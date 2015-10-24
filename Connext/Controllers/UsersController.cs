using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConnextBusinessLayer.Bdd;
using ConnextBusinessLayer.Managers;
using Connext.Models;

namespace Connext.Controllers
{
    public class UsersController : ApiController
    {

        private UserManager manager = new UserManager();
        // GET api/values
        public List<UserLiteModel> Get()
        {
            List<UserLiteModel> listModel = new List<UserLiteModel>();
            foreach(USER user in manager.getList())
            {
                listModel.Add(new UserLiteModel(user));
            }
            return listModel;
        }

        // GET api/values/5
        public UserModel Get(int id)
        {
            return new UserModel(manager.get(1));
        }

        // POST api/values
        public string Post(UserModel model)
        {
            USER objBdd = new USER();
            objBdd.FIRST_NAME = model.FirstName;
            objBdd.LAST_NAME = model.Lastname;
            objBdd.ID_AGENCY = model.Agency.Id;
            objBdd.EMAIL = model.Email;
            objBdd.PASSWORD = model.Password;
            objBdd.DESCRIPTION = model.Description;
            manager.add(objBdd);
            return "done!";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
