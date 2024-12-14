using System.IO;
using System.Text.Json;

namespace TestProject.Setup
{
    public class Config
    {
        public string BaseUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class ConfigReader
    {
        public static Config GetConfig()
        {
            string json = File.ReadAllText("Config/appsettings.json");
            return JsonSerializer.Deserialize<Config>(json);
        }
    }
}
