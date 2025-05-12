using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }
                      

        public void TCreate(Booking entity)
        {
             _bookingDal.Create(entity);
        }
         
        public void TDelete(int id)
        {
            _bookingDal.Delete(id);
        }

        public List<Booking> TGetAll()
        {
            return _bookingDal.GetAll();
        }

        public Booking TGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }

        public List<Booking> GetBookingByStatus(string status)
        {
            return _bookingDal.GetBookingByStatus(status);
        }

        public List<Booking> GetBookingByUserId(int userId)
        {
            return _bookingDal.GetBookingByUserId(userId);
        }
    }
}
