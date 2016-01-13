using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//John McNaughton
//10/12/2014
//defines subclass of manager

//start of class manager subclass for person
public class Manager : Person
{
    //declaring machinepin attribute
    private string machinepin;

    public string getmachinepin()
    {
        return machinepin;
    }
    public void setmachinepin(string machinepinIn)
    {
        machinepin = machinepinIn;
    }

    //constuctor 0 parameters
    public Manager()
        : base()
    {
        machinepin = "";
    }

    //constructor //7 parameters
    public Manager(string idIn, string forenameIn, string surnameIn, string homeaddressIn, string telephonenumberIn, string emailIn,
        string machinepinIn)
        :base(idIn, forenameIn, surnameIn, homeaddressIn, telephonenumberIn, emailIn)
    {
        machinepin = machinepinIn;
    }
}//end of class