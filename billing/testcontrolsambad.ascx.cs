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

public partial class testcontrolsambad : System.Web.UI.UserControl
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
    public testcontrolsambad()
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
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();


        ds.ReadXml(Server.MapPath("XML/bill_sambad.xml"));
        lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();        
        lbscheme.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbnumber.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbordernumber.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();        
        lbpackagerate.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();      
        lblamount.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        lbltotal.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        lblbox.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        lblnet.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        lbformatproposal.Text = ds.Tables[0].Rows[0].ItemArray[60].ToString();
        lbinsertionnumber.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
        lbpanno.Text = ds.Tables[0].Rows[0].ItemArray[31].ToString();
        lbproductkey.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();
        lbrupee.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        lbpub.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        lbto.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        lbpackagena.Text = ds.Tables[0].Rows[0].ItemArray[38].ToString();
        lbvat.Text = ds.Tables[0].Rows[0].ItemArray[39].ToString();
        lbeduca.Text = ds.Tables[0].Rows[0].ItemArray[40].ToString();      
        lbservice.Text = ds.Tables[0].Rows[0].ItemArray[41].ToString();
        lbheadoffice.Text = ds.Tables[0].Rows[0].ItemArray[43].ToString();  
        lbpremium.Text = ds.Tables[0].Rows[0].ItemArray[46].ToString();
        lbextrach.Text = ds.Tables[0].Rows[0].ItemArray[47].ToString();
        lbltrade.Text = ds.Tables[0].Rows[0].ItemArray[48].ToString();
        lbgr.Text = ds.Tables[0].Rows[0].ItemArray[49].ToString();
        lbtdper.Text = ds.Tables[0].Rows[0].ItemArray[50].ToString();
        lbtrade1.Text = ds.Tables[0].Rows[0].ItemArray[51].ToString();
        remark.Text = ds.Tables[0].Rows[0].ItemArray[65].ToString();
        txtpan.Text = ds.Tables[0].Rows[0].ItemArray[64].ToString();




    }

    public void setcard()
    {



        GC.Collect();

        String dytbl;
        dytbl = "";

        dytbl += "<table width='500px'align='left' cellpadding='0' cellspacing='0'>";
        {
            DataSet dsb = new DataSet();
            dsb.ReadXml(Server.MapPath("XML/bill_sambad.xml"));
            dytbl += "<tr align=center >";
            dytbl += "<td class='insertiontxtclass12' align='center' width='150px' >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass12' align='center' width='70px'>" + dsb.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass12' align='center'  width='5px' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass12'  align='center'  width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass12'  align='center'  width='32px' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass12'  align='center'  width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass12'  align='center'  width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass12'  align='center'  width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[53].ToString() + "</td>";
            dytbl += "</tr>";
        }








        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double finalamount = 0;
        double discountint = 0;
        int totinsertnewint = 0;
        double amountinckudingboxbill = 0.01;

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

     
            txtpackname.Text = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
            ds3.Dispose();

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

            if (ds4.Tables[0].Rows[0]["paydate"].ToString() != "")
            {
                Label17.Text = ds4.Tables[0].Rows[0]["paydate"].ToString() + ". (Int. @ 2% will be charged after payable by date)";
            }
            else
            {
                Label17.Text = ds4.Tables[0].Rows[0]["paydatesys"].ToString() + ". (Int. @ 2% will be charged after payable by date)";
            }

            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/bill.xml"));
          
            int stcou = ds4.Tables[0].Rows[0].ItemArray[1].ToString().Length;
            if (stcou > 5)
            {
                stcou = 6;
            }
            Label16.Text = ds4.Tables[0].Rows[0]["Email"].ToString();      
            rono.Text = ds4.Tables[0].Rows[0].ItemArray[8].ToString();
            agencytxt.Text = ds4.Tables[0].Rows[0].ItemArray[1].ToString();
            if (agencytxt.Text.Substring(0, stcou) == "DIRECT")
            { agencytxt.Text = ""; }
      
            pubtxt.Text = ds4.Tables[0].Rows[0].ItemArray[2].ToString();
         


            amtdisc.Text = ds4.Tables[0].Rows[0].ItemArray[10].ToString();
            if (amtdisc.Text == "")
            { }
            else
            {

                double disc = Convert.ToDouble(amtdisc.Text);
            }

            //================
            if (ds4.Tables[0].Rows[0].ItemArray[1].ToString().Substring(0, stcou) != "DIRECT")
            {
                lbnewad.Text = ds4.Tables[0].Rows[0]["Add2"].ToString();
                lbnewad2.Text = ds4.Tables[0].Rows[0]["Add3"].ToString();
            }
            else
            {
                lbnewad.Text = "";
                lbnewad2.Text = "";
            }
            //====================

            lbclientna.Text = ds4.Tables[0].Rows[0].ItemArray[26].ToString();
            if (ds4.Tables[0].Rows[0].ItemArray[25].ToString() != "NATIONAL")
            {
            }
            else
            {
                lbclientadd.Text = ds4.Tables[0].Rows[0].ItemArray[25].ToString();
            }

            
            if (ds4.Tables[0].Rows[0].ItemArray[1].ToString().Substring(0, stcou) != "DIRECT")
            {
                agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[19].ToString();
            }
            else
            {
                agddxt.Text = "";
            }

            rupeetxt.Text = ds4.Tables[0].Rows[0].ItemArray[18].ToString();
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
                boxcharges1.Text = bx2.ToString("F2");


            }

            insertiontxt.Text = insertion.ToString();
            txtinvoice.Text = invoiceno.ToString();

             
           
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

            txtpackname.Text = packna.ToString();

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

            string bukingdate = bookingdate;
            if (bukingdate != "")
            {

                orderno.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString() + "-" + bukingdate;
            }
            else
            {
                orderno.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString();
            }        
            string rono1 = orderno1.ToString();
            string rodate = orderdate.ToString();
            if (rodate != "" && rono1 != "")
            {
                rono.Text = rono1 + rodate;
            }
            rono.Text = rono1 + " - " + rodate;




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
            ds4.Dispose();
            GC.Collect();
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

                //
                lbhead2.Text = ds4.Tables[0].Rows[0].ItemArray[36].ToString();
                string phone1 = ds4.Tables[0].Rows[0].ItemArray[37].ToString();              
                Label1.Text = phone1 + "-" + ds4.Tables[0].Rows[0].ItemArray[38].ToString();
                Label3.Text = phone1 + "-" + ds4.Tables[0].Rows[0].ItemArray[39].ToString();            
                format.Text = ds4.Tables[0].Rows[0].ItemArray[40].ToString();
                txtgroup.Text = ds4.Tables[0].Rows[0]["Cap"].ToString();
                string amt = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
                string boxcharges = ds4.Tables[0].Rows[0].ItemArray[21].ToString();
                double amt1 = 0;
                if (amt != "")
                {
                    amt1 = Convert.ToDouble(amt);
                }


                /////////

               
                if(ds4.Tables[0].Rows[0]["Bill_Amt"].ToString()!="")
               amountinckudingboxbill = amountinckudingboxbill + Convert.ToDouble(ds4.Tables[0].Rows[0]["Bill_Amt"].ToString());


               
                string package_rate = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
                string premiumper2 = ds4.Tables[0].Rows[0].ItemArray[34].ToString();
                if (package_rate != "")
                {
                    packrate = Convert.ToDouble(package_rate);
                   
                    packrate1 = packrate;
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


                lbpack.Text = packrate1.ToString();








                string discountstr = ds4.Tables[0].Rows[0].ItemArray[10].ToString();
                if (discountstr != "")
                    discountint = Convert.ToDouble(discountstr);
                else
                    discountint = Convert.ToInt16(0);


                runtxt.Text = ds4.Tables[0].Rows[0].ItemArray[28].ToString();
                /////////////////////////////////////////////////////////////////////////////////


                dytbl += "<tr>";
                dytbl += "<td width=50px   align=left >" + ds4.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                //dytbl += "<td width=49px   align=center >" + ds4.Tables[0].Rows[0].ItemArray[15].ToString() + "</td>";
                if (ds4.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                {
                    dytbl += "<td width=32px  align=center >" + ds4.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td width=32px  align=center>---</td>";
                }
                if (ds4.Tables[0].Rows[0].ItemArray[4].ToString() != "")
                {
                    dytbl += "<td width=40px  align=center>" + ds4.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                }
                else
                {
                    dytbl += "<td width=40px  align=center>---</td>";
                }
                dytbl += "<td width=60px  align=center>" + ds4.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                dytbl += "<td width=60px  align=left>" + ds4.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>";
               //for page no.
                if (ds4.Tables[0].Rows[0].ItemArray[29].ToString() != "")
                {
                    dytbl += "<td width=80px  align=center >" + ds4.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>";
                }
                else
                    dytbl += "<td width=80px  align=center>---</td>";
                //end for page no

                if (ds4.Tables[0].Rows[0].ItemArray[30].ToString() != "")
                    dytbl += "<td width=76px  align=left>" + ds4.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";
                else
                    dytbl += "<td width=76px  align=left>---</td>";


                if (ds4.Tables[0].Rows[0].ItemArray[34].ToString() != "")

                    dytbl += "<td width=35px  align=center>" + ds4.Tables[0].Rows[0].ItemArray[34].ToString() + "</td>";
                else
                    dytbl += "<td width=35px  align=center>---</td>";

                dytbl += "</tr>";



            }



            dytbl += "</table>";




            dynamictable.Text = dytbl;


            double amountprem = amt4 * (premiumper1 / 100);
            txtprem.Text = amountprem.ToString();
            txch.Text = ds4.Tables[0].Rows[0].ItemArray[32].ToString();
            amtdisc.Text = ds4.Tables[0].Rows[0].ItemArray[31].ToString();
            txtper.Text = ds4.Tables[0].Rows[0].ItemArray[33].ToString();




            if (txch.Text == "")
            {
                txch.Text = "0";
            }
            if (amtdisc.Text == "")
            {
                amtdisc.Text = "0";
            }

            if (txch.Text != "")
            {
                spcharges = Convert.ToDouble(txch.Text);
            }
            if (amtdisc.Text != "")
            {
                spdes = Convert.ToDouble(amtdisc.Text);
            }


            if (txtper.Text != "")
            {
                dispr = Convert.ToDouble(txtper.Text);
            }
            double amtspe = amt4 + spdes;
            amount1.Text = amtspe.ToString("F2");
            amountprem = amt4 + amountprem + spcharges; //-( spdes);


            string extdis = amtdisc.Text;
            double extdiscount = Convert.ToDouble(extdis);
            double extdisper = 0;
            if (ds4.Tables[0].Rows[0]["addcom"].ToString() != "")
                extdisper = Convert.ToDouble(ds4.Tables[0].Rows[0]["addcom"].ToString());
            ds4.Dispose();
            double extaddcom = 0;
            extaddcom = (amtspe * extdisper) / 100;
            double totextaddcom = extdiscount + extaddcom;
            amtdisc.Text = Convert.ToString(totextaddcom);
            ///============end here================
            amountprem = amountprem - totextaddcom;

            
            txtgr.Text = amountprem.ToString("F2");
            double disper1 = amountprem * (dispr / 100);
            txtdiscal.Text = disper1.ToString();
            //break;


            ///////////



            //amountinckudingbox = amountprem + boxchg1 + disper1;  //comment by gaurav in sambad
            amountinckudingbox = amountprem + boxchg1 - disper1;
            txttotal.Text = amountinckudingbox.ToString();




          /*




            double amountforvat1 = 0;
            DataSet dsvat = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                //NewAdbooking.Classes.Class1 objvat = new NewAdbooking.Classes.Class1();
                //dsvat = objvat.vatrate(bookingdate, Session["compcode"].ToString(), Session["dateformat"].ToString ());
            }
            else
            {
                string[] bookingdate1 = bookingdate.Split(' ');
                NewAdbooking.BillingClass.classesoracle.billing_save objvat = new NewAdbooking.BillingClass.classesoracle.billing_save();

                dsvat = objvat.vatrate(bookingdate1[0], Session["compcode"].ToString(), Session["dateformat"].ToString());

            }
            int count = dsvat.Tables[1].Rows.Count;
            int vat2 = 0;
            double vrate = 0;
            for (vat2 = 0; vat2 < count; vat2++)
            {
                string vatrate = dsvat.Tables[1].Rows[vat2].ItemArray[1].ToString();
                double vatrate1 = Convert.ToDouble(vatrate);
                vrate = amountinckudingbox * vatrate1 / 100;
                if (vat2 == 0)
                {

                    double vrate2 = Math.Round(vrate);
                    lblamt.Text = vrate2.ToString();
                }
                else
                    if (vat2 == 1)
                    {
                        double vrate2 = Math.Round(vrate);
                        lbled.Text = vrate2.ToString();
                    }
                    else
                    {
                        double vrate2 = Math.Round(vrate);
                        lblser.Text = vrate2.ToString();
                    }



                amountinckudingbox = amountinckudingbox + vrate;




            }
             
            ///////////////////////////////////////////////////////////////////////////////////////////////
            */


           

          


            double amountinckudingbox1 = Math.Round(amountinckudingbox);

            netpay.Text = amountinckudingbox1.ToString();
            netacc.Text = amountinckudingbox1.ToString();


            NumberToEngish obj = new NumberToEngish();

            rupeetxt.Text = obj.changeNumericToWords(amountinckudingbox1.ToString()) + "Only";

            Label10.Text = "4)All disputes are Subject to " + qbc + " Jurisdiction.";

            //==================================
           DataSet dssave = new DataSet();

            //if (packlength == c1)
            //{



                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

             //  NewAdbooking.BillingClass.Classes.billing_save objsave = new NewAdbooking.Classes.billing_save();            
               NewAdbooking.BillingClass.Classes.billing_save objabc = new NewAdbooking.BillingClass.Classes.billing_save();
               dssave = objabc.updatebillprintstatus(txtinvoice.Text);
                }
            //    else
            //    {
            //        //       NewAdbooking.BillingClass.classesoracle.billing_save objabc = new NewAdbooking.classesoracle.billing_save();
            //        NewAdbooking.BillingClass.classesoracle.billing_save objabc = new NewAdbooking.BillingClass.classesoracle.billing_save();
            //      //  dssave = objabc.updatebillprintstatus(txtinvoice.Text);


            //    }

            //}

           // String countBILS = dssave.Tables[0].Rows[0].ItemArray[0].ToString();
            //if (countBILS == "1")
            //{
            //    pagestatus.Text = "ORIGINAL".ToString();
            //}
            //else
            //{
            //    pagestatus.Text = "DUPLICATE".ToString();
            //}

            //==================================


        }
    }
}