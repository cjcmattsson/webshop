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
                
                var cart = connection.Query<CartProductModel>(
                    "select *, COUNT(product_id) AS amount " +
                    "FROM cart JOIN things ON cart.product_id=things.id WHERE " +
                    "cart_id = @cartId GROUP BY product_id", new {cartId}).ToList();
                return View(cart);
            }
        }



        [HttpGet]
        public IActionResult Add(string id)
        {
            var cartId = Request.Cookies["CartID"];
            
                using (var connection = new MySqlConnection(this.connectionString))
                {
                
                var addToCartQuery = "INSERT INTO cart (product_id, cart_id) VALUES(@id, @cartId)";

                    connection.Execute(addToCartQuery, new { id ,cartId });

                }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Remove(string id)
        {
            var cartId = Request.Cookies["CartID"];
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var removeFromCartQuery = "DELETE FROM cart WHERE cart_item_id = @cart_item_id AND cart_id = @cartId LIMIT 1";

                connection.Execute(removeFromCartQuery, new { cart_item_id = id, cartId });

            }
            return RedirectToAction("Index");

        }


    }
}
