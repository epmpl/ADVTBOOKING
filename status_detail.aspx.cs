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

public partial class status_detail : System.Web.UI.Page
{
    public static int numberDiv;
    int j = 0;
    static string fDate, tDate;
    string show;
    string agencode, agencysubcode;
    public static int flag = 0;

    DateTime[] sdfr;// = Convert.ToDateTime(txtefffrom.Text);
    string[] dateto;
    DateTime[] sdto;
    static int i;
    string message;

    static string gbfrom, gbto, gbstatus, gbcircular, gbstatusname, gbremark, gbhidattach;

    string currcode;
     DataSet dk1 = new DataSet();
     DataSet dk = new DataSet();
    DataRow my_row;
 
    private void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
        Response.Expires = -1;

        if (Session["compcode"] != null)
        {
            hiddencomcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            show = Request.QueryString["show"].ToString();
            hiddensaurabh.Value = show;
        }
        else
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }

        //			-------------------------------------Code Of XML File--------------
        //		
        DataSet objDataSet = new DataSet();

        objDataSet.ReadXml(Server.MapPath("XML/status_detail.xml"));

        From.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        TO.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString() ;
        Status.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString() ;
        CircularNo.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        Remarks.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        Button1.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        btnclear.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        btndelete.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        btnclose.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
        lblattachment3.Text = objDataSet.Tables[0].Rows[0].ItemArray[9].ToString();

        //         --------------------------------End-------------------------------------------------

        agencode = Request.QueryString["agecode"].ToString();
        agencysubcode = Request.QueryString["agencysubcode"].ToString();

        hiddenagevcode.Value = Request.QueryString["agecode"].ToString();
        Session["hiddenagevcode"] = hiddenagevcode.Value;
        hiddenagensubcode.Value = Request.QueryString["agencysubcode"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(status_detail));

        if (agencode != "" && agencysubcode != "")
        { }
        else
        {
            Response.Write("<script>alert('You Should Enter The Agency Code First And Sub Code');window.close();</script>");

            return;
        }
        if (show=="2")
        {
            Button1.Enabled = true;
            btndelete.Enabled = true;
            txtCircular.Enabled = true;
            txtfrom.Enabled = true;
            txtremark.Enabled = true;
            txtto.Enabled = true;
            drpstatus.Enabled = true;
            attachment1.Enabled = true;
            //btnclose.Enabled = true;
        }
        if (show == "1")
        {
            Button1.Enabled = true;
            btndelete.Enabled = false;
            txtCircular.Enabled = true;
            txtfrom.Enabled = true;
            txtremark.Enabled = true;
            txtto.Enabled = true;
            drpstatus.Enabled = true;
            attachment1.Enabled = true;
        }
        if(show=="0")
        {
            Button1.Enabled = false;
            btndelete.Enabled = false;
            txtCircular.Enabled = false;
            txtfrom.Enabled = false;
            txtremark.Enabled = false;
            txtto.Enabled = false;
            drpstatus.Enabled = false;
            attachment1.Enabled = false;
            //btnclose.Enabled = false;
        }

        if (!Page.IsPostBack)
        {
            statusname();
            if (dk1.Tables.Count > 0 && Session["statussave"] == null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();

                //dk.Clear();
                //dk.Dispose();
                dk = new DataSet();
            }

            if (Session["statussave"] == null || Session["statussave"] == "")
            {

                DataGrid2.Visible = false;
                divdatagrid2.Visible = false;

                divdatagrid1.Visible = true;
                DataGrid1.Visible = true;

                hiddenfdate.Value = "";
                hiddentdate.Value = "";
                tDate = "";
                fDate = "";

                databind("cust_status");
       
            }
            else
            {

                DataGrid2.Visible = true;
                divdatagrid2.Visible = true;

                divdatagrid1.Visible = false;
                DataGrid1.Visible = false;


                bindgrid1("cust_status");

                hiddenfdate.Value = fDate;
                hiddentdate.Value = tDate;
         
            }

            //if (Session["statussave"] != null)
            //{
            //    bindgrid1("cust_status");
            //}


            txtremark.Attributes.Add("OnBlur", "javascript:return uppercase();");
            Button1.Attributes.Add("OnClick", "javascript:return summition();");
            txtfrom.Attributes.Add("onChange", "javascript:return checkdate(this);  ");
            txtto.Attributes.Add("onChange", "javascript:return checkdate(this);  ");
            //btnclose.Attributes.Add("OnClick", "javascript:return selectstatus();");
            btndelete.Attributes.Add("OnClick", "javascript:return deletestatus();");
            btnclear.Attributes.Add("OnClick", "javascript:return cleardata('stat');");
            attachment1.Attributes.Add("OnClick", "javascript:return openattach3();");
            //txtbusineedate.Attributes.Add("onChange", "javascript:return checkdate(this);  ");
        }
    }


    public void statusname()
    {
        drpstatus.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")        
        {
            NewAdbooking.Classes.pop name = new NewAdbooking.Classes.pop();

            ds = name.addstatusname(hiddencomcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop name = new NewAdbooking.classesoracle.pop();
            ds = name.addstatusname(hiddencomcode.Value);
        }
        else
        {
            NewAdbooking.classmysql.pop name = new NewAdbooking.classmysql.pop();
            ds = name.addstatusname(hiddencomcode.Value);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-----Select Status-----";
        li1.Value = "0";
        li1.Selected = true;
        drpstatus.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpstatus.Items.Add(li);
        }
    }


    public void databind(string sortfield)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop status = new NewAdbooking.Classes.pop();

            ds = status.statusbind12(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop status = new NewAdbooking.classesoracle.pop();
            ds = status.statusbind12(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        else
        {
            NewAdbooking.classmysql.pop status = new NewAdbooking.classmysql.pop();
            ds = status.statusbind12(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        if (ds.Tables.Count > 0)
        {
            dv = ds.Tables[0].DefaultView;
            dv.Sort = sortfield;
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
        }
    }

    public void bindgrid1(string sortfield)
    {
        DataGrid1.Visible = false;
        DataGrid2.Visible = true;
        divdatagrid2.Visible = true;
        DataSet ds_tbl = new DataSet();


        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();

        //----------------------added by sayrabh Agarwal

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "cust_status";
        mydatatable.Columns.Add(mycolumn);

        //-----------------------------------------------------------

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "STATUS_NAME";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "FROM_DATE";
        mydatatable.Columns.Add(mycolumn);
        // DataRow myrow;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "TO_DATE";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "circular_no";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Remarks";
        mydatatable.Columns.Add(mycolumn);

          mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "STAT_CODE";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "attachment";
        mydatatable.Columns.Add(mycolumn);

        my_row = mydatatable.NewRow();
        my_row["STATUS_NAME"] = gbstatus;
        my_row["cust_status"] = gbstatusname;
        my_row["FROM_DATE"] = gbfrom;
        my_row["TO_DATE"] = gbto;
        my_row["STAT_CODE"] = "0";
        my_row["circular_no"] = gbcircular;
        my_row["Remarks"] = gbremark;
        my_row["attachment"] = gbhidattach;


        if (Session["statussave"] == null)
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
            dsnew = (DataSet)Session["statussave"];
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
                //if (g == 0)
                //{my_row = dk1.Tables[d].Rows[0]my_row = dk1.Tables[d].Rows[0]
                my_row = dsnew.Tables[d].Rows[0];
                //}
                //else
                //{
                //     my_row = dk.Tables[dk.Tables.Count - 1].Rows[0];
                //}



                mydatatable.ImportRow(my_row);



            }


            ds_tbl.Tables.Add(mydatatable);
            ViewState["SortExpression"] = sortfield;
            ViewState["order"] = "ASC";
            DataView dv = new DataView();
            dv = ds_tbl.Tables[0].DefaultView;
            // dv.Sort = sortfield;


            DataGrid2.DataSource = dv;
            DataGrid2.DataBind();
            d = 0;

        }
        gbcircular = "";
        gbfrom = "";
        gbto = "";
        gbstatus = "";
        gbstatusname = "";
        gbremark = "";
        gbhidattach = "";
        txtfrom.Text = "";
        txtto.Text = "";
        txtCircular.Text = "";
        txtremark.Text = "";
        drpstatus.SelectedValue = "0";
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
        this.hiddendateformat.ServerChange += new System.EventHandler(this.hiddendateformat_ServerChange);
        //this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion

    ////		private void Button1_Click(object sender, System.EventArgs e)
    ////		{
    ////			if(drpstatus.SelectedValue=="0" )
    ////			{
    ////				Response.Write("<script>alert('Status,From Date And To Date Fields Can-not Be Blank');</script>");
    ////				return;
    ////			}
    ////
    ////			string status=drpstatus.SelectedValue.ToString();
    ////			string fromdate=txtfrom.Text;
    ////			string todate=txtto.Text;
    ////
    ////			NewAdbooking.Classes.pop statusinsert=new NewAdbooking.Classes.pop();
    ////			DataSet ds=new DataSet();
    ////
    ////			ds=statusinsert.insertstatus(status,fromdate,todate,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode);
    ////			Response.Write("<script>alert('You Details Saved In Database sucessfuly');</script>");

    ////			drpstatus.SelectedValue="0";
    ////			txtfrom.Text="";
    ////			txtto.Text="";
    ////			databind();
    ////
    ////		}

    [Ajax.AjaxMethod]
    public void Update(string drpstatus, string txtfrom, string txtto, string circular, string agencycode, string compcode, string userid, string agencysubcode, string code, string txtremark,string attach)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings["ConnectionType"].ToString()=="sql")
        {
            NewAdbooking.Classes.pop update1 = new NewAdbooking.Classes.pop();

            ds = update1.statusupdate(drpstatus, txtfrom, txtto, circular, agencycode, compcode, userid, agencysubcode, code, txtremark, attach);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop update1 = new NewAdbooking.classesoracle.pop();
            ds = update1.statusupdate(drpstatus, txtfrom, txtto, circular, agencycode, compcode, userid, agencysubcode, code, txtremark, attach);
        }
        else
        {
            NewAdbooking.classmysql.pop update1 = new NewAdbooking.classmysql.pop();
            ds = update1.statusupdate(drpstatus, txtfrom, txtto, circular, agencycode, compcode, userid, agencysubcode, code, txtremark);
        }
    }

    [Ajax.AjaxMethod]
    public DataSet Sel(string drpstatus, string txtfrom, string txtto, string circular, string compcode, string userid, string agencode, string agencysubcode, string txtremark)
    {
        DataSet dn = new DataSet();
        if (ConfigurationSettings.AppSettings["ConncectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop checkstatus = new NewAdbooking.Classes.pop();

            dn = checkstatus.statuscheck(drpstatus, txtfrom, txtto, circular, compcode, userid, agencode, agencysubcode, txtremark);
            return dn;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop checkstatus = new NewAdbooking.classesoracle.pop();
            dn = checkstatus.statuscheck(drpstatus, txtfrom, txtto, circular, compcode, userid, agencode, agencysubcode, txtremark);
            return dn;
        }
        else
        {
            NewAdbooking.classmysql.pop checkstatus = new NewAdbooking.classmysql.pop();

            dn = checkstatus.statuscheck(drpstatus, txtfrom, txtto, circular, compcode, userid, agencode, agencysubcode, txtremark);
            return dn;
        }
    }

    //Response.Write("<script>alert('Record allready in database');</script>");

    [Ajax.AjaxMethod]
    public void Submit(string drpstatus, string txtfrom, string txtto, string circular, string compcode, string userid, string agencode, string agencysubcode, string txtremark,string dateformat,string attach)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop statusinsert = new NewAdbooking.Classes.pop();

            ds = statusinsert.insertstatus(drpstatus, txtfrom, txtto, circular, compcode, userid, agencode, agencysubcode, txtremark, attach);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop statusinsert = new NewAdbooking.classesoracle.pop();
            ds = statusinsert.insertstatus(drpstatus, txtfrom, txtto, circular, compcode, userid, agencode, agencysubcode, txtremark, dateformat, attach);
        }
        else
        {
            NewAdbooking.classmysql.pop statusinsert = new NewAdbooking.classmysql.pop();
            ds = statusinsert.insertstatus(drpstatus, txtfrom, txtto, circular, compcode, userid, agencode, agencysubcode, txtremark, dateformat, attach);
        }
    }
    [Ajax.AjaxMethod]
    public DataSet delete1(string compcode, string userid, string agencode, string agencysubcode, string hiddenccode)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop delete = new NewAdbooking.Classes.pop();

            da = delete.statusdelete(compcode, userid, agencode, agencysubcode, hiddenccode);
            return da;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop delete = new NewAdbooking.classesoracle.pop();
            da = delete.statusdelete(compcode, userid, agencode, agencysubcode, hiddenccode);
            return da;
        }
        else
        {
            NewAdbooking.classmysql.pop delete = new NewAdbooking.classmysql.pop();
            da = delete.statusdelete(compcode, userid, agencode, agencysubcode, hiddenccode);
            return da;
        }
    }

    //check status detail date in modify mode 
    [Ajax.AjaxMethod]
    public DataSet checkstatusdate(string drpstatus, string txtfrom,string txtto, string compcode, string userid, string agencycode,string agencysubcode,string dateformat)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop chkdate = new NewAdbooking.Classes.pop();

            da = chkdate.statusdatecheck(drpstatus, txtfrom, txtto, compcode, userid, agencycode, agencysubcode, dateformat);
            return da;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop chkdate = new NewAdbooking.classesoracle.pop();
            da = chkdate.statusdatecheck(drpstatus, txtfrom, txtto, compcode, userid, agencycode, agencysubcode, dateformat);
            return da;
        }
        else
        {
            NewAdbooking.classmysql.pop chkdate = new NewAdbooking.classmysql.pop();
            da = chkdate.statusdatecheck(drpstatus, txtfrom, txtto, compcode, userid, agencycode, agencysubcode, dateformat);
            return da;
        }
    }

    [Ajax.AjaxMethod]
    public DataSet databind1(string agecode, string compcode, string userid, string hiddenccode)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings["ConnectionType"].ToString()=="sql")
        {
            NewAdbooking.Classes.pop status = new NewAdbooking.Classes.pop();

            ds = status.statusbind(agecode, compcode, userid, hiddenccode);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop status = new NewAdbooking.classesoracle.pop();
            ds = status.statusbind(agecode, compcode, userid, hiddenccode);

            return ds;
        }
        else
        {
            NewAdbooking.classmysql.pop status = new NewAdbooking.classmysql.pop();
            ds = status.statusbind(agecode, compcode, userid, hiddenccode);

            return ds;
        }
        //DataGrid1.DataSource=ds;
        //DataGrid1.DataBind();
    }

    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        DataView dv = new DataView();

        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + "   OnClick=\"javascript:return selectstatus('"+ str +"');\" value=" + e.Item.Cells[7].Text + "  />";

            //OnClick=\"javascript:return selectstatus();\"
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

                    case "cust_status":
                        str = "Status";
                        break;
                    case "FROM_DATE":
                        str = "From Date";
                        break;

                    case "TO_DATE":
                        str = "To Date";
                        break;

                    case "circular_no":
                        str = "Circualr No.";
                        break;

                    case "Remarks":
                        str = "Remarks ";
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

    private void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString()=="sql")
        {
            NewAdbooking.Classes.pop status = new NewAdbooking.Classes.pop();

            ds = status.statusbind12(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop status = new NewAdbooking.classesoracle.pop();
            ds = status.statusbind12(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        else
        {
            NewAdbooking.classmysql.pop status = new NewAdbooking.classmysql.pop();
            ds = status.statusbind12(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
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
    public DataSet statusinsert(string agencycode, string compcode, string userid, string txtfrom, string txtto, string circular, string date, string txtremark, string subagencycode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConncectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop status = new NewAdbooking.Classes.pop();

            ds = status.statuscheckdate(agencycode, compcode, userid, txtfrom, txtto, circular, date, txtremark, subagencycode);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop status = new NewAdbooking.classesoracle.pop();
            ds = status.statuscheckdate(agencycode, compcode, userid, txtfrom, txtto, circular, date, txtremark, subagencycode);

            return ds;
        }
        else
        {
            NewAdbooking.classmysql.pop status = new NewAdbooking.classmysql.pop();
            ds = status.statuscheckdate(agencycode, compcode, userid, txtfrom, txtto, circular, date, txtremark, subagencycode);

            return ds;
        }
    }

    [Ajax.AjaxMethod]
    public DataSet statusdateupdate(string agencycode, string compcode, string userid, string txtfrom, string txtto, string code, string circular, string date, string txtremark, string subagencycode)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings["ConnectionType"].ToString()=="sql")
        {
            NewAdbooking.Classes.pop status = new NewAdbooking.Classes.pop();

            ds = status.statusdateupdate12(agencycode, compcode, userid, txtfrom, txtto, code, circular, date, txtremark, subagencycode);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop status = new NewAdbooking.classesoracle.pop();
            ds = status.statusdateupdate12(agencycode, compcode, userid, txtfrom, txtto, code, circular, date, txtremark, subagencycode);

            return ds;
        }
        else
        {
            NewAdbooking.classmysql.pop status = new NewAdbooking.classmysql.pop();
            ds = status.statusdateupdate12(agencycode, compcode, userid, txtfrom, txtto, code, circular, date, txtremark, subagencycode);

            return ds;
        }
        //DataGrid1.DataSource=ds;
        //DataGrid1.DataBind();

    }

    private void hiddendateformat_ServerChange(object sender, System.EventArgs e)
    {

    }

    ////		private void btnselect_Click(object sender, System.EventArgs e)
    ////		{
    ////			btndelete.Enabled=true;
    ////			int j=0;
    ////			for (int i = 0; i <= DataGrid1.Items.Count - 1; i++)
    ////			{				
    ////				CheckBox CheckBox = (CheckBox)DataGrid1.Items[i].FindControl("CheckBox1");
    ////				
    ////				if (CheckBox.Checked==true)
    ////				{
    ////					j=j+1;
    ////				}
    ////			}
    ////			
    ////			if (j==1)
    ////			{
    ////				band();
    ////						
    ////			}
    ////			else
    ////			{
    ////				Response.Write("<script>alert('Select Only one item');</script>");	
    ////			}
    ////			
    ////		}
    ////
    ////		public void band()
    ////		{
    ////
    ////			btndelete.Enabled=true;
    ////
    ////			NewAdbooking.Classes.pop status=new NewAdbooking.Classes.pop();
    ////			DataSet ds=new DataSet();
    ////			ds=status.statusbind(agencode,Session["compcode"].ToString(),Session["userid"].ToString());
    ////
    ////			DataGrid1.DataSource=ds;

    ////			for (int i = 0; i <= DataGrid1.Items.Count - 1; i++)
    ////			{
    ////				CheckBox CheckBox = (CheckBox)DataGrid1.Items[i].FindControl("CheckBox1");
    ////				
    ////				if (CheckBox.Checked==true)
    ////				{
    ////					txtfrom.Text=Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[1]).ToString("MM/dd/yyyy");
    ////					txtto.Text=Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[2]).ToString("MM/dd/yyyy");
    ////					drpstatus.SelectedItem.Text=ds.Tables[0].Rows[i].ItemArray[0].ToString();
    ////					hiddenccode.Value=ds.Tables[0].Rows[i].ItemArray[3].ToString(); /*use this field for cont code*/
    ////										
    ////				}
    ////			}
    ////			DataGrid1.DataBind();
    ////	
    ////		}


   

    protected void DataGrid2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
       
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>"); 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;

        hiddenfdate.Value = hiddenfdate.Value + txtfrom.Text + ",";
        hiddentdate.Value = hiddentdate.Value + txtto.Text + ",";
        fDate = hiddenfdate.Value;
        tDate = hiddentdate.Value;

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "cust_status";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "STATUS_NAME";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "FROM_DATE";
        mydatatable1.Columns.Add(mycolumn1);
        // DataRow myrow;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "TO_DATE";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "circular_no";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Remarks";
        mydatatable1.Columns.Add(mycolumn1);


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "STAT_CODE";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "attachment";
        mydatatable1.Columns.Add(mycolumn1);

//--------------------------------------------------------------------------------------

        // Code for Checking the redundency of grid 
        //during the timr of insertinr new record at 
        //runtime when records are submitted in 
        //the session only

//--------------------------------------------------------------------------------------


        DataSet len = (DataSet)Session["statussave"];
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
        if (Session["statussave"] != null && Session["statussave"] != "")
        {
            while (j < length)
            {
                string sf = len.Tables[i].Rows[0].ItemArray[2].ToString();
                string st = len.Tables[i].Rows[0].ItemArray[3].ToString();
                string[] ff = sf.Split('/');
                string mm = ff[0];//.ToString();
                string dd = ff[1];
                string yyyy = ff[2];

                string[] tt = st.Split('/');
                string mm1 = tt[0];//.ToString();
                string dd1 = tt[1];
                string yyyy1 = tt[2];

                string txtfromm = txtfrom.Text;
                string txttoo = txtto.Text;

                string[] txtff = txtfromm.Split('/');
                string txtmm = txtff[0];//.ToString();
                string txtdd = txtff[1];
                string txtyyyy = txtff[2];

                string[] txttt = txttoo.Split('/');
                string txtmm1 = txttt[0];//.ToString();
                string txtdd1 = txttt[1];
                string txtyyyy1 = txttt[2];

                if (((Convert.ToInt32(txtyyyy) >= Convert.ToInt32(yyyy)) && (Convert.ToInt32(txtyyyy) <= Convert.ToInt32(yyyy1))) || ((Convert.ToInt32(txtyyyy1) >= Convert.ToInt32(yyyy)) && (Convert.ToInt32(txtyyyy1) <= Convert.ToInt32(yyyy1))))
                {
                    //Response.Write("<script>alert('You have already entered the Commision Apply On for this duration');</script>");
                    //return;
                    //message = "You have already entered the Commision Apply On for this duration";
                    //AspNetMessageBox(message);
                    //return;

                    if (((Convert.ToInt32(txtmm) >= Convert.ToInt32(mm)) && (Convert.ToInt32(txtmm) <= Convert.ToInt32(mm1))) || ((Convert.ToInt32(txtmm1) >= Convert.ToInt32(mm)) && (Convert.ToInt32(txtmm1) <= Convert.ToInt32(mm1))))
                    {
                        //Response.Write("<script>alert('You have already entered the Commision Apply On for this duration');</script>");
                        //return;
                        //message = "You have already entered the Commision Apply On for this duration";
                        //AspNetMessageBox(message);
                        //return;

                        if (((Convert.ToInt32(txtdd) >= Convert.ToInt32(dd)) && (Convert.ToInt32(txtdd) <= Convert.ToInt32(dd1))) || ((Convert.ToInt32(txtdd1) >= Convert.ToInt32(dd)) && (Convert.ToInt32(txtdd1) <= Convert.ToInt32(dd1))))
                        {
                            //Response.Write("<script>alert('You have already entered the Commision Apply On for this duration');</script>");
                            message = "The Status Detail for this duration has already been submitted";
                            AspNetMessageBox(message);
                            return;

                        }
                    }
                }



                j++;

            }
        }










        myrow1 = mydatatable1.NewRow();
        myrow1["STAT_CODE"] = "00";


        myrow1["STATUS_NAME"] = drpstatus.SelectedItem.Value;
        gbstatus = drpstatus.SelectedItem.Value;


        myrow1["cust_status"] = drpstatus.SelectedItem.Text;
        gbstatusname = drpstatus.SelectedItem.Text;

        myrow1["FROM_DATE"] = txtfrom.Text;
        gbfrom = txtfrom.Text;

        myrow1["TO_DATE"] = txtto.Text;
        gbto = txtto.Text;

        myrow1["circular_no"] = txtCircular.Text;
        gbcircular = txtCircular.Text;

        myrow1["Remarks"] = txtremark.Text;
        gbremark = txtremark.Text;

        myrow1["attachment"] = hidattach1.Value;
        gbhidattach = hidattach1.Value;


        mydatatable1.Rows.Add(myrow1);
        if (Session["statussave"] != null)
        {
            DataSet dsNew = new DataSet();
            dsNew = (DataSet)Session["statussave"];
            dk1 = dsNew;
        }

        dk1.Tables.Add(mydatatable1);

        Session["statussave"] = dk1;
        bindgrid1("cust_status");
    }
/*--------------------------     Saurabh Changed     ------------------------------------

        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();
        DataRow myrow;

     

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "STATUS_NAME";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "FROM_DATE";
        mydatatable.Columns.Add(mycolumn);
        // DataRow myrow;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "TO_DATE";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "circular_no";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Remarks";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "STAT_CODE";
        mydatatable.Columns.Add(mycolumn);
    
  

        myrow = mydatatable.NewRow();

        myrow["STATUS_NAME"] = drpstatus.SelectedValue;

        myrow["FROM_DATE"] = txtfrom.Text;

        myrow["TO_DATE"] = txtto.Text;


        myrow["circular_no"] = txtCircular.Text;

        myrow["Remarks"] = txtremark.Text;
        myrow["STAT_CODE"] = "00";

        mydatatable.Rows.Add(myrow);

        dk1.Tables.Add(mydatatable);
        bindgrid1("cust_status");

 *///---------------------------------------------------change over-----------------------   


    

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(status_detail), "ShowAlert", strAlert, true);
    }



    //public date()
    //{
    
    
    //}

    

}