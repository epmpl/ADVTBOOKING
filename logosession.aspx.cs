using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class logosession : System.Web.UI.Page
{

    string retcode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        retcode = Request.QueryString["retcode"].ToString();

        Session["Premium"] = null;

        Session["DESIGN"] = null;
        Session["BULLET"] = null;
        Session["STYLE"] = null;
    }
}