namespace GEM.Server.Service
{
    public class PayPalConfigManager
    {
        private readonly Dictionary<string, string> _config;

        public PayPalConfigManager(Dictionary<string, string> config)
        {
            _config = config;
        }

        public string GetClientId()
        {
            return _config["clientId"];
        }

        public string GetClientSecret()
        {
            return _config["clientSecret"];
        }

        public string GetMode()
        {
            return _config["mode"];
        }
    }
}
