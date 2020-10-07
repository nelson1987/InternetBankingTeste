using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BGB.Core.Log.Interceptors
{
    public class FilterAuditAttribute : ActionFilterAttribute
    {
        private ILogUserActivityService _service;

        //injecting specified service to insert the log in database.
        public FilterAuditAttribute(ILogUserActivityService service)
        {
            _service = service;
        }

        #region [ Constants ]

        private const string KeyUserName = "user-name";

        #endregion [ Constants ]

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            //var userName = string.Empty;
            //IEnumerable<string> values;

            //if (actionContext.ControllerContext.Request.Headers.TryGetValues(KeyUserName, out values))
            //    userName = values.First();

            //var detail = ProcessDetail(actionContext.ActionArguments);
            //var serviceName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
            //var actionName = actionContext.ActionDescriptor.ActionName;

            var userName = "userteste";
            var serviceName = "serviceteste";
            var actionName = "actionteste";
            var detail = "detailteste";

            RegisterAccess(userName, serviceName, actionName, detail);
        }

        #region [ Private Methods ]

        //private string ProcessDetail(Dictionary<string, object> inputs)
        //{
        //    var parameters = new StringBuilder();

        //    foreach (var input in inputs)
        //    {
        //        if (input.Value == null)
        //            continue;

        //        var serializer = new DataContractJsonSerializer(input.Value.GetType());
        //        var ms = new MemoryStream();
        //        serializer.WriteObject(ms, input.Value);
        //        var retVal = Encoding.UTF8.GetString(ms.ToArray());
        //        ms.Dispose();

        //        if (parameters.Length > 0)
        //        {
        //            parameters.Append(",");
        //            parameters.Append(Environment.NewLine);
        //        }
        //        parameters.Append(retVal);
        //    }

        //    return parameters.ToString();
        //}

        private void RegisterAccess(string userName, string serviceName, string operationName, string detail)
        {
            var entity = new
            {
                OperationName = $"{serviceName}/{operationName}",
                Detail = detail,
                UserName = userName
            };

            //var body = JsonConvert.SerializeObject(entity);

            //Log4Net.GetLogger().LogIt(body, Log4NetLevelEnum.Info);
        }

        #endregion [ Private Methods ]

    }
}