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

public partial class ASMT : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Session Expired Please Login Again');window.close();</script>");
            return;
        }

        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    var cheakorclsql = "sql";
        //}
        //else {
        //    var cheakorclsql = "oracle";
        //}
        hdncompcode.Value = Session["compcode"].ToString();
        hdnuser.Value = Session["userid"].ToString();
        hdncurdate.Value = DateTime.Now.ToString("dd/MM/yyyy");
        hiddendateformat.Value = Session["dateformat"].ToString();
        cheakorclsql.Value = cheakorclsql1.Value=ConfigurationSettings.AppSettings["ConnectionType"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(ASMT));
        DataSet objDataSetbu = new DataSet();
        objDataSetbu.ReadXml(Server.MapPath("XML/ASMT.xml"));
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
        Agencylabel.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[0].ToString();
        securityamountlabel.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[1].ToString();
        commisionlabel.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[2].ToString();
        statuslabel.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[3].ToString();
        lstagency.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[12].ToString();
        executedeletesaveoperation.Value = objDataSetbu.Tables[1].Rows[0].ItemArray[4].ToString();
        modifyoperation.Value = objDataSetbu.Tables[1].Rows[0].ItemArray[4].ToString();
        String tablename = objDataSetbu.Tables[1].Rows[0].ItemArray[5].ToString();
        whercol.Value = objDataSetbu.Tables[1].Rows[0].ItemArray[8].ToString();
        if (!IsPostBack)
        {
            btnNew.Attributes.Add("OnClick", "javascript:return newClick(event);");
            btnCancel.Attributes.Add("OnClick", "javascript:return clearClick(event);");
            btnExit.Attributes.Add("onclick", "javascript:return exitbook(event);");
            btnSave.Attributes.Add("onclick", "javascript:return EmailSave();");
            btnQuery.Attributes.Add("OnClick", "javascript:return EmailQuery();");
            btnExecute.Attributes.Add("OnClick", "javascript:return EmailExecute();");
            btnfirst.Attributes.Add("OnClick", "javascript:return EmailFirst();");
            btnnext.Attributes.Add("OnClick", "javascript:return EmailNext();");
            btnprevious.Attributes.Add("OnClick", "javascript:return EmailPrevious();");
            btnlast.Attributes.Add("OnClick", "javascript:return EmailLast();");
            btnDelete.Attributes.Add("OnClick", "javascript:return EmailDelete();");
            btnModify.Attributes.Add("onclick", "javascript:return EmailModify();");

            
            lstagency.Attributes.Add("onclick", "javascript:return onclickagency(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return onclickagency(event);");
            textagency.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            textagency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr(event);");
            textagency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr(event);");
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

        return ds;
    }
    [Ajax.AjaxMethod]
    public String tal_modify(string mod_tablefields, string mod_tablevalue, string mod_tablename, string mod_action, string wherefield, string date, string extra1, string extra2)
    {
        try
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.emailprocessmaster obj = new NewAdbooking.classesoracle.emailprocessmaster();
                ds = obj.Modify_tal(mod_tablefields, mod_tablevalue, mod_tablename, mod_action, wherefield, date, extra1, extra2);
            }
            else
            {
                NewAdbooking.Classes.emailprocessmaster obj = new NewAdbooking.Classes.emailprocessmaster();
                //ds = obj.Modify_tal(mod_tablefields, mod_tablevalue, mod_tablename, mod_action, wherefield, date, extra1, extra2);
            }
            return "true";
        }

        catch (Exception ex)
        {
            return Convert.ToString(ex.Message);
        }
    }

    [Ajax.AjaxMethod]
    public string Savename(string COMP_CODE, string AG_MAIN_CODE, string AG_SUB_CODE, string SEC_RATE_TYPE, string SEC_RATE, string SEC_LIMIT_AMT, string CREATED_BY, string CREATED_DATE, string flag)
    {
        string str = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.emailprocessmaster obj = new NewAdbooking.Classes.emailprocessmaster();
            str = obj.Save_main1(COMP_CODE, AG_MAIN_CODE, AG_SUB_CODE, SEC_RATE_TYPE, SEC_RATE, SEC_LIMIT_AMT, CREATED_BY, CREATED_DATE, flag);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.emailprocessmaster obj = new NewAdbooking.classesoracle.emailprocessmaster();
                //str = obj.Save_main(string code, string unitcode, string tblname, string action, string datefrm, string extra1, string extra2);
            }
        return str;
    }


    [Ajax.AjaxMethod]
    public string Savename1(string code, string unitcode, string tblname, string action, string datefrm, string extra1, string extra2)
    {
        string str = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.emailprocessmaster obj = new NewAdbooking.Classes.emailprocessmaster();
           // str = obj.Save_main(COMP_CODE, AG_MAIN_CODE, AG_SUB_CODE, SEC_RATE_TYPE, SEC_RATE, SEC_LIMIT_AMT, CREATED_BY, CREATED_DATE, flag);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.emailprocessmaster obj = new NewAdbooking.classesoracle.emailprocessmaster();
                str = obj.Save_main(code,unitcode,tblname,action,datefrm,extra1,extra2);
            }
        return str;
    }

    [Ajax.AjaxMethod]
    public string Savenamemodify(string COMP_CODE, string AG_MAIN_CODE, string AG_SUB_CODE, string SEC_RATE_TYPE, string SEC_RATE, string SEC_LIMIT_AMT, string CREATED_BY, string CREATED_DATE, string flag)
    {
        string str = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.emailprocessmaster obj = new NewAdbooking.Classes.emailprocessmaster();
            str = obj.Save_main1(COMP_CODE, AG_MAIN_CODE, AG_SUB_CODE, SEC_RATE_TYPE, SEC_RATE, SEC_LIMIT_AMT, CREATED_BY, CREATED_DATE, flag);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.emailprocessmaster obj = new NewAdbooking.classesoracle.emailprocessmaster();
                //str = obj.Save_main(COMP_CODE, AG_MAIN_CODE, AG_SUB_CODE, SEC_RATE_TYPE, SEC_RATE, SEC_LIMIT_AMT, CREATED_BY, CREATED_DATE, flag);
            }
        return str;
    }


    [Ajax.AjaxMethod]
    public DataSet clie_execute(string tablename, string ex_ficolname, string ex_finalval, string ex_pre, string date, string extra1, string extra2)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.emailprocessmaster obj = new NewAdbooking.classesoracle.emailprocessmaster();
            ds = obj.cli_execute(tablename, ex_ficolname, ex_finalval, ex_pre, date, extra1, extra2);
        }
        else
        {
            NewAdbooking.Classes.emailprocessmaster obj = new NewAdbooking.Classes.emailprocessmaster();
            ds = obj.cli_execute(tablename, ex_ficolname, ex_finalval, ex_pre, date, extra1, extra2);
        }

        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet bindagency(string comcode,string code,string value)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.emailprocessmaster obj = new NewAdbooking.classesoracle.emailprocessmaster();
            ds = obj.bindagencyname(comcode, code, value);
        }
        else
        {
            NewAdbooking.Classes.emailprocessmaster obj = new NewAdbooking.Classes.emailprocessmaster();
            ds = obj.bindagencyname22(comcode, code, value);
        }

        return ds;
    }

    [Ajax.AjaxMethod]
    public String tal_delete(string del_tabname, string del_colname, string del_colval, string del_action, string date, string extra1, string extra2)
    {
        try
        {
            string result = "";
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.emailprocessmaster obj = new NewAdbooking.classesoracle.emailprocessmaster();
                result = obj.delete_tal(del_tabname, del_colname, del_colval, del_action, date, extra1, extra2);
            }
            else
            {
                NewAdbooking.Classes.emailprocessmaster obj = new NewAdbooking.Classes.emailprocessmaster();
                result = obj.delete_tal(del_tabname, del_colname, del_colval, del_action, date, extra1, extra2);

            }
            return result;
        }
        catch (Exception ex)
        {
            return Convert.ToString(ex.Message);
        }
    }


}
