using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;
using MySql.Data.MySqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly string connectionString;

        public IActionResult Index()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var products = connection.Query<ProductsViewModel>("select * from things").ToList();
                return View(products);
            }
            //return View(this.products);
        }
        public ProductsController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public IActionResult SingleProduct(string Id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var productsItem = connection.QuerySingleOrDefault<ProductsViewModel>("select * from things where id = @id", new { Id });
                return View(productsItem);
            }
        }

        [HttpPost]
        public ActionResult AddToCart(ProductsViewModel model)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var newsQuery = "INSERT INTO cart (product_id, product_price) SELECT id, price FROM things WHERE id = @Id;";

                connection.Execute(newsQuery, new
                {
                    id = @model.Id,
                    body = @model.Price

                });
                return RedirectToAction("Index");

            }
        }

    }
}
