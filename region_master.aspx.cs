﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class region_master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        if (Session["Username"] == null)
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        hiddencompanycode.Value = Session["compcode"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddenauto.Value = Session["autogenerated"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(region_master));
        hiddenusername.Value = Session["Username"].ToString();

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/button.xml"));
        btnNew.ImageUrl = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        btnSave.ImageUrl = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        btnModify.ImageUrl = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        btnQuery.ImageUrl = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        btnExecute.ImageUrl = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        btnCancel.ImageUrl = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        btnfirst.ImageUrl = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        btnprevious.ImageUrl = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        btnnext.ImageUrl = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        btnlast.ImageUrl = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        btnDelete.ImageUrl = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        btnExit.ImageUrl = ds.Tables[0].Rows[0].ItemArray[11].ToString();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/regionmaster.xml"));
        lbregioncode.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        lbregionname.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        lbalias.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        lbzone.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        
        btnNew.Focus();
        DataSet comm_nam = new DataSet();
        // Read in the XML file
        comm_nam.ReadXml(Server.MapPath("XML/Comm_detail.xml"));
        lblintegration.Text = comm_nam.Tables[0].Rows[0].ItemArray[12].ToString();

        if (!Page.IsPostBack)
        {
            btnNew.Attributes.Add("OnClick", "javascript:return newclick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return cancelclick('region_master');");
            //btnSave.Attributes.Add("OnClick","javascript:return saveclick();  ");
            btnSave.Attributes.Add("OnClick", "javascript:return save();");
            btnModify.Attributes.Add("OnClick", "javascript:return modifyclick();");
            btnDelete.Attributes.Add("OnClick", "javascript:return deleteclick();");

            btnExit.Attributes.Add("OnClick", "javascript:return regionexit();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstclick1();");
            btnlast.Attributes.Add("OnClick", "javascript:return lastclick1();");
            btnprevious.Attributes.Add("OnClick", "javascript:return preclick1();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextclick1();");
            btnExecute.Attributes.Add("OnClick", "javascript:return executeclick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return queryclick();");
            txtregioncode.Attributes.Add("OnChange", "javascript:return uppercase();");
            txtalias.Attributes.Add("OnChange", "javascript:return uppercase2();");
            txtregioncode.Attributes.Add("OnKeyPress", "javascript:return charval();");
            txtregionname.Attributes.Add("OnKeyPress", "javascript:return charval();");
            txtregionname.Attributes.Add("OnChange", "javascript:return autoornot();");
            txtalias.Attributes.Add("OnKeyPress", "javascript:return charval();");
            bindzone();

            txtregioncode.Enabled = false;
            txtregionname.Enabled = false;
            txtalias.Enabled = false;
            drzone.Enabled = false;
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnModify.Enabled = false;
            btnQuery.Enabled = true;
            btnExecute.Enabled = false;
            btnfirst.Enabled = false;
            btnprevious.Enabled = false;
            btnnext.Enabled = false;
            btnlast.Enabled = false;
            btnCancel.Enabled = true;
            btnExit.Enabled = true;
            btnDelete.Enabled = false;
        }
        if (btnNew.Enabled == false)
            btnNew.ImageUrl = ds.Tables[1].Rows[0].ItemArray[0].ToString();
        if (btnSave.Enabled == false)
            btnSave.ImageUrl = ds.Tables[1].Rows[0].ItemArray[1].ToString();
        if (btnModify.Enabled == false)
            btnModify.ImageUrl = ds.Tables[1].Rows[0].ItemArray[2].ToString();
        if (btnQuery.Enabled == false)
            btnQuery.ImageUrl = ds.Tables[1].Rows[0].ItemArray[3].ToString();
        if (btnExecute.Enabled == false)
            btnExecute.ImageUrl = ds.Tables[1].Rows[0].ItemArray[4].ToString();
        if (btnCancel.Enabled == false)
            btnCancel.ImageUrl = ds.Tables[1].Rows[0].ItemArray[5].ToString();
        if (btnfirst.Enabled == false)
            btnfirst.ImageUrl = ds.Tables[1].Rows[0].ItemArray[6].ToString();
        if (btnprevious.Enabled == false)
            btnprevious.ImageUrl = ds.Tables[1].Rows[0].ItemArray[7].ToString();
        if (btnnext.Enabled == false)
            btnnext.ImageUrl = ds.Tables[1].Rows[0].ItemArray[8].ToString();
        if (btnlast.Enabled == false)
            btnlast.ImageUrl = ds.Tables[1].Rows[0].ItemArray[9].ToString();
        if (btnDelete.Enabled == false)
            btnDelete.ImageUrl = ds.Tables[1].Rows[0].ItemArray[10].ToString();
        if (btnExit.Enabled == false)
            btnExit.ImageUrl = ds.Tables[1].Rows[0].ItemArray[11].ToString();
    }
    private void bindzone()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["userid"].ToString(), Session["compcode"].ToString() };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "bindzone";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "bindzone.bindzone_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "BINDZONE_BINDZONE_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        

            ListItem li1;
            li1 = new ListItem();
            li1.Text = "Select Zone";
            li1.Value = "0";
            li1.Selected = true;
            drzone.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drzone.Items.Add(li);
        }

    }
    #region Web Form Designer generated code
    protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }
    private void InitializeComponent()
    {

    }
    #endregion
    [Ajax.AjaxMethod]
    public void regionmastersave(string compcode, string regioncode, string regionname, string alias, string username, string zone, string intg)
    {
        
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, regioncode, regionname, alias, username, zone,intg };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "region_save";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "region_save.region_save_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "region_save_region_save_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        

    }
    [Ajax.AjaxMethod]
    public void regionmastermodify_save(string compcode, string regioncode, string regionname, string alias, string username, string zone, string intg)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, regioncode, regionname, alias, zone,intg };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "sp_modifyregion";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "sp_modifyregion.sp_modifyregion_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "SP_MODIFYREGION_SP_MODIFYREGION_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        
        
    }
    [Ajax.AjaxMethod]
    public DataSet regionsearchexecute(string compcode, string regioncode, string regionname, string alias, string username, string zone)
    {

        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, regioncode, regionname, alias, zone };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "sp_chkregion";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "sp_chkregion.sp_chkregion_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "sp_chkregion_sp_chkregion_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public void delete1(string compcode, string regioncode, string userid)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, regioncode};
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "regiondel";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "regiondel.regiondel_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "regiondel_regiondel_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
    }
    [Ajax.AjaxMethod]
    public DataSet chkregion(string compcode, string regionname, string regioncode, string userid)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, regionname, regioncode, userid };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "chkregion";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "chkregion.chkregion_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "CHKREGION_CHKREGION_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;

    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet chkregioncodename(string str)
    {
        string code = "";
        DataSet ds = new DataSet();
        string compcode = Session["compcode"].ToString();
         if (str.Length > 2)
        {
            code = str.Substring(0, 2);
        }
        else
        {
            code = str;
        }
        string[] parameterValueArray = new string[] { str, code, compcode };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "chkregioncodename";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "chkregioncodename.chkregioncodename_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "CHKREGIONCODENAME_CHKREGIONCODENAME_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet chkname(string regioncode, string regionname, string compcode)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, regioncode, regionname  };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "chkduplicateregion";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "chkduplicateregion.chkduplicateregion_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "CHKDUPLICATEREGION_CHKDUPLICATEREGION_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

    }


