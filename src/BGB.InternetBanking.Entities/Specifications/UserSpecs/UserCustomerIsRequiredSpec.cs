using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Entities.Specifications.UserSpecs
{
    public class UserCustomerIsRequiredSpec : ISpecification<User>
    {
        public bool IsSatisfiedBy(User user)
        {
            return user.Customer != null && user.Customer.Id > 0;
        }
    }
}