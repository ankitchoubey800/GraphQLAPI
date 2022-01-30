using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GraphQLAPI.Enums.Enums;

namespace GraphQLAPI.ViewModels
{
    public class RoomModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public RoomStatus Status { get; set; }

        public bool AllowedSmoking { get; set; }
    }
}
