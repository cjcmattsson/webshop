using System;

namespace Webshop.Models

{
    public class CartProductModel
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }
}