namespace CustomGpt.Service.Models
{
    public class ChatCompletionResponseModel
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public int Created { get; set; }
        public string Model { get; set; }
        public List<ChatCompletionUsage> Choices { get; set; }
        public Usage Usage { get; set; }

        public override string ToString()
        {
            if (Choices != null && Choices.Count > 0)
                return Choices[0].ToString();
            else
                return null;
        }
    }

    public class Choice
    {
        public int Index { get; set; }
        public ChatCompletionMessage Message { get; set; }
        public string FinishReason { get; set; }
    }

    public class ChatCompletionMessage
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }
    public class ChatCompletionUsage
    {
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
        public int TotalTokens { get; set; }
    }
}
