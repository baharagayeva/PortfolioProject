using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IPortfolioDAL : IRepository<Portfoli> 
    {
        List<Portfoli> GetAll(Expression<Func<Portfoli, bool>> predicate = null);
    }
}
