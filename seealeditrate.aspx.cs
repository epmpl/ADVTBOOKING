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

public partial class seealeditrate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>alert(\"Your Session has been expired\");window.close();</script>");
            return;

        }

        string packagecode = Request.QueryString["packagecode"].ToString();
        bindgridforrate(packagecode);
    }

    public void bindgridforrate(string pkg)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster bind = new NewAdbooking.Classes.RateMaster();
            ds = bind.bindrateforgrid(pkg, Session["compcode"].ToString(), Session["dateformat"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster bind = new NewAdbooking.classesoracle.RateMaster();
            ds = bind.bindrateforgrid(pkg, Session["compcode"].ToString(), Session["dateformat"].ToString());
        }
      
        rategrid.DataSource = ds;
        rategrid.DataBind();


    }
}
