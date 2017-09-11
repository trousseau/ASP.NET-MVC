using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsRouting
{
    public partial class Blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblYear.Text = Convert.ToString(RouteData.Values["year"]);
            this.lblMonth.Text = Convert.ToString(RouteData.Values["month"]);
            this.lblDay.Text = Convert.ToString(RouteData.Values["day"]);

        }
    }
}