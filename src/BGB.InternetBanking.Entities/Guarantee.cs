namespace BGB.InternetBanking.Entities
{
    public class Guarantee
    {
        public virtual int Id { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; }
        public virtual CheckingAccount CheckingAccountGarantor { get; set; }
        public virtual string Contract { get; set; }
        public virtual decimal CardAmount { get; set; }
        public virtual decimal RequiredAmount { get; set; }
        public virtual decimal DuplicateAmount { get; set; }
        public virtual decimal CheckAmount { get; set; }
        public virtual decimal ExpiredAmount { get; set; }
    }
}