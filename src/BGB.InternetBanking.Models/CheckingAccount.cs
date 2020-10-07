using BGB.InternetBanking.Models.Enums;

namespace BGB.InternetBanking.Models
{
    public class CheckingAccount
    {

        #region [ Constructor ]

        public CheckingAccount() { }
        public CheckingAccount(int number, int digit)
        {
            Number = number;
            Digit = digit;
        }

        #endregion [ Constructor ]

        #region [ Properties ] 
        
        public virtual int Number { get; set; }
        public virtual int Digit { get; set; }

        public AccountTypeEnum Type
        {
            get
            {
                if (Number <= 9999)
                    return AccountTypeEnum.Normal;
                else if (Number > 9999 && Number <= 40000)
                    return AccountTypeEnum.Binded;
                else
                    return AccountTypeEnum.Others;
            }
        }

        public string Formatted
        {
            get
            {
                return $"{Number.ToString("D5")}-{Digit}";
            }
        }
        
        #endregion [ Properties ] 

        public bool Equals(CheckingAccount other)
        {
            return Number.Equals(other.Number) && Digit.Equals(other.Digit);
        }
    }
}