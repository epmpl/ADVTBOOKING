using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
public partial class proofrepubdetail : System.Web.UI.Page
{
    string output = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddenuserhome.Value = Session["userhome"].ToString();
            hiddenrevenue.Value = Session["Revenue"].ToString();
            hiddenadmin.Value = Session["Admin"].ToString();

            hdnusername.Value = Session["Username"].ToString();
        }
        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(proofrepubdetail));
        hiddenbooking_desc.Value = Request.QueryString["booking"].ToString();

        hiddenrono.Value = Request.QueryString["rono"].ToString();

    
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster objMatter = new NewAdbooking.classesoracle.BookingMaster();
            ds = objMatter.pudetail(hiddencompcode.Value, hiddenbooking_desc.Value, hiddenrono.Value);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            output += "<table class='fontboldreport' style='margin-left:250px;margin-top:150px;width:500px;background-color:Lime;align:center;' cellpadding='0'cellspacing='0' border='1'>";
            output += "<tr><td style='align:center;width:500px;font-size:15px;margin-left:25px;'>publication wise Details</td></tr></table>";
            output += "<table class='fontboldreport' style='margin-left:250px;width:500px;background-color:Lime;align:center;' cellpadding='0'cellspacing='0' border='1'>";
           
            output += "<tr><td  style='align:center;width:160px;font-size:12px;'>Booking Id</td><td  style='align:center;width:160px;font-size:12px;'>RO NO</td><td  style='align:center;width:160px;font-size:12px;'>File Name</td></tr><table>";
            for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            output += "<table class='fontboldreport' style='margin-left:250px;align:center; width:500px;'cellpadding='0'cellspacing='0' border='1'><tr>";
            output += "<td style='align:left;width:160px;font-size:10px;'>"+ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";
            output += "<td style='align:left;width:160px;font-size:10px;'>" + ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>";
            output += "<td style='align:left;width:160px;font-size:10px;'>" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td></tr></table>";
        }
        puvdiv11.InnerHtml = output;
    }
    }
    
}


