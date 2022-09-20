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

public partial class punebillclassi_re : System.Web.UI.UserControl
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
    public  string _auto;
    public  string branch;
    public punebillclassi_re()
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
        _auto = "";
        branch = "";


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
        lbagencyadd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        //lbclientna.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbcreditdate.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbadcat.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        lbformonth.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString();
        lbbranch.Text = ds.Tables[0].Rows[0].ItemArray[46].ToString();
        lbwaluj.Text = ds.Tables[0].Rows[0].ItemArray[47].ToString();
    
       
    }

    public void setcardmonthly()
    {



        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double amt1 = 0;
        double amt2 = 0;
        double comm2 = 0;
        double boxamt2 = 0;
        int agnew;
        double gm = 0;

        string maxdate = "";

        string[] bookingid4ag = bookingid.Split(',');

        string bookingidn = bookingid.Replace(",", ",");
        string maxinsert = "";

        int countlen = bookingid4ag.Length;
        String dytbl;
        dytbl = "";


        dytbl += "<table width='650px'align='left' cellpadding='5' cellspacing='0'>";
        {
            DataSet dsb = new DataSet();
            dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
            dytbl += "<tr align=center >";
            dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[49].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[39].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";

            dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[56].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[40].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[43].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[44].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[48].ToString() + "</td>";
            dytbl += "</tr>";
        }
          for (agnew = 0; agnew < countlen; agnew++)
            {

        DataSet ds4 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();
            ds4 = objvalues1.selectmonthly(agcode, fromdate, dateto, bookingid, Client, Session["dateformat"].ToString(), "0");
          lbadtypetxt.Text = ds4.Tables[0].Rows[0]["adtype"].ToString();
       
        }
        else
        {
            //NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
            //ds4 = objvalues1.selectmonthly(agcode, fromdate, dateto, bookingid, Client, Session["dateformat"].ToString(), "0");

            NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds4 = objvalues1.selectmonthlynew(agcode, fromdate, dateto, bookingid4ag[agnew], Client, Session["dateformat"].ToString(), bookingidn);


            lbadtypetxt.Text = ds4.Tables[0].Rows[0]["adv_type_name"].ToString();
            lbemailtxt.Text = ds4.Tables[0].Rows[0]["EmailID"].ToString();
            lbpunetxt.Text = ds4.Tables[0].Rows[0]["pan"].ToString();
            lbcreditdatetxt.Text = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
            lbwalujadd.Text = ds4.Tables[0].Rows[0]["address"].ToString() + "," + ds4.Tables[0].Rows[0]["street"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["fax"].ToString();
            lbcompanyname.Text = ds4.Tables[0].Rows[0]["companyname"].ToString();
            lbterms.Text = ds4.Tables[0].Rows[0]["companyname"].ToString();
            lbnaam.Text = "AURANGABAD".ToString();


        }


        lbbranch.Text = ds4.Tables[0].Rows[0]["branch"].ToString();

        agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
        agddxt.Text = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
        lbagencyaddtxt.Text = ds4.Tables[0].Rows[0]["Agency_address"].ToString() + ds4.Tables[0].Rows[0]["Add1"].ToString() + "," + ds4.Tables[0].Rows[0]["Street"].ToString() + "," + ds4.Tables[0].Rows[0]["Dist_Code"].ToString();

     
        lbadcattxt.Text = ds4.Tables[0].Rows[0]["AdCat"].ToString();
     
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


     

      
        int insnum_cou = ds4.Tables[0].Rows.Count;
        string insnum_cou1 = ds4.Tables[0].Rows[0].ItemArray[24].ToString();


        int len11 = bookingid4ag[agnew].Length;

        char[] book = bookingid4ag[agnew].ToCharArray();

        int chnew = 0;

        string addbook = "";


        for (chnew = 0; chnew < len11; chnew++)
        {

            if (chnew == 0)
            {
                addbook = addbook + book[chnew];
            }
            else if (chnew % 7 != 0)
            {
                addbook = addbook + book[chnew];
            }
            else
            {
                addbook = addbook + "</br>" + book[chnew];
            }





        }





      
        for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
        {
            string adsub_catnew = ds4.Tables[0].Rows[i]["adsub_cat"].ToString();
            char [] adsub_cat = adsub_catnew.ToCharArray();
            int ch = 0;
            string adsub_cat1 = "";
            int len11N = adsub_catnew.Length;


            for (ch = 0; ch < len11N; ch++)
            {

                if (ch == 0)
                {
                    adsub_cat1 = adsub_cat1 + adsub_cat[ch];
                }
                else if (ch % 6 != 0)
                {
                    adsub_cat1 = adsub_cat1 + adsub_cat[ch];
                }
                else
                {
                    adsub_cat1 = adsub_cat1 + "</br>" + adsub_cat[ch];
                }





            }







            dytbl += "<tr align=center>";
            dytbl += "<td class='dateclasspune' >" + addbook + "</td>";
           // dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["No_Insert"].ToString() + "</td>";

            string DATENEW = ds4.Tables[0].Rows[i]["month"].ToString();
            string[] DATENEW1 = DATENEW.Split('-');
            lbformonthtxt.Text = DATENEW1[1].ToString();

            dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["Edition"].ToString() + "</td>";
            dytbl += "<td  class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["client"].ToString() + "</td>";
            if (ds4.Tables[0].Rows[i]["RO_No"].ToString() != "")
            {
                dytbl += "<td  class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["RO_No"].ToString() + "</td>";
            }
            else
            {
                dytbl += "<td class='middleforbill' >-</td>";
            }

            dytbl += "<td  class='insertiontxtclass' >" + adsub_cat1 + "</td>";


           
            if (ds4.Tables[0].Rows[i]["Uom_Alias"].ToString() != "")
            {
                dytbl += "<td  class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["Size_Book"].ToString() + "</td>";
            }
            else
            {
                dytbl += "<td class='middleforbill' >-</td>";
            }
            if (ds4.Tables[0].Rows[i]["Col_Name"].ToString() != "")
            {
                dytbl += "<td  class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["Col_Name"].ToString() + "</td>";
            }
            else
            {
                dytbl += "<td  class='middleforbill' >-</td>";

            }
          
           dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["Gross_Rate"].ToString() + "</td>";
                if (ds4.Tables[0].Rows[i]["TRADE DISC AMT"].ToString() != "")
                {
                    dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["TRADE DISC AMT"].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td  class='middleforbill' >-</td>";
                }

                if (ds4.Tables[0].Rows[i]["AD AGENCY COMM AMT"].ToString() != "")
                {
                    dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["AD AGENCY COMM AMT"].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td  class='middleforbill' >-</td>";
                }

                dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["netamt"].ToString() + "</td>";



                string amt = ds4.Tables[0].Rows[i]["netamt"].ToString();
                if (amt != "")
                {
                    amt1 = Convert.ToDouble(amt);
                }
               
                amt2 = amt2 + amt1;

              
        }


        txttotal.Text = amt2.ToString();
        if (comm1 != "")
        {

            comm2 = Convert.ToDouble(comm1);
        }

        


        }




        dytbl += "</table>";
        dynamictable.Text = dytbl;


        //  txtgross.Text = amt2.ToString("F2");
         gm = amt2 - (amt2 * comm2 / 100);
      
        double amtincludebox = gm + boxamt2;
      
        
        DataSet ds5 = new DataSet();

       txtinvoice.Text = invoiceno.ToString();
     















    }

}
