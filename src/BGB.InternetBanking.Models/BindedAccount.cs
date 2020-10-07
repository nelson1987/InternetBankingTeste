namespace BGB.InternetBanking.Models
{
    public class BindedAccount
    {
        public virtual int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; }
        public virtual bool Active { get; set; }
    }
}