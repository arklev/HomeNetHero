namespace HomeNetHeroApp
{
    public class Config
    {
        // Define the properties you want to read from your TOML configuration file
        // This is an example, modify it according to your needs
        public string DiscordWebhookUrl { get; set; }
        public int CheckInterval { get; set; }
        public string AvatarLogoUrl { get; set; }
    }
}
