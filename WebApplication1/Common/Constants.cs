using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApplication1.Common
{
    public static class Constants
    {

        public static string ConnectionString = ConfigManager.AppSetting["ConnectionStrings:DefaultConnectionString"];
    }
    
}
