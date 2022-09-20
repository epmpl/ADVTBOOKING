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

public partial class chkpkgrate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string flag = "";

        string adtype = Request.QueryString["adtype"].ToString();
        string adcategory = Request.QueryString["adcat"].ToString();
        string color = Request.QueryString["color"].ToString();
        string adscat = Request.QueryString["adsucat"].ToString();
        string curr = Request.QueryString["currency"].ToString();
        string ratcod = Request.QueryString["ratecode"].ToString();
        string pack = Request.QueryString["package1"].ToString();
        //string chkdate = Request.QueryString["selecdate"].ToString();
        string compcode = Session["compcode"].ToString();
        string uom = Request.QueryString["uomvalue"].ToString();
        string premium = Request.QueryString["prem_insert"].ToString();
        try
        {

            NewAdbooking.Classes.BookingMaster rate = new NewAdbooking.Classes.BookingMaster();
            DataSet dr = new DataSet();
            dr = rate.getrateforprmpkg(adtype, color, adcategory, adscat, curr, ratcod, pack,  compcode, uom, premium);

            if (dr.Tables[0].Rows.Count > 0)
            {
                flag = "1";
            }
            else
            {
                flag = "0";
            }

        }
        catch (Exception ex)
        {
            flag = "0";
            Response.Write(flag);
            Response.End();



        }
        Response.Write(flag);
        Response.End();

    }
}
