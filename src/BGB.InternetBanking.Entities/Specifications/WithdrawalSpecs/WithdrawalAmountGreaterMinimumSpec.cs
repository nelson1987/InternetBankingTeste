using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Entities.Specifications.WithdrawalSpecs
{
    public class WithdrawalAmountGreaterMinimumSpec : ISpecification<WithdrawalCommunication>
    {
        public bool IsSatisfiedBy(WithdrawalCommunication withdrawal)
        {
            return withdrawal.Amount >= withdrawal.MinimumAmount;
        }
    }
}