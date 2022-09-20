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

public partial class chkpubcatmaststatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string value = "", value1 = "", compcode, userid;
        //  string country = Request.QueryString["page"].ToString();
        //string chkadv=Request.QueryString["chk"].ToString();

        string centcode = Request.QueryString["centcode"].ToString();
       // string city = Request.QueryString["city"].ToString();
        string fromdate = Request.QueryString["fdate"].ToString();
        string todate = Request.QueryString["todate"].ToString();
        string center = "N";
        string circular = Request.QueryString["circular"].ToString();
        string status = Request.QueryString["status"].ToString();
        string dateformat = Request.QueryString["dateformat"].ToString();
        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();

        }
        else
        {
            Response.Write("yes");
             return;
        }
        if (todate != "" && fromdate != "")
        {
            DataSet ds = new DataSet();
            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
            {
            NewAdbooking.Classes.PubCatMast insert = new NewAdbooking.Classes.PubCatMast();
            
            ds = insert.pcmstatuscheck(compcode, userid, centcode, status, circular, todate, fromdate, dateformat);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.PubCatMast insert = new NewAdbooking.classesoracle.PubCatMast();
                ds = insert.pcmstatuscheck(compcode, userid, centcode, status, circular, todate, fromdate, dateformat);
            }
            else
            {
                NewAdbooking.classmysql.PubCatMast insert = new NewAdbooking.classmysql.PubCatMast();

                ds = insert.pcmstatuscheck(compcode, userid, centcode, status, circular, todate, fromdate, dateformat);

            }
        
            

            if (ds.Tables[0].Rows.Count > 1)
            {
                center = "Y";
               
            }
            else
            {
               // center = "N";
                if (ds.Tables[1].Rows.Count > 0)
                {
                    center = "N,'" + ds.Tables[1].Rows[0].ItemArray[0].ToString() + "'";
                }
                else {
                    center = "N,";
                }
               // ds.Tables[1].Rows[0].ItemArray[0].ToString();
                
            }
            Response.Write(center);
             Response.End();

        }
    }
}
