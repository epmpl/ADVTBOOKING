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

public partial class printcoverletter : System.Web.UI.UserControl
{



    public string _centername;
    public string _telephonenumber;
    public string _agddxt;
    public string _lbaddress; 
    public string _billno;
    public string _billdate;
    public string _billamount;
    public string _billedition;
    public string _billrefrence;
    public string _billrono;
    public string _lbrundate;
    public printcoverletter()
    {
        _centername = "";
        _telephonenumber= "";
        _agddxt= "";
        _lbaddress= "";
        _billno= "";
        _billdate= "";
        _billamount= "";
        _billedition= "";
        _billrefrence= "";
        _billrono = "";
        _lbrundate="";

     }


    public string centername { get { return _centername; } set { _centername = value; } }
    public string telephonenumber { get { return _telephonenumber; } set { _telephonenumber = value; } }

    public string agddxt1 { get { return _agddxt; } set { _agddxt = value; } }
    public string lbaddress { get { return _lbaddress; } set { _lbaddress = value; } }

    public string billno { get { return _billno; } set { _billno = value; } }
    public string billdate { get { return _billdate; } set { _billdate = value; } }

    public string billamount { get { return _billamount; } set { _billamount = value; } }
    public string billedition { get { return _billedition; } set { _billedition = value; } }

    public string billrefrence { get { return _billrefrence; } set { _billrefrence = value; } }
    public string billrono { get { return _billrono; } set { _billrono = value; } }
    public string lbrundate1 { get { return _lbrundate; } set { _lbrundate = value; } }

    
  
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void setReceiptData()
    {

        lb_center.Text = centername;
        lb_telephone.Text = telephonenumber; 


        lb_agency.Text = agddxt1;
        lb_agencyadd.Text = lbaddress;

        lb_bill.Text = billno;
        lb_billdate.Text = billdate;
        lb_amount.Text = billamount;     
   
        lb_edition.Text = billedition;
        lb_refrence.Text = billrefrence;
        lb_rono.Text = billrono;
        lbrundate.Text = lbrundate1;
             
    }
}
