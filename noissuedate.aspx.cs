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

public partial class noissuedate : System.Web.UI.Page
{
    string compcode, userid, dateformat, issuecode, isdate, day, edition_aliasdate;
    static string no_issue_day1 = "", no_issue_date1 = "";
    public static int flag = 0;
    string sortfield, show;
    int j;
    //string gbNO_Issue_Date;
    //string gbNO_Iss_Day;
    static DataSet dk1 = new DataSet();
    static DataSet dk = new DataSet();


    DataRow my_row;

    protected void Page_Load(object sender, System.EventArgs e)
    {


        //    btnsubmit.Enabled = true;

        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }

        compcode = Session["compcode"].ToString();
        hiddencompcode.Value = compcode;

        show = Request.QueryString["show"].ToString();
        hiddenshow.Value = show;

        userid = Session["userid"].ToString();
        hiddenuserid.Value = userid;

        dateformat = Session["dateformat"].ToString();
        hiddendateformat.Value = dateformat;

        issuecode = Request.QueryString["issuecode"].ToString();
        hiddenissuecode.Value = issuecode;

        edition_aliasdate = Request.QueryString["edition_aliasdate"].ToString();
        hiddeneditionalias.Value = edition_aliasdate;

        hdnedition.Value = Request.QueryString["edition"].ToString();
        Session["issuecode"] = issuecode;

        //Response.Write( "<script> alert('Please Enter Center Code First'); </script>" );

        //if (hiddenissuecode.Value == "" || hiddenissuecode.Value == null)
        //{
        //    Response.Write("<script> alert('Please Enter No Issue Code First');window.close(); </script>");
        //}

        Ajax.Utility.RegisterTypeForAjax(typeof(noissuedate));

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/noissuedate.xml"));
        lblnoissueday.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblnoeditiondate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        btnsubmit.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        btnclear.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        btndelete.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        btnclose.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();

        //Ajax.Utility.RegisterTypeForAjax(typeof(NoIssueMaster));

        if (show == "1")
        {
            btnsubmit.Enabled = true;
            drpissday.Enabled = true;
            txtdate.Enabled = true;
            btndelete.Enabled = false;
            hiddendelsau.Value = "0";
            if (lblnoissueday.Enabled == true)
                drpissday.Focus();
        }
        if (show == "0")
        {
            btnsubmit.Enabled = false;
            drpissday.Enabled = false;
            txtdate.Enabled = false;
            btndelete.Enabled = false;
            hiddendelsau.Value = "0";

        }
        if (show == "2")
        {
            btnsubmit.Enabled = true;
            drpissday.Enabled = true;
            txtdate.Enabled = true;
            btndelete.Enabled = false;
            if (lblnoissueday.Enabled == true)
                drpissday.Focus();

            hiddendelsau.Value = "1";

        }

        noissueday(compcode, userid);

        if (!Page.IsPostBack)
        {
            if ((dk1.Tables.Count > 0) && (Session["issuesave"] == null))
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();

                dk.Clear();
                dk.Dispose();
                dk = new DataSet();
            }


            if (Session["issuecode"] != "")
            {

                DataGrid2.Visible = false;
                DataGrid1.Visible = true;
                bindgrid("No_Iss_day");
            }
            else
            {
                DataGrid2.Visible = true;
                DataGrid1.Visible = false;
                bindgrid1("No_Iss_day");

            }
            if (Session["issuesave"] != null)
            {
                bindgrid1("No_Iss_day");
            }

            btnsubmit.Attributes.Add("OnClick", "javascript:return nosubmit();");
            btndelete.Attributes.Add("OnClick", "javascript:return nodelete();");
            txtdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            btnclear.Attributes.Add("OnClick", "javascript:return noclear();");
            btnclose.Attributes.Add("OnClick", "javascript:return closewindow();");

        }


        // Put user code to initialize the page here
    }

    #region Web Form Designer generated code
    protected void OnInit(EventArgs e)
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


    //		public void noissueday(string compcode,string userid)
    public void noissueday(string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.NoIssueMaster day = new NewAdbooking.Classes.NoIssueMaster();

            ds = day.editionname(compcode, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.NoIssueMaster day = new NewAdbooking.classesoracle.NoIssueMaster();
            ds = day.editionname(compcode, userid);
        }
        else
        {
            NewAdbooking.classmysql.NoIssueMaster day = new NewAdbooking.classmysql.NoIssueMaster();
            ds = day.editionname(compcode, userid);
        }
        drpissday.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "---Select Day---";
        li1.Value = "0";
        li1.Selected = true;
        drpissday.Items.Add(li1);
        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[1].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[1].Rows[i].ItemArray[1].ToString();
            drpissday.Items.Add(li);
        }
    }


    public void bindgrid(string sortfield)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.NoIssueMaster databind = new NewAdbooking.Classes.NoIssueMaster();

            ds = databind.nimbind(issuecode, Session["compcode"].ToString(), dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.NoIssueMaster databind = new NewAdbooking.classesoracle.NoIssueMaster();
            ds = databind.nimbind(issuecode, Session["compcode"].ToString(), dateformat);
        }
        else
        {
            NewAdbooking.classmysql.NoIssueMaster databind = new NewAdbooking.classmysql.NoIssueMaster();
            ds = databind.nimbind(issuecode, Session["compcode"].ToString(), dateformat);
        }
        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        dv = ds.Tables[0].DefaultView;
        dv.Sort = sortfield;

        DataGrid1.DataSource = dv;
        DataGrid1.DataBind();
    }


    //		public void bindgrid(string compcode,string userid,string noisscode)
    public void bind33(string compcode, string userid, string noisscode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.NoIssueMaster bind = new NewAdbooking.Classes.NoIssueMaster();

            ds = bind.getbind(compcode, userid, noisscode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.NoIssueMaster bind = new NewAdbooking.classesoracle.NoIssueMaster();
            ds = bind.getbind(compcode, userid, noisscode);
        }
        else
        {
            NewAdbooking.classmysql.NoIssueMaster bind = new NewAdbooking.classmysql.NoIssueMaster();
            ds = bind.getbind(compcode, userid, noisscode);
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
    //		public void submit(string date,string noissueday,string issuecode, string compcode,string userid )
    public void submit(string date, string noissueday, string issuecode, string compcode, string userid, string datefrmt, string edition_alias)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.NoIssueMaster submit = new NewAdbooking.Classes.NoIssueMaster();

            ds = submit.insertdate(date, noissueday, issuecode, compcode, userid, datefrmt);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.NoIssueMaster submit = new NewAdbooking.classesoracle.NoIssueMaster();
            ds = submit.insertdate(date, noissueday, issuecode, compcode, userid, datefrmt, edition_alias);
        }
        else
        {
            NewAdbooking.classmysql.NoIssueMaster submit = new NewAdbooking.classmysql.NoIssueMaster();
            ds = submit.insertdate(date, noissueday, issuecode, compcode, userid, datefrmt);
        }

    }



    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    //		public void submit(string date,string noissueday,string issuecode, string compcode,string userid )
    public DataSet chkdate123(string date, string noissueday, string issuecode, string edition_alias, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.NoIssueMaster submit = new NewAdbooking.Classes.NoIssueMaster();

            ds = submit.chkdate(date, noissueday, issuecode, compcode, userid, Session["dateformat"].ToString());

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.NoIssueMaster submit = new NewAdbooking.classesoracle.NoIssueMaster();
            ds = submit.chkdate(date, noissueday, issuecode, edition_alias, compcode, userid, Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.NoIssueMaster submit = new NewAdbooking.classmysql.NoIssueMaster();
            ds = submit.insertdate(date, noissueday, issuecode, compcode, userid, Session["dateformat"].ToString());
        }

        return ds;

    }










    [Ajax.AjaxMethod]
    public DataSet chkpubcatcode(string str, string editioname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.NoIssueMaster chk = new NewAdbooking.Classes.NoIssueMaster();
            ds = chk.pubcodechk(str, editioname);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.NoIssueMaster chk = new NewAdbooking.classesoracle.NoIssueMaster();
            ds = chk.pubcodechk(str, editioname);

        }
        else
        {
            NewAdbooking.classmysql.NoIssueMaster chk = new NewAdbooking.classmysql.NoIssueMaster();
            ds = chk.pubcodechk(str, editioname);
        }
        return ds;
    }


    [Ajax.AjaxMethod]
    //		public void modify(string date,string noissueday,string issuecode, string compcode,string userid,string code )
    public void modify(string date, string noissueday, string issuecode, string compcode, string userid, string code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.NoIssueMaster submit = new NewAdbooking.Classes.NoIssueMaster();

            ds = submit.modifydate(date, noissueday, issuecode, compcode, userid, code);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.NoIssueMaster submit = new NewAdbooking.classesoracle.NoIssueMaster();
            ds = submit.modifydate(date, noissueday, issuecode, compcode, userid, code);
        }
        else
        {
            NewAdbooking.classmysql.NoIssueMaster submit = new NewAdbooking.classmysql.NoIssueMaster();
            ds = submit.modifydate(date, noissueday, issuecode, compcode, userid, code);
        }
    }

    [Ajax.AjaxMethod]
    //		public void modify(string date,string noissueday,string issuecode, string compcode,string userid,string code )
    public DataSet chkissue(string date, string noissueday, string issuecode, string compcode, string code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.NoIssueMaster chk = new NewAdbooking.Classes.NoIssueMaster();

            ds = chk.chkissue(date, noissueday, issuecode, compcode, code);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.NoIssueMaster chk = new NewAdbooking.classesoracle.NoIssueMaster();
            ds = chk.chkissue(date, noissueday, issuecode, compcode, code);
        }
        else
        {
            NewAdbooking.classmysql.NoIssueMaster chk = new NewAdbooking.classmysql.NoIssueMaster();
            ds = chk.chkissue(date, noissueday, issuecode, compcode, code);
        }

        return ds;
    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    //		public DataSet select(string issuecode, string compcode,string userid, string code )
    public DataSet select(string issuecode, string compcode, string userid, string code10)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.NoIssueMaster submit = new NewAdbooking.Classes.NoIssueMaster();

            ds = submit.selectdate(issuecode, compcode, userid, code10);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.NoIssueMaster submit = new NewAdbooking.classesoracle.NoIssueMaster();
            ds = submit.selectdate(issuecode, compcode, userid, code10);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.NoIssueMaster submit = new NewAdbooking.classmysql.NoIssueMaster();
            ds = submit.selectdate(issuecode, compcode, userid, code10, Session["dateformat"].ToString());
            return ds;
        }
    }

    [Ajax.AjaxMethod]
    //		public DataSet delete1(string issuecode, string compcode,string userid, string code )
    public DataSet delete1(string issuecode, string compcode, string userid, string datecode)//, string code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.NoIssueMaster submit = new NewAdbooking.Classes.NoIssueMaster();

            ds = submit.deletedate(issuecode, compcode, userid, datecode);//, code);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.NoIssueMaster submit = new NewAdbooking.classesoracle.NoIssueMaster();
            ds = submit.deletedate(issuecode, compcode, userid, datecode);//, code);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.NoIssueMaster submit = new NewAdbooking.classmysql.NoIssueMaster();
            ds = submit.deletedate(issuecode, compcode, userid, datecode);//, code);
            return ds;
        }
    }

    //private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    //{
    //    DataView dv = new DataView();


    //    dv = (DataView)DataGrid1.DataSource;
    //    DataColumnCollection dc = dv.Table.Columns;


    //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //    {

    //        string str = "DataGrid1_ctl_CheckBox1" + j;

    //        e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return noselect('" + str + "');\"  value=" + e.Item.Cells[2].Text + "  />";
    //        j++;

    //    }


    //}

    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        DataView dv = new DataView();


        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;


        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            string str = "DataGrid1_ctl_CheckBox1" + j;

            //            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + "  value=" + e.Item.Cells[2].Text + "  />";
            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return chkselect('" + str + "');\" value=" + e.Item.Cells[4].Text + "  />";
            //            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return hello();\" value=" + e.Item.Cells[1].Text + "  />";
            j++;

            // e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  OnClick=\"javascript:return selectclick('" + str + "');\" value=" + e.Item.Cells[1].Text + "  />";
        }

    }

    protected void DataGrid2_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        DataColumn mycolumn1;

        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;
        flag = 0;
        string message;

        int j = 0;
        if (DataGrid2.Items.Count > 0)
        {
            while (j < DataGrid2.Items.Count)
            {
                string sau = hi.Value;
                string sau1 = hi1.Value;
                string issueday = DataGrid2.Items[j].Cells[1].Text;
                string issuedate = DataGrid2.Items[j].Cells[2].Text;
                if (sau == issueday && sau1 == issuedate)
                {
                    message = "Issue day has been submitted already";
                    AspNetMessageBox(message);
                    drpissday.SelectedValue = "0";

                    return;
                }
                else if (sau1 == issuedate)
                {
                    message = "Issue date has been submitted already";
                    AspNetMessageBox(message);
                    txtdate.Text = "";
                    //Session["issuesave"] = dk1;
                    //bindgrid1("No_Iss_day");
                    return;
                }
                j++;
            }

        }
        /*  if ((dk1.Tables.Count != 0))
          {
              int j;
              for (j = 0; j < dk1.Tables[0].Rows.Count; j++)
              {
                  //if (drpissday.SelectedValue == dk1.Tables[0].Rows[j].ItemArray[0].ToString())

                  string sau = hi.Value ;
                  string sau1 = hi1.Value;
                  if (sau == dk1.Tables[0].Rows[j].ItemArray[1].ToString())
                  {
                      message = "Issue day has been submitted already";
                      AspNetMessageBox(message);
                      flag = 1;

                  }
                  else if (sau1==dk1.Tables[0].Rows[j].ItemArray[2].ToString())
                  {
                      message = "Issue date has been submitted already";
                      AspNetMessageBox(message);
                      flag = 1;
                  }
                  else
                  {
                      flag = 0;
                  }

              }

         }*/

        if (flag == 0)
        {
            if (dk1.Tables.Count > 0)
            {
                for (int i = 0; i < dk1.Tables.Count; i++)
                {
                    if (dk1.Tables[i].Rows[0].ItemArray[1].ToString() == no_issue_day1 && dk1.Tables[i].Rows[0].ItemArray[2].ToString() == txtdate.Text)
                    {
                        message = "Issue day has been submitted already";
                        AspNetMessageBox(message);
                        drpissday.SelectedValue = "0";
                        Session["issuesave"] = dk1;
                        bindgrid1("No_Iss_day");
                        return;
                    }
                    /* else if (dk1.Tables[i].Rows[0].ItemArray[2].ToString() == txtdate.Text)
                     {
                         message = "Issue date has been submitted already";
                         AspNetMessageBox(message);
                         txtdate.Text = "";
                         Session["issuesave"] = dk1;
                         bindgrid1("No_Iss_day");
                         return;
                     }*/
                }
            }
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "No_Iss_Code";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "No_Iss_day";
            mydatatable1.Columns.Add(mycolumn1);
            /**/
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "no_issue_date";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "datecode";
            mydatatable1.Columns.Add(mycolumn1);

            myrow1 = mydatatable1.NewRow();

            no_issue_day1 = Session["drop"].ToString();

            myrow1["No_Iss_day"] = no_issue_day1;
            myrow1["no_issue_date"] = txtdate.Text;
            no_issue_date1 = txtdate.Text;
            myrow1["datecode"] = "00";

            mydatatable1.Rows.Add(myrow1);

            dk1.Tables.Add(mydatatable1);
            Session["issuesave"] = dk1;

            bindgrid1("No_Iss_day");


        }

    }

    public void bindgrid1(string sortfield)
    {
        //int d;

        DataGrid2.Visible = true;
        //divgrid21.Visible = true;
        DataGrid1.Visible = false;
        //divgrid1.Visible = false;

        DataSet ds_tbl = new DataSet();


        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "No_Iss_Code";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "No_Iss_day";
        mydatatable.Columns.Add(mycolumn);
        // DataRow myrow;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "no_issue_date";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "datecode";
        mydatatable.Columns.Add(mycolumn);

        my_row = mydatatable.NewRow();



        my_row["No_Iss_day"] = no_issue_day1;
        my_row["no_issue_date"] = no_issue_date1;
        my_row["datecode"] = "00";


        ds_tbl.Tables.Add(mydatatable);

        if (Session["issuesave"] == null)
        {
            // ds_tbl.Tables.Add(mydatatable);
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

            ViewState["SortExpression"] = sortfield;
            ViewState["order"] = "ASC";
            DataView dv = new DataView();
            dv = ds_tbl.Tables[0].DefaultView;

            DataGrid2.DataSource = dv;
            DataGrid2.DataBind();
            d = 0;
        }

        drpissday.SelectedValue = "0";
        txtdate.Text = "";

    }

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(noissuedate), "ShowAlert", strAlert, true);
    }







    protected void DataGrid1_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {
        DataView dv = new DataView();


        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;


        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            string str = "DataGrid1_ctl_CheckBox1" + j;

            //            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + "  value=" + e.Item.Cells[2].Text + "  />";
            //e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return chkselect('" +str+ "');\" value="+ e.Item.Cells[1].Text + "  />";
            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return chkselect('" + str + "');\" value=" + e.Item.Cells[4].Text + "  />";
            j++;

            // e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  OnClick=\"javascript:return selectclick('" + str + "');\" value=" + e.Item.Cells[1].Text + "  />";
        }
    }

    [Ajax.AjaxMethod]
    //		public DataSet chk(string issuecode ,string compcode,string userid)
    public DataSet addeditionsupp(string compcode, string userid, string editioncode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.NoIssueMaster chk = new NewAdbooking.Classes.NoIssueMaster();

            // ds = chk.editionsuppname(issuecode, compcode, userid);
            //return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.NoIssueMaster chk = new NewAdbooking.classesoracle.NoIssueMaster();
            ds = chk.editionsuppname(compcode, userid, editioncode);

        }
        return ds;

    }
}