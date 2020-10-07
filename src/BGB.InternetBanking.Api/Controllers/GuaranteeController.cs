using System.Linq;
using AutoMapper;
using BGB.InternetBanking.Api.Contracts.Datas;
using BGB.InternetBanking.Api.Infra;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BGB.InternetBanking.Api.Controllers
{
    //[Authorize("Bearer")]
    [ApiVersion("1.0")]
    public class GuaranteeController : BaseController
    {

        #region [ Attributes ]

        private readonly IGuaranteeService _guaranteeService;
        private readonly IAccountBalanceService _accountBalanceService;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public GuaranteeController(IGuaranteeService guaranteeService, IAccountBalanceService accountBalanceService)
        {
            _guaranteeService = guaranteeService;
            _accountBalanceService = accountBalanceService;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        [HttpGet]
        public IActionResult GetByAccount(int accountNumber)
        {
            var guarantees = _guaranteeService.GetByAccount(accountNumber);

            if (guarantees == null || guarantees.Count() == 0)
                return Ok(new GuaranteeBoardDto());

            var accounts = guarantees.Select(x => x.CheckingAccount);
            accounts.ToList().AddRange(guarantees.Select(x => x.CheckingAccountGarantor));

            var accountsNumber = accounts.GroupBy(x => x.Number).Select(x => x.Key);
            var accountsNumberGuaranteed = accountsNumber.Select(x => x + 30000);

            var balances = _accountBalanceService.GetCurrent(accountsNumber);
            var balancesGuarantee = _accountBalanceService.GetCurrent(accountsNumberGuaranteed); ;

            var guarantee = new GuaranteeBoard(guarantees, balances, balancesGuarantee);

            return Ok(Mapper.Map<GuaranteeBoardDto>(guarantee));
        }

        #endregion [ Queries ]

    }
}