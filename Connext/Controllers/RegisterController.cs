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
    public class RegisterController : ApiController
    {

        private UserManager manager = new UserManager();
        
        public TokenModel Register(UserModel model)
        {
            if (model == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            try
            {
                USER objBdd = new USER();
                objBdd.FIRST_NAME = model.FirstName;
                objBdd.LAST_NAME = model.Lastname;
                objBdd.ID_AGENCY = model.Agency.Id;
                objBdd.EMAIL = model.Email;
                objBdd.PASSWORD = model.Password;
                objBdd.DESCRIPTION = "";
                manager.add(objBdd);
                return new TokenModel(Convert.ToBase64String(Guid.NewGuid().ToByteArray()));
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
    }
}
