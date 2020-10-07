using BGB.Core.Validations;
using BGB.InternetBanking.Models.Enums;
using BGB.InternetBanking.Models.Validations;
using System.Collections.Generic;

namespace BGB.InternetBanking.Models
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual long CpfCnpj { get; set; }
        public virtual PersonTypeEnum PersonType { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; }
        public virtual bool Active { get; set; }

        public virtual IEnumerable<BindedAccount> BindedAccounts { get; set; }

        public virtual ValidationResult ValidationResult { get; protected set; }

        public virtual bool IsValid
        {
            get
            {
                var entity = new CustomerIsValidValidation();
                ValidationResult = entity.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}