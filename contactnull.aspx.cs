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

public partial class contactnull : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {

        Response.Expires = -1;
        string value = "", value1 = "", compcode, userid;
        if (Session["compcode"] != null)
        {
            Response.Write("yes");
            return;
        }

        Response.Expires = -1;
       
        if (!Page.IsPostBack)
        {
            Session["pubstatus"] = null;
            Session["pubsave"] = null;
        }
    }

}
