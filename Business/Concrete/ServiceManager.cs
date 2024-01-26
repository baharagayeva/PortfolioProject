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
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDAL _serviceDAL;
        public ServiceManager(IServiceDAL serviceDAL)
        {
            _serviceDAL = serviceDAL;
        }
        public IResult Add(Service service)
        {
            _serviceDAL.Add(service);
            return new SuccessResult(CommonOperationMessages.DataAddedSuccessfully);
        }

        public IResult Delete(Service service)
        {
            _serviceDAL.Update(service);
            return new SuccessResult(CommonOperationMessages.DataDeletedSuccessfully);
        }

        public IDataResult<List<Service>> GetAll()
        {
            return new SuccessDataResult<List<Service>>(_serviceDAL.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Service> GetById(int id)
        {
            return new SuccessDataResult<Service>(_serviceDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IResult Update(Service service)
        {
            _serviceDAL.Update(service);
            return new SuccessResult(CommonOperationMessages.DataUpdatedSuccessfully);
        }
    }
}
