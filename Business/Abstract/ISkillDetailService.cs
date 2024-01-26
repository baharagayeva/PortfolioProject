using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISkillDetailService
    {
        IResult Add(SkillDetail skillDetail);
        IResult Delete(SkillDetail skillDetail);
        IResult Update(SkillDetail skillDetail);
        IDataResult<SkillDetail> GetById(int id);
        IDataResult<List<SkillDetail>> GetAll();
    }
}
