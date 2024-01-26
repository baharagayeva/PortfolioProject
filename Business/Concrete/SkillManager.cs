using Business.Abstract;
using Core.Helpers;
using Core.Helpers.Constants;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SkillManager : ISkillService
    {
        private readonly ISkillDAL _skillDAL;
        public SkillManager(ISkillDAL skillDAL)
        {
            _skillDAL = skillDAL;
        }
        public IResult Add(Skill skill)
        {
            _skillDAL.Add(skill);
            return new SuccessResult(CommonOperationMessages.DataAddedSuccessfully);
        }

        public IResult Delete(Skill skill)
        {
            _skillDAL.Update(skill);
            return new SuccessResult(CommonOperationMessages.DataDeletedSuccessfully);
        }

        public IDataResult<List<Skill>> GetAll()
        {
            return new SuccessDataResult<List<Skill>>(_skillDAL.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Skill> GetById(int id)
        {
            return new SuccessDataResult<Skill>(_skillDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IResult Update(Skill skill)
        {
            _skillDAL.Update(skill);
            return new SuccessResult(CommonOperationMessages.DataUpdatedSuccessfully);
        }
    }
}
