using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ConnextBusinessLayer.Bdd;

namespace Connext.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public CategoryModel() { }
        public CategoryModel(ConnextBusinessLayer.Bdd.CATEGORY objBdd)
        {
            Id = objBdd.ID_CATEGORY;
            Label = objBdd.TITLE;
            Description = objBdd.DESCRIPTION;
        }

    }
}