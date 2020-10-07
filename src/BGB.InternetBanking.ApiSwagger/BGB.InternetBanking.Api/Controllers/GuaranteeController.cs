using AutoMapper;
using BGB.InternetBanking.Api.Contracts.Datas;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BGB.InternetBanking.Api.Controllers
{
    [AllowAnonymous]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v1.0/[controller]")]
    public class GuaranteeController : Controller
    {
        #region [ Queries ]

        [HttpGet("GetByAccount/{accountNumber}")]
        [ProducesResponseType(200, Type = typeof(GuaranteeBoardDto))] //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult GetByAccount(int accountNumber,
                                        [FromServices] IGuaranteeService _guaranteeService,
                                        [FromServices] IAccountBalanceService _accountBalanceService)
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