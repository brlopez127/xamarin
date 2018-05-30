using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App3.Services;
using Newtonsoft.Json;
using RestSharp;
using Xamarin.Forms;

[assembly: Dependency(typeof(Api))]
    
namespace App3.Services
{
    class Api : IApi
    {
        public Task<RespuestaDocente> EstudiantesApi ( string user, string password)
        {
            RestClient _client = new RestClient("http://youis.000webhostapp.com/Project/Utap/api/");
            RestRequest _Request = new RestRequest("/utap0-0.php", Method.POST) { RequestFormat = DataFormat.Json };

            _Request.AddParameter("email", user);
            _Request.AddParameter("password", password);

            try
            {
                var _respuesta = _client.Execute(_Request);
                var a = _respuesta.Content;
                RespuestaDocente respuestaServer = JsonConvert.DeserializeObject<RespuestaDocente>(_respuesta.Content);
                return Task.FromResult(respuestaServer);
            }
            catch (Exception ex)
            {

                return Task.FromResult(new RespuestaDocente() { message = "Error:" + ex.Message });
            }
       

        }

        public Task<RespuestaDocente2> Notas(int Estudiante_id)
        {
            RestClient _client = new RestClient("http://youis.000webhostapp.com/Project/Utap/api/");
            RestRequest _Request = new RestRequest("/utap1-0.php", Method.POST) { RequestFormat = DataFormat.Json };

            _Request.AddParameter("estudiante_id", Estudiante_id);
           

            try
            {
                var _respuesta = _client.Execute(_Request);
                var a = _respuesta.Content;
                RespuestaDocente2 respuestaServer = JsonConvert.DeserializeObject<RespuestaDocente2>(_respuesta.Content);
                return Task.FromResult(respuestaServer);
            }
            catch (Exception ex)
            {

                return Task.FromResult(new RespuestaDocente2() { message = "Error:" + ex.Message });
            }


        }

    }
}
