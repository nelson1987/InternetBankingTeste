using System;
using BGB.InternetBanking.Api.Contracts.Enums;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class InvestmentMovementDto
    {
        public int Id { get; set; }
        public CheckingAccountDto CheckingAccount { get; set; }
        public int BequestId { get; set; }
        public DateTime MovementDate { get; set; }
        public DateTime EmissionDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public InvestmentMovementTypeEnumDto Type { get; set; }
        public string PaperCode { get; set; }
        public string PaperName { get; set; }
        public string Complement { get; set; }
        public decimal Ir { get; set; }
        public decimal Iof { get; set; }
        public decimal Amount { get; set; }
        public decimal LiquidAmount { get; set; }
    }
}