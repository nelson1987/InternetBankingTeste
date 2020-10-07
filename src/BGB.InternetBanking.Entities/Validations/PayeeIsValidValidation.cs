using BGB.Core.Validations;
using BGB.InternetBanking.Entities.Specifications.PayeeSpecs;

namespace BGB.InternetBanking.Entities.Validations
{
    public class PayeeIsValidValidation : Validation<Payee>
    {
        public PayeeIsValidValidation()
        {
            base.AddRule(new ValidationRule<Payee>(new PayeeNameIsRequiredSpec(), ValidationMessages.PayeeNameIsRequired));
            base.AddRule(new ValidationRule<Payee>(new PayeeNameLengthCanNotBeGreaterThan100Spec(), ValidationMessages.PayeeNameLengthCanNotBeGreaterThan100));
            base.AddRule(new ValidationRule<Payee>(new PayeeCpfIsRequiredSpec(), ValidationMessages.CpfIsRequired));
        }
    }
}