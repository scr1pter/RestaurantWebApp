using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebApp.ViewModel
{
    //η αναπαρασταση του πινακα PaymentType σε C#, περιεχει τις στηλες του πινακα και δινει το Id του τροπου πληρωμης και τον τροπο(cash or credit)
    public class PaymentTypeViewModel
    {
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
    }
}