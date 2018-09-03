using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaoriSouvenirShopping.Models
{
    public class OrderItem
    {
        public int SouvenirID { get; set; }
        public int OrderID { get; set; }
        public int ItemAmount { get; set; }

        public Souvenir Souvenir { get; set; }
        public Order Order { get; set; }
    }
}
