using GraphQL.Types;
using GraphQLAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAPI.GraphQLModels
{
    public class ReservationType : ObjectGraphType<Reservation>
    {
        public ReservationType()
        {
            Field(x => x.Id);
            Field(x => x.CheckinDate);
            Field(x => x.CheckoutDate);
            Field<GuestType>(nameof(Reservation.Guest));
            Field<RoomType>(nameof(Reservation.Room));
        }
    }
}
