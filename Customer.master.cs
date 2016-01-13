using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lBtnWithdraw_Click(object sender, EventArgs e)
    {
        Response.Redirect("Withdrawl.aspx");
        
    }
    protected void lBtnBalance_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewBalance.aspx");
    }
    protected void lBtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerHome.aspx");
    }
}
