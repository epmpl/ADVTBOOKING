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

public partial class Agency_CreditAmount : System.Web.UI.Page
{
    int j = 0, sno=0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            dateformat.Value = Session["dateformat"].ToString();
            //hiddendateformat.Value = "mm/dd/yyyy";
            //dateformat.Value = "mm/dd/yyyy";
            hdncompcode.Value = Session["compcode"].ToString();
            hdncompname.Value = Session["comp_name"].ToString();
            hdnuserid.Value = Session["userid"].ToString();
            hdnunitcode.Value = Session["center"].ToString();
            hdncentername.Value = Session["centername"].ToString();
            hiddenconnection.Value = ConfigurationSettings.AppSettings["ConnectionType"].ToString();
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


            Ajax.Utility.RegisterTypeForAjax(typeof(Agency_CreditAmount));
            //btnNew.Focus();
            //btnNew.Enabled = true;
            //btnSave.Enabled = false;
            //btnQuery.Enabled = true;
            //btnModify.Enabled = false;
            //btnExecute.Enabled = false;
            //btnCancel.Enabled = true;
            //btnfirst.Enabled = false;
            //btnprevious.Enabled = false;
            //btnnext.Enabled = false;
            //btnlast.Enabled = false;
            //btnDelete.Enabled = false;
            //btnExit.Enabled = true;

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/Button.xml"));
            btnNew.ImageUrl = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            btnSave.ImageUrl = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            btnQuery.ImageUrl = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
            btnModify.ImageUrl = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
            btnExecute.ImageUrl = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
            btnCancel.ImageUrl = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            btnfirst.ImageUrl = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            btnprevious.ImageUrl = ds1.Tables[0].Rows[0].ItemArray[7].ToString();
            btnnext.ImageUrl = ds1.Tables[0].Rows[0].ItemArray[8].ToString();
            btnlast.ImageUrl = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
            btnDelete.ImageUrl = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
            btnExit.ImageUrl = ds1.Tables[0].Rows[0].ItemArray[11].ToString();

            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/Agency_CreditAmount.xml"));


            lblcompcode.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            lblqbccode.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();

            lbldate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            lblbalance.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();

            tblfields.Value = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            hiddennochangecode.Value = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            deltblfields.Value = ds.Tables[0].Rows[0].ItemArray[6].ToString();


            btnNew.Attributes.Add("onclick", "javascript:return Newclick();");
            btnSave.Attributes.Add("onclick", "javascript:return chkduplicacy()");
            btnExit.Attributes.Add("onclick", "javascript:return Exit();");
            btnCancel.Attributes.Add("onclick", "javascript:return clear_all();");
            btnQuery.Attributes.Add("onclick", "javascript:return EnabledonQuery()");
            btnExecute.Attributes.Add("onclick", "javascript:return EnableExecute()");
            btnfirst.Attributes.Add("onclick", "javascript:return Find_FirstRecord()");
            btnprevious.Attributes.Add("onclick", "javascript:return Find_PreRecord()");
            btnnext.Attributes.Add("onclick", "javascript:return Find_NextRecord()");
            btnlast.Attributes.Add("onclick", "javascript:return Find_LastRecord()");
            btnDelete.Attributes.Add("onclick", "javascript:return Delete_Record()");
            btnModify.Attributes.Add("onclick", "javascript:return Modify_Records()");

            txtqbccode.Attributes.Add("onkeydown", "javascript:return F2fillagencycr_allagency(event);");
            txtqbccode.Attributes.Add("onkeypress", "javascript:return F2fillagencycr_allagency(event);");

            lstagency.Attributes.Add("onclick", "javascript:return ClickAgaency1(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaency1(event);");

            BtnRun.Attributes.Add("onclick", "javascript:return chkfrrun()");
            txtdate.Attributes.Add("OnChange", "javascript:return checkdateforcurr(this);  ");
            //Button4.Attributes.Add("onclick", "javascript:return EnableExecute('view');");

            //txtdate.Attributes.Add("onblur", "javascript:return isDatevat(this.value,this.id,document.getElementById('hiddendateformat').value,document.getElementById('HDN_server_date').value)");







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
            NewAdbooking.classmysql.Master adagency = new NewAdbooking.classmysql.Master();
            ds = adagency.bindagencyforxls(compcol, agen);
        }

        return ds;
    }

    [Ajax.AjaxMethod]
    public string Savename(string fields, string finalval, string tablename, string insert, string dateformat, string extra2, string extra3)
    {
        string str = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Roav_qbc obj = new NewAdbooking.Classes.Roav_qbc();
            str = obj.Save_main(fields, finalval, tablename, insert, dateformat, extra2, extra3);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Roav_qbc obj = new NewAdbooking.classesoracle.Roav_qbc();
                str = obj.Save_main(fields, finalval, tablename, insert, dateformat, extra2, extra3);
            }
            else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "cir_dynamic_dml_variable_insert_stmt";
                string[] parameterValueArray = { tablename, fields, finalval, "$~$", dateformat, extra2, extra3 };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                str = "true";
            }
        return str;
    }

    [Ajax.AjaxMethod]
    public String tal_modify(string mod_tablefields, string mod_tablevalue, string mod_tablename, string mod_action, string wherefield, string date, string extra1, string extra2)
    {
        try
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Roav_qbc obj = new NewAdbooking.classesoracle.Roav_qbc();
                ds = obj.Modify_tal(mod_tablefields, mod_tablevalue, mod_tablename, mod_action, wherefield, date, extra1, extra2);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Roav_qbc obj = new NewAdbooking.Classes.Roav_qbc();
                ds = obj.Modify_tal(mod_tablefields, mod_tablevalue, mod_tablename, mod_action, wherefield, date, extra1, extra2);
            }
            else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "cir_dynamic_dml_variable_update_stmt";
                string[] parameterValueArray = { mod_tablename, mod_tablefields, mod_tablevalue, "$~$", mod_action, date, wherefield, extra2 };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            return "true";
        }

        catch (Exception ex)
        {
            return Convert.ToString(ex.Message);
        }
    }

    [Ajax.AjaxMethod]
    public DataSet clie_execute(string tablename, string ex_ficolname, string ex_finalval, string ex_pre, string date, string extra1, string extra2)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Roav_qbc obj = new NewAdbooking.classesoracle.Roav_qbc();
            ds = obj.cli_execute(tablename, ex_ficolname, ex_finalval, ex_pre, date, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Roav_qbc obj = new NewAdbooking.Classes.Roav_qbc();
            ds = obj.cli_execute(tablename, ex_ficolname, ex_finalval, ex_pre, date, extra1, extra2);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "cir_dynamic_dml_variable_execute_stmt";
            string[] parameterValueArray = { tablename, ex_ficolname, ex_finalval, ex_pre, date, extra1, extra2 };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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
                NewAdbooking.classesoracle.Roav_qbc obj = new NewAdbooking.classesoracle.Roav_qbc();
                result = obj.delete_tal(del_tabname, del_colname, del_colval, del_action, date, extra1, extra2);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Roav_qbc obj = new NewAdbooking.Classes.Roav_qbc();
                result = obj.delete_tal(del_tabname, del_colname, del_colval, del_action, date, extra1, extra2);

            }
            else
            {
                NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
                result = obj.delete_tal(del_tabname, del_colname, del_colval, del_action, date, extra1, extra2);
                //string procedureName = "cir_dynamic_dml_variable_delete_stmt";
                //string[] parameterValueArray = { del_tabname, del_colname, del_colval, "$~$", del_action, date, extra1, extra2 };
                //NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                //result = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            return result;
        }
        catch (Exception ex)
        {
            return Convert.ToString(ex.Message);
        }
    }

    [Ajax.AjaxMethod]
    public DataSet checkduplicacy(string ptbl_name, string pcol1, string pcol1_val, string pcol2, string pcol2_val, string pcol3, string pcol3_val, string pcol4, string pcol4_val, string pcol5, string pcol5_val, string pcol6, string pcol6_val, string pcol7, string pcol7_val, string pcol8, string pcol8_val, string pcol9, string pcol9_val, string pcol10, string pcol10_val, string date, string extra1, string extra2)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Roav_qbc duplicacy = new NewAdbooking.classesoracle.Roav_qbc();
            ds = duplicacy.duplicacy_chk(ptbl_name, pcol1, pcol1_val, pcol2, pcol2_val, pcol3, pcol3_val, pcol4, pcol4_val, pcol5, pcol5_val, pcol6, pcol6_val, pcol7, pcol7_val, pcol8, pcol8_val, pcol9, pcol9_val, pcol10, pcol10_val, date, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Roav_qbc duplicacy = new NewAdbooking.Classes.Roav_qbc();
           ds = duplicacy.duplicacy_chk(ptbl_name, pcol1, pcol1_val, pcol2, pcol2_val, pcol3, pcol3_val, pcol4, pcol4_val, pcol5, pcol5_val, pcol6, pcol6_val, pcol7, pcol7_val, pcol8, pcol8_val, pcol9, pcol9_val, pcol10, pcol10_val, date, extra1, extra2);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "tv_duplicacy";
            string[] parameterValueArray = { ptbl_name, pcol1, pcol1_val, pcol2, pcol2_val, pcol3, pcol3_val, pcol4, pcol4_val, pcol5, pcol5_val, pcol6, pcol6_val, pcol7, pcol7_val, pcol8, pcol8_val, pcol9, pcol9_val, pcol10, pcol10_val, date, extra1, extra2 };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet Agency_get(string pcode, string subcode)
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Roav_qbc obj = new NewAdbooking.classesoracle.Roav_qbc();
            ds = obj.Agency_getname(pcode, subcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Roav_qbc augen = new NewAdbooking.Classes.Roav_qbc();
            ds = augen.Agency_getname(pcode, subcode);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "jbl_get_agency";
            string[] parameterValueArray = { pcode, subcode };
            NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
            ds = obj.BindCommanFunctionagency(procedureName, parameterValueArray);
        }

        return ds;
    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Header)
        {
            //   string insert = "Insert_" + j;
            //    string edition = "edition_" + j;
            string chekbox = "chekbox_" + j;
            string bilhold = "bilhold_" + j;



            e.Item.Cells[0].Text = Convert.ToString(sno++);



            //if (e.Item.Cells[25].Text == "Y")
            //{
            //    e.Item.Cells[22].Text = "<input type='checkbox' disabled  size='1'   id=" + chekbox + "'   />";
            //}
            //else

            //    e.Item.Cells[6].Text = "<input type='checkbox'   size='1'   id=" + chekbox + "'    />";

            j++;
        }

    }

    protected void BtnRun_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Roav_qbc obj = new NewAdbooking.Classes.Roav_qbc();

            ds = obj.getagamnt(hdncompcode.Value, hdnagency.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Roav_qbc obj = new NewAdbooking.classesoracle.Roav_qbc();
            ds = obj.getagamnt(hdncompcode.Value, hdnagency.Value);

        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "getagcrdamnt";
            string[] parameterValueArray = { hdncompcode.Value, hdnagency.Value };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count.ToString() == "0")
        {
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();

            Response.Write("<script> alert('Data Not found');</script>");
            //    return;
           


            return;



        }
        else
        {

            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
        }
    }
}
