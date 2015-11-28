using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ConnextBusinessLayer.Bdd;

namespace Connext.Models
{
    
    public class RequestTravelModel
    {
        public int Id { get; set; }
        public int IdTravel { get; set; }
        public int IdUser { get; set; }
        public int IdAction { get; set; }
        public RequestTravelModel() { }
        public RequestTravelModel(REQUEST_TRAVEL objBdd)
        {
            Id = objBdd.ID_REQUEST_TRAVEL;
            IdTravel = objBdd.ID_TRAVEL;
            IdUser = objBdd.ID_USER;
            IdAction = objBdd.ID_ACTION;
        }
    }
    public class ActionRequestModel
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public ActionRequestModel() { }
        public ActionRequestModel(ACTION objBdd)
        {
            Id = objBdd.ID_ACTION;
            Libelle = objBdd.LIBELLE;
        }
    }
}