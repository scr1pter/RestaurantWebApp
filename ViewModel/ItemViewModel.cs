using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebApp.ViewModel
{
    //η αναπαρασταση του πινακα Orders σε C#, περιεχει τις στηλες του πινακα
    public class ItemViewModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }

    }
}