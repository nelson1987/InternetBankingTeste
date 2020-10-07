using BGB.Core.Validations;
using BGB.InternetBanking.Models.Specifications.CpfSpecs;

namespace BGB.InternetBanking.Models.Validations
{
    public class CpfIsValidValidation : Validation<Cpf>
    {
        public CpfIsValidValidation()
        {
            base.AddRule(new ValidationRule<Cpf>(new CpfIsRequiredSpec(), ValidationMessages.CpfIsRequired));
            base.AddRule(new ValidationRule<Cpf>(new CpfIsValidSpec(), ValidationMessages.CpfIsInvalid));
        }
    }
}