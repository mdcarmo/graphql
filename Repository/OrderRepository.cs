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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;
        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllByCustomer(Guid customerId)
        {
            return await _context.Orders.Where(a => a.CustomerId.Equals(customerId)).ToListAsync();
        }
    }
}
