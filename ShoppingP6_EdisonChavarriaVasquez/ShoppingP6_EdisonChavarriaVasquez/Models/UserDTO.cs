using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingP6_EdisonCV.Models
{
    public class UserDTO
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentype = "Content-Type";



        public int IDUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string Contrasennia { get; set; } = null!;
        public string CorreoRespaldo { get; set; } = null!;

        public string NumeroTelefono { get; set; } = null!;

        public int IDRol { get; set; }
        public int IDPais { get; set; }

        public string RolDescripcion { get; set; } = null!;

        public string PaisNombre { get; set; } = null!;

        public async Task<UserDTO> GetUserData(string email)
        {

            try
            {
                string RouteSufix = string.Format("Users/GetUserInfo?email={0}",
                    email);
                string FinalURL = Services.CnnToP6API.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                //agregar la info de seguridad del api , aqui va la apikey

                request.AddHeader(Services.CnnToP6API.ApiKeyName, Services.CnnToP6API.ApiKeyValue);
                request.AddHeader(contentype, mimetype);



                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                //carga de info en un json


                if (statusCode == HttpStatusCode.OK)
                {
                    //carga de info en un json
                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);
                    var item = list[0];
                    
                    
                    return item;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                string msg = ex.Message;

                //to do guardar errores en una bitacora.
                throw;
            }

        }



        //funcion actualizar usuario

        public async Task<bool> UpdateUser()
        {

            try
            {
                string RouteSufix = string.Format("");
                string FinalURL = Services.CnnToP6API.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method. Put);// se usa put o patch

                //agregar la info de seguridad del api , aqui va la apikey

                request.AddHeader(Services.CnnToP6API.ApiKeyName, Services.CnnToP6API.ApiKeyValue);
                request.AddHeader(contentype, mimetype);

                //Tenemos que serializar la clase para poder enviarla a la api
                string SerialClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerialClass, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                //carga de info en un json


                if (statusCode == HttpStatusCode.OK)
                {
                    //carga de info en un json

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                string msg = ex.Message;

                //to do guardar errores en una bitacora.
                throw;
            }

        }




    }
}
