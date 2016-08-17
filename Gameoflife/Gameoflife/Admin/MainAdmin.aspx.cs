using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gameoflife.Admin
{
    public partial class MainAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserButton.PostBackUrl = "User.aspx";
            UserTemplateButton.PostBackUrl = "UserTemplates.aspx";
        }
    }
}