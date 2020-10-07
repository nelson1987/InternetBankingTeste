using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Models.Specifications.WithdrawalSpecs
{
    public class WithdrawalExpectedDateIsValidSpec : ISpecification<WithdrawalCommunication>
    {
        public bool IsSatisfiedBy(WithdrawalCommunication withdrawal)
        {
            return withdrawal.ExpectedDate.Date == withdrawal.ExpectedDateValid.Date;
        }
    }
}