using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConnextBusinessLayer.Bdd;
using ConnextBusinessLayer.Managers;
using Connext.Models;
using System.Web;

namespace Connext.Controllers
{
    public class RequestTravelsController : ApiController
    {

        private RequestTravelManager manager = new RequestTravelManager();
        // GET api/values
        public List<RequestTravelModel> Get()
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            List<RequestTravelModel> listModel = new List<RequestTravelModel>();
            foreach(REQUEST_TRAVEL request in manager.getList())
            {
                listModel.Add(new RequestTravelModel(request));
            }
            return listModel;
        }

        // GET api/values/5
        public List<RequestTravelModel> Get(int id)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            List<RequestTravelModel> listModel = new List<RequestTravelModel>();
            foreach (REQUEST_TRAVEL request in manager.getList(id))
            {
                listModel.Add(new RequestTravelModel(request));
            }
            return listModel;
        }

        // POST api/values
        public HttpResponseMessage Post(RequestTravelModel model)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            REQUEST_TRAVEL objBdd = new REQUEST_TRAVEL();
            objBdd.ID_TRAVEL = model.IdTravel;
            objBdd.ID_USER = model.IdUser;
            objBdd.ID_ACTION = 1;
            manager.add(objBdd);
            return new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    Success = true, //error
                    Message = "Success" //return exception
                })
            };
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, RequestTravelModel re)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            manager.modify(id, re.IdAction);
            return new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    Success = true, //error
                    Message = "Success" //return exception
                })
            };
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
