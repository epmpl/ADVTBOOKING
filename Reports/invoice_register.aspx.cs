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

public partial class invoice_register : System.Web.UI.Page
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
            hiddenuserid.Value = Session["userid"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(invoice_register));
        DataSet ds = new DataSet();

        ds.ReadXml(Server.MapPath("XML/invoice_register.xml"));
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbpublication.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbbranch.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbedition.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbcatgory.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbagtype.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbagcat.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbexe.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lblage.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lblclient.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lbadcat.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lbldistrict.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lblinsertstatus.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lbbreak.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        lblrptdestination.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
        lbadsubcat.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
        lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();

        Session["dateto"] = txttodate1.Text;
        Session["fromdate"] = txtfrmdate.Text;
        if (!IsPostBack)
        {
            hdnagncode.Value = "";
            btnsubmit.Attributes.Add("onclick", "javascript:return forreport();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");

            dpcategory.Attributes.Add("onchange", "javascript:return bindadcat();");
            dpadcat.Attributes.Add("onchange", "javascript:return bindsubcat();");
            dpadsubcat.Attributes.Add("onchange", "javascript:return bindsubcat345(this.id);");


            dpagcat.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpagtype.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpcategory.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpedition.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            //txt_executive.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dppub1.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpregion.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dppub1.Attributes.Add("onchange", "javascript:return bind_edition13();");

            //txt_executive.Attributes.Add("onkeydown", "javascript:return F2fillexecutivecr_bill(event);");
            //txt_executive.Attributes.Add("onkeypress", "javascript:return F2fillexecutivecr_bill(event);");

            //lstexecutive.Attributes.Add("onclick", "javascript:return Clickexecutive_bill(event);");
            //lstexecutive.Attributes.Add("onkeydown", "javascript:return Clickexecutive_bill(event);");
            dpteam.Attributes.Add("onchange", "javascript:return bind_exe_represen();");
            txtclient.Attributes.Add("onkeydown", "javascript:return F2fillclientcr(event);");
            txtclient.Attributes.Add("onkeypress", "javascript:return F2fillclientcr(event);");

            lstclintf2.Attributes.Add("onclick", "javascript:return Clickclient(event);");
            lstclintf2.Attributes.Add("onkeydown", "javascript:return Clickclient(event);");

            txtage.Attributes.Add("onkeydown", "javascript:return F2fillagencycr(event);");
            txtage.Attributes.Add("onkeypress", "javascript:return F2fillagencycr(event);");

            lstagencyf2.Attributes.Add("onclick", "javascript:return ClickAgaency(event);");
            lstagencyf2.Attributes.Add("onkeydown", "javascript:return ClickAgaency(event);");

            publicationbind();
            bindpublication();
            bindregion();
            bindedition();
            bindadtype();
            bindagencytype();
            bindagencycat();
            bindBreakDown();
            bindbranch();
            binddistrict();
            bindinsertstatus();
            bindproductnamne();
            txtfrmdate.Focus();
            bindteam();
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
        //dppubcent.SelectedValue = Session["center"].ToString();

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
        return ds;
    }

    public void bindteam()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.team(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SummaryReport advpub = new NewAdbooking.Report.classesoracle.SummaryReport();
            ds = advpub.team(Session["compcode"].ToString());
        }
        else
        {
        }

        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[30].ToString();

        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpteam.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpteam.Items.Add(li);


        }
    }


    [Ajax.AjaxMethod]
    public DataSet exe_bind(string comp_code, string userid, string team)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister exec = new NewAdbooking.Report.classesoracle.billregister();
            ds = exec.adexec(comp_code, userid, team);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 exec = new NewAdbooking.Report.Classes.Class1();
            ds = exec.adexec(comp_code, userid, team);

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
        return ds;
    }


    public void bindpublication()
    {

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
    [Ajax.AjaxMethod]
    public DataSet subcat345(string cat, string compcode, string cat4, string cat5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
            ds = adcat.cat345(cat, compcode, cat4, cat5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.cat345(cat, compcode, cat4, cat5);
        }
        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet subcatbind(string compcode, string cat)
    {
        DataSet ds = new DataSet();
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
        return ds;

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
            li2.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li2.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpagcat.Items.Add(li2);


        }
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


        ListItem li1;
        li1 = new ListItem();



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


    public void bindproductnamne()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister objprod = new NewAdbooking.Report.classesoracle.billregister();
            ds = objprod.bindProductcategory(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objprod = new NewAdbooking.Report.Classes.Class1();
            ds = objprod.bindProductcategory(Session["compcode"].ToString());
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









    public void bindBreakDown()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/invoice_register.xml"));

        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Date Wise";
        li1.Value = "D";
        li1.Selected = true;
        drpbreak.Items.Add(li1);

        for (i = 0; i < ds.Tables[1].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            drpbreak.Items.Add(li);

        }


    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionmis_run(string fromdate, string todate, string branch, string pub, string edtn, string region, string dist, string dest, string adtype, string adcat, string adsubcat, string agtype, string agcat, string product, string executiveCd, string exename, string agcd, string agname, string clientcd, string clientnm, string brkon, string billtype, string req_parent_child, string paymode, string extra4, string extra5, string extra12, string extra14, string extra15, string adcatNM, string pcent)
    {


        Session["fromdate"] = fromdate;
        Session["todate"] = todate;
        Session["pub"] = pub;
        Session["edtn"] = edtn;
        Session["branch"] = branch;
        Session["region"] = region;
        Session["dest"] = dest;
        Session["dist"] = dist;
        Session["adcat"] = adcat;
        Session["adtype"] = adtype;
        Session["adsubcat"] = adsubcat;
        Session["agtype"] = agtype;
        Session["agcat"] = agcat;
        Session["product"] = product;
        Session["executiveCd"] = executiveCd;
        Session["exename"] = exename;
        Session["agcd"] = agcd;
        Session["agname"] = agname;
        Session["clientcd"] = clientcd;
        Session["clientnm"] = clientnm;
        Session["brkon"] = brkon;
        Session["billtype"] = billtype;
        Session["req_parent_child"] = req_parent_child;
        Session["paymode"] = paymode;
        Session["extra4"] = extra4;
        Session["extra5"] = extra5;
        Session["extra12"] = extra12;
        Session["extra14"] = extra14;
        Session["extra15"] = extra15;
        Session["adcatNM"] = adcatNM;
        Session["pcent"] = pcent;

    }




}
