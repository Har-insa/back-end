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

namespace Connext.Controllers
{
    public class AgenciesController : ApiController
    {

        private AgencyManager manager = new AgencyManager();
        // GET api/values
        public List<AgencyModel> Get()
        {
            List<AgencyModel> listModel = new List<AgencyModel>();
            foreach(AGENCY agency in manager.getList())
            {
                listModel.Add(new AgencyModel(agency));
            }
            return listModel;
        }

        // GET api/values/5
        public AgencyModel Get(int id)
        {
            return new AgencyModel(manager.get(1));
        }

        // POST api/values
        public string Post(AgencyModel model)
        {
            AGENCY objBdd = new AGENCY();
            objBdd.NAME = model.Name;
            objBdd.LATITUDE = model.Latitude;
            objBdd.LONGITUDE = model.Longitude;
            manager.add(objBdd);
            return "done!";
        }

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
