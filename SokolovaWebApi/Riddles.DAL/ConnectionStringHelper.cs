using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace Riddles.DAL
{
    public static class ConnectionStringHelper
    {
        public static string GetConnectionStringByName(ConnectionType stringType)
        {
            return ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).ConnectionStrings.ConnectionStrings[stringType.ToString()].ConnectionString;
        }
    }
}
