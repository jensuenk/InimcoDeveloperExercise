using FluentValidation;
using SocialSkillsApi.Models;

namespace SocialSkillsApi.Validators
{
    public class UserProfileValidator : AbstractValidator<UserProfile>
    {
        public UserProfileValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleForEach(x => x.SocialAccounts).SetValidator(new SocialAccountValidator());
        }
    }

    public class SocialAccountValidator : AbstractValidator<SocialAccount>
    {
        public SocialAccountValidator()
        {
            RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
        }
    }
}
