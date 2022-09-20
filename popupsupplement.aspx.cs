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

public partial class popupsupplement : System.Web.UI.Page
{
    string compcode, userid, dateformat, suppcode, alias, validco;
    string sortfield;
    string show;
    int j = 0;
    static string gbeditionalias, gbfirstcycle, gbsecondcycle;
    public static string date1 = "";
    static int i;
    DataRow my_row;
    public static int numberDiv;
    static DataSet dk1 = new DataSet();
    string fdate, tdate;
    string rifrom, rito;
    string message;
    protected void Page_Load(object sender, EventArgs e)
    {


        
        Response.Expires = -1;
        if (Session["compcode"] != null)
        {

            hiddencompcode.Value = Session["compcode"].ToString();
            compcode = hiddencompcode.Value;
            hiddenuserid.Value = Session["userid"].ToString();
            userid = hiddenuserid.Value;
            hiddendateformat.Value = Session["dateformat"].ToString();
            dateformat = hiddendateformat.Value;
            show = Request.QueryString["show"].ToString();
            suppcode = Request.QueryString["suppcode1"].ToString().Trim();
            hiddensuppcode.Value = Request.QueryString["suppcode1"].ToString();
            hiddenperiodicity.Value = Request.QueryString["periodicity1"].ToString();
            validco = Request.QueryString["validationco"].ToString();
           
            alias = Request.QueryString["alias1"].ToString();
            hiddenshow.Value = Request.QueryString["show"].ToString();
            //rifrom = hiddenfdate.Value;
            //rito = hiddentaddate.Value;

        }
        else
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(popupsupplement));

       
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/popupsupplement.xml"));
        lbsupplementname.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbaddate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        btnsubmit.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        btnclear.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        btndelete.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        btnclose.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();

        btndelete.Enabled = false;

        if (!Page.IsPostBack)
        {
            if (dk1.Tables.Count > 0 && (Session["suppdate"] == null || Session["suppdate"] == ""))
            {
                //dk.Clear();
                //dk.Dispose();
                //dk = new DataSet();

                //dk.Clear();
                //dk.Dispose();

                dk1 = new DataSet();
            }
            if (show.Trim() == "1")
            {
                btnsubmit.Enabled = true;
                txtaddate.Enabled = true;
                txtdate.Enabled = true;
                txteditionname.Enabled = true;

            }
            else
            {
                btnsubmit.Enabled = false;
                txtaddate.Enabled = false;
                txtdate.Enabled = false;
                txteditionname.Enabled = false;


            }

           /* if ((Session["firstdate"] == null) && (Session["seconddate"] ==null))
            {
                DataGrid2.Visible = false;
                //divdg2.Visible = false;
                //divdatagd1.Visible = true;
                DataGrid1.Visible = true;
                bindgrid("Supp_Alias");
                //datagridbind("Exec_name");
            }
            else
            {
                DataGrid2.Visible = true;
              //  divdg2.Visible = true;
                //divdatagd1.Visible = false;
                DataGrid1.Visible = false;
                bindgrid1("Supp_Alias");
            }*/
            bindgrid("Supp_Alias");

            filleditalias(suppcode, compcode, userid);

           
             btnsubmit.Attributes.Add("OnClick","javascript:return submitclick();");
             txtdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
             txtaddate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
             btndelete.Attributes.Add("OnClick","javascript:return deletegridclick();");
             btnclear.Attributes.Add("OnClick","javascript:return clearclick();");
             //btnclear.Attributes.Add("OnClick","javascript:return clearclick();");
        }
        //if (validco == "2 ")
        //{
        //    lbaddate.Attributes.Add("style", "display:none");
        //    txtaddate.Attributes.Add("style", "display:none");
        //}

    }
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(popupsupplement), "ShowAlert", strAlert, true);
    }
    public void bindgrid(string sortfield)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.SupplimentMaster bind = new NewAdbooking.Classes.SupplimentMaster();

            ds = bind.ratebind(suppcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.SupplimentMaster bind = new NewAdbooking.classesoracle.SupplimentMaster();
            ds = bind.ratebind(suppcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.SupplimentMaster bind = new NewAdbooking.classmysql.SupplimentMaster();
            ds = bind.ratebind(suppcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
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

        DataGrid2.Visible = true;
        divgrid21.Visible = true;
        DataGrid1.Visible = false;
        divgrid1.Visible = false;

        DataSet ds_tbl = new DataSet();


        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "suppdate_code";
        mydatatable.Columns.Add(mycolumn);
        // DataRow myrow;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Supp_Alias";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Date_Supplement";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "AdditionalDate_Supp";
        mydatatable.Columns.Add(mycolumn);


        my_row = mydatatable.NewRow();

        my_row["suppdate_code"] = "0";
        my_row["Supp_Alias"] = gbeditionalias;
        my_row["Date_Supplement"] = gbfirstcycle;
        my_row["AdditionalDate_Supp"] = gbsecondcycle;
        //gbsecondcycle = txtaddate.Text;

        //mydatatable.Rows.Add(my_row);

        ds_tbl.Tables.Add(mydatatable);

        if (Session["suppdate"] == null)
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


            ViewState["SortExpression"] = sortfield;
            ViewState["order"] = "ASC";
            DataView dv = new DataView();
            //if (g == 0)
            //{
            dv = ds_tbl.Tables[0].DefaultView;

            DataGrid2.DataSource = dv;
            DataGrid2.DataBind();
            d = 0;
        }
        txtaddate.Text = "";
        txtdate.Text = "";
        gbfirstcycle = "";
        gbsecondcycle = "";

    }



      

    public void filleditalias(string suppcode, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.SupplimentMaster filltxtalias = new NewAdbooking.Classes.SupplimentMaster();

            // ds = filltxtalias.filleditalias(suppcode, compcode, userid);
            //  if (ds.Tables[0].Rows[0].ItemArray[0].ToString() !="")
            //  {
            txteditionname.Text = alias;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.SupplimentMaster filltxtalias = new NewAdbooking.classesoracle.SupplimentMaster();
            txteditionname.Text = alias;
        }
        else
        {
            NewAdbooking.classmysql.SupplimentMaster filltxtalias = new NewAdbooking.classmysql.SupplimentMaster();
            txteditionname.Text = alias;
        }
        //  }

        //return ds;


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










    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]

    public void insert(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string suppcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.SupplimentMaster insertgrid = new NewAdbooking.Classes.SupplimentMaster();

            ds = insertgrid.inserteditname(txteditionname, txtdate, txtaddate, compcode, userid, suppcode, Session["dateformat"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.SupplimentMaster insertgrid = new NewAdbooking.classesoracle.SupplimentMaster();

            ds = insertgrid.inserteditname(txteditionname, txtdate, txtaddate, compcode, userid, suppcode, Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.SupplimentMaster insertgrid = new NewAdbooking.classmysql.SupplimentMaster();
            ds = insertgrid.inserteditname(txteditionname, txtdate, txtaddate, compcode, userid, suppcode,Session["dateformat"].ToString());
        }


    }

    //////////[Ajax.AjaxMethod]

    //////////public void deletegrid(string editcode, string compcode, string userid, string code10)
    //////////{
    //////////    NewAdbooking.Classes.SupplimentMaster delete = new NewAdbooking.Classes.SupplimentMaster();
    //////////    DataSet ds = new DataSet();
    //////////    ds = delete.griddelete(editcode, compcode, userid, code10);


    //////////}

    private void hiddencurrcode_ServerChange(object sender, System.EventArgs e)
    {

    }

    [Ajax.AjaxMethod]

    public DataSet selected(string suppcode, string compcode, string userid, string code10)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.SupplimentMaster selectgrid = new NewAdbooking.Classes.SupplimentMaster();

            ds = selectgrid.selectedfromgrid(suppcode, compcode, userid, code10);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.SupplimentMaster selectgrid = new NewAdbooking.classesoracle.SupplimentMaster();
            ds = selectgrid.selectedfromgrid(suppcode, compcode, userid, code10);

            return ds;
        }
        else
        {
            NewAdbooking.classmysql.SupplimentMaster selectgrid = new NewAdbooking.classmysql.SupplimentMaster();
            ds = selectgrid.selectedfromgrid(suppcode, compcode, userid, code10);

            return ds;
        }

    }

    [Ajax.AjaxMethod]

    public void update(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string suppcode, string code10)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.SupplimentMaster updategrid = new NewAdbooking.Classes.SupplimentMaster();

            ds = updategrid.gridupdate(txteditionname, txtdate, txtaddate, compcode, userid, suppcode, code10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.SupplimentMaster updategrid = new NewAdbooking.classesoracle.SupplimentMaster();
            ds = updategrid.gridupdate(txteditionname, txtdate, txtaddate, compcode, userid, suppcode, code10);
        }
        else
        {
            NewAdbooking.classmysql.SupplimentMaster updategrid = new NewAdbooking.classmysql.SupplimentMaster();
            ds = updategrid.gridupdate(txteditionname, txtdate, txtaddate, compcode, userid, suppcode, code10);
        }

    }

    [Ajax.AjaxMethod]

    public void deletegrid(string suppcode, string compcode, string userid, string code10)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.SupplimentMaster delete = new NewAdbooking.Classes.SupplimentMaster();

            ds = delete.griddelete(suppcode, compcode, userid, code10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.SupplimentMaster delete = new NewAdbooking.classesoracle.SupplimentMaster();
            ds = delete.griddelete(suppcode, compcode, userid, code10);
        }
        else
        {
            NewAdbooking.classmysql.SupplimentMaster delete = new NewAdbooking.classmysql.SupplimentMaster();
            ds = delete.griddelete(suppcode, compcode, userid, code10);
        }


    }

    //[Ajax.AjaxMethod]

    //public DataSet chkinsert(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string suppcode)
    //{
    //    NewAdbooking.Classes.SupplimentMaster chkdate = new NewAdbooking.Classes.SupplimentMaster();
    //    DataSet ds = new DataSet();
    //    ds = chkdate.chkdaetedit(txteditionname, txtdate, txtaddate, compcode, userid, suppcode);

    //    return ds;


    //}

    [Ajax.AjaxMethod]

    public DataSet chkperiodicty(string periodicty)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.SupplimentMaster chkperiodicty = new NewAdbooking.Classes.SupplimentMaster();

            ds = chkperiodicty.chkperiodicty(periodicty);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.SupplimentMaster chkperiodicty = new NewAdbooking.classesoracle.SupplimentMaster();

            ds = chkperiodicty.chkperiodicty(periodicty);

            return ds;
        }
        else
        {
            NewAdbooking.classmysql.SupplimentMaster chkperiodicty = new NewAdbooking.classmysql.SupplimentMaster();
            ds = chkperiodicty.chkperiodicty(periodicty);

            return ds;

        }

    }

    [Ajax.AjaxMethod]

    public DataSet chkupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string suppcode, string code10)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.SupplimentMaster chkdateup = new NewAdbooking.Classes.SupplimentMaster();

            ds = chkdateup.chkdateupdate(txteditionname, txtdate, txtaddate, compcode, userid, suppcode, code10);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.SupplimentMaster chkdateup = new NewAdbooking.classesoracle.SupplimentMaster();
            ds = chkdateup.chkdateupdate(txteditionname, txtdate, txtaddate, compcode, userid, suppcode, code10);

            return ds;
        }
        else
        {
            NewAdbooking.classmysql.SupplimentMaster chkdateup = new NewAdbooking.classmysql.SupplimentMaster();
            ds = chkdateup.chkdateupdate(txteditionname, txtdate, txtaddate, compcode, userid, suppcode, code10);

            return ds;
        }

    }

    protected void hiddendateformat_ServerChange(object sender, System.EventArgs e)
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


                    case "Supp_Alias":
                        str = "Supplement Name";
                        break;

                    case "Date_Supplement":
                        str = "Date";
                        break;

                    case "AdditionalDate_Supp":
                        str = "Additional Date";
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

        NewAdbooking.Classes.SupplimentMaster databind = new NewAdbooking.Classes.SupplimentMaster();
      

        ds = databind.ratebind(suppcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());

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


    
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>");
    }
    protected void hiddensuppcode_ServerChange(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string sd = "hello";



        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "suppdate_code";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Supp_Alias";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Date_Supplement";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "AdditionalDate_Supp";
        mydatatable1.Columns.Add(mycolumn1);

        //--------------------------------------------------------------------------------------

        // Code for Checking the redundency of grid 
        //during the timr of insertinr new record at 
        //runtime when records are submitted in 
        //the session only

        //--------------------------------------------------------------------------------------
        DataSet len = (DataSet)Session["suppdate"];
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
        if (Session["suppdate"] != null && Session["suppdate"] != "")
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

                string txtfrom = txtdate.Text;
                string txtto = txtaddate.Text;

                string[] txtff = txtfrom.Split('/');
                string txtmm = txtff[0];//.ToString();
                string txtdd = txtff[1];
                string txtyyyy = txtff[2];

                string[] txttt = txtto.Split('/');
                string txtmm1 = txttt[0];//.ToString();
                string txtdd1 = txttt[1];
                string txtyyyy1 = txttt[2];

                //if (len.Tables[i].Rows[0].ItemArray[6].ToString() == drpadtype.SelectedValue)
                //{
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
                            message = "Issue Date has already been assigned ";
                            AspNetMessageBox(message);
                            return;

                        }
                    }
                    //}
                }



                j++;

            }
        }


        myrow1 = mydatatable1.NewRow();

        myrow1["suppdate_code"] = "00";


        myrow1["Supp_Alias"] = txteditionname.Text;
        gbeditionalias = txteditionname.Text;

        myrow1["Date_Supplement"] = txtdate.Text;
        gbfirstcycle = txtdate.Text;

        // Session["firstdate"] = "";


        myrow1["AdditionalDate_Supp"] = txtaddate.Text;
        gbsecondcycle = txtaddate.Text;
        // Session["seconddate"] = "";

        mydatatable1.Rows.Add(myrow1);

        dk1.Tables.Add(mydatatable1);
        Session["suppdate"] = dk1;

        bindgrid1("Supp_Alias");
    }
}




    
