using BGB.Core.Validations;
using BGB.InternetBanking.Models.Specifications.WithdrawalSpecs;

namespace BGB.InternetBanking.Models.Validations
{
    public class WithdrawalIsValidValidation : Validation<WithdrawalCommunication>
    {
        public WithdrawalIsValidValidation()
        {
            base.AddRule(new ValidationRule<WithdrawalCommunication>(new WithdrawalExpectedDateIsValidSpec(), ValidationMessages.ExpectedDateIsInvalid));
            base.AddRule(new ValidationRule<WithdrawalCommunication>(new WithdrawalExpectedDateOnDeadlineSpec(), ValidationMessages.ExpectedDateOutOfDeadline));
            base.AddRule(new ValidationRule<WithdrawalCommunication>(new WithdrawalFinalityIsRequiredSpec(), ValidationMessages.FinalityIsRequired));
            base.AddRule(new ValidationRule<WithdrawalCommunication>(new WithdrawalFinalityLengthCanNotBeGreaterThan150Spec(), ValidationMessages.FinalityLengthCanNotBeGreaterThan150));
            base.AddRule(new ValidationRule<WithdrawalCommunication>(new WithdrawalAmountIsRequiredSpec(), ValidationMessages.AmountIsRequired));
            base.AddRule(new ValidationRule<WithdrawalCommunication>(new WithdrawalAmountGreaterMinimumSpec(), ValidationMessages.AmountGreaterMinimum));
        }
    }
}