using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lBtnStartup_Click(object sender, EventArgs e)
    {
        //redirects to index page
        //"..\\" goes back a level
        Response.Redirect("..\\Index.aspx");
    }

    protected void lBtnMaintenance_Click(object sender, EventArgs e)
    {
        Response.Redirect("Maintenance.aspx");
    }
}
