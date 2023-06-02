using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyStore.Models.EF;

namespace TechnologyStore.Models.ViewModel
{
    public class ProductsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<Category> ListCategories { get; set; }
        public string ImageLink { get; set; }
    }
    public class NewProductsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Brand_Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<int> ListIdCategories { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }
}