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
public partial class billing : System.Web.UI.UserControl
{
    public static string _agency;
    public static string _package;
    public static string _insertion;
    public static string _bookingid;
    public static string _height;
    public static string _width;
    public static string _color;
    public static string _volume;
    public static string _adcat;
    public static string _pageposition;
    public static string _scheme;
    public static string _rono_date;
    
    public static string _publication;

    public static string _rundate;
    public static string _packgerate;
    public static string _orderno;


  
    public billing()


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






  
    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();



        ds.ReadXml(Server.MapPath("XML/bill.xml"));
        lbagecnycode.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbtype.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbstandard.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbposition.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbpackage.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbscheme.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbavertiser.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbnumber.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbordernumber.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();
        lbweidth.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lbheight.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lbvolume.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lbextrasize.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        lbcolor.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
        lbpackagerate.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
        lbextracharges.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
        lbdiscount.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        lbamount.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        lblamount.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        lbltrade.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        lbltotal.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        lblbox.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        lblnet.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        lblnetpayable.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        lbformatproposal.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
        lbinsertionnumber.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
        lblwhile.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
        lbpanno .Text = ds.Tables[0].Rows[0].ItemArray[31].ToString();
        lbproductkey.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();
       lbrupee .Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
          lbpub.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        lbedition.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();

    }

    public void setcard()
    {

        lbweidthtxt.Text = width.ToString();
        lbheitext.Text = height.ToString();
        lbcolortxt.Text = color.ToString();
        packaget.Text = package.ToString();
        adcat.Text = adcat1.ToString();
        position.Text = pageposition.ToString();
        rono.Text = rono_date.ToString();
        insertiontxt.Text  = insertion.ToString();
        agencytxt.Text = agency.ToString();
        pubtxt.Text = publication.ToString();
        orderno.Text = orderno1.ToString();
        




        //lbvoltxt.Text =volume.ToString ();
        //lbextratxt.Text=volume.ToString ();
        
        //lbextr.Text=
        //lbdiscounttxt.Text=
        //lbamtxt.Text=


      
      
      

    }
}
