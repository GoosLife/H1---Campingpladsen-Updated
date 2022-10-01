using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampingpladsenAuthorization
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btn_login.ServerClick += new System.EventHandler(this.btn_login_Click);
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            // Check input against database
            string username = text_username.Value;
            string password = text_password.Value;

            if (DbController.AuthorizeUser(username, password))
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, username, DateTime.Now,
                DateTime.Now.AddMinutes(30), false, "admin");
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                Response.Redirect("AdminPanel.aspx");
            }
            else
            {
                // Else, display error message
                lbl_invalidCredentials.Visible = true;
            }
        }
    }
}