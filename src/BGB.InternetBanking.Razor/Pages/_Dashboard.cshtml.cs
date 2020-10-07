using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BGB.Core.Proxy;
using BGB.InternetBanking.Api.Contracts.Datas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BGB.InternetBanking.Razor.Pages
{
    public class _DashboardModel : PageModel
    {
        [BindProperty]
        public GuaranteeBoardDto Guarantee { get; set; }


        public void OnGet()
        {
            LoadGuarantees();
        }

        private void LoadGuarantees()
        {
            Guarantee = new GuaranteeBoardDto();

            var accountNumber = 3444;
            var baseUri = "localhost:50001";
            var uri = $"api/v1.0/Guarantee/GetByAccount?accountNumber={accountNumber}";

            try
            {
                Guarantee = new ApiServiceInvoker().GetAsyncService<GuaranteeBoardDto>(baseUri, uri);
            }
            catch (Exception ex)
            {
                //Message = $"{ex.Message}";
            }
        }
    }
}