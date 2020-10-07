using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Entities.Specifications.UserSpecs
{
    public class UserCredentialIsRequiredSpec : ISpecification<User>
    {
        public bool IsSatisfiedBy(User user)
        {
            return user.Credential != null && user.Credential.Login.Trim().Length > 0;
        }
    }
}