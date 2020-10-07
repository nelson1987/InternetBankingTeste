using BGB.InternetBanking.Api.Contracts.Enums;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class PayerDto
    {
        public long CpfCnpj { get; set; }
        public string Name { get; set; }
        public PersonTypeEnumDto PersonType { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public int? ZipCode { get; set; }
        public string State { get; set; }
    }
}