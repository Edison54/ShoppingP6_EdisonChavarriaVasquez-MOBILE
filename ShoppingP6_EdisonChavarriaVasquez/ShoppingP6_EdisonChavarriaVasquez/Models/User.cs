using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingP6_EdisonCV.Models
{
    public class User
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentype = "Content-Type";



        public User()
        {
            // Invoices = new HashSet<Invoice>();
            // UserStores = new HashSet<UserStore>();
        }

        public int Iduser { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string BackUpEmail { get; set; } = null!;
        public string SecurityCode { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public bool? Active { get; set; }
        public int IduserRole { get; set; }
        public int Idcountry { get; set; }

        public virtual Country IdcountryNavigation { get; set; } = null!;
        public virtual UserRole IduserRoleNavigation { get; set; } = null!;

        //public virtual ICollection<Invoice> Invoices { get; set; }

        //public virtual ICollection<UserStore> UserStores { get; set; }

        public async Task<bool> AddUser()
        {

            try
            {
                string RouteSufix = string.Format("Users");
                string FinalURL = Services.CnnToP6API.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Post);

                //agregar la info de seguridad del api , aqui va la apikey

                request.AddHeader(Services.CnnToP6API.ApiKeyName, Services.CnnToP6API.ApiKeyValue);
                request.AddHeader(contentype, mimetype);

                //Tenemos que serializar la clase para poder enviarla a la api
                string SerialClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerialClass, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                //carga de info en un json


                if (statusCode == HttpStatusCode.Created)
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

