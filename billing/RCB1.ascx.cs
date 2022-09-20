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

public partial class RCB1 : System.Web.UI.UserControl
{
    public string _agddxt;
    public string _lbaddress;
    public string _txtcliname;
    public string _lbcaption;
    public string _txtinvoice;
    public string _runtxt;
    public string _ldduedate;
    public string _adcat;
    public string _lbronodate;
    public string _txtpackname;
    public string _lbpakgrate;
    public string _insertiontxt;
    public string _amount1;
    public string _lbextrapre;
    public string _txtgr;
    public string _txtdiscal;
    public string _lbadtdtxt;
    public string _netpay;
    public string _lbwordinrupees;
    public string _lbemailtxt;
    public string _lbpunetxt;
    public string _lbcompanyname;
    public string _lbcompaddress;
    public string _lbnaam;
    public string _lbterms;
    public string _lbadtd;
    public string _lbextpre;
    public string _dynamictable;
    public string _lbtrade1;
    public string _hidedata;
    public string _EOU;
    public string _lbemail;
    public string _lbpune;
    public string _lbimg;
    public string _lblvatamt;
    public string _txtvatamt;
    public string _lblclient;
    public string _txtclientc;
    public string _lblfreqnc;
    public string _txtfrequenc;
    public string _lblcatedis;
    public string _txtcatedisc;
    public string _txtcashdisc;
    public string _txtcashtype;
    public string _lblcashdisc;
    public string _eyecatcher;
    public string _lblmatter;
    public string _lblciono;
    public string _lblpageprem1;

    public string _Lblsalesamt;
    public string _lblbilltyp;
    public string _userid;
    public RCB1()
    {
        _agddxt = "";
        _lbaddress = "";
        _txtcliname = "";
        _lbcaption = "";
        _txtinvoice = "";
        _runtxt = "";
        _ldduedate = "";
        _adcat = "";
        _lbronodate = "";
        _txtpackname = "";
        _lbpakgrate = "";
        _insertiontxt = "";
        _amount1 = "";
        _lbextrapre = "";
        _txtgr = "";
        _txtdiscal = "";
        _lbadtdtxt = "";
        _netpay = "";
        _lbwordinrupees = "";
        _lbemailtxt = "";
        _lbpunetxt = "";
        _lbcompanyname = "";
        _lbcompaddress = "";
        _lbnaam = "";
        _lbterms = "";
        _lbadtd = "";
        _lbextpre = "";
        _dynamictable = "";
        _lbtrade1 = "";
        _hidedata = "";
        _EOU = "";
        _lbemail = "";
        _lbpune = "";
        _lbimg = "";
        _lblvatamt="";
        _txtvatamt="";
        _lblclient="";
        _txtclientc="";
        _lblfreqnc="";
        _txtfrequenc="";
        _lblcatedis="";
        _txtcatedisc="";
        _lblcashdisc="";
        _txtcashdisc="";
         _txtcashtype="";
        _eyecatcher="";
        _lblmatter = "";
        _lblciono = "";
        _lblpageprem1 = "";
        _Lblsalesamt = "";
        _lblbilltyp = "";
        _userid = "";

    }

    public string lblvatamt1 { get { return _lblvatamt; } set { _lblvatamt = value; } }
    public string lblclientc1 { get { return _lblclient; } set { _lblclient = value; } }
    public string lblfreq1 { get { return _lblfreqnc; } set { _lblfreqnc = value; } }
    public string lblcatedis1 { get { return _lblcatedis; } set { _lblcatedis = value; } }
    public string lblcashdisc1 { get { return _lblcashdisc; } set { _lblcashdisc = value; } }
    public string agddxt1 { get { return _agddxt; } set { _agddxt = value; } }
    public string lbaddress1 { get { return _lbaddress; } set { _lbaddress = value; } }
    public string txtvatamt1 { get { return _txtvatamt; } set { _txtvatamt = value; } }
    public string txtclientc1 { get { return _txtclientc; } set { _txtclientc = value; } }
    public string txtfrequence1 { get { return _txtfrequenc; } set { _txtfrequenc = value; } }
    public string txtcatedisc1 { get { return _txtcatedisc; } set { _txtcatedisc = value; } }
    public string txtcashdisc1 { get { return _txtcashdisc; } set { _txtcashdisc = value; } }
    public string txtcashtype1 { get { return _txtcashtype; } set { _txtcashtype = value; } }

    public string txtcliname1 { get { return _txtcliname; } set { _txtcliname = value; } }
    public string lbcaption1 { get { return _lbcaption; } set { _lbcaption = value; } }
    public string txtinvoice1 { get { return _txtinvoice; } set { _txtinvoice = value; } }
    public string runtxt1 { get { return _runtxt; } set { _runtxt = value; } }

    public string ldduedate1 { get { return _ldduedate; } set { _ldduedate = value; } }
    public string adcat1 { get { return _adcat; } set { _adcat = value; } }
    public string lbronodate1 { get { return _lbronodate; } set { _lbronodate = value; } }
    public string txtpackname1 { get { return _txtpackname; } set { _txtpackname = value; } }
    public string lbpakgrate1 { get { return _lbpakgrate; } set { _lbpakgrate = value; } }

    public string insertiontxt1 { get { return _insertiontxt; } set { _insertiontxt = value; } }
    public string amount11 { get { return _amount1; } set { _amount1 = value; } }


    public string lbextrapre1 { get { return _lbextrapre; } set { _lbextrapre = value; } }
    public string txtgr1 { get { return _txtgr; } set { _txtgr = value; } }
    public string txtdiscal1 { get { return _txtdiscal; } set { _txtdiscal = value; } }


    public string lbadtdtxt1 { get { return _lbadtdtxt; } set { _lbadtdtxt = value; } }
    public string lbemailtxt1 { get { return _lbemailtxt; } set { _lbemailtxt = value; } }

    public string lbpunetxt1 { get { return _lbpunetxt; } set { _lbpunetxt = value; } }

    public string netpay1 { get { return _netpay; } set { _netpay = value; } }
    public string lbwordinrupees1 { get { return _lbwordinrupees; } set { _lbwordinrupees = value; } }

    public string lbcompanyname1 { get { return _lbcompanyname; } set { _lbcompanyname = value; } }
    public string lbcompaddress1 { get { return _lbcompaddress; } set { _lbcompaddress = value; } }

    public string lbterms1 { get { return _lbterms; } set { _lbterms = value; } }
    public string lbnaam1 { get { return _lbnaam; } set { _lbnaam = value; } }
    public string lbadtd1 { get { return _lbadtd; } set { _lbadtd = value; } }
    public string lbextpre1 { get { return _lbextpre; } set { _lbextpre = value; } }
    public string dynamictable1 { get { return _dynamictable; } set { _dynamictable = value; } }
    public string lbtrade11 { get { return _lbtrade1; } set { _lbtrade1 = value; } }
    public string hidedata1 { get { return _hidedata; } set { _hidedata = value; } }
    public string EOU1 { get { return _EOU; } set { _EOU = value; } }
    public string lbemail1 { get { return _lbemail; } set { _lbemail = value; } }
    public string lbpune1 { get { return _lbpune; } set { _lbpune = value; } }
    public string divimg1 { get { return _lbimg; } set { _lbimg = value; } }
    public string eyecatcher1 { get { return _eyecatcher; } set { _eyecatcher = value; } }
    public string lblmatter1 { get { return _lblmatter; } set { _lblmatter = value; } }
    public string lblciono1 { get { return _lblciono; } set { _lblciono = value; } }

    public string lblpageprem1 { get { return _lblpageprem1; } set { _lblpageprem1 = value; } }

    public string Lblsalesamt1 { get { return _Lblsalesamt; } set { _Lblsalesamt = value; } }
    public string lblbilltyp1 { get { return _lblbilltyp; } set { _lblbilltyp = value; } }
    public string userid1 { get { return _userid; } set { _userid = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/punebill.xml"));
        // lbemail.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        // lbpune.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        //lbcompaddress.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
      //  if (lbtrade11 != "1")
        //{
            agencytxt.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            lbclientadd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
           lbclientna.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
     //   }
       // else
       // {
       //     agencytxt.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
       //     lbclientadd.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
       //     lbclientna.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
       //}
        lbcap.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbddate.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[58].ToString();
        lbrodat.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //lbpackagena.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        //lbpackagena.Text = ds.Tables[0].Rows[0].ItemArray[69].ToString();
        lbpackagerate.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lbinsertionnumber.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        lblamount.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        //lbgr.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        //if (lbtrade11 != "1")
        //{
            lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
            lbgr.Text = "Gross Amount";
        //}
        //else
        //{
        //    lblnetpayable.Text = "Gross Amount";
        //    lbgr.Text = "&nbsp;";
        //}
    }

    public void setReceiptData()
    {



        double ASA = 0;
        if (lblbilltyp1 != "")
        {
            ASA = Convert.ToDouble(lblbilltyp1);
        }
        if (ASA > 0)
        {
            if (userid1 == "DH0" || userid1 == "BH0")
            {
            lblbilltyp.Text = "ORIGNAL";
            }
            else
            {
            lblbilltyp.Text = "DUPLICATE";
            }


            
        }
        else
        {

            lblbilltyp.Text = "ORIGNAL";
        }

        lblpageprem.Text = lblpageprem1;
        lblciono.Text = lblciono1;
        lbcaption.Text = lbcaption1;
        txtinvoice.Text = txtinvoice1;
        runtxt.Text = runtxt1;
        ldduedate.Text = ldduedate1;
        adcat.Text = adcat1;
        lbronodate.Text = lbronodate1;
        txtpackname.Text = txtpackname1;
        lbpakgrate.Text = lbpakgrate1;
        insertiontxt.Text = insertiontxt1;
        amount1.Text = amount11;

        lbextrapre.Text = lbextrapre1;

        Lblsalesamt.Text = Lblsalesamt1;

            txtgr.Text = txtgr1;
            txtdiscal.Text = txtdiscal1;
            lbadtdtxt.Text = lbadtdtxt1;
          //  lbadtd.Text = lbadtd1;
          //  lbtrade1.Text = lbtrade11;
            netpay.Text = netpay1;
            agddxt.Text = agddxt1;
            lbaddress.Text = lbaddress1;
            txtcliname.Text = txtcliname1;
      

        txtcatedisc.Text = txtcatedisc1;
        txtclientc.Text = txtclientc1;
        txtcatedisc.Text = txtcatedisc1;
        txtfrequenc.Text = txtfrequence1;
        txtvatamt.Text = txtvatamt1;
        txtcashdisc.Text = txtcashdisc1;
        txtcashtype.Text = txtcashtype1;
        lbwordinrupees.Text = lbwordinrupees1;
        //lbemailtxt.Text = lbemailtxt1;
     //   lbpunetxt.Text = lbpunetxt1;
        lbcompanyname.Text = lbcompanyname1;
        lbcompaddress.Text = lbcompaddress1;
        //  lbnaam.Text = lbnaam1;
        //lbterms .Text =lbterms1;

        if (lblfreq1 != "1")
            lblfreqnc.Text = lblfreq1;
        else
            lblfreqnc.Text = "";
        if (lblclientc1 != "1")
            lblclient.Text = lblclientc1;
        else
            lblclient.Text = "";
        if (lblcatedis1 != "1")
            lblcatedis.Text = lblcatedis1;
        else
            lblcatedis.Text = "";
        if (lblcashdisc1 != "1")
            lblcashdisc.Text = lblcashdisc1;
        else
            lblcashdisc.Text = "";
        if (lblvatamt1 != "1")
            lblvatamt.Text = lblvatamt1;
        else
            lblvatamt.Text = "";

        if (lbadtd1 != "1")
            lbadtd.Text = lbadtd1;
        else
        lbadtd.Text = "";

        if (lbtrade11 != "1")
            lbtrade1.Text = lbtrade11;
        else
       lbtrade1.Text = "";

        if (lbextrapre1 != "")
        {
            lbextpre.Text = lbextpre1;
        }
        else
        {
            lbextpre.Text = "";
        }
        dynamictable.Text = dynamictable1;
        //=====================
        string eyecatchstr = "";
        string eyecatchfont = "";
        string dropcap = "1";
        string fontweight = "";
        if (eyecatcher1 != "DR" && eyecatcher1 != "BO" && eyecatcher1 != "BO0" && eyecatcher1 != "0" && eyecatcher1 != "")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.bulletmaster clsbullet = new NewAdbooking.Classes.bulletmaster();
                DataSet ds = clsbullet.getSymbol(eyecatcher1, Session["compcode"].ToString());
                eyecatchstr = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.bulletmaster clsbullet = new NewAdbooking.classesoracle.bulletmaster();
                    DataSet ds = clsbullet.getSymbol(eyecatcher1, Session["compcode"].ToString());
                    eyecatchstr = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    eyecatchfont = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                    //eyecatchfontsize = "7";
                }
        }
        if (eyecatcher1 == "BO0")
        {
            fontweight = "<b>";//"<p style=\"font-weight:bold;\">";
        }
        lblmatter.InnerHtml = fontweight + "<span style=\"border:0px solid;float:left;" + "font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + lblmatter1;
        //=============
      
        if (lblmatter1 == "" || lblmatter1 == null)
        {
            lblmatter.Attributes.Add("style", "display:none");
        }



        hidedata.Text = hidedata1;
      //  EOU.Text = EOU1;
       // lbemail.Text = lbemail1;
       // lbpune.Text = lbpune1;
        divimg.InnerHtml = divimg1;
    }

}
