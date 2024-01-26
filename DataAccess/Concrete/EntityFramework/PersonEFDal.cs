using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class PersonEFDal : RepositoryBase<Person, PortfolioDbContext>, IPersonDAL
    {
        private readonly PortfolioDbContext _dbContext;
        public PersonEFDal(PortfolioDbContext portfolioDbContext)
        {
            _dbContext = portfolioDbContext;
        }
        public List<Person> GetAll(Expression<Func<Person, bool>> predicate = null)
        {
            return predicate is null
                ?
                _dbContext.Set<Person>().Include(x => x.Position).ToList()
                :
                _dbContext.Set<Person>().Include(x => x.Position).Where(predicate).ToList(); ;
        }
    }
}
