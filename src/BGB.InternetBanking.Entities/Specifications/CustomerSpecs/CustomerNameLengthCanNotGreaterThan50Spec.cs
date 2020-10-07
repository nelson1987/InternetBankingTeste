using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Entities.Specifications.CustomerSpecs
{
    public class CustomerNameLengthCanNotGreaterThan50Spec : ISpecification<Customer>
    {
        public bool IsSatisfiedBy(Customer customer)
        {
            return !string.IsNullOrEmpty(customer.Name) && customer.Name.Trim().Length <= 50;
        }
    }
}