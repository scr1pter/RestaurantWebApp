using RestaurantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantWebApp.Repositories
{
    public class PaymentTypeRepository
    {
        private RestaurantDBEntities objRestaurantDBEntities;

        public PaymentTypeRepository()
        {
            //creating object for the entity
            objRestaurantDBEntities = new RestaurantDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllPaymentTypes()
        {
            var objSelectListItems = new List<SelectListItem>();

            //γεμιζω την λιστα με τα δεδομενα/εγγραφες που υπαρχουν στον πινακα στη βαση 
            objSelectListItems = (from obj in objRestaurantDBEntities.PaymentTypes
              select new SelectListItem()
                {
                  Text = obj.PaymentTypeName,
                  Value = obj.PaymentTypeId.ToString(),
                  Selected = true
                }).ToList();

            return objSelectListItems;
        }
    }
}