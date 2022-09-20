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

public partial class sbview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string path_1 = Request.QueryString["path1"];
        Bitmap b1 = new Bitmap(path_1);
        Response.Clear();
        b1.Save(HttpContext.Current.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        b1.Dispose();
    }
}
