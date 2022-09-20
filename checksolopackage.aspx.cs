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

public partial class checksolopackage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        string ratecode = Request.QueryString["ratecode"].ToString();
        string packagecode = Request.QueryString["packagecode"].ToString(); ;
        string color = Request.QueryString["color"].ToString(); ;
        string adtypecode = Request.QueryString["adtypecode"].ToString(); ;
        string adcatcode = Request.QueryString["adcatcode"].ToString(); ;
        string adsucode = Request.QueryString["adsucatcode"].ToString(); ;
        string currcode = Request.QueryString["currcode"].ToString(); ;
        string validfrom = Request.QueryString["validfrom"].ToString(); ;
        string validto = Request.QueryString["validto"].ToString(); ;
        string dateformat = Session["dateformat"].ToString();

        string flag = "";

        datesave getdatechk = new datesave();
        string validfromdate = getdatechk.getDate(dateformat, validfrom);
        string validtill = getdatechk.getDate(dateformat, validto);

        NewAdbooking.Classes.RateMaster chksolopackage = new NewAdbooking.Classes.RateMaster();
        DataSet ds = new DataSet();
        ds = chksolopackage.modsolpack(Session["compcode"].ToString(), ratecode, adtypecode, adcatcode, adsucode, color, packagecode, currcode, validfromdate, validtill);

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[1].Rows.Count > 1)
            {
                flag = "1";

            }
            else
            {
                flag = "0";
            }
        }
        else
        {
            flag = "0";
        }

        Response.Write(flag);
        Response.End();

    }
}
