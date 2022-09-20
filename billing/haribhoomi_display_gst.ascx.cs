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

public partial class haribhoomi_display_gst : System.Web.UI.UserControl
{

    string imagepath = "";
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
    public string _unit;
    public string _divid;
    public string _chkvalue_length;
    public string _tbl_id;
    public string _trade_disc;
    public haribhoomi_display_gst()
    {
        _tbl_id = "";
        _unit = "";
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
        _trade_disc = "";
        _chkvalue_length = "";
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
    public string chkvalue_length { get { return _chkvalue_length; } set { _chkvalue_length = value; } }
    public string trade_disc { get { return _trade_disc; } set { _trade_disc = value; } }
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/hari_classified_last.xml"));
        //lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        //lblcap.Text = "Caption";// ds.Tables[0].Rows[0].ItemArray[72].ToString();
        lblrefno.Text = ds.Tables[0].Rows[0].ItemArray[70].ToString();
        //lblagencyname.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbladd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblkey.Text = ds.Tables[0].Rows[0].ItemArray[68].ToString();
        lb_total.Text = ds.Tables[0].Rows[0].ItemArray[66].ToString();
        lbtrade1.Text = ds.Tables[0].Rows[0].ItemArray[53].ToString();
        Label16.Text = ds.Tables[0].Rows[0].ItemArray[77].ToString();
        Label20.Text = ds.Tables[0].Rows[0].ItemArray[78].ToString();
        Label24.Text = ds.Tables[0].Rows[0].ItemArray[79].ToString();
        Label28.Text = ds.Tables[0].Rows[0].ItemArray[80].ToString();
        //lblbilldt.Text = ds.Tables[0].Rows[0].ItemArray[71].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[58].ToString();
        //publ.Text = ds.Tables[0].Rows[0].ItemArray[73].ToString();
        //hribhomi_text.Text = ds.Tables[0].Rows[0].ItemArray[75].ToString();





        //if (prtype == "agencyroaudit")
        //{
        //    btnPrev.Text = "Audit";

        //    tit.Text = "Agency Ro Audit";
        //    cap = "Agency Ro Audit";

        //}
        //else
        //{
        //    btnPrev.Text = "Proof";
        //    tit.Text = "ProofReading";
        //    cap = "ProofReading";

        //}



        //  splchagr.Text = ds.Tables[0].Rows[0].ItemArray[76].ToString();

    }

    public void setcard()
    {
        string day = "", month = "", year = "", date = "", street = "", packagecode11 = packagecode.ToString(), ciobookingid = id.ToString(), editionname = "", i12 = insertion.ToString(), ediplusdate = "", path = "",
               clientadd = "", compname = "", compname25 = "", rev = "", revenu = "", revenu25 = "", Agrred_rate = "0", GAamt1 = "0", packna = "", edicode = "", bukingdate = "", rono1 = "", rodate = "", editionnametest = "", sub_serv_acc_code = "" ;
        string[] packagecode1_tot = packagecode11.Split(','), packagecode1 = packagecode11.Split(','), editionnamenew, addname, editionnametest1;
        int totinsertnewint = 0, count11 = Convert.ToInt16(insertion), packlength22 = Convert.ToInt16(packagelength), srl = 1, packlength = 0, packlength1 = 0, totinsert = Convert.ToInt16(totalinsertion),
            c1 = packagecode1.Length, c1_total = packagecode1.Length, packlength_total = 0, editionlen = 0, counteditin = 0, maxlimit = 17, j, je, counteditioncode = 0, counted = 0, i;
        double finalamount = 0, discountint = 0, grossamt = 0, traddis = 0, adddis = 0, addchr = 0, finalamount1 = 0, amt5, disc = 0.00, sp_disc_per = 0, BILL_AMT21 = 0, volume_total = 0, package_total = 0,
               bill_amt = 0, bill_amt1 = 0, amt2 = 0, amt3 = 0, amt4 = 0, amountinckudingbox = 0, packrate = 0, packrate1 = 0, premiumper = 0, premiumper1 = 0, spcharges = 0, spdes = 0, dispr = 0, trate = 0, tgamt = 0,
               volume = 0, height1 = 0, width1 = 0, ext = 0, grs = 0, totalam = 0, Disc = 0, boxchg1 = 0, boxchg2 = 0;
        float ht = 40;
        String dytbl = "";
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet(); DataSet ds = new DataSet();
        DataSet dsbranch = new DataSet();
        DataSet ds5 = new DataSet();
        double amtcommdis = 0, agreedamt = 0, discamt = 0, addagency = 0, spldisc = 0, agreedamt1 = 0, disc1 = 0, discamt1 = 0, addagency1 = 0, spldisc1 = 0, splamt = 0, splamt32 = 0
        , splgrossamt = 0, addpremamt = 0, addpremamt32 = 0, addpremgrossamt32 = 0, cardamt = 0;




        //====================================

        //for (packlength_total = 0; packlength_total < c1_total; packlength_total++)
        //{
        dytbl = "";
        dytbl += "<table width='690px' align='left' cellpadding='5' cellspacing='0' >";
        {
            DataSet dsb = new DataSet();
            dsb.ReadXml(Server.MapPath("XML/hari_classified_last.xml"));
            dytbl += "<tr align='center'>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='10px' >" + dsb.Tables[0].Rows[0].ItemArray[64].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='150px' >" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='150px' >" + dsb.Tables[0].Rows[0].ItemArray[59].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='left'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</br>" + "H*W" + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[65].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + "Color"/*.Tables[0].Rows[0].ItemArray[76].ToString()*/ + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>";
            //dytbl += "<td class='insertiontxtclass1'  align='center'  width='10px' >" + dsb.Tables[0].Rows[0].ItemArray[74].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[69].ToString() + "</td>";
            //  dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[67].ToString() + "</td>";
            dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[66].ToString() + "</td>";
            dytbl += "</tr>";
        }

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
            ds3 = objedition.edition(packagecode1_tot[packlength_total], Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.invoice objedition = new NewAdbooking.BillingClass.classesoracle.invoice();
            ds3 = objedition.edition(packagecode1[packlength_total], Session["compcode"].ToString());

        }
        else
        {
            string[] parameterValueArray = new string[] { packagecode1[packlength_total], Session["compcode"].ToString() };
            string procedureName = "websp_selectedition";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds3 = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.invoice shtr = new NewAdbooking.BillingClass.classesoracle.invoice();
            ds5 = shtr.bindaddress(Session["compcode"].ToString(), Session["center"].ToString(), "", "");


        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.invoice shtr = new NewAdbooking.BillingClass.Classes.invoice();
            ds5 = shtr.bindaddress(Session["compcode"].ToString(), Session["center"].ToString(), "", "");

        }
         else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["center"].ToString(), "", "" };
            string procedureName = "adgetbindaddress";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds5 = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        for (i = 0; i < ds3.Tables[0].Rows.Count; i++)
        {
            editionnametest = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
            //==================================
            editionnametest1 = editionnametest.Split('+');
            int len = editionnametest1.Length;
            if (len == 1)
            {
                editionname = editionnametest1[0];
            }
            counted = editionnametest1.Length;
            if (counted > 1)
            {
                c1 = counted;
                packagecode1 = editionnametest.Split('+');
            }

            packlength1 = packlength;
            if (len == 1)
            {
                c1 = 1;
            }

            for (packlength = 0; packlength < c1; packlength++)
            {
                if (counted <= 1)
                {
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
                        //ds3 = objedition.edition(packagecode1[packlength], Session["compcode"].ToString());
                        ds3 = objedition.edition(packagecode11, Session["compcode"].ToString());
                        //editionname = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {

                        NewAdbooking.BillingClass.classesoracle.invoice objedition = new NewAdbooking.BillingClass.classesoracle.invoice();
                        //ds3 = objedition.edition(packagecode1[packlength], Session["compcode"].ToString());
                        ds3 = objedition.edition(packagecode11, Session["compcode"].ToString());
                        if (len > 1)
                        {
                            editionname = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                        }
                    }
                    else
                    {
                        string[] parameterValueArray = new string[] { packagecode11, Session["compcode"].ToString() };
                        string procedureName = "websp_selectedition";
                        NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                        ds3 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                        if (len > 1)
                        {
                            editionname = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                        }

                    }

                }
                else
                {
                    editionname = packagecode1[packlength];
                }

                c1_total = 1;

                ds4.Dispose();
                GC.Collect();
                for (packlength1 = 0; packlength1 < c1_total; packlength1++)
                {
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.BillingClass.Classes.invoice objvalues = new NewAdbooking.BillingClass.Classes.invoice();
                        // ds4 = objvalues.values_bill(ciobookingid, editionname, i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                        ds4 = objvalues.values_bill_rj(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString(), invoiceno, "N");
                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.BillingClass.classesoracle.invoice objvalues = new NewAdbooking.BillingClass.classesoracle.invoice();
                       // ds4 = objvalues.values_bill_rj(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString(), invoiceno, "N");
                        // shubham chk here that orcl filE Not updated properly
                    }
                    else
                    {
                        string[] parameterValueArray = new string[] { ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString(), invoiceno, "N" };
                        string procedureName = "websp_selectvaluesnew_rj";
                        NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                        ds4 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                       

                    }

                    adcat.Text = ds4.Tables[0].Rows[0].ItemArray[13].ToString();
                    lbookid.Text = ds4.Tables[0].Rows[0]["cioid"].ToString();
                    ds.ReadXml(Server.MapPath("XML/bill.xml"));
                    path = "Images/" + ds.Tables[1].Rows[0].ItemArray[1].ToString();
                    if (System.IO.File.Exists(Server.MapPath(path)))
                    {
                        //divimg.InnerHtml = "<img src='" + path + "' height='" + ht + "'>";
                    }
                    // agddxt.Text = ds4.Tables[0].Rows[0].ItemArray[1].ToString();
                    ////////////////////

                    sub_serv_acc_code = ds4.Tables[0].Rows[0]["sub_serv_acc_code"].ToString();
                    if (ds4.Tables[0].Rows[0]["bill2"].ToString() == "" || ds4.Tables[0].Rows[0]["bill2"].ToString() == null)
                    {
                        agddxt.Text = ds4.Tables[0].Rows[0]["Agency"].ToString();
                        agencyaddtxt.Text = ds4.Tables[0].Rows[0]["add1"].ToString() + "</br>" + ds4.Tables[0].Rows[0]["add2"].ToString() + "</br>" + ds4.Tables[0].Rows[0]["add3"].ToString() + "</br>"
                        + ds4.Tables[0].Rows[0]["city_name1"].ToString() + "-" + ds4.Tables[0].Rows[0]["zip"].ToString() + "</br>" + ds4.Tables[0].Rows[0]["ag_stae_name"].ToString();
                        //  lbltextmain.Text = "Agency";
                        if (sub_serv_acc_code == "null" || sub_serv_acc_code == "")
                        {
                            lblagencycode.Text = " PAN -" + ds4.Tables[0].Rows[0]["PANNO"].ToString() + "</BR>" +  " SAC_CODE -" + ds4.Tables[0].Rows[0]["serv_acc_NM"].ToString() +  "</BR>" + " SUB_SAC_CODE -" + ds4.Tables[0].Rows[0]["sub_serv_acc_nm"].ToString();// +",     TAN -" + ds4.Tables[0].Rows[0]["TAN_no"].ToString();
                        }
                        else
                        {
                            lblagencycode.Text = " PAN -" + ds4.Tables[0].Rows[0]["PANNO"].ToString() + "</BR>" +  " SAC_CODE -" + ds4.Tables[0].Rows[0]["serv_acc_NM"].ToString() +  "</BR>" + " SUB_SAC_CODE -" + ds4.Tables[0].Rows[0]["sub_serv_acc_nm"].ToString();// +",     TAN -" + ds4.Tables[0].Rows[0]["TAN_no"].ToString();
                        }
                    }
                    else
                    {
                        if (ds4.Tables[0].Rows[0]["agenadd"].ToString() != "")
                        {
                            addname = ds4.Tables[0].Rows[0]["agenadd"].ToString().Split("$$".ToCharArray());

                            agencyaddtxt.Text = addname[0] ;//+ "</br>" + addname[2] + "</br>" + addname[4] + "</br>" + addname[8] + "-" + addname[12] + "</br>" + addname[10];
                            if (ds4.Tables[0].Rows[0]["agenadd"].ToString() == "")
                                agddxt.Text = "(" + ds4.Tables[0].Rows[0]["agency_sub_code"].ToString() + ")" + ds4.Tables[0].Rows[0]["Agency"].ToString();
                            else
                                agddxt.Text = ds4.Tables[0].Rows[0]["Agency"].ToString();//addname[0];

                            if (sub_serv_acc_code == "null" || sub_serv_acc_code == "")
                            {
                                lblagencycode.Text = " PAN -" + ds4.Tables[0].Rows[0]["PANNO"].ToString() + "</BR>" +  " SAC_CODE -" + ds4.Tables[0].Rows[0]["serv_acc_NM"].ToString() +  "</BR>" + " SUB_SAC_CODE -" + ds4.Tables[0].Rows[0]["sub_serv_acc_nm"].ToString();// +",     TAN -" + ds4.Tables[0].Rows[0]["TAN_no"].ToString();
                            }
                            else
                            {
                                lblagencycode.Text = " PAN -" + ds4.Tables[0].Rows[0]["PANNO"].ToString() + "</BR>" +  " SAC_CODE -" + ds4.Tables[0].Rows[0]["serv_acc_NM"].ToString() +  "</BR>" + " SUB_SAC_CODE -" + ds4.Tables[0].Rows[0]["sub_serv_acc_nm"].ToString();// +",     TAN -" + ds4.Tables[0].Rows[0]["TAN_no"].ToString();
                            }
                        }
                        else
                        {
                            agencyaddtxt.Text = ds4.Tables[0].Rows[0]["add1"].ToString() + "</br>" + ds4.Tables[0].Rows[0]["add2"].ToString() + "</br>" + ds4.Tables[0].Rows[0]["add3"].ToString() + "</br>"
                                + ds4.Tables[0].Rows[0]["city_name1"].ToString() + "-" + ds4.Tables[0].Rows[0]["zip"].ToString() + "</br>" + "State/UT:" + ds4.Tables[0].Rows[0]["ag_stae_name"].ToString() + "</br>" + "State/UT Code:" + ds4.Tables[0].Rows[0]["ag_GST_STATE_CODE"].ToString()
                                + "</br>" + "GSTIN/Unique ID:" + ds4.Tables[0].Rows[0]["AG_GSTIN"].ToString();

                            agddxt.Text = ds4.Tables[0].Rows[0]["Agency"].ToString();// +"(" + ds4.Tables[0].Rows[0]["agency_sub_code"].ToString() + ")";

                            if (sub_serv_acc_code == "null" || sub_serv_acc_code == "")
                            {
                                lblagencycode.Text = " PAN -" + ds4.Tables[0].Rows[0]["PANNO"].ToString() + "</BR>" +  " SAC_CODE -" + ds4.Tables[0].Rows[0]["serv_acc_NM"].ToString() +  "</BR>" + " SUB_SAC_CODE -" + ds4.Tables[0].Rows[0]["sub_serv_acc_nm"].ToString();// +",     TAN -" + ds4.Tables[0].Rows[0]["TAN_no"].ToString();
                            }
                            else
                            {
                                lblagencycode.Text = " PAN -" + ds4.Tables[0].Rows[0]["PANNO"].ToString() + "</BR>" + " SAC_CODE -" + ds4.Tables[0].Rows[0]["serv_acc_NM"].ToString() +  "</BR>" + " SUB_SAC_CODE -" + ds4.Tables[0].Rows[0]["sub_serv_acc_nm"].ToString();// +",     TAN -" + ds4.Tables[0].Rows[0]["TAN_no"].ToString();
                            }
                        }
                    }

                    if (ds4.Tables[0].Rows[0]["ClientAd"].ToString() != "")
                    {
                        clientadd = ds4.Tables[0].Rows[0]["ClientAd"].ToString();
                    }
                    else
                    {
                        clientadd = "";
                    }
                    if (ds4.Tables[0].Rows[0]["Agency"].ToString() == "DIRECT PARTY")
                    {
                        agddxt.Text = ds4.Tables[0].Rows[0]["Client"].ToString() + "</br>" + clientadd.ToString();
                    }
                    if (agddxt.Text == ds4.Tables[0].Rows[0]["Agency"].ToString())
                    {
                        lbladrelpar.Text = "Client";
                        lbladrelpar.Text = "Client";
                        if (ds4.Tables[0].Rows[0]["Bill_remarks"].ToString() != "")
                        {
                            txtcliname.Text = ds4.Tables[0].Rows[0]["Bill_remarks"].ToString();
                        }
                        else
                        {
                            txtcliname.Text = ds4.Tables[0].Rows[0]["Client"].ToString();
                        }
                    }
                    else if (agddxt.Text == ds4.Tables[0].Rows[0]["Client"].ToString())
                    {
                        lbladrelpar.Text = "Agency";
                        txtcliname.Text = "(" + ds4.Tables[0].Rows[0]["agency_sub_code"].ToString() + ")" + ds4.Tables[0].Rows[0]["Agency"].ToString();
                    }
                    else
                    {
                        lbladrelpar.Text = "Client";
                        if (ds4.Tables[0].Rows[0]["Bill_remarks"].ToString() != "")
                        {
                            txtcliname.Text = ds4.Tables[0].Rows[0]["Bill_remarks"].ToString();
                        }
                        else
                        {
                            txtcliname.Text = ds4.Tables[0].Rows[0]["Client"].ToString();
                        }

                    }
                    if (ds4.Tables[0].Rows[0]["Agency"].ToString() == "DIRECT PARTY")
                    {
                        lbladrelpar.Text = "Agency";
                        txtcliname.Text = "(" + ds4.Tables[0].Rows[0]["agency_sub_code"].ToString() + ")" + ds4.Tables[0].Rows[0]["Agency"].ToString();

                    }

                    lbcompaddress.Text = ds5.Tables[0].Rows[0]["Add1"].ToString() + " " + ds5.Tables[0].Rows[0]["Street"].ToString()
                    + " " + ds5.Tables[0].Rows[0]["Dist_Code"].ToString() + "," + ds5.Tables[0].Rows[0]["Zip"].ToString() + "</br>" + "Phone No.:" + ds5.Tables[0].Rows[0]["Phone1"].ToString()
                    + "," + ds5.Tables[0].Rows[0]["Phone2"].ToString() + "," + "     Fax:" + ds5.Tables[0].Rows[0]["Fax"].ToString() + "&nbsp;</br> Email Id: " + ds5.Tables[0].Rows[0]["EmailID"].ToString()
                     + "</br>" + "CIN:" + ds4.Tables[0].Rows[0]["cin_no"].ToString() + "</br>" + "PAN:" + "AACCD1338F" + "</br>" + "State?UT:" + ds4.Tables[0].Rows[0]["br_STATE_NAME"].ToString() + "</br>" + "State/UT Code::" + ds4.Tables[0].Rows[0]["br_GST_STATE_CODE"].ToString() + "</br>" + "GSTIN:" + ds4.Tables[0].Rows[0]["BRANCH_GSTIN"].ToString();

                    //txtmailid.Text = addname1[1];

                    //lbemailtxt.Text = "www.nationalduniya.com";
                    lbemailtxt.Text = ds4.Tables[0].Rows[0]["emailid"].ToString();
                    txtvts.Text = ds4.Tables[0].Rows[0]["No_of_VTS"].ToString();
                    txtcrdys.Text = ds4.Tables[0].Rows[0]["Credit_days"].ToString();//ds4.Tables[0].Rows[0]["paydate"].ToString();
                    txtduedys.Text = ds4.Tables[0].Rows[0]["paydate"].ToString(); //ds4.Tables[0].Rows[0]["paydatesys"].ToString();

                    hribhomi_text.Text = "For     " + "DILIGENT MEDIA CORPORATION LTD.";//+ds4.Tables[0].Rows[0]["pub1"].ToString();
                    if (ds4.Tables[0].Rows[0]["agency_sub_code"].ToString() != "")
                    {

                    }
                    /////////////////////
                    if (ds4.Tables[0].Rows[0]["insert_date"].ToString() != "")
                    {
                        // billdt.Text = ds4.Tables[0].Rows[0]["insert_date"].ToString();
                        lbbilldt.Text = ds4.Tables[0].Rows[0]["insert_date"].ToString();
                    }
                    if (ds4.Tables[0].Rows[0]["key_no"].ToString() != "")
                    {
                        txtkey.Text = ds4.Tables[0].Rows[0]["key_no"].ToString();
                    }
                    if (ds4.Tables[0].Rows[0]["RoNo."].ToString() != "")
                    {
                        txtrefno.Text = ds4.Tables[0].Rows[0]["RoNo."].ToString();
                    }
                    if (ds4.Tables[0].Rows[0]["Ro_Date"].ToString() != "")
                    {
                        txtrodate.Text = ds4.Tables[0].Rows[0]["Ro_Date"].ToString();
                    }
                    if (ds4.Tables[0].Rows[0]["Cap"].ToString() != "")
                    {
                        // txtcaption.Text = ds4.Tables[0].Rows[0]["Cap"].ToString() + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + ds4.Tables[0].Rows[0]["product"].ToString();
                    }
                    else if (ds4.Tables[0].Rows[0]["product"].ToString() != "")
                    {
                        //txtcaption.Text = "--" + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + ds4.Tables[0].Rows[0]["product"].ToString();
                    }
                    else if (ds4.Tables[0].Rows[0]["Cap"].ToString() != "")
                    {
                        //txtcaption.Text = ds4.Tables[0].Rows[0]["Cap"].ToString() + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + "--";
                    }
                    else
                    {
                        //txtcaption.Text = "--" + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + "--";
                    }

                    compname = ds4.Tables[0].Rows[0]["companyname"].ToString();
                    compname25 = "<B>NATIONAL DUNIYA Communications Pvt. Ltd.</B>";
                    if (Session["revenue"].ToString() == "ja1")
                    {
                        lbcompanyname.Text = compname25;
                    }
                    else
                    {
                        lbcompanyname.Text = compname;
                    }
                    //string rev = ds4.Tables[0].Rows[0]["Print_cent_name"].ToString();
                    rev = "DELHI";
                    revenu = "";
                    revenu25 = "";
                    if (ds5.Tables[0].Rows[0]["Pub_Cent_name"].ToString() == "NCR")
                    {
                        revenu = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All Cheques/Drafts should be in favour of ESS BEE MEDIA PVT LTD & Payable  at ,&nbsp;NOIDA.<br /> 2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br /> 3:&nbsp;All disputes are subject to NOIDA Jurisdicition<br /> ";
                        revenu25 = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All Cheques/Drafts should be in favour of ESS BEE MEDIA PVT LTD& Payable  at,&nbsp;" + compname25 + " , &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;" + rev + ".<br /> 2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br />  3:&nbsp;All disputes are subject to NOIDA Jurisdicition<br /> ";
                    }
                    else
                    {
                        // & Payable  at ,&nbsp;" + ds5.Tables[0].Rows[0]["Pub_Cent_name"].ToString() + "
                        revenu = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All Cheques/Drafts should be in favour of " + ds4.Tables[0].Rows[0]["companyname"].ToString() + "<br />2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br />3:&nbsp;Please quote our invoice no. while remitting the amount<br />4:&nbspInterest @ 18% Per annum will be charged on overdue invoices.<br />5:&nbsp;All disputes subject to Mumbai Jurisdiction.";
                        revenu25 = "<b><u>Terms & Conditions:</u></b><br />1:&nbsp;All Cheques/Drafts should be in favour of ESS BEE MEDIA PVT LTD& Payable  at,&nbsp;" + compname25 + " , &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;" + rev + ".<br /> 2:&nbsp;Any query may please be reverted within 15 days of receipt of bill.<br />  3:&nbsp;All disputes are subject to NOIDA Jurisdicition<br /> ";
                    }
                    if (Session["revenue"].ToString() == "ja1")
                    {
                        hidedata.Text = revenu25;
                    }
                    else
                    {
                        hidedata.Text = revenu;
                    }
                    // txtinvoice.Text = invoiceno.ToString();
                    lbbillno.Text = invoiceno.ToString();
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
                    // runtxt.Text = date.ToString(); 
                    edicode = "";
                    counteditioncode = ds4.Tables[2].Rows.Count;
                    bukingdate = bookingdate.ToString();
                    if (bukingdate != "")
                    { }
                    else
                    { }
                    rono1 = orderno1.ToString();
                    rodate = orderdate.ToString();
                    if (rodate != "" && rono1 != "")
                    { }



                    string[] package = ds4.Tables[0].Rows[0]["Package"].ToString().Split(',');
                    int packagelen = package.Length;

                    for (int l = 0; l < ds4.Tables[0].Rows.Count; l++)
                    {
                        dytbl += "<tr align=center hight='10px'>";
                        dytbl += "<td class='insertiontxtclass' align='center' style='border-right:solid 1px black; border-bottom:solid 1px black;'>" + srl.ToString() + "</td>";
                        //dytbl += "<td class='insertiontxtclass' align='center' width='150px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[0]["EditionName"].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass' align='center' width='150px' style='border-right:solid 1px black; border-bottom:solid 1px black;' >" + ds4.Tables[0].Rows[l]["package_name1"].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass' align='center'width='50px' style='border-right:solid 1px black; border-bottom:solid 1px black;'>" + ds4.Tables[0].Rows[l]["insert_date"].ToString() + "</td>";


                        if (ds4.Tables[0].Rows[l]["Depth"].ToString() != "")
                        {
                            {
                                dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black; border-bottom:solid 1px black;'>" + ds4.Tables[0].Rows[l]["Depth"].ToString() + "*" + ds4.Tables[0].Rows[0]["Width"].ToString() + "</td>";
                            }
                        }
                        else
                        {
                            dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black; border-bottom:solid 1px black;'>" + ds4.Tables[0].Rows[l]["volume"].ToString() + "</td>";
                        }
                        dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black; border-bottom:solid 1px black;'>" + ds4.Tables[0].Rows[l]["volume"].ToString() + "</td>";
                        dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black; border-bottom:solid 1px black;'>" + ds4.Tables[0].Rows[l]["Hue"].ToString() + "</td>";
                        dytbl += "<td class='insertiontxtclass'align='center' width='90px' style='border-right:solid 1px black; border-bottom:solid 1px black;' >" + ds4.Tables[0].Rows[l]["Page_insrt"].ToString() + "</td>";
                        if (packlength == 0 && packlength_total == 0)
                        {
                            if (l == 0)
                            {

                                if (ds4.Tables[0].Rows[0]["package rate"].ToString() != "")
                                {
                                    dytbl += "<td class='insertiontxtclass' align='center' width='80px' style='border-right:solid 1px black; border-bottom:solid 1px black;'>" + ds4.Tables[0].Rows[0]["package rate"].ToString() + "</td>";
                                }
                                else
                                {
                                    dytbl += "<td class='insertiontxtclass' align='center' width='80px' style='border-right:solid 1px black; border-bottom:solid 1px black;'>" + ds4.Tables[0].Rows[0]["card_rate"].ToString() + "</td>";
                                }

                                if (ds4.Tables[0].Rows[0]["Bill_amt"].ToString() != "0")
                                {
                                    if (ds4.Tables[0].Rows[0]["ACTIVE_AGREEDAMT"].ToString() == "1")
                                    {
                                        cardamt = Convert.ToDouble(ds4.Tables[0].Rows[0]["amt"].ToString());
                                    }
                                    else
                                    {
                                        cardamt = Convert.ToDouble(ds4.Tables[0].Rows[0]["amt"].ToString());
                                    }
                                }
                                else
                                {
                                    cardamt = 0;
                                }

                                if (ds4.Tables[0].Rows[0]["PREM_AMT"].ToString() != "")
                                {
                                    addpremamt = Convert.ToDouble(ds4.Tables[0].Rows[0]["PREM_AMT"].ToString());
                                    addpremamt32 = addpremamt32 + addpremamt;
                                }
                                if (ds4.Tables[0].Rows[0]["SPLDISAMT"].ToString() != "")
                                {
                                    splamt = Convert.ToDouble(ds4.Tables[0].Rows[0]["SPLDISAMT"].ToString());
                                    splamt32 = splamt32 + splamt;
                                }


                                dytbl += "<td class='insertiontxtclass' align='center' width='80px' style='border-bottom:solid 1px black;'>" + ((cardamt - addpremamt) + splamt).ToString() + "</td>";//((cardamt - addpremamt) + splamt).ToString()
                                dytbl += "<td class='insertiontxtclass' align='right'  width='90px' style='border-left:solid 1px black;border-right:solid 1px black;border-bottom:solid 1px black;'>" + ((cardamt - addpremamt) + splamt).ToString() + "</td>";

                            }
                            else
                            {
                                if (ds4.Tables[0].Rows[0]["package rate"].ToString() != "")
                                {
                                    dytbl += "<td class='insertiontxtclass' align='center' width='80px' style='border-right:solid 1px black; border-bottom:solid 1px black;'>" + ds4.Tables[0].Rows[l]["package rate"].ToString() + "</td>";
                                }
                                else
                                {
                                    dytbl += "<td class='insertiontxtclass' align='center' width='80px' style='border-right:solid 1px black; border-bottom:solid 1px black;'>" + ds4.Tables[0].Rows[l]["card_rate"].ToString() + "</td>";
                                }

                                if (ds4.Tables[0].Rows[l]["Bill_amt"].ToString() != "0")
                                {
                                    if (ds4.Tables[0].Rows[0]["ACTIVE_AGREEDAMT"].ToString() == "1")
                                    {
                                        cardamt = Convert.ToDouble(ds4.Tables[0].Rows[l]["amt"].ToString());
                                    }
                                    else
                                    {
                                        cardamt = Convert.ToDouble(ds4.Tables[0].Rows[l]["amt"].ToString());
                                    }
                                }
                                else
                                {
                                    cardamt = 0;
                                }

                                if (ds4.Tables[0].Rows[l]["PREM_AMT"].ToString() != "")
                                {
                                    addpremamt = Convert.ToDouble(ds4.Tables[0].Rows[l]["PREM_AMT"].ToString());
                                    addpremamt32 = addpremamt32 + addpremamt;
                                }

                                if (ds4.Tables[0].Rows[l]["SPLDISAMT"].ToString() != "")
                                {
                                    splamt = Convert.ToDouble(ds4.Tables[0].Rows[l]["SPLDISAMT"].ToString());
                                    splamt32 = splamt32 + splamt;
                                }


                                dytbl += "<td class='insertiontxtclass' align='center' width='80px' style='border-bottom:solid 1px black;'>" + ((cardamt - addpremamt) + splamt).ToString() + "</td>";//((cardamt - addpremamt) + splamt).ToString()
                                dytbl += "<td class='insertiontxtclass' align='right'  width='90px' style='border-left:solid 1px black;border-right:solid 1px black;border-bottom:solid 1px black;'>" + ((cardamt - addpremamt) + splamt).ToString() + "</td>";

                            }

                        }
                        else
                        {


                            if (ds4.Tables[0].Rows[0]["package rate"].ToString() != "")
                            {
                                dytbl += "<td class='insertiontxtclass' align='center' width='80px' style='border-right:solid 1px black; border-bottom:solid 1px black;'>" + ds4.Tables[0].Rows[l]["package rate"].ToString() + "</td>";
                            }
                            else
                            {
                                dytbl += "<td class='insertiontxtclass' align='center' width='80px' style='border-right:solid 1px black; border-bottom:solid 1px black;'>" + ds4.Tables[0].Rows[l]["card_rate"].ToString() + "</td>";
                            }
                            if (ds4.Tables[0].Rows[l]["Bill_amount"].ToString() != "0")
                            {
                                if (ds4.Tables[0].Rows[0]["ACTIVE_AGREEDAMT"].ToString() == "1")
                                {
                                    cardamt = Convert.ToDouble(ds4.Tables[0].Rows[l]["amt"].ToString());
                                }
                                else
                                {
                                    cardamt = Convert.ToDouble(ds4.Tables[0].Rows[l]["amt"].ToString());
                                }
                            }
                            else
                            {
                                cardamt = 0;
                            }

                            if (ds4.Tables[0].Rows[l]["PREM_AMT"].ToString() != "")
                            {
                                addpremamt = Convert.ToDouble(ds4.Tables[0].Rows[l]["PREM_AMT"].ToString());
                                addpremamt32 = addpremamt32 + addpremamt;
                            }

                            if (ds4.Tables[0].Rows[l]["SPLDISAMT"].ToString() != "")
                            {
                                splamt = Convert.ToDouble(ds4.Tables[0].Rows[l]["SPLDISAMT"].ToString());
                                splamt32 = splamt32 + splamt;
                            }
                            dytbl += "<td class='insertiontxtclass' align='right'  width='90px' style='border-right:solid 1px black;'>" + ".." + "</td>";
                            //dytbl += "<td class='insertiontxtclass' align='center'  width='90px'>" + ".." + "</td>";
                            dytbl += "<td class='insertiontxtclass' align='right'  width='90px' style='border-left:solid 1px black;border-right:solid 1px black;'>" + ".." + "</td>";

                        }

                        if (ds4.Tables[0].Rows[0]["Bill_Amt"].ToString() != "")
                        {
                            bill_amt = Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_rate"].ToString());
                        }
                        else
                        {
                            bill_amt = 0;
                        }

                        bill_amt1 = bill_amt1 + cardamt;


                        if (trade_disc != "1")
                        {
                            if (ds4.Tables[0].Rows[0]["DISCOUNT_PER"].ToString() != "")
                                disc = Convert.ToDouble(ds4.Tables[0].Rows[0]["DISCOUNT_PER"].ToString());
                        }
                        else
                        {
                            disc = 0;
                        }
                        dytbl += "</tr>";


                        srl++;
                    }


                }




                if (ds4.Tables[0].Rows[0]["booking_type"].ToString() == "3" || ds4.Tables[0].Rows[0]["booking_type"].ToString() == "1")
                {
                    double amtpremium = 0;
                    double amountprem = 0;
                    if (ds4.Tables[0].Rows[0]["Prem_per"].ToString() != "")
                    {

                        lb_pageprm.Text = ds4.Tables[0].Rows[0]["Prem_per"].ToString() + "%";
                        //amountprem = Convert.ToDouble(ds4.Tables[0].Rows[0]["premiumch"].ToString());
                    }
                    else
                    {
                        lb_pageprm.Text = "0%";
                        amountprem = 0;
                    }
                    double amtpre = 0;
                    if (amountprem != 0)
                    {

                        lb_pageprm.Text = addpremamt32.ToString();

                    }
                    double surchg = 0;
                    double chgamt = 0;
                    double spcdis = 0;
                    double trnacdis = 0;
                    double pospredis = 0;
                    if (ds4.Tables[0].Rows[0]["trade_disc"].ToString() != "")
                    {


                    }

                    // }
                    ////////////transletion disc/////////////////



                    /////////////////////spcl discount//////////////////

                    if (ds4.Tables[0].Rows[0]["commdisc"].ToString() != "")
                    {

                        splchagr.Text = "(" + ds4.Tables[0].Rows[0]["commdisc"].ToString() + "%)";

                    }
                    else
                    {
                        splchagr.Text = "(0)%";

                    }
                    if (ds4.Tables[0].Rows[0]["spldisamt"].ToString() != "")
                    {

                        Label9.Text = splamt32.ToString();

                    }
                    else
                    {
                        Label9.Text = "0.00";

                    }
                    ////////////////////spc discount///////////                     




                    ////////////posprem disc/////////////////



                    /////////////gross amt/////////////
                    double grosamt = 0;
                    for (int k = 0; k < ds4.Tables[0].Rows.Count; k++)
                    {
                        if (ds4.Tables[0].Rows[0]["ACTIVE_AGREEDAMT"].ToString() == "1")
                        {
                            grosamt = grosamt + Convert.ToDouble(ds4.Tables[0].Rows[k]["amt"].ToString());
                        }
                        else
                        {
                            grosamt = grosamt + Convert.ToDouble(ds4.Tables[0].Rows[k]["amt"].ToString());
                        }
                    }
                    //double grosamt = Convert.ToDouble(ds4.Tables[0].Rows[0]["package amt"].ToString());
                    grossamt = (grosamt + addpremamt32 + chgamt) - spcdis - splamt32 - trnacdis - pospredis;
                    // grossamt= Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_amount"].ToString());
                    lb_totalamt.Text = grossamt.ToString();






                    ////commission discount
                    //if (ds4.Tables[0].Rows[0]["COMMDISC"].ToString() != "")
                    //{
                    //    Label9.Text = ds4.Tables[0].Rows[0]["COMMDISC"].ToString();
                    //    spldisc = Convert.ToDouble(ds4.Tables[0].Rows[0]["COMMDISC"].ToString());

                    //}
                    //else
                    //{
                    //    Label9.Text = "0";
                    //    spldisc = 0;
                    //}

                    //if (spldisc != 0)
                    //{
                    //    Label9.Text = splamt32.ToString();
                    //}

                    double dis = 0;
                    double addisag = 0;
                    if (trade_disc != "1")
                    {
                        if (ds4.Tables[0].Rows[0]["CHKTRADEDISC"].ToString() != "0")
                        {
                            if (ds4.Tables[0].Rows[0]["trade_disc"].ToString() != "")
                            {
                                trddisc_per.Text = "(" + ds4.Tables[0].Rows[0]["Trade_disc"].ToString() + "%)";
                                dis = Convert.ToDouble(ds4.Tables[0].Rows[0]["trade_disc"].ToString());
                            }
                        }


                    }
                    else
                    {
                        trddisc_per.Text = "(0%)";
                        dis = 0;
                        addisag = 0;
                    }



                    double disamount = 0;
                    if (dis != 0)
                    {
                        disamount = (grossamt * Convert.ToDouble(dis)) / 100;

                    }

                    txtdiscal.Text = disamount.ToString();

                    double tot = 0;
                    tot = grossamt - disamount;
                    splgrossamt = (bill_amt1 - addpremamt32) + splamt32;
                    // lb_totalamt.Text = Convert.ToString(tot);
                    double splchg = 0;
                    /////Special Charges//////////

                    //if (ds4.Tables[0].Rows[0]["Special_charges"].ToString() != "")
                    //{
                    //    splchg = Convert.ToDouble(ds4.Tables[0].Rows[0]["Special_charges"].ToString());
                    //    lb_spc_chg.Text = ds4.Tables[0].Rows[0]["Special_charges"].ToString();
                    //}
                    //else
                    //{
                    //    lb_spc_chg.Text = "0.00";
                    //    splchg = 0;
                    //}

                    ///////////////////Add.agn.T.D//////////////////


                    /////////////net Amount//////////

                    //netpay.Text = Convert.ToString(ds4.Tables[3].Rows[0]["bill_amount"].ToString());

                    double netamt = 0;
                    //netamt = Convert.ToDouble(ds4.Tables[3].Rows[0]["Bill_amount"].ToString());
                    if (spldisc1 != 0)
                    {
                        netamt = spldisc1 - disamount;
                    }
                    else
                    {
                        netamt = tot - addisag;
                    }


                    if (ds4.Tables[0].Rows[0]["CGST_RATE"].ToString() != "")
                    {
                        Label17.Text = "(" + ds4.Tables[0].Rows[0]["CGST_RATE"].ToString() + "%)";
                        Label18.Text = ds4.Tables[0].Rows[0]["CGST_AMT"].ToString();
                    }
                    else
                    {
                        Label17.Text = "(0%)";
                        Label18.Text = "0";
                    }

                    if (ds4.Tables[0].Rows[0]["SGST_RATE"].ToString() != "")
                    {
                        Label21.Text = "(" + ds4.Tables[0].Rows[0]["SGST_RATE"].ToString() + "%)";
                        Label22.Text = ds4.Tables[0].Rows[0]["SGST_AMT"].ToString();
                    }
                    else
                    {
                        Label21.Text = "(0%)";
                        Label22.Text = "0";
                    }

                    if (ds4.Tables[0].Rows[0]["IGST_RATE"].ToString() != "")
                    {
                        Label25.Text = "(" + ds4.Tables[0].Rows[0]["IGST_RATE"].ToString() + "%)";
                        Label26.Text = ds4.Tables[0].Rows[0]["IGST_AMT"].ToString();
                    }
                    else
                    {
                        Label25.Text = "(0%)";
                        Label26.Text = "0";
                    }

                    if (ds4.Tables[0].Rows[0]["GST_CESS_RATE"].ToString() != "")
                    {
                        Label29.Text = "(" + ds4.Tables[0].Rows[0]["GST_CESS_RATE"].ToString() + "%)";
                        Label30.Text = ds4.Tables[0].Rows[0]["GST_CESS_AMT"].ToString();
                    }
                    else
                    {
                        Label25.Text = "(0%)";
                        Label26.Text = "0";
                    }


                    //netamt = netamt + splchg;
                    netamt = Convert.ToDouble(ds4.Tables[0].Rows[0]["bill_amt"].ToString());
                    //netpay.Text = netamt.ToString();
                    netpay.Text = Math.Round(netamt).ToString();
                    //Label21.Text = Math.Round(netamt).ToString();
                    txtrupees.Text = Math.Round(netamt).ToString();
                    amountinckudingbox = Convert.ToDouble(netpay.Text.ToString());
                    double amountinckudingbox1 = Math.Round(amountinckudingbox);
                    NumberToEngish obj = new NumberToEngish();
                    lbwordinrupees.Text = obj.changeNumericToWords(amountinckudingbox1.ToString()) + "Only";
                }




                ////////////////



                break;

            }
            break;
        }


        for (int a1 = ds4.Tables[0].Rows.Count; a1 < 2; a1++)
        {
            dytbl += "<tr align=center hight='67px'>";
            dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
            dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
            dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
            dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
            dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
            dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
            dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
            dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
            dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
            dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
            dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-left:solid 1px black;'>" + "&nbsp;" + "</td>";
            dytbl += "</tr>";
        }

        ////////////////

        dytbl += "</table>";

        dynamictable.Text = dytbl;



        if (chkvalue_length == "yes")
        {

            tbl_id.Attributes.Add("style", "page-break-after:always;");

        }
        //  }
    }
}

