using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeNetHeroApp
{
    internal class WebHookDemo
    {
        public WebHookDemo()
        {

        }

        public async Task SendNotificationAsync()
        {
            string webhookUrl = "https://discord.com/api/webhooks/1124303603818041424/v9ulPUvteGxSCWS46lyK6G5U4xOoFLX6685eXla0XDe3e_zJmkDexyzPGfZtz_7Rh2zJ";
            string content = "```css\n[INFO]\nHello, Discord! This is a test message.\n```";

            string jsonPayload = webhookContent.ToJson();
            using (HttpClient client = new HttpClient())
            {
                var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(webhookUrl, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Message sent successfully!");
                }
                else
                {
                    Console.WriteLine($"Failed to send message. Error: {response.StatusCode}");
                }
            }
        }
    }
}
