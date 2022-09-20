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

public partial class LanguageMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddenauto.Value = Session["autogenerated"].ToString();


        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }


        Ajax.Utility.RegisterTypeForAjax(typeof(LanguageMaster));


        btnNew.Focus();


        //////////////////////
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
        ds.ReadXml(Server.MapPath("XML/LanguageMaster.xml"));

        Label1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        Label2.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        Label3.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
       
        
        hiddenusername.Value = Session["username"].ToString();


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

        txtLangCode.Enabled = false;
        txtLangName.Enabled = false;
        txtAlias.Enabled = false;

        // Put user code to initialize the page here

        if (!Page.IsPostBack)
        {
            btnNew.Attributes.Add("OnClick", "javascript:return LangNewClick();");
            btnSave.Attributes.Add("OnClick", "javascript:return LangSaveClick();");
            btnModify.Attributes.Add("OnClick", "javascript:return LangModifyClick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return LangQueryClick();");
            btnExecute.Attributes.Add("OnClick", "javascript:return LangExecuteClick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return LangCancelClick('LanguageMaster');");
            btnfirst.Attributes.Add("OnClick", "javascript:return LangFirstClick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return LangPreviousClick();");
            btnnext.Attributes.Add("OnClick", "javascript:return LangNextClick();");
            btnlast.Attributes.Add("OnClick", "javascript:return LangLastClick();");
            btnDelete.Attributes.Add("OnClick", "javascript:return LangdeleteClick();");
            btnExit.Attributes.Add("OnClick", "javascript:return LangExitClick();");
            txtLangName.Attributes.Add("OnBlur", "javascript:return autoornot();");
          
            txtAlias.Attributes.Add("OnBlur", "javascript:return ClientUpperCase1('txtAlias');");
            txtLangCode.Attributes.Add("OnBlur", "javascript:return ClientUpperCase1('txtLangCode');");
            //txtLangName.Attributes.Add("OnBlur", "javascript:return ClientUpperCase('txtLangName');");

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
        // Put user code to initialize the page here
    }
    [Ajax.AjaxMethod]
    //		public DataSet modify(string LangCode,string LangName,string Alias,string compcode,string userid)
     public DataSet modify(string LangCode, string LangName, string Alias, string compcode, string userid)
     {
         DataSet ds = new DataSet();
        if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.LanguageMaster modify = new NewAdbooking.Classes.LanguageMaster();
        
        ds = modify.ModifyValue(LangCode, LangName, Alias, compcode, userid);
        return ds;
        }

        else
            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="orcl")
            {
                NewAdbooking.classesoracle.LanguageMaster modify = new NewAdbooking.classesoracle.LanguageMaster();

                ds = modify.ModifyValue(LangCode, LangName, Alias, compcode, userid);
                return ds;
            }


        else
        {
            NewAdbooking.classmysql.LanguageMaster modify = new NewAdbooking.classmysql.LanguageMaster();

            ds = modify.ModifyValue(LangCode, LangName, Alias, compcode, userid);
            return ds;
        }
    }

    [Ajax.AjaxMethod]
    //		public DataSet insert(string LangCode,string LangName,string Alias,string compcode,string userid)
     public DataSet insert(string LangCode, string LangName, string Alias, string compcode, string userid)
     {
         DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.LanguageMaster insert = new NewAdbooking.Classes.LanguageMaster();
          
            ds = insert.InsertValue(LangCode, LangName, Alias, compcode, userid);
            return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.LanguageMaster insert = new NewAdbooking.classesoracle.LanguageMaster();

                ds = insert.InsertValue(LangCode, LangName, Alias, compcode, userid);
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.LanguageMaster insert = new NewAdbooking.classmysql.LanguageMaster();

            ds = insert.InsertValue(LangCode, LangName, Alias, compcode, userid);
            return ds;
        }
    }

    [Ajax.AjaxMethod]
    //		public DataSet Select(string LangCode,string LangName,string Alias,string compcode,string userid)
     public DataSet Select(string LangCode, string LangName, string Alias, string compcode, string userid)
     {
         DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.LanguageMaster select = new NewAdbooking.Classes.LanguageMaster();
            
            ds = select.SelectValue(LangCode, LangName, Alias, compcode, userid);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.LanguageMaster select = new NewAdbooking.classesoracle.LanguageMaster();

                ds = select.SelectValue(LangCode, LangName, Alias, compcode, userid);
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.LanguageMaster select = new NewAdbooking.classmysql.LanguageMaster();

            ds = select.SelectValue(LangCode, LangName, Alias, compcode, userid);
            return ds;
        }
    }

    [Ajax.AjaxMethod]
    //		public DataSet Selectfnpl(string LangCode,string LangName,string Alias,string compcode,string userid)
     public DataSet Selectfnpl(string LangCode, string LangName, string Alias, string compcode, string userid)
     {
         DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.LanguageMaster select = new NewAdbooking.Classes.LanguageMaster();
            
            ds = select.Selectfnpl(LangCode, LangName, Alias, compcode, userid);
            return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.LanguageMaster select = new NewAdbooking.classesoracle.LanguageMaster();

                ds = select.Selectfnpl(LangCode, LangName, Alias, compcode, userid);
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.LanguageMaster select = new NewAdbooking.classmysql.LanguageMaster();

            ds = select.Selectfnpl(LangCode, LangName, Alias, compcode, userid);
            return ds;
        }

    }

    [Ajax.AjaxMethod]
    //		public DataSet deletelang(string LangCode,string compcode,string userid)
     public DataSet deletelang(string LangCode, string compcode, string userid)
     {
         DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.LanguageMaster check = new NewAdbooking.Classes.LanguageMaster();
            
            da = check.DeleteValue(LangCode, compcode, userid);
            return da;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.LanguageMaster check = new NewAdbooking.classesoracle.LanguageMaster();

                da = check.DeleteValue(LangCode, compcode, userid);
                return da;
            }
        else
        {
            NewAdbooking.classmysql.LanguageMaster check = new NewAdbooking.classmysql.LanguageMaster();

            da = check.DeleteValue(LangCode, compcode, userid);
            return da;

        }

    }

    [Ajax.AjaxMethod]
    //		public DataSet checklangcode(string LangCode,string compcode,string userid)
     public DataSet checklangcode(string LangCode,string LangName,  string compcode, string userid)
     {
         DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.LanguageMaster chklang = new NewAdbooking.Classes.LanguageMaster();

            ds = chklang.checklangcode(LangCode, LangName,compcode, userid);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.LanguageMaster chklang = new NewAdbooking.classesoracle.LanguageMaster();

                ds = chklang.checklangcode(LangCode, LangName,compcode, userid);
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.LanguageMaster chklang = new NewAdbooking.classmysql.LanguageMaster();

            ds = chklang.checklangcode(LangCode, LangName, compcode, userid);
            return ds;
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
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet chklanguagecode(string str)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.LanguageMaster chk = new NewAdbooking.Classes.LanguageMaster();
            
            ds = chk.countlanguagecode(str,Session["compcode"].ToString());
            return ds;
        }
        else  if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.LanguageMaster chk = new NewAdbooking.classesoracle.LanguageMaster();

                ds = chk.countlanguagecode(str,Session["compcode"].ToString());
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.LanguageMaster chk = new NewAdbooking.classmysql.LanguageMaster();

            ds = chk.countlanguagecode(str, Session["compcode"].ToString());
            return ds;
        }

    }
    protected void hiddenusername_ServerChange(object sender, System.EventArgs e)
    {

    }
   
}