using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
namespace Agricultural.Application.Common
{
    public class DtRequest
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        [JsonPropertyName("search[value]")]
        public string searchValue { get; set; }
    }
}
