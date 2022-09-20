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

public partial class open_ads : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        xmllist3.Attributes.Add("onclick", "javascript:getadhtm1()");
        xmllist3.Attributes.Add("onkeydown", "javascript:getadhtm1()");
        xmllist3.Attributes.Add("onkeyup", "javascript:getadhtm1()");


        if (!Page.IsPostBack)
        {
            //bindxml();
        }
    }
}
