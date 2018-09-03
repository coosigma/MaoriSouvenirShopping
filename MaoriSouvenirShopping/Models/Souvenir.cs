using System;
using System.Collections.Generic;


namespace MaoriSouvenirShopping.Models
{
    public class Souvenir
    {
        public int SouvenirID { get; set; }
        public string SouvenirName { get; set; }
        public double Price { get; set; }
        public string PhotoPath { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }

        public Category Category { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
