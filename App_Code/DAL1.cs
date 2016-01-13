using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//John McNaughton
//16/12/2014

//start of class
public class DAL1
{
    //loading manager information into dictionary
    public Dictionary<String, Manager> loadManagers() {
        Manager aManager;
        Dictionary<String, Manager> managers = new Dictionary<String, Manager>();
        aManager = new Manager("11111", "Danny", "McGuire", "1 High St", "07944123456", "a@b.com", "12345");
        managers.Add(aManager.getid(), aManager);
        aManager = new Manager("22222", "David", "Drouin", "1 Low St", "07941222222", "b@c.com", "2222");
        managers.Add(aManager.getid(), aManager);
        return managers;
    }//end of load managers function

    // loading customer information into dictionary
public Dictionary<String, Customer>loadCustomers () { 
        Customer aCustomer;
        Account anAccount; 
	Dictionary<String,Customer> Customers = new Dictionary<String,Customer>();

        aCustomer = new Customer( "1234567","Mike", "O'Neill", "1 King St", "07944123456", "a@b.com");
        anAccount = new Account("11111111", 1000, "1111");
        aCustomer.addAccount(anAccount);
        anAccount = new Account("22222222", 2000, "2222");
        aCustomer.addAccount(anAccount);
        Customers.Add(aCustomer.getid(), aCustomer);

        aCustomer = new Customer("3333333","Greg", "Moffat", "1 Princes St", "07941555666", "b@c.com");

        Customers.Add(aCustomer.getid(), aCustomer);
	return Customers;

	}//end of load customers function




	public DAL1()
	{
		



	}
}//end of class