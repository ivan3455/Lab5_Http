namespace Lab5_Http
{
    public class APIClient
    {
        public async Task<ResponseModel<string>> Get(string url)
        {
            var responseModel = new ResponseModel<string>();
            try
            {
                // Використання using для автоматичного звільнення ресурсів HttpClient.
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    responseModel.Message = "HTTP request successful.";
                    responseModel.HttpStatusCode = (int)response.StatusCode;
                    responseModel.Data = new List<string> { responseBody };
                }
            }
            catch (HttpRequestException e)
            {
                responseModel.Message = $"HTTP request failed: {e.Message}";
                responseModel.HttpStatusCode = 500; // Internal Server Error
                responseModel.Data = null;
            }
            return responseModel;
        }

        public async Task<ResponseModel<string>> Post(string url, string data)
        {
            var responseModel = new ResponseModel<string>();
            try
            {
                // Перевірка, чи дані не порожні.
                if (string.IsNullOrEmpty(data))
                {
                    responseModel.Message = "Data cannot be null or empty.";
                    responseModel.HttpStatusCode = 400; // Bad Request
                    responseModel.Data = null;
                    return responseModel;
                }

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(data);

                    HttpResponseMessage response = await httpClient.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    responseModel.Message = "HTTP request successful.";
                    responseModel.HttpStatusCode = (int)response.StatusCode;
                    responseModel.Data = new List<string> { responseBody };
                }
            }
            catch (HttpRequestException e)
            {
                responseModel.Message = $"HTTP request failed: {e.Message}";
                responseModel.HttpStatusCode = 500; // Internal Server Error
                responseModel.Data = null;
            }
            return responseModel;
        }
    }
}
