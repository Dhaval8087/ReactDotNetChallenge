using Microsoft.AspNetCore.Mvc;

namespace Demo.Repository
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> Get();
        public Task<T> Create(T entity);
        public Task<bool> Update(int id, T entity);
        public Task<T> GetById(int id);
        public Task<bool> Delete(int id);
    }
}
