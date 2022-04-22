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

        public async Task<IEnumerable<Customer>> GetAllWithOrders()
        {
            return await _context.Customers.Include(x => x.Orders).ToListAsync();
        }

        public async Task<Customer> GetById(Guid id, bool returnOrders)
        {
            if (returnOrders)
            {
                return await _context.Customers
                        .Include(x => x.Orders)
                        .Where(x => x.Id == id)
                        .SingleOrDefaultAsync();
            }   
            else
            {
                return await _context.Customers
                        .Where(x => x.Id == id)
                        .SingleOrDefaultAsync();
            }
        }

        public async Task<Customer> Create(Customer customer)
        {
            customer.Id = Guid.NewGuid();
             _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Update(Customer dbCustomer, Customer customer)
        {
            dbCustomer.Name = customer.Name;
            dbCustomer.IdentificationNumber = customer.IdentificationNumber;
            dbCustomer.Email = customer.Email;
            await _context.SaveChangesAsync();

            return dbCustomer;
        }

        public async Task Delete(Customer customer)
        {
            _context.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
