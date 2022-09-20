/***********mimoh 16042012****************************7196********************************/

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
@p_editionwisebilling as varchar(2)

AS
declare @query as varchar(2000)
declare @query1 as varchar(2000)

update Agency_mast set Rate_Group=@rategrp, Agency_Code=@agentcode , fax1=@txtfax2,CREDIT_TYPE=@curtype, zone_code=@zone,  type=@type, Agency_Type_Code=@agencytype,Agency_Cat_Code=@agentcategory,Agency_SubCat_Code=@agentcategory2,Agency_Name=@agentname,Agency_Alias=@alias,Agency_HO=@agencyho,Add1=@address,Street=@street,City_Code=@city,Zip=@zip,Dist_Code=@district,State_Code=@state,Country_Code=@country,Phone=@phone,Fax=@fax,EmailID=@mail,URL=@url,Buss_Start_Date=@bussinessstartdate,Enroll_Date=@enrolldate ,MRV_Ref_No=@mrerefferenceno,No_of_VTS=@novts,Credit_Days=@credit,PAN_No=@pan,TAN_No=@tan,ST_ACC_No=@stacno1,Pay_Mode_Code=@paymode,Status_Reason=@status,Remarks=@remarks,SUB_Agency_HO=@subagencyho,SUB_Agency_Code=@agencycode ,BILL_TO =@acagen, acagency=@billto,ALERT=@alert,credit_limit=@creditlimit,code=@code ,region=@region,representative_code=@representative,pin_code=@pincode,Add2=@address1,Add3=@address2,qbc_userid=@qbcuserid , TALUKA=@taluka , Branch_code=@branchcode, DISTRICT=@hddistcode,STATE=@hdstatecode,BILL_FREQUENCY=@billf,OLD_AGENCY=@oldagen,BOOKING_TYPE=@booktype,VAT=@vat,RATE_REVISE=@p_raterevise,EDTN_WISE_BILL_REQ =@p_editionwisebilling 
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
/*************************************************************************************/
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
@p_editionwisebilling as varchar(2)
--@bank as varchar(30),
--@validitydate as DATETIME




AS

--insert into Agency_mast(Comp_Code,Agency_Type_Code,Agency_Cat_Code,Agency_SubCat_Code,Agency_Code,Agency_Name,Agency_Alias,Agency_HO,Add1,Street,City_Code,Zip,Dist_Code,State_Code,Country_Code,Phone,Fax,EmailID,URL,Buss_Start_Date,Enroll_Date,MRV_Ref_No,No_of_VTS,Credit_Days ,PAN_No,TAN_No,ST_ACC_No,Pay_Mode_Code,Agency_Status,Status_Reason,Remarks,UserID,Creation_Datetime,SUB_Agency_HO,SUB_Agency_Code,BILL_TO,ALERT,CREDIT_LIMIT,CODE,representative_code,pin_code) values (@compcode,@agencytype,@agentcategory,@agentcategory2,@agentcode,@agentname,@alias,@agencyho,@address,@street,@city,@zip,@district,@state,@country,@phone,@mail,@fax,@url,@bussinessstartdate,@enrolldate,@mrerefferenceno,@novts,@credit,@pan,@tan,@stacno,@paymode,@statusdrp,@status,@remarks,@userid,@statusdate,@subagencyho,@agencycode,@billto,@alert ,@creditlimit,@code,@representative,@pin)
insert into Agency_mast(Comp_Code,Agency_Type_Code,Agency_Cat_Code,Agency_SubCat_Code,Agency_Code,Agency_Name,Agency_Alias,Agency_HO,Add1,     Street,City_Code,Dist_Code,State_Code,Country_Code,Phone,Fax,EmailID,URL,Buss_Start_Date,     Enroll_Date,MRV_Ref_No,      No_of_VTS,Credit_Days ,PAN_No,TAN_No,ST_ACC_No,Pay_Mode_Code,Status_Reason,Remarks, UserID, SUB_Agency_HO,SUB_Agency_Code,acagency,ALERT, CREDIT_LIMIT, CODE, representative_code,pin_code,region, type, code_subcode,          zone_code,Add2,     Add3,     CREDIT_TYPE,BILL_TO,fax1,    Rate_Group, qbc_userid,TALUKA,   zip,Branch_code,DISTRICT,    STATE,      BILL_FREQUENCY,OLD_AGENCY,BOOKING_TYPE,VAT,RATE_REVISE,EDTN_WISE_BILL_REQ) values 
						(@compcode,@agencytype,    @agentcategory, @agentcategory2,   @agentcode, @agentname, @alias,      @agencyho,@address,@street,@city,    @district,@state,    @country,    @phone,@fax,@mail,@url,@bussinessstartdate,@enrolldate,@mrerefferenceno,@novts,   @credit,     @pan,  @tan,  @stacno,  @paymode,     @status,      @remarks,@userid,@subagencyho, @agencycode,    @acagen, @alert ,@creditlimit,@code,@representative,    @pin,    @region,@type,@agentcode+@agencycode,@zone,    @address1,@address2,@curtype,   @billto,@txtfax1,@rategrp,   @qbcuserid, @taluka,@zip,@branchcode,@hddistcode,@hdstatecode,@billf,        @oldagency,@booktype,   @vat,@p_raterevise,@p_editionwisebilling)
						
/* TO INSERT DATA IN AGENCY HISTORY LOG*/

 INSERT INTO AGENCY_REMARK_DETAIL(COMP_CODE, AGENCY_CODE, SUB_AGENCY_CODE, CODE_SUBCODE, AGENCY_ALERT, AGENCY_REMARK, USERID)
        VALUES(@compcode,@agentcode,@agencycode,@agentcode + @agencycode,@alert,@remarks,@userid);

/**********************************************************************************/


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
declare @query as varchar(2000)

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
                (select status_name from tblstatus where comp_code='''+@compcode+''' and status_code=(SELECT top 1 status_name FROM STATUS_DETAIL WHERE comp_code='''+@compcode+''' and  STATUS_DETAIL.agency_code+STATUS_DETAIL.agency_subcat_code = AGENCY_MAST.code_subcode)) AS status_name,
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
                (select AGENCY_CODE from ad_user where ad_user.AGENCY_CODE=agency_mast.code_subcode) AS AGENCYCODE,TALUKA ,Branch_code,(select dist_mst.Dist_Name from dist_mst where dist_mst.Dist_Code=agency_mast.DISTRICT) as DISTRICT,(select state_mst.State_Name from state_mst where state_mst.State_Code=agency_mast.STATE) as STATE,BILL_FREQUENCY,OLD_AGENCY,BOOKING_TYPE,VAT,RATE_REVISE,EDTN_WISE_BILL_REQ FROM AGENCY_MAST  where comp_code='''+@compcode+''' '

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

















/***********mimoh 16042012****************************7196********************************/


/***********ankit ****************************add category********************************/


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[advinsert]    Script Date: 04/16/2012 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE  [dbo].[advinsert]

@compcode as varchar(8),
@userid as varchar(8),
@adcatcode as varchar(8),
@catalias as varchar(50),
@catname as varchar(50),
@adtype as varchar(8),
@rclient as varchar(30),
@filename as varchar(50),
@status1   as varchar(5),
@productivity as varchar(8),
@hrs as varchar(8),
@min as varchar(8)

 AS

begin

insert into Adv_Cat_Mast (Comp_Code, userid, adv_cat_code,adv_cat_name,adv_cat_alias,/*edition_code,*/creation_datetime,Adv_Type,REGCLIENT,CAT_FILE_NAME,STATUS,Preodicity_Code,RO_hr,RO_min) values (@compcode, @userid, @adcatcode,  @catname, @catalias,/*@catediname,*/getdate(),@adtype,@rclient,@filename,@status1,@productivity,@hrs,@min);

end





=============================================================================================





USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[advupdate]    Script Date: 04/16/2012 11:13:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[advupdate]
@compcode as varchar(8),
--@userid as varchar(8),
@adcatcode as varchar(8),
@catalias as varchar(50),
@catname as varchar(50),
@adtype as varchar(8),
@rclient as varchar(10),
@filename as varchar(50),
@status1   as varchar(5),
@productivity as varchar(8),
@hrs as varchar(8),
@min as varchar(8)

 AS


begin
update Adv_Cat_Mast set REGCLIENT=@rclient, adv_cat_name=@catname,adv_cat_alias=@catalias,/*edition_code=@catediname,*/creation_datetime=getdate(),Adv_Type=@adtype,CAT_FILE_NAME=@filename,STATUS=@status1,Preodicity_Code=@productivity,RO_hr=@hrs,RO_min=@min where comp_code=@compcode /*and userid=@userid */and adv_cat_code =@adcatcode

--update advdummy set adv_cat_name=@catname,adv_cat_alias=@catalias,/*edition_code=@catediname,*/creation_datetime=getdate() where comp_code=@compcode and /*userid=@userid and*/ adv_cat_code =@adcatcode

end


--update Client_cont_details set Cont_Person=@contactperson,DOB=@dob,phone=@phone,Extension=@ext,Fax=@fax,EmailId=@mail where  userid=@userid and CUST_CODE=@custcode and COMP_CODE=@compcode  and cont_code=@update












=======================================================================================================





USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[advcatexec]    Script Date: 04/16/2012 11:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



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
	STATUS  VARCHAR(5),
	Preodicity_Code   VARCHAR(8),
	RO_hr   VARCHAR(8),
	RO_min   VARCHAR(8)
)

set @query=' insert  into #ADV_CAT_MAST select Comp_Code, adv_cat_code, Adv_Cat_Name,Adv_Cat_Alias,/*Edition_Code,*/userid, getdate(),Adv_Type,REGCLIENT,CAT_FILE_NAME,STATUS,Preodicity_Code,RO_hr,RO_min  from adv_cat_mast where  Comp_Code='''+@compcode+'''  '--and  userid='''+@userid+''''


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





/***********ankit ****************************add category********************************/




/***********ankit *******************7143*********creat user********************************/



USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[loginInsert]    Script Date: 04/12/2012 15:12:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







ALTER PROCEDURE [dbo].[loginInsert]
@username as varchar(50),
@password as varchar(20),
@userid as varchar(10),
@date_format as varchar(50),
@comp_name as varchar(50),
@com_code as varchar(10),
@curr_code as varchar(8),
@retainer_code as varchar(8),
@agencycode as varchar(50),
@user as  varchar(50),
@admin as varchar(50),
@comp_user as varchar(20),
@compnamelist as varchar(25),
@emailid  as varchar(50),
@discount as varchar(20),
@filter as varchar(50),
@rolename as varchar(20),
@editlines as varchar(50),
@firstname  as VARCHAR(20),
@lastname   as VARCHAR(20),
@pstatus    AS VARCHAR(20),
@p_empcode as varchar(50),
@p_acccode as varchar(50)
AS

insert into login(username,   password,   userid,   date_format,    comp_name,com_code, curr_code, retainer_code, Agency_code,user_status,Admin,Company_user,USER_COMPANY,EMAIL ,DISCOUNT,FILTER,ROLEID,BOOKING_EDITLINES,FIRSTNAME,LASTNAME,STATUS,HR_CODE,ACC_CODE)
values(@username,@password,@userid,@date_format,@comp_name,@com_code,@curr_code,@retainer_code,@agencycode,@user,@admin,@comp_user ,@compnamelist,@emailid,@discount,@filter,@rolename,@editlines,@firstname,@lastname,@pstatus,@p_empcode,@p_acccode)


 DELETE FROM MODULE_DETAIBUTTONL WHERE MODULE_DETAIBUTTONL.userid=@userid

 INSERT INTO MODULE_DETAIBUTTONL SELECT BUTTONID, FORM_NAME,COMPCODE,@userid,'',FORM_ID,'','','','','0',''  FROM ROLE_PERMISSION WHERE ROLEID=@rolename










---------------------------------------------------------------------------------------------






USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[loginModify]    Script Date: 04/12/2012 15:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE  [dbo].[loginModify]

@username as varchar(50),
@password as varchar(20),
@userid as varchar(10),
@date_format as varchar(50),
@comp_name as varchar(50),
@com_code as varchar(10),
@curr_code as varchar(8),
@retainer_code as varchar(8),
@agencycode as varchar(50),
@user as varchar(50),
@admin as varchar(50),
@comp_user as varchar(20),
@companylist as varchar(25),
@emailid as varchar(50),
@disc as varchar(20),
@fil as varchar(8),
@role as varchar(8),
@editlines as varchar(1),
@firstname  as VARCHAR(20),
@lastname   as VARCHAR(20),
@pstatus    AS VARCHAR(20),
@p_empcode as varchar(50),
@p_acccode as varchar(50)


AS

update login set FIRSTNAME=@firstname,LASTNAME =@lastname,username=@username, password=@password, date_format=@date_format, comp_name=@comp_name, com_code=@com_code, curr_code=@curr_code, 
retainer_code=@retainer_code,Agency_code=@agencycode,user_status=@user,Admin=@admin,Company_user=@comp_user ,
 BOOKING_EDITLINES=@editlines, ROLEID=@role,FILTER=@fil, DISCOUNT=@disc, USER_COMPANY=@companylist,EMAIL=@emailid,STATUS=@pstatus,HR_CODE=@p_empcode,ACC_CODE=@p_acccode where userid=@userid

DELETE FROM MODULE_DETAIBUTTONL WHERE MODULE_DETAIBUTTONL.userid=@userid

INSERT INTO MODULE_DETAIBUTTONL
           ([Button_id]
           ,[Form_Name]
           ,[comp_code]
           ,[userid]
           ,[Module_No]
           ,[Form_id]
           ,[Paid_permission]
           ,[Backdate_booking]
           ,[Ro_date_perm]
           ,[Confirm_qbc])
            SELECT BUTTONID, FORM_NAME,COMPCODE,@userid,'',FORM_ID,'','','',''  FROM ROLE_PERMISSION WHERE ROLEID=@role;




====================================================================================================================================




USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[loginexecute]    Script Date: 04/12/2012 15:26:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





ALTER PROCEDURE [dbo].[loginexecute]

@username as varchar(50),
@userid as varchar(10),
@com_code as varchar(10),
@admin as varchar(8)

AS

declare @query  as   varchar(1000)



	if(@admin='')
		set @query='select [username]
      ,[password]
      ,[userid]
      ,[date_format]
      ,[COM_CODE]
      ,[comp_name]
      ,[Autogenerate]
      ,[curr_code]
      ,[retainer_code]
      ,[Agency_code]
      ,[User_status]
      ,[Admin]
      ,[Company_user]
      ,[USER_COMPANY]
      ,[EMAIL]
      ,[CREATION_DATETIME]
      ,[DISCOUNT]
      ,[FILTER]
      ,[ROLEID]
      ,[BOOKING_EDITLINES]
      ,[FIRSTNAME]
      ,[LASTNAME]
      ,[ROLE]
      ,[STATUS]
      ,[DOMAIN_USER]
      ,(select NAME+''(''+EMP_CODE+'')'' from HR_EMP_MST where COMP_CD='''+@com_code+''' AND EMP_CODE=login.HR_CODE)AS HR_CODE,(select Agency_Name from agency_mast where  agency_mast.code_subcode=LOGIN.Agency_code)as AGENCY_NAME,(select ACC_NAME from fa_acc_mast where CDP=LOGIN.ACC_CODE) as ACC_NAME,ACC_CODE from login where   admin!=''yes'''  --username='''+@username+''''
	else
		set @query='select [username]
      ,[password]
      ,[userid]
      ,[date_format]
      ,[COM_CODE]
      ,[comp_name]
      ,[Autogenerate]
      ,[curr_code]
      ,[retainer_code]
      ,[Agency_code]
      ,[User_status]
      ,[Admin]
      ,[Company_user]
      ,[USER_COMPANY]
      ,[EMAIL]
      ,[CREATION_DATETIME]
      ,[DISCOUNT]
      ,[FILTER]
      ,[ROLEID]
      ,[BOOKING_EDITLINES]
      ,[FIRSTNAME]
      ,[LASTNAME]
      ,[ROLE]
      ,[STATUS]
      ,[DOMAIN_USER]
      ,(select NAME+''(''+EMP_CODE+'')'' from HR_EMP_MST where COMP_CD='''+@com_code+''' AND EMP_CODE=login.HR_CODE)AS HR_CODE,(select Agency_Name from agency_mast where  agency_mast.code_subcode=LOGIN.Agency_code)as AGENCY_NAME,(select ACC_NAME from fa_acc_mast where CDP=LOGIN.ACC_CODE) as ACC_NAME,ACC_CODE from login where admin=''yes'''

if(@com_code<>''  and @com_code <>'0')
begin
	set @query= @query + ' and com_code= '''+@com_code+''''
end

if(@username<>'')
begin
	set @query= @query + ' and username like ''%'+@username+'%'''
end

if(@userid<>'')
begin
	set @query= @query + ' and userid = '''+@userid+''''
end



print(@query)
exec(@query)


==========================ankit============7143==========end===================================================================

**************************start**************sapna**************date 17-4-2012*************


alter table EDITION_MASTTEMP add  Gutter_Space varchar(8),Column_Space varchar(8),RO_hr varchar(8),RO_min varchar(8),Production varchar(8),Edition_Type varchar(20),No_Of_Collumn varchar(5),SAP_BOOKING_UNIT varchar(20),PRINT_CENT varchar(20),SEGMENT_CODE varchar(10)


*********************************************end*********************************

****************************************start******sapna********date 17-4-2012**********

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[websp_editorSelect]    Script Date: 04/17/2012 15:46:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE  [dbo].[websp_editorSelect]

@PubName as varchar(8),
@CityName as varchar(8),
@EditonCode as varchar(8),
@EditionName as varchar(50),
@Alias as varchar(50),
@userid as varchar(8),
@compcode as varchar(8),
@country as varchar(8),
@circulation as varchar(8),
@uom as varchar(8),
@column as varchar(8),
@height as varchar(8),
@width as varchar(8),
@area as varchar(15),
@periodicity as varchar(8),
@gutter as varchar(8),
@col_space as varchar(8),
@type as varchar(20),
@psegmentcod as varchar(50)


AS
declare @query as varchar (1000)

CREATE TABLE #EDITION_MASTTEMP (
	Comp_Code varchar (8) ,
	Pub_Code varchar (8) ,
	City_Code varchar (8) ,
	Edition_Code varchar (8) ,
	Edition_Name varchar (50) ,
	Edition_Alias varchar (1000) ,
	UserId varchar (8) ,
	Creation_Datetime datetime NOT NULL ,
	Country_Code varchar (8)  NULL ,
	No_Of_Circulation varchar (8),
	UOM_Code varchar(500),
	No_Of_Columns varchar(8),
	Size_Height varchar(8),
	Size_Width varchar(8),
	Edition_Area varchar(15),
	Preodicity_Code varchar(8),
	Gutter_Space varchar(8),
	Column_Space varchar(8),
	RO_hr varchar(8),
	RO_min varchar(8),
	Production varchar(8),
	Edition_Type varchar(20),
	No_Of_Collumn varchar(5),
    SAP_BOOKING_UNIT varchar(20),
    PRINT_CENT varchar(50),
    SEGMENT_CODE varchar(10)
) 

set @query='insert #EDITION_MASTTEMP select * from  EDITION_MAST where  Comp_Code='''+@compcode+''' '--and UserId='''+@userid+''''



if(@PubName <> '0' and @PubName <> '')
begin
set @query  =  @query + 'and Pub_Code  like ''%'+@PubName +'%'''
end


if(@CityName  <> '0' and @CityName  <> '')
begin
set @query  =  @query + 'and City_Code  like ''%'+@CityName +'%'''
end


if(@EditonCode <>'')
begin
print(@EditonCode)
set @query  =  @query + 'and Edition_Code  like ''%'+@EditonCode +'%'''
end

if(@EditionName <>'')
begin
set @query  =  @query + 'and Edition_Name  like ''%'+@EditionName +'%'''
end

if(@Alias <>'')
begin
set @query  =  @query + 'and Edition_Alias  like ''%'+@Alias +'%'''
end


if(@country <>'0' and @country <> '')
begin
set @query=@query+ 'and Country_Code like''%'+@country+'%'''
end

if(@circulation <> '')
begin
set @query  =  @query + 'and No_Of_Circulation  like ''%'+@circulation +'%'''
end

if(@uom <>'0' and @uom <> '')
begin
set @query  =  @query + 'and UOM_Code  like ''%'+@uom +'%'''
end

if(@column <>'')
begin
set @query  =  @query + 'and No_Of_Columns  like ''%'+@column +'%'''
end
if(@height <>'')
begin
set @query  =  @query + 'and Size_Height  like ''%'+@height +'%'''
end
if(@width <>'')
begin
set @query  =  @query + 'and Size_Width  like ''%'+@width +'%'''
end
if(@area <>'')
begin
set @query  =  @query + 'and Edition_Area  like ''%'+@area +'%'''
end

if(@type <>'0' and @type <> '')
begin
set @query=@query+ 'and Edition_Type = '''+@type+''''
end

if(@psegmentcod <>'0' and @psegmentcod <> '')
begin
set @query=@query+ 'and segment_code = '''+@psegmentcod+''''
end

print('adc')
print(@EditionName)
print('mnb')
print(@query)
exec(@query)

select * from #EDITION_MASTTEMP  --where  Comp_Code=@compcode and  UserId=@userid
drop table #EDITION_MASTTEMP




*********************************************end**********************************


=============7217===start========avinash==========19apr2012==========================

alter function fetch_insert_package(
    @pcompcode       varchar(500),
    @pcioid          varchar(500),
    @pinsertion_no   int,
    @ppkg_type       varchar(50)) returns varchar(2000)
as
Begin
If @pinsertion_no='' Begin
	set @pinsertion_no=null
End	
If @ppkg_type='' Begin
	set @ppkg_type=null
End
 

declare @v_val   varchar(2000)
declare @v_pack  varchar(200)
declare @v1_pack varchar(200)

declare c1 cursor for
    select distinct package_code pack from tbl_booking_insert 
        where "Comp_Code"=@pcompcode and "Cio_Booking_Id"=@pcioid and "No_Insert" =isnull(@pinsertion_no,"No_Insert") and "Insert_Status"!='cancel';

open C1;
	fetch NEXT FROM c1 INTO @v1_pack
	WHILE (@@FETCH_STATUS = 0) Begin
    
		if isnull(@ppkg_type,'N')='N' begin--for Package name
			select @v_pack="Package_Name" from combin_mast where "Combin_Code"=@v1_pack
		End    
		else Begin--for Package code
			set @v_pack=@v1_pack
		end
	    
		if (@v_val is null) begin
			set @v_val=@v_pack
		End  
		else Begin
			set @v_val=@v_val +','+ @v_pack
		end
	fetch NEXT FROM c1 INTO @v1_pack  
	end
close C1
deallocate c1

return @v_val

END
=========================================================

ALTER PROCEDURE Reportnew
@agname			as VARCHAR(500)=NULL,
@clientname		as VARCHAR(500)=NULL,
@adtype1		as VARCHAR(50),
@Adcategory		as VARCHAR(500),
@fromdate		as VARCHAR(20),
@dateto			as VARCHAR(20),
@compcode		as VARCHAR(10),
@pub_name		as VARCHAR(200),
@pub_cent		as VARCHAR(200),
@status			as VARCHAR(50)=NULL,
@edition		as VARCHAR(100),
@dateformat		as VARCHAR(20),
@hold			as VARCHAR(20)=NULL,
@descid			as VARCHAR(20)=NULL,
@ascdesc		as VARCHAR(20)=NULL,
@agtype			as varchar(20)=null,
@puserid		as varchar(10)=null,
@chk_access		as varchar(2),
@pextra1		as varchar(200)=null,--for UOM
@pextra2		as varchar(200)=null,
@pextra3		as varchar(200)=null,
@pextra4		as varchar(200)=null,
@pextra5		as varchar(200)=null
AS

declare @center  VARCHAR(50)
declare @from_date DATETIME
declare @date_to DATETIME
declare @query VARCHAR(8000)
BEGIN
create table #Results(SegmentNum INT, Edition_Name  VARCHAR(255))

insert into #Results select * from dbo.Fn_Splitfield(@Adcategory,',')

set	@query='SELECT TBL_BOOKING_MAST.cio_booking_id AS CIOID,TBL_BOOKING_INSERT.Edition as edition,
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),Insert_Date,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),Insert_Date,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),Insert_Date,111)  END AS "Ins.date" ,
AGENCY_MAST.Agency_Name AS Agency,
(SELECT  AGENCY_MAST.SUB_Agency_Code FROM AGENCY_MAST WHERE  AGENCY_MAST.Type <> ''P'' AND TBL_BOOKING_MAST.Agency_code=AGENCY_MAST.Agency_Code  AND TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode and tbl_booking_mast.comp_code=AGENCY_MAST.comp_code) AS SubAg,
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code and CUST_MAST.comp_code=tbl_booking_mast.comp_code),Client_code)  AS Client,
(select COMBIN_MAST.Package_Name from combin_mast where COMBIN_MAST.comp_code=tbl_booking_mast.comp_code and COMBIN_MAST.Combin_Code  in(TBL_BOOKING_MAST.Package_code))AS Package,
TBL_BOOKING_INSERT.Col_Code AS Color_code,
round(TBL_BOOKING_insert.Size_Book,2) AS Area,
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast.Uom_code=uom_mast.Uom_Code and tbl_booking_mast.comp_code=uom_mast.comp_code)as uom,
tbl_booking_insert.Height AS Depth,
tbl_booking_insert.Width  AS Width,
(SELECT ADVPOS_TYPE_MAST.Pos_Type_Alias FROM ADVPOS_TYPE_MAST WHERE TBL_BOOKING_INSERT.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code  and tbl_booking_insert.comp_code=ADVPOS_TYPE_MAST.comp_code) AS Page,
TBL_BOOKING_MAST.Bullet_code AS BulletPremium ,
tbl_booking_insert.Page_Post AS PositionPremium ,
TBL_BOOKING_INSERT.Premium1 AS PagePremium ,
RO_No AS "RoNo.",
CASE ro_status
WHEN ''2'' THEN ''Reservation''
WHEN ''1'' THEN ''Confirm'' END AS RoStatus,
(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=tbl_booking_insert.Ad_Cat and ADV_CAT_MAST.comp_code=tbl_booking_insert.comp_code) AS AdCat,
Rate_code AS RateCode,
TBL_BOOKING_mast.Card_rate AS CardRate,
isnull(Agrred_rate,0) AS AgreedRate,
TBL_BOOKING_insert.Bill_Amt  AS Amt,
TBL_BOOKING_MAST.Caption AS Cap,
Key_no AS "Key",
TBL_BOOKING_MAST.Trade_disc AS Disc,
TBL_BOOKING_INSERT.Insert_Status AS Status,
TBL_BOOKING_INSERT.Status_Material AS MatStatus,
(SELECT dbo.InitCap(Comp_Name) from comp_mst where Comp_Code='''+@compcode+''') AS companyname,
getdate() as Rundate
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST 
 WHERE
 TBL_BOOKING_MAST.Comp_code='''+@compcode+'''
 AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
 AND TBL_BOOKING_MAST.Agency_code=AGENCY_MAST.Agency_Code
 AND TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode
 AND TBL_BOOKING_MAST.cio_booking_id not in(select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)
/* and  lower(Insert_Status) !=''cancel'' */
and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )'

IF(@agname IS NOT NULL and @agname <> '')
begin
	set @query=@query+' and TBL_BOOKING_MAST.Agency_code ='''+@agname+''''
END

IF(@clientname IS NOT NULL and @clientname <> '')
begin
	set @query=@query+' and TBL_BOOKING_MAST.Client_code='''+@clientname +''''
END

/*IF(@status IS NOT NULL and @status<>'')
begin
set @query=@query+' and TBL_BOOKING_INSERT.Insert_Status='''+@status+''''
END*/

IF(@status IS NOT NULL and @status<>'')
begin
	set @query=@query+' and TBL_BOOKING_INSERT.Insert_Status='''+@status+''''
end
/*else
begin
set @query=@query+' and lower(Insert_Status) !=''cancel'' '
END*/ 

IF(@adtype1 IS NOT NULL and @adtype1 <>'')
begin
	set @query=@query+' and TBL_BOOKING_MAST.Ad_type_code='''+@adtype1+''''
END

IF(@Adcategory IS NOT NULL and @Adcategory<>'')
begin
	--set @query=@query+' and TBL_BOOKING_MAST.Ad_cat_code in('''+@Adcategory+''' )'
	set @query=@query+' and tbl_booking_insert.Ad_Cat in(select EDITION_NAME from #Results)'
END

IF(@pub_cent IS NOT NULL and @pub_cent<>'')
begin
	set @query=@query+'  and tbl_booking_insert.Pub_Cent_Code='''+@pub_cent+''''
END

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL )
begin
	set @query=@query+' and Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
END

IF( @fromdate<>'' and @dateto<>'')
begin
	set @query=@query+' and Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
END

IF(@edition IS NOT NULL and @edition<>'')
begin
	set @query=@query+'  and tbl_booking_insert.Edition_Code='''+@edition+''''
END

IF(@pub_name IS NOT NULL and @pub_name<>'')
begin
	set @query=@query+' and  TBL_BOOKING_INSERT.Publication_Code='''+@pub_name+''''
END

IF(@pextra1 IS NOT NULL) Begin
    set @query = @query+'  and TBL_BOOKING_MAST."Uom_code"='''+@pextra1+''''
END

IF((@agtype IS NOT NULL and @agtype<>'') AND (@agtype <> 'Package') AND (@agtype <> 'Solo'))
begin
	set @query=@query+' and  TBL_BOOKING_mast.Agency_type='''+upper(@agtype)+''''
END

IF(@descid IS NOT  NULL and @descid<>'')
begin
	set @query=@query+'  order by "'+@descid+'"'
	set @query=@query+''+@ascdesc+''
end
ELSE
begin
	set @query=@query+'  order by Insert_Date,TBL_BOOKING_MAST.cio_booking_id'
END

print(@query)
exec(@query)
END



**************************************

ALTER PROCEDURE deviationreport(
@page			varchar(50)=null,
@position		varchar(50)=null,
@agname			varchar(50)=null,
@clientname		varchar(50)=null,
@adtype			varchar(50)=null,
@adcategory		varchar(50)=null,
@fromdate		varchar(50),
@dateto			varchar(50),
@compcode		varchar(10),
@pub_name		varchar(50),
@pub_cent		varchar(50),
@status			varchar(50)=null,
@edition		varchar(50),
@dateformat		varchar(50),
@hold			varchar(10)=null,
@descid			varchar(50)=null,
@ascdesc		varchar(50)=null,
@agtype			varchar(50)=null,
@puserid		varchar(10),
@chk_access		varchar(2),
@puomcode		varchar(20)=null,
@pextra1		varchar(200)=null,
@pextra2		varchar(200)=null,
@pextra3		varchar(200)=null,
@pextra4		varchar(200)=null,
@pextra5		varchar(200)=null)
as 
declare @str  as varchar(8000)
declare @center  as varchar(50)
declare @can as varchar(8)
set @can='Cancel'

create table #Results(SegmentNum INT, Edition_Name  VARCHAR(255))

insert into #Results select * from dbo.Fn_Splitfield(@Adcategory,',')

set @str='SELECT distinct m."cio_booking_id" AS "CIOID",/*i."Edition"*/ 
null as "edition",
CASE '''+@dateformat+'''
when ''mm/dd/yyyy'' then convert(varchar(10),min(i."Insert_Date"),101) 
when ''dd/mm/yyyy'' then convert(varchar(10),min(i."Insert_Date"),103) 
when ''yyyy/mm/dd'' then convert(varchar(10),min(i."Insert_Date"),111) end AS "Ins.date" ,
min(i."Insert_Date") as "Insert_Date",
a."Agency_Name" AS "Agency",(select "City_Name" from city_mst where city_mst."City_Code"=a."City_Code") as "AGENCY_CITY",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
dbo.fetch_insert_package('''+@compcode+''',m."cio_booking_id",null,''N'') as "Package",
--m."Total_area" AS "Area",
max(round(i."Size_Book",2)) AS "Area",
max(i."Col_Code") AS "Hue",
CASE '''+@dateformat+'''
when ''mm/dd/yyyy'' then convert(varchar(10),m.creation_datetime,101) 
when ''dd/mm/yyyy'' then convert(varchar(10),m.creation_datetime,103) 
when ''yyyy/mm/dd'' then convert(varchar(10),m.creation_datetime,111)   END AS "BookDate",
m."RO_No" AS "RoNo",
CASE m."ro_status"
WHEN ''2'' THEN ''Reservation''
WHEN ''1'' THEN ''Confirm''END AS "RoStatus",
(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=m."Ad_cat_code" ) AS "AdCat",
m."Rate_code" AS "RateCode",
m."Card_rate" AS "CardRate",
m."Agrred_rate" AS "AgreedRate",
dbo.Fn_Deviatio(m.Card_rate,m.Agrred_rate) AS "Deviation(%)",
m.APP_STATUS AS "Status",
m."booked_by",m."audit" "audit",u.UOM_DESC as "uom",
(SELECT dbo.initcap("Comp_Name") from comp_mst where "Comp_Code"='''+@compcode+''') AS "companyname",
sysdate as "Rundate"
from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,uom_mast u
 where m."Comp_code"='''+@Compcode+''' AND
 m."cio_booking_id"=i."Cio_Booking_Id"  AND
 m."Agency_code"=a."Agency_Code" AND
 m."Agency_sub_code"=a."code_subcode" and m."Uom_code"=u."Uom_Code"
and (m."Card_rate" != m."Agrred_rate" and m."Agrred_rate" <>0)
and (nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0))>0
AND not exists (select ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
and  lower(i."Insert_Status") !=''cancel''
and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )'


if(@agname <>'' and @agname is not null)
begin

set @str=@str+' and m.agency_code ='''+@agname +''''
end

if(@clientname <>'' and @clientname is not null)
begin
set @str=@str+' and m.client_code ='''+@clientname +''''
end
if(@status <>'' and @status is not null)
begin
set @str=@str+' and i.insert_status  ='''+@status+''''
end


if(@adtype<>'' and @adtype is not null)
begin
--print(@adtype)
set @str=@str + ' and m. ad_type_code ='''+@adtype+''' '
End

if(@adcategory <> '' and @adcategory is not null)
begin
set @str=@str +  ' and i.Ad_Cat in(select EDITION_NAME from #Results  )'
End


if(@pub_cent<>'' and @pub_cent is not null)
begin
set @str=@str+'  and i.pub_cent_code ='''+  @pub_cent+''''
end

 if(@fromdate is not null and @dateto is not null )
begin
	set @str=@str+' and i.Insert_Date between  '''+@fromdate +''' and  '''+@dateto +''' '
end

else if(@fromdate<>'' and @dateto<>'' )
begin
	set @str=@str+' and i.Insert_Date between  '''+@fromdate +''' and  '''+@dateto +''' '
end
if(@edition <> '' and @edition is not null)
begin
set @str=@str+'  and i.edition_code='''+ @edition +''''
End

if(@pub_name <> '' and @pub_name is not null)
begin
set @str=@str+' and  i.publication_code='''+ @pub_name +''''
End
if(@page <> '' and @page is not null)
begin
set @str=@str+' and  i.premium1='''+ @page +''''
End
if(@position <> '' and @position is not null)
begin
set @str=@str+' and  i.page_post='''+ @position +''''
End

IF((@agtype IS NOT NULL) and (@agtype<>'') AND (@agtype <> 'Package') AND (@agtype <> 'Solo'))
BEGIN
set @str=@str+'and  m.Agency_type='''+upper(@agtype)+''''
END 

if(@puomcode is not null or @puomcode <>'')
begin
    set @str=@str+'  and m."Uom_code" ='''+@puomcode+''''
end

set @str=@str+' group by m."cio_booking_id",a."Agency_Name",a."City_Code",
m."Client_code",m."date_time",m."RO_No",m."ro_status",m."Ad_cat_code",m."Rate_code",m."Card_rate",m."Agrred_rate",m.APP_STATUS,m."booked_by",m."audit",u.UOM_DESC '


if(@descid <>  '' and @descid is not null)
begin
set @str=@str+'  order by '''+@descid + ''''
set @str=@str+ ''+@ascdesc+''	
end 
ELSE
BEGIN
set @str=@str+'  order by Insert_Date,m.cio_booking_id'
END

print(@str)
exec(@str)

==============end==============7127========avinash======19apr2012=====================

------------------------------------------Start-----------updated on---19/04/2012--------------------------
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[Websp_Orderlastnew_b]    Script Date: 04/19/2012 14:26:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






ALTER PROCEDURE  [dbo].[Websp_Orderlastnew_b]
(

@bookingid as VARCHAR(500),
@dateformat as VARCHAR(50),
@fromdate as VARCHAR(50),
@dateto as VARCHAR(50),
@v_invoice as VARCHAR(500),
@v_compcode as VARCHAR(50)

)

 AS

declare @query as varchar(8000)
declare @query1 as varchar(8000)
declare @str as varchar(8000)
declare @var_date_min as varchar(8000)
declare @package_cd  as varchar(300)
declare @package_result  as varchar(300)
declare @package_cd1  as varchar(300)
create table #package ( package_name varchar (100) )
set @var_date_min=@fromdate


set @query='SELECT TBL_BOOKING_MAST .RO_No,
 TBL_BOOKING_INSERT .Cio_Booking_Id,
TBL_BOOKING_INSERT.No_Insert ,
TBL_BOOKING_INSERT.Edition,
Height,
Width,
Size_Book,
COL_MAST.Col_Name,
 TBL_BOOKING_INSERT.Page_No,
 TBL_BOOKING_INSERT.No_Ofcolumn,

 TBL_BOOKING_insert.Gross_Rate,
 CASE '''+@dateformat+'''
  WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),Insert_Date,1)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),Insert_Date,3)

WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),Insert_Date,3)  END AS "Ins.date",
tbl_booking_insert.Agreed_Rate,
tbl_booking_mast.Agency_address,
 AGENCY_MAST.Agency_Name,
 CASE '''+@dateformat+'''
   WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),RO_Date,1)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),RO_Date,3)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),RO_Date,3) END AS RO_Date,
pub_mast.Pub_Name as Publication,
(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where ADV_CAT_MAST.Adv_Cat_Code=TBL_BOOKING_MAST.Ad_cat_code)

as AdCat,

isnull((SELECT Cust_Alias FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client
,tbl_booking_mast.Client_address
, city_mst.City_Name,
tbl_booking_insert.No_Insert,
(SELECT BOX_MAST.Box_Charges_Native FROM BOX_MAST,TBL_BOOKING_MAST  WHERE

TBL_BOOKING_MAST.Box_code=BOX_MAST.Box_Code AND TBL_BOOKING_MAST.cio_booking_id='''+@bookingid+''') as

boxcode,
TBL_BOOKING_MAST.Trade_disc,
Invoices,

(select  PUB_CENT_MAST.Add1 FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS Add1,
1 as Phone1,
2 as Phone2,
PUB_CENT_MAST .Fax1 as Fax1,
uom_mast.Uom_Alias ,
TBL_BOOKING_MAST.Key_no AS "Key No",
3 as Email,

/*CASE '''+@dateformat+'''
   WHEN ''mm/dd/yyyy'' THEN
 (select to_char((SELECT SYSDATE + (SELECT DISTINCT AGENCY_MAST.Credit_Days FROM AGENCY_MAST WHERE


AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code AND TBL_BOOKING_MAST.cio_booking_id =

'''+@bookingid+''')  FROM  dual),''mm/dd/yyyy'') from dual)
    WHEN ''dd/mm/yyyy'' THEN
 (select to_char((SELECT SYSDATE + (SELECT DISTINCT AGENCY_MAST.Credit_Days FROM AGENCY_MAST WHERE

AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code AND TBL_BOOKING_MAST.cio_booking_id =

'''+@bookingid+''')  FROM  dual),''dd/mm/yyyy'') from dual)

  WHEN ''yyyy/mm/dd'' THEN
 (select to_char((SELECT SYSDATE + (SELECT DISTINCT AGENCY_MAST.Credit_Days FROM AGENCY_MAST WHERE

AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code AND TBL_BOOKING_MAST.cio_booking_id =

'''+@bookingid+''')  FROM  dual),''yyyy/mm/dd'') from dual) end as*/
1 as
 paydatesys,

tbl_booking_insert.Card_Rate,
adv_type_mast.Adv_Type_Name,
tbl_booking_mast.No_of_insertion,
tbl_booking_mast.Gross_amount,
tbl_booking_mast.Caption,



comp_mst .Comp_Name as companyname,

comp_mst.PAN_No as pan,
PUB_CENT_MAST.Pub_Cent_name as pubname,

comp_mst.Add1 as address,
comp_mst.Street as street,
comp_mst.Fax as fax,
(select distinct Bullet_Charges  from BULlet_mast,tbl_booking_mast where tbl_booking_mast

.Bullet_code=BULlet_mast.Bullet_Code  AND   TBL_BOOKING_mast.cio_booking_id='''+@bookingid+''' ) AS

expremiumch,
TBL_BOOKING_MAST  .ADD_AGENCY_COMM as adtd,


tbl_booking_mast.Trade_disc  as td,

  tbl_booking_mast.branch,
    col_mast.Col_Alias as  Color_code,


   CASE '''+@dateformat+'''
   WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),getdate(),1)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),getdate(),3)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),getdate(),3) END AS SYSDATE1,


(select PUB_CENT_MAST .EmailID FROM PUB_CENT_MAST WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS EmailID,


CASE '''+@dateformat+'''
 when ''mm/dd/yyyy''  then(select convert(varchar(20),max(Insert_Date),1) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''')
 when ''dd/mm/yyyy'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id='''+@bookingid+''')

 when ''yyyy/mm/dd'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''') end as maxdate,


 (select advpos_type_mast.Amount from  advpos_type_mast where

advpos_type_mast.Pos_Type_Code=tbl_booking_mast.Page_position_code)as expr,

 tbl_booking_mast.Card_rate*Total_area as amtnew,

50 as  "PACKAGERATE",

/* ((SELECT SUM(Card_Rate-ROUND((Card_Rate*(isnull(TBL_BOOKING_MAST.Special_disc_per,0)+isnull(TBL_BOOKING_MAST.Space_disc_per,0))/100),2)) FROM TBL_BOOKING_INSERT  WHERE INSERTS=''1'' AND TBL_BOOKING_INSERT
.Cio_Booking_Id='''+@bookingid+''' and
Insert_Date between  '''+@var_date_min+''' and '''+@dateto+''' )) AS PACKAGERATE,*/

TBL_BOOKING_MAST.Agrred_rate,




(select  PUB_CENT_MAST.street FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS street_new,





CASE '''+@dateformat+'''
 when ''mm/dd/yyyy''  then(select convert(varchar(20),max(Insert_Date),1) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''' AND Insert_Date between  '''+@fromdate+''' and
'''+@dateto+''')
 when ''dd/mm/yyyy'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id='''+@bookingid+''' AND Insert_Date between  '''+@fromdate+''' and
'''+@dateto+''')

 when ''yyyy/mm/dd'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''' AND Insert_Date between  '''+@fromdate+''' and
'''+@dateto+''') end as maxdate1,

TBL_BOOKING_INSERT.Bill_Amt,';


set @query1='(select  PUB_CENT_MAST.Fax FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS Fax2,

(select  PUB_CENT_MAST.Fax1 FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS Fax3,
(select  PUB_CENT_MAST."FILE_PATH" FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST."Pub_cent_Code" IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS FILE_PATH,
tbl_booking_mast."Special_charges" as "Special_charges",


pub_cent_mast.Fax1 as fax1,
pub_cent_mast.phone1 as phone,
pub_cent_mast.phone1 as phone0,
COL_MAST.Col_Code,
tbl_booking_mast."Bill_to" as "bill2",
dbo.getadd('''+@v_compcode+''','''+@bookingid+''') as "agenadd",
tbl_booking_mast.bill_remarks as "Remark"



FROM TBL_BOOKING_MAST  ,
TBL_BOOKING_INSERT,
COL_MAST,
AGENCY_MAST,
PUB_MAST,
CITY_MST,
PUB_CENT_MAST,
uom_mast,
adv_type_mast,
comp_mst
WHERE  TBL_BOOKING_INSERT.Col_Code=COL_MAST.Col_Code AND  CITY_MST.City_Code=AGENCY_MAST.City_Code  AND
AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code AND TBL_BOOKING_INSERT.Publication_Code=

PUB_MAST.Pub_Code
and uom_mast.Uom_Code=tbl_booking_mast.Uom_code
and TBL_BOOKING_MAST .Comp_code=comp_mst.Comp_Code
and tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code 
 AND adv_type_mast.COMP_CODE=TBL_BOOKING_MAST.COMP_CODE
and PUB_CENT_MAST.Pub_cent_Code  =TBL_BOOKING_INSERT.Pub_Cent_Code
AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
AND TBL_BOOKING_INSERT  .Cio_Booking_Id='''+@bookingid+''' and


Insert_Date between  '''+@var_date_min+''' and
'''+@dateto+'''
and (bill_no='''+@v_invoice+''' or  '''+@v_invoice+'''= '''')

and Insert_Status!=''cancel''
order by tbl_booking_insert. No_Insert'

print(@query)
print(@query1)
exec(@query+@query1)

select  @package_cd1=package_code from tbl_booking_mast where cio_booking_id=@bookingid



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
exec(@str)

select * from #package
delete from #package


update ad_bills set PRINT_COUNT=isnull(PRINT_COUNT,0)+1 where COMP_CODE_V=@v_compcode and BILNO=@v_invoice;







-------------------------------------------------End----------------------19/04/2012------------------------------





/**********************************mimoh 20april2012**********************************************7274*/


ALTER procedure [dbo].[discchk](
@compcode as varchar(8),
@disccode as varchar(8),
@discdes as varchar(50),
@padtype as varchar(50)
)
as
begin
select DISC_CODE, DISC_DESC, AD_TYPE, DISC_TYPE from DISC_MASTER where COMP_CODE=@compcode and DISC_CODE=@disccode

select DISC_CODE, DISC_DESC, AD_TYPE, DISC_TYPE from DISC_MASTER where COMP_CODE=@compcode and DISC_DESC=@discdes and AD_TYPE=@padtype

end

/**********************************mimoh 20april2012**********************************************7274*/



@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@PUBLICATION CENTER-26-04-2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

/////////////PUBLICATION CENTER-26-04-2012-///INSERT

ALTER PROCEDURE [dbo].[pcminsert]

@compcode as varchar(8),
@centercode as varchar(8),
@centername as varchar(50),
@alias as varchar(50),
@add1 as varchar(50),
@street as varchar(50),
@city as varchar(15),
@dist as varchar(15),
@country as varchar(8),
@phone1 as varchar(5),
@phone2 as varchar(10),
@pin as varchar(15),
@state as varchar(15),
@fax as varchar(5),
@email as varchar(50),
--@status as varchar(15),
--@statusdate as varchar(15),
@remarks as varchar(200),
@userid as varchar(8),
@region as varchar(8),
@zone As varchar(8),
@fax1 as varchar(10),
@boxaddress as varchar(200),
@printval as VARCHAR(20),
@imgpath as varchar(50),
@cir_imgpath as varchar(50),
@pcompanyname as varchar(50),
@plogopath as varchar(200)
 AS

declare @query as varchar(1000)


declare @distcode as varchar(50)
declare @statecode as varchar(50)
declare @countrycode as varchar(50)

select @distcode =dist_code from dist_mst where dist_name=@dist
select @statecode=state_code from state_mst  where state_Name=@state
select @countrycode=country_code from count_mst  where country_Name=@country



insert into pub_cent_mast ([Comp_Code]
      ,[Pub_cent_Code]
      ,[Pub_Cent_name]
      ,[Pub_Cent_Alias]
      ,[Add1]
      ,[street]
      ,[Country_Code]
      ,[State_Code]
      ,[Dist_Code]
      ,[City_Code]
      ,[zip]
      ,[Phone1]
      ,[Phone2]
      ,[Fax]
      ,[EmailID]
      ,[Pub_Cent_Status]
      ,[Status_date]
      ,[Remarks]
      ,[UserId]
      ,[Creation_Datetime]
      ,[Region_code]
      ,[Zone_code]
      ,[Fax1]
      ,[BOXADDRESS]
      ,[PRINT_CENT]
      ,[IP]
      ,[FILE_PATH]
      ,[CIR_FILE_PATH],[CENTER_COMP_NAME],[LOGO_FILE_PATH]) values(@compcode,@centercode,@centername, @alias,@add1,@street,@country, @state, @dist, @city, @pin,@phone1,@phone2, @fax,@email,'',getdate(),@remarks,@userid,getdate(),@region,@zone,@fax1,@boxaddress,@printval ,'',@imgpath,@cir_imgpath,@pcompanyname,@plogopath)
--insert into pub_cent_mast values(@compcode,@centercode,@centername, @alias,@add1,@street,@country, @state, @dist, @city, @pin,@phone1,@phone2, @fax,@email,'','',@remarks,@userid,@region,@zone,@txtdate),@fax2


exec(@query)
print(@query)

///////////////////////////////////////////////////////UPDATE////////////////////////////////////////////////////////////////////////////////////////

ALTER PROCEDURE [dbo].[pcmupdate]

@compcode as varchar(8),
@centercode as varchar(8),
@centername as varchar(50),
@alias as varchar(50),
@add1 as varchar(50),
@street as varchar(50),
@city as varchar(15),
@dist as varchar(15),
@country as varchar(8),
@phone1 as varchar(5),
@phone2 as varchar(10),
@pin as varchar(15),
@state as varchar(15),
@fax as varchar(5),
@email as varchar(50),
--@status as varchar(15),
--@statusdate as varchar(15),
@remarks    as varchar(200),
--@userid as varchar(8),
@region as varchar(8),
@zone as varchar(8),
@fax1 as varchar(10),
@boxadd  varchar(200),
@printval as varchar(20),
@imgpath as varchar(50),
@cir_imgpath as varchar(50),
@pcompanyname as varchar(50),
@plogopath as varchar(50)
AS

declare @query varchar(1000)
declare @query1 varchar(1000)

set @query=' update pub_cent_mast set Pub_Cent_name='''+@centername+''' , Pub_Cent_Alias='''+@alias+''' , Add1='''+@add1+''' , street='''+@street+''', Country_Code='''+@country+''', State_Code='''+@state+''', Dist_Code='''+@dist+''', City_Code='''+@city+''', zip='''+@pin+''', Phone1='''+@phone1+''', Phone2='''+@phone2+''',Fax='''+@fax+''', EmailID='''+@email+''',Remarks='''+@remarks+''',region_code='''+@region+''',zone_code='''+@zone+''',Fax1='''+@fax1+''' ,BOXADDRESS='''+@boxadd+''',PRINT_CENT='''+@printval+''',FILE_PATH='''+@imgpath+''',CIR_FILE_PATH='''+@cir_imgpath+''',CENTER_COMP_NAME='''+@pcompanyname+''',LOGO_FILE_PATH='''+@plogopath+'''  where comp_code='''+@compcode+'''   and   Pub_cent_Code='''+@centercode+'''   '

--set @query1=' update pcmdummy set Pub_Cent_name='''+@centername+''' , Pub_Cent_Alias='''+@alias+''' , Add1='''+@add1+''' , street='''+@street+''', Country_Code='''+@country+''', State_Code='''+@state+''', Dist_Code='''+@dist+''', City_Code='''+@city+''', zip='''+@pin+''', Phone1='''+@phone1+''', Phone2='''+@phone2+''',Fax='''+@fax+''', EmailID='''+@email+''',Remarks='''+@remarks+''',region_code='''+@region+''',zone_code='''+@zone+''',Fax1='''+@fax1+'''  where comp_code='''+@compcode+'''    and   Pub_cent_Code='''+@centercode+'''   '


print (@query)
exec(@query)
--print(@query1)
--exec(@query1)



@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@PUBLICATION CENTER-26-04-2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@26-04-2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@



alter PROCEDURE getdata_export
   @adtype_p     as VARCHAR(200),
   @fromdate_p   datetime,
   @todate_p     datetime,
   @p_solo       as VARCHAR(200),
   @p_ratecode   as VARCHAR(200),
   @p_pubcent    as VARCHAR(200),
   @pedtn_flag   as VARCHAR(10)--M for Main,E for Edition ,S for Suppliment and A for All
   
AS
BEGIN
IF isnull (@p_solo, '') = 'S' begin
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
	x.tue_rate_extra, x.wed_rate_extra,x.thu_rate_extra, x.fri_rate_extra,x.sat_rate_extra, x.maxwidth,x.priority, x.vat_detail, x.adon,x.ref_id, x.cancellation_charges,
	x."ratemastid" "ratemastid", x."id" "id",x."rate_code" AS "rate_code" from
	(select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
	r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
	r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",convert(varchar(20),r."Valid_From",101) AS valid_from,convert(varchar(20),r."Valid_To",101) AS valid_to, 
	(select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
	(select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
	(select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
	(select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
	r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
	r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
	r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
	r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
	r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,
	'' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
	--,'' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
	FROM rate_mast r
	WHERE "Adv_Type_Code" = @adtype_p  AND "Valid_From" >= @fromdate_p AND "Valid_To" <= @todate_p AND charindex ('+',"combin_desc") <= 0 
	and r."Rate_Mast_Code"=isnull(@p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=@p_pubcent or @p_pubcent is null) and 
	exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=r."combin_desc" and 
	(("Edition_Type"='Main Edition' and @pedtn_flag='M') or ("Edition_Type"='Edition' and @pedtn_flag='E')))
	union
	select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
	r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
	r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",convert(varchar(20),r."Valid_From",101) AS valid_from,convert(varchar(20),r."Valid_To",101) AS valid_to, 
	(select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
	(select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
	(select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
	(select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
	r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
	r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
	r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
	r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
	r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,
	'' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
	--,'' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
	FROM rate_mast r
	WHERE "Adv_Type_Code" = @adtype_p  AND "Valid_From" >= @fromdate_p AND "Valid_To" <= @todate_p AND charindex ('+',"combin_desc") <= 0
	and r."Rate_Mast_Code"=isnull(@p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=@p_pubcent or @p_pubcent is null) and 
	exists(select 'x' from supplement_mast where supplement_mast."Supp_Alias"=r."combin_desc" and @pedtn_flag='S')
	union
	select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
	r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
	r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",convert(varchar(20),r."Valid_From",101) AS valid_from,convert(varchar(20),r."Valid_To",101) AS valid_to, 
	(select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
	(select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
	(select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
	(select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
	r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
	r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
	r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
	r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
	r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,
	'' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
	--,'' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
	FROM rate_mast r
	WHERE r."Adv_Type_Code" = @adtype_p  AND r."Valid_From" >= @fromdate_p AND r."Valid_To" <= @todate_p AND charindex ('+',"combin_desc") <= 0
	and r."Rate_Mast_Code"=isnull(@p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=@p_pubcent or @p_pubcent is null) and @pedtn_flag='A') x
	ORDER BY x."rateuniqueid";
END

IF isnull(@p_solo, '') = 'P' begin
	select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
	r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
	r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",convert(varchar(20),r."Valid_From",101) AS valid_from,convert(varchar(20),r."Valid_To",101) AS valid_to,  
	(select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
	(select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
	(select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
	(select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
	r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
	r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
	r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
	r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
	r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,
	'' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
	--, '' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
	FROM rate_mast r
	WHERE "Adv_Type_Code" = @adtype_p
	AND "Valid_From" >= @fromdate_p
	AND "Valid_To" <= @todate_p
	AND charindex ('+',"combin_desc") > 0
	and r."Rate_Mast_Code"=isnull(@p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=@p_pubcent or @p_pubcent is null)
	ORDER BY r."rateuniqueid";
END

END



@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@26-04-2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


===========start==========avinash===7343=====26apr2012====================================
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go







ALTER Procedure [dbo].[execcontactupdate]
@exename as varchar(30),
@teamcode as varchar(10),
@designation as varchar(30),
@address as varchar(50),
@street as varchar(30),
@city as varchar(10),
@district as varchar(18),

@state as varchar(18),
@country as varchar(10),
@pin as varchar(20),
@phone as varchar(50),
@status as varchar(10),
@compcode as varchar(10),
@userid as varchar(10),
@code as varchar(10),
@report as varchar(8),
@TALUKA1 as varchar(23),
@repname as varchar(50),
@adtype as varchar(8),
@branchcode as varchar(20),
@craditlimit as varchar(20),
@mobile as varchar(50),
@email as varchar(200),
@mailto as varchar(200),
@p_empcode as varchar(50)


as

declare @query as varchar(1000)

declare @query2 as varchar(1000)

--set @query='insert into Exec_mast(Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,phone,exe_status,userid,comp_code,pin_code)  values('''+@teamcode+''','''+@exename+''','''+@designation+''','''+@address+''','''+@street+''' ,'''+@country+''','''+@state+''','''+@district+''','''+@city+''','''+@phone+''','''+@status+''','''+@userid+''','''+@compcode+''','''+@pin+''')'

set @query='update  Exec_mast set  Exec_name='''+@exename+''' ,Designation='''+@designation+''',Add1='''+@address+''',Street='''+@street+''',Country_code='''+@country+''',State_code='''+@state+''',dist_code='''+@district+''',city_code='''+@city+''',phone='''+@phone+''',exe_status='''+@status+''' ,pin_code='''+@pin+''', report_to='''+@report+''',TALUKA='''+@TALUKA1+''',REPRESENTATIVE='''+@repname+''',ADTYPE='''+@adtype+''',Branch_code='''+@branchcode+''',CREDIT_LIMIT='''+@craditlimit+''',MOBILENO='''+@mobile+''',EMAILID='''+@email+''',HR_CODE='''+@p_empcode+''',EMAIL_ID='''+@mailto+''' where comp_code='''+@compcode+''' and Exe_no='''+@code+'''   ' --EXEC_EMAILID='''+@EXEC_EMAILID+''',EXEC_USERID='''+@EXEC_USERID+'''
print(@query)
exec(@query)


set @query2='update Exec_mast set city_name=(select city_name from city_mst where city_code='''+@city+''' and exec_mast.comp_code=city_mst.comp_code) where city_code='''+@city+''' '
print(@query2)
exec(@query2)


*********************************



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go









ALTER Procedure [dbo].[execcontactinsert]
@exename as varchar(30),
@teamcode as varchar(10),
@designation as varchar(30),
@address as varchar(50),
@street as varchar(30),
@city as varchar(20),
@district as varchar(18),

@state as varchar(18),
@country as varchar(10),
@pin as varchar(20),
@phone as varchar(50),
@status as varchar(18),
@compcode as varchar(10),
@userid as varchar(10),
@report as varchar(8),
@taluka1 as varchar(20),
@repname as varchar(50),
@adtype as varchar(8),
@zone as varchar(20),
@craditlimit as varchar(20),
@mobile as varchar(50),
@email as varchar(200),
@mailto as varchar(200),
@p_empcode as varchar(50)




as

declare @exeno as int
declare @query as varchar(1000)
declare @query2 as varchar(1000)

select @exeno= max(isnull(Exe_no,0)+1)  from exec_mast
if @exeno is null
	set @exeno=1
print(@exeno)
if @exeno is null
	set @exeno=1
insert into Exec_mast
(Exe_no,Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,phone,exe_status,userid,comp_code,pin_code,report_to,TALUKA,creation_datetime,REPRESENTATIVE,ADTYPE,Branch_code,CREDIT_LIMIT,MOBILENO,EMAILID,HR_CODE,EMAIL_ID) 
 values(@exeno  ,@teamcode,@exename,@designation,@address,@street ,@country,@state,@district,@city,@phone,@status,@userid,@compcode,@pin,@report,@taluka1,getdate(),@repname,@adtype,@zone,@craditlimit,@mobile,@email,@p_empcode,@mailto)/*'''+@EXEC_USERID+''','''+@EXEC_EMAILID+'''*/
--print(@query)
exec(@query)
--set @query='insert into tmp_exec_mast(Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,phone,exe_status,userid,comp_code,pin_code)  values('''+@teamcode+''','''+@exename+''','''+@designation+''','''+@address+''','''+@street+''' ,'''+@country+''','''+@state+''','''+@district+''','''+@city+''','''+@phone+''','''+@status+''','''+@userid+''','''+@compcode+''','''+@pin+''')'



set @query2='update Exec_mast set city_name=(select city_name from city_mst where comp_code = '''+@compcode+''' and city_code='''+@city+''') where comp_code = '''+@compcode+''' and city_code='''+@city+''' '
select @exeno as 'exeno'
print(@query2)
exec(@query2)


*****************************************


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER Procedure [dbo].[execselectbind]

@code as varchar(10),
@compcode as varchar(10),
@userid as varchar(10)

as

declare @query as varchar(1000)
declare @query1 as varchar(1000)
declare @query2 as varchar(1000)
--set @query='insert into Exec_mast(Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,phone,exe_status,userid,comp_code,pin_code)  values('''+@teamcode+''','''+@exename+''','''+@designation+''','''+@address+''','''+@street+''' ,'''+@country+''','''+@state+''','''+@district+''','''+@city+''','''+@phone+''','''+@status+''','''+@userid+''','''+@compcode+''','''+@pin+''')'

set @query='select Exec_name,Designation,Add1,Street,city_code,dist_code,State_code,Country_code,pin_code,phone,exe_status,Exe_no,report_to, EXEC_EMAILID,EXEC_USERID,TALUKA,REPRESENTATIVE  as repname ,ADTYPE as adtype,Branch_code,CREDIT_LIMIT,MOBILENO,EMAILID,(select NAME+''(''+EMP_CODE+'')'' from HR_EMP_MST where COMP_CD='''+@compcode+''' AND EMP_CODE=Exec_mast.HR_CODE)AS HR_CODE,EMAIL_ID from Exec_mast where comp_code='''+@compcode+'''  and Exe_no ='''+@code+''''/*and userid='''+@userid+'''*/
print(@query)
exec(@query)

set @query1='select TALU_CODE,TALU_NAME from taluka_mast,Exec_mast WHERE taluka_mast.DIST_CODE=(select Dist_Code from dist_mst where Dist_Name =(SELECT dist_code FROM Exec_mast where comp_code='''+@compcode+'''  and Exe_no ='''+@code+''')  ) and Exec_mast.comp_code='''+@compcode+'''  and Exec_mast.Exe_no ='''+@code+''''
print(@query1)
exec(@query1)

set @query2='select catcode as adcat from exec_adcat where compcode='''+@compcode+'''  and execcode ='''+@code+''''
print(@query2)
exec(@query2)



===========End==========avinash===7343=====26apr2012====================================





////////////////////issue no 7279/////////////////



USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[Websp_updatestatus]    Script Date: 05/02/2012 16:36:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO













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
(SELECT distinct adv_subcat_mast."Adv_Subcat_Name" FROM adv_subcat_mast  WHERE adv_subcat_mast ."Adv_Subcat_Code"=TBL_BOOKING_INSERT ."Ad_Sub_Cat") AS "Sub_cat",
(select ad_cat3."catname" from ad_cat3,adv_subcat_mast where tbl_booking_mast."Ad_Subcat3"=ad_cat3."catcode" and ad_cat3."subcatname"=adv_subcat_mast."Adv_Subcat_Code" and TBL_BOOKING_INSERT ."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and TBL_BOOKING_INSERT ."Ad_Cat"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat3",
tbl_booking_insert.gross_rate as   "agreed_rate" ,tbl_booking_mast.caption,
"Uom_Alias" as "Uom",


case TBL_BOOKING_INSERT."Supp_Code"
    when ''MN''then
    (select distinct EDITION_MAST."Edition_Alias" from EDITION_MAST where  tbl_booking_insert."Edition_Code"=EDITION_MAST ."Edition_Code")
    else
    (select distinct supplement_MAST."Supp_Name" from supplement_MAST where  tbl_booking_insert."Supp_Code"=supplement_MAST ."Supp_Code")
    end as "Editionname",
    (SELECT premiumname FROM ADVPOS_PREM_MAST WHERE ADVPOS_PREM_MAST.Premiumcode=TBL_BOOKING_MAST.Page_prem) AS  Page_prem ,


   
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


--tbl_booking_mast.Page_prem,


/////////////////////////////end of issue no 7279////////

------------------------------start updated by dimple issue no:7175------------------------------


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[Websp_Orderlastnew_b]    Script Date: 05/02/2012 12:35:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





ALTER PROCEDURE  [dbo].[Websp_Orderlastnew_b]
(

@bookingid as VARCHAR(500),
@dateformat as VARCHAR(50),
@fromdate as VARCHAR(50),
@dateto as VARCHAR(50),
@v_invoice as VARCHAR(500),
@v_compcode as VARCHAR(50)

)

 AS

declare @query as varchar(8000)
declare @query1 as varchar(8000)
declare @str as varchar(8000)
declare @var_date_min as varchar(8000)
declare @package_cd  as varchar(300)
declare @package_result  as varchar(300)
declare @package_cd1  as varchar(300)
create table #package ( package_name varchar (100) )
set @var_date_min=@fromdate


set @query='SELECT TBL_BOOKING_MAST .RO_No,
 TBL_BOOKING_INSERT .Cio_Booking_Id,
TBL_BOOKING_INSERT.No_Insert ,
TBL_BOOKING_INSERT.Edition,
Height,
Width,
Size_Book,
COL_MAST.Col_Name,
 TBL_BOOKING_INSERT.Page_No,
 TBL_BOOKING_INSERT.No_Ofcolumn,

 TBL_BOOKING_insert.Gross_Rate,
 CASE '''+@dateformat+'''
  WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),Insert_Date,1)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),Insert_Date,3)

WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),Insert_Date,3)  END AS "Ins.date",
tbl_booking_insert.Agreed_Rate,
tbl_booking_mast.Agency_address,
 AGENCY_MAST.Agency_Name,
 CASE '''+@dateformat+'''
   WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),RO_Date,1)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),RO_Date,3)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),RO_Date,3) END AS RO_Date,
pub_mast.Pub_Name as Publication,
(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where ADV_CAT_MAST.Adv_Cat_Code=TBL_BOOKING_MAST.Ad_cat_code)

as AdCat,

isnull((SELECT Cust_Alias FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client
,tbl_booking_mast.Client_address
, city_mst.City_Name,
tbl_booking_insert.No_Insert,
(SELECT BOX_MAST.Box_Charges_Native FROM BOX_MAST,TBL_BOOKING_MAST  WHERE

TBL_BOOKING_MAST.Box_code=BOX_MAST.Box_Code AND TBL_BOOKING_MAST.cio_booking_id='''+@bookingid+''') as

boxcode,
TBL_BOOKING_MAST.Trade_disc,
Invoices,

(select  PUB_CENT_MAST.Add1 FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS Add1,
1 as Phone1,
2 as Phone2,
PUB_CENT_MAST .Fax1 as Fax1,
uom_mast.Uom_Alias ,
TBL_BOOKING_MAST.Key_no AS "Key No",
3 as Email,

CASE '''+@dateformat+'''
when ''mm/dd/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),1) 
when ''dd/mm/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),3) 
when ''yyyy/mm/dd'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),3)  end as "paydate",
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),1) 
when ''dd/mm/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),3) 
when ''yyyy/mm/dd'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),3)  end as "paydatesys",

tbl_booking_insert.Card_Rate,
adv_type_mast.Adv_Type_Name,
tbl_booking_mast.No_of_insertion,
tbl_booking_mast.Gross_amount,
tbl_booking_mast.Caption,



comp_mst .Comp_Name as companyname,

comp_mst.PAN_No as pan,
PUB_CENT_MAST.Pub_Cent_name as pubname,

comp_mst.Add1 as address,
comp_mst.Street as street,
comp_mst.Fax as fax,
(select distinct Bullet_Charges  from BULlet_mast,tbl_booking_mast where tbl_booking_mast

.Bullet_code=BULlet_mast.Bullet_Code  AND   TBL_BOOKING_mast.cio_booking_id='''+@bookingid+''' ) AS

expremiumch,
TBL_BOOKING_MAST  .ADD_AGENCY_COMM as adtd,


tbl_booking_mast.Trade_disc  as td,

  tbl_booking_mast.branch,
    col_mast.Col_Alias as  Color_code,


   CASE '''+@dateformat+'''
   WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),getdate(),1)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),getdate(),3)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),getdate(),3) END AS SYSDATE1,


(select PUB_CENT_MAST .EmailID FROM PUB_CENT_MAST WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS EmailID,


CASE '''+@dateformat+'''
 when ''mm/dd/yyyy''  then(select convert(varchar(20),max(Insert_Date),1) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''')
 when ''dd/mm/yyyy'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id='''+@bookingid+''')

 when ''yyyy/mm/dd'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''') end as maxdate,


 (select advpos_type_mast.Amount from  advpos_type_mast where

advpos_type_mast.Pos_Type_Code=tbl_booking_mast.Page_position_code)as expr,

 tbl_booking_mast.Card_rate*Total_area as amtnew,

50 as  "PACKAGERATE",

/* ((SELECT SUM(Card_Rate-ROUND((Card_Rate*(isnull(TBL_BOOKING_MAST.Special_disc_per,0)+isnull(TBL_BOOKING_MAST.Space_disc_per,0))/100),2)) FROM TBL_BOOKING_INSERT  WHERE INSERTS=''1'' AND TBL_BOOKING_INSERT
.Cio_Booking_Id='''+@bookingid+''' and
Insert_Date between  '''+@var_date_min+''' and '''+@dateto+''' )) AS PACKAGERATE,*/

TBL_BOOKING_MAST.Agrred_rate,




(select  PUB_CENT_MAST.street FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS street_new,





CASE '''+@dateformat+'''
 when ''mm/dd/yyyy''  then(select convert(varchar(20),max(Insert_Date),1) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''' AND Insert_Date between  '''+@fromdate+''' and
'''+@dateto+''')
 when ''dd/mm/yyyy'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id='''+@bookingid+''' AND Insert_Date between  '''+@fromdate+''' and
'''+@dateto+''')

 when ''yyyy/mm/dd'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''' AND Insert_Date between  '''+@fromdate+''' and
'''+@dateto+''') end as maxdate1,

TBL_BOOKING_INSERT.Bill_Amt,';


set @query1='(select  PUB_CENT_MAST.Fax FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS Fax2,

(select  PUB_CENT_MAST.Fax1 FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS Fax3,
(select  PUB_CENT_MAST."FILE_PATH" FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST."Pub_cent_Code" IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS FILE_PATH,
tbl_booking_mast."Special_charges" as "Special_charges",


pub_cent_mast.Fax1 as fax1,
pub_cent_mast.phone1 as phone,
pub_cent_mast.phone1 as phone0,
COL_MAST.Col_Code,
tbl_booking_mast."Bill_to" as "bill2",
dbo.getadd('''+@v_compcode+''','''+@bookingid+''') as "agenadd",

tbl_booking_mast.bill_remarks as "Remark",
(select lang_name from lang_mast where lang_mast.lang_code=pub_mast.lang_code) as "language" ,

(select advpos_type_mast.pos_type from advpos_type_mast where advpos_type_mast.pos_type_code=tbl_booking_insert.page_post) as "pageposition",


   (select retain_Name from  retainermaster where retainermaster.retain_code=tbl_booking_mast.retainer)as "Retainer",
   (select exec_name from exec_mast where exec_mast.exe_no=tbl_booking_mast.executive_code) as "Executive"




FROM TBL_BOOKING_MAST  ,
TBL_BOOKING_INSERT,
COL_MAST,
AGENCY_MAST,
PUB_MAST,
CITY_MST,
PUB_CENT_MAST,
uom_mast,
adv_type_mast,
comp_mst
WHERE  TBL_BOOKING_INSERT.Col_Code=COL_MAST.Col_Code 
AND  CITY_MST.City_Code=AGENCY_MAST.City_Code  

AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code 
AND TBL_BOOKING_INSERT.Publication_Code=PUB_MAST.Pub_Code
and uom_mast.Uom_Code=tbl_booking_mast.Uom_code
and TBL_BOOKING_MAST .Comp_code=comp_mst.Comp_Code
and tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code 
 AND adv_type_mast.COMP_CODE=TBL_BOOKING_MAST.COMP_CODE
and PUB_CENT_MAST.Pub_cent_Code  =TBL_BOOKING_INSERT.Pub_Cent_Code
AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
AND TBL_BOOKING_INSERT  .Cio_Booking_Id='''+@bookingid+''' 
and Insert_Date between  '''+@var_date_min+''' and
'''+@dateto+'''
and (bill_no='''+@v_invoice+''' or  '''+@v_invoice+'''= '''')

and Insert_Status!=''cancel''


order by tbl_booking_insert. No_Insert'

print(@query)
print(@query1)
exec(@query+@query1)

select  @package_cd1=package_code from tbl_booking_mast where cio_booking_id=@bookingid



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
exec(@str)

select * from #package
delete from #package


update ad_bills set PRINT_COUNT=isnull(PRINT_COUNT,0)+1 where COMP_CODE_V=@v_compcode and BILNO=@v_invoice;







-----------------------------------end issue no:7175------------------------------------------------

******************************updated by dimple*******03/05/2012*********************************
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[Websp_Orderlastnew_b]    Script Date: 05/03/2012 13:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






ALTER PROCEDURE  [dbo].[Websp_Orderlastnew_b]
(

@bookingid as VARCHAR(500),
@dateformat as VARCHAR(50),
@fromdate as VARCHAR(50),
@dateto as VARCHAR(50),
@v_invoice as VARCHAR(500),
@v_compcode as VARCHAR(50)

)

 AS

declare @query as varchar(8000)
declare @query1 as varchar(8000)
declare @str as varchar(8000)
declare @var_date_min as varchar(8000)
declare @package_cd  as varchar(300)
declare @package_result  as varchar(300)
declare @package_cd1  as varchar(300)
create table #package ( package_name varchar (100) )
set @var_date_min=@fromdate


set @query='SELECT TBL_BOOKING_MAST .RO_No,
 TBL_BOOKING_INSERT .Cio_Booking_Id,
TBL_BOOKING_INSERT.No_Insert ,
TBL_BOOKING_INSERT.Edition,
Height,
Width,
Size_Book,
COL_MAST.Col_Name,
 TBL_BOOKING_INSERT.Page_No,
 TBL_BOOKING_INSERT.No_Ofcolumn,

 TBL_BOOKING_insert.Gross_Rate,
 CASE '''+@dateformat+'''
  WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),Insert_Date,1)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),Insert_Date,3)

WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),Insert_Date,3)  END AS "Ins.date",
tbl_booking_insert.Agreed_Rate,
tbl_booking_mast.Agency_address,
 AGENCY_MAST.Agency_Name,
 CASE '''+@dateformat+'''
   WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),RO_Date,1)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),RO_Date,3)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),RO_Date,3) END AS RO_Date,
pub_mast.Pub_Name as Publication,
(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where ADV_CAT_MAST.Adv_Cat_Code=TBL_BOOKING_MAST.Ad_cat_code)

as AdCat,

isnull((SELECT Cust_Alias FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client
,tbl_booking_mast.Client_address
, city_mst.City_Name,
tbl_booking_insert.No_Insert,
(SELECT BOX_MAST.Box_Charges_Native FROM BOX_MAST,TBL_BOOKING_MAST  WHERE

TBL_BOOKING_MAST.Box_code=BOX_MAST.Box_Code AND TBL_BOOKING_MAST.cio_booking_id='''+@bookingid+''') as

boxcode,
TBL_BOOKING_MAST.Trade_disc,
Invoices,

(select  PUB_CENT_MAST.Add1 FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS Add1,
1 as Phone1,
2 as Phone2,
PUB_CENT_MAST .Fax1 as Fax1,
uom_mast.Uom_Alias ,
TBL_BOOKING_MAST.Key_no AS "Key No",
3 as Email,

CASE '''+@dateformat+'''
when ''mm/dd/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),1) 
when ''dd/mm/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),3) 
when ''yyyy/mm/dd'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),3)  end as "paydate",
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),1) 
when ''dd/mm/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),3) 
when ''yyyy/mm/dd'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),3)  end as "paydatesys",

tbl_booking_insert.Card_Rate,
adv_type_mast.Adv_Type_Name,
tbl_booking_mast.No_of_insertion,
tbl_booking_mast.Gross_amount,
tbl_booking_mast.Caption,



comp_mst .Comp_Name as companyname,

comp_mst.PAN_No as pan,
PUB_CENT_MAST.Pub_Cent_name as pubname,

comp_mst.Add1 as address,
comp_mst.Street as street,
comp_mst.Fax as fax,
(select distinct Bullet_Charges  from BULlet_mast,tbl_booking_mast where tbl_booking_mast

.Bullet_code=BULlet_mast.Bullet_Code  AND   TBL_BOOKING_mast.cio_booking_id='''+@bookingid+''' ) AS

expremiumch,
TBL_BOOKING_MAST  .ADD_AGENCY_COMM as adtd,


tbl_booking_mast.Trade_disc  as td,

  tbl_booking_mast.branch,
    col_mast.Col_Alias as  Color_code,


   CASE '''+@dateformat+'''
   WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),getdate(),1)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),getdate(),3)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),getdate(),3) END AS SYSDATE1,


(select PUB_CENT_MAST .EmailID FROM PUB_CENT_MAST WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS EmailID,


CASE '''+@dateformat+'''
 when ''mm/dd/yyyy''  then(select convert(varchar(20),max(Insert_Date),1) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''')
 when ''dd/mm/yyyy'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id='''+@bookingid+''')

 when ''yyyy/mm/dd'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''') end as maxdate,


 (select advpos_type_mast.Amount from  advpos_type_mast where

advpos_type_mast.Pos_Type_Code=tbl_booking_mast.Page_position_code)as expr,

 tbl_booking_mast.Card_rate*Total_area as amtnew,

50 as  "PACKAGERATE",

/* ((SELECT SUM(Card_Rate-ROUND((Card_Rate*(isnull(TBL_BOOKING_MAST.Special_disc_per,0)+isnull(TBL_BOOKING_MAST.Space_disc_per,0))/100),2)) FROM TBL_BOOKING_INSERT  WHERE INSERTS=''1'' AND TBL_BOOKING_INSERT
.Cio_Booking_Id='''+@bookingid+''' and
Insert_Date between  '''+@var_date_min+''' and '''+@dateto+''' )) AS PACKAGERATE,*/

TBL_BOOKING_MAST.Agrred_rate,




(select  PUB_CENT_MAST.street FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS street_new,





CASE '''+@dateformat+'''
 when ''mm/dd/yyyy''  then(select convert(varchar(20),max(Insert_Date),1) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''' AND Insert_Date between  '''+@fromdate+''' and
'''+@dateto+''')
 when ''dd/mm/yyyy'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id='''+@bookingid+''' AND Insert_Date between  '''+@fromdate+''' and
'''+@dateto+''')

 when ''yyyy/mm/dd'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''' AND Insert_Date between  '''+@fromdate+''' and
'''+@dateto+''') end as maxdate1,

TBL_BOOKING_INSERT.Bill_Amt,';


set @query1='(select  PUB_CENT_MAST.Fax FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS Fax2,

(select  PUB_CENT_MAST.Fax1 FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS Fax3,
(select  PUB_CENT_MAST."FILE_PATH" FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST."Pub_cent_Code" IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS FILE_PATH,
tbl_booking_mast."Special_charges" as "Special_charges",


pub_cent_mast.Fax1 as fax1,
pub_cent_mast.phone1 as phone,
pub_cent_mast.phone1 as phone0,
COL_MAST.Col_Code,
tbl_booking_mast."Bill_to" as "bill2",
dbo.getadd('''+@v_compcode+''','''+@bookingid+''') as "agenadd",

tbl_booking_mast.bill_remarks as "Remark",
(select lang_name from lang_mast where lang_mast.lang_code=pub_mast.lang_code) as "language" ,

(select advpos_type_mast.pos_type from advpos_type_mast where advpos_type_mast.pos_type_code=tbl_booking_insert.page_post) as "pageposition",


   (select retain_Name from  retainermaster where retainermaster.retain_code=tbl_booking_mast.retainer)as "Retainer",
   (select exec_name from exec_mast where exec_mast.exe_no=tbl_booking_mast.executive_code) as "Executive",


(select distinct premiumname from ADVPOS_PREM_MAST where   ADVPOS_PREM_MAST. premiumcode=tbl_booking_insert.premium1) as "premium_name"





FROM TBL_BOOKING_MAST  ,
TBL_BOOKING_INSERT,
COL_MAST,
AGENCY_MAST,
PUB_MAST,
CITY_MST,
PUB_CENT_MAST,
uom_mast,
adv_type_mast,
comp_mst
WHERE  TBL_BOOKING_INSERT.Col_Code=COL_MAST.Col_Code 
AND  CITY_MST.City_Code=AGENCY_MAST.City_Code  

AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code 
AND TBL_BOOKING_INSERT.Publication_Code=PUB_MAST.Pub_Code
and uom_mast.Uom_Code=tbl_booking_mast.Uom_code
and TBL_BOOKING_MAST .Comp_code=comp_mst.Comp_Code
and tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code 
 AND adv_type_mast.COMP_CODE=TBL_BOOKING_MAST.COMP_CODE
and PUB_CENT_MAST.Pub_cent_Code  =TBL_BOOKING_INSERT.Pub_Cent_Code
AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
AND TBL_BOOKING_INSERT  .Cio_Booking_Id='''+@bookingid+''' 
and Insert_Date between  '''+@var_date_min+''' and
'''+@dateto+'''
and (bill_no='''+@v_invoice+''' or  '''+@v_invoice+'''= '''')

and Insert_Status!=''cancel''


order by tbl_booking_insert. No_Insert'

print(@query)
print(@query1)
exec(@query+@query1)

select  @package_cd1=package_code from tbl_booking_mast where cio_booking_id=@bookingid



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
exec(@str)

select * from #package
delete from #package


update ad_bills set PRINT_COUNT=isnull(PRINT_COUNT,0)+1 where COMP_CODE_V=@v_compcode and BILNO=@v_invoice;







************************************************end*********03/05/2012***********
///////////////////////////issue 7460
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[selectmax_latest]    Script Date: 05/09/2012 18:28:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ================================================
 ALTER  PROCEDURE  [dbo].[selectmax_latest]
@date as varchar(15),
@pfromdate as varchar(30),
@ptodate as  varchar(30),
@ppublication as varchar(50),
@pbookingcenter as varchar(40),
@prevenuecenter as varchar(40),
@pagencytype as varchar(30),
@ppckage as varchar(40),
@padtype as varchar(50),
@pagency as varchar(50),
@pclient as varchar(50),
@billstatus as varchar(50),
@rate_audit as varchar(8),
@billmode as  varchar(10),
@billcycle as varchar(10),
@compcode as varchar(10),
@userid as varchar(10),
@DISP_CLSBILL as varchar(100),
@v_retainer_name as varchar(200),
@v_executive_name as varchar(200),
@v_branch_name as varchar(200),
@v_ad_category as varchar(100),
@v_district as varchar(100),
@v_taluka as varchar(100),
@V_DISP_CASHBILL as varchar(100),
@V_FMG_BILL_DIS as varchar(100),
@V_BILL_DISP_CASHBILL as varchar(100),
@v_centername as varchar(100),
@v_ROWISE_CASHBOOKING as varchar(100),
@pbillno as varchar(100)

as 

declare  @str as varchar(8000)
declare  @str1 as varchar(8000)
declare  @puom_code as varchar(8000)
declare @padtype_new  as varchar(8000)
declare  @VAR_DATE AS datetime;
declare @var_date_min AS  varchar(10)
declare @month_var AS varchar(500);
declare @v_bill_criteria as varchar(10);

if(@DISP_CLSBILL='N')
begin
set @puom_code= ''
SET @padtype_new=@padtype
END

else
BEGIN
SET @puom_code='CD'
SET @padtype_new=@padtype
end 

if @padtype='DI0' begin
    select @v_bill_criteria=disp_billing_criteria from preferrences where comp_code=@compcode
	end
else
	begin
    select @v_bill_criteria=clsd_billing_criteria From preferrences where comp_code=@compcode
	end
	
	
	if @padtype='RO0' begin
    select @v_bill_criteria=disp_billing_criteria from preferrences where comp_code=@compcode
	end
else
	begin
    select @v_bill_criteria=clsd_billing_criteria From preferrences where comp_code=@compcode
	end


SELECT @var_date=DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@ptodate)+1,0))
--SELECT @var_date_min=convert(varchar(11),(DATEADD(dd,-(DAY(DATEADD(mm,1,@ptodate))-1),DATEADD(mm,0,@ptodate))),106)
SELECT @var_date_min=month(@ptodate)
select @month_var=convert(varchar(4),@ptodate,100)









IF(@billstatus='5')
    BEGIN
             set  @str='select DISTINCT
    tbl_booking_insert.Cio_Booking_Id,tbl_booking_mast.Trade_disc as
    Commission,
               (select Agency_Name from agency_mast where
    agency_mast.code_subcode=tbl_booking_mast.Agency_sub_code) as
    Agency,

               count(distinct tbl_booking_insert.No_Insert)as NoOfAds,
      isnull((SELECT Cust_Alias FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client
    ,
             sum(Gross_Rate) as TotalAmount,
             Insert_Status as Status,
             tbl_booking_mast.Agency_sub_code,BILL_NO,

        (SELECT count(tbl_booking_insert.Insert_Id) FROM  tbl_booking_insert WHERE tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id AND
    Insert_Date between '''+@pfromdate+''' and  '''+@ptodate+'''   and  TBL_BOOKING_INSERT.Insert_Status ! =''cancel'' ) as TotalCount


    ,(SELECT count(tbl_booking_insert.Insert_Id) FROM  tbl_booking_insert WHERE tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id AND
    Insert_Date between '''+@pfromdate+''' and '''+@ptodate+''' and  TBL_BOOKING_INSERT.Insert_Status =''audit by rate''  and  TBL_BOOKING_INSERT.Insert_Status ! =''cancel'' )as AuditCount
,(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert.Comp_Code=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as PrintCount
              from tbl_booking_insert  ,tbl_booking_mast  where
     (select max(Insert_Date) from tbl_booking_insert where tbl_booking_mast.cio_booking_id
    =tbl_booking_insert.Cio_Booking_Id  AND   TBL_BOOKING_INSERT.Insert_Status  not in(''cancel'',''billed'')
    --and Insert_Date= '''+@pfromdate+''' 
      ) between '''+@pfromdate+'''  and '''+@ptodate+''' 
   -- AND  substring(tbl_booking_insert.Cio_Booking_Id,0,3)='''+@v_centername+'''
    and (tbl_booking_mast.Uom_code in (select UOM_MAST .Uom_Code FROM UOM_MAST  WHERE UOM_DESC ='''+@puom_code+''' or  '''' = ''''))
    and (TBL_BOOKING_INSERT.Insert_Status =''publish'')
               and tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id'

 END 



IF(@billstatus='3'  )
  begin
set @str='select DISTINCT
    tbl_booking_insert.Cio_Booking_Id,tbl_booking_mast.Trade_disc as
    Commission,
               (select Agency_Name from agency_mast where
    agency_mast.code_subcode=tbl_booking_mast.Agency_sub_code) as
    Agency,

               count(distinct tbl_booking_insert.No_Insert)as NoOfAds,
      isnull((SELECT Cust_Alias FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client
    ,
             sum(Gross_Rate) as TotalAmount,
             Insert_Status as Status,
             tbl_booking_mast.Agency_sub_code,BILL_NO,

        (SELECT count(tbl_booking_insert.Insert_Id) FROM  tbl_booking_insert WHERE tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id AND
    Insert_Date between '''+@pfromdate+''' and  '''+@ptodate+'''   and  TBL_BOOKING_INSERT.Insert_Status ! =''cancel'' ) as TotalCount


    ,(SELECT count(tbl_booking_insert.Insert_Id) FROM  tbl_booking_insert WHERE tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id AND
    Insert_Date between '''+@pfromdate+''' and '''+@ptodate+''' and  TBL_BOOKING_INSERT.Insert_Status =''audit by rate''  and  TBL_BOOKING_INSERT.Insert_Status ! =''cancel'' )as AuditCount
,(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert.Comp_Code=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as PrintCount
              from tbl_booking_insert  ,tbl_booking_mast  where
     (select max(Insert_Date) from tbl_booking_insert where tbl_booking_mast.cio_booking_id
    =tbl_booking_insert.Cio_Booking_Id  AND   TBL_BOOKING_INSERT.Insert_Status  not in(''cancel'',''billed'')
     and convert (varchar(30) ,month(Insert_Date))= '''+@var_date_min+''' 
      ) between '''+@pfromdate+'''  and '''+@ptodate+''' 
   -- AND  substring(tbl_booking_insert.Cio_Booking_Id,0,3)='''+@v_centername+'''
    and (tbl_booking_mast.Uom_code in (select UOM_MAST .Uom_Code FROM UOM_MAST  WHERE UOM_DESC ='''+@puom_code+''' or  '''' = ''''))
    and (TBL_BOOKING_INSERT.Insert_Status =''audit by rate'')
               and tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id'

end




IF(@billstatus='2' )
   BEGIN

print('ads')
            set  @str='select DISTINCT
    tbl_booking_insert.Cio_Booking_Id,tbl_booking_mast.Trade_disc as
    Commission,
               (select Agency_Name from agency_mast where
    agency_mast.code_subcode=tbl_booking_mast.Agency_sub_code) as
    Agency,

               count(distinct tbl_booking_insert.No_Insert)as NoOfAds,
      isnull((SELECT Cust_Alias FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client
    ,
             sum(Gross_Rate) as TotalAmount,
             Insert_Status as Status,
             tbl_booking_mast.Agency_sub_code,BILL_NO,

        (SELECT count(tbl_booking_insert.Insert_Id) FROM  tbl_booking_insert WHERE tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id AND
    Insert_Date between '''+@pfromdate+''' and  '''+@ptodate+'''   and  TBL_BOOKING_INSERT.Insert_Status ! =''cancel'' ) as TotalCount


    ,(SELECT count(tbl_booking_insert.Insert_Id) FROM  tbl_booking_insert WHERE tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id AND
    Insert_Date between '''+@pfromdate+''' and '''+@ptodate+''' and  TBL_BOOKING_INSERT.Insert_Status =''audit by rate''  and  TBL_BOOKING_INSERT.Insert_Status ! =''cancel'' )as AuditCount
,(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert.Comp_Code=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as PrintCount
              from tbl_booking_insert  ,tbl_booking_mast  where
     (select max(Insert_Date) from tbl_booking_insert where tbl_booking_mast.cio_booking_id
    =tbl_booking_insert.Cio_Booking_Id  AND   TBL_BOOKING_INSERT.Insert_Status  not in(''cancel'')
   and convert (varchar(30) ,month(Insert_Date))= '''+@var_date_min+''' 
      ) between '''+@pfromdate+'''  and '''+@ptodate+''' 
   -- AND  substring(tbl_booking_insert.Cio_Booking_Id,0,3)='''+@v_centername+'''
    and (tbl_booking_mast.Uom_code in (select UOM_MAST .Uom_Code FROM UOM_MAST  WHERE UOM_DESC ='''+@puom_code+'''  or  '''' = ''''))
    and (TBL_BOOKING_INSERT.Insert_Status =''billed'')
               and tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id'
   END






IF(@billstatus='6')
       BEGIN
           set  @str='select DISTINCT
    tbl_booking_insert.Cio_Booking_Id,tbl_booking_mast.Trade_disc as
    Commission,
               (select Agency_Name from agency_mast where
    agency_mast.code_subcode=tbl_booking_mast.Agency_sub_code) as
    Agency,

               count(distinct tbl_booking_insert.No_Insert)as NoOfAds,
      isnull((SELECT Cust_Alias FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client
    ,
             sum(Gross_Rate) as TotalAmount,
             Insert_Status as Status,
             tbl_booking_mast.Agency_sub_code,BILL_NO,

        (SELECT count(tbl_booking_insert.Insert_Id) FROM  tbl_booking_insert WHERE tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id AND
    Insert_Date between '''+@pfromdate+''' and  '''+@ptodate+'''   and  TBL_BOOKING_INSERT.Insert_Status ! =''cancel'' ) as TotalCount


    ,(SELECT count(tbl_booking_insert.Insert_Id) FROM  tbl_booking_insert WHERE tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id AND
    Insert_Date between '''+@pfromdate+''' and '''+@ptodate+''' and  TBL_BOOKING_INSERT.Insert_Status =''audit by rate''  and  TBL_BOOKING_INSERT.Insert_Status ! =''cancel'' )as AuditCount
,(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert.Comp_Code=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as PrintCount
              from tbl_booking_insert  ,tbl_booking_mast  where
     (select max(Insert_Date) from tbl_booking_insert where tbl_booking_mast.cio_booking_id
    =tbl_booking_insert.Cio_Booking_Id  AND   TBL_BOOKING_INSERT.Insert_Status  not in(''cancel'',''billed'')
       and convert (varchar(30) ,month(Insert_Date))= '''+@var_date_min+''' 
      ) between '''+@pfromdate+'''  and '''+@ptodate+''' 
   -- AND  substring(tbl_booking_insert.Cio_Booking_Id,0,3)='''+@v_centername+'''
    and (tbl_booking_mast.Uom_code in (select UOM_MAST .Uom_Code FROM UOM_MAST  WHERE UOM_DESC ='''+@puom_code+'''))
    and (TBL_BOOKING_INSERT.Insert_Status =''booked'')
               and tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id'
    END 

 IF(@V_FMG_BILL_DIS ='Exclude')
begin
 set @str=@str +' and TBL_BOOKING_MAST .Booking_type !=''2'''
END 




IF(@billstatus='2')
begin
set @str=@str +' and TBL_BOOKING_MAST .Booking_type !=''2'''
END 



        IF(@V_DISP_CASHBILL  ='N' )
begin
set @str=@str +' and TBL_BOOKING_MAST .Bill_pay !=''CA0'''
END 


IF(@V_BILL_DISP_CASHBILL='N' AND @billstatus='2' )

begin
set @str=@str +' and TBL_BOOKING_MAST .Bill_pay !=''CA0'''
END 


        IF(@v_retainer_name <> '' )
begin
set @str=@str +' and TBL_BOOKING_MAST .RETAINER ='''+@v_retainer_name+''''
END 




        IF(@v_executive_name <> '' )
begin
set @str=@str +' and TBL_BOOKING_MAST  .Executive_code ='''+@v_executive_name+ ''''
END 



IF(@v_branch_name  IS NOT NULL)
begin
set @str=@str +' and TBL_BOOKING_MAST .branch ='''+@v_branch_name+''''
END 




IF(@v_ad_category  <> '' or  @v_ad_category<>  null)
begin
set @str=@str +' and TBL_BOOKING_MAST .Ad_cat_code ='''+@v_ad_category+''''
END 


IF(@v_district  IS NOT NULL)
begin 
set @str=@str +' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.Dist_Code ='''+@v_district+''') '
END 



IF(@v_taluka IS NOT NULL)
begin
set @str=@str +'  AND TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where (AGENCY_MAST.Dist_Code  in(select DIST_CODE from taluka_mast where   TALU_CODE='''+@v_taluka+''' ) )  AND AGENCY_MAST.Dist_Code='''+@v_district+'''  )'
END 



IF(@pagency  IS NOT NULL)
begin
set @str=@str +' and TBL_BOOKING_MAST.Agency_sub_code ='''+@pagency +''''
END 
IF(@pclient  IS NOT NULL)
begin
set @str=@str +' and TBL_BOOKING_MAST.Client_code ='''+@pclient+ ''''
END 
IF(@pagencytype  IS NOT NULL)
begin
set @str=@str +' and TBL_BOOKING_mast.Agency_type  ='''+@pagencytype+''''
END 
IF(@padtype_new IS NOT NULL)
begin
set @str=@str +' and TBL_BOOKING_MAST. Ad_type_code ='''+@padtype_new+''''
END 
IF(@pbookingcenter IS NOT NULL)
begin
set @str=@str +' and TBL_BOOKING_MAST.branch IN (SELECT Branch_code FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_code and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code='''+@pbookingcenter+ '''))'
END 
IF(@prevenuecenter IS NOT NULL)
begin
set @str=@str +' and TBL_BOOKING_MAST. branch ='''+@prevenuecenter+ ''''
END 
IF(@ppublication  IS NOT NULL)
begin
set @str=@str +' and  TBL_BOOKING_INSERT.Publication_Code='''+@ppublication+ ''''
END 
IF(@ppckage  IS NOT NULL)
begin
set @str=@str +' and  TBL_BOOKING_insert .Edition_Code='''+@ppckage+ ''''
END 

set @str=@str +' group by tbl_booking_insert.Cio_Booking_Id
,tbl_booking_mast.Agency_sub_code,
Insert_Status,Trade_disc,tbl_booking_mast.Client_code
,tbl_booking_insert.BILL_NO, tbl_booking_mast.cio_booking_id,tbl_booking_insert.Comp_Code '


IF(@v_ROWISE_CASHBOOKING='CASHBILLROWISE')
begin
IF(@billstatus='3' )
   begin
                  set @str=@str +' UNION select DISTINCT
tbl_booking_insert.Cio_Booking_Id,tbl_booking_mast.Trade_disc as
Commission,
           (select Agency_Name from agency_mast where
agency_mast.code_subcode=tbl_booking_mast.Agency_sub_code) as
Agency,

           count(distinct tbl_booking_insert.No_Insert)as NoOfAds,
  isnull((SELECT Cust_Alias FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client
,
         sum(Gross_Rate) as TotalAmount,
         Insert_Status as Status,
         tbl_booking_mast.Agency_sub_code,BILL_NO,

    (SELECT count(tbl_booking_insert.Insert_Id) FROM  tbl_booking_insert WHERE tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id AND
Insert_Date between '''+@pfromdate+''' and '''+@ptodate+'''   and  TBL_BOOKING_INSERT.Insert_Status ! =''cancel'' ) as TotalCount

,(SELECT count(tbl_booking_insert.Insert_Id) FROM  tbl_booking_insert WHERE tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id AND
Insert_Date between '''+@pfromdate+''' and '''+@ptodate+''' and  TBL_BOOKING_INSERT.Insert_Status =''audit by rate''  and  TBL_BOOKING_INSERT.Insert_Status ! =''cancel'' )as AuditCount


,(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert.Comp_Code=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO ) as PrintCount

          from tbl_booking_insert  ,tbl_booking_mast  where
           (select max(Insert_Date) from tbl_booking_insert where  tbl_booking_mast.cio_booking_id
    =tbl_booking_insert.Cio_Booking_Id  AND   TBL_BOOKING_INSERT.Insert_Status !=''cancel''
    
    and convert (varchar(30) ,month(Insert_Date))= '''+@var_date_min+''' 
    ) between '''+@pfromdate+''' and '''+@ptodate+ '''

--AND  substring(Cio_Booking_Id,0,3)='''+@v_centername+'''

and (tbl_booking_mast.Uom_code in (select UOM_MAST .Uom_Code FROM UOM_MAST  WHERE UOM_DESC !='''+@puom_code+''') )
AND TBL_BOOKING_MAST .Bill_pay =''CA0''
and (TBL_BOOKING_INSERT.Insert_Status =''audit by rate'')
           and tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id'
     

IF(@V_FMG_BILL_DIS  ='Exclude')
begin
set @str=@str +' and TBL_BOOKING_MAST .Booking_type !=''2'''
END 

IF(@billstatus='2')
begin
set @str=@str +' and TBL_BOOKING_MAST .Booking_type !=''2'''
END 

IF(@V_DISP_CASHBILL  ='N' )
begin
set @str=@str +' and TBL_BOOKING_MAST .Bill_pay !=''CA0'''
END 

IF(@V_BILL_DISP_CASHBILL='N' AND @billstatus='2' )
begin
set @str=@str +' and TBL_BOOKING_MAST .Bill_pay !=''CA0'''
END 

IF(@v_retainer_name <> '' )
begin
set @str=@str +' and TBL_BOOKING_MAST .RETAINER ='''+@v_retainer_name+ ''''
END 

IF(@v_executive_name <> '' )
begin
set @str=@str +' and TBL_BOOKING_MAST  .Executive_code ='''+@v_executive_name+ ''''
END 

IF(@v_branch_name  IS NOT NULL)
begin
set @str=@str +' and TBL_BOOKING_MAST .branch ='''+@v_branch_name+ ''''
END 

IF(@v_ad_category <> '' )
begin
set @str=@str +' and TBL_BOOKING_MAST .Ad_cat_code ='''+@v_ad_category+''''
END 

IF(@v_district  IS NOT NULL)
begin
set @str=@str +' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.Dist_Code ='''+@v_district+''')'
END 

IF(@v_taluka IS NOT NULL)
begin
set @str=@str +'  AND TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where (AGENCY_MAST.Dist_Code  in(select DIST_CODE from taluka_mast where   TALU_CODE='''+@v_taluka+''')  AND AGENCY_MAST.Dist_Code='''+@v_district+''')'
END 

/*
if @v_bill_criteria='A' begin--it is for agency bill frequncy
	if(@billcycle is not null )
	begin	
		if(@billcycle != '1')
		begin
			set @str=@str+' and AGENCY_MAST.bill_frequency ='''+@billcycle +''''
		end
		else
		begin
			set @str=@str+' and isnull(AGENCY_MAST.bill_frequency,0) not in (''W'',''M'',''F'')'
		end
	end
end

*/
if @v_bill_criteria='R' begin --it is for bill cycle in booking
	if(@billcycle is not null )
	begin
		set @str=@str+' and TBL_BOOKING_MAST.Bill_cycle ='''+@billcycle +''''
	end
end

IF(@pagency  IS NOT NULL)
begin
set @str=@str +' and TBL_BOOKING_MAST.Agency_sub_code ='''+@pagency+ ''''
END 

IF(@pclient  IS NOT NULL)
begin
set @str=@str +' and TBL_BOOKING_MAST.Client_code ='''+@pclient+ ''''
END 

IF(@pagencytype  IS NOT NULL)
begin
set @str=@str +' and TBL_BOOKING_mast.Agency_type  ='''+@pagencytype+ ''''
END 

IF(@padtype_new <> '' or  @padtype_new<>  null)
begin
set @str=@str +' and TBL_BOOKING_MAST. Ad_type_code = '''+@padtype_new+ ''''
END 

IF(@pbookingcenter IS NOT NULL)
begin

set @str=@str +' and TBL_BOOKING_MAST.branch IN (SELECT Branch_code FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_code and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code='''+@pbookingcenter+'''))'
END 

IF(@prevenuecenter IS NOT NULL)
begin
set @str=@str +' and TBL_BOOKING_MAST. branch ='''+@prevenuecenter+ ''''
END 

IF(@ppublication  IS NOT NULL)
begin
set @str=@str +' and  TBL_BOOKING_INSERT.Publication_Code='''+@ppublication+ ''''
END 

IF(@ppckage  IS NOT NULL)
begin
set @str=@str +' and  TBL_BOOKING_insert .Edition_Code='''+@ppckage+ ''''
END 

set @str=@str +' group by tbl_booking_insert.Cio_Booking_Id
,tbl_booking_mast.Agency_sub_code,
Insert_Status,Trade_disc,tbl_booking_mast.Client_code
,tbl_booking_insert.BILL_NO, tbl_booking_mast.cio_booking_id , tbl_booking_insert.Comp_Code '




END 
END 
set @str=@str +'order by tbl_booking_insert.Cio_Booking_Id'









/*set @str=@str +' group by tbl_booking_insert.Cio_Booking_Id
,tbl_booking_mast.Agency_sub_code,
Insert_Status,Trade_disc,tbl_booking_mast.Client_code
,tbl_booking_insert.BILL_NO, tbl_booking_mast.cio_booking_id , tbl_booking_insert.Comp_Code '*/


print(@str)
exec(@str)


/////////////end of issue 7460