using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Entities.Specifications.CpfSpecs
{
    public class CpfIsValidSpec : ISpecification<Cpf>
    {
        public bool IsSatisfiedBy(Cpf cpf)
        {
            return IsValid(cpf.Number);
        }

        #region [ Private Methods ]

        private bool IsValid(long value)
        {
            if (value == 0)
                return false;

            var number = value.ToString();

            if (!SequentialIsValid(number))
                return false;

            var digit = value.ToString("D11").Substring(9, 2);
            number = value.ToString("D11").Substring(0, 9);

            var digitCalculated = CalculateDigit(number);
            return digit.Equals(digitCalculated);
        }

        private bool SequentialIsValid(string value)
        {
            if (value.Length < 9)
                return false;

            var isValid = false;

            for (int i = 0; i < value.Length - 1; i++)
            {
                if (!value[i].Equals(value[i + 1]))
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }

        private string CalculateDigit(string value)
        {
            var digit = 0;
            var calculatedDigit = string.Empty;
            var leftover = value.Length + 1;

            for (int i = leftover; i >= 2; i--)
                digit += i * int.Parse(value[leftover - i].ToString());

            digit = digit % 11;

            if (digit == 0 || digit == 1)
                calculatedDigit += "0";
            else
                calculatedDigit += (11 - digit).ToString();

            if (leftover == 10)
                calculatedDigit += CalculateDigit(value + calculatedDigit);

            return calculatedDigit;
        }

        #endregion [ Private Methods ]

    }
}