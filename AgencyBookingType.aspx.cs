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

public partial class AgencyBookingType : System.Web.UI.Page
{
    int j = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddenDateFormat.Value = Session["DateFormat"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(AgencyBookingType));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/AgencyBookingType.xml"));
        lblbooktyp.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblagency.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblfromdate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbltilldate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        drpbooktype.Focus();
        if (!IsPostBack)
        {
            bindbookType();
            btnsubmit.Attributes.Add("OnClick", "javascript:return savebooktype();");
            btnupdate.Attributes.Add("OnClick", "javascript:return updatebooktype();");
            btndel.Attributes.Add("OnClick", "javascript:return delbooktype();");
            btnExit.Attributes.Add("OnClick", "javascript:return catexitclick1();");
            lstagency.Attributes.Add("onclick", "javascript:return insertagency();");
            txtvalidityfrom.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttilldate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
        }


    }
    public void bindbookType()
    {
        DataSet billtyp = new DataSet();
        billtyp.ReadXml(Server.MapPath("XML/billcycle.xml"));
        drpbooktype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Booking Type";
        li1.Value = "0";
        //li1.Selected = true;
        drpbooktype.Items.Add(li1);

        for (i = 0; i < billtyp.Tables[3].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();

            drpbooktype.Items.Add(li);

        }

    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindagencyname(string compcode, string userid, string agency)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindagenname = new NewAdbooking.Classes.BookingMaster();
            ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster bindagenname = new NewAdbooking.classesoracle.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
            }
            else
            {
                ds = bindagenname.bindagency(compcode, userid, agency, "0");
            }
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bindagenname = new NewAdbooking.classmysql.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
            }
            else
            {
                ds = bindagenname.bindagency(compcode, userid, agency, "0");
            }
        }
        return ds;



    }
    [Ajax.AjaxMethod]
    public void savebktype(string booktype, string agency, string frmdate, string tdate, string dateformat, string usrid, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AgencyBookingType bktyp = new NewAdbooking.Classes.AgencyBookingType();
            ds = bktyp.savebkdata(booktype, agency, frmdate, tdate, dateformat, usrid, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AgencyBookingType bktyp = new NewAdbooking.classesoracle.AgencyBookingType();
            ds = bktyp.savebkdata(booktype, agency, frmdate, tdate, dateformat, usrid, compcode);
        }
        else
        {
            //NewAdbooking.classesoracle.AgencyBookingType booktyp = new NewAdbooking.classesoracle.AgencyBookingType();
            //ds = booktyp.savebkdata(booktyp, agency, frmdate, tdate, dateformat, usrid);
            
        }
        //return ds;



    }
    [Ajax.AjaxMethod]
    public void delbktype(string compcode, string code11)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AgencyBookingType bktyp = new NewAdbooking.Classes.AgencyBookingType();
            ds = bktyp.delbkdata(compcode, code11);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AgencyBookingType bktyp = new NewAdbooking.classesoracle.AgencyBookingType();
            ds = bktyp.delbkdata(compcode, code11);
        }
        else
        {
            //NewAdbooking.classesoracle.AgencyBookingType booktyp = new NewAdbooking.classesoracle.AgencyBookingType();
            //ds = booktyp.savebkdata(booktyp, agency, frmdate, tdate, dateformat, usrid);

        }
        //return ds;



    }
    [Ajax.AjaxMethod]
    public void updatebktype(string booktype, string agency, string frmdate, string tdate, string dateformat, string usrid, string compcode,string code11)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AgencyBookingType bktyp = new NewAdbooking.Classes.AgencyBookingType();
            ds = bktyp.updbkdata(booktype, agency, frmdate, tdate, dateformat, usrid, compcode, code11);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AgencyBookingType bktyp = new NewAdbooking.classesoracle.AgencyBookingType();
            ds = bktyp.updbkdata(booktype, agency, frmdate, tdate, dateformat, usrid, compcode, code11);
        }
        else
        {
            //NewAdbooking.classesoracle.AgencyBookingType booktyp = new NewAdbooking.classesoracle.AgencyBookingType();
            //ds = booktyp.savebkdata(booktyp, agency, frmdate, tdate, dateformat, usrid);

        }
        //return ds;



    }
    [Ajax.AjaxMethod]
    public DataSet chkduplicate(string booktype, string agency, string frmdate, string tdate, string dateformat, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AgencyBookingType bktyp = new NewAdbooking.Classes.AgencyBookingType();
            ds = bktyp.chkdup(booktype, agency, frmdate, tdate, dateformat, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AgencyBookingType bktyp = new NewAdbooking.classesoracle.AgencyBookingType();
            ds = bktyp.chkdup(booktype, agency, frmdate, tdate, dateformat, compcode);
        }
        else
        {
            //NewAdbooking.classesoracle.AgencyBookingType booktyp = new NewAdbooking.classesoracle.AgencyBookingType();
            //ds = booktyp.savebkdata(booktyp, agency, frmdate, tdate, dateformat, usrid);

        }
        return ds;



    }
    [Ajax.AjaxMethod]
    public DataSet chkdupforup(string booktype, string agency, string frmdate, string tdate, string dateformat, string compcode,string code11)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AgencyBookingType bktyp = new NewAdbooking.Classes.AgencyBookingType();
            ds = bktyp.chkdupdate(booktype, agency, frmdate, tdate, dateformat, compcode, code11);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AgencyBookingType bktyp = new NewAdbooking.classesoracle.AgencyBookingType();
            ds = bktyp.chkdupdate(booktype, agency, frmdate, tdate, dateformat, compcode, code11);
        }
        else
        {
            //NewAdbooking.classesoracle.AgencyBookingType booktyp = new NewAdbooking.classesoracle.AgencyBookingType();
            //ds = booktyp.savebkdata(booktyp, agency, frmdate, tdate, dateformat, usrid);

        }
        return ds;



    }
    [Ajax.AjaxMethod]
    public DataSet bandbktyp(string compcode, string code11)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AgencyBookingType bktyp = new NewAdbooking.Classes.AgencyBookingType();
            ds = bktyp.bindcktyp(compcode, code11);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AgencyBookingType bktyp = new NewAdbooking.classesoracle.AgencyBookingType();
            ds = bktyp.bindcktyp(compcode, code11);
        }
        else
        {
            //NewAdbooking.classesoracle.AgencyBookingType booktyp = new NewAdbooking.classesoracle.AgencyBookingType();
            //ds = booktyp.savebkdata(booktyp, agency, frmdate, tdate, dateformat, usrid);

        }
        return ds;



    }
    protected void drpbooktype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string booktype = drpbooktype.SelectedValue;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AgencyBookingType bktyp = new NewAdbooking.Classes.AgencyBookingType();
            ds = bktyp.findrec(booktype, hiddencompcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AgencyBookingType bktyp = new NewAdbooking.classesoracle.AgencyBookingType();
            ds = bktyp.findrec(booktype, hiddencompcode.Value);
        }
        else
        {
            //NewAdbooking.classesoracle.AgencyBookingType booktyp = new NewAdbooking.classesoracle.AgencyBookingType();
            //ds = booktyp.savebkdata(booktyp, agency, frmdate, tdate, dateformat, usrid);

        }
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Header)
        {
            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  OnClick=\"javascript:return selectbooktyp('" + str + "');\" value=" + e.Item.Cells[5].Text + "  />";
            j++;
        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        drpbooktype_SelectedIndexChanged(sender, e);
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        drpbooktype_SelectedIndexChanged(sender, e);
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        drpbooktype_SelectedIndexChanged(sender, e);
    }
}
