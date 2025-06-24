using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OsusTattoo.Models;

namespace OsusTattoo.WebApp.Models
{
    public class CheckoutViewModel
    {
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public UserDeliveryInfo UserDeliveryInfo { get; set; }
        public CartModel Cart { get; set; } //Get cart items
    }

    public class UserDeliveryInfo 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public bool SaveUserDeliveryInfo { get; set; }
    }
}