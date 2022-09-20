﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class bill_haribhoomi_classified : System.Web.UI.UserControl
{
    public  string _agddxt;
    public  string _lbaddress;
    public string _agname;
    public  string _txtcliname;


    public  string _lbcaption;
    public  string _txtinvoice;
    public  string _runtxt;

    public  string _ldduedate;
    public  string _adcat;
    public  string _lbronodate;

    public string _publication_value;

    public  string _txtpackname;
    public  string _lbpakgrate;

    public  string _insertiontxt;
    public  string _amount1;
    public  string _lbextrapre;
    public  string _txtgr;
    public  string _txtdiscal;
    public  string _lbadtdtxt;
    public  string _netpay;
    public string _round_text;
    public  string _lbwordinrupees;
    public  string _lbemailtxt;
    public  string   _lbpunetxt;
    public  string _lbcompanyname;
    public string _centername;
    public  string _lbcompaddress;
    public  string _lbnaam;
    public  string _lbterms;
     public  string _lbadtd;
    public  string _lbextpre;
    public  string _dynamictable;
    public  string _lbtrade1;
    public  string _hidedata;
    public  string _EOU;
    public  string _lbemail;
    public  string _lbpune;
    public string _lb_totalamt;
    public string _orignaldupli;
    public string _lbimg;
    public string _remark;

   
    public bill_haribhoomi_classified()
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
        _publication_value = ""; 
        _txtpackname = "";
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

    }

    public string agddxt1 { get { return _agddxt; } set { _agddxt = value; } }
    public string lbaddress1 { get { return _lbaddress; } set { _lbaddress = value; } }

    public string agname1 { get { return _agname; } set { _agname = value; } }

    public string txtcliname1 { get { return _txtcliname; } set { _txtcliname = value; } }
    public string lbcaption1 { get { return _lbcaption; } set { _lbcaption = value; } }
    public string txtinvoice1 { get { return _txtinvoice; } set { _txtinvoice = value; } }
    public string runtxt1 { get { return _runtxt; } set { _runtxt = value; } }

    public string orignaldupli { get { return _orignaldupli; } set { _orignaldupli = value; } }

    public string ldduedate1 { get { return _ldduedate; } set { _ldduedate = value; } }
    public string adcat1 { get { return _adcat; } set { _adcat = value; } }
    public string lbronodate1 { get { return _lbronodate; } set { _lbronodate = value; } }

    public string publication_value1 { get { return _publication_value; } set { _publication_value = value; } }


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

    //public string divimg1 { get { return _lbimg; } set { _lbimg = value; } }

    





    protected void Page_Load(object sender, EventArgs e)
    {
        
        DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/hari_classified_last.xml"));
            // lbemail.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
            // lbpune.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
            //lbcompaddress.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            //agencytxt.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            // lbclientadd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            // lbclientna.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            //lbcap.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            lbdate.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            lbddate.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[58].ToString();
            // lbrodat.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            lbpackagena.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            // lbpackagerate.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
            //lbinsertionnumber.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
            lblamount.Text = ds.Tables[0].Rows[0].ItemArray[52].ToString();
            //lbgr.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
            lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
            publ.Text = ds.Tables[0].Rows[0].ItemArray[62].ToString();
            roundoff.Text = ds.Tables[0].Rows[0].ItemArray[63].ToString();
    }

    public void setReceiptData()
    {
        agddxt.Text = agddxt1;
        lbaddress.Text=lbaddress1 ;
        agname.Text = agname1;
        //txtcliname.Text=txtcliname1;
        //lbcaption.Text  = lbcaption1;
        txtinvoice.Text = txtinvoice1;
        runtxt.Text = runtxt1;
        ldduedate.Text = ldduedate1;
        publication_value.Text = publication_value1;
        adcat.Text = adcat1;
        //lbronodate.Text = lbronodate1;
        txtpackname.Text = txtpackname1;
        // lbpakgrate.Text = lbpakgrate1;
        //insertiontxt.Text = insertiontxt1;
        amount1.Text = amount11;
        lbextrapre.Text = lbextrapre1;
        // txtgr.Text = txtgr1;
        txtdiscal.Text = txtdiscal1;
        lbadtdtxt.Text = lbadtdtxt1;
        netpay.Text = netpay1;
        round_text.Text = round_text1;
        lbwordinrupees.Text = lbwordinrupees1;
        lbemailtxt.Text = lbemailtxt1;
        lbpunetxt.Text = lbpunetxt1;
        string comp = "<B>HARI BHOOMI</B>";
        string comp1 = "<B>HARI BHOOMI COMMUNICATIONS PVT. LTD.</B>";
        if (Session["revenue"].ToString() == "ja1")
        {
        lbcompanyname.Text = comp1;
        }
        else
        {
        lbcompanyname.Text = comp;
        }
        string compn = centername1;
        //lbcompanyname .Text = lbcompanyname1;
        lbcompaddress .Text = lbcompaddress1;
        //lbnaam.Text = lbnaam1;
        //lbterms .Text =lbterms1;
        lbadtd .Text  =lbadtd1;
        lbextpre.Text = lbextpre1;
        dynamictable.Text  = dynamictable1;
        lbtrade1.Text = lbtrade11;
        // hidedata.Text = hidedata1;
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
        //EOU.Text = EOU1;
        // lbemail.Text = lbemail1;
        lbpune.Text = lbpune1;
        lb_totalamt.Text = amount11;
        String countBILS = orignaldupli.ToString();
        if (countBILS == "0")
        {
            pagestatus.Text = "ORIGINAL".ToString();
        }
        else
        {
            pagestatus.Text = "DUPLICATE".ToString();
        }

        txt_remark.Text = remark.ToString();
        // netpay.Text = Math.Round(finalamount + 0.01).ToString();

        //divimg.InnerHtml = divimg1;
    }

}

