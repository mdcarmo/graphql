using ex_graphql.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ex_graphql.Contracts
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();

        Task<IEnumerable<Customer>> GetAllWithOrders();

        Task<Customer> GetById(Guid id, bool returnOrders);
    }
}
