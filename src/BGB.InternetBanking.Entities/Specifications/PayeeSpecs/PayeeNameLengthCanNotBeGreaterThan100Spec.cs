using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Entities.Specifications.PayeeSpecs
{
    public class PayeeNameLengthCanNotBeGreaterThan100Spec : ISpecification<Payee>
    {
        public bool IsSatisfiedBy(Payee payee)
        {
            return !string.IsNullOrEmpty(payee.Name) && payee.Name.Trim().Length <= 100;
        }
    }
}