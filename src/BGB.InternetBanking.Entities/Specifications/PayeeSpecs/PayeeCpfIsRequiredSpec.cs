using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Entities.Specifications.PayeeSpecs
{
    public class PayeeCpfIsRequiredSpec : ISpecification<Payee>
    {
        public bool IsSatisfiedBy(Payee payee)
        {
            return payee.Cpf != null && payee.Cpf.Number > 0;
        }
    }
}