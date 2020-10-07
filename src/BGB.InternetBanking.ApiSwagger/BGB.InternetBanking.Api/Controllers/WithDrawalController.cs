using AutoMapper;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BGB.InternetBanking.Api.Controllers
{
    //[Authorize("Bearer")]
    [AllowAnonymous]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v1.0/[controller]")]
    public class WithDrawalController : Controller
    {
        #region [ Actions ]

        [HttpPost]
        [ProducesResponseType(200)] //OK
        [ProducesResponseType(400)] //Requisição inválida
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult Insert([FromBody] WithdrawalCommunication model,
                                    [FromServices] IWithdrawalService repository)
        {
            if (ModelState.IsValid) //verificar as validações
            {
                try
                {
                    WithdrawalCommunication p = Mapper.Map<WithdrawalCommunication>(model);
                    repository.Insert(p);

                    return Ok(); //200
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message); //500
                }
            }
            else
            {
                return BadRequest(); //400
            }
        }

        [HttpDelete]
        [ProducesResponseType(200)] //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult Cancel([FromBody]int withdrawalId,
                                    [FromServices] IWithdrawalService service)
        {
            try
            {
                service.Cancel(withdrawalId);

                return Ok(); //200
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message); //500
            }
        }

        #endregion [ Actions ]

        #region [ Queries ]

        [HttpGet("GetByAccount/{customerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WithdrawalCommunication>))] //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult GetByAccount(int customerId,
                                        [FromServices] IWithdrawalService service)
        {
            var withdrawals = service.GetByCustomer(customerId);

            return Ok(Mapper.Map<IEnumerable<WithdrawalCommunication>>(withdrawals));
        }

        #endregion [ Queries ]

    }
}