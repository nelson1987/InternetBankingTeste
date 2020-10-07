namespace BGB.InternetBanking.Models
{
    public class Acquirer
    {
        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
    }
}