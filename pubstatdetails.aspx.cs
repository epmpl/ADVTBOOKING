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

public partial class pubstatdetails : System.Web.UI.Page
{
    string compcode, userid, dateformat, centcode, alias;
    string sortfield;
    string show,message;
    int j = 0;
    static int i;
    static string gbfrom, gbto, gbstatus, gbcircular;
    static DataSet dk1 = new DataSet();
    static DataSet dk = new DataSet();
    public static int numberDiv;
    public static string date1 = "";
    DataRow my_row;
    public static int flag = 0;
    
    protected void Page_Load(object sender, System.EventArgs e)
    {
       
        txtfrom.Focus();
        Response.Expires = -1;
        
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }

        show = Request.QueryString["show"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(pubstatdetails));

        

        compcode = Session["compcode"].ToString();
        hiddencompcode.Value = compcode;
        userid = Session["userid"].ToString();
        hiddenuserid.Value = userid;

        dateformat = Session["dateformat"].ToString();
        hiddendateformat.Value = dateformat;

        centcode = Request.QueryString["centcode"].ToString();
        hiddencentcode.Value = centcode;
        Session["centcode"] = centcode;
        hiddenshow.Value = show;

        DataSet objDataSet = new DataSet();
        objDataSet.ReadXml(Server.MapPath("XML/pubstatusdetail.xml"));
        lbFrom.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lbTO.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        lbStaus.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        lbCircularNo.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        btnsubmit.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        btnclose.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        btndelete.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        btnclear.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();


        if (hiddencentcode.Value == "" || hiddencentcode.Value == null)
        {
            Response.Write("<script> alert('Please Enter Center Name ');window.close(); </script>");
        }

      if (show == "1")
        {
            btnsubmit.Enabled = true;
            txtto.Enabled = true;
            txtfrom.Enabled = true;
            txtCircular.Enabled = true;
            drpstatus.Enabled = true;
            btndelete.Enabled = false;

        }
        if (show == "0")
        {
            btndelete.Enabled = false;
            btnsubmit.Enabled = false;
            txtto.Enabled = false;
            txtfrom.Enabled = false;
            txtCircular.Enabled = false;
            drpstatus.Enabled = false;

        }

        if (show == "2")
        {
            btnsubmit.Enabled = true;

            btndelete.Enabled = false;
            txtto.Enabled = true;
            txtfrom.Enabled = true;
            txtCircular.Enabled = true;
            drpstatus.Enabled = true;


        }

        

//        *******************************************************************************

        if (!Page.IsPostBack)
        {
            statusname();

            if ((dk1.Tables.Count > 0) && (Session["pubstatus"] == null))
            {
                dk.Clear();
                dk.Dispose();
                dk = new DataSet();

                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();
            }


            if (Session["centcode"] != "")
            //if (hiddencentcode.Value != "")
            {
                DataGrid2.Visible = false;
                Divgrid2.Visible = false;
                Divgrid1.Visible = true;
                DataGrid1.Visible = true;
                //saurabh change                  
                

                bindgrid("cent_status");
            }
            else
            {
                DataGrid2.Visible = true;
                Divgrid2.Visible = true;
                //saurabh change
            //    btndelete.Enabled = false;

                Divgrid1.Visible = false;
                DataGrid1.Visible = false;
                bindgrid1("cent_status");

            }

            //saurabh

            if (Session["pubstatus"] != null)
            {
                bindgrid1("cent_status");
            }


            // databind11("cent_status");
            btnsubmit.Attributes.Add("OnClick", "javascript:return submitstatus();");
            
            //btnselect.Attributes.Add("OnClick", "javascript:return selectstatus();");
            //btndelete.Attributes.Add("OnCLick", "javascript:return statusdelete();");

            //saurabh change

            btndelete.Attributes.Add("OnCLick", "javascript:return statusdelete();");

            txtto.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txtfrom.Attributes.Add("OnChange", "javascript:return checkdate(this);");

            btnclear.Attributes.Add("OnClick", "javascript:return popclear();");
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
        this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);

    }
    #endregion

    //public void databind11(string sortfield)
    //{
    //    //int flag=0;
    //    NewAdbooking.Classes.PubCatMast bind = new NewAdbooking.Classes.PubCatMast();
    //    DataSet ds = new DataSet();
    //    ds = bind.getbind(compcode, userid, centcode);

    //    ViewState["SortExpression"] = sortfield;
    //    ViewState["order"] = "ASC";
    //    DataView dv = new DataView();
    //    dv = ds.Tables[0].DefaultView;
    //    dv.Sort = sortfield;

    //    DataGrid1.DataSource = dv;
    //    DataGrid1.DataBind();
    //}

    public void statusname()
    {
        drpstatus.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop name = new NewAdbooking.Classes.pop();

            ds = name.addstatusname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop name = new NewAdbooking.classesoracle.pop();
            ds = name.addstatusname(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.pop name = new NewAdbooking.classmysql.pop();
            ds = name.addstatusname(Session["compcode"].ToString());
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

    public void bindgrid(string sortfield)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.PubCatMast bind = new NewAdbooking.Classes.PubCatMast();
        
       
        ds = bind.getbind(centcode, compcode, userid, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast bind = new NewAdbooking.classesoracle.PubCatMast();
            ds = bind.getbind(centcode, compcode, userid, dateformat);
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast bind = new NewAdbooking.classmysql.PubCatMast();


            ds = bind.getbind(centcode, compcode, userid, dateformat);
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
    public string insertpcm(string compcode, string userid, string centcode, string status, string circular, string todate, string fromdate, string dateformat)
    {
        string flag;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.PubCatMast insert = new NewAdbooking.Classes.PubCatMast();

            ds = insert.pcmstatuscheck(compcode, userid, centcode, status, circular, todate, fromdate, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast insert = new NewAdbooking.classesoracle.PubCatMast();
            ds = insert.pcmstatuscheck(compcode, userid, centcode, status, circular, todate, fromdate, dateformat);
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast insert = new NewAdbooking.classmysql.PubCatMast();

            ds = insert.pcmstatuscheck(compcode, userid, centcode, status, circular, todate, fromdate, dateformat);

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
    public void insertpcm12(string compcode, string userid, string centcode, string status, string todate, string fromdate, string circular, string dateformat)
    {
     DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.PubCatMast insert = new NewAdbooking.Classes.PubCatMast();
           
            ds = insert.insertpcmstatus(compcode, userid, centcode, status, todate, fromdate, circular);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast insert = new NewAdbooking.classesoracle.PubCatMast();
            ds = insert.insertpcmstatus(compcode, userid, centcode, status, todate, fromdate, circular, dateformat);
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast insert = new NewAdbooking.classmysql.PubCatMast();

            ds = insert.insertpcmstatus(compcode, userid, centcode, status, todate, fromdate, circular);
        }
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }


    [Ajax.AjaxMethod]
    public string updatepcm(string compcode, string userid, string centcode, string status, string circular, string todate, string fromdate, string dateformat, string codepass)
    {
        string flag;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.PubCatMast update = new NewAdbooking.Classes.PubCatMast();
         
            ds = update.pcmstatuscheck12(compcode, userid, centcode, status, circular, todate, fromdate, dateformat, codepass);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast update = new NewAdbooking.classesoracle.PubCatMast();
            ds = update.pcmstatuscheck12(compcode, userid, centcode, status, circular, todate, fromdate, dateformat, codepass);
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast update = new NewAdbooking.classmysql.PubCatMast();

            ds = update.pcmstatuscheck12(compcode, userid, centcode, status, circular, todate, fromdate, dateformat, codepass);

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
    public void updatepcm12(string compcode, string userid, string centcode, string status, string circular, string todate, string fromdate, string codepass)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.PubCatMast update = new NewAdbooking.Classes.PubCatMast();
            
            ds = update.updatepcmstatus(compcode, userid, centcode, status, circular, todate, fromdate, codepass);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast update = new NewAdbooking.classesoracle.PubCatMast();
            ds = update.updatepcmstatus(compcode, userid, centcode, status, circular, todate, fromdate, codepass);
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast update = new NewAdbooking.classmysql.PubCatMast();

            ds = update.updatepcmstatus(compcode, userid, centcode, status, circular, todate, fromdate, codepass);

        }
       
    }


    [Ajax.AjaxMethod]
    public DataSet deletestatuspcm(string centcode, string compcode, string userid, string codepass)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.PubCatMast delete = new NewAdbooking.Classes.PubCatMast();
        
            ds = delete.deletepcmstatus(centcode, compcode, userid, codepass);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast delete = new NewAdbooking.classesoracle.PubCatMast();
            ds = delete.deletepcmstatus(centcode, compcode, userid, codepass);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast delete = new NewAdbooking.classmysql.PubCatMast();

            ds = delete.deletepcmstatus(centcode, compcode, userid, codepass);
            return ds;
        }
    }





    [Ajax.AjaxMethod]
    public DataSet bandstatus(string centcode, string compcode, string userid, string code11, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.PubCatMast insert = new NewAdbooking.Classes.PubCatMast();
            
            ds = insert.selectpcmstatus(centcode, compcode, userid, code11, dateformat);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast insert = new NewAdbooking.classesoracle.PubCatMast();
            ds = insert.selectpcmstatus(centcode, compcode, userid, code11, dateformat);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast insert = new NewAdbooking.classmysql.PubCatMast();

            ds = insert.selectpcmstatus(centcode, compcode, userid, code11, dateformat);
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

            e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  OnClick=\"javascript:return selectstatus('" + str + "');\" value=" + e.Item.Cells[4].Text + "  />";
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


                    case "cent_status":
                        str = "Status";
                        break;

                    case "FROM_DATE":
                        str = "From Date";
                        break;

                    case "TO_DATE":
                        str = "To Date ";
                        break;


                    case "circular":
                        str = "Circular";
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

                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

                }
                else
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+str+"<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";

                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";

                }
            }
        }
    }


    public void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.PubCatMast bind = new NewAdbooking.Classes.PubCatMast();
            da = bind.getbind(centcode, compcode, userid, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast bind = new NewAdbooking.classesoracle.PubCatMast();
            da = bind.getbind(centcode, compcode, userid, dateformat);
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast bind = new NewAdbooking.classmysql.PubCatMast();
            da = bind.getbind(centcode, compcode, userid, dateformat);
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

    protected void btnclose_Click1(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>");
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


        // DataRow myrow;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "cent_status";
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

  

        my_row = mydatatable.NewRow();


        my_row["cent_status"] = gbstatus;
        my_row["FROM_DATE"] = gbfrom;
        my_row["TO_DATE"] = gbto;
        my_row["STAT_CODE"] = "0";
        my_row["circular"] = gbcircular;
        //my_row["Fax"] = gbfax;
        //my_row["EmailID"] = gbmailid;
        //my_row["Cont_Code"] = "0";
        //gbsecondcycle = txtaddate.Text;

        //  mydatatable.Rows.Add(my_row);

        ds_tbl.Tables.Add(mydatatable);

        // mydatatable.ImportRow(my_row);

        if (Session["pubstatus"] == null)
        {
            ds_tbl.Tables.Add(mydatatable);
            DataGrid2.DataSource = ds_tbl.Tables[0];
            DataGrid2.DataBind();
        }
        else
        {
           // dk1.Clear();
            DataSet dsnew = new DataSet();
            dsnew = (DataSet)Session["pubstatus"];
            int d;
            int g;
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

        txtfrom.Text = "";
        txtto.Text = "";
        txtCircular.Text = "";
        drpstatus.SelectedValue = "0";
        

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
         DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;
           mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "cent_status";
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

            hiddenfdate.Value = hiddenfdate.Value + txtfrom.Text + ",";
            hiddentdate.Value = hiddentdate.Value + txtto.Text + ",";
        //*********************************************************************************************
        
        DataSet len = (DataSet)Session["pubstatus"];
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
        if (Session["pubstatus"] != null && Session["pubstatus"] != "")
        {
            while (j < length)
            {
                string sf = len.Tables[i].Rows[0].ItemArray[1].ToString();
                string st = len.Tables[i].Rows[0].ItemArray[2].ToString();
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

                    if (((Convert.ToInt32(txtmm) >= Convert.ToInt32(mm)) && (Convert.ToInt32(txtmm) <= Convert.ToInt32(mm1))) || ((Convert.ToInt32(txtmm1) >= Convert.ToInt32(mm)) && (Convert.ToInt32(txtmm1) <= Convert.ToInt32(mm1))))
                    {

                        if (((Convert.ToInt32(txtdd) >= Convert.ToInt32(dd)) && (Convert.ToInt32(txtdd) <= Convert.ToInt32(dd1))) || ((Convert.ToInt32(txtdd1) >= Convert.ToInt32(dd)) && (Convert.ToInt32(txtdd1) <= Convert.ToInt32(dd1))))
                        {
                            Response.Write("<script>alert('You have already entered the Commision Apply On for this duration');</script>");
                            return;

                        }
                    }
                }



                j++;

            }
        }



        //*********************************************************************************************


            myrow1 = mydatatable1.NewRow();

            myrow1["STAT_CODE"] = "00";


            myrow1["cent_status"] = drpstatus.SelectedItem.Text;
            gbstatus = drpstatus.SelectedValue;

            

            myrow1["FROM_DATE"] = ttformdate.Text;
            gbfrom = ttformdate.Text;
            myrow1["TO_DATE"] = tttodate.Text;
            gbto = tttodate.Text;
            //myrow1["STAT_CODE"] = txt.Text;
            //gbphone = txtphoneno.Text;
            myrow1["circular"] = txtCircular.Text;
            gbcircular = txtCircular.Text;

            myrow1["status_name"] = drpstatus.SelectedValue;
            gbstatus = drpstatus.SelectedValue;
            //myrow1["Fax"] = txtfaxno.Text;
            //gbfax = txtfaxno.Text;

            //myrow1["EmailID"] = txtemailid.Text;
            //gbmailid = txtemailid.Text;


            mydatatable1.Rows.Add(myrow1);
            dk1 = new DataSet();
            if (Session["pubstatus"] != null)
            {
                DataSet dsNew = new DataSet();
                dsNew = (DataSet)Session["pubstatus"];
                dk1 = dsNew;
            }
            dk1.Tables.Add(mydatatable1);

            Session["pubstatus"] = dk1;

            bindgrid1("cent_status");
        //}
    }

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(pubstatdetails), "ShowAlert", strAlert, true);
    }

}