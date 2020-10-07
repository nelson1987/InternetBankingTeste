using BGB.InternetBanking.Api.Contracts.Enums;
using System.Collections.Generic;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long CpfCnpj { get; set; }
        public PersonTypeEnumDto PersonType { get; set; }
        public virtual CheckingAccountDto CheckingAccount { get; set; }
        public bool Active { get; set; }

        public IEnumerable<BindedAccountDto> BindedAccounts { get; set; }
    }
}