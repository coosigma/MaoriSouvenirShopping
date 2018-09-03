﻿using System;
using System.Collections.Generic;


namespace MaoriSouvenirShopping.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
