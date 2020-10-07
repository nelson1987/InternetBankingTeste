namespace BGB.InternetBanking.Entities
{
    public class Instruction
    {
        public virtual int Id { get; set; }
        public virtual int? Number { get; set; }
        public virtual int? Bank { get; set; }
        public virtual string BilletPhrase { get; set; }
    }
}