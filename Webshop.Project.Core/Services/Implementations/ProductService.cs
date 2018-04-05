using System;
using System.Collections.Generic;
using Webshop.Project.Core.Models;
using Webshop.Project.Core.Repositories;
using Webshop.Project.Core.Repositories.Implementations;

namespace Webshop.Project.Core.Services.Implementations
{
    public class ProductService : IProductRepository
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<ProductsViewModel> GetAll()
        {
            return productRepository.GetAll();
        }

        public ProductsViewModel singleProduct(string Id)
        {
            return productRepository.singleProduct(Id);
        }
    }
}
