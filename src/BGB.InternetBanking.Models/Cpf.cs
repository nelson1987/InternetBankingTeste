using BGB.Core.Validations;
using BGB.InternetBanking.Models.Validations;
using System.Text.RegularExpressions;

namespace BGB.InternetBanking.Models
{
    public class Cpf
    {

        #region [ Properties ]

        public virtual long Number { get; set; }
        public virtual long Control
        {
            get
            {
                if (!IsValid)
                    return 0;

                var number = Number.ToString();
                return long.Parse(number.Substring(0, number.Length-2));
            }
        }

        public virtual int Digit
        {
            get
            {
                if (!IsValid)
                    return 0;

                var number = Number.ToString();
                return int.Parse(number.Substring(number.Length - 2, 2));
            }
        }

        public virtual string FormatedNumber
        {
            get
            {
                return Number.ToString(@"000\.000\.000\-00");
            }
        }

        #endregion [ Properties ]

        public virtual ValidationResult ValidationResult { get; protected set; }

        public virtual bool IsValid
        {
            get
            {
                var entity = new CpfIsValidValidation();
                ValidationResult = entity.Valid(this);

                return ValidationResult.IsValid;
            }
        }

    }
}