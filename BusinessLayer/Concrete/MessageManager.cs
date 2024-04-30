using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetListReceiverMessage(int p)
        {
            return _messageDal.GetByFilter(x => x.ReceiverId == p && x.MessageTrash == false);
        }

        public List<Message> GetListSenderMessage(int p)
        {
            return _messageDal.GetByFilter(x=> x.SenderId == p && x.MessageTrash == false);
        }

        public void TDelete(int id)
        {
            _messageDal.Delete(id);
        }

        public List<Message> TGetAll()
        {
            return _messageDal.GetAll();
        }

        public List<Message> TGetByFilter(Expression<Func<Message, bool>> filter)
        {
           return _messageDal.GetByFilter(filter);
        }

        public Message TGetById(int id)
        {
           return _messageDal.GetById(id);
        }

        public List<Message> TGetMessageWithUsers()
        {
           return _messageDal.GetMessageWithUsers();
        }

        public void TInsert(Message entity)
        {
           _messageDal.Insert(entity);
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
