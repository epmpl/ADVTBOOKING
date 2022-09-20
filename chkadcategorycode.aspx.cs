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

public partial class chkadcategorycode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string value = "";

        string adcatcode = Request.QueryString["adcatcode"].ToString();
        //string adcatcode = Request.QueryString["adcatcode"].ToString();
        string center = "N";
        //string firstdate = Request.QueryString["date1"].ToString();
        //string seconddate = Request.QueryString["date2"].ToString();

        if (adcatcode != "")
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.AdCategoryMaster chk = new NewAdbooking.Classes.AdCategoryMaster();
            
                ds = chk.advcatchk(Session["compcode"].ToString(), Session["userid"].ToString(), adcatcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.AdCategoryMaster chk = new NewAdbooking.classesoracle.AdCategoryMaster();
                ds = chk.advcatchk(Session["compcode"].ToString(), Session["userid"].ToString(), adcatcode);
            }
            else
            {
                NewAdbooking.classmysql.AdCategoryMaster chk = new NewAdbooking.classmysql.AdCategoryMaster();
                ds = chk.advcatchk(Session["compcode"].ToString(), Session["userid"].ToString(), adcatcode);
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
