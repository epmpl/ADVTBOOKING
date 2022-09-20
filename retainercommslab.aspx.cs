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

public partial class retainercommslab : System.Web.UI.Page
{
    string userid, compcode, retcode, show, n_m, gbcommrate, gbagency_type, gbagency_type_value;
    string gbfrom, gbto, gbenln, gbcommon;
    static DataSet dk1 = new DataSet();
    DataRow my_row;
    public static int numberDiv;
    int j = 0;
    int i = 1;
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

        Ajax.Utility.RegisterTypeForAjax(typeof(retainercommslab));


        show = Request.QueryString["show"].ToString();
        n_m = Request.QueryString["n_m"].ToString();
        hdntargetid.Value = Request.QueryString["n_m"].ToString();

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
        dk.ReadXml(Server.MapPath("XML/retainercommslab.xml"));

        lblfromdate.Text = dk.Tables[0].Rows[0].ItemArray[0].ToString();
        lblstatus.Text = dk.Tables[0].Rows[0].ItemArray[1].ToString();

        lbltodate.Text = dk.Tables[0].Rows[0].ItemArray[2].ToString();

        lblcircular.Text = dk.Tables[0].Rows[0].ItemArray[3].ToString();

        btnSave.Text = dk.Tables[0].Rows[0].ItemArray[4].ToString();


        btnclear.Text = dk.Tables[0].Rows[0].ItemArray[5].ToString();

        btnclose.Text = dk.Tables[0].Rows[0].ItemArray[6].ToString();

        btndelete.Text = dk.Tables[0].Rows[0].ItemArray[7].ToString();
        lblagencytype.Text = dk.Tables[0].Rows[0].ItemArray[8].ToString();




        if (show == "1")
        {

            btnSave.Enabled = true;
            txtto.Enabled = true;
            txtfrom.Enabled = true;
            txtcommrate.Enabled = true;
            drpcommon.Enabled = true;
            btndelete.Enabled = false;
            hiddendelsau.Value = "0";
            drpagentyp.Enabled = true;

        }
        if (show == "0")
        {

            btndelete.Enabled = false;
            //   txtcontactperson.Enabled = false;
            btnSave.Enabled = false;
            txtto.Enabled = false;
            txtfrom.Enabled = false;
            txtcommrate.Enabled = false;
            drpcommon.Enabled = false;
            hiddendelsau.Value = "0";
            drpagentyp.Enabled = false;

        }

        if (show == "2")
        {
            btnSave.Enabled = true;

            btndelete.Enabled = false;
            //btnsubmit.Enabled = true;
            //btndelete.Enabled = true;
            txtto.Enabled = true;
            txtfrom.Enabled = true;
            txtcommrate.Enabled = true;
            drpcommon.Enabled = true;
            hiddendelsau.Value = "1";
            drpagentyp.Enabled = true;

        }

        if (!Page.IsPostBack)
        {

            if (dk1.Tables.Count > 0 && Session["retainer_slab"] == null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();
            }
            if (Session["retainer_slab"] == null)
            {
                DataGrid2.Visible = false;
                Divgrid2.Visible = false;
                Divgrid1.Visible = true;
                DataGrid1.Visible = true;
                DataGrid1.DataSource = "";
                DataGrid1.DataBind();
                binddata();
                bindagencytyp();

            }
            else
            {
                DataGrid2.Visible = true;
                Divgrid2.Visible = true;
                Divgrid1.Visible = false;
                DataGrid1.Visible = false;
                binddata1();
                bindagencytyp();
            }


            ////Button Coding
            btnSave.Attributes.Add("OnClick", "javascript:return RetcomslabSubmit();");
            //// btnselect.Attributes.Add("OnClick", "javascript:return StatusSelect();");
            btnclear.Attributes.Add("OnClick", "javascript:return PopSlabClear();");
            btndelete.Attributes.Add("OnClick", "javascript:return RetSlabDelete();");

            //Control Validations left undone

            //txtfrom.Attributes.Add("OnChange", "javascript:return checkdate_new(this);");
            //txtto.Attributes.Add("OnChange", "javascript:return checkdate_new(this);");




        }

    }


    public void bindagencytyp()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master agent = new NewAdbooking.Classes.Master();
            drpagentyp.Items.Clear();
            ds = agent.addagent_typ(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Master agent = new NewAdbooking.classesoracle.Master();
                drpagentyp.Items.Clear();
                ds = agent.addagent_typ(Session["userid"].ToString(), Session["compcode"].ToString());

            }
            else
            {
                //NewAdbooking.classmysql.Master agent = new NewAdbooking.classmysql.Master();
                //drpagentyp.Items.Clear();
                //ds = agent.addagent_typ(Session["userid"].ToString(), Session["compcode"].ToString());
            }

        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpagentyp.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drpagentyp.Items.Add(li);
            }

        }

    }




    public void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.RetainerMaster bind = new NewAdbooking.Classes.RetainerMaster();
            da = bind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), n_m);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RetainerMaster bind = new NewAdbooking.classesoracle.RetainerMaster();
            da = bind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), n_m);

        }
        else
        {
            NewAdbooking.classmysql.RetainerMaster bind = new NewAdbooking.classmysql.RetainerMaster();
            da = bind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

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




    public void binddata()
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster databind = new NewAdbooking.Classes.RetainerMaster();
            da = databind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), n_m);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RetainerMaster databind = new NewAdbooking.classesoracle.RetainerMaster();
            da = databind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), n_m);

        }
        else
        {
            NewAdbooking.classmysql.RetainerMaster databind = new NewAdbooking.classmysql.RetainerMaster();
            da = databind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

        }

        //ViewState["SortExpression"] = sortfield;
        //ViewState["order"] = "ASC";
        DataView dv = new DataView();
        if (da.Tables.Count > 0)
        {
            dv = da.Tables[0].DefaultView;
            //dv.Sort = sortfield;
            //foreach (DataRowView dr in da.Tables[0].Rows)
            //{
            //    string totalc = dr["COMM_TARGET_ID"].ToString();

            //    if (totalc != n_m)
            //    {
            //        dr.Delete();
            //    }
            //}
            da.Tables[0].AcceptChanges();
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["hdnflag"] == "T")
        {

            Session["hdnflag"] = null;
            DataColumn mycolumn1;
            DataTable mydatatable1 = new DataTable();
            DataRow myrow1;

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "ENLN";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "FROM_DAYS";
            mydatatable1.Columns.Add(mycolumn1);

            // //DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "TILL_DAYS";
            mydatatable1.Columns.Add(mycolumn1);

            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "COMM_ON";
            mydatatable1.Columns.Add(mycolumn1);
            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "COMM_RATE";
            mydatatable1.Columns.Add(mycolumn1);

            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "COMM_TARGET_ID";
            mydatatable1.Columns.Add(mycolumn1);



            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "AGENCY_TYPE";
            mydatatable1.Columns.Add(mycolumn1);


            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "AGENCY_TYPE_CODE";
            mydatatable1.Columns.Add(mycolumn1);


      


            myrow1 = mydatatable1.NewRow();

            myrow1["ENLN"] = "0";
            //gbenln = Convert.ToInt32(i).ToString() ;

            myrow1["FROM_DAYS"] = txtfrom.Text;
            gbfrom = txtfrom.Text;

            myrow1["TILL_DAYS"] = txtto.Text;
            gbto = txtto.Text;

            myrow1["COMM_ON"] = drpcommon.SelectedItem.Value;
            gbcommon = drpcommon.SelectedItem.Text;

            myrow1["COMM_RATE"] = txtcommrate.Text;
            gbcommrate = txtcommrate.Text;

            myrow1["COMM_TARGET_ID"] = n_m;

            if (drpagentyp.SelectedItem.Text == "--Select--")
            {

                myrow1["AGENCY_TYPE"] ="";
                gbagency_type = "";
            }
            else
            {

                myrow1["AGENCY_TYPE"] = drpagentyp.SelectedItem.Text;
                gbagency_type = drpagentyp.SelectedItem.Text;
            }

            myrow1["AGENCY_TYPE_CODE"] = drpagentyp.SelectedItem.Value;
            gbagency_type_value = drpagentyp.SelectedItem.Value;





            int j = 0;
            if (DataGrid2.Items.Count > 0)
            {
                while (j < DataGrid2.Items.Count)
                {
                    string fromdate = DataGrid2.Items[j].Cells[1].Text;
                    string todate = DataGrid2.Items[j].Cells[2].Text;
                   string agency_type123 = DataGrid2.Items[j].Cells[6].Text;
                     
                    
                    int txtfdate = 0;

                    if (txtfrom.Text == "")
                    {
                         txtfdate = 0;
                    }
                    else
                    {
                         txtfdate = Convert.ToInt32(txtfrom.Text);
                    }


                   
                    
                    
                    
                    int txttdate = 0;
                    if (txtto.Text == "")
                    {
                        txttdate = 0;
                    }
                    else
                    {
                        txttdate = Convert.ToInt32(txtto.Text);
                    }




                    if (fromdate == "&nbsp;")
                    {
                        fromdate = "0";
                    }
                    if (todate == "&nbsp;")
                    {
                        todate = "0";
                    }

                    int fdate = Convert.ToInt32(fromdate);
                    int tdate = Convert.ToInt32(todate);



                    //  if (Convert.ToInt32(fromdate) == Convert.ToInt32(txtfrom.Text) && Convert.ToInt32(todate) == Convert.ToInt32(txtto.Text))
                    //  if ((txtfdate >= fdate && txttdate <= tdate) || (txtfdate == fdate && txttdate > tdate)) 
                    if ((txtfdate >= fdate && txtfdate <= tdate) || (txttdate >= fdate && txttdate <= tdate) || (agency_type123 == drpagentyp.SelectedItem.Text)) //|| (txtfdate == fdate && txttdate > tdate)
                    {
                        string message = "Retainer Slab already exist with this Day Range";
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

            Session["retainer_slab"] = dk1;

            binddata1();
        }
        else
        {
            Session["retainer_slab"] = dk1;
            binddata1();
            gbfrom = "";
            gbto = "";

            gbcommon = "";
            gbcommrate = "";
            txtfrom.Text = "";
            txtto.Text = "";
            txtcommrate.Text = "";
            drpcommon.SelectedValue = "0";

        }
    }



    public void binddata1()
    {
        DataGrid2.Visible = true;
        Divgrid2.Visible = true;
        DataGrid1.Visible = false;
        Divgrid1.Visible = false;

        DataSet ds_tbl = new DataSet();
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();


        // DataRow myrow;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "ENLN";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "FROM_DAYS";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn1;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "TILL_DAYS";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn1;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "COMM_ON";
        mydatatable.Columns.Add(mycolumn);
        ////DataColumn mycolumn1;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "COMM_RATE";
        mydatatable.Columns.Add(mycolumn);
        ////DataColumn mycolumn1;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "COMM_TARGET_ID";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "AGENCY_TYPE";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "AGENCY_TYPE_CODE";
        mydatatable.Columns.Add(mycolumn);



     


      my_row = mydatatable.NewRow();


        my_row["ENLN"] = "0";
        my_row["FROM_DAYS"] = gbfrom;
        my_row["TILL_DAYS"] = gbto;
        my_row["COMM_ON"] = gbcommon;
        my_row["COMM_RATE"] = gbcommrate;
        my_row["COMM_TARGET_ID"] = n_m;

     
            my_row["AGENCY_TYPE"] = gbagency_type;
      
        my_row["AGENCY_TYPE_CODE"] = gbagency_type_value;
        ds_tbl.Tables.Add(mydatatable);

        // mydatatable.ImportRow(my_row);

        if (Session["retainer_slab"] == null)
        {
            ds_tbl.Tables.Add(mydatatable);
            if (ds_tbl.Tables[0].Rows[0]["COMM_TARGET_ID"].ToString() == n_m)
            {
                DataGrid2.DataSource = ds_tbl.Tables[0];
                DataGrid2.DataBind();
            }
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
                my_row = dk1.Tables[d].Rows[0];
                mydatatable.ImportRow(my_row);

            }

            // ViewState["SortExpression"] = sortfield;
            // ViewState["order"] = "ASC";
            DataView dv = new DataView();
            dv = ds_tbl.Tables[0].DefaultView;
            // dv.Sort = sortfield;

            //DataSet ds = new DataSet();
            //ds = (DataSet)ds_tbl.Tables[0].DefaultView;
            foreach (DataRowView dr in dv)
            {
                string commid = dr["COMM_TARGET_ID"].ToString();

                if (commid != n_m)
                {
                    dr.Delete();
                }
            }
            DataGrid2.DataSource = dv;
            DataGrid2.DataBind();
            d = 0;

        }


        gbfrom = "";
        gbto = "";
        //gbenln = "";
        gbcommon = "";
        gbcommrate = "";
        txtfrom.Text = "";
        txtto.Text = "";
        txtcommrate.Text = "";
        drpcommon.SelectedValue = "0";
        gbagency_type = "";
        drpagentyp.SelectedValue = "0";



    }

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(retainercommslab), "ShowAlert", strAlert, true);
    }

    [Ajax.AjaxMethod]
    public DataSet bindslab(string retcode, string compcode, string userid, string code11)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();
            ds = insert.selectretslab(retcode, compcode, userid, code11);
            //return ds;
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();
            ds = insert.selectretslab(retcode, compcode, userid, code11);

        }
        else
        {
            NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();
            ds = insert.selectretslab(retcode, compcode, userid, code11);
        }

        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet checkretslabupdate(string retcode, string compcode, string userid, string common, string commrate, string todays, string fromdays, string code,string agency_type)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster rtmst = new NewAdbooking.Classes.RetainerMaster();
            ds = rtmst.Ret_GetSlabupdate(retcode, compcode, userid, common, commrate, todays, fromdays, code,agency_type);
            //return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster rtmst = new NewAdbooking.classesoracle.RetainerMaster();
                ds = rtmst.Ret_GetSlabupdate(retcode, compcode, userid, common, commrate, todays, fromdays, code,agency_type);

            }
            else
            {
                NewAdbooking.classmysql.RetainerMaster rtmst = new NewAdbooking.classmysql.RetainerMaster();
                ds = rtmst.Ret_GetSlabupdate(retcode, compcode, userid, common, commrate, todays, fromdays, code);
            }
        return ds;
    }

    [Ajax.AjaxMethod]
    public string insertretslab(string compcode, string userid, string retcode, string todays, string fromdays, string codepass,string agency_type)
    {
        string flag;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();

            ds = insert.retslabcheck(compcode, userid, retcode, todays, fromdays, codepass,agency_type);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();

                ds = insert.retslabcheck(compcode, userid, retcode, todays, fromdays, codepass, agency_type);

            }
            else
            {
                NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();

                ds = insert.retslabcheck(compcode, userid, retcode, todays, fromdays, codepass);
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
    public void insertretslab12(string compcode, string userid, string retcode, string fromdays, string todays, string common, string commrate, string commid,string agency_type)
    {
        string flag;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();

            ds = insert.insertretstatus_slab(compcode, userid, retcode, fromdays, todays, common, commrate, commid, agency_type);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();
            ds = insert.insertretstatus_slab(compcode, userid, retcode, fromdays, todays, common, commrate, commid, agency_type);

        }
        else
        {
            NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();
            ds = insert.insertretstatus_slab(compcode, userid, retcode, fromdays, todays, common, commrate);
        }

        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }

    [Ajax.AjaxMethod]
    public DataSet Ret_StatusDeleteSlab(string userid, string compcode, string retcode, string enlncode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster rtmst = new NewAdbooking.Classes.RetainerMaster();
            ds = rtmst.Ret_StatusDeleteSlab(userid, compcode, retcode, enlncode);
            //return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.RetainerMaster rtmst = new NewAdbooking.classesoracle.RetainerMaster();
            ds = rtmst.Ret_StatusDeleteSlab(userid, compcode, retcode, enlncode);


        }
        else
        {
            NewAdbooking.classmysql.RetainerMaster rtmst = new NewAdbooking.classmysql.RetainerMaster();
            ds = rtmst.Ret_StatusDeleteSlab(userid, compcode, retcode, enlncode);
        }
        return ds;

    }

    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>");

    }



    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataView dv = new DataView();
            dv = (DataView)DataGrid1.DataSource;
            DataColumnCollection dc = dv.Table.Columns;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                string str = "DataGrid1__ctl_CheckBox1" + j;
                e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return SlabSelect('" + str + "');\" value=" + e.Item.Cells[1].Text + "  />";
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
                        case "ENLN":
                            str = "Elno";
                            break;

                        case "FROM_DAYS":
                            str = "From Days";
                            break;

                        case "TILL_DAYS":
                            str = "Till Days";
                            break;


                        case "COMM_ON":
                            str = "COMM. ON.";
                            break;

                        case "COMM_RATE":
                            str = "COMM. RATE";
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

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setviewstatevalue()
    {
        Session["hdnflag"] = "T";
    }
}
