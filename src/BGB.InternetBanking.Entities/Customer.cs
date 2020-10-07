using BGB.Core.Validations;
using BGB.InternetBanking.Entities.Enums;
using BGB.InternetBanking.Entities.Validations;
using System.Collections.Generic;

namespace BGB.InternetBanking.Entities
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