using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HomeNetHeroApp.Notification
{
    public class WebHookSender
    {
        #region Members

        private string _webhookUrl;
        private HttpClient _client;

        #endregion

        #region Public Methods

        public WebHookSender(string webHookUrl)
        {
            if (string.IsNullOrEmpty(webHookUrl))
            {
                throw new ArgumentNullException(@"Webhook cannot be null or empty");
            }

            _webhookUrl = webHookUrl;
            _client = new HttpClient();
        }

        public DiscordWebhookContent BuildNotificationContent(DiscordEmbedField[] fields)
        {
            DiscordWebhookContent webhookContent = new DiscordWebhookContent
            {
                Username = "HomeNetHero",
                AvatarUrl = "https://i.imgur.com/4M34hi2.png",
                Embeds = new DiscordEmbed[]
                {
                    new DiscordEmbed
                    {
                        Title = Environment.MachineName,
                        Color = 15258703,
                        Fields = fields,
                        Footer = new DiscordEmbedFooter
                        {
                            Text = "Woah! So cool! :smirk:",
                            IconUrl = "https://i.imgur.com/fKL31aD.jpg"
                        }
                    }
                }
            };

            return webhookContent;
        }

        public async Task SendNotificationAsync(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException(@"Payload content cannot be null or empty");
            }

            try
            {
                JsonDocument.Parse(content);
            }
            catch (JsonException ex)
            {

                Log.Error("Invalid JSON: " + ex.Message);
                return;
            }

            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(_webhookUrl, httpContent);

            if (response.IsSuccessStatusCode)
            {
                Log.Information("Message sent successfully!");
            }
            else
            {
                Log.Error($"Failed to send message. Error: {response.StatusCode}");
            }
        }

        #endregion
    }
}
