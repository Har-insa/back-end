using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConnextBusinessLayer.Bdd;
using ConnextBusinessLayer.Managers;
using Connext.Models;
using System.Web.Http.ModelBinding;
using System.Web;

namespace Connext.Controllers
{
    public class PublicationsController : ApiController
    {

        private PublicationManager manager = new PublicationManager();
        // GET api/values
        public List<PublicationLiteModel> Get()
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else                
            {
                List<PublicationLiteModel> listLiteModel = new List<PublicationLiteModel>();
                foreach (PUBLICATION agency in manager.getList())
                {
                    listLiteModel.Add(new PublicationLiteModel(agency));
                }
                return listLiteModel;
            }
        }

        // GET api/values/5
        public PublicationModel Get(int id)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            return new PublicationModel(manager.get(1));
        }

        // POST api/values
        /*public string Post(PublicationModel model)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            return "done";
        }*/

        // PUT api/values/5
        public string Put(int id, AgencyModel model)
        {
            return "Not implement yet!";
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            return "Don't do it please!";
        }
    }
}
