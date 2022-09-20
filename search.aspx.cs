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
using System.Data.SqlClient;

public partial class search : System.Web.UI.Page
{
    int i = 0;
    public static Int32 numberDiv;
    public static DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
        }

        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenusername.Value = Session["Username"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/search.xml"));
        lbagency.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbsperson.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbcust.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbfromdate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbtodate.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbsheldate.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbinsertntodate.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbtext.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbStatus.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lblhindi.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lbleng.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();

        Ajax.Utility.RegisterTypeForAjax(typeof(search));
        btnreset.Attributes.Add("OnClick", "javascript:return resetVal();");
        btnexit.Attributes.Add("OnClick", "javascript:return exitclick();");
        lstclient.Attributes.Add("onclick", "javascript:return insertclient();");
        lstagency.Attributes.Add("onclick", "javascript:return insertagency();");
        lstsperson.Attributes.Add("onclick", "javascript:return insertspeson();");
        radh1.Attributes.Add("onclick","javascript:return checkfontname();");
        raden.Attributes.Add("onclick", "javascript:return checkfontname();");

       // txtagency.Attributes.Add("onclick", "javascript:return tabvaluebyid(event);");
       // txtsperson.Attributes.Add("onclick", "javascript:return tabvaluebyid(event);");
       // txtcust.Attributes.Add("onclick", "javascript:return tabvaluebyid(event);");

        txtagency.Attributes.Add("onchange", "javascript:return agencychange();");
        txtcust.Attributes.Add("onchange", "javascript:return clientchange();");
        txtsperson.Attributes.Add("onchange", "javascript:return spersonchange();");
        
        txtfromdate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
        txttodate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
        txtsheldate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
        insertntodate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");

        txtfromdate.Attributes.Add("OnKeypress", "javascript:return ClientisDate(event);");
        txttodate.Attributes.Add("OnKeypress", "javascript:return ClientisDate(event);");
        txtsheldate.Attributes.Add("OnKeypress", "javascript:return ClientisDate(event);");
        insertntodate.Attributes.Add("OnKeypress", "javascript:return ClientisDate(event);");

        BtnRun.Attributes.Add("onclick", "javascript:return validation();");

        txtagency.Attributes.Add("onkeydown", "javascript:return tabvaluebyid(event);");
        lstagency.Attributes.Add("onkeydown", "javascript:return tabvaluebyid(event);");


        txtsperson.Attributes.Add("onkeydown", "javascript:return tabvaluebyid(event);");
        lstsperson.Attributes.Add("onkeydown", "javascript:return tabvaluebyid(event);");



        txtcust.Attributes.Add("onkeydown", "javascript:return tabvaluebyid(event);");
        lstclient.Attributes.Add("onkeydown", "javascript:return tabvaluebyid(event);");






       // onkeydown="javascript:return tabvaluebyid(event);"

      
        if (!Page.IsPostBack)
        {
            if (ConfigurationSettings.AppSettings["center"].ToString() == "depo")
            {
                DataSet dsagencyxml = new DataSet();
                dsagencyxml.ReadXml(Server.MapPath("XML/agency.xml"));
                string agency1 = dsagencyxml.Tables[0].Rows[0].ItemArray[0].ToString();
                if (agency1 != "all")
                {
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.login searchdetail = new NewAdbooking.Classes.login();
                        dsagencyxml = searchdetail.getPubCenterlogin(agency1);
                    }

                    else
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.login searchdetail = new NewAdbooking.classesoracle.login();
                            dsagencyxml = searchdetail.getPubCenterlogin(agency1);

                        }
                        else
                        {

                            NewAdbooking.classmysql.login searchdetail = new NewAdbooking.classmysql.login();
                            dsagencyxml = searchdetail.getPubCenterlogin(agency1);
                        }

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        txtagency.Text = dsagencyxml.Tables[0].Rows[0].ItemArray[0].ToString();
                        txtagency.Enabled = false;
                    }
                }
                else
                {

                    agency1 = Session["agency_name"].ToString();
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.login searchdetail = new NewAdbooking.classesoracle.login();
                        dsagencyxml = searchdetail.getPubCenterlogin(agency1);

                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.login searchdetail = new NewAdbooking.Classes.login();
                        dsagencyxml = searchdetail.getPubCenterlogin(agency1);
                    }
                    else
                    {

                        NewAdbooking.classmysql.login searchdetail = new NewAdbooking.classmysql.login();
                        dsagencyxml = searchdetail.getPubCenterlogin(agency1);
                    }

                    if (ds.Tables[0].Rows.Count != 0)
                        txtagency.Text = dsagencyxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    txtagency.Enabled = false;
                }

            }
            else
            {
                string agency1 = Session["agency_name"].ToString();
                if (agency1 != "0")
                {
                    DataSet dsagencyxml = new DataSet();
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.login searchdetail = new NewAdbooking.classesoracle.login();
                        dsagencyxml = searchdetail.getPubCenterlogin(agency1);

                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.login searchdetail = new NewAdbooking.Classes.login();
                        dsagencyxml = searchdetail.getPubCenterlogin(agency1);
                    }
                    else
                    {

                        NewAdbooking.classmysql.login searchdetail = new NewAdbooking.classmysql.login();
                        dsagencyxml = searchdetail.getPubCenterlogin(agency1);
                    }

                    if (ds.Tables[0].Rows.Count != 0)
                        txtagency.Text = dsagencyxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    txtagency.Enabled = false;
                }
            }
     //       bindgrid();
        }
       


        
    }

    [Ajax.AjaxMethod]
    public DataSet bindagencyname(string compcode, string agency)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.search bindagen = new NewAdbooking.Classes.search();        
        ds = bindagen.bindagency(compcode, agency);
        return ds;
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.reportconfirm bindagen = new NewAdbooking.classesoracle.reportconfirm();
            ds = bindagen.bindagency(compcode, agency);
            return ds;
        }
        else
        {

            NewAdbooking.classmysql.search bindagen = new NewAdbooking.classmysql.search();
            ds = bindagen.bindagency(compcode, agency);
            return ds;
        }
    }

    [Ajax.AjaxMethod]
    public DataSet bindclientname(string compcode, string client)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.search objclient = new NewAdbooking.Classes.search();

           
            ds = objclient.getClientName(compcode, client);
            return ds;

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {


            NewAdbooking.classesoracle.reportconfirm objclient = new NewAdbooking.classesoracle.reportconfirm();


            ds = objclient.getClientName(compcode, client);
            return ds;

        }
        else
        {
            NewAdbooking.classmysql.search objclient = new NewAdbooking.classmysql.search();


            ds = objclient.getClientName(compcode, client);
            return ds;


        }
    }

    [Ajax.AjaxMethod]
    public DataSet bindusername(string username)
    {
        DataSet ds = new DataSet();


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.search objclient = new NewAdbooking.Classes.search();

            ds = objclient.Getusername(username);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportconfirm objclient = new NewAdbooking.classesoracle.reportconfirm();

            ds = objclient.Getusername(username);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.search objclient = new NewAdbooking.classmysql.search();

            ds = objclient.Getusername(username);
            return ds;
 

        }
    }
    protected void BtnRun_Click(object sender, EventArgs e)
    {



        bindgrid();
        //string agency;
        //string sperson;
        //string cust;
        //string fromdate;
        //string todate;
        //string sheldate;
        //string text;
        //string insertntodate1;
        //agency = txtagency.Text.ToString();
        //sperson = txtsperson.Text.ToString();
        //cust = txtcust.Text.ToString();
        //fromdate = txtfromdate.Text.ToString();
        //todate = txttodate.Text.ToString();
        //sheldate = txtsheldate.Text.ToString();
        //text = txttext.Text.ToString();
        //insertntodate1 = insertntodate.Text.ToString();
        //NewAdbooking.Classes.search objclient = new NewAdbooking.Classes.search();

        //DataSet ds = new DataSet();
        //ds = objclient.advance_search();
        //ds = objclient.advance_search(agency, sperson, cust, fromdate, todate, sheldate, insertntodate1, text);
        //return ds;
    }

    public void bindgrid()
    {



        string agname;
        string sperson;
        string clientname;
        string clientcode = "";
        string fromdate;
        string todate;
        string sheldate;
        string text;
        string insertntodate1;
        if (hdnagency.Value != "")
        {
            agname = hdnagency.Value;
        }
        else
        {
            agname = txtagency.Text;
        }
        if (hdnsperson.Value != "")
        {
            sperson = hdnsperson.Value;//
        }
        else
        {
            sperson = txtsperson.Text;
        }

        //if (hdnclient.Value != "")
        if(txtcust.Text.IndexOf('+')>0)
        {
            clientcode = hdnclient.Value;
            clientname = txtcust.Text.Split('+')[0];
        }
        else
        {
            clientcode = "";
            clientname = txtcust.Text;
        }

        //ScriptManager.RegisterClientScriptBlock(this, typeof(search), "clearhdn", "clearHidden()", true);

        fromdate = txtfromdate.Text.ToString();
        todate = txttodate.Text.ToString();
        sheldate = txtsheldate.Text.ToString();
        text = txttext.Text.ToString();

        insertntodate1 = insertntodate.Text.ToString();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.search obj = new NewAdbooking.Classes.search();
           // SqlDataAdapter da = new SqlDataAdapter();

            ds = obj.advance_search(Session["compcode"].ToString(), agname, clientname, sperson, fromdate, todate, sheldate, insertntodate1, text, clientcode, drpStatus.SelectedValue, Session["dateformat"].ToString());

            Session["RowLen"] = ds.Tables[0].Rows.Count;
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();

        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
           

            NewAdbooking.classesoracle.reportconfirm obj = new NewAdbooking.classesoracle.reportconfirm();
            ds = obj.advance_search(Session["compcode"].ToString(), agname, clientname, sperson, fromdate, todate, sheldate, insertntodate1, text, clientcode, drpStatus.SelectedValue, Session["dateformat"].ToString());
            Session["RowLen"] = ds.Tables[0].Rows.Count;
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();

        }

        else
        {
            NewAdbooking.classmysql.search obj = new NewAdbooking.classmysql.search();
            // SqlDataAdapter da = new SqlDataAdapter();
           
            ds = obj.advance_search(Session["compcode"].ToString(), agname, clientname, sperson, fromdate, todate, sheldate, insertntodate1, text, clientcode, Session["dateformat"].ToString());

            Session["RowLen"] = ds.Tables[0].Rows.Count;
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();

        }

        



      
    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        hiddenrowcount.Value = Session["RowLen"].ToString();
        string agency1 = Session["agency_name"].ToString();
        if (agency1 != "0")
        {
            e.Item.Cells[1].Visible = false;
        }
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
          
            string bookingid = e.Item.Cells[1].Text;
            e.Item.Cells[0].Text = "<a id='cio" + i + "' style=\"cursor:hand;color:blue\" onClick=\"openPrintReceipt('" + e.Item.Cells[9].Text + "','" + e.Item.Cells[2].Text + "','" + e.Item.Cells[10].Text + "','" + e.Item.Cells[0].Text + "','cio" + i + "','" + hiddenrowcount.Value + "','')\">" + e.Item.Cells[0].Text + "</a>";
            i = i + 1;
            
        }
        e.Item.Cells[9].Visible = false;
        e.Item.Cells[10].Visible = false;
    }

    protected void DataGrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        DataView dv = new DataView(ds.Tables["Table"]);
        if ((numberDiv % 2) == 0)
            dv.Sort = e.SortExpression + " " + "ASC";
        else
            dv.Sort = e.SortExpression + " " + "DESC";
        numberDiv++;
        DataGrid1.DataSource = dv;
        DataGrid1.DataBind();


    }
  
}
