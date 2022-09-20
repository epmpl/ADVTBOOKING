using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class button : System.Web.UI.Page
{
    protected void  Page_Load(object sender, EventArgs e)
    {
       // Response.Write("str");
      //  Response.End();
           // string str = "";
           // str = "<table><tr><td>";
           // int i = 0;
           // //int totalImage = Convert.ToInt32(Request.QueryString["maxpage"].ToString());
           // //string imageName = Request.QueryString["imagename"].ToString();
           // //for (i = 1; i <= totalImage; i++)
           //// {
           //     //str = str + "<img src='pages/" + imageName + "-" + i + ".jpg'>";
           // //}
           // str = str + "</td></tr></table>";
           // str = "Ankur";
           // Response.Write(str);
            // Put user code to initialize the page here
        Response.Expires = -1;
       Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";



        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            string compcode = Session["compcode"].ToString();
            string userid = Session["userid"].ToString();
            string formname = Request.QueryString["page"].ToString();
            DataSet dz = new DataSet();
            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString()=="sql")
            {
            NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
          
            dz = checkform.formpermission(compcode, userid, formname);
            }

            else
                if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="orcl")
                {

                      NewAdbooking.classesoracle .Master checkform = new NewAdbooking.classesoracle.Master();
          
            dz = checkform.formpermission(compcode, userid, formname);

                }
            else
            {
                NewAdbooking.classmysql.Master checkform = new NewAdbooking.classmysql.Master();
                dz = checkform.formpermission(compcode, userid, formname);
          

            }
        string id = "";
        if (dz.Tables[0].Rows.Count > 0)
        {
            id = dz.Tables[0].Rows[0].ItemArray[0].ToString();
        }

            //return dz;
            Response.Write(id);
            Response.End();
        }
       // if (dz.Tables[0].Rows.Count > 0)
        //{


        //}


        

    }
}
