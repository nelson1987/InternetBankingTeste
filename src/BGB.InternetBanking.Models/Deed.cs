using System;
using BGB.InternetBanking.Models.Enums;

namespace BGB.InternetBanking.Models
{
    public class Deed
    {
        public virtual int Id { get; set; }
        public virtual int Assignor { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; }
        public virtual string Number { get; set; }
        public virtual long OurNumber { get; set; }
        public virtual WalletEnum WalletType { get; set; }
        public virtual string ReceiverNumber { get; set; }
        public virtual string ReceiverDigit { get; set; }
        public virtual int ReceiverWalletId { get; set; }
        public virtual int ReceiverBank { get; set; }
        public virtual int ReceiverAgency { get; set; }
        public virtual CheckingAccount CheckingAccountReceiver { get; set; }
        public virtual DateTime EntryDate { get; set; }
        public virtual DateTime MaturityDate { get; set; }
        public virtual DateTime MaturityDateDayUtil { get; set; }
        public virtual DateTime? DischargeDate { get; set; }
        public virtual DateTime? LossDate { get; set; }
        public virtual DeedTypeEnum Type { get; set; }
        public virtual Payer Payer { get; set; }
        public virtual GuarantorPayer GuarantorPayer { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual decimal Mulct { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual decimal PermanenceDay { get; set; }
        public virtual decimal Liquidation { get; set; }
        public virtual OperationDeedEnum OperationDeed { get; set; }
        public virtual DeedStatus DeedStatus { get; set; }
        public virtual Instruction Instruction { get; set; }
        public virtual int? DayProtest { get; set; }
        public virtual string BilletMessage
        {
            get
            {
                var message = string.Empty;

                if (Instruction != null)
                {
                    var propertie = Instruction.BilletPhrase.Substring(Instruction.BilletPhrase.IndexOf("{") + 1, 
                                        Instruction.BilletPhrase.LastIndexOf("}") - Instruction.BilletPhrase.IndexOf("{") - 1);

                    var prop = this.GetType().GetProperty(propertie);

                    if (prop == null)
                        return message;

                    var value = prop.GetValue(this);

                    if (value == null)
                        return message;

                    message = Instruction.BilletPhrase.Replace("{" + propertie + "}", value.ToString());
                }

                return message;
            }
        }
    }
}