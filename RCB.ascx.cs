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

public partial class RCB : System.Web.UI.UserControl
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
    public static string _lblimg;
    public static string _adsubcat;
    public static string _payname1;
    public static string _chkno1;
    public static string _chkdt1;
    public static string _bankname1;
    public static string _lblspldis;
    public static string _lblspldis1;
    public static string _subtfcat;
    public string _chkvalue_length;
    public string _eyecatcher;
    public RCB()
    {
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
        _lblimg = "";
        _adsubcat = "";
        _payname1="";
        _chkno1="";
        _chkdt1="";
        _bankname1="";
        _lblspldis = "";
        _lblspldis1 = "";
        _subtfcat = "";
        _chkvalue_length="";
        _eyecatcher = "";
    }

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
    public string lblimg1 { get { return _lblimg; } set { _lblimg = value; } }
    public string adsubcat { get { return _adsubcat; } set { _adsubcat = value; } }
    public string payname { get { return _payname1; } set { _payname1 = value; } }
    public string chkno { get { return _chkno1; } set { _chkno1 = value; } }
    public string chkdt { get { return _chkdt1; } set { _chkdt1 = value; } }
    public string banknm { get { return _bankname1; } set { _bankname1 = value; } }
    public string lblspldis { get { return _lblspldis; } set { _lblspldis = value; } }
    public string lblspldis1 { get { return _lblspldis1; } set { _lblspldis1 = value; } }
    public string subtfcat { get { return _subtfcat; } set { _subtfcat = value; } }
    public string chkvalue_length { get { return _chkvalue_length; } set { _chkvalue_length = value; } }
    public string eyecatcher { get { return _eyecatcher; } set { _eyecatcher = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/classifiedreceipt_bill.xml"));
       // lblpublications.Text = ds.Tables[0].Rows[0].ItemArray[49].ToString();
        //lbemail.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        //lbpune.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        //lbcompaddress.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
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
       // lbgr.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
       //// lbtrade1.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        lbadtd.Text = "Eye Catcher";
      //  lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        lbrcb.Text = ds.Tables[0].Rows[0].ItemArray[48].ToString();
        lblprevbill.Text = ds.Tables[0].Rows[0].ItemArray[50].ToString();
        //lblcashdisc.Text = ds.Tables[0].Rows[0].ItemArray[51].ToString();
        lblbox.Text = ds.Tables[0].Rows[0].ItemArray[54].ToString();
    }

    public void setReceiptData()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.classifiedreceipt shtr = new NewAdbooking.classesoracle.classifiedreceipt();
            ds = shtr.bindaddress(Session["compcode"].ToString(), Session["center"].ToString(), "", "");


        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.classifiedreceipt shtr = new NewAdbooking.Classes.classifiedreceipt();
            ds = shtr.bindaddress(Session["compcode"].ToString(), Session["center"].ToString(), "", "");
        }
        else
        {

            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["center"].ToString(), "", "" };
            string procedureName = "adgetbindaddress";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        lblpublications.Text = Session["comp_name"].ToString();
        //lbwalujadd.Text = ds.Tables[0].Rows[0]["Pub_Cent_name"].ToString() + " " + ds.Tables[0].Rows[0]["Add1"].ToString() + " " + ds.Tables[0].Rows[0]["Street"].ToString()
        //    + " " + ds.Tables[0].Rows[0]["Dist_Code"].ToString() + "," + ds.Tables[0].Rows[0]["Zip"].ToString() + "Phone No.=" + ds.Tables[0].Rows[0]["Phone1"].ToString()
        //    + "," + ds.Tables[0].Rows[0]["Phone2"].ToString() + "Fax:=" + ds.Tables[0].Rows[0]["Fax"].ToString() + "&nbsp; Email Id:= " + ds.Tables[0].Rows[0]["EmailID"].ToString();

        lbcompaddress.Text = ds.Tables[0].Rows[0]["Add1"].ToString() + " " + ds.Tables[0].Rows[0]["Street"].ToString() + " " + ds.Tables[0].Rows[0]["dist_code"].ToString()
            + " " + ds.Tables[0].Rows[0]["Zip"].ToString() +"</BR>"+ "Phone No.=" + ds.Tables[0].Rows[0]["Phone1"].ToString()
            + "," + ds.Tables[0].Rows[0]["Phone2"].ToString() + "Fax:=" + ds.Tables[0].Rows[0]["Fax"].ToString() + "," + ds.Tables[0].Rows[0]["Fax1"].ToString() + "</BR>" + "Email Id:= " + ds.Tables[0].Rows[0]["EmailID"].ToString();
        agddxt.Text = agddxt1;
        lbaddress.Text = lbaddress1;
        txtcliname.Text = txtcliname1;
        lbcaption.Text = lbcaption1;
        txtpackname.Text = txtpackname1;
        lbpakgrate.Text=lbpakgrate1;
        lbrcbtxt.Text=lbrcbtxt1;
        runtxt.Text=runtxt1;
        adcat.Text=adcat1;
        Label3.Text = adsubcat;
        lbronodate.Text=lbronodate1;
        insertiontxt.Text=insertiontxt1;
        txtgrossamt.Text=txtgrossamt1;
        lbpunetxt.Text = lbpunetxt1;
        lbextrapre.Text=lbextrapre1;
        lbextpre.Text = lbextpre1;
        //txtagr.Text=txtagr1;
        lbtrade1.Text=lbtrade11;
        lbadtd.Text=lbadtd1;
        lbadtdtxt.Text = eyecatcher;
        txtdiscal.Text=txtdiscal1;
        netpay.Text=netpay1;
        lbwordinrupees.Text = lbwordinrupees1;
        lblmatter.Text = lblmatter1;
        dynamictable.Text = dynamictable1;
        lbbilltype.Text = lbbilltype1;
        lbpune.Text = lbpune1;
        lbemailtxt.Text = lbemailtxt1;
        lblnetpayable.Text = lblnetpayable1;
        lblcashdisc.Text = lblspldis;
        lblcashdisctxt.Text = lblspldis1;
        lblboxtxt.Text = lblbox1;
        lblimg.InnerHtml = lblimg1;
        lblcatdata.Text=lblcatdata1;

        lblpay.Text = payname;
        lblchno.Text = chkno;
        lblchkdt.Text = chkdt;
        lblbanknm.Text = banknm;
        Label7.Text = subtfcat;
        if (lblprevbill1 == "")
        {
            lblprevbill.Visible = false;
            lblprevbilltxt.Visible = false;
            lblprevbilltxt.Style.Add("Display", "none");
            lblprevbill.Style.Add("Display", "none");
        }
        else { lblprevbilltxt.Text = String.Format("{0:0.00}", Convert.ToDouble(lblprevbill1)); }
        if (lbextrapre1=="0.00")
        {
            tr3.Attributes.Add("style", "display:none");
        }
        if (lbextrapre1 == "0.00")
        {
            tr3.Attributes.Add("style", "display:none");
        }
        // if (lblbox1 == "0.00")
        //{
        //    tr8.Attributes.Add("style", "display:none");
        //}
         //if (netpay1 == "0.00")
         //{
         //    tr10.Attributes.Add("style", "display:none");
         //}
        if (eyecatcher == "0.00")
        {
            tr6.Attributes.Add("style", "display:none");
        }
         if (txtdiscal1 == "0.00")
         {
             tr5.Attributes.Add("style", "display:none");
         }
         if (lblcashdisc1 == "0.00")
         {
             tr7.Attributes.Add("style", "display:none");
         }


         if (chkvalue_length == "yes")
         {

             showtable.Attributes.Add("style", "page-break-after:always;");

         }
    }
   
}
