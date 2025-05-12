using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrete
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(CentalContext context) : base(context)
        {
        }

        public List<Booking> GetBookingByStatus(string status)
        {
            return _context.Set<Booking>().Where(x => x.Status == status).ToList();
        }

        public List<Booking> GetBookingByUserId(int userId)
        {
            return _context.Set<Booking>().Where(x => x.AppUserId == userId).ToList();
        }
    }
}
