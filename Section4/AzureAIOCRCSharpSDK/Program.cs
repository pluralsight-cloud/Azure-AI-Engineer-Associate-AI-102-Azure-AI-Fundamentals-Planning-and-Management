using System;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Threading.Tasks;

// Must have run dotnet add package Microsoft.Azure.CognitiveServices.Vision.ComputerVision --version 7.0.0
class Program
{
    static readonly string subscriptionKey = Environment.GetEnvironmentVariable("AI_SVC_KEY");
    static readonly string endpoint = Environment.GetEnvironmentVariable("AI_SVC_ENDPOINT");

    static void Main()
    {
        string imageUrl = "https://github.com/johnthebrit/RandomStuff/raw/master/Whiteboards/RAG.png";

        var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey))
        {
            Endpoint = endpoint
        };

        var result = ExtractTextFromImageAsync(client,imageUrl).Result;

        Console.WriteLine("\nExtracted text from image:");
        Console.WriteLine(result);
    }

    static async Task<string> ExtractTextFromImageAsync(ComputerVisionClient client, string imageUrl)
    {
        var ocrResult = await client.RecognizePrintedTextAsync(true, imageUrl);

        string result = "";
        foreach (var region in ocrResult.Regions)
        {
            foreach (var line in region.Lines)
            {
                foreach (var word in line.Words)
                {
                    result += word.Text + " ";
                }
                result += "\n";
            }
        }

        return result;
    }
}
