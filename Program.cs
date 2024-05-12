using Lab5_Http;

class Program
{
    static async Task Main()
    {
        string accessKey = "8288699ac75bb974aa46ee8f65c3789f";
        IPStackClient ipStackClient = new IPStackClient(accessKey);

        // Отримання інформації про конкретну IP-адресу
        ResponseModel<string> ipInfoResponse = await ipStackClient.GetInfoAboutIP("8.8.8.8"); // DNS-сервер Google

        if (ipInfoResponse.HttpStatusCode == 200)
        {
            Console.WriteLine($"Message: {ipInfoResponse.Message}");
            Console.WriteLine($"HTTP Status Code: {ipInfoResponse.HttpStatusCode}");

            if (ipInfoResponse.Data != null)
            {
                foreach (var data in ipInfoResponse.Data)
                {
                    Console.WriteLine($"Data from API: {data}");
                }
            }
            else
            {
                Console.WriteLine("No data received from API.");
            }
        }
        else
        {
            Console.WriteLine($"Error: {ipInfoResponse.Message}");
            Console.WriteLine($"HTTP Status Code: {ipInfoResponse.HttpStatusCode}");
        }

        Console.WriteLine();

        // Отримання інформації про локальну IP-адресу
        ResponseModel<string> localIpInfoResponse = await ipStackClient.GetInfoAboutLocalIP();

        if (localIpInfoResponse.HttpStatusCode == 200)
        {
            Console.WriteLine($"Message: {localIpInfoResponse.Message}");
            Console.WriteLine($"HTTP Status Code: {localIpInfoResponse.HttpStatusCode}");

            if (localIpInfoResponse.Data != null)
            {
                foreach (var data in localIpInfoResponse.Data)
                {
                    Console.WriteLine($"Data from API: {data}");
                }
            }
            else
            {
                Console.WriteLine("No data received from API.");
            }
        }
        else
        {
            Console.WriteLine($"Error: {localIpInfoResponse.Message}");
            Console.WriteLine($"HTTP Status Code: {localIpInfoResponse.HttpStatusCode}");
        }
    }
}