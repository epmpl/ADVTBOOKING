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

public partial class ratecodechk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        string ratecode = Request.QueryString["page"].ToString();
        string type_ = Request.QueryString["type_"].ToString();
        string flag = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster chkratecodeinratedetail = new NewAdbooking.Classes.RateMaster();
            ds = chkratecodeinratedetail.chkratecode(Session["compcode"].ToString(), ratecode, type_);
            //ds = chkratecodeinratedetail.chkratecode(Session["compcode"].ToString(), ratecode);
        }
        else
        {
            NewAdbooking.classmysql.RateMaster chkratecodeinratedetail = new NewAdbooking.classmysql.RateMaster();
            ds = chkratecodeinratedetail.chkratecode(Session["compcode"].ToString(), ratecode);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            flag = "Y";
        }
        else
        {
            flag = "N";
        }

        Response.Write(flag);
        Response.End();

    }
}
