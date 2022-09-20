/////////////////////done by shipra////////////issue no8856/////////////////////////



ALTER TABLE pcmdummy1 ADD MRV_MEMBER_CODE VARCHAR2(20);





CREATE OR REPLACE PACKAGE HT18JULY.pcminsert is

procedure pcminsert_p
(

compcode in varchar,
centercode in varchar2,
centername in varchar2,
alias in varchar2,
add1 in varchar2,
street in varchar2,
city in varchar2,
dist in varchar2,
country in varchar2,
phone1 in varchar2,
phone2 in varchar2,
pin in varchar2,
state in varchar2,
fax in varchar2,
email in varchar2,
remarks in varchar2,
userid in varchar2,
region1 in varchar2,
zone in varchar2,
fax1 in varchar2,
boxaddress in varchar2,
printval in varchar2,
imgpath in varchar2,
cir_imgpath in varchar2,
pcompanyname in varchar2,
plogopath in varchar2,
pstate in varchar2,
pmrv in varchar2
);
end pcminsert;
/






//////////////////////////////////////



CREATE OR REPLACE PACKAGE BODY HT18JULY.pcminsert is
procedure pcminsert_p
(

compcode in varchar,
centercode in varchar2,
centername in varchar2,
alias in varchar2,
add1 in varchar2,
street in varchar2,
city in varchar2,
dist in varchar2,
country in varchar2,
phone1 in varchar2,
phone2 in varchar2,
pin in varchar2,
state in varchar2,
fax in varchar2,
email in varchar2,
remarks in varchar2,
userid in varchar2,
region1 in varchar2,
zone in varchar2,
fax1 in varchar2,
boxaddress in varchar2,
printval IN VARCHAR2,
imgpath in varchar2,
cir_imgpath in varchar2,
pcompanyname in varchar2,
plogopath in varchar2,
pstate in varchar2,
pmrv in varchar2
)as

distcode  varchar2(50);
 statecode  varchar2(50);
 countrycode  varchar2(50);
begin



--select "Dist_Code"  into distcode  from dist_mst where "Dist_Name"=dist;
--select "State_Code"  into statecode from state_mst  where "State_Name"=state;
--select "Country_Code" into countrycode from count_mst  where "Country_Name"=country;

insert into pub_cent_mast("Comp_Code","Pub_cent_Code","Pub_Cent_name","Pub_Cent_Alias","Add1",
"street","Country_Code","State_Code","Dist_Code","City_Code","zip","Phone1","Phone2","Fax",
"EmailID","Pub_Cent_Status","Status_date","Remarks","UserId","Creation_Datetime","Region_code",
"Zone_code","Fax1","BOXADDRESS","PRINT_CENT","FILE_PATH","CIR_FILE_PATH","CENTER_COMP_NAME","LOGO_FILE_PATH","STATE",MRV_MEMBER_CODE )



 values(compcode,centercode,centername, alias,add1,street,country, state, dist, city, pin,phone1,phone2, fax,email,'',sysdate,remarks,userid,sysdate,region1,zone,fax1,boxaddress,printval,imgpath,cir_imgpath,pcompanyname,plogopath,pstate,pmrv);


end  pcminsert_p;
end  pcminsert;
/




/////////////////////////////////////////////////////


CREATE OR REPLACE PACKAGE HT18JULY.pcmexe Is

Type T_Accounts_Cursor Is Ref Cursor;


Procedure pcmexe_P(
compcode in varchar2,
centcode in varchar2,
centname in varchar2,
alias in varchar2,
city in varchar2,
country in varchar2,
pcompname in varchar2,
pstate in varchar2,
pmrv in varchar2,
p_Accounts Out T_Accounts_Cursor );

End pcmexe;
/





///////////////////////////////////////



CREATE OR REPLACE PACKAGE BODY HT18JULY.Pcmexe IS

PROCEDURE pcmexe_P(
compcode IN VARCHAR2,
centcode IN VARCHAR2,
centname IN VARCHAR2,
alias IN VARCHAR2,
city IN VARCHAR2,
country IN VARCHAR2,
pcompname in varchar2,
pstate in varchar2,
pmrv in varchar2,
p_Accounts OUT T_Accounts_Cursor ) AS

BEGIN

DELETE FROM pcmdummy1; COMMIT;

--select "Comp_Code","Pub_cent_Code","Pub_Cent_name","Pub_Cent_Alias","Add1","street","Country_Code", "State_Code","Dist_Code","City_Code","zip","Phone1","Phone2","Fax","EmailID",(select "cent_status" from pcm_status where  "center_code" ="Pub_cent_Code"),sysdate,"Remarks","UserId",(select "TO_DATE" from pcm_status where "center_code"="Pub_cent_Code" ),(select "FROM_DATE" from pcm_status where "center_code"="Pub_cent_Code" ),"Creation_Datetime","Region_code" as "Region_code","Zone_code" as "Zone_code","Fax1" from pub_cent_mast
INSERT INTO pcmdummy1
SELECT "Comp_Code","Pub_cent_Code","Pub_Cent_name","Pub_Cent_Alias","Add1","street","Country_Code",
"State_Code","Dist_Code","City_Code","zip","Phone1","Phone2","Fax","EmailID","Pub_Cent_Status"
,SYSDATE,"Remarks","UserId",SYSDATE,SYSDATE,"Creation_Datetime","Region_code","Zone_code","Fax1","BOXADDRESS",PRINT_CENT,
(select "Region_Name" from region_mst where region_mst."Region_Code"=pub_cent_mast."Region_code") as "Region_Name",
(select "Zone_Name" from zone_mast where zone_mast."Zone_Code"= pub_cent_mast."Zone_code") as "Zone_Name",FILE_PATH,CIR_FILE_PATH,CENTER_COMP_NAME,LOGO_FILE_PATH,STATE,MRV_MEMBER_CODE
FROM pub_cent_mast
WHERE "Comp_Code"=compcode AND  ("Pub_cent_Code"=centcode OR centcode IS NULL)AND
 ("Pub_Cent_name" LIKE centname||'%' OR centname IS NULL)
AND  ("Pub_Cent_Alias" LIKE alias||'%' OR alias IS NULL)
AND  ("Country_Code"=country OR country IS NULL)
AND  ("City_Code"=city OR city IS NULL)
AND  ("CENTER_COMP_NAME" LIKE pcompname||'%' OR pcompname IS NULL)
AND  ("STATE"=pstate OR pstate IS NULL)
AND  ("CENTER_COMP_NAME" LIKE pcompname||'%' OR pcompname IS NULL)
AND  ("MRV_MEMBER_CODE"=pmrv OR pmrv IS NULL)


ORDER BY "Pub_cent_Code";


DECLARE
CURSOR pcm  IS
SELECT "Pub_cent_Code" FROM pcmdummy1 ORDER BY "Pub_cent_Code";
pcm1 VARCHAR2(100);

BEGIN

OPEN pcm;
LOOP
FETCH pcm INTO pcm1;
EXIT WHEN PCM%NOTFOUND;

UPDATE pcmdummy1 SET "Pub_Cent_Status"=(SELECT "Status_Name" FROM tblstatus WHERE "Status_Code"=(SELECT "cent_status" FROM pcm_status WHERE "center_code"=pcm1 AND sysdate between "FROM_DATE" and "TO_DATE" AND ROWNUM<=1))
 WHERE "Pub_cent_Code"=pcm1;

UPDATE pcmdummy1 SET "To_date"=(SELECT  "TO_DATE" FROM pcm_status WHERE "center_code"=pcm1 AND ROWNUM<=1) WHERE "Pub_cent_Code"=pcm1;

UPDATE pcmdummy1 SET "From_date"=(SELECT  "FROM_DATE" FROM pcm_status WHERE "center_code"=pcm1 AND ROWNUM<=1) WHERE "Pub_cent_Code"=pcm1;

END  LOOP;

CLOSE pcm;

END;

OPEN p_accounts FOR
SELECT  DISTINCT * FROM pcmdummy1  ORDER BY "Pub_cent_Code";




END pcmexe_P;

END Pcmexe;
/




//////////////////////////////////////////////



CREATE OR REPLACE PACKAGE HT18JULY.pcmupdate is
procedure pcmupdate_p
(
compcode  in varchar2,
centercode in  varchar2,
centername in varchar2,
alias in  varchar2,
add1 in varchar2,
street in varchar2,
city in varchar2,
dist in varchar2,
country in  varchar2,
phone1 in varchar2,
phone2 in varchar2,
pin in varchar2,
state in varchar2,
fax in varchar2,
email in varchar2,
remarks in    varchar2,
region1 in  varchar2,
zone in varchar2,
fax1 in varchar2,
boxadd in varchar2,
printval in varchar2,
imgpath in varchar2,
cir_imgpath in varchar2,
pcompanyname in varchar2,
plogopath    in varchar2,
pstate in varchar2,
pmrv in varchar2
);
end pcmupdate;
/








//////////////////////////////////////////////


CREATE OR REPLACE PACKAGE BODY HT18JULY.pcmupdate is
procedure pcmupdate_p
(
compcode  in varchar2,
centercode in  varchar2,
centername in varchar2,
alias in  varchar2,
add1 in varchar2,
street in varchar2,
city in varchar2,
dist in varchar2,
country in  varchar2,
phone1 in varchar2,
phone2 in varchar2,
pin in varchar2,
state in varchar2,
fax in varchar2,
email in varchar2,
remarks in    varchar2,
region1 in  varchar2,
zone in varchar2,
fax1 in varchar2,
boxadd in varchar2,
printval in varchar2,
imgpath in varchar2,
cir_imgpath in varchar2,
pcompanyname in varchar2,
plogopath    in varchar2,
pstate in varchar2,
pmrv in varchar2
)
as
begin

 update pub_cent_mast set "Pub_Cent_name"=centername , "Pub_Cent_Alias"=alias, "Add1"=add1, "street"=street, "Country_Code"=country, "State_Code"=state, "Dist_Code"=dist, "City_Code"=city, "zip"=pin, "Phone1"=phone1, "Phone2"=phone2,"Fax"=fax, "EmailID"=email,

 "Remarks"=remarks,"Region_code"=region1,"Zone_code"=zone,"Fax1"=fax1, "BOXADDRESS"=boxadd , PRINT_CENT=printval,FILE_PATH=imgpath,CIR_FILE_PATH=cir_imgpath,CENTER_COMP_NAME=pcompanyname,LOGO_FILE_PATH=plogopath,STATE=pstate,MRV_MEMBER_CODE =pmrv where "Comp_Code"=compcode  and   "Pub_cent_Code"=centercode;

 commit;


end pcmupdate_p;
end pcmupdate;
/
////////////////////////end by shipra/////////////////////////////////












/////////////stat by shipra/////////////////////////




CREATE OR REPLACE PACKAGE HT18JULY.Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/
////////////////////////////////////////////



CREATE OR REPLACE PACKAGE BODY HT18JULY.currbindpreferpgld
IS
   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
         SELECT "date_format", "autogenerated", "currency_code",
                "rate_gr_code", "solo", "breakup", "blackwhitecode",
                "rostatus", "File_name", "Tfn", "Insert_breakup", "prefix",
                "suffix", "financestatus", "voucherst", "Ad_category",
                "Ro_datetime", "Vat", "Booking_status", "Cio_id",
                "Receipt_no", "uom_code", "Bgcolor_publication",
                "chkfor_valid_pubdates", "Agency_ratecode", "audit",
                "book_insert_date", "agencycomm", "rate_audit", "bill_audit",
                "billtype", "Premium_type", "copy_booking",
                "RATE_COMPANY_AGENCY", "ADDITIONAL_AGENCY_COMM",
                "AGENCY_RETAINER_COMM", "SUBEDITIONRATE", cls_billtype,
                dis_billtype, "BILLING_FORMAT", "RATE_CHECK", "ALL_PACKAGE",
                dayrate, scheme_type, disp_clsbill, receipt_format,
                cash_receipt_bill, bill_orderwslast, floor_chk, rokeycheck,
                agencycomm_seq_com, credit_recipt, disp_cashbill,
                cla_cashbill, rate_audit_pref, barcoding_allowed,
                fmg_bill_dis, bill_disp_cashbill, bill_cla_cashbill,
                backdatereceipt, rowise_cashbooking, cutofftime,
                dockit_booking, approval, back_days, cash_discount,
                cash_discounttype, "Allowed_old_date", seprate_cashier,
                cir_many_time_posting, cir_backdays_posting,
                cir_max_return_allow, cir_return_limit_allow,
                cir_no_of_chqbounce, cir_days_chqbounce, cir_return_days,
                cir_sup_order_limit, disp_billing_criteria,
                clsd_billing_criteria, max_publishdays, billno_periodicity,
                specialdisc_trans_edit, sharing_trans,
                multipackage_sel_trans, scheme_minword, trade_splcharge,
                rate_authorization, f2_record, publishad_edit_rateaudit,
                bindrevenue_center, fa_ledger_allow, clearance_type_allow,
                repeat_day_type, premium_edit, bill_generation_prior,
                publication_ho, spldisc_allowprem, bill_scheme,
                allowed_pdc_days_receipt, ad_type_manul_bill,
                outstanding_amt_criteria AS ro_outstand, genrate_cir_agcd,
                disp_auditbkg, cir_dis_auto_posting, relauthreqon,
                cir_auto_approval_unsold, cir_auto_physical_unsold,
                cir_unsold_include_inct, cir_unsold_include_insfee,
                cir_unsold_on_received_dt, agency_unblock_approval,
                unblock_approval_outside_limit, cir_bill_publwise,
                records_on_page, records_on_print, header_on_page,
                agency_required, region_required, allow_follow_dt_boook,
                crm_supply_type_paid, crm_supply_type_free,
                currency_measurement, "Space_area", editable_agency_comm,
                cancellation_charge, taxi_entry_type, approval_with,
                tds_auto_cn, tds_auto_reason, tds_db_cdp, tds_cr_cdp,
                ser_tax_auto_cn, ser_tax_auto_reason, ser_tax_db_cdp,
                ser_tax_cr_cdp, pkk_auto_cn, pkk_auto_reason, pkk_db_cdp,
                pkk_cr_cdp, bank_chg_auto_cn, bank_chg_auto_reason,
                bank_chg_db_cdp, bank_chg_cr_cdp, cir_barcode,
                cir_wieght_calc_req, gen_rct_typ, product_brand_req, ALLOWPREM_CARD_DISC_RATE,FINANCE_CADE,EXECUTIVE_PUBLICATION_VISE,EXECUTIVECREDITLIMIT,MRV_BASED_ON ,
                CIR_POST_DIS,
    CIR_VAT_ALLOW,
    CIR_SUP_ALT_ROUTE,
    SHOW_REC_ALL_AGENCY,
    CIR_SUP_ORDER_DEC_LIMIT,
    CIR_ALLOW_HOLIDAY_SUN,
    CIR_ALLOW_HOLIDAY_MON,
    CIR_ALLOW_HOLIDAY_TUE,
    CIR_ALLOW_HOLIDAY_WED,
    CIR_ALLOW_HOLIDAY_THU,
    CIR_ALLOW_HOLIDAY_FRI,
    CIR_ALLOW_HOLIDAY_SAT,
    CRM_AUTOINFO,
    SAP_ID
           FROM preferrences
          WHERE "comp_code" = compcode;
   END currbindpreferpgld_p;
END currbindpreferpgld;
/
///////////////////////////////////////////





CREATE OR REPLACE PACKAGE HT18JULY.Wesp_Updatedate
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
p_mrv in varchar2
);
END      Wesp_Updatedate;
/
///////////////////////////////////////////











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
p_mrv in varchar2

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
SAP_ID=p_sapid,MRV_BASED_ON=p_mrv


  WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/
///////////////////////////////////////////////



//////////end by shipra////////////////////////////////////////////////










//////////start by shipra////////issue no 8855/////////////////





CREATE OR REPLACE PACKAGE HT18JULY.pubsave is
procedure pubsave_p(
comcode in varchar2,pubcode in varchar2,pubname in varchar2,pubalias in varchar2,langcode in  varchar2,priority  in varchar2,estdate in date,contperson in varchar2,phone in varchar2,fax in varchar2,emailid in varchar2,userid in varchar2,pubtype in varchar2,preocity in varchar2,phone2  in varchar2,fax2 in varchar2,gutter_space in varchar2,column_space in varchar2,hr in  varchar2,mint in  varchar2,prod in varchar2,
noofcol in varchar2,publish_code in varchar2,PREFIX IN VARCHAR2,mrv in varchar2
);
end pubsave;
/



//////////////////////////////////////////////////



CREATE OR REPLACE PACKAGE BODY HT18JULY.pubsave is

procedure pubsave_p(
comcode in varchar2,
pubcode in varchar2,
pubname in varchar2,
pubalias in varchar2,
langcode in  varchar2,
priority  in varchar2,
estdate in date,
contperson in varchar2,
phone in varchar2,
fax in varchar2,
emailid in varchar2,
userid in varchar2,
pubtype in varchar2,
preocity in varchar2,
phone2  in varchar2,
fax2 in varchar2,
gutter_space in varchar2,
column_space in varchar2,
hr in  varchar2,
mint in  varchar2,
prod in varchar2,
noofcol in varchar2,
publish_code in varchar2,
PREFIX IN VARCHAR2,
mrv in varchar2
)as
begin
insert into PUB_MAST("Comp_Code","Priority","Pub_Code","Pub_Name","pub_alias","Lang_Code","Establish_Date","Cont_Person","Phone","Fax","EmailID","UserId","Creation_Datetime","publication_type","preodicity","Phone1","Fax1","Gutter_Space","Column_Space","rotimehr","rotimemin","production","No_Of_collumn",PUBLISHER_CODE,PREFIX_PUB_NAME,MRV_MEMBER_CODE )
 values(comcode ,priority,pubcode,pubname,pubalias,langcode,estdate,contperson,phone,fax,emailid,userid, sysdate,pubtype,preocity,phone2,fax2,gutter_space,column_space,hr,mint,prod,noofcol,publish_code,PREFIX,mrv);

commit;
end  pubsave_p;
end pubsave;
/



//////////////////////////////////////////


CREATE OR REPLACE PACKAGE HT18JULY.pub_modify is
procedure pub_modify_p(
comcode in varchar2,pubcode in varchar2,pubname in varchar2,pubalias in
varchar2,langcode in varchar2,priority in varchar2,estdate in date,contperson in varchar2,
phone in varchar2,fax in varchar2,emailid in varchar2,pubtype in  varchar2,preocity in varchar2,
phone2 in varchar2,fax2 in varchar2,gutter_space  in varchar2,column_space  in varchar2,
hr in varchar2,mint in  varchar2,prod in varchar2,noofcol in varchar2,publishcode in varchar2,PREFIX IN VARCHAR2,mrv in varchar2);
end pub_modify;
/
/////////////////////////////////////////////////



CREATE OR REPLACE PACKAGE BODY HT18JULY.pub_modify is

procedure pub_modify_p(
comcode in varchar2,pubcode in varchar2,pubname in varchar2,pubalias in varchar2,langcode in varchar2,priority in varchar2,estdate in date,contperson in varchar2,phone in varchar2,fax in varchar2,emailid in varchar2,pubtype in  varchar2,preocity in varchar2,phone2 in varchar2,fax2 in varchar2,gutter_space  in varchar2,column_space  in varchar2,hr in varchar2,mint in  varchar2,prod in varchar2,noofcol in varchar2,publishcode in varchar2,PREFIX IN VARCHAR2,mrv in varchar2)as
begin
update PUB_MAST set "Pub_Name"=pubname, "pub_alias"=pubalias, "Lang_Code"=langcode, "Priority"=priority, "Establish_Date"=estdate, "Cont_Person"=contperson, "Phone"=phone, "Fax"=fax, "EmailID"=emailid,"publication_type"=pubtype,"preodicity"=preocity,"Phone1"=phone2,"Fax1"=fax2,"Gutter_Space"=gutter_space,"Column_Space"=column_space, "rotimehr"=hr, "rotimemin"=mint, "production"=prod ,"No_Of_collumn"=noofcol,PUBLISHER_CODE= publishcode,PREFIX_PUB_NAME=PREFIX,MRV_MEMBER_CODE =mrv where "Comp_Code"=comcode and "Pub_Code"=pubcode;


commit;
end  pub_modify_p;
end pub_modify;
/
///////////////////////////////////////////////////






CREATE OR REPLACE PACKAGE HT18JULY.pubexecute Is

Type T_Accounts_Cursor Is Ref Cursor;


Procedure pubexecute_P(
compcode in varchar2,
pubcode in varchar2,
pubname in varchar2,
pubalias in varchar2,
langcode in varchar2,
pubtype  in varchar2,
preocity  in varchar2,
p_Accounts Out T_Accounts_Cursor );

End pubexecute;
/
/////////////////////////////////////////////////



CREATE OR REPLACE PACKAGE BODY HT18JULY.pubexecute IS

Procedure pubexecute_P(
compcode in varchar2,
pubcode in varchar2,
pubname in varchar2,
pubalias in varchar2,
langcode in varchar2,
pubtype  in varchar2,
preocity  in varchar2,
p_Accounts Out T_Accounts_Cursor ) AS

BEGIN


Open P_Accounts For
 select "Pub_Code","Pub_Name","pub_alias","Lang_Code" as "Lang_Code","Priority","Cont_Person","publication_type" as "publication_type","Gutter_Space",
  "Column_Space","rotimehr" as "hr","rotimemin" as "mint","production", "No_Of_collumn"  as "No_Of_Collumn" ,"production" as "prod","Phone1","Fax1","preodicity","Establish_Date","Phone",
  "Fax","EmailID",PUBLISHER_CODE,PREFIX_PUB_NAME AS PREFIX,MRV_MEMBER_CODE from PUB_MAST


where ("Comp_Code"=compcode OR compcode IS NULL)
and  ("Pub_Code" like pubcode or pubcode is null)
and  ("Pub_Name" like pubname||'%' or pubname is null)
and  ("pub_alias" like pubalias||'%' or pubalias is null)
and  ("Lang_Code" like langcode or langcode is null)
and  ("preodicity" like preocity||'%' or preocity is null)
and  ("publication_type" like pubtype || '%' or pubtype is null)
;


END pubexecute_P;

END pubexecute;
/


/////////////////////////end by shipra/////////////////////////////////////////


./////////////////issune no 8444(anuj)05/oct/2012/////////////////////////////////

DROP PACKAGE HT18JULY.DATEINSERT;

CREATE OR REPLACE PACKAGE HT18JULY.dateinsert  is
procedure    dateinsert_p(
date1 in varchar2,
noissueday in varchar2,
issuecode in varchar2,
compcode in varchar2,
userid in varchar2);
end  dateinsert;
/



DROP PACKAGE BODY HT18JULY.DATEINSERT;

CREATE OR REPLACE PACKAGE BODY HT18JULY.Dateinsert  IS


PROCEDURE    dateinsert_p(
date1 IN VARCHAR2,
noissueday IN VARCHAR2,
issuecode IN VARCHAR2,
compcode IN VARCHAR2,
userid IN VARCHAR2) AS

count1 int;

BEGIN

select COUNT(*) into count1 from No_Iss_Grid where "No_Iss_Code"=issuecode and "no_issue_date"=date1;
if count1=0  then
INSERT INTO NO_ISS_GRID
 ("datecode",  "Comp_Code" ,   "No_Iss_Code",   "no_issue_date",  "No_Iss_day"  ,  "UserId")
VALUES (DATECODE.nextval,compcode,issuecode, date1,  noissueday,  userid );
COMMIT;
end if;
END dateinsert_p;
END Dateinsert;
/


///////////////////////////////////end//////////////////////////////


///////////////////*********issueno 9011(anuj) 16/oct/2012*****////////////////////////////////////////////////




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
            x.tue_rate_extra, x.wed_rate_extra,x.thu_rate_extra, x.fri_rate_extra,x.sat_rate_extra, x.maxwidth,x.priority, x.vat_detail, x.adon,x.ref_id, x.cancellation_charges,x.position_prem,
            x."ratemastid" "ratemastid", x."id" "id",x."rate_code" AS "rate_code" from
            (select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
            r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
            r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'mm/dd/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'mm/dd/yyyy') AS valid_to, 
            (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
            (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
            (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
            (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
            r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
            r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
            r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
            r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
            r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,r.position_prem,
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
            r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'mm/dd/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'mm/dd/yyyy') AS valid_to, 
            (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
            (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
            (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
            (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
            r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
            r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
            r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
            r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
            r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,r.position_prem,
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
            r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'mm/dd/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'mm/dd/yyyy') AS valid_to, 
            (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
            (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
            (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
            (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
            r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
            r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
            r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
            r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
            r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,r.position_prem,
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
      OPEN p_accounts FOR
        select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
            r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
            r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'mm/dd/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'mm/dd/yyyy') AS valid_to, 
            (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
            (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
            (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
            (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
            r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
            r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
            r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
            r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
            r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,r.position_prem,
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
   END IF;
/*open p_Accounts for

SELECT RATE_MAST."rateuniqueid", RATE_MAST."Comp_code", RATE_MAST."Rate_Mast_Code", RATE_MAST."Adv_Type_Code", RATE_MAST."Adv_Cat_Code", RATE_MAST."Adv_subcat_code", RATE_MAST."Rate_Gr_Code", RATE_MAST."Currency", RATE_MAST."combin_desc", RATE_MAST."Combin_Code", RATE_MAST."Uom", to_char(RATE_MAST."Valid_From",'mm/dd/yyyy') as Valid_From, to_char(RATE_MAST."Valid_To",'mm/dd/yyyy') as Valid_To, RATE_MAST."Size_To", RATE_MAST."Size_From", RATE_MAST."consumption_Per", RATE_MAST."Color", RATE_MAST."Col_chr_typ", RATE_MAST."Remarks", RATE_MAST."Week_Day_Rate", RATE_MAST."Week_min_rate", RATE_MAST."Week_Extra_Rate", RATE_MAST."Focus_Day_Rate", RATE_MAST."Focus_min_rate", RATE_MAST."Focus_extra_rate", RATE_MAST."userid", RATE_MAST."Creation_DateTime", RATE_MAST."Premium", RATE_MAST."Premium_Charges", RATE_MAST."weekend_rate", RATE_MAST."weekend_min_rate", RATE_MAST."weekend_extra", RATE_MAST."chksolo", RATE_MAST."min_ad_area", RATE_MAST."Edition_from", RATE_MAST."Edition_to", RATE_MAST."floor_amount", RATE_MAST."floor_discount", RATE_MAST."Scheme_Name", RATE_MAST."Ad_Subcat4", RATE_MAST."Ad_Subcat5", RATE_MAST."Ad_subcat6", RATE_MAST."From_insertion", RATE_MAST."To_insertion", RATE_MAST."Agency_type", RATE_MAST."Client_cat", RATE_MAST."Max_Area", RATE_MAST."pub_center", RATE_MAST.SUN_RATE, RATE_MAST.MON_RATE, RATE_MAST.TUE_RATE, RATE_MAST.WED_RATE, RATE_MAST.THU_RATE, RATE_MAST.FRI_RATE, RATE_MAST.SAT_RATE, RATE_MAST.SUN_RATE_EXTRA, RATE_MAST.MON_RATE_EXTRA, RATE_MAST.TUE_RATE_EXTRA, RATE_MAST.WED_RATE_EXTRA, RATE_MAST.THU_RATE_EXTRA, RATE_MAST.FRI_RATE_EXTRA, RATE_MAST.SAT_RATE_EXTRA, RATE_MAST.MAXWIDTH, RATE_MAST.PRIORITY,RATE_MAST.VAT_DETAIL,RATE_MAST.ADON,RATE_MAST.REF_ID,RATE_MAST.CANCELLATION_CHARGES
,RATE_DETAILS."ratemastid", RATE_DETAILS."id", RATE_DETAILS."rate_code", RATE_DETAILS."edition_name", RATE_DETAILS."Week_Day_Rate", RATE_DETAILS."Week_min_rate", RATE_DETAILS."Week_Extra_Rate", RATE_DETAILS."Focus_Day_Rate", RATE_DETAILS."Focus_min_rate", RATE_DETAILS."Focus_extra_rate", RATE_DETAILS."userid", RATE_DETAILS."Creation_DateTime", RATE_DETAILS."Comp_Code", RATE_DETAILS."Solus_week_rate", RATE_DETAILS."Solus_focus_rate", RATE_DETAILS."weekend_rate", RATE_DETAILS."weekend_min", RATE_DETAILS."weekend_extra", RATE_DETAILS."Solo_weekendrate", RATE_DETAILS.SUN_RATE, RATE_DETAILS.MON_RATE, RATE_DETAILS.TUE_RATE, RATE_DETAILS.WED_RATE, RATE_DETAILS.THU_RATE, RATE_DETAILS.FRI_RATE, RATE_DETAILS.SAT_RATE, RATE_DETAILS.SUN_RATE_EXTRA, RATE_DETAILS.MON_RATE_EXTRA, RATE_DETAILS.TUE_RATE_EXTRA, RATE_DETAILS.WED_RATE_EXTRA, RATE_DETAILS.THU_RATE_EXTRA, RATE_DETAILS.FRI_RATE_EXTRA, RATE_DETAILS.SAT_RATE_EXTRA, RATE_DETAILS.PKGNAME
 FROM RATE_MAST FULL JOIN RATE_DETAILS ON
 RATE_MAST."rateuniqueid"=RATE_DETAILS."ratemastid"
 WHERE "Adv_Type_Code"=adtype_p
 and "Valid_From">=fromdate_p AND "Valid_To"<=todate_p
   ORDER BY RATE_MAST."rateuniqueid";*/
END;
/















----------------------------------------------




CREATE OR REPLACE PROCEDURE binndratecode (
   p_compcode    IN       VARCHAR2,
   p_ratecode   IN       VARCHAR2,
   p_accounts    OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT distinct RATE_DESC as "Rate_Mast_Code"
        FROM RATE_CODE_MAST
       WHERE COMP_CODE = p_compcode
         AND RATE_DESC LIKE p_ratecode || '%' order by RATE_DESC;
        
END;
/








/////////////////////////////////////**********////////////////////////////


///////////////////*****************(ANUJ) issue 9011 18-oct-2012 *******//////////////////////


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
   END IF;
/*open p_Accounts for

SELECT RATE_MAST."rateuniqueid", RATE_MAST."Comp_code", RATE_MAST."Rate_Mast_Code", RATE_MAST."Adv_Type_Code", RATE_MAST."Adv_Cat_Code", RATE_MAST."Adv_subcat_code", RATE_MAST."Rate_Gr_Code", RATE_MAST."Currency", RATE_MAST."combin_desc", RATE_MAST."Combin_Code", RATE_MAST."Uom", to_char(RATE_MAST."Valid_From",'mm/dd/yyyy') as Valid_From, to_char(RATE_MAST."Valid_To",'mm/dd/yyyy') as Valid_To, RATE_MAST."Size_To", RATE_MAST."Size_From", RATE_MAST."consumption_Per", RATE_MAST."Color", RATE_MAST."Col_chr_typ", RATE_MAST."Remarks", RATE_MAST."Week_Day_Rate", RATE_MAST."Week_min_rate", RATE_MAST."Week_Extra_Rate", RATE_MAST."Focus_Day_Rate", RATE_MAST."Focus_min_rate", RATE_MAST."Focus_extra_rate", RATE_MAST."userid", RATE_MAST."Creation_DateTime", RATE_MAST."Premium", RATE_MAST."Premium_Charges", RATE_MAST."weekend_rate", RATE_MAST."weekend_min_rate", RATE_MAST."weekend_extra", RATE_MAST."chksolo", RATE_MAST."min_ad_area", RATE_MAST."Edition_from", RATE_MAST."Edition_to", RATE_MAST."floor_amount", RATE_MAST."floor_discount", RATE_MAST."Scheme_Name", RATE_MAST."Ad_Subcat4", RATE_MAST."Ad_Subcat5", RATE_MAST."Ad_subcat6", RATE_MAST."From_insertion", RATE_MAST."To_insertion", RATE_MAST."Agency_type", RATE_MAST."Client_cat", RATE_MAST."Max_Area", RATE_MAST."pub_center", RATE_MAST.SUN_RATE, RATE_MAST.MON_RATE, RATE_MAST.TUE_RATE, RATE_MAST.WED_RATE, RATE_MAST.THU_RATE, RATE_MAST.FRI_RATE, RATE_MAST.SAT_RATE, RATE_MAST.SUN_RATE_EXTRA, RATE_MAST.MON_RATE_EXTRA, RATE_MAST.TUE_RATE_EXTRA, RATE_MAST.WED_RATE_EXTRA, RATE_MAST.THU_RATE_EXTRA, RATE_MAST.FRI_RATE_EXTRA, RATE_MAST.SAT_RATE_EXTRA, RATE_MAST.MAXWIDTH, RATE_MAST.PRIORITY,RATE_MAST.VAT_DETAIL,RATE_MAST.ADON,RATE_MAST.REF_ID,RATE_MAST.CANCELLATION_CHARGES
,RATE_DETAILS."ratemastid", RATE_DETAILS."id", RATE_DETAILS."rate_code", RATE_DETAILS."edition_name", RATE_DETAILS."Week_Day_Rate", RATE_DETAILS."Week_min_rate", RATE_DETAILS."Week_Extra_Rate", RATE_DETAILS."Focus_Day_Rate", RATE_DETAILS."Focus_min_rate", RATE_DETAILS."Focus_extra_rate", RATE_DETAILS."userid", RATE_DETAILS."Creation_DateTime", RATE_DETAILS."Comp_Code", RATE_DETAILS."Solus_week_rate", RATE_DETAILS."Solus_focus_rate", RATE_DETAILS."weekend_rate", RATE_DETAILS."weekend_min", RATE_DETAILS."weekend_extra", RATE_DETAILS."Solo_weekendrate", RATE_DETAILS.SUN_RATE, RATE_DETAILS.MON_RATE, RATE_DETAILS.TUE_RATE, RATE_DETAILS.WED_RATE, RATE_DETAILS.THU_RATE, RATE_DETAILS.FRI_RATE, RATE_DETAILS.SAT_RATE, RATE_DETAILS.SUN_RATE_EXTRA, RATE_DETAILS.MON_RATE_EXTRA, RATE_DETAILS.TUE_RATE_EXTRA, RATE_DETAILS.WED_RATE_EXTRA, RATE_DETAILS.THU_RATE_EXTRA, RATE_DETAILS.FRI_RATE_EXTRA, RATE_DETAILS.SAT_RATE_EXTRA, RATE_DETAILS.PKGNAME
 FROM RATE_MAST FULL JOIN RATE_DETAILS ON
 RATE_MAST."rateuniqueid"=RATE_DETAILS."ratemastid"
 WHERE "Adv_Type_Code"=adtype_p
 and "Valid_From">=fromdate_p AND "Valid_To"<=todate_p
   ORDER BY RATE_MAST."rateuniqueid";*/
END;
/



////////////////////////////////////****************************************//////////////////////////////////






////////////////////////////*******************************ISSUE NO. 8893 ********************/////////////////////////////

CREATE OR REPLACE procedure schedulereport_checklist(
    fromdate        in varchar2,
    dateto          in varchar2,
    compcode        in varchar2,
    pub_name        in varchar2,
    pub_cent        in varchar2,
    dateformat      in varchar2,
    descid          in varchar2:=null,
    ascdesc         in varchar2:=null,
    adtyp           in varchar2,
    adcatg          in varchar2,
    padsubcat        in varchar,
    edition_name    in varchar2,
    drpstatus       in varchar2,
    supplement_name in varchar2,
    packagecode     in varchar2,
    editiondtl      in varchar2,
    puserid         in varchar2:=null,
    chk_access      in varchar2:=null,
    p_branch            in varchar2:=null,
    poth_branch_flag    in varchar2,--Y for
    p_uom           in varchar2,  
    p_accounts      OUT Cur_Type_New1.cursor_type,
    p_accounts1     OUT Cur_Type_New1.cursor_type,
    p_accounts2     OUT Cur_Type_New1.cursor_type,
    p_accounts3     out Cur_Type_New1.cursor_type,
    p_accounts4     out Cur_Type_New1.cursor_type) IS

query_upper         VARCHAR2(8000);
query1                  VARCHAR2(20000);
query_booked_by_others  VARCHAR2(20000);
query_group         VARCHAR2(8000);
query2              VARCHAR2(1000);
vwherecl            VARCHAR2(8000);    
query_not_pubdt     VARCHAR2(20000);
v_gau               number:=17;
v_val               number(4);
vs_gau              number(4);
v_billed            number(10);
v_booked_by_others  number(10);
v_direct_cash       number(10);
v_scheme_ads        number(10);
v_fmg_ads           number(10);
V_SCHEME_TYPE       varchar2(50);
V_FMG_BILL          varchar2(50);
BEGIN
    select BILL_SCHEME,FMG_BILL_DIS into V_SCHEME_TYPE,V_FMG_BILL from preferrences where "comp_code"=compcode;

    query_upper:='select distinct x.comp_code as "COMP_CODE",x.branch as "BRANCH",x.cioid as "CIOID",x.agency as "AGENCY",x.agency_city as "AGENCY_CITY",
    x.client  as "CLIENT",x.hue as "HUE",x.cardrate as "CARDRATE",x.agreedrate as "AGREEDRATE",x.special_disc_per as "SPECIAL_DISC_PER",
    x.caption as "CAPTION",x.key_no as "KEY_NO",x.RO_NO as "RO_NO",x.RATE_CODE as "RATE_CODE",
    x.pagepremium as "PAGEPREMIUM",x.pospremium as "POSPREMIUM",
    max(x.width)  as "WIDTH",max(x.depth) as "DEPTH",max(x.area) as "AREA",
    min(x.ins_date) as "INSERT_DATE" ,
    case '''||dateformat||'''
    when ''mm/dd/yyyy'' then to_char(min(x.ins_date),''MM-DD-YY'')
    when ''dd/mm/yyyy'' then to_char(min(x.ins_date),''DD-MM-YY'')
    when ''yyyy/mm/dd'' then to_char(min(x.ins_date),''YY-MM-DD'') end
    as "INS_DATE" ,
    x.adcat as "ADCAT",x.adsubcat as "ADSUBCAT",x.adsubcat3 as "ADSUBCAT3",
    min(x.pageno) as "PAGENO",x.ratecd as "RATECD",x.uom as "UOM",x.uomdesc as "UOMDESC",x.booktype as "booktype",x."AUDIT" as "AUDIT",
    x.app_status as "APP_STATUS",x.app_user as "APP_USER",x.no_insert as "NO_INSERT",x.branch_name as "BRANCH_NAME",
    x.package_name AS "PACKAGE_NAME",x.edition as "EDITION",
    x.trade_disc as "TRADE_DISC",
    case when nvl(x.edtn_wise_bill_req,''N'')=''Y'' then 
        (select round(sum(tbl_booking_insert."Bill_Amt")) from tbl_booking_insert
        where tbl_booking_insert."Cio_Booking_Id"=x."CIOID" and tbl_booking_insert."No_Insert"=x."NO_INSERT"
        and lower(tbl_booking_insert."Insert_Status") !=''cancel''and lower(tbl_booking_insert."Insert_Status") !=''hold''
        and "Edition"=x.edition)
    else
        (select sum(tbl_booking_insert."Bill_Amt") from tbl_booking_insert
        where tbl_booking_insert."Cio_Booking_Id"=x."CIOID" and tbl_booking_insert."No_Insert"=x."NO_INSERT"
        and lower(tbl_booking_insert."Insert_Status") !=''cancel''and lower(tbl_booking_insert."Insert_Status") !=''hold'')
    end as "BILL_AMT",
    x.bill_remarks as "BILL_REMARKS",x.bill_no as "BILL_NO",x.bill_date as "BILL_DATE",
       case '''||dateformat||'''
    when ''mm/dd/yyyy'' then to_char(x.bill_date,''MM-DD-YY'')
    when ''dd/mm/yyyy'' then to_char(x.bill_date,''DD-MM-YY'')
    when ''yyyy/mm/dd'' then to_char(x.bill_date,''YY-MM-DD'') end
    as "BILLDATE" ,
    x.edition_name as "EDITION_NAME",x.no_of_insertion as "NO_OF_INSERTION",x.Bill_cycle as "BILL_CYCLE",
    x.bkdate as bkdate,x.exec_code as exec_code,case when (x.exec_code=''0'' or x.exec_code is null) then null else (select "Exec_name"  from exec_mast where "Exe_no"=x.exec_code) end as "EXECUTIVE_NAME",
    x.RETAINER as retainer,case when (x.RETAINER=''0'' or x.RETAINER is null) then null else (select "Retain_Name" from retainermaster where "Retain_Code"=x.retainer)  end as "RETAINER_NAME", 
    x.translation_code as "TRANSLATION_CODE",(select distinct charge_name from ad_charge_mast where ad_charge_mast.charge_code=x.translation_code and 
    comp_code=x.comp_code and x.bkdate between valid_from_date and valid_till_date) as translation_name,
    x.posprem_disc posprem_disc,x.translation_disc translation_disc, x.page_prem as page_prem,x.page_prem_per as page_prem_per,
    x.disc_on_page_prem as disc_on_page_prem,x.booking_type as "BOOKING_TYPE",
    case '''||dateformat||'''
    when ''mm/dd/yyyy'' then to_char(min(x.pubdt),''MM-DD-YY'')
    when ''dd/mm/yyyy'' then to_char(min(x.pubdt),''DD-MM-YY'')
    when ''yyyy/mm/dd'' then to_char(min(x.pubdt),''YY-MM-DD'') end as "PUBDT"
    from(';
     
    query1:='select distinct m."Comp_code" comp_code,m."branch" branch, m."cio_booking_id" cioid,a."Agency_Name" agency,(select "City_Name" from city_mst where "City_Code"=a."City_Code") agency_city,
    nvl((select "Cust_Name" from cust_mast where "Cust_Code"=m."Client_code" and m."Comp_code"=cust_mast."Comp_Code" ),m."Client_code")  client,
    c."Col_Alias" hue,m."Card_rate" as cardrate,nvl(m."Agrred_rate",''0'') as agreedrate,
    case when nvl(m.DISC_PREMIUM,''0'')=''0'' then nvl(m."Special_disc_per",0) else 0 end as special_disc_per,
    m."Caption" caption,m."Key_no" as key_no,m."RO_No" as ro_no,m."Rate_code" RATE_CODE,
    (select advpos_prem_mast."premiumname" from advpos_prem_mast where advpos_prem_mast."Premiumcode"=i."Premium1" and advpos_prem_mast."comp_code"=m."Comp_code" ) pagepremium,
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=i."Page_Post" and advpos_type_mast."Comp_Code"=m."Comp_code" ) pospremium,
    round(i."Size_Book",2) area,
    i."Insert_Date" ins_date,i."Width" width,i."Height" depth,
    ac."Adv_Cat_Name" adcat,
    (select adv_subcat_mast."Adv_Subcat_Name" from adv_subcat_mast where  adv_subcat_mast."Adv_Subcat_Code"=i."Ad_Sub_Cat" and adv_subcat_mast."Comp_Code"=m."Comp_code" ) adsubcat,
    (select ad_cat3."catname" from ad_cat3 where ad_cat3."catcode"=m."Ad_Subcat3" and ad_cat3."compcode"=m."Comp_code" ) as adsubcat3,
    i."Page_No" pageno,m."Rate_code" ratecd,
    u."Uom_Name" uom,u."UOM_DESC" uomdesc,m."Booking_type" booktype,m."audit" "AUDIT",
    m.app_status app_status,m.app_user app_user,
    i."No_Insert" no_insert,b."Branch_Name" branch_name,
    fetch_insert_package(m."Comp_code",m."cio_booking_id",i."No_Insert",''N'') package_name,
    fetch_publish_edtnname(m."Comp_code",m."cio_booking_id",case when nvl(i."Insert_Date",to_date('''||fromdate||''',''dd/mm/yyyy''))=to_date('''||fromdate||''',''dd/mm/yyyy'') then nvl(i."Insert_Date",to_date('''||fromdate||''',''dd/mm/yyyy'')) else to_date('''||fromdate||''',''dd/mm/yyyy'') end,null,null,null,'''||dateformat||''',i."No_Insert",null) as edition,
    m."Trade_disc" as trade_disc,i."Bill_Amt" as bill_amt,m."Print_remark" bill_remarks,i.bill_no bill_no,i.bill_date bill_date,
    fetch_insert_center_edtn(m."Comp_code",m."cio_booking_id", '''||pub_cent||''',i."No_Insert") as edition_name,
    m."No_of_insertion" NO_OF_INSERTION,m."Bill_cycle" "BILL_CYCLE",m."date_time" as bkdate,m."Executive_code" as exec_code,
    m.RETAINER as retainer, m.translation_code as translation_code,m.posprem_disc posprem_disc,m.translation_disc translation_disc,
    m."Page_prem" as page_prem,m."Prem_per" as page_prem_per,
    case when nvl(m.disc_premium,''0'')=''0'' then 0 else m."Special_disc_per" end as disc_on_page_prem,m."Booking_type" booking_type,
    a.edtn_wise_bill_req edtn_wise_bill_req,
    case when nvl(i."Insert_Date",to_date('''||fromdate||''',''dd/mm/yyyy''))=to_date('''||fromdate||''',''dd/mm/yyyy'') then nvl(i."Insert_Date",to_date('''||fromdate||''',''dd/mm/yyyy'')) else to_date('''||fromdate||''',''dd/mm/yyyy'') end as pubdt,
    i.package_code as pack_code,
    i."Edition_Code" as edtn_code
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,col_mast c,uom_mast u,branch_mst b,adv_cat_mast ac
    where m."Comp_code"='''||compcode||''' and m."Comp_code"=i."Comp_Code" and ac."Comp_Code"=i."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
    i."Col_Code"=c."Col_Code" and b."Branch_Code"=m."branch" and ac."Adv_Cat_Code"=i."Ad_Cat"
    and lower(i."Insert_Status") not in(''cancel'',''hold'') and u."Uom_Code"=m."Uom_code"
    and not exists (select distinct ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
    and a.edtn_wise_bill_req=''N''';

IF(p_branch IS NOT NULL )THEN
    --query_booked_by_others  :=' union '||query1||' AND m."branch"<>'''||p_branch||'''';
    --query1                  :=query1||' AND m."branch"='''||p_branch||'''';

    query_booked_by_others  :=' union '||query1|| ' and exists(select distinct ''x'' from tbl_booking_mast a, tbl_booking_insert b 
    where a."Comp_code"=b."Comp_Code" and a."cio_booking_id"=b."Cio_Booking_Id" and 
    a."cio_booking_id"=m."cio_booking_id" and b."No_Insert"=i."No_Insert" and b."Insert_Date" between '''||fromdate||''' and '''||dateto||''' AND a."branch"=nvl('''||p_branch||''',a."branch"))';

END IF;

/*IF fromdate IS NOT NULL and dateto IS NOT NULL THEN 
    vwherecl:=vwherecl||'and ((i."Insert_Date" between '''||fromdate||''' and '''||dateto||''') or i."Insert_Date" is null) 
    and exists(select distinct ''x'' from tbl_booking_mast a, tbl_booking_insert b 
    where a."Comp_code"=b."Comp_Code" and a."cio_booking_id"=b."Cio_Booking_Id" and 
    a."cio_booking_id"=m."cio_booking_id" and b."No_Insert"=i."No_Insert" and b."Insert_Date" between '''||fromdate||''' and '''||dateto||''' AND a."branch"=nvl('''||p_branch||''',a."branch"))';
END iF;*/

IF fromdate IS NOT NULL and dateto IS NOT NULL THEN 
    --vwherecl:=vwherecl||' and i."Insert_Date" between '''||fromdate||''' and '''||dateto||'''';
    query1  :=query1||' and nvl(a.edtn_wise_bill_req,''N'')=''N'' and i."Insert_Date" between '''||fromdate||''' and '''||dateto||'''';

END iF;

IF(pub_name IS NOT NULL )THEN
    vwherecl:=vwherecl||' AND i."Publication_Code"='''||pub_name||'''';
END IF;


IF(adtyp IS NOT NULL) THEN
    vwherecl:=vwherecl|| ' AND m."Ad_type_code"='''||Adtyp||''' ';
END IF;

IF(p_uom IS NOT NULL) THEN
    vwherecl:=vwherecl|| ' AND m."Uom_code"='''||p_uom||''' ';
END IF;

IF(adcatg IS NOT NULL) THEN
    vwherecl:=vwherecl|| ' AND i."Ad_Cat" in ('''||adcatg||''' )';
END IF;


/*IF(padsubcat  IS NOT NULL) THEN
    vwherecl:=vwherecl|| ' AND i."Ad_Sub_Cat" in ('''||padsubcat ||''' )';
END IF;*/

IF(edition_name IS NOT NULL ) THEN
    vwherecl:=vwherecl||'  AND i."Edition_Code"='''||edition_name||'''';
END IF;

IF(supplement_name IS NOT NULL ) THEN
    vwherecl:=vwherecl||' AND (i."Supp_Code" ='''||supplement_name||''' )';
END IF;

IF(packagecode IS NOT NULL ) THEN
    vwherecl:=vwherecl||' AND ('''||packagecode||''' in (m."Package_code") )';
END IF;

IF(pub_cent IS NOT NULL) THEN
    query2:='  AND i."Pub_Cent_Code"='''||pub_cent||'''';
END IF;

query_group:=' )x group by x.comp_code,x.branch, x.cioid,x.agency,x.agency_city, x.client,x.hue,x.cardrate,x.agreedrate,x.special_disc_per,
x.caption,x.key_no ,x.RO_NO,x.RATE_CODE,x.pagepremium,x.pospremium,x.adcat,x.adsubcat ,x.adsubcat3 ,
x.ratecd ,x.uom,x.uomdesc,x.booktype,x."AUDIT",x.app_status ,x.app_user,x.no_insert,x.branch_name,
x.package_name,x.edition,x.trade_disc,x.bill_remarks,x.bill_no,x.bill_date,x.edition_name,x.no_of_insertion,x.Bill_cycle,
x.bkdate,x.exec_code,x.retainer, x.translation_code,x.posprem_disc,x.translation_disc, x.page_prem,x.page_prem_per,
x.disc_on_page_prem,x.booking_type,x.edtn_wise_bill_req,x.ins_date,x.pack_code,x.edtn_code';


query_group:=query_group||' order by edition_name,package_name, cioid,insert_date';


/*delete from searchtbl;
insert into searchtbl values('query_upper '||query_upper); commit;
insert into searchtbl values('query1 '||query1); commit;
insert into searchtbl values('vwherecl '||vwherecl); commit;
insert into searchtbl values('query2 '||query2); commit;
insert into searchtbl values('query_group '||query_group); commit;*/
--insert into searchtbl values('query_booked_by_others '||query_booked_by_others); commit;
--delete from test1;insert into test1(vstring,vstring2) values('schedule1 ',query1||vwherecl||query2);
--insert into test1(vstring,vstring2) values(' schedule2 ',query_booked_by_others||vwherecl||query2||query_group);

OPEN p_accounts FOR query_upper||query1||vwherecl||query2||query_booked_by_others||vwherecl||query2||query_group;
insert into searchtbl values('p_accounts '||query_upper); commit;
OPEN p_accounts1 FOR
select "Edition_Alias"  as "Editions"  from edition_mast where ("Pub_Code"=pub_name or pub_name is null)  and "Edition_Type"='Main Edition';
insert into searchtbl values('p_accounts1 '||query_upper); commit;
IF fromdate IS NOT NULL and dateto IS NOT NULL THEN 
    --vwherecl:=vwherecl||' and i."Insert_Date" between '''||fromdate||''' and '''||dateto||'''';
    query2  :=query2||'and i."Insert_Date" between '''||fromdate||''' and '''||dateto||'''';
END iF;
If nvl(poth_branch_flag,'N')='Y' and (pub_cent IS NOT NULL) then
    query2:=' AND m."branch"='''||p_branch||''' AND not exists (select ''x'' from tbl_booking_insert where "Cio_Booking_Id"=m."cio_booking_id" and "No_Insert"=i."No_Insert" and "Pub_Cent_Code"='''||pub_cent||''')';
else
    query2:=' AND 1=2 ';
End If;





OPEN p_accounts2 FOR query_upper||query1||vwherecl||query2||query_group;
--insert into searchtbl values('a p_accounts2 '||query_upper||query1||vwherecl||query2||query_group); commit;

    query1:='select distinct m."Comp_code" comp_code,m."branch" branch, m."cio_booking_id" cioid,a."Agency_Name" agency,(select "City_Name" from city_mst where "City_Code"=a."City_Code") agency_city,
    nvl((select "Cust_Name" from cust_mast where "Cust_Code"=m."Client_code" and m."Comp_code"=cust_mast."Comp_Code" ),m."Client_code")  client,
    c."Col_Alias" hue,m."Card_rate" as cardrate,nvl(m."Agrred_rate",''0'') as agreedrate,
    case when nvl(m.DISC_PREMIUM,''0'')=''0'' then nvl(m."Special_disc_per",0) else 0 end as special_disc_per,
    m."Caption" caption,m."Key_no" as key_no,m."RO_No" as ro_no,m."Rate_code" RATE_CODE,
    (select advpos_prem_mast."premiumname" from advpos_prem_mast where advpos_prem_mast."Premiumcode"=i."Premium1" and advpos_prem_mast."comp_code"=m."Comp_code" ) pagepremium,
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=i."Page_Post" and advpos_type_mast."Comp_Code"=m."Comp_code" ) pospremium,
    round(i."Size_Book",2) area,
    i."Insert_Date" ins_date,i."Width" width,i."Height" depth,
    ac."Adv_Cat_Name" adcat,
    (select adv_subcat_mast."Adv_Subcat_Name" from adv_subcat_mast where  adv_subcat_mast."Adv_Subcat_Code"=i."Ad_Sub_Cat" and adv_subcat_mast."Comp_Code"=m."Comp_code" ) adsubcat,
    (select ad_cat3."catname" from ad_cat3 where ad_cat3."catcode"=m."Ad_Subcat3" and ad_cat3."compcode"=m."Comp_code" ) as adsubcat3,
    i."Page_No" pageno,m."Rate_code" ratecd,
    u."Uom_Name" uom,u."UOM_DESC" uomdesc,m."Booking_type" booktype,m."audit" "AUDIT",
    m.app_status app_status,m.app_user app_user,
    i."No_Insert" no_insert,b."Branch_Name" branch_name,
    fetch_insert_package(m."Comp_code",m."cio_booking_id",i."No_Insert",''N'') package_name,
    fetch_publish_edtnname(m."Comp_code",m."cio_booking_id",case when nvl(i."Insert_Date",to_date('''||fromdate||''',''dd/mm/yyyy''))=to_date('''||fromdate||''',''dd/mm/yyyy'') then nvl(i."Insert_Date",to_date('''||fromdate||''',''dd/mm/yyyy'')) else to_date('''||fromdate||''',''dd/mm/yyyy'') end,i.package_code,'''||pub_name||''',i."Edition_Code",'''||dateformat||''',i."No_Insert",null) as edition,
    m."Trade_disc" as trade_disc,i."Bill_Amt" as bill_amt,m."Print_remark" bill_remarks,i.bill_no bill_no,i.bill_date bill_date,
    fetch_insert_center_edtn(m."Comp_code",m."cio_booking_id", '''||pub_cent||''',i."No_Insert") as edition_name,
    m."No_of_insertion" NO_OF_INSERTION,m."Bill_cycle" "BILL_CYCLE",m."date_time" as bkdate,m."Executive_code" as exec_code,
    m.RETAINER as retainer, m.translation_code as translation_code,m.posprem_disc posprem_disc,m.translation_disc translation_disc,
    m."Page_prem" as page_prem,m."Prem_per" as page_prem_per,
    case when nvl(m.disc_premium,''0'')=''0'' then 0 else m."Special_disc_per" end as disc_on_page_prem,m."Booking_type" booking_type,
    a.edtn_wise_bill_req edtn_wise_bill_req,
    i."Insert_Date"as pubdt ,
    i.package_code as pack_code,
    i."Edition_Code" as edtn_code
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,col_mast c,uom_mast u,branch_mst b,adv_cat_mast ac
    where m."Comp_code"='''||compcode||''' and m."Comp_code"=i."Comp_Code" and ac."Comp_Code"=i."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
    i."Col_Code"=c."Col_Code" and b."Branch_Code"=m."branch" and ac."Adv_Cat_Code"=i."Ad_Cat"
    and lower(i."Insert_Status") not in(''cancel'',''hold'') and u."Uom_Code"=m."Uom_code"
    and not exists (select distinct ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
    and i."Insert_Date" between '''||fromdate||''' and '''||dateto||'''  and m."branch"='''||p_branch||''' and 
    a.edtn_wise_bill_req=''Y''';
    
--delete from searchtbl;
--insert into searchtbl values(query1); commit;
--insert into searchtbl values(query2||query_group); commit;
insert into test1 values('1','b p_accounts2 '||query_upper); commit;
insert into test1 values('2','b p_accounts2 '||query1); commit;
insert into test1 values('3','b p_accounts2 '||vwherecl); commit;
insert into test1 values('4','b p_accounts2 '||query_group); commit;

OPEN p_accounts3 FOR query_upper||query1||vwherecl||query_group;
insert into searchtbl values('p_accounts3 '||query_upper); commit;
select count(distinct i."Cio_Booking_Id"||i."No_Insert") into v_booked_by_others from tbl_booking_mast m,tbl_booking_insert i
    where m."Comp_code"=compcode and m."cio_booking_id"=i."Cio_Booking_Id" and
    not exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "Branch_Code"=nvl(p_branch,"Branch_Code") and "pub_center"=pub_cent) and
    m."Ad_type_code"=nvl(adtyp,m."Ad_type_code") AND i."Insert_Date" BETWEEN fromdate AND dateto       
    and not exists(select 'x' from tbl_booking_mast where m."Comp_code"=compcode and "prev_cioid" is not null and "prev_cioid"=m."cio_booking_id")
    AND i."Pub_Cent_Code"=nvl(pub_cent,i."Pub_Cent_Code") AND m."Uom_code"=nvl(p_uom,m."Uom_code")
    and lower(i."Insert_Status") not in('cancel' ,'hold');

select sum(x.direct_cash_ads) into v_direct_cash from
    (select count(distinct i."Cio_Booking_Id"||i."No_Insert") as direct_cash_ads from tbl_booking_mast m,tbl_booking_insert i
    where m."Comp_code"=compcode and m."cio_booking_id"=i."Cio_Booking_Id" and
    exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "Branch_Code"=nvl(p_branch,"Branch_Code")) and
    m."Ad_type_code"=nvl(adtyp,m."Ad_type_code") AND i."Insert_Date" BETWEEN fromdate AND  dateto and i.bill_no is null
    AND m."Uom_code"=nvl(p_uom,m."Uom_code") and exists (select 'x' from AD_DIRECT_CLIENT_AGENCY where m."Agency_sub_code"=ag_main_code||ag_sub_code and flag_type='D')
    AND m."Bill_pay"='CA0'
    and lower(i."Insert_Status") not in('cancel' ,'hold'))x; 

if V_FMG_BILL ='Exclude' then
    select sum(x.fmg_ads) into v_fmg_ads from
        (select count(distinct i."Cio_Booking_Id"||i."No_Insert") as fmg_ads from tbl_booking_mast m,tbl_booking_insert i
        where m."Comp_code"=compcode and m."cio_booking_id"=i."Cio_Booking_Id" and
        exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "Branch_Code"=nvl(p_branch,"Branch_Code")) and
        m."Ad_type_code"=nvl(adtyp,m."Ad_type_code") AND i."Insert_Date" BETWEEN fromdate AND  dateto and i.bill_no is null
        AND m."Uom_code"=nvl(p_uom,m."Uom_code") AND m."Booking_type" in ('2','4','5','6')
        and lower(i."Insert_Status") not in('cancel' ,'hold') )x;
end if;
    
if V_SCHEME_TYPE='EXCLUDE'  or V_SCHEME_TYPE='EXCULDE' then
    select sum(x.scheme_ads) into v_scheme_ads from
        (select count(distinct i."Cio_Booking_Id"||i."No_Insert") as scheme_ads from tbl_booking_mast m,tbl_booking_insert i
        where m."Comp_code"=compcode and m."cio_booking_id"=i."Cio_Booking_Id" and
        exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "Branch_Code"=nvl(p_branch,"Branch_Code")) and
        m."Ad_type_code"=nvl(adtyp,m."Ad_type_code") AND i."Insert_Date" BETWEEN fromdate AND  dateto and i.bill_no is null
        AND m."Uom_code"=nvl(p_uom,m."Uom_code") AND i."Pai_Free_Ins"  ='N' AND m."Booking_type" not in ('2','4','5','6','7')
        and lower(i."Insert_Status") not in('cancel' ,'hold') and not exists (select 'x' from AD_DIRECT_CLIENT_AGENCY where m."Agency_sub_code"=ag_main_code||ag_sub_code 
        and flag_type='D')
        AND m."cio_booking_id" not in(select distinct "Cio_Booking_Id" from tbl_booking_mast m,tbl_booking_insert i
where m."cio_booking_id"=i."Cio_Booking_Id" and "Insert_Date"<'1-jun-2012' and m."Uom_code"='RO0') )x;
end if;        
    
OPEN  p_accounts4 FOR
SELECT SYSDATE,initcap("Comp_Name") as "COMP_NAME" ,nvl(v_billed,0) as "ALREADY_BILLED", nvl(v_booked_by_others,0) as "BOOKED_BY_OTHERS",
nvl(v_direct_cash,0) as "DIRECT_CASH",(nvl(v_fmg_ads,0)+nvl(v_scheme_ads,0)) as "SCHEME_ADS"
from comp_mst where "Comp_Code"=compcode;

DELETE FROM MULTIPAGE_BREAK where sess_id=userenv('sessionid')  ;commit;

end schedulereport_checklist;
/



////////////////////////////*******************************ISSUE NO. 8893 ********************/////////////////////////////


///////////////////////////////////////////booking audit procedure date 30 oct 2012////////by rahul/////////////////////////



CREATE OR REPLACE PACKAGE HT18JULY.Bindaudit IS
TYPE T_ACCOUNT_CURSOR IS REF CURSOR;

PROCEDURE bindaudit_p(
fromdate        IN VARCHAR2,
todate          IN VARCHAR2,
date1           IN VARCHAR2,
BRANCH1         IN VARCHAR2,
Adtype          IN VARCHAR2,
audittype       IN VARCHAR2,
branch2         IN VARCHAR2,
v_Cat           in varchar2,
v_userid        in varchar2,
comp_code       in varchar2,
v_package_code  in varchar2,
pagency_code    in varchar2,
pclient_code    in varchar2,
psection_code   in varchar2,
p_booktype      in varchar2,
extra1          in varchar2,
extra2          in varchar2,
extra3          in varchar2,
extra4          in varchar2,
P_ACCOUNT       OUT T_ACCOUNT_CURSOR);
END Bindaudit;
/





CREATE OR REPLACE PACKAGE BODY HT18JULY.bindaudit IS
PROCEDURE bindaudit_p(
    fromdate        IN VARCHAR2,
    todate          IN VARCHAR2,
    date1           IN VARCHAR2,
    BRANCH1         IN VARCHAR2,
    Adtype          IN VARCHAR2,
    audittype       IN VARCHAR2,
    branch2         IN VARCHAR2,
    v_Cat           in varchar2,
    v_userid        in varchar2,
    comp_code       in varchar2,
    v_package_code  in varchar2,
    pagency_code    in varchar2,
    pclient_code    in varchar2,
    psection_code   in varchar2,
    p_booktype      in varchar2,--A for all ,D for Direct ,Q for Qbc Booking
    extra1          in varchar2,--for UOM
    extra2          in varchar2,--for Date based on ,B for Booking Date,P for Publish date
    extra3          in varchar2,
    extra4          in varchar2,
    P_ACCOUNT       OUT T_ACCOUNT_CURSOR)
AS

v_branch1       varchar2(50);
v_branch2       varchar2(50);
v_approval_req  varchar2(1);
v_query         varchar2(20000);
v_wherecl       varchar2(5000);
v_query_group   varchar2(5000);
BEGIN
     --INSERT INTO test1(vstring)VALUES (   'fromdate '|| fromdate|| ' todate '|| todate|| ' date1 '|| date1|| ' BRANCH1 '|| branch1|| ' Adtype '|| adtype|| ' audittype '|| audittype|| ' branch2 '|| branch2|| ' v_Cat '|| v_cat|| ' v_userid '|| v_userid);COMMIT;
    If branch1 = 'All' then
        v_branch1 := null;
    Else
        v_branch1 := branch1;
    End if;
    
    If branch2 = 'All' then
        v_branch2 := null;
    Else
        v_branch2 := branch2;    
    End if;
    v_approval_req:='N';
    
    select relauthreqon into v_approval_req from preferrences where "comp_code"=comp_code;
    
    v_query:='SELECT distinct m."cio_booking_id" as "cio_booking_id",
        NVL ((SELECT distinct  "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),
        m."Client_code") AS "Client_code",
        m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",m."Receipt_no" as "Receipt_no",
        (SELECT distinct "File_Name" FROM tbl_booking_insert
        WHERE "Cio_Booking_Id" =m."cio_booking_id" AND "File_Name" IS NOT NULL AND ROWNUM <= 1) AS "FILENAME",
        CASE '''||date1||''' WHEN ''mm/dd/yyyy'' THEN TO_CHAR(m."Creation_datetime",''mm/dd/yyyy'')
            WHEN ''dd/mm/yyyy'' THEN TO_CHAR (m."Creation_datetime", ''dd/mm/yyyy'')
            WHEN ''yyyy/mm/dd'' THEN TO_CHAR (m."Creation_datetime", ''yyyy/mm/dd'')
        END AS "Creation_datetime",m.ATTACHMENT1 as ATTACHMENT,
        AD_GETAGENCY_ADD('''||comp_code||''',m."cio_booking_id",''A'') as "Agency_Remark",
        AD_GETAGENCY_ADD('''||comp_code||''',m."cio_booking_id",''C'') as "Client_Remark",
        case when '''||v_approval_req||'''=''N'' then ''Y'' else 
        case when nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)=0 then ''Y'' else nvl(m.app_status,''N'') end 
        end as "APPROVAL_FLAG",TO_CHAR(min(i."Insert_Date"),'''||date1||''') as "INSERT_DATE",min(i."Insert_Date") dd
        FROM tbl_booking_mast m,tbl_booking_insert i,branch_mst b,login_branch_mast lb
        WHERE m."cio_booking_id" =i."Cio_Booking_Id" AND m."Ad_type_code" = '''||adtype||'''
        AND m."branch"= b."Branch_Code" and m."branch"= lb.branch_code AND NVL (lb.user_flag, ''N'') = ''Y''';
        
        If pagency_code is not null then
            v_wherecl:=v_wherecl||' and m."Agency_sub_code"= '''||pagency_code||'''';
        end if;

        If v_branch2 is not null then
            v_wherecl:=v_wherecl||' and m."branch"= '''||v_branch2||'''';
        end if;

        If pclient_code is not null then
            v_wherecl:=v_wherecl||' and m."Client_code"= '''||pclient_code||'''';
        end if;                

        If pclient_code is not null then
            v_wherecl:=v_wherecl||' and m."Client_code"= '''||pclient_code||'''';
        end if;
        
        IF audittype = 'audit' or (audittype = 'unaudit' or audittype is null) THEN
        
            if extra2='P' then
                v_wherecl:=v_wherecl||' and i."Insert_Date" BETWEEN '''||fromdate||''' AND '''||todate||'''';
            else
                v_wherecl:=v_wherecl||' and m."date_time" BETWEEN '''||fromdate||''' AND '''||todate||'''';
            end if;
            
        End IF;
        
        If v_cat is not null then
            v_wherecl:=v_wherecl||' and m."Ad_cat_code"= '''||v_cat||'''';
        end if;

        If v_userid is not null then
            v_wherecl:=v_wherecl||' and lb.user_code= '''||v_userid||'''';
        end if;                
        
        If v_branch1 is not null then
            v_wherecl:=v_wherecl||' and b."pub_center"= '''||v_branch1||'''';
        end if;

        If v_package_code is not null then
            v_wherecl:=v_wherecl||' and i."PACKAGE_CODE"= '''||v_package_code||'''';
        end if;        
        
        If psection_code is not null then
            v_wherecl:=v_wherecl||' and i."SECTIONCODE"= '''||psection_code||'''';
        end if;
        
        If extra1 is not null then
            v_wherecl:=v_wherecl||' and m."Uom_code"= '''||extra1||'''';
        end if;

        If p_booktype is not null then
            v_wherecl:=v_wherecl||' and exists (select "userid" from login where "userid"=m."Userid" and
                                    ((nvl("Agency_code",''0'')<>''0'' and nvl('''||p_booktype||''',''A'') =''Q'') or
                   (nvl("Agency_code",''0'')=''0'' and nvl('''||p_booktype||''',''A'') =''D'') or nvl('''||p_booktype||''',''A'') =''A''))';
        end if;        
    
        IF audittype = 'audit' THEN

            v_wherecl:=v_wherecl||' AND m."audit" IS NOT NULL';
            
        END IF;

        IF audittype = 'unaudit' or audittype is null THEN
            v_wherecl:=v_wherecl||' AND m."audit" IS NULL AND m."ro_status"=''1'' and nvl(m.modified_audit,''N'')!=''Y''';
        End IF;

        IF audittype = 'modified' THEN
            v_wherecl:=v_wherecl||' AND m."audit" IS NULL AND m."ro_status"=''1'' and nvl(m.modified_audit,''N'')=''Y''';
        END IF;
    
    /*IF audittype = 'unaudit' or audittype is null THEN
        OPEN p_account FOR
            SELECT distinct m."cio_booking_id" as "cio_booking_id",
            NVL ((SELECT distinct "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),
            m."Client_code") AS "Client_code",
            m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",m."Receipt_no" as "Receipt_no",
            (SELECT distinct  "File_Name" FROM tbl_booking_insert
            WHERE "Cio_Booking_Id" =m."cio_booking_id"
            AND "File_Name" IS NOT NULL
            AND ROWNUM <= 1) AS "FILENAME",
            CASE date1 WHEN 'mm/dd/yyyy' THEN TO_CHAR(m."Creation_datetime",'mm/dd/yyyy')
                WHEN 'dd/mm/yyyy' THEN TO_CHAR (m."Creation_datetime", 'dd/mm/yyyy')
                WHEN 'yyyy/mm/dd' THEN TO_CHAR (m."Creation_datetime", 'yyyy/mm/dd')
            END AS "Creation_datetime",m.ATTACHMENT1 as ATTACHMENT,
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'A') as "Agency_Remark",
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'C') as "Client_Remark",
            case when v_approval_req='N' then 'Y' else 
                case when nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)=0 then 'Y' else nvl(m.app_status,'N') end 
            end as "APPROVAL_FLAG",TO_CHAR(m."Insertion_date",date1) as "INSERT_DATE",m."Insertion_date" dd
            FROM tbl_booking_mast m,tbl_booking_insert i,branch_mst b,login_branch_mast lb
            WHERE m."cio_booking_id" =i."Cio_Booking_Id"
            and m."Agency_sub_code"= nvl(pagency_code,m."Agency_sub_code")
            AND m."Ad_type_code" = adtype
            AND m."branch" = nvl(v_branch2,m."branch")
            AND m."branch"= b."Branch_Code"
            and m."branch"= lb.branch_code
            and m."Client_code"= nvl(pclient_code,m."Client_code")
            and m."date_time" BETWEEN fromdate AND todate
            AND m."audit" IS NULL AND m."ro_status"='1'
            AND m."Ad_cat_code" = nvl(v_cat,m."Ad_cat_code")
            AND lb.user_code = v_userid
            AND NVL (lb.user_flag, 'N') = 'Y'
            AND b."pub_center" = nvl(v_branch1,b."pub_center")
            and (i."PACKAGE_CODE"= v_package_code or v_package_code is null )
            and (i."SECTIONCODE"= psection_code or psection_code is null)
            and nvl(m.modified_audit,'N')!='Y' and exists (select "userid" from login where "userid"=m."Userid" and
            ((nvl("Agency_code",'0')<>'0' and nvl(p_booktype,'A') ='Q') or
            (nvl("Agency_code",'0')='0' and nvl(p_booktype,'A') ='D') or nvl(p_booktype,'A') ='A'))
            AND m."Uom_code"=nvl(extra1,m."Uom_code")
            order by m."Insertion_date",m."cio_booking_id";
    END IF;

    IF audittype = 'modified' THEN
        OPEN p_account FOR
            SELECT distinct m."cio_booking_id" as "cio_booking_id",
            NVL ((SELECT distinct "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),
            m."Client_code") AS "Client_code",
            m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",m."Receipt_no" as "Receipt_no",
            (SELECT distinct  "File_Name" FROM tbl_booking_insert
            WHERE "Cio_Booking_Id" =m."cio_booking_id"
            AND "File_Name" IS NOT NULL
            AND ROWNUM <= 1) AS "FILENAME",
            CASE date1 WHEN 'mm/dd/yyyy' THEN TO_CHAR(m."Creation_datetime",'mm/dd/yyyy')
                WHEN 'dd/mm/yyyy' THEN TO_CHAR (m."Creation_datetime", 'dd/mm/yyyy')
                WHEN 'yyyy/mm/dd' THEN TO_CHAR (m."Creation_datetime", 'yyyy/mm/dd')
            END AS "Creation_datetime",m.ATTACHMENT1 as ATTACHMENT,
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'A') as "Agency_Remark",
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'C') as "Client_Remark",
            case when v_approval_req='N' then 'Y' else 
                case when nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)=0 then 'Y' else nvl(m.app_status,'N') end 
            end as "APPROVAL_FLAG",TO_CHAR(m."Insertion_date",date1) as "INSERT_DATE",m."Insertion_date" dd
            FROM tbl_booking_mast m,tbl_booking_insert i,branch_mst b,login_branch_mast lb
            WHERE m."cio_booking_id" =i."Cio_Booking_Id"
            and m."Agency_sub_code"= nvl(pagency_code,m."Agency_sub_code")
            AND m."Ad_type_code" = adtype
            AND m."branch" = nvl(v_branch2,m."branch")
            AND m."branch"= b."Branch_Code"
            and m."branch"= lb.branch_code
            and m."Client_code"= nvl(pclient_code,m."Client_code")
            --and m."date_time" BETWEEN fromdate AND todate
            AND m."audit" IS NULL
            AND m."Ad_cat_code" = nvl(v_cat,m."Ad_cat_code")
            AND lb.user_code = v_userid
            AND NVL (lb.user_flag, 'N') = 'Y'
            AND b."pub_center" = nvl(v_branch1,b."pub_center")
            and (i."PACKAGE_CODE"= v_package_code or v_package_code is null )
            and (i."SECTIONCODE"= psection_code or psection_code is null)
            and nvl(m.modified_audit,'N')='Y' and exists (select "userid" from login where "userid"=m."Userid" and
            ((nvl("Agency_code",'0')<>'0' and nvl(p_booktype,'A') ='Q') or
            (nvl("Agency_code",'0')='0' and nvl(p_booktype,'A') ='D') or nvl(p_booktype,'A') ='A'))
            AND m."Uom_code"=nvl(extra1,m."Uom_code")
            order by m."Insertion_date",m."cio_booking_id";
    END IF;*/
    
    v_query_group:=' group by m."cio_booking_id" ,m."Client_code",m."audit", m."Ad_type_code",m."Receipt_no",
            m."Creation_datetime",m.ATTACHMENT1,nvl(m."Discount_per",0),nvl(m."Special_disc_per",0),m.app_status 
            order by dd,"cio_booking_id"';
    
    delete from test1;insert into test1(vstring,vstring2) values('bindaudit ',v_query||v_wherecl||v_query_group);commit;
    
    OPEN p_account FOR v_query||v_wherecl||v_query_group;
    
    
    
   END bindaudit_p;
END bindaudit;
/


//////////////////////////////////////////end of booking audit procedure//////////////////////////////////////////////



///////////////////////////////////start of publish audit date 30 oct 2012/////////////////////////////////////////





CREATE OR REPLACE PROCEDURE HT18JULY.Websp_Updatestatus
(
fromdate IN VARCHAR2,
todate IN VARCHAR2,
Adtype IN VARCHAR2,
branch in varchar2,
publication in varchar2,
dateformat in varchar2,
v_edition IN VARCHAR2,
v_supplement IN  VARCHAR2,
v_booking_audit in varchar2,
v_status_value in varchar2,
v_pub_cent_code IN VARCHAR2,
V_AD_CATEGORY IN VARCHAR2,
v_userid        in varchar2,
p_recordset OUT Cur_Type_New1.cursor_type
)
IS
query1 VARCHAR2(10000);
BEGIN
query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id",
"No_Insert" AS "no_of_insertion" ,

case TBL_BOOKING_INSERT."Supp_Code"
    when ''MN''then
    (select distinct EDITION_MAST."Edition_Alias" from EDITION_MAST where  tbl_booking_insert."Edition_Code"=EDITION_MAST ."Edition_Code")
    else
    (select distinct supplement_MAST."Supp_Name" from supplement_MAST where  tbl_booking_insert."Supp_Code"=supplement_MAST ."Supp_Code")
    end as "Editionname",

--(select distinct EDITION_MAST."Edition_Name" from EDITION_MAST where  tbl_booking_insert."Edition_Code"=EDITION_MAST ."Edition_Code") as "Editionname",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "client",
AGENCY_MAST."Agency_Name" AS "Agency",
TBL_BOOKING_INSERT."Gross_Rate" as "agreed_rate",
tbl_booking_mast ."Caption",
TBL_BOOKING_MAST."Trade_disc" AS "Commission",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date" ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''yyyy/mm/dd'') END AS "Ins.date" ,
tbl_booking_mast."RO_No",


TBL_BOOKING_INSERT."Height" AS "Depth" ,

nvl(TBL_BOOKING_INSERT."No_Ofcolumn" ,TBL_BOOKING_INSERT."Width") AS "Width" ,


TBL_BOOKING_INSERT. "Size_Book" AS "Area",


COL_MAST."Col_Alias" AS "Hue",

TBL_BOOKING_INSERT."Insert_Status" AS "status",
TBL_BOOKING_MAST."No_of_insertion" AS "total",



TBL_BOOKING_MAST."Bill_remarks",

tbl_booking_insert."Page_No"  as "Page_no",

(SELECT ADVPOS_TYPE_MAST."Pos_Type" FROM  ADVPOS_TYPE_MAST WHERE TBL_BOOKING_MAST."Page_position_code" =ADVPOS_TYPE_MAST ."Pos_Type_Code")AS "Page_pos1",

(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=TBL_BOOKING_INSERT ."Ad_Cat") AS "AdCat","Uom_Alias" as "Uom",

(SELECT distinct adv_subcat_mast."Adv_Subcat_Name" FROM adv_subcat_mast  WHERE adv_subcat_mast ."Adv_Subcat_Code"=TBL_BOOKING_INSERT ."Ad_Sub_Cat") AS "Sub_cat",

(select ad_cat3."catname" from ad_cat3,adv_subcat_mast where tbl_booking_mast."Ad_Subcat3"=ad_cat3."catcode" and ad_cat3."subcatname"=adv_subcat_mast."Adv_Subcat_Code" and TBL_BOOKING_INSERT ."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and TBL_BOOKING_INSERT ."Ad_Cat"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat3",

trim(TBL_BOOKING_INSERT."Edition") as "Edition",

(SELECT "premiumname" FROM ADVPOS_PREM_MAST WHERE ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_MAST."Page_prem") AS  Page_prem1 ,


(SELECT distinct adv_subcat_mast."Adv_Subcat_Name" FROM adv_subcat_mast  WHERE adv_subcat_mast ."Adv_Subcat_Code"=TBL_BOOKING_INSERT ."Ad_Sub_Cat") AS "Sub_cat",

(SELECT ADVPOS_PREM_MAST."premiumname" FROM  ADVPOS_PREM_MAST WHERE TBL_BOOKING_insert."Premium1" =ADVPOS_PREM_MAST ."Premiumcode")AS "Page_prem",

(SELECT ADVPOS_TYPE_MAST."Pos_Type" FROM  ADVPOS_TYPE_MAST WHERE TBL_BOOKING_insert."Page_Post" =ADVPOS_TYPE_MAST  ."Pos_Type_Code")AS "Page_pos"

,tbl_booking_insert."Bill_Amt"






FROM TBL_BOOKING_INSERT,
TBL_BOOKING_MAST,COL_MAST,UOM_MAST,
AGENCY_MAST,
login_branch_mast

 WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT ."Cio_Booking_Id"
AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"
 AND TBL_BOOKING_insert  ."Col_Code" =COL_MAST."Col_Code"
 AND TBL_BOOKING_Mast."Uom_code" =UOM_MAST."Uom_Code"
AND "Insert_Date" BETWEEN  '''||fromdate ||''' AND  '''||todate ||'''    
and
TBL_BOOKING_MAST."branch"= login_branch_mast.branch_code AND NVL (login_branch_mast.user_flag, ''N'') = ''Y''

';




If v_userid is not null then
query1:=query1||' and login_branch_mast.user_code= '''||v_userid||'''';
end if;  



if(v_status_value is not null)
then
query1:=query1 ||' AND TBL_BOOKING_insert. "Insert_Status" ='''||v_status_value||''' ';
end if;





if(v_status_value is  null)
then
query1:=query1 ||' AND TBL_BOOKING_insert. "Insert_Status" in (''publish'',''booked'') ';
end if;


if ((v_booking_audit ='Y')or(v_booking_audit ='y'))
then
query1:=query1 ||' AND TBL_BOOKING_MAST. "audit" is not null ';

end if;




IF(Adtype IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST. "Ad_type_code" ='''||Adtype||''' ';
END IF;

IF(publication IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_insert. "Publication_Code" ='''||publication||''' ';
END IF;



IF(v_pub_cent_code IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_insert."Pub_Cent_Code" ='''||v_pub_cent_code ||''' ';
END IF;




IF(branch IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST."branch" ='''||branch||''' ';
END IF;



IF(v_edition  IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_insert ."Edition_Code" ='''||v_edition||''' ';
END IF;


IF(v_supplement IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_INSERT."Supp_Code" ='''||v_supplement||''' ';
END IF;





IF(V_AD_CATEGORY IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_INSERT."Ad_Cat" ='''||V_AD_CATEGORY||''' ';
END IF;

query1:=query1 ||'ORDER BY "no_of_insertion"  ' ;






--delete from ANK_SEARCH ;
--iNSERT INTO ANK_SEARCH VALUES(query1);
--commit;
OPEN p_recordset FOR
 query1;



END ;
/


/////////////////////////////////////////end of publish audit  30 oct 2012/////////////////////////////////////////////


////////////////////********************start of rate audit 30 oct 2012************************//////////////////


CREATE OR REPLACE PACKAGE HT18JULY.websp_bindorderwise
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE websp_bindorderwise_p(
fromdate IN varchar2,
todate IN varchar2,
date1 IN varchar2,
branch IN varchar2,
adtype IN varchar2,
publication in varchar2,
pub_cent in varchar2,
edition in varchar2,
agency in varchar2,
client in varchar2,
branchnew in varchar,
v_retainer in varchar,
v_executive in varchar,
v_supplement in varchar,
v_insert_status in varchar,
v_userid in varchar,
v_payment_mode in varchar,
p_accounts   OUT      t_accounts_cursor
   );
END websp_bindorderwise;
/






CREATE OR REPLACE PACKAGE BODY HT18JULY.websp_bindorderwise
IS
   PROCEDURE websp_bindorderwise_p (
fromdate IN varchar2,
todate IN varchar2,
date1 IN varchar2,
branch IN varchar2,
adtype IN varchar2,
publication in varchar2,
pub_cent in varchar2,
edition in varchar2,
agency in varchar2,
client in varchar2,
branchnew in varchar,
v_retainer in varchar,
v_executive in varchar,
v_supplement in varchar,
v_insert_status in varchar,
v_userid in varchar,
v_payment_mode in varchar,
p_accounts   OUT      t_accounts_cursor
   )




IS



query1 VARCHAR2(10000);
VAR_DATE date;
puom_code varchar2(200);





BEGIN
puom_code:='CD';



SELECT  TO_CHAR(LAST_DAY(todate))  into VAR_DATE FROM DUAL;



if(v_insert_status ='publish')
then

query1:='select distinct tbl_booking_insert."Cio_Booking_Id" as "cio_booking_id",
nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where  cust_mast."Cust_Code"=tbl_booking_mast."Client_code"),"Client_code") as "client",
AGENCY_MAST."Agency_Name" as "Agency",
tbl_booking_mast."Gross_amount" as "gross_amount",
CASE '||''''||date1||''''|| '
 WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insertion_date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insertion_date",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insertion_date",''yyyy/mm/dd'')  END AS "Ins.date",
tbl_booking_mast."RO_No",
COL_MAST."Col_Alias" as "Col_Name",
tbl_booking_MAST."Ad_size_type_code"    AS   "Size_Book",
tbl_booking_MAST ."Agrred_rate"     AS "Agreed_Rate",
tbl_booking_MAST . "Bill_amount"  AS   "Bill_Amt",
"Ad_size_height" AS "Height", "Ad_size_width" AS "Width",

(SELECT count(tbl_booking_insert."Insert_Id") FROM  tbl_booking_insert WHERE tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" AND
"Insert_Date" between '||''''||fromdate||''''|| ' and '||''''||VAR_DATE||''''|| '   and  TBL_BOOKING_INSERT."Insert_Status" not in(''audit by rate'',''billed'',''cancel'')) as "TotalCount"


,(SELECT count(tbl_booking_insert."Insert_Id") FROM  tbl_booking_insert WHERE tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" AND
"Insert_Date" between '||''''||fromdate||''''|| ' and '||''''||VAR_DATE||''''|| ' and  TBL_BOOKING_INSERT."Insert_Status" =''publish''  and  TBL_BOOKING_INSERT."Insert_Status" ! =''cancel'' and  TBL_BOOKING_INSERT."Insert_Status" ! =''audit by rate'' )as "PublishCount"



from tbl_booking_insert,
tbl_booking_mast,
COL_MAST,
agency_mast where tbl_booking_mast ."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id"  and
 TBL_BOOKING_MAST."Color_code"=COL_MAST."Col_Code"  AND
 agency_mast."code_subcode"=tbl_booking_mast."Agency_sub_code"';

end if;


if(v_insert_status ='audit by rate')
then

query1:='select distinct tbl_booking_insert."Cio_Booking_Id" as "cio_booking_id",
nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where  cust_mast."Cust_Code"=tbl_booking_mast."Client_code"),"Client_code") as "client",
AGENCY_MAST."Agency_Name" as "Agency",
tbl_booking_mast."Gross_amount" as "gross_amount",
CASE '||''''||date1||''''|| '
 WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insertion_date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insertion_date",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insertion_date",''yyyy/mm/dd'')  END AS "Ins.date",
tbl_booking_mast."RO_No",
COL_MAST."Col_Alias" as "Col_Name",
tbl_booking_MAST."Ad_size_type_code"    AS   "Size_Book",
tbl_booking_MAST ."Agrred_rate"     AS "Agreed_Rate",
tbl_booking_MAST . "Bill_amount"  AS   "Bill_Amt",
"Ad_size_height" AS "Height", "Ad_size_width" AS "Width",

(SELECT count(tbl_booking_insert."Insert_Id") FROM  tbl_booking_insert WHERE tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" AND
"Insert_Date" between '||''''||fromdate||''''|| ' and '||''''||VAR_DATE||''''|| '   and  TBL_BOOKING_INSERT."Insert_Status" ! =''cancel'' ) as "TotalCount"


,(SELECT count(tbl_booking_insert."Insert_Id") FROM  tbl_booking_insert WHERE tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" AND
"Insert_Date" between '||''''||fromdate||''''|| ' and '||''''||VAR_DATE||''''|| ' and  TBL_BOOKING_INSERT."Insert_Status" =''audit by rate''  and  TBL_BOOKING_INSERT."Insert_Status" ! =''cancel'' )as "PublishCount"



from tbl_booking_insert,
tbl_booking_mast,
COL_MAST,
agency_mast where tbl_booking_mast ."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id"  and
 TBL_BOOKING_MAST."Color_code"=COL_MAST."Col_Code"  AND
 agency_mast."code_subcode"=tbl_booking_mast."Agency_sub_code"';

end if;








if(v_insert_status is not null)
then
query1:=query1 ||' AND TBL_BOOKING_insert. "Insert_Status" ='''||v_insert_status||''' ';
end if;




/*
if(v_insert_status is  null)
then
query1:=query1 ||' AND TBL_BOOKING_insert. "Insert_Status" in (''publish'',''audit by rate'') ';
end if;
*/


IF(v_retainer   IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_mast ."RETAINER"='''||v_retainer ||'''';
END IF;


IF(v_executive  IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_mast ."Executive_code"='''||v_executive||'''';
END IF;











IF(v_supplement  IS NOT NULL)
THEN
query1:=query1||'  and TBL_BOOKING_insert ."Supp_Code"='''||v_supplement||'''';
END IF;





IF(branchnew  IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_mast ."branch"='''||branchnew||'''';
END IF;



IF(client IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_mast ."Client_code"='''||client||'''';
END IF;



IF(pub_cent IS NOT NULL)
THEN

query1:=query1||'  and TBL_BOOKING_MAST   ."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||pub_cent||'''))';
--query1:=query1||'  and tbl_booking_insert."Pub_Cent_Code"='''||pub_cent||'''';
END IF;


IF(agency IS NOT NULL)
THEN
query1:=query1 ||'  AND  TBL_BOOKING_MAST  ."Agency_sub_code" ='''||agency ||'''';
END IF;







IF(publication IS NOT NULL)
THEN
query1:=query1||' and  TBL_BOOKING_insert."Publication_Code"='''||publication||'''';
END IF;


/*

IF(adtype IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST. "Ad_type_code" ='''||adtype||'''';
END IF;
*/


IF(adtype='DI0')
THEN
query1:=query1||'  and (tbl_booking_mast."Uom_code" in (select UOM_MAST ."Uom_Code" FROM UOM_MAST  WHERE UOM_DESC ='||''''||puom_code||''''||') or '||''''||puom_code||''''||' is null)';

END IF;

IF(adtype ='CL0')
THEN
query1:=query1||'  and (tbl_booking_mast."Uom_code" in (select UOM_MAST ."Uom_Code" FROM UOM_MAST  WHERE UOM_DESC !='||''''||puom_code||''''||') or '||''''||puom_code||''''||' is null)';
END IF;



IF(fromdate IS NOT NULL AND todate IS NOT NULL )
THEN
    query1:=query1||' and "Insert_Date" between  '''||fromdate ||''' and  '''||todate||''' ';
END IF;

IF(edition IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_insert."Edition_Code"='''||edition||'''';
END IF;

IF(v_payment_mode IS NOT NULL)
THEN
query1:=query1||'  and TBL_BOOKING_MAST ."Bill_pay"='''||v_payment_mode||'''';
END IF;



--delete from ANK_SEARCH ;
--iNSERT INTO ANK_SEARCH VALUES(query1);

--COMMIT;




OPEN p_accounts  FOR

query1;






  --and "branch"=branch






   END websp_bindorderwise_p;
END websp_bindorderwise;
/


/////////////////////////////////end of rate audit 30 oct 2012//////////////////////////////////////////



.///////////////////////////********isue no 8944 anuj***********///////////////

alter table tbl_booking_mast_q 
add ("Agency_sub_code" varchar2(20));


--------




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



    vquery:='SELECT (select Agency_Name from agency_mast where Comp_Code='''||compcode||''' and code_subcode=tbl_booking_mast_q.Agency_sub_code) agency,
    (select Cust_Name from cust_mast where Comp_Code='''||compcode||''' and Cust_Code= Client_code) client,
    cio_booking_id as "TEMPID", (select count(*) from tbl_booking_insert_q where tbl_booking_insert_q.cio_booking_id=tbl_booking_mast_q.cio_booking_id) INSERTION,QUOTATIONFLAG
    from tbl_booking_mast_q a where Comp_code='''||compcode||''' and date_time between '''|| v_varFromDate||''' and '''|| v_varToDate||''' ';
    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------BHANU
    if (padtype <>'') then
         vquery := vquery||' and "Ad_type_code" = '''||Padtype||'''' ;
    end  if;    
   
       
    if (agency!='') then
        vquery := vquery|| ' and Agency_sub_code = '''||agency||'''';
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
       
    end ;
/




//////////////////////////***************end of issue********************************//////////////////////////////


////////////////////////start 8428//////////////////////////////////////

CREATE OR REPLACE PROCEDURE websp_GetAdMaterial_CD
(
    compcode  VARCHAR2,
    pubdate  date,
    pubcode  VARCHAR2,
    centercode  VARCHAR2,
    editioncode  VARCHAR2,
    suppcode  VARCHAR2,
    pageno   VARCHAR2,
    p_GetAgency OUT Cur_Type_New1.cursor_type
)
    
AS

    BEGIN
        OPEN p_GetAgency FOR
            SELECT IDNUM AS "idnum",COLOUR AS "colour",SZ1 AS "sz1",COL1 AS "col1",nvl(PUBSIZE,0) AS "pubsize",nvl(PUBCOL,0) AS "pubcol",
            CLIENT_NAME AS "client_name",CLIENTNAME AS "clientname",CAPTION AS "caption",nvl(PAGE_NO,0)AS "page_no",INSNUM AS "insnum",
            FILE_NAME AS "file_name",PAGINATION_ID as "insert_id",REMARK1 as "remark1","Edition_Alias" AS edition_name  FROM clfd_ad_ros,edition_mast 
            WHERE  clfd_ad_ros.comp_code=edition_mast."Comp_Code"  AND clfd_ad_ros.edition=edition_mast."Edition_Code"
            AND COMP_CODE=compcode AND INSDATE=pubdate AND PRIPUB=pubcode AND BKFOR=centercode 
            AND EDITION=editioncode AND SECPUB=suppcode and uom='CL0' AND (PAGE_NO=pageno or  pageno is NULL)
            AND "CANMISS" not in ('C','W','H')
            ORDER BY IDNUM,to_number(PAGE_NO);

END;
/


////////////////////////////////////////////////////////////////////

CREATE OR REPLACE PROCEDURE Websp_Show_Permission(compcode VARCHAR2,userid VARCHAR2,formname IN OUT VARCHAR2)
IS

	 CURSOR c_1 IS SELECT DISTINCT form_name FROM FORM_DETAIL WHERE comp_code=compcode AND userid=userid AND form_name=formname;
	 --CURSOR c_1 IS SELECT userid,date_format,com_code FROM LOGIN WHERE username=username AND password=password;
	 x_1 c_1 % ROWTYPE;

	 BEGIN
	 	  OPEN c_1;
		  FETCH c_1 INTO x_1;
		  WHILE c_1%FOUND
		  LOOP
		  	  formname:=x_1.form_name;
			  FETCH c_1 INTO x_1;
		  END LOOP;
		  CLOSE c_1;
END;
/


//////////////////////////////////////////////////////

CREATE OR REPLACE PACKAGE body websp_GetClient is

procedure websp_GetClient_p(
compcode in varchar2,
pubdate in date,
iidnum in varchar2,
P_Accounts out T_Accounts_Cursor)as
begin
    open  P_Accounts for
    select distinct "Client_code" as "client_code" from tbl_booking_mast where  "Comp_code"=compcode and /*"Insertion_date"=pubdate and*/  
    "cio_booking_id"=iidnum;
end  websp_GetClient_p;
end  websp_GetClient;
/

////////////////////////////////////////////////////////////

CREATE OR REPLACE procedure add_cd_upload_for_all(

bookind_id  in  varchar2,
p_accounts    OUT      cur_type_new1.cursor_type

)

as

begin

 open p_accounts for

select "Insert_Id" ,"Insert_Date","Edition_Code","No_Insert" from  tbl_booking_insert where  "Cio_Booking_Id"=bookind_id;
end;
/

//////////////////////////endissue 8428/////////////////////////////

//////////////////////////////////**********anuj issue no 8444********************//////////////////////////////////////////////////
DROP PACKAGE HT18JULY.CHKDATEINSERT;

CREATE OR REPLACE PACKAGE HT18JULY.chkdateinsert  is type t_accounts_type is ref cursor  ;
procedure    chkdateinsert_p(
date1 in varchar2,
noissueday in varchar2,
issuecode in varchar2,
compcode in varchar2,
userid in varchar2,
p_accounts OUT t_accounts_type
);
end  chkdateinsert;
/



DROP PACKAGE BODY HT18JULY.CHKDATEINSERT;

CREATE OR REPLACE PACKAGE BODY HT18JULY.chkDateinsert  AS
PROCEDURE    chkdateinsert_p(
date1 IN VARCHAR2,
noissueday IN VARCHAR2,
issuecode IN VARCHAR2,
compcode IN VARCHAR2,
userid IN VARCHAR2,
p_accounts OUT t_accounts_type


) AS

count1 int;

BEGIN
open p_accounts for
select COUNT(*) as count11 into count1 from No_Iss_Grid where "No_Iss_Code"in (select "No_Iss_Code" from no_iss_mast where "Edition_Code"=issuecode) and "no_issue_date"=date1;

END ;
END chkDateinsert;
/


-----------------------------

DROP PROCEDURE HT18JULY.EXECUTENOISSUEDATE;

CREATE OR REPLACE PROCEDURE HT18JULY.executenoissuedate
(

pcompcode in  varchar2,
editioncode in  varchar2,
p_accounts out Cur_Type_New1.cursor_type



)

is
begin


IF editioncode  is null THEN

open p_accounts for 
select distinct "No_Iss_day","no_issue_date",
nvl((select "Edition_Alias" from edition_mast where "Edition_Code"= no_iss_mast."Edition_Code"),no_iss_mast."Edition_Code") as "EDITION" 
 from no_iss_grid,no_iss_mast where no_iss_grid."Comp_Code"=pcompcode and no_iss_grid."No_Iss_Code"=no_iss_mast."No_Iss_Code";
 
ELSE
open p_accounts for 
--select "No_Iss_day","no_issue_date",nvl((select "Edition_Name" from edition_mast where "Edition_Code"= editioncode),editioncode) as "EDITION" from no_iss_grid where "No_Iss_Code"
 --in (select "No_Iss_Code" from no_iss_mast where "Edition_Code"=editioncode) ;
select distinct "No_Iss_day","no_issue_date",
nvl((select "Edition_Alias" from edition_mast where "Edition_Code"= no_iss_mast."Edition_Code"),no_iss_mast."Edition_Code") as "EDITION" 
 from no_iss_grid,no_iss_mast where no_iss_grid."Comp_Code"=pcompcode and no_iss_mast."Edition_Code"=editioncode and no_iss_grid."No_Iss_Code"=no_iss_mast."No_Iss_Code";
 
END IF;

end executenoissuedate;
/


/////////////////////////////**************(END)/////////////////////////////////////////////////


///////////////////////////////////***********issue 8816 (20/11/2012)********************/////////////////////////

CREATE OR REPLACE procedure HT18JULY.ChkExecutiveCreditLimit(
pcompcode in varchar2,
puserid in varchar2,
pexecname in varchar2,
pciobookid in varchar2,
pgrossamt in NUMBER,
pbillamt in NUMBER,
ppaymode in varchar2,
p_accounts   OUT   cur_type_new1.cursor_type
)
as


 ptotbill NUMBER;
 ptotbooking NUMBER;
 pfinaltot NUMBER;
 pcreditlimit NUMBER;
 pchkpref varchar2(1000);
 pexecpaymode varchar2(1000);
 temp varchar2(5);
 a int;


BEGIN
delete from result;
a:=fn_splitfield(pexecpaymode,',');
begin
select  executivecreditlimit into pchkpref  from preferrences  where "comp_code"=pcompcode and "userid"=puserid;
 EXCEPTION
                  WHEN NO_DATA_FOUND
                  THEN
                     NULL;
               END;
begin
select nvl(credit_limit,0) into pcreditlimit from exec_mast where "Exe_no"=pexecname and instr(ppaymode,paymentmode)>0 ;
 EXCEPTION
                  WHEN NO_DATA_FOUND
                  THEN
                     NULL;
               END;
if pchkpref = '1' and pcreditlimit>0 then

    select sum(tbl_booking_insert."Bill_Amt") into ptotbill from tbl_booking_insert ,tbl_booking_mast where tbl_booking_insert."Insert_Status" not in('billed','cancel') 
    and tbl_booking_mast."cio_booking_id"!=pciobookid and 
    tbl_booking_mast."Executive_code"=pexecname and 
    tbl_booking_insert."Cio_Booking_Id"=tbl_booking_mast."cio_booking_id"

    and tbl_booking_mast."Bill_pay" in (select Edition_Name from result)

    group by tbl_booking_insert."Cio_Booking_Id";

select sum(tbl_booking_insert."Bill_Amt") into ptotbooking from tbl_booking_insert 
where tbl_booking_insert."Cio_Booking_Id"=pciobookid 
and tbl_booking_insert."Insert_Status" not in('billed','cancel') group by tbl_booking_insert."Cio_Booking_Id";

 pfinaltot:=ptotbill + ptotbooking;


    if ptotbooking > pcreditlimit and pcreditlimit>0 then
    open p_accounts for
    select 'N'  as "N" from dual;
    else 
    open p_accounts for
    Select 'Y' as "Y"  from dual;
    end if;  
    else
      open p_accounts for
    Select 'Y' as "Y"  from dual;  
end if;
END;
/
////////////////////////////////////*********end*********/////////////////////////////////////