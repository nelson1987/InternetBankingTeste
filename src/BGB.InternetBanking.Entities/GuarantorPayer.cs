namespace BGB.InternetBanking.Entities
{
    public class GuarantorPayer
    {
        public virtual long CpfCnpj { get; set; }
        public virtual string Name { get; set; }

        public virtual bool Equals(GuarantorPayer other)
        {
            return other.CpfCnpj.Equals(CpfCnpj) && other.Name.Equals(Name);
        }
    }
}