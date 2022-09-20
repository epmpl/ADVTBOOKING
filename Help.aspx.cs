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

public partial class Help : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hiddenformname.Value = Request.QueryString["formname"].ToString();
        DataSet fpathDataSet = new DataSet();
        fpathDataSet.ReadXml(Server.MapPath("XML/Help.xml"));
        hiddenfilepath.Value = fpathDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
    }
}
