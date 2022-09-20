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
using System.IO;

public partial class chktheimage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //  Response.Expires = -1;
       // Response.Buffer = false;
       // Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);        
        //Response.CacheControl = "no-cache";        
        string flag = "";
        string image = Request.QueryString["image_chk"].ToString();
      //  image = Server.MapPath(image);
      //  if (System.IO.File.Exists(Server.MapPath(image)))
        if (System.IO.File.Exists(image))
        {
            flag = "y";
        }
        else
        {
            flag = "n";
        }

        Response.Write(flag);
        Response.End();

    }
}
