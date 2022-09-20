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
public partial class BillRegister : System.Web.UI.Page
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

        Session["access"] = "0";
        if (Session["dateformat"] != null)
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(BillRegister));
      
      
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[68].ToString();
       

        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lbcatgory.Text = ds.Tables[0].Rows[0].ItemArray[61].ToString();
        
        lbedition.Text = ds.Tables[0].Rows[0].ItemArray[45].ToString();
        lbagtype.Text = ds.Tables[0].Rows[0].ItemArray[59].ToString();
        lbagcat.Text = ds.Tables[0].Rows[0].ItemArray[60].ToString();
        lbpublication.Text = ds.Tables[0].Rows[0].ItemArray[62].ToString();
        ad.Text = ds.Tables[0].Rows[0].ItemArray[65].ToString();
        bill.Text = ds.Tables[0].Rows[0].ItemArray[67].ToString();
        schedule.Text = ds.Tables[0].Rows[0].ItemArray[66].ToString();
        lbexe.Text = ds.Tables[0].Rows[0].ItemArray[72].ToString();
        lbbreak.Text = ds.Tables[0].Rows[0].ItemArray[95].ToString();
        lblage.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblclient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();

        lbldistrict.Text = ds.Tables[0].Rows[0].ItemArray[96].ToString();
        lblinsertstatus.Text = ds.Tables[0].Rows[0].ItemArray[98].ToString();
        DataSet d2s = new DataSet();
        d2s.ReadXml(Server.MapPath("XML/REPORT.xml"));
        lbPublicationCenter.Text = d2s.Tables[0].Rows[0].ItemArray[5].ToString();
        


        Session["dateto"] = txttodate1.Text;
        Session["fromdate"] = txtfrmdate.Text;
        if (!IsPostBack)
        {
            hdnagncode.Value = "";
            BtnRun.Attributes.Add("onclick", "javascript:return daily_summarized_bill();");
           // BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            //dpregion.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            //txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            //txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");

            bill.Attributes.Add("OnClick", "javascript:return billclick1();");
            schedule.Attributes.Add("OnClick", "javascript:return scheduleclick1();");


            dpagcat.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpagtype.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpcategory.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpedition.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            txt_executive.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dppub1.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpregion.Attributes.Add("onkeypress", "javascript:return keySort(this);");

            dppubcent.Attributes.Add("onchange", "javascript:return bind_edition13();");
            dppub1.Attributes.Add("onchange", "javascript:return bind_edition13();");
            exe.Attributes.Add("onclick", "javascript:return enable_exe();");
            csv.Attributes.Add("onclick", "javascript:return enable_csv();");
            Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");

            txt_executive.Attributes.Add("onkeydown", "javascript:return F2fillexecutivecr_bill(event);");
            txt_executive.Attributes.Add("onkeypress", "javascript:return F2fillexecutivecr_bill(event);");

            lstexecutive.Attributes.Add("onclick", "javascript:return Clickexecutive_bill(event);");
            lstexecutive.Attributes.Add("onkeydown", "javascript:return Clickexecutive_bill(event);");

            txtclient.Attributes.Add("onkeydown", "javascript:return F2fillclientcr();");
            txtclient.Attributes.Add("onkeypress", "javascript:return F2fillclientcr();");

            lstclintf2.Attributes.Add("onclick", "javascript:return Clickclient();");
            lstclintf2.Attributes.Add("onkeydown", "javascript:return Clickclient();");

            txtage.Attributes.Add("onkeydown", "javascript:return F2fillagencycr(event);");
            txtage.Attributes.Add("onkeypress", "javascript:return F2fillagencycr(event);");

            lstagencyf2.Attributes.Add("onclick", "javascript:return ClickAgaency(event);");
            lstagencyf2.Attributes.Add("onkeydown", "javascript:return ClickAgaency(event);");

            
            bindpublication();
            binddest();
            bindregion();
            bindedition();
            bindadtype();
            bindagencytype();
            bindagencycat();
          //  bindexecutive();
            publicationbind();
            txtfrmdate.Focus();
            bindBreakDown();
            binddistrict();
            bindinsertstatus();
            bindbranch();
          
        }
    }
    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditexecutive(string compcol, string exectv)
    {
        string tname = "", userid = "";

        DataSet ds = new DataSet();

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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string[] parameterValueArray = new string[] { compcol, userid, tname, exectv };
            string procedureName = "xlsBindexecnew_xlsBindexecnew_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        return ds;
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
            ds = pub.adbranch_perm(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            string procedureName = "branchbind_adv_branchbind_adv_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select Branch";
        li.Selected = true;
        dpd_branch.Items.Add(li);



        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpd_branch.Items.Add(li1);
        }
        dpd_branch.SelectedValue = Session["revenue"].ToString();
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
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
            string procedureName = "pubcent_proc_pubcent_proc_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

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
            string[] parameterValueArray = new string[] { pub, pub_cent, compcode };
            string procedureName = "edition_proc_edition_proc_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        return ds;
    }
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        Txtdest.Items.Clear();
        int i;

       
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
            
            ListItem li1;
            li1 = new ListItem();
            li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            li1.Value = "0";
            li1.Selected = true;
            Txtdest.Items.Add(li1);

            for (i = 0; i < destination.Tables[0].Columns.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
                i = i + 1;
                li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
                Txtdest.Items.Add(li);
                if (i == destination.Tables[0].Columns.Count - 1)
                {
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        ListItem lit;
                        lit = new ListItem();
                        lit.Text = "On Screen with Amt";
                        lit.Value = "5";
                        Txtdest.Items.Add(lit);
                    }
                }


            }
        //}
        //else
        //{
        //    ListItem li1;
        //    li1 = new ListItem();
        //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        //    li1.Value = "5";
        //    li1.Selected = true;
        //    Txtdest.Items.Add(li1);
        //    for (i = 2; i < destination.Tables[0].Columns.Count; i++)
        //    {
        //        if (i == 2)
        //        {

        //            ListItem lit;
        //            lit = new ListItem();
        //            lit.Text = "On Screen with Amt";
        //            lit.Value = "5";
        //            Txtdest.Items.Add(lit);

        //        }
        //        ListItem li;
        //        li = new ListItem();
        //        li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
        //        i = i + 1;
        //        li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
        //        Txtdest.Items.Add(li);
                


        //    }
 
        //}


    }
    //public void bindexecutive()
    //{
    //    string tname = "";

    //    DataSet ds = new DataSet();
       
    //     if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.Report.classesoracle.billregister exec = new NewAdbooking.Report.classesoracle.billregister();
    //        ds = exec.adexec(Session["compcode"].ToString(), Session["userid"].ToString(), tname);
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 exec = new NewAdbooking.Report.Classes.Class1();
    //        ds = exec.adexec(Session["compcode"].ToString(), Session["userid"].ToString(), tname);
    //    }
    //    ListItem li1;
    //    li1 = new ListItem();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[29].ToString();
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    txt_executive.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        txt_executive.Items.Add(li);


    //    }
    //}
    public void bindpublication()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            string procedureName = "Bind_PubName_Bind_PubName_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

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


    public void bindinsertstatus()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        drpstatus.Items.Clear();
        int i;

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Insert Status--";
        li1.Value = "";
        li1.Selected = true;
        drpstatus.Items.Add(li1);


        for (i = 0; i < ds.Tables[1].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
             i = i + 1;
            li.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            drpstatus.Items.Add(li);

        }


    }

    public void bindcategory()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        dpcategory.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[17].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        dpcategory.Items.Add(li1);

        for (i = 0; i < ds.Tables[3].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[3].Rows[0].ItemArray[i].ToString();
            // i = i + 1;
            li.Value = ds.Tables[3].Rows[0].ItemArray[i].ToString();
            dpcategory.Items.Add(li);

        }


    }
    public void bindregion()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.bindregion(Session["compcode"].ToString());

        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister objregion = new NewAdbooking.Report.classesoracle.billregister();
            ds = objregion.bindregionname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            string procedureName = "sp_region_sp_region_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[16].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
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

    public void bindagencycat()
    {
       
        DataSet ds = new DataSet();
       
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
            ds = obj.bindagcat(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 obj = new NewAdbooking.Report.Classes.Class1();
            ds = obj.bindagcat(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string[] parameterValueArray = new string[] { Session["userid"].ToString(), Session["compcode"].ToString() };
            string procedureName = "agencycategory_agencycategory_P";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        ListItem li;
        li = new ListItem();
        dpagcat.Items.Clear();
        
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[26].ToString();
        //li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpagcat.Items.Add(li);
        


        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li2;
            li2 = new ListItem();
            li2.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li2.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpagcat.Items.Add(li2);


        }
    }
    public void bindagencytype()
    {
       
        DataSet ds = new DataSet();
       
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
            ds = obj.bindagtype(Session["userid"].ToString(),Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.billregister obj = new NewAdbooking.Report.Classes.billregister();
            ds = obj.bindagtype(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string[] parameterValueArray = new string[] { Session["userid"].ToString(), Session["compcode"].ToString() };
            string procedureName = "Websp_agent_Websp_agent_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

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
    public void bindedition()
    {

        DataSet ds = new DataSet();
       
        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);

    }

    [Ajax.AjaxMethod]
    public DataSet fillF2_client(string compcol, string cli)
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
            string[] parameterValueArray = new string[] { compcol, cli };
            string procedureName = "bindclientforxls_bindclientforxls_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet fillF2_Agency(string compcol, string agen)
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
            string[] parameterValueArray = new string[] { compcol, agen };
            string procedureName = "bindclientforxls_bindclientforxls_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }

        return ds;
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
             string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
             string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
             NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
             ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

         }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpcategory.Items.Add(li1);
        

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpcategory.Items.Add(li);


        }
    }


    public void binddistrict()
    {
        //regionhidden=hiddenregion.Value;
       
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub.district(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.district(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString() };
            string procedureName = "CityMst_District_CityMst_District_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }

        ListItem li1;
        li1 = new ListItem();

    //    DataSet ds1 = new DataSet();
     //   ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = "Select District";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        ddldistrict.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            ddldistrict.Items.Add(li);


        }
    }


 
   
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string from_date = "";
        string to_date = "";
        
        string temp_agname = hdnagncode.Value, temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "",temp_product="";
        string adchk="",statecod="";
       // Request.Form["bill"]
        if (bill.Checked == true)
            adchk = "1";
        else
            adchk = "2";

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
        string reportbased = drbrebas.SelectedValue.ToString();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (drpbreak.SelectedValue != "")
        {
            if (drpbreak.SelectedItem.Text == "Agency")
                hiddencioid.Value = drpbreak.SelectedItem.Text;
           
                else if (drpbreak.SelectedItem.Text == "Client")
                    hiddencioid.Value = drpbreak.SelectedItem.Text;
            else if (drpbreak.SelectedItem.Text == "Publication")
                hiddencioid.Value = drpbreak.SelectedItem.Text;
                          
        }
        //else
        //    hiddencioid.Value = "Publication";
      
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
           
            if (adchk == "1")
            {
                
                    ds = obj.billreg(from_date, to_date, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, dpcategory.SelectedValue, dppubcent.SelectedValue, dpagtype.SelectedItem.Text, hiddenedition.Value, temp_agency, dpregion.SelectedValue, dpagcat.SelectedValue, adchk, hdnexecode.Value, Session["userid"].ToString(), Session["access"].ToString(), statecod, ddldistrict.SelectedValue, drpstatus.SelectedValue);
                
                
            }
            else
            {
                if (reportbased != "M")
                {
                    ds = obj.billreg(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, dpcategory.SelectedValue, dppubcent.SelectedValue, dpagtype.SelectedItem.Text, hiddenedition.Value, temp_agency, dpregion.SelectedValue, dpagcat.SelectedValue, adchk, hdnexecode.Value, Session["userid"].ToString(), Session["access"].ToString(), statecod, ddldistrict.SelectedValue, drpstatus.SelectedValue);
                }
                else
                {
                    ds = obj.billreg_standardmulti(from_date, to_date, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, dpcategory.SelectedValue, dppubcent.SelectedValue, dpagtype.SelectedItem.Text, hiddenedition.Value, temp_agency, dpregion.SelectedValue, dpagcat.SelectedValue, adchk, hdnexecode.Value, Session["userid"].ToString(), Session["access"].ToString(), statecod, ddldistrict.SelectedValue, drpstatus.SelectedValue);
                    //ds = obj.billreg_standardmulti(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, dpcategory.SelectedValue, dppubcent.SelectedValue, dpagtype.SelectedItem.Text, hiddenedition.Value, temp_agency, dpregion.SelectedValue, dpagcat.SelectedValue, adchk, hdnexecode.Value, Session["userid"].ToString(), Session["access"].ToString(), statecod, ddldistrict.SelectedValue, drpstatus.SelectedValue);
                }
                
            }

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

            if (adchk == "1")
            {
                if (Session["compcode"].ToString() != "SU001")
                {
                    ds = obj.billreg(from_date, to_date, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), dpcategory.SelectedValue, dppubcent.SelectedValue, dpagtype.SelectedItem.Text, hiddenedition.Value, temp_agency, dpregion.SelectedValue, dpagcat.SelectedValue, adchk, hdnexecode.Value, Session["userid"].ToString(), Session["access"].ToString(), statecod, ddldistrict.SelectedValue, drpstatus.SelectedValue, "", "");
                }
                else
                {
                    ds = obj.billreg1_news7(from_date, to_date, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, dpcategory.SelectedValue, dppubcent.SelectedValue, dpagtype.SelectedValue, hiddeneditionname.Value, temp_agency, dpregion.SelectedValue, dpagcat.SelectedValue, adchk, hdnexecode.Value, Session["userid"].ToString(), Session["access"].ToString(), statecod, ddldistrict.SelectedValue, drpstatus.SelectedValue, "", dpd_branch.SelectedValue);
                }
                       
            }
            else
            {
                if (Session["compcode"].ToString() != "SU001")
                {
                    ds = obj.billreg1(from_date, to_date, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, dpcategory.SelectedValue, dppubcent.SelectedValue, dpagtype.SelectedValue, hiddeneditionname.Value, temp_agency, dpregion.SelectedValue, dpagcat.SelectedValue, adchk, hdnexecode.Value, Session["userid"].ToString(), Session["access"].ToString(), statecod, ddldistrict.SelectedValue, drpstatus.SelectedValue, "");
                }
                else
                {
                    ds = obj.billreg1_news7(from_date, to_date, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, dpcategory.SelectedValue, dppubcent.SelectedValue, dpagtype.SelectedValue, hiddeneditionname.Value, temp_agency, dpregion.SelectedValue, dpagcat.SelectedValue, adchk, hdnexecode.Value, Session["userid"].ToString(), Session["access"].ToString(), statecod, ddldistrict.SelectedValue, drpstatus.SelectedValue, "", dpd_branch.SelectedValue);
                }
                
           
            }

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {

            string procedureName = "";
            string[] parameterValueArray = new string[] { temp_agname, dpcategory.SelectedValue, from_date, to_date, Session["compcode"].ToString(), dppubcent.SelectedValue, dpagtype.SelectedItem.Text, hiddeneditionname.Value, Session["dateformat"].ToString(), dpregion.SelectedValue, dppub1.SelectedValue, temp_agency, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), dpagcat.SelectedValue, adchk, hdnexecode.Value, Session["userid"].ToString(), Session["access"].ToString(), statecod, ddldistrict.SelectedValue, drpstatus.SelectedValue };
            if (adchk == "1")
            {

                procedureName = "pub_Reportnew";

            }
            else
            {
                if (reportbased != "M")
                {
                    procedureName = "pub_Reportnew";
                }
                else
                {
                    procedureName = "pub_Reportnewmulti";
                }
            }
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(BillRegister), "sa", "alert(\"searching criteria is not valid\");", true);
            return;

        }
        else
        {
            Session["billregister"] = ds;
            Session["prm_billregister"] = "destination~" + Txtdest.SelectedItem.Value + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~edition~" + hiddenedition.Value + "~editionname~" + hiddeneditionname.Value + "~region~" + dpregion.SelectedValue + "~regionname~" + dpregion.SelectedItem.Text + "~adtype~" + dpcategory.SelectedValue + "~agtype~" + dpagtype.SelectedValue + "~agtypetext~" + dpagtype.SelectedItem.Text + "~agcat~" + dpagcat.SelectedValue + "~agcattext~" + dpagcat.SelectedItem.Text + "~publicationcd~" + dppub1.SelectedValue + "~publication1~" + dppub1.SelectedItem.Text + "~adtypetext~" + dpcategory.SelectedItem.Text + "~adchk~" + adchk + "~exename~" + txt_executive.Text + "~execode~" + hdnexecode.Value + "~chk_excel~" + chk_excel + "~BreakDown~" + drpbreak.SelectedValue + "~agnName~" + txtage.Text + "~insertstatus~" + drpstatus.SelectedItem.Text;
           // Response.Redirect("BillRegisterview.aspx");
            Response.Write("<Script>window.open('BillRegisterview.aspx',target='_blank')</Script>");
            //Response.Redirect("BillRegisterview.aspx?&destination=" + Txtdest.SelectedItem.Value + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&edition=" + hiddenedition.Value + "&editionname=" + hiddeneditionname.Value + "&region=" + dpregion.SelectedValue + "&regionname=" + dpregion.SelectedItem.Text + "&adtype=" + dpcategory.SelectedValue + "&agtype=" + dpagtype.SelectedValue + "&agtypetext=" + dpagtype.SelectedItem.Text + "&agcat=" + dpagcat.SelectedValue + "&agcattext=" + dpagcat.SelectedItem.Text + "&publicationcd=" + dppub1.SelectedValue + "&publication1=" + dppub1.SelectedItem.Text + "&adtypetext=" + dpcategory.SelectedItem.Text + "&adchk=" + adchk + "&exename=" + txt_executive.Text + "&execode=" + hdnexecode.Value);
       }
       

       
    }

    public void bindBreakDown()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/BreakOn.xml"));
        
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Break On--";
        li1.Value = "0";
        li1.Selected = true;
        drpbreak.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[0].ItemArray[i].ToString();
           i = i + 1;
            li.Value = ds.Tables[0].Rows[0].ItemArray[i].ToString();
            drpbreak.Items.Add(li);

        }


    }


   
}



