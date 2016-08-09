using System.Configuration;

namespace @(Model.ApplicationData.Namespace).Service
{
    public class Config
    {
        public static string Get(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(value)) throw new ConfigurationException("Config file is misssing appSettings[" + key + "].");

            return value;
        }
    }
}
