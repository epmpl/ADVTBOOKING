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

public partial class clientcontactdetails : System.Web.UI.Page
{
    public static int numberDiv;
    public static string dupName;
    string custcode, userid, compcode, show, n_m;
    int j = 0;
    public static int flag = 0;
    static string gbcontperson = "", gbdob = "", gbphone = "", gbext = "", gbfax = "", gbmailid = "", gbanniversary = "", gbmobile = "";
    DataSet dk1 = new DataSet();
    DataRow my_row;
    protected void Page_Load(object sender, System.EventArgs e)
    {

        Response.Expires = -1;
        txtcontactperson.Focus();
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }
        if (Session["compcode"].ToString() == "" && Session["userid"].ToString() == "")
        {
            Response.Write("<script>alert('Your session has been expired');</script>");
            return;
        }

        userid = Session["userid"].ToString();
        hiddenuserid.Value = userid;

        show = Request.QueryString["show"].ToString();
        n_m = Request.QueryString["n_m"].ToString();
        hiddenchk.Value = n_m;
        
        compcode = Session["compcode"].ToString();
        hiddencomcode.Value = compcode;


        custcode = Request.QueryString["custcode"].ToString();
        hiddencustcode.Value = custcode;
        hiddenccode.Value = custcode;

        hiddendateformat.Value = Session["dateformat"].ToString();

        


        if (hiddenccode.Value == "")
        {
            Response.Write("<script>alert('You Should Enter The Customer Code First');window.close();</script>");
            return;
        }
        // Put user code to initialize the page here
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/clientcontactdetails.xml"));
        lbcontact.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbphone.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbdob.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        //lbdesignation.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbfax.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbextension.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbemailid.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        btnsubmit.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        btnclear.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        btndelete.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        btnclose.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lblanniversary.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lblmobile.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lblempcod.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();

       // btnselect.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();



        Ajax.Utility.RegisterTypeForAjax(typeof(clientcontactdetails));

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
           // btnselect.Enabled = true;
            //if(n_m=="1"||n_m=="2")
            //{
            //    btndelete.Enabled=false;
            //}
            //else
            //{
            //btndelete.Enabled = true;
            //}
            btnclear.Enabled = true;
            btndelete.Enabled = false;
            txtcontactperson.Enabled = true;
          //  txtdesignation.Enabled = true;
            txtdob.Enabled = true;
            txtemailid.Enabled = true;
            txtext.Enabled = true;
            txtfaxno.Enabled = true;
            txtphoneno.Enabled = true;
            txtanniversary.Enabled = true;
            txtmobile.Enabled = true;
        }
        else
        {
            btnsubmit.Enabled = false;
           // btnselect.Enabled = true;
            btndelete.Enabled = false;
            btnclear.Enabled = true;
            txtcontactperson.Enabled = false;
          //  txtdesignation.Enabled = false;
            txtdob.Enabled = false;
            txtemailid.Enabled = false;
            txtext.Enabled = false;
            txtfaxno.Enabled = false;
            txtphoneno.Enabled = false;
            txtanniversary.Enabled = false;
            txtmobile.Enabled = false;

        }
        if (!Page.IsPostBack)
        {
            if (dk1.Tables.Count > 0 && Session["client_cont"] == null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();
            }
            if(Session["client_cont"]==null)
            {
                DataGrid2.Visible = false;
                Divgrid2.Visible = false;
                Divgrid1.Visible = true;
                DataGrid1.Visible = true;
                binddata("Cont_Person");
                dupName = "";
                hiddenDupName.Value = "";
            }
            else
            {
                DataGrid2.Visible = true;
                Divgrid2.Visible = true;
                Divgrid1.Visible = false;
                DataGrid1.Visible = false;
                binddata1("Cont_Person");
                hiddenDupName.Value = dupName;
            }
            txtemailid.Attributes.Add("OnBlur", "javascript:return checkEmail();");
            btnsubmit.Attributes.Add("OnClick", "javascript:return submitcontact();  ");
            btnclear.Attributes.Add("OnClick", "javascript:return clearclick();");
            txtdob.Attributes.Add("OnChange", "javascript:return checkdateforcurr(this);  ");
            txtanniversary.Attributes.Add("OnChange", "javascript:return checkdateforcurr(this);  ");
            btndelete.Attributes.Add("OnClick", "javascript:return deletebtn();  ");


           // txtemailid.Attributes.Add("OnBlur", "javascript:return ClientEmailCheck('txtemailid');");
            txtcontactperson.Attributes.Add("OnBlur", "javascript:return uppercase();  ");
            //txtemailid.Attributes.Add("OnClick","javascript:return checkEmail();  ");
            txtdob.Attributes.Add("onChange", "javascript:return checkdate(this);  ");
            //txtdob.Attributes.Add("OnkeyDown", "javascript:return false;  ");
            txtphoneno.Attributes.Add("OnChange", "javascript:return pholeminlength('txtphoneno')");
            btnclose.Attributes.Add("OnClick", "javascript:return closewindow();");

            txtemcode.Attributes.Add("onkeydown", "javascript:return F2fillempcode(event);");
            lstempcode.Attributes.Add("onkeydown", "javascript:return Clickrempcode_ret(event);");
            lstempcode.Attributes.Add("OnClick", "javascript:return Clickrempcode_ret(event);");



            //binddata("cont_person");

        }



    }



    /*private void binddata()
    {
			
			
        NewAdbooking.Classes.ClientMasterpopup databind=new NewAdbooking.Classes.ClientMasterpopup();
        DataSet da=new DataSet();
        da=databind.clientcontactbind(custcode,Session["userid"].ToString(),Session["compcode"].ToString());
        DataGrid1.DataSource=da;
        DataGrid1.DataBind();
			
    }*/



    private void binddata(string sortfield)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientMasterpopup databind = new NewAdbooking.Classes.ClientMasterpopup();
            da = databind.clientcontactbind12(custcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMasterpopup databind = new NewAdbooking.classesoracle.ClientMasterpopup();
            da = databind.clientcontactbind12(custcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.ClientMasterpopup databind = new NewAdbooking.classmysql.ClientMasterpopup();
            da = databind.clientcontactbind12(custcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());
        }
        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        dv = da.Tables[0].DefaultView;
        dv.Sort = sortfield;
        DataGrid1.DataSource = dv;
        DataGrid1.DataBind();

    }

    public void binddata1(string sortfield)
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
        mycolumn.ColumnName = "Cont_Person";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "DOB";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        //mycolumn = new DataColumn();
        //mycolumn.DataType = System.Type.GetType("System.String");
        //mycolumn.ColumnName = "Designation";
        //mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Phone";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Extension";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Fax";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "EmailID";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Cont_Code";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "ANNIVERSARY";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "MOBILENO";
        mydatatable.Columns.Add(mycolumn);


        my_row = mydatatable.NewRow();


        my_row["Cont_Person"] = gbcontperson;
        my_row["DOB"] = gbdob;
        //my_row["Designation"] = gbdesignation;
        my_row["Phone"] = gbphone;
        my_row["Extension"] = gbext;
        my_row["Fax"] = gbfax;
        my_row["EmailID"] = gbmailid;
        my_row["ANNIVERSARY"] = gbanniversary;
        my_row["MOBILENO"] = gbmobile;
        my_row["Cont_Code"] = "0";
        //gbsecondcycle = txtaddate.Text;

        // mydatatable.Rows.Add(my_row);

        //ds_tbl.Tables.Add(mydatatable);

        // mydatatable.ImportRow(my_row);

        if (Session["client_cont"] == null)
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
            dsnew = (DataSet)Session["client_cont"];
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

            // ds_tbl.Tables.Add(mydatatable);
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

        gbmailid = "";
        gbfax = "";
        gbext = "";
        gbdob = "";
        //gbdesignation = "";
        gbcontperson = "";
        gbphone = "";
        gbanniversary = "";
        gbmobile = "";
        txtcontactperson.Text = "";
        //txtdesignation.Text = "";
        txtdob.Text = "";
        txtemailid.Text = "";
        txtext.Text = "";
        txtfaxno.Text = "";
        txtphoneno.Text = "";
        txtanniversary.Text = "";
        txtmobile.Text = "";


    }

    private void DataGrid1_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        DataView dv = new DataView();


        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;




        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + "  OnClick=\"javascript:return selected('" + str + "');\"  value=" + e.Item.Cells[7].Text + "  />";
            j++;

        }







        if (e.Item.ItemType == ListItemType.Header)
        {

            if (ViewState["SortExpression"].ToString() != "")
            {
                string str = "";
                switch (ViewState["SortExpression"].ToString())
                {
                    case "cont_person":
                        str = "Contact Person";
                        break;

                    case "dob":
                        str = "Date Of Birth";
                        break;

                    case "phone":
                        str = "Phone No.";
                        break;

                    case "extension":
                        str = "Ext.";
                        break;

                    case "fax":
                        str = "Fax No.";
                        break;

                    case "emailid":
                        str = "Email Id";
                        break;
                    case "anniversary":
                        str = "Anniversary Date";
                        break;
                    case "mobile":
                        str = "Mobile No";
                        break;


                };
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




    private void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientMasterpopup databind = new NewAdbooking.Classes.ClientMasterpopup();
            da = databind.contactbind(custcode, Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMasterpopup databind = new NewAdbooking.classesoracle.ClientMasterpopup();
            da = databind.contactbind(custcode, Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.ClientMasterpopup databind = new NewAdbooking.classmysql.ClientMasterpopup();
            da = databind.contactbind(custcode, Session["userid"].ToString(), Session["compcode"].ToString());
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










    [Ajax.AjaxMethod]
    public void submitcontact(string contactperson, string txtdob, string txtphoneno, string txtext, string txtfaxno, string mail, string compcode, string userid, string custcode, string update, string anniversary, string mobile)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientMasterpopup contactup = new NewAdbooking.Classes.ClientMasterpopup();
            da = contactup.contactupdate(contactperson, txtdob, txtphoneno, txtext, txtfaxno, mail, compcode, userid, custcode, update, anniversary,mobile);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMasterpopup contactup = new NewAdbooking.classesoracle.ClientMasterpopup();
            da = contactup.contactupdate(contactperson, txtdob, txtphoneno, txtext, txtfaxno, mail, compcode, userid, custcode, update, anniversary,mobile);
        }
   
        {
             NewAdbooking.classmysql.ClientMasterpopup contactup = new NewAdbooking.classmysql.ClientMasterpopup();
             da = contactup.contactupdate(contactperson, txtdob, txtphoneno, txtext, txtfaxno, mail, compcode, userid, custcode, update);
         }

        DataGrid1.DataSource = da;
        DataGrid1.DataBind();
    }

    //************************************************by Manish***********************************************
    public void insertcontact(string contact, string dob, string phone, string ext, string fax, string mail, string compcode, string userid, string custcode, string anniversary, string mobile)
    {
         DataSet ds1 = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Classes.ClientMasterpopup contactinsert = new NewAdbooking.Classes.ClientMasterpopup();
             ds1 = contactinsert.insertcontact(contact, dob, phone, ext, fax, mail, userid, custcode, compcode, anniversary,mobile);
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.classesoracle.ClientMasterpopup contactinsert = new NewAdbooking.classesoracle.ClientMasterpopup();
             ds1 = contactinsert.insertcontact(contact, dob, phone, ext, fax, mail, userid, custcode, compcode, anniversary,mobile);
         }
         else
         {
             NewAdbooking.classmysql.ClientMasterpopup contactinsert = new NewAdbooking.classmysql.ClientMasterpopup();
             ds1 = contactinsert.insertcontact(contact, dob, phone, ext, fax, mail, userid, custcode, compcode);
         }
    }
    //********************************************************************************************************

    [Ajax.AjaxMethod]
    public void insertcontactdtl(string contactperson, string txtdob, string txtphoneno, string txtext, string txtfaxno, string mail, string userid, string custcode, string compcode, string anniversary, string mobile)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientMasterpopup contactinsert = new NewAdbooking.Classes.ClientMasterpopup();
            ds = contactinsert.insertcontact(contactperson, txtdob, txtphoneno, txtext, txtfaxno, mail, userid, custcode, compcode, anniversary,mobile);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMasterpopup contactinsert = new NewAdbooking.classesoracle.ClientMasterpopup();
            ds = contactinsert.insertcontact(contactperson, txtdob, txtphoneno, txtext, txtfaxno, mail, userid, custcode, compcode, anniversary,mobile);
        }
        else
        {
            NewAdbooking.classmysql.ClientMasterpopup contactinsert = new NewAdbooking.classmysql.ClientMasterpopup();
            ds = contactinsert.insertcontact(contactperson, txtdob, txtphoneno, txtext, txtfaxno, mail, userid, custcode, compcode);

        }
    }

    [Ajax.AjaxMethod]
    public DataSet checkcontact(string contactperson, string custcode, string compcode, string hiddenccode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientMasterpopup contactchk = new NewAdbooking.Classes.ClientMasterpopup();
            ds = contactchk.chkcontact(contactperson, custcode, compcode, hiddenccode);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMasterpopup contactchk = new NewAdbooking.classesoracle.ClientMasterpopup();
            ds = contactchk.chkcontact(contactperson, custcode, compcode, hiddenccode);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.ClientMasterpopup contactchk = new NewAdbooking.classmysql.ClientMasterpopup();
            ds = contactchk.chkcontact(contactperson, custcode, compcode, hiddenccode);
            return ds;
        }

    }







    [Ajax.AjaxMethod]
    public DataSet bandcontact(string custcode, string compcode, string userid, string datagrid)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.ClientMasterpopup databind = new NewAdbooking.Classes.ClientMasterpopup();
            da = databind.clientcontactbind(datagrid, userid, compcode);
            return da;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMasterpopup databind = new NewAdbooking.classesoracle.ClientMasterpopup();
            da = databind.clientcontactbind(datagrid, userid, compcode);
            return da;
        }
        else
        {
            NewAdbooking.classmysql.ClientMasterpopup databind = new NewAdbooking.classmysql.ClientMasterpopup();
            da = databind.clientcontactbind(datagrid, userid, compcode);
            return da;
        }
    }


    [Ajax.AjaxMethod]
   public void deletecontact(string custcode, string compcode, string userid, string update)
   {
         DataSet ds = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {

             NewAdbooking.Classes.ClientMasterpopup contactdelete = new NewAdbooking.Classes.ClientMasterpopup();
             ds = contactdelete.contactdelete(custcode, compcode, userid, update);
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.classesoracle.ClientMasterpopup contactdelete = new NewAdbooking.classesoracle.ClientMasterpopup();
             ds = contactdelete.contactdelete(custcode, compcode, userid, update);
         }
         else
         {
             NewAdbooking.classmysql.ClientMasterpopup contactdelete = new NewAdbooking.classmysql.ClientMasterpopup();
             ds = contactdelete.contactdelete(custcode, compcode, userid, update);
         }
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();

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

    }
    #endregion





    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;
        flag = 0;

        //saurabh check


        //if (dk1.Tables.Count != 0)
        //{
        //    Session["pubsave"] = "";
        //}


        hiddenDupName.Value = hiddenDupName.Value + txtcontactperson.Text + ",";
        dupName = hiddenDupName.Value;

        string message;
        if ((dk1.Tables.Count != 0))
        {
            int j;
            for (j = 0; j < dk1.Tables[0].Rows.Count; j++)
            {
                if (txtcontactperson.Text == dk1.Tables[0].Rows[j].ItemArray[0].ToString())
                {
                    message = "Contact Name has been submitted already";
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
            //       DataGrid2.DataSource = null;



            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Cont_Person";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "DOB";
            mydatatable1.Columns.Add(mycolumn1);

            // //DataColumn mycolumn1;
            //mycolumn1 = new DataColumn();
            //mycolumn1.DataType = System.Type.GetType("System.String");
            //mycolumn1.ColumnName = "Designation";
            //mydatatable1.Columns.Add(mycolumn1);

            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Phone";
            mydatatable1.Columns.Add(mycolumn1);
            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Extension";
            mydatatable1.Columns.Add(mycolumn1);
            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Fax";
            mydatatable1.Columns.Add(mycolumn1);
            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "EmailID";
            mydatatable1.Columns.Add(mycolumn1);

            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Cont_Code";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "ANNIVERSARY";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "MOBILENO";
            mydatatable1.Columns.Add(mycolumn1);

            myrow1 = mydatatable1.NewRow();

            myrow1["Cont_Code"] = "00";


            myrow1["Cont_Person"] = txtcontactperson.Text;
            gbcontperson = txtcontactperson.Text;
            myrow1["DOB"] = txtdob.Text;
            gbdob = txtdob.Text;
            //myrow1["Designation"] = txtdesignation.Text;
            //gbdesignation = txtdesignation.Text;
            myrow1["Phone"] = txtphoneno.Text;
            gbphone = txtphoneno.Text;
            myrow1["Extension"] = txtext.Text;
            gbext = txtext.Text;
            myrow1["Fax"] = txtfaxno.Text;
            gbfax = txtfaxno.Text;

            myrow1["EmailID"] = txtemailid.Text;
            gbmailid = txtemailid.Text;

            myrow1["ANNIVERSARY"] = txtanniversary.Text;
            gbanniversary = txtanniversary.Text;

            myrow1["MOBILENO"] = txtmobile.Text;
            gbdob = txtmobile.Text;



            mydatatable1.Rows.Add(myrow1);
          
            if (Session["client_cont"] != null)
            {
                DataSet dsnew = new DataSet();
                dsnew = (DataSet)Session["client_cont"];
                dk1 = dsnew;
            }
            dk1.Tables.Add(mydatatable1);

            Session["client_cont"] = dk1;

            binddata1("Cont_Person");
        }
    }

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(clientcontactdetails), "ShowAlert", strAlert, true);
    }

    protected void DataGrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        binddata("Cont_Person");
    }
    [Ajax.AjaxMethod]
    public DataSet empcodebind(string compcode, string empname)
    {
        //drpemcode.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.BranchMaster name = new NewAdbooking.Classes.BranchMaster();
            ds = name.bindempcode_new(compcode, empname);

        }
        else
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BranchMaster name = new NewAdbooking.classesoracle.BranchMaster();
            ds = name.bindempcode(compcode, empname);

        }
        return ds;


    }
}