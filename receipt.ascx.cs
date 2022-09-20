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

public partial class receipt : System.Web.UI.UserControl
{
        public static string  _lbbranchtxt;
        public static string  _lbclienttxt;
        public static string  _lbdatetxt;

        public static string  _lbrectxt;
        public static string  _lbbilltxt;
        public static string  _lbreceviedtxt;
        public static string  _txtChequeNo;
        public static string  _txtChequeDate;
        public static string  _txtBankName;
        public static string  _lbamounttxt;
        public static string  _lbpaytxt;
        public static string _lbinwordtxt;
        public static string _lbbilltype;
        public receipt()
        {
            _lbbranchtxt="";
            _lbclienttxt="";
            _lbdatetxt="";
            _lbclienttxt="";
            _lbrectxt="";
            _lbbilltxt="";
            _lbreceviedtxt="";
            _txtChequeNo="";
            _txtChequeDate="";
            _txtBankName="";
            _lbamounttxt="";
            _lbpaytxt="";
            _lbinwordtxt = "";
            _lbbilltype = "";
        }
    public string lbbranchtxt1{ get{return  _lbbranchtxt;} set{  _lbbranchtxt = value;}}
    public string lbclienttxt1 { get { return _lbclienttxt; } set { _lbclienttxt = value; } }
    public string lbdatetxt1 { get { return _lbdatetxt; } set { _lbdatetxt = value; } }
    public string lbrectxt1 { get { return _lbrectxt; } set { _lbrectxt = value; } }
    public string lbbilltxt1 { get { return _lbbilltxt; } set { _lbbilltxt = value; } }
    public string lbreceviedtxt1 { get { return _lbreceviedtxt; } set { _lbreceviedtxt = value; } }
    public string txtChequeNo1 { get { return _txtChequeNo; } set { _txtChequeNo = value; } }
    public string txtChequeDate1 { get { return _txtChequeDate; } set { _txtChequeDate = value; } }
    public string txtBankName1 { get { return _txtBankName; } set { _txtBankName = value; } }
    public string lbamounttxt1 { get { return _lbamounttxt; } set { _lbamounttxt = value; } }
    public string lbbilltype1 { get { return _lbbilltype; } set { _lbbilltype = value; } }
    public string lbpaytxt1 { get { return _lbpaytxt; } set { _lbpaytxt = value; } }
    public string lbinwordtxt1 { get { return _lbinwordtxt; } set { _lbinwordtxt = value; } }
   

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        ds.ReadXml(Server.MapPath("XML/classifiedreceipt.xml"));
        //lbcompanynametxt.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        //lbwalujadd.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbbranch.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        lbpro.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        lbdate.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        lbrec.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
        lbrecevied.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
        lbclient.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
        lbpay.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();
        lbbill.Text = ds.Tables[0].Rows[0].ItemArray[31].ToString();
        lbinword.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();
        lbcustsign.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        lbsign.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        lbsubj.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();

        lbwaluj.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString();
        lblChqNo.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        lblChqDt.Text = ds.Tables[0].Rows[0].ItemArray[38].ToString();
        lblBank.Text = ds.Tables[0].Rows[0].ItemArray[39].ToString();
       // lbbilltype.Text = ds.Tables[0].Rows[0].ItemArray[40].ToString();

    }
    public void setReceiptData()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.classifiedreceipt shtr = new NewAdbooking.classesoracle.classifiedreceipt();
            ds = shtr.bindaddress(Session["compcode"].ToString(), Session["center"].ToString(), "", "");


        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Classes.classifiedreceipt shtr = new NewAdbooking.Classes.classifiedreceipt();
            ds = shtr.bindaddress(Session["compcode"].ToString(), Session["center"].ToString(), "", "");


        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["center"].ToString(), "", "" };
            string procedureName = "adgetbindaddress";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        lbcompanynametxt.Text = Session["comp_name"].ToString();
        //lbwalujadd.Text = ds.Tables[0].Rows[0]["Pub_Cent_name"].ToString() + " " + ds.Tables[0].Rows[0]["Add1"].ToString() + " " + ds.Tables[0].Rows[0]["Street"].ToString()
        //    + " " + ds.Tables[0].Rows[0]["Dist_Code"].ToString() + "," + ds.Tables[0].Rows[0]["Zip"].ToString() + "Phone No.=" + ds.Tables[0].Rows[0]["Phone1"].ToString()
        //    + "," + ds.Tables[0].Rows[0]["Phone2"].ToString() + "Fax:=" + ds.Tables[0].Rows[0]["Fax"].ToString() + "&nbsp; Email Id:= " + ds.Tables[0].Rows[0]["EmailID"].ToString();

        lbwalujadd.Text =  ds.Tables[0].Rows[0]["Add1"].ToString() + " " + ds.Tables[0].Rows[0]["Street"].ToString()
            + " " + ds.Tables[0].Rows[0]["Zip"].ToString() + "Phone No.=" + ds.Tables[0].Rows[0]["Phone1"].ToString()
            + "," + ds.Tables[0].Rows[0]["Phone2"].ToString() + "Fax:=" + ds.Tables[0].Rows[0]["Fax"].ToString() + "," + ds.Tables[0].Rows[0]["Fax1"].ToString() + "&nbsp; Email Id:= " + ds.Tables[0].Rows[0]["EmailID"].ToString();
        lbbranchtxt.Text = lbbranchtxt1;
        lbbranchtxt.Text = lbbranchtxt1;
        lbclienttxt.Text=lbclienttxt1;
        lbdatetxt.Text=lbdatetxt1;
        lbclienttxt.Text=lbclienttxt1;
        lbrectxt.Text=lbrectxt1;
        lbbilltxt.Text=lbbilltxt1;
        lbreceviedtxt.Text=lbreceviedtxt1;
        txtChequeNo.Text=txtChequeNo1;
        txtChequeDate.Text=txtChequeDate1;
        txtBankName.Text=txtBankName1;
        lbamounttxt.Text=lbamounttxt1;
       
        lbamounttxt.Text=lbamounttxt1;
        lbpaytxt.Text=lbpaytxt1;
        lbinwordtxt.Text=lbinwordtxt1;
        lbbilltype.Text = lbbilltype1;
    }
}
