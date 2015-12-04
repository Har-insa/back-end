using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ConnextBusinessLayer.Bdd;

namespace Connext.Models
{
    public class GroupModel : GroupLiteModel
    {
        public List<UserBaseModel> listUser { get; set; }
        public GroupModel() { }
        public GroupModel(ConnextBusinessLayer.Bdd.GROUP objBdd) : base(objBdd)
        {
            listUser = new List<UserBaseModel>();
            foreach(var userBdd in objBdd.USERs)
            {
                listUser.Add(new UserBaseModel(userBdd));
            }
        }
    }
    public class GroupLiteModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public GroupLiteModel() { }
        public GroupLiteModel(ConnextBusinessLayer.Bdd.GROUP objBdd)
        {
            Id = objBdd.ID_GROUP;
            Label = objBdd.LABEL;
        }

    }
}