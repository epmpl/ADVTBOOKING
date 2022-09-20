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

public partial class RetainerCommDetails : System.Web.UI.Page
{
    int j = 0;
    //string sortfield;
    static string fDate, tDate;
    public static int numberDiv;
    string userid, compcode, retcode, show, n_m;
    static string gbfrom, gbto, gbdiscount, gbcommrate, gbframt, gbtamt, gbaddcommrate;
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

        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
            //Response.Redirect("login.aspx");
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(RetainerCommDetails));


        show = Request.QueryString["show"].ToString();
        n_m = Request.QueryString["n_m"].ToString();

        hiddenshow.Value = show;

        hiddencompcode.Value = Session["compcode"].ToString();
        compcode = hiddencompcode.Value;

        hiddenuserid.Value = Session["userid"].ToString();
        userid = hiddenuserid.Value;

        hiddendateformat.Value = Session["dateformat"].ToString();

        hiddenretcode.Value = Request.QueryString["RetCode"].ToString();
        retcode = hiddenretcode.Value;

        btndelete.Enabled = false;
        if (hiddenretcode.Value == "")
        {
            Response.Write("<script>alert('You Should Enter The Retainer Code First');window.close();</script>");
            return;
        }


        //hiddencompcode.Value = Session["compcode"].ToString();
        //hiddenuserid.Value = Session["userid"].ToString();
        //hiddendateformat.Value = Session["dateformat"].ToString();
        //hiddenretcode.Value = Request.QueryString["Retcode"].ToString();
        //show = Request.QueryString["show"].ToString();
        //btndelete.Enabled = false;
        //if (hiddenretcode.Value == "")
        //{
        //    Response.Write("<script>alert('You Should Enter The Retainer Code First');window.close();</script>");
        //    return;
        //}

        DataSet dk = new DataSet();
        dk.ReadXml(Server.MapPath("XML/RetainerCommDetails.xml"));

        lblefffrom.Text=dk.Tables[0].Rows[0].ItemArray[0].ToString();
        lblcommrate.Text=dk.Tables[0].Rows[0].ItemArray[1].ToString();
        lblefftill.Text=dk.Tables[0].Rows[0].ItemArray[2].ToString();
        lblcommapplyon.Text=dk.Tables[0].Rows[0].ItemArray[3].ToString();
        btnSubmit.Text=dk.Tables[0].Rows[0].ItemArray[4].ToString();
        btnclear.Text=dk.Tables[0].Rows[0].ItemArray[5].ToString();
        btnclose.Text=dk.Tables[0].Rows[0].ItemArray[6].ToString();
        btndelete.Text=dk.Tables[0].Rows[0].ItemArray[7].ToString();
        lblframt.Text = dk.Tables[0].Rows[0].ItemArray[8].ToString();
        lbltoamt.Text = dk.Tables[0].Rows[0].ItemArray[9].ToString();
        lbladdcommrate.Text = dk.Tables[0].Rows[0].ItemArray[10].ToString();
        if (show == "1")
        {
            btnSubmit.Enabled = true;
            txtefffrom.Enabled = true;
            txtefftill.Enabled = true;
            txtcommrate.Enabled = true;
            txtaddcommrate.Enabled = true;
            drpcommdetail.Enabled = true;
            btndelete.Enabled = false;
            txtframt.Enabled = true;
            txttoamt.Enabled = true;
            hiddendelsau.Value = "0";

        }
        if (show == "0")
        {
            btndelete.Enabled = false;
            btnSubmit.Enabled = false;

            txtefffrom.Enabled = false;
            txtefftill.Enabled = false;
            txtcommrate.Enabled = false;
            txtaddcommrate.Enabled = false;
            drpcommdetail.Enabled = false;
            txtframt.Enabled = false;
            txttoamt.Enabled = false;

            hiddendelsau.Value = "0";

        }

        if (show == "2")
        {
            btnSubmit.Enabled = true;

            btndelete.Enabled = false;

            txtefffrom.Enabled = true;
            txtefftill.Enabled = true;
            txtcommrate.Enabled = true;
            txtaddcommrate.Enabled = true;
            drpcommdetail.Enabled = true;
            txtframt.Enabled = true;
            txttoamt.Enabled = true;
            hiddendelsau.Value = "1";

        }



        if (!Page.IsPostBack)
        {
            //binddrp();

            if (dk1.Tables.Count > 0 && Session["retainer_comm"] == null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();
            }
            if (Session["retainer_comm"] == null)
            {
                DataGrid2.Visible = false;
                Divgrid2.Visible = false;
                Divgrid1.Visible = true;
                DataGrid1.Visible = true;
                binddata("Discount");
            }
            else
            {
                DataGrid2.Visible = true;
                Divgrid2.Visible = true;
                Divgrid1.Visible = false;
                DataGrid1.Visible = false;
                binddata1("Discount");
            }
                        
            //Button Coding
            
            btnSubmit.Attributes.Add("OnClick", "javascript:return CommSubmit();");

         //   btnselect.Attributes.Add("OnClick", "javascript:return CommSelect();");
         //   btnclear.Attributes.Add("OnClick", "javascript:return CommClear();");
            
            btndelete.Attributes.Add("OnClick", "javascript:return CommDelete();");
            
            //Control Validations left undone
            btnclear.Attributes.Add("OnClick", "javascript:return popcommclear();");

            txtefffrom.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txtefftill.Attributes.Add("OnChange", "javascript:return checkdate(this);");


            //txtcommrate.Attributes.Add("OnBlur","javascript:return checkpercentage('txtcommrate');");
            //if (show == "1" || show == "2")
            //{
            //    btnSubmit.Enabled = true;
            //    btnselect.Enabled = true;
            //}
            //else
            //{
            //    btnSubmit.Enabled = false;
            //    btnselect.Enabled = false;

            //}
        }
    }

    public void binddrp()
    {
        //Dropdown Binding
        drpcommdetail.Items.Clear();
          DataSet ds = new DataSet();
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
{


        NewAdbooking.Classes.pop commdetail = new NewAdbooking.Classes.pop();
      
        ds = commdetail.commission();
             }

             else
                 if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                 {
                     NewAdbooking.classesoracle.pop commdetail = new NewAdbooking.classesoracle.pop();

                     ds = commdetail.commission();
                 }
             else
             {
                    NewAdbooking.classmysql .pop commdetail = new NewAdbooking.classmysql.pop();
      
        ds = commdetail.commission();
             }

        
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select";
        li1.Value = "0";
        li1.Selected = true;
        drpcommdetail.Items.Add(li1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                drpcommdetail.Items.Add(li);
            }
            drpcommdetail.DataBind();
        }
    }

    public void binddata(string sortfield)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster retmast = new NewAdbooking.Classes.RetainerMaster();
            
            ds1 = retmast.RetainerCommBind(hiddenretcode.Value, hiddencompcode.Value, hiddenuserid.Value, hiddendateformat.Value);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster retmast = new NewAdbooking.classesoracle.RetainerMaster();

                ds1 = retmast.RetainerCommBind(hiddenretcode.Value, hiddencompcode.Value, hiddenuserid.Value, hiddendateformat.Value);

            }
        else
        {
            NewAdbooking.classmysql.RetainerMaster retmast = new NewAdbooking.classmysql.RetainerMaster();

            ds1 = retmast.RetainerCommBind(hiddenretcode.Value, hiddencompcode.Value, hiddenuserid.Value, hiddendateformat.Value);

        }
        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        dv = ds1.Tables[0].DefaultView;
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

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Eff_from_date";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Eff_Till_date";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Comm_rate";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "COMM_CODE";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Discount";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "FROMAMOUNT";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "TOAMOUNT";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Addl_Comm_Rate";
        mydatatable.Columns.Add(mycolumn);


        
        my_row = mydatatable.NewRow();
        my_row["Eff_from_date"] = gbfrom;
        //my_row["cust_status"] = gbstatus;
        my_row["Eff_Till_date"] = gbto;
        my_row["Comm_rate"] = gbcommrate;
        my_row["COMM_CODE"] = "0";

        my_row["Discount"] = gbdiscount;

        my_row["FROMAMOUNT"] = gbframt;
        my_row["TOAMOUNT"] = gbtamt;
        my_row["Addl_Comm_Rate"] = gbaddcommrate;
        //my_row["Fax"] = gbfax;
        //my_row["EmailID"] = gbmailid;
        //my_row["Cont_Code"] = "0";
        //gbsecondcycle = txtaddate.Text;

        //  mydatatable.Rows.Add(my_row);

        ds_tbl.Tables.Add(mydatatable);

        // mydatatable.ImportRow(my_row);

        if (Session["retainer_comm"] == null)
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


        gbdiscount = "";
        gbfrom = "";
        gbto = "";
        gbcommrate = "";
        gbframt = "";
        gbtamt = "";
        gbaddcommrate = "";
        //gbstatusname = "";

        txtefffrom.Text = "";
        txtefftill.Text = "";
        txtcommrate.Text = "";
        txtaddcommrate.Text = "";
        drpcommdetail.SelectedValue = "0";
        txtframt.Text = "";
        txttoamt.Text = "";


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

    //Ajax method to check the validity of date

    [Ajax.AjaxMethod]
    public DataSet chkcommdate(string retcode, string userid, string compcode, string txtefffrom, string txtefftill)
    {

        DataSet ds = new DataSet();
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    {
        NewAdbooking.Classes.RetainerMaster rtmaster = new NewAdbooking.Classes.RetainerMaster();
        
        ds = rtmaster.checkdate(retcode, userid, compcode, txtefffrom, txtefftill);
        return ds;
             }

             else
                 if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                 {
                     NewAdbooking.classesoracle.RetainerMaster rtmaster = new NewAdbooking.classesoracle.RetainerMaster();

                     ds = rtmaster.checkdate(retcode, userid, compcode, txtefffrom, txtefftill);
                     return ds;
                 }
             else
             {
                   NewAdbooking.classmysql.RetainerMaster rtmaster = new NewAdbooking.classmysql.RetainerMaster();
        
        ds = rtmaster.checkdate(retcode, userid, compcode, txtefffrom, txtefftill);
        return ds;
             }
    }

    [Ajax.AjaxMethod]
    public DataSet chkcommdateupdate(string retcode, string userid, string compcode, string txtefffrom, string txtefftill, string code)
    {
        DataSet ds = new DataSet();
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
             {
        NewAdbooking.Classes.RetainerMaster rtmaster = new NewAdbooking.Classes.RetainerMaster();
        
        ds = rtmaster.checkdateupdate(retcode, userid, compcode, txtefffrom, txtefftill, code);
        return ds;
             }

             else
                 if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                 {
                     NewAdbooking.classesoracle.RetainerMaster rtmaster = new NewAdbooking.classesoracle.RetainerMaster();

                     ds = rtmaster.checkdateupdate(retcode, userid, compcode, txtefffrom, txtefftill, code);
                     return ds;
                 }
             else
             {
                  NewAdbooking.classmysql.RetainerMaster rtmaster = new NewAdbooking.classmysql.RetainerMaster();
        
        ds = rtmaster.checkdateupdate(retcode, userid, compcode, txtefffrom, txtefftill, code);
        return ds;
             }
    }

    [Ajax.AjaxMethod]
    public DataSet bandcomm(string retcode, string compcode, string userid, string code11, string dateformat)
    {
        //string flag;
        DataSet ds = new DataSet();
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
             {
        NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();
        
        ds = insert.selectretcomm(retcode, compcode, userid, code11, dateformat);
        return ds;
             }
             else
                 if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                 {
                     NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();

                     ds = insert.selectretcomm(retcode, compcode, userid, code11, dateformat);
                     return ds;
                 }
             else
             {
                   NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();
        
        ds = insert.selectretcomm(retcode, compcode, userid, code11, dateformat);
        return ds;
             }

    }



    //Ajax method to insert /Update the records
    [Ajax.AjaxMethod]
    public DataSet RetainerCommission(string retcode, string userid, string compcode, string txtefffrom, string txtefftill, string txtcommrate, string discount, string updatecommission, int flag,string frmamt,string toamt,string addcommrate)
    {
          DataSet ds = new DataSet();
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
             {
        NewAdbooking.Classes.RetainerMaster rtmaster = new NewAdbooking.Classes.RetainerMaster();

        ds = rtmaster.RetainerCommission(retcode, userid, compcode, txtefffrom, txtefftill, txtcommrate, discount, updatecommission, flag, frmamt, toamt, addcommrate);
        return ds;
             }

             else
                 if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                 {
                     NewAdbooking.classesoracle.RetainerMaster rtmaster = new NewAdbooking.classesoracle.RetainerMaster();

                     ds = rtmaster.RetainerCommission(retcode, userid, compcode, txtefffrom, txtefftill, txtcommrate, discount, updatecommission, flag,frmamt,toamt,addcommrate);
                     return ds;
                 }
             else
             {
                 NewAdbooking.classmysql.RetainerMaster rtmaster = new NewAdbooking.classmysql.RetainerMaster();

                 ds = rtmaster.RetainerCommission(retcode, userid, compcode, txtefffrom, txtefftill, txtcommrate, discount, updatecommission, flag, frmamt, toamt, addcommrate);
        return ds;
             }
    }

    [Ajax.AjaxMethod]
    public DataSet GetRetComm(string compcode, string userid, string retcode, string codeid, int flag)
    { 
             DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    {

        NewAdbooking.Classes.RetainerMaster rtmaster = new NewAdbooking.Classes.RetainerMaster();
   
        ds = rtmaster.getCommData(compcode, userid, retcode, codeid, flag);
        return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster rtmaster = new NewAdbooking.classesoracle.RetainerMaster();

                ds = rtmaster.getCommData(compcode, userid, retcode, codeid, flag);
                return ds;
            }
        else
        {
                    NewAdbooking.classmysql .RetainerMaster rtmaster = new NewAdbooking.classmysql.RetainerMaster();
   
        ds = rtmaster.getCommData(compcode, userid, retcode, codeid, flag);
        return ds;

        }


    }


    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        DataView dv = new DataView();
        
        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;
        
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return CommissionSelect('" + str + "');\" value=" + e.Item.Cells[5].Text + "  />";
                j++;
           
            }

            if (e.Item.ItemType == ListItemType.Header)
            {
                if (ViewState["SortExpression"].ToString() != "")
                {
                    string str = "";
                    switch (ViewState["SortExpression"].ToString())
                    {

                           
                             


                        case "Eff_from_date":
                            str = "Effective From";
                            break;

                        case "Eff_Till_date":
                            str = "Effective Till";
                            break;

                        case "COMM_CODE":
                            str = "Commission Rate";
                            break;


                        case "Discount":
                            str = "Commission Applied On";
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

    protected void  btnSubmit_Click(object sender, EventArgs e)
{
        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;

        hiddenfdate.Value = hiddenfdate.Value + txtefffrom.Text + ",";
        hiddentdate.Value = hiddentdate.Value + txtefftill.Text + ",";
        fDate = hiddenfdate.Value;
        tDate = hiddentdate.Value;

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Eff_from_date";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Eff_Till_date";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "COMM_CODE";
        mydatatable1.Columns.Add(mycolumn1);
        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Comm_rate";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Discount";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "FROMAMOUNT";
        mydatatable1.Columns.Add(mycolumn1);
       
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "TOAMOUNT";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Addl_Comm_Rate";
        mydatatable1.Columns.Add(mycolumn1);

        myrow1 = mydatatable1.NewRow();

        myrow1["COMM_CODE"] = "00";
        myrow1["Discount"] = drpcommdetail.SelectedItem.Value;
        gbdiscount = drpcommdetail.SelectedItem.Text;


        myrow1["Eff_from_date"] = txtefffrom.Text;
        gbfrom = txtefffrom.Text;
        myrow1["Eff_Till_date"] = txtefftill.Text;
        gbto = txtefftill.Text;
     
        myrow1["Comm_rate"] = txtcommrate.Text;
        gbcommrate = txtcommrate.Text;

        myrow1["Addl_Comm_Rate"] = txtaddcommrate.Text;
        gbaddcommrate = txtaddcommrate.Text;

        myrow1["FROMAMOUNT"] = txtframt.Text;
        gbframt = txtframt.Text;

        myrow1["TOAMOUNT"] = txttoamt.Text;
        gbtamt = txttoamt.Text;

        int j = 0;
        if (DataGrid2.Items.Count > 0)
        {
            while (j < DataGrid2.Items.Count)
            {
                string fromdate = DataGrid2.Items[j].Cells[0].Text;
                string todate = DataGrid2.Items[j].Cells[1].Text;
                if (todate == txtefftill.Text)
                {
                    if (txtframt.Text == DataGrid2.Items[j].Cells[7].Text && txttoamt.Text == DataGrid2.Items[j].Cells[8].Text)
                    {
                        string message = "Retainer Status already exist with this Date Range";
                        AspNetMessageBox(message);
                        txtefffrom.Text = "";
                        txtefftill.Text = "";
                        return;
                    }
                }
                j++;
            }
        }

        mydatatable1.Rows.Add(myrow1);

        dk1.Tables.Add(mydatatable1);

        Session["retainer_comm"] = dk1;

        binddata1("Discount");
    }
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(RetainerCommDetails), "ShowAlert", strAlert, true);
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>");
    }
}