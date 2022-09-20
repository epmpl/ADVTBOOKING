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

public partial class RCB_V : System.Web.UI.UserControl
{
     public static string _agddxt;
    public static string _lbaddress;
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
    public static string _lbwordinrupees;
    public static string _lblmatter;
    public static string _dynamictable;
    public static string _lbbilltype;
    public static string _lbpune;
    public static string _lbemailtxt;
    public static string _lblnetpayable;
    public static string _lblprevbill;
    public static string _lblcashdisc;
    public static string _lbimg;
    public static string _lbbox;
    public static string _lblcatdata1;
    public static string _cioid;
    public static string _boxno;
    public RCB_V()
    {
        _boxno = "";
        _cioid = "";
        _agddxt="";
        _lbaddress = "";
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
        _lbwordinrupees = "";
        _lblmatter = "";
        _dynamictable = "";
        _lbbilltype = "";
        _lbpunetxt = "";
        _lbemailtxt = "";
        _lblnetpayable = "";
        _lblprevbill = "";
        _lblcashdisc = "";
        _lbimg = "";
        _lbbox = "";
        _lblcatdata1 = "";
    }

    public string boxno1 { get { return _boxno; } set { _boxno = value; } }
    public string cioid11 { get { return _cioid; } set { _cioid = value; } }
    public string agddxt1 { get { return _agddxt; } set { _agddxt = value; } }
    public string lbaddress1 { get { return _lbaddress; } set { _lbaddress = value; } }
    public string txtcliname1 { get { return _txtcliname; } set { _txtcliname = value; } }
    public string lbcaption1 { get { return _lbcaption; } set { _lbcaption = value; } }
    public string txtpackname1 { get { return _txtpackname; } set { _txtpackname = value; } }
    public string lbpakgrate1 { get { return _lbpakgrate; } set { _lbpakgrate = value; } }
    public string lbrcbtxt1 { get { return _lbrcbtxt; } set { _lbrcbtxt = value; } }
    public string runtxt1 { get { return _runtxt; } set { _runtxt = value; } }
    public string adcat1 { get { return _adcat; } set { _adcat = value; } }
    public string lbronodate1 { get { return _lbronodate; } set { _lbronodate = value; } }
    public string insertiontxt1 { get { return _insertiontxt; } set { _insertiontxt = value; } }
    public string txtgrossamt1 { get { return _txtgrossamt; } set { _txtgrossamt = value; } }
    public string lbpunetxt1 { get { return _lbpunetxt; } set { _lbpunetxt = value; } }
    public string lbextrapre1 { get { return _lbextrapre; } set { _lbextrapre = value; } }
    public string lbextpre1 { get { return _lbextpre; } set { _lbextpre = value; } }
    public string txtagr1 { get { return _txtagr; } set { _txtagr = value; } }
    public string lbtrade11 { get { return _lbtrade1; } set { _lbtrade1 = value; } }
    public string lbadtd1 { get { return _lbadtd; } set { _lbadtd = value; } }
    public string lbadtdtxt1 { get { return _lbadtdtxt; } set { _lbadtdtxt = value; } }
    public string txtdiscal1 { get { return _txtdiscal; } set { _txtdiscal = value; } }
    public string netpay1 { get { return _netpay; } set { _netpay = value; } }
    public string lbwordinrupees1 { get { return _lbwordinrupees; } set { _lbwordinrupees = value; } }
    public string lblmatter1 { get { return _lblmatter; } set { _lblmatter = value; } }
    public string dynamictable1 { get { return _dynamictable; } set { _dynamictable = value; } }
    public string lbbilltype1 { get { return _lbbilltype; } set { _lbbilltype = value; } }
    public string lbpune1 { get { return _lbpune; } set { _lbpune = value; } }
    public string lbemailtxt1 { get { return _lbemailtxt; } set { _lbemailtxt = value; } }
    public string lblnetpayable1 { get { return _lblnetpayable; } set { _lblnetpayable = value; } }
    public string lblprevbill1 { get { return _lblprevbill; } set { _lblprevbill = value; } }
    public string lblcashdisc1 { get { return _lblcashdisc; } set { _lblcashdisc = value; } }
    public string divimg1 { get { return _lbimg; } set { _lbimg = value; } }
    public string lblbox1 { get { return _lbbox; } set { _lbbox = value; } }
    public string lblcatdata1 { get { return _lblcatdata1; } set { _lblcatdata1 = value; } }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void setReceiptData()
    {
        agencytxt.Text = agddxt1;
        txtadcat.Text = lblcatdata1;
        //txtinvoice.Text = cioid11;
       

        //txtadvertiser.Text = txtcliname1;
        lblrelodno.Text = lbronodate1;
        lblmatter.Text = lblmatter1;

        txtdate.Text = runtxt1;
        txtrecept.Text = lbrcbtxt1;
        //lblbox.Text = boxno1;

        dynamictable.Text = dynamictable1;

        lbl_gross.Text = txtgrossamt1;
        lbl_trade.Text = txtdiscal1;
        //lbl_add.Text = lblcashdisc1;
        //lbl_box.Text = lblbox1;
        lbl_net.Text = netpay1;
        lbwordinrupees.Text = lbwordinrupees1;
    }
}
