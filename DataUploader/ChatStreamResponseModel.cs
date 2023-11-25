using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataUploader
{
    public class Choice
    {
        public int index { get; set; }
        public Delta delta { get; set; }
        public object finish_reason { get; set; }
    }

    public class Delta
    {
        public string content { get; set; }
    }

    public class ChatStreamResponseModel
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public List<Choice> choices { get; set; }
    }
}
