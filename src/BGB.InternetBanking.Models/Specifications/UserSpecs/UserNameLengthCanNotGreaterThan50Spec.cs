using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Models.Specifications.UserSpecs
{
    public class UserNameLengthCanNotGreaterThan50Spec : ISpecification<User>
    {
        public bool IsSatisfiedBy(User user)
        {
            return !string.IsNullOrEmpty(user.Email) && user.Name.Trim().Length <= 50;
        }
    }
}