using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGB.InternetBanking.Api.Entities
{
    public class WithDrawalCommunication
    {
        public virtual int Id { get; set; }
        //public virtual Customer Customer { get; set; }
        //public virtual Status Status { get; set; }
        public virtual string Protocol { get; set; }
        public virtual string CoafProtocol { get; set; }
        public virtual DateTime CommunicationDate { get; set; }
        public virtual DateTime CommunicationDateValid { get; set; }
        public virtual DateTime ExpectedDate { get; set; }
        public virtual DateTime? EffectiveDate { get; set; }
        public virtual string Finality { get; set; }
        public virtual decimal Amount { get; set; }
        //public virtual Payee Payee { get; set; }
        public virtual DateTime ExpectedDateValid { get; set; }
        public virtual decimal MinimumAmount { get; set; }
        public virtual int DaysInAdvance { get; set; }

        //public virtual ValidationResult ValidationResult { get; protected set; }

        public virtual bool IsValid
        {
            get
            {
                //var entity = new WithdrawalIsValidValidation();

                //ValidationResult = entity.Valid(this);

                //if (Payee != null && !Payee.IsValid)
                //    ValidationResult.Add(Payee.ValidationResult);

                //return ValidationResult.IsValid;
                return true;
            }
        }
    }
}