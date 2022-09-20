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

public partial class RCB_CLASSIFIED : System.Web.UI.UserControl
{
    public string _txtinvoice;
    public string _runtxt;
    public string _lbcreditdatetxt;
    public string _lbadtypetxt;
    public string _lbadcattxt;
    public string _lbformonthtxt;
    public string _agddxt;
    public string _lbagencyaddtxt;
    public string _txtcliname;
    public string _lbwalujadd;
    public string _lbbranchtxt;
    public string _lbemailtxt;
    public string _lbpunetxt;
    public string _lbcompanyname;
    public string _dynamictable;
    public string _hidedata;
    public string _EOU;
    public string _lbemail;
    public string _lbemai2;
    public string _lbpune;
    public string _txttotal;
    public string _lbtotal;
    public string _Label2;

    
    public RCB_CLASSIFIED()
    {
        _txtinvoice="";
        _runtxt="";
        _lbcreditdatetxt="";
        _lbadtypetxt = "";
        _lbadcattxt = "";
        _lbformonthtxt = "";
        _agddxt = "";
        _lbagencyaddtxt = "";
        _txtcliname = "";
        _lbwalujadd = "";
        _lbbranchtxt = "";
        _lbemailtxt="";
        _lbpunetxt="";
        _lbcompanyname = "";
        _dynamictable = "";
         _hidedata = "";
         _EOU = "";
         _lbemail = "";
         _lbemai2 = "";
         _lbpune = "";
         _txttotal = "";
         _lbtotal = "";
         _Label2 = "";


    }

  

     public string txtinvoice1 { get {return _txtinvoice; }set { _txtinvoice = value; } }
    public string runtxt1 { get {return _runtxt;}set {_runtxt = value; } }
    public string lbcreditdatetxt1 { get { return _lbcreditdatetxt; } set{ _lbcreditdatetxt = value; } }
    public string lbadtypetxt1 { get {return _lbadtypetxt; } set { _lbadtypetxt = value; } }
    public string lbadcattxt1 { get { return _lbadcattxt; } set { _lbadcattxt = value; } }
    public string lbformonthtxt1 { get {return _lbformonthtxt; } set { _lbformonthtxt = value; } }
    public string agddxt1 {get { return _agddxt; } set { _agddxt = value; } }
    public string lbagencyaddtxt1 { get{ return _lbagencyaddtxt; } set { _lbagencyaddtxt = value;} }
    public string txtcliname1 {get {return _txtcliname; } set { _txtcliname = value; } }
    public string lbwalujadd1 { get{ return _lbwalujadd; } set {_lbwalujadd = value; } }
   // public string lbwalujadd1 { get{ return _lbwalujadd; } set {_lbwalujadd = value; } }
    public string lbbranchtxt1{ get { return _lbbranchtxt; } set{ _lbbranchtxt = value; } }
    public string lbemailtxt1{ get { return _lbemailtxt; } set{ _lbemailtxt = value; } }
    public string lbpunetxt1 { get { return _lbpunetxt; } set { _lbpunetxt = value; } }
    public string lbcompanyname1{ get { return _lbcompanyname; } set{ _lbcompanyname = value; } }
    public string dynamictable1 { get { return _dynamictable; } set { _dynamictable = value; } }
    public string hidedata1 { get { return _hidedata; } set { _hidedata = value; } }
    public string EOU1 { get { return _EOU; } set { _EOU = value; } }
    public string lbemail1 { get { return _lbemail; } set { _lbemail = value; } }
    public string lbemail2 { get { return _lbemai2; } set { _lbemai2 = value; } }
    public string lbpune1 { get { return _lbpune; } set { _lbpune = value; } }
    public string txttotal1 { get { return _txttotal; } set { _txttotal = value; } }

    public string lbtotal1 { get { return _lbtotal; } set { _lbtotal = value; } }
    public string Label2 { get { return _Label2; } set { _Label2 = value; } }
  


     
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();


        ds.ReadXml(Server.MapPath("XML/punebill.xml"));
        //lbemail.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
       // lbpune.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        agencytxt.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbagencyadd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();

        lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbcreditdate.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbadcat.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        lbformonth.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString();
        lbbranch.Text = ds.Tables[0].Rows[0].ItemArray[46].ToString();
        lbwaluj.Text = ds.Tables[0].Rows[0].ItemArray[47].ToString();
       // lbgross.Text = ds.Tables[0].Rows[0].ItemArray[52].ToString();
       // lbcomm.Text = ds.Tables[0].Rows[0].ItemArray[53].ToString();
       // lbgr.Text = ds.Tables[0].Rows[0].ItemArray[54].ToString();


    }

    public void setReceiptData()
    {

        txtinvoice.Text = txtinvoice1;
        runtxt.Text = runtxt1;
        lbcreditdatetxt.Text = lbcreditdatetxt1;


        lbadtypetxt.Text = lbadtypetxt1;
        lbadcattxt.Text = lbadcattxt1;
        lbformonthtxt.Text = lbformonthtxt1;
        agddxt.Text = agddxt1;
        lbagencyaddtxt.Text = lbagencyaddtxt1;
       
        lbwalujadd.Text = lbwalujadd1;
        lbbranchtxt.Text = lbbranchtxt1;
        lbcompanyname.Text = lbcompanyname1;
        lbpunetxt.Text = lbpunetxt1;
        dynamictable.Text = dynamictable1;
       // hidedata.Text = hidedata1;
        EOU.Text = EOU1;
        lbemail.Text = lbemail1;
        lbemailtxt.Text = lbemail2;
        lbpune.Text = lbpune1;
        //txttotal.Text = txttotal1;
       //lbtotal .Text = lbtotal1;
       lbemailtxt.Text = lbemailtxt1;
      // Label234.Text = Label2;

    }


}
