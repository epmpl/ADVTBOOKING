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
using System.Security.Cryptography;
public partial class loginsession : System.Web.UI.Page
{
    const string passphrase = "password";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        string flag = "0";
        string username = Request.QueryString["username"].ToString();
        string password = Request.QueryString["password"].ToString();
        string qbc = Request.QueryString["qbc"].ToString();
        string agency_name = Request.QueryString["agency_name"].ToString();
        string center = Request.QueryString["center"].ToString();
        string centername = "";
        if (Request.QueryString["centername"] != null)
        {
            centername = Request.QueryString["centername"].ToString();
        }

        Session["agency_name"] = agency_name;
        Session["center"] = center;
        DataSet ds = new DataSet();
        DataSet dslicense = new DataSet();
        if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
        {
            Session["CENTERDJ"] = Request.QueryString["centerdj"].ToString();
            Session["LOGINDJ"] = Request.QueryString["logint"].ToString();
            Session["PUBLICATIONDJ"] = Request.QueryString["publication"].ToString();
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();
            string pwddecrypt = EncryptData(password);
            ds = logindetail.chklogin(username, pwddecrypt, qbc);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = "1";
                    if (ConfigurationSettings.AppSettings["EXPIREPWD"].ToString() == "1")
                    {
                        if (ds.Tables[0].Rows[0]["diff"] != null)
                        {
                            int day = Convert.ToInt32(ds.Tables[0].Rows[0]["diff"]);
                            if (day > 15)
                            {
                                flag = "2";
                            }
                        }
                    }
                    DataSet dslice1 = new DataSet();
                    dslice1 = logindetail.fetchKey(ds.Tables[0].Rows[0].ItemArray[4].ToString());
                    string keyno = DecryptString(dslice1.Tables[0].Rows[0].ItemArray[0].ToString());
                    dslicense = logindetail.fetchLicenseKeyDate(ds.Tables[0].Rows[0].ItemArray[4].ToString(), keyno);
                    if (dslicense.Tables.Count > 0 && dslicense.Tables[0].Rows.Count > 0 && dslicense.Tables[0].Rows[0].ItemArray[1].ToString() != "X")
                    {
                        int diff = Convert.ToInt32(dslicense.Tables[0].Rows[0].ItemArray[0]);
                        if (diff <= 10)
                        {
                            flag = "5" + "~" + dslicense.Tables[0].Rows[0].ItemArray[1].ToString() + "~" + diff.ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[2].ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[3].ToString();
                        }
                    }
                    else if (dslicense.Tables.Count > 0 && dslicense.Tables[0].Rows.Count > 0 && dslicense.Tables[0].Rows[0].ItemArray[2].ToString() != "")
                    {
                        flag = "5" + "~" + dslicense.Tables[0].Rows[0].ItemArray[1].ToString() + "~" + "" + "~" + dslicense.Tables[0].Rows[0].ItemArray[2].ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[3].ToString();
                    }
                    else if (dslicense.Tables[0].Rows[0].ItemArray[1].ToString() == "X")
                    {
                        flag = "5" + "~" + dslicense.Tables[0].Rows[0].ItemArray[1].ToString() + "~" + "" + "~" + dslicense.Tables[0].Rows[0].ItemArray[2].ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[3].ToString();
                    }
                    if (dslicense.Tables.Count > 0 && dslicense.Tables[0].Rows.Count > 0 && dslicense.Tables[0].Rows[0].ItemArray[1].ToString() != "X" && dslicense.Tables[0].Rows[0].ItemArray[3].ToString() == "FALSE" && flag == "1")
                    {
                        flag = "5" + "~" + dslicense.Tables[0].Rows[0].ItemArray[1].ToString() + "~" + "" + "~" + dslicense.Tables[0].Rows[0].ItemArray[2].ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[3].ToString();
                    }
                    Session["ALLOW_FOLLOW_DT_BOOOK"] = ds.Tables[1].Rows[0]["ALLOW_FOLLOW_DT_BOOOK"].ToString();
                    Session["DispAuditBooking"] = ds.Tables[1].Rows[0]["DISP_AUDITBKG"].ToString();
                    Session["revenue"] = ds.Tables[0].Rows[0]["RETAINER"].ToString();
                    Session["centername"] = centername;
                    /*new change ankur 18 feb*/
                    Session["SCHEME_TYPE"] = ds.Tables[1].Rows[0]["SCHEME_TYPE"].ToString();
                    Session["comp_name"] = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                    Session["Username"] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    Session["userid"] = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                    Session["compcode"] = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                    Session["dateformat"] = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                    Session["autogenerated"] = ds.Tables[1].Rows[0].ItemArray[1].ToString();
                    Session["currency"] = ds.Tables[1].Rows[0].ItemArray[2].ToString();
                    Session["ratecode"] = ds.Tables[1].Rows[0].ItemArray[0].ToString();
                    Session["solorate"] = ds.Tables[1].Rows[0].ItemArray[4].ToString();
                    Session["decimal"] = ds.Tables[1].Rows[0].ItemArray[5].ToString();
                    Session["breakup"] = ds.Tables[1].Rows[0].ItemArray[6].ToString();
                    Session["bwcode"] = ds.Tables[1].Rows[0].ItemArray[7].ToString();
                    Session["uom"] = ds.Tables[1].Rows[0].ItemArray[8].ToString();
                    Session["rostatus"] = ds.Tables[1].Rows[0].ItemArray[9].ToString();
                    Session["tfn"] = ds.Tables[1].Rows[0].ItemArray[10].ToString();
                    Session["insertsbreakup"] = ds.Tables[1].Rows[0].ItemArray[11].ToString();
                    Session["premtype"] = ds.Tables[1].Rows[0].ItemArray[12].ToString();
                    Session["dealtype"] = ds.Tables[1].Rows[0].ItemArray[13].ToString();
                    Session["prefix"] = ds.Tables[1].Rows[0].ItemArray[14].ToString();
                    Session["suffix"] = ds.Tables[1].Rows[0].ItemArray[15].ToString();
                    Session["financestatus"] = ds.Tables[1].Rows[0].ItemArray[16].ToString();
                    Session["voucherst"] = ds.Tables[1].Rows[0].ItemArray[17].ToString();
                    Session["roadcat"] = ds.Tables[1].Rows[0].ItemArray[18].ToString();
                    Session["rodatetime"] = ds.Tables[1].Rows[0].ItemArray[19].ToString();
                    Session["spacearea"] = ds.Tables[1].Rows[0].ItemArray[20].ToString();
                    Session["vat"] = ds.Tables[1].Rows[0].ItemArray[21].ToString();
                    Session["bookstat"] = ds.Tables[1].Rows[0].ItemArray[22].ToString();
                    Session["cioid"] = ds.Tables[1].Rows[0].ItemArray[23].ToString();
                    Session["Receipt_no"] = ds.Tables[1].Rows[0].ItemArray[24].ToString();
                    /*new change ankur*/
                    Session["bg_colorpub"] = ds.Tables[1].Rows[0].ItemArray[25].ToString();
                    Session["validdate_pub"] = ds.Tables[1].Rows[0].ItemArray[26].ToString();
                    //////////////////
                    Session["userhome"] = ds.Tables[2].Rows[0].ItemArray[0].ToString();
                    Session["Admin"] = ds.Tables[2].Rows[0].ItemArray[1].ToString();
                    /*new change ankur for agency*/
                    Session["agencyratecode"] = ds.Tables[1].Rows[0].ItemArray[27].ToString();
                    Session["audit"] = ds.Tables[1].Rows[0].ItemArray[28].ToString();
                    Session["rateradio"] = ds.Tables[1].Rows[0]["rate_company_agency"].ToString();
                    Session["RATE_CHECK"] = ds.Tables[1].Rows[0]["RATE_CHECK"].ToString();
                    Session["ratepremtype"] = ds.Tables[1].Rows[0]["DAYRATE"].ToString();
                    Session["addAgencyComm"] = ds.Tables[1].Rows[0].ItemArray[32].ToString();
                    Session["addAgencyComm_Ret"] = ds.Tables[1].Rows[0].ItemArray[33].ToString();

                    Session["DISP_CLSBILL"] = ds.Tables[1].Rows[0]["DISP_CLSBILL"].ToString();

                    Session["DISP_CASHBILL"] = ds.Tables[1].Rows[0]["DISP_CASHBILL"].ToString();
                    Session["CLA_CASHBILL"] = ds.Tables[1].Rows[0]["CLA_CASHBILL"].ToString();
                    Session["USERDISCOUNT"] = ds.Tables[0].Rows[0]["DISCOUNT"].ToString();
                    Session["RECEIPT_FORMAT"] = ds.Tables[1].Rows[0]["RECEIPT_FORMAT"].ToString();
                    Session["CASH_RECEIPT_BILL"] = ds.Tables[1].Rows[0]["CASH_RECEIPT_BILL"].ToString();


                    Session["BILL_ORDERWSLAST"] = ds.Tables[1].Rows[0]["BILL_ORDERWSLAST"].ToString();
                    Session["FLOOR_CHK"] = ds.Tables[1].Rows[0]["FLOOR_CHK"].ToString();
                    Session["FILTER"] = ds.Tables[0].Rows[0]["FILTER"].ToString();
                    Session["ROLEID"] = ds.Tables[0].Rows[0]["ROLEID"].ToString();
                    Session["ROKEYCHECK"] = ds.Tables[1].Rows[0]["ROKEYCHECK"].ToString();
                    Session["rate_audit"] = ds.Tables[1].Rows[0]["rate_audit"].ToString();
                    Session["clsbilltype"] = ds.Tables[1].Rows[0]["CLS_BILLTYPE"].ToString();
                    Session["displaybilltype"] = ds.Tables[1].Rows[0]["DIS_BILLTYPE"].ToString();
                    Session["ALL_PACKAGE"] = ds.Tables[1].Rows[0]["ALL_PACKAGE"].ToString();
                    Session["RATE_AUDIT_PREF"] = ds.Tables[1].Rows[0]["RATE_AUDIT_PREF"].ToString();
                    Session["CHECKRODUPLICACY"] = ds.Tables[1].Rows[0]["CHECKRODUPLICACY"].ToString();

                    //new add for receipt entry
                    Session["allowPDC"] = ds.Tables[1].Rows[0]["PDC_DAY"].ToString();
                    Session["allowBarcode"] = "NO";
                    Session["backDayRecpt"] = ds.Tables[1].Rows[0]["BACK_DATE_RCPT"].ToString();
                    Session["FA_LEDGER_ALLOW"] = ds.Tables[1].Rows[0]["FA_LEDGER_ALLOW"].ToString();
                    Session["CLEARANCE_TYPE_ALLOW"] = ds.Tables[1].Rows[0]["CLEARANCE_TYPE_ALLOW"].ToString();
                    Session["ROLEID"] = ds.Tables[0].Rows[0]["ROLEID"].ToString();

                    if (qbc == "")
                    {
                    }
                    else
                    {

                        Session["FINANCE_CADE"] = ds.Tables[1].Rows[0]["FINANCE_CADE"].ToString();
                    }

                    if (center == "0")
                    {
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {
                            DataSet dsC = new DataSet();
                            dsC = logindetail.getCenter(Session["compcode"].ToString(), ds.Tables[0].Rows[0]["RETAINER"].ToString());// agency_name);
                            if (dsC.Tables[0].Rows.Count > 0)
                            {
                                center = dsC.Tables[0].Rows[0].ItemArray[0].ToString();
                                Session["center"] = center;
                                Session["centerAdd"] = dsC.Tables[0].Rows[0].ItemArray[1].ToString();
                            }
                        }

                    }
                }
                else
                {
                    flag = "0";
                }
            }
            else
            {
                flag = "0";
            }
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
                string pwddecrypt = EncryptData(password);
                //pwddecrypt = password;
                ds = logindetail.chklogin(username, pwddecrypt, qbc);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = "1";
                    if (ConfigurationSettings.AppSettings["EXPIREPWD"].ToString() == "1")
                    {
                        if (ds.Tables[0].Rows[0]["diff"] != null)
                        {
                            int day = Convert.ToInt32(ds.Tables[0].Rows[0]["diff"]);
                            if (day > 15)
                            {
                                flag = "2";
                            }
                        }
                    }
                    DataSet dslice1 = new DataSet();
                    dslice1 = logindetail.fetchKey(ds.Tables[0].Rows[0].ItemArray[4].ToString());
                    string keyno = DecryptString(dslice1.Tables[0].Rows[0].ItemArray[0].ToString());
                    dslicense = logindetail.fetchLicenseKeyDate(ds.Tables[0].Rows[0].ItemArray[4].ToString(), keyno);
                    if (dslicense.Tables.Count > 0 && dslicense.Tables[0].Rows.Count > 0 && dslicense.Tables[0].Rows[0].ItemArray[1].ToString() != "X")
                    {
                        int diff = Convert.ToInt32(dslicense.Tables[0].Rows[0].ItemArray[0]);
                        if (diff <= 10)
                        {
                            flag = "5" + "~" + dslicense.Tables[0].Rows[0].ItemArray[1].ToString() + "~" + diff.ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[2].ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[3].ToString();
                        }
                    }
                    else if (dslicense.Tables.Count > 0 && dslicense.Tables[0].Rows.Count > 0 && dslicense.Tables[0].Rows[0].ItemArray[2].ToString() != "")
                    {
                        flag = "5" + "~" + dslicense.Tables[0].Rows[0].ItemArray[1].ToString() + "~" + "" + "~" + dslicense.Tables[0].Rows[0].ItemArray[2].ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[3].ToString();
                    }
                    else if (dslicense.Tables[0].Rows[0].ItemArray[1].ToString() == "X")
                    {
                        flag = "5" + "~" + dslicense.Tables[0].Rows[0].ItemArray[1].ToString() + "~" + "" + "~" + dslicense.Tables[0].Rows[0].ItemArray[2].ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[3].ToString();
                    }
                    if (dslicense.Tables.Count > 0 && dslicense.Tables[0].Rows.Count > 0 && dslicense.Tables[0].Rows[0].ItemArray[1].ToString() != "X" && dslicense.Tables[0].Rows[0].ItemArray[3].ToString() == "FALSE" && flag=="1")
                    {
                        flag = "5" + "~" + dslicense.Tables[0].Rows[0].ItemArray[1].ToString() + "~" + "" + "~" + dslicense.Tables[0].Rows[0].ItemArray[2].ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[3].ToString();
                    }
                    Session["ALLOW_FOLLOW_DT_BOOOK"] = ds.Tables[1].Rows[0]["ALLOW_FOLLOW_DT_BOOOK"].ToString();
                    Session["DispAuditBooking"] = ds.Tables[1].Rows[0]["DISP_AUDITBKG"].ToString();
                    Session["revenue"] = ds.Tables[0].Rows[0]["RETAINER"].ToString();
                    Session["centername"] = centername;
                    Session["comp_name"] = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                    Session["Username"] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    Session["userid"] = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                    Session["compcode"] = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                    Session["dateformat"] = ds.Tables[1].Rows[0].ItemArray[3].ToString();
                    Session["autogenerated"] = ds.Tables[1].Rows[0].ItemArray[1].ToString();
                    Session["currency"] = ds.Tables[1].Rows[0].ItemArray[2].ToString();
                    Session["ratecode"] = ds.Tables[1].Rows[0].ItemArray[0].ToString();
                    Session["solorate"] = ds.Tables[1].Rows[0].ItemArray[4].ToString();
                    Session["decimal"] = ds.Tables[1].Rows[0].ItemArray[5].ToString();
                    Session["breakup"] = ds.Tables[1].Rows[0].ItemArray[6].ToString();
                    Session["bwcode"] = ds.Tables[1].Rows[0].ItemArray[7].ToString();
                    Session["uom"] = ds.Tables[1].Rows[0].ItemArray[8].ToString();
                    Session["rostatus"] = ds.Tables[1].Rows[0].ItemArray[9].ToString();
                    Session["tfn"] = ds.Tables[1].Rows[0].ItemArray[10].ToString();
                    Session["insertsbreakup"] = ds.Tables[1].Rows[0].ItemArray[11].ToString();
                    Session["premtype"] = ds.Tables[1].Rows[0].ItemArray[12].ToString();
                    Session["dealtype"] = ds.Tables[1].Rows[0].ItemArray[13].ToString();
                    Session["prefix"] = ds.Tables[1].Rows[0].ItemArray[14].ToString();
                    Session["suffix"] = ds.Tables[1].Rows[0].ItemArray[15].ToString();
                    Session["financestatus"] = ds.Tables[1].Rows[0].ItemArray[16].ToString();
                    Session["voucherst"] = ds.Tables[1].Rows[0].ItemArray[17].ToString();
                    Session["roadcat"] = ds.Tables[1].Rows[0].ItemArray[18].ToString();
                    Session["rodatetime"] = ds.Tables[1].Rows[0].ItemArray[19].ToString();
                    Session["spacearea"] = ds.Tables[1].Rows[0].ItemArray[20].ToString();
                    Session["vat"] = ds.Tables[1].Rows[0].ItemArray[21].ToString();
                    Session["bookstat"] = ds.Tables[1].Rows[0].ItemArray[22].ToString();
                    Session["cioid"] = ds.Tables[1].Rows[0].ItemArray[23].ToString();
                    Session["Receipt_no"] = ds.Tables[1].Rows[0].ItemArray[24].ToString();
                    Session["userhome"] = ds.Tables[2].Rows[0].ItemArray[0].ToString();
                    Session["Admin"] = ds.Tables[2].Rows[0].ItemArray[1].ToString();
                    Session["bg_colorpub"] = ds.Tables[1].Rows[0].ItemArray[25].ToString();
                    Session["validdate_pub"] = ds.Tables[1].Rows[0].ItemArray[26].ToString();
                    /*new change ankur for agency*/
                    Session["agencyratecode"] = ds.Tables[1].Rows[0].ItemArray[27].ToString();

                    Session["audit"] = ds.Tables[1].Rows[0].ItemArray[28].ToString();
                    Session["copyrate"] = ds.Tables[1].Rows[0].ItemArray[29].ToString();

                    Session["rateradio"] = ds.Tables[1].Rows[0].ItemArray[30].ToString();
                    Session["editionsubrate"] = ds.Tables[1].Rows[0].ItemArray[31].ToString();
                    Session["addAgencyComm"] = ds.Tables[1].Rows[0].ItemArray[32].ToString();
                    Session["addAgencyComm_Ret"] = ds.Tables[1].Rows[0].ItemArray[33].ToString();
                    Session["rate_audit"] = ds.Tables[1].Rows[0]["rate_audit"].ToString();
                    Session["invoice_no"] = ds.Tables[1].Rows[0]["invoice_no"].ToString();
                    Session["clsbilltype"] = ds.Tables[1].Rows[0]["CLS_BILLTYPE"].ToString();
                    Session["displaybilltype"] = ds.Tables[1].Rows[0]["DIS_BILLTYPE"].ToString();
                    Session["RATE_CHECK"] = ds.Tables[1].Rows[0]["RATE_CHECK"].ToString();
                    Session["ALL_PACKAGE"] = ds.Tables[1].Rows[0]["ALL_PACKAGE"].ToString();
                    Session["BILLING_FORMAT"] = ds.Tables[1].Rows[0]["BILLING_FORMAT"].ToString();
                    Session["ratepremtype"] = ds.Tables[1].Rows[0]["DAYRATE"].ToString();
                    Session["SCHEME_TYPE"] = ds.Tables[1].Rows[0]["SCHEME_TYPE"].ToString();
                    Session["DISP_CLSBILL"] = ds.Tables[1].Rows[0]["DISP_CLSBILL"].ToString();
                    Session["DISP_CASHBILL"] = ds.Tables[1].Rows[0]["DISP_CASHBILL"].ToString();
                    Session["CLA_CASHBILL"] = ds.Tables[1].Rows[0]["CLA_CASHBILL"].ToString();
                    Session["USERDISCOUNT"] = ds.Tables[0].Rows[0]["DISCOUNT"].ToString();
                    Session["RECEIPT_FORMAT"] = ds.Tables[1].Rows[0]["RECEIPT_FORMAT"].ToString();
                    Session["CASH_RECEIPT_BILL"] = ds.Tables[1].Rows[0]["CASH_RECEIPT_BILL"].ToString();
                    Session["CHECKRODUPLICACY"] = ds.Tables[1].Rows[0]["CHECKRODUPLICACY"].ToString();

                    Session["BILL_ORDERWSLAST"] = ds.Tables[1].Rows[0]["BILL_ORDERWSLAST"].ToString();
                    Session["FLOOR_CHK"] = ds.Tables[1].Rows[0]["FLOOR_CHK"].ToString();
                    Session["FILTER"] = ds.Tables[0].Rows[0]["FILTER"].ToString();
                    Session["ROLEID"] = ds.Tables[0].Rows[0]["ROLEID"].ToString();
                    Session["ROKEYCHECK"] = ds.Tables[1].Rows[0]["ROKEYCHECK"].ToString();
                    Session["RATE_AUDIT_PREF"] = ds.Tables[1].Rows[0]["RATE_AUDIT_PREF"].ToString();

                    Session["FINANCE_CADE"] = ds.Tables[1].Rows[0]["FINANCE_CADE"].ToString();

                    if (qbc != "" && qbc != null)
                    {
                        //new add for receipt entry
                        Session["allowPDC"] = ds.Tables[1].Rows[0]["PDC_DAY"].ToString();
                        Session["allowBarcode"] = "NO";
                        Session["backDayRecpt"] = ds.Tables[1].Rows[0]["BACK_DATE_RCPT"].ToString();
                        Session["FA_LEDGER_ALLOW"] = ds.Tables[1].Rows[0]["FA_LEDGER_ALLOW"].ToString();
                        Session["CLEARANCE_TYPE_ALLOW"] = ds.Tables[1].Rows[0]["CLEARANCE_TYPE_ALLOW"].ToString();
                        Session["ROLEID"] = ds.Tables[0].Rows[0]["ROLEID"].ToString();
                    }

                    if (center == "0")
                    {
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            DataSet dsC = new DataSet();
                            dsC = logindetail.getCenter(Session["compcode"].ToString(), ds.Tables[0].Rows[0]["RETAINER"].ToString());// agency_name);
                            if (dsC.Tables[0].Rows.Count > 0)
                            {
                                center = dsC.Tables[0].Rows[0].ItemArray[0].ToString();
                                Session["center"] = center;
                                Session["centerAdd"] = dsC.Tables[0].Rows[0].ItemArray[1].ToString();
                            }
                        }

                    }

                }
                else
                {
                    flag = "0";
                }
            }
            else
            {
                NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
                string pwddecrypt = EncryptData(password);
                ds = logindetail.chklogin(username, pwddecrypt, qbc);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = "1";
                    if (ConfigurationSettings.AppSettings["EXPIREPWD"].ToString() == "1")
                    {
                        if (ds.Tables[0].Rows[0]["diff"] != null)
                        {
                            int day = Convert.ToInt32(ds.Tables[0].Rows[0]["diff"]);
                            if (day > 15)
                            {
                                flag = "2";
                            }
                        }
                    }
                    DataSet dslice1 = new DataSet();
                   // dslice1 = logindetail.fetchKey(ds.Tables[0].Rows[0].ItemArray[4].ToString());
                  //  string keyno = DecryptString(dslice1.Tables[0].Rows[0].ItemArray[0].ToString());
                   // dslicense = logindetail.fetchLicenseKeyDate(ds.Tables[0].Rows[0].ItemArray[4].ToString(), keyno);
                    //if (dslicense.Tables.Count > 0 && dslicense.Tables[0].Rows.Count > 0 && dslicense.Tables[0].Rows[0].ItemArray[1].ToString() != "X")
                    //{
                    //    int diff = Convert.ToInt32(dslicense.Tables[0].Rows[0].ItemArray[0]);
                    //    if (diff <= 10)
                    //    {
                    //        flag = "5" + "~" + dslicense.Tables[0].Rows[0].ItemArray[1].ToString() + "~" + diff.ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[2].ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[3].ToString();
                    //    }
                    //}
                    //else if (dslicense.Tables.Count > 0 && dslicense.Tables[0].Rows.Count > 0 && dslicense.Tables[0].Rows[0].ItemArray[2].ToString() != "")
                    //{
                    //    flag = "5" + "~" + dslicense.Tables[0].Rows[0].ItemArray[1].ToString() + "~" + "" + "~" + dslicense.Tables[0].Rows[0].ItemArray[2].ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[3].ToString();
                    //}
                    //else if (dslicense.Tables[0].Rows[0].ItemArray[1].ToString() == "X")
                    //{
                    //    flag = "5" + "~" + dslicense.Tables[0].Rows[0].ItemArray[1].ToString() + "~" + "" + "~" + dslicense.Tables[0].Rows[0].ItemArray[2].ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[3].ToString();
                    //}
                    //if (dslicense.Tables.Count > 0 && dslicense.Tables[0].Rows.Count > 0 && dslicense.Tables[0].Rows[0].ItemArray[1].ToString() != "X" && dslicense.Tables[0].Rows[0].ItemArray[3].ToString() == "FALSE" && flag == "1")
                    //{
                    //    flag = "5" + "~" + dslicense.Tables[0].Rows[0].ItemArray[1].ToString() + "~" + "" + "~" + dslicense.Tables[0].Rows[0].ItemArray[2].ToString() + "~" + dslicense.Tables[0].Rows[0].ItemArray[3].ToString();
                    //}
                    Session["ALLOW_FOLLOW_DT_BOOOK"] = ds.Tables[1].Rows[0]["ALLOW_FOLLOW_DT_BOOOK"].ToString();
                    Session["DispAuditBooking"] = ds.Tables[1].Rows[0]["DISP_AUDITBKG"].ToString();
                    Session["revenue"] = ds.Tables[0].Rows[0]["RETAINER"].ToString();
                    Session["centername"] = centername;
                    Session["comp_name"] = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                    Session["Username"] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    Session["userid"] = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                    Session["compcode"] = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                    Session["dateformat"] = ds.Tables[1].Rows[0].ItemArray[3].ToString();
                    Session["autogenerated"] = ds.Tables[1].Rows[0].ItemArray[1].ToString();
                    Session["currency"] = ds.Tables[1].Rows[0].ItemArray[2].ToString();
                    Session["ratecode"] = ds.Tables[1].Rows[0].ItemArray[0].ToString();
                    Session["solorate"] = ds.Tables[1].Rows[0].ItemArray[4].ToString();
                    Session["decimal"] = ds.Tables[1].Rows[0].ItemArray[5].ToString();
                    Session["breakup"] = ds.Tables[1].Rows[0].ItemArray[6].ToString();
                    Session["bwcode"] = ds.Tables[1].Rows[0].ItemArray[7].ToString();
                    Session["uom"] = ds.Tables[1].Rows[0].ItemArray[8].ToString();
                    Session["rostatus"] = ds.Tables[1].Rows[0].ItemArray[9].ToString();
                    Session["tfn"] = ds.Tables[1].Rows[0].ItemArray[10].ToString();
                    Session["insertsbreakup"] = ds.Tables[1].Rows[0].ItemArray[11].ToString();
                    Session["premtype"] = ds.Tables[1].Rows[0].ItemArray[12].ToString();
                    Session["dealtype"] = ds.Tables[1].Rows[0].ItemArray[13].ToString();
                    Session["prefix"] = ds.Tables[1].Rows[0].ItemArray[14].ToString();
                    Session["suffix"] = ds.Tables[1].Rows[0].ItemArray[15].ToString();
                    Session["financestatus"] = ds.Tables[1].Rows[0].ItemArray[16].ToString();
                    Session["voucherst"] = ds.Tables[1].Rows[0].ItemArray[17].ToString();
                    Session["roadcat"] = ds.Tables[1].Rows[0].ItemArray[18].ToString();
                    Session["rodatetime"] = ds.Tables[1].Rows[0].ItemArray[19].ToString();
                    Session["spacearea"] = ds.Tables[1].Rows[0].ItemArray[20].ToString();
                    Session["vat"] = ds.Tables[1].Rows[0].ItemArray[21].ToString();
                    Session["bookstat"] = ds.Tables[1].Rows[0].ItemArray[22].ToString();
                    Session["cioid"] = ds.Tables[1].Rows[0].ItemArray[23].ToString();
                    Session["Receipt_no"] = ds.Tables[1].Rows[0].ItemArray[24].ToString();
                    Session["userhome"] = ds.Tables[2].Rows[0].ItemArray[0].ToString();
                    Session["Admin"] = ds.Tables[2].Rows[0].ItemArray[1].ToString();
                    Session["bg_colorpub"] = ds.Tables[1].Rows[0].ItemArray[25].ToString();
                    Session["validdate_pub"] = ds.Tables[1].Rows[0].ItemArray[26].ToString();
                    /*new change ankur for agency*/
                    Session["agencyratecode"] = ds.Tables[1].Rows[0].ItemArray[27].ToString();

                    Session["audit"] = ds.Tables[1].Rows[0].ItemArray[28].ToString();
                    Session["copyrate"] = ds.Tables[1].Rows[0].ItemArray[29].ToString();

                    Session["rateradio"] = ds.Tables[1].Rows[0].ItemArray[30].ToString();
                    Session["editionsubrate"] = ds.Tables[1].Rows[0].ItemArray[31].ToString();
                    Session["addAgencyComm"] = ds.Tables[1].Rows[0].ItemArray[32].ToString();
                    Session["addAgencyComm_Ret"] = ds.Tables[1].Rows[0].ItemArray[33].ToString();
                    Session["rate_audit"] = ds.Tables[1].Rows[0]["rate_audit"].ToString();
                    Session["invoice_no"] = ds.Tables[1].Rows[0]["invoice_no"].ToString();
                    Session["clsbilltype"] = ds.Tables[1].Rows[0]["CLS_BILLTYPE"].ToString();
                    Session["displaybilltype"] = ds.Tables[1].Rows[0]["DIS_BILLTYPE"].ToString();
                    Session["RATE_CHECK"] = ds.Tables[1].Rows[0]["RATE_CHECK"].ToString();
                    Session["ALL_PACKAGE"] = ds.Tables[1].Rows[0]["ALL_PACKAGE"].ToString();
                    Session["BILLING_FORMAT"] = ds.Tables[1].Rows[0]["BILLING_FORMAT"].ToString();
                    Session["ratepremtype"] = ds.Tables[1].Rows[0]["DAYRATE"].ToString();
                    Session["SCHEME_TYPE"] = ds.Tables[1].Rows[0]["SCHEME_TYPE"].ToString();
                    Session["DISP_CLSBILL"] = ds.Tables[1].Rows[0]["DISP_CLSBILL"].ToString();
                    Session["DISP_CASHBILL"] = ds.Tables[1].Rows[0]["DISP_CASHBILL"].ToString();
                    Session["CLA_CASHBILL"] = ds.Tables[1].Rows[0]["CLA_CASHBILL"].ToString();
                    Session["USERDISCOUNT"] = ds.Tables[0].Rows[0]["DISCOUNT"].ToString();
                    Session["RECEIPT_FORMAT"] = ds.Tables[1].Rows[0]["RECEIPT_FORMAT"].ToString();
                    Session["CASH_RECEIPT_BILL"] = ds.Tables[1].Rows[0]["CASH_RECEIPT_BILL"].ToString();
                    Session["CHECKRODUPLICACY"] = ds.Tables[1].Rows[0]["CHECKRODUPLICACY"].ToString();

                    Session["BILL_ORDERWSLAST"] = ds.Tables[1].Rows[0]["BILL_ORDERWSLAST"].ToString();
                    Session["FLOOR_CHK"] = ds.Tables[1].Rows[0]["FLOOR_CHK"].ToString();
                    Session["FILTER"] = ds.Tables[0].Rows[0]["FILTER"].ToString();
                    Session["ROLEID"] = ds.Tables[0].Rows[0]["ROLEID"].ToString();
                    Session["ROKEYCHECK"] = ds.Tables[1].Rows[0]["ROKEYCHECK"].ToString();
                    Session["RATE_AUDIT_PREF"] = ds.Tables[1].Rows[0]["RATE_AUDIT_PREF"].ToString();

                    Session["FINANCE_CADE"] = ds.Tables[1].Rows[0]["FINANCE_CADE"].ToString();

                    if (qbc != "" && qbc != null)
                    {
                        //new add for receipt entry
                        Session["allowPDC"] = ds.Tables[1].Rows[0]["PDC_DAY"].ToString();
                        Session["allowBarcode"] = "NO";
                        Session["backDayRecpt"] = ds.Tables[1].Rows[0]["BACK_DATE_RCPT"].ToString();
                        Session["FA_LEDGER_ALLOW"] = ds.Tables[1].Rows[0]["FA_LEDGER_ALLOW"].ToString();
                        Session["CLEARANCE_TYPE_ALLOW"] = ds.Tables[1].Rows[0]["CLEARANCE_TYPE_ALLOW"].ToString();
                        Session["ROLEID"] = ds.Tables[0].Rows[0]["ROLEID"].ToString();
                    }

                    if (center == "0")
                    {
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            DataSet dsC = new DataSet();
                            dsC = logindetail.getCenter(Session["compcode"].ToString(), ds.Tables[0].Rows[0]["RETAINER"].ToString());// agency_name);
                            if (dsC.Tables[0].Rows.Count > 0)
                            {
                                center = dsC.Tables[0].Rows[0].ItemArray[0].ToString();
                                Session["center"] = center;
                                Session["centerAdd"] = dsC.Tables[0].Rows[0].ItemArray[1].ToString();
                            }
                        }

                    }


                }
                else
                {
                    flag = "0";
                }

            }



        Response.Write(flag);
        try
        {
            string url1 = Request.QueryString["url1"].ToString();
            if (url1 != "")
            {
                url1 = url1.Replace("$D$", "?");
                url1 = url1.Replace("$F$", "&");
                Response.Redirect(url1);

            }
        }
        catch (Exception e1)
        {
            
        }
        Response.End();
    }
    public static string DecryptString(string Message)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;
        byte[] DataToDecrypt = Convert.FromBase64String(Message);
        try
        {
            ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
        }
        finally
        {
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }
        return UTF8.GetString(Results);
    }
    private string EncryptData(string Message)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;
        byte[] DataToEncrypt = UTF8.GetBytes(Message);
        try
        {
            ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
            Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
        }
        finally
        {
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }
        return Convert.ToBase64String(Results);
    }
}
