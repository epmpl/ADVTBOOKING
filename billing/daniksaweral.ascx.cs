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


public partial class daniksaweral : System.Web.UI.UserControl
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
    public string _chkvalue_length;
    public daniksaweral()
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
    public string chkvalue_length { get { return _chkvalue_length; } set { _chkvalue_length = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {

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




        string[] editionname_vif;
        int editionlen_vif = 0;

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
                txtpackname.Text = ediplusdate.ToString();
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

            //Sign Image
            string path = "Images/" + ds.Tables[1].Rows[0].ItemArray[1].ToString();
            if (System.IO.File.Exists(Server.MapPath(path)))
            {
                divimg.InnerHtml = "<img src='" + path + "' height='" + ht + "'>";
            }

            agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[1].ToString();
            // street = ds4.Tables[0].Rows[0]["street"].ToString();
            agencyaddtxt.Text = ds4.Tables[0].Rows[0]["add1"].ToString();
            agencyaddtxt.Text = agencyaddtxt.Text + "," + street;
            lbcityname.Text = ds4.Tables[0].Rows[0]["city_name"].ToString();
            // lblagncode.Text = ds4.Tables[0].Rows[0]["agency_sub_code"].ToString();

            txtpinno.Text = ds4.Tables[0].Rows[0]["pin_code"].ToString();
            grossamt = Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_Rate"].ToString());
            traddis = Convert.ToDouble(ds4.Tables[0].Rows[0]["trade_disc"].ToString());
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
            if (ds4.Tables[0].Rows[0]["clientAd"].ToString() != "" && ds4.Tables[0].Rows[0]["clientAd"].ToString() != null)
            {
                client.Attributes.Add("style", "display:block;");
                client1.Attributes.Add("style", "display:none;");
                client2.Attributes.Add("style", "display:none;");
                compnyname.Text = ds4.Tables[0].Rows[0]["client"].ToString();
                //clientcitypin.Text = ds4.Tables[0].Rows[0]["clientZip"].ToString();
                //clientcity.Text = ds4.Tables[0].Rows[0]["clientcity"].ToString();
                compnyaddres.Text = ds4.Tables[0].Rows[0]["clientAd"].ToString();
                //string compstreet     = ds4.Tables[0].Rows[0]["street"].ToString();
                //compnyaddres.Text = compnyaddres.Text + "," + compstreet;
                // lblext.Text = "---";
            }
            else
            {
                client.Attributes.Add("style", "display:none;");
                client1.Attributes.Add("style", "display:block;");
                client2.Attributes.Add("style", "display:block;");
            }


            // lblnetamt.Text = finalamount.ToString("F2");


            lblround.Text = Math.Round(finalamount + 0.01).ToString();
            lblpubname.Text = ds4.Tables[0].Rows[0]["pub"].ToString();
            txtpackname.Text = ds4.Tables[1].Rows[0]["package_name"].ToString();
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

            //  insertiontxt.Text = totalinsertion.ToString();
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
            dytbl = "";

            int editionlen_vif_new = 0;
            int counteditin_vif_new = 0;
            dytbl += "<table width='660px' align='left' cellpadding='5' cellspacing='0' >";
            {
                DataSet dsb = new DataSet();
                dsb.ReadXml(Server.MapPath("XML/udyavani.xml"));
                dytbl += "<tr align=center >";
                dytbl += "<td width='25px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
                dytbl += "<td  class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                dytbl += "<td width='35px'class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
                //dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[26].ToString() + "</td>";
                dytbl += "<td width='35px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[59].ToString() + "</td>";


                dytbl += "<td width='25px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[40].ToString() + "</td>";
                dytbl += "<td width='25px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                // dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>";

                dytbl += "<td width='40px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[60].ToString() + "</td>";
                dytbl += "<td class='display4' >" + dsb.Tables[0].Rows[0].ItemArray[61].ToString() + "</td>";



                dytbl += "</tr>";
            }
            packlength1 = packlength;

            ////////////////////////////////////////////////////////////////////////////////////////////////
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



                ///////////////
                string[] editionname_vif_new = editionname.Split('+');

                if (editionname.IndexOf("+") > 0)
                {

                    //editionname_vif_new = editionname.Split('+');

                     counteditin_vif_new = editionname_vif_new.Length;

                }
                else
                {
                    counteditin_vif_new = 1;
                }

                for (editionlen_vif_new = 0; editionlen_vif_new < counteditin_vif_new; editionlen_vif_new++)
                {

                    if (editionname.IndexOf("+") > 0)
                    {
                        editionname = editionname_vif_new[editionlen_vif_new].Trim();
                    }
                    /////////

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

                

            }



            //////////////////////////////////////////////////
       
            
       
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

                string[] editionname_vif_new = editionname.Split('+');

                if (editionname.IndexOf("+") > 0)
                {

                    //editionname_vif_new = editionname.Split('+');

                     counteditin_vif_new = editionname_vif_new.Length;

                }
                else
                {
                    counteditin_vif_new = 1;
                }

                for (editionlen_vif_new = 0; editionlen_vif_new < counteditin_vif_new; editionlen_vif_new++)
                  {

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {



                    if (editionname.IndexOf("+") > 0)
                    {
                        editionname = editionname_vif_new[editionlen_vif_new].Trim();
                    }

                        //for (editionlen_vif_new = editionlen_vif; editionlen_vif_new < counteditin_vif; editionlen_vif_new++)
                    //{

                            //NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();

                            //ds4 = objedition1.values_bill(ciobookingid, editionname_vif[editionlen_vif_new].Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());

                            //if (editionlen_vif_new == counteditin_vif - 1)
                    //{
                    //    editionlen_vif_new = 0;
                    //}
                    //break;




                    //    }
                    //}
                   


                        NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();

                        ds4 = objedition1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                   
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.invoice objvalues1 = new NewAdbooking.BillingClass.classesoracle.invoice();

                    ds4 = objvalues1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());


                }
                ldduedate.Text = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
                runtxt.Text = ds4.Tables[0].Rows[0].ItemArray[28].ToString();
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



                /////////////////////////////////////////////////////////////////////////////////

                dytbl += "<tr>";
                dytbl += "<td align=left class=display>" + srl.ToString() + "</td>";
                dytbl += "<td width=130px   align=left class=display>" + ds4.Tables[0].Rows[0]["advertiser"].ToString() + "</td>";

                if (ds4.Tables[0].Rows[0]["ad_type"].ToString() == "CLASSIFIED")
                {
                    if (ds4.Tables[0].Rows[0]["AdSubCat"].ToString() != "")
                    {
                        dytbl += "<td width=65px class=display  align=left >" + ds4.Tables[0].Rows[0]["AdSubCat"].ToString() + "</td>";
                    }
                    else
                        dytbl += "<td width=63px  class=display align=center>---</td>";
                }
                else
                {

                    if (ds4.Tables[0].Rows[0]["Cap"].ToString() != "")
                    {
                        dytbl += "<td width=65px class=display  align=left >" + ds4.Tables[0].Rows[0]["Cap"].ToString() + "</td>";
                    }
                    else
                        dytbl += "<td width=63px  class=display align=center>---</td>";

                }
                if (ds4.Tables[0].Rows[0]["RoNo."].ToString() != "")
                {
                    dytbl += "<td width='35px'  class=display align=left >" + ds4.Tables[0].Rows[0]["RoNo."].ToString() + "</td>";

                }
                else
                    dytbl += "<td width='35px' class=display align=center>---</td>";




                //    dytbl += "<td width=65px   align=left >" + ds4.Tables[0].Rows[0]["EditionName"].ToString() + "</td>";
                dytbl += "<td   align=left class=display>" + ds4.Tables[0].Rows[0]["insert_date"].ToString() + "</td>";




                string col = ds4.Tables[0].Rows[0].ItemArray[6].ToString();
                if (col == "BW")
                {
                    col = col.Substring(0, 2);
                }
                else
                {
                    col = col.Substring(0, 3);
                }
                string col1 = col;
                col1 = col1.Substring(0, 1);
                if (col1 == "B")
                {
                    col = "B / W";
                }
                dytbl += "<td width=35px  walign=left class=display>" + col + "</td>";

                if (ds4.Tables[0].Rows[0].ItemArray[29].ToString() != "")
                {
                    dytbl += "<td align=center class=display>" + ds4.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>";
                }
                else
                    dytbl += "<td class=display  align=center>---</td>";

                if (ds4.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                {
                    dytbl += "<td   align=center class=display >" + ds4.Tables[0].Rows[0].ItemArray[5].ToString() + "*" + ds4.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                }
                else if (ds4.Tables[0].Rows[0].ItemArray[13].ToString() != "")
                {
                    dytbl += "<td   align=center class=display >" + ds4.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td class=display  align=center>---</td>";
                }

                // dytbl += "<td width=63px  align=center>" + ds4.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";



                if (packlength == 0)
                    dytbl += "<td id=str" + packlength + " align=center class=display>" + trate + "</td>";
                else
                    dytbl += "<td class=display align=right>---</td>";



                //dytbl += "<td  align=center class=display>---</td>";
                if (ds4.Tables[0].Rows[0]["Extra"].ToString() != "")
                    dytbl += "<td  align=center class=display>" + ds4.Tables[0].Rows[0]["Extra"].ToString() + "%" + "</td>";
                else
                    dytbl += "<td class=display align=right>---</td>";

                if (packlength == 0)
                    dytbl += "<td  align=center class=display>" + tgamt + "</td>";
                else
                    dytbl += "<td class=display align=right>---</td>";

                dytbl += "</tr>";

                srl++;

            }

        }

            dytbl += "</table>";

            dynamictable.Text = dytbl;

            double amountprem = amt4 * (premiumper1 / 100);
            lb_totalamt.Text = amt4.ToString();
            amountprem = amt4 + amountprem - (spcharges + spdes);
            //  txtgr.Text = amountprem.ToString();
            double disper1 = amountprem * (dispr / 100);
            //  txtdiscal.Text = disper1.ToString();

            lblgross.Text = amt5.ToString();
            traddis = amt5 * traddis / 100;
            lbltradedis.Text = traddis.ToString();
            lbladddis.Text = adddis.ToString();
            lblextra.Text = addchr.ToString();
            lblnetamt.Text = bill_amt1.ToString("F2");
            bill_amt1 = bill_amt1 + 0.01;
            double amountinckudingbox1 = Math.Round(bill_amt1);

            lblround.Text = amountinckudingbox1.ToString();

            // amountinckudingbox = amountprem + boxchg1 - disper1;

            //  double amountforvat1 = 0;

            ///////////////////////////////////////////////////////////////////////////////////////////////


            //  netpay.Text = amountinckudingbox1.ToString();


            NumberToEngish obj = new NumberToEngish();
            rupeetxt.Text = obj.changeNumericToWords(lblround.Text.ToString()) + "Only";

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
            /*
                        String countBILS = dssave.Tables[0].Rows[0].ItemArray[0].ToString();
                        if (countBILS == "1")
                        {
                            pagestatus.Text = "ORIGINAL".ToString();
                        }
                        else
                        {
                            pagestatus.Text = "DUPLICATE".ToString();
                        }

                        */




















        }
        if (chkvalue_length == "yes")
        {
            div_p.Attributes.Add("style", "page-break-after:always;");
        }

    }
}




