using ex_graphql.Contracts;
using ex_graphql.Entities;
using ex_graphql.GraphQL.Types;
using GraphQL;
using GraphQL.Types;
using System;

namespace ex_graphql.GraphQL
{
    public class AppMutation: ObjectGraphType
    {
        public AppMutation(ICustomerRepository repository)
        {

            Field<CustomerType>(
                "createCustomer",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CustomerInputType>> { Name = "customer" }),
                resolve: context =>
                {
                    var customer = context.GetArgument<Customer>("customer");
                    return repository.Create(customer);
                }
            );

            Field<CustomerType>(
                "updateCustomer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CustomerInputType>> { Name = "customer" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "customerId" }),
                resolve: context =>
                {
                    var customer = context.GetArgument<Customer>("customer");
                    var customerId = context.GetArgument<Guid>("customerId");

                    var dbCustomer = repository.GetById(customerId, false).Result;
                    if (dbCustomer == null)
                    {
                        context.Errors.Add(new ExecutionError("Cliente não encontrado na base de dados com este id."));
                        return null;
                    }

                    return repository.Update(dbCustomer, customer);
                }
            );

            Field<StringGraphType>(
                "deleteCustomer",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "customerId" }),
                resolve: context =>
                {
                    var customerId = context.GetArgument<Guid>("customerId");
                    var customer = repository.GetById(customerId, false).Result; 
                    if (customer == null)
                    {
                        context.Errors.Add(new ExecutionError("Cliente não encontrado na base de dados com este id."));
                        return null;
                    }
                    repository.Delete(customer);
                    return $"O Cliente com o id: {customerId} foi excluido da base de dados com sucesso.";
                }
            );
        }
    }
}
