using System;

namespace Webshop.Project.Core.Models

{
    public class CartProductModel
    {
        public int cart_item_id { get; set; }
        public int product_id { get; set; }
        public int amount { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }
}