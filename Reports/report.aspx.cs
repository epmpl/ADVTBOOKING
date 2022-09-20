using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
public partial class report : System.Web.UI.Page
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
        Ajax.Utility.RegisterTypeForAjax(typeof(report));
      
       // exe.Style.Add("display", "none");
        //csv.Style.Add("display", "none");
      // exe.Enabled = false;
      //  csv.Enabled = false;
       
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/REPORT.xml"));
        lbadtype .Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbadcatgory.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbDateFrom .Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbPublicationCenter .Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();

        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
       
        docketbooking.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lsearching.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lbluom.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lbluserid.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();

        statelbl.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        districtlbl.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        lblcity.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
        btndetail.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
        btnexit.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();

        lblbukingid.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        lblincludehold.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        lblcurrencyconvert.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        lblpageno.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        lbl_printcent.Text = "Booking Center";
        lbl_branch.Text = "Branch";
        DataSet dsv = new DataSet();
        dsv.ReadXml(Server.MapPath("XML/disschreg.xml"));
        lbagtype.Text = dsv.Tables[0].Rows[0].ItemArray[59].ToString();
        if (!Page.IsPostBack)
        {
            edition();
            bindadvtype();
            bindpub();
            binddest();
            publicationbind();
            bindagencytype();
            bindprintcent();
           // bindbranch();
            user_bind();
            bindstate();
            bindincludehold();
            bindAdType(Session["compcode"].ToString());
            drpstate.Attributes.Add("onchange", "javascript:return diststate();");
            drpdistrict.Attributes.Add("onchange", "javascript:return city();");
            dpd_printcent.Attributes.Add("onchange", "javascript:return branchbind();");
            btnexit.Attributes.Add("OnClick", "javascript:return formexit();");
          
            BtnRun.Attributes.Add("OnClick", "javascript:return allads();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            dpedition.Attributes.Add("onkeypress", "return keySort(this);");
           // dpdadtype.Attributes.Add("onchange", "javascript:return adcat_bind();");
            dpdadtype.Attributes.Add("onblur", "javascript:return adcat_bind();");
            dpadcatgory.Attributes.Add("onchange", "javascript:return adsubcat_bind();");
            dppubcent.Attributes.Add("onchange", "javascript:return bind_edition();");
            dppub1.Attributes.Add("onchange", "javascript:return bind_edition();");
            Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
            exe.Attributes.Add("onclick", "javascript:return enable_exe();");
            csv.Attributes.Add("onclick", "javascript:return enable_csv();");
            drpuom.Attributes.Add("onchange", "javascript:return uomcode();");
            btndetail.Attributes.Add("OnClick", "javascript:return dailysummaryreport();");
            bindcurrency();
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
        else
        {
            string procedureName = "bindcurrency_bindcurrency_p";
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
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






    public void bindprintcent()
    {
        DataSet ds = new DataSet();
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
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
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
    //public void bindbranch()
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {

    //        NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = pub.adbranch(Session["compcode"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
    //        ds = pub.adbranch(Session["compcode"].ToString());
    //    }
    //    ListItem li = new ListItem();
    //    li.Value = "0";
    //    li.Text = "Select Branch";
    //    li.Selected = true;
    //    dpd_branch.Items.Add(li);



    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li1 = new ListItem();
    //        li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpd_branch.Items.Add(li1);
    //    }

    //}
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
        else
        {
            string procedureName = "Websp_agent_Websp_agent_p";
            string[] parameterValueArray = { Session["userid"].ToString(), Session["compcode"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li;
        li = new ListItem();
        dpagtype.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[25].ToString();
        
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
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/frontend.xml"));
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        li1.Value = "0";
        li1.Selected = true;
        Txtdest.Items.Add(li1);

        for (i = 0; i < destination.Tables[20].Columns.Count-1 ; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[20].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[20].Rows[0].ItemArray[i].ToString();
            Txtdest.Items.Add(li);

        }


    }

    

    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string from_date = "";
        string to_date = "";
        if (hiddendateformat.Value == "dd/mm/yyyy"){
            //from_date = DMYToMDY(txtfrmdate.Text);
            //to_date = DMYToMDY(txttodate1.Text);
            from_date = (txtfrmdate.Text);
            to_date = (txttodate1.Text);
        }
        else if (hiddendateformat.Value == "yyyy/mm/dd"){
            from_date = YMDToMDY(txtfrmdate.Text);
            to_date = YMDToMDY(txttodate1.Text);
        }

        string str = "";
        string str1 = "";
        string new1str = "";
        string new1str1 = "";
        str = hiddenadcat.Value;
      new1str = hiddenadsubcat.Value;
      str1 = hiddenadcatname.Value;
      new1str1 = hiddenadsubcatname.Value;
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


        
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {  
            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            ds = obj.spfun1(dpdadtype.SelectedValue, str, new1str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, dpd_printcent.SelectedValue, DropDowndocket.SelectedValue, DropDownsearching.SelectedValue, hiddenuom.Value, drpuserid.SelectedValue, drpstate.SelectedValue, drpdistrict.SelectedValue, drpcity.SelectedValue, drpcurrencuconvert.SelectedValue);
        }
       
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
          //  ds = obj.spfun1(dpdadtype.SelectedValue, str, new1str, from_date, to_date, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, dpd_printcent.SelectedValue, DropDowndocket.SelectedValue, DropDownsearching.SelectedValue, hiddenuom.Value, drpuserid.SelectedValue, drpstate.SelectedValue, drpdistrict.SelectedValue, drpcity.SelectedValue, txtbukid.Text, drpincludehold.SelectedValue);
            ds = obj.spfun1(dpdadtype.SelectedValue, str, new1str, from_date, to_date, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", drpincludehold.SelectedValue,dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, dpd_printcent.SelectedValue, DropDowndocket.SelectedValue, DropDownsearching.SelectedValue, hiddenuom.Value, txtbukid.Text, drpcurrencuconvert.SelectedValue);
        }
        else
        {
            string procedureName = "reportnew1";
            string[] parameterValueArray = { null, null, null, str, new1str, from_date, to_date, Session["compcode"].ToString(), dppub1.SelectedValue, dppubcent.SelectedValue, null, hiddenedition.Value, Session["dateformat"].ToString(), null, null, hiddenascdesc.Value.Trim(), dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, dpd_printcent.SelectedValue, DropDowndocket.SelectedValue, DropDownsearching.SelectedValue, DropDownsearching.SelectedValue, hiddenuom.Value, null, drpstate.SelectedValue, drpdistrict.SelectedValue, drpcity.SelectedValue, null, drpcurrencuconvert.SelectedValue, null, null };
          //  ds = obj.spfun1(dpdadtype.SelectedValue, str, new1str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, dpd_printcent.SelectedValue, DropDowndocket.SelectedValue, DropDownsearching.SelectedValue, hiddenuom.Value, drpuserid.SelectedValue, drpstate.SelectedValue, drpdistrict.SelectedValue, drpcity.SelectedValue, drpcurrencuconvert.SelectedValue);
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
       //string adtype, string adcategory, string adsubcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string agname, string clientname, string status, string hold, string agentyp, string useid, string chk_acc, string branch, string print_cent, string docket, string searching, string uom, string bukid
       

        if (ds.Tables[0].Rows.Count == 0)
        {           
            ScriptManager.RegisterClientScriptBlock(this, typeof(report), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["fromdate"] = txtfrmdate.Text;
            Session["dateto"] = txttodate1.Text;
            Session["drpcurrency"] = drpcurrencuconvert.SelectedValue;
            Session["allads"] = ds;
            //Session["parameter"] = "adtype~" + dpdadtype.SelectedValue + "~adcategory~" + str + "~adsubcat~" + new1str + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~publication~" + dppub1.SelectedValue + "~pubcenter~" + dppubcent.SelectedValue + "~edition~" + hiddenedition.Value + "~publicname~" + dppub1.SelectedItem.Text + "~publiccent~" + dppubcent.SelectedItem.Text + "~destination~" + Txtdest.SelectedItem.Value + "~adcatname~" + str1 + "~adtypename~" + dpdadtype.SelectedItem.Text + "~editionname~" + hiddeneditionname.Value + "~adsubcatname~" + new1str1 + "~agtype~" + dpagtype.SelectedValue + "~agtypetext~" + dpagtype.SelectedItem.Text + "~chk_excel~" + chk_excel + "~branch_name~" + dpd_branch.SelectedItem.Text + "~print_cent~" + dpd_printcent.SelectedValue + "~docket_booking~" + DropDowndocket.SelectedValue + "~sear_cre~" + DropDownsearching.SelectedValue + "~extra1~" + hiddenuom.Value + "~extra2~" + drpuserid.SelectedValue;
            Session["parameter"] = "adtype~" + dpdadtype.SelectedValue + "~adcategory~" + str + "~adsubcat~" + new1str + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~publication~" + dppub1.SelectedValue + "~pubcenter~" + dppubcent.SelectedValue + "~edition~" + hiddenedition.Value + "~publicname~" + dppub1.SelectedItem.Text + "~publiccent~" + dppubcent.SelectedItem.Text + "~destination~" + Txtdest.SelectedItem.Value + "~adcatname~" + str1 + "~adtypename~" + dpdadtype.SelectedItem.Text + "~editionname~" + hiddeneditionname.Value + "~adsubcatname~" + new1str1 + "~agtype~" + dpagtype.SelectedValue + "~agtypetext~" + dpagtype.SelectedItem.Text + "~chk_excel~" + chk_excel + "~branch_name~" + dpd_branch.SelectedValue + "~print_cent~" + dpd_printcent.SelectedValue + "~docket_booking~" + DropDowndocket.SelectedValue + "~sear_cre~" + DropDownsearching.SelectedValue + "~extra1~" + hiddenuom.Value + "~extra2~" + drpuserid.SelectedValue + "~extra3~" + drpstate.SelectedValue + "~extra4~" + drpdistrict.SelectedValue + "~extra5~" + drpcity.SelectedValue;
           Response.Redirect("reportview.aspx");
          // Response.Redirect("reportview.aspx?adtype=" + dpdadtype.SelectedValue + "&adcategory=" + str + "&adsubcat=" + new1str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&edition=" + hiddenedition.Value + "&publicname=" + dppub1.SelectedItem.Text + "&publiccent=" + dppubcent.SelectedItem.Text + "&destination=" + Txtdest.SelectedItem.Value + "&adcatname=" + str1 + "&adtypename=" + dpdadtype.SelectedItem.Text + "&editionname=" + hiddeneditionname.Value + "&adsubcatname=" + new1str1 + "&agtype=" + dpagtype.SelectedValue + "&agtypetext=" + dpagtype.SelectedItem.Text);
//            Server.Transfer("reportview.aspx?adtype=" + dpdadtype.SelectedValue + "&adcategory=" + str + "&adsubcat=" + new1str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&edition=" + hiddenedition.Value + "&publicname=" + dppub1.SelectedItem.Text + "&publiccent=" + dppubcent.SelectedItem.Text + "&destination=" + Txtdest.SelectedItem.Value + "&adcatname=" + str1 + "&adtypename=" + dpdadtype.SelectedItem.Text + "&editionname=" + hiddeneditionname.Value + "&adsubcatname=" + new1str1 + "&agtype=" + dpagtype.SelectedValue + "&agtypetext=" + dpagtype.SelectedItem.Text);
            return;
        }
      
        
    
 }

    private char alert(string p)
    {
        throw new Exception("The method or operation is not implemented.");
    }
   


    public void bindadvtype()
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
        else
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            string[] parameterValueArray = { Session["compcode"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
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
        else
        {
            string procedureName = "Bind_PubName_Bind_PubName_p";
            string[] parameterValueArray = { Session["compcode"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
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
    [Ajax.AjaxMethod]
    public DataSet bind_adcat(string adtype,string compcode)
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
        else
        {
            string procedureName = "RA_bindadcategory_RA_bindadcategory_p";
            string[] parameterValueArray = { adtype, compcode };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

   

    public void edition()
    {
        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));        
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        //li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);

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
        else
        {
            string procedureName = "pubcent_proc_pubcent_proc_p";
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
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
    [Ajax.AjaxMethod]
    public DataSet bind_adsubcat(string newstr, string newstr1)
    {
        DataSet ds = new DataSet();
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
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet edition_bind(string pub, string pub_cent,string compcode)
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
        else
        {
            string procedureName = "edition_proc_edition_proc_p";
            string[] parameterValueArray = { pub, pub_cent, compcode };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet uom_bind(string comp_code, string adtype, string uomdesc)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent2.uombind(comp_code, adtype, uomdesc);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.uombind(comp_code, adtype, uomdesc);

        }
        else
        {
            string procedureName = "getuom";
            string[] parameterValueArray = { comp_code, adtype, uomdesc };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
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
            else
            {
                string procedureName = "bind_username_bind_username_p";
                string[] parameterValueArray = { Session["compcode"].ToString(), Session["ROLEID"].ToString() };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
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
    public void bindstate()
    {


        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
            ds = obj.state(hiddencompcode.Value);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
                ds = obj.state(hiddencompcode.Value);
            }
            else
            {
                string procedureName = "stateMst_state";
                string[] parameterValueArray = { hiddencompcode.Value, null };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        drpstate.Items.Clear();
        ListItem li = new ListItem();
        li.Text = "----Select State----";
        li.Value = "";
        drpstate.Items.Add(li);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[0].Rows[i]["STATE_Name"].ToString();
            li1.Value = ds.Tables[0].Rows[i]["STATE_Code"].ToString();
            drpstate.Items.Add(li1);
        }
    }

    public void bindincludehold()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/REPORT.xml"));
        drpincludehold.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "No";
        li1.Value = "N";
        li1.Selected = true;
        drpincludehold.Items.Add(li1);
        for (i = 0; i < ds.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            drpincludehold.Items.Add(li);
        }
    }


    [Ajax.AjaxMethod]
    public DataSet binddist(string compcode, string state)
    {


        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
            ds = obj.dist(compcode, state);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
                ds = obj.dist(compcode, state);
            }
            else
            {
                string procedureName = "distMst_state";
                string[] parameterValueArray = { compcode, state };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet bindcity(string compcode, string dist)
    {


        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
            ds = obj.city(compcode, dist);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
                ds = obj.city(compcode, dist);
            }
            else
            {
                string procedureName = "cityMst_city";
                string[] parameterValueArray = { compcode, dist };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet bindbranch(string compcode, string branchname, string centercode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
            ds = obj.bankbranch(compcode, centercode, branchname);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
                ds = obj.bankbranch(compcode, centercode, branchname);

            }
            else
            {
                string procedureName = "branch_name_new";
                string[] parameterValueArray = { compcode, centercode, branchname };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        return ds;
    }
    public void bindAdType(string compcode)
    {
        DataSet billtyp = new DataSet();
        billtyp.ReadXml(Server.MapPath("XML/billcycle.xml"));
        //DataView dv = billtyp.Tables["date"].DefaultView;
        ////dv.Sort = "ID";
        //drpbooktype.DataTextField = "Name";
        //drpbooktype.DataValueField = "ID";
        //drpbooktype.DataSource = dv;
        //drpbooktype.DataBind();
        drpbooktype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Booking Type";
        li1.Value = "0";
        //li1.Selected = true;
        drpbooktype.Items.Add(li1);

        for (i = 0; i < billtyp.Tables[3].Columns.Count - 1; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Text = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
            drpbooktype.Items.Add(li);

        }
    }


   
}



