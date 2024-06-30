using Demo.Context;
using Demo.Interface;

namespace Demo.Repository
{
    public class ContactRepository : RepositoryBase<Contact>
    {
        public ContactRepository(IUnitOfwork unitOfwork) : base(unitOfwork)
        {
        }
    }
}
