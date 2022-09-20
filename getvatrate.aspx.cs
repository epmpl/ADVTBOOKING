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

public partial class getvatrate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string grossamt = Request.QueryString["grossamt"].ToString();
        string compcode = Session["compcode"].ToString();
        string flag = "";

        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {

        NewAdbooking.Classes.BookingMaster vat = new NewAdbooking.Classes.BookingMaster();
    
        ds = vat.getvatamt(grossamt,compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster vat = new NewAdbooking.classesoracle.BookingMaster();

                ds = vat.getvatamt(grossamt, compcode);

            }
        else
        {

            NewAdbooking.classmysql.BookingMaster vat = new NewAdbooking.classmysql.BookingMaster();

            ds = vat.getvatamt(grossamt, compcode);
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            flag = ds.Tables[0].Rows[0].ItemArray[0].ToString();

        }
        Response.Write(flag);
        Response.End();


    }
}
