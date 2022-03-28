using ex_graphql.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ex_graphql.Contracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<IEnumerable<Order>> GetAllByCustomer(Guid customerId);
    }
}
