using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class PortfolioValidator : AbstractValidator<Portfoli>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title can not be empty");
            RuleFor(x => x.WorkImgPath).NotEmpty().WithMessage("Work Image can not be empty");
        }
    }
}
