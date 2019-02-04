using Microsoft.Extensions.Configuration;

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
