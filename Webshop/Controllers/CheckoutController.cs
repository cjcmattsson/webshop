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
    public class CheckoutController : Controller
    {
        private readonly string connectionString;

        public CheckoutController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public IActionResult Index(int id)
        {
            var cartId = Request.Cookies["CartID"];
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var checkout = connection.Query<CheckoutViewModel>(
                    "select *, COUNT(product_id) AS amount " +
                    "FROM cart JOIN things ON cart.product_id=things.id WHERE " +
                    "cart_id = @cartId GROUP BY product_id", new { cartId }).ToList();


                return View(checkout);
            }
        }

        [HttpPost]
        public IActionResult Pay(string name, string address, int creditcard, int cost)
        {
            //var cartId = Request.Cookies["CartID"];

            using (var connection = new MySqlConnection(this.connectionString))
            {

                var payProducts = "INSERT INTO orders (customer_name, address, creditcard, cost) VALUES(@name, @address, @creditcard, @cost)";

                connection.Execute(payProducts, new { 
                    name = @name,
                    address = @address, 
                    creditcard = @creditcard,
                    cost = @cost
                });

            }
            return RedirectToAction("Index");

        }


    }
}
