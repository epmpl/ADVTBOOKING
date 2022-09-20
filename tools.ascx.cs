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

public partial class tools : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        fcolor.Attributes.Add("onclick", "showColorGridT1('colorcodeT_F',currentid);");
        bgcolor.Attributes.Add("onclick", "showColorGridT2('colorcodeT_B',currentid);");
    }
    protected void fcolor_TextChanged(object sender, EventArgs e)
    {

    }
}
