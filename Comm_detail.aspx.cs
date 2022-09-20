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

public partial class Comm_detail : System.Web.UI.Page
{
   int j = 0;
    DataSet dk1 = new DataSet();
    DataSet dk = new DataSet();
    public static int numberDiv;
    string show, adtype;
    DataRow my_row;
    protected System.Text.StringBuilder sb;
    string agencode, agencysubcode;
    static string gbDiscount, gbComm_rate, gbaddComm_rate, gbto, gbfrom, gbadtype, gbadtypecode, guom, gagen, gcashdis, gcashamt, gbadsubcat;
    static int i;
    string message;

    DateTime[] sdfr;// = Convert.ToDateTime(txtefffrom.Text);
        string[] dateto;
        DateTime[] sdto;



    private void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here

        Response.Expires = -1;
        EffectiveFrom.Text = "";
        EffectiveTill.Text = "";
        CommissionRate.Text = "";
        if (Session["compcode"] != null)
        {
            //Response.Write("<script>alert('Your Session Expired Please Relogin ');</script>");
            hiddencomcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            show = Request.QueryString["show"].ToString();
            hideshow.Value = show;
            hiddenshow.Value = Request.QueryString["show"].ToString();
            adtype = Request.QueryString["drpagetyp"].ToString();
            hdnconntype.Value = ConfigurationSettings.AppSettings["ConnectionType"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }
        Label5.Visible = false;

        //			-------------------------------------Code Of XML File--------------
        //		
        DataSet objDataSet = new DataSet();

        objDataSet.ReadXml(Server.MapPath("XML/Comm_detail.xml"));

        EffectiveFrom.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        CommissionRate.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        EffectiveTill.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        CommissionApplyOn.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        btnSubmit.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        btnclear.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        btndelete.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        btnclose.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        lbadtype.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
        lbluom.Text = objDataSet.Tables[0].Rows[0].ItemArray[9].ToString();
        Label2.Text = objDataSet.Tables[0].Rows[0].ItemArray[10].ToString();
        lbadcat1.Text = objDataSet.Tables[0].Rows[0].ItemArray[11].ToString();
      
        //         --------------------------------End-------------------------------------------------


        agencode = Request.QueryString["agecode"].ToString();
        agencysubcode = Request.QueryString["agencysubcode"].ToString();
        if (agencysubcode == "null")
            agencysubcode = "";
        Session["agencode"] = agencode;
        hiddenagevcode.Value = Request.QueryString["agecode"].ToString();


        hiddenagensubcode.Value = agencysubcode;
        Ajax.Utility.RegisterTypeForAjax(typeof(Comm_detail));




        //if (agencode != "" && agencysubcode != "")
        //{ }
        //else
        //{
        //    Response.Write("<script>alert('You Should Enter The Agency Code First And Sub Code');window.close();</script>");

        //    return;
        //}

        //if (show == "1")
        //{
        //    btnSubmit.Enabled = true;
        //    //btnclose.Enabled = true;
        //}
        //else
        //{
        //    btnSubmit.Enabled = false;
        //    //btnclose.Enabled = false;
        //}
        if (show == "2")
        {
            btnSubmit.Enabled = true;
            btndelete.Enabled = true;
            txtcommrate.Enabled = true;
            txtaddcomm.Enabled = true;
            txtefffrom.Enabled = true;
            txtefftill.Enabled = true;
            drpcommdetail.Enabled = true;
            drpuom.Enabled = true;
            drpagen.Enabled = true;
            drpcashdis.Enabled = true;
            txtcsamt.Enabled = true;
            dpadcat.Enabled = true;
            
        }
        if (show == "1")
        {
            btnSubmit.Enabled = true;
            btndelete.Enabled = false;
            txtcommrate.Enabled = true;
            txtaddcomm.Enabled = true;
            txtefffrom.Enabled = true;
            txtefftill.Enabled = true;
            drpcommdetail.Enabled = true;
            drpuom.Enabled = true;
            drpagen.Enabled = true;
            drpcashdis.Enabled = true;
            txtcsamt.Enabled = true;
            dpadcat.Enabled = true;

        }

        if (show == "0")
        {
            btnSubmit.Enabled = false;
            btndelete.Enabled = false;
            txtcommrate.Enabled = false;
            txtaddcomm.Enabled = false;
            txtefffrom.Enabled = false;
            txtefftill.Enabled = false;
            drpcommdetail.Enabled = false;
            drpadtype.Enabled = false;
            drpuom.Enabled = false;
            drpagen.Enabled = false;
            drpcashdis.Enabled = false;
            txtcsamt.Enabled = false;
            dpadcat.Enabled = false;

        }
        if (!Page.IsPostBack)
        {
            if (dk1.Tables.Count > 0 && (Session["commdetail"] == null || Session["commdetail"] == ""))
            {
                dk.Clear();
                dk.Dispose();
                dk = new DataSet();

                //dk.Clear();
                //dk.Dispose();
              

                dk1 = new DataSet();
            }
            
            if (show == "2" || show == "0")
                Session["commdetail"] = null;
            if (Session["commdetail"] == null || Session["commdetail"] == "")
            //if (hiddencentcode.Value != "")
            {
                DataGrid2.Visible = false;
                Divgrid2.Visible = false;
                Divgrid1.Visible = true;
                DataGrid1.Visible = true;
                bindgrid("Eff_from_date");
            }
            else
            {
                DataGrid2.Visible = true;
                Divgrid2.Visible = true;
                Divgrid1.Visible = false;
                DataGrid1.Visible = false;
                bindgrid1("Eff_from_date");

            }
            btnSubmit.Attributes.Add("OnClick", "javascript:return commsubmit();");
            //btnclose.Attributes.Add("OnClick", "javascript:return selectcomm();");
            btnclear.Attributes.Add("OnClick", "javascript:return cleardata('comm');");
            btndelete.Attributes.Add("OnClick", "javascript:return deletecomm();");
            txtefffrom.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            txtefftill.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            lbpubmaster.Attributes.Add("OnClick", "javascript:return pubopen();  ");
            drpadtype.Attributes.Add("OnChange", "javascript:return onchage_adtype();");


            drpuom.Attributes.Add("OnChange", "javascript:return onchage_uom();");
            dpadcat.Attributes.Add("OnChange", "javascript:return onchage_adsubcat();");

            txtcsamt.Attributes.Add("OnBlur", "javascript:return chkamt();");
            drpcashdis.Attributes.Add("OnChange", "javascript:return chkamt();");

            bindcommission();
            bindadtype();
            //databind12("Eff_from_date");
            txtcommrate.Attributes.Add("OnChange", "javascript:return allamount121();");

            //btnSubmit.Attributes.Add("OnClick","javascript:return validate();");
            DataSet adtypes = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop bindadvtype = new NewAdbooking.Classes.pop();

                adtypes = bindadvtype.collectadvtype(Session["compcode"].ToString(), Session["userid"].ToString(), hiddendateformat.Value);
                for (int z = 0; z <= adtypes.Tables[0].Rows.Count - 1; z++)
                {
                    if (adtype == adtypes.Tables[0].Rows[z].ItemArray[0].ToString() && show == "1")
                    {
                        txtefffrom.Text = adtypes.Tables[0].Rows[z].ItemArray[1].ToString();
                        txtefftill.Text = adtypes.Tables[0].Rows[z].ItemArray[2].ToString();
                        txtcommrate.Text = adtypes.Tables[0].Rows[z].ItemArray[3].ToString();
                        //drpcommdetail.SelectedItem.Value = adtypes.Tables[0].Rows[z].ItemArray[4].ToString();
                        drpcommdetail.SelectedValue = adtypes.Tables[0].Rows[z].ItemArray[4].ToString();

                    }
                }
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop bindadvtype = new NewAdbooking.classesoracle.pop();
                adtypes = bindadvtype.collectadvtype(Session["compcode"].ToString(), Session["userid"].ToString(), hiddendateformat.Value);
                for (int z = 0; z <= adtypes.Tables[0].Rows.Count - 1; z++)
                {
                    if (adtype == adtypes.Tables[0].Rows[z].ItemArray[0].ToString() && show == "1")
                    {
                        txtefffrom.Text = adtypes.Tables[0].Rows[z].ItemArray[1].ToString();
                        txtefftill.Text = adtypes.Tables[0].Rows[z].ItemArray[2].ToString();
                        txtcommrate.Text = adtypes.Tables[0].Rows[z].ItemArray[3].ToString();
                        //drpcommdetail.SelectedItem.Value = adtypes.Tables[0].Rows[z].ItemArray[4].ToString();
                        drpcommdetail.SelectedValue = adtypes.Tables[0].Rows[z].ItemArray[4].ToString();

                    }
                }
            }
            else
            {
                NewAdbooking.classmysql.pop bindadvtype = new NewAdbooking.classmysql.pop();
                adtypes = bindadvtype.collectadvtype(Session["compcode"].ToString(), Session["userid"].ToString(), hiddendateformat.Value);
                for (int z = 0; z <= adtypes.Tables[0].Rows.Count - 1; z++)
                {
                    if (adtype == adtypes.Tables[0].Rows[z].ItemArray[0].ToString() && show == "1")
                    {
                        txtefffrom.Text = adtypes.Tables[0].Rows[z].ItemArray[1].ToString();
                        txtefftill.Text = adtypes.Tables[0].Rows[z].ItemArray[2].ToString();
                        txtcommrate.Text = adtypes.Tables[0].Rows[z].ItemArray[3].ToString();
                        //drpcommdetail.SelectedItem.Value = adtypes.Tables[0].Rows[z].ItemArray[4].ToString();
                        drpcommdetail.SelectedValue = adtypes.Tables[0].Rows[z].ItemArray[4].ToString();

                    }
                }
            }
        }
    }
    public string ConvertToDateTime(string strDateTime)
    {
        string dtFinaldate; string sDateTime;
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

    public void bindcommission()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop commdetail = new NewAdbooking.Classes.pop();

            ds = commdetail.commission();
        }
        else if(ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop commdetail=new NewAdbooking.classesoracle.pop();
             ds = commdetail.commission();
        }
         else
        {
            NewAdbooking.classmysql.pop commdetail = new NewAdbooking.classmysql.pop();

            ds = commdetail.commission();
        }

            drpcommdetail.Items.Clear();
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "Select";
            li1.Value = "0";
            //li1.Selected =true;
            //drpcommdetail.Items.Add(li1);
           // ds = commdetail.commission();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li;
                    li = new ListItem();
                    li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    //li1.Selected =true;
                    drpcommdetail.Items.Add(li);

                }
                //drpcommdetail.DataBind();
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
        this.hiddenshow.ServerChange += new System.EventHandler(this.hiddenshow_ServerChange);
        //this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion


    //	

    public void bindgrid(string sortfield)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop databindcomm = new NewAdbooking.Classes.pop();


            ds = databindcomm.commbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop databindcomm = new NewAdbooking.classesoracle.pop();
            ds = databindcomm.commbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }

        else
        {
            NewAdbooking.classmysql.pop databindcomm = new NewAdbooking.classmysql.pop();
            ds = databindcomm.commbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }


            ViewState["SortExpression"] = sortfield;
            ViewState["order"] = "ASC";
            DataView dv = new DataView();
            dv = ds.Tables[0].DefaultView;
            dv.Sort = sortfield;

            if (ds.Tables[0].Rows.Count >= 1)
            {
                DataGrid1.DataSource = dv;
                DataGrid1.DataBind();
                DataSet dsnew = new DataSet();
                for (int j = 0; j <= ds.Tables[0].Rows.Count - 1; j++)
                {
                    //Session["commdetail"] = ds.Tables[0].Rows[j];
                    
                    DataRow my_row1;
                    DataTable mydatatable = new DataTable();
                    my_row1 = mydatatable.NewRow();
                    my_row1 = ds.Tables[0].Rows[j];
                    mydatatable.ImportRow(my_row1);
                    dsnew.Tables.Add(mydatatable);
                }
                Session["commdetail"] = dsnew;
            }
            else
            {
                DataGrid2.Visible = true;
                Divgrid2.Visible = true;
                Divgrid1.Visible = false;
                DataGrid1.Visible = false;
                DataGrid2.DataSource = dv;
                DataGrid2.DataBind();
            }
        
   
           

    }



    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet submitcomm(string txtefffrom, string txtefftill, string txtcommrate, string drpcommdetail, string hiddenccode, string hiddenagevcode, string hiddencomcode, string hiddenuserid, string adtype, string addcomm, string uom, string agen, string cash_disc, string cash_amt, string adcat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop comminsert = new NewAdbooking.Classes.pop();

            double comm_r = Convert.ToDouble(txtcommrate);
            ds = comminsert.commupdate(txtefffrom, txtefftill, Convert.ToString(comm_r), drpcommdetail, hiddenccode, hiddencomcode, hiddenuserid, hiddenagevcode, adtype, addcomm, uom, agen, cash_disc, cash_amt, adcat);
            Session["commdetail"] = null;
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop comminsert = new NewAdbooking.classesoracle.pop();
            double comm_r = Convert.ToDouble(txtcommrate);
            ds = comminsert.commupdate(txtefffrom, txtefftill, Convert.ToString(comm_r), drpcommdetail, hiddenccode, hiddencomcode, hiddenuserid, hiddenagevcode, adtype, addcomm, uom, agen, cash_disc, cash_amt, adcat);
            Session["commdetail"] = null;
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.pop comminsert = new NewAdbooking.classmysql.pop();

            double comm_r = Convert.ToDouble(txtcommrate);
            ds = comminsert.commupdate(ConvertToDateTime(txtefffrom), ConvertToDateTime(txtefftill), Convert.ToString(comm_r), drpcommdetail, hiddenccode, hiddencomcode, hiddenuserid, hiddenagevcode, adtype, addcomm, uom, agen, cash_disc, cash_amt);
            Session["commdetail"] = null;
            return ds;
        }
        
    }

    [Ajax.AjaxMethod]
    public DataSet pkg_adcat_uom_bind(string compcode, string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bind = new NewAdbooking.Classes.BookingMaster();
            ds = bind.advdatacategoryRate(compcode, adtype, "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster bind = new NewAdbooking.classesoracle.RateMaster();
            ds = bind.advdatacategory(compcode, adtype, "");

        }
        else
        {
            string procedureName = "book_advcategory_book_advcategory_p";
            string[] parameterValueArray = { compcode, adtype, "" };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

          //  NewAdbooking.classmysql.pop bind = new NewAdbooking.classmysql.pop();
         //   ds = bind.binduom1(compcode, adtype);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet pkg_adcat(string compcode, string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bind = new NewAdbooking.Classes.BookingMaster();
            ds = bind.advdatacategoryRate(compcode, adtype, "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster bind = new NewAdbooking.classesoracle.RateMaster();
            ds = bind.advdatacategory(compcode, adtype, "");

        }
        else
        {
            NewAdbooking.classmysql.pop bind = new NewAdbooking.classmysql.pop();
            ds = bind.binduom1(compcode, adtype);
        }
        return ds;
    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void insertcommdetail(string txtefffrom, string txtefftill, string txtcommrate, string drpcommdetail, string hiddenagevcode, string hiddencomcode, string hiddenuserid, string hiddenagensubcode, string dateformat, string adtype, string adcomm, string uom, string agen, string cash_disc, string cash_amt, string adcat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop comminsert = new NewAdbooking.Classes.pop();

            double comm_r = Convert.ToDouble(txtcommrate);
            ds = comminsert.insertcomm(txtefffrom, txtefftill, Convert.ToString(comm_r), drpcommdetail, hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode, dateformat, adtype, adcomm, uom, agen, cash_disc, cash_amt, adcat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop comminsert = new NewAdbooking.classesoracle.pop();
            double comm_r = Convert.ToDouble(txtcommrate);
            ds = comminsert.insertcomm(txtefffrom, txtefftill, Convert.ToString(comm_r), drpcommdetail, hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode, dateformat, adtype, adcomm, uom, agen, cash_disc, cash_amt, adcat);
        }
        else
        {
            NewAdbooking.classmysql.pop comminsert = new NewAdbooking.classmysql.pop();
            double comm_r = Convert.ToDouble(txtcommrate);
            ds = comminsert.insertcomm(ConvertToDateTime(txtefffrom), ConvertToDateTime(txtefftill), Convert.ToString(comm_r), drpcommdetail, hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode, dateformat, adtype, adcomm, uom, agen, cash_disc, cash_amt, adcat);
        }
        Session["commdetail"] = null;
    }

    //		[Ajax.AjaxMethod]
    //		public DataSet bandcomm(string hiddenagevcode,string hiddencomcode,string hiddenuserid,string datagrid)
    //		{
    //			NewAdbooking.Classes.pop databindcomm=new NewAdbooking.Classes.pop();
    //			DataSet ds=new DataSet();
    //
    //			ds=databindcomm.commbind(hiddenagevcode,hiddencomcode,hiddenuserid);
    //
    //			return ds;
    //
    //		}

    [Ajax.AjaxMethod]
    public DataSet bandcomm123(string hiddenagevcode, string hiddencomcode, string hiddenuserid, string code11)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop databindcomm = new NewAdbooking.Classes.pop();


            ds = databindcomm.commbind123(hiddenagevcode, hiddencomcode, hiddenuserid, code11);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop databindcomm = new NewAdbooking.classesoracle.pop();
            ds = databindcomm.commbind123(hiddenagevcode, hiddencomcode, hiddenuserid, code11);

            return ds;
        }
        else
        {

            string procedureName = "commbind12_p";
            string[] parameterValueArray = { hiddenagevcode, hiddenuserid, hiddencomcode, code11 };
           NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
           ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
       
           // NewAdbooking.classmysql.pop databindcomm = new NewAdbooking.classmysql.pop();
           // ds = databindcomm.commbind123(hiddenagevcode, hiddencomcode, hiddenuserid, code11);

            return ds;
        }

    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void deletecommdet(string hiddenagevcode, string hiddencomcode, string hiddenuserid, string hiddenccode, string hiddenagensubcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop delete = new NewAdbooking.Classes.pop();

            ds = delete.commdelete(hiddenccode, hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop delete = new NewAdbooking.classesoracle.pop();
            ds = delete.commdelete(hiddenccode, hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode);
        }
        else
        {
            NewAdbooking.classmysql.pop delete = new NewAdbooking.classmysql.pop();
            ds = delete.commdelete(hiddenccode, hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode);
        }
        Session["commdetail"] = null;
    }

    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {

        DataView dv = new DataView();


        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;




        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  OnClick=\"javascript:return selectcomm('" + str + "');\" value=" + e.Item.Cells[6].Text + "  />";
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
                    case "Eff_from_date":
                        str = "Effective From";
                        break;
                    case "Eff_Till_date":
                        str = "Effective Till";
                        break;

                    case "Comm_rate":
                        str = "Commission Rate";
                        break;

                    case "Discount":
                        str = "Commision Applied On";
                        break;




                };
                if (ViewState["order"].ToString() == "DESC")
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";
                }
                else
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+str+"<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                }





            }
        }


    }

    private void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop databindcomm = new NewAdbooking.Classes.pop();


            ds = databindcomm.commbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop databindcomm = new NewAdbooking.classesoracle.pop();
            ds = databindcomm.commbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        else
        {
            NewAdbooking.classmysql.pop databindcomm = new NewAdbooking.classmysql.pop();
            ds = databindcomm.commbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);

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
    
         
       

  


    //[Ajax.AjaxMethod]
    //public DataSet commdate(string hiddenagevcode, string hiddencomcode, string hiddenuserid, string fromdate, string todate,string agencysubcode)
    //{
    //    NewAdbooking.Classes.pop databindcomm = new NewAdbooking.Classes.pop();
    //    DataSet ds = new DataSet();

    //    ds = databindcomm.commcheckdate(hiddenagevcode, hiddencomcode, hiddenuserid, fromdate, todate, agencysubcode);
    //    return ds;

    //}

    [Ajax.AjaxMethod]
    public DataSet commdate12(string hiddenagevcode, string hiddencomcode, string hiddenuserid, string fromdate, string todate, string hiddenccode, string subagencycode, string drpcommdetail, string adtype, string uom)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop databindcomm = new NewAdbooking.Classes.pop();


            ds = databindcomm.commcheckdate12(hiddenagevcode, hiddencomcode, hiddenuserid, fromdate, todate, hiddenccode, subagencycode, drpcommdetail, adtype, uom);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop databindcomm = new NewAdbooking.classesoracle.pop();
            ds = databindcomm.commcheckdate12(hiddenagevcode, hiddencomcode, hiddenuserid, fromdate, todate, hiddenccode, subagencycode, drpcommdetail, adtype, uom);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.pop databindcomm = new NewAdbooking.classmysql.pop();
            ds = databindcomm.commcheckdate12(hiddenagevcode, hiddencomcode, hiddenuserid, ConvertToDateTime(fromdate), ConvertToDateTime(todate), hiddenccode, subagencycode, drpcommdetail, adtype, uom);
            return ds;
        }

    }

    private void hiddendateformat_ServerChange(object sender, System.EventArgs e)
    {

    }

    private void DataGrid1_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        DataView dv = new DataView();


        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;




        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + " OnClick=\"javascript:return selectcomm('" + str + "');\"  value=" + e.Item.Cells[6].Text + "  />";
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
                    case "Eff_from_date":
                        str = "Effective From";
                        break;
                    case "Eff_Till_date":
                        str = "Effective Till";
                        break;

                    case "Comm_rate":
                        str = "Commission Rate";
                        break;

                    case "Discount":
                        str = "Commision Applied On";
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

    private void hiddenshow_ServerChange(object sender, System.EventArgs e)
    {

    }







    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>"); 
    }

    protected void DataGrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop databindcomm = new NewAdbooking.Classes.pop();


            ds = databindcomm.commbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop databindcomm=new NewAdbooking.classesoracle.pop();
            ds = databindcomm.commbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
            else
        {
            NewAdbooking.classmysql.pop databindcomm = new NewAdbooking.classmysql.pop();
            ds = databindcomm.commbind(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
           
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
    public void bindgrid1(string sortfield)
    {
        DataGrid2.Visible = true;
        Divgrid2.Visible = true;
        DataGrid1.Visible = false;
        Divgrid1.Visible = false;

        DataSet ds_tbl = new DataSet();


        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Eff_from_date";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Eff_Till_date";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn1;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Comm_rate";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn1;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Discount";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn1;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "COMM_CODE";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn1;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "adtype";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn1;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "adtypecode";
        mydatatable.Columns.Add(mycolumn);

        my_row = mydatatable.NewRow();

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Addl_Comm_Rate";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "UOM";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "ADDITIONAL_FLAG";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "CASH_DISCOUNT";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "CASH_DISCOUNTTYPE";
        mydatatable.Columns.Add(mycolumn);



        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "ADSUBCAT1";
        mydatatable.Columns.Add(mycolumn);


        my_row = mydatatable.NewRow();


        my_row["Eff_from_date"] = gbfrom ;
        my_row["Eff_Till_date"] = gbto ;
        my_row["Comm_rate"] = gbComm_rate;
        my_row["Discount"] = gbDiscount;
        my_row["adtype"] = gbadtype;
        my_row["adtypecode"] = gbadtypecode;
        my_row["COMM_CODE"] = "0";
        my_row["Addl_Comm_Rate"] = gbaddComm_rate;
        my_row["UOM"] = guom;
        my_row["ADDITIONAL_FLAG"] = gagen;
        my_row["CASH_DISCOUNT"] = gcashamt;
        my_row["CASH_DISCOUNTTYPE"] = gcashdis;
        my_row["ADSUBCAT1"] = gbadsubcat;

        ds_tbl.Tables.Add(mydatatable);

        // mydatatable.ImportRow(my_row);

        if (Session["commdetail"] == null)
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
            dsnew = (DataSet)Session["commdetail"];
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


        gbDiscount="";
        gbfrom = "";
        gbto = "";
        gbComm_rate = "";
        gbadtype = "";
        gcashdis="";
        gcashamt = "";
        txtaddcomm.Text = "";
        txtcommrate.Text = "";
        txtefffrom .Text = "";
        txtefftill .Text = "";
        drpadtype.SelectedValue = "0";
        drpuom.SelectedValue = "0";
        drpagen.SelectedValue = "0";
        txtcsamt.Text = "";
        drpcashdis.SelectedValue = "0";
        dpadcat.SelectedValue = "0";
        //drpcommdetail.SelectedValue = "NET";

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Eff_from_date";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Eff_Till_date";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Comm_rate";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Discount";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "COMM_CODE";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "adtype";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "adtypecode";
        mydatatable1.Columns.Add(mycolumn1);

        //--------------------------------------------------------------------------------------
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Addl_Comm_rate";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "UOM";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "ADDITIONAL_FLAG";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "CASH_DISCOUNT";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "CASH_DISCOUNTTYPE";
        mydatatable1.Columns.Add(mycolumn1);


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "ADSUBCAT1";
        mydatatable1.Columns.Add(mycolumn1);

        // Code for Checking the redundency of grid 
        //during the timr of insertinr new record at 
        //runtime when records are submitted in 
        //the session only

        //--------------------------------------------------------------------------------------



        DataSet len = (DataSet)Session["commdetail"];
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
        if (Session["commdetail"] != null && Session["commdetail"] != "")
        {
            while (j < length)
            {
                string sf = len.Tables[j].Rows[0].ItemArray[0].ToString();
                string st = len.Tables[j].Rows[0].ItemArray[1].ToString();
                string adtypecode = len.Tables[j].Rows[0].ItemArray[6].ToString();
                string uom1 = len.Tables[j].Rows[0].ItemArray[8].ToString();
                string[] ff = sf.Split('/');
                string mm = ff[0];//.ToString();
                string dd = ff[1];
                string yyyy = ff[2];

                string[] tt = st.Split('/');
                string mm1 = tt[0];//.ToString();
                string dd1 = tt[1];
                string yyyy1 = tt[2];

                string txtfrom = txtefffrom.Text;
                string txtto = txtefftill.Text;
                string adtyp = drpadtype.SelectedValue;

                string[] txtff = txtfrom.Split('/');
                string txtmm = txtff[0];//.ToString();
                string txtdd = txtff[1];
                string txtyyyy = txtff[2];

                string[] txttt = txtto.Split('/');
                string txtmm1 = txttt[0];//.ToString();
                string txtdd1 = txttt[1];
                string txtyyyy1 = txttt[2];
                
                if (len.Tables[j].Rows[0].ItemArray[6].ToString() == drpadtype.SelectedValue)
                {
                    DataSet ds_b = new DataSet();
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.pop databindcomm = new NewAdbooking.Classes.pop();


                        ds_b = databindcomm.datechk(sf, st, txtfrom, txtto, Session["dateformat"].ToString());
                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.pop databindcomm = new NewAdbooking.classesoracle.pop();
                        ds_b = databindcomm.datechk(sf, st, txtfrom, txtto, Session["dateformat"].ToString());
                    }
                    else 
                    {
                        string procedureName = "datechk_b";
                        string[] parameterValueArray = { sf, st, ConvertToDateTime(txtfrom), ConvertToDateTime(txtto) };
                        NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                        ds_b = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                    }
                    if ((uom1 == hiddenuom.Value) || uom1 == "")// && (adtyp != "0"))
                    {
                        if (ds_b.Tables[0].Rows[0].ItemArray[0].ToString() == "In Range")
                        {
                            //Response.Write("<script>alert('You have already entered the Commision Apply On for this duration');</script>");
                            message = "The Commision Apply On for this duration has already been submitted";
                            AspNetMessageBox(message);
                            return;
                        }
                    }

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
                    //            if ((uom1 == hiddenuom.Value))// && (adtyp != "0"))
                    //            {
                    //                //Response.Write("<script>alert('You have already entered the Commision Apply On for this duration');</script>");
                    //                message = "The Commision Apply On for this duration has already been submitted";
                    //                AspNetMessageBox(message);
                    //                return;
                    //            }
                    //            // else
                    //            // {
                    //            //   message = "The Commision Apply On for this duration has already been submitted";
                    //            //  AspNetMessageBox(message);
                    //            //  return;
                    //            // }


                    //        }
                    //    }
                    //}
                }
                
                
                
                j++;

            }
        }




        //saurabh change for grid repeated data

        //if (Session["commdetail"] != null || Session["commdetail"] == "")
        //{
            
        //}

        //int j = 0;
        //string[] datefrom;
        ////DateTime[] sdfr;// = Convert.ToDateTime(txtefffrom.Text);
        ////string[] dateto;
        ////DateTime[] sdto;// = Convert.ToDateTime(txtefftill.Text);
        //int flag = 0;

        //while (j < i)
        //{
        //    //int tf = Convert.ToInt32(txtefffrom.Text);
        //    string tf = txtefffrom.Text;
        //    string[] from=tf.Split('/');
        //    string mm = from[0];
        //    string dd = from[1];
        //    string yyyy = from[2];

        //    DateTime txtfrom = new DateTime(Convert.ToInt32(yyyy),Convert.ToInt32(mm),Convert.ToInt32(dd));

        //    //string tt = Convert.ToInt32(txtefftill.Text);
        //    string tt =txtefftill.Text;
        //    string[] to = tt.Split('/');
        //    string mm1 = to[0];
        //    string dd1 = to[1];
        //    string yyyy1 = to[2];

        //    DateTime txtto = new DateTime(Convert.ToInt32(yyyy1), Convert.ToInt32(mm1), Convert.ToInt32(dd1));


        //    if (((txtfrom > sdfr[j]) && (txtfrom < sdfr[j])) || ((txtto > sdto[j]) && (txtto < sdto[j])))
        //    {
        //        flag = 1;
        //    }
        //    j++;
        //}

        //if (flag == 0)
        //{
        //    //if (sdf[i] == System.DateTime.null || Convert.ToString(sdf[i]) == "")
        //    //{
        //        sdfr[i] = Convert.ToDateTime(txtefffrom.Text);
        //        sdto[i] = Convert.ToDateTime(txtefftill.Text);
        //        i++;
        //    //}
        //    //if (Convert.ToString(sdt[i]) == null || Convert.ToString(sdt[i]) == "")
        //    //{
        //        //sdt[i] = Convert.ToDateTime(txtefftill.Text);
        //        //i++;
        //    //}
        //}

       

        //if (flag == 1)
        //{
        //    Response.Write("<script>alert('You have already entered the Commision Apply On for this duration');</script>");
        //}
        //else
        //{
            myrow1 = mydatatable1.NewRow();

            myrow1["COMM_CODE"] = "00";


            myrow1["Discount"] = drpcommdetail.SelectedValue;
            gbDiscount = drpcommdetail.SelectedValue;

            myrow1["Comm_rate"] = txtcommrate.Text;
            gbComm_rate = txtcommrate.Text;
            myrow1["Eff_Till_date"] = txtefftill.Text;
            gbto = txtefftill.Text;
            //myrow1["STAT_CODE"] = txt.Text;
            //gbphone = txtphoneno.Text;
            myrow1["Eff_from_date"] = txtefffrom.Text;

            myrow1["Addl_Comm_rate"] = txtaddcomm.Text;
            gbComm_rate = txtaddcomm.Text;
            gbfrom = txtefffrom.Text;
           

            if (drpadtype.SelectedValue != "0")
            {
                myrow1["adtype"] = drpadtype.SelectedItem.Text;
                gbadtype = drpadtype.SelectedItem.Text;
            }
            else
            {
                myrow1["adtype"] = drpadtype.SelectedValue;
                gbadtype = drpadtype.SelectedValue;
            }

            if (hiddenuom.Value != "" && drpadtype.SelectedValue != "0")
            {
                myrow1["UOM"] = hiddenuom.Value;
                guom = hiddenuom.Value;
            }
            else
            {
                myrow1["UOM"] = "";
                guom = "";
            }

           
            myrow1["ADDITIONAL_FLAG"] = drpagen.SelectedItem.Value;
                gagen = drpagen.SelectedItem.Value;
            //}
            //else
            //{
            //    myrow1["ADDITIONAL_FLAG"] = "";
            //    gagen = "";
            //}

            myrow1["adtypecode"] = drpadtype.SelectedValue;
            gbadtypecode = drpadtype.SelectedValue;

            myrow1["CASH_DISCOUNT"] = txtcsamt.Text;
            gcashamt = txtcsamt.Text;

            if (drpcashdis.SelectedValue != "" && drpcashdis.SelectedValue != "0")
            {

                myrow1["CASH_DISCOUNTTYPE"] = drpcashdis.SelectedValue;
                gcashdis = drpcashdis.SelectedValue;
            }
            else
            {
                myrow1["CASH_DISCOUNTTYPE"] = "";
                gcashdis = "";
            }



            //if (dpadcat.SelectedValue != "0")
            //{
            //    myrow1["ADSUBCAT1"] = dpadcat.SelectedItem.Text;
            //    gbadsubcat = drpadtype.SelectedItem.Text;
            //}
            //else
            //{
            //    myrow1["adtype"] = dpadcat.SelectedValue;
            //    gbadsubcat = drpadtype.SelectedValue;
            //}


            if (hiddensubcat.Value != "" && drpadtype.SelectedValue != "0")
            {
                myrow1["ADSUBCAT1"] = hiddensubcat1.Value;
                gbadsubcat = hiddensubcat.Value;
            }
            else
            {
                myrow1["ADSUBCAT1"] = "";
                gbadsubcat = "";
            }




            mydatatable1.Rows.Add(myrow1);

            if (Session["commdetail"] != null)
            {
                DataSet dsNew = new DataSet();
                dsNew = (DataSet)Session["commdetail"];
                dk1 = dsNew;
            }

            dk1.Tables.Add(mydatatable1);

            Session["commdetail"] = dk1;

            bindgrid1("Eff_from_date");
//      }

    }

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Comm_detail), "ShowAlert", strAlert, true);
    }

    protected void bindadtype()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CombinationMaster bind = new NewAdbooking.Classes.CombinationMaster();
            ds = bind.adtypbind(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.CombinationMaster bind = new NewAdbooking.classesoracle.CombinationMaster();
            ds = bind.adtypbind(Session["compcode"].ToString());

        }
        else
        {
            NewAdbooking.classmysql.CombinationMaster bind = new NewAdbooking.classmysql.CombinationMaster();
            ds = bind.adtypbind(Session["compcode"].ToString());
        }

        drpadtype.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select";
        li1.Value = "0";
        drpadtype.Items.Add(li1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                drpadtype.Items.Add(li);
            }
        }
    }





    [Ajax.AjaxMethod]
    public DataSet adcatbnd(string adtype, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
            ds = adcat.advtype(adtype, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.advtype(adtype, compcode);
        }
        return ds;

    }

}