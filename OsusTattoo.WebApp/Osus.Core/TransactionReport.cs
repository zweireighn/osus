using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osus.Core
{
    public class TransactionReport
    {
        public int Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public Order Order { get; set; }
    }
}
