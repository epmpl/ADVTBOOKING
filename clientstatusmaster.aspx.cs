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

public partial class clientstatusmaster : System.Web.UI.Page
{
    int j = 0;
    static string fDate;
    static string tDate;
    //string sortfield;
    public static int numberDiv;
    string userid, compcode, custcode, show, n_m;
    static string gbfrom, gbto, gbstatus, gbcircular, gbstatusname, gattachment;
     DataSet dk1 = new DataSet();
    DataRow my_row;
    public static int flag = 0;
    protected void Page_Load(object sender, System.EventArgs e)
    {

        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }
        if (Session["compcode"].ToString() == "" && Session["userid"].ToString() == "")
        {
            Response.Write("<script>alert('Your Session Expired Please Relogin ');</script>");
            return;
        }

        

        userid = Session["userid"].ToString();
        hiddenuserid.Value = userid;

        show = Request.QueryString["show"].ToString();
        n_m = Request.QueryString["n_m"].ToString();
        hiddenchk.Value = n_m;

        compcode = Session["compcode"].ToString();
        hiddencomcode.Value = compcode;


        custcode = Request.QueryString["custcode"].ToString();
        hiddencustcode.Value = custcode;

        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet objDataSet = new DataSet();
        // Read in the XML file
        objDataSet.ReadXml(Server.MapPath("XML/clientstatusmaster.xml"));
        lbfrom.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lbto.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        lbstatus.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        lbcircularno.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        btnsubmit.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        //btnclose.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        btndelete.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        btnclear.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        btnclose.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
        lblattachment3.Text = objDataSet.Tables[0].Rows[0].ItemArray[9].ToString();
        lblremark.Text = objDataSet.Tables[0].Rows[0].ItemArray[10].ToString();

        txtfrom.Focus();

        Ajax.Utility.RegisterTypeForAjax(typeof(clientstatusmaster));

        if (custcode != "")
        { }
        else
        {
            Response.Write("<script>alert('You Should Enter The Customer Code First ');window.close();</script>");
            return;
        }
        if (show == "1")
        {
            btnsubmit.Enabled = true;
            btnclear.Enabled = true;
            btndelete.Enabled = false;
            txtfrom.Enabled = true;
            //  txtdesignation.Enabled = true;
            txtto.Enabled = true;
            txtcircular.Enabled = true;
            drpstatus.Enabled = true;
            attachment1.Enabled = true;
        }
        else
        {
            btnsubmit.Enabled = false;
            // btnselect.Enabled = true;
            btndelete.Enabled = false;
            btnclear.Enabled = true;
            txtfrom.Enabled = false;
            //  txtdesignation.Enabled = false;
            txtto.Enabled = false;
            txtcircular.Enabled = false;
            drpstatus.Enabled = false;
            attachment1.Enabled = false;
        }
        if (!Page.IsPostBack)
        {
            statusname();
            if (dk1.Tables.Count > 0 && Session["client_stat"] == null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();
            }
            if (Session["client_stat"] == null)
            {
                DataGrid2.Visible = false;
                Divgrid2.Visible = false;
                Divgrid1.Visible = true;
                DataGrid1.Visible = true;
                binddata("status_name");
                hiddenfdate.Value = "";
                hiddentdate.Value = "";
                tDate = "";
                fDate = "";
                if (Session["dateformat"].ToString() == "dd/mm/yyyy")
                {
                    txtfrom.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");
                }
                else if (Session["dateformat"].ToString() == "mm/dd/yyyy")
                {
                    txtfrom.Text = System.DateTime.Now.Date.ToString("MM/dd/yyyy");
                }
                else
                {
                    txtfrom.Text = System.DateTime.Now.Date.ToString("yyyy/MM/dd");
                }
            }
            else
            {
                DataGrid2.Visible = true;
                Divgrid2.Visible = true;
                Divgrid1.Visible = false;
                DataGrid1.Visible = false;
                binddata1("status_name");
                hiddenfdate.Value = fDate;
                hiddentdate.Value = tDate;
            }
            btnsubmit.Attributes.Add("OnClick", "javascript:return ClientStatusSubmit123();");
            //btnSelect.Attributes.Add("OnClick", "javascript:return ClientSelected();");
            btnclear.Attributes.Add("OnClick", "javascript:return clearclick11();");
            btndelete.Attributes.Add("OnClick", "javascript:return ClientDelete();");
            //txtfrom.Attributes.Add("OnClick", "javascript:return popUpCalendar(this,Form1.txtfrom,hiddendateformat.Value);");
            txtfrom.Attributes.Add("onChange", "javascript:return Checkdate(this);");
            //txtfrom.Attributes.Add("OnkeyDown", "javascript:return false;  ");
            txtto.Attributes.Add("onChange", "javascript:return Checkdate(this);");
            //txtto.Attributes.Add("OnClick", "javascript:return popUpCalendar(this,Form1.txtto,hiddendateformat.Value);");
            //txtto.Attributes.Add("OnkeyDown", "javascript:return false;  ");
            btnclose.Attributes.Add("OnClick", "javascript:return closewindow();");
            attachment1.Attributes.Add("OnClick", "javascript:return openattach3();");
            txtto.Attributes.Add("OnChange", "javascript:return checkdateforcurr(this);  ");
        }

    }
    public string ConvertToDateTime(string strDateTime)
    {
        string dtFinaldate; string sDateTime;
        if (strDateTime != "")
        {
            string hddndateformat = Session["DateFormat"].ToString();
            try
            {
                if (hddndateformat == "dd/mm/yyyy")
                {
                    string[] sDate = strDateTime.Split('/');
                    sDateTime = sDate[2] + '/' + sDate[0] + '/' + sDate[1];
                    dtFinaldate = sDateTime;
                }
                else
                {
                    dtFinaldate = Convert.ToDateTime(strDateTime).ToString();
                }
            }
            catch (Exception e)
            {
                string[] sDate = strDateTime.Split('/');
                sDateTime = sDate[2] + '/' + sDate[0] + '/' + sDate[1];
                dtFinaldate = sDateTime;
            }
            return dtFinaldate;
        }
        else
        {
            return "";
        }
    }
    public void statusname()
    {
        drpstatus.Items.Clear();
         DataSet ds = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Classes.ClientMasterpopup name = new NewAdbooking.Classes.ClientMasterpopup();
             ds = name.addstatusname(compcode);
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.classesoracle.ClientMasterpopup name = new NewAdbooking.classesoracle.ClientMasterpopup();
             ds = name.addstatusname(compcode);
         }
         else
         {
             NewAdbooking.classmysql.ClientMasterpopup name = new NewAdbooking.classmysql.ClientMasterpopup();
             ds = name.addstatusname(compcode);
         }
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "-----Select Status-----";
            li1.Value = "0";
          //  li1.Selected = true;
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
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientMasterpopup databind = new NewAdbooking.Classes.ClientMasterpopup();
            da = databind.clientstatusbind(custcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMasterpopup databind = new NewAdbooking.classesoracle.ClientMasterpopup();
            da = databind.clientstatusbind(custcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.ClientMasterpopup databind = new NewAdbooking.classmysql.ClientMasterpopup();
            da = databind.clientstatusbind(custcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

        }
        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        dv = da.Tables[0].DefaultView;
        dv.Sort = sortfield;
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
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "cust_status";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
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
        mycolumn.ColumnName = "circular";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "attachment";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "status_name";
        mydatatable.Columns.Add(mycolumn);

        my_row = mydatatable.NewRow();
        my_row["status_name"] = gbstatusname;
        my_row["cust_status"] = gbstatus;
        my_row["FROM_DATE"] = gbfrom;
        my_row["TO_DATE"] = gbto;
        my_row["STAT_CODE"] = "0";
        my_row["circular"] = gbcircular;
        my_row["attachment"] = gattachment;
        //my_row["EmailID"] = gbmailid;
        //my_row["Cont_Code"] = "0";
        //gbsecondcycle = txtaddate.Text;

        //  mydatatable.Rows.Add(my_row);

        ds_tbl.Tables.Add(mydatatable);

        // mydatatable.ImportRow(my_row);

        if (Session["client_stat"] == null)
        {
            ds_tbl.Tables.Add(mydatatable);
            DataGrid2.DataSource = ds_tbl.Tables[0];
            DataGrid2.DataBind();
        }
        else
        {
            int d;
            int g;
            DataSet dsnew = new DataSet();
            dsnew = (DataSet)Session["client_stat"];
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
        txtcircular.Text = "";
     //   drpstatus.SelectedValue = "0";
        gattachment = "";


    }



    private void DataGrid1_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        DataView dv = new DataView();


        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;




        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return ClientSelected('" + str + "');\" value=" + e.Item.Cells[4].Text + "  />";
            j++;

        }

        if (e.Item.ItemType == ListItemType.Header)
        {
            if (ViewState["SortExpression"].ToString() != "")
            {
                string str = "";
                switch (ViewState["SortExpression"].ToString())
                {


                    case "status_name":
                        str = "Status";
                        break;

                    case "FROM_DATE":
                        str = "From Date";
                        break;

                    case "TO_DATE":
                        str = "To Date";
                        break;


                    case "Circular":
                        str = "Circular No.";
                        break;

                };
                string strd = Convert.ToString(dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
                strd = Convert.ToString(Convert.ToInt32(strd) - 1);
                if (strd.Length < 2)
                    strd = "0" + strd;
                if(ViewState["order"].ToString()=="DESC")
                {
                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')  \">"+ str +"</a>";

                }	
                else
                {
                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')   \">"+ str +"</a>";
                }

						
					
 
            } 
        }


    }




    [Ajax.AjaxMethod]
    public string submitstatus(string status, string fromdate1, string todate1, string custcode, string compcode, string userid, string update, string dateformat, string circular)
    {
        string flag;
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientMasterpopup statusup = new NewAdbooking.Classes.ClientMasterpopup();
            da = statusup.statusupdate(status, fromdate1, todate1, compcode, userid, custcode, update, dateformat, circular);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMasterpopup statusup = new NewAdbooking.classesoracle.ClientMasterpopup();
            da = statusup.statusupdate(status, fromdate1, todate1, compcode, userid, custcode, update, dateformat, circular);
        }
        else
        {
            NewAdbooking.classmysql.ClientMasterpopup statusup = new NewAdbooking.classmysql.ClientMasterpopup();
            da = statusup.statusupdate(status, fromdate1, todate1, compcode, userid, custcode, update, dateformat, circular);

        }
        if (da.Tables[0].Rows.Count > 0)
        {
            flag = "true";
        }
        else
        {
            flag = "false";
        }
        return flag;

    }



    [Ajax.AjaxMethod]
    public void submitstatus11(string status, string fromdate, string todate, string compcode, string userid, string custcode, string update, string circular,string attach, string remark)
    {
        DataSet dr = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientMasterpopup statusup = new NewAdbooking.Classes.ClientMasterpopup();
            dr = statusup.statusupdate11(status, fromdate, todate, compcode, userid, custcode, update, circular,attach, remark);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMasterpopup statusup = new NewAdbooking.classesoracle.ClientMasterpopup();
            dr = statusup.statusupdate11(status, fromdate, todate, compcode, userid, custcode, update, circular,attach,remark);
        }
        else
        {
            NewAdbooking.classmysql.ClientMasterpopup statusup = new NewAdbooking.classmysql.ClientMasterpopup();
            dr = statusup.statusupdate11(status, fromdate, todate, compcode, userid, custcode, update, circular);

        }
             DataGrid1.DataSource = dr;
        DataGrid1.DataBind();
    }

    //[Ajax.AjaxMethod]
    //public void deduce_status(string status,string compcode)
    //{
    //    NewAdbooking.Classes.ClientMasterpopup status_deduce = new NewAdbooking.Classes.ClientMasterpopup();
    //    DataSet dr = new DataSet();
    //    dr = statusup.status_name_call(status,compcode);
    //}



    [Ajax.AjaxMethod]
    public string insertstatus(string status, string fromdate, string todate, string custcode, string compcode, string userid, string dateformat, string circular)
    {
        string flag;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientMasterpopup statusinsert = new NewAdbooking.Classes.ClientMasterpopup();
            ds = statusinsert.insertstatus(status, fromdate, todate, custcode, compcode, userid, dateformat, circular);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMasterpopup statusinsert = new NewAdbooking.classesoracle.ClientMasterpopup();
            ds = statusinsert.insertstatus(status, fromdate, todate, custcode, compcode, userid, dateformat, circular);
        }
        else
        {
            NewAdbooking.classmysql.ClientMasterpopup statusinsert = new NewAdbooking.classmysql.ClientMasterpopup();
            ds = statusinsert.insertstatus(status, fromdate, todate, custcode, compcode, userid, dateformat, circular);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            flag = "true";
        }
        else
        {
            flag = "false";
        }
        return flag;
    }




    [Ajax.AjaxMethod]
    public void insertstatus11(string status, string fromdate, string todate, string custcode, string compcode, string userid, string circular,string attach,string remark)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientMasterpopup statusinsert = new NewAdbooking.Classes.ClientMasterpopup();
            ds = statusinsert.insertstatus11(status, fromdate, todate, custcode, compcode, userid, circular, attach,remark);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMasterpopup statusinsert = new NewAdbooking.classesoracle.ClientMasterpopup();
            ds = statusinsert.insertstatus11(status, fromdate, todate, custcode, compcode, userid, circular, attach,remark);
        }
        else
        {
            string procedureName = "sp_insertclientstatus";
            string[] parameterValueArray = new string[] { custcode, status, ConvertToDateTime(fromdate), ConvertToDateTime(todate), userid, compcode, circular, attach, remark };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            /*

            NewAdbooking.classmysql.ClientMasterpopup statusinsert = new NewAdbooking.classmysql.ClientMasterpopup();
            ds = statusinsert.insertstatus11(status, fromdate, todate, custcode, compcode, userid, circular);
             * */
        }
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }//





    [Ajax.AjaxMethod]
    public DataSet bandstatus(string custcode, string compcode, string userid, string code11, string dateformat)
    {
          DataSet da = new DataSet();
          if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
          {
              NewAdbooking.Classes.ClientMasterpopup statusdatabind = new NewAdbooking.Classes.ClientMasterpopup();
              da = statusdatabind.clientstatusbind12(custcode, compcode, userid, code11, dateformat);
              return da;
          }
          else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
          {
              NewAdbooking.classesoracle.ClientMasterpopup statusdatabind = new NewAdbooking.classesoracle.ClientMasterpopup();
              da = statusdatabind.clientstatusbind12(custcode, compcode, userid, code11, dateformat);
              return da;
          }
          else
          {
              NewAdbooking.classmysql.ClientMasterpopup statusdatabind = new NewAdbooking.classmysql.ClientMasterpopup();
              da = statusdatabind.clientstatusbind12(custcode, compcode, userid, code11, dateformat);
              return da;
          }
    }




    [Ajax.AjaxMethod]
    public DataSet deletestatus(string custcode, string compcode, string userid, string delete1)
    {
        DataSet da = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientMasterpopup statusdelete = new NewAdbooking.Classes.ClientMasterpopup();
            da = statusdelete.clientstatusdelete(custcode, compcode, userid, delete1);
            return da;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMasterpopup statusdelete = new NewAdbooking.classesoracle.ClientMasterpopup();
            da = statusdelete.clientstatusdelete(custcode, compcode, userid, delete1);
            return da;
        }
        else
        {
            NewAdbooking.classmysql.ClientMasterpopup statusdelete = new NewAdbooking.classmysql.ClientMasterpopup();
            da = statusdelete.clientstatusdelete(custcode, compcode, userid, delete1);
            return da;
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

        this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound_1);

    }
    #endregion



    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;
        //if ((dk1.Tables.Count != 0))
        //{
        //    int j;
        //    for (j = 0; j < dk1.Tables[0].Rows.Count; j++)
        //    {
        //        if (txtfrom.Text>=dk1.Tables[0].Rows[j].ItemArray[1].ToString())
        //        {
        //            message = "Contact Name has been submitted already";
        //            AspNetMessageBox(message);
        //            flag = 1;

        //        }
        //        else
        //        {
        //            flag = 0;
        //        }

        //    }

        //}

        //if (flag == 0)
        //{

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
        mycolumn1.ColumnName = "circular";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "status_name";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "attachment";
        mydatatable1.Columns.Add(mycolumn1);

        myrow1 = mydatatable1.NewRow();

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "remarks";
        mydatatable1.Columns.Add(mycolumn1);



        myrow1["STAT_CODE"] = "00";
        myrow1["status_name"] = drpstatus.SelectedItem.Text;
        gbstatusname = drpstatus.SelectedItem.Text;
        myrow1["cust_status"] = drpstatus.SelectedValue;
        gbstatus = drpstatus.SelectedValue;

        myrow1["FROM_DATE"] = txtfrom.Text;
        gbfrom = txtfrom.Text;
        myrow1["TO_DATE"] = txtto.Text;
        gbto = txtto.Text;
        //myrow1["STAT_CODE"] = txt.Text;
        //gbphone = txtphoneno.Text;
        myrow1["circular"] = txtcircular.Text;
        gbcircular = txtcircular.Text;
        //myrow1["Fax"] = txtfaxno.Text;
        //gbfax = txtfaxno.Text;

        myrow1["attachment"] = hidattach1.Value;
        gattachment = hidattach1.Value;

        myrow1["remarks"] = txtremark.Text;
        //gbmailid = txtemailid.Text;


        mydatatable1.Rows.Add(myrow1);
        if (Session["client_stat"] != null)
        {
            DataSet dsnew = new DataSet();
            dsnew = (DataSet)Session["client_stat"];
            dk1 = dsnew;
        }
        dk1.Tables.Add(mydatatable1);

        Session["client_stat"] = dk1;

        binddata1("status_name");
        //}
    }

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(clientstatusmaster), "ShowAlert", strAlert, true);
    }

    protected void DataGrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        binddata("status_name");
    }
}