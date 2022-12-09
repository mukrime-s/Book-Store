using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final
{
    public class Customer
    {
        public int CustomerID;
        public string CustormerName;
        public string CustormerEmail;
        public string CustormerPhoneNumber;
        public string CustormerPassword;

        public Customer(int CustomerID, string CustormerName, string CustormerEmail, string CustormerPhoneNumber, string CustormerPassword)
        {
            this.CustomerID = CustomerID;
            this.CustormerName = CustormerName;
            this.CustormerEmail = CustormerEmail;
            this.CustormerPhoneNumber = CustormerPhoneNumber;
            this.CustormerPassword = CustormerPassword;
        }
    }
}