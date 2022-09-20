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

public partial class checkrotime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
       
        string Rohours = Request.QueryString["rohours"].ToString();
        string Romin = Request.QueryString["romin"].ToString();
        string compcode = Request.QueryString["compcode"].ToString();
        string publishdate = Request.QueryString["dateday"].ToString();
        string packagename = Request.QueryString["pkgname"].ToString();
        string hei = Request.QueryString["h"].ToString();
       // int heinum = Convert.ToInt32(hei);
        string wid = Request.QueryString["w"].ToString();
        string flag = "0";
        DataSet ds = new DataSet();

        if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.BookingMaster chkrotime = new NewAdbooking.Classes.BookingMaster();
        
        ds = chkrotime.getrotime(Rohours, Romin, compcode, publishdate, packagename);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster chkrotime = new NewAdbooking.classesoracle.BookingMaster();

                ds = chkrotime.getrotime(Rohours, Romin, compcode, publishdate, packagename,Session["dateformat"].ToString());

            }

        else
        {
            NewAdbooking.classmysql.BookingMaster chkrotime = new NewAdbooking.classmysql.BookingMaster();
        
        ds = chkrotime.getrotime(Rohours, Romin, compcode, publishdate, packagename);

        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            int hrs = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
            int min = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[1]);
            int prod = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[2]);
            int prod_mast = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[3]);

            if(prod<=prod_mast)
            {
                if (Convert.ToInt32(Rohours) <= hrs)
                {
                    flag = "1";

                }
                if (Convert.ToInt32(Romin) < min)
                {
                    flag = "1";

                }
           

            }
            else if (Convert.ToInt32(Rohours) <= hrs && prod <= prod_mast)
            {
                flag = "1";

            }
            else if (Convert.ToInt32(Romin) < min && Convert.ToInt32(Rohours) <= hrs && prod <= prod_mast)
            {
                flag = "1";

            }
            if (Convert.ToDouble(hei.Trim()) > Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[4]))
            {
                flag="2";

            }
            if (Convert.ToDouble(wid) > Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[5]))
            {
                flag = "2";

            }
           


        }

        Response.Write(flag);
        Response.End();


    }
}
