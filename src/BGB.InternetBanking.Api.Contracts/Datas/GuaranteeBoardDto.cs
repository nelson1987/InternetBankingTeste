namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class GuaranteeBoardDto
    {
        public decimal Required { get; set; }
        public decimal Duplicate { get; set; }
        public decimal Check { get; set; }
        public decimal Card { get; set; }
        public decimal Expired { get; set; }
        public decimal Margin { get; set; }
        public CheckingAccountBalanceDto CheckingAccountBalance { get; set; }
        public CheckingAccountBalanceDto GuaranteedAccountBalance { get; set; }
    }
}