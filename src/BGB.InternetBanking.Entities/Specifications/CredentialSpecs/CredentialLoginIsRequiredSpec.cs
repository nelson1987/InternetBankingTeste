using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Entities.Specifications.CredentialSpecs
{
    public class CredentialLoginIsRequiredSpec : ISpecification<Credential>
    {
        public bool IsSatisfiedBy(Credential credential)
        {
            return !string.IsNullOrEmpty(credential.Login) && credential.Login.Trim().Length > 0;
        }
    }
}