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

public partial class gettheinsertionfromcombin : System.Web.UI.Page
{
    string code = "";
    string desc = "";
    string agencytype = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;
        if (Session["compcode"] == null)
        { }
        else
        {
            code = Request.QueryString["code"].ToString();
            desc = Request.QueryString["desc"].ToString();
            agencytype = Request.QueryString["agencytype"].ToString();

            DataSet dx = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster getinserts = new NewAdbooking.Classes.BookingMaster();

                dx = getinserts.getinserts_combin(Session["compcode"].ToString(), code, desc, agencytype);
            }

            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster getinserts = new NewAdbooking.classesoracle.BookingMaster();

                    dx = getinserts.getinserts_combin(Session["compcode"].ToString(), code, desc, agencytype);

                }
            else
            {
                NewAdbooking.classmysql.BookingMaster getinserts = new NewAdbooking.classmysql.BookingMaster();



                dx = getinserts.getinserts_combin(Session["compcode"].ToString(), code, desc, agencytype);
            }

            string flag = dx.Tables[0].Rows[0].ItemArray[0].ToString();
            if (flag == "null" || flag == null)
                flag = "1";
            Response.Write(flag);
            Response.End();



        }

    }
}
