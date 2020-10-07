using System.Net;
using System.Collections.Generic;
using BGB.Core.Resources;

namespace BGB.Core.Models
{
    public class ReturnMessage
    {
        public bool Success { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public string Message { get; private set; }
        public IEnumerable<string> Erros { get; private set; }

        public ReturnMessage(bool success, string successMessage, IEnumerable<string> erros)
        {
            Success = success;
            Erros = erros;
            Message = success ? successMessage : BusinessMessage.ErroInTheIOperation;
            StatusCode = success ? HttpStatusCode.OK : (HttpStatusCode)422;
        }
    }
}