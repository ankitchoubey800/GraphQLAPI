using GraphQL.Types;
using GraphQLAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAPI.GraphQLModels
{
    public class GuestType : ObjectGraphType<Guest>
    {
        public GuestType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.RegisterDate);
        }
    }
}
