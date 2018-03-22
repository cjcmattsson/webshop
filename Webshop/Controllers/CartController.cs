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
            var cartId = Request.Cookies["CartID"];

            using (var connection = new MySqlConnection(this.connectionString))
            {
                var cart = connection.Query<CartProductModel>("select * from cart LEFT JOIN things ON cart.product_id=things.id WHERE cart_id = @cartId", new {cartId}).ToList();
                return View(cart);
            }
        }



        [HttpGet]
        public IActionResult Add(string Id)
        {
            var cartId = Request.Cookies["CartID"];
            
                using (var connection = new MySqlConnection(this.connectionString))
                {
                
             
                var addToCartQuery = "INSERT INTO cart (product_id, cart_id) VALUES(@id, @cartId)";

                    connection.Execute(addToCartQuery, new { Id ,cartId });

                }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Remove(string Id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var addToCartQuery = "DELETE FROM cart WHERE id = @id";

                connection.Execute(addToCartQuery, new {Id});

            }
            return RedirectToAction("Index");

        }
    }
}
