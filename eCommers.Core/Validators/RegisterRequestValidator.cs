using eCommers.Core.DTO;
using eCommers.Core.DTO.Enums;
using FluentValidation;

namespace eCommers.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            //Email
            RuleFor(temp => temp.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address format");
            
            //Password
            RuleFor(temp => temp.Password)
            .NotEmpty().WithMessage("Password is required");
        
            //PersonName
            RuleFor(temp => temp.PersonName)
            .NotEmpty().WithMessage("Person name is required");

            //Gender
            RuleFor(temp => temp.Gender)
            .IsInEnum().WithMessage("Gender is required");


        }
    }
}