namespace HomeNetHeroApp
{
    public class IPAddressMonitor
    {
        private HttpClient _client = new HttpClient();
        private string _lastIPAddress = null;

        public async Task<string> GetPublicIPAddressAsync()
        {
            string ip = await _client.GetStringAsync("https://api.ipify.org");
            return ip.Trim(); // remove any whitespace or line breaks
        }

        public async Task<bool> HasIPAddressChangedAsync()
        {
            string currentIPAddress = await GetPublicIPAddressAsync();

            if (_lastIPAddress == null)
            {
                _lastIPAddress = currentIPAddress;
                return false;
            }

            if (_lastIPAddress != currentIPAddress)
            {
                _lastIPAddress = currentIPAddress;
                return true;
            }

            return false;
        }
    }
}
