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

public partial class chkretcom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string value = "", value1 = "", compcode;
        string retcode = Request.QueryString["retcode"].ToString();
        string fromdate = Request.QueryString["fdate"].ToString();
        string todate = Request.QueryString["tdate"].ToString();
        string center = "N";
        string dateformat = Request.QueryString["dateformat"].ToString();
        string txtframt = Request.QueryString["txtframt"].ToString();
        string txttoamt = Request.QueryString["txttoamt"].ToString();
        
        string codepass = "";
        if (Request.QueryString["codepass"] != null)
        {
            codepass = Request.QueryString["codepass"].ToString();
        }
        datesave ac = new datesave();
        string fdat = ac.getDate(dateformat, fromdate);
        string tdat = ac.getDate(dateformat, todate);


        //NewAdbooking.Classes.d

        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
        }
        else
        {
            Response.Write("yes");
            return;
        }
        if (tdat != "" && fdat != "")
        {
            DataSet ds = new DataSet();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();
                ds = insert.retcomcheck(compcode, retcode, tdat, fdat, dateformat, codepass, txtframt,txttoamt);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();
                ds = insert.retstatuscheck1(compcode, retcode, tdat, fdat, dateformat, codepass, txtframt, txttoamt);
            }
            else
            {
                NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();
                //ds = insert.retstatuscheck1(compcode, retcode, tdat, fdat, dateformat, codepass);

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
