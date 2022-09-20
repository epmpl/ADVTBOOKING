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

public partial class Offline_Mode_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["access"] = "0";
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddenaccess.Value = Session["access"].ToString();

            Ajax.Utility.RegisterTypeForAjax(typeof(Offline_Mode_Report));
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/RO_Agency_Wise.xml"));
            //lbl_printcent.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            //lbl_branch.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            //lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            //lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            //lbl_district.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            //lbl_taluka.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            //lbl_agency.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            //lbl_rodoc_status.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            //lbl_paymode.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
            //lbl_destination.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            //BtnDetail.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            //BtnSummary.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
            //lbl_executive.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
            //lbl_retainer.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/offlinemode.xml"));
            lbl_agency.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            if (!IsPostBack)
            {
               
                binddest();        
                txt_agency.Attributes.Add("onkeypress", "javascript:return keySort(this);"); 
                txt_agency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr(event);");
                txt_agency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr(event);");
                lstagency.Attributes.Add("onclick", "javascript:return ClickAgaency(event);");
                lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaency(event);");              
               
                txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
                txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
                dpd_destination.Attributes.Add("onchange", "javascript:return excel_report1();");
                exe.Attributes.Add("onclick", "javascript:return enable_exe1();");
                csv.Attributes.Add("onclick", "javascript:return enable_csv1();");
                BtnRun.Attributes.Add("OnClick", "javascript:return run_report();");
                
               
            }
        }
    }
    [Ajax.AjaxMethod]
    public DataSet fillF2_CreditAgency(string compcol, string agen)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adagency = new NewAdbooking.Report.classesoracle.Class1();
            ds = adagency.agencyxls(compcol, agen);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adagency = new NewAdbooking.Report.Classes.Class1();
            ds = adagency.agencyxls(compcol, agen);
        }
        else 
        {
            string procedureName = "bindagencyforxls_bindagencyforxls_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcol, agen };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/frontend.xml"));
        dpd_destination.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        li1.Value = "0";
        li1.Selected = true;
        dpd_destination.Items.Add(li1);

        for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            dpd_destination.Items.Add(li);

        }


    }

    protected void BtnRun_Click(object sender, EventArgs e)
    {
       
        string chk_excel = "";
        if (dpd_destination.SelectedValue == "4")
        {
            if (exe.Checked == true)
            {
                chk_excel = "1";//excel
            }
            else
            {
                chk_excel = "2";//csv
            }

        }
        else
        {
            chk_excel = "0";//other than excel
        }

       
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Oddline_Mode_Report obj = new NewAdbooking.Report.classesoracle.Oddline_Mode_Report();
            ds = obj.run_offline(hdnagencycode.Value, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(),dpd_status.SelectedValue, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string strr = "";
            if (txtfrmdate.Text != "")
            {
                string[] strArr = txtfrmdate.Text.Split('/');
                strr = strArr[1] + "/" + strArr[0] + "/" + strArr[2];
            }
            else
            {
                strr = txtfrmdate.Text;
            }

            string strr1 = "";
            if (txttodate1.Text != "")
            {
                string[] strArr1 = txttodate1.Text.Split('/');
                strr1 = strArr1[1] + "/" + strArr1[0] + "/" + strArr1[2];
            }
            else
            {
                strr1 = txttodate1.Text;
            }

            NewAdbooking.Report.Classes.RO_Agency_Wise obj = new NewAdbooking.Report.Classes.RO_Agency_Wise();
            ds = obj.run_offline(hdnagencycode.Value, strr, strr1, Session["compcode"].ToString(), dpd_status.SelectedValue, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
        }

        else 
        {
            string procedureName = "offline_report";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { hdnagencycode.Value, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dpd_status.SelectedValue, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }


        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Offline_Mode_Report), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {

            Session["offline_report"] = ds;
            Session["offline_parameter"] = "fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~destination~" + dpd_destination.SelectedValue + "~agency_code~" + hdnagencycode.Value + "~agency_name~" + txt_agency.Text + "~chk_excel~" + chk_excel + "~status~" + dpd_status.SelectedValue;
            Response.Redirect("Offline_Mode_Report_View.aspx");
         }



    }
}
