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
    public class SendMessageManager(ISendMessageDal _messageDal) : ISendMessageService
    {
        public void TCreate(SendMessage entity)
        {
            _messageDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _messageDal.Delete(id);
        }

        public List<SendMessage> TGetAll()
        {
            return _messageDal.GetAll();    
        }

        public SendMessage TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public void TUpdate(SendMessage entity)
        {
            _messageDal.Update(entity); 
        }
    }
}
