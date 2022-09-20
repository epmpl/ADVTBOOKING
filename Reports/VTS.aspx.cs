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
public partial class Reports_VTS : System.Web.UI.Page
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
            hdncompcode.Value = Session["compcode"].ToString();
            hiddenuseid.Value = Session["userid"].ToString();
            Session["access"] = "0";
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_VTS));



        Session["fromdate"] = txtfrmdate.Text;
        Session["todate"] = txttodate1.Text;
        DataSet ds1 = new DataSet();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/VTS_REPORT.xml"));

        lbClient.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbadcatgory.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbAdtype.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbagencyname.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbl_branch.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //lbstatus.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        //lbagtype.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lbbilled.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        Label1.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        LabelClient.Text = ds.Tables[1].Rows[0].ItemArray[0].ToString();

           if (!Page.IsPostBack)

           {


               edition();
               bindadvtype();
               bindpub();
               binddest();
               publicationbind();
               bindbranch();
               bindclienttype();
               bindstate();
           

            BtnRun.Attributes.Add("OnClick", "javascript:return run_report();");

            txtfrmdate.Attributes.Add("onblur", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("onblur", "javascript:return checkdate(this);");

            dpagency.Attributes.Add("onkeypress", "return keySort(this);");
         
            //dpdadtype.Attributes.Add("onchange", "javascript:return adcat_bind_deviation();");
           
            dppubcent.Attributes.Add("onchange", "javascript:return bind_edition5();");
            dppub1.Attributes.Add("onchange", "javascript:return bind_edition5();");
            //dpedition.Attributes.Add("onchange", "javascript:return bind_edition5();");
            Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
            exe.Attributes.Add("onclick", "javascript:return enable_exe();");
            csv.Attributes.Add("onclick", "javascript:return enable_csv();");

            dpagency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr_dev(event);");
            dpagency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr_dev(event);");

            lstagency.Attributes.Add("onclick", "javascript:return ClickAgaencybb(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaencybb(event);");

            dpclient.Attributes.Add("onkeydown", "javascript:return F2fillclientcr_dev(event);");
            dpclient.Attributes.Add("onkeypress", "javascript:return F2fillclientcr_dev(event);");

            lstclient.Attributes.Add("onclick", "javascript:return Clickclientaa(event);");
            lstclient.Attributes.Add("onkeydown", "javascript:return Clickclientaa(event);");
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
        else
        {
            string procedureName = "bindclientforxls.bindclientforxls_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcol, cli };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string chk_excel = "";
        string from_date = "";
        string to_date = "", dateto = "", fromdate = "", pubname = "", compcode="",client_code ="",todate ="",pub_name="",publication_center ="",chk_acc="", pubcent = "",agency_code="", branch_c = "", edition = "", extra1 = "", extra2 = "", clientcode="";
        //Response.Redirect("");
        string page = "";
        string position = "";
        string hold = "";
        string str = "";
        string str1 = "";

        string dateformate = "";
        string state = "";
        for (int x = 0; x < ListBox1.Items.Count; x++)
        {
            if (ListBox1.Items[x].Selected == true)
            {
                if (state == "")
                    state = ListBox1.Items[x].Value;
                else
                    state = state + "," + ListBox1.Items[x].Value;
            }
        }

        str = hiddenadcat.Value;
        str1 = hiddenadcatname.Value;
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
        string agencychk = "", clientchk="";
        string agnecycode = "";
        if (dpagency.Text == "")
        {
            agencychk = "";
            hdnagency1.Value = "";
            hdnagencytxt.Value = "";
        }
        else
            agencychk = hdnagency1.Value;
        if (dpclient.Text == "")
        {
            clientchk = "";
            hdnclienttxt.Value = "";
            hdnclient1.Value = "";
        }
        else
            clientchk = hdnclient1.Value;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                fromdate = DMYToMDY(txtfrmdate.Text);
                dateto = DMYToMDY(txttodate1.Text);
            }


            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                fromdate = YMDToMDY(txtfrmdate.Text);
                dateto = YMDToMDY(txttodate1.Text);
            }
            NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            //ds = obj.vtsreport(agnecycode, clientcode, fromdate, dateto, pubname, pubcent, branch_c, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc, extra1, extra2);
           
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
            // ds = obj.spDeviation(clientchk, agencychk, dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpstatus.SelectedItem.Value, hiddenedition.Value, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), page, position, dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());
        }
        //int cont = ds.Tables[0].Rows.Count;
        else
        {
            //string procedureName = "bindclientforxls.bindclientforxls_p";
            //NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            //string[] parameterValueArray = new string[] { compcol, cli };
            //ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(Reports_VTS), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["VTS"] = ds;
            Session["prm_vts"] = "agencycode~" + agency_code + "~clientcode~" + client_code + "~fromdate~" + from_date + "~dateto~" + todate + "~pubname~" + pub_name + "~pubcenter~" + publication_center + "~edition~" + hiddenedition.Value + "~pubcent~" + dppubcent.SelectedItem.Text + "~branch_c~" + dpd_branch.SelectedItem.Text + "~destination~" + Txtdest.SelectedItem.Value + "~clientname~" + clientchk + "~reporttype~" + drpbilles.SelectedValue + "~state~" + state;
            Response.Redirect("vtsviewpage.aspx");
            

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
        else
        {
            string procedureName = "branchbind_adv_branchbind_adv_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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

    public void bindclienttype()
    {
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/VTS_REPORT.xml"));
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "-Select client type-";
        li.Selected = true;
        DropDownClient.Items.Add(li);
        for (int i = 1; i < ds1.Tables[1].Columns.Count-1; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            li1.Value = ds1.Tables[1].Rows[0].ItemArray[i + 1].ToString();
            DropDownClient.Items.Add(li1);
            i++;

        }
       

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
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
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
        else
        {
            string procedureName = "Bind_PubName_Bind_PubName_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
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


    public void publicationbind()
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

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
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        int i;
        ListItem li;
        li = new ListItem();
        dppubcent.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        // li.Text = "-Select Publication Center-";
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
        else
        {
            string procedureName = "RA_bindadcategory_RA_bindadcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { adtype, compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;

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
        else
        {
            string procedureName = "edition_proc.edition_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { pub, pub_cent, compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }

    protected void RUN_Click(object sender, EventArgs e)
    {

    }
    public void bindstate()
    {

        DataSet ds = new DataSet();
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
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["center"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListBox1.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Value = "0";
        li1.Text = "--Select State--";
        ListBox1.Items.Add(li1);
       
       
       



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            ListBox1.Items.Add(li);
        }

    }

}
    



    

