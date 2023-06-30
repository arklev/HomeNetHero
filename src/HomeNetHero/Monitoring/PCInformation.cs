using System;
using System.Diagnostics;
using System.Net;

namespace HomeNetHeroApp
{
    public class PCInformation
    {
        public string GetPCName()
        {
            return Environment.MachineName;
        }

        public string GetExternalIP()
        {
            try
            {
                using (var client = new WebClient())
                {
                    string externalIP = client.DownloadString("https://api.ipify.org");
                    return externalIP;
                }
            }
            catch (Exception ex)
            {
                return "Error retrieving external IP: " + ex.Message;
            }
        }

        public string GetTotalUptime()
        {
            var uptime = TimeSpan.FromMilliseconds(Environment.TickCount);
            return uptime.ToString();
        }
    }
}
