using System;

namespace Webshop.Project.Core.Models

{
    public class CheckoutViewModel
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int amount { get; set; }


        public string id { get; set; }
        public string customer_name { get; set; }
        public string address { get; set; }
        public int creditcard { get; set; }
        public int cost { get; set; }
    }
}