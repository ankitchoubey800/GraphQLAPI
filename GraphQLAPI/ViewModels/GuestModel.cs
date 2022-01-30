using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAPI.ViewModels
{
    public class GuestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
