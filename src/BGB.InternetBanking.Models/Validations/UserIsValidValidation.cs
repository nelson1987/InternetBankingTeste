using BGB.Core.Validations;
using BGB.InternetBanking.Models.Specifications.UserSpecs;

namespace BGB.InternetBanking.Models.Validations
{
    public class UserIsValidValidation : Validation<User>
    {
        public UserIsValidValidation()
        {
            base.AddRule(new ValidationRule<User>(new UserCustomerIsRequiredSpec(), ValidationMessages.CustomerIsRequired));
            base.AddRule(new ValidationRule<User>(new UserCredentialIsRequiredSpec(), ValidationMessages.CredentialIsRequired));
            base.AddRule(new ValidationRule<User>(new UserNameIsRequiredSpec(), ValidationMessages.NameIsRequired));
            base.AddRule(new ValidationRule<User>(new UserNameLengthCanNotGreaterThan50Spec(), ValidationMessages.NameLengthCanNotGreaterThan50));
            base.AddRule(new ValidationRule<User>(new UserEmailIsRequiredSpec(), ValidationMessages.EmailIsRequired));
            base.AddRule(new ValidationRule<User>(new UserEmailLengthCanNotBeGreaterThan100Spec(), ValidationMessages.EmailLengthCanNotGreaterThan100));
        }
    }
}