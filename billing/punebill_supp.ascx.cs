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


public partial class punebill_supp : System.Web.UI.UserControl
{
    public  string _agency;
    public  string _package;
    public  string _insertion;
    public  string _bookingid;
    public  string _height;
    public  string _width;
    public  string _color;
    public  string _volume;
    public  string _adcat;
    public  string _pageposition;
    public  string _scheme;
    public  string _rono_date;

    public  string _publication;

    public  string _rundate;
    public  string _packgerate;
    public  string _orderno;
    public  string _amount;
    public  string _discount;
    public  string _edition1;
    public  string _client;
    public  string _agencycode;
    public  string _agddxt1;
    public  string _city;
    public  string _tbl;
    public  string _currency;
    public  string _boxcharges;
    public  string _packagelength;
    public  string _packagecode;
    public  string _id;
    public  string _invoiceno;
    public  string _totalinsertion;
    public  string _bookingdate;
    public  string _orderdate;
    public  string _valueofradio;
    public string _qbc;
    public  string _editionnameplus;
    public  string _auto;
    public  string branch;
    public  string _agcode;
    public  string _fromdate;
    public  string _dateto;
/// <summary>
/// //////////////////////
/// 
/// 
/// </summary>
    public punebill_supp()
    {

        _agency = "";
        _package = "";
        _insertion = "0";
        _bookingid = "";
        _height = "";
        _width = "";
        _color = "";
        _volume = "";
        _adcat = "";
        _pageposition = "";
        _scheme = "";
        _rono_date = "";
        _agency = "";
        _publication = "";
        _rundate = "";
        _packgerate = "";
        _orderno = "";
        _amount = "";
        _discount = "";
        _edition1 = "";
        _client = "";
        _agencycode = "";
        _agddxt1 = "";
        _city = "";
        _currency = "";
        _boxcharges = "";
        _packagelength = "";
        _packagecode = "";
        _id = "";
        _invoiceno = "";
        _totalinsertion = "";
        _bookingdate = "";
        _orderdate = "";
        _valueofradio = "";
        _qbc = "";
        _editionnameplus = "";
        _agcode = "";
        _fromdate = "";
        _dateto = "";
    }

    public string agency { get { return _agency; } set { _agency = value; } }
    public string package { get { return _package; } set { _package = value; } }
    public string insertion { get { return _insertion; } set { _insertion = value; } }
    public string bookingid { get { return _bookingid; } set { _bookingid = value; } }
    public string height { get { return _height; } set { _height = value; } }
    public string width { get { return _width; } set { _width = value; } }
    public string color { get { return _color; } set { _color = value; } }
    public string volume { get { return _volume; } set { _volume = value; } }
    public string adcat1 { get { return _adcat; } set { _adcat = value; } }
    public string pageposition { get { return _pageposition; } set { _pageposition = value; } }
    public string scheme1 { get { return _scheme; } set { _scheme = value; } }
    public string rono_date { get { return _rono_date; } set { _rono_date = value; } }

    public string publication { get { return _publication; } set { _publication = value; } }
    public string rundate1 { get { return _rundate; } set { _rundate = value; } }
    public string packgerate { get { return _packgerate; } set { _packgerate = value; } }
    public string orderno1 { get { return _orderno; } set { _orderno = value; } }
    public string discount { get { return _discount; } set { _discount = value; } }
    public string amount { get { return _amount; } set { _amount = value; } }
    public string edition1 { get { return _edition1; } set { _edition1 = value; } }
    public string Client { get { return _client; } set { _client = value; } }

    public string agencycode { get { return _agencycode; } set { _agencycode = value; } }

    public string agddxt1 { get { return _agddxt1; } set { _agddxt1 = value; } }
    public string city { get { return _city; } set { _city = value; } }
    public string tbl { get { return _tbl; } set { _tbl = value; } }
    public string currency { get { return _currency; } set { _currency = value; } }
    public string boxcharges { get { return _boxcharges; } set { _boxcharges = value; } }
    public string packagelength { get { return _packagelength; } set { _packagelength = value; } }
    public string packagecode { get { return _packagecode; } set { _packagecode = value; } }
    public string id { get { return _id; } set { _id = value; } }
    public string invoiceno { get { return _invoiceno; } set { _invoiceno = value; } }
    public string totalinsertion { get { return _totalinsertion; } set { _totalinsertion = value; } }

    public string bookingdate { get { return _bookingdate; } set { _bookingdate = value; } }
    public string orderdate { get { return _orderdate; } set { _orderdate = value; } }
    public string valueofradio { get { return _valueofradio; } set { _valueofradio = value; } }
    public string qbc { get { return _qbc; } set { _qbc = value; } }
    public string editionnameplus { get { return _editionnameplus; } set { _editionnameplus = value; } }

    public string agcode { get { return _agcode; } set { _agcode = value; } }
    public string fromdate { get { return _fromdate; } set { _fromdate = value; } }
    public string dateto { get { return _dateto; } set { _dateto = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/punebill.xml"));
        lbemail.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        lbpune.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        agencytxt.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbclientadd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbclientna.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbcap.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbddate.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbrodat.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbpackagena.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbpackagerate.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lbinsertionnumber.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        lblamount.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        lbgr.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
    }

    public void setcardlast()
    {

        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double amt1 = 0;
        double amt2 = 0;
        double comm2 = 0;
        double boxamt2 = 0;
        double abc = 0;
        double abc1 = 0;
        double amtinpr = 0;
        double abc2 = 0;

        string maxdate = "";

        DataSet ds4 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();
            ds4 = objvalues1.selectlast(bookingid, Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds4 = objvalues1.selectlastnew_supp(bookingid, Session["dateformat"].ToString(), fromdate, dateto);
        }

        lbemailtxt.Text = ds4.Tables[0].Rows[0]["EmailID"].ToString();

        agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
        agddxt.Text = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
        lbaddress.Text = ds4.Tables[0].Rows[0]["Agency_address"].ToString();
        lbpakgrate.Text = ds4.Tables[0].Rows[0]["PACKAGERATE"].ToString();
        insertiontxt.Text = ds4.Tables[0].Rows[0]["No_of_insertion"].ToString();

        txtcliname.Text = ds4.Tables[0].Rows[0]["client"].ToString();
        string comm1 = ds4.Tables[0].Rows[0].ItemArray[23].ToString();
        if (comm1 != "")
        {

            comm2 = Convert.ToDouble(comm1);
        }
        string boxamt1 = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
        if (boxamt1 != "")
        {
            boxamt2 = Convert.ToDouble(boxamt1);
        }
        runtxt.Text = ds4.Tables[0].Rows[0]["SYSDATE1"].ToString();
        ldduedate.Text = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
        adcat.Text = ds4.Tables[0].Rows[0]["Adv_Type_Name"].ToString();
        lbronodate.Text = ds4.Tables[0].Rows[0]["RO_No"].ToString() + "-" + ds4.Tables[0].Rows[0]["RO_Date"].ToString();
        txtpackname.Text = ds4.Tables[0].Rows[0]["Caption"].ToString();
        lbcompanyname.Text = ds4.Tables[0].Rows[0]["companyname"].ToString();
        lbpunetxt.Text = ds4.Tables[0].Rows[0]["pan"].ToString();
        lbnaam.Text = "AURANGABAD".ToString();
        lbterms.Text = ds4.Tables[0].Rows[0]["companyname"].ToString();
        string pr = ds4.Tables[0].Rows[0]["expr"].ToString();
        double pr1 = 0;
        if (pr != "")
        {
            pr1 = Convert.ToDouble(pr);
        }
        lbextpre.Text = "Ex.Premium" + "(" + pr1 + ")" + "%";
        string dis = ds4.Tables[0].Rows[0]["td"].ToString();
        double dis1 = 0;
        Double DISCAMT = 0;
        if (dis != "")
        {
            dis1 = Convert.ToDouble(dis);
        }

        string disn = ds4.Tables[0].Rows[0]["adtd"].ToString();
        double disn1 = 0;
        Double DISCADTD = 0;
        if (disn != "")
        {
            disn1 = Convert.ToDouble(disn);
        }
        lbadtd.Text = "Ad Td" + "(" + disn1 + ")" + "%";
        String dytbl;
        dytbl = "";

        dytbl += "<table width='450px'align='left' cellpadding='0' cellspacing='0'>";
        {
            DataSet dsb = new DataSet();
            dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
            dytbl += "<tr align=center >";
            dytbl += "<td class='insertiontxtclass1' align='center' width='150px' >" + dsb.Tables[0].Rows[0].ItemArray[26].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' align='center' width='70px'>" + dsb.Tables[0].Rows[0].ItemArray[27].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' align='center'  width='5px' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='32px' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";
            dytbl += "</tr>";
        }
        int insnum_cou = ds4.Tables[0].Rows.Count;
        string insnum_cou1 = ds4.Tables[0].Rows[0].ItemArray[24].ToString();

        string maxinsert = "";
        for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
        {
            dytbl += "<tr align=center>";
            dytbl += "<td class='insertiontxtclass'align='center' width='150px' >" + ds4.Tables[0].Rows[i]["Edition"].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass' align='center 'width='20px' >" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";

            if (ds4.Tables[0].Rows[i]["Height"].ToString() != "")
            {
                dytbl += "<td  align='center' width='15px' >" + ds4.Tables[0].Rows[i]["Height"].ToString() + "*" + ds4.Tables[0].Rows[i]["Width"].ToString() + "</td>";
            }
            else
            {
                dytbl += "<td width=63px  align=center>---</td>";
            }
            if (ds4.Tables[0].Rows[i]["Color_code"].ToString() != "")
            {
                dytbl += "<td  class='insertiontxtclass' align='center' width='20px' >" + ds4.Tables[0].Rows[i]["Color_code"].ToString() + "</td>";
            }
            else
            {
                dytbl += "<td  class='middleforbill'align='center' >-</td>";

            }
            dytbl += "<td class='insertiontxtclass'align='center' width='20px' >" + ds4.Tables[0].Rows[i]["Page_No"].ToString() + "</td>";
            string cardrt = ds4.Tables[0].Rows[i]["Card_Rate"].ToString();
            double cdr = 0;
            if (cardrt != "")
            {
                cdr = Convert.ToDouble(cardrt);
            }
            dytbl += "<td class='insertiontxtclass' align='center' width='20px'  >" + cdr.ToString("F2") + "</td>";
            string grossamt = ds4.Tables[0].Rows[i]["Gross_Rate"].ToString();
            if (grossamt != "")
            {
                abc = Convert.ToDouble(grossamt);
            }

            abc1 = abc1 + abc;
            dytbl += "</tr>";

            maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();
            
        }

        abc2 = abc1;

        txtgr.Text = abc1.ToString("F2");


        amtinpr = ((abc1 * pr1) / 100);
        lbextrapre.Text = amtinpr.ToString("F2");
        abc1 = abc1 - amtinpr;
        amount1.Text = abc1.ToString("F2");


        DISCAMT = abc2 * dis1 / 100;

        txtdiscal.Text = DISCAMT.ToString("F2");

        lbtrade1.Text = "TD" + "(" + dis + ")" + "%";
        DISCADTD = abc2 * disn1 / 100;
        lbadtdtxt.Text = DISCADTD.ToString("F2");

        double net = abc2 - ((abc2 * disn1 / 100) + (DISCAMT));
        netpay.Text = net.ToString("F2");

        NumberToEngish obj = new NumberToEngish();
        lbwordinrupees.Text = obj.changeNumericToWords(netpay.Text) + "Only";
        dytbl += "</table>";
        dynamictable.Text = dytbl;
        showtable.Visible = true;
        DataSet ds5 = new DataSet();
        if (valueofradio == "2")
        {

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass.Classes.billing_save();
                ds5 = fetchinvoice.fetchlast(bookingid);
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();

                ds5 = fetchinvoice.fetchlast_supp(bookingid);
            }


            txtinvoice.Text = ds5.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        else
        {
            txtinvoice.Text = invoiceno.ToString();
        }

        if (invoiceno == "XXXX")
        {
            lbbilltype.Text = "PROVISIONAL INVOICE";
        }
        else
        {
            lbbilltype.Text = "INVOICE";
        }


    }


}