using BGB.Core.Validations;
using BGB.InternetBanking.Entities.Validations;

namespace BGB.InternetBanking.Entities
{
    public class Payee
    {
        public virtual string Name { get; set; }
        public virtual Cpf Cpf { get; set; }
        public virtual string Passport { get; set; }
        public virtual string EmitterCountry { get; set; }
        public virtual bool Foreign { get; set; }

        public virtual ValidationResult ValidationResult { get; protected set; }

        public virtual bool IsValid
        {
            get
            {
                var entity = new PayeeIsValidValidation();
                ValidationResult = entity.Valid(this);

                if (!Cpf.IsValid)
                    ValidationResult.Add(Cpf.ValidationResult);

                return ValidationResult.IsValid;
            }
        }
    }
}