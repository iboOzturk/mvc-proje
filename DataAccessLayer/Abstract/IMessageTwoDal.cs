using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageTwoDal:IGenericDal<MessageTwo>
    {
        List<MessageTwo> GetInboxListWithMessageByWriter(int id);
        List<MessageTwo> GetSendBoxListWithMessageByWriter(int id);
    }
}
