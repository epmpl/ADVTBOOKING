
ALTER PROCEDURE   [dbo].[wesp_updatedate1]

@compcode as varchar(15),
@userid as varchar(15),
@dateformat as varchar(15),
@code as varchar(4),
@curr as varchar(8),
@ratecode as varchar(8),
@solo as varchar(15),
@breakup as varchar(2),
@bwcode as varchar(8),
@rostatus as varchar(2),
@filename as varchar(2),
@tfn as VARCHAR(4),
@insertbreak as varchar(2),
@prem as varchar(8),
@dealtype as varchar(2),
@pre as varchar(5),
@suff as varchar(5),
@financestatus as  char(2),
@voucherst as varchar(30),
@adcode as varchar(100),
@rodatetime as varchar(8),
@spacearea as varchar(8),
@vat as varchar(50),
@bookstat as varchar(25),
@cio_id as varchar(8),
@receipt_no as varchar(50),
@uom as varchar(8),
@bgcolor as varchar(10),
@validdate as varchar(10),
@agencyratecode as varchar(10),
@audit as varchar(8),
@book_insert_date as varchar(8),
@agencycomm as varchar(8),
@rateaudit as varchar(8),
@billaudit as varchar(8),
@billtype as varchar(8),
@invoice_no as varchar(50),
@copybooking as varchar(8),
@ratecompany as varchar(50),
@addagenycomm as varchar(50),
@agencycommlinkretainer as varchar(50),
@subeditionr as varchar(50),
@displaybilltype as varchar(50),
@classifiedbilltype as varchar(50),
@billformat as varchar(50),
@ratechk as varchar(50),
@allpkg as varchar(50),
@dayrate1 as varchar(50),
@schemetype as varchar(50),
@PIncludeclassi as varchar(50),
@receiptformat as varchar(50),
@cash_receipt as varchar(50),
@bill_orderwiselast as varchar(50),
@floor_chk as varchar(50),
@Unsoldflag as varchar(1),
@Supplystopper as varchar(10),
@drpRokeychk as varchar(1),
@Agencycomm_seq as varchar(1),
@creditreciept as varchar(1),
@cashindisplay as varchar(8),
@cashinclassified as varchar(8),
@rate_audit_pref as varchar(25),
@v_barcoding_allow as varchar(25),
@v_fmgbills AS VARCHAR(25),
@v_billed_cashdis as varchar(25),
@v_billed_cashcls as varchar(25),
@v_drpbackdate as varchar(25),
@dockitbooking as varchar(1),
@allowprevbooking as varchar(1),
@ro_wisecashbill as varchar(50),
@chkval as varchar(5),
@approval1 as varchar(50),
@pckstatus as varchar(3),
@cash_disc as varchar(1),
@cash_amt as varchar(10),
@seperate_cashier1 as varchar(10),
@disp_bill as varchar(1),
@clas_bill as varchar(1),
@mantimepost as varchar(1),
@bkdaypost as int,
@maxterutn as int,
@cir_return as varchar(1),
@noofchkbounc as int,
@noofdaychkrec as int,
@retday as int,
@chngsuppord as int,
@max_publishday as int,
@p_billno_period as varchar(15),
@spl_trans_edit as varchar(5),
@spl_dis_trans_editable as varchar(5),
@mul_pac_sel_trans as varchar(5),
@shmon_minword	as varchar(1),
@tradon_spcrg	as varchar(1),
@rateauth       as varchar(1),
@f2day as int,
@rateauditmodify as varchar(1),
@bindrevenuecenter as varchar(1),
@p_led_allow as varchar(2),
@p_clear_allow as varchar(2),
@repeatday as varchar(2),
@premiumedit as varchar(2),
@P_BILL_GENERATION as varchar(20),
@P_PUBLICATION_CENTER as varchar(50),
@P_allow_discount_prem as varchar(1),
@P_SCHEME_BILLING as varchar(50),
@P_ALLOW_PDC as varchar(50),
@PAD_TYPE_FOR_MANUL_BILL AS VARCHAR(20),
@RO_OUTSTAND_P AS VARCHAR(5),
@genrate_agency_code AS VARCHAR(5),
@p_dispauditbk AS VARCHAR(5),
@p_aotosupply  AS VARCHAR(5),
@p_Authorization as VARCHAR(1),
@p_CIR_AUTO_APPROVAL_UNSOLD AS VARCHAR(5),
@p_CIR_AUTO_PHYSICAL_UNSOLD AS VARCHAR(5),
@p_CIR_UNSOLD_INCLUDE_INCT AS VARCHAR(5),
@p_CIR_UNSOLD_INCLUDE_INSFEE AS VARCHAR(5),
@p_CIR_UNSOLD_ON_RECEIVED_DT AS VARCHAR(5),
@p_AGENCY_UNBLOCK_APPROVAL AS VARCHAR(5),
@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT AS VARCHAR(5),
@p_CIR_BILL_PUBLWISE AS VARCHAR(5),
@paging         AS VARCHAR(4000) ,
@print          AS VARCHAR(4000) ,
@allowpage      AS VARCHAR(4000) ,
@agency_req     AS VARCHAR(4000) ,
@region_req     AS VARCHAR(4000) ,
@p_ALLOW_FOLLOW_DT_BOOOK as varchar(1),
@p_CRM_SUPPLY_TYPE_PAID   as varchar(10),
@p_CRM_SUPPLY_TYPE_FREE   as varchar(10),
@p_CURRENCY_MEASUREMENT   as varchar(5),

@p_EDITABLE_AGENCY_COMM as varchar(1),
@p_CANCELLATION_CHARGE as varchar(1),
@P_taxi_entry_type     as VARCHAR(1),
@P_ApprovalWith          as VARCHAR(1),
@p_Auto_TDS_Credit_Note as varchar(1),
@p_TDS_Reason as varchar(10),
@p_Debit_Account_Head as varchar(10),
@p_credit_Account_Head as varchar(10),
@p_service_tax_credit_note as varchar(1),
@p_Tax_Reason as varchar(10),
@p_Debit_Account_Service_Tax as varchar(10),
@p_Credit_Account_Service_Tax as varchar(10),
@p_Auto_Patrakar_Credit_Note as varchar(1),
@p_Patrakar_Reason as varchar(10),
@p_Debit_Account_Patrakar as varchar(10),
@p_Credit_Account_Patrakar as varchar(10),
@p_Auto_Bank_Credit_Note as varchar(1),
@p_Bank_Reason as VARCHAR(10),
@p_Debit_Account_Bank as varchar(10),
@p_Credit_Account_Bank as varchar(10),
@P_BAR_CODE as VARCHAR(5),
@P_GEN_RCT_NO as VARCHAR(5),
@P_misdata as VARCHAR(5) =null,
@P_WEIGHT_CAL as VARCHAR(5) =null,
@P_allowpremium as varchar(5) =null,
@p_financecode as varchar(5) =null,
@p_exepub as varchar(5)=null,
@p_executivecreditlimit as varchar(5)=null,
--new add
@P_postdis as varchar(5) =null,
@P_suppdecreselimit as varchar(5) =null,
@P_allowvat as varchar(5) =null,
@P_alterroute as varchar(5) =null,
@P_showrecptag as varchar(5) =null,
@P_allowhoSUN as varchar(5) =null,
@P_allowhoMON as varchar(5) =null,
@P_allowhoTUE as varchar(5) =null,
@P_allowhoWED as varchar(5) =null,
@P_allowhoTHU as varchar(5) =null,
@P_allowhoFRI as varchar(5) =null,
@P_allowhoSAT as varchar(5) =null,
@P_autoinfo   as varchar(20) =null,
@Psap_id	  as varchar(20) =null,
@p_mrv   as varchar(1) =null,
@p_schhr	as	varchar(20)=null,
@p_ret_after_bank as varchar
AS
declare @query as varchar(8000)
declare @query1 as varchar(8000)
/*
set @query='update login set date_format='''+@dateformat+''' , Autogenerate='''+@code+''',curr_code='''+@curr+''' where com_code='''+@compcode+'''   '
exec(@query)

set @query1='update preferrences set RATE_COMPANY_AGENCY='''+@ratecompany+''',ADDITIONAL_AGENCY_COMM='''+@addagenycomm+''',
AGENCY_RETAINER_COMM='''+@agencycommlinkretainer+''',SUBEDITIONRATE='''+@subeditionr+''',DIS_BILLTYPE='''+@displaybilltype+''',
CLS_BILLTYPE='''+@classifiedbilltype+''',autogenerated='''+@code+''',currency_code='''+@curr+''' ,rate_gr_code='''+@ratecode+''' , 
date_format='''+@dateformat+''',solo='''+@solo+''',breakup='''+@breakup+''' ,blackwhitecode='''+@bwcode+''',  rostatus='''+@rostatus+''',
File_name='''+@filename+''',Tfn='''+@tfn+''',Insert_breakup='''+@insertbreak+''',Premium_type='''+@prem+''',Deal_type='''+@dealtype+'''  ,    
prefix='''+@pre+''', suffix='''+@suff+'''  ,     financestatus='''+ @financestatus+''' , voucherst='''+@voucherst+''',Ad_category='''+@adcode+''' ,
Ro_datetime='''+@rodatetime+''' ,Space_area='''+@spacearea+''',Vat='''+@vat+''' ,Booking_status='''+@bookstat+''' ,Cio_id='''+@cio_id+''',
Receipt_no='''+@receipt_no+''' ,uom_code='''+@uom+''',Bgcolor_publication='''+@bgcolor+''' ,chkfor_valid_pubdates='''+@validdate+''', 
Agency_ratecode='''+@agencyratecode+''',   audit='''+@audit+''', book_insert_date='''+@book_insert_date+''',agencycomm='''+@agencycomm+''',
rate_audit='''+@rateaudit+''',bill_audit='''+@billaudit+''', billtype='''+@billtype+''', invoice_no='''+@invoice_no+''' , 
copy_booking='''+@copybooking+''', BILLING_FORMAT='''+@billformat+''' , RATE_CHECK='''+@ratechk+''', ALL_PACKAGE='''+@allpkg+''',
DAYRATE='''+@dayrate1+''' ,SCHEME_TYPE='''+@schemetype+'''    ,DISP_CLSBILL='''+@PIncludeclassi+ '''  , RECEIPT_FORMAT ='''+@receiptformat+''',
CASH_RECEIPT_BILL='''+@cash_receipt+''', BILL_ORDERWSLAST='''+@bill_orderwiselast+''',FLOOR_CHK='''+@floor_chk+''' ,
Unsold_Entry_Flag='''+@Unsoldflag+''' ,Supply_Stop_Percentage='''+@Supplystopper+''',ROKEYCHECK='''+@drpRokeychk+''',
AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''',DISP_CASHBILL='''+@cashindisplay+''',
CLA_CASHBILL='''+@cashinclassified+''',RATE_AUDIT_PREF='''+@rate_audit_pref+''',BARCODING_ALLOWED='''+@v_barcoding_allow+''', 
FMG_BILL_DIS='''+@v_fmgbills+''',BILL_DISP_CASHBILL='''+@v_billed_cashdis +''',BILL_CLA_CASHBILL ='''+@v_billed_cashcls+''',
BACKDATERECEIPT='''+@v_drpbackdate+''',DOCKIT_BOOKING='''+@dockitbooking+''',Allowed_old_date='''+@allowprevbooking+''',
ROWISE_CASHBOOKING='''+@ro_wisecashbill+''' where    comp_code='''+@compcode+'''   ' 
*/
/*********************************************************************************************************/
UPDATE LOGIN SET date_format=@dateformat, Autogenerate=@code,curr_code=@curr WHERE COM_CODE=@compcode

UPDATE PREFERRENCES SET  autogenerated=@code,
currency_code=@curr ,
rate_gr_code=@ratecode,
date_format=@dateformat,solo=@solo,breakup=@breakup,
blackwhitecode=@bwcode,rostatus=@rostatus,File_name=@filename,Tfn=@tfn,
Insert_breakup=@insertbreak,Premium_type=@prem,Deal_type=@dealtype  ,
 prefix=@pre, suffix=@suff, financestatus=@financestatus , voucherst=@voucherst,
 Ad_category=@adcode ,Ro_datetime=@rodatetime ,Space_area=@spacearea,Vat=@vat,
 Booking_status=@bookstat,Cio_id=@cio_id,Receipt_no=@receipt_no,uom_code=@uom,
 Bgcolor_publication=@bgcolor ,chkfor_valid_pubdates=@validdate, Agency_ratecode=@agencyratecode,
  audit=@AUDIT,book_insert_date=@book_insert_date,agencycomm=@agencycomm,
  rate_audit=@rateaudit,bill_audit=@billaudit,billtype=@billtype,invoice_no=@invoice_no,
  copy_booking=@copybooking,RATE_COMPANY_AGENCY=@ratecompany, ADDITIONAL_AGENCY_COMM=@addagenycomm ,
  AGENCY_RETAINER_COMM=@agencycommlinkretainer,SUBEDITIONRATE=@subeditionr,
  CLS_BILLTYPE=@classifiedbilltype,DIS_BILLTYPE=@displaybilltype,BILLING_FORMAT=@billformat,
  RATE_CHECK=@ratechk,ALL_PACKAGE=@allpkg,dayrate=@dayrate1,SCHEME_TYPE=@schemetype,DISP_CLSBILL=@PIncludeclassi   ,
  CASH_RECEIPT_BILL=@cash_receipt, BILL_ORDERWSLAST=@bill_orderwiselast, FLOOR_CHK=@floor_chk ,
  Unsold_Entry_Flag=@Unsoldflag ,Supply_Stop_Percentage=@Supplystopper,ROKEYCHECK=@drpRokeychk ,
  AGENCYCOMM_SEQ_COM=@Agencycomm_seq ,CREDIT_RECIPT=@creditreciept,DISP_CASHBILL=@cashindisplay,
  CLA_CASHBILL=@cashinclassified,RATE_AUDIT_PREF=@rate_audit_pref,BARCODING_ALLOWED=@v_barcoding_allow,
  FMG_BILL_DIS =@v_fmgbills, BILL_DISP_CASHBILL=@v_billed_cashdis , BILL_CLA_CASHBILL=@v_billed_cashcls,BACKDATERECEIPT=@v_drpbackdate,DOCKIT_BOOKING=@dockitbooking,Allowed_old_date=@allowprevbooking,ROWISE_CASHBOOKING=@ro_wisecashbill,CUTOFFTIME=@chkval,APPROVAL=@approval1,back_days=@pckstatus,CASH_DISCOUNT=@cash_amt,CASH_DISCOUNTTYPE=@cash_disc,SEPRATE_CASHIER=@seperate_cashier1,
 CIR_MANY_TIME_POSTING=@mantimepost, CIR_BACKDAYS_POSTING=@bkdaypost, CIR_MAX_RETURN_ALLOW=@maxterutn, CIR_RETURN_LIMIT_ALLOW=@cir_return, CIR_NO_OF_CHQBOUNCE=@noofchkbounc, CIR_DAYS_CHQBOUNCE=@noofdaychkrec, CIR_RETURN_DAYS=@retday, CIR_SUP_ORDER_LIMIT=@chngsuppord, DISP_BILLING_CRITERIA=@disp_bill, CLSD_BILLING_CRITERIA=@clas_bill,MAX_PUBLISHDAYS=@max_publishday,
 BILLNO_PERIODICITY=@p_billno_period,SPECIALDISC_TRANS_EDIT=@spl_trans_edit, SHARING_TRANS=@spl_dis_trans_editable, MULTIPACKAGE_SEL_TRANS=@mul_pac_sel_trans,SCHEME_MINWORD=@shmon_minword, TRADE_SPLCHARGE=@tradon_spcrg,RATE_AUTHORIZATION=@rateauth
  ,F2_RECORD=@f2day,PUBLISHAD_EDIT_RATEAUDIT=@rateauditmodify,BINDREVENUE_CENTER=@bindrevenuecenter,
FA_LEDGER_ALLOW=@p_led_allow,CLEARANCE_TYPE_ALLOW=@p_clear_allow,REPEAT_DAY_TYPE=@repeatday,PREMIUM_EDIT=@premiumedit,

BILL_GENERATION_PRIOR=@P_BILL_GENERATION,PUBLICATION_HO=@P_PUBLICATION_CENTER,

SPLDISC_ALLOWPREM=@P_allow_discount_prem,BILL_SCHEME=@P_SCHEME_BILLING,

ALLOWED_PDC_DAYS_RECEIPT=@P_ALLOW_PDC,AD_TYPE_MANUL_BILL=@PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=@RO_OUTSTAND_P,GENRATE_CIR_AGCD=@genrate_agency_code,DISP_AUDITBKG=@p_dispauditbk,CIR_DIS_AUTO_POSTING=@p_aotosupply,RELAUTHREQON=@p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=@p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=@p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=@p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=@p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=@p_CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL=@p_AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE=@p_CIR_BILL_PUBLWISE,
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=@p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=@p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=@p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM =@p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE =@p_CANCELLATION_CHARGE,taxi_entry_type=@P_taxi_entry_type,APPROVAL_WITH =@P_ApprovalWith,

TDS_AUTO_CN=@p_Auto_TDS_Credit_Note,
TDS_AUTO_REASON=@p_TDS_Reason ,TDS_DB_CDP=@p_Debit_Account_Head,TDS_CR_CDP=@p_credit_Account_Head,SER_TAX_AUTO_CN=@p_service_tax_credit_note,SER_TAX_AUTO_REASON=@p_Tax_Reason,SER_TAX_DB_CDP=@p_Debit_Account_Service_Tax,SER_TAX_CR_CDP=@p_Credit_Account_Service_Tax,PKK_AUTO_CN=@p_Auto_Patrakar_Credit_Note,PKK_AUTO_REASON=@p_Patrakar_Reason ,PKK_DB_CDP=@p_Debit_Account_Patrakar,PKK_CR_CDP=@p_Credit_Account_Patrakar ,BANK_CHG_AUTO_CN=@p_Auto_Bank_Credit_Note ,
BANK_CHG_AUTO_REASON=@p_Bank_Reason ,BANK_CHG_DB_CDP=@p_Debit_Account_Bank ,BANK_CHG_CR_CDP=@p_Credit_Account_Bank,

 CIR_BARCODE= @P_BAR_CODE,CIR_WIEGHT_CALC_REQ= @P_WEIGHT_CAL,GEN_RCT_TYP = @P_GEN_RCT_NO,PRODUCT_BRAND_REQ=@P_misdata,ALLOWPREM_CARD_DISC_RATE=@P_allowpremium,FINANCE_CADE=@p_financecode,EXECUTIVE_PUBLICATION_VISE=@p_exepub,EXECUTIVECREDITLIMIT=@p_executivecreditlimit,
--NEW ADD
 CIR_POST_DIS=@P_postdis,
 CIR_VAT_ALLOW=@P_allowvat,
 CIR_SUP_ALT_ROUTE=@P_alterroute,
 SHOW_REC_ALL_AGENCY=@P_showrecptag,
 CIR_SUP_ORDER_DEC_LIMIT=@P_suppdecreselimit,
 CIR_ALLOW_HOLIDAY_SUN=@P_allowhoSUN,
 CIR_ALLOW_HOLIDAY_MON=@P_allowhoMON,       
 CIR_ALLOW_HOLIDAY_TUE=@P_allowhoTUE,
 CIR_ALLOW_HOLIDAY_WED=@P_allowhoWED,
 CIR_ALLOW_HOLIDAY_THU=@P_allowhoTHU,
 CIR_ALLOW_HOLIDAY_FRI=@P_allowhoFRI,
 CIR_ALLOW_HOLIDAY_SAT=@P_allowhoSAT,
 CRM_AUTOINFO=@P_autoinfo,
 SAP_ID=@Psap_id,
 MRV_BASED_ON =@p_mrv,
 SCHEDULING_HOURS=@p_schhr,
ALLOW_RET_AFTER_BANK=@p_ret_after_bank
 
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)




***********************************************************************************************************************


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go









ALTER PROCEDURE   [dbo].[wesp_submitdate1]

@compcode as varchar(15),
@userid as varchar(15),
@dateformat as varchar(15),
@code as varchar(4),
@curr as varchar(8),
@ratecode as varchar(8),
@solo  as varchar(15),
@breakup varchar(2),
@bwcode as varchar(8),
@rostatus as varchar(2),
@filename as varchar(2),
@tfn as int,
@insertbreak as varchar(2),
@prem as varchar(8),
@dealtype as varchar(2),
@pre as varchar(5),
@suff as varchar(5),
@financestatus as  char(2),
@voucherst as varchar(30),
@adcode as varchar(100),
@rodatetime as varchar(8),
@spacearea as varchar(8),
@vat as varchar(50),
@bookstat as varchar(25),
@cio_id as varchar(8),
@receipt_no as varchar(50),
@uom as varchar(8),
@bgcolor as varchar(10),
@validdate as varchar(10),
@agencyratecode as varchar(10),
@audit as varchar(8),
@book_insert_date as varchar(8),
@agencycomm as varchar(8),
@rateaudit as varchar(8),
@billaudit as varchar(8),
@billtype as varchar(8),
@invoice_no as varchar(50),
@copybooking as varchar(8),

@ratecompany as varchar(50),
@addagenycomm as varchar(50),
@agencycommlinkretainer as varchar(50),
@subeditionr as varchar(50),
@displaybilltype as varchar(50),
@classifiedbilltype as varchar(50),
@billformat as varchar(50),
@ratechk as varchar(50),
@allpkg as varchar(50),
@dayrate1 as varchar(50),
@schemetype as varchar(50),
@PIncludeclassi as varchar(50),
@receiptformat as varchar(50),
@v_cash_receipt as varchar(50),
@v_bill_orderwiselast  as varchar(50),
@v_floor_chk as varchar(50),
@Unsoldflag as varchar(1),
@Supplystopper as int,
@drpRokeychk as varchar(1),
@Agencycomm_seq as varchar(1),
@creditreciept as varchar(1),
@cashindisplay as varchar(8),
@cashinclassified  as varchar(8),
@rate_audit_pref as varchar(25),
@v_barcoding_allow as varchar(25),
@v_fmgbills AS VARCHAR(25),
@v_billed_cashdis as varchar(25),
@v_billed_cashcls as varchar(25),
@v_drpbackdate as varchar(25),
@dockitbooking as varchar(1),
@allowprevbooking as varchar(1),
@ro_wisecashbill as varchar(50),
@chkval as varchar(5),
@approval1 as varchar(50),
@pckstatus as varchar(3),
@cash_disc as varchar(1),
@cash_amt as varchar(10),

@p_repeatday as varchar(20),
@p_premiumedit as varchar(20),
@P_BILL_GENERATION as varchar(20),
@P_PUBLICATION_CENTER as varchar(50),
@P_allow_discount_prem AS VARCHAR(2),
@P_SCHEME_BILLING as varchar(20),
@P_ALLOW_PDC AS VARCHAR(20),
@PAD_TYPE_FOR_MANUL_BILL AS VARCHAR(20),
@p_ret_after_bank as varchar








AS
declare @query as varchar(900)

/*insert preferrences(comp_code,userid,rate_gr_code,autogenerated,currency_code,date_format,solo,breakup,blackwhitecode,rostatus,File_name,tfn,Insert_breakup,Premium_type,Deal_type,prefix,suffix,financestatus,voucherst,Ad_category,Ro_datetime,Space_area,Vat,Booking_status,Cio_id,Receipt_no,uom_code,Bgcolor_publication,chkfor_valid_pubdates,Agency_ratecode,audit,book_insert_date, agencycomm,rate_audit,bill_audit,billtype,invoice_no, copy_booking,RATE_COMPANY_AGENCY,ADDITIONAL_AGENCY_COMM,AGENCY_RETAINER_COMM,SUBEDITIONRATE,CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT,RATE_CHECK,ALL_PACKAGE,DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,Unsold_Entry_Flag,Supply_Stop_Percentage,ROKEYCHECK,AGENCYCOMM_SEQ_COM,CREDIT_RECIPT,DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF,BARCODING_ALLOWED,FMG_BILL_DIS,BILL_DISP_CASHBILL,BILL_CLA_CASHBILL,BACKDATERECEIPT,DOCKIT_BOOKING,Allowed_old_date,ROWISE_CASHBOOKING)
values(@compcode,@userid,@ratecode,@code,@curr,@dateformat,@solo,@breakup,@bwcode,@rostatus,@filename,@tfn,@insertbreak,@prem,@dealtype,@pre,@suff ,@financestatus,@voucherst,@adcode,@rodatetime,@spacearea,@vat,@bookstat,@cio_id,@receipt_no ,@uom,@bgcolor,@validdate,@agencyratecode,@audit, @book_insert_date, @agencycomm,@rateaudit,@billaudit,@billtype,@invoice_no,@copybooking,@ratecompany ,@addagenycomm,@agencycommlinkretainer,@subeditionr,@displaybilltype,@classifiedbilltype,@billformat,@ratechk,@allpkg,@dayrate1,@schemetype,@PIncludeclassi,@receiptformat,@v_cash_receipt,@v_bill_orderwiselast,@v_floor_chk,@Unsoldflag,@Supplystopper,@drpRokeychk,@Agencycomm_seq,@creditreciept,@cashindisplay,@cashinclassified,@rate_audit_pref,@v_barcoding_allow,@v_fmgbills,@v_billed_cashdis,@v_billed_cashcls,@v_drpbackdate ,@dockitbooking ,@allowprevbooking,@ro_wisecashbill)
*/

INSERT INTO PREFERRENCES(comp_code,userid,rate_gr_code,autogenerated,currency_code,date_format,solo,breakup,blackwhitecode,rostatus,File_name,Tfn,Insert_breakup,Premium_type,Deal_type,prefix,suffix,financestatus,voucherst,Ad_category,Ro_datetime,Space_area,Vat,Booking_status,Cio_id,Receipt_no,uom_code,Bgcolor_publication,chkfor_valid_pubdates,Agency_ratecode,audit,book_insert_date,agencycomm,rate_audit,bill_audit,billtype,invoice_no,copy_booking,RATE_COMPANY_AGENCY,ADDITIONAL_AGENCY_COMM,AGENCY_RETAINER_COMM,SUBEDITIONRATE,CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT,RATE_CHECK,ALL_PACKAGE,DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,Unsold_Entry_Flag,Supply_Stop_Percentage,ROKEYCHECK,AGENCYCOMM_SEQ_COM,CREDIT_RECIPT,DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF,BARCODING_ALLOWED,FMG_BILL_DIS,BILL_DISP_CASHBILL, BILL_CLA_CASHBILL,BACKDATERECEIPT,DOCKIT_BOOKING,Allowed_old_date,ROWISE_CASHBOOKING,CASH_DISCOUNT,CASH_DISCOUNTTYPE,REPEAT_DAY_TYPE,PREMIUM_EDIT,BILL_GENERATION_PRIOR,PUBLICATION_HO,SPLDISC_ALLOWPREM,BILL_SCHEME,ALLOWED_PDC_DAYS_RECEIPT,AD_TYPE_MANUL_BILL,ALLOW_RET_AFTER_BANK)
VALUES(@compcode,@userid,@ratecode,@code,@curr,@dateformat,@solo,@breakup,@bwcode,@rostatus,@filename,@tfn,@insertbreak,@prem,@dealtype,@pre,@suff ,@financestatus,@voucherst,@adcode,@rodatetime,@spacearea,@vat,@bookstat,@cio_id,@receipt_no,@uom,@bgcolor,@validdate,@agencyratecode,@audit,@book_insert_date,@agencycomm,@rateaudit,@billaudit,@billtype,@invoice_no,@copybooking,@ratecompany,@addagenycomm,@agencycommlinkretainer,@subeditionr,@classifiedbilltype,@displaybilltype,@billformat,@ratechk,@allpkg,@dayrate1,@schemetype,@PIncludeclassi,@receiptformat,@v_cash_receipt,@v_bill_orderwiselast,@v_floor_chk,@Unsoldflag,@Supplystopper,@drpRokeychk,@Agencycomm_seq,@creditreciept,@cashindisplay,@cashinclassified,@rate_audit_pref,@v_barcoding_allow,@v_fmgbills,@v_billed_cashdis,@v_billed_cashcls,@v_drpbackdate,@dockitbooking,@allowprevbooking,@ro_wisecashbill,@cash_amt,@cash_disc,@p_repeatday,@p_premiumedit,@P_BILL_GENERATION,@P_PUBLICATION_CENTER,@P_allow_discount_prem,@P_SCHEME_BILLING,@P_ALLOW_PDC,@PAD_TYPE_FOR_MANUL_BILL,@p_ret_after_bank)



--set @query='update login set date_format='''+@dateformat+''' , Autogenerate='''+@code+''',curr_code='''+@curr+''' where com_code='''+@compcode+'''   '
--set @query='update preferrences set  autogenerated='''+@code+''',currency_code='''+@curr+''' ,rate_gr_code='''+@ratecode+''' where comp_code='''+@compcode+'''  '

print(@query)
exec(@query)










/****************update by dhananjay for edition master********************************/
/*************************procedure****************************/
create  procedure  [dbo].[editiontxtsave]
(
@editoncode varchar(50),
@compcode varchar(50),
@userid varchar(50),
@txtsun varchar(200),
@txtmon varchar(200),
@txttue varchar(200),
@txtwed varchar(200),
@txtthu varchar(200),
@txtfri varchar(200),
@txtsat varchar(200)
)
as
insert into SELECT_EDITION_TXT values(@compcode,@editoncode,@txtsun,@txtmon,@txttue,@txtwed,@txtthu,@txtfri,@txtsat,@userid)

exec  websp_Insert_package @editoncode 

/*************************end****************************/

/*************************procedure****************************/
create  procedure  [dbo].[editiontxtmodify]
(
@editioncode varchar(50),
@compcode varchar(50),
@userid varchar(50),
@txtsun varchar(200),
@txtmon varchar(200),
@txttue varchar(200),
@txtwed varchar(200),
@txtthu varchar(200),
@txtfri varchar(200),
@txtsat varchar(200)
)
as
update  SELECT_EDITION_TXT set txtsun=@txtsun,txtmon=@txtmon,txttue=@txttue,txtwed=@txtwed,txtthu=@txtthu,txtfri=@txtfri,txtsat=@txtsat where comp_code=@compcode and edition_code=@editioncode -- and userid=@userid

/*************************end****************************/

/*************************procedure****************************/
create procedure [dbo].[checkedtiontxt]
(
@compcode varchar(8),
@editoncode varchar(8),
@userid varchar(8)
)
as 
begin
select COMP_CODE,EDITION_CODE,TXTSUN,TXTMON,TXTTUE,TXTWED,TXTTHU,TXTFRI,TXTSAT,USERID,TEMP_ID from SELECT_EDITION_TXT where comp_code=@compcode and edition_code=@editoncode 

end

/*************************end****************************/

/*************************procedure****************************/
ALTER PROCEDURE  [dbo].[websp_editordelete]

@EditonCode as varchar(8),
@userid as varchar(8),
@compcode as varchar(8)

as
declare @countnum int
select @countnum=count(*) from tbl_booking_insert where edition_code=@EditonCode
if @countnum=0 
begin
delete from EDITION_MAST where Edition_Code=@EditonCode and  Comp_Code=@compcode --and UserId=@userid 

--delete from EDITION_MASTTEMP where Edition_Code=@EditonCode and Comp_Code=@compcode --and UserId=@userid

delete from SELECT_EDITION_DAY where Edition_Code=@EditonCode and Comp_Code=@compcode --and UserId=@userid

delete from edit_date where Comp_Code=@compcode  and Edition_Code=@EditonCode --and editdate_code=@code10 --and UserId=@userid

delete from SELECT_EDITION_TXT where Edition_Code=@EditonCode and Comp_Code=@compcode --and UserId=@userid
end

--select * from  EDITION_MASTTEMP  order by  Edition_Code

/*************************end****************************/

/**********************END edition master************************/



/****************update by dhananjay for ad category master********************************/
/*************************procedure****************************/
create procedure [dbo].[slelectadcattxtsave]
(
@adcatcode varchar(8),
@compcode varchar(8),
@userid varchar(8),
@txtsun varchar(100),
@txtmon varchar(100),
@txttue varchar(100),
@txtwed varchar(100),
@txtthu varchar(100),
@txtfri varchar(100),
@txtsat varchar(100)
)
as
begin
insert into Select_AdvCat_txt values(@compcode,@adcatcode,@txtsun,@txtmon,@txttue,@txtwed,@txtthu,@txtfri,@txtsat,@userid)

end
/*************************end****************************/

/*************************procedure****************************/
create  procedure [dbo].[slelectadtxtmodify]
(
@adcatcode varchar(8),
@compcode varchar(8),
@userid varchar(8),
@txtsun varchar(100),
@txtmon varchar(100),
@txttue varchar(100),
@txtwed varchar(100),
@txtthu varchar(100),
@txtfri varchar(100),
@txtsat varchar(100)
)
as
begin
update  Select_AdvCat_txt set txtsun=@txtsun,txtmon=@txtmon,txttue=@txttue,txtwed=@txtwed,txtthu=@txtthu,txtfri=@txtfri,txtsat=@txtsat where comp_code=@compcode and Adv_Cat_Code=@adcatcode
end

/*************************end****************************/

/*************************procedure****************************/
create procedure [dbo].[checkadtxt]
@compcode varchar(8),
@adcatcode varchar(8),
@userid varchar(8)
as 
begin
select COMP_CODE,ADV_CAT_CODE,TXTSUN,TXTMON,TXTTUE,TXTWED,TXTTHU,TXTFRI,TXTSAT,USERID,TEMP_ID from Select_AdvCat_txt where comp_code=@compcode and Adv_Cat_Code=@adcatcode
end
/*************************end****************************/

/*************************procedure****************************/
ALTER PROCEDURE [dbo].[advcatdel]

@compcode as varchar(8),
--@userid as varchar(8),
@adcatcode as varchar(8)

AS
declare @countnum int
declare @countnum1 int
select @countnum=count(*) from tbl_booking_insert where ad_cat=@adcatcode
select @countnum1=count(*) from rate_mast where adv_cat_code=@adcatcode
if @countnum=0 and  @countnum1=0
begin
 delete from adv_cat_mast where comp_code=@compcode /*and userid=@userid*/ and adv_cat_code=@adcatcode


-- delete from advdummy where comp_code=@compcode /*and userid=@userid*/ and adv_cat_code=@adcatcode

delete from CategoryWiseEdition where comp_code=@compcode /*and userid=@userid*/ and Adv_Cat_Code=@adcatcode

delete from select_AdvCat_day where comp_code=@compcode /*and userid=@userid*/ and adv_cat_code=@adcatcode


delete from Select_AdvCat_txt where comp_code=@compcode /*and userid=@userid*/ and adv_cat_code=@adcatcode
end
/*************************end****************************/

/**********************END ad category master************************/

///////////start by shipra issue no 9143//////////////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[websp_saveagent]    Script Date: 11/09/2012 10:36:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE  [dbo].[websp_saveagent]

@compcode as varchar(25),
@agencytype as varchar(25),
@agentcategory as varchar(25),
@agentcategory2 varchar(50),
@agentcode as varchar(25),
@agentname as varchar(50),
@alias as varchar(50),
@agencyho as varchar(25),
@txtfax1 as varchar(15),
@address as varchar(50),
@street as varchar(50),
@city varchar(50),
@zip as varchar(25),
@district as varchar(50),
@state as varchar(50),
@country as varchar(25),
@phone as varchar(25),

@fax varchar(50),
@mail as varchar(50),
@url as varchar(50),
@bussinessstartdate as DATETIME,
@enrolldate as DATETIME,
@novts as varchar(25),
@credit as varchar(25),
@pan as varchar(25),
@tan as varchar(25),
@stacno as varchar(25),
@paymode as varchar(25),
--@statusdrp as varchar(25),
@status as varchar(250),
@remarks as varchar(200),
@userid as varchar(10),

@mrerefferenceno as varchar(50),
@subagencyho as varchar(10),

@agencycode as varchar(8),
@billto as varchar(50),
@alert as varchar(200),
@creditlimit as varchar(10),
@code as varchar(16),
@representative as varchar(10),
@pin as varchar(15),
@region as varchar(25),
@type as varchar(5),
@zone as varchar(8),
@address1 as varchar(50),
@address2 as varchar(50),
@curtype as varchar(8),
@acagen as varchar(12),
@rategrp as varchar(8),
@qbcuserid as varchar(50),
@taluka as varchar(50),
@branchcode    as varchar(20),
@hddistcode as varchar(50),
@hdstatecode    as varchar(20),
@billf as varchar(8),
@oldagency as varchar(50),
@booktype as varchar(100),
@vat as varchar(1),
@p_raterevise as varchar(5),
@p_editionwisebilling as varchar(2),
@p_executive as varchar(50),
@email as varchar(1),
@age_desig as varchar(50)
--@bank as varchar(30),
--@validitydate as DATETIME




AS

--insert into Agency_mast(Comp_Code,Agency_Type_Code,Agency_Cat_Code,Agency_SubCat_Code,Agency_Code,Agency_Name,Agency_Alias,Agency_HO,Add1,Street,City_Code,Zip,Dist_Code,State_Code,Country_Code,Phone,Fax,EmailID,URL,Buss_Start_Date,Enroll_Date,MRV_Ref_No,No_of_VTS,Credit_Days ,PAN_No,TAN_No,ST_ACC_No,Pay_Mode_Code,Agency_Status,Status_Reason,Remarks,UserID,Creation_Datetime,SUB_Agency_HO,SUB_Agency_Code,BILL_TO,ALERT,CREDIT_LIMIT,CODE,representative_code,pin_code) values (@compcode,@agencytype,@agentcategory,@agentcategory2,@agentcode,@agentname,@alias,@agencyho,@address,@street,@city,@zip,@district,@state,@country,@phone,@mail,@fax,@url,@bussinessstartdate,@enrolldate,@mrerefferenceno,@novts,@credit,@pan,@tan,@stacno,@paymode,@statusdrp,@status,@remarks,@userid,@statusdate,@subagencyho,@agencycode,@billto,@alert ,@creditlimit,@code,@representative,@pin)
insert into Agency_mast(Comp_Code,Agency_Type_Code,Agency_Cat_Code,Agency_SubCat_Code,Agency_Code,Agency_Name,Agency_Alias,Agency_HO,Add1,     Street,City_Code,Dist_Code,State_Code,Country_Code,Phone,Fax,EmailID,URL,Buss_Start_Date,     Enroll_Date,MRV_Ref_No,      No_of_VTS,Credit_Days ,PAN_No,TAN_No,ST_ACC_No,Pay_Mode_Code,Status_Reason,Remarks, UserID, SUB_Agency_HO,SUB_Agency_Code,acagency,ALERT, CREDIT_LIMIT, CODE, representative_code,pin_code,region, type, code_subcode,          zone_code,Add2,     Add3,     CREDIT_TYPE,BILL_TO,fax1,    Rate_Group, qbc_userid,TALUKA,   zip,Branch_code,DISTRICT,    STATE,      BILL_FREQUENCY,OLD_AGENCY,BOOKING_TYPE,VAT,RATE_REVISE,EDTN_WISE_BILL_REQ,EXECUTIVE,BILL_EMAIL,AGENCY_DESIGNATION) values 
						(@compcode,@agencytype,    @agentcategory, @agentcategory2,   @agentcode, @agentname, @alias,      @agencyho,@address,@street,@city,    @district,@state,    @country,    @phone,@fax,@mail,@url,@bussinessstartdate,@enrolldate,@mrerefferenceno,@novts,   @credit,     @pan,  @tan,  @stacno,  @paymode,     @status,      @remarks,@userid,@subagencyho, @agencycode,    @acagen, @alert ,@creditlimit,@code,@representative,    @pin,    @region,@type,@agentcode+@agencycode,@zone,    @address1,@address2,@curtype,   @billto,@txtfax1,@rategrp,   @qbcuserid, @taluka,@zip,@branchcode,@hddistcode,@hdstatecode,@billf,        @oldagency,@booktype,   @vat,@p_raterevise,@p_editionwisebilling,@p_executive,@email,@age_desig)
						
/* TO INSERT DATA IN AGENCY HISTORY LOG*/

 INSERT INTO AGENCY_REMARK_DETAIL(COMP_CODE, AGENCY_CODE, SUB_AGENCY_CODE, CODE_SUBCODE, AGENCY_ALERT, AGENCY_REMARK, USERID)
        VALUES(@compcode,@agentcode,@agencycode,@agentcode + @agencycode,@alert,@remarks,@userid);




















USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[websp_executeagency]    Script Date: 11/09/2012 10:37:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[websp_executeagency]

@compcode as varchar(9),
@userid as varchar(9),
@agentcode as varchar(12),
@subagencycode as varchar(15),
@agencyname1  as varchar(50),
@alias as varchar(30),
@agenttype as varchar(12),
@agentcategory as varchar(12),
@agentsubcategory as varchar(12),
@city as varchar(12),
@count as varchar(12),
@branchcode    as varchar(20),
@billf as varchar(8)

AS

--Comp_Code,Agency_Type_Code,Agency_Cat_Code,Agency_SubCat_Code,Agency_Code,Agency_Name,Agency_Alias,Agency_HO,Add1,Street,City_Code,Zip,Dist_Code,State_Code,Country_Code,Phone,Fax,EmailID,URL,Buss_Start_Date,Enroll_Date,MRV_Ref_No,No_of_VTS,Credit_Days ,PAN_No,TAN_No,ST_ACC_No,Pay_Mode_Code,Agency_Status,Status_Reason,Remarks,UserID,Creation_Datetime,SUB_Agency_HO,SUB_Agency_Code
declare @query as varchar(2100)

declare @comp as varchar(10)
declare @agencytycode as varchar(10)
declare @agencycatcode as varchar(10)
declare @agencysubcat as varchar(10)
declare @agencycod as varchar(10)
declare @agencyname as varchar(30)
declare @agencyalias as varchar(30)
declare @agencyho  as varchar(15)
declare @add as varchar(30)
declare @agencystreet as varchar(30)
declare @agencycity as varchar(10)
declare @agencyzip as varchar(10)
declare @agencudistt as varchar(10)
declare @agencystate as varchar(10)
declare @agencycountry as varchar(10)
declare @agencyphone as varchar(10)
declare @fax as varchar(10)
declare @mail as varchar(20)
declare @url as varchar(20)
declare @buss as VARCHAR(20)
declare @enroll as VARCHAR(20)
declare @mrv as varchar(10)
declare @nov as varchar(10)
declare @credit as varchar(10)
declare @pan as varchar(10)
declare @tan as varchar(10)
declare @st as varchar(10)
declare @pay as varchar(10)
declare @status as varchar(10)
declare @reason as varchar(200)
declare @remarks as varchar(200)
declare @user as varchar(10)
declare @date as varchar(20)
declare @use as varchar(10)
declare @subagencyho as varchar(10)
declare @sagencode as varchar(10)
declare @bill as varchar(10) 
declare @alert as varchar(200)
declare @crlimit as varchar(10)
declare @cod as varchar(10)
declare @repcode as varchar(10)
declare @pin as varchar(10)
declare @region as varchar(10)
declare @todate as varchar(10)
declare @query1 as varchar(1000)
declare @firstagencycode as varchar(100)
declare @agen as varchar(100)
declare @check as varchar(900)




declare @agencycode as varchar(100)
declare @abc as varchar(100)
DECLARE @AuthorID char(11)
declare @query5 as varchar(1000)
declare @query6 as varchar(1000)
declare @xx as varchar(1000)

declare @agencyname2 as varchar(50)

declare @agentcode1 as varchar(12)

declare @subagencycode1 as varchar(15)

declare @alias1 as varchar(30)

declare @vat as varchar(1)

CREATE TABLE #first (
	Comp_Code varchar (50)  ,
	Agency_Type_Code varchar (50)  ,
	Agency_Cat_Code varchar (50)  ,
	Agency_SubCat_Code varchar (50)  ,
	Agency_Code varchar (50)  ,
	Agency_Name varchar (50)  ,
	Agency_Alias varchar (50)  ,
	Agency_HO varchar (50)  ,
	Add1 varchar (50)  ,
	Street varchar (50)  ,
	City_Code varchar (50)  ,
	Zip varchar (50)  ,
	Dist_Code varchar (50)  ,
	State_Code varchar (50)  ,
	Country_Code varchar (50)  ,
	Phone varchar (50)  ,
	Fax varchar (50)  ,
	EmailID varchar (50)  ,
	URL varchar (50)  ,
	Buss_Start_Date datetime NULL ,
	Enroll_Date datetime NULL ,
	MRV_Ref_No varchar (50)  ,
	No_of_VTS varchar (50)  ,
	Credit_Days varchar (50)  ,
	PAN_No varchar (50)  ,
	TAN_No varchar (50)  ,
	ST_ACC_No varchar (50)  ,
	Pay_Mode_Code varchar (50)  ,
	status_name varchar (50)  ,
	Status_Reason varchar (500)  ,
	Remarks varchar (500)  ,
	UserID varchar (50)  ,
	current_Datetime datetime NULL ,
	users varchar (50)  ,
	SUB_Agency_HO varchar (50)  ,
	SUB_Agency_Code varchar (50)  ,
	BILL_TO varchar (50)  ,
	ALERT varchar (500)  ,
	CREDIT_LIMIT varchar (50)  ,
	CODE varchar (50)  ,
	representative_code varchar (50)  ,
	pin_code varchar (50)  ,
	region varchar (50)  ,
	to_date datetime NULL ,
	Type varchar (5)  ,
	code_subcode varchar (16)  ,
	zone_code varchar (8)  ,
	Add2 varchar (50)  ,
	Add3 varchar (50)  ,
	CREDIT_TYPE varchar (8)  ,
	acagency varchar (12)  ,
	fax1 varchar (15) ,
	Rate_Group varchar(8) ,
	qbc_userid varchar(50),
    TALUKA varchar(8),
    Branch_code varchar(20),
	billf varchar(8),
    VAT varchar(1)
)



set @agencyname2= replace(@agencyname1,'''','''')

set  @agentcode1=  replace(@agentcode ,'''','''')

set @subagencycode1=replace(@subagencycode,'''','''')

set @alias1=replace(@alias,'''','''')


--set @query=' insert  #first select a.Comp_Code,a.Agency_Type_Code,a.Agency_Cat_Code,a.Agency_SubCat_Code,a.Agency_Code,a.Agency_Name,a.Agency_Alias,a.Agency_HO,a.Add1,a.Street,a.City_Code,a.Zip,a.Dist_Code,a.State_Code,a.Country_Code,a.Phone,a.Fax,a.EmailID,a.URL,a.Buss_Start_Date,a.Enroll_Date,a.MRV_Ref_No,a.No_of_VTS,a.Credit_Days ,a.PAN_No,a.TAN_No,a.ST_ACC_No,a.Pay_Mode_Code,,a.Status_Reason,a.Remarks,a.UserID,getdate(),a.userid,a.SUB_Agency_HO,a.SUB_Agency_Code,a.BILL_TO,a.ALERT,a.CREDIT_LIMIT,a.CODE,a.representative_code,a.pin_code,a.region ,,a.type, a.code_subcode,a.zone_code,a.add2,a.add3,a.CREDIT_TYPE,a.acagency,a.fax1, a.Rate_Group,a.qbc_userid, a.TALKUA from Agency_mast a where a.userid='''+@userid+''' and a.comp_code='''+@compcode+''' '
set @query='SELECT Comp_Code, Agency_Type_Code, Agency_Cat_Code,  Agency_SubCat_Code, Agency_Code, Agency_Name AS Agency_Name,Agency_Alias, Agency_HO, Add1, Street, City_Code,
                Zip, Dist_Code, State_Code, Country_Code, Phone,
                Fax, EmailID, URL, Buss_Start_Date, Enroll_Date,
                MRV_Ref_No, No_of_VTS, Credit_Days, PAN_No, TAN_No,
                ST_ACC_No, Pay_Mode_Code,
                (SELECT top 1 status_name FROM STATUS_DETAIL WHERE comp_code='''+@compcode+''' and  STATUS_DETAIL.agency_code+STATUS_DETAIL.agency_subcat_code = AGENCY_MAST.code_subcode) AS status_name,
                Status_Reason, Remarks, UserID, getdate() AS current_Datetime, UserID,
                SUB_Agency_HO AS SUB_Agency_HO, SUB_Agency_Code AS SUB_Agency_Code, BILL_TO, ALERT,
                CREDIT_LIMIT, CODE, Representative_code as representative_code, pin_code, region,
                (SELECT top 1 TO_DATE FROM STATUS_DETAIL
                  WHERE  agency_code = AGENCY_MAST.Agency_Code) AS to_date,
                (SELECT top 1 FROM_DATE FROM STATUS_DETAIL
                  WHERE  agency_code = AGENCY_MAST.Agency_Code) AS FROM_DATE,
                Type, code_subcode, zone_code, Add2, Add3,
                CREDIT_TYPE, acagency, fax1, Rate_Group,
                qbc_userid,(select DEPO_CODE from ad_user where ad_user.AGENCY_CODE=agency_mast.code_subcode) AS DEPOCODE,
                (select AGENCY_CODE from ad_user where ad_user.AGENCY_CODE=agency_mast.code_subcode) AS AGENCYCODE,TALUKA ,Branch_code,(select dist_mst.Dist_Name from dist_mst where dist_mst.Dist_Code=agency_mast.DISTRICT) as DISTRICT,(select state_mst.State_Name from state_mst where state_mst.State_Code=agency_mast.STATE) as STATE,BILL_FREQUENCY,OLD_AGENCY,BOOKING_TYPE,VAT,RATE_REVISE,EDTN_WISE_BILL_REQ,BILL_EMAIL,AGENCY_DESIGNATION FROM AGENCY_MAST  where comp_code='''+@compcode+''' '

if(@agentcode1 <> '')
begin

set @query= @query + 'and  agency_code  like ''%'+@agentcode1+'%'''
end



if(@subagencycode1 <> '')
begin

set @query  =  @query + 'and SUB_Agency_Code like ''%'+@subagencycode1+'%'' '
end



if(@agencyname2 <> '')
begin

set @query  =  @query + 'and Agency_Name like ''%'+@agencyname2 +'%'''
end

if(@alias1 <> '')
begin

set @query  =  @query + 'and Agency_Alias  like ''%'+@alias1 +'%'''
end



if(@agenttype <> '' and @agenttype <> '0')
begin

set @query  =  @query + 'and agency_type_code  like ''%'+@agenttype +'%'''
end


if(@agentcategory <> '' and @agentcategory <> '0')
begin

set @query  =  @query + 'and agency_type_code  like ''%'+@agentcategory +'%'''
end





if(@agentsubcategory <> '' and @agentsubcategory <> '0')
begin

set @query  =  @query + 'and Agency_Cat_Code  like ''%'+@agentsubcategory +'%'''
end



if(@city <> '' and @city <> '0')
begin

set @query  =  @query + 'and City_Code  like ''%'+@city +'%'''
end


if(@count <> '' and @count <> '0')
begin

set @query  =  @query + 'and Country_Code  like ''%'+@count +'%'''
end

if(@branchcode <> '' and @branchcode <> '0')
begin

set @query= @query + 'and  Branch_code  like ''%'+@branchcode+'%'''
end
if(@billf <> '' and @billf <> '0')
begin

set @query  =  @query + 'and BILL_FREQUENCY  like ''%'+@billf +'%'''
end

print(@query)
exec(@query)

DECLARE c1 CURSOR READ_ONLY
FOR
select  sub_agency_code from first order by sub_agency_code

OPEN c1

FETCH NEXT FROM c1
INTO @AuthorID

WHILE @@FETCH_STATUS = 0
BEGIN

	--PRINT @AuthorID

	









--set @query='select     top 1   @xx= status_name ,agency_code   from status_detail where agency_code='''+@AuthorID+''' order by current_datetime desc,agency_code'

set @query5='update #first set status_name= (select     top 1    status_name    from status_detail where agency_subcat_code='''+@AuthorID+''' order by current_datetime   )   where sub_agency_code='''+@AuthorID+''''

set @query6='update #first set to_date= (select     top 1    to_date    from status_detail where agency_subcat_code='''+@AuthorID+'''  order by current_datetime   )   where sub_agency_code='''+@AuthorID+''''

print(@xx)
exec(@xx)
print(@query5)
exec(@query5)

print(@query6)
exec(@query6)
FETCH NEXT FROM c1
	INTO @AuthorID


END

CLOSE c1
DEALLOCATE c1








select   distinct  *  from #first  order by agency_code
drop table #first






















USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[websp_agencymodify]    Script Date: 11/09/2012 10:38:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE  [dbo].[websp_agencymodify]

@compcode as varchar(25),
@agencytype as varchar(25),
@agentcategory as varchar(25),
@agentcategory2 varchar(50),
@agentcode as varchar(25),
@agentname as varchar(50),
@alias as varchar(50),
@agencyho as varchar(25),
@type as varchar(5),
@address as varchar(25),
@street as varchar(25),
@city varchar(50),
@zip as varchar(25),
@district as varchar(25),
@state as varchar(25),
@country as varchar(25),
@phone as varchar(25),
@txtfax2 as varchar(15),
@fax varchar(50),
@mail as varchar(25),
@url as varchar(25),
@bussinessstartdate as DATETIME,
@enrolldate as DATETIME,
@novts as varchar(25),
@credit as varchar(25),
@pan as varchar(25),
@tan as varchar(25),
@stacno as varchar(25),
@paymode as varchar(25),

@status as varchar(250),
@remarks as varchar(200),
@userid as varchar(10),

@mrerefferenceno as varchar(50),
@subagencyho as varchar(10),

@agencycode as varchar(8),
@billto as varchar(50),
@alert as varchar(200),
@creditlimit as varchar(10),
@code as varchar(12),
@region as varchar(10),
@representative as varchar(10),
@pincode as varchar(12),
@stacno1 as varchar(25),
@zone as varchar(8),

@address1 as varchar(50),
@address2 as varchar(50),
@curtype as varchar(8),
@acagen as varchar(8),
@rategrp as varchar(8),
@qbcuserid as varchar(50),
@depocode as varchar(8),
@taluka as varchar(50),
@branchcode    as varchar(20),
@hddistcode as varchar(50),
@hdstatecode    as varchar(20),
@billf as varchar(8),
@oldagen as varchar(50),
@booktype as varchar(100),
@vat as varchar(1),
@p_raterevise as varchar(5),
@p_insertremarkdet as varchar(5),
@p_editionwisebilling as varchar(2),
@p_executive as varchar(50),
@email as varchar(1),
@age_desig as varchar(100)

AS
declare @query as varchar(2000)
declare @query1 as varchar(2000)

update Agency_mast set Rate_Group=@rategrp, Agency_Code=@agentcode , fax1=@txtfax2,CREDIT_TYPE=@curtype, zone_code=@zone,  type=@type, Agency_Type_Code=@agencytype,Agency_Cat_Code=@agentcategory,Agency_SubCat_Code=@agentcategory2,Agency_Name=@agentname,Agency_Alias=@alias,Agency_HO=@agencyho,Add1=@address,Street=@street,City_Code=@city,Zip=@zip,Dist_Code=@district,State_Code=@state,Country_Code=@country,Phone=@phone,Fax=@fax,EmailID=@mail,URL=@url,Buss_Start_Date=@bussinessstartdate,Enroll_Date=@enrolldate ,MRV_Ref_No=@mrerefferenceno,No_of_VTS=@novts,Credit_Days=@credit,PAN_No=@pan,TAN_No=@tan,ST_ACC_No=@stacno1,Pay_Mode_Code=@paymode,Status_Reason=@status,Remarks=@remarks,SUB_Agency_HO=@subagencyho,SUB_Agency_Code=@agencycode ,BILL_TO =@acagen, acagency=@billto,ALERT=@alert,credit_limit=@creditlimit,code=@code ,region=@region,representative_code=@representative,pin_code=@pincode,Add2=@address1,Add3=@address2,qbc_userid=@qbcuserid , TALUKA=@taluka , Branch_code=@branchcode, DISTRICT=@hddistcode,STATE=@hdstatecode,BILL_FREQUENCY=@billf,OLD_AGENCY=@oldagen,BOOKING_TYPE=@booktype,VAT=@vat,RATE_REVISE=@p_raterevise,EDTN_WISE_BILL_REQ =@p_editionwisebilling,EXECUTIVE=@p_executive,BILL_EMAIL=@email,AGENCY_DESIGNATION=@age_desig
where Comp_Code=@compcode  AND Agency_Code= @agentcode and SUB_Agency_Code=@agencycode

/* TO INSERT DATA IN AGENCY HISTORY LOG*/
        IF(@p_insertremarkdet = '1') Begin
                 INSERT INTO AGENCY_REMARK_DETAIL(COMP_CODE, AGENCY_CODE, SUB_AGENCY_CODE, CODE_SUBCODE, AGENCY_ALERT, AGENCY_REMARK, USERID)
                        VALUES(@compcode,@agentcode,@agencycode,@agentcode + @agencycode,@alert,@remarks,@userid);
                        
        END 
/*
print(@query)
exec(@query)
print(@query1)
exec(@query1)*/

//////////////////////////////////////////////////////////////////






///////////////************issue 9051 and 23-nov-2012******************////////////////

                                                                     
                                                                     
                                                                     
                                             
create PROCEDURE rate_expiry
@compcode      as varchar(200),
@adtypcod      as varchar(200), 
@ratecod       as varchar(200),
@categrycod    as varchar(200),
@colorcod      as varchar(200),
@uomcod        as varchar(200),
@frdate        as varchar(200),
@todate        as varchar(200),
@packgcod      as varchar(200),
@extra1        as varchar(200),
@extra2        as varchar(200),
@p_solo        as varchar(200),
@pedtn_flag    as varchar(200)--m for main,e for edition ,s for suppliment and a for all
as

Begin
 -- advpos_prem_mast
IF isnull (@p_solo, '') = 'S' Begin
    If @pedtn_flag='M' Begin
        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=isnull(@adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=isnull(@ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=isnull(@categrycod,"Adv_Cat_Code")
        and "Color" =isnull(@colorcod,"Color") and "Uom"   =isnull(@uomcod,"Uom")
        and ("Combin_Code"=@packgcod or @packgcod is null)
        and ("Valid_From"=@frdate and "Valid_To"=@todate) 
        and exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=Rate_Mast."combin_desc" and 
        (("Edition_Type"='Main Edition' and @pedtn_flag='M') ));
  End
    Else if @pedtn_flag='E' begin

        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=isnull(@adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=isnull(@ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=isnull(@categrycod,"Adv_Cat_Code")
        and "Color" =isnull(@colorcod,"Color") and "Uom"   =isnull(@uomcod,"Uom")
        and ("Combin_Code"=@packgcod or @packgcod is null)
        and ("Valid_From"=@frdate and "Valid_To"=@todate) 
        and exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=Rate_Mast."combin_desc" and 
        "Edition_Type"='Edition' and @pedtn_flag='E');
    End
    Else if @pedtn_flag='S' begin

        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=isnull(@adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=isnull(@ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=isnull(@categrycod,"Adv_Cat_Code")
        and "Color" =isnull(@colorcod,"Color") and "Uom"   =isnull(@uomcod,"Uom")
        and ("Combin_Code"=@packgcod or @packgcod is null)
        and ("Valid_From"=@frdate and "Valid_To"=@todate) 
        and exists(select 'x' from supplement_mast where supplement_mast."Supp_Alias"=Rate_Mast."combin_desc" and @pedtn_flag='S');
    End
    Else begin
        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=isnull(@adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=isnull(@ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=isnull(@categrycod,"Adv_Cat_Code")
        and "Color" =isnull(@colorcod,"Color") and "Uom"   =isnull(@uomcod,"Uom")
        and ("Combin_Code"=@packgcod or @packgcod is null)
        and ("Valid_From"=@frdate and "Valid_To"=@todate) ;
             
    End
End    
       
IF isnull (@p_solo, '') = 'P' Begin
    If @pedtn_flag='M' Begin
    
        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=isnull(@adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=isnull(@ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=isnull(@categrycod,"Adv_Cat_Code")
        and "Color" =isnull(@colorcod,"Color") and "Uom"   =isnull(@uomcod,"Uom")
        and ("Combin_Code"=@packgcod or @packgcod is null)
        and ("Valid_From"=@frdate and "Valid_To"=@todate) 
        and "rateuniqueid" in(select "rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=isnull(@adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=isnull(@ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=isnull(@categrycod,"Adv_Cat_Code")
        and "Color" =isnull(@colorcod,"Color") and "Uom"   =isnull(@uomcod,"Uom")
        and ("Combin_Code"=@packgcod or @packgcod is null)
        and ("Valid_From"=@frdate and "Valid_To"=@todate) 
        and exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=Rate_Mast."combin_desc" and 
        (("Edition_Type"='Main Edition' and @pedtn_flag='M') ))) ;
    End
    Else if @pedtn_flag='E' begin
    
        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=isnull(@adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=isnull(@ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=isnull(@categrycod,"Adv_Cat_Code")
        and "Color" =isnull(@colorcod,"Color") and "Uom"   =isnull(@uomcod,"Uom")
        and ("Combin_Code"=@packgcod or @packgcod is null)
        and ("Valid_From"=@frdate and "Valid_To"=@todate)
        and "rateuniqueid" in(select "rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=isnull(@adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=isnull(@ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=isnull(@categrycod,"Adv_Cat_Code")
        and "Color" =isnull(@colorcod,"Color") and "Uom"   =isnull(@uomcod,"Uom")
        and ("Combin_Code"=@packgcod or @packgcod is null)
        and ("Valid_From"=@frdate and "Valid_To"=@todate) 
        and exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=Rate_Mast."combin_desc" and 
        "Edition_Type"='Edition' and @pedtn_flag='E')) ;
	End
    Else if @pedtn_flag='S' begin
    
        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=isnull(@adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=isnull(@ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=isnull(@categrycod,"Adv_Cat_Code")
        and "Color" =isnull(@colorcod,"Color") and "Uom"   =isnull(@uomcod,"Uom")
        and ("Combin_Code"=@packgcod or @packgcod is null)
        and ("Valid_From"=@frdate and "Valid_To"=@todate)
        and "rateuniqueid" in(select "rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=isnull(@adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=isnull(@ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=isnull(@categrycod,"Adv_Cat_Code")
        and "Color" =isnull(@colorcod,"Color") and "Uom"   =isnull(@uomcod,"Uom")
        and ("Combin_Code"=@packgcod or @packgcod is null)
        and ("Valid_From"=@frdate and "Valid_To"=@todate) 
        and exists(select 'x' from supplement_mast where supplement_mast."Supp_Alias"=Rate_Mast."combin_desc" and 
        @pedtn_flag='S')) ;
    End
    Else Begin
        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=isnull(@adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=isnull(@ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=isnull(@categrycod,"Adv_Cat_Code")
        and "Color" =isnull(@colorcod,"Color") and "Uom"   =isnull(@uomcod,"Uom")
        and ("Combin_Code"=@packgcod or @packgcod is null)
        and ("Valid_From"=@frdate and "Valid_To"=@todate) ;
    End
End

End



///////////end ////////////////////


start by shipra  ///attachment delete//////




alter procedure [dbo].[Attachment_delete111]
(
@pcompcode as varchar(10),
@pcompid as varchar(50)

 
)
as

begin


update tbl_booking_mast set "ATTACHMENT1"='', "ATTACHMENT2"=''
where "Comp_code" =@pcompcode and "cio_booking_id"=@pcompid;


;


end ;



/////////////////////////////////////////////////


alter procedure [dbo].[Attachment_select11]
(
@pcompcode as varchar(10),
@pcompno as varchar(50)
--p_accounts1     OUT Cur_Type_New1.cursor_type

 
)
as

begin


--open p_accounts1 for 

select * from tbl_booking_mast where "Comp_code"=@pcompcode and "cio_booking_id"=@pcompno;



end;



/////end by shipra/;attachment delete///////////////////


/////////////start issue no:9237(30/11/2012)/////////
create procedure [dbo].[websp_selectvalues_invoice](
@ciobooking	varchar(50), 
@editionname	varchar(50),
@compcode	VARCHAR(50),
@insertion	varchar(50),
@dateformat	varchar(50),
@pbill_no varchar(250)

)
as 
declare @str	as varchar(8000)
declare @str1	as varchar(8000)
declare @str3 as varchar(8000)
declare @package_cd	as varchar(3000)
declare @package_result as varchar(3000)
declare @package_cd1	as varchar(3000)
create table #package ( package_name varchar (3000) )

declare @v_scheme_code  as varchar(300)


set @str='select TBL_BOOKING_MAST.cio_booking_id as "CIOID",
AGENCY_MAST.agency_name as "Agency",
PUB_MAST.pub_name as "Pub",PUB_MAST.pub_name as "Pub"

,tbl_booking_insert.height as "Depth",

case 
when TBL_BOOKING_MAST.uom_code=''CO0'' then tbl_booking_insert.No_ofcolumn
when TBL_BOOKING_MAST.uom_code <> ''CO0'' then tbl_booking_insert.width end as "Width"

/*,tbl_booking_insert.width as "Width"*/
, COL_MAST.col_alias as "Hue"
,tbl_booking_insert.no_insert as "Ins.No."
  ,ro_no as "RoNo.",
TBL_BOOKING_MAST.card_amount as "Amt"
,TBL_BOOKING_INSERT.disc_rate as "Disc",
(select advpos_type_mast.pos_type from advpos_type_mast where advpos_type_mast.pos_type_code=tbl_booking_insert.page_post) as "pageposition",
(select adv_cat_mast.adv_cat_name from adv_cat_mast where ADV_CAT_MAST.adv_cat_code=TBL_BOOKING_MAST.ad_cat_code) as "AdCat",
tbl_booking_insert.size_book as "volume",tbl_booking_mast.card_rate as "package rate", edition_mast. edition_alias as "edition"
,isnull((select distinct cust_mast.cust_alias from cust_mast  where  cust_mast.cust_code=tbl_booking_mast.client_code),tbl_booking_mast.client_code) as "advertiser",
tbl_booking_mast.agency_sub_code,tbl_booking_mast.gross_amount,agency_mast.add1 , city_mst.city_name,

(select box_mast.box_charges_native from box_mast  ,tbl_booking_mast where  tbl_booking_mast.box_code=box_mast.box_code and TBL_BOOKING_MAST.cio_booking_id='''+@ciobooking+''' ) as "boxchares" ,
tbl_booking_insert.gross_rate,
tbl_booking_mast.creation_datetime,

(select distinct  min(package_name) from combin_mast where combin_desc='''+@editionname+''')as package_name,
(select distinct cust_mast.ADD1 from cust_mast  where  cust_mast.cust_code=tbl_booking_mast.client_code) as "clientAd",
isnull((select cust_name from CUST_MAST where cust_code=client_code),client_code)  as "Client",tbl_booking_mast.no_of_insertion,

case '''+@dateformat + '''

 when ''mm/dd/yyyy'' then convert(varchar(10),insertion_date,1) 

when ''dd/mm/yyyy'' then convert(varchar(10),insertion_date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),insertion_date,3)  end as "Ins.date" ,
tbl_booking_insert. page_no,

(select top 1 premiumname from ADVPOS_PREM_MAST,tbl_booking_insert where   ADVPOS_PREM_MAST. premiumcode=tbl_booking_insert.premium1 and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' and   tbl_booking_insert.no_insert='''+@insertion+''' and  tbl_booking_insert.edition='''+@editionname+''' ),
tbl_booking_mast.special_discount,
tbl_booking_mast.Special_disc_per,
tbl_booking_mast.special_charges
,tbl_booking_mast.trade_disc,

(select top 1 premium_charges from ADVPOS_PREM_MAST,tbl_booking_insert where   ADVPOS_PREM_MAST. premiumcode=tbl_booking_insert.premium1 and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' and   tbl_booking_insert.no_insert='''+@insertion+''' and  tbl_booking_insert.edition='''+@editionname+''' ) as "premiumch",tbl_booking_insert.card_rate,
pub_cent_mast.add1 as add11,
pub_cent_mast.phone1,
pub_cent_mast.phone2 ,
pub_cent_mast.fax1,
isnull(TBL_BOOKING_INSERT.agreed_rate,0) as agreed_rate,
TBL_BOOKING_INSERT.Edition as "EditionName",


agency_mast.bill_to,
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),insert_date,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),insert_date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),insert_date,3)  end as "insert_date",
tbl_booking_mast.uom_code,
(select Uom_Name from uom_mast where uom_code=tbl_booking_mast.uom_code) as uom_name,
(select Adv_Type_Name from adv_type_mast where Adv_Type_Code=tbl_booking_mast.Ad_type_code) as ad_type,

comp_mst.COMP_NAME as "companyname",
comp_mst.PAN_NO as "pan",
PUB_CENT_MAST.Pub_Cent_name as "pubname",
comp_mst.ADD1 as "address",
comp_mst.STREET as "street",
comp_mst.FAX as "fax",
tbl_booking_insert.Bill_Amt,
1 as "Email",
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),1) 
when ''dd/mm/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),3) 
when ''yyyy/mm/dd'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),3)  end as "paydate",
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),1) 
when ''dd/mm/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),3) 
when ''yyyy/mm/dd'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),3)  end as "paydatesys",
tbl_booking_insert.insert_id,
AGENCY_MAST."Add2",
AGENCY_MAST."Add3",
dbo.getadd('''+@compcode+''','''+@ciobooking+''') as "agenadd",
tbl_booking_mast."Bill_to" as "bill2",
/*Modified*/
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),tbl_booking_insert.Insert_date,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),tbl_booking_insert.Insert_date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),tbl_booking_insert.Insert_date,3)  end as "insert_date1",
--convert(varchar(10),tbl_booking_insert.Insert_date,1) as "insert_date1",
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),tbl_booking_insert.bill_date,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),tbl_booking_insert.bill_date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),tbl_booking_insert.bill_date,3)  end as "bill_date1",
--convert(varchar(10),tbl_booking_insert.bill_date,1) as "bill_date1",
PUB_MAST.Pub_Code as "pub_cod",
edition_mast.Edition_Code as "edit_code",
tbl_booking_mast.Scheme_type_code as "scheme",
tbl_booking_mast.CASHDISCOUNT as "cashdis_per",
isnull(TBL_BOOKING_mast.Agreed_amount,0) as "AgreedAmt",
tbl_booking_mast.Rate_code as "rate_code",
tbl_booking_insert.Insert_status as "status",
tbl_booking_insert.BOXCHARGE as "boxcrg",
agency_mast.Agency_Code as "agency_cod",
(select top 1 Box_Charges_Native from Box_mast where Box_mast.Box_Code=tbl_booking_mast.Box_code) as "Box_Charge",
tbl_booking_mast.Page_amount as "Pag_amt",
tbl_booking_mast.Prem_per as "pag_prem",
tbl_booking_mast.Agrred_rate as "agree_rate",
dbo.get_printing_cent_name_fr_bran('''+@compcode+''',tbl_booking_mast.branch) as Print_cent_name,
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),date_time,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),date_time,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),date_time,3)  end as "date_time",
case tbl_booking_mast.ad_type_code
when ''DI0'' then tbl_booking_mast."Caption"
else tbl_booking_mast."key_no" end as "Cap",
TBL_BOOKING_mast.ADD_AGENCY_COMM as "addcom",
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),TBL_BOOKING_MAST.RO_Date,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),TBL_BOOKING_MAST.RO_Date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),TBL_BOOKING_MAST.RO_Date,3)  end as "RO_Date",
tbl_booking_mast."key_no" as "key_no",
AGENCY_MAST.pin_code,
isnull(tbl_booking_insert.agreed_rate,ISNULL(tbl_booking_insert.card_rate,0)*isnull(tbl_booking_insert.size_book,0))  as insert_gross_amt';


set @str1=',(select distinct COLORRATEGROUPMAST.prcent_pr from COLORRATEGROUPMAST 
where tbl_booking_mast.comp_code=COLORRATEGROUPMAST.comp_code and 
tbl_booking_mast.ad_type_code=COLORRATEGROUPMAST.ad_type and tbl_booking_insert.package_code=COLORRATEGROUPMAST.pkg_code 
 and tbl_booking_insert.col_code=COLORRATEGROUPMAST.color_name) as "Extra",
(select top 1 Cont_Person from cont_details where tbl_booking_mast.Comp_code=cont_details.Comp_Code 
and cont_details.Agency_Code=tbl_booking_mast.Agency_code) as "contact",

(select top 1 MOBILENO from cont_details where tbl_booking_mast.Comp_code=cont_details.Comp_Code 
and cont_details.Agency_Code=tbl_booking_mast.Agency_code) as "MOBILENO",

 (select  dbo.initcap(PUB_CENT_MAST.Add1) FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_code=TBL_BOOKING_MAST.branch AND 
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS addressnew,



(select  dbo.initcap(PUB_CENT_MAST.street) FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_code=TBL_BOOKING_MAST.branch AND 
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS streetnew,

(select  PUB_CENT_MAST.zip FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_code=TBL_BOOKING_MAST.branch AND 
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS Fax2new,


(select  PUB_CENT_MAST.phone1 FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_code=TBL_BOOKING_MAST.branch AND 
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS phone11,

(select  PUB_CENT_MAST.phone2 FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_code=TBL_BOOKING_MAST.branch AND 
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS phone22,

(SELECT dbo.initcap(City_Name)  from city_mst WHERE COMP_CODE='''+@compcode+''' AND city_mst.City_Code=
(select  PUB_CENT_MAST.CITY_CODE FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_code=TBL_BOOKING_MAST.branch AND 
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))) AS CITY_NAMEnew,
tbl_booking_mast.RETAINER,tbl_booking_mast.Executive_code,
(select ADV_SUBCAT_MAST.Adv_Subcat_Name from ADV_SUBCAT_MAST where ADV_SUBCAT_MAST.Adv_Subcat_Code=TBL_BOOKING_MAST.ad_sub_cat_code) as "AdSubCat",

(SELECT DISTINCT PACKAGE_NAME FROM COMBIN_MAST WHERE COMBIN_MAST.COMBIN_CODE=TBL_BOOKING_MAST.PACKAGE_CODE) AS "PACK_NAME",
tbl_booking_mast.BOOKING_TYPE

from TBL_BOOKING_MAST,pub_cent_mast,
TBL_BOOKING_INSERT,
AGENCY_MAST ,
PUB_MAST
,
COL_MAST ,
edition_mast,
city_mst,
comp_mst

 where TBL_BOOKING_MAST.comp_code='''+@compcode+''' and TBL_BOOKING_INSERT.pub_cent_code=pub_cent_mast.pub_cent_code
and TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.cio_booking_id
 and TBL_BOOKING_MAST.agency_code=AGENCY_MAST.agency_code  and comp_mst.comp_code='''+@compcode+''' 
 and tbl_booking_insert.Col_code=col_mast.Col_code   and pub_mast.pub_code=tbl_booking_insert.publication_code 
  and edition_mast.edition_code=tbl_booking_insert.edition_code and city_mst.city_code=agency_mast.city_code  and TBL_BOOKING_INSERT.publication_code = PUB_MAST.pub_code and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' 
  -- and   tbl_booking_insert.no_insert='''+@insertion+''' 
--  and  tbl_booking_insert.edition='''+@editionname+''' 
 and tbl_booking_insert.bill_no= '''+@pbill_no+'''
  '



print('d')
--set @str3=' and tbl_booking_insert.insert_date='''+convert (varchar(10),@pubdate,101)+''''
select  @package_cd1=package_code from tbl_booking_mast where cio_booking_id=@ciobooking




select  @package_cd1=package_code,@v_scheme_code=Scheme_type_code from tbl_booking_mast where cio_booking_id=@ciobooking



DECLARE c1 CURSOR READ_ONLY
FOR
 
    
select Edition_Name from fn_SplitField(@package_cd1,',')


           
    open c1
    FETCH NEXT FROM c1
    INTO @package_result
                 

    WHILE @@FETCH_STATUS = 0
    BEGIN


    insert into #package select combin_desc from combin_mast where combin_code=@package_result
    --select * from #package         

    FETCH NEXT FROM c1
    INTO  @package_result
    END
    print(@package_result)
CLOSE c1
DEALLOCATE c1

/////////////////////////////





//////////////////////////////////**************(Laxman Sir)28/dec/2012**************///////////////////////////////////////////////


                                                                     
                                                                     
                                                                     
                                             
CREATE FUNCTION FETCH_PUBLISH_EDTNNAME_SIZE(
    @pcomp_cd    varchar(20),
    @pbkid       varchar(20),
    @ppubdate    datetime,
    @ppkgcode    varchar(20),
    @ppublcode   varchar(20),
    @pedtncode   varchar(20),
    @pinsert_no  numeric(10),
    @phight      numeric(10,2),
    @pwidth      numeric(10,2),
    @pdateformat varchar(20),
    @pexrta1     varchar(20),
    @pexrta2     varchar(20)) RETURNs VARCHAR(1000) As
Begin

declare @v_edtn          varchar(20);
declare @v_edtn_alias    varchar(200);
declare @v_edtn_name     varchar(2000);
    declare c1 cursor for 
        select distinct x."Edition_Code" "Edition_Code",x."Edition_Alias" "Edition_Alias" from
        (select distinct a."Edition_Code",e."Edition_Alias" from tbl_booking_insert a,edition_mast e
        where a."Comp_Code"=e."Comp_Code" and a."Edition_Code"=e."Edition_Code" and a."Cio_Booking_Id"=@pbkid and 
            a."Insert_Date"=@ppubdate and package_code=isnull(@ppkgcode,package_code) and a."Publication_Code"=isnull(@ppublcode,a."Publication_Code") and 
            a."Edition_Code"=isnull(@pedtncode,a."Edition_Code") and a."Insert_Status" not in('cancel','hold') 
            and a."No_Insert"=isnull(@pinsert_no,a."No_Insert") and a."Height" =isnull(@phight,a."Height")
            and a."Width"=isnull(@pwidth,a."Width")
        union
        select distinct a."EDITION" as "Edition_Code",e."Edition_Alias" from tbl_booking_subedition a,edition_mast e
        where a."COMP_CODE"=e."Comp_Code" and a."EDITION"=e."Edition_Code" and a."CIOID"=@pbkid and 
            a."INSERTDATE"=@ppubdate and a."PUBLICATION"=@ppublcode and 
            a."EDITION"=@pedtncode and a."INSERTSTATUS" not in('cancel','hold')
            and a."NO_INSERT"=isnull(@pinsert_no,a."NO_INSERT") and a.height =isnull(@phight,a.height)
            and a.width=isnull(@pwidth,a.width)) x
            order by "Edition_Alias"; 

    open c1;
    fetch NEXT FROM c1 INTO @v_edtn,@v_edtn_alias;
		WHILE (@@FETCH_STATUS = 0) 
        BEGIN
    
			if (@v_edtn_name is null or @v_edtn_name='') begin
				set @v_edtn_name=@v_edtn_alias
			End
			else Begin
				set @v_edtn_name=@v_edtn_name+','+@v_edtn_alias
			end
			fetch NEXT FROM c1 INTO @v_edtn,@v_edtn_alias;
		End
    close c1;    
	deallocate c1;
    return isnull(@v_edtn_name,'?');
END


--------



                                                                     
                                                                     
                                                                     
                                             
CREATE function fetch_insert_center_printrmrk(
    @pcompcode       varchar(200),
    @pcioid          varchar(200),
    @ppub_cent_code  varchar(200),
    @pinsertion_no   int,
    @ppubdate        datetime,
    @pedtncode       varchar(200),
    @pextra1         varchar(200),
    @pextra2         varchar(200)) returns varchar(2000)

as
Begin
declare @v_rmrk   varchar(2000);


    select distinct @v_rmrk =max(i."Remarks")  from tbl_booking_mast m,tbl_booking_insert i 
        where m."Comp_code"= i."Comp_Code" and i."Comp_Code"=@pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
        i."Cio_Booking_Id"=@pcioid and i."No_Insert" =isnull(@pinsertion_no,i."No_Insert") and 
        i."Insert_Status"!='cancel' and i."Insert_Date"=@ppubdate and i."Edition_Code"=isnull(@pedtncode,i."Edition_Code");
    
    if @v_rmrk is null or @v_rmrk='' begin

        select distinct @v_rmrk =max(i."Remarks") from tbl_booking_mast m,tbl_booking_insert i 
            where m."Comp_code"= i."Comp_Code" and i."Comp_Code"=@pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
                i."Cio_Booking_Id"=@pcioid and i."No_Insert" =isnull(@pinsertion_no,i."No_Insert") and 
                i."Insert_Status"!='cancel' and i."Insert_Date"=@ppubdate and 
                i."Pub_Cent_Code"= isnull(@ppub_cent_code,i."Pub_Cent_Code");
        
        if @v_rmrk is null or @v_rmrk ='' begin
            select distinct @v_rmrk =max(i."Remarks") from tbl_booking_mast m,tbl_booking_insert i 
                where m."Comp_code"= i."Comp_Code" and i."Comp_Code"=@pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
                    i."Cio_Booking_Id"=@pcioid and i."No_Insert" =isnull(@pinsertion_no,i."No_Insert") and 
                    i."Insert_Status"!='cancel' and i."Insert_Date"=@ppubdate ;
        
            if @v_rmrk is null or @v_rmrk ='' begin
                select distinct @v_rmrk = max(i."Remarks") from tbl_booking_mast m,tbl_booking_insert i 
                    where m."Comp_code"= i."Comp_Code" and i."Comp_Code"=@pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
                        i."Cio_Booking_Id"=@pcioid and i."No_Insert" =isnull(@pinsertion_no,i."No_Insert") and 
                        i."Insert_Status"!='cancel';
            end    
        end
    end


return isnull(@v_rmrk,null);

END





////////////////////////////////////*************************************///////////////////////////////

/////////////////////////****************(Anuj  Rajasthan patrika  09/01/2013  )*******************/////////////////////////////////


alter PROCEDURE rpt_unregistered_client
   @pcompcode		as varchar(200),
   @pbranchcode		as varchar(200),
   @pdatefrom		as datetime,
   @pdateto			as datetime,
   @pdateformate	as varchar(200),
   @padtype			as varchar(200),
   @puomcode		as varchar(200),
   @pdate_flag		as varchar(20),
   @pextra1			as varchar(4000),
   @pextra2			as varchar(200),
   @pextra3			as varchar(200),
   @pextra4			as varchar(200),
   @pextra5			as varchar(200)
AS
BEGIN
	declare @v_query  varchar(8000)
    If @pbranchcode is null Begin
		set @pbranchcode=''
    End

    If @padtype is null Begin
		set @padtype=''
    End
    
    If @puomcode is null Begin
		set @puomcode=''
    End 
    set @v_query='SELECT distinct a."date_time" as "BKDATE",a."Client_code" AS "CLIENTNAME", "Client_address" AS "CLIENT_ADDRESS",
        a."cio_booking_id" AS "CIOID", b."Agency_Name" as "AGENCY_NAME", c."Adv_Type_Name" as "ADV_TYPE_NAME",
        (select "Package_Name" from combin_mast where "Comp_Code"='''+@pcompcode+''' and "Combin_Code"=(
        case when charindex('','',''abcdef'') >0 then substring(a."Package_code",1,charindex(a."Package_code",'','')-1)  
        else a."Package_code" end)) as "PACKAGE_NAME", e."Adv_Cat_Name" as "ADV_CAT_NAME", 
        a."Total_area" as "TOTAL_AREA", a."Rate_code" as "RATE_CODE",
        a."Card_rate" as "CARD_RATE", a."Bill_amount" as "BILL_AMOUNT", a."Gross_amount" as "GROSS_AMOUNT", 
        f."Uom_Name" as "UOM_NAME",g."Comp_Name" as "COMP_NAME"
    FROM tbl_booking_mast a,agency_mast b,adv_type_mast c,adv_cat_mast e,uom_mast f,comp_mst g,tbl_booking_insert i
    WHERE a."Comp_code" = g."Comp_Code" AND a."Comp_code" = i."Comp_Code" AND a."Comp_code" ='''+@pcompcode+''' and 
        a."cio_booking_id" = i."Cio_Booking_Id"'
	print(@v_query)
                
    If @pdate_flag='B' Begin
        set @v_query=@v_query+' AND a."date_time" BETWEEN '''+convert(varchar(20),@pdatefrom,101)+''' AND '''+convert(varchar(20),@pdateto,101)+''' 
                    AND b."code_subcode" = a."Agency_sub_code" and 
                    not exists (SELECT ''x'' FROM cust_mast where "Cust_Code"=a."Client_code")
                    AND a."Ad_type_code" = c."Adv_Type_Code" AND (a."Ad_type_code" =isnull('''+@padtype+''',a."Ad_type_code") or '''''+'='+''''')
                    AND a."Uom_code" = f."Uom_Code" AND (a."Uom_code" =isnull('''+@puomcode+''',a."Uom_code")  or '''''+'='+''''')
                    AND a."Ad_cat_code" = e."Adv_Cat_Code"
                    AND (a."branch" = isnull('''+@pbranchcode+''',a."branch")  or '''''+'='+''''')'
	End                    
    Else Begin
        set @v_query=@v_query+' AND i."Insert_Date" BETWEEN '''+convert(varchar(20),@pdatefrom,101)+''' AND '''+convert(varchar(20),@pdateto,101)+''' 
                    AND b."code_subcode" = a."Agency_sub_code" and 
                    not exists (SELECT ''x'' FROM cust_mast where "Cust_Code"=a."Client_code")
                    AND a."Ad_type_code" = c."Adv_Type_Code" AND (a."Ad_type_code" =isnull('''+@padtype+''',a."Ad_type_code")  or '''''+'='+''''')
                    AND a."Uom_code" = f."Uom_Code" AND (a."Uom_code" =isnull('''+@puomcode+''',a."Uom_code")  or '''''+'='+''''')
                    AND a."Ad_cat_code" = e."Adv_Cat_Code"
                    AND (a."branch" = isnull('''+@pbranchcode+''',a."branch")  or '''''+'='+''''')';
    End  
    print('2')
    print('@pextra1')print(@pextra1)
    print(@v_query)   
    
    if @pextra1 is not null or @pextra1!='' Begin
        set @v_query=@v_query+' AND i."Cio_Booking_Id" in ('''+@pextra1+''') order by bkdate,cioid';
    End
    else Begin
        set @v_query=@v_query+' order by bkdate,cioid';
    end    

    if @pextra2='NRC' begin--Non Registered Client
        set @v_query=@v_query+' and a.CLIENT_TYPE='''+@pextra2+'''';
    End
    Else if @pextra2='URC' begin--Un Registered Client
        set @v_query=@v_query+' and isnull(a.CLIENT_TYPE,''/'')<>''NRC''';
    
    End
    else Begin
        set @v_query=@v_query;
    end
    
    if @pextra1 is not null or @pextra1<>'' begin

        set @v_query=@v_query+' AND i."Cio_Booking_Id" in ('+@pextra1+') order by CLIENTNAME,bkdate,cioid';
    End
    else
    Begin
        set @v_query=@v_query+' order by CLIENTNAME,bkdate,cioid';
    end

    print(@v_query)
     
	exec(@v_query)
    
END
alter procedure clientupdttrasac2
    @pciobookid  as VARCHAR(200),
    @pclientcod  as VARCHAR(200),
    @pcomp_cod   as varchar(200)

AS
    declare @v_cl_addr   varchar(200);
    declare @v_cl_name   varchar(200);
BEGIN

        
        select distinct @v_cl_name="Cust_Name",@v_cl_addr=isnull("Add1",'') from cust_mast 
			where "Cust_Code"=@pclientcod;
    
    if @v_cl_name is not null or @v_cl_name<>'' begin
    
        update tbl_booking_mast set "Client_code"=@pclientcod,"Client_address"=@v_cl_addr ,client_type='RC'
            where "cio_booking_id"=@pciobookid and "Comp_code"=@pcomp_cod;
            
        update ad_bills set clientcd =  @pclientcod, clientname =@v_cl_name
            where comp_code_v=  @pcomp_cod and idnum=@pciobookid;
            
        update ad_bills_det set clientcd = @pclientcod, clientname =@v_cl_name
            where comp_code_v=  @pcomp_cod and idnum=@pciobookid;

        update ad_outstand set bank= @pclientcod
            where comp_code = @pcomp_cod and doctype='BILL' and receipt_no=@pciobookid;
    end
    else
    Begin
        update tbl_booking_mast set "Client_code"=@pclientcod 
            where "cio_booking_id"=@pciobookid and "Comp_code"=@pcomp_cod;
            
        update ad_bills set clientcd =  @pclientcod, clientname =@pclientcod
            where comp_code_v=  @pcomp_cod and idnum=@pciobookid;
            
        update ad_bills_det set clientcd = @pclientcod, clientname =@pclientcod
            where comp_code_v=  @pcomp_cod and idnum=@pciobookid;       

        update ad_outstand set bank= @pclientcod
            where comp_code = @pcomp_cod and doctype='BILL' and receipt_no=@pciobookid;    
    
    end
    
END
CREATE procedure ad_client_mark_nonregistered
    @pciobookid  as VARCHAR(200),
    @pclientcod  as VARCHAR(50),
    @pcomp_cod   as varchar(20)

AS
    declare @v_cnt   numeric(5)
BEGIN

        
    select @v_cnt=count(*) from cust_mast where "Comp_Code"=@pcomp_cod and "Cust_Code"=@pclientcod;
            
        
    if isnull(@v_cnt,0)=0 begin
        
        update tbl_booking_mast set CLIENT_TYPE='NRC' 
            where "cio_booking_id"=@pciobookid and "Comp_code"=@pcomp_cod;

    end
    
END
/////////////////***********changes send by bhanu sir from rajasthan patrika*************/////////////////////////

                                                                     
                                             
CREATE PROCEDURE agency_mrv_region_bind
    @pcompcode		as  VARCHAR(200),
    @pdateformat	as  VARCHAR(200),
    @puserid		as  VARCHAR(200),
    @pextra1		as  VARCHAR(200),
    @pextra2		as  VARCHAR(200),
    @pextra3		as  VARCHAR(200),
    @pextra4		as  VARCHAR(200),
    @pextra5		as  VARCHAR(200)
AS
BEGIN
 
    select distinct "Zip" from agency_mast 
    where "Comp_Code" =@pcompcode and ("Zip" is not null or "Zip"<>'')
    order by "Zip";
 
END



-------------------

                                                                     
                                                                     
                                                                     
                                             
USE [erp]
GO
/****** Object:  StoredProcedure [dbo].[executecontract]    Script Date: 01/24/2013 11:33:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









ALTER PROCEDURE [dbo].[executecontract]

@compcode as varchar(8),--
@userid as varchar(8),--
@DealNo as varchar(8),--
@dealname as varchar(50),--
@agencycode as varchar(8),--
@subagencycode as varchar(8),--
@representative as varchar(8),
@dealtype as varchar(8),
@quotion_p as varchar(8),
@clientname_p as varchar(100)
--@contract_id as varchar(100)--



AS

declare @query as varchar(2000)



CREATE TABLE #Temp_Contract_mast (
	Deal_No varchar (8)  ,
	Comp_code varchar (8)  ,
	Agency_code varchar (80)  ,
	Sub_Agency_Code varchar (8)  ,
	Client_code varchar (80)  ,
	Product_code varchar (8)  ,
	From_date datetime  ,
	Till_date datetime  ,
	representative varchar (8)  ,
	Userid varchar (8)  ,
	Creation_datetime datetime  ,
	Total_val int ,
	Total_volu int ,
	team_code varchar(8),
	deal_type varchar(8),
	deal_name varchar(50),
	contract_id varchar(100),
	Ad_type varchar(12),
	REMARKS varchar(1000),
	EXECUTIVE varchar(20), 
	RETAINER varchar(20),
	CONTRACTDATE datetime,
	CLOSEDATE datetime,
	SERVICETAX datetime,
	PAYMENTTYPE varchar(200),
	CAPTION varchar(500),
B2B varchar(10), CHKMULTIAD varchar(10), SEQNO_ALLOW varchar(10), SEQNO varchar(10), 
AFT_PRTCLR_AD varchar(10), INDUSTRY varchar(10), INDUSTRY_PRODUCT varchar(100), DEALON VARCHAR(20)
,ATTACHMENT VARCHAR(20),QUOTATION varchar(2)
) 
/*

CREATE TABLE #temp_Contract_mast (
	Deal_No varchar (8) ,
	Comp_code varchar (8) ,
	Agency_code varchar (8)  ,
	Sub_Agency_Code varchar (8)  ,
	Client_code varchar (8)  ,
	Product_code varchar (8)  ,
	From_date datetime  ,
	Till_date datetime  ,
	representative varchar (8)  ,
	Adv_cat_code varchar (8)  ,
	Publication_code varchar (8)  ,
	suppliment_code varchar (8)  ,
	Edition_code varchar (8)  ,
	Booked_for varchar (8)  ,
	Color_code varchar (8)  ,
	Card_rate decimal(18, 0)  ,
	Deal_rate decimal(18, 0)  ,
	premium_code varchar (8)  ,
	Card_premium varchar (8)  ,
	Deal_premium varchar (8)  ,
	Volume_billed varchar (15)  ,
	Volume_disc varchar (15)  ,
	Value_from varchar (15)  ,
	Value_to varchar (15)  ,
	UOM_Code varchar (8)  ,
	Package_code varchar (8)  ,
	Userid varchar (8) ,
	Creation_datetime datetime ,
	Total_val int  ,
	Total_volu int  ,
	curr_code varchar (8)  ,
	team_code varchar (8)  ,
	deal_type varchar (8)  ,
	deal_name varchar (50)  
)*/




--delete from temp_contract_mast where comp_code=@compcode and userid=@userid
/*
set @query='insert into #Temp_Contract_mast  select   Deal_No AS Deal_No
,Comp_code AS Comp_code,
(select agency_name + ''('' + Agency_code + '')'' from agency_mast where agency_mast.Agency_code=contract_mast.agency_code and agency_mast.SUB_Agency_Code=contract_mast.Sub_Agency_Code)as Agency_code
,Sub_Agency_Code,(select Cust_Name + ''(''+Cust_Code+'')'' from cust_mast where cust_mast.Cust_Code=contract_mast.Client_Code) as Client_code,
Product_code,convert(varchar(10),From_date,101) as From_date,convert(varchar(10),Till_date,101) as Till_date,
representative,Userid,getdate(),Total_val,Total_volu,
team_code,deal_type,deal_name, contract_id,Ad_type,REMARKS,
(select Exec_name + ''(''+CAST(Exe_no AS VARCHAR(20))+'')'' 
from exec_mast where Exe_no=EXECUTIVE) as EXECUTIVE, 
(select Retain_Name+''('' + Retain_Code + '')'' from  retainermaster where Retain_Code=RETAINER) as RETAINER
, CONTRACTDATE, CLOSEDATE, SERVICETAX, PAYMENTTYPE, CAPTION,B2B, CHKMULTIAD, SEQNO_ALLOW, 
SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON  from contract_mast 
 where comp_code='''+@compcode+''''
*/
set @query='select   Deal_No AS Deal_No
,Comp_code AS Comp_code,
(select agency_name + ''('' + Agency_code + '')'' from agency_mast where agency_mast.Agency_code=contract_mast.agency_code and agency_mast.SUB_Agency_Code=contract_mast.Sub_Agency_Code)as Agency_code
,Sub_Agency_Code,isnull((select Cust_Name + ''(''+Cust_Code+'')'' from cust_mast where cust_mast.Cust_Code=contract_mast.Client_Code),Client_code) as Client_code,
Product_code,convert(varchar(10),From_date,101) as From_date,convert(varchar(10),Till_date,101) as Till_date,
representative,Userid,getdate(),Total_val,Total_volu,
team_code,deal_type,deal_name, contract_id,Ad_type,REMARKS,
(select Exec_name + ''(''+CAST(Exe_no AS VARCHAR(20))+'')'' 
from exec_mast where Exe_no=EXECUTIVE) as EXECUTIVE, 
(select Retain_Name+''('' + Retain_Code + '')'' from  retainermaster where Retain_Code=RETAINER) as RETAINER
, convert(varchar(10),CONTRACTDATE,101) as CONTRACTDATE, convert(varchar(10),CLOSEDATE,101) as CLOSEDATE, SERVICETAX, PAYMENTTYPE, CAPTION,B2B, CHKMULTIAD, SEQNO_ALLOW, 
SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON,ATTACHMENT, 
(select Pub_Cent_name + ''('' + Pub_cent_Code + '')'' from pub_cent_mast where pub_cent_mast.Pub_cent_Code=contract_mast.DEAL_FROM) AS DEAL_FROM, DEAL_CENTER, TRANSLATION_CHARGES,
RECEIPT_NO, RECEIPT_DATE, RO_STATUS, RO_NO, convert(varchar(10),RO_DATE,101) AS RO_DATE, RCPT_CURRENCY,QUOTATION
 from contract_mast 
 where comp_code='''+@compcode+''''
if(@DealNo <> '')
begin
set @query=@query+'and Deal_No like ''%'+@DealNo+'%'''
end

if(@dealname <> '')
begin
set @query=@query+'and deal_name like ''%'+@dealname+'%'''
end

if(@agencycode <> '0' and @agencycode <>'')
begin
set @query=@query+'and Agency_code like '''+@agencycode+''''
end

if(@dealtype <> '0' and @dealtype <> '')
begin
set @query=@query+'and deal_type like '''+@dealtype+''''
end


if(@subagencycode <>''  and @subagencycode <> '0')
begin
	
	
	set @query=@query+' and Sub_Agency_Code like '''+@subagencycode+''''
	
end

if(@representative <> '0'  and  @representative <>'' ) 
begin
set @query=@query+' and Representative like '''+@representative+''''
end

if(@clientname_p <> '0'  and  @clientname_p <>'' ) 
begin
set @query=@query+' and Client_Code like '''+@clientname_p+''''
end

if(@quotion_p = 'Y'  and  @quotion_p ='y' ) 
begin
set @query=@query+' and QUOTATION like '''+@quotion_p+''''
end

else
begin
set @query=@query+' and QUOTATION  is null ' 
end

print(@query)
exec(@query)
/*
select   Deal_No,Comp_code,Agency_code,Sub_Agency_Code,Client_code,Product_code,
convert(varchar(10),From_date,101) as From_date,convert(varchar(10),Till_date,101) as Till_date,
representative,Userid,Total_val,Total_volu,team_code,deal_type,deal_name,contract_id,Ad_type,REMARKS,EXECUTIVE, RETAINER, CONTRACTDATE, CLOSEDATE, SERVICETAX, PAYMENTTYPE, CAPTION,B2B, CHKMULTIAD, SEQNO_ALLOW, SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON   from #Temp_Contract_mast
*/
drop table #Temp_Contract_mast






//////////////////////////*******(end)*******//////////////////////




