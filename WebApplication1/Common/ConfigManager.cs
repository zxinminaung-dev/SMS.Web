using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApplication1.Common
{
    public class ConfigManager
    {
        public static IConfiguration AppSetting { get; }
        static ConfigManager()
        {

            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }
    }
}
