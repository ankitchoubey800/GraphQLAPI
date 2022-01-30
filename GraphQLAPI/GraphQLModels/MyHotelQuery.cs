using GraphQL.Types;
using GraphQLAPI.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GraphQLAPI.Enums.Enums;

namespace GraphQLAPI.GraphQLModels
{
    public class MyHotelQuery : ObjectGraphType
    {        
        public MyHotelQuery(ReservationRepository reservationRepository)
        {
            //specify fields and resolve
            /*Version: 1 get all*/
            Field<ListGraphType<ReservationType>>(  //ReservationType is the type of the field
                "reservations",                     //reservations shows up in schema docs and name used for querying
                resolve: context => reservationRepository.GetQuery());  //resolver tells the query, from where to get the data from
            /*
         -- Simple test query --
            query TestQuery {
              reservations {
                id
                checkinDate
                checkoutDate
                guest {
                  id
                  name
                  registerDate
                }
                room {
                  id
                  name
                  number
                  allowedSmoking
                  status
                }
              }
            }

        */

            /*Version: 2 filtering*/
            //Field<ListGraphType<ReservationType>>("reservations",
            //    arguments: new QueryArguments(new List<QueryArgument>
            //    {
            //        new QueryArgument<IdGraphType>
            //        {
            //            Name = "id"
            //        },
            //        new QueryArgument<DateGraphType>
            //        {
            //            Name = "checkinDate"
            //        },
            //        new QueryArgument<DateGraphType>
            //        {
            //            Name = "checkoutDate"
            //        },
            //        new QueryArgument<BooleanGraphType>
            //        {
            //            Name = "roomAllowedSmoking"
            //        },
            //        new QueryArgument<RoomStatusType>
            //        {
            //            Name = "roomStatus"
            //        }
            //    }),
            //    resolve: context =>
            //    {
            //        var query = reservationRepository.GetQuery();

            //        var reservationId = context.GetArgument<int?>("id");
            //        if (reservationId.HasValue)
            //        {
            //            return reservationRepository.GetQuery().Where(r => r.Id == reservationId.Value);
            //        }

            //        var checkinDate = context.GetArgument<DateTime?>("checkinDate");
            //        if (checkinDate.HasValue)
            //        {
            //            return reservationRepository.GetQuery()
            //                .Where(r => r.CheckinDate.Date == checkinDate.Value.Date);
            //        }

            //        var checkoutDate = context.GetArgument<DateTime?>("checkoutDate");
            //        if (checkoutDate.HasValue)
            //        {
            //            return reservationRepository.GetQuery()
            //                .Where(r => r.CheckoutDate.Date >= checkoutDate.Value.Date);
            //        }

            //        var allowedSmoking = context.GetArgument<bool?>("roomAllowedSmoking");
            //        if (allowedSmoking.HasValue)
            //        {
            //            return reservationRepository.GetQuery()
            //                .Where(r => r.Room.AllowedSmoking == allowedSmoking.Value);
            //        }

            //        var roomStatus = context.GetArgument<RoomStatus?>("roomStatus");
            //        if (roomStatus.HasValue)
            //        {
            //            return reservationRepository.GetQuery().Where(r => r.Room.Status == roomStatus.Value);
            //        }

            //        return query.ToList();
            //    }
            //);

        }
    }

}
