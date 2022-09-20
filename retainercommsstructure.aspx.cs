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

public partial class retainercommsstructure : System.Web.UI.Page
{
    string userid, compcode, retcode, show, n_m, gbcommrate;
    string gbfrom, gbto, gbenln, gbcommon;
    string gbpublist="";
    string gbpubtype="";
    string gbadtype="";
    string gbcusttype="";
    string gbcat="";
    string gbteam = "";
    static DataSet dk1 = new DataSet();
    DataRow my_row;
    public static int numberDiv;
    int j = 0;
    int i = 1;
    public static int id;
    protected void Page_Load(object sender, System.EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //string codepass = Request.QueryString["codepass"].ToString();

        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(retainercommsstructure));
        show = Request.QueryString["show"].ToString();
        n_m = Request.QueryString["n_m"].ToString();
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
        DataSet dk = new DataSet();
        dk.ReadXml(Server.MapPath("XML/retainercommstructure.xml"));

        lblfromtgt.Text = dk.Tables[0].Rows[0].ItemArray[0].ToString();
        lblteam.Text = dk.Tables[0].Rows[0].ItemArray[1].ToString();
        lbltotgt.Text = dk.Tables[0].Rows[0].ItemArray[2].ToString();
        lbladpub.Text = dk.Tables[0].Rows[0].ItemArray[8].ToString();
        //lblcategory.Text = dk.Tables[0].Rows[0].ItemArray[3].ToString();
        lblcusttype.Text = dk.Tables[0].Rows[0].ItemArray[10].ToString();
        lblpubtype.Text = dk.Tables[0].Rows[0].ItemArray[11].ToString();
        //lbladpub.Text = dk.Tables[0].Rows[0].ItemArray[8].ToString();
        lblcategory.Text = dk.Tables[0].Rows[0].ItemArray[3].ToString();
        lblpublication.Text = dk.Tables[0].Rows[0].ItemArray[9].ToString();        
        btnSave.Text = dk.Tables[0].Rows[0].ItemArray[4].ToString();
        btnclear.Text = dk.Tables[0].Rows[0].ItemArray[5].ToString();
        btnclose.Text = dk.Tables[0].Rows[0].ItemArray[6].ToString();
        btndelete.Text = dk.Tables[0].Rows[0].ItemArray[7].ToString();
        if (show == "1")
        {
            btnSave.Enabled = true;            
            txtto.Enabled = true;
            txtfrom.Enabled = true;
            drpcusttype.Enabled = true;
            drpadpub.Enabled = true;
            drpteam.Enabled = true;
            drpcat.Enabled = true;
            lstpublication.Enabled = true;
            btndelete.Enabled = false;
            hiddendelsau.Value = "0";
        }
        if (show == "0")
        {
            btndelete.Enabled = false;
            btnSave.Enabled = false;
            txtto.Enabled = false;
            txtfrom.Enabled = false;
            drpcusttype.Enabled = false;
            drpadpub.Enabled = false;
            drpteam.Enabled = false;
            drpcat.Enabled = false;
            lstpublication.Enabled = false;
            hiddendelsau.Value = "0";
        }

        if (show == "2")
        {
            btnSave.Enabled = true;
            btndelete.Enabled = false;
            txtto.Enabled = true;
            txtfrom.Enabled = true;
            drpcusttype.Enabled = true;
            drpadpub.Enabled = true;
            drpteam.Enabled = true;
            drpcat.Enabled = true;
            lstpublication.Enabled = true;
            hiddendelsau.Value = "1";
        }

        if (!Page.IsPostBack)
        {
            if (dk1.Tables.Count > 0 && Session["retainer_comm_structure"] == null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();
            }
            if (Session["retainer_comm_structure"] == null)
            {
                DataGrid2.Visible = false;
                Divgrid2.Visible = false;
                Divgrid1.Visible = true;
                DataGrid1.Visible = true;
                DataGrid1.DataSource = "";
                DataGrid1.DataBind();
                binddata();

            }
            else
            {
                DataGrid2.Visible = true;
                Divgrid2.Visible = true;
                Divgrid1.Visible = false;
                DataGrid1.Visible = false;
                binddata1();
            }
            bindteam();
            bindadcat();
            bindcusttype();
            bindadtype();
            //bindpublication();
            bindpubtype();
            //binddata1();
            ////Button Coding
            //btnSave.Attributes.Add("OnClick", "javascript:return RetcomslabSubmit();");
            btnSave.Attributes.Add("OnClick", "javascript:return grdSubmit();");
            btnclear.Attributes.Add("OnClick", "javascript:return PopadcommstSlabClear();");
            btndelete.Attributes.Add("OnClick", "javascript:return RetstrSlabDelete();");
            btndayslb.Attributes.Add("OnClick", "javascript:return openpage();");
            btnadcomm.Attributes.Add("Onclick", "javascript:return openaddcomm();");
            drppubtype.Attributes.Add("onchange", "javascript:return bindpub()");
            //Session["retainer_slab"] = dk1;
          
        }
        //if (s1.IsInAsyncPostBack)
        //{

        //    hiddenflag.Value = "T";


        //}
        ////else
        ////{
        ////    hiddenflag.Value = "F";
        ////}

    }
    public void bindadtype()
    {
       
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {


            NewAdbooking.Report.classesoracle.Class1 advname = new NewAdbooking.Report.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advname = new NewAdbooking.Report.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());

        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "ra_adbindcategory_ra_adbindcategory_p";
            string[] parameterValueArray = { Session["compcode"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select AdType";
        li1.Value = "0";
        li1.Selected = true;
        drpadpub.Items.Add(li1);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpadpub.Items.Add(li);


        }
    }
    public void bindpubtype()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            //regionhidden=hiddenregion.Value;
            NewAdbooking.Classes.PublicationMaster Publicationtype = new NewAdbooking.Classes.PublicationMaster();

            ds = Publicationtype.publicationtype();
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.PublicationMaster Publicationtype = new NewAdbooking.classesoracle.PublicationMaster();

                ds = Publicationtype.publicationtype();
            }
            
            else
            {
                NewAdbooking.classmysql.PublicationMaster Publicationtype = new NewAdbooking.classmysql.PublicationMaster();

                ds = Publicationtype.publicationtype();

            }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Publication Type";
        li1.Value = "0";
        li1.Selected = true;
        drppubtype.Items.Add(li1);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drppubtype.Items.Add(li);


        }
    }
     [Ajax.AjaxMethod]
    public DataSet bindpublicatin(string compcode, string ptype,  string publcode, string extra1, string extra2)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RetainerMaster pub = new NewAdbooking.classesoracle.RetainerMaster();
            ds = pub.advpub(compcode, ptype, publcode, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster pub = new NewAdbooking.Classes.RetainerMaster();
            ds = pub.advpub(compcode, ptype, publcode, extra1, extra2);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bind_publ_name";
            string[] parameterValueArray = { compcode, ptype, publcode, extra1, extra2 };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        //ListItem li = new ListItem();
        //li.Value = "0";
        //li.Text = "Select Publication";
        //li.Selected = true;
        //lstpublication.Items.Add(li);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    ListItem li1 = new ListItem();
        //    li1.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //    li1.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //    lstpublication.Items.Add(li1);
        //}
        return ds;
    }
    public void bindcusttype()
    {
        drpcusttype.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster client = new NewAdbooking.Classes.RateMaster();
            ds = client.bindclientcat(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster client = new NewAdbooking.classesoracle.RateMaster();
            ds = client.bindclientcat(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.RateMaster client = new NewAdbooking.classmysql.RateMaster();
            ds = client.bindclientcat(Session["compcode"].ToString());

        }
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcusttype.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                drpcusttype.Items.Add(li);
            }

        }

    }
    public void bindadcat()
    {
        drpcat.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
            ds = adcat.advtype("", compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.advtype("", compcode);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "RA_bindadcategory_RA_bindadcategory_p";
            string[] parameterValueArray = { "", compcode };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select--";
        
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcat.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpcat.Items.Add(li);


        }
    }
    public void bindteam()
    {
        drpteam.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.team(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SummaryReport advpub = new NewAdbooking.Report.classesoracle.SummaryReport();
            ds = advpub.team(Session["compcode"].ToString());
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Bind_team";
            string[] parameterValueArray = { Session["compcode"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpteam.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpteam.Items.Add(li);


        }
    }
    //public void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    //{
    //    DataSet da = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Classes.RetainerMaster bind = new NewAdbooking.Classes.RetainerMaster();
    //        da = bind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(),"");
    //    }

    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.RetainerMaster bind = new NewAdbooking.classesoracle.RetainerMaster();
    //        da = bind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(),"");

    //    }
    //    else
    //    {
    //        NewAdbooking.classmysql.RetainerMaster bind = new NewAdbooking.classmysql.RetainerMaster();
    //        da = bind.retainerstatusbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

    //    }

    //    DataView dv = new DataView();
    //    dv = da.Tables[0].DefaultView;
    //    if ((numberDiv % 2) == 0)
    //    {
    //        dv.Sort = e.SortExpression + " " + "ASC";
    //        ViewState["SortExpression"] = e.SortExpression;
    //        ViewState["order"] = "ASC";
    //    }
    //    else
    //    {
    //        dv.Sort = e.SortExpression + " " + "DESC";
    //        ViewState["SortExpression"] = e.SortExpression;
    //        ViewState["order"] = "DESC";
    //    }
    //    numberDiv++;



    //    DataGrid1.DataSource = dv;
    //    DataGrid1.DataBind();


    //}




    public void binddata()
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster databind = new NewAdbooking.Classes.RetainerMaster();
            da = databind.retainerstructuresbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RetainerMaster databind = new NewAdbooking.classesoracle.RetainerMaster();
            da = databind.retainerstructuresbind_b(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "AD_RETAIN_COMM_TARGET_BIND";
            string[] parameterValueArray = { retcode, Session["userid"].ToString(), Session["compcode"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            da = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        DataView dv = new DataView();
        if (da.Tables.Count > 0)
        {
            dv = da.Tables[0].DefaultView;
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["hdnflag"] == "T")
        {
            if (txtfrom.Text.Trim().ToString() == "" || txtto.Text.Trim().ToString() == "" || drpteam.SelectedItem.Value.ToString() == "0" || drpcat.SelectedItem.Value.ToString() == "0" || drpadpub.SelectedItem.Value.ToString() == "0" || drpcusttype.SelectedItem.Value.ToString() == "0" || drppubtype.SelectedItem.Value.ToString() == "0")
            {
                Response.Write("<script>alert('Please fill the data in data control');</script>");
                return;
            }
            else
            {
                Session["hdnflag"] = null;


                DataColumn mycolumn1;
                DataTable mydatatable1 = new DataTable();
                DataRow myrow1;

                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "ENLN";
                mydatatable1.Columns.Add(mycolumn1);

                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "TEAM";
                mydatatable1.Columns.Add(mycolumn1);

                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "FROM_TGT";
                mydatatable1.Columns.Add(mycolumn1);

                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "TO_TGT";
                mydatatable1.Columns.Add(mycolumn1);

                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "CATEGORY";
                mydatatable1.Columns.Add(mycolumn1);

                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "CUST_TYPE";
                mydatatable1.Columns.Add(mycolumn1);

                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "AD_TYPE";
                mydatatable1.Columns.Add(mycolumn1);

                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "PUB_TYPE";
                mydatatable1.Columns.Add(mycolumn1);

                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "PUBLICATION";
                mydatatable1.Columns.Add(mycolumn1);


                myrow1 = mydatatable1.NewRow();
                id = id + 1;
                myrow1["ENLN"] = id;

                myrow1["TEAM"] = drpteam.SelectedValue;
                gbteam = drpteam.SelectedValue;

                myrow1["FROM_TGT"] = txtfrom.Text;
                gbfrom = txtto.Text;

                myrow1["TO_TGT"] = txtto.Text;
                gbto = txtto.Text;

                myrow1["CATEGORY"] = drpcat.SelectedValue;
                gbcat = drpcat.SelectedValue;

                myrow1["CUST_TYPE"] = drpcusttype.SelectedValue;
                gbcusttype = drpcusttype.SelectedValue;

                myrow1["AD_TYPE"] = drpadpub.SelectedValue;
                gbadtype = drpadpub.SelectedValue;

                myrow1["PUB_TYPE"] = drppubtype.SelectedValue;
                gbpubtype = drppubtype.SelectedValue;

                //string publist = hiddenpublicationcode.value;
                //for(int x=0; x<lstpublication.Items.Count;x++)
                //{
                //    if(lstpublication.Items[x].Selected==true)
                //    {
                //        if(publist=="")
                //            publist=lstpublication.Items[x].Value;
                //        else
                //            publist=publist+","+lstpublication.Items[x].Value;
                //    }
                //}

                myrow1["PUBLICATION"] = hiddenpublicationcode.Value;
                gbpublist = hiddenpublicationcode.Value;



                /*int j = 0;
                if (DataGrid2.Items.Count > 0)
                {
                    while (j < DataGrid2.Items.Count)
                    {
                        string fromdate = DataGrid2.Items[j].Cells[1].Text;
                        string todate = DataGrid2.Items[j].Cells[2].Text;
                        int txtfdate = Convert.ToInt32(txtfrom.Text);
                        int txttdate = Convert.ToInt32(txtto.Text);
                        int fdate = Convert.ToInt32(fromdate);
                        int tdate = Convert.ToInt32(todate);
                        //  if (Convert.ToInt32(fromdate) == Convert.ToInt32(txtfrom.Text) && Convert.ToInt32(todate) == Convert.ToInt32(txtto.Text))
                        //  if ((txtfdate >= fdate && txttdate <= tdate) || (txtfdate == fdate && txttdate > tdate)) 
                        if ((txtfdate >= fdate && txtfdate <= tdate) || (txttdate >= fdate && txttdate <= tdate)) //|| (txtfdate == fdate && txttdate > tdate)
                        {
                            string message = "Retainer Slab already exist with this Target Range";
                            AspNetMessageBox(message);
                            txtfrom.Text = "";
                            txtto.Text = "";
                            return;
                        }
                        j++;
                    }

                }*/
                mydatatable1.Rows.Add(myrow1);
                dk1.Tables.Add(mydatatable1);
                Session["retainer_comm_structure"] = dk1;
                binddata1();
                //return;


            }
        }
        else
        {
            Session["retainer_comm_structure"] = dk1;
            binddata1();
            txtfrom.Text = "";
                txtto.Text= "";
                drpteam.SelectedValue = "0";
                drpcat.SelectedValue = "0";
            drpadpub.SelectedValue = "0";
            drpcusttype.SelectedValue = "0";
            drppubtype.SelectedValue = "0";

            //return;
        }
    }


    public void binddata1()
    {
        
        DataGrid2.Visible = true;
        Divgrid2.Visible = true;
        DataGrid1.Visible = false;
        Divgrid1.Visible = false;

        DataSet ds_tbl = new DataSet();
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();


        // DataRow myrow;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "ENLN";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "TEAM";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "FROM_TGT";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "TO_TGT";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "CATEGORY";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "CUST_TYPE";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "AD_TYPE";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "PUB_TYPE";
        mydatatable.Columns.Add(mycolumn);
        
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "PUBLICATION";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "COMM_TARGET_ID";
        mydatatable.Columns.Add(mycolumn);

        /***********ajay*************/

        string abc = "1";
        my_row = mydatatable.NewRow();
        //id = id + 1;
        my_row["ENLN"] = id;
        my_row["TEAM"] = gbteam;
        my_row["FROM_TGT"] = gbfrom;
        my_row["TO_TGT"] = gbto;
        my_row["CATEGORY"] = gbcat;
        my_row["CUST_TYPE"] = gbcusttype;
        my_row["AD_TYPE"] = gbadtype;
        my_row["PUB_TYPE"] = gbpubtype;
        my_row["PUBLICATION"] = gbpublist;
        my_row["COMM_TARGET_ID"] = abc;

          ds_tbl.Tables.Add(mydatatable);

        // mydatatable.ImportRow(my_row);

          if (Session["retainer_comm_structure"] == null)
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
                my_row = dk1.Tables[d].Rows[0];
                mydatatable.ImportRow(my_row);

            }

            // ViewState["SortExpression"] = sortfield;
            // ViewState["order"] = "ASC";
            DataView dv = new DataView();
            dv = ds_tbl.Tables[0].DefaultView;
            //dv.Sort = sortfield;
            DataGrid2.DataSource = dv;
            DataGrid2.DataBind();
            d = 0;

        }


        txtfrom.Text  = "";
        drpteam.SelectedValue = "0";
        txtto.Text = "";
        drpcat.SelectedValue = "0";
        drpcusttype.SelectedValue = "0";
        drpadpub.SelectedValue = "0";
        drppubtype.SelectedValue = "0";
        lstpublication.SelectedValue = "0";
        return;

    }

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(retainercommsstructure), "ShowAlert", strAlert, true);
    }

    [Ajax.AjaxMethod]
    public DataSet bindstruct(string retcode, string compcode, string userid, string code11)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();
            ds = insert.selectretstruct(retcode, compcode, userid, code11);
            //return ds;
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();
            ds = insert.selectretstruct(retcode, compcode, userid, code11);

        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "retselectstructslab";
            string[] parameterValueArray = { compcode ,userid,retcode,code11 };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet checkretstructslabupdate(string compcode, string userid, string retcode, string PTEAM_CODE, string PADCTG_CODE, string PFROM_TGT, string PTO_TGT, string PCUST_TYPE, string PAD_TYPE, string PPUB_TYPE, string PPUBL_CODE, string PCOMM_TARGET_ID)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster rtmst = new NewAdbooking.Classes.RetainerMaster();
            ds = rtmst.Ret_GetStructSlabupdate(compcode, userid, retcode, PTEAM_CODE, PADCTG_CODE, PFROM_TGT, PTO_TGT, PCUST_TYPE, PAD_TYPE, PPUB_TYPE, PPUBL_CODE, PCOMM_TARGET_ID);
            //return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster rtmst = new NewAdbooking.classesoracle.RetainerMaster();
                ds = rtmst.Ret_GetStructSlabupdate(compcode, userid, retcode, PTEAM_CODE, PADCTG_CODE, PFROM_TGT, PTO_TGT, PCUST_TYPE, PAD_TYPE, PPUB_TYPE, PPUBL_CODE, PCOMM_TARGET_ID);

            }
            else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "AD_RETAIN_COMM_TARGET_INS";
                string[] parameterValueArray = { retcode, PTEAM_CODE, PADCTG_CODE, PFROM_TGT, PTO_TGT, PCUST_TYPE, PAD_TYPE, PPUB_TYPE, PPUBL_CODE, userid, null, null, null, PCOMM_TARGET_ID, "U" };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        return ds;
    }

    [Ajax.AjaxMethod]
    public string insertretstructslab(string compcode, string userid, string retcode, string PTEAM_CODE, string PADCTG_CODE, string PFROM_TGT, string PTO_TGT, string PCUST_TYPE, string PAD_TYPE, string PPUB_TYPE, string PPUBL_CODE, string commcod)
    {
        string flag;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();

            ds = insert.insertretcommstructure(compcode, userid, retcode, PTEAM_CODE, PADCTG_CODE, PFROM_TGT, PTO_TGT, PCUST_TYPE, PAD_TYPE, PPUB_TYPE, PPUBL_CODE, commcod);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();

                ds = insert.insertretcommstructure(compcode, userid, retcode, PTEAM_CODE, PADCTG_CODE, PFROM_TGT, PTO_TGT, PCUST_TYPE, PAD_TYPE, PPUB_TYPE, PPUBL_CODE, commcod);

            }

            else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "AD_RETAIN_COMM_TARGET_INS";
                string[] parameterValueArray = { retcode, PTEAM_CODE, PADCTG_CODE, PFROM_TGT, PTO_TGT, PCUST_TYPE, PAD_TYPE, PPUB_TYPE, PPUBL_CODE, userid, null, null, null, commcod, "I" };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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
    public void insertretslab12(string compcode, string userid, string retcode, string fromdays, string todays, string common, string commrate, string commid,string agency_type)
    {
        string flag;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();

            ds = insert.insertretstatus_slab(compcode, userid, retcode, fromdays, todays, common, commrate, commid, agency_type);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();
            ds = insert.insertretstatus_slab(compcode, userid, retcode, fromdays, todays, common, commrate, commid, agency_type);

        }
        else
        {
            NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();
            ds = insert.insertretstatus_slab(compcode, userid, retcode, fromdays, todays, common, commrate);
        }

        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }

    [Ajax.AjaxMethod]
    public DataSet Ret_StructureDeleteSlab(string userid, string compcode, string retcode, string enlncode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();

            ds = insert.delretcommstructure(compcode, userid, retcode, enlncode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();

                ds = insert.delretcommstructure(compcode, userid, retcode, enlncode);

            }

        //else
        //{
        //    NewAdbooking.classmysql.RetainerMaster rtmst = new NewAdbooking.classmysql.RetainerMaster();
        //    ds = rtmst.Ret_StatusDeleteSlab(userid, compcode, retcode, enlncode);
        //}
        return ds;

    }

    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>");

    }



    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataView dv = new DataView();
            dv = (DataView)DataGrid1.DataSource;
            DataColumnCollection dc = dv.Table.Columns;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                string str = "DataGrid1__ctl_CheckBox1" + j;
                e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return Selectgcol('" + str + "');\" value=" + e.Item.Cells[1].Text + "  />";
                j++;

            }

            if (e.Item.ItemType == ListItemType.Header)
            {
                if (ViewState["SortExpression"].ToString() != "")
                {
                    string str = "";
                    switch (ViewState["SortExpression"].ToString())
                    {


                        // case "STATUS_NAME":
                        case "TEAM":
                            str = "Team";
                            break;

                        case "FROM_TARGET":
                            str = "From Target";
                            break;

                        case "TO_TARGET":
                            str = "To Target";
                            break;


                        case "CATEGORY":
                            str = "Category";
                            break;

                        case "CUST TYPE":
                            str = "Cust Type";
                            break;

                        case "ADD TYPE":
                            str = "Add Type";
                            break;


                        case "PUB TYPE":
                            str = "Pub Type";
                            break;



                        case "PUBLICATION":
                            str = "Publication";
                            break;

                    };
                    string strd = Convert.ToString(dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
                    strd = Convert.ToString(Convert.ToInt32(strd) - 1);
                    if (strd.Length < 2)
                        strd = "0" + strd;
                    if (ViewState["order"].ToString() == "DESC")
                    {
                        e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')  \">" + str + "</a>";

                    }
                    else
                    {
                        e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')   \">" + str + "</a>";
                    }




                }
            }


        }
    }
    protected void DataGrid2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

        if (e.Item.ItemType != ListItemType.Header)
        {
            string str = "DataGrid12__ctl_CheckBox1" + j;
            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return Selectcommstruc('" + str + "');\"  value=" + e.Item.Cells[1].Text + "  />";
            j++;
        }

    }
    [Ajax.AjaxMethod]
    public DataSet getmaxcodeforslab(string compcode, string userid)
    {
        string flag;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();

            ds = insert.gencodeforslab(compcode, userid);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();

                ds = insert.gencodeforslab(compcode, userid);

            }

     
        return ds;

    }




[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
public void setviewstatevalue()
{
Session["hdnflag"] = "T";
}



}
