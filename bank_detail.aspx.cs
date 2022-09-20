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

public partial class bank_detail : System.Web.UI.Page
{
    string agencode, agencysubcode, gattachment;
    public static int numberDiv;
    string show;
    int j;
     DataSet dk1 = new DataSet();
     DataSet dk = new DataSet();
    DataRow my_row;
    static string gbBG_NO, gbBG_DATE, gbAMOUNT, gbBANK_NAME, gbVALIDITY_DATE;


    DateTime[] sdfr;// = Convert.ToDateTime(txtefffrom.Text);
    string[] dateto;
    DateTime[] sdto;
    static int i;
    string message;


    protected void Page_Load(object sender, System.EventArgs e)
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

        //************************************Read XML****************
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/bank_detail.xml"));
        BGNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        Amount.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        Bank.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        BGDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        ValidityDate.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        btnSubmit.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        btnclear.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        btndelete.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        Label1.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        btnclose.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();


        //***********************************************************


        agencode = Request.QueryString["agecode"].ToString();

        hiddenagevcode.Value = Request.QueryString["agecode"].ToString();


        agencysubcode = Request.QueryString["agencysubcode"].ToString();
        hiddenagensubcode.Value = Request.QueryString["agencysubcode"].ToString();

        //Button1.Attributes.Add("OnClick","javascript:return validate()");
        Ajax.Utility.RegisterTypeForAjax(typeof(bank_detail));



        if (agencode != "" && agencysubcode != "")
        { }
        else
        {
            Response.Write("<script>alert('You Should Enter The Agency Code First And Sub Code');window.close();</script>");

            return;
        }

        //if (Session["bankdetail"] != null)
        //{
        //    bindgrid1("BG_DATE");
        //}

        if (show == "2")
        {
            btnSubmit.Enabled = true;
            btndelete.Enabled = true;
            txtamount.Enabled = true;
            txtbank.Enabled = true;
            txtbgdate.Enabled = true;
            txtbgno.Enabled = true;
            txtvaliditydate.Enabled = true;
            attachment1.Enabled = true;


        }
        if (show == "1")
        {
            btnSubmit.Enabled = true;
            btndelete.Enabled = false;
            txtamount.Enabled = true;
            txtbank.Enabled = true;
            txtbgdate.Enabled = true;
            txtbgno.Enabled = true;
            txtvaliditydate.Enabled = true;
            attachment1.Enabled = true;

        }
        if(show=="0")
        {
            btnSubmit.Enabled = false;
            btndelete.Enabled = false;
            txtamount.Enabled = false;
            txtbank.Enabled = false;
            txtbgdate.Enabled = false;
            txtbgno.Enabled = false;
            txtvaliditydate.Enabled = false;
            attachment1.Enabled = false;

           


        }
        if (!Page.IsPostBack)
        {
            if (dk1.Tables.Count > 0 && Session["bankdetail"]==null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();

                //dk.Clear();
                //dk.Dispose();
                dk = new DataSet();
            }
            //if (Session["agencode"] != "" || Session["agencode"] != null)
            ////if (hiddencentcode.Value != "")
            //{
            //    DataGrid2.Visible = false;
            //    DIV2.Visible = false;
            //    DIV1.Visible = true;
            //    DataGrid1.Visible = true;
            //    bindgrid("BG_DATE");
            //}
            //else
            //{
            //    DataGrid2.Visible = true;
            //    DIV2.Visible = true;
            //    DIV1.Visible = false;
            //    DataGrid1.Visible = false;
            //    bindgrid1("BG_DATE");
            //}

            if (Session["bankdetail"] == null || Session["bankdetail"] == "")
            //if (hiddencentcode.Value != "")
            {
                DataGrid2.Visible = false;
                DIV2.Visible = false;
                DIV1.Visible = true;
                DataGrid1.Visible = true;
                bindgrid("BG_DATE");
            }
            else
            {
                DataGrid2.Visible = true;
                DIV2.Visible = true;
                DIV1.Visible = false;
                DataGrid1.Visible = false;
                bindgrid1("BG_DATE");

            }
            

            btnSubmit.Attributes.Add("OnClick", "javascript:return submitbank();");
            //btnclose.Attributes.Add("OnClick", "javascript:return selectbank();");
            txtbank.Attributes.Add("OnChange", "javascript:return uppercase7();");
            txtbgdate.Attributes.Add("onChange", "javascript:return checkdate(this);  ");
            txtvaliditydate.Attributes.Add("onChange", "javascript:return checkdate(this);  ");
            btnclear.Attributes.Add("OnClick", "javascript:return cleardata('bank');");
            btndelete.Attributes.Add("OnClick", "javascript:return deletebank();");
            txtamount.Attributes.Add("OnChange", "javascript:return allamount122();");
            attachment1.Attributes.Add("OnClick", "javascript:return openattach123();");
            bindgrid("BG_DATE");


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

    }
    #endregion

	

    public void band()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop databindcomm = new NewAdbooking.Classes.pop();
            ds = databindcomm.bankbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop databindcomm = new NewAdbooking.classesoracle.pop();
            ds = databindcomm.bankbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        else
        {
            NewAdbooking.classmysql.pop databindcomm = new NewAdbooking.classmysql.pop();
            ds = databindcomm.bankbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
       

        DataGrid1.DataSource = ds;


        for (int i = 0; i <= DataGrid1.Items.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)DataGrid1.Items[i].FindControl("CheckBox1");

            if (CheckBox.Checked == true)
            {
                txtbgno.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                txtbgdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[2]).ToString("MM/dd/yyyy");
                txtamount.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                txtbank.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString(); /*use this field for cont code*/
                txtvaliditydate.Text = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[5]).ToString("MM/dd/yyyy");
                hiddenccode.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            }

        }

        DataGrid1.DataBind();
    }

    public void bindgrid(string sortfield)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop databindcomm = new NewAdbooking.Classes.pop();

            ds = databindcomm.bankbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop databindcomm = new NewAdbooking.classesoracle.pop();
            ds = databindcomm.bankbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        else
        {
            NewAdbooking.classmysql.pop databindcomm = new NewAdbooking.classmysql.pop();
            ds = databindcomm.bankbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }

       

        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        dv = ds.Tables[0].DefaultView;
        dv.Sort = sortfield;

        DataGrid1.DataSource = dv;
        DataGrid1.DataBind();


    }
    [Ajax.AjaxMethod]
    public void submitbankdet(string txtbgno, string txtamount, string txtbank, string txtbgdate, string txtvaliditydate, string hiddenccode, string hiddenagevcode, string hiddencomcode, string hiddenuserid, string hiddenagensubcode,string attach)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop bankinsert = new NewAdbooking.Classes.pop();


            ds = bankinsert.updatebank(txtbgno, txtbgdate, txtamount, txtbank, txtvaliditydate, hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode, hiddenccode,attach);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop bankinsert = new NewAdbooking.classesoracle.pop();
            ds = bankinsert.updatebank(txtbgno, txtbgdate, txtamount, txtbank, txtvaliditydate, hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode, hiddenccode,attach);
        }
        else
        {
            NewAdbooking.classmysql.pop bankinsert = new NewAdbooking.classmysql.pop();
            ds = bankinsert.updatebank(txtbgno, txtbgdate, txtamount, txtbank, txtvaliditydate, hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode, hiddenccode);
        }

    }

    [Ajax.AjaxMethod]
    public void insertbankdet(string txtbgno, string txtamount, string txtbank, string txtbgdate, string txtvaliditydate, string hiddenagevcode, string hiddencomcode, string hiddenuserid, string hiddenagensubcode,string dateformat,string attach)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop bankinsert = new NewAdbooking.Classes.pop();


            ds = bankinsert.insertbank(txtbgno, txtbgdate, txtamount, txtbank, txtvaliditydate, hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode,attach);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop bankinsert = new NewAdbooking.classesoracle.pop();
            ds = bankinsert.insertbank(txtbgno, txtbgdate, txtamount, txtbank, txtvaliditydate, hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode, dateformat, attach);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "websp_insertbank";
            string[] parameterValueArray = { agencode, txtbgno, txtbgdate, txtamount, txtbank, txtvaliditydate, hiddenuserid, agencysubcode, hiddencomcode, attach };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        //else
        //{
        //    NewAdbooking.classmysql.pop bankinsert = new NewAdbooking.classmysql.pop();
        //    ds = bankinsert.insertbank(txtbgno, txtbgdate, txtamount, txtbank, txtvaliditydate, hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode, dateformat, attach);
        //}

    }

    //		[Ajax.AjaxMethod]
    //		public DataSet bandbank(string hiddenagevcode,string hiddencomcode,string hiddenuserid,string hiddenagensubcode)
    //		{
    //			NewAdbooking.Classes.pop databindcomm=new NewAdbooking.Classes.pop();
    //			DataSet ds=new DataSet();
    //
    //			ds=databindcomm.bankbind(hiddenagevcode,hiddencomcode,hiddenuserid);
    //
    //			return ds;
    //		}


    [Ajax.AjaxMethod]
    public DataSet bandbank12(string hiddenagevcode, string hiddencomcode, string hiddenuserid, string hiddenagensubcode, string code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop databindcomm = new NewAdbooking.Classes.pop();


            ds = databindcomm.bankbind12(hiddenagevcode, hiddencomcode, hiddenuserid, code);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop databindcomm = new NewAdbooking.classesoracle.pop();

            ds = databindcomm.bankbind12(hiddenagevcode, hiddencomcode, hiddenuserid, code);

            return ds;
        }
        else
        {
            NewAdbooking.classmysql.pop databindcomm = new NewAdbooking.classmysql.pop();

            ds = databindcomm.bankbind12(hiddenagevcode, hiddencomcode, hiddenuserid, code);

            return ds;
        }
    }

    
    [Ajax.AjaxMethod]
    public DataSet chkBgNo(string Bgno, string Bgname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop databindcomm = new NewAdbooking.Classes.pop();
            ds = databindcomm.checkBgno(Bgno, Bgname);
            
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop databindcomm = new NewAdbooking.classesoracle.pop();
            ds = databindcomm.checkBgno(Bgno, Bgname);

        }
        else
        {
            NewAdbooking.classmysql.pop databindcomm = new NewAdbooking.classmysql.pop();
            ds = databindcomm.checkBgno(Bgno, Bgname);
        }
        return ds;
        
    }


    [Ajax.AjaxMethod]
    public void deletebank(string hiddenagevcode, string hiddencomcode, string hiddenuserid, string hiddenccode, string hiddenagensubcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop delete = new NewAdbooking.Classes.pop();


            ds = delete.deletebank(hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode, hiddenccode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop delete = new NewAdbooking.classesoracle.pop();
            ds = delete.deletebank(hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode, hiddenccode);
        }
        else
        {
            NewAdbooking.classmysql.pop delete = new NewAdbooking.classmysql.pop();
            ds = delete.deletebank(hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode, hiddenccode);
        }
    }



    private void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop databindcomm = new NewAdbooking.Classes.pop();
            ds = databindcomm.bankbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop databindcomm = new NewAdbooking.classesoracle.pop();
            ds = databindcomm.bankbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        else
        {
            NewAdbooking.classmysql.pop databindcomm = new NewAdbooking.classmysql.pop();
            ds = databindcomm.bankbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
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



    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {

        DataView dv = new DataView();

        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            string str = "DataGrid1__ctl_CheckBox1" + j;
            
            e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  OnClick=\"javascript:return selectbank('" + str + "');\" value=" + e.Item.Cells[7].Text + "  />";
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
                    case "BG_NO":
                        str = "BG No.";
                        break;
                    case "BG_DATE":
                        str = "BG Date";
                        break;

                    case "AMOUNT":
                        str = "Amount";
                        break;

                    case "BANK_NAME":
                        str = "Bank";
                        break;

                    case "VALIDITY_DATE":
                        str = "Validity Date";
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

    protected void hiddendateformat_ServerChange(object sender, System.EventArgs e)
    {

    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>"); 
    }
    public void bindgrid1(string sortfield)
    {
        DataGrid2.Visible = true;
        DIV2.Visible = true;
        DataGrid1.Visible = false;
        DIV1.Visible = false;

        DataSet ds_tbl = new DataSet();


        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "BG_NO";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "BG_DATE";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn1;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "AMOUNT";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn1;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "BANK_NAME";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn1;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "VALIDITY_DATE";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "BG_CODE";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "attachment";
        mydatatable.Columns.Add(mycolumn);



        my_row = mydatatable.NewRow();


        my_row["BG_NO"] = gbBG_NO;
        my_row["BG_DATE"] = gbBG_DATE;
        my_row["AMOUNT"] = gbAMOUNT;
        my_row["BANK_NAME"] = gbBANK_NAME;
        my_row["VALIDITY_DATE"] = gbVALIDITY_DATE;

        my_row["attachment"] = gattachment;
        my_row["BG_CODE"] = "0";
        //my_row["Fax"] = gbfax;
        //my_row["EmailID"] = gbmailid;
        //my_row["Cont_Code"] = "0";
        //gbsecondcycle = txtaddate.Text;

        //  mydatatable.Rows.Add(my_row);

        ds_tbl.Tables.Add(mydatatable);

        // mydatatable.ImportRow(my_row);

        if (Session["bankdetail"] == null)
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
            dsnew = (DataSet)Session["bankdetail"];
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

        gbBG_NO = "";
        gbBG_DATE = "";
        gbAMOUNT = "";
        gbBANK_NAME = "";
        gbVALIDITY_DATE = "";
        gattachment = "";

        txtvaliditydate.Text = "";
        txtbgno.Text = "";
        txtbgdate.Text = "";
        txtbank.Text = "";
        txtamount.Text = "";
        //drpcommdetail.SelectedValue = "NET";

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       

    }
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "BG_NO";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "BG_DATE";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "AMOUNT";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "VALIDITY_DATE";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "BANK_NAME";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "BG_CODE";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "attachment";
        mydatatable1.Columns.Add(mycolumn1);

        myrow1 = mydatatable1.NewRow();


        //--------------------------------------------------------------------------------------

        // Code for Checking the redundency of grid 
        //during the timr of insertinr new record at 
        //runtime when records are submitted in 
        //the session only

        //--------------------------------------------------------------------------------------


        DataSet len = (DataSet)Session["bankdetail"];
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
       // if (Session["bankdetail"] != null && Session["bankdetail"] != "")
        if(DataGrid2.Items.Count>0)
        {
            while (j < DataGrid2.Items.Count)
            {
                string bg_no = DataGrid2.Items[j].Cells[0].Text;//len.Tables[i].Rows[0].ItemArray[0].ToString();
                string txtbg_no = txtbgno.Text;

                if (txtbg_no == bg_no)
                {
                    message = "You have already entered this BG No.";
                    txtbgno.Text = "";
                    AspNetMessageBox(message);
                    return; 
                }



                //string sf = len.Tables[i].Rows[0].ItemArray[2].ToString();
                //string st = len.Tables[i].Rows[0].ItemArray[3].ToString();
                //string[] ff = sf.Split('/');
                //string mm = ff[0];//.ToString();
                //string dd = ff[1];
                //string yyyy = ff[2];

                //string[] tt = st.Split('/');
                //string mm1 = tt[0];//.ToString();
                //string dd1 = tt[1];
                //string yyyy1 = tt[2];

                //string txtfromm = txtfrom.Text;
                //string txttoo = txtto.Text;

                //string[] txtff = txtfromm.Split('/');
                //string txtmm = txtff[0];//.ToString();
                //string txtdd = txtff[1];
                //string txtyyyy = txtff[2];

                //string[] txttt = txttoo.Split('/');
                //string txtmm1 = txttt[0];//.ToString();
                //string txtdd1 = txttt[1];
                //string txtyyyy1 = txttt[2];

                //if (((Convert.ToInt32(txtyyyy) >= Convert.ToInt32(yyyy)) && (Convert.ToInt32(txtyyyy) <= Convert.ToInt32(yyyy1))) || ((Convert.ToInt32(txtyyyy1) >= Convert.ToInt32(yyyy)) && (Convert.ToInt32(txtyyyy1) <= Convert.ToInt32(yyyy1))))
                //{
                //    //Response.Write("<script>alert('You have already entered the Commision Apply On for this duration');</script>");
                //    //return;
                //    //message = "You have already entered the Commision Apply On for this duration";
                //    //AspNetMessageBox(message);
                //    //return;

                //    if (((Convert.ToInt32(txtmm) >= Convert.ToInt32(mm)) && (Convert.ToInt32(txtmm) <= Convert.ToInt32(mm1))) || ((Convert.ToInt32(txtmm1) >= Convert.ToInt32(mm)) && (Convert.ToInt32(txtmm1) <= Convert.ToInt32(mm1))))
                //    {
                //        //Response.Write("<script>alert('You have already entered the Commision Apply On for this duration');</script>");
                //        //return;
                //        //message = "You have already entered the Commision Apply On for this duration";
                //        //AspNetMessageBox(message);
                //        //return;

                //        if (((Convert.ToInt32(txtdd) >= Convert.ToInt32(dd)) && (Convert.ToInt32(txtdd) <= Convert.ToInt32(dd1))) || ((Convert.ToInt32(txtdd1) >= Convert.ToInt32(dd)) && (Convert.ToInt32(txtdd1) <= Convert.ToInt32(dd1))))
                //        {
                //            //Response.Write("<script>alert('You have already entered the Commision Apply On for this duration');</script>");
                //            message = "You have already entered the Status Detail for this duration";
                //            AspNetMessageBox(message);
                //            return;

                //        }
                //    }
                //}





                j++;

            }
        }




        
        myrow1 = mydatatable1.NewRow();

        myrow1["BG_CODE"] = "00";


        myrow1["BANK_NAME"] = txtbank.Text;
        gbBANK_NAME = txtbank.Text;

        myrow1["AMOUNT"] = txtamount.Text;
        gbAMOUNT = txtamount.Text;

        myrow1["BG_DATE"] = txtbgdate.Text;
        gbBG_DATE = txtbgdate.Text;

        myrow1["BG_NO"] = txtbgno.Text;
        gbBG_NO = txtbgno.Text;

        myrow1["VALIDITY_DATE"] = txtvaliditydate.Text;
        gbVALIDITY_DATE = txtvaliditydate.Text;


        myrow1["attachment"] = hidattach2.Value;
        gattachment = hidattach2.Value;



        mydatatable1.Rows.Add(myrow1);
        if (Session["bankdetail"] != null)
        {
            DataSet dsNew = new DataSet();
            dsNew = (DataSet)Session["bankdetail"];
            dk1 = dsNew;
        }

        dk1.Tables.Add(mydatatable1);

        Session["bankdetail"] = dk1;

        bindgrid1("BG_DATE");
    }


    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(bank_detail), "ShowAlert", strAlert, true);
    }






}
