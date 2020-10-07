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
    public class ViewsModel : PageModel
    {
        public const string BaseUri = "localhost:8091";

        public string Message { get; set; }

        [BindProperty]
        public int Account { get; set; }
    }

    public class IndexModel : ViewsModel
    {
        //public const string baseUri = "localhost:8091";
        public IndexModel()
        {
            Account = 3444;
            Accounts = new List<CheckingAccountDto>();
        }

        [BindProperty]
        public List<CheckingAccountDto> Accounts { get; set; }

        public List<SelectListItem> AccountList { get; private set; }

        [BindProperty]
        public GuaranteeBoardDto Guarantee { get; set; }

        [BindProperty]
        public IEnumerable<CheckingAccountMovementDto> Movements { get; set; }

        [BindProperty]
        public CheckingAccountBalanceDto Balance { get; set; }

        public void OnGet()
        {
            LoadAccounts();
            LoadMovements();
            LoadBalance();
            LoadGuarantees();
            GetCredenciadoraList();
        }

        protected string GetToken()
        {
            string token = Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(token))
            {
                token = Request.Form["hidAuthorization"];

                if (string.IsNullOrEmpty(token))
                    return string.Empty;
            }

            return token.Replace("Bearer ", string.Empty);
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
            UserDto usuario = new UserDto();
            //http://localhost:8091/api/v1.0/User/Get/1
            var accountNumber = 1;
            var uri = $"api/v1.0/User/Get/{accountNumber}";

            try
            {
                usuario = new ApiServiceInvoker().GetAsyncService<UserDto>(BaseUri, uri);

                Accounts.Add(usuario.Customer.CheckingAccount);
                //guarantee = new ApiServiceInvoker().GetAsyncService<CustomerDto>(BaseUri, uri);
            }
            catch (Exception ex)
            {
                Message = $"{ex.Message}";
            }
        }

        private void LoadGuarantees()
        {
            Guarantee = new GuaranteeBoardDto();

            var uri = $"api/v1.0/Guarantee/GetByAccount/{Account}";

            try
            {
                Guarantee = new ApiServiceInvoker().GetAsyncService<GuaranteeBoardDto>(BaseUri, uri);
            }
            catch (Exception ex)
            {
                Message = $"{ex.Message}";
            }
        }

        private void LoadMovements()
        {
            var uri = $"api/v1.0/CheckingAccount/GetMovementLast?accountNumber={Account}&quantity=7";

            try
            {
                Movements = new ApiServiceInvoker().GetAsyncService<IEnumerable<CheckingAccountMovementDto>>(BaseUri, uri);
            }
            catch (Exception ex)
            {
                Message = $"{ex.Message}";
            }
        }

        private void LoadBalance()
        {
            var uri = $"api/v1.0/CheckingAccount/GetCurrentBalance?accountNumber={Account}";

            try
            {
                Balance = new ApiServiceInvoker().GetAsyncService<CheckingAccountBalanceDto>(BaseUri, uri);
            }
            catch (Exception ex)
            {
                Message = $"{ex.Message}";
            }
        }
    }
}
