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

public partial class jansandesh_billing : System.Web.UI.UserControl
{

    public string _agddxt;
    public string _lbaddress;
    public string _agname;
    public string _txtcliname;


    public string _lbcaption;
    public string _txtinvoice;
    public string _runtxt;

    public string _ldduedate;
    public string _adcat;
    public string _txtrefno;
    public string _txtrodate;
    public string _publication_value;

    public string _txtcaption;
    public string _lbpakgrate;

    public string _insertiontxt;
    public string _amount1;
    public string _lbextrapre;
    public string _txtgr;
    public string _txtdiscal;
    public string _txtkey;
    public string _lbadtdtxt;
    public string _netpay;
    public string _round_text;
    public string _lbwordinrupees;
    public string _lbemailtxt;
    public string _lbpunetxt;
    public string _lbcompanyname;
    public string _centername;
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
    public string _lb_totalamt;
    public string _orignaldupli;
    public string _lbimg;
    public string _remark;

    public jansandesh_billing()
    {
        _agddxt = "";
        _lbaddress = "";
        _txtcliname = "";
        _lbcaption = "";
        _txtinvoice = "";
        _runtxt = "";
        _ldduedate = "";
        _adcat = "";
      
        _publication_value = ""; 
       // _txtpackname = "";
        _lbpakgrate = "";
        _insertiontxt = "";
        _amount1 = "";
        _lbextrapre = "";
        _txtgr = "";
        _txtdiscal = "";
        _lbadtdtxt = "";
        _netpay = "";
        _round_text = "";
        _lbwordinrupees = "";
        _lbemailtxt = "";
        _lbpunetxt = "";
        _lbcompanyname = "";
        _centername= "";
        _lbcompaddress= "";
        _lbnaam="";
        _lbterms = "";
        _txtkey = "";
        _lbadtd = "";
        _lbextpre = "";
        _dynamictable = "";
        _lbtrade1 = "";
        _hidedata = "";
        _EOU = "";
        _lbemail = "";
        _lbpune = "";
        _lb_totalamt = "";
        _lbimg = "";
        _orignaldupli = "";
        _remark = "";
       _txtrefno="";
     _txtrodate="";
     _txtcaption = "";
    }
    public string agddxt1 { get { return _agddxt; } set { _agddxt = value; } }
    public string lbaddress1 { get { return _lbaddress; } set { _lbaddress = value; } }
    public string txtkey1 { get { return _txtkey; } set { _txtkey = value; } }
    public string agname1 { get { return _agname; } set { _agname = value; } }

    public string txtcliname1 { get { return _txtcliname; } set { _txtcliname = value; } }
    public string lbcaption1 { get { return _lbcaption; } set { _lbcaption = value; } }
    public string txtinvoice1 { get { return _txtinvoice; } set { _txtinvoice = value; } }
    public string runtxt1 { get { return _runtxt; } set { _runtxt = value; } }

    public string orignaldupli { get { return _orignaldupli; } set { _orignaldupli = value; } }

    public string ldduedate1 { get { return _ldduedate; } set { _ldduedate = value; } }
    public string adcat1 { get { return _adcat; } set { _adcat = value; } }
    // public string lbronodate1 { get { return _lbronodate; } set { _lbronodate = value; } }
    public string txtrodate1
    {
        get
        {
            return _txtrodate;
        }
        set
        {
            _txtrodate = value;
        }
    }
    public string txtrefno1
    {
        get
        {
            return _txtrefno;
        }
        set
        {
            _txtrefno = value;
        }
    }



    public string publication_value1 { get { return _publication_value; } set { _publication_value = value; } }


    public string txtpackname1 { get { return _txtcaption; } set { _txtcaption = value; } }
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
    public string round_text1 { get { return _round_text; } set { _round_text = value; } }
    public string lbwordinrupees1 { get { return _lbwordinrupees; } set { _lbwordinrupees = value; } }

    public string lbcompanyname1 { get { return _lbcompanyname; } set { _lbcompanyname = value; } }
    public string centername1 { get { return _centername; } set { _centername = value; } }

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
    public string lb_totalamt1 { get { return _lb_totalamt; } set { _lb_totalamt = value; } }

    public string remark { get { return _remark; } set { _remark = value; } }




    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/jansandesh.xml"));
        lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        lblcap.Text = ds.Tables[0].Rows[0].ItemArray[72].ToString();
        lblrefno.Text = ds.Tables[0].Rows[0].ItemArray[70].ToString();
        lblagencyname.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbladd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblkey.Text = ds.Tables[0].Rows[0].ItemArray[68].ToString();
        lb_total.Text = ds.Tables[0].Rows[0].ItemArray[69].ToString();
        lbtrade1.Text = ds.Tables[0].Rows[0].ItemArray[53].ToString();
        lblbilldt.Text = ds.Tables[0].Rows[0].ItemArray[71].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[58].ToString();
        publ.Text = ds.Tables[0].Rows[0].ItemArray[73].ToString();


    }

    public void setReceiptData()
    {


        agddxt.Text = agddxt1;
        agencyaddtxt.Text = lbaddress1;
        adcat.Text = adcat1;
        txtcliname.Text = txtcliname1;
        txtinvoice.Text = txtinvoice1;
        txtrefno.Text = txtrefno1;
        txtrodate.Text = txtrodate1;
        txtcaption.Text = txtpackname1;
        txtdiscal.Text = txtdiscal1;
        //publication_value.Text = publication_value1;
        txtkey.Text = txtkey1;
        //amount1.Text = amount12;

        netpay.Text = netpay1;

        lbemailtxt.Text = lbemailtxt1;

        dynamictable.Text = dynamictable1;
        lbtrade1.Text = lbtrade11;
        lbcompaddress.Text = lbcompaddress1;
        lb_totalamt.Text = amount11;
        lbwordinrupees.Text = lbwordinrupees1;
        //txt_remark.Text = remark.ToString();
        //netpay.Text = Math.Round(finalamount + 0.01).ToString();
        String countBILS = orignaldupli.ToString();
        if (countBILS == "0")
        {
            pagestatus.Text = "ORIGINAL".ToString();
        }
        else
        {
            pagestatus.Text = "DUPLICATE".ToString();
        }
        string compname = "<B>HARI BHOOMI</B>";
        string compname25 = "<B>Hari Bhoomi Communications Pvt. Ltd.</B>";
        if (Session["revenue"].ToString() == "ja1")
        {
            hidedata.Text = compname25;
        }
        else
        {
            hidedata.Text = compname;
        }
        string rev = centername1;
        string revenu = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All cheques/drafts should be payable to Hari Bhoomi ,&nbsp;" + rev + ".<br /> 2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br /> 3:&nbsp;22% Interest will be charged on overdue bills.<br /> 4:&nbsp;Payment should be made by A/C payee cheque/draft favouring\"Hari Bhoomi\" and&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;payable at&nbsp;&nbsp; " + rev + "&nbsp;&nbsp;.<br /> 5:&nbsp;All disputes are subject to&nbsp;&nbsp;" + rev + " &nbsp;&nbsp;jurisdiction.<br /> ";
        string revenu25 = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All cheques/drafts should be payable to " + compname25 + " , &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;" + rev + ".<br /> 2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br /> 3:&nbsp;22% Interest will be charged on overdue bills.<br /> 4:&nbsp;Payment should be made by A/C payee cheque/draft favouring\"" + compname25 + "\" and&nbsp;&nbsp;payable at&nbsp;&nbsp; " + rev + "&nbsp;&nbsp;.<br /> 5:&nbsp;All disputes are subject to&nbsp;&nbsp;" + rev + " &nbsp;&nbsp;jurisdiction.<br /> ";
        if (Session["revenue"].ToString() == "ja1")
        {
            hidedata.Text = revenu25;

        }
        else
        {
            hidedata.Text = revenu;
        }
        //divimg.InnerHtml = divimg1;
    }



}
