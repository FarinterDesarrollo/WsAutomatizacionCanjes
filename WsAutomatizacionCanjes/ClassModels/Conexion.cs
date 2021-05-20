using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace WsAutomatizacionCanjes.ClassModels
{
    public class Conexion
    {
        public static string AutCanjes = ConfigurationManager.ConnectionStrings["AUTCANJES"].ConnectionString;

    }
}