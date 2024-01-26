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
    public class SkillDetailManager : ISkillDetailService
    {
        private readonly ISkillDetailDAL _skillDetailDAL;
        public SkillDetailManager(ISkillDetailDAL skillDetailDAL)
        {
            _skillDetailDAL = skillDetailDAL;
        }
        public IResult Add(SkillDetail skillDetail)
        {
            _skillDetailDAL.Add(skillDetail);
            return new SuccessResult(CommonOperationMessages.DataAddedSuccessfully);
        }

        public IResult Delete(SkillDetail skillDetail)
        {
            _skillDetailDAL.Update(skillDetail);
            return new SuccessResult(CommonOperationMessages.DataDeletedSuccessfully);
        }

        public IDataResult<List<SkillDetail>> GetAll()
        {
            return new SuccessDataResult<List<SkillDetail>>(_skillDetailDAL.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<SkillDetail> GetById(int id)
        {
            return new SuccessDataResult<SkillDetail>(_skillDetailDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IResult Update(SkillDetail skillDetail)
        {
            _skillDetailDAL.Update(skillDetail);
            return new SuccessResult(CommonOperationMessages.DataUpdatedSuccessfully);
        }
    }
}
