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

public partial class Userpermission : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddenuserhome.Value=Session["userhome"].ToString();
            hiddenrevenue.Value = Session["Revenue"].ToString();
            hiddenadmin.Value = Session["Admin"].ToString();
        }

        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;

        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Userpermission));

        //*********************************For Lables***************************
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Userpermission.xml"));
        lbluserid.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblsched.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblrole.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblfrom_osbal.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblto_osbal.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblno_times.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblperiod.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        //***********************************************************************//
        //*****************Code For Read the data from xml File******************//
        //*******************************For The Button**************************//
        //***********************************************************************//
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
        drpuserid.Enabled = true;
        drpuserid.Focus();
        drpschedule.Enabled = false;
        if (!Page.IsPostBack)
        {
            //btnNew.Attributes.Add("OnClick", "javascript:return btnNewClick2();");
            savebutton.Attributes.Add("OnClick", "javascript:return saveclick();");
            //btnModify.Attributes.Add("OnClick", "javascript:return btnModifyClick2();");
            //btnDelete.Attributes.Add("OnClick", "javascript:return btnDeleteClick2();");
            //btnQuery.Attributes.Add("OnClick", "javascript:return btnQueryClick2();");
            //btnExecute.Attributes.Add("OnClick", "javascript:return btnExecuteClick2();");
            //btnCancel.Attributes.Add("OnClick", "javascript:return btnCancelClick2('Userpermission');");
            //btnfirst.Attributes.Add("OnClick", "javascript:return firstclick();");
            //btnprevious.Attributes.Add("OnClick", "javascript:return previousclick();");
            //btnnext.Attributes.Add("OnClick", "javascript:return nextclick();");
            //btnlast.Attributes.Add("OnClick", "javascript:return lastclick();");
            //btnExit.Attributes.Add("OnClick", "javascript:return exitclick();");
            //btnDelete.Attributes.Add("OnClick", "javascript:return deleteclick();");
            drpuserid.Attributes.Add("onkeydown", "javascript:return binduser(event);");
            lst_user.Attributes.Add("onclick", "javascript:return filluser(event);");
            lst_user.Attributes.Add("onkeydown", "javascript:return filluser(event);");

            btncopy.Attributes.Add("onclick","javascript:return Copyfield();");
            btndel.Attributes.Add("onclick", "javascript:return removefieldname();");
            btncopyall.Attributes.Add("onclick", "javascript:return Copyall();");
            btndelall.Attributes.Add("onclick", "javascript:return removeallfieldname();");
            listbox1.Attributes.Add("onchange", "javascript:return showdetail(this.id);");
            listbox2.Attributes.Add("onchange", "javascript:return showdetail(this.id);");
            drpuserid.Attributes.Add("onblur","javascript:return filluser_permission();");
           // binduser();
            bindlistbox1();
        }
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
        
    }
//=====Bind User===========//
/*public void binduser()
{
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop MastPrev = new NewAdbooking.Classes.pop();
            ds1 = MastPrev.MastPrevDisp(Session["compcode"].ToString(), Session["userid"].ToString(), Session["userhome"].ToString(), Session["Admin"].ToString(),Session["Revenue"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop MastPrev = new NewAdbooking.classesoracle.pop();
            ds1 = MastPrev.MastPrevDisp(Session["compcode"].ToString(), Session["userid"].ToString(), Session["userhome"].ToString(), Session["Admin"].ToString(), Session["Revenue"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.pop MastPrev = new NewAdbooking.classmysql.pop();
            ds1 = MastPrev.MastPrevDisp(Session["compcode"].ToString(), Session["userid"].ToString(), Session["userhome"].ToString(), Session["Admin"].ToString());
        }
        

        drpuserid.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select";
        li1.Value = "0";
        li1.Selected = true;
        drpuserid.Items.Add(li1);

        //ds=MastPrev.MastPrevDisp();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
               // if (Session["userhome"].ToString() == "Agency" && Session["Admin"].ToString() == "yes")
                if (Session["Admin"].ToString() == "yes")
                {
                    li.Text = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
                    li.Value = ds1.Tables[0].Rows[i].ItemArray[1].ToString();
                    drpuserid.Items.Add(li);
                }
                else
                {
                    if (ds1.Tables[0].Rows[i].ItemArray[2].ToString() == "" && ds1.Tables[0].Rows[i].ItemArray[3].ToString() == "Agency")
                    { }
                    else
                    {
                        li.Text = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
                        li.Value = ds1.Tables[0].Rows[i].ItemArray[1].ToString();
                        drpuserid.Items.Add(li);
                    }
                }
                //user=li.Value=ds1.Tables[0].Rows[i].ItemArray[1].ToString();
                //li1.Selected =true;
                

            }
            drpuserid.DataBind();
        }
    }*/

    public void bindlistbox1()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Userpermission.xml"));
        listbox1.Items.Clear();
        int i;

        for (i = 0; i < ds.Tables[1].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
          //  i = i + 1;
            li.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            listbox1.Items.Add(li);

        }
    }


    [Ajax.AjaxMethod]
    public DataSet UserBind(string compcode,string userid,string userhome,string revenue,string admin)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop MastPrev = new NewAdbooking.Classes.pop();
            ds1 = MastPrev.MastPrevDisp(compcode, userid, userhome, admin, revenue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop MastPrev = new NewAdbooking.classesoracle.pop();
            ds1 = MastPrev.MastPrevDisp(compcode, userid, userhome, admin, revenue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "WESP_MODULTPREVDISP_wesp_modultprevdisp_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, userid, userhome, admin, revenue ,"",""};
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds1;
    }

    [Ajax.AjaxMethod]
    public DataSet chkuser(string compcode, string user)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Userpermission chkuser = new NewAdbooking.Classes.Userpermission();

            ds = chkuser.userchk(compcode, user);

            return ds;

        }
        else
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Userpermission chkuser = new NewAdbooking.classesoracle.Userpermission();

            ds = chkuser.userchk(compcode, user);

            return ds;

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "chkuserforper";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, user };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            return ds;
        }
        return ds;
}
[Ajax.AjaxMethod]
    public DataSet persave(string compcode, string userid, string schedule, string loguser, string permission_desc, string delflag, string keyboard, string keyboardtype)
{
    DataSet ds = new DataSet();
    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    {
        NewAdbooking.Classes.Userpermission save = new NewAdbooking.Classes.Userpermission();
        ds = save.savedata(compcode, userid, schedule, loguser, permission_desc, delflag, keyboard, keyboardtype);
        return ds;
    }
    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    {
        NewAdbooking.classesoracle.Userpermission save = new NewAdbooking.classesoracle.Userpermission();
        ds = save.savedata(compcode, userid, schedule, loguser, permission_desc, delflag, keyboard, keyboardtype);
        return ds;
    }
    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
    {
        //string procedureName = "chkuserforper";
        string procedureName = "saveuserforper";
        NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
        string[] parameterValueArray = { compcode, userid, schedule, loguser, permission_desc, delflag, keyboard, keyboardtype };
        ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        return ds;
    }
    return ds;
}

  [Ajax.AjaxMethod]
  public DataSet  persave_detail(string user,string permission_desc,string from_osbal,string to_osbal,string no_oftimes,string period,string allow_flag,string loguser)
  {
     DataSet ds = new DataSet();
    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    {
        NewAdbooking.Classes.Userpermission exec = new NewAdbooking.Classes.Userpermission();
        ds = exec.save_perdetail(user, permission_desc, from_osbal, to_osbal, no_oftimes, period, allow_flag, loguser);
        return ds;

    }
    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    {
        NewAdbooking.classesoracle.Userpermission exec = new NewAdbooking.classesoracle.Userpermission();
        ds = exec.save_perdetail(user, permission_desc, from_osbal, to_osbal, no_oftimes, period, allow_flag, loguser);
        return ds;
    }
    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
    {
        string procedureName = "saveuserfor_perdetail";
        NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
        string[] parameterValueArray = { user, permission_desc, from_osbal, to_osbal, no_oftimes, period, allow_flag, loguser };
        ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        return ds;
    }
    return ds;
  }
 

[Ajax.AjaxMethod]
public DataSet executeuser(string compcode, string user, string schedule)
{
    DataSet ds = new DataSet();
    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    {
        NewAdbooking.Classes.Userpermission exec = new NewAdbooking.Classes.Userpermission();
        ds = exec.execuser(compcode, user, schedule);
        return ds;

    }
    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    {
        NewAdbooking.classesoracle.Userpermission exec = new NewAdbooking.classesoracle.Userpermission();
        ds = exec.execuser(compcode, user, schedule);
        return ds;
    }
    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
    {
        string procedureName = "execuserforper";
        NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
        string[] parameterValueArray = { compcode, user, schedule };
        ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        return ds;
    }
    return ds;
}
[Ajax.AjaxMethod]
public DataSet update(string compcode,string user,string schedule)
{
    DataSet ds = new DataSet();
    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    {
        NewAdbooking.Classes.Userpermission modify = new NewAdbooking.Classes.Userpermission();

        ds = modify.modifydata(compcode, user, schedule);

        return ds;

    }
    else
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Userpermission modify = new NewAdbooking.classesoracle.Userpermission();

            ds = modify.modifydata(compcode, user, schedule);

            return ds;

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "updateuserforper";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, user, schedule };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            return ds;
        }
    return ds;
}
[Ajax.AjaxMethod]
public DataSet userdelete(string compcode, string user)
{
    DataSet ds = new DataSet();
    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    {
        NewAdbooking.Classes.Userpermission del = new NewAdbooking.Classes.Userpermission();

        ds = del.deletedata(compcode, user);

        return ds;

    }
    else
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Userpermission del = new NewAdbooking.classesoracle.Userpermission();

            ds = del.deletedata(compcode, user);

            return ds;

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "updateuserforper";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, user };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            return ds;
        }
    return ds;
}


[Ajax.AjaxMethod]
public DataSet get_username(string userid)
{
    DataSet ds = new DataSet();
    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    {
        NewAdbooking.Classes.Userpermission del = new NewAdbooking.Classes.Userpermission();
        ds = del.get_username(userid);
        
    }
    else  if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    {
        NewAdbooking.classesoracle.Userpermission del = new NewAdbooking.classesoracle.Userpermission();
        ds = del.get_username(userid);
       
    }
    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
    {
        
        string procedureName = "cir_get_login";
        NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
        string[] parameterValueArray = { userid };
        ds = obj.BindCommanFunction(procedureName, parameterValueArray);
    }
    return ds;
 }
    
    [Ajax.AjaxMethod]
    public DataSet Get_Rolename(string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Userpermission del = new NewAdbooking.Classes.Userpermission();
            ds = del.Get_Rolename(userid);
          
        }
        else  if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Userpermission del = new NewAdbooking.classesoracle.Userpermission();
            ds = del.Get_Rolename(userid);
           
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {

            string procedureName = "cir_get_login";
            NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
            string[] parameterValueArray = { userid };
            ds = obj.BindCommanFunction(procedureName, parameterValueArray);
        }
        return ds;
     }

   [Ajax.AjaxMethod]
    public DataSet Fetchuser_permission(string userid,string compcode,string login_userid,string per_desc)
   {
          DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Userpermission del = new NewAdbooking.Classes.Userpermission();
            ds = del.filluser_permission(userid, compcode, login_userid, per_desc);
          
        }
        else  if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Userpermission del = new NewAdbooking.classesoracle.Userpermission();
            ds = del.filluser_permission(userid, compcode, login_userid, per_desc);
            
           
        }
       else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "fill_userpermission";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { userid, compcode, login_userid, per_desc };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            return ds;
        }
        return ds;
   }
}
