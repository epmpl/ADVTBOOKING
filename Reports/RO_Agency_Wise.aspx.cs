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
using System.Diagnostics;


public partial class RO_Agency_Wise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value= Session["userid"].ToString();
            hiddenaccess.Value=   Session["access"].ToString();

            Ajax.Utility.RegisterTypeForAjax(typeof(RO_Agency_Wise));
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/RO_Agency_Wise.xml"));
            lbl_printcent.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            lbl_branch.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            lbl_district.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            lbl_taluka.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            lbl_agency.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            lbl_rodoc_status.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            lbl_paymode.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
            lbl_destination.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            BtnDetail.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            BtnSummary.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
            lbl_executive.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
            lbl_retainer.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
            lbl_adtype.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
            lbl_adcat.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
            lbl_type.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
            lblbased.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
            if (!IsPostBack)
            {
                bindprintcent();
                bindbranch();
                binddistrict();
                binddest();
                bind_paymode();
                bind_rodoc();
                bind_dpd();
                bindtype();
                
                bindadtype();

                bindadtypesub();

                dpd_district.Attributes.Add("onchange", "javascript:return bind_taluka();");
                dpd_printcent.Attributes.Add("onchange", "javascript:return bind_pubcentbranch();");
                dpd_printcent.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                dpd_branch.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                dpd_district.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                dpd_taluka.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                txt_agency.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                dpd_rodoc_status.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                dpd_paymode.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                txt_executive.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                txt_retainer.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                txt_agency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr(event);");
                txt_agency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr(event);");
                lstagency.Attributes.Add("onclick", "javascript:return ClickAgaency(event);");
                lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaency(event);");

                txt_executive.Attributes.Add("onkeydown", "javascript:return F2fillexecutivecr(event);");
                txt_executive.Attributes.Add("onkeypress", "javascript:return F2fillexecutivecr(event);");

                lstexecutive.Attributes.Add("onclick", "javascript:return Clickexecutive(event);");
                lstexecutive.Attributes.Add("onkeydown", "javascript:return Clickexecutive(event);");

                txt_retainer.Attributes.Add("onkeydown", "javascript:return F2fillretainercr(event);");
                txt_retainer.Attributes.Add("onkeypress", "javascript:return F2fillretainercr(event);");

                lstretainer.Attributes.Add("onclick", "javascript:return Clickretainer(event);");
                lstretainer.Attributes.Add("onkeydown", "javascript:return Clickretainer(event);");

                //radio_agency.Attributes.Add("onclick", "javascript:return rad_chk1(this);");
                //radio_exe_ret.Attributes.Add("onclick", "javascript:return rad_chk1(this);");
                drp_chk.Attributes.Add("onchange", "javascript:return rad_chk();");

                BtnDetail.Attributes.Add("onclick", "javascript:return run_report(1);");
                BtnSummary.Attributes.Add("onclick", "javascript:return run_report(2);");

                txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
                txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");

                dpd_destination.Attributes.Add("onchange", "javascript:return excel_report1();");
                exe.Attributes.Add("onclick", "javascript:return enable_exe1();");
                csv.Attributes.Add("onclick", "javascript:return enable_csv1();");
                dpd_adtype.Attributes.Add("onchange", "javascript:return bindadcat();");

                dpd_adcat.Attributes.Add("onchange", "javascript:return bindadcatsub();");
                
                ListItem li64;
                li64 = new ListItem();
                li64.Text = "Select Taluka";
                li64.Value = "0";
                dpd_taluka.Items.Add(li64);
            }
        }

    }
    [Ajax.AjaxMethod]
    public DataSet fillQBC(string pubcenter)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { pubcenter };
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.RO_Agency_Wise exec = new NewAdbooking.Report.classesoracle.RO_Agency_Wise();
                ds = exec.getQBC(pubcenter);
            }
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Report.Classes.RO_Agency_Wise exec = new NewAdbooking.Report.Classes.RO_Agency_Wise();
                ds = exec.getQBC(pubcenter);
            }
            else
            {
                string procedureName = "websp_QBC_websp_QBC_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        return ds;

    }
    public void bind_dpd()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/RO_Agency_Wise.xml"));
        drp_chk.Items.Clear();
        int i;
       // drp_chk.Items.Add(li1);

        for (i = 0; i < destination.Tables[3].Columns.Count ; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[3].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[3].Rows[0].ItemArray[i].ToString();
            drp_chk.Items.Add(li);

        }

        
    }
    public void bindadtype()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advname = new NewAdbooking.Report.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advname = new NewAdbooking.Report.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select AdType";
        li1.Value = "0";
        li1.Selected = true;
        dpd_adtype.Items.Add(li1);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpd_adtype.Items.Add(li);


        }
    }
    [Ajax.AjaxMethod]
    public DataSet adcatbnd(string adtype, string compcode)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { adtype, compcode };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
            ds = adcat.advtype(adtype, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.advtype(adtype, compcode);
        }
        else
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;

    }
    public void bindtype()
    {
        DataSet type = new DataSet();
        type.ReadXml(Server.MapPath("XML/RO_Agency_Wise.xml"));        
        dpd_type.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Type--";
        li1.Value = "0";
        li1.Selected = true;
        dpd_type.Items.Add(li1);

        for (i = 0; i < type.Tables[4].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = type.Tables[4].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = type.Tables[4].Rows[0].ItemArray[i].ToString();
            dpd_type.Items.Add(li);

        }
        /////bind ad cat
        dpd_adcat.Items.Clear();
        ListItem li2;
        li2 = new ListItem();
        li2.Text = "Select AdCat";
        li2.Value = "0";
        li2.Selected = true;
        dpd_adcat.Items.Add(li2);


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
    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditexecutive(string compcol, string exectv)
    {
        string tname = "", userid = "";

        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcol, exectv };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister exec = new NewAdbooking.Report.classesoracle.billregister();
            ds = exec.executivexls(compcol, userid, tname, exectv);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 exec = new NewAdbooking.Report.Classes.Class1();
            ds = exec.executivexls(compcol, userid, tname, exectv);
        }
        else
        {
            string procedureName = "xlsBindexecnew_xlsBindexecnew_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditretainer(string compcol, string ret)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcol, ret };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SHACHIREPORT objregion = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
            ds = objregion.retainerxls(compcol, ret);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.retainerxls(compcol, ret);
        }

        else
        {
            string procedureName = "xlsRetainerbind_xlsRetainerbind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
  
    [Ajax.AjaxMethod]
    public DataSet fillF2_CreditAgency(string compcol, string agen)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcol, agen };
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
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindtaluka(string compcode, string district)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, district };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 objprod = new NewAdbooking.Report.classesoracle.Class1();
            ds = objprod.talukabind(compcode, district);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objprod = new NewAdbooking.Report.Classes.Class1();
            ds = objprod.talukabind(compcode, district);
        }
        else
        {
            string procedureName = "BINDTALUKA_BINDTALUKA_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;

    }
    public void bindprintcent()
    {
        DataSet ds = new DataSet();
        //string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString() };
        string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }
        else
        {
            string procedureName = "Bind_PubCentName_r_Bind_PubCentName_r_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select Printing Center";
        li.Selected = true;
        dpd_printcent.Items.Add(li);
        
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpd_printcent.Items.Add(li1);


        }
    }
    public void bindbranch()
    {
       
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select Branch";
        li.Selected = true;
        dpd_branch.Items.Add(li);



    }
    public void bind_paymode()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.RO_Agency_Wise pub = new NewAdbooking.Report.classesoracle.RO_Agency_Wise();
            ds = pub.bindpaymode(Session["compcode"].ToString());
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.RO_Agency_Wise pub = new NewAdbooking.Report.Classes.RO_Agency_Wise();
            ds = pub.bindpaymode(Session["compcode"].ToString());
        }
         else
        {
            string procedureName = "an_payment_an_payment_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select Pay Mode";
        li.Selected = true;
        dpd_paymode.Items.Add(li);



        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpd_paymode.Items.Add(li1);
        }

    }
    public void bind_rodoc()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/RO_Agency_Wise.xml"));
       
        dpd_rodoc_status.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select R.O. Doc Status";
        li1.Value = "0";
        li1.Selected = true;
        dpd_rodoc_status.Items.Add(li1);

        for (i = 0; i < ds.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            dpd_rodoc_status.Items.Add(li);
        }


    }
    public void binddistrict()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
        ds = pub.district(Session["compcode"].ToString(),Session["userid"].ToString());
         }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.district(Session["compcode"].ToString(), Session["userid"].ToString());

        }
        else
        {
            string procedureName = "CityMst_District_CityMst_District_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select District";
        li.Selected = true;
        dpd_district.Items.Add(li);
        
            
        

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpd_district.Items.Add(li1);
        }
        
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
      public DataSet btn_click(string compcode, string dateformat, string user_id, string access, string from_date, string to_date, string print_cent, string agency_code, string branch, string district, string taluka, string ro_doc_status, string pay_mode, string exe_code, string ret_code, string det_sum, string str, string desti, string chk_excel, string branch_code, string type, string ad_type, string ad_cat, string print_cent_name, string taluka_name, string agency_name, string exe_name, string ret_name, string adtyp_name, string adcat_name, string typ_name, string rodoc_status_name, string paymode_name, string dtbased, string adsubcat, string rpttype, string extra1, string extra2)
    {
        DataSet ds = new DataSet();
		if(ad_cat == "Select AdCat")
        {
            ad_cat = "";
        }
        if (access == "0")              { access = ""; }
        if (print_cent == "0")          { print_cent = ""; }
        if (branch == "Select Branch")  { branch = ""; }
        if (district == "Select District") { district = ""; }
        if (taluka == "0")          { taluka = "";          }
        if (ro_doc_status == "0")   { ro_doc_status = "";   }
        if (pay_mode == "0")        { pay_mode = "";        }
        if (exe_code == "0")        { exe_code = "";        }
        if (type == "0")            { type = "";            }
        if (ad_type == "0")         { ad_type = "";         }
        if (ad_cat == "0")          { ad_cat = "";          }
        if (adsubcat == "0")        { adsubcat = "";        }


        if (rpttype == "0")
        {
            string[] parameterValueArray = new string[] { compcode, dateformat, user_id, access, from_date, to_date, print_cent, agency_code, branch, district, taluka, ro_doc_status, pay_mode, exe_code, ret_code, det_sum, str, type, ad_type, ad_cat, dtbased, adsubcat, rpttype, extra1, extra2 };
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.RO_Agency_Wise obj = new NewAdbooking.Report.classesoracle.RO_Agency_Wise();
                ds = obj.ro_report(compcode, dateformat, user_id, access, from_date, to_date, print_cent, agency_code, branch, district, taluka, ro_doc_status, pay_mode, exe_code, ret_code, det_sum, str, type, ad_type, ad_cat, dtbased, adsubcat, rpttype, extra1, extra2);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                string[] strArr = from_date.Split('/');
                string strr = strArr[1] + "/" + strArr[0] + "/" + strArr[2];

                string[] strArr1 = to_date.Split('/');
                string strr1 = strArr1[1] + "/" + strArr1[0] + "/" + strArr1[2];

                NewAdbooking.Report.Classes.RO_Agency_Wise obj = new NewAdbooking.Report.Classes.RO_Agency_Wise();
                ds = obj.ro_report(compcode, dateformat, user_id, access, strr, strr1, print_cent, agency_code, branch, district, taluka, ro_doc_status, pay_mode, exe_code, ret_code, det_sum, str, type, ad_type, ad_cat, dtbased);
            }
            else
            {

                string procedureName = "Ro_Report";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, dateformat, user_id, access, from_date, to_date, print_cent, agency_code, branch, district, taluka, ro_doc_status, pay_mode, exe_code, ret_code, det_sum, str, type, ad_type, ad_cat, dtbased, adsubcat, rpttype, extra1, extra2 };
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.RO_Agency_Wise obj = new NewAdbooking.Report.classesoracle.RO_Agency_Wise();
                ds = obj.ro_reportfirstins(compcode, dateformat, user_id, access, from_date, to_date, print_cent, agency_code, branch, district, taluka, ro_doc_status, pay_mode, exe_code, ret_code, det_sum, str, type, ad_type, ad_cat, dtbased, adsubcat, rpttype, extra1, extra2);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                string[] strArr = from_date.Split('/');
                string strr = strArr[1] + "/" + strArr[0] + "/" + strArr[2];

                string[] strArr1 = to_date.Split('/');
                string strr1 = strArr1[1] + "/" + strArr1[0] + "/" + strArr1[2];

                NewAdbooking.Report.Classes.RO_Agency_Wise obj = new NewAdbooking.Report.Classes.RO_Agency_Wise();
                ds = obj.ro_report(compcode, dateformat, user_id, access, strr, strr1, print_cent, agency_code, branch, district, taluka, ro_doc_status, pay_mode, exe_code, ret_code, det_sum, str, type, ad_type, ad_cat, dtbased);
            }
             else
            {

                string procedureName = "ro_report_firstinsertionamt_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

        }

       
        
     
         Session["roreport"] = ds;
         Session["roparameter"] = "fromdate~" + from_date + "~todate~" + to_date + "~printcent~" + print_cent + "~agency~" + agency_code + "~branch~" + branch_code + "~district~" + district + "~taluka~" + taluka + "~rodoc_status~" + ro_doc_status + "~paymode~" + pay_mode + "~executive~" + exe_code + "~retainer~" + ret_code + "~det_summ~" + det_sum + "~age_exeret~" + str + "~branch_name~" + branch + "~destination~" + desti + "~chk_excel~" + chk_excel + "~print_cent_name~" + print_cent_name + "~taluka_name~" + taluka_name + "~agency_name~" + agency_name + "~exe_name~" + exe_name + "~ret_name~" + ret_name + "~typ_name~" + typ_name + "~adtyp_name~" + adtyp_name + "~adcat_name~" + adcat_name + "~rodoc_status_name~" + rodoc_status_name + "~paymode_name~" + paymode_name + "~rpttype~" + rpttype;
         return ds;
        
       
    }



    // add by sourabh

    public void bindadtypesub()
    {
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select AdCat Sub";
        li1.Value = "0";
        li1.Selected = true;
        dpd_adcatsub.Items.Add(li1);
    }

    [Ajax.AjaxMethod]
    public DataSet bind_adsubcat(string newstr, string newstr1)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { newstr, newstr1 };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SHACHIREPORT adsubcat = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
            ds = adsubcat.bindadsubcat(newstr);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adsubcat = new NewAdbooking.Report.Classes.Class1();
            ds = adsubcat.bindadsubcat(newstr);
        }
        else
        {
            string procedureName = "adsubcategory_adsubcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }



    // protected void BtnDetail_Click(object sender, EventArgs e)
    //{
    //     string str="";
    //     if (radio_agency.Checked == true)
    //         str = "1";
    //     else
    //         str = "2";

    //     string chk_excel = "";
    //     if (dpd_destination.SelectedValue == "4")
    //     {
    //         if (exe.Checked == true)
    //         {
    //             chk_excel = "1";//excel
    //         }
    //         else
    //         {
    //             chk_excel = "2";//csv
    //         }

    //     }
    //     else
    //     {
    //         chk_excel = "0";//other than excel
    //     }
    //   DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {  
    //        NewAdbooking.Report.classesoracle.RO_Agency_Wise obj = new NewAdbooking.Report.classesoracle.RO_Agency_Wise();
    //        ds = obj.ro_report(hiddencompcode.Value, hiddendateformat.Value, hiddenuserid.Value, Session["access"].ToString(), txtfrmdate.Text, txttodate1.Text, dpd_printcent.SelectedValue, hdnagencycode.Value, dpd_branch.SelectedItem.Text, dpd_district.SelectedItem.Text, hdntaluka.Value , dpd_rodoc_status.SelectedValue, dpd_paymode.SelectedValue, hdnexecode.Value, hdnretcode.Value, "1", str);
    //    }

    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, typeof(RO_Agency_Wise), "sa", "alert(\"searching criteria is not valid\");", true);
    //        radio_agency.Checked=true;
    //        radio_exe_ret.Checked = false;
    //        txt_agency.Text = "";
    //        txt_executive.Text = "";
    //        txt_retainer.Text = "";
    //        hdnagencycode.Value = "";
    //        hdnexecode.Value = "";
    //        hdnretcode.Value = "";
    //        return;
    //    }
    //    else
    //    {


    //        Session["roreport"] = ds;
    //        Session["roparameter"] = "fromdate~" + txtfrmdate.Text + "~todate~" + txttodate1.Text + "~printcent~" + dpd_printcent.SelectedValue + "~agency~" + hdnagencycode.Value + "~branch~" + dpd_branch.SelectedValue + "~district~" + dpd_district.SelectedValue + "~taluka~" + hdntaluka.Value + "~rodoc_status~" + dpd_rodoc_status.SelectedValue + "~paymode~" + dpd_paymode.SelectedValue + "~executive~" + hdnexecode.Value + "~retainer~" + hdnretcode.Value + "~det_summ~" + "1" + "~age_exeret~" + str + "~branch_name~" + dpd_branch.SelectedItem.Text + "~destination~" + dpd_destination.SelectedValue + "~chk_excel~" + chk_excel;
           
    //        if (dpd_destination.SelectedValue == "4")
    //        {
    //            Response.Redirect("RO_Agency_Wise_View.aspx");
               
    //        }
    //        else
    //            ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('RO_Agency_Wise_View.aspx')</script>");
           
          
            
    //    }

    //}
    //protected void BtnSummary_Click(object sender, EventArgs e)
    //{
    //    string str = "";
    //    if (radio_agency.Checked == true)
    //        str = "1";
    //    else
    //        str = "2";

    //    string chk_excel = "";
    //    if (dpd_destination.SelectedValue == "4")
    //    {
    //        if (exe.Checked == true)
    //        {
    //            chk_excel = "1";//excel
    //        }
    //        else
    //        {
    //            chk_excel = "2";//csv
    //        }

    //    }
    //    else
    //    {
    //        chk_excel = "0";//other than excel
    //    }
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.Report.classesoracle.RO_Agency_Wise obj = new NewAdbooking.Report.classesoracle.RO_Agency_Wise();
    //        ds = obj.ro_report(hiddencompcode.Value, hiddendateformat.Value, hiddenuserid.Value, Session["access"].ToString(), txtfrmdate.Text, txttodate1.Text, dpd_printcent.SelectedValue, hdnagencycode.Value, dpd_branch.SelectedItem.Text, dpd_district.SelectedItem.Text, hdntaluka.Value, dpd_rodoc_status.SelectedValue, dpd_paymode.SelectedValue, hdnexecode.Value, hdnretcode.Value, "2", str);
    //    }

    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, typeof(RO_Agency_Wise), "sa", "alert(\"searching criteria is not valid\");", true);
    //        radio_agency.Checked = true;
    //        radio_exe_ret.Checked = false;
    //        txt_agency.Text = "";
    //        txt_executive.Text = "";
    //        txt_retainer.Text = "";
    //        hdnagencycode.Value = "";
    //        hdnexecode.Value = "";
    //        hdnretcode.Value = "";
    //        return;
    //    }
    //    else
    //    {
            

    //        Session["roreport"] = ds;
    //        Session["roparameter"] = "fromdate~" + txtfrmdate.Text + "~todate~" + txttodate1.Text + "~printcent~" + dpd_printcent.SelectedValue + "~agency~" + hdnagencycode.Value + "~branch~" + dpd_branch.SelectedValue + "~district~" + dpd_district.SelectedValue + "~taluka~" + hdntaluka.Value + "~rodoc_status~" + dpd_rodoc_status.SelectedValue + "~paymode~" + dpd_paymode.SelectedValue + "~executive~" + hdnexecode.Value + "~retainer~" + hdnretcode.Value + "~det_summ~" + "2" + "~age_exeret~" + str + "~branch_name~" + dpd_branch.SelectedItem.Text + "~destination~" + dpd_destination.SelectedValue + "~chk_excel~" + chk_excel;
    //        if (dpd_destination.SelectedValue == "4")
    //        {
    //            Response.Redirect("RO_Agency_Wise_View.aspx");

    //        }
    //        else
    //            ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('RO_Agency_Wise_View.aspx')</script>");
           
    //    }


    //}

   
}
