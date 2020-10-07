using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Models.Specifications.CustomerSpecs
{
    public class CustomerAccountIsRequiredSpec : ISpecification<Customer>
    {
        public bool IsSatisfiedBy(Customer customer)
        {
            return customer.CheckingAccount != null && customer.CheckingAccount.Number != 0;
        }
    }
}