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
        public string CategoryName
        {
            get { return Category.CategoryName; }
        }
        public Supplier Supplier { get; set; }
        public string SupplierName
        {
            get { return Supplier.FullName; }
        }

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
