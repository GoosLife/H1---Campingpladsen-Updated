using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampingpladsenAuthorization
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["CampingpladsenAuthorization"] != null)
            {
                navbar_adminPanelLink.Visible = true;
            }
        }
    }
}