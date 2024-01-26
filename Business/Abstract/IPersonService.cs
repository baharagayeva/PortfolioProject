using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonService
    {
        IDataResult<List<string>> Add(Person person, string imgFile, string download);
        IResult Delete(Person person);
        IDataResult<List<string>> Update(Person person, string imgFile, string download);
        IDataResult<Person> GetById(int id);
        IDataResult <List<Person>> GetAll();
    }
}
