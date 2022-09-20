/////////////////issue no-4797//////////////////////////
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





ALTER PROCEDURE [dbo].[report]
(
@agname varchar(50)=null,
@clientname varchar(50)=null,
@adtype varchar(50),
@adcategory varchar(50),
@fromdate varchar(50),
@dateto varchar(50),
@compcode varchar(10),
@pub_name varchar(50),
@pub_cent varchar(50),
@status varchar(50)=null,
@edition varchar(50),
@dateformat varchar(50),
@hold varchar(10)=null,
@descid varchar(50)=null,
@ascdesc varchar(50)=null


)
as 
declare @str  as varchar(3000)
declare @center  as varchar(50)



set @str='select TBL_BOOKING_MAST.cio_booking_id as "CIOID",AGENCY_MAST.agency_name as "Agency",isnull((select cust_name from CUST_MAST where cust_code=client_code),client_code)  as "Client",PUB_CENT_MAST.pub_cent_name as "City",
PUB_MAST.pub_name as "Pub",COMBIN_MAST.combin_desc as "Package",ad_size_height as "Depth",ad_size_width as "Width",TBL_BOOKING_MAST.total_area as "Area", COL_MAST.col_alias as "Hue",(select ADVPOS_TYPE_MAST.pos_type_alias from ADVPOS_TYPE_MAST where TBL_BOOKING_INSERT.page_post=ADVPOS_TYPE_MAST.pos_type_code) as "Page",no_insert as "Ins.No.",
case '''+@dateformat + '''

 when ''mm/dd/yyyy'' then convert(varchar(10),Insert_Date,101) 

when ''dd/mm/yyyy'' then convert(varchar(10),Insert_Date,103) 
when ''yyyy/mm/dd'' then convert(varchar(10),Insert_Date,111)  end as "Ins.date" ,

case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),TBL_BOOKING_MAST.date_time,101) 
when ''dd/mm/yyyy'' then convert(varchar(10),TBL_BOOKING_MAST.date_time,103) 
when ''yyyy/mm/dd'' then convert(varchar(10),TBL_BOOKING_MAST.date_time,111)  end as "BookDate"
  ,ro_no as "RoNo.",
case ro_status
when ''1'' then ''Reservation''
when ''2'' then ''Confirm''
end as "RoStatus",
 ADV_TYPE_MAST. Adv_type_name as "AdType" 
,rate_Code as "RateCode",TBL_BOOKING_INSERT.card_rate as "CardRate",isnull(TBL_BOOKING_MAST.card_amount,TBL_BOOKING_MAST.gross_amount) as "Amt",TBL_BOOKING_INSERT.disc_rate as "Disc",  TBL_BOOKING_INSERT.insert_status as "Status",TBL_BOOKING_INSERT.status_material as "MatStatus",caption as "Cap",key_no as "Key",agrred_rate as "AgreedRate",(select  AGENCY_MAST.Sub_Agency_code from agency_mast where  AGENCY_MAST.type <> ''P'' and TBL_BOOKING_MAST.agency_code=AGENCY_MAST.code_subcode )as "SubAg",(select adv_cat_mast.adv_cat_name from adv_cat_mast where ADV_CAT_MAST.adv_cat_code=TBL_BOOKING_MAST.ad_cat_code) as "AdCat",SAPID

from TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,PUB_MAST,PUB_CENT_MAST,ADV_TYPE_MAST ,COMBIN_MAST, COL_MAST 
 where TBL_BOOKING_MAST.comp_code='''+@compcode+''' and TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.cio_booking_id
 and TBL_BOOKING_MAST.agency_code=AGENCY_MAST.agency_code and TBL_BOOKING_MAST.Ad_type_code=ADV_TYPE_MAST .adv_type_code
 and tbl_booking_mast.Color_code=col_mast.Col_code  and 
TBL_BOOKING_MAST.package_code=COMBIN_MAST.combin_code and TBL_BOOKING_MAST.agency_sub_code=AGENCY_MAST.code_subcode and TBL_BOOKING_INSERT.publication_code = PUB_MAST.pub_code and TBL_BOOKING_INSERT.pub_cent_code=PUB_CENT_MAST.pub_cent_code '

--select adv_cat_mast.adv_cat_name from adv_cat_mast where ADV_CAT_MAST.adv_cat_code=TBL_BOOKING_MAST.ad_cat_code



if(@hold is not null)
begin
set @str=@str+' and UPPER(TBL_BOOKING_INSERT.insert_status)!=''CANCEL'''
end

if(@agname  is not null)
begin

set @str=@str+' and tbl_booking_mast.Agency_sub_code ='''+@agname +''''
end

if(@clientname is not null)
begin
set @str=@str+' and TBL_BOOKING_MAST.client_code ='''+@clientname +''''
end
if(@status is not null)
begin
set @str=@str+' and TBL_BOOKING_INSERT.insert_status  ='''+@status+''''
end


if(@adtype is not null)
begin
print(@adtype)
set @str=@str + 'and TBL_BOOKING_MAST. ad_type_code ='''+@adtype+''' '
End

if(@adcategory is not null)
begin
set @str=@str +  ' and TBL_BOOKING_MAST. ad_cat_code in('''+@adcategory+''' )'
End


--if(@pub_cent<>null )
--begin
--select @center=substring(pub_cent_alias,1,3) from pub_cent_mast where pub_cent_code=@pub_cent

--print(@center)
--set @str=@str+'  and tbl_booking_insert.pub_cent_code='''+ @center +''''
--print(@str)
--end
if(@pub_cent is not null)
begin
set @str=@str+'  and tbl_booking_insert.pub_cent_code ='''+  @pub_cent+''''
end




if(@fromdate is not null and @dateto is null )
begin
	set @str=@str+' and Insert_Date ='''+@fromdate +''''

end

else if(@fromdate is not null and @dateto is not null )
begin
	set @str=@str+' and Insert_Date between  '''+@fromdate +''' and  '''+@dateto +''' '
end

if(@edition is not null)
begin
set @str=@str+'  and tbl_booking_insert.edition_code='''+ @edition +''''
End

if(@pub_name is not null)
begin
set @str=@str+' and  TBL_BOOKING_INSERT.publication_code='''+ @pub_name +''''
End



if(@descid is not  null)
begin
set @str=@str+'  order by '''+@descid + ''''
set @str=@str+ ''+@ascdesc+''

End



print(@str)
exec(@str)




///////////////////end of issue/////////////////////////////


//////////////////5410//////////////mimoh 1nov 2011//////////////////start///////////////////////


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[getperiodDate_Edition] 
	@Compcode varchar(50),
	@pkgname	VARCHAR(50),
	@dateday DATETIME
AS
DECLARE @VCODE AS varchar(10)
DECLARE @day_p AS INT
DECLARE @month_p AS INT
DECLARE @fcycle_p AS INT
DECLARE @scycle_p AS INT
BEGIN
select @VCODE=ValidationCode from PREODICITY_MASTER where Comp_Code=@Compcode and Preodicity_Code=(select Preodicity_Code from edition_mast where Comp_Code=@Compcode and Edition_Alias=@pkgname)
select @day_p=DATEPART(dd,@dateday) ,@month_p=DATEPART(mm,@dateday)    
print @VCODE
IF @VCODE ='2' OR @VCODE = '3' OR @VCODE = '4' OR @VCODE = '6' OR @VCODE = '7' 
begin      
    select @fcycle_p=Date_Edition,@scycle_p=AdditionalDate_Edit from edit_date  WHERE Comp_Code=@Compcode and Edition_Alias= @pkgname     
    -- VCODE = 6 BI-MONTHLY AND VCODE = 7 QUARTLY    
    IF @VCODE  = 2  -- MONTHLY
	BEGIN
        IF @fcycle_p = @day_p 
            SELECT '0' as MESSAGE
        ELSE
            SELECT 'NOT A VALID DATE' AS MESSAGE    
	END
	ELSE IF @VCODE  = '6'  -- BI-MONTHLY
	BEGIN
        IF @fcycle_p = @day_p AND (@scycle_p = @month_p  or datepart(month,dateadd(month,2,cast(cast(@scycle_p as varchar(5))+'/'+cast(@fcycle_p  as varchar(5))+'/'+ cast(datepart(year,getdate()) as varchar(5)) as datetime)))=@month_p or datepart(month,dateadd(month,4,cast(cast(@scycle_p  as varchar(5))+'/'+cast(@fcycle_p  as varchar(5))+'/'+ cast(datepart(year,getdate()) as varchar(5)) as datetime)))=@month_p or datepart(month,dateadd(month,6,cast(cast(@scycle_p  as varchar(5))+'/'+cast(@fcycle_p  as varchar(5))+'/'+ cast(datepart(year,getdate()) as varchar(5)) as datetime)))=@month_p or datepart(month,dateadd(month,8,cast(cast(@scycle_p  as varchar(5))+'/'+cast(@fcycle_p  as varchar(5))+'/'+ cast(datepart(year,getdate()) as varchar(5)) as datetime)))=@month_p or datepart(month,dateadd(month,10,cast(cast(@scycle_p  as varchar(5))+'/'+cast(@fcycle_p  as varchar(5))+'/'+ cast(datepart(year,getdate()) as varchar(5)) as datetime)))=@month_p)
            SELECT '0' as MESSAGE
        ELSE
            SELECT 'NOT A VALID DATE' AS MESSAGE    
	END
	ELSE IF @VCODE  = '7'  -- QUARTLY
	BEGIN
print 'ss'
print @fcycle_p
print @day_p
        IF @fcycle_p = @day_p AND (@scycle_p = @month_p  or datepart(month,dateadd(month,3,cast(cast(@scycle_p  as varchar(5))+'/'+cast(@fcycle_p  as varchar(5))+'/'+ cast(datepart(year,getdate()) as varchar(5)) as datetime)))=@month_p or datepart(month,dateadd(month,6,cast(cast(@scycle_p  as varchar(5))+'/'+cast(@fcycle_p  as varchar(5))+'/'+ cast(datepart(year,getdate()) as varchar(5)) as datetime)))=@month_p or datepart(month,dateadd(month,9,cast(cast(@scycle_p  as varchar(5))+'/'+cast(@fcycle_p  as varchar(5))+'/'+ cast(datepart(year,getdate()) as varchar(5)) as datetime)))=@month_p)
            SELECT '0' as MESSAGE
        ELSE
            SELECT 'NOT A VALID DATE' AS MESSAGE    
	END
    ELSE IF @VCODE = 3 --YEARLY
	BEGIN
         IF @fcycle_p = @day_p  AND @scycle_p = @month_p 
            SELECT '0' AS MESSAGE
        ELSE
            SELECT 'NOT A VALID DATE' AS MESSAGE    
	END
    ELSe IF @VCODE = 4  --FORTNIGHTLY
	BEGIN
         IF @fcycle_p = @day_p  OR @scycle_p = @month_p
            SELECT '0' AS MESSAGE
        ELSE
            SELECT 'NOT A VALID DATE' AS MESSAGE  
	END
    ELSE
	BEGIN
    SELECT '0' AS MESSAGE
    END     
END
else
begin
	 SELECT '0' AS MESSAGE
end      
END


/***********************************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go








ALTER PROCEDURE [dbo].[qbc_getinsertion]
@package varchar(1000),
@noofinsertion varchar(10),
@insertiondate varchar(20),
@startdate varchar(50),
@dateformat as varchar(15),
@compcode as varchar(8),
@pck as float,
@uom as varchar(8),
@dealrate as float,
@adcategory as varchar(8),
@adsubcat as varchar(8),
@color as varchar(8),
@adtype as varchar(8),
@currency as varchar(8),
@ratecode as varchar(8),
@clickdate as varchar(50),
@flag as int,
@code as varchar(100),
@checkforor as varchar(8),
@classinserts as varchar(8),
@lines as varchar(8),
@adcat3 as varchar(8),
@adcat4 as varchar(8),
@adcat5 as varchar(8),
@clientcode as varchar(25),
@user_id as VARCHAR(50),
@center as VARCHAR(50)
AS
CREATE TABLE #TMP_GRIDINS   ( SEGMENTNUM    INT,  EDITION_NAME  VARCHAR(500),  FLAG          VARCHAR(500),  INSERTION     INT)
CREATE TABLE #TMP2
(
  EDITION_NAME  VARCHAR(500),
  DATE1         DATETIME,
  EDITION_CODE  VARCHAR(50),
  IDNUM         INT
)
CREATE TABLE #TMPINS
(
  SEGMENTNAME   VARCHAR(50),
  EDITION_NAME  VARCHAR(500),
  DATE1         DATETIME,
  IDNUM         int,
  EDITION_CODE  VARCHAR(50)
)
declare @packagename varchar(1000)
declare @i int
declare @linechk as int
set @i=0
declare @finaldate datetime
DECLARE @SNUM INT
DECLARE @EDI_NAME VARCHAR(100);
DECLARE @FL VARCHAR(100)
DECLARE @INSERTS INT
DECLARE @FINSERTS INT
DECLARE @REPAETTYPE VARCHAR(2)
DECLARE @PERIODICITY_VALIDCODE VARCHAR(1)
DECLARE @PERIODICITY_COUNT INT
if(@startdate='')
	set @finaldate = null
else
	set @finaldate=@startdate

set @packagename=@package
select @REPAETTYPE=REPEAT_DAY_TYPE from preferrences where comp_code=@compcode
INSERT INTO #TMP_GRIDINS SELECT * FROM MULTISPLIT(@packagename,@code,',')
DECLARE subedition CURSOR LOCAL FOR SELECT SEGMENTNUM, EDITION_NAME, FLAG, INSERTION FROM  #TMP_GRIDINS  ORDER BY SEGMENTNUM 
OPEN subedition 
DECLARE @count		 INT 
SELECT @count = 1 
WHILE (0 = 0) 
BEGIN 

FETCH NEXT FROM subedition INTO 
@SNUM, @EDI_NAME, @FL, @INSERTS
IF (@@FETCH_STATUS = -1) 
BREAK
SELECT @PERIODICITY_COUNT=COUNT(*) FROM EDITION_MAST WHERE EDITION_ALIAS=@EDI_NAME
IF @PERIODICITY_COUNT > 0
BEGIN
	SELECT @PERIODICITY_VALIDCODE=ValidationCode FROM PREODICITY_MASTER WHERE Preodicity_Code=
	(select Preodicity_Code from edition_mast where Ltrim(RTRIM(Edition_Alias))=Ltrim(RTRIM(@EDI_NAME)))
END
ELSE
BEGIN
	SELECT @PERIODICITY_VALIDCODE=ValidationCode FROM PREODICITY_MASTER WHERE Preodicity_Code=
	(select Preodicity_Code from SUPPLEMENT_MAST where Ltrim(RTRIM(SUPP_Alias))=Ltrim(RTRIM(@EDI_NAME)))
END
SELECT @FINSERTS  = @INSERTS * @noofinsertion -- dbms_output.put_line(FINSERTS);


WHILE ( (@i) < (@FINSERTS))
BEGIN 

IF (@i = 0 AND (@startdate IS NOT NULL AND @startdate<>'' ) )
	BEGIN 
	SELECT @finaldate  = @startdate 
	END
ELSE
BEGIN 
	IF (@insertiondate IS NULL or @insertiondate='' ) 
	BEGIN 
	SELECT @finaldate  = null 
	END
	ELSE
	BEGIN 
		IF @REPAETTYPE = 'y'
			SELECT @finaldate  = dateadd(year,cast(@insertiondate as int),@finaldate)
		ELSE IF @REPAETTYPE = 'm'
			SELECT @finaldate  = dateadd(month,cast(@insertiondate as int),@finaldate)
		ELSE
		BEGIN
			if @PERIODICITY_VALIDCODE = '6' 
               SELECT @finaldate  = dateadd(month,2,@finaldate)
            ELSE if @PERIODICITY_VALIDCODE = '7' 
               SELECT @finaldate  = dateadd(month,3,@finaldate)
			ELSE
				SELECT @finaldate  = dateadd(day,cast(@insertiondate as int),@finaldate)
		END
	END

END

INSERT INTO  #TMPINS    
VALUES 		( @SNUM , 
@EDI_NAME , 
@finaldate , 
@i , 
@FL)  

SELECT @i  = @i + 1 

END 

SELECT @i  = 0 
SELECT @FINSERTS  = 0 
SELECT @count=@count +1
END 

CLOSE subedition

DEALLOCATE subedition


IF ( @flag = 0 ) 
BEGIN 
INSERT INTO  #TMP2    SELECT edition_name,date1,EDITION_CODE,IDNUM FROM  #TMPINS ORDER BY idnum,EDITION_CODE,segmentname 
END

IF ( @dateformat = 'mm/dd/yyyy' ) 
BEGIN 
	IF @insertiondate = null OR @insertiondate = '' 
	BEGIN 
	SELECT ISNULL((SELECT Combin_Desc  FROM  COMBIN_MAST  WHERE	Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name",  ISNULL(CONVERT(VARCHAR(10), date1, 101), '') AS 'Date', EDITION_CODE, IDNUM,Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 
	END
	ELSE
	BEGIN 
	SELECT  ISNULL((SELECT Combin_Desc FROM  COMBIN_MAST  WHERE	Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND	pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name", ISNULL(CONVERT(VARCHAR(10), date1, 101), '') AS "Date", EDITION_CODE, IDNUM, Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 
	END

END

IF ( @dateformat = 'dd/mm/yyyy' ) 
BEGIN 
	IF @insertiondate = null  OR @insertiondate = '' 
	BEGIN 
	SELECT ISNULL((SELECT Combin_Desc FROM  COMBIN_MAST  WHERE	 Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND	pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name", ISNULL(CONVERT(VARCHAR(10), date1, 103), '') AS "Date", EDITION_CODE, IDNUM,Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 
	END
	ELSE
	BEGIN 
	SELECT ISNULL((SELECT Combin_Desc FROM  COMBIN_MAST  WHERE	 Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND	pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name", ISNULL(CONVERT(VARCHAR(10), date1, 103), '') AS "Date", EDITION_CODE,  IDNUM, Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 
	END

END

IF ( @dateformat = 'yyyy/mm/dd' ) 
BEGIN 
	IF @insertiondate = null OR @insertiondate = '' 
	BEGIN 
	SELECT ISNULL((SELECT Combin_Desc FROM  COMBIN_MAST WHERE	 Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND	pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name", ISNULL(CONVERT(VARCHAR(10), date1, 111), '') AS "Date",  EDITION_CODE, IDNUM, Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 
	END
	ELSE
	BEGIN 
	SELECT ISNULL((SELECT Combin_Desc FROM  COMBIN_MAST WHERE	 Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND	pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name", ISNULL(CONVERT(VARCHAR(10), date1, 111), '') AS "Date", EDITION_CODE, IDNUM, Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 
	END
END

IF ( @dateformat = null OR @dateformat='') 
BEGIN 
	IF @insertiondate = null OR @insertiondate=''
	BEGIN 
	SELECT
	ISNULL((SELECT Combin_Desc FROM  COMBIN_MAST  WHERE	 Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND	pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name", ISNULL(CONVERT(VARCHAR(10), date1, 101), '') AS "Date", EDITION_CODE, IDNUM, Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 
	END
	ELSE
	BEGIN 
	SELECT ISNULL((SELECT Combin_Desc FROM  COMBIN_MAST WHERE	 Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND	pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name", ISNULL(CONVERT(VARCHAR(10), date1, 101), '') AS "Date", EDITION_CODE, IDNUM, Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 
	END
END

SELECT Col_Name AS "col_Name", Col_Code AS "col_Code" FROM  COL_MAST  WHERE	 Comp_Code  = @Compcode 
SELECT premiumname, Premiumcode FROM  ADVPOS_PREM_MAST  WHERE	 comp_code  = @Compcode 

SELECT Adv_Subcat_Name, Adv_Subcat_Code FROM  ADV_SUBCAT_MAST  WHERE	 Adv_Cat_Code  = @Adcategory AND	Comp_Code  = @compcode

SELECT Uom_Name AS "uom_name", Uom_Code AS "uom_code" FROM  UOM_MAST  WHERE	 Comp_Code  = @Compcode

SELECT Adv_Type_Name AS "adv_type_name", Adv_Type_Code AS "adv_type_code" FROM  ADV_TYPE_MAST  WHERE	 Comp_Code  = @Compcode 
SELECT Adv_Cat_Name AS "adv_cat_name",Adv_Cat_Code AS "adv_cat_code" FROM  ADV_CAT_MAST WHERE	 Comp_Code  = @Compcode

SELECT Pos_Type_Code AS "pos_type_code", Pos_Type AS "pos_type" FROM  ADVPOS_TYPE_MAST  WHERE	 Comp_Code  = @Compcode

SELECT Comp_Code FROM  EDITION_MAST  WHERE	 Comp_Code  = 'dummy'

SELECT Paid_permission FROM  MODULE_DETAIBUTTONL  WHERE	 comp_code  = @Compcode AND	Form_Name  = 'QBC'

SELECT catname, catcode FROM  AD_CAT3  WHERE	 subcatname  = @adsubcat AND	compcode  = @compcode ORDER BY catname 

SELECT  Cat_Name,Cat_Code FROM  TBL_CAT4 WHERE	 Sub_Cat_Name  = @adcat3 AND	Comp_Code  = @compcode ORDER BY Cat_Name 

SELECT Cat_Name, Cat_Code FROM  TBL_CAT5  WHERE	 Sub_Cat_Name  = @adcat4 AND	Comp_Code  = @compcode ORDER BY Cat_Name







/**********************************************************************************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[bindaudit]
--@code as varchar(10),
@fromdate as varchar(10),
 @todate as varchar(10),
@date as varchar(15),
@branch1 as varchar(50),
@adtype as varchar(50),
@audittype as VARCHAR(50),
@branch2 as VARCHAR(50),
@v_Cat as varchar(50),
@comp_code as varchar(50)

 AS
declare @query as varchar(1000)
----BHANU
declare @RELAUTHREQ as varchar(1)

select @RELAUTHREQ=RELAUTHREQON from preferrences where comp_code=@comp_code
----BHANU
 IF (@audittype = 'audit')
 begin
    	  	 IF(@branch1='All')
                begin        	  
set @query  ='SELECT cio_booking_id,
               isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) as Client_code,
           audit,Ad_type_code,
            (select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=tbl_booking_mast .cio_booking_id and File_Name <> null ) as FILENAME,
            
          
   CASE '''+@date+'''
WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime"
 FROM TBL_BOOKING_MAST WHERE  date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''' 
AND Ad_type_code='''+@Adtype+''' AND audit <>'''''
--and (branch=@branch2 OR  @branch2 IS NULL) 
--and (tbl_booking_mast.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL)
                end
             ELSE
        	  begin
 set @query  ='SELECT cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) 
as Client_code,audit,Ad_type_code,(select top 1  File_Name from tbl_booking_insert 
where Cio_Booking_Id=tbl_booking_mast.cio_booking_id and File_Name <> null ) as FILENAME,
   CASE '''+@date+'''
WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime"


 FROM 
TBL_BOOKING_MAST WHERE  date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''' AND branch IN (SELECT Branch_CODE FROM BRANCH_MST 
WHERE pub_center=(SELECT top 1 Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+'''))
 AND Ad_type_code='''+@Adtype+'''  AND  audit <> '''''
 --and (branch=@branch2 OR  @branch2 IS NULL) 
--AND (tbl_booking_mast.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL)

             END 
          END 
		  IF (@audittype = 'unaudit') begin
      	     IF(@branch1='All')begin
        	     
 set @query  =' SELECT cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) as Client_code,audit,Ad_type_code,
(select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=tbl_booking_mast.cio_booking_id and File_Name <> null) as FILENAME,


   CASE '''+@date+'''
WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime"


FROM 
TBL_BOOKING_MAST WHERE  
date_time BETWEEN '''+@fromdate+''' AND '''+@todate +'''
AND Ad_type_code='''+@Adtype+''' AND audit = '''' '
--and (branch=@branch2 OR  @branch2 IS NULL) 
--and (tbl_booking_mast.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL);
        		end 		
             ELSE
        	 	begin 
 set @query  ='         		 SELECT cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) as Client_code,audit,Ad_type_code,
(select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=tbl_booking_mast.cio_booking_id and File_Name <> null ) as FILENAME ,


   CASE '''+@date+'''
WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime"

FROM TBL_BOOKING_MAST WHERE  date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''' AND 
branch IN(SELECT Branch_CODE FROM BRANCH_MST WHERE pub_center=(SELECT  top 1 Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+''' )) 
AND Ad_type_code='''+@Adtype+''' AND audit = '''' '
--and (branch=@branch2 OR  @branch2 IS NULL) and (tbl_booking_mast.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL);
             END 
          END 

		  IF (@audittype != 'unaudit' AND @audittype != 'audit') begin
      	     IF(@branch1='All')begin
        	    
  set @query  ='SELECT cio_booking_id,
isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) as Client_code,
audit,Ad_type_code,(select top 1 File_Name from tbl_booking_insert where Cio_Booking_Id=tbl_booking_mast.cio_booking_id and File_Name <> null ) as FILENAME,
   CASE '''+@date+'''
WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime"


 FROM TBL_BOOKING_MAST WHERE  date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''' AND 
Ad_type_code='''+@Adtype+''' '
--and (branch=@branch2 OR  @branch2 IS NULL) 
--and (tbl_booking_mast.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL)
        		 end		
    		 ELSE
begin
        	    
set @query  ='SELECT cio_booking_id,
isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) as Client_code,
audit,Ad_type_code,(select top 1 File_Name from tbl_booking_insert where Cio_Booking_Id=tbl_booking_mast.cio_booking_id and File_Name is not null 
 ) as FILENAME,
 
 
    CASE '''+@date+'''
WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime" FROM 
TBL_BOOKING_MAST WHERE  date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''' AND 
branch IN(SELECT Branch_CODE FROM BRANCH_MST WHERE pub_center=(SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+''')) AND
 Ad_type_code='''+@Adtype+''' '
--and (branch=@branch2 OR  @branch2 IS NULL) 
--AND (tbl_booking_mast.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL);
             END 
          END 





if(@branch2 <> null or @branch2 <> '')
begin
set @query= @query+' and branch='''+@branch2+''' '
end 



if(@v_Cat <> null or @v_Cat <> '')
begin
set @query=@query+' and tbl_booking_mast.Ad_cat_code='''+@v_Cat+''' '
end 
----BHANU
if(@RELAUTHREQ = 'A' )
begin
set @query=@query+' and tbl_booking_mast.APP_STATUS='''+'Y'+''' '
end 
if(@RELAUTHREQ = 'D' )
begin
set @query=@query+'  and (DBO.Fn_Deviatio(tbl_booking_mast.Card_rate,tbl_booking_mast.Agrred_rate)!=''0'' OR DBO.Fn_chkSalesExec(tbl_booking_mast.Userid)=''SE0'' or ''' + @RELAUTHREQ+ '''= ''A'')'
end 
-----BHANU
print(@query)
exec(@query)



/********************************************************************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go






ALTER PROCEDURE [dbo].[getapprovalRo_web] @vusername  varchar(50),
@compcode as varchar(50),
@agency as varchar(50),
@executive as  varchar(50),
@client as varchar(50),
@varFromDate as datetime,
@varToDate as datetime,
@dateformat as varchar(20),
@cioid as varchar(50),
@flag as varchar(1)
AS
declare @query varchar(3000)
---BHANU
declare @RELAUTHREQ as varchar(1)
---BHANU
BEGIN
---BHANU
select @RELAUTHREQ=RELAUTHREQON from preferrences where comp_code=@compcode
---BHANU
if(@flag='A')
begin
set @query='SELECT (select Agency_Name from agency_mast where Comp_Code='''+@compcode+''' and code_subcode=tbl_booking_mast.Agency_sub_code) agency,
(select Package_Name from combin_mast where Comp_Code='''+@compcode+''' and Combin_Code=(
case when charindex(''abcdef'','','') >0 then 
substrING(Package_code,1,charindex(Package_code,'','')-1)  
else Package_code end)) as Package,
case '''+@dateformat+''' when ''dd/mm/yyyy'' then
convert(varchar(12),date_time,103) 
when ''mm/dd/yyyy'' then
convert(varchar(12),date_time,101) 
else
convert(varchar(12),date_time,111) 
end  as bookdate
,
(select Cust_Name from cust_mast where Comp_Code='''+@compcode+''' and Cust_Code= Client_code) client,
RO_No,case '''+@dateformat+''' when ''dd/mm/yyyy'' then
convert(varchar(12),ro_date,103) 
when ''mm/dd/yyyy'' then
convert(varchar(12),ro_date,101) 
else
convert(varchar(12),ro_date,111) 
end  as rodate,(select Exec_name from exec_mast where  Exe_no = Executive_code) executive,
(select Retain_Name from retainermaster where Comp_Code='''+@compcode+''' and Retain_Code= RETAINER) retainer,Card_rate,
DBO.Fn_Deviatio(tbl_booking_mast.Card_rate,tbl_booking_mast.Agrred_rate) as deviation,cio_booking_id ,Bill_amount,Gross_amount,
(select premiumname from advpos_prem_mast where comp_code='''+@compcode+''' and Premiumcode=tbl_booking_mast.Page_prem) as PAGEPERM,APP_STATUS,booked_by
from tbl_booking_mast where Comp_code='''+@compcode+'''  and APP_STATUS=''Y'' and (DBO.Fn_Deviatio(tbl_booking_mast.Card_rate,tbl_booking_mast.Agrred_rate)!=''0'' OR DBO.Fn_chkSalesExec(tbl_booking_mast.Userid)=''SE0'' or ''' + @RELAUTHREQ+ '''= ''A'')'
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------BHANU
if @agency!=''
begin
set @query = @query + ' and Agency_sub_code = '''+@agency+''''
end
if @executive!=''
begin
set @query = @query + ' and Executive_code = '''+ @executive+''''
end
if @client!=''
begin
set @query = @query + ' and Client_code = '''+ @client+''''
end
if @cioid!=''
begin
set @query = @query + ' and cio_booking_id = '''+ @cioid+''''
end

set @query = @query + ' and date_time between '''+ CAST(@varFromDate AS VARCHAR(20))+''' and '''+ CAST(@varToDate AS VARCHAR(20))+''''
end
else if(@flag='R')
begin
set @query='SELECT (select Agency_Name from agency_mast where Comp_Code='''+@compcode+''' and code_subcode=tbl_booking_mast.Agency_sub_code) agency,
(select Package_Name from combin_mast where Comp_Code='''+@compcode+''' and Combin_Code=(
case when charindex(''abcdef'','','') >0 then 
substrING(Package_code,1,charindex(Package_code,'','')-1)  
else Package_code end)) as Package,
case '''+@dateformat+''' when ''dd/mm/yyyy'' then
convert(varchar(12),date_time,103) 
when ''mm/dd/yyyy'' then
convert(varchar(12),date_time,101) 
else
convert(varchar(12),date_time,111) 
end  as bookdate
,
(select Cust_Name from cust_mast where Comp_Code='''+@compcode+''' and Cust_Code= Client_code) client,
RO_No,case '''+@dateformat+''' when ''dd/mm/yyyy'' then
convert(varchar(12),ro_date,103) 
when ''mm/dd/yyyy'' then
convert(varchar(12),ro_date,101) 
else
convert(varchar(12),ro_date,111) 
end  as rodate,(select Exec_name from exec_mast where  Exe_no = Executive_code) executive,
(select Retain_Name from retainermaster where Comp_Code='''+@compcode+''' and Retain_Code= RETAINER) retainer,Card_rate,
DBO.Fn_Deviatio(tbl_booking_mast.Card_rate,tbl_booking_mast.Agrred_rate) as deviation,cio_booking_id ,Bill_amount,Gross_amount,
(select premiumname from advpos_prem_mast where comp_code='''+@compcode+''' and Premiumcode=tbl_booking_mast.Page_prem) as PAGEPERM,APP_STATUS,booked_by
from tbl_booking_mast where Comp_code='''+@compcode+'''  and  APP_STATUS=''N'' and (DBO.Fn_Deviatio(tbl_booking_mast.Card_rate,tbl_booking_mast.Agrred_rate)!=''0'' OR DBO.Fn_chkSalesExec(tbl_booking_mast.Userid)=''SE0'' or ''' + @RELAUTHREQ+ '''= ''A'')'
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------BHANU
if @agency!=''
begin
set @query = @query + ' and Agency_sub_code = '''+@agency+''''
end
if @executive!=''
begin
set @query = @query + ' and Executive_code = '''+ @executive+''''
end
if @client!=''
begin
set @query = @query + ' and Client_code = '''+ @client+''''
end
if @cioid!=''
begin
set @query = @query + ' and cio_booking_id = '''+ @cioid+''''
end

set @query = @query + ' and date_time between '''+ CAST(@varFromDate AS VARCHAR(20))+''' and '''+ CAST(@varToDate AS VARCHAR(20))+''''
end
else
begin
set @query='SELECT (select Agency_Name from agency_mast where Comp_Code='''+@compcode+''' and code_subcode=tbl_booking_mast.Agency_sub_code) agency,
(select Package_Name from combin_mast where Comp_Code='''+@compcode+''' and Combin_Code=(
case when charindex(''abcdef'','','') >0 then 
substrING(Package_code,1,charindex(Package_code,'','')-1)  
else Package_code end)) as Package,
case '''+@dateformat+''' when ''dd/mm/yyyy'' then
convert(varchar(12),date_time,103) 
when ''mm/dd/yyyy'' then
convert(varchar(12),date_time,101) 
else
convert(varchar(12),date_time,111) 
end  as bookdate
,
(select Cust_Name from cust_mast where Comp_Code='''+@compcode+''' and Cust_Code= Client_code) client,
RO_No,case '''+@dateformat+''' when ''dd/mm/yyyy'' then
convert(varchar(12),ro_date,103) 
when ''mm/dd/yyyy'' then
convert(varchar(12),ro_date,101) 
else
convert(varchar(12),ro_date,111) 
end  as rodate,(select Exec_name from exec_mast where  Exe_no = Executive_code) executive,
(select Retain_Name from retainermaster where Comp_Code='''+@compcode+''' and Retain_Code= RETAINER) retainer,Card_rate,
DBO.Fn_Deviatio(tbl_booking_mast.Card_rate,tbl_booking_mast.Agrred_rate) as deviation,cio_booking_id ,Bill_amount,Gross_amount,
(select premiumname from advpos_prem_mast where comp_code='''+@compcode+''' and Premiumcode=tbl_booking_mast.Page_prem) as PAGEPERM,APP_STATUS,booked_by
from tbl_booking_mast where Comp_code='''+@compcode+''' and isnull(APP_STATUS,''#'')!=''Y''   and isnull(APP_STATUS,''#'')!=''N'' and (DBO.Fn_Deviatio(tbl_booking_mast.Card_rate,tbl_booking_mast.Agrred_rate)!=''0'' OR DBO.Fn_chkSalesExec(tbl_booking_mast.Userid)=''SE0'' or ''' + @RELAUTHREQ+ '''= ''A'')'
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------BHANU
if @agency!=''
begin
set @query = @query + ' and Agency_sub_code = '''+@agency+''''
end
if @executive!=''
begin
set @query = @query + ' and Executive_code = '''+ @executive+''''
end
if @client!=''
begin
set @query = @query + ' and Client_code = '''+ @client+''''
end
if @cioid!=''
begin
set @query = @query + ' and cio_booking_id = '''+ @cioid+''''
end

set @query = @query + ' and date_time between '''+ CAST(@varFromDate AS VARCHAR(20))+''' and '''+ CAST(@varToDate AS VARCHAR(20))+''''
end
print @query
EXEC(@query)
END








/************************************************************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER FUNCTION [dbo].[getcm1] 
(
	@col varchar(10),
	@prod varchar(30),
	@adtype varchar(10)
)
RETURNS numeric(6,2)
AS
BEGIN
	declare @getsize varchar(10)
	select @getsize=col_size from COLCM where COL_NO=@col and ADPRODUCT=@prod and AD_TYPE=@adtype
	if @getsize is null
		set @getsize= @col
	
	return  @getsize
END

/*****************************************************************************************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER PROCEDURE [dbo].[insertintobooking]

@approvedby as varchar(25),
@audit as varchar(25),
@rono as varchar(20),
@rodate as datetime,
@caption as varchar(500),
@billstatus as varchar(8),
@rostatus as varchar(8),
@agency as varchar(8),
@client as varchar(100),
@agencyaddress as varchar(500),
@clientaddresses as varchar(500),
@agencycode as varchar(50),
@dockitno as varchar(25),
@execname as varchar(8),
@execzone as varchar(8),
@product as varchar(8),
@brand as varchar(8),
@keyno as varchar(50),
@billremark as varchar(500),
@printremark as varchar(500),
@package as varchar(500),
@insertion as int,
@startdate as datetime,
@repeatdate as varchar(8),
@adtype as varchar(8),
@adcategory as varchar(8),
@subcategory as varchar(8),
@color as varchar(8),
@uom as varchar(8),
@pageposition as varchar(8),
@pagetype as varchar(100),
@pageno as int,
@adsizheight as float,
@adsizwidth as float,
@ratecode as varchar(8),
@scheme as varchar(500),
@currency as varchar(8),
@agreedrate as float,
@agreedamt as float,
@spedisc as float,
@spacedisx as float,
@compcode as varchar(8),
@userid as varchar(8),
@ciobookid as varchar(50),
@date_time as datetime,
@branch as varchar(25),
@booked_by as varchar(25),
@prevbook as varchar(25),
@adsizetype as varchar(8),
@specialcharges as float,
--, , , , , , , , , , , , , , , , , , , 
@agencytype as varchar(25),
@agencystatus as varchar(25),
@paymode as varchar(25),
@agencredit as int,
@cardrate as float,
@cardamount as float,
@discount as float,
@discountper as float,
@billaddress as varchar(500),
@totarea as float,
@billcycle as varchar(8),
@revenuecenter as varchar(8),
@billpay as varchar(8),
@billheight as float,
@billwidth as float,
@billto as varchar(8),
@invoices as int,
@vts as int,
@tradedisc as float,
@agencyout as varchar(50),
@boxcode as varchar(8),
@boxno as varchar(8),
@boxaddress as varchar(500),
@boxagency as varchar(2),
@boxclient as varchar(2),
@bookingtype as varchar(8),
@tfn as varchar(2),
@coupan as varchar(2),
@campaign as varchar(50),
@bill_amt as float,
@pageprem as varchar(8),
@pageamt as float,
@premper as float,
@grossamt as float,
@adsizcolumn as float,
@billarea as float,
@billcolumn as float,
@spacediscper as float,
@specdiscper as float,
@paidins as int,
@deviation as float,
@dealrate as float,
@varient as varchar(8),
@dealtype as varchar(50),
@contractname as varchar(50),
@cardname as varchar(100),
@cardtype as varchar(50),
@cardmonth as varchar(8),
@cardyear as varchar(8),
@cardno as varchar(20),
@receiptno as varchar(50),
@adscat3 as varchar(8),
@adscat4 as varchar(8),
@adscat5 as varchar(8),
@bgcolor as varchar(8),
@bulletcode as varchar(8),
@bulletprm as float,
@material as varchar(8),
@receiptdate as datetime=null,
@prevcioid as varchar(100)=null,
@prevreceipt as varchar(50)=null,
@prev_ga as float=null,
@region as varchar(8)=null,
@varient_name as varchar(8)=null,
@coltype as varchar(8)=null,
@logo_h as varchar(5)=null,
@logo_w as varchar(5)=null,
@logo_col as varchar(8)=null,
@logo_uom as varchar(8)=null,
@retainer1 AS VARCHAR(50),
@addagencyrate AS VARCHAR(50),
@mobileno AS varchar(100),
@addlamt as varchar(50),
@retamt as varchar(50),
@retper as varchar(50),
@cashrecieved as float,
@CIRAGENCY as varchar(100),
@CIRRATE as varchar(50),
@CIREDITION as varchar(50),
@CIRPUBLICATION as varchar(50),
@CIRAGENCYSUBCODE as varchar(50),
@BARTERTYPE AS VARCHAR(50),
@CASHDISCOUNT_V AS FLOAT,
@CASHDISCOUNTPER_V AS VARCHAR(5),
@attach1 AS varchar(50),
@attach2 AS varchar(50),
@drpdiscprem AS VARCHAR(50),
@doctype as varchar(20),
@CHKTRADE AS VARCHAR(1),
@sharepub_p as varchar(4000),
@fmginsert	as varchar(100),
@chkno AS VARCHAR(50),
@chkdate as datetime=null,
@chkamt AS VARCHAR(30),
@chkbankname as varchar(100),
@ourbank	as varchar(50),
@DEALERPANEL_P AS VARCHAR(1),
@DEALERH_P AS FLOAT,
@DEALERW_P AS FLOAT,
@DEALERTYPE_P AS VARCHAR(1),
@multiselect AS VARCHAR(200),
@AGREEDRATE_ACTIVE as int,
@AGREEDAMT_ACTIVE as int,
@grossamtlocal_p as float,
@billamtlocal_p as float
AS

declare @sccode as varchar(50)
declare @bk_audit as varchar(2)
declare @rate_auth as varchar(2)
declare @auditn as varchar(50)
declare @username_v as varchar(50)
declare @roleid_v as varchar(50)
-----BHANU
declare @RELAUTHREQ as varchar(1)
---BHANU
--select @sccode=scheme_id from scheme_master where scheme_name=ltrim(rtrim(@scheme)) and comp_code=@compcode
SET @sccode=@scheme
--, , , , , , , ,CIRAGENCY,CIRRATE,CIREDITION
select @rate_auth=RATE_AUTHORIZATION,@bk_audit=audit,@RELAUTHREQ=RELAUTHREQON from preferrences where comp_code=@compcode
-----------------------------------------------------BHANU @RELAUTHREQ != 'A'-----**************/
select @username_v=username,@roleid_v=roleid from login where userid=@userid
if @roleid_v!='SE0' and  @RELAUTHREQ != 'A'
begin
if @RELAUTHREQ = 'D'
  begin
		if @rate_auth='Y' and @bk_audit='y' and (@agreedamt is null or @agreedamt='' or @agreedamt='0') 
		begin
				
			  set @auditn=@username_v
		end
		else
		begin
			   set @auditn=@audit    
		end
	end 
else
		  set @auditn=@username_v
   
end

else
begin
       set @auditn=@audit    
end
------------------------BHANU CHANGS CONDITION @RELAUTHREQ != 'A'
insert into tbl_booking_mast_g(
date_time ,
branch  ,
booked_by  ,
cio_booking_id  ,
prev_booking  ,
applied_by  ,
audit  ,
RO_No  ,
RO_Date ,
Caption ,
bill_status ,
ro_status  ,
Agency_code  ,
Agency_address ,
Client_code  ,
Client_address ,
Agency_sub_code  ,
Dockit_no  ,
Executive_code  ,
Executive_zone  ,
Product_code  ,
Brand_code  ,
	Key_no  ,
Bill_remarks ,
Print_remark ,
Package_code ,
No_of_insertion ,
Insertion_date ,
Repeating_day  ,
Ad_type_code  ,
Ad_cat_code  ,	
Ad_sub_cat_code ,
Color_code  ,
	Uom_code  ,
Page_position_code  ,
Page_type_code  ,
Page_no ,
Ad_size_type_code  ,
Ad_size_height  ,
Ad_size_width  ,
Rate_code  ,
Scheme_type_code  ,
Currency_code  ,
Agrred_rate  ,	
Agreed_amount  ,
Special_discount  ,
Space_discount  ,
Special_charges  ,
Comp_code ,
Userid,
Agency_status,
Agency_type,
Agency_pay,
Agency_credit,
Total_area,
Card_rate,
Card_amount,
Discount,
Discount_per,
Bill_cycle,
Revenue_center,
Bill_pay,
Bill_height,
Bill_width,
Bill_to,
Invoices,
Vts,
Bill_add,
Trade_disc,
Agency_out,
Box_code,
Box_no,
Box_agency,
Box_client,
Box_address,
Booking_type,
Tfn,
Coupan_ad,
Campaign,
Bill_amount,
Page_prem,
Page_amount,
Prem_per,
Gross_amount,
Ad_size_column,
Bill_column,
Bill_area,
Special_disc_per,
Space_disc_per,
Paid_ins,
Contract_rate,
Deviation,
Variant_code,
Contract_name,
Contract_type,
Card_name,
Card_type,
Card_month,
Card_year,
Card_number,
Receipt_no,
Ad_Subcat3,
Ad_Subcat4,
Ad_subcat5,
Bg_color,
Bullet_code,
Bullet_premium,
Material_status,
Receipt_date,
prev_cioid,
prev_receipt,
prev_grossamt,
Region,
Variant,
Colortype,
Logo_H,
Logo_W,
Logo_color,
Logo_Uom,
Creation_datetime,
RETAINER,
ADD_AGENCY_COMM,
MobileNo,
ADD_AGENCY_COMM_AMT,
RETAINER_COMM,
RETAINER_COMM_AMT,
CASH_RECIEVED,
CIRAGENCY,
CIRRATE,
CIREDITION,
CIRPUBLICATION,
CIRAGENCY_SUBCODE,
BARTER_TYPE,
CASHDISCOUNT,
CASHDISCTYPE,
ATTACHMENT1,
ATTACHMENT2,
DISC_PREMIUM,
DOCTYPE,
CHKTRADEDISC,
CHK_NO,
CHK_DATE,
CHK_AMT,
CHK_BANK_NAME,
OUR_BANK,
DEALERPANEL,
DEALER_H,
DEALER_W,
DEALERTYPE,
ACTIVE_AGREEDRATE,
ACTIVE_AGREEDAMT,
LOCALGROSSAMT,
LOCALBILLAMT
) 
values	 
(@date_time,
@branch,
@booked_by,
@ciobookid,
@prevbook,
@approvedby ,
@auditn ,
@rono ,
@rodate ,
@caption,
@billstatus ,
@rostatus ,
@agency ,
@agencyaddress,
@client ,
@clientaddresses,
@agencycode ,
@dockitno ,
@execname ,
@execzone ,
@product ,
@brand ,
@keyno ,
@billremark,
@printremark,
@package ,
@insertion,
 @startdate ,
@repeatdate ,
@adtype ,
@adcategory ,
@subcategory ,
@color ,
@uom ,
@pageposition ,
@pagetype ,
@pageno,
@adsizetype,
 @adsizheight ,
@adsizwidth ,
@ratecode ,
@sccode ,
@currency ,
@agreedrate ,
@agreedamt ,
@spedisc ,
@spacedisx ,
@specialcharges,
@compcode ,
@userid,
@agencystatus,
@agencytype,
@paymode,
@agencredit,
@totarea,
@cardrate,
@cardamount,
@discount, 
@discountper,
@billcycle, 
@revenuecenter,
@billpay, 
@billheight,
 @billwidth,
@billto, 
@invoices, 
@vts,
@billaddress , 
@tradedisc, 
@agencyout,
@boxcode,
@boxno,
@boxagency,
@boxclient,
@boxaddress,
@bookingtype,
@tfn,
@coupan,
@campaign ,
@bill_amt,
@pageprem,
@pageamt,
@premper,
@grossamt,
@adsizcolumn,
@billcolumn,
@billarea,
@specdiscper,
@spacediscper,
@paidins,
@dealrate,
@deviation,
@varient,
@contractname,
@dealtype,
@cardname,
@cardtype,
@cardmonth,
@cardyear,
@cardno,
@receiptno,
@adscat3,
@adscat4,
@adscat5,
@bgcolor,
@bulletcode,
@bulletprm,
@material,
@receiptdate,
@prevcioid,
@prevreceipt,
@prev_ga,
@region,
@varient_name,
@coltype,
@logo_h,
@logo_w,
@logo_col,
@logo_uom,
GETDATE(),
 @retainer1,
@addagencyrate,
@mobileno,
@addlamt,
@retper,
@retamt,
@cashrecieved,
@CIRAGENCY,
@CIRRATE,
@CIREDITION,
@CIRPUBLICATION,
@CIRAGENCYSUBCODE,
@BARTERTYPE,
@CASHDISCOUNT_V,
@CASHDISCOUNTPER_V,
@attach1,
@attach2,
@drpdiscprem,
@doctype,
@CHKTRADE,
@chkno,
@chkdate,
@chkamt,
@chkbankname,
@ourbank,
@DEALERPANEL_P,
@DEALERH_P,
@DEALERW_P,
@DEALERTYPE_P,
@AGREEDRATE_ACTIVE,
@AGREEDAMT_ACTIVE,
@grossamtlocal_p,
@billamtlocal_p
)


IF @sharepub_p is not null and @sharepub_p!=''
begin
	exec insert_sharepub_details @sharepub_p,@ciobookid,'INSERT'
end


if @fmginsert is not null and @fmginsert!=''
begin
	exec insert_fmgTrans_details @fmginsert,@ciobookid,'INSERT'
end




if @multiselect is not null and @multiselect!=''
begin
	exec insert_multiexec_details @userid,@compcode,@multiselect,@ciobookid,'INSERT'
end




/**********************************************************************************************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER  procedure [dbo].[insertRemarks_web]
@remarks as varchar(500),
@userid as varchar(50),
@appstatus as varchar(10),
@insertid as varchar(10),
@cioid as varchar(50)

as
declare @countmain int;
declare @countapp int;
declare @countreject int;
declare @username_v varchar(50)
if @insertid is null 
begin
update tbl_booking_mast set tbl_booking_mast.APP_STATUS=@appstatus,APP_REMARKS=@remarks,APP_DATE=getdate(),APP_USER=@userid  where cio_booking_id=@cioid
update tbl_booking_INSERT set APP_STATUS=@appstatus,APP_REMARKS=@remarks,APP_DATE=getdate(),APP_USER=@userid  where Cio_Booking_Id=@cioid
----BHANU
--if @appstatus = 'N' 
--    update tbl_booking_mast set audit=null where cio_booking_id=@cioid
--else 
--begin
--select @username_v=username from login where userid=@userid
--    update tbl_booking_mast set audit=/*@username_v*/ where cio_booking_id=@cioid  
--end
---BHANU
end
else
begin
update tbl_booking_INSERT set APP_STATUS=@appstatus,APP_REMARKS=@remarks,APP_DATE=getdate(),APP_USER=@userid  where Cio_Booking_Id=@cioid AND Insert_Id=@insertid
select @countmain=count(*)   from tbl_booking_INSERT where Cio_Booking_Id=@cioid
select @countapp=count(*) from tbl_booking_INSERT where Cio_Booking_Id=@cioid and APP_STATUS is not null
if @countmain=@countapp 
begin
select @countreject=count(*)   from tbl_booking_INSERT where Cio_Booking_Id=@cioid and APP_STATUS ='N'
if @countreject=@countmain 
update tbl_booking_mast set APP_STATUS='N',APP_DATE=getdate(),APP_USER=@userid  where cio_booking_id=@cioid
else
update tbl_booking_mast set APP_STATUS='Y',APP_DATE=getdate(),APP_USER=@userid  where cio_booking_id=@cioid
end 
end


/**********************************end***********************************************************************************/

//////////////////5410//////////////mimoh 1nov 2011//////////////////end///////////////////////

/*======================================= ISSUE 0005059 (Kuldeep Bhati) ==============================*/

ALTER PROCEDURE [dbo].[getCenter_Agency]
	-- Add the parameters for the stored procedure here
	@compcode varchar(50),
@agency varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select pub_center,(select Add1 + '^' + Phone1 + '^' + Phone2 from pub_cent_mast where
Pub_Cent_name=branch_mst.pub_center) from branch_mst where Comp_Code=@compcode and  
Branch_Code=@agency--(select retainer_code from login where Agency_code=@agency and COM_CODE=@compcode and
 --retainer_code <>'0')
END


/*======================================End of ISSUE 0005059 (Kuldeep Bhati) ==============================*/

/*======================================ISSUE 0004645 (Kuldeep Bhati) ==============================*/

ALTER procedure [dbo].[websp_selectvalues_kannad]


(

@ciobooking  varchar(50), 
@editionname varchar(50),
@compcode  VARCHAR(50),
@insertion varchar(50),
@dateformat varchar(50)
)
as 
declare @str  as varchar(8000)
declare @str1  as varchar(8000)
declare @package_cd  as varchar(300)
declare @package_result  as varchar(300)
declare @package_cd1  as varchar(300)
create table #package ( package_name varchar (100) )

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

(select premiumname from ADVPOS_PREM_MAST,tbl_booking_insert where   ADVPOS_PREM_MAST. premiumcode=tbl_booking_insert.premium1 and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' and   tbl_booking_insert.no_insert='''+@insertion+''' and  tbl_booking_insert.edition='''+@editionname+''' ),
tbl_booking_mast.special_discount,
tbl_booking_mast.Special_disc_per,
tbl_booking_mast.Space_disc_per,
tbl_booking_mast.special_charges
,tbl_booking_mast.trade_disc,

(select premium_charges from ADVPOS_PREM_MAST,tbl_booking_insert where   ADVPOS_PREM_MAST. premiumcode=tbl_booking_insert.premium1 and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' and   tbl_booking_insert.no_insert='''+@insertion+''' and  tbl_booking_insert.edition='''+@editionname+''' ) as "premiumch",tbl_booking_insert.card_rate,
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
(select Uom_Name from uom_mast where uom_mast.Comp_Code=tbl_booking_mast.Comp_Code and uom_code=tbl_booking_mast.uom_code) as uom_name,
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
tbl_booking_insert.Pai_free_ins AS "PAI_FREE_INS",
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
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))) AS CITY_NAMEnew

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
 and TBL_BOOKING_MAST.agency_SUB_code=AGENCY_MAST.code_subcode  and comp_mst.comp_code='''+@compcode+''' 
 and tbl_booking_insert.Col_code=col_mast.Col_code   and pub_mast.pub_code=tbl_booking_insert.publication_code 
  and edition_mast.edition_code=tbl_booking_insert.edition_code and city_mst.city_code=agency_mast.city_code  and TBL_BOOKING_INSERT.publication_code = PUB_MAST.pub_code and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' and   tbl_booking_insert.no_insert='''+@insertion+''' and  tbl_booking_insert.edition='''+@editionname+''' '






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





print(@str)
print(@str1)

exec(@str+@str1)


select * from #package	
delete from #package

select distinct edition_code from tbl_booking_insert where  cio_booking_id=@ciobooking and Insert_status not in ('Hold','cancel')

-- select top 1 insert_date from tbl_booking_insert where  cio_booking_id=@ciobooking order by insert_date
select top 1 DateName( Month,insert_date )+'-'+ DateName( Year, insert_date ) as "insert_date" from tbl_booking_insert where  cio_booking_id=@ciobooking and tbl_booking_insert.no_insert=@insertion order by insert_date

select scheme_code  from Scheme_Master where comp_code=@compcode and Scheme_id=@v_scheme_code
select AGENCYCOMM_SEQ_COM from preferrences where comp_code=@compcode

/*======================================End of ISSUE 0004645 (Kuldeep Bhati) ==============================*/


/******************ajay**************************/



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[RA_bindadcategory_r] 

@advtype varchar(8),
@compcode varchar(8)

 AS

select Adv_Cat_Code,Adv_Cat_Name from adv_cat_mast where  comp_code=@compcode 
and (adv_type=@advtype or @advtype is null or @advtype ='')
order by Adv_Cat_Name

/**end***/

/*====================================== 28-November-2011 (currency) (Kuldeep Bhati) ==============================*/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE   [dbo].[chkdateupdate]
@compcode as varchar(10),
@userid as varchar(10),
@txtconrate as varchar(10),
--@txtfromdate as datetime,
@txtfromdate as varchar(50),

--@txtefftill as datetime,
@txtefftill as varchar(50),
@currcode as varchar(10),
@code10 as varchar(8),
@pcurrency as varchar(20)



 AS
declare @query as varchar(900)
--insert CURR_CONV_DET(Conv_Rate,Valid_From_Date,Valid_Till_Date,UserId,comp_code,Curr_Code)values(@txtconrate,@txtfromdate,@txtefftill,@userid,@compcode,@currcode)

--update  CURR_CONV_DET set Valid_From_Date=@txtfromdate,Valid_Till_Date=@txtefftill,Conv_Rate=@txtconrate where comp_code=@compcode and userid=@userid and Curr_Code=@currcode and Convert_code=@code10
--set @query='select  comm_code, convert(varchar,Eff_from_date,101) as Eff_from_date,convert(varchar,Eff_Till_date,101) as Eff_Till_date,Comm_rate,Discount,comm_code  from comm_details where userid='''+@userid+''' and A(  '''+@fromdatecomm+''' between  Eff_from_date and Eff_Till_date   or  '''+@tilldate+''' between  Eff_from_date and Eff_Till_date or Eff_Till_date  between '''+@fromdatecomm+''' and '''+@tilldate+'''  or Eff_from_date  between '''+@fromdatecomm+''' and '''+@tilldate+'''  )  and   comm_code  !='''+@hiddenccode+'''  '
--set @query='select  comm_code, convert(varchar,Eff_from_date,101) as Eff_from_date,convert(varchar,Eff_Till_date,101) as Eff_Till_date,Comm_rate,Discount,comm_code  from comm_details where userid='''+@userid+''' and Agency_sub_code='''+@subagencycode+'''  and AGENCY_CODE='''+@agencode+'''  and (  '''+@fromdatecomm+''' between  Eff_from_date and Eff_Till_date   or  '''+@tilldate+''' between  Eff_from_date and Eff_Till_date or Eff_Till_date  between '''+@fromdatecomm+''' and '''+@tilldate+'''  or Eff_from_date  between '''+@fromdatecomm+''' and '''+@tilldate+'''  )  and   comm_code  !='''+@hiddenccode+'''  '
set @query='select convert(varchar,Valid_From_Date,101) as Valid_From_Date,convert(varchar,Valid_Till_Date,101) as Valid_Till_Date from CURR_CONV_DET where CONV_CURRENCY='''+@pcurrency+''' and Curr_Code='''+@currcode+'''  and ( '''+@txtfromdate+''' between  Valid_From_Date and Valid_Till_Date   or  '''+@txtefftill+''' between  Valid_From_Date and Valid_Till_Date or Valid_Till_Date  between '''+@txtfromdate+''' and '''+@txtefftill+'''  or Valid_From_Date  between '''+@txtfromdate+''' and '''+@txtefftill+''' ) and   Convert_code  !='''+@code10+'''  '

--set @query='select convert(varchar,Valid_From_Date,101) as Valid_From_Date,convert(varchar,Valid_Till_Date,101) as Valid_Till_Date from CURR_CONV_DET where userid='''+@userid+''' and Curr_Code='''+@currcode+'''  and ( '''+@txtfromdate+''' = Valid_From_Date  or  '''+@txtefftill+'''=Valid_Till_Date  or  '''+@txtfromdate+''' between  Valid_From_Date and Valid_Till_Date   or  '''+@txtefftill+''' between  Valid_From_Date and Valid_Till_Date or Valid_Till_Date  between '''+@txtfromdate+''' and '''+@txtefftill+'''  or Valid_From_Date  between '''+@txtfromdate+''' and '''+@txtefftill+''' ) and   Convert_code  !='''+@code10+'''  '
--set @query='select convert(varchar,Valid_From_Date,101) as Valid_From_Date,convert(varchar,Valid_Till_Date,101) as Valid_Till_Date from CURR_CONV_DET where userid='''+@userid+''' and Curr_Code='''+@currcode+'''  and ( '''+@txtfromdate+''' = Valid_From_Date  or  '''+@txtefftill+'''=Valid_Till_Date  or  '''+@txtfromdate+''' between  Valid_From_Date and Valid_Till_Date   or  '''+@txtefftill+''' between  Valid_From_Date and Valid_Till_Date or Valid_Till_Date  between '''+@txtfromdate+''' and '''+@txtefftill+'''  or Valid_From_Date  between '''+@txtfromdate+''' and '''+@txtefftill+''' and   Convert_code  !='''+@code10+''' )  '


print(@query)
exec(@query)

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER PROCEDURE   [dbo].[chkdateupdate]
@compcode as varchar(10),
@userid as varchar(10),
@txtconrate as varchar(10),
--@txtfromdate as datetime,
@txtfromdate as varchar(50),

--@txtefftill as datetime,
@txtefftill as varchar(50),
@currcode as varchar(10),
@code10 as varchar(8),
@pcurrency as varchar(20)



 AS
declare @query as varchar(900)
--insert CURR_CONV_DET(Conv_Rate,Valid_From_Date,Valid_Till_Date,UserId,comp_code,Curr_Code)values(@txtconrate,@txtfromdate,@txtefftill,@userid,@compcode,@currcode)

--update  CURR_CONV_DET set Valid_From_Date=@txtfromdate,Valid_Till_Date=@txtefftill,Conv_Rate=@txtconrate where comp_code=@compcode and userid=@userid and Curr_Code=@currcode and Convert_code=@code10
--set @query='select  comm_code, convert(varchar,Eff_from_date,101) as Eff_from_date,convert(varchar,Eff_Till_date,101) as Eff_Till_date,Comm_rate,Discount,comm_code  from comm_details where userid='''+@userid+''' and A(  '''+@fromdatecomm+''' between  Eff_from_date and Eff_Till_date   or  '''+@tilldate+''' between  Eff_from_date and Eff_Till_date or Eff_Till_date  between '''+@fromdatecomm+''' and '''+@tilldate+'''  or Eff_from_date  between '''+@fromdatecomm+''' and '''+@tilldate+'''  )  and   comm_code  !='''+@hiddenccode+'''  '
--set @query='select  comm_code, convert(varchar,Eff_from_date,101) as Eff_from_date,convert(varchar,Eff_Till_date,101) as Eff_Till_date,Comm_rate,Discount,comm_code  from comm_details where userid='''+@userid+''' and Agency_sub_code='''+@subagencycode+'''  and AGENCY_CODE='''+@agencode+'''  and (  '''+@fromdatecomm+''' between  Eff_from_date and Eff_Till_date   or  '''+@tilldate+''' between  Eff_from_date and Eff_Till_date or Eff_Till_date  between '''+@fromdatecomm+''' and '''+@tilldate+'''  or Eff_from_date  between '''+@fromdatecomm+''' and '''+@tilldate+'''  )  and   comm_code  !='''+@hiddenccode+'''  '
set @query='select convert(varchar,Valid_From_Date,101) as Valid_From_Date,convert(varchar,Valid_Till_Date,101) as Valid_Till_Date from CURR_CONV_DET where CONV_CURRENCY='''+@pcurrency+''' and Curr_Code='''+@currcode+'''  and ( '''+@txtfromdate+''' between  Valid_From_Date and Valid_Till_Date   or  '''+@txtefftill+''' between  Valid_From_Date and Valid_Till_Date or Valid_Till_Date  between '''+@txtfromdate+''' and '''+@txtefftill+'''  or Valid_From_Date  between '''+@txtfromdate+''' and '''+@txtefftill+''' ) and   Convert_code  !='''+@code10+'''  '

--set @query='select convert(varchar,Valid_From_Date,101) as Valid_From_Date,convert(varchar,Valid_Till_Date,101) as Valid_Till_Date from CURR_CONV_DET where userid='''+@userid+''' and Curr_Code='''+@currcode+'''  and ( '''+@txtfromdate+''' = Valid_From_Date  or  '''+@txtefftill+'''=Valid_Till_Date  or  '''+@txtfromdate+''' between  Valid_From_Date and Valid_Till_Date   or  '''+@txtefftill+''' between  Valid_From_Date and Valid_Till_Date or Valid_Till_Date  between '''+@txtfromdate+''' and '''+@txtefftill+'''  or Valid_From_Date  between '''+@txtfromdate+''' and '''+@txtefftill+''' ) and   Convert_code  !='''+@code10+'''  '
--set @query='select convert(varchar,Valid_From_Date,101) as Valid_From_Date,convert(varchar,Valid_Till_Date,101) as Valid_Till_Date from CURR_CONV_DET where userid='''+@userid+''' and Curr_Code='''+@currcode+'''  and ( '''+@txtfromdate+''' = Valid_From_Date  or  '''+@txtefftill+'''=Valid_Till_Date  or  '''+@txtfromdate+''' between  Valid_From_Date and Valid_Till_Date   or  '''+@txtefftill+''' between  Valid_From_Date and Valid_Till_Date or Valid_Till_Date  between '''+@txtfromdate+''' and '''+@txtefftill+'''  or Valid_From_Date  between '''+@txtfromdate+''' and '''+@txtefftill+''' and   Convert_code  !='''+@code10+''' )  '


print(@query)
exec(@query)

/*======================================End 28-November-2011 (currency) (Kuldeep Bhati) ==============================*/
////////////////////////////////////////////// uganda issue//////garima
////////////////////////////set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER procedure [dbo].[bookingdetailgrid]
(
 @cioid as varchar(100)
)
as

begin


select No_Insert,
(select pub_alias from pub_mast where Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
Pub_Cent_Code as Center,
Edition,

convert(varchar(10),Insert_Date,101) as Insert_Date,Col_Code,Page_No,Size_Book,
(select Adv_Cat_Alias from adv_cat_mast where Adv_Cat_Code=tbl_booking_insert.Ad_Cat ) as AdCategory,
(select Adv_Subcat_Alias from adv_subcat_mast where Adv_Subcat_Code=tbl_booking_insert.Ad_Sub_Cat) as AdSubcategory,
File_Name,Insert_Status,
case Pai_Free_Ins
when 'Y' then 'Yes'
when 'N' then 'No'
end as Pai_Free_Ins
,Gross_Rate,Bill_Amt,BILL_NO,
SECTIONCODE,RESOURCE_NO
from tbl_booking_insert where Cio_Booking_Id=@cioid order by Insert_Id;


end



////////////////////////////////////////////////////////////////////////////////////







ALTER PROCEDURE [dbo].[bindaudit]
--@code as varchar(10),
@fromdate as varchar(10),
 @todate as varchar(10),
@date as varchar(15),
@branch1 as varchar(50),
@adtype as varchar(50),
@audittype as VARCHAR(50),
@branch2 as VARCHAR(50),
@v_Cat as varchar(50),
@comp_code as varchar(50),
@package_code as varchar(100),
@pagency_code as varchar(100),
@pclient_code as varchar(100),
@psection_code as varchar(100)

 AS
declare @query as varchar(8000)
----BHANU
declare @RELAUTHREQ as varchar(1)

select @RELAUTHREQ=RELAUTHREQON from preferrences where comp_code=@comp_code
----BHANU
 IF (@audittype = 'audit')
 begin
    	  	 IF(@branch1='All')
                begin        	  
set @query  ='SELECT distinct TBL_BOOKING_MAST.cio_booking_id,
               isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) as Client_code,
           audit,Ad_type_code,
            (select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=tbl_booking_mast .cio_booking_id and File_Name <> null ) as FILENAME,
            
          
   CASE '''+@date+'''
WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime"
 FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT WHERE  date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''' 
AND Ad_type_code='''+@Adtype+''' AND audit <>''''
AND TBL_BOOKING_MAST.cio_booking_id=tbl_booking_insert.cio_booking_id'
--and (branch=@branch2 OR  @branch2 IS NULL) 
--and (tbl_booking_mast.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL)
                end
             ELSE
        	  begin
 set @query  ='SELECT distinct TBL_BOOKING_MAST.cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) 
as Client_code,audit,Ad_type_code,(select top 1  File_Name from tbl_booking_insert 
where Cio_Booking_Id=tbl_booking_mast.cio_booking_id and File_Name <> null ) as FILENAME,
   CASE '''+@date+'''
WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime"


 FROM 
TBL_BOOKING_MAST ,tbl_booking_insert WHERE  date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''' AND branch IN (SELECT Branch_CODE FROM BRANCH_MST 
WHERE pub_center=(SELECT top 1 Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+'''))
 AND Ad_type_code='''+@Adtype+'''  AND  audit <> ''''
AND TBL_BOOKING_MAST.cio_booking_id=tbl_booking_insert.cio_booking_id
'
 --and (branch=@branch2 OR  @branch2 IS NULL) 
--AND (tbl_booking_mast.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL)

             END 
          END 
		  IF (@audittype = 'unaudit') begin
      	     IF(@branch1='All')begin
        	     
 set @query  =' SELECT  distinct TBL_BOOKING_MAST.cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) as Client_code,audit,Ad_type_code,
(select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=tbl_booking_mast.cio_booking_id and File_Name <> null) as FILENAME,


   CASE '''+@date+'''
WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime"


FROM 
TBL_BOOKING_MAST,tbl_booking_insert WHERE  
date_time BETWEEN '''+@fromdate+''' AND '''+@todate +'''
AND Ad_type_code='''+@Adtype+''' AND audit = ''''
and  TBL_BOOKING_MAST.cio_booking_id=tbl_booking_insert.cio_booking_id'
--and (branch=@branch2 OR  @branch2 IS NULL) 
--and (tbl_booking_mast.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL);
        		end 		
             ELSE
        	 	begin 
 set @query  ='         		 SELECT distinct TBL_BOOKING_MAST.cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) as Client_code,audit,Ad_type_code,
(select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=tbl_booking_mast.cio_booking_id and File_Name <> null ) as FILENAME ,


   CASE '''+@date+'''
WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime"

FROM TBL_BOOKING_MAST,tbl_booking_insert WHERE  date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''' AND 
branch IN(SELECT Branch_CODE FROM BRANCH_MST WHERE pub_center=(SELECT  top 1 Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+''' )) 
AND Ad_type_code='''+@Adtype+''' AND audit = ''''
AND TBL_BOOKING_MAST.cio_booking_id=tbl_booking_insert.cio_booking_id'
--and (branch=@branch2 OR  @branch2 IS NULL) and (tbl_booking_mast.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL);
             END 
          END 

		  IF (@audittype != 'unaudit' AND @audittype != 'audit') begin
      	     IF(@branch1='All')begin
        	    
  set @query  ='SELECT distinct TBL_BOOKING_MAST.cio_booking_id,
isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) as Client_code,
audit,Ad_type_code,(select top 1 File_Name from tbl_booking_insert where Cio_Booking_Id=tbl_booking_mast.cio_booking_id and File_Name <> null ) as FILENAME,
   CASE '''+@date+'''
WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime"


 FROM TBL_BOOKING_MAST,tbl_booking_insert WHERE  date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''' AND 
Ad_type_code='''+@Adtype+''' AND TBL_BOOKING_MAST.cio_booking_id=tbl_booking_insert.cio_booking_id'
--and (branch=@branch2 OR  @branch2 IS NULL) 
--and (tbl_booking_mast.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL)
        		 end		
    		 ELSE
begin
        	    
set @query  ='SELECT distinct TBL_BOOKING_MAST.cio_booking_id,
isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) as Client_code,
audit,Ad_type_code,(select top 1 File_Name from tbl_booking_insert where Cio_Booking_Id=tbl_booking_mast.cio_booking_id and File_Name is not null 
 ) as FILENAME,
 
 
    CASE '''+@date+'''
WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime" FROM 
TBL_BOOKING_MAST,tbl_booking_insert WHERE  date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''' AND 
branch IN(SELECT Branch_CODE FROM BRANCH_MST WHERE pub_center=(SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+''')) AND
 Ad_type_code='''+@Adtype+''' AND TBL_BOOKING_MAST.cio_booking_id=tbl_booking_insert.cio_booking_id '
--and (branch=@branch2 OR  @branch2 IS NULL) 
--AND (tbl_booking_mast.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL);
             END 
          END 



if(@package_code <> null or @package_code <> '')

begin
set @query= @query+' and tbl_booking_insert.package_code in ('''+@package_code+''') '
end



if(@pagency_code <> null or @pagency_code <> '')

begin
set @query= @query+' and tbl_booking_mast.Agency_sub_code in ('''+@pagency_code+''') '
end


if(@pclient_code <> null or @pclient_code <> '')

begin
set @query= @query+' and tbl_booking_mast.Client_code in ('''+@pclient_code+''') '
end

if(@psection_code <> null or @psection_code <> '')

begin
set @query= @query+' and tbl_booking_insert.SECTIONCODE in ('''+@psection_code+''') '
end


if(@branch2 <> null or @branch2 <> '')
begin
set @query= @query+' and branch='''+@branch2+''' '
end 



if(@v_Cat <> null or @v_Cat <> '')
begin
set @query=@query+' and tbl_booking_mast.Ad_cat_code='''+@v_Cat+''' '
end 
----BHANU
if(@RELAUTHREQ = 'A' )
begin
set @query=@query+' and tbl_booking_mast.APP_STATUS='''+'Y'+''' '
end 
if(@RELAUTHREQ = 'D' )
begin
set @query=@query+'  and (DBO.Fn_Deviatio(tbl_booking_mast.Card_rate,tbl_booking_mast.Agrred_rate)!=''0'' OR DBO.Fn_chkSalesExec(tbl_booking_mast.Userid)=''SE0'' or ''' + @RELAUTHREQ+ '''= ''A'')'
end 
-----BHANU
print(@query)
exec(@query)








/////////////////////////////////////////garima//////////

/*======================================= nov-30-11 (Kuldeep Bhati) ==============================*/

create PROCEDURE  AD_RETAIN_ADD_COMM_TARGET_INS (@PCOMP_CODE       AS VARCHAR(40),
												@PRETAIN_CODE     AS VARCHAR(40),
												@PPUBL_CODE       AS VARCHAR(40),
												@PNO_OF_PUBL      AS VARCHAR(40),
												@PADCOMM_PER        AS NUMERIC,
												@PCOMM_TYPE       AS VARCHAR(40),
												@PCREATED_BY      AS VARCHAR(40),
												@PCREATED_DT      AS DATETIME,
												@PUPDATED_BY      AS VARCHAR(40),
												@PUPDATED_DT      AS DATETIME,
												@PCOMM_TARGET_ID  AS NUMERIC,
												@PDML_TYPE        AS VARCHAR(40)) AS

BEGIN
 IF ISNULL(@PDML_TYPE,'?')='I' 
   BEGIN 
     INSERT INTO retain_adcomm_target (COMP_CODE, RETAIN_CODE, PUBL_CODE, NO_OF_PUBL,ADCOMM_PER,
									  COMM_TYPE, CREATED_BY, CREATED_DT, UPDATED_BY, UPDATED_DT)
                            VALUES  (@PCOMP_CODE,@PRETAIN_CODE,@PPUBL_CODE,@PNO_OF_PUBL,@PADCOMM_PER,
                                     @PCOMM_TYPE,getdate(),@PCREATED_DT,@PUPDATED_BY,@PUPDATED_DT)
   END
 IF ISNULL(@PDML_TYPE,'?')='U' 
   BEGIN
     UPDATE retain_adcomm_target SET PUBL_CODE = @PPUBL_CODE, NO_OF_PUBL = @PNO_OF_PUBL, ADCOMM_PER = @PADCOMM_PER,
                                   COMM_TYPE = @PCOMM_TYPE,UPDATED_BY = @PUPDATED_BY,UPDATED_DT = getdate()
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
          AND COMM_TARGET_ID = @PCOMM_TARGET_ID;
   END
 IF ISNULL(@PDML_TYPE,'?')='D' 
   BEGIN
     DELETE FROM retain_adcomm_target
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
          AND COMM_TARGET_ID = @PCOMM_TARGET_ID;
   END
END

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER    PROCEDURE  [dbo].[AD_RETAIN_COMM_TARGET_INS] (@PCOMP_CODE       AS VARCHAR(40),
												@PRETAIN_CODE     AS VARCHAR(40),
												@PTEAM_CODE       AS VARCHAR(40),
												@PADCTG_CODE      AS VARCHAR(40),
												@PFROM_TGT        AS NUMERIC,
												@PTO_TGT          AS NUMERIC,
												@PCUST_TYPE       AS VARCHAR(40),
												@PAD_TYPE         AS VARCHAR(40),
												@PPUB_TYPE        AS VARCHAR(40),
												@PPUBL_CODE       AS VARCHAR(40),
												@PCREATED_BY      AS VARCHAR(40),
												@PCREATED_DT      AS DATETIME,
												@PUPDATED_BY      AS VARCHAR(40),
												@PUPDATED_DT      AS DATETIME,
												@PCOMM_TARGET_ID  AS NUMERIC,
												@PDML_TYPE        AS VARCHAR(40)) AS
BEGIN
 IF ISNULL(@PDML_TYPE,'?')='I' 
   BEGIN 
     INSERT INTO RETAIN_COMM_TARGET (COMP_CODE,RETAIN_CODE,TEAM_CODE,ADCTG_CODE,FROM_TGT,
                                     TO_TGT,CUST_TYPE,AD_TYPE,PUB_TYPE,PUBL_CODE,
                                     CREATED_BY,CREATED_DT,UPDATED_BY,UPDATED_DT,COMM_TARGET_ID)
                            VALUES  (@PCOMP_CODE,@PRETAIN_CODE,@PTEAM_CODE,@PADCTG_CODE,@PFROM_TGT,
                                     @PTO_TGT,@PCUST_TYPE,@PAD_TYPE,@PPUB_TYPE,@PPUBL_CODE,
                                     @PCREATED_BY,@PCREATED_DT,@PUPDATED_BY,@PUPDATED_DT,@PCOMM_TARGET_ID);
   END
 IF ISNULL(@PDML_TYPE,'?')='U' 
   BEGIN
     UPDATE RETAIN_COMM_TARGET SET TEAM_CODE = @PTEAM_CODE, ADCTG_CODE = @PADCTG_CODE, FROM_TGT = @PFROM_TGT,
                                   TO_TGT = @PTO_TGT, CUST_TYPE = @PCUST_TYPE, AD_TYPE = @PAD_TYPE,
                                   PUB_TYPE = @PPUB_TYPE, PUBL_CODE = @PPUBL_CODE, CREATED_BY = @PCREATED_BY,
                                   CREATED_DT = @PCREATED_DT,UPDATED_BY = @PUPDATED_BY,UPDATED_DT = @PUPDATED_DT
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
          AND COMM_TARGET_ID = @PCOMM_TARGET_ID;
   END
 IF ISNULL(@PDML_TYPE,'?')='D' 
   BEGIN
     DELETE FROM RETAIN_COMM_TARGET
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
          AND COMM_TARGET_ID = @PCOMM_TARGET_ID;
   END
END



@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22

alter  procedure  retselectstructslab
(
@compcode as varchar(20),
@userid as varchar(20),
@retcode as varchar(20),
@code11 as int


)

as

select TEAM_CODE,ADCTG_CODE,FROM_TGT,TO_TGT,CUST_TYPE,AD_TYPE,PUB_TYPE,PUBL_CODE,COMM_TARGET_ID from RETAIN_COMM_TARGET where COMP_CODE=@compcode and RETAIN_CODE=@retcode and COMM_TARGET_ID=@code11



@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@2

create  PROCEDURE AD_RETAIN_COMM_TARGET_BIND
(
@retcode as varchar(20),
@userid as varchar(20),
@compcode as varchar(20)
)

as

select * from RETAIN_COMM_TARGET where COMP_CODE=@compcode  and RETAIN_CODE=@retcode

/*======================================= nov-30-11 (Kuldeep Bhati) ==============================*/

/*======================================= dec-01-11 (Kuldeep Bhati) ==============================*/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER  procedure [dbo].[insertretstatus_slab]
(
@compcode as varchar(20),
@userid as varchar(20),
@retcode as varchar(20),
--enln as varchar(20), 
@fromdays as varchar(20),
@todays as varchar(20),
@drpcommon as varchar(20),
@commrate as varchar(20),
@P_COMM_TARGET_ID as varchar(20)
)

as
declare @enlncode as int

select @enlncode=max(isnull(ENLN,0)+1) from RETAIN_COMM_SLAB

insert into retain_comm_slab(COMP_CODE,RETAIN_CODE,ENLN,FROM_DAYS,TILL_DAYS,COMM_ON,COMM_RATE,CREATED_BY,CREATED_DATE,UPDATED_BY,UPDATED_DATE,COMM_TARGET_ID) 
values(@compcode,@retcode,@enlncode,@fromdays,@todays,@drpcommon,@commrate,@userid,getdate(),'','',@P_COMM_TARGET_ID)

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

create  procedure retaddselectslab
(
@compcode as varchar(20),
@userid as varchar(20),
@retcode as varchar(20),
@code11 as int


)

as

select  PUBL_CODE, NO_OF_PUBL,ADCOMM_PER,COMM_TYPE,COMM_TARGET_ID from retain_adcomm_target where COMP_CODE=@compcode and RETAIN_CODE=@retcode and COMM_TARGET_ID=@code11



@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

create  PROCEDURE retaddstatusbind
(
@retcode as varchar(20),
@userid as varchar(20),
@compcode as varchar(20)
)

as

select * from retain_adcomm_target where COMP_CODE=@compcode  and RETAIN_CODE=@retcode 




/*======================================= dec-01-11  (Kuldeep Bhati) ==============================*/



//================================issue no. 5825 02/12/2011============================================================
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





ALTER procedure [dbo].[completereport]
(
@compcode as varchar(50)= NULL,
@fromdate as varchar(50)= NULL,
@dateto as varchar(50)= NULL,
@dateformat as varchar(50)= NULL,
@publication as varchar(50)= NULL,
@pub_cent as varchar(50)= NULL,
@edition as varchar(50)= NULL,
@suppliment as varchar(50)= NULL,
@zone as varchar(50)= NULL,
@branch as varchar(50)= NULL,
@district as varchar(50)= NULL,
@region as varchar(50)= NULL,
@city as varchar(50)= NULL,
@revcenter as varchar(50)= NULL,
@adtype as varchar(50)= NULL,
@agencytype as varchar(50)= NULL,
@ratetype as varchar(50)= NULL,
@adcat as varchar(50)= NULL,
@adsubcat as varchar(50)= NULL,
@adsubcat3 as varchar(50)= NULL,
@adsubcat4 as varchar(50)= NULL,
@adsubcat5 as varchar(50)= NULL,
@package as varchar(50)= NULL,
@scheme as varchar(50)= NULL,
@agency as varchar(50)= NULL,
@client as varchar(50)= NULL,
@executive as varchar(50)= NULL,
@retainer as varchar(50)= NULL,
@product as varchar(50)= NULL,
@brand as varchar(50)= NULL,
@varient as varchar(50)= NULL,
@pagetype as varchar(50)= NULL,
@pageprem as varchar(50)= NULL,
@postprem as varchar(50)= NULL,
@rostatus as varchar(50)= NULL,
@booktype as varchar(50)= NULL,
@contractname as varchar(50)= NULL,
@filterby as varchar(50)= NULL,
@adcheck as varchar(50)=null,
@state as varchar(50)=null,
@taluka as varchar(50)=null,
@base as varchar(50)=null,
@drpstatus as varchar(50)=null,
@chkdetail as varchar(50)=null,
@puserid as varchar(50)=null,
@insertstatus as varchar(50)=null,
@chk_access as varchar(2)
)
AS
declare @query1 as VARCHAR(8000)
declare @v_val as int
declare @query2 as VARCHAR(8000)
declare @query4 as VARCHAR(8000)
declare @query3 as VARCHAR(8000)

declare @bookdate as VARCHAR(50)
declare @noinsert as VARCHAR(50)
declare @Paidinsert as VARCHAR(50)
declare @Area as VARCHAR(50)
declare @Pagepremium as VARCHAR(50)
declare @cardamt as VARCHAR(50)
declare @Deviationamt as VARCHAR(50)
declare @Deviationper as VARCHAR(50)
declare @aggamt as VARCHAR(50)
declare @DiscAmt as VARCHAR(50)
declare @Discper as VARCHAR(50)
declare @posamt as VARCHAR(50)
declare @posper as VARCHAR(50)
declare @Spdiscamt as VARCHAR(50)
declare @Spdiscper as VARCHAR(50)
declare @Spacedisc as VARCHAR(50)
declare @Spacediscper as VARCHAR(50)
declare @Specialcharge as VARCHAR(50)
declare @AgencyAddlTDper as VARCHAR(50)
declare @AgencyAddlTDAmt as VARCHAR(50)
declare @Grossamt as VARCHAR(50)
declare @RetTDper as VARCHAR(50)
declare @RetTDAmt as VARCHAR(50)
declare @AgencyTDper as VARCHAR(50)
declare @AgencyTDAmt as VARCHAR(50)
declare @Billamt as VARCHAR(50)
declare @RetCommper as VARCHAR(50)
declare @RetCommAmt as VARCHAR(50)
declare @ActualBusines as VARCHAR(50)
----------------------------------------
declare @v_edition  as VARCHAR(100)
declare @v_edipkg  as VARCHAR(500)
declare @prefer    as VARCHAR(10)
declare @v_frdt as varchar(10)
declare @v_todt as varchar(10)
-----------cursor variables--------------
declare @c1cioid as varchar(50)
declare @c1pckcode as varchar(50)
declare @c1gramt as float
declare @c1chkvar as varchar(4)
/********************************for billing***********************************************/
declare @v2_CIOID as varchar(100)
declare @v2_BILLNO as varchar(100) 
declare @v2_AGMAINCODE as varchar(100) 
declare @v2_AG_SUB_CODE as varchar(100)
declare @v2_AGCODE as varchar(100)
declare @v2_AGNAME as varchar(200)
declare @v2_EXECCODE as varchar(100)
declare @v2_EXECNAME as varchar(200)
declare @v2_RETCODE as varchar(100)
declare @v2_RETNAME as varchar(200)
declare @q_n as varchar(8000)


/*********************************for billing************************************************/
/*
CREATE TABLE #TEMP_COMPLETE_DYNAMIC_REPORT(  ROW_CODE    VARCHAR(50),  ROW_DESC    VARCHAR(150),  COL_CODE    VARCHAR(50),  COL_DESC    VARCHAR(150),  COL_BILAMT  float,  COL_ACTAMT  float)
CREATE TABLE #MULTIPACK_REP(  CIOID  VARCHAR(500),  PACK   VARCHAR(500))
CREATE TABLE #MULTIPACK_RAT(  CIOID    VARCHAR(500),  RAT      VARCHAR(500),  PER_AMT  int)
CREATE TABLE #MULTIPACK_RATNEW(  CIOID    VARCHAR(500),  RAT      VARCHAR(500),  PER_AMT  int)
*/
create table #temp_ad_bills_report 
(
  CIOID             varchar(50),
  BILLNO            varchar(25),
  AGENCY            varchar(50),
  CLIENT            varchar(200),
  RONO              varchar(40),
  RODATE            DATEtime,
  EXECUTIVE         varchar(50),
  RETAINER          varchar(80),
  BOOKTYPE          varchar(8),
  COLOR             varchar(20),
  ADCAT             varchar(50),
  ADSUBCAT          varchar(50),
  ADSUBCAT3         varchar(50),
  ADSUBCAT4         varchar(50),
  ADSUBCAT5         varchar(50),
  PACKAG            varchar(500),
  BILLDATE          DATEtime,
  NOINSERT          int,
  PAIDINSERT        int,
  HEIGHT            int,
  WIDTH             int,
  AREA              int,
  PAGEPREMIUM       varchar(30),
  POSTPREM          varchar(30),
  SCHEME            varchar(50),
  RATECOD           varchar(40),
  CARDRATE          FLOAT,
  CARDAMT           FLOAT,
  CONTRACTRATE      int,
  DEVIATIONAMT      int,
  DEVIATIONPER      int,
  AGGRATE           int,
  AGGAMT            int,
  DISCAMT           FLOAT,
  DISCPER           int,
  POSAMT            int,
  POSPER            int,
  SPDISCAMT         int,
  SPDISCPER         int,
  SPACEDISC         int,
  SPACEDISCPER      int,
  SPECIALCHARGE     int,
  AGENCYADDLTDPER   varchar(8),
  AGENCYADDLTDAMT   int,
  GROSSAMT          int,
  RETTDPER          int,
  RETTDAMT          int,
  AGENCYTDPER       int,
  AGENCYTDAMT       int,
  BILLAMT           int,
  RETCOMMPER        int,
  RETCOMMAMT        int,
  ACTUALBUSINESS    int,
  REVCENTER         varchar(50),
  UOM               varchar(20),
  UOMDESC           varchar(50),
  COMP_CODE         varchar(10),
  PADTYPE           varchar(20),
  PRIPUB            varchar(10),
  PEDITION          varchar(50),
  BRANCH_NAME       varchar(50),
  PUB_CENT_CODE     varchar(50),
  REGION            varchar(12),
  AGENCY_TYPE_CODE  varchar(10),
  PRIADCTG          varchar(40),
  SECADCTG          varchar(40),
  AD_SUBCAT3        varchar(15),
  AD_SUBCAT4        varchar(15),
  AD_SUBCAT5        varchar(15),
  PACKAGE_CODE      varchar(500),
  AG_MAIN_CODE      varchar(10),
  AG_SUB_CODE       varchar(10),
  CLIENTCD          varchar(200),
  EXECUTIVE_NAME    varchar(100),
  PRIPROCTG         varchar(10),
  BRAND_CODE        varchar(10),
  VARIENT_NAME      varchar(25),
  PAGE_PREM         varchar(10),
  PAGE_POST         varchar(10),
  CONTRACT_NAME     varchar(50),
  SUPP_CODE         varchar(50),
  RETAINER_CODE     varchar(10),
  RATECD            varchar(40),
  CITY_CODE         varchar(20),
  ZONE_CODE         varchar(20),
  DIST_CODE         varchar(20),
  STATE_CODE        varchar(20),
  PTALUKA           varchar(20),
  PSCHEME           varchar(18),
  REVENUE_CENTER    varchar(10),
  RO_STATUS         varchar(10),
  PAGE_TYPE         varchar(100),
  BOOKING_TYPE      varchar(10),
  PUB_CENT_PERMIT   varchar(50),
  SESS_ID           int                      ,
  DIST_NAME         varchar(50),
  TALU_NAME         varchar(50),
  PUB_CENT_NAME     varchar(50),
  CITY_NAME         varchar(30),
  ZONE_NAME         varchar(30),
  STATE_NAME        varchar(30),
PAGE_NO int

)
declare c1 cursor for
		SELECT distinct TBL_BOOKING_mast.cio_booking_id AS "CIOID",
		TBL_BOOKING_MAST.Package_code as "package_code",TBL_BOOKING_mast.Gross_amount as "Crate",'1' as "chk_var"
		FROM TBL_BOOKING_MAST, TBL_BOOKING_INSERT
		WHERE TBL_BOOKING_MAST.Comp_code=@compcode
		AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
		AND ((tbl_booking_mast.Insertion_date BETWEEN @fromdate AND @dateto and @filterby='Publish Date') or (tbl_booking_mast.date_time BETWEEN @fromdate AND @dateto and @filterby='Booking Date'))
		AND (TBL_BOOKING_INSERT.Publication_Code=@publication or @publication is null)
		--and TBL_BOOKING_MAST.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code=@pub_cent or @pub_cent is null))

--old version

--and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
--and (tbl_booking_mast."branch" =p_branch or p_branch is null)

--new version
and TBL_BOOKING_MAST."branch" IN (SELECT  "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT  "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=@pub_cent or @pub_cent is null))
and((@branch is null) or  (tbl_booking_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" =@branch) ))


		AND (TBL_BOOKING_MAST.Ad_type_code=@adtype or @adtype is null)
		AND (TBL_BOOKING_MAST.Ad_cat_code=@adcat or @adcat is null)
		AND (TBL_BOOKING_INSERT.Edition_Code=@edition or @edition is null)
		and (tbl_booking_mast.branch =@branch or @branch is null)
		and (TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.region =@region  or @region is null))
		and (tbl_booking_mast.Revenue_center =@revcenter or @revcenter is null)
		and (TBL_BOOKING_MAST.Agency_type =@agencytype or @agencytype is null)
		and (TBL_BOOKING_MAST.Ad_sub_cat_code =@adsubcat or @adsubcat is null)
		and (TBL_BOOKING_MAST.Ad_Subcat3 =@adsubcat3 or @adsubcat3 is null)
		and (TBL_BOOKING_MAST.Ad_Subcat4 =@adsubcat4 or @adsubcat4 is null or @adsubcat4='')
		and (TBL_BOOKING_MAST.Ad_subcat5 =@adsubcat5 or @adsubcat5 is null or @adsubcat5='')
		and (TBL_BOOKING_MAST.Package_code =@package or @package is null)
		and (TBL_BOOKING_MAST.Scheme_type_code =@scheme or @scheme is null)
		and (TBL_BOOKING_MAST.Agency_code =@agency or @agency is null)
		and (TBL_BOOKING_MAST.Client_code =@client or @client is null)
		and (TBL_BOOKING_MAST.Executive_code =@executive or @executive is null)
		and (TBL_BOOKING_MAST.RETAINER =@retainer or @retainer is null)
		and (TBL_BOOKING_MAST.Product_code =@product  or @product is null)
		and (TBL_BOOKING_MAST.Brand_code =@brand or @brand is null)
		and (TBL_BOOKING_MAST.Variant_code =@varient or @varient is null)
		and (TBL_BOOKING_MAST.Page_type_code =@pagetype or @pagetype is null)
		and (TBL_BOOKING_MAST.Page_prem =@pageprem or @pageprem is null)
		and (TBL_BOOKING_MAST.Page_position_code =@postprem or @postprem is null)
		and (TBL_BOOKING_MAST.ro_status =@rostatus or @rostatus is null)
		and (TBL_BOOKING_MAST.Booking_type =@booktype or @booktype is null)
		and (TBL_BOOKING_MAST.Contract_name =@contractname or @contractname is null)
		and (tbl_booking_insert.Supp_Code =@suppliment or @suppliment is null)
		and (tbl_booking_MAST.Rate_code =@ratetype or @ratetype is null)
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.City_Code =@city or @city is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code =@city or @city is null))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.City_Code=@city or @city is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.zone_code =@zone or @zone is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= @zone or @zone is null) ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Zone_Code=@zone or @zone is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.Dist_Code =@district or @district is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code= @district or @district is null ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Dist_Code=@district or @district is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.State_Code =@state or @state is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code= @state or @state is null ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.State_Code=@state or @state is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.TALUKA=@taluka or @taluka is null ))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA= @taluka or @taluka is null ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.TALUKA=@taluka or @taluka is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code IS NOT NULL AND TBL_BOOKING_MAST.Agency_sub_code!='0')
		or (@base='2' and tbl_booking_mast.Executive_code    is not null and tbl_booking_mast.Executive_code !='0' )
		or (@base='3' and tbl_booking_mast.RETAINER is not null  and tbl_booking_mast.RETAINER !='0'))
		and ((@drpstatus is  not null and  TBL_BOOKING_INSERT.Insert_Status!='XYZ')
		or (@drpstatus is  null and  lower(Insert_Status)!='cancel'))
        and (lower(Insert_Status)=@insertstatus or @insertstatus is null)
      -- and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access='1')
      -- or  (@chk_access='0') )
		and @adcheck='1'
		union--************** union****************************
		SELECT distinct TBL_BOOKING_mast.cio_booking_id AS "CIOID",
		TBL_BOOKING_MAST.Package_code as "package_code",tbl_booking_insert.Gross_Rate as "Crate",'1' as "chk_var"
		FROM TBL_BOOKING_MAST, TBL_BOOKING_INSERT
		WHERE TBL_BOOKING_MAST.Comp_code=@compcode
		AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
		AND (tbl_booking_insert.Insert_Date BETWEEN @fromdate AND @dateto )
		AND (TBL_BOOKING_INSERT.Publication_Code=@publication or @publication is null)
		--and TBL_BOOKING_MAST.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code=@pub_cent or @pub_cent is null))
--old version

--and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
--and (tbl_booking_mast."branch" =p_branch or p_branch is null)

--new version
and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=@pub_cent or @pub_cent is null))
and (tbl_booking_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" =@branch))




		AND (TBL_BOOKING_MAST.Ad_type_code=@adtype or @adtype is null)
		AND (TBL_BOOKING_insert.Ad_Cat=@adcat or @adcat is null)
		AND (TBL_BOOKING_INSERT.Edition_Code=@edition or @edition is null)
		and (tbl_booking_mast.branch =@branch or @branch is null)
		and (TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.region =@region  or @region is null))
		and (tbl_booking_mast.Revenue_center =@revcenter or @revcenter is null)
		and (TBL_BOOKING_MAST.Agency_type =@agencytype or @agencytype is null)
		and (TBL_BOOKING_MAST.Ad_sub_cat_code =@adsubcat or @adsubcat is null)
		and (TBL_BOOKING_MAST.Ad_Subcat3 =@adsubcat3 or @adsubcat3 is null)
		and (TBL_BOOKING_MAST.Ad_Subcat4 =@adsubcat4 or @adsubcat4 is null)
		and (TBL_BOOKING_MAST.Ad_subcat5 =@adsubcat5 or @adsubcat5 is null)
		and (TBL_BOOKING_MAST.Package_code =@package or @package is null)
		and (TBL_BOOKING_MAST.Scheme_type_code =@scheme or @scheme is null)
		and (TBL_BOOKING_MAST.Agency_code =@agency or @agency is null)
		and (TBL_BOOKING_MAST.Client_code =@client or @client is null)
		and (TBL_BOOKING_MAST.Executive_code =@executive or @executive is null)
		and (TBL_BOOKING_MAST.RETAINER =@retainer or @retainer is null)
		and (TBL_BOOKING_MAST.Product_code =@product  or @product is null)
		and (TBL_BOOKING_MAST.Brand_code =@brand or @brand is null)
		and (TBL_BOOKING_MAST.Variant_code =@varient or @varient is null)
		and (TBL_BOOKING_MAST.Page_type_code =@pagetype or @pagetype is null)
		and (TBL_BOOKING_insert.Premium1 =@pageprem or @pageprem is null)
		and (tbl_booking_insert.Page_Post =@postprem or @postprem is null)
		and (TBL_BOOKING_MAST.ro_status =@rostatus or @rostatus is null)
		and (TBL_BOOKING_MAST.Booking_type =@booktype or @booktype is null)
		and (TBL_BOOKING_MAST.Contract_name =@contractname or @contractname is null)
		and (tbl_booking_insert.Supp_Code =@suppliment or @suppliment is null)
		and (tbl_booking_MAST.Rate_code =@ratetype or @ratetype is null)
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.City_Code =@city or @city is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code =@city or @city is null))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.City_Code=@city or @city is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.zone_code =@zone or @zone is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= @zone or @zone is null) ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Zone_Code=@zone or @zone is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.Dist_Code =@district or @district is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code= @district or @district is null ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Dist_Code=@district or @district is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.State_Code =@state or @state is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code= @state or @state is null ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.State_Code=@state or @state is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.TALUKA=@taluka or @taluka is null) )  
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA= @taluka or @taluka is null ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.TALUKA=@taluka or @taluka is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code IS NOT NULL AND TBL_BOOKING_MAST.Agency_sub_code!='0')
		or (@base='2' and tbl_booking_mast.Executive_code    is not null and tbl_booking_mast.Executive_code !='0' )
		or (@base='3' and tbl_booking_mast.RETAINER is not null  and tbl_booking_mast.RETAINER !='0'))
		and ((@drpstatus is  not null and  TBL_BOOKING_INSERT.Insert_Status!='XYZ')
		or (@drpstatus is  null and  lower(Insert_Status)!='cancel'))
and (lower(Insert_Status)=@insertstatus or @insertstatus is null)
--and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access='1')
--or  (@chk_access='0') )
		and @adcheck='3'
		union--***********************Union*****************************
		SELECT distinct ad_bills.IDNUM AS "CIOID",
		ad_bills_det.PACKAGE_CODE as "package_code",ad_bills.GROSS_AMT as "Crate",'2' as "chk_var"
		FROM ad_bills, ad_bills_det
		WHERE ad_bills.IDNUM=ad_bills_det.IDNUM
		AND (ad_bills.BILDT between @fromdate and @dateto)
		and (ad_bills.PRIPUB=@publication  or @publication is null)
		and (ad_bills_det.EDITION=@edition or @edition is null)
		and (ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.region =@region  or @region is null))
		and (ad_bills_det.AD_TYPE_V=@adtype or @adtype is null)
		and (ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.Agency_Type_Code =@agencytype or @agencytype is null))
		and (ad_bills_det.PRIADCTG =@adcat or @adcat is null)
		and (ad_bills_det.SECADCTG =@adsubcat or @adsubcat is null)
		and (ad_bills_det.AD_SUBCAT3  =@adsubcat3 or @adsubcat3 is null)
		and (ad_bills_det.AD_SUBCAT4 =@adsubcat4 or @adsubcat4 is null)
		and (ad_bills_det.AD_SUBCAT5 =@adsubcat5 or @adsubcat5 is null)
		and (ad_bills_det.PACKAGE_CODE =@package or @package is null)
		--and (ad_bills.AGCODE =@agency  or @agency is null)
and (ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.Agency_Code =@agency or @agency is null))
		and (ad_bills.CLIENTCD=@client or @client is null)
		and (ad_bills.EXECUTIVE_NAME=@executive or @executive is null)
		and (ad_bills.PRIPROCTG=@product or @product is null)
		and ((ad_bills.PRIPROCTG in (select brand_mst.prod_cat_code from brand_mst where brand_mst.brand_code=@brand or @brand is null) and ad_bills.PRIPROCTG is not null)or (ad_bills.PRIPROCTG is null))
		and ((ad_bills.PRIPROCTG in (select brand_mst.prod_cat_code from brand_mst where brand_mst.brand_code in(select varient_mst.Brand_Code from varient_mst where varient_mst.Varient_Name=@varient or @varient is null)) and ad_bills.PRIPROCTG is not null) or (ad_bills.PRIPROCTG is null))
		and (ad_bills_det.PAGE_PREM =@pageprem or @pageprem is null)
		and (ad_bills_det.PAGE_POST =@postprem or @postprem is null)
		and (ad_bills.CONTRACT_NAME =@contractname or @contractname is null)
		and (ad_bills_det.SUPP_CODE =@suppliment or @suppliment is null)
		and (ad_bills.RETAINER_CODE =@retainer or @retainer is null)
		and (ad_bills_det.RATECD =@ratetype or @ratetype is null)
		and ((ad_bills.UNIT  in(select branch_mst.Branch_Code from branch_mst where  branch_mst.Branch_Name =@branch or @branch is null) and ad_bills.UNIT is not null ) or (ad_bills.UNIT is not null))
		and ad_bills.UNIT IN (SELECT Branch_Code FROM BRANCH_MST WHERE ad_bills.UNIT=Branch_Code and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code=@pub_cent or @pub_cent is null))
		and (ad_bills.SCHEME=@scheme or @scheme is null)
		and (AD_BILLS.REVENUE_CENTER =@revcenter or @revcenter is null)
		and (AD_BILLS.RO_STATUS =@rostatus or @rostatus is null)
		and (AD_BILLS.PAGE_TYPE =@pagetype or @pagetype is null)
		and (AD_BILLS.BOOKING_TYPE =@booktype or @booktype is null)
		and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.City_Code =@city or @city is null))
		or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code =@city or @city is null))
		or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.City_Code=@city or @city is null)))
		and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.zone_code =@zone or @zone is null))
		or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= @zone or @zone is null) ))
		or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Zone_Code=@zone or @zone is null)))
		and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.Dist_Code =@district or @district is null))
		or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code= @district or @district is null ))
		or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Dist_Code=@district or @district is null)))
		and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.State_Code =@state or @state is null))
		or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code= @state or @state is null ))
		or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.State_Code=@state or @state is null)))
		and ((@base='1' and ad_bills.AGCODE   in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.TALUKA=@taluka or @taluka is null) )  
		or (@base='2' and ad_bills.EXECUTIVE_NAME   in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA= @taluka or @taluka is null ))
		or (@base='3' and ad_bills.RETAINER_CODE  in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.TALUKA=@taluka or @taluka is null)))
		and ((@base='1' and ad_bills.AGCODE IS NOT NULL AND ad_bills.AGCODE!='0')
		or (@base='2' and ad_bills.EXECUTIVE_NAME   is not null and ad_bills.EXECUTIVE_NAME !='0' )
		or (@base='3' and ad_bills.RETAINER_CODE  is not null  and ad_bills.RETAINER_CODE !='0'))
       --and ((ad_bills_det.BKFOR in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access='1')
       --or  (@chk_access='0') )
		and @adcheck='2'

declare  C2 Cursor for
SELECT distinct ad_bills.IDNUM AS "CIOID",ad_bills.BILNO as "BILLNO" ,ag_main_code as "AGMAINCODE",ag_sub_code as "AG_SUB_CODE",agcode as "AGCODE",
dbo.agename(@compcode,agcode) as "AGNAME",
isnull(executive_name,0) as "EXECCODE",
dbo.AD_GET_EXECNAME(@compcode,EXECUTIVE_NAME) as "EXECNAME",
RETAINER_CODE as "RETCODE",
dbo.AD_GET_RETAINER(@compcode,RETAINER_CODE) as "RETNAME"
FROM ad_bills WHERE ((ad_bills.UNIT  in(select branch_mst.Branch_Code from branch_mst where  branch_mst.Branch_Name =@branch or @branch is null) and ad_bills.UNIT is not null ) or (ad_bills.UNIT is  null))
and ad_bills.UNIT IN (SELECT Branch_Code FROM BRANCH_MST WHERE ad_bills.UNIT=Branch_Code and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code=@pub_cent or @pub_cent is null))
and (ad_bills.BILDT between @fromdate and @dateto)
and (ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.region =@region  or @region is null))
and (ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.Agency_Type_Code =@agencytype or @agencytype is null))
and (ad_bills.PRIPUB=@publication  or @publication is null)
and (ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.Agency_Code =@agency or @agency is null))
and (ad_bills.CLIENTCD=@client or @client is null)
and (ad_bills.EXECUTIVE_NAME=@executive or @executive is null)
and (ad_bills.PRIPROCTG=@product or @product is null)
and ((ad_bills.PRIPROCTG in (select brand_mst.prod_cat_code from brand_mst where brand_mst.brand_code=@brand or @brand is null) and ad_bills.PRIPROCTG is not null)or (ad_bills.PRIPROCTG is null or ad_bills.PRIPROCTG=''))
and ((ad_bills.PRIPROCTG in (select brand_mst.prod_cat_code from brand_mst where brand_mst.brand_code in(select varient_mst.Brand_Code from varient_mst where varient_mst.Varient_Name=@varient or @varient is null)) and ad_bills.PRIPROCTG is not null) or (ad_bills.PRIPROCTG is null or ad_bills.PRIPROCTG=''))
and (ad_bills.CONTRACT_NAME =@contractname or @contractname is null)
and (ad_bills.RETAINER_CODE =@retainer or @retainer is null)
and (ad_bills.SCHEME=@scheme or @scheme is null)
and (AD_BILLS.REVENUE_CENTER =@revcenter or @revcenter is null)
and (AD_BILLS.RO_STATUS =@rostatus or @rostatus is null)
and (AD_BILLS.PAGE_TYPE =@pagetype or @pagetype is null)
and (AD_BILLS.BOOKING_TYPE =@booktype or @booktype is null)
and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.City_Code =@city or @city is null))
or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code =@city or @city is null))
or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.City_Code=@city or @city is null)))
and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.zone_code =@zone or @zone is null))
or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= @zone or @zone is null) ))
or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Zone_Code=@zone or @zone is null)))
and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.Dist_Code =@district  or @district  is null))
or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code= @district  or @district  is null ))
or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Dist_Code=@district  or @district  is null)))
and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.State_Code =@state or @state is null))
or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code= @state or @state is null ))
or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.State_Code=@state or @state is null)))
and ((@base='1' and ad_bills.AGCODE   in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.TALUKA=@taluka or @taluka is null) )
or (@base='2' and ad_bills.EXECUTIVE_NAME   in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA= @taluka or @taluka is null ))
or (@base='3' and ad_bills.RETAINER_CODE  in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.TALUKA=@taluka or @taluka is null)))
and ((@base='1' and ad_bills.AGCODE IS NOT NULL AND ad_bills.AGCODE!='0')
or (@base='2' and ad_bills.EXECUTIVE_NAME   is not null and ad_bills.EXECUTIVE_NAME !='0' )
or (@base='3' and ad_bills.RETAINER_CODE  is not null  and ad_bills.RETAINER_CODE !='0'))



set @v_frdt=@fromdate
set @v_todt=@dateto
select distinct @prefer= AGENCY_RETAINER_COMM from preferrences where comp_code=@compcode
delete from temp_complete_dynamic_report


delete from MULTIPACK_REP	
delete from MULTIPACK_RAT
delete from MULTIPACK_RATNEW
open c1
fetch next from c1
into @c1cioid ,@c1pckcode,@c1gramt,@c1chkvar
PRINT(@@FETCH_STATUS)
while @@FETCH_STATUS=0
begin
PRINT('KHARE')
PRINT(@c1chkvar)
	if(@c1chkvar='1')begin	
		insert into MULTIPACK_REP select * from dbo.multipack_report1(@c1cioid, @c1pckcode, @c1gramt, '1')

	end
	else if(@c1chkvar='3') begin
		insert into MULTIPACK_RAT select * from dbo.multipack_report3(@c1cioid, @c1pckcode, @c1gramt, '3')
	end
	else
	begin
		insert into MULTIPACK_RATNEW select * from dbo.multipack_report2(@c1cioid, @c1pckcode, @c1gramt, '2')
	end
	set @v_edition=null
	set @v_edipkg=null
fetch next from c1
into @c1cioid ,@c1pckcode,@c1gramt,@c1chkvar
end
close c1
print('145466')
print(@chkdetail)
print(@adcheck)
print('xz')
if(@chkdetail='Detail')begin

if(@adcheck=1)
begin
set @query1='SELECT distinct a.cio_booking_id AS CIOID
,CASE '''+@dateformat+'''
 WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),a.date_time,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),a.date_time,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),a.date_time,111) END as BookDate,
AGENCY_MAST.Agency_Name AS Agency,
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS Client,
RO_No AS "RoNo.",
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),RO_Date,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),RO_Date,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),RO_Date,111) END AS "Ro.Date",
(select EXEC_MAST.Exec_name from exec_mast where a.Executive_code=exec_mast.Exe_no) AS Executive,
(select RETAINERMASTER.Retain_Name  FROM  RETAINERMASTER where RETAINERMASTER.Retain_Code=a.RETAINER ) AS Retainer,
case a.Booking_type
when ''1'' then ''Barter''
when ''2'' then ''FMG''
when ''3'' then ''Normal''
when ''4'' then ''InHouse''
when ''5'' then ''Complimentary''
else ''Normal'' end as BookType,
(select col_mast.Col_Alias from col_mast where a.Color_code=col_mast.Col_Code) as Color,
adv_cat_mast.Adv_Cat_Name as Adcat,
(select adv_subcat_mast.Adv_Subcat_Name from adv_subcat_mast where a.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code)as Adsubcat,
(select ad_cat3.catname from ad_cat3,adv_subcat_mast  where a.Ad_Subcat3=ad_cat3.catcode and ad_cat3.subcatname=adv_subcat_mast.Adv_Subcat_Code and a.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code) as Adsubcat3,
(select tbl_cat4.Cat_Name from tbl_cat4,adv_subcat_mast where a.Ad_Subcat4=tbl_cat4.Cat_Code and tbl_cat4.Sub_Cat_Name=adv_subcat_mast.Adv_Subcat_Code and a.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code) as Adsubcat4,
(select tbl_cat5.Cat_Name from tbl_cat5,adv_subcat_mast where a.Ad_subcat5=tbl_cat5.Cat_Code and tbl_cat5.Sub_Cat_Name=adv_subcat_mast.Adv_Subcat_Code and a.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code) as Adsubcat5,
dbo.FETCH_PACK(a.cio_booking_id) AS Package,
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),a.Insertion_date,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),a.Insertion_date,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),a.Insertion_date,111) END as PubDate,
a.No_of_insertion as noinsert,
a.Paid_ins as Paidinsert,
a.Ad_size_height as height,
a.Ad_size_width as width,
a.Total_area as Area,
(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where a.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Pagepremium,
(select advpos_type_mast.Pos_Type from advpos_type_mast where a.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem,
(select scheme_master.Scheme_Name from scheme_master where a.Scheme_type_code=scheme_master.scheme_id) as scheme,
a.Rate_code as Ratecode,
a.Card_rate as cardrate,
a.Card_amount as cardamt,
a.Contract_rate as contractrate,
a.Deviation as Deviationamt,
a.Deviation AS  "Deviation(%)",
a.Agrred_rate as Aggrate,
a.Agreed_amount as aggamt,
(a.Card_amount - 
case isnull(a.Agreed_amount,0)
when 0 then a.Card_amount
else a.Agreed_amount end)  as DiscAmt,
a.Discount_per as Discper,
dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1'') as  posamt,
dbo.FETCH_RATAMT(a.cio_booking_id,''2'',''1'')  as  "pos(%)",
round(((a.Special_disc_per * a.Total_area * a.Card_rate)/100),2) as Spdiscamt,
a.Special_disc_per as Spdiscper,
round(((a.Space_disc_per * a.Total_area * a.Card_rate)/100),2) as Spacedisc,
a.Space_disc_per as Spacediscper,
a.Special_charges as Specialcharge,
isnull(a.ADD_AGENCY_COMM,''0'') as  "AgencyAddlTD(%)",
isnull((isnull(a.Gross_amount,''0'')*isnull(a.ADD_AGENCY_COMM,''0'')/100),''0'') as AgencyAddlTDAmt,
isnull(a.Gross_amount,''0'') as Grossamt,
isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''3'' ),''0'')as  "RetTD(%)",
isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''4'' ),''0'')as RetTDAmt,
isnull(a.Trade_disc,''0'' )as "AgencyTD(%)",
(isnull(a.Gross_amount,''0'')* isnull(a.Trade_disc,''0'' )/100 )as AgencyTDAmt,
isnull(a.Bill_amount,''0'') as Billamt,
isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''1'' ),''0'') as "RetComm(%)",
isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''2'' ),''0'') as RetCommAmt,
isnull((a.Bill_amount-isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''2'' ),''0'')  ),''0'') as ActualBusiness,
(SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE a.Revenue_center=BRANCH_MST.Branch_Code )as Revcenter,
UOM_MAST.Uom_Name  AS Uom,
uom_mast.UOM_DESC as uomdesc
,(select top 1 pub_cent_mast.Pub_Cent_name from pub_cent_mast where pub_cent_mast.Pub_cent_Code in(select pub_center from  BRANCH_MST WHERE a.branch=Branch_Name) ) as Printcenter
,a.branch as Branch
,case '''+@base+'''
when ''1'' then  AGENCY_MAST.Dist_Code
when ''2'' then (select dist_mst.Dist_Name from dist_mst where dist_mst.Dist_Code in(select exec_mast.dist_code from exec_mast where  exec_mast.Exe_no=a.Executive_code )  )
when ''3'' then (select dist_mst.Dist_Name from dist_mst where dist_mst.Dist_Code in(select RETAINERMASTER.Dist_Code from RETAINERMASTER where  RETAINERMASTER.Retain_Code= a.RETAINER )  ) end as District
,case '''+@base+'''
when ''1'' then (select taluka_mast.TALU_NAME  from taluka_mast where AGENCY_MAST.TALUKA=taluka_mast.TALU_CODE )
when ''2'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select exec_mast.TALUKA from exec_mast where  exec_mast.Exe_no=a.Executive_code )  )
when ''3'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select RETAINERMASTER.TALUKA from RETAINERMASTER where  RETAINERMASTER.Retain_Code= a.RETAINER )  ) end as Taluka
,isnull(a.Page_no,0) as "Page_No"
,CASHDISCOUNT as "Cash_Disc"
,Box_code as "BoxCode",
a.Userid as USERID,(SELECT max(username) from login where com_code = a.Comp_code and userid=a.Userid) as USERNAME
FROM TBL_BOOKING_MAST a,AGENCY_MAST ,UOM_MAST,
adv_cat_mast,adv_type_mast,
TBL_BOOKING_insert
WHERE a.Comp_code='''+@compcode+''' AND
 UOM_MAST.Uom_Code=a.Uom_code and
a.Agency_sub_code=AGENCY_MAST.code_subcode AND
a.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
a.Ad_type_code=adv_type_mast.Adv_Type_Code
and adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
a.cio_booking_id=tbl_booking_insert.Cio_Booking_Id'
--and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
--or  ('''+@chk_access+'''=''0'') )' 
--

if(@query4='' or @query4 is null)begin
		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' )
		begin
		set @query4=' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 


		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' )
		begin
		set @query4=' and a.Insertion_date  between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 
end
else 
begin
		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' )
		begin
		set @query4=@query4+' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 

		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' )
		begin
		set @query4=@query4+' and a.Insertion_date  between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 
end
if(@base='2')begin
set @query4=@query4+' and (a.Executive_code is not null and a.Executive_code<>'''' and a.Executive_code !=''0'')  '
end 

if(@base='3')begin
set @query4=@query4+' and (a.RETAINER is not null and a.RETAINER<>''''  and a.RETAINER !=''0'')  '
end 


if(@drpstatus is null or  @drpstatus = '') begin
set @query4=@query4+' and lower(Insert_Status)!=''cancel'''
end 
if(@insertstatus is not null and @insertstatus<>'') begin
set @query4=@query4+' and lower(Insert_Status)='''+@insertstatus+''''
end 




IF(@publication IS NOT NULL)
begin
set @query4=@query4+' and TBL_BOOKING_insert.publication_Code='''+@publication+'''    '
END 

/*IF(@pub_cent IS NOT NULL)
begin
--set @query4=@query4+'  and tbl_booking_insert.Pub_Cent_Code='''+pub_cent+''''
set @query4=@query4+'  and a.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE a.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code='''+@pub_cent+'''))'

END

IF(@branch IS NOT NULL  and @branch<>'')
begin
set @query4=@query4+'  and a.branch ='''+@branch+''''
END*/


--old version
/*IF(@publication IS NOT NULL)
begin
set @query4=@query4+'  and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_mast."branch" ='''||p_branch||'''';
END IF;
*/

--new version
IF(@pub_cent IS NOT NULL)
begin
set @query4=@query4+'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
END 


IF(@branch IS NOT NULL  and @branch<>'')
begin
set @query4=@query4+'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
END 


IF(@edition IS NOT NULL  and @edition<>'')
begin
set @query4=@query4+'  and tbl_booking_insert.Edition_Code='''+@edition+''''
END 

 

IF(@region IS NOT NULL and @region <>'')
begin
--set @query4=@query4 +' and tbl_booking_insert.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+region +''')'
set @query4=@query4 +' and agency_mast.region ='''+@region +''' '
END 

IF(@revcenter IS NOT NULL and @revcenter <>'')
begin
set @query4=@query4 +' and a.Revenue_center ='''+@revcenter+''''
END 

IF(@adtype IS NOT NULL and @adtype <>'')
begin
set @query4=@query4 + ' and a.Ad_type_code='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype <>'')
begin
set @query4=@query4 + ' and a.Agency_type ='''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat <>'')
begin
set @query4=@query4 + ' and a.Ad_cat_code ='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat <>'')
begin
set @query4=@query4 + ' and a.Ad_sub_cat_code ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'')
begin
set @query4=@query4 + ' and a.Ad_Subcat3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'')
begin
set @query4=@query4 + ' and a.Ad_Subcat4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'')
begin
set @query4=@query4 + ' and a.Ad_subcat5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package <>'')
begin
set @query4=@query4 + ' and a.Package_code ='''+@package+''''
END 

IF(@scheme IS NOT NULL and @scheme <>'')
begin
set @query4=@query4 + ' and a.Scheme_type_code ='''+@scheme+''''
END 

IF(@agency IS NOT NULL and @agency <>'')
begin
set @query4=@query4 + ' and a.Agency_code ='''+@agency+''''
END 

IF(@client IS NOT NULL and @client  <>'')
begin
set @query4=@query4 + ' and a.Client_code ='''+@client+''''
END 

IF(@executive IS NOT NULL and @executive <>'')
begin
set @query4=@query4 + ' and a.Executive_code ='''+@executive+''''
END 

IF(@retainer IS NOT NULL and @retainer <>'')
begin
set @query4=@query4 + ' and a.RETAINER ='''+@retainer+''''
END 

IF(@product IS NOT NULL and @product <>'')
begin
set @query4=@query4 + ' and a.Product_code ='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand <>'')
begin
set @query4=@query4 + ' and a.Brand_code ='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient <>'')
begin
set @query4=@query4 + ' and a.Variant_code ='''+@varient+''''
END 

IF(@pagetype IS NOT NULL and @pagetype <>'')
begin
set @query4=@query4 + ' and a.Page_type_code ='''+@pagetype+''''
END 

IF(@pageprem IS NOT NULL and @pageprem <>'')
begin
set @query4=@query4 + ' and a.Page_prem ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem <>'')
begin
set @query4=@query4 + ' and a.Page_position_code ='''+@postprem+''''
END 

IF(@rostatus IS NOT NULL and @rostatus <>'')
begin
set @query4=@query4 + ' and a.ro_status ='''+@rostatus+''''
END 

IF(@booktype IS NOT NULL and @booktype <>'')
begin
set @query4=@query4 + ' and a.Booking_type ='''+@booktype+''''
END 

IF(@contractname  IS NOT NULL and @contractname  <>'')
begin
set @query4=@query4 + ' and a.Contract_name ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment  <>'')
begin
set @query4=@query4 + ' and tbl_booking_insert.Supp_Code ='''+@suppliment+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype  <>'')
begin
set @query4=@query4 + ' and a.Rate_code ='''+@ratetype+''''
END 

IF(@city  IS NOT NULL and @city  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.City_Code ='''+@city+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code ='''+@city+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.City_Code='''+@city+''')'
end 
END 

IF(@zone  IS NOT NULL and @zone  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.zone_code ='''+@zone+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= '''+@zone+''') )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Zone_Code='''+@zone+''')'
end 
END 

IF(@district  IS NOT NULL and @district  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.Dist_Code ='''+@district+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code ='''+@district+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Dist_Code='''+@district+''')'
end 
END 

IF(@state  IS NOT NULL and @state  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.State_Code ='''+@state+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code ='''+@state+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.State_Code='''+@state+''')'
end 
END 

IF(@taluka  IS NOT NULL and @taluka  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.TALUKA='''+@taluka+'''  '
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA ='''+@taluka+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.TALUKA='''+@taluka+''')'
end 
END 

set @query4=@query4 + ' order by a.cio_booking_id'
print(@query1+@query4)
exec(@query1+@query4)



--print(@query1)
--exec(@query1)
end 

else if(@adcheck=2)begin
open c2
fetch next from c2
into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME

print(@@FETCH_STATUS)
while @@FETCH_STATUS=0

begin

insert into #temp_ad_bills_report select * from dbo.FUN_BILL_INSERT(@compcode,@v2_CIOID,@v2_BILLNO,@prefer,@dateformat,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME,@base )  

fetch next from c2
into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME

end
close c2



set @query2='select CIOID AS "CIOID",BILLNO AS "Billno" ,AGENCY AS "Agency", CLIENT AS "Client" ,
RONO  AS "RoNo.",
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),RODATE,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),RODATE,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),RODATE,111) END AS "Ro.Date",
EXECUTIVE  AS "Executive",RETAINER  AS "Retainer" ,BOOKTYPE as "BookType",COLOR as "Color",ADCAT as "Adcat",
ADSUBCAT as "Adsubcat",ADSUBCAT3 as "Adsubcat3",ADSUBCAT4  as "Adsubcat4",ADSUBCAT5 as "Adsubcat5",PACKAG AS "Package",
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),BILLDATE,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),BILLDATE,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),BILLDATE,111) END AS "BillDate",
NOINSERT as "noinsert",PAIDINSERT as "Paidinsert" ,HEIGHT as "height",WIDTH as "width",AREA as "Area",PAGEPREMIUM as "Pagepremium",POSTPREM as "Postprem",
SCHEME as "scheme",RATECOD as "Ratecode",CARDRATE as "cardrate",CARDAMT as "cardamt",
CONTRACTRATE as "contractrate",DEVIATIONAMT as "Deviationamt",DEVIATIONPER AS "Deviation(%)",
AGGRATE as "Aggrate",AGGAMT as "aggamt",DISCAMT as "DiscAmt",DISCPER as "Discper",
POSAMT as  "posamt",POSPER as "pos(%)",SPDISCAMT as "Spdiscamt",
SPDISCPER as "Spdiscper",SPACEDISC as "Spacedisc",SPACEDISCPER as "Spacediscper",SPECIALCHARGE as "Specialcharge",AGENCYADDLTDPER  as "AgencyAddlTD(%)",
AGENCYADDLTDAMT as "AgencyAddlTDAmt",GROSSAMT as "Grossamt",
RETTDPER as "RetTD(%)",RETTDAMT as "RetTDAmt",AGENCYTDPER as "AgencyTD(%)",AGENCYTDAMT as "AgencyTDAmt",BILLAMT as "Billamt",
RETCOMMPER as "RetComm(%)",RETCOMMAMT as "RetCommAmt",ACTUALBUSINESS as "ActualBusiness",
REVCENTER as "Revcenter",UOM AS "Uom",UOMDESC as "uomdesc"
,PUB_CENT_NAME as "Printcenter"
,BRANCH_NAME  as "Branch"
,DIST_NAME as "District"
,TALU_NAME as "Taluka"
,PAGE_NO as "Page_No"
from #temp_ad_bills_report where'

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL )
begin
set @query4= '  BILLDATE between  '''+@fromdate +''' and  '''+@dateto+''' '
END 

IF(@publication IS NOT NULL and @publication<>'')
begin
set @query4=@query4+ ' and PRIPUB='''+@publication+''''
END 

IF(@pub_cent IS NOT NULL and @pub_cent<>'')
begin
set @query4=@query4+ '   and PUB_CENT_CODE='''+@pub_cent+''''
END 

IF(@edition IS NOT NULL and @edition<>'')
begin
set @query4=@query4+ '  and PEDITION='''+@edition+''''
END 

IF(@branch IS NOT NULL and @branch<>'')
begin
set @query4=@query4+ '  and  BRANCH_NAME ='''+@branch+''' '
END 

IF(@region IS NOT NULL and @region<>'')
begin
set @query4=@query4 +' and REGION='''+@region +''''
END 

IF(@adtype IS NOT NULL and @adtype<>'')
begin
set @query4=@query4 + ' and PADTYPE='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype<>'')
begin
set @query4=@query4 + ' and AGENCY_TYPE_CODE= '''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat<>'')
begin
set @query4=@query4 + ' and PRIADCTG='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat<>'')
begin
set @query4=@query4 + ' and SECADCTG ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3<>'')
begin
set @query4=@query4 + ' and AD_SUBCAT3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4<>'')
begin
set @query4=@query4 + ' and AD_SUBCAT4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5<>'')
begin
set @query4=@query4 + ' and AD_SUBCAT5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package<>'')
begin
set @query4=@query4 + ' and PACKAGE_CODE='''+@package+''''
END 

IF(@agency IS NOT NULL and @agency<>'')
begin
set @query4=@query4 + ' and AG_MAIN_CODE ='''+@agency +''''
END 

IF(@client IS NOT NULL and @client<>'')
begin
set @query4=@query4 + ' and CLIENTCD='''+@client +''''
END 

IF(@executive IS NOT NULL and @executive<>'')
begin
set @query4=@query4 + ' and EXECUTIVE_NAME='''+@executive+''''
END 

IF(@product IS NOT NULL and @product<>'')
begin
set @query4=@query4 + ' and PRIPROCTG='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand<>'')
begin
set @query4=@query4 + ' and BRAND_CODE='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient<>'')
begin
set @query4=@query4 + ' and   VARIENT_NAME='''+@varient+''''
END 

IF(@pageprem IS NOT NULL and @pageprem<>'')
begin
set @query4=@query4 + ' and PAGE_PREM ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem<>'')
begin
set @query4=@query4 + ' and PAGE_POST ='''+@postprem+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'')
begin
set @query4=@query4 + ' and CONTRACT_NAME ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment<>'')
begin
set @query4=@query4 + ' and SUPP_CODE='''+@suppliment+''''
END 

IF(@retainer IS NOT NULL and @retainer<>'')
begin
set @query4=@query4 + ' and RETAINER_CODE='''+@retainer+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype<>'')
begin
set @query4=@query4 + ' and RATECD ='''+@ratetype+''''
END 

IF(@scheme IS NOT NULL and @scheme<>'')
begin
set @query4=@query4 + ' and PSCHEME='''+@scheme+''''
END 

IF(@revcenter IS NOT NULL and @revcenter<>'')
begin
set @query4=@query4 +' and REVENUE_CENTER='''+@revcenter+''''
END 

IF(@rostatus IS NOT NULL and @rostatus<>'')
begin
set @query4=@query4 + ' and RO_STATUS='''+@rostatus+''''
END 

IF(@pagetype IS NOT NULL and @pagetype<>'')
begin
set @query4=@query4 + ' and PAGE_TYPE ='''+@pagetype+''''
END 

IF(@booktype IS NOT NULL and @booktype<>'')
begin
set @query4=@query4 + ' and BOOKING_TYPE='''+@booktype+''''
END 

IF(@city  IS NOT NULL and @city<>'')
begin
set @query4=@query4 + ' and CITY_CODE ='''+@city+''''
END 

IF(@zone  IS NOT NULL and @zone<>'')
begin
set @query4=@query4 + ' and ZONE_CODE ='''+@zone+''''
end 

IF(@district  IS NOT NULL and @district<>'')
begin
set @query4=@query4 + ' and DIST_CODE ='''+@district+''''
end 

IF(@state  IS NOT NULL and @state<>'')
begin
set @query4=@query4 + ' and STATE_CODE ='''+@state+''''
end 

IF(@taluka  IS NOT NULL and @taluka<>'')
begin
set @query4=@query4 + ' and PTALUKA='''+@taluka+'''  '
end 


if(@base='2')begin
set @query4=@query4 +' and (EXECUTIVE_NAME   is not null and EXECUTIVE_NAME !=''0'')  '
end 

if(@base='3')begin
set @query4=@query4 +' and (RETAINER_CODE  is not null  and RETAINER_CODE  !=''0'')  '
end 



set @query4=@query4 + ' order by CIOID'


print(@query2+@query4)
exec(@query2+@query4)
end 

else if(@adcheck=3) begin
set @query3='SELECT  TBL_BOOKING_MAST.cio_booking_id AS CIOID,
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),TBL_BOOKING_MAST.date_time,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),TBL_BOOKING_MAST.date_time,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),TBL_BOOKING_MAST.date_time,111) END as BookDate,
AGENCY_MAST.Agency_Name AS Agency,
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS Client,
RO_No AS "RoNo.",
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),RO_Date,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),RO_Date,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),RO_Date,111) END AS "Ro.Date",
(select EXEC_MAST.Exec_name from exec_mast where tbl_booking_mast.Executive_code=exec_mast.Exe_no) AS Executive,
(select RETAINERMASTER.Retain_Name  FROM  RETAINERMASTER where RETAINERMASTER.Retain_Code=tbl_booking_mast.RETAINER ) AS Retainer,
case tbl_booking_mast.Booking_type
when ''1'' then ''Barter''
when ''2'' then ''FMG''
when ''3'' then ''Normal''
when ''4'' then ''InHouse''
when ''5'' then ''Complimentary''
else ''Normal'' end as BookType,
(select col_mast.Col_Alias from col_mast where tbl_booking_insert.Col_Code =col_mast.Col_Code) as Color,
adv_cat_mast.Adv_Cat_Name as Adcat,
(select adv_subcat_mast.Adv_Subcat_Name from adv_subcat_mast where tbl_booking_mast.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code)as Adsubcat,
(select ad_cat3.catname from ad_cat3,adv_subcat_mast  where tbl_booking_mast.Ad_Subcat3=ad_cat3.catcode and ad_cat3.subcatname=adv_subcat_mast.Adv_Subcat_Code and tbl_booking_mast.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code) as Adsubcat3,
(select tbl_cat4.Cat_Name from tbl_cat4,adv_subcat_mast where tbl_booking_mast.Ad_Subcat4=tbl_cat4.Cat_Code and tbl_cat4.Sub_Cat_Name=adv_subcat_mast.Adv_Subcat_Code and tbl_booking_mast.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code) as Adsubcat4,
(select tbl_cat5.Cat_Name from tbl_cat5,adv_subcat_mast where tbl_booking_mast.Ad_subcat5=tbl_cat5.Cat_Code and tbl_cat5.Sub_Cat_Name=adv_subcat_mast.Adv_Subcat_Code and tbl_booking_mast.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code) as Adsubcat5,
dbo.FETCH_PACK(tbl_booking_mast.cio_booking_id) AS Package,
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),tbl_booking_insert.Insert_Date,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),tbl_booking_insert.Insert_Date,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),tbl_booking_insert.Insert_Date,111) END as PubDate,
 tbl_booking_insert.Height as "height",
 tbl_booking_insert.Width  as "width",
tbl_booking_insert.Size_Book as Area,
(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_insert.Premium1=ADVPOS_PREM_MAST.Premiumcode) as Pagepremium,
(select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_insert.Page_Post=advpos_type_mast.Pos_Type_Code) as Postprem,
(select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id) as scheme,
tbl_booking_mast.Rate_code as Ratecode,
tbl_booking_mast.Card_rate as cardrate,
tbl_booking_mast.Card_rate*tbl_booking_insert.Size_Book as cardamt,
tbl_booking_mast.Contract_rate as contractrate,
TBL_BOOKING_mast.Deviation as Deviationamt,
TBL_BOOKING_mast.Deviation AS  "Deviation(%)",
tbl_booking_mast.Agrred_rate as Aggrate,
tbl_booking_insert.Agreed_Rate  as aggamt,
((tbl_booking_mast.Card_rate*tbl_booking_insert.Size_Book) - 
case isnull(tbl_booking_insert.Agreed_Rate,0)
when 0 then (tbl_booking_mast.Card_rate*tbl_booking_insert.Size_Book)
else tbl_booking_insert.Agreed_Rate end)  as DiscAmt,
tbl_booking_mast.Discount_per as Discper,
dbo.FETCH_RATAMT(tbl_booking_mast.cio_booking_id ,''1'',''1'') as  posamt,
dbo.FETCH_RATAMT(tbl_booking_mast.cio_booking_id,''2'',''1'')  as  "pos(%)",
round(((tbl_booking_mast.Special_disc_per * tbl_booking_insert.Size_Book * tbl_booking_mast.Card_rate)/100),2) as Spdiscamt,
tbl_booking_mast.Special_disc_per as Spdiscper,
round(((tbl_booking_mast.Space_disc_per * tbl_booking_insert.Size_Book * tbl_booking_mast.Card_rate)/100),2) as Spacedisc,
tbl_booking_mast.Space_disc_per as Spacediscper,
tbl_booking_mast.Special_charges as Specialcharge,
isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'') as  "AgencyAddlTD(%)",
isnull((isnull(tbl_booking_insert.Gross_Rate ,''0'')*isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'')/100),''0'') as AgencyAddlTDAmt,
isnull(tbl_booking_insert.Gross_Rate,''0'') as Grossamt,
isnull(dbo.fun_actual('''+ @compcode +''',isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),isnull(tbl_booking_mast.RETAINER,''0''),isnull(tbl_booking_insert.Gross_Rate,''0''),'''+@prefer+''',''3'' ),''0'')as  "RetTD(%)",
isnull(dbo.fun_actual('''+ @compcode +''',isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),isnull(tbl_booking_mast.RETAINER,''0''),isnull(tbl_booking_insert.Gross_Rate,''0''),'''+@prefer+''',''4'' ),''0'')as RetTDAmt,
isnull(tbl_booking_mast.Trade_disc,''0'' )as "AgencyTD(%)",
(isnull(tbl_booking_insert.Gross_Rate,''0'')* isnull(tbl_booking_mast.Trade_disc,''0'' )/100 )as AgencyTDAmt,
isnull(TBL_BOOKING_INSERT.Bill_Amt,''0'') as Billamt,
isnull(dbo.fun_actual('''+ @compcode +''',isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),isnull(tbl_booking_mast.RETAINER,''0''),isnull(tbl_booking_insert.Gross_Rate,''0''),'''+@prefer+''',''1'' ),''0'') as "RetComm(%)",
isnull(dbo.fun_actual('''+ @compcode +''',isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),isnull(tbl_booking_mast.RETAINER,''0''),isnull(tbl_booking_insert.Gross_Rate,''0''),'''+@prefer+''',''2'' ),''0'') as RetCommAmt,
isnull((  isnull(TBL_BOOKING_INSERT.Bill_Amt,''0'')-isnull(dbo.fun_actual('''+ @compcode +''',isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),isnull(tbl_booking_mast.RETAINER,''0''),isnull(tbl_booking_insert.Gross_Rate,''0''),'''+@prefer+''',''2'' ),''0'')  ),''0'') as ActualBusiness,
(SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE tbl_booking_mast.Revenue_center=BRANCH_MST.Branch_Code )as Revcenter
,UOM_MAST.Uom_Name  AS Uom,
pub_mast.Pub_Name as publication,
TBL_BOOKING_INSERT.Edition as Edition,
uom_mast.UOM_DESC as uomdesc
,(select top 1 pub_cent_mast.Pub_Cent_name from pub_cent_mast where pub_cent_mast.Pub_cent_Code in(select pub_center from  BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name) ) as Printcenter
,tbl_booking_mast.branch as Branch
,case '''+@base+'''
when ''1'' then  AGENCY_MAST.Dist_Code
when ''2'' then (select dist_mst.Dist_Name from dist_mst where dist_mst.Dist_Code in(select exec_mast.dist_code from exec_mast where  exec_mast.Exe_no=tbl_booking_mast.Executive_code )  )
when ''3'' then (select dist_mst.Dist_Name from dist_mst where dist_mst.Dist_Code in(select RETAINERMASTER.Dist_Code from RETAINERMASTER where  RETAINERMASTER.Retain_Code= tbl_booking_mast.RETAINER )  ) end as District
,case '''+@base+'''
when ''1'' then (select taluka_mast.TALU_NAME  from taluka_mast where AGENCY_MAST.TALUKA=taluka_mast.TALU_CODE )
when ''2'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select exec_mast.TALUKA from exec_mast where  exec_mast.Exe_no=tbl_booking_mast.Executive_code )  )
when ''3'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select RETAINERMASTER.TALUKA from RETAINERMASTER where  RETAINERMASTER.Retain_Code= tbl_booking_mast.RETAINER )  ) end as Taluka,
tbl_booking_insert.Page_No as "Page_No"
,CASHDISCOUNT as "Cash_Disc"
,Insert_Status as "Status"
,Box_code as "BoxCode",
a.Userid as USERID,(SELECT max(username) from login where com_code = a.Comp_code and userid=a.Userid) as USERNAME
FROM TBL_BOOKING_MAST,AGENCY_MAST ,uom_mast,
adv_cat_mast,adv_type_mast,pub_mast,TBL_BOOKING_insert'

set @query4=' WHERE TBL_BOOKING_MAST.Comp_code='''+@compcode+''' AND
UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
tbl_booking_insert.Ad_Cat=adv_cat_mast.Adv_Cat_Code and
tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code
and adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
pub_mast.Pub_Code=TBL_BOOKING_insert.publication_Code and
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id '
--and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
--or  ('''+@chk_access+'''=''0'') )' 

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL)
begin
set @query4=@query4+' and tbl_booking_insert.Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
END

if(@base='2')begin
set @query4=@query4 +' and (tbl_booking_mast.Executive_code is not null and tbl_booking_mast.Executive_code !=''0'')  '
end 

if(@base='3')begin

 
set @query4=@query4 +' and (tbl_booking_mast.retainer IS NOT NULL and retainer <>''''  and tbl_booking_mast.RETAINER !=''0'')  '

end 


if(@drpstatus is null or  @drpstatus = '') begin
set @query4=@query4+' and lower(Insert_Status)!=''cancel'''
end 

if(@insertstatus is not null and @insertstatus<>'' ) begin
set @query4=@query4+' and lower(Insert_Status)='''+@insertstatus+''''
end 





IF(@publication IS NOT NULL)
begin
set @query4=@query4 +' and TBL_BOOKING_insert.publication_Code='''+@publication+'''    '
END 

/*IF(@pub_cent IS NOT NULL and @pub_cent <>'')
begin
--set @query4=@query4 +'  and tbl_booking_insert.Pub_Cent_Code='''+@pub_cent+''''
set @query4=@query4+'  and TBL_BOOKING_MAST.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code='''+@pub_cent+'''))'

END 
IF(@branch IS NOT NULL and @branch<>'')
begin
set @query4=@query4 +'  and tbl_booking_mast.branch ='''+@branch+''''
END 

*/

IF(@pub_cent IS NOT NULL)
begin
set @query4=@query4+'  and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
END 


IF(@branch IS NOT NULL  and @branch<>'')
begin
set @query4=@query4+'  and TBL_BOOKING_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
END 


IF(@edition IS NOT NULL and @edition<>'')
begin
set @query4=@query4 +'  and tbl_booking_insert.Edition_Code='''+@edition+''''
END 



IF(@region IS NOT NULL and @region <>'')
begin
--set @query4=@query4  +' and tbl_booking_insert.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+@region +''')'
set @query4=@query4  +' and agency_mast.region ='''+@region+''''

END 

IF(@revcenter IS NOT NULL and @revcenter <>'')
begin
set @query4=@query4  +' and tbl_booking_mast.Revenue_center ='''+@revcenter+''''
END 

IF(@adtype IS NOT NULL and @adtype <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_type_code='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Agency_type ='''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_insert.Ad_Cat ='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_sub_cat_code ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_Subcat3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_Subcat4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_subcat5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Package_code ='''+@package+''''
END 

IF(@scheme IS NOT NULL and @scheme <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Scheme_type_code ='''+@scheme+''''
END 

IF(@agency IS NOT NULL and @agency <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Agency_code ='''+@agency+''''
END 

IF(@client IS NOT NULL and @client  <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Client_code ='''+@client+''''
END 

IF(@executive IS NOT NULL and @executive <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Executive_code ='''+@executive+''''
END 

IF(@retainer IS NOT NULL and @retainer <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.RETAINER ='''+@retainer+''''
END 

IF(@product IS NOT NULL and @product <>'')
begin
set @query4=@query4 + ' and TBL_BOOKING_MAST.Product_code ='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Brand_code ='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Variant_code ='''+@varient+''''
END 

IF(@pagetype IS NOT NULL and @pagetype <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Page_type_code ='''+@pagetype+''''
END 

IF(@pageprem IS NOT NULL and @pageprem <>'')
begin
set @query4=@query4 + ' and TBL_BOOKING_insert.Premium1 ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem <>'')
begin
set @query4=@query4 + ' and TBL_BOOKING_insert.Page_Post ='''+@postprem+''''
END 

IF(@rostatus IS NOT NULL and @rostatus <>'')
begin
set @query4=@query4 + ' and TBL_BOOKING_MAST.ro_status ='''+@rostatus+''''
END 

IF(@booktype IS NOT NULL and @booktype <>'')
begin
set @query4=@query4 + ' and TBL_BOOKING_MAST.Booking_type ='''+@booktype+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'')
begin
set @query4=@query4 + ' and TBL_BOOKING_MAST.Contract_name ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment  <>'')
begin
set @query4=@query4 + ' and tbl_booking_insert.Supp_Code ='''+@suppliment+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype  <>'')
begin
set @query4=@query4 + ' and tbl_booking_MAST.Rate_code ='''+@ratetype+''''
END 

IF(@city  IS NOT NULL and @city  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.City_Code ='''+@city+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and tbl_booking_mast.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code ='''+@city+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.City_Code='''+@city+''')'
end 
END 

IF(@zone  IS NOT NULL and @zone  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.zone_code ='''+@zone+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and tbl_booking_mast.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= '''+@zone+''') )'
end 

if(@base='3')begin
set @query4=@query4 + ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Zone_Code='''+@zone+''')'
end 
END 

IF(@district  IS NOT NULL and @district  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.Dist_Code ='''+@district+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and tbl_booking_mast.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code ='''+@district+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Dist_Code='''+@district+''')'
end
END 

IF(@state  IS NOT NULL and @state  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.State_Code ='''+@state+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and tbl_booking_mast.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code ='''+@state+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.State_Code='''+@state+''')'
end
END 

IF(@taluka  IS NOT NULL and @taluka  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.TALUKA='''+@taluka+'''  '
end 

if(@base='2')begin
set @query4=@query4 + ' and tbl_booking_mast.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA ='''+@taluka+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.TALUKA='''+@taluka+''')'
end
END 

set @query4=@query4 + ' order by tbl_booking_insert.Insert_Date ,TBL_BOOKING_MAST.cio_booking_id'

print(@query3+@query4)
exec(@query3+@query4)

end end

else

if(@adcheck=1)
begin
print('prachi')
print(@adsubcat3)
print(@adsubcat4)
set @query1='SELECT
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),a.date_time,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),a.date_time,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),a.date_time,111) END as "Date",
sum(a.No_of_insertion) as noinsert,
sum(a.Paid_ins) as Paidinsert,sum(a.Total_area) as Area,
sum(a.Card_amount) as cardamt,
sum(a.Deviation) as Deviationamt,
round(((isnull(sum(a.Deviation),0)*100)/sum(a.Card_amount)),2) AS  "Deviation(%)",
sum(a.Agreed_amount) as aggamt,
(sum(a.Card_amount)-
case isnull(sum(a.Agreed_amount),0)
when 0 then sum(a.Card_amount)
else sum(a.Agreed_amount) end)  as DiscAmt,
round((((sum(a.Card_amount)- 
case isnull(sum(a.Agreed_amount),0)
when 0 then sum(a.Card_amount)
else sum(a.Agreed_amount) end ) *100) /sum(a.Card_amount)),2)  as Discper,
sum(dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1'')) as  posamt,
round(((sum(dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1''))*100)/sum(a.Card_amount)),2)   as  "pos(%)",
sum(a.Special_disc_per * a.Total_area * a.Card_rate/100) as Spdiscamt,
round(((sum(a.Special_disc_per * a.Total_area * a.Card_rate/100)*100)/sum(a.Card_amount)),2)  as Spdiscper,
sum(a.Space_disc_per * a.Total_area * a.Card_rate/100) as Spacedisc,
round(((sum(a.Space_disc_per * a.Total_area * a.Card_rate/100) *100)/sum(a.Card_amount)),2) as Spacediscper,
sum(a.Special_charges) as Specialcharge,
round(((sum(isnull((isnull(a.Gross_amount,''0'')*isnull(a.ADD_AGENCY_COMM,''0'')/100),''0''))*100)/(sum(a.Card_amount)+sum(dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1''))+sum(a.Special_charges)-sum(a.Deviation)-(sum(a.Card_amount)- 
case isnull(sum(a.Agreed_amount),0)
when 0 then sum(a.Card_amount)
else sum(a.Agreed_amount) end) -sum(a.Space_disc_per * a.Total_area * a.Card_rate/100)-sum(a.Special_disc_per * a.Total_area * a.Card_rate/100))),2) as  "AgencyAddlTD(%)",
sum(isnull((isnull(a.Gross_amount,''0'')*isnull(a.ADD_AGENCY_COMM,''0'')/100),''0'')) as AgencyAddlTDAmt,
sum(isnull(a.Gross_amount,''0'')) as Grossamt,
round(((sum(isnull(dbo.fun_actual('''+@compcode+''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''4'' ),''0''))*100)/sum(isnull(a.Gross_amount,''0''))),2) as  "RetTD(%)",
sum(isnull(dbo.fun_actual('''+@compcode+''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''4'' ),''0''))as RetTDAmt,
round(((sum((isnull(a.Gross_amount,''0'')* isnull(a.Trade_disc,''0'' )/100) )*100)/(sum(a.Card_amount)+sum(dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1''))+sum(a.Special_charges)-sum(a.Deviation)-(sum(a.Card_amount)- 
case isnull(sum(a.Agreed_amount),0)
when 0 then sum(a.Card_amount)
else sum(a.Agreed_amount)end) -sum(a.Space_disc_per * a.Total_area * a.Card_rate/100)-sum(a.Special_disc_per * a.Total_area * a.Card_rate/100))),2)as "AgencyTD(%)",
sum((isnull(a.Gross_amount,''0'')* isnull(a.Trade_disc,''0'' )/100) )as AgencyTDAmt,
sum(isnull(a.Bill_amount,''0'')) as Billamt,
round(((sum(isnull(dbo.fun_actual('''+@compcode+''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''2'' ),''0''))*100)/sum(isnull(a.Gross_amount,''0''))),2) as "RetComm(%)",
sum(isnull(dbo.fun_actual('''+@compcode+''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''2'' ),''0'')) as RetCommAmt,
sum(isnull((a.Bill_amount-isnull(dbo.fun_actual('''+@compcode+''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''2'' ),''0'')  ),''0'') )as ActualBusiness
FROM TBL_BOOKING_MAST a,
agency_mast
WHERE a.Comp_code='''+@compcode+''' AND
a.Agency_sub_code=AGENCY_MAST.code_subcode' 
if(@query4='' or @query4 is null) begin

		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' )
		begin
		set @query4=' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 


		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' )
		begin
		set @query4=' and a.Insertion_date  between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 

end
else
begin 

      IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' )
		begin
		set @query4=@query4+' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 


		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' )
		begin
		set @query4=@query4+' and a.Insertion_date  between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 

end
/*if(@chk_access='1')begin
set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where a.cio_booking_id=b.Cio_Booking_Id and b.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''')) ';
end 
*/
if(@base='2')begin
set @query4=@query4+' and (a.Executive_code is not null and a.Executive_code !=''0'')  '
end 

if(@base='3')begin
set @query4=@query4+' and (a.retainer IS NOT NULL and retainer <>''  and a.RETAINER !=''0'')  '
end 


if(@drpstatus is null or  @drpstatus = '') begin
set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where a.cio_booking_id=b.Cio_Booking_Id AND lower(Insert_Status)!='''+'cancel'+''' )'
end 

if(@insertstatus is not null and @insertstatus<>'') begin
set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where a.cio_booking_id=b.Cio_Booking_Id AND lower(Insert_Status)='''+@insertstatus+''' )';
end 




IF(@publication IS NOT NULL)
begin
set @query4=@query4+'  and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.publication_Code='''+@publication+''' )    '
END 

/*
IF(@pub_cent IS NOT NULL and @pub_cent <>'')
begin
--set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Pub_Cent_Code='''+@pub_cent+''' )  '
set @query4=@query4+'  and a.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE a.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code='''+@pub_cent+'''))'

END 
IF(@branch IS NOT NULL and @branch<>'')
begin
set @query4=@query4+' and a.branch ='''+@branch+''''
END 
*/



IF(@pub_cent IS NOT NULL)
begin
set @query4=@query4+'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
END 


IF(@branch IS NOT NULL  and @branch<>'')
begin
set @query4=@query4+'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
END 


IF(@edition IS NOT NULL and @edition<>'')
begin

set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Edition_Code='''+@edition+''' )'
END 



IF(@region IS NOT NULL and @region <>'')
begin
--set @query4=@query4 +'  and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+@region +''') )'
set @query4=@query4 +'  and agency_mast.region ='''+@region+''''
END 

IF(@suppliment  IS NOT NULL and @suppliment  <>'')
begin
set @query4=@query4 + '  and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Supp_Code ='''+@suppliment+''' )'
END 







IF(@revcenter IS NOT NULL and @revcenter <>'')
begin
set @query4=@query4 +' and a.Revenue_center ='''+@revcenter+''''
END 

IF(@adtype IS NOT NULL and @adtype <>'')
begin
set @query4=@query4 + ' and a.Ad_type_code='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype <>'')
begin
set @query4=@query4 + ' and a.Agency_type ='''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat <>'')
begin
set @query4=@query4 + ' and a.Ad_cat_code ='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat <>'')
begin
set @query4=@query4 + ' and a.Ad_sub_cat_code ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'')
begin
set @query4=@query4 + ' and a.Ad_Subcat3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'')
begin
set @query4=@query4 + ' and a.Ad_Subcat4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'')
begin
set @query4=@query4 + ' and a.Ad_subcat5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package <>'')
begin
set @query4=@query4 + ' and a.Package_code ='''+@package+''''
END 

IF(@scheme IS NOT NULL and @scheme <>'')
begin
set @query4=@query4 + ' and a.Scheme_type_code ='''+@scheme+''''
END 

IF(@agency IS NOT NULL and @agency <>'')
begin
set @query4=@query4 + ' and a.Agency_code ='''+@agency+''''
END 

IF(@client IS NOT NULL and @client  <>'')
begin
set @query4=@query4 + ' and a.Client_code ='''+@client+''''
END 

IF(@executive IS NOT NULL and @executive <>'')
begin
set @query4=@query4 + ' and a.Executive_code ='''+@executive+''''
END 

IF(@retainer IS NOT NULL and @retainer <>'')
begin
set @query4=@query4 + ' and a.RETAINER ='''+@retainer+''''
END 

IF(@product IS NOT NULL and @product <>'')
begin
set @query4=@query4 + ' and a.Product_code ='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand <>'')
begin
set @query4=@query4 + ' and a.Brand_code ='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient <>'')
begin
set @query4=@query4 + ' and a.Variant_code ='''+@varient+''''
END 

IF(@pagetype IS NOT NULL and @pagetype <>'')
begin
set @query4=@query4 + ' and a.Page_type_code ='''+@pagetype+''''
END 

IF(@pageprem IS NOT NULL and @pageprem <>'')
begin
set @query4=@query4 + ' and a.Page_prem ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem <>'')
begin
set @query4=@query4 + ' and a.Page_position_code ='''+@postprem+''''
END 

IF(@rostatus IS NOT NULL and @rostatus <>'')
begin
set @query4=@query4 + ' and a.ro_status ='''+@rostatus+''''
END 

IF(@booktype IS NOT NULL and @booktype <>'')
begin
set @query4=@query4 + ' and a.Booking_type ='''+@booktype+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'')
begin
set @query4=@query4 + ' and a.Contract_name ='''+@contractname +''''
END 



IF(@ratetype  IS NOT NULL and @ratetype  <>'')
begin
set @query4=@query4 + ' and a.Rate_code ='''+@ratetype+''''
END 

IF(@city  IS NOT NULL and @city  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.City_Code ='''+@city+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code ='''+@city+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RET.Retain_Code from  RETAINERMASTER RET where  RET.City_Code='''+@city+''')'
end 
END 

IF(@zone  IS NOT NULL and @zone  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.zone_code ='''+@zone+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= '''+@zone+''') )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RET.Retain_Code from  RETAINERMASTER RET where  RET.Zone_Code='''+@zone+''')'
end 
END 

IF(@district  IS NOT NULL and @district  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.Dist_Code ='''+@district+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code ='''+@district+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RET.Retain_Code from  RETAINERMASTER RET where  RET.Dist_Code='''+@district+''')'
end 
END 

IF(@state  IS NOT NULL and @state  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.State_Code ='''+@state+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code ='''+@state+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RET.Retain_Code from  RETAINERMASTER RET where  RET.State_Code='''+@state+''')'
end 
END 

IF(@taluka  IS NOT NULL and @taluka  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.TALUKA='''+@taluka+'''  '
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA ='''+@taluka+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RET.Retain_Code from  RETAINERMASTER RET where  RET.TALUKA='''+@taluka+''')'
end 
END 

set @query4=@query4 + ' group by a.date_time order by Date '



print(@query1+@query4)
exec(@query1+@query4)
end

else if(@adcheck=2)begin


open c2
fetch next from c2
into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME
while @@FETCH_STATUS=0
begin
insert into #temp_ad_bills_report select * from dbo.FUN_BILL_INSERT(@compcode,@v2_CIOID,@v2_BILLNO,@prefer,@dateformat,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME,@base )  
fetch next from c2
into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME

end
close c2



set @query2='SELECT 
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),BILLDATE,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),BILLDATE,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),BILLDATE,111) END AS "Date",
sum(NOINSERT) as "noinsert",
sum(PAIDINSERT) as "Paidinsert" ,
sum(AREA) as "Area",
sum(CARDAMT) as "cardamt",
sum(DEVIATIONAMT) as "Deviationamt",
case isnull(sum(CARDAMT),0)
when 0 then 0
else round(((isnull(sum(DEVIATIONAMT),0) *100)/isnull(sum(CARDAMT),0)),2) end  AS "Deviation(%)",

sum(AGGAMT)  as "aggamt",
sum(DISCAMT) as "DiscAmt",
case isnull(sum(CARDAMT),0)
when 0 then 0
else round(((isnull(sum(DISCAMT),0) *100)/isnull(sum(CARDAMT),0)),2) end as "Discper",

sum(POSAMT)as  "posamt",
case isnull(sum(CARDAMT),0)
when 0 then 0
else round(((isnull(sum(POSAMT),0) *100)/isnull(sum(CARDAMT),0)),2) end as "pos(%)",

sum(SPDISCAMT) as "Spdiscamt",
case isnull(sum(CARDAMT),0)
when 0 then 0
else round(((isnull(sum(SPDISCAMT),0)*100)/isnull(sum(CARDAMT),0)),2) end as "Spdiscper",

sum(SPACEDISC) as "Spacedisc",
case isnull(sum(CARDAMT),0)
when 0 then 0
else round(((isnull(sum(SPACEDISC),0)*100)/isnull(sum(CARDAMT),0)),2) end as "Spacediscper",

sum(SPECIALCHARGE) as "Specialcharge",
sum(AGENCYADDLTDAMT) as "AgencyAddlTDAmt",
case (isnull(sum(CARDAMT),0)+isnull(sum(POSAMT),0)+isnull(sum(SPECIALCHARGE),0)-isnull(sum(DEVIATIONAMT),0)-isnull(sum(DISCAMT),0)-isnull(sum(SPDISCAMT),0)-isnull(sum(SPACEDISC),0))
when 0 then 0
else round(((isnull(sum(AGENCYADDLTDAMT),0)*100)/(isnull(sum(CARDAMT),0)+isnull(sum(POSAMT),0)+isnull(sum(SPECIALCHARGE),0)-isnull(sum(DEVIATIONAMT),0)-isnull(sum(DISCAMT),0)-isnull(sum(SPDISCAMT),0)-isnull(sum(SPACEDISC),0))),2) end as "AgencyAddlTD(%)",

sum(GROSSAMT)  as "Grossamt",
sum(RETTDAMT)as "RetTDAmt",
case isnull(sum(GROSSAMT),0) 
when 0 then 0
else round(((isnull(sum(RETTDAMT),0)*100)/isnull(sum(GROSSAMT),0) ),2) end as "RetTD(%)",

sum(AGENCYTDAMT)as "AgencyTDAmt",
case (isnull(sum(CARDAMT),0)+isnull(sum(POSAMT),0)+isnull(sum(SPECIALCHARGE),0)-isnull(sum(DEVIATIONAMT),0)-isnull(sum(DISCAMT),0)-isnull(sum(SPDISCAMT),0)-isnull(sum(SPACEDISC),0))
when 0 then 0
else round(((isnull(sum(AGENCYTDAMT),0)*100)/(isnull(sum(CARDAMT),0)+isnull(sum(POSAMT),0)+isnull(sum(SPECIALCHARGE),0)-isnull(sum(DEVIATIONAMT),0)-isnull(sum(DISCAMT),0)-isnull(sum(SPDISCAMT),0)-isnull(sum(SPACEDISC),0))),2) end as "AgencyTD(%)",

sum(BILLAMT )as "Billamt",
sum(RETCOMMAMT)as "RetCommAmt",
case isnull(sum(GROSSAMT),0)
when 0 then 0
else round(((isnull(sum(RETCOMMAMT),0)*100)/isnull(sum(GROSSAMT),0)),2) end as "RetComm(%)",

sum(ACTUALBUSINESS)as "ActualBusiness"
from #temp_ad_bills_report where '



IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL )
begin
set @query4= '  BILLDATE between  '''+@fromdate +''' and  '''+@dateto+''' '
END 

IF(@publication IS NOT NULL and @publication<>'')
begin
set @query4=@query4+ ' and PRIPUB='''+@publication+''''
END 

IF(@pub_cent IS NOT NULL and @pub_cent<>'')
begin
set @query4=@query4+ '   and PUB_CENT_CODE='''+@pub_cent+''''
END 

IF(@edition IS NOT NULL and @edition<>'')
begin
set @query4=@query4+ '  and PEDITION='''+@edition+''''
END 

IF(@branch IS NOT NULL and @branch<>'')
begin
set @query4=@query4+ '  and  BRANCH_NAME ='''+@branch+''' '
END 

IF(@region IS NOT NULL and @region<>'')
begin
set @query4=@query4 +' and REGION='''+@region +''''
END 

IF(@adtype IS NOT NULL and @adtype<>'')
begin
set @query4=@query4 + ' and PADTYPE='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype<>'')
begin
set @query4=@query4 + ' and AGENCY_TYPE_CODE= '''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat<>'')
begin
set @query4=@query4 + ' and PRIADCTG='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat<>'')
begin
set @query4=@query4 + ' and SECADCTG ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3<>'')
begin
set @query4=@query4 + ' and AD_SUBCAT3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4<>'')
begin
set @query4=@query4 + ' and AD_SUBCAT4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5<>'')
begin
set @query4=@query4 + ' and AD_SUBCAT5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package<>'')
begin
set @query4=@query4 + ' and PACKAGE_CODE='''+@package+''''
END 

IF(@agency IS NOT NULL and @agency<>'')
begin
set @query4=@query4 + ' and AG_MAIN_CODE ='''+@agency +''''
END 

IF(@client IS NOT NULL and @client<>'')
begin
set @query4=@query4 + ' and CLIENTCD='''+@client +''''
END 

IF(@executive IS NOT NULL and @executive<>'')
begin
set @query4=@query4 + ' and EXECUTIVE_NAME='''+@executive+''''
END 

IF(@product IS NOT NULL and @product<>'')
begin
set @query4=@query4 + ' and PRIPROCTG='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand<>'')
begin
set @query4=@query4 + ' and BRAND_CODE='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient<>'')
begin
set @query4=@query4 + ' and   VARIENT_NAME='''+@varient+''''
END 

IF(@pageprem IS NOT NULL and @pageprem<>'')
begin
set @query4=@query4 + ' and PAGE_PREM ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem<>'')
begin
set @query4=@query4 + ' and PAGE_POST ='''+@postprem+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'')
begin
set @query4=@query4 + ' and CONTRACT_NAME ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment<>'')
begin
set @query4=@query4 + ' and SUPP_CODE='''+@suppliment+''''
END 

IF(@retainer IS NOT NULL and @retainer<>'')
begin
set @query4=@query4 + ' and RETAINER_CODE='''+@retainer+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype<>'')
begin
set @query4=@query4 + ' and RATECD ='''+@ratetype+''''
END 

IF(@scheme IS NOT NULL and @scheme<>'')
begin
set @query4=@query4 + ' and PSCHEME='''+@scheme+''''
END 

IF(@revcenter IS NOT NULL and @revcenter<>'')
begin
set @query4=@query4 +' and REVENUE_CENTER='''+@revcenter+''''
END 

IF(@rostatus IS NOT NULL and @rostatus<>'')
begin
set @query4=@query4 + ' and RO_STATUS='''+@rostatus+''''
END 

IF(@pagetype IS NOT NULL and @pagetype<>'')
begin
set @query4=@query4 + ' and PAGE_TYPE ='''+@pagetype+''''
END 

IF(@booktype IS NOT NULL and @booktype<>'')
begin
set @query4=@query4 + ' and BOOKING_TYPE='''+@booktype+''''
END 

IF(@city  IS NOT NULL and @city<>'')
begin
set @query4=@query4 + ' and CITY_CODE ='''+@city+''''
END 

IF(@zone  IS NOT NULL and @zone<>'')
begin
set @query4=@query4 + ' and ZONE_CODE ='''+@zone+''''
end 

IF(@district  IS NOT NULL and @district<>'')
begin
set @query4=@query4 + ' and DIST_CODE ='''+@district+''''
end 

IF(@state  IS NOT NULL and @state<>'')
begin
set @query4=@query4 + ' and STATE_CODE ='''+@state+''''
end 

IF(@taluka  IS NOT NULL and @taluka<>'')
begin
set @query4=@query4 + ' and PTALUKA='''+@taluka+'''  '
end 


if(@base='2')begin
set @query4=@query4 +' and (EXECUTIVE_NAME   is not null and EXECUTIVE_NAME !=''0'')  '
end 

if(@base='3')begin
set @query4=@query4 +' and (RETAINER_CODE  is not null  and RETAINER_CODE  !=''0'')  '
end 



set @query4=@query4 + ' group by BILLDATE'
set @query4=@query4 + ' order by BILLDATE'


print(@query2+@query4)
exec(@query2+@query4)
end 

else if(@adcheck=3) begin
set @query3='SELECT  distinct
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),b.Insert_Date,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),b.Insert_Date,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),b.Insert_Date,111) END as Date,
sum(a.No_of_insertion) as noinsert,
sum(a.Paid_ins) as Paidinsert,
sum(b.Size_Book) as Area,
sum(a.Card_rate*b.Size_Book) as cardamt,
sum(a.Deviation) as Deviationamt,
round(((sum(a.Deviation)*100)/sum(a.Card_rate*b.Size_Book)),2) AS  "Deviation(%)",
sum(b.Agreed_Rate)  as aggamt,
(sum(a.Card_rate*b.Size_Book)- 
case isnull(sum(b.Agreed_Rate),0)
when 0 then sum(a.Card_rate*b.Size_Book)
else sum(b.Agreed_Rate)end) as DiscAmt,
round((((sum(a.Card_rate*b.Size_Book)- 
case isnull(sum(b.Agreed_Rate),0)
when 0 then sum(a.Card_rate*b.Size_Book)
else sum(b.Agreed_Rate)end)*100)/sum(a.Card_rate*b.Size_Book)),2) as Discper,
sum(dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1'') )as  posamt,
round(((sum(dbo.FETCH_RATAMT(a.cio_booking_id,''1'',''1''))*100)/sum(a.Card_rate*b.Size_Book)),2)  as  "pos(%)",
sum(a.Special_disc_per * b.Size_Book * a.Card_rate/100) as Spdiscamt,
round(((sum(a.Special_disc_per * b.Size_Book * a.Card_rate/100)*100)/sum(a.Card_rate*b.Size_Book)),2) as Spdiscper,
sum(a.Space_disc_per * b.Size_Book * a.Card_rate/100) as Spacedisc,
round(((sum(a.Space_disc_per * b.Size_Book * a.Card_rate/100)*100)/sum(a.Card_rate*b.Size_Book)),2) as Spacediscper,
sum(a.Special_charges) as Specialcharge,
round(((sum(isnull((isnull(b.Gross_Rate ,''0'')*isnull(a.ADD_AGENCY_COMM,''0'')/100),''0''))*100)/(sum(a.Card_rate*b.Size_Book)+sum(dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1'') )+sum(a.Special_charges) -sum(a.Deviation)-(sum(a.Card_rate*b.Size_Book)- 
case isnull(sum(b.Agreed_Rate),0)
when 0 then sum(a.Card_rate*b.Size_Book)
else sum(b.Agreed_Rate)end)-sum(a.Special_discount)-sum(a.Space_discount))),2) as  "AgencyAddlTD(%)",
sum(isnull((isnull(b.Gross_Rate ,''0'')*isnull(a.ADD_AGENCY_COMM,''0'')/100),''0'')) as AgencyAddlTDAmt,
ROUND(sum(isnull(b.Gross_Rate,''0'') ),2)as Grossamt,
 case sum(isnull(b.Gross_Rate,''0'') )
 when  0 then 0
 else  round(((sum(isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(b.Gross_Rate,''0''),'''+@prefer+''',''4'' ),''0''))*100)/sum(isnull(b.Gross_Rate,''0'') )),2)  
 end  as  "RetTD(%)",
sum(isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(b.Gross_Rate,''0''),'''+@prefer+''',''4'' ),''0''))as RetTDAmt,
round(((sum((isnull(b.Gross_Rate,''0'')* isnull(a.Trade_disc,''0'' )/100 ))*100)/(sum(a.Card_rate*b.Size_Book)+sum(dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1'') )+sum(a.Special_charges) -sum(a.Deviation)-(sum(a.Card_rate*b.Size_Book)- 
case isnull(sum(b.Agreed_Rate),0)
when 0 then sum(a.Card_rate*b.Size_Book)
else sum(b.Agreed_Rate)end)-sum(a.Special_discount)-sum(a.Space_discount))),2) as "AgencyTD(%)",
sum((isnull(b.Gross_Rate,''0'')* isnull(a.Trade_disc,''0'' )/100 ))as AgencyTDAmt,
ROUND(sum(isnull(b.Bill_Amt,''0'')),2) as Billamt,
 case sum(isnull(b.Gross_Rate,''0'') )
 when  0 then 0
 else  round(((sum(isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(b.Gross_Rate,''0''),'''+@prefer+''',''2'' ),''0'') ) *100)/sum(isnull(b.Gross_Rate,''0'') )),2)  
 end  as "RetComm(%)",
sum(isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(b.Gross_Rate,''0''),'''+@prefer+''',''2'' ),''0'') )as RetCommAmt,
ROUND(sum(isnull((  isnull(b.Bill_Amt,''0'')-isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(b.Gross_Rate,''0''),'''+@prefer+''',''2'' ),''0'')  ),''0'')),2) as ActualBusiness
FROM TBL_BOOKING_MAST a,AGENCY_MAST ,
TBL_BOOKING_insert b
WHERE a.Comp_code='''+@compcode+''' AND
a.Agency_sub_code=AGENCY_MAST.code_subcode AND
a.cio_booking_id=b.Cio_Booking_Id '
--and ((b.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
--or  ('''+@chk_access+'''=''0'') )' 

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL)
begin
set @query4=' and b.Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
END 

if(@base='2')begin
set @query4=@query4 +' and (a.Executive_code is not null and a.Executive_code !=''0'')  '
end 

if(@base='3')begin
set @query4=@query4 +' and (a.retainer IS NOT NULL and retainer <>''  and a.RETAINER !=''0'')  '
end 


if(@drpstatus is null or  @drpstatus = '') begin
set @query4=@query4+' and lower(Insert_Status)!='''+'cancel'+''''
end 

if(@insertstatus is not null and @insertstatus<>'' ) begin
set @query4=@query4+' and lower(Insert_Status)='''+@insertstatus+''''
end 





IF(@publication IS NOT NULL)
begin
set @query4=@query4 +' and b.publication_Code='''+@publication+'''    '
END 

/*IF(@pub_cent IS NOT NULL and @pub_cent <>'')
begin
--set @query4=@query4 +'  and b.Pub_Cent_Code='''+@pub_cent+''''
set @query4=@query4+'  and a.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE a.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code='''+@pub_cent+'''))'

END 
IF(@branch IS NOT NULL and @branch<>'')
begin
set @query4=@query4 +'  and a.branch ='''+@branch+''''
END 
*/

IF(@pub_cent IS NOT NULL)
begin
set @query4=@query4+'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
END 


IF(@branch IS NOT NULL  and @branch<>'')
begin
set @query4=@query4+'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
END 

IF(@edition IS NOT NULL and @edition<>'')
begin
set @query4=@query4 +'  and b.Edition_Code='''+@edition+''''
END 



IF(@region IS NOT NULL and @region <>'')
begin
--set @query4=@query4  +' and b.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+@region +''')'
set @query4=@query4  +' and agency_mast.region ='''+@region+''''

END 

IF(@revcenter IS NOT NULL and @revcenter <>'')
begin
set @query4=@query4  +' and a.Revenue_center ='''+@revcenter+''''
END 

IF(@adtype IS NOT NULL and @adtype <>'')
begin
set @query4=@query4  + ' and a.Ad_type_code='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype <>'')
begin
set @query4=@query4  + ' and a.Agency_type ='''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat <>'')
begin
set @query4=@query4  + ' and b.Ad_Cat ='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat <>'')
begin
set @query4=@query4  + ' and a.Ad_sub_cat_code ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'')
begin
set @query4=@query4  + ' and a.Ad_Subcat3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'')
begin
set @query4=@query4  + ' and a.Ad_Subcat4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'')
begin
set @query4=@query4  + ' and a.Ad_subcat5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package <>'')
begin
set @query4=@query4  + ' and a.Package_code ='''+@package+''''
END 

IF(@scheme IS NOT NULL and @scheme <>'')
begin
set @query4=@query4  + ' and a.Scheme_type_code ='''+@scheme+''''
END 

IF(@agency IS NOT NULL and @agency <>'')
begin
set @query4=@query4  + ' and a.Agency_code ='''+@agency+''''
END 

IF(@client IS NOT NULL and @client  <>'')
begin
set @query4=@query4  + ' and a.Client_code ='''+@client+''''
END 

IF(@executive IS NOT NULL and @executive <>'')
begin
set @query4=@query4  + ' and a.Executive_code ='''+@executive+''''
END 

IF(@retainer IS NOT NULL and @retainer <>'')
begin
set @query4=@query4  + ' and a.RETAINER ='''+@retainer+''''
END 

IF(@product IS NOT NULL and @product <>'')
begin
set @query4=@query4 + ' and a.Product_code ='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand <>'')
begin
set @query4=@query4  + ' and a.Brand_code ='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient <>'')
begin
set @query4=@query4  + ' and a.Variant_code ='''+@varient+''''
END 

IF(@pagetype IS NOT NULL and @pagetype <>'')
begin
set @query4=@query4  + ' and a.Page_type_code ='''+@pagetype+''''
END 

IF(@pageprem IS NOT NULL and @pageprem <>'')
begin
set @query4=@query4 + ' and b.Premium1 ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem <>'')
begin
set @query4=@query4 + ' and b.Page_Post ='''+@postprem+''''
END 

IF(@rostatus IS NOT NULL and @rostatus <>'')
begin
set @query4=@query4 + ' and a.ro_status ='''+@rostatus+''''
END 

IF(@booktype IS NOT NULL and @booktype <>'')
begin
set @query4=@query4 + ' and a.Booking_type ='''+@booktype+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'')
begin
set @query4=@query4 + ' and a.Contract_name ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment  <>'')
begin
set @query4=@query4 + ' and b.Supp_Code ='''+@suppliment+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype  <>'')
begin
set @query4=@query4 + ' and a.Rate_code ='''+@ratetype+''''
END 

IF(@city  IS NOT NULL and @city  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.City_Code ='''+@city+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code ='''+@city+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.City_Code='''+@city+''')'
end 
END 

IF(@zone  IS NOT NULL and @zone  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.zone_code ='''+@zone+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= '''+@zone+''') )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Zone_Code='''+@zone+''')'
end 
END 

IF(@district  IS NOT NULL and @district  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.Dist_Code ='''+@district+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code ='''+@district+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Dist_Code='''+@district+''')'
end 
END 

IF(@state  IS NOT NULL and @state  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.State_Code ='''+@state+''''
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code ='''+@state+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.State_Code='''+@state+''')'
end 
END 

IF(@taluka  IS NOT NULL and @taluka  <>'')
begin
if(@base='1')begin
set @query4=@query4 + ' and AGENCY_MAST.TALUKA='''+@taluka+'''  '
end 

if(@base='2')begin
set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA ='''+@taluka+''' )'
end 

if(@base='3')begin
set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.TALUKA='''+@taluka+''')'
end 
END 

set @query4=@query4 + ' group by b.Insert_Date order by Date'

print(@query3+@query4)
exec(@query3+@query4)

end 
 


SELECT getdate() AS "Rundate",dbo.initcap(Comp_Name) AS "companyname" from comp_mst where Comp_Code=@compcode
select * from  #temp_ad_bills_report



deallocate c1
deallocate c2

drop table #temp_ad_bills_report
/*drop table #temp_complete_dynamic_report
drop table #MULTIPACK_REP	
drop table #MULTIPACK_RAT
drop table #MULTIPACK_RATNEW



*/



/////////////////////////////////////end of issue 5825////////////////////////////////////////////////////////////////

/***************************************** December 2 2011 kuldeep Bhati (Retainer Issue) *********************************************************/
create procedure gencodeforcommstruct
(
@p_compcode                                   VARCHAR(4000) ,
@p_userid                                   VARCHAR(4000) 
)
AS 
	BEGIN
		DECLARE @num     int
	SELECT @num  =  ISNULL(MAX(COMM_TARGET_ID), 0) + 1 FROM  RETAIN_COMM_TARGET 

 select @num  AS "IDNO"
		

END

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER PROCEDURE  [dbo].[AD_RETAIN_ADD_COMM_TARGET_INS] (@PCOMP_CODE       AS VARCHAR(40),
												@PRETAIN_CODE     AS VARCHAR(40),
												@PPUBL_CODE       AS VARCHAR(40),
												@PNO_OF_PUBL      AS VARCHAR(40),
												@PADCOMM_PER        AS NUMERIC,
												@PCOMM_TYPE       AS VARCHAR(40),
												@PCREATED_BY      AS VARCHAR(40),
												@PCREATED_DT      AS DATETIME,
												@PUPDATED_BY      AS VARCHAR(40),
												@PUPDATED_DT      AS DATETIME,
												@PCOMM_TARGET_ID  AS NUMERIC,
												@PADD_COMM_ID	  AS NUMERIC,
												@PDML_TYPE        AS VARCHAR(40)) AS

BEGIN
 IF ISNULL(@PDML_TYPE,'?')='I' 
   BEGIN 
     INSERT INTO retain_adcomm_target (COMP_CODE, RETAIN_CODE, PUBL_CODE, NO_OF_PUBL,ADCOMM_PER,
									  COMM_TYPE, CREATED_BY, CREATED_DT, UPDATED_BY, UPDATED_DT,COMM_TARGET_ID)
                            VALUES  (@PCOMP_CODE,@PRETAIN_CODE,@PPUBL_CODE,@PNO_OF_PUBL,@PADCOMM_PER,
                                     @PCOMM_TYPE,getdate(),@PCREATED_DT,@PUPDATED_BY,@PUPDATED_DT,@PCOMM_TARGET_ID)
   END
 IF ISNULL(@PDML_TYPE,'?')='U' 
   BEGIN
     UPDATE retain_adcomm_target SET PUBL_CODE = @PPUBL_CODE, NO_OF_PUBL = @PNO_OF_PUBL, ADCOMM_PER = @PADCOMM_PER,
                                   COMM_TYPE = @PCOMM_TYPE,UPDATED_BY = @PUPDATED_BY,UPDATED_DT = getdate()
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
          AND ADD_COMM_ID = @PADD_COMM_ID;
   END
 IF ISNULL(@PDML_TYPE,'?')='D' 
   BEGIN
     DELETE FROM retain_adcomm_target
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
         AND ADD_COMM_ID = @PADD_COMM_ID;
   END
END





@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER  procedure [dbo].[retaddselectslab]
(
@compcode as varchar(20),
@userid as varchar(20),
@retcode as varchar(20),
@code11 as int


)

as

select  PUBL_CODE, NO_OF_PUBL,ADCOMM_PER,COMM_TYPE,COMM_TARGET_ID from retain_adcomm_target where COMP_CODE=@compcode and RETAIN_CODE=@retcode and ADD_COMM_ID=@code11

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


ALTER  PROCEDURE [dbo].[retaddstatusbind]
(
@retcode as varchar(20),
@userid as varchar(20),
@compcode as varchar(20),
@commid as varchar(20)
)

as

select * from retain_adcomm_target where COMP_CODE=@compcode  and RETAIN_CODE=@retcode and COMM_TARGET_ID=@commid
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER  PROCEDURE [dbo].[sp_retstatusbind_b]
(
@retcode as varchar(20),
@userid as varchar(20),
@compcode as varchar(20),
@commid as varchar(20)
)

as

select * from retain_comm_slab where COMP_CODE=@compcode  and RETAIN_CODE=@retcode and COMM_TARGET_ID=@commid

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

/***************************************** December 2 2011 kuldeep Bhati (Retainer Issue) *********************************************************/

/*======================================= 5-12-11 mimoh mahajan client MAster ===============5747===============*/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





ALTER PROCEDURE [dbo].[clientexecute]
@compcode  varchar(8),
@userid  varchar(8),
@custcode  varchar(8),
@custname  varchar(50),
@alias  varchar(50),
@citycode varchar(8),
@status varchar(20),
@rategroup varchar(8),
@country varchar(8),
@agency_sav varchar(20)

AS

--delete  clientfirst
declare @query  varchar(3000)
declare @query1  varchar(3000)
declare @query2  varchar(3000)
declare @curscod  varchar(12)
declare @code varchar(8)


CREATE TABLE #CUST_MAST(
Comp_Code varchar(8),
Cust_Code varchar(8),
Cust_Name varchar(50),
Cust_Alias varchar(50),
Add1 varchar(50),
Stree varchar(50),
City_Code varchar(8),
Zip varchar(12),
Dist_Code varchar(50),
State_Code varchar(50),
Country_Code varchar(8),
phone1 varchar(30),
Phone2 varchar(30),
Fax varchar(30),
EmailID varchar(50),
URL varchar(30),
No_of_VTS varchar(20),
ST_ACC_NO varchar(30),
PAN_NO varchar(30),
Credit_Days int,
Pay_Mode_Code varchar(20),
Cust_Status varchar(20),
Status_Reason varchar(200),
Remarks varchar(200),
UserId varchar(8),
Creation_Datetime datetime,
Zone_code varchar(8),
Region_code varchar(8),
Credit_limit varchar(8),
Rate_Gr_Code varchar(8),
to_date datetime,
Client_category varchar(8),
TALUKA varchar(8)
)


--declare @curscod  char(12)

--declare @query1  varchar(3000)

--declare @query2  varchar(3000)

print('ankur')


-- set @query='insert into #CUST_MAST select comp_code,cust_code,cust_name,cust_alias,add1,stree,city_code,zip,dist_code,state_code,country_code,phone1,phone2,fax,emailid,url,no_of_vts,st_acc_no,pan_no,credit_days,pay_mode_code,cust_status,status_reason,remarks,userid,creation_datetime,zone_code,region_code,credit_limit,Rate_Gr_Code,  getdate() ,Client_category ,TALUKA    from cust_mast where comp_code='''+@compcode+'''' 
set @query='select Comp_Code,Cust_Code,Cust_Name,Cust_Alias,Add1,Stree,City_Code,Zip,Dist_Code,State_Code,Country_Code,phone1,Phone2,Fax,EmailID,URL,No_of_VTS,ST_ACC_NO,PAN_NO,Credit_Days,Pay_Mode_Code,
(select top 1 status_name from tblstatus where status_code = (select top 1 cust_status from status_detail_client where cust_code=cust_mast.cust_code and getdate() between from_date and to_date)) as Cust_Status
,Status_Reason,Remarks,UserId,Creation_Datetime,Zone_code,Region_code,Credit_limit,Rate_Gr_Code,  getdate() ,Client_category ,TALUKA,(select top 1 TO_DATE from status_detail_client where status_detail_client.cust_code=cust_mast.Cust_Code) as to_date,CLIENT_TYPE,QBC_AGENCY    from cust_mast where comp_code='''+@compcode+'''' 

if(@custcode <>'')

--print(@custcode)

begin

set @query= @query + 'and  cust_code like ''%'+@custcode+'%'''

end

if(@custname <> '')

--print(@custname)

begin

set @query  =  @query + 'and cust_name  like ''%'+@custname+'%'''

end

if(@alias <> '')

--print(@custname)

begin

set @query  =  @query + 'and cust_alias  like ''%'+@alias+'%'''

end

if(@citycode <> '' AND @citycode <> '0')

--print(@citycode)

begin

set @query  =  @query + 'and city_code  like ''%'+@citycode+'%'''

end

if(@status <> '')

--print(@status)

begin

set @query  =  @query + 'and cust_status  like ''%'+@status+'%'''

end

if(@rategroup='' and @rategroup <> '0')

--print(@rategroup)

begin

set @query  =  @query + 'and Rate_Gr_Code  like ''%'+@rategroup+'%'''

end

if(@agency_sav <> '')



begin

set @query  =  @query + 'and  AGENCY_CODE  like ''%'+@agency_sav+'%'''

end

if(@country='' and @country <> '0')

--print(@rategroup)

begin

set @query  =  @query + 'and Country_Code  like ''%'+@country+'%'''

end

print(@query)

exec(@query)
/*
declare client cursor read_only
for 
select Cust_Code from #CUST_MAST order by Cust_Code

open client

FETCH NEXT FROM client
INTO @curscod
--select @curscod=cust_code from #CUST_MAST

print(@curscod)
WHILE @@FETCH_STATUS = 0
BEGIN
-----print(@curscod)

--select @code= cust_status from status_detail_client where cust_status = (select top 1 cust_status from status_detail_client where cust_code='''+@curscod+''' order by to_date desc)	
--print(@curscod)
--set @query1='update #CUST_MAST set Cust_Status=(select status_name from tblstatus where status_code='''+@code+''') where cust_code='''+@curscod+''''

 --- set @query1='update #CUST_MAST set Cust_Status=(select top 1 status_name from tblstatus where status_code = (select top 1 cust_status from status_detail_client where cust_code='''+RTRIM(LTRIM(@curscod))+''' and getdate() between from_date and to_date  order by to_date desc)	) where cust_code='''+@curscod+''''

set @query2='update #CUST_MAST set to_date=(select top 1 to_date from status_detail_client where cust_code='''+@curscod+''' order by to_date desc) where cust_code='''+@curscod+''''

print(@query1)

exec(@query1)

print(@query2)

exec(@query2)
FETCH NEXT FROM client
	INTO @curscod

end
CLOSE client
DEALLOCATE client
*/
-- select * from #CUST_MAST order by Cust_Code
drop table #CUST_MAST
--declare @dist as varchar(50)
--declare @state as varchar(50)

--select @dist=dist_code,@state=state_code from clientfirst where











/******************************************************************************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go








ALTER   procedure [dbo].[clientsave]
@compcode varchar(8),
@custcode varchar(8),
@custname varchar(50),
@custalias varchar(15),
@add1 varchar(50),
@street varchar(50),
@citycode varchar(8),
@zip varchar(12),
@dist varchar(50),
@state varchar(50),
@country varchar(50),
@phone1 varchar(50),
@phone2 varchar(50),
@fax varchar(50),
@emailid varchar(50),
@url varchar(50),
@vats varchar(50),
@servicetax varchar(50),
@pan varchar(50),
@creditdays varchar(50),
@paymodecode varchar(50),
@custstatus varchar(50),
@statusreason varchar(200),
@alert varchar(200),
@userid varchar(50),
@zone as varchar(8),
@region as varchar(8),
@crdlimit as varchar(8),
@flag int,
@rategroup as varchar(8),
@clientcat as varchar(8) ,
@taluka as varchar(8),
@agency_sav as varchar(20),
@p_CLIENT_TYPE as varchar(5),
@p_QBC_AGENCY as varchar(20)
 
as

declare @distcode as varchar(50)
declare @statecode as varchar(50)
declare @countrycode as varchar(50)
declare @fatchstatus as varchar(50)

--select @distcode =dist_code from dist_mst where dist_name=@dist
--select @statecode=state_code from state_mst  where state_Name=@state
select @countrycode=country_code from count_mst  where country_Name=@country
select top 1 @fatchstatus=status_name from tblstatus where status_code=(select top 1 cust_status from status_detail_client where cust_code=@custcode and Comp_Code=@compcode)
/*Transaction Variable*/

	if(@flag=1)
		begin 
        		update cust_mast  set zone_code=@zone,region_code=@region, credit_limit=@crdlimit,Cust_Name=@custname,Cust_Alias=@custalias,Add1=@add1,Stree=@street,City_Code=@citycode,Zip=@zip,Dist_Code=@dist,State_Code=@state,Country_Code=@country,Phone1=@phone1,Phone2=@phone2,Fax=@fax,Emailid=@emailid,Url=@url,No_of_VTS=@vats,ST_ACC_No=@servicetax,PAN_No=@pan,Credit_Days=@creditdays,Pay_Mode_Code=@paymodecode,Cust_Status=@custstatus,Status_Reason=@statusreason,Remarks=@alert,UserId=@userid,Creation_Datetime=getdate(),Rate_Gr_Code=@rategroup,Client_category=@clientcat ,TALUKA=@taluka , AGENCY_CODE=@agency_sav,
				CLIENT_TYPE= @p_CLIENT_TYPE,QBC_AGENCY=@p_QBC_AGENCY 
				WHERE Comp_Code = @compcode AND Cust_Code=@custcode 		
		--update clientfirst  set  zone_code=@zone,region_code=@region, credit_limit=@crdlimit,Cust_Name=@custname,Cust_Alias=@custalias,Add1=@add1,Stree=@street,City_Code=@citycode,Zip=@zip,Dist_Code=@dist,State_Code=@state,Country_Code=@country,Phone1=@phone1,Phone2=@phone2,Fax=@fax,Emailid=@emailid,Url=@url,No_of_VTS=@vats,ST_ACC_No=@servicetax,PAN_No=@pan,Credit_Days=@creditdays,Pay_Mode_Code=@paymodecode,Cust_Status=@custstatus,Status_Reason=@statusreason,Remarks=@alert,UserId=@userid,Creation_Datetime=getdate(),Rate_Gr_Code=@rategroup WHERE Comp_Code = @compcode AND Cust_Code=@custcode and UserId=@userid		

		end

	if(@flag=0)
		begin 
				
			/*Transaction part*/
						
			insert into cust_mast (Comp_Code, Cust_Code, Cust_Name, Cust_Alias,
                      Add1, Stree, City_Code, Zip, Dist_Code,
                      State_Code, Country_Code, phone1, Phone2,
                      Fax, EmailID, URL, No_of_VTS, ST_ACC_No,
                      PAN_No, Credit_Days, Pay_Mode_Code,
                      Cust_Status, Status_Reason, Remarks, UserId,
                      Creation_Datetime, Zone_code, Region_code,
                      Credit_limit, Rate_Gr_Code, Client_category,TALUKA,AGENCY_CODE,CLIENT_TYPE,QBC_AGENCY
                     ) values(@compcode,@custcode,@custname,@custalias,@add1,@street,@citycode,@zip,@dist,@state,@country,@phone1,@phone2,@fax,@emailid,@url,@vats,@servicetax,@pan,@creditdays,@paymodecode,@fatchstatus,@statusreason,@alert,@userid,getdate(),@zone,@region,@crdlimit,@rategroup,@clientcat,@taluka,@agency_sav,
					 @p_CLIENT_TYPE,@p_QBC_AGENCY)
			
						--insert into cust_mast
			/*This is added by Amit */
			/* This query is automatically added after data is addded on cust_mast table*/
			--insert into pay_mode_client(Comp_Code,Client_code,userid,creation_datetime) values(@compcode,@custcode,@userid,getdate()) 
			
		
		end





/******************************************************************************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go






ALTER PROCEDURE [dbo].[websp_getclientName] 
@compcode varchar(50),
@client varchar(50)
AS
select Cust_Code,Cust_Name,Add1 from cust_mast
 where comp_code=@compcode and cust_name like @client+'%' 
and (isnull(Cust_Status,'ACTIVE')='ACTIVE' or Cust_Status='' ) and (client_type='' or client_type is null or client_type='B')order by Cust_Name







/*******************************************************************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go






ALTER PROCEDURE [dbo].[websp_getclientName_b] 
@compcode varchar(50),
@client varchar(50),
@agencycode varchar(50)
AS
select Cust_Code,Cust_Name,Add1 from cust_mast
 where comp_code=@compcode and cust_name like @client+'%' 
and (isnull(Cust_Status,'ACTIVE')='ACTIVE' or Cust_Status='' ) and (AGENCY_CODE = @agencycode OR @agencycode IS NULL) and (client_type='Q')order by Cust_Name








/*======================================= 5-12-11 mimoh mahajan client MAster ===============5747===============*/


/////////////////5831
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go












ALTER PROCEDURE [dbo].[executebooking_new1]
@compcode as varchar(8),
@ciobookid as varchar(50),
@docno as varchar(25)=null,
@keyno as varchar(25)=null,
@rono as varchar(20)=null,
@agencycode as varchar(8)=null,
@client as varchar(100)=null,
@booking as varchar(8),
@dateformat as varchar(20),
@revenue as varchar(50)

AS
declare @query as varchar(8000)
 declare @VERSION1 as   float
 declare @count1  as    float


CREATE TABLE #tempbooking_mast ( 
  date_time            DATETIME         , 
  branch               VARCHAR(25)  , 
  booked_by            VARCHAR (25)  , 
  cio_booking_id       VARCHAR (50), 
  prev_booking         VARCHAR (25), 
  applied_by           VARCHAR (25), 
  audit                VARCHAR (25), 
  RO_No                VARCHAR (20), 
  RO_Date              DATETIME, 
  Caption              VARCHAR (500), 
  bill_status          VARCHAR (8)  , 
  ro_status            VARCHAR (8), 
  Agency_code          VARCHAR (50), 
  Agency_address       VARCHAR (500), 
  Client_code          VARCHAR (100), 
  Client_address       VARCHAR (500), 
  Agency_sub_code      VARCHAR (50), 
  Dockit_no            VARCHAR (25), 
  Executive_code       VARCHAR (50), 
  Executive_zone       VARCHAR (50), 
  Product_code         VARCHAR (50), 
  Brand_code           VARCHAR (50), 
  Key_no               VARCHAR (100), 
  Bill_remarks         VARCHAR (500), 
  Print_remark         VARCHAR (500), 
  Package_code         VARCHAR (500) , 
  No_of_insertion      FLOAT, 
  Insertion_date       DATETIME, 
  Repeating_day        VARCHAR (8), 
  Ad_type_code         VARCHAR (8), 
  Ad_cat_code          VARCHAR (8), 
  Ad_sub_cat_code      VARCHAR (50), 
  Color_code           VARCHAR (8), 
  Uom_code             VARCHAR (8), 
  Page_position_code   VARCHAR (8), 
  Page_type_code       VARCHAR (100), 
  Page_no              FLOAT, 
  Ad_size_type_code    VARCHAR (8), 
  Ad_size_height       FLOAT, 
  Ad_size_width        FLOAT, 
  Rate_code            VARCHAR (100), 
  Scheme_type_code     VARCHAR (18), 
  Currency_code        VARCHAR (8), 
  Agrred_rate          FLOAT, 
  Agreed_amount        FLOAT, 
  Special_discount     FLOAT, 
  Space_discount       FLOAT, 
  Special_charges      FLOAT, 
  Agency_status        VARCHAR (15), 
  Agency_type          VARCHAR (25), 
  Agency_pay           VARCHAR (25), 
  Agency_credit        FLOAT, 
  Total_area           FLOAT, 
  Card_rate            FLOAT, 
  Card_amount          FLOAT, 
  Discount             FLOAT, 
  Discount_per         FLOAT, 
  Bill_cycle           VARCHAR (8), 
  Revenue_center       VARCHAR (50), 
  Bill_pay             VARCHAR (8), 
  Bill_height          FLOAT, 
  Bill_width           FLOAT, 
  Bill_to              VARCHAR (100), 
  Invoices             FLOAT, 
  Vts                  FLOAT, 
  Bill_add             VARCHAR (500), 
  Trade_disc           FLOAT, 
  Agency_out           VARCHAR (50), 
  Box_code             VARCHAR (8), 
  Box_no               VARCHAR (50), 
  Box_agency           VARCHAR (2), 
  Box_client           VARCHAR (2), 
  Box_address          VARCHAR (500), 
  Comp_code            VARCHAR (8)  , 
  Userid               VARCHAR (8), 
  Creation_datetime    DATETIME          , 
  Booking_type         VARCHAR (8), 
  Tfn                  VARCHAR (2), 
  Coupan_ad            VARCHAR (2), 
  Campaign             VARCHAR (50), 
  Bill_amount          FLOAT, 
  Page_prem            VARCHAR (8), 
  Page_amount          FLOAT, 
  Prem_per             FLOAT, 
  Gross_amount         FLOAT, 
  Ad_size_column       FLOAT, 
  Bill_column          FLOAT, 
  Bill_area            FLOAT, 
  Special_disc_per     FLOAT, 
  Space_disc_per       FLOAT, 
  Paid_ins             FLOAT, 
  Contract_rate        FLOAT, 
  Deviation            FLOAT, 
  Variant_code         VARCHAR (8), 
  Contract_name        VARCHAR (50), 
  Contract_type        VARCHAR (50), 
  Card_name            VARCHAR (100), 
  Card_type            VARCHAR (50), 
  Card_month           VARCHAR (8), 
  Card_year            VARCHAR (8), 
  Card_number          VARCHAR (20), 
  Receipt_no           VARCHAR (50), 
  Ad_Subcat3           VARCHAR (8), 
  Ad_Subcat4           VARCHAR (8), 
  Ad_subcat5           VARCHAR (8), 
  Bg_color             VARCHAR (8), 
  Bullet_code          VARCHAR (8), 
  Bullet_premium       FLOAT, 
  Material_status      VARCHAR (50), 
  Receipt_date         DATETIME, 
  prev_cioid           VARCHAR (100), 
  prev_receipt         VARCHAR (50), 
  prev_grossamt        FLOAT, 
  Region               VARCHAR (8), 
  Variant              VARCHAR (8), 
  Colortype            VARCHAR (8), 
  Logo_H               VARCHAR (5), 
  Logo_W               VARCHAR (5), 
  Logo_color           VARCHAR (8), 
  Logo_Uom             VARCHAR (8), 
  SAPID                VARCHAR (10), 
  RETAINER             VARCHAR (100), 
  ADD_AGENCY_COMM      VARCHAR (8), 
  MOBILENO             VARCHAR (50), 
  ADD_AGENCY_COMM_AMT  VARCHAR (50), 
  RETAINER_COMM        VARCHAR (50), 
  RETAINER_COMM_AMT    VARCHAR (50), 
  CASH_RECIEVED        VARCHAR (50),doctype varchar(20),APP_REMARKS varchar(500) )


declare @booking_type11  as varchar(8) 

set @booking_type11='3'

set @query=' insert  #tempbooking_mast   SELECT date_time, branch, booked_by, cio_booking_id,
                prev_booking, applied_by, audit, RO_No, RO_Date,
                Caption, bill_status, ro_status, Agency_code,
                Agency_address, Client_code, Client_address,
                Agency_sub_code, Dockit_no, Executive_code,
                Executive_zone, Product_code, Brand_code, Key_no,
                Bill_remarks, Print_remark, Package_code,
                No_of_insertion, Insertion_date, Repeating_day,
                Ad_type_code, Ad_cat_code, Ad_sub_cat_code,
                Color_code, Uom_code, Page_position_code,
                Page_type_code, Page_no, Ad_size_type_code,
                Ad_size_height, 

   isnull(TBL_BOOKING_MAST."Ad_size_column" ,TBL_BOOKING_MAST."Ad_size_width") AS "Ad_size_width"  , 



Rate_code,
                Scheme_type_code, Currency_code, ISNULL(Agrred_rate,''0''),
                ISNULL(Agreed_amount,''0''), Special_discount, Space_discount,
                Special_charges, Agency_status, Agency_type,
                Agency_pay, Agency_credit, Total_area, Card_rate,
                Card_amount, ISNULL(Discount,''0''), Discount_per, Bill_cycle,
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
                (Receipt_date), prev_cioid, prev_receipt,
                prev_grossamt, Region, Variant, Colortype, Logo_H,
                Logo_W, Logo_color, Logo_Uom,sapid,RETAINER,ADD_AGENCY_COMM,MOBILENO,ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,'''',doctype,APP_REMARKS
           FROM TBL_BOOKING_MAST where comp_code='''+@compcode+''''
--  and  Ad_type_code='''+@booking+'''    '


if(@ciobookid <>'' or @ciobookid<>null)
begin
set @query=@query+'and  cio_booking_id = '''+@ciobookid+''''
end

/*

if(@docno<>'' and @docno<>null)
begin
set @query=@query+'and  Dockit_no = '''+@docno+''''
end

if(@keyno<>'' and @keyno<>null)
begin
set @query=@query+'and  Key_no = '''+@keyno+''''
end

if(@rono<>'' and @rono<>null)
begin
set @query=@query+'and  RO_No = '''+@rono+''''
end

if(@agencycode<>'' and @agencycode<>null)
begin
set @query=@query+'and  Agency_sub_code = '''+@agencycode+''''
end

if(@client<>'' and @client<>null) 
begin
set @query=@query+'and  Client_code = '''+@client+''''
end

if(@booking<> '' and @booking <> null)
begin
set @query=@query +' and Ad_type_code='''+@booking+''''
end

set @query=@query + 'and branch='''+@revenue+''''

*/
print(@query)
exec(@query)

SELECT CASE @dateformat
                     WHEN 'mm/dd/yyyy' THEN convert(varchar(100),date_time,101)
                  WHEN 'dd/mm/yyyy' THEN convert(varchar(100),date_time,103)
                     WHEN 'yyyy/mm/dd' THEN convert(varchar(100),date_time,103)  END AS date_time,
                     branch,booked_by, cio_booking_id, prev_booking, applied_by,audit, RO_No,
            CASE @dateformat
                 WHEN 'mm/dd/yyyy' THEN convert(varchar(100),RO_Date,101)
                 WHEN 'dd/mm/yyyy' THEN convert(varchar(100),RO_Date,103)
                 WHEN 'yyyy/mm/dd' THEN convert(varchar(100),RO_Date,103)  END AS RO_Date,
                 -- TO_CHAR(RO_Date, 'dd/mm/yyyy') AS RO_Date,
                Caption, bill_status, ro_status,#TEMPBOOKING_MAST.Agency_code,
                Agency_address, Client_code, Client_address,
                Agency_sub_code, Dockit_no, Executive_code,
                Executive_zone, Product_code, Brand_code, Key_no,
                Bill_remarks, Print_remark, Package_code,No_of_insertion,
            CASE @dateformat
                    WHEN 'mm/dd/yyyy' THEN convert(varchar(100),Insertion_date,101)
                    WHEN 'dd/mm/yyyy' THEN convert(varchar(100),Insertion_date,103)
                    WHEN 'yyyy/mm/dd' THEN convert(varchar(100),Insertion_date,103)  END    AS Insertion_date,
                Repeating_day, Ad_type_code, Ad_cat_code,
                Ad_sub_cat_code, Color_code, Uom_code,
                Page_position_code, Page_type_code, Page_no,
                Ad_size_type_code, Ad_size_height, Ad_size_width, Rate_code,
                (SELECT Scheme_Name FROM SCHEME_MASTER WHERE scheme_id =#TEMPBOOKING_MAST.Scheme_type_code)AS Scheme_type_code,
                 Currency_code, Agrred_rate, Agreed_amount,
                Special_discount, Space_discount, Special_charges,
                #TEMPBOOKING_MAST.Comp_code, #TEMPBOOKING_MAST.Userid,
                #TEMPBOOKING_MAST.Agency_status, Agency_type, Agency_pay,
                Agency_credit, Total_area, Card_rate, Card_amount,
                Discount, Discount_per, Bill_cycle, Revenue_center,
                Bill_pay, Bill_height, Bill_width,
                #TEMPBOOKING_MAST.Bill_to, Invoices, Vts, Bill_add,
                Trade_disc, Agency_out,#TEMPBOOKING_MAST. Booking_type, Campaign,
                Page_prem, Page_amount, Prem_per, Gross_amount,
                Bill_amount, Box_code, Box_no, Box_agency,
                Box_client, Box_address, Tfn, Coupan_ad,
                Ad_size_column, Bill_column, Bill_area,
                Special_disc_per, Space_disc_per,
                AGENCY_MAST.Agency_Name + '(' + AGENCY_MAST.code_subcode + ')'+ '('+(select city_mst.city_name from city_mst  where city_mst.city_code=agency_mast.city_code)  +')' AS AgencyName,
                (SELECT EXEC_MAST.Exec_name + '(' + convert(varchar(100),EXEC_MAST.Exe_no)+ ')' FROM EXEC_MAST
                  WHERE #TEMPBOOKING_MAST.Executive_code = EXEC_MAST.Exe_no
                    AND #TEMPBOOKING_MAST.Comp_code = EXEC_MAST.comp_code) AS execname,
               
                (SELECT  PRODUCT_CAT_MAST.prod_desc + '(' +PRODUCT_CAT_MAST.prod_cat_code + ')' FROM PRODUCT_CAT_MAST
                  WHERE #TEMPBOOKING_MAST.Product_code = PRODUCT_CAT_MAST.prod_cat_code
                    AND #TEMPBOOKING_MAST.Comp_code = PRODUCT_CAT_MAST.comp_code) AS product,
                
                Paid_ins, Contract_rate, Deviation, Variant_code,
                Contract_name, Contract_type, Card_name, Card_type,
          
                Card_month, Card_year, Card_number, Receipt_no,
                Ad_Subcat3, Ad_Subcat4, Ad_subcat5, Bg_color,
                Bullet_code, Bullet_premium,
                (SELECT Agency_Name FROM AGENCY_MAST WHERE code_subcode =#TEMPBOOKING_MAST.Agency_sub_code) AS AgencySubCode,
      
                isnull ((SELECT Cust_Name+'('+Cust_Code+')' FROM CUST_MAST WHERE Cust_Code = Client_code), Client_code) AS Client,                                       --112
                (SELECT DISTINCT Payment_Mode_Name FROM PAYMENT_MODE_MAST WHERE PAYMENT_MODE_MAST.Comp_Code=#TEMPBOOKING_MAST. Comp_code  and Pay_Mode_Code = Agency_pay) AS PayMode,
                (SELECT Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code =#TEMPBOOKING_MAST.Ad_cat_code) AS categoryname,
                (SELECT Adv_Subcat_Name FROM ADV_SUBCAT_MAST  WHERE ADV_SUBCAT_MAST.Adv_Subcat_Code =#TEMPBOOKING_MAST.Ad_sub_cat_code)
                 AS subcategoryname,
                (SELECT brand_name FROM BRAND_MST WHERE brand_code =#TEMPBOOKING_MAST.Brand_code) AS Brand,
                (SELECT Uom_Name FROM UOM_MAST WHERE Uom_Code = #TEMPBOOKING_MAST.Uom_code) AS UOM,
                (SELECT premiumname FROM ADVPOS_PREM_MAST WHERE Premiumcode =#TEMPBOOKING_MAST.Page_prem) AS PagePremium,
                 (SELECT Pos_Type FROM ADVPOS_TYPE_MAST
                  WHERE Pos_Type_Code = #TEMPBOOKING_MAST.Page_position_code) AS PositionPremium,
                (SELECT Curr_Name FROM CURR_MAST WHERE Curr_Code = #TEMPBOOKING_MAST.Currency_code) AS Currency,
                Material_status, convert(varchar(100),Receipt_date,102) AS Receipt_date, #TEMPBOOKING_MAST.Region,
                Variant, Colortype,
                (SELECT UOM_DESC FROM UOM_MAST WHERE Uom_Code = #TEMPBOOKING_MAST.Uom_code) AS uom_desc,
                (SELECT Logo FROM UOM_MAST WHERE Uom_Code =#TEMPBOOKING_MAST.Uom_code) AS logo,Logo_H, Logo_W, Logo_color, Logo_Uom,
                (SELECT Logo_Uom FROM UOM_MAST WHERE Uom_Code = #TEMPBOOKING_MAST.Uom_code)  AS logocode,
                (SELECT Box_Charges_Native FROM BOX_MAST WHERE BOX_MAST.Box_Code=#TEMPBOOKING_MAST.Box_code) AS boxchrg,#TEMPBOOKING_MAST.sapid,
                retainer,(SELECT Retain_Name+'('+Retain_Code+')' FROM RETAINERMASTER WHERE RETAINERMASTER.Retain_Code=#TEMPBOOKING_MAST.RETAINER) AS RETAINER1,
                (SELECT Package_Name FROM combin_mast WHERE Combin_Code =

#TEMPBOOKING_MAST.Package_code) as Package_cod,(SELECT Col_Name FROM col_mast WHERE Col_Code = #TEMPBOOKING_MAST.Color_code) as

Color_cod,(SELECT Pos_Type FROM advpos_type_mast WHERE Pos_Type_Code =

#TEMPBOOKING_MAST.Page_position_code) as Page_position_cod,





 CASE #TEMPBOOKING_MAST.Booking_type
                    WHEN '1'  THEN 'BARTER'
                    WHEN  '2' THEN 'FMG'
                    WHEN '3' THEN 'NORMAL'  
when '4' then 'INHOUSE'
when '5' then 'COMPLIMENTARY'

END    AS Book_type,
         

--decode(TEMPBOOKING_MAST.Booking_type,'1','BARTER','2','FMG','3','NORMAL','4','INHOUSE') as Book_type,
(SELECT catname  FROM  AD_CAT3   WHERE AD_CAT3.catcode=#TEMPBOOKING_MAST.Ad_Subcat3)  as Subcat3,
(SELECT Cat_Name  FROM  TBL_CAT4   WHERE

TBL_CAT4.Cat_Code=#TEMPBOOKING_MAST.Ad_Subcat4) as Ad_Subcat4,
(SELECT Cat_Name  FROM  TBL_CAT5   WHERE

TBL_CAT5.Cat_Code=#TEMPBOOKING_MAST.Ad_subcat5) as Ad_subcat5,
/*(SELECT Comm_Rate FROM ret_comm_details WHERE
ret_comm_details.Retain_Code=#TEMPBOOKING_MAST.RETAINER 
and rowid=
(select max(rowid) from ret_comm_details where ret_comm_details.Retain_Code=#TEMPBOOKING_MAST.RETAINER))*/
 RETAINER_COMM AS RETAINER_COMM,
(select AUDIT_COMMENT from tbl_booking_mast where tbl_booking_mast.cio_booking_id=#TEMPBOOKING_MAST.cio_booking_id) as remarks,
ADD_AGENCY_COMM,
 (SELECT Box_Charges_Type FROM BOX_MAST WHERE BOX_MAST.Box_Code=#TEMPBOOKING_MAST.Box_code) AS boxchargetype,
 ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,
(select RO_COMMENT from tbl_booking_mast where tbl_booking_mast.cio_booking_id=#TEMPBOOKING_MAST.cio_booking_id) as RO_COMMENT
, DOCTYPE,APP_REMARKS
 FROM #TEMPBOOKING_MAST, AGENCY_MAST
 WHERE
 AGENCY_MAST.code_subcode = #TEMPBOOKING_MAST.Agency_sub_code
AND 
AGENCY_MAST.Comp_Code =#TEMPBOOKING_MAST. Comp_code 
ORDER BY #TEMPBOOKING_MAST.Creation_datetime




 --SELECT isnull(COUNT (*),'0') AS count    FROM TBL_BOOKING_MAST_LOG WHERE Receipt_no = @ciobookid AND audit <> ''

 SELECT @VERSION1 = MAX (VSEQNO)   FROM TBL_BOOKING_MAST_LOG   WHERE Receipt_no = @ciobookid AND VSEQNO < (SELECT MAX (VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE Receipt_no = @ciobookid);      




 SELECT    CASE 
@dateformat
                     WHEN 'mm/dd/yyyy' THEN CONVERT(varchar(50),datetime_time,101)
                  WHEN 'dd/mm/yyyy' THEN CONVERT(varchar(50),datetime_time,102)
                     WHEN 'yyyy/mm/dd' THEN CONVERT(varchar(50),datetime_time,103)  END AS date_time,
                 branch, booked_by, cio_booking_id, prev_booking, applied_by,audit, RO_No,
               CASE @dateformat
                     WHEN 'mm/dd/yyyy' THEN CONVERT(varchar(50),RO_Datetime,101)
                  WHEN 'dd/mm/yyyy' THEN CONVERT(varchar(50),RO_Datetime,102)
                     WHEN 'yyyy/mm/dd' THEN CONVERT(varchar(50),RO_Datetime,103)  END AS RO_Date,
                Caption,bill_status, ro_status,
                TBL_BOOKING_MAST_LOG.Agency_code, Agency_address,
                Client_code, Client_address, Agency_sub_code,
                Dockit_no, Executive_code, Executive_zone,
                Product_code, Brand_code, Key_no, Bill_remarks,
                Print_remark, Package_code, No_of_insertion,
            CASE @dateformat
                     WHEN 'mm/dd/yyyy' THEN CONVERT(varchar(50),Insertion_datetime,101)
                  WHEN 'dd/mm/yyyy' THEN CONVERT(varchar(50),Insertion_datetime,102)
                     WHEN 'yyyy/mm/dd' THEN CONVERT(varchar(50),Insertion_datetime,103)  END AS Insertion_date,
             
                Repeating_day, Ad_type_code, Ad_cat_code,
                Ad_sub_cat_code, Color_code, Uom_code,
                Page_position_code, Page_type_code, Page_no,
                Ad_size_type_code, Ad_size_height, Ad_size_width,
                Rate_code, Scheme_type_code, Currency_code,
                Agrred_rate, Agreed_amount, Special_discount,
                Space_discount, Special_charges,
                TBL_BOOKING_MAST_LOG.Comp_code,
                TBL_BOOKING_MAST_LOG.Userid,
                TBL_BOOKING_MAST_LOG.Agency_status, Agency_type,
                Agency_pay, Agency_credit, Total_area, Card_rate,
                Card_amount, Discount, Discount_per, Bill_cycle,
                Revenue_center, Bill_pay, Bill_height, Bill_width,
                TBL_BOOKING_MAST_LOG.Bill_to, Invoices, Vts,
                Bill_add, Trade_disc, Agency_out,TBL_BOOKING_MAST_LOG.Booking_type,
                Campaign, Page_prem, Page_amount, Prem_per,
                Gross_amount, Bill_amount, Box_code, Box_no,
                Box_agency, Box_client, Box_address, Tfn Coupan_ad,
                Ad_size_column, Bill_column, Bill_area,
                Special_disc_per, Space_disc_per,
                  AGENCY_MAST.Agency_Name+ '('+ AGENCY_MAST.code_subcode+ ')' AS AgencyName,
                   (SELECT    EXEC_MAST.Exec_name + '('+convert(varchar(100),EXEC_MAST.Exe_no) + ')'
                   FROM EXEC_MAST  WHERE TBL_BOOKING_MAST_LOG.Executive_code =EXEC_MAST.Exe_no
                    AND TBL_BOOKING_MAST_LOG.Comp_code =EXEC_MAST.comp_code)AS execname,
               (SELECT    PRODUCT_CAT_MAST.prod_desc+ '('+ PRODUCT_CAT_MAST.prod_cat_code + ')'
                   FROM PRODUCT_CAT_MAST WHERE TBL_BOOKING_MAST_LOG.Product_code =PRODUCT_CAT_MAST.prod_cat_code
                    AND TBL_BOOKING_MAST_LOG.Comp_code =PRODUCT_CAT_MAST.comp_code)                                                                 AS product,
                Paid_ins, Contract_rate, Deviation, Variant_code,
                Contract_name, Contract_type, Card_name, Card_type,
                Card_month, Card_year, Card_number, Receipt_no,
                Ad_Subcat3, Ad_Subcat4, Ad_subcat5, Bg_color,
                (SELECT Agency_Name FROM AGENCY_MAST WHERE code_subcode = TBL_BOOKING_MAST_LOG.Agency_sub_code)AS AgencySubCode,
               isnull ((SELECT Cust_Name  FROM CUST_MAST WHERE Cust_Code = Client_code),'' ) AS Client,
              (SELECT distinct Payment_Mode_Name  FROM PAYMENT_MODE_MAST WHERE PAYMENT_MODE_MAST.Comp_Code=TBL_BOOKING_MAST_LOG.Comp_Code and Pay_Mode_Code = Agency_pay) AS PayMode,
               (SELECT Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code =TBL_BOOKING_MAST_LOG.Ad_cat_code)AS categoryname,
               (SELECT Adv_Subcat_Name  FROM ADV_SUBCAT_MAST WHERE ADV_SUBCAT_MAST.Adv_Subcat_Code =TBL_BOOKING_MAST_LOG.Ad_sub_cat_code)
                 AS subcategoryname,
               (SELECT brand_name  FROM BRAND_MST   WHERE brand_code = TBL_BOOKING_MAST_LOG.Brand_code)AS Brand,
               (SELECT Uom_Name FROM UOM_MAST WHERE Uom_Code =TBL_BOOKING_MAST_LOG.Uom_code)AS UOM,
               (SELECT premiumname FROM ADVPOS_PREM_MAST WHERE Premiumcode =TBL_BOOKING_MAST_LOG.Page_type_code)AS PagePremium,
                (SELECT Pos_Type FROM ADVPOS_TYPE_MAST WHERE Pos_Type_Code =TBL_BOOKING_MAST_LOG.Page_position_code)AS PositionPremium,
               (SELECT Curr_Name  FROM CURR_MAST WHERE Curr_Code =TBL_BOOKING_MAST_LOG.Currency_code) AS Currency
           FROM TBL_BOOKING_MAST_LOG, AGENCY_MAST
             WHERE TBL_BOOKING_MAST_LOG.Receipt_no = @ciobookid
            AND VSEQNO = @VERSION1
           AND AGENCY_MAST.code_subcode =TBL_BOOKING_MAST_LOG.Agency_sub_code
            AND AGENCY_MAST.Comp_Code =TBL_BOOKING_MAST_LOG. Comp_Code





SELECT    
CASE 
@dateformat
                     WHEN 'mm/dd/yyyy' THEN convert(varchar(50) ,datetime_time,101)
                  WHEN 'dd/mm/yyyy' THEN convert(varchar(50) , datetime_time,102)
                     WHEN 'yyyy/mm/dd' THEN convert(varchar(50) , datetime_time,103)  END AS date_time,
                   branch,booked_by, cio_booking_id, prev_booking, applied_by,audit, RO_No,
              CASE @dateformat
                     WHEN 'mm/dd/yyyy' THEN convert(varchar(50) , RO_Datetime,101)
                  WHEN 'dd/mm/yyyy' THEN convert(varchar(50) ,RO_Datetime,102)
                     WHEN 'yyyy/mm/dd' THEN convert(varchar(50) ,RO_Datetime,103)  END AS RO_Date,
                Caption,bill_status, ro_status,
                TBL_BOOKING_MAST_LOG.Agency_code, Agency_address,
                Client_code, Client_address, Agency_sub_code,
                Dockit_no, Executive_code, Executive_zone,
                Product_code, Brand_code, Key_no, Bill_remarks,
                Print_remark, Package_code, No_of_insertion,
            CASE @dateformat
                     WHEN 'mm/dd/yyyy' THEN convert(varchar(50) ,Insertion_datetime,101)
                  WHEN 'dd/mm/yyyy' THEN convert(varchar(50) ,Insertion_datetime,102)
                     WHEN 'yyyy/mm/dd' THEN convert(varchar(50) ,Insertion_datetime,103)  END AS Insertion_date,
                Repeating_day, Ad_type_code, Ad_cat_code,
                Ad_sub_cat_code, Color_code, Uom_code,
                Page_position_code, Page_type_code, Page_no,
                Ad_size_type_code, Ad_size_height, Ad_size_width,
                Rate_code, Scheme_type_code, Currency_code,
                Agrred_rate, Agreed_amount, Special_discount,
                Space_discount, Special_charges,
                TBL_BOOKING_MAST_LOG.Comp_code,
                TBL_BOOKING_MAST_LOG.Userid,
                TBL_BOOKING_MAST_LOG.Agency_status, Agency_type,
                Agency_pay, Agency_credit, Total_area, Card_rate,
                Card_amount, Discount, Discount_per, Bill_cycle,
                Revenue_center, Bill_pay, Bill_height, Bill_width,
                TBL_BOOKING_MAST_LOG.Bill_to, Invoices, Vts,
                Bill_add, Trade_disc, Agency_out,TBL_BOOKING_MAST_LOG. Booking_type,
                Campaign, Page_prem, Page_amount, Prem_per,
                Gross_amount, Bill_amount, Box_code, Box_no,
                Box_agency, Box_client, Box_address, Tfn, Coupan_ad,
                Ad_size_column, Bill_column, Bill_area,
                Special_disc_per, Space_disc_per,
                 AGENCY_MAST.Agency_Name + '('+ AGENCY_MAST.code_subcode+ ')' AS AgencyName,
                (SELECT    EXEC_MAST.Exec_name + '('+ convert(varchar(100), EXEC_MAST.Exe_no)+ ')'
                   FROM EXEC_MAST  WHERE TBL_BOOKING_MAST_LOG.Executive_code = EXEC_MAST.Exe_no
                    AND TBL_BOOKING_MAST_LOG.Comp_code = EXEC_MAST.comp_code)AS execname,
                (SELECT    PRODUCT_CAT_MAST.prod_desc + '(' + PRODUCT_CAT_MAST.prod_cat_code + ')'
                   FROM PRODUCT_CAT_MAST WHERE TBL_BOOKING_MAST_LOG.Product_code =PRODUCT_CAT_MAST.prod_cat_code
                    AND TBL_BOOKING_MAST_LOG.Comp_code =PRODUCT_CAT_MAST.comp_code)AS product,
                Paid_ins, Contract_rate, Deviation, Variant_code,
                Contract_name, Contract_type, Card_name, Card_type,
                Card_month, Card_year, Card_number, Receipt_no,
                Ad_Subcat3, Ad_Subcat4, Ad_subcat5, Bg_color,
                Bullet_code, Bullet_premium,
                (SELECT Agency_Name FROM AGENCY_MAST WHERE code_subcode =TBL_BOOKING_MAST_LOG.Agency_sub_code)AS AgencySubCode,
                isnull ((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code = Client_code),'' ) AS Client,
                (SELECT distinct Payment_Mode_Name FROM PAYMENT_MODE_MAST WHERE Comp_Code=TBL_BOOKING_MAST_LOG. Comp_Code and Pay_Mode_Code = Agency_pay) AS PayMode,
                (SELECT Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code =TBL_BOOKING_MAST_LOG.Ad_cat_code)AS categoryname,
                (SELECT Adv_Subcat_Name FROM ADV_SUBCAT_MAST WHERE ADV_SUBCAT_MAST.Adv_Subcat_Code =TBL_BOOKING_MAST_LOG.Ad_sub_cat_code)AS subcategoryname,
                (SELECT brand_name FROM BRAND_MST WHERE brand_code =TBL_BOOKING_MAST_LOG.Brand_code)AS Brand,
                (SELECT Uom_Name FROM UOM_MAST WHERE Uom_Code =TBL_BOOKING_MAST_LOG.Uom_code)AS UOM,
                (SELECT premiumname FROM ADVPOS_PREM_MAST  WHERE Premiumcode =TBL_BOOKING_MAST_LOG.Page_type_code)AS PagePremium,
                (SELECT Pos_Type FROM ADVPOS_TYPE_MAST WHERE Pos_Type_Code = TBL_BOOKING_MAST_LOG.Page_position_code)AS PositionPremium,
                (SELECT Curr_Name FROM CURR_MAST WHERE Curr_Code =TBL_BOOKING_MAST_LOG.Currency_code)AS Currency
           FROM TBL_BOOKING_MAST_LOG, AGENCY_MAST
          WHERE TBL_BOOKING_MAST_LOG.Receipt_no = @ciobookid
            AND VSEQNO =(SELECT MAX (VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE Receipt_no = @ciobookid AND VSEQNO <
            (SELECT MAX(VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE Receipt_no = @ciobookid) AND audit IS NOT NULL)
                        AND AGENCY_MAST.code_subcode = TBL_BOOKING_MAST_LOG.Agency_sub_code 
AND AGENCY_MAST.Comp_Code = TBL_BOOKING_MAST_LOG. Comp_Code

/*============================================================================================*/
/*********************** Issue 5846  29/11/2011  *******************/

ALTER PROCEDURE   [dbo].[subcatexe]
@compcode as varchar(8),
@catcode as varchar(8),
@subcatcode as varchar(8),
@subcatname as varchar(50),
@subcatalias as varchar(50),
@userid as varchar(8)


AS


CREATE TABLE #subcatdummy (
	Comp_Code varchar (8)  ,
	Adv_Cat_Code varchar (8)  ,
	Adv_Subcat_Code varchar (8)  ,
	Adv_Subcat_Name varchar (50)  ,
	Adv_Subcat_Alias varchar (50)  ,
	Userid varchar (8)  ,
	Creation_Datetime datetime,
	Image_name varchar(100),
	ADMINWEBXML varchar(50) ,
	PRIORITY varchar(50) ,
	STATUS  VARCHAR(5)
) 


set @subcatname=replace(@subcatname,'''','''''')
set @subcatalias=replace(@subcatalias,'''','''''')








declare @query as varchar(1500)

--delete subcatdummy 


set @query='insert #subcatdummy select comp_code,adv_cat_code,adv_subcat_code,adv_subcat_name,adv_subcat_alias,userid,getdate(),Image_name,ADMINWEBXML,PRIORITY,STATUS from adv_subcat_mast where comp_code='''+@compcode+''' '
print(@catcode)
print(@subcatcode)

if(@catcode <> '0' )


begin
set @query= @query+' and adv_cat_code  = '''+@catcode+''''
end

if(@subcatcode <> '')

begin
set @query= @query+' and adv_subcat_code like ''%'+@subcatcode+'%'''
end

if(@subcatname <> '')


begin
set @query= @query+' and adv_subcat_name like ''%'+@subcatname+'%'''
end

if(@subcatalias <> '')

begin
set @query= @query+' and adv_subcat_alias  like ''%'+@subcatalias+'%'''
end

print(@query)
exec(@query)
--select * from subcatdummy 

select * from #subcatdummy 
drop table  #subcatdummy 
--print(@query)
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE  [dbo].[subcatsave]
@compcode as varchar(8),
@catcode as varchar(8),
@subcatcode as varchar(8),
@subcatname as varchar(50),
@subcatalias as varchar(50),
@userid as varchar(8),
@imagename as varchar(100),
@subcatxml as varchar(50),
@pri as varchar(50),
@status1   as varchar(5)

AS

insert into adv_subcat_mast(comp_code,adv_cat_code,adv_subcat_code,adv_subcat_name,adv_subcat_alias,userid,creation_datetime,image_name, ADMINWEBXML,PRIORITY,STATUS) values(@compcode,@catcode,@subcatcode,@subcatname,@subcatalias,@userid,getdate(),@imagename,@subcatxml,@pri,@status1)
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[subcatupdate]

@compcode as varchar(8),
@catcode as varchar(8),
@subcatcode as varchar(8),
@subcatname as varchar(50),
@subcatalias as varchar(50),
@userid as varchar(8),
@imagename as varchar(100),
@subcatxml as varchar(50),
@pri as varchar(50),
@status1   as varchar(5)




 AS
declare @query as varchar (900)
declare @query1 as varchar(900)



set @subcatname=replace(@subcatname,'''','''''')
set @subcatalias=replace(@subcatalias,'''','''''')

set @query='update adv_subcat_mast set PRIORITY='''+@pri+''',adv_subcat_name = '''+@subcatname+'''  , adv_subcat_alias = '''+@subcatalias+''',image_name='''+@imagename+''', ADMINWEBXML='''+@subcatxml+''',STATUS='''+@status1+''' where comp_code='''+@compcode+''' and adv_cat_code='''+@catcode+''' and adv_subcat_code='''+@subcatcode+''''--and userid='''+@userid+'''
set @query1='update subcatdummy set adv_subcat_name = '''+@subcatname+'''  , adv_subcat_alias = '''+@subcatalias+''',image_name='''+@imagename+''', ADMINWEBXML='''+@subcatxml+''' where comp_code='''+@compcode+'''  and adv_cat_code='''+@catcode+''' and adv_subcat_code='''+@subcatcode+''''--and userid='''+@userid+'''
exec(@query)
print(@query)

print(@query1)

exec(@query1)
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER PROCEDURE  [dbo].[advcatexec]

@compcode as varchar(8),
--@userid as varchar(8),
@adcatcode as varchar(8),
@catalias as varchar(50),
@catname as varchar(50),
@adtype as varchar(8)
--@catediname as varchar(8)


 AS


declare @query as varchar(1000)

--delete from advdummy

CREATE TABLE #ADV_CAT_MAST (
	Comp_Code varchar (8),
	Adv_Cat_Code varchar (8),
	Adv_Cat_Name varchar (50),
	Adv_Cat_Alias varchar (50),
	UserId varchar (8),
	Creation_Datetime datetime ,
	Adv_Type varchar (10) ,
	REGCLIENT VARCHAR(10),
CAT_FILE_NAME VARCHAR(50),
STATUS  VARCHAR(5)
)

set @query=' insert  into #ADV_CAT_MAST select Comp_Code, adv_cat_code, Adv_Cat_Name,Adv_Cat_Alias,/*Edition_Code,*/userid, getdate(),Adv_Type,REGCLIENT,CAT_FILE_NAME,STATUS  from adv_cat_mast where  Comp_Code='''+@compcode+'''  '--and  userid='''+@userid+''''


if(@adcatcode <>  null)

print(@adcatcode)

begin
set @query=@query+'  and  adv_cat_code like''%'+@adcatcode+'%'''
end

if(@catalias  <> null)

print(@catalias)

begin
set @query=@query+'and  Adv_Cat_Alias  like''%'+@catalias+'%'''
end

if(@adtype <>  '0')
print(@adtype)
begin
set @query=@query+'and Adv_Type like''%'+@adtype+'%'''
end


/*
if(@catediname <> null)
print(@catediname) 
begin
set @query=@query+'   and        Edition_Code    like  ''%'+@catediname+'%'''
end
*/

if(@catname <> null)
print(@catname)
begin
set @query=@query+'and Adv_Cat_Name like''%'+@catname+'%'''
end





print(@query)
exec(@query)

--select distinct * from advdummy order by adv_cat_code
select distinct * from #ADV_CAT_MAST order by adv_cat_code
drop table #ADV_CAT_MAST


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[advupdate]
@compcode as varchar(8),
--@userid as varchar(8),
@adcatcode as varchar(8),
@catalias as varchar(50),
@catname as varchar(50),
@adtype as varchar(8),
@rclient as varchar(10),
@filename as varchar(50),
@status1   as varchar(5)

 AS


begin
update Adv_Cat_Mast set REGCLIENT=@rclient, adv_cat_name=@catname,adv_cat_alias=@catalias,/*edition_code=@catediname,*/creation_datetime=getdate(),Adv_Type=@adtype,CAT_FILE_NAME=@filename,STATUS=@status1 where comp_code=@compcode /*and userid=@userid */and adv_cat_code =@adcatcode

--update advdummy set adv_cat_name=@catname,adv_cat_alias=@catalias,/*edition_code=@catediname,*/creation_datetime=getdate() where comp_code=@compcode and /*userid=@userid and*/ adv_cat_code =@adcatcode

end


--update Client_cont_details set Cont_Person=@contactperson,DOB=@dob,phone=@phone,Extension=@ext,Fax=@fax,EmailId=@mail where  userid=@userid and CUST_CODE=@custcode and COMP_CODE=@compcode  and cont_code=@update

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE  [dbo].[advinsert]

@compcode as varchar(8),
@userid as varchar(8),
@adcatcode as varchar(8),
@catalias as varchar(50),
@catname as varchar(50),
@adtype as varchar(8),
@rclient as varchar(30),
@filename as varchar(50),
@status1   as varchar(5)

 AS

begin

insert into Adv_Cat_Mast (Comp_Code, userid, adv_cat_code,adv_cat_name,adv_cat_alias,/*edition_code,*/creation_datetime,Adv_Type,REGCLIENT,CAT_FILE_NAME,STATUS) values (@compcode, @userid, @adcatcode,  @catname, @catalias,/*@catediname,*/getdate(),@adtype,@rclient,@filename,@status1);

end


/*********************** End of Issue 5846 29/11/2011  *******************/

/*******************************************mimoh 6/12/2011*******************0005879********************************/
alter  procedure  retselectstructslab
(
@compcode as varchar(20),
@userid as varchar(20),
@retcode as varchar(20),
@code11 as int


)

as

select TEAM_CODE,ADCTG_CODE,FROM_TGT,TO_TGT,CUST_TYPE,AD_TYPE,PUB_TYPE,PUBL_CODE,COMM_TARGET_ID from RETAIN_COMM_TARGET where COMP_CODE=@compcode and RETAIN_CODE=@retcode and COMM_TARGET_ID=@code11



@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22
create  PROCEDURE AD_RETAIN_COMM_TARGET_BIND
(
@retcode as varchar(20),
@userid as varchar(20),
@compcode as varchar(20)
)

as

select * from RETAIN_COMM_TARGET where COMP_CODE=@compcode  and RETAIN_CODE=@retcode

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER  procedure [dbo].[insertretstatus_slab]
(
@compcode as varchar(20),
@userid as varchar(20),
@retcode as varchar(20),
--enln as varchar(20), 
@fromdays as varchar(20),
@todays as varchar(20),
@drpcommon as varchar(20),
@commrate as varchar(20),
@P_COMM_TARGET_ID as varchar(20)
)

as
declare @enlncode as int

select @enlncode=max(isnull(ENLN,0)+1) from RETAIN_COMM_SLAB

insert into retain_comm_slab(COMP_CODE,RETAIN_CODE,ENLN,FROM_DAYS,TILL_DAYS,COMM_ON,COMM_RATE,CREATED_BY,CREATED_DATE,UPDATED_BY,UPDATED_DATE,COMM_TARGET_ID) 
values(@compcode,@retcode,@enlncode,@fromdays,@todays,@drpcommon,@commrate,@userid,getdate(),'','',@P_COMM_TARGET_ID)

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER proc [dbo].[RetainerInsertDetail]
(
@Comp_Code1 as varchar(8),
@Retain_Code1 as varchar(8),
@userid1 as varchar(10),
@Retain_Name1 as varchar(150),
@Retain_Alias1 as varchar(150),
@Add11 as varchar(50) ,
@Street1 as varchar(50) ,
@City_Code1 as varchar(8),
@pubcent1   as varchar(20),
@Zip1 as varchar(12) ,
@Dist_Code1 as varchar(8) ,
@State_Code1 as varchar(8),
@zone_code1 as varchar(10),
@region_code1 as varchar(10),
@Country_Code1 as varchar(8),
@phone11 as varchar(30) ,
@Phone21 as varchar(30) ,
@Fax1 as varchar(30) ,
@EmailID1 as varchar(200) ,
@PAN_No1 as varchar(30) ,
@Credit_Days1 as varchar(5),
@Remarks1 as varchar(200) ,

@flag as int,
@Box1 as varchar(50),
@Publication11 as varchar(50),
@Edition11 as varchar(50),
@Supplement11 as varchar(50),
@taluka as varchar(23),
@repname as varchar(23),
@branchcode  as varchar(20),
@creditlimit  as varchar(50),
@mobile1 as varchar(20),
@signature	as varchar(50)
)
as

declare @query varchar(1000)
declare @query3 varchar(1000)


if(@flag=0)
begin

set @query = 'insert into RetainerMaster(Comp_Code ,Retain_Code ,userid ,Retain_Name ,Retain_Alias ,Add1 ,Street ,City_Code ,Zip ,Dist_Code ,State_Code ,Zone_Code,Region_Code,Country_Code ,phone1 ,Phone2 ,Fax ,EmailID ,PAN_No ,Credit_Days,Remarks , pubcent_code,Creation_Datetime, retain_status, to_date,BOXMATTER,PUBLICATION,EDITION,SUPPLEMENT,TALUKA,REPRESENTATIVE,Branch_code,CREDIT_LIMIT,MOBILENO,SIGN)values ('''+@Comp_Code1+''' ,'''+@Retain_Code1+''' ,'''+@userid1+''' ,'''+@Retain_Name1+''' ,'''+@Retain_Alias1+''' ,'''+@Add11+''' ,'''+@Street1+''','''+@City_Code1+''' ,'''+@Zip1+''' ,'''+@Dist_Code1+''','''+@State_Code1+''' ,'''+@zone_code1+''' ,'''+@region_code1+''' ,'''+@Country_Code1+''' ,'''+@phone11+''' ,'''+@Phone21+''' ,'''+@Fax1+''','''+@EmailID1+''','''+@PAN_No1+''' ,'''+@Credit_Days1+''' ,'''+@Remarks1+''','''+@pubcent1+''',getdate(),'''','''','''+@Box1+''','''+@Publication11+''' ,'''+@Edition11+''','''+@Supplement11+''','''+@taluka+''','''+@repname+''','''+@branchcode+''','''+@creditlimit+''','''+ @mobile1+''','''+@signature+''') '

end
if(@flag=1)
begin  
	set @query = 'update RetainerMaster set Retain_Name = '''+@Retain_Name1+'''  ,Retain_Alias = '''+@Retain_Alias1+'''  ,Add1 = '''+@Add11 +''',Street = '''+@Street1+''' ,City_Code = '''+@City_Code1+'''  ,Zip = '''+@Zip1+'''  ,Dist_Code = '''+@Dist_Code1+'''  ,State_Code = '''+@State_Code1+''' ,zone_code = '''+@zone_code1+'''  ,region_code = '''+@region_code1+'''  ,Country_Code = '''+@Country_Code1+'''  ,phone1 = '''+@phone11+'''  ,Phone2 = '''+@Phone21+'''  ,Fax = '''+@Fax1+'''  ,EmailID = '''+@EmailID1+'''  ,PAN_No = '''+@PAN_No1+'''  ,Credit_Days = '''+@Credit_Days1+''',Remarks = '''+@Remarks1+''' ,    pubcent_code='''+@pubcent1+''' 
,    BOXMATTER='''+@Box1+''' ,PUBLICATION = '''+@Publication11+'''  ,EDITION = '''+@Edition11 +''',SUPPLEMENT = '''+@Supplement11+''',TALUKA='''+@taluka+''',REPRESENTATIVE='''+@repname+''',Branch_code='''+@branchcode+''',CREDIT_LIMIT='''+@creditlimit+''',MOBILENO='''+ @mobile1+''',SIGN='''+@signature+''' where comp_code = '''+@Comp_Code1 +''' and Retain_Code = '''+@Retain_Code1+''''    --/*   and userid ='''+@userid+'''   */  
--set @query3 = 'update tmpretainer set Retain_Name = '''+@Retain_Name+'''  ,Retain_Alias = '''+@Retain_Alias+'''  ,Add1 = '''+@Add1 +''',Street = '''+@Street+''' ,City_Code = '''+@City_Code+'''  ,Zip = '''+@Zip+'''  ,Dist_Code = '''+@Dist_Code+'''  ,State_Code = '''+@State_Code+'''  ,Country_Code = '''+@Country_Code+'''  ,phone1 = '''+@phone1+'''  ,Phone2 = '''+@Phone2+'''  ,Fax = '''+@Fax+'''  ,EmailID = '''+@EmailID+'''  ,PAN_No = '''+@PAN_No+'''  ,Credit_Days = '''+@Credit_Days+''',Remarks = '''+@Remarks+'''   where comp_code = '''+@Comp_Code +'''and userid ='''+@userid+''' and Retain_Code = '''+@Retain_Code+'''' 
end


print(@query)
exec(@query)
--print(@query3)
--exec(@query3)










//************************************************************************************************************************

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go










ALTER PROCEDURE [dbo].[RetainerExec]

@compcode  varchar(8),
@Retain_Code  varchar(8),
@retname  varchar(150),
@retalias  varchar(150),
@citycode varchar(10),
@pubcent varchar(20),
@country varchar(8),
@Box varchar(50),
@repname  varchar(50),
@branchname  varchar(20)




AS

--saurabh added

--declare @query1 varchar(900)
declare @query2 varchar(900)
declare @query3 varchar(900)
declare @query4 varchar(900)
declare @cc varchar(28)
--declare @reatiner1 varchar(12)



--delete  from tmpretainer 

/*CREATE TABLE #RetainerMaster (
	Comp_Code varchar (8)  NOT NULL ,
	userid varchar (10)  NOT NULL ,
	Retain_Code varchar (8)  NOT NULL ,
	Retain_Name varchar (50)  NOT NULL ,
	Retain_Alias varchar (15)  NOT NULL ,
	Add1 varchar (50)  NULL ,
	Street varchar (50)  NULL ,
	City_Code varchar (8)  NOT NULL ,
	Zip varchar (12)  NULL ,
	Dist_Code varchar (8)  NULL ,
	State_Code varchar (8)  NOT NULL ,
  --  Region_Code varchar (8)  NOT NULL ,
	Country_Code varchar (8)  NOT NULL ,
	Phone1 varchar (30)  NULL ,
	Phone2 varchar (30)  NULL ,
	Fax varchar (30)  NULL ,
	EmailID varchar (50)  NULL ,
	Credit_Days varchar (5)  NULL ,
	Remarks varchar (200)  NULL ,
	PAN_No varchar (50)  NULL ,
	Retain_status varchar (50)  NULL ,
	To_date datetime NULL ,
	--status_date datetime null,
	Creation_Datetime datetime NOT NULL ,
	pubcent_code varchar (20)  NULL,
	Zone_Code  varchar (10),
	Region_Code  varchar (10),
	Branch_code  varchar (8),
    BOXMATTER varchar (50)  NULL,
	PUBLICATION varchar (50),
	EDITION  varchar (50),
	SUPPLEMENT  varchar (50),
	TALUKA  varchar (23)
) */










declare @retainer1 char(12)

declare @query  varchar(3000)
declare @query1  varchar(3000)

--set @query='insert into #RetainerMaster select Comp_Code,userid,Retain_Code,Retain_Name,Retain_Alias,Add1,Street,City_Code,Zip,Dist_Code,State_Code,Region_Code,Country_Code,Phone1,Phone2,Fax,EmailID,Credit_Days,Remarks,PAN_No,Retain_status,getdate(),getdate(),pubcent_code,BOXMATTER,PUBLICATION,EDITION,SUPPLEMENT,TALUKA from  RetainerMaster where Comp_code='''+@compcode+''''
set @query=' select Comp_Code,userid,Retain_Code,Retain_Name,Retain_Alias,Add1,Street,City_Code,Zip,Dist_Code,State_Code,Region_Code,Country_Code,Phone1,Phone2,Fax,EmailID,Credit_Days,Remarks,PAN_No,Retain_status,getdate(),getdate(),pubcent_code,BOXMATTER,PUBLICATION,EDITION,SUPPLEMENT,TALUKA,REPRESENTATIVE as "repname",Branch_code,CREDIT_LIMIT,MOBILENO,SIGN from  RetainerMaster where Comp_code='''+@compcode+''''

if(@Retain_Code <>'')

begin

set @query= @query + 'and  Retain_Code like ''%'+@Retain_Code +'%'''

end

if(@retname <>'')

--print(@retname)

begin

set @query  =  @query + 'and Retain_Name  like ''%'+@retname +'%'''

end

if(@retalias <> '')

--print(@retalias)

begin

set @query  =  @query + 'and Retain_Alias  like ''%'+@retalias+'%'''

end

if(@citycode <> '0' and @citycode <> '')

--print(@citycode)

begin

set @query  =  @query + 'and City_Code  like ''%'+@citycode +'%'''

end


if(@pubcent <> '0' and @pubcent <> '')

--print(@pubcent)

begin

set @query  =  @query + 'and pubcent_code  like ''%'+@pubcent +'%'''

end



if(@country <> '0' and @country <> '')

--print(@country)

begin

set @query  =  @query + 'and Country_Code  like ''%'+@country +'%'''

end

if(@branchname <> '0' and @branchname <> '')
begin
   set @query  =  @query + 'and Branch_code  like ''%'+@branchname +'%'''
end

print(@query)

exec(@query)


--saurabh added



/*declare retainer cursor read_only
for 

select Retain_Code from #RetainerMaster order by Retain_Code

open retainer

FETCH NEXT FROM retainer
INTO @retainer1

WHILE @@FETCH_STATUS = 0
BEGIN

set @query2='update #RetainerMaster set Retain_status =(select  status_name from tblstatus where status_code = (select top 1 status_name from RET_STATUS_DETAIL where retain_code='''+RTRIM(LTRIM(@retainer1))+'''  order by to_date desc)) where retain_code='''+@retainer1+''''

set @query3='update #RetainerMaster set status_date=(select top 1 to_date from RET_STATUS_DETAIL where retain_code='''+@retainer1+''' order by to_date desc) where retain_code='''+@retainer1+''''

set @query4='update #RetainerMaster set To_date=(select top 1 from_date from RET_STATUS_DETAIL where retain_code='''+@retainer1+''' order by from_date asc) where retain_code='''+@retainer1+''''

print(@query2)

exec(@query2)

print(@query3)

exec(@query3)

print(@query4)

exec(@query4)

FETCH NEXT FROM retainer
	INTO @retainer1


end

CLOSE retainer
DEALLOCATE retainer

select  *  from #RetainerMaster  order by  Retain_Code

drop table     #RetainerMaster*/










//**********************************************************************************************************************************
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER proc [dbo].[AdvTeamDetailSave]


@Comp_Code as varchar(8),
@Team_Code as varchar(8),
@Team_Name as varchar(20),
@userid as varchar(8),
@zone as varchar(50),
@signature as varchar(50)
as 



  insert into Adv_Exec_Master(Comp_Code,Team_Code,Team_Name,userid,creation_datetime,branch_code,SIGN) values(@Comp_Code,@Team_Code,@Team_Name,@userid,getdate(),@zone,@signature)

//****************************************************************************************************************************************
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go









ALTER  proc [dbo].[AdvTeamDetail]
(
@Comp_Code as varchar(8),
@Team_Code as varchar(8),
@Team_Name as varchar(20),
@userid as varchar(8),
@zone as varchar(50),
@Flag as int,
@signature as varchar(50)
)

as


CREATE TABLE #Adv_Exec_Master_tmp(
	Comp_Code varchar (8)  ,
	Team_Code varchar (8)  ,
	Team_Name varchar (20)  ,
    Userid varchar (8)  ,
	ad_cat varchar (50) ,
	Creation_Datetime datetime ,
    branch_code varchar(50),
	SIGN varchar(50)
) 


declare @countnum int
declare @query as varchar (1500)

set @Team_Code=replace(@Team_Code,'','''')
--set @Team_Name=replace(@Team_Name,'','''')


if(@Flag=0)
begin
 set  @query='insert #Adv_Exec_Master_tmp select  Comp_Code,Team_Code,Team_Name,userid,creation_datetime,ad_cat,branch_code,SIGN  from Adv_Exec_Master  where Comp_Code='''+@Comp_Code+''' '  ---and userid='''+@userid+'''and Team_Code like '%''@Team_Code''%' and Team_Name like '%@Team_Name%'


if(@Team_Code <>'')
begin
set @query=@query+'and Team_Code like ''%'+@Team_Code+'%'''
end

if(@Team_Name <>'')
begin
set @query=@query+'and Team_Name like ''%'+@Team_Name+'%'''
end

/*if(@cat <>"0")
begin
set @query=@query+'and ad_cat like''%'+@cat+'%'''
end */

if(@zone <> '0')
begin
set @query=@query+'and branch_code like''%'+@zone+'%'''
end

print(@query)
exec(@query)
		
select * from #Adv_Exec_Master_tmp where  Comp_Code = @Comp_Code --and userid=@userid
end

else if(@Flag=1)
	begin
	      insert into Adv_Exec_Master(Comp_Code,Team_Code,Team_Name,userid,creation_datetime,branch_code,SIGN) values(@Comp_Code,@Team_Code,@Team_Name,@userid,getdate(),@zone,@signature) 
        --insert  Exec_mast select Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,zip,phone,exe_status,userid,comp_code,creation_datetime,pin_code from tmp_exec_mast where Team_code = @Team_Code and comp_code = @Comp_Code and userid=@userid
	end

else if(@Flag=2)
	begin

		declare @teamnm as varchar(30)
		declare @regionnm as varchar(30)
			update Adv_Exec_Master set Team_Name=@Team_Name  , branch_code=@zone,SIGN=@signature where Team_Code=@Team_Code and Comp_Code=@Comp_Code  --and userid=@userid	
             -- update exec_mast set Branch_code=@zone where Team_code=@Team_Code and comp_code=@Comp_Code
          --update temp_Adv_Exec set Team_Name = @Team_Name where Team_Code = @Team_Code	and Comp_Code = @Comp_Code and userid=@userid
    end

else if(@Flag=3)
	begin
		print(@Flag)
select @countnum=count(*) from tbl_booking_mast where executive_code in(select exe_no from Exec_mast where Team_Code = @Team_Code)
	if @countnum = 0 
	begin
		delete from Adv_Exec_Master where  Comp_Code=@Comp_Code and Team_Code = @Team_Code and Team_Name = @Team_Name and   branch_code=@zone  --and userid=@userid  
		delete from Exec_mast where  Comp_Code = @Comp_Code and Team_Code = @Team_Code --and userid=@userid
        delete from exec_adcat where TEAMCODE=@Team_Code    
	end
 --delete from temp_Adv_Exec where  Comp_Code = @Comp_Code and Team_Code = @Team_Code and Team_Name = @Team_Name and userid=@userid
	end
else if(@Flag=5)
	begin
		/*check if the team code is present or not */
		select * from exec_mast where  Comp_Code = @Comp_Code and Team_Code = @Team_Code --and userid=@userid
	end
else if(@Flag=6)
	begin
		select * from adv_exec_master where  Comp_Code = @Comp_Code and Team_Code = @Team_Code --and userid=@userid
	end
else
	begin
		select * from #Adv_Exec_Master_tmp where Comp_Code = @Comp_Code  --and userid=@userid
	end

drop table #Adv_Exec_Master_tmp

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
create procedure gencodeforcommstruct
(
@p_compcode                                   VARCHAR(4000) ,
@p_userid                                   VARCHAR(4000) 
)
AS 
	BEGIN
		DECLARE @num     int
	SELECT @num  =  ISNULL(MAX(COMM_TARGET_ID), 0) + 1 FROM  RETAIN_COMM_TARGET 

 select @num  AS "IDNO"
		

END

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@2
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER PROCEDURE  [dbo].[AD_RETAIN_ADD_COMM_TARGET_INS] (@PCOMP_CODE       AS VARCHAR(40),
												@PRETAIN_CODE     AS VARCHAR(40),
												@PPUBL_CODE       AS VARCHAR(40),
												@PNO_OF_PUBL      AS VARCHAR(40),
												@PADCOMM_PER        AS NUMERIC,
												@PCOMM_TYPE       AS VARCHAR(40),
												@PCREATED_BY      AS VARCHAR(40),
												@PCREATED_DT      AS DATETIME,
												@PUPDATED_BY      AS VARCHAR(40),
												@PUPDATED_DT      AS DATETIME,
												@PCOMM_TARGET_ID  AS NUMERIC,
												@PADD_COMM_ID	  AS NUMERIC,
												@PDML_TYPE        AS VARCHAR(40)) AS

BEGIN
 IF ISNULL(@PDML_TYPE,'?')='I' 
   BEGIN 
     INSERT INTO retain_adcomm_target (COMP_CODE, RETAIN_CODE, PUBL_CODE, NO_OF_PUBL,ADCOMM_PER,
									  COMM_TYPE, CREATED_BY, CREATED_DT, UPDATED_BY, UPDATED_DT,COMM_TARGET_ID)
                            VALUES  (@PCOMP_CODE,@PRETAIN_CODE,@PPUBL_CODE,@PNO_OF_PUBL,@PADCOMM_PER,
                                     @PCOMM_TYPE,getdate(),@PCREATED_DT,@PUPDATED_BY,@PUPDATED_DT,@PCOMM_TARGET_ID)
   END
 IF ISNULL(@PDML_TYPE,'?')='U' 
   BEGIN
     UPDATE retain_adcomm_target SET PUBL_CODE = @PPUBL_CODE, NO_OF_PUBL = @PNO_OF_PUBL, ADCOMM_PER = @PADCOMM_PER,
                                   COMM_TYPE = @PCOMM_TYPE,UPDATED_BY = @PUPDATED_BY,UPDATED_DT = getdate()
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
          AND ADD_COMM_ID = @PADD_COMM_ID;
   END
 IF ISNULL(@PDML_TYPE,'?')='D' 
   BEGIN
     DELETE FROM retain_adcomm_target
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
         AND ADD_COMM_ID = @PADD_COMM_ID;
   END
END





@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@



ALTER  procedure [dbo].[retaddselectslab]
(
@compcode as varchar(20),
@userid as varchar(20),
@retcode as varchar(20),
@code11 as int


)

as

select  PUBL_CODE, NO_OF_PUBL,ADCOMM_PER,COMM_TYPE,COMM_TARGET_ID from retain_adcomm_target where COMP_CODE=@compcode and RETAIN_CODE=@retcode and ADD_COMM_ID=@code11

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER    PROCEDURE  [dbo].[AD_RETAIN_COMM_TARGET_INS] (@PCOMP_CODE       AS VARCHAR(40),
												@PRETAIN_CODE     AS VARCHAR(40),
												@PTEAM_CODE       AS VARCHAR(40),
												@PADCTG_CODE      AS VARCHAR(40),
												@PFROM_TGT        AS NUMERIC,
												@PTO_TGT          AS NUMERIC,
												@PCUST_TYPE       AS VARCHAR(40),
												@PAD_TYPE         AS VARCHAR(40),
												@PPUB_TYPE        AS VARCHAR(40),
												@PPUBL_CODE       AS VARCHAR(40),
												@PCREATED_BY      AS VARCHAR(40),
												@PCREATED_DT      AS DATETIME,
												@PUPDATED_BY      AS VARCHAR(40),
												@PUPDATED_DT      AS DATETIME,
												@PCOMM_TARGET_ID  AS NUMERIC,
												@PDML_TYPE        AS VARCHAR(40)) AS
BEGIN
 IF ISNULL(@PDML_TYPE,'?')='I' 
   BEGIN 
     INSERT INTO RETAIN_COMM_TARGET (COMP_CODE,RETAIN_CODE,TEAM_CODE,ADCTG_CODE,FROM_TGT,
                                     TO_TGT,CUST_TYPE,AD_TYPE,PUB_TYPE,PUBL_CODE,
                                     CREATED_BY,CREATED_DT,UPDATED_BY,UPDATED_DT,COMM_TARGET_ID)
                            VALUES  (@PCOMP_CODE,@PRETAIN_CODE,@PTEAM_CODE,@PADCTG_CODE,@PFROM_TGT,
                                     @PTO_TGT,@PCUST_TYPE,@PAD_TYPE,@PPUB_TYPE,@PPUBL_CODE,
                                     @PCREATED_BY,@PCREATED_DT,@PUPDATED_BY,@PUPDATED_DT,@PCOMM_TARGET_ID);
   END
 IF ISNULL(@PDML_TYPE,'?')='U' 
   BEGIN
     UPDATE RETAIN_COMM_TARGET SET TEAM_CODE = @PTEAM_CODE, ADCTG_CODE = @PADCTG_CODE, FROM_TGT = @PFROM_TGT,
                                   TO_TGT = @PTO_TGT, CUST_TYPE = @PCUST_TYPE, AD_TYPE = @PAD_TYPE,
                                   PUB_TYPE = @PPUB_TYPE, PUBL_CODE = @PPUBL_CODE, CREATED_BY = @PCREATED_BY,
                                   CREATED_DT = @PCREATED_DT,UPDATED_BY = @PUPDATED_BY,UPDATED_DT = @PUPDATED_DT
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
          AND COMM_TARGET_ID = @PCOMM_TARGET_ID;
   END
 IF ISNULL(@PDML_TYPE,'?')='D' 
   BEGIN
     DELETE FROM RETAIN_COMM_TARGET
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
          AND COMM_TARGET_ID = @PCOMM_TARGET_ID;
   END
END



@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER  PROCEDURE [dbo].[retaddstatusbind]
(
@retcode as varchar(20),
@userid as varchar(20),
@compcode as varchar(20),
@commid as varchar(20)
)

as

select * from retain_adcomm_target where COMP_CODE=@compcode  and RETAIN_CODE=@retcode and COMM_TARGET_ID=@commid
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


ALTER  PROCEDURE [dbo].[sp_retstatusbind_b]
(
@retcode as varchar(20),
@userid as varchar(20),
@compcode as varchar(20),
@commid as varchar(20)
)

as

select * from retain_comm_slab where COMP_CODE=@compcode  and RETAIN_CODE=@retcode and COMM_TARGET_ID=@commid


/****************************************************************************************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER  PROCEDURE [dbo].[AD_RETAIN_COMM_TARGET_BIND]
(
@retcode as varchar(20),
@userid as varchar(20),
@compcode as varchar(20)
)

as

select * from RETAIN_COMM_TARGET where COMP_CODE=@compcode  and RETAIN_CODE=@retcode 



/*************************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER  procedure  [dbo].[retselectstructslab]
(
@compcode as varchar(20),
@userid as varchar(20),
@retcode as varchar(20),
@code11 as int


)

as

select TEAM_CODE,ADCTG_CODE,FROM_TGT,TO_TGT,CUST_TYPE,AD_TYPE,PUB_TYPE,PUBL_CODE,COMM_TARGET_ID from RETAIN_COMM_TARGET where COMP_CODE=@compcode and RETAIN_CODE=@retcode and COMM_TARGET_ID=@code11




/****************************/


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER    PROCEDURE  [dbo].[AD_RETAIN_COMM_TARGET_INS] (@PCOMP_CODE       AS VARCHAR(40),
												@PRETAIN_CODE     AS VARCHAR(40),
												@PTEAM_CODE       AS VARCHAR(40),
												@PADCTG_CODE      AS VARCHAR(40),
												@PFROM_TGT        AS NUMERIC,
												@PTO_TGT          AS NUMERIC,
												@PCUST_TYPE       AS VARCHAR(40),
												@PAD_TYPE         AS VARCHAR(40),
												@PPUB_TYPE        AS VARCHAR(40),
												@PPUBL_CODE       AS VARCHAR(40),
												@PCREATED_BY      AS VARCHAR(40),
												@PCREATED_DT      AS DATETIME,
												@PUPDATED_BY      AS VARCHAR(40),
												@PUPDATED_DT      AS DATETIME,
												@PCOMM_TARGET_ID  AS NUMERIC,
												@PDML_TYPE        AS VARCHAR(40)) AS
BEGIN
 IF ISNULL(@PDML_TYPE,'?')='I' 
   BEGIN 
     INSERT INTO RETAIN_COMM_TARGET (COMP_CODE,RETAIN_CODE,TEAM_CODE,ADCTG_CODE,FROM_TGT,
                                     TO_TGT,CUST_TYPE,AD_TYPE,PUB_TYPE,PUBL_CODE,
                                     CREATED_BY,CREATED_DT,UPDATED_BY,UPDATED_DT,COMM_TARGET_ID)
                            VALUES  (@PCOMP_CODE,@PRETAIN_CODE,@PTEAM_CODE,@PADCTG_CODE,@PFROM_TGT,
                                     @PTO_TGT,@PCUST_TYPE,@PAD_TYPE,@PPUB_TYPE,@PPUBL_CODE,
                                     @PCREATED_BY,@PCREATED_DT,@PUPDATED_BY,@PUPDATED_DT,@PCOMM_TARGET_ID);
   END
 IF ISNULL(@PDML_TYPE,'?')='U' 
   BEGIN
     UPDATE RETAIN_COMM_TARGET SET TEAM_CODE = @PTEAM_CODE, ADCTG_CODE = @PADCTG_CODE, FROM_TGT = @PFROM_TGT,
                                   TO_TGT = @PTO_TGT, CUST_TYPE = @PCUST_TYPE, AD_TYPE = @PAD_TYPE,
                                   PUB_TYPE = @PPUB_TYPE, PUBL_CODE = @PPUBL_CODE, CREATED_BY = @PCREATED_BY,
                                   CREATED_DT = @PCREATED_DT,UPDATED_BY = @PUPDATED_BY,UPDATED_DT = @PUPDATED_DT
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
          AND COMM_TARGET_ID = @PCOMM_TARGET_ID;
   END
 IF ISNULL(@PDML_TYPE,'?')='D' 
   BEGIN
     DELETE FROM RETAIN_COMM_TARGET
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
          AND COMM_TARGET_ID = @PCOMM_TARGET_ID;
   END
END



/********************************************************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER  procedure [dbo].[insertretstatus_slab]
(
@compcode as varchar(20),
@userid as varchar(20),
@retcode as varchar(20),
--enln as varchar(20), 
@fromdays as varchar(20),
@todays as varchar(20),
@drpcommon as varchar(20),
@commrate as varchar(20),
@P_COMM_TARGET_ID as varchar(20)
)

as
declare @enlncode as int

select @enlncode=max(isnull(ENLN,0)+1) from RETAIN_COMM_SLAB

insert into retain_comm_slab(COMP_CODE,RETAIN_CODE,ENLN,FROM_DAYS,TILL_DAYS,COMM_ON,COMM_RATE,CREATED_BY,CREATED_DATE,UPDATED_BY,UPDATED_DATE,COMM_TARGET_ID) 
values(@compcode,@retcode,@enlncode,@fromdays,@todays,@drpcommon,@commrate,@userid,getdate(),'','',@P_COMM_TARGET_ID)


/********************************************************/


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER    PROCEDURE  [dbo].[AD_RETAIN_COMM_TARGET_INS] (@PCOMP_CODE       AS VARCHAR(40),
												@PRETAIN_CODE     AS VARCHAR(40),
												@PTEAM_CODE       AS VARCHAR(40),
												@PADCTG_CODE      AS VARCHAR(40),
												@PFROM_TGT        AS NUMERIC,
												@PTO_TGT          AS NUMERIC,
												@PCUST_TYPE       AS VARCHAR(40),
												@PAD_TYPE         AS VARCHAR(40),
												@PPUB_TYPE        AS VARCHAR(40),
												@PPUBL_CODE       AS VARCHAR(40),
												@PCREATED_BY      AS VARCHAR(40),
												@PCREATED_DT      AS DATETIME,
												@PUPDATED_BY      AS VARCHAR(40),
												@PUPDATED_DT      AS DATETIME,
												@PCOMM_TARGET_ID  AS NUMERIC,
												@PDML_TYPE        AS VARCHAR(40)) AS
BEGIN
 IF ISNULL(@PDML_TYPE,'?')='I' 
   BEGIN 
     INSERT INTO RETAIN_COMM_TARGET (COMP_CODE,RETAIN_CODE,TEAM_CODE,ADCTG_CODE,FROM_TGT,
                                     TO_TGT,CUST_TYPE,AD_TYPE,PUB_TYPE,PUBL_CODE,
                                     CREATED_BY,CREATED_DT,UPDATED_BY,UPDATED_DT,COMM_TARGET_ID)
                            VALUES  (@PCOMP_CODE,@PRETAIN_CODE,@PTEAM_CODE,@PADCTG_CODE,@PFROM_TGT,
                                     @PTO_TGT,@PCUST_TYPE,@PAD_TYPE,@PPUB_TYPE,@PPUBL_CODE,
                                     @PCREATED_BY,@PCREATED_DT,@PUPDATED_BY,@PUPDATED_DT,@PCOMM_TARGET_ID);
   END
 IF ISNULL(@PDML_TYPE,'?')='U' 
   BEGIN
     UPDATE RETAIN_COMM_TARGET SET TEAM_CODE = @PTEAM_CODE, ADCTG_CODE = @PADCTG_CODE, FROM_TGT = @PFROM_TGT,
                                   TO_TGT = @PTO_TGT, CUST_TYPE = @PCUST_TYPE, AD_TYPE = @PAD_TYPE,
                                   PUB_TYPE = @PPUB_TYPE, PUBL_CODE = @PPUBL_CODE, CREATED_BY = @PCREATED_BY,
                                   CREATED_DT = @PCREATED_DT,UPDATED_BY = @PUPDATED_BY,UPDATED_DT = @PUPDATED_DT
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
          AND COMM_TARGET_ID = @PCOMM_TARGET_ID;
   END
 IF ISNULL(@PDML_TYPE,'?')='D' 
   BEGIN
     DELETE FROM RETAIN_COMM_TARGET
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
          AND COMM_TARGET_ID = @PCOMM_TARGET_ID;
   END
END



/*******************************************************************************************/



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER procedure [dbo].[gencodeforcommstruct]
(
@p_compcode                                   VARCHAR(4000) ,
@p_userid                                   VARCHAR(4000) 
)
AS 
	BEGIN
		DECLARE @num     int
	SELECT @num  =  ISNULL(MAX(COMM_TARGET_ID), 0) + 1 FROM  RETAIN_COMM_TARGET 

 select @num  AS "IDNO"
		

END

/**********************************************/



/*****************************************************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER  procedure [dbo].[retaddselectslab]
(
@compcode as varchar(20),
@userid as varchar(20),
@retcode as varchar(20),
@code11 as int


)

as

select  PUBL_CODE, NO_OF_PUBL,ADCOMM_PER,COMM_TYPE,COMM_TARGET_ID,ADD_COMM_ID from retain_adcomm_target where COMP_CODE=@compcode and RETAIN_CODE=@retcode and ADD_COMM_ID=@code11






/*****************************************************************/

ALTER  procedure [dbo].[retaddselectslab]
(
@compcode as varchar(20),
@userid as varchar(20),
@retcode as varchar(20),
@code11 as int


)

as

select  PUBL_CODE, NO_OF_PUBL,ADCOMM_PER,COMM_TYPE,COMM_TARGET_ID from retain_adcomm_target where COMP_CODE=@compcode and RETAIN_CODE=@retcode and ADD_COMM_ID=@code11

/**************************************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER proc [dbo].[RetainerInsertDetail]
(
@Comp_Code1 as varchar(8),
@Retain_Code1 as varchar(8),
@userid1 as varchar(10),
@Retain_Name1 as varchar(150),
@Retain_Alias1 as varchar(150),
@Add11 as varchar(50) ,
@Street1 as varchar(50) ,
@City_Code1 as varchar(8),
@pubcent1 as varchar(20),
@Zip1 as varchar(12) ,
@Dist_Code1 as varchar(8) ,
@State_Code1 as varchar(8),
@zone_code1 as varchar(10),
@region_code1 as varchar(10),
@Country_Code1 as varchar(8),
@phone11 as varchar(30) ,
@Phone21 as varchar(30) ,
@Fax1 as varchar(30) ,
@EmailID1 as varchar(200) ,
@PAN_No1 as varchar(30) ,
@Credit_Days1 as varchar(5),
@Remarks1 as varchar(200) ,

@flag as int,
@Box1 as varchar(50),
@Publication11 as varchar(50),
@Edition11 as varchar(50),
@Supplement11 as varchar(50),
@taluka as varchar(23),
@repname as varchar(23),
@branchcode as varchar(20),
@creditlimit as varchar(50),
@mobile1 as varchar(20),
@signature	as varchar(50)
)
as

declare @query varchar(1000)
declare @query3 varchar(1000)


if(@flag=0)
begin

set @query = 'insert into RetainerMaster(Comp_Code ,Retain_Code ,userid ,Retain_Name ,Retain_Alias ,Add1 ,Street ,City_Code ,Zip ,Dist_Code ,State_Code ,Zone_Code,Region_Code,Country_Code ,phone1 ,Phone2 ,Fax ,EmailID ,PAN_No ,Credit_Days,Remarks , pubcent_code,Creation_Datetime, retain_status, to_date,BOXMATTER,PUBLICATION,EDITION,SUPPLEMENT,TALUKA,REPRESENTATIVE,Branch_code,CREDIT_LIMIT,MOBILENO,SIGN)values ('''+@Comp_Code1+''' ,'''+@Retain_Code1+''' ,'''+@userid1+''' ,'''+@Retain_Name1+''' ,'''+@Retain_Alias1+''' ,'''+@Add11+''' ,'''+@Street1+''','''+@City_Code1+''' ,'''+@Zip1+''' ,'''+@Dist_Code1+''','''+@State_Code1+''' ,'''+@zone_code1+''' ,'''+@region_code1+''' ,'''+@Country_Code1+''' ,'''+@phone11+''' ,'''+@Phone21+''' ,'''+@Fax1+''','''+@EmailID1+''','''+@PAN_No1+''' ,'''+@Credit_Days1+''' ,'''+@Remarks1+''','''+@pubcent1+''',getdate(),'''','''','''+@Box1+''','''+@Publication11+''' ,'''+@Edition11+''','''+@Supplement11+''','''+@taluka+''','''+@repname+''','''+@branchcode+''','''+@creditlimit+''','''+ @mobile1+''','''+@signature+''') '

end
if(@flag=1)
begin 
set @query = 'update RetainerMaster set Retain_Name = '''+@Retain_Name1+''' ,Retain_Alias = '''+@Retain_Alias1+''' ,Add1 = '''+@Add11 +''',Street = '''+@Street1+''' ,City_Code = '''+@City_Code1+''' ,Zip = '''+@Zip1+''' ,Dist_Code = '''+@Dist_Code1+''' ,State_Code = '''+@State_Code1+''' ,zone_code = '''+@zone_code1+''' ,region_code = '''+@region_code1+''' ,Country_Code = '''+@Country_Code1+''' ,phone1 = '''+@phone11+''' ,Phone2 = '''+@Phone21+''' ,Fax = '''+@Fax1+''' ,EmailID = '''+@EmailID1+''' ,PAN_No = '''+@PAN_No1+''' ,Credit_Days = '''+@Credit_Days1+''',Remarks = '''+@Remarks1+''' , pubcent_code='''+@pubcent1+''' 
, BOXMATTER='''+@Box1+''' ,PUBLICATION = '''+@Publication11+''' ,EDITION = '''+@Edition11 +''',SUPPLEMENT = '''+@Supplement11+''',TALUKA='''+@taluka+''',REPRESENTATIVE='''+@repname+''',Branch_code='''+@branchcode+''',CREDIT_LIMIT='''+@creditlimit+''',MOBILENO='''+ @mobile1+''',SIGN='''+@signature+''' where comp_code = '''+@Comp_Code1 +''' and Retain_Code = '''+@Retain_Code1+'''' --/* and userid ='''+@userid+''' */ 
--set @query3 = 'update tmpretainer set Retain_Name = '''+@Retain_Name+''' ,Retain_Alias = '''+@Retain_Alias+''' ,Add1 = '''+@Add1 +''',Street = '''+@Street+''' ,City_Code = '''+@City_Code+''' ,Zip = '''+@Zip+''' ,Dist_Code = '''+@Dist_Code+''' ,State_Code = '''+@State_Code+''' ,Country_Code = '''+@Country_Code+''' ,phone1 = '''+@phone1+''' ,Phone2 = '''+@Phone2+''' ,Fax = '''+@Fax+''' ,EmailID = '''+@EmailID+''' ,PAN_No = '''+@PAN_No+''' ,Credit_Days = '''+@Credit_Days+''',Remarks = '''+@Remarks+''' where comp_code = '''+@Comp_Code +'''and userid ='''+@userid+''' and Retain_Code = '''+@Retain_Code+'''' 
end


print(@query)
exec(@query)
--print(@query3)
--exec(@query3)
/**************************************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER PROCEDURE [dbo].[AD_RETAIN_ADD_COMM_TARGET_INS] (@PCOMP_CODE AS VARCHAR(40),
@PRETAIN_CODE AS VARCHAR(40),
@PPUBL_CODE AS VARCHAR(40),
@PNO_OF_PUBL AS VARCHAR(40),
@PADCOMM_PER AS NUMERIC,
@PCOMM_TYPE AS VARCHAR(40),
@PCREATED_BY AS VARCHAR(40),
@PCREATED_DT AS DATETIME,
@PUPDATED_BY AS VARCHAR(40),
@PUPDATED_DT AS DATETIME,
@PCOMM_TARGET_ID AS NUMERIC,
@PADD_COMM_ID	 AS NUMERIC,
@PDML_TYPE AS VARCHAR(40)) AS

BEGIN
IF ISNULL(@PDML_TYPE,'?')='I' 
BEGIN 
INSERT INTO retain_adcomm_target (COMP_CODE, RETAIN_CODE, PUBL_CODE, NO_OF_PUBL,ADCOMM_PER,
COMM_TYPE, CREATED_BY, CREATED_DT, UPDATED_BY, UPDATED_DT,COMM_TARGET_ID)
VALUES (@PCOMP_CODE,@PRETAIN_CODE,@PPUBL_CODE,@PNO_OF_PUBL,@PADCOMM_PER,
@PCOMM_TYPE,getdate(),@PCREATED_DT,@PUPDATED_BY,@PUPDATED_DT,@PCOMM_TARGET_ID)
END
IF ISNULL(@PDML_TYPE,'?')='U' 
BEGIN
UPDATE retain_adcomm_target SET PUBL_CODE = @PPUBL_CODE, NO_OF_PUBL = @PNO_OF_PUBL, ADCOMM_PER = @PADCOMM_PER,
COMM_TYPE = @PCOMM_TYPE,UPDATED_BY = @PUPDATED_BY,UPDATED_DT = getdate()
WHERE COMP_CODE = @PCOMP_CODE
AND RETAIN_CODE = @PRETAIN_CODE
AND ADD_COMM_ID = @PADD_COMM_ID;
END
IF ISNULL(@PDML_TYPE,'?')='D' 
BEGIN
DELETE FROM retain_adcomm_target
WHERE COMP_CODE = @PCOMP_CODE
AND RETAIN_CODE = @PRETAIN_CODE
AND ADD_COMM_ID = @PADD_COMM_ID;
END
END


//***************************************************************//
ALTER proc [dbo].[RetainerInsertDetail]
(
@Comp_Code1 as varchar(8),
@Retain_Code1 as varchar(8),
@userid1 as varchar(10),
@Retain_Name1 as varchar(150),
@Retain_Alias1 as varchar(150),
@Add11 as varchar(50) ,
@Street1 as varchar(50) ,
@City_Code1 as varchar(8),
@pubcent1 as varchar(20),
@Zip1 as varchar(12) ,
@Dist_Code1 as varchar(8) ,
@State_Code1 as varchar(8),
@zone_code1 as varchar(10),
@region_code1 as varchar(10),
@Country_Code1 as varchar(8),
@phone11 as varchar(30) ,
@Phone21 as varchar(30) ,
@Fax1 as varchar(30) ,
@EmailID1 as varchar(200) ,
@PAN_No1 as varchar(30) ,
@Credit_Days1 as varchar(5),
@Remarks1 as varchar(200) ,

@flag as int,
@Box1 as varchar(50),
@Publication11 as varchar(50),
@Edition11 as varchar(50),
@Supplement11 as varchar(50),
@taluka as varchar(23),
@repname as varchar(23),
@branchcode as varchar(20),
@creditlimit as varchar(50),
@mobile1 as varchar(20),
@signature	as varchar(50)
)
as

declare @query varchar(1000)
declare @query3 varchar(1000)


if(@flag=0)
begin

set @query = 'insert into RetainerMaster(Comp_Code ,Retain_Code ,userid ,Retain_Name ,Retain_Alias ,Add1 ,Street ,City_Code ,Zip ,Dist_Code ,State_Code ,Zone_Code,Region_Code,Country_Code ,phone1 ,Phone2 ,Fax ,EmailID ,PAN_No ,Credit_Days,Remarks , pubcent_code,Creation_Datetime, retain_status, to_date,BOXMATTER,PUBLICATION,EDITION,SUPPLEMENT,TALUKA,REPRESENTATIVE,Branch_code,CREDIT_LIMIT,MOBILENO,SIGN)values ('''+@Comp_Code1+''' ,'''+@Retain_Code1+''' ,'''+@userid1+''' ,'''+@Retain_Name1+''' ,'''+@Retain_Alias1+''' ,'''+@Add11+''' ,'''+@Street1+''','''+@City_Code1+''' ,'''+@Zip1+''' ,'''+@Dist_Code1+''','''+@State_Code1+''' ,'''+@zone_code1+''' ,'''+@region_code1+''' ,'''+@Country_Code1+''' ,'''+@phone11+''' ,'''+@Phone21+''' ,'''+@Fax1+''','''+@EmailID1+''','''+@PAN_No1+''' ,'''+@Credit_Days1+''' ,'''+@Remarks1+''','''+@pubcent1+''',getdate(),'''','''','''+@Box1+''','''+@Publication11+''' ,'''+@Edition11+''','''+@Supplement11+''','''+@taluka+''','''+@repname+''','''+@branchcode+''','''+@creditlimit+''','''+ @mobile1+''','''+@signature+''') '

end
if(@flag=1)
begin 
set @query = 'update RetainerMaster set Retain_Name = '''+@Retain_Name1+''' ,Retain_Alias = '''+@Retain_Alias1+''' ,Add1 = '''+@Add11 +''',Street = '''+@Street1+''' ,City_Code = '''+@City_Code1+''' ,Zip = '''+@Zip1+''' ,Dist_Code = '''+@Dist_Code1+''' ,State_Code = '''+@State_Code1+''' ,zone_code = '''+@zone_code1+''' ,region_code = '''+@region_code1+''' ,Country_Code = '''+@Country_Code1+''' ,phone1 = '''+@phone11+''' ,Phone2 = '''+@Phone21+''' ,Fax = '''+@Fax1+''' ,EmailID = '''+@EmailID1+''' ,PAN_No = '''+@PAN_No1+''' ,Credit_Days = '''+@Credit_Days1+''',Remarks = '''+@Remarks1+''' , pubcent_code='''+@pubcent1+''' 
, BOXMATTER='''+@Box1+''' ,PUBLICATION = '''+@Publication11+''' ,EDITION = '''+@Edition11 +''',SUPPLEMENT = '''+@Supplement11+''',TALUKA='''+@taluka+''',REPRESENTATIVE='''+@repname+''',Branch_code='''+@branchcode+''',CREDIT_LIMIT='''+@creditlimit+''',MOBILENO='''+ @mobile1+''',SIGN='''+@signature+''' where comp_code = '''+@Comp_Code1 +''' and Retain_Code = '''+@Retain_Code1+'''' --/* and userid ='''+@userid+''' */ 
--set @query3 = 'update tmpretainer set Retain_Name = '''+@Retain_Name+''' ,Retain_Alias = '''+@Retain_Alias+''' ,Add1 = '''+@Add1 +''',Street = '''+@Street+''' ,City_Code = '''+@City_Code+''' ,Zip = '''+@Zip+''' ,Dist_Code = '''+@Dist_Code+''' ,State_Code = '''+@State_Code+''' ,Country_Code = '''+@Country_Code+''' ,phone1 = '''+@phone1+''' ,Phone2 = '''+@Phone2+''' ,Fax = '''+@Fax+''' ,EmailID = '''+@EmailID+''' ,PAN_No = '''+@PAN_No+''' ,Credit_Days = '''+@Credit_Days+''',Remarks = '''+@Remarks+''' where comp_code = '''+@Comp_Code +'''and userid ='''+@userid+''' and Retain_Code = '''+@Retain_Code+'''' 
end


print(@query)
exec(@query)
--print(@query3)
--exec(@query3)

/******************************************************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER    PROCEDURE  [dbo].[AD_RETAIN_COMM_TARGET_INS] (@PCOMP_CODE       AS VARCHAR(40),
												@PRETAIN_CODE     AS VARCHAR(40),
												@PTEAM_CODE       AS VARCHAR(40),
												@PADCTG_CODE      AS VARCHAR(40),
												@PFROM_TGT        AS NUMERIC,
												@PTO_TGT          AS NUMERIC,
												@PCUST_TYPE       AS VARCHAR(40),
												@PAD_TYPE         AS VARCHAR(40),
												@PPUB_TYPE        AS VARCHAR(40),
												@PPUBL_CODE       AS VARCHAR(40),
												@PCREATED_BY      AS VARCHAR(40),
												@PCREATED_DT      AS DATETIME,
												@PUPDATED_BY      AS VARCHAR(40),
												@PUPDATED_DT      AS DATETIME,
												@PCOMM_TARGET_ID  AS NUMERIC,
												@PDML_TYPE        AS VARCHAR(40)) AS
BEGIN
 IF ISNULL(@PDML_TYPE,'?')='I' 
   BEGIN 
     INSERT INTO RETAIN_COMM_TARGET (COMP_CODE,RETAIN_CODE,TEAM_CODE,ADCTG_CODE,FROM_TGT,
                                     TO_TGT,CUST_TYPE,AD_TYPE,PUB_TYPE,PUBL_CODE,
                                     CREATED_BY,CREATED_DT,UPDATED_BY,UPDATED_DT,COMM_TARGET_ID)
                            VALUES  (@PCOMP_CODE,@PRETAIN_CODE,@PTEAM_CODE,@PADCTG_CODE,@PFROM_TGT,
                                     @PTO_TGT,@PCUST_TYPE,@PAD_TYPE,@PPUB_TYPE,@PPUBL_CODE,
                                     @PCREATED_BY,@PCREATED_DT,@PUPDATED_BY,@PUPDATED_DT,@PCOMM_TARGET_ID);
   END
 IF ISNULL(@PDML_TYPE,'?')='U' 
   BEGIN
     UPDATE RETAIN_COMM_TARGET SET TEAM_CODE = @PTEAM_CODE, ADCTG_CODE = @PADCTG_CODE, FROM_TGT = @PFROM_TGT,
                                   TO_TGT = @PTO_TGT, CUST_TYPE = @PCUST_TYPE, AD_TYPE = @PAD_TYPE,
                                   PUB_TYPE = @PPUB_TYPE, PUBL_CODE = @PPUBL_CODE, CREATED_BY = @PCREATED_BY,
                                   CREATED_DT = @PCREATED_DT,UPDATED_BY = @PUPDATED_BY,UPDATED_DT = @PUPDATED_DT
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
          AND COMM_TARGET_ID = @PCOMM_TARGET_ID;
   END
 IF ISNULL(@PDML_TYPE,'?')='D' 
   BEGIN
     DELETE FROM RETAIN_COMM_TARGET
        WHERE COMP_CODE      = @PCOMP_CODE
          AND RETAIN_CODE    = @PRETAIN_CODE
          AND COMM_TARGET_ID = @PCOMM_TARGET_ID;
   END
END




/*******************************************mimoh 6/12/2011*******************0005879********************************/





//////////////////////////////////////////////////////////////////////////////issue number 5877
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go












ALTER Procedure [dbo].[Websp_updatestatus]

@fromdate as VARCHAR(100),
@todate as VARCHAR(100),
@Adtype as VARCHAR(100),
@branch as VARCHAR(100),
@publication as VARCHAR(100),
@dateformat as VARCHAR(100),
@v_edition as VARCHAR(100),
@v_supplement as  VARCHAR(100),
@v_booking_audit as VARCHAR(100),
@v_status_value as VARCHAR(100),
@v_pub_cent_code as VARCHAR(100),
@comp_code as varchar(100)
as

declare @query as varchar(8000)

set @query='SELECT  DISTINCT  TBL_BOOKING_INSERT.Cio_Booking_Id,
No_Insert AS no_of_insertion ,
tbl_booking_insert.Edition,
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client,
AGENCY_MAST.Agency_Name AS Agency,
TBL_BOOKING_INSERT.Gross_Rate,
TBL_BOOKING_MAST.Trade_disc AS Commission,

CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),Insert_Date,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),Insert_Date,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),Insert_Date,102) END AS "Ins.date" ,

tbl_booking_mast.RO_No,

TBL_BOOKING_INSERT.Height AS Depth ,
TBL_BOOKING_INSERT.Width AS Width ,
TBL_BOOKING_INSERT. Size_Book AS Area,
COL_MAST.Col_Alias AS Hue,
TBL_BOOKING_INSERT.Insert_Status AS status,
TBL_BOOKING_MAST.No_of_insertion AS total,
TBL_BOOKING_MAST.Bill_remarks,
tbl_booking_insert.Page_no,

(SELECT ADVPOS_TYPE_MAST.Pos_Type FROM  ADVPOS_TYPE_MAST WHERE TBL_BOOKING_MAST.Page_position_code =ADVPOS_TYPE_MAST .Pos_Type_Code)AS Page_pos,
(select adv_cat_mast ."Adv_Cat_Name" from adv_cat_mast where tbl_booking_insert."Ad_Cat"= adv_cat_mast."Adv_Cat_Code")  as "AdCat",
tbl_booking_insert.gross_rate as   "agreed_rate" ,tbl_booking_mast.caption,
"Uom_Alias" as "Uom",


case TBL_BOOKING_INSERT."Supp_Code"
    when ''MN''then
    (select distinct EDITION_MAST."Edition_Alias" from EDITION_MAST where  tbl_booking_insert."Edition_Code"=EDITION_MAST ."Edition_Code")
    else
    (select distinct supplement_MAST."Supp_Name" from supplement_MAST where  tbl_booking_insert."Supp_Code"=supplement_MAST ."Supp_Code")
    end as "Editionname",
    tbl_booking_mast.Page_prem,
    
    CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime"
,tbl_booking_insert."Bill_Amt"
     
    


FROM TBL_BOOKING_INSERT,
TBL_BOOKING_MAST,COL_MAST,UOM_MAST,
AGENCY_MAST WHERE TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT .Cio_Booking_Id
AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code
 AND TBL_BOOKING_insert.Col_Code =COL_MAST.Col_Code 
 
 AND TBL_BOOKING_Mast."Uom_code" =UOM_MAST."Uom_Code"
AND Insert_Date BETWEEN  '''+@fromdate+''' AND  '''+@todate+''''



if(@v_status_value <> '')
begin
set @query=@query +' AND TBL_BOOKING_insert.Insert_Status ='''+@v_status_value+''' '
end 
else
begin
set @query=@query+' AND TBL_BOOKING_insert. Insert_Status in (''publish'',''booked'')'
end 












if ((@v_booking_audit ='Y')or(@v_booking_audit ='y'))
begin
set @query=@query +' AND TBL_BOOKING_MAST. audit <> ''''';

end 




IF(@Adtype <> NULL or @Adtype <> ''  )
begin
set @query=@query +' AND TBL_BOOKING_MAST. Ad_type_code ='''+@Adtype+''' ';
END

IF(@publication <> NULL or @publication <> '')
begin
set @query=@query +' AND TBL_BOOKING_insert. Publication_Code ='''+@publication+''' ';
END 



IF(@v_pub_cent_code <> NULL or @v_pub_cent_code <> ''  )
begin
set @query=@query +' AND TBL_BOOKING_insert.Pub_Cent_Code ='''+@v_pub_cent_code+''' '
--set @query=@query +' AND branch IN(SELECT Branch_CODE FROM BRANCH_MST WHERE pub_center=(SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@v_pub_cent_code+''' and comp_code='''+@comp_code+'''))'


END 




IF(@branch <>NULL or @branch <>''  )
begin
set @query=@query +' AND TBL_BOOKING_MAST.branch =ISNULL((SELECT  Branch_Code FROM BRANCH_MST  WHERE Branch_Name='''+@branch+'''),'''+@branch+''' )';
END 



IF(@v_edition  <> NULL or @v_edition  <> '')
begin
set @query=@query+' AND TBL_BOOKING_insert .Edition_Code ='''+@v_edition+''' ';
END 


IF(@v_supplement <> null or @v_supplement <> ''  )
begin
set @query=@query +' AND TBL_BOOKING_INSERT.Supp_Code ='''+@v_supplement+''' '
END 

set @query=@query + 'ORDER BY no_of_insertion,tbl_booking_insert.Page_no' 

print(@query)
exec(@query)




//////////////////////////////////////////////////////////////////////////////end of issue number 5877


































