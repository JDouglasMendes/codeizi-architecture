using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Codeizi.Integration.Test
{
    public static class StringContentJsonHelper
    {
        public static StringContent ToJson(this object objeto)
        {
            var content = JsonConvert.SerializeObject(objeto);
            return new StringContent(content, Encoding.UTF8, "application/json");
        }
    }
}