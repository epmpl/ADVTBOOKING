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

public partial class chkretstatus1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string value = "", value1 = "", compcode, userid;
    
        string retcode = Request.QueryString["retcode"].ToString();
        string fromdays = Request.QueryString["fromdays"].ToString();
        string todays = Request.QueryString["todays"].ToString();

        string agency_type = "";// Request.QueryString["agency_type"].ToString();

        string center = "N";
        string codepass = "";
        if (Request.QueryString["codepass"] != null)
        {
            codepass = Request.QueryString["codepass"].ToString();
        }
        


        //NewAdbooking.Classes.d

        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();

        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("yes");
            return;
        }
        
            DataSet ds = new DataSet();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();
                ds = insert.retslabcheck(compcode, userid, retcode, fromdays, todays, codepass, agency_type);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();
                ds = insert.retslabcheck(compcode, userid, retcode, fromdays, todays, codepass, agency_type);
            }
            else
            {
                NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();
                ds = insert.retslabcheck(compcode, userid, retcode, fromdays, todays, codepass);
            }
           

            if (ds.Tables[0].Rows.Count > 0)
            {
                center = "Y";

            }
            else
            {
                center = "N";

            }
            Response.Write(center);
            Response.End();
        
    }
}
