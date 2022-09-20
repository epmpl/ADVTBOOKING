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

public partial class Cir_roleMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof (Cir_roleMaster ));
        if(Session ["userid"]==null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
       hdncompcode .Value =Session ["compcode"].ToString ();
       hdncompname .Value =Session ["comp_name"].ToString ();
       hiddendateformat .Value =Session ["dateformat"].ToString ();
       hdnuserid .Value =Session ["userid"].ToString ();
       hdnunit .Value =Session ["center"].ToString ();
       
       txtcompcode.Text = hdncompcode.Value;
       txtcompname.Text = hdncompname.Value;

       DataSet ds = new DataSet();
       ds.ReadXml(Server.MapPath("XML/button.xml"));
       btnNew.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
       btnSave.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
       btnQuery.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
       btnModify.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
       btnExecute.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
       btnCancel.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
       btnfirst.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
       btnprevious.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
       btnnext.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
       btnlast.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
       btnDelete.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
       btnExit.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();

       DataSet ds1 = new DataSet();
       ds1.ReadXml(Server.MapPath("XML/Cir_roleMaster.xml"));
        lblcompcode .Text=ds1.Tables [0].Rows [0].ItemArray [0].ToString ();
        lblcompname .Text=ds1.Tables [0].Rows [0].ItemArray [1].ToString ();
        lblRoleCode .Text=ds1.Tables [0].Rows [0].ItemArray [2].ToString ();
        lblRoleName .Text =ds1.Tables [0].Rows [0].ItemArray [3].ToString ();
        lblLevels .Text=ds1.Tables [0].Rows [0].ItemArray [4].ToString ();
        lblfreezflag.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        string tablename=ds1.Tables [0].Rows [0].ItemArray [6].ToString ();
        tblfields.Value =ds1.Tables [0].Rows [0].ItemArray [7].ToString ();
        executefields.Value =ds1.Tables [0].Rows [0].ItemArray [8].ToString ();
        deltblfields.Value = ds1.Tables[0].Rows[0].ItemArray[9].ToString();


        view10.Text = ds1.Tables[3].Rows[0].ItemArray[0].ToString();
        view11.Text = ds1.Tables[3].Rows[0].ItemArray[1].ToString();
        view12.Text = ds1.Tables[3].Rows[0].ItemArray[2].ToString();
        view13.Text = ds1.Tables[3].Rows[0].ItemArray[3].ToString();
        if (!Page.IsPostBack)
        {
            btnCancel.Attributes.Add("onclick", "javascript:return ClearAll();");
            btnExit.Attributes.Add("onclick", "javascript:return Exit();");
            btnNew.Attributes.Add("onclick", "javascript:return Enableonnew();");
            btnSave.Attributes.Add("onclick", "javascript:return generatecode();");
            btnExecute.Attributes.Add("onclick", "javascript:return EnableExecute();");
            btnQuery.Attributes.Add("onclick", "javascript:return EnabledOnQuery();");
            btnModify.Attributes.Add("onclick", "javascript:return Modify_Records();");
            btnDelete.Attributes.Add("onclick", "javascript:return Delete_Record();");
            btnnext.Attributes.Add("onclick", "javascript:return Find_NextRecord();");
            btnprevious.Attributes.Add("onclick", "javascript:return Find_PreRecord();");
            btnfirst.Attributes.Add("onclick", "javascript:return Find_Firstrecord();");
            btnlast.Attributes.Add("onclick", "javascript:return Find_Lastrecord();");
            Button4.Attributes.Add("onclick", "javascript:return fetchview();");
            bindfreezeflag();
            bindLevels();
            NewAdbooking.classesoracle.Cir_role_mast agmast = new NewAdbooking.classesoracle.Cir_role_mast();
            DataSet ds_table = new DataSet();
            ds_table = agmast.col_width(tablename, "");

            if (ds_table.Tables[0].Rows.Count > 0)
            {
                txtRoleCode.MaxLength = Convert.ToInt16(ds_table.Tables[0].Rows[2].ItemArray[3].ToString());
                txtRoleName.MaxLength = Convert.ToInt16(ds_table.Tables[0].Rows[3].ItemArray[3].ToString());

            }

            //DataSet ds_per = new DataSet();
            //NewAdbooking.classesoracle.cir_permission ls = new NewAdbooking.classesoracle.cir_permission();
            //ds_per = ls.fnd_form_permission(hdncompcode.Value, hdnunit.Value, hdnuserid.Value, "1", "CIR_ROLEMASTER", hiddendateformat.Value, "", "");
            //if (ds_per.Tables[0].Rows.Count > 0)
            //{
            //    hdn_user_right.Value = ds_per.Tables[0].Rows[0].ItemArray[6].ToString();
            //}
            //else
            //{
            //    hdn_user_right.Value = "0";
            //}

        }
       }
    }

    public void bindLevels()
    {
        ddlLevels.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server .MapPath ("XML/Cir_roleMaster.xml"));
        ListItem li = new ListItem();
        li.Text = "Select Level";
        li.Value = "0";
        ddlLevels.Items.Add(li);
        for (int i = 0; i < ds.Tables[2].Columns .Count;i++ )
        {
            ListItem li1 = new ListItem();
            li1.Text=ds.Tables [2].Rows[0].ItemArray [i].ToString ();
            i++;
            li1.Value = ds.Tables[2].Rows[0].ItemArray[i].ToString();
            ddlLevels.Items.Add(li1);
        }
    }
    public void bindfreezeflag()
    {

        drpfreezflag.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/Cir_roleMaster.xml"));
        ListItem li = new ListItem();
        li.Text = "--Select Freeze Flag--";
        li.Value = "0";
        drpfreezflag.Items.Add(li);

        for (int i = 0; i < ds1.Tables[1].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            drpfreezflag.Items.Add(li1);

        }
    }

    [Ajax.AjaxMethod]
    public DataSet generatecode(string compcode,string dateformat,string extra1,string extra2)
    {
        NewAdbooking.classesoracle.Cir_role_mast role = new NewAdbooking.classesoracle.Cir_role_mast();
        DataSet ds = new DataSet();
        ds = role.generateCode(compcode, dateformat, extra1, extra2);
        return ds;
    }

    [Ajax.AjaxMethod]
    public string save_role(string tablefields, string tablevalue, string tablename, string action, string date, string extra1, string extra2)
    {
        NewAdbooking.classesoracle.Cir_role_mast role = new NewAdbooking.classesoracle.Cir_role_mast();
        DataSet ds = new DataSet();
        string result = "";
        try
        {
            result = role.Save_role(tablefields, tablevalue, tablename, action, date, extra1, extra2);
            return result ;
        }
        catch(Exception ex)
        {
            return ex.Message.ToString () ;
        }
    }

    [Ajax.AjaxMethod]
    public DataSet role_execute(string tablename, string ex_ficolname, string ex_finalval, string ex_pre, string date, string extra1, string extra2)
    {
        NewAdbooking.classesoracle.Cir_role_mast role = new NewAdbooking.classesoracle.Cir_role_mast();
        DataSet ds = new DataSet();
        ds = role.execute_role(tablename, ex_ficolname, ex_finalval, ex_pre, "", "", "");
        return ds;
    }

    [Ajax.AjaxMethod]
    public string role_modify(string mod_tablefields, string mod_tablevalue, string mod_tablename, string mod_action, string wherefield, string date, string extra1, string extra2)
    {
        NewAdbooking.classesoracle.Cir_role_mast role = new NewAdbooking.classesoracle.Cir_role_mast();
        DataSet ds = new DataSet();
        string result = "";
        try
        {
           result  = role.Modify_role(mod_tablefields, mod_tablevalue, mod_tablename, mod_action, wherefield, date, extra1, extra2);
            return result ;
        }
        catch(Exception ex)
        {
            return ex.Message.ToString ();
        }
    }

    [Ajax.AjaxMethod]
    public DataSet role_delete(string del_tabname, string del_colname, string del_colval, string del_action, string date, string extra1, string extra2)
    {
        NewAdbooking.classesoracle.Cir_role_mast role = new NewAdbooking.classesoracle.Cir_role_mast();
        DataSet ds = new DataSet();
        ds = role.delete_role(del_tabname, del_colname, del_colval, del_action, date, extra1, extra2);
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet role_allviews(string compcode,string unitocde, string date, string extra1, string extra2)
    {
        NewAdbooking.classesoracle.Cir_role_mast role = new NewAdbooking.classesoracle.Cir_role_mast();
        DataSet ds = new DataSet();
        ds = role.bind_all_role(compcode,unitocde,date,extra1,extra2);
        return ds;
    }
}
