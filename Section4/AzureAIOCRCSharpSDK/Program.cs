using System.Net.Http.Headers;

class Program
{
    static readonly string subscriptionKey = Environment.GetEnvironmentVariable("AI_SVC_KEY");
    static readonly string endpoint = Environment.GetEnvironmentVariable("AI_SVC_ENDPOINT");

    static void Main()
    {
        string imageUrl = "https://github.com/johnthebrit/RandomStuff/raw/master/Whiteboards/RAG.png";

        var result = ExtractTextFromImageAsync(imageUrl).Result;

        Console.WriteLine("\nExtracted text from image:");
        Console.WriteLine(result);
    }

    static async Task<string> ExtractTextFromImageAsync(string imageUrl)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

        string uri = endpoint + "vision/v3.0/ocr?language=unk&detectOrientation=true";

        HttpResponseMessage response;
        string requestBody = "{\"url\":\"" + imageUrl + "\"}";

        using (var content = new StringContent(requestBody))
        {
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response = await client.PostAsync(uri, content);
        }

        string result = await response.Content.ReadAsStringAsync();
        return result;
    }
}
