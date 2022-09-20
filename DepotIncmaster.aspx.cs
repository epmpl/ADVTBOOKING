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

public partial class DepotIncmaster : System.Web.UI.Page
{
    int j = 0;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here

        Response.Expires = -1;

        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddenusername.Value = Session["UserName"].ToString();


        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(DepotIncmaster));


        //Ajax.Utility.RegisterTypeForAjax(typeof(ClientMaster));
        bindgrid();
        if (!Page.IsPostBack)
        {
            btnsubmit.Attributes.Add("OnClick", "javascript:return submitclick();");
            btnselect.Attributes.Add("OnClick", "javascript:return selectclick();");
            btndelete.Attributes.Add("OnClick", "javascript:return deleteclick();");
            txtpercentage.Attributes.Add("OnChange", "javascript:return allamountbullet(this);");
            txttdsrate.Attributes.Add("OnChange", "javascript:return allamountbullet(this);");


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
        this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);

    }
    #endregion

    protected void hiddendateformat_ServerChange(object sender, System.EventArgs e)
    {

    }

    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  value=" + e.Item.Cells[7].Text + "  />";
            j++;
            //e.Item.Cells[0].Text="<input type='checkbox' id="+e.Item.Cells[8].Text+"   value="+e.Item.Cells[8].Text+"  />";

        }
    }

    [Ajax.AjaxMethod]

    public void insertde(string slabfrom, string slabto, string percentage, string rate, string txtfromdate, string txtefftill, string userid, string compcode)
    {
        NewAdbooking.Classes.DepotIncMaster insertinto = new NewAdbooking.Classes.DepotIncMaster();
        DataSet ds = new DataSet();
        ds = insertinto.insertdepo(slabfrom, slabto, percentage, rate, txtfromdate, txtefftill, userid, compcode);


    }
    public void bindgrid()
    {
        NewAdbooking.Classes.DepotIncMaster bind = new NewAdbooking.Classes.DepotIncMaster();
        DataSet ds = new DataSet();
        ds = bind.grinddepo(Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());

        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();

    }

    [Ajax.AjaxMethod]

    public DataSet selected(string userid, string compcode, string code10)
    {
        NewAdbooking.Classes.DepotIncMaster selectde = new NewAdbooking.Classes.DepotIncMaster();
        DataSet ds = new DataSet();
        ds = selectde.selectdepo(userid, compcode, code10);

        return ds;


    }

    [Ajax.AjaxMethod]

    public DataSet update(string slabfrom, string slabto, string percentage, string rate, string txtfromdate, string txtefftill, string userid, string compcode, string code)
    {
        NewAdbooking.Classes.DepotIncMaster updatede = new NewAdbooking.Classes.DepotIncMaster();
        DataSet ds = new DataSet();
        ds = updatede.updatevalue(slabfrom, slabto, percentage, rate, txtfromdate, txtefftill, userid, compcode, code);

        return ds;


    }

    [Ajax.AjaxMethod]

    public DataSet deletegrid(string userid, string compcode, string code10)
    {
        NewAdbooking.Classes.DepotIncMaster deletevalue = new NewAdbooking.Classes.DepotIncMaster();
        DataSet ds = new DataSet();
        ds = deletevalue.deleteit(userid, compcode, code10);

        return ds;


    }
    [Ajax.AjaxMethod]

    public DataSet chkinsert(string slabfrom, string slabto, string percentage, string rate, string txtfromdate, string txtefftill, string userid, string compcode)
    {
        NewAdbooking.Classes.DepotIncMaster chkinsert = new NewAdbooking.Classes.DepotIncMaster();
        DataSet ds = new DataSet();
        ds = chkinsert.chkvalue(slabfrom, slabto, percentage, rate, txtfromdate, txtefftill, userid, compcode);

        return ds;


    }

    [Ajax.AjaxMethod]

    public DataSet chkupdate(string slabfrom, string slabto, string percentage, string rate, string txtfromdate, string txtefftill, string userid, string compcode, string code)
    {
        NewAdbooking.Classes.DepotIncMaster chkupdate = new NewAdbooking.Classes.DepotIncMaster();
        DataSet ds = new DataSet();
        ds = chkupdate.chkupdatevalue(slabfrom, slabto, percentage, rate, txtfromdate, txtefftill, userid, compcode, code);

        return ds;


    }
}