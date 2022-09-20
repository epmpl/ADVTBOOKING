using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class eyecater_report : System.Web.UI.Page
{
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
            hdnunit.Value = Session["center"].ToString();
            hdnUnitName.Value = Session["centername"].ToString();
            hdncompname.Value = Session["comp_name"].ToString();
            hdnbranchcod.Value = Session["revenue"].ToString();
            hdnuserid.Value = Session["userid"].ToString();
           
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(eyecater_report));
        DataSet ds = new DataSet();

        ds.ReadXml(Server.MapPath("XML/eyecather_report.xml"));
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbuom.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblcenter.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbbranch.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbleyecat.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();      
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        btnclear.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbladtype.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lblcateg.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lblreprtfor.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lblbrcn.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lblRateCode.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        if (!Page.IsPostBack)
        {
            bindadtype();
            bindreporttype();
            desbind();
            bindreportfor();
            bind_uom();
            bindbullet();
            bindpubcent();
            addbranch();
            drpadtype.Attributes.Add("OnChange", "javascript:return filladcat();");
            BtnRun.Attributes.Add("OnClick", "javascript:return runreport();");
            //dpagency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr_allagency(event);");
            //dpagency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr_allagency(event);");
            //lstagency.Attributes.Add("onclick", "javascript:return ClickAgaency1(event);");
            //lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaency1(event);");
            btnclear.Attributes.Add("onclick", "javascript:return clear_onload();");

        }
    }
    public void bindadtype()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {


            NewAdbooking.Report.classesoracle.ad_bussiness_targetrpt advname = new NewAdbooking.Report.classesoracle.ad_bussiness_targetrpt();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.ad_bussiness_targetrpt advname = new NewAdbooking.Report.Classes.ad_bussiness_targetrpt();
            ds = advname.adname(Session["compcode"].ToString());

        }
        ListItem li1;
        li1 = new ListItem();

        li1.Value = "";
        li1.Text = "--Select AdType--";
        li1.Value = "0";
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
    public void addbranch()
    {
        drpbrn.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvertisementMaster name = new NewAdbooking.Classes.AdvertisementMaster();

            ds = name.adzone(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster name = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = name.adzone(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.AdvertisementMaster name = new NewAdbooking.classmysql.AdvertisementMaster();

            ds = name.adzone(Session["userid"].ToString(), Session["compcode"].ToString());

        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-----Select Branch-----";
        li1.Value = "0";
        li1.Selected = true;
        drpbrn.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpbrn.Items.Add(li);
        }
    }

    public void bindreporttype()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/eyecather_report.xml"));
        int i;
        for (i = 0; i < ds.Tables[2].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[2].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Text = ds.Tables[2].Rows[0].ItemArray[i].ToString();
            drbranch.Items.Add(li);
        }
    }
   
    public void bindreportfor()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/eyecather_report.xml"));
        int i;
        for (i = 0; i < ds.Tables[4].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[4].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Text = ds.Tables[4].Rows[0].ItemArray[i].ToString();
            drpreportfor.Items.Add(li);
        }
    }
    public void bind_uom()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.ad_bussiness_targetrpt binduom = new NewAdbooking.Report.Classes.ad_bussiness_targetrpt();
            ds = binduom.uombind(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.ad_bussiness_targetrpt binduom = new NewAdbooking.Report.classesoracle.ad_bussiness_targetrpt();
            ds = binduom.uombind(Session["compcode"].ToString());

        }

        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/eyecather_report.xml"));
        li1.Text = ds1.Tables[1].Rows[0].ItemArray[0].ToString();
        li1.Value = "0";
        li1.Selected = true;
        dpuom.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpuom.Items.Add(li);


        }
    }

    public void bindpubcent()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.ad_bussiness_targetrpt binduom = new NewAdbooking.Report.Classes.ad_bussiness_targetrpt();
            //ds = binduom.bindpubcent34(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.eyecather_report binduom = new NewAdbooking.Report.classesoracle.eyecather_report();
            ds = binduom.bindpubcent34(Session["compcode"].ToString());

        }

        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/eyecather_report.xml"));
        li1.Text ="--Select Center--";
        li1.Value = "0";
        li1.Selected = true;
        drpcenter.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpcenter.Items.Add(li);


        }
    }
    public void desbind()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/eyecather_report.xml"));
        int i;
        for (i = 0; i < ds.Tables[3].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[3].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Text = ds.Tables[3].Rows[0].ItemArray[i].ToString();
            drpdestination.Items.Add(li);
        }
    }

    [Ajax.AjaxMethod]
    public DataSet adcat(string compcode, string adtype, string center)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bind = new NewAdbooking.Classes.BookingMaster();
            ds = bind.advdatacategoryRate(compcode, adtype, center);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster bind = new FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster();
            ds = bind.advdatacategory(compcode, adtype, center);

        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
            ds = bind.advdatacategory(compcode, adtype);
        }
        return ds;
    }
    public void bindbullet()
    {
        DataSet dsch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ///////if it is 0 than bind the drp down for bg col,or aND IF 1 THAN FOR BULLET DROP DOWN or if not 0 or 1 than get the selected bullet premium into its text field  
            dsch = bindbgcolor.bgcolorbind(Session["compcode"].ToString(), "1", "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ///////if it is 0 than bind the drp down for bg col,or aND IF 1 THAN FOR BULLET DROP DOWN or if not 0 or 1 than get the selected bullet premium into its text field  
            dsch = bindbgcolor.bgcolorbind_qbc(Session["compcode"].ToString(), "1", Session["userid"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bindbgcolor = new NewAdbooking.classmysql.BookingMaster();

            ///////if it is 0 than bind the drp down for bg col,or aND IF 1 THAN FOR BULLET DROP DOWN or if not 0 or 1 than get the selected bullet premium into its text field  
            dsch = bindbgcolor.bgcolorbind(Session["compcode"].ToString(), "1");
        }
        drpeyecat.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select- Bullet";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpeyecat.Items.Add(li1);

        if (dsch.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dsch.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();

                li.Text = dsch.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = dsch.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpeyecat.Items.Add(li);
            }

        }


    }
}