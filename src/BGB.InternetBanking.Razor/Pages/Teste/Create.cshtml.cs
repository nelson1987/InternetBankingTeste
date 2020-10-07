using BGB.InternetBanking.Api.Contracts.Datas;
using BGB.InternetBanking.Api.Contracts.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BGB.InternetBanking.Razor.Pages.Teste
{
    public class TesteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
    }
    public class Credenciadora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }

    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public List<TesteDto> Usuarios { get; private set; }
        public List<Credenciadora> Credenciadoras { get; private set; }
        public List<SelectListItem> CredenciadoraList { get; private set; }
        public List<SelectListItem> BandeiraList { get; private set; }

        #region [ Bind Properties ]

        [BindProperty]
        public int Credenciadora { get; set; }

        [BindProperty]
        public int Bandeira { get; set; }

        [BindProperty]
        public DateTime PeriodoInicial { get; set; }

        [BindProperty]
        public DateTime PeriodoFinal { get; set; }

        #endregion [ Bind Properties ]

        public IndexModel()
        {
            Usuarios = new List<TesteDto>();
            Credenciadoras = new List<Credenciadora>();
            GetCredenciadoraList();
            GetBandeiraList();
        }

        public void OnGet()
        {
            //Dados Form
            PeriodoInicial = DateTime.Today.AddMonths(-1);
            PeriodoFinal = DateTime.Today;

            //Dados Grid
            Usuarios.Add(new TesteDto { Id = 1, Data = DateTime.Parse("31/12/2018"), Nome = "Alfredo" });
        }

        public void OnPost()
        {
            Usuarios.Add(new TesteDto { Id = 1, Data = DateTime.Parse("31/12/2018"), Nome = "Alfredo" });
            Usuarios.Add(new TesteDto { Id = 2, Data = DateTime.Parse("30/12/2018"), Nome = "Bernardo" });

            Message = $"Pesquisa realizada com sucesso";
        }

        private void GetCredenciadoraList()
        {
            GetCredenciadoras();

            CredenciadoraList = Credenciadoras
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Nome
                })
                .ToList();
        }

        private void GetBandeiraList()
        {
            BandeiraList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "MasterCard", Value = "1" },
                new SelectListItem { Text = "Visa", Value = "2" }
            };
        }

        private void GetCredenciadoras()
        {
            Credenciadoras.Add(new Credenciadora() { Id = 1, Nome = "REDE", Codigo = "A" });
            Credenciadoras.Add(new Credenciadora() { Id = 2, Nome = "GETNET", Codigo = "G" });
        }
    }
}
