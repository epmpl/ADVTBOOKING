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

public partial class DiscountMaster : System.Web.UI.Page
{
    string compcode, userid, dateformat;

    protected void Page_Load(object sender, System.EventArgs e)
    {

        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(DiscountMaster));
        //Ajax.Utility.RegisterTypeForAjax(typeof(multi_discount));

        hiddenusername.Value = Session["Username"].ToString();
        

        compcode = Session["compcode"].ToString();
        hiddencompcode.Value = compcode;

        userid = Session["userid"].ToString();
        hiddenuserid.Value = userid;

        dateformat = Session["dateformat"].ToString();
        hiddendateformat.Value = dateformat;
        hiddenusername.Value = Session["Username"].ToString();



        advtyp(compcode, userid);
        advcat(compcode, userid);
        advcomb(compcode, userid);


        pageloadbtn();

        if (!Page.IsPostBack)
        {
            drpcomb.Attributes.Add("OnChange", "javascript:return combpkg();");
            txtfrom.Attributes.Add("OnChange", "javascript:return checkdate(this)");
            txtto.Attributes.Add("OnChange", "javascript:return checkdate(this)");
            txtdis.Attributes.Add("OnBlur", "javascript:return UpperCase('txtdis')");
            txtremarks.Attributes.Add("OnBlur", "javascript:return UpperCase('txtdis')");
            btnNew.Attributes.Add("OnClick", "javascript:return disnew()");
            btnSave.Attributes.Add("OnClick", "javascript:return dissave()");
            btnExecute.Attributes.Add("OnClick", "javascript:return disexe()");
            btnmulti.Attributes.Add("OnClick", "javascript:return multiple()");
            btnQuery.Attributes.Add("OnClick", "javascript:return disquery()");
            btnModify.Attributes.Add("OnClick", "javascript:return dismodify()");
            btnfirst.Attributes.Add("OnClick", "javascript:return disfirst()");
            btnnext.Attributes.Add("OnClick", "javascript:return disnext()");
            btnprevious.Attributes.Add("OnClick", "javascript:return dispre()");
            btnlast.Attributes.Add("OnClick", "javascript:return dislast()");
            btnCancel.Attributes.Add("OnClick", "javascript:return disCancle('DiscountMaster');");
            txtdiscode.Attributes.Add("OnBlur", "javascript:return UpperCase('txtdiscode')");
            txtremarks.Attributes.Add("OnBlur", "javascript:return UpperCase('txtremarks')");
            txtfrom.Attributes.Add("OnChange", "javascript:return checkdate(this)");
            txtto.Attributes.Add("OnChange", "javascript:return checkdate(this)");
            btnDelete.Attributes.Add("Onclick", "javascript:return disdelete()");
            btnExit.Attributes.Add("Onclick", "javascript:return disexit()");
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
        btnmulti.Enabled = false;

        txtdiscode.Enabled = false;
        drpadvtyp.Enabled = false;
        drpadvcat.Enabled = false;
        drpcomb.Enabled = false;
        drppkg.Enabled = false;
        txtdis.Enabled = false;
        drpdistyp.Enabled = false;
        txtfrom.Enabled = false;
        txtto.Enabled = false;
        txtremarks.Enabled = false;

    }

    //		public void advtyp(string compcode,string userid)
     public void advtyp(string compcode, string userid)
    {
        NewAdbooking.Classes.DiscountMaster bind = new NewAdbooking.Classes.DiscountMaster();
        DataSet ds = new DataSet();
        ds = bind.advdata(compcode, userid);

        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Adv Name-";
        li1.Value = "0";
        li1.Selected = true;
        drpadvtyp.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drpadvtyp.Items.Add(li);

            }
        }


    }



    //		public void advcat(string compcode,string userid)
     public void advcat(string compcode, string userid)
    {
        NewAdbooking.Classes.DiscountMaster bind = new NewAdbooking.Classes.DiscountMaster();
        DataSet ds = new DataSet();
        ds = bind.advdata(compcode, userid);

        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Adv Category-";
        li1.Value = "0";
        li1.Selected = true;
        drpadvcat.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Value = ds.Tables[1].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[1].Rows[i].ItemArray[1].ToString();
                drpadvcat.Items.Add(li);

            }
        }


    }


    //		public void advcomb(string compcode,string userid)
     public void advcomb(string compcode, string userid)
    {
        NewAdbooking.Classes.DiscountMaster bind = new NewAdbooking.Classes.DiscountMaster();
        DataSet ds = new DataSet();
        ds = bind.advdata(compcode, userid);

        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Com./Edi.-";
        li1.Value = "0";
        li1.Selected = true;
        drpcomb.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[2].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Value = ds.Tables[2].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[2].Rows[i].ItemArray[0].ToString();
                drpcomb.Items.Add(li);

            }
        }


    }


    [Ajax.AjaxMethod]
    //		public DataSet filpkg(string comb,string compcode,string userid)
     public DataSet filpkg(string comb, string compcode, string userid)
    {
        NewAdbooking.Classes.DiscountMaster fill = new NewAdbooking.Classes.DiscountMaster();
        DataSet ds = new DataSet();
        ds = fill.advdata1(comb, compcode, userid);

        return ds;
    }

    [Ajax.AjaxMethod]
    //		public DataSet chksave(string discode,string compcode,string userid)
     public DataSet chksave(string discode, string compcode, string userid)
    {
        NewAdbooking.Classes.DiscountMaster fill = new NewAdbooking.Classes.DiscountMaster();
        DataSet ds = new DataSet();
        ds = fill.chksave(discode, compcode, userid);

        return ds;
    }


    [Ajax.AjaxMethod]
    //		public DataSet fnpl(string compcode,string userid)
     public DataSet fnpl(string compcode, string userid)
    {
        NewAdbooking.Classes.DiscountMaster fill = new NewAdbooking.Classes.DiscountMaster();
        DataSet ds = new DataSet();
        ds = fill.chkfnpl(compcode, userid);

        return ds;
    }


    [Ajax.AjaxMethod]
    //		public void insertdis(string discode,string comb,string compcode,string userid,string advcode,string catcode,string pkgname,string  distyp,string disval,string fromdate,string todate,string remarks)
     public void insertdis(string discode, string comb, string compcode, string userid, string advcode, string catcode, string pkgname, string distyp, string disval, string fromdate, string todate, string remarks)
    {
        NewAdbooking.Classes.DiscountMaster fill = new NewAdbooking.Classes.DiscountMaster();
        DataSet ds = new DataSet();
        ds = fill.disinsert(discode, comb, compcode, userid, advcode, catcode, pkgname, distyp, disval, fromdate, todate, remarks);


    }

    [Ajax.AjaxMethod]
    //		public DataSet exedis(string discode,string comb,string compcode,string userid,string advcode,string catcode,string  distyp,string fromdate)
     public DataSet exedis(string discode, string comb, string compcode, string userid, string advcode, string catcode, string distyp, string fromdate)
    {
        NewAdbooking.Classes.DiscountMaster fill = new NewAdbooking.Classes.DiscountMaster();
        DataSet ds = new DataSet();
        ds = fill.disexe(discode, comb, compcode, userid, advcode, catcode, distyp, fromdate);

        return ds;
    }


    [Ajax.AjaxMethod]
    //		public void update(string discode,string comb,string compcode,string userid,string advcode,string catcode,string pkgname,string  distyp,string disval,string fromdate,string todate,string remarks)
     public void update(string discode, string comb, string compcode, string userid, string advcode, string catcode, string pkgname, string distyp, string disval, string fromdate, string todate, string remarks)
    {
        NewAdbooking.Classes.DiscountMaster fill = new NewAdbooking.Classes.DiscountMaster();
        DataSet ds = new DataSet();
        ds = fill.disupdate(discode, comb, compcode, userid, advcode, catcode, pkgname, distyp, disval, fromdate, todate, remarks);


    }


    [Ajax.AjaxMethod]
    //		public void del(string discode,string compcode,string userid)
     public void del(string discode, string compcode, string userid)
    {
        NewAdbooking.Classes.DiscountMaster fill = new NewAdbooking.Classes.DiscountMaster();
        DataSet ds = new DataSet();
        ds = fill.delete(discode, compcode, userid);


    }

    protected void hiddenusername_ServerChange(object sender, System.EventArgs e)
    {

    }

    protected void btnmulti_Click(object sender, System.EventArgs e)
    {

    }


}
