using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for updateprefer
/// </summary>
namespace NewAdbooking.Classes
{
    public class updateprefer : connection
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
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("wesp_chkdateprefer", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }
        public DataSet dateupdation(string compcode, string userid, string dateformat, string code, string curr, string ratecode, string solo, string breakup, string bwcode, string rostatus, string filename, string tfn, string insertbreak, string prem, string dealtype, string pre, string suff, string chkfinancestatus, string voucherst, string adcode, string rodatetime, string spacearea, string vat, string bookstat, string cio_id, string receipt_no, string uom, string bgcolor, string validdate, string agencyratecode, string audit, string insert_date, string agencycomm, string rateaudit, string billaudit, string billtype, string invoice_no, string copybooking, string ratecomp, string addagencycomm, string agencyretcomm, string subrate, string displaybilltype, string classifiedbilltype, string billformat, string ratechk, string allpkg, string dayrate, string schemetype, string Includeclassi, string receiptformat, string cash_receipt, string bill_orderwiselast, string floor_chk, string Unsoldflag, string Supplystopper, string drpRokeychk, string Agencycomm_seq, string creditreciept, string cashindisplay, string cashinclassified, string rate_audit_pref, string barcoding_allow, string fmgbills, string billed_cashdis, string billed_cashcls, string v_drpbackdate, string dockitbooking, string allowprevbooking, string chkval, string cash_billtype, string approval, string pckstatus, string cash_disc, string cash_amt, string seperate_cashier, string disp_bill, string clas_bill, string mantimepost, string bkdaypost, string maxterutn, string cir_return, string noofchkbounc, string noofdaychkrec, string retday, string chngsuppord, string max_publishday, string billno_period, string spl_trans_edit, string spl_dis_trans_editable, string mul_pac_sel_trans, string shmon_minword, string tradon_spcrg, string rateauth, string f2day, string rateauditmodify, string bindrevenuecenter, string led_allow, string clear_allow, string repeatday, string premiumedit, string BILL_GENERATION, string PUBLICATION_CENTER, string allow_discount_prem, string scheme_billing, string ALLOW_PDC, string ad_type_for_manul_bill, string RO_OUTSTAND_P, string genrate_agency_code, string dispauditbk, string aotosupply, string Authorization, string UNSOLDAPPROVAL, string UNSOLDPHYSICAL, string INCLUDEUNSOLD, string INCLUDEUNSOLDININSERTIONFEEPROCESS, string UNSOLDONSUPPLYORRECEIVEDDATE, string Agencyunblockapproval, string UnblockApprovalOutsideCreditLimit, string billingpublicationwise, string ALLOW_FOLLOW_DT_BOOOK, string paging, string print, string allowpage, string agency, string region, string subscription_paid_supply_type, string subscription_free_supply_type, string CURRENCY_MEASUREMENT, string drpadddiscount, string cancharges, string entry_type, string ApprovalWith, string Auto_TDS_Credit_Note, string TDS_Reason, string Debit_Account_Head, string credit_Account_Head, string service_tax_credit_note, string Tax_Reason, string Debit_Account_Service_Tax, string Credit_Account_Service_Tax, string Auto_Patrakar_Credit_Note, string Patrakar_Reason, string Debit_Account_Head_For_Patrakar, string Credit_Account_Head_For_Patrakar, string Auto_Bank_Credit_Note, string Bank_Reason, string Debit_Account_Bank, string Credit_Account_Bank, string BARCODE, string WEIGHTCAL, string GENRCTNO, string misdata, string allowpremium, string financecode, string executivepub, string executivecreditlimit, string mrv, string ret_after_bank, string fixed_tran_amt, string trade_dis_based, string retcomm, string supplbill, string tdstypename, string tdssecname, string retno, string bankrecorequired, string txtretonoverdue, string txtdoconoverdue, string drpallowbooking, string drpchkfordupreq, string alowwithtro, string commonfrid, string drpreciptno, string txtvalue, string flag1, string drpret_exec, string drpcashrecacc,string daysbook)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("wesp_updatedate1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                ////////////////////////////////////////////////////////////////////

                objSqlCommand.Parameters.Add("@copybooking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@copybooking"].Value = copybooking;

                objSqlCommand.Parameters.Add("@ratecompany", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecompany"].Value = ratecomp;

                objSqlCommand.Parameters.Add("@addagenycomm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addagenycomm"].Value = addagencycomm;

                objSqlCommand.Parameters.Add("@agencycommlinkretainer", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycommlinkretainer"].Value = agencyretcomm;

                objSqlCommand.Parameters.Add("@subeditionr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subeditionr"].Value = subrate;

                objSqlCommand.Parameters.Add("@displaybilltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@displaybilltype"].Value = displaybilltype;

                objSqlCommand.Parameters.Add("@classifiedbilltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@classifiedbilltype"].Value = classifiedbilltype;



                /////////////////////////////////////////////////////////////////////////////


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@curr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@curr"].Value = curr;

                objSqlCommand.Parameters.Add("@solo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@solo"].Value = solo;

                objSqlCommand.Parameters.Add("@breakup", SqlDbType.VarChar);
                objSqlCommand.Parameters["@breakup"].Value = breakup;

                objSqlCommand.Parameters.Add("@bwcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bwcode"].Value = bwcode;

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("@filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filename"].Value = filename;

                objSqlCommand.Parameters.Add("@tfn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tfn"].Value = tfn;


                objSqlCommand.Parameters.Add("@insertbreak", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertbreak"].Value = insertbreak;

                objSqlCommand.Parameters.Add("@prem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prem"].Value = prem;

                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;

                objSqlCommand.Parameters.Add("@pre", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pre"].Value = pre;


                objSqlCommand.Parameters.Add("@suff", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suff"].Value = suff;


                objSqlCommand.Parameters.Add("@financestatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@financestatus"].Value = chkfinancestatus;


                objSqlCommand.Parameters.Add("@voucherst", SqlDbType.VarChar);
                objSqlCommand.Parameters["@voucherst"].Value = voucherst;

                objSqlCommand.Parameters.Add("@adcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcode"].Value = adcode;

                objSqlCommand.Parameters.Add("@rodatetime", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rodatetime"].Value = rodatetime;

                objSqlCommand.Parameters.Add("@spacearea", SqlDbType.VarChar);
                objSqlCommand.Parameters["@spacearea"].Value = spacearea;

                objSqlCommand.Parameters.Add("@vat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vat"].Value = vat;



                objSqlCommand.Parameters.Add("@bookstat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookstat"].Value = bookstat;

                objSqlCommand.Parameters.Add("@cio_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cio_id"].Value = cio_id;


                objSqlCommand.Parameters.Add("@receipt_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receipt_no"].Value = receipt_no;

                /*new change ankur*/
                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@bgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgcolor"].Value = bgcolor;


                objSqlCommand.Parameters.Add("@validdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validdate"].Value = validdate;



                objSqlCommand.Parameters.Add("@agencyratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyratecode"].Value = agencyratecode;

                objSqlCommand.Parameters.Add("@audit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@audit"].Value = audit;

                objSqlCommand.Parameters.Add("@book_insert_date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@book_insert_date"].Value = insert_date;

                objSqlCommand.Parameters.Add("@agencycomm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycomm"].Value = agencycomm;

                objSqlCommand.Parameters.Add("@rateaudit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateaudit"].Value = rateaudit;

                objSqlCommand.Parameters.Add("@billaudit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billaudit"].Value = billaudit;

                objSqlCommand.Parameters.Add("@billtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billtype"].Value = billtype;

                objSqlCommand.Parameters.Add("@invoice_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@invoice_no"].Value = invoice_no;


                ///////change bhanu

                objSqlCommand.Parameters.Add("@billformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billformat"].Value = billformat;

                objSqlCommand.Parameters.Add("@ratechk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratechk"].Value = ratechk;

                objSqlCommand.Parameters.Add("@allpkg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@allpkg"].Value = allpkg;

                objSqlCommand.Parameters.Add("@dayrate1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dayrate1"].Value = dayrate;

                objSqlCommand.Parameters.Add("@schemetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@schemetype"].Value = schemetype;

                objSqlCommand.Parameters.Add("@PIncludeclassi", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PIncludeclassi"].Value = Includeclassi;

                objSqlCommand.Parameters.Add("@receiptformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptformat"].Value = receiptformat;

                objSqlCommand.Parameters.Add("@cash_receipt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cash_receipt"].Value = cash_receipt;

                objSqlCommand.Parameters.Add("@bill_orderwiselast", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bill_orderwiselast"].Value = bill_orderwiselast;


                objSqlCommand.Parameters.Add("@floor_chk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@floor_chk"].Value = floor_chk;

                //for circulation
                objSqlCommand.Parameters.Add("@Unsoldflag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Unsoldflag"].Value = Unsoldflag;


                objSqlCommand.Parameters.Add("@Supplystopper", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Supplystopper"].Value = Supplystopper;

                objSqlCommand.Parameters.Add("@drpRokeychk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpRokeychk"].Value = drpRokeychk;


                objSqlCommand.Parameters.Add("@Agencycomm_seq", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Agencycomm_seq"].Value = Agencycomm_seq;


                objSqlCommand.Parameters.Add("@creditreciept", SqlDbType.VarChar);
                objSqlCommand.Parameters["@creditreciept"].Value = creditreciept;

                objSqlCommand.Parameters.Add("@cashindisplay", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cashindisplay"].Value = cashindisplay;


                objSqlCommand.Parameters.Add("@cashinclassified", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cashinclassified"].Value = cashinclassified;


                objSqlCommand.Parameters.Add("@rate_audit_pref", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_audit_pref"].Value = rate_audit_pref;

                objSqlCommand.Parameters.Add("@v_barcoding_allow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_barcoding_allow"].Value = barcoding_allow;


                objSqlCommand.Parameters.Add("@v_fmgbills", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_fmgbills"].Value = fmgbills;



                objSqlCommand.Parameters.Add("@v_billed_cashdis", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_billed_cashdis"].Value = billed_cashdis;



                objSqlCommand.Parameters.Add("@v_billed_cashcls", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_billed_cashcls"].Value = billed_cashcls;



                objSqlCommand.Parameters.Add("@v_drpbackdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_drpbackdate"].Value = v_drpbackdate;

                objSqlCommand.Parameters.Add("@dockitbooking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dockitbooking"].Value = dockitbooking;

                objSqlCommand.Parameters.Add("@allowprevbooking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@allowprevbooking"].Value = allowprevbooking;

                objSqlCommand.Parameters.Add("@chkval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkval"].Value = chkval;

                objSqlCommand.Parameters.Add("@ro_wisecashbill", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ro_wisecashbill"].Value = cash_billtype;

                objSqlCommand.Parameters.Add("@approval1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@approval1"].Value = approval;

                objSqlCommand.Parameters.Add("@pckstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pckstatus"].Value = pckstatus;

                objSqlCommand.Parameters.Add("@cash_disc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cash_disc"].Value = cash_disc;

                objSqlCommand.Parameters.Add("@cash_amt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cash_amt"].Value = cash_amt;

                objSqlCommand.Parameters.Add("@seperate_cashier1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@seperate_cashier1"].Value = seperate_cashier;

                objSqlCommand.Parameters.Add("@disp_bill", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disp_bill"].Value = disp_bill;

                objSqlCommand.Parameters.Add("@clas_bill", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clas_bill"].Value = clas_bill;

                objSqlCommand.Parameters.Add("@mantimepost", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mantimepost"].Value = mantimepost;

                objSqlCommand.Parameters.Add("@bkdaypost", SqlDbType.Int);
                if (bkdaypost == "" || bkdaypost == null)
                {
                    objSqlCommand.Parameters["@bkdaypost"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@bkdaypost"].Value = Convert.ToInt32(bkdaypost);
                }

                objSqlCommand.Parameters.Add("@maxterutn", SqlDbType.VarChar);
                if (maxterutn == "" || maxterutn == null)
                {
                    objSqlCommand.Parameters["@maxterutn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@maxterutn"].Value = Convert.ToInt32(maxterutn);
                }

                objSqlCommand.Parameters.Add("@cir_return", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cir_return"].Value = cir_return;

                objSqlCommand.Parameters.Add("@noofchkbounc", SqlDbType.VarChar);
                if (noofchkbounc == "" || noofchkbounc == null)
                {
                    objSqlCommand.Parameters["@noofchkbounc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@noofchkbounc"].Value = Convert.ToInt32(noofchkbounc);
                }

                objSqlCommand.Parameters.Add("@noofdaychkrec", SqlDbType.VarChar);
                if (noofdaychkrec == "" || noofdaychkrec == null)
                {
                    objSqlCommand.Parameters["@noofdaychkrec"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@noofdaychkrec"].Value = Convert.ToInt32(noofdaychkrec);
                }

                objSqlCommand.Parameters.Add("@retday", SqlDbType.VarChar);
                if (retday == "" || retday == null)
                {
                    objSqlCommand.Parameters["@retday"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@retday"].Value = Convert.ToInt32(retday);
                }

                objSqlCommand.Parameters.Add("@chngsuppord", SqlDbType.VarChar);
                if (chngsuppord == "" || chngsuppord == null)
                {
                    objSqlCommand.Parameters["@chngsuppord"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@chngsuppord"].Value = Convert.ToInt32(chngsuppord);
                }

                objSqlCommand.Parameters.Add("@max_publishday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@max_publishday"].Value = max_publishday;


                objSqlCommand.Parameters.Add("@p_billno_period", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_billno_period"].Value = billno_period;

                objSqlCommand.Parameters.Add("@spl_trans_edit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@spl_trans_edit"].Value = spl_trans_edit;

                objSqlCommand.Parameters.Add("@spl_dis_trans_editable", SqlDbType.VarChar);
                objSqlCommand.Parameters["@spl_dis_trans_editable"].Value = spl_dis_trans_editable;

                objSqlCommand.Parameters.Add("@mul_pac_sel_trans", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mul_pac_sel_trans"].Value = mul_pac_sel_trans;

                objSqlCommand.Parameters.Add("@shmon_minword", SqlDbType.VarChar);
                objSqlCommand.Parameters["@shmon_minword"].Value = shmon_minword;

                objSqlCommand.Parameters.Add("@tradon_spcrg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tradon_spcrg"].Value = tradon_spcrg;

                objSqlCommand.Parameters.Add("@rateauth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateauth"].Value = rateauth;

                objSqlCommand.Parameters.Add("@f2day", SqlDbType.VarChar);
                objSqlCommand.Parameters["@f2day"].Value = f2day;

                objSqlCommand.Parameters.Add("@rateauditmodify", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateauditmodify"].Value = rateauditmodify;

                objSqlCommand.Parameters.Add("@bindrevenuecenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bindrevenuecenter"].Value = bindrevenuecenter;


                objSqlCommand.Parameters.Add("@p_led_allow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_led_allow"].Value = led_allow;

                objSqlCommand.Parameters.Add("@p_clear_allow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_clear_allow"].Value = clear_allow;

                objSqlCommand.Parameters.Add("@repeatday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@repeatday"].Value = repeatday;

                objSqlCommand.Parameters.Add("@premiumedit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premiumedit"].Value = premiumedit;

                objSqlCommand.Parameters.Add("@P_BILL_GENERATION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_BILL_GENERATION"].Value = BILL_GENERATION;

                objSqlCommand.Parameters.Add("@P_PUBLICATION_CENTER", SqlDbType.VarChar);
                if (PUBLICATION_CENTER == "0")
                {
                    objSqlCommand.Parameters["@P_PUBLICATION_CENTER"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@P_PUBLICATION_CENTER"].Value = PUBLICATION_CENTER;
                }


                objSqlCommand.Parameters.Add("@P_allow_discount_prem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_allow_discount_prem"].Value = allow_discount_prem;


                objSqlCommand.Parameters.Add("@P_SCHEME_BILLING", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_SCHEME_BILLING"].Value = scheme_billing;


                objSqlCommand.Parameters.Add("@P_ALLOW_PDC", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_ALLOW_PDC"].Value = ALLOW_PDC;



                objSqlCommand.Parameters.Add("@PAD_TYPE_FOR_MANUL_BILL", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PAD_TYPE_FOR_MANUL_BILL"].Value = ad_type_for_manul_bill;



                objSqlCommand.Parameters.Add("@RO_OUTSTAND_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@RO_OUTSTAND_P"].Value = RO_OUTSTAND_P;

                objSqlCommand.Parameters.Add("@genrate_agency_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@genrate_agency_code"].Value = genrate_agency_code;

                objSqlCommand.Parameters.Add("@p_dispauditbk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_dispauditbk"].Value = dispauditbk;

                objSqlCommand.Parameters.Add("@p_aotosupply", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_aotosupply"].Value = aotosupply;

                objSqlCommand.Parameters.Add("@p_Authorization", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Authorization"].Value = Authorization;

                objSqlCommand.Parameters.Add("@p_CIR_AUTO_APPROVAL_UNSOLD", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_CIR_AUTO_APPROVAL_UNSOLD"].Value = UNSOLDAPPROVAL;

                objSqlCommand.Parameters.Add("@p_CIR_AUTO_PHYSICAL_UNSOLD", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_CIR_AUTO_PHYSICAL_UNSOLD"].Value = UNSOLDPHYSICAL;

                objSqlCommand.Parameters.Add("@p_CIR_UNSOLD_INCLUDE_INCT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_CIR_UNSOLD_INCLUDE_INCT"].Value = INCLUDEUNSOLD;

                objSqlCommand.Parameters.Add("@p_CIR_UNSOLD_INCLUDE_INSFEE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_CIR_UNSOLD_INCLUDE_INSFEE"].Value = INCLUDEUNSOLDININSERTIONFEEPROCESS;

                objSqlCommand.Parameters.Add("@p_CIR_UNSOLD_ON_RECEIVED_DT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_CIR_UNSOLD_ON_RECEIVED_DT"].Value = UNSOLDONSUPPLYORRECEIVEDDATE;

                objSqlCommand.Parameters.Add("@p_AGENCY_UNBLOCK_APPROVAL", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_AGENCY_UNBLOCK_APPROVAL"].Value = Agencyunblockapproval;

                objSqlCommand.Parameters.Add("@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT"].Value = UnblockApprovalOutsideCreditLimit;

                objSqlCommand.Parameters.Add("@p_CIR_BILL_PUBLWISE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_CIR_BILL_PUBLWISE"].Value = billingpublicationwise;

                objSqlCommand.Parameters.Add("@p_ALLOW_FOLLOW_DT_BOOOK", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_ALLOW_FOLLOW_DT_BOOOK"].Value = ALLOW_FOLLOW_DT_BOOOK;

                objSqlCommand.Parameters.Add("@paging ", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paging "].Value = paging;

                objSqlCommand.Parameters.Add("@print", SqlDbType.VarChar);
                objSqlCommand.Parameters["@print"].Value = print;

                objSqlCommand.Parameters.Add("@allowpage", SqlDbType.VarChar);
                objSqlCommand.Parameters["@allowpage"].Value = allowpage;

                objSqlCommand.Parameters.Add("@agency_req", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency_req"].Value = agency;

                objSqlCommand.Parameters.Add("@region_req", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region_req"].Value = region;

                objSqlCommand.Parameters.Add("@p_CRM_SUPPLY_TYPE_PAID", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_CRM_SUPPLY_TYPE_PAID"].Value = subscription_paid_supply_type;

                objSqlCommand.Parameters.Add("@p_CRM_SUPPLY_TYPE_FREE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_CRM_SUPPLY_TYPE_FREE"].Value = subscription_free_supply_type;

                objSqlCommand.Parameters.Add("@p_CURRENCY_MEASUREMENT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_CURRENCY_MEASUREMENT"].Value = CURRENCY_MEASUREMENT;

            

                objSqlCommand.Parameters.Add("@p_EDITABLE_AGENCY_COMM", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_EDITABLE_AGENCY_COMM"].Value = drpadddiscount;

                objSqlCommand.Parameters.Add("@p_CANCELLATION_CHARGE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_CANCELLATION_CHARGE"].Value = cancharges;

                objSqlCommand.Parameters.Add("@P_taxi_entry_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_taxi_entry_type"].Value = entry_type;

                objSqlCommand.Parameters.Add("@P_ApprovalWith", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_ApprovalWith"].Value = ApprovalWith;


                objSqlCommand.Parameters.Add("@p_Auto_TDS_Credit_Note", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Auto_TDS_Credit_Note"].Value = Auto_TDS_Credit_Note;

                objSqlCommand.Parameters.Add("@p_TDS_Reason", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_TDS_Reason"].Value = TDS_Reason;

                objSqlCommand.Parameters.Add("@p_Debit_Account_Head", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Debit_Account_Head"].Value = Debit_Account_Head;

                objSqlCommand.Parameters.Add("@p_credit_Account_Head", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_credit_Account_Head"].Value = credit_Account_Head;

                objSqlCommand.Parameters.Add("@p_service_tax_credit_note", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_service_tax_credit_note"].Value = service_tax_credit_note;

                objSqlCommand.Parameters.Add("@p_Tax_Reason", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Tax_Reason"].Value = Tax_Reason;

                objSqlCommand.Parameters.Add("@p_Debit_Account_Service_Tax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Debit_Account_Service_Tax"].Value = Debit_Account_Service_Tax;

                objSqlCommand.Parameters.Add("@p_Credit_Account_Service_Tax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Credit_Account_Service_Tax"].Value = Credit_Account_Service_Tax;

                objSqlCommand.Parameters.Add("@p_Patrakar_Reason", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Patrakar_Reason"].Value = Patrakar_Reason;

                objSqlCommand.Parameters.Add("@p_Debit_Account_Patrakar", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Debit_Account_Patrakar"].Value = Debit_Account_Head_For_Patrakar;

                objSqlCommand.Parameters.Add("@p_Credit_Account_Patrakar", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Credit_Account_Patrakar"].Value = Credit_Account_Head_For_Patrakar;

                objSqlCommand.Parameters.Add("@p_Auto_Bank_Credit_Note", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Auto_Bank_Credit_Note"].Value = Auto_Bank_Credit_Note;

                objSqlCommand.Parameters.Add("@p_Bank_Reason", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Bank_Reason"].Value = Bank_Reason;

                objSqlCommand.Parameters.Add("@p_Debit_Account_Bank", SqlDbType.VarChar);
                if (Debit_Account_Bank != "")
                {

                    objSqlCommand.Parameters["@p_Debit_Account_Bank"].Value = Debit_Account_Bank;
                }
                else {
                    objSqlCommand.Parameters["@p_Debit_Account_Bank"].Value = System.DBNull.Value;
                }


                objSqlCommand.Parameters.Add("@p_Credit_Account_Bank", SqlDbType.VarChar);
                if (credit_Account_Head != "")
                {
                    objSqlCommand.Parameters["@p_Credit_Account_Bank"].Value = credit_Account_Head;
                }
                else
                {
                    objSqlCommand.Parameters["@p_Credit_Account_Bank"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@p_Auto_Patrakar_Credit_Note", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Auto_Patrakar_Credit_Note"].Value = Auto_Patrakar_Credit_Note;


                objSqlCommand.Parameters.Add("@P_BAR_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_BAR_CODE"].Value = BARCODE;

                objSqlCommand.Parameters.Add("@P_WEIGHT_CAL", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_WEIGHT_CAL"].Value = WEIGHTCAL;

                objSqlCommand.Parameters.Add("@P_GEN_RCT_NO", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_GEN_RCT_NO"].Value = GENRCTNO;


                objSqlCommand.Parameters.Add("@P_misdata", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@P_misdata"].Value = misdata;

                 objSqlCommand.Parameters.Add("@P_allowpremium", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@P_allowpremium"].Value = allowpremium;



                 objSqlCommand.Parameters.Add("@p_financecode", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@p_financecode"].Value = financecode;


                 objSqlCommand.Parameters.Add("@p_exepub", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@p_exepub"].Value = executivepub;


                 objSqlCommand.Parameters.Add("@p_executivecreditlimit", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@p_executivecreditlimit"].Value = executivecreditlimit;



                 objSqlCommand.Parameters.Add("@p_mrv", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@p_mrv"].Value = mrv;


                 objSqlCommand.Parameters.Add("@p_ret_after_bank", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@p_ret_after_bank"].Value = ret_after_bank;


                
                 objSqlCommand.Parameters.Add("@p_fixedtransamt", SqlDbType.VarChar);
                 if (fixed_tran_amt != "")
                 {
                     objSqlCommand.Parameters["@p_fixedtransamt"].Value = fixed_tran_amt;
                 }
                 else {
                     objSqlCommand.Parameters["@p_fixedtransamt"].Value = System.DBNull.Value;
                 }

                 objSqlCommand.Parameters.Add("@p_tradediscount", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@p_tradediscount"].Value = trade_dis_based;

                 objSqlCommand.Parameters.Add("@RETAIN_COMM_ON_LAST_RECDATE", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@RETAIN_COMM_ON_LAST_RECDATE"].Value =  retcomm;

                 objSqlCommand.Parameters.Add("@SUPPLIMENTARY_BILL_REQ", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@SUPPLIMENTARY_BILL_REQ"].Value =  supplbill;
 

                 objSqlCommand.Parameters.Add("@p_tdsasseyname", SqlDbType.VarChar);
                 if (tdstypename != "")
                 {
                     objSqlCommand.Parameters["@p_tdsasseyname"].Value = tdstypename;
                 }
                 else
                 {
                     objSqlCommand.Parameters["@p_tdsasseyname"].Value = System.DBNull.Value;

                 }



                 objSqlCommand.Parameters.Add("@p_tdssecname", SqlDbType.VarChar);
                 if (tdssecname != "")
                 {
                     objSqlCommand.Parameters["@p_tdssecname"].Value = retno;
                 }
                 else
                 {
                     objSqlCommand.Parameters["@p_tdssecname"].Value = System.DBNull.Value;

                 }


                
                 objSqlCommand.Parameters.Add("@p_tdsretname", SqlDbType.VarChar);
                 if (retno != "")
                 {
                     objSqlCommand.Parameters["@p_tdsretname"].Value = retno;
                 }
                 else
                 {
                     objSqlCommand.Parameters["@p_tdsretname"].Value = System.DBNull.Value;

                 }
                 


                 objSqlCommand.Parameters.Add("@p_bankrecorequired", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@p_bankrecorequired"].Value = bankrecorequired;


                 objSqlCommand.Parameters.Add("@REASON_FOR_INTT_ADBILL", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@REASON_FOR_INTT_ADBILL"].Value = txtretonoverdue;

                 objSqlCommand.Parameters.Add("@DOCTYP_FOR_INTT_ADBILL", SqlDbType.VarChar);
                 if (txtdoconoverdue != "")
                 {
                     objSqlCommand.Parameters["@DOCTYP_FOR_INTT_ADBILL"].Value = txtdoconoverdue;
                 }
                 else
                 {
                     objSqlCommand.Parameters["@DOCTYP_FOR_INTT_ADBILL"].Value = System.DBNull.Value;
                 }
               

                objSqlCommand.Parameters.Add("@CHECKBOOKINGCREDITLIMIT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CHECKBOOKINGCREDITLIMIT"].Value = drpallowbooking;

                 objSqlCommand.Parameters.Add("@CHECKRODUPLICACY", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@CHECKRODUPLICACY"].Value = drpchkfordupreq;

                 objSqlCommand.Parameters.Add("@alowwithtro", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@alowwithtro"].Value = alowwithtro;

                 objSqlCommand.Parameters.Add("@COMMON_GRID_ALLOW", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@COMMON_GRID_ALLOW"].Value = commonfrid;

                 objSqlCommand.Parameters.Add("@RECIPT_AS_RO_NO", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@RECIPT_AS_RO_NO"].Value = drpreciptno;

                 objSqlCommand.Parameters.Add("@RETAINER_EXEC_OUTSTANDING", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@RETAINER_EXEC_OUTSTANDING"].Value = drpret_exec;

                
                 //obj11111111111111111111111111111111SqlCommand.Parameters["@COLLECTION_PER_FOR_CN"].Value = Convert.ToInt32(txtvalue);
                 objSqlCommand.Parameters.Add("@COLLECTION_PER_FOR_CN", SqlDbType.VarChar);
                 if (txtvalue != "")
                 {
                     objSqlCommand.Parameters["@COLLECTION_PER_FOR_CN"].Value = txtvalue;

                 }
                 else {
                     objSqlCommand.Parameters["@COLLECTION_PER_FOR_CN"].Value = System.DBNull.Value;
                 }
                 

                 objSqlCommand.Parameters.Add("@vat_flag", SqlDbType.VarChar);
                 if (flag1 !=""){
                 objSqlCommand.Parameters["@vat_flag"].Value = flag1;
                  }
                 else{
                 objSqlCommand.Parameters["@vat_flag"].Value = System.DBNull.Value;
                  }

                 objSqlCommand.Parameters.Add("@CASH_RECP_LINK_ADACC", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@CASH_RECP_LINK_ADACC"].Value = drpcashrecacc;
                ///add by anuja
                 objSqlCommand.Parameters.Add("@P_daysforbooking_agreed", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@P_daysforbooking_agreed"].Value = daysbook;
                
                
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }



            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }





        public DataSet fill_tds_ACCOUNT(string pcomp_code, string pdateformat, string extra1, string extra2, string passesy_type, string psec_code, string pvch_date)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fa_account_type_bind_fa_tdsheadbind_p", ref objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@passesy_type", SqlDbType.VarChar);
                if (passesy_type == "null" || passesy_type == "")
                {
                    objSqlCommand.Parameters["@passesy_type"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@passesy_type"].Value = passesy_type;
                }

                objSqlCommand.Parameters.Add("@psec_code", SqlDbType.VarChar);
                if (psec_code == "null" || psec_code == "")
                {
                    objSqlCommand.Parameters["@psec_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@psec_code"].Value = psec_code;
                }

                objSqlCommand.Parameters.Add("@pvch_date", SqlDbType.VarChar);
                if (pvch_date == "" || pvch_date == null)
                {
                    objSqlCommand.Parameters["@pvch_date"].Value = System.DBNull.Value;
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
                    objSqlCommand.Parameters["@pvch_date"].Value = pvch_date;
                }

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = pcomp_code;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = pdateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);


                return objDataSet;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }


        public DataSet fill_tds_f2(string pcomp_code, string passesy_type, string psec_code, string pvch_date, string pdateformat, string extra1, string extra2)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fa_account_type_bind_fa_tdsbind_p", ref objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@passesy_type", SqlDbType.VarChar);
                if (passesy_type == "null" || passesy_type == "")
                {
                    objSqlCommand.Parameters["@passesy_type"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@passesy_type"].Value = passesy_type;
                }

                objSqlCommand.Parameters.Add("@psec_code", SqlDbType.VarChar);
                if (psec_code == "null" || psec_code == "")
                {
                    objSqlCommand.Parameters["@psec_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@psec_code"].Value = psec_code;
                }

                objSqlCommand.Parameters.Add("@pvch_date", SqlDbType.VarChar);
                if (pvch_date == "" || pvch_date == null)
                {
                    objSqlCommand.Parameters["@pvch_date"].Value = System.DBNull.Value;
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
                    objSqlCommand.Parameters["@pvch_date"].Value = pvch_date;
                }
                // objSqlCommand.Parameters["@pvch_date"].Value = pvch_date;

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = pcomp_code;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = pdateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);


                return objDataSet;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }






        public DataSet datesubmit(string compcode, string userid, string dateformat, string code, string curr, string ratecode, string solo, string breakup, string bwcode, string rostatus, string filename, string tfn, string insertbreak, string prem, string dealtype, string pre, string suff, string chkfinancestatus, string voucherst, string adcode, string rodatetime, string spacearea, string vat, string bookstat, string cio_id, string receipt_no, string uom, string bgcolor, string validdate, string agencyratecode, string audit, string insert_date, string agencycomm, string rateaudit, string billaudit, string billtype, string invoice_no, string copybooking, string ratecomp, string addagencycomm, string agencyretcomm, string subrate, string displaybilltype, string classifiedbilltype, string billformat, string ratechk, string allpkg, string dayrate, string schemetype, string Includeclassi, string receiptformat, string cash_receipt, string bill_orderwiselast, string floor_chk, string Unsoldflag, string Supplystopper, string drpRokeychk, string Agencycomm_seq, string creditreciept, string cashindisplay, string cashinclassified, string rate_audit_pref, string barcoding_allow, string fmgbills, string billed_cashdis, string billed_cashcls, string v_drpbackdate, string dockitbooking, string allowprevbooking, string chkval, string cash_billtype, string approval, string pckstatus, string cash_disc, string cash_amt, string repeatday, string premiumedit, string BILL_GENERATION, string PUBLICATION_CENTER, string allow_discount_prem, string scheme_billing, string ALLOW_PDC, string ad_type_for_manul_bill, string RO_OUTSTAND_P, string genrate_agency_code, string aotosupply, string Authorization, string retainer_bank,string retcomm, string supplbill,string daysbook)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("wesp_submitdate1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@copybooking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@copybooking"].Value = copybooking;

                objSqlCommand.Parameters.Add("@ratecompany", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecompany"].Value = ratecomp;

                objSqlCommand.Parameters.Add("@addagenycomm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addagenycomm"].Value = addagencycomm;

                objSqlCommand.Parameters.Add("@agencycommlinkretainer", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycommlinkretainer"].Value = agencyretcomm;

                objSqlCommand.Parameters.Add("@subeditionr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subeditionr"].Value = subrate;

                objSqlCommand.Parameters.Add("@displaybilltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@displaybilltype"].Value = displaybilltype;

                objSqlCommand.Parameters.Add("@classifiedbilltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@classifiedbilltype"].Value = classifiedbilltype;



                /////////////////////////////////////////////////////////////////////////////
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@curr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@curr"].Value = curr;

                objSqlCommand.Parameters.Add("@solo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@solo"].Value = solo;

                objSqlCommand.Parameters.Add("@breakup", SqlDbType.VarChar);
                objSqlCommand.Parameters["@breakup"].Value = breakup;

                objSqlCommand.Parameters.Add("@bwcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bwcode"].Value = bwcode;

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("@filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filename"].Value = filename;

                objSqlCommand.Parameters.Add("@tfn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tfn"].Value = tfn;

                objSqlCommand.Parameters.Add("@insertbreak", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertbreak"].Value = insertbreak;

                objSqlCommand.Parameters.Add("@prem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prem"].Value = prem;

                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;


                objSqlCommand.Parameters.Add("@pre", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pre"].Value = pre;




                objSqlCommand.Parameters.Add("@suff", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suff"].Value = suff;


                objSqlCommand.Parameters.Add("@financestatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@financestatus"].Value = chkfinancestatus;


                objSqlCommand.Parameters.Add("@voucherst", SqlDbType.VarChar);
                objSqlCommand.Parameters["@voucherst"].Value = voucherst;

                objSqlCommand.Parameters.Add("@adcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcode"].Value = adcode;


                objSqlCommand.Parameters.Add("@rodatetime", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rodatetime"].Value = rodatetime;

                objSqlCommand.Parameters.Add("@spacearea", SqlDbType.VarChar);
                objSqlCommand.Parameters["@spacearea"].Value = spacearea;

                objSqlCommand.Parameters.Add("@vat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vat"].Value = vat;


                objSqlCommand.Parameters.Add("@bookstat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookstat"].Value = bookstat;

                objSqlCommand.Parameters.Add("@cio_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cio_id"].Value = cio_id;


                objSqlCommand.Parameters.Add("@receipt_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receipt_no"].Value = receipt_no;

                /*new change ankur*/


                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@bgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgcolor"].Value = bgcolor;


                objSqlCommand.Parameters.Add("@validdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validdate"].Value = validdate;

                objSqlCommand.Parameters.Add("@agencyratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyratecode"].Value = agencyratecode;


                objSqlCommand.Parameters.Add("@audit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@audit"].Value = audit;

                objSqlCommand.Parameters.Add("@book_insert_date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@book_insert_date"].Value = insert_date;

                objSqlCommand.Parameters.Add("@agencycomm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycomm"].Value = agencycomm;

                objSqlCommand.Parameters.Add("@rateaudit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateaudit"].Value = rateaudit;

                objSqlCommand.Parameters.Add("@billaudit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billaudit"].Value = billaudit;

                objSqlCommand.Parameters.Add("@billtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billtype"].Value = billtype;
                objSqlCommand.Parameters.Add("@invoice_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@invoice_no"].Value = invoice_no;


                ///////change bhanu

                objSqlCommand.Parameters.Add("@billformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billformat"].Value = billformat;

                objSqlCommand.Parameters.Add("@ratechk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratechk"].Value = ratechk;

                objSqlCommand.Parameters.Add("@allpkg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@allpkg"].Value = allpkg;

                objSqlCommand.Parameters.Add("@dayrate1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dayrate1"].Value = dayrate;

                objSqlCommand.Parameters.Add("@schemetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@schemetype"].Value = schemetype;


                objSqlCommand.Parameters.Add("@PIncludeclassi", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PIncludeclassi"].Value = Includeclassi;

                objSqlCommand.Parameters.Add("@receiptformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptformat"].Value = receiptformat;

                objSqlCommand.Parameters.Add("@cash_receipt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bill_orderwiselast"].Value = cash_receipt;

                objSqlCommand.Parameters.Add("@bill_orderwiselast", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bill_orderwiselast"].Value = bill_orderwiselast;


                objSqlCommand.Parameters.Add("@floor_chk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@floor_chk"].Value = floor_chk;

                //for circulation
                objSqlCommand.Parameters.Add("@Unsoldflag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Unsoldflag"].Value = Unsoldflag;

                objSqlCommand.Parameters.Add("@Supplystopper", SqlDbType.VarChar);
                if (Supplystopper == "")
                    objSqlCommand.Parameters["@Supplystopper"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@Supplystopper"].Value = Supplystopper;

                objSqlCommand.Parameters.Add("@drpRokeychk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpRokeychk"].Value = drpRokeychk;

                objSqlCommand.Parameters.Add("@Agencycomm_seq", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Agencycomm_seq"].Value = Agencycomm_seq;


                objSqlCommand.Parameters.Add("@creditreciept", SqlDbType.VarChar);
                objSqlCommand.Parameters["@creditreciept"].Value = creditreciept;


                objSqlCommand.Parameters.Add("@cashindisplay", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cashindisplay"].Value = cashindisplay;


                objSqlCommand.Parameters.Add("@cashinclassified", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cashinclassified"].Value = cashinclassified;


                objSqlCommand.Parameters.Add("@rate_audit_pref", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_audit_pref"].Value = rate_audit_pref;

                objSqlCommand.Parameters.Add("@v_barcoding_allow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_barcoding_allow"].Value = barcoding_allow;



                objSqlCommand.Parameters.Add("@v_fmgbills", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_fmgbills"].Value = fmgbills;






                objSqlCommand.Parameters.Add("@v_billed_cashdis", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_billed_cashdis"].Value = billed_cashdis;



                objSqlCommand.Parameters.Add("@v_billed_cashcls", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_billed_cashcls"].Value = billed_cashcls;


                objSqlCommand.Parameters.Add("@v_drpbackdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_drpbackdate"].Value = v_drpbackdate;

                objSqlCommand.Parameters.Add("@dockitbooking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dockitbooking"].Value = dockitbooking;

                objSqlCommand.Parameters.Add("@allowprevbooking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@allowprevbooking"].Value = allowprevbooking;


                objSqlCommand.Parameters.Add("@chkval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkval"].Value = chkval;

                objSqlCommand.Parameters.Add("@ro_wisecashbill", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ro_wisecashbill"].Value = cash_billtype;

                objSqlCommand.Parameters.Add("@approval1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@approval1"].Value = approval;

                objSqlCommand.Parameters.Add("@pckstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pckstatus"].Value = pckstatus;

                objSqlCommand.Parameters.Add("@cash_disc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cash_disc"].Value = cash_disc;

                objSqlCommand.Parameters.Add("@cash_amt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cash_amt"].Value = cash_amt;


                objSqlCommand.Parameters.Add("@p_repeatday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_repeatday"].Value = repeatday;

                objSqlCommand.Parameters.Add("@p_premiumedit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_premiumedit"].Value = premiumedit;


                objSqlCommand.Parameters.Add("@P_BILL_GENERATION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_BILL_GENERATION"].Value = BILL_GENERATION;

                objSqlCommand.Parameters.Add("@P_PUBLICATION_CENTER", SqlDbType.VarChar);
                if (PUBLICATION_CENTER == "0")
                {
                    objSqlCommand.Parameters["@P_PUBLICATION_CENTER"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@P_PUBLICATION_CENTER"].Value = PUBLICATION_CENTER;
                }


                objSqlCommand.Parameters.Add("@P_allow_discount_prem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_allow_discount_prem"].Value = allow_discount_prem;


                objSqlCommand.Parameters.Add("@P_SCHEME_BILLING", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_SCHEME_BILLING"].Value = scheme_billing;


                objSqlCommand.Parameters.Add("@P_ALLOW_PDC", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_ALLOW_PDC"].Value = ALLOW_PDC;


                objSqlCommand.Parameters.Add("@PAD_TYPE_FOR_MANUL_BILL", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PAD_TYPE_FOR_MANUL_BILL"].Value = ad_type_for_manul_bill;


                objSqlCommand.Parameters.Add("@RO_OUTSTAND_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@RO_OUTSTAND_P"].Value = RO_OUTSTAND_P;

                objSqlCommand.Parameters.Add("@genrate_agency_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@genrate_agency_code"].Value = genrate_agency_code;


                objSqlCommand.Parameters.Add("@p_aotosupply", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_aotosupply"].Value = aotosupply;

                objSqlCommand.Parameters.Add("@p_Authorization", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Authorization"].Value = Authorization;

                objSqlCommand.Parameters.Add("@p_ret_after_bank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_ret_after_bank"].Value = retainer_bank;


                objSqlCommand.Parameters.Add("@RETAIN_COMM_ON_LAST_RECDATE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@RETAIN_COMM_ON_LAST_RECDATE"].Value = retcomm;

                objSqlCommand.Parameters.Add("@SUPPLIMENTARY_BILL_REQ", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SUPPLIMENTARY_BILL_REQ"].Value =  supplbill;

                ///add by anuja
                objSqlCommand.Parameters.Add("@P_daysforbooking_agreed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_daysforbooking_agreed"].Value = daysbook;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        public DataSet ratebindprefer(string compcode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("bindrateforprefer", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;


                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;



                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }

        }
        public DataSet currbindpgld(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("currbindpreferpgld", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }


        }
        public DataSet currbind(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("currbindprefer", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;





                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }


        }




        public DataSet getCsupply_type(string comp_code, string dateformat,string extra1)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Cir_Supply_Type_Bind_p", ref objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();


                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = comp_code;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = "";

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }

        }


        public DataSet bind_account(string pcomp_code, string pcdp)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                string query = "select  dbo.ad_get_account_name('" + pcomp_code + "','" + pcdp + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "')";
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                //cmd.ExecuteNonQuery();

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objSqlConnection.Close();
            }
        }



        public DataSet bind_resont(string pcompcode, string preason_code)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                string query = "select  dbo.AD_GET_REASONNAME('" + pcompcode + "','" + preason_code + "')";
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                //cmd.ExecuteNonQuery();

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objSqlConnection.Close();
            }
        }


        public DataSet chkvalidateintable(string tablename, string columnname, string value)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_value_validate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tablename;

                objSqlCommand.Parameters.Add("@pcolumn_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolumn_name"].Value = columnname;

                objSqlCommand.Parameters.Add("@pvalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pvalue"].Value = value;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
    
    
    }





}

