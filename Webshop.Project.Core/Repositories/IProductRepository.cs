using System;
using System.Collections.Generic;
using Webshop.Project.Core.Models;

namespace Webshop.Project.Core.Repositories
{
    public interface IProductRepository
    {
        List<ProductsViewModel> GetAll();
        ProductsViewModel singleProduct(string Id);
    }
}
