using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBox.BLL
{
    public class Offer
    {
        public int returnDetailId { get; internal set; }

        public string title { get; internal set; }
        
        public decimal price { get; internal set; }

        public int quantity { get; internal set; }

        public int productId { get; internal set; }

        public int brandId { get; internal set; }

        public Guid? bookedBy { get; internal set; }

        public bool sold { get; internal set; }

        public string imageURL { get { return $"http://media.cymaxstores.com/Images/{brandId}/{productId}-L.jpg"; } }

        public string URL { get { return $"/details.aspx?id={returnDetailId}"; } }

        public Product product { get; internal set; }

        public static Offer ConvertFromDAL(object dal)
        {
            return ObjectMapping.ConvertToOffer(dal);
        }

        public string displayTitle { get { return this.title + (quantity > 1 ? $" (Set of {quantity})" : ""); } }

        public bool isBooked(Guid guid) { return bookedBy == null || bookedBy == guid; }
    }
}
