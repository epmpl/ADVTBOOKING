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

public partial class reportmenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();

        }
        Ajax.Utility.RegisterTypeForAjax(typeof(reportmenu));

        if (dpdpubcentpermit.SelectedValue == "0")
        {
            Session["access"] = "0";
        }
        else
        {
            Session["access"] = "1";
        }
        
        hiddenconnection.Value = ConfigurationSettings.AppSettings["ConnectionType"].ToString();
        DataSet dstreexml = new DataSet();
        dstreexml.ReadXml(Server.MapPath("XML/reportstatus.xml"));

        if (dstreexml.Tables[0].Rows[0].ItemArray[0].ToString() != "enable")
        {
            all_day.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[1].ToString() != "enable")
        {
            all_agency.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[2].ToString() != "enable")
        {
            all_client.Style.Add("display", "none");
        }
    
          
         if (dstreexml.Tables[0].Rows[0].ItemArray[3].ToString() != "enable")
        {
            status_based.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[4].ToString() != "enable")
        {
            deviation.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[5].ToString() != "enable")
        {
            page_prem.Style.Add("display", "none");
        }
      
         if (dstreexml.Tables[0].Rows[0].ItemArray[6].ToString() != "enable")
        {
            issuewise.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[7].ToString() != "enable")
        {
            revenuesummary.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[8].ToString() != "enable")
        {
            topagencli.Style.Add("display", "none");
        }

         if (dstreexml.Tables[0].Rows[0].ItemArray[39].ToString() != "enable")
         {
             issue_billreport.Style.Add("display", "none");
         }


         if (dstreexml.Tables[0].Rows[0].ItemArray[9].ToString() != "enable")
        {
            executive_wise.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[10].ToString() != "enable")
        {
            available_prem.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[11].ToString() != "enable")
        {
            category_wise.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[12].ToString() != "enable")
        {
            status_wise_daily.Style.Add("display", "none");
        }


         if (dstreexml.Tables[0].Rows[0].ItemArray[13].ToString() != "enable")
        {
            pi_reports.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[14].ToString() != "enable")
        {
            pi_contract.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[15].ToString() != "enable")
        {
            exe_ret_wise.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[16].ToString() != "enable")
        {
            schedule_report.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[17].ToString() != "enable")
        {
            complete_report.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[18].ToString() != "enable")
        {
            net_amt_report.Style.Add("display", "none");
        }
         

         if (dstreexml.Tables[0].Rows[0].ItemArray[19].ToString() != "enable")
        {
            bill_register.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[20].ToString() != "enable")
        {
            booking_type_report.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[21].ToString() != "enable")
        {
            rebate_report.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[22].ToString() != "enable")
        {
            retainer_commission.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[23].ToString() != "enable")
        {
            money_report.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[24].ToString() != "enable")
        {
            A1.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[25].ToString() != "enable")
        {
            A2.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[26].ToString() != "enable")
        {
            ro_agency.Style.Add("display", "none");
        }
         if (dstreexml.Tables[0].Rows[0].ItemArray[27].ToString() != "enable")
        {
            vts_report.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[28].ToString() != "enable")
        {
            booking_report.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[29].ToString() != "enable")
        {
            issue_edition.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[30].ToString() != "enable")
        {
            catg_report.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[31].ToString() != "enable")
        {
            billing_report.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[32].ToString() != "enable")
        {
            weekly_report.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[33].ToString() != "enable")
        {
            dealreport.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[34].ToString() != "enable")
        {
            unregistered_client.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[35].ToString() != "enable")
        {
            boxregister.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[36].ToString() != "enable")
        {
            auditor_comment.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[37].ToString() != "enable")
        {
            attendence_report.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[38].ToString() != "enable")
        {
            ad_rep_roapproval_detail.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[39].ToString() != "enable")
        {
            reotype.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[39].ToString() != "enable")
        {
            ctrdatereport.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[40].ToString() != "enable")
        {
            ctrdatereport.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[42].ToString() != "enable")
        {
            eyecater_report.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[43].ToString() != "enable")
        {
            CrditDebit.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[44].ToString() != "enable")
        {
            qbc_alleditions_rpt.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[47].ToString() != "enable")
        {
            admasterreport.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[48].ToString() != "enable")
        {
            all_mast.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[49].ToString() != "enable")
        {
            invoice.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[50].ToString() != "enable")
        {
            consolidated.Style.Add("display", "none");
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[53].ToString() != "enable")
        {
            bookingmaterialdata.Style.Add("display", "none");
        }


        //if (dstreexml.Tables[0].Rows[0].ItemArray[41].ToString() != "enable")
        //{
        //    A5.Style.Add("display", "none");
        //}
      

        //a_All_ad_.Style.Add("display", "none");


        if (!Page.IsPostBack)
        {
            bindpermit();
            lblprefer.Attributes.Add("onclick", "javascript:return reportprefer();");
        }
    }
    public void bindpermit()
    {
        DataSet dz = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 upd = new NewAdbooking.Report.classesoracle.Class1();
            dz = upd.selectreport(Session["compcode"].ToString());

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 upd = new NewAdbooking.Report.Classes.Class1();
            dz = upd.selectreport(Session["compcode"].ToString());

        }
        else
        {
            string procedureName = "select_report_prefer_select_report_prefer_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            dz = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (dz.Tables[0].Rows.Count > 0)
        {
            if (dz.Tables[0].Rows[0].ItemArray[1].ToString() == "0")
            {
                Session["access"] = "0";
            }
            else
            {
                Session["access"] = "1";
            }
        }
        else
        {
            Session["access"] = "0";
        }
    }
 
    [Ajax.AjaxMethod]
    public DataSet chk_permission(string comp_code, string user_id, string form_name)
    {
        DataSet dz = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();
            dz = checkform.formpermission(comp_code, user_id, form_name);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
            dz = checkform.formpermission(comp_code, user_id, form_name);

        }
        else
        {
            NewAdbooking.classmysql.Master checkform = new NewAdbooking.classmysql.Master();
            dz = checkform.formpermission(comp_code, user_id, form_name);


        }
        return dz;
    }
}
