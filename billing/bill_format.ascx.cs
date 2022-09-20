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

public partial class bill_format : System.Web.UI.UserControl
{


    public string _agddxt;
    public string _agencyname;
    public string _agencyadd1;
    public string _agencyadd2;
    public string _lno;
    public string _remark;
    public string _edition2;
    public string _city;
    public string _state;
    public string _invoiceno;

    public string _invoicedate;
    public string _refno;
    public string _repname;

    public string _headoffice;

    public string _publication;
    public string _lang;
    public string _No_Insert;
    public string _edition;
 
    public string _pagetype;
    public string _color;
    public string _issuedate;
    public string _caption;
    public string _rupessin;

    public string _amount1;

    public string _lbextrapre;
    public string _txtgr;
    public string _txtdiscal;
    public string _lbadtdtxt;
    public string _netpay;
    public string _round_text;
    public string _dynamictable;
    public string _captionname;
    public string _tradedis1;
    public bill_format()
    {

        _agddxt = "";
        _agencyname = "";
        _agencyadd1 = "";
        _agencyadd2 = "";
        _lno = "";
        _city = "";
        _state = "";
        _invoiceno = "";
        _remark = "";
        _invoicedate = "";
        _refno = "";
        _edition2 = "";
        _repname = "";
        _headoffice = "";
        _No_Insert = "";
        _lang = "";
        _edition = "";
        _pagetype = "";
        _color = "";
        _caption = "";
        _issuedate = "";
        _rupessin = "";


        _amount1 = "";
        _lbextrapre = "";
        _txtgr = "";
        _txtdiscal = "";
        _lbadtdtxt = "";
        _netpay = "";
        _round_text = "";
        _dynamictable = "";
        _captionname = "";

        _tradedis1 = "";
    }
    public string agddxt1 { get { return _agddxt; } set { _agddxt = value; } }

   
    public string agencyname { get { return _agencyname; } set { _agencyname = value; } }
    public string agencyadd1 { get { return _agencyadd1; } set { _agencyadd1 = value; } }

    public string agencyadd2 { get { return _agencyadd2; } set { _agencyadd2 = value; } }
    public string city { get { return _city; } set { _city = value; } }
    public string state { get { return _state; } set { _state = value; } }
    public string invoiceno { get { return _invoiceno; } set { _invoiceno = value; } }

    public string invoicedate { get { return _invoicedate; } set { _invoicedate = value; } }
    public string refno 
    { 
        get
        {
            return _refno;
        } 
        set
        { 
            _refno = value;
        } 
    }
    public string remark
    {
        get
        {
            return _remark;
        }
        set
        {
            _remark = value;
        }
    }
    public string edition2
    {
        get
        {
            return _edition2;
        }
        set
        {
            _edition2 = value;
        }
    }
    public string lno
    {
        get
        {
            return _lno;
        }
        set
        {
            _lno = value;
        }
    }
    public string repname { get { return _repname; } set { _repname = value; } }

    public string headoffice { get { return _headoffice; } set { _headoffice = value; } }


    public string publication { get { return _publication; } set { _publication = value; } }
    public string No_Insert { get { return _No_Insert; } set { _No_Insert = value; } }
    public string lang { get { return _lang; } set { _lang = value; } }

    public string edition { get { return _edition; } set { _edition = value; } }
    public string pagetype { get { return _pagetype; } set { _pagetype = value; } }


    public string color { get { return _color; } set { _color = value; } }
    public string caption { get { return _caption; } set { _caption = value; } }
    public string issuedate { get { return _issuedate; } set { _issuedate = value; } }


    public string rupessin { get { return _rupessin; } set { _rupessin = value; } }


    public string amount11 { get { return _amount1; } set { _amount1 = value; } }

    public string lbextrapre1 { get { return _lbextrapre; } set { _lbextrapre = value; } }
    public string txtgr1 { get { return _txtgr; } set { _txtgr = value; } }
    public string txtdiscal1 { get { return _txtdiscal; } set { _txtdiscal = value; } }


    public string lbadtdtxt1 { get { return _lbadtdtxt; } set { _lbadtdtxt = value; } }
    public string netpay1 { get { return _netpay; } set { _netpay = value; } }
    public string captionname { get { return _captionname; } set { _captionname = value; } }
    public string round_text1 { get { return _round_text; } set { _round_text = value; } }
    public string tradedis1 { get { return _tradedis1; } set { _tradedis1 = value; } }
    public string dynamictable1 { get { return _dynamictable; } set { _dynamictable = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/bill_format.xml"));

        lblinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblinvoicedate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblrefno.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        Lbllzr.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
     //   lbllang.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
      //  lblcaption.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        
    }
    public void setReceiptData()
    {



        //agddxt.Text = agddxt1;
        lblagencyname.Text = agencyname;
        lblagencyadd1.Text = agencyadd1;
        lblagencyadd2.Text = agencyadd2;
        lblcity.Text = city;
        lblstate.Text = state;
        txtinvoiceno.Text = invoiceno;
        txtinvoicedate.Text = invoicedate;
        txtcaptionname.Text = captionname;
        lblremtxt.Text = remark;
        lblrefnotxt.Text = refno;
        lblrepnametxt.Text = repname;
        txtheadoffice.Text = headoffice;
        lblpublication.Text = publication;
        lbllang.Text = lang;
        //lblsno.Text = No_Insert;
        lbledition.Text = edition;
        lblpagetype.Text = pagetype;
        lblcolor.Text = color;
        lblcaption.Text = caption;
        lblissue.Text = issuedate;
        lblrupees.Text = rupessin;
        netpay.Text = netpay1;
        txtdiscal.Text = txtdiscal1;
           txttradedis1.Text = tradedis1;
        lbadtdtxt.Text = lbadtdtxt1;
        lbledition2.Text = edition2;
        lbllzrtxt.Text = lno;
       // dynamictable.Text = dynamictable1;
        dynamictable.Text = dynamictable1;
        string compname = "<B>PRATIYOGITA DARPAN</B>";
        string compname25 = "<B>PRATIYOGITA DARPAN</B>";
        //if (Session["revenue"].ToString() == "ja1")
        //{
        //    hidedata.Text = compname25;
        //}
        //else
        //{
        //    hidedata.Text = compname;
        //}

        //string rev = centername1;

        string revenu = "<b><u>E.& O.E.</u></b><br />&nbsp;All cheques/drafts should be payable to Hari Bhoomi ,&nbsp;<br /> &nbsp;Company Should not be liable for any special indirect or consequencial damage<br /> &nbsp;whatsover. No claim for damages or labour or other expenses or material<br /> &nbsp;furnished will be allowed unless authrised in writing. All Payments be drawn by&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;nbsp;&nbsp;&nbsp;&nbsp;.<br /> &nbsp;cheque or Draft in favour of Pratiyogita Darpan, Payable at Agra&nbsp;&nbsp;&nbsp;&nbsp;<br /> ";
    //    string revenu25 = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All cheques/drafts should be payable to " + compname25 + " , &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;" + rev + ".<br /> 2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br /> 3:&nbsp;22% Interest will be charged on overdue bills.<br /> 4:&nbsp;Payment should be made by A/C payee cheque/draft favouring\"" + compname25 + "\" and&nbsp;&nbsp;payable at&nbsp;&nbsp; " + rev + "&nbsp;&nbsp;.<br /> 5:&nbsp;All disputes are subject to&nbsp;&nbsp;" + rev + " &nbsp;&nbsp;jurisdiction.<br /> ";
        string revenu25 = "<b><u>E.& O.E.</u></b><br />&nbsp;All cheques/drafts should be payable to Hari Bhoomi ,&nbsp;<br /> &nbsp;Company Should not be liable for any special indirect or consequencial damage<br /> &nbsp;whatsover. No claim for damages or labour or other expenses or material<br /> &nbsp;furnished will be allowed unless authrised in writing. All Payments be drawn by&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;nbsp;&nbsp;&nbsp;&nbsp;.<br /> &nbsp;cheque or Draft in favour of Pratiyogita Darpan, Payable at Agra&nbsp;&nbsp; &nbsp;&nbsp;<br /> ";

        
        if (Session["revenue"].ToString() == "ja1")
        {
          // hidedata.Text = revenu25;

        }
        else
        {
          //  hidedata.Text = revenu;
        }

     
        //lbpune.Text = lbpune1;
        //lb_totalamt.Text = amount11;
        lbltotaltext.Text = amount11;
        
    }





}