using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osus.Core.Enums;

namespace Osus.Core
{
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreationDateTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public long? TrackingNumber { get; set; }
        public int? UserId { get; set; }
        public int? ProductVariationId { get; set; }
        public string SessionId { get; set; }
        public UserAddress UserAddress { get; set; }
    }
}
