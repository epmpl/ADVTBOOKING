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

public partial class s : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string path2 = (Request.QueryString["p"]);
        Bitmap b2 = new Bitmap(path2);
        b2.Save(HttpContext.Current.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        b2.Dispose();
    }
}
