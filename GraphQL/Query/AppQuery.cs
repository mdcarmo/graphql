using ex_graphql.Contracts;
using GraphQL;
using GraphQL.Types;
using System;

namespace ex_graphql.GraphQL
{
    public class AppQuery: ObjectGraphType
    {
        public AppQuery(ICustomerRepository repository)
        {
            Name = "Consultas";
            Description = "A consulta base para todas as entidades em nosso gráfico de objetos.";

            //Para listar todos os clientes com respectivas ordens
            Field<ListGraphType<CustomerType>>(
                "customers",
                "Retorna uma lista de clientes com suas respectivas ordens.",
                resolve: context => repository.GetAllWithOrders()
                );

            //para consultar um cliente pelo ID
            Field<CustomerType>("customer", "Retorna um cliente pelo ID",
                new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "Customer Id" }),
                    context => repository.GetById(Guid.Parse(context.GetArgument<string>("id")), true).Result);

            Field<CustomerType>(
                "customerById",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "customerId" }),
                resolve: context =>
                {
                    Guid id;
                    if (!Guid.TryParse(context.GetArgument<string>("customerId"), out id))
                    {
                        context.Errors.Add(new ExecutionError("Valor inserido não é um guid válido"));
                        return null;
                    }
                    return repository.GetById(id, true);
                }
            );

        }
    }
}
