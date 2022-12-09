using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final
{
    public partial class Default : System.Web.UI.Page
    {
        string first_Name, last_Name, id;
        List<Product> pList = new List<Product>();
        List<Customer> cList = new List<Customer>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Browser.Cookies)
            {
               
            }
            else
            {
                
            }
            if (Session["pList"] != null)//Arraylist session kısmında tutulurmaktadır.
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
            if (Request.Cookies["UserInfo"] != null)
            {
                HttpCookie cookieread = Request.Cookies["UserInfo"];
                first_Name = cookieread["first_Name"];
                last_Name = cookieread["last_Name"];
                Session["first_Name"] = first_Name;
                Session["last_Name"] = last_Name;
            }
            else
            {
                Response.Write("<script>window.alert('Please Login');window.location='Login.aspx';</script>");
            }


            if (pList.Count==0)
            {
                OleDbConnection connn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Products.accdb");//Veritabanına bağlanılıp bilgilere erişim saglanir.
                OleDbCommand comd = new OleDbCommand("SELECT * FROM Tablo1 ORDER BY ProductID ASC", connn);
                OleDbDataReader dataR;

                for (int m = 0; m < pList.Count; m++)//objelerin olusturulmasi saglandi.
                {
                    pList[m].ProductName = pList[m].ProductName.Replace("'", "''");
                    pList[m].ProductImage = pList[m].ProductImage.Replace("'", "''");
                    pList[m].ProductDescription = pList[m].ProductDescription.Replace("'", "''");
                    pList[m].ProductBrand = pList[m].ProductBrand.Replace("'", "''");
                    pList[m].ProductCategoryName = pList[m].ProductCategoryName.Replace("'", "''");
                    string sql = "insert into Tablo1 values('" + pList[m].ProductID + "','" + pList[m].ProductName + "','" + 
                        pList[m].ProductPrice + "', '" + pList[m].ProductImage + "','" + pList[m].ProductDescription + "','" + 
                        pList[m].ProductBrand + "','" + pList[m].ProductQuantity + "','" + pList[m].ProductCategoryName + "')";
                    comd.CommandText = sql;
                    int r = comd.ExecuteNonQuery();
                }
                try
                {
                    connn.Open();
                    dataR = comd.ExecuteReader();
                    while (dataR.Read())//bilgiler girilip arrayliste atandi.
                    {
                        pList.Add(new Product(dataR.GetInt32(dataR.GetOrdinal("ProductID")), dataR.GetString(dataR.GetOrdinal("ProductName")), dataR.GetInt32(dataR.GetOrdinal("ProductPrice")), dataR.GetString(dataR.GetOrdinal("ProductImage")), dataR.GetString(dataR.GetOrdinal("ProductDescription")), dataR.GetString(dataR.GetOrdinal("ProductBrand")), dataR.GetInt32(dataR.GetOrdinal("ProductQuantity")), dataR.GetString(dataR.GetOrdinal("ProductCategoryName"))));
                        Session["pList"] = pList;
                    }
                    dataR.Close();
                }
                catch (Exception exp)
                {
                    throw;
                }
                finally
                {
                    connn.Close();
                }
            }

            if (cList.Count == 0)
            {
                OleDbConnection connn2 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Customers.accdb");//veritabanı bağlantısı kuruluyor
                OleDbCommand comd2 = new OleDbCommand("SELECT * FROM Tablo1 ORDER BY CustomerID ASC", connn2);//NewsID ye göre sıralama yapılıp bilgiler alınıyor
                OleDbDataReader data_R2;

                for (int i = 0; i < cList.Count; i++)
                {
                    cList[i].CustormerName = cList[i].CustormerName.Replace("'", "''");
                    cList[i].CustormerEmail = cList[i].CustormerEmail.Replace("'", "''");
                    cList[i].CustormerPhoneNumber = cList[i].CustormerPhoneNumber.Replace("'", "''");
                    cList[i].CustormerPassword = cList[i].CustormerPassword.Replace("'", "''");
                    string sql = "insert into Tablo1 values('" + cList[i].CustomerID + "','" + cList[i].CustormerName +
                        "','" + cList[i].CustormerEmail + "', '" + cList[i].CustormerPhoneNumber + "','" + cList[i].CustormerPassword + "')";
                    
                    comd2.CommandText = sql;
                    int r = comd2.ExecuteNonQuery();
                }
                try
                {
                    connn2.Open();
                    data_R2 = comd2.ExecuteReader();
                    while (data_R2.Read())
                    {
                        cList.Add(new Customer(data_R2.GetInt32(data_R2.GetOrdinal("CustomerID")), data_R2.GetString(data_R2.GetOrdinal("CustomerName")), data_R2.GetString(data_R2.GetOrdinal("CustomerEmail")), data_R2.GetString(data_R2.GetOrdinal("CustomerPhoneNumber")), data_R2.GetString(data_R2.GetOrdinal("CustomerPassword"))));
                        Session["cList"] = cList;
                    }
                    data_R2.Close();
                }
                catch (Exception exp)
                {
                    throw;
                }
                finally
                {
                    connn2.Close();
                }
            }

            for (int i = 0; i < pList.Count; i++)
            {
                ImageButton image_Button = new ImageButton();
                image_Button.ImageUrl = "/Pictures/" + pList[i].ProductImage;
                image_Button.ID = i.ToString();
                image_Button.Attributes.Add("class", "imgOne");
                image_Button.Attributes.Add("runat", "server");
                string url = string.Format("~/ProductInfo.aspx?STT={0}", i);
                image_Button.Click += new ImageClickEventHandler(imageButton_Click);
                image_Button.Width = 120;
                image_Button.Height = 120;
                this.Panel1.Controls.Add(image_Button);
            }



        }
        void imageButton_Click(object sender, ImageClickEventArgs e)//image butona göre id querystring atanmaktadir.
        {           
            ImageButton clickedButton = sender as ImageButton;
            for(int i=0;i<30;i++)
            {
                if(clickedButton.ID==i.ToString())
                {
                    Session["pList"] = pList;
                    Session["cList"] = cList;
                    Response.Redirect("ProductInfo.aspx?id=" + i.ToString());
                    id = i.ToString();
                    id = Request.QueryString[0];
                }
            }
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["UserInfo"] != null)
            {
                Response.Cookies["UserInfo"].Expires = DateTime.Now.AddDays(-1);
                Response.Write("<script>window.alert('Please Login');window.location='Login.aspx';</script>");//Gecis islemi saglandi.
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Label1.Text = first_Name + " " + last_Name;         
        }

        protected void btnCok_Click(object sender, EventArgs e)
        {
            Panel1.Controls.Clear();
            kategori(pList, Panel1, "Çok Satanlar");
        }

        protected void btnCok_PreRender(object sender, EventArgs e)
        {
            
        }

        protected void LogoutBtn_PreRender(object sender, EventArgs e)
        {
          
        }
        protected void btnCocuk_Click(object sender, EventArgs e)
        {
            kategori(pList, Panel1, "Çocuk Kitapları");
        }

        protected void btnEdebiyat_Click(object sender, EventArgs e)
        {
            kategori(pList, Panel1, "Edebiyat ve Kurgu");
        }

        protected void btnSiyaset_Click(object sender, EventArgs e)
        {
            kategori(pList, Panel1, "Siyaset ve Felsefe");
        }

        protected void btnYabanci_Click(object sender, EventArgs e)
        {
            kategori(pList, Panel1, "Yabancı Dilde Kitaplar");
        }


        protected void btnHepsi_Click(object sender, EventArgs e)//bütün ürünler için imagebutton oluşturuldu.
        {
            Panel1.Controls.Clear();
            for (int i = 0; i < pList.Count; i++)
            {
                ImageButton image_Button = new ImageButton();
                image_Button.ImageUrl = "/Pictures/" + pList[i].ProductImage;
                image_Button.ID = i.ToString();
                image_Button.Attributes.Add("class", "imgOne");
                image_Button.Attributes.Add("runat", "server");
                string url = string.Format("~/ProductInfo.aspx?STT={0}", i);
                image_Button.Click += new ImageClickEventHandler(imageButton_Click);
                image_Button.Width = 120;
                image_Button.Height = 120;
                this.Panel1.Controls.Add(image_Button);          
            }
        }

        public void kategori(List<Product> pList, Panel Panel1, string kategorii)//kategorileri uygun panele gönderme islemi yapildi.
        {
            Panel1.Controls.Clear();
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ProductCategoryName == kategorii)
                {
                    ImageButton image_Button = new ImageButton();
                    image_Button.ImageUrl = "/Pictures/" + pList[i].ProductImage;
                    image_Button.ID = i.ToString();
                    image_Button.Attributes.Add("class", "imgOne");
                    image_Button.Attributes.Add("runat", "server");
                    string url = string.Format("~/ProductInfo.aspx?STT={0}", i);
                    image_Button.Click += new ImageClickEventHandler(imageButton_Click);
                    image_Button.Width = 120;
                    image_Button.Height = 120;
                    this.Panel1.Controls.Add(image_Button);
                }
            }
        }      
    }
}