using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T>
        where T : class
    {
        private readonly GtMotiveContext _context;

        public RepositoryBase(GtMotiveContext context)
        {
            _context = context;
        }

        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
