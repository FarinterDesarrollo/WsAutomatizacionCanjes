using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WsAutomatizacionCanjes;
using SAP.Middleware.Connector;
using System.Web.SessionState;
using Microsoft.Ajax.Utilities;

namespace WsAutomatizacionCanjes
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //APERTURA CONECCION 
            //string destinationconfigname = "QA";
            string destinationconfigname = "PRD";
            bool resultado = false;
            Application["destinationconfigname"] = destinationconfigname;
            IDestinationConfiguration destinationConfiguration = null;
            bool destinationisInialised = false;
            if (!destinationisInialised)
            {
                destinationConfiguration = new ECCDestinationConfig();
                destinationConfiguration.GetParameters(destinationconfigname);

                if (RfcDestinationManager.TryGetDestination(destinationconfigname) == null)
                {
                    RfcDestinationManager.RegisterDestinationConfiguration(destinationConfiguration);
                    destinationisInialised = true;
                    resultado = false;
                    resultado = testconnection(destinationconfigname);
                    Application["resultado"] = Convert.ToString(resultado);
                }
            }
            //FIN APERTURA CONECCION
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                if (ex.GetBaseException() != null)
                {
                    ex = ex.GetBaseException();
                }

                if (HttpContext.Current.Session != null)  // Exception occurred here.
                {
                    Session["destinationconfigname"] = ex;
                    Session["resultado"] = ex;
                }

                throw new Exception("Error de coneccion " + ex.Message);
            }
        }

        private RfcDestination RfcDestination;
        public bool testconnection(string destinationname)
        {
            bool result = false;
            try
            {
                RfcDestination = RfcDestinationManager.GetDestination(destinationname);
                if (RfcDestination != null)
                {
                    RfcDestination.Ping();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
                throw new Exception("Error de coneccion " + ex.Message);
            }
            return result;

        }
    }
}
