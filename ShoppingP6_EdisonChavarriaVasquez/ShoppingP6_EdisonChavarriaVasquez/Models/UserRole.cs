using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShoppingP6_EdisonCV.Models
{
    public class UserRole
    {

        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentype = "Content-Type";

        public UserRole()
        {
          //  Users = new HashSet<User>();
        }

        public int IduserRole { get; set; }
        public string UserRoleDescription { get; set; } = null!;

        //public virtual ICollection<User> Users { get; set; }

        //FUNCIONES PARA EL MODELO
        //para mostrarlos como un picker (combobox)

        public async Task<List<UserRole>> GetUserRoles()
        {

            try
            {
                string RouteSufix = string.Format("UserRoles");
                string FinalURL = Services.CnnToP6API.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL,Method.Get);

                //agregar la info de seguridad del api , aqui va la apikey

                request.AddHeader(Services.CnnToP6API.ApiKeyName, Services.CnnToP6API.ApiKeyValue);
                request.AddHeader(contentype, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                //carga de info en un json

              
                if(statusCode == HttpStatusCode.OK )
                {
                    var list = JsonConvert.DeserializeObject<List<UserRole>>(response.Content);
                    return list;
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
      

    }
}
