using RestaurantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantWebApp.Repositories
{
    public class ItemRepository
    {
        private RestaurantDBEntities objRestaurantDBEntities;

        public ItemRepository()
        {
            //creating object for the entity
            objRestaurantDBEntities = new RestaurantDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItems = new List<SelectListItem>();

            //γεμιζω την λιστα με τα δεδομενα/εγγραφες που υπαρχουν στον πινακα στη βαση 
            objSelectListItems = (from obj in objRestaurantDBEntities.Items
              select new SelectListItem()
              {
                Text = obj.ItemName,
                Value = obj.ItemId.ToString(),
                Selected = true
              }).ToList();

            return objSelectListItems;
        }
    }
}