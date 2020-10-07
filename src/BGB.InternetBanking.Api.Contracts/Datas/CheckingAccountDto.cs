using BGB.InternetBanking.Api.Contracts.Enums;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class CheckingAccountDto
    {
        public int Number { get; set; }
        public int Digit { get; set; }
        public AccountTypeEnumDto Type { get; set; }
        //public string Formatted { get; set; }
        public string Formatted { get { return string.Format("{0}-{1}/{2}", Number, Digit, Type.ToString()); } }


        //x.Codigo +"/"+x. Tipo
    }
}