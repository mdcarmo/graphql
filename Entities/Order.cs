using System;

namespace ex_graphql.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Quantity { get; set; }
        public TypeOrder Type { get; set; }
        public StatusOrder Status { get; set; }
    }
}
