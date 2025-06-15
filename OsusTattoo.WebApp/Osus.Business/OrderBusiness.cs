using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osus.Core;
using Osus.Data;

namespace Osus.Business
{
    public class OrderBusiness
    {
        OrderData _orderData;

        public OrderBusiness()
        {
            _orderData = new OrderData();
        }

        public Order LoadOrderByVariantId(int variantId, int? userId, string sessionId)
        {
            return _orderData.LoadOrderByVariantId(variantId, userId, sessionId);
        }

        public bool AddToCart(ProductVariation productVariation)
        {
            return _orderData.AddToCartOrderInsert(productVariation);
        }
    }
}
