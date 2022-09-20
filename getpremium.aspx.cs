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

public partial class getpremium : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        string premium = Request.QueryString["page"].ToString();
        string per = "";
        string pageper = "";
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {

        NewAdbooking.Classes.BookingMaster getprem = new NewAdbooking.Classes.BookingMaster();
       
        ds = getprem.getpercentage(premium, Session["compcode"].ToString());
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getprem = new NewAdbooking.classesoracle.BookingMaster();

                ds = getprem.getpercentage(premium, Session["compcode"].ToString());

            }
        else
        {
            NewAdbooking.classmysql.BookingMaster getprem = new NewAdbooking.classmysql.BookingMaster();

            ds = getprem.getpercentage(premium, Session["compcode"].ToString());
 
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            per = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        else
        {
            per = "0";
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            pageper = ds.Tables[1].Rows[0].ItemArray[0].ToString();
        }
        else
        {
            pageper = "0";

        }
        Response.Write(per + "^" + pageper);
        Response.End();




    }
}
