using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TropicalServer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private HttpCookie _usercookie;
        protected void Page_Load(object sender, EventArgs e)
        {
            _usercookie = new HttpCookie("userLogin");
        }

        protected void loginClk(object sender, EventArgs e)
        {
            //_usercookie["user"] = 
        }
    }
}