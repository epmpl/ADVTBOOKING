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

public partial class ShareDistMaster : System.Web.UI.Page
{
    string compcode, userid;


    protected void Page_Load(object sender, System.EventArgs e)
    {

        Response.Expires = -1;

        if (Session["compcode"] == null)
        {


            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(ShareDistMaster));



        hiddenusername.Value = Session["Username"].ToString();
        hiddenauto.Value = Session["autogenerated"].ToString();

        compcode = Session["compcode"].ToString();
        hiddencompcode.Value = compcode;

        userid = Session["userid"].ToString();
        hiddenuserid.Value = userid;

        pageloadbtn();
        //****work done by shweta***********************************************************
        //******************************XML FOR BUTTON**************************************
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/button.xml"));

        btnNew.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        btnSave.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        btnModify.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        btnQuery.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        btnExecute.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        btnCancel.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        btnfirst.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        btnprevious.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        btnnext.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        btnlast.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        btnDelete.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        btnExit.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();

        //******************************XML for labels****************************************
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/ShareDistMaster.xml"));
        ShareCode .Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        ShareName .Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();


        if (!Page.IsPostBack)
        {
            btnSave.Attributes.Add("OnClick", "javascript:return ShareSave();");
            btnNew.Attributes.Add("OnClick", "javascript:return Sharenew();");
            btnModify.Attributes.Add("OnClick", "javascript:return Sharemodify();");
            btnQuery.Attributes.Add("OnClick", "javascript:return Sharequery();");
            btnExecute.Attributes.Add("OnClick", "javascript:return Shareexe();");
            btnfirst.Attributes.Add("OnClick", "javascript:return Sharefirst();");
            btnprevious.Attributes.Add("OnClick", "javascript:return Sharepre();");
            btnnext.Attributes.Add("OnClick", "javascript:return Sharenext();");
            btnlast.Attributes.Add("OnClick", "javascript:return Sharelast();");
            btnCancel.Attributes.Add("OnClick", "javascript:return cancelShare('ShareDistMaster')");
            btnDelete.Attributes.Add("OnClick", "javascript:return deleteShare()");
            btnExit.Attributes.Add("OnClick", "javascript:return Shareexit()");
            txtShareCode.Attributes.Add("OnBlur", "javascript:return UpperCase('txtShareCode')");
            txtSharename.Attributes.Add("OnBlur", "javascript:return UpperCase('txtSharename')");
            txtSharename.Attributes.Add("OnChange", "javascript:return autoornot()");
        }

    }


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

        txtShareCode .Enabled = false;
        txtSharename .Enabled = false;
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


    [Ajax.AjaxMethod]
    //		public DataSet Sharechk(string compcode,string userid,string ShareCode)
    public DataSet Sharechk(string compcode, string userid, string ShareCode)
    {
        NewAdbooking.Classes.ShareDistMaster chk = new NewAdbooking.Classes.ShareDistMaster();
        DataSet ds = new DataSet();
        ds = chk.chkShare(compcode, userid, ShareCode);
        return ds;
    }
    [Ajax.AjaxMethod]
    //		public void modify(string compcode,string userid,string ShareCode,string Sharename)
    public void modify(string compcode, string userid, string ShareCode, string Sharename)
    {
        NewAdbooking.Classes.ShareDistMaster chk = new NewAdbooking.Classes.ShareDistMaster();
        DataSet ds = new DataSet();
        ds = chk.Sharemodify(compcode, userid, ShareCode, Sharename);
    }
    [Ajax.AjaxMethod]
    //		public void save(string compcode,string userid,string ShareCode,string Sharename)
    public void save(string compcode, string userid, string ShareCode, string Sharename)
    {
        NewAdbooking.Classes.ShareDistMaster chk = new NewAdbooking.Classes.ShareDistMaster();
        DataSet ds = new DataSet();
        ds = chk.Shareinsert(compcode, userid, ShareCode, Sharename);
    }

    [Ajax.AjaxMethod]
    //		public DataSet exe(string compcode,string userid,string ShareCode,string Sharename)
    public DataSet exe(string compcode, string userid, string ShareCode, string Sharename)
    {
        NewAdbooking.Classes.ShareDistMaster chk = new NewAdbooking.Classes.ShareDistMaster();
        DataSet ds = new DataSet();
        ds = chk.Shareexe(compcode, userid, ShareCode, Sharename);
        return ds;
    }

    [Ajax.AjaxMethod]
    //		public DataSet fnpl(string compcode,string userid)
    public DataSet fnpl(string compcode, string userid)
    {
        NewAdbooking.Classes.ShareDistMaster chk = new NewAdbooking.Classes.ShareDistMaster();
        DataSet ds = new DataSet();
        ds = chk.Sharefnpl(compcode, userid);
        return ds;
    }

    [Ajax.AjaxMethod]
    //		public DataSet del(string compcode,string userid,string ShareCode)
    public DataSet del(string compcode, string userid, string ShareCode)
    {
        NewAdbooking.Classes.ShareDistMaster chk = new NewAdbooking.Classes.ShareDistMaster();
        DataSet ds = new DataSet();
        ds = chk.Sharedel(compcode, userid, ShareCode);
        return ds;
    }






    [Ajax.AjaxMethod]
    public DataSet chksharecode(string str)
    {
        NewAdbooking.Classes.ShareDistMaster chk = new NewAdbooking.Classes.ShareDistMaster();
        DataSet ds = new DataSet();
        ds = chk.chkrpcode1(str);
        return ds;

    }

}