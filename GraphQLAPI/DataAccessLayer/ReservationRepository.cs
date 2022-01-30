using AutoMapper.QueryableExtensions;
using GraphQLAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAPI.DataAccessLayer
{
    public class ReservationRepository
    {
        private readonly MyHotelDbContext _myHotelDbContext;

        public ReservationRepository(MyHotelDbContext myHotelDbContext)
        {
            _myHotelDbContext = myHotelDbContext;
        }

        public async Task<List<T>> GetAll<T>()
        {
            return await _myHotelDbContext
                .Reservations
                .Include(x => x.Room)
                .Include(x => x.Guest)
                .ProjectTo<T>()
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await _myHotelDbContext
                .Reservations
                .Include(x => x.Room)
                .Include(x => x.Guest)
                .ToListAsync();
        }
        public IIncludableQueryable<Reservation, Guest> GetQuery()
        {
            return _myHotelDbContext
                 .Reservations
                 .Include(x => x.Room)
                 .Include(x => x.Guest);
        }
    }

}
