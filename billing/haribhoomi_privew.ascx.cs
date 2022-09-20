using System;

using System.Collections;
using System.Configuration;
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

public partial class haribhoomi_privew : System.Web.UI.UserControl
{
    public string _agency;
    public string _package;
    public string _insertion;
    public string _bookingid;
    public string _height;
    public string _width;
    public string _color;
    public string _volume;
    public string _adcat;
    public string _pageposition;
    public string _scheme;
    public string _rono_date;

    public string _publication;

    public string _rundate;
    public string _packgerate;
    public string _orderno;
    public string _amount;
    public string _discount;
    public string _edition1;
    public string _client;
    public string _agencycode;
    public string _agddxt1;
    public string _city;
    public string _tbl;
    public string _currency;
    public string _boxcharges;
    public string _packagelength;
    public string _packagecode;
    public string _id;
    public string _invoiceno;
    public string _totalinsertion;
    public string _bookingdate;
    public string _orderdate;
    public string _valueofradio;
    public string _qbc;
    public string _editionnameplus;
    public string _fromdate;
    public string _dateto;
    public string _orignaldupli;
    public string _remark;
    public haribhoomi_privew()
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
        _fromdate = "";
        _dateto = "";
        _orignaldupli = "";
        _remark = "";


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
    public string orignaldupli { get { return _orignaldupli; } set { _orignaldupli = value; } }

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

    public string fromdate { get { return _fromdate; } set { _fromdate = value; } }
    public string dateto { get { return _dateto; } set { _dateto = value; } }
    public string remark { get { return _remark; } set { _remark = value; } }
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/hari_classified_last.xml"));
        lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        lblcap.Text = ds.Tables[0].Rows[0].ItemArray[72].ToString();
        lblrefno.Text = ds.Tables[0].Rows[0].ItemArray[70].ToString();
        //lblagencyname.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbladd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblkey.Text = ds.Tables[0].Rows[0].ItemArray[68].ToString();
        lb_total.Text = ds.Tables[0].Rows[0].ItemArray[66].ToString();
        lbtrade1.Text = ds.Tables[0].Rows[0].ItemArray[53].ToString();
        lblbilldt.Text = ds.Tables[0].Rows[0].ItemArray[71].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[58].ToString();
        publ.Text = ds.Tables[0].Rows[0].ItemArray[73].ToString();
        hribhomi_text.Text = ds.Tables[0].Rows[0].ItemArray[75].ToString();
        splchagr.Text = ds.Tables[0].Rows[0].ItemArray[76].ToString();

    }

    public void setcard()
    {
        string day = "";
        string month = "";
        string year = "";
        string date = "";
        string street = "";
        double finalamount = 0;
        double discountint = 0;
        double grossamt = 0;
        double traddis = 0;
        double adddis = 0;
        double addchr = 0;
        int totinsertnewint = 0;
        double finalamount1 = 0;
        double amt5 = 0;
        float ht = 40;
        
        String dytbl;
        dytbl = "";
        int count11 = Convert.ToInt16(insertion);
        int packlength22 = Convert.ToInt16(packagelength);
        string packagecode11 = packagecode.ToString();

        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();
        int srl = 1;
        int packlength = 0;
        int packlength1 = 0;
        string ciobookingid = id.ToString();
        string editionname = "";
        int totinsert = Convert.ToInt16(totalinsertion);
        string i12 = insertion.ToString();
        string[] packagecode1 = packagecode11.Split(',');
        int c1 = packagecode1.Length;

        //====================================
        for (packlength = 0; packlength < packagecode1.Length; packlength++)
        {
            if (packagecode1.Length >= 1)
            {
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
                    // ds3 = objedition.edition(packagecode1[packlength], Session["compcode"].ToString());
                    ds3 = objedition.edition(packagecode1[packlength], Session["compcode"].ToString());
                   // editionname = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                    if (editionname=="")
                    {
                         editionname = ds3.Tables[0].Rows[0].ItemArray[0].ToString() ;
                    }
                    else
                    {
                         editionname = editionname +"+"+ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                   
                    //    edicode = edicode + "," + ds4.Tables[2].Rows[je].ItemArray[0].ToString();

                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.invoice objedition = new NewAdbooking.BillingClass.classesoracle.invoice();
                    ds3 = objedition.edition(packagecode1[packlength], Session["compcode"].ToString());

                }
            }
        }

        string editionnametest = editionname;
        //==================================
        string[] editionnametest1 = editionnametest.Split('+');
        int counted = editionnametest1.Length;
        if (counted > 1)
        {
            c1 = counted;
            packagecode1 = editionnametest.Split('+');
        }
        for (packlength = 0; packlength < c1; packlength++)
        {
            if (counted <= 1)
            {
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
                    ds3 = objedition.edition(packagecode1[packlength], Session["compcode"].ToString());
                    editionname = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.invoice objedition = new NewAdbooking.BillingClass.classesoracle.invoice();
                    ds3 = objedition.edition(packagecode1[packlength], Session["compcode"].ToString());
                    editionname = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                }
            }
            else
            {
                editionname = packagecode1[packlength];
            }
            int editionlen = 0;
            string[] editionnamenew = editionname.Split('+');
            int counteditin = editionnamenew.Length;
            string ediplusdate = "";

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                for (editionlen = 0; editionlen < counteditin; editionlen++)
                {
                    NewAdbooking.BillingClass.classesoracle.invoice objedition = new NewAdbooking.BillingClass.classesoracle.invoice();
                    ds4 = objedition.editiondate(editionnamenew[editionlen].Trim(), ciobookingid, Session["compcode"].ToString(), Session["dateformat"].ToString());
                    if (ediplusdate == "")
                    {
                        ediplusdate = editionnamenew[editionlen] + ds4.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                    else
                    {
                        ediplusdate = ediplusdate + "," + editionnamenew[editionlen] + ds4.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                }
                //txtpackname.Text = ediplusdate.ToString();
            }
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.invoice objvalues = new NewAdbooking.BillingClass.Classes.invoice();
                ds4 = objvalues.values_bill(ciobookingid, editionname, i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.invoice objvalues = new NewAdbooking.BillingClass.classesoracle.invoice();
                ds4 = objvalues.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
            }
            adcat.Text = ds4.Tables[0].Rows[0].ItemArray[12].ToString();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/bill.xml"));
            //To get the Branch Address...........................
            DataSet dsbranch = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.invoice objvalues = new NewAdbooking.BillingClass.Classes.invoice();
                dsbranch = objvalues.values_bill(Session["compcode"].ToString(), Session["revenue"].ToString(), "");
            }
            if (dsbranch.Tables[0].Rows.Count > 0)
            {
                //branchadd.Text = dsbranch.Tables[0].Rows[0]["Add1"].ToString();
                //bhranchadd1.Text = "Ph:-" + dsbranch.Tables[0].Rows[0]["Phone1"].ToString() + "-" + dsbranch.Tables[0].Rows[0]["Phone2"].ToString() + "," + "fax:- " + dsbranch.Tables[0].Rows[0]["fax"].ToString();
            }
            //====================================================//
            //Sign Image
            string path = "Images/" + ds.Tables[1].Rows[0].ItemArray[1].ToString();
            if (System.IO.File.Exists(Server.MapPath(path)))
            {
                //divimg.InnerHtml = "<img src='" + path + "' height='" + ht + "'>";
            }
            // agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[1].ToString();
            ////////////////////
            if (ds4.Tables[0].Rows[0]["bill2"].ToString() == "" || ds4.Tables[0].Rows[0]["bill2"].ToString() == null)
            {
               
                agddxt.Text = ds4.Tables[0].Rows[0]["Agency"].ToString();
                agencyaddtxt.Text =  ds4.Tables[0].Rows[0]["add1"].ToString();
                lbltextmain.Text = "Agency";
            }
            else
            {
                string[] addname = ds4.Tables[0].Rows[0]["agenadd"].ToString().Split("$$".ToCharArray());
                agencyaddtxt.Text = addname[0];
                agddxt.Text = "";// addname[2];
                lbltextmain.Text = "Client";
            }
            if (agddxt.Text == ds4.Tables[0].Rows[0]["Agency"].ToString())
            {
                lbladrelpar.Text = "Client";
                txtcliname.Text = ds4.Tables[0].Rows[0]["Client"].ToString();
            }
            else if (agddxt.Text == ds4.Tables[0].Rows[0]["Client"].ToString())
            {
                lbladrelpar.Text = "Agency";
                txtcliname.Text =ds4.Tables[0].Rows[0]["Agency"].ToString();
            }
            else
            {
               lbladrelpar.Text = "Client";
                txtcliname.Text =  ds4.Tables[0].Rows[0]["Client"].ToString();

            }

            string[] addname1 = ds4.Tables[0].Rows[0]["street_login"].ToString().Split("~".ToCharArray());
            lbcompaddress.Text = addname1[0];
            txtmailid.Text = addname1[1];
            lbemailtxt.Text = "Ph:-" + addname1[2] + "-" + addname1[3] + "," + "Fax:-" + addname1[4] + "," + addname1[5];

            //if (ds4.Tables[0].Rows[0]["Address"].ToString() != "")
            //{
            //    lbcompaddress.Text = ds4.Tables[0].Rows[0]["Address"].ToString();
            //}
            if (ds4.Tables[0].Rows[0]["agency_sub_code"].ToString() != "")
            {
                txtagcode.Text = ds4.Tables[0].Rows[0]["agency_sub_code"].ToString();
            }
            /////////////////////
            if (ds4.Tables[0].Rows[0]["insert_date"].ToString() != "")
            {
                billdt.Text = ds4.Tables[0].Rows[0]["insert_date"].ToString();
            }
            if (ds4.Tables[0].Rows[0]["key_no"].ToString() != "")
            {
                txtkey.Text = ds4.Tables[0].Rows[0]["key_no"].ToString();
            }
            if (ds4.Tables[0].Rows[0]["RoNo."].ToString() != "")
            {
                txtrefno.Text = ds4.Tables[0].Rows[0]["RoNo."].ToString();
            }
            if (ds4.Tables[0].Rows[0]["Ro_Date"].ToString() != "")
            {
                txtrodate.Text = ds4.Tables[0].Rows[0]["Ro_Date"].ToString();
            }
            // street = ds4.Tables[0].Rows[0]["street"].ToString();
            // agencyaddtxt.Text = ds4.Tables[0].Rows[0]["add1"].ToString();
            //agencyaddtxt.Text = agencyaddtxt.Text + "," + street;
            // lblagncode.Text = ds4.Tables[0].Rows[0]["agency_sub_code"].ToString();
            // txtpinno.Text = ds4.Tables[0].Rows[0]["pin_code"].ToString();
            grossamt = Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_Rate"].ToString());

if(ds4.Tables[0].Rows[0]["trade_disc"].ToString()!="")
{
            traddis = Convert.ToDouble(ds4.Tables[0].Rows[0]["trade_disc"].ToString());
}
else
{
  traddis =0;

}
            // traddis = grossamt * traddis / 100;
            if (ds4.Tables[0].Rows[0]["special_discount"].ToString() != "")
            {
                adddis = Convert.ToDouble(ds4.Tables[0].Rows[0]["special_discount"].ToString());
                if (ds4.Tables[0].Rows[0]["special_charges"].ToString() != "")
                {
                    addchr = Convert.ToDouble(ds4.Tables[0].Rows[0]["special_charges"].ToString());
                }
                else
                {
                    addchr = 0;
                }
            }
            finalamount = grossamt - traddis - adddis + addchr;
            // lblgross.Text = Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_Rate"]).ToString("F2");
            // lblext.Text = "---";
            //if (ds4.Tables[0].Rows[0]["street_login"].ToString() != "")
            //{
            //    txtmailid.Text = ds4.Tables[0].Rows[0]["street_login"].ToString();
            //}
            if (ds4.Tables[0].Rows[0]["pan"].ToString() != "")
            {
                txtpanno.Text = ds4.Tables[0].Rows[0]["pan"].ToString();
            }
            // lblnetamt.Text = finalamount.ToString("F2");
            netpay.Text = Math.Round(finalamount + 0.01).ToString();
            if (ds4.Tables[0].Rows[0]["Cap"].ToString() != "")
            {
                txtcaption.Text = ds4.Tables[0].Rows[0]["Cap"].ToString() + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + ds4.Tables[0].Rows[0]["product"].ToString();
            }
            else if (ds4.Tables[0].Rows[0]["product"].ToString() != "")
            {
                txtcaption.Text = "--" + "&nbsp&nbsp" + "/" + "&nbsp&nbsp"  + ds4.Tables[0].Rows[0]["product"].ToString();
            }
            else if (ds4.Tables[0].Rows[0]["Cap"].ToString() != "")
            {
                txtcaption.Text = ds4.Tables[0].Rows[0]["Cap"].ToString() + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + "--";
            } else
            {
                txtcaption.Text = "--" + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + "--";
            }
            // txtpackname.Text = ds4.Tables[1].Rows[0]["package_name"].ToString();
            string totinsertnew = ds4.Tables[0].Rows[0].ItemArray[27].ToString();
            if (totinsertnew != "")
            {
                totinsertnewint = Convert.ToInt16(totinsertnew);
            }
            else
            {
                totinsertnewint = 0;
            }
            string bx = ds4.Tables[0].Rows[0].ItemArray[21].ToString();
            double bx2 = 0;
            if (bx == "")
            {
            }
            else
            {
                bx2 = Convert.ToDouble(bx);
                bx2 = bx2 / totinsertnewint;
                // boxcharges1.Text = bx2.ToString();
            }
            string compname = "<B>The Statesman</B>";
            string compname25 = "<B>The Statesman</B>";
            if (Session["revenue"].ToString() == "ja1")
            {
                lbcompanyname.Text = compname25;
            }
            else
            {
                lbcompanyname.Text = compname;
            }
            string rev = ds4.Tables[0].Rows[0]["Print_cent_name"].ToString();
            //string revenu = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All cheques/drafts should be in favour of The Statesman & payable at,&nbsp;" + rev + ".<br /> 2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br /> 3:&nbsp;22% Interest will be charged on overdue bills.<br />4:&nbsp;All disputes are subject to&nbsp;&nbsp;" + rev + " &nbsp;&nbsp;jurisdiction.<br />5:&nbsp;For payment by NEFT/RTGS, kindly send e-mail to akbasu@thestateman.net ";
            //string revenu25 = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All cheques/drafts should be in favour of The Statesman & payable at,&nbsp;" + compname25 + " , &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;" + rev + ".<br /> 2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br /> 3:&nbsp;22% Interest will be charged on overdue bills.<br /> 4:&nbsp;All disputes are subject to&nbsp;&nbsp;" + rev + " &nbsp;&nbsp;jurisdiction.<br />5:&nbsp;For payment by NEFT/RTGS, kindly send e-mail to akbasu@thestateman.net<br /> ";

            string revenu = "<b>This being a computer generated bill,does not reqire a signature</b>";



            hidedata.Text = revenu;
            txtinvoice.Text = invoiceno.ToString();
            if (Session["dateformat"].ToString() == "dd/mm/yyyy".ToString())
            {
                DateTime dt = System.DateTime.Now;
                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = day + "/" + month + "/" + year;
            }
            else
                if (Session["dateformat"].ToString() == "mm/dd/yyyy".ToString())
                {
                    DateTime dt = System.DateTime.Now;
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = month + "/" + day + "/" + year;

                }
                else
                    if (Session["dateformat"].ToString() == "yyyy/mm/dd".ToString())
                    {
                        DateTime dt = System.DateTime.Now;
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        date = year + "/" + month + "/" + day;

                    }
            // runtxt.Text = date.ToString();
            int j;
            string packna = "";
            double boxchg1 = 0;
            double boxchg2 = 0;

            int countpack = ds4.Tables[1].Rows.Count;
            for (j = 0; j < countpack; j++)
            {
                if (packna == "")
                {
                    packna = ds4.Tables[1].Rows[j].ItemArray[0].ToString();
                }
                else
                {
                    packna = packna + "," + ds4.Tables[1].Rows[j].ItemArray[0].ToString();
                }
            }

            //txtpackname.Text = packna.ToString();
            int je;
            string edicode = "";
            int counteditioncode = ds4.Tables[2].Rows.Count;
            for (je = 0; je < counteditioncode; je++)
            {
                if (edicode == "")
                {
                    edicode = ds4.Tables[2].Rows[je].ItemArray[0].ToString();
                }
                else
                {
                    edicode = edicode + "," + ds4.Tables[2].Rows[je].ItemArray[0].ToString();
                }
            }
            string order = ds4.Tables[0].Rows[0].ItemArray[0].ToString();

            string bukingdate = bookingdate.ToString();
            if (bukingdate != "")
            {
                //orderno.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString() + "/" + bukingdate;
            }
            else
            {
                //orderno.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            string rono1 = orderno1.ToString();
            string rodate = orderdate.ToString();
            if (rodate != "" && rono1 != "")
            {
                // rono.Text = rono1 + rodate;
            }


            
            double bill_amt = 0;
            double bill_amt1 = 0;
            double amt2 = 0;
            double amt3 = 0;
            double amt4 = 0;
            double amountinckudingbox = 0;
            double packrate = 0;
            double packrate1 = 0;
            double premiumper = 0;
            double premiumper1 = 0;
            double spcharges = 0;
            double spdes = 0;
            double dispr = 0;
            double trate = 0;
            double tgamt = 0;
            double volume = 0;
            double height1 = 0;
            double width1 = 0;
            double ext = 0;
            double grs = 0;
            double totalam = 0;
            double Disc = 0;
            string Agrred_rate = "0";
            string GAamt1 = "0";
            double billamt = 0;
            
            dytbl = "";
            dytbl += "<table width='660px' align='left' cellpadding='5' cellspacing='0' >";
            {
                DataSet dsb = new DataSet();
                dsb.ReadXml(Server.MapPath("XML/hari_classified_last.xml"));
                dytbl += "<tr align=center >";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='10px' >" + dsb.Tables[0].Rows[0].ItemArray[64].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='150px' >" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='150px' >" + dsb.Tables[0].Rows[0].ItemArray[59].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='150px' >" + "Box No" + "</td>";

                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[65].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>";
                //dytbl += "<td class='insertiontxtclass1'  align='center'  width='10px' >" + dsb.Tables[0].Rows[0].ItemArray[74].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[69].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[67].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[66].ToString() + "</td>";
                dytbl += "</tr>";
            }

            
            packlength1 = packlength;
            for (packlength1 = 0; packlength1 < c1; packlength1++)
            {
                if (counted <= 1)
                {


                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();
                        ds3 = objedition1.edition(packagecode1[packlength1], Session["compcode"].ToString());
                        editionname = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                    else
                    {
                        NewAdbooking.BillingClass.classesoracle.invoice objedition1 = new NewAdbooking.BillingClass.classesoracle.invoice();
                        ds3 = objedition1.edition(packagecode1[packlength1], Session["compcode"].ToString());
                        editionname = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                }

                else
                {
                    editionname = packagecode1[packlength1];
                }

                string editionname1 = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                    NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();

                    ds4 = objedition1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.invoice objvalues1 = new NewAdbooking.BillingClass.classesoracle.invoice();

                    ds4 = objvalues1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());


                }

                if (ds4.Tables[0].Rows[0]["card_rate"].ToString() != "")
                {
                    trate = trate + Convert.ToDouble(ds4.Tables[0].Rows[0]["card_rate"].ToString());
                }
                if (ds4.Tables[0].Rows[0]["gross_rate"].ToString() != "")
                {
                    tgamt = tgamt + Convert.ToDouble(ds4.Tables[0].Rows[0]["gross_rate"].ToString());
                }
                //for (packlength1 = 0; packlength1 < c1; packlength1++)
                //{
                    if (ds4.Tables[0].Rows[0]["agreed_rate"].ToString() != "")
                    {
                        billamt = billamt + Convert.ToDouble(ds4.Tables[0].Rows[0]["agreed_rate"].ToString());
                    }
                    else
                    {
                        billamt = billamt + Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_Rate"].ToString());
                    }

                //}

            }

            //string billamt = "0";
            //if (ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != "")
            //{
            //    billamt = "0";
            //    if (packlength == 0)
            //    {
            //        billamt = ds4.Tables[0].Rows[0]["Agrred_rate"].ToString();
            //    }
            //}


            



           

            for (packlength = 0; packlength < c1; packlength++)
            {

                if (counted <= 1)
                {


                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();
                        ds3 = objedition1.edition(packagecode1[packlength], Session["compcode"].ToString());
                        editionname = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                    else
                    {
                        NewAdbooking.BillingClass.classesoracle.invoice objedition1 = new NewAdbooking.BillingClass.classesoracle.invoice();
                        ds3 = objedition1.edition(packagecode1[packlength], Session["compcode"].ToString());
                        editionname = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                }

                else
                {
                    editionname = packagecode1[packlength];
                }

                string editionname1 = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                    NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();

                    ds4 = objedition1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.invoice objvalues1 = new NewAdbooking.BillingClass.classesoracle.invoice();

                    ds4 = objvalues1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());


                }
                // lblbilldt.Text = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
                // runtxt.Text = ds4.Tables[0].Rows[0]["insert_date"].ToString();
                billdt.Text = ds4.Tables[0].Rows[0]["insert_date"].ToString();

                string phone1 = ds4.Tables[0].Rows[0].ItemArray[37].ToString();

                string amt = ds4.Tables[0].Rows[0]["Gross_Rate"].ToString();
                string boxcharges = ds4.Tables[0].Rows[0].ItemArray[21].ToString();
                double amt1 = 0;
                if (amt != "")
                {
                    amt1 = Convert.ToDouble(amt);
                }
                amt5 = amt5 + amt1;
                string package_rate = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
                string premiumper2 = ds4.Tables[0].Rows[0].ItemArray[34].ToString();
                if (package_rate != "")
                {
                    packrate = Convert.ToDouble(package_rate);
                    packrate1 = packrate1 + packrate;
                }
                if (premiumper2 != "")
                {
                    premiumper = Convert.ToDouble(premiumper2);
                    premiumper1 = premiumper1 + premiumper;

                }

                if (boxcharges == "")
                {

                }
                else
                {
                    boxchg1 = Convert.ToDouble(boxcharges) / totinsertnewint;


                }
                boxchg2 = boxchg1 / c1;

                amt2 = amt1 - boxchg2;
                amt4 = amt4 + amt2;

                amt3 = amt3 + amt1;




                if (ds4.Tables[0].Rows[0]["Bill_Amt"].ToString() != "")
                {
                    bill_amt = Convert.ToDouble(ds4.Tables[0].Rows[0]["Bill_Amt"].ToString());
                    //bill_amt = Convert.ToDouble(ds4.Tables[0].Rows[0]["Bill_Amt"]).ToString("F2");
                    //finalamount = Convert.ToDouble(ds4.Tables[0].Rows[0]["Bill_Amt"].ToString());
                }
                else
                {
                    bill_amt = 0;
                    //lblnetamt.Text = 0.ToString("F2");
                    // finalamount = 0;

                }

                bill_amt1 = bill_amt1 + bill_amt;

                //////////////////////////////////////////////////////////////////////////////////////

                double amountforvat = Convert.ToDouble(amt3);

                string discountstr = ds4.Tables[0].Rows[0].ItemArray[10].ToString();
                if (discountstr != "")
                {
                    discountint = Convert.ToDouble(discountstr);
                }
                else
                {
                    discountint = Convert.ToInt16(0);
                }



                /////////////////////////////////////////////////////////////////////////////////\
                lbltextmain.Text = ds4.Tables[0].Rows[0]["Agency"].ToString();
                agencyaddtxt.Text = ds4.Tables[0].Rows[0]["add1"].ToString();
                agencyadd2.Text = ds4.Tables[0].Rows[0]["add2"].ToString();

                lblbookingtype.Text = ds4.Tables[0].Rows[0]["ad_type"].ToString();
                txtbookingid.Text = ds4.Tables[0].Rows[0]["CIOID"].ToString();
                txtagencytype.Text = ds4.Tables[0].Rows[0]["Agency_Type_Code"].ToString();


                dytbl += "<tr align=center hight='67px'>";
                dytbl += "<td class='insertiontxtclass' align='center' style='border-right:solid 1px black;'>" + srl.ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass' align='center' width='150px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[0]["EditionName"].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass' align='center'width='50px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["insert_date"].ToString() + "</td>";

                dytbl += "<td class='insertiontxtclass' align='center'width='50px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["box_no"].ToString() + "</td>";


                if (ds4.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    {
                        dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["Depth"].ToString() + "*" + ds4.Tables[0].Rows[0]["Width"].ToString() + "</td>";
                    }
                }
                else
                {
                    dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["volume"].ToString() + "</td>";
                }

                dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["volume"].ToString() + "</td>";

                dytbl += "<td class='insertiontxtclass'align='center' width='90px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[0]["Page_No"].ToString() + "</td>";
                if (packlength == 0)
                {
                    //if (ds4.Tables[0].Rows[0]["package rate"].ToString() != "")
                    //{
                    //    dytbl += "<td class='insertiontxtclass' align='center'  width='50px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["package rate"].ToString() + "</td>";
                    //}
                    //else
                    //{
                    //    dytbl += "<td class='insertiontxtclass' align='center'  width='50px'style='border-right:solid 1px black;'>--</td>";
                    //}
                    if (ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != "")
                    {
                        dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>--</td>";
                    }
                    dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-right:solid 1px black;'>" + billamt.ToString("F2") + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='center'  width='90px'>" + addchr + "</td>";
                    //grs = Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_amount"].ToString());
                    //ext = pr1;
                    //totalam = amt + ext;
                    dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-left:solid 1px black;'>" + billamt.ToString("F2") + "</td>";

                }
                else 
                {
                    //if (ds4.Tables[0].Rows[0]["package rate"].ToString() != "")
                    //{
                    //    dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>" + ".." + "</td>";
                    //}
                    //else
                    //{
                    //    dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'></td>";
                    //}
                    if (ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != "")
                    {
                        dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>" + ".." + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'></td>";
                    }
                    dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-right:solid 1px black;'>" + ".." + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='center'  width='90px'>" + ".." + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-left:solid 1px black;'>" + ".." + "</td>";

                }
                dytbl += "</tr>";


                srl++;

            }

            dytbl += "</table>";

            dynamictable.Text = dytbl;

            double amountprem = amt4 * (premiumper1 / 100);
            lb_totalamt.Text = string.Format("{0:0.00}", amt4).ToString();
            amountprem = amt4 + amountprem - (spcharges + spdes);
            //  txtgr.Text = amountprem.ToString();
            double disper1 = amountprem * (dispr / 100);
            //  txtdiscal.Text = disper1.ToString();
if(ds4.Tables[0].Rows[0]["trade_disc"].ToString()!="")
{
            trddisc_per.Text = "( " + ds4.Tables[0].Rows[0]["trade_disc"].ToString() + "% )";
}
else
{

 trddisc_per.Text = "( " + "0" + "% )";

}
            lb_totalamt.Text = string.Format("{0:0.00}", billamt).ToString();
            traddis = billamt * traddis / 100;
            txtdiscal.Text = string.Format("{0:0.00}", traddis).ToString();
            //lbladddis.Text =string.Format("{0:0.00}", adddis).ToString();
            //lblextra.Text = addchr.ToString();billamt.ToString("F2")
            netpay.Text = bill_amt1.ToString();
            bill_amt1 = bill_amt1 + 0.00;
            double amountinckudingbox1 = bill_amt1;

            if (ds4.Tables[0].Rows[0]["boxcharge"].ToString() == "" || ds4.Tables[0].Rows[0]["boxcharge"].ToString() == null)
            {
                Label10.Text = "0.00";
            }
            else
            {
                Label10.Text = ds4.Tables[0].Rows[0]["boxcharge"].ToString();
            }

            netpay.Text = string.Format("{0:0.00}", amountinckudingbox1).ToString();
            txt_remark.Text = ds4.Tables[0].Rows[0]["Bill_remarks"].ToString();
            // amountinckudingbox = amountprem + boxchg1 - disper1;

            //  double amountforvat1 = 0;

            ///////////////////////////////////////////////////////////////////////////////////////////////


            //  netpay.Text = amountinckudingbox1.ToString();


            NumberToEngish obj = new NumberToEngish();
            lbwordinrupees.Text = obj.changeNumericToWords(netpay.Text.ToString()) + "Only";

            DataSet dssave = new DataSet();

            if (packlength == c1)
            {



                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                    NewAdbooking.BillingClass.Classes.billing_save objabc = new NewAdbooking.BillingClass.Classes.billing_save();
                    dssave = objabc.updatebillprintstatus(txtinvoice.Text);
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.billing_save objabc = new NewAdbooking.BillingClass.classesoracle.billing_save();
                    dssave = objabc.updatebillprintstatus(txtinvoice.Text);


                }

            }

            String countBILS = orignaldupli.ToString();
            if (countBILS == "0")
            {
                pagestatus.Text = "ORIGINAL".ToString();
            }
            else
            {
                pagestatus.Text = "DUPLICATE".ToString();
            }

        }

    }
}









