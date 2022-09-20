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

public partial class noissuenull : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
           
        if (!Page.IsPostBack)
        {
            Session["issuecode"] = null;
            Session["issuesave"] = null;
            Session["date1"] = null;
            Session["drop"] = null;
        }
    }
}
