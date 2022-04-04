using ex_graphql.Contracts;
using GraphQL.Types;

namespace ex_graphql.GraphQL
{
    public class AppQuery: ObjectGraphType
    {
        public AppQuery(ICustomerRepository repository)
        {
            Name = "Queries";
            Description = "The base query for all the entities in our object graph.";

            Field<ListGraphType<CustomerType>>(
                "customers",
                resolve: context => repository.GetAllWithOrders()
                );
        }
    }
}
