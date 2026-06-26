using Microsoft.Extensions.Configuration;

namespace Core.Utils
{
    public static class ConfigurationExtensions
    {
        public static string GetMessageQueueConnection(this IConfiguration configuration, string name)
        {
            var section = configuration?.GetSection("MessageQueueConnection")?[name];
            return section;
        }
    }
}
