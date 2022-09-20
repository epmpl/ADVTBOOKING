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

public partial class FormSubbmition : System.Web.UI.Page
{
    string formnamevalue;
    string message;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            d1.Text = "<script>alert('session Expired');window.close();</script>";
            return;
        }

        formnamevalue = "FormSubbmition";

        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenauto.Value = Session["autogenerated"].ToString();


        if (Session["autogenerated"].ToString() == "1")
        {

            txtid .Enabled = false;

        }

        
        Ajax.Utility.RegisterTypeForAjax(typeof(FormSubbmition));

       // btnSave.Enabled = false;

        //chkmendetory();

        DataSet objDataSet = new DataSet();
        // Read in the XML file
        objDataSet.ReadXml(Server.MapPath("XML/FormSubbmition.xml"));
        lbformid .Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lbformname.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
         lbalias  .Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
         //btnSave.ImageUrl = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
         //btnNew.ImageUrl = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
         //btnclear.ImageUrl = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
         //btnExit.ImageUrl = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
       lblformtype.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
       lblmodcode.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();

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
       txtname.Enabled = false;
       txtalias.Enabled = false;
       drpformtype.Enabled = false;
       drpmodcode.Enabled = false; 

      // ScriptManager1.SetFocus(btnNew);
        if (!Page.IsPostBack)
        {
           
            btnSave.Attributes.Add("onclick", "javascript:return saveform();");
            btnExit.Attributes.Add("onclick", "javascript:return closeform();");
            txtname.Attributes.Add("OnChange", "javascript:return autogen();");
            btnNew.Attributes.Add("OnClick", "javascript:return btnNewClick2();");
            //btnSave.Attributes.Add("OnClick", "javascript:return saveclick();");
            btnModify.Attributes.Add("OnClick", "javascript:return btnModifyClick2();");
            btnDelete.Attributes.Add("OnClick", "javascript:return btnDeleteClick2();");
            btnQuery.Attributes.Add("OnClick", "javascript:return btnQueryClick2();");
            btnExecute.Attributes.Add("OnClick", "javascript:return btnExecuteClick2();");
            btnCancel.Attributes.Add("OnClick", "javascript:return btnCancelClick2('FormSubbmition');");
            btnfirst.Attributes.Add("OnClick", "javascript:return pubcentfirstclick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return pubcentpreviousclick();");
            btnnext.Attributes.Add("OnClick", "javascript:return pubcentnextclick();");
            btnlast.Attributes.Add("OnClick", "javascript:return pubcatlastclick();");
            bindmodcode();
            

            

        }
    //    if (btnSave.Enabled == false)
    //    btnSave.ImageUrl = objDataSet.Tables[1].Rows[0].ItemArray[0].ToString();
    //    if (btnNew.Enabled == false)
    //    btnNew.ImageUrl = objDataSet.Tables[1].Rows[0].ItemArray[1].ToString();
    //if (btnclear.Enabled == false)
    //    btnclear.ImageUrl = objDataSet.Tables[1].Rows[0].ItemArray[2].ToString();
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
        

    }

    //====================Bind Module Code========================
    public void bindmodcode()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/FormSubbmition.xml"));
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "---Select ModuleCode---";
        li1.Value = "0";
        li1.Selected = true;
        drpmodcode.Items.Add(li1);

        int i;
        for (i = 2; i < ds.Tables[1].Rows[0].ItemArray.Length; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            li.Text = ds.Tables[1].Rows[0].ItemArray[i+1].ToString();
            drpmodcode.Items.Add(li);
            i = i + 1;
        }
    }
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFrchkcodeomResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(FormSubbmition), "ShowAlert", strAlert, true);
    }

    [Ajax.AjaxMethod]

    public DataSet chkcode(string str)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.FormSubbmition auto = new NewAdbooking.classesoracle.FormSubbmition();

            ds = auto.autocode(str);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.FormSubbmition auto = new NewAdbooking.Classes.FormSubbmition();

            ds = auto.autocode(str);
            return ds;
        }
     else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
       {
           string procedureName = "forminsertautocode_forminsertautocode_p";
           NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
           string[] parameterValueArray = { str, str.Substring(0, 2) };
           ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
       }
        return ds;

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        txtalias.Text = "";
        txtname.Text = "";
        txtid.Text = "";


        pnew.Value = "1";

        if (Session["autogenerated"].ToString() == "1")
        {
            txtid.Enabled = false;
        }
        else
        {
            txtid.Enabled = true;
        }
        drpmodcode.Enabled = true;
        txtname.Enabled = true;
        txtalias.Enabled = true;
        drpformtype.Enabled = true;
        btnSave.Enabled = true;
        btnNew.Enabled = false;
        btnimage();
        ScriptManager1.SetFocus(drpformtype);
       // drpformtype.Focus();
        
               
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string sess = Session["compcode"].ToString();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(FormSubbmition), "abc", "alert('session Expired');window.close();", true);

            return;
        }
        string formid = txtid.Text;
        string formname = txtname.Text;
        string formalias = txtalias.Text;
        string formtype = drpformtype.SelectedValue;
        string modulecod = drpmodcode.SelectedValue;
        //if (Session["autogenerated"].ToString() != "1")
        //{
         DataSet ds = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.classesoracle.FormSubbmition checkcode = new NewAdbooking.classesoracle.FormSubbmition();

             ds = checkcode.formcheck(formid, Session["compcode"].ToString());
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Classes.FormSubbmition checkcode = new NewAdbooking.Classes.FormSubbmition();

             ds = checkcode.formcheck(formid, Session["compcode"].ToString());
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
         {
             string procedureName = "forminsertchk_forminsertchk_p";
             NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
             string[] parameterValueArray = { formid, Session["compcode"].ToString() };
             ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
         }

        if (ds.Tables[0].Rows.Count < 0)
        {
            message = "Please Enter The Form Code";
            AspNetMessageBox(message);
            return;
        }

        else
        {
            DataSet ds1 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.FormSubbmition insertform = new NewAdbooking.classesoracle.FormSubbmition();

                ds1 = insertform.forminsert(Session["compcode"].ToString(), formid, formname, formalias, Session["userid"].ToString(), formtype, modulecod);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.FormSubbmition insertform = new NewAdbooking.Classes.FormSubbmition();

                ds1 = insertform.forminsert(Session["compcode"].ToString(), formid, formname, formalias, Session["userid"].ToString(), formtype, modulecod);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "forminsert_forminsert_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { Session["compcode"].ToString(), formid, formname, formalias, formtype, modulecod };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            message = "Data Saved Sucessfully ";
            AspNetMessageBox(message);

            txtalias.Text = "";
            txtname.Text = "";
            txtid.Text = "";
            drpformtype.SelectedValue = "0";
            drpmodcode.SelectedValue = "0";
            //txtalias.Enabled = false;
            //txtname.Enabled = false;
            //txtid.Enabled = false;

            btnSave.Enabled = false;
            btnNew .Enabled = true;
            btnimage();
            return;

            // }

        }
    }
    
    protected void btnclear_Click1(object sender, EventArgs e)
    {
        try
        {
            string sess = Session["compcode"].ToString();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(FormSubbmition), "abc", "alert('session Expired');window.close();", true);

            return;
        }
        txtalias.Text = "";
        txtname.Text = "";
        txtid.Text = "";
        drpformtype.SelectedValue = "0";

        txtalias.Enabled = false;
        txtname.Enabled = false;
        txtid.Enabled = false;
        btnSave.Enabled = false;
        btnNew.Enabled = true;
        drpformtype.Enabled = false;
        btnimage();
        return;
    }
    [Ajax.AjaxMethod]
    public DataSet frmexecute(string compcode, string formtyp,string modulecode,string frmcode,string frmname,string frmalias)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.FormSubbmition exec = new NewAdbooking.Classes.FormSubbmition();

            ds = exec.execform(compcode, formtyp, modulecode, frmcode, frmname, frmalias);


            return ds;

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.FormSubbmition exec = new NewAdbooking.classesoracle.FormSubbmition();

                ds = exec.execform(compcode, formtyp, modulecode, frmcode, frmname, frmalias);

                return ds;

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "formexec";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                //string[] parameterValueArray = { compcode, formtyp, modulecode, frmcode, frmname, frmalias };
                string[] parameterValueArray = { compcode, frmcode, frmname, frmalias, formtyp, modulecode };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                
            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet frmdelete(string compcode,string frmcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.FormSubbmition delet = new NewAdbooking.Classes.FormSubbmition();

            ds = delet.delform(compcode, frmcode);

            return ds;

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.FormSubbmition delet = new NewAdbooking.classesoracle.FormSubbmition();

                ds = delet.delform(compcode, frmcode);

                return ds;

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "formdel";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { compcode, frmcode };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
               
            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet update(string compcode, string formtyp,string modulecode,string frmcode,string frmname,string frmalias)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.FormSubbmition update = new NewAdbooking.Classes.FormSubbmition();

            ds = update.modifydata(compcode, formtyp, modulecode, frmcode, frmname, frmalias);

            return ds;

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.FormSubbmition update = new NewAdbooking.classesoracle.FormSubbmition();

                ds = update.modifydata(compcode, formtyp, modulecode, frmcode, frmname, frmalias);

                return ds;

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "formupdate";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { compcode, formtyp, modulecode, frmcode, frmname, frmalias };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

            }
        return ds;
    }
     public void btnimage()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/button.xml"));
        if (btnNew.Enabled == false)
            btnNew.ImageUrl = ds.Tables[1].Rows[0].ItemArray[0].ToString();
        else
            btnNew.ImageUrl = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        if (btnSave.Enabled == false)
            btnSave.ImageUrl = ds.Tables[1].Rows[0].ItemArray[1].ToString();
        else
            btnSave.ImageUrl = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        if (btnModify.Enabled == false)
            btnModify.ImageUrl = ds.Tables[1].Rows[0].ItemArray[2].ToString();
        else
            btnModify.ImageUrl = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        if (btnQuery.Enabled == false)
            btnQuery.ImageUrl = ds.Tables[1].Rows[0].ItemArray[3].ToString();
        else
            btnQuery.ImageUrl = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        if (btnExecute.Enabled == false)
            btnExecute.ImageUrl = ds.Tables[1].Rows[0].ItemArray[4].ToString();
        else
            btnExecute.ImageUrl = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        if (btnCancel.Enabled == false)
            btnCancel.ImageUrl = ds.Tables[1].Rows[0].ItemArray[5].ToString();
        else
            btnCancel.ImageUrl = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        if (btnfirst.Enabled == false)
            btnfirst.ImageUrl = ds.Tables[1].Rows[0].ItemArray[6].ToString();
        else
            btnfirst.ImageUrl = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        if (btnprevious.Enabled == false)
            btnprevious.ImageUrl = ds.Tables[1].Rows[0].ItemArray[7].ToString();
        else
            btnprevious.ImageUrl = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        if (btnnext.Enabled == false)
            btnnext.ImageUrl = ds.Tables[1].Rows[0].ItemArray[8].ToString();
        else
            btnnext.ImageUrl = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        if (btnlast.Enabled == false)
            btnlast.ImageUrl = ds.Tables[1].Rows[0].ItemArray[9].ToString();
        else
            btnlast.ImageUrl = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        if (btnDelete.Enabled == false)
            btnDelete.ImageUrl = ds.Tables[1].Rows[0].ItemArray[10].ToString();
        else
            btnDelete.ImageUrl = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        if (btnExit.Enabled == false)
            btnExit.ImageUrl = ds.Tables[1].Rows[0].ItemArray[11].ToString();
        else
            btnExit.ImageUrl = ds.Tables[0].Rows[0].ItemArray[11].ToString();
      
    }

}

