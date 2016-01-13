using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//start of customer class, subclass of person
public class Customer:Person
{
    private Dictionary<string, Account> accounts;

    //getter
    //get customer account
    public Dictionary<string, Account> getAccounts()
    {
        return accounts;
    }
    public void setAccounts(Dictionary<string, Account> anAccount)
    {
        accounts = anAccount;
    }

    //constructor 0 parameters
	public Customer():base()
	{
        accounts = new Dictionary<string, Account>();
	}

    //constructor 7 parameters
    public Customer(string idIn, string forenameIn, string surnameIn, string homeaddressIn, string telephonenumberIn, string emailIn,
        Dictionary<string, Account> anAccount): base (idIn, forenameIn, surnameIn, homeaddressIn, telephonenumberIn, emailIn)
    {
        accounts = anAccount;
    }

    //constructor 6 parameters
    //creates an empty account
    public Customer(string idIn, string forenameIn, string surnameIn, string homeaddressIn,
        string telephonenumberIn, string emailIn)
        : base(idIn, forenameIn, surnameIn, homeaddressIn, telephonenumberIn, emailIn)
      {

          accounts = new Dictionary<string, Account>();

      }

    //addAccount function
    //if account is not already present then add account.
    public void addAccount(Account anAccount)
    {
        accounts.Add(anAccount.getaccountNumber(), anAccount);

        if (!accounts.ContainsKey(anAccount.getaccountNumber()))
        {
            accounts.Add(anAccount.getaccountNumber(), anAccount);
        }//end of if
    }//end of add account

    //check pin function
    //if pin matches account number return true
    public bool checkPin(string inputPin)
    {
        bool validPin = false;

        foreach (KeyValuePair<string, Account> anAccount in accounts)
        {
            if (anAccount.Value.getPin() == inputPin)
            {
                validPin = true;
            }//end of if

            
        }//end of for
        return validPin;
    }//end of checkpin

    //get Account method
    public Account getAccount(string inputPin)
    {
        Account anAccount = new Account();

        foreach (KeyValuePair<string, Account> currentAccount in accounts)
        {
            if (currentAccount.Value.getPin() == inputPin)
            {
                anAccount=currentAccount.Value;
            }//end of if

        }//end of foreach

        return anAccount;

    }//end of getAccount

    

}// end of class