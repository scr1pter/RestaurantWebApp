using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebApp.ViewModel
{
    //η αναπαρασταση του πινακα Customers σε C#, περιεχει τις στηλες του πινακα
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}