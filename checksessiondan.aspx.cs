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

public partial class checksessiondan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string err = "nosess";
        try
        {
            if (Session["compcode"] != null)
            {
                err = "sess";
            }
            if (Session[0] != null)
            {
                err = "sess";
            }
            if (Session["defaultadmin"] != null)
            {
                if (Session["defaultadmin"] == "yes")
                    err = "sess";
            }
        }
        catch (Exception ex)
        {
            err = "nosess";
        }
        Response.Clear();
        Response.Write(err);
    }
}
