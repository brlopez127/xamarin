using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Services
{
    public static class UserService
    {
        public static string UriClient = "http://192.168.137.122";

        /// <summary>
        /// Verifica si un usuario ya se encuentra registrado
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsRegister(string email, string password)
        {
            try
            {
                Models.User user = new Models.User { Email = email, Password = password };

                var json = JsonConvert.SerializeObject(user);

                var client = new RestClient(UriClient);
                // client.Authenticator = new HttpBasicAuthenticator(username, password);

                var request = new RestRequest("proyectoPI/api/User/IsRegister", Method.POST);

                request.RequestFormat = DataFormat.Json;

                // adds to POST or URL querystring based on Method                
                request.AddParameter("application/json", json, ParameterType.RequestBody);



                // easily add HTTP Headers
                request.AddHeader("Content-Type", "application/json");


                // execute the request
                IRestResponse response = client.Execute(request);
                var content = response.Content; // raw content as string

                JObject result = JObject.Parse(content);


                if ((int)result["status"] == 200)
                {
                    if ((bool)result["result"])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



    }
}
