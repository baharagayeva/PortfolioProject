using Business.Abstract;
using Core.Helpers;
using Core.Helpers.Constants;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDAL _messageDAL;
        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }
        public IResult Add(Message message)
        {
            _messageDAL.Add(message);
            return new SuccessResult(CommonOperationMessages.DataAddedSuccessfully);
        }

        public IResult Delete(Message message)
        {
            _messageDAL.Update(message);
            return new SuccessResult(CommonOperationMessages.DataDeletedSuccessfully);
        }

        public IDataResult<List<Message>> GetAll()
        {
            return new SuccessDataResult<List<Message>>(_messageDAL.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Message> GetById(int id)
        {
            return new SuccessDataResult<Message>(_messageDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IResult Update(Message message)
        {
            _messageDAL.Update(message);
            return new SuccessResult(CommonOperationMessages.DataUpdatedSuccessfully);
        }
    }
}
