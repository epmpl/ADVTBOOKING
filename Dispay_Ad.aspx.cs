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

public partial class Dispay_Ad : System.Web.UI.Page
{
    protected System.Web.UI.WebControls.Label Label1;
    int j = 0;
    string show;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here


        Response.Expires = -1;

        if (Session["compcode"] != null)
        {
            hiddensizecode.Value = Request.QueryString["adsize"].ToString();
            string hiddensize = Request.QueryString["adsize"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            show = Request.QueryString["show"].ToString();

        }
        else
        {
            Response.Redirect("login.aspx");

        }

        Ajax.Utility.RegisterTypeForAjax(typeof(Dispay_Ad));
        if (show == "1" || show == "2")
        {
            btnsubmit.Enabled = true;
            btnselect.Enabled = true;

        }
        else
        {
            btnsubmit.Enabled = false;
            btnselect.Enabled = false;

        }
        if (!Page.IsPostBack)
        {
            displaybind();
            btnsubmit.Attributes.Add("OnClick", "javascript:return submitclick();");
            btnselect.Attributes.Add("OnClick", "javascript:return selectclick();");
            btndelete.Attributes.Add("OnClick", "javascript:return deleteclick();");
        }


    }
    public void displaybind()
    {
        NewAdbooking.Classes.Adsize binddisplay = new NewAdbooking.Classes.Adsize();
        DataSet ds = new DataSet();
        ds = binddisplay.displaybind(Session["compcode"].ToString(), Session["userid"].ToString(), hiddensizecode.Value);
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();


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



    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  value=" + e.Item.Cells[5].Text + "  />";
            j++;
            //e.Item.Cells[0].Text="<input type='checkbox' id="+e.Item.Cells[8].Text+"   value="+e.Item.Cells[8].Text+"  />";

        }

    }


    [Ajax.AjaxMethod]
    public void insertdisplay(string minheight, string maxheight, string minwidth, string maxwidth, string compcode, string userid, string sizecode)
    {
        NewAdbooking.Classes.Adsize insert = new NewAdbooking.Classes.Adsize();
        DataSet ds = new DataSet();

        ds = insert.insertdisplay(minheight, maxheight, minwidth, maxwidth, compcode, userid, sizecode);

    }

    [Ajax.AjaxMethod]
    public DataSet selectdisplay(string compcode, string userid, string sizecode, string codesize)
    {
        NewAdbooking.Classes.Adsize selected = new NewAdbooking.Classes.Adsize();
        DataSet ds = new DataSet();

        ds = selected.selecteddisplay(compcode, userid, sizecode, codesize);

        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet deletedisplay(string compcode, string userid, string sizecode, string codesize)
    {
        NewAdbooking.Classes.Adsize deleted = new NewAdbooking.Classes.Adsize();
        DataSet ds = new DataSet();

        ds = deleted.deletedisplay(compcode, userid, sizecode, codesize);

        return ds;

    }
    [Ajax.AjaxMethod]
    public void updatedisplay(string minheight, string maxheight, string minwidth, string maxwidth, string compcode, string userid, string sizecode, string codesize)
    {
        NewAdbooking.Classes.Adsize updated = new NewAdbooking.Classes.Adsize();
        DataSet ds = new DataSet();

        ds = updated.updatedisplaygrid(minheight, maxheight, minwidth, maxwidth, compcode, userid, sizecode, codesize);

    }



}