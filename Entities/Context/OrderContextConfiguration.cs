using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex_graphql.Entities.Context
{
    public class OrderContextConfiguration : IEntityTypeConfiguration<Order>
    {
        private Guid[] _ids;

        public OrderContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order
                {
                    Id = Guid.NewGuid(),
                    CustomerId = _ids[0],
                    Symbol = "PETR4",
                    Price = 24,
                    Quantity = 10,
                    CreatedAt = DateTime.Now,
                    Status = StatusOrder.Liquidated,
                    Type = TypeOrder.DayTrade
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    CustomerId = _ids[0],
                    Symbol = "OIBR3",
                    Price = 4,
                    Quantity = 100,
                    CreatedAt = DateTime.Now,
                    Status = StatusOrder.Pending,
                    Type = TypeOrder.DayTrade
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    CustomerId = _ids[1],
                    Symbol = "BBDC4",
                    Price = 24,
                    Quantity = 10,
                    CreatedAt = DateTime.Now,
                    Status = StatusOrder.Pending,
                    Type = TypeOrder.SwingTrade
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    CustomerId = _ids[1],
                    Symbol = "PETR4",
                    Price = 24,
                    Quantity = 20,
                    CreatedAt = DateTime.Now,
                    Status = StatusOrder.Liquidated,
                    Type = TypeOrder.DayTrade
                }
                );
        }
    }
}
