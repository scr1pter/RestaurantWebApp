using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebApp.ViewModel
{
    //η αναπαρασταση του πινακα Orders σε C#, περιεχει τις στηλες του πινακα και δινει τις πληροφοριες της καθε παραγγελιας
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int PaymentTypeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal FinalTotal { get; set; }
        //εδω θα περιεχονται για καθε παραγγελια οι λεπτομερειες που χρειαζονται για να γεμισει το model του OrderDetails, το οποιο γεμιζει οταν γινεται η τελικη πληρωμη στο modal
        public IEnumerable<OrderDetailViewModel> ListOfOrderDetailViewModel { get; set; }
    }
}