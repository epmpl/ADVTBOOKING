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

public partial class sea_controlclassified : System.Web.UI.UserControl
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
    public string _agcode;
    public string _fromdate;
    public string _dateto;
    public sea_controlclassified()
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
        ds.ReadXml(Server.MapPath("XML/sambad.xml"));
        // lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();


    }
    public void setcard()
    {

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/bill.xml"));

        //btnprint.Attributes.Add("onclick", "javascript:window.print();");

        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double amt1 = 0;
        double amt2 = 0;
        double comm2 = 0;
        double boxamt2 = 0;
        double bilamt1 = 0;
        double bilamt2 = 0.00;

        DataSet ds4 = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            //NewAdbooking.
            //       NewAdbooking.Classes.billing_save objvalues1 = new NewAdbooking.Classes.billing_save();
            NewAdbooking.BillingClass.Classes.billing_save objbkcenter = new NewAdbooking.BillingClass.Classes.billing_save();
            ds4 = objbkcenter.selectclassified_billed(agcode, fromdate, dateto, bookingid, Client, Session["dateformat"].ToString());
        }
        else
        {


            //  NewAdbooking.classesoracle.billing_save objvalues1 = new NewAdbooking.classesoracle.billing_save();

            NewAdbooking.BillingClass.classesoracle.billing_save objbkcenter = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds4 = objbkcenter.selectclassified(agcode, fromdate, dateto, bookingid, Client, Session["dateformat"].ToString());

        }

        lblpubname.Text = ds4.Tables[0].Rows[0]["Publication"].ToString();
        adcat.Text = ds4.Tables[0].Rows[0]["Ad_type"].ToString();
        txtpackname.Text = ds4.Tables[0].Rows[0]["Edition"].ToString();

        txtinvoice.Text = ds4.Tables[0].Rows[0]["Invoice"].ToString();

        ldduedate.Text = ds4.Tables[0].Rows[0]["PayDate"].ToString();

        agddxt.Text = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();

        agencyaddtxt.Text = ds4.Tables[0].Rows[0]["Agency_address"].ToString();
        lbcityname.Text = ds4.Tables[0].Rows[0]["City_Name"].ToString();



        // scheme.Text = ds4.Tables[0].Rows[0]["schemename"].ToString();

        // rono.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString() + "/" + ds4.Tables[0].Rows[0]["RO_Date"].ToString();
        //// lbhead2.Text = ds4.Tables[0].Rows[0].ItemArray[25].ToString();
        // string phone1 = ds4.Tables[0].Rows[0].ItemArray[26].ToString();

        //if (ds4.Tables[0].Rows[0]["paydate"].ToString() != "")
        //{
        //    Label17.Text = ds4.Tables[0].Rows[0]["paydate"].ToString() + ". (Int. @ 2% will be charged after payable by date)";
        //}
        //else
        //{
        //    Label17.Text = ds4.Tables[0].Rows[0]["paydatesys"].ToString() + ". (Int. @ 2% will be charged after payable by date)";
        //}

        //if (ds4.Tables[0].Rows[0]["subcat"].ToString() != "0")
        //    txtformat.Text = ds4.Tables[0].Rows[0]["subcat"].ToString();
        //else
        //    txtformat.Text = "";

        //txtproduct.Text = ds4.Tables[0].Rows[0].ItemArray[1].ToString() + "/" + ds4.Tables[0].Rows[0]["bookdate"].ToString();
        //lbinsdt.Text = ds.Tables[0].Rows[0].ItemArray[73].ToString() + " " + ds4.Tables[2].Rows[0]["MinDate"].ToString() + " " + ds.Tables[0].Rows[0].ItemArray[74].ToString() + " " + ds4.Tables[1].Rows[0]["MaxDate"].ToString();
        //agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[1].ToString();
        //agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
        //agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[13].ToString();
        //agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
        //pubtxt.Text = ds4.Tables[0].Rows[0].ItemArray[16].ToString();
        //adcat.Text = ds4.Tables[0].Rows[0].ItemArray[17].ToString();
        //lbclientna.Text = ds4.Tables[0].Rows[0].ItemArray[18].ToString();
        //lbclientadd.Text = ds4.Tables[0].Rows[0].ItemArray[19].ToString();
        //citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[20].ToString();
        //txtcomm.Text = ds4.Tables[0].Rows[0].ItemArray[23].ToString();
        string comm1 = ds4.Tables[0].Rows[0].ItemArray[23].ToString();
        if (comm1 != "")
        {

            comm2 = Convert.ToDouble(comm1);
        }
        //txbox.Text = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
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
        runtxt.Text = ds4.Tables[2].Rows[0].ItemArray[0].ToString();


        String dytbl;
        dytbl = "";

        double sp_chg = 0;

        dytbl += "<table width='670px' align='left' cellpadding='5' cellspacing='0' >";
        {

            DataSet dsb = new DataSet();
            dsb.ReadXml(Server.MapPath("XML/seaexpress.xml"));
            dytbl += "<tr align=center >";
            dytbl += "<td width='25px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
            dytbl += "<td  class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
            dytbl += "<td width='35px'class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
            dytbl += "<td width='35px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[59].ToString() + "</td>";
            dytbl += "<td width='25px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[40].ToString() + "</td>";
            dytbl += "<td width='25px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
            dytbl += "<td width='40px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";
            dytbl += "<td width='40px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[63].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[60].ToString() + "</td>";
            dytbl += "<td width='53px'class='display4' >" + dsb.Tables[0].Rows[0].ItemArray[61].ToString() + "</td>";
            dytbl += "</tr>";
        }
        // int insnum_cou = ds4.Tables[0].Rows.Count;
        string trade_disc1 = "";
        double trade_disc11 = 0;

        {
            trade_disc11 = Convert.ToDouble(ds4.Tables[0].Rows[0]["Trade_disc"].ToString());
        }
        if (ds4.Tables[0].Rows[0]["Trade_disc"].ToString() != "")

            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {
                string amt = ds4.Tables[0].Rows[i].ItemArray[10].ToString();
                amt1 = Convert.ToDouble(amt);
                amt2 = amt2 + amt1;
                string bilamt = ds4.Tables[0].Rows[i]["Bill_Amt"].ToString();
                bilamt1 = Convert.ToDouble(bilamt);
                bilamt2 = bilamt2 + bilamt1;

                dytbl += "<tr align=center>";
                //dytbl += "<td width=50px>" + ds4.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>";
                dytbl += "<td class='display'>" + (i + 1) + "</td>";
                //dytbl += "<td width=55px>" + ds4.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>";
                if (ds4.Tables[0].Rows[0]["client"].ToString() == "")
                {
                    dytbl += "<td  class='display'>" + "--" + "</td>";
                }
                else
                {
                    dytbl += "<td class='display'>" + ds4.Tables[0].Rows[0]["client"].ToString() + "</td>";
                }
                if (ds4.Tables[0].Rows[0]["Caption"].ToString() == "")
                {
                    dytbl += "<td  class='display'>" + "--" + "</td>";
                }
                else
                {
                    dytbl += "<td class='display'>" + ds4.Tables[0].Rows[0]["Caption"].ToString() + "</td>";
                }
                dytbl += "<td class='display'>" + ds4.Tables[0].Rows[i]["RO_No"].ToString() + "</td>";
                dytbl += "<td class='display'>" + ds4.Tables[0].Rows[i]["insert_date"].ToString() + "</td>";
                dytbl += "<td class='display'>" + ds4.Tables[0].Rows[i]["Col_Name"].ToString() + "</td>";
                dytbl += "<td class='display'>" + ds4.Tables[0].Rows[i]["Page_No"].ToString() + "</td>";
                dytbl += "<td class='display'>" + ds4.Tables[0].Rows[i]["Height"].ToString() + "*" + ds4.Tables[0].Rows[0]["width"].ToString() + "</td>";
                dytbl += "<td class='display'>" + ds4.Tables[0].Rows[i]["card_rate"].ToString() + "</td>";




                if (ds4.Tables[0].Rows[i]["Disc_rate"].ToString() == "" || ds4.Tables[0].Rows[i]["Gross_Rate"].ToString() == "0")
                {
                    dytbl += "<td class='display'>" + "0" + "</td>";

                }
                else
                {
                    dytbl += "<td class='display'>" + ds4.Tables[0].Rows[i]["Disc_rate"].ToString() + "</td>";
                }
                dytbl += "<td class='display' >" + "--" + "</td>";
                dytbl += "<td class='display'>" + ds4.Tables[0].Rows[i]["Gross_Rate"].ToString() + "</td>";
                dytbl += "</tr>";

                if (ds4.Tables[0].Rows[i]["special_disc_per"].ToString() != "")
                {
                    sp_chg = Convert.ToDouble(ds4.Tables[0].Rows[i]["special_disc_per"].ToString());
                }


            }


        dytbl += "<tr align=center>";
      
        dytbl += "<td class='display' colspan='11' align='right'  ><b>" + "Total:-" + "</b></td>";
        dytbl += "<td class='display'>" + amt2.ToString() + "</td>";
        dytbl += "</tr>";
        dytbl += "</table>";
        dynamictable.Text = dytbl;


      

     

        //lbladddis.Text = "--".ToString();

        lblgross.Text = amt2.ToString();

        lbladddis .Text=( (amt2 * sp_chg) / 100).ToString();

        lblnetamt.Text = bilamt2.ToString();
       // lb_totalamt.Text = amt2.ToString();

        lblround.Text = Math.Round(bilamt2).ToString();

        double disc_amt = ((amt2 * trade_disc11) / 100);

        lbltradedis.Text = Math.Round(disc_amt).ToString();

        // double gm = amt2 - (amt2 * comm2 / 100);

        //double amtincludebox = gm + boxamt2;
        lblextra.Text = boxamt2.ToString();
        //gm = Math.Round(gm);
        //txtgr.Text = gm.ToString();
        NumberToEngish obj = new NumberToEngish();

        rupeetxt.Text = obj.changeNumericToWords(lblround.Text) + "Only";
        // finalamt.Text = amtincludebox.ToString();

        DataSet dfetch = new DataSet();




        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{

        //    NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
        //    dfetch = objsave.fetchstatusfororderwise(bookingid, insnum_cou);



        //}
        //else
        //{

        //}

        //  if (valueofradio == "1")
        //  {
        //   txtinvoice.Text = invoiceno.ToString();
        // }
        //else
        //{

        ////  txtinvoice.Text = dfetch.Tables[0].Rows[0]["BILNO"].ToString();
        //}



        //txtinvoice.Text = ds5.Tables[0].Rows[0].ItemArray[0].ToString();
        //DataSet dssave = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{

        //    NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.BillingClass.Classes.billing_save();
        //    dssave = objsave.updatebillprintstatus(txtinvoice.Text);
        //}
        //else
        //{
        //    NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
        //    dssave = objsave.updatebillprintstatus(txtinvoice.Text);

        //}
        //String countBILS = dssave.Tables[0].Rows[0].ItemArray[0].ToString();
        //if (countBILS == "1")
        //{
        //    pagestatus.Text = "ORIGINAL".ToString();
        //}
        //else
        //{
        //     pagestatus.Text = "DUPLICATE".ToString();
        //}










    }

    public void setcardlast()
    {
    }
}

