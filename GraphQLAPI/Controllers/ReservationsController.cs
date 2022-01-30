using GraphQLAPI.DataAccessLayer;
using GraphQLAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationsController(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet("[action]")]
        public async Task<List<ReservationModel>> List()
        {
            return await _reservationRepository.GetAll<ReservationModel>();
        }
    }
}
