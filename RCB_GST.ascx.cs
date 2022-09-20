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

public partial class RCB_GST : System.Web.UI.UserControl
{public static string _adadd;
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
    public static string _Label1;
    public static string _lbrcb;
    public static string _lblcgstper1;
    public static string _lblcgstchgamt1;
    public static string _lblsgstper1;
    public static string _lblsgstchgamt1;
    public static string _lbligstper1;
    public static string _lbligstchgamt1;
    public static string _lblcessper1;
    public static string _lblcesschgamt1;
    public RCB_GST()
    {
        _adadd = "";
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
        _Label1 = "";
        _lbrcb = "";
        //////////////////////gor gst///
        _lblcgstper1 = "";
        _lblcgstchgamt1 = "";
        _lblsgstper1 = "";
        _lblsgstchgamt1 = "";
        _lbligstper1 = "";
        _lbligstchgamt1 = "";
        _lblcessper1 = "";
        _lblcesschgamt1 = "";
    }

    public string _adadd1 { get { return _adadd; } set { _adadd = value; } }
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
    public string Label11 { get { return _Label1; } set { _Label1 = value; } }
    public string lbrcb1 { get { return _lbrcb; } set { _lbrcb = value; } }
    //for gst////////////////
    public string lblcgstper1 { get { return _lblcgstper1; } set { _lblcgstper1 = value; } }
    public string lblcgstchgamt1 { get { return _lblcgstchgamt1; } set { _lblcgstchgamt1 = value; } }
    public string lblsgstper1 { get { return _lblsgstper1; } set { _lblsgstper1 = value; } }
    public string lblsgstchgamt1 { get { return _lblsgstchgamt1; } set { _lblsgstchgamt1 = value; } }
    public string lbligstper1 { get { return _lbligstper1; } set { _lbligstper1 = value; } }
    public string lbligstchgamt1 { get { return _lbligstchgamt1; } set { _lbligstchgamt1 = value; } }
    public string lblcessper1 { get { return _lblcessper1; } set { _lblcessper1 = value; } }
    public string lblcesschgamt1 { get { return _lblcesschgamt1; } set { _lblcesschgamt1 = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/classifiedreceipt_bill.xml"));
        lblpublications.Text = ds.Tables[0].Rows[0].ItemArray[49].ToString();
        //lbemail.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        //lbpune.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        //    lbcompaddress.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        agencytxt.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbclientadd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbclientna.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbcap.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbrodat.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbpackagena.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbpackagerate.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lbinsertionnumber.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        lblamount.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        //// lbextpre.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        lbgr.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        //// lbtrade1.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        //// lbadtd.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        //   lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        //lbrcb.Text = ds.Tables[0].Rows[0].ItemArray[48].ToString();
        //Label1.Text = ds.Tables[0].Rows[0].ItemArray[48].ToString();
    }

    public void setReceiptData()
    {
        lbcompaddress.Text = _adadd1;
        agddxt.Text = agddxt1;
        lbaddress.Text = lbaddress1;
        txtcliname.Text = txtcliname1;
        lbcaption.Text = lbcaption1;
        txtpackname.Text = txtpackname1;
        lbpakgrate.Text = lbpakgrate1;
        lbrcbtxt.Text = lbrcbtxt1;
        runtxt.Text = runtxt1;
        adcat.Text = adcat1;
        lbronodate.Text = lbronodate1;
        insertiontxt.Text = insertiontxt1;
        txtgrossamt.Text = txtgrossamt1;
        lbpunetxt.Text = lbpunetxt1;
        lbextrapre.Text = lbextrapre1;
        lbextpre.Text = lbextpre1;
        txtagr.Text = txtagr1;
        lbtrade1.Text = lbtrade11;
        lbadtd.Text = lbadtd1;
        lbadtdtxt.Text = lbadtdtxt1;
        txtdiscal.Text = txtdiscal1;
        if (lblcgstper1 == "")
        {
            tr7.Attributes.Add("style", "display:none");
            lblcgstchgamt1 = "0";
        }
        else
        {
            lblcgst.Text = "CGST (" + lblcgstper1 + ")";
            Label23.Text = lblcgstchgamt1;
        }
        if (lblsgstper1 == "")
        {
            tr8.Attributes.Add("style", "display:none");
            lblsgstchgamt1 = "0";
        }
        else
        {
            lblsgst.Text = "SGST (" + lblsgstper1 + ")";
            Label27.Text = lblsgstchgamt1;
        }
        if (lbligstper1 == "")
        {
            tr9.Attributes.Add("style", "display:none");
            lbligstchgamt1 = "0";
        }
        else
        {
            lbligst.Text = "IGST (" + lbligstper1 + ")";
            Label31.Text = lbligstchgamt1;
        }
        if (lblcessper1 == "")
        {
            tr10.Attributes.Add("style", "display:none");
            lblcesschgamt1 = "0";
        }
        else
        {
            lblcess.Text = "CESS (" + lblcessper1 + ")";
            Label35.Text = lblcesschgamt1;

        }
        if (netpay1 == "")
        {
            netpay1 = "0";
        }
        double withgstamt = Convert.ToDouble(netpay1.ToString()) - (Convert.ToDouble(lblcgstchgamt1.ToString()) + Convert.ToDouble(lblsgstchgamt1.ToString()) + Convert.ToDouble(lbligstchgamt1.ToString()) + Convert.ToDouble(lblcesschgamt1.ToString()));
        Label21.Text = withgstamt.ToString("F2");
        netpay.Text = netpay1;
        lbwordinrupees.Text = lbwordinrupees1;
        lblmatter.Text = lblmatter1;
        dynamictable.Text = dynamictable1;
        lbbilltype.Text = lbbilltype1;
        lbpune.Text = lbpune1;
        lbemailtxt.Text = lbemailtxt1;
        lblnetpayable.Text = lblnetpayable1;
        Label1.Text = _Label1;
        lbrcb.Text = lbrcb1;
    }
   
}