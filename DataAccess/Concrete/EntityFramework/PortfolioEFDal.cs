using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class PortfolioEFDal : RepositoryBase<Portfoli, PortfolioDbContext>, IPortfolioDAL
    {
        private readonly PortfolioDbContext _dbContext;
        public PortfolioEFDal(PortfolioDbContext portfolioDbContext)
        {
            _dbContext = portfolioDbContext;
        }
        public List<Portfoli> GetAll(Expression<Func<Portfoli, bool>> predicate = null)
        {
            return predicate is null
                ?
                _dbContext.Set<Portfoli>().Include(x => x.WorkCategory).ToList()
                :
                _dbContext.Set<Portfoli>().Include(x => x.WorkCategory).Where(predicate).ToList(); ;
        }
    }
}
