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

public partial class Receiptonly : System.Web.UI.Page
{
    string cioid = "";    
    string dytbl = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["compcode"] == null)
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        cioid = Request.QueryString["cioid"].ToString();
        onscreen(cioid, Session["dateformat"].ToString(),"ORIGINAL");
        onscreen(cioid, Session["dateformat"].ToString(),"DUPLICATE");

        string myscript1 = "<script language='Javascript'>";
        myscript1 += "JavaScript: var windowObject = window.self;windowObject.opener = window.self; windowObject.print();";
        myscript1 += "</script>";
        if (!Page.IsStartupScriptRegistered("clientScript"))
        {
            Page.RegisterStartupScript("clientScript", myscript1);
        }

        string myscript = "<script language='Javascript'>";
        myscript += "JavaScript: var windowObject = window.self;windowObject.opener = window.self; windowObject.close();";
        myscript += "</script>";
        if (!Page.IsStartupScriptRegistered("clientScript"))
        {
            Page.RegisterStartupScript("clientScript", myscript);
        }
    }

    private void onscreen(string cioid, string dateformat,string labelval)
    {


        receipt obj_receipt = new receipt();
        obj_receipt = (receipt)Page.LoadControl("receipt.ascx");

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.classifiedreceipt obj = new NewAdbooking.Classes.classifiedreceipt();
            ds = obj.selectreceipt(cioid, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.classifiedreceipt obj = new NewAdbooking.classesoracle.classifiedreceipt();
            ds = obj.selectreceipt(cioid, dateformat);
        }
        else
        {
            /*string[] parameterValueArray = new string[] { cioid, dateformat };
            string procedureName = "websp_receiptnew2";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
            NewAdbooking.classmysql.classifiedreceipt obj = new NewAdbooking.classmysql.classifiedreceipt();
            ds = obj.selectreceipt(cioid, dateformat);
        }
        if(ds.Tables[0].Rows.Count>0)
        {
        obj_receipt.lbbranchtxt1 = ds.Tables[0].Rows[0]["branchname"].ToString();
       // lbprotxt.Text = Request.QueryString["cioid"].ToString();
        obj_receipt.lbclienttxt1 = ds.Tables[0].Rows[0]["Client"].ToString();
        obj_receipt.lbdatetxt1 = ds.Tables[0].Rows[0]["receiptdate"].ToString();
        obj_receipt.lbclienttxt1 = ds.Tables[0].Rows[0]["Client"].ToString();
        //obj_receipt.lbrectxt1 = ds.Tables[0].Rows[0]["recno"].ToString();
        if (ds.Tables[0].Rows[0]["recno"].ToString() != "")
        {
            obj_receipt.lbrectxt1 = ds.Tables[0].Rows[0]["recno"].ToString();
        }
        else
        {
            obj_receipt.lbrectxt1 = Request.QueryString["cioid"].ToString();
        }
        obj_receipt.lbbilltxt1 = "Booking ID :- " + Request.QueryString["cioid"].ToString() + " / " + "RO No :- " + ds.Tables[0].Rows[0]["rono"].ToString();
        obj_receipt.lbreceviedtxt1 = ds.Tables[0].Rows[0]["Agen"].ToString();
        obj_receipt.lbbilltype1 = labelval;
        //Cheque/DD info on receipt
        DataSet ds_rcpt = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster objRcpt = new NewAdbooking.Classes.BookingMaster();
            ds_rcpt = objRcpt.clsChequeInfo(Request.QueryString["compcode"].ToString(), Request.QueryString["rcptno"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster objRcpt = new NewAdbooking.classesoracle.BookingMaster();
            ds_rcpt = objRcpt.clsChequeInfo(Request.QueryString["compcode"].ToString(), Request.QueryString["rcptno"].ToString());
        }
        else
        {
            string[] parameterValueArray = new string[] { Request.QueryString["compcode"].ToString(), Request.QueryString["rcptno"].ToString() };
            string procedureName = "websp_ChequeInfo_websp_ChequeInfo_P";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds_rcpt = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        /*if (ds_rcpt.Tables[0].Rows.Count!=0)
        {
            obj_receipt.txtChequeNo1 = ds_rcpt.Tables[0].Rows[0].ItemArray[0].ToString();
            obj_receipt.txtChequeDate1 = ds_rcpt.Tables[0].Rows[0].ItemArray[1].ToString();
            obj_receipt.txtBankName1 = ds_rcpt.Tables[0].Rows[0].ItemArray[2].ToString();
        }
        */
        if (ds_rcpt.Tables[0].Rows.Count > 0)
        {
            obj_receipt.txtChequeNo1 = ds_rcpt.Tables[0].Rows[0]["CHK_NO"].ToString();
            obj_receipt.txtChequeDate1 = ds_rcpt.Tables[0].Rows[0]["CHK_DATE"].ToString();
            obj_receipt.txtBankName1 = ds_rcpt.Tables[0].Rows[0]["CHK_BANK_NAME"].ToString();
            obj_receipt.lbamounttxt1 = ds_rcpt.Tables[0].Rows[0]["bilamt"].ToString();


            if (obj_receipt.lbamounttxt1.IndexOf(".") < 0)
                obj_receipt.lbamounttxt1 = obj_receipt.lbamounttxt1 + ".00";
            obj_receipt.lbpaytxt1 = ds_rcpt.Tables[0].Rows[0]["Payment_Mode_Name"].ToString();

            NumberToEngish objwords = new NumberToEngish();
            obj_receipt.lbinwordtxt1 = objwords.changeNumericToWords(obj_receipt.lbamounttxt1) + "Only";
        }
        if (ds.Tables[0].Rows[0]["bilamt"].ToString() != "")
        {
            obj_receipt.lbamounttxt1 = ds.Tables[0].Rows[0]["bilamt"].ToString();
            if (obj_receipt.lbamounttxt1.IndexOf(".") < 0)
                obj_receipt.lbamounttxt1 = obj_receipt.lbamounttxt1 + ".00";

            NumberToEngish objwords = new NumberToEngish();
            obj_receipt.lbinwordtxt1 = objwords.changeNumericToWords(obj_receipt.lbamounttxt1) + "Only";
        }
        obj_receipt.setReceiptData();
        receipt_con.Controls.Add(obj_receipt);
      
        /////////////////////////////////////////// dynamic table  ***************

    }
}
}
