using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ex_graphql.Entities.Context
{
    public class CustomerContextConfiguration : IEntityTypeConfiguration<Customer>
    {
        private Guid[] _ids;

        public CustomerContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id = _ids[0],
                    Name = "John Doe",
                    Email = "johndoe@doe.com",
                    IdentificationNumber = "123456789"
                },
                new Customer
                {
                    Id = _ids[1],
                    Name = "Marie Doe",
                    Email = "mariedoe@doe.com",
                    IdentificationNumber = "12345678"
                }
                );
        }
    }
}
