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
    public class TravelsController : ApiController
    {

        private TravelManager manager = new TravelManager();
        // GET api/values
        public List<TravelLiteModel> Get()
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else                
            {
                List<TravelLiteModel> listLiteModel = new List<TravelLiteModel>();
                foreach (TRAVEL travel in manager.getList())
                {
                    listLiteModel.Add(new TravelLiteModel(travel));
                }
                return listLiteModel;
            }
        }

        // GET api/values/5
        public TravelModel Get(int id)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            return new TravelModel(manager.get(1));
        }

        // POST api/values
        public string Post(TravelEditModel model)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            TRAVEL travelBdd = new TRAVEL();
            travelBdd.ID_ARRIVALAGENCY = model.ArrivalAgency.Id;
            travelBdd.ID_DEPARTUREAGENCY = model.DepartureAgency.Id;
            travelBdd.ARRIVALHOUR = model.ArrivalTime;
            travelBdd.DEPARTUREHOUR = model.DepartureTime;
            travelBdd.CAPACITY = model.Capacity;

            PUBLICATION publicationBdd = new PUBLICATION();

            byte[] tokenString = Convert.FromBase64String(HttpContext.Current.Request.Headers["Authorization"]);
            UserManager userManager = new UserManager();
            publicationBdd.ID_USER = userManager.getUserFromSession(new Guid(tokenString));
            publicationBdd.TITLE = model.Publication.Title;
            publicationBdd.DESCRIPTION = model.Publication.Description;
            publicationBdd.ID_GROUP = model.Publication.Group.Id;
            publicationBdd.ID_CATEGORY = 1;

            manager.add(travelBdd, publicationBdd);
            return "done";
        }

        // PUT api/values/5
        public string Put(int id, RequestTravelModel model)
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
