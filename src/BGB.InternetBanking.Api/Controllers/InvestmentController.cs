using System;
using System.Collections.Generic;
using AutoMapper;
using BGB.InternetBanking.Api.Contracts.Datas;
using BGB.InternetBanking.Api.Infra;
using BGB.InternetBanking.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BGB.InternetBanking.Api.Controllers
{
    //[Authorize("Bearer")]
    [ApiVersion("1.0")]
    public class InvestmentController : BaseController
    {

        #region [ Attributes ]

        private readonly IInvestmentBalanceService _balanceService;
        private readonly IInvestmentMovementService _movementService;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public InvestmentController(IInvestmentBalanceService balanceService, IInvestmentMovementService movementService)
        {
            _balanceService = balanceService;
            _movementService = movementService;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        [HttpGet]
        public IActionResult GetStatement(int accountNumber, DateTime startDate, DateTime endDate)
        {
            var statement = _movementService.GetStatement(accountNumber, startDate, endDate);

            return Ok(Mapper.Map<InvestmentStatementDto>(statement));
        }

        [HttpGet]
        ///Extrato Presumido
        public IActionResult GetPresumedIncome(int accountNumber, DateTime startDate, DateTime endDate)
        {
            var incomes = _movementService.GetPresumedIncome(accountNumber, startDate, endDate);

            return Ok(Mapper.Map<IEnumerable<PresumedIncomeDto>>(incomes));
        }

        #endregion [ Queries ]

    }
}