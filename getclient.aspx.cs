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

public partial class getclient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        
        string page=Request.QueryString["page"].ToString();
        string compcode=Session["compcode"].ToString();
        string userid=Session["userid"].ToString();
        string agcode=Request.QueryString["agencycode12"].ToString();
        string sagcode = Request.QueryString["agencysubcode12"].ToString();
        DataSet ds = new DataSet();

        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.pop getclient=new NewAdbooking.Classes.pop();
       
        ds = getclient.clientvalue(page, compcode, userid, agcode, sagcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop getclient = new NewAdbooking.classesoracle.pop();
            ds = getclient.clientvalue(page, compcode, userid, agcode, sagcode);
        }
        else
        {
            NewAdbooking.classmysql.pop getclient = new NewAdbooking.classmysql.pop();

            ds = getclient.clientvalue(page, compcode, userid, agcode, sagcode);

        }

        string value = ds.Tables[0].Rows[0].ItemArray[0].ToString();

        Response.Write(value);
        Response.End();

    }
}
