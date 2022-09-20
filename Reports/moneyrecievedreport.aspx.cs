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
using System.Text.RegularExpressions;
public partial class moneyrecievedreport : System.Web.UI.Page
{
    static string YMDToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new System.Text.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})\\b",
            "${month}/${day}/${year}");
    }
    static string DMYToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<day>\\d{1,2})/(?<month>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${month}/${day}/${year}");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hdncompcode.Value = Session["compcode"].ToString();
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(moneyrecievedreport));
        
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbcurrency.Text = "Currency"; //ds.Tables[0].Rows[0].ItemArray[100].ToString();
        lbclient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[54].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[90].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lbpaymode.Text=ds.Tables[0].Rows[0].ItemArray[91].ToString();
        lblincludecancel.Text = ds.Tables[0].Rows[0].ItemArray[99].ToString();
        Session["dateto"] = txttodate1.Text;
        Session["fromdate"] = txtfrmdate.Text;
        DataSet d1s = new DataSet();
        d1s.ReadXml(Server.MapPath("XML/REPORT.xml"));
        lbPublicationCenter.Text = d1s.Tables[0].Rows[0].ItemArray[5].ToString();
        lblreporttype.Text = d1s.Tables[0].Rows[0].ItemArray[22].ToString();
       
        if (!IsPostBack)
        {
            bindcurrency();
            binddest();
           // bindclient1();
           // bindagency1();
            bindpaymode();
            bindadtype();
            bindbranch();
            user_bind();
            publicationbind();
            bindrprttype();
            BtnRun.Attributes.Add("onclick", "javascript:return pivalidation_mon();");
           // BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");

            //txt_agency.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            //txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            //txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            dppubcent.Attributes.Add("OnChange", "javascript:return bindqbc_new();");
            Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
            exe.Attributes.Add("onclick", "javascript:return enable_exe();");
            csv.Attributes.Add("onclick", "javascript:return enable_csv();");

            txt_agency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr_mon(event);");
            txt_agency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr_mon(event);");

            lstagency.Attributes.Add("onclick", "javascript:return ClickAgaency_mon(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaency_mon(event);");

            txt_client.Attributes.Add("onkeydown", "javascript:return F2fillclientcr_mon(event);");
            txt_client.Attributes.Add("onkeypress", "javascript:return F2fillclientcr_mon(event);");

            lstclient.Attributes.Add("onclick", "javascript:return Clickclient_mon(event);");
            lstclient.Attributes.Add("onkeydown", "javascript:return Clickclient_mon(event);");


        }
    }

     public void bindcurrency()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent1.bind_currency(Session["compcode"].ToString(), Session["compcode"].ToString());
        }


        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.bind_currency(Session["compcode"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindcurrency_bindcurrency_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "All";
        li.Text = "--Select Currency--";
        li.Selected = true;
        drpcurrencuconvert.Items.Add(li);


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpcurrencuconvert.Items.Add(li1);




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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindagencyforxls_bindagencyforxls_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcol, agen };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
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
    public DataSet fillQBC(string pubcenter)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 logindetail = new NewAdbooking.Report.classesoracle.Class1();

            ds = logindetail.getQBC(pubcenter);

        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 logindetail = new NewAdbooking.Report.Classes.Class1();

            ds = logindetail.getQBC(pubcenter);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "websp_QBC_websp_QBC_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { pubcenter };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            //ds = pub_cent1.pub_cent(Session["compcode"].ToString());
            NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "pubcent_proc_pubcent_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        int i;
        ListItem li;
        li = new ListItem();
        dppubcent.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        li.Value = "0";
        li.Selected = true;
        dppubcent.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dppubcent.Items.Add(li1);
            }
        }
        dppubcent.SelectedValue = Session["center"].ToString();

    }
    public void user_bind()
    {
        DataSet ds = new DataSet();

        if (Session["Admin"].ToString() == "yes")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();

                ds = obj.bind_user(Session["compcode"].ToString());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Report.Classes.Class1 obj = new NewAdbooking.Report.Classes.Class1();

                ds = obj.bind_user(Session["compcode"].ToString(), Session["ROLEID"].ToString());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "bind_username_bind_username_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { Session["compcode"].ToString(), Session["ROLEID"].ToString() };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            drpuserid.Items.Clear();
            ListItem li11;
            li11 = new ListItem();
            li11.Text = "--Select User--";
            li11.Value = "0";
            li11.Selected = true;
            drpuserid.Items.Add(li11);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drpuserid.Items.Add(li1);
            }
        }
        else
        {
             drpuserid.Items.Clear();
            ListItem li11;
            li11 = new ListItem();
            li11.Text = "--Select User--";
            li11.Value = "0";
            li11.Selected = true;
            drpuserid.Items.Add(li11);

            li11 = new ListItem();
            li11.Text = Session["Username"].ToString();
            li11.Value = Session["userid"].ToString();
            drpuserid.Items.Add(li11);

             



            
        }
     
    }


    public void bindbranch()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "branchbind_adv_branchbind_adv_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "--Select Branch--";
        li.Selected = true;
        dpbranch.Items.Add(li);



        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpbranch.Items.Add(li1);
        }
        dpbranch.SelectedValue = Session["revenue"].ToString();
    }
    public void bindadtype()
    {
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();


        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpadtype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpadtype.Items.Add(li);


        }
    }

    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string from_date = "";
        string to_date = "";
        DataSet ds = new DataSet();
        string chk_excel = "";
        if (Txtdest.SelectedValue == "4")
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
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                from_date = DMYToMDY(txtfrmdate.Text);
                to_date = DMYToMDY(txttodate1.Text);
            }


            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                from_date = YMDToMDY(txtfrmdate.Text);
                to_date = YMDToMDY(txttodate1.Text);
            }
            NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            //from_date, to_date, Session["compcode"].ToString(), hdnclient.Value, hdnagency.Value, Session["dateformat"].ToString(), drppaymode.SelectedValue, drpadtype.SelectedValue, dpbranch.SelectedValue, drpuserid.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), drpuom.SelectedValue
            ds = obj.money_report(from_date, to_date, Session["compcode"].ToString(), hdnclient.Value, hdnagency.Value, Session["dateformat"].ToString(), drppaymode.SelectedValue, drpadtype.SelectedValue, dpbranch.SelectedValue, drpuserid.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), drpuom.SelectedValue, dprprttype.SelectedValue, drpincludecancel.SelectedValue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            ds = obj.money_report(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), hdnclient.Value, hdnagency.Value, Session["dateformat"].ToString(), drppaymode.SelectedValue, drpadtype.SelectedValue, dpbranch.SelectedItem.Text, drpuserid.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), drpuom.SelectedValue, drpcurrencuconvert.SelectedValue, dprprttype.SelectedValue, drpincludecancel.SelectedValue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Money_Rep";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), hdnclient.Value, hdnagency.Value, Session["dateformat"].ToString(), drppaymode.SelectedValue, drpadtype.SelectedValue, dpbranch.SelectedItem.Text, drpuserid.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), drpuom.SelectedValue, drpcurrencuconvert.SelectedValue, dprprttype.SelectedValue, drpincludecancel.SelectedValue };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(moneyrecievedreport), "sa", "alert(\"searching criteria is not valid\");", true);
            return;

        }
        else
        {
            Session["moneyrep"] = ds;
            Session["currency"] = drpcurrencuconvert.SelectedValue;
            Session["prm_moneyrep"] = "fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~destination~" + Txtdest.SelectedItem.Value + "~agency~" + hdnagency.Value + "~agencyname~" + txt_agency.Text + "~client~" + hdnclient.Value + "~clientname~" + txt_client.Text + "~paymode~" + drppaymode.SelectedValue + "~paymodename~" + drppaymode.SelectedItem.Text + "~adtypecode~" + drpadtype.SelectedValue + "~adtypename~" + drpadtype.SelectedItem.Text + "~chk_excel~" + chk_excel + "~Reporttype~" + dprprttype.SelectedValue + "~incluestat~" + drpincludecancel.SelectedValue;
            Response.Redirect("moneyrecievedview.aspx");
//            Response.Redirect("moneyrecievedview.aspx?fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&destination=" + Txtdest.SelectedItem.Value + "&agency=" + txt_agency.SelectedValue + "&agencyname=" + txt_agency.SelectedItem.Text + "&client=" + txt_client.SelectedValue + "&clientname=" + txt_client.SelectedItem.Text + "&paymode=" + drppaymode.SelectedValue + "&paymodename=" + drppaymode.SelectedItem.Text + "&adtypecode=" + drpadtype.SelectedValue + "&adtypename=" + drpadtype.SelectedItem.Text);
        }
    }

    public void bindpaymode()
    {
       
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {  
        NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
        ds = advpub.payment(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.payment(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "an_payment.an_payment_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();


        li1.Text = "--Select Payment Mode--";
        li1.Value = "0";
        li1.Selected = true;
        drppaymode.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drppaymode.Items.Add(li);


        }
    }
    //public void bindagency1()
    //{
       
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //    NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
    //    ds = advpub.bindagency(Session["compcode"].ToString());
    //}
    //   else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {

    //        NewAdbooking.Report.Classes.Class1 adagency = new NewAdbooking.Report.Classes.Class1();
    //        ds = adagency.agency(Session["compcode"].ToString());
    //    }
    //    ListItem li1;
    //    li1 = new ListItem();


    //    li1.Text = "--Select Agency--";
    //    li1.Value = "0";
    //    li1.Selected = true;
    //    txt_agency.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        txt_agency.Items.Add(li);


    //    }
    //}
    //public void bindclient1()
    //{
    //    ListItem li1;
    //    li1 = new ListItem();

    //    li1.Text = "--Select Client--";
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    txt_client.Items.Add(li1);

    //    int i;
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //    NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
    //    ds = advpub.bindclient(Session["compcode"].ToString());
       
     
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        txt_client.Items.Add(li);


    //    }
    //}
    //     else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 adagencycli = new NewAdbooking.Report.Classes.Class1();
    //        ds = adagencycli.adagencycli(Session["compcode"].ToString());

    //        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            ListItem li;
    //            li = new ListItem();
    //            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //            txt_client.Items.Add(li);


    //        }
    //    }
    //}
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
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

    
    protected void drpadtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize binduom = new NewAdbooking.Classes.Adsize();
            ds = binduom.uombind(Session["compcode"].ToString(), drpadtype.SelectedValue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize binduom = new NewAdbooking.classesoracle.Adsize();
            ds = binduom.uombind(Session["compcode"].ToString(), drpadtype.SelectedValue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "uomadsize_uomadsize_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), drpadtype.SelectedValue };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classmysql.Adsize binduom = new NewAdbooking.classmysql.Adsize();
            ds = binduom.uombind(Session["compcode"].ToString(), drpadtype.SelectedValue);
        }
        drpuom.Items.Clear();
        ListItem li1 = new ListItem();
        li1.Text = "--- Select Uom ---";
        li1.Value = "0";
        li1.Selected = true;
        drpuom.Items.Add(li1);
        int i;
        for (i = 0; i < (ds.Tables[0].Rows.Count); i++)
        {
            ListItem li= new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpuom.Items.Add(li);
        }
    }
    protected void Btndetail_Click(object sender, EventArgs e)
    {
        string from_date = "";
        string to_date = "";
        DataSet ds = new DataSet();
        string chk_excel = "";
        if (Txtdest.SelectedValue == "4")
        {
            //if (exe.Checked == true)
            //{
                chk_excel = "1";//excel
            //}
            //else
            //{
            //    chk_excel = "2";//csv
            //}

        }
        else
        {
            chk_excel = "0";//other than excel
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                from_date = DMYToMDY(txtfrmdate.Text);
                to_date = DMYToMDY(txttodate1.Text);
            }


            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                from_date = YMDToMDY(txtfrmdate.Text);
                to_date = YMDToMDY(txttodate1.Text);
            }
            NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            ds = obj.rpt_booking_receipt(from_date, to_date, Session["compcode"].ToString(), hdnclient.Value, hdnagency.Value, Session["dateformat"].ToString(), drppaymode.SelectedValue, drpadtype.SelectedValue, dpbranch.SelectedValue, drpuserid.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), drpuom.SelectedValue, dprprttype.SelectedValue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            ds = obj.rpt_booking_receipt(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), hdnclient.Value, hdnagency.Value, Session["dateformat"].ToString(), drppaymode.SelectedValue, drpadtype.SelectedValue, dpbranch.SelectedItem.Text, drpuserid.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), drpuom.SelectedValue, dprprttype.SelectedValue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "rpt_booking_collection";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), hdnclient.Value, hdnagency.Value, Session["dateformat"].ToString(), drppaymode.SelectedValue, drpadtype.SelectedValue, dpbranch.SelectedItem.Text, drpuserid.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), drpuom.SelectedValue, dprprttype.SelectedValue };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(moneyrecievedreport), "sa", "alert(\"searching criteria is not valid\");", true);
            return;

        }
        else
        {
            Session["moneyrep"] = ds;
            Session["prm_moneyrep"] = "fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~destination~" + Txtdest.SelectedItem.Value + "~agency~" + hdnagency.Value + "~agencyname~" + txt_agency.Text + "~client~" + hdnclient.Value + "~clientname~" + txt_client.Text + "~paymode~" + drppaymode.SelectedValue + "~paymodename~" + drppaymode.SelectedItem.Text + "~adtypecode~" + drpadtype.SelectedValue + "~adtypename~" + drpadtype.SelectedItem.Text + "~chk_excel~" + chk_excel + "~Reporttype~" + dprprttype.SelectedValue;
            Response.Redirect("ReceiptRegister_View.aspx");
        }
    }
    public void  bindrprttype()
    {
        DataSet fgf = new DataSet();
        fgf.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        dprprttype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        //li1.Text = ds1.Tables[0].Rows[0].ItemArray[32].ToString();
        //li1.Value = "0";
        li1.Selected = true;
        //dprprttype.Items.Add(li1);

        for (i = 0; i < fgf.Tables[19].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = fgf.Tables[19].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = fgf.Tables[19].Rows[0].ItemArray[i].ToString();
            dprprttype.Items.Add(li);

        }


    }

}
