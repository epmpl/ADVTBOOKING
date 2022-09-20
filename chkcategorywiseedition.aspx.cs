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

public partial class chkcategorywiseedition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string value = "";

        string edition = Request.QueryString["edition"].ToString();
        string adcatcode = Request.QueryString["adcatcode"].ToString();
        string center = "N";
        //string firstdate = Request.QueryString["date1"].ToString();
        //string seconddate = Request.QueryString["date2"].ToString();

        if (edition != "" && adcatcode!="")
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.AdCategoryMaster chkedition = new NewAdbooking.Classes.AdCategoryMaster();
            
                ds = chkedition.chkedit(edition, adcatcode);
            }
            else if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.AdCategoryMaster chkedition = new NewAdbooking.classesoracle.AdCategoryMaster();
                ds = chkedition.chkedit(edition, adcatcode);
            }
            else
            {
                NewAdbooking.classmysql.AdCategoryMaster chkedition = new NewAdbooking.classmysql.AdCategoryMaster();
                ds = chkedition.chkedit(edition, adcatcode);
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
        //else
        //{
        //    NewAdbooking.Classes.EditorMaster chkdate = new NewAdbooking.Classes.EditorMaster();
        //    DataSet ds = new DataSet();
        //    ds = chkdate.chkdaetedit(Session["compcode"].ToString(), edition);
        //    Session["firstdate"] = firstdate;
        //    Session["seconddate"] = seconddate;

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        date = "Y";
        //    }
        //    else
        //    {
        //        date = "N";

        //    }

        //    Response.Write(date);
        //    Response.End();

        //}



    }
}
