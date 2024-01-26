using Business.Abstract;
using Core.Helpers;
using Core.Helpers.Constants;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExperienceManager : IExperienceService
    {
        private readonly IExperienceDAL _experienceDAL;
        private readonly IValidator<Experience> _validationRules;
        public ExperienceManager(IExperienceDAL experienceDAL, IValidator<Experience> validationRules)
        {
            _experienceDAL = experienceDAL;
            _validationRules = validationRules;
        }
        public IDataResult<List<string>> Add(Experience experience)
        {
            var result = _validationRules.Validate(experience);
            if (!result.IsValid)
            {
                return new ErrorDataResult<List<string>>(result.Errors.Select(x => x.PropertyName).ToList(), result.Errors.Select(x => x.ErrorMessage).ToList());
            }
            _experienceDAL.Add(experience);
            return new SuccessDataResult<List<string>>(null, CommonOperationMessages.DataAddedSuccessfully);
        }

        public IResult Delete(Experience experience)
        {
            _experienceDAL.Update(experience);
            return new SuccessResult(CommonOperationMessages.DataDeletedSuccessfully);
        }

        public IDataResult<List<Experience>> GetAll()
        {
            return new SuccessDataResult<List<Experience>>(_experienceDAL.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Experience> GetById(int id)
        {
            return new SuccessDataResult<Experience>(_experienceDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IDataResult<List<string>> Update(Experience experience)
        {
            var result = _validationRules.Validate(experience);
            if (!result.IsValid)
            {
                return new ErrorDataResult<List<string>>(result.Errors.Select(x => x.PropertyName).ToList(), result.Errors.Select(x => x.ErrorMessage).ToList());
            }
            _experienceDAL.Update(experience);
            return new SuccessDataResult<List<string>>(null, CommonOperationMessages.DataAddedSuccessfully);
        }
    }
}
