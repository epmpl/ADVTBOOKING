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

public partial class clientexecutivemast : System.Web.UI.Page
{
    public int j;
    public string custcode, show, n_m;
    static string gbexeccode, gbexecname, gbclientname;
    DataSet dk1 = new DataSet();
    DataRow my_row;
    public static int flag = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            Response.Write("<script>\"Your session has been expired\";window.close();</script>");
            return;

        }
        DataSet objDataSet = new DataSet();
        // Read in the XML file
        objDataSet.ReadXml(Server.MapPath("XML/clientexecmastr.xml"));

        Client.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        Executive.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        btnsubmit.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        btnclear.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        btndelete.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        btnclose.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        //Read button text from XML file
        DataSet objDs = new DataSet();

        Ajax.Utility.RegisterTypeForAjax(typeof(clientexecutivemast));
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        custcode = Request.QueryString["custcode"].ToString();
        hiddenclientcode.Value = custcode;
        show = Request.QueryString["show"].ToString();
        n_m = Request.QueryString["n_m"].ToString();
        hiddenchk.Value = n_m;

        drpExecutive.Focus();

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
            //txtfrom.Enabled = true;
            //  txtdesignation.Enabled = true;
            //txtto.Enabled = true;
            //txtcircular.Enabled = true;
            //if (n_m != "0")
            //{
            //    drpExecutive.Enabled = true;
            //}
            //else
            //{
            //    drpExecutive.Enabled = false;
            //}
            //drpproductexec.Enabled = true;

            drpExecutive.Enabled = true;
        }
        else
        {
            btnsubmit.Enabled = false;
            // btnselect.Enabled = true;
            btndelete.Enabled = false;
            btnclear.Enabled = true;
            //txtfrom.Enabled = false;
            ////  txtdesignation.Enabled = false;
            //txtto.Enabled = false;
            //txtcircular.Enabled = false;
            drpExecutive.Enabled = false;
          //  drpproductexec.Enabled = false;
        }
        if (!Page.IsPostBack)
        {
          //  addproduct();
            addExecutive1();
            //databind();
            if (dk1.Tables.Count > 0 && Session["client_prod"] == null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();
            }
            if (Session["client_exec"] == null)
            {
                DataGrid2.Visible = false;
                Divgrid2.Visible = false;
                Divgrid1.Visible = true;
                DataGrid1.Visible = true;
                databind("Exec_Name");
            }
            else
            {
                DataGrid2.Visible = true;
                Divgrid2.Visible = true;
                Divgrid1.Visible = false;
                DataGrid1.Visible = false;
                databind1("Exec_Name");
            }
            dclient.Text = Request.QueryString["clientname"].ToString();

            btnsubmit.Attributes.Add("OnClick", "javascript:return xyz();");
            btnclear.Attributes.Add("OnClick", "javascript:return clearclick17();");

            btndelete.Attributes.Add("OnClick", "javascript:return deleteclientprod();");

            btnclose.Attributes.Add("OnClick", "javascript:return closewindow();");


        }


        dclient.Enabled = false;
        //dproduct.Enabled = false;

    }


   

    public void addExecutive1()
    {
        drpExecutive.Items.Clear();//
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientProdMastr client1 = new NewAdbooking.Classes.ClientProdMastr();
            ds = client1.adxecutive(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientProdMastr client1 = new NewAdbooking.classesoracle.ClientProdMastr();
            ds = client1.adexecutive(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        //else
        //{
        //    NewAdbooking.classmysql.ClientProdMastr client1 = new NewAdbooking.classmysql.ClientProdMastr();
        //    ds = client1.adproduct(Session["compcode"].ToString(), Session["userid"].ToString());
        //}
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select  Executive-";
        li1.Value = "0";
        li1.Selected = true;
        drpExecutive.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpExecutive.Items.Add(li);
        }
    }


    private void databind(string sortfield)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientexecmastr databind = new NewAdbooking.Classes.clientexecmastr();
            da = databind.clientbind(Session["userid"].ToString(), Session["compcode"].ToString(), custcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientexecmastr databind = new NewAdbooking.classesoracle.clientexecmastr();
            da = databind.clientbind(Session["userid"].ToString(), Session["compcode"].ToString(), custcode);
        }
        //else
        //{
        //    NewAdbooking.classmysql.ClientProdMastr databind = new NewAdbooking.classmysql.ClientProdMastr();
        //    da = databind.clientbind(Session["userid"].ToString(), Session["compcode"].ToString(), custcode);
        //}
        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        dv = da.Tables[0].DefaultView;
        dv.Sort = sortfield;

        DataGrid1.DataSource = dv;
        DataGrid1.DataBind();

    }
    public void databind1(string sortfield)
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
        mycolumn.ColumnName = "client_name";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Exec_Name";
        mydatatable.Columns.Add(mycolumn);

      
        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "client_exec_code";
        mydatatable.Columns.Add(mycolumn);


    

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "STAT_CODE";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        //mycolumn = new DataColumn();
        //mycolumn.DataType = System.Type.GetType("System.String");
        //mycolumn.ColumnName = "circular";
        //mydatatable.Columns.Add(mycolumn);

        //mycolumn = new DataColumn();
        //mycolumn.DataType = System.Type.GetType("System.String");
        //mycolumn.ColumnName = "status_name";
        //mydatatable.Columns.Add(mycolumn);

        my_row = mydatatable.NewRow();
        my_row["client_name"] = gbclientname;
        my_row["Exec_Name"] = gbexecname;

        my_row["client_exec_code"] = gbexeccode;
   
        //my_row["TO_DATE"] = gbto;
        my_row["STAT_CODE"] = "0";
        //my_row["circular"] = gbcircular;
        //my_row["Fax"] = gbfax;
        //my_row["EmailID"] = gbmailid;
        //my_row["Cont_Code"] = "0";
        //gbsecondcycle = txtaddate.Text;

        //  mydatatable.Rows.Add(my_row);

        ds_tbl.Tables.Add(mydatatable);

        // mydatatable.ImportRow(my_row);

        if (Session["client_exec"] == null)
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
            dsnew = (DataSet)Session["client_exec"];
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


        gbclientname = "";
        gbexeccode = "";
        gbexecname = "";
      //  gbexecname = "";
     //   gbexeccode = "";

        //gbstatus = "";
        //gbstatusname = "";
        //txtfrom.Text = "";
        //txtto.Text = "";
        //dclient.Text = "";
      //  dproduct.SelectedValue = "0";
      //  drpproductexec.SelectedValue = "0";
        drpExecutive.SelectedValue = "0";


    }


    // Put user code to initialize the page here
    [Ajax.AjaxMethod]

    public void saveclient(string client_code, string client_name, string exec_code, string compcode, string userid)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientexecmastr insert = new NewAdbooking.Classes.clientexecmastr();
            da = insert.insertclientcode(client_code, client_name, exec_code, compcode, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientexecmastr insert = new NewAdbooking.classesoracle.clientexecmastr();
            da = insert.insertclientcode(client_code, client_name, exec_code, compcode, userid);
        }
        //else
        //{
        //    NewAdbooking.classmysql.ClientProdMastr insert = new NewAdbooking.classmysql.ClientProdMastr();
        //    da = insert.insertclientcode(client_code, client_name, exec_code, compcode, userid);

        //}

    }



    [Ajax.AjaxMethod]
    public void deleteclient(string client_code, string client_name, string exec_code, string compcode, string userid, string client_exec_code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientexecmastr del = new NewAdbooking.Classes.clientexecmastr();
            ds = del.deleteclientprod(client_code, client_name, exec_code, compcode, userid, client_exec_code);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientexecmastr del = new NewAdbooking.classesoracle.clientexecmastr();
            ds = del.deleteclientprod(client_code, client_name, exec_code, compcode, userid, client_exec_code);
        }
        else
        {
            NewAdbooking.classmysql.ClientProdMastr del = new NewAdbooking.classmysql.ClientProdMastr();
            ds = del.deleteclientprod(client_code, client_name, exec_code, compcode, userid, client_exec_code);

        }

    }








    [Ajax.AjaxMethod]

    public DataSet bandcontact12(string client_code, string compcode, string userid, string client_prod_code)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientexecmastr databind = new NewAdbooking.Classes.clientexecmastr();
            da = databind.contactbind12(client_code, userid, compcode, client_prod_code);
            return da;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientexecmastr databind = new NewAdbooking.classesoracle.clientexecmastr();
            da = databind.contactbind12(client_code, userid, compcode, client_prod_code);
            return da;
        }
        else
        {
            NewAdbooking.classmysql.ClientProdMastr databind = new NewAdbooking.classmysql.ClientProdMastr();
            da = databind.contactbind12(client_code, userid, compcode, client_prod_code);
            return da;
        }

    }

    //[Ajax.AjaxMethod]

    //public DataSet chk(string client_code, string product_code, string compcode, string userid, string exec_code)
    //{
    //    DataSet da = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Classes.ClientProdMastr datachk = new NewAdbooking.Classes.ClientProdMastr();
    //        da = datachk.chk(client_code, product_code, compcode, userid);
    //        return da;
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.ClientProdMastr datachk = new NewAdbooking.classesoracle.ClientProdMastr();
    //        da = datachk.chk(client_code, product_code, compcode, userid, exec_code);
    //        return da;
    //    }
    //    else
    //    {
    //        NewAdbooking.classmysql.ClientProdMastr datachk = new NewAdbooking.classmysql.ClientProdMastr();
    //        da = datachk.chk(client_code, product_code, compcode, userid);
    //        return da;
    //    }

    //}


    [Ajax.AjaxMethod]

    public DataSet chk(string client_code, string exec_code, string compcode, string userid)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientexecmastr datachk = new NewAdbooking.Classes.clientexecmastr();
            da = datachk.chk(client_code, exec_code, compcode, userid);
            return da;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientexecmastr datachk = new NewAdbooking.classesoracle.clientexecmastr();
            da = datachk.chk(client_code, exec_code, compcode, userid);
            return da;
        }
        else
        {
            NewAdbooking.classmysql.ClientProdMastr datachk = new NewAdbooking.classmysql.ClientProdMastr();
            da = datachk.chk(client_code, exec_code, compcode, userid);
            return da;
        }

    }


    [Ajax.AjaxMethod]
    public void updateclient(string client_code, string client_name, string exec_code, string compcode, string userid, string client_prod_code)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientexecmastr insert = new NewAdbooking.Classes.clientexecmastr();
            da = insert.updateclientcode(client_code, client_name, exec_code, compcode, userid, client_prod_code);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientexecmastr insert = new NewAdbooking.classesoracle.clientexecmastr();
            da = insert.updateclientcode(client_code, client_name, exec_code, compcode, userid, client_prod_code);
        }
        //else
        //{
        //    NewAdbooking.classmysql.ClientProdMastr insert = new NewAdbooking.classmysql.ClientProdMastr();
        //    da = insert.updateclientcode(client_code, client_name, product_code, compcode, userid, client_prod_code);

        //}

    }

    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        DataView dv = new DataView();

        if (n_m != "1")
        {
            dv = (DataView)DataGrid1.DataSource;
            DataColumnCollection dc = dv.Table.Columns;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                string str = "DataGrid1__ctl_CheckBox1" + j;

                e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return selected('" + str + "');\" value=" + e.Item.Cells[3].Text + "  />";
                j++;

            }

        }
        /************************************************************************************/

        //if (e.Item.ItemType == ListItemType.Header)
        //{
        //    if (ViewState["SortExpression"].ToString() != "")
        //    {
        //        string str = "";
        //        switch (ViewState["SortExpression"].ToString())
        //        {


        //            case "Product_Name":
        //                str = "Product Name";
        //                break;

        //            case "client_name":
        //                str = "Client Name";
        //                break;





        //            //case "TO_DATE":
        //            //    str = "To Date";
        //            //    break;


        //            //case "Circular":
        //            //    str = "Circular No.";
        //            //    break;

        //        };
        //        string strd = Convert.ToString(dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
        //        strd = Convert.ToString(Convert.ToInt32(strd) - 1);
        //        if (strd.Length < 2)
        //            strd = "0" + strd;
        //        if (ViewState["order"].ToString() == "DESC")
        //        {
        //            e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')  \">" + str + "</a>";

        //        }
        //        else
        //        {
        //            e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')   \">" + str + "</a>";
        //        }




        //    }
        //}



    }

  
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(clientexecutivemast), "ShowAlert", strAlert, true);
    }
    //protected void btnsubmit_Click(object sender, EventArgs e)
    //{

        
    //}
    protected void btnsubmit_Click1(object sender, EventArgs e)
    {

        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow my_row1;
        flag = 0;

        string message;
        if ((dk1.Tables.Count != 0))
        {
            int j;
            for (j = 0; j < dk1.Tables.Count; j++)
            {

                if (drpExecutive.SelectedValue == dk1.Tables[j].Rows[0].ItemArray[2].ToString())
                {
                    message = "Executive has been submitted already";
                    AspNetMessageBox(message);
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
            mycolumn1.ColumnName = "client_name";
            mydatatable1.Columns.Add(mycolumn1);

            // //DataColumn mycolumn;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Exec_Name";
            mydatatable1.Columns.Add(mycolumn1);


            ////DataColumn mycolumn;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "client_exec_code";
            mydatatable1.Columns.Add(mycolumn1);



            ////DataColumn mycolumn;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "STAT_CODE";
            mydatatable1.Columns.Add(mycolumn1);

            my_row1 = mydatatable1.NewRow();
            my_row1["client_name"] = dclient.Text;
            gbclientname = dclient.Text;
            my_row1["Exec_Name"] = drpExecutive.SelectedItem.Text;
            gbexecname = drpExecutive.SelectedItem.Text;
            my_row1["client_exec_code"] = drpExecutive.SelectedValue;
            gbexeccode = drpExecutive.SelectedValue;

            // my_row1["exec_code"] = dproduct.SelectedValue;
            //  gbexeccode = drpproductexec.SelectedValue;
            //my_row["TO_DATE"] = gbto;

            // my_row1["exec_name"] = drpproductexec.SelectedItem.Text;
            //  gbexecname = drpproductexec.SelectedItem.Text;

            //  my_row1["exec_code"] = drpproductexec.SelectedValue;
            //  gbexeccode = drpproductexec.SelectedValue;


            my_row1["STAT_CODE"] = "00";


            mydatatable1.Rows.Add(my_row1);
            if (Session["client_exec"] != null)
            {
                DataSet dsnew = new DataSet();
                dsnew = (DataSet)Session["client_exec"];
                dk1 = dsnew;
            }
            dk1.Tables.Add(mydatatable1);

            Session["client_exec"] = dk1;

            databind1("Exec_Name");
        }


    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
}
