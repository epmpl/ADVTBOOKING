/*******************Issue No. 6197*********************/
ALTER TABLE BRANCH_MST ADD BRANCH_NICK VARCHAR(3) NOT NULL

/*******************Issue No. 6197*********************/

/*************contract***********************************/
ALTER TABLE tv_combin_mast
 ADD (CHANNEL  VARCHAR2(50));
/**************contarct***********************************/

/******************mimoh 11jan2011********************/
ALTER TABLE TBL_BOOKING_MAST ADD (CLIENT_TYPE VARCHAR2(5));

ALTER TABLE TBL_BOOKING_MAST_g ADD (CLIENT_TYPE VARCHAR2(5));

ALTER TABLE TEMPBOOKING_MAST ADD (CLIENT_TYPE VARCHAR2(5));
/******************mimoh 11jan2011********************/


/******************ankit*******6228************* 13jan2011*********************************/

CREATE OR REPLACE PROCEDURE Reportnew1(
    agname          IN  VARCHAR2:=NULL,
    clientname      IN  VARCHAR2:=NULL,
    adtype1         IN  VARCHAR2,
    Adcategory      IN  VARCHAR2,
    Adsubcategory   IN  VARCHAR2,
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
    pbranch         in  varchar2:=null,
    pprint_center   in  varchar2:=null,
    pwithout_rono   in  varchar2:=null,--it is for without agency ro no. list Y or N or All
    pdate_flag      in  varchar2:=null,--it is used for booking date B or publish date P
    pextra1         in  varchar2:=null,
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
    v_query:=' SELECT m."cio_booking_id" AS "CIOID",i."Edition" as "edition",
    CASE '''||dateformat||'''WHEN ''mm/dd/yyyy'' THEN TO_CHAR(i."Insert_Date",''mm/dd/yyyy'')
    WHEN ''dd/mm/yyyy'' THEN TO_CHAR(i."Insert_Date",''dd/mm/yyyy'')
    WHEN ''yyyy/mm/dd'' THEN TO_CHAR(i."Insert_Date",''yyyy/mm/dd'')  END AS "Ins.date" ,
    a."Agency_Name" AS "Agency",
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
    (select COMBIN_MAST."Package_Name" from combin_mast where COMBIN_MAST."Combin_Code"  in(m."Package_code"))AS "Package",
    i."Height" AS "Depth",i."Width"   AS "Width",round(i."Size_Book",2) AS "Area",
    (select uom_mast.UOM_DESC from uom_mast where m."Uom_code"=uom_mast."Uom_Code")as "uom",i."Col_Code" AS "Color_code",
    (SELECT ADVPOS_TYPE_MAST."Pos_Type_Alias" FROM ADVPOS_TYPE_MAST WHERE i."Page_Post"=ADVPOS_TYPE_MAST."Pos_Type_Code") AS "Page",
    m."Bullet_code" AS "BulletPremium" ,i."Page_Post" AS "PositionPremium" ,i."Premium1" AS "PagePremium" ,
    m."RO_No" AS "RoNo.",CASE m."ro_status" WHEN ''2'' THEN ''Reservation'' WHEN ''1'' THEN ''Confirm'' END AS "RoStatus",
    (SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=i."Ad_Cat") AS "AdCat",
    m."Card_rate" AS "CardRate",NVL("Agrred_rate",0) AS "AgreedRate",i."Bill_Amt" AS "Amt",m."Caption" AS "Cap",m."Key_no" AS "Key",
    (SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
    sysdate as "Rundate",
    m.CASHDISCOUNT as "Cash_Disc", m."AUDIT_COMMENT" as "COMMENT",m."Dockit_no" as "DOCKIT_NO"
    FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a
    WHERE m."Comp_code"='''||compcode||'''
    AND m."cio_booking_id"=i."Cio_Booking_Id"
    AND m."Agency_code"=a."Agency_Code"
    and m."Agency_sub_code"=a."code_subcode"
    AND m."cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
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

IF(Adsubcategory IS NOT NULL) THEN
    a:=fn_SplitField_new(Adsubcategory,',');
    v_query:=v_query||' and m."Ad_sub_cat_code" in(select "EDITION_NAME" from result_new where sess_id='||userenv('sessionid')||' )';
END IF;

IF(pub_cent IS NOT NULL) THEN
    v_query:=v_query||'  and i."Pub_Cent_Code"='''||pub_cent||'''';
END IF;

If pdate_flag='B' then
    IF(fromdate IS NOT NULL AND dateto IS NULL ) THEN
        v_query:=v_query||' and m."date_time" ='''||fromdate||'''';

    END IF;

    IF(fromdate IS NOT NULL AND dateto IS NOT NULL ) THEN
        v_query:=v_query||' and m."date_time" between  '''||fromdate ||''' and  '''||dateto||''' ';
    END IF;
Else
    IF(fromdate IS NOT NULL AND dateto IS NULL ) THEN
        v_query:=v_query||' and i."Insert_Date" ='''||fromdate||'''';
    END IF;

    IF(fromdate IS NOT NULL AND dateto IS NOT NULL ) THEN
        v_query:=v_query||' and i."Insert_Date" between  '''||fromdate ||''' and  '''||dateto||''' ';
    END IF;
End If;    

IF(edition IS NOT NULL) THEN
    v_query:=v_query||'  and i."Edition_Code"='''||edition||'''';
END IF;

IF(pub_name IS NOT NULL) THEN
    v_query:=v_query||' and  i."Publication_Code"='''||pub_name||'''';
END IF;

IF((agtype IS NOT NULL) AND (agtype <> 'Package') AND (agtype <> 'Solo')) THEN
    v_query:=v_query||' and  m."Agency_type"='''||upper(agtype)||'''';
END IF;


if(pprint_center is not null)then
    v_query:=v_query||' and m."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE m."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||pprint_center||''')) ';
end if;

if(pbranch is not null)then
    v_query:=v_query||' and m."branch" = '''||pbranch||''' ';
end if;

If pwithout_rono='Y' then
    
    v_query:=v_query||' and (m."RO_No" is null or m."RO_No"='''') ';
End if;    

If pwithout_rono='N' then
    
    v_query:=v_query||' and (m."RO_No" is not null or m."RO_No"<>'''') ';
    
End if;

IF(descid IS NOT  NULL) THEN
    v_query:=v_query||'  order by "'||descid||'"';
    v_query:=v_query||''||ascdesc||'';
ELSE
    v_query:=v_query||'  order by i."Insert_Date",m."cio_booking_id"';
END IF;

delete from searchtbl;insert into searchtbl values(v_query);commit;

OPEN p_reportnew FOR v_query;

END Reportnew1;
/

/******************ankit*******6228************* 13jan2011*********************************/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@6421@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER TABLE TBL_BOOKING_INSERT
 ADD (CAPTION  VARCHAR2(500));
 
ALTER TABLE TBL_BOOKING_INSERT_G
 ADD (CAPTION  VARCHAR2(500));

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@6421@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

/*******************Issue No. 6339*********************/

ALTER TABLE CURR_CONV_DET
 ADD (UNIT  INTEGER);


/*******************Issue No. 6339*********************/


/*************mimoh******Issue No. 0006211*********************/

ALTER TABLE contract_mast ADD (ATTACHMENT   VARCHAR2(200));


ALTER TABLE CONTRACT_MAST
ADD (DEAL_FROM VARCHAR2(50 BYTE));

ALTER TABLE CONTRACT_MAST
ADD (DEAL_CENTER VARCHAR2(50 BYTE));

ALTER TABLE CONTRACT_MAST
ADD (TRANSLATION_CHARGES VARCHAR2(50 BYTE));

  
ALTER TABLE CONTRACT_DETAIL
ADD (POSITION_PREM VARCHAR2(50 BYTE));

ALTER TABLE CONTRACT_DETAIL
ADD (CONTRACT_AMOUNT FLOAT);

/**************mimoh*****Issue No. 0006211*********************/


/*******************************mimoh***********************/
eate index tbl_matter_idx on tbl_matter("cioid")

create index tbl_booking_mast_idx on tbl_booking_mast("Comp_code","prev_cioid")
/*******************************mimoh***********************/
/*********************mimoh 0006376**********************************/
ALTER TABLE EXEC_MAST ADD HR_CODE VARCHAR2(6);
ALTER TABLE RETAINERMASTER ADD HR_CODE VARCHAR2(6);
ALTER TABLE LOGIN ADD HR_CODE VARCHAR2(6);
/*********************mimoh 0006376**********************************/



/***********************ajay**********Issue6650*******************/
ALTER TABLE HT18JULY.AD_CHARGE_MAST
 DROP PRIMARY KEY CASCADE;
DROP TABLE HT18JULY.AD_CHARGE_MAST CASCADE CONSTRAINTS;

CREATE TABLE HT18JULY.AD_CHARGE_MAST
(
  COMP_CODE          VARCHAR2(8 BYTE)           NOT NULL,
  AD_TYPE            VARCHAR2(8 BYTE)           NOT NULL,
  CHARGE_CODE        VARCHAR2(8 BYTE)           NOT NULL,
  CHARGE_NAME        VARCHAR2(50 BYTE)          NOT NULL,
  CHARGE_ALIAS       VARCHAR2(50 BYTE)          NOT NULL,
  CHARGES_TYPE       VARCHAR2(10 BYTE)          NOT NULL,
  CHARGE_AMT         NUMBER(6,2)                NOT NULL,
  VALID_FROM_DATE    DATE                       NOT NULL,
  VALID_TILL_DATE    DATE,
  CHARGE_ACTIVE      VARCHAR2(1 BYTE)           DEFAULT 'Y',
  USERID             VARCHAR2(8 BYTE)           NOT NULL,
  CREATION_DATETIME  DATE                       NOT NULL,
  UPDATED_BY         VARCHAR2(8 BYTE),
  UPDATED_DATE       DATE
)
TABLESPACE USERS
PCTUSED    0
PCTFREE    10
INITRANS   1
MAXTRANS   255
STORAGE    (
            INITIAL          64K
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            BUFFER_POOL      DEFAULT
           )
LOGGING 
NOCOMPRESS 
NOCACHE
NOPARALLEL
MONITORING;


CREATE UNIQUE INDEX HT18JULY.AD_CHARGE_MAST_PK ON HT18JULY.AD_CHARGE_MAST
(CHARGE_CODE)
LOGGING
TABLESPACE USERS
PCTFREE    10
INITRANS   2
MAXTRANS   255
STORAGE    (
            INITIAL          64K
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            BUFFER_POOL      DEFAULT
           )
NOPARALLEL;


ALTER TABLE HT18JULY.AD_CHARGE_MAST ADD (
  CONSTRAINT AD_CHARGE_MAST_PK
 PRIMARY KEY
 (CHARGE_CODE)
    USING INDEX 
    TABLESPACE USERS
    PCTFREE    10
    INITRANS   2
    MAXTRANS   255
    STORAGE    (
                INITIAL          64K
                MINEXTENTS       1
                MAXEXTENTS       UNLIMITED
                PCTINCREASE      0
               ));
/**********************************mimoh**6673*******************/
ALTER TABLE MULTIPACK_REP
MODIFY(PACK VARCHAR2(4000 BYTE));
/**********************************************************/