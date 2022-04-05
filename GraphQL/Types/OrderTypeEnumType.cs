using ex_graphql.Entities;
using GraphQL.Types;

namespace ex_graphql.GraphQL
{
    public class OrderTypeEnumType: EnumerationGraphType<TypeOrder>
    {
        public OrderTypeEnumType()
        {
            Name = "Type";
            Description = "Enumeração para o tipo de ordem";
        }
    }
}
