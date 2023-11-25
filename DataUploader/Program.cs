// See https://aka.ms/new-console-template for more information
using CustomGpt.Core.Constants;
using CustomGpt.Service.Models;
using DataUploader;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace DataUploader
{
    class Program
    {
        static int DataHeaderLength = "data: ".Length;

        static async Task Main(string[] args)
        {
            var chatCompletionModel = new ChatCompletionModel
            {
                Model = "gpt-4",
                Stream = true,
                MaxTokens = 500
            };

            chatCompletionModel.Messages.Add(new Message
            {
                Role = "system",
                Content = "You are a helpful assistant." //add more context as needed.
            });

            chatCompletionModel.Messages.Add(new Message
            {
                Role = "user",
                Content = "Use below articles to answer about .net aspire. .NET Aspire is a stack for building resilient, observable, and configurable cloud-native applications with .NET. It includes a curated set of components enhanced for cloud-native by including telemetry, resilience, configuration, and health checks by default. Combined with a sophisticated but simple local developer experience, .NET Aspire makes it easy to discover, acquire, and configure essential dependencies for cloud-native applications on day 1 as well as day 100. The first preview of .NET Aspire is available today. Question: Does .net aspire contains telemetry?"
            });

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(OpenAIUri.ChatCompletion),
                Headers =
                {
                    { "accept", "application/json" },
                    { "Authorization", $"Bearer [API KEY]" }
                },
                Content = JsonContent.Create(chatCompletionModel)
            };

            StringBuilder result = new();
            await foreach (var response in StreamChatCompletionsRaw(request))
            {
                var content = response.choices[0].delta?.content;
                if (content is not null)
                    result.Append(content);
            }

            Console.WriteLine(result.ToString());

        }

        static (ProcessResponseEventResult result, ChatStreamResponseModel data) ProcessResponseEvent(string line)
        {
            if (line.StartsWith("data: "))
                line = line[DataHeaderLength..];

            if (string.IsNullOrWhiteSpace(line)) return (ProcessResponseEventResult.Empty, default);

            if (line == "[DONE]")
                return (ProcessResponseEventResult.Done, default);

            var data = JsonSerializer.Deserialize<ChatStreamResponseModel>(line);
            if (data is null)
                throw new JsonException($"Failed to deserialize response: {line} to type {typeof(ChatStreamResponseModel)}");

            return (ProcessResponseEventResult.Response, data);
        }

        static ValueTask<string?> ReadLineAsync(TextReader reader, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(reader);
            return reader.ReadLineAsync(cancellationToken);
        }

        private static async IAsyncEnumerable<ChatStreamResponseModel> StreamChatCompletionsRaw(HttpRequestMessage httpRequest)
        {
            using var client = new HttpClient();
            var response = await client.SendAsync(httpRequest);
            response.EnsureSuccessStatusCode();

            var l = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(l);
            while (await ReadLineAsync(reader, CancellationToken.None) is { } line)
            {

                var (result, data) = ProcessResponseEvent(line);
                //Console.WriteLine(data.choices[0].delta?.content);
                switch (result)
                {
                    case ProcessResponseEventResult.Done:
                        yield break;
                    case ProcessResponseEventResult.Empty:
                        continue;
                    case ProcessResponseEventResult.Response:
                        yield return data!;
                        break;
                }
            }

            yield break;
        }
    }
}
