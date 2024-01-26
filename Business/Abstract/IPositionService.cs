using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPositionService
    {
        IResult Add(Position position);
        IResult Delete(Position position);
        IResult Update(Position position);
        IDataResult<Position> GetById(int id);
        IDataResult<List<Position>> GetAll();   
    }
}
