/////////start by shipra/////////////////////////////////////


                                             
ALTER PROCEDURE [dbo].[Schedulereport1](
@fromdate               VARCHAR(50) ,
@dateto                 VARCHAR(50) ,
@compcode               VARCHAR(50) ,
@pub_name               VARCHAR(50) ,
@pub_cent               VARCHAR(50) ,
@dateformat             VARCHAR(50) ,
@descid                 VARCHAR(50)= null ,
@ascdesc                VARCHAR(50)= null ,
@adtyp                  VARCHAR(400) ,
@adcatg                 VARCHAR(400) ,
@edition_name           VARCHAR(50) ,
@drpstatus              VARCHAR(50) ,
@supplement_name        VARCHAR(50),
@packagecode varchar(50),
@editiondtl varchar(50),
@puserid	varchar(50),
@chk_access	varchar(2),
@ro_statusres	varchar(2),
@p_branch	varchar(50),
@P_designer varchar(200)
) 
AS 
CREATE TABLE #MULTIPACK_RAT(CIOID VARCHAR(500),RAT VARCHAR(500),PER_AMT numeric(12,2)) 
--CREATE TABLE #MULTIPACK_RATNEW (CIOID VARCHAR(500),RAT VARCHAR(500),PER_AMT numeric(12,2))
CREATE TABLE #MULTIPACK_REP(CIOID  VARCHAR(500),PACK  VARCHAR(500))
CREATE TABLE #MULTIPAGE_BREK(TOT  int,PACK  VARCHAR(500))

BEGIN
DECLARE @query1       VARCHAR(8000) 
DECLARE @v_gau        FLOAT                           
SET @v_gau = 17 
DECLARE @v_val        NUMERIC(4) 
DECLARE @vs_gau       NUMERIC(4) 

DECLARE p1 Cursor LOCAL FOR 
SELECT  i.Edition as "edition", COUNT(*) as "tot"
FROM TBL_BOOKING_MAST m, TBL_BOOKING_INSERT i, AGENCY_MAST a, COL_MAST c, UOM_MAST u
WHERE m.Comp_code  = @compcode AND m.cio_booking_id  = i.Cio_Booking_Id
AND m.Agency_sub_code  = a.code_subcode
AND i.Col_Code  = c.Col_Code
AND u.Uom_Code  = m.Uom_code
AND i.Insert_Date  BETWEEN @fromdate  AND  @dateto
 
AND i.Publication_Code  = isnull(@pub_name,i.Publication_Code)
AND i.Pub_Cent_Code = isnull(@pub_cent,i.Pub_Cent_Code)
AND m.Ad_type_code  = isnull(@Adtyp,m.Ad_type_code)
AND (i.Ad_Cat= @adcatg OR @adcatg  is null)
AND i.Edition_Code  = isnull(@edition_name,i.Edition_Code)
AND (i.Supp_Code  = @supplement_name  OR	@supplement_name  is null)
AND (m."branch"  = @p_branch  OR	@p_branch  is null)
and   (@packagecode in (m.Package_code) or @packagecode is null)
and ((i.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access='1')
or  (@chk_access='0') )
and m.cio_booking_id not in (select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)

and ((@drpstatus ='includecancel' and  lower("Insert_Status") !='hold') 
   or (@drpstatus ='includehold' and lower("Insert_Status") !='cancel')
   or (@drpstatus ='cancel' and lower("Insert_Status") !='cancel' and lower("Insert_Status") !='hold') )
GROUP BY  i.Edition 
ORDER BY i.Edition 
DECLARE @g1_edition  VARCHAR(200) 
declare @g1_tot varchar(200)

DECLARE C1 Cursor LOCAL FOR 
SELECT DISTINCT i.Cio_Booking_Id AS "CIOID", m.Package_code as package_code,
m.Gross_amount as Crate
FROM  TBL_BOOKING_MAST m, TBL_BOOKING_INSERT i
WHERE m.Comp_code=@compcode AND m.cio_booking_id=i.Cio_Booking_Id
AND i.Insert_Date BETWEEN @fromdate AND @dateto
AND i.Publication_Code  = isnull(@pub_name,i.Publication_Code)
AND i.Pub_Cent_Code = isnull(@pub_cent,i.Pub_Cent_Code)
AND m.Ad_type_code  = isnull(@Adtyp,m.Ad_type_code)
AND (i.Ad_Cat=@adcatg or @adcatg is null)
AND i.Edition_Code  = isnull(@edition_name,i.Edition_Code)
AND (i.Supp_Code =@supplement_name or @supplement_name is null)
AND m."branch"  = isnull(@p_branch,m."branch")
and (@packagecode in (m.Package_code) or @packagecode is null)
and ((i.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access='1')
or  (@chk_access='0') )
and m.cio_booking_id not in (select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)

DECLARE @v1_cioid  VARCHAR(200)
declare @v1_package_code varchar(200) 
declare @v1_crate float

DECLARE C2 Cursor LOCAL FOR 
SELECT DISTINCT Edition	FROM  TBL_BOOKING_INSERT WHERE Cio_Booking_Id  = @v1_cioid
DECLARE @v_edition    VARCHAR(100) 
DECLARE @v_edipkg     VARCHAR(500) 
--DELETE  temp_edi  
--DELETE FROM  MULTIPAGE_BREAK
delete from #multipage_brek

OPEN p1 
DECLARE @count	INT 
SET @count = 1 
fetch NEXT FROM p1 INTO @g1_edition,@g1_tot
WHILE (@@FETCH_STATUS != -1) BEGIN
insert into #multipage_brek SELECT  * from dbo.multipage_brek(@g1_edition, @g1_tot, @v_gau) --@vs_gau  =	
SET @count=@count +1
fetch NEXT FROM p1 INTO @g1_edition,@g1_tot
END
close p1
  
delete from #MULTIPACK_REP	
delete from #MULTIPACK_RAT
OPEN c1 
SET @count = 1 
fetch NEXT FROM c1 INTO @v1_cioid,@v1_package_code,@v1_crate
WHILE (@@FETCH_STATUS != -1) BEGIN 
--exec multipack_report @v1_cioid, @v1_package_code, @v1_crate, '1'
insert into #MULTIPACK_REP select * from dbo.multipack_report1(@v1_cioid, @v1_package_code, @v1_crate, '1')
insert into #MULTIPACK_RAT select * from dbo.multipack_report3(@v1_cioid, @v1_package_code, @v1_crate, '1')
OPEN C2 
SET @count = 1 
fetch NEXT FROM C2 INTO	@v_edition
WHILE (@@FETCH_STATUS != -1) BEGIN 
IF @v_edipkg is null BEGIN 
SET @v_edipkg  = @v_edition 
END
ELSE BEGIN 
SET @v_edipkg  = @v_edipkg + ',' + @v_edition 
END
   
SET @count=@count +1
fetch NEXT FROM C2 INTO	@v_edition
END
close C2
SET @v_edition  = null 
SET @v_edipkg  = null 
SET @count=@count +1	
fetch NEXT FROM c1 INTO @v1_cioid,@v1_package_code,@v1_crate
end	
close c1	

---------------------- Changes done by gaurav 14 june 10-------------------------------------------
if (@packagecode is null or @editiondtl ='1') begin
print('1')
IF ( @drpstatus = 'includecancel'  or @drpstatus ='includehold') BEGIN 
print('2')
SET @query1  = 'SELECT TBL_BOOKING_MAST.cio_booking_id AS "CIOID", AGENCY_MAST.Agency_Name AS "Agency", 
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code and cust_mast.comp_code=tbl_booking_mast.comp_code),Client_code)  AS "Client", 
#multipack_rep.PACK  AS "Package", COL_MAST.Col_Alias AS "Hue", TBL_BOOKING_MAST.Card_rate AS "CardRate",
isnull(Agrred_rate,TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", 
case when tbl_booking_mast.ad_type_code=''CL0'' then
       tbl_booking_insert.caption
    else
   TBL_BOOKING_MAST.Caption 
end as "Caption", 
TBL_BOOKING_MAST.Key_no as "Key_no", TBL_BOOKING_INSERT.Edition as "edition", TBL_BOOKING_MAST.RO_No as "RO_No",
(SELECT ADVPOS_PREM_MAST.Premiumcode FROM ADVPOS_PREM_MAST WHERE TBL_BOOKING_INSERT.Premium1=ADVPOS_PREM_MAST.Premiumcode AND TBL_BOOKING_INSERT.Col_Code= ADVPOS_PREM_MAST.col_code and tbl_booking_insert.comp_code=ADVPOS_PREM_MAST.comp_code) AS PagePremium,
(SELECT ADVPOS_TYPE_MAST.Pos_Type_Code FROM ADVPOS_TYPE_MAST WHERE TBL_BOOKING_INSERT.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code  and tbl_booking_insert.comp_code=ADVPOS_TYPE_MAST.comp_code) AS "PosPremium", 
round(TBL_BOOKING_insert.Size_Book,2)  AS "Area", TBL_BOOKING_MAST.Bill_remarks AS "Spl Instruction", 
CASE ''' + @dateformat + '''  WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),Insert_Date,101)  
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),Insert_Date,103)  
WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),Insert_Date,112)  END AS "Ins.date" ,
tbl_booking_insert.Width  AS "Width",  tbl_booking_insert.Height AS "Depth",
(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=tbl_booking_insert.Ad_Cat and tbl_booking_insert.comp_code=ADV_CAT_MAST.comp_code) as "Adcat", 
(select ADV_SUBCAT_MAST.Adv_Subcat_Name FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST.Adv_Subcat_Code=tbl_booking_insert.Ad_Sub_Cat  and tbl_booking_insert.comp_code=ADV_SUBCAT_MAST.comp_code) AS "AdSubcat", 
(select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3",
TBL_BOOKING_INSERT.Page_No as "Pageno", TBL_BOOKING_MAST.Paid_ins as "Paidins",  
TBL_BOOKING_MAST.Rate_code as ratecd, UOM_MAST.Uom_Name  AS "Uom",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast.Uom_code=uom_mast.Uom_Code and uom_mast.comp_code=tbl_booking_mast.comp_code)as "uomdesc" 
,TBL_BOOKING_MAST.Booking_type AS "booktype"   ,tbl_booking_mast.audit as "audit"	
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT",
(select distinct "Branch_Name" from branch_mst where "Branch_Code"=TBL_BOOKING_MAST."branch") as "BRANCH_NAME"
,dbo.AD_GET_CITYNAME(TBL_BOOKING_MAST."Comp_code",AGENCY_MAST."City_Code") CITY_NAME
FROM TBL_BOOKING_MAST,
TBL_BOOKING_INSERT,AGENCY_MAST,#multipack_rep,COL_MAST,UOM_MAST  
WHERE TBL_BOOKING_MAST.Comp_code=''' + @compcode + '''
AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id 
AND  TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode
AND  TBL_BOOKING_insert.Col_Code=COL_MAST.Col_Code 
AND UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code 
and #multipack_rep.CIOID=tbl_booking_mast.cio_booking_id
and tbl_booking_mast.cio_booking_id not in (select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)
and (('''+@drpstatus+''' =''includecancel'' and  lower(Insert_Status) !=''hold'') or ('''+@drpstatus+''' =''includehold'' and lower(Insert_Status) !=''cancel''))
and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )' 
END
ELSE BEGIN 
print ('3')

SET @query1  = 'SELECT TBL_BOOKING_MAST.cio_booking_id AS "CIOID", AGENCY_MAST.Agency_Name AS "Agency", 
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code and cust_mast.comp_code=tbl_booking_mast.comp_code),Client_code)  AS "Client", 
#multipack_rep.PACK  AS "Package", COL_MAST.Col_Alias AS "Hue", TBL_BOOKING_MAST.Card_rate AS "CardRate",
isnull(Agrred_rate,TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", 
case when tbl_booking_mast.ad_type_code=''CL0'' then
       tbl_booking_insert.caption
    else
   TBL_BOOKING_MAST.Caption 
end as "Caption", 
TBL_BOOKING_MAST.Key_no as "Key_no", TBL_BOOKING_INSERT.Edition as "edition", TBL_BOOKING_MAST.RO_No as "RO_No",
(SELECT ADVPOS_PREM_MAST.Premiumcode FROM ADVPOS_PREM_MAST WHERE TBL_BOOKING_INSERT.Premium1=ADVPOS_PREM_MAST.Premiumcode AND TBL_BOOKING_INSERT.Col_Code= ADVPOS_PREM_MAST.col_code and tbl_booking_insert.comp_code=ADVPOS_PREM_MAST.comp_code) AS PagePremium,
(SELECT ADVPOS_TYPE_MAST.Pos_Type_Code FROM ADVPOS_TYPE_MAST WHERE TBL_BOOKING_INSERT.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code  and tbl_booking_insert.comp_code=ADVPOS_TYPE_MAST.comp_code) AS "PosPremium", 
round(TBL_BOOKING_insert.Size_Book,2)  AS "Area", TBL_BOOKING_MAST.Bill_remarks AS "Spl Instruction", 
CASE ''' + @dateformat + '''  WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),Insert_Date,101)  
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),Insert_Date,103)  
WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),Insert_Date,112)  END AS "Ins.date" ,
tbl_booking_insert.Width  AS "Width",  tbl_booking_insert.Height AS "Depth",
(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=tbl_booking_insert.Ad_Cat and tbl_booking_insert.comp_code=ADV_CAT_MAST.comp_code) as "Adcat", 
(select ADV_SUBCAT_MAST.Adv_Subcat_Name FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST.Adv_Subcat_Code=tbl_booking_insert.Ad_Sub_Cat  and tbl_booking_insert.comp_code=ADV_SUBCAT_MAST.comp_code) AS "AdSubcat",
(select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3",
TBL_BOOKING_INSERT.Page_No as "Pageno", TBL_BOOKING_MAST.Paid_ins as "Paidins",  
TBL_BOOKING_MAST.Rate_code as ratecd, UOM_MAST.Uom_Name  AS "Uom",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast.Uom_code=uom_mast.Uom_Code and uom_mast.comp_code=tbl_booking_mast.comp_code)as "uomdesc" 
,TBL_BOOKING_MAST.Booking_type AS "booktype"   ,tbl_booking_mast.audit as "audit"	
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT",
(select distinct "Branch_Name" from branch_mst where "Branch_Code"=TBL_BOOKING_MAST."branch") as "BRANCH_NAME"
,dbo.AD_GET_CITYNAME(TBL_BOOKING_MAST."Comp_code",AGENCY_MAST."City_Code") CITY_NAME,
sectioncode
FROM TBL_BOOKING_MAST,
TBL_BOOKING_INSERT,AGENCY_MAST,#multipack_rep,COL_MAST,UOM_MAST  
WHERE TBL_BOOKING_MAST.Comp_code=''' + @compcode + '''
AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id 
AND  TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode
AND  TBL_BOOKING_insert.Col_Code=COL_MAST.Col_Code 
AND UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code 
and #multipack_rep.CIOID=tbl_booking_mast.cio_booking_id
and tbl_booking_mast.cio_booking_id not in (select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)	
and lower(Insert_Status) !=''cancel''
and lower(Insert_Status) !=''hold''
and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )' 
END
end
else begin
print('4')
IF ( @drpstatus = 'includecancel'  or @drpstatus ='includehold') BEGIN
print ('5')
SET @query1  = 'SELECT distinct TBL_BOOKING_MAST.cio_booking_id AS "CIOID", AGENCY_MAST.Agency_Name AS "Agency", 
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code and cust_mast.comp_code=tbl_booking_mast.comp_code),Client_code)  AS "Client", 
#multipack_rep.PACK  AS "Package", COL_MAST.Col_Alias AS "Hue", TBL_BOOKING_MAST.Card_rate AS "CardRate",
isnull(TBL_BOOKING_MAST.Agrred_rate, TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", 
case when tbl_booking_mast.ad_type_code=''CL0'' then
       tbl_booking_insert.caption
    else
   TBL_BOOKING_MAST.Caption 
end as "Caption", 
TBL_BOOKING_MAST.Key_no as "Key_no", TBL_BOOKING_MAST.RO_No as "RO_No",
(SELECT ADVPOS_PREM_MAST.Premiumcode FROM ADVPOS_PREM_MAST WHERE TBL_BOOKING_INSERT.Premium1=ADVPOS_PREM_MAST.Premiumcode AND TBL_BOOKING_INSERT.Col_Code= ADVPOS_PREM_MAST.col_code and tbl_booking_insert.comp_code=ADVPOS_PREM_MAST.comp_code) AS PagePremium,
(SELECT ADVPOS_TYPE_MAST.Pos_Type_Code FROM ADVPOS_TYPE_MAST WHERE TBL_BOOKING_INSERT.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code  and tbl_booking_insert.comp_code=ADVPOS_TYPE_MAST.comp_code) AS "PosPremium", 
round(TBL_BOOKING_insert.Size_Book,2)  AS "Area", TBL_BOOKING_MAST.Bill_remarks AS "Spl Instruction", 
CASE ''' + @dateformat + '''  WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),Insert_Date,101)  
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),Insert_Date,103)  
WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),Insert_Date,112) 
END AS "Ins.date" ,
tbl_booking_insert.Width  AS "Width",
tbl_booking_insert.Height AS "Depth",
(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=tbl_booking_insert.Ad_Cat and tbl_booking_insert.comp_code=ADV_CAT_MAST.comp_code) as "Adcat", 
(select ADV_SUBCAT_MAST.Adv_Subcat_Name FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST.Adv_Subcat_Code=tbl_booking_insert.Ad_Sub_Cat  and tbl_booking_insert.comp_code=ADV_SUBCAT_MAST.comp_code) AS "AdSubcat",
(select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3", 
TBL_BOOKING_INSERT.Page_No as "Pageno", TBL_BOOKING_MAST.Paid_ins as "Paidins",  
TBL_BOOKING_MAST.Rate_code as ratecd, UOM_MAST.Uom_Name  AS "Uom"
,(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and uom_mast.comp_code=tbl_booking_mast.comp_code)as "uomdesc"
,TBL_BOOKING_MAST.Booking_type AS "booktype"   ,tbl_booking_mast.audit as "audit"	
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT",
(select distinct "Branch_Name" from branch_mst where "Branch_Code"=TBL_BOOKING_MAST."branch") as "BRANCH_NAME"
,dbo.AD_GET_CITYNAME(TBL_BOOKING_MAST."Comp_code",AGENCY_MAST."City_Code") CITY_NAME
FROM TBL_BOOKING_MAST,
TBL_BOOKING_INSERT,AGENCY_MAST,#multipack_rep,COL_MAST,UOM_MAST  
WHERE TBL_BOOKING_MAST.Comp_code=''' + @compcode + '''AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id 
AND  TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND  TBL_BOOKING_insert.Col_Code=COL_MAST.Col_Code 
AND UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and #multipack_rep.CIOID=tbl_booking_mast.cio_booking_id	
and tbl_booking_mast.cio_booking_id not in (select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)
and  (('''+@drpstatus+''' =''includecancel'' and  lower(Insert_Status) !=''hold'') or ('''+@drpstatus+''' =''includehold'' and lower(Insert_Status) !=''cancel''))
and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )' 
END
ELSE BEGIN 
print('7')	
SET @query1 = 'SELECT distinct TBL_BOOKING_MAST.cio_booking_id AS "CIOID", AGENCY_MAST.Agency_Name AS "Agency", 
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code and cust_mast.comp_code=tbl_booking_mast.comp_code),Client_code)  AS "Client", 
#multipack_rep.PACK  AS "Package", COL_MAST.Col_Alias AS "Hue", TBL_BOOKING_MAST.Card_rate AS "CardRate",
isnull(TBL_BOOKING_MAST.Agrred_rate, TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", 
case when tbl_booking_mast.ad_type_code=''CL0'' then
       tbl_booking_insert.caption
    else
   TBL_BOOKING_MAST.Caption 
end as "Caption", 
TBL_BOOKING_MAST.Key_no as "Key_no", TBL_BOOKING_MAST.RO_No as "RO_No",
(SELECT ADVPOS_PREM_MAST.Premiumcode FROM ADVPOS_PREM_MAST WHERE TBL_BOOKING_INSERT.Premium1=ADVPOS_PREM_MAST.Premiumcode AND TBL_BOOKING_INSERT.Col_Code= ADVPOS_PREM_MAST.col_code and tbl_booking_insert.comp_code=ADVPOS_PREM_MAST.comp_code) AS PagePremium,
(SELECT ADVPOS_TYPE_MAST.Pos_Type_Code FROM ADVPOS_TYPE_MAST WHERE TBL_BOOKING_INSERT.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code  and tbl_booking_insert.comp_code=ADVPOS_TYPE_MAST.comp_code) AS "PosPremium", 
round(TBL_BOOKING_insert.Size_Book,2)  AS "Area", TBL_BOOKING_MAST.Bill_remarks AS "Spl Instruction", 
CASE ''' + @dateformat + '''  WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),Insert_Date,101)  
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),Insert_Date,103)  
WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),Insert_Date,112) 
END AS "Ins.date" ,
tbl_booking_insert.Width  AS "Width",
tbl_booking_insert.Height AS "Depth",
(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=tbl_booking_insert.Ad_Cat and tbl_booking_insert.comp_code=ADV_CAT_MAST.comp_code) as "Adcat", 
(select ADV_SUBCAT_MAST.Adv_Subcat_Name FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST.Adv_Subcat_Code=tbl_booking_insert.Ad_Sub_Cat  and tbl_booking_insert.comp_code=ADV_SUBCAT_MAST.comp_code) AS "AdSubcat", 
(select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3",
TBL_BOOKING_INSERT.Page_No as "Pageno", TBL_BOOKING_MAST.Paid_ins as "Paidins",  
TBL_BOOKING_MAST.Rate_code as ratecd, UOM_MAST.Uom_Name  AS "Uom"
,(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and uom_mast.comp_code=tbl_booking_mast.comp_code)as "uomdesc"
,TBL_BOOKING_MAST.Booking_type AS "booktype"   ,tbl_booking_mast.audit as "audit"	
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT",
(select distinct "Branch_Name" from branch_mst where "Branch_Code"=TBL_BOOKING_MAST."branch") as "BRANCH_NAME"
,dbo.AD_GET_CITYNAME(TBL_BOOKING_MAST."Comp_code",AGENCY_MAST."City_Code") CITY_NAME
FROM TBL_BOOKING_MAST,
TBL_BOOKING_INSERT,AGENCY_MAST,#multipack_rep,COL_MAST,UOM_MAST  
WHERE TBL_BOOKING_MAST.Comp_code=''' + @compcode + '''AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id 
AND  TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND  TBL_BOOKING_insert.Col_Code=COL_MAST.Col_Code 
AND UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and #multipack_rep.CIOID=tbl_booking_mast.cio_booking_id
and lower(Insert_Status) !=''cancel''
and lower(Insert_Status) !=''hold''
and tbl_booking_mast.cio_booking_id not in (select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)	
and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )' 

END
end

IF ( @fromdate IS NOT NULL AND @dateto IS NOT NULL ) BEGIN 
SET @query1  = @query1 + ' AND TBL_BOOKING_INSERT.Insert_Date BETWEEN ''' + @fromdate + ''' AND''' + @dateto + '''' 
END
   
IF ( @pub_name IS NOT NULL ) BEGIN 
SET @query1  = @query1 + ' AND TBL_BOOKING_INSERT.Publication_Code=''' + @pub_name + '''' 
END

IF ( @p_branch IS NOT NULL ) BEGIN 
SET @query1  = @query1 + ' AND TBL_BOOKING_mast.branch=''' + @p_branch + '''' 
END

IF ( @pub_cent IS NOT NULL ) BEGIN 
SET @query1  = @query1 + '  AND TBL_BOOKING_INSERT.Pub_Cent_Code=''' + @pub_cent + '''' 
END
   
IF ( @adtyp IS NOT NULL ) BEGIN 
SET @query1  = @query1 + 'AND TBL_BOOKING_MAST.Ad_type_code=''' + @adtyp + '''' 
END
   
IF ( @adcatg IS NOT NULL ) BEGIN 
SET @query1  = @query1 + 'AND  tbl_booking_insert.Ad_Cat in (''' + @adcatg + ''' )' 
END
   
IF ( @edition_name IS NOT NULL ) BEGIN 
SET @query1  = @query1 + '  AND TBL_BOOKING_INSERT.Edition_Code=''' + @edition_name + '''' 
END
   
IF ( @supplement_name IS NOT NULL ) BEGIN 
SET @query1  = @query1 + 'AND (TBL_BOOKING_insert.Supp_Code =''' + @supplement_name + ''' )' 
END

IF ( @ro_statusres IS NOT NULL ) BEGIN 
SET @query1  = @query1 + 'AND (TBL_BOOKING_MAST.ro_status =''' + @ro_statusres + ''' )' 
END
IF ( @P_designer IS NOT NULL ) BEGIN 
SET @query1  = @query1 + 'AND (TBL_BOOKING_insert.SECTIONCODE =''' + @P_designer + ''' OR '''+@P_designer+''' IS NULL OR '''+@P_designer+'''='''')' 
END
IF(@packagecode IS NOT NULL ) begin
SET @query1=@query1+' AND ('''+@packagecode+''' in (tbl_booking_mast.Package_code) )'
END 
   	
if(@packagecode is null) begin
IF ( @descid IS NOT NULL ) BEGIN 
SET @query1  = @query1 + '  order by "' + @descid + '"' 
if(@descid='edition')begin
SET @query1  = @query1 + '' + @ascdesc + '' + '  '
end
else begin
SET @query1  = @query1 + '' + @ascdesc + '' + ' ,TBL_BOOKING_INSERT.Edition '
end
END
ELSE BEGIN 
SET @query1  = @query1 + ' order by TBL_BOOKING_INSERT.Edition' 
END
end
else begin
IF ( @descid IS NOT NULL ) BEGIN 
SET @query1  = @query1 + '  order by "' + @descid + '"'
SET @query1  = @query1 + '' + @ascdesc + '' 
END
ELSE BEGIN 
SET @query1  = @query1 + 'order by TBL_BOOKING_MAST.cio_booking_id ' 
END
End
print(@query1)
EXEC(@query1) 
SELECT Edition_Alias as "Editions" FROM  edition_mast WHERE Pub_Code  = @pub_name AND Edition_Type  = 'Main Edition'

SELECT CASE @dateformat 
WHEN 'mm/dd/yyyy'  THEN CONVERT(VARCHAR(23), Insert_Date, 10)
WHEN 'dd/mm/yyyy'  THEN CONVERT(VARCHAR(23), Insert_Date, 5)
WHEN 'yyyy/mm/dd'  THEN CONVERT(VARCHAR(23), Insert_Date)
END as "Insdate",TBL_BOOKING_INSERT.Edition
FROM  TBL_BOOKING_INSERT 
WHERE TBL_BOOKING_INSERT.Edition in 
(SELECT Edition_Alias as "Editions" FROM  edition_mast WHERE	Pub_Code = @pub_name)
SELECT PACK,TOT FROM #MULTIPAGE_BREK ORDER BY PACK,TOT DESC
SELECT GETDATE(),dbo.initcap("Comp_Name") FROM  comp_mst WHERE Comp_Code  = @compcode
 DEALLOCATE p1
 DEALLOCATE C1
 DEALLOCATE C2

END

--select * from  #MULTIPAGE_BREK

drop table  #MULTIPACK_RAT
drop table  #MULTIPACK_REP
drop table  #MULTIPAGE_BREK




////////////////////end/////////////////////////////



////////////srart by shipra////////////////////////////////



/******************************************/
USE [THENIBERP]
GO
/****** Object:  StoredProcedure [dbo].[Reportnew1]    Script Date: 2/25/2013 10:49:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Reportnew1]
@agname        as    VARCHAR(500)=NULL,
@clientname        as    VARCHAR(500)=NULL,
@adtype1        as    VARCHAR(50),
@Adcategory        as    VARCHAR(500),
@Adsubcategory    as    VARCHAR(500),
 @fromdate        as    VARCHAR(20),
@dateto            as    VARCHAR(20),
@compcode        as  VARCHAR(10),
@pub_name        as    VARCHAR(200),
@pub_cent        as  VARCHAR(200),
@status            as    VARCHAR(50)=NULL,
 @edition        as    VARCHAR(100),
@dateformat        as    VARCHAR(20),
@hold            as    VARCHAR(20)=NULL,
@descid            as    VARCHAR(20)=NULL,
@ascdesc        as    VARCHAR(20)=NULL,
@agtype            as    varchar(20)=null,
 @puserid        as    varchar(10)=null,
@chk_access        as    varchar(2),
@pbranch        as    varchar(50)=null,
@pprint_center    as    varchar(50)=null,
@pwithout_rono  as  varchar(50)=null,--it is for without agency ro no. list Y or N or All
 @pdate_flag     as  varchar(5)=null,--it is used for booking date B or publish date P
@pextra1        as  varchar(50)=null,--for UOM
@pextra2        as  varchar(50)=null,
@pextra3        as  varchar(50)=null,
 @pextra4        as  varchar(50)=null,
@pextra5        as  varchar(50)=null
AS
declare @center            VARCHAR(50)
declare @from_date        DATETIME
declare @date_to        DATETIME
declare @v_query        VARCHAR(8000)
 declare @v_query1        VARCHAR(200)
declare @v_query2        VARCHAR(200)

BEGIN

create table #Results(SegmentNum INT, Edition_Name  VARCHAR(255))
create table #result_new(SegmentNum INT, Edition_Name  VARCHAR(255))
 insert into #Results select * from dbo.Fn_Splitfield(@Adcategory,',')
insert into #result_new select * from dbo.Fn_Splitfield_NEW(@Adsubcategory,',')


set    @v_query='SELECT m.cio_booking_id AS "CIOID",i.Edition as "edition",
 CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),i.Insert_Date,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),i.Insert_Date,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),i.Insert_Date,111)  END AS "Ins.date" ,
 a.Agency_Name AS "Agency",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=m.Client_code and CUST_MAST.comp_code=m.comp_code),m.Client_code)  AS "Client",
/*(select COMBIN_MAST.Package_Name from combin_mast where COMBIN_MAST.comp_code=m.comp_code and COMBIN_MAST.Combin_Code  in(m.Package_code))AS "Package",*/
 case when CHARINDEX('','', m."Package_code") >0 then 
    dbo.FETCH_PACK_new('''+@compcode+''', m."Package_code" ) 
else
    (select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=m."Package_code")
 end AS "Package",
i.Height AS "Depth",i.No_ofcolumn   AS "Width",
round(i.Size_Book,2) AS "Area",
(select uom_mast.UOM_DESC from uom_mast where m.Uom_code=uom_mast.Uom_Code and m.comp_code=uom_mast.comp_code)as "uom",
 i.Col_Code AS "Color_code",
(SELECT ADVPOS_TYPE_MAST.Pos_Type_Alias FROM ADVPOS_TYPE_MAST WHERE i.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code  and i.comp_code=ADVPOS_TYPE_MAST.comp_code) AS "Page",
 m.Bullet_code AS "BulletPremium" ,i.Page_Post AS "PositionPremium" ,i.Premium1 AS "PagePremium" ,
m.RO_No AS "RoNo.",CASE m.ro_status WHEN ''2'' THEN ''Reservation'' WHEN ''1'' THEN ''Confirm'' END AS "RoStatus",
 (SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=i.Ad_Cat and ADV_CAT_MAST.comp_code=i.comp_code) AS "AdCat",
m.Card_rate AS "CardRate",isnull(Agrred_rate,0) AS "AgreedRate",i.Bill_Amt AS "Amt",
CASE WHEN M.AD_TYPE_CODE=''CL0'' THEN
       I.Caption 
     ELSE
  M.CAPTION
END AS "Cap",Key_no AS "Key",
 (SELECT dbo.InitCap(Comp_Name) from comp_mst where Comp_Code='''+@compcode+''')  AS "companyname",
getdate() as "Rundate",CASHDISCOUNT as "Cash_Disc",m.AUDIT_COMMENT as "COMMENT",(select Exec_name from Exec_mast where Exe_no=m.Executive_code) as "DOCKIT_NO",
 case when no_insert=''1'' then ''Original''
else
''Repeat''
end as "ADSTATUS",m.booked_by as BOOKED_BY,CASE isnull(i.VATAMT,0)
WHEN 0 THEN CONVERT(varchar(10),i.Bill_Amt)
 else CONVERT(varchar(10),round((i.Bill_Amt-(i.Bill_Amt-(i.Bill_Amt/(1+(i.VATAMT/100))))),2))  END AS "GS"
FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a
 WHERE m.Comp_code='''+@compcode+''' AND m.cio_booking_id=i.Cio_Booking_Id
  AND m.Agency_code=a.Agency_Code and m.Agency_sub_code=a.code_subcode
 AND m.cio_booking_id not in(select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)
 and  lower(i.Insert_Status) !=''cancel''
 and ((i.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'') 
or  ('''+@chk_access+'''=''0'') )'
 

if(@pextra2 is not null and @pextra2 <> '' )begin
set @v_query=@v_query+' and i.cio_booking_id='''+@pextra2+''''
end 
if(@pextra3 is not null and @pextra3 <> '' )begin
 set @v_query=@v_query+' and i.PACKAGE_CODE='''+@pextra3+''''
end 
IF(@agname IS NOT NULL and @agname <> '') Begin
    set @v_query=@v_query+' and m.Agency_code ='''+@agname+''''
 END

IF(@clientname IS NOT NULL and @clientname <> '') Begin
    set @v_query=@v_query+' and m.Client_code='''+@clientname +''''
END

IF(@status IS NOT NULL and @status<>'') Begin
     set @v_query=@v_query+' and i.Insert_Status='''+@status+''''
END

IF(@adtype1 IS NOT NULL and @adtype1 <>'') Begin
    set @v_query=@v_query+' and m.Ad_type_code='''+@adtype1+''''
 END

IF(@Adcategory IS NOT NULL and @Adcategory<>'') Begin
    set @v_query=@v_query+' and i.Ad_Cat in(select EDITION_NAME from #Results  )'
    --set @v_query=@v_query+' and TBL_BOOKING_MAST.Ad_cat_code in('''+@Adcategory+''' )'
 END

IF(@Adsubcategory IS NOT NULL and @Adsubcategory<>'') Begin
    set @v_query=@v_query+' and m.Ad_sub_cat_code in(select EDITION_NAME from #result_new )'
    --set @v_query=@v_query+' and TBL_BOOKING_MAST.Ad_sub_cat_code in('''+@Adsubcategory+''' )'
 END

IF(@pub_cent IS NOT NULL and @pub_cent<>'') Begin
    set @v_query=@v_query+'  and i.Pub_Cent_Code='''+@pub_cent+''''
END

If @pdate_flag='B' Begin
 
if(@pextra2 ='' or @pextra2 is NULL)begin


    IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL ) Begin
        set @v_query=@v_query+' and m."date_time" between  '''+@fromdate +''' and  '''+@dateto+''' '
     END

    IF( @fromdate<>'' and @dateto<>'') Begin
        set @v_query=@v_query+' and m."date_time" between  '''+@fromdate +''' and  '''+@dateto+''' '
     END

end
End

If @pdate_flag='P' Begin

if(@pextra2 ='' or @pextra2 is NULL)begin
    IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL ) Begin
        set @v_query=@v_query+' and i.Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
     END

    IF( @fromdate<>'' and @dateto<>'') Begin
        set @v_query=@v_query+' and i.Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
     END
end
End




IF(@edition IS NOT NULL and @edition<>'' and @edition<>'--Select Edition Name--') Begin
    set @v_query=@v_query+'  and i.Edition_Code='''+@edition+''''
 END

IF(@pub_name IS NOT NULL and @pub_name<>'') Begin
    set @v_query=@v_query+' and  i.Publication_Code='''+@pub_name+''''
END

IF((@agtype IS NOT NULL and @agtype<>'') AND (@agtype <> 'Package') AND (@agtype <> 'Solo')) Begin
     set @v_query=@v_query+' and  m.Agency_type='''+upper(@agtype)+''''
END

if(@pprint_center is not null and @pprint_center<>'')Begin
    set @v_query=@v_query+' and m."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE m."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pprint_center+''')) '
 end 

if(@pbranch is not null and @pbranch<>'') Begin
    set @v_query=@v_query+' and m."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Code" ='''+@pbranch+''') '
 end 

if(@pwithout_rono='Y') Begin
    set @v_query=@v_query+' and (m."RO_No" is null or m."RO_No"='''') ';
End

if(@pwithout_rono='N') Begin
     set @v_query=@v_query+' and (m."RO_No" is not null or m."RO_No"<>'''') ';
End

IF(@pextra1 IS NOT NULL) begin
    set @v_query=@v_query+'  and m."Uom_code"='''+@pextra1+'''';
 END

IF(@descid IS NOT  NULL and @descid<>'') Begin
    set @v_query=@v_query+'  order by "'+@descid+'"'
    set @v_query=@v_query+''+@ascdesc+''
end
 ELSE Begin
    set @v_query=@v_query+'  order by i.Insert_Date,m.cio_booking_id'
END

print(@v_query)
exec(@v_query)

set @v_query='select EDITION_NAME from #Results '
set @v_query='select EDITION_NAME from #result_new '
 
print(@v_query1)
exec(@v_query1)
print(@v_query2)
exec(@v_query2)
end



/////////////////////end///////////////////////////////////////////////////////////
