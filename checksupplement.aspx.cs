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

public partial class checksupplement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string value = "";

        string periodicty = Request.QueryString["page"].ToString().Trim();
        string supplement = Request.QueryString["supplement"].ToString();
        string date = "N";
        string firstdate = Request.QueryString["date1"].ToString();
        string seconddate = Request.QueryString["date2"].ToString();

        if (supplement == "" && periodicty != "")
        {
            DataSet ds = new DataSet();
            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
            {
            NewAdbooking.Classes.SupplimentMaster chkperiodicty = new NewAdbooking.Classes.SupplimentMaster();
            
            ds = chkperiodicty.chkperiodicty(periodicty);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.SupplimentMaster chkperiodicty = new NewAdbooking.classesoracle.SupplimentMaster();
                ds = chkperiodicty.chkperiodicty(periodicty);
            }
            else
            {
                NewAdbooking.classmysql.SupplimentMaster chkperiodicty = new NewAdbooking.classmysql.SupplimentMaster();

                ds = chkperiodicty.chkperiodicty(periodicty);
            }
            if (ds.Tables[0].Rows.Count >= 0)
            {
                value = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else
            {
                value = "";
            }
            Response.Write(value);
            Response.End();
        }
        else
        {
            DataSet ds = new DataSet();
            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
            {
            NewAdbooking.Classes.SupplimentMaster chkdate = new NewAdbooking.Classes.SupplimentMaster();

            ds = chkdate.chkdaetedit(Session["compcode"].ToString(), supplement, firstdate, seconddate);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.SupplimentMaster chkdate = new NewAdbooking.classesoracle.SupplimentMaster();
                ds = chkdate.chkdaetedit(Session["compcode"].ToString(), supplement, firstdate, seconddate);
            }
            else
            {
                NewAdbooking.classmysql.SupplimentMaster chkdate = new NewAdbooking.classmysql.SupplimentMaster();

                ds = chkdate.chkdaetedit(Session["compcode"].ToString(), supplement, firstdate, seconddate);
            }
            //Session["firstdate"] = firstdate;
            //Session["seconddate"] = seconddate;

            if (ds.Tables[0].Rows.Count > 0)
            {
                date = "Y";
            }
            else
            {
                date = "N";

            }

            Response.Write(date);
            Response.End();

        }
    }
}
