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

public partial class udayvani_bill_classi : System.Web.UI.UserControl
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
    public string _lbagcode1;
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
    public string _lbpinno1;

    public string _lbcity;
    public string _lbltradedis;
    public string _lbladddis;
    public string _lblextra;
    public string _lblnetamt;
    public string _lblround;
    public string _lbltotalword;
    public string _lblinvoice;
    public string _hidrec;
    public string _imgpath;
    public string _lblpubl;
    public string _lbldue;
    public udayvani_bill_classi()
    {
        _lbldue = "";
        _txtinvoice = "";
        _runtxt = "";
        _lbcreditdatetxt = "";
        _lbadtypetxt = "";
        _lbadcattxt = "";
        _lbformonthtxt = "";
        _agddxt = "";
        _lbagencyaddtxt = "";
        _txtcliname = "";
        _lbwalujadd = "";
        _lbagcode1 = "";
        _lbemailtxt = "";
        _lbpunetxt = "";
        _lbcompanyname = "";
        _dynamictable = "";
        _hidedata = "";
        _EOU = "";
        _lbemail = "";
        _lbemai2 = "";
        _lbpune = "";
        _txttotal = "";
        _lbtotal = "";
        _lbcity = "";
        _lbpinno1 = "";
        _lbltradedis = "";
        _lbladddis = "";
        _lblextra = "";
        _lblnetamt = "";
        _lblround = "";
        _lbltotalword = "";
        _lblinvoice = "";
        _hidrec = "";
        _imgpath = "";
        _lblpubl = "";
    }

    public string ldduedate1 { get { return _lbldue; } set { _lbldue = value; } }
    public string lblpubname1 { get { return _lblpubl; } set { _lblpubl = value; } }
    public string imgpath { get { return _imgpath; } set { _imgpath = value; } }
    public string hidetab1 { get { return _hidrec; } set { _hidrec = value; } }
    public string txtinvoice1 { get { return _lblinvoice; } set { _lblinvoice = value; } }
    public string lbladddis1 { get { return _lbladddis; } set { _lbladddis = value; } }
    public string lblextra1 { get { return _lblextra; } set { _lblextra = value; } }
    public string lblnetamt1 { get { return _lblnetamt; } set { _lblnetamt = value; } }
    public string lblround1 { get { return _lblround; } set { _lblround = value; } }
    public string lbltradedis1 { get { return _lbltradedis; } set { _lbltradedis = value; } }
    public string rupeetxt1 { get { return _lbltotalword; } set { _lbltotalword = value; } }
    public string runtxt1 { get { return _runtxt; } set { _runtxt = value; } }
    public string lbcreditdatetxt1 { get { return _lbcreditdatetxt; } set { _lbcreditdatetxt = value; } }
    public string lbadtypetxt1 { get { return _lbadtypetxt; } set { _lbadtypetxt = value; } }
    public string lbadcattxt1 { get { return _lbadcattxt; } set { _lbadcattxt = value; } }
    public string lbformonthtxt1 { get { return _lbformonthtxt; } set { _lbformonthtxt = value; } }
    public string agddxt1 { get { return _agddxt; } set { _agddxt = value; } }
    public string lbagencyaddtxt1 { get { return _lbagencyaddtxt; } set { _lbagencyaddtxt = value; } }
    public string txtcliname1 { get { return _txtcliname; } set { _txtcliname = value; } }
    public string lbwalujadd1 { get { return _lbwalujadd; } set { _lbwalujadd = value; } }
    public string lbpinno1 { get { return _lbpinno1; } set { _lbpinno1 = value; } }
    public string lbagcode1 { get { return _lbagcode1; } set { _lbagcode1 = value; } }
    public string lbemailtxt1 { get { return _lbemailtxt; } set { _lbemailtxt = value; } }
    public string lbpunetxt1 { get { return _lbpunetxt; } set { _lbpunetxt = value; } }
    public string lbcompanyname1 { get { return _lbcompanyname; } set { _lbcompanyname = value; } }
    public string dynamictable1 { get { return _dynamictable; } set { _dynamictable = value; } }
    public string hidedata1 { get { return _hidedata; } set { _hidedata = value; } }
    public string EOU1 { get { return _EOU; } set { _EOU = value; } }
    public string lbemail1 { get { return _lbemail; } set { _lbemail = value; } }
    public string lbemail2 { get { return _lbemai2; } set { _lbemai2 = value; } }
    public string lbpune1 { get { return _lbpune; } set { _lbpune = value; } }
    public string txttotal1 { get { return _txttotal; } set { _txttotal = value; } }

    public string lbtotal1 { get { return _lbtotal; } set { _lbtotal = value; } }
    public string lbcityname1 { get { return _lbcity; } set { _lbcity = value; } }




    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();


        ds.ReadXml(Server.MapPath("XML/punebill.xml"));
        //lblagencytxt.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        // lbagencyadd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();

        lbinvoiceno.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        //   lbcreditdate.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        //  lbadcat.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        //   lbformonth.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString();
        //   lbbranch.Text = ds.Tables[0].Rows[0].ItemArray[46].ToString();
        //   lbwaluj.Text = ds.Tables[0].Rows[0].ItemArray[47].ToString();



    }

    public void setReceiptData()
    {

        txtinvoice.Text = txtinvoice1;
        runtxt.Text = runtxt1;
        agencyaddtxt.Text = lbagencyaddtxt1;
        agddxt.Text = agddxt1;
        lb_totalamt.Text = lbtotal1;
        lbcityname.Text = lbcityname1;
        runtxt.Text = runtxt1;
        txtpinno.Text = lbpinno1;
        lblgross.Text = lbtotal1;
        dynamictable.Text = dynamictable1;
        adcat.Text = lbadcattxt1;
        lblpubname.Text = lblpubname1;
        ldduedate.Text = ldduedate1;
        //EOU.Text = EOU1;
        //lbemail.Text = lbemail1;
        //lbemailtxt.Text = lbemail2;
        //lbpune.Text = lbpune1;

        //lbemailtxt.Text = lbemailtxt1;

        //txtinvoice.Text = txtinvoice1;
        lbltradedis.Text = lbltradedis1;
        lbladddis.Text = lbladddis1;
        lblextra.Text = lblextra1;
        lblnetamt.Text = lblnetamt1;
        lblround.Text = lblround1;
        rupeetxt.Text = rupeetxt1;
        if (hidetab1 == "hide")
        {
            totaltab.Attributes.Add("style", "display:none");
            notetab.Attributes.Add("style", "display:none");
            TBL_NEW.Attributes.Add("style", "display:none");
        }
        else
        {
            totaltab.Attributes.Add("style", "display:block");
            notetab.Attributes.Add("style", "display:block");
            TBL_NEW.Attributes.Add("style", "display:none");
        }
        divimg.InnerHtml = imgpath;
    }


}
