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

public partial class edition_wise_discount : System.Web.UI.Page
{
    string compcode, userid, dateformat, editcode, alias, validco;
    string sortfield;
    string show;
    int j = 0;
    static string gbeditionalias, gbfirstcycle, gbthirdcycle, gbsecondcycle = "";
    DataSet dk1 = new DataSet();
    public static int numberDiv;
    public static string date1 = "";
    public static string year1 = "";
    DataRow my_row;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] != null)
        {

            hiddencompcode.Value = Session["compcode"].ToString();
            compcode = hiddencompcode.Value;
            hiddenuserid.Value = Session["userid"].ToString();
            userid = hiddenuserid.Value;
            hdnunit.Value = Session["revenue"].ToString();
             hdndate.Value = DateTime.Now.ToString();
             hiddendateformat.Value = Session["dateformat"].ToString();
            dateformat = hiddendateformat.Value;
            editcode = Request.QueryString["disccode"].ToString().Trim();
            hiddeneditcode.Value = Request.QueryString["disccode"].ToString();
            show = Request.QueryString["show"].ToString().Trim();
            hiddenperiodicity.Value = Request.QueryString["disctype"].ToString();
            alias = Request.QueryString["disctypename"].ToString();
            //hiddenshow.Value = Request.QueryString["show"].ToString();
            htext.Value = Request.QueryString["htext"].ToString().Trim();
            validco = Request.QueryString["discountprem"].ToString();

        }
        else
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(edition_wise_discount));


        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/edition_wise_discount.xml"));
        lbeditionname.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbldiscount.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbaddate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        btnsubmit.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        btnclear.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        btndelete.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        btnclose.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();

        btndelete.Enabled = false;
        if (!Page.IsPostBack)
        {
            if (show == "1")
            {
                btnsubmit.Enabled = false;

            }
            else if (show == "2")
            {
                btnsubmit.Enabled = true;
                hiddenshow.Value = "1";
            }
            else
            {
                btnsubmit.Enabled = false;
                txtdiscount.Enabled = false;
                txtfrmedition.Enabled = false;
                txttoedition.Enabled = false;
                txtdistype.Enabled = false;
            }
            if (dk1.Tables.Count > 0)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();


            }
            filldisctype(editcode, compcode, userid);

            if ((Session["DISCOUNT"] != null || gbsecondcycle != ""))
            {
                DataGrid2.Visible = true;
                divgrid2.Visible = true;
                DataGrid1.Visible = false;
                divgrid1.Visible = false;
                bindgrid1("DISC_TYPE");
            }

            else
            {
                DataGrid2.Visible = false;
                divgrid2.Visible = false;
                DataGrid1.Visible = true;
                divgrid1.Visible = true;
                bindgrid("DISC_TYPE");
            }
            btnsubmit.Attributes.Add("OnClick", "javascript:return submitclick();");
            btndelete.Attributes.Add("OnClick", "javascript:return deletegridclick();");
            btnclear.Attributes.Add("OnClick", "javascript:return clearclick();");
            txtdiscount.Attributes.Add("onkeypress", "javascript:return notchar2(event);");
            txtfrmedition.Attributes.Add("onkeypress", "javascript:return notchar2(event);");
            txttoedition.Attributes.Add("onkeypress", "javascript:return notchar2(event);");

        }
    }

    public void filldisctype(string editcode, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.edition_wise_discount filltxtalias = new NewAdbooking.Classes.edition_wise_discount();

            txtdistype.SelectedValue = alias;
            txtdistype.Text = alias;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.edition_wise_discount filltxtalias = new NewAdbooking.classesoracle.edition_wise_discount();
            txtdistype.SelectedValue = alias;
            txtdistype.Text = alias;
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster filltxtalias = new NewAdbooking.classmysql.EditorMaster();
            txtdistype.SelectedValue = alias;
        }
    }

    public void bindgrid1(string sortfield)
    {
        DataGrid2.Visible = true;
        divgrid2.Visible = true;
        DataGrid1.Visible = false;
        divgrid1.Visible = false;

        DataSet ds_tbl = new DataSet();


        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "DISC_CODE";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "COMP_CODE";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "UNIT_CODE";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "CREATION_DATETIME";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "USERID";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "UPDATED_DATETIME";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "UPDATEDBY";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "DISC_TYPE";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "DISCOUNT";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "FROM_EDITION";
        mydatatable.Columns.Add(mycolumn);



        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "TO_EDITION";
        mydatatable.Columns.Add(mycolumn);



        my_row = mydatatable.NewRow();
        if (Session["DISCOUNT"] != "" && Session["DISCOUNT"] != null)
        {
            gbeditionalias = txtdistype.SelectedValue;

            gbfirstcycle = Session["DISCOUNT"].ToString();

            gbsecondcycle = Session["FROM_EDITION"].ToString();

            gbthirdcycle = Session["TO_EDITION"].ToString();

            my_row["DISC_CODE"] = hiddeneditcode.Value;
            my_row["COMP_CODE"] = hiddencompcode.Value;
            my_row["UNIT_CODE"] = hdnunit.Value;
            my_row["CREATION_DATETIME"] = hiddendateformat.Value;
            my_row["USERID"] = hiddenuserid.Value;
            my_row["UPDATED_DATETIME"] = hiddendateformat.Value;
            my_row["UPDATEDBY"] = hiddenuserid.Value;

            
            my_row["DISC_TYPE"] = gbeditionalias;
            my_row["DISCOUNT"] = gbfirstcycle;
            my_row["FROM_EDITION"] = gbsecondcycle;
            my_row["TO_EDITION"] = gbthirdcycle;



        }

        else
        {
            my_row["DISC_CODE"] = hiddeneditcode.Value;
            my_row["COMP_CODE"] = hiddencompcode.Value;
            my_row["UNIT_CODE"] = hdnunit.Value;
            my_row["CREATION_DATETIME"] = hiddendateformat.Value;
            my_row["USERID"] = hiddenuserid.Value;
            my_row["UPDATED_DATETIME"] = hiddendateformat.Value;
            my_row["UPDATEDBY"] = hiddenuserid.Value;

           
            my_row["DISC_TYPE"] = gbeditionalias;
            my_row["DISCOUNT"] = gbfirstcycle;
            my_row["FROM_EDITION"] = gbsecondcycle;
            my_row["TO_EDITION"] = gbthirdcycle;


        }

        mydatatable.Rows.Add(my_row);

        ds_tbl.Tables.Add(mydatatable);




        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();

        dv = ds_tbl.Tables[0].DefaultView;
        DataGrid2.DataSource = dv;
        DataGrid2.DataBind();
        gbeditionalias = "";
        gbfirstcycle = "";
        gbsecondcycle = "";
        gbthirdcycle = "";
    }

    public void bindgrid(string sortfield)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.edition_wise_discount bind = new NewAdbooking.Classes.edition_wise_discount();

            ds = bind.discbind(editcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.edition_wise_discount bind = new NewAdbooking.classesoracle.edition_wise_discount();
            ds = bind.discbind(editcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
           // ds = bind.ratebind(editcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster bind = new NewAdbooking.classmysql.EditorMaster();
           // ds = bind.ratebind(editcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
        }
        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        dv = ds.Tables[0].DefaultView;
        dv.Sort = sortfield;
        DataGrid1.DataSource = dv;
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
        this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound_1);
        this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.abc);

    }
    #endregion

    protected void btnsubmit_Click1(object sender, EventArgs e)
    
    {

        
        //string sd = "hello";



        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "DISC_CODE";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "COMP_CODE";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "UNIT_CODE";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "CREATION_DATETIME";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "USERID";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "UPDATED_DATETIME";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "UPDATEDBY";
        mydatatable1.Columns.Add(mycolumn1);


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "DISC_TYPE";
        mydatatable1.Columns.Add(mycolumn1);


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "DISCOUNT";
        mydatatable1.Columns.Add(mycolumn1);


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "FROM_EDITION";
        mydatatable1.Columns.Add(mycolumn1);



        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "TO_EDITION";
        mydatatable1.Columns.Add(mycolumn1);
            

        myrow1 = mydatatable1.NewRow();

        myrow1["DISC_CODE"] = hiddeneditcode.Value;
        myrow1["COMP_CODE"] = hiddencompcode.Value;
        myrow1["UNIT_CODE"] = hdnunit.Value;
        myrow1["CREATION_DATETIME"] = hiddendateformat.Value;
        myrow1["USERID"] = hiddenuserid.Value;
        myrow1["UPDATED_DATETIME"] = hiddendateformat.Value;
        myrow1["UPDATEDBY"] = hiddenuserid.Value;
        myrow1["DISC_TYPE"] = txtdistype.SelectedValue;
        gbeditionalias = txtdistype.SelectedValue;

        myrow1["DISCOUNT"] = txtdiscount.Text;
        gbfirstcycle = txtdiscount.Text;

        myrow1["FROM_EDITION"] = txtfrmedition.Text;
        gbsecondcycle = txtfrmedition.Text;


        myrow1["TO_EDITION"] = txttoedition.Text;
        gbthirdcycle = txttoedition.Text;

        mydatatable1.Rows.Add(myrow1);

        dk1.Tables.Add(mydatatable1);

        bindgrid1("DISC_TYPE");



    }

    protected void DataGrid2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataView dv = new DataView();
        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;
    }

    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>");
    }

    private void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.edition_wise_discount databind = new NewAdbooking.Classes.edition_wise_discount();
            ds = databind.discbind(editcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.edition_wise_discount databind = new NewAdbooking.classesoracle.edition_wise_discount();
            ds = databind.discbind(editcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
           // ds = databind.ratebind(editcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster databind = new NewAdbooking.classmysql.EditorMaster();
            //ds = databind.ratebind(editcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
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


    private void DataGrid1_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        DataView dv = new DataView();

        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  OnClick=\"javascript:return selectclick('" + str + "');\" value=" + e.Item.Cells[1].Text + "  />";
            j++;
            //e.Item.Cells[0].Text="<input type='checkbox' id="+e.Item.Cells[8].Text+"   value="+e.Item.Cells[8].Text+"  />";

        }
        if (e.Item.ItemType == ListItemType.Header)
        {
            if (ViewState["SortExpression"].ToString() != "")
            {
                string str = "";
                switch (ViewState["SortExpression"].ToString())
                {


                    case "DISC_TYPE":
                        str = "DISC TYPE";
                        break;

                    case "DISCOUNT":
                        str = "DISCOUNT";
                        break;

                    case "FROM_EDITION":
                        str = "FROM EDITION";
                        break;


                    case "TO_EDITION":
                        str = "TO EDITION";
                        break;





                };
                string strd = Convert.ToString(dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
                strd = Convert.ToString(Convert.ToInt32(strd) - 1);
                if (strd.Length < 2)
                    strd = "0" + strd;
                if (ViewState["order"].ToString() == "DESC")
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                    //$ctl01$ctl00

                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

                }
                else
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+str+"<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                }
            }
        }
    }

    [Ajax.AjaxMethod]
    public DataSet chkdup(string compcode, string disccode,string unit)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.edition_wise_discount dis = new NewAdbooking.Classes.edition_wise_discount();
            ds = dis.chkduplicate(compcode, disccode,unit);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //NewAdbooking.classesoracle.Disc_master dis = new NewAdbooking.classesoracle.Disc_master();
            NewAdbooking.classesoracle.edition_wise_discount dis = new NewAdbooking.classesoracle.edition_wise_discount();
            ds = dis.chkduplicate(compcode, disccode, unit);
            //ds = dis.chkduplicate(compcode, disccode, discdes, adtype);
            return ds;
        }
        else
        {
            return ds;
        }
    }

    [Ajax.AjaxMethod]

    public void insert(string compcode, string unit, string txtaddate, string year, string txteditionname, string txtdate, string createddate, string userid, string updateddate, string updatedby, string editcode,string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.edition_wise_discount insertgrid = new NewAdbooking.Classes.edition_wise_discount();

            ds = insertgrid.inserteditname(compcode, unit, txtaddate, year, txteditionname, txtdate, createddate, userid, updateddate, updatedby, editcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.edition_wise_discount insertgrid = new NewAdbooking.classesoracle.edition_wise_discount();
            ds = insertgrid.inserteditname(compcode, unit, txtaddate, year, txteditionname, txtdate, createddate, userid, updateddate, updatedby, editcode, dateformat);
            //ds = insertgrid.inserteditname(txteditionname, txtdate, txtaddate, compcode, userid, editcode, year);
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster insertgrid = new NewAdbooking.classmysql.EditorMaster();
            ds = insertgrid.inserteditname(txteditionname, txtdate, txtaddate, compcode, userid, editcode);
        }
        //  Session["firstdate"] = null;
        // Session["seconddate"] = null;

        //if (htext.Value == "mod ")
        //{
        //    bindgrid("Edition_Alias");

        //}


    }

    [Ajax.AjaxMethod]

    public DataSet selected(string compcode, string userid, string unitcode, string disccode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.edition_wise_discount selectgrid = new NewAdbooking.Classes.edition_wise_discount();

            ds = selectgrid.selectedfromgrid(compcode, userid, unitcode, disccode);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.edition_wise_discount selectgrid = new NewAdbooking.classesoracle.edition_wise_discount();
            ds = selectgrid.selectedfromgrid(compcode, userid, unitcode, disccode);
            //ds = selectgrid.selectedfromgrid(editcode, compcode, userid, code10);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster selectgrid = new NewAdbooking.classmysql.EditorMaster();

           // ds = selectgrid.selectedfromgrid(editcode, compcode, userid, code10);

            return ds;
        }


    }
    [Ajax.AjaxMethod]
    public DataSet chkupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string unit)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.edition_wise_discount chkdateup = new NewAdbooking.Classes.edition_wise_discount();

            ds = chkdateup.chkdateupdate(txteditionname, txtdate, txtaddate, compcode, userid, editcode, unit);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.edition_wise_discount chkdateup = new NewAdbooking.classesoracle.edition_wise_discount();
            ds = chkdateup.chkdateupdate(txteditionname, txtdate, txtaddate, compcode, userid, editcode, unit);
           // ds = chkdateup.chkdateupdate(txteditionname, txtdate, txtaddate, compcode, userid, editcode, code10);

            return ds;
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster chkdateup = new NewAdbooking.classmysql.EditorMaster();
           // ds = chkdateup.chkdateupdate(txteditionname, txtdate, txtaddate, compcode, userid, editcode, code10);
            return ds;
        }


    }

    [Ajax.AjaxMethod]

    public void update(string compcode, string unit, string txtaddate, string year, string txteditionname, string txtdate, string createddate, string userid, string updateddate, string updatedby, string editcode, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.edition_wise_discount updategrid = new NewAdbooking.Classes.edition_wise_discount();

            ds = updategrid.gridupdate(compcode, unit, txtaddate, year, txteditionname, txtdate, createddate, userid, updateddate, updatedby, editcode);
            //Session["firstdate"] = null;
            //Session["seconddate"] = null;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.edition_wise_discount updategrid = new NewAdbooking.classesoracle.edition_wise_discount();
            ds = updategrid.gridupdate(compcode, unit, txtaddate, year, txteditionname, txtdate, createddate, userid, updateddate, updatedby, editcode,dateformat);
           // ds = updategrid.gridupdate(txteditionname, txtdate, txtaddate, compcode, userid, editcode, code10, year);
            //Session["firstdate"] = null;
            //Session["seconddate"] = null;
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster updategrid = new NewAdbooking.classmysql.EditorMaster();
            //ds = updategrid.gridupdate(txteditionname, txtdate, txtaddate, compcode, userid, editcode, code10);
            //Session["firstdate"] = null;
            //Session["seconddate"] = null;
        }

    }

    [Ajax.AjaxMethod]

    public void deletegrid(string compcode, string userid, string editcode, string unit)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.edition_wise_discount delete = new NewAdbooking.Classes.edition_wise_discount();

            ds = delete.griddelete(compcode, userid, editcode, unit);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.edition_wise_discount delete = new NewAdbooking.classesoracle.edition_wise_discount();
            ds = delete.griddelete(compcode, userid, editcode, unit);
            //ds = delete.griddelete(editcode, compcode, userid, code10);
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster delete = new NewAdbooking.classmysql.EditorMaster();
            //ds = delete.griddelete(editcode, compcode, userid, code10);
        }

    }


}
