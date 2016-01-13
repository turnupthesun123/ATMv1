using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestAccount : System.Web.UI.Page
{
    Account myAccount;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        myAccount = (Account)Session["current account"];
    }
    protected void btncreate_Click(object sender, EventArgs e)
    {

        string accountno = txtaccountNo.Text;
        decimal balance = Convert.ToDecimal(txtBalance.Text);
        string pin = txtPin.Text;

        myAccount = new Account(accountno, balance, pin);

        Session.Add("current account", myAccount);

    }
    protected void btnview_Click(object sender, EventArgs e)
    {
        lblaccountNo.Text = myAccount.getaccountNumber();
        lblbalance.Text = Convert.ToString(myAccount.getBalance());
        lblpin.Text = myAccount.getPin();

    }
    protected void btnCredit_Click(object sender, EventArgs e)
    {
        int creditAmount = Convert.ToInt32(txtCredit.Text);
        myAccount.credit(creditAmount);

        Session.Add("current account", myAccount);

    }
    protected void btnDebit_Click(object sender, EventArgs e)
    {
        int debitAmount = Convert.ToInt32(txtDebit.Text);

        if (myAccount.debit(debitAmount) == true)
        {
            lblMessage.Text = "Successful Withdrawl";
        }else{
            lblMessage.Text = "Unsuccessful Withdrawl";
        }

        Session.Add("current account", myAccount);
    }
}