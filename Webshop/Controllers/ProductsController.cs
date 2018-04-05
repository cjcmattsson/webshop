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
using Webshop.Project.Core.Services.Implementations;
using Webshop.Project.Core.Repositories.Implementations;
using System.Data.SqlClient;
using Webshop.Project.Core.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly string connectionString;
        private ProductService productService;

        public IActionResult Index()
        {
            List<ProductsViewModel> products = productService.GetAll();
            return View(products);

        }

        public ProductsController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            productService = new ProductService(new ProductRepository(this.connectionString));
        }

        public IActionResult SingleProduct(string Id)
        {
            var singleProduct = this.productService.singleProduct(Id);
            return View(singleProduct);
        }
    }
}
