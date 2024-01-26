using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ISkillDetailDAL : IRepository<SkillDetail>
    {
        List<SkillDetail> GetAll(Expression<Func<SkillDetail, bool>> predicate = null);
    }
}
