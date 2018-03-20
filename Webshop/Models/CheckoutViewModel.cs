using System;

namespace Webshop.Models

{
    public class CheckoutViewModel
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public int Product_price { get; set; }

        public int Name { get; set; }
        public int Adress { get; set; }
        public string Phone_number { get; set; }
        public int Email_address { get; set; }
    }
}