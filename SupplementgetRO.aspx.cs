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

public partial class SupplementgetRO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        string pubname = Request.QueryString["pubname"].ToString();
        string compcode = Session["compcode"].ToString();

        string nameadd;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.SupplimentMaster sm = new NewAdbooking.Classes.SupplimentMaster();

            ds = sm.getRO(pubname, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.SupplimentMaster sm = new NewAdbooking.classesoracle.SupplimentMaster();
            ds = sm.getRO(pubname, compcode);
        }
        else
        {
            NewAdbooking.classmysql.SupplimentMaster sm = new NewAdbooking.classmysql.SupplimentMaster();
            ds = sm.getRO(pubname, compcode);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {

            string gut = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            string col = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            string hr = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            string min = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            string pro = ds.Tables[0].Rows[0].ItemArray[4].ToString();

            nameadd =  gut+ "+" + col + "+" + hr + "+" + min + "+" + pro;
            Response.Write(nameadd);
            Response.End();
        }

    }
}
