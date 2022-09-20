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

public partial class categorywiseedition : System.Web.UI.Page
{
    string adcatcode, compcode, userid;
    string show, sortfield;
    static DataSet dk1 = new DataSet();
    static DataSet dk = new DataSet();
    static string gbedition = "", gbsun = "", gbmon = "", gbtue = "", gbwed = "", gbthu = "", gbfri = "", gbsat = "", gball = "",gbeditionname="";
    int j = 0;
    // string compcode, userid, ;
    //string sortfield;
    public static int flag = 0;
    public static int numberDiv;
    string chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8;
    DataRow my_row;

    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;

        adcatcode = Request.QueryString["txtadvcatcode"].ToString();

        //edition = Request.QueryString["txtadvcatcode"].ToString();

        hiddenadcatcode.Value = adcatcode;
        Session["centcode"] = adcatcode;

        compcode = Session["compcode"].ToString();
        hiddencomcode.Value = compcode;

        userid = Session["userid"].ToString();
        hiddenuserid.Value = userid;

        show = Request.QueryString["show"].ToString();
        hiddenshow.Value = show;

        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
            //compcode = hiddencompcode.Value;
            //userid = hiddenuserid.Value;

        }
        Ajax.Utility.RegisterTypeForAjax(typeof(categorywiseedition));


       // bindedition(compcode, userid);//,edition);

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/CategoryWiseEdition.xml"));
        lbeditionname.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbeditionday.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        btnsubmit1.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        btnclear1.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        btnclose1.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        btndelete1.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();

        if (hiddenadcatcode.Value == "" || hiddenadcatcode.Value == null)
        {
            Response.Write("<script> alert('Please Enter AdCategory Code First');window.close(); </script>");
        }

        //  checkbox();

        if (show == "1")
        {

            btnsubmit1.Enabled = true;
            drpednname.Enabled = true;
            //txtfrom.Enabled = true;
            //txtcircularno.Enabled = true;
            //drpstatus.Enabled = true;
            btndelete1.Enabled = false;
           // hiddendelsau.Value = "0";

        }
        if (show == "0")
        {

            btndelete1.Enabled = false;
            //   txtcontactperson.Enabled = false;
            btnsubmit1.Enabled = false;
            drpednname.Enabled = false;
            
            //hiddendelsau.Value = "0";

        }

        if (show == "2")
        {
            btnsubmit1.Enabled = true;

            btndelete1.Enabled = true;
            //btnsubmit.Enabled = true;
            //btndelete.Enabled = true;
            drpednname.Enabled = true;
            //DataGrid2.DataBind();
            //hiddendelsau.Value = "1";

        }

        if (drpednname.Enabled==true)
        {
            drpednname.Focus();
        }
        //if (show == "1" || show == "2")
        //{
        //    btnsubmit1.Enabled = false;
        //    btndelete1.Enabled = false;
        //    drpednname.Enabled = false;

        //}
        //else
        //{
        //    btnsubmit1.Enabled = true;
        //    btndelete1.Enabled = true;
        //    drpednname.Enabled = true;

        //}
        //if (show == "0")
        //{
        //    btndelete1.Enabled = false;
        //}
        //if (show == "1")
        //{
        //    btnsubmit1.Enabled = true;
        //    drpednname.Enabled = true;

        //    btndelete1.Enabled = false;

        //}
        //if (show == "0")
        //{
        //    btndelete1.Enabled = false;
        //    txtcontactperson.Enabled = false;
        //    btnsubmit1.Enabled = false;
        //    drpednname.Enabled = false;


        //}

        //if (show == "2")
        //{
        //    btnsubmit1.Enabled = true;

        //    btndelete1.Enabled = false;
        //    btnsubmit.Enabled = true;
        //    btndelete.Enabled = true;
        //    drpednname.Enabled = true;



        //}

      //  hiddenedition.Value = drpednname.SelectedItem.Value;
        
        if (!Page.IsPostBack)
        {
            bindedition(compcode, userid);
            if (dk1.Tables.Count > 0 && (Session["editionsave"] == "" || Session["editionsave"] == null))
            {

                dk.Clear();
                dk.Dispose();
                dk = new DataSet();

                //dk.Clear();
                //dk.Dispose();
                dk1 = new DataSet();

            }

            //if (Session["centcode"] != "")
            //    if (hiddencentcode.Value != "")
            //    {
            //        DataGrid2.Visible = false;
            //        Divgrid2.Visible = false;
            //        Divgrid1.Visible = true;
            //        DataGrid1.Visible = true;
            //        bindgrid("Edcode");
            //    }
            //    else
            //    {
            //        DataGrid2.Visible = true;
            //        Divgrid2.Visible = true;
            //        Divgrid1.Visible = false;
            //        DataGrid1.Visible = false;
            //        bindgrid1("Edcode");

            //}

            
            if (Session["editionsave"] != null)
            {
                bindgrid1("Edcode");
            }
            else
            {
                bindgrid("Edcode");
            }

           
            //addatagrid();

            btnsubmit1.Attributes.Add("OnClick", "javascript:return submitcat();");
            btndelete1.Attributes.Add("OnCLick", "javascript:return editiondelete();");
            btnclear1.Attributes.Add("OnClick", "javascript:return popclear();");
            btnclose1.Attributes.Add("OnClick", "javascript:return close1();");

            CheckBox8.Attributes.Add("OnClick", "javascript:return checkedunchecked1('CheckBox8');");
            CheckBox1.Attributes.Add("OnClick", "javascript:return fillchk_chkbox1();");
            CheckBox2.Attributes.Add("OnClick", "javascript:return fillchk_chkbox1();");
            CheckBox3.Attributes.Add("OnClick", "javascript:return fillchk_chkbox1();");
            CheckBox4.Attributes.Add("OnClick", "javascript:return fillchk_chkbox1();");
            CheckBox5.Attributes.Add("OnClick", "javascript:return fillchk_chkbox1();");
            CheckBox6.Attributes.Add("OnClick", "javascript:return fillchk_chkbox1();");
            CheckBox7.Attributes.Add("OnClick", "javascript:return fillchk_chkbox1();");

            drpednname.Attributes.Add("OnChange", "javascript:return editionday();");


        }

    }

    //private void binddata(string sortfield)
    //{
    //    NewAdbooking.Classes.AdCategoryMaster databind = new NewAdbooking.Classes.AdCategoryMaster();
    //    DataSet ds = new DataSet();
    //    ds = databind.catwiesedition(adcatcode, Session["userid"].ToString(), Session["compcode"].ToString());//, Session["dateformat"].ToString());


    //    //ViewState["SortExpression"] = sortfield;
    //    //ViewState["order"] = "ASC";
    //    DataView dv = new DataView();
    //    dv = ds.Tables[0].DefaultView;
    //    dv.Sort = sortfield;
    //    DataGrid1.DataSource = dv;
    //    DataGrid1.DataBind();

    //}


    private void bindgrid(string sortfield)
    {
        //hiddenedition.Value = drp;

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString()== "sql")
        {
            NewAdbooking.Classes.AdCategoryMaster databind = new NewAdbooking.Classes.AdCategoryMaster();

            ds = databind.catwiesedition(adcatcode, Session["userid"].ToString(), Session["compcode"].ToString());//, Session["dateformat"].ToString());
        }
        else if(ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCategoryMaster databind = new NewAdbooking.classesoracle.AdCategoryMaster();
            ds = databind.catwiesedition(adcatcode, Session["userid"].ToString(), Session["compcode"].ToString());//, Session["dateformat"].ToString());

        }
         else
        {
            NewAdbooking.classmysql.AdCategoryMaster databind = new NewAdbooking.classmysql.AdCategoryMaster();
            ds = databind.catwiesedition(adcatcode, Session["userid"].ToString(), Session["compcode"].ToString());
        }

           
            ViewState["SortExpression"] = sortfield;
            ViewState["order"] = "ASC";
            DataView dv = new DataView();
            dv = ds.Tables[0].DefaultView;
            dv.Sort = sortfield;
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
       
       
    }

    public void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdCategoryMaster databind = new NewAdbooking.Classes.AdCategoryMaster();

            ds = databind.catwiesedition(adcatcode, Session["userid"].ToString(), Session["compcode"].ToString());//, Session["dateformat"].ToString());

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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCategoryMaster databind = new NewAdbooking.classesoracle.AdCategoryMaster();
            ds = databind.catwiesedition(adcatcode, Session["userid"].ToString(), Session["compcode"].ToString());//, Session["dateformat"].ToString());

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
        else
        {
            NewAdbooking.classmysql.AdCategoryMaster databind = new NewAdbooking.classmysql.AdCategoryMaster();
            ds = databind.catwiesedition(adcatcode, Session["userid"].ToString(), Session["compcode"].ToString());//, Session["dateformat"].ToString());

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

        // this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion

    //Bind The Drop Down//
    public void bindedition(string compcode, string userid)//,string edition)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdCategoryMaster editionselect = new NewAdbooking.Classes.AdCategoryMaster();

            ds = editionselect.selectedition(compcode, userid);//,edition);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCategoryMaster editionselect = new NewAdbooking.classesoracle.AdCategoryMaster();
            ds = editionselect.selectedition(compcode, userid);
        }
        else
        {

            NewAdbooking.classmysql.AdCategoryMaster editionselect = new NewAdbooking.classmysql.AdCategoryMaster();

            ds = editionselect.selectedition(compcode, userid);
        }
            drpednname.Items.Clear();
            ListItem li1 = new ListItem();
            li1.Text = "---Select Edition---";

            li1.Value = "0";
            li1.Selected = true;
            drpednname.Items.Add(li1);
            int i;
            for (i = 0; i < ds.Tables[0].Rows.Count ; i++)
            {
                ListItem li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                drpednname.Items.Add(li);
            }
        }
       


    //DataGrid Bind//
    //public void addatagrid(string sortfield)
    //{
    //    NewAdbooking.Classes.AdCategoryMaster datagridbind = new NewAdbooking.Classes.AdCategoryMaster();
    //    DataSet da = new DataSet();
    //    da = datagridbind.editionbindgrid(Session["compcode"].ToString(), Session["userid"].ToString());
    //    DataGrid1.DataSource = da;
    //    DataGrid1.DataBind();

    //    //ViewState["SortExpression"] = sortfield;
    //    //ViewState["order"] = "ASC";
    //    //DataView dv = new DataView();
    //    //dv = da.Tables[0].DefaultView;
    //    //dv.Sort = sortfield;

    //    //DataGrid1.DataSource = dv;
    //    //DataGrid1.DataBind();
    //}

    //Check the EditionCode//
    [Ajax.AjaxMethod]
    //		public DataSet advcatchk(string compcode,string userid,string adcatcode)
    public DataSet editionchk(string compcode, string userid, string edition)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdCategoryMaster chk = new NewAdbooking.Classes.AdCategoryMaster();

            ds = chk.editionchk(compcode, userid, edition);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCategoryMaster chk = new NewAdbooking.classesoracle.AdCategoryMaster();
            ds = chk.editionchk(compcode, userid, edition);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.AdCategoryMaster chk = new NewAdbooking.classmysql.AdCategoryMaster();
            ds = chk.editionchk(compcode, userid, edition);
            return ds;
        }


    }
    //Save Function//
    [Ajax.AjaxMethod]
    public DataSet submit1(string compcode, string userid, string adcatcode, string edition, string chk1, string chk2, string chk3, string chk4, string chk5, string chk6, string chk7, string chk8)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdCategoryMaster edsubmit = new NewAdbooking.Classes.AdCategoryMaster();

            ds = edsubmit.editionsubmit(compcode, userid, adcatcode, edition, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCategoryMaster edsubmit = new NewAdbooking.classesoracle.AdCategoryMaster();
            ds = edsubmit.editionsubmit(compcode, userid, adcatcode, edition, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.AdCategoryMaster edsubmit = new NewAdbooking.classmysql.AdCategoryMaster();
            ds = edsubmit.editionsubmit(compcode, userid, adcatcode, edition, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8);
            return ds;
        }


    }

    //Select The Row From the Data Grid/My/
    [Ajax.AjaxMethod]
    public DataSet editionsel(string adcatcode, string compcode, string userid, string code10)//, string datagrid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdCategoryMaster databind = new NewAdbooking.Classes.AdCategoryMaster();

            ds = databind.seledition(adcatcode, userid, compcode, code10);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCategoryMaster databind = new NewAdbooking.classesoracle.AdCategoryMaster();
            ds = databind.seledition(adcatcode, userid, compcode, code10);
            return ds;
        }

        else
        {
            NewAdbooking.classmysql.AdCategoryMaster databind = new NewAdbooking.classmysql.AdCategoryMaster();
            ds = databind.seledition(adcatcode, userid, compcode, code10);
            return ds;
        }
    }

    //Modify//
    [Ajax.AjaxMethod]
    public DataSet modify1(string compcode, string userid, string adcatcode, string edition, string chk1, string chk2, string chk3, string chk4, string chk5, string chk6, string chk7, string chk8, string hiddenccode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdCategoryMaster edsubmit = new NewAdbooking.Classes.AdCategoryMaster();

            ds = edsubmit.editionmodify(compcode, userid, adcatcode, edition, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, hiddenccode);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCategoryMaster edsubmit = new NewAdbooking.classesoracle.AdCategoryMaster();
            ds = edsubmit.editionmodify(compcode, userid, adcatcode, edition, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, hiddenccode);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.AdCategoryMaster edsubmit = new NewAdbooking.classmysql.AdCategoryMaster();
            ds = edsubmit.editionmodify(compcode, userid, adcatcode, edition, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, hiddenccode);
            return ds;
        }


    }

    //Delete the data//
    [Ajax.AjaxMethod]
    public DataSet delete1(string compcode, string userid, string edition, string hiddenccode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdCategoryMaster eddelete = new NewAdbooking.Classes.AdCategoryMaster();

            ds = eddelete.editiondelete(compcode, userid, edition, hiddenccode);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCategoryMaster eddelete = new NewAdbooking.classesoracle.AdCategoryMaster();
            ds = eddelete.editiondelete(compcode, userid, edition, hiddenccode);
            return ds;
        }

        else
        {
            NewAdbooking.classmysql.AdCategoryMaster eddelete = new NewAdbooking.classmysql.AdCategoryMaster();
            ds = eddelete.editiondelete(compcode, userid, edition, hiddenccode);
            return ds;
        }

    }
    [Ajax.AjaxMethod]
    public DataSet editionday(string drpednname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdCategoryMaster editday = new NewAdbooking.Classes.AdCategoryMaster();

            ds = editday.editionday(drpednname);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCategoryMaster editday = new NewAdbooking.classesoracle.AdCategoryMaster();
            ds = editday.editionday(drpednname);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.AdCategoryMaster editday = new NewAdbooking.classmysql.AdCategoryMaster();
            ds = editday.editionday(drpednname);
            return ds;
        }

    }

    //Close Button//
    protected void btnclose1_Click(object sender, EventArgs e)
    {
        //Response.Write("<script>window.close();</script>");
    }

    //DataGrid Bind//
    protected void DataGrid1_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {

        DataView dv = new DataView();
        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;

        //  //This line was commented beforeit
        //  NewAdbooking.Classes.AdCategoryMaster datagridbind = new NewAdbooking.Classes.AdCategoryMaster();
        //  DataSet da = new DataSet();
        //  da = datagridbind.editionbindgrid(Session["compcode"].ToString(), Session["userid"].ToString());//, e.Item.Cells[1].Text);
        ////End//
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (e.Item.Cells[12].Text == "Y")
            {
                e.Item.Cells[2].Text = "<input type='checkbox'width='7px' id=a" + j + " checked='checked' disabled='disabled'/>";

            }
            else
            {
                e.Item.Cells[2].Text = "<input type='checkbox' width='7px' id=a" + j + " disabled='disabled'/>";
            }
            if (e.Item.Cells[13].Text == "Y")
            {
                e.Item.Cells[3].Text = "<input type='checkbox' width='7px' id=b" + j + " checked='checked' disabled='disabled'/>";

            }
            else
            {
                e.Item.Cells[3].Text = "<input type='checkbox'  width='7px' id=b" + j + " disabled='disabled'  />";
            }
            if (e.Item.Cells[14].Text == "Y")
            {
                e.Item.Cells[4].Text = "<input type='checkbox' width='7px' id=c" + j + " checked='checked' disabled='disabled' />";

            }
            else
            {
                e.Item.Cells[4].Text = "<input type='checkbox' width='7px' id=c" + j + " disabled='disabled' />";
            }
            if (e.Item.Cells[15].Text == "Y")
            {
                e.Item.Cells[5].Text = "<input type='checkbox' width='7px'  id=d" + j + " checked='checked' disabled='disabled'/>";

            }
            else
            {
                e.Item.Cells[5].Text = "<input type='checkbox' width='7px' id=d" + j + " disabled='disabled' />";
            }
            if (e.Item.Cells[16].Text == "Y")
            {
                e.Item.Cells[6].Text = "<input type='checkbox' width='7px' id=e" + j + " checked='checked' disabled='disabled'/>";

            }
            else
            {
                e.Item.Cells[6].Text = "<input type='checkbox' width='7px' id=e" + j + " disabled='disabled' />";
            }

            if (e.Item.Cells[17].Text == "Y")
            {
                e.Item.Cells[7].Text = "<input type='checkbox' width='7px' id=f" + j + " checked='checked' disabled='disabled' />";

            }
            else
            {
                e.Item.Cells[7].Text = "<input type='checkbox' width='7px' id=f" + j + " disabled='disabled'  />";
            }
            if (e.Item.Cells[18].Text == "Y")
            {
                e.Item.Cells[8].Text = "<input type='checkbox' width='7px' id=g" + j + " checked='checked' disabled='disabled' />";

            }
            else
            {
                e.Item.Cells[8].Text = "<input type='checkbox' width='7px' id=g" + j + " disabled='disabled' />";
            }

            e.Item.Cells[9].Text = "<input type='checkbox'width='7px' id=h" + j + " ssssss disabled='disabled'/>";

            string str = "DataGrid1__ctl_CheckBox1" + j;
             //string str = "DataGrid1";
            //string str = "e.Item.Cells[0].Text";
           e.Item.Cells[0].Text = "<input type='checkbox' width='7px' id= " + str + " OnClick=\"javascript:return editionsubmit12('" + str + "','" + e.Item.Cells[20].Text + "');\"  value=" + e.Item.Cells[20].Text + "  />";
           j++;
            //string str = "DataGrid1__ctl_CheckBox1" + j;
            //// string str = "DataGrid1";
            //string str = "e.Item.Cells[0].Text";
           // e.Item.Cells[0].Text = "<input type='checkbox' id= " + str + " OnClick=\"javascript:return editionsubmit12('" + e.Item.Cells[1].Text + "','" + e.Item.ItemIndex + "');\"  value=" + e.Item.Cells[1].Text + "  />";
            //j++;

        }
        if (e.Item.ItemType == ListItemType.Header)
        {
            if (ViewState["SortExpression"].ToString() != "")
            {
                string str = "";
                switch (ViewState["SortExpression"].ToString())
                {
                    case "Edcode":
                        str = "Edition Name";
                        break;


                }
                string strd = Convert.ToString(dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
                strd = Convert.ToString(Convert.ToInt32(strd) - 1);
                if (strd.Length < 2)
                    strd = "0" + strd;
                if (ViewState["order"].ToString() == "DESC")
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                    //$ctl01$ctl00

                   //  e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

                }
                else
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+str+"<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                   //  e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                }
            }
        }

    }
    protected void btnsubmit1_Click(object sender, EventArgs e)
    {
        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;
        // DataRow myrow1;

//******************************som********************************//

        string message;


        if ((dk1.Tables.Count > 1))
        {
            int cou = dk1.Tables.Count;
            int j;
            for (j = 0; j < cou; j++) //for (j = 0; j < dk1.Tables[0].Rows.Count; j++)
            {
                if (drpednname.SelectedValue == dk1.Tables[j].Rows[0].ItemArray[1].ToString())
                {
                    message = "Edition has been submitted already";
                    AspNetMessageBox(message);
                    flag = 1;
                    return;

                }
                else
                {
                    flag = 0;
                }

            }

        }
        else if (dk1.Tables.Count !=0)
        {
            
            int j;
            for (j = 0; j < dk1.Tables[0].Rows.Count; j++)
            {
                if (drpednname.SelectedValue == dk1.Tables[0].Rows[j].ItemArray[1].ToString())
                {
                    message = "Edition has been submitted already";
                    AspNetMessageBox(message);
                    flag = 1;

                }
                else
                {
                    flag = 0;
                }

            }
        }
        if (flag== 0)
        {

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Edcode";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Edition_code";
            mydatatable1.Columns.Add(mycolumn1);

            // //DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "sun";
            mydatatable1.Columns.Add(mycolumn1);

            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "mon";
            mydatatable1.Columns.Add(mycolumn1);

            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "tue";
            mydatatable1.Columns.Add(mycolumn1);

            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "wed";
            mydatatable1.Columns.Add(mycolumn1);

            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "thu";
            mydatatable1.Columns.Add(mycolumn1);

            ////DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "fri";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "sat";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "all";
            mydatatable1.Columns.Add(mycolumn1);


            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "STAT_CODE";
            mydatatable1.Columns.Add(mycolumn1);


            myrow1 = mydatatable1.NewRow();

            myrow1["Edition_code"] = hiddenedition1.Value;//drpednname.SelectedItem.Text; //; 
            gbedition = hiddenedition1.Value;

            //myrow1["Edcode"] = hiddenname.Value;//drpednname.SelectedItem.Text; //; 
            //gbeditionname = hiddenname.Value;

            myrow1["Edcode"] = hiddenname.Value;//drpednname.SelectedItem.Text; //; 
            gbeditionname = hiddenedition1.Value;

            myrow1["sun"] = hchk1.Value;
            gbsun = hchk1.Value;
            myrow1["mon"] = hchk2.Value;
            gbmon = hchk2.Value;
            myrow1["tue"] = hchk3.Value;
            gbtue = hchk3.Value;
            myrow1["wed"] = hchk4.Value;
            gbwed = hchk4.Value;
            myrow1["thu"] = hchk5.Value;
            gbthu = hchk5.Value;
            myrow1["fri"] = hchk6.Value;
            gbfri = hchk6.Value;
            myrow1["sat"] = hchk7.Value;
            gbsat = hchk7.Value;
            myrow1["all"] = hchk8.Value;
            gball = hchk8.Value;

            myrow1["STAT_CODE"] = "0";

            mydatatable1.Rows.Add(myrow1);

            dk1.Tables.Add(mydatatable1);

            Session["editionsave"] = dk1;


            bindgrid1("Edition_code");
            bindgrid("Edcode");

        }

    }



    public void bindgrid1(string sortfield)
    {
        DataGrid2.Visible = true;
        Divgrid2.Visible = true;
        DataGrid1.Visible = false;
        Divgrid1.Visible = false;

        DataSet ds_tbl = new DataSet();

        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();
        DataRow myrow;

       mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Edcode";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Edition_code";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "sun";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "mon";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "tue";
        mydatatable.Columns.Add(mycolumn);
        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "wed";
        mydatatable.Columns.Add(mycolumn);
        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "thu";
        mydatatable.Columns.Add(mycolumn);
        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "fri";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "sat";
        mydatatable.Columns.Add(mycolumn);

        //myrow = mydatatable.NewRow();

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "all";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "STAT_CODE";
        mydatatable.Columns.Add(mycolumn);

        myrow = mydatatable.NewRow();

        // mydatatable.Rows.Add(myrow);

        //dk1.Tables.Add(mydatatable1);



        /////////////////////////////////////


        myrow["Edcode"] = gbeditionname;
        myrow["Edition_code"] = gbedition;
        myrow["sun"] = gbsun;
        myrow["mon"] = gbmon;
        myrow["tue"] = gbtue;
        myrow["wed"] = gbwed;
        myrow["thu"] = gbthu;
        myrow["fri"] = gbfri;
        myrow["sat"] = gbsat;
        myrow["all"] = gball;
        myrow["STAT_CODE"] = "0";

        ds_tbl.Tables.Add(mydatatable);
        //myrow1["Edition_code"] = txtedition.Text;
        //gbedition = txtedition.Text;
        //myrow1["sun"] = hchk1.Value;
        //myrow1["mon"] = hchk2.Value;
        //myrow1["tue"] = hchk3.Value;
        //myrow1["wed"] = hchk4.Value;
        //myrow1["thu"] = hchk5.Value;
        //myrow1["fri"] = hchk6.Value;
        //myrow1["sat"] = hchk7.Value;
        //myrow1["all"] = hchk8.Value;
        //my_row["Edition_Code"] = "0";

        //ds_tbl.Tables.Add(mydatatable1);

        // mydatatable.ImportRow(my_row);
        // Session["editionsave"] = dk1;
        if (Session["editionsave"] == null)
        {
        //    ds_tbl.Tables.Add(mydatatable);
        //    DataGrid2.DataSource = ds_tbl.Tables[0];
            DataGrid1.DataBind();
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
                //if (g == 0)
                //{my_row = dk1.Tables[d].Rows[0]my_row = dk1.Tables[d].Rows[0]
                my_row = dk1.Tables[d].Rows[0];
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

        gbedition = "";
        gbsun = "";
        gbmon = "";
        gbtue = "";
        gbwed = "";
        gbthu = "";
        gbfri = "";
        gbsat = "";
        gball = "";
        //drpednname.SelectedValue = "0";
        //txtdesignation.Text = "";
        //txtdob.Text = "";
        //txtemailid.Text = "";
        //txtext.Text = "";
        //txtfaxno.Text = "";
        //txtphoneno.Text = "";


    }




//***************************************************************************************************************
    protected void DataGrid2_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {
        //NewAdbooking.Classes.AdCategoryMaster datagridbind = new NewAdbooking.Classes.AdCategoryMaster();
        //DataSet da = new DataSet();
        //da = datagridbind.editionbindgrid(Session["compcode"].ToString(), Session["userid"].ToString());

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (e.Item.Cells[11].Text == "Y")
            {
                e.Item.Cells[1].Text = "<input type='checkbox'width='7px' id=a" + j + " checked='checked' disabled='disabled'/>";

            }
            else
            {
                e.Item.Cells[1].Text = "<input type='checkbox' width='7px' id=a" + j + " disabled='disabled'/>";
            }
            if (e.Item.Cells[12].Text == "Y")
            {
                e.Item.Cells[2].Text = "<input type='checkbox' width='7px' id=b" + j + " checked='checked' disabled='disabled'/>";

            }
            else
            {
                e.Item.Cells[2].Text = "<input type='checkbox'  width='7px' id=b" + j + " disabled='disabled'  />";
            }
            if (e.Item.Cells[13].Text == "Y")
            {
                e.Item.Cells[3].Text = "<input type='checkbox' width='7px' id=c" + j + " checked='checked' disabled='disabled' />";

            }
            else
            {
                e.Item.Cells[3].Text = "<input type='checkbox' width='7px' id=c" + j + " disabled='disabled' />";
            }
            if (e.Item.Cells[14].Text == "Y")
            {
                e.Item.Cells[4].Text = "<input type='checkbox' width='7px'  id=d" + j + " checked='checked' disabled='disabled'/>";

            }
            else
            {
                e.Item.Cells[4].Text = "<input type='checkbox' width='7px' id=d" + j + " disabled='disabled' />";
            }
            if (e.Item.Cells[15].Text == "Y")
            {
                e.Item.Cells[5].Text = "<input type='checkbox' width='7px' id=e" + j + " checked='checked' disabled='disabled'/>";

            }
            else
            {
                e.Item.Cells[5].Text = "<input type='checkbox' width='7px' id=e" + j + " disabled='disabled' />";
            }

            if (e.Item.Cells[16].Text == "Y")
            {
                e.Item.Cells[6].Text = "<input type='checkbox' width='7px' id=f" + j + " checked='checked' disabled='disabled' />";

            }
            else
            {
                e.Item.Cells[6].Text = "<input type='checkbox' width='7px' id=f" + j + " disabled='disabled'  />";
            }
            if (e.Item.Cells[17].Text == "Y")
            {
                e.Item.Cells[7].Text = "<input type='checkbox' width='7px' id=g" + j + " checked='checked' disabled='disabled' />";

            }
            else
            {
                e.Item.Cells[7].Text = "<input type='checkbox' width='7px' id=g" + j + " disabled='disabled' />";
            }

            e.Item.Cells[8].Text = "<input type='checkbox'width='7px' id=h" + j + " ssssss disabled='disabled'/>";

            //string str = "DataGrid1__ctl_CheckBox1" + j;
            //// string str = "DataGrid1";
            ////string str = "e.Item.Cells[0].Text";
            //e.Item.Cells[0].Text = "<input type='checkbox' width='7px' id= " + str + " OnClick=\"javascript:return editionsubmit12('" + str + "','" + e.Item.Cells[19].Text + "');\"  value=" + e.Item.Cells[19].Text + "  />";
            //j++;
            //string str = "DataGrid1__ctl_CheckBox1" + j;
            //// string str = "DataGrid1";
            ////string str = "e.Item.Cells[0].Text";
            //e.Item.Cells[0].Text = "<input type='checkbox' id= " + str + " OnClick=\"javascript:return editionsubmit12('" + e.Item.Cells[1].Text + "','" + e.Item.ItemIndex + "');\"  value=" + e.Item.Cells[1].Text + "  />";
            j++;

        }
    }
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(categorywiseedition), "ShowAlert", strAlert, true);
    }


    [Ajax.AjaxMethod]
    //		public DataSet advcatchk(string compcode,string userid,string adcatcode)
    public DataSet chk_b(string compcode, string adcatcode, string edition)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdCategoryMaster chk = new NewAdbooking.Classes.AdCategoryMaster();
            ds = chk.editionchk_b(compcode, adcatcode, edition);
           
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCategoryMaster chk = new NewAdbooking.classesoracle.AdCategoryMaster();
            ds = chk.editionchk_b(compcode, adcatcode, edition);
            
        }
        else
        {
            NewAdbooking.classmysql.AdCategoryMaster chk = new NewAdbooking.classmysql.AdCategoryMaster();
            ds = chk.editionchk_b(compcode, adcatcode, edition);
            
        }
        return ds;

    }
}

//***********************************************************************************************************
//if((document.getElementById('CheckBox1').checked==true))
//{

//chk1="Y";
//}
//else
//{
//chk1="N";
//}
//if((document.getElementById('CheckBox2').checked==true))
//{
//chk2="Y";
//}
//else
//{
//chk2="N";
//}
//if(document.getElementById('CheckBox3').checked==true)
//{
//chk3="Y";
//}
//else
//{
//chk3="N";
//}
//if(document.getElementById('CheckBox4').checked==true)
//{
//chk4="Y";
//}
//else
//{
//chk4="N";
//}
//if(document.getElementById('CheckBox5').checked==true)
//{
//chk5="Y";
//}
//else
//{
//chk5="N";
//}
//if(document.getElementById('CheckBox6').checked==true)
//{
//chk6="Y";
//}
//else
//{
//chk6="N";
//}
//if(document.getElementById('CheckBox7').checked==true)
//{
//chk7="Y";
//}
//else
//{
//chk7="N";
//}
//if(document.getElementById('CheckBox8').checked==true)
//{

//chk8="Y";
//chk1="Y";
//chk2="Y";
//chk3="Y"
//chk4="Y"
//chk5="Y"
//chk6="Y"
//chk7="Y"
//chk8="Y"
//}
//else
//{
//chk8="N";
//}
