namespace Lab5_Http
{
    public class IPStackClient
    {
        private readonly APIClient _apiClient;
        private readonly string _accessKey;
        private readonly string _apiUrl;

        public IPStackClient(string accessKey)
        {
            _apiClient = new APIClient();
            _accessKey = accessKey;
            _apiUrl = "http://api.ipstack.com/";
        }

        public async Task<ResponseModel<string>> GetInfoAboutIP(string ip)
        {
            string url = $"{_apiUrl}{ip}?access_key={_accessKey}";
            return await _apiClient.Get(url);
        }

        public async Task<ResponseModel<string>> GetInfoAboutLocalIP()
        {
            string url = $"{_apiUrl}check?access_key={_accessKey}";
            return await _apiClient.Get(url);
        }
    }
}
