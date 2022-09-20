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

public partial class premium_master : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
        Response.Expires = -1;
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            //hiddendateformat.Value=Session["dateformat"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();

        }
        else
        {

            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        navigation();
        Ajax.Utility.RegisterTypeForAjax(typeof(premium_master));

        hiddenusername.Value = Session["Username"].ToString();
        //Ajax.Utility.RegisterTypeForAjax(typeof(ClientMaster));

        if (!Page.IsPostBack)
        {
            addtype();
            addcategory();
            addrategroup();
            addpremiumtype();
            //addpackagetype();
            addcombin();
            txtvalidfrom.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            txtvalidtil.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            drpcombination.Attributes.Add("OnChange", "javascript:return fillpackagename();");
            btnNew.Attributes.Add("OnClick", "javascript:return newclick();");
            btnModify.Attributes.Add("OnClick", "javascript:return modifyclick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return queryclick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return cancelclick('premium_master');");
            btnExit.Attributes.Add("OnClick", "javascript:return exitclick();");
            btnSave.Attributes.Add("OnClick", "javascript:return saveclick();");
            btnExecute.Attributes.Add("OnClick", "javascript:return executeclick();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstclick();");
            btnlast.Attributes.Add("OnClick", "javascript:return lastclick();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextclick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return previousclick();");
            btnDelete.Attributes.Add("OnClick", "javascript:return deleteclick();");
            txtpremiumcode.Attributes.Add("OnChange", "javascript:return uppercase('txtpremiumcode');");
            txtrate.Attributes.Add("OnChange", "javascript:return allamountbullet(this);");
        }
    }

    public void addpremiumtype()
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.premiummaster premiumtyp = new NewAdbooking.Classes.premiummaster();
       
        ds = premiumtyp.bindpretyp(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.premiummaster premiumtyp = new NewAdbooking.classesoracle.premiummaster();

                ds = premiumtyp.bindpretyp(Session["compcode"].ToString(), Session["userid"].ToString());


            }


        ListItem li1;

        li1 = new ListItem();
        li1.Text = "--Select --";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppremiumtype.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drppremiumtype.Items.Add(li);


        }

    }


    public void addcombin()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.premiummaster combin = new NewAdbooking.Classes.premiummaster();
            
            ds = combin.combinbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.premiummaster combin = new NewAdbooking.classesoracle.premiummaster();

            ds = combin.combinbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }

        ListItem li1;

        li1 = new ListItem();
        li1.Text = "--Select --";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcombination.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[1].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[1].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[1].Rows[i].ItemArray[0].ToString();
            drpcombination.Items.Add(li);


        }

    }
    public void addrategroup()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.premiummaster ratebind = new NewAdbooking.Classes.premiummaster();
        
            ds = ratebind.rategrpbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.premiummaster ratebind = new NewAdbooking.classesoracle.premiummaster();

            ds = ratebind.rategrpbind(Session["compcode"].ToString(), Session["userid"].ToString()); 
        }
        ListItem li1;

        li1 = new ListItem();
        li1.Text = "--Select --";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drprategroup.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drprategroup.Items.Add(li);


        }

    }
    public void addtype()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Adsize bindtype = new NewAdbooking.Classes.Adsize();
            ds = bindtype.typebind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize bindtype = new NewAdbooking.classesoracle.Adsize();
            ds = bindtype.typebind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        ListItem li1;

        li1 = new ListItem();
        li1.Text = "--Select --";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpadvtype.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpadvtype.Items.Add(li);


        }
    }
    public void addcategory()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize bindlistbox = new NewAdbooking.Classes.Adsize();

            ds = bindlistbox.listboxbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize bindlistbox = new NewAdbooking.classesoracle.Adsize();

            ds = bindlistbox.listboxbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }

        drpcategory.Items.Clear();
        ListItem li1;
        ListItem li2;
        li1 = new ListItem();
        li1.Text = "--Select --";
        li1.Value = "0";
        li1.Selected = true;

        drpcategory.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpcategory.Items.Add(li);


        }

    }

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
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
    public DataSet bindpackage(string code, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.premiummaster bindpackage = new NewAdbooking.Classes.premiummaster();
            
            ds = bindpackage.packagebind(code, compcode, userid);

            
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.premiummaster bindpackage = new NewAdbooking.classesoracle.premiummaster();
            
            ds = bindpackage.packagebind(code, compcode, userid);

            
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet checkcode(string txtpremiumcode, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            
            NewAdbooking.Classes.premiummaster check = new NewAdbooking.Classes.premiummaster();
            
            ds = check.checkprem(txtpremiumcode, compcode, userid);

            
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.premiummaster check = new NewAdbooking.classesoracle.premiummaster();
            
            ds = check.checkprem(txtpremiumcode, compcode, userid);

            
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet insert(string drpcombin, string drpadvtype, string drpcategory, string txtpremiumcode, string drpprerate, string txtrate, string drppremiumtype, string txtremarks, string validatedate, string validatetill, string compcode, string userid, string drppackagename, string drprategroup)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            
            NewAdbooking.Classes.premiummaster insertprem = new NewAdbooking.Classes.premiummaster();
            
            ds = insertprem.insertpremmast(drpcombin, drpadvtype, drpcategory, txtpremiumcode, drpprerate, txtrate, drppremiumtype, txtremarks, validatedate, validatetill, compcode, userid, drppackagename, drprategroup);

            

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.premiummaster insertprem = new NewAdbooking.classesoracle.premiummaster();
            
            ds = insertprem.insertpremmast(drpcombin, drpadvtype, drpcategory, txtpremiumcode, drpprerate, txtrate, drppremiumtype, txtremarks, validatedate, validatetill, compcode, userid, drppackagename, drprategroup);

            
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet execute(string drpadvtype, string drpcategory, string txtpremiumcode, string drpprerate, string validatedate, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.premiummaster executeprem = new NewAdbooking.Classes.premiummaster();
            
            ds = executeprem.executeprmma(drpadvtype, drpcategory, txtpremiumcode, drpprerate, validatedate, compcode, userid);

            
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.premiummaster executeprem = new NewAdbooking.classesoracle.premiummaster();
            
            ds = executeprem.executeprmma(drpadvtype, drpcategory, txtpremiumcode, drpprerate, validatedate, compcode, userid);

            
        }

        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet first()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            
            NewAdbooking.Classes.premiummaster firstpremmast = new NewAdbooking.Classes.premiummaster();
            ds = firstpremmast.premfirst();

            
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.premiummaster firstpremmast = new NewAdbooking.classesoracle.premiummaster();
            ds = firstpremmast.premfirst();

            
        }
        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet update(string drpcombin, string drpadvtype, string drpcategory, string txtpremiumcode, string drpprerate, string txtrate, string drppremiumtype, string txtremarks, string validatedate, string validatetill, string compcode, string userid, string drppackagename, string drprategroup)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            
            NewAdbooking.Classes.premiummaster updateprem = new NewAdbooking.Classes.premiummaster();
            
            ds = updateprem.updatepremmast(drpcombin, drpadvtype, drpcategory, txtpremiumcode, drpprerate, txtrate, drppremiumtype, txtremarks, validatedate, validatetill, compcode, userid, drppackagename, drprategroup);

            

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.premiummaster updateprem = new NewAdbooking.classesoracle.premiummaster();
            
            ds = updateprem.updatepremmast(drpcombin, drpadvtype, drpcategory, txtpremiumcode, drpprerate, txtrate, drppremiumtype, txtremarks, validatedate, validatetill, compcode, userid, drppackagename, drprategroup);

            
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet deleteed(string txtpremiumcode, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.premiummaster updateprem = new NewAdbooking.Classes.premiummaster();
    
            ds = updateprem.deletepremmast(txtpremiumcode, compcode, userid);

          
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.premiummaster updateprem = new NewAdbooking.classesoracle.premiummaster();
            
            ds = updateprem.deletepremmast(txtpremiumcode, compcode, userid);

            
        }
        return ds;


    }
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

    protected void hiddenusername_ServerChange(object sender, System.EventArgs e)
    {

    }

}