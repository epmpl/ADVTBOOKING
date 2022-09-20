using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class bill_generate_insertionwise : System.Web.UI.UserControl
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


    public bill_generate_insertionwise()
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

    }

    public void setcardlastnew()
    {
        string pcompcode = Session["compcode"].ToString();
        string pcenter = publicationcenter;
        string porderno = bookingid;
        string pinsertion_no = insertion;
        string pbill_cycle = "";
        string puserid = Session["userid"].ToString();
        string pfrom_date = fromdate;
        string ptill_date = dateto;
        string pbill_date = "";
        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "haribhoomi")
        {
             pbill_date = "";
        }
        else
        {
             pbill_date = billdater;
        }
        string pdateformat = Session["dateformat"].ToString();
        string pnoofinsert = "";
        string pprefix = publicationcenter;
        string pextra1 = "";
        string pextra2 = "";
        string pextra3 = "";
        string pextra4 = "";
        string pextra5 = "";
        // string result = "";

        //DateTime dt = DateTime.Now;
        //string cen = branch;
        //pprefix = publicationcentername.Substring(0, 3);




        DataSet result = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.save_det_orderwiselast objbkcenter = new NewAdbooking.BillingClass.classesoracle.save_det_orderwiselast();
            result = objbkcenter.bill_save_data_insertionwise(pcompcode, pcenter, porderno, pinsertion_no, pbill_cycle, puserid, pfrom_date, ptill_date, pbill_date, pdateformat, pnoofinsert, pprefix, pextra1, pextra2, pextra3, pextra4, pextra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.save_det_orderwiselast objbkcenter = new NewAdbooking.BillingClass.Classes.save_det_orderwiselast();
            result = objbkcenter.bill_save_data_insertionwise(pcompcode, pcenter, porderno, pinsertion_no, pbill_cycle, puserid, pfrom_date, ptill_date, pbill_date, pdateformat, pnoofinsert, pprefix, pextra1, pextra2, pextra3, pextra4, pextra5);
        }
         else
        {
            string[] parameterValueArray = new string[] { pcompcode, pcenter, porderno, pinsertion_no, pbill_cycle, puserid, pfrom_date, ptill_date, pbill_date, pdateformat, pnoofinsert, pprefix, pextra1, pextra2, pextra3, pextra4, pextra5 };
            string procedureName = "bill_save_insertionwise_new";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            result = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }

    }

}
