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
using System.Text;

public partial class sb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb1=new StringBuilder();
        sb1.Append("<table border=1  style='FONT-SIZE: 10px'>");
        sb1.Append("<tr align='center'width='5'>");
        sb1.Append("<td>");
        string tt = "04000";
        sb1.Append(tt.ToString());
        sb1.Append("</td>");
        sb1.Append("</tr>");
        sb1.Append("</table>");
        Response.Write(sb1.ToString());
    }
}
