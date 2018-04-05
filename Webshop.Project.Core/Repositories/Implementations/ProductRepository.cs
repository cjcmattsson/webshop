using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using Webshop.Project.Core.Models;

namespace Webshop.Project.Core.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly string connectionString;

        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ProductsViewModel> GetAll()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<ProductsViewModel>("select * from things").ToList();
            }
        }

        public ProductsViewModel singleProduct (string Id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<ProductsViewModel>("select * from things where id = @id", new { Id });

            }
        }
    }
}
