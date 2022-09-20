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

public partial class contractfill : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string compcode = Session["compcode"].ToString();
        string userid = Session["userid"].ToString();
        string formname = Request.QueryString["page"].ToString();
        string dealcode = Request.QueryString["dealcode"].ToString();

        NewAdbooking.Classes.Contract getvalue = new NewAdbooking.Classes.Contract();
        DataSet ds = new DataSet();
        ds = getvalue.getfromcontractdetail(compcode, userid, formname, dealcode);

        string d = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        

    }
}
