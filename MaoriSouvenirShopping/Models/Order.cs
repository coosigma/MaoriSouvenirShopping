using System;
using System.Collections.Generic;


namespace MaoriSouvenirShopping.Models
{
    public enum Status
    {
        Ordered, Billed, Paid, Cancelled
    }
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public Status Status { get; set; }
        public int CustomerID { get; set; }
        public double TotalCost { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
