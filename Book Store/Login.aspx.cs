using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final
{
    public partial class Login : System.Web.UI.Page
    {
        string first_Name, last_Name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Browser.Cookies)
            {
                
            }
            else
            {
                
            
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
                Session["first_Name"] = null;
                Session["last_Name"] = null;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)//cookie oluşturulup firstname ve lastname verileri aktarılıyor
        {
            HttpCookie cerezOku = new HttpCookie("UserInfo");
            cerezOku["first_Name"] = FirstNametxt.Text;
            cerezOku["last_Name"] = LastNametxt.Text;

            first_Name = cerezOku["first_Name"];
            last_Name = cerezOku["last_Name"];

            Session["first_Name"] = cerezOku["first_Name"];
            Session["last_Name"] = cerezOku["last_Name"];

            cerezOku.Expires = DateTime.Now.AddDays(30);//Cookie süresi 30 gün olarak belirlendi.
            Response.Cookies.Add(cerezOku);
            Response.Redirect("Default.aspx");
        }
    }
}