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

public partial class chkcomm_detail : System.Web.UI.Page
{
    //static int i;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        Response.Expires = -1;
        string value = "", value1 = "", compcode, userid;

        string hiddenagevcode = Request.QueryString["hiddenagevcode"].ToString();
        string hiddenagensubcode = Request.QueryString["hiddenagensubcode"].ToString();
        string txtefffrom = Request.QueryString["txtefffrom"].ToString();
        string txtefftill = Request.QueryString["txtefftill"].ToString();
        string adtype = Request.QueryString["adtype"].ToString();
        string uom11 = Request.QueryString["uom11"].ToString();

        string center = "N";

        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();

        }
        else
        {
            Response.Write("<script>alert(\"Your Session has been expired\");window.close();</script>");
            return;
        }

        if (txtefffrom != "" && txtefftill!="")
        {

            DataSet ds = new DataSet();
            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
            {
            NewAdbooking.Classes.pop databindcomm = new NewAdbooking.Classes.pop();

            ds = databindcomm.commcheckdate(hiddenagevcode, compcode, userid, txtefffrom, txtefftill, hiddenagensubcode,adtype, uom11);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop databindcomm = new NewAdbooking.classesoracle.pop();
                ds = databindcomm.commcheckdate(hiddenagevcode, compcode, userid, txtefffrom, txtefftill, hiddenagensubcode, adtype, uom11);
            }
            else
            {
                NewAdbooking.classmysql.pop databindcomm = new NewAdbooking.classmysql.pop();

                ds = databindcomm.commcheckdate(hiddenagevcode, compcode, userid, txtefffrom, txtefftill, hiddenagensubcode, adtype, uom11);

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
}
