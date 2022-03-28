using System;
using System.Collections.Generic;

namespace ex_graphql.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
