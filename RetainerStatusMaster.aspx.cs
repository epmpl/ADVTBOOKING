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

public partial class RetainerStatusMaster : System.Web.UI.Page
{
    int j = 0;

    public static int numberDiv;
    static string fDate, tDate;
    //string sortfield;
//    public static int numberDiv;
    string userid, compcode, retcode, show, n_m;
    static string gbfrom, gbto, gbstatus, gbcircular, gbstatusname;
    static DataSet dk1 = new DataSet();
    DataRow my_row;
    public static int flag = 0;
    protected void Page_Load(object sender, System.EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //string codepass = Request.QueryString["codepass"].ToString();

        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(RetainerStatusMaster));


        show = Request.QueryString["show"].ToString();
        n_m = Request.QueryString["n_m"].ToString();

        hiddenshow.Value = show;

        hiddencompcode.Value = Session["compcode"].ToString();
        compcode = hiddencompcode.Value;

        hiddenuserid.Value = Session["userid"].ToString();
        userid = hiddenuserid.Value;

        hiddendateformat.Value = Session["dateformat"].ToString();

        hiddenretcode.Value = Request.QueryString["RetStatusCode"].ToString();
        retcode = hiddenretcode.Value;

        btndelete.Enabled = false;
        if (hiddenretcode.Value == "")
        {
            Response.Write("<script>alert('You Should Enter The Retainer Code First');window.close();</script>");
            return;
        }

        DataSet dk = new DataSet();
        dk.ReadXml(Server.MapPath("XML/retainerstatusdetail.xml"));

        lblfromdate.Text = dk.Tables[0].Rows[0].ItemArray[0].ToString();
        lblstatus.Text = dk.Tables[0].Rows[0].ItemArray[1].ToString();

        lbltodate.Text = dk.Tables[0].Rows[0].ItemArray[2].ToString();

        lblcircular.Text = dk.Tables[0].Rows[0].ItemArray[3].ToString();

        btnSubmit.Text = dk.Tables[0].Rows[0].ItemArray[4].ToString();


        btnclear.Text = dk.Tables[0].Rows[0].ItemArray[5].ToString();

        btnclose.Text = dk.Tables[0].Rows[0].ItemArray[6].ToString();

        btndelete.Text = dk.Tables[0].Rows[0].ItemArray[7].ToString();



        //if (custcode != "")
        //{ }
        //else
        //{
        //    Response.Write("<script>alert('You Should Enter The Customer Code First ');window.close();</script>");
        //    return;
        //}
        if (show == "1")
        {

            btnSubmit.Enabled = true;
            txtto.Enabled = true;
            txtfrom.Enabled = true;
            txtcircularno.Enabled = true;
            drpstatus.Enabled = true;
            btndelete.Enabled = false;
            hiddendelsau.Value = "0";

        }
        if (show == "0")
        {

            btndelete.Enabled = false;
            //   txtcontactperson.Enabled = false;
            btnSubmit.Enabled = false;
            txtto.Enabled = false;
            txtfrom.Enabled = false;
            txtcircularno.Enabled = false;
            drpstatus.Enabled = false;
            hiddendelsau.Value = "0";
            
        }

        if (show == "2")
        {
            btnSubmit.Enabled = true;

            btndelete.Enabled = false;
            //btnsubmit.Enabled = true;
            //btndelete.Enabled = true;
            txtto.Enabled = true;
            txtfrom.Enabled = true;
            txtcircularno.Enabled = true;
            drpstatus.Enabled = true;
            hiddendelsau.Value = "1";

        }

        if (!Page.IsPostBack)
        {
            statusname();
            if (dk1.Tables.Count > 0 && Session["retainer_stat"] == null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();
            }
            if (Session["retainer_stat"] == null)
            {
                DataGrid2.Visible = false;
                Divgrid2.Visible = false;
                Divgrid1.Visible = true;
                DataGrid1.Visible = true;
                hiddenfdate.Value = "";
                hiddentdate.Value = "";
                tDate = "";
                fDate = "";
                binddata("cust_status");
            }
            else
            {
                DataGrid2.Visible = true;
                Divgrid2.Visible = true;
                Divgrid1.Visible = false;
                DataGrid1.Visible = false;
                binddata1("cust_status");
                hiddenfdate.Value = fDate;
                hiddentdate.Value = tDate;
            }

            
            //Button Coding
            btnSubmit.Attributes.Add("OnClick", "javascript:return RetStatusSubmit();");
            // btnselect.Attributes.Add("OnClick", "javascript:return StatusSelect();");
            btnclear.Attributes.Add("OnClick", "javascript:return PopStatusClear();");
            btndelete.Attributes.Add("OnClick", "javascript:return StatusDelete();");

            //Control Validations left undone

            txtfrom.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txtto.Attributes.Add("OnChange", "javascript:return checkdate(this);");


            //if (show == "1" || show == "2")
            //{
            //    btnSubmit.Enabled = true;
            //    btnselect.Enabled = true;
            //}
            //if (show == "0")
            //{
            //    btnSubmit.Enabled = false;
            //    btnselect.Enabled = false;

            //}

        }

    }

    public void statusname()
    {
        drpstatus.Items.Clear();
          DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.RetainerMaster name = new NewAdbooking.Classes.RetainerMaster();
      
        ds = name.addstatusname(compcode);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster name = new NewAdbooking.classesoracle.RetainerMaster();

                ds = name.addstatusname(compcode);
            }
        else
        {
            NewAdbooking.classmysql .RetainerMaster name = new NewAdbooking.classmysql.RetainerMaster();
      
        ds = name.addstatusname(compcode);
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

    public void binddata(string sortfield)
    {
             DataSet da = new DataSet();
            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
            {
            NewAdbooking.Classes.RetainerMaster databind = new NewAdbooking.Classes.RetainerMaster();
           
            da = databind.retainerstatusbind(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());
            }
            else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster databind = new NewAdbooking.classesoracle.RetainerMaster();
                da = databind.retainerstatusbind(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

            }
            else
            {
                NewAdbooking.classmysql .RetainerMaster databind = new NewAdbooking.classmysql.RetainerMaster();
                da = databind.retainerstatusbind(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

            }

        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        if (da.Tables.Count > 0)
       {
            dv = da.Tables[0].DefaultView;
            dv.Sort = sortfield;
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
       }

    }

    public void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
      DataSet da = new DataSet();  
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {       

        NewAdbooking.Classes.RetainerMaster bind = new NewAdbooking.Classes.RetainerMaster();   
      

        da = bind.retainerstatusbind(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster bind = new NewAdbooking.classesoracle.RetainerMaster();   
      

        da = bind.retainerstatusbind(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

            }
        else
        {
                    NewAdbooking.classmysql .RetainerMaster bind = new NewAdbooking.classmysql.RetainerMaster();      
      

        da = bind.retainerstatusbind(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

        }

        DataView dv = new DataView();
        dv = da.Tables[0].DefaultView;
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

    public void binddata1(string sortfield)
    {
        DataGrid2.Visible = true;
        Divgrid2.Visible = true;
        DataGrid1.Visible = false;
        Divgrid1.Visible = false;

        DataSet ds_tbl = new DataSet();


        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();


        // DataRow myrow;
        //mycolumn = new DataColumn();
        //mycolumn.DataType = System.Type.GetType("System.String");
        //mycolumn.ColumnName = "Ret_status";
        //mydatatable.Columns.Add(mycolumn);



        // //DataColumn mycolumn;

        // DataRow myrow;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "cust_status";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "STATUS_NAME";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "FROM_DATE";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "TO_DATE";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "STAT_CODE";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "circular_no";
        mydatatable.Columns.Add(mycolumn);



        my_row = mydatatable.NewRow();
        my_row["status_name"] = gbstatus;
        my_row["cust_status"] = gbstatusname;
        my_row["FROM_DATE"] = gbfrom;
        my_row["TO_DATE"] = gbto;
        my_row["STAT_CODE"] = "0";
        my_row["circular_no"] = gbcircular;
        //my_row["Fax"] = gbfax;
        //my_row["EmailID"] = gbmailid;
        //my_row["Cont_Code"] = "0";
        //gbsecondcycle = txtaddate.Text;

        //  mydatatable.Rows.Add(my_row);

        ds_tbl.Tables.Add(mydatatable);

        // mydatatable.ImportRow(my_row);

        if (Session["retainer_stat"] == null)
        {
            ds_tbl.Tables.Add(mydatatable);
            DataGrid2.DataSource = ds_tbl.Tables[0];
            DataGrid2.DataBind();
        }
        else
        {
            int d;
            int g;
            if (dk1.Tables.Count > 1)
            {
                g = 1;
            }
            else
            {
                g = 0;
            }

            for (d = 0; d <= dk1.Tables.Count - 1; d++)
            {
                //if (g == 0)
                //{my_row = dk1.Tables[d].Rows[0]my_row = dk1.Tables[d].Rows[0]
                my_row = dk1.Tables[d].Rows[0];
                //}
                //else
                //{
                //     my_row = dk.Tables[dk.Tables.Count - 1].Rows[0];
                //}



                mydatatable.ImportRow(my_row);



            }


            //ds_tbl.Tables.Add(mydatatable);
            ViewState["SortExpression"] = sortfield;
            ViewState["order"] = "ASC";
            DataView dv = new DataView();
            dv = ds_tbl.Tables[0].DefaultView;
            // dv.Sort = sortfield;


            DataGrid2.DataSource = dv;
            DataGrid2.DataBind();
            d = 0;

        }


        //ViewState["SortExpression"] = sortfield;
        //ViewState["order"] = "ASC";
        //DataView dv = new DataView();

        //dv = ds_tbl.Tables[0].DefaultView;
        //DataGrid2.DataSource = dv;
        //DataGrid2.DataBind();


        gbcircular = "";
        gbfrom = "";
        gbto = "";
        gbstatus = "";
        gbstatusname = "";
        txtfrom.Text = "";
        txtto.Text = "";
        txtcircularno.Text = "";
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
        this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);

    }
    #endregion

    [Ajax.AjaxMethod]
    public DataSet checkstatusdate(string retcode, string compcode, string userid, string date, string fromdate, string todate, int flag)
    { DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.RetainerMaster rtmst = new NewAdbooking.Classes.RetainerMaster();
       
        ds = rtmst.Ret_GetStatus(retcode, compcode, userid, date, fromdate, todate, "", flag);
        return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster rtmst = new NewAdbooking.classesoracle.RetainerMaster();

                ds = rtmst.Ret_GetStatus(retcode, compcode, userid, date, fromdate, todate, "", flag);
                return ds;
 
            }
        else
        {
            NewAdbooking.classmysql .RetainerMaster rtmst = new NewAdbooking.classmysql.RetainerMaster();
       
        ds = rtmst.Ret_GetStatus(retcode, compcode, userid, date, fromdate, todate, "", flag);
        return ds;
        }

    }


    [Ajax.AjaxMethod]
    public DataSet bandstatus(string retcode, string compcode, string userid, string code11, string dateformat)
    {DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {      
        

        NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();
        
        ds = insert.selectretstatus(retcode, compcode, userid, code11, dateformat);
        return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                  NewAdbooking.classesoracle .RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();
        
        ds = insert.selectretstatus(retcode, compcode, userid, code11, dateformat);
        return ds;
            }
        else
        {
            NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();
        
        ds = insert.selectretstatus(retcode, compcode, userid, code11, dateformat);
        return ds;
        }
    }


    [Ajax.AjaxMethod]
    public DataSet checkstatusdateupdate(string retcode, string compcode, string userid, string status, string circular, string todate, string fromdate, string code)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.RetainerMaster rtmst = new NewAdbooking.Classes.RetainerMaster();
        
        ds = rtmst.Ret_GetStatusupdate(retcode, compcode, userid, status, circular, todate, fromdate, code);
        return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster rtmst = new NewAdbooking.classesoracle.RetainerMaster();

                ds = rtmst.Ret_GetStatusupdate(retcode, compcode, userid, status, circular, todate, fromdate, code);
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.RetainerMaster rtmst = new NewAdbooking.classmysql.RetainerMaster();
        
        ds = rtmst.Ret_GetStatusupdate(retcode, compcode, userid, status, circular, todate, fromdate, code);
        return ds;
        }
    }


    [Ajax.AjaxMethod]
    public string insertretstatus(string compcode, string userid, string retcode, string status, string circular, string todate, string fromdate, string dateformat,string codepass)
    {
        string flag;
         DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();
       
        ds = insert.retstatuscheck(compcode, userid, retcode, status, circular, todate, fromdate, dateformat,codepass);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();

                ds = insert.retstatuscheck(compcode, userid, retcode, status, circular, todate, fromdate, dateformat, codepass);

            }
        else
        {
            NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();
       
                 ds = insert.retstatuscheck(compcode, userid, retcode, status, circular, todate, fromdate, dateformat,codepass);

        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            flag = "fail";
        }
        else
        {
            flag = "pass";

        }
        return flag;

    }

    [Ajax.AjaxMethod]
    public void insertretstatus12(string compcode, string userid, string retcode, string status, string todate, string fromdate, string circular)
    {
        string flag;
         DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();
       
        ds = insert.insertretstatus(compcode, userid, retcode, status, todate, fromdate, circular);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();

                ds = insert.insertretstatus(compcode, userid, retcode, status, todate, fromdate, circular);

            }
        else
        {
                    NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();
       
        ds = insert.insertretstatus(compcode, userid, retcode, status, todate, fromdate, circular);

        }
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }



    [Ajax.AjaxMethod]
    public DataSet Ret_StatusOperation(string userid, string compcode, string retcode, string statusname, string fromdate, string todate, string circular, string codeid, int flag)
    {   DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.RetainerMaster rtmst = new NewAdbooking.Classes.RetainerMaster();
     
        ds = rtmst.Ret_StatusOperation(userid, compcode, retcode, statusname, fromdate, todate, circular, codeid, flag);
        return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

     NewAdbooking.classesoracle .RetainerMaster rtmst = new NewAdbooking.classesoracle.RetainerMaster();
     
        ds = rtmst.Ret_StatusOperation(userid, compcode, retcode, statusname, fromdate, todate, circular, codeid, flag);
        return ds;

            }
        else
        {
            NewAdbooking.classmysql.RetainerMaster rtmst = new NewAdbooking.classmysql.RetainerMaster();
     
        ds = rtmst.Ret_StatusOperation(userid, compcode, retcode, statusname, fromdate, todate, circular, codeid, flag);
        return ds;
        }
    }
    [Ajax.AjaxMethod]
    public DataSet getstatusdetail(string retcode, string compcode, string userid, string dateformat, string txtfrom, string txtto, string codestatusid, int flag)
    {    DataSet ds = new DataSet();
    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    {
        NewAdbooking.Classes.RetainerMaster rtmst = new NewAdbooking.Classes.RetainerMaster();

        ds = rtmst.Ret_GetStatus(retcode, compcode, userid, dateformat, txtfrom, txtto, codestatusid, flag);
        return ds;
    }

    else
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RetainerMaster rtmst = new NewAdbooking.classesoracle.RetainerMaster();

            ds = rtmst.Ret_GetStatus(retcode, compcode, userid, dateformat, txtfrom, txtto, codestatusid, flag);
            return ds;
        }
    else
    {
        NewAdbooking.classmysql.RetainerMaster rtmst = new NewAdbooking.classmysql.RetainerMaster();

        ds = rtmst.Ret_GetStatus(retcode, compcode, userid, dateformat, txtfrom, txtto, codestatusid, flag);
        return ds;
    }

    }

    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {


        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //string str = "DataGrid1__ctl_CheckBox1" + j;

            ////e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  value=" + e.Item.Cells[4].Text + "  />";
            //e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return ClientSelected('" + str + "');\" value=" + e.Item.Cells[4].Text + "  />";
            //j++;

            //saurabh

            DataView dv = new DataView();


            dv = (DataView)DataGrid1.DataSource;
            DataColumnCollection dc = dv.Table.Columns;




            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                string str = "DataGrid1__ctl_CheckBox1" + j;

                e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return StatusSelect('" + str + "');\" value=" + e.Item.Cells[4].Text + "  />";
                j++;

            }

            if (e.Item.ItemType == ListItemType.Header)
            {
                if (ViewState["SortExpression"].ToString() != "")
                {
                    string str = "";
                    switch (ViewState["SortExpression"].ToString())
                    {


                        // case "STATUS_NAME":
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
                            str = "Circular No.";
                            break;

                    };
                    string strd = Convert.ToString(dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
                    strd = Convert.ToString(Convert.ToInt32(strd) - 1);
                    if (strd.Length < 2)
                        strd = "0" + strd;
                    if (ViewState["order"].ToString() == "DESC")
                    {
                        e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')  \">" + str + "</a>";

                    }
                    else
                    {
                        e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')   \">" + str + "</a>";
                    }




                }
            }


        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
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
        mycolumn1.ColumnName = "FROM_DATE";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "TO_DATE";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "STAT_CODE";
        mydatatable1.Columns.Add(mycolumn1);
        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "circular_no";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "STATUS_NAME";
        mydatatable1.Columns.Add(mycolumn1);

        myrow1 = mydatatable1.NewRow();

        myrow1["STAT_CODE"] = "0";
        myrow1["STATUS_NAME"] = drpstatus.SelectedItem.Value;
        gbstatus = drpstatus.SelectedItem.Value;


        myrow1["cust_status"] = drpstatus.SelectedItem.Text;
        gbstatusname = drpstatus.SelectedItem.Text;

        myrow1["FROM_DATE"] = txtfrom.Text;
        gbfrom = txtfrom.Text;
        myrow1["TO_DATE"] = txtto.Text;
        gbto = txtto.Text;
        //myrow1["STAT_CODE"] = txt.Text;
        //gbphone = txtphoneno.Text;
        myrow1["circular_no"] = txtcircularno.Text;
        gbcircular = txtcircularno.Text;
        //myrow1["Fax"] = txtfaxno.Text;
        //gbfax = txtfaxno.Text;

        //myrow1["EmailID"] = txtemailid.Text;
        //gbmailid = txtemailid.Text;
          int j = 0;
        if (DataGrid2.Items.Count>0)
        {
            while (j < DataGrid2.Items.Count)
            {
                string fromdate = DataGrid2.Items[j].Cells[2].Text;
                string todate = DataGrid2.Items[j].Cells[3].Text;
                if (fromdate == txtfrom.Text && todate == txtto.Text)
                {
                    string message = "Retainer Status already exist with this Date Range";
                    AspNetMessageBox(message);
                    txtfrom.Text = "";
                    txtto.Text = "";
                    return;
                }
                j++;
            }
           
        }
        mydatatable1.Rows.Add(myrow1);

        dk1.Tables.Add(mydatatable1);

        Session["retainer_stat"] = dk1;

        binddata1("status_name");
    }
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(RetainerStatusMaster), "ShowAlert", strAlert, true);
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {

        Response.Write("<script>window.close();</script>");

    }
}