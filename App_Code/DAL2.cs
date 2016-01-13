using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
//used to store information as a data table
using System.Configuration;
using System.Data;


//John McNaughton
//13/01/2015
//Uses Access data table to populate dictionary

public class DAL2//start if class
{
    //intialising variables.
    private string connStr;
    private OleDbConnection conn;
    private OleDbCommand comm;
    private Dictionary<string, Manager> bankManagers;
    private Dictionary<string, Customer> bankCustomers;

    //getters for manager and customer
    public Dictionary<string, Manager> getBankManagers()
    {
        return bankManagers;
    }
    public Dictionary<string, Customer> getBankCustomers()
    {
        return bankCustomers;
    }

    //constructor setting default values.
    public DAL2()
	{
        connStr = ConfigurationManager.ConnectionStrings["JohnMcNaughtonDB"].ConnectionString;
        conn = new OleDbConnection(connStr);
		bankManagers = new Dictionary<string,Manager>();
        bankCustomers = new Dictionary<string,Customer>();

        
	}//end of DAL2 constructor.

    public DataTable retrieveAllPersonData()
    {
        string myQuery = "SELECT * FROM Person";
        var myConnection = new OleDbConnection(connStr);
        var myCommand = new OleDbCommand(myQuery, myConnection);

        //getting and storing results
        OleDbDataReader myResults;
        DataTable myDataTable = new DataTable();

        //Takes everything from "myResults" and puts in datatable
        //try catch is used to execute problematic code which could produce and error
        //and cause program to crash
        //if this code is placed in "try" and there is an error system will not crash
        //parenthesis after catch are used to decide which exception type to catch

        try
        {
            //opening connection
            myConnection.Open();
            myResults = myCommand.ExecuteReader();

            //if the query as any results
            //load into data table
            //else return empty data table

            if (myResults.HasRows == true)
            {
                myDataTable.Load(myResults);
            }

            return myDataTable;

        }//end of Try

        catch (Exception e)
        {
            return myDataTable;
        }//end of Catch

        //executed after try and catch have finished
        finally 
        {
            //closing connection
            //removing all traces from memory

            myConnection.Close();
            myCommand.Dispose();


        }//end of "finally"
       
    }// end of retrieve all persons data method.

    public DataTable retrieveAllAccountData()
    {
        //initialising variables.
        string myQuery = "SELECT * FROM Account";
        var myConnection = new OleDbConnection(connStr);
        var myCommand = new OleDbCommand(myQuery, myConnection);

        //getting and storing results
        OleDbDataReader myResults;
        DataTable myDataTable = new DataTable();

        //Takes everything from "myResults" and puts in datatable
        //try catch is used to execute problematic code which could produce and error
        //and cause program to crash
        //if this code is placed in "try" and there is an error system will not crash
        //parenthesis after catch are used to decide which exception type to catch

        try
        {
            //opening connection
            myConnection.Open();
            myResults = myCommand.ExecuteReader();

            //if the query as any results
            //load into data table
            //else return empty data table

            if (myResults.HasRows == true)
            {
                myDataTable.Load(myResults);
            }

            return myDataTable;

        }//end of Try

        catch (Exception e)
        {
            return myDataTable;
        }//end of Catch

        //executed after try and catch have finished
        finally
        {
            //closing connection
            //removing all traces from memory

            myConnection.Close();
            myCommand.Dispose();


        }//end of "finally"

    }//end of retrieveAllAccountData method

    //start if loadAllPersonData Method
    //loads data from database into datatables
    public void loadAllPersonData()
    {
        //initialising variables.
        DAL2 myDB;
        DataTable personTable;
        DataTable accountTable;

        //setting variable values
        myDB = new DAL2();
        personTable = myDB.retrieveAllPersonData();
        accountTable = myDB.retrieveAllAccountData();

        //start of for loop
        //iterates through each row in the table and poplulates 'persontable' with values in
        //bank.accdb
        for( int i =0; i <= personTable.Rows.Count -1; i++)
        {
            //setting variables values using data from table.

            string id = Convert.ToString(personTable.Rows[i][0]);

            string fname = Convert.ToString(personTable.Rows[i][1]);

            string sname = Convert.ToString(personTable.Rows[i][2]);

            string address = Convert.ToString(personTable.Rows[i][3]);

            string email = Convert.ToString(personTable.Rows[i][5]);

            string telno = Convert.ToString(personTable.Rows[i][4]);

            string role = Convert.ToString(personTable.Rows[i][6]);

            string machinepin = Convert.ToString(personTable.Rows[i][7]);

            //start of if
            //if role is manager add new manager to table.
            if (role == "M")
            {
                Manager newManager = new Manager (id, fname, sname, address, email, telno, machinepin);
                bankManagers.Add(id, newManager);
            }
            //else if role is customer add new customer to table.
            else if (role == "C")
            {
                Customer newCustomer = new Customer (id, fname, sname, address, email, telno);
                bankCustomers.Add(id, newCustomer);
            }//end of elseif
          

        }//end of for loop.

        //start of for loop 
        //takes data from account table and populates datatable with it
        //iterates through each row
        for (int i = 0; i <= accountTable.Rows.Count - 1; i++)
        {
            string accountNumber = Convert.ToString(accountTable.Rows[i][0]);
            decimal balance = Convert.ToDecimal(accountTable.Rows[i][1]);
            string pin = Convert.ToString(accountTable.Rows[i][2]);
            string id = Convert.ToString(accountTable.Rows[i][3]);

            //creating instance of account class, customer class
            Account newAccount = new Account(accountNumber, balance, pin);
            Customer accountCustomer = bankCustomers[id];
            accountCustomer.addAccount(newAccount);

        }//end of loop

    }//end of method.

}//end of class