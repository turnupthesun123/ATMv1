using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_Receipt : System.Web.UI.Page
{
    //initialising variables
    Bank hBos = new Bank();
    string login = "";
    string pin = "";
    int withdrawn = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        //start of if
        // if no session variable exists for HBos
        //create session variable
        if (Session["HBos"] == null)
        {
            hBos = new Bank();
        }
        else
        {

            hBos = (Bank)Session["HBos"];
        }

        login = Convert.ToString(Session["login"]);
        pin = Convert.ToString(Session["pin"]);
        hBos = (Bank)Session["HBos"];
        withdrawn = Convert.ToInt32(Session["Amount"]);

         Account anAccount = new Account();

        var aCustomer = hBos.getBankCustomer()[login];

        anAccount = aCustomer.getAccount(pin);
        
        lblAcc.Text = Convert.ToString(anAccount.getaccountNumber());

        lblName.Text = Convert.ToString(aCustomer.getforename() + " " + aCustomer.getsurname());

        lblBalance.Text = Convert.ToString(hBos.getBalance(login, pin));

        lblWithdrawn.Text = Convert.ToString(withdrawn);

        Session.Add("HBos", hBos);
        Session.Add("Amount", withdrawn);
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("..\\Index.aspx");
    }
}