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

public partial class checkvalueforcontact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string contactcode = Request.QueryString["page"].ToString();
        string compcode = Session["compcode"].ToString();
        string userid = Session["userid"].ToString();


        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {

        NewAdbooking.Classes.pop contactdetail = new NewAdbooking.Classes.pop();
        

        ds = contactdetail.detailofcontact(compcode, userid, contactcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop contactdetail = new NewAdbooking.classesoracle.pop();
            ds = contactdetail.detailofcontact(compcode, userid, contactcode);
        }
        else
        {
            NewAdbooking.classmysql.pop contactdetail = new NewAdbooking.classmysql.pop();


            ds = contactdetail.detailofcontact(compcode, userid, contactcode);

        }
        string code;
        if (ds.Tables[0].Rows.Count > 0)
            code = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        else
            code = "";
        Response.Write(code);
        Response.End();


    }
}
