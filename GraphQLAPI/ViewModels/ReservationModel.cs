using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAPI.ViewModels
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public RoomModel Room { get; set; }
        public int RoomId { get; set; }

        public GuestModel Guest { get; set; }
        public int GuestId { get; set; }
        public DateTime CheckinDate { get; set; }

        public DateTime CheckoutDate { get; set; }
    }
}
