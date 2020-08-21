using RestaurantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantWebApp.Repositories
{
    public class CustomerRepository
    {
        private RestaurantDBEntities objRestaurantDBEntities;

        public CustomerRepository()
        {
            //creating object for the entity
            objRestaurantDBEntities = new RestaurantDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var objSelectListItems = new List<SelectListItem>();
            //γεμιζω την λιστα με τα δεδομενα/εγγραφες που υπαρχουν στον πινακα στη βαση 
            objSelectListItems = (from obj in objRestaurantDBEntities.Customers
                select new SelectListItem()
                {
                    Text = obj.CustomerName,
                    Value = obj.CustomerId.ToString(),
                    Selected = true
                }).ToList();

            return objSelectListItems;
        }
    }
}