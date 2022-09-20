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

public partial class SchemeDetails : System.Web.UI.Page
{
    int j;
    string compcode, userid, dateformat, SchemeCode;
    string sortfield;
    string show;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;

        }

        compcode = Session["compcode"].ToString();
        hiddencompcode.Value = compcode;


       // show = Request.QueryString["show"].ToString();

        userid = Session["userid"].ToString();
        hiddenuserid.Value = userid;
        dateformat = Session["dateformat"].ToString();
        hiddendateformat.Value = dateformat;
       // SchemeCode = Request.QueryString["SchemeCode"].ToString();
        //hiddenSchemeCode.Value = SchemeCode;

        //Response.Write( "<script> alert('Please Enter Center Code First'); </script>" );

        if (hiddenSchemeCode.Value == "" || hiddenSchemeCode.Value == null)
        {
            Response.Write("<script> alert('Please Enter Center Code First');window.close(); </script>");
        }





        Ajax.Utility.RegisterTypeForAjax(typeof(SchemeDetails));


        //if (show == "1")
        //{
        //    btnsubmit.Enabled = true;
        //    btnselect.Enabled = true;

        //}
        //else
        //{
        //    btnsubmit.Enabled = false;
        //    btnselect.Enabled = false;

        //}

        if (!Page.IsPostBack)
        {
            btnselect.Attributes.Add("OnClick", "javascript:return selectsec();");
            btnsubmit.Attributes.Add("OnClick", "javascript:return Submit();");
            btndelete.Attributes.Add("OnClick", "javascript:return deletesch();");
            txtSchValFrom.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txtSchValTill.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txtfreinsedi.Attributes.Add("OnBlur", "javascript:return UpperCase('txtfreinsedi');");

            binddata(compcode, userid, SchemeCode);
        }


        // Put user code to initialize the page here
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

    public void binddata(string compcode, string userid, string SchemeCode)
    {
        NewAdbooking.Classes.SchemeMaster bind = new NewAdbooking.Classes.SchemeMaster();
        DataSet ds = new DataSet();
        ds = bind.schbind(compcode, userid, SchemeCode);

        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        dv = ds.Tables[0].DefaultView;
        dv.Sort = sortfield;

        DataGrid1.DataSource = dv;
        DataGrid1.DataBind();

    }

    [Ajax.AjaxMethod]
    public void insert(string compcode, string userid, string SchemeCode, string paid, string free, string disno, string distype, string discount, string freins, string fromdate, string todate, string period, string periodtyp)
    {
        NewAdbooking.Classes.SchemeMaster ins = new NewAdbooking.Classes.SchemeMaster();
        DataSet ds = new DataSet();
        ds = ins.detailinsert(compcode, userid, SchemeCode, paid, free, disno, distype, discount, freins, fromdate, todate, period, periodtyp);

    }


    [Ajax.AjaxMethod]
    public void modify(string Code, string compcode, string userid, string SchemeCode, string paid, string free, string disno, string distype, string discount, string freins, string fromdate, string todate, string period, string periodtyp)
    {
        NewAdbooking.Classes.SchemeMaster ins = new NewAdbooking.Classes.SchemeMaster();
        DataSet ds = new DataSet();
        ds = ins.detailupdate(Code, compcode, userid, SchemeCode, paid, free, disno, distype, discount, freins, fromdate, todate, period, periodtyp);


    }

    [Ajax.AjaxMethod]
    public void dele(string SchemeCode, string compcode, string userid, string code)
    {
        NewAdbooking.Classes.SchemeMaster ins = new NewAdbooking.Classes.SchemeMaster();
        DataSet ds = new DataSet();
        ds = ins.detaildelete(SchemeCode, compcode, userid, code);


    }


    [Ajax.AjaxMethod]
    public DataSet sele(string SchemeCode, string compcode, string userid, string code10)
    {

        NewAdbooking.Classes.SchemeMaster databind = new NewAdbooking.Classes.SchemeMaster();
        DataSet da = new DataSet();
        da = databind.clientcontactbind(SchemeCode, userid, compcode, code10);
        return da;
    }




    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {

        DataView dv = new DataView();


        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;




        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + "  value=" + e.Item.Cells[11].Text + "  />";
            j++;


        }

    }

    protected void txtfreinsedi_TextChanged(object sender, System.EventArgs e)
    {

    }
}