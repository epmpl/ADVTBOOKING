using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;

/// <summary>
/// Summary description for updateprefer
/// </summary>
namespace NewAdbooking.classesoracle
{

    public class updateprefer : orclconnection
    {
        public updateprefer()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        //********************************To check whether entry for company code exist*****************

        public DataSet datechkprefer(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("wesp_chkdateprefer.wesp_chkdateprefer_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }
        public DataSet dateupdation(string compcode, string userid, string dateformat, string code, string curr, string ratecode, string solo, string breakup, string bwcode, string rostatus, string filename, string tfn, string insertbreak, string prem, string dealtype, string pre, string suff, string chkfinancestatus, string voucherst, string adcode, string rodatetime, string spacearea, string vat, string bookstat, string cio_id, string receipt_no, string uom, string bgcolor, string validdate, string agencyratecode, string audit, string insert_date, string agencycomm, string rateaudit, string billaudit, string billtype, string invoice_no, string copybooking, string ratecomp, string addagencycomm, string agencyretcomm, string subrate, string displaybilltype, string classifiedbilltype, string billformat, string ratechk, string allpkg, string dayrate, string schemetype, string Includeclassi, string receiptformat, string cash_receipt, string bill_orderwiselast, string floor_chk, string Unsoldflag, string Supplystopper, string drpRokeychk, string Agencycomm_seq, string creditreciept, string cashindisplay, string cashinclassified, string rate_audit_pref, string barcoding_allow, string fmgbills, string billed_cashdis, string billed_cashcls, string v_drpbackdate, string dockitbooking, string allowprevbooking, string chkval, string cash_billtypea, string approval, string pckstatus, string cash_disc, string cash_amt, string seperate_cashier, string disp_bill, string clas_bill, string mantimepost, string bkdaypost, string maxterutn, string cir_return, string noofchkbounc, string noofdaychkrec, string retday, string chngsuppord, string max_publishday, string billno_period, string spl_trans_edit, string spl_dis_trans_editable, string mul_pac_sel_trans, string shmon_minword, string tradon_spcrg, string rateauth, string f2day, string rateauditmodify, string bindrevenuecenter, string led_allow, string clear_allow, string repeatday, string premiumedit, string BILL_GENERATION, string PUBLICATION_CENTER, string allow_discount_prem, string scheme_billing, string ALLOW_PDC, string ad_type_for_manul_bill, string RO_OUTSTAND_P, string genrate_agency_code, string dispauditbk, string aotosupply, string Authorization, string UNSOLDAPPROVAL, string UNSOLDPHYSICAL, string INCLUDEUNSOLD, string INCLUDEUNSOLDININSERTIONFEEPROCESS, string UNSOLDONSUPPLYORRECEIVEDDATE, string Agencyunblockapproval, string UnblockApprovalOutsideCreditLimit, string billingpublicationwise, string ALLOW_FOLLOW_DT_BOOOK, string paging, string print, string allowpage, string agency, string region, string subscription_paid_supply_type, string subscription_free_supply_type, string CURRENCY_MEASUREMENT, string drpadddiscount, string cancharges, string entry_type, string ApprovalWith, string Auto_TDS_Credit_Note, string TDS_Reason, string Debit_Account_Head, string credit_Account_Head, string service_tax_credit_note, string Tax_Reason, string Debit_Account_Service_Tax, string Credit_Account_Service_Tax, string Auto_Patrakar_Credit_Note, string Patrakar_Reason, string Debit_Account_Head_For_Patrakar, string Credit_Account_Head_For_Patrakar, string Auto_Bank_Credit_Note, string Bank_Reason, string Debit_Account_Bank, string Credit_Account_Bank, string BARCODE, string WEIGHTCAL, string genration_reciept, string misdata, string allowpremium, string financecode, string executivepub, string executivecreditlimit, string mrv, string ret_after_bank, string fixed_tran_amt, string trade_dis_based, string retcomm, string supplbill, string tdstypename, string tdssecname, string retno, string bankrecorequired, string txtretonoverdue, string txtdoconoverdue, string drpallowbooking, string drpchkfordupreq, string alowwithtro, string commonfrid, string drpreciptno, string drpret_exec, string drpcashrecacc, string daysbook)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("wesp_updatedate.wesp_updatedate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //////////////////////////////////////
                OracleParameter prm222 = new OracleParameter("billformat", OracleType.VarChar, 50);
                prm222.Direction = ParameterDirection.Input;
                prm222.Value = billformat;
                objOraclecommand.Parameters.Add(prm222);

                OracleParameter prm2221 = new OracleParameter("allpkg", OracleType.VarChar, 50);
                prm2221.Direction = ParameterDirection.Input;
                prm2221.Value = allpkg;
                objOraclecommand.Parameters.Add(prm2221);

                OracleParameter prm2222 = new OracleParameter("ratechk", OracleType.VarChar, 50);
                prm2222.Direction = ParameterDirection.Input;
                prm2222.Value = ratechk;
                objOraclecommand.Parameters.Add(prm2222);
                ///////////////////////////////////////

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("RATECODE11", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ratecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateformat;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("code", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = code;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("curr", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = curr;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("solo", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = solo;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("breakup", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = breakup;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("bwcode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = bwcode;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("rostatus", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = rostatus;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("filename", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = filename;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("tfn", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = tfn;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("insertbreak", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = insertbreak;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("prem", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = prem;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("dealtype", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = dealtype;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pre", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = pre;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("suff", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = suff;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("financestatus", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = chkfinancestatus;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("voucherst", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = voucherst;
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("adcode", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = adcode;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("rodatetime", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = rodatetime;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm23 = new OracleParameter("spacearea", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = spacearea;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("vat", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = vat;
                objOraclecommand.Parameters.Add(prm24);


                OracleParameter prm25 = new OracleParameter("bookstat", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = bookstat;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("cio_id", OracleType.VarChar, 50);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = cio_id;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("receipt_no", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = receipt_no;
                objOraclecommand.Parameters.Add(prm27);

                /*new change ankur*/
                OracleParameter prm28 = new OracleParameter("uom", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = uom;
                objOraclecommand.Parameters.Add(prm28);


                OracleParameter prm29 = new OracleParameter("bgcolor", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = bgcolor;
                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("validdate", OracleType.VarChar, 50);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = validdate;
                objOraclecommand.Parameters.Add(prm30);



                OracleParameter prm31 = new OracleParameter("agencyratecode", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = agencyratecode;
                objOraclecommand.Parameters.Add(prm31);


                OracleParameter prm32 = new OracleParameter("AUDIT1", OracleType.VarChar, 50);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = audit;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("book_insert_date", OracleType.VarChar, 50);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = insert_date;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("agencycomm", OracleType.VarChar, 50);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = agencycomm;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("rateaudit", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = rateaudit;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("billaudit", OracleType.VarChar, 50);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = billaudit;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("bill_type", OracleType.VarChar, 50);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = billtype;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("invoice_no1", OracleType.VarChar, 50);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = invoice_no;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("copybooking", OracleType.VarChar, 50);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = copybooking;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("ratecompany", OracleType.VarChar, 50);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = ratecomp;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("addagenycomm", OracleType.VarChar, 50);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = addagencycomm;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("agencycommlinkretainer", OracleType.VarChar, 50);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = agencyretcomm;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("subeditionr", OracleType.VarChar, 50);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = subrate;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm142 = new OracleParameter("classifiedbilltype", OracleType.VarChar, 50);
                prm142.Direction = ParameterDirection.Input;
                prm142.Value = classifiedbilltype;
                objOraclecommand.Parameters.Add(prm142);

                OracleParameter prm143 = new OracleParameter("displaybilltype", OracleType.VarChar, 50);
                prm143.Direction = ParameterDirection.Input;
                prm143.Value = displaybilltype;
                objOraclecommand.Parameters.Add(prm143);

                OracleParameter prm1439 = new OracleParameter("dayrate1", OracleType.VarChar, 10);
                prm1439.Direction = ParameterDirection.Input;
                prm1439.Value = dayrate;
                objOraclecommand.Parameters.Add(prm1439);

                OracleParameter prm1440 = new OracleParameter("schemetype", OracleType.VarChar, 10);
                prm1440.Direction = ParameterDirection.Input;
                prm1440.Value = schemetype;
                objOraclecommand.Parameters.Add(prm1440);


                OracleParameter prm1441 = new OracleParameter("PIncludeclassi", OracleType.VarChar, 50);
                prm1441.Direction = ParameterDirection.Input;
                prm1441.Value = Includeclassi;
                objOraclecommand.Parameters.Add(prm1441);


                OracleParameter prm1442 = new OracleParameter("receiptformat", OracleType.VarChar, 50);
                prm1442.Direction = ParameterDirection.Input;
                prm1442.Value = receiptformat;
                objOraclecommand.Parameters.Add(prm1442);

                OracleParameter prm1443 = new OracleParameter("v_bill_orderwiselast", OracleType.VarChar, 50);
                prm1443.Direction = ParameterDirection.Input;
                prm1443.Value = bill_orderwiselast;
                objOraclecommand.Parameters.Add(prm1443);

                OracleParameter prm1463 = new OracleParameter("v_cash_receipt", OracleType.VarChar, 50);
                prm1463.Direction = ParameterDirection.Input;
                prm1463.Value = cash_receipt;
                objOraclecommand.Parameters.Add(prm1463);

                OracleParameter prm1465 = new OracleParameter("v_floor_chk", OracleType.VarChar, 50);
                prm1465.Direction = ParameterDirection.Input;
                prm1465.Value = floor_chk;
                objOraclecommand.Parameters.Add(prm1465);

                //for circulation

                OracleParameter prm1466 = new OracleParameter("Unsoldflag", OracleType.VarChar, 50);
                prm1466.Direction = ParameterDirection.Input;
                prm1466.Value = Unsoldflag;
                objOraclecommand.Parameters.Add(prm1466);

                OracleParameter prm1467 = new OracleParameter("Supplystopper", OracleType.VarChar, 50);
                prm1467.Direction = ParameterDirection.Input;
                prm1467.Value = Supplystopper;
                objOraclecommand.Parameters.Add(prm1467);

                OracleParameter prm1468 = new OracleParameter("drpRokeychk", OracleType.VarChar, 50);
                prm1468.Direction = ParameterDirection.Input;
                prm1468.Value = drpRokeychk;
                objOraclecommand.Parameters.Add(prm1468);


                OracleParameter prm1469 = new OracleParameter("Agencycomm_seq", OracleType.VarChar, 50);
                prm1469.Direction = ParameterDirection.Input;
                prm1469.Value = Agencycomm_seq;
                objOraclecommand.Parameters.Add(prm1469);

                OracleParameter prm1470 = new OracleParameter("creditreciept", OracleType.VarChar, 50);
                prm1470.Direction = ParameterDirection.Input;
                prm1470.Value = creditreciept;
                objOraclecommand.Parameters.Add(prm1470);



                OracleParameter prm1471 = new OracleParameter("cashindisplay", OracleType.VarChar, 50);
                prm1471.Direction = ParameterDirection.Input;
                prm1471.Value = cashindisplay;
                objOraclecommand.Parameters.Add(prm1471);

                OracleParameter prm1472 = new OracleParameter("cashinclassified", OracleType.VarChar, 50);
                prm1472.Direction = ParameterDirection.Input;
                prm1472.Value = cashinclassified;
                objOraclecommand.Parameters.Add(prm1472);

                OracleParameter prm1473 = new OracleParameter("v_rate_audit_pref", OracleType.VarChar, 50);
                prm1473.Direction = ParameterDirection.Input;
                prm1473.Value = rate_audit_pref;
                objOraclecommand.Parameters.Add(prm1473);



                OracleParameter prm1474 = new OracleParameter("v_barcoding_allow_pref", OracleType.VarChar, 50);
                prm1474.Direction = ParameterDirection.Input;
                prm1474.Value = barcoding_allow;
                objOraclecommand.Parameters.Add(prm1474);


                OracleParameter prm1475 = new OracleParameter("v_fmgbills", OracleType.VarChar, 50);
                prm1475.Direction = ParameterDirection.Input;
                prm1475.Value = fmgbills;
                objOraclecommand.Parameters.Add(prm1475);



                OracleParameter prm1476 = new OracleParameter("v_billed_cashdis", OracleType.VarChar, 50);
                prm1476.Direction = ParameterDirection.Input;
                prm1476.Value = billed_cashdis;
                objOraclecommand.Parameters.Add(prm1476);


                OracleParameter prm1477 = new OracleParameter("v_billed_cashcls", OracleType.VarChar, 50);
                prm1477.Direction = ParameterDirection.Input;
                prm1477.Value = billed_cashcls;
                objOraclecommand.Parameters.Add(prm1477);



                OracleParameter prm1478 = new OracleParameter("v_drpbackdate", OracleType.VarChar, 50);
                prm1478.Direction = ParameterDirection.Input;
                prm1478.Value = v_drpbackdate;
                objOraclecommand.Parameters.Add(prm1478);


                OracleParameter prm1479 = new OracleParameter("dockitbooking", OracleType.VarChar, 50);
                prm1479.Direction = ParameterDirection.Input;
                prm1479.Value = dockitbooking;
                objOraclecommand.Parameters.Add(prm1479);

                OracleParameter prm1480 = new OracleParameter("allowprevbooking", OracleType.VarChar, 50);
                prm1480.Direction = ParameterDirection.Input;
                prm1480.Value = allowprevbooking;
                objOraclecommand.Parameters.Add(prm1480);

                OracleParameter prm1481 = new OracleParameter("chkval", OracleType.VarChar, 50);
                prm1481.Direction = ParameterDirection.Input;
                prm1481.Value = chkval;
                objOraclecommand.Parameters.Add(prm1481);

                OracleParameter prm1482 = new OracleParameter("ro_wisecashbill", OracleType.VarChar, 50);
                prm1482.Direction = ParameterDirection.Input;
                prm1482.Value = cash_billtypea;
                objOraclecommand.Parameters.Add(prm1482);


                OracleParameter prm1483 = new OracleParameter("approval1", OracleType.VarChar, 50);
                prm1483.Direction = ParameterDirection.Input;
                prm1483.Value = approval;
                objOraclecommand.Parameters.Add(prm1483);

                OracleParameter prm1484 = new OracleParameter("pckstatus", OracleType.VarChar, 50);
                prm1484.Direction = ParameterDirection.Input;
                prm1484.Value = pckstatus;
                objOraclecommand.Parameters.Add(prm1484);

                OracleParameter prm1485 = new OracleParameter("cash_disc", OracleType.VarChar, 50);
                prm1485.Direction = ParameterDirection.Input;
                prm1485.Value = cash_disc;
                objOraclecommand.Parameters.Add(prm1485);

                OracleParameter prm1487 = new OracleParameter("cash_amt", OracleType.VarChar, 50);
                prm1487.Direction = ParameterDirection.Input;
                prm1487.Value = cash_amt;
                objOraclecommand.Parameters.Add(prm1487);

                OracleParameter prm1486 = new OracleParameter("seperate_cashier1", OracleType.VarChar, 50);
                prm1486.Direction = ParameterDirection.Input;
                prm1486.Value = seperate_cashier;
                objOraclecommand.Parameters.Add(prm1486);

                OracleParameter prm50 = new OracleParameter("retday", OracleType.VarChar, 50);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = retday;
                objOraclecommand.Parameters.Add(prm50);

                OracleParameter prm51 = new OracleParameter("disp_bill", OracleType.VarChar, 50);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = disp_bill;
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm52 = new OracleParameter("clas_bill", OracleType.VarChar, 50);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = clas_bill;
                objOraclecommand.Parameters.Add(prm52);

                OracleParameter prm53 = new OracleParameter("mantimepost", OracleType.VarChar, 50);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = mantimepost;
                objOraclecommand.Parameters.Add(prm53);

                OracleParameter prm54 = new OracleParameter("bkdaypost", OracleType.VarChar, 50);
                prm54.Direction = ParameterDirection.Input;
                prm54.Value = bkdaypost;
                objOraclecommand.Parameters.Add(prm54);

                OracleParameter prm55 = new OracleParameter("maxterutn", OracleType.VarChar, 50);
                prm55.Direction = ParameterDirection.Input;
                prm55.Value = maxterutn;
                objOraclecommand.Parameters.Add(prm55);

                OracleParameter prm56 = new OracleParameter("cir_return", OracleType.VarChar, 50);
                prm56.Direction = ParameterDirection.Input;
                prm56.Value = cir_return;
                objOraclecommand.Parameters.Add(prm56);

                OracleParameter prm57 = new OracleParameter("noofchkbounc", OracleType.VarChar, 50);
                prm57.Direction = ParameterDirection.Input;
                prm57.Value = noofchkbounc;
                objOraclecommand.Parameters.Add(prm57);

                OracleParameter prm58 = new OracleParameter("noofdaychkrec", OracleType.VarChar, 50);
                prm58.Direction = ParameterDirection.Input;
                prm58.Value = noofdaychkrec;
                objOraclecommand.Parameters.Add(prm58);

                OracleParameter prm59 = new OracleParameter("chngsuppord", OracleType.VarChar, 50);
                prm59.Direction = ParameterDirection.Input;
                prm59.Value = chngsuppord;
                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm60 = new OracleParameter("max_publishday", OracleType.VarChar, 50);
                prm60.Direction = ParameterDirection.Input;
                prm60.Value = max_publishday;
                objOraclecommand.Parameters.Add(prm60);


                OracleParameter prm61 = new OracleParameter("p_billno_period", OracleType.VarChar, 50);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = billno_period;
                objOraclecommand.Parameters.Add(prm61);

                OracleParameter prm62 = new OracleParameter("spl_trans_edit", OracleType.VarChar, 50);
                prm62.Direction = ParameterDirection.Input;
                prm62.Value = spl_trans_edit;
                objOraclecommand.Parameters.Add(prm62);

                OracleParameter prm63 = new OracleParameter("spl_dis_trans_editable", OracleType.VarChar, 50);
                prm63.Direction = ParameterDirection.Input;
                prm63.Value = spl_dis_trans_editable;
                objOraclecommand.Parameters.Add(prm63);

                OracleParameter prm64 = new OracleParameter("mul_pac_sel_trans", OracleType.VarChar, 50);
                prm64.Direction = ParameterDirection.Input;
                prm64.Value = mul_pac_sel_trans;
                objOraclecommand.Parameters.Add(prm64);

                OracleParameter prm65 = new OracleParameter("shmon_minword", OracleType.VarChar, 50);
                prm65.Direction = ParameterDirection.Input;
                prm65.Value = shmon_minword;
                objOraclecommand.Parameters.Add(prm65);

                OracleParameter prm66 = new OracleParameter("tradon_spcrg", OracleType.VarChar, 50);
                prm66.Direction = ParameterDirection.Input;
                prm66.Value = tradon_spcrg;
                objOraclecommand.Parameters.Add(prm66);

                OracleParameter prm67 = new OracleParameter("rateauth", OracleType.VarChar, 50);
                prm67.Direction = ParameterDirection.Input;
                prm67.Value = rateauth;
                objOraclecommand.Parameters.Add(prm67);

                OracleParameter prm68 = new OracleParameter("f2day", OracleType.VarChar, 50);
                prm68.Direction = ParameterDirection.Input;
                prm68.Value = f2day;
                objOraclecommand.Parameters.Add(prm68);

                OracleParameter prm69 = new OracleParameter("rateauditmodify", OracleType.VarChar, 50);
                prm69.Direction = ParameterDirection.Input;
                prm69.Value = rateauditmodify;
                objOraclecommand.Parameters.Add(prm69);

                OracleParameter prm70 = new OracleParameter("bindrevenuecenter", OracleType.VarChar, 50);
                prm70.Direction = ParameterDirection.Input;
                prm70.Value = bindrevenuecenter;
                objOraclecommand.Parameters.Add(prm70);


                OracleParameter prm71 = new OracleParameter("p_led_allow", OracleType.VarChar, 50);
                prm71.Direction = ParameterDirection.Input;
                prm71.Value = led_allow;
                objOraclecommand.Parameters.Add(prm71);


                OracleParameter prm72 = new OracleParameter("p_clear_allow", OracleType.VarChar, 50);
                prm72.Direction = ParameterDirection.Input;
                prm72.Value = clear_allow;
                objOraclecommand.Parameters.Add(prm72);



                OracleParameter prm1487a = new OracleParameter("repeatday", OracleType.VarChar, 50);
                prm1487a.Direction = ParameterDirection.Input;
                prm1487a.Value = repeatday;
                objOraclecommand.Parameters.Add(prm1487a);

                OracleParameter prm1488 = new OracleParameter("premiumedit", OracleType.VarChar, 50);
                prm1488.Direction = ParameterDirection.Input;
                prm1488.Value = premiumedit;
                objOraclecommand.Parameters.Add(prm1488);



                OracleParameter prm73 = new OracleParameter("P_BILL_GENERATION", OracleType.VarChar, 50);
                prm73.Direction = ParameterDirection.Input;
                prm73.Value = BILL_GENERATION;
                objOraclecommand.Parameters.Add(prm73);

                OracleParameter prm74 = new OracleParameter("P_PUBLICATION_CENTER", OracleType.VarChar, 50);
                prm74.Direction = ParameterDirection.Input;
                if (PUBLICATION_CENTER == "0")
                {
                    prm74.Value = System.DBNull.Value;
                }
                else
                {
                    prm74.Value = PUBLICATION_CENTER;
                }
                objOraclecommand.Parameters.Add(prm74);



                OracleParameter prm75 = new OracleParameter("P_allow_discount_prem", OracleType.VarChar, 50);
                prm75.Direction = ParameterDirection.Input;
                prm75.Value = allow_discount_prem;
                objOraclecommand.Parameters.Add(prm75);




                OracleParameter prm76 = new OracleParameter("P_SCHEME_BILLING", OracleType.VarChar, 50);
                prm76.Direction = ParameterDirection.Input;
                prm76.Value = scheme_billing;
                objOraclecommand.Parameters.Add(prm76);




                OracleParameter prm77 = new OracleParameter("P_ALLOW_PDC", OracleType.VarChar, 50);
                prm77.Direction = ParameterDirection.Input;
                prm77.Value = ALLOW_PDC;
                objOraclecommand.Parameters.Add(prm77);



                OracleParameter prm78 = new OracleParameter("PAD_TYPE_FOR_MANUL_BILL", OracleType.VarChar, 50);
                prm78.Direction = ParameterDirection.Input;
                prm78.Value = ad_type_for_manul_bill;
                objOraclecommand.Parameters.Add(prm78);



                OracleParameter prm79 = new OracleParameter("RO_OUTSTAND_P", OracleType.VarChar, 50);
                prm79.Direction = ParameterDirection.Input;
                prm79.Value = RO_OUTSTAND_P;
                objOraclecommand.Parameters.Add(prm79);

                OracleParameter prm80 = new OracleParameter("genrate_agency_code", OracleType.VarChar, 50);
                prm80.Direction = ParameterDirection.Input;
                prm80.Value = genrate_agency_code;
                objOraclecommand.Parameters.Add(prm80);

                OracleParameter prm81 = new OracleParameter("p_dispauditbk", OracleType.VarChar, 50);
                prm81.Direction = ParameterDirection.Input;
                prm81.Value = dispauditbk;
                objOraclecommand.Parameters.Add(prm81);

                OracleParameter prm82 = new OracleParameter("p_aotosupply", OracleType.VarChar, 50);
                prm82.Direction = ParameterDirection.Input;
                prm82.Value = aotosupply;
                objOraclecommand.Parameters.Add(prm82);

                OracleParameter prm83 = new OracleParameter("p_Authorization", OracleType.VarChar, 50);
                prm83.Direction = ParameterDirection.Input;
                prm83.Value = Authorization;
                objOraclecommand.Parameters.Add(prm83);

                OracleParameter prm84 = new OracleParameter("p_CIR_AUTO_APPROVAL_UNSOLD", OracleType.VarChar, 50);
                prm84.Direction = ParameterDirection.Input;
                prm84.Value = UNSOLDAPPROVAL;
                objOraclecommand.Parameters.Add(prm84);

                OracleParameter prm85 = new OracleParameter("p_CIR_AUTO_PHYSICAL_UNSOLD", OracleType.VarChar, 50);
                prm85.Direction = ParameterDirection.Input;
                prm85.Value = UNSOLDPHYSICAL;
                objOraclecommand.Parameters.Add(prm85);

                OracleParameter prm86 = new OracleParameter("p_CIR_UNSOLD_INCLUDE_INCT", OracleType.VarChar, 50);
                prm86.Direction = ParameterDirection.Input;
                prm86.Value = INCLUDEUNSOLD;
                objOraclecommand.Parameters.Add(prm86);

                OracleParameter prm87 = new OracleParameter("p_CIR_UNSOLD_INCLUDE_INSFEE", OracleType.VarChar, 50);
                prm87.Direction = ParameterDirection.Input;
                prm87.Value = INCLUDEUNSOLDININSERTIONFEEPROCESS;
                objOraclecommand.Parameters.Add(prm87);

                OracleParameter prm88 = new OracleParameter("p_CIR_UNSOLD_ON_RECEIVED_DT", OracleType.VarChar, 50);
                prm88.Direction = ParameterDirection.Input;
                prm88.Value = UNSOLDONSUPPLYORRECEIVEDDATE;
                objOraclecommand.Parameters.Add(prm88);


                OracleParameter prm89 = new OracleParameter("p_AGENCY_UNBLOCK_APROV", OracleType.VarChar, 50);
                prm89.Direction = ParameterDirection.Input;
                prm89.Value = Agencyunblockapproval;
                objOraclecommand.Parameters.Add(prm89);

                OracleParameter prm90 = new OracleParameter("p_UNBLOCK_APROV_OUT_LMT", OracleType.VarChar, 50);
                prm90.Direction = ParameterDirection.Input;
                prm90.Value = UnblockApprovalOutsideCreditLimit;
                objOraclecommand.Parameters.Add(prm90);

                OracleParameter prm91 = new OracleParameter("p_CIR_BILL_PUBLWISE", OracleType.VarChar, 50);
                prm91.Direction = ParameterDirection.Input;
                prm91.Value = billingpublicationwise;
                objOraclecommand.Parameters.Add(prm91);


                OracleParameter prm92 = new OracleParameter("p_ALLOW_FOLLOW_DT_BOOOK", OracleType.VarChar, 50);
                prm92.Direction = ParameterDirection.Input;
                prm92.Value = ALLOW_FOLLOW_DT_BOOOK;
                objOraclecommand.Parameters.Add(prm92);


                OracleParameter prm93 = new OracleParameter("p_paging", OracleType.VarChar, 4000);
                prm93.Direction = ParameterDirection.Input;
                prm93.Value = paging;
                objOraclecommand.Parameters.Add(prm93);

                OracleParameter prm94 = new OracleParameter("p_print", OracleType.VarChar, 4000);
                prm94.Direction = ParameterDirection.Input;
                prm94.Value = print;
                objOraclecommand.Parameters.Add(prm94);

                OracleParameter prm95 = new OracleParameter("p_allowpage", OracleType.VarChar, 4000);
                prm95.Direction = ParameterDirection.Input;
                prm95.Value = allowpage;
                objOraclecommand.Parameters.Add(prm95);

                OracleParameter prm96 = new OracleParameter("p_agency_req", OracleType.VarChar, 4000);
                prm96.Direction = ParameterDirection.Input;
                prm96.Value = agency;
                objOraclecommand.Parameters.Add(prm96);

                OracleParameter prm97 = new OracleParameter("p_region_req", OracleType.VarChar, 4000);
                prm97.Direction = ParameterDirection.Input;
                prm97.Value = region;
                objOraclecommand.Parameters.Add(prm97);

                OracleParameter prm98 = new OracleParameter("p_CRM_SUPPLY_TYPE_PAID", OracleType.VarChar, 4000);
                prm98.Direction = ParameterDirection.Input;
                prm98.Value = subscription_paid_supply_type;
                objOraclecommand.Parameters.Add(prm98);

                OracleParameter prm99 = new OracleParameter("p_CRM_SUPPLY_TYPE_FREE", OracleType.VarChar, 4000);
                prm99.Direction = ParameterDirection.Input;
                prm99.Value = subscription_free_supply_type;
                objOraclecommand.Parameters.Add(prm99);

                OracleParameter prm100 = new OracleParameter("p_CURRENCY_MEASUREMENT", OracleType.VarChar, 4000);
                prm100.Direction = ParameterDirection.Input;
                prm100.Value = CURRENCY_MEASUREMENT;
                objOraclecommand.Parameters.Add(prm100);

                

                OracleParameter prm102 = new OracleParameter("p_EDITABLE_AGENCY_COMM", OracleType.VarChar, 4000);
                prm102.Direction = ParameterDirection.Input;
                prm102.Value = drpadddiscount;
                objOraclecommand.Parameters.Add(prm102);


                OracleParameter prm103 = new OracleParameter("p_CANCELLATION_CHARGE", OracleType.VarChar, 4000);
                prm103.Direction = ParameterDirection.Input;
                prm103.Value = cancharges;
                objOraclecommand.Parameters.Add(prm103);

                OracleParameter prm104 = new OracleParameter("P_taxi_entry_type", OracleType.VarChar, 4000);
                prm104.Direction = ParameterDirection.Input;
                prm104.Value = entry_type;
                objOraclecommand.Parameters.Add(prm104);

                OracleParameter prm105 = new OracleParameter("P_ApprovalWith", OracleType.VarChar, 4000);
                prm105.Direction = ParameterDirection.Input;
                prm105.Value = ApprovalWith;
                objOraclecommand.Parameters.Add(prm105);




                OracleParameter prm106 = new OracleParameter("p_Auto_TDS_Credit_Note", OracleType.VarChar, 4000);
                prm106.Direction = ParameterDirection.Input;
                prm106.Value = Auto_TDS_Credit_Note;
                objOraclecommand.Parameters.Add(prm106);


                OracleParameter prm107 = new OracleParameter("p_TDS_Reason", OracleType.VarChar, 4000);
                prm107.Direction = ParameterDirection.Input;
                prm107.Value = TDS_Reason;
                objOraclecommand.Parameters.Add(prm107);



                OracleParameter prm108 = new OracleParameter("p_Debit_Account_Head", OracleType.VarChar, 4000);
                prm108.Direction = ParameterDirection.Input;
                prm108.Value = Debit_Account_Head;
                objOraclecommand.Parameters.Add(prm108);



                OracleParameter prm109 = new OracleParameter("p_credit_Account_Head", OracleType.VarChar, 4000);
                prm109.Direction = ParameterDirection.Input;
                prm109.Value = credit_Account_Head;
                objOraclecommand.Parameters.Add(prm109);




                OracleParameter prm110 = new OracleParameter("p_service_tax_credit_note", OracleType.VarChar, 4000);
                prm110.Direction = ParameterDirection.Input;
                prm110.Value = service_tax_credit_note;
                objOraclecommand.Parameters.Add(prm110);



                OracleParameter prm111 = new OracleParameter("p_Tax_Reason", OracleType.VarChar, 4000);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = Tax_Reason;
                objOraclecommand.Parameters.Add(prm111);



                OracleParameter prm112 = new OracleParameter("p_Debit_Account_Service_Tax", OracleType.VarChar, 4000);
                prm112.Direction = ParameterDirection.Input;
                prm112.Value = Debit_Account_Service_Tax;
                objOraclecommand.Parameters.Add(prm112);



                OracleParameter prm113 = new OracleParameter("p_Credit_Account_Service_Tax", OracleType.VarChar, 4000);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = Credit_Account_Service_Tax;
                objOraclecommand.Parameters.Add(prm113);



                OracleParameter prm114 = new OracleParameter("p_Patrakar_Reason", OracleType.VarChar, 4000);
                prm114.Direction = ParameterDirection.Input;
                prm114.Value = Patrakar_Reason;
                objOraclecommand.Parameters.Add(prm114);



                OracleParameter prm115 = new OracleParameter("p_Debit_Account_Patrakar", OracleType.VarChar, 4000);
                prm115.Direction = ParameterDirection.Input;
                prm115.Value = Debit_Account_Head_For_Patrakar;
                objOraclecommand.Parameters.Add(prm115);



                OracleParameter prm116 = new OracleParameter("p_Credit_Account_Patrakar", OracleType.VarChar, 4000);
                prm116.Direction = ParameterDirection.Input;
                prm116.Value = Credit_Account_Head_For_Patrakar;
                objOraclecommand.Parameters.Add(prm116);



                OracleParameter prm117 = new OracleParameter("p_Auto_Bank_Credit_Note", OracleType.VarChar, 4000);
                prm117.Direction = ParameterDirection.Input;
                prm117.Value = Auto_Bank_Credit_Note;
                objOraclecommand.Parameters.Add(prm117);



                OracleParameter prm118 = new OracleParameter("p_Bank_Reason", OracleType.VarChar, 4000);
                prm118.Direction = ParameterDirection.Input;
                prm118.Value = Bank_Reason;
                objOraclecommand.Parameters.Add(prm118);



                OracleParameter prm119 = new OracleParameter("p_Debit_Account_Bank", OracleType.VarChar, 4000);
                prm119.Direction = ParameterDirection.Input;
                prm119.Value = Debit_Account_Bank;
                objOraclecommand.Parameters.Add(prm119);



                OracleParameter prm120 = new OracleParameter("p_Credit_Account_Bank", OracleType.VarChar, 4000);
                prm120.Direction = ParameterDirection.Input;
                prm120.Value = Credit_Account_Bank;
                objOraclecommand.Parameters.Add(prm120);



                OracleParameter prm121 = new OracleParameter("p_Auto_Patrakar_Credit_Note", OracleType.VarChar, 4000);
                prm121.Direction = ParameterDirection.Input;
                prm121.Value = Auto_Patrakar_Credit_Note;
                objOraclecommand.Parameters.Add(prm121);


                OracleParameter prm122 = new OracleParameter("P_BAR_CODE", OracleType.VarChar, 4000);
                prm122.Direction = ParameterDirection.Input;
                prm122.Value = BARCODE;
                objOraclecommand.Parameters.Add(prm122);


                OracleParameter prm123 = new OracleParameter("P_WEIGHT_CAL", OracleType.VarChar, 4000);
                prm123.Direction = ParameterDirection.Input;
                prm123.Value = WEIGHTCAL;
                objOraclecommand.Parameters.Add(prm123);

                OracleParameter prm124 = new OracleParameter("P_GEN_RCT_TYP", OracleType.VarChar, 4000);
                prm124.Direction = ParameterDirection.Input;
                prm124.Value = genration_reciept;
                objOraclecommand.Parameters.Add(prm124);

                OracleParameter prm125 = new OracleParameter("P_misdata", OracleType.VarChar, 4000);
                prm125.Direction = ParameterDirection.Input;
                prm125.Value = misdata;
                objOraclecommand.Parameters.Add(prm125);

                OracleParameter prm126 = new OracleParameter("P_allowpremium", OracleType.VarChar, 4000);
                prm126.Direction = ParameterDirection.Input;
                prm126.Value = allowpremium;
                objOraclecommand.Parameters.Add(prm126);


                OracleParameter prm127 = new OracleParameter("p_financecode", OracleType.VarChar, 4000);
                prm127.Direction = ParameterDirection.Input;
                prm127.Value = financecode;
                objOraclecommand.Parameters.Add(prm127);

                OracleParameter prm128 = new OracleParameter("p_exepub", OracleType.VarChar, 4000);
                prm128.Direction = ParameterDirection.Input;
                prm128.Value = executivepub;
                objOraclecommand.Parameters.Add(prm128);


                OracleParameter prm129 = new OracleParameter("p_executivecreditlimit", OracleType.VarChar, 4000);
                prm129.Direction = ParameterDirection.Input;
                prm129.Value = executivecreditlimit;
                objOraclecommand.Parameters.Add(prm129);


                OracleParameter prm130 = new OracleParameter("p_mrv", OracleType.VarChar, 4000);
                prm130.Direction = ParameterDirection.Input;
                prm130.Value = mrv;
                objOraclecommand.Parameters.Add(prm130);


                OracleParameter prm131 = new OracleParameter("p_ret_after_bank", OracleType.VarChar, 4000);
                prm131.Direction = ParameterDirection.Input;
                prm131.Value = ret_after_bank;
                objOraclecommand.Parameters.Add(prm131);



                OracleParameter prm132 = new OracleParameter("p_fixedtransamt", OracleType.VarChar, 4000);
                prm132.Direction = ParameterDirection.Input;
                prm132.Value = fixed_tran_amt;
                objOraclecommand.Parameters.Add(prm132);





                OracleParameter prm133 = new OracleParameter("p_tradediscount", OracleType.VarChar, 4000);
                prm133.Direction = ParameterDirection.Input;
                prm133.Value = trade_dis_based;
                objOraclecommand.Parameters.Add(prm133);



                OracleParameter prm134 = new OracleParameter("p_RETAIN_COMM_ON_LAST_RECDATE", OracleType.VarChar, 4000);
                prm134.Direction = ParameterDirection.Input;
                prm134.Value = retcomm;
                objOraclecommand.Parameters.Add(prm134);


                OracleParameter prm135 = new OracleParameter("p_SUPPLIMENTARY_BILL_REQ", OracleType.VarChar, 4000);
                prm135.Direction = ParameterDirection.Input;
                prm135.Value = supplbill;
                objOraclecommand.Parameters.Add(prm135);


                OracleParameter prm844 = new OracleParameter("p_tdsasseyname", OracleType.VarChar, 50);
                prm844.Direction = ParameterDirection.Input;
                prm844.Value = tdstypename;
                objOraclecommand.Parameters.Add(prm844);

                OracleParameter prm845 = new OracleParameter("p_tdssecname", OracleType.VarChar, 50);
                prm845.Direction = ParameterDirection.Input;
                prm845.Value = tdssecname;
                objOraclecommand.Parameters.Add(prm845);

                OracleParameter prm846 = new OracleParameter("p_tdsretname", OracleType.VarChar, 50);
                prm846.Direction = ParameterDirection.Input;
                prm846.Value =retno;
                objOraclecommand.Parameters.Add(prm846);

                OracleParameter prm847 = new OracleParameter("p_bankrecorequired", OracleType.VarChar, 50);
                prm847.Direction = ParameterDirection.Input;
                prm847.Value = bankrecorequired;
                objOraclecommand.Parameters.Add(prm847);


                OracleParameter prm848 = new OracleParameter("p_REASON_FOR_INTT_ADBILL", OracleType.VarChar, 50);
                prm848.Direction = ParameterDirection.Input;
                prm848.Value = txtretonoverdue;
                objOraclecommand.Parameters.Add(prm848);

                OracleParameter prm849 = new OracleParameter("p_DOCTYP_FOR_INTT_ADBILL", OracleType.VarChar, 50);
                 prm849.Direction = ParameterDirection.Input;
                 prm849.Value = txtdoconoverdue;
                 objOraclecommand.Parameters.Add(prm849);

                 OracleParameter prm850 = new OracleParameter("p_CHECKBOOKINGCREDITLIMIT", OracleType.VarChar, 50);
                 prm850.Direction = ParameterDirection.Input;
                 prm850.Value = drpallowbooking;
                 objOraclecommand.Parameters.Add(prm850);


                 OracleParameter prm851 = new OracleParameter("P_CHECKRODUPLICACY", OracleType.VarChar, 50);
                 prm851.Direction = ParameterDirection.Input;
                 prm851.Value = drpchkfordupreq;
                 objOraclecommand.Parameters.Add(prm851);

                 OracleParameter prm852 = new OracleParameter("p_alowwithtro", OracleType.VarChar, 50);
                 prm852.Direction = ParameterDirection.Input;
                 prm852.Value = alowwithtro;
                 objOraclecommand.Parameters.Add(prm852);


                 OracleParameter prm853 = new OracleParameter("P_COMMON_GRID_ALLOW", OracleType.VarChar, 50);
                 prm853.Direction = ParameterDirection.Input;
                 prm853.Value = commonfrid;
                 objOraclecommand.Parameters.Add(prm853);
                
                   OracleParameter prm854 = new OracleParameter("P_RECIPT_AS_RO_NO", OracleType.VarChar, 50);
                   prm854.Direction = ParameterDirection.Input;
                   prm854.Value = drpreciptno;
                   objOraclecommand.Parameters.Add(prm854);

                   OracleParameter prm855 = new OracleParameter("P_RETAINER_EXEC_OUTSTANDING", OracleType.VarChar, 50);
                   prm855.Direction = ParameterDirection.Input;
                   prm855.Value = drpret_exec;
                   objOraclecommand.Parameters.Add(prm855);

                   OracleParameter prm856 = new OracleParameter("P_CASH_RECP_LINK_ADACC", OracleType.VarChar, 50);
                   prm856.Direction = ParameterDirection.Input;
                   prm856.Value = drpcashrecacc;
                   objOraclecommand.Parameters.Add(prm856);
                //////add by anuja
                   OracleParameter prm8562 = new OracleParameter("P_daysforbooking_agreed", OracleType.VarChar, 50);
                   prm8562.Direction = ParameterDirection.Input;
                   prm8562.Value = daysbook;
                   objOraclecommand.Parameters.Add(prm8562);

         
                
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet datesubmit(string compcode, string userid, string dateformat, string code, string curr, string ratecode, string solo, string breakup, string bwcode, string rostatus, string filename, string tfn, string insertbreak, string prem, string dealtype, string pre, string suff, string chkfinancestatus, string voucherst, string adcode, string rodatetime, string spacearea, string vat, string bookstat, string cio_id, string receipt_no, string uom, string bgcolor, string validdate, string agencyratecode, string audit, string insert_date, string agencycomm, string rateaudit, string billaudit, string billtype, string invoice_no, string copybooking, string ratecomp, string addagencycomm, string agretainercomm, string subrate, string displaybilltype, string classifiedbilltype, string billformat, string ratechk, string allpkg, string dayrate, string schemetype, string Includeclassi, string receiptformat, string cash_receipt, string bill_orderwiselast, string floor_chk, string Unsoldflag, string Supplystopper, string drpRokeychk, string Agencycomm_seq, string creditreciept, string cashindisplay, string cashinclassified, string rate_audit_pref, string barcoding_allow, string fmgbills, string billed_cashdis, string billed_cashcls, string v_drpbackdate, string dockitbooking, string allowprevbooking, string chkval, string cash_billtypea, string approval, string pckstatus, string cash_disc, string cash_amt, string repeatday, string premiumedit, string BILL_GENERATION, string PUBLICATION_CENTER, string allow_discount_prem, string scheme_billing, string ALLOW_PDC, string ad_type_for_manul_bill, string RO_OUTSTAND_P, string genrate_agency_code, string aotosupply, string Authorization, string retainer_bank, string retcomm, string supplbill, string daysbook)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("wesp_submitdate.wesp_submitdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm222 = new OracleParameter("billformat", OracleType.VarChar, 50);
                prm222.Direction = ParameterDirection.Input;
                prm222.Value = billformat;
                objOraclecommand.Parameters.Add(prm222);


                OracleParameter prm2221 = new OracleParameter("ratechk", OracleType.VarChar, 50);
                prm2221.Direction = ParameterDirection.Input;
                prm2221.Value = ratechk;
                objOraclecommand.Parameters.Add(prm2221);

                OracleParameter prm2222 = new OracleParameter("allpkg", OracleType.VarChar, 50);
                prm2222.Direction = ParameterDirection.Input;
                prm2222.Value = allpkg;
                objOraclecommand.Parameters.Add(prm2222);


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("RATECODE11", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ratecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateformat;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("code", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = code;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("curr", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = curr;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("solo", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = solo;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("breakup", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = breakup;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("bwcode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = bwcode;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("rostatus", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = rostatus;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("filename", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = filename;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("tfn", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = tfn;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("insertbreak", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = insertbreak;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("prem", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = prem;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("dealtype", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = dealtype;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pre", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = pre;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("suff", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = suff;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("financestatus", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = chkfinancestatus;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("voucherst", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = voucherst;
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("adcode", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = adcode;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("rodatetime", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = rodatetime;
                objOraclecommand.Parameters.Add(prm21);


                OracleParameter prm23 = new OracleParameter("spacearea", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = spacearea;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("vat", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = vat;
                objOraclecommand.Parameters.Add(prm24);


                OracleParameter prm25 = new OracleParameter("bookstat", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = bookstat;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("cio_id", OracleType.VarChar, 50);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = cio_id;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("receipt_no", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = receipt_no;
                objOraclecommand.Parameters.Add(prm27);

                /*new change ankur*/
                OracleParameter prm28 = new OracleParameter("uom", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = uom;
                objOraclecommand.Parameters.Add(prm28);


                OracleParameter prm29 = new OracleParameter("bgcolor", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = bgcolor;
                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("validdate", OracleType.VarChar, 50);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = validdate;
                objOraclecommand.Parameters.Add(prm30);



                OracleParameter prm31 = new OracleParameter("agencyratecode", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = agencyratecode;
                objOraclecommand.Parameters.Add(prm31);


                OracleParameter prm32 = new OracleParameter("audit", OracleType.VarChar, 50);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = audit;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("book_insert_date", OracleType.VarChar, 50);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = insert_date;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("agencycomm", OracleType.VarChar, 50);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = agencycomm;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("rateaudit", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = rateaudit;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("billaudit", OracleType.VarChar, 50);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = billaudit;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("bill_type", OracleType.VarChar, 50);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = billtype;
                objOraclecommand.Parameters.Add(prm37);


                OracleParameter prm38 = new OracleParameter("invoice_no1", OracleType.VarChar, 50);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = invoice_no;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("copybooking", OracleType.VarChar, 50);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = copybooking;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("ratecompagnecy", OracleType.VarChar, 50);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = ratecomp;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("addagenycomm", OracleType.VarChar, 50);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = addagencycomm;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("agencycommlinkretainer", OracleType.VarChar, 50);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = agretainercomm;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("subeditionr", OracleType.VarChar, 50);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = subrate;
                objOraclecommand.Parameters.Add(prm43);


                OracleParameter prm44 = new OracleParameter("displaybilltype", OracleType.VarChar, 50);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = displaybilltype;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("classifiedbilltype", OracleType.VarChar, 50);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = classifiedbilltype;
                objOraclecommand.Parameters.Add(prm45);

                OracleParameter prm459 = new OracleParameter("dayrate1", OracleType.VarChar, 10);
                prm459.Direction = ParameterDirection.Input;
                prm459.Value = dayrate;
                objOraclecommand.Parameters.Add(prm459);

                OracleParameter prm460 = new OracleParameter("schemetype", OracleType.VarChar, 10);
                prm460.Direction = ParameterDirection.Input;
                prm460.Value = schemetype;
                objOraclecommand.Parameters.Add(prm460);

                OracleParameter prm461 = new OracleParameter("PIncludeclassi", OracleType.VarChar, 50);
                prm461.Direction = ParameterDirection.Input;
                prm461.Value = Includeclassi;
                objOraclecommand.Parameters.Add(prm461);


                OracleParameter prm462 = new OracleParameter("receiptformat", OracleType.VarChar, 50);
                prm462.Direction = ParameterDirection.Input;
                prm462.Value = receiptformat;
                objOraclecommand.Parameters.Add(prm462);



                OracleParameter prm463 = new OracleParameter("v_cash_receipt", OracleType.VarChar, 50);
                prm463.Direction = ParameterDirection.Input;
                prm463.Value = cash_receipt;
                objOraclecommand.Parameters.Add(prm463);




                OracleParameter prm464 = new OracleParameter("v_bill_orderwiselast", OracleType.VarChar, 50);
                prm464.Direction = ParameterDirection.Input;
                prm464.Value = bill_orderwiselast;
                objOraclecommand.Parameters.Add(prm464);

                OracleParameter prm465 = new OracleParameter("v_floor_chk", OracleType.VarChar, 50);
                prm465.Direction = ParameterDirection.Input;
                prm465.Value = floor_chk;
                objOraclecommand.Parameters.Add(prm465);

                //for circulation
                OracleParameter prm1466 = new OracleParameter("Unsoldflag", OracleType.VarChar, 50);
                prm1466.Direction = ParameterDirection.Input;
                prm1466.Value = Unsoldflag;
                objOraclecommand.Parameters.Add(prm1466);

                OracleParameter prm1467 = new OracleParameter("Supplystopper", OracleType.VarChar, 50);
                prm1467.Direction = ParameterDirection.Input;
                prm1467.Value = Supplystopper;
                objOraclecommand.Parameters.Add(prm1467);

                OracleParameter prm1468 = new OracleParameter("drpRokeychk", OracleType.VarChar, 50);
                prm1468.Direction = ParameterDirection.Input;
                prm1468.Value = drpRokeychk;
                objOraclecommand.Parameters.Add(prm1468);

                OracleParameter prm1469 = new OracleParameter("Agencycomm_seq", OracleType.VarChar, 50);
                prm1469.Direction = ParameterDirection.Input;
                prm1469.Value = Agencycomm_seq;
                objOraclecommand.Parameters.Add(prm1469);

                OracleParameter prm1470 = new OracleParameter("creditreciept", OracleType.VarChar, 50);
                prm1470.Direction = ParameterDirection.Input;
                prm1470.Value = creditreciept;
                objOraclecommand.Parameters.Add(prm1470);

                OracleParameter prm1471 = new OracleParameter("cashindisplay", OracleType.VarChar, 50);
                prm1471.Direction = ParameterDirection.Input;
                prm1471.Value = cashindisplay;
                objOraclecommand.Parameters.Add(prm1471);

                OracleParameter prm1472 = new OracleParameter("cashinclassified", OracleType.VarChar, 50);
                prm1472.Direction = ParameterDirection.Input;
                prm1472.Value = cashinclassified;
                objOraclecommand.Parameters.Add(prm1472);

                OracleParameter prm1473 = new OracleParameter("v_rate_audit_pref", OracleType.VarChar, 50);
                prm1473.Direction = ParameterDirection.Input;
                prm1473.Value = rate_audit_pref;
                objOraclecommand.Parameters.Add(prm1473);



                OracleParameter prm1474 = new OracleParameter("v_barcoding_allow_pref", OracleType.VarChar, 50);
                prm1474.Direction = ParameterDirection.Input;
                prm1474.Value = barcoding_allow;
                objOraclecommand.Parameters.Add(prm1474);


                OracleParameter prm1475 = new OracleParameter("v_fmgbills", OracleType.VarChar, 50);
                prm1475.Direction = ParameterDirection.Input;
                prm1475.Value = fmgbills;
                objOraclecommand.Parameters.Add(prm1475);




                OracleParameter prm1476 = new OracleParameter("v_billed_cashdis", OracleType.VarChar, 50);
                prm1476.Direction = ParameterDirection.Input;
                prm1476.Value = billed_cashdis;
                objOraclecommand.Parameters.Add(prm1476);


                OracleParameter prm1477 = new OracleParameter("v_billed_cashcls", OracleType.VarChar, 50);
                prm1477.Direction = ParameterDirection.Input;
                prm1477.Value = billed_cashcls;
                objOraclecommand.Parameters.Add(prm1477);



                OracleParameter prm1478 = new OracleParameter("v_drpbackdate", OracleType.VarChar, 50);
                prm1478.Direction = ParameterDirection.Input;
                prm1478.Value = v_drpbackdate;
                objOraclecommand.Parameters.Add(prm1478);

                OracleParameter prm1479 = new OracleParameter("dockitbooking", OracleType.VarChar, 50);
                prm1479.Direction = ParameterDirection.Input;
                prm1479.Value = dockitbooking;
                objOraclecommand.Parameters.Add(prm1479);

                OracleParameter prm1480 = new OracleParameter("allowprevbooking", OracleType.VarChar, 50);
                prm1480.Direction = ParameterDirection.Input;
                prm1480.Value = allowprevbooking;
                objOraclecommand.Parameters.Add(prm1480);

                OracleParameter prm1481 = new OracleParameter("chkval", OracleType.VarChar, 50);
                prm1481.Direction = ParameterDirection.Input;
                prm1481.Value = chkval;
                objOraclecommand.Parameters.Add(prm1481);

                OracleParameter prm1482 = new OracleParameter("ro_wisecashbill", OracleType.VarChar, 50);
                prm1482.Direction = ParameterDirection.Input;
                prm1482.Value = cash_billtypea;
                objOraclecommand.Parameters.Add(prm1482);


                OracleParameter prm1483 = new OracleParameter("approval1", OracleType.VarChar, 50);
                prm1483.Direction = ParameterDirection.Input;
                prm1483.Value = approval;
                objOraclecommand.Parameters.Add(prm1483);

                OracleParameter prm1484 = new OracleParameter("pckstatus", OracleType.VarChar, 50);
                prm1484.Direction = ParameterDirection.Input;
                prm1484.Value = pckstatus;
                objOraclecommand.Parameters.Add(prm1484);

                OracleParameter prm1485 = new OracleParameter("cash_disc", OracleType.VarChar, 50);
                prm1485.Direction = ParameterDirection.Input;
                prm1485.Value = cash_disc;
                objOraclecommand.Parameters.Add(prm1485);

                OracleParameter prm1486 = new OracleParameter("cash_amt", OracleType.VarChar, 50);
                prm1486.Direction = ParameterDirection.Input;
                prm1486.Value = cash_amt;
                objOraclecommand.Parameters.Add(prm1486);


                OracleParameter prm1487 = new OracleParameter("repeatday", OracleType.VarChar, 50);
                prm1487.Direction = ParameterDirection.Input;
                prm1487.Value = repeatday;
                objOraclecommand.Parameters.Add(prm1487);

                OracleParameter prm1488 = new OracleParameter("premiumedit", OracleType.VarChar, 50);
                prm1488.Direction = ParameterDirection.Input;
                prm1488.Value = premiumedit;
                objOraclecommand.Parameters.Add(prm1488);


                OracleParameter prm73 = new OracleParameter("P_BILL_GENERATION", OracleType.VarChar, 50);
                prm73.Direction = ParameterDirection.Input;
                prm73.Value = BILL_GENERATION;
                objOraclecommand.Parameters.Add(prm73);

                OracleParameter prm74 = new OracleParameter("P_PUBLICATION_CENTER", OracleType.VarChar, 50);
                prm74.Direction = ParameterDirection.Input;
                prm74.Value = PUBLICATION_CENTER;
                objOraclecommand.Parameters.Add(prm74);


                OracleParameter prm75 = new OracleParameter("P_allow_discount_prem", OracleType.VarChar, 50);
                prm75.Direction = ParameterDirection.Input;
                prm75.Value = allow_discount_prem;
                objOraclecommand.Parameters.Add(prm75);


                OracleParameter prm76 = new OracleParameter("P_SCHEME_BILLING", OracleType.VarChar, 50);
                prm76.Direction = ParameterDirection.Input;
                prm76.Value = scheme_billing;
                objOraclecommand.Parameters.Add(prm76);


                OracleParameter prm77 = new OracleParameter("P_ALLOW_PDC", OracleType.VarChar, 50);
                prm77.Direction = ParameterDirection.Input;
                prm77.Value = ALLOW_PDC;
                objOraclecommand.Parameters.Add(prm77);



                OracleParameter prm78 = new OracleParameter("P_TYPE_FOR_MANUL_BILL", OracleType.VarChar, 50);
                prm78.Direction = ParameterDirection.Input;
                prm78.Value = ad_type_for_manul_bill;
                objOraclecommand.Parameters.Add(prm78);



                OracleParameter prm79 = new OracleParameter("RO_OUTSTAND_P", OracleType.VarChar, 50);
                prm79.Direction = ParameterDirection.Input;
                prm79.Value = RO_OUTSTAND_P;
                objOraclecommand.Parameters.Add(prm79);

                OracleParameter prm80 = new OracleParameter("genrate_agency_code", OracleType.VarChar, 50);
                prm80.Direction = ParameterDirection.Input;
                prm80.Value = genrate_agency_code;
                objOraclecommand.Parameters.Add(prm80);

                OracleParameter prm82 = new OracleParameter("p_aotosupply", OracleType.VarChar, 50);
                prm82.Direction = ParameterDirection.Input;
                prm82.Value = aotosupply;
                objOraclecommand.Parameters.Add(prm82);

                OracleParameter prm83 = new OracleParameter("p_Authorization", OracleType.VarChar, 50);
                prm83.Direction = ParameterDirection.Input;
                prm83.Value = Authorization;
                objOraclecommand.Parameters.Add(prm83);

                OracleParameter prm841 = new OracleParameter("p_ret_after_bank", OracleType.VarChar, 50);
                prm841.Direction = ParameterDirection.Input;
                prm841.Value = retainer_bank;
                objOraclecommand.Parameters.Add(prm841);

                OracleParameter prm842 = new OracleParameter("p_RETAIN_COMM_ON_LAST_RECDATE", OracleType.VarChar, 50);
                prm842.Direction = ParameterDirection.Input;
                prm842.Value = retcomm;
                objOraclecommand.Parameters.Add(prm842);

                OracleParameter prm843 = new OracleParameter("p_SUPPLIMENTARY_BILL_REQ", OracleType.VarChar, 50);
                prm843.Direction = ParameterDirection.Input;
                prm843.Value = supplbill;
                objOraclecommand.Parameters.Add(prm843);

                //////add by anuja
                OracleParameter prm8562 = new OracleParameter("P_daysforbooking_agreed", OracleType.VarChar, 50);
                prm8562.Direction = ParameterDirection.Input;
                prm8562.Value = daysbook;
                objOraclecommand.Parameters.Add(prm8562);
               
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }



        public DataSet ratebindprefer(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindrateforprefer.bindrateforprefer_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }
        public DataSet currbindpgld(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("currbindpreferpgld.currbindpreferpgld_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }
        public DataSet currbind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("currbindprefer.currbindprefer_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }



        public DataSet getCsupply_type(string comp_code, string dateformat,string extra1)
        {
            OracleConnection con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            DataSet ds = new DataSet();
            OracleCommand orclcmd;
            try
            {
                con.Open();
                orclcmd = GetCommand("Cir_Supply_Type_Bind.Cir_Supply_Type_Bind_p", ref con);
                orclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comp_code;
                orclcmd.Parameters.Add(prm1);

                OracleParameter prm4 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateformat;
                orclcmd.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra1;
                orclcmd.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = "";
                orclcmd.Parameters.Add(prm6);

                orclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                orclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                da.SelectCommand = orclcmd;
                da.Fill(ds);
                return ds;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }

        }





        public DataSet bind_account(string pcomp_code, string pcdp)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                //string query = "select  Get_unit_type('" + comp_code + "','" + unit_code + "') from dual";
                string query = "select  ad_get_account_name('" + pcomp_code + "','" + pcdp + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "') from dual";
                cmd.CommandText = query;
                cmd.Connection = con;
                //cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }


        public DataSet bind_resont(string pcompcode, string preason_code)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                //string query = "select  Get_unit_type('" + comp_code + "','" + unit_code + "') from dual";
                string query = "select  AD_GET_REASONNAME('" + pcompcode + "','" + preason_code + "') from dual";
                cmd.CommandText = query;
                cmd.Connection = con;
                //cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet filltds()
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                //string query = "select  Get_unit_type('" + comp_code + "','" + unit_code + "') from dual";
                string query = "select RET_COMM_TDS_ASSEY from  preferrences";
                cmd.CommandText = query;
                cmd.Connection = con;
                //cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        
        
        }

        public DataSet retno()
        {

            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                //string query = "select  Get_unit_type('" + comp_code + "','" + unit_code + "') from dual";
                string query = "select  RET_COMM_NOPAN_TDS_RATE from  preferrences";
                cmd.CommandText = query;
                cmd.Connection = con;
                //cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        
        
        
        }


        public DataSet assess()
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                //string query = "select  Get_unit_type('" + comp_code + "','" + unit_code + "') from dual";
                string query = "select  RET_COMM_TDS_SEC_CODE from  preferrences";
                cmd.CommandText = query;
                cmd.Connection = con;
                //cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        
        }




        public DataSet fill_tds_ACCOUNT(string pcomp_code, string pdateformat, string extra1, string extra2, string passesy_type, string psec_code, string pvch_date)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("fa_account_type_bind.fa_tdsheadbind_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pcomp_code;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("passesy_type", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = passesy_type;
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("psec_code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = psec_code;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pvch_date", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (pvch_date == "" || pvch_date == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pvch_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pvch_date = mm + "/" + dd + "/" + yy;
                    }
                    else if (pdateformat == "yyyy/mm/dd")
                    {
                        string[] arr = pvch_date.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        pvch_date = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(pvch_date).ToString("dd-MMMM-yyyy");
                }
                cmd.Parameters.Add(prm4);

                OracleParameter prm17 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = pdateformat;
                cmd.Parameters.Add(prm17);

                OracleParameter prm20 = new OracleParameter("pextra1", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = extra1;
                cmd.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("pextra2", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = extra2;
                cmd.Parameters.Add(prm21);




                cmd.Parameters.Add("P_Accounts", OracleType.Cursor);
                cmd.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                CloseConnection(ref con);
            }

        }





        public DataSet fill_tds_f2(string pcomp_code, string passesy_type, string psec_code, string pvch_date, string pdateformat, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("fa_account_type_bind.fa_tdsbind_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pcomp_code;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("passesy_type", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = passesy_type;
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("psec_code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = psec_code;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pvch_date", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (pvch_date == "" || pvch_date == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pvch_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pvch_date = mm + "/" + dd + "/" + yy;
                    }
                    else if (pdateformat == "yyyy/mm/dd")
                    {
                        string[] arr = pvch_date.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        pvch_date = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(pvch_date).ToString("dd-MMMM-yyyy");
                }
                cmd.Parameters.Add(prm4);

                OracleParameter prm17 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = pdateformat;
                cmd.Parameters.Add(prm17);

                OracleParameter prm20 = new OracleParameter("pextra1", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = extra1;
                cmd.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("pextra2", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = extra2;
                cmd.Parameters.Add(prm21);

                cmd.Parameters.Add("P_Accounts", OracleType.Cursor);
                cmd.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                CloseConnection(ref con);
            }

        }










        public DataSet chkvalidateintable(string tablename, string columnname, string value)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_value_validate", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tablename;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcolumn_name", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = columnname;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pvalue", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = value;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_temp", OracleType.Cursor);
                objOraclecommand.Parameters["p_temp"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }
    
    }


}

