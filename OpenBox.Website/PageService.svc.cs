using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace OpenBox.Website
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PageService
    {
        [OperationContract]
        public string Offers_Search(string location, string tags, decimal? priceMin, decimal? priceMax)
        {
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();

            List<BLL.Offer> result = BLL.OfferManager.Search(location, tags, priceMin,  priceMax);
            return js.Serialize(result);
        }
    }
}
