using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Entities.Specifications.CustomerSpecs
{
    public class CustomerCpfCnpjIsRequiredSpec : ISpecification<Customer>
    {
        public bool IsSatisfiedBy(Customer customer)
        {
            return customer.CpfCnpj != 0;
        }
    }
}