using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Models.Specifications.UserSpecs
{
    public class UserNameIsRequiredSpec : ISpecification<User>
    {
        public bool IsSatisfiedBy(User user)
        {
            return user.Name.Trim().Length > 0;
        }
    }
}