using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_Maintenance : System.Web.UI.Page
{
    //creating instance of Bank class
   public Bank hBos = new Bank();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //start of if
        // if no session variable exists for HBos
        if (Session["HBos"] == null)
        {
            hBos = new Bank();
        }
        else
        {

            hBos = (Bank)Session["HBos"];
        }


                

        //using getters to set label values to that in bank class
        lblExRate.Text = Convert.ToString(hBos.getexchange());
        lblAtmUsed.Text = Convert.ToString(hBos.gettimesused());
        lblFailedLogins.Text = Convert.ToString(hBos.getfailedlogins());
        lblBalanceAvailable.Text = Convert.ToString(hBos.gettotalbalance());
        lblCards.Text = Convert.ToString(hBos.getcards());
        lblId.Text = Convert.ToString(hBos.getatmid());
        lblTotalWithdrawls.Text = Convert.ToString(hBos.getwithdrawls());

        Session.Add("HBos", hBos);
    }

    protected void btnRate_Click(object sender, EventArgs e)
    {
       

        //initialisng variable amount
        decimal amount;

        //setting amount to value input in txtRate
        amount = Convert.ToDecimal(txtRate.Text);

        //using setter to set exchange rate to amount entered in Text box
        hBos.setexhange(amount);
        
        //displaying new exchange rate in lblExRate
        lblExRate.Text = Convert.ToString(amount);

        hBos.setexhange(amount);

        Session.Add("HBos", hBos);
    }

    
}