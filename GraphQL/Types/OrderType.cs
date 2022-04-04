using ex_graphql.Entities;
using GraphQL.Types;

namespace ex_graphql.GraphQL
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the order object.");
            Field(x => x.CustomerId, type: typeof(IdGraphType)).Description("CustomerId property from the order object.");
            Field(x => x.CreatedAt).Description("Order creation date.");
            Field(x => x.Price).Description("Asset unit price.");
            Field(x => x.Quantity).Description("Amount of order assets.");
            Field(x => x.Symbol).Description("asset symbol.");
            //Field(x => x.Type).Description("Order Type.");
            //Field(x => x.Status).Description("Order Status.");
        }
    }
}
