﻿using System;
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
        // GET api/travels
        public List<TravelLiteModel> Get()
        {
            try { 
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else                
            {
                List<TravelLiteModel> listLiteModel = new List<TravelLiteModel>();
                    if (HttpContext.Current.Request["id_user"] != null)
                    {
                        foreach (TRAVEL travel in manager.getListByUser(int.Parse(HttpContext.Current.Request["id_user"])))
                        {
                            listLiteModel.Add(new TravelLiteModel(travel));
                        }
                    }
                    else
                    {
                        foreach (TRAVEL travel in manager.getList())
                        {
                            listLiteModel.Add(new TravelLiteModel(travel));
                        }
                    }
                listLiteModel.Sort((x, y) => DateTime.Compare(y.Publication.DateTimeCreation, x.Publication.DateTimeCreation));
                return listLiteModel;
            }
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        // GET api/travels/5
        public TravelModel Get(int id)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            return new TravelModel(manager.get(id));
        }

        // POST api/values
        public HttpResponseMessage Post(TravelEditModel model)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else
            {
                try
                {
                    TRAVEL travelBdd = new TRAVEL();
                    travelBdd.ID_ARRIVALAGENCY = model.ArrivalAgency.Id;
                    travelBdd.ID_DEPARTUREAGENCY = model.DepartureAgency.Id;
                    travelBdd.ARRIVALHOUR = model.ArrivalTime;
                    travelBdd.DEPARTUREHOUR = model.DepartureTime;
                    travelBdd.CAPACITY = model.Capacity;

                    PUBLICATION publicationBdd = new PUBLICATION();

                    string tokenString = HttpContext.Current.Request.Headers["Authorization"];
                    UserManager userManager = new UserManager();
                    publicationBdd.ID_USER = userManager.getUserFromSession(new Guid(tokenString));
                    publicationBdd.TITLE = model.Publication.Title;
                    publicationBdd.DESCRIPTION = model.Publication.Description;
                    publicationBdd.ID_GROUP = 1;
                    publicationBdd.ID_CATEGORY = 1;
                    publicationBdd.DATE_TIME_CREATION = DateTime.Now.AddHours(1);


                    manager.add(travelBdd, publicationBdd);
                    return new HttpResponseMessage()
                    {
                        Content = new JsonContent(new
                        {
                            Success = true, //error
                            Message = "Success" //return exception
                        })
                    };
                }
                catch(Exception e)
                {
                    return new HttpResponseMessage()
                    {
                        Content = new JsonContent(new
                        {
                            Success = false, //error
                            Message = "Exception with token :" + HttpContext.Current.Request.Headers["Authorization"] + " Error :" + e.ToString() //return exception
                        })
                    };
                }
            }
        }

        // PUT api/values/5
        public string Put(int id, RequestTravelModel model)
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
