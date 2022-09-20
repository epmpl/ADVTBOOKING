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

public partial class pratidinbill_f_supp : System.Web.UI.UserControl
{
      public static string _agddxt;
    public static string _lbaddress;
    public static string _lbaddress1;
    public static string _txtcliname;
    public static string _lbcaption;
    public static string _txtpackname;
    public static string _lbpakgrate;
    public static string _lbrcbtxt;
    public static string _runtxt;
    public static string _adcat;
    public static string _lbronodate;
    public static string _insertiontxt;
    public static string _txtgrossamt;
    public static string _lbpunetxt;
    public static string _lbextrapre;
    public static string _lbextpre;
    public static string _txtagr;
    public static string _lbtrade1;
    public static string _lbadtd;
    public static string _lbadtdtxt;
    public static string _txtdiscal;
    public static string _netpay;
    public static string _netpay1;
    public static string _lbwordinrupees;
    public static string _lblmatter;
    public static string _dynamictable;
    public static string _trate1;
    public static string _netamttab1;
    public static string _orgname;
    public pratidinbill_f_supp()
    {

        _agddxt = "";
        _lbaddress = "";
        _lbaddress1 = "";
        _txtcliname = "";
        _lbcaption = "";
        _txtpackname = "";
        _lbpakgrate = "";
        _lbrcbtxt = "";
        _runtxt = "";
        _adcat = "";
        _lbronodate = "";
        _insertiontxt = "";
        _txtgrossamt = "";
        _lbpunetxt = "";
        _lbextrapre = "";
        _lbextpre = "";
        _txtagr = "";
        _lbtrade1 = "";
        _lbadtd = "";
        _lbadtdtxt = "";
        _txtdiscal = "";
        _netpay = "";
        _netpay1 = "";
        _lbwordinrupees = "";
        _lblmatter = "";
        _dynamictable = "";
        _trate1 = "";
        _netamttab1 = "";
        _orgname = "";


    }

    public string agddxt1 { get { return _agddxt; } set { _agddxt = value; } }
    public string lbaddress1 { get { return _lbaddress; } set { _lbaddress = value; } }
    public string lbaddress2 { get { return _lbaddress1; } set { _lbaddress1 = value; } }
    public string lbcityname1 { get { return _txtcliname; } set { _txtcliname = value; } }
    public string txtpinno1 { get { return _lbcaption; } set { _lbcaption = value; } }
    public string lblcode1 { get { return _txtpackname; } set { _txtpackname = value; } }
    public string lblboxchrg1 { get { return _lbpakgrate; } set { _lbpakgrate = value; } }
    public string lblexamt_col1 { get { return _lbrcbtxt; } set { _lbrcbtxt = value; } }
    public string lbllocval1 { get { return _runtxt; } set { _runtxt = value; } }
    public string lblexamt_day1 { get { return _adcat; } set { _adcat = value; } }
    public string txtscode1 { get { return _lbronodate; } set { _lbronodate = value; } }
    public string txtratecode1 { get { return _insertiontxt; } set { _insertiontxt = value; } }
    public string lbbillno1 { get { return _txtgrossamt; } set { _txtgrossamt = value; } }
    public string lblclientname1 { get { return _lbpunetxt; } set { _lbpunetxt = value; } }
    public string lblpageval1 { get { return _lbextrapre; } set { _lbextrapre = value; } }
    public string lblisname1 { get { return _lbextpre; } set { _lbextpre = value; } }
    public string lbldate1 { get { return _txtagr; } set { _txtagr = value; } }
    public string lblgross1 { get { return _lbtrade1; } set { _lbtrade1 = value; } }
    public string lbltradedis1 { get { return _lbadtd; } set { _lbadtd = value; } }
    public string lbladddis1 { get { return _lbadtdtxt; } set { _lbadtdtxt = value; } }
    public string lbltrade1 { get { return _txtdiscal; } set { _txtdiscal = value; } }
    public string netpay1 { get { return _netpay; } set { _netpay = value; } }
    public string lblexamt_pos1 { get { return _netpay1; } set { _netpay1 = value; } }
    public string lbwordinrupees1 { get { return _lbwordinrupees; } set { _lbwordinrupees = value; } }
    public string lblamt1 { get { return _lblmatter; } set { _lblmatter = value; } }
    public string dynamictable1 { get { return _dynamictable; } set { _dynamictable = value; } }
    public string trate1 { get { return _trate1; } set { _trate1 = value; } }
    public string netamttab1 { get { return _netamttab1; } set { _netamttab1 = value; } }
    public string lblorg1 { get { return _orgname; } set { _orgname = value; } }
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void setReceiptData()
    {
        agddxt.Text = agddxt1;
        agencyaddtxt.Text = lbaddress1;
        agencyaddtxt.Text = lbaddress2;
        lbcityname.Text = lbcityname1;
        txtpinno.Text = txtpinno1;
        lblcode.Text = lblcode1;
        lblboxchrg.Text = lblboxchrg1;
        lblexamt_col.Text = lblexamt_col1;
        lbllocval.Text = lbllocval1;
        lblexamt_day.Text = lblexamt_day1;
        txtscode.Text = txtscode1;
        txtratecode.Text = txtratecode1;
        lbbillno.Text = lbbillno1;
        lblclientname.Text = lblclientname1;
        lblpageval.Text = lblpageval1;
        lblisname.Text = lblisname1;
        lbldate.Text = lbldate1;
        lblgross.Text = lblgross1;
        lbltradedis.Text = lbltradedis1;
        lbladddis.Text = lbladddis1;
        lbltrade.Text = lbltrade1;
        lblnetamt.Text = netpay1;
        lblexamt_pos.Text = lblexamt_pos1;
        lblamtword.Text = lbwordinrupees1;
        lblamt.Text = lblamt1;
        dynamictable.Text = dynamictable1;
        lblorg.Text = lblorg1;
        if (trate1 == "none")
        {
            trate.Attributes.Add("style", "display:none");
            netamttab.Attributes.Add("style", "display:none"); 
        }
    }
    
}
