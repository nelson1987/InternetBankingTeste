using BGB.Core.Proxy;
using BGB.InternetBanking.Api.Contracts.Datas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace BGB.InternetBanking.Razor.Pages.Deed
{
    public class FrancesinhaModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        public IEnumerable<CheckingAccountDto> Accounts { get; set; }

        [BindProperty]
        public GuaranteeBoardDto Guarantee { get; set; }

        [BindProperty]
        public IEnumerable<CheckingAccountMovementDto> Movements { get; set; }

        [BindProperty]
        public CheckingAccountBalanceDto Balance { get; set; }

        public FrancesinhaModel()
        {
            Movements = new List<CheckingAccountMovementDto>();
        }

        public void OnGet()
        {
            Movements = new List<CheckingAccountMovementDto>() {
                new CheckingAccountMovementDto{ Id= 30, MovementDate = DateTime.Parse("08/04/2018"), Document = "TARIFA DOC/TED PESSOAL DEBITO TAXA TRANSFERENCIA", Amount  = -20.0M },
                new CheckingAccountMovementDto{ Id= 30, MovementDate = DateTime.Parse("08/04/2018"), Document = "SALDO DIÁRIO", Amount  = -20.0M },
            };


            //LoadAccounts();
            //LoadMovements();
            //LoadBalance();
            //LoadGuarantees();
        }

        private void LoadAccounts()
        {
            Accounts = new List<CheckingAccountDto>();
            //var accountNumber = 3444;
            //var baseUri = "localhost:5000";
            //var uri = $"api/v1.0/Guarantee/GetByAccount?accountNumber={accountNumber}";

            //try
            //{
            //    Accounts = new ApiServiceInvoker().GetAsyncService<GuaranteeBoardDto>(baseUri, uri);
            //}
            //catch (Exception ex)
            //{
            //    Message = $"{ex.Message}";
            //}
        }
        private void LoadGuarantees()
        {
            Guarantee = new GuaranteeBoardDto();

            var accountNumber = 3444;
            var baseUri = "localhost:5000";
            var uri = $"api/v1.0/Guarantee/GetByAccount?accountNumber={accountNumber}";

            try
            {
                Guarantee = new ApiServiceInvoker().GetAsyncService<GuaranteeBoardDto>(baseUri, uri);
            }
            catch (Exception ex)
            {
                Message = $"{ex.Message}";
            }
        }

        private void LoadMovements()
        {
            var accountNumber = 3444;
            var quantity = 7;

            var baseUri = "localhost:5000";
            var uri = $"api/v1.0/CheckingAccount/GetMovementLast?accountNumber={accountNumber}&quantity={quantity}";

            try
            {
                Movements = new ApiServiceInvoker().GetAsyncService<IEnumerable<CheckingAccountMovementDto>>(baseUri, uri);
            }
            catch (Exception ex)
            {
                Message = $"{ex.Message}";
            }
        }

        private void LoadBalance()
        {
            var accountNumber = 3444;

            var baseUri = "localhost:5000";
            var uri = $"api/v1.0/CheckingAccount/GetCurrentBalance?accountNumber={accountNumber}";

            try
            {
                Balance = new ApiServiceInvoker().GetAsyncService<CheckingAccountBalanceDto>(baseUri, uri);
            }
            catch (Exception ex)
            {
                Message = $"{ex.Message}";
            }
        }
    }
}
