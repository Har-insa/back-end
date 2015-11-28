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
    public class CategoriesController : ApiController
    {

        private CategoryManager manager = new CategoryManager();
        // GET api/values
        public List<CategoryModel> Get()
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
                List<CategoryModel> listLiteModel = new List<CategoryModel>();
                foreach (CATEGORY agency in manager.getList())
                {
                    listLiteModel.Add(new CategoryModel(agency));
                }
                return listLiteModel;
        }

        // GET api/values/5
        public CategoryModel Get(int id)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            return new CategoryModel(manager.get(id));
        }

        // POST api/values
        /*public string Post(AgencyModel model)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            string token = HttpContext.Current.Request.Headers["Authorization"];
            AGENCY objBdd = new AGENCY();
            objBdd.NAME = model.Name;
            objBdd.LATITUDE = model.Latitude;
            objBdd.LONGITUDE = model.Longitude;
            manager.add(objBdd);
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
