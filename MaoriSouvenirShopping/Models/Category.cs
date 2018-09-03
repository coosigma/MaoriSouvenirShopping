using System;
using System.Collections.Generic;


namespace MaoriSouvenirShopping.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public ICollection<Souvenir> Souvenirs { get; set; }
    }
}
