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
    public class GroupsController : ApiController
    {

        private GroupManager manager = new GroupManager();
        // GET api/values
        public List<GroupLiteModel> Get()
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else
            {
                List<GroupLiteModel> listLiteModel = new List<GroupLiteModel>();
                foreach (GROUP group in manager.getList())
                {
                    listLiteModel.Add(new GroupLiteModel(group));
                }
                return listLiteModel;
            }
        }

        // GET api/values/5
        public GroupModel Get(int id)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            return new GroupModel(manager.get(id));
        }

        // POST api/values
        public HttpResponseMessage Post(GroupModel model)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            string token = HttpContext.Current.Request.Headers["Authorization"];
            GROUP objBdd = new GROUP();
            objBdd.LABEL = model.Label;
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
        public HttpResponseMessage Put(int id, ActionModel action)
        {
            if (HttpContext.Current.Request.Headers["Authorization"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            if(action.action == "add")
            {
                manager.addUser(id, action.Id);
            }
            else if(action.action == "remove")
            {
                manager.removeUser(id, action.Id);
            }

            return new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    Success = true, //error
                    Message = "Success" //return exception
                })
            };
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
