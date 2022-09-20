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

public partial class dealmarketstatus : System.Web.UI.Page
{

    string compcode, userid, dateformat, editcode, alias, validco;
    string sortfield;
    string show;
    int j = 0;
    static string gbeditionalias, gbfirstcycle, gbthirdcycle, gbsecondcycle = "";
    DataSet dk1 = new DataSet();
    public static int numberDiv;
    public static string date1 = "";
    public static string year1 = "";
    string hiddentext = "";
    DataRow my_row;
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;
        if (Session["compcode"] != null)
        {

            hiddencompcode.Value = Session["compcode"].ToString();
            compcode = hiddencompcode.Value;
            hiddenuserid.Value = Session["userid"].ToString();
            userid = hiddenuserid.Value;
            hiddendateformat.Value = Session["dateformat"].ToString();
            dateformat = hiddendateformat.Value;
            hiddentext = Request.QueryString["hiddentext"].ToString();
            hiddendealno.Value = Request.QueryString["editioncode"].ToString();
            hiddeneditcode.Value = Request.QueryString["editioncode"].ToString();
            show = Request.QueryString["show"].ToString().Trim();
            htext.Value = Request.QueryString["hiddentext"].ToString().Trim();
            //hiddenperiodicity.Value = Request.QueryString["periodicity1"].ToString();
            //alias = Request.QueryString["alias1"].ToString();
            //hiddenshow.Value = Request.QueryString["show"].ToString();
            //htext.Value = Request.QueryString["htext"].ToString().Trim();
            //validco = Request.QueryString["validationco"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(dealmarketstatus));


        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/DEALMARKETSHARE.xml"));
        lblyear.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbaddate.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        btnsubmit.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        btnclear.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        btndelete.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        btnclose.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();

        btndelete.Enabled = false;


        if (!Page.IsPostBack)
        {
            //gbeditionalias = "";
            //gbfirstcycle = "";
            //gbsecondcycle = "";
            //bindbranch();
            //publicationbind();

            if (show == "1")
            {
                btnsubmit.Enabled = false;

            }
            else if (show == "2")
            {
                btnsubmit.Enabled = true;
                hiddenshow.Value = "1";
            }
            else
            {
                btnsubmit.Enabled = false;
                txtpubcenter.Enabled = false;
                txtpub.Enabled = false;
                txtmarstatus.Enabled = false;
            }

            if (dk1.Tables.Count > 0)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();


            }
            filleditalias(editcode, compcode, userid);
            //if (htext.Value != "mod ")
            //{
            //if ((Session["firstdate"] != null || gbsecondcycle != ""))
            //{
            //    DataGrid2.Visible = true;
            //    divgrid2.Visible = true;
            //    DataGrid1.Visible = false;
            //    divgrid1.Visible = false;
            //    bindgrid1("PUBLICATION");
            //}
            ////}
            //else
            //{
                DataGrid2.Visible = false;
                divgrid2.Visible = false;
                DataGrid1.Visible = true;
                divgrid1.Visible = true;
                bindgrid("PUBLICATION");
            //}
            btnsubmit.Attributes.Add("OnClick", "javascript:return submitclick();");
            //txtdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            //txtaddate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            btndelete.Attributes.Add("OnClick", "javascript:return deletegridclick();");
            btnclear.Attributes.Add("OnClick", "javascript:return clearclick();");
            txtpubcenter.Attributes.Add("onkeydown", "javascript:return fillpubcent(event);");
            txtpubcenter.Attributes.Add("onkeypress", "javascript:return fillpubcent(event);");

            lstpubcent.Attributes.Add("onclick", "javascript:return fillpubcenter(event);");
            lstpubcent.Attributes.Add("onkeydown", "javascript:return fillpubcenter(event);");

            txtpub.Attributes.Add("onkeydown", "javascript:return fillpub(event);");
            txtpub.Attributes.Add("onkeypress", "javascript:return fillpub(event);");

            lstpub.Attributes.Add("onclick", "javascript:return fillpublication(event);");
            lstpub.Attributes.Add("onkeydown", "javascript:return fillpublication(event);");
            //btnclear.Attributes.Add("OnClick","javascript:return clearclick();");
        }
        if (validco == "2 ")
        {
            lbaddate.Attributes.Add("style", "display:none");
            txtpubcenter.Attributes.Add("style", "display:none");
            lblyear.Attributes.Add("style", "display:none");
            txtmarstatus.Attributes.Add("style", "display:none");

        }

        if (validco == "4 ")
        {

            lblyear.Attributes.Add("style", "display:none");
            txtmarstatus.Attributes.Add("style", "display:none");

        }

        if (validco == "3 " || validco == "6 " || validco == "7 ")
        {
            lbaddate.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            lblyear.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();

            txtpub.Text = "";
            txtpubcenter.Text = "";
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/popupedit.xml"));

            
            DataView dv = ds1.Tables["date"].DefaultView;
            DataView dv1 = ds1.Tables["year"].DefaultView;

            //dv.Sort = "ID";
            //txtpub.DataTextField = "Name";
            //txtpub.DataValueField = "ID";
            //txtpub.DataSource = dv;
            //txtpub.DataBind();


            //txtpubcenter.DataTextField = "name1";
            //txtpubcenter.DataValueField = "id1";
            //txtpubcenter.DataSource = dv1;
            //txtpubcenter.DataBind();






        }

    }

    public void bindgrid(string sortfield)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bind = new NewAdbooking.Classes.Contract();

            //ds = databind.dealshare(hiddeneditcode.Value, Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract databind = new NewAdbooking.classesoracle.Contract();
            ds = databind.dealshare(hiddeneditcode.Value, Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.Contract bind = new NewAdbooking.classmysql.Contract();
            ds = bind.dealshare(hiddeneditcode.Value, Session["compcode"].ToString(), Session["userid"].ToString());

            //NewAdbooking.classmysql.Contract bind = new NewAdbooking.classmysql.Contract();
            //ds = chkcontractdetail.dealshare(hiddeneditcode.Value, Session["compcode"].ToString(), Session["userid"].ToString());

            //NewAdbooking.classmysql.EditorMaster bind = new NewAdbooking.classmysql.EditorMaster();
            //ds = bind.ratebind(editcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
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
        DataGrid2.Visible = true;
        divgrid2.Visible = true;
        DataGrid1.Visible = false;
        divgrid1.Visible = false;

        DataSet ds_tbl = new DataSet();


        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "COMP_CODE";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "DEAL_NO";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "PUBLICATION";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "PUBCENTER";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "MARKET_STATUS";
        mydatatable.Columns.Add(mycolumn);



        



        my_row = mydatatable.NewRow();
        //if (Session["firstdate"] != "" && Session["firstdate"] != null)
        //{
        //    gbeditionalias = txteditionname.Text;

        //    gbfirstcycle = Session["firstdate"].ToString();

        //    gbsecondcycle = Session["seconddate"].ToString();

        //    gbthirdcycle = Session["thirdyear"].ToString();



        //    my_row["editdate_code"] = "0";
        //    my_row["COMP_CODE"] = "0";

        //    my_row["PUBLICATION"] = gbeditionalias;
        //    my_row["PUBCENTER"] = gbfirstcycle;
        //    my_row["MARKET_STATUS"] = gbsecondcycle;
        //    //my_row["Year"] = gbthirdcycle;



        //}

        //else
        //{
            //my_row["editdate_code"] = "0";
            //my_row["COMP_CODE"] = "0";

            my_row["PUBLICATION"] = gbeditionalias;
            my_row["PUBCENTER"] = gbfirstcycle;
            my_row["MARKET_STATUS"] = gbsecondcycle;


        //}

        mydatatable.Rows.Add(my_row);

        ds_tbl.Tables.Add(mydatatable);




        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();

        dv = ds_tbl.Tables[0].DefaultView;
        DataGrid2.DataSource = dv;
        DataGrid2.DataBind();
        gbeditionalias = "";
        gbfirstcycle = "";
        gbsecondcycle = "";
        gbthirdcycle = "";
    }





    public void filleditalias(string editcode, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.EditorMaster filltxtalias = new NewAdbooking.Classes.EditorMaster();

            txteditionname.Text = alias;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.EditorMaster filltxtalias = new NewAdbooking.classesoracle.EditorMaster();
            //txteditionname.Text = alias;
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster filltxtalias = new NewAdbooking.classmysql.EditorMaster();
            txteditionname.Text = alias;
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
        this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound_1);
        this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.abc);

    }
    #endregion




    [Ajax.AjaxMethod]

    public void insert(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string year)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract insertgrid = new NewAdbooking.Classes.Contract();

            ds = insertgrid.inserteditname(txteditionname, txtdate, txtaddate, compcode, userid, editcode, year);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract insertgrid = new NewAdbooking.classesoracle.Contract();
            ds = insertgrid.inserteditname(txteditionname, txtdate, txtaddate, compcode, userid, editcode, year);
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster insertgrid = new NewAdbooking.classmysql.EditorMaster();
            ds = insertgrid.inserteditname(txteditionname, txtdate, txtaddate, compcode, userid, editcode);
        }
        //  Session["firstdate"] = null;
        // Session["seconddate"] = null;

        //if (htext.Value == "mod ")
        //{
        //    bindgrid("Edition_Alias");

        //}


    }





    private void hiddencurrcode_ServerChange(object sender, System.EventArgs e)
    {

    }

    [Ajax.AjaxMethod]

    public DataSet selected(string editcode, string compcode, string userid, string code10)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract selectgrid = new NewAdbooking.Classes.Contract();

            ds = selectgrid.selectedfromgrid(editcode, compcode, userid, code10);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract selectgrid = new NewAdbooking.classesoracle.Contract();
            ds = selectgrid.selectedfromgrid(editcode, compcode, userid, code10);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster selectgrid = new NewAdbooking.classmysql.EditorMaster();

            ds = selectgrid.selectedfromgrid(editcode, compcode, userid, code10);

            return ds;
        }


    }

    [Ajax.AjaxMethod]

    public void update(string compcode,string editcode, string txteditionname, string txtdate, string txtaddate)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract updategrid = new NewAdbooking.Classes.Contract();

            ds = updategrid.gridupdate(txteditionname, txtdate, txtaddate, compcode, editcode);
            //Session["firstdate"] = null;
            //Session["seconddate"] = null;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract updategrid = new NewAdbooking.classesoracle.Contract();
            ds = updategrid.gridupdate(txteditionname, txtdate, txtaddate, compcode, editcode);
            //Session["firstdate"] = null;
            //Session["seconddate"] = null;
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster updategrid = new NewAdbooking.classmysql.EditorMaster();
            //ds = updategrid.gridupdate(txteditionname, txtdate, txtaddate, compcode, userid, editcode, code10);
            //Session["firstdate"] = null;
            //Session["seconddate"] = null;
        }

    }

    [Ajax.AjaxMethod]

    public void deletegrid(string editcode, string compcode, string userid, string code10)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract delete = new NewAdbooking.Classes.Contract();

            ds = delete.griddelete(compcode, editcode, userid, code10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract delete = new NewAdbooking.classesoracle.Contract();
            ds = delete.griddelete(compcode,editcode, userid, code10);
        }
        else
        {
            NewAdbooking.classmysql.Contract delete = new NewAdbooking.classmysql.Contract();
            //ds = delete.griddelete(editcode, compcode, userid, code10);
        }

    }

    [Ajax.AjaxMethod]

    public DataSet chkinsert(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract chkdate = new NewAdbooking.Classes.Contract();

            ds = chkdate.chkdaetdeal(txteditionname, txtdate);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract chkdate = new NewAdbooking.classesoracle.Contract();
            ds = chkdate.chkdaetdeal(txteditionname, txtdate);

            return ds;
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster chkdate = new NewAdbooking.classmysql.EditorMaster();
            ds = chkdate.chkdaetedit(compcode, editcode);
            return ds;
        }


    }

    [Ajax.AjaxMethod]

    public DataSet chkupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string code10)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.EditorMaster chkdateup = new NewAdbooking.Classes.EditorMaster();

            ds = chkdateup.chkdateupdate(txteditionname, txtdate, txtaddate, compcode, userid, editcode, code10);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.EditorMaster chkdateup = new NewAdbooking.classesoracle.EditorMaster();

            ds = chkdateup.chkdateupdate(txteditionname, txtdate, txtaddate, compcode, userid, editcode, code10);

            return ds;
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster chkdateup = new NewAdbooking.classmysql.EditorMaster();
            ds = chkdateup.chkdateupdate(txteditionname, txtdate, txtaddate, compcode, userid, editcode, code10);
            return ds;
        }


    }

    [Ajax.AjaxMethod]

    public DataSet chkperiodicty(string periodicty)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.EditorMaster chkperiodicty = new NewAdbooking.Classes.EditorMaster();

            ds = chkperiodicty.chkperiodicty(periodicty, "foredition", "", "", "");
            //ds = chkperiodicty.chkperiodicty(periodicty);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.EditorMaster chkperiodicty = new NewAdbooking.classesoracle.EditorMaster();
            ds = chkperiodicty.chkperiodicty(periodicty, "foredition", "", "", "");

            return ds;
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster chkperiodicty = new NewAdbooking.classmysql.EditorMaster();
            ds = chkperiodicty.chkperiodicty(periodicty);
            return ds;
        }


    }

    protected void hiddendateformat_ServerChange(object sender, System.EventArgs e)
    {

    }

    private void DataGrid1_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        DataView dv = new DataView();

        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  OnClick=\"javascript:return selectclick('" + str + "');\" value=" + e.Item.Cells[1].Text + "  />";
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


                    case "PUBLICATION":
                        str = "PUBLICATION";
                        break;

                    case "PUBCENTER":
                        str = "PUBCENTER";
                        break;

                    case "MARKET_STATUS":
                        str = "MARKET_STATUS";
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


    private void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract databind = new NewAdbooking.Classes.Contract();


            ds = databind.dealshare(hiddeneditcode.Value, Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract databind = new NewAdbooking.classesoracle.Contract();
            ds = databind.dealshare(hiddeneditcode.Value, Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.EditorMaster databind = new NewAdbooking.classmysql.EditorMaster();
            ds = databind.ratebind(editcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
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


    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>");
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        //DataColumn mycolumn;
        //DataTable mydatatable = new DataTable();
        //DataRow myrow;
        //mycolumn = new DataColumn();
        //mycolumn.DataType = System.Type.GetType("System.String");
        //mycolumn.ColumnName = "EditionName";
        //mydatatable.Columns.Add(mycolumn);

        //// //DataColumn mycolumn;
        //mycolumn = new DataColumn();
        //mycolumn.DataType = System.Type.GetType("System.String");
        //mycolumn.ColumnName = "Date";
        //mydatatable.Columns.Add(mycolumn);

        //////DataColumn mycolumn;
        //mycolumn = new DataColumn();
        //mycolumn.DataType = System.Type.GetType("System.String");
        //mycolumn.ColumnName = "AdditionalDate";
        //mydatatable.Columns.Add(mycolumn);

        //myrow = mydatatable.NewRow();
        //myrow["EditionName"] = txteditionname.Text;
        //myrow["Date"] = txtdate.Text;
        //myrow["AdditionalDate"] = txtaddate.Text;

    }
    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        //string sd = "hello";



        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "PUBLICATION";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "PUBCENTER";
        mydatatable1.Columns.Add(mycolumn1);


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "MARKET_STATUS";
        mydatatable1.Columns.Add(mycolumn1);


        //mycolumn1 = new DataColumn();
        //mycolumn1.DataType = System.Type.GetType("System.String");
        //mycolumn1.ColumnName = "secondcycle";
        //mydatatable1.Columns.Add(mycolumn1);



        //mycolumn1 = new DataColumn();
        //mycolumn1.DataType = System.Type.GetType("System.String");
        //mycolumn1.ColumnName = "thirdyear";
        //mydatatable1.Columns.Add(mycolumn1);











        myrow1 = mydatatable1.NewRow();

        myrow1["PUBLICATION"] = "00";


        myrow1["PUBCENTER"] = txteditionname.Text;
        gbeditionalias = txteditionname.Text;

        //myrow1["MARKET_STATUS"] = Session["MARKET_STATUS"].ToString();
        //gbfirstcycle = Session["MARKET_STATUS"].ToString();




        //myrow1["secondcycle"] = Session["seconddate"].ToString();
        //gbsecondcycle = Session["seconddate"].ToString();


        //myrow1["thirdyear"] = Session["thirdyear"].ToString();
        //gbthirdcycle = Session["thirdyear"].ToString();



        mydatatable1.Rows.Add(myrow1);

        dk1.Tables.Add(mydatatable1);



        bindgrid1("PUBLICATION");



    }


    //[Ajax.AjaxMethod]

    //public DataSet year(string year, string compcode)
    //{

    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        //   NewAdbooking.Classes.EditorMaster chkdate = new NewAdbooking.Classes.EditorMaster();

    //        // ds = chkdate.chkyear(Session["compcode"].ToString(), edition);
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.EditorMaster chkdate = new NewAdbooking.classesoracle.EditorMaster();

    //        ds = chkdate.chkyear(year, Session["compcode"].ToString());
    //    }

    //    return ds;
    //}



    [Ajax.AjaxMethod]

    public DataSet year2(string year, string compcode, string txteditionname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //    NewAdbooking.Classes.EditorMaster chkperiodicty = new NewAdbooking.Classes.EditorMaster();

            //   ds = chkperiodicty.chkperiodicty(periodicty, "foredition", "", "", "");

            // return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.EditorMaster chkdate = new NewAdbooking.classesoracle.EditorMaster();

            //ds = chkdate.chkyear(year, compcode, txteditionname);

        }

        return ds;

    }




    protected void DataGrid2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataView dv = new DataView();
        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;
    }

    //public void bindbranch()
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {

    //        NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = pub.adbranch(Session["compcode"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
    //        ds = pub.adbranch(Session["compcode"].ToString());
    //    }
    //    ListItem li = new ListItem();
    //    li.Value = "0";
    //    li.Text = "Select Branch";
    //    li.Selected = true;
    //    txtpub.Items.Add(li);



    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li1 = new ListItem();
    //        li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        txtpub.Items.Add(li1);
    //    }
    //    txtpub.SelectedValue = Session["revenue"].ToString();
    //}

    //public void publicationbind()
    //{
    //    DataSet ds = new DataSet();

    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {

    //        NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), "");
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
    //        ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
    //    }
    //    int i;
    //    ListItem li;
    //    li = new ListItem();
    //    txtpubcenter.Items.Clear();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
    //    // li.Text = "-Select Publication Center-";
    //    li.Value = "0";
    //    li.Selected = true;
    //    txtpubcenter.Items.Add(li);


    //    if (ds.Tables.Count > 0)
    //    {
    //        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            ListItem li1;
    //            li1 = new ListItem();
    //            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //            txtpubcenter.Items.Add(li1);
    //        }
    //    }

    //    txtpubcenter.SelectedValue = Session["center"].ToString();
    //}

    [Ajax.AjaxMethod]
    public DataSet fill_pubcent(string compcode, string mcatcode, string dateformat, string extra1, string extra2)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.Contract databind = new NewAdbooking.classesoracle.Contract();
            ds = databind.pub_centbind(compcode, mcatcode, extra1);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract databind = new NewAdbooking.Classes.Contract();
            ds = databind.pub_centbind(compcode, mcatcode, extra1);
        }
        else
        {
            NewAdbooking.classmysql.Contract databind = new NewAdbooking.classmysql.Contract();
            ds = databind.pub_centbind(compcode, mcatcode, extra1,"");

        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet fill_pub(string compcode, string mcatcode, string dateformat, string extra1, string extra2)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.Contract databind = new NewAdbooking.classesoracle.Contract();
            ds = databind.publication(compcode, mcatcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract databind = new NewAdbooking.Classes.Contract();
            ds = databind.publication(compcode, mcatcode);
          
        }
        else
        {
            NewAdbooking.classmysql.Contract databind = new NewAdbooking.classmysql.Contract();
            ds = databind.publication(compcode, mcatcode);

        }
        return ds;
    }


}



