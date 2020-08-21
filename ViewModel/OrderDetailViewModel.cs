using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebApp.ViewModel
{
    //η αναπαρασταση του πινακα OrderDetails σε C#, περιεχει τις στηλες του πινακα και δινει τις λεπτομερειες της καθε παραγγελιας
    public class OrderDetailViewModel
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal Total { get; set; }
        public int Quantity { get; set; }
    }
}