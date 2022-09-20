using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class RP_bill_combined : System.Web.UI.UserControl
{

    public string _chkval;
    public string _txtinvoice1;
    public string _agencytxt1;
    public string _lblkeyno1;
    public string _agencyaddtxt1;
    public string _lb_booking_id1;
    public string _runtxt1;
    public string _txtcliname1;
    public string _lbronodate1;
    public string _lblremark1;
    public string _scheme;
    public string _dynamictable1;
    public string _orgdup1;
    public string _adcat1;
    public string _grossamt;
    public string _agdis;
    public string _traddis1;
    public string _traddisamt;
    public string _adddis1;
    public string _addchr1;
    public string _boxcrg1;
    public string _bullet1;
    public string _transcrg1;
    public string _netbillamt1;
    public string _hideamt;
        
    public RP_bill_combined()
    {

        _chkval = "";
        _txtinvoice1 = "";
        _agencytxt1 = "";
        _lblkeyno1 = "";
        _agencyaddtxt1 = "";
        _lb_booking_id1 = "";
        _runtxt1 = "";
        _txtcliname1 = "";
        _lbronodate1 = "";
        _lblremark1 = "";
        _scheme = "";
        _dynamictable1 = "";
        _orgdup1 = "";
        _adcat1 = "";
        _grossamt = "";
        _agdis = "";
        _traddis1 = "";
        _adddis1 = "";
        _addchr1 = "";
        _boxcrg1 = "";
        _bullet1 = "";
        _transcrg1 = "";
        _netbillamt1 = "";
        _traddisamt = "";
        _hideamt = "";
      
    }
    public string hideamt { get { return _hideamt; } set { _hideamt = value; } }
    public string traddisamt { get { return _traddisamt; } set { _traddisamt = value; } }
    public string netbillamt1 { get { return _netbillamt1; } set { _netbillamt1 = value; } }
    public string transcrg1 { get { return _transcrg1; } set { _transcrg1 = value; } }
    public string bullet1 { get { return _bullet1; } set { _bullet1 = value; } }
    public string boxcrg1 { get { return _boxcrg1; } set { _boxcrg1 = value; } }
    public string addchr1 { get { return _addchr1; } set { _addchr1 = value; } }
    public string adddis1 { get { return _adddis1; } set { _adddis1 = value; } }
    public string traddis1 { get { return _traddis1; } set { _traddis1 = value; } }
    public string add_ag_dis1 { get { return _agdis; } set { _agdis = value; } }
    public string grossamt { get { return _grossamt; } set { _grossamt = value; } }
    public string adcat1 { get { return _adcat1; } set { _adcat1 = value; } }
    public string chkvalue_length { get { return _chkval; } set { _chkval = value; } }
    public string txtinvoice1 { get { return _txtinvoice1; } set { _txtinvoice1 = value; } }
    public string agencytxt1 { get { return _agencytxt1; } set { _agencytxt1 = value; } }
    public string lblkeyno1 { get { return _lblkeyno1; } set { _lblkeyno1 = value; } }
    public string agencyaddtxt1 { get { return _agencyaddtxt1; } set { _agencyaddtxt1 = value; } }
    public string lb_booking_id1 { get { return _lb_booking_id1; } set { _lb_booking_id1 = value; } }
    public string runtxt1 { get { return _runtxt1; } set { _runtxt1 = value; } }
    public string txtcliname1 { get { return _txtcliname1; } set { _txtcliname1 = value; } }
    public string lbronodate1 { get { return _lbronodate1; } set { _lbronodate1 = value; } }
    public string lblremark1 { get { return _lblremark1; } set { _lblremark1 = value; } }
    public string lblschemetype1 { get { return _scheme; } set { _scheme = value; } }
    public string dynamictable1 { get { return _dynamictable1; } set { _dynamictable1 = value; } }
    public string orgdup1 { get { return _orgdup1; } set { _orgdup1 = value; } }
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void setReceiptData()
    {
        string aa = chkvalue_length;
        txtinvoice.Text = txtinvoice1;
        agencytxt.Text = agencytxt1;
        lblkeyno.Text = lblkeyno1;
        agencyaddtxt.Text = agencyaddtxt1;
        lb_booking_id.Text = lb_booking_id1;
        runtxt.Text = runtxt1;
        txtcliname.Text = txtcliname1;
        lbronodate.Text = lbronodate1;
        lblremark.Text = lblremark1;
        lblschemetype.Text = lblschemetype1;
        orgdup.Text = orgdup1;
        adcat.Text = adcat1;
        if (hideamt == "none")
            tblamt.Attributes.Add("style", "display:none");

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

      
           dynamictable.Text = dynamictable1;
           //===========*************=================//
           double grossamt1 = 0;
           double boxcrg = 0;
           if (boxcrg1 != "")
               boxcrg = Convert.ToDouble(boxcrg1);
           if (grossamt != "")
           grossamt1= Convert.ToDouble(grossamt);
           lbl_gross.Text =grossamt1.ToString("F2");
           ////add_ag_dis1 = grossamt * add_ag_dis1 / 100;
           ////grossamt = grossamt - add_ag_dis1;
           lbl_tradisper.Text = traddis1.ToString() + "%";
           ////traddis1 = grossamt * traddis1 / 100;

           lbl_trade.Text = traddisamt;
           lbl_add.Text = add_ag_dis1;
           lbl_extra.Text = adddis1; //(adddis + adddis).ToString("F2");
           lbl_box.Text = boxcrg.ToString("F2");
           lblbullet.Text = bullet1;
           lbltranslation.Text = transcrg1;
           double netbillamt = Convert.ToDouble(netbillamt1);
           netbillamt = netbillamt + 0.01;
           netbillamt = Math.Round(netbillamt);
           lbl_net.Text = netbillamt.ToString();

            NumberToEngish obj = new NumberToEngish();
            lbwordinrupees.Text = obj.changeNumericToWords(lbl_net.Text.ToString()) + "Only";

    }
}