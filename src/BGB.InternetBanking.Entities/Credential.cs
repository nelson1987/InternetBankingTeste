using BGB.Core.Validations;
using BGB.InternetBanking.Entities.Validations;

namespace BGB.InternetBanking.Entities
{
    public class Credential
    {
        public virtual string Login { get; set; }
        public virtual string Key { get; set; }
        public virtual bool TemporaryKey { get; set; }

        public bool Equals(Credential other)
        {
            return Login.Equals(other.Login) && Key.Equals(other.Key);
        }

        public virtual ValidationResult ValidationResult { get; protected set; }

        public virtual bool IsValid
        {
            get
            {
                var entity = new CredentialIsValidValidation();
                ValidationResult = entity.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}