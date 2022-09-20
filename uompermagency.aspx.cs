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

public partial class uompermagency : System.Web.UI.Page
{
    string agencode, agencysubcode, comp, userid, show;
    int j = 0;
    string sortfield;
    public static int numberDiv;
    static string uom, adtype, category;
    static int i;
    DataSet dk1 = new DataSet();
    DataSet dk = new DataSet();
    DataRow my_row;
    string message;
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(uompermagency), "ShowAlert", strAlert, true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;

        if (Session["compcode"] != null)
        {

            userid = Session["userid"].ToString();
            hiddenuserid.Value = userid;
            comp = Session["compcode"].ToString();
            hiddencomcode.Value = comp;
            hiddendateformat.Value = Session["dateformat"].ToString();
            show = Request.QueryString["show"].ToString();
            hiddensaurabh.Value = show;
           
        }
        else
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(uompermagency));
        //			-------------------------------------Code Of XML File--------------
        //		
        DataSet objDataSet = new DataSet();

        objDataSet.ReadXml(Server.MapPath("XML/uomper.xml"));

        lbladtype.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lblcat.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        lbluom.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        btnsubmit.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        clear.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        btndelete.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        btnclose.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();

        //         --------------------------------End-------------------------------------------------


        agencode = Request.QueryString["agecode"].ToString();
        hiddenagencycode.Value = agencode;
        Session["hiddenagevcode"] = hiddenagevcode.Value;
        agencysubcode = Request.QueryString["agencysubcode"].ToString();
        hiddenagensubcode.Value = agencysubcode;
       
        if (agencode != "" && agencysubcode != "")
        { }
        else
        {
            Response.Write("<script>alert('You Should Enter The Agency Code First And Sub Code');window.close();</script>");

            return;
        }
        bindadvtype();
       // binduom();
        //******************************************************
        if (show == "2")
        {
            btnsubmit.Enabled = true;
            btndelete.Enabled = true;
            drpadtype.Enabled = true;
            drpcat.Enabled = true;
            drpuom.Enabled = true;
        }
        if (show == "1")
        {
            btnsubmit.Enabled = true;
            btndelete.Enabled = false;
            drpadtype.Enabled = true;
            drpcat.Enabled = true;
            drpuom.Enabled = true;
        }
        if (show == "0")
        {
            btnsubmit.Enabled = false;
            btndelete.Enabled = false;
            drpadtype.Enabled = false;
            drpcat.Enabled = false;
            drpuom.Enabled = false;
        }
        if (!Page.IsPostBack)
        {
            if (dk1.Tables.Count > 0 && Session["uommaster"] == null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();
                dk = new DataSet();
            }
          
            if (Session["hiddenagevcode"] != null)
            {
                DataGrid2.Visible = false;
                Div2.Visible = false;
                Div1.Visible = true;
                DataGrid1.Visible = true;
                binddata("uom_name");
            }
            else
            {
                DataGrid2.Visible = true;
                Div2.Visible = true;

                Div1.Visible = false;
                DataGrid1.Visible = false;
                bindgrid1("uom_name");

            }

            if (Session["uommaster"] != null)
            {
                bindgrid1("uom_name");
            }
            drpadtype.Attributes.Add("OnChange", "javascript:return filladcat();");
          
            btnsubmit.Attributes.Add("OnClick", "javascript:return submitdata();");
            btndelete.Attributes.Add("OnClick", "javascript:return deleted();");
            clear.Attributes.Add("OnClick", "javascript:return cleardata();");
            btnclose.Attributes.Add("OnClick", "javascript:return closewindow();");
          //  drpadtype.Attributes.Add("OnBlur", "javascript:return filluom();");
            //txtbran.Attributes.Add("OnBlur", "javascript:return uppercase('txtbran');");
            //txtbno.Attributes.Add("OnBlur", "javascript:return uppercase('txtbno');");
            //txtano.Attributes.Add("OnBlur", "javascript:return uppercase('txtano');");
            //***********************************************************************

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

        this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.abc);
        this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
        //this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion

    ////*********************************Bind The Adv Type*******************************//
    public void bindadvtype()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdCategoryMaster advname = new NewAdbooking.Classes.AdCategoryMaster();

            ds = advname.adname(hiddencomcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCategoryMaster advname = new NewAdbooking.classesoracle.AdCategoryMaster();
            ds = advname.adname(hiddencomcode.Value);
        }
        else
        {
            NewAdbooking.classmysql.AdCategoryMaster advname = new NewAdbooking.classmysql.AdCategoryMaster();
            ds = advname.adname(hiddencomcode.Value);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Ad Type--";
        li1.Value = "0";
        li1.Selected = true;
        drpadtype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpadtype.Items.Add(li);


        }
    }
       
    [Ajax.AjaxMethod]
    public DataSet adcat(string compcode, string adtype, string center)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bind = new NewAdbooking.Classes.BookingMaster();
            ds = bind.advdatacategoryRate(compcode, adtype, center);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster bind = new FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster();
            ds = bind.advdatacategory(compcode, adtype, center);

        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
            ds = bind.advdatacategory(compcode, adtype);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet binduomdrop(string compcode, string adtype, string center)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.RateMaster binduom = new FourCPlus.AdBooking.BookingMaster.Sql.RateMaster();
            ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), "0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.uomperm binduom = new NewAdbooking.classesoracle.uomperm();
            ds = binduom.uombinddrop(compcode, "", adtype);
        }
        else
        {
            NewAdbooking.classmysql.RateMaster binduom = new NewAdbooking.classmysql.RateMaster();
            ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), "0");
        }
        return ds;
        //int i;
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "Select UOM";
        //li1.Value = "0";
        //li1.Selected = true;
        //drpuom.Items.Add(li1);
        //for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    ListItem li;
        //    li = new ListItem();
        //    li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //    li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //    drpuom.Items.Add(li);
        //}
    }

    public void binddata(string sortfield)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.uomperm bind = new NewAdbooking.Classes.uomperm();

            ds = bind.uombind(agencode, agencysubcode, comp, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.uomperm bind = new NewAdbooking.classesoracle.uomperm();
            ds = bind.uombind(agencode, agencysubcode, comp, userid);
        }
        
        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        dv = ds.Tables[0].DefaultView;
        dv.Sort = sortfield;
        DataGrid1.DataSource = dv;
        DataGrid1.DataBind();



    }
    public void bindgrid1(string sortfield)
    {
        DataGrid1.Visible = false;
        DataGrid2.Visible = true;
        Div2.Visible = true;
        DataSet ds_tbl = new DataSet();
        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "uom_name";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "adtype";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "category";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "seq_no";
        mydatatable.Columns.Add(mycolumn);

        if (Session["uommaster"] == null)
        {
            ds_tbl.Tables.Add(mydatatable);
            DataGrid1.DataSource = ds_tbl.Tables[0];
            DataGrid1.DataBind();
        }
        else
        {
            int d;
            int g;
            DataSet dsnew = new DataSet();
            dsnew = (DataSet)Session["uommaster"];
            if (dsnew.Tables.Count > 1)
            {
                g = 1;
            }
            else
            {
                g = 0;
            }

            for (d = 0; d <= dsnew.Tables.Count - 1; d++)
            {
              
                my_row = dsnew.Tables[d].Rows[0];
               
                mydatatable.ImportRow(my_row);
            }


            ds_tbl.Tables.Add(mydatatable);
            ViewState["SortExpression"] = sortfield;
            ViewState["order"] = "ASC";
            DataView dv = new DataView();
            dv = ds_tbl.Tables[0].DefaultView;
            DataGrid2.DataSource = dv;
            DataGrid2.DataBind();
            d = 0;
        }
       
        uom="";
        adtype = "";
        category = "";
        drpadtype.SelectedValue = "0";
        drpuom.SelectedValue = "0";
        drpcat.SelectedValue = "0";

        hiddenuom.Value = "";
        hiddenadtyp.Value = "";
        hiddencate.Value = "";

    }
    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        DataView dv = new DataView();
        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return selected('" + str + "');\" value=" + e.Item.Cells[4].Text + "  />";
            j++;
        }

        if (e.Item.ItemType == ListItemType.Header)
        {
            for (int a = 0; a <= e.Item.Cells.Count - 1; a++)
            {
            }
            if (ViewState["SortExpression"].ToString() != "")
            {
                string str = "";
                switch (ViewState["SortExpression"].ToString())
                {
                    case "uom_name":
                        str = "Uom_Name";
                        break;
                    case "adtype":
                        str = "Adtype";
                        break;

                    case "category":
                        str = "Category";
                        break;
                    case "seq_no":
                        str = "Seq_No.";
                        break;
                };
                string strd = Convert.ToString(dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
                strd = Convert.ToString(Convert.ToInt32(strd) - 1);
                if (strd.Length < 2)
                    strd = "0" + strd;
                if (ViewState["order"].ToString() == "DESC")
                {
                  
                   // e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

                }
                else
                {
                   // e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                }

            }
        }
    
    }
   
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "uom_name";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "adtype";
        mydatatable1.Columns.Add(mycolumn1);
    
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "category";
        mydatatable1.Columns.Add(mycolumn1);

       
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "seq_no";
        mydatatable1.Columns.Add(mycolumn1);

        myrow1 = mydatatable1.NewRow();

        drpuom.SelectedValue = hiddenuom.Value;
        myrow1["uom_name"] = drpuom.SelectedItem.Value;
        uom = hiddenuom.Value;


        drpcat.SelectedValue = hiddencate.Value;
        myrow1["category"] = drpcat.SelectedItem.Value;
        category = hiddencate.Value;

        drpadtype.SelectedValue = hiddenadtyp.Value;
        myrow1["adtype"] = drpadtype.SelectedItem.Value;
        adtype = hiddenadtyp.Value;


        DataSet len = (DataSet)Session["uommaster"];
        int length;
        if (len != null)
        {
            length = len.Tables.Count;
        }
        else
        {
            length = 0;
        }
        int j = 0;
     

        mydatatable1.Rows.Add(myrow1);
        if (Session["uommaster"] != null)
        {
            DataSet dsNew = new DataSet();
            dsNew = (DataSet)Session["uommaster"];
            dk1 = dsNew;
        }

        dk1.Tables.Add(mydatatable1);
        Session["uommaster"] = dk1;
        bindgrid1("uom_name");
   
    }
    [Ajax.AjaxMethod]
    public void insert(string compcode, string userid, string uom, string category, string adtype, string agencode, string subagncode, string seq)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.uomperm ins = new NewAdbooking.Classes.uomperm();

            ds = ins.insertdata(compcode, userid, uom, category, adtype, agencode, subagncode, seq);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.uomperm ins = new NewAdbooking.classesoracle.uomperm();
            ds = ins.insertdata(compcode, userid,uom,category,adtype, agencode, subagncode,seq);
        }
        
    }
    [Ajax.AjaxMethod]
    public DataSet bandcontact(string compcode, string userid, string agencode, string subagncode, string code10)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.uomperm databind = new NewAdbooking.Classes.uomperm();

            da = databind.bankdata(compcode, userid, agencode, subagncode, code10);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.uomperm databind = new NewAdbooking.classesoracle.uomperm();
            da = databind.bankdata(compcode, userid, agencode, subagncode, code10);
        }
        
        return da;
    }
    [Ajax.AjaxMethod]
    public void update(string compcode, string userid, string uom, string category, string adtype, string agencode, string subagncode, string seq)
    {
        DataSet ds = new DataSet();
      
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.uomperm ins = new NewAdbooking.Classes.uomperm();

            ds = ins.updatedata(compcode, userid, uom, category, adtype, agencode, subagncode, seq);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.uomperm ins = new NewAdbooking.classesoracle.uomperm();
            ds = ins.updatedata(compcode, userid, uom, category, adtype, agencode, subagncode, seq);
        }

    }

    private void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.uomperm bind = new NewAdbooking.Classes.uomperm();

            ds = bind.uombind(agencode, agencysubcode, comp, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.uomperm bind = new NewAdbooking.classesoracle.uomperm();
            ds = bind.uombind(agencode, agencysubcode, comp, userid);
        }
        else
        {
            //NewAdbooking.classmysql.bankmaster bind = new NewAdbooking.classmysql.bankmaster();

            //ds = bind.bankbind(agencode, agencysubcode, comp, userid);
        }
        DataView dv = new DataView();
        dv = ds.Tables[0].DefaultView;
        if ((numberDiv % 2) == 0)
        {
            dv.Sort = e.SortExpression + " " + "ASC";
            ViewState["SortExpression"] = e.SortExpression;
            ViewState["order"] = "ASC";
        }
        else
        {
            dv.Sort = e.SortExpression + " " + "DESC";
            ViewState["SortExpression"] = e.SortExpression;
            ViewState["order"] = "DESC";
        }
        numberDiv++;



        DataGrid1.DataSource = dv;
        DataGrid1.DataBind();


    }
    [Ajax.AjaxMethod]
    public void dele(string compcode, string userid, string codebk)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.uomperm ins = new NewAdbooking.Classes.uomperm();

            ds = ins.deletedata(compcode, userid, codebk);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.uomperm ins = new NewAdbooking.classesoracle.uomperm();
            ds = ins.deletedata(compcode, userid, codebk);
        }
      
    }


}
