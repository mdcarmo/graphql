using ex_graphql.Entities;
using GraphQL.Types;

namespace ex_graphql.GraphQL
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Identificador da ordem de compra.");
            Field(x => x.CustomerId, type: typeof(IdGraphType)).Description("Identificador do cliente.");
            Field(x => x.CreatedAt).Description("Data de criação da ordem.");
            Field(x => x.Price).Description("Preço unitário do ativo.");
            Field(x => x.Quantity).Description("Quantidade de ativos na ordem.");
            Field(x => x.Symbol).Description("Simbolo do ativo.");
            Field<OrderTypeEnumType>("Type", "Enumeração para o tipo de ordem.");
            Field<StatusOrderEnumType>("Status", "Enumeração para o status de ordem.");
        }
    }
}
