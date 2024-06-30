using Demo.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repository
{
    public abstract class RepositoryBase<T> : ControllerBase, IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected DbSet<T> dbSet;
        private readonly IUnitOfwork _unitOfWork;

        public RepositoryBase(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
            dbSet = _unitOfWork.DbContext.Set<T>();
        }

        //Get Request
        public async Task<IEnumerable<T>> Get()
        {
            var data = await dbSet.ToListAsync();
            return data;
        }

        //Create Request
        public async Task<T> Create(T entity)
        {
            dbSet.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        //Update Request
        public async Task<bool> Update(int id, T entity)
        {
            var existingRecord = await dbSet.FindAsync(id);
            if (existingRecord == null)
            {
                return false;
            }

            _unitOfWork.DbContext.Entry(existingRecord).CurrentValues.SetValues(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return true;
        }

        //Delete Request
        public async Task<bool> Delete(int id)
        {
            var data = await dbSet.FindAsync(id);
            if (data == null)
            {
                return false;
            }

            dbSet.Remove(data);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        //Get by Id
        public async Task<T> GetById(int id)
        {
            var data = await dbSet.FindAsync(id);
            if (data == null)
            {
                return null;
            }
            return data;
        }
    }
}
