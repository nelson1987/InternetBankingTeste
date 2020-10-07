using AutoMapper;
using BGB.InternetBanking.Api.Contracts.Datas;
using BGB.InternetBanking.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BGB.InternetBanking.Api.Controllers
{
    [AllowAnonymous]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v1.0/[controller]")]
    public class InvestmentController : Controller
    {
        #region [ Queries ]

        [HttpGet("GetStatement")]
        [ProducesResponseType(200, Type = typeof(InvestmentStatementDto))] //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult GetStatement(int accountNumber, DateTime startDate, DateTime endDate,
                                        [FromServices] IInvestmentMovementService _movementService)
        {
            var statement = _movementService.GetStatement(accountNumber, startDate, endDate);

            return Ok(Mapper.Map<InvestmentStatementDto>(statement));
        }

        [HttpGet("GetPresumedIncome")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PresumedIncomeDto>))] //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        ///Extrato Presumido
        public IActionResult GetPresumedIncome(int accountNumber, DateTime startDate, DateTime endDate,
                                        [FromServices] IInvestmentMovementService _movementService)
        {
            var incomes = _movementService.GetPresumedIncome(accountNumber, startDate, endDate);

            return Ok(Mapper.Map<IEnumerable<PresumedIncomeDto>>(incomes));
        }

        #endregion [ Queries ]

    }
}