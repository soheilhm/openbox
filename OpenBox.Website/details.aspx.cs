using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpenBox.Website
{
    public partial class details : System.Web.UI.Page
    {

        protected BLL.Offer offer;

        protected void Page_Load(object sender, EventArgs e)
        {
            int offerId = 0;

            if (int.TryParse(Request.QueryString["Id"], out offerId)) { offer = BLL.OfferManager.Load(offerId); }

            if (offer == null) { Response.Redirect("/index.html", true); }            
        }
    }
}