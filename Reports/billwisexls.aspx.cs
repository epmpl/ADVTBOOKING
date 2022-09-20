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
public partial class billwisexls : System.Web.UI.Page
{
    int sno = 1;
    string chkid = "", chkbookdate = "", chkagencyname = "", chkclientname = "", chkrono = "", chkrodate = "", chkexe = "", chkbooktype = "", chkcolor = "", chkadcat = "", chkadsubcat = "", chkadsubcat3 = "", chkadsubcat4 = "", chkpackage = "", chkpubdate = "", chkpaidins = "", chkadsize = "", chkarea = "", chkpageprem = "", chkposprem = "", chkscheme = "", chkcardrate = "", chkrate = "", chkcardamt = "", chkcontract = "", chkdevamt = "", chkdevper = "", chkagrate = "", chkagamt = "", chkdiscamt = "", chkdiscper = "", chkpospremper = "", chkpospremamt = "", chkspdiscamt = "", chkspdiscper = "", chkspacediscamt = "", chkspacediscper = "", chkspcharge = "", chkagadtdamt = "", chkagadtdper = "", chkgrossamt = "", chkrettdamt = "", chkrettdper = "", chkagtdamt = "", chkagtdper = "", chkbillamt = "", chkretcomamt = "", chkretcomper = "", chkactbusiness = "", chkrevcenter = "", chkuom = "", chkpublication="",chkedition="";
    string chkprintcenter = "", chkbranch = "", chkdistrict = "", chktaluka = "", chkpageno = "", chkcashdisc = "", chkboxcycle = "", chkstatus = "", chkuserid = "", chkusername = "", chkbillremark = "",chkproduct = "",chkbrand = "",chkVarient = "",chkCaption = "",chkfmgreason="";

    string chkNo_Ins1 = "", chkPaid_Ins1 = "", chkArea1 = "", chkPage_Prem1 = "", chkCard_Amt1 = "", chkDvtn_Amt1 = "", chkDvtn_per1 = "", chkAgrd_Amt1 = "", chkDisc_Amt1 = "", chkDisc_per1 = "", chkPost_Prem_Amt1 = "", chkPost_Prem_per1 = "", chkSp_Disc_Amt1 = "", chkSp_Disc1 = "", chkEx_Disc_Amt1 = "", chkEx_Disc_per1 = "", chkSp_Charges1 = "", chkAdd_Age_Td_Amt1 = "", chkAdd_Age_td_per1 = "", chkGr_Amt1 = "", chkRet_Td_Amt1 = "", chkRet_Td_per1 = "", chkAge_TD_Amt1 = "", chkAge_TD_per1 = "", chkBK_Amt1 = "", chkRet_Comm_Amt1 = "", chkRet_Comm_per1 = "", chkActl_Bus1 = "", chkDate1 = "";
    double area = 0;
    double totalcardamt = 0;
    double totaldeviationdamt = 0;
    double totalaggamt = 0;
    double totaldiscamt = 0;
    double totalpostpremamt = 0;
    double totalspdiscamt = 0;
    double totalspacediscamt = 0;
    double totalspecialcharges = 0;
    double totalagaddltdamt = 0;
    double totalgrossamt = 0;
    double totalretainertdamt = 0;
    double totalbillingamt = 0;
    double totalretcommamt = 0;
    double totalactbusiness = 0;
    double totalagtdamt = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
	string name1 = "", name2 = "", name3 = "";
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
        if (Session["dateformat"] != null)
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hdncompcode.Value = Session["compcode"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }

      
        Ajax.Utility.RegisterTypeForAjax(typeof(billwisexls));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/billbook.xml"));

        //filters
        printcenter.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        publication.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        edition.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        suppliment.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        zone.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        branch.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        district.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        region.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        city.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        revcenter.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        adtype.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        agencytype.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        ratetype.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        adcat.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        adsubcat.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        adsubcat3.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
        adsubcat4.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
        adsubcat5.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
        package.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        scheme.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        agency.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        client.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        executive.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        retainer.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        product.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        brand.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
        varient.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
        pagetype.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
        pageprem.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();
        posprem.Text = ds.Tables[0].Rows[0].ItemArray[31].ToString();
        rostatus.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();
        booktype.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        contractname.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        fromdate.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();
        todate.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString();
        book.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        bill.Text = ds.Tables[0].Rows[0].ItemArray[38].ToString();
        insert.Text=ds.Tables[0].Rows[0].ItemArray[47].ToString();
        filterby.Text= ds.Tables[0].Rows[0].ItemArray[19].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[40].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[41].ToString();
        lbavilfield.Text = ds.Tables[0].Rows[0].ItemArray[42].ToString();
        lbselfield.Text = ds.Tables[0].Rows[0].ItemArray[43].ToString();
        lbstate.Text = ds.Tables[0].Rows[0].ItemArray[44].ToString();
        lbtaluka.Text = ds.Tables[0].Rows[0].ItemArray[45].ToString();
        lbbased.Text = ds.Tables[0].Rows[0].ItemArray[46].ToString();
        lblboxcycle.Text = ds.Tables[0].Rows[0].ItemArray[48].ToString();
        lblcaption.Text = ds.Tables[0].Rows[0].ItemArray[50].ToString();
        lblbillno.Text = ds.Tables[0].Rows[0].ItemArray[51].ToString();
        //lblincludehold.Text = ds.Tables[0].Rows[0].ItemArray[52].ToString();
        lbfmgregion.Text = ds.Tables[0].Rows[0].ItemArray[53].ToString();


        insertstatus.Text = "Insert Status";
        DataSet dsl = new DataSet();
        dsl.ReadXml(Server.MapPath("XML/disschreg.xml"));
        status.Text = dsl.Tables[0].Rows[0].ItemArray[56].ToString();
        lbdtbason.Enabled = false;
        drpdtbasedon.Enabled = false;

        if (IsPostBack != true)
        {

            bindpublication();
            bindpubcent();
            bindfilter();
            bindzone();
            bindbranch();
            binddistrict();
            bindcity();
            bindadtype();
            bindregion();
            bindrevenue();
            bindpage();
            bindposition();
            bindagencytype();
            bindproductnamne();
            bindbooktype();
            bindroStatus();
            bindpagetype();
            bindcontractname();
            bindscheme();
            bindratetype();
            bindpkg();
            bindload();
            bindlistfield();
            bindstate();
            bindbased();
            bindstatus();
            bindcycle();
            bind_fmgregion();
            bind_bookingtype();
          //  bindincludehold();
            txtfromdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            dppublication.Attributes.Add("onchange", "javascript:return editionbind();");
            dpprintcenter.Attributes.Add("OnChange", "javascript:return bindQBC();");
            dpdistrict.Attributes.Add("onchange", "javascript:return citybind();");
            dpedition.Attributes.Add("onchange", "javascript:return suppbind();");
            dpproduct.Attributes.Add("onchange", "javascript:return bindbrand();");
            dpbrand.Attributes.Add("onchange", "javascript:return bindvarient();");
            dpadtype.Attributes.Add("onchange", "javascript:return bindadcat();");
            dpadcat.Attributes.Add("onchange", "javascript:return bindsubcat();");
            dpadsubcat.Attributes.Add("onchange", "javascript:return bindsubcat345(this.id);");
            dpadsubcat3.Attributes.Add("onchange", "javascript:return bindsubcat345(this.id);");
            dpadsubcat4.Attributes.Add("onchange", "javascript:return bindsubcat345(this.id);");

            btnselectall.Attributes.Add("onclick", "javascript:return allchk();");
            btnremoveall.Attributes.Add("onclick", "javascript:return removeallfieldname();");
            btnremove.Attributes.Add("onclick", "javascript:return removefieldname();");
            btnadd.Attributes.Add("onclick", "javascript:return addfieldname();");                                                 
            BtnRun.Attributes.Add("onclick", "javascript:return chkrun();");
            bill.Attributes.Add("onclick", "javascript:return billbill();");
            book.Attributes.Add("onclick", "javascript:return billbook();");
            dpdistrict.Attributes.Add("onchange", "javascript:return bind_taluka();");
            insert.Attributes.Add("onclick", "javascript:return billinsert();");
            dpagency.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpclient.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpexecutive.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpretainer.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpedition.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpsuppliment.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpstate.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpdistrict.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dptaluka.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpcity.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpregion.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpbranch.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dprevcenter.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpadcat.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpadsubcat.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpadsubcat3.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dppackage.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpproduct.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpbrand.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpvarient.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpcontractname.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            lstagency.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            lstclient.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            lstexecutive.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            lstretainer.Attributes.Add("onkeypress", "javascript:return keySort(this);");

            dpagency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr(event);");
            dpagency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr(event);");

            lstagency.Attributes.Add("onclick", "javascript:return ClickAgaency1(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaency1(event);");

            dpclient.Attributes.Add("onkeydown", "javascript:return F2fillclientcr(event);");
            dpclient.Attributes.Add("onkeypress", "javascript:return F2fillclientcr(event);");

            lstclient.Attributes.Add("onclick", "javascript:return Clickclient(event);");
            lstclient.Attributes.Add("onkeydown", "javascript:return Clickclient(event);");

            dpexecutive.Attributes.Add("onkeydown", "javascript:return F2fillexecutivecr(event);");
            dpexecutive.Attributes.Add("onkeypress", "javascript:return F2fillexecutivecr(event);");

            lstexecutive.Attributes.Add("onclick", "javascript:return Clickexecutive(event);");
            lstexecutive.Attributes.Add("onkeydown", "javascript:return Clickexecutive(event);");

            dpretainer.Attributes.Add("onkeydown", "javascript:return F2fillretainercr(event);");
            dpretainer.Attributes.Add("onkeypress", "javascript:return F2fillretainercr(event);");

            lstretainer.Attributes.Add("onclick", "javascript:return Clickretainer(event);");
            lstretainer.Attributes.Add("onkeydown", "javascript:return Clickretainer(event);");

            exe.Attributes.Add("onclick", "javascript:return enable_exe();");
            csv.Attributes.Add("onclick", "javascript:return enable_csv();");
            txtbillno.Attributes.Add("onkeypress", "javascript:return fornumbercheck(event);");
           
        }

        }
    public void bindstatus()
    {

        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        drpinsertstatus.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[8].ToString();
        li1.Value = "0";
        li1.Selected = true;
        drpinsertstatus.Items.Add(li1);

        for (i = 0; i < destination.Tables[18].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[18].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[18].Rows[0].ItemArray[i].ToString();
            drpinsertstatus.Items.Add(li);

        }




    }

    //public void bindincludehold()
    //{
    //    DataSet ds = new DataSet();
    //    ds.ReadXml(Server.MapPath("XML/REPORT.xml"));
    //    drpincludehold.Items.Clear();
    //    int i;
    //    ListItem li1;
    //    li1 = new ListItem();
    //    li1.Text = "No";
    //    li1.Value = "N";
    //    li1.Selected = true;
    //    drpincludehold.Items.Add(li1);
    //    for (i = 0; i < ds.Tables[1].Columns.Count - 1; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
    //        i = i + 1;
    //        li.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
    //        drpincludehold.Items.Add(li);
    //    }
    //}


    public void bindbased()
    {
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Agency";
        li1.Value = "1";
        li1.Selected = true;
        dpbased.Items.Add(li1);

        li1 = new ListItem();
        li1.Value = "2";
        li1.Text = "Executive";
        dpbased.Items.Add(li1);

        li1 = new ListItem();
        li1.Value = "3";
        li1.Text = "Retainer";
        dpbased.Items.Add(li1);

    }
    public void bindstate()
    {       
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["center"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 objprod = new NewAdbooking.Report.classesoracle.Class1();
            ds = objprod.statebind(Session["compcode"].ToString(), Session["center"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objprod = new NewAdbooking.Report.Classes.Class1();
            ds = objprod.statebind(Session["compcode"].ToString(), Session["center"].ToString());
        }
        else
        {
            string procedureName = "statebind_statebind_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();


        li1.Text = "Select State";
        li1.Value = "0";
        dpstate.Items.Add(li1);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpstate.Items.Add(li);
        }

    }


    public void bindcycle()
    {

        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["center"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 objprod = new NewAdbooking.Report.classesoracle.Class1();
            ds = objprod.boxcyclebind(Session["compcode"].ToString(), Session["center"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objprod = new NewAdbooking.Report.Classes.Class1();
            ds = objprod.boxcyclebind(Session["compcode"].ToString(), Session["center"].ToString());
        }
        else
        {
            string procedureName = "boxbind_boxbind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li1;
        li1 = new ListItem();


        li1.Text = "Select Box Cycle";
        li1.Value = "0";
        drpboxcycle.Items.Add(li1);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpboxcycle.Items.Add(li);
        }

    }

    public void bindlistfield()
    {


        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/billbook.xml"));
        
       
            int i;

            for (i = 1; i < ds.Tables[3].Columns.Count - 1; i++)
            {
                ListItem li;
                li = new ListItem();
                i = i + 1;
                li.Text = ds.Tables[3].Rows[0].ItemArray[i].ToString();
                Listavilfield.Items.Add(li);

           }
       
    }

    public void bindload()
    {
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select AdCat";
        li1.Value = "0";
       dpadcat.Items.Add(li1);

        ListItem li11;
        li11 = new ListItem();
        li11.Text = "Select AdSubCat";
        li11.Value = "0";
        dpadsubcat.Items.Add(li11);

        ListItem li21;
        li21 = new ListItem();
        li21.Text = "Select AdSubCat3";
        li21.Value = "0";
        dpadsubcat3.Items.Add(li21);

        ListItem li31;
        li31 = new ListItem();
        li31.Text = "Select AdSubCat4";
        li31.Value = "0";
        dpadsubcat4.Items.Add(li31);

        ListItem li41;
        li41 = new ListItem();
        li41.Text = "Select AdSubCat5";
        li41.Value = "0";
        dpadsubcat5.Items.Add(li41);
        
     
        ListItem li91;
        li91 = new ListItem();
        li91.Text = "Select Edition";
        li91.Value = "0";
        dpedition.Items.Add(li91);
        
   
        ListItem li81;
        li81 = new ListItem();
        li81.Text = "Select Suppliment";
        li81.Value = "0";
        dpsuppliment.Items.Add(li81);
        
    
        ListItem li71;
        li71 = new ListItem();
        li71.Text = "Select Brand";
        li71.Value = "0";
        dpbrand.Items.Add(li71);
   
        ListItem li61;
        li61 = new ListItem();
        li61.Text = "Select Varient";
        li61.Value = "0";
        dpvarient.Items.Add(li61);

        ListItem li64;
        li64 = new ListItem();
        li64.Text = "Select Taluka";
        li64.Value = "0";
        dptaluka.Items.Add(li64);
        
    }
    public void bindroStatus()
    {
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select RO Status";
        li1.Value = "0";
        li1.Selected = true;
        dprostatus.Items.Add(li1);
        
        li1 = new ListItem();
        li1.Value = "2";
        li1.Text = "Confirm";
        dprostatus.Items.Add(li1);
        li1 = new ListItem();
        li1.Value = "1";
        li1.Text = "Reservation";
        dprostatus.Items.Add(li1);

    }
    public void bindpkg()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 objprod = new NewAdbooking.Report.classesoracle.Class1();
            ds = objprod.packagebind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objprod = new NewAdbooking.Report.Classes.Class1();
            ds = objprod.packagebind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            string procedureName = "bindpackage_bindpackage_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li1;
        li1 = new ListItem();


        li1.Text = "Select Package";
        li1.Value = "0";
        dppackage.Items.Add(li1);
           
        
           
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppackage.Items.Add(li);
        }

    }
    public void bindratetype()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 objprod = new NewAdbooking.Report.classesoracle.Class1();
        ds = objprod.ratecdbind(Session["compcode"].ToString());
      }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objprod = new NewAdbooking.Report.Classes.Class1();
            ds = objprod.ratecdbind(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "xlsratecode_xlsratecode_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();


        li1.Text = "Select Rate Code";
        li1.Value = "0";
        dpratetype.Items.Add(li1);
        
           
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpratetype.Items.Add(li);
        }

    }
    
        
    public void bindscheme()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 objprod = new NewAdbooking.Report.classesoracle.Class1();
        ds = objprod.bindscheme(Session["compcode"].ToString());
         }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objprod = new NewAdbooking.Report.Classes.Class1();
            ds = objprod.bindscheme(Session["compcode"].ToString());
        }

        else
        {
            string procedureName = "schemename_schemename_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();


        li1.Text = "Select Scheme";
        li1.Value = "0";
        dpscheme.Items.Add(li1);
            
            
        


        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpscheme.Items.Add(li);
        }

    }
    
    public void bindcontractname()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 objprod = new NewAdbooking.Report.classesoracle.Class1();
        ds = objprod.bindcontract(Session["compcode"].ToString());
        }
             else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objprod = new NewAdbooking.Report.Classes.Class1();
            ds = objprod.bindcontract(Session["compcode"].ToString());
        }

        else
        {
            string procedureName = "contractname_contractname_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();


        li1.Text = "Select Contract Name";
        li1.Value = "0";
        dpcontractname.Items.Add(li1);
            
        


        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpcontractname.Items.Add(li);
        }

    }

    public void bindpagetype()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 objprod = new NewAdbooking.Report.classesoracle.Class1();
        ds = objprod.bindpagetype(Session["compcode"].ToString());
         }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objprod = new NewAdbooking.Report.Classes.Class1();
            ds = objprod.bindpagetype(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "bindpagetype_bindpagetype_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();


        li1.Text = "Select Page Type";
        li1.Value = "0";
        dppagetype.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppagetype.Items.Add(li);
        }

    }

    public void bindbooktype()
    {
        //DataSet billtyp = new DataSet();
        //billtyp.ReadXml(Server.MapPath("XML/billcycle.xml"));
        //dpbooktype.Items.Clear();
        
        //int i;
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "Select Booking Type";
        //li1.Value = "0";
        //dpbooktype.Items.Add(li1);

        //for (i = 0; i < billtyp.Tables[3].Columns.Count - 1; i++)
        //{
        //    ListItem li;
        //    li = new ListItem();
        //    li.Text = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
        //    i = i + 1;
        //    li.Value = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();

        //    dpbooktype.Items.Add(li);

        //}

    }

    public void bindproductnamne()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
           NewAdbooking.Report.classesoracle.billregister objprod = new NewAdbooking.Report.classesoracle.billregister();
            ds = objprod.bindProductcategory(Session["compcode"].ToString());
         }
        else if(ConfigurationSettings.AppSettings["ConnectionType"].ToString()=="sql")
        {
           NewAdbooking.Report.Classes.Class1 objprod = new NewAdbooking.Report.Classes.Class1();
           ds = objprod.bindProductcategory(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "Websp_Product1_Websp_Product1_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }


        ListItem li1;
        li1 = new ListItem();

       
        li1.Text = "Select Product";
        li1.Value = "0";
        dpproduct.Items.Add(li1);
      

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpproduct.Items.Add(li);
        }
    }
   
    [Ajax.AjaxMethod]
    public DataSet fillQBC(string pubcenter)
    {
        DataSet ds=new DataSet();
        string[] parameterValueArray = new string[] { pubcenter };
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
        else
        {
            string procedureName = "websp_QBC_websp_QBC_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet fillF2_CreditAgency(string compcol,string agen)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcol, agen };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adagency = new NewAdbooking.Report.classesoracle.Class1();
            ds = adagency.agencyxls(compcol,agen);
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
    public DataSet fillF2_Creditclient(string compcol,string cli)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcol, cli };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 adagencycli = new NewAdbooking.Report.classesoracle.Class1();
        ds = adagencycli.clientxls(compcol,cli);
       
         }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Report.Classes.Class1 adagencycli = new NewAdbooking.Report.Classes.Class1();
             ds = adagencycli.clientxls(compcol, cli);
         }

        else
        {
            string procedureName = "bindclientforxls_bindclientforxls_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditexecutive(string compcol,string exectv)
    {
        string tname = "",userid="";
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
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
    public DataSet fillF2_Creditretainer(string compcol,string ret)
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
  

    public void bindagencytype()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["userid"].ToString(), Session["compcode"].ToString() };
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
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

       ListItem li;
        li = new ListItem();
        dpagencytype.Items.Clear();
        
        li.Text = "Select Agency Type";
       
        li.Value = "0";
        li.Selected = true;
        dpagencytype.Items.Add(li);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li2;
            li2 = new ListItem();
            li2.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li2.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpagencytype.Items.Add(li2);
            


        }
    }
    public void bindpage()
        {
            DataSet ds = new DataSet();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.Class1 page = new NewAdbooking.Report.classesoracle.Class1();
                ds = page.premiumbind(Session["compcode"].ToString());
             }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Report.Classes.Class1 page = new NewAdbooking.Report.Classes.Class1();
                ds = page.premiumbind(Session["compcode"].ToString());
            }
            else
            {
                string procedureName = "bindpremiumforrate_report_bindpremiumforrate_report_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            ListItem li1;
            li1 = new ListItem();
           
            li1.Text = "Select Page Premium";
          
            li1.Value = "0";
            li1.Selected = true;
            dppageprem.Items.Add(li1);
            

            int i;
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dppageprem.Items.Add(li);


            }


        }
        public void bindposition()
        {
            DataSet ds = new DataSet();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.Class1 position = new NewAdbooking.Report.classesoracle.Class1();
                ds = position.bindPagePosition(Session["compcode"].ToString());
           }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Report.Classes.Class1 position = new NewAdbooking.Report.Classes.Class1();
                ds = position.bindPagePosition(Session["compcode"].ToString());
            }

            else
            {
                string procedureName = "websp_getPagePosition_websp_getPagePosition_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            ListItem li1;
            li1 = new ListItem();

            li1.Text = "Select Position Premium";
            li1.Value = "0";
            li1.Selected = true;
            dpposprem.Items.Add(li1);
            

            int i;
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dpposprem.Items.Add(li);


            }


        }



    public void bindrevenue()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
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
        else
        {
            string procedureName = "branchbind_adv_branchbind_adv_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select RevenueCenter";
        li.Selected = true;
        dprevcenter.Items.Add(li);
        



        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dprevcenter.Items.Add(li1);
        }
        
    }

    public void bindregion()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 objregion = new NewAdbooking.Report.classesoracle.Class1();
            ds = objregion.bindregion(Session["compcode"].ToString());
        }
       else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.bindregion(Session["compcode"].ToString());
        }

        else
        {
            string procedureName = "Sp_Region_sp_region_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
          ListItem li1;
        li1 = new ListItem();
       
        li1.Text = "Select Region";
        li1.Value = "0";
        li1.Selected = true;
        dpregion.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpregion.Items.Add(li);


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
        dpadtype.Items.Add(li1);
        


        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpadtype.Items.Add(li);


        }
    }

    public void bindcity()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister objregion = new NewAdbooking.Report.classesoracle.billregister();
            ds = objregion.bindplace(Session["compcode"].ToString());
         }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.bindplace(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "Spcityac_Spcityac_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select City";
        li1.Value = "0";
        li1.Selected = true;
        dpcity.Items.Add(li1);
        

       
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpcity.Items.Add(li);


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
        dpdistrict.Items.Add(li);
        
            
        

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpdistrict.Items.Add(li1);
        }
        
    }

    public void bindzone()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
        ds = pub.addzone(Session["compcode"].ToString());
         }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.addzone(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "zonebind_zonebind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select Zone";
        li.Selected = true;
        dpzone.Items.Add(li);
        

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpzone.Items.Add(li1);
        }
        
    }

    public void bindbranch()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
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
        else
        {
            string procedureName = "branchbind_adv_branchbind_adv_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select Branch";
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
    public void bindpublication()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
        ds = pub.advpub(Session["compcode"].ToString());
         }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.advpub(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "Bind_PubName_Bind_PubName_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select Publication";
        li.Selected = true;
        dppublication.Items.Add(li);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dppublication.Items.Add(li1);
        }
        
    }
    public void bindpubcent()
    {
        DataSet ds=new DataSet();
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
        dpprintcenter.Items.Add(li);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpprintcenter.Items.Add(li1);
            

         }
    }
   
     [Ajax.AjaxMethod]
    public DataSet bindedition_print(string publ, string pubcentr, string compcode)
    {
        DataSet ds = new DataSet();
        //string[] parameterValueArray = new string[] { publ, pubcentr, compcode };
        string[] parameterValueArray = new string[] { compcode,publ, pubcentr };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
        ds = pub_cent2.edition_print(publ, pubcentr, compcode);
         }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.edition_print(publ, pubcentr, compcode);
        }
        else
        {
            string procedureName = "BIND_EDITION_PRINT_BIND_EDITION_PRINT_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }
    
    [Ajax.AjaxMethod]
    public DataSet bindcity1(string district, string compcode)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { district, compcode };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
        ds = pub_cent2.distcity(district, compcode);
         }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.distcity(district, compcode);
        }
        else
        {
            string procedureName = "dist_city_dist_city_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }
       [Ajax.AjaxMethod]
    public DataSet bindsupp(string compcode, string edition)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, edition };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
        ds = pub_cent2.pubsupply(compcode, edition);
             }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.pubsupply(compcode, edition);
        }
        else
        {
            string procedureName = "bindsuppliment_bindsuppliment_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
           
    }

     [Ajax.AjaxMethod]
    public DataSet bindag(string compcode, string agencytyp)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, agencytyp };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
        ds = pub_cent2.agbnd(compcode, agencytyp);
          }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.agbnd(compcode, agencytyp);
        }
        else
        {
            string procedureName = "ag_agtype_ag_agtype_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
         
           
    }
    [Ajax.AjaxMethod]
    public DataSet bindbrand(string compcode, string prod)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, prod };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
        ds = pub_cent2.bindBrand(compcode, prod);
         }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.bindBrand(compcode, prod);
        }
        else
        {
            string procedureName = "websp_getBrand_websp_getBrand_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
         
    }
      [Ajax.AjaxMethod]
    public DataSet varientbind(string compcode, string brand)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, brand };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
        ds = pub_cent2.bindvarient(brand, compcode);
           }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.bindvarient(brand, compcode);
        }
        else
        {
            string procedureName = "websp_getBrand_websp_getBrand_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
         
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
            string procedureName = "RA_bindadcategory_RA_bindadcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
         
    }
     [Ajax.AjaxMethod]
    public DataSet subcatbind(string compcode, string cat)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, cat };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
        ds = adcat.getSubCategory(compcode, cat);
          }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.getSubCategory(compcode, cat);
        }
        else
        {
            string procedureName = "advsubcattyp_advsubcattyp_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
         
    }
     [Ajax.AjaxMethod]
    public DataSet subcat345(string cat,string compcode,string cat4,string cat5)
    {
        DataSet ds = new DataSet();
           string[] parameterValueArray = new string[] { cat, compcode, cat4, cat5 };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
        ds = adcat.cat345(cat, compcode,cat4,cat5);
         }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.cat345(cat, compcode,cat4,cat5);
        }
         else
        {
            string procedureName = "bindadcat345_bindadcat345_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
         
    }
     [Ajax.AjaxMethod]
    public DataSet bindtaluka(string compcode,string district)
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
   
    public void bindfilter()
    {
        DataSet filter = new DataSet();
        filter.ReadXml(Server.MapPath("XML/billbook.xml"));
       
        dpfilterby.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Filter By";
        li1.Value = "0";
        li1.Selected = true;
        dpfilterby.Items.Add(li1);

        for (i = 0; i < filter.Tables[2].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = filter.Tables[2].Rows[0].ItemArray[i].ToString();
            li.Value = filter.Tables[2].Rows[0].ItemArray[i+1].ToString();
            dpfilterby.Items.Add(li);
            i = i + 1;

        }


    }

    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string chk_excel = "";
        string from_date = "";
        string to_date = "";

        string adchk = "" ;
        string filter="";
        if (book.Checked == true)
            adchk = "1";
        else if(bill.Checked==true)
            adchk = "2";
        else
            adchk = "3";

        if (dpfilterby.SelectedValue == "0")
             filter = "Booking Date";
        else
            filter = dpfilterby.SelectedItem.Text;

        string hedition=hdnedition.Value;
        string hcity= hdncity.Value;
        string hsuppliment= hdnsuppliment.Value;
        string hagency= hdnagency.Value;
        string hbrand= hdnbrand.Value;
        string hvarient= hdnvarient.Value;
        string hadcat= hdnadcat.Value;
        string hadsubcat= hdnadsubcat.Value;
        string hadsubcat3= hdnadsubcat3.Value;
        string hadsubcat4= hdnadsubcat4.Value;
        if (hadsubcat4 == "undefined")
            hadsubcat4 = "";
        string hadsubcat5 = hdnadsubcat5.Value;
        if (hadsubcat5 == "undefined")
            hadsubcat5 = "";
        string htaluka = hdntaluka.Value;


        string chkdetail = "";
        if (RadioButton2.Checked == true)
        {
            chkdetail = "Date_Wise_Summary";
        }
        else
        {
            chkdetail = "Detail";
        }


        string agencychk = "", clientchk = "", executivechk = "", retainerchk="";
        if(dpagency.Text=="")
             agencychk = "";
        else
             agencychk = hdnagency1.Value;

         if (dpclient.Text == "")
             clientchk = "";
         else
             clientchk = hdnclient1.Value;

         if (dpexecutive.Text == "")
             executivechk = "";
         else
             executivechk = hdnexecutive1.Value;

         if (dpretainer.Text == "")
             retainerchk = "";
         else
             retainerchk = hdnretainer1.Value;


         if (exe.Checked == true)
         {
             chk_excel = "1";//excel
         }
         else
         {
             chk_excel = "2";//csv
         }
         string dtbasedon = drpdtbasedon.SelectedValue;
         if (dtbasedon == "")
         {
             dtbasedon = "";
         }
         DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString(), txtfromdate.Text, txttodate.Text, Session["dateformat"].ToString(), dppublication.SelectedValue, dpprintcenter.SelectedValue, hedition, hsuppliment, dpzone.SelectedValue, dpbranch.SelectedItem.Value, dpdistrict.SelectedItem.Text, dpregion.SelectedValue, hcity, dprevcenter.SelectedValue, dpadtype.SelectedValue, dpagencytype.SelectedValue, dpratetype.SelectedValue, hadcat, hadsubcat, hadsubcat3, hadsubcat4, hadsubcat5, dppackage.SelectedValue, dpscheme.SelectedValue, agencychk, clientchk, executivechk, retainerchk, dpproduct.SelectedValue, hbrand, hvarient, dppagetype.SelectedValue, dppageprem.SelectedValue, dpposprem.SelectedValue, dprostatus.SelectedValue, dpbooktype.SelectedValue, dpcontractname.SelectedValue, filter, adchk, dpstate.SelectedItem.Text, htaluka, dpbased.SelectedValue, drpstatus.SelectedValue, chkdetail, drpinsertstatus.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), drpboxcycle.SelectedValue, drpfmgregion.SelectedValue };
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.Report.classesoracle.Class1 ncls = new NewAdbooking.Report.classesoracle.Class1();
             if (adchk == "2")
                 ds = ncls.completerep(Session["compcode"].ToString(), txtfromdate.Text, txttodate.Text, Session["dateformat"].ToString(), dppublication.SelectedValue, dpprintcenter.SelectedValue, hedition, hsuppliment, dpzone.SelectedValue, dpbranch.SelectedItem.Value, dpdistrict.SelectedItem.Text, dpregion.SelectedValue, hcity, dprevcenter.SelectedValue, dpadtype.SelectedValue, dpagencytype.SelectedValue, dpratetype.SelectedValue, hadcat, hadsubcat, hadsubcat3, hadsubcat4, hadsubcat5, dppackage.SelectedValue, dpscheme.SelectedValue, agencychk, clientchk, executivechk, retainerchk, dpproduct.SelectedValue, hbrand, hvarient, dppagetype.SelectedValue, dppageprem.SelectedValue, dpposprem.SelectedValue, dprostatus.SelectedValue, dpbooktype.SelectedValue, dpcontractname.SelectedValue, filter, adchk, dpstate.SelectedItem.Text, htaluka, dpbased.SelectedValue, drpstatus.SelectedValue, chkdetail, drpinsertstatus.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), drpboxcycle.SelectedValue, drpfmgregion.SelectedValue);
             else
                 ds = ncls.completerep(Session["compcode"].ToString(), txtfromdate.Text, txttodate.Text, Session["dateformat"].ToString(), dppublication.SelectedValue, dpprintcenter.SelectedValue, hedition, hsuppliment, dpzone.SelectedValue, dpbranch.SelectedItem.Value, dpdistrict.SelectedItem.Text, dpregion.SelectedValue, hcity, dprevcenter.SelectedValue, dpadtype.SelectedValue, dpagencytype.SelectedItem.Text, dpratetype.SelectedValue, hadcat, hadsubcat, hadsubcat3, hadsubcat4, hadsubcat5, dppackage.SelectedValue, dpscheme.SelectedValue, agencychk, clientchk, executivechk, retainerchk, dpproduct.SelectedValue, hbrand, hvarient, dppagetype.SelectedValue, dppageprem.SelectedValue, dpposprem.SelectedValue, dprostatus.SelectedValue, dpbooktype.SelectedValue, dpcontractname.SelectedValue, filter, adchk, dpstate.SelectedItem.Text, htaluka, dpbased.SelectedValue, drpstatus.SelectedValue, chkdetail, drpinsertstatus.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), drpboxcycle.SelectedValue, drpfmgregion.SelectedValue);

         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             if (hiddendateformat.Value == "dd/mm/yyyy")
             {
                 from_date = DMYToMDY(txtfromdate.Text);
                 to_date = DMYToMDY(txttodate.Text);
             }


             else if (hiddendateformat.Value == "yyyy/mm/dd")
             {
                 from_date = YMDToMDY(txtfromdate.Text);
                 to_date = YMDToMDY(txttodate.Text);
             }
             NewAdbooking.Report.Classes.report ncls = new NewAdbooking.Report.Classes.report();
             if (adchk == "2")
                 ds = ncls.completerep(Session["compcode"].ToString(), from_date, to_date, Session["dateformat"].ToString(), dppublication.SelectedValue, dpprintcenter.SelectedValue, hedition, hsuppliment, dpzone.SelectedValue, dpbranch.SelectedItem.Value, dpdistrict.SelectedItem.Text, dpregion.SelectedValue, hcity, dprevcenter.SelectedValue, dpadtype.SelectedValue, dpagencytype.SelectedValue, dpratetype.SelectedValue, hadcat, hadsubcat, hadsubcat3, hadsubcat4, hadsubcat5, dppackage.SelectedValue, dpscheme.SelectedValue, agencychk, clientchk, executivechk, retainerchk, dpproduct.SelectedValue, hbrand, hvarient, dppagetype.SelectedValue, dppageprem.SelectedValue, dpposprem.SelectedValue, dprostatus.SelectedValue, dpbooktype.SelectedValue, dpcontractname.SelectedValue, filter, adchk, dpstate.SelectedItem.Text, htaluka, dpbased.SelectedValue, drpstatus.SelectedValue, chkdetail, drpinsertstatus.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), drpboxcycle.SelectedValue, dtbasedon);
             else
                 ds = ncls.completerep(Session["compcode"].ToString(), from_date, to_date, Session["dateformat"].ToString(), dppublication.SelectedValue, dpprintcenter.SelectedValue, hedition, hsuppliment, dpzone.SelectedValue, dpbranch.SelectedItem.Value, dpdistrict.SelectedItem.Text, dpregion.SelectedValue, hcity, dprevcenter.SelectedValue, dpadtype.SelectedValue, dpagencytype.SelectedItem.Text, dpratetype.SelectedValue, hadcat, hadsubcat, hadsubcat3, hadsubcat4, hadsubcat5, dppackage.SelectedValue, dpscheme.SelectedValue, agencychk, clientchk, executivechk, retainerchk, dpproduct.SelectedValue, hbrand, hvarient, dppagetype.SelectedValue, dppageprem.SelectedValue, dpposprem.SelectedValue, dprostatus.SelectedValue, dpbooktype.SelectedValue, dpcontractname.SelectedValue, filter, adchk, dpstate.SelectedItem.Text, htaluka, dpbased.SelectedValue, drpstatus.SelectedValue, chkdetail, drpinsertstatus.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), drpboxcycle.SelectedValue, dtbasedon);
         }
         else
         {
             string procedureName = "completereport";
             NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
             ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
         }

         if (ds.Tables[0].Rows.Count == 0)
         {
             ScriptManager.RegisterClientScriptBlock(this, typeof(billwisexls), "sa", "alert(\"searching criteria is not valid\");", true);
             return;
         }

        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //NewAdbooking.Report.classesoracle.Class1 ncls = new NewAdbooking.Report.classesoracle.Class1();
        //if( adchk == "2")
        //    ds = ncls.completerep(Session["compcode"].ToString(), txtfromdate.Text, txttodate.Text, Session["dateformat"].ToString(), dppublication.SelectedValue, dpprintcenter.SelectedValue, hedition, hsuppliment, dpzone.SelectedValue, dpbranch.SelectedItem.Text, dpdistrict.SelectedItem.Text, dpregion.SelectedValue, hcity, dprevcenter.SelectedValue, dpadtype.SelectedValue, dpagencytype.SelectedValue, dpratetype.SelectedValue, hadcat, hadsubcat, hadsubcat3, hadsubcat4, hadsubcat5, dppackage.SelectedValue, dpscheme.SelectedValue, agencychk, clientchk, executivechk, retainerchk, dpproduct.SelectedValue, hbrand, hvarient, dppagetype.SelectedValue, dppageprem.SelectedValue, dpposprem.SelectedValue, dprostatus.SelectedValue, dpbooktype.SelectedValue, dpcontractname.SelectedValue, filter, adchk, dpstate.SelectedItem.Text, htaluka, dpbased.SelectedValue, drpstatus.SelectedValue, chkdetail, drpinsertstatus.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
        //else
        //    ds = ncls.completerep(Session["compcode"].ToString(), txtfromdate.Text, txttodate.Text, Session["dateformat"].ToString(), dppublication.SelectedValue, dpprintcenter.SelectedValue, hedition, hsuppliment, dpzone.SelectedValue, dpbranch.SelectedItem.Text, dpdistrict.SelectedItem.Text, dpregion.SelectedValue, hcity, dprevcenter.SelectedValue, dpadtype.SelectedValue, dpagencytype.SelectedItem.Text, dpratetype.SelectedValue, hadcat, hadsubcat, hadsubcat3, hadsubcat4, hadsubcat5, dppackage.SelectedValue, dpscheme.SelectedValue, agencychk, clientchk, executivechk, retainerchk, dpproduct.SelectedValue, hbrand, hvarient, dppagetype.SelectedValue, dppageprem.SelectedValue, dpposprem.SelectedValue, dprostatus.SelectedValue, dpbooktype.SelectedValue, dpcontractname.SelectedValue, filter, adchk, dpstate.SelectedItem.Text, htaluka, dpbased.SelectedValue, drpstatus.SelectedValue, chkdetail, drpinsertstatus.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());

        //  }
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    if (hiddendateformat.Value == "dd/mm/yyyy")
        //    {
        //        from_date = DMYToMDY(txtfromdate.Text);
        //        to_date = DMYToMDY(txttodate.Text);
        //    }


        //    else if (hiddendateformat.Value == "yyyy/mm/dd")
        //    {
        //        from_date = YMDToMDY(txtfromdate.Text);
        //        to_date = YMDToMDY(txttodate.Text);
        //    }
        //    NewAdbooking.Report.Classes.report ncls = new NewAdbooking.Report.Classes.report();
        //    if (adchk == "2")
        //        ds = ncls.completerep(Session["compcode"].ToString(),from_date, to_date, Session["dateformat"].ToString(), dppublication.SelectedValue, dpprintcenter.SelectedValue, hedition, hsuppliment, dpzone.SelectedValue, dpbranch.SelectedItem.Text, dpdistrict.SelectedItem.Text, dpregion.SelectedValue, hcity, dprevcenter.SelectedValue, dpadtype.SelectedValue, dpagencytype.SelectedValue, dpratetype.SelectedValue, hadcat, hadsubcat, hadsubcat3, hadsubcat4, hadsubcat5, dppackage.SelectedValue, dpscheme.SelectedValue, agencychk, clientchk, executivechk, retainerchk, dpproduct.SelectedValue, hbrand, hvarient, dppagetype.SelectedValue, dppageprem.SelectedValue, dpposprem.SelectedValue, dprostatus.SelectedValue, dpbooktype.SelectedValue, dpcontractname.SelectedValue, filter, adchk, dpstate.SelectedItem.Text, htaluka, dpbased.SelectedValue, drpstatus.SelectedValue, chkdetail, drpinsertstatus.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
        //    else
        //        ds = ncls.completerep(Session["compcode"].ToString(), from_date, to_date, Session["dateformat"].ToString(), dppublication.SelectedValue, dpprintcenter.SelectedValue, hedition, hsuppliment, dpzone.SelectedValue, dpbranch.SelectedItem.Text, dpdistrict.SelectedItem.Text, dpregion.SelectedValue, hcity, dprevcenter.SelectedValue, dpadtype.SelectedValue, dpagencytype.SelectedItem.Text, dpratetype.SelectedValue, hadcat, hadsubcat, hadsubcat3, hadsubcat4, hadsubcat5, dppackage.SelectedValue, dpscheme.SelectedValue, agencychk, clientchk, executivechk, retainerchk, dpproduct.SelectedValue, hbrand, hvarient, dppagetype.SelectedValue, dppageprem.SelectedValue, dpposprem.SelectedValue, dprostatus.SelectedValue, dpbooktype.SelectedValue, dpcontractname.SelectedValue, filter, adchk, dpstate.SelectedItem.Text, htaluka, dpbased.SelectedValue, drpstatus.SelectedValue, chkdetail, drpinsertstatus.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
        //} 
        ////if (ds.Tables[0].Rows.Count == 0)
        ////{
        ////    ScriptManager.RegisterClientScriptBlock(this, typeof(billwisexls), "sa", "alert(\"searching criteria is not valid\");", true);
        ////    return;
        ////}
        else
        {
            int countrw = ds.Tables[0].Rows.Count;
            int cont = ds.Tables[0].Rows.Count;
            if (RadioButton2.Checked != true)
            {
                for (int i = 0; i <= cont - 1; i++)
                {
                    if (ds.Tables[0].Rows[i]["cardamt"].ToString() != "")
                        totalcardamt = totalcardamt + double.Parse(ds.Tables[0].Rows[i]["cardamt"].ToString());
                    if (ds.Tables[0].Rows[i]["Deviationamt"].ToString() != "")
                        totaldeviationdamt = totaldeviationdamt + double.Parse(ds.Tables[0].Rows[i]["Deviationamt"].ToString());
                    if (ds.Tables[0].Rows[i]["aggamt"].ToString() != "")
                        totalaggamt = totalaggamt + double.Parse(ds.Tables[0].Rows[i]["aggamt"].ToString());
                    if (ds.Tables[0].Rows[i]["DiscAmt"].ToString() != "")
                        totaldiscamt = totaldiscamt + double.Parse(ds.Tables[0].Rows[i]["DiscAmt"].ToString());
                    //Post Prem Amt
                    //if (ds.Tables[0].Rows[i]["cardamt"].ToString() != "")
                    //    totalcardamt = totalcardamt + ds.Tables[0].Rows[i]["cardamt"].ToString();
                    if (ds.Tables[0].Rows[i]["Spdiscamt"].ToString() != "")
                        totalspdiscamt = totalspdiscamt + double.Parse(ds.Tables[0].Rows[i]["Spdiscamt"].ToString());
                    //Space Disc Amt
                    //if (ds.Tables[0].Rows[i]["cardamt"].ToString() != "")
                    //    totalcardamt = totalcardamt + ds.Tables[0].Rows[i]["cardamt"].ToString();
                    if (ds.Tables[0].Rows[i]["Specialcharge"].ToString() != "")
                        totalspecialcharges = totalspecialcharges + double.Parse(ds.Tables[0].Rows[i]["Specialcharge"].ToString());
                    if (ds.Tables[0].Rows[i]["AgencyAddlTDAmt"].ToString() != "")
                        totalagaddltdamt = totalagaddltdamt + double.Parse(ds.Tables[0].Rows[i]["AgencyAddlTDAmt"].ToString());
                    if (ds.Tables[0].Rows[i]["Grossamt"].ToString() != "")
                        totalgrossamt = totalgrossamt + double.Parse(ds.Tables[0].Rows[i]["Grossamt"].ToString());
                    if (ds.Tables[0].Rows[i]["RetTDAmt"].ToString() != "")
                        totalretainertdamt = totalretainertdamt + double.Parse(ds.Tables[0].Rows[i]["RetTDAmt"].ToString());
                    if (ds.Tables[0].Rows[i]["AgencyTDAmt"].ToString() != "")
                        totalagtdamt = totalagtdamt + double.Parse(ds.Tables[0].Rows[i]["AgencyTDAmt"].ToString());
                    if (ds.Tables[0].Rows[i]["Billamt"].ToString() != "")
                        totalbillingamt = totalbillingamt + double.Parse(ds.Tables[0].Rows[i]["Billamt"].ToString());
                    if (ds.Tables[0].Rows[i]["RetCommAmt"].ToString() != "")
                        totalretcommamt = totalretcommamt + double.Parse(ds.Tables[0].Rows[i]["RetCommAmt"].ToString());
                    if (ds.Tables[0].Rows[i]["ActualBusiness"].ToString() != "")
                        totalactbusiness = totalactbusiness + double.Parse(ds.Tables[0].Rows[i]["ActualBusiness"].ToString());


                    if ((ds.Tables[0].Rows[i]["Area"]).ToString() != "")
                    {

                        if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "CD" || ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROD")
                            area = area + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        else if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROL")
                            totrol = totrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        else if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROC")
                            totcd = totcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        else if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROW")
                            totcc = totcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());

                    }
                }
            }

            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";

            Response.ContentType = "text/csv";
           // Response.AppendHeader("content-disposition", "attachment; filename=Ex.csv");
            
            if (chk_excel == "1")
            {
                Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
            }
            else
            {
                Response.AppendHeader("content-disposition", "attachment; filename=Ex.csv");
            }
           
            BoundColumn nameColumn0 = new BoundColumn();
            nameColumn0.HeaderText = "S.No";
            DataGrid1.Columns.Add(nameColumn0);
            
           
            if(RadioButton2.Checked == true)
            {

                          string[] list11 = new string[27];
                          String allitem11 = hdnlist.Value;
                          list11 = allitem11.Split(',');
                                

                          for (int dt1 = 0; dt1 < list11.Length - 1; dt1++)
                          {

                              

                              if (list11[dt1] == "Date")

                                    chkDate1 = "1";

                              if (list11[dt1] == "No. Ins")

                                  chkNo_Ins1 = "1";


                              if (list11[dt1] == "Paid Ins")
                                  chkPaid_Ins1 = "1";


                              if (list11[dt1] == "Area")
                                  chkArea1 = "1";


                              if (list11[dt1] == "Page Prem.")
                                  chkPage_Prem1 = "1";


                              if (list11[dt1] == "Card Amt")
                                  chkCard_Amt1 = "1";


                              if (list11[dt1] == "Dvtn. Amt")
                                  chkDvtn_Amt1 = "1";


                              if (list11[dt1] == "Dvtn. (%)")
                                  chkDvtn_per1 = "1";


                              if (list11[dt1] == "Agrd. Amt")
                                  chkAgrd_Amt1 = "1";

                              if (list11[dt1] == "Disc Amt")
                                  chkDisc_Amt1 = "1";

                              if (list11[dt1] == "Disc (%)")
                                  chkDisc_per1 = "1";

                              if (list11[dt1] == "Post Prem. Amt.")
                                  chkPost_Prem_Amt1 = "1";

                              if (list11[dt1] == "Post Prem.(%)")
                                  chkPost_Prem_per1 = "1";

                              if (list11[dt1] == "Sp. Disc Amt")
                                  chkSp_Disc_Amt1 = "1";



                              if (list11[dt1] == "Sp. Disc (%)")
                                  chkSp_Disc1 = "1";

                              if (list11[dt1] == "Ex. Disc Amt")
                                  chkEx_Disc_Amt1 = "1";

                              if (list11[dt1] == "Ex. Disc (%)")
                                  chkEx_Disc_per1 = "1";

                              if (list11[dt1] == "Sp. Charges")
                                  chkSp_Charges1 = "1";

                              if (list11[dt1] == "Add. Age. Td.Amt")
                                  chkAdd_Age_Td_Amt1 = "1";



                              if (list11[dt1] == "Add. Age. Td.(%)")
                                  chkAdd_Age_td_per1 = "1";

                              if (list11[dt1] == "Gr. Amt")
                                  chkGr_Amt1 = "1";

                              if (list11[dt1] == "Ret. Td.Amt")
                                  chkRet_Td_Amt1 = "1";

                              if (list11[dt1] == "Ret. Td.(%)")
                                  chkRet_Td_per1 = "1";



                              if (list11[dt1] == "Age. TD Amt")
                                  chkAge_TD_Amt1 = "1";

                              if (list11[dt1] == "Age. TD (%)")
                                  chkAge_TD_per1 = "1";

                              if (list11[dt1] == "BK.Amt")
                                  chkBK_Amt1 = "1";

                              if (list11[dt1] == "Ret. Comm Amt")
                                  chkRet_Comm_Amt1 = "1";

                              if (list11[dt1] == "Ret. Comm (%)")
                                  chkRet_Comm_per1 = "1";

                              if (list11[dt1] == "Actl. Bus.")
                                  chkActl_Bus1 = "1";



                          }

                          if (chkDate1 == "1")
                          {

                              BoundColumn nameColumn31 = new BoundColumn();
                              if (adchk == "3")
                              {
                                  nameColumn31.HeaderText = "Publish Date";
                                   name1 = name1 + "," + "Publish Date";
                              }
                              else if (adchk == "2")
                              {
                                  nameColumn31.HeaderText = "Bill Date";
                                   name1 = name1 + "," + "Bill Date";
                              }
                              else
                              {
                                  nameColumn31.HeaderText = "Booking Date";
                                   name1 = name1 + "," + "Booking Date";
                              }
                              nameColumn31.DataField = "Date";

							  
                         name2 = name2 + "," + "Date";
                         name3 = name3 + "," + "G";

                              DataGrid1.Columns.Add(nameColumn31);
                          }

                          if (chkNo_Ins1 == "1")
                          {

                              BoundColumn nameColumn = new BoundColumn();
                              nameColumn.HeaderText = "No. Ins";
                              nameColumn.DataField = "noinsert";
                                name1 = name1 + "," + "No. Ins";
                               name2 = name2 + "," + "noinsert";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn);
                          }
                        
                          if (chkPaid_Ins1 == "1")
                          {


                              BoundColumn nameColumn1 = new BoundColumn();
                              nameColumn1.HeaderText = "Paid Ins";
                              nameColumn1.DataField = "Paidinsert";

                               name1 = name1 + "," +"Paid Ins";
                               name2 = name2 + "," + "Paidinsert";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn1);
                          }
                          if (chkArea1 == "1")
                          {

                              BoundColumn nameColumn2 = new BoundColumn();
                              nameColumn2.HeaderText = "Area";
                              nameColumn2.DataField = "Area";

                               name1 = name1 + "," +"Area";
                               name2 = name2 + "," +  "Area";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn2);
                          }
                        
                        
                          if (chkCard_Amt1 == "1")
                          {

                              BoundColumn nameColumn4 = new BoundColumn();
                              nameColumn4.HeaderText = "Card Amt";
                              nameColumn4.DataField = "cardamt";

                                 name1 = name1 + "," +"Card Amt";
                               name2 = name2 + "," +   "cardamt";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn4);
                          }

                          if (chkDvtn_Amt1 == "1")
                          {

                              BoundColumn nameColumn6 = new BoundColumn();
                              nameColumn6.HeaderText = "Dvtn. Amt";
                              nameColumn6.DataField = "Deviationamt";

                                 name1 = name1 + "," + "Dvtn. Amt";
                               name2 = name2 + "," +  "Deviationamt";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn6);
                          }
                          if (chkDvtn_per1 == "1")
                          {

                              BoundColumn nameColumn7 = new BoundColumn();
                              nameColumn7.HeaderText = "Dvtn. (%)";
                              nameColumn7.DataField = "Deviation(%)";

                                name1 = name1 + "," + "Dvtn. (%)";
                               name2 = name2 + "," +  "Deviation(%)";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn7);
                          }

                          if (chkAgrd_Amt1 == "1")
                          {

                              BoundColumn nameColumn9 = new BoundColumn();
                              nameColumn9.HeaderText = "Agrd. Amt";
                              nameColumn9.DataField = "aggamt";

                               name1 = name1 + "," +  "Agrd. Amt";
                               name2 = name2 + "," + "aggamt";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn9);
                          }

                          if (chkDisc_Amt1 == "1")
                          {
                              BoundColumn nameColumn10 = new BoundColumn();
                              nameColumn10.HeaderText = "Disc Amt";
                              nameColumn10.DataField = "DiscAmt";

                               name1 = name1 + "," +  "Disc Amt";
                               name2 = name2 + "," + "DiscAmt";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn10);
                          }
                          if (chkDisc_per1 == "1")
                          {

                              BoundColumn nameColumn11 = new BoundColumn();
                              nameColumn11.HeaderText = "Disc (%)";
                              nameColumn11.DataField = "Discper";

                               name1 = name1 + "," +  "Disc (%)";
                               name2 = name2 + "," +  "Discper";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn11);
                          }
                          if (chkPost_Prem_Amt1 == "1")
                          {

                              BoundColumn nameColumn12 = new BoundColumn();
                              nameColumn12.HeaderText = "Post Prem. Amt.";
                              nameColumn12.DataField = "Posamt";

                                name1 = name1 + "," + "Post Prem. Amt.";
                               name2 = name2 + "," + "Posamt";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn12);
                          }
                          if (chkPost_Prem_per1 == "1")
                          {

                              BoundColumn nameColumn13 = new BoundColumn();
                              nameColumn13.HeaderText = "Post Prem.(%)";
                              nameColumn13.DataField = "Pos(%)";

                               name1 = name1 + "," +"Post Prem.(%)";
                               name2 = name2 + "," + "Pos(%)";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn13);
                          }
                          if (chkSp_Disc_Amt1 == "1")
                          {

                              BoundColumn nameColumn14 = new BoundColumn();
                              nameColumn14.HeaderText = "Sp. Disc Amt";
                              nameColumn14.DataField = "Spdiscamt";

                                name1 = name1 + "," +"Sp. Disc Amt";
                               name2 = name2 + "," +"Spdiscamt";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn14);
                          }

                          if (chkSp_Disc1 == "1")
                          {

                              BoundColumn nameColumn15 = new BoundColumn();
                              nameColumn15.HeaderText = "Sp. Disc (%)";
                              nameColumn15.DataField = "Spdiscper";

                               name1 = name1 + "," + "Sp. Disc (%)";
                               name2 = name2 + "," +"Spdiscper";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn15);
                          }
                          if (chkEx_Disc_Amt1 == "1")
                          {

                              BoundColumn nameColumn16 = new BoundColumn();
                              nameColumn16.HeaderText = "Ex. Disc Amt";
                              nameColumn16.DataField = "Spacedisc";

                                name1 = name1 + "," + "Ex. Disc Amt";
                               name2 = name2 + "," +"Spacedisc";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn16);
                          }
                          if (chkEx_Disc_per1 == "1")
                          {

                              BoundColumn nameColumn17 = new BoundColumn();
                              nameColumn17.HeaderText = "Ex. Disc (%)";
                              nameColumn17.DataField = "Spacediscper";

                                name1 = name1 + "," +  "Ex. Disc (%)";
                               name2 = name2 + "," + "Spacediscper";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn17);
                          }
                          if (chkSp_Charges1 == "1")
                          {

                              BoundColumn nameColumn18 = new BoundColumn();
                              nameColumn18.HeaderText = "Sp. Charges";
                              nameColumn18.DataField = "Specialcharge";

                               name1 = name1 + "," + "Sp. Charges";
                               name2 = name2 + "," +  "Specialcharge";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn18);
                          }

                          if (chkAdd_Age_Td_Amt1 == "1")
                          {

                              BoundColumn nameColumn19 = new BoundColumn();
                              nameColumn19.HeaderText = "Add. Age. Td.Amt";
                              nameColumn19.DataField = "AgencyAddlTDAmt";

                                name1 = name1 + "," + "Add. Age. Td.Amt";
                               name2 = name2 + "," +  "AgencyAddlTDAmt";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn19);
                          }
                          if (chkAdd_Age_td_per1 == "1")
                          {

                              BoundColumn nameColumn20 = new BoundColumn();
                              nameColumn20.HeaderText = "Add. Age. Td.(%)";
                              nameColumn20.DataField = "AgencyAddlTD(%)";

                               name1 = name1 + "," + "Add. Age. Td.(%)";
                               name2 = name2 + "," +  "AgencyAddlTD(%)";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn20);
                          }
                          if (chkGr_Amt1 == "1")
                          {

                              BoundColumn nameColumn21 = new BoundColumn();
                              nameColumn21.HeaderText = "Gr. Amt";
                              nameColumn21.DataField = "Grossamt";

                               name1 = name1 + "," +"Gr. Amt";
                               name2 = name2 + "," +   "Grossamt";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn21);
                          }
                          if (chkRet_Td_Amt1 == "1")
                          {

                              BoundColumn nameColumn22 = new BoundColumn();
                              nameColumn22.HeaderText = "Ret. Td.Amt";
                              nameColumn22.DataField = "RetTDAmt";

                                name1 = name1 + "," +"Ret. Td.Amt";
                               name2 = name2 + "," +  "RetTDAmt";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn22);
                          }
                          if (chkRet_Td_per1 == "1")
                          {

                              BoundColumn nameColumn23 = new BoundColumn();
                              nameColumn23.HeaderText = "Ret. Td.(%)";
                              nameColumn23.DataField = "RetTD(%)";

                               name1 = name1 + "," +"Ret. Td.(%)";
                               name2 = name2 + "," +  "RetTD(%)";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn23);
                          }
                          if (chkAge_TD_Amt1 == "1")
                          {

                              BoundColumn nameColumn24 = new BoundColumn();
                              nameColumn24.HeaderText = "Age. TD Amt";
                              nameColumn24.DataField = "AgencyTDAmt";

                                name1 = name1 + "," + "Age. TD Amt";
                               name2 = name2 + "," + "AgencyTDAmt";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn24);
                          }
                          if (chkAge_TD_per1 == "1")
                          {

                              BoundColumn nameColumn25 = new BoundColumn();
                              nameColumn25.HeaderText = "Age. TD (%)";
                              nameColumn25.DataField = "AgencyTD(%)";

                               name1 = name1 + "," +  "Age. TD (%)";
                               name2 = name2 + "," +  "AgencyTD(%)";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn25);
                          }
                          if (chkBK_Amt1 == "1")
                          {

                              BoundColumn nameColumn26 = new BoundColumn();
                              nameColumn26.HeaderText = "BK.Amt";
                              nameColumn26.DataField = "Billamt";

                                name1 = name1 + "," +  "BK.Amt";
                                name2 = name2 + "," +   "Billamt";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn26);
                          }
                          if (chkRet_Comm_Amt1 == "1")
                          {

                              BoundColumn nameColumn27 = new BoundColumn();
                              nameColumn27.HeaderText = "Ret. Comm Amt";
                              nameColumn27.DataField = "RetCommAmt";

                                name1 = name1 + "," +  "Ret. Comm Amt";
                                name2 = name2 + "," + "RetCommAmt";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn27);
                          }
                          if (chkRet_Comm_per1 == "1")
                          {

                              BoundColumn nameColumn28 = new BoundColumn();
                              nameColumn28.HeaderText = "Ret. Comm (%)";
                              nameColumn28.DataField = "RetComm(%)";

                               name1 = name1 + "," +  "Ret. Comm (%)";
                                name2 = name2 + "," + "RetComm(%)";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn28);
                          }
                          
                          if (chkActl_Bus1 == "1")
                          {

                              BoundColumn nameColumn29 = new BoundColumn();
                              nameColumn29.HeaderText = "Actl. Bus.";
                              nameColumn29.DataField = "ActualBusiness";

                               name1 = name1 + "," + "Actl. Bus.";
                                name2 = name2 + "," + "ActualBusiness";
                                name3 = name3 + "," + "G";
                              DataGrid1.Columns.Add(nameColumn29);
                          }

                          if (chk_excel == "1")
                          {
                              DataGrid1.DataSource = ds;
                              System.IO.StringWriter sw = new System.IO.StringWriter();
                              HtmlTextWriter hw = new HtmlTextWriter(sw);
                              DataGrid1.ShowHeader = true;
                              DataGrid1.ShowFooter = true;
                              DataGrid1.DataBind();
                              hw.Write("<p align=\"left\"><b>" + ds.Tables[1].Rows[0]["companyname"].ToString() + "</b>");
                              hw.Write("<p align=\"left\"><b>From Date:</b>" + txtfromdate.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>To Date:</b>" + txttodate.Text);
                     
                              hw.Write("<p align=\"left\"><b>Run Date:</b>" + ds.Tables[1].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>Complete Report<b>");
                              hw.WriteBreak();
                              DataGrid1.RenderControl(hw);
                              Response.Write(sw.ToString().Replace("</table>", "<tr></tr></table>"));
                          }
                          else
                          {
                              DataGrid1.DataSource = ds;
                              if (name2.Length <= 0)
                              {
                                  Response.Write("<script>alert('This Field is not valid to display data');return false;</script>");
                                  return;

                              }
                              else
                              {
                                  string[] names = name2.Substring(1, name2.Length - 1).Split(',');
                                  string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
                                  string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
                                  string[][] colProperties ={ names, captions, formats };

                                  QueryToCSV(ds, colProperties);
                              }
                          }
                       


           }
           else
           {

          
            string[] list1 = new string[51];
            String allitem = hdnlist.Value;
            list1 = allitem.Split(',');
            

           
            for (int dt = 0; dt < list1.Length-1; dt++)
            {
  if (list1[dt] == "Booking Id")

chkid = "1";


if (list1[dt] == "Booking Date/Bill No")
   chkbookdate="1";


if(list1[dt] == "Agency Name")
       chkagencyname="1";


if(list1[dt] == "Client Name")
       chkclientname="1";


if(list1[dt] == "RO No.")
       chkrono="1";


if(list1[dt] == "RO Date")
       chkrodate="1";


 if(list1[dt] == "Exe/Ret Name")
       chkexe="1";


if(list1[dt]== "Booking Type")
       chkbooktype="1";

if(list1[dt] == "Color")
       chkcolor="1";

if(list1[dt] == "Ad Cat")
       chkadcat="1";

if(list1[dt] == "Ad Subcat")
       chkadsubcat="1";

if(list1[dt] == "Ad Subcat3")
       chkadsubcat3="1";

if(list1[dt] == "Ad Subcat4")
       chkadsubcat4="1";



if(list1[dt] == "Package")
       chkpackage="1";

   if (list1[dt] == "Publish Date/Bill Date")
       chkpubdate="1";

if(list1[dt] == "No of Ins.")
       chkpubdate="1";

if(list1[dt] == "Paid Ins.")
       chkpaidins="1";

if(list1[dt] == "AdSize(H*W)")
       chkadsize="1";



if(list1[dt] == "Area")
       chkarea="1";

if(list1[dt] == "Page Prem.")
       chkpageprem="1";

if(list1[dt] == "Position Prem.")
       chkposprem="1";

if(list1[dt] == "Scheme Type")
       chkscheme="1";



if(list1[dt] == "Rate Code")
       chkrate="1";

if(list1[dt] == "Card Rate")
       chkcardrate="1";

if(list1[dt] == "Card Amt")
       chkcardamt="1";

if(list1[dt] == "Contract Rate")
       chkcontract="1";

if(list1[dt] == "Deviation Amt")
       chkdevamt="1";

if(list1[dt] == "Deviation(%)")
       chkdevper="1";



if(list1[dt] == "Agg Rate")
       chkagrate="1";

if(list1[dt] == "Agg Amt")
       chkagamt="1";

if(list1[dt] == "Disc Amt")
       chkdiscamt="1";

if(list1[dt] == "Disc(%)")
       chkdiscper="1";

if(list1[dt] == "Post Prem Amt")
       chkpospremper="1";

if(list1[dt] == "Post Prem(%)")
       chkpospremamt="1";

if(list1[dt] == "Sp. Disc Amt")
       chkspdiscamt="1";



if(list1[dt] == "Sp. Disc(%)")
       chkspdiscper="1";

if(list1[dt] == "Space Disc Amt")
       chkspacediscamt="1";

if(list1[dt] == "Space Disc(%)")
       chkspacediscper="1";

if(list1[dt] == "Special Charges")
       chkspcharge="1";

if(list1[dt] == "Ag. Addl. TD Amt")
       chkagadtdamt="1";

if(list1[dt] == "Ag. Addl. TD(%)")
       chkagadtdper="1";


if(list1[dt] == "Gross Amt")
       chkgrossamt="1";

if(list1[dt] == "Retainer TD Amt")
       chkrettdamt="1";

if(list1[dt] == "Retainer TD(%)")
       chkrettdper="1";

if(list1[dt] == "Ag. TD Amt")
       chkagtdamt="1";

if(list1[dt] == "Ag. TD(%)")
       chkagtdper="1";

if(list1[dt] == "Billing Amt")
       chkbillamt="1";


if(list1[dt] == "Ret. Comm. Amt")
       chkretcomamt="1";

if(list1[dt] == "Ret. Comm(%)")
       chkretcomper="1";

if(list1[dt] == "Actual Business")
       chkactbusiness="1";

if(list1[dt] == "Revenue Center")
       chkrevcenter="1";

   if (list1[dt] == "Uom")
       chkuom = "1";

   if (list1[dt] == "Publication")
       chkpublication = "1";

   if (list1[dt] == "Edition")
       chkedition = "1";

   if (list1[dt] == "Printing Center")
       chkprintcenter = "1";

   if (list1[dt] == "Branch")
       chkbranch = "1";

   if (list1[dt] == "District")
       chkdistrict = "1";

   if (list1[dt] == "Taluka")
       chktaluka = "1";

   if (list1[dt] == "Page No")
       chkpageno = "1";

   if (list1[dt] == "Cash Disc")
       chkcashdisc = "1";

   if (list1[dt] == "Box Code")
       chkboxcycle = "1";

   if (list1[dt] == "Status")
       chkstatus = "1";

   if (list1[dt] == "User Id")
       chkuserid = "1";

   if (list1[dt] == "User Name")
       chkusername = "1";

   if (list1[dt] == "Bill Remark")
       chkbillremark = "1";

   if (list1[dt] == "Product")
       chkproduct = "1";

   if (list1[dt] == "Brand")
       chkbrand = "1";

   if (list1[dt] == "Varient")
       chkVarient = "1";

   if (list1[dt] == "Caption")
       chkCaption = "1";

   if (list1[dt] == "FMG Reason")
       chkfmgreason = "1";
                                
}

               if (chkid == "1")
                  {

                      BoundColumn nameColumn = new BoundColumn();
                      nameColumn.HeaderText = "Booking Id";
                      nameColumn.DataField = "CIOID";

					             name1 = name1 + "," + "Booking Id";
							    name2 = name2 + "," +  "CIOID";
						        name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn);
                  }
                  if (chkbookdate == "1")
                  {
                      if (adchk == "1" || adchk == "3")
                      {
                          BoundColumn nameColumnag = new BoundColumn();
                          nameColumnag.HeaderText = "Booking Date";
                          nameColumnag.DataField = "BookDate";                        
                          nameColumnag.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
						 name1 = name1 + "," +  "Booking Date";
					     name2 = name2 + "," +  "BookDate";
						 name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumnag);
                      }
                      else if (adchk == "2")
                      {
                          BoundColumn nameColumnag = new BoundColumn();
                          nameColumnag.HeaderText = "Bill No";
                          nameColumnag.DataField = "Billno";

						    name1 = name1 + "," +   "Bill No";
							    name2 = name2 + "," +   "Billno";
						        name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumnag);
                      }
                  }
                  if (chkagencyname == "1")
                  {


                      BoundColumn nameColumn1 = new BoundColumn();
                      nameColumn1.HeaderText = "Agency";
                      nameColumn1.DataField = "Agency";

					   name1 = name1 + "," +  "Agency";
							    name2 = name2 + "," +  "Agency";
						        name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn1);
                  }
                  if (chkclientname == "1")
                  {

                      BoundColumn nameColumn2 = new BoundColumn();
                      nameColumn2.HeaderText = "Client";
                      nameColumn2.DataField = "Client";

					    name1 = name1 + "," +   "Client";
							    name2 = name2 + "," +  "Client";
						        name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn2);
                  }
                  if (adchk == "3")
                  {
                      if (chkpublication == "1")
                      {

                          BoundColumn namep1 = new BoundColumn();
                          namep1.HeaderText = "Publication";
                          namep1.DataField = "Publication";

						   name1 = name1 + "," +  "Publication";
							    name2 = name2 + "," + "Publication";
						        name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(namep1);
                      }
                      if (chkedition == "1")
                      {

                          BoundColumn namep12 = new BoundColumn();
                          namep12.HeaderText = "Edition";
                          namep12.DataField = "Edition";

						   name1 = name1 + "," +  "Edition";
							    name2 = name2 + "," + "Edition";
						        name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(namep12);
                      }
                  }
                  if (chkprintcenter == "1")
                  {

                      BoundColumn ret1 = new BoundColumn();
                      ret1.HeaderText = "Printing Center ";
                      ret1.DataField = "Printcenter";

					   name1 = name1 + "," +  "Printing Center ";
						 name2 = name2 + "," + "Printcenter";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(ret1);
                  }
                  if (chkbranch == "1")
                  {

                      BoundColumn ret2 = new BoundColumn();
                      ret2.HeaderText = "Branch";
                      ret2.DataField = "Branch";

					   name1 = name1 + "," +  "Branch";
						 name2 = name2 + "," + "Branch";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(ret2);
                  }
                  if (chkdistrict == "1")
                  {

                      BoundColumn ret3 = new BoundColumn();
                      ret3.HeaderText = "District";
                      ret3.DataField = "District";

					   name1 = name1 + "," +   "District";
						 name2 = name2 + "," +  "District";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(ret3);
                  }
                  if (chktaluka == "1")
                  {

                      BoundColumn ret4 = new BoundColumn();
                      ret4.HeaderText = "Taluka";
                      ret4.DataField = "Taluka";

					    name1 = name1 + "," +   "Taluka";
						 name2 = name2 + "," +  "Taluka";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(ret4);
                  }
                  if (chkrono == "1")
                  {

                      BoundColumn nameColumn3 = new BoundColumn();
                      nameColumn3.HeaderText = "RoNo.";
                      nameColumn3.DataField = "RoNo.";

					    name1 = name1 + "," +    "RoNo.";
						 name2 = name2 + "," +  "RoNo.";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn3);
                  }
                  if (chkrodate == "1")
                  {

                      BoundColumn nameColumn4 = new BoundColumn();
                      nameColumn4.HeaderText = "Ro.Date";
                      nameColumn4.DataField = "Ro.Date";
                      nameColumn4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
					   name1 = name1 + "," +   "Ro.Date";
						 name2 = name2 + "," + "Ro.Date";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn4);
                  }
                  if (chkexe == "1")
                  {
                      if (dpbased.SelectedValue == "1")
                      {
                          BoundColumn nameColumn5 = new BoundColumn();
                          nameColumn5.HeaderText = "Executive";
                          nameColumn5.DataField = "Executive";

						   name1 = name1 + "," +  "Executive";
						 name2 = name2 + "," + "Executive";
						name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumn5);

                          BoundColumn nameColumn05 = new BoundColumn();
                          nameColumn05.HeaderText = "Retainer";
                          nameColumn05.DataField = "Retainer";

						    name1 = name1 + "," + "Retainer";
						 name2 = name2 + "," +"Retainer";
						name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumn05);
                      }
                      else if (dpbased.SelectedValue == "2")
                      {
                          BoundColumn nameColumn5 = new BoundColumn();
                          nameColumn5.HeaderText = "Executive";
                          nameColumn5.DataField = "Executive";

						   name1 = name1 + "," +  "Executive";
						 name2 = name2 + "," +   "Executive";
						name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumn5);
                      }
                      else if (dpbased.SelectedValue == "3")
                      {
                          BoundColumn nameColumn05 = new BoundColumn();
                          nameColumn05.HeaderText = "Retainer";
                          nameColumn05.DataField = "Retainer";

						    name1 = name1 + "," + "Retainer";
						 name2 = name2 + "," +    "Retainer";
						name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumn05);
                      }
                      
                  }
                  if (chkbooktype == "1")
                  {

                      BoundColumn nameColumn6 = new BoundColumn();
                      nameColumn6.HeaderText = "Booking Type";
                      nameColumn6.DataField = "BookType";

					      name1 = name1 + "," +"Booking Type";
						 name2 = name2 + "," +   "BookType";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn6);
                  }
                  if (chkcolor == "1")
                  {

                      BoundColumn nameColumn7 = new BoundColumn();
                      nameColumn7.HeaderText = "Color";
                      nameColumn7.DataField = "Color";

					   name1 = name1 + "," +"Color";
						 name2 = name2 + "," + "Color";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn7);
                  }

                  if (chkadcat == "1")
                  {

                      BoundColumn nameColumn9 = new BoundColumn();
                      nameColumn9.HeaderText = "Adcat";
                      nameColumn9.DataField = "Adcat";

					   name1 = name1 + "," + "Adcat";
						 name2 = name2 + "," + "Adcat";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn9);
                  }

                  if (chkadsubcat == "1")
                  {
                      BoundColumn nameColumn10 = new BoundColumn();
                      nameColumn10.HeaderText = "Adsubcat";
                      nameColumn10.DataField = "Adsubcat";

					  	   name1 = name1 + "," +  "Adsubcat";
						 name2 = name2 + "," +"Adsubcat";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn10);
                  }
                  if (chkadsubcat3 == "1")
                  {

                      BoundColumn nameColumn11 = new BoundColumn();
                      nameColumn11.HeaderText = "Adsubcat3";
                      nameColumn11.DataField = "Adsubcat3";

					   name1 = name1 + "," + "Adsubcat3";
						 name2 = name2 + "," +"Adsubcat3";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn11);
                  }
                  if (chkadsubcat4 == "1")
                  {

                      BoundColumn nameColumn12 = new BoundColumn();
                      nameColumn12.HeaderText = "Adsubcat4";
                      nameColumn12.DataField = "Adsubcat4";

					    name1 = name1 + "," +  "Adsubcat4";
						 name2 = name2 + "," + "Adsubcat4";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn12);
                  }
         
                 
                  if (chkpackage == "1")
                  {
                      BoundColumn nameColumn14 = new BoundColumn();
                      nameColumn14.HeaderText = "Package";
                      nameColumn14.DataField = "Package";

					    name1 = name1 + "," +  "Package";
						 name2 = name2 + "," + "Package";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn14);
                  }
                  if (chkpubdate == "1")
                  {
                      if (adchk == "1" || adchk == "3")
                      {
                          BoundColumn nameColumn15 = new BoundColumn();
                          nameColumn15.HeaderText = "Publish Date";
                          nameColumn15.DataField = "PubDate";
                          nameColumn15.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
						    name1 = name1 + "," +   "Publish Date";
						 name2 = name2 + "," + "PubDate";
						name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumn15);
                      }
                      else if (adchk == "2")
                      {
                          BoundColumn nameColumn15 = new BoundColumn();
                          nameColumn15.HeaderText = "Bill Date";
                          nameColumn15.DataField = "BillDate";
                          nameColumn15.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
						    name1 = name1 + "," +   "Bill Date";
						 name2 = name2 + "," +  "BillDate";
						name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumn15);
                      }
                  }
                  if (adchk != "3")
                  {
                      if (chkpubdate == "1")
                      {

                          BoundColumn nameColumn8 = new BoundColumn();
                          nameColumn8.HeaderText = "No. of Insertions";
                          nameColumn8.DataField = "noinsert";

					name1 = name1 + "," +  "No. of Insertions";
						 name2 = name2 + "," +   "noinsert";
						name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumn8);
                      }
                      if (chkpaidins == "1")
                      {

                          BoundColumn nameColumn16 = new BoundColumn();
                          nameColumn16.HeaderText = "Paid Insertion";
                          nameColumn16.DataField = "Paidinsert";

						  	name1 = name1 + "," +  "Paid Insertion";
						 name2 = name2 + "," +  "Paidinsert";
						name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumn16);
                      }
                  }

                  if (chkpageno == "1")
                  {
                      BoundColumn nameColumn1v8 = new BoundColumn();
                      nameColumn1v8.HeaderText = "Page No";
                      nameColumn1v8.DataField = "Page_No";

                      name1 = name1 + "," + "Page No";
                      name2 = name2 + "," + "Page_No";
                      name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn1v8);

                  }


                  if (chkadsize == "1")
                  {

                      BoundColumn nameColumn17 = new BoundColumn();
                      nameColumn17.HeaderText = "Height";
                      nameColumn17.DataField = "height";
					  	name1 = name1 + "," +  "Height";
						 name2 = name2 + "," +   "height";
						name3 = name3 + "," + "G";



                      DataGrid1.Columns.Add(nameColumn17);

                      BoundColumn nameColumn178 = new BoundColumn();
                      nameColumn178.HeaderText = "Width";
                      nameColumn178.DataField = "width";

					    	name1 = name1 + "," +  "Width";
						 name2 = name2 + "," +   "width";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn178);
                  }
                  if (chkarea == "1")
                  {

                      BoundColumn nameColumn18 = new BoundColumn();
                      nameColumn18.HeaderText = "Area";
                      nameColumn18.DataField = "Area";

					  name1 = name1 + "," +  "Area";
						 name2 = name2 + "," + "Area";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn18);
                  }
                  //if (adchk != "2")
                  //{
                      if (chkuom == "1")
                      {

                          BoundColumn nameColumnpk = new BoundColumn();
                          nameColumnpk.HeaderText = "Uom";
                          nameColumnpk.DataField = "Uom";

						    name1 = name1 + "," + "Uom";
						 name2 = name2 + "," +"Uom";
						name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumnpk);
                      }
                 // }
                  if (chkpageprem == "1")
                  {

                      BoundColumn nameColumn19 = new BoundColumn();
                      nameColumn19.HeaderText = "Page Premium";
                      nameColumn19.DataField = "Pagepremium";

					    name1 = name1 + "," +  "Page Premium";
						 name2 = name2 + "," +"Pagepremium";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn19);
                  }
                  if (chkposprem == "1")
                  {

                      BoundColumn nameColumn20 = new BoundColumn();
                      nameColumn20.HeaderText = "Position Premium";
                      nameColumn20.DataField = "Postprem";

					    name1 = name1 + "," +   "Position Premium";
						 name2 = name2 + "," + "Postprem";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn20);
                  }
                  if (chkscheme == "1")
                  {

                      BoundColumn nameColumn21 = new BoundColumn();
                      nameColumn21.HeaderText = "scheme";
                      nameColumn21.DataField = "scheme";

					   name1 = name1 + "," +  "scheme";
						 name2 = name2 + "," +"scheme";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn21);
                  }
                
                  if (chkrate == "1")
                  {
                      BoundColumn ter = new BoundColumn();
                      ter.HeaderText = "Rate Code";
                      ter.DataField = "Ratecode";

					   name1 = name1 + "," +  "Rate Code";
						 name2 = name2 + "," +"Ratecode";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(ter);
                  }
                  if (chkcardrate == "1")
                  {
                      BoundColumn nameColumn22 = new BoundColumn();
                      nameColumn22.HeaderText = "Card Rate";
                      nameColumn22.DataField = "cardrate";

					    name1 = name1 + "," +   "Card Rate";
						 name2 = name2 + "," +"cardrate";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn22);
                  }
                  if (adchk != "3")
                  {
                      if (chkcardamt == "1")
                      {

                          BoundColumn nameColumn23 = new BoundColumn();
                          nameColumn23.HeaderText = "Card Amt";
                          nameColumn23.DataField = "cardamt";

						   name1 = name1 + "," +  "Card Amt";
						 name2 = name2 + "," +   "cardamt";
						name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumn23);
                      }
                  }
                  if (chkcontract == "1")
                  {

                      BoundColumn nameColumn24 = new BoundColumn();
                      nameColumn24.HeaderText = "Contract Rate";
                      nameColumn24.DataField = "contractrate";

					    name1 = name1 + "," +   "Contract Rate";
						 name2 = name2 + "," +   "contractrate";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn24);
                  }
                  if (chkdevamt == "1")
                  {

                      BoundColumn nameColumn26 = new BoundColumn();
                      nameColumn26.HeaderText = "Deviation Amt";
                      nameColumn26.DataField = "Deviationamt";

					    name1 = name1 + "," +   "Deviation Amt";
						 name2 = name2 + "," +   "Deviationamt";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn26);
                  }

                  if (chkdevper == "1")
                  {
                      BoundColumn nameColumn27 = new BoundColumn();
                      nameColumn27.HeaderText = "Deviation(%)";
                      nameColumn27.DataField = "Deviation(%)";

					    name1 = name1 + "," +    "Deviation(%)";
						 name2 = name2 + "," +   "Deviation(%)";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn27);
                  }
                  if (chkagrate == "1")
                  {
                      BoundColumn nameColumn28 = new BoundColumn();
                      nameColumn28.HeaderText = "Agg. Rate";
                      nameColumn28.DataField = "Aggrate";

					    name1 = name1 + "," +   "Agg. Rate";
						 name2 = name2 + "," +   "Aggrate";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn28);
                  }
                  if (chkagamt == "1")
                  {

                      BoundColumn nameColumn29 = new BoundColumn();
                      nameColumn29.HeaderText = "Agg. Amt";
                      nameColumn29.DataField = "aggamt";

					    name1 = name1 + "," +  "Agg. Amt";
						 name2 = name2 + "," +   "aggamt";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn29);
                  }
                  if (chkdiscamt == "1")
                  {

                      BoundColumn nameColumn30 = new BoundColumn();
                      nameColumn30.HeaderText = "Disc. Amt";
                      nameColumn30.DataField = "DiscAmt";

					    name1 = name1 + "," +  "Disc. Amt";
						 name2 = name2 + "," +  "DiscAmt";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn30);
                  }

                  if (chkdiscper == "1")
                  {
                      BoundColumn nameColumn31 = new BoundColumn();
                      nameColumn31.HeaderText = "Disc.(%)";
                      nameColumn31.DataField = "Discper";

					    name1 = name1 + "," +   "Disc.(%)";
						 name2 = name2 + "," +  "Discper";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn31);
                  }

                  //////////////////////NEED TO CHANGE
                  if (chkpospremper == "1")
                  {
                      BoundColumn nameColumn32 = new BoundColumn();
                      nameColumn32.HeaderText = "Post Prem(%)";
                      nameColumn32.DataField = "pos(%)";

					      name1 = name1 + "," +    "Post Prem(%)";
						 name2 = name2 + "," +  "pos(%)";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn32);
                  }
                  if (chkpospremamt == "1")
                  {
                      BoundColumn nameColumn33 = new BoundColumn();
                      nameColumn33.HeaderText = "Post Prem Amt";
                      nameColumn33.DataField = "posamt";

					        name1 = name1 + "," +   "Post Prem Amt";
						 name2 = name2 + "," +  "posamt";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn33);
                  }
                  ///////////////////////////NEED TO CHANGE

                  if (chkspdiscamt == "1")
                  {
                      BoundColumn nameColumn34 = new BoundColumn();
                      nameColumn34.HeaderText = "Sp. disc Amt";
                      nameColumn34.DataField = "Spdiscamt";

					     name1 = name1 + "," + "Sp. disc Amt";
						 name2 = name2 + "," +  "Spdiscamt";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn34);
                  }
                  if (chkspdiscper == "1")
                  {

                      BoundColumn nameColumn35 = new BoundColumn();
                      nameColumn35.HeaderText = "Sp. disc(%)";
                      nameColumn35.DataField = "Spdiscper";

					    name1 = name1 + "," +  "Sp. disc(%)";
						 name2 = name2 + "," +  "Spdiscper";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn35);
                  }
                  if (chkspacediscamt == "1")
                  {

                      BoundColumn nameColumn36 = new BoundColumn();
                      nameColumn36.HeaderText = "Space disc Amt";
                      nameColumn36.DataField = "Spacedisc";

					    name1 = name1 + "," +  "Space disc Amt";
						 name2 = name2 + "," + "Spacedisc";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn36);
                  }
                  if (chkspacediscper == "1")
                  {
                      BoundColumn nameColumn37 = new BoundColumn();
                      nameColumn37.HeaderText = "Space disc(%)";
                      nameColumn37.DataField = "Spacediscper";

					      name1 = name1 + "," +   "Space disc(%)";
						 name2 = name2 + "," + "Spacediscper";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn37);
                  }
                  if (chkspcharge == "1")
                  {

                      BoundColumn nameColumn38 = new BoundColumn();
                      nameColumn38.HeaderText = "Special Charge";
                      nameColumn38.DataField = "Specialcharge";

					      name1 = name1 + "," +   "Special Charge";
						 name2 = name2 + "," + "Specialcharge";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn38);
                  }
                  if (chkgrossamt == "1")
                  {

                      BoundColumn nameColumn41 = new BoundColumn();
                      nameColumn41.HeaderText = "Gross Amt";
                      nameColumn41.DataField = "Grossamt";

					     name1 = name1 + "," +   "Gross Amt";
						 name2 = name2 + "," +  "Grossamt";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn41);
                  }
                  if (chkagadtdamt == "1")
                  {

                      BoundColumn nameColumn39 = new BoundColumn();
                      nameColumn39.HeaderText = "Ag. Addl. TD Amt";
                      nameColumn39.DataField = "AgencyAddlTDAmt";

					    name1 = name1 + "," +   "Ag. Addl. TD Amt";
						 name2 = name2 + "," + "AgencyAddlTDAmt";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn39);
                  }
                  if (chkagadtdper == "1")
                  {
                      BoundColumn nameColumn40 = new BoundColumn();
                      nameColumn40.HeaderText = "Ag. Addl. TD(%)";
                      nameColumn40.DataField = "AgencyAddlTD(%)";

					    name1 = name1 + "," +   "Ag. Addl. TD(%)";
						 name2 = name2 + "," + "AgencyAddlTD(%)";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn40);
                  }
                  if (chkagtdamt == "1")
                  {
                      BoundColumn nameColumn44 = new BoundColumn();
                      nameColumn44.HeaderText = "Agency TD Amt";
                      nameColumn44.DataField = "AgencyTDAmt";

					    name1 = name1 + "," +  "Agency TD Amt";
						 name2 = name2 + "," +  "AgencyTDAmt";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn44);
                  }
                  if (chkagtdper == "1")
                  {

                      BoundColumn nameColumn45 = new BoundColumn();
                      nameColumn45.HeaderText = "Agency TD(%)";
                      nameColumn45.DataField = "AgencyTD(%)";

					    name1 = name1 + "," +  "Agency TD(%)";
						 name2 = name2 + "," +  "AgencyTD(%)";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn45);
                  }
                  if (chkrettdamt == "1")
                  {
                      BoundColumn nameColumn42 = new BoundColumn();
                      nameColumn42.HeaderText = "Retainer TD Amt";
                      nameColumn42.DataField = "RetTDAmt";

					    name1 = name1 + "," +  "Retainer TD Amt";
						 name2 = name2 + "," +  "RetTDAmt";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn42);
                  }
                  if (chkrettdper == "1")
                  {

                      BoundColumn nameColumn43 = new BoundColumn();
                      nameColumn43.HeaderText = "Retainer TD(%)";
                      nameColumn43.DataField = "RetTD(%)";

					     name1 = name1 + "," + "Retainer TD(%)";
						 name2 = name2 + "," + "RetTD(%)";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn43);
                  }

                 
                  if (chkbillamt == "1")
                  {
                      BoundColumn nameColumn46 = new BoundColumn();
                      nameColumn46.HeaderText = "Bill Amt";
                      nameColumn46.DataField = "Billamt";

					     name1 = name1 + "," + "Bill Amt";
						 name2 = name2 + "," +  "Billamt";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn46);
                  }

                  if (chkretcomamt == "1")
                  {
                      BoundColumn nameColumn47 = new BoundColumn();
                      nameColumn47.HeaderText = "Ret. Comm. Amt";
                      nameColumn47.DataField = "RetCommAmt";

					    name1 = name1 + "," +  "Ret. Comm. Amt";
						 name2 = name2 + "," +  "RetCommAmt";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn47);
                  }
                  if (chkretcomper == "1")
                  {

                      BoundColumn nameColumn50 = new BoundColumn();
                      nameColumn50.HeaderText = "Ret. Comm.(%)";
                      nameColumn50.DataField = "RetComm(%)";

					     name1 = name1 + "," +   "Ret. Comm.(%)";
						 name2 = name2 + "," + "RetComm(%)";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn50);
                  }
                  if (chkcashdisc == "1")
                  {
                      if (adchk == "1" || adchk == "3")
                      {
                          BoundColumn nameColumn511 = new BoundColumn();
                          nameColumn511.HeaderText = "Cash Disc";
                          nameColumn511.DataField = "Cash_Disc";


                          name1 = name1 + "," + "Cash Disc";
                          name2 = name2 + "," + "Cash_Disc";
                          name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumn511);
                      }
                  }

                  if (chkstatus == "1")
                  {
                      if (adchk == "3")
                      {
                          BoundColumn nameColumn5111 = new BoundColumn();
                          nameColumn5111.HeaderText = "Status";
                          nameColumn5111.DataField = "Status";


                          name1 = name1 + "," + "Status";
                          name2 = name2 + "," + "Status";
                          name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumn5111);
                      }
                  }

                  if (chkboxcycle == "1")
                  {
                      
                      if (adchk == "1" || adchk == "3")
                      {
                          BoundColumn nameColumn51112 = new BoundColumn();
                          nameColumn51112.HeaderText = "Box Code";
                          nameColumn51112.DataField = "BoxCode";


                          name1 = name1 + "," + "Box Code";
                          name2 = name2 + "," + "BoxCode";
                          name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumn51112);
                      }
                  }
                  if (chkactbusiness == "1")
                  {
                      BoundColumn nameColumn51 = new BoundColumn();
                      nameColumn51.HeaderText = "Actual Business";
                      nameColumn51.DataField = "ActualBusiness";

					  
					     name1 = name1 + "," +  "Actual Business";
						 name2 = name2 + "," +  "ActualBusiness";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn51);
                  }
                  if (chkrevcenter == "1")
                  {
                      BoundColumn nameColumn52 = new BoundColumn();
                      nameColumn52.HeaderText = "Revenue Center";
                      nameColumn52.DataField = "Revcenter";

					     name1 = name1 + "," +  "Revenue Center";
						 name2 = name2 + "," +  "Revcenter";
						name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn52);
                  }


                  if (chkuserid == "1")
                  {

                      if (adchk == "1" || adchk == "3")
                      {
                          BoundColumn nameColumn511120 = new BoundColumn();
                          nameColumn511120.HeaderText = "User Id";
                          nameColumn511120.DataField = "USERID";


                          name1 = name1 + "," + "User Id";
                          name2 = name2 + "," + "USERID";
                          name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumn511120);
                      }
                  }

                  if (chkuserid == "1")
                  {

                      if (adchk == "1" || adchk == "3")
                      {
                          BoundColumn nameColumn511102 = new BoundColumn();
                          nameColumn511102.HeaderText = "User Name";
                          nameColumn511102.DataField = "USERNAME";


                          name1 = name1 + "," + "User Name";
                          name2 = name2 + "," + "USERNAME";
                          name3 = name3 + "," + "G";
                          DataGrid1.Columns.Add(nameColumn511102);
                      }
                  }


                  if (chkbillremark == "1")
                  {

                      BoundColumn nameColumn = new BoundColumn();
                      nameColumn.HeaderText = "Bill Remark";
                      nameColumn.DataField = "BillRemark";

					             name1 = name1 + "," + "Bill Remark";
                                 name2 = name2 + "," + "BillRemark";
						        name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn);
                  }
                  if ( chkproduct == "1")
                  {

                      BoundColumn nameColumn = new BoundColumn();
                      nameColumn.HeaderText = "Product";
                      nameColumn.DataField = "PRODUCT";

                      name1 = name1 + "," + "Product";
                      name2 = name2 + "," + "Product";
                      name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn);
                     
                  }
                  if (chkbrand == "1")
                  {

                      BoundColumn nameColumn = new BoundColumn();
                      nameColumn.HeaderText = "Brand";
                      nameColumn.DataField = "BRAND";

                      name1 = name1 + "," + "Brand";
                      name2 = name2 + "," + "Brand";
                      name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn);

                  }
                  if (chkVarient == "1")
                  {

                      BoundColumn nameColumn = new BoundColumn();
                      nameColumn.HeaderText = "Varient";
                      nameColumn.DataField = "VARIENT";

                      name1 = name1 + "," + "Varient";
                      name2 = name2 + "," + "Varient";
                      name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn);

                  }
                  if (chkCaption == "1")
                  {

                      BoundColumn nameColumn = new BoundColumn();
                      nameColumn.HeaderText = "Caption";
                      nameColumn.DataField = "CAPTION";

                      name1 = name1 + "," + "Caption";
                      name2 = name2 + "," + "Caption";
                      name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn);

                  }

                  if (chkfmgreason == "1")
                  {

                      BoundColumn nameColumn = new BoundColumn();
                      nameColumn.HeaderText = "FMG Reason";
                      nameColumn.DataField = "FMG_REASON";

                      name1 = name1 + "," + "FMG_REASON";
                      name2 = name2 + "," + "FMG_REASON";
                      name3 = name3 + "," + "G";
                      DataGrid1.Columns.Add(nameColumn);


                  }

            

                  if (chk_excel == "1")
                  {
                      DataGrid1.DataSource = ds;
                      System.IO.StringWriter sw = new System.IO.StringWriter();
                      HtmlTextWriter hw = new HtmlTextWriter(sw);
                      DataGrid1.ShowHeader = true;
                      DataGrid1.ShowFooter = true;
                      DataGrid1.DataBind();

                      hw.Write("<p <table border=\"1\"><tr><td colspan=\"6\"align=\"center\"><b>" + ds.Tables[1].Rows[0]["companyname"].ToString() + "</b></td></tr>");

                      hw.Write("<p <tr><td colspan=\"6\"align=\"center\"><b>" + "Complete Report" + "</b></td></tr>");
                      hw.Write("<p <tr><td colspan=\"2\"align=\"left\"><b>" + "From Date:" + txtfromdate.Text + "</b></td><td colspan=\"2\"align=\"center\"><b>" + "To Date:" + txttodate.Text + "</b></td><td colspan=\"2\"align=\"right\"><b>" + "Run Date:" + ds.Tables[1].Rows[0]["Rundate"].ToString() + "</b></td></tr>");
                
                      //hw.Write("<p align=\"left\"><b>" + ds.Tables[1].Rows[0]["companyname"].ToString() + "</b>");
                      //hw.Write("<p align=\"left\"><b>From Date:</b>" + txtfromdate.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>To Date:</b>" + txttodate.Text);
                      //hw.Write("<p align=\"left\"><b>Run Date:</b>" + ds.Tables[1].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>Complete Report<b>");
                      hw.WriteBreak();
                      DataGrid1.RenderControl(hw);
                      if (hdnamtflag.Value=="")
                          Response.Write(sw.ToString().Replace("</table>", "<tr><td colspan='2' style='font-weight:bold'>Total Area:</td><td>" + area.ToString() + "</td></tr><tr><td colspan='2' style='font-weight:bold'>Total Lines:</td><td>" + totrol.ToString() + "</td><tr><td colspan='2' style='font-weight:bold'>Total Words:</td><td>" + totcc.ToString() + "</td><tr><td colspan='2' style='font-weight:bold'>Total Chars:</td><td>" + totcd.ToString() + "</td></tr></table>"));
                      if (hdnamtflag.Value == "true")
                      {
                          string str = "<tr>";

                          if (chkcardamt == "1")
                              str = str + "<td colspan='1' style='font-weight:bold'>Card Total:</td><td colspan='1'>" + totalcardamt.ToString() + "</td>";
                          //if(chkdevamt == "1")
                          //    str=str+"<td colspan='1' style='font-weight:bold'>Deviation Amt. Total:</td><td colspan='1'>" + totaldeviationdamt.ToString() + "</td>";
                          //if(chkagamt == "1")
                          //    str=str+"<td colspan='1' style='font-weight:bold'>Agg Amt Total:</td><td colspan='1'>" + totalaggamt.ToString() + "</td>";
                          if(chkdiscamt == "1")
                              str=str+"<td colspan='1' style='font-weight:bold'>Disc Amt Total:</td><td colspan='1'>" + totaldiscamt.ToString() + "</td>";                          
                          if(chkspdiscamt == "1")
                              str=str+"<td colspan='1' style='font-weight:bold'>Sp. Disc Amt Total:</td><td colspan='1'>" + totalspdiscamt.ToString() + "</td>";
                          if(chkspacediscamt == "1")
                              str=str+"<td colspan='1' style='font-weight:bold'>Space Disc Amt Total:</td><td colspan='1'>" + totalspacediscamt.ToString() + "</td>";
                          if (chkspcharge == "1")
                              str = str + "<td colspan='1' style='font-weight:bold'>Special Charges Total:</td><td colspan='1'>" + totalspecialcharges.ToString() + "</td>";
                          if(chkagadtdamt == "1")
                              str=str+"<td colspan='1' style='font-weight:bold'>Ag Addl TD Amt Total:</td><td colspan='1'>" + totalagaddltdamt.ToString() + "</td>";
                          if (chkgrossamt == "1")
                              str = str + "<td colspan='1' style='font-weight:bold'>Gross Amt Total:</td><td colspan='1'>" + totalgrossamt.ToString() + "</td>";
                          if (chkrettdamt == "1")
                              str = str + "<td colspan='1' style='font-weight:bold'>Retainer Td Amt Total:</td><td colspan='1'>" + totalretainertdamt.ToString() + "</td>";
                          if (chkagtdamt == "1")
                              str = str + "<td colspan='1' style='font-weight:bold'>Ag TD Amt Total:</td><td colspan='1'>" + totalagtdamt.ToString() + "</td>";
                          if (chkbillamt == "1")
                              str = str + "<td colspan='1' style='font-weight:bold'>Billing Amt Total:</td><td colspan='1'>" + totalbillingamt.ToString() + "</td>";
                          if (chkretcomamt == "1")
                              str = str + "<td colspan='1' style='font-weight:bold'>Ret Comm Amt Total:</td><td colspan='1'>" + totalretcommamt.ToString() + "</td>";
                          if (chkactbusiness == "1")
                              str = str + "<td colspan='1' style='font-weight:bold'>Actual Business Total:</td><td colspan='1'>" + totalactbusiness.ToString() + "</td>";

                          str = str + "<tr><td colspan='2' style='font-weight:bold'>Total Area:</td><td>" + area.ToString() + "</td></tr><tr><td colspan='2' style='font-weight:bold'>Total Lines:</td><td>" + totrol.ToString() + "</td><tr><td colspan='2' style='font-weight:bold'>Total Words:</td><td>" + totcc.ToString() + "</td><tr><td colspan='2' style='font-weight:bold'>Total Chars:</td><td>" + totcd.ToString() + "</td></tr></table>";
                          Response.Write(sw.ToString().Replace("</table>",str));
                      }
                  }
                  else
                  {

                      DataGrid1.DataSource = ds;

                      if (name2.Length <= 0)
                      {
                          Response.Write("<script>alert('This Field is not valid to display data');return false;</script>");
                          return;

                      }
                      else
                      {
                          string[] names = name2.Substring(1, name2.Length - 1).Split(',');
                          string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
                          string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
                          string[][] colProperties ={ names, captions, formats };

                          QueryToCSV(ds, colProperties);

                      }
                  }

             
           }



                          Response.Flush();
                          Response.End();


                          hdnamtflag.Value = "";
        }
    }
    private void QueryToCSV(DataSet dr, string[][] colProperties)
    {
        if (colProperties.Length > 0)
        {
            int counter;
            Response.Write("\"" + String.Join("\",\"", colProperties[1]) + "\"\n");
            for (int i = 0; i < dr.Tables[0].Rows.Count; i++)
            {
                counter = 0;
                Response.Write("\"");
                foreach (String column in colProperties[0])
                {
                    //dr.Tables[0].Rows[i].
                    Response.Write(String.Format("{0:" + colProperties[2][counter] + "}", dr.Tables[0].Rows[i].ItemArray[getcolindex(dr, column)]));
                    if (counter < colProperties[0].Length - 1)
                    {
                        Response.Write("\",\"");
                    }
                    counter += 1;
                }
                Response.Write("\"\n");
            }
            //dr.Close();
            //tw.Close();
        }
    }
    private int getcolindex(DataSet ds, string col)
    {
        int i;
        for (i = 0; i < ds.Tables[0].Columns.Count - 1; i++)
        {
            if (ds.Tables[0].Columns[i].ColumnName.ToLower().Trim() == col.ToLower().Trim())
            {
                goto td5;

            }
        }
    td5:
        return i;

    }

    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        string sno1 = e.Item.Cells[0].Text;
        if (e.Item.Cells.Count > 1)
        {
            string cioidchk = e.Item.Cells[1].Text;

            if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
            {
                e.Item.Cells[0].Text = Convert.ToString(sno++);
            }
        }
        
    }




    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton1.Checked = false;
        RadioButton2.Checked = true;


        Listavilfield.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/billbook.xml"));


        int i;

        for (i = 1; i < ds.Tables[5].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            i = i + 1;
            li.Text = ds.Tables[5].Rows[0].ItemArray[i].ToString();
            Listavilfield.Items.Add(li);

        }


    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {

        RadioButton1.Checked = true;
        RadioButton2.Checked = false;

        Listavilfield.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/billbook.xml"));


        int i;

        for (i = 1; i < ds.Tables[3].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            i = i + 1;
            li.Text = ds.Tables[3].Rows[0].ItemArray[i].ToString();
            Listavilfield.Items.Add(li);

        }


    }


    public void bind_fmgregion()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 objprod = new NewAdbooking.Report.classesoracle.Class1();
            ds = objprod.bind_fmgregion(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objprod = new NewAdbooking.Report.Classes.Class1();
            ds = objprod.bind_fmgregion(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            string procedureName = "ad_fmg_reason_bind";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();


        li1.Text = "Select Fmg Region";
        li1.Value = "0";
        drpfmgregion.Items.Add(li1);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpfmgregion.Items.Add(li);
        }

    }


    public void bind_bookingtype()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 objprod = new NewAdbooking.Report.classesoracle.Class1();
            ds = objprod.bind_bookingtype(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
             NewAdbooking.Report.Classes.Class1 objprod = new NewAdbooking.Report.Classes.Class1();
             ds = objprod.bind_bookingtype(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            string procedureName = "ad_bktype_bind";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();


        li1.Text = "Select Booking Type";
        li1.Value = "0";
        dpbooktype.Items.Add(li1);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpbooktype.Items.Add(li);
        }

    }
}
