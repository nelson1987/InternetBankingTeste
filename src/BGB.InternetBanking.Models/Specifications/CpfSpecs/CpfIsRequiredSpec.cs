using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Models.Specifications.CpfSpecs
{
    public class CpfIsRequiredSpec : ISpecification<Cpf>
    {
        public bool IsSatisfiedBy(Cpf cpf)
        {
            return cpf.Number > 0;
        }
    }
}