using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Entities.Specifications.WithdrawalSpecs
{
    public class WithdrawalAmountIsRequiredSpec : ISpecification<WithdrawalCommunication>
    {
        public bool IsSatisfiedBy(WithdrawalCommunication withdrawal)
        {
            return withdrawal.Amount > 0;
        }
    }
}