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

public partial class Revenue_master : System.Web.UI.Page
{
    int j = 0;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here

        Response.Expires = -1;

        if (Session["compcode"] != null)
        {

            hiddencompcode.Value = Session["compcode"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();

        }
        else
        {
            Response.Redirect("login.aspx");
        }

        navigation();
        Ajax.Utility.RegisterTypeForAjax(typeof(Revenue_master));

        hiddenusername.Value = Session["Username"].ToString();
        

        if (!Page.IsPostBack)
        {
           // adddatagrid("1");

            btnsubmit.Attributes.Add("OnClick", "javascript:return submitintotext();");

            txtsharecode.Attributes.Add("OnChange", "javascript:return uppercase('txtsharecode');  ");
            txtremarks.Attributes.Add("OnChange", "javascript:return uppercase('txtremarks');");
            txtvalidatetill.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            txtvalidaetdate.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");

            btnNew.Attributes.Add("OnClick", "javascript:return newclick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return cancelclick('Revenue_master');");
            btnQuery.Attributes.Add("OnClick", "javascript:return queryclick();");
            btnModify.Attributes.Add("OnClick", "javascript:return modifyclick();");
            btnSave.Attributes.Add("OnClick", "javascript:return submittedclick();");
            btnExecute.Attributes.Add("OnClick", "javascript:return executeclick();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstclick();");
            btnlast.Attributes.Add("OnClick", "javascript:return lastclick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return previousclick();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextclick();");
            btnDelete.Attributes.Add("OnClick", "javascript:return deleteclick();");
            btnExit.Attributes.Add("OnClick", "javascript:return exitclick();");
        }


    }

    //public void adddatagrid(string valuee)
    //{
    //    NewAdbooking.Classes.CombinationMaster datagridbind = new NewAdbooking.Classes.CombinationMaster();
    //    DataSet da = new DataSet();
    //    da = datagridbind.bindgrid(Session["compcode"].ToString(), Session["userid"].ToString(), valuee);
    //    DataGrid1.DataSource = da;
    //    DataGrid1.DataBind();
    //}


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
        this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);

    }
    #endregion

    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string str = "textbox" + j;

            e.Item.Cells[1].Text = "<input type='textbox' width='5px' id=" + str + " onkeypress='return notchar2();' onchange='return allamount(this);' maxlength='4'  />";

            string str1 = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[2].Text = "<input type='checkbox' width='5px' id=" + str + "  value=" + e.Item.Cells[0].Text + "  />";
            j++;

        }
    }

    [Ajax.AjaxMethod]
    public DataSet checkcode(string comcode, string compcode, string userid)
    {
        NewAdbooking.Classes.Revenuemaster check = new NewAdbooking.Classes.Revenuemaster();
        DataSet da = new DataSet();
        da = check.checkrevcode(comcode, compcode, userid);
        return da;
    }

    [Ajax.AjaxMethod]
    public DataSet insert(string sharecode, string sharedescription, string validatedate, string validatetill, string remarks, string compcode, string userid)
    {
        NewAdbooking.Classes.Revenuemaster insertrev = new NewAdbooking.Classes.Revenuemaster();
        DataSet da = new DataSet();
        da = insertrev.revinsert(sharecode, sharedescription, validatedate, validatetill, remarks, compcode, userid);
        return da;
    }

    [Ajax.AjaxMethod]
    public DataSet execute(string sharecode, string sharedescription, string compcode, string userid)
    {
        NewAdbooking.Classes.Revenuemaster excute = new NewAdbooking.Classes.Revenuemaster();
        DataSet da = new DataSet();
        da = excute.executerev(sharecode, sharedescription, compcode, userid);
        return da;
    }

    [Ajax.AjaxMethod]
    public DataSet firstrev()
    {
        NewAdbooking.Classes.Revenuemaster firstexe = new NewAdbooking.Classes.Revenuemaster();
        DataSet da = new DataSet();
        da = firstexe.firstrev();
        return da;
    }

    [Ajax.AjaxMethod]
    public DataSet update(string sharecode, string sharedescription, string validatedate, string validatetill, string remarks, string compcode, string userid)
    {
        NewAdbooking.Classes.Revenuemaster updaterev = new NewAdbooking.Classes.Revenuemaster();
        DataSet da = new DataSet();
        da = updaterev.revupdate(sharecode, sharedescription, validatedate, validatetill, remarks, compcode, userid);
        return da;
    }

    [Ajax.AjaxMethod]
    public DataSet deleterev(string sharecode, string compcode, string userid)
    {
        NewAdbooking.Classes.Revenuemaster updaterev = new NewAdbooking.Classes.Revenuemaster();
        DataSet da = new DataSet();
        da = updaterev.revdelete(sharecode, compcode, userid);
        return da;
    }

    public void navigation()
    {
        btnsubmit.Enabled = false;
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
        //btncomname.Enabled=false;
    }

    protected void btnNew_Click(object sender, System.EventArgs e)
    {

    }

    protected void hiddenusername_ServerChange(object sender, System.EventArgs e)
    {

    }

}