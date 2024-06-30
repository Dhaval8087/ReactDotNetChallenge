using Demo.Context;
using Demo.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace Demo.Service
{
    public class UnitOfwork : IUnitOfwork
    {
        private readonly ContactDbContext _context;
        private bool _disposed = false;

        public UnitOfwork(ContactDbContext context)
        {
            _context = context;
        }

        public DbContext DbContext => _context;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
