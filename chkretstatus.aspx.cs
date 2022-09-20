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

public partial class chkretstatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string value = "", value1 = "", compcode, userid;
        //  string country = Request.QueryString["page"].ToString();
        //string chkadv=Request.QueryString["chk"].ToString();

        string retcode = Request.QueryString["retcode"].ToString();
        // string city = Request.QueryString["city"].ToString();
        string fromdate = Request.QueryString["fdate"].ToString();
        string todate = Request.QueryString["tdate"].ToString();
        string center = "N";
        string circular = Request.QueryString["circular"].ToString();
        string status = Request.QueryString["status"].ToString();
        string dateformat = Request.QueryString["dateformat"].ToString();
        string codepass = "";
        if (Request.QueryString["codepass"] != null)
        {
             codepass = Request.QueryString["codepass"].ToString();
        }
        datesave ac=new datesave();
        string fdat=ac.getDate(dateformat,fromdate);
        string tdat = ac.getDate(dateformat, todate);


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
        if (tdat != "" && fdat != "")
        {
            DataSet ds = new DataSet();

            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
            {
            NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();
            ds = insert.retstatuscheck(compcode, userid, retcode, status, circular, tdat, fdat, dateformat, codepass);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();
                ds = insert.retstatuscheck(compcode, userid, retcode, status, circular, tdat, fdat, dateformat, codepass);
            }
            else
            {
                NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();

                ds = insert.retstatuscheck(compcode, userid, retcode, status, circular, tdat, fdat, dateformat, codepass);

            }
            //return ds;

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
