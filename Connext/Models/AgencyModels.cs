using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Connext.Models
{
    public class AgencyModel
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public AgencyModel() { }
        public AgencyModel(ConnextBusinessLayer.Bdd.AGENCY objBdd)
        {
            Id = objBdd.ID_AGENCY;
            Name = objBdd.NAME;
            Latitude = objBdd.LATITUDE;
            Longitude = objBdd.LONGITUDE;
        }
    }
}