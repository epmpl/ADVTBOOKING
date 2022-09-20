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

public partial class weekly_monthly_reports : System.Web.UI.Page
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
       

        if (hiddendateformat.Value == "mm/dd/yyyy")
        {
            HDN_server_date.Value = DateTime.Today.Month + "/" + DateTime.Today.Day + "/" + DateTime.Today.Year;

        }
        else if (hiddendateformat.Value == "dd/mm/yyyy")
        {
            HDN_server_date.Value = DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
        }
        else
        {
            HDN_server_date.Value = DateTime.Today.Year + "/" + DateTime.Today.Month + "/" + DateTime.Today.Day;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(weekly_monthly_reports));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/weekly_monthly_reports.xml"));
        lbl_printcent.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbl_branch.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbbasedon.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        if (!Page.IsPostBack)
        {
            bindprintcent();
            bindpub();
            bind_basedon();
            binddest();
            //txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            //txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txtfrmdate.Attributes.Add("onblur", "javascript:return checkdate(this.value,this.id,document.getElementById('hiddendateformat'),document.getElementById('HDN_server_date').value);");
            txttodate1.Attributes.Add("onblur", "javascript:return checkdate(this.value,this.id,document.getElementById('hiddendateformat'),document.getElementById('HDN_server_date').value);");
            
            BtnRun.Attributes.Add("OnClick", "javascript:return checkrundatenetamt_agency();");
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
    protected void dpd_printcent_SelectedIndexChanged(object sender, EventArgs e)
    {
        hiddenprint.Value = dpd_printcent.SelectedValue;
        bindbranch(hiddencompcode.Value, hiddenprint.Value);
    }

    public void bindbranch(string compcode, string printingcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.weekly_monthly_reports recpt = new NewAdbooking.Report.Classes.weekly_monthly_reports();
            ds = recpt.branchbindWithPrintCenter(hiddencompcode.Value, printingcode);
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.weekly_monthly_reports recpt = new NewAdbooking.Report.classesoracle.weekly_monthly_reports();
            ds = recpt.branchbindWithPrintCenter(hiddencompcode.Value, printingcode);
        }
        dpd_branch.Items.Clear();
        ListItem li = new ListItem();
        li.Text = "--Select Branch--";
        li.Value = "";
        dpd_branch.Items.Add(li);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[0].Rows[i]["Branch_Name"].ToString();
            li1.Value = ds.Tables[0].Rows[i]["Branch_Code"].ToString();
            dpd_branch.Items.Add(li1);
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
    public void bind_basedon()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/weekly_monthly_reports.xml"));
        dpdbasedon.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text ="Booking Date";
        li1.Value = "1";
        li1.Selected = true;
        dpdbasedon.Items.Add(li1);

        for (i = 0; i < ds.Tables[1].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            dpdbasedon.Items.Add(li);

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
}
