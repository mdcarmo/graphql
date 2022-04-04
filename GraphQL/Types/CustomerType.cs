using ex_graphql.Entities;
using ex_graphql.Entities.Context;
using GraphQL.Types;

namespace ex_graphql.GraphQL
{
    public class CustomerType: ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the customer object.");
            Field(x => x.Name).Description("Name property from the csutomer object.");

            Field(
                name: "orders",
                description: "Lista de ordens",
                type: typeof(ListGraphType<OrderType>),
                resolve: m => m.Source.Orders);
        }
    }
}
