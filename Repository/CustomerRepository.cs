using ex_graphql.Contracts;
using ex_graphql.Entities;
using ex_graphql.Entities.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex_graphql.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _context;

        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(Guid id)
        {
            return await _context.Customers.Where(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
