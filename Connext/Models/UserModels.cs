using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connext.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AgencyModel Agency { get; set; }
        public string Description { get; set; }
        public UserModel() { }
        public UserModel(ConnextBusinessLayer.Bdd.USER objBdd)
        {
            Id = objBdd.ID_USER;
            FirstName = objBdd.FIRST_NAME;
            Lastname = objBdd.LAST_NAME;
            Email = objBdd.EMAIL;
            Password = objBdd.PASSWORD;
            var agency = objBdd.AGENCY;
            Agency = new AgencyModel(agency);
        }
    }

    public class UserLiteModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AgencyId { get; set; }
        public string AgencyName { get; set; }
        public string Description { get; set; }
        public UserLiteModel() { }
        public UserLiteModel(ConnextBusinessLayer.Bdd.USER objBdd)
        {
            Id = objBdd.ID_USER;
            FirstName = objBdd.FIRST_NAME;
            Lastname = objBdd.LAST_NAME;
            Email = objBdd.EMAIL;
            Password = objBdd.PASSWORD;
            var agency = objBdd.AGENCY;
            AgencyId = agency.ID_AGENCY;
            AgencyName = agency.NAME;
            Description = objBdd.DESCRIPTION;
        }
    }

    public class UserBaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int AgencyId { get; set; }
        public string Description { get; set; }
        public UserBaseModel() { }
        public UserBaseModel(ConnextBusinessLayer.Bdd.USER objBdd)
        {
            Id = objBdd.ID_USER;
            FirstName = objBdd.FIRST_NAME;
            Lastname = objBdd.LAST_NAME;
            Email = objBdd.EMAIL;
            AgencyId = objBdd.ID_AGENCY;
            Description = objBdd.DESCRIPTION;
        }
    }
    public class TokenWithUserBaseModel
    {
        public string token { get; set; }
        public UserBaseModel userInfo { get; set; }
        public TokenWithUserBaseModel(string token, ConnextBusinessLayer.Bdd.USER objBdd)
        {
            this.token = token;
            this.userInfo = new UserBaseModel(objBdd);
        }
    }
    public class TokenModel
    {
        public string token { get; set; }
        public TokenModel(string token)
        {
            this.token = token;
        }
    }
    public class ActionModel
    {
        public int Id { get; set; }
        public string action { get; set; }
        public ActionModel()
        {
        }
    }
}