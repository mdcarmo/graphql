using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex_graphql.GraphQL.Types
{
    public class CustomerInputType: InputObjectGraphType
    {
        public CustomerInputType()
        {
            Name = "customerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("identificationNumber");
            Field<NonNullGraphType<StringGraphType>>("email");
        }
        
    }
}
