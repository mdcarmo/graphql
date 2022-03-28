using Microsoft.EntityFrameworkCore;
using System;

namespace ex_graphql.Entities.Context
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid() };

            modelBuilder.ApplyConfiguration(new CustomerContextConfiguration(ids));
            modelBuilder.ApplyConfiguration(new OrderContextConfiguration(ids));
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}

