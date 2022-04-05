using ex_graphql.Entities;
using GraphQL.Types;

namespace ex_graphql.GraphQL
{
    public class StatusOrderEnumType : EnumerationGraphType<StatusOrder>
    {
        public StatusOrderEnumType()
        {
            Name = "Status";
            Description = "Status da ordem";
        }
    }
}
