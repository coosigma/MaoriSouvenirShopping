using System;
using System.Collections.Generic;


namespace MaoriSouvenirShopping.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string FullName
        {
            get { return FirstName+" "+LastName; }
        }

        public ICollection<Souvenir> Souvenirs { get; set; }
    }
}
