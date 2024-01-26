using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete.EntityFramework
{
    public class ServiceEFDal : RepositoryBase<Service, PortfolioDbContext>, IServiceDAL
    {

    }
}
