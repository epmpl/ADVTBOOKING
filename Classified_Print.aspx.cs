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
using System.Drawing;
using System.Text.RegularExpressions;
using System.Globalization;

public partial class Classified_Print : System.Web.UI.Page
{
        string matterText = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        matterText = Session["matterText_session_print"].ToString();
       
        lblmatter.Text = matterText;
        btnPrint.Attributes.Add("onclick", "javascript:return printreport();");


    }
}
