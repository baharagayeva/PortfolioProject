using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IExperienceDAL:IRepository<Experience> 
    {
        List<Experience> GetAll(Expression<Func<Experience, bool>> predicate = null);
    }

}
