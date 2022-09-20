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

public partial class checksession : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;
        string sessioncheck;
        if (Session["compcode"] == null)
        {
            sessioncheck = "0";
        }
        else
        {
            sessioncheck = "1";

        }

        Response.Write(sessioncheck);
        Response.End();

    }
}
