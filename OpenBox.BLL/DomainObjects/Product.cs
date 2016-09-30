using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBox.BLL
{
    public class Product
    {

        public int productId { get; internal set; }

        public int brandId { get; internal set; }

        public string sku { get; internal set; }

        public string details { get; internal set; }

        public string imageURL { get { return $"http://media.cymaxstores.com/Images/{brandId}/{productId}-L.jpg"; } }

        public static Product ConvertFromDAL(object dal)
        {
            return ObjectMapping.ConvertToProduct(dal);
        }

    }
}
