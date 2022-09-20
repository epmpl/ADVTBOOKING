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
//using System.Xml.Linq;

public partial class RP_bill : System.Web.UI.UserControl
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
    public RP_bill()
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

    public void setcard()
    {
        string packagecode11 = packagecode.ToString();

        int srl = 1;
        int packlength = 0;
        string ciobookingid = id.ToString();

        string i12 = insertion.ToString();
        string[] packagecode1 = packagecode11.Split(',');
        int c1 = packagecode1.Length;


        DataSet ds4 = new DataSet();
        string street = "";
        String dytbl = "";

        double Insertgrossamt = 0;
        double traddis = 0;
        double adddis = 0;
        double addchr = 0;
        double bill_amt = 0;
        double bill_amt1 = 0;

        double Gross_Rate = 0;
        double add_ag_dis = 0;
        int minword = 0;
        int maxword = 0;
        int extraword = 0;
        double extrarate=0;
        double bulletcrg = 0;
        double boxchrg = 0;
        double transcrg = 0;

       if(c1 > 0)
        {

//To Fetch Address and file from publication Center
            DataSet dspub = new DataSet();
           if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.invoice objvalues = new NewAdbooking.BillingClass.Classes.invoice();
                //ds4 = objvalues.values_bill(ciobookingid, editionname, i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.invoice objvalues = new NewAdbooking.BillingClass.classesoracle.invoice();
                //dspub = objvalues.getpubcent_detail(Session["compcode"].ToString(), Session["center"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString());
            }

           if (dspub.Tables[0].Rows.Count > 0)
           {
               string path = "Images/" + dspub.Tables[0].Rows[0]["LOGO_FILE_PATH"].ToString();
               float ht = 40;
               if (System.IO.File.Exists(Server.MapPath(path)))
               {
                   divimg.InnerHtml = "<img style='padding-right:5px;' src='" + path + "' height='" + ht + "'>";
               }
               pubadd.Text = dspub.Tables[0].Rows[0]["ADD1"].ToString() + " " + dspub.Tables[0].Rows[0]["STREET"].ToString();
               pubtel.Text = "Tel: "+dspub.Tables[0].Rows[0]["PHONE1"].ToString() + "-" + dspub.Tables[0].Rows[0]["PHONE2"].ToString();
               pubpan.Text = "Pan No :"+dspub.Tables[0].Rows[0]["PAN_NO"].ToString();
               lblbranch.Text = dspub.Tables[0].Rows[0]["CITY_NAME"].ToString();
               lblbrnch.Text = dspub.Tables[0].Rows[0]["CITY_NAME"].ToString();
               lblcompnam.Text = dspub.Tables[0].Rows[0]["CENTER_COMP_NAME"].ToString();
               lblmailid.Text = "e-mail :" + dspub.Tables[0].Rows[0]["EMAILID"].ToString();
               if (dspub.Tables[0].Rows[0]["FAX"].ToString() != null && dspub.Tables[0].Rows[0]["FAX"].ToString() != "")
                   pubfax.Text = "Fax :" + dspub.Tables[0].Rows[0]["FAX"].ToString();
           }

           
            for (packlength = 0; packlength < c1; packlength++)
            {

                double packagegrossamt = 0;
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                    NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();
                    //ds4 = objedition1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                }
                else
                {
                    NewAdbooking.BillingClass.classesoracle.invoice objvalues1 = new NewAdbooking.BillingClass.classesoracle.invoice();
                  //  ds4 = objvalues1.values_bill_rp(ciobookingid, packagecode1[packlength].Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());


                }

                if (packlength == 0)
                {
                    //To fill data in Dynamic Table Header
                    dytbl += "<table width='900px' border=0 align='left' cellpadding='0' cellspacing='0' >";
                    DataSet dsb = new DataSet();
                    dsb.ReadXml(Server.MapPath("XML/RP_bill.xml"));
                    if (Session["bill_org"].ToString() == "0")
                    {
                        orgdup.Text = dsb.Tables[0].Rows[0].ItemArray[15].ToString();
                    }
                    else
                    {
                        orgdup.Text = dsb.Tables[0].Rows[0].ItemArray[16].ToString();
                    }

                    txtinvoice.Text = invoiceno.ToString();
                    dytbl += "<tr align=center >";
                    dytbl += "<td class='insertiontxtclass1' width='85px'  >" + dsb.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' width='125x'  >" + dsb.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>";
                    dytbl += "<td   class='insertiontxtclass1'width='75px' >" + dsb.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>";

                    if (ds4.Tables[0].Rows[0]["Ad_type_code"].ToString() == "DI0" || ds4.Tables[0].Rows[0]["Uom_code"].ToString() == "CL0")
                    {
                        dytbl += "<td   class='insertiontxtclass1' width='100px' >" + "<table cellpadding='0' cellspacing='0' width='100px' ><tr><td colspan='2'>" + dsb.Tables[0].Rows[0].ItemArray[2].ToString() + " </td></tr><tr><td  style='border-right:solid 1px black;border-top:solid 1px black' >Height</td><td style='border-top:solid 1px black'>Width</td></tr></table></td>";
                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";
                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
                        dytbl += "<td  class='insertiontxtclass1' width='100px' >" + dsb.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";
                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                        dytbl += "<td    class='insertiontxtclass14' width='100px' >" + dsb.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
                        adcat.Text = ds4.Tables[0].Rows[0]["Cap"].ToString();


                    }
                    else
                    {
                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";
                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";
                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";
                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[19].ToString() + "</td>";
                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[20].ToString() + "</td>";
                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                        dytbl += "<td    class='insertiontxtclass14'>" + dsb.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
                        adcat.Text = ds4.Tables[0].Rows[0]["Adv_Cat_Name"].ToString() + "/" + ds4.Tables[0].Rows[0]["Adv_Subcat_Name"].ToString();
                    }

                    dytbl += "</tr>";
                }

//============***********************======================//
                agencytxt.Text = ds4.Tables[0].Rows[0]["Agency"].ToString();
                lblkeyno.Text = ds4.Tables[0].Rows[0]["Key No"].ToString();

                street = ds4.Tables[0].Rows[0]["street"].ToString();
                agencyaddtxt.Text = ds4.Tables[0].Rows[0]["add1"].ToString();
                agencyaddtxt.Text = agencyaddtxt.Text + "," + street + ds4.Tables[0].Rows[0]["add2"].ToString() + ds4.Tables[0].Rows[0]["add3"].ToString();

                lb_booking_id.Text = ds4.Tables[0].Rows[0]["CIOID"].ToString();
                runtxt.Text = ds4.Tables[0].Rows[0]["BILL_DATE"].ToString();
                

                txtcliname.Text = ds4.Tables[0].Rows[0]["advertiser"].ToString();
                lbronodate.Text = ds4.Tables[0].Rows[0]["RoNo."].ToString() + "-" + ds4.Tables[0].Rows[0]["RO_Date"].ToString();

                if (ds4.Tables[0].Rows[0]["Bill_remarks"].ToString() != "" && ds4.Tables[0].Rows[0]["Bill_remarks"].ToString() != null)
                {
                    lblremark.Text = ds4.Tables[0].Rows[0]["Bill_remarks"].ToString();
                }
                if (ds4.Tables[0].Rows[0]["Scheme"].ToString() != "" && ds4.Tables[0].Rows[0]["Scheme"].ToString() != null)
                {
                    lblschemetype.Text = ds4.Tables[0].Rows[0]["Scheme"].ToString();
                }

               
//=============================************========================================//
                if (ds4.Tables[0].Rows[0]["trade_disc"].ToString() != "")
                {
                    traddis = Convert.ToDouble(ds4.Tables[0].Rows[0]["trade_disc"].ToString());
                }
                else
                {
                    traddis = 0;
                }
                if (ds4.Tables[0].Rows[0]["addcom"].ToString() != "" && ds4.Tables[0].Rows[0]["addcom"].ToString() != null)
                {
                    add_ag_dis = Convert.ToDouble(ds4.Tables[0].Rows[0]["addcom"].ToString());
                }
                else
                {
                    traddis = 0;
                }

                if (ds4.Tables[0].Rows[0]["special_discount"].ToString() != "")
                {
                    adddis = Convert.ToDouble(ds4.Tables[0].Rows[0]["special_discount"].ToString());
                }

                if (ds4.Tables[0].Rows[0]["special_charges"].ToString() != "")
                {
                    addchr = Convert.ToDouble(ds4.Tables[0].Rows[0]["special_charges"].ToString());

                }
//===================**************For package Gross Amount And Bill amount*************================//
                for (int k1 = 0; k1 < ds4.Tables[0].Rows.Count; k1++)
                {
                    if(ds4.Tables[0].Rows[k1]["Gross_Rate"].ToString() != "")
                    packagegrossamt=packagegrossamt + Convert.ToDouble(ds4.Tables[0].Rows[k1]["Gross_Rate"].ToString());
                    
                    //string boxcharges = ds4.Tables[0].Rows[0].ItemArray[21].ToString();
                    
                    if (ds4.Tables[0].Rows[k1]["Bill_Amt"].ToString() != "")
                    {
                        bill_amt = Convert.ToDouble(ds4.Tables[0].Rows[k1]["Bill_Amt"].ToString());
                    }
                    else
                    {
                        bill_amt = 0;
                    }

                    bill_amt1 = bill_amt1 + bill_amt;
                }
                Insertgrossamt = Insertgrossamt + packagegrossamt;
 //===================**************End of package Gross Amount And Bill amount*************================//

                dytbl += "<tr>";
                dytbl += "<td    align='left' class='display'>" + ds4.Tables[0].Rows[0]["Package"].ToString() + "</td>";

               
                if (ds4.Tables[0].Rows[0]["Ad_type_code"].ToString() == "DI0" || ds4.Tables[0].Rows[0]["Uom_code"].ToString() == "CL0")
                {
                    dytbl += "<td   class=display align='center'></td>";
                    dytbl += "<td   class=display align='center'></td>";

                    //if (ds4.Tables[0].Rows[0]["Depth"].ToString() != "" && ds4.Tables[0].Rows[0]["Width"].ToString() != "")
                    //{
                    dytbl += "<td    class=display align='center' width='100px' >" + "<table cellpadding='0' cellspacing='0' width='100px' ><tr><td style='' width='55px' >" + ds4.Tables[0].Rows[0]["Depth"].ToString() + "</td><td>" + ds4.Tables[0].Rows[0]["Width"].ToString() + "</td></tr></table></td>";

                    //}
                    //else
                    //    dytbl += "<td    class=display align='center' width='100px' >" + "<table cellpadding='0' cellspacing='0' width='100px' ><tr><td style='border-right:solid 1px black;'>---</td><td>---</td></tr></table></td>";

                    dytbl += "<td   align='center' class=display>" + ds4.Tables[0].Rows[0]["Volume"].ToString() + "</td>";
                    if (ds4.Tables[0].Rows[0]["premiumname"].ToString() != "" && ds4.Tables[0].Rows[0]["premiumname"].ToString() != null)
                    {
                        dytbl += "<td   class=display align='right' >" + ds4.Tables[0].Rows[0]["premiumname"].ToString() + "</td>";

                    }
                    else
                        dytbl += "<td  class=display align='right'>---</td>";

                    if (ds4.Tables[0].Rows[0]["premiumch"].ToString() != "" && ds4.Tables[0].Rows[0]["premiumch"].ToString() != null)
                    {
                        dytbl += "<td   class=display align='right' >" + ds4.Tables[0].Rows[0]["premiumch"].ToString() + "</td>";

                    }
                    else
                        dytbl += "<td  class=display align='right'></td>";




                    string col = ds4.Tables[0].Rows[0]["Hue"].ToString();
                    col = col.Substring(0, 3);
                    string col1 = col;
                    col1 = col1.Substring(0, 1);
                    if (col1 == "B")
                    {
                        col = "B / W";
                    }
                    dytbl += "<td   align='center' class=display>" + col + "</td>";


                    if (ds4.Tables[0].Rows[0]["Card_Rate"].ToString() != "")
                    {
                        //dytbl += "<td   class=display align='center' >" + ds4.Tables[0].Rows[0]["Card_Rate"].ToString() + "</td>";
                        dytbl += "<td   class=display align='center' >" + ds4.Tables[0].Rows[0]["package rate"].ToString() + "</td>";

                    }
                    else
                        dytbl += "<td  class=display align='center'></td>";
                    //for extra rate
                    dytbl += "<td    align='right' class='display1'></td>";

                }
                else
                {
                    dytbl += "<td   class=display align='center'></td>";
                   // dytbl += "<td   class=display align='center'></td>";
                    if (ds4.Tables[0].Rows[0]["Ins.Date"].ToString() != "")
                    {
                        dytbl += "<td  class=display  align='center' >" + ds4.Tables[0].Rows[0]["Ins.Date"].ToString() + "</td>";
                    }
                    else
                        dytbl += "<td   class=display align='center'>**/**/****</td>";

                    dytbl += "<td   align='center' class=display>" + ds4.Tables[0].Rows[0]["Volume"].ToString() + "</td>";
                    maxword = Convert.ToInt32(ds4.Tables[0].Rows[0]["Volume"].ToString());
                    if (ds4.Tables[0].Rows[0]["premiumname"].ToString() != "" && ds4.Tables[0].Rows[0]["premiumname"].ToString() != null)
                    {
                        dytbl += "<td   class=display align='right' >" + ds4.Tables[0].Rows[0]["premiumname"].ToString() + "</td>";

                    }
                    else
                        dytbl += "<td  class=display align='right'>---</td>";

                    if (ds4.Tables[0].Rows[0]["premiumch"].ToString() != "" && ds4.Tables[0].Rows[0]["premiumch"].ToString() != null)
                    {
                        dytbl += "<td   class=display align='right' >" + ds4.Tables[0].Rows[0]["premiumch"].ToString() + "</td>";

                    }
                    else
                        dytbl += "<td  class=display align='right'></td>";




                    string col = ds4.Tables[0].Rows[0]["Hue"].ToString();
                    col = col.Substring(0, 3);
                    string col1 = col;
                    col1 = col1.Substring(0, 1);
                    if (col1 == "B")
                    {
                        col = "B / W";
                    }
                    dytbl += "<td   align='center' class=display>" + col + "</td>";

                    //for min word
                    if (ds4.Tables[0].Rows[0]["MIN_WORD"].ToString() != "")
                    {
                        dytbl += "<td   class=display align='center' >" + ds4.Tables[0].Rows[0]["MIN_WORD"].ToString() + "</td>";
                        minword = Convert.ToInt32(ds4.Tables[0].Rows[0]["MIN_WORD"].ToString());

                    }
                    else
                        dytbl += "<td  class=display align='center'></td>";

                    if (ds4.Tables[0].Rows[0]["Card_Rate"].ToString() != "")
                    {
                        //dytbl += "<td   class=display align='center' >" + ds4.Tables[0].Rows[0]["Card_Rate"].ToString() + "</td>";
                        dytbl += "<td   class=display align='center' >" + ds4.Tables[0].Rows[0]["package rate"].ToString() + "</td>";

                    }
                    else
                        dytbl += "<td  class=display align='center'></td>";
                    //for extra word
                    if (maxword > minword)
                    {
                        extraword = maxword - minword;
                        if (ds4.Tables[0].Rows[0]["EXTRA_RATE"].ToString() != null && ds4.Tables[0].Rows[0]["EXTRA_RATE"].ToString() != "")
                            extrarate = Convert.ToDouble(ds4.Tables[0].Rows[0]["EXTRA_RATE"].ToString());
                        dytbl += "<td   class=display align='center' >" + (extraword).ToString() + "</td>";
                        //for extra rate
                        dytbl += "<td    align='right' class='display1'>" + extrarate.ToString() + "</td>";
                        dytbl += "<td   class=display align='center' >" + (extraword * extrarate).ToString() + "</td>";

                    }
                    else
                    {
                        dytbl += "<td  class=display align='center'>0</td>";
                        //for extra rate
                        dytbl += "<td    align='right' class='display1'></td>";
                        dytbl += "<td  class=display align='center'>0</td>";
                    }
                }



              

                if (ds4.Tables[0].Rows[0]["Disc"].ToString() != "" && ds4.Tables[0].Rows[0]["Disc"].ToString() != null)
                {
                    dytbl += "<td   class=display align='right' >" + ds4.Tables[0].Rows[0]["Disc"].ToString() + "</td>";

                }
                else
                    dytbl += "<td  class=display align='right'></td>";

                dytbl += "<td    align='right' class='display1'>" + packagegrossamt + "</td>";

                dytbl += "</tr>";

                if (ds4.Tables[0].Rows[0]["Ad_type_code"].ToString() == "DI0" || ds4.Tables[0].Rows[0]["Uom_code"].ToString() == "CL0")
                {
                    //FOR EDITION PART
                    for (int k = 0; k < ds4.Tables[2].Rows.Count; k++)
                    {
                        dytbl += "<tr>";
                        dytbl += "<td    align='left' class='display'></td>";

                        if (ds4.Tables[2].Rows[k]["Edition"].ToString() != "" && ds4.Tables[2].Rows[k]["Edition"].ToString() != "")
                        {
                            dytbl += "<td  class=display  align='center' >" + ds4.Tables[2].Rows[k]["Edition"].ToString() + "</td>";

                        }


                        if (ds4.Tables[2].Rows[k]["Ins.Date"].ToString() != "")
                        {
                            dytbl += "<td  class=display  align='center' >" + ds4.Tables[2].Rows[k]["Ins.Date"].ToString() + "</td>";
                        }
                        else
                            dytbl += "<td   class=display align='center'>**/**/****</td>";

                        dytbl += "<td    align='left' colspan='10' class='display'></td>";

                        dytbl += "</tr>";
                    }
                }
                
                

                srl++;

            }

            dytbl += "</table>";

            dynamictable.Text = dytbl;

            //double amountprem = amt4 * (premiumper1 / 100);
            //lbl_gross.Text = amt5.ToString();
            //amountprem = amt4 + amountprem - (spcharges + spdes);
            //double disper1 = amountprem * (dispr / 100);
            //add_ag_dis = amt5 * add_ag_dis / 100;
            //amt5 = amt5 - add_ag_dis;
            //traddis = amt5 * traddis / 100;

            //lbl_trade.Text = traddis.ToString("F2");
            //lbl_add.Text = add_ag_dis.ToString("F2");
            //lbl_extra.Text = (adddis + adddis).ToString("F2");
            //bill_amt1 = bill_amt1 + 0.01;
           //===========*************=================//
            lbl_gross.Text = Insertgrossamt.ToString("F2");
            //amountprem = amt4 + amountprem - (spcharges + spdes);
            //double disper1 = amountprem * (dispr / 100);
            add_ag_dis = Insertgrossamt * add_ag_dis / 100;
            Insertgrossamt = Insertgrossamt - add_ag_dis;
            lbl_tradisper.Text = traddis.ToString()+"%";
            traddis = Insertgrossamt * traddis / 100;

            lbl_trade.Text = traddis.ToString("F2");
            lbl_add.Text = add_ag_dis.ToString("F2");
            lbl_extra.Text = (adddis + addchr).ToString("F2"); //(adddis + adddis).ToString("F2");

            if (ds4.Tables[0].Rows[0]["Bullet_Charges"].ToString() != "")
            {
                bulletcrg = Convert.ToDouble(ds4.Tables[0].Rows[0]["Bullet_Charges"].ToString());
            }
            if (ds4.Tables[0].Rows[0]["BOXCHARGE"].ToString() != "")
            {
                boxchrg = Convert.ToDouble(ds4.Tables[0].Rows[0]["BOXCHARGE"].ToString());
            }
            lbl_box.Text = boxchrg.ToString("F2");
            lblbullet.Text = bulletcrg.ToString("F2");
            lbltranslation.Text = transcrg.ToString("F2");

            bill_amt1 = bill_amt1 + 0.01;
            double amountinckudingbox1 = Math.Round(bill_amt1);
            lbl_net.Text = amountinckudingbox1.ToString();

            NumberToEngish obj = new NumberToEngish();
            lbwordinrupees.Text = obj.changeNumericToWords(lbl_net.Text.ToString()) + "Only";

           
            if (packlength == c1)
            {
                DataSet dssave = new DataSet();
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

        }

    }
}