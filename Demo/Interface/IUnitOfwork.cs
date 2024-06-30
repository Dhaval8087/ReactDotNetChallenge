using Microsoft.EntityFrameworkCore;

namespace Demo.Interface
{
    public interface IUnitOfwork : IDisposable
    {
        DbContext DbContext { get; }
        public Task SaveChangesAsync();
    }
}
