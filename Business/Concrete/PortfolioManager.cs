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
    public class PortfolioManager : IPortfolioService
    {
        private readonly IPortfolioDAL _portfolioDAL;
        private readonly IValidator<Portfoli> _validationRules;
        public PortfolioManager(IPortfolioDAL portfolioDAL, IValidator<Portfoli> validationRules)
        {
            _portfolioDAL = portfolioDAL;
            _validationRules = validationRules;
        }
        public IDataResult<List<string>> Add(Portfoli portfolio, string workImgFile)
        {
            portfolio.WorkImgPath = workImgFile;
            var result = _validationRules.Validate(portfolio);
            if (!result.IsValid)
            {
                return new ErrorDataResult<List<string>>(result.Errors.Select(x => x.PropertyName).ToList(), result.Errors.Select(x => x.ErrorMessage).ToList());
            }
            _portfolioDAL.Add(portfolio);
            return new SuccessDataResult<List<string>>(null, CommonOperationMessages.DataAddedSuccessfully);
        }

        public IResult Delete(Portfoli portfolio)
        {
            _portfolioDAL.Update(portfolio);
            return new SuccessResult(CommonOperationMessages.DataDeletedSuccessfully);
        }

        public IDataResult<List<Portfoli>> GetAll()
        {
            return new SuccessDataResult<List<Portfoli>>(_portfolioDAL.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Portfoli> GetById(int id)
        {
            return new SuccessDataResult<Portfoli>(_portfolioDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IDataResult<List<string>> Update(Portfoli portfolio, string workImgFile)
        {
            portfolio.WorkImgPath = workImgFile;
            var result = _validationRules.Validate(portfolio);
            if (!result.IsValid)
            {
                return new ErrorDataResult<List<string>>(result.Errors.Select(x => x.PropertyName).ToList(), result.Errors.Select(x => x.ErrorMessage).ToList());
            }
            _portfolioDAL.Update(portfolio);
            return new SuccessDataResult<List<string>>(null, CommonOperationMessages.DataAddedSuccessfully);
        }
    }
}
