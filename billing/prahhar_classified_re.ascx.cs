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

public partial class prahhar_classified_re : System.Web.UI.UserControl
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
    public  string _agcode;
    public  string _fromdate;
    public  string _dateto;
    public  string _hiddensession;

    public prahhar_classified_re()
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
        _hiddensession = "";



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
    public string hiddensessionnew { get { return _hiddensession; } set { _hiddensession = value; } }

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

        //    lbweidth.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        //    lbheight.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        //     lbvolume.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        //     lbcolor.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();  




        //  lbformatproposal.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();

        lblwhile.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
        lbpanno.Text = ds.Tables[0].Rows[0].ItemArray[31].ToString();
        //  lbproductkey.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();

        lbpub.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        lbheadoffice.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString();
        lbto.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();



        // lbinsdt.Text = ds.Tables[0].Rows[0].ItemArray[42].ToString();
        //    lbedi.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();
        //   lbinsno.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();

        lbheadoffice.Text = ds.Tables[0].Rows[0].ItemArray[43].ToString();
        lbhead2.Text = ds.Tables[0].Rows[0].ItemArray[44].ToString();
        //   lbpageno.Text = ds.Tables[0].Rows[0].ItemArray[45].ToString();


        // remark.Text = ds.Tables[0].Rows[0].ItemArray[52].ToString();
        //   lblrono.Text = ds.Tables[0].Rows[0].ItemArray[54].ToString();
        //
        //  lbnoofcolumns.Text = ds.Tables[0].Rows[0].ItemArray[55].ToString();
        //   lbra.Text = ds.Tables[0].Rows[0].ItemArray[56].ToString();
        //   lbper.Text = ds.Tables[0].Rows[0].ItemArray[57].ToString();
        //   lbAmount.Text = ds.Tables[0].Rows[0].ItemArray[58].ToString();
        lbgross.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        lbcomm.Text = ds.Tables[0].Rows[0].ItemArray[59].ToString();
        lbbox.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        lbgr.Text = ds.Tables[0].Rows[0].ItemArray[49].ToString();
        txtpan.Text = ds.Tables[0].Rows[0].ItemArray[60].ToString();

    }
    public void setcard()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/bill.xml"));
        lbproductkey.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();
        lbformatproposal.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();

        //btnprint.Attributes.Add("onclick", "javascript:window.print();");

        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double amt1 = 0;
        double amt2 = 0;
        double comm2 = 0;
        double boxamt2 = 0;

        DataSet ds4 = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.BillingClass .Classes.billing_save objvalues1 = new NewAdbooking.BillingClass . Classes.billing_save();
            //ds4 = objvalues1.selectclassified(agcode, fromdate, dateto, bookingid, Client, Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.BillingClass .classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass .classesoracle.billing_save();
            //   ds4 = objvalues1.selectclassified(agcode, fromdate, dateto, bookingid, Client, Session["dateformat"].ToString());

        }

        agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
        agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[13].ToString();
        agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
        pubtxt.Text = ds4.Tables[0].Rows[0].ItemArray[16].ToString();
        adcat.Text = ds4.Tables[0].Rows[0].ItemArray[17].ToString();
        lbclientna.Text = ds4.Tables[0].Rows[0].ItemArray[18].ToString();
        lbclientadd.Text = ds4.Tables[0].Rows[0].ItemArray[19].ToString();
        citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[20].ToString();
        txtcomm.Text = ds4.Tables[0].Rows[0].ItemArray[23].ToString();
        string comm1 = ds4.Tables[0].Rows[0].ItemArray[23].ToString();
        if (comm1 != "")
        {

            comm2 = Convert.ToDouble(comm1);
        }
        txbox.Text = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
        string boxamt1 = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
        if (boxamt1 != "")
        {
            boxamt2 = Convert.ToDouble(boxamt1);
        }

        // txtinvoice.Text = invoiceno.ToString();


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


        String dytbl;
        dytbl = "";

        dytbl += "<table>";
        int insnum_cou = ds4.Tables[0].Rows.Count;

        for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
        {

            dytbl += "<tr align=center>";
            dytbl += "<td width=50px>" + ds4.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>";
            dytbl += "<td width=55px>" + ds4.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>";
            dytbl += "<td width=55px>" + ds4.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";

            dytbl += "<td width=40px>" + ds4.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>";
            dytbl += "<td width=50px>" + ds4.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>";
            dytbl += "<td width=65px>" + ds4.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>";
            dytbl += "<td width=40px>" + ds4.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>";
            dytbl += "<td width=55px>" + ds4.Tables[0].Rows[i].ItemArray[7].ToString() + "</td>";
            dytbl += "<td width=60px>" + ds4.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>";
            dytbl += "<td width=40px>" + ds4.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>";
            dytbl += "<td width=40px>" + ds4.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>";
            dytbl += "<td width=40px>" + "Words".ToString() + "</td>";
            dytbl += "<td width=40px>" + ds4.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>";
            string amt = ds4.Tables[0].Rows[i].ItemArray[10].ToString();
            if (amt != "")
            {
                amt1 = Convert.ToDouble(amt);
            }
            amt2 = amt2 + amt1;


            dytbl += "</tr>";


        }




        dytbl += "</table>";
        dynamictable.Text = dytbl;


        txtgross.Text = amt2.ToString("F2");
        double gm = amt2 - (amt2 * comm2 / 100);
        txtgr.Text = gm.ToString("F2");
        double amtincludebox = gm + boxamt2;
        txbox.Text = boxamt2.ToString("F2");
        finalamt.Text = amtincludebox.ToString("F2");

        DataSet ds5 = new DataSet();

        NewAdbooking.BillingClass .Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass .Classes.billing_save();
        ds5 = fetchinvoice.selectinvoicefmclassi(bookingid, ds4.Tables[0].Rows[0].ItemArray[24].ToString());


        txtinvoice.Text = ds5.Tables[0].Rows[0].ItemArray[0].ToString();
        DataSet dssave = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass .Classes.billing_save objsave = new NewAdbooking.BillingClass .Classes.billing_save();
            dssave = objsave.updatebillprintstatus(txtinvoice.Text);
        }
        String countBILS = dssave.Tables[0].Rows[0].ItemArray[0].ToString();
        if (countBILS == "1")
        {
            pagestatus.Text = "ORIGINAL".ToString();
        }
        else
        {
            pagestatus.Text = "DUPLICATE".ToString();
        }










    }

    public void setcardmonthly()
    {


        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/bill.xml"));
        lbproductkey.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();
        lbformatproposal.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
        hiddensessionnew = "monthlyclientwise";
        if (hiddensessionnew == "monthlyclientwise")
        {





            int fix = 2;

            //btnprint.Attributes.Add("onclick", "javascript:window.print();");

            string day = "";
            string month = "";
            string year = "";
            string date = "";
            double amt1 = 0;
            double amt2 = 0;
            double comm2 = 0;
            double boxamt2 = 0;
            int inew = 0;
            int countclient = 0;

            string[] bookingid4ag = bookingid.Split(',');

            string bookingidn = bookingid.Replace(",", "','");



            int countlen = bookingid4ag.Length;
            int agnew;
            String dytbl;
            dytbl = "";
            string maxinsert = "";
            bool flag = true;
            string client = "";
            string clientnew = "";
            string clientchk = "";
            int inew2 = 0;
            bool flagcheck = false;
            dytbl += "<table width='646px'align='left' cellpadding='5' cellspacing='0'>";
            {
                DataSet dsb = new DataSet();
                dsb.ReadXml(Server.MapPath("XML/bill.xml"));
                dytbl += "<tr align=center >";
                dytbl += "<td class='insertiontxtclass1' width='30px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[68].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='right'  >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[54].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='2px' align='left'>" + dsb.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='right'>" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='right'>" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
                // dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px'align='right'  >" + dsb.Tables[0].Rows[0].ItemArray[45].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='30px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[56].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[57].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='30px'align='right' >" + dsb.Tables[0].Rows[0].ItemArray[58].ToString() + "</td>";
                dytbl += "</tr>";
            }

            for (agnew = 0; agnew < countlen; agnew++)
            {

                DataSet ds4 = new DataSet();

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {


                    NewAdbooking.BillingClass .Classes.billing_save objvalues1 = new NewAdbooking.BillingClass .Classes.billing_save();
                    ds4 = objvalues1.selectclassifiedmonthly(agcode, fromdate, dateto, bookingid4ag[agnew], Client, Session["dateformat"].ToString(), bookingidn);
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                    ds4 = objvalues1.selectmonthlynew(agcode, fromdate, dateto, bookingid4ag[agnew], Client, Session["dateformat"].ToString(), bookingidn);

                }
                //format.Text = ds4.Tables[0].Rows[0]["ro_no"].ToString();
                //txtproduct.Text = bookingid.ToString();


                string tab3 = ds4.Tables[2].Rows[0].ItemArray[0].ToString();
                agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
                agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[13].ToString();
                agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
                pubtxt.Text = ds4.Tables[0].Rows[0].ItemArray[16].ToString();
                adcat.Text = ds4.Tables[0].Rows[0]["adv_type_name"].ToString();
                lbclientna.Text = ds4.Tables[0].Rows[0].ItemArray[18].ToString();
                lbclientadd.Text = ds4.Tables[0].Rows[0].ItemArray[19].ToString();
                citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[20].ToString();
                txtcomm.Text = ds4.Tables[0].Rows[0].ItemArray[23].ToString();
                string comm1 = ds4.Tables[0].Rows[0].ItemArray[23].ToString();
                if (comm1 != "")
                {

                    comm2 = Convert.ToDouble(comm1);
                }
                txbox.Text = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
                string boxamt1 = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
                if (boxamt1 != "")
                {
                    boxamt2 = Convert.ToDouble(boxamt1);
                }

                // txtinvoice.Text = invoiceno.ToString();


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
                runtxt.Text = dateto.ToString();







                int insnum_cou = ds4.Tables[0].Rows.Count;


                string insnum_cou1 = ds4.Tables[0].Rows[0].ItemArray[24].ToString();

                for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
                {

                    //if (inew == 9)
                    //{
                    //    dytbl += "<table width='646px'align='left' cellpadding='5' cellspacing='0' class='break'>";
                    //}
                    //  dytbl += "<tr align=center>";

                    //  dytbl += "<td style='height:50px'></td></tr>";

                    //dytbl += "<tr align=center>";


                    int len11 = bookingid4ag[agnew].Length;

                    char[] book = bookingid4ag[agnew].ToCharArray();
                    int ch = 0;


                    string addbook = "";
                    string rono1 = "";
                    string colo1 = "";

                    for (ch = 0; ch < len11; ch++)
                    {

                        if (ch == 0)
                        {
                            addbook = addbook + book[ch];
                        }
                        else if (ch % 5 != 0)
                        {
                            addbook = addbook + book[ch];
                        }
                        else
                        {
                            addbook = addbook + "</br>" + book[ch];
                        }





                    }

                    ////for rono
                    string rrr = ds4.Tables[0].Rows[i].ItemArray[0].ToString();
                    char[] rono = rrr.ToCharArray();
                    len11 = rono.Length;

                    for (ch = 0; ch < len11; ch++)
                    {

                        if (ch == 0)
                        {
                            rono1 = rono1 + rono[ch];
                        }
                        else if (ch % 15 != 0)
                        {
                            rono1 = rono1 + rono[ch];
                        }
                        else
                        {
                            rono1 = rono1 + "</br>" + rono[ch];
                        }





                    }

                    ////



                    string colorr = ds4.Tables[0].Rows[i].ItemArray[7].ToString();
                    char[] colorrnew = colorr.ToCharArray();
                    len11 = colorrnew.Length;

                    for (ch = 0; ch < len11; ch++)
                    {

                        if (ch == 0)
                        {
                            colo1 = colo1 + colorrnew[ch];
                        }
                        else if (ch % 5 != 0)
                        {
                            colo1 = colo1 + colorrnew[ch];
                        }
                        else
                        {
                            colo1 = colo1 + "</br>" + colorrnew[ch];
                        }





                    }



                    //if (inew == 9)
                    //{
                    //    dytbl += "<table width='646px'align='left' cellpadding='5' cellspacing='0'>";
                    //}


                    //
                    clientchk = ds4.Tables[0].Rows[i]["client"].ToString();

                    if (client == "")
                    {

                        dytbl += "<tr align=center >";
                        if (ds4.Tables[0].Rows[i]["client"].ToString() != "")
                        {
                            dytbl += "<td class='insertiontxtclass'>ClientName:</td><td class='insertiontxtclass' align='left'colspan='12' >" + ds4.Tables[0].Rows[i]["client"].ToString() + "</td></tr>";
                        }
                        else
                        {
                            dytbl += "<td class='insertiontxtclass'>ClientName:</td><td class='middleforbill' align='left' colspan='12' >-</td></tr>";
                        }
                        clientnew = ds4.Tables[0].Rows[i]["client"].ToString();
                        client = clientnew;
                        countclient++;

                    }
                    else
                        if (clientchk != clientnew)
                        {
                            dytbl += "<tr align=center  >";

                            if (clientchk != "")
                            {

                                dytbl += "<td class='insertiontxtclass'>ClientName:</td><td class='insertiontxtclass' align='left' colspan='12' >" + clientchk + "</td></tr>";
                            }
                            else
                            {
                                dytbl += "<td class='insertiontxtclass'>ClientName:</td><td class='middleforbill' align='left' colspan='12' >-</td></tr>";

                            }

                            clientnew = ds4.Tables[0].Rows[i]["client"].ToString();
                            countclient++;

                        }


                    dytbl += "<tr align=center >";

                    dytbl += "<td class='insertiontxtclass' align='left' >" + addbook + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='right' >" + ds4.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>";
                    if (ds4.Tables[0].Rows[i].ItemArray[0].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclass' align='left' >" + rono1 + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='middleforbill' align='left' >-</td>";
                    }

                    dytbl += "<td  class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>";
                    if (ds4.Tables[0].Rows[i].ItemArray[4].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclass' align='right'  >" + ds4.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>";
                    }
                    else
                        if (ds4.Tables[0].Rows[i].ItemArray[8].ToString() != "")
                        {
                            dytbl += "<td  class='insertiontxtclass' align='right' >" + ds4.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>";
                        }
                        else
                        {
                            dytbl += "<td class='middleforbill' >-</td>";
                        }
                    if (ds4.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclass' align='right' >" + ds4.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td  class='middleforbill' align='right' >-</td>";

                    }
                    dytbl += "<td class='insertiontxtclass' align='right' >" + ds4.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='left' >" + colo1 + "</td>";
                    // dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>";
                    if (ds4.Tables[0].Rows[i].ItemArray[9].ToString() != "")
                    {
                        dytbl += "<td class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='middleforbill' align='left' >-</td>";

                    }
                    if (ds4.Tables[0].Rows[i].ItemArray[12].ToString() != "")
                    {

                        double rt = 0;
                        string rtstr = ds4.Tables[0].Rows[i].ItemArray[12].ToString();
                        if (rtstr != "")
                        {
                            rt = Convert.ToDouble(rtstr);
                        }
                        dytbl += "<td class='insertiontxtclass' align='right'>" + rt.ToString("F2") + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='middleforbill' align='right' >-</td>";
                    }

                    //  if (ds4.Tables[1].Rows[i].ItemArray[0].ToString() == "AB0")
                    //  {
                   // dytbl += "<td class='insertiontxtclass'align='left' >" + "Words".ToString() + "</td>";
                    //  }
                    //   else
                    //   {
                    dytbl += "<td class='insertiontxtclass' align='left'>" + "Colcm".ToString() + "</td>";
                    //     }
                    if (ds4.Tables[0].Rows[i].ItemArray[10].ToString() != "")
                    {
                        string amtt = ds4.Tables[0].Rows[i].ItemArray[10].ToString();
                        double qq = 0;
                        if (amtt != "")
                        {
                            qq = Convert.ToDouble(amtt);
                        }

                        dytbl += "<td class='insertiontxtclass' align='right'>" + qq.ToString("F2") + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='middleforbill' align='right' >-</td>";
                    }
                    inew++;


                    inew2++;

                    //if (inew % 13==0)





                    string amt = ds4.Tables[0].Rows[i].ItemArray[10].ToString();
                    if (amt == "")
                    {
                        amt = "0";
                    }
                    amt1 = Convert.ToDouble(amt);
                    amt2 = amt2 + amt1;


                    dytbl += "</tr>";




                    maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();



                    if (flag == true)
                    {
                        if (inew + ((countclient) / 2) >= 10)
                        {




                            dytbl += "<tr align=left>";

                            dytbl += "<td style='height:40px' colspan='13' align=right>contd. pg" + fix + "</td></tr>";
                            countclient = 0;
                            inew = 0;

                            dytbl += "</table >";
                            //dytbl += "</br>";
                            dytbl += "<tr ><td colspan='13' class='amtxtclass' width='646px'>";
                            // dytbl += "</br>";

                            dytbl += "<table   class='break' border=1  width='646px'align='left' cellpadding='5' cellspacing='0' >";

                            ////

                            DataSet dsb = new DataSet();
                            dsb.ReadXml(Server.MapPath("XML/bill.xml"));
                            dytbl += "<tr align=center >";
                            dytbl += "<td class='insertiontxtclass1' width='30px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[68].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='right'  >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[54].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='2px' align='left'>" + dsb.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='right'>" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='right'>" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
                            // dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px'align='right'  >" + dsb.Tables[0].Rows[0].ItemArray[45].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='30px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[56].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[57].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='30px'align='right' >" + dsb.Tables[0].Rows[0].ItemArray[58].ToString() + "</td>";
                            dytbl += "</tr>";
                            //


                            flag = false;

                        }
                    }
                    int tabnew = 0;

                    if (tab3 != "")
                    {
                        tabnew = Convert.ToInt16(tab3);
                    }

                    if (inew + ((countclient) / 2) >= 17)
                    {
                        fix = fix + 1;

                        //dytbl += "<tr align=right>";
                        //dytbl += "<td class='insertiontxtclass1' colspan= '13' class='break' >Continue</br></br></br></td>";


                        //dytbl += "</tr>";
                        dytbl += "<tr align=left>";

                        dytbl += "<td style='height:80px' colspan='13' align=right >contd. pg" + fix + "</td></tr><tr><td height='30px'></td></tr>";
                        dytbl += " </tr ></td></TABLE>";
                        dytbl += "</br></br>";
                        //dytbl += "<br><br><br><br><br><br>";

                        dytbl += "<tr ><td colspan='13' class='amtxtclass' width='646px'  >";


                        dytbl += "<table border=1   class='break'  width='646px'align='left' cellpadding='5' cellspacing='0' >";

                        if (tabnew - inew2 != 0)
                        {
                            countclient = 0;
                            inew = 0;
                            DataSet dsb = new DataSet();
                            dsb.ReadXml(Server.MapPath("XML/bill.xml"));
                            dytbl += "<tr align=center >";
                            dytbl += "<td class='insertiontxtclass1' width='30px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[68].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='right'  >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[54].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='2px' align='left'>" + dsb.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='right'>" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='right'>" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
                            // dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px'align='right'  >" + dsb.Tables[0].Rows[0].ItemArray[45].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='30px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[56].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[57].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='30px'align='right' >" + dsb.Tables[0].Rows[0].ItemArray[58].ToString() + "</td>";
                            dytbl += "</tr>";
                        }





                    }


                    else
                        if (inew2 == tabnew)
                        {

                            if (inew + ((countclient) / 2) >= 17)
                            {
                                fix = fix + 1;
                                dytbl += "<td style='height:10px' colspan='13' align=right >contd. pg" + fix + "</td></tr><tr><td height='30px'></td></tr>";
                                dytbl += "</tr ></td></TABLE>";
                                dytbl += "<tr ><td colspan='13' class='amtxtclass' width='646px'  >";
                                dytbl += "<table border=1   class='break'  width='646px'align='left' cellpadding='5' cellspacing='0' >";

                            }
                            else
                            {
                            }



                            //tabnew = 0;
                            //if (tab3 != "")
                            //{
                            //    tabnew = Convert.ToInt16(tab3);
                            //}
                            //int diff = tabnew - inew2;
                            //if (diff >= 16 && diff < 18)
                            //    flagcheck = true;
                            //if (flag != true && flagcheck == true && tabnew == inew2)
                            //{
                            //    fix = fix + 1;
                            //    dytbl += "<br><br><br><br><br><br>";
                            //    dytbl += "<td style='height:65px' colspan='13' align=right >contd. pg" + fix + "</td></tr><tr><td height='30px'></td></tr>";
                            //    dytbl += "</table>";
                            //    dytbl += "<tr ><td colspan='13' class='amtxtclass' width='646px'  >";

                            //    dytbl += "<table border=1   class='break'  width='646px'align='left' cellpadding='5' cellspacing='0' >";


                            //}
                        }



                }
                //  dytbl += "</table>";
                // dytbl += "</tr ></td>";

            }

            //  dytbl += "</table>";
            dytbl += "</tr ></td>";

            dytbl += "</table>";
            tabledy.InnerHtml = dytbl;
            //dynamictable.Text = dytbl;


            txtgross.Text = amt2.ToString("F2");
            double gm = amt2 - (amt2 * comm2 / 100);
            txtgr.Text = gm.ToString("F2");
            double amtincludebox = gm + boxamt2;
            txbox.Text = boxamt2.ToString("F2");
            finalamt.Text = amtincludebox.ToString("F2");

            DataSet ds5 = new DataSet();

            string[] invoiceno1 = invoiceno.Split(',');

            txtinvoice.Text = invoiceno1[0].ToString();
            DataSet dssave = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.BillingClass.Classes.billing_save();
                dssave = objsave.updatebillprintstatus(txtinvoice.Text);
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                dssave = objsave.updatebillprintstatus(txtinvoice.Text);

            }
            String countBILS = dssave.Tables[0].Rows[0].ItemArray[0].ToString();
            if (countBILS == "1")
            {
                pagestatus.Text = "ORIGINAL".ToString();
            }
            else
            {
                pagestatus.Text = "DUPLICATE".ToString();
            }










        }

            /////monthly
        else
        {





            int fix = 2;

            //btnprint.Attributes.Add("onclick", "javascript:window.print();");

            string day = "";
            string month = "";
            string year = "";
            string date = "";
            double amt1 = 0;
            double amt2 = 0;
            double comm2 = 0;
            double boxamt2 = 0;
            int inew = 0;

            string[] bookingid4ag = bookingid.Split(',');
            int countlen = bookingid4ag.Length;
            int agnew;
            String dytbl;
            dytbl = "";
            string maxinsert = "";
            bool flag = true;
            string client = "";
            string clientnew = "";
            string clientchk = "";
            dytbl += "<table width='646px'align='left' cellpadding='5' cellspacing='0'>";
            {
                DataSet dsb = new DataSet();
                dsb.ReadXml(Server.MapPath("XML/bill.xml"));
                dytbl += "<tr align=center >";
                dytbl += "<td class='insertiontxtclass1' width='30px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[61].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='left'  >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[54].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='2px' align='left'>" + dsb.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='left'>" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='left'>" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
                // dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px'align='left'  >" + dsb.Tables[0].Rows[0].ItemArray[45].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='30px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[56].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[57].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' width='30px'align='left' >" + dsb.Tables[0].Rows[0].ItemArray[58].ToString() + "</td>";
                dytbl += "</tr>";
            }

            for (agnew = 0; agnew < countlen; agnew++)
            {

                DataSet ds4 = new DataSet();

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {


                    NewAdbooking.BillingClass .Classes.billing_save objvalues1 = new NewAdbooking.BillingClass .Classes.billing_save();
                    ds4 = objvalues1.selectclassifiedmonthly(agcode, fromdate, dateto, bookingid4ag[agnew], Client, Session["dateformat"].ToString(), bookingid);
                }
                else
                {
                    // NewAdbooking.classesoracle.billing_save objvalues1 = new NewAdbooking.classesoracle.billing_save();
                    // ds4 = objvalues1.selectclassifiedmonthly(agcode, fromdate, dateto, bookingid, Client, Session["dateformat"].ToString());

                }
                //format.Text = ds4.Tables[0].Rows[0]["ro_no"].ToString();
                //txtproduct.Text = bookingid.ToString();
                agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
                agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[13].ToString();
                agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
                pubtxt.Text = ds4.Tables[0].Rows[0].ItemArray[16].ToString();
                adcat.Text = ds4.Tables[0].Rows[0]["adv_type_name"].ToString();
                lbclientna.Text = ds4.Tables[0].Rows[0].ItemArray[18].ToString();
                lbclientadd.Text = ds4.Tables[0].Rows[0].ItemArray[19].ToString();
                citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[20].ToString();
                txtcomm.Text = ds4.Tables[0].Rows[0].ItemArray[23].ToString();
                string comm1 = ds4.Tables[0].Rows[0].ItemArray[23].ToString();
                if (comm1 != "")
                {

                    comm2 = Convert.ToDouble(comm1);
                }
                txbox.Text = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
                string boxamt1 = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
                if (boxamt1 != "")
                {
                    boxamt2 = Convert.ToDouble(boxamt1);
                }

                // txtinvoice.Text = invoiceno.ToString();


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
                runtxt.Text = dateto.ToString();







                int insnum_cou = ds4.Tables[0].Rows.Count;


                string insnum_cou1 = ds4.Tables[0].Rows[0].ItemArray[24].ToString();

                for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
                {

                    //if (inew == 9)
                    //{
                    //    dytbl += "<table width='646px'align='left' cellpadding='5' cellspacing='0' class='break'>";
                    //}
                    //  dytbl += "<tr align=center>";

                    //  dytbl += "<td style='height:50px'></td></tr>";

                    //dytbl += "<tr align=center>";


                    int len11 = bookingid4ag[agnew].Length;

                    char[] book = bookingid4ag[agnew].ToCharArray();
                    int ch = 0;


                    string addbook = "";
                    string rono1 = "";
                    string colo1 = "";

                    for (ch = 0; ch < len11; ch++)
                    {

                        if (ch == 0)
                        {
                            addbook = addbook + book[ch];
                        }
                        else if (ch % 5 != 0)
                        {
                            addbook = addbook + book[ch];
                        }
                        else
                        {
                            addbook = addbook + "</br>" + book[ch];
                        }





                    }

                    ////for rono
                    string rrr = ds4.Tables[0].Rows[i].ItemArray[0].ToString();
                    char[] rono = rrr.ToCharArray();
                    len11 = rono.Length;

                    for (ch = 0; ch < len11; ch++)
                    {

                        if (ch == 0)
                        {
                            rono1 = rono1 + rono[ch];
                        }
                        else if (ch % 15 != 0)
                        {
                            rono1 = rono1 + rono[ch];
                        }
                        else
                        {
                            rono1 = rono1 + "</br>" + rono[ch];
                        }





                    }

                    ////



                    string colorr = ds4.Tables[0].Rows[i].ItemArray[7].ToString();
                    char[] colorrnew = colorr.ToCharArray();
                    len11 = colorrnew.Length;

                    for (ch = 0; ch < len11; ch++)
                    {

                        if (ch == 0)
                        {
                            colo1 = colo1 + colorrnew[ch];
                        }
                        else if (ch % 5 != 0)
                        {
                            colo1 = colo1 + colorrnew[ch];
                        }
                        else
                        {
                            colo1 = colo1 + "</br>" + colorrnew[ch];
                        }





                    }



                    //if (inew == 9)
                    //{
                    //    dytbl += "<table width='646px'align='left' cellpadding='5' cellspacing='0'>";
                    //}


                    //



                    dytbl += "<tr align=center >";

                    dytbl += "<td class='insertiontxtclass' align='left' >" + addbook + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>";
                    if (ds4.Tables[0].Rows[i].ItemArray[0].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclass' align='left' >" + rono1 + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='middleforbill' align='left' >-</td>";
                    }

                    dytbl += "<td  class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>";
                    if (ds4.Tables[0].Rows[i].ItemArray[4].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclass' align='left'  >" + ds4.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>";
                    }
                    else
                        if (ds4.Tables[0].Rows[i].ItemArray[8].ToString() != "")
                        {
                            dytbl += "<td  class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>";
                        }
                        else
                        {
                            dytbl += "<td class='middleforbill' >-</td>";
                        }
                    if (ds4.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td  class='middleforbill' align='left' >-</td>";

                    }
                    dytbl += "<td class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='left' >" + colo1 + "</td>";
                    // dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>";
                    if (ds4.Tables[0].Rows[i].ItemArray[9].ToString() != "")
                    {
                        dytbl += "<td class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='middleforbill' align='left' >14</td>";

                    }
                    if (ds4.Tables[0].Rows[i].ItemArray[12].ToString() != "")
                    {
                        dytbl += "<td class='insertiontxtclass' align='left'>" + ds4.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='middleforbill' align='left' >-</td>";
                    }

                    // if (ds4.Tables[1].Rows[i].ItemArray [0].ToString() == "AB0")
                    // {
                  //  dytbl += "<td class='insertiontxtclass'align='left' >" + "Words".ToString() + "</td>";
                    // }
                    // else
                    // {
                    dytbl += "<td class='insertiontxtclass' align='left'>" + "Colcm".ToString() + "</td>";
                    //  }
                    if (ds4.Tables[0].Rows[i].ItemArray[10].ToString() != "")
                    {
                        string amtt = ds4.Tables[0].Rows[i].ItemArray[10].ToString();
                        double qq = 0;
                        if (amtt != "")
                        {
                            qq = Convert.ToDouble(amtt);
                        }

                        dytbl += "<td class='insertiontxtclass' align='left'>" + qq.ToString("F2") + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='middleforbill' align='left' >-</td>";
                    }
                    inew++;


                    //if (inew % 13==0)





                    string amt = ds4.Tables[0].Rows[i].ItemArray[10].ToString();
                    if (amt == "")
                    {
                        amt = "0";
                    }
                    amt1 = Convert.ToDouble(amt);
                    amt2 = amt2 + amt1;


                    dytbl += "</tr>";




                    maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();



                    if (flag == true)
                    {
                        if (inew == 11)
                        {



                            //dytbl += "<tr align=right class='break'>";
                            //dytbl += "<td class='insertiontxtclass1' colspan='13' class='break'  >Continue</td>";

                            //dytbl += "</tr>";
                            dytbl += "<tr align=left>";

                            dytbl += "<td style='height:10px' colspan='13' align=right>contd. pg" + fix + "</td></tr>";


                            //dytbl += "<td >";
                            dytbl += "</table >";
                            dytbl += "</br>";
                            dytbl += "<tr ><td colspan='13' class='amtxtclass' width='646px'>";
                            dytbl += "</br>";
                            dytbl += "<table   class='break' border=1  width='646px'align='left' cellpadding='5' cellspacing='0' >";

                            ////

                            DataSet dsb = new DataSet();
                            dsb.ReadXml(Server.MapPath("XML/bill.xml"));
                            dytbl += "<tr align=center >";
                            dytbl += "<td class='insertiontxtclass1' width='30px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[61].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='left'  >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[54].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='2px' align='left'>" + dsb.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='left'>" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='left'>" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
                            // dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px'align='left'  >" + dsb.Tables[0].Rows[0].ItemArray[45].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='30px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[56].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[57].ToString() + "</td>";
                            dytbl += "<td class='insertiontxtclass1' width='30px'align='left' >" + dsb.Tables[0].Rows[0].ItemArray[58].ToString() + "</td>";
                            dytbl += "</tr>";

                            //


                            flag = false;

                        }
                    }

                    if (inew % 30 == 0)
                    {
                        fix = fix + 1;

                        //dytbl += "<tr align=right>";
                        //dytbl += "<td class='insertiontxtclass1' colspan= '13' class='break' >Continue</br></br></br></td>";


                        //dytbl += "</tr>";
                        dytbl += "<tr align=left>";

                        dytbl += "<td style='height:10px' colspan='13' align=right >contd. pg" + fix + "</td></tr><tr><td height='30px'></td></tr>";
                        dytbl += "</TABLE>";
                        // dytbl += "</br></br></br></br></br></br>";
                        //dytbl += "<br><br><br><br><br><br>";
                        dytbl += "<tr ><td colspan='13' class='amtxtclass' width='646px'>";

                        dytbl += "<table border=1   class='break'  width='646px'align='left' cellpadding='5' cellspacing='0' >";
                        DataSet dsb = new DataSet();
                        dsb.ReadXml(Server.MapPath("XML/bill.xml"));
                        dytbl += "<tr align=center >";
                        dytbl += "<td class='insertiontxtclass1' width='30px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[61].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='20px' align='left'  >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[54].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='2px' align='left'>" + dsb.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='20px' align='left'>" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='20px' align='left'>" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
                        // dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='20px'align='left'  >" + dsb.Tables[0].Rows[0].ItemArray[45].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='30px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[56].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='20px' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[57].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='30px'align='left' >" + dsb.Tables[0].Rows[0].ItemArray[58].ToString() + "</td>";
                        dytbl += "</tr>";


                    }

                }
                //  dytbl += "</table>";
                // dytbl += "</tr ></td>";

            }

            //  dytbl += "</table>";
            //dytbl += "</tr ></td>";

            dytbl += "</table>";
            tabledy.InnerHtml = dytbl;
            //dynamictable.Text = dytbl;


            txtgross.Text = amt2.ToString("F2");
            double gm = amt2 - (amt2 * comm2 / 100);
            txtgr.Text = gm.ToString("F2");
            double amtincludebox = gm + boxamt2;
            txbox.Text = boxamt2.ToString("F2");
            finalamt.Text = amtincludebox.ToString("F2");

            DataSet ds5 = new DataSet();


            txtinvoice.Text = invoiceno.ToString();
            DataSet dssave = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass .Classes.billing_save objsave = new NewAdbooking.BillingClass .Classes.billing_save();
                dssave = objsave.updatebillprintstatus(txtinvoice.Text);
            }
            String countBILS = dssave.Tables[0].Rows[0].ItemArray[0].ToString();
            if (countBILS == "1")
            {
                pagestatus.Text = "ORIGINAL".ToString();
            }
            else
            {
                pagestatus.Text = "DUPLICATE".ToString();
            }










        }






    }


    ////////////////////////


    public void setcardlast()
    {





        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/bill.xml"));

        lbproductkey.Text = ds.Tables[0].Rows[0].ItemArray[64].ToString();
        lbformatproposal.Text = ds.Tables[0].Rows[0].ItemArray[65].ToString();


        int fix = 2;

        //btnprint.Attributes.Add("onclick", "javascript:window.print();");

        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double amt1 = 0;
        double amt2 = 0;
        double comm2 = 0;
        double boxamt2 = 0;
        int inew = 0;
        int countclient = 0;

        string[] bookingid4ag = bookingid.Split(',');

        string bookingidn = bookingid.Replace(",", "','");



        int countlen = bookingid4ag.Length;
        int agnew;
        String dytbl;
        dytbl = "";
        string maxinsert = "";
        bool flag = true;
        int inew2 = 0;
        string client = "";
        string clientnew = "";
        string clientchk = "";
        
        bool flagcheck = false;
        dytbl += "<table width='640px'align='left' cellpadding='5' cellspacing='0'>";
        {
            DataSet dsb = new DataSet();
            dsb.ReadXml(Server.MapPath("XML/bill.xml"));
            dytbl += "<tr align=center >";

            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' width='20px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[70].ToString() + "</td>";

            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[69].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[71].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
            // dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[45].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[56].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[57].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[58].ToString() + "</td>";
            dytbl += "</tr>";
        }

        for (agnew = 0; agnew < countlen; agnew++)
        {

            DataSet ds4 = new DataSet();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {


                NewAdbooking.BillingClass .Classes.billing_save objvalues1 = new NewAdbooking.BillingClass .Classes.billing_save();
                ds4 = objvalues1.selectlast(bookingid4ag[agnew], Session["dateformat"].ToString());
                scheme.Text = ds4.Tables[0].Rows[0]["scheme"].ToString();
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds4 = objvalues1.selectlast(bookingid4ag[agnew], Session["dateformat"].ToString());
            }
            //format.Text = ds4.Tables[0].Rows[0]["ro_no"].ToString();
            //txtproduct.Text = bookingid.ToString();


            // string tab3 = ds4.Tables[2].Rows[0].ItemArray[0].ToString();
            
          
            format.Text = ds4.Tables[0].Rows[0]["ro_no"].ToString();
            txtproduct.Text = bookingid4ag[agnew].ToString();
            agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
            agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[13].ToString();
            agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
            pubtxt.Text = ds4.Tables[0].Rows[0].ItemArray[16].ToString();
            adcat.Text = ds4.Tables[0].Rows[0]["adv_type_name"].ToString();
            lbclientna.Text = ds4.Tables[0].Rows[0].ItemArray[18].ToString();
            lbclientadd.Text = ds4.Tables[0].Rows[0].ItemArray[19].ToString();
            citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[20].ToString();
            txtcomm.Text = ds4.Tables[0].Rows[0].ItemArray[23].ToString();
            string comm1 = ds4.Tables[0].Rows[0].ItemArray[23].ToString();
            if (comm1 != "")
            {

                comm2 = Convert.ToDouble(comm1);
            }
            txbox.Text = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
            string boxamt1 = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
            if (boxamt1 != "")
            {
                boxamt2 = Convert.ToDouble(boxamt1);
            }

            // txtinvoice.Text = invoiceno.ToString();

            runtxt.Text = ds4.Tables[0].Rows[0]["maxdate"].ToString();







            int insnum_cou = ds4.Tables[0].Rows.Count;


            string insnum_cou1 = ds4.Tables[0].Rows[0].ItemArray[24].ToString();

            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {




                int len11 = bookingid4ag[agnew].Length;

                char[] book = bookingid4ag[agnew].ToCharArray();
                int ch = 0;


                string addbook = "";
                string rono1 = "";
                string colo1 = "";

                for (ch = 0; ch < len11; ch++)
                {

                    if (ch == 0)
                    {
                        addbook = addbook + book[ch];
                    }
                    else if (ch % 5 != 0)
                    {
                        addbook = addbook + book[ch];
                    }
                    else
                    {
                        addbook = addbook + "</br>" + book[ch];
                    }





                }


                ////



                string colorr = ds4.Tables[0].Rows[i].ItemArray[7].ToString();
                char[] colorrnew = colorr.ToCharArray();
                len11 = colorrnew.Length;

                for (ch = 0; ch < len11; ch++)
                {

                    if (ch == 0)
                    {
                        colo1 = colo1 + colorrnew[ch];
                    }
                    else if (ch % 5 != 0)
                    {
                        colo1 = colo1 + colorrnew[ch];
                    }
                    else
                    {
                        colo1 = colo1 + "</br>" + colorrnew[ch];
                    }





                }
                string rrr = "";


                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                rrr = ds4.Tables[0].Rows[i]["first_catname"].ToString();
                }
                else
                {
                   rrr =   ds4.Tables[0].Rows[i]["AdCat"].ToString();
                }

                char[] rono = rrr.ToCharArray();
                len11 = rono.Length;
                string rrrn = "";

                for (ch = 0; ch < len11; ch++)
                {
                    if (rono[ch] != ' ')
                    {
                        rrrn = rrrn + rono[ch];
                    }
                }

                char[] rono2 = rrrn.ToCharArray();


                for (ch = 0; ch < len11; ch++)
                {

                    if (ch == 0)
                    {
                        rono1 = rono1 + rono[ch];
                    }
                    else if (ch % 9 != 0)
                    {
                        rono1 = rono1 + rono[ch];
                    }
                    else
                    {
                        rono1 = rono1 + "</br>" + rono[ch];
                    }





                }





                dytbl += "<tr align=center >";


                dytbl += "<td class='insertiontxtclass' align='right' width='20px' >" + ds4.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass' align='right'width='20px' >" + ds4.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>";

                dytbl += "<td class='insertiontxtclass' align='left'width='20px' >" + rono1.Trim() + "</td>";

                dytbl += "<td  class='insertiontxtclass' align='left'width='40px' >" + ds4.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>";
                if (ds4.Tables[0].Rows[i].ItemArray[4].ToString() != "")
                {
                    dytbl += "<td  class='insertiontxtclass' align='right' width='10px'  >" + ds4.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>";
                }
                else
                    if (ds4.Tables[0].Rows[i].ItemArray[8].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclass' align='right' width='10px' >" + ds4.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='middleforbill' >-</td>";
                    }
                if (ds4.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                {
                    dytbl += "<td  class='insertiontxtclass' align='right'   width='20px' >" + ds4.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td  class='middleforbill' align='right' >-</td>";

                }
                dytbl += "<td class='insertiontxtclass' align='right' >" + ds4.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>";
                if (ds4.Tables[0].Rows[i].ItemArray[7].ToString() == "BLACK AND WHITE")
                    dytbl += "<td width=39px class='insertiontxtclass'  align=center width='5px'>B/W</td>";

                else
                    dytbl += "<td width=39px class='insertiontxtclass' align=center >C</td>";

                if (ds4.Tables[0].Rows[i].ItemArray[9].ToString() != "")
                {
                    dytbl += "<td class='insertiontxtclass' align='left' width='5px' >" + ds4.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td class='middleforbill' align='left' >-</td>";

                }
                if (ds4.Tables[0].Rows[i].ItemArray[12].ToString() != "")
                {

                    double rt = 0;
                    string rtstr = ds4.Tables[0].Rows[i].ItemArray[12].ToString();
                    if (rtstr != "")
                    {
                        rt = Convert.ToDouble(rtstr);
                    }
                    dytbl += "<td class='insertiontxtclass' align='right' width='20px'>" + rt.ToString("F2") + "</td>";
                }
                else
                {
                    dytbl += "<td class='middleforbill' align='right'width='20px' >-</td>";
                }

                if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                {

                if (ds4.Tables[0].Rows[i]["uomname"].ToString() == "CO0")
                {
                    dytbl += "<td class='insertiontxtclass' align='left' width='20px'>" + "Colcm".ToString() + "</td>";

                }
                else
                    if (ds4.Tables[0].Rows[i]["uomname"].ToString() == "RO2")
                    {
                        dytbl += "<td class='insertiontxtclass' align='left' width='20px'>" + "Sqcm".ToString() + "</td>";
                    }
                    else
                    {

                        dytbl += "<td class='insertiontxtclass'align='left' width='10px' >" + "Words".ToString() + "</td>";
                    }
                }
                else
                {
                    dytbl += "<td class='insertiontxtclass'>" + ds4.Tables[0].Rows[i]["Uom_Alias"].ToString() + "</td>";

                }
                if (ds4.Tables[0].Rows[i].ItemArray[10].ToString() != "")
                {
                    string amtt = ds4.Tables[0].Rows[i].ItemArray[10].ToString();
                    double qq = 0;
                    if (amtt != "")
                    {
                        qq = Convert.ToDouble(amtt);
                    }

                    dytbl += "<td class='insertiontxtclass' align='right' width='20px'>" + qq.ToString("F2") + "</td>";
                }
                else
                {
                    dytbl += "<td class='middleforbill' align='right' >-</td>";
                }
                inew++;


                inew2++;

                //if (inew % 13==0)





                string amt = ds4.Tables[0].Rows[i].ItemArray[10].ToString();
                if (amt == "")
                {
                    amt = "0";
                }
                amt1 = Convert.ToDouble(amt);
                amt2 = amt2 + amt1;


                dytbl += "</tr>";




                maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();



                //if (flag == true)
                //{
                //    if (inew >= 16)
                //    {




                //        dytbl += "<tr align=left>";

                //        dytbl += "<td style='height:70px' colspan='11' align=right>contd. pg" + fix + "</td></tr>";
                //        countclient = 0;
                //        inew = 0;

                //        dytbl += "</table >";

                //        dytbl += "</tr ></td>";
                //        dytbl += "<tr ><td colspan='12' class='amtxtclass' width='640px'>";


                //        dytbl += "<table   class='break' border=1  width='640px'align='left' cellpadding='5' cellspacing='0' >";



                //        if (insnum_cou - inew2 != 0)
                //        {
                //            DataSet dsb = new DataSet();
                //            dsb.ReadXml(Server.MapPath("XML/bill.xml"));
                //            dytbl += "<tr align=center >";

                //            dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
                //            dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                //            dytbl += "<td class='insertiontxtclass1' width='40px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[66].ToString() + "</td>";

                //            dytbl += "<td class='insertiontxtclass1'  width='40px' >" + dsb.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>";
                //            dytbl += "<td class='insertiontxtclass1' width='10px'>" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
                //            dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                //            dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                //            dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
                //            // dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";
                //            dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[45].ToString() + "</td>";
                //            dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[56].ToString() + "</td>";
                //            dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[57].ToString() + "</td>";
                //            dytbl += "<td class='insertiontxtclass1'width='40px' >" + dsb.Tables[0].Rows[0].ItemArray[58].ToString() + "</td>";
                //            dytbl += "</tr>";
                //            //
                //        }


                //        flag = false;

                //    }
                //}




                //if (inew >= 28)
                //{
                //    fix = fix + 1;

                //    //dytbl += "<tr align=right>";
                //    //dytbl += "<td class='insertiontxtclass1' colspan= '13' class='break' >Continue</br></br></br></td>";


                //    //dytbl += "</tr>";
                //    dytbl += "<tr align=left>";

                //    dytbl += "<td style='height:40px' colspan='12' align=right>contd. pg" + fix + "</td></tr>";
                //    dytbl += " </tr ></td></TABLE>";
                //    dytbl += "</br></br>";
                //    //dytbl += "<br><br><br><br><br><br>";

                //    dytbl += "<tr ><td colspan='12' class='amtxtclass' width='640px'  >";


                //    dytbl += "<table border=1   class='break'  width='640px'align='left' cellpadding='5' cellspacing='0' >";

                //    if (insnum_cou - inew2 != 0)
                //    {
                //        countclient = 0;
                //        inew = 0;
                //        DataSet dsb = new DataSet();
                //        dsb.ReadXml(Server.MapPath("XML/bill.xml"));
                //        dytbl += "<tr align=center >";
                //        dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
                //        dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                //        dytbl += "<td class='insertiontxtclass1' width='40px' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[66].ToString() + "</td>";

                //        dytbl += "<td class='insertiontxtclass1'  width='40px' >" + dsb.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>";
                //        dytbl += "<td class='insertiontxtclass1' width='10px'>" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
                //        dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                //        dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                //        dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
                //        // dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";
                //        dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[45].ToString() + "</td>";
                //        dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[56].ToString() + "</td>";
                //        dytbl += "<td class='insertiontxtclass1'width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[57].ToString() + "</td>";
                //        dytbl += "<td class='insertiontxtclass1'width='40px' >" + dsb.Tables[0].Rows[0].ItemArray[58].ToString() + "</td>";
                //        dytbl += "</tr>";
                //    }





                //}


                //else
                //    if (inew2 == insnum_cou)
                //    {

                //        if (inew >= 33)
                //        {
                //            fix = fix + 1;
                //            dytbl += "<td style='height:10px' colspan='12' align=right >contd. pg" + fix + "</td></tr><tr><td height='30px'></td></tr>";
                //            dytbl += "</tr ></td></TABLE>";
                //            dytbl += "<tr ><td colspan='12' class='amtxtclass' width='640px'  >";
                //            dytbl += "<table border=1   class='break'  width='640px'align='left' cellpadding='5' cellspacing='0' >";

                //        }
                //        else
                //        {
                //        }


                //    }



            }

        }


        dytbl += "</tr ></td>";

        dytbl += "</table>";
        tabledy.InnerHtml = dytbl;
        //dynamictable.Text = dytbl;


        txtgross.Text = amt2.ToString("F2");
        double gm = amt2 - (amt2 * comm2 / 100);
        txtgr.Text = gm.ToString("F2");
        double amtincludebox = gm + boxamt2;
        txbox.Text = boxamt2.ToString("F2");
        amtincludebox = Math.Round(amtincludebox);

        finalamt.Text = amtincludebox + ".00".ToString();
        NumberToEngish obj = new NumberToEngish();
        txtrupee.Text = obj.changeNumericToWords(amtincludebox.ToString()) + "Only";





        agnew = 0;
        DataSet ds5 = new DataSet();

        if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
        {

        NewAdbooking.BillingClass .Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass .Classes.billing_save();
        ds5 = fetchinvoice.fetchlast(bookingid4ag[agnew]);
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds5 = fetchinvoice.fetchlast(bookingid4ag[agnew]);

        }


        txtinvoice.Text = ds5.Tables[0].Rows[0].ItemArray[0].ToString();
        DataSet dssave = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.BillingClass.Classes.billing_save();
            dssave = objsave.updatebillprintstatus(txtinvoice.Text);
        }

        else
        {
            NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
            dssave = objsave.updatebillprintstatus(txtinvoice.Text);

        }
        String countBILS = dssave.Tables[0].Rows[0].ItemArray[0].ToString();
        if (countBILS == "1")
        {
            // pagestatus.Text = "ORIGINAL".ToString();
        }
        else
        {
            pagestatus.Text = "DUPLICATE".ToString();
        }










    }



















}
