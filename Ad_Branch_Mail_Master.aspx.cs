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

public partial class Ad_Branch_Mail_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["compcode"] != null)
        {
            hdncompcode.Value = Session["compcode"].ToString();
            hdncompname.Value = Session["comp_name"].ToString();
            hdnunitcd.Value = Session["center"].ToString();
            hdnunitnm.Value = Session["centername"].ToString();
            hdnbrancd.Value = Session["revenue"].ToString();
            //hdnbrannm.Value = Session["revenuename"].ToString();
            hdnusernm.Value = Session["Username"].ToString();
            hdnuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();

        }
        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(Ad_Branch_Mail_Master));

        DataSet objDataSetbu = new DataSet();
        objDataSetbu.ReadXml(Server.MapPath("XML/button.xml"));
        btnNew.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
        btnSave.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        btnModify.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
        btnQuery.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[3].ToString();
        btnExecute.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        btnCancel.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
        btnfirst.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString();
        btnprevious.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();
        btnnext.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();
        btnlast.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString();
        btnDelete.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[10].ToString();
        btnExit.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[11].ToString();

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Ad_Branch_Mail_Master.xml"));

        lblunitname.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbbranchname.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblmodule.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbluser.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblmail.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblremarks.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblflag.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();



        btnNew.Enabled = true;
        btnSave.Enabled = false;
        btnModify.Enabled = false;
        btnDelete.Enabled = false;
        btnQuery.Enabled = true;
        btnExecute.Enabled = false;
        btnCancel.Enabled = true;
        btnfirst.Enabled = false;
        btnnext.Enabled = false;
        btnprevious.Enabled = false;
        btnlast.Enabled = false;
        btnExit.Enabled = true;

        if (!Page.IsPostBack)
        {
            btnNew.Attributes.Add("onclick", "javascript:return OnClickNew();");
            btnSave.Attributes.Add("onclick", "javascript:return OnClickSave();");
            btnModify.Attributes.Add("onclick", "javascript:return OnClickModify();");
            btnQuery.Attributes.Add("onclick", "javascript:return OnClickQuery();");
            btnExecute.Attributes.Add("onclick", "javascript:return OnClickExecute();");
            btnCancel.Attributes.Add("onclick", "javascript:return OnClickClear();");
            btnfirst.Attributes.Add("onclick", "javascript:return OnClickFirst();");
            btnprevious.Attributes.Add("onclick", "javascript:return OnClickPrevious();");
            btnnext.Attributes.Add("onclick", "javascript:return OnClickNext();");
            btnlast.Attributes.Add("onclick", "javascript:return OnClickLast();");
            btnDelete.Attributes.Add("onclick", "javascript:return OnClickDelete();");
            btnExit.Attributes.Add("onclick", "javascript:return OnClickExit();");

            txtunitname.Attributes.Add("onkeydown", "javascript:return BindUnit(event);");
            lstunit.Attributes.Add("OnClick", "javascript:return fillunit(event);");
            lstunit.Attributes.Add("onkeypress", "javascript:return fillunit(event);");

            txtbranch.Attributes.Add("onkeydown", "javascript:return BindBranch(event);");
            lstbranch.Attributes.Add("OnClick", "javascript:return fillBranch(event);");
            lstbranch.Attributes.Add("onkeypress", "javascript:return fillBranch(event);");

            txtuserid.Attributes.Add("onkeydown", "javascript:return BindUserid(event);");
            lstuser.Attributes.Add("OnClick", "javascript:return fillUserid(event);");
            lstuser.Attributes.Add("onkeydown", "javascript:return fillUserid(event);");

            BindModule();
            BindFlag();
        }
    }
    public void BindModule()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = { "", "", "", "" };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "user_privileges_module_bind_p";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "user_privileges.module_bind_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "USER_PRIVILEGES_module_bind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li = new ListItem();
        li.Text = "---Select Module---";
        li.Value = "";
        drpmoduleid.Items.Add(li);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li1 = new ListItem();
                    li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    drpmoduleid.Items.Add(li1);
                }
            }
        }
    }
    public void BindFlag()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Ad_Branch_Mail_Master.xml"));
        ListItem li = new ListItem();
        li.Text = "---Select Value---";
        li.Value = "";
        drpflag.Items.Add(li);
        if (ds.Tables[1].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[1].Columns.Count; i++)
            {
                ListItem li1 = new ListItem();
                li1.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
                li1.Value = ds.Tables[1].Rows[0].ItemArray[++i].ToString();
                drpflag.Items.Add(li1);
            }
        }
    }
    [Ajax.AjaxMethod]
    public DataSet bind_unit(string[] parameterValueArray)
    {
        DataSet ds = new DataSet();
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "publication_proc";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "publication_proc.publication_proc_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "publication_proc_publication_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bind_branch(string[] parameterValueArray)
    {
        DataSet ds = new DataSet();
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "branchbind_permissionwise";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "branchbind_adv.branchbind_adv_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "BRANCHBIND_ADV_branchbind_adv_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bind_userid(string[] parameterValueArray)
    {
        DataSet ds = new DataSet();
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "cir_login_bind_p";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "cir_login_bind.cir_login_bind_P";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "cir_login_bind_cir_login_bind_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet Ad_Mailing_Ins_Upd_Del(string[] parameterValueArray)
    {
        DataSet ds = new DataSet();
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "ad_mailing_save";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "ad_mailing_save";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "ad_mailing_save";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
}