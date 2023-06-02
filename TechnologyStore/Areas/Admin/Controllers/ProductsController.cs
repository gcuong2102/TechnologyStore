using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyStore.Models.DataAccess;
using TechnologyStore.Models.ViewModel;

namespace TechnologyStore.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        public ActionResult Index(string categoryName, string productName, string brandName, decimal? price, int page =1 , int pageSize =  5)
        {

            ViewBag.CurrentPage = page;
            IEnumerable<ProductsViewModel> listProducts = new DataAccess().GetProduct(categoryName,productName,brandName,price);
            int totalItem = listProducts.Count();
            int maxPage = (int)Math.Ceiling((double)totalItem / pageSize);
            var model = listProducts.Skip((page - 1)*pageSize).Take(pageSize).ToList();
            ViewBag.TotalPage = maxPage;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NewProductsViewModel product)
        {
            return View();
        }
    }
}