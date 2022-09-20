using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class dmhbill_formate : System.Web.UI.UserControl
{
    public string _lblpo;
    public string _txtpono;
    public string _txtlbltel;
    public string _txtlblfax;
    public string _lbltel;
    public string _lblfax;
    public string _lblmail;
    public string _txtlblmail;



    public string _lblinv;
    public string _lblregnr;
    public string _lblcoreg;
    public string _txtlblregnr;
    public string _txtlblcoregt;




    public string _lbldt;
    public string _lblpg;
    public string _txtlbldt;
    public string _txtlblpg;
    public string _lblinvno;
    public string _txtlblinvno;




    public string _lblsold;
    public string _lblship;


    public string _lbladd;
    public string _Label1;


    public string _lblordno;
    public string _lblordrdt;
    public string _lblcustno;
    public string _lblsalspr;
    public string _lblponmbr;
    public string _lblform;




    public string _txtlblordno;
    public string _txtlblordrdt;
    public string _txtlblcustno;
    public string _txtlblsalspr;
    public string _txtlblponmbr;
    public string _txtlblform;



    public string _lblnb;
    public string _lblfnb;
    public string _lblbrnch;
    public string _lblacnt;
    public string _lbltel1;
    public string _lblfax1;
    public string _txtlblfnb;
    public string _txtlblbrnch;
    public string _txtlblacnt;
    public string _txtlbltel1;
    public string _txtlblfax1;

    public string _dynamictable;


    public string _lblsubttl;
    public string _lblvatttl;


    public string _lblamnt;
    public string _txtlblsubttl;
    public string _txtlblvattl;
    public string _txtlblamt;


    ////////////////////


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
    public string _orignaldupli;
    public string _remark;
    public string _chkvalue_length;

    public dmhbill_formate()
    {
        _chkvalue_length = "";
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
        _orignaldupli = "";
        _remark = "";
        ///////////
        _lblpo="";
        _txtpono = "";
        _txtlbltel = "";
        _txtlblfax = "";
        _lbltel = "";
        _lblfax = "";
        _lblmail = "";
        _txtlblmail = "";



        _lblinv = "";
        _lblregnr = "";
        _lblcoreg = "";
        _txtlblregnr = "";
        _txtlblcoregt = "";




        _lbldt = "";
        _lblpg = "";
        _txtlbldt = "";
        _txtlblpg = "";
        _lblinvno = "";
        _txtlblinvno = "";




        _lblsold = "";
        _lblship = "";


        _lbladd = "";
        _Label1 = "";


        _lblordno = "";
        _lblordrdt = "";
        _lblcustno = "";
        _lblsalspr = "";
        _lblponmbr = "";
        _lblform = "";




        _txtlblordno = "";
        _txtlblordrdt = "";
        _txtlblcustno = "";
        _txtlblsalspr = "";
        _txtlblponmbr = "";
        _txtlblform = "";



        _lblnb = "";
        _lblfnb = "";
        _lblbrnch = "";
        _lblacnt = "";
        _lbltel1 = "";
        _lblfax1 = "";
        _txtlblfnb = "";
        _txtlblbrnch = "";
        _txtlblacnt = "";
        _txtlbltel1 = "";
        _txtlblfax1 = "";

        _dynamictable = "";


        _lblsubttl = "";
        _lblvatttl = "";


        _lblamnt = "";
        _txtlblsubttl = "";
        _txtlblvattl = "";
        _txtlblamt = "";


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
    public string chkvalue_length { get { return _chkvalue_length; } set { _chkvalue_length = value; } }

    public string publication { get { return _publication; } set { _publication = value; } }
    public string rundate1 { get { return _rundate; } set { _rundate = value; } }
    public string packgerate { get { return _packgerate; } set { _packgerate = value; } }
    public string orderno1 { get { return _orderno; } set { _orderno = value; } }
    public string discount { get { return _discount; } set { _discount = value; } }
    public string amount { get { return _amount; } set { _amount = value; } }
    public string edition1 { get { return _edition1; } set { _edition1 = value; } }
    public string Client { get { return _client; } set { _client = value; } }

    public string agencycode { get { return _agencycode; } set { _agencycode = value; } }
    public string orignaldupli { get { return _orignaldupli; } set { _orignaldupli = value; } }

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
    public string remark { get { return _remark; } set { _remark = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/dmhbill_formate.xml"));
        lblpo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
       // txtpono.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbltel.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblfax.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblmail.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbldt.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblpg.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblinvno.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
   
        lblregnr.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
   lblcoreg.Text="Co Reg No.:";
        lblnb.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblsold.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lblship.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lblordno.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lblordrdt.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lblcustno.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lblsalspr.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lblponmbr.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        lblform.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
        lblbrnch.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
        lblfax1.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbltel1.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblacnt.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
        lblsch.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        lblvatno.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        lblsubttl.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();

        lblvatttl.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        lblamnt.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        txtlblregnr.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        txtlblcoregt.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        txtpono.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        txtlblponmbr.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
        txtlblform.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
        txtlblfnb.Text = ds.Tables[2].Rows[0].ItemArray[0].ToString();
        txtlblbrnch.Text = ds.Tables[2].Rows[0].ItemArray[1].ToString();
        txtlblacnt.Text = ds.Tables[2].Rows[0].ItemArray[2].ToString();
        txtlblfax1.Text = ds.Tables[2].Rows[0].ItemArray[3].ToString();
        txtlbltel1.Text = ds.Tables[2].Rows[0].ItemArray[4].ToString();
    }



    public void setcard()
    {
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
        double volume = 0;
        double height1 = 0;
        double width1 = 0;
        double ext = 0;
        double grs = 0;
        double totalam = 0;
        double Disc = 0;
        string agrred_rate = "0";
        string GAamt1 = "0";
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
                ds4 = objvalues.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.invoice objvalues = new NewAdbooking.BillingClass.classesoracle.invoice();
                ds4 = objvalues.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
            }
            //adcat.Text = ds4.Tables[0].Rows[0].ItemArray[12].ToString();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/bill.xml"));
            //To get the Branch Address...........................
            DataSet dsbranch = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.invoice objvalues = new NewAdbooking.BillingClass.Classes.invoice();
                dsbranch = objvalues.values_bill(Session["compcode"].ToString(), Session["revenue"].ToString(), "");
            }
            if (dsbranch.Tables[0].Rows.Count > 0)
            {
                //branchadd.Text = dsbranch.Tables[0].Rows[0]["Add1"].ToString();
                //bhranchadd1.Text = "Ph:-" + dsbranch.Tables[0].Rows[0]["Phone1"].ToString() + "-" + dsbranch.Tables[0].Rows[0]["Phone2"].ToString() + "," + "fax:- " + dsbranch.Tables[0].Rows[0]["fax"].ToString();
            }
     
            ////////////////////
            if (ds4.Tables[0].Rows[0]["bill2"].ToString() == "" || ds4.Tables[0].Rows[0]["bill2"].ToString() == null)
            {

                lbladd.Text = ds4.Tables[0].Rows[0]["Agency"].ToString();
                
            }
            else
            {
                string[] addname = ds4.Tables[0].Rows[0]["agenadd1"].ToString().Split("$$".ToCharArray());
                lbladd.Text = addname[2] + "</br>" + addname[0] + "</br>" + addname[1]; 
               
            }


            if (ds4.Tables[0].Rows[0]["bill2"].ToString() == "" || ds4.Tables[0].Rows[0]["bill2"].ToString() == null)
            {

                Label1.Text = ds4.Tables[0].Rows[0]["Agency"].ToString();
           
            }
            else
            {
                string[] addname = ds4.Tables[0].Rows[0]["agenadd"].ToString().Split("$$".ToCharArray());
                Label1.Text = addname[2];
            
            }
            if (invoiceno == "&nbsp;")
            {
                txtlblinvno.Text = "XXXX";
            }
            else
            {
                txtlblinvno.Text = invoiceno;
            }
            if (ds4.Tables[0].Rows[0]["date_time"].ToString() != "")
            {
                string[] date_new = ds4.Tables[0].Rows[0]["date_time"].ToString().Split("/".ToCharArray());
                string name = "";
                if (date_new[1] == "1")
                    name = "jan";
                else if (date_new[1] == "2")
                    name = "Feb";
                else if (date_new[1] == "3")
                    name = "March";
                else if (date_new[1] == "4")
                    name = "Apr";
                else if (date_new[1] == "5")
                    name = "may";
                else if (date_new[1] == "6")
                    name = "Jun";
                else if (date_new[1] == "7")
                    name = "July";
                else if (date_new[1] == "8")
                    name = "Aug";
                else if (date_new[1] == "9")
                    name = "Sep";
                else if (date_new[1] == "10")
                    name = "Oct";
                else if (date_new[1] == "11")
                    name = "Nov";
                else if (date_new[1] == "12")
                    name = "Dec";


                txtlbldt.Text = name + "&nbsp;" + date_new[0] + "," + date_new[2];
            }
            else
            {
                txtlbldt.Text = "&nbsp";
            }

            if(ds4.Tables[0].Rows[0]["page_no"].ToString()!="")
            {
                txtlblpg.Text = ds4.Tables[0].Rows[0]["page_no"].ToString();
            }
            else
            {
                txtlblpg.Text = "";
            }
            if (ds4.Tables[0].Rows[0]["advertiser"].ToString()!="")
            {
                txtlblsalspr.Text = ds4.Tables[0].Rows[0]["advertiser"].ToString();
            }
            else
            {
                txtlblsalspr.Text = "";
            }







            string[] addname1 = ds4.Tables[0].Rows[0]["street_login"].ToString().Split("~".ToCharArray());
            //lbcompaddress.Text = addname1[0];
            txtlblmail.Text = addname1[1];
            if (ds4.Tables[0].Rows[0]["fax"].ToString() != "")
            {
                txtlblfax.Text= ds4.Tables[0].Rows[0]["fax"].ToString();
            }
            if (ds4.Tables[0].Rows[0]["phone1"].ToString() != "")
            {
               txtlbltel.Text= ds4.Tables[0].Rows[0]["phone1"].ToString();
            }
            else
            {
                txtlbltel.Text = "9535676543";
            }

            txtlblcustno.Text = ds4.Tables[0].Rows[0]["client"].ToString();
            txtlblordno.Text = ds4.Tables[0].Rows[0]["CIOID"].ToString();
            txtlblordrdt.Text = ds4.Tables[0].Rows[0]["Ro_Date"].ToString();















    
     
      
      
     
       
      
     
     
    



            
            dytbl = "";
            dytbl += "<table width='678px' align='left' cellpadding='5' cellspacing='0' >";
            {
                DataSet dsb = new DataSet();
                dsb.ReadXml(Server.MapPath("XML/dmhbill_formate.xml"));
                dytbl += "<tr align=center >";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='10px' >" + dsb.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='200px' >" + dsb.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='197px' >" + dsb.Tables[1].Rows[0].ItemArray[2].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>";
                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>";
        
                
                dytbl += "</tr>";
            }

                    /////////////////////////////////////////////////////////////////////////////////
           
                dytbl += "<tr align=center hight='67px'>";
                dytbl += "<td class='insertiontxtclass' align='center' style='border-right:solid 1px black;border-left:solid 1px black;'>" + srl.ToString() + "</td>";

                //dytbl += "<td class='insertiontxtclass' align='center'width='50px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["Ins.date"].ToString() + "</td>";
                if (ds4.Tables[0].Rows[0]["uom_name"].ToString() != "")
                {

                    dytbl += "<td  class='insertiontxtclass' align='center' width='150px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["uom_name"].ToString() + "</td>";

                }
                else
                {
                    dytbl += "<td  class='insertiontxtclass' align='center' width='150px' style='border-right:solid 1px black;'>" + "&nbsp;" + "</td>";

                }
                if (ds4.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    {
                        dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["Depth"].ToString() + "*" + ds4.Tables[0].Rows[0]["Width"].ToString() + "</td>";
                    }
                }
                else
                {
                    dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["volume"].ToString() + "</td>";
                }



                dytbl += "<td class='insertiontxtclass'align='center' width='90px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[0]["gross_amount"].ToString() + "</td>";

                if (ds4.Tables[0].Rows[0]["uom_code"].ToString() != "")
                {

                    dytbl += "<td  class='insertiontxtclass' align='center' width='150px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["uom_code"].ToString() + "</td>";

                }
                else
                {
                    dytbl += "<td  class='insertiontxtclass' align='center' width='150px' style='border-right:solid 1px black;'>" + "&nbsp;" + "</td>";

                }

                if (ds4.Tables[0].Rows[0]["Bill_Amt"].ToString() != "")
                {
                    bill_amt = Convert.ToDouble(ds4.Tables[0].Rows[0]["Bill_Amt"].ToString());
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px' style='border-right:solid 1px black;'>" + bill_amt + "</td>";

                }
                else
                {
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px' style='border-right:solid 1px black;'>" + "&nbsp;" + "</td>";

                }

                bill_amt1 = bill_amt1 + bill_amt;
         
                dytbl += "</tr>";

          
                    srl++;

                }

                dytbl += "</table>";

                dynamictable.Text = dytbl;

                double vat = Convert.ToDouble(ds4.Tables[0].Rows[0]["trade_disc"].ToString());
                txtlblvattl.Text = vat.ToString("F2");
                txtlblvat.Text = vat.ToString("F2");
                txtlblsubttl.Text = bill_amt1.ToString("F2");
                bill_amt1 = bill_amt1 + 0.01;

                double total_amnt = vat + bill_amt1;
                txtlblamt.Text = total_amnt.ToString("F2");
              

                ///////////////////////////////////////////////////////////////////////////////////////////////

                if (chkvalue_length == "yes")
                {
                    div_p.Attributes.Add("style", "page-break-after:always;");
                }
          







      



        }

    }
