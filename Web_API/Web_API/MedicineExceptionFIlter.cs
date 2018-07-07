using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Web_API
{
    public class MedicineExceptionFIlter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is DivideByZeroException)
            {
                context.Response = new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);
            }
        }
    }
}