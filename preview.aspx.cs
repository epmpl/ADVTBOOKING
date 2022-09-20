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

public partial class preview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        form1.Attributes.Add("OnLoad", "javascript:movedata();");
        printme.Attributes.Add("onclick", "javascript:printas();");
        cancelme.Attributes.Add("onclick", "javascript:closeme();");
        
    }

}
