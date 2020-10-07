namespace BGB.InternetBanking.Models
{
    public class Status
    {
        public virtual int Id { get; set; }
        public virtual TypeStatus TypeStatus { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
    }
}