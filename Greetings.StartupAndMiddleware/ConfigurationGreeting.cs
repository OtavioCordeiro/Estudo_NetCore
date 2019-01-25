using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greetings
{
    public class ConfigurationGreeting : IGreeting
    {
        IConfiguration _configuration;

        public ConfigurationGreeting(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetMessageOfDay()
        {
            return _configuration["Greetings"];
        }
    }
}
