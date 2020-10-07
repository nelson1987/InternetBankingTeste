using System.Collections.Generic;
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
    ///Transferência de Recurso
    public class WithdrawalController : BaseController
    {

        #region [ Attributes ]

        private readonly IWithdrawalService _withdrawalService;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public WithdrawalController(IWithdrawalService withdrawalService)
        {
            _withdrawalService = withdrawalService;
        }

        #endregion [ Constructor ]

        #region [ Actions ]

        [HttpPost]
        //[FilterAudit]
        public IActionResult Insert([FromBody] WithdrawalCommunication withdrawal)
        {
            var returnMessage = _withdrawalService.Insert(withdrawal);

            return ReturnMessageAction(returnMessage);
        }

        [HttpPost]
        //[FilterAudit]
        public IActionResult Cancel([FromBody]int withdrawalId)
        {
            var returnMessage = _withdrawalService.Cancel(withdrawalId);

            return ReturnMessageAction(returnMessage);
        }

        #endregion [ Actions ]

        #region [ Queries ]

        [HttpGet]
        public IActionResult GetByAccount(int customerId)
        {
            var withdrawals = _withdrawalService.GetByCustomer(customerId);

            return Ok(Mapper.Map< IEnumerable<WithdrawalCommunicationDto>>(withdrawals));
        }

        #endregion [ Queries ]

    }
}