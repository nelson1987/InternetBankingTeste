using BGB.Core.Proxy;
using BGB.InternetBanking.Api.Contracts.Datas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace BGB.InternetBanking.Razor.Pages.Account
{
    public class ComunicacaoModel : PageModelDefault
    {
        public List<WithdrawalCommunicationDto> ComunicacaoList { get; set; }
        public ComunicacaoModel()
        {
            ComunicacaoList = new List<WithdrawalCommunicationDto>();
        }

        public void OnGet()
        {
            ComunicacaoList.Add(new WithdrawalCommunicationDto() { Id = 1, Amount = 1000000.00M, Payee = new PayeeDto() { Foreign = true, EmitterCountry = "US", Name = "BOB", Passport = "123US234P" } });
        }
    }
}
