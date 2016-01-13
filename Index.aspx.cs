using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//John McNaughton
//17/12/2014
//Login page

public partial class Index : System.Web.UI.Page
{
    //declaring variables
    int cardsRetained;
    int timesused;
    int numberoffailedattempts;
    int finalfailedattempts;
    Bank hBos = new Bank();
   


    protected void Page_Load(object sender, EventArgs e)
    {
        //start of if
        // if no session variable exists for HBos
        if (Session["Hbos"] == null)
        {
            hBos = new Bank();
        }
        else
        {

            hBos = (Bank)Session["Hbos"];
        }

        //initialising number of attempts session variable
        numberoffailedattempts = Convert.ToInt32(Session["numberoffailedattempts"]);

        cardsRetained = hBos.getcards();
        timesused = hBos.gettimesused();
        finalfailedattempts = hBos.getfailedlogins();

        //start of if statement
        //checks if manager has logged in
        //if not, disable customer button
        if (Session["HBos"] == null)
        {
            rblChoose.Items[1].Enabled = false;

        }
        else
        {
          rblChoose.Items[1].Enabled = true;

        }
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
      
        //initialising variables, login and pin
        string login = Login1.UserName;
        string pin = Login1.Password;

        //start of if
        //if manager login is successful allow customer login.
        if (rblChoose.Items[0].Selected == true)
        {
            rblChoose.Items[1].Enabled = true;

            if (hBos.isValidManagerLogin(login, pin) == true)
            {
                //updating session variables if manager login is successful
                Session.Add("HBos", hBos);
                Session.Add("login", login);
                Session.Add("pin", pin);

                //redirect to manager page
                Response.Redirect("Manager\\ManagerHome.aspx");
            }
            else
            {
                //display error message
                Login1.FailureText = "Invalid login, try again";
                
            }
        }
       
            //if account login is valid
            //add 1 to times used
        if (hBos.isValidAccountLogin(login, pin) == true)
        {
            timesused++;
            //reset failed attempts to 0
            numberoffailedattempts = 0;
            
            //updating session if login is successful
            Session.Add("HBos", hBos);
            Session.Add("login", login);
            Session.Add("pin", pin);
            Session.Add("numberoffailedattempts", numberoffailedattempts);
            //send to customer home page
            Response.Redirect("Customer\\CustomerHome.aspx");
        }
        else
        {
            //else if login failed
            //add one to session failed attempts
            //add one to overall failed attempts
            //set failed login total to value in final failed attempts
            if (hBos.isValidAccountLogin(login, pin) == false)
            {
                
                numberoffailedattempts++;
                finalfailedattempts++;
                hBos.setfailedlogins(finalfailedattempts);
                Session.Add("numberoffailedattempts", numberoffailedattempts);
                Session.Add("HBos", hBos);
                Session.Add("login", login);
                Session.Add("pin", pin);

                //if failed attempts is under 3 display invalid login message
                //else display retained card message and add 1 to cards retained
                if (numberoffailedattempts < 3)
                {
                    Login1.FailureText = "Invalid login, try again";
                }
                else
                {



                    if (numberoffailedattempts == 3)
                    {
                        Login1.FailureText = "Card retained - contact your branch";
                        cardsRetained++;
                        numberoffailedattempts = 0;
                        Session.Add("numberoffailedattempts", numberoffailedattempts);
                    }


                }

            }

            
            hBos.setcards(cardsRetained);
            hBos.settimesused(timesused);
            Session.Add("Hbos", hBos);
           
            }
                
        }//end of login

    protected void rblChoose_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    }//end of class

    

  
    