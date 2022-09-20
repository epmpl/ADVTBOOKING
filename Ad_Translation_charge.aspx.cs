﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class Ad_Translation_charge : System.Web.UI.Page
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
            hiddencode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenusername.Value = Session["Username"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddenauto.Value = Session["autogenerated"].ToString();
        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
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



        Ajax.Utility.RegisterTypeForAjax(typeof(Ad_Translation_charge));
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
        ds.ReadXml(Server.MapPath("XML/Ad_Translation_charge.xml"));
        lbladtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblchargecode.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblchargename.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblchargealias.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblchargestype.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        //lblchargeamt.Text=ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblfromdate.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbltodate.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lblchargeactive.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        hdnchkdup.Value = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        hdntblfields.Value=ds.Tables[0].Rows[0].ItemArray[9].ToString();
        executefields.Value=ds.Tables[0].Rows[0].ItemArray[10].ToString();
        deltblfields.Value=ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lblchargeamt.Text=ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lblchargeon.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        adtypedata(hiddencode.Value);

        if (!Page.IsPostBack)
        {

            btnNew.Attributes.Add("onclick", "javascript:return EnabledOnNew();");
            btnCancel.Attributes.Add("onclick", "javascript:return ClearAll();");
            btnQuery.Attributes.Add("onclick", "javascript:return EnabledonQuery();");
            btnSave.Attributes.Add("onclick", "javascript:return check_duplicasy();");
            //btnSave.Attributes.Add("onclick", "javascript:return Generatecode();");
            btnExit.Attributes.Add("onclick", "javascript:return Exit();");
            btnExecute.Attributes.Add("onclick", "javascript:return EnableExecute();");
            btnnext.Attributes.Add("onclick", "javascript:return Find_NextRecord();");
            btnlast.Attributes.Add("onclick", "javascript:return Find_Lastrecord();");
            btnprevious.Attributes.Add("onclick", "javascript:return Find_PreRecord();");
            btnfirst.Attributes.Add("onclick", "javascript:return Find_Firstrecord();");
            btnDelete.Attributes.Add("onclick", "javascript:return Delete_Record();");
            btnModify.Attributes.Add("onclick", "javascript:return Modify_Records();");
            txtfromdate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
            txttodate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
            


            //txtfromdate.Attributes.Add("onkeypress", "javascript:return isDate(this.value,this.id,this.value,hiddendateformat.Value);");
            txtchargename.Attributes.Add("onchange", "javascript:return autoornot();");

        }
    }



    public void adtypedata(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CombinationMaster bind = new NewAdbooking.Classes.CombinationMaster();
            ds = bind.adtypbind(compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.CombinationMaster bind = new NewAdbooking.classesoracle.CombinationMaster();
                ds = bind.adtypbind(compcode);

            }
            else
            {
                NewAdbooking.classmysql.CombinationMaster bind = new NewAdbooking.classmysql.CombinationMaster();
                ds = bind.adtypbind(compcode);
            }


        int i;
        ListItem li1;

        li1 = new ListItem();
        drpadtype.Items.Clear();
        li1.Text = "-Select Ad Type-";
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

    [Ajax.AjaxMethod]
    public DataSet chkagencytype(string str, string adcattype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Ad_Translation_charge chk = new NewAdbooking.Classes.Ad_Translation_charge();

            ds = chk.agtypecode(str, adcattype);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Ad_Translation_charge chk = new NewAdbooking.classesoracle.Ad_Translation_charge();

                ds = chk.agtypecode(str,adcattype);
                return ds;
            }
            else
            {
                NewAdbooking.classmysql.AgencyTypeMaster chk = new NewAdbooking.classmysql.AgencyTypeMaster();

                ds = chk.agtypecode(str);
                return ds;
            }

    }


    [Ajax.AjaxMethod]
    public DataSet checkdupl(string compcode, string compcode1, string userid, string userid1, string tabname, string modename, string modename1, string alias, string alias1, string date, string extra1, string extra2)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Ad_Translation_charge code = new NewAdbooking.Classes.Ad_Translation_charge();
            ds = code.checkdp(compcode, compcode1, userid, userid1, tabname, modename, modename1, alias, alias1, date, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Ad_Translation_charge code = new NewAdbooking.classesoracle.Ad_Translation_charge();
            ds = code.checkdp(compcode, compcode1, userid, userid1, tabname, modename, modename1, alias, alias1, date, extra1, extra2);
        }
        else
        {
        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public string save_area(string tablefields, string tablevalue, string tablename, string action, string date, string extra1, string extra2)
    {

        string result = "";
        try
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Ad_Translation_charge code = new NewAdbooking.Classes.Ad_Translation_charge();
                result = code.Save_ModeCode(tablefields, tablevalue, tablename, action, date, extra1, extra2);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Ad_Translation_charge code = new NewAdbooking.classesoracle.Ad_Translation_charge();
                result = code.Save_ModeCode(tablefields, tablevalue, tablename, action, date, extra1, extra2);
            }
            else
            {
            }
            return result;
        }

        catch (Exception ex)
        {
            return ex.Message;
        }
    }



    [Ajax.AjaxMethod]
    public DataSet mode_execute(string tablename, string ex_ficolname, string ex_finalval, string ex_pre, string date, string extra1, string extra2)
    {

        string[] strd = ex_finalval.Split('~');
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Ad_Translation_charge area = new NewAdbooking.Classes.Ad_Translation_charge();
            ds = area.execute_area(tablename, ex_ficolname, ex_finalval, ex_pre, "", "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Ad_Translation_charge area = new NewAdbooking.classesoracle.Ad_Translation_charge();
            //ds = area.execute_area(tablename, ex_ficolname, ex_finalval, ex_pre, "", "", "");
            ds = area.execute_area1(strd[0], strd[1], strd[2], strd[3], strd[4], strd[5], strd[10]);
        }
        else
        {
        }

        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet area_delete(string del_tabname, string del_colname, string del_colval, string del_action, string date, string extra1, string extra2)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Ad_Translation_charge delarea = new NewAdbooking.Classes.Ad_Translation_charge();

            ds = delarea.delete_area(del_tabname, del_colname, del_colval, del_action, date, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Ad_Translation_charge delarea = new NewAdbooking.classesoracle.Ad_Translation_charge();

            ds = delarea.delete_area(del_tabname, del_colname, del_colval, del_action, date, extra1, extra2);
        }
        else
        {
        }
        return ds;
    }



    [Ajax.AjaxMethod]
    public string area_modify(string mod_tablefields, string mod_tablevalue, string mod_tablename, string mod_action, string wherefield, string date, string extra1, string extra2)
    {
        try
        {
            string result = "";
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Ad_Translation_charge modarea = new NewAdbooking.Classes.Ad_Translation_charge();
                result = modarea.Modify_area(mod_tablefields, mod_tablevalue, mod_tablename, mod_action, wherefield, date, extra1, extra2);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Ad_Translation_charge modarea = new NewAdbooking.classesoracle.Ad_Translation_charge();
                result = modarea.Modify_area(mod_tablefields, mod_tablevalue, mod_tablename, mod_action, wherefield, date, extra1, extra2);
            }
            else
            {
            }
            return result;
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }


}
