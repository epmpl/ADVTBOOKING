using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class executivecommslab : System.Web.UI.Page
{

    string userid, compcode, retcode, show, n_m, gbcommrate;
    string gbfrom, gbto, gbenln, gbcommon;

    string submit = "F";
    string gbtempexecode = "";
    static DataSet dk1 = new DataSet();
    DataRow my_row;
    public static int numberDiv;
    int j = 0;
    int i = 1;
    protected void Page_Load(object sender, EventArgs e)
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

        Ajax.Utility.RegisterTypeForAjax(typeof(executivecommslab));


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




        if (show == "1")
        {

            btnSave.Enabled = true;
            txtto.Enabled = true;
            txtfrom.Enabled = true;
            txtcommrate.Enabled = true;
            drpcommon.Enabled = true;
            btndelete.Enabled = false;
            hiddendelsau.Value = "0";

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

            }
            else
            {
                DataGrid2.Visible = true;
                Divgrid2.Visible = true;
                Divgrid1.Visible = false;
                DataGrid1.Visible = false;
                binddata1();
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

    public void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvertisementMaster bind = new NewAdbooking.Classes.AdvertisementMaster();
            da = bind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(),n_m);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster bind = new NewAdbooking.classesoracle.AdvertisementMaster();
            da = bind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(),n_m);

        }
        //else
        //{
        //    NewAdbooking.classmysql.RetainerMaster bind = new NewAdbooking.classmysql.RetainerMaster();
        //    da = bind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

        //}

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
            NewAdbooking.Classes.AdvertisementMaster databind = new NewAdbooking.Classes.AdvertisementMaster();
            da = databind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(),n_m);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster databind = new NewAdbooking.classesoracle.AdvertisementMaster();
            da = databind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(),n_m);

        }
        //else
        //{
        //    NewAdbooking.classmysql.RetainerMaster databind = new NewAdbooking.classmysql.RetainerMaster();
        //    da = databind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

        //}

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
            mycolumn1.ColumnName = "TEMPEXECODE";
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
            myrow1["TEMPEXECODE"] = hiddenretcode.Value;
            gbtempexecode = hiddenretcode.Value;


            int j = 0;
            if (DataGrid2.Items.Count > 0)
            {
                while (j < DataGrid2.Items.Count)
                {
                    string fromdate = DataGrid2.Items[j].Cells[1].Text;
                    string todate = DataGrid2.Items[j].Cells[2].Text;
                    int txtfdate = Convert.ToInt32(txtfrom.Text);
                    int txttdate = Convert.ToInt32(txtto.Text);
                    int fdate = Convert.ToInt32(fromdate);
                    int tdate = Convert.ToInt32(todate);
                    //  if (Convert.ToInt32(fromdate) == Convert.ToInt32(txtfrom.Text) && Convert.ToInt32(todate) == Convert.ToInt32(txtto.Text))
                    //  if ((txtfdate >= fdate && txttdate <= tdate) || (txtfdate == fdate && txttdate > tdate)) 
                    if ((txtfdate >= fdate && txtfdate <= tdate) || (txttdate >= fdate && txttdate <= tdate)) //|| (txtfdate == fdate && txttdate > tdate)
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
        mycolumn.ColumnName = "TEMPEXECODE";
        mydatatable.Columns.Add(mycolumn);



        my_row = mydatatable.NewRow();
        my_row["ENLN"] = "0";
        my_row["FROM_DAYS"] = gbfrom;
        my_row["TILL_DAYS"] = gbto;
        my_row["COMM_ON"] =gbcommon;
        my_row["COMM_RATE"] = gbcommrate;
        my_row["COMM_TARGET_ID"] = n_m;
        my_row["TEMPEXECODE"] = gbtempexecode;
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

              string flagm = "T";
            DataSet ds_tbl1 = new DataSet();
            DataColumn mycolumn1;
            DataTable mydatatable1 = new DataTable();
            DataRow myrow1;
            for (int k = 0; k <= ds_tbl.Tables[0].Rows.Count - 1; k++)
            {
                if (ds_tbl.Tables[0].Rows[k]["TEMPEXECODE"].ToString() == retcode)
                {
                    if (flagm == "T")
                    {
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
                        mycolumn1.ColumnName = "TEMPEXECODE";
                        mydatatable1.Columns.Add(mycolumn1);
                        flagm = "F";


                  
                    }
                    myrow1 = mydatatable1.NewRow();
                    myrow1["ENLN"] = ds_tbl.Tables[0].Rows[k]["ENLN"].ToString(); ;
                    myrow1["FROM_DAYS"] = ds_tbl.Tables[0].Rows[k]["FROM_DAYS"].ToString(); ;
                    myrow1["TILL_DAYS"] = ds_tbl.Tables[0].Rows[k]["TILL_DAYS"].ToString(); ;
                    myrow1["COMM_ON"] = ds_tbl.Tables[0].Rows[k]["COMM_ON"].ToString(); ;
                    myrow1["COMM_RATE"] = ds_tbl.Tables[0].Rows[k]["COMM_RATE"].ToString(); ;
                    myrow1["COMM_TARGET_ID"] = ds_tbl.Tables[0].Rows[k]["COMM_TARGET_ID"].ToString(); ;
                    myrow1["TEMPEXECODE"] = ds_tbl.Tables[0].Rows[k]["TEMPEXECODE"].ToString(); ;
                    mydatatable1.Rows.Add(myrow1);
                   

                }
                else if (hiddenretcode.Value == ds_tbl.Tables[0].Rows[k]["TEMPEXECODE"].ToString())
                {
                    if (flagm == "T")
                    {
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
                        mycolumn1.ColumnName = "TEMPEXECODE";
                        mydatatable1.Columns.Add(mycolumn1);
                        flagm = "F";



                    }
                    myrow1 = mydatatable1.NewRow();
                    myrow1["ENLN"] = ds_tbl.Tables[0].Rows[k]["ENLN"].ToString(); ;
                    myrow1["FROM_DAYS"] = ds_tbl.Tables[0].Rows[k]["FROM_DAYS"].ToString(); ;
                    myrow1["TILL_DAYS"] = ds_tbl.Tables[0].Rows[k]["TILL_DAYS"].ToString(); ;
                    myrow1["COMM_ON"] = ds_tbl.Tables[0].Rows[k]["COMM_ON"].ToString(); ;
                    myrow1["COMM_RATE"] = ds_tbl.Tables[0].Rows[k]["COMM_RATE"].ToString(); ;
                    myrow1["COMM_TARGET_ID"] = ds_tbl.Tables[0].Rows[k]["COMM_TARGET_ID"].ToString(); ;
                    myrow1["TEMPEXECODE"] = ds_tbl.Tables[0].Rows[k]["TEMPEXECODE"].ToString(); ;
                    mydatatable1.Rows.Add(myrow1);
                   
                }

            }
            ds_tbl1.Tables.Add(mydatatable1);
              

           // ViewState["SortExpression"] = sortfield;
           // ViewState["order"] = "ASC";
            DataView dv = new DataView();
            if (ds_tbl.Tables[0].Rows.Count > 0)
            {
                dv = ds_tbl1.Tables[0].DefaultView;
            }
            else
            {
                dv = ds_tbl.Tables[0].DefaultView;
            }
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
        txtto.Text="";
        txtcommrate.Text = "";
        drpcommon.SelectedValue = "0";
       
    }

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(executivecommslab), "ShowAlert", strAlert, true);
    }

    [Ajax.AjaxMethod]
    public DataSet bindslab(string retcode, string compcode, string userid, string code11)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.AdvertisementMaster insert = new NewAdbooking.Classes.AdvertisementMaster();
            ds = insert.selectretslab(retcode, compcode, userid, code11);
            //return ds;
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster insert = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = insert.selectretslab(retcode, compcode, userid, code11);

        }
        //else
        //{
        //    NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();
        //    ds = insert.selectretslab(retcode, compcode, userid, code11);
        //}
          
        return ds;
    }
    
    [Ajax.AjaxMethod]
    public DataSet checkretslabupdate(string retcode, string compcode, string userid, string common, string commrate, string todays, string fromdays, string code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdvertisementMaster rtmst = new NewAdbooking.Classes.AdvertisementMaster();
            ds = rtmst.Ret_GetSlabupdate(retcode, compcode, userid, common, commrate, todays, fromdays, code);
            //return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.AdvertisementMaster rtmst = new NewAdbooking.classesoracle.AdvertisementMaster();
                ds = rtmst.Ret_GetSlabupdate(retcode, compcode, userid, common, commrate, todays, fromdays, code);

            }
            //else
            //{
            //    NewAdbooking.classmysql.RetainerMaster rtmst = new NewAdbooking.classmysql.RetainerMaster();
            //    ds = rtmst.Ret_GetSlabupdate(retcode, compcode, userid, common, commrate, todays, fromdays, code);
            //}
        return ds;   
    }

    [Ajax.AjaxMethod]
    public string insertretslab(string compcode, string userid, string retcode,string  todays,string fromdays ,string codepass)
    {
        string flag;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();

            ds = insert.retslabcheck(compcode, userid, retcode, todays, fromdays, codepass,"");
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();

                ds = insert.retslabcheck(compcode, userid, retcode, todays, fromdays, codepass,"");

            }
            //else
            //{
            //    NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();

            //    ds = insert.retslabcheck(compcode, userid, retcode, todays, fromdays, codepass);
            //}
          
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
    public string insertretslab33(string compcode, string userid, string retcode, string fromdays, string todays, string common, string commrate, string commid)
    {
        string flag;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdvertisementMaster insert = new NewAdbooking.Classes.AdvertisementMaster();

            ds = insert.insertretstatus_slab(compcode, userid, retcode, fromdays, todays, common, commrate, commid);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.AdvertisementMaster insert = new NewAdbooking.classesoracle.AdvertisementMaster();

                ds = insert.insertretstatus_slab(compcode, userid, retcode, fromdays, todays, common, commrate, commid);

            }
        //else
        //{
        //    NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();

        //    ds = insert.retslabcheck(compcode, userid, retcode, todays, fromdays, codepass);
        //}

        if (ds.Tables.Count > 0)
        {
            flag = "fail";
        }
        else
        {
            flag = "pass";

        }
        return flag;

    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void insertretslab12(string compcode, string userid, string retcode, string fromdays, string todays, string common, string commrate, string commid)
    {
        string flag;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdvertisementMaster insert = new NewAdbooking.Classes.AdvertisementMaster();

            ds = insert.insertretstatus_slab(compcode, userid, retcode, fromdays, todays, common, commrate, commid);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster insert = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = insert.insertretstatus_slab(compcode, userid, retcode, fromdays, todays, common, commrate, commid);

        }
        //else
        //{
        //    NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();
        //    ds = insert.insertretstatus_slab(compcode, userid, retcode, fromdays, todays, common, commrate);
        //}
        Session["retainer_slab"] = null;   
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
            ds = rtmst.Ret_StatusDeleteSlab(userid, compcode, retcode,enlncode);
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

  