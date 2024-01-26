using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class SkillDetailEFDal : RepositoryBase<SkillDetail, PortfolioDbContext>, ISkillDetailDAL
    {
        private readonly PortfolioDbContext _dbContext;
        public SkillDetailEFDal(PortfolioDbContext portfolioDbContext)
        {
            _dbContext = portfolioDbContext;
        }
        public List<SkillDetail> GetAll(Expression<Func<SkillDetail, bool>> predicate = null)
        {
            return predicate is null
                ?
                _dbContext.Set<SkillDetail>().Include(x => x.Skill).ToList()
                :
                _dbContext.Set<SkillDetail>().Include(x => x.Skill).Where(predicate).ToList(); ;
        }
    }
}
