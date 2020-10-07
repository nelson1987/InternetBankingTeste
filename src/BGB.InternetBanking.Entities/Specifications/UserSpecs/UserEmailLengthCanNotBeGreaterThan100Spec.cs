using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Entities.Specifications.UserSpecs
{
    public class UserEmailLengthCanNotBeGreaterThan100Spec : ISpecification<User>
    {
        public bool IsSatisfiedBy(User user)
        {
            return !string.IsNullOrEmpty(user.Email) && user.Email.Trim().Length <= 100;
        }
    }
}