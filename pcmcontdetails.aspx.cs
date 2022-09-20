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

public partial class pcmcontdetails : System.Web.UI.Page
{
    string compcode, userid, dateformat, centcode, alias;
    string sortfield;
    string show, message;
    string chkper = "", chkper1 = "";
    int j = 0;
    public static int flag = 0;
    static string gbcontperson = "", gbdob = "", gbdesignation = "", gbphone = "", gbext = "", gbfax = "", gbmailid = "";
     DataSet dk1 = new DataSet();
     DataSet dk = new DataSet();
    public static int numberDiv;
    public static string date1 = "";
    DataRow my_row;

    //string compcode, userid, dateformat, centcode;
    //string sortfield;
    //string show;
    //public static int numberDiv;
    //string currcode;
    //int j = 0;
    //string show;

    protected void Page_Load(object sender, System.EventArgs e)
    {
       
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }

        show = Request.QueryString["show"].ToString();
        hiddenshow.Value = show;
        Ajax.Utility.RegisterTypeForAjax(typeof(pcmcontdetails));

        hiddenchk.Value = "1";
        compcode = Session["compcode"].ToString();
        hiddencompcode.Value = compcode;
      //  hiddencomcode.Value = comp;

        userid = Session["userid"].ToString();
        hiddenuserid.Value = userid;

        dateformat = Session["dateformat"].ToString();
        hiddendateformat.Value = dateformat;

        centcode = Request.QueryString["centcode"].ToString();
        hiddencentcode.Value = centcode;
        Session["centcode"] = centcode;
        //hiddencentcode.Value = centcode;
        hiddenDup.Value = hiddenDup.Value + txtcontactperson.Text + ",";

        Ajax.Utility.RegisterTypeForAjax(typeof(pcmcontdetails));
        
        
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/pcmcontdetails.xml"));
        lbcontperson.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbphoneno.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbdob.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbdesignation.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbFaxNo.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbExtension.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbEmailID.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        btnsubmit.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        btnclear.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        btndelete.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        btnclose.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lblempcod.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();

        hiddencontsau.Value = txtcontactperson.Text;


        if (hiddencentcode.Value == "" || hiddencentcode.Value == null)
        {
            Response.Write("<script> alert('Please Enter Center Code First');window.close(); </script>");
        }

        // Put user code to initialize the page here
        // binddata();
        if (show == "1")
        {
            btnsubmit.Enabled = true;
            //btndelete.Enabled = true;
            txtcontactperson.Enabled = true;
            txtdesignation.Enabled = true;
            txtdob.Enabled = true;
            txtemailid.Enabled = true;
            txtext.Enabled = true;
            txtfaxno.Enabled = true;
            txtphoneno.Enabled = true;
            //saurabh change
   //         if (hiddendelsau.Value == "1")
    //        {
                btndelete.Enabled = false;
     //       }

        }
        if (show == "0")
        {
            btnsubmit.Enabled = false;

            btndelete.Enabled = false;
            txtcontactperson.Enabled = false;
            txtdesignation.Enabled = false;
            txtdob.Enabled = false;
            txtemailid.Enabled = false;
            txtext.Enabled = false;
            txtfaxno.Enabled = false;
            txtphoneno.Enabled = false;
            hiddendelsau.Value = "0";
            //       }

        }

        if(show == "2")
        {
            btnsubmit.Enabled = true;
          
            btndelete.Enabled = false;
            //btnsubmit.Enabled = true;
            //btndelete.Enabled = true;
            txtcontactperson.Enabled = true;
            txtdesignation.Enabled = true;
            txtdob.Enabled = true;
            txtemailid.Enabled = true;
            txtext.Enabled = true;
            txtfaxno.Enabled = true;
            txtphoneno.Enabled = true;

            hiddendelsau.Value = "1";

        }

      


        if (!Page.IsPostBack)
        {
            hiddencontsau.Value = txtcontactperson.Text;
            if (dk1.Tables.Count > 0 && Session["pubsave"] == null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();

                dk.Clear();
                dk.Dispose();
                dk = new DataSet();

               

            }
           


            if (Session["centcode"] != "")
            {
              
                DataGrid2.Visible = false;
                Divgrid2.Visible = false;
                Divgrid1.Visible = true;
                DataGrid1.Visible = true;
                bindgrid("Cont_Person");
            }
            else
            {
                DataGrid2.Visible = true;
                Divgrid2.Visible = true;
                Divgrid1.Visible = false;
                DataGrid1.Visible = false;

                bindgrid1("Cont_Person");

            }
            if (Session["pubsave"] != null)
            {
                bindgrid1("Cont_Person");
            }
            
            txtcontactperson.Focus();

           
            btnsubmit.Attributes.Add("OnClick", "javascript:return submitcont();");
            //btnselect.Attributes.Add("OnClick", "javascript:return selectcont();");
            btndelete.Attributes.Add("OnCLick", "javascript:return contdelete();");
            txtcontactperson.Attributes.Add("onBlur", "javascript:return UpperCase('txtcontactperson');");
            txtdesignation.Attributes.Add("onBlur", "javascript:return ClientUpperCase('txtdesignation');");
            btnclear.Attributes.Add("OnClick", "javascript:return pcmcontclear();");
//          txtdob.Attributes.Add("OnChange", "javascript:return Checkdate('txtdob');");
            txtdob.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txtemailid.Attributes.Add("OnBlur", "javascript:return ClientEmailCheck1('txtemailid');");
            txtemailid.Attributes.Add("OnKeypress", "javascript:return checkSpace(event);");
            //txtdob.Attributes.Add("OnChange", "javascript:return currentdate();");

           // txtdob.Attributes.Add("OnChange", "javascript:return RetCheckdate(this);");
            // txtdob.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
            //txtdob.Attributes.Add("OnBlur", "javascript:return checkdate(this);");



            txtemcode.Attributes.Add("onkeydown", "javascript:return F2fillempcode(event);");
            lstempcode.Attributes.Add("onkeydown", "javascript:return Clickrempcode_ret(event);");
            lstempcode.Attributes.Add("OnClick", "javascript:return Clickrempcode_ret(event);");

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


    //private void binddata(string sortfield)
    //{


    //    NewAdbooking.Classes.PubCatMast databind = new NewAdbooking.Classes.PubCatMast();
    //    DataSet ds = new DataSet();
    //    ds = databind.pcmcontbind(centcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());


    //    ViewState["SortExpression"] = sortfield;
    //    ViewState["order"] = "ASC";
    //    DataView dv = new DataView();
    //    dv = ds.Tables[0].DefaultView;
    //    dv.Sort = sortfield;
    //    DataGrid1.DataSource = dv;
    //    DataGrid1.DataBind();

    //}

    public void bindgrid(string sortfield)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.PubCatMast databind = new NewAdbooking.Classes.PubCatMast();
        
        ds = databind.pcmcontbind(centcode, Session["compcode"].ToString(), Session["userid"].ToString(), dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast databind = new NewAdbooking.classesoracle.PubCatMast();
            ds = databind.pcmcontbind(centcode, Session["compcode"].ToString(), Session["userid"].ToString(), dateformat);
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast databind = new NewAdbooking.classmysql.PubCatMast();

            ds = databind.pcmcontbind(centcode, Session["compcode"].ToString(), Session["userid"].ToString(), dateformat);

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
    public void submitcontact(string contactperson, string txtdob, string desi, string txtphoneno, string txtext, string txtfaxno, string mail, string centcode, string compcode, string userid, string update, string dateformat)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.PubCatMast contactup = new NewAdbooking.Classes.PubCatMast();
            
            da = contactup.contactupdate(contactperson, txtdob, desi, txtphoneno, txtext, txtfaxno, mail, compcode, userid, centcode, update);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast contactup = new NewAdbooking.classesoracle.PubCatMast();
            da = contactup.contactupdate(contactperson, txtdob, desi, txtphoneno, txtext, txtfaxno, mail, compcode, userid, centcode, update, dateformat);
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast contactup = new NewAdbooking.classmysql.PubCatMast();

            da = contactup.contactupdate(contactperson, txtdob, desi, txtphoneno, txtext, txtfaxno, mail, compcode, userid, centcode, update);

        }


        DataGrid1.DataSource = da;
        DataGrid1.DataBind();
    }


    [Ajax.AjaxMethod]
    public void insertcontact(string contactperson, string txtdob, string txtphoneno, string desi, string txtext, string txtfaxno, string mail, string centcode, string compcode, string userid, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.PubCatMast contactinsert = new NewAdbooking.Classes.PubCatMast();


            ds = contactinsert.insertcontact(contactperson, txtdob, txtphoneno, desi, txtext, txtfaxno, mail, userid, centcode, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast contactinsert = new NewAdbooking.classesoracle.PubCatMast();
            ds = contactinsert.insertcontact(contactperson, txtdob, txtphoneno, desi, txtext, txtfaxno, mail, userid, centcode, compcode, dateformat);
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast contactinsert = new NewAdbooking.classmysql.PubCatMast();


            ds = contactinsert.insertcontact(contactperson, txtdob, txtphoneno, desi, txtext, txtfaxno, mail, userid, centcode, compcode);

        }

        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }


    [Ajax.AjaxMethod]
    public DataSet chkcontact(string contactperson, string centcode, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.PubCatMast chkname = new NewAdbooking.Classes.PubCatMast();
            
            ds = chkname.chkcolor(contactperson, centcode, compcode);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast chkname = new NewAdbooking.classesoracle.PubCatMast();
            ds = chkname.chkcolor(contactperson, centcode, compcode);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast chkname = new NewAdbooking.classmysql.PubCatMast();

            ds = chkname.chkcolor(contactperson, centcode, compcode);
            return ds;
        }
    }



    [Ajax.AjaxMethod]
    public DataSet pcmcontsel(string centcode, string compcode, string userid, string datagrid)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.PubCatMast databind = new NewAdbooking.Classes.PubCatMast();
       


            da = databind.selpcmbind(datagrid, userid, compcode);
            return da;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast databind = new NewAdbooking.classesoracle.PubCatMast();
            da = databind.selpcmbind(datagrid, userid, compcode);
            return da;
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast databind = new NewAdbooking.classmysql.PubCatMast();


            da = databind.selpcmbind(datagrid, userid, compcode);
            return da;
        }


       
    }



    [Ajax.AjaxMethod]
    public void deletecontpcm(string centcode, string compcode, string userid, string update)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.PubCatMast contactdelete = new NewAdbooking.Classes.PubCatMast();
           

            ds = contactdelete.pcmcontdelete(centcode, compcode, userid, update);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast contactdelete = new NewAdbooking.classesoracle.PubCatMast();
            ds = contactdelete.pcmcontdelete(centcode, compcode, userid, update);
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast contactdelete = new NewAdbooking.classmysql.PubCatMast();


            ds = contactdelete.pcmcontdelete(centcode, compcode, userid, update);
        }

        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();

    }


    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        DataView dv = new DataView();

        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  OnClick=\"javascript:return selectcont('" + str + "');\" value=" + e.Item.Cells[8].Text + "  />";
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
                    case "Cont_Person":
                        str = "Contact Person";
                        break;

                    case "Designation":
                        str = "Designation";
                        break;


                    case "DOB":
                        str = "Date Of Birth";
                        break;



                    case "Phone":
                        str = "Phone No.";
                        break;

                    case "Extention":
                        str = "Ext";
                        break;



                    case "Fax":
                        str = "Fax No";
                        break;

                    case "EmailID":
                        str = "Email ID";
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

//to remove the image of sorting                   e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

                }
                else
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+str+"<img  src=\"images\\moveprevious2.gif\" border=0></a>";
//                   e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";

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

            NewAdbooking.Classes.PubCatMast databind = new NewAdbooking.Classes.PubCatMast();
           
            da = databind.pcmcontbind(centcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PubCatMast databind = new NewAdbooking.classesoracle.PubCatMast();
            da = databind.pcmcontbind(centcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.PubCatMast databind = new NewAdbooking.classmysql.PubCatMast();

            da = databind.pcmcontbind(centcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());

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

    protected void btnclose_Click(object sender, EventArgs e)
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
        mycolumn.ColumnName = "Cont_Person";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "DOB";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Designation";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Phone";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Extention";
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


        my_row = mydatatable.NewRow();


        my_row["Cont_Person"] = gbcontperson;
        my_row["DOB"] = gbdob;
        my_row["Designation"] = gbdesignation;
        my_row["Phone"] = gbphone;
        my_row["Extention"] = gbext;
        my_row["Fax"] = gbfax;
        my_row["EmailID"] = gbmailid;
        my_row["Cont_Code"] = "0";
        //gbsecondcycle = txtaddate.Text;

        // mydatatable.Rows.Add(my_row);

        ds_tbl.Tables.Add(mydatatable);

        // mydatatable.ImportRow(my_row);

        if (Session["pubsave"] == null)
        {
            ds_tbl.Tables.Add(mydatatable);
            DataGrid2.DataSource = ds_tbl.Tables[0];
            DataGrid2.DataBind();
        }
        else
        {
            int d;
            int g;
           // dk1.Clear();
            DataSet dsnew = new DataSet();
            dsnew = (DataSet)Session["pubsave"];
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
        gbdesignation = "";
        gbcontperson = "";
        gbphone = "";
        txtcontactperson.Text = "";
        txtdesignation.Text = "";
        txtdob.Text = "";
        txtemailid.Text = "";
        txtext.Text = "";
        txtfaxno.Text = "";
        txtphoneno.Text = "";


    }
    protected void DataGrid2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
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




        if ((dk1.Tables.Count!= 0))
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
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Designation";
            mydatatable1.Columns.Add(mycolumn1);

            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Phone";
            mydatatable1.Columns.Add(mycolumn1);
            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Extention";
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
         
            myrow1 = mydatatable1.NewRow();

            myrow1["Cont_Code"] = "00";


            myrow1["Cont_Person"] = txtcontactperson.Text;
            gbcontperson = txtcontactperson.Text;



            //chkper = chkper + txtcontactperson.Text + ",";
            //chkper1 = chkper.Length.ToString();
            //if (chkper.IndexOf("txtcontactperson.Text") > 0)
            //{
            //    Response.Write("<script>alert('hi')</script>");
            //    return;
            //}
            //int a = Convert.ToInt32(chkper1);
            //if (a > 0)
            //{
            //    Response.Write("<script>alert('hi')</script>");
            //   // return;
            //}
            hiddenDup.Value = hiddenDup.Value + txtcontactperson.Text + ",";


            myrow1["DOB"] = txtdob.Text;
            gbdob = txtdob.Text;
            myrow1["Designation"] = txtdesignation.Text;
            gbdesignation = txtdesignation.Text;
            myrow1["Phone"] = txtphoneno.Text;
            gbphone = txtphoneno.Text;
            myrow1["Extention"] = txtext.Text;
            gbext = txtext.Text;
            myrow1["Fax"] = txtfaxno.Text;
            gbfax = txtfaxno.Text;

            myrow1["EmailID"] = txtemailid.Text;
            gbmailid = txtemailid.Text;


            mydatatable1.Rows.Add(myrow1);

            if (Session["pubsave"] != null)
            {
                DataSet dsNew = new DataSet();
                dsNew = (DataSet)Session["pubsave"];
                dk1 = dsNew;
            }

            dk1.Tables.Add(mydatatable1);

            Session["pubsave"] = dk1;

            bindgrid1("Cont_Person");
        }
        txtcontactperson.Focus();
    }

    private void mbox(string p)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(pcmcontdetails), "ShowAlert", strAlert, true);
    }
    [Ajax.AjaxMethod]
    public DataSet empcodebind(string compcode, string empname)
    {
        
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.BranchMaster name = new NewAdbooking.Classes.BranchMaster();

            ds = name.bindempcode(compcode, empname);
            return ds;
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