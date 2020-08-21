using RestaurantWebApp.Models;
using RestaurantWebApp.Repositories;
using RestaurantWebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //οταν ανοιγει η εφαρμογη καλειται και δημιουργουνται τα 3 αντικειμενα Customer, Item και Payment
            CustomerRepository objCustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository();

            //καλουνται οι 3 μεθοδοι που επιστρεφουν τα δεδομενα απο την βαση και εκχωρουνται στο tuple για να επιστραφει το model που χρειαζεται στο view. To tuple μου επιτρεπει να περασω διαφορα σετ δεδομενων ταυτοχρονα σε μια μεταβλητη, ενω πριν θα επρεπε να εκανα 3 λιστες
            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(objCustomerRepository.GetAllCustomers(),
                objItemRepository.GetAllItems(), objPaymentTypeRepository.GetAllPaymentTypes());

            return View(objMultipleModels);
        }

        // για καποιο item βρισκει στη βαση την τιμη του και την επιστρεφει, ωστε οταν επιλεγω καποιο item να εμφανιζεται η τιμη του στο view
        [HttpGet]
        public JsonResult GetItemPricePerUnit(int itemId)
        {
            RestaurantDBEntities obj = new RestaurantDBEntities();
            decimal pricePerUnit = obj.Items.FirstOrDefault(item => item.ItemId == itemId).ItemPrice;
            return Json(pricePerUnit, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertToDB(OrderViewModel objOrderViewModel)
        {
            OrderRepository objOrderRepository = new OrderRepository();
            //οταν εχω πατησει το payment τοτε προστιθεται η παραγγελια και γινεται η εισαγωγη στη βαση μεσα στην μεθοδο AddOrder
            objOrderRepository.AddOrder(objOrderViewModel);

            return Json(data: "Order Successfully Placed!", JsonRequestBehavior.AllowGet);
        }
    }
}