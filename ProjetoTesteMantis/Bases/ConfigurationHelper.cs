using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteMantis.Bases
{
    
        public static class ConfigurationHelper
        {
            private static IConfigurationRoot _config;

            static ConfigurationHelper()
            {
                _config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
            }

            public static string Get(string key)
            {
                return _config[key];
            }
        }
    
}
