using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete.EntityFramework
{
    public class SkillEFDal : RepositoryBase<Skill, PortfolioDbContext>, ISkillDAL
    {

    }
}
