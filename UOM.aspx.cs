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

public partial class UOM : System.Web.UI.Page
{
    string client;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
        Response.Expires = -1;
        // Page.RegisterClientScriptBlock("getPermission('UOM')", treeLibrary.js);
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddenauto.Value = Session["autogenerated"].ToString();


        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        ip1.Value = Request.ServerVariables["REMOTE_ADDR"];
        //if (Request.QueryString["index"].ToString() == "1")
        //{
        //    client = Request.QueryString["formname"].ToString();
        //    submitpermission1();

        //}
        navigation();
        Ajax.Utility.RegisterTypeForAjax(typeof(UOM));
        hiddenusername.Value = Session["Username"].ToString();
        //Ajax.Utility.RegisterTypeForAjax(typeof(ClientMaster));



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
        ds.ReadXml(Server.MapPath("XML/UOM.xml"));

        Label1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        Label2.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        Label3.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbtype.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbladtype.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbSampleImg.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbStyleSheet.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
       


      
        lbaddesc.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();

       
        lblogo.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        logouom.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lblcolumn.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lblguttwid.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lblcolwid.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lblsrvcacc.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lblsubsrvacc.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();

        if (!Page.IsPostBack)
        {
            binduomtype();
            //bindlogoname();
            btnNew.Attributes.Add("OnClick", "javascript:return newclick();");
            btnModify.Attributes.Add("OnClick", "javascript:return modifyclick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return queryclick();");
            btnExecute.Attributes.Add("OnClick", "javascript:return executeclick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return cancelclick('UOM');");
            btnExit.Attributes.Add("OnClick", "javascript:return exitclick();");
            btnSave.Attributes.Add("OnClick", "javascript:return saveclick();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstclick();");
            btnlast.Attributes.Add("OnClick", "javascript:return lastclick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return previousclick();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextclick();");
            btnDelete.Attributes.Add("OnClick", "javascript:return deleteclick();");
            txtuomcode.Attributes.Add("OnChange", "javascript:return uppercase('txtuomcode');");
            txtuomdesc.Attributes.Add("OnBlur", "javascript:return autoornot();");
            txtsrvcacc.Attributes.Add("onkeydown", "javascript:return fillservicecode(event);");
            lstservicecode.Attributes.Add("onkeydown", "javascript:return onclickservice(event);");
            lstservicecode.Attributes.Add("onclick", "javascript:return onclickservice(event);");


            txtsubsrvcacc.Attributes.Add("onkeydown", "javascript:return fillsubservicecode(event);");
            lstsubservicecode.Attributes.Add("onkeydown", "javascript:return onclicksubservice(event);");
            lstsubservicecode.Attributes.Add("onclick", "javascript:return onclicksubservice(event);");
            txtalias.Attributes.Add("OnChange", "javascript:return uppercase('txtalias');");
            bindAdType(Session["compcode"].ToString());
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
        btnNew.Focus();
    }

    /*new change ankur 22 feb */
    //public void bindlogoname()
    //{
    //    DataSet cardtyp = new DataSet();
    //    cardtyp.ReadXml(Server.MapPath("XML/uomType.xml"));
    //    txtlogouom.Items.Clear();
    //    int i;
    //    ListItem li1;
    //    li1 = new ListItem();
    //    li1.Text = "Select Logo Uom";
    //    li1.Value = "0";
    //    //li1.Selected = true;
    //    txtlogouom.Items.Add(li1);

    //    for (i = 0; i < cardtyp.Tables[0].Columns.Count - 1; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = cardtyp.Tables[0].Rows[0].ItemArray[i].ToString();
    //        i = i + 1;
    //        li.Value = cardtyp.Tables[0].Rows[0].ItemArray[i].ToString();

    //        txtlogouom.Items.Add(li);

    //    }

    //}


    /*new change ankur 16 feb*/
    public void binduomtype()
    {

        DataSet cardtyp = new DataSet();
        cardtyp.ReadXml(Server.MapPath("XML/uomType.xml"));
        drpaddesc.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Uom Type";
        li1.Value = "0";
        //li1.Selected = true;
        drpaddesc.Items.Add(li1);

        for (i = 0; i < cardtyp.Tables[0].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = cardtyp.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = cardtyp.Tables[0].Rows[0].ItemArray[i].ToString();

            drpaddesc.Items.Add(li);

        }


    }

    [Ajax.AjaxMethod]
    public DataSet fill_subService(string pcompcode, string pssac_code, string psac_code, string pssac_name, string pcode, string pfreez_flag, string pcreated_by, string pdateformat, string ptrn_type, string extra1, string extra2, string extra3, string extra4, string extra5, string extra6, string extra7, string extra8, string extra9, string extra10)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { pcompcode, pssac_code, psac_code, pssac_name, pcode, pfreez_flag, pcreated_by, pdateformat, ptrn_type, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10 };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "fa_sub_sac_ins_upd_del";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "fa_sub_sac_ins_upd_del";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "fa_sub_sac_ins_upd_del";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet fill_Service(string pcompcode, string psac_code, string psac_name, string pcreated_by, string pcode, string pfreez_flag, string pdateformat, string ptrn_type, string extra1, string extra2, string extra3, string extra4, string extra5, string extra6, string extra7, string extra8, string extra9, string extra10)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { pcompcode, psac_code, psac_name, pcreated_by, pcode, pfreez_flag, pdateformat, ptrn_type, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10 };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "fa_sac_ins_upd_del";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "fa_sac_ins_upd_del";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "fa_sac_ins_upd_del";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }


    public void bindAdType(string compcode)
    {DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
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
        li1.Text = "Select Ad Type";
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
    #region Web Form Designer generated code
     protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {

    }
    #endregion


    //		public DataSet checkuom(string pagecode,string compcode,string userid)
    [Ajax.AjaxMethod]
    public DataSet checkuom(string pagecode,string txtuomdesc, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.UOM check = new NewAdbooking.Classes.UOM();
          
            ds = check.checkuomcode(pagecode,txtuomdesc, compcode, userid);


            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.UOM check = new NewAdbooking.classesoracle.UOM();

                ds = check.checkuomcode(pagecode,txtuomdesc, compcode, userid);


                return ds;
            }
        else
        {
            NewAdbooking.classmysql.UOM check = new NewAdbooking.classmysql.UOM();

            ds = check.checkuomcode(pagecode, txtuomdesc, compcode, userid);


            return ds;

        }


    }

        
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]  
    public DataSet insert(string txtuomcode, string txtuomdesc, string txtalias, string compcode, string userid, string txtuomtype, string adtype, string sampleimg, string stylesheet,string uom_desc,string logo,string logouom, string ip, string column, string gutwidth, string colwidth, string acc_cd, string sacc_cd)
    {
        DataSet ds = new DataSet();
        string err = "";
        try
        {

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.UOM insertuom = new NewAdbooking.Classes.UOM();
                ds = insertuom.insertinuom(txtuomcode, txtuomdesc, txtalias, compcode, userid, txtuomtype, adtype, sampleimg, stylesheet, uom_desc, logo, logouom, column, gutwidth, colwidth, acc_cd, sacc_cd);

            }

            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.UOM insertuom = new NewAdbooking.classesoracle.UOM();
                    ds = insertuom.insertinuom(txtuomcode, txtuomdesc, txtalias, compcode, userid, txtuomtype, adtype, sampleimg, stylesheet, uom_desc, logo, logouom, column, gutwidth, colwidth, acc_cd, sacc_cd);

                }
                else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
                {
                    string procedureName = "insertuom_insertuom_p";
                    string[] parameterValueArray = { compcode, userid, txtuomcode, txtuomdesc, txtalias, txtuomtype, adtype, sampleimg, stylesheet, uom_desc, logo, logouom, column, gutwidth, colwidth, acc_cd, sacc_cd };
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                }                

        }
        catch (Exception e)
        {
            err = e.Message;
        }
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new (DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + HttpContext.Current.Session["userid"] + "','UOM','" + err.Replace("'", "''") + "','UOM Creation','" + txtuomdesc;
        sqldd = sqldd + "',";
        sqldd = sqldd + "'" + ip + "')";
        dconnect.executenonquery1(sqldd);
        return ds;
    }
       

    [Ajax.AjaxMethod]
    //public DataSet execute(string txtuomcode, string txtuomdesc, string txtalias, string compcode, string userid, string adtype, string uomtype)
    public DataSet execute(string compcode, string userid, string txtuomcode, string txtuomdesc, string txtalias, string adtype, string uomtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.UOM execute1 = new NewAdbooking.Classes.UOM();
            ds = execute1.executeuom(compcode, userid, txtuomcode, txtuomdesc, txtalias, adtype, uomtype);
            return ds;
        }
            else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.UOM execute1 = new NewAdbooking.classesoracle.UOM();
                ds = execute1.executeuom(compcode, userid, txtuomcode, txtuomdesc, txtalias, adtype, uomtype);
                return ds;

            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, userid, txtuomcode, txtuomdesc, txtalias, adtype, uomtype };
                string procedureName = "executeuom_executeuom_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                return ds;
            }


    }   

    [Ajax.AjaxMethod]
    public DataSet first()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.UOM firstuom = new NewAdbooking.Classes.UOM();
           
            ds = firstuom.firstquery();


            return ds;
        }
            else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.UOM firstuom = new NewAdbooking.classesoracle.UOM();

                ds = firstuom.firstquery();


                return ds;
            }
            else
            {
                NewAdbooking.classmysql.UOM firstuom = new NewAdbooking.classmysql.UOM();

                ds = firstuom.firstquery();


                return ds;
            }


    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    //		public DataSet update(string txtuomcode,string txtuomdesc,string txtalias,string compcode,string userid)
        /*new change ankur 16 feb*/
        /*new change ankur 19 feb*/
    public DataSet update(string txtuomcode, string txtuomdesc, string txtalias, string compcode, string userid, string txtuomtype, string adtype, string sampleimg, string stylesheet,string uom_desc,string logo,string logouom, string ip ,string column,string gutwidth,string colwidth, string acc_cd, string sacc_cd)
    {
        DataSet ds = new DataSet();
         string err = "";
         try
         {

             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
             {

                 NewAdbooking.Classes.UOM update1 = new NewAdbooking.Classes.UOM();

                 ds = update1.updaetcode(txtuomcode, txtuomdesc, txtalias, compcode, userid, txtuomtype, adtype, sampleimg, stylesheet, uom_desc, logo, logouom,column, gutwidth, colwidth, acc_cd, sacc_cd);


                 //return ds;
             }
             else
                 if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                 {

                     NewAdbooking.classesoracle.UOM update1 = new NewAdbooking.classesoracle.UOM();

                     ds = update1.updaetcode(txtuomcode, txtuomdesc, txtalias, compcode, userid, txtuomtype, adtype, sampleimg, stylesheet, uom_desc, logo, logouom, column, gutwidth, colwidth, acc_cd, sacc_cd);


                   //  return ds;
                 }
                 else
                 {
                     string[] parameterValueArray = new string[] { compcode, userid, txtuomcode, txtuomdesc, txtalias, txtuomtype, adtype, sampleimg, stylesheet, uom_desc, logouom, logo, column, gutwidth, colwidth, acc_cd, sacc_cd };
                     string procedureName = "updateuom_updateuom_p";
                     NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                     ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                     /*
                     NewAdbooking.classmysql.UOM update1 = new NewAdbooking.classmysql.UOM();

                     ds = update1.updaetcode(txtuomcode, txtuomdesc, txtalias, compcode, userid, txtuomtype, adtype, sampleimg, stylesheet, uom_desc, logo, logouom, column, gutwidth, colwidth, acc_cd, sacc_cd);
                     */

                     //return ds;
                 }
         }
         catch (Exception e)
         {
             err = e.Message;
         }

         clsconnection dconnect = new clsconnection();
         string sqldd = "insert into log_new (DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + HttpContext.Current.Session["userid"] + "','UOM','" + err.Replace("'", "''") + "','UOM Updation','" + txtuomdesc;
         sqldd = sqldd + "',";
         sqldd = sqldd + "'" + ip + "')";
         dconnect.executenonquery1(sqldd);
         return ds;

    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    //		public DataSet deleteit(string txtuomcode,string compcode,string userid)
     public DataSet deleteit(string txtuomcode, string compcode, string userid, string ip)
    {
        DataSet ds = new DataSet();
         string err = "";
         try
         {
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
             {

                 NewAdbooking.Classes.UOM delete = new NewAdbooking.Classes.UOM();

                 ds = delete.deleteuom(txtuomcode, compcode, userid);


                 //  return ds;
             }
             else
                 if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                 {
                     NewAdbooking.classesoracle.UOM delete = new NewAdbooking.classesoracle.UOM();

                     ds = delete.deleteuom(txtuomcode, compcode, userid);


                     //    return ds;
                 }
                 else
                 {
                     NewAdbooking.classmysql.UOM delete = new NewAdbooking.classmysql.UOM();

                     ds = delete.deleteuom(txtuomcode, compcode, userid);


                     //  return ds;
                 }

         }
         catch (Exception e)
         {
             err = e.Message;
         }
         clsconnection dconnect = new clsconnection();
         string sqldd = "insert into log_new (DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + HttpContext.Current.Session["userid"] + "','UOM','" + err.Replace("'", "''") + "','UOM Deletion','" + txtuomdesc;
         sqldd = sqldd + "',";
         sqldd = sqldd + "'" + ip + "')";
         dconnect.executenonquery1(sqldd);
         return ds;

    }
    //		public void navigation()
     public void navigation()
    {
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

    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet chkuomcode(string str)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.UOM chk = new NewAdbooking.Classes.UOM();
            
            ds = chk.countuomcode(str,Session["compcode"].ToString());
            return ds;
        }
            else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.UOM chk = new NewAdbooking.classesoracle.UOM();

                ds = chk.countuomcode(str, Session["compcode"].ToString());
                return ds;


            }
            else
            {
                NewAdbooking.classmysql.UOM chk = new NewAdbooking.classmysql.UOM();

                ds = chk.countuomcode(str);
                return ds;

            }

    }

    public void submitpermission1()
    {
        DataSet dz = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
            
            dz = checkform.formpermissionall(Session["compcode"].ToString(), Session["userid"].ToString(), client);
        }
            else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();

                dz = checkform.formpermissionall(Session["compcode"].ToString(), Session["userid"].ToString(), client);

            }
            else
            {
                NewAdbooking.classmysql.Master checkform = new NewAdbooking.classmysql.Master();

                dz = checkform.formpermissionall(Session["compcode"].ToString(), Session["userid"].ToString(), client);

            }
        
    }
    [Ajax.AjaxMethod]

    public DataSet submitpermission(string hiddencompcode, string hiddenuserid, string formname)
    {
        DataSet dz = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
            
            dz = checkform.formpermission(hiddencompcode, hiddenuserid, formname);
            return dz;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                 NewAdbooking.classesoracle .Master checkform = new NewAdbooking.classesoracle.Master();
            
            dz = checkform.formpermission(hiddencompcode, hiddenuserid, formname);
            return dz;
            }
        else
        {
            NewAdbooking.classmysql.Master checkform = new NewAdbooking.classmysql.Master();

            dz = checkform.formpermission(hiddencompcode, hiddenuserid, formname);
            return dz;
        }
    }
    protected void txtalias_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
}