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

public partial class chkweight : System.Web.UI.Page
{
    string value="";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string weight = Request.QueryString["page"].ToString();

        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        
        NewAdbooking.Classes.Contract wight = new NewAdbooking.Classes.Contract();
        
        ds = wight.chkweight(weight, Session["compcode"].ToString());
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract wight = new NewAdbooking.classesoracle.Contract();

                ds = wight.chkweight(weight, Session["compcode"].ToString());

            }
        else
        {
            NewAdbooking.classmysql.Contract wight = new NewAdbooking.classmysql.Contract();

            ds = wight.chkweight(weight, Session["compcode"].ToString());

        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            value = ds.Tables[0].Rows[0].ItemArray[0].ToString();

        }

        Response.Write(value);
        Response.End();

    }
}
