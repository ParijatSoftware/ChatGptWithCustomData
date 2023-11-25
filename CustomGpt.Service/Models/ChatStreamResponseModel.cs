using System.Text.Json.Serialization;

namespace CustomGpt.Service.Models
{
    public class ChatStreamResponseChoice
    {
        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("delta")]
        public Delta Delta { get; set; }

        [JsonPropertyName("finish_reason")]
        public object FinishReason { get; set; }
    }

    public class Delta
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public class ChatStreamResponseModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("object")]
        public string Object { get; set; }

        [JsonPropertyName("created")]
        public int Created { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("choices")]
        public List<ChatStreamResponseChoice> Choices { get; set; }
    }
}
