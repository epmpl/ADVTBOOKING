//////////////shipra///////////////////done by bhanu sir///////////////////////////////


ALTER  PROCEDURE [dbo].[getapprovalRo_web]
    @vusername                                VARCHAR(4000) ,
    @compcode                                 VARCHAR(4000) ,
    @agency                                   VARCHAR(4000) ,
    @executive                                VARCHAR(4000) ,
    @client                                   VARCHAR(4000) ,
    @varfromdate                              DATETIME ,
    @vartodate                                DATETIME ,
    @DATEFORMAT                               VARCHAR(4000) ,
    @cioid                                    VARCHAR(4000) ,
    @flag                                     VARCHAR(4000) ,
    @pbranch                                  VARCHAR(4000) ,
    @pdate_based_on                           VARCHAR(4000) ,
    @porder                                   VARCHAR(4000) 
AS 
    DECLARE @LoopProcessingFlag BIT 
    BEGIN
        SET NOCOUNT ON
        
        DECLARE @relauthreq                               VARCHAR(1) 
        DECLARE @v_query                                  VARCHAR(8000) 
        DECLARE @v_query1                                  VARCHAR(8000) 
        DECLARE @v_distcount_allowed                      NUMERIC(12,2) 
        DECLARE @v_approval_with                          VARCHAR(1) 
        DECLARE @v_login_hr_code                          VARCHAR(50) 
        DECLARE @v_login_exec_team                        VARCHAR(50) 
        DECLARE @v_login_mailid                           VARCHAR(50) 
        
        SELECT
                 @relauthreq  =  relauthreqon,
                 @v_approval_with  =  approval_with
        FROM  preferrences 
        WHERE     comp_code  = @compcode
        
        
        SELECT
                 @v_distcount_allowed  =  CONVERT(NUMERIC(8, 2), ISNULL(discount, '0')),
                 @v_login_hr_code  =  hr_code,
                 @v_login_mailid  =  email
        FROM  login 
        WHERE     userid  = @vusername
         AND    CONVERT(NUMERIC(8, 2), ISNULL(discount, '0'))  > 0
        
        SET @v_query  = ' SELECT distinct m.Comp_code,a.Agency_Name as AGENCY,
(select City_Name from city_mst where City_Code=a.City_Code) as CITY_NAME,    
dbo.fetch_insert_package(''' + @compcode + ''',m.cio_booking_id,null,''N'') as PACKAGE,    
case when''' + @DATEFORMAT + '''=''dd/mm/yyyy'' then 
convert(varchar(20),m.date_time,103)    
when''' + @DATEFORMAT + '''=''yyyy/mm/dd'' then
 convert(varchar(20),m.date_time,111)    
else 
convert(varchar(20),m.date_time,101) 
end as BOOKDATE,     
isnull((select Cust_Name from cust_mast where Comp_Code=m.Comp_code and 
Cust_Code= m.Client_code),m.Client_code) as CLIENT,      m.RO_No as RO_NO,   
case when''' + @DATEFORMAT + '''=''dd/mm/yyyy'' then 
convert(varchar(20),m.RO_Date,103)  
when''' + @DATEFORMAT + '''=''yyyy/mm/dd'' then 
convert(varchar(20),m.RO_Date,111)   
else 
convert(varchar(20),m.RO_Date,101) end as RODATE,    
(select Exec_name from exec_mast 
where  convert(varchar(4000),Exe_no) = m.Executive_code) as EXECUTIVE,     
(select Retain_Name from retainermaster where Comp_Code=m.Comp_code
and Retain_Code= m.RETAINER) as RETAINER,     
m.Card_rate as CARD_RATE,dbo.Fn_Deviatio(m.Card_rate,m.Agrred_rate)
+isnull(m.Special_disc_per,0) as DEVIATION,m.cio_booking_id as CIO_BOOKING_ID,
m.Bill_amount as BILL_AMOUNT,m.Gross_amount as GROSS_AMOUNT,  
(select premiumname from advpos_prem_mast
where comp_code=m.Comp_code and Premiumcode=m.Page_prem)
as PAGEPERM,      m.app_status as APP_STATUS,m.booked_by as 
BOOKED_BY,      (select Payment_Mode_Name from payment_mode_mast 
where Comp_Code=m.Comp_code and Pay_Mode_Code=m.Agency_pay)
as PAYMODE,      m.Receipt_no as RECEIPT_NO,m.Ad_cat_code as 
AD_CAT_CODE,(select Adv_Cat_Name from adv_cat_mast where Comp_Code=m.Comp_code 
and Adv_Cat_Code=m.Ad_cat_code) as AD_CAT_NAME,      m.Color_code as COLOR_CODE,
(select Col_Name from col_mast where Comp_Code=m.Comp_code and Col_Code=m.Color_code) 
as COLOR_NAME,      m.Card_amount as CARD_AMOUNT,m.Agrred_rate as AGRRED_RATE,m.Agreed_amount 
as AGREED_AMOUNT,      m.Ad_size_height as AD_SIZE_HEIGHT,m.Ad_size_width as AD_SIZE_WIDTH,
 (isnull(m.Ad_size_height,0)* isnull(m.Ad_size_width,0)) as SIZE_BOOK,   
 convert(varchar(20),min(i.Insert_Date),101) as FIRST_INSDATE,convert(varchar(20),max(i.Insert_Date),101) as 
LAST_INSDATE,      m.ATTACHMENT1 as ATTACHMENT,m.Page_no as PAGE_NO,
(select distinct process_email from process_type_email where branch_code=m.branch and  
process_type=''RO APPROVED MAIL'') as APPROVED_MAILID,(select distinct process_email 
from process_type_email where branch_code=m.branch and       process_type=''RO REJECTED MAIL'')
as REJECTED_MAILID,''' + isnull(@v_login_mailid,'') + ''' as LOGIN_MAILID
from tbl_booking_mast m,tbl_booking_insert i,agency_mast a--,result r
 where m.Comp_code=''' + @compcode + ''' and m.Comp_code=i.Comp_Code 
and m.Comp_code=a.Comp_Code and      m.cio_booking_id=i.Cio_Booking_Id 
and m.Agency_sub_code=a.code_subcode      and ((dbo.Fn_Deviatio(m.Card_rate,m.Agrred_rate)
 is not null and dbo.Fn_Deviatio(m.Card_rate,m.Agrred_rate) !=''0'') 
 or isnull(m.Special_disc_per,0)>0 OR dbo.Fn_chkSalesExec(m.Userid)=''SE0'' OR''' +
  @relauthreq + ''' =''A'')      and isnull('''',m.Agency_sub_code) = isnull(''' + @agency + ''',m.Agency_sub_code)
   and (m.Executive_code =''' + @executive + '''  OR''' + @executive + ''' IS NULL or ''' +@executive+'''='''')     
    and (m.Client_code =''' + @client + '''  OR''' + @client + ''' IS NULL or '''+@client+'''='''')      
    ' 
    
    
        IF @cioid != '' 
        BEGIN 
            SELECT @v_query  = @v_query + 'and m.cio_booking_id = ''' + @cioid + '''' 
            SET @LoopProcessingFlag = 1
        END

 
        SET @LoopProcessingFlag = 0
        
        
        
        IF @flag = 'A' 
        BEGIN 
            SELECT @v_query  = @v_query + ' and m.app_status=''Y''' 
            SET @LoopProcessingFlag = 1
        END
        IF @flag = 'R'  AND (@LoopProcessingFlag = 0)
        BEGIN 
            SELECT @v_query  = @v_query + ' and m.app_status=''N''' 
            SET @LoopProcessingFlag = 1
        END
        IF (@LoopProcessingFlag = 0)
        BEGIN 
            SELECT @v_query  = @v_query + ' and isnull(m.app_status,''#'')!=''Y'' and isnull(m.app_status,''#'')!=''N''' 
        END
   
        IF @pdate_based_on = 'P' 
        BEGIN 
            SELECT @v_query  = @v_query + ' and i.Insert_Date between''' + convert(varchar(20),@varfromdate,101) + ''' and''' + convert(varchar(20),@vartodate ,101)+ '''' 
        END
        ELSE
        BEGIN 
            SELECT @v_query  = @v_query + ' and m.date_time between''' + convert(varchar(20),@varfromdate,101) + ''' and''' + convert(varchar(20),@vartodate,101) + '''' 
        END
   
        IF @pbranch = 'B' 
        BEGIN 
            SELECT @v_query  = @v_query + ' AND m.branch in(select ltrim(rtrim(branch_code)) from login_branch_mast where user_code=''' + @vusername + ''' and comp_code=''' + @compcode + ''' and user_flag=''Y'')' 
        END
   
        IF ISNULL(@v_approval_with, 'D')= 'T' 
        BEGIN 
            INSERT INTO  RESULT   
                    ( edition_name )  
            SELECT DISTINCT Team_code
            FROM  exec_mast 
            WHERE     comp_code  = @compcode
             AND    hr_code  = @v_login_hr_code
            
            SELECT @v_query  = @v_query + ' and (isnull(m.Discount_per,0)+isnull(m.Special_disc_per,0))>0              and r.edition_name =(select distinct Team_code from exec_mast where comp_code=m.Comp_code and to_char(Exe_no)=m.Executive_code)' 
        END
   
        SELECT @v_query  = @v_query + ' group by m.Comp_code,a.Agency_Name,m.Package_code,m.date_time, m.Client_code,m.RO_No,m.RO_Date,m.Executive_code,m.RETAINER,                      m.Card_rate,m.cio_booking_id,m.Bill_amount,m.Gross_amount,m.Page_prem,m.app_status,m.booked_by,m.Agency_pay,                      m.Receipt_no,m.Ad_cat_code,m.Ad_cat_code,m.Color_code,m.Card_amount,m.Agrred_rate,m.Agreed_amount,                      m.Ad_size_height,m.Ad_size_width,m.retainer,m.Executive_code,a.City_Code,m.ATTACHMENT1,m.Page_no,isnull(m.Special_disc_per,0),m.branch' 
        SET @LoopProcessingFlag = 0
        IF @porder = '1' 
        BEGIN 
            SELECT @v_query  = @v_query + ' ORDER BY DEVIATION ASC,bookdate DESC,m.cio_booking_id' 
            SET @LoopProcessingFlag = 1
        END
        IF @porder = '2'  AND (@LoopProcessingFlag = 0)
        BEGIN 
            SELECT @v_query  = @v_query + ' ORDER BY DEVIATION DESC,bookdate DESC,m.cio_booking_id' 
            SET @LoopProcessingFlag = 1
        END
        IF (@LoopProcessingFlag = 0)
        BEGIN 
            SELECT @v_query = @v_query + ' ORDER BY bookdate DESC,m.cio_booking_id' 
        END
   
        DELETE FROM   test1    
        
        --INSERT INTO  test1   
        --        ( vstring , 
        --        vstring2 )  
        -- VALUES         ( 'getapprovalRo_web ' , 
        --        @v_query )  
        
        
      print(@v_query )
    --   print(@v_query1 )
       
        EXEC(@v_query)
        DELETE FROM   RESULT    
        
    

        SET NOCOUNT OFF

    END


///////////////end ///////shipra////////////////////////////////by bhanu sir



////////////start //////shipra//////////////////by amit dhama sir////////////



CREATE
 PROCEDURE exeaddstatusbind
@execode 
VARCHAR(4000) ,
@userid 
VARCHAR(4000) ,
@compcode 
VARCHAR(4000) ,
@commid 
VARCHAR(4000) 
AS

BEGIN
SET NOCOUNT ON



SELECT *
FROM EXECUTIVE_ADCOMM_TARGET 
WHERE comp_code = @compcode
AND EXECUTIVE_CODE = @execode
AND comm_target_id = @commid

SET NOCOUNT OFF
END
===================================================================

CREATE
 PROCEDURE ad_execu_add_comm_target_ins
@pcomp_code 
VARCHAR(4000) ,
@pexecu_code 
VARCHAR(4000) ,
@ppubl_code 
VARCHAR(4000) ,
@pno_of_publ 
VARCHAR(4000) ,
@padcomm_per 
FLOAT ,
@pcomm_type 
VARCHAR(4000) ,
@pcreated_by 
VARCHAR(4000) ,
@pcreated_dt 
DATETIME ,
@pupdated_by 
VARCHAR(4000) ,
@pupdated_dt 
DATETIME ,
@pcomm_target_id 
FLOAT ,
@padd_comm_id 
FLOAT ,
@pdml_type 
VARCHAR(4000) 
AS

BEGIN
SET NOCOUNT ON

IF ISNULL(@pdml_type, '?')= 'I'
BEGIN
INSERT INTO executive_adcomm_target 
(
comp_code 
,
EXECUTIVE_CODE 
,
publ_code 
,
no_of_publ 
,
adcomm_per 
,
comm_type 
,
created_by 
,
created_dt 
,
updated_by 
,
updated_dt 
,
comm_target_id 
)
VALUES (
@pcomp_code 
,
@pexecu_code 
,
@ppubl_code 
,
@pno_of_publ 
,
@padcomm_per 
,
@pcomm_type 
,
GETDATE() ,
@pcreated_dt 
,
@pupdated_by 
,
@pupdated_dt 
,
@pcomm_target_id 
)


END

IF ISNULL(@pdml_type, '?')= 'U'
BEGIN
UPDATE executive_adcomm_target 
SET publ_code = @ppubl_code,
no_of_publ 
= @pno_of_publ,
adcomm_per 
= @padcomm_per,
comm_type 
= @pcomm_type,
updated_by 
= @pupdated_by,
updated_dt 
= GETDATE()
WHERE comp_code = @pcomp_code
AND EXECUTIVE_CODE = @pexecu_code
AND add_comm_id = @padd_comm_id 



END

IF ISNULL(@pdml_type, '?')= 'D'
BEGIN
DELETE FROM executive_adcomm_target 
WHERE comp_code = @pcomp_code
AND EXECUTIVE_CODE = @pexecu_code
AND add_comm_id = @padd_comm_id 


END

SET NOCOUNT OFF
END


/******************************************************************************/

CREATE
 PROCEDURE exeaddselectslab
@execode 
VARCHAR(4000) ,
@userid 
VARCHAR(4000) ,
@compcode 
VARCHAR(4000) ,
@code11 
VARCHAR(4000)
AS

BEGIN
SET NOCOUNT ON


SELECT
publ_code
,
no_of_publ
,
adcomm_per
,
comm_type
,
comm_target_id
,
add_comm_id

FROM executive_adcomm_target 
WHERE comp_code = @compcode
AND EXECUTIVE_CODE = @execode
AND add_comm_id = @code11

SET NOCOUNT OFF
END

/*****************************************************************************/


alter
 PROCEDURE ad_execut_comm_target_bind
@execode 
VARCHAR(4000) ,
@userid 
VARCHAR(4000) ,
@compcode 
VARCHAR(4000)
AS

BEGIN
SET NOCOUNT ON



SELECT *
FROM executive_comm_target 
WHERE comp_code = @compcode
AND EXECU_CODE = @execode

SET NOCOUNT OFF
END


CREATE
 PROCEDURE exeselectstructslab
@compcode 
VARCHAR(4000) ,
@userid 
VARCHAR(4000) ,
@execode 
VARCHAR(4000) ,
@code11 
FLOAT 
AS

BEGIN
SET NOCOUNT ON



SELECT
team_code
,
adctg_code
,
from_tgt
,
to_tgt
,
cust_type
,
ad_type
,
pub_type
,
publ_code
,
comm_target_id

FROM executive_comm_target 
WHERE comp_code = @compcode
AND EXECU_CODE = @execode
AND comm_target_id = @code11

SET NOCOUNT OFF
END


/************************************************************************************************/

CREATE
 PROCEDURE ad_execu_comm_target_ins
@pcomp_code 
VARCHAR(4000) ,
@pexe_code 
VARCHAR(4000) ,
@pteam_code 
VARCHAR(4000) ,
@padctg_code 
VARCHAR(4000) ,
@pfrom_tgt 
FLOAT ,
@pto_tgt 
FLOAT ,
@pcust_type 
VARCHAR(4000) ,
@pad_type 
VARCHAR(4000) ,
@ppub_type 
VARCHAR(4000) ,
@ppubl_code 
VARCHAR(4000) ,
@pcreated_by 
VARCHAR(4000) ,
@pcreated_dt 
DATETIME ,
@pupdated_by 
VARCHAR(4000) ,
@pupdated_dt 
DATETIME ,
@pcomm_target_id 
FLOAT ,
@pdml_type 
VARCHAR(4000) 
AS

BEGIN
SET NOCOUNT ON

IF ISNULL(@pdml_type, '?')= 'I'
BEGIN
INSERT INTO executive_comm_target 
( comp_code ,
EXECU_CODE 
,
team_code 
,
adctg_code 
,
from_tgt 
,
to_tgt 
,
cust_type 
,
ad_type 
,
pub_type 
,
publ_code 
,
created_by 
,
created_dt 
,
updated_by 
,
updated_dt 
,
comm_target_id 
)
VALUES ( @pcomp_code ,
@pexe_code 
,
@pteam_code 
, 
@padctg_code 
,
@pfrom_tgt 
,
@pto_tgt 
,
@pcust_type 
,
@pad_type 
,
@ppub_type 
,
@ppubl_code 
,
@pcreated_by 
,
@pcreated_dt 
,
@pupdated_by 
,
@pupdated_dt 
,
@pcomm_target_id 
)


-- IMPLICIT_TRANSACTIONS is set to OFF
END

IF ISNULL(@pdml_type, '?')= 'U'
BEGIN
UPDATE executive_comm_target 
SET team_code = @pteam_code,
adctg_code 
= @padctg_code,
from_tgt 
= @pfrom_tgt,
to_tgt 
= @pto_tgt,
cust_type 
= @pcust_type,
ad_type 
= @pad_type,
pub_type 
= @ppub_type,
publ_code 
= @ppubl_code,
created_by 
= @pcreated_by,
created_dt 
= @pcreated_dt,
updated_by 
= @pupdated_by,
updated_dt 
= @pupdated_dt 
WHERE comp_code = @pcomp_code
AND EXECU_CODE = @pexe_code
AND comm_target_id = @pcomm_target_id 


-- IMPLICIT_TRANSACTIONS is set to OFF
END

IF ISNULL(@pdml_type, '?')= 'D'
BEGIN
DELETE FROM executive_comm_target 
WHERE comp_code = @pcomp_code
AND EXECU_CODE = @pexe_code
AND comm_target_id = @pcomm_target_id 


-- IMPLICIT_TRANSACTIONS is set to OFF
END

SET NOCOUNT OFF
END
/**********************************************************/

CREATE
 PROCEDURE insertexestatus_slab
@compcode 
VARCHAR(4000) ,
@userid 
VARCHAR(4000) ,
@execode 
VARCHAR(4000) ,
--enln in NUMBER,

@fromdays 
FLOAT ,
@todays 
FLOAT ,
@drpcommon 
VARCHAR(4000) ,
@p_comm_target_id 
VARCHAR(4000) ,
@commrate 
FLOAT 
AS

BEGIN
SET NOCOUNT ON

INSERT INTO EXECUTIVE_COMM_SLAB 
( comp_code ,
enln 
,
from_days 
,
till_days 
,
comm_on 
,
comm_rate 
,
created_by 
,
updated_by 
,
updated_date 
,
comm_target_id 
)
VALUES ( @compcode ,
@execode 
,
@fromdays 
,
@todays 
,
@drpcommon 
,
@commrate 
,
@userid 
,
'' ,
'' ,
@p_comm_target_id 
)


-- IMPLICIT_TRANSACTIONS is set to OFF
SET NOCOUNT OFF
END

/**************************************************************************/

CREATE
 PROCEDURE exegencodeforcommstruct
@p_compcode 
VARCHAR(4000) ,
@p_userid 
VARCHAR(4000) 
AS

BEGIN
SET NOCOUNT ON

DECLARE @num FLOAT
SELECT @num = ISNULL(MAX(comm_target_id), 0) + 1
FROM executive_comm_target 



SELECT ISNULL(@num, 0) AS "IDNO"

SET NOCOUNT OFF
END



/////////////////end //////////////////shipra////////////by dhama sir/////////





//////////////////start////////////shipra//////////////by dhama sir//////////




=================tables sql--------------------------------


CREATE
 TABLE EXECUTIVE_ADCOMM_TARGET 
(
COMP_CODE 
VARCHAR (8) NOT NULL ,
EXECUTIVE_CODE 
VARCHAR (8) NOT NULL ,
COMM_TARGET_ID 
NUMERIC (10) NOT NULL ,
PUBL_CODE 
VARCHAR (200) ,
NO_OF_PUBL 
NUMERIC (3) ,
ADCOMM_PER 
NUMERIC (12, 2) ,
COMM_TYPE 
VARCHAR (1) DEFAULT 'P' ,
CREATED_BY 
VARCHAR (30) ,
CREATED_DT 
DATETIME DEFAULT GETDATE() ,
UPDATED_BY 
VARCHAR (30) ,
UPDATED_DT 
DATETIME ,
ADD_COMM_ID 
NUMERIC NOT NULL
)

===================================================
 

CREATE
 TABLE EXECUTIVE_COMM_TARGET 
(
COMP_CODE 
VARCHAR (8) NOT NULL ,
EXECU_CODE 
VARCHAR (8) NOT NULL ,
TEAM_CODE 
VARCHAR (8) ,
ADCTG_CODE 
VARCHAR (8) ,
FROM_TGT 
NUMERIC (5, 2) ,
TO_TGT 
NUMERIC (5, 2) ,
CUST_TYPE 
VARCHAR (10) ,
AD_TYPE 
VARCHAR (8) ,
PUB_TYPE 
VARCHAR (8) ,
PUBL_CODE 
VARCHAR (200) ,
CREATED_BY 
VARCHAR (30) ,
CREATED_DT 
DATETIME DEFAULT GETDATE() ,
UPDATED_BY 
VARCHAR (30) ,
UPDATED_DT 
DATETIME ,
COMM_TARGET_ID 
NUMERIC (10) NOT NULL
)

============================================
CREATE
 TABLE EXECUTIVE_COMM_SLAB 
(
COMP_CODE 
VARCHAR (8) ,
EXE_CODE 
VARCHAR (8) ,
ENLN 
NUMERIC ,
FROM_DAYS 
NUMERIC (10) ,
TILL_DAYS 
NUMERIC (10) ,
COMM_ON 
VARCHAR (8) ,
COMM_RATE 
NUMERIC (10, 2) ,
CREATED_BY 
VARCHAR (8) ,
CREATED_DATE 
DATETIME DEFAULT GETDATE() ,
UPDATED_BY 
VARCHAR (8) ,
UPDATED_DATE 
DATETIME ,
COMM_TARGET_ID 
NUMERIC (10)
)
=============================================


////////////////end by ///shipra////////////////////by dhama sir/////////



///////////////////////////start////////////////shipra/////////////////by dhama sir



USE
 [CIO4CPLUS]
GO

/****** Object: StoredProcedure [dbo].[report_avilable_dates] Script Date: 07/17/2012 14:19:12 ******/

SET
 ANSI_NULLS ON
GO

SET
 QUOTED_IDENTIFIER ON
GO










ALTER
 PROCEDURE [dbo].[report_avilable_dates]
@compcode 
as varchar(8),
@fromdate 
as varchar(20) =null,
@todate 
as varchar(20) =null,
@pub 
as varchar(50)=null,
@edition 
as varchar(50)=null,
@page 
as varchar(50)=null,
@position 
as varchar(50)=null,
@dateformat 
as varchar(20)=null,
@pubcenter 
as varchar(50)=null,
@puserid 
as varchar(8)=null,
@chk_access 
as varchar(2)=null,
@page_no 
as varchar(50)=null,
@ad_type 
as varchar(50)=null,
@ad_cat 
as varchar(50)
AS

declare
 @vfrdt as datetime
declare
 @todt as datetime
declare
 @vquery as varchar(4000)
declare
 @vvar as Varchar(4000)
declare
 @a as int
DECLARE
 @v_edtn1 AS VARCHAR(20)
DECLARE
 @v_edtn_area1 AS INT



declare c1 cursor for
select distinct tbl_booking_insert.Edition as "edition",round(edition_mast.Edition_Area,2) as "edtn_area"
from tbl_booking_insert,edition_mast 
where 
((
tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1)
or (@chk_access=0) )
and tbl_booking_insert.Edition_Code=edition_mast.Edition_Code and
tbl_booking_insert
.Comp_Code=@compcode and
(tbl_booking_insert.Publication_Code=@pub or @pub is null) and
(tbl_booking_insert.Edition_Code=@edition or @edition is null) and
(tbl_booking_insert.premium1=@page or @page is null) and
(tbl_booking_insert.Page_Post =@position or @position is null) and
(tbl_booking_insert.Pub_Cent_Code=@pubcenter or @pubcenter is null) and 
(tbl_booking_insert.Page_No=@page_no or @page_no is null) and 
(
 (@ad_type is null) or (TBL_BOOKING_insert."Ad_Cat" in (select "Adv_Cat_Code" from adv_cat_mast where "Adv_Type"=@ad_type) ) ) and 
(TBL_BOOKING_insert."Ad_Cat"=@ad_cat or @ad_cat is null) and
tbl_booking_insert
.Insert_Date between @fromdate and @todate

declare
 @v_edtn varchar(100)
declare
 @v_edtn_area varchar(100)
begin



OPEN c1 
DECLARE @count INT
SELECT @count = 1 
fetch NEXT FROM c1 INTO @v_edtn,@v_edtn_area
print
(@v_edtn)
print
(@v_edtn_area)
WHILE (@@FETCH_STATUS != -1)
BEGIN
if (@vvar is null OR @vvar='') BEGIN

--set @vvar='ISNULL(round(sum(case Edition when '''+@v_edtn+''' then Size_Book end ),2),0) "'+@v_edtn+'",ISNULL(''+@v_edtn_area+'',0) "'+@v_edtn+'_AREA"'
set @vvar='ISNULL(round(sum(case Edition when '''+@v_edtn+''' then Size_Book end ),2),0) "'+@v_edtn+'",ISNULL(cast('''+@v_edtn_area+''' as float) -round(sum(case Edition when '''+@v_edtn+''' then Size_Book end),2),cast('''+@v_edtn_area+''' as float)) "'+@v_edtn+'_AREA"'
END
else
BEGIN
set @vvar=@vvar+',ISNULL(round(sum(case Edition when '''+@v_edtn+''' then Size_Book end ),2),''0'') "'+@v_edtn+'",ISNULL(cast('''+@v_edtn_area+''' as float)-round(sum(case Edition when '''+@v_edtn+''' then Size_Book end),2),cast('''+@v_edtn_area+''' as float)) "'+@v_edtn+'_AREA"'
end
SELECT @count=@count +1
fetch NEXT FROM c1 INTO @v_edtn,@v_edtn_area
END
close c1 
print
(@vvar)
IF (@vvar is not null)
begin
set @vquery='select 
CASE '''
+@dateformat+''' 
WHEN ''mm/dd/yyyy'' THEN convert(varchar,Insert_Date,101) 

WHEN ''dd/mm/yyyy'' THEN convert(varchar,Insert_Date,103) 

WHEN ''yyyy/mm/dd'' THEN convert(varchar,Insert_Date,111) END AS "Date",'
+@vvar+'
from tbl_booking_insert

where ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''
+@puserid+''') and '''+@chk_access+'''=''1'')
or ('''
+@chk_access+'''=''0'') )
and tbl_booking_insert.Comp_Code='''
+@compcode+''' and
Insert_Date between '''
+@fromdate+''' and '''+@todate+''''
--Insert_Date between ''02/24/2010'' and ''07/28/2010'''

if
(@pub is not null and @pub<>'')begin
set
 @vquery=@vquery+' and tbl_booking_insert.Publication_Code='''+@pub+''''
end

if
(@page is not null and @page<>'')begin
set
 @vquery=@vquery+' and tbl_booking_insert.premium1='''+@page+''''
end

if
(@edition is not null and @edition<>'')begin
set
 @vquery=@vquery+' and tbl_booking_insert.Edition_Code='''+@edition+''''
end

if
(@position is not null and @position<>'')begin
set
 @vquery=@vquery+' and tbl_booking_insert.Page_Post='''+@position+''''
end



if
(@page_no is not null and @page_no<>'')begin
set
 @vquery=@vquery+' and tbl_booking_insert.Page_No='''+@page_no+''''
end


if
(@ad_type is not null and @ad_type<>'')begin
set
 @vquery=@vquery+' and tbl_booking_insert.Adv_Type='''+@ad_type+''''
end

if
(@ad_cat is not null and @ad_cat<>'')begin
set
 @vquery=@vquery+' and tbl_booking_insert.Ad_Cat='''+@ad_cat+''''
end

if
(@pubcenter is not null and @pubcenter<>'')begin
set
 @vquery=@vquery+' and tbl_booking_insert.Pub_Cent_Code='''+@pubcenter+''''
end


set
 @vquery=@vquery+' group by Insert_Date order by Insert_Date'

end

else

begin

set @vquery='select ''gaurav'''
end
 
print 
(@vquery)
exec 
(@vquery)
deallocate
 c1
SELECT
 dbo.InitCap(Comp_Name) AS "companyname" ,getdate() as "Rundate"from comp_mst where Comp_Code=@compcode
end


////////////////end ////shipra //by dhama sir///////////////////////




////////////////////start/////shipra/////////////////dhama sir//////////////////



ALTER
 Procedure [dbo].[Bg_SAVE]

@bgid 
varchar(8),
@bgname 
varchar(30),
@bgalias 
varchar(30),
@pub 
varchar(8),
@edit 
varchar(8),
@cat 
varchar(8),
@cat2 
varchar(8),
@cat3 
varchar(8),
@cat4 
varchar(8),
@cat5 
varchar(8),
@coltyp 
varchar(15),
@comcode 
varchar(8),
@bgtype 
as varchar(8),
@bgamt 
as int
as

begin

declare
 @query as varchar(1000)

insert
 into Tbl_BgColor(bgid,bgname,bgalias,Publication,Edition,Category,Category2,Category3,Category4,Category5,Colortype,comp_code,BG_TYPE, BG_AMT)
values(@bgid,@bgname,@bgalias,@pub,@edit,@cat,@cat2,@cat3,@cat4,@cat5,@coltyp,@comcode,@bgtype,@bgamt)
end




///////////////end ////////shipra/////////////////////dhama sir//////










////////////start by shipra/////////////8096/////////////

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[Ad_Gen_Code_fmg]    Script Date: 07/26/2012 18:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Ad_Gen_Code_fmg] 
    @pcompcode                             VARCHAR(20),
    @descp                              VARCHAR(20) 
	
AS 

		
		DECLARE @vno                                      NUMERIC(5) 
		DECLARE @v_code                               VARCHAR(15)

 
        SELECT @vno  =  MAX(SUBSTRING(REASON_CODE,2,3)) + 1
		FROM  AD_FMG_REASON_MAST 
		WHERE	 comp_code  = @pcompcode
		

	
		IF ISNULL(@vno, 0)= 0 
		BEGIN 
			SELECT @v_code  = 'A' + '001' 
		END
		ELSE
		BEGIN 
			
       select @v_code='A'+dbo.fnPadLeft('0',3,@vno);
		END
   
		select @v_code as VAR_CODE



	
 



//////////////////////end by shipra//////////////8096



/////////////////////////////////////////////*****************Sumit Roy(Rate Master)*******************////////////////


ALTER  PROCEDURE [dbo].[binndratecode]
   
   @p_compcode    as       VARCHAR(10),
   @p_ratecode   as       VARCHAR(50)
   
as


      SELECT distinct "RATE_DESC"
        FROM rate_code_mast
       WHERE "COMP_CODE" = @p_compcode
       AND "STATUS" = 'AC0'
         AND "RATE_CODE" LIKE @p_ratecode + '%'
         
         select * from tv_promo_booking





**************************************************************************************************

ALTER PROCEDURE [dbo].[AD_RATECODE_CHECK]

@comp_code      varchar(2000),
@ratecode      varchar(2000),
@extra1        varchar(2000),
@extra2        varchar(2000)
AS
DECLARE	@return_value int

BEGIN
SET NOCOUNT ON


 SET @return_value = (SELECT COUNT(*) FROM RATE_MAST WHERE COMP_CODE=@comp_code AND RATE_MAST_CODE=@ratecode)
 
 IF @return_value>0
 BEGIN
 SELECT 'Return_Value' = 'N'
 END
 ELSE
 BEGIN
 SELECT 'Return_Value' = 'Y'
 END
 
 --SELECT	'Return Value' = @return_value
 
        SET NOCOUNT OFF
END



*******************************************************************************




ALTER PROCEDURE [dbo].[autoratecode]

@str as varchar(30),
@cod as varchar(2)

as

declare @query as  varchar(1000)

declare @query1 as  varchar(1000)
set @query='select * from RATE_CODE_MAST where RATE_DESC= '''+@str+'''   '






set @query1='select MAX(cast(dbo.translate(RATE_CODE,''ABCDEFGHIJKLMNOPQRSTUVWXYZ@#$%^&*()!>~<?/_+|=-'',0) as int )) as RATE_CODE from RATE_CODE_MAST where  RATE_CODE like '''+@cod+'%'''


--print(@query)

print(@query)
exec(@query)

--print(@query)

print(@query1)
exec(@query1)



****************************************************************************************




ALTER PROCEDURE [dbo].[bindstatus_for_ratemast]

@pcompcode as varchar(8)



AS
begin

	select Status_code,Status_name from tblstatus where comp_code=@pcompcode  order by Status_code
end





/////////////////////////////***************************END**************************************/////////////////////// 


=================start===avinash================7876========30-07-2012====

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER procedure [dbo].[rpt_vts_report]
@pagency_code as varchar(50),
@pclient_code as varchar(50),
@pfrom_date as varchar(20),
@pto_date as varchar(20),
@pdateformat as varchar(20),
@ppublication as varchar(50),
@pedition as varchar(50),
@ppub_center as varchar(50),
@pbranch as varchar(50),
@pcompcode as varchar(20),
@puserid as varchar(20),
@chk_access as varchar(20),
@clienttype as varchar(8),
@pextra1 as varchar(50),
@pextra2 as varchar(50)
as 
declare @query1 varchar(8000)

begin
set @query1='select distinct a."Comp_code", a."cio_booking_id" as "CIOID",a."date_time" as bkdate, 
c.Agency_Name AS "AGENCY",c."Add1",c."Add2",c."Add3",(select "City_Name" from city_mst where "City_Code"=c."City_Code") city_name,c."Dist_Code",c."State_Code",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE a.comp_code=CUST_MAST.comp_code AND Cust_Code=Client_code),Client_code)  AS "CLIENT", 
isnull((SELECT "Add1" FROM  CUST_MAST WHERE a."Comp_code"= CUST_MAST."Comp_Code" AND "Cust_Code"=a."Client_code"),a."Client_address")  AS "CLIENT_ADDR", 
b.Edition as "EDITION",
CASE '''+@pdateformat+'''
 WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),Insert_Date,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),Insert_Date,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),Insert_Date,111)  END AS "PUB_DATE" ,
a."NO_OF_INSERTION",
isnull(a.Agrred_rate,a.Card_rate ) AS "RATE",
(select Comp_Name from comp_mst where comp_mst.Comp_Code=a.Comp_code) comp_name,
(select "Package_Name" from combin_mast where "Combin_Code"=b.package_code) package_name
from tbl_booking_mast a,tbl_booking_insert b,agency_mast c
   WHERE a.Comp_code='''+@pcompcode+''' 
     AND a.Agency_sub_code=c.code_subcode 
     AND a.cio_booking_id=b.Cio_Booking_Id 
     and exists (select cioid from tbl_booking_vts 
                  where compcode=a.comp_code
                    and cioid=a.cio_booking_id)
     and ((b.Pub_Cent_Code in (select distinct pub_center from login_center 
                                  where newuser_id='''+@puserid+''') 
                                   and '''+@chk_access+'''=''1'') or  ('''+@chk_access+'''=''0'') )'

IF(@pfrom_date IS NOT NULL AND @pto_date IS NOT NULL)
begin
set @query1=@query1+' and b.Insert_Date between  '''+@pfrom_date +''' and  '''+@pto_date+''' '
END

IF(@pagency_code IS NOT NULL )
begin
set @query1=@query1+' and a.Agency_code =  '''+@pagency_code+''' '
END

IF(@pclient_code IS NOT NULL )
begin
set @query1=@query1+' and a.Client_code='''+@pclient_code +''''
END

IF(@ppublication IS NOT NULL )
begin
set @query1=@query1+' and  b.Publication_Code='''+@ppublication+''''
END

IF(@ppub_center IS NOT NULL )
begin
set @query1=@query1+'  and b.Pub_Cent_Code='''+@ppub_center+''''
END

IF(@pedition IS NOT NULL )
begin
set @query1=@query1+'  and b.Edition_Code='''+@pedition+''''
END

IF(@pbranch IS NOT NULL )
begin
set @query1=@query1+'  and a.branch='''+@pbranch+''''
END

if (@clienttype is not null or @clienttype<>'')
  Begin
    if @clienttype = 'R'
      Begin
         set @query1=@query1+'  and client_code in (select cust_code from cust_mast where comp_code = '''+@pcompcode+''''+'and cust_status=''ACTIVE'')'
      End
    else if @clienttype = 'N'
      Begin
         set @query1=@query1+'  and client_code not in (select cust_code from cust_mast where comp_code = '''+@pcompcode+''''+'and cust_status=''ACTIVE'')'
      End
    else
      Begin
         set @query1=@query1
      End   
   End

print(@query1)
exec(@query1)

end


=================end===avinash================7876========30-07-2012====


