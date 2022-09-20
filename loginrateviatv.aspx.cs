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

public partial class loginrateviatv : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        hdnusername.Value = Request.QueryString["username"].ToString();
        hdnpassword.Value = Request.QueryString["password"].ToString();
        hdnrefid.Value = Request.QueryString["refid"].ToString();
        hdncenter.Value = Request.QueryString["center"].ToString();
    }
}
