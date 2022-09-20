﻿using System;
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

public partial class changeeditionstatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Ajax.Utility.RegisterTypeForAjax(typeof(changeeditionstatus));

        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddenauto.Value = Session["autogenerated"].ToString();
        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        hiddenusername.Value = Session["Username"].ToString();
        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
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
        // Read in the XML file
        ds.ReadXml(Server.MapPath("XML/EditionStatus.xml"));

        PackageCode.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        AdType.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        Status.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbeditiontype.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();

        if (Session["Username"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        else
        {
        }
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
        if (btnNew.Enabled == false)
            btnNew.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[0].ToString();
        if (btnSave.Enabled == false)
            btnSave.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[1].ToString();
        if (btnModify.Enabled == false)
            btnModify.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[2].ToString();
        if (btnQuery.Enabled == false)
            btnQuery.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[3].ToString();
        if (btnExecute.Enabled == false)
            btnExecute.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[4].ToString();
        if (btnCancel.Enabled == false)
            btnCancel.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[5].ToString();
        if (btnfirst.Enabled == false)
            btnfirst.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[6].ToString();
        if (btnprevious.Enabled == false)
            btnprevious.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[7].ToString();
        if (btnnext.Enabled == false)
            btnnext.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[8].ToString();
        if (btnlast.Enabled == false)
            btnlast.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[9].ToString();
        if (btnDelete.Enabled == false)
            btnDelete.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[10].ToString();
        if (btnExit.Enabled == false)
            btnExit.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[11].ToString();
        btnNew.Focus();
        // Put user code to initialize the page here
        if (!Page.IsPostBack)
        {
            drpPackageCode.Enabled = false;
            drpadtype.Enabled = false;
            drpStatus.Enabled = false;
            drpeditiontype.Enabled = false;
            btnNew.Attributes.Add("OnClick", "javascript:return e_NewClick();");
            btnSave.Attributes.Add("OnClick", "javascript:return e_SaveClick();");
            btnModify.Attributes.Add("OnClick", "javascript:return e_ModifyClick();");
            btnDelete.Attributes.Add("OnClick", "javascript:return e_DeleteClick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return e_QueryClick();");
            btnExecute.Attributes.Add("OnClick", "javascript:return e_ExecuteClick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return e_CancelClick();");
            btnfirst.Attributes.Add("OnClick", "javascript:return e_FirstClick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return e_PreviousClick();");
            btnnext.Attributes.Add("OnClick", "javascript:return e_NextClick();");
            btnlast.Attributes.Add("OnClick", "javascript:return e_LastClick();");
            btnExit.Attributes.Add("OnClick", "javascript:return e_ExitClick();");
            btnDelete.Attributes.Add("OnClick", "javascript:return e_DeleteClick();");
       //     drpadtype.Attributes.Add("onchange", "javascript:return bindpackage(this);");
            drpeditiontype.Attributes.Add("onchange", "javascript:return bindpackage(this);");
        }
        bindadtype();
        addstatus();

    }
public void bindadtype()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CombinationMaster bind = new NewAdbooking.Classes.CombinationMaster();
            ds = bind.adtypbind(Session["compcode"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.CombinationMaster bind = new NewAdbooking.classesoracle.CombinationMaster();
            ds = bind.adtypbind(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.CombinationMaster bind = new NewAdbooking.classmysql.CombinationMaster();
            ds = bind.adtypbind(Session["compcode"].ToString());
        }

        int i;
        ListItem li1;
        li1 = new ListItem();
        drpadtype.Items.Clear();
        li1.Text = "--Select Ad Type--";
        li1.Value = "0";
        li1.Selected = true;
        drpadtype.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpadtype.Items.Add(li);
        }
    }
    public void addstatus()
    {
        ListItem li1;
        li1 = new ListItem();
        drpStatus.Items.Clear();
        li1.Text = "--Select Status--";
        li1.Value = "0";
        li1.Selected = true;
        drpStatus.Items.Add(li1);

        ListItem li;
        li = new ListItem();
        li.Value = "A";
        li.Text = "Active";
        drpStatus.Items.Add(li);
        ListItem li2;
        li2 = new ListItem();
        li2.Value = "I"; 
        li2.Text = "Inactive";
        drpStatus.Items.Add(li2);        
    }

    [Ajax.AjaxMethod]
    public DataSet addpackage(string compcode,string adtypecode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();
            ds = bindopackage.packagebind(compcode, adtypecode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();
            ds = bindopackage.packagebind(compcode, adtypecode);
        }
        else
        {
            NewAdbooking.classmysql.Contract bindopackage = new NewAdbooking.classmysql.Contract();
            ds = bindopackage.packagebind(compcode, adtypecode);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public void savePackageStatus(string compcode, string userid, string pkgcode, string pkgstatus, string edition)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.changeeditionstatus objpackagestatus = new NewAdbooking.Classes.changeeditionstatus();
            objpackagestatus.clspackagestatus(compcode, userid, pkgcode, pkgstatus, edition);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.changeeditionstatus objpackagestatus = new NewAdbooking.classesoracle.changeeditionstatus();
            objpackagestatus.clspackagestatus(compcode, userid, pkgcode, pkgstatus, edition);
        }
        else
        {
            NewAdbooking.classmysql.Contract objpakagestatus = new NewAdbooking.classmysql.Contract();
            //objpakagestatus.clspackagestatus(compcode, userid, adtype, pkgcode, pkgstatus);
        }
    }

    [Ajax.AjaxMethod]
    public void modifyPackageStatus(string compcode, string pkgcode, string pkgstatus,string recordid)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract objpackagestatus = new NewAdbooking.Classes.Contract();
          //  objpackagestatus.clsmodifypackagestatus(compcode, adtype, pkgcode, pkgstatus, recordid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.changeeditionstatus objpackagestatus = new NewAdbooking.classesoracle.changeeditionstatus();
            objpackagestatus.clsmodifypackagestatus(compcode, pkgcode, pkgstatus, recordid,"");
        }
        else
        {
            NewAdbooking.classmysql.Contract objpackagestatus = new NewAdbooking.classmysql.Contract();
          //  objpackagestatus.clsmodifypackagestatus(compcode, adtype, pkgcode, pkgstatus, recordid);
        }
    }

    [Ajax.AjaxMethod]
    public void deletePackageStatus(string compcode, string adtype, string pkgcode)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract objpackagestatus = new NewAdbooking.Classes.Contract();
            objpackagestatus.clsdeletepackagestatus(compcode, adtype, pkgcode);   
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract objpackagestatus = new NewAdbooking.classesoracle.Contract();
            objpackagestatus.clsdeletepackagestatus(compcode, adtype, pkgcode);
        }
        else
        {
            NewAdbooking.classmysql.Contract objpackagestatus = new NewAdbooking.classmysql.Contract();
            objpackagestatus.clsdeletepackagestatus(compcode, adtype, pkgcode);
        }
    }
     [Ajax.AjaxMethod]
    public DataSet ExistingPkgStatus(string compcode,string pkgcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.changeeditionstatus objexistpackage = new NewAdbooking.Classes.changeeditionstatus();
            ds = objexistpackage.clsexistpackagestatus(compcode, pkgcode); 
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.changeeditionstatus objexistpackage = new NewAdbooking.classesoracle.changeeditionstatus();
            ds = objexistpackage.clsexistpackagestatus(compcode, pkgcode);
        }
        else
        {
            NewAdbooking.classmysql.Contract objexistpackage = new NewAdbooking.classmysql.Contract();
            //ds = objexistpackage.clsexistpackagestatus(compcode, adtype, pkgcode);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindEntry(string compcode,string pkgcode,string pkgstatus)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.changeeditionstatus objbind = new NewAdbooking.Classes.changeeditionstatus();
            ds = objbind.clsbindEntry(compcode, pkgcode, pkgstatus);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.changeeditionstatus objbind = new NewAdbooking.classesoracle.changeeditionstatus();
            ds = objbind.clsbindEntry(compcode, pkgcode, pkgstatus);
        }
        else
        {
            NewAdbooking.classmysql.Contract objbind = new NewAdbooking.classmysql.Contract();
        //    ds = objbind.clsbindEntry(compcode, adtype, pkgcode, pkgstatus);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet CheckPermission(string compcode,string userid,string formname)
    {
        DataSet dz = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
            dz = checkform.formpermission(compcode, userid, "EditionStatus");
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();
            dz = checkform.formpermission(compcode, userid, "EditionStatus");

        }
        else
        {
            NewAdbooking.classmysql.Master checkform = new NewAdbooking.classmysql.Master();
            dz = checkform.formpermission(compcode, userid, "EditionStatus");
        }
        return dz;

    }
    [Ajax.AjaxMethod]
    public DataSet addpackage1(string compcode, string adtypecode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.changeeditionstatus bindopackage = new NewAdbooking.Classes.changeeditionstatus();
            ds = bindopackage.packagebind1(compcode, adtypecode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.changeeditionstatus bindopackage = new NewAdbooking.classesoracle.changeeditionstatus();
            ds = bindopackage.packagebind_n(compcode, adtypecode);
        }
        else
        {
            NewAdbooking.classmysql.Contract bindopackage = new NewAdbooking.classmysql.Contract();
            ds = bindopackage.packagebind(compcode, adtypecode);
        }
        return ds;
    }
        
}
