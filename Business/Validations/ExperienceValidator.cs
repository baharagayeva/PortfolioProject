using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class ExperienceValidator : AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.CompanyName).NotNull().NotEmpty().WithMessage("Company Name can not be empty")
                                       .MaximumLength(50).WithMessage("Company Name can not be more than 50 symbols");
            RuleFor(x => x.PositionID).NotEmpty().WithMessage("Position can not be empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description can not be empty")
                                       .MinimumLength(50).WithMessage("Please enter at least 50 symbols");
            RuleFor(x => x.EntryDate).NotEmpty().WithMessage("Entry Date can not be null");

        }
    }
}
