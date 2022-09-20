/CREATE OR REPLACE PACKAGE HT18JULY.Wesp_Updatedate
IS
PROCEDURE      Wesp_Updatedate_p(
compcode IN VARCHAR2,
userid IN VARCHAR2,
dateformat IN VARCHAR2,
code IN VARCHAR2,
curr IN VARCHAR2,
RATECODE11 IN VARCHAR2,
solo  IN VARCHAR2,
breakup VARCHAR2,
bwcode IN VARCHAR2,
rostatus IN VARCHAR2,
filename IN VARCHAR2,
tfn IN NUMBER,
insertbreak IN VARCHAR2,
prem IN VARCHAR2,
dealtype IN VARCHAR2,
pre IN VARCHAR2,
suff IN VARCHAR2,
financestatus IN  VARCHAR2,
voucherst IN VARCHAR2,
adcode IN VARCHAR2,
rodatetime IN VARCHAR2,
spacearea IN VARCHAR2,
vat IN VARCHAR2,
bookstat IN VARCHAR2,
cio_id IN VARCHAR2,
receipt_no IN VARCHAR2,
uom IN VARCHAR2,
bgcolor IN VARCHAR2,
validdate IN VARCHAR2,
agencyratecode IN VARCHAR2,
AUDIT1 IN VARCHAR2,
book_insert_date IN VARCHAR2,
agencycomm IN VARCHAR2,
rateaudit IN VARCHAR2,
billaudit IN VARCHAR2,
bill_type IN VARCHAR2,
invoice_no1 IN VARCHAR2,
copybooking IN VARCHAR2,
ratecompany IN VARCHAR2,
addagenycomm IN VARCHAR2,
agencycommlinkretainer IN VARCHAR2,
subeditionr IN VARCHAR2,
displaybilltype IN VARCHAR2,
classifiedbilltype IN VARCHAR2,
billformat IN VARCHAR2,
ratechk IN VARCHAR2,
allpkg IN VARCHAR2,
dayrate1 in varchar2,
schemetype in varchar2,
PIncludeclassi in varchar2,
receiptformat IN VARCHAR2,
v_cash_receipt in varchar2,
v_bill_orderwiselast in varchar2,
v_floor_chk in varchar2,
Unsoldflag in varchar2,
Supplystopper in  number,
drpRokeychk in varchar2,
Agencycomm_seq in varchar2,
creditreciept in varchar,
cashindisplay IN VARCHAR,
cashinclassified IN VARCHAR,
v_rate_audit_pref in varchar,
v_barcoding_allow_pref in varchar2,
v_fmgbills IN VARCHAR2,
v_billed_cashdis in varchar2,
v_billed_cashcls in varchar,
v_drpbackdate in varchar,
dockitbooking in varchar2,
allowprevbooking in varchar2,
ro_wisecashbill in varchar2,
chkval in varchar2,
approval1 in varchar2,
pckstatus in varchar2,
cash_disc in varchar2,
cash_amt in varchar2,
seperate_cashier1 in varchar2,
disp_bill in varchar2,
clas_bill in varchar2,
mantimepost in varchar2,
bkdaypost in number,
maxterutn in number,
cir_return in varchar2,
noofchkbounc in number,
noofdaychkrec in number,
retday in number,
chngsuppord in number,
max_publishday in number,
p_billno_period in varchar,
spl_trans_edit in varchar2,
spl_dis_trans_editable in varchar2,
mul_pac_sel_trans in varchar2,
shmon_minword in varchar2,
tradon_spcrg in varchar2,
rateauth     in varchar2,
f2day in number,
rateauditmodify in varchar,
bindrevenuecenter in varchar,
p_led_allow in varchar,
p_clear_allow in varchar,
repeatday in varchar,
premiumedit in varchar,
P_BILL_GENERATION in varchar,
P_PUBLICATION_CENTER in varchar,
P_allow_discount_prem IN VARCHAR,
P_SCHEME_BILLING in varchar,
P_ALLOW_PDC in varchar,
PAD_TYPE_FOR_MANUL_BILL in varchar,
RO_OUTSTAND_P IN VARCHAR2,
genrate_agency_code IN VARCHAR2,
p_dispauditbk IN VARCHAR2,
p_aotosupply  IN VARCHAR2,
p_Authorization IN VARCHAR2,
p_CIR_AUTO_APPROVAL_UNSOLD IN VARCHAR2,
p_CIR_AUTO_PHYSICAL_UNSOLD IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INCT IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INSFEE IN VARCHAR2,
p_CIR_UNSOLD_ON_RECEIVED_DT IN VARCHAR2,
p_AGENCY_UNBLOCK_APROV IN VARCHAR2,
p_UNBLOCK_APROV_OUT_LMT IN VARCHAR2,
p_CIR_BILL_PUBLWISE IN VARCHAR2,
p_paging         IN VARCHAR2,
p_print          IN VARCHAR2,
p_allowpage      IN VARCHAR2,
p_agency_req     IN VARCHAR2,
p_region_req     IN VARCHAR2,
p_ALLOW_FOLLOW_DT_BOOOK     IN VARCHAR2,
p_CRM_SUPPLY_TYPE_PAID     IN VARCHAR2,
p_CRM_SUPPLY_TYPE_FREE     IN VARCHAR2,
p_CURRENCY_MEASUREMENT     IN VARCHAR2,

p_EDITABLE_AGENCY_COMM      IN VARCHAR2,
p_CANCELLATION_CHARGE      IN VARCHAR2,
P_taxi_entry_type          IN VARCHAR2,
P_ApprovalWith          IN VARCHAR2,
p_Auto_TDS_Credit_Note IN VARCHAR2,
p_TDS_Reason IN VARCHAR2,
p_Debit_Account_Head IN VARCHAR2,
p_credit_Account_Head IN VARCHAR2,
p_service_tax_credit_note IN VARCHAR2,
p_Tax_Reason IN VARCHAR2,
p_Debit_Account_Service_Tax IN VARCHAR2,
p_Credit_Account_Service_Tax IN VARCHAR2,
p_Auto_Patrakar_Credit_Note IN VARCHAR2,
p_Patrakar_Reason IN VARCHAR2,
p_Debit_Account_Patrakar IN VARCHAR2,
p_Credit_Account_Patrakar IN VARCHAR2,
p_Auto_Bank_Credit_Note IN VARCHAR2,
p_Bank_Reason IN VARCHAR2,
p_Debit_Account_Bank IN VARCHAR2,
p_Credit_Account_Bank IN VARCHAR2,
P_BAR_CODE IN VARCHAR2,
P_GEN_RCT_TYP IN VARCHAR2,
P_WEIGHT_CAL IN VARCHAR2,
P_misdata IN VARCHAR2,
P_allowpremium IN VARCHAR2,
p_financecode in varchar2,
p_exepub in varchar2,
p_executivecreditlimit in varchar2,
p_autoinfo  in  varchar2:=null,
p_sapid     in  varchar2 :=null,
p_mrv in varchar2 :=null,
p_schhr in  varchar2 :=null,
p_ret_after_bank IN varchar2
);
END      Wesp_Updatedate;
/






CREATE OR REPLACE PACKAGE BODY HT18JULY.Wesp_Updatedate IS
PROCEDURE      Wesp_Updatedate_p(
compcode IN VARCHAR2,
userid IN VARCHAR2,
dateformat IN VARCHAR2,
code IN VARCHAR2,
curr IN VARCHAR2,
RATECODE11 IN VARCHAR2,
solo  IN VARCHAR2,
breakup VARCHAR2,
bwcode IN VARCHAR2,
rostatus IN VARCHAR2,
filename IN VARCHAR2,
tfn IN NUMBER,
insertbreak IN VARCHAR2,
prem IN VARCHAR2,
dealtype IN VARCHAR2,
pre IN VARCHAR2,
suff IN VARCHAR2,
financestatus IN  VARCHAR2,
voucherst IN VARCHAR2,
adcode IN VARCHAR2,
rodatetime IN VARCHAR2,
spacearea IN VARCHAR2,
vat IN VARCHAR2,
bookstat IN VARCHAR2,
cio_id IN VARCHAR2,
receipt_no IN VARCHAR2,
uom IN VARCHAR2,
bgcolor IN VARCHAR2,
validdate IN VARCHAR2,
agencyratecode IN VARCHAR2,
AUDIT1 IN VARCHAR2,
book_insert_date IN VARCHAR2,
agencycomm IN VARCHAR2,
rateaudit IN VARCHAR2,
billaudit IN VARCHAR2,
bill_type IN VARCHAR2,
invoice_no1 IN VARCHAR2,
copybooking IN VARCHAR2,
ratecompany IN VARCHAR2,
addagenycomm IN VARCHAR2,
agencycommlinkretainer IN VARCHAR2,
subeditionr IN VARCHAR2,
displaybilltype IN VARCHAR2,
classifiedbilltype IN VARCHAR2,
billformat IN VARCHAR2,
ratechk IN VARCHAR2,
allpkg IN VARCHAR2,
dayrate1 in varchar2,
schemetype in varchar2,
PIncludeclassi in varchar2,
receiptformat IN VARCHAR2,
v_cash_receipt in varchar2,
v_bill_orderwiselast in varchar2,
v_floor_chk in varchar2,
Unsoldflag in varchar2,
Supplystopper in  number,
drpRokeychk in varchar2,
Agencycomm_seq in varchar2,
creditreciept in varchar,
cashindisplay IN VARCHAR,
cashinclassified IN VARCHAR,
v_rate_audit_pref in varchar,
v_barcoding_allow_pref in varchar2,
v_fmgbills IN VARCHAR2,
v_billed_cashdis in varchar2,
v_billed_cashcls in varchar,
v_drpbackdate in varchar,
dockitbooking in varchar2,
allowprevbooking in varchar2,
ro_wisecashbill in varchar2,
chkval in varchar2,
approval1 in varchar2,
pckstatus in varchar2,
cash_disc in varchar2,
cash_amt in varchar2,
seperate_cashier1 in varchar2,
disp_bill in varchar2,
clas_bill in varchar2,
mantimepost in varchar2,
bkdaypost in number,
maxterutn in number,
cir_return in varchar2,
noofchkbounc in number,
noofdaychkrec in number,
retday in number,
chngsuppord in number,
max_publishday in number,
p_billno_period in varchar,
spl_trans_edit in varchar2,
spl_dis_trans_editable in varchar2,
mul_pac_sel_trans in varchar2,
shmon_minword in varchar2,
tradon_spcrg in varchar2,
rateauth     in varchar2,
f2day in number,
rateauditmodify in varchar,
bindrevenuecenter in varchar,
p_led_allow in varchar,
p_clear_allow in varchar,
repeatday in varchar,
premiumedit in varchar,
P_BILL_GENERATION in varchar,
P_PUBLICATION_CENTER in varchar,
P_allow_discount_prem IN VARCHAR,
P_SCHEME_BILLING in varchar,
P_ALLOW_PDC in varchar,
PAD_TYPE_FOR_MANUL_BILL in varchar,
RO_OUTSTAND_P IN VARCHAR2,
genrate_agency_code IN VARCHAR2,
p_dispauditbk IN VARCHAR2,
p_aotosupply  IN VARCHAR2,
p_Authorization IN VARCHAR2,
p_CIR_AUTO_APPROVAL_UNSOLD IN VARCHAR2,
p_CIR_AUTO_PHYSICAL_UNSOLD IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INCT IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INSFEE IN VARCHAR2,
p_CIR_UNSOLD_ON_RECEIVED_DT IN VARCHAR2,
p_AGENCY_UNBLOCK_APROV IN VARCHAR2,
p_UNBLOCK_APROV_OUT_LMT IN VARCHAR2,
p_CIR_BILL_PUBLWISE IN VARCHAR2,
p_paging         IN VARCHAR2,
p_print          IN VARCHAR2,
p_allowpage      IN VARCHAR2,
p_agency_req     IN VARCHAR2,
p_region_req     IN VARCHAR2,
p_ALLOW_FOLLOW_DT_BOOOK     IN VARCHAR2,
p_CRM_SUPPLY_TYPE_PAID     IN VARCHAR2,
p_CRM_SUPPLY_TYPE_FREE     IN VARCHAR2,
p_CURRENCY_MEASUREMENT     IN VARCHAR2,

p_EDITABLE_AGENCY_COMM      IN VARCHAR2,
p_CANCELLATION_CHARGE      IN VARCHAR2,
P_taxi_entry_type          IN VARCHAR2,
P_ApprovalWith          IN VARCHAR2,

p_Auto_TDS_Credit_Note IN VARCHAR2,
p_TDS_Reason IN VARCHAR2,
p_Debit_Account_Head IN VARCHAR2,
p_credit_Account_Head IN VARCHAR2,
p_service_tax_credit_note IN VARCHAR2,
p_Tax_Reason IN VARCHAR2,
p_Debit_Account_Service_Tax IN VARCHAR2,
p_Credit_Account_Service_Tax IN VARCHAR2,
p_Auto_Patrakar_Credit_Note IN VARCHAR2,
p_Patrakar_Reason IN VARCHAR2,
p_Debit_Account_Patrakar IN VARCHAR2,
p_Credit_Account_Patrakar IN VARCHAR2,
p_Auto_Bank_Credit_Note IN VARCHAR2,
p_Bank_Reason IN VARCHAR2,
p_Debit_Account_Bank IN VARCHAR2,
p_Credit_Account_Bank IN VARCHAR2,
P_BAR_CODE IN VARCHAR2,
P_GEN_RCT_TYP IN VARCHAR2,
P_WEIGHT_CAL IN VARCHAR2,
P_misdata IN VARCHAR2,
P_allowpremium IN VARCHAR2,
p_financecode in varchar2,
p_exepub in varchar2,
p_executivecreditlimit in varchar2,
p_autoinfo  in  varchar2:=null,
p_sapid     in  varchar2 :=null,
p_mrv in varchar2,
p_schhr in varchar2,
p_ret_after_bank IN varchar2

)AS
BEGIN
UPDATE LOGIN SET "date_format"=dateformat,
"Autogenerate"=code,"curr_code"=curr WHERE "COM_CODE"=compcode;
COMMIT;
       UPDATE PREFERRENCES SET  "autogenerated"=code,
"currency_code"=curr ,
"rate_gr_code"=RATECODE11,
"date_format"=dateformat,"solo"=solo,"breakup"=breakup,
"blackwhitecode"=bwcode,"rostatus"=rostatus,"File_name"=filename,"Tfn"=tfn,
"Insert_breakup"=insertbreak,"Premium_type"=prem,"Deal_type"=dealtype  ,
 "prefix"=pre, "suffix"=suff, "financestatus"=financestatus ,
"voucherst"=voucherst,
 "Ad_category"=adcode ,"Ro_datetime"=rodatetime
,"Space_area"=spacearea,"Vat"=vat,
 "Booking_status"=bookstat,"Cio_id"=cio_id,"Receipt_no"=receipt_no,"uom_code"=uom,
 "Bgcolor_publication"=bgcolor ,"chkfor_valid_pubdates"=validdate,
"Agency_ratecode"=agencyratecode,
 "audit"=AUDIT1,"book_insert_date"=book_insert_date,"agencycomm"=agencycomm,
 "rate_audit"=rateaudit,"bill_audit"=billaudit,"billtype"=bill_type,"invoice_no"=invoice_no1,
 "copy_booking"=copybooking,"RATE_COMPANY_AGENCY"=ratecompany,
"ADDITIONAL_AGENCY_COMM"=addagenycomm ,
 "AGENCY_RETAINER_COMM"=agencycommlinkretainer,"SUBEDITIONRATE"=subeditionr,
 "CLS_BILLTYPE"=classifiedbilltype,"DIS_BILLTYPE"=displaybilltype,"BILLING_FORMAT"=billformat,
 "RATE_CHECK"=ratechk,"ALL_PACKAGE"=allpkg,"DAYRATE"=dayrate1,"SCHEME_TYPE"=schemetype,"DISP_CLSBILL"=PIncludeclassi
 ,
 "CASH_RECEIPT_BILL"=v_cash_receipt,
"BILL_ORDERWSLAST"=v_bill_orderwiselast, "FLOOR_CHK"=v_floor_chk ,
 "UNSOLD_ENTRY_FLAG"=Unsoldflag
,"SUPPLY_STOP_PERCENTAGE"=Supplystopper,"ROKEYCHECK"=drpRokeychk ,
 "AGENCYCOMM_SEQ_COM"=Agencycomm_seq
,"CREDIT_RECIPT"=creditreciept,"DISP_CASHBILL"=cashindisplay,
 "CLA_CASHBILL"=cashinclassified,"RATE_AUDIT_PREF"=v_rate_audit_pref,"BARCODING_ALLOWED"=v_barcoding_allow_pref,
 "FMG_BILL_DIS" =v_fmgbills, "BILL_DISP_CASHBILL"=v_billed_cashdis ,
"BILL_CLA_CASHBILL"=v_billed_cashcls,"BACKDATERECEIPT"=v_drpbackdate,"DOCKIT_BOOKING"=dockitbooking,"Allowed_old_date"=allowprevbooking,"ROWISE_CASHBOOKING"=ro_wisecashbill,"CUTOFFTIME"=chkval,"APPROVAL"=approval1,"BACK_DAYS"=pckstatus
,CASH_DISCOUNT=cash_amt,CASH_DISCOUNTTYPE=cash_disc,SEPRATE_CASHIER=seperate_cashier1,
  CIR_MANY_TIME_POSTING=mantimepost, CIR_BACKDAYS_POSTING=bkdaypost,
CIR_MAX_RETURN_ALLOW=maxterutn, CIR_RETURN_LIMIT_ALLOW=cir_return,
CIR_NO_OF_CHQBOUNCE=noofchkbounc, CIR_DAYS_CHQBOUNCE=noofdaychkrec,
CIR_RETURN_DAYS=retday, CIR_SUP_ORDER_LIMIT=chngsuppord,
DISP_BILLING_CRITERIA=disp_bill,
CLSD_BILLING_CRITERIA=clas_bill,MAX_PUBLISHDAYS=max_publishday,BILLNO_PERIODICITY=p_billno_period,
  SPECIALDISC_TRANS_EDIT=spl_trans_edit,
SHARING_TRANS=spl_dis_trans_editable,
MULTIPACKAGE_SEL_TRANS=mul_pac_sel_trans,SCHEME_MINWORD=shmon_minword,
TRADE_SPLCHARGE=tradon_spcrg,RATE_AUTHORIZATION=rateauth
 ,F2_RECORD=f2day,PUBLISHAD_EDIT_RATEAUDIT=rateauditmodify,BINDREVENUE_CENTER=bindrevenuecenter,
 FA_LEDGER_ALLOW=p_led_allow
,CLEARANCE_TYPE_ALLOW=p_clear_allow,REPEAT_DAY_TYPE=repeatday,PREMIUM_EDIT=premiumedit,
BILL_GENERATION_PRIOR=P_BILL_GENERATION,PUBLICATION_HO=P_PUBLICATION_CENTER,SPLDISC_ALLOWPREM=P_allow_discount_prem,

BILL_SCHEME=P_SCHEME_BILLING,ALLOWED_PDC_DAYS_RECEIPT=P_ALLOW_PDC
,AD_TYPE_MANUL_BILL=PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=RO_OUTSTAND_P,GENRATE_CIR_AGCD=genrate_agency_code,DISP_AUDITBKG=p_dispauditbk,CIR_DIS_AUTO_POSTING=p_aotosupply,RELAUTHREQON=p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=p_CIR_UNSOLD_ON_RECEIVED_DT,
AGENCY_UNBLOCK_APPROVAL=p_AGENCY_UNBLOCK_APROV,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=p_UNBLOCK_APROV_OUT_LMT,CIR_BILL_PUBLWISE=p_CIR_BILL_PUBLWISE,
RECORDS_ON_PAGE = p_paging,RECORDS_ON_PRINT = p_print,HEADER_ON_PAGE =
p_allowpage,AGENCY_REQUIRED = p_agency_req,REGION_REQUIRED =
p_region_req,
ALLOW_FOLLOW_DT_BOOOK=p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=p_CRM_SUPPLY_TYPE_FREE,
CURRENCY_MEASUREMENT=p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM=p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE=p_CANCELLATION_CHARGE,taxi_entry_type=P_taxi_entry_type,APPROVAL_WITH
=P_ApprovalWith , TDS_AUTO_CN=p_Auto_TDS_Credit_Note,
TDS_AUTO_REASON=p_TDS_Reason
,TDS_DB_CDP=p_Debit_Account_Head,TDS_CR_CDP=p_credit_Account_Head,SER_TAX_AUTO_CN=p_service_tax_credit_note,SER_TAX_AUTO_REASON=p_Tax_Reason,SER_TAX_DB_CDP=p_Debit_Account_Service_Tax,SER_TAX_CR_CDP=p_Credit_Account_Service_Tax,PKK_AUTO_CN=p_Auto_Patrakar_Credit_Note,PKK_AUTO_REASON=p_Patrakar_Reason
,PKK_DB_CDP=p_Debit_Account_Patrakar,PKK_CR_CDP=p_Credit_Account_Patrakar
,BANK_CHG_AUTO_CN=p_Auto_Bank_Credit_Note ,
BANK_CHG_AUTO_REASON=p_Bank_Reason
,BANK_CHG_DB_CDP=p_Debit_Account_Bank
,BANK_CHG_CR_CDP=p_Credit_Account_Bank ,


CIR_BARCODE=P_BAR_CODE, CIR_WIEGHT_CALC_REQ =P_WEIGHT_CAL, GEN_RCT_TYP
=P_GEN_RCT_TYP,PRODUCT_BRAND_REQ=P_misdata,ALLOWPREM_CARD_DISC_RATE=P_allowpremium,FINANCE_CADE=p_financecode,EXECUTIVE_PUBLICATION_VISE=p_exepub,
EXECUTIVECREDITLIMIT=p_executivecreditlimit,
CRM_AUTOINFO=p_autoinfo,
SAP_ID=p_sapid,
MRV_BASED_ON=p_mrv,
SCHEDULING_HOURS=p_schhr,ALLOW_RET_AFTER_BANK=p_ret_after_bank


  WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/



************************************************************************************************************************

CREATE OR REPLACE PACKAGE HT18JULY.Wesp_Submitdate IS

TYPE T_Accounts_Cursor IS REF CURSOR;


PROCEDURE wesp_submitdate_P(
compcode IN VARCHAR2,
userid IN VARCHAR2,
dateformat IN VARCHAR2,
code IN VARCHAR2,
curr IN VARCHAR2,
RATECODE11 IN VARCHAR2,
solo  IN VARCHAR2,
breakup VARCHAR2,
bwcode IN VARCHAR2,
rostatus IN VARCHAR2,
filename IN VARCHAR2,
tfn IN NUMBER,
insertbreak IN VARCHAR2,
prem IN VARCHAR2,
dealtype IN VARCHAR2,
pre IN VARCHAR2,
suff IN VARCHAR2,
financestatus IN  VARCHAR2,
voucherst IN VARCHAR2,
adcode IN VARCHAR2,
rodatetime IN VARCHAR2,
spacearea IN VARCHAR2,
vat IN VARCHAR2,
bookstat IN VARCHAR2,
cio_id IN VARCHAR2,
receipt_no IN VARCHAR2,
uom IN VARCHAR2,
bgcolor IN VARCHAR2,
validdate IN VARCHAR2,
agencyratecode IN VARCHAR2,
AUDIT1 IN VARCHAR2,
book_insert_date IN VARCHAR2,
agencycomm IN VARCHAR2,
rateaudit IN VARCHAR2,
billaudit IN VARCHAR2,
bill_type IN VARCHAR2,
invoice_no1 IN VARCHAR2,
copybooking IN VARCHAR2,
ratecompagnecy IN VARCHAR2,
addagenycomm IN VARCHAR2,
agencycommlinkretainer IN VARCHAR2,
subeditionr IN VARCHAR2,
classifiedbilltype IN VARCHAR2,
displaybilltype IN VARCHAR2,
billformat IN VARCHAR2,
ratechk IN VARCHAR2,
allpkg IN VARCHAR2,
dayrate1 in varchar,
schemetype in varchar2,
PIncludeclassi in varchar2,
receiptformat IN VARCHAR2,
v_cash_receipt in varchar2,
v_bill_orderwiselast in varchar2,
v_floor_chk in varchar2,
Unsoldflag in varchar2,
Supplystopper in number,
drpRokeychk in varchar2,
Agencycomm_seq in varchar2,
creditreciept in varchar,
cashindisplay IN VARCHAR,
cashinclassified IN VARCHAR,
v_rate_audit_pref in varchar,
v_barcoding_allow in varchar2,
v_fmgbills IN VARCHAR2,
v_billed_cashdis in varchar2,
v_billed_cashcls in varchar,
v_drpbackdate in varchar,
dockitbooking in varchar2,
allowprevbooking in varchar2,
ro_wisecashbill in varchar2,
chkval in varchar2,
approval1 in varchar2,
pckstatus in varchar2,
cash_disc in varchar2,
cash_amt in varchar2,
repeatday in varchar2,
premiumedit in varchar2,
P_BILL_GENERATION in varchar2,
P_PUBLICATION_CENTER in varchar,
P_allow_discount_prem IN varchar,
P_SCHEME_BILLING IN VARCHAR,
P_ALLOW_PDC in varchar,
P_TYPE_FOR_MANUL_BILL in varchar,

p_ret_after_bank IN varchar2

);

END Wesp_Submitdate;
/




CREATE OR REPLACE PACKAGE BODY HT18JULY.wesp_submitdate
IS
   PROCEDURE wesp_submitdate_p (
      compcode                 IN   VARCHAR2,
      userid                   IN   VARCHAR2,
      DATEFORMAT               IN   VARCHAR2,
      code                     IN   VARCHAR2,
      curr                     IN   VARCHAR2,
      ratecode11               IN   VARCHAR2,
      solo                     IN   VARCHAR2,
      breakup                       VARCHAR2,
      bwcode                   IN   VARCHAR2,
      rostatus                 IN   VARCHAR2,
      filename                 IN   VARCHAR2,
      tfn                      IN   NUMBER,
      insertbreak              IN   VARCHAR2,
      prem                     IN   VARCHAR2,
      dealtype                 IN   VARCHAR2,
      pre                      IN   VARCHAR2,
      suff                     IN   VARCHAR2,
      financestatus            IN   VARCHAR2,
      voucherst                IN   VARCHAR2,
      adcode                   IN   VARCHAR2,
      rodatetime               IN   VARCHAR2,
      spacearea                IN   VARCHAR2,
      vat                      IN   VARCHAR2,
      bookstat                 IN   VARCHAR2,
      cio_id                   IN   VARCHAR2,
      receipt_no               IN   VARCHAR2,
      uom                      IN   VARCHAR2,
      bgcolor                  IN   VARCHAR2,
      validdate                IN   VARCHAR2,
      agencyratecode           IN   VARCHAR2,
      audit1                   IN   VARCHAR2,
      book_insert_date         IN   VARCHAR2,
      agencycomm               IN   VARCHAR2,
      rateaudit                IN   VARCHAR2,
      billaudit                IN   VARCHAR2,
      bill_type                IN   VARCHAR2,
      invoice_no1              IN   VARCHAR2,
      copybooking              IN   VARCHAR2,
      ratecompagnecy           IN   VARCHAR2,
      addagenycomm             IN   VARCHAR2,
      agencycommlinkretainer   IN   VARCHAR2,
      subeditionr              IN   VARCHAR2,
      classifiedbilltype       IN   VARCHAR2,
      displaybilltype          IN   VARCHAR2,
      billformat               IN   VARCHAR2,
      ratechk                  IN   VARCHAR2,
      allpkg                   IN   VARCHAR2,
      dayrate1                 IN   VARCHAR,
      schemetype               IN   VARCHAR2,
      pincludeclassi           IN   VARCHAR2,
      receiptformat            IN   VARCHAR2,
      v_cash_receipt           IN   VARCHAR2,
      v_bill_orderwiselast     IN   VARCHAR2,
      v_floor_chk              IN   VARCHAR2,
      unsoldflag               IN   VARCHAR2,
      supplystopper            IN   NUMBER,
      drprokeychk              IN   VARCHAR2,
      agencycomm_seq           IN   VARCHAR2,
      creditreciept            IN   VARCHAR,
      cashindisplay            IN   VARCHAR,
      cashinclassified         IN   VARCHAR,
      v_rate_audit_pref        IN   VARCHAR,
      v_barcoding_allow        IN   VARCHAR2,
      v_fmgbills               IN   VARCHAR2,
      v_billed_cashdis         IN   VARCHAR2,
      v_billed_cashcls         IN   VARCHAR,
      v_drpbackdate            IN   VARCHAR,
      dockitbooking            IN   VARCHAR2,
      allowprevbooking         IN   VARCHAR2,
      ro_wisecashbill          IN   VARCHAR2,
      chkval                   IN   VARCHAR2,
      approval1                IN   VARCHAR2,
      pckstatus                IN   VARCHAR2,
      cash_disc                IN   VARCHAR2,
      cash_amt                 IN   VARCHAR2,
      repeatday                IN   VARCHAR2,
      premiumedit              IN   VARCHAR2,
      p_bill_generation        IN   VARCHAR2,
      p_publication_center     IN   VARCHAR,
      P_allow_discount_prem IN varchar,
      P_SCHEME_BILLING IN VARCHAR,
      P_ALLOW_PDC in varchar,
      P_TYPE_FOR_MANUL_BILL in varchar,
      p_ret_after_bank IN varchar2
      
   )
   AS
   BEGIN
      INSERT INTO preferrences
                  ("comp_code", "userid", "rate_gr_code", "autogenerated",
                   "currency_code", "date_format", "solo", "breakup",
                   "blackwhitecode", "rostatus", "File_name", "Tfn",
                   "Insert_breakup", "Premium_type", "Deal_type", "prefix",
                   "suffix", "financestatus", "voucherst", "Ad_category",
                   "Ro_datetime", "Space_area", "Vat", "Booking_status",
                   "Cio_id", "Receipt_no", "uom_code",
                   "Bgcolor_publication", "chkfor_valid_pubdates",
                   "Agency_ratecode", "audit", "book_insert_date",
                   "agencycomm", "rate_audit", "bill_audit", "billtype",
                   "invoice_no", "copy_booking", "RATE_COMPANY_AGENCY",
                   "ADDITIONAL_AGENCY_COMM", "AGENCY_RETAINER_COMM",
                   "SUBEDITIONRATE", cls_billtype, dis_billtype,
                   billing_format, rate_check, all_package, dayrate,
                   scheme_type, disp_clsbill, receipt_format,
                   cash_receipt_bill, bill_orderwslast, floor_chk,
                   unsold_entry_flag, supply_stop_percentage, rokeycheck,
                   agencycomm_seq_com, credit_recipt, disp_cashbill,
                   cla_cashbill, rate_audit_pref, barcoding_allowed,
                   fmg_bill_dis, bill_disp_cashbill, bill_cla_cashbill,
                   backdatereceipt, dockit_booking, "Allowed_old_date",
                   rowise_cashbooking, cash_discount, cash_discounttype,
                   repeat_day_type, premium_edit, bill_generation_prior,
                   publication_ho,SPLDISC_ALLOWPREM,BILL_SCHEME,ALLOWED_PDC_DAYS_RECEIPT,AD_TYPE_MANUL_BILL,ALLOW_RET_AFTER_BANK 
                  )
           VALUES (compcode, userid, ratecode11, code,
                   curr, DATEFORMAT, solo, breakup,
                   bwcode, rostatus, filename, tfn,
                   insertbreak, prem, dealtype, pre,
                   suff, financestatus, voucherst, adcode,
                   rodatetime, spacearea, vat, bookstat,
                   cio_id, receipt_no, uom,
                   bgcolor, validdate,
                   agencyratecode, audit1, book_insert_date,
                   agencycomm, rateaudit, billaudit, bill_type,
                   invoice_no1, copybooking, ratecompagnecy,
                   addagenycomm, agencycommlinkretainer,
                   subeditionr, classifiedbilltype, displaybilltype,
                   billformat, ratechk, allpkg, dayrate1,
                   schemetype, pincludeclassi, receiptformat,
                   v_cash_receipt, v_bill_orderwiselast, v_floor_chk,
                   unsoldflag, supplystopper, drprokeychk,
                   agencycomm_seq, creditreciept, cashindisplay,
                   cashinclassified, v_rate_audit_pref, v_barcoding_allow,
                   v_fmgbills, v_billed_cashdis, v_billed_cashcls,
                   v_drpbackdate, dockitbooking, allowprevbooking,
                   ro_wisecashbill, cash_amt, cash_disc,
                   repeatday, premiumedit, p_bill_generation,
                   p_publication_center,P_allow_discount_prem,P_SCHEME_BILLING,P_ALLOW_PDC,P_TYPE_FOR_MANUL_BILL,p_ret_after_bank 
                  );
   END wesp_submitdate_p;
END wesp_submitdate;
/


/****************update by dhananjay for edition master********************************/
CREATE OR REPLACE package HT18JULY.editiontxtsave  is type t_accounts_type is ref cursor;
procedure editiontxtsave_p
(
peditoncode  IN      varchar2,
pcompcode   IN      varchar2,
puserid     IN      varchar2,
ptxtsun     IN      varchar2,
ptxtmon     IN      varchar2,
ptxttue     IN      varchar2,
ptxtwed     IN      varchar2,
ptxtthu     IN      varchar2,
ptxtfri     IN      varchar2,
ptxtsat     IN      varchar2
);
procedure editiontxtmodify
(
peditoncode  IN      varchar2,
pcompcode   IN      varchar2,
puserid     IN      varchar2,
ptxtsun     IN      varchar2,
ptxtmon     IN      varchar2,
ptxttue     IN      varchar2,
ptxtwed     IN      varchar2,
ptxtthu     IN      varchar2,
ptxtfri     IN      varchar2,
ptxtsat     IN      varchar2
);

procedure checkedtiontxt
(
pcompcode   IN       varchar2,
peditoncode IN       varchar2,
puserid     IN       varchar2,
p_accounts         OUT   t_accounts_type
);
END editiontxtsave;
/


CREATE OR REPLACE package BODY HT18JULY.editiontxtsave  AS
procedure editiontxtsave_p
(
peditoncode IN      varchar2,
pcompcode   IN      varchar2,
puserid     IN      varchar2,
ptxtsun     IN      varchar2,
ptxtmon     IN      varchar2,
ptxttue     IN      varchar2,
ptxtwed     IN      varchar2,
ptxtthu     IN      varchar2,
ptxtfri     IN      varchar2,
ptxtsat     IN      varchar2
)
as
begin
insert into SELECT_EDITION_TXT(COMP_CODE,EDITION_CODE,TXTSUN,TXTMON,TXTTUE,TXTWED,TXTTHU,TXTFRI,TXTSAT,USERID) 
           values(pcompcode,peditoncode,ptxtsun,ptxtmon,ptxttue,ptxtwed,ptxtthu,ptxtfri,ptxtsat,puserid);
commit;
end;

procedure editiontxtmodify
(
peditoncode  IN      varchar2,
pcompcode   IN      varchar2,
puserid     IN      varchar2,
ptxtsun     IN      varchar2,
ptxtmon     IN      varchar2,
ptxttue     IN      varchar2,
ptxtwed     IN      varchar2,
ptxtthu     IN      varchar2,
ptxtfri     IN      varchar2,
ptxtsat     IN      varchar2
)
as
begin
update  SELECT_EDITION_TXT set txtsun=ptxtsun,txtmon=ptxtmon,txttue=ptxttue,txtwed=ptxtwed,txtthu=ptxtthu,txtfri=ptxtfri,txtsat=ptxtsat where comp_code=pcompcode and EDITION_CODE=peditoncode;

end;

procedure checkedtiontxt
(
pcompcode   IN       varchar2,
peditoncode IN       varchar2,
puserid     IN       varchar2,
p_accounts         OUT   t_accounts_type
)
AS 
BEGIN
open p_accounts for
select * from SELECT_EDITION_TXT where comp_code=pcompcode and EDITION_CODE=peditoncode;
END;
END editiontxtsave;
/

/*******************package*******************************/
CREATE OR REPLACE PACKAGE HT18JULY.websp_editordelete Is

Procedure websp_editordelete_P (
EditonCode in varchar2,
userid in varchar2,
compcode in varchar2
);

End websp_editordelete ;
/

CREATE OR REPLACE PACKAGE BODY HT18JULY.websp_editordelete  Is
Procedure websp_editordelete_P (
EditonCode in varchar2,
userid in varchar2,
compcode in varchar2
) As
countnum number;
Begin

select count(*) into countnum from tbl_booking_insert where "Edition_Code"=EditonCode;
if countnum=0 then
delete from SELECT_EDITION_DAY where "edition_code"=EditonCode and "comp_code"=compcode;
delete from edit_date where "Comp_Code"=compcode and "Edition_Code"=EditonCode;
delete from EDITION_MAST where "Edition_Code"=EditonCode and "Comp_Code"=compcode;

delete from SELECT_EDITION_TXT where "EDITION_CODE"=EditonCode and "COMP_CODE"=compcode;
end if;

End websp_editordelete_P;

End websp_editordelete;
/


/*******************end ********************************/


/**********************end edition master************************************/




/****************update by dhananjay for Ad category master********************************/
CREATE OR REPLACE PACKAGE HT18JULY.slelectadcattxtsave  IS type t_accounts_type is ref cursor;
 procedure slelectadcattxtsave_p
(
padcatcode  IN      varchar2,
pcompcode   IN      varchar2,
puserid     IN      varchar2,
ptxtsun     IN      varchar2,
ptxtmon     IN      varchar2,
ptxttue     IN      varchar2,
ptxtwed     IN      varchar2,
ptxtthu     IN      varchar2,
ptxtfri     IN      varchar2,
ptxtsat     IN      varchar2
);

procedure slelectadtxtmodify
(
padcatcode      IN   varchar2,
pcompcode       IN   varchar2,
puserid         IN   varchar2,
ptxtsun         IN   varchar2,
ptxtmon         IN   varchar2,
ptxttue         IN   varchar2,
ptxtwed         IN   varchar2,
ptxtthu         IN   varchar2,
ptxtfri         IN   varchar2,
ptxtsat         IN   varchar2
);
procedure checkadtxt
(
pcompcode  IN       varchar2,
padcatcode IN       varchar2,
puserid    IN       varchar2,
p_accounts         OUT   t_accounts_type
);
END slelectadcattxtsave ;
/


CREATE OR REPLACE PACKAGE BODY HT18JULY.slelectadcattxtsave AS
 PROCEDURE slelectadcattxtsave_p(
    padcatcode      IN      varchar2,
    pcompcode       IN      varchar2,
    puserid         IN      varchar2,
    ptxtsun         IN      varchar2,
    ptxtmon         IN      varchar2,
    ptxttue         IN      varchar2,
    ptxtwed         IN      varchar2,
    ptxtthu         IN      varchar2,
    ptxtfri         IN      varchar2,
    ptxtsat         IN      varchar2
)
as
begin
insert into Select_AdvCat_txt(COMP_CODE,ADV_CAT_CODE,TXTSUN,TXTMON,TXTTUE,TXTWED,TXTTHU,TXTFRI,TXTSAT,USERID) 
           values(pcompcode,padcatcode,ptxtsun,ptxtmon,ptxttue,ptxtwed,ptxtthu,ptxtfri,ptxtsat,puserid);
commit;
end;

procedure slelectadtxtmodify
(
padcatcode      IN   varchar2,
pcompcode       IN   varchar2,
puserid         IN   varchar2,
ptxtsun         IN   varchar2,
ptxtmon         IN   varchar2,
ptxttue         IN   varchar2,
ptxtwed         IN   varchar2,
ptxtthu         IN   varchar2,
ptxtfri         IN   varchar2,
ptxtsat         IN   varchar2
)

as
begin
update  Select_AdvCat_txt set txtsun=ptxtsun,txtmon=ptxtmon,txttue=ptxttue,txtwed=ptxtwed,txtthu=ptxtthu,txtfri=ptxtfri,txtsat=ptxtsat where comp_code=pcompcode and Adv_Cat_Code=padcatcode;
end;

procedure checkadtxt
(
pcompcode  IN       varchar2,
padcatcode IN       varchar2,
puserid    IN       varchar2,
p_accounts         OUT   t_accounts_type
)
as
BEGIN 
open p_accounts for
select * from Select_AdvCat_txt where comp_code=pcompcode and Adv_Cat_Code=padcatcode;
END;
end slelectadcattxtsave;
/
/*******************end********************************/

/*******************package*******************************/
CREATE OR REPLACE PACKAGE HT18JULY.advcatdel is
procedure advcatdel_p(compcode in varchar2,adcatcode in varchar2);
end advcatdel;
/

CREATE OR REPLACE PACKAGE BODY HT18JULY.advcatdel is
procedure advcatdel_p(compcode in varchar2,adcatcode in varchar2)as
countnum number;
countnum1 number;
begin
select count(*) into countnum from tbl_booking_insert where "Ad_Cat"=adcatcode;
select count(*) into countnum1 from rate_mast where "Adv_Cat_Code"=adcatcode;
if countnum=0 and  countnum1=0 then
delete from adv_cat_mast where "Comp_Code"=compcode and "Adv_Cat_Code"=adcatcode;

delete from CategoryWiseEdition where "Comp_code"=compcode and "Adv_Cat_Code"=adcatcode;

delete from select_AdvCat_day where "comp_code"=compcode  and "Adv_Cat_Code"=adcatcode;

delete from select_AdvCat_txt where "COMP_CODE"=compcode  and "ADV_CAT_CODE"=adcatcode;

end if;


end advcatdel_p;
end advcatdel;
/

/*******************end********************************/

/**********************end Ad category master************************************/








//////////////////////strat by  shipra issue no 9143\\\\\\\\\\\\\\\\\\\\\\\\\\\


CREATE OR REPLACE PACKAGE HT18JULY.Websp_Executeagency
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE websp_executeagency_p (
      compcode           IN       VARCHAR2,
      userid             IN       VARCHAR2,
      agentcode          IN       VARCHAR2,
      subagencycode      IN       VARCHAR2,
      agencyname1        IN       VARCHAR2,
      alias              IN       VARCHAR2,
      agenttype          IN       VARCHAR2,
      agentcategory      IN       VARCHAR2,
      agentsubcategory   IN       VARCHAR2,
      city               IN       VARCHAR2,
      COUNT1             IN       VARCHAR2,
      branchcode         IN       VARCHAR2,
      billf              in       varchar2,
      p_accounts         OUT      t_accounts_cursor
   );
END Websp_Executeagency;
/








CREATE OR REPLACE PACKAGE BODY HT18JULY.Websp_Executeagency
IS
   PROCEDURE websp_executeagency_p (
      compcode           IN       VARCHAR2,
      userid             IN       VARCHAR2,
      agentcode          IN       VARCHAR2,
      subagencycode      IN       VARCHAR2,
      agencyname1        IN       VARCHAR2,
      alias              IN       VARCHAR2,
      agenttype          IN       VARCHAR2,
      agentcategory      IN       VARCHAR2,
      agentsubcategory   IN       VARCHAR2,
      city               IN       VARCHAR2,
      COUNT1              IN       VARCHAR2,
      branchcode         IN       VARCHAR2,
      billf              in       varchar2,
  
      p_accounts         OUT      t_accounts_cursor
   )
   AS
      agencyname2      VARCHAR (50);
      agentcode1       VARCHAR (12);
      subagencycode1   VARCHAR (15);
      alias1           VARCHAR (30);
   BEGIN
  DELETE FROM FIRST1 ; COMMIT;
   --  INSERT INTO FIRST1


    OPEN p_accounts FOR

     SELECT "Comp_Code", "Agency_Type_Code", "Agency_Cat_Code","BILL_EMAIL",
                "Agency_SubCat_Code", "Agency_Code", "Agency_Name" AS "Agency_Name",
                "Agency_Alias", "Agency_HO", "Add1", "Street", "City_Code",
                "Zip", "Dist_Code", "State_Code", "Country_Code", "Phone",
                "Fax", "EmailID", "URL", "Buss_Start_Date", "Enroll_Date",
                "MRV_Ref_No", "No_of_VTS", "Credit_Days", "PAN_No", "TAN_No",
                "ST_ACC_No", "Pay_Mode_Code",
                (SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE") AS "status_name",
                "Status_Reason", "Remarks", "UserID", SYSDATE AS "current_Datetime", "UserID",
                "SUB_Agency_HO" AS "SUB_Agency_HO", "SUB_Agency_Code" AS "SUB_Agency_Code", "BILL_TO", "ALERT",
                "CREDIT_LIMIT", "CODE", "Representative_code" as "representative_code", "pin_code",
                "region",
                (SELECT "TO_DATE"
                   FROM STATUS_DETAIL
                  WHERE ROWNUM <= 1
                    AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode") AS "to_date",
                "Type", "code_subcode", "zone_code", "Add2", "Add3",
                "CREDIT_TYPE", "acagency", "fax1", "Rate_Group",
                "qbc_userid",(select "DEPO_CODE" from ad_user where ad_user."AGENCY_CODE"=agency_mast."code_subcode"  AND ROWNUM<=1) AS "DEPOCODE",
                (select "AGENCY_CODE" from ad_user where ad_user."AGENCY_CODE"=agency_mast."code_subcode"  AND ROWNUM<=1) AS "AGENCYCODE","TALUKA","Branch_code",/*(select dist_mst."Dist_Name" from dist_mst where dist_mst."Dist_Code"=agency_mast.DISTRICT and "Comp_Code"=compcode) as */DISTRICT,/*(select state_mst."State_Name" from state_mst where state_mst."State_Code"=agency_mast.STATE and "Comp_Code"=compcode) as */STATE,BILL_FREQUENCY,OLD_AGENCY,BOOKING_TYPE,VAT,
                RATE_REVISE,EDTN_WISE_BILL_REQ ,EXECUTIVE,AGENCY_DESIGNATION
           FROM AGENCY_MAST
                WHERE ("Comp_Code" = compcode OR compcode IS NULL)
                AND ("Agency_Code" like agentcode||'%')
                AND ("SUB_Agency_Code" like  subagencycode   OR subagencycode IS NULL)
                AND ("Agency_Name" like agencyname1||'%')-- OR agencyname1  IS NULL)
                AND ("Agency_Alias" like alias   OR alias IS NULL)
                AND ("Agency_Type_Code" like agenttype   OR agenttype IS NULL)
                 AND ("Branch_code" like branchcode   OR branchcode IS NULL)
                AND ("Agency_Cat_Code"like agentcategory   OR agentcategory IS NULL)
                AND (BILL_FREQUENCY =billf OR billf IS NULL);












/*

DECLARE

 CURSOR c1 IS SELECT  SUB_AGENCY_CODE FROM FIRST1 ORDER BY sub_agency_code;
 AuthorID VARCHAR(100);
 BEGIN



OPEN c1;
LOOP
FETCH c1 INTO AuthorID;

EXIT WHEN c1%NOTFOUND;













UPDATE FIRST1 SET STATUS_NAME= (SELECT   "STATUS_NAME"    FROM STATUS_DETAIL WHERE AGENCY_SUBCAT_CODE=AuthorID AND ROWNUM<=1)
 WHERE SUB_AGENCY_CODE=AuthorID;

UPDATE FIRST1 SET TO_DATE= (SELECT "TO_DATE"    FROM STATUS_DETAIL WHERE AGENCY_SUBCAT_CODE=AuthorID AND ROWNUM<=1  )
 WHERE SUB_AGENCY_CODE=AuthorID;
END LOOP;

CLOSE c1;
END;







OPEN p_accounts FOR
SELECT  COMP_CODE AS "Comp_Code", AGENCY_TYPE_CODE AS "Agency_Type_Code", AGENCY_CAT_CODE AS "Agency_Cat_Code" , AGENCY_SUBCAT_CODE AS "Agency_SubCat_Code" , AGENCY_CODE AS "Agency_Code", AGENCY_NAME AS "Agency_Name" , AGENCY_ALIAS AS "Agency_Alias" , AGENCY_HO AS "Agency_HO", ADD1 AS "Add1", STREET AS "Street" , CITY_CODE AS "City_Code", ZIP AS "Zip", DIST_CODE AS "Dist_Code", STATE_CODE AS "State_Code", COUNTRY_CODE AS "Country_Code", PHONE AS "Phone" , FAX AS "Fax", EMAILID AS "EmailID", URL, BUSS_START_DATE AS "Buss_Start_Date", ENROLL_DATE AS "Enroll_Date", MRV_REF_NO AS "MRV_Ref_No", NO_OF_VTS AS "No_of_VTS", CREDIT_DAYS AS "Credit_Days", PAN_NO, TAN_NO, ST_ACC_NO, PAY_MODE_CODE AS "Pay_Mode_Code" , STATUS_NAME, STATUS_REASON AS "Status_Reason" , REMARKS AS "Remarks", USERID AS "UserID", CURRENT_DATETIME AS "current_Datetime", USERS AS "users", SUB_AGENCY_HO AS "SUB_Agency_HO", SUB_AGENCY_CODE AS "SUB_Agency_Code", BILL_TO, ALERT, CREDIT_LIMIT, CODE, REPRESENTATIVE_CODE AS "Representative_code", PIN_CODE AS"pin_code"  , Region AS "region", TO_DATE, "TYPE" AS "Type", CODE_SUBCODE AS "code_subcode", ZONE_CODE AS "zone_code", ADD2 AS "Add2", ADD3 AS "Add2", CREDIT_TYPE, ACAGENCY AS "acagency", FAX1 AS "fax1" , RATE_GROUP AS "Rate_Group", QBC_USERID AS "qbc_userid"
  FROM FIRST1      WHERE COMP_CODE = compcode OR compcode IS NULL
                AND AGENCY_CODE LIKE agentcode || '%' OR agentcode IS NULL
                AND SUB_AGENCY_CODE LIKE subagencycode || '%'  OR subagencycode IS NULL
                AND AGENCY_NAME LIKE agencyname1 || '%' OR agencyname1  IS NULL
                AND AGENCY_ALIAS LIKE alias || '%'  OR alias IS NULL
                AND AGENCY_TYPE_CODE LIKE agenttype || '%'  OR agenttype IS NULL
                AND AGENCY_CAT_CODE LIKE agentcategory  || '%' OR agentcategory IS NULL;

*/

       END websp_executeagency_p;
END Websp_Executeagency;
/










CREATE OR REPLACE PACKAGE HT18JULY.websp_saveagent
IS
   PROCEDURE websp_saveagent_p (
      compcode             IN   VARCHAR2,
      agencytype           IN   VARCHAR2,
      agentcategory        IN   VARCHAR2,
      agentcategory2       IN   VARCHAR2,
      agentcode            IN   VARCHAR2,
      agentname            IN   VARCHAR2,
      alias                IN   VARCHAR2,
      agencyho             IN   VARCHAR2,
      txtfax1              IN   VARCHAR2,
      address              IN   VARCHAR2,
      street               IN   VARCHAR2,
      city                 IN   VARCHAR2,
      district1             IN   VARCHAR2,
      state1                IN   VARCHAR2,
      country              IN   VARCHAR2,
      phone                IN   VARCHAR2,
      fax                  IN   VARCHAR2,
      mail                 IN   VARCHAR2,
      url1                  IN   VARCHAR2,
      bussinessstartdate   IN   DATE,
      enrolldate           IN   DATE,
      novts                IN   VARCHAR2,
      credit               IN   VARCHAR2,
      pan                  IN   VARCHAR2,
      TAN                  IN   VARCHAR2,
      stacno               IN   VARCHAR2,
      paymode              IN   VARCHAR2,
      status               IN   VARCHAR2,
      remarks              IN   VARCHAR2,
      userid               IN   VARCHAR2,
      mrerefferenceno      IN   VARCHAR2,
      subagencyho          IN   VARCHAR2,
      agencycode           IN   VARCHAR2,
      billto               IN   VARCHAR2,
      alert                IN   VARCHAR2,
      creditlimit          IN   VARCHAR2,
      code                 IN   VARCHAR2,
      representative       IN   VARCHAR2,
      pin                  IN   VARCHAR2,
      region1               IN   VARCHAR2,
      TYPE1                 IN   VARCHAR2,
      ZONE1                 IN   VARCHAR2,
      address1             IN   VARCHAR2,
      address2             IN   VARCHAR2,
      curtype              IN   VARCHAR2,
      acagen               IN   VARCHAR2,
      rategrp              IN   VARCHAR2,
      qbcuserid            IN   VARCHAR2,
      taluka1            IN   VARCHAR2,
      branchcode         in varchar2,
      hddistcode            IN   VARCHAR2,
      hdstatecode         in varchar2,
      billf               in varchar2,
      oldagency           in varchar2,
      booktype1           in varchar2,
      vat1                in varchar2,
      p_raterevise        in varchar2,
      p_editionwisebilling    in varchar2,
      pexecutive          in varchar2,
      pemail in varchar2,
      page_desig in varchar2
   );
END websp_saveagent;
/









CREATE OR REPLACE PACKAGE BODY HT18JULY.websp_saveagent
IS
   PROCEDURE websp_saveagent_p (
      compcode             IN   VARCHAR2,
      agencytype           IN   VARCHAR2,
      agentcategory        IN   VARCHAR2,
      agentcategory2       IN   VARCHAR2,
      agentcode            IN   VARCHAR2,
      agentname            IN   VARCHAR2,
      alias                IN   VARCHAR2,
      agencyho             IN   VARCHAR2,
      txtfax1              IN   VARCHAR2,
      address              IN   VARCHAR2,
      street               IN   VARCHAR2,
      city                 IN   VARCHAR2,
      district1             IN   VARCHAR2,
      state1                IN   VARCHAR2,
      country              IN   VARCHAR2,
      phone                IN   VARCHAR2,
      fax                  IN   VARCHAR2,
      mail                 IN   VARCHAR2,
      url1                  IN   VARCHAR2,
      bussinessstartdate   IN   DATE,
      enrolldate           IN   DATE,
      novts                IN   VARCHAR2,
      credit               IN   VARCHAR2,
      pan                  IN   VARCHAR2,
      TAN                  IN   VARCHAR2,
      stacno               IN   VARCHAR2,
      paymode              IN   VARCHAR2,
      status               IN   VARCHAR2,
      remarks              IN   VARCHAR2,
      userid               IN   VARCHAR2,
      mrerefferenceno      IN   VARCHAR2,
      subagencyho          IN   VARCHAR2,
      agencycode           IN   VARCHAR2,
      billto               IN   VARCHAR2,
      alert                IN   VARCHAR2,
      creditlimit          IN   VARCHAR2,
      code                 IN   VARCHAR2,
      representative       IN   VARCHAR2,
      pin                  IN   VARCHAR2,
      region1               IN   VARCHAR2,
      TYPE1                 IN   VARCHAR2,
      ZONE1                IN   VARCHAR2,
      address1             IN   VARCHAR2,
      address2             IN   VARCHAR2,
      curtype              IN   VARCHAR2,
      acagen               IN   VARCHAR2,
      rategrp              IN   VARCHAR2,
      qbcuserid            IN   VARCHAR2,
      taluka1            IN   VARCHAR2,
        branchcode         in varchar2,
        hddistcode            IN   VARCHAR2,
      hdstatecode         in varchar2,
      billf               in varchar2,
      oldagency           in varchar2,
      booktype1           in varchar2,
      vat1                in varchar2,
      p_raterevise        in varchar2,
      p_editionwisebilling    in varchar2,
      pexecutive              in varchar2,
      pemail in varchar2,
      page_desig in varchar2
   )
   AS
   BEGIN
      INSERT INTO agency_mast
                  ("Comp_Code", "Agency_Type_Code", "Agency_Cat_Code",
                   "Agency_SubCat_Code", "Agency_Code", "Agency_Name",
                   "Agency_Alias", "Agency_HO", "Add1", "Street",
                   "City_Code", "Dist_Code", "State_Code", "Country_Code",
                   "Phone", "Fax", "EmailID", "URL", "Buss_Start_Date",
                   "Enroll_Date", "MRV_Ref_No", "No_of_VTS", "Credit_Days",
                   "PAN_No", "TAN_No", "ST_ACC_No", "Pay_Mode_Code",
                   "Status_Reason", "Remarks", "UserID", "SUB_Agency_HO",
                   "SUB_Agency_Code", "acagency", "ALERT", "CREDIT_LIMIT",
                   "CODE", "Representative_code", "pin_code", "region",
                   "Type", "code_subcode", "zone_code", "Add2", "Add3",
                   "CREDIT_TYPE", "BILL_TO", "fax1", "Rate_Group",
                   "qbc_userid","Creation_Datetime","TALUKA","Branch_code",DISTRICT,STATE,BILL_FREQUENCY,OLD_AGENCY,BOOKING_TYPE,VAT,RATE_REVISE,EDTN_WISE_BILL_REQ,executive,"BILL_EMAIL" ,AGENCY_DESIGNATION
                  )
           VALUES (compcode,agencytype, agentcategory, agentcategory2,
                    agentcode, agentname,
                   alias, agencyho, address, street,
                   city, district1, state1, country,
                   phone, fax, mail, url1, bussinessstartdate,
                   enrolldate, mrerefferenceno, novts, credit,
                   pan, TAN, stacno, paymode,
                   status, remarks, userid, subagencyho,
                   agencycode, acagen, alert, creditlimit,
                   code, representative, pin, region1,
                   TYPE1, agentcode || agencycode, zone1, address1, address2,
                   curtype, billto, txtfax1, rategrp,
                   qbcuserid,sysdate,taluka1,branchcode,hddistcode,hdstatecode,billf,oldagency,booktype1,vat1, p_raterevise,p_editionwisebilling,pexecutive ,pemail,page_desig
                  );
     /* TO INSERT DATA IN AGENCY HISTORY LOG*/
                 INSERT INTO AGENCY_REMARK_DETAIL(COMP_CODE, AGENCY_CODE, SUB_AGENCY_CODE, CODE_SUBCODE, AGENCY_ALERT, AGENCY_REMARK, USERID)
                        VALUES(compcode,agentcode,agencycode,agentcode || agencycode,alert,remarks,userid);

      COMMIT;
   END websp_saveagent_p;
END websp_saveagent;
/














CREATE OR REPLACE PACKAGE HT18JULY.websp_agencymodify
IS
   PROCEDURE websp_agencymodify_p (
      compcode             IN   VARCHAR2,
      agencytype           IN   VARCHAR2,
      agentcategory        IN   VARCHAR2,
      agentcategory2       IN   VARCHAR2,
      agentcode            IN   VARCHAR2,
      agentname            IN   VARCHAR2,
      alias                IN   VARCHAR2,
      agencyho             IN   VARCHAR2,
      TYPE1                 IN   VARCHAR2,
      address              IN   VARCHAR2,
      street               IN   VARCHAR2,
      city                 IN   VARCHAR2,
      zip                  IN   VARCHAR2,
      district1             IN   VARCHAR2,
      state1               IN   VARCHAR2,
      country              IN   VARCHAR2,
      phone                IN   VARCHAR2,
      txtfax2              IN   VARCHAR2,
      fax                  IN   VARCHAR2,
      mail                 IN   VARCHAR2,
      url1                  IN   VARCHAR2,
      bussinessstartdate   IN   DATE,
      enrolldate           IN   DATE,
      novts                IN   VARCHAR2,
      credit               IN   VARCHAR2,
      pan                  IN   VARCHAR2,
      TAN                  IN   VARCHAR2,
      stacno               IN   VARCHAR2,
      paymode              IN   VARCHAR2,
      status               IN   VARCHAR2,
      remarks              IN   VARCHAR2,
      userid               IN   VARCHAR2,
      mrerefferenceno      IN   VARCHAR2,
      subagencyho          IN   VARCHAR2,
      agencycode           IN   VARCHAR2,
      billto               IN   VARCHAR2,
      alert1                IN   VARCHAR2,
      creditlimit          IN   VARCHAR2,
      code                 IN   VARCHAR2,
      region1               IN   VARCHAR2,
      representative       IN   VARCHAR2,
      pincode              IN   VARCHAR2,
      stacno1              IN   VARCHAR2,
      ZONE1                 IN   VARCHAR2,
      address1             IN   VARCHAR2,
      address2             IN   VARCHAR2,
      curtype              IN   VARCHAR2,
      acagen               IN   VARCHAR2,
      rategrp              IN   VARCHAR2,
      qbcuserid            IN   VARCHAR2,
      depocode             IN    VARCHAR2,
      taluka1              IN    VARCHAR2,
      branchcode           IN    VARCHAR2,
      hddistcode           in varchar2,
      hdstatecode          in varchar2 ,
      billf                in varchar2,
      oldagen              in varchar2,
      booktype1            in varchar2,
      vat1                 in varchar2,
      p_raterevise         in varchar2,
      p_insertremarkdet    in varchar2,
      p_editionwisebilling    in varchar2,
      pexecutive           in varchar2,
      pemail in varchar2,
        page_desig in varchar2
   );
END websp_agencymodify;
/









CREATE OR REPLACE PACKAGE BODY HT18JULY.websp_agencymodify
IS
   PROCEDURE websp_agencymodify_p (
      compcode             IN   VARCHAR2,
      agencytype           IN   VARCHAR2,
      agentcategory        IN   VARCHAR2,
      agentcategory2       IN   VARCHAR2,
      agentcode            IN   VARCHAR2,
      agentname            IN   VARCHAR2,
      alias                IN   VARCHAR2,
      agencyho             IN   VARCHAR2,
      TYPE1                 IN   VARCHAR2,
      address              IN   VARCHAR2,
      street               IN   VARCHAR2,
      city                 IN   VARCHAR2,
      zip                  IN   VARCHAR2,
      district1             IN   VARCHAR2,
      state1                IN   VARCHAR2,
      country              IN   VARCHAR2,
      phone                IN   VARCHAR2,
      txtfax2              IN   VARCHAR2,
      fax                  IN   VARCHAR2,
      mail                 IN   VARCHAR2,
      url1                  IN   VARCHAR2,
      bussinessstartdate   IN   DATE,
      enrolldate           IN   DATE,
      novts                IN   VARCHAR2,
      credit               IN   VARCHAR2,
      pan                  IN   VARCHAR2,
      TAN                  IN   VARCHAR2,
      stacno               IN   VARCHAR2,
      paymode              IN   VARCHAR2,
      status               IN   VARCHAR2,
      remarks              IN   VARCHAR2,
      userid               IN   VARCHAR2,
      mrerefferenceno      IN   VARCHAR2,
      subagencyho          IN   VARCHAR2,
      agencycode           IN   VARCHAR2,
      billto               IN   VARCHAR2,
      alert1                IN   VARCHAR2,
      creditlimit          IN   VARCHAR2,
      code                 IN   VARCHAR2,
      region1               IN   VARCHAR2,
      representative       IN   VARCHAR2,
      pincode              IN   VARCHAR2,
      stacno1              IN   VARCHAR2,
      zone1                IN   VARCHAR2,
      address1             IN   VARCHAR2,
      address2             IN   VARCHAR2,
      curtype              IN   VARCHAR2,
      acagen               IN   VARCHAR2,
      rategrp              IN   VARCHAR2,
      qbcuserid            IN   VARCHAR2,
      depocode                IN    VARCHAR2,
      taluka1              IN    VARCHAR2,
      branchcode           IN    VARCHAR2,
      hddistcode           in varchar2,
      hdstatecode          in varchar2 ,
      billf                in varchar2,
      oldagen              in varchar2,
      booktype1            in varchar2,
      vat1                 in varchar2,
      p_raterevise         in varchar2,
      p_insertremarkdet    in varchar2,
      p_editionwisebilling    in varchar2,
      pexecutive            in varchar2,
      pemail in varchar2,
        page_desig in varchar2
   )
   AS
   BEGIN
      UPDATE agency_mast
         SET "Rate_Group" = rategrp,
             "Agency_Code" = agentcode,
             "fax1" = txtfax2,
             "CREDIT_TYPE" = curtype,
             "zone_code" = zone1,
             "Type" = TYPE1,
             "Agency_Type_Code" = agencytype,
             "Agency_Cat_Code" = agentcategory,
             "Agency_SubCat_Code" = agentcategory2,
             "Agency_Name" = agentname,
             "Agency_Alias" = alias,
             "Agency_HO" = agencyho,
             "Add1" = address,
             "Street" = street,
             "City_Code" = city,
             "Zip" = zip,
             "Dist_Code" = district1,
             "State_Code" = state1,
             "Country_Code" = country,
             "Phone" = phone,
             "Fax" = fax,
             "EmailID" = mail,
             "URL" = url1,
             "Buss_Start_Date" = bussinessstartdate,
             "Enroll_Date" = enrolldate,
             "MRV_Ref_No" = mrerefferenceno,
             "No_of_VTS" = novts,
             "Credit_Days" = credit,
             "PAN_No" = pan,
             "TAN_No" = TAN,
             "ST_ACC_No" = stacno1,
             "Pay_Mode_Code" = paymode,
             "Status_Reason" = status,
             "Remarks" = remarks,
             "SUB_Agency_HO" = subagencyho,
             "SUB_Agency_Code" = agencycode,
             "BILL_TO" = acagen,
             "acagency" = billto,
             "ALERT" = alert1,
             "CREDIT_LIMIT" = creditlimit,
             "CODE" = code,
             "region" = region1,
             "Representative_code" = representative,
             "pin_code" = pincode,
             "Add2" = address1,
             "Add3" = address2,
             "qbc_userid" = qbcuserid,
             "TALUKA"=taluka1,
             "Branch_code"=branchcode, DISTRICT=hddistcode,STATE=hdstatecode,BILL_FREQUENCY=billf,OLD_AGENCY=oldagen,BOOKING_TYPE=booktype1,VAT=vat1,
             RATE_REVISE=p_raterevise,EDTN_WISE_BILL_REQ =p_editionwisebilling,executive=pexecutive,BILL_EMAIL=pemail,AGENCY_DESIGNATION= page_desig 
       WHERE "Comp_Code" = compcode AND "SUB_Agency_Code" = agencycode;

        --UPDATE ad_user SET "DEPO_CODE"=depocode where "AGENCY_CODE"=agentcode;
        
        /* TO INSERT DATA IN AGENCY HISTORY LOG*/
        IF(p_insertremarkdet = '1') THEN
                 INSERT INTO AGENCY_REMARK_DETAIL(COMP_CODE, AGENCY_CODE, SUB_AGENCY_CODE, CODE_SUBCODE, AGENCY_ALERT, AGENCY_REMARK, USERID)
                        VALUES(compcode,agentcode,agencycode,agentcode || agencycode,alert1,remarks,userid);
                        
        END IF;

      COMMIT;
   END websp_agencymodify_p;
END websp_agencymodify;
/









/////////////////////end of issue no 9143//////////////////////////

////////////////////////issue 9051 23-nov-2012//////////////////////////////////

                                                                     
                                                                     
                                                                     
                                             
CREATE OR REPLACE PROCEDURE rate_expiry(
compcode      in varchar2,
adtypcod      in varchar2, 
ratecod       in varchar2,
categrycod    in varchar2,
colorcod      in varchar2,
uomcod        in varchar2,
frdate        in varchar2,
todate        in varchar2,
packgcod      in varchar2,
extra1        in varchar2,
extra2        in varchar2,
p_solo        in  varchar2,
pedtn_flag    in  varchar2,--m for main,e for edition ,s for suppliment and a for all
p_accounts out cur_type_new1.cursor_type) as

Begin
 -- advpos_prem_mast
IF NVL (p_solo, '') = 'S' THEN
    If pedtn_flag='M' then
        OPEN p_Accounts FOR
        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate) 
        and exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=Rate_Mast."combin_desc" and 
        (("Edition_Type"='Main Edition' and pedtn_flag='M') ));
  
    Elsif pedtn_flag='E' then
        OPEN p_Accounts FOR
        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate) 
        and exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=Rate_Mast."combin_desc" and 
        (("Edition_Type"='Edition' and pedtn_flag='E') ));
       
    Elsif pedtn_flag='S' then
        OPEN p_Accounts FOR
        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate) 
        and exists(select 'x' from supplement_mast where supplement_mast."Supp_Alias"=Rate_Mast."combin_desc" and pedtn_flag='S');
    Else
        OPEN p_Accounts FOR
        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate) ;
             
    End if;
End if;    
       
IF NVL (p_solo, '') = 'P' THEN
    If pedtn_flag='M' then
    
        OPEN p_Accounts FOR
        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate) 
        and "rateuniqueid" in(select "ratemastid" from Rate_details where
        "rate_code"=nvl(ratecod,"rate_code")
        and exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=Rate_details."edition_name" and 
        (("Edition_Type"='Main Edition' and pedtn_flag='M') ))) ;
    
    Elsif pedtn_flag='E' then
    
        OPEN p_Accounts FOR
        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate)
        and "rateuniqueid" in(select "ratemastid" from Rate_details where
        "rate_code"=nvl(ratecod,"rate_code")
        and exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=Rate_details."edition_name" and 
        (("Edition_Type"='Edition' and pedtn_flag='E') ))) ;

    Elsif pedtn_flag='S' then
    
        OPEN p_Accounts FOR
        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate)
        and "rateuniqueid" in(select "ratemastid" from Rate_details where
        "rate_code"=nvl(ratecod,"rate_code")
        and exists(select 'x' from supplement_mast where supplement_mast."Supp_Alias"=Rate_details."edition_name" and 
        pedtn_flag='S' )) ;
    Else
        OPEN p_Accounts FOR
        select "Rate_Mast_Code",
        (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
        ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) as "Premium","Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate) ;    
    End if;        
End if;

End rate_expiry;
/




/////////////////////////end////////////////////////////////////



//////////////////////////********rate expiry and rate import export pocedure(Anuj 27/nov/2012)*****///////////////////////////////////////////



                                                                     
                                                                     
                                                                     
                                             
CREATE OR REPLACE PROCEDURE getdata_export (
   adtype_p         IN  VARCHAR2,
   fromdate_p       IN  VARCHAR2,
   todate_p         IN  VARCHAR2,
   p_solo           IN  VARCHAR2,
   p_ratecode       IN  VARCHAR2,
   p_pubcent        IN  VARCHAR2,
   pedtn_flag       IN  VARCHAR2,--M for Main,E for Edition ,S for Suppliment and A for All
   p_packagecode    IN  VARCHAR2,
   padcatg          IN  VARCHAR2,
   puom_code        IN  VARCHAR2,
   pextra1          IN  VARCHAR2,
   pextra2          IN  VARCHAR2,
   pextra3          IN  VARCHAR2,
   pextra4          IN  VARCHAR2,
   pextra5          IN  VARCHAR2,
   p_accounts       OUT cur_type_new1.cursor_type)
IS
v_gr    number(5);
BEGIN
   v_gr:=FN_SPLITFIELD(p_packagecode,',');
   v_gr:=FN_SPLITFIELD1(padcatg,',');
   
   delete from test1;insert into test1(vstring,vstring2) values('getdata_export',adtype_p||','||fromdate_p||','||todate_p||','||p_solo||','||p_ratecode||','||p_pubcent||','||pedtn_flag||','||p_packagecode||','||padcatg||','||puom_code||','||pextra1||','||pextra2||','||pextra3||','||pextra4||','||pextra5);commit;
   
   IF NVL (p_solo, '') = 'S' THEN
      OPEN p_accounts FOR
            select x."rateuniqueid",x."pub_center", x."Adv_Cat_Code", x."Adv_subcat_code",x."Ad_Subcat4", x."Ad_Subcat5",x."Ad_subcat6",x."Premium", x."Scheme_Name",
            x."Comp_code",x."Rate_Mast_Code", x."Adv_Type_Code", x."Rate_Gr_Code", x."Currency",x."combin_desc", x."Combin_Code",x."Uom",x."Size_To",x."Size_From",
            x."consumption_Per", x."Color",x."Col_chr_typ", x."Remarks",x.Valid_From AS valid_from,x.Valid_To AS valid_to, 
            x."Package_Name" as "Package_Name",
            x."Adv_Cat_Name" as "Adv_Cat_Name",
            x."Adv_Subcat_Name" as "Adv_Subcat_Name",
            x."Uom_Name" as "Uom_Name",
            x."Week_Day_Rate", x."Week_min_rate",x."Week_Extra_Rate", x."Focus_Day_Rate",x."Focus_min_rate", x."Focus_extra_rate",
            x."userid", x."Creation_DateTime", x."Premium_Charges",x."weekend_rate", x."weekend_min_rate",x."weekend_extra", x."chksolo",x."min_ad_area", x."Edition_from",
            x."Edition_to", x."floor_amount",x."floor_discount", x."From_insertion",x."To_insertion", x."Agency_type",
            x."Client_cat", x."Max_Area", x.sun_rate,x.mon_rate, x.tue_rate, x.wed_rate,x.thu_rate, x.fri_rate, x.sat_rate,x.sun_rate_extra, x.mon_rate_extra,
            x.tue_rate_extra, x.wed_rate_extra,x.thu_rate_extra, x.fri_rate_extra,x.sat_rate_extra, x.maxwidth,x.priority, x.vat_detail, x.adon,x.ref_id, x.cancellation_charges,x.position_prem,(select "Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code" =x.position_prem and advpos_type_mast."Comp_Code" =x."Comp_code") as "Position Premium Name",
            x."ratemastid" "ratemastid", x."id" "id",x."rate_code" AS "rate_code" from
            (select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
            r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
            r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'dd/mm/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'dd/mm/yyyy') AS valid_to, 
            (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
            (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
            (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
            (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
            r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
            r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
            r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
            r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
            r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,r.position_prem,(select "Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code" =r.position_prem and advpos_type_mast."Comp_Code" =r."Comp_code") as "Position Premium Name",
            '' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
            --,'' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
            FROM rate_mast r
            WHERE "Adv_Type_Code" = adtype_p  AND "Valid_From" >= fromdate_p AND "Valid_To" <= todate_p AND INSTR ("combin_desc", '+') <= 0 
            and r."Rate_Mast_Code"=nvl(p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=p_pubcent or p_pubcent is null) and 
            exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=r."combin_desc" and 
            (("Edition_Type"='Main Edition' and pedtn_flag='M') or ("Edition_Type"='Edition' and pedtn_flag='E')))
            and (r."Combin_Code" in(select edition_name from result) or p_packagecode is null)
            and (r."Adv_Cat_Code" in(select edition_name from result1) or padcatg is null)
            and (r."Uom"=puom_code or puom_code is null)
            union
            select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
            r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
            r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'dd/mm/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'dd/mm/yyyy') AS valid_to, 
            (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
            (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
            (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
            (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
            r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
            r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
            r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
            r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
            r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,r.position_prem,(select "Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code" =r.position_prem and advpos_type_mast."Comp_Code" =r."Comp_code") as "Position Premium Name",
            '' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
            --,'' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
            FROM rate_mast r
            WHERE "Adv_Type_Code" = adtype_p  AND "Valid_From" >= fromdate_p AND "Valid_To" <= todate_p AND INSTR ("combin_desc", '+') <= 0
            and r."Rate_Mast_Code"=nvl(p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=p_pubcent or p_pubcent is null) and 
            exists(select 'x' from supplement_mast where supplement_mast."Supp_Alias"=r."combin_desc" and pedtn_flag='S')
            and (r."Combin_Code" in(select edition_name from result) or p_packagecode is null)
            and (r."Adv_Cat_Code" in(select edition_name from result1) or padcatg is null)
            and (r."Uom"=puom_code or puom_code is null)
            union
            select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
            r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
            r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'dd/mm/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'dd/mm/yyyy') AS valid_to, 
            (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
            (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
            (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
            (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
            r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
            r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
            r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
            r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
            r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,r.position_prem,(select "Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code" =r.position_prem and advpos_type_mast."Comp_Code" =r."Comp_code") as "Position Premium Name",
            '' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
            --,'' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
            FROM rate_mast r
            WHERE r."Adv_Type_Code" = adtype_p  AND r."Valid_From" >= fromdate_p AND r."Valid_To" <= todate_p AND INSTR (r."combin_desc", '+') <= 0
            and r."Rate_Mast_Code"=nvl(p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=p_pubcent or p_pubcent is null) and pedtn_flag='A'
            and (r."Combin_Code" in(select edition_name from result) or p_packagecode is null)
            and (r."Adv_Cat_Code" in(select edition_name from result1) or padcatg is null)
            and (r."Uom"=puom_code or puom_code is null)) x
         ORDER BY x."rateuniqueid";
   END IF;

   IF NVL (p_solo, '') = 'P'
   THEN
      if pedtn_flag='M' then
        OPEN p_accounts FOR
        select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
            r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
            r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'dd/mm/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'dd/mm/yyyy') AS valid_to, 
            (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
            (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
            (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
            (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
            r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
            r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
            r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
            r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
            r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,r.position_prem,(select "Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code" =r.position_prem and advpos_type_mast."Comp_Code" =r."Comp_code") as "Position Premium Name",
            '' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
            --, '' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
            FROM rate_mast r
            WHERE "Adv_Type_Code" = adtype_p
              AND "Valid_From" >= fromdate_p
              AND "Valid_To" <= todate_p
              AND INSTR ("combin_desc", '+') > 0
              and r."Rate_Mast_Code"=nvl(p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=p_pubcent or p_pubcent is null)
              and (r."Combin_Code" in(select edition_name from result) or p_packagecode is null)
              and (r."Adv_Cat_Code" in(select edition_name from result1) or padcatg is null)
              and (r."Uom"=puom_code or puom_code is null)
              and "rateuniqueid" in(select "ratemastid" from Rate_details where
            "rate_code"=nvl(p_ratecode,"rate_code")
            and exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=Rate_details."edition_name" and 
            "Edition_Type"='Main Edition' ))
            ORDER BY r."rateuniqueid";
            
      elsif pedtn_flag='E' then
        
        OPEN p_accounts FOR
        select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
            r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
            r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'dd/mm/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'dd/mm/yyyy') AS valid_to, 
            (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
            (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
            (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
            (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
            r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
            r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
            r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
            r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
            r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,r.position_prem,(select "Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code" =r.position_prem and advpos_type_mast."Comp_Code" =r."Comp_code") as "Position Premium Name",
            '' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
            --, '' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
            FROM rate_mast r
            WHERE "Adv_Type_Code" = adtype_p
              AND "Valid_From" >= fromdate_p
              AND "Valid_To" <= todate_p
              AND INSTR ("combin_desc", '+') > 0
              and r."Rate_Mast_Code"=nvl(p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=p_pubcent or p_pubcent is null)
              and (r."Combin_Code" in(select edition_name from result) or p_packagecode is null)
              and (r."Adv_Cat_Code" in(select edition_name from result1) or padcatg is null)
              and (r."Uom"=puom_code or puom_code is null)
              and "rateuniqueid" in(select "ratemastid" from Rate_details where
            "rate_code"=nvl(p_ratecode,"rate_code")
            and exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=Rate_details."edition_name" and 
            "Edition_Type"='Edition' ))
            ORDER BY r."rateuniqueid";           
      
      elsif pedtn_flag='S' then
        
        OPEN p_accounts FOR
        select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
            r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
            r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'dd/mm/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'dd/mm/yyyy') AS valid_to, 
            (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
            (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
            (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
            (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
            r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
            r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
            r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
            r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
            r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,r.position_prem,(select "Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code" =r.position_prem and advpos_type_mast."Comp_Code" =r."Comp_code") as "Position Premium Name",
            '' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
            --, '' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
            FROM rate_mast r
            WHERE "Adv_Type_Code" = adtype_p
              AND "Valid_From" >= fromdate_p
              AND "Valid_To" <= todate_p
              AND INSTR ("combin_desc", '+') > 0
              and r."Rate_Mast_Code"=nvl(p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=p_pubcent or p_pubcent is null)
              and (r."Combin_Code" in(select edition_name from result) or p_packagecode is null)
              and (r."Adv_Cat_Code" in(select edition_name from result1) or padcatg is null)
              and (r."Uom"=puom_code or puom_code is null)
              and "rateuniqueid" in(select "ratemastid" from Rate_details where
            "rate_code"=nvl(p_ratecode,"rate_code")
            and exists(select 'x' from supplement_mast where supplement_mast."Supp_Alias"=Rate_details."edition_name"))
            ORDER BY r."rateuniqueid";         
      
      else
        OPEN p_accounts FOR
        select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
        r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
        r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'dd/mm/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'dd/mm/yyyy') AS valid_to, 
        (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
        (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
        (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
        (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
        r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
        r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
        r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
        r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
        r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,r.position_prem,(select "Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code" =r.position_prem and advpos_type_mast."Comp_Code" =r."Comp_code") as "Position Premium Name",
        '' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
        --, '' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
        FROM rate_mast r
        WHERE "Adv_Type_Code" = adtype_p
        AND "Valid_From" >= fromdate_p
        AND "Valid_To" <= todate_p
        AND INSTR ("combin_desc", '+') > 0
        and r."Rate_Mast_Code"=nvl(p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=p_pubcent or p_pubcent is null)
        and (r."Combin_Code" in(select edition_name from result) or p_packagecode is null)
        and (r."Adv_Cat_Code" in(select edition_name from result1) or padcatg is null)
        and (r."Uom"=puom_code or puom_code is null)
        ORDER BY r."rateuniqueid";      
      end if;

   END IF;
/*open p_Accounts for

SELECT RATE_MAST."rateuniqueid", RATE_MAST."Comp_code", RATE_MAST."Rate_Mast_Code", RATE_MAST."Adv_Type_Code", RATE_MAST."Adv_Cat_Code", RATE_MAST."Adv_subcat_code", RATE_MAST."Rate_Gr_Code", RATE_MAST."Currency", RATE_MAST."combin_desc", RATE_MAST."Combin_Code", RATE_MAST."Uom", to_char(RATE_MAST."Valid_From",'mm/dd/yyyy') as Valid_From, to_char(RATE_MAST."Valid_To",'mm/dd/yyyy') as Valid_To, RATE_MAST."Size_To", RATE_MAST."Size_From", RATE_MAST."consumption_Per", RATE_MAST."Color", RATE_MAST."Col_chr_typ", RATE_MAST."Remarks", RATE_MAST."Week_Day_Rate", RATE_MAST."Week_min_rate", RATE_MAST."Week_Extra_Rate", RATE_MAST."Focus_Day_Rate", RATE_MAST."Focus_min_rate", RATE_MAST."Focus_extra_rate", RATE_MAST."userid", RATE_MAST."Creation_DateTime", RATE_MAST."Premium", RATE_MAST."Premium_Charges", RATE_MAST."weekend_rate", RATE_MAST."weekend_min_rate", RATE_MAST."weekend_extra", RATE_MAST."chksolo", RATE_MAST."min_ad_area", RATE_MAST."Edition_from", RATE_MAST."Edition_to", RATE_MAST."floor_amount", RATE_MAST."floor_discount", RATE_MAST."Scheme_Name", RATE_MAST."Ad_Subcat4", RATE_MAST."Ad_Subcat5", RATE_MAST."Ad_subcat6", RATE_MAST."From_insertion", RATE_MAST."To_insertion", RATE_MAST."Agency_type", RATE_MAST."Client_cat", RATE_MAST."Max_Area", RATE_MAST."pub_center", RATE_MAST.SUN_RATE, RATE_MAST.MON_RATE, RATE_MAST.TUE_RATE, RATE_MAST.WED_RATE, RATE_MAST.THU_RATE, RATE_MAST.FRI_RATE, RATE_MAST.SAT_RATE, RATE_MAST.SUN_RATE_EXTRA, RATE_MAST.MON_RATE_EXTRA, RATE_MAST.TUE_RATE_EXTRA, RATE_MAST.WED_RATE_EXTRA, RATE_MAST.THU_RATE_EXTRA, RATE_MAST.FRI_RATE_EXTRA, RATE_MAST.SAT_RATE_EXTRA, RATE_MAST.MAXWIDTH, RATE_MAST.PRIORITY,RATE_MAST.VAT_DETAIL,RATE_MAST.ADON,RATE_MAST.REF_ID,RATE_MAST.CANCELLATION_CHARGES
,RATE_DETAILS."ratemastid", RATE_DETAILS."id", RATE_DETAILS."rate_code", RATE_DETAILS."edition_name", RATE_DETAILS."Week_Day_Rate", RATE_DETAILS."Week_min_rate", RATE_DETAILS."Week_Extra_Rate", RATE_DETAILS."Focus_Day_Rate", RATE_DETAILS."Focus_min_rate", RATE_DETAILS."Focus_extra_rate", RATE_DETAILS."userid", RATE_DETAILS."Creation_DateTime", RATE_DETAILS."Comp_Code", RATE_DETAILS."Solus_week_rate", RATE_DETAILS."Solus_focus_rate", RATE_DETAILS."weekend_rate", RATE_DETAILS."weekend_min", RATE_DETAILS."weekend_extra", RATE_DETAILS."Solo_weekendrate", RATE_DETAILS.SUN_RATE, RATE_DETAILS.MON_RATE, RATE_DETAILS.TUE_RATE, RATE_DETAILS.WED_RATE, RATE_DETAILS.THU_RATE, RATE_DETAILS.FRI_RATE, RATE_DETAILS.SAT_RATE, RATE_DETAILS.SUN_RATE_EXTRA, RATE_DETAILS.MON_RATE_EXTRA, RATE_DETAILS.TUE_RATE_EXTRA, RATE_DETAILS.WED_RATE_EXTRA, RATE_DETAILS.THU_RATE_EXTRA, RATE_DETAILS.FRI_RATE_EXTRA, RATE_DETAILS.SAT_RATE_EXTRA, RATE_DETAILS.PKGNAME
 FROM RATE_MAST FULL JOIN RATE_DETAILS ON
 RATE_MAST."rateuniqueid"=RATE_DETAILS."ratemastid"
 WHERE "Adv_Type_Code"=adtype_p
 and "Valid_From">=fromdate_p AND "Valid_To"<=todate_p
   ORDER BY RATE_MAST."rateuniqueid";*/
END getdata_export;
/



------------------------------------------------------------------




                                                                     
                                                                     
                                                                     
                                             
CREATE OR REPLACE PROCEDURE rate_expiry(
compcode      in varchar2,
adtypcod      in varchar2, 
ratecod       in varchar2,
categrycod    in varchar2,
colorcod      in varchar2,
uomcod        in varchar2,
frdate        in varchar2,
todate        in varchar2,
packgcod      in varchar2,
extra1        in varchar2,
extra2        in varchar2,
p_solo        in  varchar2,
pedtn_flag    in  varchar2,--m for main,e for edition ,s for suppliment and a for all
p_accounts out cur_type_new1.cursor_type) as

Begin
 -- advpos_prem_mast
delete from test1;insert into test1(vstring,vstring2) 
values('rate_expiry ','compcode '||compcode||','||adtypcod||','||ratecod||','||categrycod||','||colorcod||','||uomcod||','||frdate||','||todate||','||packgcod||','||p_solo||','||pedtn_flag||','||extra1||','||extra2);
 
IF NVL (p_solo, '') = 'S' THEN
    If pedtn_flag='M' then
        OPEN p_Accounts FOR
        select "Rate_Mast_Code"||'/'||upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Rate_Mast_Code",
        case when nvl(rate_mast."Adv_subcat_code",'0')='0' then
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") 
        else
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code")||'/'||
            (Select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code"
            and adv_subcat_mast."Adv_Subcat_Code"=rate_mast."Adv_subcat_code")
        end 
        as "Adv_Cat_Code",
        "Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        case when POSITION_PREM='0' or POSITION_PREM is null then
            upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) 
        else
            case when "Premium"='0' or "Premium"='' then
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            else
                upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium"))||'/'||
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            end    
        end as "Premium",
        "Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate) 
        and exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=Rate_Mast."combin_desc" and 
        "Edition_Type"='Main Edition' ) order by "Rate_Mast_Code","Adv_Cat_Code";
  
    Elsif pedtn_flag='E' then
        OPEN p_Accounts FOR
        select "Rate_Mast_Code"||'/'||upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Rate_Mast_Code",
        case when nvl(rate_mast."Adv_subcat_code",'0')='0' then
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") 
        else
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code")||'/'||
            (Select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code"
            and adv_subcat_mast."Adv_Subcat_Code"=rate_mast."Adv_subcat_code")
        end 
        as "Adv_Cat_Code",
        "Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        case when POSITION_PREM='0' or POSITION_PREM is null then
            upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) 
        else
            case when "Premium"='0' or "Premium"='' then
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            else
                upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium"))||'/'||
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            end    
        end as "Premium",
        "Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate) 
        and exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=Rate_Mast."combin_desc" and 
        "Edition_Type"='Edition'  ) order by "Rate_Mast_Code","Adv_Cat_Code";
       
    Elsif pedtn_flag='S' then
        OPEN p_Accounts FOR
        select "Rate_Mast_Code"||'/'||upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Rate_Mast_Code",
        case when nvl(rate_mast."Adv_subcat_code",'0')='0' then
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") 
        else
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code")||'/'||
            (Select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code"
            and adv_subcat_mast."Adv_Subcat_Code"=rate_mast."Adv_subcat_code")
        end 
        as "Adv_Cat_Code",
        "Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        case when POSITION_PREM='0' or POSITION_PREM is null then
            upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) 
        else
            case when "Premium"='0' or "Premium"='' then
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            else
                upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium"))||'/'||
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            end    
        end as "Premium",
        "Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate) 
        and exists(select 'x' from supplement_mast where supplement_mast."Supp_Alias"=Rate_Mast."combin_desc")
        order by "Rate_Mast_Code","Adv_Cat_Code";
    Else
        OPEN p_Accounts FOR
        select "Rate_Mast_Code"||'/'||upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Rate_Mast_Code",
        case when nvl(rate_mast."Adv_subcat_code",'0')='0' then
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") 
        else
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code")||'/'||
            (Select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code"
            and adv_subcat_mast."Adv_Subcat_Code"=rate_mast."Adv_subcat_code")
        end 
        as "Adv_Cat_Code",
        "Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        case when POSITION_PREM='0' or POSITION_PREM is null then
            upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) 
        else
            case when "Premium"='0' or "Premium"='' then
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            else
                upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium"))||'/'||
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            end    
        end as "Premium",
        "Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate) order by "Rate_Mast_Code","Adv_Cat_Code";
             
    End if;
End if;    
       
IF NVL (p_solo, '') = 'P' THEN
    If pedtn_flag='M' then
    
        OPEN p_Accounts FOR
        select "Rate_Mast_Code"||'/'||upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Rate_Mast_Code",
        case when nvl(rate_mast."Adv_subcat_code",'0')='0' then
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") 
        else
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code")||'/'||
            (Select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code"
            and adv_subcat_mast."Adv_Subcat_Code"=rate_mast."Adv_subcat_code")
        end 
        as "Adv_Cat_Code",
        "Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        case when POSITION_PREM='0' or POSITION_PREM is null then
            upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) 
        else
            case when "Premium"='0' or "Premium"='' then
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            else
                upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium"))||'/'||
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            end    
        end as "Premium",
        "Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate) 
        and "rateuniqueid" in(select "ratemastid" from Rate_details where
        "rate_code"=nvl(ratecod,"rate_code")
        and exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=Rate_details."edition_name" and 
        "Edition_Type"='Main Edition' )) order by "Rate_Mast_Code","Adv_Cat_Code";
    
    Elsif pedtn_flag='E' then
    
        OPEN p_Accounts FOR
        select "Rate_Mast_Code"||'/'||upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Rate_Mast_Code",
        case when nvl(rate_mast."Adv_subcat_code",'0')='0' then
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") 
        else
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code")||'/'||
            (Select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code"
            and adv_subcat_mast."Adv_Subcat_Code"=rate_mast."Adv_subcat_code")
        end 
        as "Adv_Cat_Code",
        "Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        case when POSITION_PREM='0' or POSITION_PREM is null then
            upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) 
        else
            case when "Premium"='0' or "Premium"='' then
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            else
                upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium"))||'/'||
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            end    
        end as "Premium",
        "Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate)
        and "rateuniqueid" in(select "ratemastid" from Rate_details where
        "rate_code"=nvl(ratecod,"rate_code")
        and exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=Rate_details."edition_name" and 
        "Edition_Type"='Edition')) order by "Rate_Mast_Code","Adv_Cat_Code";

    Elsif pedtn_flag='S' then
    
        OPEN p_Accounts FOR
        select "Rate_Mast_Code"||'/'||upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Rate_Mast_Code",
        case when nvl(rate_mast."Adv_subcat_code",'0')='0' then
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") 
        else
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code")||'/'||
            (Select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code"
            and adv_subcat_mast."Adv_Subcat_Code"=rate_mast."Adv_subcat_code")
        end 
        as "Adv_Cat_Code",
        "Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        case when POSITION_PREM='0' or POSITION_PREM is null then
            upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) 
        else
            case when "Premium"='0' or "Premium"='' then
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            else
                upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium"))||'/'||
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            end    
        end as "Premium",
        "Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate)
        and "rateuniqueid" in(select "ratemastid" from Rate_details where
        "rate_code"=nvl(ratecod,"rate_code")
        and exists(select 'x' from supplement_mast where supplement_mast."Supp_Alias"=Rate_details."edition_name")) order by "Rate_Mast_Code","Adv_Cat_Code";
    Else
        OPEN p_Accounts FOR
        select "Rate_Mast_Code"||'/'||upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Rate_Mast_Code",
        case when nvl(rate_mast."Adv_subcat_code",'0')='0' then
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") 
        else
            (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code")||'/'||
            (Select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code"
            and adv_subcat_mast."Adv_Subcat_Code"=rate_mast."Adv_subcat_code")
        end 
        as "Adv_Cat_Code",
        "Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
        case when POSITION_PREM='0' or POSITION_PREM is null then
            upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium")) 
        else
            case when "Premium"='0' or "Premium"='' then
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            else
                upper((select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium"))||'/'||
                upper((select "Pos_Type" from ADVPOS_TYPE_MAST where "Pos_Type_Code"=POSITION_PREM))
            end    
        end as "Premium",
        "Size_To","Size_From",
        "From_insertion","To_insertion",
        upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
        "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        "Adv_Type_Code"=nvl(adtypcod ,"Adv_Type_Code") and "Rate_Mast_Code"=nvl(ratecod,"Rate_Mast_Code")
        and "Adv_Cat_Code"=nvl(categrycod,"Adv_Cat_Code")
        and "Color" =nvl(colorcod,"Color") and "Uom"   =nvl(uomcod,"Uom")
        and ("Combin_Code"=packgcod or packgcod is null)
        and ("Valid_From"=frdate and "Valid_To"=todate) order by "Rate_Mast_Code","Adv_Cat_Code";    
    End if;        
End if;

End rate_expiry;
/


--------------------------------------------------------------------------------




                                                                     
                                                                     
                                                                     
                                             
CREATE OR REPLACE PACKAGE xlsratecode IS
Type T_Accounts_Cursor is Ref Cursor;
PROCEDURE  xlsratecode_p(
compcode in varchar2,
p_Accounts out T_Accounts_Cursor
);
End xlsratecode;
/
CREATE OR REPLACE PACKAGE BODY xlsratecode
IS
PROCEDURE  xlsratecode_p(
compcode in varchar2,
p_Accounts out T_Accounts_Cursor
)as
begin

Open p_Accounts for
select  distinct  "Rate_Mast_Code" AS "rate_mast_code" from   rate_mast  
where "Comp_code"= compcode 
and ((sysdate between "Valid_From" and "Valid_To")  OR ("Valid_From">=SYSDATE)) order by "Rate_Mast_Code";

End xlsratecode_p;

End xlsratecode;
/



///////////////////**************(End)*********************//////////




///////////start by shipra/////  attachment delete////////

/////////////////


CREATE OR REPLACE PROCEDURE HT18JULY.Attachment_delete111
(
pcompcode in varchar2,
pcompid in varchar2

 
)
is

begin


update tbl_booking_mast set "ATTACHMENT1"=null, "ATTACHMENT2"=null
where "Comp_code" =pcompcode and "cio_booking_id"=pcompid;


--update web_ad_master set rate_amt =prateAmt where reciept_no=preceiptNum and seqnum=pseqnum;


end ;
/


///////////////////////////


CREATE OR REPLACE PROCEDURE HT18JULY.Attachment_select11
(
pcompcode in varchar2,
pcompno in varchar2,
p_accounts1     OUT Cur_Type_New1.cursor_type

 
)
as

begin


open p_accounts1 for 

select * from tbl_booking_mast where "Comp_code"=pcompcode and "cio_booking_id"=pcompno;



end;
/
//////////end by shipra ///attachment delete//////////////



/////////////////////////////////************(issue no 8944 Anuj)**********************///////////////////////////////////


CREATE OR REPLACE procedure HT18JULY.executebooking_new_quotation1(
compcode   in   varchar2,
ciobookid  in   varchar2,
docno      in   varchar2 ,
keyno      in   varchar2,
rono       in   varchar2 ,
agencycode in   varchar2 ,
client     in   varchar2,
booking    in   varchar2,
dateformat in   varchar2,
revenue    in   varchar2,
p_accounts1 OUT   cur_type_new1.cursor_type,
p_accounts2 OUT   cur_type_new1.cursor_type,
p_accounts3 OUT   cur_type_new1.cursor_type,
p_accounts4 OUT   cur_type_new1.cursor_type)

as
 vquery           varchar2(8000);
 version1        number;
 count1          number;
 booking_type11  varchar2(8) ;
 --booking_type11:=3;
 
 BEGIN
 
  delete from tempbooking where sessionid = userenv ('sessionid');

 insert  into tempbooking(date_time, branch , booked_by,cio_booking_id ,prev_booking,applied_by,audit1,ro_no,ro_date,  
  caption,  bill_status,ro_status,agency_code,agency_address,client_code,client_address,
  agency_sub_code,dockit_no,executive_code,executive_zone,product_code,  brand_code, key_no,   bill_remarks,  
  print_remark,  package_code,no_of_insertion,insertion_date, repeating_day, ad_type_code,  ad_cat_code,
  ad_sub_cat_code,color_code, uom_code,  page_position_code,   page_type_code,page_no,  ad_size_type_code,ad_size_height ,
  ad_size_width , rate_code,scheme_type_code, currency_code, agrred_rate ,  agreed_amount, special_discount, 
  space_discount ,special_charges, agency_status, agency_type,agency_pay , agency_credit, 
  total_area, card_rate  , card_amount ,  discount ,discount_per,  bill_cycle, revenue_center ,
  bill_pay  , bill_height,bill_width ,bill_to  ,invoices ,vts,  bill_add ,
  trade_disc ,agency_out ,box_code ,box_no   ,box_agency,box_client ,
  box_address,comp_code,userid ,creation_datetime ,   booking_type,  tfn,
  coupan_ad ,campaign  ,bill_amount ,page_prem  , page_amount ,prem_per , 
  gross_amount  ,ad_size_column ,bill_column ,  bill_area  ,special_disc_per, space_disc_per,
  paid_ins , contract_rate ,deviation   ,  variant_code ,  contract_name ,contract_type, 
  card_name  ,card_type , card_month, card_year, card_number,receipt_no ,
  ad_subcat3 ,ad_subcat4 ,ad_subcat5 ,bg_color ,bullet_code,bullet_premium ,
  material_status,receipt_date,  prev_cioid ,prev_receipt,  prev_grossamt, region ,  
  variant,  colortype,logo_h,logo_w , logo_color ,logo_uom, sapid  ,  
  retainer, add_agency_comm,mobileno ,add_agency_comm_amt , retainer_comm ,retainer_comm_amt ,   
  cash_recieved ,doctype  ,app_remarks ,  translation_code, translation_premium , boxcharge )   
  SELECT date_time, branch, booked_by, cio_booking_id,
                prev_booking, applied_by, audit_q, RO_No, RO_Date,
                Caption, bill_status, ro_status, Agency_code,
                Agency_address, Client_code, Client_address,
                Agency_sub_code, Dockit_no, Executive_code,
                Executive_zone, Product_code, Brand_code, Key_no,
                Bill_remarks, Print_remark, Package_code,
                No_of_insertion, Insertion_date, Repeating_day,
                Ad_type_code, Ad_cat_code, Ad_sub_cat_code,
                Color_code, Uom_code, Page_position_code,
                Page_type_code, Page_no, Ad_size_type_code,
                Ad_size_height, Ad_size_width , 
Rate_code,Scheme_type_code, Currency_code, NVL(Agrred_rate,0),
                NVL(Agreed_amount,0), Special_discount, Space_discount,
                Special_charges, Agency_status, Agency_type,
                Agency_pay, Agency_credit, Total_area, Card_rate,
                Card_amount, NVL(Discount,0), Discount_per, Bill_cycle,
                Revenue_center, Bill_pay, Bill_height, Bill_width,
                Bill_to, Invoices, Vts, Bill_add, Trade_disc,
                Agency_out, Box_code, Box_no, Box_agency,
                Box_client, Box_address, Comp_code, Userid,
                Creation_datetime, Booking_type, Tfn, Coupan_ad,
                Campaign, Bill_amount, Page_prem, Page_amount,
                Prem_per, Gross_amount, Ad_size_column, Bill_column,
                Bill_area, Special_disc_per, Space_disc_per,
                Paid_ins, Contract_rate, Deviation, Variant_code,
                Contract_name, Contract_type, Card_name, Card_type,
                Card_month, Card_year, Card_number, Receipt_no,
                Ad_Subcat3, Ad_Subcat4, Ad_subcat5, Bg_color,
                Bullet_code, Bullet_premium, Material_status,
                Receipt_date, prev_cioid, prev_receipt,
                prev_grossamt, Region, Variant, Colortype, Logo_H,
                Logo_W, Logo_color, Logo_Uom,sapid,RETAINER,ADD_AGENCY_COMM,MOBILENO,ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,'''',doctype,APP_REMARKS,
                TRANSLATION_CODE, TRANSLATION_PREMIUM,
                (SELECT "Box_Charges_Native" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=BOX_CODE) AS boxcharge
                FROM TBL_BOOKING_MAST_Q --where comp_code='''+compcode+''''; 
                
                commit; 

if(ciobookid!='' or ciobookid is null ) then 
vquery:=vquery||'and  cio_booking_id = '''||ciobookid||'''' ;
end if;



OPEN p_accounts1 FOR 

SELECT  CASE dateformat
                       WHEN 'mm/dd/yyyy' THEN to_char(date_time,'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN to_char(date_time,'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN to_char(date_time,'yyyy/mm/dd')  END AS date_time,
                     branch,booked_by, cio_booking_id, prev_booking, applied_by,audit1, RO_No as "RO_No",
            CASE dateformat
                 WHEN 'mm/dd/yyyy' THEN to_char(RO_Date,'mm/dd/yyyy')
                 WHEN 'dd/mm/yyyy' THEN to_char(RO_Date,'dd/mm/yyyy')
                 WHEN 'yyyy/mm/dd' THEN to_char(RO_Date,'yyyy/mm/dd' )  END AS RO_Date,
                Caption, bill_status, ro_status as "ro_status",TEMPBOOKING.Agency_code,
                Agency_address, Client_code, Client_address,
                Agency_sub_code, Dockit_no, Executive_code,
                Executive_zone, Product_code, Brand_code, Key_no,
                Bill_remarks, Print_remark, Package_code,No_of_insertion as "No_of_insertion",
            CASE dateformat
                    WHEN 'mm/dd/yyyy' THEN to_char(Insertion_date,'mm/dd/yyyy')
                    WHEN 'dd/mm/yyyy' THEN to_char(Insertion_date,'dd/mm/yyyy')
                    WHEN 'yyyy/mm/dd' THEN to_char(Insertion_date,'yyyy/mm/dd')  END    AS "Insertion_date",
                   Repeating_day, Ad_type_code, Ad_cat_code,
                Ad_sub_cat_code, Color_code, Uom_code,
                Page_position_code, Page_type_code, Page_no,
                Ad_size_type_code, Ad_size_height as "Ad_size_height", Ad_size_width as "Ad_size_width", Rate_code,
                (SELECT "Scheme_Name" FROM SCHEME_MASTER WHERE "scheme_id" =TEMPBOOKING.Scheme_type_code )AS "Scheme_type_code",
                 Currency_code, Agrred_rate as "Agrred_rate", Agreed_amount as "Agreed_amount",
                Special_discount as "Special_discount", Space_discount as "Space_discount", Special_charges as "Special_charges",
                TEMPBOOKING.Comp_code, TEMPBOOKING.Userid,
                TEMPBOOKING.Agency_status, Agency_type, Agency_pay,
                Agency_credit, Total_area as "Total_area", Card_rate as "Card_rate", Card_amount as "Card_amount",
                Discount, Discount_per as "Discount_per", Bill_cycle, Revenue_center,
                Bill_pay, Bill_height, Bill_width,
                TEMPBOOKING.Bill_to, Invoices, Vts, Bill_add,
                Trade_disc as "Trade_disc", Agency_out as "Agency_out",TEMPBOOKING. Booking_type, Campaign,
                Page_prem, Page_amount, Prem_per, Gross_amount as "Gross_amount",
                Bill_amount as "Bill_amount", Box_code, Box_no, Box_agency,
                Box_client, Box_address, Tfn, Coupan_ad,
                Ad_size_column, Bill_column, Bill_area,
                Special_disc_per, Space_disc_per,
                AGENCY_MAST."Agency_Name" || '('|| AGENCY_MAST."code_subcode" || ')'||'('||(select city_mst."City_Name" from city_mst  where city_mst."City_Code"=agency_mast."City_Code") ||')' AS "AgencyName",
            ---    (SELECT EXEC_MAST.Exec_name + '(' + convert(varchar(100),EXEC_MAST.Exe_no)+ ')' FROM EXEC_MAST WHERE TEMPBOOKING.Executive_code = EXEC_MAST.Exe_noAND TEMPBOOKING.Comp_code = EXEC_MAST.comp_code) AS execname,
                (SELECT  PRODUCT_CAT_MAST."prod_desc" || '(' ||PRODUCT_CAT_MAST."prod_cat_code" || ')' FROM PRODUCT_CAT_MAST WHERE TEMPBOOKING.Product_code = PRODUCT_CAT_MAST."prod_cat_code" AND TEMPBOOKING.Comp_code = PRODUCT_CAT_MAST."comp_code") AS product, 
                Paid_ins  as "Paid_ins", Contract_rate, Deviation, Variant_code, Contract_name as "Contract_name", Contract_type, Card_name,Card_type,Card_month,Card_year,Card_number, Receipt_no,
(SELECT "catname"  FROM  AD_CAT3   WHERE AD_CAT3."catcode"=TEMPBOOKING.Ad_Subcat3)   as "SUBCAT3",
(SELECT "Cat_Name"  FROM  TBL_CAT4   WHERE TBL_CAT4."Cat_Code"=TEMPBOOKING.Ad_Subcat4) as "SUBCAT4"  ,
(SELECT "Cat_Name"  FROM  TBL_CAT5   WHERE TBL_CAT5."Cat_Code"=TEMPBOOKING.Ad_subcat5) as "SUBCAT5",
 Bg_color,Bullet_code, Bullet_premium,
 (SELECT "Agency_Name" FROM AGENCY_MAST WHERE "code_subcode" =TEMPBOOKING.Agency_sub_code and Comp_Code=TEMPBOOKING.Comp_code) AS "AgencySubCode",
                (SELECT "Cust_Name"||'('||"Cust_Code"||')' FROM CUST_MAST WHERE "Cust_Code" = Client_code) AS "Client",                                       
                (SELECT DISTINCT "Payment_Mode_Name" FROM PAYMENT_MODE_MAST WHERE PAYMENT_MODE_MAST."Comp_Code"=TEMPBOOKING.Comp_code  and "Pay_Mode_Code" = Agency_pay and "Comp_Code"=TEMPBOOKING.Comp_code) AS "PayMode",
                (SELECT "Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code" =TEMPBOOKING.Ad_cat_code and "Comp_Code"=TEMPBOOKING.Comp_code) AS "categoryname",
                (SELECT "Adv_Subcat_Name" FROM ADV_SUBCAT_MAST  WHERE ADV_SUBCAT_MAST."Adv_Subcat_Code" =TEMPBOOKING.Ad_sub_cat_code and Comp_Code=TEMPBOOKING.Comp_code)
                 AS "subcategoryname",
                (SELECT "brand_name" FROM BRAND_MST WHERE "brand_code" =TEMPBOOKING.Brand_code and "Comp_Code"=TEMPBOOKING.Comp_code ) AS "Brand",
                (SELECT "Uom_Name" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING.Uom_code and "Comp_Code"=TEMPBOOKING.Comp_code) AS "UOM",
                (SELECT "premiumname" FROM ADVPOS_PREM_MAST WHERE "Premiumcode" =TEMPBOOKING.Page_prem and "Comp_Code"=TEMPBOOKING.Comp_code) AS "PagePremium",
                 (SELECT "Pos_Type" FROM ADVPOS_TYPE_MAST
                  WHERE "Pos_Type_Code" = TEMPBOOKING.Page_position_code and Comp_Code=TEMPBOOKING.Comp_code) AS "PositionPremium",
                (SELECT "Curr_Name" FROM CURR_MAST WHERE "Curr_Code" = TEMPBOOKING.Currency_code and "Comp_Code"=TEMPBOOKING.Comp_code) AS "Currency",
                Material_status, Receipt_date AS "Receipt_date", TEMPBOOKING.Region,
                Variant, Colortype,
                (SELECT "UOM_DESC" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING.Uom_code and "Comp_Code"=TEMPBOOKING.Comp_code) AS "uom_desc",
                (SELECT "Logo" FROM UOM_MAST WHERE "Uom_Code" =TEMPBOOKING.Uom_code and "Comp_Code"=TEMPBOOKING.Comp_code) AS "logo",Logo_H, Logo_W, Logo_color, Logo_Uom,
                (SELECT "Logo_Uom" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING.Uom_code and "Comp_Code"=TEMPBOOKING.Comp_code)  AS "logocode",
                (SELECT "Box_Charges_Native" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING.Box_code and "Comp_Code"=TEMPBOOKING.Comp_code) AS "boxchrg",TEMPBOOKING.sapid,
                retainer,(SELECT "Retain_Name"||'('||"Retain_Code"||')' FROM RETAINERMASTER WHERE RETAINERMASTER."Retain_Code"=TEMPBOOKING."RETAINER" and "Comp_Code"=TEMPBOOKING.Comp_code) AS "RETAINER1",
                (SELECT "Package_Name" FROM combin_mast WHERE "Combin_Code" =TEMPBOOKING.Package_code and "Comp_Code"=TEMPBOOKING.Comp_code) as "Package_cod",(SELECT "Col_Name" FROM col_mast 
                WHERE "Col_Code" = TEMPBOOKING.Color_code and "Comp_Code"=TEMPBOOKING.Comp_code) as "Color_cod",(SELECT "Pos_Type" FROM advpos_type_mast WHERE "Pos_Type_Code" =TEMPBOOKING.Page_position_code and "Comp_Code"=TEMPBOOKING.Comp_code) as "Page_position_cod",
CASE TEMPBOOKING.Booking_type WHEN '1'  THEN 'BARTER'
                    WHEN  '2' THEN 'FMG'WHEN '3' THEN 'NORMAL'  
when '4' then 'INHOUSE' when '5' then 'COMPLIMENTARY'
END    AS "Book_type",
(SELECT "catname"  FROM  AD_CAT3   WHERE AD_CAT3."catcode"=TEMPBOOKING.Ad_Subcat3)  as "Subcat3",
(SELECT "Cat_Name"  FROM  TBL_CAT4   WHERE TBL_CAT4."Cat_Code"=TEMPBOOKING.Ad_Subcat4) as "Ad_Subcat4",
(SELECT "Cat_Name"  FROM  TBL_CAT5   WHERE TBL_CAT5."Cat_Code"=TEMPBOOKING.Ad_subcat5) as "Ad_subcat5",
 "RETAINER_COMM" AS "RETAINER_COMM",
(select "AUDIT_COMMENT" from TBL_BOOKING_MAST_Q where TBL_BOOKING_MAST_Q.cio_booking_id=TEMPBOOKING.cio_booking_id) as "remarks",
"ADD_AGENCY_COMM",
 (SELECT "Box_Charges_Type" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING.Box_code) AS "boxchargetype",
 "ADD_AGENCY_COMM_AMT","RETAINER_COMM","RETAINER_COMM_AMT",
(select "RO_COMMENT" from TBL_BOOKING_MAST_Q where TBL_BOOKING_MAST_Q.cio_booking_id=TEMPBOOKING.cio_booking_id) as "RO_COMMENT"
, "DOCTYPE","APP_REMARKS","TRANSLATION_PREMIUM",
 '' as "TRANS_TYPE",(SELECT "Box_Name" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING.Box_code) AS "boxname"
 FROM TEMPBOOKING, AGENCY_MAST WHERE AGENCY_MAST."code_subcode" = TEMPBOOKING.Agency_sub_code AND 
AGENCY_MAST."Comp_Code" =TEMPBOOKING.Comp_code ORDER BY TEMPBOOKING.Creation_datetime;

OPEN p_accounts2 FOR 
SELECT  MAX (VSEQNO) into VERSION1  FROM TBL_BOOKING_MAST_LOG  
 WHERE "Receipt_no" = ciobookid AND VSEQNO < (SELECT MAX (VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" = ciobookid);      


OPEN p_accounts3 FOR 

 SELECT   case dateformat
                     when 'mm/dd/yyyy' then to_char("date_time",'mm/dd/yyyy')
                     when 'dd/mm/yyyy'    then to_char("date_time",'dd/mm/yyyy')
                     when 'yyyy/mm/dd' then to_char("date_time",'yyyy/mm/dd')  end as "date_time",
                   "branch","booked_by", "cio_booking_id", "prev_booking", "applied_by","audit", "RO_No",
            case dateformat
                 when 'mm/dd/yyyy' then to_char("RO_Date",'mm/dd/yyyy')
                 when 'dd/mm/yyyy'    then to_char("RO_Date",'dd/mm/yyyy')
                 when 'yyyy/mm/dd' then to_char("RO_Date",'yyyy/mm/dd')   end as "RO_Date",
               "Caption","bill_status", "ro_status",
                TBL_BOOKING_MAST_LOG."Agency_code", "Agency_address",
                "Client_code", "Client_address", "Agency_sub_code",
                "Dockit_no", "Executive_code", "Executive_zone",
                "Product_code", "Brand_code", "Key_no", "Bill_remarks",
                "Print_remark", "Package_code", "No_of_insertion",
            case dateformat
                     when 'mm/dd/yyyy' then to_char("Insertion_date",'mm/dd/yyyy')
                  when 'dd/mm/yyyy'    then to_char("Insertion_date",'dd/mm/yyyy')
                     when 'yyyy/mm/dd' then to_char("Insertion_date",'yyyy/mm/dd')   end as "Insertion_date",
                "Repeating_day", "Ad_type_code", "Ad_cat_code",
                "Ad_sub_cat_code", "Color_code", "Uom_code",
                "Page_position_code", "Page_type_code", "Page_no",
                "Ad_size_type_code", "Ad_size_height", "Ad_size_width",
                "Rate_code", "Scheme_type_code", "Currency_code",
                "Agrred_rate", "Agreed_amount", "Special_discount",
                "Space_discount", "Special_charges",
                TBL_BOOKING_MAST_LOG."Comp_code",
                TBL_BOOKING_MAST_LOG."Userid",
                TBL_BOOKING_MAST_LOG."Agency_status", "Agency_type",
                 "Agency_pay", "Agency_credit", "Total_area", "Card_rate",
                "Card_amount", "Discount", "Discount_per", "Bill_cycle",
                "Revenue_center", "Bill_pay", "Bill_height", "Bill_width",
                TBL_BOOKING_MAST_LOG."Bill_to","Invoices", "Vts",
                "Bill_add","Trade_disc","Agency_out",TBL_BOOKING_MAST_LOG."Booking_type",    
                "Tfn","Coupan_ad","Campaign","Bill_amount","Page_prem","Page_amount","Prem_per",
                "Gross_amount","Ad_size_column","Bill_column","Bill_area","Special_disc_per","Space_disc_per",
                 agency_mast."Agency_Name" || '('|| agency_mast."code_subcode"|| ')' as agencyname,
              --(SELECT    EXEC_MAST."Exec_name" , EXEC_MAST."Exe_no" FROM EXEC_MAST ) WHERE TBL_BOOKING_MAST_LOG."Executive_code" = EXEC_MAST."Exe_no" AND TBL_BOOKING_MAST_LOG."Comp_code" = EXEC_MAST."comp_code")AS execname,
                (SELECT    PRODUCT_CAT_MAST."prod_desc" || '(' || PRODUCT_CAT_MAST."prod_cat_code" || ')'
                   FROM PRODUCT_CAT_MAST WHERE TBL_BOOKING_MAST_LOG."Product_code" =PRODUCT_CAT_MAST."prod_cat_code"
                    AND TBL_BOOKING_MAST_LOG."Comp_code" =PRODUCT_CAT_MAST."comp_code")AS product,
                "Paid_ins","Contract_rate","Deviation","Variant_code","Contract_name","Contract_type",        
"Card_name","Card_type","Card_month","Card_year","Card_number",    "Receipt_no",            
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                "Bullet_code","Bullet_premium", 
                (select "Agency_Name" from agency_mast where "code_subcode" =tbl_booking_mast_log."Agency_sub_code")as agencysubcode,
               nvl((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code" = "Client_code"),'' ) AS "Client",
                (SELECT distinct "Payment_Mode_Name" FROM PAYMENT_MODE_MAST WHERE "Comp_Code"=TBL_BOOKING_MAST_LOG."Comp_code" and "Pay_Mode_Code" = "Agency_pay") AS "PayMode",
                (SELECT "Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code" =TBL_BOOKING_MAST_LOG."Ad_cat_code")AS categoryname,
                (SELECT "Adv_Subcat_Name" FROM ADV_SUBCAT_MAST WHERE ADV_SUBCAT_MAST."Adv_Subcat_Code" =TBL_BOOKING_MAST_LOG."Ad_sub_cat_code")AS subcategoryname,
                (SELECT "brand_name" FROM BRAND_MST WHERE "brand_code" =TBL_BOOKING_MAST_LOG."Brand_code")AS "Brand",
                (SELECT "Uom_Name" FROM UOM_MAST WHERE "Uom_Code" =TBL_BOOKING_MAST_LOG."Uom_code")AS "UOM",
                (SELECT "premiumname" FROM ADVPOS_PREM_MAST  WHERE "Premiumcode" =TBL_BOOKING_MAST_LOG."Page_type_code")AS "PagePremium",
                (SELECT "Pos_Type" FROM ADVPOS_TYPE_MAST WHERE "Pos_Type_Code" = TBL_BOOKING_MAST_LOG."Page_position_code")AS "PositionPremium",
                (SELECT "Curr_Name" FROM CURR_MAST WHERE "Curr_Code" =TBL_BOOKING_MAST_LOG."Currency_code")AS "Currency"
           FROM TBL_BOOKING_MAST_LOG, AGENCY_MAST
             WHERE TBL_BOOKING_MAST_LOG."Receipt_no" = ciobookid
            AND VSEQNO = VERSION1
           AND AGENCY_MAST."code_subcode" =TBL_BOOKING_MAST_LOG."Agency_sub_code"
            AND AGENCY_MAST."Comp_Code" =TBL_BOOKING_MAST_LOG."Comp_code";



OPEN p_accounts4 FOR 

select  case dateformat
                     when 'mm/dd/yyyy' then to_char("date_time",'mm/dd/yyyy')
                     when 'dd/mm/yyyy'    then to_char("date_time",'dd/mm/yyyy')
                     when 'yyyy/mm/dd' then to_char("date_time",'yyyy/mm/dd')  end as "date_time",
                   "branch","booked_by", "cio_booking_id", "prev_booking", "applied_by","audit", "RO_No",
            case dateformat
                 when 'mm/dd/yyyy' then to_char("RO_Date",'mm/dd/yyyy')
                 when 'dd/mm/yyyy'    then to_char("RO_Date",'dd/mm/yyyy')
                 when 'yyyy/mm/dd' then to_char("RO_Date",'yyyy/mm/dd')   end as "RO_Date",
               "Caption","bill_status", "ro_status",
                TBL_BOOKING_MAST_LOG."Agency_code", "Agency_address",
                "Client_code", "Client_address", "Agency_sub_code",
                "Dockit_no", "Executive_code", "Executive_zone",
                "Product_code", "Brand_code", "Key_no", "Bill_remarks",
                "Print_remark", "Package_code", "No_of_insertion",
            case dateformat
                     when 'mm/dd/yyyy' then to_char("Insertion_date",'mm/dd/yyyy')
                  when 'dd/mm/yyyy'    then to_char("Insertion_date",'dd/mm/yyyy')
                     when 'yyyy/mm/dd' then to_char("Insertion_date",'yyyy/mm/dd')   end as "Insertion_date",
                "Repeating_day", "Ad_type_code", "Ad_cat_code",
                "Ad_sub_cat_code", "Color_code", "Uom_code",
                "Page_position_code", "Page_type_code", "Page_no",
                "Ad_size_type_code", "Ad_size_height", "Ad_size_width",
                "Rate_code", "Scheme_type_code", "Currency_code",
                "Agrred_rate", "Agreed_amount", "Special_discount",
                "Space_discount", "Special_charges",
                TBL_BOOKING_MAST_LOG."Comp_code",
                TBL_BOOKING_MAST_LOG."Userid",
                TBL_BOOKING_MAST_LOG."Agency_status", "Agency_type",
                "Agency_pay", "Agency_credit", "Total_area", "Card_rate",
                "Card_amount", "Discount", "Discount_per", "Bill_cycle",
                "Revenue_center", "Bill_pay", "Bill_height", "Bill_width",
                TBL_BOOKING_MAST_LOG."Bill_to","Invoices", "Vts",
                "Bill_add","Trade_disc","Agency_out",TBL_BOOKING_MAST_LOG."Booking_type",    
                "Tfn","Coupan_ad","Campaign","Bill_amount","Page_prem","Page_amount","Prem_per",
                "Gross_amount","Ad_size_column","Bill_column","Bill_area","Special_disc_per","Space_disc_per",
                 agency_mast."Agency_Name" || '('|| agency_mast."code_subcode"|| ')' as agencyname,
              --(SELECT    EXEC_MAST."Exec_name" , EXEC_MAST."Exe_no" FROM EXEC_MAST ) WHERE TBL_BOOKING_MAST_LOG."Executive_code" = EXEC_MAST."Exe_no" AND TBL_BOOKING_MAST_LOG."Comp_code" = EXEC_MAST."comp_code")AS execname,
                (SELECT    PRODUCT_CAT_MAST."prod_desc" || '(' || PRODUCT_CAT_MAST."prod_cat_code" || ')'
                   FROM PRODUCT_CAT_MAST WHERE TBL_BOOKING_MAST_LOG."Product_code" =PRODUCT_CAT_MAST."prod_cat_code"
                    AND TBL_BOOKING_MAST_LOG."Comp_code" =PRODUCT_CAT_MAST."comp_code")AS product,
                "Paid_ins","Contract_rate","Deviation","Variant_code","Contract_name","Contract_type",        
"Card_name","Card_type","Card_month","Card_year","Card_number",    "Receipt_no",            
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                "Bullet_code","Bullet_premium", 
                (select "Agency_Name" from agency_mast where "code_subcode" =tbl_booking_mast_log."Agency_sub_code")as agencysubcode,
               nvl((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code" = "Client_code"),'' ) AS "Client",
                (SELECT distinct "Payment_Mode_Name" FROM PAYMENT_MODE_MAST WHERE "Comp_Code"=TBL_BOOKING_MAST_LOG."Comp_code" and "Pay_Mode_Code" = "Agency_pay") AS "PayMode",
                (SELECT "Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code" =TBL_BOOKING_MAST_LOG."Ad_cat_code")AS categoryname,
                (SELECT "Adv_Subcat_Name" FROM ADV_SUBCAT_MAST WHERE ADV_SUBCAT_MAST."Adv_Subcat_Code" =TBL_BOOKING_MAST_LOG."Ad_sub_cat_code")AS subcategoryname,
                (SELECT "brand_name" FROM BRAND_MST WHERE "brand_code" =TBL_BOOKING_MAST_LOG."Brand_code")AS "Brand",
                (SELECT "Uom_Name" FROM UOM_MAST WHERE "Uom_Code" =TBL_BOOKING_MAST_LOG."Uom_code")AS "UOM",
                (SELECT "premiumname" FROM ADVPOS_PREM_MAST  WHERE "Premiumcode" =TBL_BOOKING_MAST_LOG."Page_type_code")AS "PagePremium",
                (SELECT "Pos_Type" FROM ADVPOS_TYPE_MAST WHERE "Pos_Type_Code" = TBL_BOOKING_MAST_LOG."Page_position_code")AS "PositionPremium",
                (SELECT "Curr_Name" FROM CURR_MAST WHERE "Curr_Code" =TBL_BOOKING_MAST_LOG."Currency_code")AS "Currency"
           from tbl_booking_mast_log, agency_mast
          where tbl_booking_mast_log."Receipt_no" = ciobookid
                           AND VSEQNO =(SELECT MAX (VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" =ciobookid AND VSEQNO <
            (SELECT MAX(VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" = ciobookid) AND "audit" IS NOT NULL)
                        AND AGENCY_MAST."code_subcode" = TBL_BOOKING_MAST_LOG."Agency_sub_code" 
AND AGENCY_MAST."Comp_Code" = TBL_BOOKING_MAST_LOG."Comp_code";

---OPEN p_accounts FOR query; 
END executebooking_new_quotation1;
/





------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE HT18JULY.savequotationinbookingtable1                                     
(
   premarks           in  varchar2,
   puserid            in  varchar2,
   pappstatus         in  varchar2,
   pinsertid          in  varchar2,
   pbookid1           in  varchar2,
   pcompcode          in  varchar2,
   pcenter            in  varchar2,
   pdateformate       in  varchar2,
   p_error         OUT    varchar2,--  cur_type_new1.cursor_type,
   p_new_cioid     OUT    varchar2--  cur_type_new1.cursor_type 
     
)
    as

  
    pv_ad_type varchar2(2000);


    Begin
    
    

       
      update tbl_booking_mast_Q set QUOTATIONFLAG=pappstatus, QUOTATIONREMARKS=premarks
      
        where cio_booking_id=pbookid1 and Comp_code=pcompcode;
        
        select  substr(ad_type_code,1,2) into pv_ad_type from tbl_booking_mast_Q 
        where cio_booking_id=pbookid1 and Comp_code=pcompcode ; 
       commit;

       if (pappstatus!='N') then
       
           committransaction(pbookid1, pinsertid,pcompcode,pcenter,puserid,pdateformate,pv_ad_type,'',p_error,p_new_cioid );
       end if;
       
       --open p_error for select sysdate from dual;
       --open p_new_cioid for select sysdate from dual;
       
       
       
       commit;
          
    End;
    /



---------------------------------------------------------------------------------


CREATE OR REPLACE PROCEDURE HT18JULY.getquotationapproval(

username       in     varchar2,
compcode       in     varchar2,
agency         in     varchar2,
executiv       in     varchar2,
client         in     varchar2,
retainer       in     varchar2,
varFromDate    in     date,
varToDate      in    date,
dateformat     in    varchar2,
flag	       in 	varchar2,
padtype        in	varchar2,
p_accounts   OUT      cur_type_new1.cursor_type
)
IS
 vquery      varchar(8000);
 v_varFromDate  date;
 v_varToDate    date;
 BEGIN
v_varFromDate:=to_date(varFromDate,''''||dateformat||'''');
 v_varToDate:=to_date(varToDate,''''||dateformat||'''');



    vquery:='SELECT (select "Agency_Name" from agency_mast where Comp_Code='''||compcode||''' and "code_subcode"=a."AGENCY_SUB_CODE") agency,
    (select "Cust_Name" from cust_mast where Comp_Code='''||compcode||''' and "Cust_Code"= Client_code) client,
    cio_booking_id as "TEMPID", (select count(*) from tbl_booking_insert_q where a.cio_booking_id=a.cio_booking_id) INSERTION,QUOTATIONFLAG
    from tbl_booking_mast_q a where Comp_code='''||compcode||''' and date_time between '''|| v_varFromDate||''' and '''|| v_varToDate||''' ';
    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------BHANU
    if (padtype <>'') then
         vquery := vquery||' and "Ad_type_code" = '''||Padtype||'''' ;
    end  if;    
   
       
    if (agency!='') then
        vquery := vquery|| ' and "AGENCY_SUB_CODE" = '''||agency||'''';
    end if;
   
  if (executiv!='' ) then
		 vquery := vquery || ' and Executive_code = '''|| executiv||'''';
	end if;
	
    if (client!='' )then
		 vquery := vquery || ' and Client_code = '''|| client||'''';
	end if;
	
    if (retainer!='' )then
		 vquery := vquery || ' and RETAINER = '''|| retainer||'''';
	end if;
	
    if (flag='A' or flag='N') then
         vquery:=vquery||' and QUOTATIONFLAG ='''||flag ||'''';
      
  
    else 
    
       vquery :=vquery || ' and "QUOTATIONFLAG"  is null ';
       end   if;
      OPEN p_accounts FOR vquery; 
          delete from test1;
    insert into test1 values('',vquery);
    commit;
       
    end;
/


---------------------------------------------------------------------------------------


//////////////////////////////////////////******************(end)**********************/////////////////////////////////////////



///////////////////////////////***************Laxman Sir (28/12/2012)*************************//////////////////////////////////////

                                                                     
                                                                     
                                                                     
                                             
CREATE OR REPLACE FUNCTION FETCH_PUBLISH_EDTNNAME_SIZE(
    pcomp_cd    varchar2,
    pbkid       varchar2,
    ppubdate    date,
    ppkgcode    varchar2,
    ppublcode   varchar2,
    pedtncode   varchar2,
    pinsert_no  number,
    phight      number,
    pwidth      number,
    pdateformat varchar2,
    pexrta1     varchar2,
    pexrta2     varchar2) RETURN VARCHAR2 as
    
v_edtn          varchar2(20);
v_edtn_alias    varchar2(200);
v_edtn_name     varchar2(2000);
    cursor c1 is
        select distinct "Edition_Code","Edition_Alias" from
        (select distinct a."Edition_Code",e."Edition_Alias" from tbl_booking_insert a,edition_mast e
        where a."Comp_Code"=e."Comp_Code" and a."Edition_Code"=e."Edition_Code" and a."Cio_Booking_Id"=pbkid and 
            a."Insert_Date"=ppubdate and package_code=nvl(ppkgcode,package_code) and a."Publication_Code"=nvl(ppublcode,a."Publication_Code") and 
            a."Edition_Code"=nvl(pedtncode,a."Edition_Code") and a."Insert_Status" not in('cancel','hold') 
            and a."No_Insert"=nvl(pinsert_no,a."No_Insert") and a."Height" =nvl(phight,a."Height")
            and a."Width"=nvl(pwidth,a."Width")
        union
        select distinct a."EDITION" as "Edition_Code",e."Edition_Alias" from tbl_booking_subedition a,edition_mast e
        where a."COMP_CODE"=e."Comp_Code" and a."EDITION"=e."Edition_Code" and a."CIOID"=pbkid and 
            a."INSERTDATE"=ppubdate and a."PUBLICATION"=ppublcode and 
            a."EDITION"=pedtncode and a."INSERTSTATUS" not in('cancel','hold')
            and a."NO_INSERT"=nvl(pinsert_no,a."NO_INSERT") and a.height =nvl(phight,a.height)
            and a.width=nvl(pwidth,a.width))order by "Edition_Alias"; 
BEGIN
    open c1;
    loop
        fetch c1 into v_edtn,v_edtn_alias;
        exit when c1%notfound;
    
        if v_edtn_name is null then
            v_edtn_name:=v_edtn_alias;
        else
            v_edtn_name:=v_edtn_name||','||v_edtn_alias;
        end if;    
        
    end loop;
    close c1;    

    return NVL(v_edtn_name,'?');
END FETCH_PUBLISH_EDTNNAME_SIZE;
/
CREATE OR REPLACE function fetch_insert_center_printrmrk(
    pcompcode       varchar2,
    pcioid          varchar2,
    ppub_cent_code  varchar2,
    pinsertion_no   int,
    ppubdate        date,
    pedtncode       varchar2,
    pextra1         varchar2,
    pextra2         varchar2) return varchar2

as
v_rmrk   varchar2(2000);

BEGIN

    select distinct max(i."Remarks")  into v_rmrk from tbl_booking_mast m,tbl_booking_insert i 
        where m."Comp_code"= i."Comp_Code" and i."Comp_Code"=pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
        i."Cio_Booking_Id"=pcioid and i."No_Insert" =nvl(pinsertion_no,i."No_Insert") and 
        i."Insert_Status"!='cancel' and i."Insert_Date"=ppubdate and i."Edition_Code"=nvl(pedtncode,i."Edition_Code");
    
    if v_rmrk is null then

        select distinct max(i."Remarks")  into v_rmrk from tbl_booking_mast m,tbl_booking_insert i 
            where m."Comp_code"= i."Comp_Code" and i."Comp_Code"=pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
                i."Cio_Booking_Id"=pcioid and i."No_Insert" =nvl(pinsertion_no,i."No_Insert") and 
                i."Insert_Status"!='cancel' and i."Insert_Date"=ppubdate and 
                i."Pub_Cent_Code"= nvl(ppub_cent_code,i."Pub_Cent_Code");
        
        if v_rmrk is null then
            select distinct max(i."Remarks")  into v_rmrk from tbl_booking_mast m,tbl_booking_insert i 
                where m."Comp_code"= i."Comp_Code" and i."Comp_Code"=pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
                    i."Cio_Booking_Id"=pcioid and i."No_Insert" =nvl(pinsertion_no,i."No_Insert") and 
                    i."Insert_Status"!='cancel' and i."Insert_Date"=ppubdate ;        
        
            if v_rmrk is null then
                select distinct max(i."Remarks")  into v_rmrk from tbl_booking_mast m,tbl_booking_insert i 
                    where m."Comp_code"= i."Comp_Code" and i."Comp_Code"=pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
                        i."Cio_Booking_Id"=pcioid and i."No_Insert" =nvl(pinsertion_no,i."No_Insert") and 
                        i."Insert_Status"!='cancel';
            /*else
                v_rmrk:=v_rmrk||' 3';*/
            end if;        
        /*else
            v_rmrk:=v_rmrk||' 2';*/
        end if;
    /*else
        v_rmrk:=v_rmrk||' 1';*/
    end if;


return v_rmrk;

END fetch_insert_center_printrmrk;
/


//////////////////////////////////////(End)/////////////////////////////////////////////////

////////////////////////////********(ANUJ Rajasthan Patrika(9/01/2013))***********************////////////////////////////////////////

                                                                     
                                                                     
                                                                     
                                             
CREATE OR REPLACE PROCEDURE rpt_unregistered_client (
   pcompcode      IN       VARCHAR2,
   pbranchcode    IN       VARCHAR2,
   pdatefrom      IN       VARCHAR2,
   pdateto        IN       VARCHAR2,
   pdateformate   IN       VARCHAR2,
   padtype        IN       VARCHAR2,
   puomcode       IN       VARCHAR2,
   pdate_flag     IN       VARCHAR2,--for on booking date B or Publish date P 
   pextra1        IN       VARCHAR2,--for multiple booking ids
   pextra2        IN       VARCHAR2,--Non Registered Client NRC
   pextra3        IN       VARCHAR2,
   pextra4        IN       VARCHAR2,
   pextra5        IN       VARCHAR2,    
   p_accounts     OUT      cur_type_new1.cursor_type)
IS
   v_frdt   DATE;
   v_todt   DATE;
   v_query  varchar2(8000);
   a    int;
BEGIN
    v_frdt := TO_DATE (pdatefrom, '''' || pdateformate || '''');
    v_todt := TO_DATE (pdateto, '''' || pdateformate || '''');
    
    v_query:='SELECT distinct a."date_time" as "BKDATE",a."Client_code" AS "CLIENTNAME", "Client_address" AS "CLIENT_ADDRESS",
        a."cio_booking_id" AS "CIOID", b."Agency_Name" as "AGENCY_NAME", c."Adv_Type_Name" as "ADV_TYPE_NAME",a."booked_by" as "BOOKED_BY",
        (select "Package_Name" from combin_mast where "Comp_Code"='''||pcompcode||''' and "Combin_Code"=(
        case when instr(''abcdef'','','') >0 then substr(a."Package_code",1,instr(a."Package_code",'','')-1)  
        else a."Package_code" end)) as "PACKAGE_NAME", e."Adv_Cat_Name" as "ADV_CAT_NAME", 
        a."Total_area" as "TOTAL_AREA", a."Rate_code" as "RATE_CODE",
        a."Card_rate" as "CARD_RATE", a."Bill_amount" as "BILL_AMOUNT", a."Gross_amount" as "GROSS_AMOUNT", 
        f."Uom_Name" as "UOM_NAME",g."Comp_Name" as "COMP_NAME"
    FROM tbl_booking_mast a,agency_mast b,adv_type_mast c,adv_cat_mast e,uom_mast f,comp_mst g,tbl_booking_insert i
    WHERE a."Comp_code" = g."Comp_Code" AND a."Comp_code" = i."Comp_Code" AND a."Comp_code" ='''||pcompcode||''' and 
        a."cio_booking_id" = i."Cio_Booking_Id"';
                
    If pdate_flag='B' then 
        v_query:=v_query||' AND a."date_time" BETWEEN '''||v_frdt||''' AND '''||v_todt||''' 
                    AND b."code_subcode" = a."Agency_sub_code" and 
                    not exists (SELECT ''x'' FROM cust_mast where "Cust_Code"=a."Client_code")
                    AND a."Ad_type_code" = c."Adv_Type_Code" AND a."Ad_type_code" =nvl('''||padtype||''',a."Ad_type_code") 
                    AND a."Uom_code" = f."Uom_Code" AND a."Uom_code" =nvl('''||puomcode||''',a."Uom_code")
                    AND a."Ad_cat_code" = e."Adv_Cat_Code"
                    AND a."branch" = nvl('''||pbranchcode||''',a."branch")';
    Else
        v_query:=v_query||' AND i."Insert_Date" BETWEEN '''||v_frdt||''' AND '''||v_todt||''' 
                    AND b."code_subcode" = a."Agency_sub_code" and 
                    not exists (SELECT ''x'' FROM cust_mast where "Cust_Code"=a."Client_code")
                    AND a."Ad_type_code" = c."Adv_Type_Code" AND a."Ad_type_code" =nvl('''||padtype||''',a."Ad_type_code") 
                    AND a."Uom_code" = f."Uom_Code" AND a."Uom_code" =nvl('''||puomcode||''',a."Uom_code")
                    AND a."Ad_cat_code" = e."Adv_Cat_Code"
                    AND a."branch" = nvl('''||pbranchcode||''',a."branch")';
    End if;     
    
    if pextra2='NRC' then--Non Registered Client
        v_query:=v_query||' and a.CLIENT_TYPE='''||pextra2||'''';
    elsif pextra2='URC' then--Un Registered Client
        v_query:=v_query||' and nvl(a.CLIENT_TYPE,''/'')<>''NRC''';
    else
        v_query:=v_query;        
    end if;
    
    if pextra1 is not null then
        --a:=Fn_Splitfield(pextra1,',');
        v_query:=v_query||' AND i."Cio_Booking_Id" in ('||pextra1||') order by CLIENTNAME,bkdate,cioid';
        --v_query:=v_query||' AND i."Cio_Booking_Id" in (select "EDITION_NAME" from result) order by bkdate,cioid';
    else
        v_query:=v_query||' order by CLIENTNAME,bkdate,cioid';
    end if;

    delete from test1;insert into test1(vstring,vstring2) values(' unregistered_client '||pextra1,v_query);commit;
     
    OPEN p_accounts FOR v_query;
    
END rpt_unregistered_client;
/
CREATE OR REPLACE procedure clientupdttrasac2(
    pciobookid  IN VARCHAR2,
    pclientcod  IN VARCHAR2,
    pcomp_cod   in varchar2
)
AS
    v_cl_addr   varchar2(200);
    v_cl_name   varchar2(200);
BEGIN

    Begin
        
        select distinct "Cust_Name",nvl("Add1",'') into v_cl_name,v_cl_addr from cust_mast where "Cust_Code"=pclientcod;
        
    Exception when others then
        v_cl_addr:=null;
    End;
    
    if v_cl_name is not null then
    
        update tbl_booking_mast set "Client_code"=pclientcod,"Client_address"=v_cl_addr ,client_type='RC'
            where "cio_booking_id"=pciobookid and "Comp_code"=pcomp_cod;
            
        update ad_bills set clientcd =  pclientcod, clientname =v_cl_name
            where comp_code_v=  pcomp_cod and idnum=pciobookid;
            
        update ad_bills_det set clientcd = pclientcod, clientname =v_cl_name
            where comp_code_v=  pcomp_cod and idnum=pciobookid;

        update ad_outstand set bank= pclientcod
            where comp_code = pcomp_cod and doctype='BILL' and receipt_no=pciobookid;
    
    else
    
        update tbl_booking_mast set "Client_code"=pclientcod 
            where "cio_booking_id"=pciobookid and "Comp_code"=pcomp_cod;
            
        update ad_bills set clientcd =  pclientcod, clientname =pclientcod
            where comp_code_v=  pcomp_cod and idnum=pciobookid;
            
        update ad_bills_det set clientcd = pclientcod, clientname =pclientcod
            where comp_code_v=  pcomp_cod and idnum=pciobookid;       

        update ad_outstand set bank= pclientcod
            where comp_code = pcomp_cod and doctype='BILL' and receipt_no=pciobookid;    
    
    end if;
    
END clientupdttrasac2;
/
CREATE OR REPLACE procedure ad_client_mark_nonregistered(
    pciobookid  IN VARCHAR2,
    pclientcod  IN VARCHAR2,
    pcomp_cod   in varchar2
)
AS
    v_cnt   number(5);
BEGIN

        
    select count(*) into v_cnt from cust_mast where "Comp_Code"=pcomp_cod and "Cust_Code"=pclientcod;
            
        
    if nvl(v_cnt,0)=0 then
        
        update tbl_booking_mast set CLIENT_TYPE='NRC' 
            where "cio_booking_id"=pciobookid and "Comp_code"=pcomp_cod;

    end if;
    
END ad_client_mark_nonregistered;
/






----------------------------


                                                                     
                                                                     
                                                                     
                                             
CREATE OR REPLACE FUNCTION RP4C.cir_get_userpermission(
    pcomp_code          in  varchar2,
    punit_code          in  varchar2,
    pagcd               in  varchar2,
    pdpcd               in  varchar2,
    pclbal              in  number,
    puserid             in  varchar2,
    pper_desc           in  varchar2,
    pextra1             in  varchar2,
    pextra2             in  varchar2,
    pextra3             in  varchar2,
    pextra4             in  varchar2,
    pextra5             in  varchar2,
    pextra6             in  varchar2,
    pextra7             in  varchar2,
    pextra8             in  varchar2,
    pextra9             in  varchar2,
    pextra10            in  varchar2) RETURN varchar2 IS
    
    v_flg           varchar2(1):='N';
    v_clbal         number(18,2);
    v_cnt           number(5);
    v_from_osbal    number(18,2);
    v_till_osbal    number(18,2);
    v_no_of_times   number(5);
    v_period_freq   varchar2(40); 
BEGIN
    If pper_desc='Allow Unblock Agency' then--check for unblock agency

        v_clbal:=cir_get_agency_opening(pcomp_code,punit_code,null,pagcd,pdpcd,to_date(sysdate,'dd/mon/yyyy')+1,'NM','dd/mm/yyyy',puserid,null,null);
        
        select count(*) into v_cnt from userpermission_detail where userid=puserid and permission_desc=pper_desc and allow_flag='Y';
        if nvl(v_cnt,0)>0 then
        
            select from_os_bal,till_os_bal,no_of_times,period_freq into v_from_osbal,v_till_osbal,v_no_of_times,v_period_freq 
                from userpermission_detail where userid=puserid and permission_desc=pper_desc and allow_flag='Y';
        
        if v_clbal between v_from_osbal and v_till_osbal then
            v_flg:='Y';
        else
            v_flg:='N';
        end if;
        else
            v_flg:='N';                        
        end if;
    Else
        select count(*) into v_cnt from userpermission where userid=puserid and permission_desc=pper_desc;
        if nvl(v_cnt,0)>0 then
            v_flg:='Y';
        else
            v_flg:='N';                        
        end if;
    End If;

  return nvl(v_flg,'N');
End cir_get_userpermission;
/





//////////////////////////////(End)//////////////////////////////////////////

/////////////////***********changes send by bhanu sir from rajasthan patrika*************/////////////////////////

                                             
CREATE OR REPLACE PROCEDURE agency_mrv_region_bind(
    pcompcode   IN  VARCHAR2,
    pdateformat IN  VARCHAR2,
    puserid     IN  VARCHAR2,
    pextra1     IN  VARCHAR2,
    pextra2     IN  VARCHAR2,
    pextra3     IN  VARCHAR2,
    pextra4     IN  VARCHAR2,
    pextra5     IN  VARCHAR2,
    p_accounts  OUT cur_type_new1.cursor_type)
IS
BEGIN
 
    OPEN p_accounts FOR
    select distinct "Zip" from agency_mast 
    where "Comp_Code" =pcompcode and "Zip" is not null
    order by "Zip";
 
END agency_mrv_region_bind;
/

----------------------


                                                                     
                                                                     
                                                                     
                                             
CREATE OR REPLACE PACKAGE HT18JULY.executecontract IS
Type T_Accounts_Cursor is Ref Cursor;
PROCEDURE executecontract_P(
compcode in varchar2,
userid in varchar2,--
DealNo in varchar2,--
dealname in varchar2,--
agencycode in varchar2,--
subagencycode in varchar2,--
representative in varchar2,
dealtype in varchar2,
quotion_p in varchar2,
clientname_p in varchar2,
P_Accounts  OUT  T_Accounts_Cursor
);
end executecontract;
/


CREATE OR REPLACE PACKAGE BODY HT18JULY.Executecontract
IS
  PROCEDURE executecontract_P(
  			compcode IN VARCHAR2,
			userid IN VARCHAR2,--
			DealNo IN VARCHAR2,--
			dealname IN VARCHAR2,--
			agencycode IN VARCHAR2,--
			subagencycode IN VARCHAR2,--
			Representative IN VARCHAR2,
			dealtype IN VARCHAR2,
            quotion_p in varchar2,
clientname_p in varchar2,
			P_Accounts  OUT  T_Accounts_Cursor)
	AS
	BEGIN
    if quotion_p='Y' then
		 OPEN P_Accounts FOR
		 SELECT  "Deal_No","Comp_code",(select "Agency_Name"||'('|| "Agency_Code" ||')' from agency_mast where "Agency_Code"="Agency_code" 
         and agency_mast."SUB_Agency_Code"=contract_mast."Sub_Agency_Code") as "Agency_code",
         "Sub_Agency_Code",nvl((select "Cust_Name"||'('||"Cust_Code"||')' from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code","Product_code",TO_CHAR("From_date",'mm/dd/yyyy') as "From_date",TO_CHAR("Till_date",'mm/dd/yyyy') as "Till_date","representative","Userid","Total_val","Total_volu","team_code","deal_type","deal_name","contract_id","Ad_type",REMARKS,(select "Exec_name"||'('||"Exe_no"||')' from exec_mast where "Exe_no"=EXECUTIVE) as EXECUTIVE, (select "Retain_Name"||'(' || "Retain_Code" || ')' from  retainermaster where "Retain_Code"=RETAINER) as RETAINER, TO_CHAR(CONTRACTDATE,'mm/dd/yyyy') as CONTRACTDATE,TO_CHAR(CLOSEDATE,'mm/dd/yyyy') as  CLOSEDATE, SERVICETAX, PAYMENTTYPE, CAPTION, B2B, CHKMULTIAD, SEQNO_ALLOW, SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON,ATTACHMENT,ad_get_fieldname ('Comp_Code',
                                    compcode,
                                    'Pub_cent_Code',
                                    CONTRACT_MAST.DEAL_FROM,
                                    'Pub_Cent_name',
                                    'pub_cent_mast',
                                    '',
                                    ''
                                   ) AS DEAL_FROM, DEAL_CENTER, TRANSLATION_CHARGES,
                                   RECEIPT_NO, RECEIPT_DATE, RO_STATUS, RO_NO,TO_CHAR(RO_DATE,'mm/dd/yyyy') AS RO_DATE, RCPT_CURRENCY
          FROM CONTRACT_MAST
		 WHERE ("Comp_code" = compcode OR compcode IS NULL)
		 AND (LOWER("Deal_No") LIKE LOWER(DealNo) || '%' OR LOWER(DealNo) IS NULL)
		 AND("deal_name"  LIKE dealname ||'%'OR dealname IS NULL)
		 AND("Agency_code" LIKE agencycode||'%'OR agencycode IS NULL)
		 AND("deal_type" LIKE dealtype||'%'OR dealtype IS NULL)
		 AND("Sub_Agency_Code" LIKE subagencycode||'%'OR subagencycode IS NULL)
		 AND("representative" LIKE Representative||'%'OR Representative IS NULL)
         AND("QUOTATION" = quotion_p)
         AND("Client_code" LIKE clientname_p ||'%'OR clientname_p IS NULL);
    else
        OPEN P_Accounts FOR
		 SELECT  "Deal_No","Comp_code",(select "Agency_Name"||'('|| "Agency_Code" ||')' from agency_mast where "Agency_Code"="Agency_code" 
         and agency_mast."SUB_Agency_Code"=contract_mast."Sub_Agency_Code") as "Agency_code",
         "Sub_Agency_Code",nvl((select "Cust_Name"||'('||"Cust_Code"||')' from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code","Product_code",TO_CHAR("From_date",'mm/dd/yyyy') as "From_date",TO_CHAR("Till_date",'mm/dd/yyyy') as "Till_date","representative","Userid","Total_val","Total_volu","team_code","deal_type","deal_name","contract_id","Ad_type",REMARKS,(select "Exec_name"||'('||"Exe_no"||')' from exec_mast where "Exe_no"=EXECUTIVE) as EXECUTIVE, (select "Retain_Name"||'(' || "Retain_Code" || ')' from  retainermaster where "Retain_Code"=RETAINER) as RETAINER, TO_CHAR(CONTRACTDATE,'mm/dd/yyyy') as CONTRACTDATE,TO_CHAR(CLOSEDATE,'mm/dd/yyyy') as  CLOSEDATE, SERVICETAX, PAYMENTTYPE, CAPTION, B2B, CHKMULTIAD, SEQNO_ALLOW, SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON,ATTACHMENT,ad_get_fieldname ('Comp_Code',
                                    compcode,
                                    'Pub_cent_Code',
                                    CONTRACT_MAST.DEAL_FROM,
                                    'Pub_Cent_name',
                                    'pub_cent_mast',
                                    '',
                                    ''
                                   ) AS DEAL_FROM, DEAL_CENTER, TRANSLATION_CHARGES,
                                   RECEIPT_NO, RECEIPT_DATE, RO_STATUS, RO_NO,TO_CHAR(RO_DATE,'mm/dd/yyyy') AS RO_DATE, RCPT_CURRENCY
          FROM CONTRACT_MAST
		 WHERE ("Comp_code" = compcode OR compcode IS NULL)
		 AND (LOWER("Deal_No") LIKE LOWER(DealNo) || '%' OR LOWER(DealNo) IS NULL)
		 AND("deal_name"  LIKE dealname ||'%'OR dealname IS NULL)
		 AND("Agency_code" LIKE agencycode||'%'OR agencycode IS NULL)
		 AND("deal_type" LIKE dealtype||'%'OR dealtype IS NULL)
		 AND("Sub_Agency_Code" LIKE subagencycode||'%'OR subagencycode IS NULL)
		 AND("representative" LIKE Representative||'%'OR Representative IS NULL)
         AND("QUOTATION" is null)
         AND("Client_code" LIKE clientname_p ||'%'OR clientname_p IS NULL);     
     end if;    
         --AND("QUOTATION" = quotion_p);
         
         

END executecontract_P;
END Executecontract;
/




//////////////////////////*******(end)*******//////////////////////