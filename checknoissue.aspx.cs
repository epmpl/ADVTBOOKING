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

public partial class checknoissue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        
        string value = "", value1 = "", compcode, userid;

        string issuecode = Request.QueryString["issuecode"].ToString();
        string noissuecode = Request.QueryString["nocode"].ToString();
        string date1 = Request.QueryString["date1"].ToString();
        string check= Request.QueryString["page"].ToString();
        string dateformat = Request.QueryString["dateformat"].ToString();
        string code = Request.QueryString["hiddencode"].ToString();
        datesave ac = new datesave();
        string date = ac.getDate(dateformat, date1);

        string center = "N";

        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();

        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        compcode = Session["compcode"].ToString();
      
        if (check == "save")
        {
            Session["drop"] = noissuecode;
            Session["date1"] = date;
        }
        else
        {
            Session["drop"] = "";
            Session["date1"] = "";
        }

        if (compcode != "" && Session["drop"] != "" && code!="undefined")
        {

          
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.NoIssueMaster chkname = new NewAdbooking.Classes.NoIssueMaster();
                ds = chkname.chkissue3(issuecode, noissuecode, compcode, date, dateformat,code);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.NoIssueMaster chkname = new NewAdbooking.classesoracle.NoIssueMaster();
                ds = chkname.chkissue3(issuecode, noissuecode, compcode, date, dateformat, code);
            }
            // return ds;
            else
            {
                NewAdbooking.classmysql.NoIssueMaster chkname = new NewAdbooking.classmysql.NoIssueMaster();
                ds = chkname.chkissue3(issuecode, noissuecode, compcode, date, dateformat, code);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                center = "Y";
                // value = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                // value1 = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            }
            else
            {
                center = "N";
                //value = "";
                // value1 = "";
            }
            Response.Write(center);
            //Response.Write(value1);
            Response.End();
        }
        //string supplement = Request.QueryString["supplement"].ToString();
        //string date = "N";
        //string firstdate = Request.QueryString["date1"].ToString();
        //string seconddate = Request.QueryString["date2"].ToString();

        //if (supplement == "" && periodicty != "")
        //{
        //    NewAdbooking.Classes.SupplimentMaster chkperiodicty = new NewAdbooking.Classes.SupplimentMaster();
        //    DataSet ds = new DataSet();
        //    ds = chkperiodicty.chkperiodicty(periodicty);
        //    if (ds.Tables[0].Rows.Count >= 0)
        //    {
        //        value = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        //    }
        //    else
        //    {
        //        value = "";
        //    }
        //    Response.Write(value);
        //    Response.End();
        //}
        //else
        //{
        //    NewAdbooking.Classes.SupplimentMaster chkdate = new NewAdbooking.Classes.SupplimentMaster();
        //    DataSet ds = new DataSet();
        //    ds = chkdate.chkdaetedit(Session["compcode"].ToString(), supplement);
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
