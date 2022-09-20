using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

public partial class haribhoomi_billnew1 : System.Web.UI.UserControl
{
    public string _agddxt;
    public string _lbaddress;
    public string _agname;
    public string _txtcliname;


    public string _lbcaption;
    public string _txtinvoice;
    public string _runtxt;
    public string _txtmailid;
    public string _ldduedate;
    public string _adcat;
    public string _txtrefno;
    public string _txtrodate;
    public string _publication_value;
    public string _txtagcode;
    public string _lblagencyname1;
    public string _trddisc_per1;

    public string _txtcaption;
    public string _lbpakgrate;
    public string _txtpanno;
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
    public string _bill_dt;

    public string _lb_totalamt;
    public string _orignaldupli;
    public string _lbimg;
    public string _remark;
    public string _lbladrelpar1;
    public string _unit;
    public string _chkvalue_length;
    public string _chkvalue_length2;
    public string _tbl_id;
    public string _lblspchrg;
    public string _lblpageprem;
    public haribhoomi_billnew1()
    {
        _unit = "";
        _txtagcode = "";
        _lblagencyname1 = "";
        _trddisc_per1 = "";

        _agddxt = "";
        _lbaddress = "";
        _txtcliname = "";
        _lbcaption = "";
        _txtinvoice = "";
        _runtxt = "";
        _ldduedate = "";
        _adcat = "";
        _txtpanno = "";
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
        _bill_dt = "";
        _lb_totalamt = "";
        _lbimg = "";
        _orignaldupli = "";
        _remark = "";
       _txtrefno="";
     _txtrodate="";
     _txtcaption = "";
     _txtmailid="";
     _lbladrelpar1 = "";
     _chkvalue_length = "";
     _chkvalue_length2 = "";
        _lblspchrg="";
        _lblpageprem = "";
    }
    public string unit1 { get { return _unit; } set { _unit = value; } }
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
    public string lblagencyname1 { get { return _lblagencyname1; } set { _lblagencyname1 = value; } }
    public string trddisc_per1 { get { return _trddisc_per1; } set { _trddisc_per1 = value; } }

    public string lbladrelpar1 { get { return _lbladrelpar1; } set { _lbladrelpar1 = value; } }
    public string txtagcode1
    {
        get
        {
            return _txtagcode;
        }
        set
        {
            _txtagcode = value;
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
    public string txtpanno1
    {
        get
        {
            return _txtpanno;
        }
        set
        {
            _txtpanno = value;
        }
    }

    public string txtmailid1
    {
        get
        {
            return _txtmailid;
        }
        set
        {
            _txtmailid = value;
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
    public string bill_dt { get { return _bill_dt; } set { _bill_dt = value; } }

    public string lb_totalamt1 { get { return _lb_totalamt; } set { _lb_totalamt = value; } }
    public string chkvalue_length { get { return _chkvalue_length; } set { _chkvalue_length = value; } }
    public string chkvalue_length2 { get { return _chkvalue_length2; } set { _chkvalue_length2 = value; } }
    public string remark { get { return _remark; } set { _remark = value; } }
    public string lblspchrg { get { return _lblspchrg; } set { _lblspchrg = value; } }
    public string lblpageprem { get { return _lblpageprem; } set { _lblpageprem = value; } }
    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/hari_classified_last.xml"));
        lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        //lblcap.Text = ds.Tables[0].Rows[0].ItemArray[72].ToString();
        lblcap.Text = "Caption";
        lblrefno.Text = ds.Tables[0].Rows[0].ItemArray[70].ToString();
        //lblagencyname.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbladd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblkey.Text = ds.Tables[0].Rows[0].ItemArray[68].ToString();
        lb_total.Text = ds.Tables[0].Rows[0].ItemArray[66].ToString();
        lbtrade1.Text = ds.Tables[0].Rows[0].ItemArray[53].ToString();
        lblbilldt.Text = ds.Tables[0].Rows[0].ItemArray[71].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[58].ToString();
       // product.Text=ds.Tables[0].Rows[0].ItemArray[73].ToString();
        //hribhomi_text.Text = ds.Tables[0].Rows[0].ItemArray[75].ToString();
        hribhomi_text.Text = "For :-     " +"NATIONAL DUNIYA";
        //splchagr.Text = ds.Tables[0].Rows[0].ItemArray[76].ToString();
        splchagr.Text = "Spl.Dis." + "( " + "0" + "% )";
        lbladman.Text = "Advertisement Manager";
        publ.Text = "Product";
        
    }
    public void setReceiptData()
    {
        DataSet ds5 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //Collection.classesoracle.ReceiptEntry shtr = new Collection.classesoracle.ReceiptEntry();
            //ds5 = shtr.bindaddress(Session["compcode"].ToString(), Session["printingcentercode"].ToString(), "", "");


        }
        else
        {
            NewAdbooking.BillingClass.Classes.invoice shtr = new NewAdbooking.BillingClass.Classes.invoice();
            ds5 = shtr.bindaddress(Session["compcode"].ToString(), Session["center"].ToString(), "", "");

        }
        trddisc_per.Text = trddisc_per1;
        //lblagencyname.Text = lblagencyname1;
        lbladrelpar.Text = lbladrelpar1;
        txtagcode.Text = txtagcode1;
        agddxt.Text = agddxt1;
        agencyaddtxt.Text = lbaddress1;
        adcat.Text = adcat1;
        txtcliname.Text = txtcliname1;
        txtinvoice.Text = txtinvoice1;
        txtrefno.Text = txtrefno1;
        txtrodate.Text = txtrodate1;
        txtcaption.Text = publication_value1;
        txtdiscal.Text = txtdiscal1;
        //publication_value.Text = publication_value1;
        txtkey.Text = txtkey1;
        //amount1.Text = amount12;
        txtmailid.Text = txtmailid1;
        lbemailtxt.Text = "www.nationalduniya.in";
        netpay.Text = netpay1;
        txtrupees.Text = netpay1;
        txtpanno.Text = txtpanno1;
        //lbemailtxt.Text = lbemailtxt1;
        lbpune.Text = lbpune1;
        billdt.Text = bill_dt;
        dynamictable.Text = dynamictable1;
        lbtrade1.Text = lbtrade11;
        //lbcompaddress.Text = lbcompaddress1;
        lbcompaddress.Text = ds5.Tables[0].Rows[0]["Pub_Cent_name"].ToString() + " " + ds5.Tables[0].Rows[0]["Add1"].ToString() + " " + ds5.Tables[0].Rows[0]["Street"].ToString()
           + " " + ds5.Tables[0].Rows[0]["Dist_Code"].ToString() + "," + ds5.Tables[0].Rows[0]["Zip"].ToString() + "</br>" + "Phone No.=" + ds5.Tables[0].Rows[0]["Phone1"].ToString()
           + "," + ds5.Tables[0].Rows[0]["Phone2"].ToString() + "</br>" + "Fax:=" + ds5.Tables[0].Rows[0]["Fax"].ToString() + "&nbsp; </br> Email Id:= " + ds5.Tables[0].Rows[0]["EmailID"].ToString();

        lb_totalamt.Text = amount11;
        lbwordinrupees.Text = lbwordinrupees1;
        txt_remark.Text = remark.ToString();
        Label9.Text = lblspchrg.ToString();
        lb_pageprm.Text = lblpageprem.ToString();
        //netpay.Text = Math.Round(finalamount + 0.01).ToString();
        //String countBILS = orignaldupli.ToString();
        //if (countBILS == "0")
        //{
        //    pagestatus.Text = "ORIGINAL".ToString();
        //}
        //else
        //{
        //    pagestatus.Text = "DUPLICATE".ToString();
        //}
        string compname = "<B>NATIONAL DUNIYA</B>";
        string compname25 = "<B>NATIONAL DUNIYA</B>";
        if (Session["revenue"].ToString() == "ja1")
        {
            lbcompanyname.Text = compname25;
        }
        else
        {
            lbcompanyname.Text = compname;
        }
        string rev = "DELHI";
        string revenu = "";
        string revenu25 = "";
       // lbemail.Text = lbemail1;
        //string rev = centername1;
        //string revenu = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All cheques/drafts should be in favour of ESS BEE MEDIA PVT LTD & payable at,&nbsp;" + rev + ".<br /> 2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br />3:&nbsp;All disputes are subject to&nbsp;&nbsp;" + "NOIDA" + " &nbsp;&nbsp;jurisdiction.<br /> ";
        //string revenu25 = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All cheques/drafts should be in favour of ESS BEE MEDIA PVT LTD & payable at,&nbsp;" + compname25 + " , &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;" + rev + ".<br /> 2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br /> 3:&nbsp;All disputes are subject to&nbsp;&nbsp;" + rev + " &nbsp;&nbsp;jurisdiction.<br /> ";
        if (ds5.Tables[0].Rows[0]["Pub_Cent_name"].ToString() == "NCR")
        {
            revenu = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All Cheques/Drafts should be in favour of ESS BEE MEDIA PVT LTD & Payable  at ,&nbsp;NOIDA.<br /> 2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br /> 3:&nbsp;All disputes are subject to NOIDA Jurisdicition<br /> ";
            revenu25 = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All Cheques/Drafts should be in favour of ESS BEE MEDIA PVT LTD& Payable  at,&nbsp;" + compname25 + " , &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;" + rev + ".<br /> 2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br />  3:&nbsp;All disputes are subject to NOIDA Jurisdicition<br /> ";
        }
        else
        {
            revenu = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All Cheques/Drafts should be in favour of ESS BEE MEDIA PVT LTD & Payable  at ,&nbsp;" + ds5.Tables[0].Rows[0]["Pub_Cent_name"].ToString() + ".<br /> 2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br /> 3:&nbsp;All disputes are subject to " + ds5.Tables[0].Rows[0]["Pub_Cent_name"].ToString() + " Jurisdicition<br /> ";
            revenu25 = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All Cheques/Drafts should be in favour of ESS BEE MEDIA PVT LTD& Payable  at,&nbsp;" + compname25 + " , &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;" + rev + ".<br /> 2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br />  3:&nbsp;All disputes are subject to NOIDA Jurisdicition<br /> ";
        }
        if (Session["revenue"].ToString() == "ja1")
        {
            hidedata.Text = revenu25;

        }
        else
        {
            hidedata.Text = revenu;
        }
        //divimg.InnerHtml = divimg1;

        if (unit1 == "RO1")
        {
            lbltan.Text="Tan No:-" +"DELH06489A";
            lblservices.Text="Service Tax No.:-"+"AACCH0077KST001";
        }
        else if (unit1 == "RA2")
        {
            lbltan.Text = "Tan No:-" + "DELH06489A";
            lblservices.Text = "Service Tax No.:-" + "AACCH0077KST003";
        }
        else if (unit1 == "de1")
        {
            lbltan.Text = "Tan No:-" + "DELH06489A";
            lblservices.Text = "Service Tax No:-"+"AACCH0077KST004";
        }
        else if (unit1 == "BI1")
        {
            lbltan.Text = "Tan No:-" + "DELH06489A";
            lblservices.Text = "Service Tax No:-"+"AACCH0077KST002";
        }
        else if (unit1 == "ja1")
        {
            lbltan.Text = "Tan No:-" + "DELH06489A";
            lblservices.Text = "Service Tax No:-"+"AACCH0077KST005";
        }
        else if (unit1 == "RA1")
        {
            lbltan.Text = "Tan No:-" + "DELH06489A";
            lblservices.Text = "Service Tax No:-"+"AACCH0077KSD006";
        }

       
    }

    






}
