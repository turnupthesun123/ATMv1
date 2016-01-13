using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestPerson : System.Web.UI.Page
{
    Person myPerson;

    protected void Page_Load(object sender, EventArgs e)
    {
        myPerson = (Person)Session["current person"];
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string id = txtId.Text;
        string forename = txtForename.Text;
        string surname = txtSurname.Text;
        string homeaddress = txtHomeaddress.Text;
        string telephonenumber = txtTelephoneNumber.Text;
        string email = txtEmail.Text;

        myPerson = new Person(id, forename, surname, homeaddress, telephonenumber, email);

        Session.Add("current person", myPerson);
    }
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        lblId.Text = myPerson.getid();
        lblForename.Text = myPerson.getforename();
        lblSurname.Text = myPerson.getsurname();
        lblHomeAddress.Text = myPerson.gethomeaddress();
        lblTelephoneNumber.Text = myPerson.gettelephonenumber();
        lblEmail.Text = myPerson.getemail();
    }
}