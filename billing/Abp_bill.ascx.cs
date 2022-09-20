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

public partial class Abp_bill : System.Web.UI.UserControl
{   
    string Fotter_flag = "";
    string header_flag = "";
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
    public Abp_bill()
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
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //public string changeformat(string userdate)
    //{
    //    string[] arr = userdate.Split('/');
    //    string change = arr[1] + "/" + arr[0] + "/" + arr[2].Substring(0, 4);
    //    return change;
    //}

    public string RETURN_LENGTH(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x = str_decimal+ "%" ;
        else
            x = str_decimal + "%";
        return x;
        
    }
    public string RETURN_LENGTH1(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x = "("+ str_decimal + ")";
        else
            x = "(" + str_decimal + ")";
        return x;

    }



    public string chk_null(string str_decimal)
    {
        string final_decimal = "";
        if (str_decimal == "0.00" || str_decimal == "0.0" || str_decimal == "0")
        {
            final_decimal = "0.00";
        }
        else if (str_decimal.IndexOf(".") > -1)
        {

            double dd = System.Math.Round(Convert.ToDouble(str_decimal), 2);
            string[] oo = dd.ToString().Split('.');
            if (oo.Length == 1)
                final_decimal = dd.ToString() + ".00";
            else if (oo[1].Length == 1)
                final_decimal = dd.ToString() + "0";
            else
                final_decimal = dd.ToString();
        }
        else
        {
            if (str_decimal != "")
            {
                final_decimal = Convert.ToDouble(str_decimal).ToString("F2");
            }
            else
                final_decimal = "0.00";
        }
        return final_decimal;
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
        double pageprem_amt = 0;
        double PagePrem = 0;
        double cardamount = 0;
        double positionpremium = 0;
        double extraposamt = 0;

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



            //adcat.Text = ds4.Tables[0].Rows[0].ItemArray[12].ToString();



            DataSet ds_ABP = new DataSet();
            ds_ABP.ReadXml(Server.MapPath("XML/newbill.xml"));
            //lbcompanynametxt.Text = ds_ABP.Tables[0].Rows[0].ItemArray[1].ToString();


            Fotter_flag = ds_ABP.Tables[0].Rows[0].ItemArray[44].ToString();

            if (Fotter_flag == "yes")
            {
                lbcompanynametxt1.Text = ds_ABP.Tables[0].Rows[0].ItemArray[1].ToString();
                lbwalujadd1.Text = ds_ABP.Tables[0].Rows[0].ItemArray[43].ToString();

                line1.Text = ds_ABP.Tables[0].Rows[0].ItemArray[54].ToString();
            }

            header_flag = ds_ABP.Tables[0].Rows[0].ItemArray[44].ToString();

            if (header_flag == "yes")
            {
                lbcompanynametxt2.Text = ds_ABP.Tables[0].Rows[0].ItemArray[1].ToString();
                lbwalujadd2.Text = ds_ABP.Tables[0].Rows[0].ItemArray[45].ToString();
                line.Text = ds_ABP.Tables[0].Rows[0].ItemArray[54].ToString();


            }

            //lbwalujadd.Text = ds_ABP.Tables[0].Rows[0].ItemArray[42].ToString();


     


            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/billing_magzin.xml"));
            /*MAzine*/
            lblro.Text = "<b>"+ds.Tables[0].Rows[0].ItemArray[0].ToString()+"</b>";
            lblrodate.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[1].ToString() + "</b>";
            lblkey.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[2].ToString() + "</b>";
            //lblpage.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[3].ToString() + "</b>";
            lblagno.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[4].ToString() + "</b>";
            lblcaption.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[5].ToString() + "</b>";
            lbldes.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[6].ToString() + "</b>";
            lblpublication.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[7].ToString() + "</b>";
            lbldate.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[8].ToString() + "</b>";
            lblmeasurement.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[9].ToString() + "</b>";
            lblratetype.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[10].ToString() + "</b>";
            lblrate.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[11].ToString() + "</b>";
            //lbladjustment.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[12].ToString() + "</b>";
            lbltotal.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[13].ToString() + "</b>";
            lblbillno.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[15].ToString() + "</b>";
            lblbilldate.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[16].ToString() + "</b>";
            lbllast.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[17].ToString() + "</b>";
            
            lblnote.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[14].ToString() + "</b>";
            lblname.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[18].ToString() + "</b>";
            lblname1.Text = "<b>" +ds.Tables[0].Rows[0].ItemArray[19].ToString() + "</b>";
            lblclientname.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[20].ToString() + "</b>";
            lblpanno.Text = "<b>" + ds.Tables[0].Rows[0].ItemArray[21].ToString() + "</b>";
            //lblpanno1.Text="<b>" + ds.Tables[0].Rows[0].ItemArray[22].ToString() + "</b>";
               
            lbl1.Text = ds.Tables[1].Rows[0].ItemArray[0].ToString();
            lbl2.Text = ds.Tables[1].Rows[0].ItemArray[1].ToString();
            lbl3.Text = ds.Tables[1].Rows[0].ItemArray[2].ToString();
            lbl4.Text = ds.Tables[1].Rows[0].ItemArray[3].ToString();
         


            if (ds4.Tables[0].Rows[0]["RoNo."].ToString() == "")
            {
                txtro.Text = "--";
            }
            else
            {
                txtro.Text = ds4.Tables[0].Rows[0]["RoNo."].ToString();
            }
            if (ds4.Tables[0].Rows[0]["RO_Date"].ToString() == "")
            {
                txtrodate.Text = "--";
            }
            else
            {
                txtrodate.Text = ds4.Tables[0].Rows[0]["RO_Date"].ToString();
            }
            if (ds4.Tables[0].Rows[0]["key_no"].ToString() == "")
            {
                 txtkey.Text="--";
            }
            else
            {
                txtkey.Text = ds4.Tables[0].Rows[0]["key_no"].ToString();
            }

            /*if (ds4.Tables[0].Rows[0]["page_no"].ToString() == "")
            {
                txtpage.Text = "--";
            }
            else
            {
                txtpage.Text = ds4.Tables[0].Rows[0]["page_no"].ToString();
            }*/

            if (ds4.Tables[0].Rows[0]["CIOID"].ToString() == "")
            {
                txtagno.Text = "--";
            }
            else
            {
                txtagno.Text = ds4.Tables[0].Rows[0]["CIOID"].ToString();
            }
            if (ds4.Tables[0].Rows[0]["Cap"].ToString() == "")
            {
                txtcaption.Text = "--";
            }
            else
            {
                txtcaption.Text = ds4.Tables[0].Rows[0]["Cap"].ToString();
            }

            if (ds4.Tables[0].Rows[0]["ad_type"].ToString() == "")
            {
                txtdes.Text="--";
            }
            else
            {
                txtdes.Text = ds4.Tables[0].Rows[0]["ad_type"].ToString();
            }
            if (ds4.Tables[0].Rows[0]["Pub"].ToString() == "")
            {
                txtpublication.Text = "--";
            }
            else
            {
                txtpublication.Text = ds4.Tables[0].Rows[0]["Pub"].ToString();
            }
            //txtdate.Text="--";
            if (ds4.Tables[0].Rows[0]["uom_name"].ToString() == "")
            {
                txtmeasurement.Text = "--";
            }
            else
            {
                txtmeasurement.Text = ds4.Tables[0].Rows[0]["uom_name"].ToString();
            }
            if (ds4.Tables[0].Rows[0]["rate_code"].ToString() != "")
            {
                txtratetype.Text = ds4.Tables[0].Rows[0]["rate_code"].ToString();
            }
            else
            {
                txtratetype.Text="--";
            }
            if (ds4.Tables[0].Rows[0]["card_rate"].ToString() == "")
            {
                txtrate.Text = "--";
            }
            else
            {
                txtrate.Text = ds4.Tables[0].Rows[0]["card_rate"].ToString();
            }

            agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[1].ToString();
            street = ds4.Tables[0].Rows[0]["street"].ToString();
            agencyaddtxt.Text = ds4.Tables[0].Rows[0]["add1"].ToString();
            agencyaddtxt.Text = agencyaddtxt.Text + "," + street;
            agencyaddtxt1.Text = ds4.Tables[0].Rows[0]["add1"].ToString();
            agencyaddtxt1.Text = agencyaddtxt.Text + "," + street;
            lbcityname.Text = ds4.Tables[0].Rows[0]["city_name"].ToString();
            lbcityname1.Text = ds4.Tables[0].Rows[0]["city_name"].ToString();

            txtpinno.Text = ds4.Tables[0].Rows[0]["pin_code"].ToString();

            if (ds4.Tables[0].Rows[0]["pag_prem"].ToString() != "" && ds4.Tables[0].Rows[0]["pag_prem"].ToString() != null)
            {
                PagePrem = Convert.ToDouble(ds4.Tables[0].Rows[0]["pag_prem"].ToString());
            }
            if (ds4.Tables[0].Rows[0]["Pag_amt"].ToString() != "" && ds4.Tables[0].Rows[0]["Pag_amt"].ToString() != null)
            {
                positionpremium = Convert.ToDouble(ds4.Tables[0].Rows[0]["Pag_amt"].ToString());
            }
            if (ds4.Tables[0].Rows[0]["Amt"].ToString() != "" && ds4.Tables[0].Rows[0]["Amt"].ToString() != null)
            {
                cardamount = Convert.ToDouble(ds4.Tables[0].Rows[0]["Amt"].ToString());
            }
            
            grossamt = Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_Rate"].ToString());
            traddis = Convert.ToDouble(ds4.Tables[0].Rows[0]["trade_disc"].ToString());
           


            if (ds4.Tables[0].Rows[0]["special_discount"].ToString() != "")
            {
                adddis = Convert.ToDouble(ds4.Tables[0].Rows[0]["special_discount"].ToString());
                if (ds4.Tables[0].Rows[0]["special_charges"].ToString() != "")
                    addchr = Convert.ToDouble(ds4.Tables[0].Rows[0]["special_charges"].ToString());
            }
            finalamount = grossamt - traddis - adddis + addchr;

            //if (ds4.Tables[0].Rows[0]["scheme"].ToString() != "" && ds4.Tables[0].Rows[0]["scheme"].ToString() != null)
            //{
            //    txtscode.Text = ds4.Tables[0].Rows[0]["scheme"].ToString();
            //}
            //if (ds4.Tables[0].Rows[0]["rate_code"].ToString() != "")
            //{
            //    txtratecode.Text = ds4.Tables[0].Rows[0]["rate_code"].ToString();
            //}
            //lblround.Text = Math.Round(finalamount + 0.01).ToString();
            //lblpubname.Text = ds4.Tables[0].Rows[0]["pub"].ToString();
            //txtpackname.Text = ds4.Tables[1].Rows[0]["package_name"].ToString();
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
            }

          

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

            int j;
            string packna = "";
            double boxchg1 = 0;
            double boxchg2 = 0;

            //int countpack = ds4.Tables[1].Rows.Count;
            //for (j = 0; j < countpack; j++)
            //{
            //    if (packna == "")
            //    {
            //        packna = ds4.Tables[1].Rows[j].ItemArray[0].ToString();
            //    }
            //    else
            //    {
            //        packna = packna + "," + ds4.Tables[1].Rows[j].ItemArray[0].ToString();
            //    }

            //}


            //int je;
            //string edicode = "";
            //int counteditioncode = ds4.Tables[2].Rows.Count;


            //for (je = 0; je < counteditioncode; je++)
            //{
            //    if (edicode == "")
            //    {
            //        edicode = ds4.Tables[2].Rows[je].ItemArray[0].ToString();
            //    }
            //    else
            //    {
            //        edicode = edicode + "," + ds4.Tables[2].Rows[je].ItemArray[0].ToString();
            //    }

            //}
            //string order = ds4.Tables[0].Rows[0].ItemArray[0].ToString();

            //string bukingdate = bookingdate.ToString();
            //if (bukingdate != "")
            //{

            //    //orderno.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString() + "/" + bukingdate;
            //}
            //else
            //{
            //    //orderno.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString();
            //}
            //string rono1 = orderno1.ToString();
            //string rodate = orderdate.ToString();
            //if (rodate != "" && rono1 != "")
            //{
            //    // rono.Text = rono1 + rodate;
            //}



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
            //dytbl = "";
            //dytbl += "<table width='660px' align='left' cellpadding='0' cellspacing='0' >";
            //{
            //    DataSet dsb = new DataSet();
            //    dsb.ReadXml(Server.MapPath("XML/pratidin.xml"));
            //    dytbl += "<tr align=center >";
            //    string tb1 = "";
            //    tb1 += "<table width='250px' cellpadding='0' cellspacing='0' >";
            //    tb1 += "<tr align=center >";
            //    tb1 += "<td colspan='3'align='center' style='border-bottom:solid 1px black'>" + dsb.Tables[0].Rows[0].ItemArray[2].ToString() + "</td></tr>";
            //    tb1 += "<tr align=center >";
            //    tb1 += "<td  align='center' style='border-right:solid 1px black' width='80px' >" + dsb.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>";
            //    tb1 += "<td  align='center' style='border-right:solid 1px black' width='80px' >" + dsb.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
            //    tb1 += "<td  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[5].ToString() + "</td></tr></table>";


            //    dytbl += "<td width='90px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>";
            //    dytbl += "<td width='70px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>";
            //    dytbl += "<td width='250px' class='insertiontxtclass1' >" + tb1 + "</td>";
            //    dytbl += "<td width='70px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>";
            //    dytbl += "<td width='80px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
            //    dytbl += "<td width='100px' class='insertiontxtclass2' >" + dsb.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";

            //    dytbl += "</tr>";
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
               
                txtdate.Text = ds4.Tables[0].Rows[0].ItemArray[28].ToString();
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

                /* dytbl += "<tr>";


                   if (ds4.Tables[0].Rows[0]["CIOID"].ToString() != "")
                   {
                       dytbl += "<td width=90px class=display  align=center >" + ds4.Tables[0].Rows[0]["CIOID"].ToString() + "</td>";
                   }
                   else
                       dytbl += "<td width=90px  class=display align=center>---</td>";

                   if (ds4.Tables[0].Rows[0].ItemArray[28].ToString() != "")
                   {
                       dytbl += "<td width='70px'  class=display align=center >" + ds4.Tables[0].Rows[0]["date_time"].ToString() + "</td>";

                   }
                   else
                       dytbl += "<td width='70px' class=display align=center>---</td>";

                   string tb1 = "";
                   tb1 += "<table width='250px' cellpadding='0' cellspacing='0' >";
                   tb1 += "<tr align=center >";
                   tb1 += "<td  align='center' class=display3 width='80px' >" + ds4.Tables[0].Rows[0].ItemArray[28].ToString() +"</td>";
                   if (ds4.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                   {
                       tb1 += "<td  align='center' class=display3 width='80px' >" + ds4.Tables[0].Rows[0].ItemArray[5].ToString() + "*" + ds4.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                   }
                   else
                   {
                       tb1 += "<td  align='center' class=display3 width='80px' >---</td>";
                   }
                   tb1 += "<td  align='center'  width='90px'>" + ds4.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>";
                   tb1 += "</tr></table>";

                   dytbl += "<td width='250px'  class=display align=center >" + tb1 + "</td>";

                   if (ds4.Tables[0].Rows[0]["volume"].ToString() != "")
                   {
                       dytbl += "<td width='70px'  class=display align=center >" + ds4.Tables[0].Rows[0]["volume"].ToString() + "</td>";

                   }
                   else
                       dytbl += "<td width='70px' class=display align=center>---</td>";


                   if (ds4.Tables[0].Rows[0]["uom_name"].ToString() != "")
                   {
                       dytbl += "<td width='80px'  class=display align=center >" + ds4.Tables[0].Rows[0]["uom_name"].ToString() + "</td>";

                   }
                   else
                       dytbl += "<td width='80px' class=display align=center>---</td>";

                   if (ds4.Tables[0].Rows[0]["card_rate"].ToString() != "")
                   {
                       dytbl += "<td width='100px'  class=display1 align=center >" + ds4.Tables[0].Rows[0]["card_rate"].ToString() + "</td>";

                   }
                   else
                       dytbl += "<td width='100px' class=display1 align=center>---</td>";



                   dytbl += "</tr>";

                   srl++;

               }

               dytbl += "</table>";

               dynamictable.Text = dytbl;*/

                double amountprem = amt4 * (premiumper1 / 100);
                //lb_totalamt.Text = amt4.ToString();
                amountprem = amt4 + amountprem - (spcharges + spdes);
                double disper1 = amountprem * (dispr / 100);

                //lblgross.Text = amt5.ToString();
                traddis = amt5 * traddis / 100;
                //if (traddis.ToString() == "")
                //{
                //    txtadjustment.Text = "--";
                //}
                //else
                //{
                //    txtadjustment.Text = traddis.ToString();
                //}

                if (bill_amt1.ToString() == "")
                {
                    txttotal.Text = "--";
                }
                else
                {
                    txttotal.Text = (amt5).ToString("F2");
                   // txttotal.Text = (bill_amt1 + traddis).ToString("F2");
                }
                //double net1 = (Convert.ToDouble((bill_amt1 + traddis).ToString("F2"))-((Convert.ToDouble((bill_amt1 + traddis).ToString("F2")) * Convert.ToDouble(ds4.Tables[0].Rows[0]["trade_disc"].ToString())) / 100) + ((Convert.ToDouble((bill_amt1 + traddis).ToString("F2")) * Convert.ToDouble(ds4.Tables[0].Rows[0]["addcom"].ToString())) / 100));
                //txtnetrate.Text = chk_null(net1.ToString());
                txtnetrate.Text = bill_amt1.ToString("F2");
                
                lblbillnotxt.Text = invoiceno;
                lblbilldatetxt.Text = ds4.Tables[0].Rows[0]["Ins.date"].ToString();


                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                    string DATENEW = ds4.Tables[0].Rows[0]["paydate"].ToString();
                    string[] DATENEW1 = DATENEW.Split(' ');
                    lbllasttxt.Text = DATENEW1[1].ToString() + "," + DATENEW1[2].ToString();
                }

                //lbllasttxt.Text = ds4.Tables[0].Rows[0]["paydate"].ToString();
               // txtless.Text = ((Convert.ToDouble((bill_amt1 + traddis).ToString("F2")) * Convert.ToDouble(ds4.Tables[0].Rows[0]["trade_disc"].ToString())) / 100)
                double tot1 = (Convert.ToDouble((amt5).ToString("F2")) * Convert.ToDouble(ds4.Tables[0].Rows[0]["trade_disc"].ToString())) / 100;
                txtless.Text = chk_null(tot1.ToString());
                txtless1.Text = RETURN_LENGTH1(RETURN_LENGTH(ds4.Tables[0].Rows[0]["trade_disc"].ToString()));
                //lblclientnametxt = Client;
                //lblclientnametxt = ds4.Tables[0].Rows[0]["client"].ToString();
                double add2 = (Convert.ToDouble((amt5).ToString("F2")) * Convert.ToDouble(ds4.Tables[0].Rows[0]["addcom"].ToString())) / 100;
                txtadd1.Text = RETURN_LENGTH1(RETURN_LENGTH(ds4.Tables[0].Rows[0]["addcom"].ToString()));
                txtadd.Text =  chk_null(add2.ToString());
                //txtadd.Text = (((bill_amt1 + traddis).ToString("F2")) * (ds4.Tables[0].Rows[0]["addcom"].ToString())) / 100;
                ///////////////////////////////////////////////////////////////////////////////////////////////

                NumberToEngish obj = new NumberToEngish();
                txtnetpayword.Text = obj.changeNumericToWords(txtnetrate.Text.ToString()) + "Only";


            }

        }
    }
}
