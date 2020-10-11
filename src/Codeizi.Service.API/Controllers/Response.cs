using System.Collections.Generic;
using System.Linq;

namespace Codeizi.Service.API.Controllers
{
    public class Response
    {
        public bool IsSuccess => !Erros.Any();
        public List<KeyValuePair<string, string>> Erros { get; set; }

        public Response()
            => Erros = new List<KeyValuePair<string, string>>();

        public void AddErros(
            string propertyName,
            string error)
            => Erros.Add(new KeyValuePair<string, string>(propertyName, error));
    }
}