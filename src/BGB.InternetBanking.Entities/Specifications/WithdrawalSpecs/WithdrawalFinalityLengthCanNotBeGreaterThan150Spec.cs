using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Entities.Specifications.WithdrawalSpecs
{
    public class WithdrawalFinalityLengthCanNotBeGreaterThan150Spec : ISpecification<WithdrawalCommunication>
    {
        public bool IsSatisfiedBy(WithdrawalCommunication withdrawal)
        {
            return !string.IsNullOrEmpty(withdrawal.Finality) && withdrawal.Finality.Trim().Length <= 150;
        }
    }
}