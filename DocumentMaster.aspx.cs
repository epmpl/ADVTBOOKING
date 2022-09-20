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

public partial class DocumentMaster : System.Web.UI.Page
{
    string compcode, userid, dateformat;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        Response.Expires = -1;

        if (Session["compcode"] == null)
        {


            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(DocumentMaster));
        

        hiddenformname.Value = "Document Master";


        hiddenusername.Value = Session["Username"].ToString();

        compcode = Session["compcode"].ToString();
        hiddencompcode.Value = compcode;

        userid = Session["userid"].ToString();
        hiddenuserid.Value = userid;

        dateformat = Session["dateformat"].ToString();
        hiddendateformat.Value = dateformat;


        pageloadbtn();

        if (!Page.IsPostBack)
        {
            btnSave.Attributes.Add("OnClick", "javascript:return docsave();");
            btnNew.Attributes.Add("OnClick", "javascript:return docnew();");
            btnModify.Attributes.Add("OnClick", "javascript:return docmodify();");
            btnQuery.Attributes.Add("OnClick", "javascript:return docquery();");
            btnExecute.Attributes.Add("OnClick", "javascript:return docexe();");
            btnfirst.Attributes.Add("OnClick", "javascript:return docfirst();");
            btnprevious.Attributes.Add("OnClick", "javascript:return docpre();");
            btnnext.Attributes.Add("OnClick", "javascript:return docnext();");
            btnlast.Attributes.Add("OnClick", "javascript:return doclast();");
            btnCancel.Attributes.Add("OnClick", "javascript:return canceldoc('DocumentMaster')");
            btnDelete.Attributes.Add("OnClick", "javascript:return deletedoc()");
            btnExit.Attributes.Add("OnClick", "javascript:return docexit()");
            txtdoccode.Attributes.Add("OnBlur", "javascript:return UpperCase('txtdoccode')");
            txtdocalias.Attributes.Add("OnBlur", "javascript:return UpperCase('txtdocalias')");
            txtdoctyp.Attributes.Add("OnBlur", "javascript:return UpperCase('txtdoctyp')");
            txtmultiplier.Attributes.Add("OnBlur", "javascript:return UpperCase('txtmultiplier')");
        }
        // Put user code to initialize the page here
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

    //		public void pageloadbtn()
     public void pageloadbtn()
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

        txtdoccode.Enabled = false;
        txtdocalias.Enabled = false;
        txtdoctyp.Enabled = false;
        txtmultiplier.Enabled = false;
    }

    [Ajax.AjaxMethod]
    //		public DataSet docchk(string compcode,string userid,string doccode)
     public DataSet docchk(string compcode, string userid, string doccode)
    { 
         DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.DocumentMaster chk = new NewAdbooking.Classes.DocumentMaster();
       
        ds = chk.chkdoc(compcode, userid, doccode);
        return ds;
    }
        else
        {
            NewAdbooking.classmysql.DocumentMaster chk = new NewAdbooking.classmysql.DocumentMaster();
       
        ds = chk.chkdoc(compcode, userid, doccode);
        return ds;
        }

    }
    [Ajax.AjaxMethod]
    //		public void modify(string compcode,string userid,string doccode,string doctype,string alias,string multi)
     public void modify(string compcode, string userid, string doccode, string doctype, string alias, string multi)
    {   DataSet ds = new DataSet();
        
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.DocumentMaster chk = new NewAdbooking.Classes.DocumentMaster();
      
        ds = chk.docmodify(compcode, userid, doccode, doctype, alias, multi);
    }
    else
    {
        NewAdbooking.classmysql.DocumentMaster chk = new NewAdbooking.classmysql.DocumentMaster();
      
        ds = chk.docmodify(compcode, userid, doccode, doctype, alias, multi);
    }
    }
    [Ajax.AjaxMethod]
    //		public void save(string compcode,string userid,string doccode,string doctype,string alias,string multi)
     public void save(string compcode, string userid, string doccode, string doctype, string alias, string multi)
    { 
       DataSet ds = new DataSet(); 
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.DocumentMaster chk = new NewAdbooking.Classes.DocumentMaster();
        
        ds = chk.docinsert(compcode, userid, doccode, doctype, alias, multi);
    }
    else
    {
        NewAdbooking.classmysql.DocumentMaster chk = new NewAdbooking.classmysql.DocumentMaster();
       
        ds = chk.docinsert(compcode, userid, doccode, doctype, alias, multi);
    }
    }

    [Ajax.AjaxMethod]
    //		public DataSet exe(string compcode,string userid,string doccode,string doctype,string alias,string multi)
     public DataSet exe(string compcode, string userid, string doccode, string doctype, string alias, string multi)
    { 
         DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.DocumentMaster chk = new NewAdbooking.Classes.DocumentMaster();
       
        ds = chk.docexe(compcode, userid, doccode, doctype, alias, multi);
        return ds;
    }
    else
    {
        NewAdbooking.classmysql.DocumentMaster chk = new NewAdbooking.classmysql.DocumentMaster();
       
        ds = chk.docexe(compcode, userid, doccode, doctype, alias, multi);
        return ds;
    }
    }

    [Ajax.AjaxMethod]
    //		public DataSet fnpl(string compcode,string userid)
     public DataSet fnpl(string compcode, string userid)
     {
         DataSet ds = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Classes.DocumentMaster chk = new NewAdbooking.Classes.DocumentMaster();
            
             ds = chk.docfnpl(compcode, userid);
             return ds;
         }
         else
         {
             NewAdbooking.classmysql.DocumentMaster chk = new NewAdbooking.classmysql.DocumentMaster();

             ds = chk.docfnpl(compcode, userid);
             return ds;
         }
    }

    [Ajax.AjaxMethod]
    //		public DataSet del(string compcode,string userid,string doccode)
     public DataSet del(string compcode, string userid, string doccode)
     {
         DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.DocumentMaster chk = new NewAdbooking.Classes.DocumentMaster();
    
        ds = chk.docdel(compcode, userid, doccode);
        return ds;
        }
        else
        {
            NewAdbooking.classmysql.DocumentMaster chk = new NewAdbooking.classmysql.DocumentMaster();

            ds = chk.docdel(compcode, userid, doccode);
            return ds;
        }
    }

    protected void hiddenformname_ServerChange(object sender, System.EventArgs e)
    {

    }


}