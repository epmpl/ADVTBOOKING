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

public partial class chkpackagesolo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string flag = "noextrarate";
        string adtype = Request.QueryString["adtype"].ToString();
        string adcategory = Request.QueryString["adcat"].ToString();
        string color = Request.QueryString["color"].ToString();
        string adscat = Request.QueryString["adsucat"].ToString();
        string curr = Request.QueryString["currency"].ToString();
        string ratcod = Request.QueryString["ratecode"].ToString();
        string pack = Request.QueryString["package1"].ToString();
        string chkdate = Request.QueryString["selecdate"].ToString();
        string compcode = Session["compcode"].ToString();
        string uom = Request.QueryString["uomvalue"].ToString();
        string premium = Request.QueryString["prem_insert"].ToString();
        string line = Request.QueryString["line"].ToString();
        string insert = Request.QueryString["insert"].ToString();
        string clientname = Request.QueryString["clientname"].ToString();
        string adcat3 = Request.QueryString["adcat3"].ToString();
        string adcat4 = Request.QueryString["adcat4"].ToString();
        string adcat5 = Request.QueryString["adcat5"].ToString();
        string editionsolo = Request.QueryString["editionsolo"].ToString();

        try
        {
            NewAdbooking.Classes.BookingMaster rate = new NewAdbooking.Classes.BookingMaster();
            DataSet dr = new DataSet();
            dr = rate.class_chklinerate(adtype, color, adcategory, adscat, curr, ratcod, pack, chkdate, compcode, uom, insert, line, premium, adcat3, adcat4, adcat5, clientname, editionsolo);

            if (dr.Tables[0].Rows.Count > 0)
            {
                flag = dr.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else
            {
                flag = "noextrarate";
            }
        }


        catch (Exception ex)
        {
            flag = "noextrarate";
            Response.Write(flag);
            Response.End();



        }
        Response.Write(flag);
        Response.End();


    }
}
