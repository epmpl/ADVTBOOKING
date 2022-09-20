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

public partial class Reports_targetanalisis : System.Web.UI.Page
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
            hdnuserid.Value = Session["userid"].ToString();
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_targetanalisis));
        DataSet ds = new DataSet();

        ds.ReadXml(Server.MapPath("XML/targetanalisis.xml"));
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbedition.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbuom.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbpaymode.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbbasedon.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        rdoexecutive.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        rdoagencywise.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        rdouomwise.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        rdosupplinentwise.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        agencyname.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        btnclear.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
        if (!Page.IsPostBack)
        {
               bindpub();
               bindadtype();
               bindbasedon();
               desbind();
               bindpaymode();
               bind_uom();
               dppub1.Attributes.Add("onchange", "javascript:return bind_edition5();");
              // drpadtype.Attributes.Add("onchange", "javascript:return binduom();");
              BtnRun.Attributes.Add("OnClick", "javascript:return runreport();");
              dpagency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr_allagency(event);");
              dpagency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr_allagency(event);");
              lstagency.Attributes.Add("onclick", "javascript:return ClickAgaency1(event);");
              lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaency1(event);");
              btnclear.Attributes.Add("onclick", "javascript:return clear_onload();");

        }


    }

    public void bindpaymode()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.targetanalisis advpub = new NewAdbooking.Report.classesoracle.targetanalisis();
            ds = advpub.paymode(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.targetanalisis advpub = new NewAdbooking.Report.Classes.targetanalisis();
             ds = advpub.paymode(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            string procedureName = "payfill_payfill_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/targetanalisis.xml"));
        li1.Text = ds1.Tables[1].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";
        li1.Selected = true;
        drppaymode.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drppaymode.Items.Add(li);


        }
    }

    public void bindpub()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.targetanalisis advpub = new NewAdbooking.Report.classesoracle.targetanalisis();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.targetanalisis advpub = new NewAdbooking.Report.Classes.targetanalisis();
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
        ds1.ReadXml(Server.MapPath("XML/targetanalisis.xml"));
        li1.Text = ds1.Tables[1].Rows[0].ItemArray[0].ToString();
        li1.Value = "0";
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
    public DataSet edition_bind(string publication, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.targetanalisis pub_cent2 = new NewAdbooking.Report.classesoracle.targetanalisis();
            ds = pub_cent2.edition(publication, "", compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.targetanalisis pub_cent2 = new NewAdbooking.Report.Classes.targetanalisis();
            ds = pub_cent2.edition(publication, "", compcode);
        }
        else
        {
            string procedureName = "edition_proc_edition_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { publication, "", compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

    
    public void bind_uom()
    {
               
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.targetanalisis binduom = new NewAdbooking.Report.Classes.targetanalisis();
            ds = binduom.uombind(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.targetanalisis binduom = new NewAdbooking.Report.classesoracle.targetanalisis();
            ds = binduom.uombind(Session["compcode"].ToString());

        }
        else
        {
            string procedureName = "binduomfortarget";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }


        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/targetanalisis.xml"));
        li1.Text = ds1.Tables[1].Rows[0].ItemArray[2].ToString();
        li1.Value = "0";
        li1.Selected = true;
        drpuom.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpuom.Items.Add(li);


        }
    }

    public void bindadtype()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {


            NewAdbooking.Report.classesoracle.targetanalisis advname = new NewAdbooking.Report.classesoracle.targetanalisis();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.targetanalisis advname = new NewAdbooking.Report.Classes.targetanalisis();
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

        li1.Value = "";
        li1.Text = "--Select AdType--";
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

    public void bindbasedon()
    {
        DataSet ds = new DataSet();
         ds.ReadXml(Server.MapPath("XML/targetanalisis.xml"));
        int i;
        for (i = 0; i < ds.Tables[2].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[2].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Text = ds.Tables[2].Rows[0].ItemArray[i].ToString();
            drpbasedon.Items.Add(li);
        }
    }

    public void desbind()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/targetanalisis.xml"));
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
            string procedureName = "bindagencyforxls.bindagencyforxls_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcol, agen };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet getlastday(string frmdate, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.targetanalisis adagency = new NewAdbooking.Report.classesoracle.targetanalisis();
            ds = adagency.getlastday(frmdate, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.targetanalisis adagency = new NewAdbooking.Report.Classes.targetanalisis();
            ds = adagency.getlastday(frmdate, dateformat);
        }

        else
        {
            string procedureName = "getlastday";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { frmdate, dateformat };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }


    
    
}
