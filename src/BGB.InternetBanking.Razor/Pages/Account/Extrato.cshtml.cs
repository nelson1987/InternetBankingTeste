using BGB.Core.Proxy;
using BGB.InternetBanking.Api.Contracts.Datas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BGB.InternetBanking.Razor.Pages.Account
{
    public class TesteDTO
    {
        [DataType(DataType.Date)]
        public DateTime PeriodoInicial { get; set; }
        //public DateTime PeriodoInicialStr { get { return DateTime.Parse(PeriodoInicial); } }

        [DataType(DataType.Date)]
        public DateTime PeriodoFinal { get; set; }
        //public DateTime PeriodoFinalStr { get { return DateTime.Parse(PeriodoFinal); } }

        public int AccountId { get; set; }

        public List<SelectListItem> AccountList { get; set; }
    }
    public class ExtratoModel : PageModelDefault
    {
        [BindProperty]
        public IList<CheckingAccountMovementDto> Movements { get; private set; }

        [BindProperty]
        public TesteDTO Filtro { get; set; }

        public IList<CheckingAccountDto> Accounts { get; private set; }

        public void OnGet()
        {
            Movements = new List<CheckingAccountMovementDto>() {
                new CheckingAccountMovementDto{ Id= 30, MovementDate = DateTime.Parse("31/12/2018"), Document = "TARIFA DOC/TED PESSOAL DEBITO TAXA TRANSFERENCIA", Amount  = -2000000000.0M },
                new CheckingAccountMovementDto{ Id= 30, MovementDate = DateTime.Parse("31/12/2018"), Document = "SALDO DIÁRIO", Amount  = 2000000000.0M },
            };
            Filtro = new TesteDTO()
            {
                PeriodoInicial = DateTime.Parse("31/12/2018"),
                PeriodoFinal = DateTime.Parse("31/12/2019"),
                AccountId = 0,
                AccountList = LoadAccounts()
                                .Select(x => new SelectListItem
                                {
                                    Text = x.Formatted,
                                    Value = x.Number.ToString()
                                })
                                .ToList()
            };
        }

        private List<CheckingAccountDto> LoadAccounts()
        {
            Accounts = new List<CheckingAccountDto>();
            var accountNumber = 3444;
            var baseUri = "localhost:5000";
            var uri = $"api/v1.0/Guarantee/GetByAccount/{accountNumber}";

            try
            {
                Accounts = new ApiServiceInvoker().GetAsyncService<List<CheckingAccountDto>>(baseUri, uri);
            }
            catch (Exception ex)
            {
                Message = $"{ex.Message}";
            }

            return new List<CheckingAccountDto>() {
                new CheckingAccountDto{ Type  = Api.Contracts.Enums.AccountTypeEnumDto.Normal, Number = 123, Digit = 1 }
            };
        }

        public JsonResult OnGetAccountList()
        {
            List<string> lstString = new List<string>
            {
                "Val 1",
                "Val 2",
                "Val 3"
            };
            return new JsonResult(lstString);
        }

        public JsonResult OnPostSend([FromBody]TesteDTO obj)
        {
            return new JsonResult(new List<CheckingAccountMovementDto>() {
                new CheckingAccountMovementDto{ Id= 30, MovementDate = DateTime.Parse("31/12/2018"), Document = "TARIFA DOC/TED PESSOAL DEBITO TAXA TRANSFERENCIA", Amount  = -2000000000.0M },
                new CheckingAccountMovementDto{ Id= 30, MovementDate = DateTime.Parse("31/12/2018"), Document = "SALDO DIÁRIO", Amount  = 2000000000.0M },
                new CheckingAccountMovementDto{ Id= 30, MovementDate = DateTime.Parse("30/12/2018"), Document = "SALDO DIÁRIO", Amount  = 1000000000.0M },
                new CheckingAccountMovementDto{ Id= 30, MovementDate = DateTime.Parse("29/12/2018"), Document = "SALDO DIÁRIO", Amount  = 2000000000.0M },
            });
        }
    }
}
