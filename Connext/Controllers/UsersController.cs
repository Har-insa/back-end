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
    public class UsersController : ApiController
    {
        private UserManager manager = new UserManager();
        // GET api/values
        public List<UserLiteModel> Get()
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
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
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            return new UserModel(manager.get(id));
        }

        // POST api/values
        public HttpResponseMessage Post(UserModel model)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            USER objBdd = new USER();
            objBdd.FIRST_NAME = model.FirstName;
            objBdd.LAST_NAME = model.Lastname;
            objBdd.ID_AGENCY = model.Agency.Id;
            objBdd.EMAIL = model.Email;
            objBdd.PASSWORD = model.Password;
            objBdd.DESCRIPTION = model.Description;
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
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
