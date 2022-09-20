========start=======avinash=10/08/2012======================================
alter  function ad_get_bktype
(
@pcompcode  as varchar(10),
@pbktype_code  as numeric
)
RETURNS varchar(200) as
begin
declare @v_name as varchar(50);

    
    select @v_name= bktype_desc  from ad_bktype_mast where bktype_code=@pbktype_code
    
    
 return isnull(@v_name,'N/A');

end 


*****************************************************************

CREATE TABLE [dbo].[AD_BKTYPE_MAST](
	[BKTYPE_CODE] [numeric](5, 0) NOT NULL,
	[BKTYPE_DESC] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BKSTATUS] [varchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL DEFAULT ('A'),
	[BILL_PAID] [varchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL DEFAULT ('N'),
 CONSTRAINT [PK_AD_BKTYPE_MAST] PRIMARY KEY CLUSTERED 
(
	[BKTYPE_CODE] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
)

*********************************************
ALTER  procedure [dbo].[ad_bktype_bind] 
   @pcompcode        as  varchar(10),
   @pextra1          as  varchar(10),
   @pextra2          as  varchar(10)
   
as

   
   select bktype_code, bktype_desc, bkstatus, bill_paid from ad_bktype_mast order by bktype_code
      


Insert into AD_BKTYPE_MAST
   (BKTYPE_CODE, BKTYPE_DESC, BKSTATUS, BILL_PAID)
 Values
   (1, 'Barter', 'A', 'Y');
Insert into AD_BKTYPE_MAST
   (BKTYPE_CODE, BKTYPE_DESC, BKSTATUS, BILL_PAID)
 Values
   (2, 'FMG', 'A', 'N');
Insert into AD_BKTYPE_MAST
   (BKTYPE_CODE, BKTYPE_DESC, BKSTATUS, BILL_PAID)
 Values
   (3, 'Normal', 'A', 'Y');
Insert into AD_BKTYPE_MAST
   (BKTYPE_CODE, BKTYPE_DESC, BKSTATUS, BILL_PAID)
 Values
   (4, 'Inhouse', 'A', 'N');
Insert into AD_BKTYPE_MAST
   (BKTYPE_CODE, BKTYPE_DESC, BKSTATUS, BILL_PAID)
 Values
   (5, 'Complimentary', 'A', 'N');
Insert into AD_BKTYPE_MAST
   (BKTYPE_CODE, BKTYPE_DESC, BKSTATUS, BILL_PAID)
 Values
   (6, 'Corrigendum', 'A', 'N');



========end=======avinash=10/08/2012======================================

========start=======avinash=14/08/2012======================================
CREATE OR REPLACE PROCEDURE daily_booking_report(
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
    pextra1         in  varchar2:=null,--for UOM
    pextra2         in  varchar2:=null,--for created by 
    pextra3         in  varchar2:=null,--for state
    pextra4         in  varchar2:=null,--for district
    pextra5         in  varchar2:=null,--for city
    p_Accounts     OUT Cur_Type_New1.cursor_type)
IS

center      VARCHAR(50);
from_date   DATE;
date_to     DATE;
v_query     VARCHAR(8000);
a           number;
BEGIN
    v_query:=' select distinct x.cioid AS "CIOID",x.bkdate as bkdate,
    x.agency_sub_code agency_sub_code,x.agency_name agency_name,x.ag_city as ag_city,
    x.ro_no ro_no,x.ro_date ro_date,
    x."Client" AS "Client",
    x."Package" AS "Package",
    x."uom" as "uom",x."Color_code" AS "Color_code",
    x."BulletPremium" AS "BulletPremium" ,
    x."RoStatus" AS "RoStatus",
    x."AdCat" AS "AdCat",
    x."CardRate" AS "CardRate",x."AgreedRate" AS "AgreedRate",x."Amt" AS "Amt",x."Cap" AS "Cap",
    x."Key" AS "Key",x."companyname" AS "companyname",
    x."Rundate" as "Rundate",x."Cash_Disc" as "Cash_Disc", x."COMMENT" as "COMMENT",x.dockit_no as "DOCKIT_NO",
    min(bi."Insert_Date") fisrt_pubdt,max(bi."Insert_Date") last_pubdt ,max(bi."No_Insert") no_of_insdertion
    from
    (select distinct m."cio_booking_id" AS "CIOID",m."date_time" as bkdate,
    m."Agency_sub_code" agency_sub_code,a."Agency_Name"  agency_name,(select "City_Name" from city_mst where "City_Code"=a."City_Code") as ag_city,
    m."RO_No" ro_no,m."RO_Date" ro_date,
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
    case when instr(m."Package_code",'','') >0 then 
        FETCH_PACK_new('''||compcode||''', m."Package_code" ) 
    else
        (select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=m."Package_code")
    end AS "Package",
    (select uom_mast.UOM_DESC from uom_mast where m."Uom_code"=uom_mast."Uom_Code")as "uom",i."Col_Code" AS "Color_code",
    m."Bullet_code" AS "BulletPremium" ,
    CASE m."ro_status" WHEN ''2'' THEN ''Reservation'' WHEN ''1'' THEN ''Confirm'' END AS "RoStatus",
    (SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=m."Ad_cat_code") AS "AdCat",
    m."Card_rate" AS "CardRate",NVL(m."Agrred_rate",0) AS "AgreedRate",m."Bill_amount" AS "Amt",m."Caption" AS "Cap",
    m."Key_no" AS "Key",(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
    sysdate as "Rundate",m.CASHDISCOUNT as "Cash_Disc", m."AUDIT_COMMENT" as "COMMENT",m."Dockit_no" as "DOCKIT_NO"
    FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a
    WHERE m."Comp_code"='''||compcode||''' AND m."cio_booking_id"=i."Cio_Booking_Id"
    AND m."Agency_code"=a."Agency_Code"  and m."Agency_sub_code"=a."code_subcode"
    AND m."cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
    and  lower(i."Insert_Status") !=''cancel''
    and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where  newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
    or  ('''||chk_access||'''=''0'') )';

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

IF(pextra1 IS NOT NULL) THEN
    v_query:=v_query||'  and m."Uom_code"='''||pextra1||'''';
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

IF(pextra2 IS NOT NULL) THEN
    v_query:=v_query||'  and m."Userid"='''||pextra2||'''';
END IF;

IF(pextra3 IS NOT NULL) THEN
    v_query:=v_query||'  and a.STATE ='''||pextra3||'''';
END IF;

IF(pextra4 IS NOT NULL) THEN
    v_query:=v_query||'  and a.DISTRICT ='''||pextra4||'''';
END IF;

IF(pextra5 IS NOT NULL) THEN
    v_query:=v_query||'  and a."City_Code" ='''||pextra5||'''';
END IF;

v_query:=v_query||')x, tbl_booking_insert bi where x.CIOID=bi."Cio_Booking_Id" 
        group by x.cioid ,x.bkdate,x.agency_sub_code ,x.agency_name,x.ag_city,
    x.ro_no,x.ro_date,x."Client",x."Package",x."uom",x."Color_code",
    x."BulletPremium", x."RoStatus", x."AdCat", x."CardRate",x."AgreedRate",x."Amt",x."Cap",
    x."Key",x."companyname",x."Rundate",x."Cash_Disc", x."COMMENT",x.dockit_no';

IF(descid IS NOT  NULL) THEN
    v_query:=v_query||'  order by "'||descid||'"';
    v_query:=v_query||''||ascdesc||'';
ELSE
    v_query:=v_query||'  order by bkdate,cioid';
END IF;

delete from searchtbl;insert into searchtbl values(v_query);commit;

OPEN p_Accounts FOR v_query;

END daily_booking_report;
/
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
CREATE OR REPLACE PROCEDURE ERPTESTING.Reportnew1(
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
    pextra1         in  varchar2:=null,--for UOM
    pextra2         in  varchar2:=null,--for created by 
    pextra3         in  varchar2:=null,--for state
    pextra4         in  varchar2:=null,--for district
    pextra5         in  varchar2:=null,--for city
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
    /*(select COMBIN_MAST."Package_Name" from combin_mast where COMBIN_MAST."Combin_Code"  in(m."Package_code"))AS "Package",*/
    case when instr(m."Package_code",'','') >0 then 
        FETCH_PACK_new('''||compcode||''', m."Package_code" ) 
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

IF(pextra1 IS NOT NULL) THEN
    v_query:=v_query||'  and m."Uom_code"='''||pextra1||'''';
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

IF(pextra2 IS NOT NULL) THEN
    v_query:=v_query||'  and m."Userid"='''||pextra2||'''';
END IF;

IF(pextra3 IS NOT NULL) THEN
    v_query:=v_query||'  and a.STATE ='''||pextra3||'''';
END IF;

IF(pextra4 IS NOT NULL) THEN
    v_query:=v_query||'  and a.DISTRICT ='''||pextra4||'''';
END IF;

IF(pextra3 IS NOT NULL) THEN
    v_query:=v_query||'  and a."City_Code" ='''||pextra5||'''';
END IF;


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
========end=======avinash=14/08/2012======================================


///////////////////////////start///////shipra//////////////given by mimoh sir////////////////

CREATE OR REPLACE procedure getBarter
(
company_code in varchar2,
center in varchar2,
branch in varchar2,
agency in varchar2,
client in varchar2,
p_accounts out Cur_Type_New1.cursor_type
)
is 
begin


open p_accounts for 

select BARTE_DESC,BARTER_CODE,BARTER_AMOUNT,STOPBOOKING  from ad_barter 
where COMP_CODE=company_code and UNIT_CODE=center and BRAN_CODE=branch and 
((AG_CODE||AG_SUBCODE=agency and CLIENT_CODE=client) or (AG_CODE||AG_SUBCODE=agency)or (CLIENT_CODE=client)) and sysdate between BARTER_STDT and BARTER_ENDDT;

   
end getBarter;
/


/**************************************************************************************************/


CREATE OR REPLACE PROCEDURE Adbarter_checkduplicacy
(
compcode in varchar2,
unitcode in varchar2,
branchcode in varchar2,
bartercode in varchar2,
barterdesc in varchar2,
agencycode in varchar2,
agencysubcode in varchar2,
p_accounts   OUT   cur_type_new1.cursor_type,
p_accounts1   OUT   cur_type_new1.cursor_type
)

as
begin
 open p_accounts for
 select * from ad_barter where COMP_CODE=compcode and UNIT_CODE=unitcode and BRAN_CODE=branchcode and BARTER_CODE =bartercode;-- and AG_CODE=agencycode and AG_SUBCODE=agencysubcode;
 
  open p_accounts1 for
 select * from ad_barter where COMP_CODE=compcode and UNIT_CODE=unitcode and BRAN_CODE=branchcode and BARTE_DESC =barterdesc ;-- and AG_CODE=agencycode and AG_SUBCODE=agencysubcode;
end;
/



/////////////////////end /////////shipra////////////mimoh sir////////////

========start=======avinash==by mimoh===17/08/2012======================================
CREATE OR REPLACE PROCEDURE bindproofreading (
   compcode      IN       VARCHAR2,
   frdate        IN       VARCHAR2,
   todate        IN       VARCHAR2,
   cate          IN       VARCHAR2,
   filter1       IN       VARCHAR2,
   cat2          IN       VARCHAR2,
   p_repeat      IN       VARCHAR2,
   p_booktype    IN       VARCHAR2,
   p_bkid        IN       VARCHAR2,
   puserid       IN       VARCHAR2,
   pdateformat   IN       VARCHAR2,
   pextra1       IN       VARCHAR2,                       --for booking branch
   pextra2       IN       VARCHAR2,
   pextra3       IN       VARCHAR2,
   pextra4       IN       VARCHAR2,
   pextra5       IN       VARCHAR2,
   p_accounts    OUT      cur_type_new1.cursor_type,
   p_accounts1   OUT      cur_type_new1.cursor_type
)
AS
   v_query   VARCHAR (4000);
BEGIN
   IF filter1 = 'BOOK'
   THEN
      v_query :=
            'SELECT  distinct row_number() over (order by x."Insert_Id" asc) AS RowNumber,x."cio_booking_id" ,
                x."Client_code" as "Client_code",x."AGENCY" as "AGENCY",
                x."Filename" as "Filename",x."audit" as "audit", x."Ad_type_code" as "Ad_type_code", x."Receipt_no" as "Receipt_no", x.SAPID as SAPID,
                x."Dockit_no" as "Dockit_no",x."RO_No" as "RO_No" ,x."Agency_sub_code" as "Agency_sub_code",
                x.proofread as proofread,x."no_insert" as "no_insert",x."Insert_Id" "Insert_Id" ,x."Ad_cat_code" "Ad_cat_code",
                x."Adv_Cat_Name" "Adv_Cat_Name",x."Ad_sub_cat_code",x."Adv_Subcat_Name",x."Logo_H" as "logo_ht",x."Logo_W" as "logo_wd",
                x."Logo_name" as "logo_name",x."Size_Book" as "Size_Book",x.min_word as "MIN_WORD"
                from
                (SELECT distinct m."cio_booking_id" "cio_booking_id",m."Ad_cat_code",c."Adv_Cat_Name",
                nvl((select "Cust_Name" from cust_mast where "Cust_Code"=m."Client_code"),m."Client_code") as "Client_code",
                (select "Agency_Name" from agency_mast where "code_subcode"=m."Agency_sub_code") as "AGENCY",
                min(i."File_Name") as "Filename",m."audit", m."Ad_type_code", m."Receipt_no", m.SAPID,m."Dockit_no",m."RO_No" ,m."Agency_sub_code",
                i.proofread,min(i."No_Insert") as "no_insert",min(i."Insert_Id") "Insert_Id",m."Ad_sub_cat_code",
                (select "Adv_Subcat_Name" from adv_subcat_mast where "Adv_Cat_Code"=m."Ad_cat_code" and "Adv_Subcat_Code"=m."Ad_sub_cat_code") as "Adv_Subcat_Name",
                i."Logo_H",i."Logo_W",i."Logo_name",i."Size_Book" as "Size_Book",
                (select max("Size_To") from rate_mast where /*"Combin_Code"=i.PACKAGE_CODE and*/ "Comp_code"='''
         || compcode
         || ''' and "Rate_Mast_Code"=m."Rate_code" and "Adv_Type_Code"=m."Ad_type_code" and "Adv_Cat_Code"=m."Ad_cat_code" and 
                "Uom"=m."Uom_code" and "Color"=m."Color_code" and m."Insertion_date" between "Valid_From" and "Valid_To") as "MIN_WORD"    
                from tbl_booking_mast m,tbl_booking_insert i , adv_cat_mast c,uom_mast u
                where m."cio_booking_id"=i."Cio_Booking_Id" and m."cio_booking_id"=nvl('''
         || p_bkid
         || ''',m."cio_booking_id") and m."Ad_cat_code"=c."Adv_Cat_Code"
            and m."Comp_code"='''
         || compcode
         || ''' and "date_time" between '''
         || frdate
         || ''' and  '''
         || todate
         || ''' 
            and (m."Ad_cat_code"='''
         || cate
         || ''' or '''
         || cate
         || ''' is null or '''
         || cate
         || ''' ='''' or '''
         || cate
         || '''=''0'') 
            and (i."Ad_Sub_Cat"='''
         || cat2
         || ''' or '''
         || cat2
         || ''' is null) and (m."Userid"='''
         || puserid
         || ''' or '''
         || puserid
         || ''' is null)
         and (m."branch"='''
         || pextra1
         || ''' or '''
         || pextra1
         || ''' is null or '''
         || pextra1
         || ''' ='''' or '''
         || pextra1
         || '''=''0'')         
            and (m."Ad_type_code" =''CL0'') and m."Uom_code"=u."Uom_Code" and u.UOM_DESC<>''CD'' 
            and lower(i."Insert_Status") not in(''cancel'',''hold'')
            and exists (select "userid" from login where "userid" = m."Userid" AND ((NVL ("Agency_code", ''0'') <> ''0''
            and nvl ('''
         || p_booktype
         || ''', ''A'') = ''Q'') OR (NVL ("Agency_code", ''0'') = ''0'' AND NVL ('''
         || p_booktype
         || ''', ''A'') = ''D'') OR NVL ('''
         || p_booktype
         || ''', ''A'') = ''A''))
            group by m."cio_booking_id" ,m."Client_code",m."Agency_sub_code",m."Ad_cat_code",c."Adv_Cat_Name",m."Ad_sub_cat_code",
            m."audit", m."Ad_type_code", m."Receipt_no", m.SAPID,m."Dockit_no",m."RO_No" ,i.proofread,i."Logo_H",i."Logo_W",i."Logo_name",i."Size_Book",
            i.PACKAGE_CODE,m."Rate_code",m."Ad_type_code",m."Insertion_date",m."Uom_code",m."Color_code")x where 1=1 ';
    /*v_query:='SELECT distinct row_number() over (order by tbl_booking_insert."Insert_Id" asc) AS RowNumber,TBL_BOOKING_MAST."cio_booking_id" as "cio_booking_id",
    (select "Cust_Name" from cust_mast where "Cust_Code"=tbl_booking_mast."Client_code") as "Client_code",
    (select "Agency_Name" from agency_mast where "code_subcode"=tbl_booking_mast."Agency_sub_code") as "AGENCY",
   -- (select  "File_Name" from tbl_booking_insert where ROWNUM <=1 AND tbl_booking_insert."Cio_Booking_Id"=tbl_booking_mast."cio_booking_id") as "Filename",
    tbl_booking_insert."File_Name" as "Filename","audit", "Ad_type_code", "Receipt_no", SAPID,"Dockit_no","RO_No","Agency_sub_code",
    tbl_booking_insert.PROOFREAD as "PROOFREAD",tbl_booking_insert."No_Insert" as "no_insert",tbl_booking_insert."Insert_Id"
    FROM  TBL_BOOKING_MAST,tbl_booking_insert WHERE tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id"
    and tbl_booking_mast."Comp_code"='''||compcode||''' and "date_time"  BETWEEN '''||frdate||''' AND  '''||todate||'''
    and ("Ad_cat_code"='''||cate||''' or '''||cate||''' is null or '''||cate||''' ='''' or '''||cate||'''=''0'')
    and (tbl_booking_insert."Ad_Sub_Cat"='''||cat2||''' or '''||cat2||''' is null)';

   if p_repeat='REPEATE' then
        v_query:=v_query || ' and no_insert>1 and TBL_BOOKING_INSERT.proofread=''Y''';
   end if;

   if p_repeat='NONREPEATE' then
        v_query:=v_query || ' and no_insert=1';
    end if; */
   ELSE
      v_query :=
            'SELECT  distinct row_number() over (order by x."Insert_Id" asc) AS RowNumber,x."cio_booking_id" ,
                x."Client_code" as "Client_code",x."AGENCY" as "AGENCY",
                x."Filename" as "Filename",x."audit" as "audit", x."Ad_type_code" as "Ad_type_code", x."Receipt_no" as "Receipt_no", x.SAPID as SAPID,
                x."Dockit_no" as "Dockit_no",x."RO_No" as "RO_No" ,x."Agency_sub_code" as "Agency_sub_code",
                x.proofread as proofread,x."no_insert" as "no_insert",x."Insert_Id" "Insert_Id" ,x."Ad_cat_code" "Ad_cat_code",
                x."Adv_Cat_Name" "Adv_Cat_Name",x."Ad_sub_cat_code",x."Adv_Subcat_Name",x."Logo_H" as "logo_ht",x."Logo_W" as "logo_wd",
                x."Logo_name" as "logo_name",x."Size_Book" as "Size_Book",x.min_word as "MIN_WORD"
                from
                (SELECT distinct m."cio_booking_id" "cio_booking_id",m."Ad_cat_code",c."Adv_Cat_Name",
                nvl((select "Cust_Name" from cust_mast where "Cust_Code"=m."Client_code"),m."Client_code") as "Client_code",
                (select "Agency_Name" from agency_mast where "code_subcode"=m."Agency_sub_code") as "AGENCY",
                min(i."File_Name") as "Filename",m."audit", m."Ad_type_code", m."Receipt_no", m.SAPID,m."Dockit_no",m."RO_No" ,m."Agency_sub_code",
                i.proofread,min(i."No_Insert") as "no_insert",min(i."Insert_Id") "Insert_Id",m."Ad_sub_cat_code",
                (select "Adv_Subcat_Name" from adv_subcat_mast where "Adv_Cat_Code"=m."Ad_cat_code" and "Adv_Subcat_Code"=m."Ad_sub_cat_code") as "Adv_Subcat_Name",
                i."Logo_H",i."Logo_W",i."Logo_name",i."Size_Book" as "Size_Book",
                (select max("Size_To") from rate_mast where /*"Combin_Code"=i.PACKAGE_CODE and*/ "Comp_code"='''
         || compcode
         || ''' and "Rate_Mast_Code"=m."Rate_code" and "Adv_Type_Code"=m."Ad_type_code" and "Adv_Cat_Code"=m."Ad_cat_code" and 
                "Uom"=m."Uom_code" and "Color"=m."Color_code" and m."Insertion_date" between "Valid_From" and "Valid_To") as "MIN_WORD"   
                from tbl_booking_mast m,tbl_booking_insert i , adv_cat_mast c,uom_mast u
                where m."cio_booking_id"=i."Cio_Booking_Id" and m."cio_booking_id"=nvl('''
         || p_bkid
         || ''',m."cio_booking_id") and m."Ad_cat_code"=c."Adv_Cat_Code"
                and m."Comp_code"='''
         || compcode
         || ''' and i."Insert_Date"  between '''
         || frdate
         || ''' AND  '''
         || todate
         || ''' 
                and (m."Ad_cat_code"='''
         || cate
         || ''' or '''
         || cate
         || ''' is null or '''
         || cate
         || ''' ='''' or '''
         || cate
         || '''=''0'') 
                and (i."Ad_Sub_Cat"='''
         || cat2
         || ''' or '''
         || cat2
         || ''' is null) and (m."Userid"='''
         || puserid
         || ''' or '''
         || puserid
         || ''' is null) 
         and (m."branch"='''
         || pextra1
         || ''' or '''
         || pextra1
         || ''' is null or '''
         || pextra1
         || ''' ='''' or '''
         || pextra1
         || '''=''0'')         
                and m."Ad_type_code" =''CL0'' and m."Uom_code"=u."Uom_Code" and u.UOM_DESC<>''CD'' 
                and lower(i."Insert_Status") not in(''cancel'',''hold'')
                and exists (select "userid" from login where "userid" = m."Userid" AND ((NVL ("Agency_code", ''0'') <> ''0''
                and nvl ('''
         || p_booktype
         || ''', ''A'') = ''Q'') OR (NVL ("Agency_code", ''0'') = ''0'' AND NVL ('''
         || p_booktype
         || ''', ''A'') = ''D'') OR NVL ('''
         || p_booktype
         || ''', ''A'') = ''A''))
                group by m."cio_booking_id" ,m."Client_code",m."Agency_sub_code",m."Ad_cat_code",c."Adv_Cat_Name",m."Ad_sub_cat_code",
                m."audit", m."Ad_type_code", m."Receipt_no", m.SAPID,m."Dockit_no",m."RO_No" ,i.proofread,i."Logo_H",i."Logo_W",i."Logo_name",i."Size_Book",
                i.PACKAGE_CODE,m."Rate_code",m."Ad_type_code",m."Insertion_date",m."Uom_code",m."Color_code")x where 1=1 ';
   /* v_query:= 'SELECT  distinct row_number() over (order by tbl_booking_insert."Insert_Id" asc) AS RowNumber,TBL_BOOKING_MAST."cio_booking_id" ,
   (select "Cust_Name" from cust_mast where "Cust_Code"=tbl_booking_mast."Client_code") as "Client_code",
   (select "Agency_Name" from agency_mast where  "code_subcode"=tbl_booking_mast."Agency_sub_code") as "AGENCY",
   tbl_booking_insert."File_Name" as "Filename","audit", "Ad_type_code", "Receipt_no", SAPID,"Dockit_no","RO_No" ,"Agency_sub_code",
   TBL_BOOKING_INSERT.proofread,tbl_booking_insert."No_Insert" as "no_insert",tbl_booking_insert."Insert_Id"
   FROM  TBL_BOOKING_MAST,tbl_booking_insert WHERE TBL_BOOKING_MAST."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id"
   and tbl_booking_insert."Insert_Date" BETWEEN '''||frdate||''' AND '''||todate||'''
   and ("Ad_cat_code"='''||cate||''' or '''||cate||''' is null or '''||cate||''' ='''' or '''||cate||'''=''0'')
   and TBL_BOOKING_MAST."Comp_code"='''||compcode||''' and (tbl_booking_insert."Ad_Sub_Cat"='''||cat2||''' or '''||cat2||''' is null)';

   if p_repeat='REPEATE' then
           v_query:=v_query || ' and no_insert>1 and TBL_BOOKING_INSERT.proofread=''Y''';
      end if;

   if p_repeat='NONREPEATE' then
       v_query:=v_query || ' and no_insert=1';
   end if; */
   END IF;

   IF p_repeat = 'PROOFED'
   THEN
      v_query := v_query || ' and x.proofread=''Y''';
   END IF;

   IF p_repeat = 'UNPROOFED'
   THEN
      v_query := v_query || ' and nvl(x.proofread,''N'')<>''Y''';
   END IF;

   v_query := v_query || ' order by x."Insert_Id"';

   INSERT INTO test1
               (vstring2
               )
        VALUES (v_query
               );

   COMMIT;

   OPEN p_accounts FOR v_query;

   OPEN p_accounts1 FOR
      SELECT DISTINCT m."Package_code" AS "Package_code",
                      (SELECT DISTINCT "Package_Name"
                                  FROM combin_mast
                                 WHERE "Combin_Code" =
                                           m."Package_code")
                                                            AS "Package_Name",
                      TO_CHAR (i."Insert_Date",
                               '' || pdateformat || ''
                              ) AS "Insert_Date",
                      i."Insert_Date" AS "PUBLISH_DATE"
                 FROM tbl_booking_mast m, tbl_booking_insert i
                WHERE m."Comp_code" = i."Comp_Code"
                  AND m."cio_booking_id" = i."Cio_Booking_Id"
                  AND m."cio_booking_id" = p_bkid
                  AND LOWER (i."Insert_Status") NOT IN ('cancel', 'hold')
             ORDER BY "Package_Name", "PUBLISH_DATE";
END bindproofreading;
/



========end=======avinash==by mimoh===17/08/2012======================================

========start=======avinash=====17/08/2012======================================
CREATE OR REPLACE procedure HT18JULY.clientupdttrasac(
  
   pcomp_code  in varchar2,
   puserid     in varchar2,
   pclientcod  in varchar2 ,
   p_accounts      OUT Cur_Type_New1.cursor_type

)
as 
begin

open p_accounts for 

select "cio_booking_id",(select "Agency_Name" from agency_mast where "code_subcode"=m."Agency_sub_code" and "Comp_Code"=pcomp_code) as "Agency_Name" ,
"Client_code",(select "Package_Name" from combin_mast where "Combin_Code"=m."Package_code" and "Comp_Code"=pcomp_code) as "Package_Name" 
from tbl_booking_mast m 
where "Comp_code"=pcomp_code and "Client_code"=pclientcod;

end clientupdttrasac;
/
********************************************************
CREATE OR REPLACE procedure HT18JULY.clientupdttrasac2(
   pciobookid IN VARCHAR2,

  pclientcod IN VARCHAR2,
  pcomp_cod in varchar2
  
)
   AS
   BEGIN

         UPDATE TBL_BOOKING_Mast SET "Client_code"=pclientcod,
"Client_address"=nvl((SELECT nvl("Add1",'') FROM CUST_MAST where "Cust_Name"=pclientcod),'') 
WHERE  "cio_booking_id"=pciobookid
          and "Comp_code"=pcomp_cod;



   END clientupdttrasac2;
/



========end=======avinash=====17/08/2012======================================


========start===8199====avinash=====21/08/2012======================================
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
f_caption       varchar2(2000);


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
,max("Uom_code")
,max("Caption")
 into FRetCommPer,FRetCommAmt,FRetTDPer,FRetTDAmt,FActualBusiness
,Fnoinsert,FPaidinsert,FDeviationamt,FDeviationper,FAggrate,Faggamt,FDiscper,FSpdiscper,FSpacediscper,FSpecialcharge,FAgencyAddlTDper,FAgencyAddlTDAmt
,FfUom
,f_caption

  from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=FCIOID;
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
  CITY_CODE,ZONE_CODE,DIST_CODE,STATE_CODE,PTALUKA,CITY_NAME,ZONE_NAME,STATE_NAME,PAGE_NO,BILL_REMARK,CAPTION
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
,f_caption
);
commit;


return 0;

--exception when others then
--insert into amit_amit(COMPCODE,subcode,name) values(comp_cod,cio_id,bil_no);  commit;
END;
/



========end===8199====avinash=====21/08/2012======================================

========start=======avinash by sumit dhama sir======================================
CREATE OR REPLACE PROCEDURE HT18JULY.daily_booking_report(
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
    pextra1         in  varchar2:=null,--for UOM
    pextra2         in  varchar2:=null,--for created by 
    pextra3         in  varchar2:=null,--for state
    pextra4         in  varchar2:=null,--for district
    pextra5         in  varchar2:=null,--for city
    p_Accounts     OUT Cur_Type_New1.cursor_type)
IS

center      VARCHAR(50);
from_date   DATE;
date_to     DATE;
v_query     VARCHAR(8000);
a           number;
BEGIN
    v_query:=' select distinct x.cioid AS "CIOID",x.bkdate as bkdate,
    x.agency_sub_code agency_sub_code,x.agency_name agency_name,x.ag_city as ag_city,
    x.ro_no ro_no,x.ro_date ro_date,
    x."Client" AS "Client",
    x."Package" AS "Package",
    x."uom" as "uom",x."Color_code" AS "Color_code",
    x."BulletPremium" AS "BulletPremium" ,
    x."RoStatus" AS "RoStatus",
    x."AdCat" AS "AdCat",
    x."CardRate" AS "CardRate",x."AgreedRate" AS "AgreedRate",x."Amt" AS "Amt",x."Cap" AS "Cap",
    x."Key" AS "Key",x."companyname" AS "companyname",
    x."Rundate" as "Rundate",x."Cash_Disc" as "Cash_Disc", x."COMMENT" as "COMMENT",x.dockit_no as "DOCKIT_NO",
    min(bi."Insert_Date") fisrt_pubdt,max(bi."Insert_Date") last_pubdt ,max(bi."No_Insert") no_of_insdertion
    from
    (select distinct m."cio_booking_id" AS "CIOID",m."date_time" as bkdate,
    m."Agency_sub_code" agency_sub_code,a."Agency_Name"  agency_name,(select "City_Name" from city_mst where "City_Code"=a."City_Code") as ag_city,
    m."RO_No" ro_no,m."RO_Date" ro_date,
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
    case when instr(m."Package_code",'','') >0 then 
        FETCH_PACK_new('''||compcode||''', m."Package_code" ) 
    else
        (select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=m."Package_code")
    end AS "Package",
    (select uom_mast.UOM_DESC from uom_mast where m."Uom_code"=uom_mast."Uom_Code")as "uom",i."Col_Code" AS "Color_code",
    m."Bullet_code" AS "BulletPremium" ,
    CASE m."ro_status" WHEN ''2'' THEN ''Reservation'' WHEN ''1'' THEN ''Confirm'' END AS "RoStatus",
    (SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=m."Ad_cat_code") AS "AdCat",
    m."Card_rate" AS "CardRate",NVL(m."Agrred_rate",0) AS "AgreedRate",m."Bill_amount" AS "Amt",m."Caption" AS "Cap",
    m."Key_no" AS "Key",(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
    sysdate as "Rundate",m.CASHDISCOUNT as "Cash_Disc", m."AUDIT_COMMENT" as "COMMENT",m."Dockit_no" as "DOCKIT_NO"
    FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a
    WHERE m."Comp_code"='''||compcode||''' AND m."cio_booking_id"=i."Cio_Booking_Id"
    AND m."Agency_code"=a."Agency_Code"  and m."Agency_sub_code"=a."code_subcode"
    AND m."cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
    and  lower(i."Insert_Status") !=''cancel''
    and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where  newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
    or  ('''||chk_access||'''=''0'') )';

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

IF(pextra1 IS NOT NULL) THEN
    v_query:=v_query||'  and m."Uom_code"='''||pextra1||'''';
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

IF(pextra2 IS NOT NULL) THEN
    v_query:=v_query||'  and m."Userid"='''||pextra2||'''';
END IF;

IF(pextra3 IS NOT NULL) THEN
    v_query:=v_query||'  and a.STATE ='''||pextra3||'''';
END IF;

IF(pextra4 IS NOT NULL) THEN
    v_query:=v_query||'  and a.DISTRICT ='''||pextra4||'''';
END IF;

IF(pextra5 IS NOT NULL) THEN
    v_query:=v_query||'  and a."City_Code" ='''||pextra5||'''';
END IF;

v_query:=v_query||')x, tbl_booking_insert bi where x.CIOID=bi."Cio_Booking_Id" 
        group by x.cioid ,x.bkdate,x.agency_sub_code ,x.agency_name,x.ag_city,
    x.ro_no,x.ro_date,x."Client",x."Package",x."uom",x."Color_code",
    x."BulletPremium", x."RoStatus", x."AdCat", x."CardRate",x."AgreedRate",x."Amt",x."Cap",
    x."Key",x."companyname",x."Rundate",x."Cash_Disc", x."COMMENT",x.dockit_no';

IF(descid IS NOT  NULL) THEN
    v_query:=v_query||'  order by "'||descid||'"';
    v_query:=v_query||''||ascdesc||'';
ELSE
    v_query:=v_query||'  order by bkdate,cioid';
END IF;

delete from searchtbl;insert into searchtbl values(v_query,'','');commit;

OPEN p_Accounts FOR v_query;

END daily_booking_report;
/
*****************************************************************

CREATE OR REPLACE PROCEDURE HT18JULY.Reportnew1(
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
     pinclude       IN  VARCHAR2:= NULL,
    pextra1         in  varchar2:=null,--for UOM
    pextra2         in  varchar2:=null,--for created by 
    pextra3         in  varchar2:=null,--for state
    pextra4         in  varchar2:=null,--for district
    pextra5         in  varchar2:=null,--for city
    pextra6         in  varchar2:=null,--for bookingid
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
    /*(select COMBIN_MAST."Package_Name" from combin_mast where COMBIN_MAST."Combin_Code"  in(m."Package_code"))AS "Package",*/
    case when instr(m."Package_code",'','') >0 then 
        FETCH_PACK_new('''||compcode||''', m."Package_code" ) 
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
IF(pextra6 ='') then
    IF(fromdate IS NOT NULL AND dateto IS NULL ) THEN
        v_query:=v_query||' and m."date_time" ='''||fromdate||'''';

    END IF;

    IF(fromdate IS NOT NULL AND dateto IS NOT NULL ) THEN
        v_query:=v_query||' and m."date_time" between  '''||fromdate ||''' and  '''||dateto||''' ';
    END IF;
    end IF;
Else
IF(pextra6 ='') then
    IF(fromdate IS NOT NULL AND dateto IS NULL ) THEN
        v_query:=v_query||' and i."Insert_Date" ='''||fromdate||'''';
    END IF;

    IF(fromdate IS NOT NULL AND dateto IS NOT NULL ) THEN
        v_query:=v_query||' and i."Insert_Date" between  '''||fromdate ||''' and  '''||dateto||''' ';
    END IF;
    END IF;
End If;    

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

if(nvl(pinclude,'N')='N' )then
v_query := v_query || ' and lower(i."Insert_Status" )!=''hold''';
end if;


IF(pextra2 IS NOT NULL) THEN
    v_query:=v_query||'  and m."Userid"='''||pextra2||'''';
END IF;

IF(pextra3 IS NOT NULL) THEN
    v_query:=v_query||'  and a.STATE ='''||pextra3||'''';
END IF;

IF(pextra4 IS NOT NULL) THEN
    v_query:=v_query||'  and a.DISTRICT ='''||pextra4||'''';
END IF;

IF(pextra3 IS NOT NULL) THEN
    v_query:=v_query||'  and a."City_Code" ='''||pextra5||'''';
END IF;

 IF (pextra6 IS NOT NULL )
   THEN
      v_query := v_query || ' and m."cio_booking_id" =''' || pextra6 || '''';
   END IF;


IF(descid IS NOT  NULL) THEN
    v_query:=v_query||'  order by "'||descid||'"';
    v_query:=v_query||''||ascdesc||'';
ELSE
    v_query:=v_query||'  order by i."Insert_Date",m."cio_booking_id"';
END IF;

delete from searchtbl;insert into searchtbl values(v_query,'','');commit;

OPEN p_reportnew FOR v_query;

END Reportnew1;
/
*************************************************************
CREATE OR REPLACE PROCEDURE HT18JULY.schedulereport_checklist (
   fromdate           IN       VARCHAR2,
   dateto             IN       VARCHAR2,
   compcode           IN       VARCHAR2,
   pub_name           IN       VARCHAR2,
   pub_cent           IN       VARCHAR2,
   DATEFORMAT         IN       VARCHAR2,
   descid             IN       VARCHAR2 := NULL,
   ascdesc            IN       VARCHAR2 := NULL,
   adtyp              IN       VARCHAR2,
   adcatg             IN       VARCHAR2,
   edition_name       IN       VARCHAR2,
   drpstatus          IN       VARCHAR2,
   supplement_name    IN       VARCHAR2,
   packagecode        IN       VARCHAR2,
   editiondtl         IN       VARCHAR2,
   puserid            IN       VARCHAR2 := NULL,
   chk_access         IN       VARCHAR2 := NULL,
   p_branch           IN       VARCHAR2 := NULL,
   poth_branch_flag   IN       VARCHAR2,                               --Y for
   p_uom              IN       VARCHAR2,
   p_accounts         OUT      cur_type_new1.cursor_type,
   p_accounts1        OUT      cur_type_new1.cursor_type,
   p_accounts2        OUT      cur_type_new1.cursor_type,
   p_accounts3        OUT      cur_type_new1.cursor_type,
   p_accounts4        OUT      cur_type_new1.cursor_type
)
IS
   query_upper              VARCHAR2 (8000);
   query1                   VARCHAR2 (20000);
   query_booked_by_others   VARCHAR2 (20000);
   query_group              VARCHAR2 (8000);
   query2                   VARCHAR2 (1000);
   vwherecl                 VARCHAR2 (8000);
   query_not_pubdt          VARCHAR2 (20000);
   v_gau                    NUMBER           := 17;
   v_val                    NUMBER (4);
   vs_gau                   NUMBER (4);
   v_billed                 NUMBER (10);
   v_booked_by_others       NUMBER (10);
   v_direct_cash            NUMBER (10);
   v_scheme_ads             NUMBER (10);
   v_fmg_ads                NUMBER (10);
   v_scheme_type            VARCHAR2 (50);
   v_fmg_bill               VARCHAR2 (50);
BEGIN
---------------------end -------------------------------
   query_upper :=
         'select distinct x.comp_code as "COMP_CODE",x.branch as "BRANCH",x.cioid as "CIOID",x.agency as "AGENCY",x.agency_city as "AGENCY_CITY",
        x.client  as "CLIENT",x.hue as "HUE",x.cardrate as "CARDRATE",x.agreedrate as "AGREEDRATE",
        x.caption as "CAPTION",x.key_no as "KEY_NO",x.RO_NO as "RO_NO",x.RATE_CODE as "RATE_CODE",
        x.pagepremium as "PAGEPREMIUM",x.pospremium as "POSPREMIUM",
        max(x.width)  as "WIDTH",max(x.depth) as "DEPTH",max(x.area) as "AREA",
        min(x.ins_date) as "INSERT_DATE" ,
        case '''
      || DATEFORMAT
      || '''
        when ''mm/dd/yyyy'' then to_char(min(x.ins_date),''MM-DD-YY'')
        when ''dd/mm/yyyy'' then to_char(min(x.ins_date),''DD-MM-YY'')
        when ''yyyy/mm/dd'' then to_char(min(x.ins_date),''YY-MM-DD'') end
        as "INS_DATE" ,
        x.adcat as "ADCAT",x.adsubcat as "ADSUBCAT",x.adsubcat3 as "ADSUBCAT3",
        min(x.pageno) as "PAGENO",x.ratecd as "RATECD",x.uom as "UOM",x.uomdesc as "UOMDESC",x.booktype as "booktype",x."AUDIT" as "AUDIT",
        x.app_status as "APP_STATUS",x.app_user as "APP_USER",x.no_insert as "NO_INSERT",x.branch_name as "BRANCH_NAME",
        x.package_name AS "PACKAGE_NAME",x.edition as "EDITION",
        x.trade_disc as "TRADE_DISC",/*sum(x.bill_amt) "BILL_AMT",*/
        (select sum(tbl_booking_insert."Bill_Amt") from tbl_booking_insert
        where tbl_booking_insert."Cio_Booking_Id"=x."CIOID" and tbl_booking_insert."No_Insert"=x."NO_INSERT"
        and lower(tbl_booking_insert."Insert_Status") !=''cancel''and lower(tbl_booking_insert."Insert_Status") !=''hold'') "BILL_AMT",
        x.bill_remarks as "BILL_REMARKS",x.bill_no as "BILL_NO",x.bill_date as "BILL_DATE",
           case '''
      || DATEFORMAT
      || '''
        when ''mm/dd/yyyy'' then to_char(x.bill_date,''MM-DD-YY'')
        when ''dd/mm/yyyy'' then to_char(x.bill_date,''DD-MM-YY'')
        when ''yyyy/mm/dd'' then to_char(x.bill_date,''YY-MM-DD'') end
        as "BILLDATE" ,
        x.edition_name as "EDITION_NAME",x.no_of_insertion as "NO_OF_INSERTION",x.Bill_cycle as "BILL_CYCLE"
        from(';
   query1 :=
         'select distinct m."Comp_code" comp_code,m."branch" branch, m."cio_booking_id" cioid,a."Agency_Name" agency,(select "City_Name" from city_mst where "City_Code"=a."City_Code") agency_city,
        nvl((select "Cust_Name" from cust_mast where "Cust_Code"=m."Client_code" and m."Comp_code"=cust_mast."Comp_Code" ),m."Client_code")  client,
        c."Col_Alias" hue,m."Card_rate" as cardrate,nvl(m."Agrred_rate",''0'') agreedrate,
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
        fetch_publish_edtnname(m."Comp_code",m."cio_booking_id",nvl(i."Insert_Date",'''
      || fromdate
      || '''),null,'''
      || pub_name
      || ''',null,'''
      || DATEFORMAT
      || ''',null,null) as edition,
        m."Trade_disc" as trade_disc,i."Bill_Amt" as bill_amt,m."Print_remark" bill_remarks,i.bill_no bill_no,i.bill_date bill_date,
        fetch_insert_center_edtn(m."Comp_code",m."cio_booking_id", '''
      || pub_cent
      || ''',i."No_Insert") as edition_name,
        m."No_of_insertion" NO_OF_INSERTION,m."Bill_cycle" "BILL_CYCLE"
        from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,col_mast c,uom_mast u,branch_mst b,adv_cat_mast ac
        where m."Comp_code"='''
      || compcode
      || ''' and m."Comp_code"=i."Comp_Code" and ac."Comp_Code"=i."Comp_Code" and
        m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
        i."Col_Code"=c."Col_Code" and b."Branch_Code"=m."branch" and ac."Adv_Cat_Code"=i."Ad_Cat"
        and lower(i."Insert_Status") not in(''cancel'',''hold'') and u."Uom_Code"=m."Uom_code"
        and not exists (select distinct ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)';

   IF (p_branch IS NOT NULL)
   THEN
      --query_booked_by_others  :=' union '||query1||' AND m."branch"<>'''||p_branch||'''';
      --query1                  :=query1||' AND m."branch"='''||p_branch||'''';
      query_booked_by_others :=
            ' union '
         || query1
         || ' and exists(select distinct ''x'' from tbl_booking_mast a, tbl_booking_insert b 
    where a."Comp_code"=b."Comp_Code" and a."cio_booking_id"=b."Cio_Booking_Id" and 
    a."cio_booking_id"=m."cio_booking_id" and b."No_Insert"=i."No_Insert" and b."Insert_Date" between '''
         || fromdate
         || ''' and '''
         || dateto
         || ''' AND a."branch"=nvl('''
         || p_branch
         || ''',a."branch"))';
   END IF;

/*IF fromdate IS NOT NULL and dateto IS NOT NULL THEN
    vwherecl:=vwherecl||'and ((i."Insert_Date" between '''||fromdate||''' and '''||dateto||''') or i."Insert_Date" is null)
    and exists(select distinct ''x'' from tbl_booking_mast a, tbl_booking_insert b
    where a."Comp_code"=b."Comp_Code" and a."cio_booking_id"=b."Cio_Booking_Id" and
    a."cio_booking_id"=m."cio_booking_id" and b."No_Insert"=i."No_Insert" and b."Insert_Date" between '''||fromdate||''' and '''||dateto||''' AND a."branch"=nvl('''||p_branch||''',a."branch"))';
END iF;*/
   IF fromdate IS NOT NULL AND dateto IS NOT NULL
   THEN
      --vwherecl:=vwherecl||' and i."Insert_Date" between '''||fromdate||''' and '''||dateto||'''';
      query1 :=
            query1
         || 'and i."Insert_Date" between '''
         || fromdate
         || ''' and '''
         || dateto
         || '''';
   END IF;

   IF (pub_name IS NOT NULL)
   THEN
      vwherecl :=
               vwherecl || ' AND i."Publication_Code"=''' || pub_name || '''';
   END IF;

   IF (adtyp IS NOT NULL)
   THEN
      vwherecl := vwherecl || ' AND m."Ad_type_code"=''' || adtyp || ''' ';
   END IF;

   IF (p_uom IS NOT NULL)
   THEN
      vwherecl := vwherecl || ' AND m."Uom_code"=''' || p_uom || ''' ';
   END IF;

   IF (adcatg IS NOT NULL)
   THEN
      vwherecl := vwherecl || ' AND i."Ad_Cat" in (''' || adcatg || ''' )';
   END IF;

   IF (edition_name IS NOT NULL)
   THEN
      vwherecl :=
              vwherecl || '  AND i."Edition_Code"=''' || edition_name || '''';
   END IF;

   IF (supplement_name IS NOT NULL)
   THEN
      vwherecl :=
           vwherecl || ' AND (i."Supp_Code" =''' || supplement_name || ''' )';
   END IF;

   IF (packagecode IS NOT NULL)
   THEN
      vwherecl :=
         vwherecl || ' AND (''' || packagecode
         || ''' in (m."Package_code") )';
   END IF;

   IF (pub_cent IS NOT NULL)
   THEN
      query2 := '  AND i."Pub_Cent_Code"=''' || pub_cent || '''';
   END IF;

   query2 :=
         query2
      || ' AND m."cio_booking_id" not in(select distinct "Cio_Booking_Id" from tbl_booking_mast m,tbl_booking_insert i
where m."cio_booking_id"=i."Cio_Booking_Id" and "Insert_Date"<''1-may-2012'' and m."Uom_code"=''RO0'') ';
   query_group :=
      ' )x group by x.comp_code,x.branch, x.cioid,x.agency,x.agency_city, x.client,x.hue,x.cardrate,x.agreedrate,
x.caption,x.key_no ,x.RO_NO,x.RATE_CODE,x.pagepremium,x.pospremium,x.adcat,x.adsubcat ,x.adsubcat3 ,
x.ratecd ,x.uom,x.uomdesc,x.booktype,x."AUDIT",x.app_status ,x.app_user,x.no_insert,x.branch_name,
x.package_name,x.edition,x.trade_disc,x.bill_remarks,x.bill_no,x.bill_date,x.edition_name,x.no_of_insertion,x.Bill_cycle';
   query_group :=
       query_group || ' order by package_name,edition_name, cioid,insert_date';

   DELETE FROM searchtbl;

   INSERT INTO searchtbl
        VALUES ('query_upper ' || query_upper);

   COMMIT;

   INSERT INTO searchtbl
        VALUES ('query1 ' || query1);

   COMMIT;

   INSERT INTO searchtbl
        VALUES ('vwherecl ' || vwherecl);

   COMMIT;

   INSERT INTO searchtbl
        VALUES ('query2 ' || query2 || query_group);

   COMMIT;

   OPEN p_accounts FOR    query_upper
                       || query1
                       || vwherecl
                       || query2
                       || query_booked_by_others
                       || vwherecl
                       || query2
                       || query_group;

   OPEN p_accounts1 FOR
      SELECT "Edition_Alias" AS "Editions"
        FROM edition_mast
       WHERE ("Pub_Code" = pub_name OR pub_name IS NULL)
         AND "Edition_Type" = 'Main Edition';

   IF fromdate IS NOT NULL AND dateto IS NOT NULL
   THEN
      --vwherecl:=vwherecl||' and i."Insert_Date" between '''||fromdate||''' and '''||dateto||'''';
      query2 :=
            query2
         || 'and i."Insert_Date" between '''
         || fromdate
         || ''' and '''
         || dateto
         || '''';
   END IF;

   IF NVL (poth_branch_flag, 'N') = 'Y' AND (pub_cent IS NOT NULL)
   THEN
      query2 :=
            ' AND m."branch"='''
         || p_branch
         || ''' AND not exists (select ''x'' from tbl_booking_insert where "Cio_Booking_Id"=m."cio_booking_id" and "No_Insert"=i."No_Insert" and "Pub_Cent_Code"='''
         || pub_cent
         || ''')';
   ELSE
      query2 := ' AND 1=2 ';
   END IF;

   SELECT bill_scheme, fmg_bill_dis
     INTO v_scheme_type, v_fmg_bill
     FROM preferrences
    WHERE "comp_code" = compcode;

--delete from searchtbl;
   INSERT INTO searchtbl
        VALUES (query1);

   COMMIT;

   INSERT INTO searchtbl
        VALUES (query2 || query_group);

   COMMIT;

   OPEN p_accounts2 FOR query_upper || query1 || vwherecl || query2
                        || query_group;

   OPEN p_accounts3 FOR
      SELECT   pack, tot
          FROM multipage_break
         WHERE sess_id = USERENV ('sessionid')
      ORDER BY pack, tot DESC;

/*select sum(x.billed_ads) into v_billed from
(select count(distinct i."Cio_Booking_Id"||i."No_Insert") as billed_ads from tbl_booking_mast m,tbl_booking_insert i
    where m."Comp_code"=compcode and m."cio_booking_id"=i."Cio_Booking_Id" and
    exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "Branch_Code"=nvl(p_branch,"Branch_Code") and "pub_center"=pub_cent ) and
    m."Ad_type_code"=nvl(adtyp,m."Ad_type_code") AND i."Insert_Date" BETWEEN fromdate AND  dateto and bill_no is not null
    AND i."Pub_Cent_Code"=nvl(pub_cent,i."Pub_Cent_Code")
    AND m."Uom_code"=nvl(p_uom,m."Uom_code")
union all
select count(distinct i."Cio_Booking_Id"||i."No_Insert")  as billed_ads from tbl_booking_mast m,tbl_booking_insert i
    where m."Comp_code"=compcode and m."cio_booking_id"=i."Cio_Booking_Id" and
    exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "Branch_Code"=nvl(p_branch,"Branch_Code")) and
    m."Ad_type_code"=nvl(adtyp,m."Ad_type_code") AND i."Insert_Date" BETWEEN fromdate AND  dateto and bill_no is not null
    AND i."Pub_Cent_Code"<>pub_cent and nvl(poth_branch_flag,'N')='Y'
    and  not exists(select 'x' from tbl_booking_mast a,tbl_booking_insert b
    where a."Comp_code"=compcode and a."cio_booking_id"=b."Cio_Booking_Id" and b."Cio_Booking_Id"=i."Cio_Booking_Id" and b."No_Insert"=i."No_Insert" and
    exists (select 'x' from branch_mst where "Branch_Code"=a."branch" and "Branch_Code"=nvl(p_branch,"Branch_Code")) and
    a."Ad_type_code"=nvl(adtyp,a."Ad_type_code") AND b.bill_no is not null
    AND b."Pub_Cent_Code"=nvl(pub_cent,b."Pub_Cent_Code")
    ) AND m."Uom_code"=nvl(p_uom,m."Uom_code"))x;*/
   SELECT COUNT (DISTINCT i."Cio_Booking_Id" || i."No_Insert")
     INTO v_booked_by_others
     FROM tbl_booking_mast m, tbl_booking_insert i
    WHERE m."Comp_code" = compcode
      AND m."cio_booking_id" = i."Cio_Booking_Id"
      AND NOT EXISTS (
             SELECT 'x'
               FROM branch_mst
              WHERE "Branch_Code" = m."branch"
                AND "Branch_Code" = NVL (p_branch, "Branch_Code")
                AND "pub_center" = pub_cent)
      AND m."Ad_type_code" = NVL (adtyp, m."Ad_type_code")
      AND i."Insert_Date" BETWEEN fromdate AND dateto
      AND NOT EXISTS (
             SELECT 'x'
               FROM tbl_booking_mast
              WHERE m."Comp_code" = compcode
                AND "prev_cioid" IS NOT NULL
                AND "prev_cioid" = m."cio_booking_id")
      AND i."Pub_Cent_Code" = NVL (pub_cent, i."Pub_Cent_Code")
      AND m."Uom_code" = NVL (p_uom, m."Uom_code")
      AND LOWER (i."Insert_Status") != 'cancel'
      AND LOWER (i."Insert_Status") != 'hold';

   SELECT SUM (x.direct_cash_ads)
     INTO v_direct_cash
     FROM (SELECT COUNT (DISTINCT i."Cio_Booking_Id" || i."No_Insert"
                        ) AS direct_cash_ads
             FROM tbl_booking_mast m, tbl_booking_insert i
            WHERE m."Comp_code" = compcode
              AND m."cio_booking_id" = i."Cio_Booking_Id"
              AND EXISTS (
                     SELECT 'x'
                       FROM branch_mst
                      WHERE "Branch_Code" = m."branch"
                        AND "Branch_Code" = NVL (p_branch, "Branch_Code"))
              AND m."Ad_type_code" = NVL (adtyp, m."Ad_type_code")
              AND i."Insert_Date" BETWEEN fromdate AND dateto
              AND i.bill_no IS NULL
              AND m."Uom_code" = NVL (p_uom, m."Uom_code")
              AND EXISTS (
                       SELECT 'x'
                         FROM ad_direct_client_agency
                        WHERE m."Agency_sub_code" =
                                                   ag_main_code || ag_sub_code)
              AND m."Bill_pay" = 'CA0'
              AND LOWER (i."Insert_Status") != 'cancel'
              AND LOWER (i."Insert_Status") != 'hold') x;

   IF v_fmg_bill = 'Exclude'
   THEN
      SELECT SUM (x.fmg_ads)
        INTO v_fmg_ads
        FROM (SELECT COUNT (DISTINCT i."Cio_Booking_Id" || i."No_Insert"
                           ) AS fmg_ads
                FROM tbl_booking_mast m, tbl_booking_insert i
               WHERE m."Comp_code" = compcode
                 AND m."cio_booking_id" = i."Cio_Booking_Id"
                 AND EXISTS (
                        SELECT 'x'
                          FROM branch_mst
                         WHERE "Branch_Code" = m."branch"
                           AND "Branch_Code" = NVL (p_branch, "Branch_Code"))
                 AND m."Ad_type_code" = NVL (adtyp, m."Ad_type_code")
                 AND i."Insert_Date" BETWEEN fromdate AND dateto
                 AND i.bill_no IS NULL
                 AND m."Uom_code" = NVL (p_uom, m."Uom_code")
                 AND m."Booking_type" IN ('2', '4', '5')
                 AND LOWER (i."Insert_Status") != 'cancel'
                 AND LOWER (i."Insert_Status") != 'hold') x;
   END IF;

   IF v_scheme_type = 'EXCLUDE' OR v_scheme_type = 'EXCULDE'
   THEN
      SELECT SUM (x.scheme_ads)
        INTO v_scheme_ads
        FROM (SELECT COUNT (DISTINCT i."Cio_Booking_Id" || i."No_Insert"
                           ) AS scheme_ads
                FROM tbl_booking_mast m, tbl_booking_insert i
               WHERE m."Comp_code" = compcode
                 AND m."cio_booking_id" = i."Cio_Booking_Id"
                 AND EXISTS (
                        SELECT 'x'
                          FROM branch_mst
                         WHERE "Branch_Code" = m."branch"
                           AND "Branch_Code" = NVL (p_branch, "Branch_Code"))
                 AND m."Ad_type_code" = NVL (adtyp, m."Ad_type_code")
                 AND i."Insert_Date" BETWEEN fromdate AND dateto
                 AND i.bill_no IS NULL
                 AND m."Uom_code" = NVL (p_uom, m."Uom_code")
                 AND i."Pai_Free_Ins" = 'N'
                 AND LOWER (i."Insert_Status") != 'cancel'
                 AND LOWER (i."Insert_Status") != 'hold'
                 AND m."cio_booking_id" NOT IN (
                        SELECT DISTINCT "Cio_Booking_Id"
                                   FROM tbl_booking_mast m,
                                        tbl_booking_insert i
                                  WHERE m."cio_booking_id" =
                                                            i."Cio_Booking_Id"
                                    AND "Insert_Date" < '1-may-2012'
                                    AND m."Uom_code" = 'RO0')) x;
   END IF;

   OPEN p_accounts4 FOR
      SELECT SYSDATE, INITCAP ("Comp_Name") AS "COMP_NAME",
             NVL (v_billed, 0) AS "ALREADY_BILLED",
             NVL (v_booked_by_others, 0) AS "BOOKED_BY_OTHERS",
             NVL (v_direct_cash, 0) AS "DIRECT_CASH",
             (NVL (v_fmg_ads, 0) + NVL (v_scheme_ads, 0)) AS "SCHEME_ADS"
        FROM comp_mst
       WHERE "Comp_Code" = compcode;

   DELETE FROM multipage_break
         WHERE sess_id = USERENV ('sessionid');

   COMMIT;
END schedulereport_checklist;
/




========end=======avinash by sumit dhama sir======================================








////////////////////////START//////////////////SHIPRA//////22-AUG////////////////////////


CREATE OR REPLACE PACKAGE HT18JULY.Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/
















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
                cir_wieght_calc_req, gen_rct_typ, product_brand_req, ALLOWPREM_CARD_DISC_RATE,FINANCE_CADE,
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
	CIR_ALLOW_HOLIDAY_SAT
           FROM preferrences
          WHERE "comp_code" = compcode;
   END currbindpreferpgld_p;
END currbindpreferpgld;
/















/////////////////////////////////////////////////////////////










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
p_financecode in varchar2
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
p_financecode in varchar2

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
=P_GEN_RCT_TYP,PRODUCT_BRAND_REQ=P_misdata,ALLOWPREM_CARD_DISC_RATE=P_allowpremium,FINANCE_CADE=p_financecode


  WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/
















CREATE OR REPLACE PACKAGE HT18JULY.Websp_Loginemployee IS

TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE Websp_Loginemployee_P (Vusername IN VARCHAR2 ,vpassword IN VARCHAR2 ,vqbc IN VARCHAR2, P_Accounts OUT T_Accounts_Cursor,
P_Accounts1 OUT T_Accounts_Cursor,
P_Accounts2 OUT T_Accounts_Cursor);


END Websp_Loginemployee;
/





CREATE OR REPLACE PACKAGE BODY HT18JULY.Websp_Loginemployee
IS

--var a refcursor;
--var b refcursor;
--var c refcursor;
--exec websp_loginemployee.websp_loginemployee_p('bh01','123','',:a,:b,:c);
    PROCEDURE Websp_Loginemployee_P (Vusername IN VARCHAR2 ,vpassword IN VARCHAR2 ,vqbc IN VARCHAR2,
        P_Accounts OUT T_Accounts_Cursor,
        P_Accounts1 OUT T_Accounts_Cursor,
        P_Accounts2 OUT T_Accounts_Cursor)
    AS
        vuserid VARCHAR2(100);
        v_nm varchar2(100);
        COUNT VARCHAR2(100);
    BEGIN
        IF Vqbc IS NULL THEN
        OPEN P_Accounts FOR
        SELECT "username","password","userid","date_format","COM_CODE","Autogenerate","curr_code","comp_name",
        to_date(sysdate)-to_date(CREATION_DATETIME) as "diff",DISCOUNT,FILTER,ROLEID,"retainer_code" AS RETAINER FROM LOGIN
        WHERE "userid"=Vusername  AND "password"=Vpassword and STATUS !='I';

        OPEN P_Accounts1 FOR SELECT "rate_gr_code","autogenerated","currency_code","date_format","solo","No_of_Decimal",
        "breakup","blackwhitecode","uom_code","rostatus","Tfn","Insert_breakup","Premium_type","Deal_type"     ,
        "prefix","suffix","financestatus","voucherst","Ad_category","Ro_datetime","Space_area","Vat","Booking_status","Cio_id","Receipt_no","Bgcolor_publication", "chkfor_valid_pubdates","Agency_ratecode","audit","copy_booking","RATE_COMPANY_AGENCY","SUBEDITIONRATE","ADDITIONAL_AGENCY_COMM","AGENCY_RETAINER_COMM",

        "invoice_no","rate_audit",CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT, RATE_CHECK, ALL_PACKAGE,DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,ROKEYCHECK,
  DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF,       
        FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,DISP_AUDITBKG, CIR_AUTO_PHYSICAL_UNSOLD,ALLOW_FOLLOW_DT_BOOOK,CIR_BARCODE,CIR_WIEGHT_CALC_REQ,AD_COLL_AUTO_TFR_FIN
        FROM PREFERRENCES WHERE "comp_code"=(SELECT "COM_CODE" FROM LOGIN WHERE "userid"=Vusername AND "password"=Vpassword);
       
        BEGIN
              SELECT "COM_CODE","username" INTO COUNT,v_nm FROM LOGIN WHERE "userid"=vusername AND "password"=vpassword;
              EXCEPTION WHEN NO_DATA_FOUND THEN NULL;
        END;
     
      -- Using Userid,UserNAme & User MAchine ID For Log Purpose
          sec_user.set_userid(vusername);
          sec_user.set_username(v_nm);
          sec_user.set_userip('');
      -- Using Userid,UserNAme & User MAchine ID For Log Purpose    

    OPEN P_Accounts2 FOR
    SELECT "Company_user","Admin" FROM LOGIN WHERE "userid"=Vusername;

ELSE
    OPEN P_Accounts FOR SELECT "username","password","userid","date_format","COM_CODE","Autogenerate","curr_code","comp_name",to_date(sysdate)-to_date(CREATION_DATETIME) as "diff", DISCOUNT,FILTER,ROLEID,"retainer_code" AS RETAINER FROM LOGIN
    WHERE "userid"=Vusername AND "password"=Vpassword AND ("retainer_code"=Vqbc) and STATUS !='I'/* or "retainer_code" in(select BRANCH_CODE from login_branch_mast where BRANCH_CODE =Vqbc and USER_CODE=Vusername and USER_FLAG='Y') )*/ and "Company_user" is null;

OPEN P_Accounts1 FOR SELECT "rate_gr_code","autogenerated","currency_code","date_format","solo","No_of_Decimal",
"breakup","blackwhitecode","uom_code","rostatus","Tfn","Insert_breakup","Premium_type","Deal_type"     ,
"prefix","suffix","financestatus","voucherst","Ad_category","Ro_datetime","Space_area","Vat","Booking_status","Cio_id","Receipt_no","Bgcolor_publication", "chkfor_valid_pubdates","Agency_ratecode","audit","copy_booking","RATE_COMPANY_AGENCY","SUBEDITIONRATE","ADDITIONAL_AGENCY_COMM","AGENCY_RETAINER_COMM",
"invoice_no","rate_audit",CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT, RATE_CHECK, ALL_PACKAGE, DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,ROKEYCHECK,

DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF ,FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,DISP_AUDITBKG,CIR_AUTO_PHYSICAL_UNSOLD,ALLOW_FOLLOW_DT_BOOOK

,CIR_BARCODE,CIR_WIEGHT_CALC_REQ,
AD_COLL_AUTO_TFR_FIN,FINANCE_CADE
FROM PREFERRENCES  WHERE "comp_code"=(SELECT "COM_CODE" FROM LOGIN WHERE "userid"=Vusername AND "password"=Vpassword);
BEGIN
SELECT "COM_CODE","username" INTO COUNT,v_nm FROM LOGIN WHERE "userid"=vusername AND "password"=vpassword AND "retainer_code"=vqbc;
EXCEPTION WHEN NO_DATA_FOUND THEN NULL;
END;

      -- Using Userid,UserNAme & User MAchine ID For Log Purpose
          sec_user.set_userid(vusername);
          sec_user.set_username(v_nm);
          sec_user.set_userip('');
      -- Using Userid,UserNAme & User MAchine ID For Log Purpose

OPEN P_Accounts2 FOR
SELECT "Company_user","Admin" FROM LOGIN WHERE "userid"=Vusername;
END IF;

 

END Websp_Loginemployee_P;

END Websp_Loginemployee;
/
////////////////////////////END///////////////////SHIPRA///////////////22-AUG///////////


========start===8359====avinash=24/08/2012======================================
CREATE OR REPLACE PROCEDURE HT18JULY.getmatterlog
(

ptable IN VARCHAR2,
puserid IN VARCHAR2,
pfrmdt IN VARCHAR2,
ptdat IN VARCHAR2,
pbukid in VARCHAR2,
P_Accounts OUT Cur_Type_New1.cursor_type

)


IS
v_query     VARCHAR(8000);

BEGIN
    if puserid is not null then
        v_query:=' select CIOID,MATTER_FILENAME ,MATTER,LANG,(select "username" from login where "userid"='|| ptable ||'.CREATED_BY) as CREATED_BY,CREATED_DATE,UPDATED_BY,UPDATED_DATE,LOG_DATE from '|| ptable ||'  where "UPDATED_BY"='''|| puserid ||''' AND LOG_DATE   BETWEEN ''' || pfrmdt ||'''  and  ''' ||ptdat||'''and ("CIOID"='''|| pbukid||''' or '''|| pbukid||'''  is null) '  ;
    else
        v_query:=' select  CIOID,MATTER_FILENAME ,MATTER,LANG,(select "username" from login where "userid"='|| ptable ||'.CREATED_BY) as CREATED_BY ,CREATED_DATE,UPDATED_BY,UPDATED_DATE,LOG_DATE from '|| ptable ||'  where LOG_DATE   BETWEEN ''' || pfrmdt ||'''  and  ''' ||ptdat||''' and ("CIOID"='''|| pbukid||''' or '''|| pbukid||'''  is null) '  ;
    end if;            


OPEN p_accounts FOR v_query;
END ;
/


========end===8359====avinash=24/08/2012======================================


========start===8031====avinash=24/08/2012======================================

CREATE OR REPLACE PROCEDURE HT18JULY.daily_booking_report(
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
    pextra1         in  varchar2:=null,--for UOM
    pextra2         in  varchar2:=null,--for created by 
    pextra3         in  varchar2:=null,--for state
    pextra4         in  varchar2:=null,--for district
    pextra5         in  varchar2:=null,--for city
    p_Accounts     OUT Cur_Type_New1.cursor_type)
IS

center      VARCHAR(50);
from_date   DATE;
date_to     DATE;
v_query     VARCHAR(8000);
a           number;
BEGIN
    v_query:=' select distinct x.cioid AS "CIOID",x.bkdate as bkdate,
    x.agency_sub_code agency_sub_code,x.agency_name agency_name,x.ag_city as ag_city,
    x.ro_no ro_no,x.ro_date ro_date,
    x."Client" AS "Client",
    x."Package" AS "Package",
    x."uom" as "uom",x."Color_code" AS "Color_code",
    x."BulletPremium" AS "BulletPremium" ,
    x."RoStatus" AS "RoStatus",
    x."AdCat" AS "AdCat",
    x."CardRate" AS "CardRate",x."AgreedRate" AS "AgreedRate",x."Amt" AS "Amt",x."Cap" AS "Cap",
    x."Key" AS "Key",x."companyname" AS "companyname",
    x."Rundate" as "Rundate",x."Cash_Disc" as "Cash_Disc", x."COMMENT" as "COMMENT",x.dockit_no as "DOCKIT_NO",
    min(bi."Insert_Date") fisrt_pubdt,max(bi."Insert_Date") last_pubdt ,max(bi."No_Insert") no_of_insdertion,
    x."date_time" , x."booked_by"
    from
    (select distinct m."cio_booking_id" AS "CIOID",m."date_time" as bkdate,
    m."Agency_sub_code" agency_sub_code,a."Agency_Name"  agency_name,(select "City_Name" from city_mst where "City_Code"=a."City_Code") as ag_city,
    m."RO_No" ro_no,m."RO_Date" ro_date,
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
    case when instr(m."Package_code",'','') >0 then 
        FETCH_PACK_new('''||compcode||''', m."Package_code" ) 
    else
        (select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=m."Package_code")
    end AS "Package",
    (select uom_mast.UOM_DESC from uom_mast where m."Uom_code"=uom_mast."Uom_Code")as "uom",i."Col_Code" AS "Color_code",
    m."Bullet_code" AS "BulletPremium" ,
    CASE m."ro_status" WHEN ''2'' THEN ''Reservation'' WHEN ''1'' THEN ''Confirm'' END AS "RoStatus",
    (SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=m."Ad_cat_code") AS "AdCat",
    m."Card_rate" AS "CardRate",NVL(m."Agrred_rate",0) AS "AgreedRate",m."Bill_amount" AS "Amt",m."Caption" AS "Cap",
    m."Key_no" AS "Key",(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
    sysdate as "Rundate",m.CASHDISCOUNT as "Cash_Disc", m."AUDIT_COMMENT" as "COMMENT",m."Dockit_no" as "DOCKIT_NO",
    m."date_time" , m."booked_by"
    FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a
    WHERE m."Comp_code"='''||compcode||''' AND m."cio_booking_id"=i."Cio_Booking_Id"
    AND m."Agency_code"=a."Agency_Code"  and m."Agency_sub_code"=a."code_subcode"
    AND m."cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
    and  lower(i."Insert_Status") !=''cancel''
    and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where  newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
    or  ('''||chk_access||'''=''0'') )';

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

IF(pextra1 IS NOT NULL) THEN
    v_query:=v_query||'  and m."Uom_code"='''||pextra1||'''';
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

IF(pextra2 IS NOT NULL) THEN
    v_query:=v_query||'  and m."Userid"='''||pextra2||'''';
END IF;

IF(pextra3 IS NOT NULL) THEN
    v_query:=v_query||'  and a.STATE ='''||pextra3||'''';
END IF;

IF(pextra4 IS NOT NULL) THEN
    v_query:=v_query||'  and a.DISTRICT ='''||pextra4||'''';
END IF;

IF(pextra5 IS NOT NULL) THEN
    v_query:=v_query||'  and a."City_Code" ='''||pextra5||'''';
END IF;

v_query:=v_query||')x, tbl_booking_insert bi where x.CIOID=bi."Cio_Booking_Id" 
        group by x.cioid ,x.bkdate,x.agency_sub_code ,x.agency_name,x.ag_city,
    x.ro_no,x.ro_date,x."Client",x."Package",x."uom",x."Color_code",
    x."BulletPremium", x."RoStatus", x."AdCat", x."CardRate",x."AgreedRate",x."Amt",x."Cap",
    x."Key",x."companyname",x."Rundate",x."Cash_Disc", x."COMMENT",x.dockit_no,x."date_time" , x."booked_by"';

IF(descid IS NOT  NULL) THEN
    v_query:=v_query||'  order by "'||descid||'"';
    v_query:=v_query||''||ascdesc||'';
ELSE
    v_query:=v_query||'  order by bkdate,cioid';
END IF;

delete from searchtbl;insert into searchtbl values(v_query,'','');commit;

OPEN p_Accounts FOR v_query;

END daily_booking_report;
/

========end===8031====avinash=24/08/2012======================================

