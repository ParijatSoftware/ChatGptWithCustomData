using CustomGpt.Core.Constants;

namespace CustomGpt.Core.Helpers
{
    public static class ModelTokenHelper
    {
        static Dictionary<string, int> modelWithTokens = new Dictionary<string, int>
        {
            { OpenAIModels.GPT4, 8192 },
            { OpenAIModels.GPT4_Turbo, 128000 }
        };

        public static int GetMaxTokenValue(string model)
        {
            if (modelWithTokens.ContainsKey(model))
                return modelWithTokens[model];
            else
                throw new Exception("Model not found");
        }
    }
}
