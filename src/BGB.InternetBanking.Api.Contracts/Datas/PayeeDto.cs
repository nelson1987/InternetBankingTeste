using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class PayeeDto
    {
        public string Name { get; set; }
        public CpfDto Cpf { get; set; }
        public string Passport { get; set; }
        public string EmitterCountry { get; set; }
        public bool Foreign { get; set; }
    }
}