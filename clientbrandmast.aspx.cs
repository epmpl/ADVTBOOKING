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

public partial class clientbrandmast : System.Web.UI.Page
{

    public int j;
    public string custcode, show, n_m;
    static string gbbrandcode, gbbrandname, gbclientname, gbproductname , gbproductcode, gbexeccode,gbexecname;
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
        objDataSet.ReadXml(Server.MapPath("XML/clientbrandmast.xml"));

        Client.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        brand.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        btnsubmit.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        btnclear.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        btndelete.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        btnclose.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        product.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        executive.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
        //Read button text from XML file
        DataSet objDs = new DataSet();

        Ajax.Utility.RegisterTypeForAjax(typeof(clientbrandmast));
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        custcode = Request.QueryString["custcode"].ToString();
        hiddenclientcode.Value = custcode;
        show = Request.QueryString["show"].ToString();
        n_m = Request.QueryString["n_m"].ToString();
        hiddenchk.Value = n_m;

    //    drpExecutive.Focus();
        drpbrand.Focus();

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

            drpbrand.Enabled = true;
            drpproduct.Enabled = true;
            drpexec.Enabled = true;
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
            drpbrand.Enabled = false;
            drpproduct.Enabled = false;
            drpexec.Enabled = false;
            //  drpproductexec.Enabled = false;
        }
        if (!Page.IsPostBack)
        {
            addproduct();
            addExecutive1();
          //  addBrand1();
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
                databind("Brand_Name");
            }
            else
            {
                DataGrid2.Visible = true;
                Divgrid2.Visible = true;
                Divgrid1.Visible = false;
                DataGrid1.Visible = false;
                databind1("Brand_Name");
            }
            dclient.Text = Request.QueryString["clientname"].ToString();

            btnsubmit.Attributes.Add("OnClick", "javascript:return xyz();");
            btnclear.Attributes.Add("OnClick", "javascript:return clearclick17();");

            btndelete.Attributes.Add("OnClick", "javascript:return deleteclientprod();");

            btnclose.Attributes.Add("OnClick", "javascript:return closewindow();");
            drpproduct.Attributes.Add("OnChange", "javascript:return BrandBind();");

            


        }

        //if (n_m != "1")
        //{
        //    drpproduct.Enabled = false;
        //}


        dclient.Enabled = false;

    }


    public void addproduct()
    {

        drpproduct.Items.Clear();//
        DataSet ds = new DataSet();
       // string clientcode11 = 
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientbrandmast client1 = new NewAdbooking.Classes.clientbrandmast();
            ds = client1.adproduct(Session["compcode"].ToString(), Session["userid"].ToString(), custcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientbrandmast client1 = new NewAdbooking.classesoracle.clientbrandmast();
            ds = client1.adproduct(Session["compcode"].ToString(), Session["userid"].ToString(), custcode);
        }
        //else
        //{
        //    NewAdbooking.classmysql.ClientProdMastr client1 = new NewAdbooking.classmysql.ClientProdMastr();
        //    ds = client1.adproduct(Session["compcode"].ToString(), Session["userid"].ToString());
        //}

        if (ds.Tables[0].Rows.Count == 0)
        {
             Response.Write("<script>alert('Please Select Product First ');window.close();</script>");
             return;
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select  Product-";
        li1.Value = "0";
        li1.Selected = true;
        drpproduct.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpproduct.Items.Add(li);
        }
    }


    public void addExecutive1()
    {

        drpexec.Items.Clear();//
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientbrandmast client1 = new NewAdbooking.Classes.clientbrandmast();
            ds = client1.adexecutive(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientbrandmast client1 = new NewAdbooking.classesoracle.clientbrandmast();
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
        drpexec.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpexec.Items.Add(li);
        }
    }


    private void databind(string sortfield)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientbrandmast databind = new NewAdbooking.Classes.clientbrandmast();
            da = databind.clientbind(Session["userid"].ToString(), Session["compcode"].ToString(), custcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientbrandmast databind = new NewAdbooking.classesoracle.clientbrandmast();
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
        mycolumn.ColumnName = "Product_Name";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Brand_Name";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Exec_Name";
        mydatatable.Columns.Add(mycolumn);


        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "client_brand_code";
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
        my_row["Brand_Name"] = gbbrandname;

        my_row["product_name"] = gbproductname;
        my_row["Exec_Name"] = gbexecname;

        my_row["client_brand_code"] = gbbrandcode;

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

        if (Session["client_brand"] == null)
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
            dsnew = (DataSet)Session["client_brand"];
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
        gbbrandcode = "";
        gbbrandname = "";
        //  gbbrandname = "";
        //   gbexeccode = "";

        //gbstatus = "";
        //gbstatusname = "";
        //txtfrom.Text = "";
        //txtto.Text = "";
        //dclient.Text = "";
        //  dproduct.SelectedValue = "0";
        //  drpproductexec.SelectedValue = "0";
        drpbrand.SelectedValue = "0";


    }


    // Put user code to initialize the page here
    [Ajax.AjaxMethod]

    public void saveclient(string client_code, string client_name, string exec_code, string compcode, string userid, string product_code , string brand_code)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientbrandmast insert = new NewAdbooking.Classes.clientbrandmast();
            da = insert.insertclientcode(client_code, client_name, exec_code, compcode, userid, product_code, brand_code);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientbrandmast insert = new NewAdbooking.classesoracle.clientbrandmast();
            da = insert.insertclientcode(client_code, client_name, exec_code, compcode, userid,product_code ,brand_code);
        }
        //else
        //{
        //    NewAdbooking.classmysql.ClientProdMastr insert = new NewAdbooking.classmysql.ClientProdMastr();
        //    da = insert.insertclientcode(client_code, client_name, exec_code, compcode, userid);

        //}

    }



    [Ajax.AjaxMethod]
    public void deleteclient(string client_code, string client_name, string brand_name, string compcode, string userid, string client_brand_code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientbrandmast del = new NewAdbooking.Classes.clientbrandmast();
            ds = del.deleteclientprod(client_code, client_name, brand_name, compcode, userid, client_brand_code);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientbrandmast del = new NewAdbooking.classesoracle.clientbrandmast();
            ds = del.deleteclientprod(client_code, client_name, brand_name, compcode, userid, client_brand_code);
        }
        else
        {
            NewAdbooking.classmysql.ClientProdMastr del = new NewAdbooking.classmysql.ClientProdMastr();
            ds = del.deleteclientprod(client_code, client_name, brand_name, compcode, userid, client_brand_code);

        }

    }








    [Ajax.AjaxMethod]

    public DataSet bandcontact12(string client_code, string compcode, string userid, string client_prod_code)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientbrandmast databind = new NewAdbooking.Classes.clientbrandmast();
            da = databind.contactbind12(client_code, userid, compcode, client_prod_code);
            return da;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientbrandmast databind = new NewAdbooking.classesoracle.clientbrandmast();
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

    public DataSet chk(string client_code, string exec_code, string compcode, string userid, string prod_code, string brand_code)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientbrandmast datachk = new NewAdbooking.Classes.clientbrandmast();
            da = datachk.chk(client_code, exec_code, compcode, userid, prod_code, brand_code);
            return da;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientbrandmast datachk = new NewAdbooking.classesoracle.clientbrandmast();
            da = datachk.chk(client_code, exec_code, compcode, userid, prod_code, brand_code);
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
    public void updateclient(string client_code, string client_name, string brand_code, string compcode, string userid, string client_prod_code,string product_code,string exec_code)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientbrandmast insert = new NewAdbooking.Classes.clientbrandmast();
            da = insert.updateclientcode(client_code, client_name, brand_code, compcode, userid, client_prod_code, product_code, exec_code);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientbrandmast insert = new NewAdbooking.classesoracle.clientbrandmast();
            da = insert.updateclientcode(client_code, client_name, brand_code, compcode, userid, client_prod_code, product_code, exec_code);
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

                e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return selected('" + str + "');\" value=" + e.Item.Cells[7].Text + "  />";
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
        ScriptManager.RegisterClientScriptBlock(this, typeof(clientbrandmast), "ShowAlert", strAlert, true);
    }
    //protected void btnsubmit_Click(object sender, EventArgs e)
    //{


    //}
    //protected void btnsubmit_Click1(object sender, EventArgs e)
    //{

    //    DataColumn mycolumn1;
    //    DataTable mydatatable1 = new DataTable();
    //    DataRow my_row1;
    //    flag = 0;

    //    string message;
    //    if ((dk1.Tables.Count != 0))
    //    {
    //        int j;
    //        for (j = 0; j < dk1.Tables.Count; j++)
    //        {

    //            if (drpbrand.SelectedValue == dk1.Tables[j].Rows[0].ItemArray[2].ToString())
    //            {
    //                message = "Executive has been submitted already";
    //                AspNetMessageBox(message);
    //                flag = 1;

    //            }
    //            else
    //            {
    //                flag = 0;
    //            }

    //        }

    //    }
    //    if (flag == 0)
    //    {
    //        mycolumn1 = new DataColumn();
    //        mycolumn1.DataType = System.Type.GetType("System.String");
    //        mycolumn1.ColumnName = "client_name";
    //        mydatatable1.Columns.Add(mycolumn1);

    //        // //DataColumn mycolumn;
    //        mycolumn1 = new DataColumn();
    //        mycolumn1.DataType = System.Type.GetType("System.String");
    //        mycolumn1.ColumnName = "Exec_Name";
    //        mydatatable1.Columns.Add(mycolumn1);


    //        ////DataColumn mycolumn;
    //        mycolumn1 = new DataColumn();
    //        mycolumn1.DataType = System.Type.GetType("System.String");
    //        mycolumn1.ColumnName = "client_exec_code";
    //        mydatatable1.Columns.Add(mycolumn1);



    //        ////DataColumn mycolumn;
    //        mycolumn1 = new DataColumn();
    //        mycolumn1.DataType = System.Type.GetType("System.String");
    //        mycolumn1.ColumnName = "STAT_CODE";
    //        mydatatable1.Columns.Add(mycolumn1);

    //        my_row1 = mydatatable1.NewRow();
    //        my_row1["client_name"] = dclient.Text;
    //        gbclientname = dclient.Text;
    //        my_row1["Exec_Name"] = drpbrand.SelectedItem.Text;
    //        gbbrandname = drpbrand.SelectedItem.Text;
    //        my_row1["client_exec_code"] = drpbrand.SelectedValue;
    //        gbbrandcode = drpbrand.SelectedValue;

    //        // my_row1["exec_code"] = dproduct.SelectedValue;
    //        //  gbbrandcode = drpproductexec.SelectedValue;
    //        //my_row["TO_DATE"] = gbto;

    //        // my_row1["exec_name"] = drpproductexec.SelectedItem.Text;
    //        //  gbbrandname = drpproductexec.SelectedItem.Text;

    //        //  my_row1["exec_code"] = drpproductexec.SelectedValue;
    //        //  gbbrandcode = drpproductexec.SelectedValue;


    //        my_row1["STAT_CODE"] = "00";


    //        mydatatable1.Rows.Add(my_row1);
    //        if (Session["client_exec"] != null)
    //        {
    //            DataSet dsnew = new DataSet();
    //            dsnew = (DataSet)Session["client_exec"];
    //            dk1 = dsnew;
    //        }
    //        dk1.Tables.Add(mydatatable1);

    //        Session["client_exec"] = dk1;

    //        databind1("Exec_Name");
    //    }


    //}

    //protected void drpproduct_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    drpbrand.Items.Clear();//

    //    string productcode11 = drpproduct.SelectedValue;
    //    DataSet ds = new DataSet();
    //    //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    //{
    //    //    NewAdbooking.Classes.ClientProdMastr client1 = new NewAdbooking.Classes.ClientProdMastr();
    //    //    ds = client1.adproduct(Session["compcode"].ToString(), Session["userid"].ToString());
    //    //}
    //    // else 
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.clientbrandmast client1 = new NewAdbooking.classesoracle.clientbrandmast();
    //        ds = client1.adbrand1(Session["compcode"].ToString(), Session["userid"].ToString(), productcode11);
    //    }
    //    //else
    //    //{
    //    //    NewAdbooking.classmysql.ClientProdMastr client1 = new NewAdbooking.classmysql.ClientProdMastr();
    //    //    ds = client1.adproduct(Session["compcode"].ToString(), Session["userid"].ToString());
    //    //}
    //    ListItem li1;
    //    li1 = new ListItem();
    //    li1.Text = "-Select Brand-";
    //    li1.Value = "0";
    //    li1.Selected = true;
    //    drpbrand.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        drpbrand.Items.Add(li);
    //    }

    //}

    

         [Ajax.AjaxMethod]
    public DataSet getbrand( string compcode,string prod_code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.clientbrandmast insert = new NewAdbooking.Classes.clientbrandmast();
            ds = insert.adbrand1(compcode, prod_code);
            return ds;

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.clientbrandmast client1 = new NewAdbooking.classesoracle.clientbrandmast();
            ds = client1.adbrand1(compcode, prod_code);
            return ds;
        }
        else
        {
            //NewAdbooking.classmysql.ClientProdMastr insert = new NewAdbooking.classmysql.ClientProdMastr();
            //ds = insert.updateclientcode(client_code, client_name, product_code, compcode, userid, client_prod_code);

            return ds;
        }

    }
}

