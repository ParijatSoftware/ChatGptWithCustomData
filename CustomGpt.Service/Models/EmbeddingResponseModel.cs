namespace CustomGpt.Service.Models
{
    public class EmbeddingResponseModel
    {
        public string Object { get; set; }
        public List<EmbeddingDataModel> Data { get; set; }
        public string Model { get; set; }
        public Usage Usage { get; set; }
    }

    public class EmbeddingDataModel
    {
        public string Object { get; set; }
        public int Index { get; set; }
        public List<double> embedding { get; set; }
    }

    public class Usage
    {
        public int Prompt_tokens { get; set; }
        public int Total_tokens { get; set; }
    }
}
