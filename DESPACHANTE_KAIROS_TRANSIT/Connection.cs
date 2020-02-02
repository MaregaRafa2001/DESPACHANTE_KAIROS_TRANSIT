using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace APP_UI
{
    public class Connection
    {
        public string Get_Connection()
        {
            return ConfigurationSettings.AppSettings["cn"].ToString();
        }
    }
}
