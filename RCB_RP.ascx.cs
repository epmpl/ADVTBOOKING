using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class RCB_RP : System.Web.UI.UserControl
{
 public  string _agddxt;
    public  string _lbaddress;
    public  string _txtcliname;
    public  string _lbcaption;
    public  string _txtpackname;
    public  string _lbpakgrate;
    public  string _lbrcbtxt;
    public  string _runtxt;
    public  string _adcat;
    public  string _lbronodate;
    public  string _insertiontxt;
    public  string _txtgrossamt;
    public  string _lbpunetxt;
    public  string _lbextrapre;
    public  string _lbextpre;
    public  string _txtagr;
    public  string _lbtrade1;
    public  string _lbadtd;
    public  string _lbadtdtxt;
    public  string _txtdiscal;
    public  string _netpay;
    public  string _lbwordinrupees;
    public  string _lblmatter;
    public  string _dynamictable;
    public  string _lbbilltype;
    public  string _lbpune;
    public  string _lbemailtxt;
    public  string _lblnetpayable;
    public  string _lblprevbill;
    public  string _lblcashdisc;
    public  string _lbimg;
    public  string _lbbox;
    public  string _lblcatdata1;
    public string _eyecatcher;
    public string _bulletcrg;
    public string _extrarate;
    public string _txtextramt;
    public RCB_RP()
    {
        _eyecatcher = "";
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
        _bulletcrg = "";
        _extrarate = "";
        _txtextramt = "";
    }
    public string txtextramt1 { get { return _txtextramt; } set { _txtextramt = value; } }
    public string bulletchrg1 { get { return _bulletcrg; } set { _bulletcrg = value; } }
    public string extrarate1 { get { return _extrarate; } set { _extrarate = value; } }
    public string eyecatcher1 { get { return _eyecatcher; } set { _eyecatcher = value; } }
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
    public string tanscrg { get { return _lbpune; } set { _lbpune = value; } }
    public string lbemailtxt1 { get { return _lbemailtxt; } set { _lbemailtxt = value; } }
    public string lblnetpayable1 { get { return _lblnetpayable; } set { _lblnetpayable = value; } }
    public string lblprevbill1 { get { return _lblprevbill; } set { _lblprevbill = value; } }
    public string lblcashdisc1 { get { return _lblcashdisc; } set { _lblcashdisc = value; } }
    public string divimg1 { get { return _lbimg; } set { _lbimg = value; } }
    public string lblbox1 { get { return _lbbox; } set { _lbbox = value; } }
    public string lblcatdata1 { get { return _lblcatdata1; } set { _lblcatdata1 = value; } }
    protected void Page_Load(object sender, EventArgs e)
    {
        string pextra1 = "";
        string pextra2 = "";
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/classifiedreceipt_bill.xml"));
        //lblpublications.Text = ds.Tables[0].Rows[0].ItemArray[49].ToString();
        //lbemail.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        //lbpune.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
       // lbcompaddress.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        if (agddxt1 == "")
            agencytxt.Text = "Direct Client";
        else
            agencytxt.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbclientadd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbclientna.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString()+" & Add :";
        lbcap.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbrodat.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //lbpackagena.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        //lbpackagerate.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lbinsertionnumber.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        lblamount.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
       //// lbextpre.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        //lbgr.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
       //// lbtrade1.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
       //// lbadtd.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        lbrcb.Text = ds.Tables[0].Rows[0].ItemArray[48].ToString();
        //lblprevbill.Text = ds.Tables[0].Rows[0].ItemArray[50].ToString();
        //lblcashdisc.Text = ds.Tables[0].Rows[0].ItemArray[51].ToString();
        lblbox.Text = ds.Tables[0].Rows[0].ItemArray[54].ToString();
        lbltrans.Text = ds.Tables[0].Rows[0].ItemArray[56].ToString();
        lblbullot.Text = ds.Tables[0].Rows[0].ItemArray[57].ToString();
        lblextra.Text = ds.Tables[0].Rows[0].ItemArray[58].ToString();
        lblextramt.Text = ds.Tables[0].Rows[0].ItemArray[60].ToString();
        DataSet dsdate = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bulletmaster cls_book = new NewAdbooking.Classes.bulletmaster();
            dsdate = cls_book.pubcenter(Session["compcode"].ToString(), Session["center"].ToString(), Session["username"].ToString(), Session["dateformat"].ToString(), pextra1, pextra2);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bulletmaster cls_book = new NewAdbooking.classesoracle.bulletmaster();
            dsdate = cls_book.pubcenter(Session["compcode"].ToString(), Session["center"].ToString(), Session["username"].ToString(), Session["dateformat"].ToString(), pextra1, pextra2);
        }
        if (dsdate.Tables[0].Rows.Count > 0)
        {
            string path = "billing/Images/" + dsdate.Tables[0].Rows[0]["LOGO_FILE_PATH"].ToString();
            float ht = 40;
            if (System.IO.File.Exists(Server.MapPath(path)))
            {
                divimglogo.InnerHtml = "<img style='padding-right:5px;' src='" + path + "' height='" + ht + "'>";
            }
            lbcompaddress.Text = dsdate.Tables[0].Rows[0]["ADD1"].ToString() + "&nbsp;" + dsdate.Tables[0].Rows[0]["STREET"].ToString() + "&nbsp;" + "Phone-" + dsdate.Tables[0].Rows[0]["PHONE1"].ToString() + "-" + dsdate.Tables[0].Rows[0]["PHONE2"].ToString() + "&nbsp" + "Fax-" + dsdate.Tables[0].Rows[0]["Fax"].ToString() + "-" + dsdate.Tables[0].Rows[0]["Fax1"].ToString();
            lblbranch.Text = dsdate.Tables[0].Rows[0]["CITY_NAME"].ToString();
        }
    }

    public void setReceiptData()
    {
//==================**********************************==========================//
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
        if(eyecatcher1=="BO0")
        {
            fontweight = "<b>";//"<p style=\"font-weight:bold;\">";
        }
        lblmatter.InnerHtml = fontweight+"<span style=\"border:0px solid;float:left;" + "font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" +lblmatter1;
//==================**********************************==========================//
        agddxt.Text = agddxt1;
        lbaddress.Text = lbaddress1;
        txtcliname.Text = txtcliname1;
        lbcaption.Text = lbcaption1;
        lbrcbtxt.Text = lbrcbtxt1;
        runtxt.Text = runtxt1;
        adcat.Text = adcat1;
        lbronodate.Text = lbronodate1;
        insertiontxt.Text = insertiontxt1;
        txtgrossamt.Text = txtgrossamt1;
        netpay.Text = netpay1;
        lbwordinrupees.Text = lbwordinrupees1;
        dynamictable.Text = dynamictable1;
        lbbilltype.Text = lbbilltype1;
        lblnetpayable.Text = lblnetpayable1;
        lblboxtxt.Text = lblbox1;
        divimg.InnerHtml = divimg1;
        lblcatdata.Text = lblcatdata1;
        txtranscrg.Text = tanscrg;
        txtbullot.Text = bulletchrg1;
        txtextra.Text = extrarate1;
        txtextramt.Text = txtextramt1;
        if (agddxt1 == "")
        {
            agencytxt.Text = "Direct Client";
            agddxt.Text = "";
        }
        if (lblmatter1 == "" || lblmatter1 == null)
        {
            lblmatter.Attributes.Add("style", "display:none");
        }
        //txtpackname.Text = txtpackname1;
        //lbpakgrate.Text=lbpakgrate1;
        //lbextrapre.Text=lbextrapre1;
        //lbextpre.Text = lbextpre1;
        //txtagr.Text=txtagr1;
        //lbtrade1.Text=lbtrade11;
        //lbadtd.Text=lbadtd1;
        //lbadtdtxt.Text=lbadtdtxt1;
        //txtdiscal.Text=txtdiscal1;
        //lblmatter.Text = lblmatter1;
        //lbemailtxt.Text = lbemailtxt1;
        //lblcashdisctxt.Text = lblcashdisc1;
        //if (lblprevbill1 == "")
        //{
        //    lblprevbill.Visible = false;
        //    lblprevbilltxt.Visible = false;
        //    lblprevbilltxt.Style.Add("Display", "none");
        //    lblprevbill.Style.Add("Display", "none");
        //}
        //else { lblprevbilltxt.Text = String.Format("{0:0.00}", Convert.ToDouble(lblprevbill1)); }
        //if (lbextrapre1=="0.00")
        //{
        //    tr3.Attributes.Add("style", "display:none");
        //}
        //if (lbextrapre1 == "0.00")
        //{
        //    tr3.Attributes.Add("style", "display:none");
        //}
        // if (lblbox1 == "0.00")
        //{
        //    tr8.Attributes.Add("style", "display:none");
        //}
         //if (netpay1 == "0.00")
         //{
         //    tr10.Attributes.Add("style", "display:none");
         //}
         //if (lbadtdtxt1 == "0.00")
         //{
         //    tr6.Attributes.Add("style", "display:none");
         //}
         //if (txtdiscal1 == "0.00")
         //{
         //    tr5.Attributes.Add("style", "display:none");
         //}
         //if (lblcashdisc1 == "0.00")
         //{
         //    tr7.Attributes.Add("style", "display:none");
         //}
    }
   
}