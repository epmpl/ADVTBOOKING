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

public partial class executiveaddtionalcomm : System.Web.UI.Page
{

    string userid, compcode, retcode, show, n_m, gbcommrate;
    string gbfrom, gbto, gbenln, gbcommon;


    //string show, n_m, compcode;
    string gblist = "";
    string gbtempexecode = "";
    string gbnopub = "";
    string gbfpubper = "";
    string gbpublist = "";
    string flag = "";
    static DataSet dk1 = new DataSet();
    DataRow my_row;
    public static int numberDiv;
    int j = 0;
    int i = 1;
    protected void Page_Load(object sender, EventArgs e)
    {

        btndelete.Enabled = false;
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(executiveaddtionalcomm));


        show = Request.QueryString["show"].ToString();
        n_m = Request.QueryString["n_m"].ToString();
        hdncommid.Value = n_m;

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




        DataSet abc = new DataSet();
        abc.ReadXml(Server.MapPath("Xml/retaineraddcomm.xml"));
        lbllopub.Text = abc.Tables[0].Rows[0].ItemArray[0].ToString();
        lblmainpub.Text = abc.Tables[0].Rows[0].ItemArray[1].ToString();
        lblpubper.Text = abc.Tables[0].Rows[0].ItemArray[2].ToString();
        btnsubmit.Text = abc.Tables[0].Rows[0].ItemArray[3].ToString();
        btnclear.Text = abc.Tables[0].Rows[0].ItemArray[4].ToString();
        btnclose.Text = abc.Tables[0].Rows[0].ItemArray[5].ToString();
        btndelete.Text = abc.Tables[0].Rows[0].ItemArray[6].ToString();
        //binddata1();
        //  Session["retaineraddtionalcomm_slab"] = dk1;

        if (show == "1")
        {
            txtmainpub.Enabled = true;
            txtpubper.Enabled = true;
            libox.Enabled = true;
            btnsubmit.Enabled = true;
            btndelete.Enabled = false;

        }
        if (show == "0")
        {
            txtmainpub.Enabled = false;
            txtpubper.Enabled = false;
            libox.Enabled = false;
            btnsubmit.Enabled = false;
            btndelete.Enabled = false;


        }

        if (show == "2")
        {
            txtmainpub.Enabled = true;
            txtpubper.Enabled = true;
            libox.Enabled = true;
            btnsubmit.Enabled = true;
            btndelete.Enabled = false;
        }

        if (!Page.IsPostBack)
        {

            if (dk1.Tables.Count > 0 && Session["retaineraddtionalcomm_slab"] == null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();
            }
            if (Session["retaineraddtionalcomm_slab"] == null)
            {
                //DataGrid2.Visible = false;
                //Divgrid2.Visible = false;
                //Divgrid1.Visible = true;
                DataGrid1.Visible = true;
                DataGrid1.DataSource = "";
                DataGrid1.DataBind();
                binddata();

            }
            else
            {
                //DataGrid2.Visible = true;
                // Divgrid2.Visible = true;
                //Divgrid1.Visible = false;
                DataGrid1.Visible = false;
                binddata1();
            }

            btnclose.Attributes.Add("OnClick", "javascript:return poupclose();");
            btnclear.Attributes.Add("OnClick", "javascript:return subpopaddclear();");

            btnsubmit.Attributes.Add("OnClick", "javascript:return RetaddcomslabSubmit();");
            btndelete.Attributes.Add("OnClick", "javascript:return RetaddSlabDelete();");
            bindpublication();
        }
    }


    public void bindpublication()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.advpub(Session["compcode"].ToString());
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select Publication";
        li.Selected = true;
        libox.Items.Add(li);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            libox.Items.Add(li1);
        }

    }
    public void binddata()
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdvertisementMaster databind = new NewAdbooking.Classes.AdvertisementMaster();
            da = databind.retaineraddbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), n_m);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster databind = new NewAdbooking.classesoracle.AdvertisementMaster();
            da = databind.retaineraddbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), n_m);

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
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
        }

    }



    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Session["hdnflag"] == "T")
        {
            Session["hdnflag"] = null;
            if (libox.SelectedItem.Value.ToString() == "0" || txtmainpub.Text.Trim().ToString() == "" || txtpubper.Text.Trim().ToString() == "")
            {
                Response.Write("<script>alert('Please fill the data in data control');</script>");
                return;

            }
            else
            {

                DataColumn mycolumn1;
                DataTable mydatatable1 = new DataTable();
                DataRow myrow1;

                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "PUBL_CODE";
                mydatatable1.Columns.Add(mycolumn1);

                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "NO_OF_PUBL";
                mydatatable1.Columns.Add(mycolumn1);

                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "ADDCOMM_PER";
                mydatatable1.Columns.Add(mycolumn1);

                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "COMM_TARGET_ID";
                mydatatable1.Columns.Add(mycolumn1);


                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "TEMPEXECODE";
                mydatatable1.Columns.Add(mycolumn1);

                string publist = "";
                for (int x = 0; x < libox.Items.Count; x++)
                {
                    if (libox.Items[x].Selected == true)
                    {
                        if (publist == "")
                            publist = libox.Items[x].Value;
                        else
                            publist = publist + "," + libox.Items[x].Value;
                    }
                }

                myrow1 = mydatatable1.NewRow();

                myrow1["PUBL_CODE"] = publist;
                gblist = publist;

                myrow1["NO_OF_PUBL"] = txtmainpub.Text;
                gbnopub = txtmainpub.Text;

                myrow1["ADDCOMM_PER"] = txtpubper.Text;
                gbfpubper = txtpubper.Text;

                myrow1["COMM_TARGET_ID"] = n_m;

                myrow1["TEMPEXECODE"] = hiddenretcode.Value;
                gbtempexecode = hiddenretcode.Value;


                //string publist = "";
                //for (int x = 0; x < libox.Items.Count; x++)
                //{
                //    if (libox.Items[x].Selected == true)
                //    {
                //        if (publist == "")
                //            publist = libox.Items[x].Value;
                //        else
                //            publist = publist + "," + libox.Items[x].Value;
                //    }
                //}

                //myrow1["PUBLICATION"] = publist;
                //gbpublist = publist;


                mydatatable1.Rows.Add(myrow1);

                dk1.Tables.Add(mydatatable1);

                Session["retaineraddtionalcomm_slab"] = dk1;

                binddata1();
            }
        }
        else
        {
            Session["retaineraddtionalcomm_slab"] = dk1;
            binddata1();
            txtmainpub.Text = "";
            txtpubper.Text = "";
            libox.SelectedValue = "0";

        }
    }


    public void binddata1()
    {

        DataGrid1.Visible = true;

        DataSet ds_tbl = new DataSet();
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "PUBL_CODE";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "NO_OF_PUBL";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "ADDCOMM_PER";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "COMM_TARGET_ID";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "TEMPEXECODE";
        mydatatable.Columns.Add(mycolumn);


        string abc = "0";
        my_row = mydatatable.NewRow();
        my_row["PUBL_CODE"] = gblist;
        my_row["NO_OF_PUBL"] = gbnopub;
        my_row["ADDCOMM_PER"] = gbfpubper;
        my_row["COMM_TARGET_ID"] = n_m;
        my_row["TEMPEXECODE"] = gbtempexecode;
        ds_tbl.Tables.Add(mydatatable);

        if (Session["retaineraddtionalcomm_slab"] == null)
        {
            ds_tbl.Tables.Add(mydatatable);
            if (ds_tbl.Tables[0].Rows[0]["COMM_TARGET_ID"].ToString() == n_m)
            {
                DataGrid1.DataSource = ds_tbl.Tables[0];
                DataGrid1.DataBind();
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
                        mycolumn1.ColumnName = "PUBL_CODE";
                        mydatatable1.Columns.Add(mycolumn1);


                        mycolumn1 = new DataColumn();
                        mycolumn1.DataType = System.Type.GetType("System.String");
                        mycolumn1.ColumnName = "NO_OF_PUBL";
                        mydatatable1.Columns.Add(mycolumn1);


                        mycolumn1 = new DataColumn();
                        mycolumn1.DataType = System.Type.GetType("System.String");
                        mycolumn1.ColumnName = "ADDCOMM_PER";
                        mydatatable1.Columns.Add(mycolumn1);

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
                    myrow1["PUBL_CODE"] = ds_tbl.Tables[0].Rows[k]["PUBL_CODE"].ToString();
                    myrow1["NO_OF_PUBL"] = ds_tbl.Tables[0].Rows[k]["NO_OF_PUBL"].ToString();
                    myrow1["ADDCOMM_PER"] = ds_tbl.Tables[0].Rows[k]["ADDCOMM_PER"].ToString();
                    myrow1["COMM_TARGET_ID"] = ds_tbl.Tables[0].Rows[k]["COMM_TARGET_ID"].ToString();
                    myrow1["TEMPEXECODE"] = ds_tbl.Tables[0].Rows[k]["TEMPEXECODE"].ToString(); 
                    mydatatable1.Rows.Add(myrow1);

                }
                else if (hiddenretcode.Value == ds_tbl.Tables[0].Rows[k]["TEMPEXECODE"].ToString())
                {
                    if (flagm == "T")
                    {
                        mycolumn1 = new DataColumn();
                        mycolumn1.DataType = System.Type.GetType("System.String");
                        mycolumn1.ColumnName = "PUBL_CODE";
                        mydatatable1.Columns.Add(mycolumn1);


                        mycolumn1 = new DataColumn();
                        mycolumn1.DataType = System.Type.GetType("System.String");
                        mycolumn1.ColumnName = "NO_OF_PUBL";
                        mydatatable1.Columns.Add(mycolumn1);


                        mycolumn1 = new DataColumn();
                        mycolumn1.DataType = System.Type.GetType("System.String");
                        mycolumn1.ColumnName = "ADDCOMM_PER";
                        mydatatable1.Columns.Add(mycolumn1);

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
                    myrow1["PUBL_CODE"] = ds_tbl.Tables[0].Rows[k]["PUBL_CODE"].ToString();
                    myrow1["NO_OF_PUBL"] = ds_tbl.Tables[0].Rows[k]["NO_OF_PUBL"].ToString();
                    myrow1["ADDCOMM_PER"] = ds_tbl.Tables[0].Rows[k]["ADDCOMM_PER"].ToString();
                    myrow1["COMM_TARGET_ID"] = ds_tbl.Tables[0].Rows[k]["COMM_TARGET_ID"].ToString();
                    myrow1["TEMPEXECODE"] = ds_tbl.Tables[0].Rows[k]["TEMPEXECODE"].ToString();
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
            //dv.Sort = sortfield;
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

            DataGrid1.Visible = false;
        }



        txtmainpub.Text = "";
        txtpubper.Text = "";
        libox.SelectedValue = "0";

    }
    [Ajax.AjaxMethod]
    public string insertretaddslab(string compcode, string userid, string retcode, string lstpub, string minpub, string publication, string commid)
    {
        string flag;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdvertisementMaster insert = new NewAdbooking.Classes.AdvertisementMaster();

            ds = insert.insertretaddcomm(compcode, userid, retcode, lstpub, minpub, publication, commid);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.AdvertisementMaster insert = new NewAdbooking.classesoracle.AdvertisementMaster();

                ds = insert.insertretaddcomm(compcode, userid, retcode, lstpub, minpub, publication, commid);

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
    [Ajax.AjaxMethod]
    public DataSet checkretaddslabupdate(string compcode, string userid, string retcode, string lstpub, string minpub, string publication, string targetid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdvertisementMaster rtmst = new NewAdbooking.Classes.AdvertisementMaster();
            ds = rtmst.AddSlabupdate(compcode, userid, retcode, lstpub, minpub, publication, targetid);
            //return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.AdvertisementMaster rtmst = new NewAdbooking.classesoracle.AdvertisementMaster();
                ds = rtmst.AddSlabupdate(compcode, userid, retcode, lstpub, minpub, publication, targetid);

            }
        //else
        //{
        //    NewAdbooking.classmysql.RetainerMaster rtmst = new NewAdbooking.classmysql.RetainerMaster();
        //    ds = rtmst.Ret_GetSlabupdate(retcode, compcode, userid, common, commrate, todays, fromdays, code);
        //}
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet Ret_AddDeleteSlab(string compcode, string userid, string retcode, string targetid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdvertisementMaster rtmst = new NewAdbooking.Classes.AdvertisementMaster();
            ds = rtmst.Ret_AddDelete(compcode, userid, retcode, targetid);
            //return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.AdvertisementMaster rtmst = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = rtmst.Ret_AddDelete(compcode, userid, retcode, targetid);


        }
        //else
        //{
        //    NewAdbooking.classmysql.RetainerMaster rtmst = new NewAdbooking.classmysql.RetainerMaster();
        //    ds = rtmst.Ret_StatusDeleteSlab(userid, compcode, retcode, enlncode);
        //}
        return ds;

    }

    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //DataView dv = new DataView();
            //dv = (DataView)DataGrid1.DataSource;
            //DataColumnCollection dc = dv.Table.Columns;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                string str = "DataGrid1__ctl_CheckBox1" + j;
                e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return AddSlabSelect('" + str + "');\" value=" + e.Item.Cells[1].Text + "  />";
                j++;

            }
        }
    }
    [Ajax.AjaxMethod]
    public DataSet bindAddslab(string retcode, string compcode, string userid, string code11)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.AdvertisementMaster insert = new NewAdbooking.Classes.AdvertisementMaster();
            ds = insert.selectretaddslab(retcode, compcode, userid, code11);
            //return ds;
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster insert = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = insert.selectretaddslab(retcode, compcode, userid, code11);

        }
        //else
        //{
        //    NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();
        //    ds = insert.selectretslab(retcode, compcode, userid, code11);
        //}

        return ds;

    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setviewstatevalue()
    {
        Session["hdnflag"] = "T";
    }

}
