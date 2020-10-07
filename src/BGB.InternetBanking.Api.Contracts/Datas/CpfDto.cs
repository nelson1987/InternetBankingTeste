namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class CpfDto
    {
        public long Number { get; set; }
        public long Control { get; set; }
        public int Digit { get; set; }
        public string FormatedNumber { get; set; }
    }
}