using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ConnextBusinessLayer.Bdd;

namespace Connext.Models
{
    public class PublicationModel : PublicationLiteModel
    {
        public UserBaseModel User { get; set; }
        public GroupLiteModel Group { get; set; }
        public CategoryModel Category { get; set; }
        public PublicationModel() { }
        public PublicationModel(ConnextBusinessLayer.Bdd.PUBLICATION objBdd)
        {
            Id = objBdd.ID_PUBLICATION;
            Group = new GroupLiteModel(objBdd.GROUP);
            Title = objBdd.TITLE;
            Description = objBdd.DESCRIPTION;
            Category = new CategoryModel(objBdd.CATEGORY);
            User = new UserBaseModel(objBdd.USER);
        }
    }

    public class PublicationLiteModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PublicationLiteModel() { }
        public PublicationLiteModel(ConnextBusinessLayer.Bdd.PUBLICATION objBdd)
        {
            Id = objBdd.ID_PUBLICATION;
            Title = objBdd.TITLE;
            Description = objBdd.DESCRIPTION;
        }
    }
}