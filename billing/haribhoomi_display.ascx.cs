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

public partial class haribhoomi_display : System.Web.UI.UserControl
{

    string imagepath = "";
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
    public string _unit;
    public string _divid;
    public string _chkvalue_length;
    public string _tbl_id;
    public string _trade_disc;
    public haribhoomi_display()
    {
        _tbl_id = "";
        _unit = "";
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
        _trade_disc = "";
        _chkvalue_length = "";
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
    public string chkvalue_length { get { return _chkvalue_length; } set { _chkvalue_length = value; } }
    public string trade_disc { get { return _trade_disc; } set { _trade_disc = value; } }
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/hari_classified_last.xml"));
        lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        lblcap.Text = "Caption";// ds.Tables[0].Rows[0].ItemArray[72].ToString();
        lblrefno.Text = ds.Tables[0].Rows[0].ItemArray[70].ToString();
        //lblagencyname.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbladd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblkey.Text = ds.Tables[0].Rows[0].ItemArray[68].ToString();
        lb_total.Text = ds.Tables[0].Rows[0].ItemArray[66].ToString();
        lbtrade1.Text = ds.Tables[0].Rows[0].ItemArray[53].ToString();
        lblbilldt.Text = ds.Tables[0].Rows[0].ItemArray[71].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[58].ToString();
        publ.Text = ds.Tables[0].Rows[0].ItemArray[73].ToString();
        //hribhomi_text.Text = ds.Tables[0].Rows[0].ItemArray[75].ToString();

      

      

        //if (prtype == "agencyroaudit")
        //{
        //    btnPrev.Text = "Audit";

        //    tit.Text = "Agency Ro Audit";
        //    cap = "Agency Ro Audit";

        //}
        //else
        //{
        //    btnPrev.Text = "Proof";
        //    tit.Text = "ProofReading";
        //    cap = "ProofReading";

        //}

        

      //  splchagr.Text = ds.Tables[0].Rows[0].ItemArray[76].ToString();

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
        double disc = 0.00;
        double sp_disc_per = 0;
        double BILL_AMT21 = 0;
        double volume_total = 0;
        double package_total = 0;

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
        string[] packagecode1_tot = packagecode11.Split(',');
        string[] packagecode1 = packagecode11.Split(',');
        int c1 = packagecode1.Length;
        int c1_total = packagecode1.Length;
        int packlength_total = 0;

        //====================================

        //for (packlength_total = 0; packlength_total < c1_total; packlength_total++)
        //{

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
            ds3 = objedition.edition(packagecode1_tot[packlength_total], Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.invoice objedition = new NewAdbooking.BillingClass.classesoracle.invoice();
            ds3 = objedition.edition(packagecode1[packlength_total], Session["compcode"].ToString());

        }
        string editionnametest = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
        //==================================
        string[] editionnametest1 = editionnametest.Split('+');
        int counted = editionnametest1.Length;
        if (counted > 1)
        {
            c1 = counted;
            packagecode1 = editionnametest.Split('+');
        }
        else
        {
            c1 = counted;
            packagecode1 = editionnametest.Split('+');

        }





        for (packlength = 0; packlength < c1; packlength++)
        {
            if (counted < 1)
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
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    NewAdbooking.BillingClass.Classes.invoice objvalues = new NewAdbooking.BillingClass.Classes.invoice();
            //    dsbranch = objvalues.values_bill(Session["compcode"].ToString(), Session["revenue"].ToString(), "");
            //}
            //if (dsbranch.Tables[0].Rows.Count > 0)
            //{
            //   // branchadd.Text = dsbranch.Tables[0].Rows[0]["Add1"].ToString();
            //   // bhranchadd1.Text = "Ph:-" + dsbranch.Tables[0].Rows[0]["Phone1"].ToString() + "-" + dsbranch.Tables[0].Rows[0]["Phone2"].ToString() + "," + "fax:- " + dsbranch.Tables[0].Rows[0]["fax"].ToString();
            //}
            DataSet ds5 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.BillingClass.classesoracle.invoice shtr = new NewAdbooking.BillingClass.classesoracle.invoice();
                ds5 = shtr.bindaddress(Session["compcode"].ToString(), Session["center"].ToString(), "", "");


            }
            else
            {
                NewAdbooking.BillingClass.Classes.invoice shtr = new NewAdbooking.BillingClass.Classes.invoice();
                ds5 = shtr.bindaddress(Session["compcode"].ToString(), Session["center"].ToString(), "", "");

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
                agencyaddtxt.Text = ds4.Tables[0].Rows[0]["add1"].ToString();
                //  lbltextmain.Text = "Agency";
            }
            else
            {
                string[] addname = ds4.Tables[0].Rows[0]["agenadd"].ToString().Split("$$".ToCharArray());
                agencyaddtxt.Text = addname[0];
                if (ds4.Tables[0].Rows[0]["agenadd"].ToString() == "")
                    agddxt.Text = "(" + ds4.Tables[0].Rows[0]["agency_sub_code"].ToString() + ")" + ds4.Tables[0].Rows[0]["Agency"].ToString();
                else
                    agddxt.Text = addname[2];
                //lbltextmain.Text = "Client";
            }
            string clientadd = "";
            if (ds4.Tables[0].Rows[0]["ClientAd"].ToString() != "")
            {
                clientadd = ds4.Tables[0].Rows[0]["ClientAd"].ToString();
            }
            else
            {
                clientadd = "";
            }
            if (ds4.Tables[0].Rows[0]["Agency"].ToString() == "DIRECT PARTY")
            {
                //lbltextmain.Text = "Client";
                agddxt.Text = ds4.Tables[0].Rows[0]["Client"].ToString() + "</br>" + clientadd.ToString();

            }

            if (agddxt.Text == ds4.Tables[0].Rows[0]["Agency"].ToString())
            {
                lbladrelpar.Text = "Client";
                txtcliname.Text = ds4.Tables[0].Rows[0]["Client"].ToString();
            }
            else if (agddxt.Text == ds4.Tables[0].Rows[0]["Client"].ToString())
            {
                lbladrelpar.Text = "Agency";
                txtcliname.Text = "(" + ds4.Tables[0].Rows[0]["agency_sub_code"].ToString() + ")" + ds4.Tables[0].Rows[0]["Agency"].ToString();
            }
            else
            {
                lbladrelpar.Text = "Client";
                txtcliname.Text = ds4.Tables[0].Rows[0]["Client"].ToString();

            }
            if (ds4.Tables[0].Rows[0]["Agency"].ToString() == "DIRECT PARTY")
            {
                lbladrelpar.Text = "Agency";
                txtcliname.Text = "(" + ds4.Tables[0].Rows[0]["agency_sub_code"].ToString() + ")" + ds4.Tables[0].Rows[0]["Agency"].ToString();

            }

            //string[] addname1 = ds4.Tables[0].Rows[0]["street_login"].ToString().Split("~".ToCharArray());
           
            lbcompaddress.Text = ds5.Tables[0].Rows[0]["Pub_Cent_name"].ToString() + " " + ds5.Tables[0].Rows[0]["Add1"].ToString() + " " + ds5.Tables[0].Rows[0]["Street"].ToString()
            + " " + ds5.Tables[0].Rows[0]["Dist_Code"].ToString() + "," + ds5.Tables[0].Rows[0]["Zip"].ToString() + "</br>" +"Phone No.=" + ds5.Tables[0].Rows[0]["Phone1"].ToString()
            + "," + ds5.Tables[0].Rows[0]["Phone2"].ToString() +"</br>" + "Fax:=" + ds5.Tables[0].Rows[0]["Fax"].ToString() + "&nbsp; </br> Email Id:= " + ds5.Tables[0].Rows[0]["EmailID"].ToString();

            //txtmailid.Text = addname1[1];
            
            //lbemailtxt.Text = "www.nationalduniya.com";
            lbemailtxt.Text = ds4.Tables[0].Rows[0]["emailid"].ToString();
            

            hribhomi_text.Text = "For :-     "+ds4.Tables[0].Rows[0]["pub1"].ToString();
            if (ds4.Tables[0].Rows[0]["agency_sub_code"].ToString() != "")
            {
               
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
            
            grossamt = Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_Rate"].ToString());
            if (trade_disc == "0")
            {
                if (ds4.Tables[0].Rows[0]["trade_disc"].ToString() != "0")
                {
                    traddis = Convert.ToDouble(ds4.Tables[0].Rows[0]["trade_disc"].ToString());
                }
                else
                {
                    traddis = 0;
                }
            }
            else
            {
                traddis = 0;
            }
            
            if (ds4.Tables[0].Rows[0]["special_discount"].ToString() != "")
            {
                adddis = Convert.ToDouble(ds4.Tables[0].Rows[0]["special_discount"].ToString());

            }

            if (ds4.Tables[0].Rows[0]["special_charges"].ToString() != "")
            {
                addchr = Convert.ToDouble(ds4.Tables[0].Rows[0]["special_charges"].ToString());
            }
            else
            {
                addchr = 0;
            }
            finalamount = grossamt - traddis - adddis + addchr;
            
            //if (ds4.Tables[0].Rows[0]["pan"].ToString() != "")
            //{
            //    txtpanno.Text = ds4.Tables[0].Rows[0]["pan"].ToString();
            //}
           
            netpay.Text = Math.Round(finalamount + 0.01).ToString();
            if (ds4.Tables[0].Rows[0]["Cap"].ToString() != "")
            {
                txtcaption.Text = ds4.Tables[0].Rows[0]["Cap"].ToString() + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + ds4.Tables[0].Rows[0]["product"].ToString();
            }
            else if (ds4.Tables[0].Rows[0]["product"].ToString() != "")
            {
                txtcaption.Text = "--" + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + ds4.Tables[0].Rows[0]["product"].ToString();
            }
            else if (ds4.Tables[0].Rows[0]["Cap"].ToString() != "")
            {
                txtcaption.Text = ds4.Tables[0].Rows[0]["Cap"].ToString() + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + "--";
            }
            else
            {
                txtcaption.Text = "--" + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + "--";
            }
           
            //string totinsertnew = ds4.Tables[0].Rows[0].ItemArray[27].ToString();
            //if (totinsertnew != "")
            //{
            //    totinsertnewint = Convert.ToInt16(totinsertnew);
            //}
            //else
            //{
            //    totinsertnewint = 0;
            //}
            //string bx = ds4.Tables[0].Rows[0].ItemArray[21].ToString();
            //double bx2 = 0;
            //if (bx == "")
            //{
            //}
            //else
            //{
            //    bx2 = Convert.ToDouble(bx);
            //    bx2 = bx2 / totinsertnewint;
            //    // boxcharges1.Text = bx2.ToString();
            //}
            string compname =  ds4.Tables[0].Rows[0]["companyname"].ToString() ;
            string compname25 = "<B>NATIONAL DUNIYA Communications Pvt. Ltd.</B>";
            if (Session["revenue"].ToString() == "ja1")
            {
                lbcompanyname.Text = compname25;
            }
            else
            {
                lbcompanyname.Text = compname;
            }
            //string rev = ds4.Tables[0].Rows[0]["Print_cent_name"].ToString();
            string rev = "DELHI";
            string revenu = "";
            string revenu25 = "";
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

            int je;
            string edicode = "";
            int counteditioncode = ds4.Tables[2].Rows.Count;
           

            string bukingdate = bookingdate.ToString();
            if (bukingdate != "")
            {
                
            }
            else
            {
               
            }
            string rono1 = orderno1.ToString();
            string rodate = orderdate.ToString();
            if (rodate != "" && rono1 != "")
            {
               
            }

            int maxlimit = 17;


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
            dytbl = "";
            dytbl += "<table width='660px' align='left' cellpadding='5' cellspacing='0' >";
            {
                DataSet dsb = new DataSet();
                dsb.ReadXml(Server.MapPath("XML/hari_classified_last.xml"));
                dytbl += "<tr align='center'>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='10px' >" + dsb.Tables[0].Rows[0].ItemArray[64].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='150px' >" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='150px' >" + dsb.Tables[0].Rows[0].ItemArray[59].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[65].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[76].ToString() + "</td>";
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
                if (counted < 1)
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

                string[] editionnamenew_latest = editionname.Split('+');
                int counteditin_latest = editionnamenew_latest.Length;


                for (int a_ed = 0; a_ed < counteditin_latest; a_ed++)
                {
                    editionname = editionnamenew_latest[a_ed];

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

                }

               

                double billamt = 0;
                double grossbillamt = 0;
                for (packlength1 = 0; packlength1 < c1; packlength1++)
                {
                   

                }




                //////////////////////////////////////
                billamt = 0;



                for (packlength_total = 0; packlength_total < c1_total; packlength_total++)
                {



                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
                        ds3 = objedition.edition(packagecode1_tot[packlength_total], Session["compcode"].ToString());
                    }
                    editionnametest = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                    //==================================
                    editionnametest1 = editionnametest.Split('+');
                    counted = editionnametest1.Length;
                    if (counted > 1)
                    {
                        c1 = counted;
                        packagecode1 = editionnametest.Split('+');
                    }
                    else
                    {
                        c1 = counted;
                        packagecode1 = editionnametest.Split('+');

                    }

                    for (packlength = 0; packlength < c1; packlength++)
                    {

                        if (counted < 1)
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

                        editionname1 = ds3.Tables[0].Rows[0].ItemArray[0].ToString();


                        string[] editionnamenew_latest1 = editionname.Split('+');
                        int counteditin_latest1 = editionnamenew_latest1.Length;

                        for (int a_ed1 = 0; a_ed1 < counteditin_latest1; a_ed1++)
                        {
                            editionname = editionnamenew_latest1[a_ed1];


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


                            //if (ds4.Tables[0].Rows[0]["agreed_rate"].ToString() != "")
                            //{
                            //    billamt = billamt + Convert.ToDouble(ds4.Tables[0].Rows[0]["agreed_rate"].ToString());
                            //}

                            //else
                            //{
                            //    billamt = billamt + Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_Rate"].ToString());
                            //}





                            if (ds4.Tables[0].Rows[0]["Size_To"].ToString() == ds4.Tables[0].Rows[0]["Size_From"].ToString())
                            {

                                if (ds4.Tables[0].Rows[0]["volume"].ToString() != "")
                                {
                                    volume_total = Convert.ToDouble(ds4.Tables[0].Rows[0]["volume"].ToString());
                                }


                                if (ds4.Tables[0].Rows[0]["agreed_rate"].ToString() == "")
                                {

                                    if (ds4.Tables[0].Rows[0]["card_rate"].ToString() != "")
                                    {
                                        package_total = Convert.ToDouble(ds4.Tables[0].Rows[0]["card_rate"].ToString());
                                    }



                                    billamt = billamt + (volume_total * package_total);






                                }
                                else
                                {

                                    if (ds4.Tables[0].Rows[0]["gross_rate"].ToString() != "0")
                                    {
                                        package_total = Convert.ToDouble(ds4.Tables[0].Rows[0]["gross_rate"].ToString());
                                        billamt = billamt + package_total;

                                        /////////////////////////
                                        double tot_dic_n = 0;
                                        if (ds4.Tables[0].Rows[0]["special_discount"].ToString() != "")
                                        {
                                            tot_dic_n = volume_total * adddis;
                                        }


                                        billamt = billamt + tot_dic_n;
                                        /////////////////////


                                    }
                                    else
                                    {
                                        billamt = 0.00;
                                    }




                                }



                            }
                            else
                            {

                                if ((packlength_total == 0) && (packlength == 0) && (a_ed1 == 0))
                                {



                                    if (ds4.Tables[0].Rows[0]["volume"].ToString() != "")
                                    {
                                        volume_total = Convert.ToDouble(ds4.Tables[0].Rows[0]["volume"].ToString());
                                    }


                                    if (ds4.Tables[0].Rows[0]["agreed_rate"].ToString() == "")
                                    {

                                        if (ds4.Tables[0].Rows[0]["package rate"].ToString() != "")
                                        {
                                            package_total = Convert.ToDouble(ds4.Tables[0].Rows[0]["package rate"].ToString());
                                        }
                                    }
                                    else
                                    {
                                        if (ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() == "")
                                        {
                                            package_total = 0.00;
                                        }
                                        else
                                        {
                                            package_total = Convert.ToDouble(ds4.Tables[0].Rows[0]["Agrred_rate"].ToString());
                                        }
                                    }


                                    billamt = billamt + (volume_total * package_total);
                                }
                            }
                            //  break;

                        }
                        //  break;
                    }
                    //   break;

                }



                //////////////////////////////////



                ///////////////////////////////////////////////////////////////////////
                double billamt_latest = 0;
                double package_total_latest = 0;


                for (packlength_total = 0; packlength_total < c1_total; packlength_total++)
                {



                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
                        ds3 = objedition.edition(packagecode1_tot[packlength_total], Session["compcode"].ToString());
                    }
                    editionnametest = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                    //==================================
                    editionnametest1 = editionnametest.Split('+');
                    counted = editionnametest1.Length;
                    if (counted > 1)
                    {
                        c1 = counted;
                        packagecode1 = editionnametest.Split('+');
                    }
                    else
                    {
                        c1 = counted;
                        packagecode1 = editionnametest.Split('+');

                    }

                    for (packlength = 0; packlength < c1; packlength++)
                    {

                        if (counted < 1)
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

                        editionname1 = ds3.Tables[0].Rows[0].ItemArray[0].ToString();


                        string[] editionnamenew_latest1 = editionname.Split('+');
                        int counteditin_latest1 = editionnamenew_latest1.Length;

                        for (int a_ed1 = 0; a_ed1 < counteditin_latest1; a_ed1++)
                        {
                            editionname = editionnamenew_latest1[a_ed1];


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




                            if (ds4.Tables[0].Rows[0]["gross_rate"].ToString() != "0")
                            {
                                package_total_latest = Convert.ToDouble(ds4.Tables[0].Rows[0]["gross_rate"].ToString());
                                billamt_latest = billamt_latest + package_total_latest;



                            }
                            else
                            {
                                billamt_latest = 0.00;
                            }











                        }

                    }


                }



                //////////////////////////////////

                ///////////////////////////////////////////////////////////////


                for (packlength_total = 0; packlength_total < c1_total; packlength_total++)
                {



                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
                        ds3 = objedition.edition(packagecode1_tot[packlength_total], Session["compcode"].ToString());
                    }
                    editionnametest = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                    //==================================
                    editionnametest1 = editionnametest.Split('+');
                    counted = editionnametest1.Length;
                    if (counted > 1)
                    {
                        c1 = counted;
                        packagecode1 = editionnametest.Split('+');
                    }
                    else
                    {
                        c1 = counted;
                        packagecode1 = editionnametest.Split('+');

                    }





                    for (packlength = 0; packlength < c1; packlength++)
                    {

                        if (counted < 1)
                        {


                            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                            {
                                NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();
                                ds3 = objedition1.edition(packagecode1_tot[packlength_total], Session["compcode"].ToString());
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

                        editionname1 = ds3.Tables[0].Rows[0].ItemArray[0].ToString();


                        string[] editionnamenew_latest1 = editionname.Split('+');
                        int counteditin_latest1 = editionnamenew_latest1.Length;

                        for (int a_ed1 = 0; a_ed1 < counteditin_latest1; a_ed1++)
                        {
                            editionname = editionnamenew_latest1[a_ed1];


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
                            //////new add




                            if (ds4.Tables[0].Rows[0]["special_disc_per"].ToString() != "")
                            {

                                splchagr.Text = "Spl. Discount (Rs)" + "( " + ds4.Tables[0].Rows[0]["special_disc_per"].ToString() + "% )";
                                sp_disc_per = Convert.ToDouble(ds4.Tables[0].Rows[0]["special_disc_per"].ToString());
                            }
                            else
                            {
                                splchagr.Text = "Spl.Dis." + "( " + "0" + "% )";
                            }
                            if (ds4.Tables[0].Rows[0]["special_disc_per"].ToString() != "")
                            {
                                disc = billamt_latest / (1 - sp_disc_per / 100);
                            }
                            else
                            {
                                disc = billamt_latest;
                            }
                            /////
                            // lblbilldt.Text = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
                            // runtxt.Text = ds4.Tables[0].Rows[0]["insert_date"].ToString();
                            billdt.Text = ds4.Tables[0].Rows[0]["insert_date"].ToString();

                            string phone1 = ds4.Tables[0].Rows[0].ItemArray[37].ToString();

                            string amt = ds4.Tables[0].Rows[0]["Gross_Rate"].ToString();
                            string boxcharges = ds4.Tables[0].Rows[0]["Box_Charge"].ToString();
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



                            if (trade_disc == "0")
                            {
                                
                                if (ds4.Tables[0].Rows[0]["Bill_Amt"].ToString() != "0")
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
                            }
                            else
                            {
                                bill_amt = Convert.ToDouble(ds4.Tables[0].Rows[0]["gross_amount"].ToString());
                            }

                            bill_amt1 = bill_amt1 + bill_amt;
                            BILL_AMT21 = bill_amt1;

                            //////////////////////////////////////////////////////////////////////////////////////

                            double amountforvat = Convert.ToDouble(amt3);

                            string discountstr = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
                            if (discountstr != "")
                            {
                                discountint = Convert.ToDouble(discountstr);
                            }
                            else
                            {
                                discountint = Convert.ToInt16(0);
                            }



                            /////////////////////////////////////////////////////////////////////////////////

                            dytbl += "<tr align=center hight='10px'>";
                            dytbl += "<td class='insertiontxtclass' align='center' style='border-right:solid 1px black; '>" + srl.ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass' align='center' width='150px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[0]["EditionName"].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass' align='center'width='50px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["insert_date"].ToString() + "</td>";


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
                            dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["Hue"].ToString() + "</td>";

                            dytbl += "<td class='insertiontxtclass'align='center' width='90px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[0]["Page_No"].ToString() + "</td>";

                            if (packlength == 0 && packlength_total == 0)
                            {
                                //if (ds4.Tables[0].Rows[0]["package rate"].ToString() != "")
                                //{
                                //    dytbl += "<td class='insertiontxtclass' align='center'  width='50px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["package rate"].ToString() + "</td>";
                                //}
                                //else
                                //{
                                //    dytbl += "<td class='insertiontxtclass' align='center'  width='50px'style='border-right:solid 1px black;'>--</td>";
                                //}

                                //if (ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != "")
                                //{
                                //    dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() + "</td>";
                                //}
                                //else
                                //{
                                //    dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["package rate"].ToString() + "</td>";
                                //}

                                if (ds4.Tables[0].Rows[0]["Agrred_Rate"].ToString() != "" && ds4.Tables[0].Rows[0]["Agrred_Rate"].ToString() != null)
                                {
                                    dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["Agreed_Rate"].ToString() + "</td>";
                                }
                                else
                                {
                                    dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["Card_Rate"].ToString() + "</td>";
                                }
                                grossbillamt = Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_amount"].ToString());

                                if (Convert.ToDouble(addchr.ToString()) == 0.0)
                                {

                                    dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-right:solid 1px black;'>" + Math.Round(disc).ToString("F2") + "</td>";
                                }
                                else
                                {
                                    double abcd_latest = billamt_latest - addchr;
                                    dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-right:solid 1px black;'>" + Math.Round(abcd_latest).ToString("F2") + "</td>";
                                }




                                dytbl += "<td class='insertiontxtclass' align='center'  width='90px'>" + addchr + "</td>";


                                //grs = Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_amount"].ToString());
                                //ext = pr1;
                                //totalam = amt + ext;

                                //billamt = billamt + addchr;
                                dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-left:solid 1px black;'>" + Math.Round(disc).ToString("F2") + "</td>";


                            }
                            else
                            {
                                

                                if (ds4.Tables[0].Rows[0]["Agrred_Rate"].ToString() != "" && ds4.Tables[0].Rows[0]["Agrred_Rate"].ToString() != null)
                                {
                                    dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["Agreed_Rate"].ToString() + "</td>";
                                }
                                else
                                {
                                    dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["Card_Rate"].ToString() + "</td>";
                                }
                                dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-right:solid 1px black;'>" + ".." + "</td>";
                                dytbl += "<td class='insertiontxtclass' align='center'  width='90px'>" + ".." + "</td>";
                                dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-left:solid 1px black;'>" + ".." + "</td>";

                            }
                            dytbl += "</tr>";


                            srl++;
                            if (trade_disc == "0")
                            {

                            }
                            else
                            {
                                bill_amt = 0;
                                bill_amt1 = 0;
                            }

                        }






                        ////////////////

                    }
                }

                for (int a1 = ds4.Tables[0].Rows.Count; a1 < 24; a1++)
                {
                    dytbl += "<tr align=center hight='67px'>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-left:solid 1px black;'>" + "&nbsp;" + "</td>";
                    dytbl += "</tr>";
                }
                ////////////////

                dytbl += "</table>";

                dynamictable.Text = dytbl;

                double amountprem = amt4 * (premiumper1 / 100);
                //    lb_totalamt.Text = string.Format("{0:0.00}", amt4).ToString();
                amountprem = amt4 + amountprem - (spcharges + spdes);
                //  txtgr.Text = amountprem.ToString();
                double disper1 = amountprem * (dispr / 100);
                //  txtdiscal.Text = disper1.ToString();

                if (ds4.Tables[0].Rows[0]["CHKTRADEDISC"].ToString() != "0")
                {
                    if (trade_disc == "0")
                    {
                        if (ds4.Tables[0].Rows[0]["trade_disc"].ToString() != "0")
                        {

                            trddisc_per.Text = "( " + ds4.Tables[0].Rows[0]["trade_disc"].ToString() + "% )";
                        }
                        else
                        {
                            trddisc_per.Text = "( " + "0" + "% )";
                        }
                    }
                    else
                    {
                        trddisc_per.Text = "( " + "0" + "% )";
                    }

                }
                else
                {
                    trddisc_per.Text = "( " + "0" + "% )";
                }



                // lb_totalamt.Text = string.Format("{0:0.00}",Math.Round(billamt_latest) ).ToString();
                lb_totalamt.Text = string.Format("{0:0.00}", Math.Round(disc)).ToString();
                billamt = billamt_latest;
                traddis = billamt * traddis / 100;
                //double spd =Convert.ToDouble(ds4.Tables[0].Rows[0]["special_disc_per"].ToString());
                //if (spd != null)
                //{
                //    
                //}

                ///
                //string unit1 = "";
                //if (ds4.Tables[4].Rows.Count > 0)
                //{
                //     unit1 = ds4.Tables[4].Rows[0]["unit"].ToString();
                //}
                //else
                //{
                //    unit1 = "";
                //}
                //if (unit1 == "RO1")
                //{
                //    lbltan.Text = "TAN NO:-" + "DELH06489A";
                //    lblservices.Text = "Service Tax No.:-" + "AACCH0077KST001";
                //}
                //else if (unit1 == "RA2")
                //{
                //    lbltan.Text = "TAN NO:-" + "DELH06489A";
                //    lblservices.Text = "Service Tax No.:-" + "AACCH0077KST003";
                //}
                //else if (unit1 == "de1")
                //{
                //    lbltan.Text = "TAN NO:-" + "DELH06489A";
                //    lblservices.Text = "Service Tax No:-" + "AACCH0077KST004";
                //}
                //else if (unit1 == "BI1")
                //{
                //    lbltan.Text = "TAN NO:-" + "DELH06489A";
                //    lblservices.Text = "Service Tax No:-" + "AACCH0077KST002";
                //}
                //else if (unit1 == "ja1")
                //{
                //    lbltan.Text = "TAN NO:-" + "DELH06489A";
                //    lblservices.Text = "Service Tax No:-" + "AACCH0077KST005";
                //}
                //else if (unit1 == "RA1")
                //{
                //    lbltan.Text = "TAN NO:-" + "DELH06489A";
                //    lblservices.Text = "Service Tax No:-" + "AACCH0077KSD006";
                //}


                ////
                if (ds4.Tables[0].Rows[0]["CHKTRADEDISC"].ToString() != "0")
                {
                    txtdiscal.Text = string.Format("{0:0.00}", traddis).ToString();
                }
                else
                {
                    txtdiscal.Text = string.Format("{0:0.00}", "0").ToString();
                }




                billamt = billamt - traddis;
                billamt = ((billamt) * sp_disc_per / 100);
                double spclcharg = volume_total * adddis;
                Label9.Text = string.Format("{0:0.00}", spclcharg).ToString();
                if (ds4.Tables[0].Rows[0]["pag_prem"].ToString() != "")
                {
                    lb_pageprm.Text = ds4.Tables[0].Rows[0]["pag_prem"].ToString();
                }
                else
                {
                    lb_pageprm.Text = "0.00";
                }
                //lbladddis.Text =string.Format("{0:0.00}", adddis).ToString();
                //lblextra.Text = addchr.ToString();billamt.ToString("F2")
                netpay.Text = BILL_AMT21.ToString();
                txtrupees.Text = BILL_AMT21.ToString();
                BILL_AMT21 = BILL_AMT21 + 0.01;
                double amountinckudingbox1 = BILL_AMT21;

                amountinckudingbox1 = Math.Round(amountinckudingbox1);

                netpay.Text = string.Format("{0:0.00}", amountinckudingbox1).ToString();
                txt_remark.Text = ds4.Tables[0].Rows[0]["Bill_remarks"].ToString();
                bill_amt = 0;
                //trade_disc="0";
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

                break;

            }

        }

        if (chkvalue_length == "yes")
        {

            tbl_id.Attributes.Add("style", "page-break-after:always;");

        }
        //  }
    }
}

