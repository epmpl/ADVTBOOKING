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

public partial class RCB_vision : System.Web.UI.UserControl
{
 public string _agency;
    public string _package;
    public string _insertion;
    public string _bookingid;
    public string _salesperson;
    public string _invoice_no;
    public string _rono;
    public string _branch;
    public  string _dynamictable;
    public string _duedate;
    public string _bill_date;
    public string _client_name;
    public string _lbltradedis1;
    public string _chkvalue_length;

    public RCB_vision()
    {

        _agency = "";
        _package = "";
        _insertion = "0";
        _bookingid = "";
        _salesperson = "";
        _invoice_no = "";
        _rono = "";
        _branch = "";
        _dynamictable = "";
        _duedate = "";
        _bill_date = "";
        _client_name = "";
        _lbltradedis1 = "";
        _chkvalue_length = "";
     }



            public string agency { get { return _agency; } set { _agency = value; } }
            public string package { get { return _package; } set { _package = value; } }
            public string insertion { get { return _insertion; } set { _insertion = value; } }
            public string bookingid { get { return _bookingid; } set { _bookingid = value; } }
            public string salesperson { get { return _salesperson; } set { _salesperson = value; } }
            public string invoice_no { get { return _invoice_no; } set { _invoice_no = value; } }
            public string rono { get { return _rono; } set { _rono = value; } }
            public string branch { get { return _branch; } set { _branch = value; } }
    public string dynamictable1 { get { return _dynamictable; } set { _dynamictable = value; } }
    public string duedate { get { return _duedate; } set { _duedate = value; } }
    public string bill_date { get { return _bill_date; } set { _bill_date = value; } }
    public string client { get { return _client_name; } set { _client_name = value; } }
    public string lbltradedis1 { get { return _lbltradedis1; } set { _lbltradedis1 = value; } }
    public string chkvalue_length { get { return _chkvalue_length; } set { _chkvalue_length = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet dsb = new DataSet();
        dsb.ReadXml(Server.MapPath("XML/RCB_vision.xml"));
        //lblhead.Text=dsb.Tables[0].Rows[0].ItemArray[20].ToString();

    }

    public void setReceiptData()
    {
        txt_salesperson.Text = salesperson;
        //txt_branch.Text = branch;
        //txt_invoice.Text = invoice_no;
        txt_order.Text = bookingid;
        dynamictable.Text = dynamictable1;
        //txt_due.Text = bill_date;
       // txt_branch.Text=Session["center"].ToString();
        txt_rono.Text = rono;
        txt_posting.Text = bill_date;
        txt_client_code.Text = client;
        if (chkvalue_length == "yes")
        {
            bhanu.Attributes.Add("style", "page-break-after:always;");
        }
    }
}