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
            return new PublicationModel(manager.get(id));
        }

        // PUT api/values/5
        public string Put(int id, AgencyModel model)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
