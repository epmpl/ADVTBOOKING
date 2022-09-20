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

public partial class billing_packageprahar : System.Web.UI.UserControl
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
    public  string _qbc;
    public  string _editionnameplus;
    public  string _auto;
    public billing_packageprahar()

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
        _agency="";
        _publication="";
        _rundate = "";
        _packgerate = "";
        _orderno ="";
        _amount = "";
        _discount = "";
        _edition1 = "";
        _client = "";
        _agencycode = "";
        _agddxt1 ="";
        _city="";
        _currency = "";
        _boxcharges="";
        _packagelength = "";
        _packagecode = "";
        _id = "";
        _invoiceno = "";
        _totalinsertion = "";
        _bookingdate = "";
        _orderdate = "";
        _valueofradio="";
        _qbc = "";
        _editionnameplus = "";


       
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
    public string rundate1{ get { return _rundate; } set { _rundate = value; } }
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

    








    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();

        

        ds.ReadXml(Server.MapPath("XML/bill.xml"));
        //lbagecnycode.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbtype.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbstandard.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbposition.Text = ds.Tables[0].Rows[0].ItemArray[53].ToString();
       // lbpackage.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbscheme.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
      // lbavertiser.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbnumber.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbordernumber.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
      //  heading.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();
        lbweidth.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lbheight.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        //lbvolume.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
      //  lbextrasize.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        lbcolor.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
        lbpackagerate.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
        lbextracharges.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
       // lbdiscount.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        //lbamount.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        lblamount.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        //lbltrade.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        lbltotal.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        lblbox.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        lblnet.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        lbformatproposal.Text = ds.Tables[0].Rows[0].ItemArray[60].ToString();
        lbinsertionnumber.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
       // lblwhile.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
       lbpanno.Text = ds.Tables[0].Rows[0].ItemArray[31].ToString();
       lbproductkey.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();
        lbrupee.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        lbpub.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
       // lbedition.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();
        lbheadoffice.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString();
        lbto.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        lbpackagena.Text = ds.Tables[0].Rows[0].ItemArray[61].ToString();
        lbvat.Text = ds.Tables[0].Rows[0].ItemArray[39].ToString();
        lbeduca.Text = ds.Tables[0].Rows[0].ItemArray[40].ToString();
        lbinsdt .Text = ds.Tables[0].Rows[0].ItemArray[42].ToString();
        //lbedi.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();
        lbservice.Text = ds.Tables[0].Rows[0].ItemArray[41].ToString();
     lbheadoffice.Text = ds.Tables[0].Rows[0].ItemArray[43].ToString();
   // lbhead2.Text = ds.Tables[0].Rows[0].ItemArray[44].ToString();
     lbpageno.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();
    lbpremium.Text = ds.Tables[0].Rows[0].ItemArray[46].ToString();
    lbextrach.Text = ds.Tables[0].Rows[0].ItemArray[47].ToString();
    lbltrade.Text = ds.Tables[0].Rows[0].ItemArray[48].ToString();
    lbgr.Text = ds.Tables[0].Rows[0].ItemArray[49].ToString();
    lbtdper.Text = ds.Tables[0].Rows[0].ItemArray[66].ToString();
    lbtrade1 .Text = ds.Tables[0].Rows[0].ItemArray[67].ToString();
   remark .Text = ds.Tables[0].Rows[0].ItemArray[65].ToString();
    //txtpan.Text = ds.Tables[0].Rows[0].ItemArray[64].ToString();
    

   


    }

    public void setcard()
    {

       

        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double finalamount = 0;
       double  discountint=0;
        int totinsertnewint = 0;

        double amountinckudingboxbill = 0.01;



        String dytbl;
        dytbl = "";

        int count11 = Convert.ToInt16(insertion);
        int packlength22 = Convert.ToInt16(packagelength);

        string packagecode11 = packagecode.ToString();
     
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();


        int i11 = 1;
       int packlength = 0;
       string ciobookingid = id.ToString();
       string editionname = "";
       int totinsert = Convert.ToInt16(totalinsertion);
       
       string i12 = insertion.ToString();
            string[] packagecode1 = packagecode11.Split(',');
            int c1 = packagecode1.Length;

            //====================================


            try
            {





                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
                    ds3 = objedition.edition(packagecode1[packlength], Session["compcode"].ToString());
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.invoice objedition = new NewAdbooking.BillingClass.classesoracle.invoice();
                    ds3 = objedition.edition(packagecode1[packlength], Session["compcode"].ToString());

                }
                string editionnametest = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                //==================================


                string[] editionnametest1 = editionnametest.Split('+');
                int counted = editionnametest1.Length;
                if (counted > 1)
                {
                    c1 = counted;
                    packagecode1 = editionnametest.Split('+');
                    //editionname =packagecode1

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

                    //for (editionlen = 0; editionlen < counteditin; editionlen++)
                    //{
                    // //   NewAdbooking.classesoracle.invoice objedition = new NewAdbooking.classesoracle.invoice();
                    //    NewAdbooking.BillingClass.classesoracle.invoice objedition = new NewAdbooking.BillingClass.classesoracle.invoice();
                    //    ds4 = objedition.editiondate(editionnamenew[editionlen].Trim (), ciobookingid, Session["compcode"].ToString(),Session ["dateformat"].ToString ());
                    //    if (ediplusdate == "")
                    //    {
                    //        ediplusdate = editionnamenew[editionlen] + ds4.Tables[0].Rows[0].ItemArray[0].ToString();

                    //    }
                    //    else
                    //    {

                    //        ediplusdate=ediplusdate+","+editionnamenew[editionlen] + ds4.Tables[0].Rows[0].ItemArray[0].ToString();

                    //    }





                    //}
                    //txtpackname.Text = ediplusdate.ToString();



                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.BillingClass.Classes.invoice objvalues = new NewAdbooking.BillingClass.Classes.invoice();
                        //ds4 = objvalues.values_bill(ciobookingid, editionname, i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                    }
                    else
                    {

                        NewAdbooking.BillingClass.classesoracle.invoice objvalues = new NewAdbooking.BillingClass.classesoracle.invoice();
                        ds4 = objvalues.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());

                    }


                    adcat.Text = ds4.Tables[0].Rows[0].ItemArray[12].ToString();

                    //if (ds4.Tables[0].Rows[0]["paydate"].ToString() != "")
                    //{
                    //    Label17.Text = ds4.Tables[0].Rows[0]["paydate"].ToString();
                    //}
                    //else
                    //{

                    //}

                    DataSet ds = new DataSet();

                    ds.ReadXml(Server.MapPath("XML/bill.xml"));
                    lbvolume.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();



                    Label16.Text = ds4.Tables[0].Rows[0]["Email"].ToString();

                    rono.Text = ds4.Tables[0].Rows[0].ItemArray[8].ToString();
                    agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[1].ToString();

                    pubtxt.Text = ds4.Tables[0].Rows[0].ItemArray[2].ToString();



                    amtdisc.Text = ds4.Tables[0].Rows[0].ItemArray[10].ToString();
                    if (amtdisc.Text == "")
                    { }
                    else
                    {

                        double disc = Convert.ToDouble(amtdisc.Text);
                    }

                    lbclientna.Text = ds4.Tables[0].Rows[0].ItemArray[26].ToString();
                    citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[25].ToString();
                    agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[19].ToString();
                    citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[20].ToString();
                    rupeetxt.Text = ds4.Tables[0].Rows[0].ItemArray[18].ToString();
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
                        // String BX11 = bx2.ToString();
                        boxcharges1.Text = bx2.ToString("F2");


                    }

                    insertiontxt.Text = totalinsertion.ToString();
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
                    runtxt.Text = date.ToString();

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

                        orderno.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString() + "/" + bukingdate;
                    }
                    else
                    {
                        orderno.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                    //  packaget.Text = packna.ToString();
                    // editxt.Text = packna.ToString(); 
                    string rono1 = orderno1.ToString();
                    string rodate = orderdate.ToString();
                    if (rodate != "" && rono1 != "")
                    {
                        rono.Text = rono1 + rodate;
                    }
                    rono.Text = rono1 + " / " + rodate;




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
                    dytbl += "<table>";
                    for (packlength = 0; packlength < c1; packlength++)
                    {

                        if (counted <= 1)
                        {


                            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                            {
                                NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();
                                ds3 = objedition1.edition(packagecode1[packlength], Session["compcode"].ToString());
                            }
                            else
                            {
                                NewAdbooking.BillingClass.classesoracle.invoice objedition1 = new NewAdbooking.BillingClass.classesoracle.invoice();
                                ds3 = objedition1.edition(packagecode1[packlength], Session["compcode"].ToString());
                            }
                        }

                        else
                        {
                            editionname = packagecode1[packlength];
                        }



                        txtpackname.Text = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                        string editionname1 = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {

                            NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();

                           // ds4 = objedition1.values_bill(ciobookingid, editionname, i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                        }
                        else
                        {
                            NewAdbooking.BillingClass.classesoracle.invoice objvalues1 = new NewAdbooking.BillingClass.classesoracle.invoice();

                            ds4 = objvalues1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                        }



                        adcat.Text = ds4.Tables[0].Rows[0].ItemArray[12].ToString();

                        if (ds4.Tables[0].Rows[0]["paydate"].ToString() != "")
                        {
                            Label17.Text = ds4.Tables[0].Rows[0]["paydate"].ToString() + ". (Int. @ 2% will be charged after payable by date)";
                        }
                        else
                        {
                            Label17.Text = ds4.Tables[0].Rows[0]["paydatesys"].ToString() + ". (Int. @ 2% will be charged after payable by date)";
                        }
                        //
                        lbhead2.Text = ds4.Tables[0].Rows[0].ItemArray[36].ToString();
                        string phone1 = ds4.Tables[0].Rows[0].ItemArray[37].ToString();
                        //comment by gaurav   
                        Label1.Text = phone1 + "-" + ds4.Tables[0].Rows[0].ItemArray[38].ToString();
                        Label3.Text = phone1 + "-" + ds4.Tables[0].Rows[0].ItemArray[39].ToString();

                        //for phone and fax
                        //Label1.Text = "0674-2585351 , ";
                        //Label3.Text = "0674-2588519";
                        //
                        format.Text = ds4.Tables[0].Rows[0].ItemArray[40].ToString();
                        // txtgroup.Text = ds4.Tables[0].Rows[0].ItemArray[41].ToString();

                        string amt = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
                        string boxcharges = ds4.Tables[0].Rows[0].ItemArray[21].ToString();
                        double amt1 = 0;
                        if (amt != "")
                        {
                            amt1 = Convert.ToDouble(amt);
                        }
                        //amt1 = "";
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

                        //////////////////////////////////////////////////////////////////////////////////////

                        double amountforvat = Convert.ToDouble(amt3);


                        lbpack.Text = packrate1.ToString();



                        // string bill_amt = ds4.Tables[0].Rows[0].ItemArray["Bill_Amt"].ToString();


                        if (ds4.Tables[0].Rows[0]["Bill_Amt"].ToString() != "")
                            amountinckudingboxbill = amountinckudingboxbill + Convert.ToDouble(ds4.Tables[0].Rows[0]["Bill_Amt"].ToString());





                        string discountstr = ds4.Tables[0].Rows[0].ItemArray[10].ToString();
                        if (discountstr != "")
                            discountint = Convert.ToDouble(discountstr);
                        else
                            discountint = Convert.ToInt16(0);







                        /////////////////////////////////////////////////////////////////////////////////

                        dytbl += "<tr>";
                        dytbl += "<td width=65px   align=left >" + ds4.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                        //dytbl += "<td width=49px   align=center >" + ds4.Tables[0].Rows[0].ItemArray[15].ToString() + "</td>";
                        if (ds4.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                        {
                            dytbl += "<td width=63px  align=center >" + ds4.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                        }
                        else
                        {
                            dytbl += "<td width=63px  align=center>---</td>";
                        }
                        if (ds4.Tables[0].Rows[0].ItemArray[4].ToString() != "")
                        {
                            dytbl += "<td width=63px  align=center>" + ds4.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                        }
                        else
                        {
                            dytbl += "<td width=63px  align=center>---</td>";
                        }
                        dytbl += "<td width=63px  align=center>" + ds4.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                        dytbl += "<td width=73px  align=left>" + ds4.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>";
                        if (ds4.Tables[0].Rows[0].ItemArray[29].ToString() != "")
                        {
                            dytbl += "<td width=63px  align=center >" + ds4.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>";
                        }
                        else
                            dytbl += "<td width=63px  align=center>---</td>";


                        if (ds4.Tables[0].Rows[0].ItemArray[30].ToString() != "")
                            dytbl += "<td width=63px  align=left>" + ds4.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";
                        else
                            dytbl += "<td width=63px  align=left>---</td>";


                        if (ds4.Tables[0].Rows[0].ItemArray[34].ToString() != "")

                            dytbl += "<td width=63px  align=center>" + ds4.Tables[0].Rows[0].ItemArray[34].ToString() + "</td>";
                        else
                            dytbl += "<td width=63px  align=center>---</td>";

                        dytbl += "</tr>";



                    }



                    dytbl += "</table>";




                    dynamictable.Text = dytbl;


                    double amountprem = amt4 * (premiumper1 / 100);
                    txtprem.Text = amountprem.ToString();
                    txch.Text = ds4.Tables[0].Rows[0].ItemArray[31].ToString();
                    amtdisc.Text = ds4.Tables[0].Rows[0].ItemArray[32].ToString();
                    txtper.Text = ds4.Tables[0].Rows[0].ItemArray[33].ToString();







                    amount1.Text = amt4.ToString("F2");

                    if (txch.Text == "")
                    {
                        txch.Text = "0";
                    }
                    if (amtdisc.Text == "")
                    {
                        amtdisc.Text = "0";
                    }

                    if (txch.Text != "")
                    {
                        spcharges = Convert.ToDouble(txch.Text);
                    }
                    if (amtdisc.Text != "")
                    {
                        spdes = Convert.ToDouble(amtdisc.Text);
                    }


                    if (txtper.Text != "")
                    {
                        dispr = Convert.ToDouble(txtper.Text);
                    }


                    amountprem = amt4 + amountprem - (spcharges + spdes);
                    txtgr.Text = amountprem.ToString("F2");
                    double disper1 = amountprem * (dispr / 100);
                    txtdiscal.Text = disper1.ToString();
                    //break;


                    ///////////



                    //amountinckudingbox = amountprem + boxchg1 + disper1;  //comment by gaurav in sambad
                    amountinckudingbox = amountprem + boxchg1 - disper1;
                    txttotal.Text = amountinckudingbox.ToString();
                    double amountforvat1 = 0;
                    DataSet dsvat = new DataSet();
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {

                        NewAdbooking.BillingClass.Classes.billing_save objvat = new NewAdbooking.BillingClass.Classes.billing_save();
                        dsvat = objvat.vatrate(bookingdate, Session["compcode"].ToString());
                    }
                    else
                    {
                        string[] bookingdate1 = bookingdate.Split(' ');
                        NewAdbooking.BillingClass.classesoracle.billing_save objvat = new NewAdbooking.BillingClass.classesoracle.billing_save();

                        dsvat = objvat.vatrate(bookingdate1[0], Session["compcode"].ToString(), Session["dateformat"].ToString());

                    }
                    int count = dsvat.Tables[1].Rows.Count;
                    int vat2 = 0;
                    double vrate = 0;
                    for (vat2 = 0; vat2 < count; vat2++)
                    {
                        string vatrate = dsvat.Tables[1].Rows[vat2].ItemArray[1].ToString();
                        double vatrate1 = Convert.ToDouble(vatrate);
                        vrate = amountinckudingbox * vatrate1 / 100;
                        if (vat2 == 0)
                        {

                            double vrate2 = Math.Round(vrate);
                            lblamt.Text = vrate2.ToString();
                        }
                        else
                            if (vat2 == 1)
                            {
                                double vrate2 = Math.Round(vrate);
                                lbled.Text = vrate2.ToString();
                            }
                            else
                            {
                                double vrate2 = Math.Round(vrate);
                                lblser.Text = vrate2.ToString();
                            }



                        amountinckudingbox = amountinckudingbox + vrate;




                    }
                    ///////////////////////////////////////////////////////////////////////////////////////////////

                    double amountinckudingbox1 = Math.Round(amountinckudingboxbill);
                    netpay.Text = amountinckudingbox1.ToString();
                    netacc.Text = amountinckudingbox1.ToString();


                    NumberToEngish obj = new NumberToEngish();

                    rupeetxt.Text = obj.changeNumericToWords(amountinckudingbox1.ToString()) + "Only";

                    Label10.Text = "4)All disputes are Subject to " + qbc + " Jurisdiction.";







                    ///////////





















                }





            }

            catch (Exception e)
            {
                Response.Write(e.Message);
                //throw (e);


            }
            finally
            {
            }

    






    }

    public void setcardnew_hari()
    {



        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double finalamount = 0;
        double discountint = 0;
        int totinsertnewint = 0;
        int chk = 0;


        double amountinckudingboxbill = 0.01;


        String dytbl;
        dytbl = "";
        int count11 = Convert.ToInt16(insertion);
        int packlength22 = Convert.ToInt16(packagelength);

        string packagecode11 = packagecode.ToString();

        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();


        int i11 = 1;
        int packlength = 0;
        string ciobookingid = id.ToString();
        string editionname = "";
        int totinsert = Convert.ToInt16(totalinsertion);

        string i12 = totinsert.ToString();
        string[] packagecode1 = packagecode11.Split(',');
        int c1 = packagecode1.Length;

        //====================================

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
            ds3 = objedition.edition(packagecode1[packlength], Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.invoice objedition = new NewAdbooking.BillingClass.classesoracle.invoice();
            ds3 = objedition.edition(packagecode1[packlength], Session["compcode"].ToString());

        }
        string editionnametest = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
        //==================================


        string[] editionnametest1 = editionnametest.Split('+');
        int counted = editionnametest1.Length;
        if (counted > 1)
        {
            c1 = counted;
            packagecode1 = editionnametest.Split('+');
            //editionname =packagecode1

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


             






            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                
                NewAdbooking.BillingClass.Classes.invoice objvalues = new NewAdbooking.BillingClass.Classes.invoice();
             //   ds4 = objvalues.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
            }
            else
            {

                NewAdbooking.BillingClass.classesoracle.invoice objvalues = new NewAdbooking.BillingClass.classesoracle.invoice();
                ds4 = objvalues.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());

            }


           
            adcat.Text = ds4.Tables[0].Rows[0].ItemArray[12].ToString();

        

            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/bill.xml"));         
            
            rono.Text = ds4.Tables[0].Rows[0].ItemArray[8].ToString();      

            amtdisc.Text = ds4.Tables[0].Rows[0].ItemArray[10].ToString();
            if (amtdisc.Text == "")
            { }
            else
            {

                double disc = Convert.ToDouble(amtdisc.Text);
            }

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
                boxcharges1.Text = bx2.ToString();


            }

            insertiontxt.Text = totalinsertion.ToString();
            txtinvoice.Text = invoiceno.ToString();


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

                orderno.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString() + "/" + bukingdate;
            }
            else
            {
                orderno.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            
            string rono1 = orderno1.ToString();
            string rodate = orderdate.ToString();
            if (rodate != "" && rono1 != "")
            {
                rono.Text = rono1 + rodate;
            }
            rono.Text = rono1 + " / " + rodate;




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
            string dateto = "";
            string chk_billtype = "dispaly";
            dytbl += "<table>";
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



              
                string[] editionnamenew_latest = editionname.Split('+');
                int counteditin_latest = editionnamenew_latest.Length;


                for (int a_ed = 0; a_ed < counteditin_latest; a_ed++)
                {
                    editionname = editionnamenew_latest[a_ed];
               

                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {                       

                    
                        NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();
                       // ds4 = objedition1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                    }
                    else
                    {
                        NewAdbooking.BillingClass.classesoracle.invoice objvalues1 = new NewAdbooking.BillingClass.classesoracle.invoice();
                        ds4 = objvalues1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());


                    }

                  
                

            
                  

                string amt = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
                string boxcharges = ds4.Tables[0].Rows[0].ItemArray[21].ToString();
                double amt1 = 0;
                if (amt != "")
                {
                    amt1 = Convert.ToDouble(amt);
                }
               
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

                //////////////////////////////////////////////////////////////////////////////////////

                double amountforvat = Convert.ToDouble(amt3);


                lbpack.Text = packrate1.ToString();







                if (ds4.Tables[0].Rows[0]["Bill_Amt"].ToString() != "")
                    amountinckudingboxbill = amountinckudingboxbill + Convert.ToDouble(ds4.Tables[0].Rows[0]["Bill_Amt"].ToString());

                    





                string discountstr = ds4.Tables[0].Rows[0].ItemArray[10].ToString();
                if (discountstr != "")
                    discountint = Convert.ToDouble(discountstr);
                else
                    discountint = Convert.ToInt16(0);






                string Ins_No = ds4.Tables[0].Rows[0]["Ins.No."].ToString();







                //////////////////////////////

                string insert_id = ds4.Tables[0].Rows[0]["insert_id"].ToString();

                dateto  = ds4.Tables[0].Rows[0]["insert_date"].ToString();

                DataSet dsnew1 = new DataSet();
                DataSet ds5 = new DataSet();
                string result = "";
             
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                    NewAdbooking.BillingClass.Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass.Classes.billing_save();
                    ds5 = fetchinvoice.fetchinsertid(insert_id);
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();
                    ds5 = fetchinvoice.fetchinsertid(insert_id);
                }
                if (ds5.Tables[0].Rows.Count == 0)
                {

                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        //if (Session["bill_type"].ToString() == "1")
                        //{

                            NewAdbooking.BillingClass.Classes.session_billing objbkcenter = new NewAdbooking.BillingClass.Classes.session_billing();
                            result = objbkcenter.save_det_monthly(ciobookingid, txtinvoice.Text, ds4.Tables[0].Rows[0].ItemArray[22].ToString(), amt1, boxchg1, Ins_No, ds4.Tables[0].Rows[0].ItemArray[29].ToString(), dateto, Session["dateformat"].ToString(), insert_id, chk_billtype);
                        //}
                        //else
                        //{
                        //    NewAdbooking.BillingClass.Classes.session_billing objbkcenter = new NewAdbooking.BillingClass.Classes.session_billing();
                        //    result = objbkcenter.save_det_monthly_ro(ciobookingid, txtinvoice.Text, ds4.Tables[0].Rows[0].ItemArray[22].ToString(), amt1, boxchg1, Ins_No, ds4.Tables[0].Rows[0].ItemArray[29].ToString(), dateto, Session["dateformat"].ToString(), insert_id, chk_billtype);
                        //}

                        }
                        else
                        {
                             NewAdbooking.BillingClass.classesoracle.billing_save objbkcenter = new NewAdbooking.BillingClass.classesoracle.billing_save();
                             dsnew1 = objbkcenter.save_det_insert(ciobookingid, txtinvoice.Text, ds4.Tables[0].Rows[0].ItemArray[22].ToString(), amt1, boxchg1, Ins_No, ds4.Tables[0].Rows[0].ItemArray[29].ToString(), insert_id);

                        }
                }

            }
               /////////////////
                //for

            }



            dytbl += "</table>";




            dynamictable.Text = dytbl;


            double amountprem = amt4 * (premiumper1 / 100);
            txtprem.Text = amountprem.ToString();
            txch.Text = ds4.Tables[0].Rows[0].ItemArray[31].ToString();
            amtdisc.Text = ds4.Tables[0].Rows[0].ItemArray[32].ToString();
            txtper.Text = ds4.Tables[0].Rows[0].ItemArray[33].ToString();







            amount1.Text = amt4.ToString("F2");

            if (txch.Text == "")
            {
                txch.Text = "0";
            }
            if (amtdisc.Text == "")
            {
                amtdisc.Text = "0";
            }

            if (txch.Text != "")
            {
                spcharges = Convert.ToDouble(txch.Text);
            }
            if (amtdisc.Text != "")
            {
                spdes = Convert.ToDouble(amtdisc.Text);
            }


            if (txtper.Text != "")
            {
                dispr = Convert.ToDouble(txtper.Text);
            }


            amountprem = amt4 + amountprem - (spcharges + spdes);
            txtgr.Text = amountprem.ToString();
            double disper1 = amountprem * (dispr / 100);
            txtdiscal.Text = disper1.ToString();

            double gross_amt = amountprem + boxchg1;
            gross_amt = Math.Round(gross_amt);
            string gros_amt = gross_amt.ToString();
         
            amountinckudingbox = amountprem + boxchg1 - disper1;
            txttotal.Text = amountinckudingbox.ToString();
            amountinckudingboxbill = amountinckudingboxbill + 0.01;

            double amountinckudingbox1 = Math.Round(amountinckudingboxbill);
            netpay.Text = amountinckudingbox1.ToString();
            netacc.Text = amountinckudingbox1.ToString();


            NumberToEngish obj = new NumberToEngish();
            rupeetxt.Text = obj.changeNumericToWords(amountinckudingbox1.ToString()) + "Only";
            Label10.Text = "4)All disputes are Subject to " + qbc + " Jurisdiction.";
            ///////////

            DataSet dfetch = new DataSet();




            if (valueofradio == "2")
            {

                if (packlength == c1)
                {

                    //////////////

                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        

                        NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                        dfetch = objsave.fetchstatus_bills(ds4.Tables[0].Rows[0].ItemArray[0].ToString(), totinsert);



                    }
                    else
                    {
                        NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.BillingClass.Classes.billing_save();
                        dfetch = objsave.fetchstatus(orderno.Text, totinsert);


                    }
                    if (dfetch.Tables [0].Rows .Count ==0)
                    {

                        /////////

                        finalamount = amountinckudingbox * totinsert;
                        DataSet dssave = new DataSet();
                        DataSet dsxml = new DataSet();
                        dsxml.ReadXml(Server.MapPath("XML/bill.xml"));
                        string doctyp = dsxml.Tables[1].Rows[0].ItemArray[0].ToString();
                       
                        string result = "";
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {

                            NewAdbooking.BillingClass.Classes.session_billing objsave = new NewAdbooking.BillingClass.Classes.session_billing();
                            result = objsave.saveinlast(ds4.Tables[0].Rows[0].ItemArray[0].ToString(), txtinvoice.Text, netpay.Text, gros_amt, boxchg1, totinsert, doctyp, insertiontxt.Text, dateto, Session["dateformat"].ToString(), chk_billtype);

                           // NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.BillingClass.Classes.billing_save();
                            //dssave = objsave.saveinsertiowise(ds4.Tables[0].Rows[0].ItemArray[0].ToString(), txtinvoice.Text, netpay.Text, txttotal.Text, totinsert, boxchg1, insertiontxt.Text, edicode, finalamount, discountint,premiumper1 );
                        }
                        else
                        {

                            //DataSet dsxml = new DataSet();
                            //dsxml.ReadXml(Server.MapPath("XML/bill.xml"));
                            //string doctyp = dsxml.Tables[1].Rows[0].ItemArray[0].ToString();
                            //NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                            //dssave = objsave.saveinsertiowise(ds4.Tables[0].Rows[0].ItemArray[0].ToString(), txtinvoice.Text, netpay.Text, txttotal.Text, totinsert, boxchg1, insertiontxt.Text, edicode, finalamount, discountint, doctyp, premiumper1);

                          
                            NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                            dssave = objsave.saveininsertion(ds4.Tables[0].Rows[0].ItemArray[0].ToString(), txtinvoice.Text, netpay.Text, gros_amt, boxchg1, totinsert, doctyp, insertiontxt.Text, Session["dateformat"].ToString(), chk_billtype);
             


                        }

                    }
                }
            }

            showtable.Visible = false;







        }//package









    }

////////////////////////////////////////

     public void setcardnew()
    {



        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double finalamount = 0;
        double discountint = 0;
        int totinsertnewint = 0;
        int chk = 0;


        double amountinckudingboxbill = 0.01;


        String dytbl;
        dytbl = "";
        int count11 = Convert.ToInt16(insertion);
        int packlength22 = Convert.ToInt16(packagelength);

        string packagecode11 = packagecode.ToString();

        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();


        int i11 = 1;
        int packlength = 0;
        string ciobookingid = id.ToString();
        string editionname = "";
        int totinsert = Convert.ToInt16(totalinsertion);

        string i12 = totinsert.ToString();
        string[] packagecode1 = packagecode11.Split(',');
        int c1 = packagecode1.Length;
        string[] packagecode_val = packagecode11.Split(',');
        string unique_number = "";


        DataSet unique_data = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
            unique_data = objedition.fetchnextvalue();
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.invoice objedition = new NewAdbooking.BillingClass.classesoracle.invoice();
            unique_data = objedition.fetchnextvalue();



        }
        unique_number = unique_data.Tables[0].Rows[0]["newPass"].ToString();


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
                    if (editionname == "")
                    {
                        editionname = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                    else
                    {
                        editionname = editionname + "+" + ds3.Tables[0].Rows[0].ItemArray[0].ToString();
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
            //editionname =packagecode1

        }




        for (packlength = 0; packlength < c1; packlength++)
        {
            string pack_naem = packagecode_val[packlength]; 
            
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

            
             






            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                
                NewAdbooking.BillingClass.Classes.invoice objvalues = new NewAdbooking.BillingClass.Classes.invoice();
                ds4 = objvalues.values_bill_state(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString(), pack_naem);
            }
            else
            {

                NewAdbooking.BillingClass.classesoracle.invoice objvalues = new NewAdbooking.BillingClass.classesoracle.invoice();
                ds4 = objvalues.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());

            }


           
            adcat.Text = ds4.Tables[0].Rows[0].ItemArray[12].ToString();

        

            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/bill.xml"));         
            
            rono.Text = ds4.Tables[0].Rows[0].ItemArray[8].ToString();      

            amtdisc.Text = ds4.Tables[0].Rows[0].ItemArray[10].ToString();
            if (amtdisc.Text == "")
            { }
            else
            {

                double disc = Convert.ToDouble(amtdisc.Text);
            }

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
                boxcharges1.Text = bx2.ToString();


            }

            insertiontxt.Text = totalinsertion.ToString();
            txtinvoice.Text = invoiceno.ToString();


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

                orderno.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString() + "/" + bukingdate;
            }
            else
            {
                orderno.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            
            string rono1 = orderno1.ToString();
            string rodate = orderdate.ToString();
            if (rodate != "" && rono1 != "")
            {
                rono.Text = rono1 + rodate;
            }
            rono.Text = rono1 + " / " + rodate;




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
            string dateto = "";
            string chk_billtype = "dispaly";
            dytbl += "<table>";
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



              
                string[] editionnamenew_latest = editionname.Split('+');
                int counteditin_latest = editionnamenew_latest.Length;


                for (int a_ed = 0; a_ed < counteditin_latest; a_ed++)
                {
                    editionname = editionnamenew_latest[a_ed];
                    if(packagecode_val.Length>1)
                     pack_naem = packagecode_val[packlength]; 

                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {                       

                    
                        NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();
                        //ds4 = objedition1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString(), pack_naem);
                        ds4 = objedition1.values_bill_state(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString(), pack_naem);
                    }
                    else
                    {
                        NewAdbooking.BillingClass.classesoracle.invoice objvalues1 = new NewAdbooking.BillingClass.classesoracle.invoice();
                        ds4 = objvalues1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());


                    }

                  
                

            
                  

                string amt = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
                string boxcharges = ds4.Tables[0].Rows[0].ItemArray[21].ToString();
                double amt1 = 0;
                if (amt != "")
                {
                    amt1 = Convert.ToDouble(amt);
                }
               
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

                //////////////////////////////////////////////////////////////////////////////////////

                double amountforvat = Convert.ToDouble(amt3);


                lbpack.Text = packrate1.ToString();







                if (ds4.Tables[0].Rows[0]["Bill_Amt"].ToString() != "")
                    amountinckudingboxbill = amountinckudingboxbill + Convert.ToDouble(ds4.Tables[0].Rows[0]["Bill_Amt"].ToString());

                    





                string discountstr = ds4.Tables[0].Rows[0].ItemArray[10].ToString();
                if (discountstr != "")
                    discountint = Convert.ToDouble(discountstr);
                else
                    discountint = Convert.ToInt16(0);






                string Ins_No = ds4.Tables[0].Rows[0]["Ins.No."].ToString();







                //////////////////////////////

                string insert_id = ds4.Tables[0].Rows[0]["insert_id"].ToString();

                dateto  = ds4.Tables[0].Rows[0]["insert_date"].ToString();

                DataSet dsnew1 = new DataSet();
                DataSet ds5 = new DataSet();
                string result = "";
             
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                    NewAdbooking.BillingClass.Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass.Classes.billing_save();
                    ds5 = fetchinvoice.fetchinsertid(insert_id);
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();
                    ds5 = fetchinvoice.fetchinsertid(insert_id);
                }
                if (ds5.Tables[0].Rows.Count == 0)
                {

                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        

                          //  NewAdbooking.BillingClass.Classes.session_billing objbkcenter = new NewAdbooking.BillingClass.Classes.session_billing();
                           // result = objbkcenter.save_det_monthly(ciobookingid, txtinvoice.Text, ds4.Tables[0].Rows[0].ItemArray[22].ToString(), amt1, boxchg1, Ins_No, ds4.Tables[0].Rows[0].ItemArray[29].ToString(), dateto, Session["dateformat"].ToString(), insert_id, chk_billtype);

                        NewAdbooking.BillingClass.Classes.session_billing objbkcenter = new NewAdbooking.BillingClass.Classes.session_billing();
                        //unique_data
                        // result = objbkcenter.save_det_monthly(ciobookingid, txtinvoice.Text, ds4.Tables[0].Rows[0].ItemArray[22].ToString(), amt1, boxchg1, Ins_No, ds4.Tables[0].Rows[0].ItemArray[29].ToString(), dateto, Session["dateformat"].ToString(), insert_id, chk_billtype);
                        result = objbkcenter.save_det_monthly_vision(ciobookingid, unique_data.Tables[0].Rows[0]["newPass"].ToString(), ds4.Tables[0].Rows[0].ItemArray[22].ToString(), amt1, boxchg1, Ins_No, ds4.Tables[0].Rows[0].ItemArray[29].ToString(), dateto, Session["dateformat"].ToString(), insert_id, chk_billtype);
                         

                       

                        }
                        else
                        {
                             NewAdbooking.BillingClass.classesoracle.billing_save objbkcenter = new NewAdbooking.BillingClass.classesoracle.billing_save();
                             dsnew1 = objbkcenter.save_det_insert(ciobookingid, txtinvoice.Text, ds4.Tables[0].Rows[0].ItemArray[22].ToString(), amt1, boxchg1, Ins_No, ds4.Tables[0].Rows[0].ItemArray[29].ToString(), insert_id);

                        }
                }

            }
               /////////////////
                //for

            }



            dytbl += "</table>";




            dynamictable.Text = dytbl;


            double amountprem = amt4 * (premiumper1 / 100);
            txtprem.Text = amountprem.ToString();
            txch.Text = ds4.Tables[0].Rows[0].ItemArray[31].ToString();
            amtdisc.Text = ds4.Tables[0].Rows[0].ItemArray[32].ToString();
            txtper.Text = ds4.Tables[0].Rows[0].ItemArray[33].ToString();







            amount1.Text = amt4.ToString("F2");

            if (txch.Text == "")
            {
                txch.Text = "0";
            }
            if (amtdisc.Text == "")
            {
                amtdisc.Text = "0";
            }

            if (txch.Text != "")
            {
                spcharges = Convert.ToDouble(txch.Text);
            }
            if (amtdisc.Text != "")
            {
                spdes = Convert.ToDouble(amtdisc.Text);
            }


            if (txtper.Text != "")
            {
                dispr = Convert.ToDouble(txtper.Text);
            }


            amountprem = amt4 + amountprem - (spcharges + spdes);
            txtgr.Text = amountprem.ToString();
            double disper1 = amountprem * (dispr / 100);
            txtdiscal.Text = disper1.ToString();

            double gross_amt = amountprem + boxchg1;
            gross_amt = Math.Round(gross_amt);
            string gros_amt = gross_amt.ToString();
         
            amountinckudingbox = amountprem + boxchg1 - disper1;
            txttotal.Text = amountinckudingbox.ToString();
            amountinckudingboxbill = amountinckudingboxbill + 0.01;

            double amountinckudingbox1 = Math.Round(amountinckudingboxbill);
            netpay.Text = amountinckudingbox1.ToString();
            netacc.Text = amountinckudingbox1.ToString();


            NumberToEngish obj = new NumberToEngish();
            rupeetxt.Text = obj.changeNumericToWords(amountinckudingbox1.ToString()) + "Only";
            Label10.Text = "4)All disputes are Subject to " + qbc + " Jurisdiction.";
            ///////////

            DataSet dfetch = new DataSet();




            if (valueofradio == "2")
            {

                if (packlength == c1)
                {

                    //////////////

                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        

                        NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                        dfetch = objsave.fetchstatus_bills(ds4.Tables[0].Rows[0].ItemArray[0].ToString(), totinsert);



                    }
                    else
                    {
                        NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.BillingClass.Classes.billing_save();
                        dfetch = objsave.fetchstatus(orderno.Text, totinsert);


                    }
                    if (dfetch.Tables [0].Rows .Count ==0)
                    {

                        /////////

                        finalamount = amountinckudingbox * totinsert;
                        DataSet dssave = new DataSet();
                        DataSet dsxml = new DataSet();
                        dsxml.ReadXml(Server.MapPath("XML/bill.xml"));
                        string doctyp = dsxml.Tables[1].Rows[0].ItemArray[0].ToString();
                       
                        string result = "";
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {


                            NewAdbooking.BillingClass.Classes.session_billing objsave = new NewAdbooking.BillingClass.Classes.session_billing();
                            result = objsave.saveinlast_vision(ds4.Tables[0].Rows[0].ItemArray[0].ToString(), txtinvoice.Text, netpay.Text, gros_amt, boxchg1, totinsert, doctyp, insertiontxt.Text, dateto, Session["dateformat"].ToString(), chk_billtype, unique_number);


                          //  NewAdbooking.BillingClass.Classes.session_billing objsave = new NewAdbooking.BillingClass.Classes.session_billing();
                           // result = objsave.saveinlast(ds4.Tables[0].Rows[0].ItemArray[0].ToString(), txtinvoice.Text, netpay.Text, gros_amt, boxchg1, totinsert, doctyp, insertiontxt.Text, dateto, Session["dateformat"].ToString(), chk_billtype);

                           // NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.BillingClass.Classes.billing_save();
                            //dssave = objsave.saveinsertiowise(ds4.Tables[0].Rows[0].ItemArray[0].ToString(), txtinvoice.Text, netpay.Text, txttotal.Text, totinsert, boxchg1, insertiontxt.Text, edicode, finalamount, discountint,premiumper1 );
                        }
                        else
                        {

                            //DataSet dsxml = new DataSet();
                            //dsxml.ReadXml(Server.MapPath("XML/bill.xml"));
                            //string doctyp = dsxml.Tables[1].Rows[0].ItemArray[0].ToString();
                            //NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                            //dssave = objsave.saveinsertiowise(ds4.Tables[0].Rows[0].ItemArray[0].ToString(), txtinvoice.Text, netpay.Text, txttotal.Text, totinsert, boxchg1, insertiontxt.Text, edicode, finalamount, discountint, doctyp, premiumper1);

                          
                            NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                            dssave = objsave.saveininsertion(ds4.Tables[0].Rows[0].ItemArray[0].ToString(), txtinvoice.Text, netpay.Text, gros_amt, boxchg1, totinsert, doctyp, insertiontxt.Text, Session["dateformat"].ToString(), chk_billtype);
             


                        }

                    }
                }
            }

            showtable.Visible = false;







        }//package









    }

/////////////////////////////////////
  
   


    
}

