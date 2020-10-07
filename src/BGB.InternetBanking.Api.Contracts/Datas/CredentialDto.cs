namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class CredentialDto
    {
        public string AccountNumber { get; set; }
        public string Login { get; set; }
        public string Key { get; set; }
        public bool TemporaryKey { get; set; }
    }
}