using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Persistance;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GtMotiveContext _context;
        private bool _disposed;

        public UnitOfWork(GtMotiveContext context)
        {
            _context = context;
        }

        public async Task<int> Save()
        {
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}
