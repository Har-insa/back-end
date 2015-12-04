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
    public class LoginController : ApiController
    {

        private UserManager manager = new UserManager();
        public TokenModel Login(UserModel model)
        {
            if (model == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            try {
                string token = manager.checkUser(model.Email, model.Password);
                if (token != null)
                {
                    return new TokenModel(token);
                }
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
    }
}
