using System.Text;

class Program
{
    static readonly string subscriptionKey = Environment.GetEnvironmentVariable("AI_SVC_KEY");
    static readonly string endpoint = Environment.GetEnvironmentVariable("AI_SVC_ENDPOINT");
    static readonly string uriBase = endpoint + "computervision/imageanalysis:analyze?api-version=2024-02-01&features=read&language=en";

    static async Task Main()
    {
        string imageUrl = "https://github.com/johnthebrit/RandomStuff/raw/master/Whiteboards/RAG.png";

        HttpClient client = new HttpClient();

        // Request headers
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

        // Request body
        string json = "{\"url\":\"" + imageUrl + "\"}";

        HttpResponseMessage response;

        // Send the POST request
        byte[] byteData = Encoding.UTF8.GetBytes(json);
        using (var content = new ByteArrayContent(byteData))
        {
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            response = await client.PostAsync(uriBase, content);
        }

        // Get the JSON response
        string result = await response.Content.ReadAsStringAsync();

        // Output the response
        Console.WriteLine("\nResponse:\n\n{0}\n", result);
    }
}
