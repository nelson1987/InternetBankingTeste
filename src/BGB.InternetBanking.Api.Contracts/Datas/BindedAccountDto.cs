namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class BindedAccountDto
    {
        public int Id { get; set; }
        public CheckingAccountDto CheckingAccount { get; set; }
        public bool Active { get; set; }
    }
}