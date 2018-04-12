using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using Webshop.Project.Core.Repositories;
using FakeItEasy;
using Webshop.Project.Core.Models;
using Webshop.Project.Core.Repositories.Implementations;
using Webshop.Project.Core.Services.Implementations;

namespace Webshop.Unittest
{
    public class ProductsServiceTest
    {
        private ProductService productService;
        private IProductRepository productRepository;

        [SetUp]
        public void SetUp()
        {
            this.productRepository = A.Fake<IProductRepository>();

            this.productService = new ProductService(this.productRepository);
        }

        [Test]
        public void GetAllProducts_ReturnsProducts()
        {
            //Arrange
            var products = new List<ProductsViewModel>
            {
                new ProductsViewModel()
            };

            A.CallTo(() => this.productRepository.GetAll()).Returns(products);

            // Act
            var result = this.productService.GetAll();

            // Assert
            Assert.That(result, Is.EqualTo(products));

        }

    }

}
