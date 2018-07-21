using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop_API.Models.ViewModels
{
    public class BookList
    {
        public int BookID { get; set; }


        public string Title { get; set; }

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
        public string ISBN { get; set; }


        public string Author { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }
    }
}