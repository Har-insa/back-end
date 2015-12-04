using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ConnextBusinessLayer.Bdd;

namespace Connext.Models
{
    public class TravelModel : TravelLiteModel
    {

        public TravelModel() { }
        public TravelModel(ConnextBusinessLayer.Bdd.TRAVEL objBdd)
        {
            Id = objBdd.ID_TRAVEL;
            Publication = new PublicationModel(objBdd.PUBLICATION);
            DepartureAgency = new AgencyLiteModel(objBdd.AGENCY);
            ArrivalAgency = new AgencyLiteModel(objBdd.AGENCY1);
            Capacity = objBdd.CAPACITY;
            DepartureTime = objBdd.DEPARTUREHOUR;
            ArrivalTime = objBdd.ARRIVALHOUR;
        }
    }
    
    public class TravelLiteModel
    {
        public int Id { get; set; }
        public PublicationLiteModel Publication { get; set; }
        public int Capacity { get; set; }
        public AgencyLiteModel DepartureAgency { get; set; }
        public AgencyLiteModel ArrivalAgency { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public TravelLiteModel() { }
        public TravelLiteModel(ConnextBusinessLayer.Bdd.TRAVEL objBdd)
        {
            Id = objBdd.ID_TRAVEL;
            Publication = new PublicationLiteModel(objBdd.PUBLICATION);
            DepartureAgency = new AgencyLiteModel(objBdd.AGENCY);
            ArrivalAgency = new AgencyLiteModel(objBdd.AGENCY1);
            Capacity = objBdd.CAPACITY;
            DepartureTime = objBdd.DEPARTUREHOUR;
            ArrivalTime = objBdd.ARRIVALHOUR;
        }
    }
    public class TravelEditModel
    {
        public int Id { get; set; }
        public PublicationModel Publication { get; set; }
        public int Capacity { get; set; }

        public int CapacityRemains { get; set; }
        public AgencyLiteModel DepartureAgency { get; set; }
        public AgencyLiteModel ArrivalAgency { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public TravelEditModel() { }
        public TravelEditModel(ConnextBusinessLayer.Bdd.TRAVEL objBdd)
        {
            Id = objBdd.ID_TRAVEL;
            Publication = new PublicationModel(objBdd.PUBLICATION);
            DepartureAgency = new AgencyLiteModel(objBdd.AGENCY);
            ArrivalAgency = new AgencyLiteModel(objBdd.AGENCY1);
            Capacity = objBdd.CAPACITY;
            DepartureTime = objBdd.DEPARTUREHOUR;
            ArrivalTime = objBdd.ARRIVALHOUR;
        }
    }
}