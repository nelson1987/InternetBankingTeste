using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Models.Specifications.WithdrawalSpecs
{
    public class WithdrawalExpectedDateOnDeadlineSpec : ISpecification<WithdrawalCommunication>
    {
        public bool IsSatisfiedBy(WithdrawalCommunication withdrawal)
        {
            return withdrawal.CommunicationDateValid.Date.AddDays(withdrawal.DaysInAdvance) <= withdrawal.ExpectedDate.Date;
        }
    }
}