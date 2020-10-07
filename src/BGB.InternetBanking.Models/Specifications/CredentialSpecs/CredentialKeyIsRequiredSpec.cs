using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Models.Specifications.CredentialSpecs
{
    public class CredentialKeyIsRequiredSpec : ISpecification<Credential>
    {
        public bool IsSatisfiedBy(Credential credential)
        {
            return !string.IsNullOrEmpty(credential.Key) && credential.Key.Trim().Length > 0;
        }
    }
}