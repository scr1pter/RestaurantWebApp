using RestaurantWebApp.Models;
using RestaurantWebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebApp.Repositories
{
    public class OrderRepository
    {
        private RestaurantDBEntities objRestaurantDBEntities;
        //constructor
        public OrderRepository()
        {
            objRestaurantDBEntities = new RestaurantDBEntities();

        }

        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            //εκχωρω στο αντικειμενο objOrder απο το αντικειμενο της παραμετρου αντιστοιχα σε καθε property την τιμη που πρεπει
            Order objOrder = new Order();
            objOrder.CustomerId = objOrderViewModel.CustomerId;
            objOrder.FinalTotal = objOrderViewModel.FinalTotal;
            objOrder.OrderDate = DateTime.UtcNow;
            objOrder.OrderId = objOrderViewModel.OrderId;
            objOrder.PaymentTypeId = objOrderViewModel.PaymentTypeId;

            //τωρα προσθετω το παραπανω αντικειμενο στον πινακα Orders της βασης, δηλαδη προσθετω την παραγγελια
            objRestaurantDBEntities.Orders.Add(objOrder);
            //αποθηκευω τις αλλαγες στη βαση
            objRestaurantDBEntities.SaveChanges();
            int orderId = objOrder.OrderId;

            //το property List του αντικειμενου της παραμετρου κραταει ολα τα δεδομενα που πρεπει να εκχωρησω στο αντικειμενο OrderDetails για καθε ξεχωριστο item που υπαρχει στην παραγγελια
            foreach(var orderDetail in objOrderViewModel.ListOfOrderDetailViewModel)
            {
                OrderDetail objOrderDetail = new OrderDetail();
                objOrderDetail.OrderId = orderId;
                objOrderDetail.ItemId = orderDetail.ItemId;
                objOrderDetail.Total = orderDetail.Total;
                objOrderDetail.PricePerUnit = orderDetail.PricePerUnit;
                objOrderDetail.Quantity = orderDetail.Quantity;

                //προσθετω το αντικειμενο στον πινακα OrderDetails της βασης
                objRestaurantDBEntities.OrderDetails.Add(objOrderDetail);
                //αποθηκευω τις αλλαγες στη βαση
                objRestaurantDBEntities.SaveChanges();

                //εκχωρω τα δεδομενα που χρειαζονται στο αντικειμενο objTransaction για να υπαρχουν οι πληροφοριες της συναλλαγης για καθε item. Αυτο γινεται για καθε item σε περιπτωση που μελλοντικα χρειαστει να ενημερωνεται το στοκ του εστιατοριου, οτι πχ δωθηκαν στην παραγγελια αυτη 10 burgers αρα το συνολικο στοκ πρεπει να μειωθει κατα 10
                Transaction objTransaction = new Transaction();
                objTransaction.ItemId = orderDetail.ItemId;
                objTransaction.Quantity = orderDetail.Quantity;
                objTransaction.TransactionDate = DateTime.UtcNow;

                //προσθετω το αντικειμενο στον πινακα Transactions της βασης
                objRestaurantDBEntities.Transactions.Add(objTransaction);
                //αποθηκευω τις αλλαγες στη βαση
                objRestaurantDBEntities.SaveChanges();
            }

            return true;
        }
    }
}