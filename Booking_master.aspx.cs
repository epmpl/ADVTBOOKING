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
using System.IO;
//using System.Web.Mail;
using FourCPlus.AdBooking.BookingMaster.Oracle;
using FourCPlus.AdBooking.BookingMaster.Sql;
using System.Data.OleDb;
using System.Diagnostics;
using System.Web.SessionState;
using System.Text;
using System.Threading;
using System.Linq;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
public partial class Booking_master : System.Web.UI.Page
{
    const string passphrase = "password";
    int z = 0;
    int cou = 0;
    string sDate = "";
    string[] arrfor_uom;
    string message = "";
    static string saveormodify = "";
    string dateformat = "";
    string formname = "";
    static string modifyrateaudit = "";
    static int FlagStatus, fpnl;
    static DataSet executequery = new DataSet();
    static string gciobookid = "";
    string getdatecheck = "";
    string rategr = "";
    static string ip = "";
    string agencyrate = "";
    string clientrate = "";
    string insertstatus;
    string hidReceipt = "";
    int i = 0;
    static string grono = "";
    static string gdockitno = "";
    static string gkeyno = "";
    static string gagencyscode = "";
    static string gclient = "";
    string globalid = "";
    string Mobno = "", ag_EmailID = "", id = "", ro_no = "", adsize = "", no_of_insertion = "", gross_amount = "";
    string agreed_ratem = "", agreed_amountm = "";
    string sms_link, uid, pwd, sender;

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Booking_master), "ShowAlert", strAlert, true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        hiddenuomdesc.Value = "CD";
        hdndepo.Value = ConfigurationSettings.AppSettings["center"].ToString();
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your Session Has Been Expired');window.close();</script>");
            return;
        }
        if (Request.QueryString["rateauditflag"] != null)
        {
            hiddenrateauditflag.Value = Request.QueryString["rateauditflag"].ToString();
        }
        else
        {
            hiddenrateauditflag.Value = "";
        }
        if (Request.QueryString["Billhold"] != null)
        {
            Hiddenbillclear.Value = Request.QueryString["Billhold"].ToString();
        }
        else
        {
            Hiddenbillclear.Value = "";
        }
        if (Request.QueryString["quotation"] != null)
        {
            hiddenquotation.Value = Request.QueryString["quotation"].ToString();
        }
        else
        {
            tremail.Attributes.Add("style", "display:none");
            hiddenquotation.Value = "";
        }
        if (Request.QueryString["supplimentflag"] != null)
        {
            hiddensupplimentflag.Value = Request.QueryString["supplimentflag"].ToString();
            hiddensupplementbillno.Value = Request.QueryString["billno"].ToString();
            hiddensupplementbilldate.Value = Request.QueryString["billdate"].ToString();
        }
        else
        {
            hiddensupplimentflag.Value = "";
            hiddensupplementbillno.Value = "";
            hiddensupplementbilldate.Value = "";
        }
        if (hiddenrateauditflag.Value == "rateaudit")
        {
            modifyrateaudit = "Y";
        }

        ip = this.Page.Request.ServerVariables["REMOTE_ADDR"];
        if (hiddenquotation.Value == "Q")
        {
            if (Request.QueryString["ADTYPE"] == "IN0")
            {
                bookingformname1.Text = "Insert Quotation";
                hdnallformname.Value = "InsertQuotation";
                formname = "InsertQuotation";
            }
            else if (Request.QueryString["ADTYPE"] == "WE0")
            {
                bookingformname1.Text = "Web Quotation";
                hdnallformname.Value = "WebQuotation";
                formname = "WebQuotation";
            }
            else
            {
                bookingformname1.Text = "Display Quotation";
                hdnallformname.Value = "DisplayQuotation";
                formname = "DisplayQuotation";
            }

        }
        else
        {
            if (Request.QueryString["ADTYPE"] == "IN0")
            {
                bookingformname1.Text = "Insert Booking";
                hdnallformname.Value = "InsertBooking";
                formname = "InsertBooking";
            }
            else if (Request.QueryString["ADTYPE"] == "WE0")
            {
                bookingformname1.Text = "Web Booking";
                hdnallformname.Value = "WebBooking";
                formname = "WebBooking";
            }
            else
            {
                bookingformname1.Text = "Display Booking";
                hdnallformname.Value = "Booking_master";
                formname = "Booking_master";
            }
        }
        DateTime dt12 = DateTime.Now;
        sDate = dt12.ToShortDateString();
        hdnsysdate.Value = sDate;

        Ajax.Utility.RegisterTypeForAjax(typeof(Booking_master));


        hiddenserverip.Value = Request.ServerVariables["REMOTE_ADDR"].ToString();
        hiddeninsertwise.Value = ConfigurationManager.AppSettings["boxchrginsertwise"].ToString();
        hiddenvaliddate.Value = Session["validdate_pub"].ToString();
        DataSet ds = new DataSet();
        hiddenconnect.Value = ConfigurationSettings.AppSettings["ConnectionType"].ToString().ToLower();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster Show_NoAd = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = Show_NoAd.clsShow_NoAd();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster Show_NoAd = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            ds = Show_NoAd.clsShow_NoAd();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            //string[] parameterValueArray = new string[] { };
            //string procedureName = "websp_tempdata_websp_tempdata_p";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            NewAdbooking.classmysql.BookingMaster Show_NoAd = new NewAdbooking.classmysql.BookingMaster();
            ds = Show_NoAd.clsShow_NoAd();
        }
        grd_SpaceCheck.DataSource = ds;
        grd_SpaceCheck.DataBind();
        GridView1.DataSource = ds;
        GridView1.DataBind();
        configclient.Value = ConfigurationSettings.AppSettings["CLIENTNAME"].ToString();
        dateformat = Session["dateformat"].ToString();
        hiddenconnect.Value = ConfigurationSettings.AppSettings["ConnectionType"].ToString().ToLower();
        formname = "Booking_master";
        hiddenuserdisc.Value = Session["USERDISCOUNT"].ToString();
        hiddenschemetype.Value = Session["SCHEME_TYPE"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        hiddentfn.Value = Session["tfn"].ToString();
        hiddeninserts.Value = Session["insertsbreakup"].ToString();
        hiddencurrency.Value = Session["currency"].ToString();
        hidcurr.Value = Session["currency"].ToString();
        hiddenpremtype.Value = Session["premtype"].ToString();
        hiddentype.Value = Session["dealtype"].ToString();
        hiddenprefix.Value = Session["prefix"].ToString();
        hiddensufix.Value = Session["suffix"].ToString();
        hidcash.Value = Session["DISP_CASHBILL"].ToString();
        hiddenroadcat.Value = Session["roadcat"].ToString();
        hiddenrodatetime.Value = Session["rodatetime"].ToString();
        hiddenspacearea.Value = Session["spacearea"].ToString();
        hiddenvat.Value = Session["vat"].ToString();
        hiddencirculation.Value = Session["solorate"].ToString();
        hiddenprereceipt.Value = Session["Receipt_no"].ToString();
        hiddenroduplicacycheck.Value = Session["CHECKRODUPLICACY"].ToString();

        hiddenadtype.Value = "DI0";
        if (Request.QueryString["ADTYPE"] != null)
        {
            hiddenadtype.Value = Request.QueryString["ADTYPE"].ToString();
        }
        else
        {
            hiddenadtype.Value = "DI0";
        }
        hiddenratecheckdate.Value = Session["RATE_CHECK"].ToString();
        hiddenratepremtype.Value = Session["ratepremtype"].ToString();
        hiddenusername.Value = Session["username"].ToString();
        hiddenuom.Value = Session["uom"].ToString();
        hiddencenter.Value = Session["center"].ToString();
        hiddencioidformat.Value = Session["cioid"].ToString();
        hiddenrostatus.Value = Session["rostatus"].ToString();
        hdnfollodate.Value = Session["ALLOW_FOLLOW_DT_BOOOK"].ToString();


        hiddenappserverpath.Value = Server.MapPath("temppdf/");//ConfigurationSettings.AppSettings["applicationpath"].ToString();
        //   hiddenappserverpath.Value =  "./temppdf/";
        //This code reads the label name from the xml file
        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
        objDataSetbu.ReadXml(Server.MapPath("XML/button.xml"));
        btnNew.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
        btnSave.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        btnModify.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
        btnQuery.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[3].ToString();
        btnExecute.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        btnCancel.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
        btnfirst.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString();
        btnprevious.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();
        btnnext.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();
        btnlast.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString();
        btnDelete.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[10].ToString();
        btnExit.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[11].ToString();

        //////get the label name from xml
        DataSet objDatagetlabname = new DataSet();
        objDatagetlabname.ReadXml(Server.MapPath("XML/bookingmaster.xml"));

        lbdatetime.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[0].ToString();
        lbbranch.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[1].ToString();
        lbbookedby.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[2].ToString();
        lbcioid.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[3].ToString();
        //  lbappby.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[4].ToString();
        //lbaudit.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[5].ToString();
        lbrono.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[6].ToString();
        lbrodate.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[7].ToString();
        lbcaption.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[8].ToString();
        lbbillstatus.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[9].ToString();
        lbrostatus.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[10].ToString();
        lbagency.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[14].ToString();
        lbclient.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[12].ToString();
        lbaaddress.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[13].ToString();
        lbcaddress.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[13].ToString();
        lbagescode.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[11].ToString();
        lbdockit.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[15].ToString();
        lbececname.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[16].ToString();
        lbexeczone.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[17].ToString();
        lbproduct.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[18].ToString();
        lbbrand.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[19].ToString();
        lbkey.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[20].ToString();
        lbbillremark.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[21].ToString();
        lbprintremark.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[22].ToString();
        lbpackage.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[42].ToString();
        //lbselectdate.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[43].ToString();
        lbnoofins.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[44].ToString();
        lbrepdate.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[45].ToString();
        lbadtype.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[23].ToString();
        lbadcat.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[24].ToString();
        lbadscat.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[25].ToString();
        lbcolor.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[26].ToString();
        lbuom.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[27].ToString();
        lbpagepost.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[28].ToString();
        lbpagetyp.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[29].ToString();
        lbpageno.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[30].ToString();
        lbadsizetype.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[31].ToString();
        lbadsize.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[33].ToString();
        lbratecode.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[34].ToString();
        lbscheme.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[35].ToString();
        // lbscty.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[35].ToString();
        lbcurrency.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[36].ToString();
        lbagreed.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[37].ToString();
        lbagreamo.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[38].ToString();
        lbspecialamo.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[39].ToString();
        lbspace.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[40].ToString();
        lbspechar.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[41].ToString();

        LinkButton1.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[46].ToString();
        LinkButton2.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[47].ToString();
        LinkButton3.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[48].ToString();
        LinkButton4.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[49].ToString();
        LinkButton5.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[50].ToString();
        LinkButton6.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[74].ToString();

        lblbillcycle.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[51].ToString();
        lblrevenuecenter.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[52].ToString();
        lblpaymenttype.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[53].ToString();
        lblinvoice.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[54].ToString();
        lblvts.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[55].ToString();
        lblbillsize.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[56].ToString();
        lblbillto.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[57].ToString();
        lbltradedisc.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[58].ToString();
        lblagencyoutstand.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[59].ToString();
        lblagencytype.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[60].ToString();
        lblagencystatus.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[61].ToString();
        lblagencypaymode.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[62].ToString();
        lblagencycreditperiod.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[63].ToString();
        lblcardrate.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[64].ToString();
        lblcardamt.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[65].ToString();
        lbldiscount.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[66].ToString();
        lbldiscpre.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[67].ToString();
        lblbilladdress.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[68].ToString();
        lbboxcode.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[69].ToString();
        lbboxno.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[70].ToString();
        lbboxadd.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[71].ToString();
        chkage.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[72].ToString();
        chkclie.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[73].ToString();
        lbad.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[75].ToString();
        lbcamp.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[76].ToString();
        lbbillamt.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[77].ToString();
        lbpageprem.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[78].ToString();
        lbpagepostamt.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[79].ToString();
        lbpremium.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[80].ToString();
        lbgrossamt.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[81].ToString();
        lbcolumn.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[82].ToString();
        // lbbillcolumn.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[82].ToString();
        // lbbillarea.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[83].ToString();
        lbspediscper.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[84].ToString();
        lbspadiscper.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[85].ToString();
        lbpaid.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[86].ToString();
        lbpreid.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[87].ToString();
        btndeal.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[88].ToString();
        lbdealtype.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[89].ToString();
        lbdeviation.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[90].ToString();
        lbcoupan.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[91].ToString();
        lbvarient.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[92].ToString();
        lbcontractname.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[93].ToString();
        lbcontracttype.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[94].ToString();
        lbcardname.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[95].ToString();
        lbtype.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[96].ToString();
        lbexdate.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[97].ToString();
        lbcardno.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[98].ToString();
        lbreceipt.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[99].ToString();
        lbprint.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[100].ToString();
        lbselectdate.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[101].ToString();
        LinkButton7.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[108].ToString();
        lbmat.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[109].ToString();
        lblretainer.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[110].ToString();
        //Cheque / DD info
        lbchqno.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[111].ToString();
        lbchqamt.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[112].ToString();
        lbchqdate.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[113].ToString();
        lbbankname.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[114].ToString();
        lblcashrecieved.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[119].ToString();

        lblciragency.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[120].ToString();
        lblcirrate.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[121].ToString();
        lblciredition.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[122].ToString();
        lblbartertype.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[123].ToString();
        lbldiscountprem.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[124].ToString();
        lbladon.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[126].ToString();
        lbreference.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[127].ToString();
        btnrefid.Value = objDatagetlabname.Tables[0].Rows[0].ItemArray[128].ToString();
        lbrptcurrency.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[129].ToString();
        lbmobileno.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[130].ToString();
        lblagaddf2.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[131].ToString();
        lblagencyaddcomm.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[132].ToString();
        lblRetainercomm.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[133].ToString();
        lbltranslation.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[134].ToString();
        lbltranslationcharges.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[135].ToString();
        hdndefpayment.Value = objDatagetlabname.Tables[1].Rows[0].ItemArray[3].ToString();
        lbltranslationdisc.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[136].ToString();
        lblpospremdisc.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[137].ToString();
        lblclientcatdisc.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[140].ToString();
        lblclientcatamt.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[141].ToString();
        lblflatfreqdisc.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[142].ToString();
        lblflatfreqamt.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[143].ToString();
        lblcatdisc.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[144].ToString();
        lblcatamt.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[145].ToString();
        //////////////anuja////////////
        lblindustry.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[150].ToString();
        lblproductcat.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[151].ToString();
        //btnmail.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[152].ToString();

        hdntxttranslationdisc.Value = objDatagetlabname.Tables[2].Rows[0].ItemArray[3].ToString();
        hdntxtpospremdisc.Value = objDatagetlabname.Tables[2].Rows[0].ItemArray[4].ToString();
        hdntxtpremper.Value = objDatagetlabname.Tables[2].Rows[0].ItemArray[5].ToString();
        hdntxtspediscper.Value = objDatagetlabname.Tables[2].Rows[0].ItemArray[6].ToString();
        hdntxtspacedisc.Value = objDatagetlabname.Tables[2].Rows[0].ItemArray[7].ToString();
        hdntxtaddagencycommrate.Value = objDatagetlabname.Tables[2].Rows[0].ItemArray[8].ToString();
        hdntxtextracharges.Value = objDatagetlabname.Tables[2].Rows[0].ItemArray[9].ToString();
        hdntxtspedisc.Value = objDatagetlabname.Tables[2].Rows[0].ItemArray[10].ToString();
        hdntxtspadiscper.Value = objDatagetlabname.Tables[2].Rows[0].ItemArray[11].ToString();
        hdnbranchf2req.Value = objDatagetlabname.Tables[2].Rows[0].ItemArray[13].ToString();
        lblcontact.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[154].ToString();
        lblmailid.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[155].ToString();

        if (hdnbranchf2req.Value == "Y")
        {
            lblrevenuecenternew.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[153].ToString();
        }
        else
        {
            lblrevenuecenternew.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[154].ToString();
        }
        lbbranch.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[1].ToString();

        if (objDatagetlabname.Tables.Count > 1)
        {
            if (objDatagetlabname.Tables[1].Rows[0].ItemArray[0].ToString() == "hide")
            {
                Button1.Attributes.Add("style", "display:none");

            }
        }
        if (objDatagetlabname.Tables.Count > 1)
        {
            if (objDatagetlabname.Tables[1].Rows[0].ItemArray[5].ToString() == "hide")
            {
                translation.Attributes.Add("style", "display:none");

            }
            if (objDatagetlabname.Tables[1].Rows[0].ItemArray[6].ToString() == "hide")
            {
                translationdisc.Attributes.Add("style", "display:none");

            }
        }

        if (objDatagetlabname.Tables[1].Rows[0].ItemArray[1].ToString() != "Y")
        {
            Imgadvance.Attributes.Add("style", "display:none");

        }
        if (objDatagetlabname.Tables[1].Rows[0].ItemArray[2].ToString() != "Y")
        {
            agremark.Attributes.Add("style", "display:none");
            clientremark.Attributes.Add("style", "display:none");

        }
        //if (hdnrevise.Value == "")
        //{
        //    btnrevise.Attributes.Add("style", "display:none");
        //}
        if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() != "UD")
        {
            drpregular.Attributes.Add("style", "display:none");
        }
        ///////this code is to show the user's previous booking and the branch
        DataSet dprv = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking prev = new NewAdbooking.Classes.adbooking();
            //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), hiddenadtype.Value, hiddenquotation.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            // NewAdbooking.classesoracle.adbooking prev = new NewAdbooking.classesoracle.adbooking();
            dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), hiddenadtype.Value);
        }
        else
        {
            //string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), hiddenadtype.Value };
            //string procedureName = "gettheprevbooking_gettheprevbooking_p";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //dprv = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            NewAdbooking.classmysql.BookingMaster prev = new NewAdbooking.classmysql.BookingMaster();
            dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), hiddenadtype.Value);
        }
        if (dprv.Tables[0].Rows.Count > 0)
        {
            txtprevbook.Text = dprv.Tables[0].Rows[0].ItemArray[0].ToString();

        }
        else
        {
            txtprevbook.Text = "";
        }

        ///////this code is to show the user's Branch Name
        DataSet dsbranch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getbranch = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dsbranch = getbranch.getbranchname(Session["compcode"].ToString(), Session["revenue"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getbranch = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dsbranch = getbranch.getbranchname(Session["compcode"].ToString(), Session["revenue"].ToString());
        }
        else
        {
            //string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["revenue"].ToString() };
            //string procedureName = "AD_GET_BRANCH_NAME";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //dsbranch = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            NewAdbooking.classmysql.BookingMaster getbranch = new NewAdbooking.classmysql.BookingMaster();
            dsbranch = getbranch.getbranchname(Session["compcode"].ToString(), Session["revenue"].ToString());
        }
        if (dsbranch.Tables[0].Rows.Count > 0)
        {
            txtbranch_name.Text = dsbranch.Tables[0].Rows[0].ItemArray[0].ToString();
            hdnbbrnch.Value = dsbranch.Tables[0].Rows[0].ItemArray[0].ToString();
            hdnbranch_name.Value = dsbranch.Tables[0].Rows[0].ItemArray[1].ToString();
            txtrevenuecenternew.Text = dsbranch.Tables[0].Rows[0].ItemArray[2].ToString();
            hdnrevenuecentcd.Value = dsbranch.Tables[0].Rows[0].ItemArray[3].ToString();
            hdnloginrevcentname.Value = dsbranch.Tables[0].Rows[0].ItemArray[2].ToString();
            hdnloginrevcentcd.Value = dsbranch.Tables[0].Rows[0].ItemArray[3].ToString();
        }

        ///////this is to get that whether the user can do the backdate booking 
        ///if it is 0 than backdate booking is not possible and if 1 than it can be

        if (dprv.Tables[2].Rows.Count > 0)
        {
            hiddenbackdatebook.Value = dprv.Tables[2].Rows[0].ItemArray[0].ToString();
            agncomm_seq_com.Value = dprv.Tables[2].Rows[0].ItemArray[1].ToString();
            creditreceipt_allow.Value = dprv.Tables[2].Rows[0].ItemArray[2].ToString();
            hidbackdatereceipt.Value = dprv.Tables[2].Rows[0].ItemArray[3].ToString();
            hiddencopybooking.Value = dprv.Tables[2].Rows[0].ItemArray[5].ToString();
            hiddencutofftime.Value = dprv.Tables[2].Rows[0].ItemArray[6].ToString();
            hiddensepcashier.Value = dprv.Tables[2].Rows[0].ItemArray[7].ToString();
            if (dprv.Tables[2].Rows[0].ItemArray[8].ToString() != "")
                hiddenmaxdays.Value = dprv.Tables[2].Rows[0].ItemArray[8].ToString();
            else
                hiddenmaxdays.Value = "0";
            hidspldisedit.Value = dprv.Tables[2].Rows[0].ItemArray[9].ToString();
            hidshareman.Value = dprv.Tables[2].Rows[0].ItemArray[10].ToString();
            hidmultisel.Value = dprv.Tables[2].Rows[0].ItemArray[11].ToString();
            hidspltd.Value = dprv.Tables[2].Rows[0].ItemArray[13].ToString();
            hiddenrateauditpreferrence.Value = dprv.Tables[2].Rows[0].ItemArray[14].ToString();
            hidpremedit.Value = dprv.Tables[2].Rows[0].ItemArray[15].ToString();
            hidsplpremdiscallow.Value = dprv.Tables[2].Rows[0].ItemArray[16].ToString();
            hiddeneiitagcomm.Value = dprv.Tables[2].Rows[0].ItemArray[17].ToString();
            hiddencancelcharge.Value = dprv.Tables[2].Rows[0].ItemArray[18].ToString();
            allowprem_card_disc_rate.Value = dprv.Tables[2].Rows[0]["ALLOWPREM_CARD_DISC_RATE"].ToString();
            hdnprefcomngrd.Value = dprv.Tables[2].Rows[0]["COMMON_GRID_ALLOW"].ToString();
        }
        if (hdndepo.Value == "depo" && dprv.Tables[5].Rows.Count > 0)
        {
            if (Session["agency_name"].ToString() == "0")
            {
                txtagency.Text = "";
                txtagencyaddress.Text = "";
            }
            else
            {
                txtagency.Text = dprv.Tables[5].Rows[0].ItemArray[0].ToString();
                txtagencyaddress.Text = dprv.Tables[5].Rows[0]["address"].ToString();
            }
            hdnagencyname.Value = dprv.Tables[5].Rows[0].ItemArray[0].ToString();
            hdnagencyaddress.Value = dprv.Tables[5].Rows[0]["address"].ToString();
        }
        //lab
        //if (!IsPostBack)
        //{
        //    // Validate initially to force asterisks
        //    // to appear before the first roundtrip.
        //    Validate();
        //}
        if (!Page.IsPostBack)
        {


            //multi_bill
            multibilling.Attributes.Add("OnClick", "javascript:return multibilling_grid();");
            lstclient_multibilling.Attributes.Add("onclick", "javascript:return fillclient(event);");

            //send for sms
            hdn_sms_link.Value = ConfigurationSettings.AppSettings["sms_link"].ToString();
            hdn_uid.Value = ConfigurationSettings.AppSettings["uid"].ToString().ToLower();
            hdn_pwd.Value = ConfigurationSettings.AppSettings["pwd"].ToString().ToLower();
            hdn_sender.Value = ConfigurationSettings.AppSettings["sender"].ToString();

            if (Request.QueryString["form"] == "Modify Master")
            {
                txtciobookid.Enabled = true;
                Hdnmodbook.Value = "modify";
                //  ClientScript.RegisterStartupScript(GetType(), "id", "queryClick()", true);
                //  Page.ClientScript.RegisterClientScriptBlock(typeof(ScriptManager), "CallMyMethod", "queryClick();");

            }

            if (Session["addAgencyComm"].ToString() == "N")
            {
                addagency.Visible = false;
                addagencycomm.Visible = false;
            }
            lstcap.Attributes.Add("onkeydown", "javascript:return capnamelst(event);");
            lstcap.Attributes.Add("OnClick", "javascript:return capnamelst(event);");

            hiddenaddAgencyComm.Value = Session["addAgencyComm"].ToString();  //*14 Oct

            hiddenafency_retainer.Value = Session["addAgencyComm_Ret"].ToString();
            //btnRefresh.Attributes.Add("OnClick", "javascript:return draw_LoadControls();");
            btnRefresh.Attributes.Add("OnClick", "javascript:return getButtonId();");

            btnPaginate.Attributes.Add("OnClick", "javascript:return Paginate();");
            Panel1.Attributes.Add("OnClick", "javascript:return getImageId();");
            // Form1.Attributes.Add("OnClick", "javascript:return getButtonId();");

            LinkButton1.Enabled = false;
            LinkButton2.Enabled = false;
            LinkButton3.Enabled = false;
            LinkButton4.Enabled = false;
            LinkButton5.Enabled = false;
            LinkButton6.Enabled = false;
            LinkButton7.Enabled = false;
            agremark.Attributes.Add("onmouseover", "opentooltip(event,'Agency');");
            agremark.Attributes.Add("onmouseout", "HideTooltip();");
            clientremark.Attributes.Add("onmouseover", "opentooltip(event,'Client');");
            clientremark.Attributes.Add("onmouseout", "HideTooltip();");

            txtprintremark.Attributes.Add("onchange", "javascript:return getremarkintogrid('remark');");
            txtcaption.Attributes.Add("onchange", "javascript:return getremarkintogrid('caption');");
            btnagencysearch.Attributes.Add("OnClick", "javascript:return searchagency();");
            btnclientsearch.Attributes.Add("OnClick", "javascript:return searchclient();");
            close1.Attributes.Add("OnClick", "javascript:return closediv();");
            close2.Attributes.Add("OnClick", "javascript:return closediv1();");
            btnrefid.Attributes.Add("OnClick", "javascript:return openRefID();");
            chkadon.Attributes.Add("OnClick", "javascript:return adonChange();");
            chkDealerPanel.Attributes.Add("OnClick", "javascript:return enableDealerPanel();");
            //   txtciragency.Attributes.Add("OnBlur", "javascript:return checkCirValidAgency();");
            btnfmg.Attributes.Add("OnClick", "javascript:return openFMGRef();");
            //btnrevise.Attributes.Add("OnClick", "javascript:return openRevisepopup();");
            //btnmulti.Attributes.Add("OnClick", "javascript:return openmultiselect();"); 
            btnsharing.Attributes.Add("OnClick", "javascript:return openPubPrecentage();");
            drpdiscountprem.Attributes.Add("OnChange", "javascript:return getDiscPrem();");
            txtcashdiscount.Attributes.Add("OnChange", "javascript:return blankAmount();");
            txttranslationdisc.Attributes.Add("OnChange", "javascript:return blankAmount();");
            txtpospremdisc.Attributes.Add("OnChange", "javascript:return blankAmount();");
            attachment1.Attributes.Add("OnClick", "javascript:return openattach1();");
            attachment2.Attributes.Add("OnClick", "javascript:return openattach2();");
            btnPreference.Attributes.Add("OnClick", "javascript:return chkBookingInfo();");
            drpadstype.Attributes.Add("OnChange", "javascript:return getHeightWidth();");
            txtRetainercomm.Attributes.Add("OnChange", "javascript:return getRetainerCommAmt();");
            txtaddagencycommrateamt.Attributes.Add("OnChange", "javascript:return getAddlAgencyComm();");
            drpadcategory.Attributes.Add("onkeypress", "return keySort(this);");
            drpadsubcategory.Attributes.Add("onkeypress", "return keySort(this);");
            drpadcat3.Attributes.Add("onkeypress", "return keySort(this);");
            drpadcat4.Attributes.Add("onkeypress", "return keySort(this);");
            drpadcat5.Attributes.Add("onkeypress", "return keySort(this);");
            btnSpaceCheck.Attributes.Add("OnClick", "javascript:return getSpaceAvailability();");
            hidehref.Attributes.Add("onclick", "javascript:return Hide();");
            btndeal.Attributes.Add("onclick", "javascript:return showdealvalue();");
            drprostatus.Attributes.Add("onchange", "javascript:return chkrodate();");
            txtrevenuecenternew.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drprostatus.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpretainer.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            //drpretainer.Attributes.Add("onblur", "javascript:return chkExecutive();");
            btnPaginatedVol.Attributes.Add("OnClick", "javascript:return getPaginatedVol();");
            drpretainer.Attributes.Add("onblur", "javascript:return chkExecutive();");

            //*6Aug*
            lstretainer.Attributes.Add("onclick", "javascript:return showretainervalue(this);");
            ///////////////////////////////////////////
            txtrono.Attributes.Add("onchange", "javascript:return disabledokit();");
            txtrono.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtdockitno1.Attributes.Add("onchange", "javascript:return disablerono();");
            txtdockitno1.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtagencypaymode.Attributes.Add("onchange", "javascript:return getintohidden();");
            txtagencypaymode.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtcouno.Attributes.Add("onchange", "javascript:return coupancheck();");
            txtrepeatingdate.Attributes.Add("OnKeyPress", "javascript:return checkdateInsert();");
            txtrepeatingdate.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtrepeatingdate.Attributes.Add("OnKeydown", "javascript:return checknumeric();");

            //  drppackage.Attributes.Add("onkeypress", "return keySort(this);");
            drppackage.Attributes.Add("onkeypress", "return keySort(this);");
            drppackage.Attributes.Add("onBlur", "return lostfocusPackage(this);");
            drppackage.Attributes.Add("onfocus", "javascript:return getfocusPackage(this);");
            // txtrepeatingdate.Attributes.Add("OnChange", "javascript:return onInsertionChange();");
            txtrepeatingdate.Attributes.Add("OnChange", "javascript:return onRepeatingDate();");

            txtinsertion.Attributes.Add("OnChange", "javascript:return onInsertionChange('txtinsertion');");
            txtinsertion.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            hiddendateformat.Value = Session["dateformat"].ToString();

            btnSave.Attributes.Add("OnClick", "javascript:return checkValidation();");
            btnsavepaginate.Attributes.Add("OnClick", "javascript:return checkValidation();");
            txtbookedby.Text = Session["username"].ToString();
            hiddencompuser.Value = Session["userhome"].ToString();
            hiddenadmin.Value = Session["Admin"].ToString();
            txttradedisc.Attributes.Add("OnBlur", "javascript:return checkTrade();");
            txttradedisc.Attributes.Add("OnFocus", "javascript:return checkTradeFocus();");
            LinkButton1.Attributes.Add("Onclick", "javascript:return changediv();");
            LinkButton2.Attributes.Add("Onclick", "javascript:return changediv1();");
            LinkButton3.Attributes.Add("Onclick", "javascript:return changebilldiv();");
            LinkButton4.Attributes.Add("Onclick", "javascript:return changedivrate();");
            lstagency.Attributes.Add("onclick", "javascript:return insertagency();");
            lstbrand.Attributes.Add("onclick", "javascript:return insertagency();");
            lstcolexec.Attributes.Add("onclick", "javascript:return insertagency();");
            lstreference.Attributes.Add("onclick", "javascript:return insertagency();");
            lstbarter.Attributes.Add("onclick", "javascript:return insertagency();");
            lstciragency.Attributes.Add("onclick", "javascript:return insertagency();");
            lstcirrate.Attributes.Add("onclick", "javascript:return insertagency();");
            //lstagency.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            lstclient.Attributes.Add("onclick", "javascript:return insertagency();");
            lstexec.Attributes.Add("onclick", "javascript:return insertagency();");
            lstproduct.Attributes.Add("onclick", "javascript:return insertagency();");

            lstrevenuecenternew.Attributes.Add("onclick", "javascript:return insertagency();");


            LinkButton5.Attributes.Add("OnClick", "javascript:return changepackage();");
            LinkButton6.Attributes.Add("OnClick", "javascript:return openboxpopup();");
            LinkButton7.Attributes.Add("onclick", "javascript:return openvts();");
            txtcardrate.Attributes.Add("onchange", "javascript:return getcardamou();");
            txtcardrate.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpregular.Attributes.Add("onchange", "javascript:return clientblank();");////bhanu
            txtadsize1.Attributes.Add("onchange", "javascript:return chkheight();");
            drpbillcycle.Attributes.Add("onchange", "javascript:return blankGross();");
            txtadsize1dealer.Attributes.Add("onchange", "javascript:return blankGrossAmt1();");
            txtadsize2dealer.Attributes.Add("onchange", "javascript:return blankGrossAmt1();");
            txtadsize1.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtadsize2.Attributes.Add("onchange", "javascript:return chkwidth();");
            txtadsize2.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtcolum.Attributes.Add("onchange", "javascript:return getwidth();");
            txtagreedrate.Attributes.Add("onchange", "javascript:return getagreedamt();");    //****
            txtagreedrate.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtagreedamt.Attributes.Add("onchange", "javascript:return getagreedamt();");    //****
            txtagreedamt.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            //            txtrodate.Attributes.Add("OnChange", "javascript:return checkdateforcurr(this);  ");
            txtrodate.Attributes.Add("OnChange", "javascript:return checkdateforcurr(this);  ");
            //txtrevisedate.Attributes.Add("OnChange", "javascript:return checkdateforcurr(this);  ");
            txtdatetime.Attributes.Add("OnBlur", "javascript:return checkdateforDatetime_b(this);");
            txtdatetime.Attributes.Add("OnChange", "javascript:return pagePositionbind();bindpackagedatewise();");
            txtrodate.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtdummydate.Attributes.Add("OnChange", "javascript:return hideCalendar1(this);  ");
            txtdummydate.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            //  btnshgrid.Attributes.Add("OnClick", "javascript:return fillrateintogrid();");      //****
            btnshgrid.Attributes.Add("OnClick", "javascript:return checkGridDate_Validation();");
            txtaddagencycommrate.Attributes.Add("OnChange", "javascript:return addagencycomm();");
            txtaddagencycommrate.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            lstagency.Attributes.Add("onkeypress", "return keySort(this);");
            lstclient.Attributes.Add("onkeypress", "return keySort(this);");
            lstproduct.Attributes.Add("onkeypress", "return keySort(this);");
            lstexec.Attributes.Add("onkeypress", "return keySort(this);");
            //drpagscode.Attributes.Add("onchange", "javascript:return getpayandstatus();");
            chkage.Attributes.Add("onclick", "javascript:return agencychk()");
            chkclie.Attributes.Add("onclick", "javascript:return clientchk()");
            //drpagscode.Attributes.Add("onchange", "javascript:return getsubcode();");
            //    txtratecode.Attributes.Add("onblur", "javascript:return gettherate();");
            txtratecode.Attributes.Add("onchange", "javascript:return rateRefresh();");
            txtratecode.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            //drpcurrency.Attributes.Add("onchange", "javascript:return chkpckforcurr();");
            drpcurrency.Attributes.Add("onchange", "javascript:return getrateoncurrchang();");
            drprptcurrency.Attributes.Add("onchange", "javascript:return blankGrossAmt();");
            drpbrand.Attributes.Add("onchange", "javascript:return getbrand();");
            drpbrand.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtexeczone.Attributes.Add("onchange", "javascript:return getzone();");
            txtexeczone.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpadcategory.Attributes.Add("onblur", "javascript:return filladsubcatmain();");
            drpadcategory.Attributes.Add("OnChange", "javascript:return AdcatChange();");
            drpadcategory.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            //btnupload.Attributes.Add("onclick", "javascript:return uploadimageall();");
            //txtagency.Attributes.Add("onchange", "javascript:return chkagency();");
            //txtagency.Attributes.Add("onBlur", "javascript:return chkmaincodeAgency();");
            drpretainer.Attributes.Add("onchange", "javascript:return chkagency();");
            txtagency.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtproduct.Attributes.Add("onchange", "javascript:return chkagency();");
            txtproduct.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtexecname.Attributes.Add("onchange", "javascript:return chkagency();");
            txtexecname.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drprevenue.Attributes.Add("onchange", "javascript:return blankGross();");
            chktfn.Attributes.Add("onclick", "javascript:return disbledinsertion();");
            drppageprem.Attributes.Add("onchange", "javascript:return getpremper();");
            drppageprem.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drppageposition.Attributes.Add("onchange", "javascript:return getpageamt();");
            drppageposition.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpboxcode.Attributes.Add("onchange", "javascript:return getboxno();");
            drpboxcode.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtbillheight.Attributes.Add("onchange", "javascript:return getbiilablearea();");
            txtbillheight.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtbillwidth.Attributes.Add("onchange", "javascript:return getbiilablearea();");

            txtbillwidth.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtspedisc.Attributes.Add("onchange", "javascript:return getspecialdisc('txtspedisc');");   //****
            txtspedisc.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtspediscper.Attributes.Add("onchange", "javascript:return getspecialdisc('txtspediscper');"); //**** 
            txtspediscper.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtextracharges.Attributes.Add("onchange", "javascript:return getsplchargeBlank();");          //****
            txtextracharges.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtspacedisc.Attributes.Add("onchange", "javascript:return getspacedisc('txtspacedisc');");  //****

            txtspacedisc.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            //  txtspadiscper.Attributes.Add("onchange", "javascript:return getspacedisc('txtspacedisc');");  //****
            txtspadiscper.Attributes.Add("onchange", "javascript:return getspacedisc('txtspadiscper');");
            drpbooktype.Attributes.Add("onBlur", "javascript:return getbillzero();");
            drpbooktype.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");

            drpadsubcategory.Attributes.Add("onBlur", "javascript:return filladscatingrid();");
            drpadsubcategory.Attributes.Add("onfocus", "javascript:return getfocusPackagecat(this);");

            drpadcat3.Attributes.Add("onfocus", "javascript:return getfocusPackagecat(this);");
            drpadcat3.Attributes.Add("onBlur", "javascript:return bindadscat4();");
            drpadcat4.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpadcat4.Attributes.Add("onBlur", "javascript:return bindadcat5();");
            drpadcat5.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");

            drpcolor.Attributes.Add("onchange", "javascript:return fillcoloringrid();");
            drpcolor.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpbrand.Attributes.Add("onchange", "javascript:return bindvarient();");
            drpbrand.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpvarient.Attributes.Add("onchange", "javascript:return getvarval();");
            drpvarient.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtclient.Attributes.Add("onblur", "javascript:return chkcasualclient();");
            txtclient.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            //btncopy.Attributes.Add("onclick", "javascript:return addpkgname();");
            btncopy.Attributes.Add("onclick", "javascript:return Btncopyclick();");
            btndel.Attributes.Add("onclick", "javascript:return removepkgname();");
            showdiv.Attributes.Add("onclick", "javascript:return showstrip();");
            txtclientadd.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtkeyno.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtcamp.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtcaption.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtcaption.Attributes.Add("onBlur", "javascript:return changepackage();");
            txtcolum.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txttotalarea.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtpageno.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpcurrency.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drprptcurrency.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpbillcycle.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drprevenue.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drppaymenttype.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpbillstatus.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpbillto.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpbillto.Attributes.Add("onchange", "javascript:return getvalueintohidden();");

            txtinvoice.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");

            txtvts.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtbilladdress.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtagencyoutstand.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtbillremark.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtprintremark.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpboxcode.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtboxaddress.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drppaymenttype.Attributes.Add("onchange", "javascript:return showcreditdetail();");   //0n24 oct, 09
            btnExit.Attributes.Add("onclick", "javascript:return exitbook();");
            drpmonth.Attributes.Add("onchange", "javascript:return chkyear();");
            drpyear.Attributes.Add("onchange", "javascript:return chkyear();");
            lbprint.Attributes.Add("onclick", "javascript:return printreceipt_display();");
            drpuom.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpuom.Attributes.Add("onchange", "javascript:return getlabeluom();");
            drpmatsta.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpmatsta.Attributes.Add("onchange", "javascript:return setmatstatus();");
            txttotalarea.Attributes.Add("onchange", "javascript:return fillnooflineintogrid();");
            chkcontract.Attributes.Add("onclick", "javascript:return contractapply();");
            ttextchqno.Attributes.Add("OnChange", "javascript:return chkminno();");

            //  btnNew.Attributes.Add("onclick", "javascript:return enableLink();");
            btnNew.Attributes.Add("onclick", "javascript:return newclick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return clearClick();");
            // lstrevenuecenternew.Attributes.Add("onBlur", "javascript:return revenueonblrenableasnew();");
            btnModify.Attributes.Add("OnClick", "javascript:return modifyClick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return queryClick();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstClick();");
            btnlast.Attributes.Add("OnClick", "javascript:return lastClick();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextClick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return previousClick();");
            btnExecute.Attributes.Add("OnClick", "javascript:return executeClick();");
            btnDelete.Attributes.Add("onclick", "javascript:return deleteCheck();");
            txtpageno.Attributes.Add("onchange", "javascript:return fillpgnogrid();");
            drptranslation.Attributes.Add("onBlur", "javascript:return gettrapremium();");
            if (hiddenroduplicacycheck.Value == "Y")
                txtrodate.Attributes.Add("onblur", "javascript:return checkro();");
            else
                txtrono.Attributes.Add("onblur", "javascript:return checkro();");
            ttextchqdate.Attributes.Add("onchange", "javascript:return checkdate(this);");
            Button1.Attributes.Add("onclick", "javascript:return openmultiselect();");
            btnteam.Attributes.Add("onclick", "javascript:return opendivforteam();");
            txtrevisedate.Attributes.Add("OnChange", "javascript:return bindrategroupcodeforreviserate();");
            txtpospremdisc.Attributes.Add("onblur", "javascript:return validation();");
            txttranslationdisc.Attributes.Add("onblur", "javascript:return validation();");
            // ttextchqdate.Attributes.Add("OnChange", "javascript:return checkdateforbook(this);  ");
            regclient.Attributes.Add("OnClick", "javascript:return btnclientreg();");
            drpcoutype.Attributes.Add("OnChange", "javascript:return blankGross()");
            hiddencalendar.Value = "1";
            //LinkButton5.Attributes.Add("Onclick", "javascript:return changedivbill();");
            ///////permission wise
            txtindustry.Attributes.Add("onchange", "javascript:return bindprodcat();");
            lstindus.Attributes.Add("onclick", "javascript:return insertagency();");
            // txtproduct.Attributes.Add("onchange", "javascript:return bindprodcat();");
            lstprosubcat.Attributes.Add("onclick", "javascript:return insertagency();");
            btnmail.Attributes.Add("onclick", "javascript:return funbtnmail();");
            btntempagency.Attributes.Add("onclick", "javascript:return openTempAgencyPopUp();");
            // drpproductcat.Attributes.Add("onchange", "javascript:return bindprodcat();");
            getbuttoncheck(formname);
            txtrevenuecenternew.Attributes.Add("onkeyup", "javascript:return f2query(event);");
            txtquotationno.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");


            // for package main and sub group
            
            lstpackmgrp.Attributes.Add("onclick", "javascript:return insertmaingrp();");
            lstpacksgrp.Attributes.Add("onclick", "javascript:return insertsubgrp();");
            //lstexec.Attributes.Add("onclick", "javascript:return insertagency();");
            
            //lstpackmgrp.Attributes.Add("onkeypress", "return keySort(this);");
            //lstpacksgrp.Attributes.Add("onkeypress", "return keySort(this);");

            txtpackmaingrp.Attributes.Add("onchange", "javascript:return bindpackmaingrp(event);");
            txtpacksubgrp.Attributes.Add("onchange", "javascript:return bindpackmaingrp(event);");

            //lstpackmgrp.Attributes.Add("onkeypress", "return insertmaingrp();");
            //lstpacksgrp.Attributes.Add("onkeypress", "return insertsubgrp();");
            //onclick

            bindbillcycle();

            bindStatus();

            bindrevenuecenter();
            drprevenue.SelectedValue = Session["revenue"].ToString();
            //txtbranch.Text = drprevenue.SelectedItem.Text;
            txtbranch.Text = Session["revenue"].ToString();
            bindbox();
            bindAdType(Session["compcode"].ToString());
            //bindCustomer(Session["compcode"].ToString());
            bindcolor();
            advcat(Session["compcode"].ToString());
            bindpackage();
            binduom();
            //bindpublication();
            //bindpagePosition(Session["compcode"].ToString());
            bindAdSizeType(Session["compcode"].ToString());
            bindDiscPrem(Session["compcode"].ToString());
            bindcurrency();
            bindBillStatus();
            bindpageprem();
            bindtranslation();
            //bindscheme();
            // bindschemepck();
            bindcardtype();
            bindpagetype();
            bindOurBank();
            //bindmatstatus();
            //*6Aug bindretainer();
            ScriptManager1.SetFocus(btnNew);




            // if (Request.QueryString["cioid"] != null)
            if (Request.QueryString["cioid"] != null)
            {
                hiddenaudit.Value = Request.QueryString["cioid"].ToString();

            }
            else
            {
                hiddenaudit.Value = "";
            }

            //bindProduct(Session["compcode"].ToString());
        }

        DateTime dt = DateTime.Now;

        int year = Convert.ToInt32(dt.Year);
        int month = Convert.ToInt32(dt.Month);
        int day = Convert.ToInt32(dt.Day);
        string serdate = Convert.ToString(month + "/" + day + "/" + year);
        datesave getdatechk = new datesave();
        dateinsert getdateshow = new dateinsert();
        DataSet dsdate = new DataSet();
        DataSet per = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //  FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster cls_book = new  FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            NewAdbooking.Classes.BookingMaster cls_book = new NewAdbooking.Classes.BookingMaster();
            dsdate = cls_book.getCurrdate();
            per = cls_book.chkdiscountpremedit_per(hiddenuserid.Value, hiddencompcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {

            //string[] parameterValueArray1 = new string[] { hiddencompcode.Value, hiddenuserid.Value };
            //string procedureName1 = "chkdiscountpremedit_per";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //per = sms.DynamicBindProcedure(procedureName1, parameterValueArray1);

            NewAdbooking.classmysql.BookingMaster cls_book = new NewAdbooking.classmysql.BookingMaster();
            per = cls_book.chkdiscountpremedit_per(hiddencompcode.Value, hiddenuserid.Value);

        }
        else
        {
            //  FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster cls_book = new  FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            NewAdbooking.classesoracle.BookingMaster cls_book = new NewAdbooking.classesoracle.BookingMaster();
            dsdate = cls_book.getCurrdate();
            per = cls_book.chkdiscountpremedit_per(hiddenuserid.Value, hiddencompcode.Value);
        }
        if (per.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < per.Tables[0].Rows.Count; i++)
            {
                if (per.Tables[0].Rows[i].ItemArray[0].ToString() == "Allow Editing Discount Item Line Wise In Transaction")
                    hiddisceditgrid.Value = "Y";
                if (per.Tables[0].Rows[i].ItemArray[0].ToString() == "Enable Adcat and Subcat After Billed")
                    ena_adsubcataftbill.Value = "Y";
                if (per.Tables[0].Rows[i].ItemArray[0].ToString() == "Client Register Required in Transaction")
                    hdnregclient.Value = "Y";
                if (per.Tables[0].Rows[i].ItemArray[0].ToString() == "NPRINT Status in Transaction")
                    hidnprint.Value = "Y";
                if (per.Tables[0].Rows[i].ItemArray[0].ToString() == "Allow change in subedition detail After publish")
                    hdnchkdetailperm.Value = "Y";
                if (per.Tables[0].Rows[i].ItemArray[0].ToString() == "Allow BackDate Booking")
                    hidbackdatereceipt.Value = "y";
                if (per.Tables[0].Rows[i].ItemArray[0].ToString() == "Allow FMG Booking")
                    hidfmgallow.Value = "y";
                if (per.Tables[0].Rows[i].ItemArray[0].ToString() == "Allow Copy Booking")
                    hdncopybookingpermission.Value = "Y";
            }
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            //string[] parameterValueArray = new string[] { };
            //string procedureName = "getCurrDate";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //dsdate = sms.DynamicBindProcedure(procedureName, parameterValueArray);

            NewAdbooking.classmysql.BookingMaster sms = new NewAdbooking.classmysql.BookingMaster();
            dsdate = sms.getCurrdate();

        }
        if (per.Tables[1].Rows.Count > 0)
        {
            allowpaidchangeper.Value = "N";
        }
        if (per.Tables[2].Rows.Count > 0) { }
        else
        {
            billhold.Attributes.Add("style", "display:none");
        }
        day = Convert.ToInt32(dsdate.Tables[0].Rows[0].ItemArray[0].ToString());
        string month1 = dsdate.Tables[0].Rows[0].ItemArray[1].ToString();
        year = Convert.ToInt32(dsdate.Tables[0].Rows[0].ItemArray[2].ToString());
        if (month1.ToString().Length == 1)
            month1 = "0" + month1;

        if (Session["dateformat"].ToString() == "dd/mm/yyyy")
        {
            txtdatetime.Text = day + "/" + month1 + "/" + year;

            getdatecheck = day + "/" + month1 + "/" + year;
        }
        else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
        {
            txtdatetime.Text = year + "/" + month1 + "/" + day;

            getdatecheck = year + "/" + month1 + "/" + day;
        }
        else
        {
            txtdatetime.Text = month1 + "/" + day + "/" + year;//getdateshow.getDate(Session["dateformat"].ToString(), serdate);

            getdatecheck = month1 + "/" + day + "/" + year;//getdatechk.getDate(Session["dateformat"].ToString(), serdate);
        }

        currdate.Value = txtdatetime.Text;
        //Request.QueryString["cioid"] = "CI881";

        //generate receipt format ---------------------------------------------------------        


        DataSet ds_rcpt = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objReceipt = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds_rcpt = objReceipt.clsBranchAlias(Session["compcode"].ToString(), Session["revenue"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objReceipt = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds_rcpt = objReceipt.clsBranchAlias(Session["compcode"].ToString(), Session["revenue"].ToString());
        }
        else
        {
            //string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["revenue"].ToString() };
            //string procedureName = "websp_BranchAlias_websp_BranchAlias_P";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds_rcpt = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            NewAdbooking.classmysql.BookingMaster objReceipt = new NewAdbooking.classmysql.BookingMaster();
            ds_rcpt = objReceipt.clsBranchAlias(Session["compcode"].ToString(), Session["revenue"].ToString());
        }
        hiddenorigbranch.Value = ds_rcpt.Tables[0].Rows[0].ItemArray[1].ToString();
        if (hiddenprereceipt.Value == "5")
        {
            hidReceipt = ds_rcpt.Tables[0].Rows[0].ItemArray[0].ToString() + "/" + year.ToString().Substring(year.ToString().Length - 2) + "-" + Convert.ToInt32(Convert.ToInt32(year.ToString().Substring(year.ToString().Length - 2)) + 1) + "/";
            hiddenhidReceipt.Value = hidReceipt;
        }
        if (hiddenrostatus.Value == "1")
        {
            drprostatus.SelectedValue = "2";
        }
        else
        {
            drprostatus.SelectedValue = "1";
        }
        //if (ConfigurationSettings.AppSettings["Multiexecutive"].ToString() == "Y")
        //    btnmulti.Attributes.Add("style", "height:15px;width:18px;color:red;display:block");
        if (btnNew.Enabled == false)
            btnNew.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[0].ToString();
        if (btnSave.Enabled == false)
            btnSave.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[1].ToString();
        if (btnModify.Enabled == false)
            btnModify.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[2].ToString();
        if (btnQuery.Enabled == false)
            btnQuery.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[3].ToString();
        if (btnExecute.Enabled == false)
            btnExecute.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[4].ToString();
        if (btnCancel.Enabled == false)
            btnCancel.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[5].ToString();
        if (btnfirst.Enabled == false)
            btnfirst.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[6].ToString();
        if (btnprevious.Enabled == false)
            btnprevious.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[7].ToString();
        if (btnnext.Enabled == false)
            btnnext.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[8].ToString();
        if (btnlast.Enabled == false)
            btnlast.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[9].ToString();
        if (btnDelete.Enabled == false)
            btnDelete.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[10].ToString();
        if (btnExit.Enabled == false)
            btnExit.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[11].ToString();
        //********************************
        if (ConfigurationManager.AppSettings["TVURL"] == null || ConfigurationManager.AppSettings["TVURL"].ToString() == "")
        {
            lbladon.Attributes.Add("style", "display:none");
            chkadon.Attributes.Add("style", "display:none");
        }

    }
    public string ConvertToDateTime(string strDateTime)
    {
        string dtFinaldate; string sDateTime;
        if (strDateTime != "")
        {
            string hddndateformat = "dd/mm/yyyy";// Session["dateformat"].ToString();
            try
            {
                if (hddndateformat == "dd/mm/yyyy")
                {
                    string[] sDate = strDateTime.Split('/');
                    sDateTime = sDate[2] + '/' + sDate[1] + '/' + sDate[0];
                    dtFinaldate = sDateTime;
                }
                else
                {
                    dtFinaldate = Convert.ToDateTime(strDateTime).ToString();
                }
            }
            catch (Exception e)
            {
                string[] sDate = strDateTime.Split('/');
                sDateTime = sDate[2] + '/' + sDate[0] + '/' + sDate[1];
                dtFinaldate = sDateTime;
            }
            return dtFinaldate;
        }
        else
        {
            return null;
        }
    }
    public void bindpagetype()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindptyp = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindptyp.book_bindpagetyp(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindptyp = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dx = bindptyp.book_bindpagetyp(Session["compcode"].ToString());
        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            string procedureName = "book_bindpagetyp_book_bindpagetyp_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindptyp = new NewAdbooking.classmysql.BookingMaster();
            //dx = bindptyp.book_bindpagetyp(Session["compcode"].ToString());
        }

        drppagetype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppagetype.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drppagetype.Items.Add(li);
            }

        }



    }



    public void bindcardtype()
    {
        DataSet cardtyp = new DataSet();
        cardtyp.ReadXml(Server.MapPath("XML/billcycle.xml"));
        drptype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Card Type";
        li1.Value = "0";
        //li1.Selected = true;
        drptype.Items.Add(li1);

        for (i = 0; i < cardtyp.Tables[5].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = cardtyp.Tables[5].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = cardtyp.Tables[5].Rows[0].ItemArray[i].ToString();

            drptype.Items.Add(li);

        }

    }
    public void bindOurBank()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dx = bindrate.getOurBank(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindrate.getOurBank(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            string procedureName = "getOurBank";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
            //dx = bindrate.getOurBank(Session["compcode"].ToString());
        }
        drpourbank.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Bank-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpourbank.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpourbank.Items.Add(li);
            }

        }
    }

    public void bindpageprem()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.RateMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.RateMaster();
            dx = bindrate.premiumbind(Session["compcode"].ToString(), hiddenadtype.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster();
            dx = bindrate.premiumbind(Session["compcode"].ToString(), hiddenadtype.Value);
        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), hiddenadtype.Value };
            string procedureName = "bindpremiumforrate_bindpremiumforrate_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.RateMaster bindrate = new NewAdbooking.classmysql.RateMaster();
            //dx = bindrate.premiumbind(Session["compcode"].ToString(), hiddenadtype.Value);
        }

        drppageprem.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Premium-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppageprem.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drppageprem.Items.Add(li);
            }

        }


    }


    //public void bindscheme()
    //{
    //    FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindschem = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
    //    DataSet dsch = new DataSet();
    //    dsch = bindschem.schemebind(Session["compcode"].ToString());

    //    drpscheme.Items.Clear();
    //    int i;
    //    ListItem li1;
    //    li1 = new ListItem();
    //    li1.Text = "-Select Scheme-";
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    drpscheme.Items.Add(li1);

    //    if (dsch.Tables[0].Rows.Count > 0)
    //    {
    //        for (i = 0; i < dsch.Tables[0].Rows.Count; i++)
    //        {
    //            ListItem li;
    //            li = new ListItem();

    //            li.Text = dsch.Tables[0].Rows[i].ItemArray[3].ToString();
    //            li.Value = dsch.Tables[0].Rows[i].ItemArray[4].ToString();
    //            //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
    //            drpscheme.Items.Add(li);
    //        }

    //    }


    //}

    //public void bindschemepck()
    //{

    //    FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindschem = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
    //    DataSet dsch = new DataSet();
    //    dsch = bindschem.schemebind(Session["compcode"].ToString());

    //    drpschemepck.Items.Clear();
    //    int i;
    //    ListItem li1;
    //    li1 = new ListItem();
    //    li1.Text = "-Select Scheme-";
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    drpschemepck.Items.Add(li1);

    //    if (dsch.Tables[0].Rows.Count > 0)
    //    {
    //        for (i = 0; i < dsch.Tables[0].Rows.Count; i++)
    //        {
    //            ListItem li;
    //            li = new ListItem();

    //            li.Text = dsch.Tables[0].Rows[i].ItemArray[3].ToString();
    //            li.Value = dsch.Tables[0].Rows[i].ItemArray[4].ToString();
    //            //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
    //            drpschemepck.Items.Add(li);
    //        }

    //    }


    //}

    public void bindbox()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindboxcode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindboxcode.boxbind(Session["compcode"].ToString(), Session["center"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindboxcode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dx = bindboxcode.boxbind(Session["compcode"].ToString(), Session["center"].ToString());
        }
        else
        {
            //string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["center"].ToString() };
            //string procedureName = "boxbind_boxbind_p";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            NewAdbooking.classmysql.BookingMaster bindboxcode = new NewAdbooking.classmysql.BookingMaster();
            dx = bindboxcode.boxbind(Session["compcode"].ToString(), Session["center"].ToString());
        }

        drpboxcode.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Box-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpboxcode.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpboxcode.Items.Add(li);
            }

        }

    }
    [Ajax.AjaxMethod]
    public DataSet GETCASH_PAY(string compcode, string paymode)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindrate.GETCASH_PAY(compcode, paymode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dx = bindrate.GETCASH_PAY(compcode, paymode);
        }
        else
        {
            string[] parameterValueArray = new string[] { paymode, compcode };
            string procedureName = "GETCASH_PAY";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
            //dx = bindrate.GETCASH_PAY(compcode, paymode);
        }
        return dx;
    }
    [Ajax.AjaxMethod]
    public DataSet getDiscPrem(string compcode, string drpdiscprem)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindrate.getDiscPremVal(compcode, drpdiscprem);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dx = bindrate.getDiscPremVal(compcode, drpdiscprem);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, drpdiscprem };
            string procedureName = "getDiscPremVal";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
            //dx = bindrate.getDiscPremVal(compcode, drpdiscprem);
        }
        return dx;
    }
    [Ajax.AjaxMethod]
    public DataSet bindratecodecenterwise(string adcat, string compcode, string branch, string bookingdate, string dateformat, string uom)
    {
        //NewAdbooking.Classes.pop bindrate = new NewAdbooking.Classes.pop();
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking insert = new NewAdbooking.Classes.adbooking();
            dx = insert.ratebindcenterwise(adcat, compcode, branch, bookingdate, dateformat, uom);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking insert = new NewAdbooking.classesoracle.adbooking();
            dx = insert.ratebindcenterwise(adcat, compcode, branch, bookingdate, dateformat, uom);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, adcat, branch, bookingdate, uom };
            string procedureName = "bindratecodecenterwise_disp";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster insert = new NewAdbooking.classmysql.BookingMaster();
            //dx = insert.ratebindcenterwise(adcat, compcode, branch, bookingdate, dateformat, uom);
        }
        return dx;
    }
    [Ajax.AjaxMethod]
    public DataSet bindratecode(string adcat, string compcode)
    {
        //NewAdbooking.Classes.pop bindrate = new NewAdbooking.Classes.pop();
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindrate.ratebind(adcat, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dx = bindrate.ratebind(adcat, compcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, adcat };
            string procedureName = "bindratecode_bindratecode_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
            //dx = bindrate.ratebind(adcat, compcode);
        }
        return dx;

        //txtratecode.Items.Clear();
        //int i;
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "-Select Rate Code-";
        //li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        //li1.Selected = true;
        //txtratecode.Items.Add(li1);

        //if (dx.Tables[0].Rows.Count > 0)
        //{
        //    for (i = 0; i < dx.Tables[0].Rows.Count; i++)
        //    {
        //        ListItem li;
        //        li = new ListItem();
        //        li.Text = dx.Tables[0].Rows[i].ItemArray[0].ToString();
        //        li.Value = dx.Tables[0].Rows[i].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        txtratecode.Items.Add(li);
        //    }

        //}

    }

    public void bindrevenuecenter()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster logindetail = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = logindetail.getQBC_n(Session["center"].ToString(), Session["compcode"].ToString());

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster logindetail = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = logindetail.getQBC_n(Session["center"].ToString(), Session["compcode"].ToString());

        }
        else
        {
            //string[] parameterValueArray = new string[] { Session["center"].ToString(), Session["compcode"].ToString() };
            //string procedureName = "websp_QBC_n";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
            //ds = logindetail.getQBC_n(Session["center"].ToString(), Session["compcode"].ToString());
            NewAdbooking.classmysql.BookingMaster Show_NoAd = new NewAdbooking.classmysql.BookingMaster();
            //ds = Show_NoAd.getQBC_n(Session["center"].ToString(), Session["compcode"].ToString());
            ds = Show_NoAd.getQBC_n("", Session["compcode"].ToString());
        }

        drprevenue.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Revenue Center";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drprevenue.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drprevenue.Items.Add(li);
            }

        }

    }

    //public void bindpaymenttype()
    //{
    //    FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster pay = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
    //    DataSet ds = new DataSet();
    //    ds = pay.bindpaymode(Session["compcode"].ToString());

    //    drppaymenttype.Items.Clear();
    //    int i;
    //    ListItem li1;
    //    li1 = new ListItem();
    //    li1.Text = "Select Pay Mode";
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    drppaymenttype.Items.Add(li1);

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            ListItem li;
    //            li = new ListItem();
    //            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //            //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
    //            drppaymenttype.Items.Add(li);
    //        }

    //    }

    //}

    [Ajax.AjaxMethod]
    public DataSet bindbillto_ag(string agcode, string compcode)
    {
        DataSet dbt = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getbillto = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dbt = getbillto.getbillval(agcode, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getbillto = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dbt = getbillto.getbillval(agcode, compcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, agcode };
            string procedureName = "book_bindbillto_book_bindbillto_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dbt = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster getbillto = new NewAdbooking.classmysql.BookingMaster();
            //dbt = getbillto.getbillval(agcode, compcode);
        }
        return dbt;

    }
    //{
    //    DataSet billcyc = new DataSet();
    //    billcyc.ReadXml(Server.MapPath("XML/billcycle.xml"));
    //    drpbillto.Items.Clear();
    //    int i;
    //    ListItem li1;
    //    li1 = new ListItem();
    //    li1.Text = "Select Bill To";
    //    li1.Value = "0";
    //    li1.Selected = true;
    //    drpbillto.Items.Add(li1);

    //    for (i = 0; i < billcyc.Tables[1].Columns.Count - 1; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = billcyc.Tables[1].Rows[0].ItemArray[i].ToString();
    //        i = i + 1;
    //        li.Value = billcyc.Tables[1].Rows[0].ItemArray[i].ToString();
    //        drpbillto.Items.Add(li);

    //    }


    //}

    public void bindbillcycle()
    {
        DataSet billcyc = new DataSet();
        billcyc.ReadXml(Server.MapPath("XML/billcycle.xml"));
        drpbillcycle.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Bill";
        li1.Value = "0";
        li1.Selected = true;
        drpbillcycle.Items.Add(li1);

        for (i = 0; i < billcyc.Tables[0].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = billcyc.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = billcyc.Tables[0].Rows[0].ItemArray[i].ToString();
            drpbillcycle.Items.Add(li);

        }

    }

    public void bindPaymentMode()
    {

    }
    public void bindcurrency()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract curr = new NewAdbooking.Classes.Contract();
            ds = curr.currencybind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract curr = new NewAdbooking.classesoracle.Contract();
            ds = curr.currencybind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString() };
            string procedureName = "bindcurrency_bindcurrency_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.Contract curr = new NewAdbooking.classmysql.Contract();
            //ds = curr.currencybind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        drpcurrency.Items.Clear();
        drprptcurrency.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Currency";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcurrency.Items.Add(li1);
        drprptcurrency.Items.Add(li1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpcurrency.Items.Add(li);
                drprptcurrency.Items.Add(li);
            }
        }
    }
    public void binduom()
    {
        //NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
        //DataSet ds = new DataSet();
        //ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.RateMaster binduom = new FourCPlus.AdBooking.BookingMaster.Sql.RateMaster();
            ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), "0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster binduom = new FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster();
            ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), "0");
        }
        else
        {
            //string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), "0" };
            //string procedureName = "binduomforrate_binduomforrate_p";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            NewAdbooking.classmysql.BookingMaster binduom = new NewAdbooking.classmysql.BookingMaster();
            ds = binduom.uombindp(Session["compcode"].ToString(), Session["userid"].ToString(), "0");
        }

        drpuom.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select UOM";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpuom.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpuom.Items.Add(li);
            }
            if (Session["uom"] != null)
                drpuom.SelectedValue = Session["uom"].ToString();
            else
                drpuom.SelectedIndex = 1;
        }

    }
    [Ajax.AjaxMethod]
    public DataSet bindpackage_DateWise(string compcode, string dtime, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();
            ds = bindopackage.packagebind(compcode, "DI0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();
            ds = bindopackage.bindpackage_DateWise(compcode, "DI0", dtime, dateformat);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, "DI0", dtime };
            string procedureName = "bindpackageActiveDateWise_bindpackageActiveDateWise_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.Contract bindopackage = new NewAdbooking.classmysql.Contract();
            //ds = bindopackage.bindpackage_DateWise(compcode, "DI0", dtime, dateformat);
        }
        return ds;
    }
    public void bindpackage()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();
            ds = bindopackage.packagebind(Session["compcode"].ToString(), hiddenadtype.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                ds = bindopackage.packagebindActive_DJ(Session["compcode"].ToString(), hiddenadtype.Value, hiddenuserid.Value, Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString());

            }
            else
            {
                NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();
                ds = bindopackage.packagebindActive(Session["compcode"].ToString(), hiddenadtype.Value);
            }
        }
        else
        {
            //string[] parameterValueArray = new string[] { Session["compcode"].ToString(), hiddenadtype.Value, "", "" };
            //string procedureName = "bindpackageActive_bindpackageActive_p";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

            //NewAdbooking.classmysql.Contract bindopackage = new NewAdbooking.classmysql.Contract();
            //ds = bindopackage.packagebind(Session["compcode"].ToString(), hiddenadtype.Value);

            NewAdbooking.classmysql.BookingMaster Show_NoAd = new NewAdbooking.classmysql.BookingMaster();
            ds = Show_NoAd.packagebindbooking(Session["compcode"].ToString(), hiddenadtype.Value, "", "");
        }

        drppackage.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Package";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppackage.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drppackage.Items.Add(li);
            }

        }


    }


    public void advcat(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bind.advdatacategory(compcode, hiddenadtype.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = bind.advdatacategory(compcode, hiddenadtype.Value);
        }
        else
        {
            string procedureName = "";
            string[] parameterValueArray = new string[] { compcode, hiddenadtype.Value };
            if (hiddenadtype.Value == "adtype")
            {
                parameterValueArray = new string[] { compcode, hiddenadtype.Value };
                procedureName = "book_advcategory1_book_advcategory1_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //parameterValueArray = new string[] { compcode, hiddenadtype.Value, "" };
                //procedureName = "book_advcategory_book_advcategory_p";

                NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
                ds = bind.advdatacategoryp(compcode, hiddenadtype.Value, "");
            }

            //NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
            //ds = bind.advdatacategory(compcode, hiddenadtype.Value);


        }

        int i;
        ListItem li1;
        li1 = new ListItem();
        drpadcategory.Items.Clear();
        li1.Text = "Select Ad Category";
        li1.Value = "0";
        li1.Selected = true;
        drpadcategory.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drpadcategory.Items.Add(li);

            }
        }


    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindExec_new(string compcode, string execname, string adtype, string rev_cent)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.tv_booking_transaction clsbooking = new NewAdbooking.Classes.tv_booking_transaction();
            ds = clsbooking.getExecbooking_n(compcode, execname, "0", adtype, rev_cent, Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.tv_booking_transaction clsbooking = new NewAdbooking.classesoracle.tv_booking_transaction();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = clsbooking.getExecbooking_n(compcode, execname, "0", rev_cent, adtype, Session["userid"].ToString());
            }
            else
            {
                ds = clsbooking.getExecbooking_n(compcode, execname, "0", rev_cent, adtype, Session["userid"].ToString());
            }
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, execname, "0", rev_cent, adtype, Session["userid"].ToString() };
            string procedureName = "websp_getExecbooking_N_websp_getExecbooking_N_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindExec(string compcode, string execname, string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            NewAdbooking.Classes.tv_booking_transaction clsbooking = new NewAdbooking.Classes.tv_booking_transaction();
            ds = clsbooking.getExecbooking_n(compcode, execname, "0", adtype, Session["revenue"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            NewAdbooking.classesoracle.tv_booking_transaction clsbooking = new NewAdbooking.classesoracle.tv_booking_transaction();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = clsbooking.getExecbooking_n(compcode, execname, "0", Session["revenue"].ToString(), adtype, Session["userid"].ToString());
            }
            else
            {
                ds = clsbooking.getExecbooking_n(compcode, execname, "0", Session["revenue"].ToString(), adtype, Session["userid"].ToString());
            }
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, execname, "0", Session["revenue"].ToString(), adtype, Session["userid"].ToString() };
            string procedureName = "websp_getExecbooking_N_websp_getExecbooking_N_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            //if (Session["FILTER"].ToString() == "D")
            //{
            //    ds = clsbooking.getExecbooking_n(compcode, execname, "0", Session["revenue"].ToString(), adtype, Session["userid"].ToString());
            //}
            //else
            //{
            //    ds = clsbooking.getExecbooking_n(compcode, execname, "0", Session["revenue"].ToString(), adtype, Session["userid"].ToString());
            //}
        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindagencyname(string compcode, string userid, string agency, string fla)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            NewAdbooking.Classes.tv_booking_transaction bindagenname = new NewAdbooking.Classes.tv_booking_transaction();
            if (Session["FILTER"].ToString() == "D")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency_n(compcode, userid, agency, Session["revenue"].ToString());
                else
                    ds = bindagenname.bindagency_n(compcode, userid, agency, Session["revenue"].ToString());
            }

            else if (Session["FILTER"].ToString() == "P")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency_n(compcode, userid, agency, Session["center"].ToString());
                else
                    ds = bindagenname.bindagency_n(compcode, userid, agency, Session["center"].ToString());
            }
            else
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency_n(compcode, userid, agency, Session["revenue"].ToString());
                else
                    ds = bindagenname.bindagency_n(compcode, userid, agency, Session["revenue"].ToString());
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            NewAdbooking.classesoracle.tv_booking_transaction bindagenname = new NewAdbooking.classesoracle.tv_booking_transaction();
            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {
                ds = bindagenname.bindagency_DJ(compcode, userid, agency, Session["revenue"].ToString(), Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString());
            }
            else if (Session["FILTER"].ToString() == "D")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency_n(compcode, userid, agency, Session["revenue"].ToString());
                else
                    ds = bindagenname.bindagency_n(compcode, userid, agency, Session["revenue"].ToString());
            }

            else if (Session["FILTER"].ToString() == "P")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency_n(compcode, userid, agency, Session["center"].ToString());
                else
                    ds = bindagenname.bindagency_n(compcode, userid, agency, Session["center"].ToString());
            }
            else
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency_n(compcode, userid, agency, Session["revenue"].ToString());
                else
                    ds = bindagenname.bindagency_n(compcode, userid, agency, Session["revenue"].ToString());
            }
        }
        else
        {
            string procedureName = "";
            string[] parameterValueArray;
            if (Session["FILTER"].ToString() == "D")
            {
                parameterValueArray = new string[] { compcode, userid, agency, Session["revenue"].ToString() };
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    procedureName = "bind10agencyforbooking_N";
                else
                    procedureName = "bindagencyforbooking_N";
            }
            else if (Session["FILTER"].ToString() == "P")
            {
                parameterValueArray = new string[] { compcode, userid, agency, Session["center"].ToString() };
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    procedureName = "bind10agencyforbooking_N";
                else
                    procedureName = "bindagencyforbooking_N";
            }
            else
            {
                parameterValueArray = new string[] { compcode, userid, agency, Session["revenue"].ToString() };
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    procedureName = "bind10agencyforbooking_N";
                else
                    procedureName = "bindagencyforbooking_N";
            }
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindagenname = new NewAdbooking.classmysql.BookingMaster();
            //if (Session["FILTER"].ToString() == "D")
            //{
            //    if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
            //        ds = bindagenname.bind10agency_n(compcode, userid, agency, Session["revenue"].ToString());
            //    else
            //        ds = bindagenname.bindagency_n(compcode, userid, agency, Session["revenue"].ToString());
            //}

            //else if (Session["FILTER"].ToString() == "P")
            //{
            //    if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
            //        ds = bindagenname.bind10agency_n(compcode, userid, agency, Session["center"].ToString());
            //    else
            //        ds = bindagenname.bindagency_n(compcode, userid, agency, Session["center"].ToString());
            //}
            //else
            //{
            //    if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
            //        ds = bindagenname.bind10agency_n(compcode, userid, agency, Session["revenue"].ToString());
            //    else
            //        ds = bindagenname.bindagency_n(compcode, userid, agency, Session["revenue"].ToString());
            //}
        }
        return ds;



    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindagencyname1(string compcode, string userid, string agency, string fla, string revcent)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            NewAdbooking.Classes.tv_booking_transaction bindagenname = new NewAdbooking.Classes.tv_booking_transaction();
            if (Session["FILTER"].ToString() == "D")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency_n(compcode, userid, agency, revcent);
                else
                    ds = bindagenname.bindagency_n(compcode, userid, agency, revcent);
            }

            else if (Session["FILTER"].ToString() == "P")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency_n(compcode, userid, agency, revcent);
                else
                    ds = bindagenname.bindagency_n(compcode, userid, agency, revcent);
            }
            else
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency_n(compcode, userid, agency, revcent);
                else
                    ds = bindagenname.bindagency_n(compcode, userid, agency, revcent);
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            NewAdbooking.classesoracle.tv_booking_transaction bindagenname = new NewAdbooking.classesoracle.tv_booking_transaction();
            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {
                ds = bindagenname.bindagency_DJ(compcode, userid, agency, Session["revenue"].ToString(), Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString());
            }
            else if (Session["FILTER"].ToString() == "D")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency_n(compcode, userid, agency, revcent);
                else
                    ds = bindagenname.bindagency_n(compcode, userid, agency, revcent);
            }

            else if (Session["FILTER"].ToString() == "P")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency_n(compcode, userid, agency, revcent);
                else
                    ds = bindagenname.bindagency_n(compcode, userid, agency, revcent);
            }
            else
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency_n(compcode, userid, agency, revcent);
                else
                    ds = bindagenname.bindagency_n(compcode, userid, agency, revcent);
            }
        }
        else
        {
            string procedureName = "";
            string[] parameterValueArray;
            if (Session["FILTER"].ToString() == "D")
            {
                parameterValueArray = new string[] { compcode, userid, agency, revcent };
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    procedureName = "bind10agencyforbooking_N";
                else
                    procedureName = "bindagencyforbooking_N";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else if (Session["FILTER"].ToString() == "P")
            {
                /*parameterValueArray = new string[] { compcode, userid, agency, revcent };
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    procedureName = "bind10agencyforbooking_N";
                else
                    procedureName = "bindagencyforbooking_N";*/

                NewAdbooking.classmysql.BookingMaster bindagenname = new NewAdbooking.classmysql.BookingMaster();
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency_n(compcode, userid, agency, revcent);
                else
                    ds = bindagenname.bindagency_n(compcode, userid, agency, revcent);

            }
            else
            {
                parameterValueArray = new string[] { compcode, userid, agency, revcent };
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    procedureName = "bind10agencyforbooking_N";
                else
                    procedureName = "bindagencyforbooking_N";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            //NewAdbooking.classmysql.BookingMaster bindagenname = new NewAdbooking.classmysql.BookingMaster();
            //if (Session["FILTER"].ToString() == "D")
            //{
            //    if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
            //        ds = bindagenname.bind10agency_n(compcode, userid, agency, Session["revenue"].ToString());
            //    else
            //        ds = bindagenname.bindagency_n(compcode, userid, agency, Session["revenue"].ToString());
            //}

            //else if (Session["FILTER"].ToString() == "P")
            //{
            //    if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
            //        ds = bindagenname.bind10agency_n(compcode, userid, agency, Session["center"].ToString());
            //    else
            //        ds = bindagenname.bindagency_n(compcode, userid, agency, Session["center"].ToString());
            //}
            //else
            //{
            //    if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
            //        ds = bindagenname.bind10agency_n(compcode, userid, agency, Session["revenue"].ToString());
            //    else
            //        ds = bindagenname.bindagency_n(compcode, userid, agency, Session["revenue"].ToString());
            //}
        }
        return ds;



    }
    public void bindStatus()
    {
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select RO Status";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drprostatus.Items.Add(li1);
        li1 = new ListItem();
        li1.Value = "1";
        li1.Text = "Confirm";
        drprostatus.Items.Add(li1);
        li1 = new ListItem();
        li1.Value = "2";
        li1.Text = "Reservation";
        drprostatus.Items.Add(li1);

    }
    public void bindBillStatus()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsBook = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = clsBook.getBillStatus();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsBook = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = clsBook.getBillStatus();
        }
        else
        {
            string[] parameterValueArray = new string[] { };
            string procedureName = "websp_getBillStatus_websp_getBillStatus_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster clsBook = new NewAdbooking.classmysql.BookingMaster();
            //ds = clsBook.getBillStatus();
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Status";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpbillstatus.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            //drpregion.SelectedValue=ds.Tables[0].Rows[i].ItemArray[1].ToString();
            //drpregion.SelectedItem.Text=ds.Tables[0].Rows[i].ItemArray[1].ToString();
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpbillstatus.Items.Add(li);
        }
    }


    protected void drpagency_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string agency = txtagency.SelectedItem.Value;

    }
    [Ajax.AjaxMethod]
    public DataSet bindpagePosition(string compcode, string bookdate, string dateformat, string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = clsbooking.bindPagePosition(compcode, bookdate, dateformat, adtype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = clsbooking.bindPagePosition(compcode, bookdate, dateformat, adtype);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, bookdate, adtype };
            string procedureName = "WEBSP_GETPAGEPOSITION_DATEWISE";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            //ds = clsbooking.bindPagePosition(compcode, bookdate, dateformat, adtype);
        }
        /*int i;
        ListItem li1;

        li1 = new ListItem();
        drppageposition.Items.Clear();
        li1.Text = "Select Page Position";
        li1.Value = "0";
        li1.Selected = true;
        drppageposition.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drppageposition.Items.Add(li);


        }*/
        return ds;
    }

    public void bindDiscPrem(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = clsbooking.bindDiscPrem(compcode, hiddenadtype.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = clsbooking.bindDiscPrem(compcode, hiddenadtype.Value);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, hiddenadtype.Value };
            string procedureName = "bindDiscPrem";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            //ds = clsbooking.bindDiscPrem(compcode, hiddenadtype.Value);
        }
        int i;
        ListItem li1;
        li1 = new ListItem();
        drpdiscountprem.Items.Clear();
        li1.Text = "Select Disc. Premium";
        li1.Value = "0";
        li1.Selected = true;
        drpdiscountprem.Items.Add(li1);
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpdiscountprem.Items.Add(li);
        }
    }
    public void bindAdSizeType(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = clsbooking.bindAdSizeType(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = clsbooking.bindAdSizeType(compcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode };
            string procedureName = "websp_getadsize_websp_getadsize_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            //ds = clsbooking.bindAdSizeType(compcode);
        }
        int i;
        ListItem li1;
        li1 = new ListItem();
        drpadstype.Items.Clear();
        li1.Text = "Select Ad Size Type";
        li1.Value = "0";
        li1.Selected = true;
        drpadstype.Items.Add(li1);
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpadstype.Items.Add(li);
        }
    }
    [Ajax.AjaxMethod]
    public DataSet bindProduct(string compcode, string product)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = clsbooking.bindProduct(compcode, product, "0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = clsbooking.bindProduct(compcode, product, "0");
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, product, "0" };
            string procedureName = "websp_getProduct_websp_getProduct_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            //ds = clsbooking.bindProduct(compcode, product, "0");
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindreferenceID(string compcode, string agency, string client)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = clsbooking.bindreferenceID(compcode, agency, client);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = clsbooking.bindreferenceID(compcode, agency, client);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, agency, client };
            string procedureName = "bindreferenceID_TV";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            //ds = clsbooking.bindreferenceID(compcode, agency, client);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindAdOnPackage(string compcode, string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = clsbooking.bindAdOnPackage(compcode, adtype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = clsbooking.bindAdOnPackage(compcode, adtype);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, adtype };
            string procedureName = "bindpackage_Adon";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            //ds = clsbooking.bindAdOnPackage(compcode, adtype);
        }
        return ds;
    }
    public void bindAdType(string compcode)
    {
        DataSet billtyp = new DataSet();
        billtyp.ReadXml(Server.MapPath("XML/billcycle.xml"));
        //DataView dv = billtyp.Tables["date"].DefaultView;
        ////dv.Sort = "ID";
        //drpbooktype.DataTextField = "Name";
        //drpbooktype.DataValueField = "ID";
        //drpbooktype.DataSource = dv;
        //drpbooktype.DataBind();
        drpbooktype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Booking Type";
        li1.Value = "0";
        //li1.Selected = true;
        drpbooktype.Items.Add(li1);

        for (i = 0; i < billtyp.Tables[3].Columns.Count - 1; i++)
        {
            if (hidfmgallow.Value == "y")
            {
                ListItem li;
                li = new ListItem();
                li.Text = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
                i = i + 1;
                li.Value = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
                drpbooktype.Items.Add(li);
            }
            else
            {
                for (i = 0; i < billtyp.Tables[3].Columns.Count - 1; i++)
                {
                    ListItem li;
                    li = new ListItem();
                    if (billtyp.Tables[3].Rows[0].ItemArray[i].ToString() != "2" && billtyp.Tables[3].Rows[0].ItemArray[i].ToString() != "FMG")
                    {
                        li.Text = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
                        i = i + 1;
                        li.Value = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
                        drptype.Items.Add(li);
                    }
                }
            }
        }
    }
    [Ajax.AjaxMethod]
    public string bindAdTypeAgencyWise(string agencycode, string compcode)
    {

        DataSet ds1 = new DataSet();
        string bookingtype = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds1 = clsbooking.bindAdTypeAgencyWise(agencycode, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds1 = clsbooking.bindAdTypeAgencyWise(agencycode, compcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { agencycode, compcode };
            string procedureName = "getAgencyBookingType";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds1 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            //ds1 = clsbooking.bindAdTypeAgencyWise(agencycode, compcode);
        }
        if (ds1.Tables[0].Rows.Count > 0)
        {
            bookingtype = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return bookingtype;

    }
    [Ajax.AjaxMethod]
    public string bindAdTypeAgencyWiseXML()
    {
        DataSet ds = new DataSet();
        DataSet billtyp = new DataSet();
        // billtyp.ReadXml(Server.MapPath("XML/billcycle.xml").Replace("\\ajax", ""));
        billtyp.ReadXml(Server.MapPath("../XML/billcycle.xml").Replace("\\ajax", ""));
        string data = "";
        for (int i = 0; i < billtyp.Tables[3].Columns.Count; i++)
        {
            if (data == "")
            {
                data = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
            }
            else
            {
                data = data + "," + billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
            }
        }

        return data;

    }
    [Ajax.AjaxMethod]
    public DataSet getexeczone(string execcode, string compcode, string agencycodesubcode)
    {
        //string execcode = txtexecname.Text;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking clsbooking = new NewAdbooking.Classes.adbooking();
            ds = clsbooking.getExecZoneName(execcode, compcode, agencycodesubcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
            ds = clsbooking.getExecZoneName34(execcode, compcode, agencycodesubcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { execcode, compcode, agencycodesubcode };
            string procedureName = "websp_getExecZoneNamebooking";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            //ds = clsbooking.getExecZoneName(execcode, compcode);
        }
        return ds;
    }
    public void bindcolor()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindcolor = new NewAdbooking.Classes.Contract();
            ds = bindcolor.colorbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract bindcolor = new NewAdbooking.classesoracle.Contract();
            ds = bindcolor.colorbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            //string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString() };
            //string procedureName = "bindcolor_bindcolor_p";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            NewAdbooking.classmysql.Contract bindcolor = new NewAdbooking.classmysql.Contract();
            ds = bindcolor.colorbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        drpcolor.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Color";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcolor.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpcolor.Items.Add(li);
            }

        }


    }



    [Ajax.AjaxMethod]
    public DataSet getbrand(string product, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = clsbooking.bindBrand(compcode, product);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = clsbooking.bindBrand(compcode, product);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, product };
            string procedureName = "websp_getBrand_websp_getBrand_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            //ds = clsbooking.bindBrand(compcode, product);
        }
        return ds;
    }

    protected void txtinsertion_TextChanged1(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

    }


    //protected void DataGrid2_ItemDataBound(object sender, DataGridItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        string text = "Text" + z;
    //        e.Item.Cells[2].Text = "<input id=" + text + " type=\"text\" value='' Class=\"btextforgrid\" />";
    //    }
    //    z++;
    //}
    protected void btnNew_Click(object sender, EventArgs e)
    {

    }
    [Ajax.AjaxMethod]
    public DataSet getData(string drppackage, string txtinsertion, string txtrepeatingdate, string txtstartdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string insert, string code, string cardrate, string uom, string dealrate, string checkforor, string premium, string clientname, string adcat3, string adcat4, string adcat5)
    {
        DataSet ds = new DataSet();
        //DateTime dt = System.DBNull.Value;
        if (txtinsertion == "")
            txtinsertion = "1";
        if (txtrepeatingdate == "")
            txtrepeatingdate = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            //  ds = clsbooking.getInsertion(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, checkforor, premium, clientname);
            ds = clsbooking.qbc_getInsertion(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, checkforor, insert, "", adcat3, adcat4, adcat5, clientname, "", "0");
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            //ds = clsbooking.qbc_getInsertion(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, checkforor, premium, clientname);
            ds = clsbooking.qbc_getInsertion(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, checkforor, insert, "", adcat3, adcat4, adcat5, clientname, "", "0");
        }

        else
        {
            //string[] parameterValueArray = new string[] { drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, cardrate, uom, dealrate, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, checkforor, insert, "", adcat3, adcat4, adcat5, clientname, "", "0" };
            string[] parameterValueArray = new string[] { drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, cardrate, uom, dealrate, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, checkforor, insert, "", adcat3, adcat4, adcat5, clientname, "", "0" };
            string procedureName = "qbc_getInsertion_qbc_getInsertion_p_tnie";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ////ds = clsbooking.getInsertion(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, checkforor, premium, clientname);
            //ds = clsbooking.getInsertion_qbc(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, checkforor, insert, "", adcat3, adcat4, adcat5, clientname, "", "0");
        }

        return ds;
    }

    public void autogenerated(string no)
    {
        if (Session["cioid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (no == "0")
        {
            DateTime dt = DateTime.Now;
            string auto = "";
            string cen = Session["center"].ToString();
            cen = cen.Substring(0, 3);
            cen = cen.Trim();
            int year = Convert.ToInt32(dt.Year);
            string zeros = "";
            ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
            ////and if it is 2 than center + yrar + uid + 8 digit no.
            if (Session["cioid"].ToString() == "1")
            {
                auto = cen + year;
            }
            else if (Session["cioid"].ToString() == "2")
            {
                auto = cen + year + Session["userid"].ToString();
            }
            string autogen = auto + cou;
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
            }
            else
            {
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), auto, no };
                string procedureName = "getautocodebooking_getautocodebooking_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                da = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();
                //da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
            }
            if (da.Tables[0].Rows.Count > 0 && da.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                string ab = da.Tables[0].Rows[0].ItemArray[0].ToString();
                int cou1 = Convert.ToInt32(ab);
                //cou1++;
                int countlen = cou1.ToString().Length;
                if (countlen == 1)
                {
                    zeros = "0000000" + cou1;

                }
                else if (countlen == 2)
                {
                    zeros = "000000" + cou1;

                }
                else if (countlen == 3)
                {
                    zeros = "00000" + cou1;
                }
                else if (countlen == 4)
                {
                    zeros = "0000" + cou1;
                }
                else if (countlen == 5)
                {
                    zeros = "000" + cou1;
                }
                else if (countlen == 6)
                {
                    zeros = "00" + cou1;
                }
                else if (countlen == 7)
                {
                    zeros = "0" + cou1;
                }
                else if (countlen == 8)
                {
                    zeros = "0" + cou1;
                }


                txtciobookid.Text = auto + zeros;
            }
            else
            {
                txtciobookid.Text = autogen;

            }
        }
        else if (no == "1")
        {
            string auto = "DN";
            string autogen = auto + cou;

            DataSet da = new DataSet();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
            }

            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
            }
            else
            {
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), auto, no };
                string procedureName = "getautocodebooking_getautocodebooking_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                da = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();
                //da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
            }
            if (da.Tables[0].Rows.Count > 0 && da.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                string ab = da.Tables[0].Rows[0].ItemArray[0].ToString();
                int cou1 = Convert.ToInt32(ab);
                cou1++;
                txtdockitno1.Text = auto + cou1;
            }
            else
            {
                txtdockitno1.Text = autogen;
            }
        }
        else if (no == "2")
        {
            string auto = "BN";
            string autogen = auto + cou;
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
            }
            else
            {
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), auto, no };
                string procedureName = "getautocodebooking";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                da = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();
                //da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
            }
            if (da.Tables[0].Rows.Count > 0 && da.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                string ab = da.Tables[0].Rows[0].ItemArray[0].ToString();
                int cou1 = Convert.ToInt32(ab);
                cou1++;
                txtboxno.Text = auto + cou1;
            }
            else
            {
                txtboxno.Text = autogen;
            }
        }
        //get max receipt number 
        else if (no == "3")
        {
            DataSet ds_maxreceipt = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objMaxReceipt_No = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                ds_maxreceipt = objMaxReceipt_No.clsMaxReceipt(txtciobookid.Text);
            }
            else
            {
                string[] parameterValueArray = new string[] { txtciobookid.Text };
                string procedureName = "websp_MaxReceipt_websp_MaxReceipt_P";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ds_maxreceipt = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            //***************************************
            string max_number = "0";
            if (ds_maxreceipt.Tables[0].Rows[0].ItemArray[0].ToString().Length == 1)
                max_number = "000" + ds_maxreceipt.Tables[0].Rows[0].ItemArray[0].ToString();
            else if (ds_maxreceipt.Tables[0].Rows[0].ItemArray[0].ToString().Length == 2)
                max_number = "00" + ds_maxreceipt.Tables[0].Rows[0].ItemArray[0].ToString();
            else if (ds_maxreceipt.Tables[0].Rows[0].ItemArray[0].ToString().Length == 3)
                max_number = "0" + ds_maxreceipt.Tables[0].Rows[0].ItemArray[0].ToString();
            else
                max_number = ds_maxreceipt.Tables[0].Rows[0].ItemArray[0].ToString();

            if (hiddenpaymode.Value == "CASH")
            {
                txtreceipt.Text = "R/" + hidReceipt + max_number;
                hiddenreceiptno.Value = txtreceipt.Text;
            }
            else
            {
                txtreceipt.Text = hidReceipt + max_number;
                hiddenreceiptno.Value = txtreceipt.Text;
            }
        }

        /*
                //for generate Receipt No. for modification...
                else if (no == "3")
                {
                    no = "2";
                    string auto = "";
                    string zeros = "";
                    if (Session["Receipt_no"].ToString() == "1")
                    {

                        auto = Session["center"].ToString().Substring(0, 3);
                        auto = auto.Trim();
                    }
                    else if (Session["Receipt_no"].ToString() == "2")
                    {
                        auto = txtagency.Text.Substring(0, 3);
                    }

                    // string autogen = auto + cou;
                    DataSet da = new DataSet();
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

                        da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                        da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
                    }
                    else
                    {
                        NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();

                        da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);

                    }

                    if (da.Tables[0].Rows.Count > 0 && da.Tables[0].Rows[0].ItemArray[0].ToString() != "")
                    {
                        string ab = da.Tables[0].Rows[0].ItemArray[0].ToString();
                        int cou1 = Convert.ToInt32(ab);
                        //cou1++;
                        if (cou1.ToString().Length == 1)
                        {
                            zeros = "00000" + cou1;
                        }
                        if (cou1.ToString().Length == 2)
                        {
                            zeros = "0000" + cou1;
                        }
                        if (cou1.ToString().Length == 3)
                        {
                            zeros = "000" + cou1;
                        }
                        if (cou1.ToString().Length == 4)
                        {
                            zeros = "00" + cou1;
                        }
                        if (cou1.ToString().Length == 5)
                        {
                            zeros = "00" + cou1;
                        }
                        if (cou1.ToString().Length == 6)
                        {
                            zeros = "0" + cou1;
                        }


                        txtreceipt.Text = auto + zeros;
                        if (Session["Receipt_no"].ToString() == "3")
                        {
                            txtreceipt.Text = "";
                            txtreceipt.Text = Session["prefix"].ToString() + zeros + Session["suffix"].ToString();
                        }
                    }
                    else
                    {
                        txtreceipt.Text = auto + "000000";

                    }

                    hiddenreceiptno.Value = txtreceipt.Text;

                }*/
    }
    public void getbuttoncheck(string formname)
    {
        DataSet butt = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.classlibraryforbutton getpermission = new NewAdbooking.Classes.classlibraryforbutton();
            butt = getpermission.getbuttonpermission(Session["compcode"].ToString(), Session["userid"].ToString(), formname);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.classlibraryforbutton getpermission = new NewAdbooking.classesoracle.classlibraryforbutton();
            butt = getpermission.getbuttonpermission(Session["compcode"].ToString(), Session["userid"].ToString(), formname);
        }
        else
        {
            //string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), formname };
            //string procedureName = "Websp_Showpermission_Websp_Showpermission_P";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //butt = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            NewAdbooking.classmysql.classlibraryforbutton getpermission = new NewAdbooking.classmysql.classlibraryforbutton();
            butt = getpermission.getbuttonpermission(Session["compcode"].ToString(), Session["userid"].ToString(), formname);
        }
        string id = "0";
        if (butt.Tables[0].Rows.Count > 0)
        {
            id = butt.Tables[0].Rows[0].ItemArray[0].ToString();
            hiddenroperm.Value = butt.Tables[2].Rows[0].ItemArray[0].ToString();
        }
        //////this is for the ro date time permission if there is 0 than no permission and if 1 than having the permission
        hiddenbuttonidcheck.Value = id;

        if (id != "0")
        {
            //var id = ds.Tables[0].Rows[0].button_id;
            if (id == "0" || id == "8")
            {
                FlagStatus = 0;
                btnNew.Enabled = false;
                btnQuery.Enabled = false;
                btnExecute.Enabled = false;
                btnCancel.Enabled = false;
                btnExit.Enabled = false;
                btnDelete.Enabled = false;
                btnModify.Enabled = false;
                btnSave.Enabled = false;
                btnsavepaginate.Enabled = false;
                btnModify.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                //window.location.href = 'EnterPage.aspx';
                //alert("You Are Not Authorised To See This Form");
                //FlagStatus = 0;
                //
            }
            if (id == "1" || id == "9")
            {
                btnNew.Enabled = true;
                btnQuery.Enabled = false;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnDelete.Enabled = false;
                btnExecute.Enabled = false;
                btnSave.Enabled = false;
                btnsavepaginate.Enabled = false;
                btnModify.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                FlagStatus = 1;
            }
            if (id == "2" || id == "10")
            {
                btnNew.Enabled = false;
                btnExecute.Enabled = false;
                btnQuery.Enabled = true;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnDelete.Enabled = false;
                btnModify.Enabled = true;
                btnSave.Enabled = false;
                btnsavepaginate.Enabled = false;
                btnfirst.Enabled = true;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                btnExit.Enabled = true;
                FlagStatus = 2;
            }
            if (id == "3" || id == "11")
            {
                btnNew.Enabled = true;
                btnQuery.Enabled = true;
                btnExecute.Enabled = false;
                btnDelete.Enabled = false;
                btnModify.Enabled = false;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
                btnsavepaginate.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                FlagStatus = 3;
            }
            if (id == "4" || id == "12")
            {
                btnNew.Enabled = false;
                btnQuery.Enabled = true;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnDelete.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                btnExecute.Enabled = false;
                btnNew.Enabled = false;
                btnExecute.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnModify.Enabled = false;
                btnSave.Enabled = false;
                btnsavepaginate.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                FlagStatus = 4;
            }
            if (id == "5" || id == "13")
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnsavepaginate.Enabled = false;
                btnQuery.Enabled = true;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnDelete.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                btnExecute.Enabled = false;
                btnModify.Enabled = false;
                FlagStatus = 5;
            }
            if (id == "6" || id == "14")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = false;
                btnsavepaginate.Enabled = false;
                btnQuery.Enabled = true;
                btnModify.Enabled = false;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnDelete.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                btnExecute.Enabled = false;
                FlagStatus = 6;
            }
            if (id == "7" || id == "15")
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnsavepaginate.Enabled = false;
                btnQuery.Enabled = true;
                btnModify.Enabled = false;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnDelete.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                btnExecute.Enabled = false;
                FlagStatus = 7;
            }
        }
    }
    public void chkstatus(int FlagStatus)
    {
        if (FlagStatus == 0 || FlagStatus == 8)
        {
            btnNew.Enabled = false;
            btnQuery.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnsavepaginate.Enabled = false;
            btnExecute.Enabled = false;
            btnCancel.Enabled = false;
            btnModify.Enabled = false;

            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
            btnExit.Enabled = false;
        }
        if (FlagStatus == 1 || FlagStatus == 9)
        {
            btnNew.Enabled = false;
            btnQuery.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnsavepaginate.Enabled = true;
            btnExecute.Enabled = false;
            btnCancel.Enabled = true;
            btnModify.Enabled = false;

            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
            btnExit.Enabled = true;

        }
        if (FlagStatus == 2 || FlagStatus == 10)
        {
            btnExecute.Enabled = true;
            btnQuery.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnCancel.Enabled = true;
            btnExecute.Enabled = false;
            btnModify.Enabled = false;
            btnExit.Enabled = true;
            btnSave.Enabled = false;
            btnsavepaginate.Enabled = false;
            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
            btnExit.Enabled = true;
        }

        if (FlagStatus == 3 || FlagStatus == 11)
        {
            btnNew.Enabled = false;
            btnQuery.Enabled = false;
            btnExecute.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnExit.Enabled = true;
            btnModify.Enabled = false;

            btnSave.Enabled = true;
            btnsavepaginate.Enabled = true;
            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
        }

        if (FlagStatus == 4 || FlagStatus == 12)
        {
            btnNew.Enabled = false;
            btnExecute.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnExit.Enabled = true;
            btnModify.Enabled = false;

            btnSave.Enabled = false;
            btnsavepaginate.Enabled = false;
            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
        }
        if (FlagStatus == 5 || FlagStatus == 13)
        {
            btnNew.Enabled = false;
            btnExecute.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnExit.Enabled = true;
            btnModify.Enabled = false;

            btnSave.Enabled = false;
            btnsavepaginate.Enabled = false;
            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
        }
        if (FlagStatus == 6 || FlagStatus == 14)
        {
            btnNew.Enabled = false;
            btnExecute.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnExit.Enabled = true;
            btnModify.Enabled = false;

            btnSave.Enabled = false;
            btnsavepaginate.Enabled = false;
            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
        }
        if (FlagStatus == 7 || FlagStatus == 15)
        {
            btnNew.Enabled = false;
            btnExecute.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnExit.Enabled = true;
            btnModify.Enabled = false;

            btnSave.Enabled = true;
            btnsavepaginate.Enabled = true;
            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
        }

    }

    public void updateStatus()
    {
        chkstatus(FlagStatus);
        if (FlagStatus == 2 || FlagStatus == 3)
        {
            btnQuery.Enabled = true;
            btnExecute.Enabled = false;
            btnSave.Enabled = false;
            btnsavepaginate.Enabled = false;
            btnModify.Enabled = true;
            btnfirst.Enabled = true;
            btnnext.Enabled = true;
            btnprevious.Enabled = true;
            btnlast.Enabled = true;
            btnDelete.Enabled = false;
        }
        if (FlagStatus == 4)
        {
            btnDelete.Enabled = true;
            btnExecute.Enabled = false;
            btnSave.Enabled = false;
            btnsavepaginate.Enabled = false;
            btnQuery.Enabled = true;
            btnModify.Enabled = false;
            btnfirst.Enabled = true;
            btnnext.Enabled = true;
            btnprevious.Enabled = true;
            btnlast.Enabled = true;

        }
        if (FlagStatus == 5)
        {
            btnDelete.Enabled = true;
            btnExecute.Enabled = false;
            btnSave.Enabled = false;
            btnsavepaginate.Enabled = false;
            btnQuery.Enabled = true;
            btnModify.Enabled = false;
            btnfirst.Enabled = true;
            btnnext.Enabled = true;
            btnprevious.Enabled = true;
            btnlast.Enabled = true;

        }
        if (FlagStatus == 6 || FlagStatus == 7)
        {
            btnDelete.Enabled = true;
            btnExecute.Enabled = false;
            btnSave.Enabled = false;
            btnsavepaginate.Enabled = false;
            btnQuery.Enabled = true;
            btnModify.Enabled = true;
            btnfirst.Enabled = true;
            btnnext.Enabled = true;
            btnprevious.Enabled = true;
            btnlast.Enabled = true;

        }
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {

    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {

    }
    protected void btnExecute_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void btnfirst_Click(object sender, EventArgs e)
    {

    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {

    }
    protected void btnnext_Click(object sender, EventArgs e)
    {

    }
    protected void btnlast_Click(object sender, EventArgs e)
    {

    }
    protected void drpuom_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbmeasure.Text = drpuom.SelectedItem.Text.ToString();
        lbbilluom.Text = drpuom.SelectedItem.Text.ToString();
        lbmeasuretotal.Text = "Sq" + "&nbsp;" + drpuom.SelectedItem.Text.ToString();
    }
    protected void drpcurrency_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //[Ajax.AjaxMethod]
    //public DataSet getratevalue(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string premium, string clientcode, string noof_ins)
    //{
    //    DataSet dr = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster rate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
    //        dr = rate.getrate(adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, compcode, uom, premium, clientcode, noof_ins);
    //    }

    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster rate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
    //        dr = rate.getrate(adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, compcode, uom, premium, clientcode, noof_ins);
    //    }

    //    else
    //    {
    //        NewAdbooking.classmysql.BookingMaster rate = new NewAdbooking.classmysql.BookingMaster();
    //        dr = rate.getrate(adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, compcode, uom, premium, clientcode, noof_ins);
    //    }


    //    return dr;

    //    //if (dr.Tables[0].Rows.Count - 1 >= 0)getpercentage

    //    //{
    //    //    txtcardrate.Text = dr.Tables[0].Rows[0].ItemArray[0].ToString();

    //    //}
    //}

    [Ajax.AjaxMethod]
    public DataSet getratevalue(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string premium, string clientcode, string noof_ins, string adcat3, string adcat4, string adcat5)
    {
        DataSet dr = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster rate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dr = rate.getrate(adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, compcode, uom, premium, clientcode, noof_ins);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster rate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dr = rate.getrate(adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, compcode, uom, premium, clientcode, noof_ins, adcat3, adcat4, adcat5);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, uom, premium, clientcode, noof_ins, adcat3, adcat4, adcat5 };
            string procedureName = "getratecode_getratecode_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dr = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster rate = new NewAdbooking.classmysql.BookingMaster();
            //dr = rate.getrate(adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, compcode, uom, premium, clientcode, noof_ins, adcat3, adcat4, adcat5);
        }
        return dr;
        //if (dr.Tables[0].Rows.Count - 1 >= 0)
        //{
        //    txtcardrate.Text = dr.Tables[0].Rows[0].ItemArray[0].ToString();
        //}
    }
    protected void drpboxcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpboxcode.SelectedValue != "0")
        {
            autogenerated("2");
        }
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    [Ajax.AjaxMethod]
    public DataSet bindagencusub(string agency, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindsub = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bindsub.bindsubagency(agency, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindsub = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = bindsub.bindsubagency(agency, compcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { agency, compcode };
            string procedureName = "book_bindsubagency_book_bindsubagency_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindsub = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindsub.bindsubagency(agency, compcode);
        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindclientname(string compcode, string client, string fla)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.tv_booking_transaction clsbooking = new NewAdbooking.Classes.tv_booking_transaction();
            if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
            {
                //NewAdbooking.Classes.tv_booking_transaction clsbooking = new NewAdbooking.Classes.tv_booking_transaction();
                ds = clsbooking.get10ClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
            }
            else
            {
                //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                ds = clsbooking.getClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
            }
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                ds = clsbooking.getClientName_DJ(compcode, client, Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString(), Session["userid"].ToString());
            }
            else if (Session["FILTER"].ToString() == "D")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                {
                    NewAdbooking.classesoracle.tv_booking_transaction clsbooking = new NewAdbooking.classesoracle.tv_booking_transaction();
                    ds = clsbooking.get10ClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
                }
                else
                {
                    //FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                    NewAdbooking.classesoracle.tv_booking_transaction clsbooking = new NewAdbooking.classesoracle.tv_booking_transaction();
                    ds = clsbooking.getClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
                }
            }
            else
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                {
                    NewAdbooking.classesoracle.tv_booking_transaction clsbooking = new NewAdbooking.classesoracle.tv_booking_transaction();
                    ds = clsbooking.get10ClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
                }
                else
                {
                    //FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                    NewAdbooking.classesoracle.tv_booking_transaction clsbooking = new NewAdbooking.classesoracle.tv_booking_transaction();
                    ds = clsbooking.getClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
                }
            }
        }

        else
        {
            /*string procedureName = "";
            string[] parameterValueArray = new string[] { compcode, client, Session["revenue"].ToString(), Session["userid"].ToString() };
            if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
            {
                procedureName = "websp_get10clientName1";
            }
            else
            {
                procedureName = "websp_getclientName_websp_getclientName_p";
            }
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
            {
                ds = clsbooking.get10ClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
            }
            else
            {
                ds = clsbooking.getClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
            }
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getpayandstatus(string agencycode, string agencysubcode, string compcode, string getdatecheck, string dateformat, string adtype)
    {
        DataSet dch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getsta = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dch = getsta.getstatuspaymode(agencycode, agencysubcode, compcode, getdatecheck, dateformat, adtype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getsta = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dch = getsta.getstatuspaymode(agencycode, agencysubcode, compcode, getdatecheck, dateformat, adtype);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, agencycode, agencysubcode, getdatecheck, adtype, dateformat };
            string procedureName = "getstatuspaymode_getstatuspaymode_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dch = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster getsta = new NewAdbooking.classmysql.BookingMaster();
            //dch = getsta.getstatuspaymode(agencycode, agencysubcode, compcode, getdatecheck, dateformat, adtype);
        }
        return dch;
    }

    ///this the function to insert the records in insert table
    [Ajax.AjaxMethod]
    public string insertinsertion(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string filename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string insertinsertion, string solorate, string grossrate, string no, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string insert_id, string dateformat, string pkgcode, string gridins, string pkgalias, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string serverip, string splitdata, string subedidata, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string caption_inserts, string dealerheight, string dealerwidth, string disc_, string agncyamnt, string adlgncyamnt, string spldisc, string cashdisc, string roundoffamt, string pdfheight, string cpnamt, string clicatamt, string flatfreqamt, string catamt, string premamtval, string gstamount, string gstgrid)
    {
        string err = "";
        DataSet dii = new DataSet();
        try
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                // dii = insertchild.insertbook_ins_display(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, "0", "0", "0", insert_id, dateformat, "0", "0", "0", pkgcode, gridins, pkgalias, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch);
                NewAdbooking.Classes.adbooking insertchild = new NewAdbooking.Classes.adbooking();
                dii = insertchild.insertbook_ins(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, "", "", "", dateformat, "0", "0", "0", pkgcode, gridins, pkgalias, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, splitdata, subedidata, "", vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, disc_, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheight, cpnamt, clicatamt, flatfreqamt, catamt, premamtval, gstamount, gstgrid);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                //FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                NewAdbooking.classesoracle.adbooking insertchild = new NewAdbooking.classesoracle.adbooking();
                err = insertchild.insertbook_ins(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, "0", "0", "0", dateformat, "0", "0", "0", pkgcode, gridins, pkgalias, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, splitdata, subedidata, "", vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, disc_, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheight, cpnamt, clicatamt, flatfreqamt, catamt, premamtval, gstamount, gstgrid);
            }
            else
            {
                //string[] parameterValueArray = new string[] { insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, "0", "0", "0", dateformat, "0", "0", "0", pkgcode, gridins, pkgalias, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, splitdata, subedidata, "", vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, disc_, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheight, cpnamt, clicatamt, flatfreqamt, catamt, premamtval, null, null };
                //string[] parameterValueArray = new string[] { ConvertToDateTime(insertdate), edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, "0", "0", "0", "0", "0", "0", pkgcode, gridins, pkgalias, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, splitdata, subedidata, "", vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, disc_, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheight, cpnamt, clicatamt, flatfreqamt, catamt, null, premamtval, null, null };
                //string procedureName = "insertintobookchild_insertintobookchild_p";
                //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                //dii = sms.DynamicBindProcedure(procedureName, parameterValueArray);

                NewAdbooking.classmysql.BookingMaster insertchild = new NewAdbooking.classmysql.BookingMaster();
                dii = insertchild.insertbook_ins(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, "0", "0", "0", dateformat, "0", "0", "0", pkgcode, gridins, pkgalias, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, splitdata, subedidata, "", vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, disc_, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheight, cpnamt, clicatamt, flatfreqamt, catamt, null, premamtval, null, null, gstamount, gstgrid);

                //err = insertchild.insertbook_ins(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, "0", "0", "0", dateformat, "0", "0", "0", pkgcode, gridins, pkgalias, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, splitdata, subedidata, "", vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, disc_, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheight, cpnamt, clicatamt, flatfreqamt, catamt, premamtval);
            }
        }
        catch (Exception e)
        {
            err = e.Message;

        }
        string data = "insertdate:" + insertdate + "edition:" + edition + "premium1:" + premium1 + "premium2:" + premium2 + "premallow:" + premallow + "adcategory:" + adcategory + "latestdate:" + latestdate + "material:" + material + "cardrate:" + cardrate + "filename:" + filename + "discrate:" + discrate + "insertstatus:" + insertstatus + "billstatus:" + billstatus + "adsubcat:" + adsubcat + "compcode:" + compcode + "userid:" + userid + "cioid:" + cioid + "height:" + height + "width:" + width + "totalsize:" + totalsize + "pagepost:" + pagepost + "premper1:" + premper1 + "premper2:" + premper2 + "colid:" + colid + "repeat:" + repeat + "insertno:" + insertno + "paid:" + paid + "insertinsertion:" + insertinsertion + "solorate:" + solorate + "grossrate:" + grossrate + "insert_pageno:" + insert_pageno + "insert_remarks:" + insert_remarks + "page_code:" + page_code + "page_per:" + page_per + "noofcol:" + noofcol + "billamt:" + billamt + "billrate:" + billrate + "logo_h:" + "0" + "logo_w:" + "0" + "logo_name:" + "0" + "dateformat:" + dateformat + "0" + "0" + "0" + "pkgcode:" + pkgcode + "gridins:" + gridins + "pkgalias:" + pkgalias + "cirvts:" + cirvts + "cirpub:" + cirpub + "ciredi:" + ciredi + "cirrate:" + cirrate + "cirdate:" + cirdate + "ciragency:" + ciragency + "ciragencysubcode:" + ciragencysubcode + "center:" + center + "branch:" + branch;
        if (err != "")
            err = err + " ERROR: " + data;
        string adcatcode2 = "Save Display Booking " + cioid;
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new(DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP)  values($date,'" + userid + "','Display Ad Booking','" + err.Replace("'", "''") + "','Ad Booking Saved','" + adcatcode2;
        sqldd = sqldd + "',";
        sqldd = sqldd + "'" + serverip + "')";
        dconnect.executenonquery1(sqldd);
        return err;
    }

    //this is to show the grid for execution
    [Ajax.AjaxMethod]
    public void rollback(string cioid)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            insertchild.rollbackT(cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            insertchild.rollbackT(cioid);
        }
        else
        {
            string[] parameterValueArray = new string[] { cioid };
            string procedureName = "rollbacktransaction";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster insertchild = new NewAdbooking.classmysql.BookingMaster();
            //insertchild.rollbackT(cioid);
        }
    }
    [Ajax.AjaxMethod]
    public void insertionCount(string cioid, int count)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            insertchild.insertionCount(cioid, count);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

        }
        else
        {
            string[] parameterValueArray = new string[] { cioid, count.ToString() };
            string procedureName = "insertionCount";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster insertchild = new NewAdbooking.classmysql.BookingMaster();
            //insertchild.insertionCount(cioid, count);
        }
    }
    /* [Ajax.AjaxMethod]
     public string commit(int count, string cioid, string pcompcode, string pcentname, string puserid, string pbkid_gentype, string quotation)
     {
         string error = "";
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
             error = insertchild.commitT(count, cioid, pcompcode, pcentname, puserid, pbkid_gentype, "DI", quotation);
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
             error = insertchild.commitT(count, cioid, pcompcode, pcentname, puserid, pbkid_gentype, "DI", quotation);
         }
         else
         {
             string val = "DI";
             DataSet res = new DataSet();
             string[] parameterValueArray = new string[] { cioid, count.ToString(), pcompcode, pcentname, puserid, pbkid_gentype, val, quotation, null };
             string procedureName = "committransaction";
             NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
             res = sms.DynamicBindProcedure(procedureName, parameterValueArray);
             error = res.Tables[1].Rows[0].ItemArray[0].ToString(); ;
             //NewAdbooking.classmysql.BookingMaster insertchild = new NewAdbooking.classmysql.BookingMaster();
             //error = insertchild.commitT(count, cioid, pcompcode, pcentname, puserid, pbkid_gentype, "DI", quotation);
         }
         return error;
     }*/
    [Ajax.AjaxMethod]
    public string commit(int count, string cioid, string pcompcode, string pcentname, string puserid, string pbkid_gentype, string quotation, string clientcode)
    {
        string error = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking insertchild = new NewAdbooking.classesoracle.adbooking();
            //FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            error = insertchild.commitT(count, cioid, pcompcode, pcentname, puserid, pbkid_gentype, "DI", quotation, clientcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking insertchild = new NewAdbooking.Classes.adbooking();
            //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            error = insertchild.commitT(count, cioid, pcompcode, pcentname, puserid, pbkid_gentype, "DI", quotation, clientcode);
        }
        else
        {
            string val = "DI";
            DataSet res = new DataSet();
            string[] parameterValueArray = new string[] { cioid, count.ToString(), pcompcode, pcentname, puserid, pbkid_gentype, val, quotation, null, clientcode };
            string procedureName = "committransaction";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            res = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            error = res.Tables[1].Rows[0].ItemArray[0].ToString(); ;
            //NewAdbooking.classmysql.BookingMaster insertchild = new NewAdbooking.classmysql.BookingMaster();
            //error = insertchild.commitT(count, cioid, pcompcode, pcentname, puserid, pbkid_gentype, "DI", quotation);
        }
        return error;
    }
    [Ajax.AjaxMethod]
    public DataSet showgridforexe(string ciobid, string compcode, string supplimentflag, string quotation)
    {
        DataSet dex = new DataSet();
        if (supplimentflag == "S")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.classesoracle.adbooking showgri = new NewAdbooking.classesoracle.adbooking();
                dex = showgri.fetchdataforexe_bill(ciobid, compcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking showgri = new NewAdbooking.classesoracle.adbooking();
                dex = showgri.fetchdataforexe_bill(ciobid, compcode);
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, ciobid };
                string procedureName = "getdataforexecute_bill";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dex = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster insertchild = new NewAdbooking.classmysql.BookingMaster();
                //dex = showgri.fetchdataforexe_bill(ciobid, compcode);
            }
        }
        else if (quotation == "Q")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.adbooking showgri = new NewAdbooking.Classes.adbooking();
                dex = showgri.fetchdataforexe(ciobid, compcode);
            }

            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking showgri = new NewAdbooking.classesoracle.adbooking();
                dex = showgri.fetchdataforexe(ciobid, compcode);
            }

            else
            {
                NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();
                dex = showgri.fetchdataforexe(ciobid, compcode);
            }
        }
        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster showgri = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                dex = showgri.fetchdataforexe(ciobid, compcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster showgri = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dex = showgri.fetchdataforexe(ciobid, compcode);
            }
            else
            {
                /*string[] parameterValueArray = new string[] { compcode, ciobid };
                string procedureName = "getdataforexecute_getdataforexecute_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dex = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/

                NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();
                dex = showgri.fetchdataforexenew(ciobid, compcode);

                //NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();
                //dex = showgri.fetchdataforexe(ciobid, compcode);
            }
        }
        return dex;
    }
    public void getadsubcatmain(string compcode, string adcat, string agencytype)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster cls_comb = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            da = cls_comb.advdatasubcatcat(compcode, adcat, agencytype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster cls_comb = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            da = cls_comb.advdatasubcatcat(compcode, adcat, agencytype);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, adcat, agencytype };
            string procedureName = "book_advsubcattyp_book_advsubcattyp_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            da = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster cls_comb = new NewAdbooking.classmysql.BookingMaster();
            //da = cls_comb.advdatasubcatcat(compcode, adcat, agencytype);
        }
        if (da.Tables[0].Rows.Count > 0)
        {
            drpadsubcategory.Items.Clear();
            int i;
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "-Select-";
            li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Selected = true;
            drpadsubcategory.Items.Add(li1);

            if (da.Tables[0].Rows.Count > 0)
            {
                for (i = 0; i < da.Tables[0].Rows.Count; i++)
                {
                    ListItem li;
                    li = new ListItem();
                    li.Text = da.Tables[0].Rows[i].ItemArray[1].ToString();
                    li.Value = da.Tables[0].Rows[i].ItemArray[0].ToString();
                    drpadsubcategory.Items.Add(li);
                }
            }
        }
    }
    [Ajax.AjaxMethod]
    public DataSet getadsubcat(string compcode, string adcat, string agencytype)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster cls_comb = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            da = cls_comb.advdatasubcatcat(compcode, adcat, agencytype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster cls_comb = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            da = cls_comb.advdatasubcatcat(compcode, adcat, agencytype);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, adcat, agencytype };
            string procedureName = "book_advsubcattyp_book_advsubcattyp_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            da = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster cls_comb = new NewAdbooking.classmysql.BookingMaster();
            //da = cls_comb.advdatasubcatcat(compcode, adcat, agencytype);
        }
        return da;
    }
    [Ajax.AjaxMethod]
    public DataSet chkagencycode(string agency, string compcode, string product, string execname, string retainer)
    {
        DataSet dagen = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkagen = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dagen = chkagen.getagencyname(agency, compcode, product, execname, retainer);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkagen = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dagen = chkagen.getagencyname(agency, compcode, product, execname);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, agency, product, execname };
            string procedureName = "chkagen_prod_exec_chkagen_prod_exec_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dagen = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster chkagen = new NewAdbooking.classmysql.BookingMaster();
            //dagen = chkagen.getagencyname(agency, compcode, product, execname);
        }
        return dagen;
    }
    [Ajax.AjaxMethod]
    public DataSet getpageamount(string pagecode, string compcode)
    {
        DataSet damt = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getamt = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            damt = getamt.getpageamt(pagecode, compcode);//, bookdate, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getamt = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            damt = getamt.getpageamt(pagecode, compcode);//, bookdate, dateformat);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, pagecode };
            string procedureName = "getpageamount_getpageamount_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            damt = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster getamt = new NewAdbooking.classmysql.BookingMaster();
            //damt = getamt.getpageamt(pagecode, compcode);
        }
        return damt;
    }
    //public DataSet getpageamount(string pagecode,string compcode)
    //{
    //    DataSet damt = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getamt = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
    //        damt = getamt.getpageamt(pagecode, compcode);
    //    }

    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getamt = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
    //        damt = getamt.getpageamt(pagecode, compcode);
    //    }

    //    else
    //    {
    //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getamt = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
    //        damt = getamt.getpageamt(pagecode, compcode);
    //    }

    //    return damt;


    //}

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getboxnovalue(string compcode, string boxno, string no, string autono)
    {
        //string auto = "BN";
        //string autogen = auto + cou;
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            da = autocode.autogenratedbox(compcode, boxno, no, "0", "0", Session["revenue"].ToString(), autono);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            //da = autocode.autogenrated(compcode, boxno, no);
            da = autocode.autogenratedbox(compcode, boxno, no, "0", "0", Session["revenue"].ToString(), autono);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, boxno, no, "0", "0", Session["revenue"].ToString(), autono };
            string procedureName = "getautocodebox_getautocodebox_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            da = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();
            //da = autocode.autogenratedbox(compcode, boxno, no, "0", "0", Session["revenue"].ToString(), autono);
        }
        return da;
    }
    //public DataSet getboxnovalue(string compcode, string boxno, string no)
    //{
    //    //string auto = "BN";
    //   //string autogen = auto + cou;
    //    DataSet da = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
    //        da = autocode.autogenrated(compcode, boxno, no);
    //    }

    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
    //        da = autocode.autogenrated(compcode, boxno, no);
    //    }

    //    else
    //    {
    //        NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();
    //        da = autocode.autogenrated(compcode, boxno, no);
    //    }

    //    return da;

    //}
    [Ajax.AjaxMethod]
    public DataSet CONVERTTOLOCAL_CURRENCY(string p_Comp_code, string p_Curr_Code, string p_gross_amount, string p_bill_amount, string p_date, string dateformat, string covertcurrency)
    {
        DataSet ddl = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster delid = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ddl = delid.CONVERTTOLOCAL_CURRENCY(p_Comp_code, p_Curr_Code, p_gross_amount, p_bill_amount, p_date, dateformat, covertcurrency);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster delid = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            ddl = delid.CONVERTTOLOCAL_CURRENCY(p_Comp_code, p_Curr_Code, p_gross_amount, p_bill_amount, p_date, dateformat, covertcurrency);
        }
        else
        {
            string[] parameterValueArray = new string[] { p_Comp_code, p_Curr_Code, p_gross_amount, p_bill_amount, p_date, covertcurrency };
            string procedureName = "tv_convert_to_local";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ddl = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();
            //ddl = delid.CONVERTTOLOCAL_CURRENCY(p_Comp_code, p_Curr_Code, p_gross_amount, p_bill_amount, p_date, dateformat, covertcurrency);
        }
        return ddl;
    }
    [Ajax.AjaxMethod]
    public DataSet modifygridinsert(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string filename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string insertinsertion, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string no_ofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string pkgcodegrid_value, string pkginsgrid_value, string pkg_alias_value, string insertid, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string serverip, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string caption_inserts, string dealerheight, string dealerwidth, string subedidata, string disc_, string agncyamnt, string adlgncyamnt, string spldisc, string cashdisc, string roundoffamt, string pdfheightval, string cpnamt, string clicatamt, string flatfreqamt, string catamt, string supplimentflag, string premamtval, string adcat3, string adcat4, string adcat5, string gstamount, string gstgrid)
    {
        DataSet dii = new DataSet();
        string err = "";
        try
        {
            if (supplimentflag == "S")
            {
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.adbooking insertchild = new NewAdbooking.Classes.adbooking();
                    dii = insertchild.insertbook_ins_display_bill(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, no_ofcol, billamt, billrate, "0", "0", "0", insertid, dateformat, adcat3, adcat4, adcat5, pkgcodegrid_value, pkginsgrid_value, pkg_alias_value, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, "", vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, subedidata, disc_, modifyrateaudit, ip, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheightval, cpnamt, clicatamt, flatfreqamt, catamt);
                }

                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.adbooking insertchild = new NewAdbooking.classesoracle.adbooking();
                    dii = insertchild.insertbook_ins_display_bill(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, no_ofcol, billamt, billrate, "0", "0", "0", dateformat, adcat3, adcat4, adcat5, pkgcodegrid_value, pkginsgrid_value, pkg_alias_value, insertid, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, subedidata, disc_, modifyrateaudit, ip, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheightval, cpnamt, clicatamt, flatfreqamt, catamt);
                }
                else
                {
                    string[] parameterValueArray = new string[] { insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, no_ofcol, billamt, billrate, "0", "0", "0", dateformat, adcat3, adcat4, adcat5, pkgcodegrid_value, pkginsgrid_value, pkg_alias_value, insertid, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, subedidata, disc_, modifyrateaudit, ip, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheightval, cpnamt, clicatamt, flatfreqamt, catamt };
                    string procedureName = "insertintobookchilddisplaybill";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    dii = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                    //NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();
                    //dii = insertchild.insertbook_ins_display_bill(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, no_ofcol, billamt, billrate, "0", "0", "0", dateformat, "0", "0", "0", pkgcodegrid_value, pkginsgrid_value, pkg_alias_value, insertid, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, subedidata, disc_, modifyrateaudit, ip, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheightval, cpnamt, clicatamt, flatfreqamt, catamt);
                }
            }
            else
            {
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                    NewAdbooking.Classes.adbooking insertchild = new NewAdbooking.Classes.adbooking();
                    dii = insertchild.insertbook_ins_display(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, no_ofcol, billamt, billrate, "0", "0", "0", insertid, dateformat, adcat3, adcat4, adcat5, pkgcodegrid_value, pkginsgrid_value, pkg_alias_value, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, "", vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, subedidata, disc_, modifyrateaudit, ip, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheightval, cpnamt, clicatamt, flatfreqamt, catamt, premamtval, gstamount, gstgrid);
                }

                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    //FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                    NewAdbooking.classesoracle.adbooking insertchild = new NewAdbooking.classesoracle.adbooking();
                    dii = insertchild.insertbook_ins_display(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, no_ofcol, billamt, billrate, "0", "0", "0", dateformat, adcat3, adcat4, adcat5, pkgcodegrid_value, pkginsgrid_value, pkg_alias_value, insertid, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, subedidata, disc_, modifyrateaudit, ip, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheightval, cpnamt, clicatamt, flatfreqamt, catamt, premamtval, gstamount, gstgrid);
                }

                else
                {
                    //string[] parameterValueArray = new string[] { insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, no_ofcol, billamt, billrate, "0", "0", "0", dateformat, "0", "0", "0", pkgcodegrid_value, pkginsgrid_value, pkg_alias_value, insertid, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, subedidata, disc_, modifyrateaudit, ip, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheightval, cpnamt, clicatamt, flatfreqamt, catamt, premamtval };
                    //string[] parameterValueArray = new string[] { ConvertToDateTime(insertdate), edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, no_ofcol, billamt, billrate, "0", "0", "0", adcat3, adcat4, adcat5, pkgcodegrid_value, pkginsgrid_value, pkg_alias_value, insertid, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, boxcharge, vat_inc_p, vatrate, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, subedidata, disc_, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheightval, cpnamt, clicatamt, flatfreqamt, catamt, premamtval, ip, modifyrateaudit };
                    string[] parameterValueArray = new string[] { ConvertToDateTime(insertdate), edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, no_ofcol, billamt, billrate, "0", "0", "0", adcat3, adcat4, adcat5, pkgcodegrid_value, pkginsgrid_value, pkg_alias_value, insertid, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, boxcharge, vat_inc_p, vatrate, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, subedidata, disc_, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheightval, cpnamt, clicatamt, flatfreqamt, catamt, premamtval, gstamount, gstgrid, ip, modifyrateaudit };
                    string procedureName = "insertintobookchild_display_insertintobookchild_display_p";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    dii = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                    //NewAdbooking.classmysql.BookingMaster insertchild = new NewAdbooking.classmysql.BookingMaster();
                    //dii = insertchild.insertbook_ins_display(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, no_ofcol, billamt, billrate, "0", "0", "0", dateformat, "0", "0", "0", pkgcodegrid_value, pkginsgrid_value, pkg_alias_value, insertid, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, subedidata, disc_, modifyrateaudit, ip, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheightval, cpnamt, clicatamt, flatfreqamt, catamt, premamtval);
                }
            }
        }
        catch (Exception e)
        {
            err = e.Message;

        }
        string adcatcode2 = "Updated Display Booking " + cioid + " with InsertId " + insertid;
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new(DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP)  values($date,'" + userid + "','Display Ad Booking','" + err.Replace("'", "''") + "','Ad Booking Updated','" + adcatcode2;
        sqldd = sqldd + "',";
        sqldd = sqldd + "'" + serverip + "')";
        dconnect.executenonquery1(sqldd);
        return dii;

    }

    //*25Aug***
    [Ajax.AjaxMethod]
    public DataSet getclientinfo(string compcode, string clientname)
    {
        //NewAdbooking.Classes.pop bindrate = new NewAdbooking.Classes.pop();
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindclient = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dx = bindclient.clsClientInfo(compcode, clientname);
            return dx;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindclient = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dx = bindclient.clsClientInfo(compcode, clientname);
                return dx;
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, clientname };
                string procedureName = "WEBSP_CLIENTINFO_WEBSP_CLIENTINFO_P";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster insertchild = new NewAdbooking.classmysql.BookingMaster();
                //dx = bindclient.clsClientInfo(compcode, clientname);
                return dx;
            }
    }
    //*************

    [Ajax.AjaxMethod]
    public DataSet binddealtype(string compcode, string agencysplit, string subagency, string bookingdate, string color, string curr, string adcat, string clientsplit, string prod, string col, string code, string rate_cod, string adtype, string dateformat, string totalarea, string dealtype)
    {
        DataSet ddeal = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getdeal = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ddeal = getdeal.getdealvalue(compcode, subagency, agencysplit, bookingdate, color, curr, adcat, clientsplit, prod, col, code, rate_cod, adtype, dateformat, totalarea, dealtype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getdeal = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ddeal = getdeal.getdealvalue(compcode, subagency, agencysplit, bookingdate, color, curr, adcat, clientsplit, prod, col, code, rate_cod, adtype, dateformat, totalarea, dealtype);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, agencysplit, subagency, bookingdate, color, curr, adcat, clientsplit, prod, code, rate_cod, adtype, totalarea, dealtype };
            //string procedureName = "booking_getdeal_dummy_booking_getdeal_dummy_p";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ddeal = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            NewAdbooking.classmysql.BookingMaster getdeal = new NewAdbooking.classmysql.BookingMaster();
            ddeal = getdeal.getdealvalue(compcode, agencysplit, subagency, bookingdate, color, curr, adcat, clientsplit, prod, col, code, rate_cod, adtype, totalarea, dealtype);
        
            //ddeal = getdeal.getdealvalue(compcode, subagency, agencysplit, bookingdate, color, curr, adcat, clientsplit, prod, col, code, rate_cod, adtype, dateformat, totalarea, dealtype);
        }
        return ddeal;
    }

    [Ajax.AjaxMethod]
    public DataSet allowdisc(string dealcode, string compcode, string agencysplit, string subagency, string clientsplit, string insertion, string contracttype)
    {
        DataSet ddisc = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getdisc = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ddisc = getdisc.booking_getdealdisc(dealcode, compcode, agencysplit, subagency, clientsplit);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getdisc = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ddisc = getdisc.booking_getdealdisc(dealcode, compcode, agencysplit, subagency, clientsplit, insertion, contracttype);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, dealcode, agencysplit, subagency, clientsplit, insertion, contracttype };
            string procedureName = "booking_getdeealdisc_booking_getdeealdisc_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ddisc = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster getdisc = new NewAdbooking.classmysql.BookingMaster();
            //ddisc = getdisc.booking_getdealdisc(dealcode, compcode, agencysplit, subagency, clientsplit, insertion, contracttype);
        }
        return ddisc;
    }
    [Ajax.AjaxMethod]
    public DataSet getDealP(string compcode, string contcode, string type, int counter)
    {
        DataSet ddisc = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getdisc = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ddisc = getdisc.getDealP(compcode, contcode, type, counter);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getdisc = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ddisc = getdisc.getDealP(compcode, contcode, type, counter);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, contcode, type, counter.ToString() };
            string procedureName = "booking_getdealag";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ddisc = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster getdisc = new NewAdbooking.classmysql.BookingMaster();
            //ddisc = getdisc.getDealP(compcode, contcode, type, counter);
        }
        return ddisc;
    }

    [Ajax.AjaxMethod]
    public DataSet getDealAmt(string conttype, string dealagency, string dealclient, string compcode, string contcode)
    {
        DataSet ddisc = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getdisc = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ddisc = getdisc.getDealAmt(conttype, dealagency, dealclient, compcode, contcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getdisc = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ddisc = getdisc.getDealAmt(conttype, dealagency, dealclient, compcode, contcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, conttype, dealagency, dealclient, contcode };
            string procedureName = "getDealAmt";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ddisc = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster getdisc = new NewAdbooking.classmysql.BookingMaster();
            //ddisc = getdisc.getDealAmt(conttype, dealagency, dealclient, compcode, contcode);
        }
        return ddisc;
    }
    [Ajax.AjaxMethod]
    public DataSet getschemedisc(string schemcode, string compcode, string noofinsert)
    {
        DataSet dsc = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getschdisc = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dsc = getschdisc.getschemedisc(schemcode, compcode, noofinsert);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getschdisc = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dsc = getschdisc.getschemedisc(schemcode, compcode, noofinsert);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, schemcode, noofinsert };
            string procedureName = "booking_getschdisc_booking_getschdisc_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dsc = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster getschdisc = new NewAdbooking.classmysql.BookingMaster();
            //dsc = getschdisc.getschemedisc(schemcode, compcode, noofinsert);
        }
        return dsc;
    }

    [Ajax.AjaxMethod]
    public DataSet fillvarient(string brandval, string compcode)
    {
        DataSet dva = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getvarient = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dva = getvarient.bindvarient(brandval, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getvarient = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dva = getvarient.bindvarient(brandval, compcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, brandval };
            string procedureName = "AN_BRANDVARIENT_AN_BRANDVARIENT_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dva = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster getvarient = new NewAdbooking.classmysql.BookingMaster();
            //dva = getvarient.bindvarient(brandval, compcode);
        }
        return dva;
    }
    protected void txtspacedisc_TextChanged(object sender, EventArgs e)
    {

    }

    [Ajax.AjaxMethod]
    public DataSet chkcasualcli(string client, string compcode)
    {
        DataSet dc = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkcli = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dc = chkcli.chkclient(client, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkcli = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dc = chkcli.chkclient(client, compcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, client };
            string procedureName = "book_chkcasualclient_book_chkcasualclient_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dc = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster chkcli = new NewAdbooking.classmysql.BookingMaster();
            //dc = chkcli.chkclient(client, compcode);
        }
        return dc;
    }
    [Ajax.AjaxMethod]
    public DataSet getinsertionscheme(string schemecode, string compcode)
    {
        DataSet dc = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getinssch = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dc = getinssch.getinsertsche(schemecode, compcode);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getinssch = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dc = getinssch.getinsertsche(schemecode, compcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, schemecode };
            string procedureName = "book_getinsertscheme_book_getinsertscheme_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dc = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster getinssch = new NewAdbooking.classmysql.BookingMaster();
            //dc = getinssch.getinsertsche(schemecode, compcode);
        }

        return dc;

    }
    [Ajax.AjaxMethod]
    public DataSet bindTable(string pkgname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = clsbooking.getPkgDetail(pkgname);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = clsbooking.getPkgDetail(pkgname);
        }
        else
        {
            string[] parameterValueArray = new string[] { pkgname };
            string procedureName = "getPackageName_getPackageName_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            //ds = clsbooking.getPkgDetail(pkgname);
        }
        return ds;
        //string output = "";
        //output = "<div style=\"width:300px,height:200px,overflow:auto\"><table cellpadding=0 cellspacing=0 border=1><tr bgcolor=\"#7DAAE3\" class=\"dtGridHd12\"><td align=center>Select</td><td align=center width=\"100px\">Edition</td></tr>";
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    output = output + "<tr><td class=\"dtGrid\" align=center><input type=checkbox onclick=\"checkCount('" + ds.Tables[0].Rows[i].ItemArray[2].ToString() + "');\" value='" + ds.Tables[0].Rows[i].ItemArray[2].ToString() + "' id=chk" + i + " /></td><td align=center class=\"dtGrid\" width=\"100px\" id=td" + i + ">" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td></tr>";
        //}
        //output = output + "</table></div>";
        //tdtable.InnerHtml = output;
    }

    protected void btncopy_Click(object sender, EventArgs e)
    {

    }

    public void forbookingaudit()
    {
        saveormodify = "1";
        hiddensavemod.Value = saveormodify;
        fpnl = 0;

        btnshgrid.Enabled = false;
        txtagencypaymode.Enabled = false;
        // btnupload.Enabled = false;

        txtciobookid.Text = "";
        //  txtappby.Text = "";
        //txtaudit.Text = "";
        txtrono.Text = "";
        txtrodate.Text = "";
        txtcaption.Text = "";
        drpbillstatus.SelectedValue = "0";
        drprostatus.SelectedValue = "0";
        txtagency.Text = "";
        txtclient.Text = "";
        txtagencyaddress.Text = "";
        txtclientadd.Text = "";
        drpagscode.SelectedValue = "0";
        txtdockitno1.Text = "";
        txtexecname.Text = "";
        txtexeczone.Text = "";
        txtproduct.Text = "";
        //drpbrand.SelectedValue = "0";
        txtkeyno.Text = "";
        txtbillremark.Text = "";
        txtprintremark.Text = "";
        // drppackage.SelectedValue = "0";
        txtinsertion.Text = "";
        txtdummydate.Text = "";
        txtrepeatingdate.Text = "";
        drpbooktype.SelectedValue = "0";
        drpadcategory.SelectedValue = "0";
        drpadsubcategory.SelectedValue = "0";

        drpadcat3.SelectedValue = "0";
        drpadcat4.SelectedValue = "0";
        drpadcat5.SelectedValue = "0";

        drpcolor.SelectedValue = "0";
        drpuom.SelectedValue = "0";
        drppageposition.SelectedValue = "0";
        drppagetype.SelectedValue = "0";
        txtpageno.Text = "";
        drpadstype.SelectedValue = "0";
        //txtadsizetypeheight.Text = "";
        //txtadsizetypewidth.Text = "";
        txtratecode.SelectedValue = "0";
        drpscheme.Text = "";
        drpscheme.Text = "";
        drpcurrency.SelectedValue = "0";
        txtagreedrate.Text = "";
        txtagreedamt.Text = "";
        txtspedisc.Text = "";
        txtspacedisc.Text = "";
        txtextracharges.Text = "";
        txtcolum.Text = "";
        //txtbillcolumn.Text = "";
        ////txtbillarea.Text = "" = "";
        txtspediscper.Text = "";
        txtspadiscper.Text = "";


        txtcontractname.Text = "";
        txtcontracttype.Text = "";
        txtcardname.Text = "";
        drptype.SelectedValue = "0";
        drpmonth.SelectedValue = "0";
        drpyear.SelectedValue = "0";
        txtcardno.Text = "";

        drppackage.SelectedValue = "0";
        drppackagecopy.Items.Clear();
        txtagencypaymode.Items.Clear();
        //////////////////////////////
        txtdockitno1.Enabled = true;
        txtkeyno.Enabled = true;
        txtrono.Enabled = true;
        txtagency.Enabled = true;
        txtclient.Enabled = true;

        btnshgrid.Enabled = false;
        //btnupload.Enabled = false;

        txtciobookid.Enabled = true;

        saveormodify = "01";
        chkstatus(FlagStatus);

        btnQuery.Enabled = false;
        btnExecute.Enabled = true;
        btnSave.Enabled = false;
        btnsavepaginate.Enabled = false;
    }
    [Ajax.AjaxMethod]
    public DataSet getIssuePages(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.getPageInfo IssuePages = new NewAdbooking.Classes.getPageInfo();
            ds = IssuePages.clsGetIssuePages(compcode, pubdate, pubcode, centercode, editioncode, suppcode, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.getPageInfo IssuePages = new NewAdbooking.classesoracle.getPageInfo();
            ds = IssuePages.clsGetIssuePages(pubdate, pubcode, centercode, editioncode, suppcode, dateformat);
        }
        else
        {
            string[] parameterValueArray = new string[] { ConvertToDateTime(pubdate), pubcode, centercode, editioncode, suppcode };
            string procedureName = "websp_Issue_number_of_Pages";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.getPageInfo IssuePages = new NewAdbooking.classmysql.getPageInfo();
            //ds = IssuePages.clsGetIssuePages(pubdate, pubcode, centercode, editioncode, suppcode, dateformat);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet pageHeading(string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.getPageInfo page_Heading = new NewAdbooking.Classes.getPageInfo();
            ds = page_Heading.clspageHeading(pubdate, pubcode, centercode, editioncode, suppcode, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.getPageInfo page_Heading = new NewAdbooking.classesoracle.getPageInfo();
            ds = page_Heading.clspageHeading(pubdate, pubcode, centercode, editioncode, suppcode, dateformat);
        }
        else
        {
            //string[] parameterValueArray = new string[] { ConvertToDateTime(pubdate), pubcode, centercode, editioncode, suppcode };
            //string procedureName = "Websp_Pageheading_P_Websp_Pageheading";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.getPageInfo page_Heading = new NewAdbooking.classmysql.getPageInfo();
            //ds = page_Heading.clspageHeading(ConvertToDateTime(pubdate), pubcode, centercode, editioncode, suppcode, dateformat);
            NewAdbooking.classmysql.BookingMaster page_Heading = new NewAdbooking.classmysql.BookingMaster();
            ds = page_Heading.clspageHeading(ConvertToDateTime(pubdate), pubcode, centercode, editioncode, suppcode, dateformat);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet ShowPages(string pdate, string ppub, string pbkfor, string pedition, string psecpub, string pageno, string dateformat)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.getVolume ShowAds = new NewAdbooking.Classes.getVolume();
            ds = ShowAds.clsShowAd(pdate, ppub, pbkfor, pedition, psecpub, pageno, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.getVolume ShowAds = new NewAdbooking.classesoracle.getVolume();
            ds = ShowAds.clsShowAd(pdate, ppub, pbkfor, pedition, psecpub, pageno, dateformat);
        }
        else
        {
            //string[] parameterValueArray = new string[] { ConvertToDateTime(pdate), ppub, pbkfor, pedition, psecpub, pageno };
            //string procedureName = "Websp_Adonpage_P_Websp_Adonpage";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.getVolume ShowAds = new NewAdbooking.classmysql.getVolume();
            //ds = ShowAds.clsShowAd(pdate, ppub, pbkfor, pedition, psecpub, pageno, dateformat);
            NewAdbooking.classmysql.BookingMaster ShowAds = new NewAdbooking.classmysql.BookingMaster();
            ds = ShowAds.clsShowAd(pdate, ppub, pbkfor, pedition, psecpub, pageno, dateformat);
        }
        foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
        {


            string filename = ds.Tables[0].Rows[i]["file_name"].ToString();
            string path = Server.MapPath("temppdf/");
            path = path.Replace("\\ajax", "");
            path = path + filename + ".jpg";
            if (filename != "" && filename != "null" && filename != null)
            {


                if (System.IO.File.Exists(path))
                {
                    dr["FLAG"] = "y";
                    //    dr.SetModified();
                    dr.AcceptChanges();

                    //ds.Tables[0].Rows[i]["file_name"] = "y";
                }

            }

            //ds.Tables[0].Rows[i]["file_name"] = "n";
        }
        ds.AcceptChanges();

        return ds;
    }

    [Ajax.AjaxMethod]
    public void UpdateAd(string pdate, string ppub, string pbkfor, string pedition, string psecpub, string pageno, double xstcol, double ystrow, string iidnum, string pgid, string dateformat)
    {
        //  DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.getPageInfo Update_Ad = new NewAdbooking.Classes.getPageInfo();
            Update_Ad.clsUpdateAd(pdate, ppub, pbkfor, pedition, psecpub, pageno, xstcol, ystrow, iidnum, pgid, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.getPageInfo Update_Ad = new NewAdbooking.classesoracle.getPageInfo();
            Update_Ad.clsUpdateAd(pdate, ppub, pbkfor, pedition, psecpub, pageno, xstcol, ystrow, iidnum, pgid, dateformat);
        }
        else
        {
            string[] parameterValueArray = new string[] { pdate, ppub, pbkfor, pedition, psecpub, pageno, xstcol.ToString(), ystrow.ToString(), iidnum, pgid };
            string procedureName = "websp_UpdateAd_websp_UpdateAd_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.getPageInfo Update_Ad = new NewAdbooking.classmysql.getPageInfo();
            //Update_Ad.clsUpdateAd(pdate, ppub, pbkfor, pedition, psecpub, pageno, xstcol, ystrow, iidnum, pgid, dateformat);
        }
    }

    [Ajax.AjaxMethod]
    public void Pagination(string pdate, string pbkfor, string ppub, string psecpub, string pedition, int pageno, string dateformat)
    {
        // DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.getPageInfo Pagination_Ad = new NewAdbooking.Classes.getPageInfo();
            Pagination_Ad.clsPagination(pdate, pbkfor, ppub, psecpub, pedition, pageno, dateformat);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.getPageInfo Pagination_Ad = new NewAdbooking.classesoracle.getPageInfo();
            Pagination_Ad.clsPagination(pdate, pbkfor, ppub, psecpub, pedition, pageno, dateformat);
        }

        else
        {
            string[] parameterValueArray = new string[] { pdate, pbkfor, ppub, psecpub, pedition, pageno.ToString() };
            string procedureName = "Create_Dummy_Pagebestfit";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.getPageInfo Pagination_Ad = new NewAdbooking.classmysql.getPageInfo();
            //Pagination_Ad.clsPagination(pdate, pbkfor, ppub, psecpub, pedition, pageno, dateformat);
        }


    }
    [Ajax.AjaxMethod]
    public DataSet getwidthforcoll(string desc, string collumn, string compcode, string uom)
    {
        DataSet dc = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getwidth = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dc = getwidth.getwidthforcollumn(desc, collumn, compcode, uom);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getwidth = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dc = getwidth.getwidthforcollumn(desc, collumn, compcode, uom);
        }

        else
        {
            string[] parameterValueArray = new string[] { compcode, desc, collumn, uom };
            string procedureName = "book_getwidthforcollumn_book_getwidthforcollumn_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dc = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster getwidth = new NewAdbooking.classmysql.BookingMaster();
            //dc = getwidth.getwidthforcollumn(desc, collumn, compcode, uom);
        }

        return dc;

    }



    [Ajax.AjaxMethod]
    public DataSet getbookingdetail(string edition, string date)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getbookingdata = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = getbookingdata.fetchbookingdata(edition, date);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getbookingdata = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                ds = getbookingdata.fetchbookingdata(edition, date);
            }
            else
            {
                string[] parameterValueArray = new string[] { edition, date };
                string procedureName = "websp_getbookingdetail_websp_getbookingdetail_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster getbookingdata = new NewAdbooking.classmysql.BookingMaster();
                //ds = getbookingdata.fetchbookingdata(edition, date);
            }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet getEditionName(string compcode, string id_buttonText, string p_pub, string p_bkfor)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objgetEditionName = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objgetEditionName.clsGetEditionName(compcode, id_buttonText);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objgetEditionName = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            if (p_pub == "DJ" || p_pub == "IN")
                ds = objgetEditionName.clsGetEditionName_DJ(compcode, id_buttonText, p_pub, p_bkfor);
            else
                ds = objgetEditionName.clsGetEditionName(compcode, id_buttonText);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, id_buttonText };
            string procedureName = "websp_GetEditionName_websp_GetEditionName_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objgetEditionName = new NewAdbooking.classmysql.BookingMaster();
            //ds = objgetEditionName.clsGetEditionName(compcode, id_buttonText);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet CheckEditionRights(string compcode, string pkgName, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objEditionRights = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objEditionRights.clsEdiRights(compcode, pkgName, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objEditionRights = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objEditionRights.clsEdiRights(compcode, pkgName, userid);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, pkgName, userid };
            string procedureName = "Websp_edirights_P_Websp_edirights";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objEditionRights = new NewAdbooking.classmysql.BookingMaster();
            //ds = objEditionRights.clsEdiRights(compcode, pkgName, userid);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet SpaceAvailability(string compcode, string pdate, string ppub, string pbkfor, string pedition, string psecpub, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster Availability_Check = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = Availability_Check.clsSpaceAvailability(compcode, pdate, ppub, pbkfor, pedition, psecpub, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster Availability_Check = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = Availability_Check.clsSpaceAvailability(compcode, pdate, ppub, pbkfor, pedition, psecpub, dateformat);
        }
        else
        {
            //string[] parameterValueArray = new string[] { compcode, pdate, ppub, pbkfor, pedition, psecpub };
            //string procedureName = "websp_spaceAvailability_websp_spaceAvailability_p";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            NewAdbooking.classmysql.BookingMaster Availability_Check = new NewAdbooking.classmysql.BookingMaster();
            ds = Availability_Check.clsSpaceAvailability(compcode, pdate, ppub, pbkfor, pedition, psecpub, dateformat);
        }

        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet getPagesBookedVol(string compcode, string pdate, string ppub, string pbkfor, string pedition, string psecpub, int pgno, string spl_page, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objBookedVol = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objBookedVol.clsPagesBookedVol(compcode, pdate, ppub, pbkfor, pedition, psecpub, pgno, spl_page, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objBookedVol = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objBookedVol.clsPagesBookedVol(compcode, pdate, ppub, pbkfor, pedition, psecpub, pgno, spl_page, dateformat);
        }
        else
        {
            //string[] parameterValueArray = new string[] { compcode, pdate, ppub, pbkfor, pedition, psecpub, pgno.ToString() };
            //string procedureName = "websp_getPagesBookedVol_websp_getPagesBookedVol_p";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            NewAdbooking.classmysql.BookingMaster objBookedVol = new NewAdbooking.classmysql.BookingMaster();
            ds = objBookedVol.clsPagesBookedVol(compcode, pdate, ppub, pbkfor, pedition, psecpub, pgno.ToString());
        }

        return ds;
    }


    [Ajax.AjaxMethod]
    public void SubmitIssuePages(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.getPageInfo obj12 = new NewAdbooking.Classes.getPageInfo();
            obj12.clsSubmitIssuePages(compcode, pubdate, pubcode, centercode, editioncode, suppcode, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.getPageInfo obj12 = new NewAdbooking.classesoracle.getPageInfo();
            obj12.clsSubmitIssuePages(compcode, pubdate, pubcode, centercode, editioncode, suppcode, dateformat);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, pubdate, pubcode, centercode, editioncode, suppcode };
            string procedureName = "websp_SubmitIssuePages";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.Classes.getPageInfo obj12 = new NewAdbooking.Classes.getPageInfo();
            //obj12.clsSubmitIssuePages(compcode, pubdate, pubcode, centercode, editioncode, suppcode, dateformat);
        }
    }


    protected void grd_SpaceCheck_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_SpaceCheck.PageIndex = e.NewPageIndex;
    }
    protected void btnsavepaginate_Click(object sender, EventArgs e)
    {

    }
    [Ajax.AjaxMethod]
    public DataSet IssuePageDetails(string pdate, string pubcode, string centercode, string editioncode, string suppcode, string ppageno, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objIssuePageDetails = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objIssuePageDetails.clsIssuePageDetails(pdate, pubcode, centercode, editioncode, suppcode, ppageno, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objIssuePageDetails = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objIssuePageDetails.clsIssuePageDetails(pdate, pubcode, centercode, editioncode, suppcode, ppageno, dateformat);
        }
        else
        {
            string[] parameterValueArray = new string[] { ConvertToDateTime(pdate), pubcode, centercode, editioncode, suppcode, ppageno };
            string procedureName = "Websp_Issuepagedetails_P_Websp_Issuepagedetails";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objIssuePageDetails = new NewAdbooking.classmysql.BookingMaster();
            //ds = objIssuePageDetails.clsIssuePageDetails(pdate, pubcode, centercode, editioncode, suppcode, ppageno, dateformat);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getCurrentBooking(string ciobookid, string iRowid, string ins_id)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objgetCurrentBooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objgetCurrentBooking.clsgetCurrentBooking(ciobookid, iRowid, ins_id);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objgetCurrentBooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objgetCurrentBooking.clsgetCurrentBooking(ciobookid, iRowid, ins_id);
        }
        else
        {
            string[] parameterValueArray = new string[] { ciobookid, iRowid, ins_id };
            string procedureName = "websp_getCurrentBooking_P_websp_getCurrentBooking";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objgetCurrentBooking = new NewAdbooking.classmysql.BookingMaster();
            //ds = objgetCurrentBooking.clsgetCurrentBooking(ciobookid, iRowid, ins_id);
        }
        return ds;
    }



    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void UpdateBooking_AdDummy(string ciobookid, string iRowid, string ins_id, string pdate, string ppub, string pbkfor, string pedition, string psecpub, string pcolour, string psplpage, string padtype, string ppageno, string adstatus, string adfilename, double adheight, double adwidth)
    {
        // DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objUpdateBooking_AdDummy = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            objUpdateBooking_AdDummy.clsUpdateBooking_AdDummy(ciobookid, iRowid, ins_id, pdate, ppub, pbkfor, pedition, psecpub, pcolour, psplpage, padtype, ppageno, adstatus, adfilename, adheight, adwidth);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objUpdateBooking_AdDummy = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            objUpdateBooking_AdDummy.clsUpdateBooking_AdDummy(ciobookid, iRowid, ins_id, pdate, ppub, pbkfor, pedition, psecpub, pcolour, psplpage, padtype, ppageno, adstatus, adfilename, adheight, adwidth, Session["dateformat"].ToString());
        }
        else
        {
            string[] parameterValueArray = new string[] { ciobookid, iRowid, ins_id, pdate, ppub, pbkfor, pedition, psecpub, pcolour, psplpage, padtype, ppageno, adstatus, adfilename, adheight.ToString(), adwidth.ToString() };
            string procedureName = "websp_UpdateBooking_AdDummy";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objUpdateBooking_AdDummy = new NewAdbooking.classmysql.BookingMaster();
            //objUpdateBooking_AdDummy.clsUpdateBooking_AdDummy(ciobookid, iRowid, ins_id, pdate, ppub, pbkfor, pedition, psecpub, pcolour, psplpage, padtype, ppageno, adstatus, adfilename, adheight, adwidth, Session["dateformat"].ToString());
        }
        // return ds;
    }
    [Ajax.AjaxMethod]
    public void UpdatePage_Booking(string ciobookid, string iRowid, string ppageno)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objUpdatePage_Booking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            objUpdatePage_Booking.clsUpdatePage_Booking(ciobookid, iRowid, ppageno);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objUpdatePage_Booking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            objUpdatePage_Booking.clsUpdatePage_Booking(ciobookid, iRowid, ppageno);
        }
        else
        {
            string[] parameterValueArray = new string[] { ciobookid, iRowid, ppageno };
            string procedureName = "websp_UpdatePage_Booking";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objUpdateBooking_AdDummy = new NewAdbooking.classmysql.BookingMaster();
            //objUpdateBooking_AdDummy.clsUpdatePage_Booking(ciobookid, iRowid, ppageno);
        }
    }
    [Ajax.AjaxMethod]
    public DataSet getPremPage(string premcode, string id)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objUpdatePage_Booking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objUpdatePage_Booking.getPremPage(premcode, id);
            // return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objPagePremium = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objPagePremium.getPremPage(premcode, id);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string[] parameterValueArray = new string[] { premcode, id };
            string procedureName = "getPremium_PageNo_getPremium_PageNo_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objPagePremium = new NewAdbooking.classmysql.BookingMaster();
            //ds = objPagePremium.getPremPage(premcode, id);

        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getSupplementName(string compcode, string id_buttonText)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objgetSupplementName = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objgetSupplementName.clsgetSupplementName(compcode, id_buttonText);
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, id_buttonText };
            string procedureName = "websp_GetSupplementName";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objPagePremium = new NewAdbooking.classmysql.BookingMaster();
            //ds = objgetSupplementName.clsgetSupplementName(compcode, id_buttonText);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet GetCityCode(string compcode, string editioncode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objGetCityCode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objGetCityCode.clsGetCityCode(compcode, editioncode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objGetCityCode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objGetCityCode.clsGetCityCode(compcode, editioncode);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, editioncode };
            string procedureName = "websp_GetCityCode";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objGetCityCode = new NewAdbooking.classmysql.BookingMaster();
            //ds = objGetCityCode.clsGetCityCode(compcode, editioncode);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet ExistingBookingVolume(string compcode, string currdate, string edition_Text, string premium, string adpage)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objExistingBookingVolume = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objExistingBookingVolume.clsExistingBookingVolume(compcode, currdate, edition_Text, premium, adpage);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objExistingBookingVolume = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objExistingBookingVolume.clsExistingBookingVolume(compcode, currdate, edition_Text, premium, adpage);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, currdate, edition_Text, premium, adpage };
            string procedureName = "websp_ExistingBookingVolume";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objExistingBookingVolume = new NewAdbooking.classmysql.BookingMaster();
            //ds = objExistingBookingVolume.clsExistingBookingVolume(compcode, currdate, edition_Text, premium, adpage);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet PremiumCode(string compcode, string pubcode, string editioncode, string adPremium)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objPremiumCode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objPremiumCode.clsPremiumCode(compcode, pubcode, editioncode, adPremium);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objPremiumCode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objPremiumCode.clsPremiumCode(compcode, pubcode, editioncode, adPremium);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, pubcode, editioncode, adPremium };
            string procedureName = "websp_PremiumCode";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objPremiumCode = new NewAdbooking.classmysql.BookingMaster();
            //ds = objPremiumCode.clsPremiumCode(compcode, pubcode, editioncode, adPremium);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet ExistingBookingSize(string compcode, string currdate, string pubcode, string centercode, string editioncode, string suppcode, string premium, string adpage)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objExistingBookingSize = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objExistingBookingSize.clsExistingBookingSize(compcode, currdate, pubcode, centercode, editioncode, suppcode, premium, adpage);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objExistingBookingSize = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objExistingBookingSize.clsExistingBookingSize(compcode, currdate, pubcode, centercode, editioncode, suppcode, premium, adpage);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, currdate, pubcode, centercode, editioncode, suppcode, premium, adpage };
            string procedureName = "websp_ExistingBookingSize";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objExistingBookingSize = new NewAdbooking.classmysql.BookingMaster();
            //ds = objExistingBookingSize.clsExistingBookingSize(compcode, currdate, pubcode, centercode, editioncode, suppcode, premium, adpage);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet BookingEditionCode(string compcode, string edition_Text)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objEditionCode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objEditionCode.clsBookingEditionCode(compcode, edition_Text);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objEditionCode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objEditionCode.clsBookingEditionCode(compcode, edition_Text);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, edition_Text };
            string procedureName = "websp_BookingEditionCode";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objEditionCode = new NewAdbooking.classmysql.BookingMaster();
            //ds = objEditionCode.clsBookingEditionCode(compcode, edition_Text);
        }
        return ds;
    }
    public string getDate(string dateformat, string dateValue)
    {
        //splitting of date
        string dateReturn = "";
        if (dateValue != "")
        {
            char[] splitterfrom = { '/' };
            string[] myarrayfrom = dateValue.Split(splitterfrom);
            string dd, mm, yyyy;
            if (dateformat == "dd/mm/yyyy")
            {
                //for from date
                dd = myarrayfrom[0];
                mm = myarrayfrom[1];
                yyyy = myarrayfrom[2];

                dateReturn = mm + "/" + dd + "/" + yyyy;


            }
            //else if (dateformat == "yyyy/mm/dd")
            //{
            //    yyyy = myarrayfrom[0];
            //    mm = myarrayfrom[1];
            //    dd = myarrayfrom[2];

            //    dateReturn = mm + "/" + dd + "/" + yyyy;
            //}
            else
            {
                dateReturn = dateValue;
            }
        }
        return dateReturn;
    }


    [Ajax.AjaxMethod]
    public DataSet bindadcat3(string adcat3, string compcode, string value)
    {
        DataSet dacat = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dacat = getadcat3.getvalfromadcat3(adcat3, compcode, value);
            return dacat;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            dacat = getadcat3.getvalfromadcat3(adcat3, compcode, value);
            return dacat;
        }
        else
        {
            string[] parameterValueArray = new string[] { adcat3, compcode, value };
            string procedureName = "class_bindadcat3_class_bindadcat3_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dacat = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();
            //dacat = getadcat3.getvalfromadcat3(adcat3, compcode, value);
            return dacat;
        }
    }
    [Ajax.AjaxMethod]
    public DataSet getRetainerComm(string reatinername, string compcode)
    {
        DataSet dacat = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            dacat = getadcat3.getRetainerComm(reatinername, compcode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dacat = getadcat3.getRetainerComm(reatinername, compcode);

        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, reatinername };
            string procedureName = "GETRETAINERCOMM_GETRETAINERCOMM_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dacat = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();
            //dacat = getadcat3.getRetainerComm(reatinername, compcode);
        }
        return dacat;
    }
    //*6Aug
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindRetainer(string compcode, string reatinername, string agcode)
    {
        DataSet dsret = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getRetain = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            NewAdbooking.Classes.tv_booking_transaction getRetain = new NewAdbooking.Classes.tv_booking_transaction();
            dsret = getRetain.getretainer_n(compcode, reatinername, Session["revenue"].ToString(), Session["userid"].ToString());

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {


            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getRetain = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dsret = getRetain.getretainerDJ(compcode, reatinername, "0", Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString(), Session["userid"].ToString(), agcode);
            }
            else
            {
                NewAdbooking.classesoracle.tv_booking_transaction getRetain = new NewAdbooking.classesoracle.tv_booking_transaction();
                if (Session["FILTER"].ToString() == "D")
                {
                    dsret = getRetain.getretainer_n(compcode, reatinername, Session["revenue"].ToString(), Session["userid"].ToString());
                }
                else
                {
                    dsret = getRetain.getretainer_n(compcode, reatinername, Session["revenue"].ToString(), Session["userid"].ToString());
                }
            }

        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, reatinername, Session["revenue"].ToString(), Session["userid"].ToString() };
            string procedureName = "GETRETAINER_N_GETRETAINER_N_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dsret = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster getRetain = new NewAdbooking.classmysql.BookingMaster();
            //dsret = getRetain.getretainer_n(compcode, reatinername, Session["revenue"].ToString(), Session["userid"].ToString());
        }
        return dsret;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindRetainer_new(string compcode, string reatinername, string agcode, string rev_centret)
    {
        DataSet dsret = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getRetain = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            NewAdbooking.Classes.tv_booking_transaction getRetain = new NewAdbooking.Classes.tv_booking_transaction();
            dsret = getRetain.getretainer_n(compcode, reatinername, rev_centret, Session["userid"].ToString());

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {


            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getRetain = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dsret = getRetain.getretainerDJ(compcode, reatinername, "0", Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString(), Session["userid"].ToString(), agcode);
            }
            else
            {
                NewAdbooking.classesoracle.tv_booking_transaction getRetain = new NewAdbooking.classesoracle.tv_booking_transaction();
                if (Session["FILTER"].ToString() == "D")
                {
                    dsret = getRetain.getretainer_n(compcode, reatinername, rev_centret, Session["userid"].ToString());
                }
                else
                {
                    dsret = getRetain.getretainer_n(compcode, reatinername, rev_centret, Session["userid"].ToString());
                }
            }

        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, reatinername, rev_centret, Session["userid"].ToString() };
            string procedureName = "GETRETAINER_N_GETRETAINER_N_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dsret = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        return dsret;
    }
    [Ajax.AjaxMethod]
    public DataSet get_rate(string noofinsertion, string dateformat, string compcode, string uom, string adtype, string currency, string ratecode, string clientcode, string uomdesc, string agencycode, string newcode, string center, string ratepremtype, string premium, string schemetype, string fdate, string ldate, int currentcounter, string chkadon_var, string discprem, string spediscper, string pospremdisc)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getrate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds1 = getrate.get_rate_qbc(noofinsertion, dateformat, compcode, uom, adtype, currency, ratecode, clientcode, uomdesc, agencycode, newcode, center, ratepremtype, premium, schemetype, currentcounter, fdate, ldate, chkadon_var, discprem, spediscper, pospremdisc, "", "", "");
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getrate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds1 = getrate.get_rate_qbc(noofinsertion, dateformat, compcode, uom, adtype, currency, ratecode, clientcode, uomdesc, agencycode, newcode, center, ratepremtype, premium, schemetype, fdate, ldate, currentcounter, chkadon_var, discprem, spediscper, pospremdisc, "", "", "");
        }
        else
        {
            string[] parameterValueArray = new string[] { noofinsertion, dateformat, compcode, uom, adtype, currency, ratecode, clientcode, uomdesc, ConfigurationSettings.AppSettings["openreferExtra"].ToString(), agencycode, newcode, center, ratepremtype, premium, schemetype, fdate, ldate, currentcounter.ToString(), ConfigurationManager.AppSettings["FETCHMINSIZEPACKAGERATE"].ToString(), chkadon_var, discprem, spediscper, pospremdisc, "", "", "" };
            /*string procedureName = "rate_qbc_rate_qbc_p";
          //  string procedureName = "rate_qbc_rate_qbc_p_testsubh";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds1 = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
            //NewAdbooking.classmysql.BookingMaster getrate = new NewAdbooking.classmysql.BookingMaster();
            //ds = getrate.get_rate_qbc(noofinsertion, dateformat, compcode, uom, adtype, currency, ratecode, clientcode, uomdesc, agencycode, newcode, center, ratepremtype, premium, schemetype, fdate, ldate, currentcounter, chkadon_var, discprem, spediscper, pospremdisc, "", "", "");

            NewAdbooking.classmysql.BookingMaster getrate = new NewAdbooking.classmysql.BookingMaster();
            ds1 = getrate.get_rate_qbc1(noofinsertion, dateformat, compcode, uom, adtype, currency, ratecode, clientcode, uomdesc, ConfigurationSettings.AppSettings["openreferExtra"].ToString(), agencycode, newcode, center, ratepremtype, premium, schemetype, fdate, ldate, currentcounter.ToString(), ConfigurationManager.AppSettings["FETCHMINSIZEPACKAGERATE"].ToString(), chkadon_var, discprem, spediscper, pospremdisc, "", "", "");

        }
        return ds1;
    }

    [Ajax.AjaxMethod]
    public DataSet bindcolorForGrid(string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindcolor = new NewAdbooking.Classes.Contract();
            ds = bindcolor.colorbind(compcode, userid);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract bindcolor = new NewAdbooking.classesoracle.Contract();
                ds = bindcolor.colorbind(compcode, userid);
            }
            else
            {
                //string[] parameterValueArray = new string[] { compcode, userid };
                //string procedureName = "bindcolor_bindcolor_p";
                //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                NewAdbooking.classmysql.Contract bindcolor = new NewAdbooking.classmysql.Contract();
                ds = bindcolor.colorbind(compcode, userid);
            }
        return ds;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindpagePositioninGrid(string compcode, string txtdatetime, string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = clsbooking.bindPagePosition(compcode, txtdatetime, Session["dateformat"].ToString(), adtype);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                ds = clsbooking.bindPagePosition(compcode, txtdatetime, Session["dateformat"].ToString(), adtype);
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, txtdatetime, adtype };
                string procedureName = "WEBSP_GETPAGEPOSITION_DATEWISE";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
                //ds = clsbooking.bindPagePosition(compcode, txtdatetime, Session["dateformat"].ToString(), adtype);
            }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet advcatinGrid(string compcode, string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bind.advdatacategory(compcode, adtype);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                ds = bind.advdatacategory(compcode, adtype);
            }
            else
            {
                string procedureName = "";
                string[] parameterValueArray = new string[] { compcode, adtype };
                if (adtype == "adtype")
                {
                    parameterValueArray = new string[] { compcode, adtype };
                    procedureName = "book_advcategory1_book_advcategory1_p";
                }
                else
                {
                    parameterValueArray = new string[] { compcode, adtype, "" };
                    procedureName = "book_advcategory_book_advcategory_p";
                }
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
                //ds = bind.advdatacategory(compcode, adtype);
            }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet getadsubcat_grid(string compcode, string adcat)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CombinationMaster cls_comb = new NewAdbooking.Classes.CombinationMaster();
            da = cls_comb.advdatasubcatcat(compcode, adcat);
            return da;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.CombinationMaster cls_comb = new NewAdbooking.classesoracle.CombinationMaster();
                da = cls_comb.advdatasubcatcat(compcode, adcat);
                return da;
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, adcat };
                string procedureName = "advsubcattyp_advsubcattyp_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                da = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.CombinationMaster cls_comb = new NewAdbooking.classmysql.CombinationMaster();
                //da = cls_comb.advdatasubcatcat(compcode, adcat);
                return da;
            }
    }

    [Ajax.AjaxMethod]
    public DataSet getBookingIdNo(string compcode, string auto, string no, string cioid)
    {
        DataSet da = new DataSet();
        if (no == "0" || no == "1" || no == "2")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                da = autocode.autogenrated(compcode, auto, no);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                    da = autocode.autogenrated(compcode, auto, no);

                }
                else
                {
                    string[] parameterValueArray = new string[] { compcode, auto, no };
                    string procedureName = "getautocodebooking_getautocodebooking_p";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    da = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                    //NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();
                    //da = autocode.autogenrated(compcode, auto, no);
                }
        }

        else if (no == "3")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objMaxReceipt_No = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                da = objMaxReceipt_No.clsMaxReceipt();
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objMaxReceipt_No = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                da = objMaxReceipt_No.clsMaxReceipt(cioid);
            }
            else
            {
                string[] parameterValueArray = new string[] { cioid };
                string procedureName = "websp_MaxReceipt_websp_MaxReceipt_P";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                da = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster objMaxReceipt_No = new NewAdbooking.classmysql.BookingMaster();
                //da = objMaxReceipt_No.clsMaxReceipt(cioid);
            }
        }
        return da;
    }

    [Ajax.AjaxMethod]
    public string getdateCHK(string dateformat, string date)
    {
        datesave getdatechk = new datesave();
        string ret = getdatechk.getDate(dateformat, date);
        return ret;
    }

    [Ajax.AjaxMethod]
    public DataSet chkwalkinClient(string client, string compcode)
    {
        DataSet dcl = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkclient = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dcl = chkclient.forwalkclient(client, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkclient = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dcl = chkclient.forwalkclient(client, compcode);
            }
            else
            {
                /*string[] parameterValueArray = new string[] { compcode, client };
                string procedureName = "chkforwalkinnclient_chkforwalkinnclient_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dcl = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
                NewAdbooking.classmysql.BookingMaster chkclient = new NewAdbooking.classmysql.BookingMaster();
                dcl = chkclient.forwalkclientN(client, compcode);
            }
        return dcl;
    }

    [Ajax.AjaxMethod]
    public DataSet bookidchk(string compcode, string cioid, string agency, string agencycode, string rono, string val, string keyno)
    {
        DataSet dck = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkbookid = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dck = chkbookid.bookidchk(compcode, cioid, agency, agencycode, rono, "0", keyno);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkbookid = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dck = chkbookid.bookidchk(compcode, cioid, agency, agencycode, rono, "0", keyno);
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, cioid, agency, agencycode, rono, "0", keyno };
                string procedureName = "chkciobookid_chkciobookid_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dck = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster chkbookid = new NewAdbooking.classmysql.BookingMaster();
                //dck = chkbookid.bookidchk(compcode, cioid, agency, agencycode, rono, "0", keyno);

            }
        return dck;
    }

    [Ajax.AjaxMethod]
    public DataSet chkrategroup(string color, string adcategory, string subcategory, string package, string ratecode, string startdate, string currency, string adtype, string compcode, string agency, string client, string dateformat)
    {
        DataSet dgr = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkrategrupcode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dgr = chkrategrupcode.chkrategroup(color, adcategory, subcategory, package, ratecode, startdate, currency, adtype, compcode, agency, client, dateformat);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkrategrupcode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dgr = chkrategrupcode.chkrategroup(color, adcategory, subcategory, package, ratecode, startdate, currency, adtype, compcode, agency, client, dateformat);
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, adtype, color, adcategory, subcategory, currency, ratecode, package, startdate, agency, client };
                string procedureName = "chkrategroupcode_chkrategroupcode_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dgr = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster chkrategrupcode = new NewAdbooking.classmysql.BookingMaster();
                //dgr = chkrategrupcode.chkrategroup(color, adcategory, subcategory, package, ratecode, startdate, currency, adtype, compcode, agency, client, dateformat);
            }
        return dgr;
    }

    [Ajax.AjaxMethod]

    public string insertBooking(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, string billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtyp, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string val1, string prev_cioid, string prev_receipt, string prev_ga, string val2, string val3, string val4, string val5, string val6, string val7, string val8, string dateformat, string retainer, string txtaddagencycommrate, string srtcancel, string auditstatus, string addlamt, string retamt, string retper, string cashrecieved, string ciragency, string cirrate, string ciredition, string cirpublication, string ciragencysubcode, string bartertype, string attach1, string attach2, string cashdiscount, string cashdiscountper, string drpdiscprem, string doctype, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string dealerpanel, string dealerh, string dealerw, string dealertype, string multicode, string mobno, string agreedrate_active, string agreedamt_active, string grossamtlocal, string billamtlocal, string chkadon, string refid, string rcpt_currency, string cur_convrate, string revisedate, string clienttype, string translation, string translationcharge, string fmgreasons, string canclecharge, string transdisc, string pospremdisc, string billhold, string fixed_booking, string vat_code, string coupantype, string coupanno, string clientcatdisc, string clientcatamt, string clientcatdistype, string flatfreqdisc, string flatfreqamt, string flatfreqdisctype, string catdisc, string catamt, string catdisctype, string representative, string teamcode, string industry, string productcat, string chkgstinc, string ppubl_rev_cent, string contractperson, string emailid, string quotationno, string TEMP_AGENCYRATECODE)
    {
        DataSet dins = new DataSet();
        DataSet dscancel = new DataSet();
        string error = "";
        try
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster insert = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                NewAdbooking.Classes.adbooking insert = new NewAdbooking.Classes.adbooking();
                dins = insert.insertbooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "", prev_cioid, prev_receipt, Convert.ToDecimal(prev_ga), "0", "0", "0", "0", "0", "0", "0", dateformat, retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, attach1, attach2, cashdiscount, cashdiscountper, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, revisedate, clienttype, translation, translationcharge, fmgreasons, canclecharge, transdisc, pospremdisc, billhold, "", "", "N", "", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype, representative, teamcode, industry, productcat, chkgstinc, ppubl_rev_cent, contractperson, emailid, quotationno);
                if (srtcancel == "1")
                {
                    FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster insert1 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                    dscancel = insert1.cancelbooking(prev_cioid);
                }
                dscancel.Dispose();

            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    //  FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insert = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                    NewAdbooking.classesoracle.adbooking insert = new NewAdbooking.classesoracle.adbooking();
                    error = insert.insertbooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "", prev_cioid, prev_receipt, Convert.ToDecimal(prev_ga), "0", "0", "0", "0", "0", "0", "0", dateformat, retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, attach1, attach2, cashdiscount, cashdiscountper, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, revisedate, clienttype, translation, translationcharge, fmgreasons, canclecharge, transdisc, pospremdisc, billhold, "N", "", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype, representative, teamcode, industry, productcat, chkgstinc, ppubl_rev_cent, contractperson, emailid, quotationno);

                    if (srtcancel == "1")
                    {
                        dscancel = insert.cancelbooking(prev_cioid);
                    }
                    dscancel.Dispose();

                }
                else
                {
                    string[] parameterValueArray = new string[] { ConvertToDateTime(date_time), adsizetype, branch, booked_by, prevbook, approvedby, ciobookid, audit, rono, ConvertToDateTime(rodate), caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, ConvertToDateTime(startdate), repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, scheme, currency, ratecode, agreedrate, agreedamt, spedisc, compcode, spacedisx, specialcharges, userid, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, billpay, revenuecenter, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxagency, boxaddress, boxclient, coupan, bookingtype, tfn, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, specdiscper, spacediscper, billarea, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "", prev_cioid, prev_receipt, prev_ga, "0", "0", "0", "0", "0", "0", "0", retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, cashdiscount, cashdiscountper, attach1, attach2, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, ConvertToDateTime(chkdate), chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, revisedate, clienttype, translation, translationcharge, fmgreasons, canclecharge, transdisc, pospremdisc, billhold, "", "", "N", "", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype, representative, teamcode, industry, productcat, chkgstinc, ppubl_rev_cent, contractperson, emailid, quotationno, TEMP_AGENCYRATECODE };
                    string procedureName = "insertintobooking_insertintobooking_p";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    dins = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                    if (srtcancel == "1")
                    {
                        string[] parameterValueArray1 = new string[] { prev_cioid };
                        string procedureName1 = "cancelbooking_cancelbooking_P";
                        dscancel = sms.DynamicBindProcedure(procedureName1, parameterValueArray1);
                    }

                    //NewAdbooking.classmysql.BookingMaster insert = new NewAdbooking.classmysql.BookingMaster();
                    // dins = insert.insertbookingqbc(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "", prev_cioid, prev_receipt, Convert.ToDecimal(prev_ga),"0", "0", "0", "0", "0", "0", "0", dateformat, retainer, txtaddagencycommrate, "", addlamt, retamt, retper, cashrecieved);
                    //error = insert.insertbooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "", prev_cioid, prev_receipt, Convert.ToDecimal(prev_ga), "0", "0", "0", "0", "0", "0", "0", dateformat, retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, attach1, attach2, cashdiscount, cashdiscountper, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, revisedate, clienttype, translation, translationcharge, fmgreasons, canclecharge, transdisc, pospremdisc, billhold, "N", "", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype, representative, teamcode,industry,productcat);

                    //if (srtcancel == "1")
                    //{
                    //    dscancel = insert.cancelbooking(prev_cioid);
                    //}
                    dscancel.Dispose();

                }
        }
        catch (Exception e)
        {
            error = e.Message;

        }
        return error;
    }

    [Ajax.AjaxMethod]
    public DataSet insertcashreceived(string ciobookid, string receiptno, string drpcashrecieved)
    {
        DataSet dscash = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insert = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dscash = insert.insertCashReceived(ciobookid, receiptno, drpcashrecieved);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster insert = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dscash = insert.insertCashReceived(ciobookid, receiptno, drpcashrecieved);
        }
        else
        {
            string[] parameterValueArray = new string[] { ciobookid, receiptno, drpcashrecieved };
            string procedureName = "insertintocashreceiveddetail";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dscash = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster insert = new NewAdbooking.classmysql.BookingMaster();
            //dscash = insert.insertCashReceived(ciobookid, receiptno, drpcashrecieved);
        }
        return dscash;
    }


    [Ajax.AjaxMethod]
    public void deleteid(string cioid, string compcode)
    {
        DataSet ddl = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster delid = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ddl = delid.deleteid(cioid, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster delid = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                ddl = delid.deleteid(cioid, compcode);

            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, cioid };
                string procedureName = "deletecioid_deletecioid_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ddl = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster delid = new NewAdbooking.classmysql.BookingMaster();
                //ddl = delid.deleteid(cioid, compcode);
            }
    }


    [Ajax.AjaxMethod]
    public void InsertintoTemp(string cioid, string compcode)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objInsertintoTemp = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            objInsertintoTemp.clsInsertintoTemp(cioid, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objInsertintoTemp = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            objInsertintoTemp.clsInsertintoTemp(cioid, compcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, cioid };
            string procedureName = "websp_InsertintoTemp";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objInsertintoTemp = new NewAdbooking.classmysql.BookingMaster();
            //objInsertintoTemp.clsInsertintoTemp(cioid, compcode);
        }
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public string Insert_rcpthdr(string compcode, string userid, string rcptno, string date_time, string chqno, string chqdate, string chqamt, string bankname, string ag_codesubcode, string ag_code, string ag_subcode, string ptype, string dateformat, string remarks, string ourbank, string repcode, string doctype, string revenue, string cioid, string execname, string retainer, string prevcioid)
    {
        string error = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objInsert_rcpthdr = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            //  if (ptype == "CA0")
            //    objInsert_rcpthdr.clsInsert_rcpthdr(compcode, userid, revenue, doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, "", chqno, chqdate, bankname, remarks, repcode, date_time, ag_code, ag_subcode, dateformat, ourbank);
            //  else
            error = objInsert_rcpthdr.clsInsert_rcpthdr(compcode, userid, revenue, doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, "", chqno, chqdate, bankname, remarks, repcode, date_time, ag_code, ag_subcode, dateformat, ourbank, cioid, execname, retainer, prevcioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objInsert_rcpthdr = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            //if (ptype == "CA0")
            //    objInsert_rcpthdr.clsInsert_rcpthdr(compcode, userid, Session["revenue"].ToString(), doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, "", chqno, chqdate, bankname, remarks, repcode, date_time, ag_code, ag_subcode, dateformat, ourbank);
            //    else
            objInsert_rcpthdr.clsInsert_rcpthdr(compcode, userid, revenue, doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, "", chqno, chqdate, bankname, remarks, repcode, date_time, ag_code, ag_subcode, dateformat, ourbank);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, userid, revenue, doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, "", chqno, chqdate, bankname, remarks, repcode, date_time, ag_code, ag_subcode, dateformat, ourbank };
            string procedureName = "Receiptsave_booking_Receiptsave_booking_P";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objInsert_rcpthdr = new NewAdbooking.classmysql.BookingMaster();
            //objInsert_rcpthdr.clsInsert_rcpthdr(compcode, userid, revenue, doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, "", chqno, chqdate, bankname, remarks, repcode, date_time, ag_code, ag_subcode, dateformat, ourbank);
        }
        return error;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void Insert_rcptdet(string compcode, string userid, string rcptno, string date_time, string chqno, string chqdate, string chqamt, string bankname, string ag_codesubcode, string ag_code, string ag_subcode, string ptype, string dateformat, string remarks, string cioid, string doctype, string revenue)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objInsert_rcptdet = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            //if(ptype=="CA0")
            //    objInsert_rcptdet.clsInsert_rcptdet(compcode, userid, Session["revenue"].ToString(), doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, chqno, chqdate, bankname, date_time, ag_code, ag_subcode, dateformat, remarks, cioid);
            //else
            objInsert_rcptdet.clsInsert_rcptdet(compcode, userid, revenue, doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, chqno, chqdate, bankname, date_time, ag_code, ag_subcode, dateformat, remarks, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objInsert_rcptdet = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            //if (ptype == "CA0")
            //    objInsert_rcptdet.clsInsert_rcptdet(compcode, userid, Session["revenue"].ToString(), doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, chqno, chqdate, bankname, date_time, ag_code, ag_subcode, dateformat, remarks);
            //else
            objInsert_rcptdet.clsInsert_rcptdet(compcode, userid, revenue, doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, chqno, chqdate, bankname, date_time, ag_code, ag_subcode, dateformat, remarks);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, userid, revenue, doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, chqno, chqdate, bankname, date_time, ag_code, ag_subcode, dateformat, remarks };
            string procedureName = "Receiptsave1_booking_Receiptsave1_booking_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objInsert_rcptdet = new NewAdbooking.classmysql.BookingMaster();
            //objInsert_rcptdet.clsInsert_rcptdet(compcode, userid, revenue, doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, chqno, chqdate, bankname, date_time, ag_code, ag_subcode, dateformat, remarks);
        }
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void update_chqinfo(string compcode, string rcptno, string chqno, string chqdate, string chqamt, string bankname, string ag_codesubcode, string ag_code, string ag_subcode, string ppaymodres, string ptype, string date_time, string dateformat, string remarks, string ourbank, string repcode, string cioid, string revenue, string execname, string retainer, string prevcioid, string grossamt)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objupdate_chqinfo = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            //    if (ppaymodres == "CA0")
            //    objupdate_chqinfo.clsupdate_chqinfo(compcode, rcptno, chqno, chqdate, chqamt, bankname, ag_codesubcode, ag_code, ag_subcode, ppaymodres, "RCP", date_time, dateformat, remarks, ourbank, repcode, revenue, Session["userid"].ToString(),cioid);
            //  else
            //  objupdate_chqinfo.clsupdate_chqinfo(compcode, rcptno, chqno, chqdate, chqamt, bankname, ag_codesubcode, ag_code, ag_subcode, ppaymodres, ptype, date_time, dateformat, remarks, ourbank, repcode, revenue, Session["userid"].ToString(), cioid, execname, retainer, prevcioid, grossamt);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objupdate_chqinfo = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            //if (ppaymodres == "CA0")
            //    objupdate_chqinfo.clsupdate_chqinfo(compcode, rcptno, chqno, chqdate, chqamt, bankname, ag_codesubcode, ag_code, ag_subcode, ppaymodres, ptype, date_time, dateformat, remarks, Session["center"].ToString(), Session["userid"].ToString(), ourbank, repcode);
            //else
            // objupdate_chqinfo.clsupdate_chqinfo(compcode, rcptno, chqno, chqdate, chqamt, bankname, ag_codesubcode, ag_code, ag_subcode, ppaymodres, ptype, date_time, dateformat, remarks, Session["center"].ToString(), Session["userid"].ToString(), ourbank, repcode);
            objupdate_chqinfo.clsupdate_chqinfo(compcode, rcptno, chqno, chqdate, chqamt, bankname, ag_codesubcode, ag_code, ag_subcode, ppaymodres, ptype, date_time, dateformat, remarks, ourbank, repcode, revenue, Session["userid"].ToString(), cioid, execname, retainer, prevcioid, grossamt);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, rcptno, chqno, chqdate, chqamt, bankname, ag_codesubcode, ag_code, ag_subcode, ppaymodres, ptype, date_time, dateformat, remarks, ourbank, repcode, revenue, Session["userid"].ToString(), cioid, execname, retainer, prevcioid, grossamt };
            string procedureName = "Websp_Update_Chqinfo_Websp_Update_Chqinfo_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objupdate_chqinfo = new NewAdbooking.classmysql.BookingMaster();
            //objupdate_chqinfo.clsupdate_chqinfo(compcode, rcptno, chqno, chqdate, chqamt, bankname, ag_codesubcode, ag_code, ag_subcode, ppaymodres, ptype, date_time, dateformat, remarks, ourbank, repcode, revenue, Session["userid"].ToString(), cioid, execname, retainer, prevcioid, grossamt);
        }
    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void Insert_outstand(string compcode, string userid, string rcptno, string date_time, string chqno, string chqdate, string chqamt, string bankname, string ag_codesubcode, string ag_code, string ag_subcode, string ptype, string dateformat, string doctype, string revenue)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objInsert_outstand = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            //if(ptype=="CA0")
            //    objInsert_outstand.clsInsert_outstand(compcode, userid, Session["revenue"].ToString(), doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, date_time, ag_code, ag_subcode, dateformat);
            //else
            objInsert_outstand.clsInsert_outstand(compcode, userid, revenue, doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, date_time, ag_code, ag_subcode, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objInsert_outstand = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            //if (ptype == "CA0")
            //    objInsert_outstand.clsInsert_outstand(compcode, userid, Session["revenue"].ToString(), doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, date_time, ag_code, ag_subcode, dateformat);
            //else
            objInsert_outstand.clsInsert_outstand(compcode, userid, revenue, doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, date_time, ag_code, ag_subcode, dateformat);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, userid, revenue, doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, date_time, ag_code, ag_subcode, dateformat };
            string procedureName = "receiptsave2_booking_receiptsave2_booking_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objInsert_outstand = new NewAdbooking.classmysql.BookingMaster();
            //objInsert_outstand.clsInsert_outstand(compcode, userid, revenue, doctype, rcptno, date_time, ptype, Session["center"].ToString(), "", chqamt, ag_codesubcode, date_time, ag_code, ag_subcode, dateformat);
        }
    }

    [Ajax.AjaxMethod]
    public void deletefromtemp(string cioid, string compcode)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objdeletefromtemp = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            objdeletefromtemp.clsdeletefromtemp(cioid, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objdeletefromtemp = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            objdeletefromtemp.clsdeletefromtemp(cioid, compcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, cioid };
            string procedureName = "websp_deletefromtemp";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objdeletefromtemp = new NewAdbooking.classmysql.BookingMaster();
            //objdeletefromtemp.clsdeletefromtemp(cioid, compcode);
        }
    }
    [Ajax.AjaxMethod]
    public DataSet getRepresenttaive(string compcode, string executive, string retainer)
    {
        DataSet dup = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster update = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dup = update.getRepressentative(compcode, executive, retainer);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster update = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dup = update.getRepressentative(compcode, executive, retainer);

        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, executive, retainer };
            string procedureName = "getRepresenttaive";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dup = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster update = new NewAdbooking.classmysql.BookingMaster();
            //dup = update.getRepressentative(compcode, executive, retainer);
        }
        return dup;
    }
    [Ajax.AjaxMethod]
    public DataSet updatebooking(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, string billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtyp, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string val1, string val2, string val3, string val4, string val5, string val6, string val7, string auditstatus, string retainer, string txtaddagencycommrate, string dateformat, string addlamt, string retamt, string retper, string cashrecieved, string ciragency, string cirrate, string ciredition, string cirpublication, string ciragencysubcode, string bartertype, string attach1, string attach2, string cashdiscount, string cashdiscountper, string drpdiscprem, string doctype, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string dealerpanel, string dealerh, string dealerw, string dealertype, string multicode, string mobno, string agreedrate_active, string agreedamt_active, string grossamtlocal, string billamtlocal, string chkadon, string refid, string rcpt_currency, string cur_convrate, string revisedate, string clienttype, string translation, string translationcharge, string fmgreasons, string canclecharge, string transdisc, string pospremdisc, string billhold, string fixed_booking, string vat_code, string coupantype, string coupanno, string clientcatdisc, string clientcatamt, string clientcatdistype, string flatfreqdisc, string flatfreqamt, string flatfreqdisctype, string catdisc, string catamt, string catdisctype, string supplimentflag, string representative, string teamcode, string industry, string producat, string chkgstinc)
    {
        DataSet dup = new DataSet();
        if (supplimentflag == "S")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.adbooking update = new NewAdbooking.Classes.adbooking();
                dup = update.updatebooking_bill(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "0", "0", "0", "0", "0", "0", "0", auditstatus, dateformat, retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, cashdiscount, cashdiscountper, attach1, attach2, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, revisedate, clienttype, translation, translationcharge, fmgreasons, canclecharge, modifyrateaudit, ip, transdisc, pospremdisc, billhold, "", "", "N", "", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.adbooking update = new NewAdbooking.classesoracle.adbooking();
                    dup = update.updatebookingdisp_bill(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "0", "0", "0", "0", "0", "0", "0", auditstatus, dateformat, retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, attach1, attach2, cashdiscount, cashdiscountper, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, revisedate, clienttype, translation, translationcharge, fmgreasons, canclecharge, modifyrateaudit, ip, transdisc, pospremdisc, billhold, "N", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype);
                }
                else
                {
                    string[] parameterValueArray = new string[] { approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, ciobookid, date_time, branch, booked_by, prevbook, adsizetype, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billarea, billcolumn, specdiscper, spacediscper, paidins, dealrate, deviation, varient, dealtyp, contractname, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "0", "0", "0", "0", "0", "0", "0", /*auditstatus, dateformat,*/ retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, cashdiscount, cashdiscountper, attach1, attach2, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, clienttype, translation, translationcharge, fmgreasons, canclecharge, revisedate, ip, modifyrateaudit, transdisc, pospremdisc, billhold, "N", "", "", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype };
                    string procedureName = "updatebooking_suppbill";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    dup = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                    //NewAdbooking.classmysql.BookingMaster update = new NewAdbooking.classmysql.BookingMaster();
                    //dup = update.updatebookingdisp_bill(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "0", "0", "0", "0", "0", "0", "0", auditstatus, dateformat, retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, attach1, attach2, cashdiscount, cashdiscountper, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, revisedate, clienttype, translation, translationcharge, fmgreasons, canclecharge, modifyrateaudit, ip, transdisc, pospremdisc, billhold, "N", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype);
                }
        }
        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster update = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                NewAdbooking.Classes.adbooking update = new NewAdbooking.Classes.adbooking();
                dup = update.updatebooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "0", "0", "0", "0", "0", "0", "0", auditstatus, dateformat, retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, cashdiscount, cashdiscountper, attach1, attach2, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, revisedate, clienttype, translation, translationcharge, fmgreasons, canclecharge, modifyrateaudit, ip, transdisc, pospremdisc, billhold, "", "", "N", "", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype, representative, teamcode, industry, producat, chkgstinc);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    // FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster update = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                    NewAdbooking.classesoracle.adbooking update = new NewAdbooking.classesoracle.adbooking();
                    dup = update.updatebookingdisp(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "0", "0", "0", "0", "0", "0", "0", auditstatus, dateformat, retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, attach1, attach2, cashdiscount, cashdiscountper, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, revisedate, clienttype, translation, translationcharge, fmgreasons, canclecharge, modifyrateaudit, ip, transdisc, pospremdisc, billhold, "N", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype, representative, teamcode, industry, producat, chkgstinc);
                }
                else
                {
                    // string[] parameterValueArray = new string[] {approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, ciobookid, date_time, branch, booked_by, prevbook, adsizetype, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billarea, billcolumn, specdiscper, spacediscper, paidins, dealrate, deviation, varient, dealtyp, contractname, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "0", "0", "0", "0", "0", "0", "0", /*auditstatus, dateformat,*/ retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, cashdiscount, cashdiscountper, attach1, attach2, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, clienttype, translation, translationcharge, fmgreasons, canclecharge, revisedate, ip, modifyrateaudit, transdisc, pospremdisc, billhold, "N", "", "", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype, representative, teamcode, industry, producat };
                    string[] parameterValueArray = new string[] { approvedby, audit, rono, ConvertToDateTime(rodate), caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, ConvertToDateTime(startdate), repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, ciobookid, ConvertToDateTime(date_time), branch, booked_by, prevbook, adsizetype, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billarea, billcolumn, spacediscper, specdiscper, paidins, dealrate, deviation, varient, dealtyp, contractname, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "0", "0", "0", "0", "0", "0", "0", retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, cashdiscount, cashdiscountper, attach1, attach2, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, clienttype, translation, translationcharge, fmgreasons, canclecharge, revisedate, ip, modifyrateaudit, transdisc, pospremdisc, billhold, "N", "", "", "", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype, representative, teamcode, industry, producat };
                    string procedureName = "updatebooking_updatebooking_p";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    dup = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                    //NewAdbooking.classmysql.BookingMaster update = new NewAdbooking.classmysql.BookingMaster();
                    //dup = update.updatebookingdisp(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "0", "0", "0", "0", "0", "0", "0", auditstatus, dateformat, retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, attach1, attach2, cashdiscount, cashdiscountper, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, revisedate, clienttype, translation, translationcharge, fmgreasons, canclecharge, modifyrateaudit, ip, transdisc, pospremdisc, billhold, "N", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype, representative, teamcode, industry, producat);
                }
        }
        return dup;
    }
    [Ajax.AjaxMethod]
    public DataSet bindcirRate(string compcode, string center)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.bindcirRate(compcode, center);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.bindcirRate(compcode, center);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, center };
            string procedureName = "cir_get_rates_cir_get_rates_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            executequery = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            //executequery = execute.bindcirRate(compcode, center);
        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public DataSet fetchFMGrefID(string cioid)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.fetchFMGrefID(cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.fetchFMGrefID(cioid);
        }
        else
        {
            string[] parameterValueArray = new string[] { cioid };
            string procedureName = "fetchFMGrefID";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            executequery = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            //executequery = execute.fetchFMGrefID(cioid);
        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public DataSet bindciragency(string compcode, string branch, string ciragency)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.bindciragency(compcode, branch, ciragency);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.bindciragency(compcode, branch, ciragency);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, branch, ciragency };
            string procedureName = "cir_agency_bind_cir_agency_bind_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            executequery = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            //executequery = execute.bindciragency(compcode, branch, ciragency);
        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public DataSet executeBooking(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string adtype, string dateformat, string branch, string supplimentflag, string quotation, string quotation_no)
    {
        DataSet executequery = new DataSet();
        if (supplimentflag == "S")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.adbooking execute = new NewAdbooking.Classes.adbooking();
                executequery = execute.executebooking_bill(compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.adbooking execute = new NewAdbooking.classesoracle.adbooking();
                    executequery = execute.executebooking_bill(compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch);
                }
                else
                {
                    string[] parameterValueArray = new string[] { compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch };
                    string procedureName = "executebookingdisp_bill";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    executequery = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                    //NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
                    //executequery = execute.executebooking_bill(compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch);
                }
        }
        else if (quotation == "Q")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.adbooking execute = new NewAdbooking.Classes.adbooking();
                executequery = execute.executebooking(compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.adbooking execute = new NewAdbooking.classesoracle.adbooking();
                    executequery = execute.executebooking(compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch);

                }
                else
                {
                    NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
                    executequery = execute.executebookingdisp(compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch);
                }
        }
        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                executequery = execute.executebooking(compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {//san
                    string[] parameterValueArray = new string[] { compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch };
                    string procedureName = "executebookingdisp.executebookingdisp_p";
                    NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
                    executequery = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                }
                else
                {
                    /*string[] parameterValueArray = new string[] { compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch };
                    string procedureName = "executebookingdisp_executebookingdisp_p";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    executequery = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/

                    NewAdbooking.classmysql.BookingMaster update = new NewAdbooking.classmysql.BookingMaster();
                    executequery = update.executebookingdisp1(compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch);

                }
        }
        return executequery;
    }

    [Ajax.AjaxMethod]
    public DataSet bindsubagency(string agency, string compcode)
    {
        DataSet dsbsa = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindsubage = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dsbsa = bindsubage.bindsubagency(agency, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindsubage = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                dsbsa = bindsubage.bindsubagency(agency, compcode);

            }
            else
            {
                /*string[] parameterValueArray = new string[] { agency, compcode };
                string procedureName = "book_bindsubagency_book_bindsubagency_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dsbsa = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
                NewAdbooking.classmysql.BookingMaster bindsubage = new NewAdbooking.classmysql.BookingMaster();
                dsbsa = bindsubage.bindsubagency(agency, compcode);

            }
        return dsbsa;
    }

    [Ajax.AjaxMethod]
    public DataSet brandbind(string compcode, string product)
    {
        DataSet dsbrand = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster brandbind = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dsbrand = brandbind.bindBrand(compcode, product);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster brandbind = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dsbrand = brandbind.bindBrand(compcode, product);
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, product };
                string procedureName = "websp_getBrand_websp_getBrand_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dsbrand = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster brandbind = new NewAdbooking.classmysql.BookingMaster();
                //dsbrand = brandbind.bindBrand(compcode, product);
            }

        return dsbrand;
    }

    [Ajax.AjaxMethod]
    public DataSet varientbind(string compcode, string brand)
    {
        DataSet dva = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getvarient = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dva = getvarient.bindvarient(brand, compcode);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getvarient = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dva = getvarient.bindvarient(brand, compcode);
        }

        else
        {
            //string[] parameterValueArray = new string[] { brand, compcode };
            string[] parameterValueArray = new string[] { compcode, brand };
            string procedureName = "AN_BRANDVARIENT_AN_BRANDVARIENT_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dva = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster getvarient = new NewAdbooking.classmysql.BookingMaster();
            //dva = getvarient.bindvarient(brand, compcode);
        }
        return dva;
    }

    [Ajax.AjaxMethod]
    public DataSet bindpacforexe(string compcode, string listpck)
    {
        DataSet dsexecut = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dsexecut = bindpacforexe.packagebindforexebook(compcode, listpck);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dsexecut = bindpacforexe.packagebindforexebook(compcode, listpck);

            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, listpck };
                string procedureName = "getpckexebook_getpckexebook_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dsexecut = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bindpacforexe = new NewAdbooking.classmysql.BookingMaster();
                //dsexecut = bindpacforexe.packagebindforexebook(compcode, listpck);
            }
        return dsexecut;
    }

    [Ajax.AjaxMethod]
    public DataSet getPackageInsert(string uom, string cioid, string supplimentflag, string quotation)
    {
        DataSet dsinsert = new DataSet();
        if (supplimentflag == "S")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bindpacforexe = new NewAdbooking.classesoracle.adbooking();
                dsinsert = bindpacforexe.getPackageInsert_bill(uom, cioid);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.adbooking bindpacforexe = new NewAdbooking.Classes.adbooking();
                dsinsert = bindpacforexe.getPackageInsert_bill(uom, cioid);
            }


            else
            {
                string[] parameterValueArray = new string[] { uom, cioid };
                string procedureName = "getPackageInsert_suppbill";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dsinsert = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bindpacforexe = new NewAdbooking.classmysql.BookingMaster();
                //dsinsert = bindpacforexe.getPackageInsert_bill(uom, cioid);
            }
        }
        else if (quotation == "Q")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bindpacforexe = new NewAdbooking.classesoracle.adbooking();
                dsinsert = bindpacforexe.getPackageInsert(uom, cioid);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.adbooking bindpacforexe = new NewAdbooking.Classes.adbooking();
                dsinsert = bindpacforexe.getPackageInsert(uom, cioid);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                NewAdbooking.classmysql.BookingMaster bindpacforexe = new NewAdbooking.classmysql.BookingMaster();
                dsinsert = bindpacforexe.getPackageInsert(uom, cioid);
            }
        }
        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dsinsert = bindpacforexe.getPackageInsert(uom, cioid);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                dsinsert = bindpacforexe.getPackageInsert(uom, cioid);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string[] parameterValueArray = new string[] { uom, cioid };
                string procedureName = "getPackageInsert_getPackageInsert_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dsinsert = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bindpacforexe = new NewAdbooking.classmysql.BookingMaster();
                //dsinsert = bindpacforexe.getPackageInsert(uom, cioid);
            }
        }
        return dsinsert;
    }
    [Ajax.AjaxMethod]
    public DataSet getVTSRate(string pubcode, string edition, string compcode)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindrate.getVTSRate(pubcode, edition, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dx = bindrate.getVTSRate(pubcode, edition, compcode);
            }
            else
            {
                string[] parameterValueArray = new string[] { pubcode, edition, compcode };
                string procedureName = "getVTSRate";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
                //dx = bindrate.getVTSRate(pubcode, edition, compcode);
            }
        return dx;
    }
    [Ajax.AjaxMethod]
    public DataSet ratebind(string adcat, string compcode)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindrate.ratebind(adcat, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dx = bindrate.ratebind(adcat, compcode);
            }
            else
            {
                string[] parameterValueArray = new string[] { adcat, compcode };
                string procedureName = "bindratecode_bindratecode_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
                //dx = bindrate.ratebind(adcat, compcode);
            }
        return dx;
    }

    [Ajax.AjaxMethod]
    public DataSet getstatuspaymode(string agencycode, string agency, string compcode, string datetimeval, string dateformat, string adtype)
    {
        DataSet dch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getsta = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dch = getsta.getstatuspaymode(agencycode, agency, compcode, datetimeval, dateformat, adtype);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getsta = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dch = getsta.getstatuspaymode(agencycode, agency, compcode, datetimeval, dateformat, adtype);
            }
            else
            {
                //string[] parameterValueArray = new string[] { agencycode, agency, compcode, datetimeval, dateformat, adtype };
                string[] parameterValueArray = new string[] { compcode, agencycode, agency, datetimeval, adtype, dateformat };
                string procedureName = "getstatuspaymode_getstatuspaymode_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dch = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster getsta = new NewAdbooking.classmysql.BookingMaster();
                //dch = getsta.getstatuspaymode(agencycode, agency, compcode, datetimeval, dateformat, adtype);

            }
        return dch;
    }

    [Ajax.AjaxMethod]
    public DataSet getbillval(string agency, string compcode)
    {
        DataSet dbt = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getbillto = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dbt = getbillto.getbillval(agency, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getbillto = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dbt = getbillto.getbillval(agency, compcode);
            }
            else
            {
                string[] parameterValueArray = new string[] { agency, compcode };
                string procedureName = "book_bindbillto_book_bindbillto_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dbt = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster getbillto = new NewAdbooking.classmysql.BookingMaster();
                //dbt = getbillto.getbillval(agency, compcode);
            }
        return dbt;
    }
    [Ajax.AjaxMethod]
    public DataSet getvalfromadcat3(string agencysubcode, string compcode, string type)
    {
        DataSet dacat = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dacat = getadcat3.getvalfromadcat3(agencysubcode, compcode, type);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dacat = getadcat3.getvalfromadcat3(agencysubcode, compcode, type);
            }
            else
            {
                string[] parameterValueArray = new string[] { agencysubcode, compcode, type };
                string procedureName = "class_bindadcat3_class_bindadcat3_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dacat = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();
                //dacat = getadcat3.getvalfromadcat3(agencysubcode, compcode, type);
            }
        return dacat;
    }


    //Fill Grid
    [Ajax.AjaxMethod]
    public DataSet FillGrid(string pubdate, string ppub, string pbkfor, string pedition, string pspub, string dateformat)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objFillGrid = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objFillGrid.clsFillGrid(pubdate, ppub, pbkfor, pedition, pspub, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objFillGrid = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objFillGrid.clsFillGrid(pubdate, ppub, pbkfor, pedition, pspub, dateformat);
        }
        else
        {
            string[] parameterValueArray = new string[] { pubdate, ppub, pbkfor, pedition, pspub };
            string procedureName = "websp_getPageVolume";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objFillGrid = new NewAdbooking.classmysql.BookingMaster();
            //ds = objFillGrid.clsFillGrid(pubdate, ppub, pbkfor, pedition, pspub, dateformat);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet FillGridAdVolume(string pubdate, string ppub, string pbkfor, string pedition, string pspub, int i, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objFillGridAdVolume = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objFillGridAdVolume.clsFillGridAdVolume(pubdate, ppub, pbkfor, pedition, pspub, i, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objFillGridAdVolume = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objFillGridAdVolume.clsFillGridAdVolume(pubdate, ppub, pbkfor, pedition, pspub, i, dateformat);
        }
        else
        {
            string[] parameterValueArray = new string[] { pubdate, ppub, pbkfor, pedition, pspub, i.ToString() };
            string procedureName = "websp_getPlacedAdsVolume_websp_getPlacedAdsVolume_P";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objFillGridAdVolume = new NewAdbooking.classmysql.BookingMaster();
            //ds = objFillGridAdVolume.clsFillGridAdVolume(pubdate, ppub, pbkfor, pedition, pspub, i, dateformat);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet FillGridPageAds(string pubdate, string ppub, string pbkfor, string pedition, string pspub, string i, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objFillGridPageAds = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objFillGridPageAds.clsPlacedAds_Page(pubdate, ppub, pbkfor, pedition, pspub, i, dateformat);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objFillGridPageAds = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objFillGridPageAds.clsPlacedAds_Page(pubdate, ppub, pbkfor, pedition, pspub, i, dateformat);
        }
        else
        {
            string[] parameterValueArray = new string[] { pubdate, ppub, pbkfor, pedition, pspub, i, dateformat };
            string procedureName = "websp_getAdsPlacedonPage";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objFillGridPageAds = new NewAdbooking.classmysql.BookingMaster();
            //ds = objFillGridPageAds.clsPlacedAds_Page(pubdate, ppub, pbkfor, pedition, pspub, i, dateformat);
        }
        return ds;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet gettheuom_desc(string compcode, string uom)
    {
        /*
        HttpContext.Current.Session["imgname"] = null;
        HttpContext.Current.Session["Tempimgname"] = null;
        HttpContext.Current.Session["insertname"] = null;
        HttpContext.Current.Session["Tempinsertname"] = null;

        HttpContext.Current.Session["imgname_logo"] = null;
        HttpContext.Current.Session["Tempimgname_logo"] = null;
        HttpContext.Current.Session["insertname_logo"] = null;
        HttpContext.Current.Session["Tempinsertname_logo"] = null;*/
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.RateMaster binduom = new FourCPlus.AdBooking.BookingMaster.Sql.RateMaster();
            ds = binduom.getuom_desc(compcode, uom);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster binduom = new FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster();
                ds = binduom.getuom_desc(compcode, uom);

            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, uom };
                string procedureName = "getuomdesc_getuomdesc_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.RateMaster binduom = new NewAdbooking.classmysql.RateMaster();
                //ds = binduom.getuom_desc(compcode, uom);
            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet get_validdates(string dateformat, string book_date, string pkgname, string adcat, string center, string pkgid, string pkgalias)
    {
        DataSet dvaid = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkpublishday = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dvaid = chkpublishday.getvaliddate_qbc_New(dateformat, book_date, pkgname, adcat, center, "CL0", pkgid, pkgalias);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkpublishday = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dvaid = chkpublishday.getvaliddate_qbc_New(dateformat, book_date, pkgname, adcat, center, "CL0", pkgid, pkgalias);
            }
            else
            {
                //string[] parameterValueArray = new string[] { dateformat, book_date, pkgname, adcat, center, "CL0", pkgid, pkgalias };
                //string procedureName = "get_validdate_qbc_get_validdate_qbc_P";
                //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                //dvaid = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                NewAdbooking.classmysql.BookingMaster chkpublishday = new NewAdbooking.classmysql.BookingMaster();
                dvaid = chkpublishday.getvaliddate_qbc_New(dateformat, book_date, pkgname, adcat, center, "CL0", pkgid, pkgalias);
            }
        return dvaid;
    }

    //cancel booked ad
    [Ajax.AjaxMethod]
    public void deleteBooking(string cioid)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster cls_book = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            cls_book.deleteBooking(cioid);
            // cls_book.deleteBooking(cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster cls_book = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            cls_book.deleteBooking(cioid);
        }
        else
        {
            string[] parameterValueArray = new string[] { cioid };
            string procedureName = "deleteBooking_deleteBooking_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster cls_book = new NewAdbooking.classmysql.BookingMaster();
            //cls_book.deleteBooking(cioid);
        }
    }

    [Ajax.AjaxMethod]
    public DataSet ChequeInfo(string compcode, string receipt)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster cls_book = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = cls_book.clsChequeInfo(compcode, receipt);
            // cls_book.deleteBooking(cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objChequeInfo = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objChequeInfo.clsChequeInfo(compcode, receipt);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, receipt };
            string procedureName = "websp_ChequeInfo_websp_ChequeInfo_P";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster objChequeInfo = new NewAdbooking.classmysql.BookingMaster();
            //ds = objChequeInfo.clsChequeInfo(compcode, receipt);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public string checkCIOIDReference(string compcode, string cioid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster cls_booking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = cls_booking.checkCIOIDReference(compcode, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster cls_booking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = cls_booking.checkCIOIDReference(compcode, cioid);
        }
        else
        {
            /*string[] parameterValueArray = new string[] { compcode, cioid };
            string procedureName = "checkCioidRef";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
            NewAdbooking.classmysql.BookingMaster cls_booking = new NewAdbooking.classmysql.BookingMaster();
            ds = cls_booking.checkCIOIDReference(compcode, cioid);
        }
        string cio_ID = cioid;
        if (ds.Tables[0].Rows.Count > 0)
        {
            cio_ID = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return cio_ID;
    }
    [Ajax.AjaxMethod]
    public DataSet bindpageprem_J(string compcode, string adtype)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.RateMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.RateMaster();
            dx = bindrate.premiumbind(compcode, adtype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster();
            dx = bindrate.premiumbind(compcode, adtype);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, adtype };
            string procedureName = "bindpremiumforrate_bindpremiumforrate_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.RateMaster bindrate = new NewAdbooking.classmysql.RateMaster();
            //dx = bindrate.premiumbind(compcode, adtype);
        }
        return dx;
    }
    [Ajax.AjaxMethod]
    public string getPkgEdition(string compcode, string combincode)
    {
        string edition = "1";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster cls_book = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            DataSet ds = new DataSet();
            ds = cls_book.getPkgEdition_P(compcode, combincode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0].ItemArray[0] != null)
                {
                    edition = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                }
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster cls_book = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            DataSet ds = new DataSet();
            ds = cls_book.getPkgEdition_P(compcode, combincode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0].ItemArray[0] != null)
                {
                    edition = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                }
            }
        }
        else
        {
            //NewAdbooking.classmysql.RateMaster cls_book = new NewAdbooking.classmysql.RateMaster();
            DataSet ds = new DataSet();
            //ds = cls_book.getPkgEdition_P(compcode, combincode);
            /*string[] parameterValueArray = new string[] { compcode, combincode };
            string procedureName = "getPkgEdition_P";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/

            NewAdbooking.classmysql.BookingMaster cls_book = new NewAdbooking.classmysql.BookingMaster();
            ds = cls_book.getPkgEdition_P(compcode, combincode);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0].ItemArray[0] != null)
                {
                    edition = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                }
            }
        }
        return edition;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getRegClientCheck(string adcat)
    {
        string chk = "0";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = prev.getRegisterClientCheck(Session["compcode"].ToString(), adcat);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    chk = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            //}
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = prev.getRegisterClientCheck(Session["compcode"].ToString(), adcat);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    chk = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            //}
        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), adcat };
            string procedureName = "getRegisterClientCheck";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.RateMaster prev = new NewAdbooking.classmysql.RateMaster();
            //ds = prev.getRegisterClientCheck(Session["compcode"].ToString(), adcat);
        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getPrevBookId(string adtype)
    {
        DataSet dprv = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            NewAdbooking.Classes.adbooking prev = new NewAdbooking.Classes.adbooking();
            dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), adtype, hiddenquotation.Value);



        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), adtype);
                //dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), adtype, hiddenquotation.Value);


            }
            else
            {
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), adtype, hiddenquotation.Value };
                string procedureName = "gettheprevbooking_gettheprevbooking_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dprv = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster prev = new NewAdbooking.classmysql.BookingMaster();
                //dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), adtype);
            }
        return dprv;
    }
    [Ajax.AjaxMethod]
    public DataSet getBAlias(string branch, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            ds = prev.getBAlias(branch, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = prev.getBAlias(branch, compcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { branch, compcode };
            string procedureName = "getBAlias";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster prev = new NewAdbooking.classmysql.BookingMaster();
            //ds = prev.getBAlias(branch, compcode);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public string getAmount(string cioid)
    {
        DataSet ds = new DataSet();
        string amount = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            ds = prev.getAmount(cioid);
            if (ds.Tables[0].Rows.Count > 0)
                amount = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = prev.getAmount(cioid);
            if (ds.Tables[0].Rows.Count > 0)
                amount = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        else
        {
            string[] parameterValueArray = new string[] { cioid };
            string procedureName = "getCioAmount";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster prev = new NewAdbooking.classmysql.BookingMaster();
            //ds = prev.getAmount(cioid);
            if (ds.Tables[0].Rows.Count > 0)
                amount = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return amount;
    }
    [Ajax.AjaxMethod]
    public DataSet getHeightWidth(string adcat, string color, string edition, string compcode, string code, string uom, string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            ds = prev.getAdSizeHeightWidth(adtype, adcat, color, edition, compcode, code, uom);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = prev.getAdSizeHeightWidth(adtype, adcat, color, edition, compcode, code, uom);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string[] parameterValueArray = new string[] { adtype, adcat, color, edition, compcode, code, uom };
            string procedureName = "getAdSizeHeightWidth";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster prev = new NewAdbooking.classmysql.BookingMaster();
            //ds = prev.getAdSizeHeightWidth(adtype, adcat, color, edition, compcode, code, uom);
        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public string getRev()
    {
        return Session["revenue"].ToString();
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public string getCen()
    {
        return Session["center"].ToString();
    }
    [Ajax.AjaxMethod]
    public Boolean chkCodeMain(string name, string code, string company)
    {
        DataSet ds = new DataSet();
        bool fag = false;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            ds = prev.getmaincode(name, code, company);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fag = true;
            }
            else
            {
                fag = false;
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = prev.getmaincode(name, code, company);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fag = true;
            }
            else
            {
                fag = false;
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string[] parameterValueArray = new string[] { name, code, company };
            string procedureName = "getmaincodeChk";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            NewAdbooking.classmysql.BookingMaster prev = new NewAdbooking.classmysql.BookingMaster();
            ds = prev.getmaincode(name, code, company);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fag = true;
            }
            else
            {
                fag = false;
            }
        }
        return fag;
    }
    [Ajax.AjaxMethod]
    public DataSet getcirAgency(string compcode, string branch, string ciragency, string ciragencysubcode)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.getciragency(compcode, branch, ciragency, ciragencysubcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.getciragency(compcode, branch, ciragency, ciragencysubcode);

        }
        else
        {
            string[] parameterValueArray = { compcode, branch, ciragency, ciragencysubcode };
            string procedureName = "cir_get_name_cir_agname_branch";
            NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
            executequery = obj.BindCommanFunction(procedureName, parameterValueArray);
            /*NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            executequery = execute.getciragency(compcode, branch, ciragency, ciragencysubcode);*/
        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public DataSet getcirEdition(string compcode, string editioncode)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.getciredition(compcode, editioncode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.getciredition(compcode, editioncode);
        }
        else
        {
            string[] parameterValueArray = { compcode, editioncode };
            string procedureName = "cir_get_name_cir_edtn";
            NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
            executequery = obj.BindCommanFunction(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            //executequery = execute.getciredition(compcode, editioncode);
        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public DataSet getBarter(string compcode, string center, string branch, string agency, string client)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.getBarter(compcode, center, branch, agency, client);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.getBarter(compcode, center, branch, agency, client);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string[] parameterValueArray = new string[] { compcode, center, branch, agency, client };
            string procedureName = "getBarter";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            executequery = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            //executequery = execute.getBarter(compcode, center, branch, agency, client);

        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public DataSet getCurTime(string compcode)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.getCurTime(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.getCurTime(compcode);
        }
        else
        {
            /*string[] parameterValueArray = new string[] { compcode };
            string procedureName = "GETCURTIME";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            executequery = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
            NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            executequery = execute.getCurTime(compcode);
        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public DataSet getBarterBookingAmt(string bartertype, string cioid, string compcode)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.getBarterBookingAmt(bartertype, cioid, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.getBarterBookingAmt(bartertype, cioid, compcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { bartertype, cioid, compcode };
            string procedureName = "getBarterBookingAmt";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            executequery = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            //executequery = execute.getBarterBookingAmt(bartertype, cioid, compcode);
        }
        return executequery;
    }
    /////////////////////////bhanu
    [Ajax.AjaxMethod]
    public DataSet getPubSharing(string packagecode, string compcode, string cioid)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.getPubSharing(packagecode, compcode, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.getPubSharing(packagecode, compcode, cioid);

        }
        else
        {
            string[] parameterValueArray = new string[] { packagecode, compcode, cioid };
            string procedureName = "getPubBooking";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            executequery = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            //executequery = execute.getPubSharing(packagecode, compcode, cioid);
        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public DataSet getpubcount(string compcode, string noofinsert, string packagecode, string cioid)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.getpubcount(compcode, noofinsert, packagecode, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.getpubcount(compcode, noofinsert, packagecode, cioid);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, noofinsert, packagecode, cioid };
            string procedureName = "getpubcount";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            executequery = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            //executequery = execute.getpubcount(compcode, noofinsert, packagecode, cioid);
        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public string backdate_validate(string pcompcode, string pformname, string puserid, string pentrydate, string pdateformat, string pextra1, string pextra2)
    {
        DataSet ds = new DataSet();
        string output = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = execute.backdate_validate(pcompcode, pformname, puserid, pentrydate, pdateformat, pextra1, pextra2);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                ds = execute.backdate_validate(pcompcode, pformname, puserid, pentrydate, pdateformat, pextra1, pextra2);
            }
            else
            {
                string procedureName = "ad_get_backdays_validate";
                string[] parameterValueArray = { pcompcode, pformname, puserid, pentrydate, pdateformat, pextra1, pextra2 };
                NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
                ds = obj.BindCommanFunction(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
                //ds = execute.backdate_validate(pcompcode, pformname, puserid, pentrydate, pdateformat, pextra1, pextra2);
            }

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            output = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return output;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void savelogin_dj(string cioid)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl" && ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            execute.SAVELOGIN_DJ(cioid, Session["PUBLICATIONDJ"].ToString(), Session["CENTERDJ"].ToString(), Session["revenue"].ToString(), Session["LOGINDJ"].ToString());
        }
        else
        {
            string[] parameterValueArray = new string[] { cioid, Session["PUBLICATIONDJ"].ToString(), Session["CENTERDJ"].ToString(), Session["revenue"].ToString(), Session["LOGINDJ"].ToString() };
            string procedureName = "SAVELOGIN_DJ";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            //execute.SAVELOGIN_DJ(cioid, Session["PUBLICATIONDJ"].ToString(), Session["CENTERDJ"].ToString(), Session["revenue"].ToString(), Session["LOGINDJ"].ToString());
        }

    }
    [Ajax.AjaxMethod]
    public DataSet getPackageConsumption(string pkgcode_p, string pfdate, string pldate, string dateformat)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.getPackageConsumption(pkgcode_p, pfdate, pldate, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.getPackageConsumption(pkgcode_p, pfdate, pldate, dateformat);
        }
        else
        {
            string[] parameterValueArray = new string[] { pkgcode_p, pfdate, pldate };
            string procedureName = "getPackageConsumption";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            executequery = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            //executequery = execute.getPackageConsumption(pkgcode_p, pfdate, pldate, dateformat);
        }
        return executequery;
    }
    /////////////////////////////////
    /////////////bhanu start
    [Ajax.AjaxMethod]
    public DataSet chkcasualclient(string client, string compcode)
    {
        DataSet dcl = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkclient = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dcl = chkclient.forwalkclient(client, compcode);
            return dcl;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkclient = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                dcl = chkclient.forwalkclient(client, compcode);
                return dcl;
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, client };
                string procedureName = "chkforwalkinnclient_chkforwalkinnclient_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dcl = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster chkclient = new NewAdbooking.classmysql.BookingMaster();

                //dcl = chkclient.forwalkclient(client, compcode);
                return dcl;
            }

    }
    /////////////bhanu end
    /////////////bhanu6june
    [Ajax.AjaxMethod]
    public DataSet fetchmultiexe(string cioid, string compcode)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.fetchmultiexe(cioid, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.fetchmultiexe(cioid, compcode);

        }
        else
        {
            string[] parameterValueArray = new string[] { cioid, compcode };
            string procedureName = "fetchmultiexe";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            executequery = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            //executequery = execute.fetchmultiexe(cioid, compcode);
        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public DataSet book_chkpublishday_n(string compcode, string pkgname, string dateday, string date_for1)
    {
        DataSet dpub = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkpublishday = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dpub = chkpublishday.book_chkpublishday_n(compcode, pkgname, dateday, date_for1);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkpublishday = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dpub = chkpublishday.book_chkpublishday_n(compcode, pkgname, dateday, date_for1);

            }
            else
            {
                /*    string[] parameterValueArray = new string[] { compcode, pkgname, dateday };
                    string procedureName = "getperiodDate_Edition";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    dpub = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
                NewAdbooking.classmysql.BookingMaster chkpublishday = new NewAdbooking.classmysql.BookingMaster();
                dpub = chkpublishday.book_chkpublishday_n(compcode, pkgname, dateday, date_for1);

            }
        return dpub;

    }
    [Ajax.AjaxMethod]
    public DataSet getuomflagvalue(string compcode, string uom_code)
    {
        DataSet dpub = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkuomflag = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dpub = chkuomflag.chkuomfval(compcode, uom_code);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkuomflag = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dpub = chkuomflag.chkuomfval(compcode, uom_code);

            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, uom_code };
                string procedureName = "ad_getuomfvalue";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dpub = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster chkuomflag = new NewAdbooking.classmysql.BookingMaster();
                //dpub = chkuomflag.chkuomfval(compcode, uom_code);

            }
        return dpub;

    }
    [Ajax.AjaxMethod]
    public DataSet bindpackage_Main(string compcode, string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();
            ds = bindopackage.packagebind(compcode, adtype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();
            ds = bindopackage.packagebindActive(compcode, adtype);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, adtype, "", "" };
            string procedureName = "bindpackageActive_bindpackageActive_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.Contract bindopackage = new NewAdbooking.classmysql.Contract();
            //ds = bindopackage.packagebind(compcode, adtype);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet fetchpwd(string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bindopackage.fetchPassword(compcode, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = bindopackage.fetchPassword(compcode, userid);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, userid };
            string procedureName = "fetchPassword";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindopackage = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindopackage.fetchPassword(compcode, userid);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getSectionCode(string name_p)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bindopackage.getSectionCode(name_p);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = bindopackage.getSectionCode(name_p);
        }
        else
        {
            string[] parameterValueArray = new string[] { name_p };
            string procedureName = "getSectionCode";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindopackage = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindopackage.getSectionCode(name_p);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getResourceNo(string name_p)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bindopackage.getResourceNo(name_p);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = bindopackage.getResourceNo(name_p);
        }
        else
        {
            string[] parameterValueArray = new string[] { name_p };
            string procedureName = "getResourceNo";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindopackage = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindopackage.getResourceNo(name_p);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getpermission(string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bindopackage.fetchpermisiondata(compcode, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = bindopackage.fetchpermisiondata(compcode, userid);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, userid, "", "" };
            string procedureName = "ADB_FETCHPERMISSION";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindopackage = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindopackage.fetchpermisiondata(compcode, userid);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet chkagencyforraterevise(string compcode, string agcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bindopackage.chkagencyforrevise(compcode, agcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = bindopackage.chkagencyforrevise(compcode, agcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, agcode, "", "" };
            string procedureName = "ADB_CHKAG_RATEREVISE";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindopackage = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindopackage.chkagencyforrevise(compcode, agcode);
        }
        return ds;
    }
    //==========================================  Generate temp Booking Id at time of New ===========================//
    [Ajax.AjaxMethod]
    public DataSet gettempBookingIdNo(string compcode)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            da = autocode.autogenratedtempid(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            da = autocode.autogenratedtempid(compcode);
        }
        else
        {
            /*string[] parameterValueArray = new string[] { compcode, "0", "0" };
            string procedureName = "GETAUTOCODEBOOKING_PRE_SAVE_GETAUTOCODEBOOKING_PRE_SAVE_P";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            da = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
            NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();
            da = autocode.autogenratedtempid(compcode, "0", "0");
        }
        return da;
    }
    [Ajax.AjaxMethod]
    public DataSet bindratecodeforreviserate(string adcat, string compcode, string revisedate)
    {
        //NewAdbooking.Classes.pop bindrate = new NewAdbooking.Classes.pop();
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindrate.ratebindforreviserate(adcat, compcode, revisedate);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dx = bindrate.ratebindforreviserate(adcat, compcode, revisedate);
        }
        else
        {
            string[] parameterValueArray = new string[] { adcat, compcode, revisedate };
            string procedureName = "bindratecodeforrevisedate";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
            //dx = bindrate.ratebindforreviserate(adcat, compcode, revisedate);
        }
        return dx;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindagencynamefromadd(string compcode, string userid, string agency, string agencyaddress)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bindagenname.bindagencyfromadd(compcode, userid, agency, Session["revenue"].ToString(), agencyaddress);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = bindagenname.bindagencyfromadd(compcode, userid, agency, Session["revenue"].ToString(), agencyaddress);

        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, userid, agency, Session["revenue"].ToString(), agencyaddress };
            string procedureName = "bindagencyfromadd";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindagenname = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindagenname.bindagencyfromadd(compcode, userid, agency, Session["revenue"].ToString(), agencyaddress);
        }
        return ds;



    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getagencyRemark(string compcode, string bookingid, string agency, string client, string type1)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bindagenname.bindgencyRemark(compcode, bookingid, agency, client, type1);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = bindagenname.bindgencyRemark(compcode, bookingid, agency, client, type1);

        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, bookingid, agency, client, type1, type1 };
            string procedureName = "ADB_GETAGENCY_ADD";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindagenname = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindagenname.bindgencyRemark(compcode, bookingid, agency, client, type1);
        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getbillnobilldate(string bookingid, string insertno)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bindagenname.getbillnobilldate1(bookingid, insertno, Session["compcode"].ToString(), Session["dateformat"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = bindagenname.getbillnobilldate1(bookingid, insertno, Session["compcode"].ToString(), Session["dateformat"].ToString());

        }
        else
        {
            string[] parameterValueArray = new string[] { bookingid, insertno, Session["compcode"].ToString(), Session["dateformat"].ToString(), "", "", "" };
            string procedureName = "ADB_GETBILLNOBILLDAET";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindagenname = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindagenname.getbillnobilldate1(bookingid, insertno, Session["compcode"].ToString(), Session["dateformat"].ToString());
        }
        return ds;
    }
    public void bindtranslation()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bind = new NewAdbooking.Classes.adbooking();

            ds = bind.bindtranslation(Session["compcode"].ToString(), hiddenadtype.Value);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bind = new NewAdbooking.classesoracle.adbooking();

                ds = bind.bindtranslation(Session["compcode"].ToString(), hiddenadtype.Value);
            }
            else
            {
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), hiddenadtype.Value };
                string procedureName = "bindtranslation";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
                //ds = bind.bindtranslation(Session["compcode"].ToString(), hiddenadtype.Value);
            }



        int i;
        ListItem li1;
        li1 = new ListItem();
        drptranslation.Items.Clear();
        li1.Text = "Select";
        li1.Value = "0";
        li1.Selected = true;
        drptranslation.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drptranslation.Items.Add(li);

            }
        }

    }
    //////bhanu// st
    [Ajax.AjaxMethod]
    public DataSet gettraprem(string compcode, string translation)
    {        ///////if it is 0 than bind the drp down for bg col,or aND IF 1 THAN FOR BULLET DROP DOWN or if not 0 or 1 than get the selected bullet premium into its text field  

        DataSet dsch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindbgcolor = new NewAdbooking.Classes.adbooking();
            dsch = bindbgcolor.gettraprem(compcode, translation);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bindbgcolor = new NewAdbooking.classesoracle.adbooking();
                dsch = bindbgcolor.gettraprem(compcode, translation);
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, translation };
                string procedureName = "gettranslationper";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dsch = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
                //dsch = bindbgcolor.gettraprem(compcode, translation);
            }
        return dsch;
    }
    ///bhnau end
    ///bhanu 5/3/2012

    [Ajax.AjaxMethod]
    public DataSet showgridforexe1(string ciobid, string compcode, string quotation)
    {
        DataSet dex = new DataSet();
        if (quotation == "Q")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.adbooking showgri = new NewAdbooking.Classes.adbooking();
                dex = showgri.fetchdataforexe1(ciobid, compcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking showgri = new NewAdbooking.classesoracle.adbooking();
                dex = showgri.fetchdataforexe1(ciobid, compcode);
            }
            else
            {
                string[] parameterValueArray = new string[] { ciobid, compcode };
                string procedureName = "getdataforexecute1_getdataforexecute1_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dex = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();
                //dex = showgri.fetchdataforexe1(ciobid, compcode);
            }
        }
        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.adbooking showgri = new NewAdbooking.Classes.adbooking();
                dex = showgri.fetchdataforexe1(ciobid, compcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking showgri = new NewAdbooking.classesoracle.adbooking();
                dex = showgri.fetchdataforexe1(ciobid, compcode);
            }
            else
            {
                string[] parameterValueArray = new string[] { ciobid, compcode };
                string procedureName = "getdataforexecute1_getdataforexecute1_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dex = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();
                //dex = showgri.fetchdataforexe1(ciobid, compcode);
            }
        }
        return dex;

    }
    ///bhanu end
    //===============******** This is to Bind Caption Master **********=============//
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindcapnam(string compcode, string userid, string caption)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bindagenname.bindcaptionname(compcode, userid, caption);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = bindagenname.bindcaptionname(compcode, userid, caption);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, userid, caption, "" };
            string procedureName = "AD_BINDCAPTION";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindagenname = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindagenname.bindcaptionname(compcode, userid, caption);
        }

        return ds;

    }
    [Ajax.AjaxMethod]
    public void btnSavecall(string compcod, string userid, string dealno, string quotation)
    {
        if (quotation == "Q")
        {
            DataSet ds1 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.adbooking bind = new NewAdbooking.Classes.adbooking();
                ds1 = bind.getmailheader(compcod, userid, dealno);

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bindrate = new NewAdbooking.classesoracle.adbooking();
                ds1 = bindrate.getmailheader(compcod, userid, dealno);
            }
            else
            {
                string[] parameterValueArray = new string[] { compcod, userid, dealno };
                string procedureName = "mailrateheaderforbooking";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ds1 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
                //ds1 = bindrate.getmailheader(compcod, userid, dealno);
            }

            DataSet ds2 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.adbooking bind = new NewAdbooking.Classes.adbooking();
                ds2 = bind.getmaildetail(compcod, userid, dealno);

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bindrate = new NewAdbooking.classesoracle.adbooking();
                ds2 = bindrate.getmaildetail(compcod, userid, dealno);
            }
            else
            {
                string[] parameterValueArray = new string[] { compcod, userid, dealno };
                string procedureName = "mailbooking";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ds2 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
                //ds2 = bindrate.getmaildetail(compcod, userid, dealno);
            }

            DataSet objdat1 = new DataSet();
            // Read in the XML file
            string datapath = (Server.MapPath("XML/dealmailbody.xml")).Replace("ajax\\", "");
            //  datapath.Replace("ajax\\","");
            objdat1.ReadXml(datapath);


            string mailbody = "<table width='100%' cellspacing='0' cellpadding='0' border='1'>";
            mailbody = mailbody + "<tr><td width=\"28%\" align='left' style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[0].ToString() + "</b></td>";
            mailbody = mailbody + "<td align='left' colspan='3'style='font-family:verdana;font-size:12'>" + chkvalue(Convert.ToDateTime(ds1.Tables[0].Rows[0].ItemArray[0].ToString()).ToShortDateString()) + "</td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\" align='left' style='font-family:verdana;font-size:14'><label id=\"lblclntnam\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[1].ToString() + "</b></label></td><td align=\"left\" colspan=\"3\">";
            mailbody = mailbody + "<label id=\"lblclntnam1\" style='font-family:verdana;font-size:12'\" >" + chkvalue(ds1.Tables[0].Rows[0].ItemArray[1].ToString()) + "</label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\" align='left' style='font-family:verdana;font-size:12'><label id=\"lblcompnam\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[2].ToString() + "</b></label></td><td align=\"left\"  colspan=\"3\">";
            mailbody = mailbody + "<label id=\"lblcompnam1\" style='font-family:verdana;font-size:12'>" + chkvalue(ds1.Tables[0].Rows[0].ItemArray[2].ToString()) + "</label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\" align='left' style='font-family:verdana;font-size:12'><label id=\"lblsub\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[3].ToString() + "</b></label></td><td align=\"left\" colspan=\"3\">";
            mailbody = mailbody + "<label id=\"lblsub1\" style='font-family:verdana;font-size:12'>" + chkvalue(ds1.Tables[0].Rows[0].ItemArray[3].ToString()) + "</label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\" align='left' style='font-family:verdana;font-size:12'><b>" + objdat1.Tables[0].Rows[0].ItemArray[4].ToString() + "</b></td>";
            mailbody = mailbody + "<td style='font-family:verdana;font-size:14'>" + objdat1.Tables[0].Rows[0].ItemArray[5].ToString() + "<label id=\"lbltel\" style='font-family:verdana;font-size:12'>" + chkvalue(ds1.Tables[0].Rows[0].ItemArray[4].ToString()) + "</label></td>";
            mailbody = mailbody + "<td style='font-family:verdana;font-size:14'>" + objdat1.Tables[0].Rows[0].ItemArray[6].ToString() + "<label id=\"lblfax\" style='font-family:verdana;font-size:12'>" + chkvalue(ds1.Tables[0].Rows[0].ItemArray[5].ToString()) + "</label></td>";
            mailbody = mailbody + "<td style=\" font-size:'14px';\">Cell:<label id=\"lblfax1\" style='font-family:verdana;font-size:12'>018414084:</label></td>";
            mailbody = mailbody + "</tr><tr><td><label id=\"lblsub\" style=\" font-size:'12px';\"></label></td><td align=\"left\" colspan=\"3\" style='font-family:verdana;font-size:14'>";
            mailbody = mailbody + objdat1.Tables[0].Rows[0].ItemArray[7].ToString() + ":<label id=\"lblmail1\" style=\" font-size:'12px';\">" + chkvalue(ds1.Tables[0].Rows[0].ItemArray[6].ToString()) + "</label></td>";
            mailbody = mailbody + "</tr></table><u><label id=\"lblquote\" style='font-family:verdana;font-size:12'><b>" + objdat1.Tables[0].Rows[0].ItemArray[8].ToString() + "</b></label></u></br>";
            mailbody = mailbody + "<label id=\"lblquote1\" style='font-family:verdana;font-size:12'><b>" + objdat1.Tables[0].Rows[0].ItemArray[9].ToString() + "</b></label>";
            mailbody = mailbody + "<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"1\">";
            mailbody = mailbody + "<tr><td><label id=\"lblcolor\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[10].ToString() + "</label></td>";
            mailbody = mailbody + "<td><label id=\"lblprice\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[11].ToString() + "</b></label></td>";
            mailbody = mailbody + "<td><label id=\"lblpub\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[12].ToString() + "</b></label></td>";
            mailbody = mailbody + "<td><label id=\"lblpubdat\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[13].ToString() + "</b></label></td>";
            mailbody = mailbody + "<td><label id=\"lbltotal\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[24].ToString() + "</b></label></td></tr>";

            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {

                    mailbody = mailbody + "<tr><td><label id=\"lblinserts\" style='font-family:verdana;font-size:12'>" + chkvalue(ds2.Tables[0].Rows[i].ItemArray[0].ToString()) + "</label></td>";
                    mailbody = mailbody + "<td><label id=\"lblfulcol\" style='font-family:verdana;font-size:12'>" + chkvalue(ds2.Tables[0].Rows[i].ItemArray[1].ToString()) + "</label></td>";
                    mailbody = mailbody + "<td><label id=\"lblpub1\" style='font-family:verdana;font-size:12'>" + chkvalue(ds2.Tables[0].Rows[i].ItemArray[3].ToString()) + "</label></td>";
                    mailbody = mailbody + "<td><label id=\"lblpubdat1\" style='font-family:verdana;font-size:12'>" + chkvalue(ds2.Tables[0].Rows[i].ItemArray[4].ToString()) + "</label></td>";
                    mailbody = mailbody + "<td><label id=\"lbltotal1\" style='font-family:verdana;font-size:12'>" + chkvalue(ds2.Tables[0].Rows[i].ItemArray[5].ToString()) + "</label></td>";
                }
            }

            mailbody = mailbody + "</tr><tr><td><label id=\"lblinserts2\" style='font-family:verdana;font-size:12'>A3 Windhoek only</label></td>";
            mailbody = mailbody + "<td><label id=\"lblfulcol2\" style='font-family:verdana;font-size:12'>&nbsp;</label></td>";
            mailbody = mailbody + "<td><label id=\"lblpub2\" style=\" font-size:'12px';\">&nbsp;</label></td>";
            mailbody = mailbody + "<td><label id=\"lblpubdat2\" style='font-family:verdana;font-size:12'>Tuesday</label></td>";
            mailbody = mailbody + "<td><label id=\"lbltotal2\" style=\" font-size:'12px';\"></label>&nbsp;</td>";
            mailbody = mailbody + "</tr><tr><td colspan=\"5\"><label id=\"lblbop\" style='font-family:verdana;font-size:12'><b>" + objdat1.Tables[0].Rows[0].ItemArray[14].ToString() + "</b></label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\"><label id=\"lblsig\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[15].ToString() + "</b></label></td>";
            mailbody = mailbody + "<td colspan=\"3\"><label id=\"lblsig2\" style=\" font-size:'12px';\">&nbsp;</label></td>";
            mailbody = mailbody + "</tr></table>";
            mailbody = mailbody + "<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" >";
            mailbody = mailbody + "<tr><td>&nbsp;</td></tr>";
            mailbody = mailbody + "<tr><td><label id=\"lblthank\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[16].ToString() + "</b></label></td>";
            mailbody = mailbody + "</tr><tr><td>&nbsp;</td></tr>";
            mailbody = mailbody + "<tr><td>__________________________</td></tr>";
            mailbody = mailbody + "<tr><td height=\"50px\"><label id=\"lbladd1\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[17].ToString() + "</b></label></td></tr>";
            mailbody = mailbody + "</table>";
            mailbody = mailbody + "<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"1\">";
            mailbody = mailbody + "<tr><td colspan=\"2\" ><label id=\"lbldet\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[18].ToString() + "</b></label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\"><label id=\"lblacnt\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[19].ToString() + "</b></label></td><td>";
            mailbody = mailbody + "<label id=\"lblacnt1\" style='font-family:verdana;font-size:12'>" + objdat1.Tables[0].Rows[0].ItemArray[26].ToString() + "</label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\"><label id=\"lblbank\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[20].ToString() + "</b></label></td><td>";
            mailbody = mailbody + "<label id=\"lblbank1\" style='font-family:verdana;font-size:12'>" + objdat1.Tables[0].Rows[0].ItemArray[27].ToString() + "</label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\"><label id=\"lblacntno\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[21].ToString() + "</b></label></td><td>";
            mailbody = mailbody + "<label id=\"lblacntno1\" style='font-family:verdana;font-size:12'>" + objdat1.Tables[0].Rows[0].ItemArray[28].ToString() + "</label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\"><label id=\"lblbranch\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[22].ToString() + "</b></label></td><td>";
            mailbody = mailbody + "<label id=\"lblbranch1\" style='font-family:verdana;font-size:12'>" + objdat1.Tables[0].Rows[0].ItemArray[29].ToString() + "</label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\"><label id=\"lblactyp\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[23].ToString() + "</b></label></td><td>";
            mailbody = mailbody + "<label id=\"lblactyp1\" style='font-family:verdana;font-size:12'>" + objdat1.Tables[0].Rows[0].ItemArray[30].ToString() + "</label></td>";
            mailbody = mailbody + "</tr></table>";
            string mailtoval = "";
            if (ds1.Tables[0].Rows[0]["EmailID"].ToString() == "" || ds1.Tables[0].Rows[0]["EmailID"].ToString() == null)
                mailtoval = "jens@dmh.com.na";
            else
                mailtoval = ds1.Tables[0].Rows[0]["EmailID"].ToString();
            string smtpadd = objdat1.Tables[0].Rows[0].ItemArray[32].ToString();
            string mailfromval = objdat1.Tables[0].Rows[0].ItemArray[31].ToString();
            objdat1.Tables[0].Rows[0].ItemArray[30].ToString();
            //MailMessage objMailMessage = new MailMessage();
            //objMailMessage = new MailMessage();
            //objMailMessage.To.Add(mailtoval);
            //objMailMessage.Subject = "Regarding Request";
            //objMailMessage.From = new MailAddress(mailfromval);// http://"+ipaddres+"/tverp/tv_car_approval.aspx?uid=" + uid + "&pstdate=" + stdate + "&sttme=" + sttme + " ";
            ////objMailMessage.IsBodyHtml = true;
            //string str = "";
            //str = "Hi, This is a request";

            ////objMailMessage.Body = "Hi, This is a request for mail.   <a href=" + url + ">http://" + ipaddres + "/tverp/tv_car_approval.aspx?uid=" + uid + "&pstdate=" + refid + "&mailto=" + mailto_indv + " </a> ";//&sttme=" + sttme + "
            ////192.168.5.148
            //objMailMessage.IsBodyHtml = true;
            //objMailMessage.Body = mailbody;
            //SmtpClient smtp = new SmtpClient(smtpadd);//192.168.1.99 // "202.63.107.91"
            //smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
            //smtp.Send(objMailMessage);
            /*MailMessage msgMail = new MailMessage();
            msgMail.To = mailtoval;
            msgMail.From = mailfromval;
            msgMail.BodyFormat = MailFormat.Html;
            msgMail.Subject = "Regarding Request";
            msgMail.Body = mailbody;
            SmtpMail.SmtpServer = smtpadd;
            SmtpMail.Send(msgMail);*/

        }
    }
    public string chkvalue(string val)
    {
        if (val == null || val == "")
            return "&nbsp;";
        else
            return val;
    }









    [Ajax.AjaxMethod]
    public DataSet bindtootipsubcat(string code, string compcode)
    {
        DataSet dex = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking showgri = new NewAdbooking.Classes.adbooking();
            dex = showgri.fetbindtootipsubcat1(code, compcode);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking showgri = new NewAdbooking.classesoracle.adbooking();
            dex = showgri.fetbindtootipsubcat1(code, compcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { code, compcode };
            string procedureName = "tooltipsubCategory";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dex = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();
            //dex = showgri.fetbindtootipsubcat1(code, compcode);
        }

        return dex;

    }
    [Ajax.AjaxMethod]
    public string getCenterCode(string edition)
    {
        string centercode = "";

        DataSet ds2 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bind = new NewAdbooking.Classes.adbooking();
            ds2 = bind.getCenterCode(edition);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindrate = new NewAdbooking.classesoracle.adbooking();
            ds2 = bindrate.getCenterCode(edition);
        }
        else
        {
            string[] parameterValueArray = new string[] { edition };
            string procedureName = "getCenterCode";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds2 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();
            //ds2 = showgri.getCenterCode(edition);
        }
        if (ds2.Tables[0].Rows.Count > 0)
        {
            centercode = ds2.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return centercode;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet executivecraditlimit(string compcode, string userid, string execname, string ciobookid, string grossamt, string billamt, string paymode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindagenname = new NewAdbooking.Classes.adbooking();
            ds = bindagenname.executivecraditlimit(compcode, userid, execname, ciobookid, grossamt, billamt, paymode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindagenname = new NewAdbooking.classesoracle.adbooking();
            ds = bindagenname.executivecraditlimit(compcode, userid, execname, ciobookid, grossamt, billamt, paymode);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, userid, execname, ciobookid, grossamt, billamt, paymode };
            string procedureName = "chkexecutivecreditlimit";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindagenname = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindagenname.executivecraditlimit(compcode, userid, execname, ciobookid, grossamt, billamt, paymode);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet billupdatedata(string compcode, string ciobookid, string supplementbilldate, string supplementbillno, string userid, string dateformat, string flag)
    {
        DataSet dsch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindbgcolor = new NewAdbooking.Classes.adbooking();
            dsch = bindbgcolor.billupdatedata(compcode, ciobookid, supplementbilldate, supplementbillno, userid, dateformat, flag);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bindbgcolor = new NewAdbooking.classesoracle.adbooking();
                dsch = bindbgcolor.billupdatedata(compcode, ciobookid, supplementbilldate, supplementbillno, userid, dateformat, flag);
            }
            else
            {
                string procedureName = "";
                string[] parameterValueArray = new string[] { compcode, ciobookid, supplementbilldate, supplementbillno, userid, dateformat };
                if (flag == "1")
                {
                    procedureName = "billdet_for_bill_update_data";
                }
                else
                {
                    procedureName = "bill_update_data";
                }
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dsch = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bindbgcolor = new NewAdbooking.classmysql.BookingMaster();//classfile
                //dsch = bindbgcolor.billupdatedata(compcode, ciobookid, supplementbilldate, supplementbillno, userid, dateformat, flag);
            }
        return dsch;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet adbillsmodificationvalidate(string compcode, string ciobookid, string supplementbilldate, string supplementbillno, string userid, string dateformat)
    {
        DataSet dsch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindbgcolor = new NewAdbooking.Classes.adbooking();
            dsch = bindbgcolor.adbillsmodificationvalidate(compcode, ciobookid, supplementbilldate, supplementbillno, userid, dateformat, Session["revenue"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bindbgcolor = new NewAdbooking.classesoracle.adbooking();
                dsch = bindbgcolor.adbillsmodificationvalidate(compcode, ciobookid, supplementbilldate, supplementbillno, userid, dateformat, Session["revenue"].ToString());
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, "", Session["revenue"].ToString(), ciobookid, supplementbillno, supplementbilldate, dateformat, userid, "", "", "", "", "" };
                string procedureName = "ad_bills_modification_validate";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dsch = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bindbgcolor = new NewAdbooking.classmysql.BookingMaster();
                //dsch = bindbgcolor.adbillsmodificationvalidate(compcode, ciobookid, supplementbilldate, supplementbillno, userid, dateformat, Session["revenue"].ToString());
            }
        return dsch;
    }
    [Ajax.AjaxMethod]
    public DataSet CHECKBOOKINGCREDITLIMIT(string compcode, string agcodeforcreadit, string outstand, string billamt, string datecheck, string dateformat, string cioid, string modflag)
    {
        DataSet dex = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking showgri = new NewAdbooking.Classes.adbooking();
            dex = showgri.CHECKBOOKINGCREDITLIMIT(compcode, agcodeforcreadit, outstand, billamt, datecheck, dateformat, cioid, modflag);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking showgri = new NewAdbooking.classesoracle.adbooking();
            dex = showgri.CHECKBOOKINGCREDITLIMIT(compcode, agcodeforcreadit, outstand, billamt, datecheck, dateformat, cioid, modflag);
        }

        else
        {
            string[] parameterValueArray = new string[] { compcode, agcodeforcreadit, outstand, billamt, datecheck, cioid, modflag, "", "", "", "" };
            string procedureName = "CHECKBOOKINGCREDITLIMIT";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dex = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();
            //dex = showgri.CHECKBOOKINGCREDITLIMIT(compcode, agcodeforcreadit, outstand, billamt, datecheck, dateformat, cioid, modflag);
        }
        return dex;

    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public string getusername()
    {
        string name = Session["username"].ToString();
        return name;
    }
    [Ajax.AjaxMethod]
    public DataSet chkSpaceEdiPageDateWise(string editionname, string compcode, string pageno, string date_p, string edition_area, string inserthei_p, string insertwid_p, string dateformat, string cioid)
    {
        DataSet dsch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindbgcolor = new NewAdbooking.Classes.adbooking();
            // dsch = bindbgcolor.adbillsmodificationvalidate(compcode, ciobookid, supplementbilldate, supplementbillno, userid, dateformat, Session["revenue"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bindbgcolor = new NewAdbooking.classesoracle.adbooking();
                dsch = bindbgcolor.chkSpaceEdiPageDateWise(editionname, compcode, pageno, date_p, edition_area, inserthei_p, insertwid_p, dateformat, cioid);
            }
            else
            {
                string[] parameterValueArray = new string[] { editionname, compcode, pageno, date_p, edition_area, inserthei_p, insertwid_p, dateformat, cioid };
                string procedureName = "chkSpaceEdiPageDateWise";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                //dsch = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bindbgcolor = new NewAdbooking.classmysql.BookingMaster();
                //dsch = bindbgcolor.chkSpaceEdiPageDateWise(editionname, compcode, pageno, date_p, edition_area, inserthei_p, insertwid_p, dateformat, cioid);
            }
        return dsch;
    }
    public void bindcoupan()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindopackage = new NewAdbooking.Classes.adbooking();
            ds = bindopackage.bindcoupan(Session["compcode"].ToString(), Session["center"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindopackage = new NewAdbooking.classesoracle.adbooking();
            ds = bindopackage.bindcoupan(Session["compcode"].ToString(), Session["center"].ToString());
        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["center"].ToString(), "", "" };
            string procedureName = "GETCOUPAN";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindopackage = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindopackage.bindcoupan(Session["compcode"].ToString(), Session["center"].ToString());
        }



        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select CPN";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcoutype.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpcoutype.Items.Add(li);
            }

        }
    }
    [Ajax.AjaxMethod]
    public DataSet getCouAmount(string compcode, string center, string coutype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindopackage = new NewAdbooking.Classes.adbooking();
            ds = bindopackage.getCouAmount(compcode, center, coutype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindopackage = new NewAdbooking.classesoracle.adbooking();
            ds = bindopackage.getCouAmount(compcode, center, coutype);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, center, coutype };
            string procedureName = "getCouAmount";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindopackage = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindopackage.getCouAmount(compcode, center, coutype);

        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet chkCoupan(string compcode, string center, string cpnno)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindopackage = new NewAdbooking.Classes.adbooking();
            ds = bindopackage.chkCoupan(compcode, center, cpnno);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindopackage = new NewAdbooking.classesoracle.adbooking();
            ds = bindopackage.chkCoupan(compcode, center, cpnno);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, center, cpnno, "" };
            string procedureName = "chkCoupan";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindopackage = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindopackage.chkCoupan(compcode, center, cpnno);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet validationCoupan(string compcode, string center, string cpnno, string cpntype, string agcode, string execode, string dtime, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindopackage = new NewAdbooking.Classes.adbooking();
            ds = bindopackage.validationCoupan(compcode, center, cpnno, cpntype, agcode, execode, dtime, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindopackage = new NewAdbooking.classesoracle.adbooking();
            ds = bindopackage.validationCoupan(compcode, center, cpnno, cpntype, agcode, execode, dtime, dateformat);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, center, cpnno, cpntype, agcode, execode, dtime, dateformat };
            string procedureName = "validationCoupan";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindopackage = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindopackage.validationCoupan(compcode, center, cpnno, cpntype, agcode, execode, dtime, dateformat);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getpageadinfo(string compcode, string pageprem, string editionname, string pageno, string date_p, string userid, string cioid)
    {
        DataSet dsch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindbgcolor = new NewAdbooking.Classes.adbooking();
            dsch = bindbgcolor.getpageadinfo(compcode, pageprem, editionname, pageno, date_p, userid, cioid, "", "", "", "", "");
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bindbgcolor = new NewAdbooking.classesoracle.adbooking();
                dsch = bindbgcolor.getpageadinfo(compcode, pageprem, editionname, pageno, date_p, userid, cioid, "", "", "", "", "");
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, pageprem, editionname, pageno, date_p, userid, cioid, "", "", "", "", "" };
                string procedureName = "getpageadinfo";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dsch = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bindbgcolor = new NewAdbooking.classmysql.BookingMaster();
                //dsch = bindbgcolor.getpageadinfo(compcode, pageprem, editionname, pageno, date_p, userid, cioid, "", "", "", "", "");
            }
        return dsch;
    }
    [Ajax.AjaxMethod]
    public DataSet adretain_billbase_outstanding(string compcode, string agencycodesubcode, string retain_code, string datetime, string dateformat, string agencytype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindagenname = new NewAdbooking.Classes.adbooking();
            ds = bindagenname.adretain_billbase_outstanding(compcode, agencycodesubcode, retain_code, datetime, dateformat, agencytype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindagenname = new NewAdbooking.classesoracle.adbooking();
            ds = bindagenname.adretain_billbase_outstanding(compcode, agencycodesubcode, retain_code, datetime, dateformat, agencytype);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, "", "", agencycodesubcode, retain_code, datetime, dateformat, agencytype };
            string procedureName = "adretain_billbase_outstanding";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindbgcolor = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindagenname.adretain_billbase_outstanding(compcode, agencycodesubcode, retain_code, datetime, dateformat, agencytype);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet adexec_billbase_outstanding(string compcode, string agencycodesubcode, string executive_code, string datetime, string dateformat, string agencytype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindagenname = new NewAdbooking.Classes.adbooking();
            ds = bindagenname.adexec_billbase_outstanding(compcode, agencycodesubcode, executive_code, datetime, dateformat, agencytype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindagenname = new NewAdbooking.classesoracle.adbooking();
            ds = bindagenname.adexec_billbase_outstanding(compcode, agencycodesubcode, executive_code, datetime, dateformat, agencytype);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, "", "", agencycodesubcode, executive_code, datetime, dateformat, agencytype };
            string procedureName = "adexec_billbase_outstanding";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster bindagenname = new NewAdbooking.classmysql.BookingMaster();
            //ds = bindagenname.adexec_billbase_outstanding(compcode, agencycodesubcode, executive_code, datetime, dateformat, agencytype);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet multi_billing(string compcode, string client_code, string client_name, string client_address, string width, string height, string gross_amt, string comm, string bill_amt, string bill_no, string bill_dt, string userid, string flag, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindopackage = new NewAdbooking.Classes.adbooking();
            ds = bindopackage.multi_billing(compcode, client_code, client_name, client_address, width, height, gross_amt, comm, bill_amt, bill_no, bill_dt, userid, flag, extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindopackage = new NewAdbooking.classesoracle.adbooking();
            ds = bindopackage.multi_billing(compcode, client_code, client_name, client_address, width, height, gross_amt, comm, bill_amt, bill_no, bill_dt, userid, flag, extra1, extra2, extra3, extra4, extra5);
        }
        else
        {
            /*string[] parameterValueArray = new string[] { compcode, client_code, client_name, client_address, width, height, gross_amt, comm, bill_amt, bill_no, bill_dt, userid, flag, extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "MULTIBILLING_RO";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
            NewAdbooking.classmysql.BookingMaster bindopackage = new NewAdbooking.classmysql.BookingMaster();
            ds = bindopackage.multi_billing(compcode, client_code, client_name, client_address, width, height, gross_amt, comm, bill_amt, bill_no, bill_dt, userid, flag, extra1, extra2, extra3, extra4, extra5);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet billupdatedatatemptable(string compcode, string ciobookid, string supplementbilldate, string supplementbillno, string userid, string dateformat, string newbookingid)
    {
        DataSet dsch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindbgcolor = new NewAdbooking.Classes.adbooking();
            dsch = bindbgcolor.billupdatedatatemptable(compcode, ciobookid, supplementbilldate, supplementbillno, userid, dateformat, newbookingid);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bindbgcolor = new NewAdbooking.classesoracle.adbooking();
                dsch = bindbgcolor.billupdatedatatemptable(compcode, ciobookid, supplementbilldate, supplementbillno, userid, dateformat, newbookingid);
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, userid, ciobookid, supplementbillno, newbookingid };
                string procedureName = "receiptsave_booking_bill";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dsch = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster bindbgcolor = new NewAdbooking.classmysql.BookingMaster();
                //dsch = bindbgcolor.billupdatedatatemptable(compcode, ciobookid, supplementbilldate, supplementbillno, userid, dateformat, newbookingid);
            }
        return dsch;
    }
    [Ajax.AjaxMethod]
    public DataSet colexec_bind(string compcode, string colexec)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking cls_comb = new NewAdbooking.Classes.adbooking();
            da = cls_comb.colexec_bind(compcode, colexec);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking cls_comb = new NewAdbooking.classesoracle.adbooking();
                da = cls_comb.colexec_bind(compcode, colexec);
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, colexec };
                string procedureName = "REPBIND_REPBIND_P";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                da = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster cls_comb = new NewAdbooking.classmysql.BookingMaster();
                //da = cls_comb.colexec_bind(compcode, colexec);
            }
        return da;
    }
    //////////////////////add by anuja for check agreed amount combination of(adtype,adcategory,pageprem,adtype,client)

    [Ajax.AjaxMethod]
    public DataSet getagreedamtchk(string compcode, string client, string pack_age, string adtype, string adcategory, string color, string page_prem, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster insert = new NewAdbooking.classesoracle.BookingMaster();
            ds = insert.getagreedamtchk(compcode, client, pack_age, adtype, adcategory, color, page_prem, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster insert = new NewAdbooking.Classes.BookingMaster();
            ds = insert.getagreedamtchk(compcode, client, pack_age, adtype, adcategory, color, page_prem, userid);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, client, pack_age, adtype, adcategory, color, page_prem, userid };
            string procedureName = "Agrredratechk";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster cls_comb = new NewAdbooking.classmysql.BookingMaster();
            //ds = insert.getagreedamtchk(compcode, client, pack_age, adtype, adcategory, color, page_prem, userid);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getteamname(string compcode, string teamname, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.tv_booking_transaction insert = new NewAdbooking.classesoracle.tv_booking_transaction();
            ds = insert.getteamname(compcode, teamname, extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.tv_booking_transaction insert = new NewAdbooking.Classes.tv_booking_transaction();
            ds = insert.getteamname(compcode, teamname, extra1, extra2, extra3, extra4, extra5);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, teamname, extra1, extra2, extra3, extra4, extra5 };
            //string procedureName = "BIND_BOOKING_TEAM";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            NewAdbooking.classmysql.BookingMaster insert = new NewAdbooking.classmysql.BookingMaster();
            ds = insert.getteamname(compcode, teamname, extra1, extra2, extra3, extra4, extra5);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindbrand(string compcode, string brand, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking insert = new NewAdbooking.classesoracle.adbooking();
            ds = insert.bindbrand(compcode, brand, extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking insert = new NewAdbooking.Classes.adbooking();
            ds = insert.bindbrand(compcode, brand, extra1, extra2, extra3, extra4, extra5);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, brand, extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "BINDBRAND";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster insert = new NewAdbooking.classmysql.BookingMaster();
            //ds = insert.bindbrand(compcode, brand, extra1, extra2, extra3, extra4, extra5);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindbrandproduct(string compcode, string brand, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking insert = new NewAdbooking.classesoracle.adbooking();
            ds = insert.bindbrandproduct(compcode, brand, extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking insert = new NewAdbooking.Classes.adbooking();
            ds = insert.bindbrandproduct(compcode, brand, extra1, extra2, extra3, extra4, extra5);
        }
        else
        {
            string[] parameterValueArray = new string[] { compcode, brand, extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "BINDBRANDPRODUCT";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster insert = new NewAdbooking.classmysql.BookingMaster();
            //ds = insert.bindbrandproduct(compcode, brand, extra1, extra2, extra3, extra4, extra5);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet send_sms(string comp_cd, string mainbookingid, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { comp_cd, mainbookingid, extra1, extra2, extra3, extra4, extra5 };
        string procedureName = "SEND_SMS_ad_booking";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CommonClass sms = new NewAdbooking.Classes.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        {
            Mobno = ds.Tables[0].Rows[0]["PHONE"].ToString();
            ag_EmailID = ds.Tables[0].Rows[0]["ag_EmailID"].ToString();
            id = ds.Tables[0].Rows[0]["cio_booking_id"].ToString();
            no_of_insertion = ds.Tables[0].Rows[0]["no_of_insertion"].ToString();
            ro_no = ds.Tables[0].Rows[0]["ro_no"].ToString();
            gross_amount = ds.Tables[0].Rows[0]["gross_amount"].ToString();
            adsize = ds.Tables[0].Rows[0]["adsize"].ToString();

            if (Mobno != "" && Mobno != null && Mobno != "undefined")
            {
                send(Mobno, ag_EmailID, id, ro_no, adsize, no_of_insertion, gross_amount, extra1, extra2, extra3, extra4, extra5);
            }
        }
        return ds;
    }

    public void send(string Mobno, string ag_EmailID, string id, string ro_no, string adsize, string no_of_insertion, string gross_amount, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        string message = "Thank you for Advertising in NAMASTHE TELANGANA. Your RO No: " + ro_no + " ,Your Ad size is =" + adsize + " cm. Total Ads :" + no_of_insertion + " Your Gross Amount is Rs.=" + gross_amount + "/-. Feel free to contact 1800 525 3666 for further assistance";

        string bulk = "Bulk";
        HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("" + extra1 + "&username=" + extra2 + "&password=" + extra3 + "&mobile=" + Mobno + "&message=" + message + "&sendername=" + extra4 + "");
        myReq.Timeout = 5000;
        HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
        System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
        string responseString = respStreamReader.ReadToEnd();
        respStreamReader.Close();
        myResp.Close();
    }
    //anuja
    [Ajax.AjaxMethod]
    public DataSet indus(string compcode, string indscode, string indusname)
    {
        DataSet dsbrand = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster brandbind = new NewAdbooking.Classes.BookingMaster();
            dsbrand = brandbind.bindindus(compcode, indscode, indusname);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster brandbind = new NewAdbooking.classesoracle.BookingMaster();
                dsbrand = brandbind.bindindus(compcode, indscode, indusname);
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, indscode, indusname };
                string procedureName = "ADPRODUCTMAINCAT_P";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dsbrand = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster brandbind = new NewAdbooking.classmysql.BookingMaster();
                //dsbrand = brandbind.bindindus(compcode, indscode, indusname);
            }

        return dsbrand;
    }
    [Ajax.AjaxMethod]
    public DataSet fillprodcat(string comcode, string insduscode, string producaname)
    {
        DataSet dva = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster brandbind = new NewAdbooking.Classes.BookingMaster();
            dva = brandbind.bindprocat(comcode, insduscode, producaname);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster brandbind = new NewAdbooking.classesoracle.BookingMaster();
            dva = brandbind.bindprocat(comcode, insduscode, producaname);
        }

        else
        {
            string[] parameterValueArray = new string[] { comcode, insduscode, producaname };
            string procedureName = "ADPRODUCTSUBCAT_P";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dva = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster brandbind = new NewAdbooking.classmysql.BookingMaster();
            //dva = brandbind.bindprocat(comcode, insduscode, producaname);
        }

        return dva;


    }
    [Ajax.AjaxMethod]
    public DataSet procatsub(string compcode, string indscode, string procatcode)
    {
        DataSet dsbrand = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster brandbind = new NewAdbooking.Classes.BookingMaster();
            dsbrand = brandbind.procatsub(compcode, indscode, procatcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster brandbind = new NewAdbooking.classesoracle.BookingMaster();
                dsbrand = brandbind.procatsub(compcode, indscode, procatcode);
            }
            else
            {
                string[] parameterValueArray = new string[] { compcode, indscode, procatcode };
                string procedureName = "ad_product_third_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dsbrand = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                //NewAdbooking.classmysql.BookingMaster brandbind = new NewAdbooking.classmysql.BookingMaster();
                //dsbrand = brandbind.procatsub(compcode, indscode, procatcode);
            }

        return dsbrand;
    }
    [Ajax.AjaxMethod]
    public DataSet productbind(string compcode, string brand)
    {
        DataSet dva = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getvarient = new NewAdbooking.Classes.BookingMaster();
            dva = getvarient.bindprodyc(brand, compcode);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking getvarient = new NewAdbooking.classesoracle.adbooking();
            dva = getvarient.bindprodyc(brand, compcode);
        }

        else
        {
            /*string[] parameterValueArray = new string[] { brand, compcode };
            string procedureName = "AN_PRODUCT_AN_bindproductcat_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dva = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
            NewAdbooking.classmysql.BookingMaster getvarient = new NewAdbooking.classmysql.BookingMaster();
            dva = getvarient.bindprodyc(brand, compcode);
        }
        return dva;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet pub_centbind(string publication)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract pub_cent1 = new NewAdbooking.classesoracle.Contract();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract pub_cent1 = new NewAdbooking.Classes.Contract();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), "");
        }
        else
        {
            //string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), "", "" };
            //string procedureName = "bind_pubcentname_new";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

            NewAdbooking.classmysql.BookingMaster Show_NoAd = new NewAdbooking.classmysql.BookingMaster();
            ds = Show_NoAd.mailpritingcenter(Session["compcode"].ToString(), Session["userid"].ToString(), "", publication);

        }
        return ds;
    }

    /*[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet pub_centbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract pub_cent1 = new NewAdbooking.classesoracle.Contract();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract pub_cent1 = new NewAdbooking.Classes.Contract();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), "");
        }
        else
        {
            //string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), "", "" };
            //string procedureName = "bind_pubcentname_new";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

            NewAdbooking.classmysql.BookingMaster Show_NoAd = new NewAdbooking.classmysql.BookingMaster();
            ds = Show_NoAd.mailpritingcenter(Session["compcode"].ToString(), Session["userid"].ToString(), "", "");

        }
        return ds;
    }*/


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet branchbind(string centercd, string ciobookid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking pub_cent1 = new NewAdbooking.classesoracle.adbooking();
            ds = pub_cent1.branchbind(Session["compcode"].ToString(), Session["userid"].ToString(), centercd, ciobookid, "", "", "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking pub_cent1 = new NewAdbooking.Classes.adbooking();
            ds = pub_cent1.branchbind(Session["compcode"].ToString(), Session["userid"].ToString(), centercd, ciobookid, "", "", "", "");
        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), centercd, ciobookid, "", "", "", "" };
            string procedureName = "bind_branchwithemail";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet mailsave(string cioid, string compcode, string mailcenter, string mailbranch, string mailid, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking insert = new NewAdbooking.classesoracle.adbooking();
            ds = insert.mailsave(cioid, compcode, mailcenter, mailbranch, mailid, userid, extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking insert = new NewAdbooking.Classes.adbooking();
            ds = insert.mailsave(cioid, compcode, mailcenter, mailbranch, mailid, userid, extra1, extra2, extra3, extra4, extra5);
        }
        else
        {
            //string[] parameterValueArray = new string[] { cioid, compcode, mailcenter, mailbranch, mailid, userid, extra1, extra2, extra3, extra4, extra5 };
            //string procedureName = "savebookingmaildetails";
            //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            //ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            NewAdbooking.classmysql.BookingMaster insert = new NewAdbooking.classmysql.BookingMaster();
            ds = insert.mailsave(cioid, compcode, mailcenter, mailbranch, mailid, userid, extra1, extra2, extra3, extra4, extra5);

        }
        return ds;
    }
    /// anuja reatinercheck   
    [Ajax.AjaxMethod]
    public DataSet getretaineragencycheck(string retainercode, string compcode, string agencycodesubcode)
    {
        //string execcode = txtexecname.Text;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking clsbooking = new NewAdbooking.Classes.adbooking();
            ds = clsbooking.getretaineragechek(retainercode, compcode, agencycodesubcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
            ds = clsbooking.getretaineragechek(retainercode, compcode, agencycodesubcode);
        }
        else
        {
            string[] parameterValueArray = new string[] { retainercode, compcode, agencycodesubcode };
            string procedureName = "websp_retaineragencycheck";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getgstcode(string compcode, string agencycodesubcode, string client, string uom, string revenue, string adcategory, string bookdatetime, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, agencycodesubcode, client, uom, revenue, adcategory, bookdatetime, extra1, extra2, extra3, extra4, extra5 };
        string procedureName = "getgstdetail";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CommonClass sms = new NewAdbooking.Classes.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public string mailfinalsave(string compcode, string cioid, string mailid, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        string err = "";
        string mat_spl_nm = "";
        string mat_org_nm = "";
        try
        {
            DataSet ds12 = new DataSet();
            string[] parameterValueArray = new string[] { compcode, cioid, extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "SEND_SMS_ad_booking";
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
                ds12 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.CommonClass sms = new NewAdbooking.Classes.CommonClass();
                ds12 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                //ds12 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                NewAdbooking.classmysql.BookingMaster Show_NoAd = new NewAdbooking.classmysql.BookingMaster();
                ds12 = Show_NoAd.maildetailsbind(compcode, cioid, extra1, extra2, extra3, extra4, extra5);
            }
            DataSet ds1222 = new DataSet();
            //string[] parameterValueArray = new string[] { compcode, cioid, extra1, extra2, extra3, extra4, extra5 };
           // string procedureName = "remove_dulicate_in_str";

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                //NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
                //ds12 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //NewAdbooking.Classes.CommonClass sms = new NewAdbooking.Classes.CommonClass();
                //ds12 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                //ds12 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                NewAdbooking.classmysql.BookingMaster Show_NoAd = new NewAdbooking.classmysql.BookingMaster();
                ds1222 = Show_NoAd.remove_dulicate_in_str(mailid);
            }

             mailid = ds1222.Tables[0].Rows[0]["mail_id"].ToString();



            {
                Mobno = ds12.Tables[0].Rows[0]["PHONE"].ToString();
                ag_EmailID = ds12.Tables[0].Rows[0]["ag_EmailID"].ToString();
                id = ds12.Tables[0].Rows[0]["cio_booking_id"].ToString();
                no_of_insertion = ds12.Tables[0].Rows[0]["no_of_insertion"].ToString();
                ro_no = ds12.Tables[0].Rows[0]["ro_no"].ToString();
                gross_amount = ds12.Tables[0].Rows[0]["gross_amount"].ToString();
                adsize = ds12.Tables[0].Rows[0]["adsize"].ToString();

                agreed_ratem = ds12.Tables[0].Rows[0]["Agrred_rate"].ToString();
                agreed_amountm = ds12.Tables[0].Rows[0]["Agreed_amount"].ToString();
                //string agencyname   = ds12.Tables[0].Rows[0]["agency_name"].ToString() + "(" + ds12.Tables[0].Rows[0]["agency_code"].ToString() + ds12.Tables[0].Rows[0]["agency_sub_code"].ToString() + ")";
                string agencyname = ds12.Tables[0].Rows[0]["agency_name"].ToString() + "(" + ds12.Tables[0].Rows[0]["agency_sub_code"].ToString() + ")";
                string clientname = ds12.Tables[0].Rows[0]["cust_name"].ToString();
                string rodate = ds12.Tables[0].Rows[0]["RO_DATE"].ToString();
                string UOM_NAME = ds12.Tables[0].Rows[0]["UOM_NAME"].ToString();
                string CARD_RATE = ds12.Tables[0].Rows[0]["CARD_RATE"].ToString();
                string USERNAME = ds12.Tables[0].Rows[0]["USERNAME"].ToString();
                string USEREMAIL = ds12.Tables[0].Rows[0]["USEREMAIL"].ToString();
                string PRINT_REMARK = ds12.Tables[0].Rows[0]["PRINT_REMARK"].ToString();
                string PAGE_NO = ds12.Tables[0].Rows[0]["PAGE_NO"].ToString();
                string Publ_revenue_name = ds12.Tables[0].Rows[0]["PUBL_REVENUE_NAME"].ToString();
                string AGENCYEMAILID = ds12.Tables[0].Rows[0]["AGENCYEMAILID"].ToString();
                string COL_NAME = ds12.Tables[0].Rows[0]["COL_NAME"].ToString();
                string SPECIAL_DISCOUNT = ds12.Tables[0].Rows[0]["SPECIAL_DISCOUNT"].ToString();
                //string SPECIAL_DISCOUNT = ds12.Tables[0].Rows[0]["DISCOUNT"].ToString();
                string CAPTION = ds12.Tables[0].Rows[0]["CAPTION"].ToString();
                string PACKAGE_NAME = ds12.Tables[0].Rows[0]["PACKAGE_NAME"].ToString();
                string COMBIN_DESC = ds12.Tables[0].Rows[0]["COMBIN_DESC"].ToString();
                string INSERT_DATE = ds12.Tables[0].Rows[0]["INSERT_DATE"].ToString();
                string INSERT_STATUS = ds12.Tables[0].Rows[0]["INSERT_STATUS"].ToString();
                string BOOKED_BY = ds12.Tables[0].Rows[0]["BOOKED_BY"].ToString();
                string INSERT_MATERIAL = ds12.Tables[0].Rows[0]["INSERT_MATERIAL"].ToString();
                string VARIANT = ds12.Tables[0].Rows[0]["VARIANT"].ToString();
                string PUBLICATION = ds12.Tables[0].Rows[0]["PUBLICATION"].ToString();
                string usermail2 = ds12.Tables[0].Rows[0]["USEREMAIL"].ToString();
                string EXECUTIVE_NAME = ds12.Tables[0].Rows[0]["EXECUTIVE_NAME"].ToString();
                string TEMP_AGENCY_CODE = "";
                string t_AGCATEGORY = "";
                string t_MAIL = "";
                string t_ADDRESS = "";
                string t_PLACE = "";
                string t_GST = "";
                string t_MOB = "";
                string t_PINCODE = "";
                string t_agency = "";
                string t_phone = "";
                string filename = ds12.Tables[0].Rows[0]["FILE_NAME"].ToString();
                string BOOKED_BY_CENTER = ds12.Tables[0].Rows[0]["BOOKED_CENTER"].ToString();
                string special_discount_per = ds12.Tables[0].Rows[0]["special_disc_per"].ToString();
                string space_discount_amt = ds12.Tables[0].Rows[0]["space_discount"].ToString();

                string prem_per = ds12.Tables[0].Rows[0]["prem_per"].ToString();
                string bill_amount = ds12.Tables[0].Rows[0]["bill_amount"].ToString();
                string mailing_center = ds12.Tables[0].Rows[0]["mailing_center"].ToString();
                string RESOURCE_NO = ds12.Tables[0].Rows[0]["RESOURCE_NO"].ToString();
                string material_status_auto = ds12.Tables[0].Rows[0]["material_status"].ToString();
                if (ds12.Tables[1].Rows.Count > 0)
                {
                    TEMP_AGENCY_CODE = ds12.Tables[1].Rows[0]["TEMP_AGENCY_CODE"].ToString();
                    t_AGCATEGORY = ds12.Tables[1].Rows[0]["AGENCY_TYPE_NAME"].ToString();
                    t_MAIL = ds12.Tables[1].Rows[0]["MAIL"].ToString();
                    t_ADDRESS = ds12.Tables[1].Rows[0]["ADDRESS"].ToString();
                    t_PLACE = ds12.Tables[1].Rows[0]["PLACE"].ToString();
                    t_GST = ds12.Tables[1].Rows[0]["GST"].ToString();
                    t_MOB = ds12.Tables[1].Rows[0]["MOB"].ToString();
                    t_PINCODE = ds12.Tables[1].Rows[0]["PINCODE"].ToString();
                    t_agency = ds12.Tables[1].Rows[0]["AGENCY"].ToString();
                    t_phone = ds12.Tables[1].Rows[0]["PHONE_NO"].ToString();
                }


                if (INSERT_STATUS != "cancel")
                {
                    /*if (INSERT_STATUS != "BOOKED")
                    {
                        INSERT_STATUS = "Modify";
                    }
                    else
                    {*/
                    if (material_status_auto == "Revised")
                    {
                        INSERT_STATUS = "Revised Material";
                    }
                    else if (extra2 == "modify")
                    {
                        INSERT_STATUS = "MODIFIED";
                    }
                    else
                    {
                        INSERT_STATUS = "BOOKED";
                    }

                    //}

                }
                //if (Mobno != "" && Mobno != null && Mobno != "undefined")
                //{
                //  send(Mobno, ag_EmailID, id, ro_no, adsize, no_of_insertion, gross_amount, extra1, extra2, extra3, extra4, extra5);

                DataSet objdat1 = new DataSet();
                // Read in the XML file
                string datapath = (Server.MapPath("XML/dealmailbody.xml")).Replace("ajax\\", "");
                //  datapath.Replace("ajax\\","");
                objdat1.ReadXml(datapath);
                string mailtoval = mailid + "," + USEREMAIL /*+"," + "sourabh.sharma@4cplus.com" + "," + "bhattijs18@gmail.com"*/;
                //string mailtoval = "sourabh.sharma@4cplus.com" ;


                string mailbody = "SBNo.:" + cioid + "\n" + "Publication :" + PUBLICATION + "\n" + "Package :" + PACKAGE_NAME + "\n" + "VARIANT :" + VARIANT + "\n" + "Order Type :" + RESOURCE_NO + "\n" + "Date Of Publication :" + INSERT_DATE + "\n" + "RO Date :" + rodate + "\n" + "RO No: " + ro_no + "\n" + "Agency :" + agencyname + "\n" + "Colour:" + COL_NAME + "\n" + "Rate:" + CARD_RATE + "\n" + "Discount on Rate:" + SPECIAL_DISCOUNT + "\n" + "Page Number:" + PAGE_NO + "\n" + "Ad size is =" + adsize + " " + UOM_NAME + "\n" + "Client :-" + clientname + "\n" + "Caption :-" + CAPTION + "\n" + "Extra For Spl.Position :-" + "0" + "\n" + "Remark :-" + PRINT_REMARK + "\n" + "Total Ads :" + no_of_insertion + "\n" + "Gross Amount is Rs.=" + gross_amount + "/-." + "\n" + "Agreed Rate Rs.= " + agreed_ratem + "/-." + "\n" + "Agreed Amount Rs.= " + agreed_amountm + "\n" + "Special Discount = " + special_discount_per + "\n" + "Space Discount = " + space_discount_amt + "/-." + "\n" + "Page Prem. = " + prem_per + "\n" + "Bill Amount = " + bill_amount + "\n" + "Mailing Center = " + mailing_center + "\n" + "Executive Name :-" + EXECUTIVE_NAME + "\n" + "File Name :-" + filename + "\n" + "Booked By Center :-" + BOOKED_BY_CENTER;
                string t_mailbody = "SBNo.:" + cioid + "\n" + "Agency Category :" + t_AGCATEGORY + "\n" + "Agency Name :" + t_agency + "\n" + "Address : " + t_ADDRESS + "\n" + "Place : " + t_PLACE + "\n" + "Pin Code : " + t_PINCODE + "\n" + "Mail Id : " + t_MAIL + "\n" + "GST NO : " + t_GST + "\n" + "Mobile No : " + t_MOB + "\n" + "Phone No : " + t_phone;

                string smtpadd = objdat1.Tables[0].Rows[0].ItemArray[32].ToString();
                string mailfromval = usermail2 + "," + (objdat1.Tables[0].Rows[0].ItemArray[31].ToString()) /*+ "," + "adsonline@newindianexpress.com"*/;
                string mailstr = objdat1.Tables[0].Rows[0].ItemArray[33].ToString();
                string attachurl = objdat1.Tables[0].Rows[0].ItemArray[34].ToString();
                string insert_mat_attachurl = objdat1.Tables[0].Rows[0].ItemArray[35].ToString();
                string insert_mat_orignalurl = objdat1.Tables[0].Rows[0].ItemArray[36].ToString();
                string attachlink = "";

                if (extra1 != "")
                {
                    string[] arr = extra1.Split(",".ToCharArray());
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i].ToString() != " " || arr[i].ToString() != "")
                        {
                            if (attachlink == "")
                            {
                                //    attachlink = "<BR><a href=\"" + attachurl + "?xab=" + arr[i].ToString() + "\">Attachment " + (i + 1) + "</a>";
                                attachlink = attachurl + "?xab=" + arr[i].ToString().Replace(" ", "~~");
                            }
                            else
                            {
                                //  attachlink = attachlink + "<BR><a href=\"" + attachurl + "?xab=" + arr[i].ToString() + "\">Attachment " + (i + 1) + "</a>";
                                attachlink = attachlink + "\n" + attachurl + "?xab=" + arr[i].ToString().Replace(" ", "~~");
                            }
                        }
                    }
                    //  attachlink = "<html><body>" + attachlink + "</body></html>";
                }
                if (INSERT_MATERIAL != "")
                {
                    string[] arr = INSERT_MATERIAL.Split(",".ToCharArray());
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i].ToString() != " " || arr[i].ToString() != "")
                        {
                            if (mat_spl_nm == "")
                            {
                                //    attachlink = "<BR><a href=\"" + attachurl + "?xab=" + arr[i].ToString() + "\">Attachment " + (i + 1) + "</a>";
                                mat_spl_nm = insert_mat_attachurl + "?xab=" + arr[i].ToString().Replace(" ", "~~");
                            }
                            else
                            {
                                //  attachlink = attachlink + "<BR><a href=\"" + attachurl + "?xab=" + arr[i].ToString() + "\">Attachment " + (i + 1) + "</a>";
                                mat_spl_nm = mat_spl_nm + "\n" + insert_mat_attachurl + "?xab=" + arr[i].ToString().Replace(" ", "~~");
                            }
                        }
                        if (arr[i].ToString() != " " || arr[i].ToString() != "")
                        {
                            if (mat_org_nm == "")
                            {
                                //    attachlink = "<BR><a href=\"" + attachurl + "?xab=" + arr[i].ToString() + "\">Attachment " + (i + 1) + "</a>";
                                mat_org_nm = insert_mat_orignalurl + "?xab=" + arr[i].ToString().Replace(" ", "~~");
                            }
                            else
                            {
                                //  attachlink = attachlink + "<BR><a href=\"" + attachurl + "?xab=" + arr[i].ToString() + "\">Attachment " + (i + 1) + "</a>";
                                mat_org_nm = mat_org_nm + "\n" + insert_mat_orignalurl + "?xab=" + arr[i].ToString().Replace(" ", "~~");
                            }
                        }
                    }
                    //  attachlink = "<html><body>" + attachlink + "</body></html>";
                }

                //objdat1.Tables[0].Rows[0].ItemArray[30].ToString();
                /*MailMessage msgMail = new MailMessage();
                msgMail.To = "sushil@4cplus.com,shubhamnamdev2233@gmail.com,bhanu@4cplus.com";// mailtoval;
                msgMail.From = mailfromval;
                msgMail.BodyFormat = MailFormat.Html;
                msgMail.Subject = "Regarding Request";
                msgMail.Body = mailstr + " " + mailbody;
                SmtpMail.SmtpServer = smtpadd;
                SmtpMail.Send(msgMail);*/

                MailMessage email_msg = new MailMessage();

                MailMessage t_email_msg = new MailMessage();
                if (AGENCYEMAILID != "")
                {
                    // email_msg.To.Add(mailtoval + "," + AGENCYEMAILID + ",bhattijs18@gmail.com" + ",sourabhsharma0701@gmail.com");//("karthick@newindianexpress.com,swamy@newindianexpress.com");
                    //email_msg.To.Add(mailtoval + "," + AGENCYEMAILID);//("karthick@newindianexpress.com,swamy@newindianexpress.com");
                    email_msg.To.Add(mailtoval);
                }
                else
                {
                    email_msg.To.Add(mailtoval);
                    //email_msg.To.Add(mailtoval + ",bhattijs18@gmail.com" + ",sourabhsharma0701@gmail.com");//("karthick@newindianexpress.com,swamy@newindianexpress.com");
                }
                //string t_fmailid = "bhattijs18@gmail.com" + "," + "sourabhsharma0701@gmail.com" + "," + USEREMAIL;
                string t_fmailid = USEREMAIL;
                if (t_agency != "")
                {
                    t_email_msg.To.Add(t_fmailid);
                    t_email_msg.From = new MailAddress(USEREMAIL);
                    t_email_msg.Subject = "New Agency Request, For Booking No :" + cioid;
                    t_email_msg.Body = t_mailbody;
                    t_email_msg.IsBodyHtml = false;

                }
                //email_msg.To.Add("sourabh.sharma@4cplus.com");
                //email_msg.From = new MailAddress("sourabh.sharma@4cplus.com");
                email_msg.From = new MailAddress(USEREMAIL);
                email_msg.Subject = (INSERT_STATUS).ToUpper() + "  4C Plus SBNo.:-" + cioid + "  And RO No:- " + ro_no + "  " + "  For The Agency :-" + agencyname + "  And Client :-" + clientname + "By :-" + BOOKED_BY;
                //email_msg.Body = mailstr + " " + mailbody;
                string status_canceled;
                status_canceled = "Following Ad Has been cancelled";
                status_canceled = status_canceled;
                if (attachlink != "" && mat_spl_nm != "")
                {
                    if (INSERT_STATUS != "cancel")
                    {
                        email_msg.Body = mailbody + "\n\n" + "Material Status:-" + material_status_auto + "\n\n\n\n" + "Click Here To Download:-" + "\n" + attachlink + /*"\n\n\n\n" + "Click Here To Download Material:-" + "\n" + mat_spl_nm +*/ "\n\n\n\n" + "Click Here To Download Orignal Material:-" + "\n" + mat_org_nm;

                    }
                    else
                    {
                        email_msg.Body = mailbody + "\n\n" + "Booking Status:-" + status_canceled + "\n\n\n\n" + "Click Here To Download:-" + "\n" + attachlink + /*"\n\n\n\n" + "Click Here To Download Material:-" + "\n" + mat_spl_nm +*/ "\n\n\n\n" + "Click Here To Download Orignal Material:-" + "\n" + mat_org_nm;
                    }

                }
                else if (attachlink != "")
                {
                    if (INSERT_STATUS != "cancel")
                    {
                        email_msg.Body = mailbody + "\n\n" + "Material Status:-" + material_status_auto + "\n\n\n\n" + "Click Here To Download:-" + "\n" + attachlink;// + "\n\n\n\n" + "Click Here To Download Matterial:-" + "\n" + mat_spl_nm;

                    }
                    else
                    {
                        email_msg.Body = mailbody + "\n\n" + "Booking Status:-" + status_canceled + "\n\n\n\n" + "Click Here To Download:-" + "\n" + attachlink; //+ "\n\n\n\n" + "Click Here To Download Matterial:-" + "\n" + mat_spl_nm;
                    }
                }
                else if (mat_spl_nm != "")
                {
                    if (INSERT_STATUS != "cancel")
                    {
                        email_msg.Body = mailbody + "\n\n" + "Material Status:-" + material_status_auto + /*"\n\n\n\n" + "Click Here To Download Material:-" + "\n" + mat_spl_nm + */"\n\n\n\n" + "Click Here To Download Orignal Material:-" + "\n" + mat_org_nm;

                    }
                    else
                    {
                        email_msg.Body = mailbody + "\n\n" + "Booking Status:-" + status_canceled + /*"\n\n\n\n" + "Click Here To Download Material:-" + "\n" + mat_spl_nm +*/ "\n\n\n\n" + "Click Here To Download Orignal Material:-" + "\n" + mat_org_nm;
                    }
                }
                else
                {
                    if (INSERT_STATUS != "cancel")
                    {
                        email_msg.Body = mailbody + "\n\n" + "Material Status:-" + material_status_auto;
                    }
                    else
                    {
                        email_msg.Body = mailbody + "\n\n" + "Material Status:-" + "\n" + material_status_auto + "\n\n\n\n" + "Booking Status:-" + status_canceled;
                    }
                    //email_msg.Body = mailbody;
                }

                email_msg.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = false;
                smtp.Port = 25;
                smtp.Host = "203.197.142.35";
                smtp.Credentials = new NetworkCredential("adsonline", "advtupload");
                smtp.Send(email_msg);
                if (t_agency != "")
                {
                    //smtp.Send(t_email_msg);
                }
                //}
            }
        }
        catch (Exception e)
        {
            err = e.Message;

        }

        return err;
    }



    /*
    [Ajax.AjaxMethod]
    public string mailfinalsave(string compcode, string cioid, string mailid, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        string err = "";
        string mat_spl_nm = "";
        try
        {
            DataSet ds12 = new DataSet();
            string[] parameterValueArray = new string[] { compcode, cioid, extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "SEND_SMS_ad_booking";
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
                ds12 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.CommonClass sms = new NewAdbooking.Classes.CommonClass();
                ds12 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                //ds12 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                NewAdbooking.classmysql.BookingMaster Show_NoAd = new NewAdbooking.classmysql.BookingMaster();
                ds12 = Show_NoAd.maildetailsbind(compcode, cioid, extra1, extra2, extra3, extra4, extra5);
            }
            {
                Mobno               = ds12.Tables[0].Rows[0]["PHONE"].ToString();
                ag_EmailID          = ds12.Tables[0].Rows[0]["ag_EmailID"].ToString();
                id                  = ds12.Tables[0].Rows[0]["cio_booking_id"].ToString();
                no_of_insertion     = ds12.Tables[0].Rows[0]["no_of_insertion"].ToString();
                ro_no               = ds12.Tables[0].Rows[0]["ro_no"].ToString();
                gross_amount        = ds12.Tables[0].Rows[0]["gross_amount"].ToString();
                adsize              = ds12.Tables[0].Rows[0]["adsize"].ToString();
                //string agencyname   = ds12.Tables[0].Rows[0]["agency_name"].ToString() + "(" + ds12.Tables[0].Rows[0]["agency_code"].ToString() + ds12.Tables[0].Rows[0]["agency_sub_code"].ToString() + ")";
                string agencyname   = ds12.Tables[0].Rows[0]["agency_name"].ToString() + "(" + ds12.Tables[0].Rows[0]["agency_sub_code"].ToString() + ")";
                string clientname   = ds12.Tables[0].Rows[0]["cust_name"].ToString();
                string rodate       = ds12.Tables[0].Rows[0]["RO_DATE"].ToString();
                string UOM_NAME     = ds12.Tables[0].Rows[0]["UOM_NAME"].ToString();
                string CARD_RATE    = ds12.Tables[0].Rows[0]["CARD_RATE"].ToString();
                string USERNAME     = ds12.Tables[0].Rows[0]["USERNAME"].ToString();
                string USEREMAIL    = ds12.Tables[0].Rows[0]["USEREMAIL"].ToString();
                string PRINT_REMARK = ds12.Tables[0].Rows[0]["PRINT_REMARK"].ToString();
                string PAGE_NO      = ds12.Tables[0].Rows[0]["PAGE_NO"].ToString();
                string Publ_revenue_name    = ds12.Tables[0].Rows[0]["PUBL_REVENUE_NAME"].ToString();
                string AGENCYEMAILID        = ds12.Tables[0].Rows[0]["AGENCYEMAILID"].ToString();
                string COL_NAME             = ds12.Tables[0].Rows[0]["COL_NAME"].ToString();
                string SPECIAL_DISCOUNT     = ds12.Tables[0].Rows[0]["SPECIAL_DISCOUNT"].ToString();
                //string SPECIAL_DISCOUNT = ds12.Tables[0].Rows[0]["DISCOUNT"].ToString();
                string CAPTION              = ds12.Tables[0].Rows[0]["CAPTION"].ToString();
                string PACKAGE_NAME         = ds12.Tables[0].Rows[0]["PACKAGE_NAME"].ToString();
                string COMBIN_DESC          = ds12.Tables[0].Rows[0]["COMBIN_DESC"].ToString();
                string INSERT_DATE          = ds12.Tables[0].Rows[0]["INSERT_DATE"].ToString();
                string INSERT_STATUS        = ds12.Tables[0].Rows[0]["INSERT_STATUS"].ToString();
                string BOOKED_BY            = ds12.Tables[0].Rows[0]["BOOKED_BY"].ToString();
                string INSERT_MATERIAL      = ds12.Tables[0].Rows[0]["INSERT_MATERIAL"].ToString();

                string TEMP_AGENCY_CODE     = "";
                string t_AGCATEGORY         = "";
                string t_MAIL               = "";
                string t_ADDRESS            = "";
                string t_PLACE              = "";
                string t_GST                = "";
                string t_MOB                = "";
                string t_PINCODE            = "";
                string t_agency             = "";
                string t_phone              = "";
                if (ds12.Tables[1].Rows.Count > 0)
                {
                      TEMP_AGENCY_CODE      = ds12.Tables[1].Rows[0]["TEMP_AGENCY_CODE"].ToString();
                      t_AGCATEGORY          = ds12.Tables[1].Rows[0]["AGENCY_TYPE_NAME"].ToString();
                      t_MAIL                = ds12.Tables[1].Rows[0]["MAIL"].ToString();
                      t_ADDRESS             = ds12.Tables[1].Rows[0]["ADDRESS"].ToString();
                      t_PLACE               = ds12.Tables[1].Rows[0]["PLACE"].ToString();
                      t_GST                 = ds12.Tables[1].Rows[0]["GST"].ToString();
                      t_MOB                 = ds12.Tables[1].Rows[0]["MOB"].ToString();
                      t_PINCODE             = ds12.Tables[1].Rows[0]["PINCODE"].ToString();
                      t_agency              = ds12.Tables[1].Rows[0]["AGENCY"].ToString();
                      t_phone               = ds12.Tables[1].Rows[0]["PHONE_NO"].ToString();
                }
                

                if (INSERT_STATUS != "cancel")
                {
                    INSERT_STATUS = "BOOKED";

                }
                //if (Mobno != "" && Mobno != null && Mobno != "undefined")
                //{
                    //  send(Mobno, ag_EmailID, id, ro_no, adsize, no_of_insertion, gross_amount, extra1, extra2, extra3, extra4, extra5);

                    DataSet objdat1 = new DataSet();
                    // Read in the XML file
                    string datapath = (Server.MapPath("XML/dealmailbody.xml")).Replace("ajax\\", "");
                    //  datapath.Replace("ajax\\","");
                    objdat1.ReadXml(datapath);
                    string mailtoval = mailid + ",adsonline@newindianexpress.com," + USEREMAIL;

                    string mailbody = "SBNo.:" + cioid + "\n" + "Publication :" + "." + "\n" + "Package :" + PACKAGE_NAME + "\n" + "Date Of Publication :" + INSERT_DATE + "\n" +  "RO Date :" + rodate + "\n" + "RO No: " + ro_no + "\n" + "Agency :" + agencyname + "\n" + "Colour:" + COL_NAME + "\n" + "Rate:" + CARD_RATE + "\n" + "Discount on Rate:" + SPECIAL_DISCOUNT + "\n" + "Page Number:" + PAGE_NO + "\n" + "Ad size is =" + adsize + " " + UOM_NAME + "\n" + "Client :-" + clientname + "\n" + "Caption :-" + CAPTION + "\n" + "Extra For Spl.Position :-" + "0" + "\n" + "Remark :-" + PRINT_REMARK + "\n" + "Total Ads :" + no_of_insertion + "\n" + "Gross Amount is Rs.=" + gross_amount + "/-.";
                    string t_mailbody = "SBNo.:" + cioid + "\n" + "Agency Category :" + t_AGCATEGORY + "\n" + "Agency Name :" + t_agency + "\n" + "Address : " + t_ADDRESS + "\n" + "Place : " + t_PLACE + "\n" + "Pin Code : " + t_PINCODE + "\n" + "Mail Id : " + t_MAIL + "\n" + "GST NO : " + t_GST + "\n" + "Mobile No : " + t_MOB + "\n" + "Phone No : " + t_phone;
                    
                    string smtpadd = objdat1.Tables[0].Rows[0].ItemArray[32].ToString();
                    string mailfromval = objdat1.Tables[0].Rows[0].ItemArray[31].ToString();
                    string mailstr = objdat1.Tables[0].Rows[0].ItemArray[33].ToString();
                    string attachurl = objdat1.Tables[0].Rows[0].ItemArray[34].ToString();
                    string insert_mat_attachurl = objdat1.Tables[0].Rows[0].ItemArray[35].ToString();
                    string attachlink = "";
                   
                    if (extra1 != "")
                    {
                        string[] arr = extra1.Split(",".ToCharArray());
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (arr[i].ToString() != " " || arr[i].ToString() != "")
                            {
                                if (attachlink == "")
                                {
                                //    attachlink = "<BR><a href=\"" + attachurl + "?xab=" + arr[i].ToString() + "\">Attachment " + (i + 1) + "</a>";
                                    attachlink = attachurl + "?xab=" + arr[i].ToString().Replace(" ","~~") ;
                                }
                                else
                                {
                                  //  attachlink = attachlink + "<BR><a href=\"" + attachurl + "?xab=" + arr[i].ToString() + "\">Attachment " + (i + 1) + "</a>";
                                    attachlink = attachlink + "\n" + attachurl + "?xab=" + arr[i].ToString().Replace(" ", "~~");
                                }
                            }
                        }
                      //  attachlink = "<html><body>" + attachlink + "</body></html>";
                    }
                    if (INSERT_MATERIAL != "")
                    {
                        string[] arr = INSERT_MATERIAL.Split(",".ToCharArray());
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (arr[i].ToString() != " " || arr[i].ToString() != "")
                            {
                                if (mat_spl_nm == "")
                                {
                                //    attachlink = "<BR><a href=\"" + attachurl + "?xab=" + arr[i].ToString() + "\">Attachment " + (i + 1) + "</a>";
                                    mat_spl_nm = insert_mat_attachurl + "?xab=" + arr[i].ToString().Replace(" ", "~~");
                                }
                                else
                                {
                                  //  attachlink = attachlink + "<BR><a href=\"" + attachurl + "?xab=" + arr[i].ToString() + "\">Attachment " + (i + 1) + "</a>";
                                    mat_spl_nm = mat_spl_nm + "\n" + insert_mat_attachurl + "?xab=" + arr[i].ToString().Replace(" ", "~~");
                                }
                            }
                        }
                      //  attachlink = "<html><body>" + attachlink + "</body></html>";
                    }
                    
                    //objdat1.Tables[0].Rows[0].ItemArray[30].ToString();
                    /*MailMessage msgMail = new MailMessage();
                    msgMail.To = "sushil@4cplus.com,shubhamnamdev2233@gmail.com,bhanu@4cplus.com";// mailtoval;
                    msgMail.From = mailfromval;
                    msgMail.BodyFormat = MailFormat.Html;
                    msgMail.Subject = "Regarding Request";
                    msgMail.Body = mailstr + " " + mailbody;
                    SmtpMail.SmtpServer = smtpadd;
                    SmtpMail.Send(msgMail);*/
    /* SmtpClient smtp = new SmtpClient();
     smtp.Port = 25;
     smtp.Host = "203.197.142.35";
     smtp.Credentials = new NetworkCredential("adsonline", "advtupload");
     MailMessage email_msg = new MailMessage();

     MailMessage t_email_msg = new MailMessage();
     if (AGENCYEMAILID != "")
     {
         email_msg.To.Add(mailtoval + "," + AGENCYEMAILID + ",bhattijs18@gmail.com" + ",sourabhsharma0701@gmail.com");//("karthick@newindianexpress.com,swamy@newindianexpress.com");
     }
     else
     {
         //email_msg.To.Add(mailtoval);
         email_msg.To.Add(mailtoval  + ",bhattijs18@gmail.com" + ",sourabhsharma0701@gmail.com");//("karthick@newindianexpress.com,swamy@newindianexpress.com");
     }
     string t_fmailid = "bhattijs18@gmail.com" + "," + "sourabhsharma0701@gmail.com" + "," + USEREMAIL;
     if (t_agency != "")
     {
         t_email_msg.To.Add(t_fmailid);
         t_email_msg.From = new MailAddress(USEREMAIL);
         t_email_msg.Subject = "New Agency Request, For Booking No :" + cioid;
         t_email_msg.Body = t_mailbody;
         t_email_msg.IsBodyHtml = false;
                    
     }
     email_msg.From = new MailAddress(USEREMAIL);
     email_msg.Subject = "SBNo.:-" + cioid + "  And RO No:- " + ro_no + "  "+(INSERT_STATUS).ToUpper() + "  For The Agency :-" + agencyname + "  And Client :-" + clientname + "By :-" + BOOKED_BY;
     //email_msg.Body = mailstr + " " + mailbody;
 string status_canceled;
 status_canceled= "Following Ad Has been cancelled";
 status_canceled =  status_canceled;
 if (attachlink != "" && mat_spl_nm !="")
     {
         if (INSERT_STATUS != "cancel")
         {
             email_msg.Body = mailbody + "\n\n\n\n" + "Click Here To Download:-" + "\n" + attachlink + "\n\n\n\n" + "Click Here To Download Matterial:-" + "\n" + mat_spl_nm;
                            
         }
         else
         {
             email_msg.Body = mailbody + "\n\n\n\n" + "Booking Status:-" + status_canceled + "\n\n\n\n" + "Click Here To Download:-" + "\n" + attachlink + "\n\n\n\n" + "Click Here To Download Matterial:-" + "\n" + mat_spl_nm;
         }
                        
     }
 else if (attachlink != "")
 {
     if (INSERT_STATUS != "cancel")
     {
         email_msg.Body = mailbody + "\n\n\n\n" + "Click Here To Download:-" + "\n" + attachlink;// + "\n\n\n\n" + "Click Here To Download Matterial:-" + "\n" + mat_spl_nm;

     }
     else
     {
         email_msg.Body = mailbody + "\n\n\n\n" + "Booking Status:-" + status_canceled + "\n\n\n\n" + "Click Here To Download:-" + "\n" + attachlink; //+ "\n\n\n\n" + "Click Here To Download Matterial:-" + "\n" + mat_spl_nm;
     }
 }
 else if (mat_spl_nm != "")
 {
     if (INSERT_STATUS != "cancel")
     {
         email_msg.Body = mailbody + "\n\n\n\n" + "Click Here To Download Matterial:-" + "\n" + mat_spl_nm;

     }
     else
     {
         email_msg.Body = mailbody + "\n\n\n\n" + "Booking Status:-" + status_canceled + "\n\n\n\n" + "Click Here To Download Matterial:-" + "\n" + mat_spl_nm;
     }
 }
 else
 {
     if (INSERT_STATUS != "cancel")
     {
         email_msg.Body = mailbody;
     }
     else
     {
         email_msg.Body = mailbody + "\n\n\n\n" + "Booking Status:-" + status_canceled;
     }
     //email_msg.Body = mailbody;
 }
                    
     email_msg.IsBodyHtml = false;
     smtp.Send(email_msg);
     if (t_agency != "")
     {
         smtp.Send(t_email_msg);
     }
 //}
}
}
catch (Exception e)
{
err = e.Message;

}*/
    /*string data = cioid;//"insertdate:" + insertdate + "edition:" + edition + "premium1:" + premium1 + "premium2:" + premium2 + "premallow:" + premallow + "adcategory:" + adcategory + "latestdate:" + latestdate + "material:" + material + "cardrate:" + cardrate + "filename:" + filename + "discrate:" + discrate + "insertstatus:" + insertstatus + "billstatus:" + billstatus + "adsubcat:" + adsubcat + "compcode:" + compcode + "userid:" + userid + "cioid:" + cioid + "height:" + height + "width:" + width + "totalsize:" + totalsize + "pagepost:" + pagepost + "premper1:" + premper1 + "premper2:" + premper2 + "colid:" + colid + "repeat:" + repeat + "insertno:" + insertno + "paid:" + paid + "insertinsertion:" + insertinsertion + "solorate:" + solorate + "grossrate:" + grossrate + "insert_pageno:" + insert_pageno + "insert_remarks:" + insert_remarks + "page_code:" + page_code + "page_per:" + page_per + "noofcol:" + noofcol + "billamt:" + billamt + "billrate:" + billrate + "logo_h:" + "0" + "logo_w:" + "0" + "logo_name:" + "0" + "dateformat:" + dateformat + "0" + "0" + "0" + "pkgcode:" + pkgcode + "gridins:" + gridins + "pkgalias:" + pkgalias + "cirvts:" + cirvts + "cirpub:" + cirpub + "ciredi:" + ciredi + "cirrate:" + cirrate + "cirdate:" + cirdate + "ciragency:" + ciragency + "ciragencysubcode:" + ciragencysubcode + "center:" + center + "branch:" + branch;
    if (err != "")
        err = err + " ERROR: " + data;
    string adcatcode2 = "Mail Display Booking " + cioid;
    clsconnection dconnect = new clsconnection();
    string sqldd = "insert into log_new(DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP)  values($date,'" + compcode + "','Display Mail Ad Booking','" + err.Replace("'", "''") + "','Ad Booking  Saved','" + adcatcode2;
    sqldd = sqldd + "',";
    sqldd = sqldd + "'" + Request.ServerVariables["REMOTE_ADDR"].ToString() + "')";
    dconnect.executenonquery1(sqldd);
    return err;*/
    //  return err;
    //}


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindclientnamefromadd(string compcode, string userid, string client, string clientaddress)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, userid, client, clientaddress, Session["revenue"].ToString(), "", "" };
        string procedureName = "bindclientbyadd";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CommonClass sms = new NewAdbooking.Classes.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet abc_get_unit_allocation(string comp_code, string unit_code, string subedtncode, string extra1, string pextra2, string extra3)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { comp_code, unit_code, subedtncode, extra1, pextra2, extra3 };
        string procedureName = "abc_get_unit_allocation";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CommonClass sms = new NewAdbooking.Classes.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindpackagerevcentwise(string compcode, string addtype, string revcent)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, addtype, "", "" };
        string procedureName = "bindpackageActive_bindpackageActive_p";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                ds = bindopackage.packagebindActive_DJ(Session["compcode"].ToString(), hiddenadtype.Value, hiddenuserid.Value, Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString());

            }
            else
            {
                NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();
                ds = bindopackage.packagebindActive(Session["compcode"].ToString(), hiddenadtype.Value);
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();
            ds = bindopackage.packagebind(Session["compcode"].ToString(), hiddenadtype.Value);
        }
        else
        {
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet gettempBookingIdNo1(string compcode, string auto, string nam, string quotation, string adtype, string systemdate, string savedata, string dateformate, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster autocode = new NewAdbooking.Classes.BookingMaster();
            da = autocode.autogenratedtempidnam(compcode, auto, nam, quotation, adtype, systemdate, savedata, dateformate, extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster autocode = new NewAdbooking.classesoracle.BookingMaster();
            da = autocode.autogenratedtempidnam(compcode, auto, nam, quotation, adtype, systemdate, savedata, dateformate, extra1, extra2, extra3, extra4, extra5);

        }
        return da;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindExec_agency(string compcode, string adtype, string agmaincode, string agsubcode, string code_subcode, string execname, string extra1, string extra2, string extra3, string extra4, string extra5, string extra6, string extra7, string extra8, string extra9, string extra10)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds = clsbooking.getExecbooking_agency(compcode, adtype, agmaincode, agsubcode, code_subcode, execname, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
            ds = clsbooking.getExecbooking_agency(compcode, adtype, agmaincode, agsubcode, code_subcode, execname, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public void gettemp_agcode()
    {
        hdntempagcode.Value = Session["TEMP_AGENCYRATECODE"].ToString();

    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindpublication_formail()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        string procedureName = "an_publication_an_bind_edition_p";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CommonClass sms = new NewAdbooking.Classes.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }



    [Ajax.AjaxMethod]
    public DataSet bindpackagemaingrp(string compcode, string maingrpcode, string maingrpname, string extra1, string extra2)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, maingrpcode, maingrpname, extra1, extra2 };
        string procedureName = "adv_combin_main_group_bind";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CommonClass sms = new NewAdbooking.Classes.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster mainpack = new NewAdbooking.classmysql.BookingMaster();
            ds = mainpack.bindpackagemaingrp(compcode, maingrpcode, maingrpname, extra1, extra2);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet bindpackagesubgrp(string compcode, string maingrpcode,string varpacksubgrpc, string subgrpname, string extra1, string extra2)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, maingrpcode, varpacksubgrpc, subgrpname, extra1, extra2 };
        string procedureName = "adv_combin_sub_group_bind";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CommonClass sms = new NewAdbooking.Classes.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster mainpack = new NewAdbooking.classmysql.BookingMaster();
            ds = mainpack.bindpackagesubgrp(compcode, maingrpcode, varpacksubgrpc, subgrpname, extra1, extra2);
        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet bindpackagegroup(string compcode, string adtype, string extra1, string extra2, string varpackmaingrp, string varpacksubgrp)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();
            ds = bindopackage.packagebind(Session["compcode"].ToString(), hiddenadtype.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                ds = bindopackage.packagebindActive_DJ(Session["compcode"].ToString(), hiddenadtype.Value, hiddenuserid.Value, Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString());
            }
            else
            {
                NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();
                ds = bindopackage.packagebindActive(Session["compcode"].ToString(), hiddenadtype.Value);
            }
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster Show_NoAd = new NewAdbooking.classmysql.BookingMaster();
            ds = Show_NoAd.packagebindbookinggroup(compcode, adtype, extra1, extra2, varpackmaingrp, varpacksubgrp);
        }

        /*drppackage.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Package";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppackage.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drppackage.Items.Add(li);
            }

        }*/
        return ds;

    }




}

