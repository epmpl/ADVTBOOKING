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
using System.Drawing;

public partial class LogView : System.Web.UI.Page
{
    //DataSet ds_tbl = new DataSet();
   // DataRow my_row;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
        }

        else
        {

            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;

        }

        Ajax.Utility.RegisterTypeForAjax(typeof(LogView));

//********************************For Label****************************************/
        DataSet objDataSetbu = new DataSet();
        objDataSetbu.ReadXml(Server.MapPath("XML/logview.xml"));
        lbtblname.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
        lbtrx.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        lbuser.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
        lbdate.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[3].ToString();
        //lbtblname1.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        //lbtrx1.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
       // lbuser1.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString();
        //lbtrxval.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();
        //lbseq.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();


        if (!Page.IsPostBack)
        {
            bindtable();
            binduser();
            
            btnSubmit.Attributes.Add("OnClick", "javascript:return logsubmitclick();");
            txtdate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
        }
    }

//====================Bind Table========================
public void bindtable()
{
    DataSet ds=new DataSet();
    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //NewAdbooking.Classes.logview tab = new NewAdbooking.Classes.logview();
           // ds = tab.tabdata(hiddencompcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.logview tab = new NewAdbooking.classesoracle.logview();
            ds = tab.tabdata(hiddencompcode.Value);
        }
        else
        {
            //NewAdbooking.classmysql.logview tab = new NewAdbooking.classmysql.logview();
            //ds = tab.tabdata(hiddencompcode.Value);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "---Select Table---";
        li1.Value = "0";
        li1.Selected = true;
        drptabname.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drptabname.Items.Add(li);
        }
    }
    //====================Bind Table========================
    public void binduser()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //NewAdbooking.Classes.logview userdetail = new NewAdbooking.Classes.logview();
            // ds = userdetail.user(hiddencompcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.logview userdetail = new NewAdbooking.classesoracle.logview();
            ds = userdetail.user(hiddencompcode.Value);
        }
        else
        {
            //NewAdbooking.classmysql.logview userdetail = new NewAdbooking.classmysql.logview();
            //ds = userdetail.user(hiddencompcode.Value);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--- Select User ---";
        li1.Value = "0";
        li1.Selected = true;
        drpuser.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpuser.Items.Add(li);
        }
    }
    protected void GridView1_Init(object sender, EventArgs e)
    {



    }
//[Ajax.AjaxMethod]
//public void logexecute(string compcode,string tabname,string trxtype,string username,string date2)
//{
//    DataSet ds = new DataSet();
//    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
//    {
//        //NewAdbooking.Classes.logview logdata = new NewAdbooking.Classes.logview();
//        //ds = logdata.addvalue(compcode,tabname,trxtype,username,date2);
//    }
//    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
//    {
//        NewAdbooking.classesoracle.logview logdata = new NewAdbooking.classesoracle.logview();
//        //ds = logdata.addvalue(compcode, tabname, trxtype, username, date2);
//    }
//    else
//    {
//        //NewAdbooking.classmysql.logview logdata = new NewAdbooking.classmysql.logview();
//        //ds = logdata.addvalue(compcode,tabname,trxtype,username,date2);
//    }
//   // return ds;
//    DataGrid2.DataSource = ds.Tables[0];
//    DataGrid2.DataBind();
//}
protected void btnSubmit_Click(object sender, EventArgs e)
{
    DataSet ds_tbl = fetchdata();
    DataGrid2.CurrentPageIndex = 0;
DataGrid2.DataSource = ds_tbl.Tables[0];
DataGrid2.DataBind();
    }
    
    protected void DataGrid2_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        DataGrid2.CurrentPageIndex = e.NewPageIndex;
        DataSet ds_tbl = fetchdata();

        DataGrid2.DataSource = ds_tbl.Tables[0];
        DataGrid2.DataBind();
        
    }
    protected void DataGrid2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        string abc= e.Item.Cells[0].Text;
        if (e.Item.Cells[1].Text != e.Item.Cells[2].Text && e.Item.Cells[1].Text != "OLD" && e.Item.Cells[2].Text != "NEW" && e.Item.Cells[1].Text != "&nbsp;" && e.Item.Cells[2].Text != "&nbsp;")
        {
            e.Item.Cells[0].ForeColor = Color.FromName("Red");
            e.Item.Cells[1].ForeColor = Color.FromName("Red");
            e.Item.Cells[2].ForeColor = Color.FromName("Red"); 

        }
    }
    private DataSet fetchdata()
    {
        string tabname = drptabname.Text;
        string trxtype = drptrxtype.Text;
        string username = drpuser.Text;
        string date1 = txtdate.Text;

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //NewAdbooking.Classes.logview logdata = new NewAdbooking.Classes.logview();
            //ds = logdata.addvalue(compcode,tabname,trxtype,username,date1);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.logview logdata = new NewAdbooking.classesoracle.logview();
            ds = logdata.addvalue(Session["compcode"].ToString(), tabname, trxtype, username, date1, Session["dateformat"].ToString());
        }
        else
        {
            //NewAdbooking.classmysql.logview logdata = new NewAdbooking.classmysql.logview();
            //ds = logdata.addvalue(compcode,tabname,trxtype,username,date1);
        }
        // return ds;
        int length;
        length = ds.Tables[1].Rows.Count;
        DataSet ds_tbl = new DataSet();
        /////////////////////////////////////
        DataColumn mycolumn;
        DataRow my_row;
        DataTable mydatatable = new DataTable();

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "FIELD";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "OLD";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn1;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "NEW";
        mydatatable.Columns.Add(mycolumn);
        DataGrid2.PageSize = length;
        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
        {
            for (int i = 0; i < length; i++)
            {
                my_row = mydatatable.NewRow();
                my_row["FIELD"] = ds.Tables[1].Rows[i].ItemArray[0].ToString();
                if (ds.Tables[0].Rows[j]["TRX_TYPE"].ToString() == "INS")
                {

                    my_row["NEW"] = ds.Tables[0].Rows[j].ItemArray[i].ToString();
                }
                else if (ds.Tables[0].Rows[j]["TRX_TYPE"].ToString() == "DEL")
                {

                    my_row["OLD"] = ds.Tables[0].Rows[j].ItemArray[i].ToString();
                }
                else if (ds.Tables[0].Rows[j]["TRX_TYPE"].ToString() == "UPD")
                {
                    if (ds.Tables[0].Rows[j]["TRX_VALUE"].ToString() == "NEW")
                        my_row["NEW"] = ds.Tables[0].Rows[j].ItemArray[i].ToString();
                    else
                    {
                        my_row["OLD"] = ds.Tables[0].Rows[j].ItemArray[i].ToString();
                    }
                    if (ds.Tables[0].Rows[j + 1]["TRX_VALUE"].ToString() == "NEW")
                        my_row["NEW"] = ds.Tables[0].Rows[j + 1].ItemArray[i].ToString();
                    else
                    {
                        my_row["OLD"] = ds.Tables[0].Rows[j + 1].ItemArray[i].ToString();
                    }
                }
                mydatatable.Rows.Add(my_row);

            }
            if (ds.Tables[0].Rows[j]["TRX_TYPE"].ToString() == "UPD")
                j = j + 1;
        }
        //for (int i = 0; i < length; i++)
        //         mydatatable.Rows[i].ItemArray[0] = ds.Tables[1].Rows[i].ItemArray[0].ToString();

        ds_tbl.Tables.Add(mydatatable);
        return ds_tbl;
    }
    //protected void DataGrid2_SortCommand(object source, DataGridSortCommandEventArgs e)
    //{
    //    DataSet ds_tbl = fetchdata();
    //    if (ViewState["SortOrder"] == null)
    //    {
    //        ViewState["SortOrder"] = " ASC";
    //    }
    //    else if (ViewState["SortOrder"].ToString() == " ASC")
    //    {
    //        ViewState["SortOrder"] = " DESC";
    //    }

    //    else if (ViewState["SortOrder"].ToString() == " DESC")
    //    {
    //        ViewState["SortOrder"] = " ASC";
    //    }
    //    else
    //    {
    //        ViewState["SortOrder"] = " ASC";
    //    }

    //    DataView dvSortedView = new DataView(ds_tbl.Tables[0]);
    //    dvSortedView.Sort = e.SortExpression + ViewState["SortOrder"].ToString();
    //    DataGrid2.DataSource = dvSortedView;
    //    DataGrid2.DataBind();
    //}
}
