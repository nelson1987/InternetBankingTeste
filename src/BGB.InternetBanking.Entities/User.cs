using BGB.Core.Validations;
using BGB.InternetBanking.Entities.Enums;
using BGB.InternetBanking.Entities.Validations;

namespace BGB.InternetBanking.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Credential Credential { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual ProfileEnum Profile { get; set; }
        public virtual bool Active { get; set; }

        public virtual ValidationResult ValidationResult { get; protected set; }

        public virtual bool IsValid
        {
            get
            {
                var entity = new UserIsValidValidation();
                ValidationResult = entity.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}