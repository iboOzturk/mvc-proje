using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageTwoManager : IMessageTwoService
    {
        IMessageTwoDal _messageTwoDal;

        public MessageTwoManager(IMessageTwoDal messageTwoDal)
        {
            _messageTwoDal = messageTwoDal;
        }

        public List<MessageTwo> GetInboxListByWriter(int id)    
        {
            return _messageTwoDal.GetInboxListWithMessageByWriter(id);
        }

        public List<MessageTwo> GetList()
        {
            return _messageTwoDal.GetListAll();
        }

        public List<MessageTwo> GetSendboxListByWriter(int id)
        {
            return _messageTwoDal.GetSendBoxListWithMessageByWriter(id);
        }

        public void TAdd(MessageTwo t)
        {
            _messageTwoDal.Insert(t);
        }

        public void TDelete(MessageTwo t)
        {
            throw new NotImplementedException();
        }

        public MessageTwo TGetById(int id)
        {
            return _messageTwoDal.GetById(id);
        }

        public void TUpdate(MessageTwo t)
        {
            throw new NotImplementedException();
        }
    }
}
