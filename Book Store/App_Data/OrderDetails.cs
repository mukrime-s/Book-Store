using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final
{
    public class OrderDetails 
    {
        public int OrderDetailsID;
        public string OrderDate;
        public string OrderProductName;
        public string OrderProductQuantity;
        public int OrderProductPrice;
        public int ProductID;
        public int OrderID;

        public OrderDetails(int OrderDetailsID, string OrderDate, string OrderProductName,
        string OrderProductQuantity, int OrderProductPrice,int ProductID, int OrderID)
        {
            this.OrderDetailsID = OrderDetailsID;
            this.OrderDate = OrderDate;
            this.OrderProductName = OrderProductName;
            this.OrderProductQuantity = OrderProductQuantity;
            this.OrderProductPrice = OrderProductPrice;
            this.ProductID = ProductID;
            this.OrderID = OrderID;
        }
    }
}