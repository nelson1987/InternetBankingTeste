using BGB.InternetBanking.Entities.Enums;

namespace BGB.InternetBanking.Entities
{
    public class Payer
    {
        public virtual long CpfCnpj { get; set; }
        public virtual string Name { get; set; }
        public virtual PersonTypeEnum PersonType { get; set; }
        public virtual string Address { get; set; }
        public virtual string District { get; set; }
        public virtual string City { get; set; }
        public virtual int? ZipCode { get; set; }
        public virtual string State { get; set; }

        public virtual bool Equals(Payer other)
        {
            return other.CpfCnpj.Equals(CpfCnpj) && other.Name.Equals(Name);
        }
    }
}