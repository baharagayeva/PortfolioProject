using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class ExperienceEFDal : RepositoryBase<Experience, PortfolioDbContext>, IExperienceDAL
    {
        private readonly PortfolioDbContext _dbContext;
        public ExperienceEFDal(PortfolioDbContext portfolioDbContext)
        {
            _dbContext = portfolioDbContext;
        }
        public List<Experience> GetAll(Expression<Func<Experience, bool>> predicate = null)
        {
            return predicate is null
                ?
                _dbContext.Set<Experience>().Include(x => x.Position).ToList()
                :
                _dbContext.Set<Experience>().Include(x => x.Position).Where(predicate).ToList();
        }
    }
}
