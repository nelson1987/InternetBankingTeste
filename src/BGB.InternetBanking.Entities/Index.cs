namespace BGB.InternetBanking.Entities
{
    public class Index
    {
        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Active { get; set; }
    }
}