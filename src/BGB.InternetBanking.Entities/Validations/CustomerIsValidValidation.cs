using BGB.Core.Validations;
using BGB.InternetBanking.Entities.Specifications.CustomerSpecs;

namespace BGB.InternetBanking.Entities.Validations
{
    public class CustomerIsValidValidation : Validation<Customer>
    {
        public CustomerIsValidValidation()
        {
            base.AddRule(new ValidationRule<Customer>(new CustomerNameIsRequiredSpec(), ValidationMessages.NameIsRequired));
            base.AddRule(new ValidationRule<Customer>(new CustomerCpfCnpjIsRequiredSpec(), ValidationMessages.CpfCnpjIsRequired));
            base.AddRule(new ValidationRule<Customer>(new CustomerAccountIsRequiredSpec(), ValidationMessages.AccountIsRequired));
            base.AddRule(new ValidationRule<Customer>(new CustomerNameLengthCanNotGreaterThan50Spec(), ValidationMessages.NameLengthCanNotGreaterThan50));
        }
    }
}