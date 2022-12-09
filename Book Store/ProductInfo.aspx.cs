using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final
{
    public partial class ProductInfo : System.Web.UI.Page
    {
        string first_Name, last_Name, id;
        List<Product> pList = new List<Product>();
        List<Customer> cList = new List<Customer>();
        ArrayList SelectedProducts = new ArrayList();

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void btnMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (SelectedProducts.Contains(Request.QueryString[0]))
            {
                Label4.Visible = true;
                Label4.Text = "Ürün zaten sepette";
            }
            else
            {
                SelectedProducts.Add(Request.QueryString[0]);
            }          
        }

     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pList"] != null)
            {
                pList = (List<Product>)Session["pList"];
            }
            if (Session["cList"] != null)
            {
                cList = (List<Customer>)Session["cList"];
            }
            if (Session["first_Name"] != null)
            {
                first_Name = (string)Session["first_Name"];              
            }
            if (Session["last_Name"] != null)
            {
                last_Name = (string)Session["last_Name"];             
            }
            if (this.IsPostBack)
            {
                Session["pList"] = null;
                Session["cList"] = null;
                Session["first_Name"] = null;
                Session["last_Name"] = null;

            }
            else
            {
            }
            for(int i=0;i< pList.Count;i++)
            {
                if(pList[i].ProductID.ToString()== Request.QueryString[0])
                {
                    Image1.ImageUrl= "/Pictures/" + pList[i].ProductImage;
                    Label1.Text = pList[i].ProductName;
                    Label2.Text = pList[i].ProductDescription;
                    Label3.Text = "Price : " + pList[i].ProductPrice + "tl";
                }
            }


        }
    }
}