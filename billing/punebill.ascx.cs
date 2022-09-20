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

public partial class punebill : System.Web.UI.UserControl
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
    public string _qbc;
    public  string _editionnameplus;
    public  string _auto;
    public  string branch;
    public  string _agcode;
    public  string _fromdate;
    public  string _dateto;
    public string _billdater1;
    public string _publicationcenter;
    public string _publicationcentername;
/// <summary>
/// //////////////////////
/// 
/// 
/// </summary>


    public punebill()
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
        _billdater1 = "";
        _publicationcenter = "";
        _publicationcentername = "";
    }
    public string billdater { get { return _billdater1; } set { _billdater1 = value; } }
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
    public string publicationcentername { get { return _publicationcentername; } set { _publicationcentername = value; } }
    public string publicationcenter { get { return _publicationcenter; } set { _publicationcenter = value; } }
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

       // lbcompaddress.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        agencytxt.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbclientadd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbclientna.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbcap.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbddate.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbrodat.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbpackagena.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbpackagerate.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lbinsertionnumber.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        lblamount.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        // lbextpre.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        lbgr.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        // lbtrade1.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        // lbadtd.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        //EOU.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        //lbextpre.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        //lbadtd.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();


    }




    public void setcardlast()
    {

        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double amt1 = 0;
        double amt2 = 0;
        double comm2 = 0;
        double boxamt2 = 0;
        double abc = 0;
        double abc1 = 0;
        double amtinpr = 0;
        double abc2 = 0;

        string maxdate = "";

        DataSet ds4 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();
            ds4 = objvalues1.selectlast(bookingid, Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds4 = objvalues1.selectlastnew(bookingid, Session["dateformat"].ToString(), fromdate, dateto);

          //  ds4 = objvalues1.selectlastnew(bookingid, Session["dateformat"].ToString(), fromdate, dateto);

        }

        lbemailtxt.Text = ds4.Tables[0].Rows[0]["EmailID"].ToString();

        agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
        agddxt.Text = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
       lbaddress.Text = ds4.Tables[0].Rows[0]["Agency_address"].ToString();
       lbpakgrate.Text = ds4.Tables[0].Rows[0]["PACKAGERATE"].ToString();
       insertiontxt.Text = ds4.Tables[0].Rows[0]["No_of_insertion"].ToString();

        txtcliname.Text = ds4.Tables[0].Rows[0]["client"].ToString();
       // lbadcattxt.Text = ds4.Tables[0].Rows[0]["AdCat"].ToString();
        //lbadtypetxt.Text = ds4.Tables[0].Rows[0]["adtype"].ToString();
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



     
        runtxt.Text = ds4.Tables[0].Rows[0]["SYSDATE1"].ToString();


        ldduedate.Text = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
        adcat.Text = ds4.Tables[0].Rows[0]["Adv_Type_Name"].ToString();
        lbronodate.Text = ds4.Tables[0].Rows[0]["RO_No"].ToString() + "-" + ds4.Tables[0].Rows[0]["RO_Date"].ToString();


      
        txtpackname.Text = ds4.Tables[0].Rows[0]["Caption"].ToString();
       
        //lbcompaddress.Text = ds4.Tables[0].Rows[0]["address"].ToString() + "," + ds4.Tables[0].Rows[0]["street"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["fax"].ToString();

        lbcompanyname.Text = ds4.Tables[0].Rows[0]["companyname"].ToString();

        lbpunetxt.Text = ds4.Tables[0].Rows[0]["pan"].ToString();
        //lbnaam.Text = ds4.Tables[0].Rows[0]["pubname"].ToString();
        lbnaam.Text = "AURANGABAD".ToString();
        lbterms.Text = ds4.Tables[0].Rows[0]["companyname"].ToString();
       // lbextrapre.Text = ds4.Tables[0].Rows[0]["premiumch"].ToString();


        string pr = ds4.Tables[0].Rows[0]["expr"].ToString();
        double pr1 = 0;
        if (pr != "")
        {


            pr1 = Convert.ToDouble(pr);
        }



               


        //string pr = ds4.Tables[0].Rows[0]["expr"].ToString();       
        //double pr1 = 0;
        //if (pr != "")
        //{           


        //    pr1 = Convert.ToDouble(pr);
        //     amtinpr = (abc * pr1 / 100);
        //    lbextrapre.Text = amtinpr.ToString("F2");

        //}

        lbextpre.Text = "Ex.Premium" + "(" + pr1 + ")" + "%";
     
        //lbextrapre.Text = pr1.ToString("F2");


      //  double amt = abc + (abc * pr1 / 100);
     


        //   txtdiscal.Text = ds4.Tables[0].Rows[0]["Trade_disc"].ToString();
        string dis = ds4.Tables[0].Rows[0]["td"].ToString();
        double dis1 = 0;
        Double DISCAMT = 0;
        if (dis != "")
        {
            dis1 = Convert.ToDouble(dis);
        }

        //amt = amt - (amt * dis1 / 100);


        ///////////
        //DISCAMT = amt * dis1 / 100;

        //txtdiscal.Text = DISCAMT.ToString("F2");

        //lbtrade1.Text = "TD" + "(" +dis+ ")" + "%";


        // txtdiscal.Text = dis1.ToString("F2");

        string disn = ds4.Tables[0].Rows[0]["adtd"].ToString();
        double disn1 = 0;
        Double DISCADTD = 0;
        if (disn != "")
        {
            disn1 = Convert.ToDouble(disn);
        }
       // DISCADTD = amt * disn1 / 100;
        lbadtd.Text = "Ad Td" + "(" + disn1 + ")" + "%";
       // lbadtdtxt.Text = DISCADTD.ToString("F2");


       // double net = amt - ((amt * disn1 / 100) + (DISCAMT));
       // netpay.Text = net.ToString("F2");

     


        //string packagename = "";
        //int p;
        //for (p = 0; p < ds4.Tables[1].Rows.Count;p++ )

        //{
        //    if (packagename == "")
        //    {
        //        packagename = ds4.Tables[1].Rows[p].ItemArray[0].ToString();
        //    }
        //    else
        //    {
        //        packagename = packagename+ "+" + ds4.Tables[1].Rows[p].ItemArray[0].ToString();
        //    }
        //}

        //txtpackname.Text = packagename.ToString();

           
 
 





        String dytbl;
        dytbl = "";

        dytbl += "<table width='450px'align='left' cellpadding='0' cellspacing='0'>";
        {
            DataSet dsb = new DataSet();
            dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
            dytbl += "<tr align=center >";
            dytbl += "<td class='insertiontxtclass1' align='center' width='150px' >" + dsb.Tables[0].Rows[0].ItemArray[26].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' align='center' width='70px'>" + dsb.Tables[0].Rows[0].ItemArray[27].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' align='center'  width='5px' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
            //dytbl += "<td class='insertiontxtclass1'align='right' >" + dsb.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='32px' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";
            dytbl += "</tr>";
        }
        int insnum_cou = ds4.Tables[0].Rows.Count;
        string insnum_cou1 = ds4.Tables[0].Rows[0].ItemArray[24].ToString();

        string maxinsert = "";
        for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
        {
            dytbl += "<tr align=center>";
            dytbl += "<td class='insertiontxtclass'align='center' width='150px' >" + ds4.Tables[0].Rows[i]["Edition"].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass' align='center 'width='20px' >" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";

            if (ds4.Tables[0].Rows[i]["Height"].ToString() != "")
            {
                dytbl += "<td  align='center' width='15px' >" + ds4.Tables[0].Rows[i]["Height"].ToString() + "*" + ds4.Tables[0].Rows[i]["Width"].ToString() + "</td>";
            }
            else
            {
                dytbl += "<td width=63px  align=center>---</td>";
            }

            //dytbl += "<td  class='insertiontxtclass' align='right' >" + ds4.Tables[0].Rows[i]["Size_Book"].ToString() + "</td>";

            if (ds4.Tables[0].Rows[i]["Color_code"].ToString() != "")
            {
                dytbl += "<td  class='insertiontxtclass' align='center' width='20px' >" + ds4.Tables[0].Rows[i]["Color_code"].ToString() + "</td>";
            }
            else
            {
                dytbl += "<td  class='middleforbill'align='center' >-</td>";

            }
            dytbl += "<td class='insertiontxtclass'align='center' width='20px' >" + ds4.Tables[0].Rows[i]["Page_No"].ToString() + "</td>";
            //dytbl += "<td class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i]["Card_Rate"].ToString() + "</td>";
            string cardrt = ds4.Tables[0].Rows[i]["Card_Rate"].ToString();
            double cdr = 0;
            if (cardrt != "")
            {
                cdr = Convert.ToDouble(cardrt);
            }


            dytbl += "<td class='insertiontxtclass' align='center' width='20px'  >" + cdr.ToString("F2") + "</td>";



            string grossamt = ds4.Tables[0].Rows[i]["Gross_Rate"].ToString();

            if (grossamt != "")
            {
                abc = Convert.ToDouble(grossamt);
            }

            abc1 = abc1 + abc;
            

            


            dytbl += "</tr>";

            maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();



        }

        abc2 = abc1;

        txtgr.Text = abc1.ToString("F2");
   

            amtinpr = ((abc1 * pr1 )/ 100);
           lbextrapre.Text = amtinpr.ToString("F2");
           abc1 = abc1 - amtinpr;
           amount1.Text = abc1.ToString("F2");


           DISCAMT = abc2 * dis1 / 100;

        txtdiscal.Text = DISCAMT.ToString("F2");

        lbtrade1.Text = "TD" + "(" + dis + ")" + "%";
        DISCADTD = abc2 * disn1 / 100;
        lbadtdtxt.Text = DISCADTD.ToString("F2");

        double net = abc2 - ((abc2 * disn1 / 100) + (DISCAMT));
        netpay.Text = net.ToString("F2");

        NumberToEngish obj = new NumberToEngish();
        lbwordinrupees.Text = obj.changeNumericToWords(netpay.Text) + "Only";
    

     



        dytbl += "</table>";
        dynamictable.Text = dytbl;





      

   
        showtable.Visible = true;
        DataSet ds5 = new DataSet();

        if (valueofradio == "2")
        {



            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

               
                NewAdbooking.BillingClass.Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass.Classes.billing_save();
                ds5 = fetchinvoice.fetchlast(bookingid);
            }
            else
            {

                NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();

                ds5 = fetchinvoice.fetchlast(bookingid);
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
        string pcompcode = Session["compcode"].ToString();
         string pcenter=publicationcenter;
         string porderno = bookingid;
         string pinsertion_no="";
         string pbill_cycle="";
         string puserid="";
         string pfrom_date = fromdate;
         string ptill_date = dateto;
         string pbill_date = billdater;
         string pdateformat = Session["dateformat"].ToString();
         string pnoofinsert="";
         string pprefix = publicationcenter;
         string pextra1="";
         string pextra2="";
         string pextra3="";
         string pextra4="";
         string pextra5="";
        // string result = "";

         //DateTime dt = DateTime.Now;
         //string cen = branch;
         //pprefix = publicationcentername.Substring(0, 3);




         DataSet result = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.BillingClass.classesoracle.save_det_orderwiselast objbkcenter = new NewAdbooking.BillingClass.classesoracle.save_det_orderwiselast();
             result = objbkcenter.bill_save_data_orderwiselast(pcompcode, pcenter, porderno, pinsertion_no, pbill_cycle, puserid, pfrom_date, ptill_date, pbill_date, pdateformat, pnoofinsert, pprefix, pextra1, pextra2, pextra3, pextra4, pextra5);
         }
         else
         {
             NewAdbooking.BillingClass.Classes.save_det_orderwiselast objbkcenter = new NewAdbooking.BillingClass.Classes.save_det_orderwiselast();
             result = objbkcenter.bill_save_data_orderwiselast(pcompcode, pcenter, porderno, pinsertion_no, pbill_cycle, puserid, pfrom_date, ptill_date, pbill_date, pdateformat, pnoofinsert, pprefix, pextra1, pextra2, pextra3, pextra4, pextra5);
         }

    }

    public void setcardlastnew1()
    {

        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double amt1 = 0;
        double amt2 = 0;
        double comm2 = 0;
        double boxamt2 = 0;

        double abc = 0;
        double abc1 = 0;
        double abc_bill = 0;
        double abc1_bill = 0;

        double amtinpr = 0;
        double abc2 = 0;
        string  bill_amt = "";
    
        string maxdate = "";
        int chk = 0;
        string serverip = Request.ServerVariables["REMOTE_ADDR"].ToString();
        DataSet ds4 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();
            ds4 = objvalues1.selectlast(bookingid, Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();          
            ds4 = objvalues1.selectlastnew(bookingid, Session["dateformat"].ToString(), fromdate, dateto);


        }

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




     


        string grossamt = ds4.Tables[0].Rows[0]["amtnew"].ToString();
        
        if (grossamt != "")
        {
            abc = Convert.ToDouble(grossamt);
        }
        amount1.Text = abc.ToString("F2");


    
        string pr = ds4.Tables[0].Rows[0]["expr"].ToString();
        double pr1 = 0;
        if (pr != "")
        {


            pr1 = Convert.ToDouble(pr);
        }







        lbextpre.Text = "Ex.Premium" + "(" + pr1 + ")" + "%";

              string dis = ds4.Tables[0].Rows[0]["td"].ToString();
        double dis1 = 0;
        Double DISCAMT = 0;
        if (dis != "")
        {
            dis1 = Convert.ToDouble(dis);
        }

     
        string disn = ds4.Tables[0].Rows[0]["adtd"].ToString();
        double disn1 = 0;
        Double DISCADTD = 0;
        if (disn != "")
        {
            disn1 = Convert.ToDouble(disn);
        }
    
        lbadtd.Text = "Ad Td" + "(" + disn1 + ")" + "%";
  
        NumberToEngish obj = new NumberToEngish();
        lbwordinrupees.Text = obj.changeNumericToWords(netpay.Text) + "Only";
       
        branch = Session["center"].ToString();





        String dytbl;
        dytbl = "";

 
        int insnum_cou = ds4.Tables[0].Rows.Count;
        string insnum_cou1 = ds4.Tables[0].Rows[0].ItemArray[24].ToString();

        string maxinsert = "";
        for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
        {

              string cardrt = ds4.Tables[0].Rows[i]["Card_Rate"].ToString();
            double cdr = 0;
            if (cardrt != "")
            {
                cdr = Convert.ToDouble(cardrt);
            }


            dytbl += "<td class='insertiontxtclass' align='center' width='20px'  >" + cdr.ToString("F2") + "</td>";





             grossamt = ds4.Tables[0].Rows[i]["Gross_Rate"].ToString();

            if (grossamt != "")
            {
                abc = Convert.ToDouble(grossamt);
            }

            abc1 = abc1 + abc;


            bill_amt = ds4.Tables[0].Rows[i]["Bill_Amt"].ToString();
            Session["BILLAMT"] = ds4.Tables[0].Rows[i]["Bill_Amt"].ToString();
            if (bill_amt != "")
            {
                abc_bill = Convert.ToDouble(bill_amt);
            }

            abc1_bill = abc1_bill + abc_bill;
           
            


          


            dytbl += "</tr>";

            Double singleamt = 0;

            
            maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();
            string insert_id = ds4.Tables[0].Rows[i]["Insert_Id"].ToString();


            DataSet ds5 = new DataSet();

        


            if (chk==0)
            {
                autogenerated_pune("0", fromdate);
           // autogenerated("0");
            txtinvoice.Text = _auto.ToString();
            chk++;
            }
            else
            {
                txtinvoice.Text = txtinvoice.Text;
            }

            DataSet dsnew = new DataSet();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save objbkcenter = new NewAdbooking.BillingClass.Classes.billing_save();
                dsnew = objbkcenter.save_det(bookingid, txtinvoice.Text, ds4.Tables[0].Rows[i]["Gross_Rate"].ToString(), singleamt, boxamt2, ds4.Tables[0].Rows[i]["No_Insert"].ToString(), ds4.Tables[0].Rows[i]["Edition"].ToString());

            }
            else
            {
                string result = "";
                NewAdbooking.BillingClass.classesoracle.billing_save objbkcenter = new NewAdbooking.BillingClass.classesoracle.billing_save();
                result = objbkcenter.save_det_monthly(bookingid, txtinvoice.Text, ds4.Tables[0].Rows[i].ItemArray[10].ToString(), abc, boxamt2, ds4.Tables[0].Rows[i].ItemArray[21].ToString(), ds4.Tables[0].Rows[i].ItemArray[3].ToString(), billdater, Session["dateformat"].ToString(), insert_id,fromdate);
                DataSet ds_new = new DataSet();
                if (result == "Fail")
                {
                    NewAdbooking.BillingClass.classesoracle.billing_save objsave_del = new NewAdbooking.BillingClass.classesoracle.billing_save();
                    ds_new = objsave_del.delete_bill_det(txtinvoice.Text);
                    break;


                }





            }




        }



        abc2 = abc1;


        abc1_bill = abc1_bill + 0.01;
        abc1_bill = Math.Round(abc1_bill);


        txtgr.Text = abc1.ToString("F2");


        amtinpr = ((abc1 * pr1) / 100);
        lbextrapre.Text = amtinpr.ToString("F2");
        abc1 = abc1 - amtinpr;
        amount1.Text = abc2.ToString("F2");


        DISCAMT = abc2 * dis1 / 100;

        txtdiscal.Text = DISCAMT.ToString("F2");

        lbtrade1.Text = "TD" + "(" + dis + ")" + "%";
        DISCADTD = abc2 * disn1 / 100;
        lbadtdtxt.Text = DISCADTD.ToString("F2");

        double net = abc2 - ((abc2 * disn1 / 100) + (DISCAMT));
        netpay.Text = abc1_bill.ToString();
    




        dytbl += "</table>";
        dynamictable.Text = dytbl;      
        double gm = amt2 - (amt2 * comm2 / 100);
        //txtgr.Text = gm.ToString("F2");
        double amtincludebox = gm + boxamt2;
        showtable.Visible = true;
        DataSet dsn = new DataSet();









        if (valueofradio == "6" || valueofradio=="firstsave")
        {

            DataSet dfetch = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass.Classes.billing_save();
                dsn = fetchinvoice.fetchlast(bookingid);

            }

            else
            {

                NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();
                dsn = fetchinvoice.fetchlast_monthly_adbil(bookingid, dateto,Session ["dateformat"].ToString ());
            }


         if( dsn.Tables[0].Rows.Count ==0)
         {



                //DataSet dssave = new DataSet();

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {


                    NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.BillingClass.Classes.billing_save();
                    //dssave = objsave.save_last(bookingid, txtinvoice.Text, netpay.Text, amount1.Text, boxamt2, insnum_cou, maxinsert, dateto, maxdate);
                }

                else
                {

                       string err = "";

                       try
                       {

                           DataSet dsxml = new DataSet();
                           string result = "";
                           dsxml.ReadXml(Server.MapPath("XML/bill.xml"));
                           string doctyp = dsxml.Tables[1].Rows[0].ItemArray[0].ToString();
                           NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                           result = objsave.saveinlast(bookingid, txtinvoice.Text, netpay.Text, amount1.Text, boxamt2, insnum_cou, doctyp, maxinsert, billdater, Session["dateformat"].ToString());
                           DataSet ds_new = new DataSet();
                           if (result == "Fail")
                           {
                               NewAdbooking.BillingClass.classesoracle.billing_save objsave_del = new NewAdbooking.BillingClass.classesoracle.billing_save();
                               ds_new = objsave_del.delete_bill_det(txtinvoice.Text);


                           }
                       }
                       catch (Exception e)
                       {
                           err = e.Message;

                       }

                       string adcatcode2 = "CD Bill " + bookingid;
                       clsconnection dconnect = new clsconnection();
                       string sqldd = "insert into log_new (DATE1 , USERID    ,PROCESSNAME  , ERR_DESCRIPTION  ,OBJECT_PROCESS_ID,	DESCRIPTION	,IP	) values($date,'" + Session["userid"].ToString() + "','CD Bill','" + err.Replace("'", "''") + "','CD Bill','" + adcatcode2;
                       sqldd = sqldd + "',";
                       sqldd = sqldd + "'" + serverip + "')";
                       dconnect.executenonquery1(sqldd);

                }
          }




        }




        showtable.Visible = false;





    }


    public void autogenerated_pune(string no, string fromdate)
    {
        DataSet dsinvoice = new DataSet();
        /*change ankur*/
        DateTime dt = DateTime.Now;
        string cen = branch;
        cen = cen.Substring(0, 1);
        string year = "";
       // string year = (dt.Year).ToString();
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

            Session["INVO"] = _auto;
        }

    }





    public void autogenerated(string no)
    {
        DataSet dsinvoice = new DataSet();
        /*change ankur*/
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
        double autono1=0;

        char[] number = autono.ToCharArray();

        if (number.Length < 4)
        {
            if(number.Length ==1)
            {

                autono="000"+autono;

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


                _auto = cen + "/" + year + "-" + nextyr1 + "/" + (autono);
            }
            else if (Session["invoice_no"].ToString() == "2")
            {
                _auto = cen + "/" + year + "-" + nextyr1 + "/" + (autono);



        }
            Session["INVO"] = _auto;
        
        }
        
    }





    public void setcard()
    {

        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double finalamount = 0;
        double discountint = 0;
        int totinsertnewint = 0;
        String dytbl;
        dytbl = "";
        int count11 = Convert.ToInt16(insertion);
        int packlength22 =0;
        if (packagelength!="")
        {
        packlength22 = Convert.ToInt16(packagelength);
        }
        string packagecode11 = packagecode.ToString();
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();
        int i11 = 1;
        int packlength = 0;
        string ciobookingid = id.ToString();
        string editionname = "";
        int totinsert = 0;
        if (totalinsertion != "")
        {
             totinsert = Convert.ToInt16(totalinsertion);
        }
        string i12 = insertion.ToString();
        string[] packagecode1 = packagecode11.Split(',');
        int c1 = packagecode1.Length;
        //====================================

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //NewAdbooking.Classes.invoice objedition = new NewAdbooking.Classes.invoice();
            //ds3 = objedition.edition(packagecode1[packlength], Session["compcode"].ToString());
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
                    //NewAdbooking.Classes.invoice objedition = new NewAdbooking.Classes.invoice();
                    NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
                    ds3 = objedition.edition(packagecode1[packlength], Session["compcode"].ToString());
                }
                else
                {
                    //  NewAdbooking.classesoracle.invoice objedition = new NewAdbooking.classesoracle.invoice();
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

            for (editionlen = 0; editionlen < counteditin; editionlen++)
            {
                //   NewAdbooking.classesoracle.invoice objedition = new NewAdbooking.classesoracle.invoice();
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



            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //    NewAdbooking.Classes.invoice objvalues = new NewAdbooking.Classes.invoice();
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
          
           // Label16.Text = ds4.Tables[0].Rows[0]["Email"].ToString();
          
           // rono.Text = ds4.Tables[0].Rows[0].ItemArray[8].ToString();
            agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[1].ToString();
            lbpakgrate.Text = ds4.Tables[0].Rows[0]["package rate"].ToString();
           // pubtxt.Text = ds4.Tables[0].Rows[0].ItemArray[2].ToString();
         


            //amtdisc.Text = ds4.Tables[0].Rows[0].ItemArray[10].ToString();
            //if (amtdisc.Text == "")
            //{ }
            //else
            //{

            //    double disc = Convert.ToDouble(amtdisc.Text);
            //}

            txtcliname.Text = ds4.Tables[0].Rows[0].ItemArray[26].ToString();
           // citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[25].ToString();
            lbaddress.Text = ds4.Tables[0].Rows[0].ItemArray[19].ToString();
            //citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[20].ToString();
           // rupeetxt.Text = ds4.Tables[0].Rows[0].ItemArray[18].ToString();
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
                 lbronodate.Text = rono1 + rodate;
            }
            lbronodate.Text = rono1 + " / " + rodate;




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


            dytbl = "";
            dytbl += "<table width='450px' align='left' cellpadding='5' cellspacing='0'>";
            {
                DataSet dsb = new DataSet();
                dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
                dytbl += "<tr align=center >";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[26].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[27].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";

                dytbl += "</tr>";


            }

            
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

                string editionname1 = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                    NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();

                    ds4 = objedition1.values_bill(ciobookingid, editionname, i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.invoice objvalues1 = new NewAdbooking.BillingClass.classesoracle.invoice();

                    ds4 = objvalues1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                }


                //ldduedate.Text = ds4.Tables[0].Rows[0]["paydatesys"].ToString();

               
               // lbhead2.Text = ds4.Tables[0].Rows[0].ItemArray[36].ToString();
                string phone1 = ds4.Tables[0].Rows[0].ItemArray[37].ToString();
                //comment by gaurav   
               // Label1.Text = phone1 + "-" + ds4.Tables[0].Rows[0].ItemArray[38].ToString();
               // Label3.Text = phone1 + "-" + ds4.Tables[0].Rows[0].ItemArray[39].ToString();

            
               
               // format.Text = ds4.Tables[0].Rows[0].ItemArray[40].ToString();
                // txtgroup.Text = ds4.Tables[0].Rows[0].ItemArray[41].ToString();

                string amt = ds4.Tables[0].Rows[0]["Gross_Rate"].ToString();
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


                //lbpack.Text = packrate1.ToString();








                string discountstr = ds4.Tables[0].Rows[0].ItemArray[10].ToString();
                if (discountstr != "")
                    discountint = Convert.ToDouble(discountstr);
                else
                    discountint = Convert.ToInt16(0);


                ///


               
                



                /////////////////////////////////////////////////////////////////////////////////

                dytbl += "<tr>";
                dytbl += "<td width=65px   align=left >" + ds4.Tables[0].Rows[0]["EditionName"].ToString() + "</td>";
                dytbl += "<td width=65px   align=left >" + ds4.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
               
                if (ds4.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                {
                    dytbl += "<td   align=center >" + ds4.Tables[0].Rows[0].ItemArray[5].ToString() +"*"+ds4.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
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


                if (ds4.Tables[0].Rows[0]["Card_Rate"].ToString() != "")
                    dytbl += "<td width=63px  align=left>" + ds4.Tables[0].Rows[0]["Card_Rate"].ToString() + "</td>";
                else
                    dytbl += "<td width=63px  align=left>---</td>";


                

                dytbl += "</tr>";



            }



            dytbl += "</table>";




            dynamictable.Text = dytbl;


            double amountprem = amt4 * (premiumper1 / 100);
            //txtprem.Text = amountprem.ToString();
            //txch.Text = ds4.Tables[0].Rows[0].ItemArray[31].ToString();
           // amtdisc.Text = ds4.Tables[0].Rows[0].ItemArray[32].ToString();
            //txtper.Text = ds4.Tables[0].Rows[0].ItemArray[33].ToString();







            amount1.Text = amt4.ToString();

            //if (txch.Text == "")
            //{
            //    txch.Text = "0";
            //}
            //if (amtdisc.Text == "")
            //{
            //    amtdisc.Text = "0";
            //}

            //if (txch.Text != "")
            //{
            //    spcharges = Convert.ToDouble(txch.Text);
            //}
            //if (amtdisc.Text != "")
            //{
            //    spdes = Convert.ToDouble(amtdisc.Text);
            //}


            //if (txtper.Text != "")
            //{
            //    dispr = Convert.ToDouble(txtper.Text);
            //}


            amountprem = amt4 + amountprem - (spcharges + spdes);
            txtgr.Text = amountprem.ToString();
            double disper1 = amountprem * (dispr / 100);
            txtdiscal.Text = disper1.ToString();
           
            amountinckudingbox = amountprem + boxchg1 - disper1;
            //txttotal.Text = amountinckudingbox.ToString();
            double amountforvat1 = 0;
            DataSet dsvat = new DataSet();
      


              




            

            double amountinckudingbox1 = Math.Round(amountinckudingbox);
            netpay.Text = amountinckudingbox1.ToString();
       


            NumberToEngish obj = new NumberToEngish();

        





















        }







    }


    public void setcardfirst()
    {

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

        agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
        agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[13].ToString();
        agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
        //pubtxt.Text = ds4.Tables[0].Rows[0].ItemArray[16].ToString();
        adcat.Text = ds4.Tables[0].Rows[0].ItemArray[17].ToString();
        lbclientna.Text = ds4.Tables[0].Rows[0].ItemArray[18].ToString();
        lbclientadd.Text = ds4.Tables[0].Rows[0].ItemArray[19].ToString();
       // citytxt.Text = ds4.Tables[0].Rows[0].ItemArray[20].ToString();
//txtcomm.Text = ds4.Tables[0].Rows[0].ItemArray[23].ToString();


        String dytbl;
        dytbl = "";
        dytbl += "<table width='450px'align='left' cellpadding='5' cellspacing='0' vlaign='top'>";
        {

            DataSet dsb = new DataSet();
            dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
            dytbl += "<tr align=center >";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[26].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[27].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";

            dytbl += "</tr>";
        }

        int insnum_cou = ds4.Tables[0].Rows.Count;

        for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
        {

            dytbl += "<tr align=center>";
            dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[7].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[29].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";

        
            dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>";
           //dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>";
            //dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>";
   
            //dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>";
            //if (ds4.Tables[0].Rows[i].ItemArray[9].ToString() != "")
            //{
            //    dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>";
            //}
            //else
            //{
            //    dytbl += "<td class='insertiontxtclass' >" + "</td>";
            //}
            //dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>";
     
            //dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>";
            string amt = ds4.Tables[0].Rows[i].ItemArray[10].ToString();
            amt1 = Convert.ToDouble(amt);
            amt2 = amt2 + amt1;


            dytbl += "</tr>";


        }




        dytbl += "</table>";
        dynamictable.Text = dytbl;

        showtable.Visible = true;




      



    }


    public void setcardnew()
    {

        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double finalamount = 0;
        double discountint = 0;
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
            //editionname =packagecode1

        }
        for (packlength = 0; packlength < c1; packlength++)
        {


            if (counted <= 1)
            {


                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    //NewAdbooking.Classes.invoice objedition = new NewAdbooking.Classes.invoice();
                    NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
                    ds3 = objedition.edition(packagecode1[packlength], Session["compcode"].ToString());
                }
                else
                {
                    //  NewAdbooking.classesoracle.invoice objedition = new NewAdbooking.classesoracle.invoice();
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

            for (editionlen = 0; editionlen < counteditin; editionlen++)
            {
                //   NewAdbooking.classesoracle.invoice objedition = new NewAdbooking.classesoracle.invoice();
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



            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //    NewAdbooking.Classes.invoice objvalues = new NewAdbooking.Classes.invoice();
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

         
            agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[1].ToString();
            lbpakgrate.Text = ds4.Tables[0].Rows[0]["package rate"].ToString();
        




            txtcliname.Text = ds4.Tables[0].Rows[0].ItemArray[26].ToString();
          
            lbaddress.Text = ds4.Tables[0].Rows[0].ItemArray[19].ToString();
           
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
                lbronodate.Text = rono1 + rodate;
            }
            lbronodate.Text = rono1 + " / " + rodate;




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

                string editionname1 = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                    NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();

                    ds4 = objedition1.values_bill(ciobookingid, editionname, i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.invoice objvalues1 = new NewAdbooking.BillingClass.classesoracle.invoice();

                    ds4 = objvalues1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                }


                
                string phone1 = ds4.Tables[0].Rows[0].ItemArray[37].ToString();

                string amt = ds4.Tables[0].Rows[0]["Gross_Rate"].ToString();
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


                //lbpack.Text = packrate1.ToString();








                string discountstr = ds4.Tables[0].Rows[0].ItemArray[10].ToString();
                if (discountstr != "")
                    discountint = Convert.ToDouble(discountstr);
                else
                    discountint = Convert.ToInt16(0);


                ///



                dytbl = "";
                dytbl += "<table width='450px' align='left' cellpadding='5' cellspacing='0'>";
                {
                    DataSet dsb = new DataSet();
                    dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
                    dytbl += "<tr align=center >";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[26].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[27].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";

                    dytbl += "</tr>";


                }




                /////////////////////////////////////////////////////////////////////////////////

                dytbl += "<tr>";
                dytbl += "<td width=65px   align=left >" + ds4.Tables[0].Rows[0]["EditionName"].ToString() + "</td>";
                dytbl += "<td width=65px   align=left >" + ds4.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";

                if (ds4.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                {
                    dytbl += "<td width=63px  align=center >" + ds4.Tables[0].Rows[0].ItemArray[5].ToString() + "*" + ds4.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
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


                if (ds4.Tables[0].Rows[0]["Card_Rate"].ToString() != "")
                    dytbl += "<td width=63px  align=left>" + ds4.Tables[0].Rows[0]["Card_Rate"].ToString() + "</td>";
                else
                    dytbl += "<td width=63px  align=left>---</td>";




                dytbl += "</tr>";



            }



            dytbl += "</table>";




            dynamictable.Text = dytbl;


            double amountprem = amt4 * (premiumper1 / 100);
          






            amount1.Text = amt4.ToString();

            


            amountprem = amt4 + amountprem - (spcharges + spdes);
            txtgr.Text = amountprem.ToString();
            double disper1 = amountprem * (dispr / 100);
            txtdiscal.Text = disper1.ToString();

            amountinckudingbox = amountprem + boxchg1 - disper1;
          String TXTTOTAL = amountinckudingbox.ToString();
            double amountforvat1 = 0;
            DataSet dsvat = new DataSet();










            double amountinckudingbox1 = Math.Round(amountinckudingbox);
            netpay.Text = amountinckudingbox1.ToString();



            NumberToEngish obj = new NumberToEngish();

            DataSet dfetch = new DataSet();




            if (valueofradio == "2")
            {

                if (packlength == c1)
                {

                    //////////////

                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {


                        //     NewAdbooking.classesoracle.billing_save objsave = new NewAdbooking.classesoracle.billing_save();
                        NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                        dfetch = objsave.fetchstatus(ds4.Tables[0].Rows[0].ItemArray[0].ToString(), totinsert);



                    }
                    else
                    {
                       
                        NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.BillingClass.Classes.billing_save();

                        dfetch = objsave.fetchstatus(ciobookingid, totinsert);


                    }
                    if ((dfetch.Tables[0].Rows[0].ItemArray[0].ToString() == "publish") || (dfetch.Tables[0].Rows[0].ItemArray[0].ToString() == "audit by rate"))
                    {

                        /////////

                        finalamount = amountinckudingbox * totinsert;
                        DataSet dssave = new DataSet();
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {

                            // NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.Classes.billing_save();
                            NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.BillingClass.Classes.billing_save();
                            dssave = objsave.saveinsertiowise(ds4.Tables[0].Rows[0].ItemArray[0].ToString(), txtinvoice.Text, netpay.Text, TXTTOTAL, totinsert, boxchg1, insertiontxt.Text, edicode, finalamount, discountint, premiumper1);
                        }
                        else
                        {

                            DataSet dsxml = new DataSet();
                            dsxml.ReadXml(Server.MapPath("XML/bill.xml"));
                            string doctyp = dsxml.Tables[1].Rows[0].ItemArray[0].ToString();
                            NewAdbooking.BillingClass.classesoracle.billing_save objsave = new NewAdbooking.BillingClass.classesoracle.billing_save();
                            dssave = objsave.saveinsertiowise(ds4.Tables[0].Rows[0].ItemArray[0].ToString(), txtinvoice.Text, netpay.Text, TXTTOTAL, totinsert, boxchg1, insertiontxt.Text, edicode, finalamount, discountint, doctyp, premiumper1);


                        }

                    }
                }
            }

            showtable.Visible = false;























        }







    }
}
