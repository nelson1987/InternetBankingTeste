using BGB.Core.Validations;
using BGB.InternetBanking.Models.Specifications.CredentialSpecs;

namespace BGB.InternetBanking.Models.Validations
{
    public class CredentialIsValidValidation : Validation<Credential>
    {
        public CredentialIsValidValidation()
        {
            base.AddRule(new ValidationRule<Credential>(new CredentialLoginIsRequiredSpec(), ValidationMessages.LoginIsRequired));
            base.AddRule(new ValidationRule<Credential>(new CredentialLoginLengthCanNotBeGreaterThan30Spec(), ValidationMessages.LoginLengthCanNotGreaterThan30));
            base.AddRule(new ValidationRule<Credential>(new CredentialLoginIsRequiredSpec(), ValidationMessages.KeyIsRequired));
        }
    }
}