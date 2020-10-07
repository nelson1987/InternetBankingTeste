using AutoMapper;
using BGB.InternetBanking.Api.Contracts.Datas;
using BGB.InternetBanking.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BGB.InternetBanking.Api.Controllers
{
    /// <summary>
    /// Cliente
    /// </summary>
    [AllowAnonymous]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v1.0/[controller]")]
    public class CustomerController : Controller
    {
        #region [ Queries ]

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(CustomerDto))] //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult Get(int id, [FromServices] ICustomerService _customerService)
        {
            var customer = _customerService.Get(id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<CustomerDto>(customer));
        }

        #endregion [ Queries ]

    }
}