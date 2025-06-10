using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osus.Core;
using Osus.Data;

namespace Osus.Business
{
    public class ProductBusiness
    {
        ProductData _productData;

        public ProductBusiness()
        {
            _productData = new ProductData();
        }

        public List<Product> LoadProduct()
        {
            return _productData.LoadProduct();
        }

        public Product LoadProductByProductId(int productId)
        {
            return _productData.LoadProductbyProductId(productId);
        }
    }
}
