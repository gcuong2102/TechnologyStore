using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyStore.Models.EF;
using TechnologyStore.Models.ViewModel;

namespace TechnologyStore.Models.DataAccess
{
    public class DataAccess
    {
        DbContextStore db;
        public DataAccess()
        {
            db = new DbContextStore();
        }
        public IEnumerable<ProductsViewModel> GetProduct(string categoryName,string productName,string brandName, decimal? price)
        {
            var products = (from p in db.Products
                           join pc in db.Product_Categories on p.id equals pc.product_id
                           join c in db.Categories on pc.category_id equals c.Id
                           join b in db.Brands on p.brand_id equals b.id
                           where (string.IsNullOrEmpty(categoryName) || c.Name.Contains(categoryName)) &&
                      (string.IsNullOrEmpty(productName) || p.name.Contains(productName)) &&
                      (string.IsNullOrEmpty(brandName) || b.name.Contains(brandName))
                           select new ProductsViewModel
                           {
                               ID = p.id,
                               Name = p.name,
                               BrandName = b.name,
                               Quantity = p.quantity,
                               ImageLink = p.images_link,
                               Price = p.price
                           }).ToList();
            return products;
        }
        public void AddCategoriesToProducts(IEnumerable<ProductsViewModel> products) 
        {
            foreach (var product in products)
            {
                var listCategories = new DataAccess().GetListCategoriesForProducts(product.ID);
                var listCate = new List<Category>();
                if (listCategories.Count() > 0)
                {
                    foreach (var item in listCategories)
                    {
                        listCate.Add(item);
                    }
                }
                product.ListCategories = listCate;
            }
        }
        public IEnumerable<Category> GetListCategoriesForProducts(int idProduct)
        {
            List<Category> model = new List<Category>();
            var categories = db.Product_Categories.Where(x => x.product_id == idProduct).ToList();
            foreach(var category in categories)
            {
                model.Add(db.Categories.Find(category.category_id));
            }
            return model;
        }
        public List<Category> GetListCategoriesForViewBag()
        {
            return db.Categories.OrderBy(x=>x.Name).ToList();
        }
        public List<Brands> GetListBrandForViewBag()
        {
            return db.Brands.OrderBy(x => x.name).ToList();
        }
    }
}