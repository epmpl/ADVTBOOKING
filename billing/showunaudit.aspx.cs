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

public partial class showunaudit : System.Web.UI.Page
{
    string cio_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        cio_id = Request.QueryString["ciobookid"].ToString();
        showvalues.Text = cio_id.ToString();

    }
}
