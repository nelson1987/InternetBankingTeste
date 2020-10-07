using BGB.Core.Validations;
using BGB.InternetBanking.Entities.Specifications.CredentialSpecs;

namespace BGB.InternetBanking.Entities.Validations
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