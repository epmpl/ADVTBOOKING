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

public partial class chkvisibilityforagency : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Agencymaster.xml"));
        string agencycategory = ds.Tables[1].Rows[0].ItemArray[0].ToString();
        string agencysubcategory = ds.Tables[1].Rows[0].ItemArray[1].ToString();
        Response.Write(agencycategory +","+ agencysubcategory);
        Response.End();

    }
}
