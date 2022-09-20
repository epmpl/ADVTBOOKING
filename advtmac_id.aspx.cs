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
public partial class advtmac_id : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        hiddcompname.Value = Session["comp_name"].ToString();
        hiddencomcode.Value = Session["compcode"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddenDateFormat.Value = Session["DateFormat"].ToString();
        hiddenusername.Value = Session["Username"].ToString();
        hdnqbc.Value = Session["revenue"].ToString();
        string extra1 = hdnqbc.Value;
        
       // hdnunit.Value = Session["Username"].ToString();
        txtcompname.Text = hiddcompname.Value;
        txtcompcode.Text = hiddencompcode.Value;
        //btnNew.Focus();


        Ajax.Utility.RegisterTypeForAjax(typeof(advtmac_id));

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



                 DataSet dz = new DataSet();
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
             {
                 NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
                 dz = checkform.formpermission(Session["compcode"].ToString(), Session["userid"].ToString(), "advtmac_id");
             }

             else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {

                 NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();
                 dz = checkform.formpermission(Session["compcode"].ToString(), Session["userid"].ToString(), "advtmac_id");

             }
             else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
             {

                 NewAdbooking.classmysql.Master checkform = new NewAdbooking.classmysql.Master();
                 dz = checkform.formpermission(Session["compcode"].ToString(), Session["userid"].ToString(), "advtmac_id");

             }
           
            // if (dz.Tables[0].Rows.Count > 0)
            // {
            //     hdn_user_right.Value = dz.Tables[0].Rows[0].ItemArray[0].ToString();
            // }
            //else
            // {
            // hdn_user_right.Value = "0";
            //  }
        







        //********************************For Label****************************************/
        DataSet ds = new DataSet();
        // Read in the XML file
        ds.ReadXml(Server.MapPath("XML/advtmac_id.xml"));

        lblcompname.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblcompcode.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbluseridname.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbluseridcode.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblmachinename.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblmachineip.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblmacid.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lblremark.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbllocation.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblfirstname.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbllastname.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lblbranchname.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();

        view10.Text = ds.Tables[1].Rows[0].ItemArray[0].ToString();
        view11.Text = ds.Tables[1].Rows[0].ItemArray[1].ToString();
        view12.Text = ds.Tables[1].Rows[0].ItemArray[2].ToString();
        view13.Text = ds.Tables[1].Rows[0].ItemArray[3].ToString();
        view14.Text = ds.Tables[1].Rows[0].ItemArray[4].ToString();
        view15.Text = ds.Tables[1].Rows[0].ItemArray[5].ToString();
       
        //***************************************************************************

        //****************This is For Button Nevegation On Page Load

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


        txtcompname.Enabled = false;
        txtcompcode.Enabled = false;
        txtuseridname.Enabled = false;
        txtuseridcode.Enabled = false;
        txtmachinename.Enabled = false;
        txtmachineip.Enabled = false;
        txtmacid.Enabled = false;
        txtremark.Enabled = false;
        txtlocation.Enabled = false;




       
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

            btnNew.Attributes.Add("OnClick", "javascript:return atmNewclick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return atmCancelclick('advtmac_id');");
            btnQuery.Attributes.Add("OnClick", "javascript:return atmQueryclick();");
            btnExecute.Attributes.Add("OnClick", "javascript:return atmExecuteclick('execute');");
            btnModify.Attributes.Add("OnClick", "javascript:return atmModifyclick();");
            btnSave.Attributes.Add("onclick", "javascript:return save_process()");
            txtuseridname.Attributes.Add("onkeydown", "javascript:return filluser()");
            lstuser.Attributes.Add("onkeydown", "javascript:return onclickuser()");
            lstuser.Attributes.Add("onclick", "javascript:return onclickuser()");

            btnfirst.Attributes.Add("OnClick", "javascript:return atmfirstclick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return atmpreviousclick();");
            btnnext.Attributes.Add("OnClick", "javascript:return atmnextclick();");
            btnlast.Attributes.Add("OnClick", "javascript:return atmlastclick();");
            btnExit.Attributes.Add("onclick", "javascript:return Exit();");
            Button4.Attributes.Add("onclick", "javascript:return atmExecuteclick('view');");
            btnDelete.Attributes.Add("onclick", "javascript:return Delete_Record();");
           
        
        
        }
    }




    [Ajax.AjaxMethod]
    public DataSet fill_user(string extra1)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.advtmac_id logindetail = new NewAdbooking.classesoracle.advtmac_id();
            ds = logindetail.getUser(extra1);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.advtmac_id logindetail = new NewAdbooking.Classes.advtmac_id();
            ds = logindetail.getUser(extra1);
        }

        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "cir_login_bind_cir_login_bind_P";
            string[] parameterValueArray = { extra1 };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet getfirstlastname(string compcode, string usercode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.advtmac_id login = new NewAdbooking.classesoracle.advtmac_id();
            ds = login.getfirstlastname(compcode, usercode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.advtmac_id login = new NewAdbooking.Classes.advtmac_id();
            ds = login.getfirstlastname(compcode, usercode);
        }
         else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "firstlastname";
            string[] parameterValueArray = { compcode, usercode };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }


        
    [Ajax.AjaxMethod]
    public DataSet savedata(string compcode, string usercode, string machinename, string machineip, string macip, string remark, string location, string username, string extra3)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.advtmac_id login = new NewAdbooking.classesoracle.advtmac_id();
            ds = login.savedata(compcode, usercode, machinename, machineip, macip, remark, location, username);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.advtmac_id login = new NewAdbooking.Classes.advtmac_id();
            ds = login.savedata(compcode, usercode, machinename, machineip, macip, remark, location, username, extra3);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "FA_MACHINE_SECURITY_FA_MACHINE_SECURITY_SAVE";
            string[] parameterValueArray = { compcode, usercode, machinename, machineip, macip, remark, location, username };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    

    
    
    [Ajax.AjaxMethod]
    public DataSet atmexecute(string compcode, string usercode, string machinename, string machineip, string macid, string remark, string location)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.advtmac_id login = new NewAdbooking.classesoracle.advtmac_id();
            ds = login.executedata(compcode, usercode, machinename, machineip, macid, remark, location);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
           NewAdbooking.Classes.advtmac_id login = new NewAdbooking.Classes.advtmac_id();
           ds = login.executedata(compcode, usercode, machinename, machineip, macid, remark, location);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "FA_MACHINE_SECURITY_FA_MACHINE_SECURITY_EXECUTE";
            string[] parameterValueArray = { compcode, usercode, machinename, machineip, macid, remark, location };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;  
    }

    

    [Ajax.AjaxMethod]
    public DataSet datadelete(string compcode,string username,string userid,string machinename,string machineip,string macip,string remark,string location)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.advtmac_id login = new NewAdbooking.classesoracle.advtmac_id();
            ds = login.datadelete(compcode, username, userid, machinename, machineip, macip, remark, location);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.advtmac_id login = new NewAdbooking.Classes.advtmac_id();
            ds = login.datadelete(compcode,  userid, machinename, machineip, macip);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "FA_MACHINE_SECURITY_FA_MACHINE_SECURITY_DELETE";
            string[] parameterValueArray = { compcode, username, userid, machinename, machineip, macip, remark, location };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }




}
