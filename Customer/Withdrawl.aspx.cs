using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_Withdrawl : System.Web.UI.Page
{
    //initialising variables
    Bank hBos = new Bank();
    string login = "";
    string pin = "";
    int amount = 0;
    bool success;
    decimal decimalAmount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        login = Convert.ToString(Session["login"]);
        pin = Convert.ToString(Session["pin"]);
        hBos = (Bank)Session["HBos"];
    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        //if amount box has value in it
        //make amount = value in amount box
        //else make amount = value of selected radio button.
        if (txtAmount.Text != "")
        {
            amount = Convert.ToInt32(txtAmount.Text);
        }else{
            amount = Convert.ToInt32(rdbAmount.SelectedValue);
        }

        //if amount isn't a multiple of 10
        //display error message
        if (amount % 10 != 0)
        {
            lblMessage.Text = "Error - Amount must be a multiple of 10";
        }
        else
        {

            //if Euro is selected
            //divide amount by exchange rate and set decimal amount to result
            //else set decimal amount to amount
            if (rdbCurrency.SelectedValue == "Euro")
            {
                decimalAmount = amount / hBos.getexchange();
            }
            else
            {
                decimalAmount = amount;
            }

            //if withdrawl is unsuccessful display error message
            //else display transaction complete message
            
            success = hBos.withdrawl(login, pin, decimalAmount);
           

            if (success == false)
            {
                lblMessage.Text = "Error - Insufficent funds!";
            }
            else
            {
                lblMessage.Text = "Transaction completed - Take your money";
            }//end of else

        }//end of btnContinue

        //Update Session
        Session.Add("HBos", hBos);
        Session.Add("Amount", decimalAmount);

           if (chkPrintReceipt.Checked == true)
               if(success == true)
        {
            Response.Redirect("Receipt.aspx");
        }
    } //exits to index page

   

    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("..\\Index.aspx");
    }
    protected void chkPrintReceipt_CheckedChanged(object sender, EventArgs e)
    {
     
    }
}//end Customer withdrawl class