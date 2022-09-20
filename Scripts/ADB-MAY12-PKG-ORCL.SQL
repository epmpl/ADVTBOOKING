///////////////issue no 7250//////////////////////////


CREATE OR REPLACE PROCEDURE Reportnew(
agname      IN VARCHAR2:=NULL,
clientname  IN VARCHAR2:=NULL,
adtype1     IN VARCHAR2,
Adcategory  IN VARCHAR2,
fromdate    IN VARCHAR2,
dateto      IN VARCHAR2,
compcode    IN VARCHAR2,
pub_name    IN VARCHAR2,
pub_cent    IN VARCHAR2,
status      IN VARCHAR2:=NULL,
edition     IN VARCHAR2,
dateformat  IN VARCHAR2,
hold        IN VARCHAR2:=NULL,
descid      IN VARCHAR2:=NULL,
ascdesc     IN VARCHAR2:=NULL,
agtype      in varchar2:=null,
puserid     in varchar2:=null,
chk_access  in varchar2:=null,
pextra1     in varchar2:=null,--for UOM
pextra2     in varchar2:=null,
pextra3     in varchar2:=null,
pextra4     in varchar2:=null,
pextra5     in varchar2:=null,
p_reportnew OUT Cur_Type_New1.cursor_type)
IS

center      VARCHAR(50);
from_date   DATE;
date_to     DATE;
v_query     VARCHAR(8000);
a           number;

BEGIN

v_query:='SELECT m."cio_booking_id" AS "CIOID",i."Edition" as "edition",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR(i."Insert_Date" ,''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(i."Insert_Date",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(i."Insert_Date",''yyyy/mm/dd'')  END AS "Ins.date" ,
i."Insert_Date" as "Insert_Date",
a."Agency_Name" AS "Agency",(select "City_Name" from city_mst where "City_Code"=a."City_Code") as "AGENCY_CITY",
(select  agency_mast."SUB_Agency_Code" from agency_mast where agency_mast."Type" <> ''P'' AND m."Agency_code"=agency_mast."Agency_Code" AND m."Agency_sub_code"=agency_mast."code_subcode") AS "SubAg",
nvl((select "Cust_Name" from cust_mast where "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
fetch_insert_package('''||compcode||''',m."cio_booking_id",null,''N'') AS "Package",
i."Col_Code" AS "Color_code",
round(i."Size_Book",2) AS "Area",
u.UOM_DESC  as "uom",
i."Height" AS "Depth",
i."Width"  AS "Width",
(SELECT ADVPOS_TYPE_MAST."Pos_Type_Alias" FROM ADVPOS_TYPE_MAST WHERE i."Page_Post"=ADVPOS_TYPE_MAST."Pos_Type_Code") AS "Page",
m."Bullet_code" AS "BulletPremium" ,
i."Page_Post" AS "PositionPremium" ,
i."Premium1" AS "PagePremium" ,
m."RO_No" AS "RoNo.",
CASE m."ro_status"
WHEN ''2'' THEN ''Reservation''
WHEN ''1'' THEN ''Confirm'' END AS "RoStatus",
(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=i."Ad_Cat") AS "AdCat",
m."Rate_code" AS "RateCode",
m."Card_rate" AS "CardRate",
nvl(m."Agrred_rate",m."Card_rate") AS "AgreedRate",
i."Bill_Amt"  AS "Amt",
m."Caption" AS "Cap",
m."Key_no" AS "Key",
m."Trade_disc" AS "Disc",
i."Insert_Status" AS "Status",
i."Status_Material" AS "MatStatus",
(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
sysdate as "Rundate",
i.bill_no as "BILL_NO",i.bill_date as "BILL_DATE",
(select "Exec_name" from exec_mast where  to_char("Exe_no") = m."Executive_code") as "EXECUTIVE",
(select "Retain_Name" from retainermaster where "Comp_Code"=m."Comp_code" and "Retain_Code"= m."RETAINER") as "RETAINER"

from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,uom_mast u 
WHERE m."Comp_code"='''||compcode||'''
AND m."cio_booking_id"=i."Cio_Booking_Id" 
AND m."Agency_code"=a."Agency_Code"
AND m."Agency_sub_code"=a."code_subcode" and m."Uom_code"=u."Uom_Code"
AND not exists (select ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
and  lower(i."Insert_Status") !=''cancel''
and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and nvl('''||chk_access||''',''0'')=''1'')
or  (nvl('''||chk_access||''',''0'')=''0'') )';


/*IF(hold IS NOT NULL)THEN
    query:=query||' and i."Insert_Status"!='''||'Cancel'||'''';
END IF;*/

IF(agname IS NOT NULL)
THEN
    v_query:=v_query||' and m."Agency_code" ='''||agname||'''';
END IF;

IF(clientname IS NOT NULL)
THEN
    v_query:=v_query||' and m."Client_code"='''||clientname ||'''';
END IF;

IF(status IS NOT NULL)
THEN
    v_query:=v_query||' and i."Insert_Status"='''||status||'''';
/*
else
query:=query||' and lower(i."Insert_Status") !=''cancel'' ';*/
END IF;

IF(adtype1 IS NOT NULL)
THEN
    v_query:=v_query||' and m."Ad_type_code"='''||adtype1||'''';
END IF;

IF(Adcategory IS NOT NULL)
THEN
    a:=Fn_Splitfield(Adcategory,',');
    v_query:=v_query||' and i."Ad_Cat" in(select "EDITION_NAME" from result)';

    --v_query:=v_query||' and m."Ad_cat_code" in('''||Adcategory||''' )';
END IF;

IF(pub_cent IS NOT NULL)
THEN
    v_query:=v_query||'  and i."Pub_Cent_Code"='''||pub_cent||'''';
END IF;

IF(fromdate IS NOT NULL AND dateto IS NULL )
THEN
    v_query:=v_query||' and i."Insert_Date" ='''||fromdate||'''';
END IF;

IF(fromdate IS NOT NULL AND dateto IS NOT NULL )
THEN
    v_query:=v_query||' and i."Insert_Date" between  '''||fromdate ||''' and  '''||dateto||''' ';
END IF;

IF(edition IS NOT NULL)
THEN
    v_query:=v_query||'  and i."Edition_Code"='''||edition||'''';
END IF;

IF(pub_name IS NOT NULL)
THEN
    v_query:=v_query||' and  i."Publication_Code"='''||pub_name||'''';
END IF;

IF(pextra1 IS NOT NULL) THEN
    v_query:=v_query||'  and m."Uom_code"='''||pextra1||'''';
END IF;

IF((agtype IS NOT NULL) AND (agtype <> 'Package') AND (agtype <> 'Solo'))
THEN
    v_query:=v_query||' and  m."Agency_type"='''||upper(agtype)||'''';
END IF;

IF(descid IS NOT  NULL)
THEN
    v_query:=v_query||'  order by "'||descid||'"';
    v_query:=v_query||''||ascdesc||'';
ELSE
    v_query:=v_query||'  order by "Insert_Date",m."cio_booking_id"';
END IF;

delete from searchtbl;insert into searchtbl values('All Ads of the Agency'||v_query);commit;

OPEN p_reportnew FOR v_query;

END Reportnew;
/



///////////////////////////////end of issue no 7250//////////////


=======start=========7356=====avinash03-may-2012===========================

CREATE OR REPLACE PROCEDURE HT18JULY.rate_expupdat
(
compcode in varchar2,
expdate in  varchar2,
ratecod in varchar2,
extra1 in varchar2

)


AS 
begin

UPDATE Rate_Mast SET "Valid_To"=expdate WHERE "rateuniqueid"=ratecod;

 commit;
end;
/


-------------------------



CREATE OR REPLACE procedure HT18JULY.rate_expiry(

compcode in varchar2,
adtypcod in varchar2, 
ratecod in varchar2,
categrycod in varchar2,
colorcod in varchar2,
uomcod in varchar2,
frdate in varchar2,
todate in varchar2,
packgcod in varchar2,
extra1 in varchar2,
extra2 in varchar2,

p_Accounts OUT Cur_Type_New1.cursor_type
)
 as Begin
 -- advpos_prem_mast
 OPEN p_Accounts FOR
 select "Rate_Mast_Code",
 (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
 ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
 (select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium") as "Premium","Size_To","Size_From",
 "From_insertion","To_insertion",
 (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code") as "Package_Name",
       "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        ("Adv_Type_Code"=adtypcod or adtypcod is null )
         and ("Rate_Mast_Code"=ratecod or  ratecod is null)
       and ("Adv_Cat_Code"=categrycod or  categrycod is null)
        and ("Color"=colorcod or  colorcod is null)
         and ("Uom"=uomcod or  uomcod is null)
         and ("Combin_Code"=packgcod or packgcod is null)
       and ("Valid_From"=frdate and "Valid_To"=todate) ;
       end;
/

========start========7356=====avinash03-may-2012===========================



CREATE OR REPLACE procedure HT18JULY.rate_expiry(

compcode in varchar2,
adtypcod in varchar2, 
ratecod in varchar2,
categrycod in varchar2,
colorcod in varchar2,
uomcod in varchar2,
frdate in varchar2,
todate in varchar2,
packgcod in varchar2,
extra1 in varchar2,
extra2 in varchar2,

p_Accounts OUT Cur_Type_New1.cursor_type
)
 as Begin
 -- advpos_prem_mast
 OPEN p_Accounts FOR
 select "Rate_Mast_Code",
 (Select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=rate_mast."Adv_Cat_Code") as "Adv_Cat_Code"
 ,"Color",(select "Uom_Name" from uom_mast where "Uom_Code"="Uom") as "Uom",
 (select "premiumname" from advpos_prem_mast where "Premiumcode"="Premium") as "Premium","Size_To","Size_From",
 "From_insertion","To_insertion",
 upper((select "Package_Name" from combin_mast where combin_mast."Combin_Code"=rate_mast."Combin_Code")) as "Package_Name",
       "Week_Day_Rate","Week_Extra_Rate","rateuniqueid" from Rate_Mast where
        ("Adv_Type_Code"=adtypcod or adtypcod is null )
         and ("Rate_Mast_Code"=ratecod or  ratecod is null)
       and ("Adv_Cat_Code"=categrycod or  categrycod is null)
        and ("Color"=colorcod or  colorcod is null)
         and ("Uom"=uomcod or  uomcod is null)
         and ("Combin_Code"=packgcod or packgcod is null)
       and ("Valid_From"=frdate and "Valid_To"=todate) ;
       end;
/

========end========7356=====avinash03-may-2012===========================

//===========================PAtch for Adon in combin_mast (Kuldeep Bhati)==================//

CREATE TABLE COMBIN_ADONS_DETAILS
(
  COMBIN_CODE           VARCHAR2(100 BYTE)       NOT NULL,
  ADON_CODE             INTEGER                  NOT NULL,
  PACKAGE_CODE          VARCHAR2(10 BYTE)        NOT NULL,
  COMP_CODE             VARCHAR2(8 BYTE)         NOT NULL,
  USERID                VARCHAR2(8 BYTE)         NOT NULL,
  CRATEION_DATETIME     DATE                     NOT NULL,
  PUBLICATION           VARCHAR2(8 BYTE)         NOT NULL,
  NO_OF_INSERT          VARCHAR2(5 BYTE)
)

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


CREATE SEQUENCE AD_COMBINADON_SEQ
  START WITH 1
  MAXVALUE 999999999999999999999999999
  MINVALUE 1
  NOCYCLE
  CACHE 20
  NOORDER;

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE procedure bindadongrid4combin
(
PCOMPCODE   IN VARCHAR2,
PCOMBINCODE IN VARCHAR2,
P_ACCOUNTS OUT Cur_Type_New1.cursor_type
)as

begin


open P_ACCOUNTS for
select ADON_CODE, PUBLICATION AS "Pubcode",PUBLICATION AS "Publication", PACKAGE_CODE AS "Edition_code" ,PACKAGE_NAME AS "Edition" , NO_OF_INSERT AS "noofinsert"
    from COMBIN_ADONS_DETAILS where COMBIN_CODE=PCOMBINCODE and COMP_CODE=PCOMPCODE;


end ;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE procedure filladongrid4combin
(
PCOMPCODE   IN VARCHAR2,
PADONCODE IN VARCHAR2,
P_ACCOUNTS OUT Cur_Type_New1.cursor_type
)as

begin


open P_ACCOUNTS for
select ADON_CODE, PUBLICATION AS "Pubcode",PACKAGE_CODE AS "Edition_code" , NO_OF_INSERT ,PACKAGE_NAME
    from COMBIN_ADONS_DETAILS where ADON_CODE=PADONCODE and COMP_CODE=PCOMPCODE;


end ;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE procedure bindsolopackage4combin
(
compcode   IN VARCHAR2,
pubcode IN VARCHAR2,
padtype IN VARCHAR2,
P_Accounts OUT Cur_Type_New1.cursor_type
)as

begin


open P_Accounts for

select "Combin_Code","Combin_Desc" from combin_mast where instr("Combin_Desc",'+')<=0 and "Ad_Type_code"=padtype
and "Combin_Desc" like pubcode||'%';
end ;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE COMBINADON_INS_UPD_DEL (
                                         PCOMP_CODE        IN VARCHAR2,
                                         PCOMBIN_CODE      IN VARCHAR2,
                                         PADON_CODE        IN VARCHAR2,
                                         PPACKAGE_CODE      IN VARCHAR2,
                                         PPUBLICATION      IN VARCHAR2,
                                         PNO_OF_INSERT     IN VARCHAR2,
                                         PUSERID           IN VARCHAR2,
                                         PTRN_TYPE         IN VARCHAR2, --'I' For Insert, 'U' For Update, 'D' For Delete & 'E' For Execute
                                         PEXTRA1           IN VARCHAR2, --for PPACKAGE_NAME
                                         PEXTRA2           IN VARCHAR2, 
                                         PEXTRA3           IN VARCHAR2, 
                                         PEXTRA4           IN VARCHAR2, 
                                         PEXTRA5           IN VARCHAR2
                                         )AS
BEGIN
  IF NVL(PTRN_TYPE,'?')='I' THEN
     INSERT INTO COMBIN_ADONS_DETAILS (COMBIN_CODE, ADON_CODE, PACKAGE_CODE, 
                                        COMP_CODE, USERID, CRATEION_DATETIME,
                                         PUBLICATION, NO_OF_INSERT,PACKAGE_NAME)
                         VALUES (PCOMBIN_CODE, AD_COMBINADON_SEQ.NEXTVAL, PPACKAGE_CODE, 
                                        PCOMP_CODE, PUSERID, SYSDATE,
                                         PPUBLICATION, PNO_OF_INSERT,PEXTRA1);
  END IF;
  IF NVL(PTRN_TYPE,'?')='U' THEN
    UPDATE COMBIN_ADONS_DETAILS  SET --COMBIN_CODE=PCOMBIN_CODE, PACKAGE_CODE=PPACKAGE_CODE, 
                                    -- PUBLICATION=PPUBLICATION,,PACKAGE_NAME=PEXTRA1
                                      NO_OF_INSERT=PNO_OF_INSERT
                   WHERE COMP_CODE = PCOMP_CODE
                     AND ADON_CODE  = PADON_CODE;
                    
  END IF;
  IF NVL(PTRN_TYPE,'?')='D' THEN
     DELETE FROM COMBIN_ADONS_DETAILS
           WHERE COMP_CODE = PCOMP_CODE
            AND ADON_CODE  = PADON_CODE;
  END IF;

END;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//===========================End PAtch for Adon in combin_mast (Kuldeep Bhati)==================//



///////////start of issue no 7423/////////////////////////

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
P_WEIGHT_CAL IN VARCHAR2
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
P_WEIGHT_CAL IN VARCHAR2

)AS
BEGIN
UPDATE LOGIN SET "date_format"=dateformat, "Autogenerate"=code,"curr_code"=curr WHERE "COM_CODE"=compcode;
COMMIT;
        UPDATE PREFERRENCES SET  "autogenerated"=code,
"currency_code"=curr ,
"rate_gr_code"=RATECODE11,
"date_format"=dateformat,"solo"=solo,"breakup"=breakup,
"blackwhitecode"=bwcode,"rostatus"=rostatus,"File_name"=filename,"Tfn"=tfn,
"Insert_breakup"=insertbreak,"Premium_type"=prem,"Deal_type"=dealtype  ,
 "prefix"=pre, "suffix"=suff, "financestatus"=financestatus , "voucherst"=voucherst,
 "Ad_category"=adcode ,"Ro_datetime"=rodatetime ,"Space_area"=spacearea,"Vat"=vat,
 "Booking_status"=bookstat,"Cio_id"=cio_id,"Receipt_no"=receipt_no,"uom_code"=uom,
 "Bgcolor_publication"=bgcolor ,"chkfor_valid_pubdates"=validdate, "Agency_ratecode"=agencyratecode,
  "audit"=AUDIT1,"book_insert_date"=book_insert_date,"agencycomm"=agencycomm,
  "rate_audit"=rateaudit,"bill_audit"=billaudit,"billtype"=bill_type,"invoice_no"=invoice_no1,
  "copy_booking"=copybooking,"RATE_COMPANY_AGENCY"=ratecompany, "ADDITIONAL_AGENCY_COMM"=addagenycomm ,
  "AGENCY_RETAINER_COMM"=agencycommlinkretainer,"SUBEDITIONRATE"=subeditionr,
  "CLS_BILLTYPE"=classifiedbilltype,"DIS_BILLTYPE"=displaybilltype,"BILLING_FORMAT"=billformat,
  "RATE_CHECK"=ratechk,"ALL_PACKAGE"=allpkg,"DAYRATE"=dayrate1,"SCHEME_TYPE"=schemetype,"DISP_CLSBILL"=PIncludeclassi   ,
  "CASH_RECEIPT_BILL"=v_cash_receipt, "BILL_ORDERWSLAST"=v_bill_orderwiselast, "FLOOR_CHK"=v_floor_chk ,
  "UNSOLD_ENTRY_FLAG"=Unsoldflag ,"SUPPLY_STOP_PERCENTAGE"=Supplystopper,"ROKEYCHECK"=drpRokeychk ,
  "AGENCYCOMM_SEQ_COM"=Agencycomm_seq ,"CREDIT_RECIPT"=creditreciept,"DISP_CASHBILL"=cashindisplay,
  "CLA_CASHBILL"=cashinclassified,"RATE_AUDIT_PREF"=v_rate_audit_pref,"BARCODING_ALLOWED"=v_barcoding_allow_pref,
  "FMG_BILL_DIS" =v_fmgbills, "BILL_DISP_CASHBILL"=v_billed_cashdis , "BILL_CLA_CASHBILL"=v_billed_cashcls,"BACKDATERECEIPT"=v_drpbackdate,"DOCKIT_BOOKING"=dockitbooking,"Allowed_old_date"=allowprevbooking,"ROWISE_CASHBOOKING"=ro_wisecashbill,"CUTOFFTIME"=chkval,"APPROVAL"=approval1,"BACK_DAYS"=pckstatus ,CASH_DISCOUNT=cash_amt,CASH_DISCOUNTTYPE=cash_disc,SEPRATE_CASHIER=seperate_cashier1,
   CIR_MANY_TIME_POSTING=mantimepost, CIR_BACKDAYS_POSTING=bkdaypost, CIR_MAX_RETURN_ALLOW=maxterutn, CIR_RETURN_LIMIT_ALLOW=cir_return, CIR_NO_OF_CHQBOUNCE=noofchkbounc, CIR_DAYS_CHQBOUNCE=noofdaychkrec, CIR_RETURN_DAYS=retday, CIR_SUP_ORDER_LIMIT=chngsuppord, DISP_BILLING_CRITERIA=disp_bill, CLSD_BILLING_CRITERIA=clas_bill,MAX_PUBLISHDAYS=max_publishday,BILLNO_PERIODICITY=p_billno_period,
   SPECIALDISC_TRANS_EDIT=spl_trans_edit, SHARING_TRANS=spl_dis_trans_editable, MULTIPACKAGE_SEL_TRANS=mul_pac_sel_trans,SCHEME_MINWORD=shmon_minword, TRADE_SPLCHARGE=tradon_spcrg,RATE_AUTHORIZATION=rateauth
  ,F2_RECORD=f2day,PUBLISHAD_EDIT_RATEAUDIT=rateauditmodify,BINDREVENUE_CENTER=bindrevenuecenter,  
  FA_LEDGER_ALLOW=p_led_allow ,CLEARANCE_TYPE_ALLOW=p_clear_allow,REPEAT_DAY_TYPE=repeatday,PREMIUM_EDIT=premiumedit,
BILL_GENERATION_PRIOR=P_BILL_GENERATION,PUBLICATION_HO=P_PUBLICATION_CENTER,SPLDISC_ALLOWPREM=P_allow_discount_prem,

BILL_SCHEME=P_SCHEME_BILLING,ALLOWED_PDC_DAYS_RECEIPT=P_ALLOW_PDC ,AD_TYPE_MANUL_BILL=PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=RO_OUTSTAND_P,GENRATE_CIR_AGCD=genrate_agency_code,DISP_AUDITBKG=p_dispauditbk,CIR_DIS_AUTO_POSTING=p_aotosupply,RELAUTHREQON=p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=p_CIR_UNSOLD_ON_RECEIVED_DT,
AGENCY_UNBLOCK_APPROVAL=p_AGENCY_UNBLOCK_APROV,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=p_UNBLOCK_APROV_OUT_LMT,CIR_BILL_PUBLWISE=p_CIR_BILL_PUBLWISE,
RECORDS_ON_PAGE = p_paging,RECORDS_ON_PRINT = p_print,HEADER_ON_PAGE = p_allowpage,AGENCY_REQUIRED = p_agency_req,REGION_REQUIRED = p_region_req,
ALLOW_FOLLOW_DT_BOOOK=p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=p_CRM_SUPPLY_TYPE_FREE,
CURRENCY_MEASUREMENT=p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM=p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE=p_CANCELLATION_CHARGE,taxi_entry_type=P_taxi_entry_type,APPROVAL_WITH =P_ApprovalWith , TDS_AUTO_CN=p_Auto_TDS_Credit_Note,
TDS_AUTO_REASON=p_TDS_Reason ,TDS_DB_CDP=p_Debit_Account_Head,TDS_CR_CDP=p_credit_Account_Head,SER_TAX_AUTO_CN=p_service_tax_credit_note,SER_TAX_AUTO_REASON=p_Tax_Reason,SER_TAX_DB_CDP=p_Debit_Account_Service_Tax,SER_TAX_CR_CDP=p_Credit_Account_Service_Tax,PKK_AUTO_CN=p_Auto_Patrakar_Credit_Note,PKK_AUTO_REASON=p_Patrakar_Reason ,PKK_DB_CDP=p_Debit_Account_Patrakar,PKK_CR_CDP=p_Credit_Account_Patrakar ,BANK_CHG_AUTO_CN=p_Auto_Bank_Credit_Note ,
BANK_CHG_AUTO_REASON=p_Bank_Reason ,BANK_CHG_DB_CDP=p_Debit_Account_Bank ,BANK_CHG_CR_CDP=p_Credit_Account_Bank ,


CIR_BARCODE=P_BAR_CODE, CIR_WIEGHT_CALC_REQ =P_WEIGHT_CAL, GEN_RCT_TYP =P_GEN_RCT_TYP

  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/
//////////////////////////end of issue 7423///////////

/////////again in 7423////////////

CREATE OR REPLACE PACKAGE HT18JULY.Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/


CREATE OR REPLACE PACKAGE BODY HT18JULY.Currbindpreferpgld
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
                "Receipt_no","uom_code","Bgcolor_publication","chkfor_valid_pubdates","Agency_ratecode","audit","book_insert_date","agencycomm",
                "rate_audit","bill_audit","billtype","Premium_type","copy_booking","RATE_COMPANY_AGENCY","ADDITIONAL_AGENCY_COMM","AGENCY_RETAINER_COMM","SUBEDITIONRATE",CLS_BILLTYPE,DIS_BILLTYPE,
                "BILLING_FORMAT","RATE_CHECK","ALL_PACKAGE",dayrate,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,
                ROKEYCHECK, AGENCYCOMM_SEQ_COM, CREDIT_RECIPT,  DISP_CASHBILL, CLA_CASHBILL,
                RATE_AUDIT_PREF,BARCODING_ALLOWED, FMG_BILL_DIS,BILL_DISP_CASHBILL, BILL_CLA_CASHBILL,BACKDATERECEIPT,ROWISE_CASHBOOKING,CUTOFFTIME,DOCKIT_BOOKING,APPROVAL,BACK_DAYS,CASH_DISCOUNT,CASH_DISCOUNTTYPE,"Allowed_old_date",SEPRATE_CASHIER,
                CIR_MANY_TIME_POSTING, CIR_BACKDAYS_POSTING, CIR_MAX_RETURN_ALLOW, CIR_RETURN_LIMIT_ALLOW, CIR_NO_OF_CHQBOUNCE, CIR_DAYS_CHQBOUNCE, CIR_RETURN_DAYS, CIR_SUP_ORDER_LIMIT, DISP_BILLING_CRITERIA, CLSD_BILLING_CRITERIA,MAX_PUBLISHDAYS,
                BILLNO_PERIODICITY, SPECIALDISC_TRANS_EDIT, SHARING_TRANS, MULTIPACKAGE_SEL_TRANS,SCHEME_MINWORD, TRADE_SPLCHARGE,RATE_AUTHORIZATION,
           F2_RECORD,PUBLISHAD_EDIT_RATEAUDIT,BINDREVENUE_CENTER, FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,REPEAT_DAY_TYPE,PREMIUM_EDIT,
           
           BILL_GENERATION_PRIOR,PUBLICATION_HO,SPLDISC_ALLOWPREM,BILL_SCHEME,ALLOWED_PDC_DAYS_RECEIPT,
           AD_TYPE_MANUL_BILL,OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD,DISP_AUDITBKG,CIR_DIS_AUTO_POSTING,RELAUTHREQON,
        CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,
        AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE ,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,"Space_area",EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE,TAXI_ENTRY_TYPE,APPROVAL_WITH,
      TDS_AUTO_CN,TDS_AUTO_REASON,TDS_DB_CDP,TDS_CR_CDP,SER_TAX_AUTO_CN,SER_TAX_AUTO_REASON,SER_TAX_DB_CDP,SER_TAX_CR_CDP,PKK_AUTO_CN,PKK_AUTO_REASON,PKK_DB_CDP,PKK_CR_CDP,BANK_CHG_AUTO_CN,BANK_CHG_AUTO_REASON,BANK_CHG_DB_CDP,BANK_CHG_CR_CDP,CIR_BARCODE,CIR_WIEGHT_CALC_REQ,GEN_RCT_TYP   
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/
///////////////////////////////end of again 7423////////


////////////////////////issue no 7477/////////////////////////


CREATE OR REPLACE PROCEDURE rpt_approvalro (
   pcompcode     IN       VARCHAR2,
   pcentercode   IN       VARCHAR2,
   pbranch       IN       VARCHAR2,
   puserid       IN       VARCHAR2,
   pfrom_date    IN       VARCHAR2,
   pto_date      IN       VARCHAR2,
   pdateformat   IN       VARCHAR2,
   agency        IN       VARCHAR2,
   executive     IN       VARCHAR2,
   client        IN       VARCHAR2,
   p_accounts    OUT      cur_type_new1.cursor_type
)
IS
   relauthreq            VARCHAR2 (1);
   v_query               VARCHAR (8000);
   v_distcount_allowed   NUMBER (12, 2);
   v_approval_with       VARCHAR2 (1);
   v_login_hr_code       VARCHAR2 (50);
   v_login_exec_team     VARCHAR2 (50);
   v_fromdate            DATE;
   v_todate              DATE;
BEGIN
   v_fromdate := TO_DATE (pfrom_date, '''' || pdateformat || '''');
   v_todate := TO_DATE (pto_date, '''' || pdateformat || '''');

   SELECT relauthreqon, approval_with
     INTO relauthreq, v_approval_with
     FROM preferrences
    WHERE "comp_code" = pcompcode;

   BEGIN
      SELECT TO_NUMBER (NVL (discount, '0')), hr_code
        INTO v_distcount_allowed, v_login_hr_code
        FROM login
       WHERE "userid" = puserid AND TO_NUMBER (NVL (discount, '0')) > 0;
   EXCEPTION
      WHEN NO_DATA_FOUND
      THEN
         v_distcount_allowed := 0;
         v_login_hr_code := NULL;
   END;

   --select "Team_code" into v_login_exec_team from exec_mast where "comp_code"=compcode and hr_code=v_login_hr_code;
   v_query :=
         'SELECT distinct m."Comp_code",(select "Comp_Name" from comp_mst where "Comp_Code"=m."Comp_code") as "COMP_NAME", 
    m."branch" "BRANCH",(select "Branch_Name" from branch_mst where "Branch_Code"=m."branch") "BRANCH_NAME",
    a."Agency_Name" as "AGENCY",(select "City_Name" from city_mst where "City_Code"=a."City_Code") as "CITY_NAME",
    fetch_insert_package('''
      || pcompcode
      || ''',m."cio_booking_id",null,''N'') as "PACKAGE",
    case when '''
      || pdateformat
      || '''=''dd/mm/yyyy'' then to_char(m."date_time",''dd/mm/yy'')
    when '''
      || pdateformat
      || '''=''yyyy/mm/dd'' then to_char(m."date_time",''yy/mm/dd'')
    else to_char(m."date_time",''mm/dd/yy'') end as "BOOKDATE",
    nvl((select "Cust_Name" from cust_mast where "Comp_Code"=m."Comp_code" and "Cust_Code"= m."Client_code"),m."Client_code") as "CLIENT",
    m."RO_No" as "RO_NO",
    case when '''
      || pdateformat
      || '''=''dd/mm/yyyy'' then to_char(m."RO_Date",''dd/mm/yy'')
    when '''
      || pdateformat
      || '''=''yyyy/mm/dd'' then to_char(m."RO_Date",''yy/mm/dd'')
    else to_char(m."RO_Date",''mm/dd/yy'') end as "RODATE",
    (select "Exec_name" from exec_mast where  to_char("Exe_no") = m."Executive_code") as "EXECUTIVE",
    (select "Retain_Name" from retainermaster where "Comp_Code"=m."Comp_code" and "Retain_Code"= m."RETAINER") as "RETAINER",
    m."Card_rate" as "CARD_RATE",Fn_Deviatio(m."Card_rate",m."Agrred_rate")+nvl(m."Special_disc_per",0) as "DEVIATION",m."cio_booking_id" as "CIO_BOOKING_ID",
    m."Bill_amount" as "BILL_AMOUNT",m."Gross_amount" as "GROSS_AMOUNT",
    (select "premiumname" from advpos_prem_mast where "comp_code"=m."Comp_code" and "Premiumcode"=m."Page_prem") as "PAGEPERM",
    m.app_status as "APP_STATUS",m."booked_by" as "BOOKED_BY",
    (select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=m."Comp_code" and "Pay_Mode_Code"=m."Agency_pay") as "PAYMODE",
    m."Ad_cat_code" as "AD_CAT_CODE",(select "Adv_Cat_Name" from adv_cat_mast where "Comp_Code"=m."Comp_code" and "Adv_Cat_Code"=m."Ad_cat_code") as "AD_CAT_NAME",
    m."Color_code" as "COLOR_CODE",(select "Col_Name" from col_mast where "Comp_Code"=m."Comp_code" and "Col_Code"=m."Color_code") as "COLOR_NAME",
    m."Card_amount" as "CARD_AMOUNT",m."Agrred_rate" as "AGRRED_RATE",m."Agreed_amount" as "AGREED_AMOUNT",
    m."Ad_size_height" as "AD_SIZE_HEIGHT",m."Ad_size_width" as "AD_SIZE_WIDTH",(m."Ad_size_height"*m."Ad_size_width") as "SIZE_BOOK",
    to_char(min(i."Insert_Date"),'''
      || pdateformat
      || ''') as "FIRST_INSDATE",to_char(max(i."Insert_Date"),'''
      || pdateformat
      || ''') as "LAST_INSDATE",
    m."Page_no" as "PAGE_NO",l.DISCOUNT as "DISCOUNT_ALLOWED", l."username" as "APPROVAL_BY",
    m.APP_REMARKS "APP_REMARKS",to_char(m."APP_DATE",''dd/mm/yy'') as "APP_DATE",
    (select "Team_code" from exec_mast where to_char("Exe_no") = m."Executive_code") as "TEAM_CODE",
    (select ad_get_exec_teamname(m."Comp_code","Team_code") from exec_mast where to_char("Exe_no") = m."Executive_code") as "TEAM_NAME"
    
        from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,login l
    where m."Comp_code"='''
      || pcompcode
      || ''' and m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode"
    and ((Fn_Deviatio(m."Card_rate",m."Agrred_rate") is not null and Fn_Deviatio(m."Card_rate",m."Agrred_rate") != ''0'') or nvl(m."Special_disc_per",0)>0 OR Fn_chkSalesExec(m."Userid")=''SE0'' OR '''
      || relauthreq
      || ''' = ''A'')
    and m."Agency_sub_code" = nvl('''
      || agency
      || ''',m."Agency_sub_code") and (m."Executive_code" = '''
      || executive
      || '''  OR '''
      || executive
      || ''' IS NULL)
    and (m."Client_code" = '''
      || client
      || '''  OR '''
      || client
      || ''' IS NULL)';
   v_query :=
         v_query
      || ' and m.app_status=''Y'' and to_date(m.APP_DATE) between '''
      || v_fromdate
      || ''' and '''
      || v_todate
      || '''';

   IF pbranch = 'B'
   THEN                   --If B then Data will show Acc. to Branch Permission
      v_query :=
            v_query
         || ' AND m."branch" in(select ltrim(rtrim(branch_code)) from login_branch_mast where user_code='''
         || puserid
         || ''' and comp_code='''
         || pcompcode
         || ''' and user_flag=''Y'')';
   END IF;

   IF NVL (v_approval_with, 'D') = 'T'
   THEN                                            --approval with discounting
      --insert into result(edition_name) select distinct "Team_code" from exec_mast where "comp_code"=pcompcode and hr_code=v_login_hr_code;
      v_query :=
            v_query
         || ' and (nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0))>0 and l."userid"=m.APP_USER';
   /*v_query:=v_query||' and (nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)) between nvl((select max(nvl(discount,''0''))+0.001 from login where hr_code in(select distinct hr_code from exec_mast where "Team_code"
                   in(select distinct "Team_code" from exec_mast,login where exec_mast.hr_code =login.hr_code and login."userid"='''||vusername||''')) and "userid"<>'''||vusername||''' and
                   to_number(nvl(discount,''0''))>0 and to_number(nvl(discount,''0''))<100),1) and (select to_number(nvl(discount,''0'')) from login where "userid"='''||vusername||''') AND
                   r.edition_name =(select distinct "Team_code" from exec_mast where "comp_code"=m."Comp_code" and to_char("Exe_no")=m."Executive_code")';*/
   END IF;

   v_query :=
         v_query
      || ' group by m."Comp_code",a."Agency_Name",m."Package_code",m."date_time", m."Client_code",m."RO_No",m."RO_Date",m."Executive_code",m."RETAINER",
                    m."Card_rate",m."cio_booking_id",m."Bill_amount",m."Gross_amount",m."Page_prem",m.app_status,m."booked_by",m."Agency_pay",
                    m."Receipt_no",m."Ad_cat_code",m."Ad_cat_code",m."Color_code",m."Card_amount",m."Agrred_rate",m."Agreed_amount",
                    m."Ad_size_height",m."Ad_size_width",m.retainer,m."Executive_code",a."City_Code",m."Page_no",nvl(m."Special_disc_per",0),
                    m.APP_USER,m.APP_REMARKS,m.APP_DATE,m."branch", l.DISCOUNT ,l."username"
                    having l.DISCOUNT <(Fn_Deviatio(m."Card_rate",m."Agrred_rate")+nvl(m."Special_disc_per",0))';
   v_query :=
         v_query
      || ' ORDER BY team_name,DEVIATION ASC,bookdate DESC,m."cio_booking_id"';

   DELETE FROM test1;

   INSERT INTO test1
               (vstring, vstring2
               )
        VALUES ('rpt_approvalro ', v_query
               );

   COMMIT;

   OPEN p_accounts FOR v_query;

   DELETE FROM RESULT;

   COMMIT;
END rpt_approvalro;
/
/**************************************************************************************/

CREATE OR REPLACE PROCEDURE getapprovalro_web (
   vusername        IN       VARCHAR2,
   compcode         IN       VARCHAR2,
   agency           IN       VARCHAR2,
   executive        IN       VARCHAR2,
   client           IN       VARCHAR2,
   varfromdate      IN       DATE,
   vartodate        IN       DATE,
   DATEFORMAT       IN       VARCHAR2,
   cioid            IN       VARCHAR2,
   flag             IN       VARCHAR2,
   pbranch          IN       VARCHAR2,
   pdate_based_on   IN       VARCHAR2,     --for Booking date B,Publish Date P
   porder           IN       VARCHAR2,
   --1 for deviation asce ,2 for deviation desc
   p_accounts       OUT      cur_type_new1.cursor_type
)
IS
   relauthreq            VARCHAR2 (1);
   v_query               VARCHAR (8000);
   v_distcount_allowed   NUMBER (12, 2);
   v_approval_with       VARCHAR2 (1);
   v_login_hr_code       VARCHAR2 (50);
   v_login_exec_team     VARCHAR2 (50);
BEGIN
   SELECT relauthreqon, approval_with
     INTO relauthreq, v_approval_with
     FROM preferrences
    WHERE "comp_code" = compcode;

   BEGIN
      SELECT TO_NUMBER (NVL (discount, '0')), hr_code
        INTO v_distcount_allowed, v_login_hr_code
        FROM login
       WHERE "userid" = vusername AND TO_NUMBER (NVL (discount, '0')) > 0;
   EXCEPTION
      WHEN NO_DATA_FOUND
      THEN
         v_distcount_allowed := 0;
         v_login_hr_code := NULL;
   END;

   --select "Team_code" into v_login_exec_team from exec_mast where "comp_code"=compcode and hr_code=v_login_hr_code;
   v_query :=
         'SELECT distinct m."Comp_code",a."Agency_Name" as "AGENCY",(select "City_Name" from city_mst where "City_Code"=a."City_Code") as "CITY_NAME",
    fetch_insert_package('''
      || compcode
      || ''',m."cio_booking_id",null,''N'') as "PACKAGE",
    case when '''
      || DATEFORMAT
      || '''=''dd/mm/yyyy'' then to_char(m."date_time",''dd/mm/yy'')
    when '''
      || DATEFORMAT
      || '''=''yyyy/mm/dd'' then to_char(m."date_time",''yy/mm/dd'')
    else to_char(m."date_time",''mm/dd/yy'') end as "BOOKDATE",
    nvl((select "Cust_Name" from cust_mast where "Comp_Code"=m."Comp_code" and "Cust_Code"= m."Client_code"),m."Client_code") as "CLIENT",
    m."RO_No" as "RO_NO",
    case when '''
      || DATEFORMAT
      || '''=''dd/mm/yyyy'' then to_char(m."RO_Date",''dd/mm/yy'')
    when '''
      || DATEFORMAT
      || '''=''yyyy/mm/dd'' then to_char(m."RO_Date",''yy/mm/dd'')
    else to_char(m."RO_Date",''mm/dd/yy'') end as "RODATE",
    (select "Exec_name" from exec_mast where  to_char("Exe_no") = m."Executive_code") as "EXECUTIVE",
    (select "Retain_Name" from retainermaster where "Comp_Code"=m."Comp_code" and "Retain_Code"= m."RETAINER") as "RETAINER",
    m."Card_rate" as "CARD_RATE",Fn_Deviatio(m."Card_rate",m."Agrred_rate")+nvl(m."Special_disc_per",0) as "DEVIATION",m."cio_booking_id" as "CIO_BOOKING_ID",
    m."Bill_amount" as "BILL_AMOUNT",m."Gross_amount" as "GROSS_AMOUNT",
    (select "premiumname" from advpos_prem_mast where "comp_code"=m."Comp_code" and "Premiumcode"=m."Page_prem") as "PAGEPERM",
    m.app_status as "APP_STATUS",m."booked_by" as "BOOKED_BY",
    (select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=m."Comp_code" and "Pay_Mode_Code"=m."Agency_pay") as "PAYMODE",
    m."Receipt_no" as "RECEIPT_NO",m."Ad_cat_code" as "AD_CAT_CODE",(select "Adv_Cat_Name" from adv_cat_mast where "Comp_Code"=m."Comp_code" and "Adv_Cat_Code"=m."Ad_cat_code") as "AD_CAT_NAME",
    m."Color_code" as "COLOR_CODE",(select "Col_Name" from col_mast where "Comp_Code"=m."Comp_code" and "Col_Code"=m."Color_code") as "COLOR_NAME",
    m."Card_amount" as "CARD_AMOUNT",m."Agrred_rate" as "AGRRED_RATE",m."Agreed_amount" as "AGREED_AMOUNT",
    m."Ad_size_height" as "AD_SIZE_HEIGHT",m."Ad_size_width" as "AD_SIZE_WIDTH",(m."Ad_size_height"*m."Ad_size_width") as "SIZE_BOOK",
    to_char(min(i."Insert_Date"),'''
      || DATEFORMAT
      || ''') as "FIRST_INSDATE",to_char(max(i."Insert_Date"),'''
      || DATEFORMAT
      || ''') as "LAST_INSDATE",m.ATTACHMENT1 as "ATTACHMENT",m."Page_no" as "PAGE_NO"
        from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,result r
    where m."Comp_code"='''
      || compcode
      || ''' and m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode"
    and ((Fn_Deviatio(m."Card_rate",m."Agrred_rate") is not null and Fn_Deviatio(m."Card_rate",m."Agrred_rate") != ''0'') or nvl(m."Special_disc_per",0)>0 OR Fn_chkSalesExec(m."Userid")=''SE0'' OR '''
      || relauthreq
      || ''' = ''A'')
    and m."Agency_sub_code" = nvl('''
      || agency
      || ''',m."Agency_sub_code") and (m."Executive_code" = '''
      || executive
      || '''  OR '''
      || executive
      || ''' IS NULL)
    and (m."Client_code" = '''
      || client
      || '''  OR '''
      || client
      || ''' IS NULL)
    and m."cio_booking_id" = nvl('''
      || cioid
      || ''',m."cio_booking_id" ) ';

   IF flag = 'A'
   THEN                                                         --for Approval
      v_query := v_query || ' and m.app_status=''Y'' ';
   ELSIF flag = 'R'
   THEN                                                        -- for rejected
      v_query := v_query || ' and m.app_status=''N'' ';
   ELSE                                    --pending for approval and rejected
      v_query :=
            v_query
         || ' and nvl(m.app_status,''#'')!=''Y'' and nvl(m.app_status,''#'')!=''N'' ';
   END IF;

   IF pdate_based_on = 'P'
   THEN                                                    --On Published date
      v_query :=
            v_query
         || ' and i."Insert_Date" between '''
         || varfromdate
         || ''' and '''
         || vartodate
         || '''';
   ELSE                                                      --on Booking date
      v_query :=
            v_query
         || ' and m."date_time" between '''
         || varfromdate
         || ''' and '''
         || vartodate
         || '''';
   END IF;

   IF pbranch = 'B'
   THEN                   --If B then Data will show Acc. to Branch Permission
      v_query :=
            v_query
         || ' AND m."branch" in(select ltrim(rtrim(branch_code)) from login_branch_mast where user_code='''
         || vusername
         || ''' and comp_code='''
         || compcode
         || ''' and user_flag=''Y'')';
   END IF;

   IF NVL (v_approval_with, 'D') = 'T'
   THEN                                            --approval with discounting
      INSERT INTO RESULT
                  (edition_name)
         SELECT DISTINCT "Team_code"
                    FROM exec_mast
                   WHERE "comp_code" = compcode AND hr_code = v_login_hr_code;

      v_query :=
            v_query
         || ' and (nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0))>0
            and r.edition_name =(select distinct "Team_code" from exec_mast where "comp_code"=m."Comp_code" and to_char("Exe_no")=m."Executive_code")';
   /*v_query:=v_query||' and (nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)) between nvl((select max(nvl(discount,''0''))+0.001 from login where hr_code in(select distinct hr_code from exec_mast where "Team_code"
                   in(select distinct "Team_code" from exec_mast,login where exec_mast.hr_code =login.hr_code and login."userid"='''||vusername||''')) and "userid"<>'''||vusername||''' and
                   to_number(nvl(discount,''0''))>0 and to_number(nvl(discount,''0''))<100),1) and (select to_number(nvl(discount,''0'')) from login where "userid"='''||vusername||''') AND
                   r.edition_name =(select distinct "Team_code" from exec_mast where "comp_code"=m."Comp_code" and to_char("Exe_no")=m."Executive_code")';*/
   END IF;

   v_query :=
         v_query
      || ' group by m."Comp_code",a."Agency_Name",m."Package_code",m."date_time", m."Client_code",m."RO_No",m."RO_Date",m."Executive_code",m."RETAINER",
                    m."Card_rate",m."cio_booking_id",m."Bill_amount",m."Gross_amount",m."Page_prem",m.app_status,m."booked_by",m."Agency_pay",
                    m."Receipt_no",m."Ad_cat_code",m."Ad_cat_code",m."Color_code",m."Card_amount",m."Agrred_rate",m."Agreed_amount",
                    m."Ad_size_height",m."Ad_size_width",m.retainer,m."Executive_code",a."City_Code",m.ATTACHMENT1,m."Page_no",nvl(m."Special_disc_per",0)';

   IF porder = '1'
   THEN
      v_query :=
         v_query
         || ' ORDER BY DEVIATION ASC,bookdate DESC,m."cio_booking_id"';
   ELSIF porder = '2'
   THEN
      v_query :=
            v_query
         || ' ORDER BY DEVIATION DESC,bookdate DESC,m."cio_booking_id"';
   ELSE
      v_query := v_query || ' ORDER BY bookdate DESC,m."cio_booking_id"';
   END IF;

   DELETE FROM test1;

   INSERT INTO test1
               (vstring, vstring2
               )
        VALUES ('getapprovalRo_web ', v_query
               );

   COMMIT;

   OPEN p_accounts FOR v_query;

/*if flag ='A' then
    open P_Accounts for
    SELECT distinct a."Agency_Name" as "AGENCY",
    (select "Package_Name" from combin_mast where "Comp_Code"=compcode and "Combin_Code"=(
    case when instr('abcdef',',') >0 then substr(m."Package_code",1,instr(m."Package_code",',')-1)
    else m."Package_code" end)) as "PACKAGE",
    case when dateformat='dd/mm/yyyy' then to_char(m."date_time",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."date_time",'yy/mm/dd')
    else to_char(m."date_time",'mm/dd/yy') end as "BOOKDATE",
    (select "Cust_Name" from cust_mast where "Comp_Code"=compcode and "Cust_Code"= m."Client_code") as "CLIENT",
    m."RO_No" as "RO_NO",
    case when dateformat='dd/mm/yyyy' then to_char(m."RO_Date",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."RO_Date",'yy/mm/dd')
    else to_char(m."RO_Date",'mm/dd/yy') end as "RODATE",
    (select "Exec_name" from exec_mast where  to_char("Exe_no") = m."Executive_code") as "EXECUTIVE",
    (select "Retain_Name" from retainermaster where "Comp_Code"=compcode and "Retain_Code"= m."RETAINER") as "RETAINER",
    m."Card_rate" as "CARD_RATE",Fn_Deviatio(m."Card_rate",m."Agrred_rate") as "DEVIATION",m."cio_booking_id" as "CIO_BOOKING_ID",
    m."Bill_amount" as "BILL_AMOUNT",m."Gross_amount" as "GROSS_AMOUNT",
    (select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=m."Page_prem") as "PAGEPERM",
    m.app_status as "APP_STATUS",m."booked_by" as "BOOKED_BY",
    (select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=m."Agency_pay") as "PAYMODE",
    m."Receipt_no" as "RECEIPT_NO",m."Ad_cat_code" as "AD_CAT_CODE",(select "Adv_Cat_Name" from adv_cat_mast where "Comp_Code"=m."Comp_code" and "Adv_Cat_Code"=m."Ad_cat_code") as "AD_CAT_NAME",
    m."Color_code" as "COLOR_CODE", m."Card_amount" as "CARD_AMOUNT",m."Agrred_rate" as "AGRRED_RATE",m."Agreed_amount" as "AGREED_AMOUNT",
    m."Ad_size_height" as "AD_SIZE_HEIGHT",m."Ad_size_width" as "AD_SIZE_WIDTH",(m."Ad_size_height"*m."Ad_size_width") as "SIZE_BOOK",
    min(i."Insert_Date") as "FIRST_INSDATE",max(i."Insert_Date") as "LAST_INSDATE"
        from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
    where m."Comp_code"=compcode and m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
    m."branch"=nvl(pbranch,m."branch") and m.app_status='Y'
    and (Fn_Deviatio(m."Card_rate",m."Agrred_rate") is not null OR Fn_chkSalesExec(m."Userid")='SE0' OR relauthreq = 'A')
    and m."Agency_sub_code" = nvl(agency,m."Agency_sub_code") and (m."Executive_code" = executive  OR executive IS NULL)
    and (m."Client_code" = client  OR client IS NULL) and m."date_time" between varfromdate and vartodate
    and m."cio_booking_id" = nvl(cioid,m."cio_booking_id")
    group by a."Agency_Name",m."Package_code",m."date_time", m."Client_code",m."RO_No",m."RO_Date",m."Executive_code",m."RETAINER",
    m."Card_rate",m."cio_booking_id",m."Bill_amount",m."Gross_amount",m."Page_prem",m.app_status,m."booked_by",m."Agency_pay",
    m."Receipt_no",m."Ad_cat_code",m."Ad_cat_code",m."Color_code",m."Card_amount",m."Agrred_rate",m."Agreed_amount",
    m."Ad_size_height",m."Ad_size_width"
    ORDER BY m."date_time" DESC,m."cio_booking_id";
elsif flag ='R' then
    open P_Accounts for
    SELECT distinct a."Agency_Name" as agency,
    (select "Package_Name" from combin_mast where "Comp_Code"=compcode and "Combin_Code"=(
    case when instr('abcdef',',') >0 then substr(m."Package_code",1,instr(m."Package_code",',')-1)
    else m."Package_code" end)) as Package,
    case when dateformat='dd/mm/yyyy' then to_char(m."date_time",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."date_time",'yy/mm/dd')
    else to_char(m."date_time",'mm/dd/yy') end as bookdate,
    (select "Cust_Name" from cust_mast where "Comp_Code"=compcode and "Cust_Code"= m."Client_code") as client,
    m."RO_No",case when dateformat='dd/mm/yyyy' then to_char(m."RO_Date",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."RO_Date",'yy/mm/dd')
    else to_char(m."RO_Date",'mm/dd/yy') end as rodate,
    (select "Exec_name" from exec_mast where to_char("Exe_no") = m."Executive_code") as executive,
    (select "Retain_Name" from retainermaster where "Comp_Code"=compcode and "Retain_Code"= m."RETAINER") retainer,m."Card_rate" as "Card_rate",
    Fn_Deviatio(m."Card_rate",m."Agrred_rate") as deviation,m."cio_booking_id",m."Bill_amount" as "Bill_amount",m."Gross_amount" as "Gross_amount",
    (select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=m."Page_prem") as PAGEPERM,m.APP_STATUS as "APP_STATUS",m."booked_by" as "booked_by",
    (select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=m."Agency_pay") as "paymode",m."Receipt_no" "Receipt_no"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
    where m."Comp_code"=compcode and m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
    m."branch"=nvl(pbranch,m."branch") and m.app_status='N'
    and (Fn_Deviatio(m."Card_rate",m."Agrred_rate") is not null OR Fn_chkSalesExec(m."Userid")='SE0' OR  RELAUTHREQ = 'A')
    AND (m."Agency_sub_code" = agency  OR agency IS NULL)
    AND (m."Executive_code" = executive  OR executive IS NULL)
    AND (m."Client_code" = client  OR client IS NULL)
    and m."date_time" between varfromdate and vartodate
    AND (m."cio_booking_id" = cioid  OR cioid IS NULL)
    ORDER BY m."date_time" DESC,m."cio_booking_id";
else
    open P_Accounts for
    SELECT distinct a."Agency_Name" as agency,
    (select "Package_Name" from combin_mast where "Comp_Code"=compcode and "Combin_Code"=(
    case when instr('abcdef',',') >0 then substr(m."Package_code",1,instr(m."Package_code",',')-1)
    else m."Package_code" end)) as Package,
    case when dateformat='dd/mm/yyyy' then to_char(m."date_time",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."date_time",'yy/mm/dd')
    else to_char(m."date_time",'mm/dd/yy') end as bookdate,
    (select "Cust_Name" from cust_mast where "Comp_Code"=compcode and "Cust_Code"= m."Client_code") client,m."RO_No" as "RO_No",
    case when dateformat='dd/mm/yyyy' then to_char(m."RO_Date",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."RO_Date",'yy/mm/dd')
    else to_char(m."RO_Date",'mm/dd/yy') end as rodate,
    (select "Exec_name" from exec_mast where "Exe_no" = m."Executive_code") as executive,
    (select "Retain_Name" from retainermaster where "Comp_Code"=compcode and "Retain_Code"= m."RETAINER") retainer,m."Card_rate" as "Card_rate",
    Fn_Deviatio(m."Card_rate",m."Agrred_rate") as deviation,m."cio_booking_id",m."Bill_amount" as "Bill_amount",m."Gross_amount" as "Gross_amount",
    (select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=m."Page_prem") as "PAGEPERM",
    m.APP_STATUS as "APP_STATUS",m."booked_by" as "booked_by",
    (select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=m."Agency_pay") as "paymode",m."Receipt_no" as "Receipt_no"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
    where m."Comp_code"=compcode and m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
    m."branch"=nvl(pbranch,m."branch") and nvl(m.app_status,'#')!='Y' and nvl(m.app_status,'#')!='N'
    and (Fn_Deviatio(m."Card_rate",m."Agrred_rate") is not null OR Fn_chkSalesExec(m."Userid")='SE0' OR  RELAUTHREQ = 'A')
    AND (m."Agency_sub_code" = agency  OR agency IS NULL)
    AND (m."Executive_code" = executive  OR executive IS NULL)
    AND (m."Client_code" = client  OR client IS NULL)
    and m."date_time" between varFromDate and varToDate
    AND (m."cio_booking_id" = cioid  OR cioid IS NULL)
    ORDER BY m."date_time" DESC,m."cio_booking_id" ;
end if;*/
   DELETE FROM RESULT;

   COMMIT;
END getapprovalro_web;
/
//////////////////////////////////////end of issue 7477///////////////////////
/*************************===== Issue no 0007485=========****************************************/
CREATE OR REPLACE PACKAGE Executebookingdisp
IS
  TYPE T_Accounts_Cursor IS REF CURSOR;
  PROCEDURE executebookingdisp_p(
  compcode IN VARCHAR2,
  ciobookid IN VARCHAR2,
  docno IN VARCHAR2:=NULL,
  keyno IN VARCHAR2:=NULL,
  rono IN VARCHAR2:=NULL,
  agencycode IN VARCHAR2:=NULL,
  client IN VARCHAR2:=NULL,
  booking IN VARCHAR2,dateformat IN VARCHAR2,
  revenue in varchar2,
  P_Accounts  OUT  T_Accounts_Cursor,P_Accounts1  OUT  T_Accounts_Cursor,P_Accounts2  OUT  T_Accounts_Cursor,
  P_Accounts3  OUT  T_Accounts_Cursor);
END Executebookingdisp ;
/
CREATE OR REPLACE PACKAGE BODY Executebookingdisp
IS
   PROCEDURE executebookingdisp_p (
      compcode      IN       VARCHAR2,
      ciobookid     IN       VARCHAR2,
      docno         IN       VARCHAR2 := NULL,
      keyno         IN       VARCHAR2 := NULL,
      rono          IN       VARCHAR2 := NULL,
      agencycode    IN       VARCHAR2 := NULL,
      client        IN       VARCHAR2 := NULL,
      booking       IN       VARCHAR2,
      dateformat     IN          VARCHAR2,
      revenue in varchar2,
      p_accounts    OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor,
      p_accounts2   OUT      t_accounts_cursor,
      P_Accounts3  OUT  T_Accounts_Cursor
    
   )
   AS
      VERSION1   NUMBER;
      count1    NUMBER;

   BEGIN

       DELETE FROM TEMPBOOKING_MAST;
        
      INSERT INTO TEMPBOOKING_MAST
         SELECT "date_time", "branch", "booked_by", "cio_booking_id",
                "prev_booking", "applied_by", "audit", "RO_No", "RO_Date",
                "Caption", "bill_status", "ro_status", "Agency_code",
                "Agency_address", "Client_code", "Client_address",
                "Agency_sub_code", "Dockit_no", "Executive_code",
                "Executive_zone", "Product_code", "Brand_code", "Key_no",
                "Bill_remarks", "Print_remark", "Package_code",
                "No_of_insertion", "Insertion_date", "Repeating_day",
                "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code",
                "Color_code", "Uom_code", "Page_position_code",
                "Page_type_code", "Page_no", "Ad_size_type_code",
                "Ad_size_height", "Ad_size_width", "Rate_code",
                "Scheme_type_code", "Currency_code", "Agrred_rate",
                "Agreed_amount", "Special_discount", "Space_discount",
                "Special_charges", "Agency_status", "Agency_type",
                "Agency_pay", "Agency_credit", "Total_area", "Card_rate",
                "Card_amount", "Discount", "Discount_per", "Bill_cycle",
                "Revenue_center", "Bill_pay", "Bill_height", "Bill_width",
                "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc",
                "Agency_out", "Box_code", "Box_no", "Box_agency",
                "Box_client", "Box_address", "Comp_code", "Userid",
                "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad",
                "Campaign", "Bill_amount", "Page_prem", "Page_amount",
                "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column",
                "Bill_area", "Special_disc_per", "Space_disc_per",
                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                "Contract_name", "Contract_type", "Card_name", "Card_type",
                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                "Bullet_code", "Bullet_premium", "Material_status",
                TRUNC("Receipt_date"), "prev_cioid", "prev_receipt",
                "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H",
                "Logo_W", "Logo_color", "Logo_Uom",sapid,RETAINER,"ADD_AGENCY_COMM",MOBILENO,ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,CASH_RECIEVED,
                CIRAGENCY,CIRRATE,CIREDITION,CIRPUBLICATION,CIRAGENCY_SUBCODE,BARTER_TYPE,CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, CHKTRADEDISC,
                CHK_DATE, CHK_AMT, CHK_BANK_NAME, OUR_BANK, CHK_NO,DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT,
                LOCALGROSSAMT,LOCALBILLAMT,PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,APP_USER,CANCELLATION_CHARGE
           FROM TBL_BOOKING_MAST
          WHERE ("Comp_code" = compcode OR compcode IS NULL)
            AND (("cio_booking_id" = ciobookid OR ciobookid IS NULL
                ) OR("Receipt_no"=ciobookid OR ciobookid IS NULL))
            AND ("Dockit_no" = docno  OR docno IS NULL)
            AND ("Key_no" = keyno  OR keyno IS NULL)
            AND ("RO_No" = rono  OR rono IS NULL)
            AND ("Agency_sub_code" LIKE agencycode || '%'
                 OR agencycode IS NULL
                )
            AND ("Client_code" LIKE client || '%' OR client IS NULL)
            AND ("Ad_type_code" = booking  OR booking IS NULL)
            AND "branch" in(SELECT LTRIM(RTRIM(BRANCH_CODE)) FROM LOGIN_BRANCH_MAST WHERE USER_CODE=revenue and COMP_CODE=compcode and USER_FLAG='Y')
         --AND "branch"=revenue 
            ;

  -- Dbms_output.put_line('rinki--');
      OPEN p_accounts FOR
      SELECT CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("date_time",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("date_time",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("date_time",'yyyy/mm/dd')  END AS date_time,
                     "branch",(select "Branch_Name" from branch_mst where "Branch_Code"="branch") as "BRANCH_NAME",
                     "booked_by", "cio_booking_id", "prev_booking", "applied_by","audit", "RO_No",
            CASE dateformat
                 WHEN 'mm/dd/yyyy' THEN TO_CHAR("RO_Date",'mm/dd/yyyy')
                 WHEN 'dd/mm/yyyy' THEN TO_CHAR("RO_Date",'dd/mm/yyyy')
                 WHEN 'yyyy/mm/dd' THEN TO_CHAR("RO_Date",'yyyy/mm/dd')  END AS "RO_Date",
                  TO_CHAR("RO_Date", 'dd/mm/yyyy') AS "RO_Date",
                "Caption", "bill_status", "ro_status", "Agency_code",
                "Agency_address", "Client_code", "Client_address",
                "Agency_sub_code", "Dockit_no", "Executive_code",
                "Executive_zone", "Product_code", "Brand_code", "Key_no",
                "Bill_remarks", "Print_remark", "Package_code","No_of_insertion",
            CASE dateformat
                    WHEN 'mm/dd/yyyy' THEN TO_CHAR("Insertion_date",'mm/dd/yyyy')
                    WHEN 'dd/mm/yyyy' THEN TO_CHAR("Insertion_date",'dd/mm/yyyy')
                    WHEN 'yyyy/mm/dd' THEN TO_CHAR("Insertion_date",'yyyy/mm/dd')  END    AS "Insertion_date",
                "Repeating_day", "Ad_type_code", "Ad_cat_code",
                "Ad_sub_cat_code", "Color_code", "Uom_code",
                "Page_position_code", "Page_type_code", "Page_no",
                "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code",
                (SELECT "Scheme_Name" FROM SCHEME_MASTER WHERE "Comp_code"=compcode and "scheme_id" =TEMPBOOKING_MAST."Scheme_type_code" and "date_time" between "Valid_From" and "Valid_To")AS "Scheme_type_code",
                 "Currency_code", "Agrred_rate", "Agreed_amount",
                "Special_discount", "Space_discount", "Special_charges",
                TEMPBOOKING_MAST."Comp_code", TEMPBOOKING_MAST."Userid",
                TEMPBOOKING_MAST."Agency_status", "Agency_type", "Agency_pay",
                "Agency_credit", "Total_area", "Card_rate", "Card_amount",
                "Discount", "Discount_per", "Bill_cycle", "Revenue_center",
                "Bill_pay", "Bill_height", "Bill_width",
                TEMPBOOKING_MAST."Bill_to", "Invoices", "Vts", "Bill_add",
                "Trade_disc", "Agency_out", "Booking_type", "Campaign",
                "Page_prem", "Page_amount", "Prem_per", "Gross_amount",
                "Bill_amount", "Box_code", "Box_no", "Box_agency",
                "Box_client", "Box_address", "Tfn", "Coupan_ad",
                "Ad_size_column", "Bill_column", "Bill_area",
                "Special_disc_per", "Space_disc_per",
                AGENCY_MAST."Agency_Name" || '(' || AGENCY_MAST."code_subcode" || ')' AS "AgencyName",
                (SELECT EXEC_MAST."Exec_name" || '(' || TO_CHAR(EXEC_MAST."Exe_no") || ')' FROM EXEC_MAST
                  WHERE TEMPBOOKING_MAST."Executive_code" = EXEC_MAST."Exe_no"
                    AND TEMPBOOKING_MAST."Comp_code" = EXEC_MAST."comp_code" and TEMPBOOKING_MAST."Comp_code"=compcode) AS "execname",
                    --91
                (SELECT  PRODUCT_CAT_MAST."prod_desc" || '(' || PRODUCT_CAT_MAST."prod_cat_code" || ')' FROM PRODUCT_CAT_MAST
                  WHERE TEMPBOOKING_MAST."Product_code" = PRODUCT_CAT_MAST."prod_cat_code"
                    AND TEMPBOOKING_MAST."Comp_code" = PRODUCT_CAT_MAST."comp_code" and TEMPBOOKING_MAST."Comp_code"=compcode) AS "product",
                    --92
                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                 (select "deal_name" from contract_mast where "Deal_No"= 
                 (select "deal_code" from contract_detail where to_char("ContractCode")= to_char("Contract_name"))) as "Contract_name", "Contract_type", "Card_name", "Card_type",
                --100
                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                "Bullet_code", "Bullet_premium",
                (SELECT "Agency_Name" FROM AGENCY_MAST WHERE "code_subcode" =TEMPBOOKING_MAST."Agency_sub_code" and agency_mast."Comp_Code"=compcode) AS "AgencySubCode",
              --111
                NVL ((SELECT DISTINCT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code" = "Client_code" and "Comp_Code"=compcode), '') AS "Client",                                       --112
                (SELECT DISTINCT "Payment_Mode_Name" FROM PAYMENT_MODE_MAST WHERE "Pay_Mode_Code" = "Agency_pay" and "Comp_Code"=compcode) AS "PayMode",
                (SELECT DISTINCT "Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code" =TEMPBOOKING_MAST."Ad_cat_code" and "Comp_Code"=compcode) AS "categoryname",
                (SELECT DISTINCT "Adv_Subcat_Name" FROM ADV_SUBCAT_MAST  WHERE ADV_SUBCAT_MAST."Adv_Subcat_Code" =TEMPBOOKING_MAST."Ad_sub_cat_code" and "Comp_Code"=compcode)
                 AS "subcategoryname",
                (SELECT DISTINCT "brand_name" FROM BRAND_MST WHERE "brand_code" =TEMPBOOKING_MAST."Brand_code" and "comp_code"=compcode) AS "Brand",
                (SELECT DISTINCT "Uom_Name" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST."Uom_code" and "Comp_Code"=compcode) AS "UOM",
                (SELECT "premiumname" FROM ADVPOS_PREM_MAST WHERE "Premiumcode" =TEMPBOOKING_MAST."Page_prem" and "comp_code"=compcode) AS "PagePremium",
                 (SELECT DISTINCT "Pos_Type" FROM ADVPOS_TYPE_MAST
                  WHERE "Pos_Type_Code" = TEMPBOOKING_MAST."Page_position_code" and "Comp_Code"=compcode) AS "PositionPremium",
                (SELECT DISTINCT "Curr_Name" FROM CURR_MAST WHERE "Curr_Code" = TEMPBOOKING_MAST."Currency_code" and "Comp_Code"=compcode) AS "Currency",
                "Material_status", TO_CHAR("Receipt_date",'dd/mm/yyyy') AS "Receipt_date", TEMPBOOKING_MAST."Region",
                "Variant", "Colortype",
                (SELECT DISTINCT "UOM_DESC" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST."Uom_code" and "Comp_Code"=compcode) AS "uom_desc",
                (SELECT DISTINCT "Logo" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST."Uom_code" and "Comp_Code"=compcode) AS "logo","Logo_H", "Logo_W", "Logo_color", "Logo_Uom",
                (SELECT DISTINCT "Logo_Uom" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST."Uom_code" and "Comp_Code"=compcode)  AS "logocode",
                (SELECT DISTINCT "Box_Charges_Native" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING_MAST."Box_code" and "Comp_Code"=compcode) AS "boxchrg",TEMPBOOKING_MAST.sapid,
                retainer,(SELECT "Retain_Name"||'('||"Retain_Code"||')' FROM RETAINERMASTER WHERE RETAINERMASTER."Retain_Code"=TEMPBOOKING_MAST.RETAINER and "Comp_Code"=compcode) AS "RETAINER1",
                (SELECT DISTINCT "Package_Name" FROM combin_mast WHERE "Combin_Code" =

                TEMPBOOKING_MAST."Package_code" and "Comp_Code"=compcode) as "Package_cod",(SELECT DISTINCT "Col_Name" FROM col_mast WHERE "Col_Code" = TEMPBOOKING_MAST."Color_code" and "Comp_Code"=compcode) as

                "Color_cod",(SELECT DISTINCT "Pos_Type" FROM advpos_type_mast WHERE "Pos_Type_Code" =

                TEMPBOOKING_MAST."Page_position_code" and "Comp_Code"=compcode) as "Page_position_cod",
                decode(TEMPBOOKING_MAST."Booking_type",'1','BARTER','2','FMG','3','NORMAL','4','INHOUSE') as "Book_type",
                (SELECT DISTINCT "catname"  FROM  AD_CAT3   WHERE

                AD_CAT3."catcode"=TEMPBOOKING_MAST."Ad_Subcat3" and "compcode"=compcode)  as "Subcat3",(SELECT DISTINCT "Cat_Name"  FROM  TBL_CAT4   WHERE

                TBL_CAT4."Cat_Code"=TEMPBOOKING_MAST."Ad_Subcat4" and "Comp_Code"=compcode) as "Subcat4",(SELECT DISTINCT "Cat_Name"  FROM  TBL_CAT5   WHERE

                TBL_CAT5."Cat_Code"=TEMPBOOKING_MAST."Ad_subcat5" and "Comp_Code"=compcode) as "subcat5",(SELECT DISTINCT "Comm_Rate" FROM ret_comm_details WHERE

                ret_comm_details."Retain_Code"=TEMPBOOKING_MAST.RETAINER and "Comp_code"=compcode and rowid=(select max(rowid) from ret_comm_details where ret_comm_details."Retain_Code"=TEMPBOOKING_MAST.RETAINER and "Comp_code"=compcode)) AS "RETAINER_COMM",(select AUDIT_COMMENT from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=TEMPBOOKING_MAST."cio_booking_id" and tbl_booking_mast."Comp_code"=compcode) as "remarks","ADD_AGENCY_COMM",
                 (SELECT DISTINCT "Box_Charges_Type" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING_MAST."Box_code" and "Comp_code"=compcode) AS "boxchargetype",
                 ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,TEMPBOOKING_MAST."Scheme_type_code" as "SCHEMEID",TEMPBOOKING_MAST.CASH_RECIEVED,
                 (select DISTINCT "pub_center" from branch_mst where "Branch_Code"=tempbooking_mast."branch" and "Comp_Code"=compcode) as "pub_center",
                  CIRAGENCY,CIRRATE,CIREDITION,CIRPUBLICATION,CIRAGENCY_SUBCODE,BARTERTYPE,(SELECT BARTE_DESC FROM AD_BARTER WHERE COMP_CODE=compcode AND BARTER_CODE=TEMPBOOKING_MAST.BARTERTYPE) AS BARTE_DESC,
                  (SELECT DISTINCT BARTER_AMOUNT FROM AD_BARTER WHERE COMP_CODE=compcode AND  BARTER_CODE=TEMPBOOKING_MAST.BARTERTYPE) AS BARTE_AMOUNT,
                  (SELECT DISTINCT ADDITIONAL_FLAG  FROM COMM_DETAILS WHERE "Agency_code"||"Agency_sub_code"=TEMPBOOKING_MAST."Agency_sub_code"
                 and "Comp_Code"=upper(compcode) and SYSDATE between "Eff_from_Date" and "Eff_Till_Date" AND ROWNUM<=1) AS ADDFLAG,
                  CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, CHKTRADE, CASE dateformat
                                     WHEN 'mm/dd/yyyy' THEN TO_CHAR(CHK_DATE,'mm/dd/yyyy')
                                  WHEN 'dd/mm/yyyy' THEN TO_CHAR(CHK_DATE,'dd/mm/yyyy')
                                     WHEN 'yyyy/mm/dd' THEN TO_CHAR(CHK_DATE,'yyyy/mm/dd')  END as CHK_DATE, CHK_AMT, CHK_BANK_NAME, OUR_BANK, CHK_NO, agency_mast.BOOKING_TYPE,
                                     DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,MOBILENO,
                                     (select "Comm_Rate" from comm_details where "Agency_code" || "Agency_sub_code"=TEMPBOOKING_MAST."Agency_sub_code"
                 and "Comp_Code"=upper(compcode) and SYSDATE between "Eff_from_Date" and "Eff_Till_Date" AND ROWNUM<=1 ) as COMM_RATE,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT, NVL(LOCALGROSSAMT,"Gross_amount") as LOCALGROSSAMT, NVL(LOCALBILLAMT,"Bill_amount") as LOCALBILLAMT, RECEIPT_CURRENCY, CONV_CURR_RATE,
                 CASE dateformat
                         WHEN 'mm/dd/yyyy' THEN TO_CHAR("REVISE_DATE",'mm/dd/yyyy')
                         WHEN 'dd/mm/yyyy' THEN TO_CHAR("REVISE_DATE",'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd' THEN TO_CHAR("REVISE_DATE",'yyyy/mm/dd')  END AS "REVISE_DATE",CLIENT_TYPE,
                         
                         CASE dateformat
                         WHEN 'mm/dd/yyyy' THEN TO_CHAR("Creation_datetime",'mm/dd/yyyy hh:mi:ss')
                         WHEN 'dd/mm/yyyy' THEN TO_CHAR("Creation_datetime",'dd/mm/yyyy hh:mi:ss')
                         WHEN 'yyyy/mm/dd' THEN TO_CHAR("Creation_datetime",'yyyy/mm/dd hh:mi:ss') END                        
                          as CREATION_DATETIME,TRANSLATION_CODE, TRANSLATION_PREMIUM,
                          (SELECT CHARGES_TYPE FROM  AD_CHARGE_MAST WHERE AD_CHARGE_MAST.CHARGE_CODE=TEMPBOOKING_MAST.TRANSLATION_CODE and COMP_CODE=compcode) AS TRANSLATION_TYPE,
                          (SELECT "username" FROM  LOGIN WHERE LOGIN."userid"=TEMPBOOKING_MAST.APP_USER and LOGIN.COM_CODE=compcode) as APP_USER,CANCELLATION_CHARGE
/*for Display and classified*/
           FROM TEMPBOOKING_MAST, AGENCY_MAST
          WHERE AGENCY_MAST."code_subcode" =
                                            TEMPBOOKING_MAST."Agency_sub_code"
            AND AGENCY_MAST."Comp_Code" = compcode ORDER BY "Creation_datetime";


      Dbms_output.put_line('rinki--');
----------------------------------------------------Lata------------------------------------------------------

      OPEN p_accounts1 FOR
      SELECT 'A' AS A FROM DUAL;
    
      OPEN p_accounts2 FOR
      SELECT 'A' AS A FROM DUAL;
    
   END executebookingdisp_p;
END Executebookingdisp;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE BODY bindratecode
IS


PROCEDURE  bindratecode_p(


compcode in varchar2,
adcat1 in  varchar2,
p_Accounts out T_Accounts_Cursor,
p_Accounts1 out T_Accounts_Cursor

)as
begin

if(adcat1='contract')then
Open p_Accounts for
select  distinct  "Rate_Mast_Code" AS "rate_mast_code" from   rate_mast  where "Comp_code"= compcode and sysdate between "Valid_From" and "Valid_To" order by "Rate_Mast_Code";

Open p_Accounts1 For
 select "Bullet_Code","Bullet_Desc" from bullet_mast where "Comp_Code"=compcode and to_date(sysdate) between "Validity_From_Date" and nvl("Validity_Till_Date",to_date(sysdate)) 
 and "Adv_Cat_Code" like '%' || adcat1 || '%'  order by "Bullet_Desc";
else
Open p_Accounts for
select  distinct  "Rate_Mast_Code" AS "rate_mast_code" from  rate_mast  where ("Comp_code"= compcode ) and ("Adv_Cat_Code"= adcat1) and sysdate between "Valid_From" and "Valid_To" order by "Rate_Mast_Code";

Open p_Accounts1 For
 select "Bullet_Code","Bullet_Desc" from bullet_mast where "Comp_Code"=compcode and to_date(sysdate) between "Validity_From_Date" and nvl("Validity_Till_Date",to_date(sysdate)) and "Adv_Cat_Code" like '%' || adcat1 || '%'  order by "Bullet_Desc";
end if;


End bindratecode_p;

End bindratecode;
/

/*************************===== end of issue 0007485 =========****************************************/


================6791=======avinash========start===================
CREATE OR REPLACE PROCEDURE HT18JULY.reportnew1 (
   agname          IN       VARCHAR2 := NULL,
   clientname      IN       VARCHAR2 := NULL,
   adtype1         IN       VARCHAR2,
   adcategory      IN       VARCHAR2,
   adsubcategory   IN       VARCHAR2,
   fromdate        IN       VARCHAR2,
   dateto          IN       VARCHAR2,
   compcode        IN       VARCHAR2,
   pub_name        IN       VARCHAR2,
   pub_cent        IN       VARCHAR2,
   status          IN       VARCHAR2 := NULL,
   edition         IN       VARCHAR2,
   DATEFORMAT      IN       VARCHAR2,
   hold            IN       VARCHAR2 := NULL,
   descid          IN       VARCHAR2 := NULL,
   ascdesc         IN       VARCHAR2 := NULL,
   agtype          IN       VARCHAR2 := NULL,
   puserid         IN       VARCHAR2 := NULL,
   chk_access      IN       VARCHAR2 := NULL,
   pbranch         IN       VARCHAR2 := NULL,
   pprint_center   IN       VARCHAR2 := NULL,
   pwithout_rono   IN       VARCHAR2 := NULL,
                          --it is for without agency ro no. list Y or N or All
   pdate_flag      IN       VARCHAR2 := NULL,
                             --it is used for booking date B or publish date P
   pextra1         IN       VARCHAR2 := NULL,
   pextra2         IN       VARCHAR2 := NULL,
   pextra3         IN       VARCHAR2 := NULL,
   pextra4         IN       VARCHAR2 := NULL,
   pextra5         IN       VARCHAR2 := NULL,
   p_reportnew     OUT      cur_type_new1.cursor_type
)
IS
   center      VARCHAR (50);
   from_date   DATE;
   date_to     DATE;
   v_query     VARCHAR (8000);
   a           NUMBER;
BEGIN
   v_query :=
         ' SELECT m."cio_booking_id" AS "CIOID",i."Edition" as "edition",
    CASE '''
      || DATEFORMAT
      || '''WHEN ''mm/dd/yyyy'' THEN TO_CHAR(i."Insert_Date",''mm/dd/yyyy'')
    WHEN ''dd/mm/yyyy'' THEN TO_CHAR(i."Insert_Date",''dd/mm/yyyy'')
    WHEN ''yyyy/mm/dd'' THEN TO_CHAR(i."Insert_Date",''yyyy/mm/dd'')  END AS "Ins.date" ,
    a."Agency_Name" AS "Agency",
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
    /*(select COMBIN_MAST."Package_Name" from combin_mast where COMBIN_MAST."Combin_Code"  in(m."Package_code"))AS "Package",*/
    case when instr(m."Package_code",'','') >0 then 
        FETCH_PACK_new('''
      || compcode
      || ''', m."Package_code" ) 
    else
        (select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=m."Package_code")
    end AS "Package",
    i."Height" AS "Depth",i."Width"   AS "Width",round(i."Size_Book",2) AS "Area",
    (select uom_mast.UOM_DESC from uom_mast where m."Uom_code"=uom_mast."Uom_Code")as "uom",i."Col_Code" AS "Color_code",
    (SELECT ADVPOS_TYPE_MAST."Pos_Type_Alias" FROM ADVPOS_TYPE_MAST WHERE i."Page_Post"=ADVPOS_TYPE_MAST."Pos_Type_Code") AS "Page",
    m."Bullet_code" AS "BulletPremium" ,i."Page_Post" AS "PositionPremium" ,i."Premium1" AS "PagePremium" ,
    m."RO_No" AS "RoNo.",CASE m."ro_status" WHEN ''2'' THEN ''Reservation'' WHEN ''1'' THEN ''Confirm'' END AS "RoStatus",
    (SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=i."Ad_Cat") AS "AdCat",
    m."Card_rate" AS "CardRate",NVL("Agrred_rate",0) AS "AgreedRate",i."Bill_Amt" AS "Amt",m."Caption" AS "Cap",m."Key_no" AS "Key",
    (SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''
      || compcode
      || ''') AS "companyname",
    sysdate as "Rundate",
    m.CASHDISCOUNT as "Cash_Disc", m."AUDIT_COMMENT" as "COMMENT",m."Dockit_no" as "DOCKIT_NO"
    FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a
    WHERE m."Comp_code"='''
      || compcode
      || '''
    AND m."cio_booking_id"=i."Cio_Booking_Id"
    AND m."Agency_code"=a."Agency_Code"
    and m."Agency_sub_code"=a."code_subcode"
    AND m."cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
    and  lower(i."Insert_Status") !=''cancel''
    and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where  newuser_id='''
      || puserid
      || ''') and '''
      || chk_access
      || '''=''1'')
    or  ('''
      || chk_access
      || '''=''0'') )';

/*
IF(hold IS NOT NULL)THEN
v_query:=v_query||' and m."Insert_Status"!='''||'Cancel'||'''';

END IF;
*/

 IF (pextra2 IS NOT NULL )
   THEN
      v_query := v_query || ' and m."cio_booking_id" =''' || pextra2 || '''';
   END IF;

   IF (agname IS NOT NULL)
   THEN
      v_query := v_query || ' and m."Agency_code" =''' || agname || '''';
   END IF;

   IF (clientname IS NOT NULL)
   THEN
      v_query := v_query || ' and m."Client_code"=''' || clientname || '''';
   END IF;

   IF (status IS NOT NULL)
   THEN
      v_query := v_query || ' and i."Insert_Status"=''' || status || '''';
   END IF;

   IF (adtype1 IS NOT NULL)
   THEN
      v_query := v_query || ' and m."Ad_type_code"=''' || adtype1 || '''';
   END IF;

   IF (adcategory IS NOT NULL)
   THEN
      a := fn_splitfield (adcategory, ',');
      --v_query:=v_query||' and m."Ad_cat_code" in('''||Adcategory||''' )';
      v_query :=
         v_query || ' and i."Ad_Cat" in(select "EDITION_NAME" from result  )';
   END IF;

   IF (adsubcategory IS NOT NULL)
   THEN
      a := fn_splitfield_new (adsubcategory, ',');
      v_query :=
            v_query
         || ' and m."Ad_sub_cat_code" in(select "EDITION_NAME" from result_new where sess_id='
         || USERENV ('sessionid')
         || ' )';
   END IF;

   IF (pub_cent IS NOT NULL)
   THEN
      v_query := v_query || '  and i."Pub_Cent_Code"=''' || pub_cent || '''';
   END IF;

   IF pdate_flag = 'B'
   THEN
   IF(pextra2 ='') 
   THEN
      IF (fromdate IS NOT NULL AND dateto IS NULL)
      THEN
         v_query := v_query || ' and m."date_time" =''' || fromdate || '''';
      END IF;

      IF (fromdate IS NOT NULL AND dateto IS NOT NULL)
      THEN
         v_query :=
               v_query
            || ' and m."date_time" between  '''
            || fromdate
            || ''' and  '''
            || dateto
            || ''' ';
      END IF;
      end IF;
   ELSE
   IF(pextra2 ='') 
   THEN
      IF (fromdate IS NOT NULL AND dateto IS NULL)
      THEN
         v_query := v_query || ' and i."Insert_Date" =''' || fromdate || '''';
      END IF;

      IF (fromdate IS NOT NULL AND dateto IS NOT NULL)
      THEN
         v_query :=
               v_query
            || ' and i."Insert_Date" between  '''
            || fromdate
            || ''' and  '''
            || dateto
            || ''' ';
      END IF;
      END IF;
   END IF;

   IF (edition IS NOT NULL)
   THEN
      v_query := v_query || '  and i."Edition_Code"=''' || edition || '''';
   END IF;

   IF (pextra1 IS NOT NULL)
   THEN
      v_query := v_query || '  and m."Uom_code"=''' || pextra1 || '''';
   END IF;

   IF (pub_name IS NOT NULL)
   THEN
      v_query :=
               v_query || ' and  i."Publication_Code"=''' || pub_name || '''';
   END IF;

   IF ((agtype IS NOT NULL) AND (agtype <> 'Package') AND (agtype <> 'Solo'))
   THEN
      v_query :=
               v_query || ' and  m."Agency_type"=''' || UPPER (agtype)
               || '''';
   END IF;

   IF (pprint_center IS NOT NULL)
   THEN
      v_query :=
            v_query
         || ' and m."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE m."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''
         || pprint_center
         || ''')) ';
   END IF;

   IF (pbranch IS NOT NULL)
   THEN
      v_query := v_query || ' and m."branch" = ''' || pbranch || ''' ';
   END IF;

   IF pwithout_rono = 'Y'
   THEN
      v_query := v_query || ' and (m."RO_No" is null or m."RO_No"='''') ';
   END IF;

   IF pwithout_rono = 'N'
   THEN
      v_query :=
                v_query || ' and (m."RO_No" is not null or m."RO_No"<>'''') ';
   END IF;

   IF (descid IS NOT NULL)
   THEN
      v_query := v_query || '  order by "' || descid || '"';
      v_query := v_query || '' || ascdesc || '';
   ELSE
      v_query := v_query || '  order by i."Insert_Date",m."cio_booking_id"';
   END IF;

--delete from searchtbl;insert into searchtbl values(v_query);commit;
   OPEN p_reportnew FOR v_query;
END reportnew1;
/

=============end====6791===avinash=======================================

=============start====7468===avinash=======================================

CREATE OR REPLACE PROCEDURE pub_Reportnew(
agname          IN VARCHAR2:= NULL,
Adtype          IN VARCHAR2:= NULL,
fromdate        IN VARCHAR2:= NULL,
dateto          IN VARCHAR2:= NULL,
compcode        IN VARCHAR2:= NULL,
pub_cent        IN VARCHAR2:= NULL,
category        IN VARCHAR2:= NULL,
edition         IN VARCHAR2:= NULL,
dateformat      IN VARCHAR2:= NULL,
Region          IN VARCHAR2:= NULL,
product         IN VARCHAR2:= NULL,
agency          IN VARCHAR2:= NULL,
descid          IN VARCHAR2:= NULL,
ascdesc         IN VARCHAR2:= NULL,
agcat           IN VARCHAR2:= NULL,
adcheck         IN VARCHAR2:= NULL,
executive       IN VARCHAR2:= NULL,
puserid         IN VARCHAR2,
chk_access      IN VARCHAR2:= NULL,
pstatecode      IN VARCHAR2:= NULL,
pdistcode       IN VARCHAR2:= NULL,
p_recordset1    OUT Cur_Type_New1.cursor_type)

IS
query1 VARCHAR2(10000);
grpnew VARCHAR2(100);
grpne VARCHAR2(100);
grpst VARCHAR2(100);

prefer     VARCHAR(10);
v_frdt     date;     
v_todt     date;
BEGIN
    v_frdt  :=to_date(fromdate,''''||dateformat||'''');
    v_todt  :=to_date(dateto,''''||dateformat||'''');

select distinct  AGENCY_RETAINER_COMM into prefer from preferrences where "comp_code"=compcode;

if(adcheck=1) then
query1:='SELECT distinct m."cio_booking_id" AS "CIOID",
a."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
p."Pub_Name" AS "Publication",
round(m."Total_area",2) AS "Area",
--round(i."Size_Book",2 )  AS "Area",
(SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE m."Revenue_center" =BRANCH_MST."Branch_Code" )AS "RevenueCenter",
m."Rate_code" as "Rate",
m."Page_prem" as "Premium",
--i."Premium1" as "Premium",
m."Bill_remarks" as "BillRemark",
m."Color_code" as "Color",
--i."Col_Code"  as "Color",
m."Ad_cat_code"  as "Category",
m."Ad_sub_cat_code" as "SubCategory",
m."Package_code" as "Package",
nvl(m."Agrred_rate",m."Card_rate" ) AS "AgreedRate",
m."Bill_amount" AS "BillAmt",
m."Trade_disc" as "AgencyComm",
m."ADD_AGENCY_COMM" as "AddlAgencyTD",
(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
sysdate as "Rundate"
,m."Booking_type" as "booktype"
,i.BILL_NO as "Bill_No"
,to_char(i.BILL_DATE,'||''''||dateformat||''''||') as "Bill_Date"

/*,m."Agency_address" AS "A_Place"
,m."Client_address" AS "C_Place"
,u."Uom_Name"  AS "Uom"
,m."Page_no" as "Page_no"
,m."Card_rate" as "Card_Rate"
,m."Discount_per" as Discper
,m."Special_disc_per" as Spdiscper
,m."Space_disc_per" as Spacediscper
,m."Special_charges" as Specialcharge
,nvl((m."Bill_amount"-nvl(fun_actual('''||compcode ||''',nvl(m."ADD_AGENCY_COMM",''0'' ),nvl(m."RETAINER",''0''),nvl(m."Gross_amount",''0''),'''||prefer||''',''2'' ),''0'')  ),''0'') as ActualBusiness
*/
,m.CASHDISCOUNT as "Cash_Disc"

FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a,PUB_MAST p,uom_mast u
WHERE m."Comp_code"='''||compcode||''' AND
u."Uom_Code"=m."Uom_code"  and
m."cio_booking_id"=i."Cio_Booking_Id" AND
m."Agency_sub_code"=a."code_subcode" AND  
i."Publication_Code" = p."Pub_Code"
AND not exists(select ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
and  lower(i."Insert_Status") not in (''cancel'',''hold'')
and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')or  ('''||chk_access||'''=''0'') )';


IF(agname IS NOT NULL) THEN
    query1:=query1 ||' AND m."Agency_code" ='''||agname ||'''';
END IF;

IF(Adtype IS NOT NULL) THEN
    query1:=query1 || ' and m."Ad_type_code"='''||Adtype||'''';
END IF;

IF(pub_cent IS NOT NULL) THEN
    query1:=query1||'  and i."Pub_Cent_Code"='''||pub_cent||'''';
END IF;

IF(fromdate IS NOT NULL AND dateto IS NULL ) THEN
    query1:=query1||' and i."Insert_Date" ='''||v_frdt||'''';
END IF;

IF(fromdate IS NOT NULL AND dateto IS NOT NULL ) THEN
    query1:=query1||' and i."Insert_Date" between  '''||v_frdt ||''' and  '''||v_todt||''' ';
END IF;

IF(edition IS NOT NULL) THEN
    query1:=query1||'  and i."Edition_Code"='''||edition||'''';
END IF;

IF((category IS NOT NULL) AND (category <> 'Package') AND (category <> 'Solo')) THEN
    query1:=query1||' and  m."Agency_type"='''||upper(category)||'''';
END IF;

IF(product IS NOT NULL) THEN
    query1:=query1||' and i."Publication_Code"='''||product||'''';
END IF;

IF(Region IS NOT NULL)
THEN
query1:=query1 ||' and i."Pub_Cent_Code" in(select pub_cent_mast."Pub_cent_Code" from pub_cent_mast where pub_cent_mast."Region_code" ='''||Region ||''')';
END IF;


IF(agcat IS NOT NULL)
THEN
query1:=query1 ||' AND m."Agency_code" =a."code_subcode" and a."Agency_Cat_Code"='''||agcat ||'''';
END IF;

IF(executive IS NOT NULL)
THEN
query1:=query1 ||' AND m."Executive_code" ='''||executive ||'''';
END IF;

IF(pstatecode IS NOT NULL)
THEN
query1:=query1 ||' AND a.state ='''||pstatecode ||'''';
END IF;

IF(pdistcode IS NOT NULL)
THEN
query1:=query1 ||' AND a.district ='''||pdistcode ||'''';
END IF;


IF(descid IS NOT  NULL)
THEN
query1:=query1||'  ORDER BY "'||descid||'"';
query1:=query1||''||ascdesc||'';
else
query1:=query1||' order by m."cio_booking_id"';

END IF;
DELETE FROM SEARCHTBL;insert into searchtbl values(query1);commit;

OPEN p_recordset1 FOR query1;

end if;

if(adcheck=2) then

query1:='SELECT b.IDNUM AS "CIOID",
a."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=d."CLIENTCD"),d."CLIENTCD")  AS "Client",
p."Pub_Name" AS "Publication",
round(d."SIZE_BOOK",2) AS "Area",
(SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE b.REVENUE_CENTER =BRANCH_MST."Branch_Code" )AS "RevenueCenter",
d.RATECD as "Rate",
b."SPPREMIUM" as "Premium",
b."BILL_RMRK" as "BillRemark",
b."COLOUR" as "Color",
d.PRIADCTG  as "Category",
d.SECADCTG as "SubCategory",
d."PACKAGE_CODE" as "Package",
(select nvl(tbl_booking_mast."Agrred_rate",tbl_booking_mast."Card_rate" ) from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=b.IDNUM)AS "AgreedRate",
SUM(ROUND(d.BILL_AMT)) AS "BillAmt",
nvl(b.DISCOUNT ,''0'' ) as "AgencyComm",
nvl((select tbl_booking_mast."ADD_AGENCY_COMM" from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=b.IDNUM),''0'') as "AddlAgencyTD", 
(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
sysdate as "Rundate"
,(select tbl_booking_mast."Booking_type" from tbl_booking_mast where b.IDNUM=tbl_booking_mast."cio_booking_id" ) as "booktype"
,d.BILNO as "Bill_No"
,to_char(d.BILDT,'||''''||dateformat||''''||') as "Bill_Date",
b.GROSS_AMT,b.BOXCHRG,b.AGCOMM


/*,a."Add1" AS "A_Place"
,(select cust_mast."Add1" from cust_mast where d."CLIENTCD"=cust_mast."Cust_Code") AS "C_Place"
,(select UOM_MAST."Uom_Name" from uom_mast where  uom_mast."Uom_Code" in(select tbl_booking_mast."Uom_code" from tbl_booking_mast where  tbl_booking_mast."cio_booking_id"=b.IDNUM ))  AS "Uom"
,b.PAGENUM as "Page_no"
,(select tbl_booking_mast."Card_rate" from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=b.IDNUM ) as "Card_Rate"
,(select tbl_booking_mast."Discount_per" from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=b.IDNUM ) as Discper
,(select tbl_booking_mast."Special_disc_per" from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=b.IDNUM ) as Spdiscper
,(select tbl_booking_mast."Space_disc_per" from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=b.IDNUM ) as Spacediscper
,(select tbl_booking_mast."Special_charges" from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=b.IDNUM ) as Specialcharge
--,(select nvl((sum(d.BILL_AMT) -nvl(fun_actual('''||compcode||''',nvl(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),nvl(b.RETAINER_CODE ,''0''),nvl(sum(d.GROSS_AMT) ,''0''),'''||prefer||''',''2'' ),''0'')  ),''0'') from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=b.IDNUM ) as ActualBusiness
*/



FROM ad_bills b,ad_bills_det d,AGENCY_MAST a ,PUB_MAST p
WHERE b.BILNO=d.BILNO AND
b.BILDT=d.BILDT AND
a."IDNUM"=d."IDNUM" and
a."AGCODE"=a."code_subcode" AND  
a."PRIPUB" = p."Pub_Code" 
and ((d."BKFOR"  in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')or  ('''||chk_access||'''=''0'') )';

IF(agname IS NOT NULL)
THEN
query1:=query1 ||' AND a.AG_MAIN_CODE ='''||agname ||'''';
END IF;

----NEED TO FIND
IF(Adtype IS NOT NULL)
THEN
query1:=query1 || ' and d."AD_TYPE_V"='''||Adtype||'''';

END IF;
----NEED TO FIND

iF(pub_cent IS NOT NULL)
THEN
query1:=query1||'  AND d."BKFOR"  ='''||pub_cent||'''';
END IF;

IF(fromdate IS NOT NULL AND dateto IS NULL )
THEN
query1:=query1||' and d.BILDT ='''||v_frdt||'''';
END IF;

IF(fromdate IS NOT NULL AND dateto IS NOT NULL )
THEN
query1:=query1||' and d.BILDT between  '''||v_frdt ||''' and  '''||v_todt||''' ';
END IF;

IF(edition IS NOT NULL)
THEN
query1:=query1||'  and d."EDITION"='''||edition||'''';
END IF;

----NEED TO FIND
IF((category IS NOT NULL) AND (category <> 'Package') AND (category <> 'Solo'))
THEN
query1:=query1||' and  b."AGCODE"= a."code_subcode" and a."Agency_Type_Code"= '''||upper(category)||'''';
END IF;
----NEED TO FIND

IF(product IS NOT NULL)
THEN
query1:=query1||' and b."PRIPUB"='''||product||'''';
END IF;

IF(Region IS NOT NULL)
THEN
query1:=query1 ||' and b.UNIT in (select "Branch_Code" from branch_mst where  BRANCH_MST."Region_code"='''||Region ||''')';
END IF;

IF(agcat IS NOT NULL)
THEN
query1:=query1 ||' AND b."AGCODE" =a."code_subcode" and a."Agency_Cat_Code"='''||agcat ||'''';
END IF;

IF(executive IS NOT NULL)
THEN
query1:=query1 ||' AND b."EXECUTIVE_NAME"='''||executive||'''';
END IF;

IF(pstatecode IS NOT NULL)
THEN
query1:=query1 ||' AND a.state ='''||pstatecode ||'''';
END IF;

IF(pdistcode IS NOT NULL)
THEN
query1:=query1 ||' AND a.district ='''||pdistcode ||'''';
END IF;

IF(descid IS NOT  NULL)
THEN
query1:=query1||'GROUP BY b.IDNUM ,a."Agency_Name" ,d."CLIENTCD",
p."Pub_Name" ,d."SIZE_BOOK", b.REVENUE_CENTER ,
d.RATECD ,b."BILL_RMRK" ,b."COLOUR" ,d.PRIADCTG  ,
d.SECADCTG ,d."PACKAGE_CODE" ,b.DISCOUNT ,d.BILNO ,
d.BILDT ,b."SPPREMIUM", b.GROSS_AMT,b.BOXCHRG ,b.AGCOMM
 --,a."Add1",b.PAGENUM,b.RETAINER_CODE
 ORDER BY "'||descid||'"';
query1:=query1||''||ascdesc||'';
else
query1:=query1||' GROUP BY b.IDNUM ,a."Agency_Name" ,d."CLIENTCD",
p."Pub_Name" ,d."SIZE_BOOK", b.REVENUE_CENTER ,
d.RATECD ,b."BILL_RMRK" ,b."COLOUR" ,d.PRIADCTG  ,
d.SECADCTG ,
d."PACKAGE_CODE" ,
b.DISCOUNT ,d.BILNO ,d.BILDT 
,b."SPPREMIUM", b.GROSS_AMT,b.BOXCHRG, b.AGCOMM
--,a."Add1",b.PAGENUM,b.RETAINER_CODE


order by b.IDNUM';
END IF;
--DELETE FROM SEARCHTBL;insert into searchtbl values(query1);commit;

insert into searchtbl values(query1);

OPEN p_recordset1 FOR query1;
end if;

END pub_Reportnew;
/


=============end====7468===avinash=======================================

//===========================PAtch for no issue date (Kuldeep Bhati)==================//
CREATE OR REPLACE PACKAGE get_validdate_qbc Is
    Type T_Accounts_Cursor Is Ref Cursor;
    Procedure get_validdate_qbc_P
    (
        dateformat  in  varchar2,
        datetoadd   in  date,
        pkgname     in  varchar2,
        adcat1      in  varchar2,
        adtype1     in  varchar2,
        center      in  varchar2,
        pkgid       in varchar2,
        pkgalias    in varchar2,
        p_Accounts  Out T_Accounts_Cursor,
        p_Accounts1 Out T_Accounts_Cursor
    );
end get_validdate_qbc;
/
CREATE OR REPLACE PACKAGE BODY get_validdate_qbc
IS
   PROCEDURE get_validdate_qbc_p (
      DATEFORMAT    IN      VARCHAR2,
      datetoadd     IN      DATE,
      pkgname       IN      VARCHAR2,
      adcat1        IN      VARCHAR2,
      adtype1       IN      VARCHAR2,
      center      in  varchar2,
       pkgid       in varchar2,
       pkgalias    in varchar2,
      p_accounts    OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor
   )
   AS
      fixdate      DATE;
      --validdate     date;
     validdate      date;
      validdays     VARCHAR2 (100);
      dateofday     VARCHAR2 (20);
      day1          VARCHAR2 (18);
      flag          NUMBER;
      count1        NUMBER;
      count2        NUMBER;
      editioncode   VARCHAR2 (12);
      sun           VARCHAR2 (5);
      mon           VARCHAR2 (5);
      tue           VARCHAR2 (5);
      wed           VARCHAR2 (5);
      thu           VARCHAR2 (5);
      fri           VARCHAR2 (5);
      sat           VARCHAR2 (5);
      
       sun1           VARCHAR2 (5);
      mon1           VARCHAR2 (5);
      tue1           VARCHAR2 (5);
      wed1           VARCHAR2 (5);
      thu1           VARCHAR2 (5);
      fri1           VARCHAR2 (5);
      sat1           VARCHAR2 (5);
      i             NUMBER;
      end1          NUMBER;
      noisscode     VARCHAR (8);
      a             NUMBER;
      datetoadd1    DATE;
   BEGIN
      DELETE FROM temp6;

      COMMIT;

      DELETE FROM RESULTS_TMP;

      COMMIT;

      a := fn_splitfield (pkgid, '+');
      
if pkgalias is not null then
      INSERT INTO temp6

SELECT  (select "Edition_Code" from edition_mast where "Edition_Alias" IN
(SELECT "Combin_Desc" from combin_mast where "Combin_Desc" ="EDITION_COMBIN_CODE" and rownum<=1) and  rownum<=1) "EDITION", "SUN", "MON",
                          "TUE", "WED", "THU", "FRI", "SAT"
                    FROM combin_days where combin_code IN ( SELECT LTRIM (RTRIM (edition_name))
                                            FROM RESULT) and "EDITION_COMBIN_CODE"=pkgalias;
                                            
                                          INSERT INTO temp6      SELECT  (select "Supp_Code" from supplement_mast where "Supp_Alias" IN
(SELECT "Combin_Desc" from combin_mast where "Combin_Desc" ="EDITION_COMBIN_CODE" and rownum<=1) and  rownum<=1) "EDITION", "SUN", "MON",
                          "TUE", "WED", "THU", "FRI", "SAT"
                    FROM combin_days where combin_code IN ( SELECT LTRIM (RTRIM (edition_name))
                                            FROM RESULT) and "EDITION_COMBIN_CODE"=pkgalias;
else     
  a := fn_splitfield (pkgname, '+');

/*SELECT  (select "Edition_Code" from edition_mast where "Edition_Alias" IN
(SELECT "Combin_Desc" from combin_mast where "Package_Name" ="EDITION_COMBIN_CODE")) "EDITION", "SUN", "MON",
                          "TUE", "WED", "THU", "FRI", "SAT"
                    FROM combin_days where combin_code IN ( SELECT LTRIM (RTRIM (edition_name))
                                            FROM RESULT);*/
INSERT INTO temp6 
 SELECT DISTINCT a."edition_code", a."sun", a."mon",
                         a."tue", a."wed", a."thu", a."fri", a."sat"
                    FROM select_edition_day a,edition_mast b
                   WHERE a."edition_code"= b."Edition_Code" and b."Edition_Alias" IN (
                                          SELECT LTRIM (RTRIM (edition_name))
                                            FROM RESULT);

INSERT INTO temp6 
 SELECT DISTINCT a."Supp_code", a."sun", a."mon",
                         a."tue", a."wed", a."thu", a."fri", a."sat"
                    FROM select_supplement_day a,supplement_mast b
                   WHERE a."Supp_code"= b."Supp_Code" and b."Supp_Alias" IN (
                                          SELECT LTRIM (RTRIM (edition_name))
                                            FROM RESULT);                                            
end if; 
SELECT COUNT(*) INTO count1 FROM TEMP6;
if count1 is null or count1=0 then
      a := fn_splitfield (pkgname, '+');

/*SELECT  (select "Edition_Code" from edition_mast where "Edition_Alias" IN
(SELECT "Combin_Desc" from combin_mast where "Package_Name" ="EDITION_COMBIN_CODE")) "EDITION", "SUN", "MON",
                          "TUE", "WED", "THU", "FRI", "SAT"
                    FROM combin_days where combin_code IN ( SELECT LTRIM (RTRIM (edition_name))
                                            FROM RESULT);*/
INSERT INTO temp6 
 SELECT DISTINCT a."edition_code", a."sun", a."mon",
                         a."tue", a."wed", a."thu", a."fri", a."sat"
                    FROM select_edition_day a,edition_mast b
                   WHERE a."edition_code"= b."Edition_Code" and b."Edition_Alias" IN (
                                          SELECT LTRIM (RTRIM (edition_name))  FROM RESULT);
       
 INSERT INTO temp6 
 SELECT DISTINCT a."Supp_code", a."sun", a."mon",
                         a."tue", a."wed", a."thu", a."fri", a."sat"
                    FROM select_supplement_day a,supplement_mast b
                   WHERE a."Supp_code"= b."Supp_Code" and b."Supp_Alias" IN (
                                          SELECT LTRIM (RTRIM (edition_name))
                                            FROM RESULT);                                    
end if;
count1:=0;
       /*  SELECT DISTINCT select_edition_day."edition_code", "sun", "mon",
                         "tue", "wed", "thu", "fri", "sat"
                    FROM select_edition_day
                   WHERE select_edition_day."edition_code" IN (
                            SELECT edition_mast."Edition_Code"
                              FROM edition_mast
                             WHERE "Edition_Alias" IN (SELECT "Combin_Desc" from combin_mast where "Package_Name" in(
                                          SELECT LTRIM (RTRIM (edition_name))
                                            FROM RESULT)));*/

      fixdate := datetoadd;
      datetoadd1 :=datetoadd;
      DBMS_OUTPUT.put_line (' fixdate' || fixdate);
      DECLARE
         CURSOR subedition
         IS
            SELECT  edition_code, sun, mon, tue, wed, thu, fri, sat
                       FROM temp6;
      BEGIN
         OPEN subedition;

         LOOP
            FETCH subedition
            INTO editioncode, sun, mon, tue, wed, thu, fri, sat;

            EXIT WHEN subedition%NOTFOUND;
                BEGIN
                    select "sun" ,"mon" ,"tue","wed","thu","fri","sat" into sun1,mon1,tue1,wed1,thu1,fri1,sat1 from categorywiseedition where "Adv_Cat_Code"=adcat1 and "Edition_code"=editioncode;
                EXCEPTION
                    WHEN NO_DATA_FOUND
                     THEN
                     NULL;
                END;
                validdate:=null;
                datetoadd1 :=datetoadd;
           
            DBMS_OUTPUT.PUT_LINE(day1);
            
            DBMS_OUTPUT.PUT_LINE('sun1--' || sun1);
          DBMS_OUTPUT.PUT_LINE('MON1--' || mon1);
          DBMS_OUTPUT.PUT_LINE('tue1--' || tue1);
          DBMS_OUTPUT.PUT_LINE('wed1--' || wed1);
          DBMS_OUTPUT.PUT_LINE('thu1--' || thu1);
          DBMS_OUTPUT.PUT_LINE('fri1--' || fri1);
          DBMS_OUTPUT.PUT_LINE('sat1--' || sat1);
          DBMS_OUTPUT.PUT_LINE('editioncode--' || editioncode);
            
             noisscode := '0';
             BEGIN
               DBMS_OUTPUT.put_line (' AAAA');

               SELECT "No_Iss_Code"
                 INTO noisscode
                 FROM no_iss_mast
                WHERE "Edition_Code" = editioncode and rownum <=1;
            EXCEPTION
               WHEN NO_DATA_FOUND
               THEN
                  NULL;
            END;

            SELECT COUNT (*)
              INTO count1
              FROM no_iss_grid
             WHERE "No_Iss_Code" = noisscode AND "no_issue_date" = datetoadd1;

              IF (count1 > 0)
            THEN
               --print('11')
               datetoadd1 := datetoadd1 + 1;
               -- convert(varchar(15),dateadd(dd, 1, @fixdate),101)
               DBMS_OUTPUT.put_line (' IFdatetoadd1' || datetoadd1);
            ELSE
               datetoadd1 := datetoadd1;
               DBMS_OUTPUT.put_line (' ELSEdatetoadd1' || datetoadd1);
            END IF;
              day1 := TO_CHAR (datetoadd1, 'dy');
            i := 0;
            end1 := 1;
             DBMS_OUTPUT.put_line (' day1***' || day1);
            WHILE (i <= end1)
           LOOP
             IF (upper(day1) = upper('Sun'))
               THEN

                  IF (sun != 'Y')
                  THEN
                     IF (mon = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     ELSIF (tue = 'Y')
                     THEN
                        validdate := datetoadd1 + 2;
                     ELSIF (wed = 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     ELSIF (thu = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     ELSIF (fri = 'Y')
                     THEN
                        validdate :=datetoadd1 + 5;
                     ELSIF (sat = 'Y')
                     THEN
                        validdate := datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
                   IF (sun1 != 'Y')
                  THEN
                     IF (mon1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     ELSIF (tue1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 2;
                     ELSIF (wed1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     ELSIF (thu1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     ELSIF (fri1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 5;
                     ELSIF (sat1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
             ELSIF (upper(day1) = upper('Mon'))
               THEN
                DBMS_OUTPUT.put_line (' MON*****' || mon);
                DBMS_OUTPUT.put_line (' MON*****' || validdate);
                  IF (mon != 'Y')
                  THEN
                     IF (tue = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     ELSIF (wed = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     ELSIF (thu = 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     ELSIF (fri = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     ELSIF (sat = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     ELSIF (sun = 'Y')
                     THEN
                        validdate :=datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                   DBMS_OUTPUT.put_line (' MON*****' || validdate);
                   IF (mon1 != 'Y')
                  THEN
                  DBMS_OUTPUT.PUT_LINE('NEW--');
                  DBMS_OUTPUT.PUT_LINE('tue1--'||tue1);
                   
                     IF (tue1 = 'Y')
                     THEN
                        
                        validdate := datetoadd1 + 1;
                        DBMS_OUTPUT.PUT_LINE('---validdate--'||validdate);
                     ELSIF (wed1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     ELSIF (thu1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     ELSIF (fri1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     ELSIF (sat1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     ELSIF (sun1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
             ELSIF (upper(day1) = upper('Tue'))
               THEN
                  IF (tue != 'Y')
                  THEN
                     IF (wed = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     ELSIF (thu = 'Y')
                     THEN
                        validdate := datetoadd1 + 2;
                     ELSIF (fri = 'Y')
                     THEN
                        validdate :=datetoadd1 + 3;
                     ELSIF (sat = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     ELSIF (sun = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     ELSIF (mon = 'Y')
                     THEN
                        validdate :=datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
                    IF (tue1 != 'Y')
                  THEN
                     IF (wed1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     ELSIF (thu1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 2;
                     ELSIF (fri1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 3;
                     ELSIF (sat1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     ELSIF (sun1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     ELSIF (mon1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
               ------for wednaesday
               ELSIF (upper(day1) = upper('Wed'))
               THEN
                    dbms_output.put_line('wed1==================='||wed1);
                  IF (wed != 'Y')
                  THEN
                     IF (thu = 'Y')
                     THEN
                        validdate :=datetoadd1 + 1;
                     --convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (fri = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (sat = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                        validdate := datetoadd1 + 3;
                     ELSIF (sun = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                        validdate := datetoadd1 + 4;
                     ELSIF (mon = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                        validdate := datetoadd1 + 5;
                     ELSIF (tue = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                        validdate :=datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
                   IF (wed1 != 'Y')
                  THEN
                     IF (thu1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 1;
                     --convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (fri1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (sat1 = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                        validdate := datetoadd1 + 3;
                     ELSIF (sun1 = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                        validdate := datetoadd1 + 4;
                     ELSIF (mon1 = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                        validdate := datetoadd1 + 5;
                     ELSIF (tue1 = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                        validdate :=datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
             ELSIF (upper(day1) = upper('Thu'))
               THEN
                  IF (thu != 'Y')
                  THEN
                     IF (fri = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     --select validdate=convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (sat = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (sun = 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                     ELSIF (mon = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                     ELSIF (tue = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                     ELSIF (wed = 'Y')
                     THEN
                        validdate := datetoadd1 + 6;
                     --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                     END IF;
                  ELSE
                  dbms_output.put_line('kkkkkkkkkkkkkkkkkk');
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
                   IF (thu1 != 'Y')
                  THEN
                     IF (fri1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     --select validdate=convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (sat1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (sun1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                     ELSIF (mon1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                     ELSIF (tue1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                     ELSIF (wed1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 6;
                     --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                     END IF;
                  ELSE
                  dbms_output.put_line('kkkkkkkkkkkkkkkkkk');
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
               ------------------------for friday
               ELSIF (upper(day1) = upper('Fri'))
               THEN
               DBMS_OUTPUT.PUT_LINE('LATA2 '||fri);
                  IF (fri != 'Y')
                  THEN
                     IF (sat = 'Y')
                     THEN
                        validdate :=datetoadd1 + 1;
                     --select validdate=convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (sun = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (mon = 'Y')
                     THEN
                        validdate :=datetoadd1 + 3;
                     --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                     ELSIF (tue = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                     ELSIF (wed = 'Y')
                     THEN
                        validdate := datetoadd1 +5;
                     --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                     ELSIF (thu = 'Y')
                     THEN
                        validdate :=datetoadd1 + 6;
                     --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1;
                    END IF;
                  END IF;
                  
                   IF (fri1 != 'Y')
                  THEN
                     IF (sat1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 1;
                     --select validdate=convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (sun1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (mon1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 3;
                     --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                     ELSIF (tue1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                     ELSIF (wed1 = 'Y')
                     THEN
                        validdate := datetoadd1 +5;
                     --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                     ELSIF (thu1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 6;
                     --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1;
                    END IF;
                  END IF;
               ------------------------------------fror saturday
               ELSIF (upper(day1) = upper('Sat'))
               THEN
                  IF (sat != 'Y')
                  THEN
                     IF (sun = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     --select validdate=convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (mon = 'Y')
                     THEN
                        validdate := datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (tue = 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                     ELSIF (wed = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                     ELSIF (thu = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                     ELSIF (fri = 'Y')
                     THEN
                        validdate := datetoadd1 + 6;
                     --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                     ELSE
                       validdate := datetoadd1;
                     --set validdate=convert(varchar(15),datetoadd1,101)
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1;
                    END IF;
                  END IF;

                  IF (sat1 != 'Y')
                  THEN
                     IF (sun1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     --select validdate=convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (mon1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (tue1= 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                     ELSIF (wed1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                     ELSIF (thu1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                     ELSIF (fri1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 6;
                     --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                     ELSE
                       validdate := datetoadd1;
                     --set validdate=convert(varchar(15),datetoadd1,101)
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1;
                    END IF;
                  END IF;


               End if;
               begin
               SELECT "No_Iss_Code"
                    INTO noisscode
                    FROM no_iss_mast
                   WHERE "Edition_Code" = editioncode and rownum <=1;

                  exception when no_data_found then
                    null;
                    end;
                    count1:=0;
                  SELECT COUNT (*)
                    INTO count1
                    FROM no_iss_grid
                   WHERE "No_Iss_Code" = noisscode
                   AND "no_issue_date" = validdate;
                     --AND "no_issue_date" = datetoadd1;
               DBMS_OUTPUT.put_line ('datetoadd1 '|| datetoadd1);
               DBMS_OUTPUT.put_line ('validdate---- '|| validdate);
                DBMS_OUTPUT.put_line ('count1---- '|| count1);
                IF (count1 > 0)
                THEN
                   --print('11')
                   validdate := validdate + 1;
                   datetoadd1:=validdate;
                   day1 := TO_CHAR (datetoadd1, 'dy');
                   -- convert(varchar(15),dateadd(dd, 1, @fixdate),101)
                   DBMS_OUTPUT.put_line (' IFdatetoadd1' || datetoadd1);
                ELSE
                   validdate := validdate;
                   DBMS_OUTPUT.put_line (' ELSEdatetoadd1' || datetoadd1);
                   i:=1;
                   exit;
                END IF;
           END LOOP;
             IF (DATEFORMAT = 'dd/mm/yyyy')
            THEN
            DBMS_OUTPUT.put_line ('ankur');
            DBMS_OUTPUT.put_line (validdate);
               INSERT INTO RESULTS_TMP
                SELECT nvl((SELECT "Edition_Alias"
                FROM edition_mast
                WHERE "Edition_Code" =
                LTRIM (RTRIM (editioncode))),(SELECT "Supp_Alias"
                FROM supplement_mast
                WHERE "Supp_Code" =
                LTRIM (RTRIM (editioncode))))
                edition_alias,validdate
              --  to_char(to_date(TO_CHAR (validdate,'dd-mon-rrrr'),'dd/mm/yyyy'),'dd/mm/yyyy')
                FROM DUAL;
            END IF;

             IF (DATEFORMAT = 'mm/dd/yyyy')
            THEN
               INSERT INTO RESULTS_TMP
                SELECT nvl((SELECT "Edition_Alias"
                FROM edition_mast
                WHERE "Edition_Code" =
                LTRIM (RTRIM (editioncode))),(SELECT "Supp_Alias"
                FROM supplement_mast
                WHERE "Supp_Code" =
                LTRIM (RTRIM (editioncode))))
                edition_alias,validdate
               --to_char(to_date(TO_CHAR (validdate,'dd-mon-rrrr'),'dd/mm/yyyy'),'mm/dd/yyyy')
                FROM DUAL;
            END IF;

             IF (DATEFORMAT = 'yyyy/mm/dd')
            THEN
               INSERT INTO RESULTS_TMP
                SELECT nvl((SELECT "Edition_Alias"
                FROM edition_mast
                WHERE "Edition_Code" =
                LTRIM (RTRIM (editioncode))),(SELECT "Supp_Alias"
                FROM supplement_mast
                WHERE "Supp_Code" =
                LTRIM (RTRIM (editioncode))))
                edition_alias,validdate
              --  to_char(to_date(TO_CHAR (validdate,'dd-mon-rrrr'),'dd/mm/yyyy'),'dd/mm/yyyy')
                FROM DUAL;
            END IF;


            END LOOP;

            CLOSE subedition;

      END;
 SELECT COUNT (*)
        INTO count2
        FROM RESULTS_TMP;
        
       SELECT COUNT (*)
        INTO count1
        FROM RESULTS_TMP
       WHERE date_noissue = fixdate;
DBMS_OUTPUT.put_line ('fixdate--'||fixdate);
DBMS_OUTPUT.put_line ('count1--'||count1);
        IF (count1 = count2) THEN
        IF (DATEFORMAT = 'mm/dd/yyyy')
         THEN
            --select convert(varchar(15),fixdate,101)
            OPEN p_accounts FOR
               SELECT TO_CHAR (fixdate, 'mm/dd/yyyy') as "date_noissue"
                 FROM DUAL;

            OPEN p_accounts1 FOR
            SELECT EDITION_CODE as "Edition_code",TO_CHAR (DATE_NOISSUE,'mm/dd/yyyy') as "date_noissue"
                FROM RESULTS_TMP;

        ELSIF (DATEFORMAT = 'dd/mm/yyyy')
         THEN
            OPEN p_accounts FOR
               SELECT TO_CHAR (fixdate, 'dd/mm/yyyy') as "date_noissue"
                 FROM DUAL;

         OPEN p_accounts1 FOR
            SELECT EDITION_CODE as "Edition_code",TO_CHAR (DATE_NOISSUE,'dd/mm/yyyy') as "date_noissue"
                FROM RESULTS_TMP;

        ELSIF (DATEFORMAT = 'yyyy/mm/dd')
         THEN
            OPEN p_accounts FOR
               SELECT TO_CHAR (fixdate, 'yyyy/mm/dd') as "date_noissue"
                 FROM DUAL;

         OPEN p_accounts1 FOR
            SELECT EDITION_CODE as "Edition_code",TO_CHAR (DATE_NOISSUE,'yyyy/mm/dd') as "date_noissue"
                FROM RESULTS_TMP;


         END IF;
      ELSE
        IF (DATEFORMAT = 'mm/dd/yyyy')
         THEN
         OPEN p_accounts FOR
            SELECT to_char(date_noissue,'mm/dd/yyyy') as "date_noissue"
              FROM RESULTS_TMP
             WHERE ROWNUM <= 1;

         OPEN p_accounts1 FOR
            SELECT EDITION_CODE as "Edition_code",to_char(DATE_NOISSUE,'mm/dd/yyyy') as "date_noissue"
                FROM RESULTS_TMP;

        ELSIF (DATEFORMAT = 'dd/mm/yyyy')
         THEN
         
             OPEN p_accounts FOR
                SELECT to_char(date_noissue,'dd/mm/yyyy') as "date_noissue"
              FROM RESULTS_TMP
             WHERE ROWNUM <= 1;

         OPEN p_accounts1 FOR
            SELECT EDITION_CODE as "Edition_code",to_char(DATE_NOISSUE,'dd/mm/yyyy') as "date_noissue"
                FROM RESULTS_TMP;
        ELSIF (DATEFORMAT = 'yyyy/mm/dd')
        then
             OPEN p_accounts FOR
                SELECT to_char(date_noissue,'yyyy/mm/dd') as "date_noissue"
              FROM RESULTS_TMP
             WHERE ROWNUM <= 1;

            OPEN p_accounts1 FOR
            SELECT EDITION_CODE as "Edition_code",to_char(DATE_NOISSUE,'yyyy/mm/dd') as "date_noissue"
                FROM RESULTS_TMP;
        end if;

      END IF;



       END get_validdate_qbc_p;
END get_validdate_qbc;
/

//=========================== End PAtch for no issue date (Kuldeep Bhati)==================//


===================7469====start=============avinash====================
CREATE OR REPLACE PACKAGE HT18JULY.advupdate Is

Procedure advupdate_P (
compcode in varchar2,
adcatcode in varchar2,
catalias in varchar2,
catname in varchar2,
adtype in varchar2,
rclient in varchar2,
filename in varchar2,
status1 in varchar2,
productivity in varchar2,
hrs in varchar2,
min1 in varchar2
);

End advupdate;
/


CREATE OR REPLACE PACKAGE BODY HT18JULY.advupdate Is
Procedure advupdate_P(
compcode in varchar2,
adcatcode in varchar2,
catalias in varchar2,
catname in varchar2,
adtype in varchar2,
rclient in varchar2,
filename in varchar2,
status1 in varchar2,
productivity in varchar2,
hrs in varchar2,
min1 in varchar2
)As
Begin
update Adv_Cat_Mast set REGCLIENT=rclient, "Adv_Cat_Name"=catname,"Adv_Cat_Alias"=catalias,"Creation_Datetime"=sysdate,"Adv_Type"=adtype,CAT_FILE_NAME=filename,STATUS=status1,PREODICITY_CODE=productivity , RO_HR=hrs ,RO_MIN=min1  where "Comp_Code"=compcode and "Adv_Cat_Code"=adcatcode;

--,RO_MIN=min
commit;
End advupdate_P;
End advupdate;
/


===================7469====End=============avinash====================


===================from jaipur====Start=============avinash====================


CREATE OR REPLACE PACKAGE Executebookingdispaudit
IS
  TYPE T_Accounts_Cursor IS REF CURSOR;
  PROCEDURE Executebookingdispaudit_p(
  compcode IN VARCHAR2,
  ciobookid IN VARCHAR2,
  docno IN VARCHAR2:=NULL,
  keyno IN VARCHAR2:=NULL,
  rono IN VARCHAR2:=NULL,
  agencycode IN VARCHAR2:=NULL,
  client IN VARCHAR2:=NULL,
  booking IN VARCHAR2,dateformat IN VARCHAR2,
  P_Accounts  OUT  T_Accounts_Cursor,P_Accounts1  OUT  T_Accounts_Cursor,P_Accounts2  OUT  T_Accounts_Cursor,
  P_Accounts3  OUT  T_Accounts_Cursor);
END Executebookingdispaudit ;
/





CREATE OR REPLACE PACKAGE BODY Executebookingdispaudit
IS
   PROCEDURE Executebookingdispaudit_p (
      compcode      IN       VARCHAR2,
      ciobookid     IN       VARCHAR2,
      docno         IN       VARCHAR2 := NULL,
      keyno         IN       VARCHAR2 := NULL,
      rono          IN       VARCHAR2 := NULL,
      agencycode    IN       VARCHAR2 := NULL,
      client        IN       VARCHAR2 := NULL,
      booking       IN       VARCHAR2,
      dateformat     IN          VARCHAR2,
      p_accounts    OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor,
      p_accounts2   OUT      t_accounts_cursor,
      P_Accounts3  OUT  T_Accounts_Cursor
   )
   AS
      VERSION1   NUMBER;
      count1    NUMBER;

   BEGIN

       DELETE FROM TEMPBOOKING_MAST_AUDIT;

      INSERT INTO TEMPBOOKING_MAST_AUDIT
         SELECT "date_time", "branch", "booked_by", "cio_booking_id",
                "prev_booking", "applied_by", "audit", "RO_No", "RO_Date",
                "Caption", "bill_status", "ro_status", "Agency_code",
                "Agency_address", "Client_code", "Client_address",
                "Agency_sub_code", "Dockit_no", "Executive_code",
                "Executive_zone", "Product_code", "Brand_code", "Key_no",
                "Bill_remarks", "Print_remark", "Package_code",
                "No_of_insertion", "Insertion_date", "Repeating_day",
                "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code",
                "Color_code", "Uom_code", "Page_position_code",
                "Page_type_code", "Page_no", "Ad_size_type_code",
                "Ad_size_height", 
                           
                
                
                
                nvl(TBL_BOOKING_MAST."Ad_size_column" ,TBL_BOOKING_MAST."Ad_size_width") AS "Ad_size_width"               
                
                
                , "Rate_code",
                "Scheme_type_code", "Currency_code", NVL("Agrred_rate",'0'),
                NVL("Agreed_amount",'0'), "Special_discount", "Space_discount",
                "Special_charges", "Agency_status", "Agency_type",
                "Agency_pay", "Agency_credit", "Total_area", "Card_rate",
                "Card_amount", NVL("Discount",'0'), "Discount_per", "Bill_cycle",
                "Revenue_center", "Bill_pay", "Bill_height", "Bill_width",
                "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc",
                "Agency_out", "Box_code", "Box_no", "Box_agency",
                "Box_client", "Box_address", "Comp_code", "Userid",
                "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad",
                "Campaign", "Bill_amount", "Page_prem", "Page_amount",
                "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column",
                "Bill_area", "Special_disc_per", "Space_disc_per",
                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                "Contract_name", "Contract_type", "Card_name", "Card_type",
                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                "Bullet_code", "Bullet_premium", "Material_status",
                TRUNC("Receipt_date"), "prev_cioid", "prev_receipt",
                "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H",
                "Logo_W", "Logo_color", "Logo_Uom",sapid,RETAINER,"ADD_AGENCY_COMM",
                MOBILENO,ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,
                "Bullet_code","Bullet_premium",DOCTYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM



           FROM TBL_BOOKING_MAST
          WHERE ("Comp_code" = compcode OR compcode IS NULL)
            AND ("cio_booking_id" = ciobookid OR ciobookid IS NULL
                )
            AND ("Dockit_no" = docno  OR docno IS NULL)
            AND ("Key_no" = keyno  OR keyno IS NULL)
            AND ("RO_No" = rono  OR rono IS NULL)
            AND ("Agency_sub_code" LIKE agencycode || '%'
                 OR agencycode IS NULL
                )
            AND ("Client_code" LIKE client || '%' OR client IS NULL)
        --    AND ("Ad_type_code" LIKE booking || '%' OR booking IS NULL)
            ;

      OPEN p_accounts FOR
      SELECT CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("date_time",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("date_time",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("date_time",'yyyy/mm/dd')  END AS date_time,
                     "branch","booked_by", "cio_booking_id", "prev_booking", "applied_by","audit", "RO_No",
            CASE dateformat
                 WHEN 'mm/dd/yyyy' THEN TO_CHAR("RO_Date",'mm/dd/yyyy')
                 WHEN 'dd/mm/yyyy' THEN TO_CHAR("RO_Date",'dd/mm/yyyy')
                 WHEN 'yyyy/mm/dd' THEN TO_CHAR("RO_Date",'yyyy/mm/dd')  END AS "RO_Date",
                  TO_CHAR("RO_Date", 'dd/mm/yyyy') AS "RO_Date",
                "Caption", "bill_status", "ro_status", "Agency_code",
                "Agency_address", "Client_code", "Client_address",
                "Agency_sub_code", "Dockit_no", "Executive_code",
                "Executive_zone", "Product_code", "Brand_code", "Key_no",
                "Bill_remarks", "Print_remark", "Package_code","No_of_insertion",
            CASE dateformat
                    WHEN 'mm/dd/yyyy' THEN TO_CHAR("Insertion_date",'mm/dd/yyyy')
                    WHEN 'dd/mm/yyyy' THEN TO_CHAR("Insertion_date",'dd/mm/yyyy')
                    WHEN 'yyyy/mm/dd' THEN TO_CHAR("Insertion_date",'yyyy/mm/dd')  END    AS "Insertion_date",
                "Repeating_day", "Ad_type_code", "Ad_cat_code",
                "Ad_sub_cat_code", "Color_code", "Uom_code",
                "Page_position_code", "Page_type_code", "Page_no",
                "Ad_size_type_code", "Ad_size_height", 
                
                "Ad_size_width"
                
                , "Rate_code",
                (SELECT "Scheme_Name" FROM SCHEME_MASTER WHERE "scheme_id" =TEMPBOOKING_MAST_AUDIT."Scheme_type_code"
                AND TEMPBOOKING_MAST_AUDIT."date_time" BETWEEN "Valid_From" AND "Valid_To")AS "Scheme_type_code",
                 "Currency_code", "Agrred_rate", "Agreed_amount",
                "Special_discount", "Space_discount", "Special_charges",
                TEMPBOOKING_MAST_AUDIT."Comp_code", TEMPBOOKING_MAST_AUDIT."Userid",
                TEMPBOOKING_MAST_AUDIT."Agency_status", "Agency_type", "Agency_pay",
                "Agency_credit", "Total_area", "Card_rate", "Card_amount",
                "Discount", "Discount_per", "Bill_cycle", "Revenue_center",
                "Bill_pay", "Bill_height", "Bill_width",
                TEMPBOOKING_MAST_AUDIT."Bill_to", "Invoices", "Vts", "Bill_add",
                "Trade_disc", "Agency_out", "Booking_type", "Campaign",
                "Page_prem", "Page_amount", "Prem_per", "Gross_amount",
                "Bill_amount", "Box_code", "Box_no", "Box_agency",
                "Box_client", "Box_address", "Tfn", "Coupan_ad",
                "Ad_size_column", "Bill_column", "Bill_area",
                "Special_disc_per", "Space_disc_per",
                AGENCY_MAST."Agency_Name" || '(' || AGENCY_MAST."code_subcode" || ')' AS "AgencyName",
                (SELECT EXEC_MAST."Exec_name" || '(' || TO_CHAR(EXEC_MAST."Exe_no") || ')' FROM EXEC_MAST
                  WHERE TEMPBOOKING_MAST_AUDIT."Executive_code" = EXEC_MAST."Exe_no"
                    AND TEMPBOOKING_MAST_AUDIT."Comp_code" = EXEC_MAST."comp_code") AS "execname",

                (SELECT  PRODUCT_CAT_MAST."prod_desc" || '(' || PRODUCT_CAT_MAST."prod_cat_code" || ')' FROM PRODUCT_CAT_MAST
                  WHERE TEMPBOOKING_MAST_AUDIT."Product_code" = PRODUCT_CAT_MAST."prod_cat_code"
                    AND TEMPBOOKING_MAST_AUDIT."Comp_code" = PRODUCT_CAT_MAST."comp_code") AS "product",

                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                "Contract_name", "Contract_type", "Card_name", "Card_type",

                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3"  , "Ad_Subcat4" , "Ad_subcat5" , "Bg_color",
                "Bullet_code", "Bullet_premium",
                (SELECT "Agency_Name" FROM AGENCY_MAST WHERE "code_subcode" =TEMPBOOKING_MAST_AUDIT."Agency_sub_code") AS "AgencySubCode",

                NVL ((SELECT "Cust_Name"||'('||"Cust_Code"||')' FROM CUST_MAST WHERE "Cust_Code" = "Client_code"), "Client_code") AS "Client",                                       --112
                (SELECT DISTINCT "Payment_Mode_Name" FROM PAYMENT_MODE_MAST WHERE "Comp_Code"=compcode and "Pay_Mode_Code" = "Agency_pay") AS "PayMode",
                (SELECT "Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code" =TEMPBOOKING_MAST_AUDIT."Ad_cat_code") AS "categoryname",
                
                (SELECT "Adv_Subcat_Name" FROM ADV_SUBCAT_MAST  WHERE ADV_SUBCAT_MAST."Adv_Cat_Code"=TEMPBOOKING_MAST_AUDIT."Ad_cat_code" AND ADV_SUBCAT_MAST."Adv_Subcat_Code" =TEMPBOOKING_MAST_AUDIT."Ad_sub_cat_code")
                 AS "subcategoryname",
                 
                (SELECT "brand_name" FROM BRAND_MST WHERE "brand_code" =TEMPBOOKING_MAST_AUDIT."Brand_code") AS "Brand",
                (SELECT "Uom_Name" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST_AUDIT."Uom_code") AS "UOM",
                (SELECT "premiumname" FROM ADVPOS_PREM_MAST WHERE "Premiumcode" =TEMPBOOKING_MAST_AUDIT."Page_prem") AS "PagePremium",
                 (SELECT "Pos_Type" FROM ADVPOS_TYPE_MAST
                  WHERE "Pos_Type_Code" = TEMPBOOKING_MAST_AUDIT."Page_position_code") AS "PositionPremium",
                (SELECT "Curr_Name" FROM CURR_MAST WHERE "Curr_Code" = TEMPBOOKING_MAST_AUDIT."Currency_code") AS "Currency",
                "Material_status", TO_CHAR("Receipt_date",'dd/mm/yyyy') AS "Receipt_date", TEMPBOOKING_MAST_AUDIT."Region",
                "Variant", "Colortype",
                (SELECT "UOM_DESC" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST_AUDIT."Uom_code") AS "uom_desc",
                (SELECT "Logo" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST_AUDIT."Uom_code") AS "logo","Logo_H", "Logo_W", "Logo_color", "Logo_Uom",
                (SELECT "Logo_Uom" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST_AUDIT."Uom_code")  AS "logocode",
                (SELECT "Box_Charges_Native" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING_MAST_AUDIT."Box_code") AS "boxchrg",TEMPBOOKING_MAST_AUDIT.sapid,
                retainer,(SELECT "Retain_Name"||'('||"Retain_Code"||')' FROM RETAINERMASTER WHERE RETAINERMASTER."Retain_Code"=TEMPBOOKING_MAST_AUDIT.RETAINER) AS "RETAINER1",
                (SELECT "Package_Name" FROM combin_mast WHERE "Combin_Code" =

                TEMPBOOKING_MAST_AUDIT."Package_code") as "Package_cod",(SELECT "Col_Name" FROM col_mast WHERE "Col_Code" = TEMPBOOKING_MAST_AUDIT."Color_code") as

                "Color_cod",(SELECT "Pos_Type" FROM advpos_type_mast WHERE "Pos_Type_Code" =

                TEMPBOOKING_MAST_AUDIT."Page_position_code") as "Page_position_cod",
                decode(TEMPBOOKING_MAST_AUDIT."Booking_type",'1','BARTER','2','FMG','3','NORMAL','4','INHOUSE') as "Book_type",
                (SELECT "catname"  FROM  AD_CAT3   WHERE

                AD_CAT3."catcode"=TEMPBOOKING_MAST_AUDIT."Ad_Subcat3")   as "SUBCAT3",(SELECT "Cat_Name"  FROM  TBL_CAT4   WHERE

                TBL_CAT4."Cat_Code"=TEMPBOOKING_MAST_AUDIT."Ad_Subcat4") as "SUBCAT4"  ,(SELECT "Cat_Name"  FROM  TBL_CAT5   WHERE

                TBL_CAT5."Cat_Code"=TEMPBOOKING_MAST_AUDIT."Ad_subcat5") as "SUBCAT5",(SELECT "Comm_Rate" FROM ret_comm_details WHERE

                ret_comm_details."Retain_Code"=TEMPBOOKING_MAST_AUDIT.RETAINER and rowid=(select max(rowid) from ret_comm_details where ret_comm_details."Retain_Code"=TEMPBOOKING_MAST_AUDIT.RETAINER)) AS "RETAINER_COMM",(select AUDIT_COMMENT from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=TEMPBOOKING_MAST_AUDIT."cio_booking_id") as "remarks","ADD_AGENCY_COMM",
                (SELECT "Box_Charges_Type" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING_MAST_AUDIT."Box_code") AS "boxchargetype",
                (SELECT "Box_Name" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING_MAST_AUDIT."Box_code") AS "boxname",
                ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,

                (select "Bullet_Desc" from  bullet_mast where bullet_mast ."Bullet_Code"=TEMPBOOKING_MAST_AUDIT  ."BULLET_DESP") as "Bullet_Desc",
                TEMPBOOKING_MAST_AUDIT."Bullet_premium",(select RO_COMMENT from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=TEMPBOOKING_MAST_AUDIT."cio_booking_id") as "RO_COMMENT"
                ,DOCTYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,
                (SELECT "Box_Charges_Native" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING_MAST_AUDIT."Box_code") AS "boxcharge"
                FROM TEMPBOOKING_MAST_AUDIT, AGENCY_MAST
                WHERE AGENCY_MAST."code_subcode" =TEMPBOOKING_MAST_AUDIT."Agency_sub_code"
                AND AGENCY_MAST."Comp_Code" = compcode ORDER BY "Creation_datetime";


      Dbms_output.put_line('rinki--');
----------------------------------------------------Lata------------------------------------------------------

      OPEN p_accounts1 FOR
         SELECT NVL(COUNT (*),'0') AS "count"
                     FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" = ciobookid AND "audit" IS NOT NULL;

      BEGIN
         SELECT MAX (VSEQNO) INTO VERSION1 FROM TBL_BOOKING_MAST_LOG
          WHERE "Receipt_no" = ciobookid AND VSEQNO < (SELECT MAX (VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" = ciobookid);
            EXCEPTION WHEN NO_DATA_FOUND THEN NULL;
      END;

      OPEN p_accounts2 FOR
         SELECT    CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("date_time",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("date_time",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("date_time",'yyyy/mm/dd')  END AS "date_time",
                 "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by","audit", "RO_No",
               CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("RO_Date",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("RO_Date",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("RO_Date",'yyyy/mm/dd')  END AS "RO_Date",
                "Caption","bill_status", "ro_status",
                TBL_BOOKING_MAST_LOG."Agency_code", "Agency_address",
                "Client_code", "Client_address", "Agency_sub_code",
                "Dockit_no", "Executive_code", "Executive_zone",
                "Product_code", "Brand_code", "Key_no", "Bill_remarks",
                "Print_remark", "Package_code", "No_of_insertion",
            CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("Insertion_date",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("Insertion_date",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("Insertion_date",'yyyy/mm/dd')  END AS "Insertion_date",

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
                TBL_BOOKING_MAST_LOG."Bill_to", "Invoices", "Vts",
                "Bill_add", "Trade_disc", "Agency_out", "Booking_type",
                "Campaign", "Page_prem", "Page_amount", "Prem_per",
                "Gross_amount", "Bill_amount", "Box_code", "Box_no",
                "Box_agency", "Box_client", "Box_address", "Tfn" "Coupan_ad",
                "Ad_size_column", "Bill_column", "Bill_area",
                "Special_disc_per", "Space_disc_per",
                  AGENCY_MAST."Agency_Name"|| '('|| AGENCY_MAST."code_subcode"|| ')' AS "AgencyName",
                   (SELECT    EXEC_MAST."Exec_name" || '('|| TO_CHAR (EXEC_MAST."Exe_no") || ')'
                   FROM EXEC_MAST  WHERE TBL_BOOKING_MAST_LOG."Executive_code" =EXEC_MAST."Exe_no"
                    AND TBL_BOOKING_MAST_LOG."Comp_code" =EXEC_MAST."comp_code")AS "execname",
               (SELECT    PRODUCT_CAT_MAST."prod_desc"|| '('|| PRODUCT_CAT_MAST."prod_cat_code" || ')'
                   FROM PRODUCT_CAT_MAST WHERE TBL_BOOKING_MAST_LOG."Product_code" =PRODUCT_CAT_MAST."prod_cat_code"
                    AND TBL_BOOKING_MAST_LOG."Comp_code" =PRODUCT_CAT_MAST."comp_code")                                                                 AS "product",
                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                "Contract_name", "Contract_type", "Card_name", "Card_type",
                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                (SELECT "Agency_Name" FROM AGENCY_MAST WHERE "code_subcode" = TBL_BOOKING_MAST_LOG."Agency_sub_code")AS "AgencySubCode",
               NVL ((SELECT "Cust_Name"  FROM CUST_MAST WHERE "Cust_Code" = "Client_code"),'' ) AS "Client",
              (SELECT distinct "Payment_Mode_Name"  FROM PAYMENT_MODE_MAST WHERE "Comp_Code"=compcode and "Pay_Mode_Code" = "Agency_pay") AS "PayMode",
               (SELECT "Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code" =TBL_BOOKING_MAST_LOG."Ad_cat_code")AS "categoryname",
               (SELECT "Adv_Subcat_Name"  FROM ADV_SUBCAT_MAST WHERE ADV_SUBCAT_MAST."Adv_Subcat_Code" =TBL_BOOKING_MAST_LOG."Ad_sub_cat_code")
                 AS "subcategoryname",
               (SELECT "brand_name"  FROM BRAND_MST   WHERE "brand_code" = TBL_BOOKING_MAST_LOG."Brand_code")AS "Brand",
               (SELECT "Uom_Name" FROM UOM_MAST WHERE "Uom_Code" =TBL_BOOKING_MAST_LOG."Uom_code")AS "UOM",
               (SELECT "premiumname" FROM ADVPOS_PREM_MAST WHERE "Premiumcode" =TBL_BOOKING_MAST_LOG."Page_type_code")AS "PagePremium",
                (SELECT "Pos_Type" FROM ADVPOS_TYPE_MAST WHERE "Pos_Type_Code" =TBL_BOOKING_MAST_LOG."Page_position_code")AS "PositionPremium",
               (SELECT "Curr_Name"  FROM CURR_MAST WHERE "Curr_Code" =TBL_BOOKING_MAST_LOG."Currency_code") AS "Currency"
           FROM TBL_BOOKING_MAST_LOG, AGENCY_MAST
             WHERE TBL_BOOKING_MAST_LOG."Receipt_no" = ciobookid
            AND VSEQNO = VERSION1
            AND AGENCY_MAST."code_subcode" =
                                    TBL_BOOKING_MAST_LOG."Agency_sub_code"
            AND AGENCY_MAST."Comp_Code" = compcode;

      OPEN p_accounts3 FOR

         SELECT    CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("date_time",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("date_time",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("date_time",'yyyy/mm/dd')  END AS "date_time",
                   "branch","booked_by", "cio_booking_id", "prev_booking", "applied_by","audit", "RO_No",
              CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("RO_Date",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("RO_Date",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("RO_Date",'yyyy/mm/dd')  END AS "RO_Date",
                "Caption","bill_status", "ro_status",
                TBL_BOOKING_MAST_LOG."Agency_code", "Agency_address",
                "Client_code", "Client_address", "Agency_sub_code",
                "Dockit_no", "Executive_code", "Executive_zone",
                "Product_code", "Brand_code", "Key_no", "Bill_remarks",
                "Print_remark", "Package_code", "No_of_insertion",
            CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("Insertion_date",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("Insertion_date",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("Insertion_date",'yyyy/mm/dd')  END AS "Insertion_date",
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
                TBL_BOOKING_MAST_LOG."Bill_to", "Invoices", "Vts",
                "Bill_add", "Trade_disc", "Agency_out", "Booking_type",
                "Campaign", "Page_prem", "Page_amount", "Prem_per",
                "Gross_amount", "Bill_amount", "Box_code", "Box_no",
                "Box_agency", "Box_client", "Box_address", "Tfn", "Coupan_ad",
                "Ad_size_column", "Bill_column", "Bill_area",
                "Special_disc_per", "Space_disc_per",
                 AGENCY_MAST."Agency_Name" || '('|| AGENCY_MAST."code_subcode"|| ')' AS "AgencyName",
                (SELECT    EXEC_MAST."Exec_name" || '('|| TO_CHAR (EXEC_MAST."Exe_no")|| ')'
                   FROM EXEC_MAST  WHERE TBL_BOOKING_MAST_LOG."Executive_code" = EXEC_MAST."Exe_no"
                    AND TBL_BOOKING_MAST_LOG."Comp_code" = EXEC_MAST."comp_code")AS "execname",
                (SELECT    PRODUCT_CAT_MAST."prod_desc" || '(' || PRODUCT_CAT_MAST."prod_cat_code" || ')'
                   FROM PRODUCT_CAT_MAST WHERE TBL_BOOKING_MAST_LOG."Product_code" =PRODUCT_CAT_MAST."prod_cat_code"
                    AND TBL_BOOKING_MAST_LOG."Comp_code" =PRODUCT_CAT_MAST."comp_code")AS "product",
                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                "Contract_name", "Contract_type", "Card_name", "Card_type",
                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                "Bullet_code", "Bullet_premium",
                (SELECT "Agency_Name" FROM AGENCY_MAST WHERE "code_subcode" =TBL_BOOKING_MAST_LOG."Agency_sub_code")AS "AgencySubCode",
                NVL ((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code" = "Client_code"),'' ) AS "Client",
                (SELECT distinct "Payment_Mode_Name" FROM PAYMENT_MODE_MAST WHERE "Comp_Code"=compcode and "Pay_Mode_Code" = "Agency_pay") AS "PayMode",
                (SELECT "Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code" =TBL_BOOKING_MAST_LOG."Ad_cat_code")AS "categoryname",
                (SELECT "Adv_Subcat_Name" FROM ADV_SUBCAT_MAST WHERE ADV_SUBCAT_MAST."Adv_Subcat_Code" =TBL_BOOKING_MAST_LOG."Ad_sub_cat_code")AS "subcategoryname",
                (SELECT "brand_name" FROM BRAND_MST WHERE "brand_code" =TBL_BOOKING_MAST_LOG."Brand_code")AS "Brand",
                (SELECT "Uom_Name" FROM UOM_MAST WHERE "Uom_Code" =TBL_BOOKING_MAST_LOG."Uom_code")AS "UOM",
                (SELECT "premiumname" FROM ADVPOS_PREM_MAST  WHERE "Premiumcode" =TBL_BOOKING_MAST_LOG."Page_type_code")AS "PagePremium",
                (SELECT "Pos_Type" FROM ADVPOS_TYPE_MAST WHERE "Pos_Type_Code" = TBL_BOOKING_MAST_LOG."Page_position_code")AS "PositionPremium",
                (SELECT "Curr_Name" FROM CURR_MAST WHERE "Curr_Code" =TBL_BOOKING_MAST_LOG."Currency_code")AS "Currency"
           FROM TBL_BOOKING_MAST_LOG, AGENCY_MAST
          WHERE TBL_BOOKING_MAST_LOG."Receipt_no" = ciobookid
            AND VSEQNO =(SELECT MAX (VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" = ciobookid AND VSEQNO <
            (SELECT MAX(VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" = ciobookid) AND "audit" IS NOT NULL)
                        AND AGENCY_MAST."code_subcode" =
             TBL_BOOKING_MAST_LOG."Agency_sub_code" AND AGENCY_MAST."Comp_Code" = compcode;


   END Executebookingdispaudit_p;
END Executebookingdispaudit;
/

/*****************************************************************************************************************************************************************/



CREATE OR REPLACE PROCEDURE Reportnew1_agency_stmt(
    agname          IN  VARCHAR2:=NULL,
    clientname      IN  VARCHAR2:=NULL,
    adtype1         IN  VARCHAR2,
    Adcategory      IN  VARCHAR2,
    fromdate        IN  VARCHAR2,
    dateto          IN  VARCHAR2,
    compcode        IN  VARCHAR2,
    pub_name        IN  VARCHAR2,
    pub_cent        IN  VARCHAR2,
    status          IN  VARCHAR2:=NULL,
    edition         IN  VARCHAR2,
    dateformat      IN  VARCHAR2,
    hold            IN  VARCHAR2:=NULL,
    descid          IN  VARCHAR2:=NULL,
    ascdesc         IN  VARCHAR2:=NULL,
    agtype          in  varchar2:=null,
    puserid         in  varchar2:=null,
    chk_access      in  varchar2:=null,
    pextra1         in  varchar2:=null,--for UOM
    pextra2         in  varchar2:=null,
    pextra3         in  varchar2:=null,
    pextra4         in  varchar2:=null,
    pextra5         in  varchar2:=null,
    p_reportnew     OUT Cur_Type_New1.cursor_type)
IS

center      VARCHAR(50);
from_date   DATE;
date_to     DATE;
v_query     VARCHAR(8000);
a           number;
BEGIN
    v_query:=' SELECT m."Comp_code" as "COMP_CODE", (SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"=m."Comp_code") AS "companyname", 
    m."cio_booking_id" AS "CIOID",
    CASE '''||dateformat||'''WHEN ''mm/dd/yyyy'' THEN TO_CHAR(min(i."Insert_Date"),''mm/dd/yyyy'')
    WHEN ''dd/mm/yyyy'' THEN TO_CHAR(min(i."Insert_Date"),''dd/mm/yyyy'')
    WHEN ''yyyy/mm/dd'' THEN TO_CHAR(min(i."Insert_Date"),''yyyy/mm/dd'')  END AS "INS_DATE" ,
    a."Agency_Name" AS "AGENCY_NAME",(select "City_Name" from city_mst where "City_Code"=a."City_Code") as "AGENCY_CITY",a."Add1" as "ADD1",a."Add2" as "ADD2",a."Add3" as "ADD3",
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "CLIENT_NAME",
    case when instr(m."Package_code",'','') >0 then 
        FETCH_PACK_new(m."Comp_code", m."Package_code" ) 
    else
        (select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=m."Package_code")
    end AS "Package",
    i."Height" AS "Depth",i."Width" AS "Width",
    case when u.UOM_DESC=''CD'' then round(i."Size_Book",2) else 0 end AS "Area",
    case when u.UOM_DESC=''CD'' then 0 else i."Size_Book" end AS "Words",
    u.UOM_DESC as "uom",i."Col_Code" AS "Color_code",
    (SELECT ADVPOS_TYPE_MAST."Pos_Type_Alias" FROM ADVPOS_TYPE_MAST WHERE i."Page_Post"=ADVPOS_TYPE_MAST."Pos_Type_Code") AS "Page",
    m."Bullet_code" AS "BulletPremium" ,i."Page_Post" AS "PositionPremium" ,i."Premium1" AS "PagePremium" ,
    m."RO_No" AS "RoNo.",
    (SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=i."Ad_Cat") AS "AdCat",
    m."Card_rate" AS "CardRate",NVL("Agrred_rate",0) AS "AgreedRate",round(sum(i."Bill_Amt"),2) AS "Amt",
    m."Caption" AS "Cap",m."Key_no" AS "Key",

    sysdate as "Rundate",m.CASHDISCOUNT as "Cash_Disc", m."AUDIT_COMMENT" as "COMMENT",m."Dockit_no" as "DOCKIT_NO",
    i."No_Insert" as "No_Insert",
    case nvl(m."Agrred_rate",0) when 0 then m."Card_rate" else m."Agrred_rate"  end as "package rate",
    m."Special_discount" "Special_discount", m."Special_charges" "Special_charges", m."Trade_disc" "Trade_disc",
    (SELECT "premium_charges" FROM ADVPOS_PREM_MAST  WHERE   ADVPOS_PREM_MAST. "Premiumcode"=i."Premium1") AS "premiumch",
    sum(i."Card_Rate") "Card_Rate",m."Print_remark" as "Print_remark",i.bill_no as "BILL_NO",i.bill_date as "BILL_DATE"
    FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a,uom_mast u
    WHERE m."Comp_code"='''||compcode||'''
    AND m."cio_booking_id"=i."Cio_Booking_Id"
    and m."Agency_sub_code"=a."code_subcode" and m."Uom_code"=u."Uom_Code"
    AND not exists(select ''x'' from tbl_booking_mast where "prev_cioid"=m."cio_booking_id" and "prev_cioid" is not null)
    and  lower(i."Insert_Status") !=''cancel''
    and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where  newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
    or  ('''||chk_access||'''=''0'') )';


/*
IF(hold IS NOT NULL)THEN
v_query:=v_query||' and m."Insert_Status"!='''||'Cancel'||'''';

END IF;
*/
IF(agname IS NOT NULL) THEN
    v_query:=v_query||' and m."Agency_code" ='''||agname||'''';
END IF;

IF(clientname IS NOT NULL) THEN
    v_query:=v_query||' and m."Client_code"='''||clientname ||'''';
END IF;

IF(status IS NOT NULL) THEN
    v_query:=v_query||' and i."Insert_Status"='''||status||'''';
END IF;

IF(adtype1 IS NOT NULL) THEN
    v_query:=v_query||' and m."Ad_type_code"='''||adtype1||'''';
END IF;

IF(Adcategory IS NOT NULL) THEN
    a:=Fn_Splitfield(Adcategory,',');
    --v_query:=v_query||' and m."Ad_cat_code" in('''||Adcategory||''' )';
    v_query:=v_query||' and i."Ad_Cat" in(select "EDITION_NAME" from result  )';
END IF;


    IF(fromdate IS NOT NULL AND dateto IS NULL ) THEN
        v_query:=v_query||' and i."Insert_Date" ='''||fromdate||'''';
    END IF;

    IF(fromdate IS NOT NULL AND dateto IS NOT NULL ) THEN
        v_query:=v_query||' and i."Insert_Date" between  '''||fromdate ||''' and  '''||dateto||''' ';
    END IF;

IF(edition IS NOT NULL) THEN
    v_query:=v_query||'  and i."Edition_Code"='''||edition||'''';
END IF;

IF(pextra1 IS NOT NULL) THEN
    v_query:=v_query||'  and m."Uom_code"='''||pextra1||'''';
END IF;

IF(pub_name IS NOT NULL) THEN
    v_query:=v_query||' and  i."Publication_Code"='''||pub_name||'''';
END IF;

IF((agtype IS NOT NULL) AND (agtype <> 'Package') AND (agtype <> 'Solo')) THEN
    v_query:=v_query||' and  m."Agency_type"='''||upper(agtype)||'''';
END IF;


v_query:=v_query||' group by m."Comp_code", m."cio_booking_id",a."Agency_Name",a."City_Code",
    m."Client_code",m."Package_code",i."Height",i."Width",u.UOM_DESC,i."Col_Code",i."Page_Post",
    m."Bullet_code",i."Premium1",m."RO_No",i."Ad_Cat",m."Card_rate",m."Agrred_rate",m."Caption",m."Key_no",
    m.CASHDISCOUNT, m."AUDIT_COMMENT",m."Dockit_no",i."No_Insert",i."Size_Book",
    m."Special_discount", m."Special_charges" , m."Trade_disc",m."Print_remark",a."Add1",a."Add2",a."Add3",i.bill_no,i.bill_date';

IF(descid IS NOT  NULL) THEN
    v_query:=v_query||'  order by "'||descid||'"';
    v_query:=v_query||''||ascdesc||'';
ELSE
    v_query:=v_query||'  order by AGENCY_NAME,"INS_DATE","CIOID"';
END IF;

delete from searchtbl;insert into searchtbl values(v_query);commit;

OPEN p_reportnew FOR v_query;

END Reportnew1_agency_stmt;
/



CREATE OR REPLACE FUNCTION ad_bill_check_validate(pcompcode in varchar2,pcenter_code in varchar2,pdate in date,pextra1 varchar2,pextra2 varchar2) RETURN number IS
v_bildt date;
BEGIN

    select max(bildt) into v_bildt from ad_bills where comp_code_v=pcompcode and 
        exists(select 'x' from branch_mst where "pub_center"=pcenter_code);            

    if pdate>=v_bildt then
        return 0;
    else
        return 1;
    end if;
END;
/


===================from jaipur====End=============avinash====================



//////////////////////start of issue no 7292/////////////////////////

CREATE OR REPLACE PACKAGE HT18JULY.checkdatecomm
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE checkdatecomm_p (
      agencode        IN       VARCHAR2,
      userid          IN       VARCHAR2,
      compcode        IN       VARCHAR2,
      fromdatecomm    IN       VARCHAR2,
      tilldate        IN       VARCHAR2,
      agencysubcode   IN       VARCHAR2,
      adtype1         IN       VARCHAR2,
        uom11         IN       VARCHAR2,
      p_accounts      OUT      t_account_cursor
   );
END checkdatecomm;
/


CREATE OR REPLACE PACKAGE BODY HT18JULY.checkdatecomm
IS
   PROCEDURE checkdatecomm_p (
      agencode        IN       VARCHAR2,
      userid          IN       VARCHAR2,
      compcode        IN       VARCHAR2,
      fromdatecomm    IN       VARCHAR2,
      tilldate        IN       VARCHAR2,
      agencysubcode   IN       VARCHAR2,
      adtype1         IN       VARCHAR2,
         uom11         IN       VARCHAR2,
      p_accounts      OUT      t_account_cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
         SELECT "Comm_Code",
                TO_CHAR ("Eff_from_Date", 'mm/dd/yyyy') AS "Eff_from_Date",
                TO_CHAR ("Eff_Till_Date", 'mm/dd/yyyy') AS "Eff_Till_Date",
                "Comm_Rate", "Discount", "Comm_Code"
           FROM comm_details
          WHERE "Agency_sub_code" = agencysubcode
            AND "Agency_code" = agencode
            AND /*(   fromdatecomm = "Eff_from_Date"
                 OR tilldate = "Eff_Till_Date"
                 OR fromdatecomm BETWEEN "Eff_from_Date" AND "Eff_Till_Date"
                 OR tilldate BETWEEN "Eff_from_Date" AND "Eff_Till_Date"
                 OR "Eff_Till_Date" BETWEEN fromdatecomm AND tilldate
                 OR "Eff_from_Date" BETWEEN fromdatecomm AND tilldate
                )*/ "Eff_Till_Date" = tilldate
             and "ADTYPE"=adtype1 and ("UOM"=uom11 or "UOM"='0' or "UOM" is NULL);
   END checkdatecomm_p;
END checkdatecomm;
/


//////////////////////////////end of issue no 7292///////////////////

//////////////////////////////STart of Mimoh///17-05-2012////////////////


CREATE OR REPLACE PROCEDURE representative_summmery (
   fromdate     IN       VARCHAR2,
   dateto       IN       VARCHAR2,
   compcode     IN       VARCHAR2,
   pub_name     IN       VARCHAR2 := NULL,
   pub_cent     IN       VARCHAR2,
   DATEFORMAT   IN       VARCHAR2,
   descid       IN       VARCHAR2 := NULL,
   ascdesc      IN       VARCHAR2 := NULL,
   adtyp        IN       VARCHAR2,
   VALUE        IN       VARCHAR2,
   execut       IN       VARCHAR2,
   team         IN       VARCHAR2,
   bill         IN       VARCHAR2,
   cl           IN       VARCHAR2,
   ag           IN       VARCHAR2,
   retainer     IN       VARCHAR2,
   rep          IN       VARCHAR2,
   puserid      IN       VARCHAR2 := NULL,
   chk_access   IN       VARCHAR2 := NULL,
   pbrancode    IN       VARCHAR2,
   pdistcode    IN       VARCHAR2,
   pextra1      IN       VARCHAR,
   pextra2      IN       VARCHAR,
   pextra3      IN       VARCHAR,
   pextra4      IN       VARCHAR,
   pextra5      IN       VARCHAR,
   p_accounts   OUT      cur_type_new1.cursor_type
)
AS
   vquery      VARCHAR (8000);
   center      VARCHAR (50);
   reg         VARCHAR (900);
   from_date   DATE;
   date_to     DATE;
   sortorder   VARCHAR (100);
   vquery1     VARCHAR (1000);
   breakup     VARCHAR (8000);
   breakgrp    VARCHAR (1000);
BEGIN
   IF (fromdate IS NOT NULL AND dateto IS NULL)
   THEN
      from_date := fromdate;
      date_to := fromdate;
   ELSIF (fromdate IS NOT NULL AND dateto IS NOT NULL)
   THEN
      from_date := fromdate;
      date_to := dateto;
   END IF;

   IF (descid IS NOT NULL)
   THEN
      sortorder := descid;
   ELSIF (ascdesc IS NOT NULL)
   THEN
      sortorder := ascdesc;
   END IF;

------------------

   --Dbms_output.put_line(Vquery1);
   IF (descid IS NULL)
   THEN
      IF (rep = '2')
      THEN
         vquery1 := ' ORDER BY "Retainer" asc';
      ELSE
         vquery1 := ' ORDER BY "Executive" asc';
      END IF;
   ELSE
      vquery1 := vquery1 || 'order by "' || descid || '"';
      vquery1 := vquery1 || '' || ascdesc || '';
   END IF;

   vquery :=
         vquery
      || 'SELECT  i."Cio_Booking_Id" AS "CIOID",
a."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "Client",
(select COMBIN_MAST."Package_Name" from combin_mast where COMBIN_MAST."Combin_Code"  in(m."Package_code"))AS "Package",
CASE '''
      || DATEFORMAT
      || '''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date" ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''yyyy/mm/dd'') END AS "Ins.date" ,
m."Trade_disc" AS "Trade_disc" ,
m."Key_no" AS "Key" ,
m."RO_No" AS "Ro.No.",
TO_CHAR(m."RO_Date",''dd-Mon-yyyy'') AS "Ro.Date",
i.BILL_NO as "BILL_NO", 
i.BILL_DATE as "BILL_DATE", 
NVL(i."Bill_Amt",''0'') AS "Bill_Amt",
i."Remarks" as "Remarks",
i.CAPTION as "CAPTION",
NVL(i."Card_Rate" ,''0'') AS "Card_Rate",
NVL(i."Agreed_Rate" ,''0'') AS "Agreed_Rate",
(select EXEC_MAST."Exec_name" from exec_mast where  m."Executive_code"=EXEC_MAST."Exe_no") AS "Executive",
(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=i."Ad_Cat" ) as "Adcat",
(select Retainermaster."Retain_Alias" from Retainermaster where  m."RETAINER"=Retainermaster."Retain_Code") as "Retainer",
DECODE( DECODE("Agency_Type_Code",''IA0'',''GOVT.'',''DA0'',''GOVT.''),''GOVT.'',''GOVT.'', DECODE(a."State_Code",''ORISSA'',''LOCAL'',''NATIONAL'') )  AS "FinalGRP",
i."Edition" as "edition",
(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''
      || compcode
      || ''') AS "companyname",
sysdate as "Rundate",i."Height",i."Width",i."Size_Book"

FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a 
WHERE m."Comp_code"='''
      || compcode
      || ''' AND m."cio_booking_id"=i."Cio_Booking_Id"
AND m."Agency_sub_code"=a."code_subcode" 
AND "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
and  lower("Insert_Status") !=''cancel''
and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''
      || puserid
      || ''') and '''
      || chk_access
      || '''=''1'')
or  ('''
      || chk_access
      || '''=''0'') )
AND  "Insert_Date" BETWEEN '''
      || from_date
      || ''' AND '''
      || date_to
      || '''
AND (m."Ad_type_code"='''
      || adtyp
      || ''' OR '''
      || adtyp
      || '''  IS NULL)
AND (i."Pub_Cent_Code"='''
      || pub_cent
      || ''' OR '''
      || pub_cent
      || ''' IS NULL)
AND (m."Revenue_center"='''
      || pub_name
      || ''' OR '''
      || pub_name
      || '''  IS NULL)
AND (m."Executive_code"  = '''
      || execut
      || ''' OR '''
      || execut
      || '''  IS NULL)
AND (m."Executive_code" in (select exec_mast."Exe_no" from exec_mast where  EXEC_MAST."Team_code"  = '''
      || team
      || ''' OR '''
      || team
      || ''' IS NULL ) OR '''
      || team
      || ''' IS NULL )
AND ("Client_code"  = '''
      || cl
      || ''' OR '''
      || cl
      || ''' IS NULL)
AND (m."Agency_code"  = '''
      || ag
      || ''' OR '''
      || ag
      || ''' IS NULL)
AND (m.RETAINER  = '''
      || retainer
      || ''' OR '''
      || retainer
      || ''' IS NULL)
AND (('''
      || rep
      || '''=''2'' and m."RETAINER" is not null and m."RETAINER"!=''0'')or('''
      || rep
      || '''=''1'' and m."Executive_code" is not null and m."Executive_code" !=''0''))';
   vquery := vquery || vquery1;

   DELETE FROM searchtbl;

   INSERT INTO searchtbl
        VALUES (vquery);

   COMMIT;

   OPEN p_accounts FOR vquery;
END representative_summmery;
/

//////////////////////////////End of Mimoh///17-05-2012////////////////


/************7561***********mimoh 22 may 2012*****************************************************/



CREATE OR REPLACE PACKAGE Wesp_Updatedate
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
P_misdata IN VARCHAR2
);
END      Wesp_Updatedate;
/



DROP PACKAGE BODY ERP_TEST.WESP_UPDATEDATE;

CREATE OR REPLACE PACKAGE BODY ERP_TEST.Wesp_Updatedate IS
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
P_misdata IN VARCHAR2

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
=P_GEN_RCT_TYP,PRODUCT_BRAND_REQ=P_misdata


  WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/
/**************************************************************************************************************************/




CREATE OR REPLACE PACKAGE ERP_TEST.Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/




CREATE OR REPLACE PACKAGE BODY ERP_TEST.currbindpreferpgld
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
                cir_wieght_calc_req, gen_rct_typ, product_brand_req
           FROM preferrences
          WHERE "comp_code" = compcode;
   END currbindpreferpgld_p;
END currbindpreferpgld;
/





/****************7561*******mimoh 22 may 2012*****************************************************/

==============6189=====avinash==23may2012===================================

CREATE OR REPLACE PROCEDURE HT18JULY.Ro_Report
(pcompcode      in varchar2,
 pdateformat    in varchar2,
 puserid        in varchar2,
 chk_access     in varchar2,
 pfromdate      in varchar2,
 pdateto        in varchar2,
 pprint_cent    in varchar2,
 pagency        in varchar2,
 pbranch        in varchar2,
 pdistrict      in varchar2,
 ptaluka        in varchar2,
 pro_doc_status in varchar2,
 ppay_mode      in varchar2,
 pexecutive     in varchar2,
 pretainer      in varchar2,
 det_summry     in varchar2,
 age_exeret     in varchar2,
 pad_type       in varchar2,
 pad_cat        in varchar2,
 ptype          in varchar2,
 p_accounts     OUT Cur_Type_New1.cursor_type,
 p_accounts1    OUT Cur_Type_New1.cursor_type)
IS
query1      varchar2(10000);
vvar        varchar2(4000);
vvar_sum    varchar2(4000);
BEGIN
    if(age_exeret='1')then/*fot agency*/
        if(det_summry='1')then/*for detail*/
            query1:='select distinct a."cio_booking_id" as  "BOOKING_ID",b."Agency_Name" AS "AGENCY", 
            nvl((select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") ,(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER )) as "EXE_RET",
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            c."Adv_Cat_Name" as "Ad_Cat",
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT",
            min(TO_CHAR(i."Insert_Date",'''||pdateformat||''')) as "Publish_Date",a.RO_COMMENT as RO_COMMENT
            from tbl_booking_mast a ,tbl_booking_insert i ,agency_mast b,adv_cat_mast c where
            a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' 
            AND a."Comp_code"=i."Comp_Code" 
            
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            
            AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Agency_sub_code"=b."code_subcode"  and lower(i."Insert_Status")<>''cancel''';
        else/* for summary*/
            query1:='select DISTINCT b."Agency_Name" AS "AGENCY",
            b."Dist_Code"  as "DISTRICT",
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
          
            SUM(DECODE(RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,agency_mast b/*,adv_cat_mast c*/
            where  
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Agency_sub_code"=b."code_subcode" 
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            and i."Insert_Status"<>''cancel''';
        end if;
    else/* for  executive/retainer*/
        if(det_summry='1')then/*for detail*/
           /* query1:='select a."cio_booking_id" as  "BOOKING_ID",
            b."Agency_Name" AS "AGENCY",
            --(select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") AS "EXECUTIVE",
            --(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER ) AS "RETAINER",
            nvl((select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") ,(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER )) as "EXE_RET",
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT"
            from tbl_booking_mast a ,agency_mast b where
            a."Comp_code"='''||pcompcode||''' AND
            a."Agency_sub_code"=b."code_subcode"';*/
              if(age_exeret='2')then
            query1:='select distinct
            a."cio_booking_id" as  "BOOKING_ID",
            b."Agency_Name" AS "AGENCY",           
            EXEC_MAST."Exec_name"  as "EXE_RET",      
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            c."Adv_Cat_Name" as "Ad_Cat",            
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT",
            min(TO_CHAR(i."Insert_Date",'''||pdateformat||''')) as "Publish_Date",a.RO_COMMENT as RO_COMMENT
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,EXEC_MAST,agency_mast b ,adv_cat_mast c
            where a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" 
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Executive_code"=exec_mast."Exe_no" AND 
             a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel'' ';
         else
          query1:='select distinct
            a."cio_booking_id" as  "BOOKING_ID",
            b."Agency_Name" AS "AGENCY",  
             RETAINERMASTER."Retain_Name"     as "EXE_RET",
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            c."Adv_Cat_Name" as "Ad_Cat",            
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT",
            min(TO_CHAR(i."Insert_Date",'''||pdateformat||''')) as "Publish_Date",a.RO_COMMENT as RO_COMMENT
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER,agency_mast b ,adv_cat_mast c
            where a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code"
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
             AND a."cio_booking_id"=i."Cio_Booking_Id" and
            RETAINERMASTER."Retain_Code"=a.RETAINER AND 
             a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel'' ';
            end if;
        else/* for summary*/
         
         if(age_exeret='2')then
            query1:='select distinct  
             EXEC_MAST."Exec_name"  as "EXE_RET",      
             EXEC_MAST."dist_code"  as "DISTRICT",
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
             
            SUM(DECODE(a.RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(a.RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(a.RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(a.RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,EXEC_MAST ,agency_mast b /*,adv_cat_mast c*/
            where  
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Executive_code"=exec_mast."Exe_no" 
            and a."Agency_sub_code"=b."code_subcode" 
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            and i."Insert_Status"<>''cancel'' ';
         else
          query1:='select distinct 
            
             RETAINERMASTER."Retain_Name"     as "EXE_RET",
           
             RETAINERMASTER."Dist_Code"   as "DISTRICT",
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
           
            SUM(DECODE(a.RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(a.RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(a.RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(a.RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER ,agency_mast b/*,adv_cat_mast c*/
            where 
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" 
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            AND a."cio_booking_id"=i."Cio_Booking_Id" and
            RETAINERMASTER."Retain_Code"=a.RETAINER 
            and a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel'' ';
            end if;
        end if;
    end if;

    if(pfromdate is not null and pdateto is not null)then
        query1:=query1||' and a."date_time" between '''||pfromdate||''' and '''||pdateto||''' ';
    end if;
    
    if(pad_type is not null)then
        query1:=query1||' and a."Ad_type_code" = '''||pad_type||''' ';
    end if;

    if(pad_cat is not null)then
        query1:=query1||' and a."Ad_cat_code" = '''||pad_cat||''' ';
    end if;
    
    if(pagency is not null)then
        query1:=query1||' and a."Agency_code" = '''||pagency||''' ';
    end if;    
  --new version 

   if(pprint_cent is not null)then
        query1:=query1||' and a."branch" IN  (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code"  and "pub_center"='''||pprint_cent||''') ';
    end if;

    if(pbranch is not null)then
        query1:=query1||'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''||pbranch||''') ';
    end if;
    
--old version
   /* 
    if(pprint_cent is not null)then
        query1:=query1||' and a."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE a."branch"="Branch_Name" and "pub_center"='''||pprint_cent||''') ';
    end if;


    if(pbranch is not null)then
        query1:=query1||' and a."branch"='''||pbranch||'''';
    end if;
*/
    
    if(pdistrict is not null)then
        if(age_exeret='1')then
            query1:=query1||' and b."Dist_Code" = '''||pdistrict||''' ';
         elsif(age_exeret='2')then
            query1:=query1||' and (a."Executive_code" IS NOT NULL AND a."Executive_code" in(select exec_mast."Exe_no" from exec_mast  where EXEC_MAST."dist_code"='''||pdistrict||''' ) ) ';
        else
            query1:=query1||' and  (a.RETAINER IS NOT NULL AND a.RETAINER IN(SELECT RETAINERMASTER."Retain_Code" FROM RETAINERMASTER WHERE RETAINERMASTER."Dist_Code"='''||pdistrict||''')) ';
        end if;
    end if;
    if(ptaluka is not null)then
        if(age_exeret='1')then
            query1:=query1||' and b.TALUKA = '''||ptaluka||''' ';
        elsif(age_exeret='2')then
            query1:=query1||' and (a."Executive_code" IS NOT NULL AND a."Executive_code" in(select exec_mast."Exe_no" from exec_mast  where EXEC_MAST."TALUKA"='''||ptaluka||'''  ) ) ';
        else
            query1:=query1||' and (a.RETAINER IS NOT NULL AND a.RETAINER IN(SELECT RETAINERMASTER."Retain_Code" FROM RETAINERMASTER WHERE RETAINERMASTER."TALUKA"='''||ptaluka||''' )) ';
        end if;
    end if;

    if (pro_doc_status is not null) then
        if pro_doc_status ='0' then
            query1:=query1||' and nvl(a."RODOCSTATUS",''0'') = '''||pro_doc_status||''' ';
        else
            query1:=query1||' and a."RODOCSTATUS" = '''||pro_doc_status||''' ';
        end if;    
    end if;

    if(ppay_mode is not null)then
        query1:=query1||' and a."Bill_pay" = '''||ppay_mode||''' ';
    end if;

    if(pexecutive is not null)then
        query1:=query1||' and a."Executive_code" = '''||pexecutive||''' ';
    end if;

    if(pretainer  is not null)then
        query1:=query1||' and a.RETAINER = '''||pretainer||''' ';
    end if;

--new version
  query1:=query1||' and a."branch" in(select lb.branch_code from login_branch_mast lb where  lb.user_code='''||puserid||''' and nvl(lb.user_flag,''N'')=''Y'') ' ;
--old version
   -- query1:=query1||' and a."branch" in(select branch_mst."Branch_Name" from branch_mst where branch_mst."Branch_Code" in (select lb.branch_code from login_branch_mast lb where  lb.user_code='''||puserid||''' and nvl(lb.user_flag,''N'')=''Y'')) ' ;

    if(ptype is not null)then
        if ptype='U' then
            query1:=query1||' and (i."Comp_Code"||i.bill_no||i.bill_date in(select /*+ (AD_OUTSTAND IND_OUT) */ o.comp_code||o.billno||o.billdt 
                        from ad_outstand o where o.comp_code=i."Comp_Code" and o.ag_main_code=b."Agency_Code" and 
                        o.ag_sub_code=b."SUB_Agency_Code" and o.billdt=i.bill_date and o.billno=i.bill_no 
                        group by o.comp_code,o.billno,o.billdt having sum(o.amount)>=10) OR i.bill_no IS NULL ) ';
        else 
            query1:=query1||' and i."Comp_Code"||i.bill_no||i.bill_date in(select /*+ (AD_OUTSTAND IND_OUT) */ o.comp_code||o.billno||o.billdt 
                        from ad_outstand o where o.comp_code=i."Comp_Code" and o.ag_main_code=b."Agency_Code" and 
                        o.ag_sub_code=b."SUB_Agency_Code" and o.billdt=i.bill_date and o.billno=i.bill_no 
                        group by o.comp_code,o.billno,o.billdt having sum(o.amount)=0)';
        end if;                
    end if;
    
    if(det_summry!='1')then/*for summary*/
        if(age_exeret='1')then/*fot agency*/
            query1:=query1||' GROUP BY b."Agency_Name" ,b."Dist_Code"  ,a."branch"';
        elsif(age_exeret='2')then
            query1:=query1||' group by EXEC_MAST."Exec_name",EXEC_MAST."dist_code",a."branch"';
        else
            query1:=query1||' GROUP BY RETAINERMASTER."Retain_Name",RETAINERMASTER."Dist_Code",a."branch"';
        end if;
        else
        
        if(age_exeret='1')then/*fot agency*/
            query1:=query1||' GROUP BY a."cio_booking_id"  ,b."Agency_Name"   ,a."Executive_code",a.RETAINER,"Client_code",c."Adv_Cat_Name","RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT';
        elsif(age_exeret='2')then
            query1:=query1||' group by a."cio_booking_id"  ,b."Agency_Name",EXEC_MAST."Exec_name","Client_code",c."Adv_Cat_Name" ,"RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT ';
        else
            query1:=query1||' GROUP BY a."cio_booking_id"  ,b."Agency_Name",RETAINERMASTER."Retain_Name","Client_code",c."Adv_Cat_Name" ,"RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT';
        end if;
        
        
        
    end if;

  delete from searchtbl;
    insert into searchtbl values(query1);commit;


    OPEN p_accounts FOR query1;
    open p_accounts1 for
    select comp_mst."Comp_Name" from comp_mst where comp_mst."Comp_Code"=pcompcode;
END Ro_Report;
/

============end========6189========avinash===========================================



////////////////////////////start by shipra/////////////////////
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
P_allowpremium IN VARCHAR2
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
P_allowpremium IN VARCHAR2

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
=P_GEN_RCT_TYP,PRODUCT_BRAND_REQ=P_misdata,ALLOWPREM_CARD_DISC_RATE=P_allowpremium


  WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/



//////////////////////////////////end by shipra/////////////////////////////////






////////------------issue no7583//////////////////////////////////////////////



CREATE OR REPLACE PACKAGE HT18JULY.AdvTeamDetail
is
Type T_Accounts_Cursor is Ref Cursor;

procedure AdvTeamDetail_p
(
Comp_Code in varchar2,
Team_Code in varchar2,
Team_Name in varchar2,
userid in varchar2,
zone in varchar2,
Flag in varchar2,
attachment in varchar2,
signature in varchar2,

P_Accounts out T_Accounts_Cursor,
P_Accounts1 out T_Accounts_Cursor
);

end  AdvTeamDetail;
/






CREATE OR REPLACE package  body                                                                                                    HT18JULY.AdvTeamDetail
is
procedure AdvTeamDetail_p
(
Comp_Code in varchar2,
Team_Code in varchar2,
Team_Name in varchar2,
userid in varchar2,
zone in varchar2,
Flag in varchar2,
attachment in varchar2,
signature in varchar2,

P_Accounts out T_Accounts_Cursor,
P_Accounts1 out T_Accounts_Cursor

) as

countnum number;

--set "Team_Code"=replace("Team_Code",'','''')
begin

if(Flag='0')then
open P_Accounts for
select  "Comp_Code","Team_Code","Team_Name","Userid","Creation_Datetime","ad_cat","branch_code","SIGN",ATTACHMENT  from Adv_Exec_Master
 where "Comp_Code"=Comp_Code /*and "Userid"=userid*/
AND ("Team_Code" LIKE Team_Code||'%' OR Team_code IS NULL)
AND ("Team_Name" LIKE Team_Name||'%' OR Team_Name IS NULL)
AND ("branch_code" LIKE zone||'%' OR zone IS NULL);

end if;

open P_Accounts1 for
select * from Adv_Exec_Master where  "Comp_Code" = Comp_Code; -- and "Userid"=userid;

if(Flag='1')then
insert into Adv_Exec_Master("Comp_Code","Team_Code","Team_Name","Userid","Creation_Datetime","branch_code","SIGN") values(Comp_Code,Team_Code,Team_Name,userid,sysdate,zone,signature);
 commit;
end if;

if(Flag=2)then
update Adv_Exec_Master set "Team_Name"=Team_Name , "branch_code"=zone,
"SIGN"=signature, "ATTACHMENT"=attachment 
where "Team_Code"=Team_Code and "Comp_Code"=Comp_Code;
-- update exec_mast set "Branch_code"=zone where "Team_code"=Team_Code and "comp_code"=Comp_Code;
commit;
open P_Accounts for select sysdate from dual;
open P_Accounts1 for select sysdate from dual;

end if;

if(Flag=3)then
select count(*) into countnum from tbl_booking_mast where "Executive_code" in(select "Exe_no" from exec_mast where "Team_code" = Team_Code);
if countnum=0 then
delete from Adv_Exec_Master where "Comp_Code"=Comp_Code and "Team_Code" = Team_Code and "Team_Name"= Team_Name and "branch_code"=zone;
delete from Exec_mast where "comp_code" = Comp_Code and "Team_code" = Team_Code;
delete from exec_adcat where TEAMCODE=Team_Code;
end if;
end if;


if(Flag=5)then
open P_Accounts for
select * from exec_mast where  "comp_code" = Comp_Code and "Team_code" = Team_Code;
end if;


if(Flag=6)then
open P_Accounts for
select * from adv_exec_master where "Comp_Code" = Comp_Code and "Team_Code" = Team_Code;
end if;

end AdvTeamDetail_p;
end AdvTeamDetail;
/






CREATE OR REPLACE PACKAGE HT18JULY.AdvTeamDetailSave is

procedure AdvTeamDetailSave_p(
Comp_Code in varchar2,
Team_Code in varchar2,
Team_Name in varchar2,
userid in varchar2,
zone in varchar2,
attachment in varchar2,
signature in varchar2
);
end AdvTeamDetailSave;
/





CREATE OR REPLACE PACKAGE BODY HT18JULY.AdvTeamDetailSave is

procedure AdvTeamDetailSave_p(Comp_Code in varchar2,
Team_Code in varchar2,
Team_Name in varchar2,
userid in varchar2,
zone in varchar2,
attachment in varchar2,
signature in varchar2)as
begin

 insert into Adv_Exec_Master("Comp_Code","Team_Code","Team_Name","Userid","Creation_Datetime","branch_code","SIGN",ATTACHMENT) values(Comp_Code,Team_Code,Team_Name,userid,sysdate,zone,signature,attachment);

commit;

end  AdvTeamDetailSave_p;
end AdvTeamDetailSave;
/






///////////////////////////////end of issue 7583//////////////////////

===========7600=avinash=================24-05-2012=======================
CREATE OR REPLACE PACKAGE HT18JULY.rpt_issue_pcentre_wise IS
TYPE t_accounts_cursor IS REF CURSOR;
PROCEDURE rpt_issue_pcentre_wise_p(
pcompcode       IN VARCHAR2,
ppubcent           IN VARCHAR2,
pedtncode       IN VARCHAR2,
pfrom_date      IN VARCHAR2,
ptill_date      IN VARCHAR2,
pdateformat     IN VARCHAR2,
puserid            IN VARCHAR2,
chk_access in varchar2:=null,
pratio_type in varchar2:=null,
pextra1 in varchar2:=null,
pextra2 in varchar2:=null,
pagtype in varchar2,
p_accounts      OUT t_accounts_cursor,
p_accounts1     OUT t_accounts_cursor );
PROCEDURE rpt_issue_insertion_pcentre_p(
 pcompcode       IN VARCHAR2,
    ppubcent        IN VARCHAR2,
    pedtncode       IN VARCHAR2,
    pfrom_date      IN VARCHAR2,
    ptill_date      IN VARCHAR2,
    pdateformat     IN VARCHAR2,
    puserid         IN VARCHAR2,
    ppubl         IN VARCHAR2,
     pdist         IN VARCHAR2,
      pbranch         IN VARCHAR2,
    chk_access      IN varchar2:=null,
    pratio_type     IN varchar2:=null,
    pextra1         IN varchar2:=null,
    pextra2         IN varchar2:=null,
    p_accounts      OUT t_accounts_cursor);
    PROCEDURE rpt_Issue_Billwise_report_p(
pcompcode       IN VARCHAR2,
ppubcent       	IN VARCHAR2,
pedtncode       IN VARCHAR2,
pfrom_date      IN VARCHAR2,
ptill_date      IN VARCHAR2,
pdateformat     IN VARCHAR2,
puserid			IN VARCHAR2,
chk_access in varchar2:=null,
pratio_type in varchar2:=null,
pextra1 in varchar2:=null,
pextra2 in varchar2:=null,
p_accounts1      OUT t_accounts_cursor,
p_accounts2    OUT t_accounts_cursor );
END rpt_issue_pcentre_wise;
/


=========end=====avinash======24-05-2012=============================





//////////////////////////////issue no 7584//////////////////////////



CREATE OR REPLACE PACKAGE HT18JULY.RetainerInsertDetail Is



Type T_Accounts_Cursor Is Ref Cursor;
Procedure RetainerInsertDetail_P (Comp_Code1  in varchar2,
Retain_Code1  in varchar2,
userid1 in varchar2,
Retain_Name1 in varchar2,
Retain_Alias1 in varchar2,
Add11 in varchar2 ,
Street1 in varchar2 ,
City_Code1 in varchar2,
pubcent   in varchar2,
Zip1 in varchar2 ,
Dist_Code1 in varchar2 ,
State_Code1 in varchar2,
zone_code1 in varchar2,
region_code1 in varchar2,
Country_Code1 in varchar2,
phone11 in varchar2,
Phone21 in varchar2 ,
Fax1 in varchar2 ,
EmailID1 in varchar2 ,
PAN_No1 in varchar2 ,
Credit_Days1 in varchar2,
Remarks1 in varchar2 ,
flag in number,
Box in varchar2,
Publication1 in varchar2,
Edition1 in varchar2,
Supplement1 in varchar2,
taluka1 in varchar2,
repname in varchar2,
branchcode in varchar2,
creditlimit in varchar2,
mobile1 in varchar2,
signature in varchar2,
p_empcode in varchar2,
attachment in varchar2,
p_maincdp in varchar2
);

End RetainerInsertDetail;
/


















CREATE OR REPLACE PACKAGE BODY HT18JULY.RetainerInsertDetail Is

Procedure RetainerInsertDetail_P (Comp_Code1  in varchar2,
Retain_Code1 in varchar2,
userid1 in varchar2,
Retain_Name1 in varchar2,
Retain_Alias1 in varchar2,
Add11 in varchar2 ,
Street1 in varchar2 ,
City_Code1 in varchar2,
pubcent   in varchar2,
Zip1 in varchar2 ,
Dist_Code1 in varchar2 ,
State_Code1 in varchar2,
zone_code1 in varchar2,
region_code1 in varchar2,
Country_Code1 in varchar2,
phone11 in varchar2,
Phone21 in varchar2 ,
Fax1 in varchar2 ,
EmailID1 in varchar2 ,
PAN_No1 in varchar2 ,
Credit_Days1 in varchar2,
Remarks1 in varchar2 ,
flag in number,
Box in varchar2,
Publication1 in varchar2,
Edition1 in varchar2,
Supplement1 in varchar2,
taluka1 in varchar2,
repname in varchar2,
branchcode in varchar2,
creditlimit in varchar2,
mobile1 in varchar2,
signature in varchar2,
p_empcode in varchar2,
attachment in varchar2,
p_maincdp in varchar2
) As

  Begin
    if flag = '0' then
   insert into RetainerMaster("Comp_Code" ,"Retain_Code" ,"userid" ,"Retain_Name" ,"Retain_Alias" ,"Add1" ,"Street" ,"City_Code" ,"Zip" ,"Dist_Code" ,"State_Code" ,"Zone_Code","Region_Code","Country_Code" ,"Phone1" ,"Phone2" ,"Fax" ,"EmailID" ,"PAN_No" ,"Credit_Days","Remarks" , "pubcent_code","Creation_Datetime", "Retain_status", "To_date","BOXMATTER","PUBLICATION","EDITION","SUPPLEMENT","TALUKA",REPRESENTATIVE,"Branch_code",CREDIT_LIMIT,MOBILENO,"SIGN",HR_CODE,CDP,ATTACHMENT)values (Comp_Code1,Retain_Code1,userid1,Retain_Name1,Retain_Alias1,Add11,Street1,City_Code1,Zip1,Dist_Code1,State_Code1,zone_code1,region_code1,Country_Code1,phone11,Phone21,Fax1,EmailID1,PAN_No1,Credit_Days1,Remarks1,pubcent,sysdate,'','',Box,Publication1,Edition1,Supplement1,taluka1,repname,branchcode,creditlimit,mobile1,signature,p_empcode,p_maincdp,attachment) ;
   else
   update RetainerMaster set "Retain_Name" = Retain_Name1  ,"Retain_Alias" =Retain_Alias1 ,"Add1" = Add11,"Street" = Street1,"City_Code" =City_Code1 ,"Zip" = Zip1,  "Dist_Code" = Dist_Code1 ,"State_Code" = State_Code1 ,"Zone_Code" = zone_code1,"Region_Code" = region_code1,"Country_Code" = Country_Code1,"Phone1" = phone11,"Phone2" =Phone21,"Fax" =Fax1 ,"EmailID" =EmailID1 ,"PAN_No" = PAN_No1,"Credit_Days" = Credit_Days1,"Remarks" =Remarks1, "pubcent_code"=pubcent, "BOXMATTER"=Box,"PUBLICATION"=Publication1,"EDITION"=Edition1,"SUPPLEMENT"=Supplement1,"TALUKA"=taluka1,REPRESENTATIVE=repname,"Branch_code"=branchcode,CREDIT_LIMIT=creditlimit,MOBILENO=mobile1,"SIGN"=signature,HR_CODE =p_empcode,CDP=p_maincdp where "Comp_Code" = Comp_Code1 and "Retain_Code" = Retain_Code1;
   end if;
    commit;
   End RetainerInsertDetail_P;
 End RetainerInsertDetail;
/

//////////////////////////////////end of issue 7584/////////////


/////////////////////////////////issue no 7579///////////////////////



CREATE OR REPLACE PROCEDURE HT18JULY.Ro_Report
(pcompcode      in varchar2,
 pdateformat    in varchar2,
 puserid        in varchar2,
 chk_access     in varchar2,
 pfromdate      in varchar2,
 pdateto        in varchar2,
 pprint_cent    in varchar2,
 pagency        in varchar2,
 pbranch        in varchar2,
 pdistrict      in varchar2,
 ptaluka        in varchar2,
 pro_doc_status in varchar2,
 ppay_mode      in varchar2,
 pexecutive     in varchar2,
 pretainer      in varchar2,
 det_summry     in varchar2,
 age_exeret     in varchar2,
 pad_type       in varchar2,
 pad_cat        in varchar2,
 ptype          in varchar2,
 p_accounts     OUT Cur_Type_New1.cursor_type,
 p_accounts1    OUT Cur_Type_New1.cursor_type)
IS
query1      varchar2(10000);
vvar        varchar2(4000);
vvar_sum    varchar2(4000);
BEGIN
    if(age_exeret='1')then/*fot agency*/
        if(det_summry='1')then/*for detail*/
            query1:='select distinct a."cio_booking_id" as  "BOOKING_ID",b."Agency_Name" AS "AGENCY", 
            nvl((select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") ,(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER )) as "EXE_RET",
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            c."Adv_Cat_Name" as "Ad_Cat",
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT",
            min(TO_CHAR(i."Insert_Date",'''||pdateformat||''')) as "Publish_Date",a.RO_COMMENT as RO_COMMENT
            ,a."branch" as BRANCH
            ,a."Bill_pay" PAY_MODE_CODE
            ,(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=a."Comp_code" and "Pay_Mode_Code"=a."Bill_pay") PAY_MODE_NAME
            from tbl_booking_mast a ,tbl_booking_insert i ,agency_mast b,adv_cat_mast c where
            a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' 
            AND a."Comp_code"=i."Comp_Code" 
            
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            
            AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Agency_sub_code"=b."code_subcode"  and lower(i."Insert_Status")<>''cancel''';
        else/* for summary*/
            query1:='select DISTINCT b."Agency_Name" AS "AGENCY",
            b."Dist_Code"  as "DISTRICT",
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
          
            SUM(DECODE(RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,agency_mast b/*,adv_cat_mast c*/
            where  
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Agency_sub_code"=b."code_subcode" 
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            and i."Insert_Status"<>''cancel''';
        end if;
    else/* for  executive/retainer*/
        if(det_summry='1')then/*for detail*/
           /* query1:='select a."cio_booking_id" as  "BOOKING_ID",
            b."Agency_Name" AS "AGENCY",
            --(select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") AS "EXECUTIVE",
            --(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER ) AS "RETAINER",
            nvl((select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") ,(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER )) as "EXE_RET",
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT"
            from tbl_booking_mast a ,agency_mast b where
            a."Comp_code"='''||pcompcode||''' AND
            a."Agency_sub_code"=b."code_subcode"';*/
              if(age_exeret='2')then
            query1:='select distinct
            a."cio_booking_id" as  "BOOKING_ID",
            b."Agency_Name" AS "AGENCY",           
            EXEC_MAST."Exec_name"  as "EXE_RET",      
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            c."Adv_Cat_Name" as "Ad_Cat",            
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT",
            min(TO_CHAR(i."Insert_Date",'''||pdateformat||''')) as "Publish_Date",a.RO_COMMENT as RO_COMMENT
             ,a."Bill_pay" PAY_MODE_CODE
            ,(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=a."Comp_code" and "Pay_Mode_Code"=a."Bill_pay") PAY_MODE_NAME
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,EXEC_MAST,agency_mast b ,adv_cat_mast c
            where a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" 
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Executive_code"=exec_mast."Exe_no" AND 
             a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel'' ';
         else
          query1:='select distinct
            a."cio_booking_id" as  "BOOKING_ID",
            b."Agency_Name" AS "AGENCY",  
             RETAINERMASTER."Retain_Name"     as "EXE_RET",
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            c."Adv_Cat_Name" as "Ad_Cat",            
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT",
            min(TO_CHAR(i."Insert_Date",'''||pdateformat||''')) as "Publish_Date",a.RO_COMMENT as RO_COMMENT
             ,a."Bill_pay" PAY_MODE_CODE
            ,(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=a."Comp_code" and "Pay_Mode_Code"=a."Bill_pay") PAY_MODE_NAME
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER,agency_mast b ,adv_cat_mast c
            where a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code"
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
             AND a."cio_booking_id"=i."Cio_Booking_Id" and
            RETAINERMASTER."Retain_Code"=a.RETAINER AND 
             a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel'' ';
            end if;
        else/* for summary*/
         
         if(age_exeret='2')then
            query1:='select distinct  
             EXEC_MAST."Exec_name"  as "EXE_RET",      
             EXEC_MAST."dist_code"  as "DISTRICT",
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
             
            SUM(DECODE(a.RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(a.RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(a.RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(a.RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,EXEC_MAST ,agency_mast b /*,adv_cat_mast c*/
            where  
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Executive_code"=exec_mast."Exe_no" 
            and a."Agency_sub_code"=b."code_subcode" 
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            and i."Insert_Status"<>''cancel'' ';
         else
          query1:='select distinct 
            
             RETAINERMASTER."Retain_Name"     as "EXE_RET",
           
             RETAINERMASTER."Dist_Code"   as "DISTRICT",
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
           
            SUM(DECODE(a.RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(a.RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(a.RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(a.RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER ,agency_mast b/*,adv_cat_mast c*/
            where 
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" 
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            AND a."cio_booking_id"=i."Cio_Booking_Id" and
            RETAINERMASTER."Retain_Code"=a.RETAINER 
            and a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel'' ';
            end if;
        end if;
    end if;

    if(pfromdate is not null and pdateto is not null)then
        query1:=query1||' and a."date_time" between '''||pfromdate||''' and '''||pdateto||''' ';
    end if;
    
    if(pad_type is not null)then
        query1:=query1||' and a."Ad_type_code" = '''||pad_type||''' ';
    end if;

    if(pad_cat is not null)then
        query1:=query1||' and a."Ad_cat_code" = '''||pad_cat||''' ';
    end if;
    
    if(pagency is not null)then
        query1:=query1||' and a."Agency_code" = '''||pagency||''' ';
    end if;    
  --new version 

   if(pprint_cent is not null)then
        query1:=query1||' and a."branch" IN  (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code"  and "pub_center"='''||pprint_cent||''') ';
    end if;

    if(pbranch is not null)then
        query1:=query1||'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''||pbranch||''') ';
    end if;
    
--old version
   /* 
    if(pprint_cent is not null)then
        query1:=query1||' and a."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE a."branch"="Branch_Name" and "pub_center"='''||pprint_cent||''') ';
    end if;


    if(pbranch is not null)then
        query1:=query1||' and a."branch"='''||pbranch||'''';
    end if;
*/
    
    if(pdistrict is not null)then
        if(age_exeret='1')then
            query1:=query1||' and b."Dist_Code" = '''||pdistrict||''' ';
         elsif(age_exeret='2')then
            query1:=query1||' and (a."Executive_code" IS NOT NULL AND a."Executive_code" in(select exec_mast."Exe_no" from exec_mast  where EXEC_MAST."dist_code"='''||pdistrict||''' ) ) ';
        else
            query1:=query1||' and  (a.RETAINER IS NOT NULL AND a.RETAINER IN(SELECT RETAINERMASTER."Retain_Code" FROM RETAINERMASTER WHERE RETAINERMASTER."Dist_Code"='''||pdistrict||''')) ';
        end if;
    end if;
    if(ptaluka is not null)then
        if(age_exeret='1')then
            query1:=query1||' and b.TALUKA = '''||ptaluka||''' ';
        elsif(age_exeret='2')then
            query1:=query1||' and (a."Executive_code" IS NOT NULL AND a."Executive_code" in(select exec_mast."Exe_no" from exec_mast  where EXEC_MAST."TALUKA"='''||ptaluka||'''  ) ) ';
        else
            query1:=query1||' and (a.RETAINER IS NOT NULL AND a.RETAINER IN(SELECT RETAINERMASTER."Retain_Code" FROM RETAINERMASTER WHERE RETAINERMASTER."TALUKA"='''||ptaluka||''' )) ';
        end if;
    end if;

    if (pro_doc_status is not null) then
        if pro_doc_status ='0' then
            query1:=query1||' and nvl(a."RODOCSTATUS",''0'') = '''||pro_doc_status||''' ';
        else
            query1:=query1||' and a."RODOCSTATUS" = '''||pro_doc_status||''' ';
        end if;    
    end if;

    if(ppay_mode is not null)then
        query1:=query1||' and a."Bill_pay" = '''||ppay_mode||''' ';
    end if;

    if(pexecutive is not null)then
        query1:=query1||' and a."Executive_code" = '''||pexecutive||''' ';
    end if;

    if(pretainer  is not null)then
        query1:=query1||' and a.RETAINER = '''||pretainer||''' ';
    end if;

--new version
  query1:=query1||' and a."branch" in(select lb.branch_code from login_branch_mast lb where  lb.user_code='''||puserid||''' and nvl(lb.user_flag,''N'')=''Y'') ' ;
--old version
   -- query1:=query1||' and a."branch" in(select branch_mst."Branch_Name" from branch_mst where branch_mst."Branch_Code" in (select lb.branch_code from login_branch_mast lb where  lb.user_code='''||puserid||''' and nvl(lb.user_flag,''N'')=''Y'')) ' ;

    if(ptype is not null)then
        if ptype='U' then
            query1:=query1||' and (i."Comp_Code"||i.bill_no||i.bill_date in(select /*+ (AD_OUTSTAND IND_OUT) */ o.comp_code||o.billno||o.billdt 
                        from ad_outstand o where o.comp_code=i."Comp_Code" and o.ag_main_code=b."Agency_Code" and 
                        o.ag_sub_code=b."SUB_Agency_Code" and o.billdt=i.bill_date and o.billno=i.bill_no 
                        group by o.comp_code,o.billno,o.billdt having sum(o.amount)>=10) OR i.bill_no IS NULL ) ';
        else 
            query1:=query1||' and i."Comp_Code"||i.bill_no||i.bill_date in(select /*+ (AD_OUTSTAND IND_OUT) */ o.comp_code||o.billno||o.billdt 
                        from ad_outstand o where o.comp_code=i."Comp_Code" and o.ag_main_code=b."Agency_Code" and 
                        o.ag_sub_code=b."SUB_Agency_Code" and o.billdt=i.bill_date and o.billno=i.bill_no 
                        group by o.comp_code,o.billno,o.billdt having sum(o.amount)=0)';
        end if;                
    end if;
    
    if(det_summry!='1')then/*for summary*/
        if(age_exeret='1')then/*fot agency*/
            query1:=query1||' GROUP BY b."Agency_Name" ,b."Dist_Code"  ,a."branch"';
        elsif(age_exeret='2')then
            query1:=query1||' group by EXEC_MAST."Exec_name",EXEC_MAST."dist_code",a."branch"';
        else
            query1:=query1||' GROUP BY RETAINERMASTER."Retain_Name",RETAINERMASTER."Dist_Code",a."branch"';
        end if;
        else
        
        if(age_exeret='1')then/*fot agency*/
            query1:=query1||' GROUP BY a."cio_booking_id"  ,b."Agency_Name"   ,a."Executive_code",a.RETAINER,"Client_code",c."Adv_Cat_Name","RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT,a."Bill_pay",a."branch",a."Comp_code"';
        elsif(age_exeret='2')then
            query1:=query1||' group by a."cio_booking_id"  ,b."Agency_Name",EXEC_MAST."Exec_name","Client_code",c."Adv_Cat_Name" ,"RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT,a."Bill_pay",a."branch",a."Comp_code" ';
        else
            query1:=query1||' GROUP BY a."cio_booking_id"  ,b."Agency_Name",RETAINERMASTER."Retain_Name","Client_code",c."Adv_Cat_Name" ,"RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT,a."Bill_pay",a."branch",a."Comp_code"';
        end if;
        
        
        
    end if;

  delete from searchtbl;
    insert into searchtbl values(query1);commit;


    OPEN p_accounts FOR query1;
    open p_accounts1 for
    select comp_mst."Comp_Name" from comp_mst where comp_mst."Comp_Code"=pcompcode;
END Ro_Report;
/
////////////////////////////////end of 7579////////////////////////




//////////-------shipra------5/25/2012////////////////done by lata mam



CREATE OR REPLACE PACKAGE HT18JULY.insertintobookchild
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  insertintobookchild_p (


    insertdate in date,
edition in varchar2,
premium1 in varchar2,
premium2 in varchar2,
premallow in varchar2,
adcategory in varchar2,
latestdate in date,
material in varchar2,
cardrate in number,
matfilename in varchar2,
discrate in number,
insertstatus in varchar2,
billstatus in varchar2,
adsubcat1 in varchar2,
compcode in varchar2,
userid in varchar2,
cioid in varchar2,
height in number,
width in number,
totalsize in number,
pagepost in varchar2,
premper1 in number,
premper2 in number,
colid in varchar2,
repeat in date,
insertno in int,
paid in varchar2,
agrrate in number,
solorate in number,
grossrate in number,
insert_pageno in number,
insert_remarks in varchar2,
page_code in varchar2,
page_per in number,
noofcol in number,
billamt in number,
billrate in number,
logo_h in varchar2,
logo_w in varchar2,
logo_name in varchar2,
ad_cat_3 in varchar2,
ad_cat_4 in varchar2,
ad_cat_5 in varchar2,
pkgcode in varchar2,
gridins in number,
pkgalias in varchar2,
cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date, 
ciragency_v in varchar2,
 ciragencysubcode_v in varchar2, 
 center_v in varchar2,
  branch_v in varchar2,
  splitdata_v in varchar2,
  subedidata in varchar2,
  splboldsizevalue IN VARCHAR2,
  vatrate_p in float,
  boxcharge_p in float,
  vat_inc_p in varchar2,
  grossamtlocal_p in varchar2,
  billamtlocal_p in varchar2,
  sectioncode_p in varchar2,
  resourceno_p in varchar2,
  caption_inserts_p in varchar2,
  dealerheight in NUMBER,
              dealerwidth in NUMBER,
              disc_p in float,
    p_error out varchar2

   );
END insertintobookchild;
/








CREATE OR REPLACE PACKAGE BODY HT18JULY.insertintobookchild
IS
   PROCEDURE insertintobookchild_p (
      insertdate           IN       DATE,
      edition              IN       VARCHAR2,
      premium1             IN       VARCHAR2,
      premium2             IN       VARCHAR2,
      premallow            IN       VARCHAR2,
      adcategory           IN       VARCHAR2,
      latestdate           IN       DATE,
      material             IN       VARCHAR2,
      cardrate             IN       NUMBER,
      matfilename          IN       VARCHAR2,
      discrate             IN       NUMBER,
      insertstatus         IN       VARCHAR2,
      billstatus           IN       VARCHAR2,
      adsubcat1            IN       VARCHAR2,
      compcode             IN       VARCHAR2,
      userid               IN       VARCHAR2,
      cioid                IN       VARCHAR2,
      height               IN       NUMBER,
      width                IN       NUMBER,
      totalsize            IN       NUMBER,
      pagepost             IN       VARCHAR2,
      premper1             IN       NUMBER,
      premper2             IN       NUMBER,
      colid                IN       VARCHAR2,
      repeat               IN       DATE,
      insertno             IN       INT,
      paid                 IN       VARCHAR2,
      agrrate              IN       NUMBER,
      solorate             IN       NUMBER,
      grossrate            IN       NUMBER,
      insert_pageno        IN       NUMBER,
      insert_remarks       IN       VARCHAR2,
      page_code            IN       VARCHAR2,
      page_per             IN       NUMBER,
      noofcol              IN       NUMBER,
      billamt              IN       NUMBER,
      billrate             IN       NUMBER,
      logo_h               IN       VARCHAR2,
      logo_w               IN       VARCHAR2,
      logo_name            IN       VARCHAR2,
      ad_cat_3             IN       VARCHAR2,
      ad_cat_4             IN       VARCHAR2,
      ad_cat_5             IN       VARCHAR2,
      pkgcode              IN       VARCHAR2,
      gridins              IN       NUMBER,
      pkgalias             IN       VARCHAR2,
      cirvts               IN       VARCHAR2,
      cirpub               IN       VARCHAR2,
      ciredi               IN       VARCHAR2,
      cirrate              IN       VARCHAR2,
      cirdate_v            IN       DATE,
      ciragency_v          IN       VARCHAR2,
      ciragencysubcode_v   IN       VARCHAR2,
      center_v             IN       VARCHAR2,
      branch_v             IN       VARCHAR2,
        splitdata_v          IN       VARCHAR2,
         subedidata in varchar2,
         splboldsizevalue IN VARCHAR2,
          vatrate_p in float,
            boxcharge_p in float,
            vat_inc_p in varchar2,
            grossamtlocal_p in varchar2,
            billamtlocal_p in varchar2,
            sectioncode_p in varchar2,
              resourceno_p in varchar2,
              caption_inserts_p in varchar2,
              dealerheight in NUMBER,
              dealerwidth in NUMBER,
               disc_p in float,
      p_error              OUT      VARCHAR2
   )
   AS
      edi           VARCHAR2 (50);
      publi         VARCHAR2 (50);
      pub_cent      VARCHAR2 (50);
      supp          VARCHAR2 (50);
      cou1          NUMBER;
      ID            NUMBER;
      insertidval   NUMBER;
      receiptno_m varchar2(50);
      error1 varchar2(100);
   BEGIN
    BEGIN
    select Receipt_no into receiptno_m from tbl_booking_mast_g where cio_booking_id=cioid and rownum<=1;
     EXCEPTION
         WHEN NO_DATA_FOUND
         THEN
            NULL;
      END;
      BEGIN
         SELECT COUNT (*)
           INTO cou1
           FROM edition_mast
          WHERE ("Edition_Alias" = edition) AND ("Comp_Code" = compcode);
      EXCEPTION
         WHEN NO_DATA_FOUND
         THEN
            NULL;
      END;

      IF (cou1 > 0)
      THEN
         BEGIN
            SELECT "Edition_Code"
              INTO edi
              FROM edition_mast
             WHERE ("Edition_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Pub_Code"
              INTO publi
              FROM edition_mast
             WHERE ("Edition_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "City_Code"
              INTO pub_cent
              FROM edition_mast
             WHERE ("Edition_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         supp := '';
      ELSE
         BEGIN
            SELECT "Edition_Code"
              INTO edi
              FROM supplement_mast
             WHERE ("Supp_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Pub_Code"
              INTO publi
              FROM supplement_mast
             WHERE ("Supp_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Supp_Code"
              INTO supp
              FROM supplement_mast
             WHERE ("Supp_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "City_Code"
              INTO pub_cent
              FROM edition_mast
             WHERE ("Edition_Code" = edi)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;
      END IF;

      IF (supp IS NULL)
      THEN
         supp := 'MN';
      END IF;

--insertidval:=INSERTID.nextval;
      SELECT insertid.NEXTVAL
        INTO insertidval
        FROM DUAL;
        INSERT INTO tbl_booking_insert_G
                  (CIO_BOOKING_ID, EDITION, INSERT_DATE, COL_CODE,
                   HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1,
                   PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW,
                   AD_CAT, AD_SUB_CAT, LATEST_BY, STATUS_MATERIAL,
                   FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS,
                   BILL_STATUS, COMP_CODE, USERID, REPEATING_DATE,
                   NO_INSERT, EDITION_CODE, PUBLICATION_CODE,
                   PUB_CENT_CODE, SUPP_CODE, PAI_FREE_INS,
                   AGREED_RATE, SOLO_RATE, GROSS_RATE, PAGE_NO,
                   REMARKS, PAGE_PREM, PAGE_PER, NO_OFCOLUMN,
                   BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME,
                   INSERT_ID, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5,
                   PACKAGE_CODE, INSERTS, PKG_ALIAS, SESID,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO,CAPTION,
                   DEALER_H, DEALER_W, DISCOUNT
                  )
           VALUES (cioid, edition, insertdate, colid,
                   height, width, totalsize, pagepost, premium1,
                   premper1, premium2, premper2, premallow,
                   adcategory, adsubcat1, latestdate, material,
                   matfilename, cardrate, discrate, insertstatus,
                   billstatus, compcode, userid, repeat,
                   insertno, edi, publi,
                   pub_cent, supp, paid,
                   agrrate, solorate, grossrate, insert_pageno,
                   insert_remarks, page_code, page_per, noofcol,
                   billamt, billrate, logo_h, logo_w, logo_name,
                   insertidval, ad_cat_3, ad_cat_4, ad_cat_5,
                   pkgcode, gridins, pkgalias,USERENV ('sessionid'),splboldsizevalue,vatrate_p,boxcharge_p,vat_inc_p,grossamtlocal_p,billamtlocal_p,sectioncode_p,  resourceno_p,caption_inserts_p,
                   dealerheight,dealerwidth,disc_p
                  );
                  insert_split_details(splitdata_v,receiptno_m,cioid,insertidval,error1);
                 INSERT INTO TEST1 VALUES(edition,'EDITION');
                 insert_edition_details(subedidata,receiptno_m,cioid,insertidval,compcode,edi,insertdate,height,width,totalsize,insertstatus,pkgcode,insertno,insert_pageno,error1);
                 commit;
                  --insert into abctest values(edition);
/*                 
      INSERT INTO tbl_booking_insert
                  ("Cio_Booking_Id", "Edition", "Insert_Date", "Col_Code",
                   "Height", "Width", "Size_Book", "Page_Post", "Premium1",
                   "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow",
                   "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Status_Material",
                   "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status",
                   "Bill_Status", "Comp_Code", "Userid", "Repeating_Date",
                   "No_Insert", "Edition_Code", "Publication_Code",
                   "Pub_Cent_Code", "Supp_Code", "Pai_Free_Ins",
                   "Agreed_Rate", "Solo_Rate", "Gross_Rate", "Page_No",
                   "Remarks", "Page_Prem", "Page_Per", "No_Ofcolumn",
                   "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name",
                   "Insert_Id", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5",
                   package_code, inserts, pkg_alias
                  )
           VALUES (cioid, edition, insertdate, colid,
                   height, width, totalsize, pagepost, premium1,
                   premper1, premium2, premper2, premallow,
                   adcategory, adsubcat1, latestdate, material,
                   matfilename, cardrate, discrate, insertstatus,
                   billstatus, compcode, userid, repeat,
                   insertno, edi, publi,
                   pub_cent, supp, paid,
                   agrrate, solorate, grossrate, insert_pageno,
                   insert_remarks, page_code, page_per, noofcol,
                   billamt, billrate, logo_h, logo_w, logo_name,
                   insertidval, ad_cat_3, ad_cat_4, ad_cat_5,
                   pkgcode, gridins, pkgalias
                  );
*/
      IF (cirvts IS NOT NULL)
      THEN
         INSERT INTO TBL_BOOKING_VTS_g
                     (compcode, cioid, insertid, vts, publication, edition,
                      rate, ciragcode, ciragsubcode, center,
                      branch, publishdate ,SESID
                     )
              VALUES (compcode, cioid, insertidval, cirvts, cirpub, ciredi,
                      cirrate, ciragency_v, ciragencysubcode_v, center_v,
                      branch_v, cirdate_v,USERENV ('sessionid')
                     );
      END IF;
   EXCEPTION
      WHEN OTHERS
      THEN
         p_error := 'Error:' || SQLERRM;
   END insertintobookchild_p;
END insertintobookchild;
/








CREATE OR REPLACE PACKAGE HT18JULY.insertintobookchild_update
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  insertintobookchild_update_p (


    insertdate in date,
edition in varchar2,
premium1 in varchar2,
premium2 in varchar2,
premallow in varchar2,
adcategory in varchar2,
latestdate in date,
material in varchar2,
cardrate in number,
matfilename in varchar2,
discrate in number,
insertstatus in varchar2,
billstatus in varchar2,
adsubcat1 in varchar2,
compcode in varchar2,
userid in varchar2,
cioid in varchar2,
height in number,
width in number,
totalsize in number,
pagepost in varchar2,
premper1 in number,
premper2 in number,
colid in varchar2,
repeat in date,
insertno in int,
paid in varchar2,
agrrate in number,
solorate in number,
grossrate in number,
insert_pageno in number,
insert_remarks in varchar2,
page_code in varchar2,
page_per in number,
noofcol in number,
billamt in number,
billrate in number,
logo_h in varchar2,
logo_w in varchar2,
logo_name in varchar2,
ad_cat_3 in varchar2,
ad_cat_4 in varchar2,
ad_cat_5 in varchar2,
pkgcode in varchar2,
gridins in number,
pkgalias in varchar2,
insertid1 in varchar2,
cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date, 
ciragency_v in varchar2,
ciragencysubcode_v in varchar2, 
center_v in varchar2,
branch_v in varchar2,
splboldsizevalue VARCHAR2,
vatrate_p float,
boxcharge_p FLOAT,
vat_inc_p varchar2,
grossamtlocal_p float,
billamtlocal_p float,
sectioncode_p varchar2,
resourceno_p varchar2,
caption_inserts_p in varchar2,
subedidata in varchar2,
disc_p in float
   ); 
END insertintobookchild_update;
/










CREATE OR REPLACE PACKAGE BODY HT18JULY.insertintobookchild_update
IS
   PROCEDURE insertintobookchild_update_p (
insertdate in date,
edition in varchar2,
premium1 in varchar2,
premium2 in varchar2,
premallow in varchar2,
adcategory in varchar2,
latestdate in date,
material in varchar2,
cardrate in number,
matfilename in varchar2,
discrate in number,
insertstatus in varchar2,
billstatus in varchar2,
adsubcat1 in varchar2,
compcode in varchar2,
userid in varchar2,
cioid in varchar2,
height in number,
width in number,
totalsize in number,
pagepost in varchar2,
premper1 in number,
premper2 in number,
colid in varchar2,
repeat in date,
insertno in int,
paid in varchar2,
agrrate in number,
solorate in number,
grossrate in number,
insert_pageno in number,
insert_remarks in varchar2,
page_code in varchar2,
page_per in number,
noofcol in number,
billamt in number,
billrate in number,
logo_h in varchar2,
logo_w in varchar2,
logo_name in varchar2,
ad_cat_3 in varchar2,
ad_cat_4 in varchar2,
ad_cat_5 in varchar2,
pkgcode in varchar2,
gridins in number,
pkgalias in varchar2,
insertid1 in varchar2,
cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date,
ciragency_v in varchar2,
ciragencysubcode_v in varchar2,
center_v in varchar2,
branch_v in varchar2,
splboldsizevalue VARCHAR2,
vatrate_p float,
boxcharge_p FLOAT,
vat_inc_p varchar2,
grossamtlocal_p float,
billamtlocal_p float,
sectioncode_p varchar2,
resourceno_p varchar2,
caption_inserts_p in varchar2,
subedidata in varchar2,
disc_p in float
   )
   AS

insertdatem date;
   heightm  number;
    widthm  number;
    insertstatusm  varchar2(50);
    cioidm  varchar2(50);

edi  varchar2(20);
publi  varchar2(20);
pub_cent   varchar2(20);
supp  varchar2(20);
cou1  number;
id  number;
insertidval number;
countcir number;
error1      varchar2(409);
BEGIN
heightm:=height;
    widthm:=width;
    insertstatusm:=insertstatus;
    cioidm:=cioid;
    insertdatem:=insertdate;
begin
select count(*) into  cou1   from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

if(cou1 >0)
then
begin
select "Edition_Code" into edi from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select "Pub_Code" into publi from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select  "City_Code" into pub_cent from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

 supp:='';


else

begin

select "Edition_Code" into edi from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select"Pub_Code" into publi from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select "Supp_Code"   into  supp  from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select "City_Code"  into pub_cent from edition_mast where ("Edition_Code"=edi) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

end if;

if(supp is null)
then

 supp:='MN';

end if;

    if(insertid1 is null or insertid1='0' or insertid1='') then
     select INSERTID.nextval into insertidval from dual;

    insert into tbl_booking_insert("Cio_Booking_Id","Edition","Insert_Date","Col_Code","Height","Width","Size_Book","Page_Post","Premium1","Prem_Per1","Premium2","Prem_Per2","Premium_Allow","Ad_Cat","Ad_Sub_Cat","Latest_By","Status_Material","File_Name","Card_Rate","Disc_Rate","Insert_Status","Bill_Status","Comp_Code","Userid","Repeating_Date","No_Insert","Edition_Code","Publication_Code","Pub_Cent_Code","Supp_Code","Pai_Free_Ins","Agreed_Rate","Solo_Rate","Gross_Rate","Page_No","Remarks","Page_Prem","Page_Per","No_Ofcolumn","Bill_Amt","Bill_Rate","Logo_H", "Logo_W", "Logo_name","Insert_Id","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION,DISCOUNT)
    values(cioid,edition,insertdate,colid,height,width,totalsize,pagepost,premium1,premper1,premium2,premper2,premallow,adcategory,adsubcat1,latestdate,material,matfilename,cardrate,discrate,insertstatus,billstatus,compcode,userid,repeat,insertno,edi,publi,pub_cent,supp,paid,agrrate,solorate,grossrate,insert_pageno,insert_remarks,page_code,page_per,noofcol,billamt,billrate,logo_h,logo_w,logo_name,insertidval,ad_cat_3,ad_cat_4,ad_cat_5, pkgcode,gridins,pkgalias, splboldsizevalue,vatrate_p,boxcharge_p,vat_inc_p ,grossamtlocal_p,billamtlocal_p,sectioncode_p,resourceno_p,caption_inserts_p,disc_p);
       
    
      if(cirvts is not null) then
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                            values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
      end if;

        insert_edition_details_update(subedidata,null,cioid,insertidval,compcode,edi,insertdate,height,width,totalsize,insertstatus,pkgcode,insertno,insert_pageno,error1);
    else
        update  tbl_booking_insert set  "Edition"=edition,"Insert_Date"=insertdate,"Col_Code"=colid,"Height"=height,"Width"=width,"Size_Book"=totalsize,"Page_Post"=pagepost,"Premium1"=premium1,"Prem_Per1"=premper1,"Premium2"=premium2,"Prem_Per2"=premper2,"Premium_Allow"=premallow,"Ad_Cat"=adcategory,"Ad_Sub_Cat"=adsubcat1,"Latest_By"=latestdate,"Status_Material"=material,"File_Name"=matfilename,"Card_Rate"=cardrate,"Disc_Rate"=discrate,"Insert_Status"=insertstatus,"Bill_Status"=billstatus,"Comp_Code"=compcode,"Userid"=userid,"Repeating_Date"=repeat,"No_Insert"=insertno,"Edition_Code"=edi,"Publication_Code"=publi,"Pub_Cent_Code"=pub_cent,"Supp_Code"=supp,"Pai_Free_Ins"=paid,"Agreed_Rate"=agrrate,"Solo_Rate"=solorate,"Gross_Rate"=grossrate,"Page_No"=insert_pageno,"Remarks"=insert_remarks,"Page_Prem"=page_code,"Page_Per"=page_per,"No_Ofcolumn"=noofcol,"Bill_Amt"=billamt,"Bill_Rate"=billrate,"Logo_H"=logo_h, "Logo_W"=logo_w, "Logo_name"=logo_name,"AD_SUBCAT3"=ad_cat_3,"AD_SUBCAT4"=ad_cat_4,"AD_SUBCAT5"=ad_cat_5,PACKAGE_CODE=pkgcode,INSERTS=gridins,PKG_ALIAS=pkgalias, SPECIAL_SIZE1= splboldsizevalue,VATAMT=vatrate_p,BOXCHARGE=boxcharge_p,VAT_INC=vat_inc_p,LOCALGROSSAMT=grossamtlocal_p,LOCALBILLAMT=billamtlocal_p,SECTIONCODE=sectioncode_p,RESOURCE_NO=resourceno_p,CAPTION=caption_inserts_p, DISCOUNT=disc_p  where "Cio_Booking_Id"=cioid and "Insert_Id" = insertid1;
        if(subedidata is null) then
        if insertstatus = 'cancel' then
                    update tbl_booking_subedition set INSERTSTATUS='cancel' where tbl_booking_subedition.cioid=cioid and insertid=insertid1;
        ELSE
        update tbl_booking_subedition set tbl_booking_subedition.INSERTDATE=insertdatem,tbl_booking_subedition.HEIGHT=heightm,tbl_booking_subedition.WIDTH=widthm,tbl_booking_subedition.TOTALAREA=totalsize , tbl_booking_subedition.INSERTSTATUS=insertstatusm WHERE tbl_booking_subedition.CIOID= cioidm and tbl_booking_subedition.INSERTID=insertid1 and tbl_booking_subedition.INSERTSTATUS!='publish' and tbl_booking_subedition.INSERTSTATUS!='billed';            
        end if;
        end if;
          begin
                select count(*) into countcir from tbl_booking_vts where CIOID=cioid and INSERTID=insertid1;
                exception when no_data_found then countcir:=0 ;
          end;
           
       if(countcir=0) then
        insertidval:=insertid1;
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                    values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
        else
            update tbl_booking_vts set VTS=cirvts,PUBLICATION=cirpub,EDITION=ciredi,RATE=cirrate,CIRAGCODE=ciragency_v,CIRAGSUBCODE=ciragencysubcode_v,PUBLISHDATE=cirdate_v where  CIOID=cioid and INSERTID=insertid1;
        end if;
    end if;
   END insertintobookchild_update_p;
END insertintobookchild_update;
/








CREATE OR REPLACE PACKAGE HT18JULY.insertintobookchild_display
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  insertintobookchild_display_p (


    insertdate in date,
edition in varchar2,
premium1 in varchar2,
premium2 in varchar2,
premallow in varchar2,
adcategory in varchar2,
latestdate in date,
material in varchar2,
cardrate in number,
matfilename in varchar2,
discrate in number,
insertstatus in varchar2,
billstatus in varchar2,
adsubcat1 in varchar2,
compcode in varchar2,
userid in varchar2,
cioid in varchar2,
height in number,
width in number,
totalsize in number,
pagepost in varchar2,
premper1 in number,
premper2 in number,
colid in varchar2,
repeat in date,
insertno in int,
paid in varchar2,
agrrate in number,
solorate in number,
grossrate in number,
insert_pageno in number,
insert_remarks in varchar2,
page_code in varchar2,
page_per in number,
noofcol in number,
billamt in number,
billrate in number,
logo_h in varchar2,
logo_w in varchar2,
logo_name in varchar2,
ad_cat_3 in varchar2,
ad_cat_4 in varchar2,
ad_cat_5 in varchar2,
pkgcode in varchar2,
gridins in number,
pkgalias in varchar2,
insertid1 in number,
cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date, 
ciragency_v in varchar2,
ciragencysubcode_v in varchar2, 
center_v in varchar2,
branch_v in varchar2,
boxcharge_p in float,
vat_inc_p in varchar2,
vatrate_p in float,
grossamtlocal_p in number,
billamtlocal_p in number,
sectioncode_p in varchar2,
resourceno_p in varchar2,
caption_inserts_p in varchar2,
dealerheight in NUMBER,
dealerwidth in NUMBER,
subedidata in varchar2,
disc_p in float
   );
END insertintobookchild_display;
/









CREATE OR REPLACE PACKAGE BODY HT18JULY.insertintobookchild_display
IS
   PROCEDURE insertintobookchild_display_p (
    insertdate in date,
    edition in varchar2,
    premium1 in varchar2,
    premium2 in varchar2,
    premallow in varchar2,
    adcategory in varchar2,
    latestdate in date,
    material in varchar2,
    cardrate in number,
    matfilename in varchar2,
    discrate in number,
    insertstatus in varchar2,
    billstatus in varchar2,
    adsubcat1 in varchar2,
    compcode in varchar2,
    userid in varchar2,
    cioid in varchar2,
    height in number,
    width in number,
    totalsize in number,
    pagepost in varchar2,
    premper1 in number,
    premper2 in number,
    colid in varchar2,
    repeat in date,
    insertno in int,
    paid in varchar2,
    agrrate in number,
    solorate in number,
    grossrate in number,
    insert_pageno in number,
    insert_remarks in varchar2,
    page_code in varchar2,
    page_per in number,
    noofcol in number,
    billamt in number,
    billrate in number,
    logo_h in varchar2,
    logo_w in varchar2,
    logo_name in varchar2,
    ad_cat_3 in varchar2,
    ad_cat_4 in varchar2,
    ad_cat_5 in varchar2,
    pkgcode in varchar2,
    gridins in number,
    pkgalias in varchar2,
    insertid1 in number,
    cirvts in varchar2,
    cirpub in varchar2,
    ciredi in varchar2,
    cirrate in varchar2,
    cirdate_v in date, 
    ciragency_v in varchar2,
    ciragencysubcode_v in varchar2, 
    center_v in varchar2,
    branch_v in varchar2,
    boxcharge_p in float,
    vat_inc_p in varchar2,
    vatrate_p in float,
    grossamtlocal_p in number,
    billamtlocal_p in number,
    sectioncode_p in varchar2,
    resourceno_p in varchar2,
    caption_inserts_p in varchar2,
    dealerheight in NUMBER,
    dealerwidth in NUMBER,
    subedidata in varchar2,
    disc_p in float
    )
   
AS
      heightm  number;
    widthm  number;
    insertstatusm  varchar2(50);
    cioidm  varchar2(50);
    edi varchar2(50);
    publi varchar2(50);
    pub_cent varchar2(50);
    supp varchar2(50);
    cou1 number;
    id number;
    billnum varchar2(50);
    retain varchar2(50);
    executive varchar(50);    
insertidval number;
countcir number;
error1      varchar2(409);
insertdatem date;
    BEGIN
    heightm:=height;
    widthm:=width;
    insertstatusm:=insertstatus;
    cioidm:=cioid;
    insertdatem:=insertdate;
        begin
            select count(*) into cou1 from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

    if(cou1 >0) then
        begin
            select "Edition_Code" into edi from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select "Pub_Code" into publi from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select "City_Code" into pub_cent from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        supp:='';
    else
        begin
            select "Edition_Code" into edi from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select"Pub_Code" into publi from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select "Supp_Code"   into  supp  from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select "City_Code"  into pub_cent from edition_mast where ("Edition_Code"=edi) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;
    end if;

    if(supp is null) then
        supp:='MN';
    end if;

    if(insertid1 is null or insertid1='0' or insertid1='') then
        select INSERTID.nextval into insertidval from dual;
        
        insert into tbl_booking_insert("Cio_Booking_Id","Edition","Insert_Date","Col_Code","Height","Width","Size_Book","Page_Post","Premium1","Prem_Per1","Premium2","Prem_Per2","Premium_Allow","Ad_Cat","Ad_Sub_Cat","Latest_By","Status_Material","File_Name","Card_Rate","Disc_Rate","Insert_Status","Bill_Status","Comp_Code","Userid","Repeating_Date","No_Insert","Edition_Code","Publication_Code","Pub_Cent_Code","Supp_Code","Pai_Free_Ins","Agreed_Rate","Solo_Rate","Gross_Rate","Page_No","Remarks","Page_Prem","Page_Per","No_Ofcolumn","Bill_Amt","Bill_Rate","Logo_H", "Logo_W", "Logo_name","Insert_Id","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS,BOXCHARGE,VAT_INC,VATAMT,LOCALGROSSAMT,LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION,DEALER_H,DEALER_W,DISCOUNT)
        values(cioid,edition,insertdate,colid,height,width,totalsize,pagepost,premium1,premper1,premium2,premper2,premallow,adcategory,adsubcat1,latestdate,material,matfilename,cardrate,discrate,insertstatus,billstatus,compcode,userid,repeat,insertno,edi,publi,pub_cent,supp,paid,agrrate,solorate,grossrate,insert_pageno,insert_remarks,page_code,page_per,noofcol,billamt,billrate,logo_h,logo_w,logo_name,insertidval,ad_cat_3,ad_cat_4,ad_cat_5, pkgcode,gridins,pkgalias,boxcharge_p,vat_inc_p,vatrate_p,grossamtlocal_p,billamtlocal_p,sectioncode_p,resourceno_p,caption_inserts_p,dealerheight,dealerwidth,disc_p);
        if(cirvts is not null) then
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                    values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
        end if; 
         insert_edition_details_update(subedidata,null,cioid,insertidval,compcode,edi,insertdate,height,width,totalsize,insertstatus,pkgcode,insertno,insert_pageno,error1);
                   
    else
        update  tbl_booking_insert set "Edition"=edition,"Insert_Date"=insertdate,"Col_Code"=colid,"Height"=height,"Width"=width,"Size_Book"=totalsize,"Page_Post"=pagepost,"Premium1"=premium1,"Prem_Per1"=premper1,"Premium2"=premium2,"Prem_Per2"=premper2,"Premium_Allow"=premallow,"Ad_Cat"=adcategory,"Ad_Sub_Cat"=adsubcat1,"Latest_By"=latestdate,"Status_Material"=material,"File_Name"=matfilename,"Card_Rate"=cardrate,"Disc_Rate"=discrate,"Insert_Status"=insertstatus,"Bill_Status"=billstatus,"Comp_Code"=compcode,"Userid"=userid,"Repeating_Date"=repeat,"No_Insert"=insertno,"Edition_Code"=edi,"Publication_Code"=publi,"Pub_Cent_Code"=pub_cent,"Supp_Code"=supp,"Pai_Free_Ins"=paid,"Agreed_Rate"=agrrate,"Solo_Rate"=solorate,"Gross_Rate"=grossrate,"Page_No"=insert_pageno,"Remarks"=insert_remarks,"Page_Prem"=page_code,"Page_Per"=page_per,"No_Ofcolumn"=noofcol,"Bill_Amt"=billamt,"Bill_Rate"=billrate,"Logo_H"=logo_h, "Logo_W"=logo_w, "Logo_name"=logo_name,"AD_SUBCAT3"=ad_cat_3,"AD_SUBCAT4"=ad_cat_4,"AD_SUBCAT5"=ad_cat_5,PACKAGE_CODE=pkgcode,INSERTS=gridins,PKG_ALIAS=pkgalias,BOXCHARGE=boxcharge_p, VAT_INC=vat_inc_p,VATAMT=vatrate_p, LOCALGROSSAMT=grossamtlocal_p, LOCALBILLAMT=billamtlocal_p, SECTIONCODE=sectioncode_p, RESOURCE_NO=resourceno_p,CAPTION=caption_inserts_p,DEALER_H=dealerheight,DEALER_W=dealerwidth,DISCOUNT=disc_p where "Cio_Booking_Id"=cioid AND "Insert_Id"=insertid1;
        if(subedidata is null) then
            if insertstatus = 'cancel' then
                update tbl_booking_subedition set INSERTSTATUS='cancel' where tbl_booking_subedition.cioid=cioid and insertid=insertid1;
                 ELSE
                update tbl_booking_subedition set tbl_booking_subedition.INSERTDATE=insertdatem,tbl_booking_subedition.HEIGHT=heightm,tbl_booking_subedition.WIDTH=widthm,tbl_booking_subedition.TOTALAREA=totalsize , tbl_booking_subedition.INSERTSTATUS=insertstatusm WHERE tbl_booking_subedition.CIOID= cioidm and tbl_booking_subedition.INSERTID=insertid1 and tbl_booking_subedition.INSERTSTATUS!='publish' and tbl_booking_subedition.INSERTSTATUS!='billed';
            end if;
        end if;
         begin
            select count(*) into countcir from tbl_booking_vts where CIOID=cioid and INSERTID=insertid1;
            exception when no_data_found then countcir:=0 ;
        end;
        if(countcir=0) then
        insertidval:=insertid1;
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                    values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
        else
            update tbl_booking_vts set VTS=cirvts,PUBLICATION=cirpub,EDITION=ciredi,RATE=cirrate,CIRAGCODE=ciragency_v,CIRAGSUBCODE=ciragencysubcode_v,PUBLISHDATE=cirdate_v where  CIOID=cioid and INSERTID=insertid1;
        end if;

        
    if insertstatus = 'billed' then
        begin
            select BILL_NO into billnum from tbl_booking_insert where "Cio_Booking_Id"=cioid AND "Insert_Id"=insertid1;
            exception when no_data_found then NULL ;
        end;
        if billnum is not null then
            begin
                SELECT "Executive_code",RETAINER into executive, retain from tbl_booking_mast where "cio_booking_id"=cioid;
                exception when no_data_found then  NULL;
            end; 
            if retain is not null then
                update ad_bills set  retainer_code=retain,executive_name=NULL where bilno=billnum;
            end if;
            if executive is not null then
                update ad_bills set  executive_name=executive,retainer_code=NULL where bilno=billnum;
            end if;
        end if;
    
    end if;
end if;
   END insertintobookchild_display_p;
END insertintobookchild_display;
/










CREATE OR REPLACE PROCEDURE HT18JULY.committransaction(
    pcioid          in  varchar2,
    totalcount      in  int,
    pcompcode       in  varchar2,
    pcentname       in  varchar2,
    puserid         in  varchar2,
    pbkid_gentype   in  varchar2,
    pbk_type        in  varchar2,
    p_error         OUT VARCHAR2,
    p_new_cioid     OUT VARCHAR2) is
    
countnum        int;
newid           varchar2(100);
billpay         varchar2(20);
rostatus        varchar2(20);
remarks         varchar2(500);
clientname      varchar2(200);
v_cursor1       TYPES.cursor_type;
v_cursor2       TYPES.cursor_type;

v_cursor1_var1  varchar2(50);
v_cursor1_var2  varchar2(50);
v_cursor2_var1  varchar2(50);

begin
newid:=pcioid;

select count(*) into countnum from tbl_booking_insert_g where Cio_Booking_Id=pcioid;
if(countnum=totalcount) then 
     
    
   getautocodebooking.getautocodebooking_p (compcode        =>  pcompcode,
                                            auto1           =>  '0',
                                            no1             =>  '0',
                                            p_accounts      =>  v_cursor1,
                                            p_accounts1     =>  v_cursor2);
                                            
    FETCH v_cursor1 INTO v_cursor1_var1, v_cursor1_var2;
    
    FETCH v_cursor2 INTO v_cursor2_var1;
    
    if  pbkid_gentype='1' then--1 for First 3 character of Centre Name+Year + Slno  
        
        newid:=substr(pcentname,1,3)||v_cursor1_var2||LPAD(v_cursor1_var1,8,'0');
    
    elsif  pbkid_gentype='2' then--2 for First 3 character of Centre Name+Year + Userid + Slno
    
        newid:=substr(pcentname,1,3)||v_cursor1_var2||LPAD(v_cursor1_var1,8,'0')||puserid;

    elsif  pbkid_gentype='4' then--BK Type + Slno

        newid:=pbk_type||LPAD(v_cursor1_var1,8,'0');

    else

        newid:=LPAD(v_cursor1_var1,8,'0');

    end if; 
    
    p_error     :='Y';
    p_new_cioid := newid;

    INSERT INTO tbladid_ins(CIOID,COUNTNUM,FLAG) VALUES(newid,countnum,p_error);
    INSERT INTO TBL_BOOKING_MAST("date_time", "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by", "audit", "RO_No", "RO_Date", "Caption", "bill_status", "ro_status", "Agency_code", "Agency_address", "Client_code", "Client_address", "Agency_sub_code", "Dockit_no", "Executive_code", "Executive_zone", "Product_code", "Brand_code", "Key_no", "Bill_remarks", "Print_remark", "Package_code", "No_of_insertion", "Insertion_date", "Repeating_day", "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code", "Color_code", "Uom_code", "Page_position_code", "Page_type_code", "Page_no", "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code", "Scheme_type_code", "Currency_code", "Agrred_rate", "Agreed_amount", "Special_discount", "Space_discount", "Special_charges", "Agency_status", "Agency_type", "Agency_pay", "Agency_credit", "Total_area", "Card_rate", "Card_amount", "Discount", "Discount_per", "Bill_cycle", "Revenue_center", "Bill_pay", "Bill_height", "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc", "Agency_out", "Box_code", "Box_no", "Box_agency", "Box_client", "Box_address", "Comp_code", "Userid", "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad", "Campaign", "Bill_amount", "Page_prem", "Page_amount", "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", "Bill_area", "Special_disc_per", "Space_disc_per", "Paid_ins", "Contract_rate", "Deviation", "Variant_code", "Contract_name", "Contract_type", "Card_name", "Card_type", "Card_month", "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", "Bullet_code", "Bullet_premium", "Material_status", "Receipt_date", "prev_cioid", "prev_receipt", "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom", "SAPID", "RETAINER", "ADD_AGENCY_COMM", "AUDIT_COMMENT", "MOBILENO", "ADD_AGENCY_COMM_AMT", "RETAINER_COMM", "RETAINER_COMM_AMT", "CASH_RECIEVED", "CONT_GROSS", "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION", "CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER", "RODOCSTATUS",CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID,RECEIPT_CURRENCY, CONV_CURR_RATE,REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,CANCELLATION_CHARGE) 
    SELECT DATE_TIME, BRANCH, BOOKED_BY, newid CIO_BOOKING_ID, PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO, RO_DATE, CAPTION, BILL_STATUS, RO_STATUS, AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE, CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO, EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE, BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK, PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE, REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE, AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE, PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO, AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH, RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE, AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT, SPACE_DISCOUNT, SPECIAL_CHARGES, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY, AGENCY_CREDIT, TOTAL_AREA, CARD_RATE, CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE, REVENUE_CENTER, BILL_PAY, BILL_HEIGHT, BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD, TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO, BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS, COMP_CODE, USERID, CREATION_DATETIME, BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN, BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER, GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN, BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER, PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE, CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME, CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER, RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, BG_COLOR, BULLET_CODE, BULLET_PREMIUM, MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID, PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT, COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR, LOGO_UOM, SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO, ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS, CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, RODOCSTATUS,CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK, DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,CANCELLATION_CHARGE FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=pcioid;

    INSERT INTO TBL_BOOKING_insert("Insert_Id", "Cio_Booking_Id", "No_Insert", "Edition_Code", "Publication_Code", "Pub_Cent_Code", "Supp_Code", "Edition", "Insert_Date", "Col_Code", "Height", "Width", "Size_Book", "Page_Post", "Premium1", "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow", "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Repeating_Date", "Status_Material", "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status", "Bill_Status", "Agreed_Rate", "Pai_Free_Ins", "Solo_Rate", "Gross_Rate", "Comp_Code", "Userid", "Page_No", "Remarks", "Pub_Height", "Pub_Width", "Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5", "PACKAGE_CODE", "BILL_NO", "BILL_DATE", "INSERTS", "PKG_ALIAS", "CONT_GROSS_AMT", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER",SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT, LOCALBILLAMT,SECTIONCODE,RESOURCE_NO,CAPTION,DEALER_H,DEALER_W,DISCOUNT) 
    SELECT INSERT_ID, newid CIO_BOOKING_ID, NO_INSERT, EDITION_CODE, PUBLICATION_CODE, PUB_CENT_CODE, SUPP_CODE, EDITION, INSERT_DATE, COL_CODE, HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1, PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW, AD_CAT, AD_SUB_CAT, LATEST_BY, REPEATING_DATE, STATUS_MATERIAL, FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS, BILL_STATUS, AGREED_RATE, PAI_FREE_INS, SOLO_RATE, GROSS_RATE, COMP_CODE, USERID, PAGE_NO, REMARKS, PUB_HEIGHT, PUB_WIDTH, PAGE_PREM, PAGE_PER, NO_OFCOLUMN, BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, PACKAGE_CODE, BILL_NO, BILL_DATE, INSERTS, PKG_ALIAS, CONT_GROSS_AMT, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, SPECIAL_SIZE1,VATAMT, BOXCHARGE, VAT_INC,LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO,CAPTION,DEALER_H,DEALER_W, DISCOUNT FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=pcioid;

    INSERT INTO TBL_BOOKING_VTS(COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE) 
    SELECT COMPCODE, newid CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE FROM TBL_BOOKING_VTS_G WHERE  cioid=pcioid;

    insert into tbl_booking_insert_sizesplit(CIOID, RECEIPTNO, INSERTID, INSERTDATE, HEIGHT, WIDTH, AREA, SRNO, CREATIONDATETIME)
    select newid CIOID, RECEIPTNO, INSERTID, INSERTDATE, HEIGHT, WIDTH, AREA, SRNO, CREATIONDATETIME from tbl_booking_insert_sizesplit_g where cioid=pcioid;

    --INSERT INTO ABCTEST VALUES(newid,counttest);
    insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO, NO_INSERT,PAGE_NO)
    select COMP_CODE, newid CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO, SRNO, NO_INSERT,PAGE_NO from tbl_booking_subedition_g
    where tbl_booking_subedition_g.CIOID=pcioid;

    insert into TBL_BOOKING_SHARING_TRANS(PUBLICATION, TYPE, SHARING, CIOID, SRNO)
    select PUBLICATION, TYPE, SHARING, newid CIOID, SRNO from TBL_BOOKING_SHARING_TRANS_g where CIOID=pcioid ;

    insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID, CREATIONDATETIME,FMG_REASONS)
    select newid CIOID, INSERTID, CREATIONDATETIME,FMG_REASONS from TBL_BOOKING_FMG_TRANS_G where CIOID=pcioid;
    
    update tbl_matter set "cioid"=newid where "cioid"=pcioid; 

    select "Bill_pay","ro_status" into billpay,rostatus from tbl_booking_mast where "cio_booking_id"=newid;

    if billpay = 'CA0' and rostatus='1' then
        declare
            cursor c1 is
            select * from tbl_booking_mast where "cio_booking_id"=newid;
        v1 c1%rowtype;

        v_error      varchar2(2000);
        v_rcptno_r   varchar2(50);
        vrecpt       varchar2(20);
        branchcode   varchar2(20);
        vrepcode     varchar2(20);
        subagencyreg varchar2(20);
        prevcioid_v  varchar2(50);
        billamt_v    float;
        grossamt_v   float;
        v_curdate     date;
    begin
        open c1;
            fetch c1 into v1;
        Begin
            select "Branch_Code" into branchcode from branch_mst where "Comp_Code"=v1."Comp_code" and "Branch_Name"=v1."branch";
        Exception When no_data_found then
            branchcode:=v1."branch";
        End;
   
        Begin
            select "SUB_Agency_Code" into subagencyreg from agency_mast where "Comp_Code"=v1."Comp_code" and "code_subcode"=v1."Agency_sub_code";
        Exception When no_data_found then
            subagencyreg:='';
        End;
        vrecpt       :=v1."Receipt_no";
        prevcioid_v  :=v1."prev_cioid";
        if prevcioid_v is null or v1."prev_receipt" is null then
            billamt_v   :=v1."Bill_amount";
            grossamt_v  :=v1."Gross_amount";
            v_curdate   :=to_date(sysdate);
        else
            select "Bill_amount","Gross_amount" into  billamt_v,grossamt_v from tbl_booking_mast where "cio_booking_id"=prevcioid_v;
            billamt_v   :=v1."Bill_amount" - billamt_v;
            grossamt_v :=v1."Gross_amount" - grossamt_v;
            IF grossamt_v=0 OR grossamt_v IS NULL THEN
                grossamt_v:=v1."Gross_amount";
            END IF;
            v_curdate  :=to_date(sysdate);
        end if;

        -- select substr(max("recptno"),1,12)||lpad(substr(max("recptno"),-6)+1,6,'0') into vrecpt from ad_rcpthdr where "unit"=branchcode and "doctype"='RCP' and
        -- "recptdt" between '1-mar-2011' and '31-mar-2011';
         
        --receiptsave_booking.receiptsave_booking_P(pcompcode,puserid , punit ,ptype , precpt , prdate , ppaymodres ,preceivedreg ,pvouno  ,pamount  ,pagency , pothercd ,
        --pchno  ,pchedate , pbank  , pnarration ,prep   , pvdate , pag_main_code ,pag_sub_code , ourbank,  cioid , execname , retainer ,
        -- prevcioid , p_error)
        begin
            SELECT "Cust_Name" into clientname FROM CUST_MAST WHERE "Cust_Code" = v1."Client_code" and "Comp_Code"=v1."Comp_code";
        exception when NO_DATA_FOUND THEN
            clientname:=v1."Client_code";
        END;

        remarks:='RONO#'||v1."RO_No" ||' RODATE# ' || to_char(v1."RO_Date",'dd-mon-yyyy') || ' BOOKINGID# ' || v1."cio_booking_id" || ' CLIENT#' || clientname;

        receiptsave_booking.receiptsave_booking_p(v1."Comp_code",v1."Userid", v1."branch",V1.DOCTYPE,vrecpt,v_curdate,v1."Bill_pay",'','',billamt_v,v1."Agency_sub_code",grossamt_v,
            '','','',remarks,vrepcode,v1."date_time",v1."Agency_code",subagencyreg,'',v1."cio_booking_id",v1."Executive_code",v1.RETAINER,v1."prev_cioid",v_rcptno_r,v_error);
   
        update tbl_booking_mast set "Receipt_no"=v_rcptno_r,"Receipt_date"= v_curdate where "cio_booking_id"=v1."cio_booking_id";
    close c1;
    commit;
 end;
 end if;
 /*
 INSERT INTO TBL_BOOKING_MAST("date_time", "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by", "audit", "RO_No", "RO_Date", "Caption", "bill_status", "ro_status", "Agency_code", "Agency_address", "Client_code", "Client_address", "Agency_sub_code", "Dockit_no", "Executive_code", "Executive_zone", "Product_code", "Brand_code", "Key_no", "Bill_remarks", "Print_remark", "Package_code", "No_of_insertion", "Insertion_date", "Repeating_day", "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code", "Color_code", "Uom_code", "Page_position_code", "Page_type_code", "Page_no", "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code", "Scheme_type_code", "Currency_code", "Agrred_rate", "Agreed_amount", "Special_discount", "Space_discount", "Special_charges", "Agency_status", "Agency_type", "Agency_pay", "Agency_credit", "Total_area", "Card_rate", "Card_amount", "Discount", "Discount_per", "Bill_cycle", "Revenue_center", "Bill_pay", "Bill_height", "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc", "Agency_out", "Box_code", "Box_no", "Box_agency", "Box_client", "Box_address", "Comp_code", "Userid", "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad", "Campaign", "Bill_amount", "Page_prem", "Page_amount", "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", "Bill_area", "Special_disc_per", "Space_disc_per", "Paid_ins", "Contract_rate", "Deviation", "Variant_code", "Contract_name", "Contract_type", "Card_name", "Card_type", "Card_month", "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", "Bullet_code", "Bullet_premium", "Material_status", "Receipt_date", "prev_cioid", "prev_receipt", "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom", "SAPID", "RETAINER", "ADD_AGENCY_COMM", "AUDIT_COMMENT", "MOBILENO", "ADD_AGENCY_COMM_AMT", "RETAINER_COMM", "RETAINER_COMM_AMT", "CASH_RECIEVED", "CONT_GROSS", "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION", "CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER", "RODOCSTATUS") 
SELECT DATE_TIME, BRANCH, BOOKED_BY, CIO_BOOKING_ID, PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO, RO_DATE, CAPTION, BILL_STATUS, RO_STATUS, AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE, CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO, EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE, BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK, PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE, REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE, AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE, PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO, AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH, RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE, AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT, SPACE_DISCOUNT, SPECIAL_CHARGES, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY, AGENCY_CREDIT, TOTAL_AREA, CARD_RATE, CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE, REVENUE_CENTER, BILL_PAY, BILL_HEIGHT, BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD, TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO, BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS, COMP_CODE, USERID, CREATION_DATETIME, BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN, BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER, GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN, BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER, PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE, CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME, CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER, RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, BG_COLOR, BULLET_CODE, BULLET_PREMIUM, MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID, PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT, COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR, LOGO_UOM, SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO, ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS, CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, RODOCSTATUS FROM TBL_BOOKING_MAST_G WHERE SESID=USERENV ('sessionid') and CIO_BOOKING_ID=cioid;

INSERT INTO TBL_BOOKING_insert("Insert_Id", "Cio_Booking_Id", "No_Insert", "Edition_Code", "Publication_Code", "Pub_Cent_Code", "Supp_Code", "Edition", "Insert_Date", "Col_Code", "Height", "Width", "Size_Book", "Page_Post", "Premium1", "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow", "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Repeating_Date", "Status_Material", "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status", "Bill_Status", "Agreed_Rate", "Pai_Free_Ins", "Solo_Rate", "Gross_Rate", "Comp_Code", "Userid", "Page_No", "Remarks", "Pub_Height", "Pub_Width", "Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5", "PACKAGE_CODE", "BILL_NO", "BILL_DATE", "INSERTS", "PKG_ALIAS", "CONT_GROSS_AMT", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER") 
SELECT INSERT_ID, CIO_BOOKING_ID, NO_INSERT, EDITION_CODE, PUBLICATION_CODE, PUB_CENT_CODE, SUPP_CODE, EDITION, INSERT_DATE, COL_CODE, HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1, PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW, AD_CAT, AD_SUB_CAT, LATEST_BY, REPEATING_DATE, STATUS_MATERIAL, FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS, BILL_STATUS, AGREED_RATE, PAI_FREE_INS, SOLO_RATE, GROSS_RATE, COMP_CODE, USERID, PAGE_NO, REMARKS, PUB_HEIGHT, PUB_WIDTH, PAGE_PREM, PAGE_PER, NO_OFCOLUMN, BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, PACKAGE_CODE, BILL_NO, BILL_DATE, INSERTS, PKG_ALIAS, CONT_GROSS_AMT, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER FROM TBL_BOOKING_INSERT_G WHERE SESID=USERENV ('sessionid') and CIO_BOOKING_ID=cioid;

*/
else
rollback;
 p_error        :=  'N';
 p_new_cioid    :=  newid;
--DELETE FROM TBL_BOOKING_INSERT WHERE "Cio_Booking_Id"=cioid;
--DELETE FROM TBL_BOOKING_mast WHERE "cio_booking_id"=cioid;
INSERT INTO tbladid_ins(CIOID,COUNTNUM,FLAG) VALUES(newid,countnum,p_error);
end if;
--delete from tbl_booking_mast_g where  CIO_BOOKING_ID=cioid;
--delete from tbl_booking_insert_g where  CIO_BOOKING_ID=cioid;
--delete from tbl_booking_vts_g where  cioid=newid;
end;
/













CREATE OR REPLACE PACKAGE HT18JULY.getdataforexecute
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  getdataforexecute_p (


compcode in varchar2,
ciobid  in varchar2,

      p_accounts   OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor,
      p_accounts2   OUT      t_accounts_cursor,
      p_accounts3   OUT      t_accounts_cursor,
      p_accounts4   OUT      t_accounts_cursor,
      p_accounts5   OUT      t_accounts_cursor,
      p_accounts6   OUT      t_accounts_cursor,
      p_accounts7   OUT      t_accounts_cursor,
      p_accounts8   OUT      t_accounts_cursor,
      p_accounts9   out       t_accounts_cursor,
      p_accounts10   out       t_accounts_cursor,
      p_accounts11   out       t_accounts_cursor,
      p_accounts12   out       t_accounts_cursor

   );
END  getdataforexecute;
/







CREATE OR REPLACE PACKAGE BODY HT18JULY.getdataforexecute
IS
   PROCEDURE  getdataforexecute_p (
           compcode in varchar2,
ciobid  in varchar2,
p_accounts   OUT      t_accounts_cursor,
p_accounts1   OUT      t_accounts_cursor,
p_accounts2   OUT      t_accounts_cursor,
p_accounts3   OUT      t_accounts_cursor,
p_accounts4   OUT      t_accounts_cursor,
p_accounts5   OUT      t_accounts_cursor,
p_accounts6   OUT      t_accounts_cursor,
p_accounts7   OUT      t_accounts_cursor,
p_accounts8   OUT      t_accounts_cursor,
p_accounts9   out      t_accounts_cursor,
p_accounts10   out       t_accounts_cursor,
p_accounts11   out       t_accounts_cursor,
p_accounts12   out       t_accounts_cursor
   )
   AS
   --adv_subcat_code   varchar2(20);
   --adcat3 varchar2(20);
   --adcat4 varchar2(20);
   BEGIN

    --BEGIN
        insert into advcategories select "Ad_Sub_Cat","AD_SUBCAT3","AD_SUBCAT4" from tbl_booking_insert where ("Comp_Code"=compcode) and ("Cio_Booking_Id"=ciobid);
       
        --EXCEPTION WHEN NO_DATA_FOUND
        --THEN NULL;
    --END;

    OPEN p_accounts FOR
        select "Cio_Booking_Id" as  "cio_booking_id","Edition","Insert_Date" as "Insert_date","Col_Code" as "Col_code" ,"Height","Width","Size_Book" as "Size_book","Page_Post" as "Page_post","Premium1","Prem_Per1" as "Prem_per1","Premium2",nvl("Prem_Per2",'0') as "Prem_per2","Premium_Allow" as "Premium_allow","Ad_Cat" as "Ad_cat","Ad_Sub_Cat" as "Ad_sub_cat","Latest_By"as "Latest_by","Status_Material" as "Status_material" ,"File_Name" as "File_name","Card_Rate" as "Card_rate",nvl("Disc_Rate",'0') as "Disc_rate","Insert_Status" as "Insert_status","Bill_Status" as "Bill_status","Comp_Code" as "comp_code","Userid","Repeating_Date" as "Repeating_date" ,"No_Insert" as "no_insert","Edition_Code" as "Edition_code","Publication_Code" as "Publication_code","Pub_Cent_Code" as "Pub_cent_code","Supp_Code" as "Supp_code",nvl("Agreed_Rate",'0') as "Agreed_rate","Pai_Free_Ins" as "Pai_free_ins",nvl("Solo_Rate",'0') as "Solo_rate","Insert_Id" as "insert_id","Gross_Rate" as "Gross_rate","Page_No" as "Page_no" ,"Remarks","Page_Prem" as "Page_prem",nvl("Page_Per",'0') as "page_per","No_Ofcolumn" as "No_ofcolumn","Bill_Amt" as "Bill_Amt","Bill_Rate" as "Bill_rate", "Logo_H" as "Logo_H", "Logo_W" as "Logo_W" , "Logo_name" as "Logo_name","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS
        ,"Publication_Code" AS "PUBCODE",
 (SELECT VTS FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as VTS,
 (SELECT PUBLICATION FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as CIRPUBLICATION,
 (SELECT EDITION FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as CIREDITION,
 (SELECT RATE FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as CIRRATE,
 (SELECT PUBLISHDATE FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as CIRPUBLISHDATE,
 (SELECT edtn_name FROM cir_edtn_mast WHERE comp_code=compcode AND edtn=(SELECT EDITION FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id")) AS CIREDITIONNAME
 ,
(select NVL(PRIORITY,'1') FROM TBL_PRIORITY_UOM WHERE EDITION_CODE=TBL_BOOKING_INSERT."Edition_Code" and TBL_PRIORITY_UOM.COMBIN_CODE=TBL_BOOKING_INSERT.PACKAGE_CODE) AS PRIORITY,
(SELECT SPLIT FROM COMBIN_MAST WHERE "Combin_Code"=PACKAGE_CODE)  as SPLIT,SPECIAL_SIZE1,VATAMT, nvl(BOXCHARGE,'') as BOXCHARGE,NVL(VAT_INC,'0') as VAT_INC,nvl(LOCALGROSSAMT,"Gross_Rate") as LOCALGROSSAMT, nvl(LOCALBILLAMT,"Bill_Amt") AS LOCALBILLAMT,
NVL(SECTIONCODE,'') AS SECTIONCODE, NVL(RESOURCE_NO,'') AS RESOURCE_NO,NVL(CAPTION,'') AS CAPTION,DEALER_H,DEALER_W,NVL(DISCOUNT,'') AS DISCOUNT
         from tbl_booking_insert where ("Comp_Code"=compcode) and ("Cio_Booking_Id"=ciobid) order by "Insert_Id";


    OPEN p_accounts1 FOR
        select "Col_Name" as  "col_Name","Col_Code" as "col_Code" from col_mast where ("Comp_Code"=compcode);
    OPEN p_accounts2 FOR
        select "premiumname" as "premiumname","Premiumcode" as "Premiumcode" from ADVPOS_PREM_MAST where ("comp_code"=compcode);
    OPEN p_accounts3 FOR
        select "Adv_Subcat_Name","Adv_Subcat_Code" from adv_subcat_mast;
    OPEN p_accounts4 FOR
        select "Uom_Name" as "uom_name","Uom_Code" as "uom_code" from uom_mast where ("Comp_Code"=compcode);
    OPEN p_accounts5 FOR
        select "Adv_Type_Name" as "adv_type_name","Adv_Type_Code" as "adv_type_code" from adv_type_mast where "Comp_Code"=compcode;
    OPEN p_accounts6 FOR
        select "Adv_Cat_Name" as "adv_cat_name","Adv_Cat_Code" as "adv_cat_code" from ADV_CAT_MAST where ("Comp_Code"=compcode);
    OPEN p_accounts7 FOR
        select "Pos_Type_Code" as "pos_type_code","Pos_Type" as "pos_type" from advpos_type_mast where ("Comp_Code"=compcode);
    OPEN p_accounts8 FOR
        select   "Paid_permission"   from Module_DetaiButtonl  where ("comp_code"=compcode) and ("Form_Name"='Booking_master');

    open p_accounts9 for
        select "Logo_name" as "Logo_name"from tbl_booking_insert where "Comp_Code"=compcode and "Cio_Booking_Id"=ciobid and rownum<=1;

    open p_accounts10 for
        select "catname","catcode" from ad_cat3 where "subcatname" in (select AD_SUB_CAT from advcategories) order by "catname";

    open p_accounts11 for
        select "Cat_Name","Cat_Code" from tbl_cat4 where "Sub_Cat_Name" in (select AD_SUBCAT3 from advcategories) order by "Cat_Name";

    open p_accounts12 for
        select "Cat_Name","Cat_Code" from tbl_cat5 where "Sub_Cat_Name" in (select AD_SUBCAT4 from advcategories) order by "Cat_Name";
    
 
 
   END  getdataforexecute_P;
END  getdataforexecute;
/








CREATE OR REPLACE PACKAGE HT18JULY.getdataforexecute1
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  getdataforexecute1_p (


compcode in varchar2,
ciobid  in varchar2,

      p_accounts   OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor,
      p_accounts2   OUT      t_accounts_cursor,
      p_accounts3   OUT      t_accounts_cursor,
      p_accounts4   OUT      t_accounts_cursor,
      p_accounts5   OUT      t_accounts_cursor,
      p_accounts6   OUT      t_accounts_cursor,
      p_accounts7   OUT      t_accounts_cursor,
      p_accounts8   OUT      t_accounts_cursor,
      p_accounts9   out       t_accounts_cursor,
      p_accounts10   out       t_accounts_cursor,
      p_accounts11   out       t_accounts_cursor,
      p_accounts12   out       t_accounts_cursor

   );
END  getdataforexecute1;
/







CREATE OR REPLACE PACKAGE BODY HT18JULY.getdataforexecute1
IS
   PROCEDURE  getdataforexecute1_p (
           compcode in varchar2,
ciobid  in varchar2,
p_accounts   OUT      t_accounts_cursor,
p_accounts1   OUT      t_accounts_cursor,
p_accounts2   OUT      t_accounts_cursor,
p_accounts3   OUT      t_accounts_cursor,
p_accounts4   OUT      t_accounts_cursor,
p_accounts5   OUT      t_accounts_cursor,
p_accounts6   OUT      t_accounts_cursor,
p_accounts7   OUT      t_accounts_cursor,
p_accounts8   OUT      t_accounts_cursor,
p_accounts9   out      t_accounts_cursor,
p_accounts10   out       t_accounts_cursor,
p_accounts11   out       t_accounts_cursor,
p_accounts12   out       t_accounts_cursor
   )
   AS
   --adv_subcat_code   varchar2(20);
   --adcat3 varchar2(20);
   --adcat4 varchar2(20);
   BEGIN

    --BEGIN
        insert into advcategories select "Ad_Sub_Cat","AD_SUBCAT3","AD_SUBCAT4" from tbl_booking_insert where ("Comp_Code"=compcode) and ("Cio_Booking_Id"=ciobid);
       
        --EXCEPTION WHEN NO_DATA_FOUND
        --THEN NULL;
    --END;

    OPEN p_accounts FOR
        select "Cio_Booking_Id" as  "cio_booking_id","Edition","Insert_Date" as "Insert_date","Col_Code" as "Col_code" ,"Height","Width","Size_Book" as "Size_book","Page_Post" as "Page_post","Premium1","Prem_Per1" as "Prem_per1","Premium2",nvl("Prem_Per2",'0') as "Prem_per2","Premium_Allow" as "Premium_allow","Ad_Cat" as "Ad_cat","Ad_Sub_Cat" as "Ad_sub_cat","Latest_By"as "Latest_by","Status_Material" as "Status_material" ,"File_Name" as "File_name","Card_Rate" as "Card_rate",nvl("Disc_Rate",'0') as "Disc_rate","Insert_Status" as "Insert_status","Bill_Status" as "Bill_status","Comp_Code" as "comp_code","Userid","Repeating_Date" as "Repeating_date" ,"No_Insert" as "no_insert","Edition_Code" as "Edition_code","Publication_Code" as "Publication_code","Pub_Cent_Code" as "Pub_cent_code","Supp_Code" as "Supp_code",nvl("Agreed_Rate",'0') as "Agreed_rate","Pai_Free_Ins" as "Pai_free_ins",nvl("Solo_Rate",'0') as "Solo_rate","Insert_Id" as "insert_id","Gross_Rate" as "Gross_rate","Page_No" as "Page_no" ,"Remarks","Page_Prem" as "Page_prem",nvl("Page_Per",'0') as "page_per","No_Ofcolumn" as "No_ofcolumn","Bill_Amt" as "Bill_Amt","Bill_Rate" as "Bill_rate", "Logo_H" as "Logo_H", "Logo_W" as "Logo_W" , "Logo_name" as "Logo_name","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS
        ,"Publication_Code" AS "PUBCODE",
 (SELECT VTS FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as VTS,
 (SELECT PUBLICATION FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as CIRPUBLICATION,
 (SELECT EDITION FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as CIREDITION,
 (SELECT RATE FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as CIRRATE,
 (SELECT PUBLISHDATE FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as CIRPUBLISHDATE,
 (SELECT edtn_name FROM cir_edtn_mast WHERE comp_code=compcode AND edtn=(SELECT EDITION FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id")) AS CIREDITIONNAME
 ,
(select NVL(PRIORITY,'1') FROM TBL_PRIORITY_UOM WHERE EDITION_CODE=TBL_BOOKING_INSERT."Edition_Code" and TBL_PRIORITY_UOM.COMBIN_CODE=TBL_BOOKING_INSERT.PACKAGE_CODE) AS PRIORITY,
(SELECT SPLIT FROM COMBIN_MAST WHERE "Combin_Code"=PACKAGE_CODE)  as SPLIT,SPECIAL_SIZE1,VATAMT, nvl(BOXCHARGE,'') as BOXCHARGE,NVL(VAT_INC,'0') as VAT_INC,nvl(LOCALGROSSAMT,"Gross_Rate") as LOCALGROSSAMT, nvl(LOCALBILLAMT,"Bill_Amt") AS LOCALBILLAMT,
NVL(SECTIONCODE,'') AS SECTIONCODE, NVL(RESOURCE_NO,'') AS RESOURCE_NO,NVL(CAPTION,'') AS CAPTION,DEALER_H,DEALER_W,NVL(DISCOUNT,'') AS DISCOUNT
         from tbl_booking_insert where ("Comp_Code"=compcode) and ("Cio_Booking_Id"=ciobid) order by "Insert_Status";


    OPEN p_accounts1 FOR
        select "Col_Name" as  "col_Name","Col_Code" as "col_Code" from col_mast where ("Comp_Code"=compcode);
    OPEN p_accounts2 FOR
        select "premiumname" as "premiumname","Premiumcode" as "Premiumcode" from ADVPOS_PREM_MAST where ("comp_code"=compcode);
    OPEN p_accounts3 FOR
        select "Adv_Subcat_Name","Adv_Subcat_Code" from adv_subcat_mast;
    OPEN p_accounts4 FOR
        select "Uom_Name" as "uom_name","Uom_Code" as "uom_code" from uom_mast where ("Comp_Code"=compcode);
    OPEN p_accounts5 FOR
        select "Adv_Type_Name" as "adv_type_name","Adv_Type_Code" as "adv_type_code" from adv_type_mast where "Comp_Code"=compcode;
    OPEN p_accounts6 FOR
        select "Adv_Cat_Name" as "adv_cat_name","Adv_Cat_Code" as "adv_cat_code" from ADV_CAT_MAST where ("Comp_Code"=compcode);
    OPEN p_accounts7 FOR
        select "Pos_Type_Code" as "pos_type_code","Pos_Type" as "pos_type" from advpos_type_mast where ("Comp_Code"=compcode);
    OPEN p_accounts8 FOR
        select   "Paid_permission"   from Module_DetaiButtonl  where ("comp_code"=compcode) and ("Form_Name"='Booking_master');

    open p_accounts9 for
        select "Logo_name" as "Logo_name"from tbl_booking_insert where "Comp_Code"=compcode and "Cio_Booking_Id"=ciobid and rownum<=1;

    open p_accounts10 for
        select "catname","catcode" from ad_cat3 where "subcatname" in (select AD_SUB_CAT from advcategories) order by "catname";

    open p_accounts11 for
        select "Cat_Name","Cat_Code" from tbl_cat4 where "Sub_Cat_Name" in (select AD_SUBCAT3 from advcategories) order by "Cat_Name";

    open p_accounts12 for
        select "Cat_Name","Cat_Code" from tbl_cat5 where "Sub_Cat_Name" in (select AD_SUBCAT4 from advcategories) order by "Cat_Name";
    
 
 
   END  getdataforexecute1_P;
END  getdataforexecute1;
/








CREATE OR REPLACE PROCEDURE HT18JULY.chkdiscountpremedit_per
 (
   compcode           IN       VARCHAR2,
   userid1               IN       VARCHAR2,
   
   p_accounts    OUT      cur_type_new1.cursor_type
)
IS
BEGIN
   OPEN p_accounts FOR
         select PERMISSION_DESC from userpermission where COMM_CODE=compcode and USERID=userid1 and
          PERMISSION_DESC='Allow Editing Discount Item Line Wise In Transaction';
END;
/


/////////------shipra-------5/25/2012----------done by lata mam//////////



=========start===7233=====avinash================================================
CREATE OR REPLACE procedure HT18JULY.billreportbilled(
    pcompcode             in varchar2,
    prowname                 in varchar2,
    pcolumnname         in varchar2,
    pconditioncheck in varchar2,
    pfromdate             in varchar2,
    ptodate                 in varchar2,
    pdateformat         in varchar2,
    puserid in varchar2:=null,
    chk_access in varchar2:=null,
    p_accounts             out Cur_Type_New1.cursor_type)is

    prefer   varchar2(10);
    v_query varchar2(8000);
    v_frdt  date;
    v_todt date;
    v_var   varchar2(4000);
    v_var_sum varchar2(4000);
        cursor c1 is
            select distinct col_code,substr(upper(nvl(col_desc,col_code)),1,20) col_desc from temp_complete_dynamic_report
            where sess_id=userenv('sessionid') order by 2;
v1 c1%rowtype;
begin
    v_frdt:=to_date(pfromdate,''''||pdateformat||'''');
    v_todt:=to_date(ptodate,''''||pdateformat||'''');
    delete from temp_complete_dynamic_report where sess_id=userenv('sessionid');

select distinct AGENCY_RETAINER_COMM into prefer from preferrences where "comp_code"=pcompcode;


--publication



   if(prowname='Publication' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    SELECT "Pub_Code","Publication","Supplement_CODE","Supplement",SUM("Billamt"),SUM("ActualBusiness"),"SESS" FROM(
    select  tbl_booking_insert."Publication_Code" as "Pub_Code",
    (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
    tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and tbl_booking_insert."Publication_Code"=supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition" as "Ed_Name",userenv('sessionid') AS "SESS"
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and
               -- tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_insert."Publication_Code" is not null and tbl_booking_insert."Publication_Code" !='0')
    GROUP BY "Pub_Code","Publication","Supplement_CODE","Supplement","SESS"
    ORDER BY "Pub_Code","Publication","Supplement_CODE","Supplement";


    elsif(prowname='Publication' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    SELECT "Pub_Code","Publication","Ad_catg_code","Adv_Catg_Name" ,SUM("Billamt"),SUM("ActualBusiness"),"SESS" FROM(
    select  tbl_booking_insert."Publication_Code" as "Pub_Code",
    (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
    tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition" as "Ed_Name"
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
             --   tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
             tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
             ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_insert."Publication_Code" is not null and tbl_booking_insert."Publication_Code" !='0')
    GROUP BY "Pub_Code","Publication","Ad_catg_code","Adv_Catg_Name"
    ,"SESS"  ORDER BY "Pub_Code","Publication","Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='Publication' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    SELECT "Pub_Code","Publication","Agency_Type_Code" ,"Agency_type_name" ,SUM("Billamt"),SUM("ActualBusiness"),"SESS" FROM(
    select  tbl_booking_insert."Publication_Code" as "Pub_Code",
    (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
    (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition" as "Ed_Name"
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_insert."Publication_Code" is not null and tbl_booking_insert."Publication_Code" !='0')
    GROUP BY "Pub_Code","Publication","Agency_Type_Code" ,"Agency_type_name" 
    ,"SESS"  ORDER BY "Pub_Code","Publication","Agency_Type_Code" ,"Agency_type_name" ;

    elsif(prowname='Publication' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Pub_Code","Publication","Scheme_code","Scheme_name",SUM("Billamt"),SUM("ActualBusiness"),"SESS" FROM(
    select  tbl_booking_insert."Publication_Code" as "Pub_Code",
    (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
    tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition" as "Ed_Name"
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
             --   tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_insert."Publication_Code" is not null and tbl_booking_insert."Publication_Code" !='0')
    GROUP BY "Pub_Code","Publication","Scheme_code","Scheme_name"
    ,"SESS"  ORDER BY "Pub_Code","Publication","Scheme_code","Scheme_name";


     elsif(prowname='Publication' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Pub_Code","Publication","Page_premium_code","Page_premium_name",SUM("Billamt"),SUM("ActualBusiness"),"SESS" FROM(
    select  tbl_booking_insert."Publication_Code"as "Pub_Code",
    (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
    tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition" as "Ed_Name"
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_insert."Publication_Code" is not null and tbl_booking_insert."Publication_Code" !='0'
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0')
    GROUP BY "Pub_Code","Publication","Page_premium_code","Page_premium_name"
    ,"SESS"  ORDER BY "Pub_Code","Publication","Page_premium_code","Page_premium_name";

         elsif(prowname='Publication' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Pub_Code","Publication","Postprem_code","Postprem_name",SUM("Billamt"),SUM("ActualBusiness"),"SESS" FROM(
    select  tbl_booking_insert."Publication_Code" as "Pub_Code",
    (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
    tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition" as "Ed_Name"
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                  ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_insert."Publication_Code" is not null and tbl_booking_insert."Publication_Code" !='0'
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0')
    GROUP BY "Pub_Code","Publication","Postprem_code","Postprem_name"
    ,"SESS"  ORDER BY "Pub_Code","Publication","Postprem_code","Postprem_name";


--edition

    elsif(prowname='Edition' and pcolumnname='Publication')then
    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    SELECT "Edition_Code","Edition","Pub_Code","Publication",SUM("Billamt"),SUM("ActualBusiness"),"SESS" FROM(
    select 
    tbl_booking_insert."Edition_Code" as "Edition_Code",tbl_booking_insert."Edition" as "Edition",
    tbl_booking_insert."Publication_Code" as "Pub_Code",
    (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition" as "Ed_Name"
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Edition_Code","Edition","Pub_Code","Publication"
    ,"SESS"  ORDER BY "Edition_Code","Edition","Pub_Code","Publication";



elsif(prowname='Edition' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    SELECT "Edition_Code","Edition","Supplement_CODE","Supplement",SUM("Billamt"),SUM("ActualBusiness"),"SESS" FROM(
    select 
    tbl_booking_insert."Edition_Code" as "Edition_Code",tbl_booking_insert."Edition" as "Edition",
    tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and tbl_booking_insert."Publication_Code"=supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition" as "Ed_Name"
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Edition_Code","Edition","Supplement_CODE","Supplement"
    ,"SESS"  ORDER BY "Edition_Code","Edition","Supplement_CODE","Supplement";


    elsif(prowname='Edition' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    SELECT "Edition_Code","Edition","Ad_catg_code","Adv_Catg_Name",SUM("Billamt"),SUM("ActualBusiness"),"SESS" FROM(
    select  tbl_booking_insert."Edition_Code" as "Edition_Code",tbl_booking_insert."Edition" as "Edition",
    tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition" as "Ed_Name"
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Edition_Code","Edition","Ad_catg_code","Adv_Catg_Name"
    ,"SESS"  ORDER BY "Edition_Code","Edition","Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='Edition' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    SELECT "Edition_Code","Edition","Agency_Type_Code","Agency_type_name",SUM("Billamt"),SUM("ActualBusiness"),"SESS" FROM(
    select  tbl_booking_insert."Edition_Code" as "Edition_Code",tbl_booking_insert."Edition" as "Edition",
    (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition" as "Ed_Name"
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                ---tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Edition_Code","Edition","Agency_Type_Code","Agency_type_name"
    ,"SESS"  ORDER BY "Edition_Code","Edition","Agency_Type_Code","Agency_type_name";

    elsif(prowname='Edition' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
     SELECT "Edition_Code","Edition","Scheme_code","Scheme_name",SUM("Billamt"),SUM("ActualBusiness"),"SESS" FROM(
    select  tbl_booking_insert."Edition_Code" as "Edition_Code",tbl_booking_insert."Edition" as "Edition",
    tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition" as "Ed_Name"
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Edition_Code","Edition","Scheme_code","Scheme_name"
    ,"SESS"  ORDER BY "Edition_Code","Edition","Scheme_code","Scheme_name";


     elsif(prowname='Edition' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    SELECT "Edition_Code","Edition","Page_premium_code","Page_premium_name",SUM("Billamt"),SUM("ActualBusiness"),"SESS" FROM(
    select  tbl_booking_insert."Edition_Code" as "Edition_Code",tbl_booking_insert."Edition" as "Edition",
    tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition" as "Ed_Name"
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0')
    GROUP BY "Edition_Code","Edition","Page_premium_code","Page_premium_name"
    ,"SESS"  ORDER BY "Edition_Code","Edition","Page_premium_code","Page_premium_name";

         elsif(prowname='Edition' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    SELECT "Edition_Code","Edition","Postprem_code","Postprem_name",SUM("Billamt"),SUM("ActualBusiness"),"SESS" FROM(
    select  tbl_booking_insert."Edition_Code" as "Edition_Code",tbl_booking_insert."Edition" as "Edition",
    tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0')
    GROUP BY "Edition_Code","Edition","Postprem_code","Postprem_name"
    ,"SESS"  ORDER BY "Edition_Code","Edition","Postprem_code","Postprem_name";

--AGENCY



elsif(prowname='Agency' and pcolumnname='Publication')then
    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Agency_Code","Agency_Namee","Pub_Code","Publication",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
      (select "Agency_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Agency_Code",
     (select "Agency_Name" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Agency_Namee",
    tbl_booking_insert."Publication_Code" as "Pub_Code",
    (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
            --    tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY  "Agency_Code","Agency_Namee","Pub_Code","Publication"
    ,"SESS"  ORDER BY "Agency_Code","Agency_Namee","Pub_Code","Publication";


elsif(prowname='Agency' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
     select "Agency_Code","Agency_Namee","Supplement_CODE","Supplement",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
     (select "Agency_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Agency_Code",
     (select "Agency_Name" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Agency_Namee",
    tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and tbl_booking_insert."Publication_Code" =supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Agency_Code","Agency_Namee","Supplement_CODE","Supplement"
    ,"SESS"  ORDER BY "Agency_Code","Agency_Namee","Supplement_CODE","Supplement";


    elsif(prowname='Agency' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
     select "Agency_Code","Agency_Namee","Ad_catg_code","Adv_Catg_Name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
    (select "Agency_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Agency_Code",
     (select "Agency_Name" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Agency_Namee",

    tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Agency_Code","Agency_Namee","Ad_catg_code","Adv_Catg_Name"
    ,"SESS"  ORDER BY "Agency_Code","Agency_Namee","Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='Agency' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
     select "Agency_Code","Agency_Namee","Agency_Type_Code","Agency_type_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
     (select "Agency_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Agency_Code",
     (select "Agency_Name" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Agency_Namee",

    (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Agency_Code","Agency_Namee","Agency_Type_Code","Agency_type_name"
    ,"SESS"  ORDER BY "Agency_Code","Agency_Namee","Agency_Type_Code","Agency_type_name";

    elsif(prowname='Agency' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Agency_Code","Agency_Namee","Scheme_code","Scheme_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
    (select "Agency_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Agency_Code",
     (select "Agency_Name" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Agency_Namee",

    tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Agency_Code","Agency_Namee","Scheme_code","Scheme_name"
    ,"SESS"  ORDER BY "Agency_Code","Agency_Namee","Scheme_code","Scheme_name";


     elsif(prowname='Agency' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
        select "Agency_Code","Agency_Namee","Page_premium_code","Page_premium_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
    (select "Agency_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Agency_Code",
     (select "Agency_Name" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Agency_Namee",

    tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0')
    GROUP BY "Agency_Code","Agency_Namee","Page_premium_code","Page_premium_name"
    ,"SESS"  ORDER BY "Agency_Code","Agency_Namee","Page_premium_code","Page_premium_name";

         elsif(prowname='Agency' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Agency_Code","Agency_Namee","Postprem_code","Postprem_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
     (select "Agency_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Agency_Code",
     (select "Agency_Name" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Agency_Namee",

    tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0')
    GROUP BY "Agency_Code","Agency_Namee","Postprem_code","Postprem_name"
    ,"SESS"  ORDER BY "Agency_Code","Agency_Namee","Postprem_code","Postprem_name";


--client




elsif(prowname='Client' and pcolumnname='Publication')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Client_Code","Client_Name","Pub_Code","Publication",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
      tbl_booking_mast."Client_code" as "Client_Code",
    nvl( (select "Cust_Name" from cust_mast where tbl_booking_mast."Client_code"= cust_mast."Cust_Code" ),tbl_booking_mast."Client_code") as "Client_Name",
   tbl_booking_insert."Publication_Code" as "Pub_Code",
   (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code" ) as "Publication",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Client_Code","Client_Name","Pub_Code","Publication"
    ,"SESS"  ORDER BY "Client_Code","Client_Name","Pub_Code","Publication";


elsif(prowname='Client' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Client_Code","Client_Name","Supplement_CODE","Supplement",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
    tbl_booking_mast."Client_code" as "Client_Code",
    nvl( (select "Cust_Name" from cust_mast where tbl_booking_mast."Client_code"= cust_mast."Cust_Code" ),tbl_booking_mast."Client_code") as "Client_Name",
     tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and tbl_booking_insert."Publication_Code"=supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and

                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Client_Code","Client_Name","Supplement_CODE","Supplement"
    ,"SESS"  ORDER BY "Client_Code","Client_Name","Supplement_CODE","Supplement";


    elsif(prowname='Client' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Client_Code","Client_Name","Ad_catg_code","Adv_Catg_Name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
    tbl_booking_mast."Client_code" as "Client_Code",
    nvl( (select "Cust_Name" from cust_mast where tbl_booking_mast."Client_code"= cust_mast."Cust_Code" ),tbl_booking_mast."Client_code") as "Client_Name",
     tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Client_Code","Client_Name","Ad_catg_code","Adv_Catg_Name"
    ,"SESS"  ORDER BY "Client_Code","Client_Name","Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='Client' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Client_Code","Client_Name","Agency_Type_Code","Agency_type_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
       tbl_booking_mast."Client_code" as "Client_Code",
    nvl( (select "Cust_Name" from cust_mast where tbl_booking_mast."Client_code"= cust_mast."Cust_Code" ),tbl_booking_mast."Client_code") as "Client_Name",
 (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Client_Code","Client_Name","Agency_Type_Code","Agency_type_name"
    ,"SESS"  ORDER BY "Client_Code","Client_Name","Agency_Type_Code","Agency_type_name";

    elsif(prowname='Client' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
     select "Client_Code","Client_Name","Scheme_code","Scheme_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
      tbl_booking_mast."Client_code" as "Client_Code",
    nvl( (select "Cust_Name" from cust_mast where tbl_booking_mast."Client_code"= cust_mast."Cust_Code" ),tbl_booking_mast."Client_code") as "Client_Name",
   tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Client_Code","Client_Name","Scheme_code","Scheme_name"
    ,"SESS"  ORDER BY "Client_Code","Client_Name","Scheme_code","Scheme_name";


     elsif(prowname='Client' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
     select "Client_Code","Client_Name","Page_premium_code","Page_premium_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
      tbl_booking_mast."Client_code" as "Client_Code",
    nvl( (select "Cust_Name" from cust_mast where tbl_booking_mast."Client_code"= cust_mast."Cust_Code" ),tbl_booking_mast."Client_code") as "Client_Name",
   tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0')
    GROUP BY "Client_Code","Client_Name","Page_premium_code","Page_premium_name"
    ,"SESS"  ORDER BY "Client_Code","Client_Name","Page_premium_code","Page_premium_name";

         elsif(prowname='Client' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Client_Code","Client_Name","Postprem_code","Postprem_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
        tbl_booking_mast."Client_code" as "Client_Code",
    nvl( (select "Cust_Name" from cust_mast where tbl_booking_mast."Client_code"= cust_mast."Cust_Code" ),tbl_booking_mast."Client_code") as "Client_Name",
    tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0')
    GROUP BY "Client_Code","Client_Name","Postprem_code","Postprem_name"
    ,"SESS"  ORDER BY "Client_Code","Client_Name","Postprem_code","Postprem_name";



--Revenue Center



elsif(prowname='Revenue Center' and pcolumnname='Publication')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Revcode","Revcenter","Pub_Code","Publication",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
      tbl_booking_mast."Revenue_center" as "Revcode",
    (SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE tbl_booking_mast."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter",
   tbl_booking_insert."Publication_Code" as "Pub_Code",
   (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Revenue_center" is not null and tbl_booking_mast."Revenue_center"!='0')
    GROUP BY  "Revcode","Revcenter","Pub_Code","Publication"
    ,"SESS"  ORDER BY  "Revcode","Revcenter","Pub_Code","Publication";


elsif(prowname='Revenue Center' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Revcode","Revcenter","Supplement_CODE","Supplement",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   tbl_booking_mast."Revenue_center" as "Revcode",
    (SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE tbl_booking_mast."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter",
    tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and tbl_booking_insert."Publication_Code"=supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                    tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Revenue_center" is not null and tbl_booking_mast."Revenue_center"!='0')
    GROUP BY  "Revcode","Revcenter","Supplement_CODE","Supplement"
    ,"SESS"  ORDER BY  "Revcode","Revcenter","Supplement_CODE","Supplement";


    elsif(prowname='Revenue Center' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Revcode","Revcenter","Ad_catg_code","Adv_Catg_Name" ,sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  tbl_booking_mast."Revenue_center" as "Revcode",
    (SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE tbl_booking_mast."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter",
    tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Revenue_center" is not null and tbl_booking_mast."Revenue_center"!='0')
    GROUP BY "Revcode","Revcenter","Ad_catg_code","Adv_Catg_Name" 
    ,"SESS"  ORDER BY "Revcode","Revcenter","Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='Revenue Center' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Revcode","Revcenter","Agency_Type_Code" ,"Agency_type_name" ,sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
      tbl_booking_mast."Revenue_center" as "Revcode",
    (SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE tbl_booking_mast."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter",
    (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Revenue_center" is not null and tbl_booking_mast."Revenue_center"!='0')
    GROUP BY  "Revcode","Revcenter","Agency_Type_Code" ,"Agency_type_name"
    ,"SESS"  ORDER BY  "Revcode","Revcenter","Agency_Type_Code" ,"Agency_type_name";

    elsif(prowname='Revenue Center' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Revcode","Revcenter","Scheme_code","Scheme_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
      tbl_booking_mast."Revenue_center" as "Revcode",
    (SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE tbl_booking_mast."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter",
  tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Revenue_center" is not null and tbl_booking_mast."Revenue_center"!='0')
    GROUP BY "Revcode","Revcenter","Scheme_code","Scheme_name"
    ,"SESS"  ORDER BY "Revcode","Revcenter","Scheme_code","Scheme_name";


     elsif(prowname='Revenue Center' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Revcode","Revcenter","Page_premium_code","Page_premium_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
      tbl_booking_mast."Revenue_center" as "Revcode",
    (SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE tbl_booking_mast."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter",
     tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Revenue_center" is not null and tbl_booking_mast."Revenue_center"!='0'
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0')
    GROUP BY  "Revcode","Revcenter","Page_premium_code","Page_premium_name"
    ,"SESS"  ORDER BY  "Revcode","Revcenter","Page_premium_code","Page_premium_name";

         elsif(prowname='Revenue Center' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Revcode","Revcenter","Postprem_code","Postprem_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
      tbl_booking_mast."Revenue_center" as "Revcode",
    (SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE tbl_booking_mast."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter",

    tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0'
                and tbl_booking_mast."Revenue_center" is not null and tbl_booking_mast."Revenue_center"!='0')
    GROUP BY "Revcode","Revcenter","Postprem_code","Postprem_name"
    ,"SESS"  ORDER BY "Revcode","Revcenter","Postprem_code","Postprem_name";


--Printing Center




elsif(prowname='Printing Center' and pcolumnname='Publication')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "pubcent_Code","pubcent_Name","Pub_Code","Publication",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
/*old version
      (SELECT pub_cent_mast."Pub_cent_Code" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Name")) as "pubcent_Code",
     (SELECT pub_cent_mast."Pub_Cent_name" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Name"))as "pubcent_Name",
     */
     --new ersion
      (SELECT pub_cent_mast."Pub_cent_Code" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Code")) as "pubcent_Code",
     (SELECT pub_cent_mast."Pub_Cent_name" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Code"))as "pubcent_Name",
     
       tbl_booking_insert."Publication_Code" as "Pub_Code",
       (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code")as "Publication",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                /*--old version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" ))
*/
--new version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" ))

                and tbl_booking_insert."Pub_Cent_Code" is not null and tbl_booking_insert."Pub_Cent_Code"!='0'
               )
    
              GROUP BY "pubcent_Code","pubcent_Name","Pub_Code","Publication"
    ,"SESS"  ORDER BY "pubcent_Code","pubcent_Name","Pub_Code","Publication";


elsif(prowname='Printing Center' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "pubcent_Code","pubcent_Name","Supplement_CODE","Supplement",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  /*old version
      (SELECT pub_cent_mast."Pub_cent_Code" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Name")) as "pubcent_Code",
     (SELECT pub_cent_mast."Pub_Cent_name" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Name"))as "pubcent_Name",
     */
     --new ersion
      (SELECT pub_cent_mast."Pub_cent_Code" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Code")) as "pubcent_Code",
     (SELECT pub_cent_mast."Pub_Cent_name" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Code"))as "pubcent_Name",
     
    tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and tbl_booking_insert."Publication_Code"=supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                /*--old version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" ))
*/
--new version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" ))

                and tbl_booking_insert."Pub_Cent_Code" is not null and tbl_booking_insert."Pub_Cent_Code"!='0')
    GROUP BY  "pubcent_Code","pubcent_Name","Supplement_CODE","Supplement"
    ,"SESS"  ORDER BY  "pubcent_Code","pubcent_Name","Supplement_CODE","Supplement";


    elsif(prowname='Printing Center' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "pubcent_Code","pubcent_Name","Ad_catg_code","Adv_Catg_Name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
 /*old version
      (SELECT pub_cent_mast."Pub_cent_Code" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Name")) as "pubcent_Code",
     (SELECT pub_cent_mast."Pub_Cent_name" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Name"))as "pubcent_Name",
     */
     --new ersion
      (SELECT pub_cent_mast."Pub_cent_Code" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Code")) as "pubcent_Code",
     (SELECT pub_cent_mast."Pub_Cent_name" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Code"))as "pubcent_Name",
     
    tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                /*--old version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" ))
*/
--new version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" ))

                and tbl_booking_insert."Pub_Cent_Code" is not null and tbl_booking_insert."Pub_Cent_Code"!='0')
    GROUP BY "pubcent_Code","pubcent_Name","Ad_catg_code","Adv_Catg_Name"
    ,"SESS"  ORDER BY "pubcent_Code","pubcent_Name","Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='Printing Center' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "pubcent_Code","pubcent_Name","Agency_Type_Code","Agency_type_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  /*old version
      (SELECT pub_cent_mast."Pub_cent_Code" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Name")) as "pubcent_Code",
     (SELECT pub_cent_mast."Pub_Cent_name" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Name"))as "pubcent_Name",
     */
     --new ersion
      (SELECT pub_cent_mast."Pub_cent_Code" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Code")) as "pubcent_Code",
     (SELECT pub_cent_mast."Pub_Cent_name" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Code"))as "pubcent_Name",
     
    (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                /*--old version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" ))
*/
--new version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" ))

                and tbl_booking_insert."Pub_Cent_Code" is not null and tbl_booking_insert."Pub_Cent_Code"!='0')
    GROUP BY  "pubcent_Code","pubcent_Name","Agency_Type_Code","Agency_type_name"
    ,"SESS"  ORDER BY  "pubcent_Code","pubcent_Name","Agency_Type_Code","Agency_type_name";

    elsif(prowname='Printing Center' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "pubcent_Code","pubcent_Name","Scheme_code","Scheme_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  /*old version
      (SELECT pub_cent_mast."Pub_cent_Code" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Name")) as "pubcent_Code",
     (SELECT pub_cent_mast."Pub_Cent_name" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Name"))as "pubcent_Name",
     */
     --new ersion
      (SELECT pub_cent_mast."Pub_cent_Code" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Code")) as "pubcent_Code",
     (SELECT pub_cent_mast."Pub_Cent_name" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Code"))as "pubcent_Name",
     
    tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
   nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                /*--old version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" ))
*/
--new version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" ))

                and tbl_booking_insert."Pub_Cent_Code" is not null and tbl_booking_insert."Pub_Cent_Code"!='0')
    GROUP BY "pubcent_Code","pubcent_Name","Scheme_code","Scheme_name"
    ,"SESS"  ORDER BY "pubcent_Code","pubcent_Name","Scheme_code","Scheme_name";


     elsif(prowname='Printing Center' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "pubcent_Code","pubcent_Name","Page_premium_code","Page_premium_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  /*old version
      (SELECT pub_cent_mast."Pub_cent_Code" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Name")) as "pubcent_Code",
     (SELECT pub_cent_mast."Pub_Cent_name" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Name"))as "pubcent_Name",
     */
     --new ersion
      (SELECT pub_cent_mast."Pub_cent_Code" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Code")) as "pubcent_Code",
     (SELECT pub_cent_mast."Pub_Cent_name" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Code"))as "pubcent_Name",
     
    tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                /*--old version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" ))
*/
--new version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" ))

                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0'
                and tbl_booking_insert."Pub_Cent_Code" is not null and tbl_booking_insert."Pub_Cent_Code"!='0')
    GROUP BY "pubcent_Code","pubcent_Name","Page_premium_code","Page_premium_name"
    ,"SESS"  ORDER BY "pubcent_Code","pubcent_Name","Page_premium_code","Page_premium_name";

         elsif(prowname='Printing Center' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
     select "pubcent_Code","pubcent_Name","Postprem_code","Postprem_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   /*old version
      (SELECT pub_cent_mast."Pub_cent_Code" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Name")) as "pubcent_Code",
     (SELECT pub_cent_mast."Pub_Cent_name" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Name"))as "pubcent_Name",
     */
     --new ersion
      (SELECT pub_cent_mast."Pub_cent_Code" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Code")) as "pubcent_Code",
     (SELECT pub_cent_mast."Pub_Cent_name" FROM PUB_CENT_MAST WHERE pub_cent_mast."Pub_cent_Code" IN(SELECT branch_mst."pub_center" FROM BRANCH_MST WHERE branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" AND TBL_BOOKING_MAST."branch"="Branch_Code"))as "pubcent_Name",
     
    tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                /*--old version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" ))
*/
--new version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" ))

                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0'
                and tbl_booking_insert."Pub_Cent_Code" is not null and tbl_booking_insert."Pub_Cent_Code"!='0')
    GROUP BY "pubcent_Code","pubcent_Name","Postprem_code","Postprem_name"
    ,"SESS"  ORDER BY "pubcent_Code","pubcent_Name","Postprem_code","Postprem_name";

--Region




elsif(prowname='Region' and pcolumnname='Publication')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Region_Code","Region_Name","Pub_Code","Publication",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
       (select AGENCY_MAST."region"  from AGENCY_MAST where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Region_Code",
    (SELECT REGION_MST."Region_Name" FROM REGION_MST WHERE REGION_MST."Region_Code" IN(select AGENCY_MAST."region"  from AGENCY_MAST where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")  )    as "Region_Name",
     TBL_BOOKING_INSERT."Publication_Code" as "Pub_Code",
     (SELECT pub_mast."Pub_Name" FROM PUB_MAST WHERE pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code"  ) as "Publication",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Region_Code","Region_Name","Pub_Code","Publication"
    ,"SESS"  ORDER BY "Region_Code","Region_Name","Pub_Code","Publication";


elsif(prowname='Region' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Region_Code","Region_Name","Supplement_CODE","Supplement",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
     (select AGENCY_MAST."region"  from AGENCY_MAST where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Region_Code",
    (SELECT REGION_MST."Region_Name" FROM REGION_MST WHERE REGION_MST."Region_Code" IN(select AGENCY_MAST."region"  from AGENCY_MAST where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")  )    as "Region_Name",
       tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and TBL_BOOKING_INSERT."Publication_Code" =supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Region_Code","Region_Name","Supplement_CODE","Supplement"
    ,"SESS"  ORDER BY "Region_Code","Region_Name","Supplement_CODE","Supplement";


    elsif(prowname='Region' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Region_Code","Region_Name","Ad_catg_code","Adv_Catg_Name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  (select AGENCY_MAST."region"  from AGENCY_MAST where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Region_Code",
    (SELECT REGION_MST."Region_Name" FROM REGION_MST WHERE REGION_MST."Region_Code" IN(select AGENCY_MAST."region"  from AGENCY_MAST where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")  )    as "Region_Name",
       tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
              --  tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Region_Code","Region_Name","Ad_catg_code","Adv_Catg_Name"
    ,"SESS"  ORDER BY "Region_Code","Region_Name","Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='Region' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Region_Code","Region_Name","Agency_Type_Code","Agency_type_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
    (select AGENCY_MAST."region"  from AGENCY_MAST where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Region_Code",
    (SELECT REGION_MST."Region_Name" FROM REGION_MST WHERE REGION_MST."Region_Code" IN(select AGENCY_MAST."region"  from AGENCY_MAST where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")  )    as "Region_Name",
      (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
            --    tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Region_Code","Region_Name","Agency_Type_Code","Agency_type_name"
    ,"SESS"  ORDER BY "Region_Code","Region_Name","Agency_Type_Code","Agency_type_name";

    elsif(prowname='Region' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Region_Code","Region_Name","Scheme_code","Scheme_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
     (select AGENCY_MAST."region"  from AGENCY_MAST where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Region_Code",
    (SELECT REGION_MST."Region_Name" FROM REGION_MST WHERE REGION_MST."Region_Code" IN(select AGENCY_MAST."region"  from AGENCY_MAST where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")  )    as "Region_Name",
   tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
  nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Region_Code","Region_Name","Scheme_code","Scheme_name"
    ,"SESS"  ORDER BY "Region_Code","Region_Name","Scheme_code","Scheme_name";


     elsif(prowname='Region' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Region_Code","Region_Name","Page_premium_code","Page_premium_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
      (select AGENCY_MAST."region"  from AGENCY_MAST where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Region_Code",
    (SELECT REGION_MST."Region_Name" FROM REGION_MST WHERE REGION_MST."Region_Code" IN(select AGENCY_MAST."region"  from AGENCY_MAST where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")  )    as "Region_Name",
   tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0')
    GROUP BY "Region_Code","Region_Name","Page_premium_code","Page_premium_name"
    ,"SESS"  ORDER BY "Region_Code","Region_Name","Page_premium_code","Page_premium_name" ;

         elsif(prowname='Region' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Region_Code","Region_Name","Postprem_code","Postprem_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
        (select AGENCY_MAST."region"  from AGENCY_MAST where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Region_Code",
    (SELECT REGION_MST."Region_Name" FROM REGION_MST WHERE REGION_MST."Region_Code" IN(select AGENCY_MAST."region"  from AGENCY_MAST where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")  )    as "Region_Name",

    tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0')
    GROUP BY  "Region_Code","Region_Name","Postprem_code","Postprem_name"
    ,"SESS"  ORDER BY  "Region_Code","Region_Name","Postprem_code","Postprem_name";

--State



elsif(prowname='State' and pcolumnname='Publication')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "State_Code","State_Name","Pub_Code","Publication",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select AGENCY_MAST."State_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "State_Code",
      (select AGENCY_MAST."State_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "State_Name",
      tbl_booking_insert."Publication_Code" as "Pub_Code",
      (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "State_Code","State_Name","Pub_Code","Publication"
    ,"SESS"  ORDER BY "State_Code","State_Name","Pub_Code","Publication";


elsif(prowname='State' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "State_Code","State_Name","Supplement_CODE","Supplement",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select AGENCY_MAST."State_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "State_Code",
      (select AGENCY_MAST."State_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "State_Name",
      tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and tbl_booking_insert."Publication_Code"=supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "State_Code","State_Name","Supplement_CODE","Supplement"
    ,"SESS"  ORDER BY "State_Code","State_Name","Supplement_CODE","Supplement";


    elsif(prowname='State' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "State_Code","State_Name","Ad_catg_code","Adv_Catg_Name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
    (select AGENCY_MAST."State_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "State_Code",
      (select AGENCY_MAST."State_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "State_Name",
      tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "State_Code","State_Name","Ad_catg_code","Adv_Catg_Name"
    ,"SESS"  ORDER BY "State_Code","State_Name","Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='State' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "State_Code","State_Name","Agency_Type_Code","Agency_type_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select AGENCY_MAST."State_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "State_Code",
      (select AGENCY_MAST."State_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "State_Name",
      (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "State_Code","State_Name","Agency_Type_Code","Agency_type_name"
    ,"SESS"  ORDER BY "State_Code","State_Name","Agency_Type_Code","Agency_type_name";

    elsif(prowname='State' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "State_Code","State_Name","Scheme_code","Scheme_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
    (select AGENCY_MAST."State_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "State_Code",
      (select AGENCY_MAST."State_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "State_Name",
    tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
  nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY  "State_Code","State_Name","Scheme_code","Scheme_name"
    ,"SESS"  ORDER BY  "State_Code","State_Name","Scheme_code","Scheme_name";


     elsif(prowname='State' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "State_Code","State_Name","Page_premium_code","Page_premium_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  (select AGENCY_MAST."State_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "State_Code",
      (select AGENCY_MAST."State_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "State_Name",
      tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0')
    GROUP BY "State_Code","State_Name","Page_premium_code","Page_premium_name"
    ,"SESS"  ORDER BY "State_Code","State_Name","Page_premium_code","Page_premium_name";

         elsif(prowname='State' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "State_Code","State_Name","Postprem_code","Postprem_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
     (select AGENCY_MAST."State_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "State_Code",
      (select AGENCY_MAST."State_Code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "State_Name",

    tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0')
    GROUP BY  "State_Code","State_Name","Postprem_code","Postprem_name"
    ,"SESS"  ORDER BY  "State_Code","State_Name","Postprem_code","Postprem_name";

--Zone


elsif(prowname='Zone' and pcolumnname='Publication')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Zone_Code","Zone_Name","Pub_Code","Publication",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select AGENCY_MAST."zone_code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Zone_Code",
    (select zone_mast."Zone_Name" from zone_mast where zone_mast."Zone_Code" in(select AGENCY_MAST."zone_code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") ) as "Zone_Name",
     tbl_booking_insert."Publication_Code" as "Pub_Code",
     (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Zone_Code","Zone_Name","Pub_Code","Publication"
    ,"SESS"  ORDER BY "Zone_Code","Zone_Name","Pub_Code","Publication";


elsif(prowname='Zone' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Zone_Code","Zone_Name","Supplement_CODE","Supplement",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  (select AGENCY_MAST."zone_code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Zone_Code",
    (select zone_mast."Zone_Name" from zone_mast where zone_mast."Zone_Code" in(select AGENCY_MAST."zone_code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") ) as "Zone_Name",
       tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and tbl_booking_insert."Publication_Code"=supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and

                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Zone_Code","Zone_Name","Supplement_CODE","Supplement"
    ,"SESS"  ORDER BY "Zone_Code","Zone_Name","Supplement_CODE","Supplement";


    elsif(prowname='Zone' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Zone_Code","Zone_Name","Ad_catg_code","Adv_Catg_Name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
 (select AGENCY_MAST."zone_code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Zone_Code",
    (select zone_mast."Zone_Name" from zone_mast where zone_mast."Zone_Code" in(select AGENCY_MAST."zone_code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") ) as "Zone_Name",
      tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Zone_Code","Zone_Name","Ad_catg_code","Adv_Catg_Name"
    ,"SESS"  ORDER BY "Zone_Code","Zone_Name","Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='Zone' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Zone_Code","Zone_Name","Agency_Type_Code" ,"Agency_type_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select AGENCY_MAST."zone_code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Zone_Code",
    (select zone_mast."Zone_Name" from zone_mast where zone_mast."Zone_Code" in(select AGENCY_MAST."zone_code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") ) as "Zone_Name",
      (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
             --   tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Zone_Code","Zone_Name","Agency_Type_Code" ,"Agency_type_name"
    ,"SESS"  ORDER BY "Zone_Code","Zone_Name","Agency_Type_Code" ,"Agency_type_name";

    elsif(prowname='Zone' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Zone_Code","Zone_Name","Scheme_code","Scheme_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
 (select AGENCY_MAST."zone_code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Zone_Code",
    (select zone_mast."Zone_Name" from zone_mast where zone_mast."Zone_Code" in(select AGENCY_MAST."zone_code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") ) as "Zone_Name",
     tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
 nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Zone_Code","Zone_Name","Scheme_code","Scheme_name"
    ,"SESS"  ORDER BY "Zone_Code","Zone_Name","Scheme_code","Scheme_name";


     elsif(prowname='Zone' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Zone_Code","Zone_Name","Page_premium_code","Page_premium_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select AGENCY_MAST."zone_code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Zone_Code",
    (select zone_mast."Zone_Name" from zone_mast where zone_mast."Zone_Code" in(select AGENCY_MAST."zone_code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") ) as "Zone_Name",
    tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0')
    GROUP BY "Zone_Code","Zone_Name","Page_premium_code","Page_premium_name"
    ,"SESS"  ORDER BY "Zone_Code","Zone_Name","Page_premium_code","Page_premium_name";

         elsif(prowname='Zone' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Zone_Code","Zone_Name","Postprem_code","Postprem_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select AGENCY_MAST."zone_code" from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "Zone_Code",
    (select zone_mast."Zone_Name" from zone_mast where zone_mast."Zone_Code" in(select AGENCY_MAST."zone_code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") ) as "Zone_Name",

    tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0')
    GROUP BY "Zone_Code","Zone_Name","Postprem_code","Postprem_name"
    ,"SESS"  ORDER BY "Zone_Code","Zone_Name","Postprem_code","Postprem_name";

    --District


elsif(prowname='District' and pcolumnname='Publication')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Dist_Code","Dist_Name","Pub_Code","Publication",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select dist_mst."Dist_Code" from dist_mst where dist_mst."Dist_Name" in(select AGENCY_MAST."Dist_Code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") ) as "Dist_Code",
    (select AGENCY_MAST."Dist_Code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")  as "Dist_Name",
      tbl_booking_insert."Publication_Code" as "Pub_Code",
      (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
             tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY  "Dist_Code","Dist_Name","Pub_Code","Publication"
    ,"SESS"  ORDER BY  "Dist_Code","Dist_Name","Pub_Code","Publication";


elsif(prowname='District' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Dist_Code","Dist_Name","Supplement_CODE","Supplement",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  (select dist_mst."Dist_Code" from dist_mst where dist_mst."Dist_Name" in(select AGENCY_MAST."Dist_Code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") ) as "Dist_Code",
    (select AGENCY_MAST."Dist_Code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")  as "Dist_Name",
        tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and tbl_booking_insert."Publication_Code" =supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and

                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Dist_Code","Dist_Name","Supplement_CODE","Supplement"
    ,"SESS"  ORDER BY "Dist_Code","Dist_Name","Supplement_CODE","Supplement";


    elsif(prowname='District' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Dist_Code","Dist_Name","Ad_catg_code","Adv_Catg_Name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select dist_mst."Dist_Code" from dist_mst where dist_mst."Dist_Name" in(select AGENCY_MAST."Dist_Code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") ) as "Dist_Code",
    (select AGENCY_MAST."Dist_Code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")  as "Dist_Name",
       tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Dist_Code","Dist_Name","Ad_catg_code","Adv_Catg_Name"
    ,"SESS"  ORDER BY "Dist_Code","Dist_Name","Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='District' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Dist_Code","Dist_Name","Agency_Type_Code","Agency_type_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select dist_mst."Dist_Code" from dist_mst where dist_mst."Dist_Name" in(select AGENCY_MAST."Dist_Code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") ) as "Dist_Code",
    (select AGENCY_MAST."Dist_Code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")  as "Dist_Name",
       (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Dist_Code","Dist_Name","Agency_Type_Code","Agency_type_name"
    ,"SESS"  ORDER BY "Dist_Code","Dist_Name","Agency_Type_Code","Agency_type_name";

    elsif(prowname='District' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Dist_Code","Dist_Name","Scheme_code", "Scheme_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select dist_mst."Dist_Code" from dist_mst where dist_mst."Dist_Name" in(select AGENCY_MAST."Dist_Code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") ) as "Dist_Code",
    (select AGENCY_MAST."Dist_Code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")  as "Dist_Name",
     tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
  nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY  "Dist_Code","Dist_Name","Scheme_code", "Scheme_name"
    ,"SESS"  ORDER BY  "Dist_Code","Dist_Name","Scheme_code", "Scheme_name";


     elsif(prowname='District' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Dist_Code","Dist_Name","Page_premium_code", "Page_premium_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select dist_mst."Dist_Code" from dist_mst where dist_mst."Dist_Name" in(select AGENCY_MAST."Dist_Code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") ) as "Dist_Code",
    (select AGENCY_MAST."Dist_Code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")  as "Dist_Name",
    tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0')
    GROUP BY "Dist_Code","Dist_Name","Page_premium_code", "Page_premium_name"
    ,"SESS"  ORDER BY "Dist_Code","Dist_Name","Page_premium_code", "Page_premium_name";

         elsif(prowname='District' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Dist_Code","Dist_Name","Postprem_code", "Postprem_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
    (select dist_mst."Dist_Code" from dist_mst where dist_mst."Dist_Name" in(select AGENCY_MAST."Dist_Code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") ) as "Dist_Code",
    (select AGENCY_MAST."Dist_Code"  from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")  as "Dist_Name",

    tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0')
    GROUP BY "Dist_Code","Dist_Name","Postprem_code", "Postprem_name"
    ,"SESS"  ORDER BY "Dist_Code","Dist_Name","Postprem_code", "Postprem_name";



    --Branch




elsif(prowname='Branch' and pcolumnname='Publication')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Branch_Code","Branch_Name","Pub_Code","Publication",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
 /*--old version
 (select branch_mst."Branch_Code" from  branch_mst  where branch_mst."Branch_Name"= tbl_booking_mast."branch" ) as "Branch_Code",
     tbl_booking_mast."branch" as "Branch_Name",
     */
 --new version
  tbl_booking_mast."branch" as "Branch_Code",
 (select branch_mst."Branch_Name" from  branch_mst  where branch_mst."Branch_Code"= tbl_booking_mast."branch" ) as "Branch_Name",
  
   tbl_booking_insert."Publication_Code" as "Pub_Code",
   (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Branch_Code","Branch_Name","Pub_Code","Publication"
    ,"SESS"  ORDER BY "Branch_Code","Branch_Name","Pub_Code","Publication";


elsif(prowname='Branch' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Branch_Code","Branch_Name","Supplement_CODE","Supplement",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
/*--old version
 (select branch_mst."Branch_Code" from  branch_mst  where branch_mst."Branch_Name"= tbl_booking_mast."branch" ) as "Branch_Code",
     tbl_booking_mast."branch" as "Branch_Name",
     */
 --new version
  tbl_booking_mast."branch" as "Branch_Code",
 (select branch_mst."Branch_Name" from  branch_mst  where branch_mst."Branch_Code"= tbl_booking_mast."branch" ) as "Branch_Name",
  
       tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and  tbl_booking_insert."Publication_Code"=supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Branch_Code","Branch_Name","Supplement_CODE","Supplement"
    ,"SESS"  ORDER BY "Branch_Code","Branch_Name","Supplement_CODE","Supplement";


    elsif(prowname='Branch' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Branch_Code","Branch_Name","Ad_catg_code","Adv_Catg_Name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
/*--old version
 (select branch_mst."Branch_Code" from  branch_mst  where branch_mst."Branch_Name"= tbl_booking_mast."branch" ) as "Branch_Code",
     tbl_booking_mast."branch" as "Branch_Name",
     */
 --new version
  tbl_booking_mast."branch" as "Branch_Code",
 (select branch_mst."Branch_Name" from  branch_mst  where branch_mst."Branch_Code"= tbl_booking_mast."branch" ) as "Branch_Name",
  
      tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Branch_Code","Branch_Name","Ad_catg_code","Adv_Catg_Name"
    ,"SESS"  ORDER BY "Branch_Code","Branch_Name","Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='Branch' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Branch_Code","Branch_Name","Agency_Type_Code" ,"Agency_type_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
/*--old version
 (select branch_mst."Branch_Code" from  branch_mst  where branch_mst."Branch_Name"= tbl_booking_mast."branch" ) as "Branch_Code",
     tbl_booking_mast."branch" as "Branch_Name",
     */
 --new version
  tbl_booking_mast."branch" as "Branch_Code",
 (select branch_mst."Branch_Name" from  branch_mst  where branch_mst."Branch_Code"= tbl_booking_mast."branch" ) as "Branch_Name",
  
    (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Branch_Code","Branch_Name","Agency_Type_Code" ,"Agency_type_name"
    ,"SESS"  ORDER BY "Branch_Code","Branch_Name","Agency_Type_Code" ,"Agency_type_name";

    elsif(prowname='Branch' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Branch_Code","Branch_Name","Scheme_code" ,"Scheme_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
/*--old version
 (select branch_mst."Branch_Code" from  branch_mst  where branch_mst."Branch_Name"= tbl_booking_mast."branch" ) as "Branch_Code",
     tbl_booking_mast."branch" as "Branch_Name",
     */
 --new version
  tbl_booking_mast."branch" as "Branch_Code",
 (select branch_mst."Branch_Name" from  branch_mst  where branch_mst."Branch_Code"= tbl_booking_mast."branch" ) as "Branch_Name",
  
 tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
  nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Branch_Code","Branch_Name","Scheme_code" ,"Scheme_name"
    ,"SESS"  ORDER BY "Branch_Code","Branch_Name","Scheme_code" ,"Scheme_name";


     elsif(prowname='Branch' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Branch_Code","Branch_Name","Page_premium_code" ,"Page_premium_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
/*--old version
 (select branch_mst."Branch_Code" from  branch_mst  where branch_mst."Branch_Name"= tbl_booking_mast."branch" ) as "Branch_Code",
     tbl_booking_mast."branch" as "Branch_Name",
     */
 --new version
  tbl_booking_mast."branch" as "Branch_Code",
 (select branch_mst."Branch_Name" from  branch_mst  where branch_mst."Branch_Code"= tbl_booking_mast."branch" ) as "Branch_Name",
  
   tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0')
    GROUP BY "Branch_Code","Branch_Name","Page_premium_code" ,"Page_premium_name"
    ,"SESS"  ORDER BY "Branch_Code","Branch_Name","Page_premium_code" ,"Page_premium_name";

         elsif(prowname='Branch' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Branch_Code","Branch_Name","Postprem_code" ,"Postprem_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
/*--old version
 (select branch_mst."Branch_Code" from  branch_mst  where branch_mst."Branch_Name"= tbl_booking_mast."branch" ) as "Branch_Code",
     tbl_booking_mast."branch" as "Branch_Name",
     */
 --new version
  tbl_booking_mast."branch" as "Branch_Code",
 (select branch_mst."Branch_Name" from  branch_mst  where branch_mst."Branch_Code"= tbl_booking_mast."branch" ) as "Branch_Name",
  
    tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0')
    GROUP BY  "Branch_Code","Branch_Name","Postprem_code" ,"Postprem_name"
    ,"SESS"  ORDER BY  "Branch_Code","Branch_Name","Postprem_code" ,"Postprem_name";

    --Taluka




elsif(prowname='Taluka' and pcolumnname='Publication')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Talu_code","Talu_name","Pub_Code","Publication",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
 (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" ) as "Talu_code",
   (select taluka_mast.TALU_NAME from taluka_mast where taluka_mast.TALU_CODE in (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" ) )  as "Talu_name",
    tbl_booking_insert."Publication_Code" as "Pub_Code",
    (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY  "Talu_code","Talu_name","Pub_Code","Publication"
    ,"SESS"  ORDER BY  "Talu_code","Talu_name","Pub_Code","Publication";


elsif(prowname='Taluka' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Talu_code","Talu_name","Supplement_CODE","Supplement",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
 (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" ) as "Talu_code",
   (select taluka_mast.TALU_NAME from taluka_mast where taluka_mast.TALU_CODE in (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" ) )  as "Talu_name",
        tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and tbl_booking_insert."Publication_Code"=supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Talu_code","Talu_name","Supplement_CODE","Supplement"
    ,"SESS"  ORDER BY "Talu_code","Talu_name","Supplement_CODE","Supplement";


    elsif(prowname='Taluka' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Talu_code","Talu_name","Ad_catg_code","Adv_Catg_Name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
 (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" ) as "Talu_code",
   (select taluka_mast.TALU_NAME from taluka_mast where taluka_mast.TALU_CODE in (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" ) )  as "Talu_name",
      tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY  "Talu_code","Talu_name","Ad_catg_code","Adv_Catg_Name"
    ,"SESS"  ORDER BY  "Talu_code","Talu_name","Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='Taluka' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Talu_code","Talu_name", "Agency_Type_Code","Agency_type_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" ) as "Talu_code",
   (select taluka_mast.TALU_NAME from taluka_mast where taluka_mast.TALU_CODE in (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" ) )  as "Talu_name",
    (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
        ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Talu_code","Talu_name", "Agency_Type_Code","Agency_type_name"
    ,"SESS"  ORDER BY "Talu_code","Talu_name", "Agency_Type_Code","Agency_type_name";

    elsif(prowname='Taluka' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Talu_code","Talu_name", "Scheme_code","Scheme_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" ) as "Talu_code",
   (select taluka_mast.TALU_NAME from taluka_mast where taluka_mast.TALU_CODE in (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" ) )  as "Talu_name",
   tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
 nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
        ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Talu_code","Talu_name", "Scheme_code","Scheme_name"
    ,"SESS"  ORDER BY "Talu_code","Talu_name", "Scheme_code","Scheme_name";


     elsif(prowname='Taluka' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Talu_code","Talu_name", "Page_premium_code","Page_premium_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" ) as "Talu_code",
   (select taluka_mast.TALU_NAME from taluka_mast where taluka_mast.TALU_CODE in (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" ) )  as "Talu_name",
  tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0')
    GROUP BY  "Talu_code","Talu_name", "Page_premium_code","Page_premium_name"
    ,"SESS"  ORDER BY  "Talu_code","Talu_name", "Page_premium_code","Page_premium_name";

         elsif(prowname='Taluka' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Talu_code","Talu_name", "Postprem_code","Postprem_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" ) as "Talu_code",
   (select taluka_mast.TALU_NAME from taluka_mast where taluka_mast.TALU_CODE in (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" ) )  as "Talu_name",
    tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0')
    GROUP BY "Talu_code","Talu_name", "Postprem_code","Postprem_name"
    ,"SESS"  ORDER BY "Talu_code","Talu_name", "Postprem_code","Postprem_name";

    --City

   

elsif(prowname='City' and pcolumnname='Publication')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "City_code","City_name", "Pub_Code","Publication",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select AGENCY_MAST."City_Code"  from agency_mast  where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "City_code",
   (select city_mst."City_Name" from city_mst where "City_Code" in(select AGENCY_MAST."City_Code"  from agency_mast  where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")) as "City_name",
    tbl_booking_insert."Publication_Code" as "Pub_Code",
    (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code" ) as "Publication",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
        ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "City_code","City_name", "Pub_Code","Publication"
    ,"SESS"  ORDER BY "City_code","City_name", "Pub_Code","Publication";


elsif(prowname='City' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "City_code","City_name", "Supplement_CODE","Supplement",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  (select AGENCY_MAST."City_Code"  from agency_mast  where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "City_code",
   (select city_mst."City_Name" from city_mst where "City_Code" in(select AGENCY_MAST."City_Code"  from agency_mast  where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")) as "City_name",
         tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and tbl_booking_insert."Publication_Code" =supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and

                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "City_code","City_name", "Supplement_CODE","Supplement"
    ,"SESS"  ORDER BY "City_code","City_name", "Supplement_CODE","Supplement";


    elsif(prowname='City' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "City_code","City_name", "Ad_catg_code","Adv_Catg_Name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  (select AGENCY_MAST."City_Code"  from agency_mast  where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "City_code",
   (select city_mst."City_Name" from city_mst where "City_Code" in(select AGENCY_MAST."City_Code"  from agency_mast  where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")) as "City_name",
      tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
        ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "City_code","City_name", "Ad_catg_code","Adv_Catg_Name"
    ,"SESS"  ORDER BY "City_code","City_name", "Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='City' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "City_code","City_name", "Agency_Type_Code","Agency_type_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  (select AGENCY_MAST."City_Code"  from agency_mast  where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "City_code",
   (select city_mst."City_Name" from city_mst where "City_Code" in(select AGENCY_MAST."City_Code"  from agency_mast  where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")) as "City_name",
      (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "City_code","City_name", "Agency_Type_Code","Agency_type_name"
    ,"SESS"  ORDER BY "City_code","City_name", "Agency_Type_Code","Agency_type_name";

    elsif(prowname='City' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "City_code","City_name","Scheme_code","Scheme_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  (select AGENCY_MAST."City_Code"  from agency_mast  where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "City_code",
   (select city_mst."City_Name" from city_mst where "City_Code" in(select AGENCY_MAST."City_Code"  from agency_mast  where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")) as "City_name",
     tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
  nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "City_code","City_name","Scheme_code","Scheme_name"
    ,"SESS"  ORDER BY "City_code","City_name","Scheme_code","Scheme_name";


     elsif(prowname='City' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "City_code","City_name","Page_premium_code","Page_premium_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   (select AGENCY_MAST."City_Code"  from agency_mast  where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "City_code",
   (select city_mst."City_Name" from city_mst where "City_Code" in(select AGENCY_MAST."City_Code"  from agency_mast  where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")) as "City_name",
    tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0')
    GROUP BY "City_code","City_name","Page_premium_code","Page_premium_name"
    ,"SESS"  ORDER BY "City_code","City_name","Page_premium_code","Page_premium_name";

         elsif(prowname='City' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "City_code","City_name","Postprem_code","Postprem_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  (select AGENCY_MAST."City_Code"  from agency_mast  where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") as "City_code",
   (select city_mst."City_Name" from city_mst where "City_Code" in(select AGENCY_MAST."City_Code"  from agency_mast  where TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode")) as "City_name",
      tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0')
    GROUP BY "City_code","City_name","Postprem_code","Postprem_name"
    ,"SESS"  ORDER BY "City_code","City_name","Postprem_code","Postprem_name";

  
    --Executive

  


elsif(prowname='Executive' and pcolumnname='Publication')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Executive_Code","Executive_Name","Pub_Code","Publication",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
    tbl_booking_mast."Executive_code" AS "Executive_Code",
    (select EXEC_MAST."Exec_name" from exec_mast where tbl_booking_mast."Executive_code"=exec_mast."Exe_no") AS "Executive_Name",
   tbl_booking_insert."Publication_Code" as "Pub_Code",
   (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
        ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                 and tbl_booking_mast."Executive_code" is not null and tbl_booking_mast."Executive_code" !='0')
    GROUP BY "Executive_Code","Executive_Name","Pub_Code","Publication"
    ,"SESS"  ORDER BY "Executive_Code","Executive_Name","Pub_Code","Publication";


elsif(prowname='Executive' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Executive_Code","Executive_Name","Supplement_CODE","Supplement",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   tbl_booking_mast."Executive_code" AS "Executive_Code",
    (select EXEC_MAST."Exec_name" from exec_mast where tbl_booking_mast."Executive_code"=exec_mast."Exe_no") AS "Executive_Name",
          tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and tbl_booking_insert."Publication_Code"=supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
        ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and

                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Executive_code" is not null and tbl_booking_mast."Executive_code" !='0')
    GROUP BY   "Executive_Code","Executive_Name","Supplement_CODE","Supplement"
    ,"SESS"  ORDER BY   "Executive_Code","Executive_Name","Supplement_CODE","Supplement";


    elsif(prowname='Executive' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Executive_Code","Executive_Name","Ad_catg_code","Adv_Catg_Name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   tbl_booking_mast."Executive_code" AS "Executive_Code",
    (select EXEC_MAST."Exec_name" from exec_mast where tbl_booking_mast."Executive_code"=exec_mast."Exe_no") AS "Executive_Name",
       tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
        ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Executive_code" is not null and tbl_booking_mast."Executive_code" !='0')
    GROUP BY  "Executive_Code","Executive_Name","Ad_catg_code","Adv_Catg_Name"
    ,"SESS"  ORDER BY  "Executive_Code","Executive_Name","Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='Executive' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Executive_Code","Executive_Name","Agency_Type_Code","Agency_type_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   tbl_booking_mast."Executive_code" AS "Executive_Code",
    (select EXEC_MAST."Exec_name" from exec_mast where tbl_booking_mast."Executive_code"=exec_mast."Exe_no") AS "Executive_Name",
      (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
        ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Executive_code" is not null and tbl_booking_mast."Executive_code" !='0')
    GROUP BY  "Executive_Code","Executive_Name","Agency_Type_Code","Agency_type_name"
    ,"SESS"  ORDER BY  "Executive_Code","Executive_Name","Agency_Type_Code","Agency_type_name";

    elsif(prowname='Executive' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Executive_Code","Executive_Name","Scheme_code","Scheme_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   tbl_booking_mast."Executive_code" AS "Executive_Code",
    (select EXEC_MAST."Exec_name" from exec_mast where tbl_booking_mast."Executive_code"=exec_mast."Exe_no") AS "Executive_Name",
    tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
   nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                 and tbl_booking_mast."Executive_code" is not null and tbl_booking_mast."Executive_code" !='0')
    GROUP BY  "Executive_Code","Executive_Name","Scheme_code","Scheme_name"
    ,"SESS"  ORDER BY  "Executive_Code","Executive_Name","Scheme_code","Scheme_name";


     elsif(prowname='Executive' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Executive_Code","Executive_Name","Page_premium_code","Page_premium_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
   tbl_booking_mast."Executive_code" AS "Executive_Code",
    (select EXEC_MAST."Exec_name" from exec_mast where tbl_booking_mast."Executive_code"=exec_mast."Exe_no") AS "Executive_Name",
      tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0'
                 and tbl_booking_mast."Executive_code" is not null and tbl_booking_mast."Executive_code" !='0')
    GROUP BY "Executive_Code","Executive_Name","Page_premium_code","Page_premium_name"
    ,"SESS"  ORDER BY "Executive_Code","Executive_Name","Page_premium_code","Page_premium_name";

         elsif(prowname='Executive' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Executive_Code","Executive_Name","Postprem_code","Postprem_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  tbl_booking_mast."Executive_code" AS "Executive_Code",
    (select EXEC_MAST."Exec_name" from exec_mast where tbl_booking_mast."Executive_code"=exec_mast."Exe_no") AS "Executive_Name",
        tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0'
                 and tbl_booking_mast."Executive_code" is not null and tbl_booking_mast."Executive_code" !='0')
    GROUP BY "Executive_Code","Executive_Name","Postprem_code","Postprem_name"
    ,"SESS"  ORDER BY "Executive_Code","Executive_Name","Postprem_code","Postprem_name";

        --Retainer

       

elsif(prowname='Retainer' and pcolumnname='Publication')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Retainer_Code", "Retainer_Name","Pub_Code","Publication",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  tbl_booking_mast.RETAINER AS "Retainer_Code",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=tbl_booking_mast.RETAINER ) AS "Retainer_Name",
  tbl_booking_insert."Publication_Code" as "Pub_Code",
  (SELECT pub_mast."Pub_Name"  FROM PUB_MAST WHERE pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code")as "Publication",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                 and (tbl_booking_mast.RETAINER is not null and tbl_booking_mast.RETAINER !='0'))
    GROUP BY "Retainer_Code", "Retainer_Name","Pub_Code","Publication"
    ,"SESS"  ORDER BY "Retainer_Code", "Retainer_Name","Pub_Code","Publication";


elsif(prowname='Retainer' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Retainer_Code", "Retainer_Name","Supplement_CODE", "Supplement",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  tbl_booking_mast.RETAINER AS "Retainer_Code",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=tbl_booking_mast.RETAINER ) AS "Retainer_Name",
        tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and tbl_booking_insert."Publication_Code"=supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
        ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                 and (tbl_booking_mast.RETAINER is not null and tbl_booking_mast.RETAINER !='0'))
    GROUP BY "Retainer_Code", "Retainer_Name","Supplement_CODE", "Supplement"
    ,"SESS"  ORDER BY "Retainer_Code", "Retainer_Name","Supplement_CODE", "Supplement";


    elsif(prowname='Retainer' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Retainer_Code", "Retainer_Name","Ad_catg_code","Adv_Catg_Name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  tbl_booking_mast.RETAINER AS "Retainer_Code",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=tbl_booking_mast.RETAINER ) AS "Retainer_Name",
     tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                 and (tbl_booking_mast.RETAINER is not null and tbl_booking_mast.RETAINER !='0'))
    GROUP BY  "Retainer_Code", "Retainer_Name","Ad_catg_code","Adv_Catg_Name"
    ,"SESS"  ORDER BY  "Retainer_Code", "Retainer_Name","Ad_catg_code","Adv_Catg_Name";

    elsif(prowname='Retainer' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Retainer_Code", "Retainer_Name","Agency_Type_Code" ,"Agency_type_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  tbl_booking_mast.RETAINER AS "Retainer_Code",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=tbl_booking_mast.RETAINER ) AS "Retainer_Name",
    (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
        ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                 and (tbl_booking_mast.RETAINER is not null and tbl_booking_mast.RETAINER !='0'))
    GROUP BY "Retainer_Code", "Retainer_Name","Agency_Type_Code" ,"Agency_type_name"
    ,"SESS"  ORDER BY "Retainer_Code", "Retainer_Name","Agency_Type_Code" ,"Agency_type_name";

    elsif(prowname='Retainer' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Retainer_Code", "Retainer_Name","Scheme_code" ,"Scheme_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
 tbl_booking_mast.RETAINER AS "Retainer_Code",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=tbl_booking_mast.RETAINER ) AS "Retainer_Name",
    tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
 nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
        ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                 and (tbl_booking_mast.RETAINER is not null and tbl_booking_mast.RETAINER !='0'))
    GROUP BY "Retainer_Code", "Retainer_Name","Scheme_code" ,"Scheme_name"
    ,"SESS"  ORDER BY "Retainer_Code", "Retainer_Name","Scheme_code" ,"Scheme_name";


     elsif(prowname='Retainer' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Retainer_Code", "Retainer_Name","Page_premium_code" ,"Page_premium_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  tbl_booking_mast.RETAINER AS "Retainer_Code",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=tbl_booking_mast.RETAINER ) AS "Retainer_Name",
    tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0'
                and (tbl_booking_mast.RETAINER is not null and tbl_booking_mast.RETAINER !='0'))
    GROUP BY "Retainer_Code", "Retainer_Name","Page_premium_code" ,"Page_premium_name"
    ,"SESS"  ORDER BY "Retainer_Code", "Retainer_Name","Page_premium_code" ,"Page_premium_name";

         elsif(prowname='Retainer' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Retainer_Code", "Retainer_Name","Postprem_code" ,"Postprem_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  tbl_booking_mast.RETAINER AS "Retainer_Code",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=tbl_booking_mast.RETAINER ) AS "Retainer_Name",
      tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0'
                 and (tbl_booking_mast.RETAINER is not null and tbl_booking_mast.RETAINER !='0'))
    GROUP BY "Retainer_Code", "Retainer_Name","Postprem_code" ,"Postprem_name"
    ,"SESS"  ORDER BY "Retainer_Code", "Retainer_Name","Postprem_code" ,"Postprem_name";

    --Package



elsif(prowname='Package' and pcolumnname='Publication')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Package_code", "Package","Pub_Code" ,"Publication",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
tbl_booking_mast."Package_code" as "Package_code",
    NVL((select combin_mast."Package_Name" from combin_mast where combin_mast."Combin_Code" in (tbl_booking_mast."Package_code") and tbl_booking_mast."Ad_type_code"=combin_mast."Ad_Type_code" ),tbl_booking_mast."Package_code") as "Package" ,

  tbl_booking_insert."Publication_Code"  as "Pub_Code",
  (SELECT pub_mast."Pub_Name" FROM PUB_MAST WHERE pub_mast."Pub_Code"=tbl_booking_insert."Publication_Code") as "Publication",
nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Package_code", "Package","Pub_Code" ,"Publication"
    ,"SESS"  ORDER BY "Package_code", "Package","Pub_Code" ,"Publication";


elsif(prowname='Package' and pcolumnname='Suppliment')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Package_code", "Package","Supplement_CODE" ,"Supplement",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
tbl_booking_mast."Package_code" as "Package_code",
    NVL((select combin_mast."Package_Name" from combin_mast where combin_mast."Combin_Code" in (tbl_booking_mast."Package_code") and tbl_booking_mast."Ad_type_code"=combin_mast."Ad_Type_code" ),tbl_booking_mast."Package_code") as "Package" ,

        tbl_booking_insert."Supp_Code" as "Supplement_CODE",
    (select supplement_mast."Supp_Name" from supplement_mast where supplement_mast."Supp_Code"=tbl_booking_insert."Supp_Code" and tbl_booking_insert."Publication_Code"=supplement_mast."Pub_Code" and tbl_booking_insert."Edition_Code" =supplement_mast."Edition_Code" ) as "Supplement",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
                tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                tbl_booking_mast."Comp_code"=pcompcode and

                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Package_code", "Package","Supplement_CODE" ,"Supplement"
    ,"SESS"  ORDER BY "Package_code", "Package","Supplement_CODE" ,"Supplement";


    elsif(prowname='Package' and pcolumnname='Ad Category')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Package_code", "Package","Ad_catg_code" ,"Adv_Catg_Name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  tbl_booking_mast."Package_code" as "Package_code",
        NVL((select combin_mast."Package_Name" from combin_mast where combin_mast."Combin_Code" in (tbl_booking_mast."Package_code") and tbl_booking_mast."Ad_type_code"=combin_mast."Ad_Type_code" ),tbl_booking_mast."Package_code") as "Package" ,
      tbl_booking_mast."Ad_cat_code" as "Ad_catg_code",
    (select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=tbl_booking_mast."Ad_cat_code" ) as "Adv_Catg_Name" ,
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Package_code", "Package","Ad_catg_code" ,"Adv_Catg_Name"
    ,"SESS"  ORDER BY "Package_code", "Package","Ad_catg_code" ,"Adv_Catg_Name";

    elsif(prowname='Package' and pcolumnname='Agency Type')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Package_code", "Package","Agency_Type_Code"  ,"Agency_type_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
 tbl_booking_mast."Package_code" as "Package_code",
    NVL((select combin_mast."Package_Name" from combin_mast where combin_mast."Combin_Code" in (tbl_booking_mast."Package_code") and tbl_booking_mast."Ad_type_code"=combin_mast."Ad_Type_code" ),tbl_booking_mast."Package_code") as "Package" ,
   (select agency_type_mst."Agency_Type_Code" from agency_type_mst where agency_type_mst."Agency_Type_Name"=tbl_booking_mast."Agency_type" ) as "Agency_Type_Code" ,
    tbl_booking_mast."Agency_type" as "Agency_type_name",
    nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                 ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Package_code", "Package","Agency_Type_Code"  ,"Agency_type_name"
    ,"SESS"  ORDER BY "Package_code", "Package","Agency_Type_Code"  ,"Agency_type_name";

    elsif(prowname='Package' and pcolumnname='Scheme')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Package_code", "Package","Scheme_code" ,"Scheme_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
tbl_booking_mast."Package_code" as "Package_code",
    NVL((select combin_mast."Package_Name" from combin_mast where combin_mast."Combin_Code" in (tbl_booking_mast."Package_code") and tbl_booking_mast."Ad_type_code"=combin_mast."Ad_Type_code" ),tbl_booking_mast."Package_code") as "Package" ,
     tbl_booking_mast."Scheme_type_code" as "Scheme_code",
    (select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id")  as "Scheme_name",
   nvl(tbl_booking_insert."Bill_Amt",0) as "Billamt",
    nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code")
    GROUP BY "Package_code", "Package","Scheme_code" ,"Scheme_name"
    ,"SESS"  ORDER BY "Package_code", "Package","Scheme_code" ,"Scheme_name";


     elsif(prowname='Package' and pcolumnname='Page Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Package_code", "Package","Page_premium_code" , "Page_premium_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
  tbl_booking_mast."Package_code" as "Package_code",
    NVL((select combin_mast."Package_Name" from combin_mast where combin_mast."Combin_Code" in (tbl_booking_mast."Package_code") and tbl_booking_mast."Ad_type_code"=combin_mast."Ad_Type_code" ),tbl_booking_mast."Package_code") as "Package" ,
    tbl_booking_mast."Page_prem" as "Page_premium_code",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Page_premium_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_prem" is not null and tbl_booking_mast."Page_prem" !='0')
    GROUP BY  "Package_code", "Package","Page_premium_code" , "Page_premium_name"
    ,"SESS"  ORDER BY  "Package_code", "Package","Page_premium_code" , "Page_premium_name";

         elsif(prowname='Package' and pcolumnname='Post. Premium')then

    insert into temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt,SESS_ID)
    select "Package_code", "Package","Postprem_code" ,"Postprem_name",sum("Billamt"),SUM("ActualBusiness"),"SESS" from(
    select 
 tbl_booking_mast."Package_code" as "Package_code",
    NVL((select combin_mast."Package_Name" from combin_mast where combin_mast."Combin_Code" in (tbl_booking_mast."Package_code") and tbl_booking_mast."Ad_type_code"=combin_mast."Ad_Type_code" ),tbl_booking_mast."Package_code") as "Package" ,
     tbl_booking_mast."Page_position_code" as "Postprem_code",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem_name",
    round(nvl(tbl_booking_insert."Bill_Amt",0),2) as "Billamt",
    round(nvl((tbl_booking_insert."Bill_Amt"-nvl(fun_actual(pcompcode,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_insert."Gross_Rate",0),prefer,2 ),0)  ),0),2) as "ActualBusiness"
    ,TBL_BOOKING_MAST."cio_booking_id"
    ,AGENCY_MAST."Agency_Name"
    ,adv_cat_mast."Adv_Cat_Name"
    ,UOM_MAST."Uom_Name",userenv('sessionid') AS "SESS",pub_mast."Pub_Name" ,TBL_BOOKING_INSERT."Edition"   as "Ed_Name"   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
             TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
             tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
             tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code" AND
             adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
             lower("Insert_Status")!='cancel' AND
             tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and
                 tbl_booking_mast."Comp_code"=pcompcode and
                --tbl_booking_insert."Insert_Date" between v_frdt and v_todt  and 
                tbl_booking_insert.BILL_DATE between v_frdt and v_todt  and
                
                ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1) or (chk_access=0) ) and  pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code"
                and tbl_booking_mast."Page_position_code" is not null and tbl_booking_mast."Page_position_code" !='0')
    GROUP BY "Package_code", "Package","Postprem_code" ,"Postprem_name"
    ,"SESS"  ORDER BY "Package_code", "Package","Postprem_code" ,"Postprem_name";


end if;
  open c1;
  loop
      fetch c1 into v1;
      exit when c1%notfound;
    IF v1.col_desc IS NOT NULL THEN
          if v_var is null then
            v_var        :='decode(d.col_desc,'||''''||v1.col_desc||''''||',d.col_bilamt)"'||v1.col_desc||'_BILL_AMT"';
            v_var        :=v_var||','||'decode(d.col_desc,'||''''||v1.col_desc||''''||',d.col_actamt)"'||v1.col_desc||'_ACT_AMT"';
          v_var_sum    :='round(sum("'||v1.col_desc||'_BILL_AMT"),2)'||' "'||v1.col_desc||'_BILL_AMT"';
          v_var_sum    :=v_var_sum||','||'round(sum("'||v1.col_desc||'_ACT_AMT"),2)'||' "'||v1.col_desc||'_ACT_AMT"';
        else
            v_var        :=v_var||','||'decode(d.col_desc,'||''''||v1.col_desc||''''||',d.col_bilamt)"'||v1.col_desc||'_BILL_AMT"';
            v_var        :=v_var||','||'decode(d.col_desc,'||''''||v1.col_desc||''''||',d.col_actamt)"'||v1.col_desc||'_ACT_AMT"';
          v_var_sum    :=v_var_sum||','||'round(sum("'||v1.col_desc||'_BILL_AMT"),2)'||' "'||v1.col_desc||'_BILL_AMT"';
          v_var_sum    :=v_var_sum||','||'round(sum("'||v1.col_desc||'_ACT_AMT"),2)'||' "'||v1.col_desc||'_ACT_AMT"';
        end if;
        ELSE
        if v_var is null then
            v_var     :=NULL;
          v_var_sum   :=NULL;
        else
            v_var        :=v_var|| NULL;
          v_var_sum    :=v_var_sum|| NULL;
        end if;
        
        END IF;
        
  end loop;
  close c1;





  if v_var is not null then
      v_query:='select row_code,row_desc,'||v_var_sum||',sum("BILLAMT") as "TOTAL_BILLAMT",sum("ACTAMT") as "TOTAL_ACTAMT" 
              from (select  distinct d.row_code as row_code,d.row_desc as row_desc,     
      '||v_var||' ,d.col_bilamt as "BILLAMT",d.col_actamt as "ACTAMT" from temp_complete_dynamic_report d where d.sess_id='||userenv('sessionid')||')  group by row_code,row_desc   ORDER BY row_desc';
        ELSE
        v_query:='select ''abc_pk'' from dual';
  end if;
  DELETE FROM SEARCHTBL;
  INSERT INTO SEARCHTBL VALUES(v_query);
  COMMIT;
  
  open p_accounts for v_query;
  
end;
/

======end===========avinash============7233=========================================

======Start===========avinash============7415========29may2012=================================



CREATE OR REPLACE PROCEDURE HT18JULY.Schedulereport1(
    fromdate        IN VARCHAR2,
    dateto          IN VARCHAR2,
    compcode        IN VARCHAR2,
    pub_name        IN VARCHAR2,
    pub_cent        IN VARCHAR2,
    dateformat      IN VARCHAR2,
    descid          IN VARCHAR2:=NULL,
    ascdesc         IN VARCHAR2:=NULL,
    adtyp           IN VARCHAR2,
    adcatg          IN VARCHAR2,
    edition_name    in varchar2,
    drpstatus       in varchar2,
    supplement_name in varchar2,
    packagecode     in varchar2,
    editiondtl      in varchar2,
    puserid         in varchar2:=null,
    chk_access      in varchar2:=null,
    p_branch        in varchar2:=null,
    ro_statusres    in  varchar2,
    p_accounts      OUT Cur_Type_New1.cursor_type,
    p_accounts1     OUT Cur_Type_New1.cursor_type,
    p_accounts2     OUT Cur_Type_New1.cursor_type,
    p_accounts3     out Cur_Type_New1.cursor_type,
    p_accounts4     out Cur_Type_New1.cursor_type) IS
query1 VARCHAR2(10000);
v_gau number:=17;
v_val number(4);
vs_gau number(4);

--if(drpstatus ='cancel') then
Cursor p1 Is
select TBL_BOOKING_INSERT."Edition" as "edition",count(*) as "tot"
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,COL_MAST, UOM_MAST
WHERE TBL_BOOKING_MAST."Comp_code"=compcode AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
TBL_BOOKING_insert."Col_Code" =COL_MAST."Col_Code" AND
UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
AND TBL_BOOKING_INSERT."Insert_Date" BETWEEN fromdate AND dateto

AND (TBL_BOOKING_INSERT."Publication_Code"=pub_name or pub_name is null)
AND (TBL_BOOKING_INSERT."Pub_Cent_Code"=pub_cent or pub_cent is null)
AND (TBL_BOOKING_MAST."Ad_type_code"=Adtyp or Adtyp is null)
AND (tbl_booking_insert."Ad_Cat"=adcatg or adcatg is null)
AND (TBL_BOOKING_INSERT."Edition_Code"=edition_name or edition_name is null)
AND (TBL_BOOKING_insert."Supp_Code" =supplement_name or supplement_name is null)
AND (TBL_BOOKING_mast."branch"  = p_branch  OR	p_branch  is null)
and (packagecode in (tbl_booking_mast."Package_code") or packagecode is null)
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1)
or  (chk_access=0) )
and "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
and ((drpstatus ='includecancel' and  lower("Insert_Status") !='hold') 
   or (drpstatus ='includehold' and lower("Insert_Status") !='cancel')
   or (drpstatus ='cancel' and lower("Insert_Status") !='cancel' and lower("Insert_Status") !='hold') )
-- and (TBL_BOOKING_INSERT."Insert_Status"!=drpstatus or drpstatus is null)

group by TBL_BOOKING_INSERT."Edition" order by TBL_BOOKING_INSERT."Edition";



g1 p1%rowtype;

Cursor C1 Is
SELECT distinct TBL_BOOKING_INSERT."Cio_Booking_Id" AS "CIOID",TBL_BOOKING_MAST."Package_code" as package_code
,TBL_BOOKING_mast."Gross_amount" as Crate
FROM TBL_BOOKING_MAST, TBL_BOOKING_INSERT--,multipack_rep
WHERE TBL_BOOKING_MAST."Comp_code"=compcode AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
AND TBL_BOOKING_INSERT."Insert_Date" BETWEEN fromdate AND dateto
AND (TBL_BOOKING_INSERT."Publication_Code"=pub_name or pub_name is null)
AND (TBL_BOOKING_INSERT."Pub_Cent_Code"=pub_cent or pub_cent is null)
AND (TBL_BOOKING_MAST."Ad_type_code"=Adtyp or Adtyp is null)
AND (tbl_booking_insert."Ad_Cat"=adcatg or adcatg is null)
AND (TBL_BOOKING_INSERT."Edition_Code"=edition_name or edition_name is null)
AND (TBL_BOOKING_insert."Supp_Code" =supplement_name or supplement_name is null)
AND (TBL_BOOKING_mast."branch"  = p_branch  OR	p_branch  is null)
and (packagecode in (tbl_booking_mast."Package_code") or packagecode is null)
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1)
or  (chk_access=0) );
v1 c1%rowtype;

Cursor C2 Is
SELECT distinct "Edition" from TBL_BOOKING_INSERT where "Cio_Booking_Id"=v1.cioid;
v_edition varchar2(100);
v_edipkg varchar2(500);

BEGIN
delete temp_edi;

delete from MULTIPAGE_BREAK where sess_id=userenv('sessionid');commit;


open p1;
loop
fetch p1 into g1;
exit when p1%notfound;
--multipage_brek(packag VARCHAR2,PCOMP_CD number,bre number)
vs_gau:=multipage_brek(g1."edition", g1."tot",v_gau);
     end loop;
close p1;
commit;

--------- fetch multiple  edition  ( ad by rinki)-----------
delete from multipack_rep where sess_id=userenv('sessionid');commit;
open c1;
loop
fetch c1 into v1;
exit when c1%notfound;

    
      v_val:=multipack_report(v1.CIOID,v1.package_code,v1.Crate,'1');
    open C2;
    Loop
    fetch C2 into v_edition;
    exit when C2%notfound;
    if v_edipkg is null then
        v_edipkg :=v_edition;
    else
        v_edipkg :=v_edipkg|| ',' ||v_edition;
    end if;
    end loop;
    close C2;

    v_edition:=null;v_edipkg:=null;
end loop;
close c1;
commit;
---------------------end -------------------------------
if(packagecode is null or editiondtl='1')then
    if(drpstatus ='includecancel' or drpstatus ='includehold') then
    
    query1:='SELECT TBL_BOOKING_MAST ."cio_booking_id" AS "CIOID",
        AGENCY_MAST."Agency_Name" AS "Agency",
        NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code" and tbl_booking_mast."Comp_code"=cust_mast."Comp_Code" ),"Client_code")  AS "Client",
        multipack_rep.PACK  AS "Package",
        COL_MAST ."Col_Alias" AS "Hue",
        TBL_BOOKING_MAST."Card_rate" AS "CardRate",
        NVL("Agrred_rate",TBL_BOOKING_MAST."Card_rate") AS "AgreedRate",
        tbl_booking_insert."Status_Material" as "InsertStatus",
        TBL_BOOKING_MAST."Caption" as "Caption",
        TBL_BOOKING_MAST."Key_no" as "Key_no",
        TBL_BOOKING_INSERT."Edition" as "edition",
        TBL_BOOKING_MAST."RO_No" as "RO_No",
        (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_INSERT."Premium1" and ADVPOS_PREM_MAST."comp_code"=tbl_booking_insert."Comp_Code" ) as "PagePremium",
        (select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=tbl_booking_insert."Page_Post" and advpos_type_mast."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "PosPremium",
        round(TBL_BOOKING_insert."Size_Book",2) AS "Area",
        TBL_BOOKING_MAST."Bill_remarks" AS "Spl Instruction",
        CASE '''||dateformat||'''
        WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''MM-DD-YY'')
        WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''DD-MM-YY'')
        WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''YY-MM-DD'') END AS "Ins.date" ,
        tbl_booking_insert."Width"  AS "Width",
        tbl_booking_insert."Height" AS "Depth"
        ,(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=tbl_booking_insert."Ad_Cat" and ADV_CAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "Adcat",
         (select ADV_SUBCAT_MAST."Adv_Subcat_Name"   FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST."Adv_Subcat_Code"=tbl_booking_insert."Ad_Sub_Cat" and ADV_SUBCAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) AS "AdSubcat",
         (select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3",
        TBL_BOOKING_INSERT."Page_No" as "Pageno",
        TBL_BOOKING_MAST."Paid_ins" as "Paidins",
        TBL_BOOKING_MAST."Rate_code" as ratecd,
        UOM_MAST."Uom_Name"  AS "Uom",
        (select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
        ,TBL_BOOKING_MAST."Booking_type" AS "booktype"
        ,tbl_booking_mast."audit" as "audit"
        ,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT",
        (select distinct "Branch_Name" from branch_mst where "Branch_Code"=TBL_BOOKING_MAST."branch") as "BRANCH_NAME"
        ,AD_GET_CITYNAME(TBL_BOOKING_MAST."Comp_code",AGENCY_MAST."City_Code") CITY_NAME
        FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,multipack_rep,COL_MAST ,UOM_MAST
        WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||'''AND
        TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
        tbl_booking_mast."Comp_code"=tbl_booking_insert."Comp_Code" and
        TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
        TBL_BOOKING_insert."Col_Code"=COL_MAST."Col_Code" AND
         UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
        and  multipack_rep.CIOID=tbl_booking_mast."cio_booking_id"
        and sess_id='||userenv('sessionid')||'
        and "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
        and (('''||drpstatus||''' =''includecancel'' and  lower("Insert_Status") !=''hold'') or ('''||drpstatus||''' =''includehold'' and lower("Insert_Status") !=''cancel''))
        and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
        or  ('''||chk_access||'''=''0'') )';

else

    query1:='SELECT TBL_BOOKING_MAST ."cio_booking_id" AS "CIOID",
    AGENCY_MAST."Agency_Name" AS "Agency",
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code" and tbl_booking_mast."Comp_code"=cust_mast."Comp_Code" ),"Client_code")  AS "Client",
    multipack_rep.PACK  AS "Package",
    COL_MAST ."Col_Alias" AS "Hue",
    TBL_BOOKING_MAST."Card_rate" AS "CardRate",
    NVL("Agrred_rate",TBL_BOOKING_MAST."Card_rate") AS "AgreedRate",
    tbl_booking_insert."Status_Material" as "InsertStatus",
    TBL_BOOKING_MAST."Caption" as "Caption",
    TBL_BOOKING_MAST."Key_no" as "Key_no",
    TBL_BOOKING_INSERT."Edition" as "edition",
    TBL_BOOKING_MAST."RO_No" as "RO_No",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_INSERT."Premium1" and ADVPOS_PREM_MAST."comp_code"=tbl_booking_insert."Comp_Code" ) as "PagePremium",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=tbl_booking_insert."Page_Post" and advpos_type_mast."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "PosPremium",
    round(TBL_BOOKING_insert."Size_Book",2) AS "Area",
    TBL_BOOKING_MAST."Bill_remarks" AS "Spl Instruction",
    CASE '''||dateformat||'''
    WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''MM-DD-YY'')
    WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''DD-MM-YY'')
    WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''YY-MM-DD'') END
     AS "Ins.date" ,
    tbl_booking_insert."Width"  AS "Width",
    tbl_booking_insert."Height" AS "Depth"
    ,(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=tbl_booking_insert."Ad_Cat" and ADV_CAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "Adcat",
     (select ADV_SUBCAT_MAST."Adv_Subcat_Name"   FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST."Adv_Subcat_Code"=tbl_booking_insert."Ad_Sub_Cat" and ADV_SUBCAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) AS "AdSubcat",
     (select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3",
    TBL_BOOKING_INSERT."Page_No" as "Pageno",
    TBL_BOOKING_MAST."Paid_ins" as "Paidins",
    TBL_BOOKING_MAST."Rate_code" as ratecd,
    UOM_MAST."Uom_Name"  AS "Uom",
    (select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
    ,TBL_BOOKING_MAST."Booking_type" AS "booktype"
    ,tbl_booking_mast."audit" as "audit"
    ,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT",
    (select distinct "Branch_Name" from branch_mst where "Branch_Code"=TBL_BOOKING_MAST."branch") as "BRANCH_NAME"
     ,AD_GET_CITYNAME(TBL_BOOKING_MAST."Comp_code",AGENCY_MAST."City_Code") CITY_NAME
    FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,multipack_rep,COL_MAST,UOM_MAST
    WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||'''AND
    TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
    tbl_booking_mast."Comp_code"=tbl_booking_insert."Comp_Code" and
    TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
    TBL_BOOKING_insert."Col_Code"=COL_MAST."Col_Code"
    and  multipack_rep.CIOID=tbl_booking_mast."cio_booking_id"
    and sess_id='||userenv('sessionid')||'
    and lower("Insert_Status") !=''cancel''
    and lower("Insert_Status") !=''hold''
    and  UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
    and "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null) 
    and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
    or  ('''||chk_access||'''=''0'') ) ';

end if;

else
if(drpstatus ='includecancel' or drpstatus ='includehold') then

    query1:='SELECT distinct TBL_BOOKING_MAST ."cio_booking_id" AS "CIOID",
    AGENCY_MAST."Agency_Name" AS "Agency",
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code" and tbl_booking_mast."Comp_code"=cust_mast."Comp_Code" ),"Client_code")  AS "Client",
    multipack_rep.PACK  AS "Package",
    COL_MAST ."Col_Alias" AS "Hue",
    TBL_BOOKING_MAST."Card_rate" AS "CardRate",
    NVL("Agrred_rate",TBL_BOOKING_MAST."Card_rate") AS "AgreedRate",
    tbl_booking_insert."Status_Material" as "InsertStatus",
    TBL_BOOKING_MAST."Caption" as "Caption",
    TBL_BOOKING_MAST."Key_no" as "Key_no",
    TBL_BOOKING_MAST."RO_No" as "RO_No",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_INSERT."Premium1" and ADVPOS_PREM_MAST."comp_code"=tbl_booking_insert."Comp_Code" ) as "PagePremium",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=tbl_booking_insert."Page_Post" and advpos_type_mast."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "PosPremium",
    round(TBL_BOOKING_insert."Size_Book",2) AS "Area",
    TBL_BOOKING_MAST."Bill_remarks" AS "Spl Instruction",
    CASE '''||dateformat||'''
    WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''MM-DD-YY'')
    WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''DD-MM-YY'')
    WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''YY-MM-DD'') END AS "Ins.date" ,
    tbl_booking_insert."Width"  AS "Width",
    tbl_booking_insert."Height" AS "Depth"
    ,(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=tbl_booking_insert."Ad_Cat" and ADV_CAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "Adcat",
     (select ADV_SUBCAT_MAST."Adv_Subcat_Name"   FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST."Adv_Subcat_Code"=tbl_booking_insert."Ad_Sub_Cat" and ADV_SUBCAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) AS "AdSubcat",
     (select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3",
    TBL_BOOKING_INSERT."Page_No" as "Pageno",
    TBL_BOOKING_MAST."Paid_ins" as "Paidins",
    TBL_BOOKING_MAST."Rate_code" as ratecd,
    UOM_MAST."Uom_Name"  AS "Uom",
    (select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
    ,TBL_BOOKING_MAST."Booking_type" AS "booktype"
    ,tbl_booking_mast."audit" as "audit"
    ,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT"
     ,AD_GET_CITYNAME(TBL_BOOKING_MAST."Comp_code",AGENCY_MAST."City_Code") CITY_NAME
    FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,multipack_rep,COL_MAST,UOM_MAST
    WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||'''AND
    TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
    tbl_booking_mast."Comp_code"=tbl_booking_insert."Comp_Code" and
    TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
    TBL_BOOKING_insert."Col_Code"=COL_MAST."Col_Code" AND
     UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
    and  multipack_rep.CIOID=tbl_booking_mast."cio_booking_id"
    and sess_id='||userenv('sessionid')||'
    and "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
    and (('''||drpstatus||''' =''includecancel'' and  lower("Insert_Status") !=''hold'') or ('''||drpstatus||''' =''includehold'' and lower("Insert_Status") !=''cancel''))
    and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
    or  ('''||chk_access||'''=''0'') )';

else

    query1:='SELECT distinct TBL_BOOKING_MAST ."cio_booking_id" AS "CIOID",
    AGENCY_MAST."Agency_Name" AS "Agency",
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code" and tbl_booking_mast."Comp_code"=cust_mast."Comp_Code" ),"Client_code")  AS "Client",
    multipack_rep.PACK  AS "Package",
    COL_MAST ."Col_Alias" AS "Hue",
    TBL_BOOKING_MAST."Card_rate" AS "CardRate",
    NVL("Agrred_rate",TBL_BOOKING_MAST."Card_rate") AS "AgreedRate",
    tbl_booking_insert."Status_Material" as "InsertStatus",
    TBL_BOOKING_MAST."Caption" as "Caption",
    TBL_BOOKING_MAST."Key_no" as "Key_no",
    TBL_BOOKING_MAST."RO_No" as "RO_No",
    (select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_INSERT."Premium1" and ADVPOS_PREM_MAST."comp_code"=tbl_booking_insert."Comp_Code" ) as "PagePremium",
    (select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=tbl_booking_insert."Page_Post" and advpos_type_mast."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "PosPremium",
    round(TBL_BOOKING_insert."Size_Book",2) AS "Area",
    TBL_BOOKING_MAST."Bill_remarks" AS "Spl Instruction",
    CASE '''||dateformat||'''
    WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''MM-DD-YY'')
    WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''DD-MM-YY'')
    WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''YY-MM-DD'') END
     AS "Ins.date" ,
    tbl_booking_insert."Width"  AS "Width",
    tbl_booking_insert."Height" AS "Depth"
    ,(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=tbl_booking_insert."Ad_Cat" and ADV_CAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "Adcat",
     (select ADV_SUBCAT_MAST."Adv_Subcat_Name"   FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST."Adv_Subcat_Code"=tbl_booking_insert."Ad_Sub_Cat" and ADV_SUBCAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) AS "AdSubcat",
     (select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3",
    TBL_BOOKING_INSERT."Page_No" as "Pageno",
    TBL_BOOKING_MAST."Paid_ins" as "Paidins",
    TBL_BOOKING_MAST."Rate_code" as ratecd,
    UOM_MAST."Uom_Name"  AS "Uom",
    (select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
    ,TBL_BOOKING_MAST."Booking_type" AS "booktype"
    ,tbl_booking_mast."audit" as "audit"
    ,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT",
    (select distinct "Branch_Name" from branch_mst where "Branch_Code"=TBL_BOOKING_MAST."branch") as "BRANCH_NAME"
     ,AD_GET_CITYNAME(TBL_BOOKING_MAST."Comp_code",AGENCY_MAST."City_Code") CITY_NAME
    FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,multipack_rep,COL_MAST,UOM_MAST
    WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||'''AND
    TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
    tbl_booking_mast."Comp_code"=tbl_booking_insert."Comp_Code" and
    TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
    TBL_BOOKING_insert."Col_Code"=COL_MAST."Col_Code"
    and  multipack_rep.CIOID=tbl_booking_mast."cio_booking_id"
    and sess_id='||userenv('sessionid')||'
    and lower("Insert_Status") !=''cancel''
    and lower("Insert_Status") !=''hold''
    and  UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
    and "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
    and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
    or  ('''||chk_access||'''=''0'') )';

end if;
end if;


IF(fromdate IS NOT NULL AND dateto IS NOT NULL ) THEN
    query1:=query1||' AND TBL_BOOKING_INSERT."Insert_Date" BETWEEN '''||fromdate||''' AND '''||dateto||''' ';
END IF;


IF(pub_name IS NOT NULL )THEN
    query1:=query1||' AND TBL_BOOKING_INSERT."Publication_Code"='''||pub_name||'''';
END IF;

IF(p_branch IS NOT NULL )THEN
    query1:=query1||' AND TBL_BOOKING_MAST."branch"='''||p_branch||'''';
END IF;

IF(pub_cent IS NOT NULL) THEN
    query1:=query1||'  AND TBL_BOOKING_INSERT."Pub_Cent_Code"='''||pub_cent||'''';
END IF;


IF(adtyp IS NOT NULL) THEN
    query1:=query1|| ' AND TBL_BOOKING_MAST."Ad_type_code"='''||Adtyp||''' ';
END IF;

IF(adcatg IS NOT NULL) THEN
    query1:=query1|| ' AND tbl_booking_insert."Ad_Cat" in ('''||adcatg||''' )';
END IF;

IF(edition_name IS NOT NULL ) THEN
    query1:=query1||'  AND TBL_BOOKING_INSERT."Edition_Code"='''||edition_name||'''';
END IF;

IF(supplement_name IS NOT NULL ) THEN
    query1:=query1||' AND (TBL_BOOKING_insert."Supp_Code" ='''||supplement_name||''' )';
END IF;

IF(ro_statusres IS NOT NULL ) THEN
    query1:=query1||' AND (TBL_BOOKING_MAST."ro_status" ='''||ro_statusres||''' )';
END IF;

IF(packagecode IS NOT NULL ) THEN
    query1:=query1||' AND ('''||packagecode||''' in (tbl_booking_mast."Package_code") )';
END IF;

if(packagecode is null)then

    IF(descid IS NOT  NULL) THEN
        query1:=query1||'  order by "'||descid||'",TBL_BOOKING_INSERT."Edition"';
        query1:=query1||''||ascdesc||'';
    else
        query1:=query1||' order by TBL_BOOKING_INSERT."Edition",TBL_BOOKING_MAST."cio_booking_id"';
    END IF;

else
    IF(descid IS NOT  NULL) THEN
        query1:=query1||'  order by "'||descid||'"';
        query1:=query1||''||ascdesc||'';
    else
        query1:=query1||' order by TBL_BOOKING_MAST."cio_booking_id"';
    END IF;
end if;
delete from searchtbl;insert into searchtbl values(query1); commit;

OPEN p_accounts FOR query1;

OPEN p_accounts1 FOR
select "Edition_Alias"  as "Editions"  from edition_mast where ("Pub_Code"=pub_name or pub_name is null)  and "Edition_Type"='Main Edition';

OPEN p_accounts2 FOR
select sysdate from dual;
/*SELECT 
CASE dateformat
WHEN 'mm/dd/yyyy' THEN TO_CHAR("Insert_Date",'MM-DD-YY')
WHEN 'dd/mm/yyyy' THEN TO_CHAR("Insert_Date",'DD-MM-YY')
WHEN 'yyyy/mm/dd' THEN TO_CHAR("Insert_Date",'YY-MM-DD') END as "Insdate"
,TBL_BOOKING_INSERT."Edition" from TBL_BOOKING_INSERT
where  TBL_BOOKING_INSERT."Edition"
in (select "Edition_Alias"  as "Editions"
from edition_mast where ("Pub_Code"=pub_name or pub_name is null));*/


OPEN p_accounts3 FOR
select PACK, TOT from  MULTIPAGE_BREAK where  sess_id=userenv('sessionid') order by PACK,TOT desc;

OPEN  p_accounts4 FOR
SELECT SYSDATE,initcap("Comp_Name") from comp_mst where "Comp_Code"=compcode;

delete from multipack_rep where sess_id=userenv('sessionid')  ;
delete from multipack_rat where sess_id=userenv('sessionid') ;
DELETE FROM multipack_ratnew where sess_id=userenv('sessionid')  ; 
DELETE FROM MULTIPAGE_BREAK where sess_id=userenv('sessionid')  ;commit;
END ;
/


=====end======avinash=====7415=============================================






//////////////////issue no 6793///////////////////////////////////





CREATE OR REPLACE PACKAGE HT18JULY.AdvTeamDetail
is
Type T_Accounts_Cursor is Ref Cursor;

procedure AdvTeamDetail_p
(
Comp_Code in varchar2,
Team_Code in varchar2,
Team_Name in varchar2,
userid in varchar2,
zone in varchar2,
Flag in varchar2,
attachment in varchar2,
signature in varchar2,

P_Accounts out T_Accounts_Cursor,
P_Accounts1 out T_Accounts_Cursor
);

end  AdvTeamDetail;
/









CREATE OR REPLACE package  body HT18JULY.AdvTeamDetail
is
procedure AdvTeamDetail_p
(
Comp_Code in varchar2,
Team_Code in varchar2,
Team_Name in varchar2,
userid in varchar2,
zone in varchar2,
Flag in varchar2,
attachment in varchar2,
signature in varchar2,

P_Accounts out T_Accounts_Cursor,
P_Accounts1 out T_Accounts_Cursor

) as

countnum number;

--set "Team_Code"=replace("Team_Code",'','''')
begin

if(Flag='0')then
open P_Accounts for
select  "Comp_Code","Team_Code","Team_Name","Userid","Creation_Datetime","ad_cat","branch_code","SIGN",ATTACHMENT  from Adv_Exec_Master
 where "Comp_Code"=Comp_Code /*and "Userid"=userid*/
AND ("Team_Code" LIKE Team_Code||'%' OR Team_code IS NULL)
AND ("Team_Name" LIKE Team_Name||'%' OR Team_Name IS NULL)
AND ("branch_code" LIKE zone||'%' OR zone IS NULL);

end if;

open P_Accounts1 for
select * from Adv_Exec_Master where  "Comp_Code" = Comp_Code; -- and "Userid"=userid;

if(Flag='1')then
insert into Adv_Exec_Master("Comp_Code","Team_Code","Team_Name","Userid","Creation_Datetime","branch_code","SIGN") values(Comp_Code,Team_Code,Team_Name,userid,sysdate,zone,signature);
 commit;
end if;

if(Flag=2)then
update Adv_Exec_Master set "Team_Name"=Team_Name , "branch_code"=zone,
"SIGN"=signature, "ATTACHMENT"=attachment 
where "Team_Code"=Team_Code and "Comp_Code"=Comp_Code;
-- update exec_mast set "Branch_code"=zone where "Team_code"=Team_Code and "comp_code"=Comp_Code;
commit;
open P_Accounts for select sysdate from dual;
open P_Accounts1 for select sysdate from dual;

end if;

if(Flag=3)then
select count(*) into countnum from tbl_booking_mast where "Executive_code" in(select "Exe_no" from exec_mast where "Team_code" = Team_Code);
if countnum=0 then
delete from Adv_Exec_Master where "Comp_Code"=Comp_Code and "Team_Code" = Team_Code and "Team_Name"= Team_Name and "branch_code"=zone;
delete from Exec_mast where "comp_code" = Comp_Code and "Team_code" = Team_Code;
delete from exec_adcat where TEAMCODE=Team_Code;
COMMIT;
open P_Accounts for select sysdate from dual;
open P_Accounts1 for select sysdate from dual;
end if;
end if;


if(Flag=5)then
open P_Accounts for
select * from exec_mast where  "comp_code" = Comp_Code and "Team_code" = Team_Code;
end if;


if(Flag=6)then
open P_Accounts for
select * from adv_exec_master where "Comp_Code" = Comp_Code and "Team_Code" = Team_Code;
end if;

end AdvTeamDetail_p;
end AdvTeamDetail;
/
//////////////////////////end of issue 6793////////////////



======start==avinash================by mimoh=======================================
CREATE OR REPLACE procedure emp_code_bind (
    pcomp_code  in       varchar2,                 
    pname       in       varchar2,
    pextra1     in       varchar2,
    pextra2     in       varchar2,
    pextra3     in       varchar2,
    pextra4     in       varchar2,
    p_accounts  out      cur_type_new1.cursor_type,
    p_accounts1 out      cur_type_new1.cursor_type,
    p_accounts2 out      cur_type_new1.cursor_type,
    p_accounts3 out      cur_type_new1.cursor_type)
is
begin
    open p_accounts for     
    select emp_code as "EMP_CODE",name as "NAME",addr1 as "ADDR1",addr2 as "ADDR2",addr3 as "ADDR3",pin as "PIN",
    father_name as "FATHER_NAME",last_name as "LAST_NAME",
    (select dept from hr_dept_mast where dept_code=hr_emp_mst.deptcode) "DEPT_NAME",email as "EMAIL",
    phone as "PHONE",mobile as "MOBILE",bran_code as "BRAN_CODE",
    (select "Branch_Name" from branch_mst where "Branch_Code"=hr_emp_mst.bran_code) as "BRANCH_NAME"
    from hr_emp_mst where comp_cd=pcomp_code 
    and ( upper(name) like upper(pname)||'%' or pname is null) order by "NAME";
         
    open p_accounts1 for 
    select 'a' as "A" from dual;
         
    open p_accounts2 for 
    select 'a'  as "A" from dual;
    open p_accounts3 for 
    select 'a' as "A" from dual;
     
end emp_code_bind;
/

======end==avinash================by mimoh=======================================

======start==avinash================by mimoh======31-05-2012=================================
CREATE OR REPLACE PROCEDURE exeaddstatusbind (
   execode      IN       VARCHAR2,
   userid       IN       VARCHAR2,
   compcode     IN       VARCHAR2,
   commid       IN       VARCHAR2,
   p_accounts   OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT *
        FROM EXECUTIVE_ADCOMM_TARGET
       WHERE comp_code = compcode
         AND EXECUTIVE_CODE = execode
         AND comm_target_id = commid;
END;
/

/********************************************************************/
CREATE OR REPLACE PROCEDURE ad_execu_add_comm_target_ins (
   pcomp_code        IN   VARCHAR2,
   pexecu_code      IN   VARCHAR2,
   ppubl_code        IN   VARCHAR2,
   pno_of_publ       IN   VARCHAR2,
   padcomm_per       IN   NUMBER,
   pcomm_type        IN   VARCHAR2,
   pcreated_by       IN   VARCHAR2,
   pcreated_dt       IN   DATE,
   pupdated_by       IN   VARCHAR2,
   pupdated_dt       IN   DATE,
   pcomm_target_id   IN   NUMBER,
   padd_comm_id      IN   NUMBER,
   pdml_type         IN   VARCHAR
)
AS
BEGIN
   IF NVL (pdml_type, '?') = 'I'
   THEN
      INSERT INTO executive_adcomm_target
                  (add_comm_id, comp_code,
                   EXECUTIVE_CODE, publ_code, no_of_publ, adcomm_per,
                   comm_type, created_by, created_dt, updated_by,
                   updated_dt, comm_target_id
                  )
           VALUES (retain_adcomm_target_seq.NEXTVAL, pcomp_code,
                   pexecu_code, ppubl_code, pno_of_publ, padcomm_per,
                   pcomm_type, SYSDATE, pcreated_dt, pupdated_by,
                   pupdated_dt, pcomm_target_id
                  );

      COMMIT;
   END IF;

   IF NVL (pdml_type, '?') = 'U'
   THEN
      UPDATE executive_adcomm_target
         SET publ_code = ppubl_code,
             no_of_publ = pno_of_publ,
             adcomm_per = padcomm_per,
             comm_type = pcomm_type,
             updated_by = pupdated_by,
             updated_dt = SYSDATE
       WHERE comp_code = pcomp_code
         AND EXECUTIVE_CODE = pexecu_code
         AND add_comm_id = padd_comm_id;

      COMMIT;
   END IF;

   IF NVL (pdml_type, '?') = 'D'
   THEN
      DELETE FROM executive_adcomm_target
            WHERE comp_code = pcomp_code
              AND EXECUTIVE_CODE = pexecu_code
              AND add_comm_id = padd_comm_id;

      COMMIT;
   END IF;
END;
/

/******************************************************************************/



CREATE OR REPLACE PROCEDURE exeaddselectslab (
   execode      IN       VARCHAR2,
   userid       IN       VARCHAR2,
   compcode     IN       VARCHAR2,
   code11       IN       VARCHAR2,
   p_accounts   OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT publ_code, no_of_publ, adcomm_per, comm_type, comm_target_id,
             add_comm_id
        FROM executive_adcomm_target
       WHERE comp_code = compcode
         AND EXECUTIVE_CODE = execode
         AND add_comm_id = code11;
END;
/



/*****************************************************************************/


 CREATE OR REPLACE PROCEDURE ad_execut_comm_target_bind (
   execode      IN       VARCHAR2,
   userid       IN       VARCHAR2,
   compcode     IN       VARCHAR2,
   p_accounts   OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT *
        FROM executive_comm_target
       WHERE comp_code = compcode AND EXECU_CODE = execode;
END;
/


/******************************************************************************/


CREATE OR REPLACE PROCEDURE exeselectstructslab (
   compcode     IN       VARCHAR2,
   userid       IN       VARCHAR2,
   execode      IN       VARCHAR2,
   code11       IN       NUMBER,
   p_accounts   OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT team_code, adctg_code, from_tgt, to_tgt, cust_type, ad_type,
             pub_type, publ_code, comm_target_id
        FROM executive_comm_target
       WHERE comp_code = compcode
         AND EXECU_CODE = execode
         AND comm_target_id = code11;
END;
/


/************************************************************************************************/




CREATE OR REPLACE PROCEDURE ad_execu_comm_target_ins (
   pcomp_code        IN   VARCHAR2,
   pexe_code      IN   VARCHAR2,
   pteam_code        IN   VARCHAR2,
   padctg_code       IN   VARCHAR2,
   pfrom_tgt         IN   NUMBER,
   pto_tgt           IN   NUMBER,
   pcust_type        IN   VARCHAR2,
   pad_type          IN   VARCHAR2,
   ppub_type         IN   VARCHAR2,
   ppubl_code        IN   VARCHAR2,
   pcreated_by       IN   VARCHAR2,
   pcreated_dt       IN   DATE,
   pupdated_by       IN   VARCHAR2,
   pupdated_dt       IN   DATE,
   pcomm_target_id   IN   NUMBER,
   pdml_type         IN   VARCHAR
)
AS
BEGIN
   IF NVL (pdml_type, '?') = 'I'
   THEN
      INSERT INTO executive_comm_target
                  (comp_code, EXECU_CODE, team_code, adctg_code,
                   from_tgt, to_tgt, cust_type, ad_type, pub_type,
                   publ_code, created_by, created_dt, updated_by,
                   updated_dt, comm_target_id
                  )
           VALUES (pcomp_code, pexe_code, pteam_code, padctg_code,
                   pfrom_tgt, pto_tgt, pcust_type, pad_type, ppub_type,
                   ppubl_code, pcreated_by, pcreated_dt, pupdated_by,
                   pupdated_dt, pcomm_target_id
                  );

      COMMIT;
   END IF;

   IF NVL (pdml_type, '?') = 'U'
   THEN
      UPDATE executive_comm_target
         SET team_code = pteam_code,
             adctg_code = padctg_code,
             from_tgt = pfrom_tgt,
             to_tgt = pto_tgt,
             cust_type = pcust_type,
             ad_type = pad_type,
             pub_type = ppub_type,
             publ_code = ppubl_code,
             created_by = pcreated_by,
             created_dt = pcreated_dt,
             updated_by = pupdated_by,
             updated_dt = pupdated_dt
       WHERE comp_code = pcomp_code
         AND EXECU_CODE = pexe_code
         AND comm_target_id = pcomm_target_id;

      COMMIT;
   END IF;

   IF NVL (pdml_type, '?') = 'D'
   THEN
      DELETE FROM executive_comm_target
            WHERE comp_code = pcomp_code
              AND EXECU_CODE = pexe_code
              AND comm_target_id = pcomm_target_id;

      COMMIT;
   END IF;
END;
/


/**********************************************************/


CREATE OR REPLACE PROCEDURE insertexestatus_slab (
   compcode           IN   VARCHAR2,
   userid             IN   VARCHAR2,
   execode            IN   VARCHAR2,
--enln in NUMBER,
   fromdays           IN   NUMBER,
   todays             IN   NUMBER,
   drpcommon          IN   VARCHAR2,
   p_comm_target_id   IN   VARCHAR2,
   commrate           IN   NUMBER
)
AS
BEGIN
   INSERT INTO EXECUTIVE_COMM_SLAB
               (comp_code, EXE_CODE, enln, from_days, till_days,
                comm_on, comm_rate, created_by, updated_by, updated_date,
                comm_target_id
               )
        VALUES (compcode, execode, retslab.NEXTVAL, fromdays, todays,
                drpcommon, commrate, userid, '', '',
                p_comm_target_id
               );

   COMMIT;
END;
/
/**************************************************************************/




CREATE OR REPLACE PROCEDURE exegencodeforcommstruct (
   p_compcode   IN       VARCHAR2,
   p_userid     IN       VARCHAR2,
   p_accounts   OUT      cur_type_new1.cursor_type
)
AS
   num   NUMBER;
BEGIN
   SELECT NVL (MAX (comm_target_id), 0) + 1
     INTO num
     FROM executive_comm_target;

   OPEN p_accounts FOR
      SELECT NVL (num, 0) AS "IDNO"
        FROM DUAL;
END;
/

/****************************************************************************/
======end==avinash================by mimoh=======================================