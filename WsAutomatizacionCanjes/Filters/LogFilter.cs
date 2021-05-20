using WsAutomatizacionCanjes.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WsAutomatizacionCanjes.Filters
{
    public class LogFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //gs = new GestorSql();
            base.OnActionExecuting(actionContext);
            LogWriter.Instance.Log("Ejecutado antes: " + System.DateTime.Now);

            //gs.LogAcceso(HttpContext.Current.Request.Url.Host, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff"), "Ejecución");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //gs = new GestorSql();
            base.OnActionExecuted(actionExecutedContext);
            LogWriter.Instance.Log("Termino en: " + System.DateTime.Now);
            //gs.LogAcceso(HttpContext.Current.Request.Url.Host, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff"), "Final de Ejecución");
        }
    }
}