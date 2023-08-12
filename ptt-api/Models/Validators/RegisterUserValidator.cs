using FluentValidation;
using ptt_api.Entities;

namespace ptt_api.Models.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(DancersDbContext dancersDbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .MinimumLength(6);
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password);
            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dancersDbContext.Users.Any(x => x.ContactEmail == value);
                    if(emailInUse)
                    {
                        context.AddFailure("ContactEmail", "That Email is taken");
                    }
                }); // nasz własny warunek walidacji
        }
    }
}
