using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISkillService
    {
        IResult Add(Skill skill);
        IResult Delete(Skill skill);
        IResult Update(Skill skill);
        IDataResult<Skill> GetById(int id);
        IDataResult<List<Skill>> GetAll();
    }
}
