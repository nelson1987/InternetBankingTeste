using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Entities.Specifications.PayeeSpecs
{
    public class PayeeNameIsRequiredSpec : ISpecification<Payee>
    {
        public bool IsSatisfiedBy(Payee payee)
        {
            return payee != null && !string.IsNullOrEmpty(payee.Name) && payee.Name.Trim().Length > 0;
        }
    }
}
