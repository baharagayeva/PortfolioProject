using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete.EntityFramework
{
    public class MessageEFDal : RepositoryBase<Message, PortfolioDbContext>, IMessageDAL
    {

    }
}
