using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Text.RegularExpressions;
public partial class Reports_date_pubediwise_billing_rpt : System.Web.UI.Page
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
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_date_pubediwise_billing_rpt));

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/date_pubediwise_billing_rpt.xml"));
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbadcatgory.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbl_branch.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbl_printcent.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbl_report.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lblpublication2.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        if (!Page.IsPostBack)
        {
            bindreport();
            bindadvtype();
            bindpub();
            bindpub2();
            bindbranch();
            bindprintcent();
            //binddest();
            dpdadtype.Attributes.Add("onchange", "javascript:return adcat_bind();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            BtnRun.Attributes.Add("OnClick", "javascript:return checkrundatenetamt_agency();");
            drppublication2.Attributes.Add("onblur", "javascript:return pub_pubtieupcheck();");
        }
    }


    public void bindadvtype()
    {
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();


        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise advname = new NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.datewise_billwise_publicationwise advname = new NewAdbooking.Report.Classes.datewise_billwise_publicationwise();
            ds = advname.adname(Session["compcode"].ToString());
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
            NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise advpub = new NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.datewise_billwise_publicationwise advpub = new NewAdbooking.Report.Classes.datewise_billwise_publicationwise();
            ds = advpub.advpub(Session["compcode"].ToString());
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


    public void bindpub2()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise advpub = new NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.datewise_billwise_publicationwise advpub = new NewAdbooking.Report.Classes.datewise_billwise_publicationwise();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppublication2.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drppublication2.Items.Add(li);


        }
    }

    public void bindbranch()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise pub = new NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.datewise_billwise_publicationwise pub = new NewAdbooking.Report.Classes.datewise_billwise_publicationwise();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "--Select Branch--";
        li.Selected = true;
        dpd_branch.Items.Add(li);



        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpd_branch.Items.Add(li1);
        }

    }

    public void bindprintcent()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise pub_cent1 = new NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.datewise_billwise_publicationwise pub_cent1 = new NewAdbooking.Report.Classes.datewise_billwise_publicationwise();
            //ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), "0", Session["userid"].ToString());
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "--Select Printing Center--";
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
    public void bindreport()
    {
        dpd_report.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/date_pubediwise_billing_rpt.xml"));
        for (int i = 0; i < ds1.Tables[1].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            dpd_report.Items.Add(li1);
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
    public DataSet bind_adcat(string adtype, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise adcat = new NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise();
            ds = adcat.advtype(adtype, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.datewise_billwise_publicationwise adcat = new NewAdbooking.Report.Classes.datewise_billwise_publicationwise();
            ds = adcat.advtype(adtype, compcode);
        }
        return ds;
    }
}

