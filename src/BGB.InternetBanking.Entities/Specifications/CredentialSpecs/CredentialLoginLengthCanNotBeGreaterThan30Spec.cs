using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Entities.Specifications.CredentialSpecs
{
    public class CredentialLoginLengthCanNotBeGreaterThan30Spec : ISpecification<Credential>
    {
        public bool IsSatisfiedBy(Credential credential)
        {
            return !string.IsNullOrEmpty(credential.Login) && credential.Login.Trim().Length <= 30;
        }
    }
}