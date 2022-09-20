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

public partial class prhaarre : System.Web.UI.UserControl
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
    public string _packgerate;
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
   //public static string _agency;
   // public static string _package;
   // public static string _insertion;
   // public static string _bookingid;
   // public static string _height;
   // public static string _width;
   // public static string _color;
   // public static string _volume;
   // public static string _adcat;
   // public static string _pageposition;
   // public static string _scheme;
   // public static string _rono_date;

   // public static string _publication;

   // public static string _rundate;
   // public static string _packgerate;
   // public static string _orderno;
   // public static string _amount;
   // public static string _discount;
   // public static string _edition1;
   // public static string _client;
   // public static string _agencycode;
   // public static string _agddxt1;
   // public static string _city;
   // public static string _tbl;
   // public static string _currency;
   // public static string _boxcharges;
   // public static string _packagelength;
   // public static string _packagecode;
   // public static string _id;
   // public static string _invoiceno;
   // public static string _totalinsertion;
   // public static string _bookingdate;
   // public static string _orderdate;
   // public static string _valueofradio;
   // public static string _qbc;
   // public static string _editionnameplus;

    public prhaarre()
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
    string collumn_uom = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/bill.xml"));
        lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbtype.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbstandard.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();   
        lbscheme.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbnumber.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbordernumber.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();   
        lbpackagerate.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();   
        lblamount.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        lbltotal.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        lblbox.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        lblnet.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        lbformatproposal.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
        lbinsertionnumber.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
        lblwhile.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
        lbpanno.Text = ds.Tables[0].Rows[0].ItemArray[31].ToString();
        txtpan.Text = ds.Tables[0].Rows[0].ItemArray[60].ToString();
        lbproductkey.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();
        lbrupee.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        lbpub.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        lbheadoffice.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString();
        lbto.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        lbpackagena.Text = ds.Tables[0].Rows[0].ItemArray[38].ToString();
        lbvat.Text = ds.Tables[0].Rows[0].ItemArray[39].ToString();
        lbeduca.Text = ds.Tables[0].Rows[0].ItemArray[40].ToString();
        lbservice.Text = ds.Tables[0].Rows[0].ItemArray[41].ToString();
        lbheadoffice.Text = ds.Tables[0].Rows[0].ItemArray[43].ToString();
        lbextrach.Text = ds.Tables[0].Rows[0].ItemArray[47].ToString();
        lbltrade.Text = ds.Tables[0].Rows[0].ItemArray[48].ToString();
        lbgr.Text = ds.Tables[0].Rows[0].ItemArray[49].ToString();
        lbtdper.Text = ds.Tables[0].Rows[0].ItemArray[50].ToString();
        lbtrade1.Text = ds.Tables[0].Rows[0].ItemArray[51].ToString();
        remark.Text = ds.Tables[0].Rows[0].ItemArray[52].ToString();


    }

    public void setcard()
    {

        string day = "";
        string month = "";
        string year = "";
        string date = "";
        string date1 = "";
        double finalamount = 0;
        double  discountint = 0;
        int totinsertnewint = 0;
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
        int totinsert = Convert.ToInt16(totalinsertion);
        string i12 = insertion.ToString();
        string[] packagecode1 = packagecode11.Split(',');
        int c1 = packagecode1.Length;
        for (packlength = 0; packlength < c1; packlength++)
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

            string editionname = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
            txtpackname.Text = editionnameplus.ToString();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.invoice objvalues = new NewAdbooking.BillingClass.Classes.invoice();
                ds4 = objvalues.values_bill(ciobookingid, editionname, totinsert.ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.invoice objvalues = new NewAdbooking.BillingClass.classesoracle.invoice();
                ds4 = objvalues.values_bill(ciobookingid, editionname, totinsert.ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

            }
            adcat.Text = ds4.Tables[0].Rows[0].ItemArray[12].ToString();

            //garima
            //position.Text = ds4.Tables[0].Rows[0].ItemArray[11].ToString();
            collumn_uom = ds4.Tables[0].Rows[0].ItemArray[44].ToString();
          
            rono.Text = ds4.Tables[0].Rows[0].ItemArray[42].ToString();

            if (ds4.Tables[0].Rows[0].ItemArray[42].ToString() != "client")
            {
                ////agency
                agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[1].ToString();
                agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[19].ToString();

                ////client
                lbclientna.Text = ds4.Tables[0].Rows[0].ItemArray[26].ToString();
                citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[25].ToString();

                citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[20].ToString();



            }
            else
            {
                ////agency
                agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[26].ToString();
                agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[25].ToString();
                agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[20].ToString();

                ////client
                lbclientna.Text = ds4.Tables[0].Rows[0].ItemArray[1].ToString();
                citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[19].ToString();

                citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[19].ToString();
            }
            // agencycod.Text = ds4.Tables[0].Rows[0].ItemArray[17].ToString();
            pubtxt.Text = ds4.Tables[0].Rows[0].ItemArray[2].ToString();
            orderno.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString();


            amtdisc.Text = ds4.Tables[0].Rows[0].ItemArray[10].ToString();
            double disc = 0;
            if (amtdisc.Text != "")
            {
                 disc = Convert.ToDouble(amtdisc.Text);
            }

        
            rupeetxt.Text = ds4.Tables[0].Rows[0].ItemArray[18].ToString();
            string totinsertnew = ds4.Tables[0].Rows[0].ItemArray[27].ToString();
            totinsertnewint = Convert.ToInt16(totinsertnew);
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
                    date = day + "/" + month + "/" + year;
                    //

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

            ///

            //if (Session["dateformat"].ToString() == "dd/mm/yyyy".ToString())
            //{



            //    string[] arr = bookingdate.Split('/');
            //    string dd = arr[1];
            //    string mm = arr[0];
            //    string yy = arr[2];
            //    date1 = dd + "/" + mm + "/" + yy;

            //}
            //else
            //    if (Session["dateformat"].ToString() == "mm/dd/yyyy".ToString())
            //    {



            //        string[] arr = bookingdate.Split('/');
            //        string dd = arr[1];
            //        string mm = arr[0];
            //        string yy = arr[2];
            //        date1 = dd + "/" + mm + "/" + yy;
            //        //

            //    }
            //    else
            //        if (Session["dateformat"].ToString() == "yyyy/mm/dd".ToString())
            //        {

            //            string[] arr = bookingdate.Split('/');
            //            string dd = arr[1];
            //            string mm = arr[0];
            //            string yy = arr[2];
            //            date1 = yy + "/" + mm + "/" + dd;

            //        }

            //


          


            //runtxt.Text = date.ToString();
            date1 = bookingdate.ToString();
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

            //  packaget.Text = packna.ToString();
            // editxt.Text = packna.ToString(); 
            string rono1 = orderno1.ToString();
            string rodate = "";
            if (orderdate != "")
            {
                if (Session["dateformat"].ToString() == "dd/mm/yyyy".ToString())
                {



                    string[] arr = orderdate.ToString().Split('/');
                    string dd = arr[1];
                    string mm = arr[0];
                    string yy = arr[2];
                    rodate = dd + "/" + mm + "/" + yy;

                }
                else
                    if (Session["dateformat"].ToString() == "mm/dd/yyyy".ToString())
                    {



                        string[] arr = orderdate.ToString().Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        rodate = dd + "/" + mm + "/" + yy;
                        //

                    }
                    else
                        if (Session["dateformat"].ToString() == "yyyy/mm/dd".ToString())
                        {

                            string[] arr = orderdate.ToString().Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            rodate = yy + "/" + mm + "/" + dd;

                        }

            }

            rono.Text = rono1 + " " + rodate;

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
            dytbl += "<table align='left' cellpadding='5' cellspacing='0'>";
            {
                DataSet dsb = new DataSet();
                dsb.ReadXml(Server.MapPath("XML/bill.xml"));
                dytbl += "<tr align=center >";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                if (ds4.Tables[0].Rows[0].ItemArray[44].ToString() == "CO0")
                {
                    //lbvolume.Text = lbvolume.Text + "C";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[61].ToString() + "</td>";

                }
                else
                {
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                    }
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[53].ToString() + "</td>";
                dytbl += "</tr>";
            }  



            string editionname1 = "";
            for (packlength = 0; packlength < c1; packlength++)
            {

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();
                    ds3 = objedition1.edition(packagecode1[packlength], Session["compcode"].ToString());
                }
                else
                {
                   // NewAdbooking.classesoracle.invoice objedition1 = new NewAdbooking.classesoracle.invoice();
                    //ds3 = objedition1.edition(packagecode1[packlength], Session["compcode"].ToString());

                }
                
                if (packagecode1[packlength] != "")
                {
                    editionname1 = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                }

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.BillingClass.Classes.invoice objvalues1 = new NewAdbooking.BillingClass.Classes.invoice();

                    ds4 = objvalues1.values_bill(ciobookingid, editionname1, i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.invoice objvalues1 = new NewAdbooking.BillingClass.classesoracle.invoice();

                    ds4 = objvalues1.values_bill(ciobookingid, editionname1, i12, Session["compcode"].ToString(), Session["dateformat"].ToString());

                }

                //
                lbhead2.Text = ds4.Tables[0].Rows[0].ItemArray[36].ToString();
                string phone1 = ds4.Tables[0].Rows[0].ItemArray[37].ToString();
                Label1.Text = phone1 + ds4.Tables[0].Rows[0].ItemArray[38].ToString();
                Label3.Text = phone1 + ds4.Tables[0].Rows[0].ItemArray[39].ToString();
                //
                // txtgroup.Text = ds4.Tables[0].Rows[0].ItemArray[40].ToString();
                string amt = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
                string boxcharges = ds4.Tables[0].Rows[0].ItemArray[21].ToString();
                double amt1 = 0;
                if (amt!="")
                {
                    
                 amt1 = Convert.ToDouble(amt);
                }

                string package_rate = ds4.Tables[0].Rows[0].ItemArray[40].ToString();
                string premiumper2 = ds4.Tables[0].Rows[0].ItemArray[34].ToString();
                if (package_rate != "")
                {
                    packrate = Convert.ToDouble(package_rate);
                    packrate1 = packrate1 + packrate;
                    packrate1 = Math.Round(packrate1, 2);
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













                string discountstr = ds4.Tables[0].Rows[0].ItemArray[10].ToString();


                if (discountstr != "")
                {
                    discountint = Convert.ToDouble(discountstr);
                }



                /////////////////////////////////////////////////////////////////////////////////
          

                dytbl += "<tr>";






                dytbl += "<td  class='insertiontxtclass'  align=left >" + ds4.Tables[0].Rows[0].ItemArray[43].ToString() + "</td>";

                if (ds4.Tables[0].Rows[0].ItemArray[41].ToString() != "")
                {
                    dytbl += "<td width=71px class='insertiontxtclass' align=center >" + ds4.Tables[0].Rows[0].ItemArray[41].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td width=71px class='insertiontxtclass' align=center>---</td>";
                }

                if (ds4.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                {
                    dytbl += "<td width=39px class='insertiontxtclass' align=center >" + ds4.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td width=39px class='insertiontxtclass' align=center>---</td>";
                }
                if (ds4.Tables[0].Rows[0].ItemArray[4].ToString() != "")
                {
                    dytbl += "<td width=39px class='insertiontxtclass' align=center>" + ds4.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td width=39px class='insertiontxtclass' align=center>---</td>";
                }
                dytbl += "<td width=55px class='insertiontxtclass' align=center>" + ds4.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";

                string sel_col = "";
                if (ds4.Tables[0].Rows[0].ItemArray[6].ToString() == "BLACK AND WHITE")
                {
                    sel_col = "B&W";
                    dytbl += "<td width=34px class='insertiontxtclass' align=left>" + sel_col + "</td>";
                }
                else if (ds4.Tables[0].Rows[0].ItemArray[6].ToString() == "COLOR")
                {
                    sel_col = "COL";
                    dytbl += "<td width=34px class='insertiontxtclass' align=left>" + sel_col + "</td>";
                }

                if (ds4.Tables[0].Rows[0].ItemArray[29].ToString() != "")
                {
                    dytbl += "<td width=59px class='insertiontxtclass' align=left >" + ds4.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>";
                }
                else
                    dytbl += "<td width=59px class='insertiontxtclass' align=left>---</td>";


                if (ds4.Tables[0].Rows[0].ItemArray[30].ToString() != "")
                    dytbl += "<td width=72px class='insertiontxtclass' align=left>" + ds4.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";
                else
                    dytbl += "<td width=72px class='insertiontxtclass' align=left>---</td>";


                if (ds4.Tables[0].Rows[0].ItemArray[34].ToString() != "")

                    dytbl += "<td width=67px class='insertiontxtclass' align=center>" + ds4.Tables[0].Rows[0].ItemArray[34].ToString() + "</td>";
                else
                    dytbl += "<td width=67px class='insertiontxtclass' align=center>---</td>";
                // dytbl += "<td width=50px>" + "" + "</td>";  

                // dytbl += "<td width=65px>" + ds4.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>";

                //dytbl += "<td width=50px align=center>" + amt2 + "</td>";
                dytbl += "</tr>";


            }



            dytbl += "</table>";




            //dynamictable.Text = dytbl;
            dynamictable.InnerHtml = dytbl;
            // double amt4 = amt3 + boxchg1;

            double amountprem = amt4 * (premiumper1 / 100);
            txtprem.Text = amountprem.ToString("F2");
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
            txtdiscal.Text = disper1.ToString("F2");
            //break;


            ///////////



            amountinckudingbox = amountprem + boxchg1 - disper1;
            txttotal.Text = amountinckudingbox.ToString("F2");
            double amountforvat1 = 0;
            DataSet dsvat = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save objvat = new NewAdbooking.BillingClass.Classes.billing_save();
                dsvat = objvat.vatrate(bookingdate, Session["compcode"].ToString());
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save objvat = new NewAdbooking.BillingClass.classesoracle.billing_save();
                dsvat = objvat.vatrate(date1, Session["compcode"].ToString(), Session["dateformat"].ToString());

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
                    lblamt.Text = vrate2.ToString("F2");
                }
                else
                    if (vat2 == 1)
                    {
                        double vrate2 = Math.Round(vrate);
                        lbled.Text = vrate2.ToString("F2");
                    }
                    else
                    {
                        double vrate2 = Math.Round(vrate);
                        lblser.Text = vrate2.ToString("F2");
                    }



                amountinckudingbox = amountinckudingbox + vrate;




            }
            ///////////////////////////////////////////////////////////////////////////////////////////////

            // double amountinckudingbox1 = Math.Round(amountinckudingbox);
            string newval = amountinckudingbox.ToString("F2");
            double amountinckudingbox1 = Convert.ToDouble(newval);
            //netpay.Text = amountinckudingbox1.ToString();
            if (amountinckudingbox1.ToString().IndexOf(".") >= 0)
            {
                netpay.Text = Convert.ToString(Math.Round(amountinckudingbox1));
                if (netpay.Text.IndexOf(".") >= 0)
                { }
                else
                {
                    netpay.Text = netpay.Text + ".00";
                }
            }
            else
            {
                netpay.Text = amountinckudingbox1.ToString() + ".00";
            }


            if (amountinckudingbox1.ToString().IndexOf(".") >= 0)
            {
                
                netacc.Text = Convert.ToString(Math.Round(amountinckudingbox1));
                if (netacc.Text.IndexOf(".") >= 0)
                { }
                else
                {
                    netacc.Text = netacc.Text + ".00";
                }
            }
            else
            {
                netacc.Text = amountinckudingbox1.ToString()+".00";
            }
            


            NumberToEngish obj = new NumberToEngish();

            rupeetxt.Text = obj.changeNumericToWords(netpay.Text) + "Only";
            Label8.Text = Label8.Text + " " + qbc;
            Label10.Text = "3)Subject to " + qbc + " Jurisdiction";



             DataSet dssave = new DataSet();

                if (packlength == c1)
                {

                  
                 
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {

                        NewAdbooking.BillingClass .Classes.billing_save objsave = new NewAdbooking.BillingClass .Classes.billing_save();
                        dssave = objsave.updatebillprintstatus(txtinvoice.Text);
                    }
                    else
                    {
                        NewAdbooking.BillingClass.classesoracle.billing_save objabc = new NewAdbooking.BillingClass.classesoracle.billing_save();
                        dssave = objabc.updatebillprintstatus(txtinvoice.Text);


                    }

                }

                String  countBILS = dssave.Tables[0].Rows[0].ItemArray[0].ToString();
                if (countBILS == "1")
            {
                //pagestatus.Text = "ORIGINAL".ToString();
            }
            else
            {
                pagestatus.Text = "DUPLICATE".ToString();
            }



           

           



           


















        }


    }

}