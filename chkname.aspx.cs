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

public partial class chkname : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string name = "";
        string compcode = Session["compcode"].ToString();
        string userid = Session["userid"].ToString();
        string conname = Request.QueryString["page"].ToString();
        string agencycode = Request.QueryString["agencycode1"].ToString();
        string subagency = Request.QueryString["agencysubcode1"].ToString();
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.pop chkname = new NewAdbooking.Classes.pop();

        ds = chkname.contactname(conname.Trim(), agencycode, subagency,compcode, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop chkname = new NewAdbooking.classesoracle.pop();
            ds = chkname.contactname(conname.Trim(), agencycode, subagency, compcode, userid);
        }
        else
        {
            NewAdbooking.classmysql.pop chkname = new NewAdbooking.classmysql.pop();

            ds = chkname.contactname(conname.Trim(), agencycode, subagency, compcode, userid);

        }
        if (ds.Tables[0].Rows.Count > 0)
        {
             name = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        Response.Write(name);
        Response.End();

    }
}
