using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    internal class ReviewManager(IReviewDal _reviewDal) : IReviewDal
    {
        public void Create(Review entity)
        {
            _reviewDal.Create(entity);  
        }

        public void Delete(int id)
        {
            _reviewDal.Delete(id);
        }

        public List<Review> GetAll()
        {
            return _reviewDal.GetAll(); 
        }

        public Review GetById(int id)
        {
            return _reviewDal.GetById(id);
        }

        public void Update(Review entity)
        {
            _reviewDal.Update(entity);  
        }
    }
}
