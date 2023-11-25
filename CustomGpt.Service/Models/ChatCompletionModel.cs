using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CustomGpt.Service.Models
{
    public class ChatCompletionModel
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("stream")]
        public bool Stream { get; set; }

        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; }

        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; } = new List<Message>();
    }

    public class Message
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
