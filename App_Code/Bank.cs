using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//john mcnaughton
//10/12/2014
//Definition of bank class with methods to identify manager from ID an customers account balance

//start of bank class
public class Bank
{
    //declaring attributes
    private string atmid;
    private int cards;
    private decimal exchange;
    private int failedlogins;
    private int timesused;
    private decimal totalbalance;
    private decimal withdrawls;
    private Dictionary<string, Manager> bankManager;
    private Dictionary<string, Customer> bankCustomer;



    //getters
    public string getatmid()
    {
        return atmid;
    }
    public int getcards()
    {
        return cards;
    }
    public decimal getexchange()
    {
        return exchange;
    }
    public int getfailedlogins()
    {
        return failedlogins;
    }
    public int gettimesused()
    {
        return timesused;
    }
    public decimal gettotalbalance()
    {
        return totalbalance;
    }
    public decimal getwithdrawls()
    {
        return withdrawls;
    }

    //getters for dictionarys
    public Dictionary<string, Manager> getBankManager()
    {
        return bankManager;
    }
    public Dictionary<string, Customer> getBankCustomer()
    {
        return bankCustomer;
    }

    //setters

    public void setatmid(string atmidIn)
    {
        atmid = atmidIn;
    }
    public void setcards(int cardsIn)
    {
        cards = cardsIn;
    }
    public void setexhange(decimal exchangeIn)
    {
        exchange = exchangeIn;
    }
    public void setfailedlogins(int failedloginsIn)
    {
        failedlogins = failedloginsIn;
    }
    public void settimesused(int timesusedIn)
    {
        timesused = timesusedIn;
    }
    public void settotalbalance(decimal totalbalanceIn)
    {
        totalbalance = totalbalanceIn;
    }
    public void setwithdrawls(decimal withdrawlsIn)
    {
        withdrawls = withdrawlsIn;
    }

   //setters for dictionary
    public void setBankManager(Dictionary<string, Manager> bankManagerIn)
    {
        bankManager = bankManagerIn;
    }
    public void setBankCustomer(Dictionary<string, Customer> bankCustomerIn)
    {
        bankCustomer = bankCustomerIn;
    }

    //populating customer dictionary
    public void addCustomer(Customer aCustomer)
    {
        bankCustomer.Add(aCustomer.getid(), aCustomer);

        if (!bankCustomer.ContainsKey(aCustomer.getid()))
        {
            bankCustomer.Add(aCustomer.getid(), aCustomer);
        }//end of if statement

    }//end of addCustomer

    // searching manager dictionary
    public Manager getManager(string inputPin)
    {
        //initialising variable
        Manager aManager = new Manager();

        //for each manager in dictionary if the machinepin matches that entered
        //set aManager to current dictionary value
        foreach (KeyValuePair<string, Manager> currentManager in bankManager)
        {
            if (currentManager.Value.getmachinepin() == inputPin)
            {
                aManager = currentManager.Value;
            }//end of if statement

        }//end of for each

        return aManager;
    }//end of method


    //finding customers and their account balance.
    public decimal getBalance(string idIn, string inputPin)
    {
        //initialising variables
        Customer aCustomer = new Customer();
        Account anAccount = new Account();
        decimal balance = 0;

        //start of for each loop
        //checking dictionary for customer with input ID
        //setting aCustomer to the customer in the dictionary with matching ID
        foreach (KeyValuePair<string, Customer> currentCustomer in bankCustomer)
        {
            if (currentCustomer.Value.getid() == idIn)
            {
                aCustomer = currentCustomer.Value;
            }
        }

        //setting anAccount to equal aCustomers account
        anAccount = aCustomer.getAccount(inputPin);

        //setting balance to equal that balance for aCustomers Account
        balance = anAccount.getBalance();

        return balance;
    }

    //valid customer login function
    //search customer dictionary
    //if account number and pin match customer login is set to true
    public bool isValidAccountLogin(string login, string inputPin)
    {
        bool validLogin;

        validLogin = false;

        foreach (KeyValuePair<string, Customer> currentCustomer in bankCustomer)
        {
            if (currentCustomer.Key == login && currentCustomer.Value.checkPin(inputPin))
            {
                validLogin = true;
            }//end if

        }//end foreach


        return validLogin;
    }

    //valid manager login
    //search manager dictionary
    //if login and machine pin match manager login is set to true
    public bool isValidManagerLogin(string login, string inputPin)
    {
        bool validLogin;

        validLogin = false;


        foreach (KeyValuePair<string, Manager> currentManager in bankManager)
        {
            if (currentManager.Key == login && currentManager.Value.getmachinepin() == inputPin)
            {
                validLogin = true;
            }//end if
        }//end for each
        
        return validLogin;
}// end isValidManagerLogin

    public bool withdrawl(string login, string inputPin, decimal amount)
    {
        bool success= false;
        Customer aCustomer = new Customer();
        Account anAccount = new Account();


        foreach (KeyValuePair<string, Customer> currentCustomer in bankCustomer)
        {
            if (currentCustomer.Key == login)
            {
                aCustomer = currentCustomer.Value;
                anAccount = aCustomer.getAccount(inputPin);
            }
        }
        
            success = anAccount.debit(amount);

            if (success == true)
            {
               totalbalance = (totalbalance - amount);
               withdrawls = (withdrawls + amount);
            }
               

        return success;
    }//end of function

    ////Constructor for the bank class- initalises instance variables
    //public Bank()
    //{
    //    //creating an instance of DAL1
    //    DAL1 dbAccess = new DAL1();

    //    bankManager = new Dictionary<string, Manager>();
    //    bankCustomer = new Dictionary<string, Customer>();
    //    bankManager = dbAccess.loadManagers();
    //    bankCustomer = dbAccess.loadCustomers();

    //    atmid = "HBOS01";

    //    exchange = 1.12M;

    //    timesused = 0;

    //    withdrawls = 0;

    //    totalbalance = 10000;

    //    failedlogins = 0;

    //    cards = 0;

    //}// end of constructor

    public Bank()
    {

        //creating an instance of DAL1
        DAL2 dbAccess = new DAL2();

        bankManager = new Dictionary<string, Manager>();
        bankCustomer = new Dictionary<string, Customer>();

        dbAccess.loadAllPersonData();

        bankManager = dbAccess.getBankManagers();
        bankCustomer = dbAccess.getBankCustomers();

        atmid = "HBOS01";

        exchange = 1.12M;

        timesused = 0;

        withdrawls = 0;

        totalbalance = 10000;

        failedlogins = 0;

        cards = 0;

    }// end of constructor

    //Start of loadData method
    //loads customer data from database
    public void loadData()
    {
        DAL1 dbAccess = new DAL1();

        bankCustomer = dbAccess.loadCustomers();
        bankManager = dbAccess.loadManagers();

    }//end of method
}//end of class