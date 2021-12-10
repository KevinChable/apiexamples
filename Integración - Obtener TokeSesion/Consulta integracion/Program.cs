using System;
//Es necesario instalar la librería.
using RestSharp;
//Es necesario habilitar 'System.Web.Extensions' en las referencias del proyecto.
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace POST
{
    public class jsontoken
    {
        public string token { get; set; }
    }
    class parametros
    {
        public string pagina { get; set; }
        public string cantidadRegistros { get; set; }
    }
    public class jsontoken2
    {
        public string tkVenta { get; set; }
    }
    class http_post
    {
        static void Main()
        {
            var url = "https://api.salesup.com";
            var path = "/integraciones/sesion";
            var tokenIntegracion = "P023B177E24-C5F6-4F2E-91D3-55C56014B6F7";

            var client = new RestClient(url);
            var request = new RestRequest(path, Method.POST);
            request.AddHeader("token", tokenIntegracion);
            IRestResponse response = client.Execute(request);
            var result = response.Content;

            var results = JsonConvert.DeserializeObject<List<jsontoken>>(result);

            var tokenSesion = results[0].token;

            Console.WriteLine(tokenSesion);
            Console.ReadLine();
        }
    }


}
