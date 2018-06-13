using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestObjects.Infrastructure.Utils
{
    public static class ConversionUtils
    {
        public static async Task<T> Deserialize<T>(this HttpContent content)
        {
            var result = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
