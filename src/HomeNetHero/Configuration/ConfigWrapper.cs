using Nett;

namespace HomeNetHeroApp
{
    public class ConfigWrapper : IConfigWrapper
    {
        // TODO: Add logging to this part of the application.

        private string _configPath;
        private Config _config;

        public Config Config { get; }

        public bool LoadConfiguration(string configPath)
        {
            if (string.IsNullOrWhiteSpace(configPath))
            {
                return false;
            }

            _configPath = configPath;

            // If the file exists, read it
            if (File.Exists(_configPath))
            {
                _config = Toml.ReadFile<Config>(_configPath);
                return true;
            }
            else
            {
                // If the file doesn't exist, create a new one with some default values
                _config = new Config
                {
                    // "https://discord.com/api/webhooks/1124303603818041424/v9ulPUvteGxSCWS46lyK6G5U4xOoFLX6685eXla0XDe3e_zJmkDexyzPGfZtz_7Rh2zJ" // TODO: Remove before commits
                    DiscordWebhookUrl = "https://discordapp.com/api/webhooks/...",
                    CheckInterval = 5000,
                    AvatarLogoUrl = "https://imgur.com/ycIPvZB"
                };

                Toml.WriteFile(_config, _configPath);
            }

            return false;
        }
    }
}
