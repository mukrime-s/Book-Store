using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final
{
    public class Order
    {
        public int OrderIID;
        public int OrderINumber;
        public string OrderDate;
        public string OrderQuantity;
        public int OrderTotalPrice;
        public int CustomerID;

        public Order(int OrderIID, int OrderINumber, string OrderDate, string OrderQuantity, int OrderTotalPrice, int CustomerID) 
        {
            this.OrderIID = OrderIID;
            this.OrderINumber = OrderINumber;
            this.OrderDate = OrderDate;
            this.OrderQuantity = OrderQuantity;
            this.OrderTotalPrice = OrderTotalPrice;
            this.CustomerID = CustomerID;
        }
    }
}