using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPortfolioService
    {
        IDataResult<List<string>> Add(Portfoli portfolio, string workImgFile);
        IResult Delete(Portfoli portfolio);
        IDataResult<List<string>> Update(Portfoli portfolio, string workImgFile);
        IDataResult<Portfoli> GetById(int id);
        IDataResult<List<Portfoli>> GetAll();
    }
}
