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

public partial class punebillclassi : System.Web.UI.UserControl
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
       public punebillclassi()
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
        // lbclientna.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
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

        string maxdate = "";

        string[] bookingid4ag = bookingid.Split(',');
        int countlen = bookingid4ag.Length;
        int agnew;
        String dytbl;
        dytbl = "";
        string maxinsert = "";
        dytbl += "<table width='666px'align='left' cellpadding='5' cellspacing='0'>";
        {
            DataSet dsb = new DataSet();
            dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
            dytbl += "<tr align=center >";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[49].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[39].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";

            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[56].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[40].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[43].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[44].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[48].ToString() + "</td>";
            dytbl += "</tr>";
        }

        for (agnew = 0; agnew < countlen; agnew++)
        {

            DataSet ds4 = new DataSet();
            
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();
                ds4 = objvalues1.selectmonthly(agcode, fromdate, dateto, bookingid4ag[agnew], Client, Session["dateformat"].ToString(), "0");
                lbadtypetxt.Text = ds4.Tables[0].Rows[0]["adtype"].ToString();
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds4 = objvalues1.selectmonthly(agcode, fromdate, dateto, bookingid4ag[agnew], Client, Session["dateformat"].ToString(), "0");

                lbadtypetxt.Text = ds4.Tables[0].Rows[0]["adv_type_name"].ToString();
                lbemailtxt.Text = ds4.Tables[0].Rows[0]["EmailID"].ToString();
                lbpunetxt.Text = ds4.Tables[0].Rows[0]["pan"].ToString();
                lbcreditdatetxt.Text = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
                lbwalujadd.Text = ds4.Tables[0].Rows[0]["address"].ToString() + "," + ds4.Tables[0].Rows[0]["street"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["fax"].ToString();


            }

            agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
            agddxt.Text = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
            lbagencyaddtxt.Text = ds4.Tables[0].Rows[0]["Agency_address"].ToString();

            // txtcliname.Text = ds4.Tables[0].Rows[0]["client"].ToString();
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


            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {

                dytbl += "<tr align=center>";
                dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["Cio_Booking_Id"].ToString() + "</td>";
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

                dytbl += "<td  class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["adsub_cat"].ToString() + "</td>";

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




                dytbl += "</tr>";

                maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();



            }


        }

        txttotal.Text = amt2.ToString();


        dytbl += "</table>";
        dynamictable.Text = dytbl;


        //  txtgross.Text = amt2.ToString("F2");
        double gm = amt2 - (amt2 * comm2 / 100);
        //txtgr.Text = gm.ToString("F2");
        double amtincludebox = gm + boxamt2;
        //txbox.Text = boxamt2.ToString("F2");
        //finalamt.Text = amtincludebox.ToString("F2");
        showtable.Visible = true;
        DataSet ds5 = new DataSet();


        txtinvoice.Text = invoiceno.ToString();
















    }



    public void setcardmonthlynew()
    {        
        double amt1 = 0;
        double amt2 = 0;
        double comm2 = 0;
        double boxamt2 = 0;
        int chk = 0;    
        string bill_amt = "";
        double abc_bill = 0;
        double abc1_bill = 0;
        string bookingid_new = bookingid;
        string[] bookingid4ag = bookingid.Split(',');
        int countlen = bookingid4ag.Length;       
                string chk_billtype = "monthly";
                string serverip = Request.ServerVariables["REMOTE_ADDR"].ToString();

        string maxinsert = ""; 

            DataSet ds4 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.session_billing objvalues1 = new NewAdbooking.BillingClass.Classes.session_billing();
                ds4 = objvalues1.selectmonthly_genrate(agcode, fromdate, dateto, bookingid_new, Client, Session["dateformat"].ToString(), "0");

          
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds4 = objvalues1.selectmonthly_genrate(agcode, fromdate, dateto, bookingid_new, Client, Session["dateformat"].ToString(), "0");

              

            }
         
            branch = Session["center"].ToString();      


            string comm1 = ds4.Tables[0].Rows[0]["Trade_disc"].ToString();
            if (comm1 != "")
            {

                comm2 = Convert.ToDouble(comm1);
            }
            string boxamt1 = ds4.Tables[0].Rows[0]["boxcode"].ToString();
            if (boxamt1 != "")
            {
                boxamt2 = Convert.ToDouble(boxamt1);
            }





            int insnum_cou = ds4.Tables[0].Rows.Count;
            string insnum_cou1 = ds4.Tables[0].Rows[0]["Invoices"].ToString();


           for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {



                string amt = ds4.Tables[0].Rows[i]["netamt"].ToString();
                if (amt != "")
                {
                    amt1 = Convert.ToDouble(amt);
                }

                amt2 = amt2 + amt1;


                bill_amt = ds4.Tables[0].Rows[i]["Gross_Rate"].ToString();

                if (bill_amt != "")
                {
                    abc_bill = Convert.ToDouble(bill_amt);
                }

                abc1_bill = abc1_bill + abc_bill;

                string insert_id = ds4.Tables[0].Rows[i]["Insert_Id"].ToString();

                bookingid = ds4.Tables[0].Rows[i]["Cio_Booking_Id"].ToString();


                //dytbl += "</tr>";

                maxinsert = "";
                ///

                DataSet ds5 = new DataSet();

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.BillingClass.Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass.Classes.billing_save();
                    ds5 = fetchinvoice.fetchinsertid(insert_id);

                }
                else
                {

                    NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();
                    ds5 = fetchinvoice.fetchinsertid(insert_id);

                   // NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();
                    //ds5 = fetchinvoice.fetchlast_monthly(ds4.Tables[0].Rows[i]["Cio_Booking_Id"].ToString(), ds4.Tables[0].Rows[i]["No_Insert"].ToString(), ds4.Tables[0].Rows[i]["Edition"].ToString());
                }


                if (ds5.Tables[0].Rows.Count == 0)
                {


                    if (chk == 0)
                    {
                      //  autogenerated_PUNE("0");
                        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
                        {
                            autogenerated_pune1("0", fromdate);
                        }
                        else
                        {
                            autogenerated_UDAYVANI("0", fromdate);

                        }
                        txtinvoice.Text = _auto.ToString();
                        chk++;
                    }
                    else
                    {
                        txtinvoice.Text = txtinvoice.Text;
                    }

                    DataSet dsnew = new DataSet();
                    string result = "";
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {




                        NewAdbooking.BillingClass.Classes.session_billing objbkcenter = new NewAdbooking.BillingClass.Classes.session_billing();
                        result = objbkcenter.save_det_monthly(ds4.Tables[0].Rows[i]["Cio_Booking_Id"].ToString(), txtinvoice.Text, ds4.Tables[0].Rows[i]["Gross_Rate"].ToString(), amt1, boxamt2, ds4.Tables[0].Rows[i]["No_Insert"].ToString(), ds4.Tables[0].Rows[i]["Edition"].ToString(), dateto, Session["dateformat"].ToString(), insert_id, chk_billtype);

                    }
                    else
                    {
                    
                        NewAdbooking.BillingClass.classesoracle.billing_save objbkcenter = new NewAdbooking.BillingClass.classesoracle.billing_save();
                        result = objbkcenter.det_monthly_new(ds4.Tables[0].Rows[i]["Cio_Booking_Id"].ToString(), txtinvoice.Text, ds4.Tables[0].Rows[i]["Gross_Rate"].ToString(), amt1, boxamt2, ds4.Tables[0].Rows[i]["No_Insert"].ToString(), ds4.Tables[0].Rows[i]["Edition"].ToString(), dateto, Session["dateformat"].ToString(), insert_id);
                        

                    }

                    DataSet ds_new = new DataSet();
                   
                        if (result == "Fail")
                        {

                            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                            {
                                NewAdbooking.BillingClass.classesoracle.billing_save objsave_del = new NewAdbooking.BillingClass.classesoracle.billing_save();
                                ds_new = objsave_del.delete_bill_det(txtinvoice.Text);
                                break;
                                
                            }

                            else
                            {
                                NewAdbooking.BillingClass.Classes.session_billing objsave_del = new NewAdbooking.BillingClass.Classes.session_billing();
                                ds_new = objsave_del.delete_bill_det(txtinvoice.Text);
                                break;
                             
                            }


                        }
                   
                   


                }



           


        }

        amt2 = Math.Round(amt2);
        txttotal.Text = amt2.ToString();   
        abc1_bill = Math.Round(abc1_bill);
        string grossfinal = abc1_bill.ToString();      


        showtable.Visible = false;










        if (valueofradio == "42")
        {

             DataSet dfetch = new DataSet();
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
             {
                 NewAdbooking.BillingClass.Classes.session_billing objsave = new NewAdbooking.BillingClass.Classes.session_billing();
                 dfetch = objsave.fetchstatusmonthly1(bookingid, dateto, Session["dateformat"].ToString(), Session["compcode"].ToString());
               

             }
             else
             {
                 NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                 dfetch = objsave.fetchstatusmonthly1(bookingid, dateto, Session["dateformat"].ToString(), Session["compcode"].ToString());
             }

             if (dfetch.Tables[0].Rows.Count == 0)
            {


 string err = "";

 try
 {


     DataSet dssave = new DataSet();
     string result = "";
     DataSet dsxml = new DataSet();
     dsxml.ReadXml(Server.MapPath("XML/bill.xml"));
     string doctyp = dsxml.Tables[1].Rows[0].ItemArray[0].ToString();
     if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
     {



         NewAdbooking.BillingClass.Classes.session_billing objsave = new NewAdbooking.BillingClass.Classes.session_billing();
         result = objsave.saveinlast(bookingid, txtinvoice.Text, grossfinal, txttotal.Text, boxamt2, insnum_cou, doctyp, maxinsert, dateto, Session["dateformat"].ToString(), chk_billtype);


     }

     else
     {


         int insnum_cou111 = 0;
         NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
         result = objsave.saveinmonthly(bookingid, txtinvoice.Text, grossfinal, txttotal.Text, boxamt2, insnum_cou111, doctyp, maxinsert, dateto, Session["dateformat"].ToString(), Session["userid"].ToString());


     }




     DataSet ds_new = new DataSet();
     if (result == "Fail")
     {
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.BillingClass.classesoracle.billing_save objsave_del = new NewAdbooking.BillingClass.classesoracle.billing_save();
             ds_new = objsave_del.delete_bill_det(txtinvoice.Text);

         }

         else
         {
             NewAdbooking.BillingClass.Classes.session_billing objsave_del = new NewAdbooking.BillingClass.Classes.session_billing();
             ds_new = objsave_del.delete_bill_det(txtinvoice.Text);


         }



     }

 }

 catch (Exception e)
 {
     err = e.Message;

 }

 string adcatcode2 = " NOT CD Bill " + bookingid;
 clsconnection dconnect = new clsconnection();
 string sqldd = "insert into log_new(DATE1 , USERID    ,PROCESSNAME  , ERR_DESCRIPTION  ,OBJECT_PROCESS_ID,	DESCRIPTION	,IP	)  values($date,'" + Session["userid"].ToString() + "','NOT CD Bill','" + err.Replace("'", "''") + "',' NOT CD Bill','" + adcatcode2;
 sqldd = sqldd + "',";
 sqldd = sqldd + "'" + serverip + "')";
 dconnect.executenonquery1(sqldd);
       


          
            }




        }






        /////////////



        ///////////















    }

    public void autogenerated(string no)
    {
        DataSet dsinvoice = new DataSet();
        /*change ankur*/
        DateTime dt = DateTime.Now;

        string cen = branch;
        cen = cen.Substring(0, 2);
        string year = (dt.Year).ToString();
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
        double autono1 = Convert.ToDouble(autono);

        if (no == "0")
        {

            string zeros = "";
            ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
            ////and if it is 2 than center + yrar + uid + 8 digit no.
            if (Session["invoice_no"].ToString() == "1")
            {
                _auto = cen + year + (autono1);
            }
            else if (Session["invoice_no"].ToString() == "2")
            {
              _auto = cen + year + month + (autono1);

              

            }
        }



    }

   public void autogenerated_PUNE(string no)
    {
        DataSet dsinvoice = new DataSet();
   
        DateTime dt = DateTime.Now;

        string cen = branch;
        cen = cen.Substring(0, 1);

        string year = (dt.Year).ToString();

        int nextyr = Convert.ToInt16(year);
        nextyr = nextyr + 1;

        string nextyr1 = nextyr.ToString();
        nextyr1 = nextyr1.Substring(2, 2);


        year = year.Substring(2, 2);

        string month = (dt.Month).ToString();
      
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


          
        }


        if (no == "0")
        {

            string zeros = "";
            ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
            ////and if it is 2 than center + yrar + uid + 8 digit no.
            if (Session["invoice_no"].ToString() == "1")
            {


                _auto = cen + "/" + year + "-" + nextyr1 + "/" + (autono);
            }
            else if (Session["invoice_no"].ToString() == "2")
            {
                _auto = cen + "/" + year + "-" + nextyr1 + "/" + (autono);

            }
        }

    }


    public void autogenerated_pune1(string no, string fromdate)
    {
        DataSet dsinvoice = new DataSet();
        /*change ankur*/
        DateTime dt = DateTime.Now;
        string cen = branch;
        cen = cen.Substring(0, 1);
        string year = "";
      //  string year = (dt.Year).ToString();
        string mm;
        string[] frmdt;
        if (Session["dateformat"].ToString() == "dd/mm/yyyy")
        {
            frmdt = fromdate.Split('/');
            mm = frmdt[1];
            year = frmdt[2];
        }
        else
            if (Session["dateformat"].ToString() == "mm/dd/yyyy")
            {
                frmdt = fromdate.Split('/');
                mm = frmdt[0];
                year = frmdt[2];
            }
            else
            {
                frmdt = fromdate.Split('/');
                mm = frmdt[2];
                year = frmdt[0];
            }


        int nextyr = Convert.ToInt16(year);
        nextyr = nextyr + 1;

        string nextyr1 = nextyr.ToString();
        nextyr1 = nextyr1.Substring(2, 2);


        year = year.Substring(2, 2);
        string cond_flag = "F";

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

            dsinvoice = objinvoice.invoice_no_pune(Session["compcode"].ToString(), fromdate, Session["dateformat"].ToString(), cond_flag);

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


                _auto = cen + "/" + year + "-" + mm + "/" + (autono);
            }
            else if (Session["invoice_no"].ToString() == "2")
            {
                _auto = cen + "/" + year + "-" + mm + "/" + (autono);

            }
        }

    }

    public void autogenerated_UDAYVANI(string no, string fromdate)
    {
        DataSet dsinvoice = new DataSet();
        /*change ankur*/
        DateTime dt = DateTime.Now;

        // string cen = branch.ToString();
        //  cen = cen.Substring(0, 2);
        string cen = "Ma";
        string year = (dt.Year).ToString();
        year = year.Substring(2, 2);

        string month = (dt.Month).ToString();
        string date1 = dt.Day.ToString();

        string mm;
        string[] frmdt;

        if (Session["dateformat"].ToString() == "dd/mm/yyyy")
        {
            frmdt = fromdate.Split('/');
            mm = frmdt[1];
            year = frmdt[2];
        }
        else
            if (Session["dateformat"].ToString() == "mm/dd/yyyy")
            {
                frmdt = fromdate.Split('/');
                mm = frmdt[0];
                year = frmdt[2];
            }
            else
            {
                frmdt = fromdate.Split('/');
                mm = frmdt[2];
                year = frmdt[0];
            }
        //  year = year.Substring(2, 2);
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //         NewAdbooking.Classes.invoice objinvoice = new NewAdbooking.Classes.invoice();
            NewAdbooking.BillingClass.Classes.invoice objinvoice = new NewAdbooking.BillingClass.Classes.invoice();
            dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());
        }
        else
        {
            //      NewAdbooking.classesoracle.invoice objinvoice = new NewAdbooking.classesoracle.invoice();
            NewAdbooking.BillingClass.classesoracle.invoice objinvoice = new NewAdbooking.BillingClass.classesoracle.invoice();

            dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());
        }
        string autono = dsinvoice.Tables[0].Rows[0].ItemArray[0].ToString();
        double autono1 = 0;
        if (autono != "")
        {
            autono1 = Convert.ToDouble(autono);
        }


        if (no == "0")
        {

            string zeros = "";
            ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
            ////and if it is 2 than center + yrar + uid + 8 digit no.

            _auto = cen + "-" + year + "-" + mm + "-" + (autono1);


        }
    }


}