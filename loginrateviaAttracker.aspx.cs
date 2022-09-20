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

public partial class loginrateviaAttracker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hdnusername22.Value = Request.QueryString["username"].ToString();
        hdnpassword22.Value = Request.QueryString["password"].ToString();
        hdntracid.Value = Request.QueryString["refid"].ToString();
        hdntracbook.Value = Request.QueryString["bookid"].ToString();
        hdntracadtye.Value = Request.QueryString["adty"].ToString();
        hdntracinsid.Value = Request.QueryString["ins"].ToString();
        hdncenter22.Value = Request.QueryString["center"].ToString();
    }
}
