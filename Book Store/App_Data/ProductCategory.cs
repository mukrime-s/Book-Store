using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final
{
    public class ProductCategory
    {
        public int ProductCategoryID;
        public string ProductCategoryName;

        public ProductCategory(int ProductCategoryID, string ProductCategoryName)
        {
            this.ProductCategoryID = ProductCategoryID;
            this.ProductCategoryName = ProductCategoryName;
        }
    }
}