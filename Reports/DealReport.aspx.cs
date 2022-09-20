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
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class DealReport : System.Web.UI.Page
{
    string date, day, month, year; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            Session["access"] = "0";
            hiddendateformat.Value = Session["dateformat"].ToString();
            hdncompcode.Value = Session["compcode"].ToString();
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(DealReport));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/DealReport.xml"));
        heading.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbAdtype.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbadcatgory.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lbl_agency.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblclient.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbldealtype.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblpackage.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbratecode.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lblstatus.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {

            DateTime dt = System.DateTime.Now;


            day = dt.Day.ToString();
            if (day.Length == 1)
                day = "0" + day;
            month = dt.Month.ToString();
            if (month.Length == 1)
                month = "0" + month;
            year = dt.Year.ToString();
            date = day + "/" + month + "/" + year;

        }
        else
            if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                if (day.Length == 1)
                    day = "0" + day;
                month = dt.Month.ToString();
                if (month.Length == 1)
                    month = "0" + month;
                year = dt.Year.ToString();
                date = month + "/" + day + "/" + year;

            }
            else
            //if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                if (day.Length == 1)
                    day = "0" + day;
                month = dt.Month.ToString();
                if (month.Length == 1)
                    month = "0" + month;
                year = dt.Year.ToString();
                date = year + "/" + month + "/" + day;

            }
        if(txtfrmdate.Text=="")
            txtfrmdate.Text = date;

        if (!IsPostBack)
        {
            bindadvtype();
            binddest();
            binddealtype();
            bindratecode();

            BtnRun.Attributes.Add("OnClick", "javascript:return chkmand();");

            dpaddtype.Attributes.Add("onchange", "javascript:return bindadcategory();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txtclient.Attributes.Add("onkeydown", "javascript:return F2fillclientcr_dev(event);");
            txtagency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr_dev(event);");
            lstclient.Attributes.Add("onclick", "javascript:return Clickclientaa(event);");
            lstclient.Attributes.Add("onkeydown", "javascript:return Clickclientaa(event);");
            lstagency.Attributes.Add("onclick", "javascript:return ClickAgaencybb(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaencybb();");
            drppackage.Attributes.Add("onchange", "javascript:return getpackagecode();");
            noofdatys.Attributes.Add("OnChange", "javascript:return calculatenextdate();");
        }
    }

    public void bindratecode()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.DealReport advname = new NewAdbooking.Report.Classes.DealReport();
            ds = advname.bindratecode(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "ADB_BINDRATECODE";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(),null,null };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.Report.classesoracle.DealReport advname = new NewAdbooking.Report.classesoracle.DealReport();
            ds = advname.bindratecode(Session["compcode"].ToString());
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select RateCode--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpratecode.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpratecode.Items.Add(li);


        }
    }
    public void binddealtype()
    {
        DataSet df = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindtype = new NewAdbooking.Classes.Contract();
            df = bindtype.binddeal(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract bindtype = new NewAdbooking.classesoracle.Contract();
            df = bindtype.binddeal(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "binddealtype_binddealtype_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            df = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        drpdealtype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Deal-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpdealtype.Items.Add(li1);

        for (i = 0; i <= df.Tables[0].Rows.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = df.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = df.Tables[0].Rows[i].ItemArray[1].ToString();
            //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            drpdealtype.Items.Add(li);
        }
    }
    public void bindadvtype()
    {
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();


        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advname = new NewAdbooking.Report.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.Report.classesoracle.Class1 advname = new NewAdbooking.Report.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpaddtype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpaddtype.Items.Add(li);


        }
    }

    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        li1.Value = "0";
        li1.Selected = true;
        Txtdest.Items.Add(li1);

        for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            Txtdest.Items.Add(li);

        }


    }
    [Ajax.AjaxMethod]
    public DataSet adcatbnd(string adtype, string compcode)
    {
        DataSet ds = new DataSet();
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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "RA_bindadcategory_RA_bindadcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { adtype, compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet adpkg_bind(string adtype, string compcode)
    {

        DataSet ds4 = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds4 = adcat.package_report(compcode, adtype);
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat1 = new NewAdbooking.Report.classesoracle.Class1();
            ds4 = adcat1.package_report(compcode, adtype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "BINDPACKAGEREPORT_BINDPACKAGEREPORT_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, adtype };
            ds4 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds4;

    }
    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditclient(string compcol, string cli)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adagencycli = new NewAdbooking.Report.classesoracle.Class1();
            ds = adagencycli.clientxls(compcol, cli);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adagencycli = new NewAdbooking.Report.Classes.Class1();
            ds = adagencycli.clientxls(compcol, cli);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindclientforxls_bindclientforxls_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcol, cli };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindagencyforxls_bindagencyforxls_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcol, agen };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string str = "";
        string str1 = "";
        string pdate_flag="";
        str = hiddenadcat.Value;
        str1 = hiddenadcatname.Value;

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Report.Classes.DealReport obj = new NewAdbooking.Report.Classes.DealReport();
            ds = obj.getdealdata(hdncompcode.Value, dpaddtype.SelectedValue, hiddenadcat.Value, drpdealtype.SelectedValue, hdnagmaincode.Value, hdnagsubcode.Value, hdnclient1.Value, dppstatus.SelectedValue, hiddenpackage.Value, dpratecode.SelectedValue, txtfrmdate.Text, txttodate1.Text, pdate_flag, Session["userid"].ToString(), hiddendateformat.Value);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "rpt_deal_detail";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { hdncompcode.Value, dpaddtype.SelectedValue, hiddenadcat.Value, drpdealtype.SelectedValue, hdnagmaincode.Value, hdnagsubcode.Value, hdnclient1.Value, dppstatus.SelectedValue, hiddenpackage.Value, dpratecode.SelectedValue, txtfrmdate.Text, txttodate1.Text, pdate_flag, Session["userid"].ToString(), hiddendateformat.Value, null, null, null, null, null, null, null, null, null, null };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.Report.classesoracle.DealReport obj = new NewAdbooking.Report.classesoracle.DealReport();
            ds = obj.getdealdata(hdncompcode.Value, dpaddtype.SelectedValue, hiddenadcat.Value, drpdealtype.SelectedValue, hdnagmaincode.Value, hdnagsubcode.Value, hdnclient1.Value, dppstatus.SelectedValue, hiddenpackage.Value, dpratecode.SelectedValue, txtfrmdate.Text, txttodate1.Text, pdate_flag, Session["userid"].ToString(), hiddendateformat.Value);
      }

        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(DealReport), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
          
            Session["from"] = txtfrmdate.Text;
            Session["to"] = txttodate1.Text;
            Session["delrep"] = ds;
            Session["rep_delrep"] = "destination~" + Txtdest.SelectedItem.Value + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~adtype~" + dpaddtype.SelectedItem.Text + "~dealtype~" + drpdealtype.SelectedItem.Text;
            Response.Redirect("DealReportView.aspx");
        }
    }
}
