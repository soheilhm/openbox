using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBox.BLL
{
    public static class OfferManager
    {

        public static List<Offer> Search(string location, string tags, decimal? priceMin, decimal? priceMax)
        {
            List<dynamic> dal = OpenBox.DAL.DBManager.Offers_Search(location, tags, priceMin, priceMax);
            return ObjectMapping.ConvertToOffers(dal);
        }

        public static Offer Load(int returnDetailId)
        {
            object dal = OpenBox.DAL.DBManager.Offers_Select(returnDetailId);
            if (dal == null) { return null; }

            object offer = dal.GetType().GetProperty("offer").GetValue(dal, null);
            object product = dal.GetType().GetProperty("product").GetValue(dal, null);
            Offer result = Offer.ConvertFromDAL(offer);
            result.product = Product.ConvertFromDAL(product);
            return result;
        }

        public static Guid Book(int returnDetailId)
        {
            return DAL.DBManager.Offers_Book(returnDetailId);
        }

        public static Guid Book(int returnDetailId, string guid)
        {
            return DAL.DBManager.Offers_Book(returnDetailId, Guid.Parse(guid));
        }

        public static int? Buy(int returnDetailId, string guid, Customer customer, Payment transaction)
        {
            return DAL.DBManager.Orders_Insert(returnDetailId, Guid.Parse(guid), customer.GetRecord(), transaction.GetRecord());
        }

    }
}
