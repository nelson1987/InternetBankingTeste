using BGB.Core.Proxy;
using BGB.InternetBanking.Api.Contracts.Datas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BGB.InternetBanking.Razor.Pages
{
    public class _AccountSummaryModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        public int Account { get; set; }

        [BindProperty]
        public IEnumerable<CheckingAccountDto> Accounts { get; set; }

        public List<SelectListItem> AccountList { get; private set; }

        [BindProperty]
        public GuaranteeBoardDto Guarantee { get; set; }

        [BindProperty]
        public IEnumerable<CheckingAccountMovementDto> Movements { get; set; }

        [BindProperty]
        public CheckingAccountBalanceDto Balance { get; set; }

        public void OnGetAsync()
        {
            LoadAccounts();
            LoadMovements();
            LoadBalance();
            LoadGuarantees();
            GetCredenciadoraList();
        }

        public void OnPost()
        {
        }

        private void GetCredenciadoraList()
        {
            AccountList = Accounts
                .Select(x => new SelectListItem
                {
                    Value = x.Number.ToString(),
                    Text = x.Formatted
                })
                .ToList();
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
