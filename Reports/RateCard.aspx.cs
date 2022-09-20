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

public partial class RateCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            Session["access"] = "0";
            hiddendateformat.Value = Session["dateformat"].ToString();
            hdncompcode.Value = Session["compcode"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(RateCard));

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/RateCard.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbAdtype.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbadcatgory.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblpackage.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblcenter.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lblratecode.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbluom.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();

        if (!IsPostBack)
        {
            bindadvtype();
            fillPubCenter();
            bindratecode();

            BtnRun.Attributes.Add("OnClick", "javascript:return forreport();");

            dpaddtype.Attributes.Add("onchange", "javascript:return bindadcat_schedule();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");

        }
    }

    public void bindratecode()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.DealReport advname = new NewAdbooking.Report.Classes.DealReport();
            ds = advname.bindratecode(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.DealReport advname = new NewAdbooking.Report.classesoracle.DealReport();
            ds = advname.bindratecode(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "adb_bindratecode";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(),null,null };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select RateCode--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpratecode.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpratecode.Items.Add(li);


        }
    }
    private void fillPubCenter()
    {
        DataSet ds;
        drppubcenter.Items.Clear();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();

            ds = logindetail.getPubCenter();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();

            ds = logindetail.getPubCenter();

        }
        else
        {
            string procedureName = "websp_pubcenter_websp_pubcenter_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Center";
        li1.Value = "0";
        li1.Selected = true;
        drppubcenter.Items.Add(li1);
        string[] drptext;
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().IndexOf("(") > 0)
            {
                drptext = ds.Tables[0].Rows[i].ItemArray[1].ToString().Split('(');
                li.Text = drptext[0];
            }
            else
            {
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            }
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drppubcenter.Items.Add(li);
        }

    }
    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();


        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advname = new NewAdbooking.Report.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advname = new NewAdbooking.Report.classesoracle.Class1();
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
        dpaddtype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpaddtype.Items.Add(li);


        }
    }
    public DataSet adcatbnd_new(string adtype, string compcode)
    {

            DataSet ds4 = new DataSet();
            string procedureName = "RA_bindadcategory_RA_bindadcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { adtype, compcode };
            ds4 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
  
        return ds4;

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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
           /* string procedureName = "RA_bindadcategory_RA_bindadcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            // string[] parameterValueArray = new string[] { adtype, Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, new string[] { adtype, Session["compcode"].ToString() });
            * */
           ds =  adcatbnd_new( adtype,  compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.advtype(adtype, compcode);
        }
        
        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet adpkg_bind(string adtype, string compcode)
    {

        DataSet ds4 = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds4 = adcat.package_report(compcode, adtype);
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat1 = new NewAdbooking.Report.classesoracle.Class1();
            ds4 = adcat1.package_report(compcode, adtype);
        }
        else
        {
            string procedureName = "bindpackagereport_bindpackagereport_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcode, adtype };
            ds4 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds4;

    }
    [Ajax.AjaxMethod]
    public DataSet binduom(string compcode, string adtye)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize binduom = new NewAdbooking.Classes.Adsize();
            ds = binduom.uombind(compcode, adtye);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize binduom = new NewAdbooking.classesoracle.Adsize();
            ds = binduom.uombind(compcode, adtye);
        }
        else
        {
            string procedureName = "uomadsize_uomadsize_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcode, adtye };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }
}
