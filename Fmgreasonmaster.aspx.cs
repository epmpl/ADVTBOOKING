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

public partial class Fmgreasonmaster : System.Web.UI.Page
{
    string isudt = "", dateformat = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        string hur = "", min = "", sec = "", time = "", date = "";
        string day = "", month = "", year = "";

        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hdnuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            //hidsysdate.Value = DateTime.Now.ToShortDateString();

        }


        DataSet objDataSet = new DataSet();



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


        objDataSet.ReadXml(Server.MapPath("XML/fmgreasonmaster.xml"));
        fmgreasoncode.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        fmgreasondesc.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();

        hdnsav.Value = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        hdnexecut.Value = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        hdnsav2.Value = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        whercol.Value = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        //hdnsav2.Value = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        //whercol.Value = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
        //hdnexecut.Value = objDataSet.Tables[0].Rows[0].ItemArray[9].ToString();
        //hdnsavsql.Value = objDataSet.Tables[0].Rows[0].ItemArray[10].ToString();

        Ajax.Utility.RegisterTypeForAjax(typeof(Fmgreasonmaster));
        // Ajax.Utility.RegisterTypeForAjax(typeof(Ro_Qbc));



        btnNew.Enabled = true;
        btnSave.Enabled = false;
        btnModify.Enabled = false;
        btnDelete.Enabled = false;
        btnQuery.Enabled = true;
        btnExecute.Enabled = false;
        btnCancel.Enabled = true;
        btnfirst.Enabled = false;
        btnprevious.Enabled = false;
        btnnext.Enabled = false;
        btnlast.Enabled = false;
        btnExit.Enabled = true;
        //  document.getElementById('txtfmgdesc').value = "";


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





        if (!Page.IsPostBack)
        {
            btnNew.Attributes.Add("OnClick", "javascript:return fmgnew();");
            btnSave.Attributes.Add("OnClick", "javascript:return fmgSave1();");
            btnCancel.Attributes.Add("OnClick", "javascript:return fmgCancel();");
            btnModify.Attributes.Add("OnClick", "javascript:return fmgModify();");
            btnQuery.Attributes.Add("OnClick", "javascript:return fmgQuery();");
            btnExecute.Attributes.Add("OnClick", "javascript:return fmgExecute();");
            btnDelete.Attributes.Add("OnClick", "javascript:return fmgDelete();");
            btnfirst.Attributes.Add("OnClick", "javascript:return fmgFirst();");
            btnnext.Attributes.Add("OnClick", "javascript:return fmgNext();");
            btnprevious.Attributes.Add("OnClick", "javascript:return fmgPrevious();");
            btnlast.Attributes.Add("OnClick", "javascript:return fmgLast();");
            btnExit.Attributes.Add("OnClick", "javascript:return fmgexit();");
        }

        dateformat = hiddendateformat.Value;
        if (hiddendateformat.Value == "dd/mm/yyyy")
        {
            DateTime sysdate = System.DateTime.Now;
            hur = sysdate.Hour.ToString();
            min = sysdate.Minute.ToString();
            sec = sysdate.Second.ToString();

            time = hur + ":" + min + ":" + sec;

            day = sysdate.Day.ToString();
            month = sysdate.Month.ToString();
            year = sysdate.Year.ToString();
            if (day.Length < 2)
                day = "0" + day;
            if (month.Length < 2)
                month = "0" + month;

            date = month + "/" + day + "/" + year;

            hidsysdatesql.Value = day + "/" + month + "/" + year;
            hidsysdate.Value = Convert.ToDateTime(date).ToString("dd-MMMM-yyyy");

        }
        if (hiddendateformat.Value == "mm/dd/yyyy")
        {
            DateTime sysdate = System.DateTime.Now;
            hur = sysdate.Hour.ToString();
            min = sysdate.Minute.ToString();
            sec = sysdate.Second.ToString();

            time = hur + ":" + min + ":" + sec;

            day = sysdate.Day.ToString();
            month = sysdate.Month.ToString();
            year = sysdate.Year.ToString();
            if (day.Length < 2)
                day = "0" + day;
            if (month.Length < 2)
                month = "0" + month;

            date = month + "/" + day + "/" + year;


            hidsysdatesql.Value = day + "/" + month + "/" + year;
            hidsysdate.Value = Convert.ToDateTime(date).ToString("MMMM/dd/yyyy");

        }
        if (hiddendateformat.Value == "yyyy/mm/dd")
        {
            DateTime sysdate = System.DateTime.Now;
            hur = sysdate.Hour.ToString();
            min = sysdate.Minute.ToString();
            sec = sysdate.Second.ToString();

            time = hur + ":" + min + ":" + sec;

            day = sysdate.Day.ToString();
            year = sysdate.Year.ToString();
            month = sysdate.Month.ToString();
            if (day.Length < 2)
                day = "0" + day;
            if (month.Length < 2)
                month = "0" + month;

            date = month + "/" + day + "/" + year;


            hidsysdatesql.Value = day + "/" + month + "/" + year;
            hidsysdate.Value = Convert.ToDateTime(date).ToString("yyyy/MMMM/dd");

        }




    }

    [Ajax.AjaxMethod]
    public string Savename(string fields, string finalval, string tablename, string insert, string dateformat, string extra2, string extra3)
    {
        string str = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.fmgreasonmaster obj = new NewAdbooking.Classes.fmgreasonmaster();
            str = obj.Save_main(fields, finalval, tablename, insert, dateformat, extra2, extra3);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.fmgreasonmaster obj = new NewAdbooking.classesoracle.fmgreasonmaster();
                str = obj.Save_main(fields, finalval, tablename, insert, dateformat, extra2, extra3);
            }
        return str;
    }



    [Ajax.AjaxMethod]
    public DataSet clie_execute(string tablename, string ex_ficolname, string ex_finalval, string ex_pre, string date, string extra1, string extra2)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.fmgreasonmaster obj = new NewAdbooking.classesoracle.fmgreasonmaster();
            ds = obj.cli_execute(tablename, ex_ficolname, ex_finalval, ex_pre, date, extra1, extra2);
        }
        else
        {
            NewAdbooking.Classes.fmgreasonmaster obj = new NewAdbooking.Classes.fmgreasonmaster();
            ds = obj.cli_execute(tablename, ex_ficolname, ex_finalval, ex_pre, date, extra1, extra2);
        }

        return ds;
    }



    [Ajax.AjaxMethod]
    public String ro_modify(string compcode, string typ, string agncod, string issdt, string dateformat, string csisno, string ronofrm, string ronotll, string sts, string userid, string currentdate)
    {
        try
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                //NewAdbooking.classesoracle.Roav_qbc obj = new NewAdbooking.classesoracle.Roav_qbc();
                //ds = obj.Modify_tal(mod_tablefields, mod_tablevalue, mod_tablename, mod_action, wherefield, date, extra1, extra2);
            }
            else
            {
                NewAdbooking.Classes.Roav_qbc obj = new NewAdbooking.Classes.Roav_qbc();
                ds = obj.ro_modify(compcode, typ, agncod, issdt, dateformat, csisno, ronofrm, ronotll, sts, userid, currentdate);
            }
            return "true";
        }

        catch (Exception ex)
        {
            return Convert.ToString(ex.Message);
        }
    }

    [Ajax.AjaxMethod]
    public String tal_modify(string mod_tablefields, string mod_tablevalue, string mod_tablename, string mod_action, string wherefield, string date, string extra1, string extra2)
    {
        try
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.fmgreasonmaster obj = new NewAdbooking.classesoracle.fmgreasonmaster();
                ds = obj.Modify_tal(mod_tablefields, mod_tablevalue, mod_tablename, mod_action, wherefield, date, extra1, extra2);
            }
            else
            {
                NewAdbooking.Classes.fmgreasonmaster obj = new NewAdbooking.Classes.fmgreasonmaster();
                ds = obj.Modify_tal(mod_tablefields, mod_tablevalue, mod_tablename, mod_action, wherefield, date, extra1, extra2);
            }
            return "true";
        }

        catch (Exception ex)
        {
            return Convert.ToString(ex.Message);
        }
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
            else
            {
                NewAdbooking.Classes.fmgreasonmaster obj = new NewAdbooking.Classes.fmgreasonmaster();
                result = obj.delete_tal(del_tabname, del_colname, del_colval, del_action, date, extra1, extra2);

            }
            return result;
        }
        catch (Exception ex)
        {
            return Convert.ToString(ex.Message);
        }
    }

    [Ajax.AjaxMethod]
    public DataSet Autogenerate_Code(string namestr, string pcode)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.fmgreasonmaster obj = new NewAdbooking.classesoracle.fmgreasonmaster();
            ds = obj.gencodfmg(namestr, pcode);
        }
        else
        {


            NewAdbooking.Classes.fmgreasonmaster obj = new NewAdbooking.Classes.fmgreasonmaster();
            ds = obj.gencodfmg(namestr, pcode);

        }

        return ds;
    }

}
