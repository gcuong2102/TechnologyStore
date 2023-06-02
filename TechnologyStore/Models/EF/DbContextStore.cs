using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TechnologyStore.Models.EF
{
    public class DbContextStore : DbContext
    {
        // Your context has been configured to use a 'DbContextStore' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TechnologyStore.Models.EF.DbContextStore' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DbContextStore' 
        // connection string in the application configuration file.
        public DbContextStore()
            : base("name=DbContextStore")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Brands> Brands { get; set;}
        public virtual DbSet<Product_Categories> Product_Categories { get; set; }
    }
    [Table("brands")]
    public class Brands
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
    [Table("products")]
    public class Products
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public int brand_id { get; set; }
        public string images_link { get; set; }
        public string description { get; set; }
        public string shortdescription { get; set; }
    }
    [Table("categories")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? parent_id { get; set; }
        public string icon_string { get; set; }
    }
    [Table("customers")]
    // Lớp đại diện cho khách hàng
    public class Customer
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
    }
    [Table("orders")]
    // Lớp đại diện cho đơn hàng
    public class Order
    {
        public int id { get; set; }
        public int customerid { get; set; }
        public DateTime orderdate { get; set; }
        public decimal totalamount { get; set; }
    }
    [Table("oder_items")]
    // Lớp đại diện cho mục đơn hàng (sản phẩm trong đơn hàng)
    public class OrderItem
    {
        public int id { get; set; }
        public int orderid { get; set; }
        public int productid { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    }
    [Table("product_categories")]
    public class Product_Categories
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int category_id { get; set; }
    }

}