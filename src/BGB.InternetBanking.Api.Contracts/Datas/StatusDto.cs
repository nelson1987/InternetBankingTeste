namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class StatusDto
    {
        public int Id { get; set; }
        public TypeStatusDto TypeStatus { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}