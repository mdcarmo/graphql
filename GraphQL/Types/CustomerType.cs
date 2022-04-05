using ex_graphql.Entities;
using ex_graphql.Entities.Context;
using GraphQL.Types;

namespace ex_graphql.GraphQL
{
    public class CustomerType: ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Identificador do cliente.");
            Field(x => x.Name).Description("Nome do cliente.");
            Field(x => x.IdentificationNumber).Description("Número de identificaçao do cliente.");
            Field(x => x.Email).Description("Email do cliente.");
            Field(
                name: "orders",
                description: "Lista de ordens",
                type: typeof(ListGraphType<OrderType>),
                resolve: m => m.Source.Orders);
        }
    }
}
