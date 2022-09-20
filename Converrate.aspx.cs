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

public partial class Converrate : System.Web.UI.Page
{
    public static int numberDiv;
    public static int flag = 0;
  
    string currcode,message;
    int j = 0;
    string show;
     DataSet dk1 = new DataSet();
    DataSet dk = new DataSet();
    public static string date1 = "";
    DataRow my_row;
 

    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here

        Response.Expires = -1;
        if (Session["compcode"] != null)
        {

            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            currcode = Request.QueryString["currcode1"].ToString();
            hiddencurrcode.Value = Request.QueryString["currcode1"].ToString();
            show = Request.QueryString["show"].ToString();
            hiddenshow.Value = Request.QueryString["show"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Converrate));

    


        DataSet ds = new DataSet();
        // Read in the XML file
        ds.ReadXml(Server.MapPath("XML/Converrate.xml"));

        ConversionRate.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        EffectiveFrom.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        EffectiveTill.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        btnsubmit.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        btnclose.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        btndelete.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        btnclear.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lblcurrency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblunit.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();

        if (!Page.IsPostBack)
        {
            if (show == "1")
            {
                btnsubmit.Enabled = true;
                txtefftill.Enabled = true;
                txteffrate.Enabled = true;
                txtconrate.Enabled = true;
                drpcurrency.Enabled = true;
                txtunit.Enabled = true;
              
            }
            else
            {
                btnsubmit.Enabled = false;
                txtconrate.Enabled = false;
                txteffrate.Enabled = false;
                txtefftill.Enabled = false;
                drpcurrency.Enabled = false;
                txtunit.Enabled = false;
            }
            if (dk.Tables.Count > 0 && (Session["currencysave"] == null))
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();

                dk.Clear();
                dk.Dispose();
                dk = new DataSet();
            }

            //if (Session["insertcomm"] != null )
            //{
            //    bindgrid1("Conv_Rate");
            //}
            //else
            //{
            //    bindgrid("Conv_Rate");
            //}

            if (Session["currencysave"] == null )
            {
                DataGrid2.Visible = true;
                divdatagrid2.Visible = true;
            
                divdatagrid1.Visible = false;
                DataGrid1.Visible = false;
         
                bindgrid("Conv_Rate");
            }
            else
            {
                DataGrid2.Visible = false;
                divdatagrid2.Visible = false;
                divdatagrid1.Visible = true;
                DataGrid1.Visible = true;
                bindgrid1("Conv_Rate");
            }
            //if (Session["currencysave"] != null)
            //{
            //    bindgrid1("Conv_Rate");
            //}
            bindcurrency();
            txtconrate.Focus();
            btnsubmit.Attributes.Add("OnClick", "javascript:return submitclick();");
            txteffrate.Attributes.Add("OnChange", "javascript:return RetCheckdate_currfrm(txteffrate);");
            txtefftill.Attributes.Add("OnChange", "javascript:return RetCheckdate_currtill(txtefftill);");
            btndelete.Attributes.Add("OnClick", "javascript:return deletegridclick();");
            btnclear.Attributes.Add("OnClick", "javascript:return clearclick();");
            txtconrate.Attributes.Add("OnChange", "javascript:return allamountbullet(txtconrate);");
            //btnclear.Attributes.Add("OnClick","javascript:return clearclick();");
        }
    }
    public void bindcurrency()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract curr = new NewAdbooking.Classes.Contract();
            ds = curr.currencybind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract curr = new NewAdbooking.classesoracle.Contract();
            ds = curr.currencybind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindcurrency_bindcurrency_p";
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            // return ds;
        }
        //else
        //{
        //    NewAdbooking.classmysql.Contract curr = new NewAdbooking.classmysql.Contract();
        //    ds = curr.currencybind(Session["compcode"].ToString(), Session["userid"].ToString());
        //}

        drpcurrency.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Currency";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcurrency.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (currcode != ds.Tables[0].Rows[i].ItemArray[1].ToString())
                {
                    ListItem li;
                    li = new ListItem();
                    li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    drpcurrency.Items.Add(li);
                }
            }

        }

    }

   
    public void bindgrid(string sortfield)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.currencymaster bind = new NewAdbooking.Classes.currencymaster();
       
        ds = bind.ratebind(currcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.currencymaster bind = new NewAdbooking.classesoracle.currencymaster();

                ds = bind.ratebind(currcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "BINDCURRMAST_BINDCURRMAST_P";
                string[] parameterValueArray = new string[] { currcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString() };       
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                // return ds;
            }
        //else
        //{
        //    NewAdbooking.classmysql.currencymaster bind = new NewAdbooking.classmysql.currencymaster();

        //    ds = bind.ratebind(currcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());

        //}

        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        dv = ds.Tables[0].DefaultView;
        dv.Sort = sortfield;
        DataGrid2.DataSource = dv;
        DataGrid2.DataBind();
    }


    public void bindgrid1(string sortfield)
    {
        DataGrid2.Visible = false;
        DataGrid1.Visible = true;
        divdatagrid1.Visible = true;
        DataSet ds_tbl = new DataSet();
        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Convert_code";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Conv_Rate";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "CONV_CURRENCY";
        mydatatable.Columns.Add(mycolumn);

       
        // DataRow myrow;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Valid_From_Date";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Valid_Till_Date";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "UNIT";
        mydatatable.Columns.Add(mycolumn);

        if (Session["currencysave"] == null)
        {
            ds_tbl.Tables.Add(mydatatable);
            DataGrid1.DataSource = ds_tbl.Tables[0];
            DataGrid1.DataBind();
        }
        else
        {
            dk1.Clear();
            DataSet dsnew = new DataSet();
            dsnew = (DataSet)Session["currencysave"];
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

            ds_tbl.Tables.Add(mydatatable);
            ViewState["SortExpression"] = sortfield;
            ViewState["order"] = "ASC";
            DataView dv = new DataView();
            dv = ds_tbl.Tables[0].DefaultView;
           // dv.Sort = sortfield;


            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
            d = 0;

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
        
        

    }
    #endregion


    [Ajax.AjaxMethod]

    public void insert(string compcode, string userid, string txtconrate, string txtfromdate, string txtefftill, string currcode, string currency, string unit)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, userid, txtconrate, txtfromdate, txtefftill, currcode, currency, unit };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.currencymaster insertgrid = new NewAdbooking.Classes.currencymaster();

            ds = insertgrid.insertconverrate(txtconrate, txtfromdate, txtefftill, compcode, userid, currcode, currency, unit);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
            NewAdbooking.classesoracle .currencymaster insertgrid = new NewAdbooking.classesoracle.currencymaster();

            ds = insertgrid.insertconverrate(txtconrate, txtfromdate, txtefftill, compcode, userid, currcode, currency, unit);

            }
       
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "insertconvertrate_insertconvertrate_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
               // return ds;
            }         
    }

    private void hiddencurrcode_ServerChange(object sender, System.EventArgs e)
    {

    }

    [Ajax.AjaxMethod]

    public DataSet selected(string currcode, string compcode, string userid, string code10)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, userid, currcode, code10 };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.currencymaster selectgrid = new NewAdbooking.Classes.currencymaster();       
            ds = selectgrid.selectedfromgrid(currcode, compcode, userid, code10);
           
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.currencymaster selectgrid = new NewAdbooking.classesoracle.currencymaster();
                ds = selectgrid.selectedfromgrid(currcode, compcode, userid, code10); 
              
            }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "SELECTFROMCURRMAST_SELECTFROMCURRMAST_P";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
             
            }
        return ds;
    }

    [Ajax.AjaxMethod]
    public void update(string txtconrate, string txtfromdate, string txtefftill, string compcode, string userid, string currcode, string code10, string currency,string unit)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.currencymaster updategrid = new NewAdbooking.Classes.currencymaster();
            ds = updategrid.gridupdate(txtconrate, txtfromdate, txtefftill, compcode, userid, currcode, code10, currency, unit);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
              NewAdbooking.classesoracle .currencymaster updategrid = new NewAdbooking.classesoracle.currencymaster();
              ds = updategrid.gridupdate(txtconrate, txtfromdate, txtefftill, compcode, userid, currcode, code10, currency, unit);

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "updateconvertrate_updateconvertrate_p";
                string[] parameterValueArray = new string[] { compcode, userid, txtconrate, txtfromdate, txtefftill, currcode, code10, currency, unit };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                // return ds;
            }
    }

    [Ajax.AjaxMethod]

    public void deletegrid(string currcode, string compcode, string userid, string code10)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.currencymaster delete = new NewAdbooking.Classes.currencymaster();
           
            ds = delete.griddelete(currcode, compcode, userid, code10);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.currencymaster delete = new NewAdbooking.classesoracle.currencymaster();

                ds = delete.griddelete(currcode, compcode, userid, code10);

            }
        else
        {

            NewAdbooking.classmysql.currencymaster delete = new NewAdbooking.classmysql.currencymaster();

            ds = delete.griddelete(currcode, compcode, userid, code10);
        }


    }

    [Ajax.AjaxMethod]
   // string txtconrate, string txtfromdate, string txtefftill, string compcode, string userid, string currcode, string conv_currency)
   
    public DataSet chkinsert(string compcode, string userid, string txtconrate, string txtfromdate, string txtefftill, string currcode, string conv_currency)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, userid, txtconrate, txtfromdate, txtefftill, currcode, conv_currency };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.currencymaster chkdate = new NewAdbooking.Classes.currencymaster();
            ds = chkdate.chkdaetconv(txtconrate, txtfromdate, txtefftill, compcode, userid, currcode, conv_currency);
            //return ds;
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.currencymaster chkdate = new NewAdbooking.classesoracle.currencymaster();
                ds = chkdate.chkdaetconv(txtconrate, txtfromdate, txtefftill, compcode, userid, currcode, conv_currency);
                //return ds;
            }
            else
            {
                string procedureName = "CHKDATECONRATE_CHKDATECONRATE_P";               
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);              
            }
        return ds;

    }

    [Ajax.AjaxMethod]   
         // string txtconrate, string txtfromdate, string txtefftill, string compcode, string userid, string currcode, string code10,string currency)
    public DataSet chkupdate(string compcode, string userid, string txtconrate, string txtfromdate, string txtefftill, string currcode, string code10, string currency)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, userid, txtconrate, txtfromdate, txtefftill, currcode, code10, currency }; 
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.currencymaster chkdateup = new NewAdbooking.Classes.currencymaster();            
            ds = chkdateup.chkdateupdate(txtconrate, txtfromdate, txtefftill, compcode, userid, currcode, code10,currency);
            //return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")           
            {
                NewAdbooking.classesoracle.currencymaster chkdateup = new NewAdbooking.classesoracle.currencymaster();
                ds = chkdateup.chkdateupdate(txtconrate, txtfromdate, txtefftill, compcode, userid, currcode, code10, currency);
               // return ds;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "chkdateupdate_chkdateupdate_p";                
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                // return ds;
            }
        //else
        //{
        //    NewAdbooking.classmysql.currencymaster chkdateup = new NewAdbooking.classmysql.currencymaster();
        //    ds = chkdateup.chkdateupdate(txtconrate, txtfromdate, txtefftill, compcode, userid, currcode, code10);
        //    return ds;
        //}

        return ds;

    }

    protected void hiddendateformat_ServerChange(object sender, System.EventArgs e)
    {

    }

   //private void DataGrid1_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
   // {
   //     DataView dv = new DataView();

   //     dv = (DataView)DataGrid1.DataSource;
   //     DataColumnCollection dc = dv.Table.Columns;

   //     if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
   //     {


   //         string str = "DataGrid1__ctl_CheckBox1" + j;

   //         e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  OnClick=\"javascript:return selectclick('" + str + "');\" value=" + e.Item.Cells[1].Text + "  />";
   //         j++;
   //         //e.Item.Cells[0].Text="<input type='checkbox' id="+e.Item.Cells[8].Text+"   value="+e.Item.Cells[8].Text+"  />";

   //     }
   //     if (e.Item.ItemType == ListItemType.Header)
   //     {
   //         if (ViewState["SortExpression"].ToString() != "")
   //         {
   //             string str = "";
   //             switch (ViewState["SortExpression"].ToString())
   //             {

                    
   //                 case "Conv_Rate":
   //                     str = "Conversion Rate";
   //                     break;

   //                 case "Valid_From_Date":
   //                     str = "Effective From";
   //                     break;

   //                 case "Valid_Till_Date":
   //                     str = "Effective Till";
   //                     break;

   //             };
   //             string strd = Convert.ToString(dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
   //             strd = Convert.ToString(Convert.ToInt32(strd) - 1);
   //             if (strd.Length < 2)
   //                 strd = "0" + strd;
   //             if (ViewState["order"].ToString() == "DESC")
   //             {
   //                 //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
   //                 //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
   //                 //$ctl01$ctl00

   //                 e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

   //             }
   //             else
   //             {
   //                 //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+str+"<img  src=\"images\\moveprevious2.gif\" border=0></a>";
   //                 e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";
   //             }
   //         }
   //     }
   // }


    public void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.currencymaster databind = new NewAdbooking.Classes.currencymaster();
         

            ds = databind.ratebind(currcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
            NewAdbooking.classesoracle .currencymaster databind = new NewAdbooking.classesoracle.currencymaster();       
            ds = databind.ratebind(currcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "BINDCURRMAST_BINDCURRMAST_P";
                string[] parameterValueArray = new string[] { currcode, Session["userid"].ToString(), Session["userid"].ToString(), date1,};
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                // return ds;
            }
        //else
        //{
        //    NewAdbooking.classmysql.currencymaster databind = new NewAdbooking.classmysql.currencymaster();
        //    ds = databind.ratebind(currcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
  
        //}

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

        DataGrid2.DataSource = dv;
        DataGrid2.DataBind();
    }

    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>"); 
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
         DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;
        flag = 0;
        if (txteffrate.Text == "")
            txteffrate.Text = hidfrom.Value;
        if (txtefftill.Text == "")
            txtefftill.Text = hidto.Value;

        string dateformat = Session["dateformat"].ToString();
        string fdate1 = getDate(dateformat, txteffrate.Text);
        string tdate1 = getDate(dateformat, txtefftill.Text);
        string conv_currency = drpcurrency.SelectedValue;
        
        DateTime fromdate = Convert.ToDateTime(fdate1);
        DateTime tilldate = Convert.ToDateTime(tdate1);
        if (Session["currencysave"] == null)
        {
            dk1.Clear();
            dk1.Dispose();
            dk1 = new DataSet();

            dk.Clear();
            dk.Dispose();
            dk = new DataSet();
        }
        else 
        {

            DataSet dsNew = new DataSet();
            dsNew = (DataSet)Session["currencysave"];
            dk = dsNew;
        }

        if (((dk.Tables.Count != 0)) && (flag ==0))
        {
             int j;
            for (j = 0; j < dk.Tables[0].Rows.Count; j++)
            {
                string dk_fdate = getDate(dateformat, dk.Tables[0].Rows[j].ItemArray[3].ToString());
                string dk_tdate = getDate(dateformat, dk.Tables[0].Rows[j].ItemArray[4].ToString());
                string dk_conv_currency=dk.Tables[0].Rows[j].ItemArray[2].ToString();
                DateTime dbdatefrm = Convert.ToDateTime(dk_fdate);
                DateTime dbdatetill = Convert.ToDateTime(dk_tdate);
                if (( (fromdate == dbdatefrm) || (tilldate == dbdatetill )|| ((fromdate  >  dbdatefrm) && (fromdate < dbdatetill))
                || ((tilldate > dbdatefrm) && (tilldate < dbdatetill))) && (dk_conv_currency == conv_currency))
              
                 {
                         message = "Issue Date  has been assigned already";
                         AspNetMessageBox(message);
                         txteffrate.Text = "";
                         txtefftill.Text = "";
                       
                        flag = 1;

                  }
                    
               
                else
                {
                    flag = 0;
                }

            }

        }
        if (flag == 0)
        {

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Convert_code";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Conv_Rate";
            mydatatable1.Columns.Add(mycolumn1);

            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "CONV_CURRENCY";
            mydatatable1.Columns.Add(mycolumn1);

            // //DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Valid_From_Date";
            mydatatable1.Columns.Add(mycolumn1);

            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Valid_Till_Date";
            mydatatable1.Columns.Add(mycolumn1);

            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "UNIT";
            mydatatable1.Columns.Add(mycolumn1);
           

            //------------------new added ------------------//
            //int j = 0;
            //if (DataGrid2.Items.Count > 0)
            //{
            //    while (j < DataGrid2.Items.Count)
            //    {
            //        string fdate = DataGrid2.Items[j].Cells[1].Text;
            //        string dk_fdate = getDate(dateformat, dk.Tables[0].Rows[j].ItemArray[2].ToString());
            //        string dk_tdate = getDate(dateformat, dk.Tables[0].Rows[j].ItemArray[3].ToString());
            //        DateTime dbdatefrm = Convert.ToDateTime(dk_fdate);
            //        DateTime dbdatetill = Convert.ToDateTime(dk_tdate);
            //        if ((fromdate == dbdatefrm) || (tilldate == dbdatetill) || ((fromdate > dbdatefrm) && (fromdate < dbdatetill))
            //        || ((tilldate > dbdatefrm) && (tilldate < dbdatetill)))
            //        {
            //            message = "Issue Date  has been assigned already";
            //            AspNetMessageBox(message);
            //            txteffrate.Text = "";
            //            txtefftill.Text = "";

            //          //  flag = 1;

            //        }
            //        j++;
            //    }

            //}


            myrow1 = mydatatable1.NewRow();

            //


            myrow1["Convert_code"] = "0";

            myrow1["CONV_CURRENCY"] = drpcurrency.SelectedValue;

            myrow1["Conv_Rate"] = txtconrate.Text;
            // gbconvrate = txtconrate.Text;

            myrow1["Valid_From_Date"] = txteffrate.Text;


            myrow1["Valid_Till_Date"] = txtefftill.Text;
            myrow1["UNIT"] = txtunit.Text;

            mydatatable1.Rows.Add(myrow1);
                if (Session["currencysave"] != null)
                {
                    DataSet dsNew = new DataSet();
                    dsNew = (DataSet) Session["currencysave"];
                    dk = dsNew;
                }
            dk.Tables.Add(mydatatable1);

            Session["currencysave"] = dk;

            ///this is for grid
            ///

            DataColumn mycolumn;
            DataTable mydatatable = new DataTable();
            DataRow myrow;

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "Convert_code";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "Conv_Rate";
            mydatatable.Columns.Add(mycolumn);

            ////DataColumn mycolumn1;
            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "CONV_CURRENCY";
            mydatatable.Columns.Add(mycolumn);

            // //DataColumn mycolumn1;
            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "Valid_From_Date";
            mydatatable.Columns.Add(mycolumn);

            ////DataColumn mycolumn1;
            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "Valid_Till_Date";
            mydatatable.Columns.Add(mycolumn);

            ////DataColumn mycolumn1;
            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "UNIT";
            mydatatable.Columns.Add(mycolumn);


            myrow = mydatatable.NewRow();


            myrow["Convert_code"] = "0";

            myrow["Conv_Rate"] = txtconrate.Text;
            // gbconvrate = txtconrate.Text;
            myrow["CONV_CURRENCY"] = drpcurrency.SelectedValue;

            myrow["Valid_From_Date"] = txteffrate.Text;


            myrow["Valid_Till_Date"] = txtefftill.Text;

            myrow["UNIT"] = txtunit.Text;

            txtconrate.Text = "";
            txteffrate.Text = "";
            txtefftill.Text = "";
            drpcurrency.SelectedValue = "0";
            txtunit.Text = "";


            mydatatable.Rows.Add(myrow);

            dk1.Tables.Add(mydatatable);


            bindgrid1("Conv_Rate");
        }
   
    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

    }
    protected void DataGrid2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        DataView dv = new DataView();

        dv = (DataView)DataGrid2.DataSource;
        DataColumnCollection dc = dv.Table.Columns;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


       string str = "DataGrid2__ctl_CheckBox1" + j;
     


            e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  OnClick=\"javascript:return selectclick('" + str + "');\" value=" + e.Item.Cells[5].Text + "  />";
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


                    case "Conv_Rate":
                        str = "Convert Rate";
                        break;

                    case "Valid_From_Date":
                        str = "Valid From";
                        break;

                    case "Valid_Till_Date":
                        str = "Valid To";
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

                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid2$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

                }
                else
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+str+"<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid2$ctl01$ctl" + strd + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                }
            }
        }

    }
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Converrate), "ShowAlert", strAlert, true);
    }

    protected string getDate(string dateformat, string value)
    {
        if (dateformat == "dd/mm/yyyy")
        {
            string[] datearr = value.Split('/');
            string dd = datearr[0];
            string mm = datearr[1];
            string yy = datearr[2];
            value = mm + '/' + dd + '/' + yy;
        }
        return value;
    }
    
}