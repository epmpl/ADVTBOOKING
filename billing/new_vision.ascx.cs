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

public partial class new_vision : System.Web.UI.UserControl
{
     public string _date;
    public string _ourref;
    public string _yourref;
    public string _agencyname;
    public string _invoice_no;
    public string _blankline;
    public string _blankline1;

   
    public new_vision()
    {
        _date = "";
        _ourref = "";
        _yourref = "";
        _agencyname = "";
        _invoice_no = "";
        _blankline = "";
        _blankline1 = "";

     

     }


    public string centername { get { return _date; } set { _date = value; } }
    public string telephonenumber { get { return _ourref; } set { _ourref = value; } }

    public string agddxt2 { get { return _yourref; } set { _yourref = value; } }
    public string agddxt1 { get { return _agencyname; } set { _agencyname = value; } }
    public string agddxt11 { get { return _invoice_no; } set { _invoice_no = value; } }
    public string agddxt12 { get { return _blankline; } set { _blankline = value; } }
    public string agddxt13 { get { return _blankline1; } set { _blankline1 = value; } }
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

     public void setReceiptData()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/new_vision.xml"));
        compname.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        compaddress.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        add1.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        add2.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbldate.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblour.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblyour.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbl_1.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbl_2.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbl_3.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbl_4.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbl_5.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lbl_6.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lbl_7.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lbl_8.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();

        lblagency.Text = agddxt1;
        lbl_invoiceno.Text = agddxt11;
        lblblank.Text = agddxt12;
        lbladdress.Text = agddxt13;
    }
}


