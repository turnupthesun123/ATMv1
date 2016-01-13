using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//John McNaughton
//14/01/2015

public partial class Customer_ViewBalance : System.Web.UI.Page
{
    //initialising variables
    Bank hBos = new Bank();
    string login = "";
    string pin = "";
    
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
       
        //initialisng session variables.
        login = Convert.ToString(Session["login"]);
        pin = Convert.ToString(Session["pin"]);
        hBos = (Bank)Session["HBos"];

        //creating an instance of account
        Account anAccount = new Account();

        //setting aCustomer to equal the desired customer
        var aCustomer = hBos.getBankCustomer()[login];

        //setting anAccount to equal desired customers account.
        anAccount = aCustomer.getAccount(pin);
        
        //displaying account number, name, and balance
        lblAcc.Text = Convert.ToString(anAccount.getaccountNumber());

        lblName.Text = Convert.ToString(aCustomer.getforename() + " " + aCustomer.getsurname());

        lblBal.Text = Convert.ToString(hBos.getBalance(login, pin));

        Session.Add("HBos", hBos);
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        //redirect to index page.

        Response.Redirect("..\\Index.aspx");
    }
}