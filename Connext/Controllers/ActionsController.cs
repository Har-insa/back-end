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
    public class ActionsController : ApiController
    {

        private ActionManager manager = new ActionManager();
        // GET api/values
        public List<ActionRequestModel> Get()
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            List<ActionRequestModel> listLiteModel = new List<ActionRequestModel>();
            foreach (ACTION action in manager.getList())
            {
                listLiteModel.Add(new ActionRequestModel(action));
            }
            return listLiteModel;
        }

        // GET api/values/5
        public ActionRequestModel Get(int id)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            return new ActionRequestModel(manager.get(1));
        }

        // POST api/values
        public string Post(AgencyModel model)
        {
            throw new NotImplementedException();
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
