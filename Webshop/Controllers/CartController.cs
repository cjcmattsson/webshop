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

namespace Webshop.Controllers
{
    public class CartController : Controller
    {
        private readonly string connectionString;

        public CartController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public IActionResult Index() 
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var cart = connection.Query<CartProductModel>("select * from cart").ToList();
                return View(cart);
            }
        }

        [HttpGet]
        public IActionResult Add(string Id)
        {
                using (var connection = new MySqlConnection(this.connectionString))
                {
                    var addToCartQuery = "INSERT INTO cart (product_id, product_name, product_price) SELECT id, name, price FROM things WHERE id = @id";

                    connection.Execute(addToCartQuery, new
                    {
                        id = @Id
                       
                    });

                }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Remove(string Id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var addToCartQuery = "DELETE FROM cart WHERE id = @id";

                connection.Execute(addToCartQuery, new
                {
                    id = @Id

                });

            }
            return RedirectToAction("Index");

        }
    }
}
