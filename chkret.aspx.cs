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


public partial class chkret : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string value = "", value1 = "", compcode, userid;

        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();

        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("yes");
            return;
        }
        /*
         *  Session["retainer_comm"] = null;
            Session["retainer_stat"] = null;

            Session["retainer_pay"] = null;*/
        if (Session["retainer_stat"] == null || Session["retainer_stat"] == "")
        {
            //ScriptManager.RegisterStartupScript(this, typeof(chkret), "ss", "stat();", true);
            Response.Write("NO1");
                Response.End();

        }
        else if (Session["retainer_comm"] == null || Session["retainer_comm"] == "")
        {
            Response.Write("NO2");
            Response.End();
        }
        else if (Session["retainer_pay"] == null || Session["retainer_pay"] == "")
        {
            Response.Write("NO3");
            Response.End();
        }
        else if (Session["retainer_slab"] == null || Session["retainer_slab"] == "")
        {
            //ScriptManager.RegisterStartupScript(this, typeof(chkret), "ss", "stat();", true);
            Response.Write("NO4");
            Response.End();


        }
    }
}
