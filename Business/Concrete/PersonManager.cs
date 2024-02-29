using Business.Abstract;
using Core.Helpers;
using Core.Helpers.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonDAL _personDAl;
        private readonly IValidator<Person> _validationRules;

        public PersonManager(IPersonDAL personDAl, PortfolioDbContext portfolioDb, IValidator<Person> validationRules)
        {
            _personDAl = personDAl;
            _validationRules = validationRules;
        }

        public IDataResult <List<string>> Add(Person person, string imgFile, string download)
        {
            person.ProfileImgPath = imgFile;
            person.CVPath = download;
            var result = _validationRules.Validate(person);
            if (!result.IsValid)
            {
                return new ErrorDataResult<List<string>>(result.Errors.Select(x => x.PropertyName).ToList(),result.Errors.Select(x => x.ErrorMessage).ToList());
            }
            _personDAl.Add(person);
            return new SuccessDataResult<List<string>>(null, CommonOperationMessages.DataAddedSuccessfully);
        }

        public IResult Delete(Person person)
        {
            _personDAl.Update(person);
            return new SuccessResult(CommonOperationMessages.DataDeletedSuccessfully);
        }

        public IDataResult<List<Person>> GetAll()
        {
            return new SuccessDataResult<List<Person>>(_personDAl.GetAll(x=> x.Deleted == 0));
        }

        public IDataResult<Person> GetById(int id)
        {
            return new SuccessDataResult<Person>(_personDAl.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IDataResult<List<string>> Update(Person person, string imgFile, string download)
        { 
            person.ProfileImgPath = imgFile;
            person.CVPath = download;
            var result = _validationRules.Validate(person);
            if (!result.IsValid)
            {
                return new ErrorDataResult<List<string>>(result.Errors.Select(x => x.PropertyName).ToList(), result.Errors.Select(x => x.ErrorMessage).ToList());
            }
            _personDAl.Update(person);
            return new SuccessDataResult<List<string>>(null, CommonOperationMessages.DataUpdatedSuccessfully);
        }
    }
}
