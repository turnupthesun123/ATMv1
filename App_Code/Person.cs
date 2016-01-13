using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Person
{

    //global attributes.
    private string id;
    private string forename;
    private string surname;
    private string homeaddress;
    private string telephonenumber;
    private string email;


    //getters
    public string getid()
    {
        return id;
    }
    public string getforename()
    {
        return forename;
    }
    public string getsurname()
    {
        return surname;
    }
    public string gethomeaddress()

    {
        return homeaddress;
    }
    public string gettelephonenumber()
    {
        return telephonenumber;
    }
    public string getemail()
    {
        return email;
    }

    //setters
    public void setid( string idIn)
    {
        id = idIn;
    }
    public void setforename(string fornameIn)
    {
        forename = fornameIn;
    }
    public void setsurname(string surnameIn)
    {
        surname = surnameIn;
    }
    public void sethomeaddress(string homeaddressIn)
    {
        homeaddress = homeaddressIn;
    }
    public void settelephonenumber(string telephonenumberIn)
    {
        telephonenumber = telephonenumberIn;
    }
    public void setemail(string emailIn)
    {
        email = emailIn;
    }
	
    //constructor 0 parameters
    public Person()
	{
        id = "";
        forename = "";
        surname = "";
        homeaddress = "";
        telephonenumber = "";
        email = "";
	}


    //overloaded constructor
    public Person(string idIn, string forenameIn, string surnameIn, string homeaddressIn, string telephonenumberIn, string emailIn)
    {

        id = idIn;
        forename = forenameIn;
        surname = surnameIn;
        homeaddress = homeaddressIn;
        telephonenumber = telephonenumberIn;
        email = emailIn;
        
    }
}