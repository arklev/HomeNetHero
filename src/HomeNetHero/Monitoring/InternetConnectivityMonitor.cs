using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeNetHeroApp
{
    using System;
    using System.Net.NetworkInformation;

    public class InternetConnectivityMonitor
    {
        public bool IsInternetAvailable()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = ping.Send("8.8.8.8");
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false; // If there's an exception, assume that the Internet is not available.
            }
        }
    }

}
