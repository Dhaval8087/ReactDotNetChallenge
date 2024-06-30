using Demo.Context;
using Demo.Interface;
using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;
        IRepository<Contact> contactRepository;

        public HomeController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
            contactRepository = new ContactRepository(_unitOfWork);
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await contactRepository.Get();
            return View(contacts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            await contactRepository.Create(contact);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int Id)
        {
            var contact = await contactRepository.GetById(Id);
            return PartialView("_ContactInfo", contact);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Contact contact)
        {
            await contactRepository.Update(contact.ContactId,contact);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await contactRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
