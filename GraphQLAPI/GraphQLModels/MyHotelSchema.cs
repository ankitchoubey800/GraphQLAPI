using GraphQL;
using GraphQL.Types;

namespace GraphQLAPI.GraphQLModels
{
    public class MyHotelSchema:Schema
    {
        public MyHotelSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MyHotelQuery>();
        }
    }
}
