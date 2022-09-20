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

public partial class convertrate : System.Web.UI.Page
{
    string currcode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
       
        string curr = Request.QueryString["curr"].ToString();
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.Contract conver = new NewAdbooking.Classes.Contract();    

        ds = conver.convertrate(curr, Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
                    NewAdbooking.classesoracle .Contract conver = new NewAdbooking.classesoracle.Contract();    

        ds = conver.convertrate(curr, Session["compcode"].ToString(), Session["userid"].ToString());

        }
        else
        {
                        NewAdbooking.classmysql .Contract conver = new NewAdbooking.classmysql.Contract();    

        ds = conver.convertrate(curr, Session["compcode"].ToString(), Session["userid"].ToString());

        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            currcode = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }

        Response.Write(currcode);
        Response.End();

    }
}
