using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryFk { get; set; }
        public string ImgName { get; set; }
        public int OrgFk { get; set; }
        public int MenuFk { get; set; }

    }
}