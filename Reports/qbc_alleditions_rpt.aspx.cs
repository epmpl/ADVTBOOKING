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

public partial class Reports_qbc_alleditions_rpt : System.Web.UI.Page
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
            hdncomp_code.Value = Session["compcode"].ToString();
            hdnuserid.Value = Session["userid"].ToString();
            hdncom_name.Value = Session["comp_name"].ToString();
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_qbc_alleditions_rpt));

       
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/qbc_alleditions_rpt.xml"));
        lblcomp_name.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblcomp_code.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbl_unit.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbl_unitcode.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblbranch.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblbranch_code.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblfromdate.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbltodate.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbldest.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbldatetyp.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblyeartyp.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbl_year_month.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        if (!Page.IsPostBack)
        {
            binddest();
            bindyearbasedon();
            binddatebasedon();
            bindyearmonth();
            txtcomp_name.Text = Session["comp_name"].ToString();
            txtcomp_code.Text = Session["compcode"].ToString();
            txtcomp_name.Enabled = false;
            txtcomp_code.Enabled = false;
            txtbranch_code.Enabled = false;
            btnexit.Attributes.Add("onclick", "javascript:return exitclick();");
            txt_unit.Attributes.Add("onpaste", "return false");
            txt_unit.Attributes.Add("ondrag", "return false");
            txt_unit.Attributes.Add("ondrop", "return false");
            txt_unit.Attributes.Add("oncut", "return false");

            txt_unit.Attributes.Add("onkeydown", "javascript:return fillunit(event)");
            lstunit.Attributes.Add("onkeydown", "javascript:return onclickunit(event)");
            lstunit.Attributes.Add("onclick", "javascript:return onclickunit(event)");

            txtbranch.Attributes.Add("onpaste", "return false");
            txtbranch.Attributes.Add("ondrag", "return false");
            txtbranch.Attributes.Add("ondrop", "return false");
            txtbranch.Attributes.Add("oncut", "return false");

            txtbranch.Attributes.Add("onkeydown", "javascript:return fillbrn(event)");
            lstbrn.Attributes.Add("onkeydown", "javascript:return onclickbrn(event)");
            lstbrn.Attributes.Add("onclick", "javascript:return onclickbrn(event)");

            btnsubmit.Attributes.Add("onclick", "javascript:return getreport()");
            btncancel.Attributes.Add("onclick", "javascript:return OnLoadFrom()");
            btnexit.Attributes.Add("onclick", "javascript:return exitclick()");
        }
    }
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/qbc_alleditions_rpt.xml"));
        txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        txtdest.Items.Add(li1);

        for (i = 0; i < destination.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
           
            li.Text = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            txtdest.Items.Add(li);

        }


    }
    public void binddatebasedon()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/qbc_alleditions_rpt.xml"));
        drpdatetype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = "--Select Date Based On--";// ds1.Tables[0].Rows[30].ItemArray[0].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        drpdatetype.Items.Add(li1);

        for (i = 0; i < destination.Tables[3].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = destination.Tables[3].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            
            li.Text = destination.Tables[3].Rows[0].ItemArray[i].ToString();
            drpdatetype.Items.Add(li);

        }


    }
    public void bindyearbasedon()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/qbc_alleditions_rpt.xml"));
        drpyeartyp.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = "--Select Year Based On--";// ds1.Tables[0].Rows[31].ItemArray[0].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        drpyeartyp.Items.Add(li1);

        for (i = 0; i < destination.Tables[2].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = destination.Tables[2].Rows[0].ItemArray[i].ToString();
            i = i + 1;
           
            li.Text = destination.Tables[2].Rows[0].ItemArray[i].ToString();
            drpyeartyp.Items.Add(li);

        }


    }



    public void bindyearmonth()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/qbc_alleditions_rpt.xml"));
        drp_year_month.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = "--Select Year/Month Wish--";
        li1.Value = "0";
        li1.Selected = true;
        drp_year_month.Items.Add(li1);

        for (i = 0; i < destination.Tables[4].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = destination.Tables[4].Rows[0].ItemArray[i].ToString();
            i = i + 1;

            li.Text = destination.Tables[4].Rows[0].ItemArray[i].ToString();
            drp_year_month.Items.Add(li);

        }


    }

    [Ajax.AjaxMethod]
    public DataSet fill_unit(string comp_code ,string unit_name,string userid ,string extra1 ,string extra2  ,string extra3  ,string extra4 ,string extra5 )
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { unit_name };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "websp_pubcenter.websp_pubcenter_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "CIR_BIND_UNIT";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;


    }
    [Ajax.AjaxMethod]
    public DataSet bind_branch(string userid, string pubcenter, string extra1)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.qbc_alleditions_rpt raddi = new NewAdbooking.classesoracle.qbc_alleditions_rpt();


            ds = raddi.getBranch_weekbill(userid, pubcenter, extra1);
        }
        else
        {
           // NewAdbooking.Classes.qbc_alleditions_rpt raddi = new NewAdbooking.Classes.qbc_alleditions_rpt();


            //ds = raddi.getBranch(userid, pubcenter, extra1);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bind_branch1(string userid, string pubcenter, string extra1)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { userid, pubcenter, extra1 };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "cir_branch_bind.cir_branch_bind_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "cir_branch_bind_p2";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;


    }
}