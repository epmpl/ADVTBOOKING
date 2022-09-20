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

public partial class chkpackage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string package = Request.QueryString["page"].ToString();
        string cyop = "";
          DataSet ds = new DataSet();

        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {

        NewAdbooking.Classes.Contract chkpac = new NewAdbooking.Classes.Contract();
      
        ds = chkpac.packagechk(package,Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                        NewAdbooking.classesoracle .Contract chkpac = new NewAdbooking.classesoracle.Contract();
      
        ds = chkpac.packagechk(package,Session["compcode"].ToString());

            }
            else
            {
                NewAdbooking.classmysql.Contract chkpac = new NewAdbooking.classmysql.Contract();
      
        ds = chkpac.packagechk(package,Session["compcode"].ToString());

            }

        if (ds.Tables[0].Rows.Count > 0)
        {
            cyop = ds.Tables[0].Rows[0].ItemArray[0].ToString();

        }
        else
        {
            cyop = "";
        }

        Response.Write(cyop);
        Response.End();

    }
}
