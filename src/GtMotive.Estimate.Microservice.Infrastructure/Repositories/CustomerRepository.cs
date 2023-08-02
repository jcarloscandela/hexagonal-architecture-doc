using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models;
using GtMotive.Estimate.Microservice.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    internal class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(GtMotiveContext context)
            : base(context)
        {
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await Context.Customers.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
