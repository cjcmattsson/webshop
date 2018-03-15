using System;

namespace Webshop.Models

{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Info { get; set; }
        public int Price { get; set; }
        public string Img { get; set; }
    }
}
