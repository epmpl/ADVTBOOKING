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

public partial class bank_master : System.Web.UI.Page
{
    string agencode, agencysubcode, comp, userid, show;
    int j=0;
    string sortfield;
    public static int numberDiv;
    static string gbbank_name, gbbranch, gbcountryname, gbcityname, gbbank_no, gbAcount_No;
    static int i;
    DataSet dk1 = new DataSet();
    DataSet dk = new DataSet();
    DataRow my_row;
    string message;
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(bank_master), "ShowAlert", strAlert, true);
    }


    private void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here	

        Response.Expires = -1;

        if (Session["compcode"] != null)
        {

            userid = Session["userid"].ToString();
            hiddenuserid.Value = userid;
            comp = Session["compcode"].ToString();
            hiddencomcode.Value = comp;
            hiddendateformat.Value = Session["dateformat"].ToString();
            show = Request.QueryString["show"].ToString();
            hiddensaurabh.Value = show;
            //Response.Write("<script>alert('Your Session Expired Please Relogin ');</script>");
        }
        else
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(bank_master));
        //			-------------------------------------Code Of XML File--------------
        //		
        DataSet objDataSet = new DataSet();

        objDataSet.ReadXml(Server.MapPath("XML/bank_master.xml"));

        BankName.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        Branch.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString() ;
        Country.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        BankNo.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString() ;
        City.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString() ;
        ACCNO.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString() ;
        btnsubmit.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        clear.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        btndelete.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
        btnclose.Text = objDataSet.Tables[0].Rows[0].ItemArray[9].ToString();

        //         --------------------------------End-------------------------------------------------

        
        agencode = Request.QueryString["agecode"].ToString();
        hiddenagencycode.Value = agencode;
        Session["hiddenagevcode"] = hiddenagevcode.Value;
        agencysubcode = Request.QueryString["agencysubcode"].ToString();
        hiddenagensubcode.Value = agencysubcode;
        //DataSet objDataSet = new DataSet();
        //read XML File
//work done by shweta
    
        if (agencode != "" && agencysubcode != "")
        { }
        else
        {
            Response.Write("<script>alert('You Should Enter The Agency Code First And Sub Code');window.close();</script>");

            return;
        }
//******************************************************
        if (show == "2")
        {
            btnsubmit.Enabled = true;
            btndelete.Enabled = true;
            txtano.Enabled = true;
            txtbno.Enabled = true;
            txtbran.Enabled = true;
            txtname.Enabled = true;
            drpcountryname.Enabled = true;
            drpcity.Enabled = true;
            //btnclose.Enabled = true;
        }
        if (show == "1")
        {
            btnsubmit.Enabled = true;
            btndelete.Enabled = false;
            txtano.Enabled = true;
            txtbno.Enabled = true;
            txtbran.Enabled = true;
            txtname.Enabled = true;
            drpcountryname.Enabled = true;
            drpcity.Enabled = true;
            //btnclose.Enabled = true;
        }
        if(show=="0")
        {
            btnsubmit.Enabled = false;
            btndelete.Enabled = false;
            txtano.Enabled = false;
            txtbno.Enabled = false;
            txtbran.Enabled = false;
            txtname.Enabled = false;
            drpcountryname.Enabled = false;
            drpcity.Enabled = false;
            //btnclose.Enabled = false;
        }


        countryname();
      //  binddata("bank_name");


        if (!Page.IsPostBack)
        {
            if (dk1.Tables.Count > 0 && Session["bankmaster"]==null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();

                //dk.Clear();
                //dk.Dispose();
                dk = new DataSet();
            }
            //if (dk1.Tables.Count > 0)
            //{
            //    dk.Clear();
            //    dk.Dispose();
            //    dk = new DataSet();

            //    //dk.Clear();
            //    //dk.Dispose();
            //    dk1 = new DataSet();
            //}
            if (Session["hiddenagevcode"] != null)
            {

                DataGrid2.Visible = false;
                Div2.Visible = false;

                Div1.Visible = true;
                DataGrid1.Visible = true;

                binddata("bank_name");

            }
            else
            {

                DataGrid2.Visible = true;
                Div2.Visible = true;

                Div1.Visible = false;
                DataGrid1.Visible = false;


                bindgrid1("bank_name");

            }

            if (Session["bankmaster"] != null)
            {
                bindgrid1("bank_name");
            }

            drpcountryname.Attributes.Add("OnChange", "javascript:return fillcity();");
            btnsubmit.Attributes.Add("OnClick", "javascript:return submitdata();");
            //btnclose.Attributes.Add("OnClick", "javascript:return selected();");
            btndelete.Attributes.Add("OnClick", "javascript:return deleted();");
            clear.Attributes.Add("OnClick", "javascript:return cleardata();");
            //chk for validations shweta
            txtname.Attributes.Add("OnBlur", "javascript:return uppercase('txtname');");
            txtbran.Attributes.Add("OnBlur", "javascript:return uppercase('txtbran');");
            txtbno.Attributes.Add("OnBlur", "javascript:return uppercase('txtbno');");
            txtano.Attributes.Add("OnBlur", "javascript:return uppercase('txtano');");



            //***********************************************************************

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
        //this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion






    public void countryname()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bankmaster name = new NewAdbooking.Classes.bankmaster();

            ds = name.adcountryname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bankmaster name = new NewAdbooking.classesoracle.bankmaster();
            ds = name.adcountryname(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "adcountryname_adcountryname_p";
            string[] parameterValueArray = { Session["compcode"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.bankmaster name = new NewAdbooking.classmysql.bankmaster();
            //ds = name.adcountryname(Session["compcode"].ToString());
        }
        drpcountryname.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-----Select Country-----";
        li1.Value = "0";
        li1.Selected = true;
        drpcountryname.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpcountryname.Items.Add(li);
        }
    }

    public void cityname(string country)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bankmaster name = new NewAdbooking.Classes.bankmaster();

            ds = name.countcity(country);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bankmaster name = new NewAdbooking.classesoracle.bankmaster();
            ds = name.countcity(country);
        }
        else
        {
            NewAdbooking.classmysql.bankmaster name = new NewAdbooking.classmysql.bankmaster();
            ds = name.countcity(country);
        }
        drpcity.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-----Select City-----";
        li1.Value = "0";
        li1.Selected = true;
        drpcity.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpcity.Items.Add(li);
        }
    }




    [Ajax.AjaxMethod]
    public DataSet addcou(string country)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master firstAgency = new NewAdbooking.Classes.Master();

            ds = firstAgency.countcity(country);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master firstAgency = new NewAdbooking.classesoracle.Master();
            ds = firstAgency.countcity(country);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.Master firstAgency = new NewAdbooking.classmysql.Master();
            ds = firstAgency.countcity(country);
            return ds;
        }
    }


    public void binddata(string sortfield)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bankmaster bind = new NewAdbooking.Classes.bankmaster();

            ds = bind.bankbind(agencode, agencysubcode, comp, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bankmaster bind = new NewAdbooking.classesoracle.bankmaster();
            ds = bind.bankbind(agencode, agencysubcode, comp, userid);
        }
        else
        {

            string procedureName = "bindbankdata_bindbankdata_p";
            string[] parameterValueArray = {comp ,userid  , agencode, agencysubcode };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

           // NewAdbooking.classmysql.bankmaster bind = new NewAdbooking.classmysql.bankmaster();
           // ds = bind.bankbind(agencode, agencysubcode, comp, userid);
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
        DataGrid1.Visible = false;
        DataGrid2.Visible = true;
        Div2.Visible = true;
        DataSet ds_tbl = new DataSet();


        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "bank_name";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "branch";
        mydatatable.Columns.Add(mycolumn);
        // DataRow myrow;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "countryname";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "cityname";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "bank_no";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Acount_No";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "autobank";
        mydatatable.Columns.Add(mycolumn);

        if (Session["bankmaster"] == null)
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
            dsnew = (DataSet)Session["bankmaster"];
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
        gbbank_name = "";
        gbbranch = "";
        gbcountryname = "";
        gbcityname = "";
        gbbank_no = "";
        gbAcount_No = "";

        txtname.Text="";
        txtbran.Text="";
        drpcountryname.SelectedValue="0";
        drpcity.SelectedValue ="0";
        txtbno.Text="";
        txtano.Text = "";

        hiddencity.Value = "";
        hiddencountry.Value = "";
          
           

        
    }
    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        DataView dv = new DataView();
        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return selected('" + str + "');\" value=" + e.Item.Cells[7].Text + "  />";
            j++;
        }

        if (e.Item.ItemType == ListItemType.Header)
        {
            for (int a = 0; a <= e.Item.Cells.Count - 1; a++)
            {
                //e.Item.Cells[a].Attributes.Add("onmousedown", "abc3(this,event)");
                //e.Item.Cells[a].Attributes.Add("onmousemove", "abc2(this,event)");
                //e.Item.Cells[a].Attributes.Add("onmouseup", "abc1(this,event)");
                //e.Item.Cells[a].Width = Unit.Pixel(300);
                //e.Item.Cells[a].ID = "d" + Convert.ToString(a);
            }
            if (ViewState["SortExpression"].ToString() != "")
            {
                string str = "";
                switch (ViewState["SortExpression"].ToString())
                {
                    case "bank_name":
                        str = "Bank Name";
                        break;
                    case "branch":
                        str = "Branch";
                        break;

                    case "countryname":
                        str = "Country";
                        break;

                    case "cityname":
                        str = "City";
                        break;

                    case "bank_no":
                        str = "Bank NO.";
                        break;

                    case "Acount_No":
                        str = "Account No.";
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
    public void insert(string bankname, string branch, string country, string city, string bankno, string accountno, string compcode, string userid, string agencode, string subagncode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bankmaster ins = new NewAdbooking.Classes.bankmaster();

            ds = ins.insertdata(bankname, branch, country, city, bankno, accountno, compcode, userid, agencode, subagncode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.bankmaster ins = new NewAdbooking.classesoracle.bankmaster();
            ds = ins.insertdata(bankname, branch, country, city, bankno, accountno, compcode, userid, agencode, subagncode);
        }
        else
        {
            NewAdbooking.classmysql.bankmaster ins = new NewAdbooking.classmysql.bankmaster();
            ds = ins.insertdata(bankname, branch, country, city, bankno, accountno, compcode, userid, agencode, subagncode);
        }
    }


    [Ajax.AjaxMethod]
    public DataSet bandcontact(string compcode, string userid, string agencode, string subagncode, string code10)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bankmaster databind = new NewAdbooking.Classes.bankmaster();

            da = databind.bankdata(compcode, userid, agencode, subagncode, code10);
            
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bankmaster databind = new NewAdbooking.classesoracle.bankmaster();
            da = databind.bankdata(compcode, userid, agencode, subagncode, code10);
        }
        else
        {
            NewAdbooking.classmysql.bankmaster databind = new NewAdbooking.classmysql.bankmaster();

            da = databind.bankdata(compcode, userid, agencode, subagncode, code10);
            //return da;
        }
        return da;
    }


    [Ajax.AjaxMethod]
    public void update(string bankname, string branch, string country, string city, string bankno, string accountno, string compcode, string userid, string agencode, string subagncode, string codebk)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bankmaster ins = new NewAdbooking.Classes.bankmaster();

            ds = ins.updatedata(bankname, branch, country, city, bankno, accountno, compcode, userid, agencode, subagncode, codebk);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bankmaster ins = new NewAdbooking.classesoracle.bankmaster();
            ds = ins.updatedata(bankname, branch, country, city, bankno, accountno, compcode, userid, agencode, subagncode, codebk);
        }
        else
        {
            NewAdbooking.classmysql.bankmaster ins = new NewAdbooking.classmysql.bankmaster();
            ds = ins.updatedata(bankname, branch, country, city, bankno, accountno, compcode, userid, agencode, subagncode, codebk);
        }

    }


    [Ajax.AjaxMethod]
    public void dele(string compcode, string userid, string codebk)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bankmaster ins = new NewAdbooking.Classes.bankmaster();

            ds = ins.deletedata(compcode, userid, codebk);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bankmaster ins = new NewAdbooking.classesoracle.bankmaster();
            ds = ins.deletedata(compcode, userid, codebk);
        }
        else
        {
            NewAdbooking.classmysql.bankmaster ins = new NewAdbooking.classmysql.bankmaster();
            ds = ins.deletedata(compcode, userid, codebk);
        }
    }




    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>"); 
    }
    // ad new
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
   

    private void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bankmaster bind = new NewAdbooking.Classes.bankmaster();

            ds = bind.bankbind(agencode, agencysubcode, comp, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bankmaster bind = new NewAdbooking.classesoracle.bankmaster();
            ds = bind.bankbind(agencode, agencysubcode, comp, userid);
        }
        else
        {
            NewAdbooking.classmysql.bankmaster bind = new NewAdbooking.classmysql.bankmaster();

            ds = bind.bankbind(agencode, agencysubcode, comp, userid);
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

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;

        //DataColumn mycolumn;
        //DataTable mydatatable = new DataTable();
        //DataRow myrow;

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "bank_name";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "branch";
        mydatatable1.Columns.Add(mycolumn1);
        // DataRow myrow;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "countryname";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "cityname";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "bank_no";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Acount_No";
        mydatatable1.Columns.Add(mycolumn1);


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "autobank";
        mydatatable1.Columns.Add(mycolumn1);
    
  

        myrow1 = mydatatable1.NewRow();

        myrow1["autobank"] = "00";
        
        myrow1["bank_name"] = txtname.Text;
        gbbank_name = txtname.Text;

        myrow1["branch"] = txtbran.Text;
        gbbranch = txtbran.Text;

     

        //myrow1["countryname"] = drpcountryname.SelectedValue;
        drpcountryname.SelectedValue = hiddencountry.Value;
       // myrow1["countryname"] = drpcountryname.SelectedItem.Text;//.Value;
        myrow1["countryname"] = drpcountryname.SelectedItem.Value;
        //drpcountryname.SelectedValue = hiddencountry.Value;
        //gbcountryname = drpcountryname.SelectedValue;
        gbcountryname = hiddencountry.Value;
        string country = gbcountryname;

        //drpcity.SelectedValue = hiddencity.Value;

        //ScriptManager.RegisterClientScriptBlock(this, typeof(bank_master), "ss", "fillcitynameinsert(country);", true);

        cityname(country);

        drpcity.SelectedValue = hiddencity.Value;
       // myrow1["cityname"] = drpcity.SelectedItem.Text;
        myrow1["cityname"] = drpcity.SelectedItem.Value;
        //string sau = drpcity.Items.FindByValue(hiddencity.Value).Text;
        //gbcountryname = drpcountryname.SelectedValue;
        gbcityname = hiddencity.Value;

       

        //myrow1["cityname"] = drpcity.SelectedValue;
        //gbcityname = drpcity.SelectedValue;

        myrow1["bank_no"] = txtbno.Text;
        gbbank_no = txtbno.Text;

        myrow1["Acount_No"] = txtano.Text;
        gbAcount_No = txtano.Text;

        DataSet len = (DataSet)Session["bankmaster"];
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
       // if (Session["bankmaster"] != null && Session["bankmaster"] != "")
        if(DataGrid2.Items.Count>0)
        {
            while (j < DataGrid2.Items.Count)
            {
                string bg_no = DataGrid2.Items[j].Cells[0].Text;// len.Tables[i].Rows[0].ItemArray[0].ToString();
                string txtbg_no = txtname.Text;


                if (txtbg_no == bg_no)
                {
                    message = "You have already entered this Bank Name.";
                    txtname.Text = "";
                    AspNetMessageBox(message);
                    return;
                }
                j++;
            }
        }

        mydatatable1.Rows.Add(myrow1);
        if (Session["bankmaster"] != null)
        {
            DataSet dsNew = new DataSet();
            dsNew = (DataSet)Session["bankmaster"];
            dk1 = dsNew;
        }

        dk1.Tables.Add(mydatatable1);
       
        Session["bankmaster"] = dk1;


        //------------------------ ad new ==========================//


        //----------------------------------------------------------//
         //DataColumn mycolumn;
        //DataTable mydatatable = new DataTable();

    //    mycolumn = new DataColumn();
    //    mycolumn.DataType = System.Type.GetType("System.String");
    //    mycolumn.ColumnName = "bank_name";
    //    mydatatable.Columns.Add(mycolumn);

    //    mycolumn = new DataColumn();
    //    mycolumn.DataType = System.Type.GetType("System.String");
    //    mycolumn.ColumnName = "branch";
    //    mydatatable.Columns.Add(mycolumn);
    //    // DataRow myrow;
    //    mycolumn = new DataColumn();
    //    mycolumn.DataType = System.Type.GetType("System.String");
    //    mycolumn.ColumnName = "countryname";
    //    mydatatable.Columns.Add(mycolumn);

    //    // //DataColumn mycolumn;
    //    mycolumn = new DataColumn();
    //    mycolumn.DataType = System.Type.GetType("System.String");
    //    mycolumn.ColumnName = "cityname";
    //    mydatatable.Columns.Add(mycolumn);

    //    mycolumn = new DataColumn();
    //    mycolumn.DataType = System.Type.GetType("System.String");
    //    mycolumn.ColumnName = "bank_no";
    //    mydatatable.Columns.Add(mycolumn);

    //    mycolumn = new DataColumn();
    //    mycolumn.DataType = System.Type.GetType("System.String");
    //    mycolumn.ColumnName = "Acount_No";
    //    mydatatable.Columns.Add(mycolumn);


    //    mycolumn = new DataColumn();
    //    mycolumn.DataType = System.Type.GetType("System.String");
    //    mycolumn.ColumnName = "bg_code";
    //    mydatatable.Columns.Add(mycolumn);
  

    //    myrow = mydatatable.NewRow();

    ////    myrow["autobank"] = "00";

    //    myrow["bank_name"] = txtname.Text;

    //    myrow["branch"] = txtbran.Text;

    //    myrow["countryname"] = drpcountryname.Text;

    //    myrow["cityname"] = drpcity.Text;

    //    myrow["bank_no"] = txtbno.Text;

    //    myrow["Acount_No"] = txtano.Text;

    //    mydatatable.Rows.Add(myrow);

    //    dk1.Tables.Add(mydatatable);

        bindgrid1("bank_name");

    


   
    }
}
