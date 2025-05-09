using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class UserManager(IUserDal _userDal) : IUserService
    {
        public void TCreate(AppUser entity)
        {
            _userDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _userDal.Delete(id);
        }

        public List<AppUser> TGetAll()
        {
            return _userDal.GetAll();
        }

        public AppUser TGetById(int id)
        {
            return _userDal.GetById(id);
        }

        public void TUpdate(AppUser entity)
        {
            _userDal.Update(entity);
        }
    }
}
