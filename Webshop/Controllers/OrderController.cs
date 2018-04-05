using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;
using MySql.Data.MySqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Webshop.Project.Core.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webshop.Controllers
{
    public class OrderController : Controller
    {
        private readonly string connectionString;

        public OrderController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public IActionResult Index(int id)
        {
            var cartId = Request.Cookies["CartID"];
            Guid guid = Guid.NewGuid();
            Response.Cookies.Append("CartID", guid.ToString());
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var order = connection.Query<OrderViewModel>(
                    "SELECT * FROM orders WHERE cart_id = @cartId", new { cartId }).ToList();
                
                return View(order);
            }
        }

        [HttpPost]
        public IActionResult Pay(string name, string address, int creditcard, int cost)
        {
            var cartId = Request.Cookies["CartID"];


            using (var connection = new MySqlConnection(this.connectionString))
            {

                var payProducts = "INSERT INTO orders (customer_name, address, creditcard, cost, cart_id) VALUES(@name, @address, @creditcard, @cost, @cartId)";

                connection.Execute(payProducts, new
                {
                    name = @name,
                    address = @address,
                    creditcard = @creditcard,
                    cost = @cost,
                    cartId
                }); 

            }
           
            return RedirectToAction("Cart");
        }


        [HttpGet]
        public IActionResult Cart(int id)
        {
            var cartId = Request.Cookies["CartID"];

            using (var connection = new MySqlConnection(this.connectionString))
            {

                var cartProducts = 
                    "INSERT INTO orderinfo (order_id, cat_battle_armor, cage_face_mug, unicorn, prosecco_pong)" +
                    " VALUES(@cartId, " +
                    "(select COUNT(name) FROM cart JOIN things ON cart.product_id=things.id WHERE name='Cat Battle Armor' AND cart_id=@cartId), " +
                    "(select COUNT(name) FROM cart JOIN things ON cart.product_id=things.id WHERE name='Nicolas Cage Face Mug' AND cart_id=@cartId), " +
                    "(select COUNT(name) FROM cart JOIN things ON cart.product_id=things.id WHERE name='Giant Inflatable Unicorn' AND cart_id=@cartId), " +
                    "(select COUNT(name) FROM cart JOIN things ON cart.product_id=things.id WHERE name='Prosecco Pong' AND cart_id=@cartId)" +
                    ")";
                connection.Execute(cartProducts, new
                {
                    cartId = @cartId,
                });

            }
            return RedirectToAction("Index");

        }

    }
}
