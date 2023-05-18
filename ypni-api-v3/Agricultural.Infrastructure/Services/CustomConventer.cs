
using Agricultural.Application.Interfaces.Common;
using System.Text.Json;
namespace Agricultural.Infrastructure.Services
{
    public class CustomConventer : ICustomConventer
    {
        //public readonly JsonResult _json;

        public string EncodeJson(object obj)
        {
        
            return JsonSerializer.Serialize(obj);
        }

     public   T DecodeJson<T>(string json) where T : class
        {

           
            return JsonSerializer.Deserialize<T>(json); ;
        }

    }
    
}
