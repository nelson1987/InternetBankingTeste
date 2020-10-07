namespace BGB.InternetBanking.Entities
{
    public class Parameter
    {
        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual string Value { get; set; }
    }
}