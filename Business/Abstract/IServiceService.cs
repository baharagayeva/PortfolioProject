using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceService
    {
        IResult Add(Service service);
        IResult Delete(Service service);
        IResult Update(Service service);
        IDataResult<Service> GetById(int id);
        IDataResult<List<Service>> GetAll();
    }
}