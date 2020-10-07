using System;
using BGB.InternetBanking.Api.Contracts.Enums;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class DeedDto
    {
        public int Id { get; set; }
        public int Assignor { get; set; }
        public CheckingAccountDto CheckingAccount { get; set; }
        public string Number { get; set; }
        public long OurNumber { get; set; }
        public WalletEnumDto WalletType { get; set; }
        public string ReceiverNumber { get; set; }
        public string ReceiverDigit { get; set; }
        public int ReceiverWalletId { get; set; }
        public int ReceiverBank { get; set; }
        public int ReceiverAgency { get; set; }
        public CheckingAccountDto CheckingAccountReceiver { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public DateTime MaturityDateDayUtil { get; set; }
        public DateTime? DischargeDate { get; set; }
        public DateTime? LossDate { get; set; }
        public DeedTypeEnumDto Type { get; set; }
        public PayerDto Payer { get; set; }
        public GuarantorPayerDto GuarantorPayer { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal Mulct { get; set; }
        public decimal Interest { get; set; }
        public decimal PermanenceDay { get; set; }
        public decimal Liquidation { get; set; }
        public OperationDeedEnumDto OperationDeed { get; set; }
        public DeedStatusDto DeedStatus { get; set; }
        public string BilletMessage { get; set; }
    }
}