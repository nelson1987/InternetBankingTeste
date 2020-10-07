using BGB.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BGB.InternetBanking.Api.Infra
{
    public class BaseController : Controller
    {
        public IActionResult ReturnMessageAction(ReturnMessage returnMessage)
        {
            if (returnMessage.Success)
                return Ok(returnMessage.Message);
            else
                return new JsonResult(returnMessage.Erros) { StatusCode = (int)returnMessage.StatusCode };
        }
    }
}