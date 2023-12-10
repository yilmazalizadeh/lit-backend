using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace Acq.IntegrityTests.Helper;

public static class ObjectConvertor
{
    public static StringContent ConvertToStringContent(dynamic inputItem)
    {
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented // Optional: if you want the JSON to be indented
        };
        var jsonString = JsonConvert.SerializeObject(inputItem, settings);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        return content;
    }
}