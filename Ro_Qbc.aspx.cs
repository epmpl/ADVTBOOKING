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

public partial class Ro_Qbc : System.Web.UI.Page
{
    string isudt = "", dateformat="";
    protected void Page_Load(object sender, EventArgs e)
    {
        string hur = "", min = "", sec = "",time="",date="";
        string day="", month="", year="";
        
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hdnuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hidsysdate.Value = DateTime.Now.ToShortDateString();
            
        }
        //else
        //{
        //    Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
        //    return;
        //}
        hdncon.Value = ConfigurationSettings.AppSettings["ConnectionType"].ToString();
        DataSet dslbl = new DataSet();
        // Read in the XML file
        dslbl.ReadXml(Server.MapPath("XML/roavqbc.xml"));
        lblagnm.Text = dslbl.Tables[0].Rows[0].ItemArray[0].ToString();
        lblisudt.Text = dslbl.Tables[0].Rows[0].ItemArray[1].ToString();
        lblisuno.Text = dslbl.Tables[0].Rows[0].ItemArray[2].ToString();
       lblfrmno.Text = dslbl.Tables[0].Rows[0].ItemArray[3].ToString();
       lbltlrono.Text = dslbl.Tables[0].Rows[0].ItemArray[4].ToString();
        lblstatus.Text = dslbl.Tables[0].Rows[0].ItemArray[5].ToString();
        hdnsav.Value = dslbl.Tables[0].Rows[0].ItemArray[6].ToString();
        hdnsav2.Value = dslbl.Tables[0].Rows[0].ItemArray[7].ToString();
        whercol.Value = dslbl.Tables[0].Rows[0].ItemArray[8].ToString();
        hdnexecut.Value = dslbl.Tables[0].Rows[0].ItemArray[9].ToString();
        hdnsavsql.Value = dslbl.Tables[0].Rows[0].ItemArray[10].ToString();
        lblagenexec.Text = dslbl.Tables[0].Rows[0].ItemArray[11].ToString();
        //CreditDays.Text = dslbl.Tables[0].Rows[0].ItemArray[7].ToString();
        //Adcat.Text = dslbl.Tables[0].Rows[0].ItemArray[8].ToString();


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

        Ajax.Utility.RegisterTypeForAjax(typeof(Ro_Qbc));

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

        statusbind();
        basedonbind();
       // ddlstatus.Items[0].Selected = true;
        if (!Page.IsPostBack)
        {
            btnNew.Attributes.Add("OnClick", "javascript:return newclick();  ");
            btnCancel.Attributes.Add("OnClick", "javascript:return cancelclick();");
            btnSave.Attributes.Add("OnClick", "javascript:return abcSaveclick();");
            btnModify.Attributes.Add("OnClick", "javascript:return Modify_Records();");
            btnDelete.Attributes.Add("OnClick", "javascript:return Delete_Record();");
            btnQuery.Attributes.Add("OnClick", "javascript:return onquery();");
            btnExecute.Attributes.Add("OnClick", "javascript:return onexecute();");

            btnfirst.Attributes.Add("OnClick", "javascript:return Find_Firstrecord();");
            btnprevious.Attributes.Add("OnClick", "javascript:return Find_PreRecord();");
            btnnext.Attributes.Add("OnClick", "javascript:return Find_NextRecord();");
            btnlast.Attributes.Add("OnClick", "javascript:return Find_Lastrecord();");
            btnExit.Attributes.Add("OnClick", "javascript:return onexit();");
            txtagnm.Attributes.Add("onkeydown", "javascript:return agname(event);");
            lstagn.Attributes.Add("onkeydown", "javascript:return agnamelst(event);");
            lstagn.Attributes.Add("OnClick", "javascript:return agnamelst(event);");

            txtisudt.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            drpagenexec.Attributes.Add("OnChange", "javascript:return chnglabel();");
            //txtfrmno.Attributes.Add("onkeydown", "javascript:return onlynum(event);");
          //  txtlrono.Attributes.Add("onkeydown", "javascript:return onlynum(event);");
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
        //    hidsysdatesql.Value = date;
            hidsysdatesql.Value = day + "/" + month + "/" + year;
            hidsysdate.Value = Convert.ToDateTime(date).ToString("dd-MMMM-yyyy");
        //    date = 12 + "/" + 31 + "/" + 2020;
        //    hiddentodate.Value = Convert.ToDateTime(date).ToString("dd-MMMM-yyyy");
        //    hiddentodatesql.Value = 31 + "/" + 12 + "/" + 2020;
        }
        if (hiddendateformat.Value == "mm/dd/yyyy")
        {
            DateTime sysdate = System.DateTime.Now;
            hur = sysdate.Hour.ToString();
            min = sysdate.Minute.ToString();
            sec = sysdate.Second.ToString();

            time = hur + ":" + min + ":" + sec;
            //DateTime sysdate = System.DateTime.Now;
            day = sysdate.Day.ToString();
            month = sysdate.Month.ToString();
            year = sysdate.Year.ToString();
            if (day.Length < 2)
                day = "0" + day;
            if (month.Length < 2)
                month = "0" + month;

            date = month + "/" + day + "/" + year;

          //  hidsysdatesql.Value = date;
            hidsysdatesql.Value = day + "/" + month + "/" + year;
            hidsysdate.Value = Convert.ToDateTime(date).ToString("MMMM/dd/yyyy");
          //  date = 12 + "/" + 31 + "/" + 2020;
         //   hiddentodate.Value = Convert.ToDateTime(date).ToString("MMMM/dd/yyyy");
        //    hiddentodatesql.Value = 12 + "/" + 31 + "/" + 2020;
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

       //     hidsysdatesql.Value = date;
            hidsysdatesql.Value = day + "/" + month + "/" + year;
            hidsysdate.Value = Convert.ToDateTime(date).ToString("yyyy/MMMM/dd");
         //   date = 12 + "/" + 31 + "/" + 2020;
         //   hiddentodate.Value = Convert.ToDateTime(date).ToString("yyyy/MMMM/dd");
         //   hiddentodatesql.Value = 2020 + "/" + 12 + "/" + 31; ;
        }

    }

    public void statusbind()
    {
        ddlstatus.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/roavqbc.xml"));
      //  ListItem li = new ListItem();
        //li.Text = "-Select Status-";
        //li.Value = "0";
      //  ddlstatus.Items.Add(li);

        for (int i = 0; i < ds1.Tables[1].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            ddlstatus.Items.Add(li1);
        }
      //  ddlstatus.Items.FindByValue("A").Selected = true;
        
    }



    public void basedonbind()
    {
        drpagenexec.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/roavqbc.xml"));
        //  ListItem li = new ListItem();
        //li.Text = "-Select Status-";
        //li.Value = "0";
        //  ddlstatus.Items.Add(li);

        for (int i = 0; i < ds1.Tables[1].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds1.Tables[2].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds1.Tables[2].Rows[0].ItemArray[i].ToString();
            drpagenexec.Items.Add(li1);
        }
        //  ddlstatus.Items.FindByValue("A").Selected = true;

    }


    [Ajax.AjaxMethod]
    public DataSet bindagencyname(string compcode, string userid, string agency)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Roav_qbc bindagenname = new NewAdbooking.Classes.Roav_qbc();

            ds = bindagenname.bindagency(compcode, userid, agency);
           
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Roav_qbc bindagenname = new NewAdbooking.classesoracle.Roav_qbc();

                ds = bindagenname.bindagency(compcode, userid, agency);
                return ds;
            }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet Autogenerate_Code(string namestr, string pcode, string dtformat)
    {
        
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Roav_qbc obj = new NewAdbooking.classesoracle.Roav_qbc();
            ds = obj.Atognrte_Code(pcode, namestr, dtformat);
        }
        //else
        //{
        //    NewAdbooking.Classes.Roav_qbc augen = new NewAdbooking.pam.Classes.Roav_qbc();
        //    ds = augen.Atognrte_Code(pcode);
        //}

        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet Agency_get(string pcode, string subcode)
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Roav_qbc obj = new NewAdbooking.classesoracle.Roav_qbc();
            ds = obj.Agency_get(pcode, subcode);
        }
        else
        {
            NewAdbooking.Classes.Roav_qbc augen = new NewAdbooking.Classes.Roav_qbc();
            ds = augen.Agency_get(pcode,"", subcode);
        }

        return ds;
    }

   /// <summary>
   /// new add///
   /// </summary>
    [Ajax.AjaxMethod]
    public DataSet executive_get(string pcode, string subcode)
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Roav_qbc obj = new NewAdbooking.classesoracle.Roav_qbc();
            ds = obj.executive_get(pcode, subcode);
        }
        else
        {
            NewAdbooking.Classes.Roav_qbc augen = new NewAdbooking.Classes.Roav_qbc();
            ds = augen.Agency_get(pcode, "", subcode);
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
            //else
            //{
            //    NewAdbooking.Classes.Roav_qbc obj = new NewAdbooking.Classes.Roav_qbc();
            //    ds = obj.Modify_tal(mod_tablefields, mod_tablevalue, mod_tablename, mod_action, wherefield, date, extra1, extra2);
            //}
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
        else
        {
            NewAdbooking.Classes.Roav_qbc obj = new NewAdbooking.Classes.Roav_qbc();
            ds = obj.cli_execute(tablename, ex_ficolname, ex_finalval, ex_pre, date, extra1, extra2);
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
            else
            {
                NewAdbooking.Classes.Roav_qbc obj = new NewAdbooking.Classes.Roav_qbc();
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
    public String ro_modify(string compcode,string typ,string agncod,string issdt,string dateformat,string csisno,string ronofrm,string ronotll,string sts,string userid,string currentdate)
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
    public DataSet bindexecname(string compcode, string userid, string executive)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.changeexecutive obj = new NewAdbooking.classesoracle.changeexecutive();
            ds = obj.bindexecutive(compcode,userid,"", executive);
        }
        else
        {
            NewAdbooking.Classes.Roav_qbc augen = new NewAdbooking.Classes.Roav_qbc();
            ds = augen.Agency_get(compcode, "", executive);
        }
        return ds;
    }


}
