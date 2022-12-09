using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final
{
    public partial class Cart : System.Web.UI.Page
    {
        string firstname, lastname, id;
        List<Product> productList = new List<Product>();
        List<Customer> customerList = new List<Customer>();
        ArrayList SelectedProducts = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["productList"] != null)
            {
                productList = (List<Product>)Session["productList"];//arraylist sessionda tutuluyor
            }
            if (Session["customerList"] != null)
            {
                customerList = (List<Customer>)Session["customerList"];//arraylist sessionda tutuluyor
            }
            if (Session["firstname"] != null)
            {
                firstname = (string)Session["firstname"];//firstname sessionda tutuluyor               
            }
            if (Session["lastname"] != null)
            {
                lastname = (string)Session["lastname"];//lastname sessionda tutuluyor               
            }
            if (this.IsPostBack)
            {
                Session["productList"] = null;
                Session["customerList"] = null;
                Session["firstname"] = null;
                Session["lastname"] = null;

            }
            else
            {
            }
        }
    }
}