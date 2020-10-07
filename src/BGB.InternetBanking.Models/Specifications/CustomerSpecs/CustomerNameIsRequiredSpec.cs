using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Models.Specifications.CustomerSpecs
{
    public class CustomerNameIsRequiredSpec : ISpecification<Customer>
    {
        public bool IsSatisfiedBy(Customer customer)
        {
            return !string.IsNullOrEmpty(customer.Name) && customer.Name.Trim().Length > 0;
        }
    }
}