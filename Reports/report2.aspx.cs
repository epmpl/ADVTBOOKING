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
public partial class report2 : System.Web.UI.Page
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
            hiddencompcode.Value = Session["compcode"].ToString();
        }
       hdncompcode.Value = Session["compcode"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/reportagency.xml"));
        agencyname.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();      
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();

        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
       lbadcatgory .Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
       lbluom.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
       Btnsummary.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
       Ajax.Utility.RegisterTypeForAjax(typeof(report2));

       DataSet dsv = new DataSet();
       dsv.ReadXml(Server.MapPath("XML/disschreg.xml"));
       lbagtype.Text = dsv.Tables[0].Rows[0].ItemArray[59].ToString();


       Session["dateto"] = txttodate1.Text;
       Session["fromdate"] = txtfrmdate.Text;
        
      
        if (!Page.IsPostBack)
        {

            bindpub();
            publicationbind();
           // bindagency();
            binddest();
            bindadvtype();
           edition();
           bindagencytype();
           Status();
           bindbranch();
           Btnsummary.Attributes.Add("OnClick", "javascript:return allagency_f2();");
           BtnRun.Attributes.Add("OnClick", "javascript:return forsummary();");
          // BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
         
           //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
           //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
           //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
           //txttodate1.Attributes.Add("OnBlur", "javascript:return dateformate();");
           //txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
           //txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");

           txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
           txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");


          // dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");
           dpagency.Attributes.Add("onkeypress", "return keySort(this);");
           dpedition.Attributes.Add("onkeypress", "return keySort(this);");
           dpdadtype.Attributes.Add("onchange", "javascript:return bindadcat_agency();");
           dppubcent.Attributes.Add("onchange", "javascript:return bind_edition2();");
           dppub1.Attributes.Add("onchange", "javascript:return bind_edition2();");
           Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
           exe.Attributes.Add("onclick", "javascript:return enable_exe();");
           csv.Attributes.Add("onclick", "javascript:return enable_csv();");
          // dpagency.Attributes.Add("onclick", "javascript:return selectvalueagency(event);"); 

           dpagency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr_allagency(event);");
           dpagency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr_allagency(event);");

           lstagency.Attributes.Add("onclick", "javascript:return ClickAgaency1(event);");
           lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaency1(event);");
            
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
    public void bindagencytype()
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
            ds = obj.bindagtype(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.billregister obj = new NewAdbooking.Report.Classes.billregister();
            ds = obj.bindagtype(Session["userid"].ToString(), Session["compcode"].ToString());

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Websp_agent_Websp_agent_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["userid"].ToString(), Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li;
        li = new ListItem();
        dpagtype.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[25].ToString();
        //li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpagtype.Items.Add(li);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li2;
            li2 = new ListItem();
            li2.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li2.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpagtype.Items.Add(li2);


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
            string[] parameterValueArray = { Session["userid"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select Branch";
        li.Selected = true;
        drpbranch.Items.Add(li);



        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpbranch.Items.Add(li1);
        }

    }

    //protected void BtnRun_Click(object sender, EventArgs e)
    //{


    //    string chk_excel = "";
    //    string from_date = "";
    //    string to_date = "";
    //    string str2 = "";
       

    //    string str = "";
    //    string str1 = "";
       
    //    str = hiddenadcat.Value;
    //    str1 = hiddenadcatname.Value;
      

    //    if (ChekAgency.Checked ==true)
    //    {
    //        str2 = "true";

    //    }
    //    else
    //    {
    //        str2 = "false";
    //    }

    //    if (Txtdest.SelectedValue == "4")
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

    //    string agencychk = "";//, clientchk="";
    //    if (dpagency.Text == "")
    //    {
    //        agencychk = "";
    //        hdnagency1.Value = "";
    //        hdnagencytxt.Value = "";
    //    }
    //    else
    //        agencychk = hdnagency1.Value;

    //    //if (dpclient.Text == "")
    //    //{
    //    //    clientchk = "";
    //    //    hdnclienttxt.Value = "";
    //    //    hdnclient1.Value = "";
    //    //}
    //    //else
    //    //    clientchk = hdnclient1.Value;

    //    SqlDataAdapter da = new SqlDataAdapter();
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
    //      //  ds = obj.spAgency(dpagency.SelectedValue, dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());
    //        ds = obj.spAgency(agencychk, dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        if (hiddendateformat.Value == "dd/mm/yyyy")
    //        {
    //            from_date = DMYToMDY(txtfrmdate.Text);
    //            to_date = DMYToMDY(txttodate1.Text);
    //        }


    //        else if (hiddendateformat.Value == "yyyy/mm/dd")
    //        {
    //            from_date = YMDToMDY(txtfrmdate.Text);
    //            to_date = YMDToMDY(txttodate1.Text);
    //        }
    //        NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
    //        //ds = obj.spAgency(dpagency.SelectedValue, dpdadtype.SelectedValue, str, from_date, to_date, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());
    //        ds = obj.spAgency(agencychk, dpdadtype.SelectedValue, str, from_date, to_date, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());

    //    }
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, typeof(report2), "sa", "alert(\"searching criteria is not valid\");", true);
    //        return;
    //    }
    //    else
    //    {
    //        Session["allagency"] = ds;
    //        Session["prm_allagency"] = "agname~" + agencychk + "~adtype~" + dpdadtype.SelectedValue + "~adcategory~" + str + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~publication~" + dppub1.SelectedValue + "~pubcenter~" + dppubcent.SelectedValue + "~publicname~" + dppub1.SelectedItem.Text + "~publiccent~" + dppubcent.SelectedItem.Text + "~edition~" + hiddenedition.Value + "~destination~" + Txtdest.SelectedItem.Value + "~adcatname~" + str1 + "~agencyname~" + hdnagencytxt.Value + "~adtypename~" + dpdadtype.SelectedItem.Text + "~editionname~" + hiddeneditionname.Value + "~agencysubcode~" + str2 + "~agtype~" + dpagtype.SelectedValue + "~agtypetext~" + dpagtype.SelectedItem.Text + "~chk_excel~" + chk_excel;
    //        Response.Redirect("reportview2.aspx");
    //       // Response.Redirect("reportview2.aspx?agname=" + dpagency.SelectedValue + "&adtype=" + dpdadtype.SelectedValue + "&adcategory=" + str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&publicname=" + dppub1.SelectedItem.Text + "&publiccent=" + dppubcent.SelectedItem.Text + "&edition=" + hiddenedition.Value + "&destination=" + Txtdest.SelectedItem.Value + "&adcatname=" + str1 + "&agencyname=" + dpagency.SelectedItem.Text + "&adtypename=" + dpdadtype.SelectedItem.Text + "&editionname=" + hiddeneditionname.Value + "&agencysubcode=" + str2 + "&agtype=" + dpagtype.SelectedValue + "&agtypetext=" + dpagtype.SelectedItem.Text);
    //    }
        
    //}
   


    public void bindpub()
    {
        
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Bind_PubName_Bind_PubName_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["userid"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
       
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppub1.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppub1.Items.Add(li);


        }
    }



    public void Status()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/disschreg.xml"));
        lststatus.Items.Clear();
        int i;
        ListItem l1 = new ListItem();
        l1.Text = "--Select Status";
        l1.Value = "A";
        lststatus.Items.Add(l1);
       
     //   Dropdwnstatus.Items.Add(li1);

        for (i = 0; i < destination.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            lststatus.Items.Add(li);

        }

        


    }


    public void edition()
    {
        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
       // li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);

    }
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        //li1.Text = "--Select Destination--";
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
        //li.Text = "-Select Publication Center-";
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
    //public void bindagency()
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {

    //        NewAdbooking.Report.classesoracle.Class1 adagency = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = adagency.agency(Session["compcode"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 adagency = new NewAdbooking.Report.Classes.Class1();
    //        ds = adagency.agency(Session["compcode"].ToString());
    //    }
        
    //    ListItem li1;
    //    li1 = new ListItem();
    //    dpagency.Items.Clear();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();
      
    //    li1.Value = "0";
    //    li1.Selected = true;
    //    dpagency.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        dpagency.Items.Add(li);


    //    }
    //}
    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
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
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        //li1.Text = "--Select Ad Type--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpdadtype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpdadtype.Items.Add(li);


        }
    }

    [Ajax.AjaxMethod]
    public DataSet edition_bind(string pub, string pub_cent, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "edition_proc_edition_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { pub, pub_cent, compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet pkg_adcat_uom_bind(string compcode, string adtype, string center)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bind = new NewAdbooking.Classes.BookingMaster();
            ds = bind.advdatacategoryRate(compcode, adtype, center);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster bind = new NewAdbooking.classesoracle.RateMaster();
            ds = bind.advdatacategory(compcode, adtype, center);

        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
            ds = bind.advdatacategory(compcode, adtype);
        }
        return ds;
    }


    protected void Btnsummary_Click(object sender, EventArgs e)
    {
        string chk_excel = "";
        string from_date = "";
        string to_date = "";
        string str2 = "";


        string str = "";
        string str1 = "";

        str = hiddenadcat.Value;
        str1 = hiddenadcatname.Value;


        if (ChekAgency.Checked == true)
        {
            str2 = "true";

        }
        else
        {
            str2 = "false";
        }

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

        string agencychk = "";//, clientchk="";
        if (dpagency.Text == "")
        {
            agencychk = "";
            hdnagency1.Value = "";
            hdnagencytxt.Value = "";
        }
        else
            agencychk = hdnagency1.Value;

        string uomcod = drpuom.SelectedValue;
        string pextra1 = "", pextra2 = "", pextra3 = "", pextra4 = "", pextra5 = "";
        //if (dpclient.Text == "")
        //{
        //    clientchk = "";
        //    hdnclienttxt.Value = "";
        //    hdnclient1.Value = "";
        //}
        //else
        //    clientchk = hdnclient1.Value;

        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            //  ds = obj.spAgency(dpagency.SelectedValue, dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());
            ds = obj.spSUMMARYAgency(agencychk, dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString(), drpbranch.SelectedValue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
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
            //ds = obj.spAgency(dpagency.SelectedValue, dpdadtype.SelectedValue, str, from_date, to_date, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());
            //  ds = obj.spAgency(agencychk, dpdadtype.SelectedValue, str, from_date, to_date, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString(), uomcod, Dropdwnstatus.SelectedValue, pextra3, pextra4, pextra5);
            ds = obj.spSUMMARYAgency(agencychk, dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Reportnew1_agency_stmt";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { agencychk, str, dpdadtype.SelectedValue, null, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, dppubcent.SelectedValue, null, hiddenedition.Value, Session["dateformat"].ToString(), null, null, hiddenascdesc.Value.Trim(), dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString(), pextra1, pextra2, pextra3, pextra4, pextra5, null };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(report2), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["allagency"] = ds;
            Session["prm_allagency"] = "agname~" + agencychk + "~adtype~" + dpdadtype.SelectedValue + "~adcategory~" + str + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~publication~" + dppub1.SelectedValue + "~pubcenter~" + dppubcent.SelectedValue + "~publicname~" + dppub1.SelectedItem.Text + "~publiccent~" + dppubcent.SelectedItem.Text + "~edition~" + hiddenedition.Value + "~destination~" + Txtdest.SelectedItem.Value + "~adcatname~" + str1 + "~agencyname~" + hdnagencytxt.Value + "~adtypename~" + dpdadtype.SelectedItem.Text + "~editionname~" + hiddeneditionname.Value + "~agencysubcode~" + str2 + "~agtype~" + dpagtype.SelectedValue + "~agtypetext~" + dpagtype.SelectedItem.Text + "~chk_excel~" + chk_excel + "~branch~" + drpbranch.SelectedValue;
            // Response.Redirect("allagencysummary.aspx");
            Response.Write("<Script>window.open('allagencysummary.aspx',target='_blank')</Script>");
            // Response.Redirect("reportview2.aspx?agname=" + dpagency.SelectedValue + "&adtype=" + dpdadtype.SelectedValue + "&adcategory=" + str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&publicname=" + dppub1.SelectedItem.Text + "&publiccent=" + dppubcent.SelectedItem.Text + "&edition=" + hiddenedition.Value + "&destination=" + Txtdest.SelectedItem.Value + "&adcatname=" + str1 + "&agencyname=" + dpagency.SelectedItem.Text + "&adtypename=" + dpdadtype.SelectedItem.Text + "&editionname=" + hiddeneditionname.Value + "&agencysubcode=" + str2 + "&agtype=" + dpagtype.SelectedValue + "&agtypetext=" + dpagtype.SelectedItem.Text);
        }

    }

    protected void drpstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string k = drpprintcenter.SelectedValue;
        //string k1 = DrpUnit.SelectedValue;
        int flag = 0;
        string newstr = "";
        string newstr1 = "";
        for (int i11 = 1; i11 < lststatus.Items.Count; i11++)
        {

            if (lststatus.Items[i11].Selected == true)
            {
                flag = 1;
                if (newstr == "")
                {
                    newstr = lststatus.Items[i11].Value;
                    newstr1 = lststatus.Items[i11].Text;
                }
                else
                {
                    newstr = newstr + "," + lststatus.Items[i11].Value;
                    newstr1 = newstr1 + "," + lststatus.Items[i11].Text;
                }
                hdnstatus.Value = newstr;
            }
        }
        if (flag != 1)
            hdnstatus.Value = "";
        //if (hdnstatus.Value != "0")
        //    bindpaymode(Session["compcode"].ToString(), hiddendoctypeval.Value);
        //else
        //    DrpPayMode.Items.Clear();

        lststatus.Focus();

        //ScriptManager.RegisterStartupScript(this, typeof(Rpt_Receipt_Register), "CallJS", "rebindbranch('" + k + "');", true);


    }

   
   
}
