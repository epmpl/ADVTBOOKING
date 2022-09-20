--------------start issue -6918 06-03-2012-------------------------

New form for agency wise RO number allotment entry(Used for QBC)

For Oracle
CREATE TABLE RO_BOOK_ALLOTMENT
(COMP_CODE VARCHAR2(8) NOT NULL,
 TYP VARCHAR2(1) NOT NULL,
 CODE_SUBCODE VARCHAR2(20) NOT NULL,
 ISSUE_DT DATE NOT NULL,
 ISSUE_NO NUMBER(8) NOT NULL,
 RONO_FROM NUMBER(8) NOT NULL,
 RONO_TILL NUMBER(8) NOT NULL,
 STATUS VARCHAR2(1) DEFAULT 'A',
 CREATED_BY VARCHAR2(30),
 CREATED_DT DATE DEFAULT SYSDATE,
 UPDATED_BY VARCHAR2(30),
 UPDATED_DT DATE,
 CONSTRAINT RO_BOOK_ALLOTMENT_PK PRIMARY KEY (COMP_CODE, CODE_SUBCODE,RONO_FROM,RONO_TILL),
 CONSTRAINT RO_BOOK_ALLOTMENT_UK UNIQUE (ISSUE_NO))

------------end issue--6918------------------------------------------------------------
 /******************************6932**************************************/

ALTER TABLE PREFERRENCES
 ADD (BOOK_AUDIT_REQ_AFTER_MOD  VARCHAR2(5 BYTE));

ALTER TABLE PREFERRENCES
 ADD (BILL_DETAIL_ON_VOUCHER  VARCHAR2(1 BYTE)      DEFAULT 'N');

ALTER TABLE PREFERRENCES
 ADD (CANCEL_VOUCHER_IN_LEDGER  VARCHAR2(1 BYTE)    DEFAULT 'N');


/******************************6932**************************************/


/************************************6963***********RATE MASTER UPDATE************************MIMOH *******************************/

ALTER TABLE RATE_MAST
 ADD (CANCELLATION_CHARGES  FLOAT(126));


/************************************6963***********RATE MASTER UPDATE************************MIMOH *******************************/

/************************6968***********BOOKING MASTE********************MIMOH*****/
ALTER TABLE TEMPBOOKING_MAST
ADD (APP_USER  VARCHAR2(50 BYTE));
/************************6968***********BOOKING MASTE********************MIMOH*****/


//-----------------------------start-----------------------------//
ALTER TABLE  PREFERRENCES ADD(TAXI_ENTRY_TYPE VARCHAR2(1))

ALTER TABLE  CIR_TAXI_ROUTE ADD(STATUS VARCHAR2(1))

//---------------------------------------end-------------------------//


//----------------------contract-----------------start-------------------------//

ALTER TABLE CONTRACT_DETAIL
RENAME COLUMN CYOP TO POSITION_PREM;
ALTER TABLE CONTRACT_DETAIL
MODIFY(POSITION_PREM VARCHAR2(50 BYTE));


ALTER TABLE CONTRACT_DETAIL
ADD (CONTRACT_AMOUNT  FLOAT);


//----------------------contract-----------------end-------------------------//


//----------------------contract-----------------start-------------------------//

ALTER TABLE CONTRACT_MAST
 ADD (DEAL_FROM  VARCHAR2(50 BYTE));

ALTER TABLE CONTRACT_MAST
 ADD (DEAL_CENTER  VARCHAR2(50 BYTE));

ALTER TABLE CONTRACT_MAST
 ADD (TRANSLATION_CHARGES  VARCHAR2(50 BYTE));

//----------------------contract-----------------end-------------------------//

/******************************mimoh mahajan 22 march 2012****************************************6982*************************/
ALTER TABLE PREFERRENCES ADD APPROVAL_WITH VARCHAR2(1) DEFAULT 'D'

/******************************mimoh mahajan 22 march 2012****************************************6982*************************/

/************************issue 3691***********************/

ALTER TABLE PREFERRENCES ADD (
TDS_AUTO_CN VARCHAR2(1) DEFAULT 'N',TDS_AUTO_REASON VARCHAR2(10),TDS_DB_CDP VARCHAR2(10),TDS_CR_CDP VARCHAR2(10),
SER_TAX_AUTO_CN VARCHAR2(1) DEFAULT 'N',SER_TAX_AUTO_REASON VARCHAR2(10),SER_TAX_DB_CDP VARCHAR2(10),SER_TAX_CR_CDP VARCHAR2(10),
PKK_AUTO_CN VARCHAR2(1) DEFAULT 'N',PKK_AUTO_REASON VARCHAR2(10),PKK_DB_CDP VARCHAR2(10),PKK_CR_CDP VARCHAR2(10),
BANK_CHG_AUTO_CN VARCHAR2(1) DEFAULT 'N',BANK_CHG_AUTO_REASON VARCHAR2(10),BANK_CHG_DB_CDP VARCHAR2(10) ,BANK_CHG_CR_CDP VARCHAR2(10));

/************************end issue 3691***********************/
/////////////////////////udated by Ghansham sir

ALTER

TABLE EDITION_MAST ADD( SEGMENT_CODE VARCHAR2(10))
////////////////////////////////////////////////////////////////////


/*****mimoh 28 march 2012*********7061*************************************************/
ALTER TABLE PREFERRENCES ADD (
TDS_AUTO_CN VARCHAR2(1) DEFAULT 'N',TDS_AUTO_REASON VARCHAR2(10),TDS_DB_CDP VARCHAR2(10),TDS_CR_CDP VARCHAR2(10),
SER_TAX_AUTO_CN VARCHAR2(1) DEFAULT 'N',SER_TAX_AUTO_REASON VARCHAR2(10),SER_TAX_DB_CDP VARCHAR2(10),SER_TAX_CR_CDP VARCHAR2(10),
PKK_AUTO_CN VARCHAR2(1) DEFAULT 'N',PKK_AUTO_REASON VARCHAR2(10),PKK_DB_CDP VARCHAR2(10),PKK_CR_CDP VARCHAR2(10),
BANK_CHG_AUTO_CN VARCHAR2(1) DEFAULT 'N',BANK_CHG_AUTO_REASON VARCHAR2(10),BANK_CHG_DB_CDP VARCHAR2(10) ,BANK_CHG_CR_CDP VARCHAR2(10));

/*****mimoh 28 march 2012*********7061*************************************************/



------0-0-0-0-0-0-0-0-0-0-0-0------- updated by Nitish ----------0-0-0-0-0-0---------
alter table PREFERRENCES add CIR_BARCODE  VARCHAR2(5)

----------------- END ----------------------

/**************************************************mimoh ***************/
CREATE TABLE AD_DIRECT_CLIENT_AGENCY
(COMP_CODE      VARCHAR2(20),
 AG_MAIN_CODE   VARCHAR2(8),
 AG_SUB_CODE    VARCHAR2(8),
 CREATED_BY     VARCHAR2(20),
 CREATED_DT     DATE    DEFAULT SYSDATE,
 UPDATED_BY     VARCHAR2(20),
 UPDATED_DT     DATE,
 CONSTRAINT AD_DIRECT_CLIENT_PK PRIMARY KEY (AG_MAIN_CODE, AG_SUB_CODE))
/***********************************************************************/

=====start========7031===========avinash====09april=============
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
===============end=======09april2012==================7031=========


/*********************mimoh/*************************************7162********************/
ALTER TABLE CUST_MAST ADD OLD_CLIENT_CODE VARCHAR2(50)


ALTER TABLE CUST_MAST_TEMP ADD OLD_CLIENT_CODE VARCHAR2(50)

/*********************mimoh/*************************************7162********************/


/*********************mimoh/*************************************7180**11 april 2012******************/

   alter table  retainermaster add ( cdp varchar2(8),cds varchar2(8))
/*********************mimoh/*************************************7180**11 april 2012******************/

**************************** issue 7141 **********************************************
CREATE OR REPLACE FUNCTION HT18JULY.FUN_BILL_INSERT ( comp_cod varchar2, cio_id varchar2,bil_no varchar2,prefer varchar2,dateformate varchar2,f_agmain varchar2,f_agsub varchar2,f_agcode varchar2,f_agname varchar2,f_execcode varchar2,f_execname varchar2,f_retcode varchar2,f_retname varchar2,base varchar2) RETURN number IS

FCIOID      varchar2(50);
FBillno     varchar2(25);
FAgency     varchar2(50);
FClient     varchar2(200);
FRoNo       varchar2(40);
FRoDate     date;
FExecutive  varchar2(50);
FRetainer   varchar2(80);
FBookType   varchar2(50);
FColor      varchar2(20);
FAdcat      varchar2(50);
FAdsubcat   varchar2(50);
FAdsubcat3  varchar2(50);
FAdsubcat4  varchar2(50);
FAdsubcat5  varchar2(50);
FPackag     varchar2(1200);
FBillDate   date;
Fnoinsert   number;
FPaidinsert         number;
Fheight             number;
Fwidth              number;
FArea               number;
FPagepremium        varchar2(30);
FPostprem           varchar2(30);
Fscheme             varchar2(50);
FRatecod            varchar2(40);
Fcardrate           float;
Fcardamt            float;
Fcontractrate       number;
FDeviationamt       number;
FDeviationper       number;
FAggrate            number;
Faggamt             number;
FDiscAmt            float;
FDiscper            number;
Fposamt             number;
Fposper             number;
FSpdiscamt          number;
FSpdiscper          number;
FSpacedisc          number;
FSpacediscper       number;
FSpecialcharge      number;
FAgencyAddlTDper    varchar2(8);
FAgencyAddlTDAmt    number;
FGrossamt           number;
FRetTDPer           number;
FRetTDAmt           number;
FAgencyTDPer        number;
FAgencyTDAmt        number;
FBillamt            number;
FRetCommPer         number;
FRetCommAmt         number;
FActualBusiness     number;
FRevcenter          varchar2(50);
FUom                varchar(20);
FUomDesc            varchar2(50);
FCOMP_CODE          varCHAR2(10);
Fpadtype            varchar2(20);
FPRIPUB             varchar2(10);
FPEDITION           varchar2(50);
FBranch_Name        varchar2(50);
FPub_cent_Code      varchar2(50);
Fregion             varchar2(12);
FAgency_Type_Code   varchar2(10);
FPRIADCTG           varchar2(40);
FSECADCTG           varchar2(40);
FAD_SUBCAT3         varchar2(15);
FAD_SUBCAT4         varchar2(15);
FAD_SUBCAT5         varchar2(15);
FPACKAGE_CODE       varchar2(1000);
FAG_MAIN_CODE       varchar2(10);
FAG_SUB_CODE        varchar2(10);
FCLIENTCD           varchar2(200);
FEXECUTIVE_NAME     varchar2(100);
FPRIPROCTG          varchar2(10);
Fbrand_code         varchar2(10);
FVarient_Name       varchar2(25);
FPAGE_PREM          varchar2(10);
FPAGE_POST          varchar2(10);
FCONTRACT_NAME      varchar2(50);
FSUPP_CODE          varchar2(50);
FRETAINER_CODE      varchar2(10);
FRATECD             varchar2(40);
FCity_Code          varchar2(10);
Fzone_code          varchar2(10);
FDist_Code          varchar2(10);
FState_Code         varchar2(10);
FPTALUKA            varchar2(10);
FPSCHEME            varchar2(18);
FREVENUE_CENTER     varchar2(10);
FRO_STATUS          varchar2(10);
FPAGE_TYPE          varchar2(100);
FBOOKING_TYPE       varchar2(10);
FPUB_CENT_PERMIT    VARCHAR2(50);

FfAdcat             varchar2(50);
FfAdsubcat          varchar2(50);
FfAdsubcat3         varchar2(50);
FfAdsubcat4         varchar2(50);
FfAdsubcat5         varchar2(50);
FfPagepremium       varchar2(50);
Ffscheme            varchar2(50);
f_bil_amt           number;
FfAgencyAddlTDAmt   number;
FfUom               varchar2(50);
FfBranch_Name       varchar2(50);
FfClient            varchar2(100);
FfColor             varchar2(20);
FfPub_cent_Code     varchar2(30);
FffPub_cent_Code    varchar2(30);
FffBranch_Name      varchar2(50);
ffPRIPROCTG         varchar2(30);

Fag_dist_code       varchar2(50);
Fag_talu_code       varchar2(50);
Fdist_name          varchar2(50);
Ftalu_name          varchar2(50);
FPub_cent_Name      varchar2(50);

Fag_city_code       varchar2(50);
Fag_zone_code       varchar2(50);
Fag_state_code      varchar2(50);
Fcity_name          varchar2(30);
Fzone_name          varchar2(30);
Fstate_name         varchar2(30);
f_exec_city         varchar2(8);
f_city_zone         varchar2(8);
f_page_no           varchar(8);
f_billremark        varchar2(500);

begin

/****************************  For Ad_bills  *******************************/

SELECT max(ad_bills.IDNUM),max(AD_BILLS.BILNO),max(ad_bills.RONUM),MAX(ad_bills.RODATE),
max(decode(AD_BILLS.BOOKING_TYPE ,'1','Barter','2','FMG','3','Normal','4','InHouse','5','Complimentary','Normal')),
max(FETCH_PACK(ad_bills.idnum)), --PACKAGE
MAX(ad_bills.BILDT),max(ad_bills.CONTRACT_RATE),
max(FETCH_RATAMT(ad_bills.idnum,'1','2')),   --posamt
max(FETCH_RATAMT(ad_bills.idnum,'2','2')) ,  --POSPER
max(ad_bills.GROSS_AMT),max(ad_bills.BILLAMT) ,max(nvl(ad_bills.DISCOUNT ,0 )),
max((nvl(ad_bills.GROSS_AMT,0)* nvl(ad_bills.DISCOUNT,0 )/100 ))   ,MAX(COMP_CODE_V)
,max(ad_bills.CLIENTCD),max("COLOUR"),
max(SCHEME),sum(nvl(ad_bills.GROSS_AMT,0)),sum(BILLAMT),max(UNIT),
max(ad_bills.UNIT),max(ad_bills."PRIPUB") ,max(ad_bills.AG_MAIN_CODE),MAX(AD_BILLS.AG_SUB_CODE),max(ad_bills."CLIENTCD"),max( ad_bills."EXECUTIVE_NAME"),max(ad_bills."PRIPROCTG"),
max(ad_bills.CONTRACT_NAME),max(ad_bills.RETAINER_CODE),max(ad_bills.SCHEME),max(AD_BILLS.REVENUE_CENTER),max(AD_BILLS.RO_STATUS),
max(AD_BILLS.PAGE_TYPE),max(AD_BILLS.BOOKING_TYPE ),max("PRIPROCTG"),max(PAGENUM),
max(ad_bills.BILL_RMRK)
INTO FCIOID,FBillno,FRoNo,FRoDate,FBookType,FPackag,FBillDate,Fcontractrate,Fposamt,Fposper ,FGrossamt,FBillamt,FAgencyTDPer,FAgencyTDAmt,FCOMP_CODE
,FfClient,FfColor,
FfPagepremium,FAgencyAddlTDAmt,f_bil_amt,FfPub_cent_Code,
FfBranch_Name,FPRIPUB ,FAG_MAIN_CODE,FAG_SUB_CODE,FCLIENTCD,FEXECUTIVE_NAME,FPRIPROCTG,FCONTRACT_NAME,FRETAINER_CODE,FPSCHEME,FREVENUE_CENTER,FRO_STATUS,FPAGE_TYPE,FBOOKING_TYPE
,ffPRIPROCTG,f_page_no,f_billremark  FROM AD_BILLS WHERE ad_bills.COMP_CODE_V=comp_cod AND ad_bills.BILNO=bil_no and ad_bills.IDNUM=cio_id ;

/**************************************  For Ad_bills_det  ***********************************/
select max(PRIADCTG),max(SECADCTG),max(AD_SUBCAT3),max(AD_SUBCAT4),max(AD_SUBCAT5) ,max(PAGE_PREM)
,max(ad_bills_det.HEIGHT),max(ad_bills_det.WIDTH),max(ad_bills_det."SIZE_BOOK"),max(ad_bills_det.RATECD)
,sum(ad_bills_det.CARD_RATE_V),max(ad_bills_det."EDITION"),max(ad_bills_det."AD_TYPE_V"),max(ad_bills_det.PRIADCTG) ,max(ad_bills_det.SECADCTG),max(ad_bills_det."AD_SUBCAT3"),
max(ad_bills_det.AD_SUBCAT4),max(ad_bills_det.AD_SUBCAT5),max(ad_bills_det.PACKAGE_CODE),max(ad_bills_det.PAGE_PREM),max(ad_bills_det.PAGE_POST),
max(ad_bills_det.SUPP_CODE),max(ad_bills_det.RATECD),MAX(ad_bills_det."BKFOR")
into FfAdcat,FfAdsubcat,FfAdsubcat3,FfAdsubcat4,FfAdsubcat5,FfPagepremium
,Fheight,Fwidth,FArea,FRatecod,Fcardrate,FPEDITION,Fpadtype,FPRIADCTG,FSECADCTG,FAD_SUBCAT3,FAD_SUBCAT4,FAD_SUBCAT5,FPACKAGE_CODE,FPAGE_PREM,FPAGE_POST,FSUPP_CODE ,FRATECD
,FPUB_CENT_PERMIT from ad_bills_det where ad_bills_det.COMP_CODE_V=comp_cod AND ad_bills_det.bilno=bil_no;
/**************************  For Tbl_booking_mast  *********************************************/
--select max(nvl(fun_actual(comp_cod,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_mast."Gross_amount",0),prefer,1 ),0)),-- "RetComm(%)"
select max(
nvl(case(prefer)
    when 'Y' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",0) AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",0)) AND ROWNUM<=1)


          when 'Gross' then
                 (
                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,0))-to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 )))
                end )

         when 'Net'   then  to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,'0'))


         --when 'Gross' then ((select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )-nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0' ))
         --when 'Net'   then  (select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )
        END )

    ELSE (select 0  from dual)
end  ,'0')),
--max(nvl(fun_actual(comp_cod,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_mast."Gross_amount",0),prefer,2 ),0)),--"RetCommAmt"
max(nvl(
case( prefer )
    when 'Y' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1)

        when 'Gross' then


         (

                 --CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,0))
                    -- WHEN 0 THEN 0
                    -- ELSE (to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,'0'))-(nvl((nvl(FGrossamt,'0')*to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0'))/100),'0')))

                -- end

                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (nvl(FGrossamt,0)*(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,'0'))-to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0')) )/100)
                 end
                )

         when 'Net'   then  (nvl(FGrossamt,0)*(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,'0')) )/100)




         --when 'Gross' then (nvl(tbl_booking_mast."Gross_amount",'0')*((select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )-nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0' ))/100)
         --when 'Net'   then  (nvl(tbl_booking_mast."Gross_amount",'0')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )/100)
        END )

    ELSE (select 0  from dual)
end
,'0')),

--max(nvl(fun_actual(comp_cod,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_mast."Gross_amount",0),prefer,3 ),0)),--"RetTD(%)"
max((select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )),

--max(nvl(fun_actual(comp_cod,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_mast."Gross_amount",0),prefer,4 ),0)),--"RetTDAmt"
max(nvl(FGrossamt,'0')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )/100),

--max(nvl((f_bil_amt-nvl(fun_actual(comp_cod,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_mast."Gross_amount",0),prefer,2 ),0)  ),0))--"ActualBusiness"
max(nvl((f_bil_amt-nvl(
case( prefer )
    when 'Y' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1)
         when 'Gross' then
                 (
                -- CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,0))
                -- WHEN 0 THEN 0
                -- ELSE (to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,'0'))-(nvl((nvl(FGrossamt,'0')*to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0'))/100),'0')))
                -- end

                CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (nvl(FGrossamt,0)*(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,'0'))-to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0')) )/100)
                 end



                 )

         when 'Net'   then  (nvl(FGrossamt,'0')*(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,'0')) )/100)
         else  (nvl(FGrossamt,'0')*(to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0')) )/100)
         --when 'Gross' then (nvl(tbl_booking_mast."Gross_amount",'0')*((select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )-nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0' ))/100)
         --when 'Net'   then  (nvl(tbl_booking_mast."Gross_amount",'0')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )/100)
        END )

    ELSE (select 0  from dual)
end
,'0')  ),0))--"ActualBusiness"

,max(tbl_booking_mast."No_of_insertion"),max(tbl_booking_mast."Paid_ins"),
max(tbl_booking_mast."Deviation"),max(tbl_booking_mast."Deviation") ,max(tbl_booking_mast."Agrred_rate"),max(tbl_booking_mast."Agreed_amount"),
max(tbl_booking_mast."Discount_per") ,max(tbl_booking_mast."Special_disc_per"),max(tbl_booking_mast."Space_disc_per"),
max(tbl_booking_mast."Special_charges"),max(nvl(tbl_booking_mast."ADD_AGENCY_COMM",0)),
max(nvl((FAgencyAddlTDAmt*nvl(tbl_booking_mast."ADD_AGENCY_COMM",0)/100),0))
,max("Uom_code") into FRetCommPer,FRetCommAmt,FRetTDPer,FRetTDAmt,FActualBusiness
,Fnoinsert,FPaidinsert,FDeviationamt,FDeviationper,FAggrate,Faggamt,FDiscper,FSpdiscper,FSpacediscper,FSpecialcharge,FAgencyAddlTDper,FAgencyAddlTDAmt
,FfUom  from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=FCIOID;
--***************************  variables  ***********************************************************
Fagency:=f_agname;
FClient:=AD_GET_CLIENTNAME (comp_cod,FfClient);
FExecutive:=f_execname;
FRetainer:=f_retname;
FAdcat:=AD_GET_catnameE(comp_cod,FfAdcat,'cat');
FAdsubcat:=AD_GET_catnameE(comp_cod,FfAdsubcat,'subcat');
FAdsubcat3:=AD_GET_catnameE(comp_cod,FfAdsubcat3,'cat3');
FAdsubcat4:=AD_GET_catnameE(comp_cod,FfAdsubcat4,'cat4');
FAdsubcat5:=AD_GET_catnameE(comp_cod,FfAdsubcat5,'cat5');
FPagepremium:=AD_GET_catnameE(comp_cod,FfPagepremium,'pprem');
Fscheme:=AD_GET_catnameE(comp_cod,Ffscheme,'fschem');
FColor:=AD_GET_catnameE(comp_cod,FfColor,'fcol');
FSpdiscamt:= (round((( nvl(FSpdiscper,0) * nvl(FArea,0) * nvl(Fcardrate,0))/100),2)) ;
FSpacedisc:= (round(((nvl(FSpacediscper,0) * nvl(FArea,0) * nvl(Fcardrate,0))/100),2))  ;
Fcardamt:=(nvl(Fcardrate,0) * nvl(FArea,0) * nvl(Fnoinsert,0))     ;
select max((nvl(Fcardrate,0) * nvl(FArea,0) * nvl(Fnoinsert,0)) - DECODE(NVL(Faggamt,0) ,0,(nvl(Fcardrate,0) * nvl(FArea,0) * nvl(Fnoinsert,0)),NVL(Faggamt,0) )) into FDiscAmt from dual  ;
select max(UOM_MAST."Uom_Name"),max(uom_mast.UOM_DESC)  into FUom,FUomDesc   from uom_mast where "Uom_Code" =FfUom;

BEGIN
select "pub_center" into FffPub_cent_Code from BRANCH_MST where "Branch_Code"=FfPub_cent_Code;
EXCEPTION WHEN no_data_found then
FffPub_cent_Code:=null;
end;

select max("Pub_cent_Code"),MAX("Pub_Cent_name") into FPub_cent_Code,FPub_cent_Name from PUB_CENT_MAST where "Pub_cent_Code"=FffPub_cent_Code;
select max(branch_mst."Branch_Name") into FBranch_Name from branch_mst where branch_mst."Branch_Code"= FfBranch_Name;
select max(agency_mast."region"),max(agency_mast."Agency_Type_Code") into Fregion,FAgency_Type_Code from agency_mast where AGENCY_MAST."code_subcode"=f_agcode;
select max(brand_mst."brand_code") into Fbrand_code from brand_mst where brand_mst."prod_cat_code"=ffPRIPROCTG;
select max(varient_mst."Varient_Name") into FVarient_Name from varient_mst where varient_mst."Brand_Code"=Fbrand_code;
--**********************************************************************************************************************

select max(exec_mast."city_code") into f_exec_city from exec_mast where "Exe_no"=f_execcode;
select max(city_mst."Zone_Code") into f_city_zone from city_mst where city_mst."City_Code"=f_exec_city;

if(base='1') then
     select max(Agency_mast."Dist_Code"),max(AGENCY_MAST.TALUKA) ,max(AGENCY_MAST."City_Code"),max(AGENCY_MAST."zone_code"),max(AGENCY_MAST."State_Code")
     into Fag_dist_code,Fag_talu_code,Fag_city_code,Fag_zone_code,Fag_state_code
     from agency_mast where "code_subcode"=f_agcode ;

 elsif(base='2') then
      select max(exec_mast."dist_code"),max(exec_mast.TALUKA) ,max(exec_mast."city_code"),f_city_zone,max(exec_mast."State_code")
      into Fag_dist_code,Fag_talu_code,Fag_city_code,Fag_zone_code,Fag_state_code
      from exec_mast where "Exe_no"=f_execcode ;

 else
       select max(RETAINERMASTER."Dist_Code"),max(RETAINERMASTER.TALUKA) ,max(RETAINERMASTER."City_Code"),max(RETAINERMASTER."Zone_Code"),max(RETAINERMASTER."State_Code")
       into Fag_dist_code,Fag_talu_code,Fag_city_code,Fag_zone_code,Fag_state_code
       from RETAINERMASTER where "Retain_Code" =f_retcode;

  end if;

select max(dist_mst."Dist_Name") into Fdist_name from dist_mst where "Dist_Name"=Fag_dist_code;

select max(taluka_mast.TALU_NAME) into Ftalu_name from taluka_mast where TALU_CODE=Fag_talu_code;

select max(city_mst."City_Name") into Fcity_name  from city_mst where "City_Code"=Fag_city_code;

select max(zone_mast."Zone_Name") into Fzone_name from zone_mast where  "Zone_Code"=Fag_zone_code;

select max(state_mst."State_Name") into Fstate_name from state_mst where  "State_Code"=Fag_state_code;

insert into temp_ad_bills_report
(
CIOID,Billno,Agency,Client,RoNo,RoDate,Executive,Retainer,BookType,Color,Adcat,Adsubcat,Adsubcat3,Adsubcat4,Adsubcat5,Packag,BillDate,
noinsert,Paidinsert,height,width,Area,Pagepremium,Postprem,scheme,Ratecod,cardrate,cardamt,contractrate,Deviationamt,Deviationper,
Aggrate,aggamt,DiscAmt,Discper,posamt,posper,Spdiscamt,Spdiscper,Spacedisc,Spacediscper,Specialcharge,AgencyAddlTDper,AgencyAddlTDAmt,
Grossamt,RetTDPer,RetTDAmt,AgencyTDPer,AgencyTDAmt,Billamt,RetCommPer,RetCommAmt,ActualBusiness,Revcenter,Uom,UomDesc,
    PADTYPE ,  PRIPUB,  PEDITION,  BRANCH_NAME ,  PUB_CENT_CODE ,  REGION,  AGENCY_TYPE_CODE,  PRIADCTG,  SECADCTG,  AD_SUBCAT3,  AD_SUBCAT4,
  AD_SUBCAT5,  PACKAGE_CODE,  AG_MAIN_CODE,   CLIENTCD,  EXECUTIVE_NAME,  PRIPROCTG ,  BRAND_CODE,  VARIENT_NAME,  PAGE_PREM ,  PAGE_POST ,
  CONTRACT_NAME ,  SUPP_CODE ,  RETAINER_CODE ,  RATECD,    PSCHEME ,  REVENUE_CENTER,  RO_STATUS ,  PAGE_TYPE ,  BOOKING_TYPE,COMP_CODE,AG_SUB_CODE,
  PUB_CENT_PERMIT,sess_id,DIST_NAME,TALU_NAME,PUB_CENT_NAME,
  CITY_CODE,ZONE_CODE,DIST_CODE,STATE_CODE,PTALUKA,CITY_NAME,ZONE_NAME,STATE_NAME,PAGE_NO,BILL_REMARK
)
values
(
FCIOID  ,FBillno  ,FAgency  ,FClient  ,FRoNo  ,FRoDate  ,FExecutive  ,FRetainer  ,FBookType  ,FColor  ,FAdcat  ,FAdsubcat  ,FAdsubcat3  ,FAdsubcat4  ,
FAdsubcat5  ,FPackag  ,FBillDate  ,Fnoinsert  ,FPaidinsert  ,Fheight  ,Fwidth  ,FArea  ,FPagepremium  ,FPostprem  ,Fscheme  ,FRatecod  ,Fcardrate  ,
Fcardamt  ,Fcontractrate  ,FDeviationamt  ,FDeviationper  ,FAggrate  ,Faggamt  ,FDiscAmt  ,FDiscper  ,Fposamt  ,Fposper  ,FSpdiscamt  ,FSpdiscper  ,
FSpacedisc  ,FSpacediscper  ,FSpecialcharge  ,FAgencyAddlTDper  ,FAgencyAddlTDAmt  ,FGrossamt  ,FRetTDPer   ,FRetTDAmt  ,FAgencyTDPer  ,
FAgencyTDAmt  ,FBillamt  ,FRetCommPer  ,FRetCommAmt   ,FActualBusiness  ,FRevcenter   ,FUom ,FUomDesc,
Fpadtype,FPRIPUB,FPEDITION,FBranch_Name,FPub_cent_Code,Fregion,FAgency_Type_Code,FPRIADCTG,FSECADCTG,FAD_SUBCAT3,FAD_SUBCAT4,
FAD_SUBCAT5,FPACKAGE_CODE,FAG_MAIN_CODE,FCLIENTCD,FEXECUTIVE_NAME,FPRIPROCTG,Fbrand_code,FVarient_Name,FPAGE_PREM,FPAGE_POST,
FCONTRACT_NAME,FSUPP_CODE,FRETAINER_CODE,FRATECD,FPSCHEME,FREVENUE_CENTER,FRO_STATUS,FPAGE_TYPE,FBOOKING_TYPE,FCOMP_CODE,FAG_SUB_CODE,
FPUB_CENT_PERMIT,userenv('sessionid'),Fdist_name,Ftalu_name,FPub_cent_Name,
Fag_city_code,Fag_zone_code,Fag_dist_code,Fag_state_code,Fag_talu_code,Fcity_name,Fzone_name, Fstate_name,f_page_no,f_billremark
);
commit;


return 0;

--exception when others then
--insert into amit_amit(COMPCODE,subcode,name) values(comp_cod,cio_id,bil_no);  commit;
END;
/

****************************** end of issue 7141*************************************

===start======avinash====by mimoh=====25jun2012==============================================

CREATE OR REPLACE PROCEDURE binndratecode (
   p_compcode    IN       VARCHAR2,
   p_ratecode   IN       VARCHAR2,
   p_accounts    OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT distinct "Rate_Mast_Code"
        FROM rate_mast
       WHERE "Comp_code" = p_compcode
         AND "Rate_Mast_Code" LIKE p_ratecode || '%';
        
END;
/

===End======avinash====by mimoh=====25jun2012==============================================
