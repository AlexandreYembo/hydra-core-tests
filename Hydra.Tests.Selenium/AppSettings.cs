using System.IO;
using Microsoft.Extensions.Configuration;

namespace Hydra.Tests.Selenium
{
    public class AppSettings
    {
        private readonly IConfiguration _config;

        public AppSettings()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public string WebDrivers => $"{_config.GetSection("WebDrivers").Value}";
        public string FolderPath => Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        public string FolderPicture => $"{FolderPath}{_config.GetSection("FolderPicture").Value}";
        public bool Headless => bool.Parse(_config.GetSection("Headless").Value);
    }
}
