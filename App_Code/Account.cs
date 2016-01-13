using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//John McNaughton
//3/12/2014
//holds account holders account number, balance and pin

//start of Account class
public class Account
{
    //global variables
    private string accountNumber;
    private decimal balance;
    private string pin;

    //getters
    public string getaccountNumber()
    {
        return accountNumber;
    }
    public decimal getBalance()
    {
        return balance;
    }
    public string getPin()
    {
        return pin;
    }

    //setters
    public void setAccountNumber(string accountNumberIn)
    {
        accountNumber = accountNumberIn;
    }
    public void setBalance(decimal balanceIn)
    {

        balance = balanceIn;

    }
    public void setPin (string pinIn)
    {
        pin = pinIn;
    }

    //constructor 0 parameters
	public Account()
	{
        accountNumber = "";
        balance = 0;
        pin = "";
	}

    //Overloaded constructor
    public Account(string accountNumberIn, decimal balanceIn, string pinIn)
    {
        accountNumber = accountNumberIn;
        balance = balanceIn;
        pin = pinIn;

    }

    //credits the reciever account with the amount passed as input parameter
    public void credit(decimal amount)
    {
        balance = (balance + amount);

    }//end of method credit

    //debits the reciever account by the amount passed as input parameter. Report success or failure
    public bool debit(decimal amount)
    {
        //setting local variable ok
        bool ok = false;


        if(balance >= amount){//start of if statement

            balance = (balance - amount);
                ok = true;}else{

            ok = false;
        }//end of if statement

        //reports success or failure
        return ok;
    }// end of method debit

}//end of class