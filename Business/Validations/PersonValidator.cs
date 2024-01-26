using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public  class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name can not be empty")
                                     .MinimumLength(3).WithMessage("First Name contains at least 3 symbols");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name can not be empty")
                                     .MinimumLength(5).WithMessage("Last Name must be contains at least 5 symbols");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Birth date can not be empty");
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Adress can not be empty")
                                  .Length(5, 100).WithMessage("Adress must be contains at least 5 and at most 100 symbols");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                                 .Length(10, 30).WithMessage("Email can contain more than 10 and less than 30 symbols")
                                 .EmailAddress().WithMessage("Please enter correct email");
            RuleFor(x => x.Website).NotEmpty().WithMessage("Website is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description can not be empty")
                                       .MinimumLength(50).WithMessage("Please enter at least 50 symbols");
            RuleFor(x => x.ProfileImgPath).NotEmpty().WithMessage("Image is required");
            RuleFor(x => x.CVPath).NotEmpty().WithMessage("CV is required");
        }
    }
}
