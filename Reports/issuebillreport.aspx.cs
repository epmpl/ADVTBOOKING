using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Reports_issuebillreport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] != null)
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            chk_access.Value = Session["access"].ToString();
            branch.Value = Session["revenue"].ToString();
            //branchname.Value = Session["revenuename"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
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


        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_issuebillreport));
        DataSet xml = new DataSet();
        xml.ReadXml(Server.MapPath("XML/issuebillreport.xml"));
        Lblprincent.Text = xml.Tables[0].Rows[0].ItemArray[2].ToString();
        lbDateFrom.Text = xml.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = xml.Tables[0].Rows[0].ItemArray[1].ToString();
        lblmanedtn.Text = xml.Tables[0].Rows[0].ItemArray[5].ToString();
        lblbranch.Text = xml.Tables[0].Rows[0].ItemArray[3].ToString();
        lblpublication.Text = xml.Tables[0].Rows[0].ItemArray[4].ToString();
        lbldistrict.Text = xml.Tables[0].Rows[0].ItemArray[10].ToString();
        LblDestinationType.Text = xml.Tables[0].Rows[0].ItemArray[9].ToString();
        //lblsubedn.Text = xml.Tables[0].Rows[0].ItemArray[6].ToString();
        suppliment.Text = xml.Tables[0].Rows[0].ItemArray[7].ToString();
        btnRun.Text = xml.Tables[0].Rows[0].ItemArray[8].ToString();

        if (!Page.IsPostBack)
        {
            dppub1.Attributes.Add("OnChange", "javascript:return bindedtn();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            ddledtn.Attributes.Add("onchange", "javascript:return suppbind();");
            btnRun.Attributes.Add("onclick", "javascript:return forreport();");

            bindpubcent();
            binddistrict();
            bindbranch();
            bindpub();
        }
    }

    public void bindpubcent()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.issuebillreport pub_cent1 = new NewAdbooking.Report.classesoracle.issuebillreport();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.issuebillreport pub_cent1 = new NewAdbooking.Report.Classes.issuebillreport();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Bind_PubCentName_r_Bind_PubCentName_r_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "";
        li.Text = "Select Printing Center";
        li.Selected = true;
        Drppubcent.Items.Add(li);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            Drppubcent.Items.Add(li1);


        }
    }

    public void binddistrict()
    {
        //regionhidden=hiddenregion.Value;

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.issuebillreport pub = new NewAdbooking.Report.classesoracle.issuebillreport();
            ds = pub.district(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.issuebillreport pub = new NewAdbooking.Report.Classes.issuebillreport();
            ds = pub.district(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "CityMst_District_CityMst_District_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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


    public void bindbranch()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.issuebillreport pub = new NewAdbooking.Report.classesoracle.issuebillreport();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.issuebillreport pub = new NewAdbooking.Report.Classes.issuebillreport();
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
        li.Value = "";
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

    }
    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.issuebillwise advpub = new NewAdbooking.Report.Classes.issuebillwise();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.issuebillreport advpub = new NewAdbooking.Report.classesoracle.issuebillreport();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Bind_PubName_Bind_PubName_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        //li1.Text = "--Select Publication--";
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
    public DataSet bindedtn(string compcode, string publ_code, string dateformat, string extra1, string extra2)
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.issuebillreport advpub = new NewAdbooking.Report.Classes.issuebillreport();
            ds = advpub.pub_Edtn(compcode, publ_code, dateformat, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.issuebillreport advpub = new NewAdbooking.Report.classesoracle.issuebillreport();
            ds = advpub.pub_Edtn(compcode, publ_code, dateformat, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "edition_proc_edition_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, publ_code, dateformat, extra1, extra2 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;


    }
    [Ajax.AjaxMethod]
    public DataSet bindsupp(string compcode, string edition)
    {
        DataSet ds = new DataSet();
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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindsuppliment_bindsuppliment_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, edition };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;

    }
   
}

