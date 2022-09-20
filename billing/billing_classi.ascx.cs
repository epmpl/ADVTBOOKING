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

public partial class billing_classi : System.Web.UI.UserControl
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

     public billing_classi()


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
         _agcode="";
     _fromdate="";
     _dateto="";


       
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
        public string agcode { get { return _agcode; } set { _agcode = value; } }
        public string fromdate { get { return _fromdate; } set { _fromdate = value; } }
        public string dateto { get { return _dateto; } set { _dateto = value; } }

    

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
        lbformatproposal.Text = ds.Tables[0].Rows[0].ItemArray[60].ToString();

        lbpanno.Text = ds.Tables[0].Rows[0].ItemArray[31].ToString();
        lbproductkey.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();       
        lbpub.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        lbheadoffice.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString();
        lbto.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();   
        lbheadoffice.Text = ds.Tables[0].Rows[0].ItemArray[43].ToString();       
        lbgross.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        lbcomm.Text = ds.Tables[0].Rows[0].ItemArray[63].ToString();
        lbbox.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        lbgr.Text = ds.Tables[0].Rows[0].ItemArray[49].ToString();
        lbrupee.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        remark.Text = ds.Tables[0].Rows[0].ItemArray[65].ToString();
         }

         public void setcard()
         {


             btnprint.Attributes.Add("onclick", "javascript:window.print();");

             string day = "";
             string month = "";
             string year = "";
             string date = "";
             double amt1 = 0;
             double amt2 = 0;
             double comm2 = 0;
             double boxamt2 = 0;

             string maxinsert = "";
             DataSet ds4 = new DataSet();

             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
             {

                 //NewAdbooking.
                 //       NewAdbooking.Classes.billing_save objvalues1 = new NewAdbooking.Classes.billing_save();
                 NewAdbooking.BillingClass.Classes.billing_save objbkcenter = new NewAdbooking.BillingClass.Classes.billing_save();
                 ds4 = objbkcenter.selectclassified(agcode, fromdate, dateto, bookingid, Client, Session["dateformat"].ToString());
             }
             else
             {


                 //  NewAdbooking.classesoracle.billing_save objvalues1 = new NewAdbooking.classesoracle.billing_save();

                 NewAdbooking.BillingClass.classesoracle.billing_save objbkcenter = new NewAdbooking.BillingClass.classesoracle.billing_save();
                 ds4 = objbkcenter.selectclassified(agcode, fromdate, dateto, bookingid, Client, Session["dateformat"].ToString());

             }




             lbhead2.Text = ds4.Tables[0].Rows[0].ItemArray[25].ToString();
             string phone1 = ds4.Tables[0].Rows[0].ItemArray[26].ToString();
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {

                 if (ds4.Tables[0].Rows[0]["paydate"].ToString() != "")
                 {
                     Label17.Text = ds4.Tables[0].Rows[0]["paydate"].ToString();
                 }
                 else
                 {
                     Label17.Text = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
                 }
             }
             else
             {
                 Label17.Text = ds4.Tables[0].Rows[0]["paydate"].ToString();
             }


             Label16.Text = ds4.Tables[0].Rows[0]["Email"].ToString();
             //comment by gaurav   
             Label1.Text = phone1 + "-" + ds4.Tables[0].Rows[0].ItemArray[27].ToString();
             Label3.Text = phone1 + "-" + ds4.Tables[0].Rows[0].ItemArray[28].ToString();
             txtformat.Text = ds4.Tables[0].Rows[0].ItemArray[30].ToString();

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
             dytbl += "<table width='630px'align='left' cellpadding='5' cellspacing='0' vlaign='top' >";
             {
                 DataSet dsb = new DataSet();
                 dsb.ReadXml(Server.MapPath("XML/bill.xml"));
                 dytbl += "<tr align=center >";
                 dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
               //  dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[54].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[45].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[56].ToString() + "</td>";
               //  dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[57].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[58].ToString() + "</td>";
                 dytbl += "</tr>";
             }

             int insnum_cou = ds4.Tables[0].Rows.Count;

             for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
             {

                 dytbl += "<tr align=center>";
                 dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>";
              //   dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>";

              //   dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";

                 dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[7].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>";
                 if (ds4.Tables[0].Rows[i].ItemArray[9].ToString() != "")
                 {
                     dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>";
                 }
                 else
                 {
                     dytbl += "<td class='insertiontxtclass' >" + "</td>";
                 }
                 dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[29].ToString() + "</td>";
                 dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>";
                 string amt = ds4.Tables[0].Rows[i].ItemArray[10].ToString();
                 amt1 = Convert.ToDouble(amt);
                 amt2 = amt2 + amt1;


                 dytbl += "</tr>";


             }




             dytbl += "</table>";
             dynamictable.Text = dytbl;

             showtable.Visible = true;


             txtgross.Text = amt2.ToString();
             double gm = amt2 - (amt2 * comm2 / 100);

             double amtincludebox = gm + boxamt2;
             txbox.Text = boxamt2.ToString();
             gm = Math.Round(gm);
             txtgr.Text = gm.ToString();
             NumberToEngish obj = new NumberToEngish();

             finalamt.Text = obj.changeNumericToWords(gm.ToString()) + "Only";
             // finalamt.Text = amtincludebox.ToString();

             DataSet dfetch = new DataSet();




             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {

                 NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                 dfetch = objsave.fetchstatusfororderfirst(bookingid, insnum_cou);



             }
             else
             {

                 NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.BillingClass.Classes.billing_save();
                 dfetch = objsave.fetchstatusfororderfirst(bookingid, insnum_cou);


             }

             if (valueofradio == "first")
             {
                 txtinvoice.Text = invoiceno.ToString();
             }
             else
             {

                 txtinvoice.Text = dfetch.Tables[0].Rows[0]["BILNO"].ToString();
             }

















         }




    public void setcardnew()
    {


        btnprint.Attributes.Add("onclick", "javascript:window.print();");

        int chk = 0;       
        double amt1 = 0;
        double amt2 = 0;
        double amt1_bill = 0;
        double amt2_bill = 0;
        double comm2 = 0;
        double boxamt2 = 0;
        string maxinsert = "";
        string dateformat_insertiondate = "";
        string chk_billtype = "orderwisefirst";
       

        DataSet ds4 = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.billing_save objbkcenter = new NewAdbooking.BillingClass.Classes.billing_save();
            ds4 = objbkcenter.selectclassified(agcode, fromdate, dateto, bookingid, Client, Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.billing_save objbkcenter = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds4 = objbkcenter.selectclassified(agcode, fromdate, dateto, bookingid, Client, Session["dateformat"].ToString());

        }




     

        lbhead2.Text = ds4.Tables[0].Rows[0].ItemArray[25].ToString();
        string phone1 = ds4.Tables[0].Rows[0].ItemArray[26].ToString();

        if (ds4.Tables[0].Rows[0]["paydate"].ToString() != "")
        {
            Label17.Text = ds4.Tables[0].Rows[0]["paydate"].ToString();
        }
        else
        {
            Label17.Text = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
        }
        Label16.Text = ds4.Tables[0].Rows[0]["Email"].ToString();
        //comment by gaurav   
        Label1.Text = phone1 + "-" + ds4.Tables[0].Rows[0].ItemArray[27].ToString();
        Label3.Text = phone1 + "-" + ds4.Tables[0].Rows[0].ItemArray[28].ToString();
        txtformat.Text = ds4.Tables[0].Rows[0].ItemArray[30].ToString();

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

    


        String dytbl;
        dytbl = "";

        dytbl += "<table>";
        int insnum_cou = ds4.Tables[0].Rows.Count;




        for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
        {

            double singleamt = 0;
            //dytbl += "<tr align=center>";
            //dytbl += "<td width=50px>" + ds4.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>";
            //dytbl += "<td width=55px>" + ds4.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>";
            //dytbl += "<td width=55px>" + ds4.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";
            //dytbl += "<td width=40px>" + ds4.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>";
            //dytbl += "<td width=50px>" + ds4.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>";
            //dytbl += "<td width=65px>" + ds4.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>";
            //dytbl += "<td width=40px>" + ds4.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>";
            //dytbl += "<td width=55px>" + ds4.Tables[0].Rows[i].ItemArray[7].ToString() + "</td>";
            //dytbl += "<td width=60px>" + ds4.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>";
            //dytbl += "<td width=40px>" + ds4.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>";
            //dytbl += "<td width=40px>" + ds4.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>";         
            //dytbl += "<td width=40px>" + ds4.Tables[0].Rows[i].ItemArray[29].ToString() + "</td>";
            //dytbl += "<td width=40px>" + ds4.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>";

           
            string amt = ds4.Tables[0].Rows[i].ItemArray[10].ToString();
            amt1 = Convert.ToDouble(amt);
            amt2 = amt2 + amt1;


            string amt_bill = ds4.Tables[0].Rows[i]["Bill_Amt"].ToString();
            amt1_bill = Convert.ToDouble(amt_bill);
            amt2_bill = amt2_bill + amt1_bill;


            branch = ds4.Tables[0].Rows[i]["branch"].ToString();
            string insert_id = ds4.Tables[0].Rows[i]["Insert_Id"].ToString();


             dateformat_insertiondate = ds4.Tables[0].Rows[i]["Insertion_date"].ToString();


            singleamt = amt1 - (amt1 * comm2 / 100);
            singleamt = singleamt + boxamt2;





            dytbl += "</tr>";

            DataSet ds5 = new DataSet();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass.Classes.billing_save();
                ds5 = fetchinvoice.fetchinsertid(insert_id);

            }
            else
            {
                //NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                //ds5 = objsave.fetchstatusfororderfirst(bookingid, insnum_cou);
                NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds5 = fetchinvoice.fetchinsertid(insert_id);
            }


          


                if (chk == 0)
                {
                    autogenerated("0");
                    txtinvoice.Text = _auto.ToString();
                    chk++;
                }
                else
                {
                    txtinvoice.Text = txtinvoice.Text;
                }

                if (ds5.Tables[0].Rows.Count == 0)
                {
                    DataSet dsxml = new DataSet();
                    string result = "";

                DataSet dsnew = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                    NewAdbooking.BillingClass.Classes.session_billing objbkcenter = new NewAdbooking.BillingClass.Classes.session_billing();
                    result = objbkcenter.save_det_monthly(bookingid, txtinvoice.Text, ds4.Tables[0].Rows[i].ItemArray[10].ToString(), singleamt, boxamt2, ds4.Tables[0].Rows[i].ItemArray[21].ToString(), ds4.Tables[0].Rows[i].ItemArray[3].ToString(), dateformat_insertiondate, Session["dateformat"].ToString(), insert_id, chk_billtype);


                    //NewAdbooking.BillingClass.Classes.billing_save objbkcenter = new NewAdbooking.BillingClass.Classes.billing_save();
                  //  dsnew = objbkcenter.save_det(bookingid, txtinvoice.Text, ds4.Tables[0].Rows[i].ItemArray[10].ToString(), singleamt, boxamt2, ds4.Tables[0].Rows[i].ItemArray[21].ToString(), ds4.Tables[0].Rows[i].ItemArray[3].ToString());

                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.billing_save objbkcenter = new NewAdbooking.BillingClass.classesoracle.billing_save();
                  dsnew = objbkcenter.save_det_new1(bookingid, txtinvoice.Text, ds4.Tables[0].Rows[i].ItemArray[10].ToString(), singleamt, boxamt2, ds4.Tables[0].Rows[i].ItemArray[21].ToString(), ds4.Tables[0].Rows[i].ItemArray[3].ToString(), dateformat_insertiondate, Session["dateformat"].ToString(), insert_id);

                }

                maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();


            }




            dytbl += "</table>";
            dynamictable.Text = dytbl;

            txtgross.Text = amt2.ToString();
        
            double gm = amt2_bill;
 
        
           txbox.Text = boxamt2.ToString();
           gm = gm + 0.01;
           //gm = Math.Round(gm);
           gm = Math.Round(gm);
            
            txtgr.Text = gm.ToString();
            NumberToEngish obj11 = new NumberToEngish();

            finalamt.Text = obj11.changeNumericToWords(gm.ToString()) + "Only";

        }
            DataSet dfetch = new DataSet();
            // finalamt.Text = amtincludebox.ToString();
            if (valueofradio == "firstsave")
            {
                ////////////////////////////////////////

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {

                    NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                    dfetch = objsave.fetchstatusfororderfirst(bookingid, insnum_cou);



                }
                else
                {

                    NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.BillingClass.Classes.billing_save();
                    dfetch = objsave.fetchstatusfororderfirst(bookingid, insnum_cou);

                }
                if (dfetch.Tables[0].Rows.Count == 0)
                {                 ////////////////////////////





                    string result = "";
                    DataSet dsxml = new DataSet();
                    dsxml.ReadXml(Server.MapPath("XML/bill.xml"));
                    string doctyp = dsxml.Tables[1].Rows[0].ItemArray[0].ToString();               
                    DataSet dssave = new DataSet();

                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {


                        NewAdbooking.BillingClass.Classes.session_billing objsave = new NewAdbooking.BillingClass.Classes.session_billing();
                        result = objsave.saveinlast(bookingid, txtinvoice.Text, txtgr.Text, txtgross.Text, boxamt2, insnum_cou, doctyp, maxinsert, dateformat_insertiondate, Session["dateformat"].ToString(), chk_billtype);


                       // NewAdbooking.BillingClass.Classes.billing_save objbkcenter = new NewAdbooking.BillingClass.Classes.billing_save();
                      //dssave = objbkcenter.saveinclassified(bookingid, txtinvoice.Text, txtgross.Text, txtgr.Text, boxamt2);
                    }

                    else
                    {


                        chk_billtype = "classifed";

                        NewAdbooking.BillingClass.classesoracle.billing_save objbkcenter = new NewAdbooking.BillingClass.classesoracle.billing_save();
                        dssave = objbkcenter.saveininsertion(bookingid, txtinvoice.Text, txtgr.Text ,txtgross.Text, boxamt2, insnum_cou, doctyp, maxinsert, Session["dateformat"].ToString(), chk_billtype);

                    }

                }




          

            showtable.Visible = false;









        }
    }


    public void autogenerated(string no)
    {
        DataSet dsinvoice = new DataSet();
        /*change ankur*/
        DateTime dt = DateTime.Now;

        string cen = branch;
        cen = cen.Substring(0, 2);

        string year = (dt.Year).ToString();

        int nextyr = Convert.ToInt16(year);
        nextyr = nextyr + 1;

        string nextyr1 = nextyr.ToString();
        nextyr1 = nextyr1.Substring(2, 2);


        year = year.Substring(2, 2);

        string month = (dt.Month).ToString();
        //  year = year.Substring(2, 2);
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.invoice objinvoice = new NewAdbooking.BillingClass.Classes.invoice();

            dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.invoice objinvoice = new NewAdbooking.BillingClass.classesoracle.invoice();

            dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());

        }
        string autono = dsinvoice.Tables[0].Rows[0].ItemArray[0].ToString();
        double autono1 = 0;

        char[] number = autono.ToCharArray();

        if (number.Length < 4)
        {
            if (number.Length == 1)
            {

                autono = "000" + autono;

            }
            else
                if (number.Length == 2)
                {
                    autono = "00" + autono;
                }
                else
                {
                    autono = "0" + autono;
                }


            //autono1 = Convert.ToDouble(autono);
        }


        if (no == "0")
        {

            string zeros = "";
            ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
            ////and if it is 2 than center + yrar + uid + 8 digit no.
            if (Session["invoice_no"].ToString() == "1")
            {


                _auto = cen + "-" + year + "-" + autono;
            }
            else if (Session["invoice_no"].ToString() == "2")
            {
                _auto = cen + "/" + year + "-" + nextyr1 + "/" + (autono);

            }
        }
    }



    public void setcardlast()
    {






        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/bill.xml"));

        lbproductkey.Text = ds.Tables[0].Rows[0].ItemArray[68].ToString();
        lbformatproposal.Text = ds.Tables[0].Rows[0].ItemArray[72].ToString();




        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double amt1 = 0;
        double amt2 = 0;
        double comm2 = 0;
        double boxamt2 = 0;

        string maxdate = "";
        string client = "";
        string clientnew = "";
        string clientchk = "";

        DataSet ds4 = new DataSet();

        string[] bookingid4ag = bookingid.Split(',');
        int countlen = bookingid4ag.Length;
        int agnew;
        String dytbl;
        dytbl = "";
        string maxinsert = "";
        dytbl += "<table width='630px'align='left' cellpadding='5' cellspacing='0'>";
        {
            DataSet dsb = new DataSet();
            dsb.ReadXml(Server.MapPath("XML/bill.xml"));
            dytbl += "<tr align=center >";

            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[70].ToString() + "</td>";

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


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {


                NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();
                ds4 = objvalues1.selectlast(bookingid4ag[agnew], Session["dateformat"].ToString());
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds4 = objvalues1.selectlast(bookingid4ag[agnew], Session["dateformat"].ToString());
            }
            // format.Text = ds4.Tables[0].Rows[0]["ro_no"].ToString();
            // txtproduct.Text = bookingid.ToString();
            txtformat.Text = ds4.Tables[0].Rows[0]["ro_no"].ToString();
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




            runtxt.Text = ds4.Tables[0].Rows[0]["maxdate"].ToString();


            int insnum_cou = ds4.Tables[0].Rows.Count;
            string insnum_cou1 = ds4.Tables[0].Rows[0].ItemArray[24].ToString();








            ////////////////////////////






            //////////////////////////


            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {



                ///////////////////////////



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




                dytbl += "<tr align=center>";

                dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>";

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    dytbl += "<td class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i]["first_catname"].ToString() + "</td>";

                }
                else
                {
                    dytbl += "<td class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i]["AdCat"].ToString() + "</td>";
                }



                dytbl += "<td  class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>";
                if (ds4.Tables[0].Rows[i].ItemArray[4].ToString() != "")
                {
                    dytbl += "<td  class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>";
                }
                else
                    if (ds4.Tables[0].Rows[i].ItemArray[8].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='middleforbill' >-</td>";
                    }
                if (ds4.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                {
                    dytbl += "<td  class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td  class='middleforbill' >-</td>";

                }
                dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>";
                if (ds4.Tables[0].Rows[i].ItemArray[7].ToString() == "BLACK AND WHITE")
                    dytbl += "<td width=39px class='insertiontxtclass'  align=center>B/W</td>";

                else
                    dytbl += "<td width=39px class='insertiontxtclass' align=center >C</td>";

                // dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>";
                if (ds4.Tables[0].Rows[i].ItemArray[9].ToString() != "")
                {
                    dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td class='middleforbill' >-</td>";

                }
                if (ds4.Tables[0].Rows[i].ItemArray[12].ToString() != "")
                {
                    dytbl += "<td class='insertiontxtclass'>" + ds4.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td class='middleforbill' >-</td>";
                }

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    if (ds4.Tables[0].Rows[i]["uomname"].ToString() == "CO0")
                    {
                        dytbl += "<td class='insertiontxtclass' align='left'>" + "Colcm".ToString() + "</td>";
                    }
                    else
                    {

                        dytbl += "<td class='insertiontxtclass'align='left' >" + "Words".ToString() + "</td>";
                    }
                }
                else
                {
                    dytbl += "<td class='insertiontxtclass'>" + ds4.Tables[0].Rows[i]["Uom_Alias"].ToString() + "</td>";
                }
                if (ds4.Tables[0].Rows[i].ItemArray[10].ToString() != "")
                {

                    dytbl += "<td class='insertiontxtclass'>" + ds4.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td class='middleforbill' >-</td>";
                }


                string amt = ds4.Tables[0].Rows[i].ItemArray[10].ToString();
                if (amt == "")
                {
                    amt = "0";
                }
                amt1 = Convert.ToDouble(amt);
                amt2 = amt2 + amt1;


                dytbl += "</tr>";

                maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();



            }
        }



        dytbl += "</table>";
        dynamictable.Text = dytbl;


        txtgross.Text = amt2.ToString("F2");
        double gm = amt2 - (amt2 * comm2 / 100);
        txtgr.Text = gm.ToString("F2");
        double amtincludebox = gm + boxamt2;
        txbox.Text = boxamt2.ToString("F2");
        finalamt.Text = amtincludebox.ToString("F2");
        showtable.Visible = true;
        DataSet ds5 = new DataSet();

        if (valueofradio == "6")
        {


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                agnew = 0;
                NewAdbooking.BillingClass.Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass.Classes.billing_save();
                ds5 = fetchinvoice.fetchlast(bookingid4ag[agnew]);
            }
            else
            {
                agnew = 0;
                NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds5 = fetchinvoice.fetchlast(bookingid4ag[agnew]);

            }


            txtinvoice.Text = ds5.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        else
        {
            txtinvoice.Text = invoiceno.ToString();
        }















    }



    public void setcardlastnew()
    {

        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double amt1 = 0;
        double amt2 = 0;
        double comm2 = 0;
        double boxamt2 = 0;

        string maxdate = "";
        string client = "";
        string clientnew = "";
        string clientchk = "";
        int chk = 0;

        DataSet ds4 = new DataSet();

        string[] bookingid4ag = bookingid.Split(',');
        int countlen = bookingid4ag.Length;
        int agnew;
        String dytbl;
        dytbl = "";
        string maxinsert = "";
        dytbl += "<table width='646px'align='left' cellpadding='5' cellspacing='0'>";
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


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {


                NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();
                ds4 = objvalues1.selectlast(bookingid4ag[agnew], Session["dateformat"].ToString());
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds4 = objvalues1.selectlast(bookingid4ag[agnew], Session["dateformat"].ToString());
            }
            // format.Text = ds4.Tables[0].Rows[0]["ro_no"].ToString();
            // txtproduct.Text = bookingid.ToString();
            agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
            agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[13].ToString();
            agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
            pubtxt.Text = ds4.Tables[0].Rows[0].ItemArray[16].ToString();
            adcat.Text = ds4.Tables[0].Rows[0]["adv_type_name"].ToString();
            lbclientna.Text = ds4.Tables[0].Rows[0].ItemArray[18].ToString();
            lbclientadd.Text = ds4.Tables[0].Rows[0].ItemArray[19].ToString();
            citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[20].ToString();
            txtcomm.Text = ds4.Tables[0].Rows[0].ItemArray[23].ToString();
            branch = ds4.Tables[0].Rows[0]["branch"].ToString();
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






                /////


                dytbl += "<tr align=center>";
                dytbl += "<td class='insertiontxtclass' >" + addbook + "</td>";
                dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>";
                if (ds4.Tables[0].Rows[i].ItemArray[0].ToString() != "")
                {
                    dytbl += "<td  class='insertiontxtclass' >" + rono1 + "</td>";
                }
                else
                {
                    dytbl += "<td class='middleforbill' >-</td>";
                }

                dytbl += "<td  class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>";
                if (ds4.Tables[0].Rows[i].ItemArray[4].ToString() != "")
                {
                    dytbl += "<td  class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>";
                }
                else
                    if (ds4.Tables[0].Rows[i].ItemArray[8].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='middleforbill' >-</td>";
                    }
                if (ds4.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                {
                    dytbl += "<td  class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td  class='middleforbill' >-</td>";

                }
                dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[7].ToString() + "</td>";
                // dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>";
                if (ds4.Tables[0].Rows[i].ItemArray[9].ToString() != "")
                {
                    dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td class='middleforbill' >-</td>";

                }
                if (ds4.Tables[0].Rows[i].ItemArray[12].ToString() != "")
                {
                    dytbl += "<td class='insertiontxtclass'>" + ds4.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td class='middleforbill' >-</td>";
                }

                if (ds4.Tables[0].Rows[i]["Uom_Alias"].ToString() == "CO0")
                {
                    dytbl += "<td class='insertiontxtclass' align='left'>" + "Colcm".ToString() + "</td>";

                }
                else
                {

                    dytbl += "<td class='insertiontxtclass'align='left' >" + "Words".ToString() + "</td>";
                }
                if (ds4.Tables[0].Rows[i].ItemArray[10].ToString() != "")
                {

                    dytbl += "<td class='insertiontxtclass'>" + ds4.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td class='middleforbill' >-</td>";
                }


                string amt = ds4.Tables[0].Rows[i].ItemArray[10].ToString();
                if (amt == "")
                {
                    amt = "0";
                }
                amt1 = Convert.ToDouble(amt);
                amt2 = amt2 + amt1;
                dytbl += "</tr>";
                maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();

                DataSet ds5 = new DataSet();

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.BillingClass.Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass.Classes.billing_save();
                    ds5 = fetchinvoice.fetchlast(bookingid4ag[agnew]);
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();
                    ds5 = fetchinvoice.fetchlast(bookingid4ag[agnew]);

                }

                if (ds5.Tables[0].Rows[0].ItemArray[0].ToString() == "")
                {


                    if (chk == 0)
                    {
                        autogenerated("0");
                        txtinvoice.Text = _auto.ToString();
                        chk++;
                    }
                    else
                    {
                        txtinvoice.Text = txtinvoice.Text;
                    }

                    DataSet dsnew1 = new DataSet();

                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {

                        NewAdbooking.BillingClass.Classes.billing_save obj1 = new NewAdbooking.BillingClass.Classes.billing_save();
                        dsnew1 = obj1.save_det(bookingid4ag[agnew], txtinvoice.Text, ds4.Tables[0].Rows[i].ItemArray[10].ToString(), amt1, boxamt2, ds4.Tables[0].Rows[i].ItemArray[21].ToString(), ds4.Tables[0].Rows[i].ItemArray[3].ToString());


                    }
                    else
                    {
                        NewAdbooking.BillingClass.classesoracle.billing_save obj1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                        dsnew1 = obj1.save_det(bookingid4ag[agnew], txtinvoice.Text, ds4.Tables[0].Rows[i].ItemArray[10].ToString(), amt1, boxamt2, ds4.Tables[0].Rows[i].ItemArray[21].ToString(), ds4.Tables[0].Rows[i].ItemArray[3].ToString());
                    }






                }


            }



            dytbl += "</table>";
            dynamictable.Text = dytbl;


            txtgross.Text = amt2.ToString("F2");
            double gm = amt2 - (amt2 * comm2 / 100);
            txtgr.Text = gm.ToString("F2");
            double amtincludebox = gm + boxamt2;
            txbox.Text = boxamt2.ToString("F2");
            finalamt.Text = amtincludebox.ToString("F2");
            showtable.Visible = true;



            if (valueofradio == "6")
            {

                DataSet ds5 = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                    NewAdbooking.BillingClass.Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass.Classes.billing_save();
                    ds5 = fetchinvoice.fetchlast(bookingid4ag[agnew]);
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();
                    ds5 = fetchinvoice.fetchlast(bookingid4ag[agnew]);

                }

                if (ds5.Tables[0].Rows[0].ItemArray[0].ToString() == "")
                {




                    DataSet dssave = new DataSet();

                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {


                        NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.BillingClass.Classes.billing_save();
                        dssave = objsave.save_last(bookingid4ag[agnew], txtinvoice.Text, txtgross.Text, finalamt.Text, boxamt2, insnum_cou, maxinsert, dateto, maxdate);
                    }

                    else
                    {


                        DataSet dsxml = new DataSet();
                        dsxml.ReadXml(Server.MapPath("XML/bill.xml"));
                        string doctyp = dsxml.Tables[1].Rows[0].ItemArray[0].ToString();
                        NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                        dssave = objsave.saveinclassified(bookingid4ag[agnew], txtinvoice.Text, txtgross.Text, finalamt.Text, boxamt2, insnum_cou, doctyp, maxinsert);

                    }
                }




            }




            showtable.Visible = false;















        }
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

             DataSet ds4 = new DataSet();




             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
             {


                 //NewAdbooking.Classes.billing_save objvalues1 = new NewAdbooking.Classes.billing_save();
                 //ds4 = objvalues1.selectmonthly(agcode, fromdate, dateto, bookingid, Client, Session["dateformat"].ToString());
             }
             else
             {
                 // NewAdbooking.classesoracle.billing_save objvalues1 = new NewAdbooking.classesoracle.billing_save();
                 //ds4 = objvalues1.selectclassified(agcode, fromdate, dateto, bookingid, Client, Session["dateformat"].ToString());

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
             string insnum_cou1 = ds4.Tables[0].Rows[0].ItemArray[24].ToString();


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
                 if (amt == "")
                 {
                     amt = "0";
                 }
                 amt1 = Convert.ToDouble(amt);
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
             showtable.Visible = true;
             DataSet ds5 = new DataSet();

             if (valueofradio == "42")
             {



                 NewAdbooking.BillingClass.Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass.Classes.billing_save();
                 ds5 = fetchinvoice.selectinvoicefmclassi(bookingid, insnum_cou.ToString());

                 txtinvoice.Text = ds5.Tables[0].Rows[0].ItemArray[0].ToString();
             }
             else
             {
                 txtinvoice.Text = invoiceno.ToString();
             }















         }
   
}
