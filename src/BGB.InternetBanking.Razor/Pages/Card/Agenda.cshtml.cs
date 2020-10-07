using BGB.InternetBanking.Api.Contracts.Datas;
using BGB.InternetBanking.Api.Contracts.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace BGB.InternetBanking.Razor.Pages.Card
{
    public class AgendaModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        public string Credemciadora { get; set; }

        [BindProperty]
        public string Bandeira { get; set; }

        [BindProperty]
        public GuaranteeBoardDto Guarantee { get; set; }

        [BindProperty]
        public IEnumerable<CardMovementDto> Movements { get; set; }

        [BindProperty]
        public CheckingAccountBalanceDto Balance { get; set; }

        [BindProperty]
        public List<SelectListItem> ListagemCredenciadora { get; set; }

        [BindProperty]
        public List<SelectListItem> ListagemBandeira { get; set; }

        public AgendaModel()
        {
            Movements = new List<CardMovementDto>();
            ListagemCredenciadora = new List<SelectListItem>();
            ListagemBandeira = new List<SelectListItem>();
        }

        public void OnGet()
        {
            Movements = new List<CardMovementDto>() { new CardMovementDto { Id = 30, SalePoint = "000030455A", Type = CardMovementEnumDto.Credit, Amount = 100000.00M, Acquirer = new AcquirerDto { Description = "Mastercard" }, LiquidationDate = DateTime.Parse("19/02/2018"), Establishment = new EstablishmentDto { Name = "Cielo" } } };

            ListagemCredenciadora.Add(new SelectListItem { Text = "Cielo", Value = "C" });
            ListagemCredenciadora.Add(new SelectListItem { Text = "GetNet", Value = "G" });
        }
    }
}
