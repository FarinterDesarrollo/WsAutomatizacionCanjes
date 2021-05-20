using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WsAutomatizacionCanjes.Tool
{
    public class LogWriter : IlogWriter
    {
        private static readonly Lazy<LogWriter> instance = new Lazy<LogWriter>(() => new LogWriter());
        private LogWriter() { }
        public static LogWriter Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public void Log(string message)
        {
            Debug.WriteLine(message);
        }

    }
}