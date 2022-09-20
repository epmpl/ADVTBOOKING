////////////////done by shipra//////////issue no 8856/////////////////////////

ALTER TABLE PUB_CENT_MAST ADD MRV_MEMBER_CODE VARCHAR(20) 




/////////////////////////////////////////////////////////////////////////////////
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[pcminsert]    Script Date: 10/03/2012 13:39:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
@plogopath as varchar(200),
@pstate as varchar(50),
@pmrv as varchar(50)
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
      ,[CIR_FILE_PATH],[CENTER_COMP_NAME],[LOGO_FILE_PATH],[STATE],[MRV_MEMBER_CODE]) values(@compcode,@centercode,@centername, @alias,@add1,@street,@country, @state, @dist, @city, @pin,@phone1,@phone2, @fax,@email,'',getdate(),@remarks,@userid,getdate(),@region,@zone,@fax1,@boxaddress,@printval ,'',@imgpath,@cir_imgpath,@pcompanyname,@plogopath,@pstate,@pmrv)
--insert into pub_cent_mast values(@compcode,@centercode,@centername, @alias,@add1,@street,@country, @state, @dist, @city, @pin,@phone1,@phone2, @fax,@email,'','',@remarks,@userid,@region,@zone,@txtdate),@fax2


exec(@query)
print(@query)


////////////////////////////////////////////////////////////////////////




USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[pcmexe]    Script Date: 10/03/2012 14:40:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





ALTER PROCEDURE [dbo].[pcmexe]

@compcode as varchar(8),
@centcode as varchar(8),
@centname as varchar(50),
@alias as varchar(50),
@city as varchar(15),
--@userid as varchar(8),
@country as varchar(8),
@pcompname as varchar(50),
@pstate as varchar(8),
@pmrv as varchar(50)



AS


declare @query1 varchar(2000)
declare @query2 varchar(900)
declare @query3 varchar(900)
declare @querys varchar(900)
declare @query4 varchar(900)

declare @pcm1 char(12)

--delete from pcmdummy 

CREATE TABLE #pcmdummy(
	Comp_Code varchar(8)  ,
	Pub_cent_Code varchar(8)  ,
	Pub_Cent_name varchar(50)  ,
	Pub_Cent_Alias varchar(50)  ,
	Add1 varchar(50)  ,
	street varchar(50)  ,
	Country_Code varchar(8)  ,
	State_Code varchar(15)  ,
	Dist_Code varchar(15)  ,
	City_Code varchar(15)  ,
	zip	varchar(12)  ,
	Phone1	varchar(5)  ,
	Phone2	varchar(10)  ,
	Fax	varchar(15)  ,
	EmailID	varchar(50)  ,
	Pub_Cent_Status	varchar(20)  ,
	Status_date	datetime	NOT NULL ,
	Remarks	varchar(200)  ,
	UserId	varchar(8)  ,
	To_date	datetime	NULL ,
	From_date	datetime	NULL ,
	Creation_Datetime	datetime	NULL ,
	Region_code	varchar(8)  ,
	Zone_code	varchar(8)  ,
	Fax1	varchar(10)  ,
             BOXADDRESS  varchar(200) ,
PRINT_CENT varchar(20),
FILE_PATH varchar(50),
CIR_FILE_PATH varchar(50),
CENTER_COMP_NAME varchar(50),

STATE varchar(50),
MRV_MEMBER_CODE  varchar(50)
)

/*
CREATE TABLE #Pub_Cent_Mast (
	Comp_Code varchar (8) ,
	Pub_cent_Code varchar (8) ,
	Pub_Cent_name varchar (50) ,
	Pub_Cent_Alias varchar (15) ,
	Add1 varchar (50) ,
	street varchar (50) ,
	Country_Code varchar (8) ,
	State_Code varchar (15) ,
	Dist_Code varchar (15) ,
	City_Code varchar (15) ,
	zip varchar (12) ,
	Phone1 varchar (5) ,
	Phone2 varchar (10) ,
	Fax varchar (5) ,
	EmailID varchar (50) ,
	Pub_Cent_Status varchar (20) ,
	Status_date datetime ,
	Remarks varchar (200) ,
	UserId varchar (8) ,
	Creation_Datetime datetime,
	Region_code varchar (8) ,
	Zone_code varchar (8) ,
	Fax1 varchar (10) 
)
*/
--set @query1=' insert #pcmdummy select Comp_Code,Pub_cent_Code,Pub_Cent_name,Pub_Cent_Alias,Add1,street,Country_Code, State_Code,Dist_Code,City_Code,zip,Phone1,Phone2,Fax,EmailID,Pub_Cent_Status,getdate(),Remarks,UserId,getdate(),creation_datetime,region_code,zone_code,Fax1 from pub_cent_mast where comp_code='''+@compcode+'''  and userid='''+@userid+'''  '
-- set @query1=' insert #pcmdummy select Comp_Code,Pub_cent_Code,Pub_Cent_name,Pub_Cent_Alias,Add1,street,Country_Code, State_Code,Dist_Code,City_Code,zip,Phone1,Phone2,Fax,EmailID, Pub_Cent_Status,getdate(),Remarks,UserId,getdate(),getdate(),creation_datetime,region_code,zone_code,Fax1,BOXADDRESS,PRINT_CENT  from pub_cent_mast where comp_code='''+@compcode+''' '
set @query1=' insert #pcmdummy select Comp_Code,Pub_cent_Code,Pub_Cent_name,Pub_Cent_Alias,Add1,street,Country_Code, State_Code,Dist_Code,City_Code,zip,Phone1,Phone2,Fax,EmailID, 
 (select top 1 status_name from tblstatus where status_code=(SELECT top 1 cent_status FROM pcm_status where pcm_status.center_code=pub_cent_mast.pub_cent_code and getdate() between FROM_DATE and TO_DATE) )  as   Pub_Cent_Status,
getdate(),Remarks,UserId,getdate(),getdate(),creation_datetime,region_code,zone_code,Fax1,BOXADDRESS,PRINT_CENT,FILE_PATH,CIR_FILE_PATH,CENTER_COMP_NAME,STATE,MRV_MEMBER_CODE   from pub_cent_mast where comp_code='''+@compcode+''' '


if(@centcode <> '' and @centcode<>'0')
begin

set @query1= @query1 + 'and  Pub_cent_Code like ''%'+@centcode +'%'''

end

if(@centname <> '' and @centname<>'0')
begin

set @query1  =  @query1 + 'and Pub_Cent_name  like ''%'+@centname +'%'''

end

if(@alias <> '' and @alias<>'0')
begin

set @query1  =  @query1 + 'and Pub_Cent_Alias  like ''%'+@alias+'%'''

end

if(@city <>'' and @city<>'0')
begin

set @query1  =  @query1 + 'and city_code  like ''%'+@city +'%'''

end


if(@country <>'' and @country <>'0')
begin

set @query1  =  @query1 + 'and Country_Code  like ''%'+@country+'%'''

end


if(@pcompname <>'' and @pcompname <>'0')
begin

set @query1  =  @query1 + 'and CENTER_COMP_NAME  like ''%'+@pcompname+'%'''

end


if(@pstate <>'' and @pstate <>'0')
begin

set @query1  =  @query1 + 'and STATE  like ''%'+@pstate+'%'''

end



print(@query1)

exec(@query1)

print(@query4)

exec(@query4)

print(@query2)

exec(@query2)


/*declare pcm cursor read_only
for 
select pub_cent_code from #pcmdummy order by pub_cent_code
--select pub_cent_code from #Pub_Cent_Mast order by pub_cent_code


open pcm

FETCH NEXT FROM pcm
INTO @pcm1

WHILE @@FETCH_STATUS = 0
BEGIN


set @query2='update #pcmdummy set Pub_Cent_Status=(select top 1 cent_status from pcm_status where center_code='''+@pcm1+''') where PUB_cent_code='''+@pcm1+''''

set @query3='update #pcmdummy set to_date=(select top 1 to_date from pcm_status where center_code='''+@pcm1+''' order by to_date desc) where PUB_cent_code='''+@pcm1+''''

set @querys='update #pcmdummy set from_date=(select top 1 from_date from pcm_status where center_code='''+@pcm1+''' order by from_date asc) where PUB_cent_code='''+@pcm1+''''

--set @querys='update #pcmdummy set from_date=(select top 1 from_date from pcm_status where center_code='''+@pcm1+''' order by from_date asc) where PUB_cent_code='''+@pcm1+''''

print(@query2)

exec(@query2)

print(@query3)

exec(@query3)

print(@querys)

exec(@querys)


	FETCH NEXT FROM pcm
	INTO @pcm1


end

CLOSE pcm
DEALLOCATE pcm*/


select  distinct * from #pcmdummy  order by pub_cent_code
drop table #pcmdummy










//////////////////////////////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[pcmupdate]    Script Date: 10/03/2012 15:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
@plogopath as varchar(50),
@pstate AS varchar(50),
@pmrv as varchar(50)
AS

declare @query varchar(1000)
declare @query1 varchar(1000)

set @query=' update pub_cent_mast set Pub_Cent_name='''+@centername+''' , Pub_Cent_Alias='''+@alias+''' , Add1='''+@add1+''' , street='''+@street+''', Country_Code='''+@country+''', State_Code='''+@state+''', Dist_Code='''+@dist+''', City_Code='''+@city+''', zip='''+@pin+''', Phone1='''+@phone1+''', Phone2='''+@phone2+''',Fax='''+@fax+''', EmailID='''+@email+''',Remarks='''+@remarks+''',region_code='''+@region+''',zone_code='''+@zone+''',Fax1='''+@fax1+''' ,BOXADDRESS='''+@boxadd+''',PRINT_CENT='''+@printval+''',FILE_PATH='''+@imgpath+''',CIR_FILE_PATH='''+@cir_imgpath+''',CENTER_COMP_NAME='''+@pcompanyname+''',LOGO_FILE_PATH='''+@plogopath+''' ,STATE='''+@pstate+''',MRV_MEMBER_CODE ='''+@pmrv+''' where comp_code='''+@compcode+'''   and   Pub_cent_Code='''+@centercode+'''   '

--set @query1=' update pcmdummy set Pub_Cent_name='''+@centername+''' , Pub_Cent_Alias='''+@alias+''' , Add1='''+@add1+''' , street='''+@street+''', Country_Code='''+@country+''', State_Code='''+@state+''', Dist_Code='''+@dist+''', City_Code='''+@city+''', zip='''+@pin+''', Phone1='''+@phone1+''', Phone2='''+@phone2+''',Fax='''+@fax+''', EmailID='''+@email+''',Remarks='''+@remarks+''',region_code='''+@region+''',zone_code='''+@zone+''',Fax1='''+@fax1+'''  where comp_code='''+@compcode+'''    and   Pub_cent_Code='''+@centercode+'''   '


print (@query)
exec(@query)
--print(@query1)
--exec(@query1)



////////////////////////////////////////////////////////////////////////////////////




///////////done by shipra /////issue no 8855///////////////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[pubSave]    Script Date: 10/03/2012 15:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER procedure [dbo].[pubSave]

@comcode as varchar(8),
@pubcode as varchar(8),
@pubname as varchar(30),
@pubalias as char(30),
@langcode as varchar(8),
@priority as varchar(4),
@estdate as datetime,
@contperson as varchar(30),
@phone as varchar(5),
@fax as varchar(5),
@emailid as varchar(30),
@userid as varchar(8),
@pubtype as varchar(10),
@preocity as varchar(9),
@phone2 as varchar(10),
@fax2 as varchar(10),
@gutter_space as varchar(10),
@column_space as varchar(10),
@hr as varchar(10),
@mint as varchar(10),
@prod as varchar(10),
@noofcol as varchar(5),
@publish_code  as varchar(8),
@PREFIX AS VARCHAR(10),
@mrv as varchar(10)
as 

--insert into PUB_MAST(Comp_Code,Priority,Pub_Code,Pub_Name,pub_alias,Lang_Code,Establish_Date,Cont_Person,Phone,Fax,EmailID,UserId,Creation_Datetime,publication_type,preodicity,Phone1,Fax1) values(@comcode ,@priority,@pubcode,@pubname,@pubalias,@langcode,@estdate,@contperson,@phone,@fax,@emailid,@userid, getdate(),@pubtype,@preocity,@phone2,@fax2)
insert into PUB_MAST ([Comp_Code]
           ,[Priority]
           ,[Pub_Code]
           ,[Pub_Name]
           ,[pub_alias]
           ,[Lang_Code]
           ,[Establish_Date]
           ,[Cont_Person]
           ,[Phone]
           ,[Fax]
           ,[EmailID]
           ,[UserId]
           ,[Creation_Datetime]
           ,[publication_type]
           ,[preodicity]
           ,[Phone1]
           ,[Fax1]
           ,[Gutter_Space]
           ,[Column_Space]
           ,[rotimehr]
           ,[rotimemin]
           ,[production]
           ,[No_Of_collumn]
           ,[PUBLISHER_CODE],PREFIX_PUB_NAME,MRV_MEMBER_CODE 
           ) values(@comcode ,@priority,@pubcode,@pubname,@pubalias,@langcode,@estdate,@contperson,@phone,@fax,@emailid,@userid, getdate(),@pubtype,@preocity,@phone2,@fax2,@gutter_space,@column_space,@hr,@mint,@prod,@noofcol,@publish_code,@PREFIX,@mrv)

//////////////////////////////////////////////////////////

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[pubexecute]    Script Date: 10/03/2012 15:56:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER   PROCEDURE [dbo].[pubexecute]
@compcode varchar(8),
@pubcode varchar(8),
@pubname varchar(30),
@pubalias varchar(30),
@langcode varchar(8),
--@userid varchar(8),
@pubtype  varchar(10),
@preocity  varchar(50)



AS
--delete  publicationfirst 

declare @query as varchar(3000)



CREATE TABLE #Publicationfirst (
	Comp_Code varchar (8) ,
	Priority varchar (4) ,
	Pub_Code varchar (8) ,
	Pub_Name varchar (30) ,
	pub_alias varchar (30) ,
	Lang_Code varchar (8) ,
	Establish_Date datetime ,
	Cont_Person varchar (30) ,
	Phone varchar (5) ,
	Fax varchar (5) ,
	EmailID varchar (50) ,
	UserId varchar (8) ,
	Creation_Datetime datetime ,
	publication_type varchar (10) ,
	preodicity varchar (9) ,
	Phone1 varchar (10) ,
	Fax1 varchar (10) ,
	Gutter_Space varchar(10) ,
	Column_Space varchar(10),
	hr  varchar(10),
	mint  varchar(10),
	prod  varchar(10),
	No_Of_Collumn varchar(5),
    PUBLISHER_CODE  varchar(8),
prefix_pub_name varchar(10),
auto_number int,
MRV_MEMBER_CODE varchar(10)
	
)




set @query='insert into #Publicationfirst select * from PUB_MAST where Comp_Code='''+@compcode+''''-- and userid='''+@userid+'''' 

if(@pubcode <> '')
print(@pubcode)
begin
set @query= @query + 'and  pub_code like ''%'+@pubcode+'%''' 					--'''+@pubcode+''''
end

if(@pubname <> '')
print(@pubname)
begin
set @query  =  @query + 'and pub_name  like ''%'+@pubname+'%'''					--'''+@pubname+''''      -- ''%'+@pubname+'%'''
end

if(@pubalias <> '')
print(@pubalias)
begin
set @query  =  @query + 'and pub_alias  like ''%'+@pubalias+'%'''				--'''+@pubalias+''''		--''%'+@pubalias+'%'''
end

if(@langcode <>'' and @langcode <> '0')
begin
set @query  =  @query + 'and lang_code  like ''%'+@langcode+'%'''				--'''+@langcode +''''			---''%'+@pubalias+'%'''
end

if(@preocity <>'' and  @preocity <>'0')
begin
set @query  =  @query + 'and preodicity  like  ''%'+@preocity +'%''' 				--'''+@preocity +''''		-- ''%'+@preocity +'%'''
end


if(@pubtype <>'' and @pubtype <>'0')
begin
set @query  =  @query + 'and publication_type  like  ''%'+@pubtype +'%''' 				--'''+@preocity +''''		-- ''%'+@preocity +'%'''
end





print(@query)
exec(@query)



select   distinct  *,prefix_pub_name AS PREFIX  from #Publicationfirst  order by Pub_Code
--drop table #Publicationfirst

////////////////////////////////////////




USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[pub_modify]    Script Date: 10/03/2012 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[pub_modify]

@comcode varchar(8),
@pubcode varchar(8),
@pubname varchar(30),
@pubalias varchar(30),
@langcode varchar(8),
@priority varchar(4),
@estdate datetime,
@contperson varchar(30),
@phone varchar(5),
@fax varchar(5),
@emailid varchar(50),
--@userid varchar(8),
@pubtype as varchar(10),
@preocity as varchar(9),
@phone2 as varchar(10),
@fax2 as varchar(10),
@gutter_space as varchar(10),
@column_space as varchar(10),
@hr as varchar(10),
@mint as varchar(10),
@prod as varchar(10),
@noofcol as varchar(5),
@publish_code as varchar(8),
@PREFIX AS VARCHAR(10),
@mrv as varchar(20)
as 

update PUB_MAST set PREFIX_PUB_NAME=@PREFIX,pub_name=@pubname, pub_alias=@pubalias, lang_code=@langcode, priority=@priority, establish_date=@estdate, cont_person=@contperson, phone=@phone, fax=@fax, emailid=@emailid,publication_type=@pubtype,preodicity=@preocity,Phone1=@phone2,Fax1=@fax2,Gutter_Space=@gutter_space,Column_Space=@column_space, rotimehr=@hr, rotimemin=@mint, production=@prod,No_Of_Collumn=@noofcol ,publisher_code=@publish_code,MRV_MEMBER_CODE =@mrv where comp_code=@comcode /*and userid=@userid*/ and pub_code=@pubcode

--update Publicationfirst set pub_name=@pubname, pub_alias=@pubalias, lang_code=@langcode, priority=@priority, establish_date=@estdate, cont_person=@contperson, phone=@phone, fax=@fax, emailid=@emailid,publication_type=@pubtype,preodicity=@preocity,Phone1=@phone2,Fax1=@fax2,Gutter_Space=@gutter_space,Column_Space=@column_space    where comp_code=@comcode /*and userid=@userid*/ and pub_code=@pubcode



//////////////end by shipra//////////////8855//////////////////





/////issue no 8782////////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[formexec]    Script Date: 10/05/2012 12:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[formexec]
(

@compcode as VARCHAR(8),
@formcode as VARCHAR(8),
@formname as VARCHAR(100),
@formalias as VARCHAR(100),
@formtype1 as VARCHAR(10),
@modulecod as VARCHAR(15)
)
 as
    declare @query as varchar(1000) 

set @query='select * from FORMMAST where Comp_code='''+@compcode+''''
if(@formtype1 <> '0' and @formtype1 <> '')
begin
set @query=@query + 'and FORMTYPE='''+@formtype1+''''
end

if(@modulecod <> '0' and @modulecod <> '')
begin
set @query=@query + 'and MODULECODE='''+@modulecod+''''
end

if(@formcode <> '')
begin
set @query=@query + 'and Form_code=''%'+@formcode+'%'''
end

if(@formname <> '')
begin
set @query=@query + 'and Form_Name like ''%'+@formname+'%'''
end

if(@formalias <> '')
begin
set @query=@query + 'and Form_Alias=''%'+@formalias+'%'''
end
      
print(@query)
exec(@query)


//////////////////end of issue no 8782///////////////////////


///////////////////////////issue no8444 anuj (5/oct/2012)////////////////////////////

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[dateinsert]    Script Date: 10/05/2012 14:05:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

ALTER PROCEDURE [dbo].[dateinsert]



@date as varchar(10),
--@edition as varchar(8),
@noissueday as varchar(30),
@issuecode as varchar(8),
@compcode as varchar(8),
@userid as varchar(8)

AS
declare @count int
begin
select @count=count(*) from No_Iss_Grid where No_Iss_Code=@issuecode and no_issue_date=@date
if @count=0 
insert into No_Iss_Grid (  Comp_Code ,   No_Iss_Code,   no_issue_date,  No_Iss_day  ,  UserId  ) values (@compcode,@issuecode, @date,  @noissueday,  @userid )

end

/////////////////////////////////////////////////////////////////////













////////////////issue no9 8859////////////////////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[Agencyana]    Script Date: 10/08/2012 18:31:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





ALTER PROCEDURE [dbo].[Agencyana](
@fromdate as VARCHAR(20),
@dateto as VARCHAR(20),
@compcode as VARCHAR(10),
@pub_name as VARCHAR(50)=NULL,
@pub_cent as VARCHAR(50),
@dateformat as VARCHAR(20),
@descid as VARCHAR(10)=NULL,
@ascdesc as VARCHAR(10)=NULL,
@adtyp as VARCHAR(50),
@value as VARCHAR(50),
@cl as VARCHAR(50)=NULL,
@ag as VARCHAR(50)=NULL,
@place as VARCHAR(50),
@publication1 as VARCHAR(50),
@Edition1 as VARCHAR(50),
@check11 as VARCHAR(10),
@totalrows as VARCHAR(10),
@executive as varchar(50),
@puserid as varchar(8),
@chk_access as varchar(2)

)
AS
declare @query VARCHAR(8000)
declare @center  VARCHAR(50)
declare @reg VARCHAR(900)
 declare @from_date DATETIME
 declare @date_to DATETIME
 declare @sortorder VARCHAR(100)
 declare @query1 VARCHAR(1000)
 declare @status VARCHAR(50)
declare @status2 VARCHAR(50)
declare @status3 VARCHAR(50)

declare @q1 int
declare @query3 varchar(4000)

BEGIN

/*create table #tbl_agency
(
 Agency varchar(100),
 A_Place varchar(100),
 GrossAmt varchar(100),
 companyname varchar(100),
 Rundate varchar(100)
)
*/
set @q1=cast(@totalrows as int)


IF(@value=1)
begin
print(@check11)


  IF(@check11=1)
  begin
print('1')
--insert into #tbl_agency
SELECT   ad_bills.CLIENTNAME AS "Agency",
    (select cust_mast.Add1 from cust_mast where ad_bills.CLIENTCD <>  ad_bills.CLIENTNAME AND ad_bills.CLIENTCD = cust_mast.Cust_Code) AS "A_Place",
    ROUND((SUM(ad_bills_det.GROSS_AMT)),2) AS "GrossAmt",
    (SELECT dbo.initcap(Comp_Name) from comp_mst where Comp_Code=@compcode) AS "companyname",
    getdate() as "Rundate"
    FROM ad_bills,ad_bills_det,cust_mast
    WHERE
ad_bills.bildt=ad_bills_det.bildt and
ad_bills.bilno=ad_bills_det.bilno and
ad_bills.comp_code_v=@compcode and
    ad_bills.IDNUM=ad_bills_det.IDNUM
    AND ad_bills.CLIENTCD=cust_mast.Cust_Code
    AND  ad_bills.INSDATE BETWEEN @fromdate AND @dateto
    AND (ad_bills_det.AD_TYPE_V=@adtyp OR @adtyp  IS NULL)
    and ( ad_bills.REVENUE_CENTER =@pub_name OR @pub_name  IS NULL)
    AND (ad_bills_det.BKFOR=@pub_cent OR @pub_cent IS NULL)
    AND (ad_bills_det.PRIPUB=@publication1 OR @publication1 IS NULL)
    AND (ad_bills_det.EDITION=@Edition1 OR @Edition1 IS NULL)
    --AND (cust_mast.City_Code =@place OR @place  IS NULL)
and ( (@place is null) or (  ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code =@place )))
    and (ad_bills.EXECUTIVE_NAME=@executive or @executive is null)
    AND ad_bills.CLIENTCD = cust_mast.Cust_Code
    and ((ad_bills_det.BKFOR in  (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1)
    or  (@chk_access=0) )
    GROUP BY ad_bills.CLIENTNAME,cust_mast.Add1,ad_bills.CLIENTCD
     ORDER BY "GrossAmt" DESC

 --  select top cast(@totalrows as int) * from #tbl_agency 
--select  * from #tbl_agency 


end

ELSE
begin
print('2')
--insert into #tbl_agency
SELECT   AGENCY_MAST.Agency_Name AS "Agency",
    AGENCY_MAST.Add1 AS "A_Place",
    ROUND((SUM(ad_bills_det.GROSS_AMT)),2) AS "GrossAmt",
     (SELECT dbo.initcap(Comp_Name) from comp_mst where Comp_Code=@compcode) AS "companyname",
    getdate() as "Rundate"
    FROM ad_bills,ad_bills_det,AGENCY_MAST
    WHERE
ad_bills.bildt=ad_bills_det.bildt and
ad_bills.bilno=ad_bills_det.bilno and
ad_bills.comp_code_v=@compcode and
    ad_bills.IDNUM=ad_bills_det.IDNUM
    AND ad_bills.AGCODE=AGENCY_MAST.code_subcode
    AND  ad_bills.INSDATE BETWEEN @fromdate AND @dateto
    AND (ad_bills_det.AD_TYPE_V=@adtyp OR @adtyp  IS NULL)
      and ( ad_bills.REVENUE_CENTER =@pub_name OR @pub_name  IS NULL)
    AND (ad_bills_det.BKFOR=@pub_cent OR @pub_cent IS NULL)
    AND (ad_bills_det.PRIPUB=@publication1 OR @publication1 IS NULL)
    AND (ad_bills_det.EDITION=@Edition1 OR @Edition1 IS NULL)
    --AND (AGENCY_MAST.City_Code =@place OR @place  IS NULL)
and ( (@place is null) or (  ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code =@place )))
    and (ad_bills.EXECUTIVE_NAME=@executive or @executive is null)
    and ((ad_bills_det.BKFOR in  (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1)
    or  (@chk_access=0) )
    GROUP BY AGENCY_MAST.Agency_Name,AGENCY_MAST.Add1
    ORDER BY "GrossAmt" DESC

--  select top  cast(@totalrows as int)  * from #tbl_agency 
--select  * from #tbl_agency 

 END 

end



ELSE
begin




IF(@check11=1)
begin
print('3')
             --insert into #tbl_agency

  SELECT  cust_mast.Cust_Name AS "Agency",
                TBL_BOOKING_MAST.Client_address AS "A_Place",
                ROUND((SUM(TBL_BOOKING_INSERT."Gross_Rate")),2) AS "GrossAmt",
                 (SELECT dbo.initcap(Comp_Name) from comp_mst where Comp_Code=@compcode) AS "companyname",
                getdate() as "Rundate"
                FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,cust_mast
                WHERE TBL_BOOKING_MAST.Comp_code=@compcode
                AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
                AND TBL_BOOKING_MAST.Client_code=cust_mast.Cust_Code
                AND  Insert_Date BETWEEN @fromdate AND @dateto
                AND (TBL_BOOKING_MAST.Ad_type_code=@adtyp OR @adtyp  IS NULL)
                AND ( TBL_BOOKING_MAST.Revenue_center=@pub_name OR @pub_name  IS NULL)
                AND (TBL_BOOKING_INSERT.Pub_Cent_Code=@pub_cent OR @pub_cent IS NULL)
                AND (TBL_BOOKING_INSERT.Publication_Code=@publication1 OR @publication1 IS NULL)
                AND (TBL_BOOKING_INSERT.Edition_Code=@Edition1 OR @Edition1 IS NULL)
               -- AND (cust_mast.City_Code =@place OR @place  IS NULL)
and (( @place is null) or (tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code =@place) ))

               AND (TBL_BOOKING_MAST.Executive_code =@executive or @executive is null)
                AND TBL_BOOKING_MAST.cio_booking_id not in(select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)
                and  lower(Insert_Status) !='cancel'
               and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1)
               or  (@chk_access=0) )
                GROUP BY cust_mast.Cust_Name,Client_address
                ORDER BY "GrossAmt" DESC
            
 
                --select top cast(@totalrows as int) * from #tbl_agency 
--select  * from #tbl_agency 


end

ELSE
begin

print('4')
--insert into #tbl_agency

                SELECT  AGENCY_MAST.Agency_Name AS "Agency",
                TBL_BOOKING_MAST.Agency_address AS "A_Place",
                ROUND((SUM(TBL_BOOKING_INSERT.Gross_Rate)),2) AS "GrossAmt",
                 (SELECT dbo.initcap(Comp_Name) from comp_mst where Comp_Code=@compcode) AS "companyname",
                getdate() as "Rundate"
                FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST
                WHERE TBL_BOOKING_MAST.Comp_code=@compcode
                AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
                AND TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode
                AND  Insert_Date BETWEEN @fromdate AND @dateto
                AND (TBL_BOOKING_MAST.Ad_type_code=@adtyp OR @adtyp  IS NULL)
                AND ( TBL_BOOKING_MAST.Revenue_center=@pub_name OR @pub_name  IS NULL)
                AND (TBL_BOOKING_INSERT.Pub_Cent_Code=@pub_cent OR @pub_cent IS NULL)
                AND (TBL_BOOKING_INSERT.Publication_Code=@publication1 OR @publication1 IS NULL)
                AND (TBL_BOOKING_INSERT.Edition_Code=@Edition1 OR @Edition1 IS NULL)
                --AND (AGENCY_MAST.City_Code =@place OR @place  IS NULL)
and (( @place is null) or (tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code =@place) ))
 AND (TBL_BOOKING_MAST.Executive_code =@executive or @executive is null)
                AND TBL_BOOKING_MAST.cio_booking_id not in(select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)
                and  lower(Insert_Status) !='cancel'
               and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1)
               or  (@chk_access=0) )
                GROUP BY AGENCY_MAST.Agency_Name,Agency_address
                ORDER BY "GrossAmt" DESC

               
              -- select top cast(@totalrows as int) * from #tbl_agency 
 --select  * from #tbl_agency 


        

                                      



END 

END 

END 














////////////////////end of issue no 8859/////









/////////////////issue no 8782(again)/////////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[formexec]    Script Date: 10/09/2012 15:00:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[formexec]
(

@compcode as VARCHAR(8),
@formcode as VARCHAR(8),
@formname as VARCHAR(100),
@formalias as VARCHAR(100),
@formtype1 as VARCHAR(10),
@modulecod as VARCHAR(15)
)
 as
    declare @query as varchar(1000) 

set @query='select * from FORMMAST where Comp_code='''+@compcode+''''
if(@formtype1 <> '0' and @formtype1 <> '')
begin
set @query=@query + 'and FORMTYPE='''+@formtype1+''''
end

if(@modulecod <> '0' and @modulecod <> '')
begin
set @query=@query + 'and MODULECODE='''+@modulecod+''''
end

if(@formcode <> '')
begin
set @query=@query + 'and Form_code like''%'+@formcode+'%'''
end

if(@formname <> '')
begin
set @query=@query + 'and Form_Name like ''%'+@formname+'%'''
end

if(@formalias <> '')
begin
set @query=@query + 'and Form_Alias=''%'+@formalias+'%'''
end
      
print(@query)
exec(@query)


///////////////////////end of issue no 8782////////////


/*********************issue no 8736 update by Hitesh ******************/

ALTER PROCEDURE [dbo].[autoagtypecode1]

@str as varchar(30),
@cod as varchar(2),
@adcattype as varchar(200)
as

declare @query as  varchar(1000)

declare @query1 as  varchar(1000)
set @query='select * from ad_charge_mast where charge_name= '''+@str+'''  and ad_type= '''+@adcattype+'''   '

--set @query1='select MAX(cast(dbo.translate(Charge_Code,''ABCDEFGHIJKLMNOPQRSTUVWXYZ@#$%^&*()!>~<?/_+|=-'',0) as int )),0 as Charge_Code from ad_charge_mast 
--where  Charge_Code like '''+@cod+'%'''
set @query1='select ISNULL(MAX(CONVERT(NUMERIC(8), SUBSTRING(Charge_Code, 3, LEN(Charge_Code)))), 0) + 1 as "CHARGE_CODE" from ad_charge_mast 
where  Charge_Code like '''+@cod+'%'''

--ISNULL(MAX(CONVERT(NUMERIC(8), SUBSTRING(CI_ID, 3, LEN(ci_id)))), 0) + 1
--select * from ad_charge_mast
print(@query)

print(@query)
exec(@query)

print(@query)

print(@query1)
exec(@query1)









/************************************************************************/


/*********************************issue no(8945)***************************************/


create table RESULT (SEGMENTNUM numeric(10,0),EDITION_NAME varchar(5000))





/*****************************************************************************************/

//////////////////**************************** issue no(8894) *********************************///////////////////////


ALTER procedure [dbo].[login_user_report] 
@pcomp_code      as  varchar(200),
@pbranch         as  varchar(200),
@pusername       as  varchar(200),
@proleid         as  varchar(200),
@pstatus         as  varchar(200),
@pdateformat     as  varchar(200),
@pextra1         as  varchar(200),
@pextra2         as  varchar(200),
@pextra3         as  varchar(200),
@pextra4         as  varchar(200),
@pextra5         as  varchar(200) as
Begin

     select "userid" userid,"username" username,firstname, lastname,
    "Agency_code",(select "Agency_Name" from agency_mast where "code_subcode"=login."Agency_code") agency_name,
    "retainer_code" branch,(select "Branch_Name" from branch_mst where "Branch_Code"=login."retainer_code") branch_name, 
    (select "Comp_Name" from comp_mst where "Comp_Code"=login.com_code) comp_name,email, discount,roleid,null as rolename,  
    case when "Admin"='Yes' then 'ADMIN' else 'USER' end login_type,  case when filter='D' then 'District Wise' 
    when filter='P' then 'Publ Center Wise' else 'All' end filter_type, 
    booking_editlines,  case when status='A' then 'Active' else 'Inactive' end status,  
    hr_code,(select distinct MAX(name) from hr_emp_mst where hr_code=login.hr_code),
    acc_code,(select MAX(acc_name) from fa_acc_mast where comp_code=login.com_code and cdp=login.acc_code) acc_name,
    null as branch_permission 
    from login where ("username"=@pusername or @pusername='' or @pusername IS NULL) 
    and ("retainer_code"=isnull(@pbranch,"retainer_code") or @pbranch='') 
    and (roleid=isnull(@proleid,roleid) or @proleid='') 
    and (status=isnull(@pstatus,status) or @pstatus='') 
    order by username;
    
End

//////////////////**************************** End issue no(8894) *********************************/////////////////////// 


///////////////////****************issue no (8946)Anuj 12/oct/2012***************************************////////////////////////////////////

ALTER PROCEDURE [dbo].[followup]
   @pcompcode      as	varchar(20),
   @pagency        as	varchar(2000),
   @pclient        as	varchar(2000),
   @pdatefrom      as	datetime,
   @pdateto        as	datetime,
   @pdateformate   as	varchar(20),
   @pextra1        as	varchar(200),
   @pextra2        as	varchar(200),
   @pextra3        as	varchar(200)
AS

BEGIN
      SELECT DISTINCT a."cio_booking_id" AS ID,
                      b."Agency_Name" AS AGENCYNAME, b."EmailID" AS mail,
                      isnull ((SELECT "Cust_Name" FROM cust_mast WHERE "Comp_Code" = a."Comp_code"
                               AND "Cust_Code" = a."Client_code"),a."Client_code") AS clientname,
                      (SELECT "EmailID" FROM cust_mast WHERE "Comp_Code" = a."Comp_code" AND 
                      "Cust_Code" = a."Client_code") AS client,d."Package_Name" AS packagename,
                      f."Page_No" AS page_no,a."No_of_insertion" AS insertion, a."RO_No" AS rono,
                          CASE @pdateformate WHEN 'mm/dd/yyyy' THEN CONVERT(varchar(20),a."RO_Date",101)
							WHEN 'dd/mm/yyyy' THEN CONVERT(varchar(20),a."RO_Date",103)
							WHEN 'yyyy/mm/dd' THEN CONVERT(varchar(20),a."RO_Date",111)  END AS rodate ,
                      CASE WHEN CHARINDEX (',',a."Package_code") > 0
                            THEN dbo.fetch_pack_new (@pcompcode, a."Package_code")
                         ELSE (SELECT DISTINCT MIN ("Combin_Desc") FROM combin_mast 
                         WHERE "Combin_Code" =a."Package_code") END AS "EDITIONNAME",
                      g."Comp_Name" AS comp_name,
                      (SELECT "EMAILID" FROM exec_mast WHERE "comp_code" = a."Comp_code" AND 
						cast ("Exe_no" as varchar(50)) = a."Executive_code") AS "EXEC_EMAILID"
                 FROM tbl_booking_mast a,agency_mast b,combin_mast d,
                      edition_mast e,tbl_booking_insert f,comp_mst g
                WHERE a."Comp_code" = g."Comp_Code"
                  AND a."Comp_code" = @pcompcode
                  AND f."Cio_Booking_Id" = a."cio_booking_id"
                  AND (a."date_time" BETWEEN @pdatefrom AND @pdateto)
                  AND (f."Insert_Date" IS NULL OR f."Insert_Date" = '')
                  AND "Insert_Status" != 'cancel'
                  AND a."Agency_sub_code" = b."code_subcode"
                  AND a."Package_code" = d."Combin_Code"
                  AND f."Edition_Code" = e."Edition_Code"
                  AND a."Agency_sub_code" = isnull (@pagency, a."Agency_sub_code")
                  AND a."cio_booking_id" = isnull (@pextra1, a."cio_booking_id")
                  AND a."Client_code" = isnull (@pclient, a."Client_code");
END



/////////////////////////////********************************************/////////////////////////////////



//////////////**************issue (8913)(Anuj) 12/oct/2012****************////////////////////////////////////////////


ALTER procedure [dbo].[bind10agencyforbooking]
    @compcode    as varchar(20),
    @userid      as varchar(50),
    @agency      as varchar(200),
    @pubcenter   as varchar(200)
as
declare @v_filter    varchar(20)
declare @v_pcenter   varchar(50)
declare @f2record int
Begin

    select distinct @v_filter=filter from login where "userid"=@userid
    select @f2record=isnull(f2_record,10) from preferrences where comp_code=@compcode
   
    If @v_filter='D' Begin--for district wise
        set @v_pcenter=@pubcenter
	End        
    Else if @v_filter='P' Begin--for Printing center wise
        set @v_pcenter=@pubcenter
    End
    Else Begin--for all
        set @v_pcenter='0'
    End

    if @v_pcenter = '0' or @v_pcenter is null or @v_pcenter='' Begin
        select  distinct top  (@f2record)   "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=@compcode and "City_Code"=agency_mast."City_Code")+'-'+"Add1"+'-'+"Add2"+'-'+"Add3"+"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=@compcode and
        isnull((SELECT top 1 status_name FROM STATUS_DETAIL WHERE "agency_code" + "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND GETDATE() between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name") like '%'+UPPER(@agency)+'%'   order by "Agency_Name" ;
    End
    Else Begin
        select  distinct top (@f2record) x."code_subcode" as "code_subcode",x."agency_name" as "agency_name",x.CITYNAME AS CITYNAME from
        (select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=@compcode and "City_Code"=agency_mast."City_Code")+'-'+"Add1"+'-'+"Add2"+'-'+"Add3"+"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=@compcode and
        isnull((SELECT top 1 status_name FROM STATUS_DETAIL WHERE "agency_code" + "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND GETDATE() between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name") like '%'+UPPER(@agency)+'%' and exists (select 'x' from branch_mst where "Branch_Code"=@pubcenter and "Dist_Code"=agency_mast."Dist_Code") and @v_filter='D' 
        union
        select  distinct top 10  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=@compcode and "City_Code"=agency_mast."City_Code")+'-'+"Add1"+'-'+"Add2"+'-'+"Add3"+"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=@compcode and
        isnull((SELECT top 1 status_name FROM STATUS_DETAIL WHERE "agency_code" + "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND GETDATE() between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name") like '%'+UPPER(@agency)+'%' and exists (select 'x' from branch_mst 
        where "Branch_Code"=agency_mast."Branch_code" and "pub_center"=@v_pcenter) and @v_filter='P') x
        order by "agency_name" ;
    end
end

















//////////////////////////////////*************************/////////////////////////////////////////

//////done by shipra/////// issue no 8692//////////////////////////////////


CREATE  PROCEDURE chkpubcatname
(
 @compcode1 as VARCHAR(100), 
 @pubname as VARCHAR(100), 
  @catname1 as VARCHAR(100), 
 @subcatname as VARCHAR(100),
 @refname as VARCHAR(100)
 --p_Accounts OUT Cur_Type_New1.cursor_type
)
AS
BEGIN
--open  p_Accounts for
select * from pub_catname_ref where "COMPCODE"=@compcode1 and "PUBLICATION"=@pubname and "CAT1"=@catname1 and "CAT2"=@subcatname; --and "CATNAME"=refname;
END 










////////////////////////////////




CREATE  PROCEDURE savepubcatref
(
 @compcode1 AS VARCHAR(100),
 @pubname AS VARCHAR(100),
  @catname1 AS VARCHAR(100),
 @subcatname AS VARCHAR(100),
 @refname AS VARCHAR(100)

)
AS
BEGIN

insert into pub_catname_ref (COMPCODE, PUBLICATION, CAT1, CAT2, CAT3, CAT4, CAT5, CATNAME)
values(@compcode1,@pubname,@catname1,@subcatname,'','','',@refname);

END 



///////////////////////





CREATE PROCEDURE exepubcatref
(

  @compcode1 AS VARCHAR(100),
 @pubname AS VARCHAR(100),
  @catname1 AS VARCHAR(100),
 @subcatname AS VARCHAR(100),
 @refname AS VARCHAR(100)

)
AS
BEGIN
--open  p_Accounts for
select * from pub_catname_ref where COMPCODE=@compcode1
 and (PUBLICATION=@pubname or @pubname ='0' or @pubname is null )
 and (CAT1=@catname1 or @catname1 ='0' or @catname1 is null  )
  and (CAT2=@subcatname or @subcatname ='0' or @subcatname is null )
   and (CATNAME=@refname  or @refname is null );

END 




/////////////////////





CREATE  PROCEDURE delpubcatref
(

 
 
   @compcode1 AS VARCHAR(100),
 @pubname AS VARCHAR(100),
  @catname1 AS VARCHAR(100),
 @subcatname AS VARCHAR(100)

 
)
AS
BEGIN

delete from pub_catname_ref where COMPCODE=@compcode1 and PUBLICATION=@pubname and CAT1=@catname1 and CAT2=@subcatname;

END 
///////////////////////



CREATE  PROCEDURE updatepubcatref
(
 
 
 
   @compcode1 AS VARCHAR(100),
 @pubname AS VARCHAR(100),
  @catname1 AS VARCHAR(100),
 @subcatname AS VARCHAR(100),
 @refname AS VARCHAR(100)
)
AS
BEGIN

update pub_catname_ref set CATNAME=@refname  where COMPCODE=@compcode1 and PUBLICATION=@pubname and CAT1=@catname1 and CAT2=@subcatname;

END 











/////////////end by shipra /////// issue no 8692///////////////////









/////////start by shipra /////////issue no8693///////////////////////////


CREATE  PROCEDURE ADCAPTION_INS_UPD_DEL 

   ( 
   @PCOMP_CODE    AS VARCHAR(100),
    @PADTYPE_CODE   AS VARCHAR(100),
    @PCAPTION       AS VARCHAR(100),
   @PUSERID        AS VARCHAR(100),
    @PTRN_TYPE      AS VARCHAR(100), --'I' For Insert, 'U' For Update, 'D' For Delete & 'E' For Execute
    @PCAPTION_CODE AS VARCHAR(100), 
    @PEXTRA1        AS VARCHAR(100), 
    @PEXTRA2        AS  VARCHAR(100), 
    @PEXTRA3        AS VARCHAR(100), 
    @PEXTRA4        AS VARCHAR(100)
    ) 
AS

DECLARE @vno           NUMERIC (8);
BEGIN
  IF ISNULL(@PTRN_TYPE,'?')='I'BEGIN
  
    
     SELECT @vno=MAX ([dbo].[fa_get_number_only] (CAPTION_CODE)) + 1   FROM CAPTION_MAST  WHERE COMP_CODE = @PCOMP_CODE;
     IF ISNULL(@vno,0) = 0 
    BEGIN
     SET   @vno =1;
     END 
     INSERT INTO CAPTION_MAST   (COMP_CODE,AD_TYPE, CAPTION_CODE, CAPTION_NAME, USERID, CREATION_DATETIME)
                         VALUES (@PCOMP_CODE,@PADTYPE_CODE,@vno,@PCAPTION,@PUSERID ,GETDATE());
  END 
  IF ISNULL(@PTRN_TYPE,'?')='U'BEGIN
    UPDATE CAPTION_MAST  SET AD_TYPE=@PADTYPE_CODE, CAPTION_NAME=@PCAPTION WHERE  CAPTION_CODE=@PCAPTION_CODE AND COMP_CODE=@PCOMP_CODE;
                   
  END 
  IF ISNULL(@PTRN_TYPE,'?')='D'BEGIN
     DELETE FROM CAPTION_MAST
        WHERE  COMP_CODE = @PCOMP_CODE
           AND CAPTION_CODE = @PCAPTION_CODE;

  END 
END





//////////////////////





CREATE  PROCEDURE AD_CAPTION_EXEC
(
  @PCOMP_CODE    AS       VARCHAR(100) ,
  @PAD_TYPE     AS        VARCHAR(100),
  @PCAPTION_CODE    AS    VARCHAR(100),
  @PCAPTION_NAME    AS    VARCHAR(100),
  @PUSERID           AS   VARCHAR(100)
 -- P_ACCOUNTS          OUT Cur_Type_New1.cursor_type
)
AS
BEGIN
 --OPEN P_ACCOUNTS FOR
 SELECT AD_TYPE, CAPTION_CODE, CAPTION_NAME, USERID FROM CAPTION_MAST 
 WHERE (COMP_CODE= @PCOMP_CODE  OR @PCAPTION_CODE IS NULL)
 AND (CAPTION_CODE =@PCAPTION_CODE OR @PCAPTION_CODE IS NULL)
 AND ((CAPTION_NAME like ''+@PCAPTION_NAME+'%') OR (@PCAPTION_NAME IS NULL))
 AND ((AD_TYPE  like ''+@PAD_TYPE+'%') OR (@PAD_TYPE IS NULL));

END


///////////end by shipra//////issue no 8693/////////////////////



 ////////////////////*********anuj 16/oct/2012(issue 9011)************/////////////////////////
 
 
 USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[binndratecode]    Script Date: 10/16/2012 15:17:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER  PROCEDURE [dbo].[binndratecode]
   
   @p_compcode    as       VARCHAR(10),
   @p_ratecode   as       VARCHAR(50)
   
as


      SELECT distinct "RATE_DESC" as "Rate_Mast_Code"
        FROM rate_code_mast
       WHERE "COMP_CODE" = @p_compcode
       AND "STATUS" = 'AC0'
         AND "RATE_DESC" LIKE @p_ratecode + '%'order by RATE_DESC;
         
         --------------------------------------
         
         
         
         
         USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[getData_Export]    Script Date: 10/16/2012 15:33:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[getData_Export]
   @adtype_p		as VARCHAR(200),
   @fromdate_p		as datetime,
   @todate_p		as datetime,
   @p_solo			as VARCHAR(200),
   @p_ratecode		as VARCHAR(200),
   @p_pubcent		as VARCHAR(200),
   @pedtn_flag		as	VARCHAR(10),--M for Main,E for Edition ,S for Suppliment and A for All
   @p_packagecode   as  VARCHAR(2000),
   @padcatg         as  VARCHAR(2000),
   @puom_code       as  VARCHAR(2000),
   @pextra1         as  VARCHAR(2000),
   @pextra2         as  VARCHAR(2000),
   @pextra3         as  VARCHAR(2000),
   @pextra4         as  VARCHAR(2000),
   @pextra5         as  VARCHAR(2000)
   
AS
declare @v_gr int
BEGIN
create table #Results(SegmentNum INT, Edition_Name  VARCHAR(255))
create table #Results1(SegmentNum INT, Edition_Name  VARCHAR(255))
	if @p_packagecode is not null or @p_packagecode<>'' begin
	insert into #Results select * from dbo.fn_SplitField(@p_packagecode,',')
		--set @v_gr=dbo.fn_SplitField(@p_packagecode,',')
	end
		
	if @padcatg is not null or @padcatg<>'' begin
	insert into #Results1 select * from dbo.fn_SplitField1(@padcatg,',')
		--set @v_gr=dbo.fn_SplitField1(@padcatg,',')
	end	

IF isnull (@p_solo, '') = 'S' begin
print('dgdfg')
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
	r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",convert(varchar(20),r."Valid_From",101) AS valid_from,convert(varchar(20),r."Valid_To",101) AS valid_to, 
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
	WHERE "Adv_Type_Code" = @adtype_p  AND "Valid_From" >= @fromdate_p AND "Valid_To" <= @todate_p AND charindex ('+',"combin_desc") <= 0 
	and r."Rate_Mast_Code"=isnull(@p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=@p_pubcent or @p_pubcent is null) and 
	exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=r."combin_desc" and 
	(("Edition_Type"='Main Edition' and @pedtn_flag='M') or ("Edition_Type"='Edition' and @pedtn_flag='E')))
	and (r."Combin_Code" in(select edition_name from #results) or @p_packagecode is null or @p_packagecode='')
	and (r."Adv_Cat_Code" in(select edition_name from #results1) or @padcatg is null or @padcatg='')
	and (r."Uom"=@puom_code or @puom_code is null or @puom_code='')
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
	r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,r.position_prem,
	'' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
	--,'' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
	FROM rate_mast r
	WHERE "Adv_Type_Code" = @adtype_p  AND "Valid_From" >= @fromdate_p AND "Valid_To" <= @todate_p AND charindex ('+',"combin_desc") <= 0
	and r."Rate_Mast_Code"=isnull(@p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=@p_pubcent or @p_pubcent is null) and 
	exists(select 'x' from supplement_mast where supplement_mast."Supp_Alias"=r."combin_desc" and @pedtn_flag='S')
	and (r."Combin_Code" in(select edition_name from #results) or @p_packagecode is null or @p_packagecode='')
	and (r."Adv_Cat_Code" in(select edition_name from #results1) or @padcatg is null or @padcatg='')
	and (r."Uom"=@puom_code or @puom_code is null or @puom_code='')
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
	r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,r.position_prem,
	'' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
	--,'' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
	FROM rate_mast r
	WHERE r."Adv_Type_Code" = @adtype_p  AND r."Valid_From" >= @fromdate_p AND r."Valid_To" <= @todate_p AND charindex ('+',"combin_desc") <= 0
	and r."Rate_Mast_Code"=isnull(@p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=@p_pubcent or @p_pubcent is null) and @pedtn_flag='A'
	and (r."Combin_Code" in(select edition_name from #results) or @p_packagecode is null or @p_packagecode='')
	and (r."Adv_Cat_Code" in(select edition_name from #results1) or @padcatg is null or @padcatg='')
	and (r."Uom"=@puom_code or @puom_code is null or @puom_code='')) x
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
	r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,r.position_prem,
	'' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
	--, '' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
	FROM rate_mast r
	WHERE "Adv_Type_Code" = @adtype_p
	AND "Valid_From" >= @fromdate_p
	AND "Valid_To" <= @todate_p
	AND charindex ('+',"combin_desc") > 0
	and r."Rate_Mast_Code"=isnull(@p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=@p_pubcent or @p_pubcent is null)
	and (r."Combin_Code" in(select edition_name from #results) or @p_packagecode is null or @p_packagecode='')
	and (r."Adv_Cat_Code" in(select edition_name from #results1) or @padcatg is null or @padcatg='')
	and (r."Uom"=@puom_code or @puom_code is null or @puom_code='')	
	ORDER BY r."rateuniqueid";
END

END

         
         
         
        
/////////////////////////////****************/////////////////////////////
/////////////////***********hitesh (issue no8834)***********////////////
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[ctr_advance_search]    Script Date: 10/16/2012 12:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ctr_advance_search]
	@compcode                                 VARCHAR(50) ,
	@agname                                   VARCHAR(100) ,
	@clientname                               VARCHAR(100) ,
	@username                                 VARCHAR(100) ,
	@fromdate                                 VARCHAR(25) ,
	@dateto                                   VARCHAR(25) ,
	@sheldate                                 VARCHAR(25) ,
	@insertntodate1                           VARCHAR(25) ,
	@adtext                                   VARCHAR(400) ,
	@rostatus                                 VARCHAR(25) ,
	@clientcode                               VARCHAR(20)
AS 
	BEGIN
		SET NOCOUNT ON
		
		-- Oracle To SQL Server Edition : The precision of '@query1' is changed from 10000 to the maximum prcession in SQLServer is 8000
		DECLARE @query1                                   VARCHAR(8000) 
		set @query1  = 'select TBL_BOOKING_MAST.cio_booking_id,(select Agency_Name from agency_mast where code_subcode=TBL_BOOKING_MAST.Agency_sub_code) as "Agency",  (select isnull(Cust_Name,TBL_BOOKING_MAST.Client_code) from CUST_MAST where Cust_Code=TBL_BOOKING_MAST.Client_code) as "Client", case(ro_status)      when ''1'' then ''confirm''      when ''2'' then ''unconfirm''  end as "RoStatus"  ,TBL_BOOKING_MAST.Total_area as "Area/Lines",  (select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code)as "AdCategory",  (select col_mast.Col_Name from col_mast where tbl_booking_mast.Color_code=col_mast.Col_Code )  as "color",  (select uom_mast.Uom_Name from uom_mast where uom_mast.Uom_Code=TBL_BOOKING_MAST.Uom_code  )  as "UOM",TBL_BOOKING_MAST.Gross_amount as "GrossAmount",Receipt_no,Client_address  from TBL_BOOKING_MAST where TBL_BOOKING_MAST.Comp_code=''' + @compcode + '''' 

		IF ( @agname <> '' ) 
		BEGIN 
			set @query1  = @query1 + '  and (TBL_BOOKING_MAST.Agency_sub_code =''' + @agname + '''          or TBL_BOOKING_MAST.Agency_sub_code=(select code_subcode from agency_mast where Agency_Name=''' + @agname + '''))' 
		END
  
		IF ( @clientname <> '' ) 
		BEGIN 
			IF ( @clientcode !='') 
			BEGIN 
				set @query1  = @query1 + ' and TBL_BOOKING_MAST.Client_code =''' + @clientcode + '''' 
			END
			ELSE
			BEGIN 
				--query1:=query1 ||' and TBL_BOOKING_MAST.Client_code ='''||clientname ||'''';
				
				set @query1  = @query1 + ' and TBL_BOOKING_MAST.Client_code =''' + @clientname + '''    or TBL_BOOKING_MAST.Client_code = (select Cust_Name from cust_mast where Cust_Code=''' + @clientname + ''')    or TBL_BOOKING_MAST.Client_code in (select Cust_Code from cust_mast where Cust_Name=''' + @clientname + ''')' 
			END
   
		END
   
		IF ( @username <> '' ) 
		BEGIN 
			set @query1  = @query1 + ' and TBL_BOOKING_MAST.Userid =''' + @username + '''            or TBL_BOOKING_MAST.Userid = (select userid from login where username=''' + @username + ''')' 
		END
   
		IF ( @fromdate <> '' ) 
		BEGIN 
			set @query1  = @query1 + ' and  convert(varchar(10),Creation_datetime,101) >=''' + @fromdate + ''' and  convert(varchar(10),Creation_datetime,101) <= ''' + @dateto + '''' 
		END
   
		IF ( @sheldate <> '' ) 
		BEGIN 
			set @query1  = @query1 + '  and convert(varchar(10),Insertion_date,101) between  ''' + @sheldate + '''  and  ''' + @insertntodate1 + '''' 
		END
   
		IF ( @rostatus <> '' and @rostatus <> '0' ) 
		BEGIN 
			set @query1  = @query1 + ' and tbl_booking_mast.ro_status=''' + @rostatus + '''' 
		END
   
		IF ( @adtext <> '' ) 
		BEGIN 
			set @query1  = @query1 + '  AND TBL_BOOKING_MAST.cio_booking_id IN (SELECT cioid FROM TBL_MATTER WHERE matter like ''%' + @adtext + '%'')' 
		END
    print @query1
		EXEC(@query1) 

		SET NOCOUNT OFF

	END



////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


///////


\\\\\\\**********issue no 8869************done by shipra/////////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[Reportnew1_agency_stmt]    Script Date: 10/17/2012 15:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Reportnew1_agency_stmt]
(
    @agname          as  VARCHAR(500)=NULL,
    @clientname     as  VARCHAR(500)=NULL,
    @adtype1         as  VARCHAR(50),
   @Adcategory       as VARCHAR(500),
    @fromdate        as  VARCHAR(20),
    @dateto          as  VARCHAR(20),
    @compcode        as  VARCHAR(10),
    @pub_name        as  VARCHAR(200),
    @pub_cent        as VARCHAR(200),
    @status          as  VARCHAR(50)=NULL,
    @edition         as  VARCHAR(100),
    @dateformat      as  VARCHAR(20),
    @hold            as  VARCHAR(20)=NULL,
    @descid          as  VARCHAR(20)=NULL,
    @ascdesc         as  VARCHAR(20)=NULL,
    @agtype          as  varchar(20)=null,
    @puserid         as  varchar(10)=null,
    @chk_access      as  varchar(2)=null,
    @pextra1        as varchar(200)=null,--for UOM
    @pextra2        as  varchar(200)=null,
    @pextra3         as varchar(200)=null,
    @pextra4         as  varchar(200)=null,
    @pextra5         as  varchar(200)=null
   --p_reportnew     OUT Cur_Type_New1.cursor_type
   )
--IS
as

declare @center      VARCHAR(50)
declare @from_date   DATE
declare @date_to     DATE
declare @v_query     VARCHAR(8000)
--a           number;
declare @a          numeric(18,0)
BEGIN
  set  @v_query =' SELECT m."Comp_code" as "COMP_CODE", (SELECT dbo.initcap("Comp_Name") from comp_mst where "Comp_Code"=m."Comp_code") AS "companyname", 
    m."cio_booking_id" AS "CIOID",
   
   
    CASE '''+@dateformat+'''WHEN ''mm/dd/yyyy'' THEN convert(varchar(10),min(i."Insert_Date"),101)
    WHEN ''dd/mm/yyyy'' THEN convert(varchar(10),min(i."Insert_Date"),103)
    WHEN ''yyyy/mm/dd'' THEN  convert(varchar(10),min(i."Insert_Date"),111)end as tdate,
    

    
    a."Agency_Name" AS "AGENCY_NAME",(select "City_Name" from city_mst where "City_Code"=a."City_Code") as "AGENCY_CITY",a."Add1" as "ADD1",a."Add2" as "ADD2",a."Add3" as "ADD3",
    isnull((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "CLIENT_NAME",
    case when charindex (m."Package_code",'','') >0 then 
        dbo.FETCH_PACK_new(m."Comp_code", m."Package_code" ) 
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
    m."Card_rate" AS "CardRate",isnull("Agrred_rate",0) AS "AgreedRate",round(sum(i."Bill_Amt"),2) AS "Amt",
    m."Caption" AS "Cap",m."Key_no" AS "Key",

    getdate() as "Rundate",m.CASHDISCOUNT as "Cash_Disc", m."AUDIT_COMMENT" as "COMMENT",m."Dockit_no" as "DOCKIT_NO",
    i."No_Insert" as "No_Insert",
    case isnull(m."Agrred_rate",0) when 0 then m."Card_rate" else m."Agrred_rate"  end as "package rate",
    m."Special_discount" "Special_discount", m."Special_charges" "Special_charges", m."Trade_disc" "Trade_disc",
    (SELECT "premium_charges" FROM ADVPOS_PREM_MAST  WHERE   ADVPOS_PREM_MAST. "Premiumcode"=i."Premium1") AS "premiumch",
    sum(i."Card_Rate") "Card_Rate",m."Print_remark" as "Print_remark",i.bill_no as "BILL_NO",i.bill_date as "BILL_DATE"
    FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a,uom_mast u
    WHERE m."Comp_code"='''+@compcode+'''
    AND m."cio_booking_id"=i."Cio_Booking_Id"
    and m."Agency_sub_code"=a."code_subcode" and m."Uom_code"=u."Uom_Code"
    AND not exists(select ''x'' from tbl_booking_mast where "prev_cioid"=m."cio_booking_id" and "prev_cioid" is not null)
    and  lower(i."Insert_Status") !=''cancel''
    and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where  newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
    or  ('''+@chk_access+'''=''0'') )';



IF(@agname IS NOT NULL) begin
  set  @v_query=@v_query+' and m."Agency_code" ='''+@agname+'''';
  
  --set @query=@query+' and m.Agency_code ='''+@agname+''''
  
END

IF(@clientname IS NOT NULL) begin
  set  @v_query=@v_query+' and m."Client_code"='''+@clientname+'''';
END 

IF(@status IS NOT NULL) begin
   set @v_query=@v_query+' and i."Insert_Status"='''+@status+'''';
END 

IF(@adtype1 IS NOT NULL) begin
   set  @v_query=@v_query+' and m."Ad_type_code"='''+@adtype1+'''';
END 

IF(@Adcategory  IS NOT NULL)
 begin
   set @a=dbo.Fn_Splitfield(@Adcategory ,',');
 
  set  @v_query=@v_query+' and i."Ad_Cat" in(select "EDITION_NAME" from result  )';
END 


    IF(@fromdate IS NOT NULL AND @dateto IS NULL ) begin
  set      @v_query=@v_query+' and i."Insert_Date" ='''+@fromdate+'''';
    END 

    IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL ) begin
      set  @v_query=@v_query+' and i."Insert_Date" between  '''+@fromdate+''' and  '''+@dateto+''' ';
    END

IF(@edition IS NOT NULL) begin
   set @v_query=@v_query+'  and i."Edition_Code"='''+@edition+'''';
END 

IF(@pextra1 IS NOT NULL) begin
  set  @v_query=@v_query+'  and m."Uom_code"='''+@pextra1+'''';
END 

IF(@pub_name IS NOT NULL) begin
   set @v_query=@v_query+' and  i."Publication_Code"='''+@pub_name+'''';
END 

IF((@agtype IS NOT NULL) AND (@agtype <> 'Package') AND (@agtype <> 'Solo')) begin
  set  @v_query=@v_query+' and  m."Agency_type"='''+upper(@agtype)+'''';
END 


set @v_query=@v_query+' group by m."Comp_code", m."cio_booking_id",a."Agency_Name",a."City_Code",
    m."Client_code",m."Package_code",i."Height",i."Width",u.UOM_DESC,i."Col_Code",i."Page_Post",
    m."Bullet_code",i."Premium1",m."RO_No",i."Ad_Cat",m."Card_rate",m."Agrred_rate",m."Caption",m."Key_no",
    m.CASHDISCOUNT, m."AUDIT_COMMENT",m."Dockit_no",i."No_Insert",i."Size_Book",
    m."Special_discount", m."Special_charges" , m."Trade_disc",m."Print_remark",a."Add1",a."Add2",a."Add3",i.bill_no,i.bill_date';
 set  @v_query=@v_query+'  order by AGENCY_NAME,"INS_DATE","CIOID"';
--IF(@descid IS NOT  NULL) begin


--  set  @v_query=@v_query+'  order by "'+@descid+'"';
--   set @v_query=@v_query+''+@ascdesc+'';
--   print('1')
--end
--ELSE begin 
--  set  @v_query=@v_query+'  order by AGENCY_NAME,"INS_DATE","CIOID"';
--END 

--delete from searchtbl;insert into searchtbl values(@v_query);commit;

print( @v_query)
exec( @v_query)

END 


/////////////end by shipra////////////////////////////////////////////

/////////////////////////////////*********issue no(8943) 17-oct-2012**************//////////////////////



ALTER PROCEDURE   [dbo].[insertintobookchild_display]

@insertdate as datetime,
@edition as varchar(500),
@premium1 as varchar(8),
@premium2 as varchar(8),
@premallow as varchar(2),
@adcategory as varchar(8), 
@latestdate as datetime,
@material as varchar(8),
@cardrate as float, 
@matfilename as varchar(100), 
@discrate as float, 
@insertstatus as varchar(25),
@billstatus as varchar(8),
@adsubcat as varchar(8),
@compcode as varchar(8), 
@userid as varchar(8), 
@cioid as varchar(50),
@height as float,
@width as float,
@totalsize as float,
@pagepost as varchar(8),
@premper1 as float,
@premper2 as float,
@colid as varchar(50),
@repeat as datetime,
@insertno as int,
@paid as varchar(2),
@agrrate as float,
@solorate as float,
@grossrate as float,
@insert_pageno as int,
@insert_remarks as varchar(50),
@page_code as varchar(8),
@page_per as float,
@noofcol as float,
@billamt as float,
@billrate as float,
@logo_h as varchar(5),
@logo_w as varchar(5),
@logo_name as varchar(500),
@insertid as int,
@ad_cat_3 as varchar(100),
@ad_cat_4 as varchar(100),
@ad_cat_5 as varchar(100),
@pkgcode as varchar(100),
@gridins as int,
@pkgalias as varchar(100),
@cirvts as varchar(50),
@cirpub as varchar(50),
@ciredi as varchar(50),
@cirrate as varchar(50),
@cirdate as datetime,
@ciragency as varchar(50),
@ciragencysubcode as varchar(50),
@center as varchar(50),
@branch as varchar(50),
@splboldsizevalue AS VARCHAR(20),
@vatrate_p as float,
@boxcharge_p as float,
@vat_inc_p as varchar,
@grossamtlocal_p as float,
@billamtlocal_p as float,
@sectioncode_p as varchar(50),
@resourceno_p as varchar(50),
@caption_inserts_p as varchar(500),
@subedidata as  varchar(5000),
@disc_p as float,
@P_ip        as  varchar(20),
@P_RATE_AUDIT_FLAG  as varchar(20)


AS
declare @edi as varchar(8)
declare @publi as varchar(8)
declare @pub_cent  as varchar(8)
declare @supp as varchar(8)
declare @cou as int
declare @id as int
declare @insertidval as int
declare @countcir as int
print(@insertid)
select @cou=count(*)   from edition_mast where edition_alias=@edition and comp_code=@compcode

if(@cou >0)
begin
select @edi=Edition_code,@publi=pub_code,@pub_cent=city_code from edition_mast where edition_alias=@edition and comp_code=@compcode
set @supp=''
end

else
begin
select @edi=edition_code,@publi=pub_code,@supp=supp_code from supplement_mast where supp_alias=@edition and comp_code=@compcode
select @pub_cent=city_code from edition_mast where edition_code=@edi and comp_code=@compcode
end

--if(@modid="0")

--begin

if(@supp='')
begin

set @supp='MN'

end
if(@insertid<>0)
begin
--set identity_insert tbl_booking_insert on
--set identity_insert tbl_booking_insert off
--insert into tbl_booking_insert(cio_booking_id,Edition,Insert_date,Col_code,Height,Width,Size_book,Page_post,Premium1,Prem_per1,Premium2,Prem_per2,Premium_allow,Ad_cat,Ad_sub_cat,Latest_by,Status_material,File_name,Card_rate,Disc_rate,Insert_status,Bill_status,comp_code,Userid,Repeating_date,no_insert,Edition_code,Publication_code,Pub_cent_code,Supp_code,Pai_free_ins,Agreed_rate,Solo_rate,Gross_rate,Page_no,Remarks,Page_prem,page_per,No_ofcolumn,Bill_Amt,Bill_rate,Logo_H,Logo_W,Logo_name,insert_id,AD_SUBCAT3,AD_SUBCAT4,AD_SUBCAT5,PACKAGE_CODE,INSERTS,PKG_ALIAS)
--values(@cioid,@edition,@insertdate,@colid,@height,@width,@totalsize,@pagepost,@premium1,@premper1,@premium2,@premper2,@premallow,@adcategory,@adsubcat,@latestdate,@material,@matfilename,@cardrate,@discrate,@insertstatus,@billstatus,@compcode,@userid,@repeat,@insertno,@edi,@publi,@pub_cent,@supp,@paid,@agrrate,@solorate,@grossrate,@insert_pageno,@insert_remarks,@page_code,@page_per,@noofcol,@billamt,@billrate,@logo_h,@logo_w,@logo_name,@insertid,@ad_cat_3,@ad_cat_4,@ad_cat_5, @pkgcode,@gridins,@pkgalias)
update tbl_booking_insert set Edition=@edition,Insert_date=@insertdate,Col_code=@colid,Height=@height,Width=@width,Size_book=@totalsize,Page_post=@pagepost,Premium1=@premium1,Prem_per1=@premper1,Premium2=@premium2,Prem_per2=@premper2,Premium_allow=@premallow,Ad_cat=@adcategory,Ad_sub_cat=@adsubcat,Latest_by=@latestdate,Status_material=@material,File_name=@matfilename,Card_rate=@cardrate,Disc_rate=@discrate,Insert_status=@insertstatus,Bill_status=@billstatus,comp_code=@compcode,Userid=@userid,Repeating_date=@repeat,no_insert=@insertno,Edition_code=@edi,Publication_code=@publi,Pub_cent_code=@pub_cent,Supp_code=@supp,Pai_free_ins=@paid,Agreed_rate=@agrrate,Solo_rate=@solorate,Gross_rate=@grossrate,Page_no=@insert_pageno,Remarks=@insert_remarks,Page_prem=@page_code,page_per=@page_per,No_ofcolumn=@noofcol,Bill_Amt=@billamt,Bill_rate=@billrate,Logo_H=@logo_h,Logo_W=@logo_w,Logo_name=@logo_name,AD_SUBCAT3=@ad_cat_3,AD_SUBCAT4=@ad_cat_4,AD_SUBCAT5=@ad_cat_5,PACKAGE_CODE=@pkgcode,INSERTS=@gridins,PKG_ALIAS=@pkgalias ,SPECIAL_SIZE1=@splboldsizevalue,VATAMT=@vatrate_p,BOXCHARGE=@boxcharge_p, VAT_INC=@vat_inc_p,LOCALGROSSAMT =@grossamtlocal_p,LOCALBILLAMT = @billamtlocal_p,sectioncode=@sectioncode_p,RESOURCE_NO=@resourceno_p,CAPTION=@caption_inserts_p,RATE_AUDIT_IP=@P_ip,RATE_AUDIT_FLAG=@P_RATE_AUDIT_FLAG,DISCOUNT=@disc_p
where cio_booking_id=@cioid and insert_id=@insertid
select @countcir=count(*) from tbl_booking_vts where CIOID=@cioid and INSERTID=@insertid 
print('@cirvts')
print(@cirvts)
if @cirvts!='' 
begin
print('--'+@cirvts)
if(@countcir=0)
insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE
)
                    values(@compcode,@cioid,@insertid,@cirvts,@cirpub,@ciredi,@cirrate,@ciragency,@ciragencysubcode ,@center ,@branch ,@cirdate)
else
update tbl_booking_vts set VTS=@cirvts,PUBLICATION=@cirpub,EDITION=@ciredi,RATE=@cirrate,CIRAGCODE=@ciragency,CIRAGSUBCODE=@ciragencysubcode,CENTER=@center,BRANCH=@branch,PUBLISHDATE=@cirdate where COMPCODE=@compcode and CIOID=@cioid and INSERTID=@insertid
end
--set identity_insert tbl_booking_insert on
end
else
begin
delete from tbl_booking_insert_g where cio_booking_id=@cioid
insert into tbl_booking_insert_g(cio_booking_id,Edition,Insert_date,Col_code,Height,Width,Size_book,Page_post,Premium1,Prem_per1,Premium2,Prem_per2,Premium_allow,Ad_cat,Ad_sub_cat,Latest_by,Status_material,File_name,Card_rate,Disc_rate,Insert_status,Bill_status,comp_code,Userid,Repeating_date,no_insert,Edition_code,Publication_code,Pub_cent_code,Supp_code,Pai_free_ins,Agreed_rate,Solo_rate,Gross_rate,Page_no,Remarks,Page_prem,page_per,No_ofcolumn,Bill_Amt,Bill_rate,Logo_H,Logo_W,Logo_name,AD_SUBCAT3,AD_SUBCAT4,AD_SUBCAT5,PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE,RESOURCE_NO,CAPTION)
values(@cioid,@edition,@insertdate,@colid,@height,@width,@totalsize,@pagepost,@premium1,@premper1,@premium2,@premper2,@premallow,@adcategory,@adsubcat,@latestdate,@material,@matfilename,@cardrate,@discrate,@insertstatus,@billstatus,@compcode,@userid,@repeat,@insertno,@edi,@publi,@pub_cent,@supp,@paid,@agrrate,@solorate,@grossrate,@insert_pageno,@insert_remarks,@page_code,@page_per,@noofcol,@billamt,@billrate,@logo_h,@logo_w,@logo_name,@ad_cat_3,@ad_cat_4,@ad_cat_5, @pkgcode,@gridins,@pkgalias,@splboldsizevalue,@vatrate_p,@boxcharge_p,@vat_inc_p,@grossamtlocal_p,@billamtlocal_p,@sectioncode_p,@resourceno_p,@caption_inserts_p)
INSERT INTO [tbl_booking_insert]
            (insert_id,
           [cio_booking_id]
           ,[no_insert]
           ,[Edition_code]
           ,[Publication_code]
           ,[Pub_cent_code]
           ,[Supp_code]
           ,[Edition]
           ,[Insert_date]
           ,[Col_code]
           ,[Height]
           ,[Width]
           ,[Size_book]
           ,[Page_post]
           ,[Premium1]
           ,[Prem_per1]
           ,[Premium2]
           ,[Prem_per2]
           ,[Premium_allow]
           ,[Ad_cat]
           ,[Ad_sub_cat]
           ,[Latest_by]
           ,[Repeating_date]
           ,[Status_material]
           ,[File_name]
           ,[Card_rate]
           ,[Disc_rate]
           ,[Insert_status]
           ,[Bill_status]
           ,[Agreed_rate]
           ,[Pai_free_ins]
           ,[Solo_rate]
           ,[Gross_rate]
           ,[comp_code]
           ,[Userid]
           ,[Page_no]
           ,[Remarks]
           ,[Pub_height]
           ,[Pub_width]
           ,[Page_prem]
           ,[page_per]
           ,[No_ofcolumn]
           ,[Bill_Amt]
           ,[Bill_rate]
           ,[Logo_H]
           ,[Logo_W]
           ,[Logo_name]
           ,[AD_SUBCAT3]
           ,[AD_SUBCAT4]
           ,[AD_SUBCAT5]
           ,[PACKAGE_CODE]
           ,[BILL_NO]
           ,[BILL_DATE]
           ,[INSERTS]
           ,[PKG_ALIAS]
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE,CAPTION)
SELECT insert_id,[cio_booking_id]
           ,[no_insert]
           ,[Edition_code]
           ,[Publication_code]
           ,[Pub_cent_code]
           ,[Supp_code]
           ,[Edition]
           ,[Insert_date]
           ,[Col_code]
           ,[Height]
           ,[Width]
           ,[Size_book]
           ,[Page_post]
           ,[Premium1]
           ,[Prem_per1]
           ,[Premium2]
           ,[Prem_per2]
           ,[Premium_allow]
           ,[Ad_cat]
           ,[Ad_sub_cat]
           ,[Latest_by]
           ,[Repeating_date]
           ,[Status_material]
           ,[File_name]
           ,[Card_rate]
           ,[Disc_rate]
           ,[Insert_status]
           ,[Bill_status]
           ,[Agreed_rate]
           ,[Pai_free_ins]
           ,[Solo_rate]
           ,[Gross_rate]
           ,[comp_code]
           ,[Userid]
           ,[Page_no]
           ,[Remarks]
           ,[Pub_height]
           ,[Pub_width]
           ,[Page_prem]
           ,[page_per]
           ,[No_ofcolumn]
           ,[Bill_Amt]
           ,[Bill_rate]
           ,[Logo_H]
           ,[Logo_W]
           ,[Logo_name]
           ,[AD_SUBCAT3]
           ,[AD_SUBCAT4]
           ,[AD_SUBCAT5]
           ,[PACKAGE_CODE]
           ,[BILL_NO]
           ,[BILL_DATE]
           ,[INSERTS]
           ,[PKG_ALIAS]
           ,[LOCKSTATUS],SPECIAL_SIZE1,vatamt,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE,CAPTION FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=@cioid
set @insertidval=@@identity
if @cirvts!='' 
insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE
)
                    values(@compcode,@cioid,@insertidval,@cirvts,@cirpub,@ciredi,@cirrate,@ciragency,@ciragencysubcode ,@center ,@branch ,@cirdate)
end

exec insert_edition_details_update @subedidata,null,@cioid,@insertidval,@compcode,@edition,@insertdate,@height,@width,@totalsize,@insertstatus,@pkgcode ,@insertno,@insert_pageno
--declare @maxid int
--if(@insertid<>0)
--begin
    --select @maxid=max (insert_id) from tbl_booking_insert where cio_booking_id=@cioid 
    --update tbl_booking_insert set insert_id=@insertid where cio_booking_id=@cioid  and insert_id=@maxid
--end
--declare @qu as varchar(1000)

--set @qu='insert into tbl_booking_insert(cio_booking_id,Edition,Insert_date,Col_code,Height,Width,Size_book,Page_post,Premium1,Prem_per1,Premium2,Prem_per2,Premium_allow,Ad_cat,Ad_sub_cat,Latest_by,Status_material,File_name,Card_rate,Disc_rate,Insert_status,Bill_status,comp_code,Userid,Repeating_date,no_insert,Edition_code,Publication_code,Pub_cent_code,Supp_code,Pai_free_ins,Agreed_rate,Solo_rate,Gross_rate,Page_no,Remarks,Page_prem,page_per,No_ofcolumn,Bill_Amt,Bill_rate,Logo_H,Logo_W,Logo_name)
--values('''+@cioid+''','''+@edition+''','''+@insertdate+''','''+@colid+''','''+@height+''','''+@width+''','''+@totalsize+''','''+@pagepost+''','''+@premium1+''','''+@premper1+''','''+@premium2+''','''+@premper2+''','''+@premallow+''','''+@adcategory+''','''+@adsubcat+''','''+@latestdate+''','''+@material+''','''+@matfilename+''','''+@cardrate+''','''+@discrate+''','''+@insertstatus+''','''+@billstatus+''','''+@compcode+''','''+@userid+''','''+@repeat+''','''+@insertno+''','''+@edi+''','''+@publi+''','''+@pub_cent+''','''+@supp+''','''+@paid+''','''+@agrrate+''','''+@solorate+''','''+@grossrate+''','''+@insert_pageno+''','''+@insert_remarks+''','''+@page_code+''','''+@page_per+''','''+@noofcol+''','''+@billamt+''','''+@billrate+''','''+@logo_h+''','''+@logo_w+''','''+@logo_name+''')'



--end

--else
--begin
--update tbl_booking_insert set Edition=@edition,Insert_date=@insertdate,Col_code=@colid,Height=@height,Width=@width,Size_book=@totalsize,Page_post=@pagepost,
--Premium1=@premium1,Prem_per1=@premper1,Premium2=@premium2,Prem_per2=@premper2,Premium_allow=@premallow,Ad_cat=@adcategory,Ad_sub_cat=@adsubcat,Latest_by=@latestdate,
--Status_material=@material,File_name=@matfilename,Card_rate=@cardrate,Disc_rate=@discrate,Insert_status=@insertstatus,Bill_status=@billstatus,Repeating_date=@repeat,
--no_insert=@insertno,Edition_code=@edi,Publication_code=@publi,Pub_cent_code=@pub_cent,Supp_code=@supp,Pai_free_ins=@paid,Agreed_rate=@agrrate,Solo_rate=@solorate,Gross_rate=@grossrate

--where cio_booking_id=@cioid and insert_id=@modid


--end

--set @query='select * from tbl_booking_insert'
--print(@query)
--exec(@query)




////////////////********(Anuj)end***************/////////////////



//////////************problem no 8740*************///////////////////////
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[websp_deleteagent]    Script Date: 10/18/2012 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE   [dbo].[websp_deleteagent]

@agentcode as varchar(10),
@compcode as varchar(10),
@userid as varchar(10),
@subagency as varchar(8),
@codesubcode  as varchar(8)

 AS
declare @query as varchar(900)
declare @countnum int
select @countnum=count(*) from tbl_booking_mast where agency_sub_code=@codesubcode
if @countnum=0
begin

delete from first where Agency_code = @agentcode and comp_code = @compcode 

delete from bank_mast  where Agency_code = @agentcode and comp_code = @compcode and AGENCY_SUBCAT_CODE=@subagency
delete from comm_details where Agency_code = @agentcode and comp_code = @compcode  and Agency_sub_code=@subagency

delete from cont_details where Agency_code = @agentcode and comp_code = @compcode  and Agency_Subcat_Code=@subagency

delete from status_detail where Agency_code = @agentcode and comp_code = @compcode and agency_subcat_code=@subagency

delete pay_mode_mst where Agency_code = @agentcode and comp_code = @compcode and Agency_subcat_code=@subagency

delete bank_detail where  Agency_code = @agentcode and comp_code = @compcode and Agency_subcat_code=@subagency

DELETE ad_user WHERE Agency_code = @codesubcode;
delete from Agency_mast where Agency_code = @agentcode and comp_code = @compcode and SUB_Agency_Code=@subagency
end



////////////////////////////end by hitesh////////////////////////////////////////////






/////////statr by shipra issue no 8895//////////////////////


alter PROCEDURE rpt_Issue_Billwise_report_p(
    @pcompcode       AS VARCHAR(50),
    @ppubcent        AS VARCHAR(100),
    @pedtncode       AS VARCHAR(50),
    @pfrom_date      AS VARCHAR(50),
    @ptill_date      AS VARCHAR(50),
    @pdateformat     AS VARCHAR(50),
    @puserid         AS VARCHAR(50),
    @chk_access      AS varchar(20)=null,
    @pratio_type     AS varchar(20)=null,
    @pextra1         AS varchar(20)=null,
    @pextra2         AS varchar(20)=null)
   -- p_accounts1      OUT t_accounts_cursor,
    --p_accounts2     OUT t_accounts_cursor)
--IS
AS
declare @v_frdt      date;
declare @v_todt      date;
declare @v_query     VARCHAR(8000);
declare @qry         VARCHAR(8000);

 declare  c11 cursor for
 Select "Comp_code" AS COMP_CODE,UNIT,"Publication_Code" PUBLICATION_CODE,"Edition_Code" AS EDITION_CODE,SUB_EDITION_CODE,edition_name,dsize, 
sum(RCR)RCR,sum(CN) CREDIT_NOTE,sum(RCP) RCP,sum(CA)CA,sum(BILL) BUSINESS_BILL,sum(DN) DEBIT_NOTE,(sum(RCR)+sum(RCP)) COLLECTION,SUM(BALANCE) BALANCE 
from( 
select DISTINCT a."Comp_code" ,dbo.GET_BRANCHCODE(a."Comp_code",a."branch") unit,a."branch" ,
 b."Publication_Code",b."Edition_Code",ISNULL(c.sub_edition_code,b."Edition_Code") sub_edition_code, 
dbo.ad_get_edtn_name( a."Comp_code",b."Publication_Code",ISNULL(c.sub_edition_code,b."Edition_Code")) edition_name, 
ISNULL(sum(b."Bill_Amt"),0) "Bill_Amt",ISNULL(c.percentage,100) percentage , 
ROUND((sum("Size_Book"))* 
round(ISNULL(sum(ISNULL(round(b."Bill_Amt"*c.percentage/100,2),b."Bill_Amt")),0)*100/ 
(select sum(billamt) from ad_bills where bilno=b.bill_no and bildt=b.bill_date),2)/100,2) dsize, 
ISNULL(sum(ISNULL(round(b."Bill_Amt"*c.percentage/100,2),b."Bill_Amt")),0) ratio_billamt, 
round(ISNULL(sum(ISNULL(round(b."Bill_Amt"*c.percentage/100,2),b."Bill_Amt")),0)*100/ 
(select sum(billamt) from ad_bills where --ad_bills.comp_code=a."Comp_code" and  
bilno=b.bill_no and bildt=b.bill_date),2) per, 
ROUND((select ISNULL(sum(ABS(amount)),0) from ad_outstand where comp_code=a."Comp_code" and doctype='RCR' and billno=b.bill_no and billdt=b.bill_date)* 
round(ISNULL(sum(ISNULL(round(b."Bill_Amt"*c.percentage/100,2),b."Bill_Amt")),0)*100/ 
(select sum(billamt) from ad_bills where bilno=b.bill_no and bildt=b.bill_date),2)/100,2) RCR, 
ROUND((select ISNULL(sum(ABS(amount)),0) from ad_outstand where comp_code=a."Comp_code" and doctype='CN' and billno=b.bill_no and billdt=b.bill_date)* 
round(ISNULL(sum(ISNULL(round(b."Bill_Amt"*c.percentage/100,2),b."Bill_Amt")),0)*100/ 
(select sum(billamt) from ad_bills where bilno=b.bill_no and bildt=b.bill_date),2)/100,2) CN, 
ROUND((select ISNULL(sum(ABS(amount)),0) from ad_outstand where comp_code=a."Comp_code" and doctype='RCP' and billno=b.bill_no and billdt=b.bill_date)* 
round(ISNULL(sum(ISNULL(round(b."Bill_Amt"*c.percentage/100,2),b."Bill_Amt")),0)*100/ 
(select sum(billamt) from ad_bills where bilno=b.bill_no and bildt=b.bill_date),2)/100,2) RCP, 
ROUND((select ISNULL(sum(ABS(amount)),0) from ad_outstand where comp_code=a."Comp_code" and doctype='CA' and billno=b.bill_no and billdt=b.bill_date)* 
round(ISNULL(sum(ISNULL(round(b."Bill_Amt"*c.percentage/100,2),b."Bill_Amt")),0)*100/ 
(select sum(billamt) from ad_bills where bilno=b.bill_no and bildt=b.bill_date),2)/100,2) CA, 
ROUND((select ISNULL(sum(ABS(amount)),0) from ad_outstand where comp_code=a."Comp_code" and doctype='BILL' and billno=b.bill_no and billdt=b.bill_date)* 
round(ISNULL(sum(ISNULL(round(b."Bill_Amt"*c.percentage/100,2),b."Bill_Amt")),0)*100/ 
(select sum(billamt) from ad_bills where bilno=b.bill_no and bildt=b.bill_date),2)/100,2) BILL, 
ROUND((select ISNULL(sum(ABS(amount)),0) from ad_outstand where comp_code=a."Comp_code" and doctype='DN' and billno=b.bill_no and billdt=b.bill_date)* 
round(ISNULL(sum(ISNULL(round(b."Bill_Amt"*c.percentage/100,2),b."Bill_Amt")),0)*100/ 
(select sum(billamt) from ad_bills where bilno=b.bill_no and bildt=b.bill_date),2)/100,2) DN ,
ROUND((select ISNULL(sum(amount),0) from ad_outstand where comp_code=a."Comp_code" and billno=b.bill_no and billdt=b.bill_date)* 
round(ISNULL(sum(ISNULL(round(b."Bill_Amt"*c.percentage/100,2),b."Bill_Amt")),0)*100/ 
(select sum(billamt) from ad_bills where bilno=b.bill_no and bildt=b.bill_date),2)/100,2) BALANCE 
from tbl_booking_mast a,tbl_booking_insert b,editionwiseratio_mast c, branch_mst d 
where   a."cio_booking_id"=b."Cio_Booking_Id" 
and a."Comp_code"=b."Comp_Code" 
and b."Comp_Code"=c.comp_code--(+)
and  b."Publication_Code"=c.pub_code--(+) 
and b."Edition_Code"=c.main_edition_code--(+) 
and  b.bill_no is not null and b."Bill_Amt"<>0 
and b."Insert_Status"='billed' 
and d."Comp_Code"=a."Comp_code" 
AND a."branch"=d."Branch_Code" 
and a."Comp_code"=@pcompcode 
and (d."pub_center"=@ppubcent or @ppubcent is null) 
and b."Insert_Date" between  @v_frdt and @v_todt 
group by a."Comp_code",a."branch",b."Pub_Cent_Code",b."Edition_Code", b."Publication_Code",c.sub_edition_code, 
c.edition_name,b."Comp_Code",c.percentage,b.bill_no,b.bill_date) x 
group by "Comp_code",UNIT,edition_name,"Publication_Code","Edition_Code",SUB_EDITION_CODE,EDITION_NAME,dsize 
order by 1,3,2;

 
   DECLARE     @v_var       varchar(8000);
    DECLARE    @v_var1      varchar(8000);
     DECLARE   @v_var2      varchar(8000);
     DECLARE   @v_var_sum   varchar(8000);
     DECLARE   @v_var_sum1  varchar(8000);
      DECLARE  @v_var_sum2  varchar(8000);
      DECLARE @v_comp varchar(20);
      declare @vPublication_Code varchar(50);
      declare @vEdition_Code varchar(50);
      declare @vSUB_EDITION_CODE varchar(50);
      declare @vedition_name varchar(50);
      declare @vdsize varchar(50);
      declare  @RCR varchar(50);
      declare @vCREDIT_NOTE varchar (20);
      declare @vCN  varchar(20);
      declare @vRCP varchar(20);
      declare @vCA varchar(20);
      declare @vBILL varchar(100);
      declare @vDEBIT_NOTE varchar(50);
      declare @vCOLLECTION varchar(50);
      declare @vBALANCE varchar(50);
      declare @vsessionid int
      
      
      
      
BEGIN

CREATE TABLE #TEMP_RPT_ISSUE_PCENTER_WISE
(
  COMP_CODE         VARCHAR(40),
  UNIT              VARCHAR(40),
  PUBLICATION_CODE  VARCHAR(40),
  EDITION_CODE      VARCHAR(40),
  SUB_EDITION_CODE  VARCHAR(40),
  EDITION_NAME      VARCHAR(40),
  DSIZE             NUMERIC(8),
  RCR               NUMERIC(8),
  CREDIT_NOTE       NUMERIC(8),
  RCP               NUMERIC(8),
  CA                NUMERIC(8),
  BUSINESS_BILL     NUMERIC(8),
  DEBIT_NOTE        NUMERIC(8),
  COLLECTION        NUMERIC(8),
  BALANCE           NUMERIC(8),
  SESS_ID           NUMERIC(8) 
)

declare @vRCR varchar(50)
 delete from #temp_rpt_issue_pcenter_wise where sess_id=@@spid ;



  set @v_frdt    =@pfrom_date--to_date(@pfrom_date,''''+@pdateformat+'''');
  set @v_todt    =@ptill_date--to_date(@ptill_date,''''+@pdateformat+'''');
 open c11;
            
                fetch next from  c11 into @v_comp,@vPublication_Code,@vEdition_Code,@vSUB_EDITION_CODE,@vedition_name,@vdsize,@RCR,@vCREDIT_NOTE,@vRCP,@vCA,@vBILL,@vDEBIT_NOTE,@vCOLLECTION,@vBALANCE,@vsessionid;
                while(@@fetch_status=0) begin
                
              insert into #temp_rpt_issue_pcenter_wise(COMP_CODE,PUBLICATION_CODE, EDITION_CODE, SUB_EDITION_CODE, EDITION_NAME, DSIZE, RCR, CREDIT_NOTE, RCP, CA, BUSINESS_BILL, DEBIT_NOTE, COLLECTION, BALANCE, SESS_ID)
                       -- values(@v_comp,v11.UNIT,v11.PUBLICATION_CODE,v11.EDITION_CODE,v11.SUB_EDITION_CODE,v11.EDITION_NAME, v11.DSIZE,v11.RCR,v11.CREDIT_NOTE,v11.RCP,v11.CA,v11.BUSINESS_BILL,v11.DEBIT_NOTE,v11.COLLECTION,v11.BALANCE,userenv('sessionid'));
            --  values(@v_comp,@vPublication_Code,@vEdition_Code,@vSUB_EDITION_CODE,@vedition_name,@vdsize,@vRCR,@vCN,@vRCP,@vCA,@vBILL,@vDEBIT_NOTE,@vCOLLECTION,@vBALANCE,@@spid)
             values(@v_comp,@vPublication_Code,@vEdition_Code,@vSUB_EDITION_CODE,@vedition_name,@vdsize,@RCR,@vCREDIT_NOTE,@vRCP,@vCA,@vBILL,@vDEBIT_NOTE,@vCOLLECTION,@vBALANCE,@@spid)
             
             -- select getdate()
            end 
               fetch next from  c11 into @v_comp,@vPublication_Code,@vEdition_Code,@vSUB_EDITION_CODE,@vedition_name,@vdsize,@RCR,@vCREDIT_NOTE,@vRCP,@vCA,@vBILL,@vDEBIT_NOTE,@vCOLLECTION,@vBALANCE,@vsessionid;
            close c11;
            deallocate c11;
  
              
 select COMP_CODE, UNIT, 
 dbo.sam_publ_name(COMP_CODE, PUBLICATION_CODE)PUBLICATION_CODE,PUBLICATION_CODE PUBL, EDITION_CODE, SUB_EDITION_CODE, EDITION_NAME, DSIZE, RCR, CREDIT_NOTE, RCP,
                             CA, BUSINESS_BILL, DEBIT_NOTE, COLLECTION, BALANCE from #temp_rpt_issue_pcenter_wise
							 where sess_id=@@spid ;
	
					

 select COMP_CODE, UNIT,dbo.sam_publ_name(COMP_CODE, PUBLICATION_CODE)PUBLICATION_CODE,PUBLICATION_CODE PUBL, EDITION_CODE,EDITION_NAME, 
                             SUM(DSIZE), SUM(BUSINESS_BILL),SUM(DEBIT_NOTE),SUM(COLLECTION),SUM(BALANCE) from #temp_rpt_issue_pcenter_wise
							 where sess_id=@@spid 
							 group by COMP_CODE, UNIT, PUBLICATION_CODE, EDITION_CODE,EDITION_NAME 
						     order by COMP_CODE, UNIT, PUBLICATION_CODE, EDITION_CODE,EDITION_NAME;

END 
 


//////////////////end by shipra/////////////////////


////////////////////******issueno(8733)(Anuj)******////////////////////////


ALTER PROCEDURE [dbo].[sp_clientstatusupdate]
@compcode varchar(8),
@userid varchar(8),
@custcode varchar(8),
@formdate as DATETIME,
@todate as DATETIME,
@status as varchar(20),
@update as varchar(4),
@crcular as varchar(8),
@attach as varchar(100),
@remark as varchar(100)

 AS

declare @query as varchar(900)
declare @ss as varchar(2000)
declare @statusname as varchar(50)

begin

select @statusname=status_name from tblstatus where status_code=@status 

update status_detail_client set cust_status=@status, from_date=@formdate, to_date=@todate ,Circular=@crcular,status_alias=@statusname,ATTACHMENT=@attach,REMARK=@remark where  comp_code=@compcode  and cust_code=@custcode and stat_code=@update
end

--begin
--update clientfirst set cust_status =@status    where  userid=@userid and cust_code=@custcode and comp_code=@compcode
--end

select * from status_detail_client
print (@query)
exec (@query)






/////////////////////////******************************************///////////////////////////////////////






/////////////////////////****************************Issue No. 8952*****************///////////////////////////////

ALTER PROCEDURE [dbo].[representative_summmery]
	@fromdate                                 VARCHAR(4000) ,
	@dateto                                   VARCHAR(4000) ,
	@compcode                                 VARCHAR(4000) ,
	@pub_name                                 VARCHAR(4000)                    = null ,
	@pub_cent                                 VARCHAR(4000) ,
	@DATEFORMAT                               VARCHAR(4000) ,
	@descid                                   VARCHAR(4000)                    = null ,
	@ascdesc                                  VARCHAR(4000)                    = null ,
	@adtyp                                    VARCHAR(4000) ,
	@VALUE                                    VARCHAR(4000) ,
	@execut                                   VARCHAR(4000) ,
	@team                                     VARCHAR(4000) ,
	@bill                                     VARCHAR(4000) ,
	@cl                                       VARCHAR(4000) ,
	@ag                                       VARCHAR(4000) ,
	@retainer                                 VARCHAR(4000) ,
	@rep                                      VARCHAR(4000) ,
	@puserid                                  VARCHAR(4000)                    = null ,
	@chk_access                               VARCHAR(4000)                    = null ,
	@pbrancode                                VARCHAR(4000) ,
	@pdistcode                                VARCHAR(4000) ,
	@pextra1                                  VARCHAR(4000) ,
	@pextra2                                  VARCHAR(4000) ,
	@pextra3                                  VARCHAR(4000) ,
	@pextra4                                  VARCHAR(4000) ,
	@pextra5                                  VARCHAR(4000) 
	--@p_accounts                               cur_type_new1.cursor_type OUTPUT set @v_frdt=convert(datetime,@pfromdate)
AS 
	DECLARE @LoopProcessingFlag BIT 
	BEGIN
		SET NOCOUNT ON
		
		DECLARE @vquery                                   VARCHAR(8000) 
		DECLARE @center                                   VARCHAR(50) 
		DECLARE @reg                                      VARCHAR(900) 
		DECLARE @from_date                                DATETIME 
		DECLARE @date_to                                  DATETIME 
		DECLARE @sortorder                                VARCHAR(100) 
		DECLARE @vquery1                                  VARCHAR(1000) 
		DECLARE @breakup                                  VARCHAR(8000) 
		DECLARE @breakgrp                                 VARCHAR(1000) 
		SET @LoopProcessingFlag = 0
		--IF ( @fromdate IS NOT NULL AND @dateto IS NULL ) 
		--BEGIN 
		--	SELECT @from_date  = CONVERT(datetime,@fromdate, 101)--@fromdate 
		--	SELECT @date_to  = CONVERT(datetime,@fromdate, 101)--@fromdate 
		--	SET @LoopProcessingFlag = 1
		--END
		--IF ( @fromdate IS NOT NULL AND @dateto IS NOT NULL )  AND (@LoopProcessingFlag = 0)
		--BEGIN 
		--	SELECT @from_date  = CONVERT(datetime,@fromdate, 101)--@fromdate 
		--	SELECT @date_to  = CONVERT(datetime,@dateto, 101)--@dateto 
		--END
   
		SET @LoopProcessingFlag = 0
		IF ( @descid IS NOT NULL ) 
		BEGIN 
			SELECT @sortorder  = @descid 
			SET @LoopProcessingFlag = 1
		END
		IF ( @ascdesc IS NOT NULL )  AND (@LoopProcessingFlag = 0)
		BEGIN 
			SELECT @sortorder  = @ascdesc 
		END
   
  
		------------------
		--Dbms_output.put_line(Vquery1);
		
		IF ( @descid IS NULL ) 
		BEGIN 
			IF ( @rep = '2' ) 
			BEGIN 
				SELECT @vquery1  = ' ORDER BY "Retainer" asc' 
			END
			ELSE
			BEGIN 
				SELECT @vquery1  = ' ORDER BY "Executive" asc' 
			END
   
		END
		ELSE
		BEGIN 
			SELECT @vquery1  = @vquery1 + 'order by "' + @descid + '"' 
			SELECT @vquery1  = @vquery1 + '' + @ascdesc + '' 
		END
    print('44444')
		SELECT @vquery  =  'SELECT  i."Cio_Booking_Id" AS "CIOID",  a."Agency_Name" AS "Agency", 
		 isnull((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "Client", 
		  (select COMBIN_MAST."Package_Name" from combin_mast where COMBIN_MAST."Combin_Code"  in(m."Package_code"))
		  AS "Package",  
		  CASE ''' + @DATEFORMAT + '''  
		  WHEN''mm/dd/yyyy'' THEN convert(varchar(10),"Insert_Date",101)  
		  WHEN''dd/mm/yyyy'' THEN convert(varchar(10),"Insert_Date",103)  
		    WHEN''yyyy/mm/dd'' THEN convert(varchar(10),"Insert_Date",111)   END AS "Ins.date" , 
		     m."Trade_disc" AS "Trade_disc" ,  m."Key_no" AS "Key" ,  m."RO_No" AS "Ro.No.", 
		     convert(varchar(10),m."RO_Date",103) AS "Ro.Date", 
		      i.BILL_NO as "BILL_NO",   i.BILL_DATE as "BILL_DATE",  
		       isnull(i."Bill_Amt",''0'') AS "Bill_Amt",  i."Remarks" as "Remarks",  
		       i.CAPTION as "CAPTION",  isnull(i."Card_Rate" ,''0'') AS "Card_Rate",
		         isnull(i."Agreed_Rate" ,''0'') AS "Agreed_Rate", 
(select EXEC_MAST."Exec_name" from exec_mast where  m."Executive_code"=EXEC_MAST."Exe_no") AS "Executive",
(select EXEC_MAST."CIty_Name" from exec_mast where  m."Executive_code"=EXEC_MAST."Exe_no") AS "ExecutiveCity", 
 (SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=i."Ad_Cat" ) as "Adcat", 
  (select Retainermaster."Retain_Alias" from Retainermaster where  m."RETAINER"=Retainermaster."Retain_Code") 
  as "Retainer",  
 (select city_mst."City_Name" from city_mst where  city_mst."City_Code"= (select Retainermaster."City_Code" from Retainermaster where  m."RETAINER"=Retainermaster."Retain_Code")) as "Retainercity",
  case (case "Agency_Type_Code" when ''IA0'' then  ''GOVT.'' when ''DA0'' then ''GOVT.'' end)
  when ''GOVT.'' then ''GOVT.''
  else (case a."State_Code" when ''ORISSA'' then ''LOCAL'' else ''NATIONAL'' end) end  AS "FinalGRP", 
  
  
   i."Edition" as "edition",  
   (SELECT dbo.initcap("Comp_Name") from comp_mst where "Comp_Code"=''' + @compcode + ''') AS "companyname", 
    getdate() as "Rundate",i."Height",i."Width",i."Size_Book", 
    u."Uom_Name" as uom,u."UOM_DESC" as uomdesc,i."No_Insert" as "NO_INSERT",m."No_of_insertion" as NO_OF_INSERTION   
     FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a,uom_mast u  
     
      
     WHERE m."Comp_code"=''' + @compcode + ''' AND m."cio_booking_id"=i."Cio_Booking_Id"  
     AND m."Agency_sub_code"=a."code_subcode"   
     AND m."cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null) 
      and  lower("Insert_Status") !=''cancel'' 
       and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=''' + @puserid + ''')
        and''' + @chk_access + '''=''1'')  or  (''' + @chk_access + '''=''0'') ) 
        
         AND (m."Ad_type_code"=''' + @adtyp + ''' OR''' + @adtyp + '''  IS NULL  or ''' + @adtyp + ''' ='''')  
         AND (i."Pub_Cent_Code"=''' + @pub_cent + ''' OR''' + @pub_cent + ''' IS NULL or ''' + @pub_cent + ''' ='''')  
         AND (m."Revenue_center"=''' + @pub_name + ''' OR''' + @pub_name + '''  IS NULL or ''' + @pub_name + '''='''')  
         AND (m."Executive_code"  =''' + @execut + ''' OR''' + @execut + '''  IS NULL or ''' + @execut + ''' ='''')  
         AND (m."Executive_code" in (select exec_mast."Exe_no" from exec_mast 
         where  EXEC_MAST."Team_code"  =''' + @team + ''' OR''' + @team + ''' IS NULL  or ''' + @team + '''='''') OR''' + @team + ''' IS NULL or ''' + @team + '''='''' )  
         AND ("Client_code"  =''' + @cl + ''' OR''' + @cl + ''' IS NULL or ''' + @cl + '''='''')  AND (m."Agency_code"  =''' + @ag + ''' 
         OR''' + @ag + ''' IS NULL or ''' + @ag + '''='''')  
         AND (m.RETAINER  =''' + @retainer + ''' OR''' + @retainer + ''' IS NULL or ''' + @retainer + '''='''')  
         AND ((''' + @rep + '''=''2'' and m."RETAINER" is not null and m."RETAINER"!=''0'' and m."RETAINER"!='''')
         or(''' + @rep + '''=''1'' and m."Executive_code" is not null and m."Executive_code" !=''0'' and m."Executive_code" !=''''))
          AND  "Insert_Date" BETWEEN''' + @fromdate + ''' AND''' + @dateto + '''  
         ' 
		SELECT @vquery  = @vquery + @vquery1 
		print(@vquery)
		EXEC (@vquery )

		SET NOCOUNT OFF

	END



------------------------------------------------------------




ALTER PROCEDURE [dbo].[representative](
@fromdate		as varchar(20),
@dateto			as varchar(20),
@compcode		as varchar(10),
@pub_name		as varchar(50)=null,
@pub_cent		as varchar(50),
@dateformat		as varchar(20),
@descid			as varchar(20)=null,
@ascdesc		as varchar(20)=null,
@adtyp			as varchar(50),
@value			as varchar(50),
@execut			as varchar(50),
@team			as varchar(50),
@bill			as varchar(50),
@cl				as varchar(50),
@ag				as varchar(50),
@retainer		as varchar(50),
@rep			as varchar(50),
@puserid		as varchar(10)=null,
@chk_access		as varchar(2),
@pbrancode		as varchar(200),
@pdistcode		as varchar(200),
@pextra1		as varchar(200),
@pextra2		as varchar(200),
@pextra3		as varchar(200),
@pextra4		as varchar(200),
@pextra5		as varchar(200))
AS
declare @Vquery		varchar(8000)
declare @center		varchar(50)
declare @reg		varchar(900)

declare @sortorder	varchar(100)
declare @Vquery1	varchar(1000)

declare @breakup	varchar(8000)
declare @breakgrp	varchar(1000)

BEGIN

IF(@descid IS NOT NULL and @descid<>'') begin
   set @sortorder=@descid 
End
else IF(@ascdesc IS NOT NULL  and @ascdesc<>'') begin
    set @sortorder=@ascdesc 
End 


if(@descid is null) begin
	if(@rep='2')begin
		set @Vquery1 = 'ORDER BY Retainer asc' 
	end
	else begin
		set @Vquery1 = 'ORDER BY Executive asc'
	end
end 
else begin
	set @Vquery1 = @Vquery1+'order by "'+@descid+'"'
	set @Vquery1 = @Vquery1 + ''+@ascdesc+''
end 


set @Vquery =  'SELECT  i.Cio_Booking_Id AS "CIOID",
a.Agency_Name AS "Agency",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=m.Client_code),m.Client_code)  AS "Client",
(select COMBIN_MAST.Package_Name from combin_mast where COMBIN_MAST.Combin_Code  in(m.Package_code))AS "Package",
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),Insert_Date,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),Insert_Date,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),Insert_Date,111) END AS "Ins.date" ,
 m.Key_no AS "Key" ,
m.RO_No AS "Ro.No.", 
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),m.RO_Date,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),m.RO_Date,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),m.RO_Date,111) END AS "Ro.Date",
isnull(i.Bill_Amt,''0'') AS "NetAmt",
(select EXEC_MAST.Exec_name from exec_mast where m.Executive_code=EXEC_MAST.Exe_no) AS "Executive",
(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=i.Ad_Cat) as "Adcat",
(select Retainermaster.Retain_Alias from Retainermaster where  m.RETAINER=Retainermaster.Retain_Code) as "Retainer",
case Agency_Type_Code
when(CASE Agency_Type_Code
WHEN ''IA0'' THEN ''GOVT.''
WHEN ''DA0'' THEN ''GOVT.'' end )
then
(CASE a.State_Code
WHEN ''ORISSA'' THEN ''LOCAL''
else ''NATIONAL'' end )end
AS "FinalGRP",
i.Edition as "edition",
(SELECT dbo.initcap(Comp_Name) from comp_mst where Comp_Code='''+@compcode+''') AS "companyname",
getdate() as "Rundate",

(select  "Branch_Name"  from branch_mst where m."branch"=  branch_mst."Branch_Code") as "Branch_Name",

(select  "Dist_Name"  from dist_mst where a."DISTRICT" =  dist_mst."Dist_Code") as "District_Name"

FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a
WHERE m.Comp_code='''+@compcode+''' AND
m.cio_booking_id=i.Cio_Booking_Id
AND m.Agency_sub_code=a.code_subcode 
 AND m.cio_booking_id not in(select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)
 and  lower(i.Insert_Status) !=''cancel''
and ((i.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )
AND  i.Insert_Date BETWEEN '''+@fromdate+''' AND '''+@dateto+'''
AND (('''+@rep+'''=''2'' and m.RETAINER is not null and m.RETAINER!=''0'' and m.RETAINER!='''')
or('''+@rep+'''=''1'' and m.Executive_code is not null and m.Executive_code !=''0'' and m.Executive_code!=''''))'

IF(@adtyp IS NOT NULL AND @adtyp<>'')BEGIN
	set @Vquery = @Vquery+' AND m.Ad_type_code='''+@adtyp+''' '
END

IF(@pub_cent IS NOT NULL AND @pub_cent<>'')BEGIN
	set @Vquery = @Vquery+' AND i.Pub_Cent_Code='''+@pub_cent+''' '
END

IF(@pub_name IS NOT NULL AND @pub_name<>'')BEGIN
	set @Vquery = @Vquery+' and m.Revenue_center='''+@pub_name+''' '
END

IF(@execut IS NOT NULL AND @execut<>'')BEGIN
	set @Vquery = @Vquery+' and m.Executive_code='''+@execut+''' '
end

IF(@team IS NOT NULL AND @team<>'')BEGIN
	set @Vquery = @Vquery+' and (m.Executive_code in (select exec_mast.Exe_no from exec_mast where  EXEC_MAST.Team_code  = '''+@team+''' OR '''+@team+''' IS NULL ) OR '''+@team+''' IS NULL )'
end

IF(@cl IS NOT NULL AND @cl<>'')BEGIN
	set @Vquery = @Vquery+' and m.Client_code  = '''+@cl+''''
end

IF(@ag IS NOT NULL AND @ag<>'')BEGIN
	set @Vquery = @Vquery+' and m.Agency_code  = '''+@ag+''''
end

IF(@retainer IS NOT NULL AND @retainer<>'')BEGIN
	set @Vquery = @Vquery+' and m.RETAINER  = '''+@retainer+''''
end

IF(@pdistcode IS NOT NULL AND @pdistcode<>'')BEGIN
	set @Vquery = @Vquery+' and a.district  = '''+@pdistcode+''''
end

IF(@pbrancode IS NOT NULL AND @pbrancode<>'')BEGIN
	set @Vquery = @Vquery+' and a.Branch_code  = '''+@pbrancode+''''
end

set @Vquery = @Vquery + @Vquery1

print(@Vquery)
exec(@Vquery)



END


/////////////////////////****************************END Issue No. 8952*****************///////////////////////////////



/////////////////////***************issur no 8794(Anuj) 22/oct-2012***********************////////////////////////////////////
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[websp_copyratenew]    Script Date: 10/22/2012 16:29:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[websp_copyratenew]
	-- Add the parameters for the stored procedure here
@adtyp            varchar(50),
@adcatsource     varchar(50),
@adcatdesc      varchar(50),
@adsubcatsource     varchar(50),
@adsubcatdesc      varchar(50),
@adsubsubcatsource     varchar(50),
@adsubsubcatdesc      varchar(50),
@compcode        varchar(50),
@fromdate        datetime,
@todate         datetime,
@dateformat     varchar(50),
@uomsource      varchar(50),
@uomdesc         varchar(50),
@color           varchar(50),
@colorcop        varchar(50),
@percentage      varchar(50),
@pratecode      varchar(50),
@psourcerate     varchar(50),
@p_package_source  varchar(50),
@p_package_dest varchar(50)
AS
declare @rateuniqueid  varchar(100)
declare @newrateuniqueid varchar(100)
declare @rateuniqueidt   varchar(100)
declare @v_gr    int
declare @combindisc    varchar(5000)
declare @COU int
BEGIN
CREATE TABLE #RATEID
(
  EDITION_NAME  VARCHAR(500),
  RATEID        VARCHAR(1000),
  RATE          float,
  EXTRARATE     float,
  PERCENTAGE    VARCHAR(18)
)
CREATE TABLE #RESULT
(
  SEGMENTNUM    int,
  EDITION_NAME  VARCHAR(500)
)

if @p_package_source is not null 
begin
select @combindisc=Combin_Desc from combin_mast where Combin_Code=@p_package_source and Ad_Type_code = @adtyp
insert into #result(segmentnum, edition_name) 
select segmentnum,edition_name from FN_SPLITFIELD(@combindisc,'+')

update #result set edition_name=(select Combin_Code from combin_mast where Combin_Desc=rtrim(#result.edition_name) and Ad_Type_code = @adtyp)
insert into #result(edition_name) values(@p_package_source)
end


if(@psourcerate is not null) 
begin
print 'lata'
    if @p_package_source is not null    
        begin
				if @adsubcatsource is null 
					insert into #rateid(RATEID) select rateuniqueid from rate_mast where convert(varchar(12),Valid_From,101)= convert(varchar(12),@fromdate,101) and convert(varchar(12),Valid_to,101)=convert(varchar(12),@todate,101) and Adv_Cat_Code=@adcatsource and Uom=@uomsource and Color=@color
					and Rate_Mast_Code=@psourcerate and Combin_Code in(select edition_name from #result)--Combin_Code =p_package_source;
				else
				begin
				 if @adsubsubcatsource is null 
				  insert into #rateid(RATEID) select rateuniqueid from rate_mast where convert(varchar(12),Valid_From,101)= convert(varchar(12),@fromdate,101) and convert(varchar(12),Valid_to,101)=convert(varchar(12),@todate,101) and Adv_Cat_Code=@adcatsource and Adv_subcat_code=@adsubcatsource and Uom=@uomsource and Color=@color
					and Rate_Mast_Code=@psourcerate and Combin_Code in(select edition_name from #result)--Combin_Code =p_package_source;
				 else 
				 insert into #rateid(RATEID) select rateuniqueid from rate_mast where convert(varchar(12),Valid_From,101)= convert(varchar(12),@fromdate,101) and convert(varchar(12),Valid_to,101)=convert(varchar(12),@todate,101) and Adv_Cat_Code=@adcatsource and Adv_subcat_code=@adsubcatsource and Ad_Subcat4=@adsubsubcatsource and Uom=@uomsource and Color=@color
					and Rate_Mast_Code=@psourcerate and Combin_Code in(select edition_name from #result)--Combin_Code =p_package_source;
		         
				end    
        end
    else
    begin
    print 'lata1'
				 if @adsubcatsource is null 
					insert into #rateid(RATEID) select rateuniqueid from rate_mast where convert(varchar(12),Valid_From,101)= convert(varchar(12),@fromdate,101) and convert(varchar(12),Valid_to,101)= convert(varchar(12),@todate,101) and Adv_Cat_Code=@adcatsource and Uom=@uomsource and Color=@color and Rate_Mast_Code=@psourcerate
				 else
				 begin
					  if @adsubsubcatsource is null 
					 insert into #rateid(RATEID) select rateuniqueid from rate_mast where convert(varchar(12),Valid_From,101)= convert(varchar(12),@fromdate,101) and convert(varchar(12),Valid_to,101)= convert(varchar(12),@todate,101) and Adv_Cat_Code=@adcatsource and Adv_subcat_code=@adsubcatsource and Uom=@uomsource and Color=@color and Rate_Mast_Code=@psourcerate;
					 else
					 insert into #rateid(RATEID) select rateuniqueid from rate_mast where convert(varchar(12),Valid_From,101)= convert(varchar(12),@fromdate,101) and convert(varchar(12),Valid_to,101)= convert(varchar(12),@todate,101) and Adv_Cat_Code=@adcatsource and Adv_subcat_code=@adsubcatsource and Ad_Subcat4=@adsubsubcatsource and Uom=@uomsource and Color=@color and Rate_Mast_Code=@psourcerate;
				 end            
      end  
    end        

else
begin
print 'shiv'
    if @p_package_source is not null 
        begin
					 if @adsubcatsource is null 
						insert into #rateid(RATEID) select rateuniqueid from rate_mast where convert(varchar(12),Valid_From,101)= convert(varchar(12),@fromdate,101) and convert(varchar(12),Valid_to,101)= convert(varchar(12),@todate,101) and Adv_Cat_Code=@adcatsource  and Uom=@uomsource and Color=@color
						and Combin_Code in(select edition_name from #result);--Combin_Code =p_package_source;
					 else
					 begin
					  if @adsubsubcatsource is null 
					 insert into #rateid(RATEID) select rateuniqueid from rate_mast where convert(varchar(12),Valid_From,101)= convert(varchar(12),@fromdate,101) and convert(varchar(12),Valid_to,101)= convert(varchar(12),@todate,101) and Adv_Cat_Code=@adcatsource and Adv_subcat_code=@adsubcatsource and Uom=@uomsource and Color=@color
						and Combin_Code in(select edition_name from #result);--Combin_Code =p_package_source;
					 else
					 insert into #rateid(RATEID) select rateuniqueid from rate_mast where convert(varchar(12),Valid_From,101)= convert(varchar(12),@fromdate,101) and convert(varchar(12),Valid_to,101)= convert(varchar(12),@todate,101) and Adv_Cat_Code=@adcatsource and Adv_subcat_code=@adsubcatsource and Ad_Subcat4=@adsubsubcatsource and Uom=@uomsource and Color=@color
						and Combin_Code in(select edition_name from #result);--Combin_Code =p_package_source;
					 end
          end
        
		else
	
			begin
      	print 'shiv1'
				 if @adsubcatsource is null 
				 begin
				 	print 'shiv2'
					insert into #rateid(RATEID) select rateuniqueid from rate_mast where convert(varchar(12),Valid_From,101)= convert(varchar(12),@fromdate,101) and convert(varchar(12),Valid_to,101)= convert(varchar(12),@todate,101) and Adv_Cat_Code=@adcatsource and Uom=@uomsource and Color=@color;
				end	
				 else
				 begin
				 
					if @adsubsubcatsource is null 
						insert into #rateid(RATEID) select rateuniqueid from rate_mast where convert(varchar(12),Valid_From,101)= convert(varchar(12),@fromdate,101) and convert(varchar(12),Valid_to,101)= convert(varchar(12),@todate,101) and Adv_Cat_Code=@adcatsource and Adv_subcat_code=@adsubcatsource and Uom=@uomsource and Color=@color;
					else
						insert into rateid(RATEID) select rateuniqueid from rate_mast where convert(varchar(12),Valid_From,101)= convert(varchar(12),@fromdate,101) and convert(varchar(12),Valid_to,101)= convert(varchar(12),@todate,101) and Adv_Cat_Code=@adcatsource and Adv_subcat_code=@adsubcatsource and Ad_Subcat4=@adsubsubcatsource and Uom=@uomsource and Color=@color;       
				  end
         end 
        end
  
declare Rateforweb cursor
for SELECT RATEID FROM #RATEID
open Rateforweb

FETCH NEXT FROM Rateforweb
INTO @rateuniqueid
WHILE @@FETCH_STATUS = 0
BEGIN

if(@dateformat='mm/dd/yyyy') 
begin
     if(@pratecode is not null ) 
     begin
          if @adsubcatsource is null 
                    select  @newrateuniqueid=pub_center + @pratecode + Adv_Type_Code + @adcatdesc + Adv_subcat_code + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,101) + convert(varchar(12),Valid_To,101)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM from rate_mast where rateuniqueid=@rateuniqueid
          else
          begin
			 if @adsubsubcatsource is null 
				 select  @newrateuniqueid=pub_center + @pratecode + Adv_Type_Code + @adcatdesc + @adsubcatdesc + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,101) + convert(varchar(12),Valid_To,101)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM  from rate_mast where rateuniqueid=@rateuniqueid;
			  else
			  select  @newrateuniqueid=pub_center + @pratecode + Adv_Type_Code + @adcatdesc + @adsubcatdesc + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,101) + convert(varchar(12),Valid_To,101)  + @uomdesc + @adsubsubcatdesc + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM  from rate_mast where rateuniqueid=@rateuniqueid;
           end   
        end   
       else
       begin
                 if @adsubcatsource is null
                    select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + Adv_subcat_code + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,101) + convert(varchar(12),Valid_To,101)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium +cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM from rate_mast where rateuniqueid=@rateuniqueid;
                 else
                 begin
                  if @adsubsubcatsource is null 
                    select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + @adsubcatdesc + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,101) + convert(varchar(12),Valid_To,101)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM from rate_mast where rateuniqueid=@rateuniqueid;
                  else
                    select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + @adsubcatdesc + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,101) + convert(varchar(12),Valid_To,101)  + @uomdesc + @adsubsubcatdesc + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM from rate_mast where rateuniqueid=@rateuniqueid;
                  end  
        end   
	end
else if(@dateformat='dd/mm/yyyy') 
begin
     if(@pratecode is not null ) 
     begin
          if @adsubcatsource is null 
                    select  @newrateuniqueid=pub_center + @pratecode + Adv_Type_Code + @adcatdesc + Adv_subcat_code + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,103) + convert(varchar(12),Valid_To,103)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM from rate_mast where rateuniqueid=@rateuniqueid
          else
          begin
			 if @adsubsubcatsource is null 
				 select  @newrateuniqueid=pub_center + @pratecode + Adv_Type_Code + @adcatdesc + @adsubcatdesc + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,103) + convert(varchar(12),Valid_To,103)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM  from rate_mast where rateuniqueid=@rateuniqueid;
			  else
			  select  @newrateuniqueid=pub_center + @pratecode + Adv_Type_Code + @adcatdesc + @adsubcatdesc + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,103) + convert(varchar(12),Valid_To,103)  + @uomdesc + @adsubsubcatdesc + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM  from rate_mast where rateuniqueid=@rateuniqueid;
           end   
        end   
       else
       begin
                 if @adsubcatsource is null 
                    select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + Adv_subcat_code + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,103) + convert(varchar(12),Valid_To,103)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium +cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM from rate_mast where rateuniqueid=@rateuniqueid;
                 else
                 begin
                  if @adsubsubcatsource is null 
                    select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + @adsubcatdesc + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,103) + convert(varchar(12),Valid_To,103)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM from rate_mast where rateuniqueid=@rateuniqueid;
                  else
                    select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + @adsubcatdesc + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,103) + convert(varchar(12),Valid_To,103)  + @uomdesc + @adsubsubcatdesc + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM from rate_mast where rateuniqueid=@rateuniqueid;
                  end  
        end   
	end
else if(@dateformat='yyyy/mm/dd') 
begin
     if(@pratecode is not null ) 
     begin
          if @adsubcatsource is null 
                    select  @newrateuniqueid=pub_center + @pratecode + Adv_Type_Code + @adcatdesc + Adv_subcat_code + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,111) + convert(varchar(12),Valid_To,111)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM from rate_mast where rateuniqueid=@rateuniqueid
          else
          begin
			 if @adsubsubcatsource is null
				 select  @newrateuniqueid=pub_center + @pratecode + Adv_Type_Code + @adcatdesc + @adsubcatdesc + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,111) + convert(varchar(12),Valid_To,111)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM  from rate_mast where rateuniqueid=@rateuniqueid;
			  else
			  select  @newrateuniqueid=pub_center + @pratecode + Adv_Type_Code + @adcatdesc + @adsubcatdesc + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,111) + convert(varchar(12),Valid_To,111)  + @uomdesc + @adsubsubcatdesc + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM  from rate_mast where rateuniqueid=@rateuniqueid;
           end   
        end   
       else
       begin
                 if @adsubcatsource is null
                    select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + Adv_subcat_code + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,111) + convert(varchar(12),Valid_To,111)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium +cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM from rate_mast where rateuniqueid=@rateuniqueid;
                 else
                 begin
                  if @adsubsubcatsource is null 
                    select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + @adsubcatdesc + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,111) + convert(varchar(12),Valid_To,111)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM from rate_mast where rateuniqueid=@rateuniqueid;
                  else
                    select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + @adsubcatdesc + @colorcop + Combin_Code + Currency + convert(varchar(12),Valid_From,111) + convert(varchar(12),Valid_To,111)  + @uomdesc + @adsubsubcatdesc + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10)) + Client_cat + POSITION_PREM from rate_mast where rateuniqueid=@rateuniqueid;
                  end  
        end   
	end	
	
SELECT @COU=COUNT(*) FROM RATE_MAST where rateuniqueid=@newrateuniqueid
if(@COU<=0)	
begin
	if(@percentage is not null )
	begin
		if(@pratecode is not null )
		begin
		 insert into rate_mast("rateuniqueid", "Comp_code", "Rate_Mast_Code", "Adv_Type_Code", "Adv_Cat_Code", "Adv_subcat_code", "Rate_Gr_Code", "Currency", "combin_desc", "Combin_Code", "Uom", "Valid_From", "Valid_To", "Size_To", "Size_From", "consumption_Per","Color", "Col_chr_typ", "Remarks", "Week_Day_Rate", "Week_min_rate", "Week_Extra_Rate", "Focus_Day_Rate", "Focus_min_rate", "Focus_extra_rate", "userid", "Creation_DateTime", "Premium", "Premium_Charges", "weekend_rate", "weekend_min_rate", "weekend_extra", "chksolo", "min_ad_area", "Edition_from", "Edition_to", "floor_amount", "floor_discount", "Scheme_Name", "Ad_Subcat4", "Ad_Subcat5", "Ad_subcat6", "From_insertion", "To_insertion", "Agency_type", "Client_cat", "Max_Area","pub_center",SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH,PRIORITY, VAT_DETAIL, ADON, REF_ID, CANCELLATION_CHARGES,POSITION_PREM)
                            select @newrateuniqueid,"Comp_code",@pratecode,"Adv_Type_Code",@adcatdesc,
                            case when @adsubcatdesc='' then "Adv_subcat_code"
                            when @adsubcatdesc!='' then @adsubcatdesc end
                            ,"Rate_Gr_Code","Currency","combin_desc","Combin_Code",@uomdesc,"Valid_From","Valid_To","Size_To","Size_From","consumption_Per",@colorcop,"Col_chr_typ","Remarks",(cast("Week_Day_Rate" as float) + (cast("Week_Day_Rate" as float) * cast(@percentage as float)/100)),"Week_min_rate","Week_Extra_Rate","Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid",getdate(),"Premium","Premium_Charges","weekend_rate","weekend_min_rate","weekend_extra","chksolo","min_ad_area","Edition_from","Edition_to","floor_amount","floor_discount","Scheme_Name",
                            case when @adsubsubcatdesc='' then "Ad_Subcat4"
                            when @adsubsubcatdesc!='' then @adsubsubcatdesc end
                           
                            ,"Ad_Subcat5","Ad_subcat6","From_insertion","To_insertion","Agency_type","Client_cat","Max_Area","pub_center",SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH,PRIORITY, VAT_DETAIL, ADON, REF_ID, CANCELLATION_CHARGES,POSITION_PREM from rate_mast where "rateuniqueid" = @rateuniqueid;
                            set @rateuniqueidt=@rateuniqueid
                            insert into tbl_rate_priority(RATEUNIQUEID, EDITION_NAME, PRIORITYNO, RATE, EXTRARATE)
                            select @newrateuniqueid, EDITION_NAME, PRIORITYNO, RATE, EXTRARATE from tbl_rate_priority where rateuniqueid = @rateuniqueidt;
        end                    
        else
        begin
        insert into rate_mast("rateuniqueid", "Comp_code", "Rate_Mast_Code", "Adv_Type_Code", "Adv_Cat_Code", "Adv_subcat_code", "Rate_Gr_Code", "Currency", "combin_desc", "Combin_Code", "Uom", "Valid_From", "Valid_To", "Size_To", "Size_From", "consumption_Per","Color", "Col_chr_typ", "Remarks", "Week_Day_Rate", "Week_min_rate", "Week_Extra_Rate", "Focus_Day_Rate", "Focus_min_rate", "Focus_extra_rate", "userid", "Creation_DateTime", "Premium", "Premium_Charges", "weekend_rate", "weekend_min_rate", "weekend_extra", "chksolo", "min_ad_area", "Edition_from", "Edition_to", "floor_amount", "floor_discount", "Scheme_Name", "Ad_Subcat4", "Ad_Subcat5", "Ad_subcat6", "From_insertion", "To_insertion", "Agency_type", "Client_cat", "Max_Area","pub_center",SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH,PRIORITY, VAT_DETAIL, ADON, REF_ID, CANCELLATION_CHARGES,POSITION_PREM)
                            select @newrateuniqueid,"Comp_code","Rate_Mast_Code","Adv_Type_Code",@adcatdesc,
                            case when @adsubcatdesc='' then "Adv_subcat_code"
                            when @adsubcatdesc!='' then @adsubcatdesc end
                            ,"Rate_Gr_Code","Currency","combin_desc","Combin_Code",@uomdesc,"Valid_From","Valid_To","Size_To","Size_From","consumption_Per",@colorcop,"Col_chr_typ","Remarks",(cast("Week_Day_Rate" as float) + (cast("Week_Day_Rate" as float) * cast(@percentage as float)/100)),"Week_min_rate","Week_Extra_Rate","Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid",getdate(),"Premium","Premium_Charges","weekend_rate","weekend_min_rate","weekend_extra","chksolo","min_ad_area","Edition_from","Edition_to","floor_amount","floor_discount","Scheme_Name",
                             case when @adsubsubcatdesc='' then "Ad_Subcat4"
                            when @adsubsubcatdesc!='' then @adsubsubcatdesc end
                            ,"Ad_Subcat5","Ad_subcat6","From_insertion","To_insertion","Agency_type","Client_cat","Max_Area","pub_center",SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH,PRIORITY, VAT_DETAIL, ADON, REF_ID, CANCELLATION_CHARGES,POSITION_PREM from rate_mast where "rateuniqueid" = @rateuniqueid;
                            set @rateuniqueidt=@rateuniqueid;
                            insert into tbl_rate_priority(RATEUNIQUEID, EDITION_NAME, PRIORITYNO, RATE, EXTRARATE)
                            select @newrateuniqueid, EDITION_NAME, PRIORITYNO, RATE, EXTRARATE from tbl_rate_priority where rateuniqueid = @rateuniqueidt;                    
        end                    
	end
else	
	begin
	 if(@pratecode is not null )
		begin
                                                insert into rate_mast("rateuniqueid", "Comp_code", "Rate_Mast_Code", "Adv_Type_Code", "Adv_Cat_Code", "Adv_subcat_code", "Rate_Gr_Code", "Currency", "combin_desc", "Combin_Code", "Uom", "Valid_From", "Valid_To", "Size_To", "Size_From", "consumption_Per","Color", "Col_chr_typ", "Remarks", "Week_Day_Rate", "Week_min_rate", "Week_Extra_Rate", "Focus_Day_Rate", "Focus_min_rate", "Focus_extra_rate", "userid", "Creation_DateTime", "Premium", "Premium_Charges", "weekend_rate", "weekend_min_rate", "weekend_extra", "chksolo", "min_ad_area", "Edition_from", "Edition_to", "floor_amount", "floor_discount", "Scheme_Name", "Ad_Subcat4", "Ad_Subcat5", "Ad_subcat6", "From_insertion", "To_insertion", "Agency_type", "Client_cat", "Max_Area","pub_center",SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH,PRIORITY, VAT_DETAIL, ADON, REF_ID, CANCELLATION_CHARGES,POSITION_PREM)
                                                select @newrateuniqueid,"Comp_code",@pratecode,"Adv_Type_Code",@adcatdesc,
                                                case when @adsubcatdesc='' then "Adv_subcat_code"
												 when @adsubcatdesc!='' then @adsubcatdesc end
                                                ,"Rate_Gr_Code","Currency","combin_desc","Combin_Code",@uomdesc,"Valid_From","Valid_To","Size_To","Size_From","consumption_Per",@colorcop,"Col_chr_typ","Remarks","Week_Day_Rate","Week_min_rate","Week_Extra_Rate","Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid",getdate(),"Premium","Premium_Charges","weekend_rate","weekend_min_rate","weekend_extra","chksolo","min_ad_area","Edition_from","Edition_to","floor_amount","floor_discount","Scheme_Name",
                                                case when @adsubsubcatdesc='' then "Ad_Subcat4"
												when @adsubsubcatdesc!='' then @adsubsubcatdesc end
                                                ,"Ad_Subcat5","Ad_subcat6","From_insertion","To_insertion","Agency_type","Client_cat","Max_Area","pub_center",SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH,PRIORITY, VAT_DETAIL, ADON, REF_ID, CANCELLATION_CHARGES,POSITION_PREM from rate_mast where "rateuniqueid" = @rateuniqueid;
                                                set @rateuniqueidt=@rateuniqueid;
                                                insert into tbl_rate_priority(RATEUNIQUEID, EDITION_NAME, PRIORITYNO, RATE, EXTRARATE)
                                                select @newrateuniqueid, EDITION_NAME, PRIORITYNO, RATE, EXTRARATE from tbl_rate_priority where rateuniqueid = @rateuniqueidt;
		end
		else
		begin
                                                insert into rate_mast("rateuniqueid", "Comp_code", "Rate_Mast_Code", "Adv_Type_Code", "Adv_Cat_Code", "Adv_subcat_code", "Rate_Gr_Code", "Currency", "combin_desc", "Combin_Code", "Uom", "Valid_From", "Valid_To", "Size_To", "Size_From", "consumption_Per","Color", "Col_chr_typ", "Remarks", "Week_Day_Rate", "Week_min_rate", "Week_Extra_Rate", "Focus_Day_Rate", "Focus_min_rate", "Focus_extra_rate", "userid", "Creation_DateTime", "Premium", "Premium_Charges", "weekend_rate", "weekend_min_rate", "weekend_extra", "chksolo", "min_ad_area", "Edition_from", "Edition_to", "floor_amount", "floor_discount", "Scheme_Name", "Ad_Subcat4", "Ad_Subcat5", "Ad_subcat6", "From_insertion", "To_insertion", "Agency_type", "Client_cat", "Max_Area","pub_center",SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH,PRIORITY, VAT_DETAIL, ADON, REF_ID, CANCELLATION_CHARGES,POSITION_PREM)
                                                select @newrateuniqueid,"Comp_code","Rate_Mast_Code","Adv_Type_Code",@adcatdesc,
                                                 case when @adsubcatdesc='' then "Adv_subcat_code"
												 when @adsubcatdesc!='' then @adsubcatdesc end
                                                ,"Rate_Gr_Code","Currency","combin_desc","Combin_Code",@uomdesc,"Valid_From","Valid_To","Size_To","Size_From","consumption_Per",@colorcop,"Col_chr_typ","Remarks","Week_Day_Rate","Week_min_rate","Week_Extra_Rate","Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid",getdate(),"Premium","Premium_Charges","weekend_rate","weekend_min_rate","weekend_extra","chksolo","min_ad_area","Edition_from","Edition_to","floor_amount","floor_discount","Scheme_Name",
                                                 case when @adsubsubcatdesc='' then "Ad_Subcat4"
												when @adsubsubcatdesc!='' then @adsubsubcatdesc end
                                                ,"Ad_Subcat5","Ad_subcat6","From_insertion","To_insertion","Agency_type","Client_cat","Max_Area","pub_center",SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH,PRIORITY, VAT_DETAIL, ADON, REF_ID, CANCELLATION_CHARGES,POSITION_PREM from rate_mast where "rateuniqueid" = @rateuniqueid;
                                                set @rateuniqueidt=@rateuniqueid;
                                                insert into tbl_rate_priority(RATEUNIQUEID, EDITION_NAME, PRIORITYNO, RATE, EXTRARATE)
                                                select @newrateuniqueid, EDITION_NAME, PRIORITYNO, RATE, EXTRARATE from tbl_rate_priority where rateuniqueid = @rateuniqueidt;
		end                                        
                                        
	end
if(@percentage is not null )
begin
	if(@pratecode is not null )
     begin
                            insert into rate_details("ratemastid","rate_code","edition_name","Week_Day_Rate","Week_min_rate","Week_Extra_Rate",
                            "Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid","Creation_DateTime","Comp_Code","Solus_week_rate","Solus_focus_rate","weekend_rate","weekend_min","weekend_extra","Solo_weekendrate",
                            SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,PKGNAME)
                            select @newrateuniqueid,@pratecode,"edition_name",(cast("Week_Day_Rate" as float) + (cast("Week_Day_Rate" as float) * cast(@percentage as float)/100)),"Week_min_rate","Week_Extra_Rate","Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid","Creation_DateTime","Comp_Code",(cast("Solus_week_rate" as float) + (cast("Solus_week_rate" as float) * cast(@percentage as float)/100)),"Solus_focus_rate","weekend_rate","weekend_min","weekend_extra","Solo_weekendrate",SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,PKGNAME from rate_details where "ratemastid"=@rateuniqueid;

	end
    else
    begin
                            insert into rate_details("ratemastid","rate_code","edition_name","Week_Day_Rate","Week_min_rate","Week_Extra_Rate",
                            "Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid","Creation_DateTime","Comp_Code","Solus_week_rate","Solus_focus_rate","weekend_rate","weekend_min","weekend_extra","Solo_weekendrate",
                            SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,PKGNAME)
                            select @newrateuniqueid,"rate_code","edition_name",(cast("Week_Day_Rate" as float) + (cast("Week_Day_Rate" as float) * cast(@percentage as float)/100)),"Week_min_rate","Week_Extra_Rate","Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid","Creation_DateTime","Comp_Code",(cast("Solus_week_rate" as float) + (cast("Solus_week_rate" as float) * cast(@percentage as float)/100)),"Solus_focus_rate","weekend_rate","weekend_min","weekend_extra","Solo_weekendrate",SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,PKGNAME from rate_details where "ratemastid"=@rateuniqueid;

    end
end
  else
  begin
	if(@pratecode is not null )
    begin
                            insert into rate_details("ratemastid","rate_code","edition_name","Week_Day_Rate","Week_min_rate","Week_Extra_Rate",
                            "Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid","Creation_DateTime","Comp_Code","Solus_week_rate","Solus_focus_rate","weekend_rate","weekend_min","weekend_extra","Solo_weekendrate",
                            SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,PKGNAME)
                            select @newrateuniqueid,@pratecode,"edition_name","Week_Day_Rate","Week_min_rate","Week_Extra_Rate","Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid","Creation_DateTime","Comp_Code","Solus_week_rate","Solus_focus_rate","weekend_rate","weekend_min","weekend_extra","Solo_weekendrate",SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,PKGNAME from rate_details where "ratemastid"=@rateuniqueid;

   end
   else
   begin
                            insert into rate_details("ratemastid","rate_code","edition_name","Week_Day_Rate","Week_min_rate","Week_Extra_Rate",
                            "Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid","Creation_DateTime","Comp_Code","Solus_week_rate","Solus_focus_rate","weekend_rate","weekend_min","weekend_extra","Solo_weekendrate",
                            SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,PKGNAME)
                            select @newrateuniqueid,"rate_code","edition_name","Week_Day_Rate","Week_min_rate","Week_Extra_Rate","Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid","Creation_DateTime","Comp_Code","Solus_week_rate","Solus_focus_rate","weekend_rate","weekend_min","weekend_extra","Solo_weekendrate",SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,PKGNAME from rate_details where "ratemastid"=@rateuniqueid;

   end
 end	
end
FETCH NEXT FROM Rateforweb
	INTO @rateuniqueid
end	
CLOSE Rateforweb
DEALLOCATE Rateforweb

/*

if @uomsource!='0' and @adcatsource!='0'
begin
print '1'
insert into #RATEID(RATEID) select rateuniqueid from rate_mast 
where comp_code=@compcode and Valid_From = @fromdate and Valid_To=@todate 
and uom=@uomsource and adv_cat_code=@adcatsource
end
else if @uomsource='0' and @adcatsource!='0'
begin
insert into #RATEID(RATEID) select rateuniqueid from rate_mast 
where comp_code=@compcode and Valid_From = @fromdate and Valid_To=@todate 
and  adv_cat_code=@adcatsource
end
else if @uomsource!='0' and @adcatsource='0'
begin
insert into #RATEID(RATEID) select rateuniqueid from rate_mast 
where comp_code=@compcode and Valid_From = @fromdate and Valid_To=@todate 
and uom=@uomsource 
end
SELECT RATEID FROM #RATEID
declare Rateforweb cursor
for SELECT RATEID FROM #RATEID
open Rateforweb

FETCH NEXT FROM Rateforweb
INTO @rateuniqueid
WHILE @@FETCH_STATUS = 0
BEGIN
	 if(@dateformat='mm/dd/yyyy')
	begin
		if @uomdesc!='0' and @adcatdesc!='0'
			select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + Adv_subcat_code + Color + Combin_Code + Currency + convert(varchar(12),Valid_From,101) + convert(varchar(12),Valid_To,101)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10) ) + Client_cat  from rate_mast where rateuniqueid=@rateuniqueid
		else if @uomdesc!='0' and @adcatdesc='0'
			select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + adv_cat_code + Adv_subcat_code + Color + Combin_Code + Currency + convert(varchar(12),Valid_From,101) + convert(varchar(12),Valid_To,101)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10) ) + Client_cat  from rate_mast where rateuniqueid=@rateuniqueid
		else if @uomdesc='0' and @adcatdesc!='0'
			select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + Adv_subcat_code + Color + Combin_Code + Currency + convert(varchar(12),Valid_From,101) + convert(varchar(12),Valid_To,101)  + UOM + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10) ) + Client_cat  from rate_mast where rateuniqueid=@rateuniqueid
	end
	else  if(@dateformat='dd/mm/yyyy')
	begin
print '2'
		if @uomdesc!='0' and @adcatdesc!='0'
			select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + Adv_subcat_code + Color + Combin_Code + Currency + convert(varchar(12),Valid_From,103) + convert(varchar(12),Valid_To,103)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10) ) + Client_cat  from rate_mast where rateuniqueid=@rateuniqueid
		else if @uomdesc!='0' and @adcatdesc='0'
			select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + adv_cat_code + Adv_subcat_code + Color + Combin_Code + Currency + convert(varchar(12),Valid_From,103) + convert(varchar(12),Valid_To,103)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10) ) + Client_cat  from rate_mast where rateuniqueid=@rateuniqueid
		else if @uomdesc='0' and @adcatdesc!='0'
			select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + Adv_subcat_code + Color + Combin_Code + Currency + convert(varchar(12),Valid_From,103) + convert(varchar(12),Valid_To,103)  + UOM + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10) ) + Client_cat  from rate_mast where rateuniqueid=@rateuniqueid
	end
	else  if(@dateformat='yyyy/mm/dd')
	begin
		if @uomdesc!='0' and @adcatdesc!='0'
			select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + Adv_subcat_code + Color + Combin_Code + Currency + convert(varchar(12),Valid_From,111) + convert(varchar(12),Valid_To,111)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10) ) + Client_cat  from rate_mast where rateuniqueid=@rateuniqueid
		else if @uomdesc!='0' and @adcatdesc='0'
			select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + adv_cat_code + Adv_subcat_code + Color + Combin_Code + Currency + convert(varchar(12),Valid_From,111) + convert(varchar(12),Valid_To,111)  + @uomdesc + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10) ) + Client_cat  from rate_mast where rateuniqueid=@rateuniqueid
		else if @uomdesc='0' and @adcatdesc!='0'
			select  @newrateuniqueid=pub_center + Rate_Mast_Code + Adv_Type_Code + @adcatdesc + Adv_subcat_code + Color + Combin_Code + Currency + convert(varchar(12),Valid_From,111) + convert(varchar(12),Valid_To,111)  + UOM + Ad_Subcat4 + Ad_Subcat5 + Ad_subcat6 + Premium + cast(Size_From as varchar(10)) + cast(Size_To as varchar(10))   + cast(From_insertion as varchar(10)) + cast(To_insertion as varchar(10) ) + Client_cat  from rate_mast where rateuniqueid=@rateuniqueid
	end
SELECT @COU=COUNT(*)   FROM RATE_MAST where rateuniqueid=@newrateuniqueid
if(@COU<=0) 
begin
if @uomdesc!='0' and @adcatdesc!='0'
begin
insert into rate_mast(rateuniqueid, Comp_code, Rate_Mast_Code, Adv_Type_Code, Adv_Cat_Code, Adv_subcat_code, Rate_Gr_Code, Currency, combin_desc, Combin_Code, Uom, Valid_From, Valid_To, Size_To, Size_From, consumption_Per,Color, Col_chr_typ, Remarks, Week_Day_Rate, Week_min_rate, Week_Extra_Rate, Focus_Day_Rate, Focus_min_rate, Focus_extra_rate, userid, Creation_DateTime, Premium, Premium_Charges, weekend_rate, weekend_min_rate, weekend_extra, chksolo, min_ad_area, Edition_from, Edition_to, floor_amount, floor_discount, Scheme_Name, Ad_Subcat4, Ad_Subcat5, Ad_subcat6, From_insertion, To_insertion, Agency_type, Client_cat, Max_Area,pub_center,SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH)
select @newrateuniqueid,Comp_code,Rate_Mast_Code,Adv_Type_Code,@adcatdesc,Adv_subcat_code,Rate_Gr_Code,Currency,combin_desc,Combin_Code,@uomdesc,Valid_From,Valid_To,Size_To,Size_From,consumption_Per,Color,Col_chr_typ,Remarks,Week_Day_Rate,Week_min_rate,Week_Extra_Rate,Focus_Day_Rate,Focus_min_rate,Focus_extra_rate,userid,Creation_DateTime,Premium,Premium_Charges,weekend_rate,weekend_min_rate,weekend_extra,chksolo,min_ad_area,Edition_from,Edition_to,floor_amount,floor_discount,Scheme_Name,Ad_Subcat4,Ad_Subcat5,Ad_subcat6,From_insertion,To_insertion,Agency_type,Client_cat,Max_Area,pub_center,SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH from rate_mast where rateuniqueid = @rateuniqueid
end
else if @uomdesc!='0' and @adcatdesc='0'
begin
insert into rate_mast(rateuniqueid, Comp_code, Rate_Mast_Code, Adv_Type_Code, Adv_Cat_Code, Adv_subcat_code, Rate_Gr_Code, Currency, combin_desc, Combin_Code, Uom, Valid_From, Valid_To, Size_To, Size_From, consumption_Per,Color, Col_chr_typ, Remarks, Week_Day_Rate, Week_min_rate, Week_Extra_Rate, Focus_Day_Rate, Focus_min_rate, Focus_extra_rate, userid, Creation_DateTime, Premium, Premium_Charges, weekend_rate, weekend_min_rate, weekend_extra, chksolo, min_ad_area, Edition_from, Edition_to, floor_amount, floor_discount, Scheme_Name, Ad_Subcat4, Ad_Subcat5, Ad_subcat6, From_insertion, To_insertion, Agency_type, Client_cat, Max_Area,pub_center,SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH)
select @newrateuniqueid,Comp_code,Rate_Mast_Code,Adv_Type_Code,adv_cat_code,Adv_subcat_code,Rate_Gr_Code,Currency,combin_desc,Combin_Code,@uomdesc,Valid_From,Valid_To,Size_To,Size_From,consumption_Per,Color,Col_chr_typ,Remarks,Week_Day_Rate,Week_min_rate,Week_Extra_Rate,Focus_Day_Rate,Focus_min_rate,Focus_extra_rate,userid,Creation_DateTime,Premium,Premium_Charges,weekend_rate,weekend_min_rate,weekend_extra,chksolo,min_ad_area,Edition_from,Edition_to,floor_amount,floor_discount,Scheme_Name,Ad_Subcat4,Ad_Subcat5,Ad_subcat6,From_insertion,To_insertion,Agency_type,Client_cat,Max_Area,pub_center,SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH from rate_mast where rateuniqueid = @rateuniqueid
end
else if @uomdesc='0' and @adcatdesc!='0'
begin
insert into rate_mast(rateuniqueid, Comp_code, Rate_Mast_Code, Adv_Type_Code, Adv_Cat_Code, Adv_subcat_code, Rate_Gr_Code, Currency, combin_desc, Combin_Code, Uom, Valid_From, Valid_To, Size_To, Size_From, consumption_Per,Color, Col_chr_typ, Remarks, Week_Day_Rate, Week_min_rate, Week_Extra_Rate, Focus_Day_Rate, Focus_min_rate, Focus_extra_rate, userid, Creation_DateTime, Premium, Premium_Charges, weekend_rate, weekend_min_rate, weekend_extra, chksolo, min_ad_area, Edition_from, Edition_to, floor_amount, floor_discount, Scheme_Name, Ad_Subcat4, Ad_Subcat5, Ad_subcat6, From_insertion, To_insertion, Agency_type, Client_cat, Max_Area,pub_center,SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH)
select @newrateuniqueid,Comp_code,Rate_Mast_Code,Adv_Type_Code,@adcatdesc,Adv_subcat_code,Rate_Gr_Code,Currency,combin_desc,Combin_Code,Uom,Valid_From,Valid_To,Size_To,Size_From,consumption_Per,Color,Col_chr_typ,Remarks,Week_Day_Rate,Week_min_rate,Week_Extra_Rate,Focus_Day_Rate,Focus_min_rate,Focus_extra_rate,userid,Creation_DateTime,Premium,Premium_Charges,weekend_rate,weekend_min_rate,weekend_extra,chksolo,min_ad_area,Edition_from,Edition_to,floor_amount,floor_discount,Scheme_Name,Ad_Subcat4,Ad_Subcat5,Ad_subcat6,From_insertion,To_insertion,Agency_type,Client_cat,Max_Area,pub_center,SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH from rate_mast where rateuniqueid = @rateuniqueid
end
insert into rate_details(ratemastid,rate_code,edition_name,Week_Day_Rate,Week_min_rate,Week_Extra_Rate,
  Focus_Day_Rate,Focus_min_rate,Focus_extra_rate,userid,Creation_DateTime,Comp_Code,Solus_week_rate,Solus_focus_rate,weekend_rate,weekend_min,weekend_extra,Solo_weekendrate,
  SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,PKGNAME)
select @newrateuniqueid,rate_code,edition_name,Week_Day_Rate,Week_min_rate,Week_Extra_Rate,Focus_Day_Rate,Focus_min_rate,Focus_extra_rate,userid,Creation_DateTime,Comp_Code,Solus_week_rate,Solus_focus_rate,weekend_rate,weekend_min,weekend_extra,Solo_weekendrate,SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,PKGNAME from rate_details where ratemastid=@rateuniqueid
end
FETCH NEXT FROM Rateforweb
	INTO @rateuniqueid
end	
CLOSE Rateforweb
DEALLOCATE Rateforweb
*/
drop table #RATEID
drop table #RESULT

END


////////////////////////////////****************end************************/////////////////////////////////////////



/////////////////////******************************Issue No. 8974*****************///////////////////////////////////

CREATE procedure [dbo].[checkduplicayforEWRE]

@pcompcode      varchar(2000),
@peditioncode   varchar(2000)


AS 
begin

select   MAIN_EDITION_CODE from EDITIONWISERATIO_MAST
WHERE (Comp_Code=@pcompcode  ) AND (MAIN_EDITION_CODE=@peditioncode)
end


------------------------------------


CREATE  procedure [dbo].[deleteeditionwise_ratioentry]

@pcompcode       varchar(2000),
@pmaineditioncode  varchar(2000)


AS
begin 
delete from EDITIONWISERATIO_MAST  where COMP_CODE= @pcompcode   and MAIN_EDITION_CODE=@pmaineditioncode 

end
------------------------------------

CREATE  procedure [dbo].[modifyeditionwise_ratioentry]

@pcompcode           varchar(2000),
@puserid             varchar(2000),
@psubeditioncode     varchar(2000),
@pmaineditioncode    varchar(2000),
@ppercentage1        varchar(2000),
@peffectivedate      datetime


AS
begin 

update  EDITIONWISERATIO_MAST set PERCENTAGE=@ppercentage1, EFFECTIVE_DATE=@peffectivedate where COMP_CODE= @pcompcode   and MAIN_EDITION_CODE=@pmaineditioncode   and SUB_EDITION_CODE=@psubeditioncode


end

----------------------------------------------

CREATE procedure [dbo].[executeeditionwise_ratioentry]

@pcompcode       varchar(2000),
@peditioncode    varchar(2000),
@Pdateformat       varchar(2000)


AS 
begin

select COMP_CODE as "compcode" ,USERID as "userid", EDITION_NAME as "subedition", MAIN_EDITION_CODE as "editioncode",PUB_CODE as "pubcode",
CASE @pdateformat
               WHEN 'mm/dd/yyyy' THEN CONVERT(varchar(12),"EFFECTIVE_DATE", 103) 
               WHEN 'dd/mm/yyyy' THEN CONVERT(varchar(12),"EFFECTIVE_DATE", 101)
               WHEN 'yyyy/mm/dd' THEN CONVERT(varchar(12),"EFFECTIVE_DATE", 111)  END as "effectivedate",


PERCENTAGE as "per",SUB_EDITION_CODE as "subeditioncode" from EDITIONWISERATIO_MAST
WHERE (Comp_Code=@pcompcode  OR @pcompcode IS NULL)
AND (MAIN_EDITION_CODE=@peditioncode or @peditioncode IS NULL)
end 


-----------------------------------------------------------


CREATE PROCEDURE [dbo].[executemainedition_ratioentry]

@pcompcode      varchar(2000) ,
@peditioncode   varchar(2000)

AS
BEGIN
select distinct MAIN_EDITION_CODE  as "edition_code" from EDITIONWISERATIO_MAST
WHERE (Comp_Code=@pcompcode  OR @pcompcode IS NULL)
AND (MAIN_EDITION_CODE=@peditioncode or @peditioncode IS NULL or @peditioncode='0')

END

----------------------------------------------------------------------------

CREATE procedure [dbo].[saveeditionwise_ratioentry]

@pcompcode              varchar(2000),
@puserid                varchar(2000),
@ppubcode               varchar(2000),
@pmaineditioncode       varchar(2000),
@psubeditionname        varchar(2000),
@psubeditioncode        varchar(2000),
@ppercentage            int,
@peffectivedate         datetime


AS
begin

insert into  EDITIONWISERATIO_MAST (COMP_CODE, USERID, PUB_CODE, MAIN_EDITION_CODE, SUB_EDITION_CODE, EDITION_NAME, CREATION_DATETIME, EFFECTIVE_DATE, PERCENTAGE)
values(@pcompcode,@puserid,@ppubcode,@pmaineditioncode,@psubeditioncode,@psubeditionname, getdate() ,@peffectivedate,@ppercentage)
end 

-------------------------------------------------------------------------------

CREATE procedure [dbo].[BindMainEdition]

@pcompcode     varchar(2000)


AS
begin

select "Edition_Code","Edition_Alias"  from edition_mast where "Comp_Code"=@pcompcode and "Edition_Type"='Main Edition' 
end 

-----------------------------------------------------







/////////////////////******************************Issue No. 8974***END**************///////////////////////////////////



///////////////////////////////******************issue no 8863   anuj(23/oct/2012)*******//////////////////

CREATE TABLE [dbo].[EXECUTIVE_ADCOMM_TARGET](
	[COMP_CODE] [varchar](8) NOT NULL,
	[EXECUTIVE_CODE] [varchar](8) NOT NULL,
	[COMM_TARGET_ID] [numeric](10, 0) NOT NULL,
	[PUBL_CODE] [varchar](200) NULL,
	[NO_OF_PUBL] [numeric](3, 0) NULL,
	[ADCOMM_PER] [numeric](12, 2) NULL,
	[COMM_TYPE] [varchar](1) NULL,
	[CREATED_BY] [varchar](30) NULL,
	[CREATED_DT] [datetime] NULL,
	[UPDATED_BY] [varchar](30) NULL,
	[UPDATED_DT] [datetime] NULL,
	[ADD_COMM_ID] [numeric](18, 0) NOT NULL
)






--------------------------


CREATE
 PROCEDURE [dbo].[exeaddstatusbind]
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



------------------------------------------



CREATE
 PROCEDURE [dbo].[exeaddstatusbind]
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

-------------------------------


ALTER
 PROCEDURE [dbo].[exeaddstatusbind]
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



-----------------------------------


CREATE TABLE [dbo].[EXECUTIVE_COMM_SLAB](
	[COMP_CODE] [varchar](8) NULL,
	[EXE_CODE] [varchar](8) NULL,
	[ENLN] [numeric](18, 0) NULL,
	[FROM_DAYS] [numeric](10, 0) NULL,
	[TILL_DAYS] [numeric](10, 0) NULL,
	[COMM_ON] [varchar](8) NULL,
	[COMM_RATE] [numeric](10, 2) NULL,
	[CREATED_BY] [varchar](8) NULL,
	[CREATED_DATE] [datetime] NULL,
	[UPDATED_BY] [varchar](8) NULL,
	[UPDATED_DATE] [datetime] NULL,
	[COMM_TARGET_ID] [numeric](10, 0) NULL
)



--------------------------------




CREATE  PROCEDURE sp_exestatusbind_b


     @compcode      varchar(10),
      @execode      varchar(30),
      @userid     varchar(10),
      @commid      varchar(40)
     
 
   AS
   BEGIN
      
         SELECT *
           FROM executive_comm_slab
          WHERE "COMP_CODE" = @compcode
            AND "EXE_CODE" = @execode
            AND "COMM_TARGET_ID" = @commid;
--and "userid"=userid
   END 
 

----------------------------------


CREATE  PROCEDURE sp_exestatusbind_b


     @compcode      varchar(10),
      @execode      varchar(30),
      @userid     varchar(10),
      @commid      varchar(40)
     
 
   AS
   BEGIN
      
         SELECT *
           FROM executive_comm_slab
          WHERE "COMP_CODE" = @compcode
            AND "EXE_CODE" = @execode
            AND "COMM_TARGET_ID" = @commid;
--and "userid"=userid
   END 
 

-----------------------------------



USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[ad_execut_comm_target_bind]    Script Date: 10/23/2012 15:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER
 PROCEDURE [dbo].[ad_execut_comm_target_bind]
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


------------------------------


ALTER
 PROCEDURE [dbo].[ad_execut_comm_target_bind]
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


----------------------------------



ALTER
 PROCEDURE [dbo].[ad_execu_comm_target_ins]
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


---------------------------------------



ALTER
 PROCEDURE [dbo].[exeselectstructslab]
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


------------------------------



ALTER PROCEDURE [dbo].[execcontactbind_grid]

@teamcode as varchar(30),
@compcode as varchar(30),
@userid as varchar(30)

AS
declare @Designation1 varchar(350)
declare @Country_code1 as varchar(520)
declare @city_code1 varchar(250)
declare @report_to1 varchar(250)
declare @Exec_name as varchar(350)
declare @Designation varchar(350)
declare @Add1 varchar(505)
declare @Street varchar(505)
declare @city_code varchar(58)
declare @dist_code varchar(158)
declare @State_code varchar(158)

declare @Country_code as varchar(85)
declare @pin_code varchar(205)
declare @phone varchar(350)
declare @exe_status varchar(520)
declare @Exe_no varchar(205)
declare @TALUKACODE varchar(100)
declare @TALUKA2 varchar(385)
declare @city_name varchar(250)
declare @Team_code varchar(58)
declare @zip varchar(105)
declare @comp_code varchar(58)

declare @report_to varchar(85)
declare @exec_userid varchar(85)
declare @exec_emailid varchar(105)
declare @creation_datetime varchar(105)
declare @repname varchar(350);
declare @Repcode  varchar(350);
declare @Branch_code varchar(50);
declare @Branch_Name varchar(100);
declare @ATTACHMENT varchar(100);
declare @paymode varchar(100);
declare @query as varchar(4005)


--select ContractCode,Advcategory,publication,suppliment,edition,Bookedfor,color,cardrate,Dealarte,premiumcode,cardpremium,dealpremium,volumebilled,volumedisc,valuefrom,valueto,Uom,packagecode from contract_detail where comp_code=@compcode and userid=@userid and deal_code=@dealno
CREATE TABLE #tmpExec_mast  (
	Exe_no int  ,
	Team_code varchar (53)  ,
	Exec_name varchar (50)  ,
	Designation varchar (50)  ,
	Add1 varchar (60)  ,
	Street varchar (60)  ,
	Country_code varchar (38)  ,
	State_code varchar (38)  ,
	dist_code varchar (38)  ,
	city_code varchar (38)  ,
	zip varchar (30)  ,
	phone varchar (40)  ,
	exe_status varchar (50)  ,
	userid varchar (48)  ,
	comp_code varchar (48)  ,
	--creation_datetime datetime  ,
	pin_code varchar (40)  ,
	CIty_Name varchar (40)  ,
	report_to varchar (48) ,
    exec_userid varchar (100) ,
    exec_emailid varchar (80)   ,
    TALUKA  varchar (23) ,
    REPRESENTATIVE varchar (50),
    Branch_code varchar (20),
    ATTACHMENT varchar(100),
    PAYMENTMODE varchar(100)
) 

	
DECLARE sss CURSOR 
--FOR select distinct Advcategory,publication,suppliment,edition, currency,contractcode,color,uom,packagecode,premiumcode from contract_detail where comp_code=@compcode and userid=@userid and deal_code=@dealno
--FOR select Exec_name,Designation,Add1,Street,city_code,dist_code,State_code,Country_code,pin_code,phone,exe_status,Exe_no,city_name,Team_code,zip,comp_code,userid,report_to from Exec_mast where comp_code=@compcode  and Team_code =@teamcode
FOR select distinct  Designation,city_code,Country_code,report_to,Exe_no,TALUKA ,REPRESENTATIVE,Branch_code,ATTACHMENT,PAYMENTMODE  from Exec_mast where comp_code=@compcode  and Team_code =@teamcode



OPEN sss
FETCH NEXT FROM sss into @Designation,@city_code,@Country_code,@report_to,@Exe_no,@TALUKACODE,@Repcode,@Branch_code,@ATTACHMENT,@paymode


WHILE @@FETCH_STATUS = 0
BEGIN

select @Designation1=Agency_Role_Name from Agency_Role_Master where Agency_Role_Code=@Designation
select @city_code1=city_name from city_mst where city_code=@city_code
select @Country_code1=country_name from count_mst where country_code=@Country_code
select @Branch_Name=branch_name from branch_mst where branch_code=@Branch_code
if(@report_to <> '0')
begin
select @report_to1=Name_all from all_module_master where All_module_code=@report_to
end
else
begin
set @report_to1=''
end
select @TALUKA2=TALU_NAME  from taluka_mast where TALU_CODE=@TALUKACODE

select @repname=Rep_Name  from rep_mast where Rep_code=@Repcode





--insert into #tmpContract_detail select ContractCode,@Advcategoryname,@publicationname,@supplimentname,@editionname,Bookedfor,@packagecode,@colorname,cardrate,Dealarte,@premiumcode,cardpremium,dealpremium,volumebilled,volumedisc,valuefrom,valueto,@uomname, @currencyname, convertrate,deal_code,ContractCode,editionaldisc,approved,quantity,weight,discounted,Cyop,deviation from contract_detail where comp_code=@compcode and userid=@userid and deal_code=@dealno and contractcode=@contractcode

insert into #tmpExec_mast select distinct Exe_no,Team_code,Exec_name,@Designation1,Add1,Street,@Country_code1,State_code,dist_code,@city_code1,zip,phone,exe_status,userid,comp_code,pin_code,city_name,@report_to1,exec_userid,exec_emailid ,@TALUKA2 ,@repname as repname,@Branch_Name,@ATTACHMENT,@paymode from Exec_mast where comp_code=@compcode  and Team_code =@teamcode and Exe_no=@Exe_no
set @report_to1=''
set @EXEC_USERID=''
set @EXEC_EMAILID=''
set @TALUKA2=''
set @repname=''
FETCH NEXT FROM sss into @Designation,@city_code,@Country_code,@report_to,@Exe_no,@TALUKACODE,@Repcode,@Branch_code,@ATTACHMENT,@paymode
end
CLOSE sss
DEALLOCATE sss

--select * from #tmpContract_detail


--select *  from #tmpExec_mast


set @query='select  distinct Exe_no,Exec_name, Designation,Add1,Street, city_code,dist_code,State_code, Country_code,pin_code,phone,exe_status,Exe_no,city_name,Branch_code,report_to,exec_userid,exec_emailid ,TALUKA , REPRESENTATIVE as repname,ATTACHMENT,PAYMENTMODE from #tmpExec_mast'


--delete from #tmpExec_mast


print(@query)
exec(@query)
drop table #tmpExec_mast
--select ContractCode,Advcategory,publication,suppliment,edition,Bookedfor,packagecode,color,cardrate,Dealarte,premiumcode,cardpremium,dealpremium,volumebilled,volumedisc,valuefrom,valueto,Uom, currency, convertrate,deal_code,ContractCode from contract_detail where comp_code=@compcode and userid=@userid and deal_code=@dealno


-------------------------------------





ALTER
 PROCEDURE [dbo].[exeselectstructslab]
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




/////////////////////////***********(End of issue8863)****************///////////////////////////////////////////


/////////////////////**********(issue no 8816) anuj (23/oct/2012)anuj***********///////////////////////////



ALTER PROCEDURE [dbo].[ChkExecutiveCreditLimit] 
@pcompcode as varchar(20),
@puserid as varchar(20),
@pexecname as varchar(20),
@pciobookid as varchar(20),
@pgrossamt as float,
@pbillamt as float,
@ppaymode as varchar(20)
AS
declare @totbill float
declare @totbooking float
declare @finaltot float
declare @creditlimit float
declare @chkpref varchar(2)
declare @execpaymode varchar(50)
BEGIN
select @chkpref=executivecreditlimit from preferrences  where comp_code=@pcompcode and userid=@puserid
select @creditlimit=isnull(credit_limit,0) from exec_mast where exe_no=@pexecname
and charindex(@ppaymode,paymentmode)>0 
if @chkpref = '1' and @creditlimit>0
begin
select @totbill=sum(bill_amt) from tbl_booking_insert ,tbl_booking_mast
where insert_status not in('billed','cancel')
and tbl_booking_mast.cio_booking_id!=@pciobookid and 
tbl_booking_mast.executive_code=@pexecname and 
tbl_booking_insert.cio_booking_id=tbl_booking_mast.cio_booking_id
and bill_pay in(select Edition_Name from dbo.fn_SplitField(@execpaymode,','))
 group by tbl_booking_insert.cio_booking_id

select @totbooking=sum(bill_amt) from tbl_booking_insert 
where cio_booking_id=@pciobookid 
and insert_status not in('billed','cancel') group by tbl_booking_insert.cio_booking_id

set @finaltot=@totbill + @totbooking


if @totbooking > @creditlimit and @creditlimit>0
select 'N'
else
Select 'Y'
end
else
begin
Select 'Y'
end	

END



-------------------------------


ALTER FUNCTION [dbo].[ad_get_backdays_validate]
(
	@pcomp_code                               VARCHAR(4000) ,
	@pformname                                VARCHAR(4000) ,
	@puserid                                  VARCHAR(4000) ,
	@pentry_date                              datetime ,
	@pdateformat                              VARCHAR(4000) , 
	@pextra1                                  VARCHAR(4000) ,
	@pextra2                                  VARCHAR(4000) 
)
RETURNS CHAR 
AS 
	BEGIN
		
		DECLARE @v_user_backdays                          INT 
		DECLARE @v_comp_backdays                          INT 
		DECLARE @v_backdays                               INT 
		DECLARE @v_dt                                     DATETIME 
		DECLARE @v_curr_dt                                DATETIME 
		DECLARE @v_validate                               VARCHAR(1)                      
		SET @v_validate = 'N' 

		SELECT @v_dt  = @pentry_date
		select @v_curr_dt = CONVERT(VARCHAR(10), GETDATE(), 101)
		

		IF @v_curr_dt >= @v_dt and @v_dt is not null 
		BEGIN 
			SET @v_backdays  = DATEDIFF(dd,@v_curr_dt , @v_dt )
	
			DECLARE @adv_rowcount INT

			DECLARE @adv_error INT

			SELECT @v_comp_backdays  =  back_days FROM  preferrences WHERE	 comp_code  = @pcomp_code
			

			SELECT @adv_error = @@ERROR, @adv_rowcount=@@ROWCOUNT
			IF @adv_error != 0 
			BEGIN
				GOTO Exception2
			END

			GOTO ExitLabel2
			Exception2:
				
				IF @adv_rowcount = 0 
				BEGIN
				
				SELECT @v_comp_backdays  = 0 
				END
			ExitLabel2:
			
			SELECT @v_user_backdays  =  back_days FROM  module_detaibuttonl WHERE	 comp_code  = @pcomp_code AND	userid  = @puserid
			 AND	Form_Name  = @pformname
			

			SELECT @adv_error = @@ERROR, @adv_rowcount=@@ROWCOUNT
			IF @adv_error != 0 
			BEGIN
				GOTO Exception3
			END

			GOTO ExitLabel3
			Exception3:
				
				IF @adv_rowcount = 0 
				BEGIN
				
				SET @v_user_backdays  = @v_comp_backdays 
				/* SwisSQL (Oracle To SQL Server) : Manual Intervention to verify Exception is required */
				END
			ExitLabel3:
			IF ISNULL(@v_user_backdays, 0)>= @v_backdays 
			BEGIN 
				return 'Y'
			END
			ELSE
			BEGIN 
				return 'N'
			END
   
		END
		ELSE
		BEGIN 
			return 'N'
		END
   

		RETURN 'N'
	END















/////////////////////////********* end(issue 8816)******************///////////////////




/////////////////////////****************************Issue No. 8952*****************///////////////////////////////

ALTER PROCEDURE [dbo].[representative_summmery]
	@fromdate                                 VARCHAR(4000) ,
	@dateto                                   VARCHAR(4000) ,
	@compcode                                 VARCHAR(4000) ,
	@pub_name                                 VARCHAR(4000)                    = null ,
	@pub_cent                                 VARCHAR(4000) ,
	@DATEFORMAT                               VARCHAR(4000) ,
	@descid                                   VARCHAR(4000)                    = null ,
	@ascdesc                                  VARCHAR(4000)                    = null ,
	@adtyp                                    VARCHAR(4000) ,
	@VALUE                                    VARCHAR(4000) ,
	@execut                                   VARCHAR(4000) ,
	@team                                     VARCHAR(4000) ,
	@bill                                     VARCHAR(4000) ,
	@cl                                       VARCHAR(4000) ,
	@ag                                       VARCHAR(4000) ,
	@retainer                                 VARCHAR(4000) ,
	@rep                                      VARCHAR(4000) ,
	@puserid                                  VARCHAR(4000)                    = null ,
	@chk_access                               VARCHAR(4000)                    = null ,
	@pbrancode                                VARCHAR(4000) ,
	@pdistcode                                VARCHAR(4000) ,
	@pextra1                                  VARCHAR(4000) ,
	@pextra2                                  VARCHAR(4000) ,
	@pextra3                                  VARCHAR(4000) ,
	@pextra4                                  VARCHAR(4000) ,
	@pextra5                                  VARCHAR(4000) 
	--@p_accounts                               cur_type_new1.cursor_type OUTPUT set @v_frdt=convert(datetime,@pfromdate)
AS 
	DECLARE @LoopProcessingFlag BIT 
	BEGIN
		SET NOCOUNT ON
		
		DECLARE @vquery                                   VARCHAR(8000) 
		DECLARE @center                                   VARCHAR(50) 
		DECLARE @reg                                      VARCHAR(900) 
		DECLARE @from_date                                DATETIME 
		DECLARE @date_to                                  DATETIME 
		DECLARE @sortorder                                VARCHAR(100) 
		DECLARE @vquery1                                  VARCHAR(1000) 
		DECLARE @breakup                                  VARCHAR(8000) 
		DECLARE @breakgrp                                 VARCHAR(1000) 
		SET @LoopProcessingFlag = 0
		--IF ( @fromdate IS NOT NULL AND @dateto IS NULL ) 
		--BEGIN 
		--	SELECT @from_date  = CONVERT(datetime,@fromdate, 101)--@fromdate 
		--	SELECT @date_to  = CONVERT(datetime,@fromdate, 101)--@fromdate 
		--	SET @LoopProcessingFlag = 1
		--END
		--IF ( @fromdate IS NOT NULL AND @dateto IS NOT NULL )  AND (@LoopProcessingFlag = 0)
		--BEGIN 
		--	SELECT @from_date  = CONVERT(datetime,@fromdate, 101)--@fromdate 
		--	SELECT @date_to  = CONVERT(datetime,@dateto, 101)--@dateto 
		--END
   
		SET @LoopProcessingFlag = 0
		IF ( @descid IS NOT NULL ) 
		BEGIN 
			SELECT @sortorder  = @descid 
			SET @LoopProcessingFlag = 1
		END
		IF ( @ascdesc IS NOT NULL )  AND (@LoopProcessingFlag = 0)
		BEGIN 
			SELECT @sortorder  = @ascdesc 
		END
   
  
		------------------
		--Dbms_output.put_line(Vquery1);
		
		IF ( @descid IS NULL ) 
		BEGIN 
			IF ( @rep = '2' ) 
			BEGIN 
				SELECT @vquery1  = ' ORDER BY "Retainer" asc' 
			END
			ELSE
			BEGIN 
				SELECT @vquery1  = ' ORDER BY "Executive" asc' 
			END
   
		END
		ELSE
		BEGIN 
			SELECT @vquery1  = @vquery1 + 'order by "' + @descid + '"' 
			SELECT @vquery1  = @vquery1 + '' + @ascdesc + '' 
		END
    print('44444')
		SELECT @vquery  =  'SELECT  i."Cio_Booking_Id" AS "CIOID",  a."Agency_Name" AS "Agency", 
		 isnull((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "Client", 
		  (select COMBIN_MAST."Package_Name" from combin_mast where COMBIN_MAST."Combin_Code"  in(m."Package_code"))
		  AS "Package",  
		  CASE ''' + @DATEFORMAT + '''  
		  WHEN''mm/dd/yyyy'' THEN convert(varchar(10),"Insert_Date",101)  
		  WHEN''dd/mm/yyyy'' THEN convert(varchar(10),"Insert_Date",103)  
		    WHEN''yyyy/mm/dd'' THEN convert(varchar(10),"Insert_Date",111)   END AS "Ins.date" , 
		     m."Trade_disc" AS "Trade_disc" ,  m."Key_no" AS "Key" ,  m."RO_No" AS "Ro.No.", 
		     convert(varchar(10),m."RO_Date",103) AS "Ro.Date", 
		      i.BILL_NO as "BILL_NO",   i.BILL_DATE as "BILL_DATE",  
		       isnull(i."Bill_Amt",''0'') AS "Bill_Amt",  i."Remarks" as "Remarks",  
		       i.CAPTION as "CAPTION",  isnull(i."Card_Rate" ,''0'') AS "Card_Rate",
		         isnull(i."Agreed_Rate" ,''0'') AS "Agreed_Rate", 
(select EXEC_MAST."Exec_name" from exec_mast where  m."Executive_code"=EXEC_MAST."Exe_no") AS "Executive",
(select EXEC_MAST."CIty_Name" from exec_mast where  m."Executive_code"=EXEC_MAST."Exe_no") AS "ExecutiveCity", 
 (SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=i."Ad_Cat" ) as "Adcat", 
  (select Retainermaster."Retain_Alias" from Retainermaster where  m."RETAINER"=Retainermaster."Retain_Code") 
  as "Retainer",  
 (select city_mst."City_Name" from city_mst where  city_mst."City_Code"= (select Retainermaster."City_Code" from Retainermaster where  m."RETAINER"=Retainermaster."Retain_Code")) as "Retainercity",
  case (case "Agency_Type_Code" when ''IA0'' then  ''GOVT.'' when ''DA0'' then ''GOVT.'' end)
  when ''GOVT.'' then ''GOVT.''
  else (case a."State_Code" when ''ORISSA'' then ''LOCAL'' else ''NATIONAL'' end) end  AS "FinalGRP", 
  
  
   i."Edition" as "edition",  
   (SELECT dbo.initcap("Comp_Name") from comp_mst where "Comp_Code"=''' + @compcode + ''') AS "companyname", 
    getdate() as "Rundate",i."Height",i."Width",i."Size_Book", 
    u."Uom_Name" as uom,u."UOM_DESC" as uomdesc,i."No_Insert" as "NO_INSERT",m."No_of_insertion" as NO_OF_INSERTION   
     FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a,uom_mast u  
     
      
     WHERE m."Comp_code"=''' + @compcode + ''' AND m."cio_booking_id"=i."Cio_Booking_Id"  
     AND m."Agency_sub_code"=a."code_subcode"   
     AND m."cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null) 
      and  lower("Insert_Status") !=''cancel'' 
       and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=''' + @puserid + ''')
        and''' + @chk_access + '''=''1'')  or  (''' + @chk_access + '''=''0'') ) 
        
         AND (m."Ad_type_code"=''' + @adtyp + ''' OR''' + @adtyp + '''  IS NULL  or ''' + @adtyp + ''' ='''')  
         AND (i."Pub_Cent_Code"=''' + @pub_cent + ''' OR''' + @pub_cent + ''' IS NULL or ''' + @pub_cent + ''' ='''')  
         AND (m."Revenue_center"=''' + @pub_name + ''' OR''' + @pub_name + '''  IS NULL or ''' + @pub_name + '''='''')  
         AND (m."Executive_code"  =''' + @execut + ''' OR''' + @execut + '''  IS NULL or ''' + @execut + ''' ='''')  
         AND (m."Executive_code" in (select exec_mast."Exe_no" from exec_mast 
         where  EXEC_MAST."Team_code"  =''' + @team + ''' OR''' + @team + ''' IS NULL  or ''' + @team + '''='''') OR''' + @team + ''' IS NULL or ''' + @team + '''='''' )  
         AND ("Client_code"  =''' + @cl + ''' OR''' + @cl + ''' IS NULL or ''' + @cl + '''='''')  AND (m."Agency_code"  =''' + @ag + ''' 
         OR''' + @ag + ''' IS NULL or ''' + @ag + '''='''')  
         AND (m.RETAINER  =''' + @retainer + ''' OR''' + @retainer + ''' IS NULL or ''' + @retainer + '''='''')  
         AND ((''' + @rep + '''=''2'' and m."RETAINER" is not null and m."RETAINER"!=''0'' and m."RETAINER"!='''')
         or(''' + @rep + '''=''1'' and m."Executive_code" is not null and m."Executive_code" !=''0'' and m."Executive_code" !=''''))
          AND  "Insert_Date" BETWEEN''' + @fromdate + ''' AND''' + @dateto + '''  
         ' 
		SELECT @vquery  = @vquery + @vquery1 
		print(@vquery)
		EXEC (@vquery )

		SET NOCOUNT OFF

	END



------------------------------------------------------------




ALTER PROCEDURE [dbo].[representative](
@fromdate		as varchar(20),
@dateto			as varchar(20),
@compcode		as varchar(10),
@pub_name		as varchar(50)=null,
@pub_cent		as varchar(50),
@dateformat		as varchar(20),
@descid			as varchar(20)=null,
@ascdesc		as varchar(20)=null,
@adtyp			as varchar(50),
@value			as varchar(50),
@execut			as varchar(50),
@team			as varchar(50),
@bill			as varchar(50),
@cl				as varchar(50),
@ag				as varchar(50),
@retainer		as varchar(50),
@rep			as varchar(50),
@puserid		as varchar(10)=null,
@chk_access		as varchar(2),
@pbrancode		as varchar(200),
@pdistcode		as varchar(200),
@pextra1		as varchar(200),
@pextra2		as varchar(200),
@pextra3		as varchar(200),
@pextra4		as varchar(200),
@pextra5		as varchar(200))
AS
declare @Vquery		varchar(8000)
declare @center		varchar(50)
declare @reg		varchar(900)

declare @sortorder	varchar(100)
declare @Vquery1	varchar(1000)

declare @breakup	varchar(8000)
declare @breakgrp	varchar(1000)

BEGIN

IF(@descid IS NOT NULL and @descid<>'') begin
   set @sortorder=@descid 
End
else IF(@ascdesc IS NOT NULL  and @ascdesc<>'') begin
    set @sortorder=@ascdesc 
End 


if(@descid is null) begin
	if(@rep='2')begin
		set @Vquery1 = 'ORDER BY Retainer asc' 
	end
	else begin
		set @Vquery1 = 'ORDER BY Executive asc'
	end
end 
else begin
	set @Vquery1 = @Vquery1+'order by "'+@descid+'"'
	set @Vquery1 = @Vquery1 + ''+@ascdesc+''
end 


set @Vquery =  'SELECT  i.Cio_Booking_Id AS "CIOID",
a.Agency_Name AS "Agency",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=m.Client_code),m.Client_code)  AS "Client",
(select COMBIN_MAST.Package_Name from combin_mast where COMBIN_MAST.Combin_Code  in(m.Package_code))AS "Package",
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),Insert_Date,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),Insert_Date,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),Insert_Date,111) END AS "Ins.date" ,
 m.Key_no AS "Key" ,
m.RO_No AS "Ro.No.", 
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),m.RO_Date,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),m.RO_Date,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),m.RO_Date,111) END AS "Ro.Date",
isnull(i.Bill_Amt,''0'') AS "NetAmt",
(select EXEC_MAST.Exec_name from exec_mast where m.Executive_code=EXEC_MAST.Exe_no) AS "Executive",
(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=i.Ad_Cat) as "Adcat",
(select Retainermaster.Retain_Alias from Retainermaster where  m.RETAINER=Retainermaster.Retain_Code) as "Retainer",
case Agency_Type_Code
when(CASE Agency_Type_Code
WHEN ''IA0'' THEN ''GOVT.''
WHEN ''DA0'' THEN ''GOVT.'' end )
then
(CASE a.State_Code
WHEN ''ORISSA'' THEN ''LOCAL''
else ''NATIONAL'' end )end
AS "FinalGRP",
i.Edition as "edition",
(SELECT dbo.initcap(Comp_Name) from comp_mst where Comp_Code='''+@compcode+''') AS "companyname",
getdate() as "Rundate",

(select  "Branch_Name"  from branch_mst where m."branch"=  branch_mst."Branch_Code") as "Branch_Name",

(select  "Dist_Name"  from dist_mst where a."DISTRICT" =  dist_mst."Dist_Code") as "District_Name"

FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a
WHERE m.Comp_code='''+@compcode+''' AND
m.cio_booking_id=i.Cio_Booking_Id
AND m.Agency_sub_code=a.code_subcode 
 AND m.cio_booking_id not in(select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)
 and  lower(i.Insert_Status) !=''cancel''
and ((i.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )
AND  i.Insert_Date BETWEEN '''+@fromdate+''' AND '''+@dateto+'''
AND (('''+@rep+'''=''2'' and m.RETAINER is not null and m.RETAINER!=''0'' and m.RETAINER!='''')
or('''+@rep+'''=''1'' and m.Executive_code is not null and m.Executive_code !=''0'' and m.Executive_code!=''''))'

IF(@adtyp IS NOT NULL AND @adtyp<>'')BEGIN
	set @Vquery = @Vquery+' AND m.Ad_type_code='''+@adtyp+''' '
END

IF(@pub_cent IS NOT NULL AND @pub_cent<>'')BEGIN
	set @Vquery = @Vquery+' AND i.Pub_Cent_Code='''+@pub_cent+''' '
END

IF(@pub_name IS NOT NULL AND @pub_name<>'')BEGIN
	set @Vquery = @Vquery+' and m.Revenue_center='''+@pub_name+''' '
END

IF(@execut IS NOT NULL AND @execut<>'')BEGIN
	set @Vquery = @Vquery+' and m.Executive_code='''+@execut+''' '
end

IF(@team IS NOT NULL AND @team<>'')BEGIN
	set @Vquery = @Vquery+' and (m.Executive_code in (select exec_mast.Exe_no from exec_mast where  EXEC_MAST.Team_code  = '''+@team+''' OR '''+@team+''' IS NULL ) OR '''+@team+''' IS NULL )'
end

IF(@cl IS NOT NULL AND @cl<>'')BEGIN
	set @Vquery = @Vquery+' and m.Client_code  = '''+@cl+''''
end

IF(@ag IS NOT NULL AND @ag<>'')BEGIN
	set @Vquery = @Vquery+' and m.Agency_code  = '''+@ag+''''
end

IF(@retainer IS NOT NULL AND @retainer<>'')BEGIN
	set @Vquery = @Vquery+' and m.RETAINER  = '''+@retainer+''''
end

IF(@pdistcode IS NOT NULL AND @pdistcode<>'')BEGIN
	set @Vquery = @Vquery+' and a.district  = '''+@pdistcode+''''
end

IF(@pbrancode IS NOT NULL AND @pbrancode<>'')BEGIN
	set @Vquery = @Vquery+' and a.Branch_code  = '''+@pbrancode+''''
end

set @Vquery = @Vquery + @Vquery1

print(@Vquery)
exec(@Vquery)



END


/////////////////////////****************************END Issue No. 8952*****************///////////////////////////////


////////////////////////////*******************************ISSUE NO. 8893 ********************/////////////////////////////


CREATE  procedure [dbo].[schedulereport_checklist]
    @fromdate           varchar(2000),
    @dateto             varchar(2000),
    @compcode           varchar(2000),
    @pub_name           varchar(2000),
    @pub_cent           varchar(2000),
    @dateformat         varchar(2000),
    @descid             varchar(2000) =null,
    @ascdesc            varchar(2000) =null,
    @adtyp              varchar(2000),
    @adcatg             varchar(2000),
    @padsubcat          varchar(200),
    @edition_name       varchar(2000),
    @drpstatus          varchar(2000),
    @supplement_name    varchar(2000),
    @packagecode        varchar(2000),
    @editiondtl         varchar(2000),
    @puserid            varchar(2000) =null,
    @chk_access         varchar(2000) =null,
    @p_branch           varchar(2000) =null,
    @poth_branch_flag   varchar(2000),--Y for
    @p_uom              varchar(2000)  
    
    
    AS
DECLARE @query_upper         VARCHAR(8000)
DECLARE @vedtn            VARCHAR(8000)
DECLARE @query1                  VARCHAR(8000)
DECLARE @query_booked_by_others  VARCHAR(8000)
DECLARE @query_group         VARCHAR(8000)
DECLARE @query2              VARCHAR(8000)
DECLARE @vwherecl            VARCHAR(8000)    
DECLARE @query_not_pubdt     VARCHAR(8000)
DECLARE @v_gau               NUMERIC (17)
DECLARE @v_val               NUMERIC(4)
DECLARE @vs_gau              NUMERIC(4)
DECLARE @v_billed            NUMERIC(10)
DECLARE @v_booked_by_others  NUMERIC(10)
DECLARE @v_direct_cash       NUMERIC(10)
DECLARE @v_scheme_ads        NUMERIC(10)
DECLARE @v_fmg_ads           NUMERIC(10)
DECLARE @V_SCHEME_TYPE       varchar(50)
DECLARE @V_FMG_BILL          varchar(50)
BEGIN


set concat_null_yields_null off

    select @V_SCHEME_TYPE = BILL_SCHEME, @V_FMG_BILL = FMG_BILL_DIS from preferrences where "comp_code"=@compcode

  SET  @query_upper ='select distinct x.comp_code as "COMP_CODE",x.branch as "BRANCH",x.cioid as "CIOID",x.agency as "AGENCY",x.agency_city as "AGENCY_CITY",
    x.client  as "CLIENT",x.hue as "HUE",x.cardrate as "CARDRATE",x.agreedrate as "AGREEDRATE",x.special_disc_per as "SPECIAL_DISC_PER",
    x.caption as "CAPTION",x.key_no as "KEY_NO",x.RO_NO as "RO_NO",x.RATE_CODE as "RATE_CODE",
    x.pagepremium as "PAGEPREMIUM",x.pospremium as "POSPREMIUM",
    max(x.width)  as "WIDTH",max(x.depth) as "DEPTH",max(x.area) as "AREA",
    min(x.ins_date) as "INSERT_DATE" ,
    case '''+@dateformat+'''
    WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),min(x.ins_date),101)
    WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),min(x.ins_date),103)
    WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),min(x.ins_date),111)
     end
    as "INS_DATE" ,
    x.adcat as "ADCAT",x.adsubcat as "ADSUBCAT",x.adsubcat3 as "ADSUBCAT3",
    min(x.pageno) as "PAGENO",x.ratecd as "RATECD",x.uom as "UOM",x.uomdesc as "UOMDESC",x.booktype as "booktype",x."AUDIT" as "AUDIT",
    x.app_status as "APP_STATUS",x.app_user as "APP_USER",x.no_insert as "NO_INSERT",x.branch_name as "BRANCH_NAME",
    x.package_name AS "PACKAGE_NAME",x.edition as "EDITION",
    x.trade_disc as "TRADE_DISC",
    case when ISNULL(x.edtn_wise_bill_req,''N'')=''Y'' then 
        (select round(sum(tbl_booking_insert."Bill_Amt"), 2) from tbl_booking_insert
        where tbl_booking_insert."Cio_Booking_Id"=x."CIOID" and tbl_booking_insert."No_Insert"=x."NO_INSERT"
        and lower(tbl_booking_insert."Insert_Status") !=''cancel''and lower(tbl_booking_insert."Insert_Status") !=''hold''
        and "Edition"=x.edition)
    else
        (select sum(tbl_booking_insert."Bill_Amt") from tbl_booking_insert
        where tbl_booking_insert."Cio_Booking_Id"=x."CIOID" and tbl_booking_insert."No_Insert"=x."NO_INSERT"
        and lower(tbl_booking_insert."Insert_Status") !=''cancel''and lower(tbl_booking_insert."Insert_Status") !=''hold'')
    end as "BILL_AMT",
    x.bill_remarks as "BILL_REMARKS",x.bill_no as "BILL_NO",x.bill_date as "BILL_DATE",
       case '''+@dateformat+'''
    WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),x.bill_date,101)
    WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),x.bill_date,103)
    WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),x.bill_date,111) end
    as "BILLDATE" ,
    x.edition_name as "EDITION_NAME",x.no_of_insertion as "NO_OF_INSERTION",x.Bill_cycle as "BILL_CYCLE",
    x.bkdate as bkdate,x.exec_code as exec_code,case when (x.exec_code=''0'' or x.exec_code is null) then null else (select "Exec_name"  from exec_mast where "Exe_no"=x.exec_code) end as "EXECUTIVE_NAME",
    x.RETAINER as retainer,case when (x.RETAINER=''0'' or x.RETAINER is null) then null else (select "Retain_Name" from retainermaster where "Retain_Code"=x.retainer)  end as "RETAINER_NAME", 
    x.translation_code as "TRANSLATION_CODE",(select distinct charge_name from ad_charge_mast where ad_charge_mast.charge_code=x.translation_code and 
    comp_code=x.comp_code and x.bkdate between valid_from_date and valid_till_date) as translation_name,
    x.posprem_disc posprem_disc,x.translation_disc translation_disc, x.page_prem as page_prem,x.page_prem_per as page_prem_per,
    x.disc_on_page_prem as disc_on_page_prem,x.booking_type as "BOOKING_TYPE",
    case '''+@dateformat+'''
    WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),min(x.pubdt),101)
    WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),min(x.pubdt),103)
    WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),min(x.pubdt),111)
    end as "PUBDT"
    from('
  -- print(@query_upper)  
  SET  @query1 ='select distinct m."Comp_code" comp_code,m."branch" branch, m."cio_booking_id" cioid,a."Agency_Name" agency,(select "City_Name" from city_mst where "City_Code"=a."City_Code") agency_city,
    ISNULL((select "Cust_Name" from cust_mast where "Cust_Code"=m."Client_code" and m."Comp_code"=cust_mast."Comp_Code" ),m."Client_code")  client,
    c."Col_Alias" hue,m."Card_rate" as cardrate,ISNULL(m."Agrred_rate",''0'') as agreedrate,
    case when ISNULL(m.DISC_PREMIUM,''0'')=''0'' then ISNULL(m."Special_disc_per",0) else 0 end as special_disc_per,
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
    dbo.fetch_insert_package(m."Comp_code",m."cio_booking_id",i."No_Insert",''N'') package_name,
    dbo.fetch_publish_edtnname(m."Comp_code",m."cio_booking_id",
    case 
    when ISNULL(i."Insert_Date",'''+@fromdate+''')='''+@fromdate+''' 
    then ISNULL(i."Insert_Date",convert(varchar(10),'''+@fromdate+''',103)) 
    else convert(varchar(10),'''+@fromdate+''',103) end,null,null,null,'''+@dateformat+''',i."No_Insert",null) as edition,
    m."Trade_disc" as trade_disc,i."Bill_Amt" as bill_amt,m."Print_remark" bill_remarks,i.bill_no bill_no,i.bill_date bill_date,
    dbo.fetch_insert_center_edtn(m."Comp_code",m."cio_booking_id", '''+@pub_cent+''',i."No_Insert") as edition_name,
    m."No_of_insertion" NO_OF_INSERTION,m."Bill_cycle" "BILL_CYCLE",m."date_time" as bkdate,m."Executive_code" as exec_code,
    m.RETAINER as retainer, m.translation_code as translation_code,m.posprem_disc posprem_disc,m.translation_disc translation_disc,
    m."Page_prem" as page_prem,m."Prem_per" as page_prem_per,
    case when ISNULL(m.disc_premium,''0'')=''0'' then 0 else m."Special_disc_per" end as disc_on_page_prem,m."Booking_type" booking_type,
    a.edtn_wise_bill_req edtn_wise_bill_req,
    case when ISNULL(i."Insert_Date",convert(varchar(10),'''+@fromdate+''',103))=convert(varchar(10),'''+@fromdate+''',103) then ISNULL(i."Insert_Date",convert(varchar(10),'''+@fromdate+''',103)) else convert(varchar(10),'''+@fromdate+''',103) end as pubdt,
    i.package_code as pack_code,
    i."Edition_Code" as edtn_code
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,col_mast c,uom_mast u,branch_mst b,adv_cat_mast ac
    where m."Comp_code"='''+@compcode+''' and m."Comp_code"=i."Comp_Code" and ac."Comp_Code"=i."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
    i."Col_Code"=c."Col_Code" and b."Branch_Code"=m."branch" and ac."Adv_Cat_Code"=i."Ad_Cat"
    and lower(i."Insert_Status") not in(''cancel'',''hold'') and u."Uom_Code"=m."Uom_code"
    and not exists (select distinct ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
    and a.edtn_wise_bill_req=''N''';

IF(@p_branch IS NOT NULL )
begin
    --@query_booked_by_others  :=' union '+@query1+' AND m."branch"<>'''+@p_branch+'''';
    --@query1                  :=@query1+' AND m."branch"='''+@p_branch+'''';

  set  @query_booked_by_others  = ' union '+@query1+ ' and exists( select distinct ''x'' from tbl_booking_mast a, tbl_booking_insert b 
    where a."Comp_code"=b."Comp_Code" and a."cio_booking_id"=b."Cio_Booking_Id" and 
    a."cio_booking_id"=m."cio_booking_id" and b."No_Insert"=i."No_Insert" and b."Insert_Date" between '''+@fromdate+''' and '''+@dateto+''' AND a."branch"=ISNULL('''+@p_branch+''',a."branch"))';

END 

/*IF @fromdate IS NOT NULL and @dateto IS NOT NULL THEN 
    @vwherecl:=@vwherecl+'and ((i."Insert_Date" between '''+@fromdate+''' and '''+@dateto+''') or i."Insert_Date" is null) 
    and exists(select distinct ''x'' from tbl_booking_mast a, tbl_booking_insert b 
    where a."Comp_code"=b."Comp_Code" and a."cio_booking_id"=b."Cio_Booking_Id" and 
    a."cio_booking_id"=m."cio_booking_id" and b."No_Insert"=i."No_Insert" and b."Insert_Date" between '''+@fromdate+''' and '''+@dateto+''' AND a."branch"=ISNULL('''+@p_branch+''',a."branch"))';
END iF;*/

IF @fromdate IS NOT NULL and @dateto IS NOT NULL 
BEGIN 
    --@vwherecl:=@vwherecl+' and i."Insert_Date" between '''+@fromdate+''' and '''+dateto+'''';
   SET @query1  = @query1+' and ISNULL(a.edtn_wise_bill_req,''N'')=''N'' and i."Insert_Date" between '''+@fromdate+''' and '''+@dateto+'''';

END 

IF(@pub_name IS NOT NULL )
BEGIN
    SET @vwherecl=@vwherecl+' AND i."Publication_Code"='''+@pub_name+'''';
END 


IF(@adtyp IS NOT NULL) 
BEGIN
  SET  @vwherecl=@vwherecl+ ' AND m."Ad_type_code"='''+@adtyp+''' ';
END 


IF(@p_uom IS NOT NULL) BEGIN
  SET  @vwherecl=@vwherecl+ ' AND m."Uom_code"='''+@p_uom+''' ';
END 

IF(@adcatg IS NOT NULL) BEGIN
   SET @vwherecl=@vwherecl+ ' AND i."Ad_Cat" in ('''+@adcatg+''' )';
END 



/*IF(@padsubcat  IS NOT NULL) THEN
    @vwherecl:=@vwherecl+ ' AND i."Ad_Sub_Cat" in ('''+@padsubcat +''' )';
END IF;*/

IF(@edition_name IS NOT NULL ) BEGIN
   SET @vwherecl=@vwherecl+'  AND (i."Edition_Code"='''+@edition_name+''')'
END 

IF(@supplement_name IS NOT NULL ) BEGIN
   SET @vwherecl=@vwherecl+' AND (i."Supp_Code" ='''+@supplement_name+''' )';
END 

IF(@packagecode IS NOT NULL ) BEGIN
   SET @vwherecl=@vwherecl+' AND ('''+@packagecode+''' in (m."Package_code") )';
END 

IF(@pub_cent IS NOT NULL) BEGIN
   SET @query2='  AND i."Pub_Cent_Code"='''+@pub_cent+'''';
END 

SET @query_group =' )x group by x.comp_code,x.branch, x.cioid,x.agency,x.agency_city, x.client,x.hue,x.cardrate,x.agreedrate,x.special_disc_per,
x.caption,x.key_no ,x.RO_NO,x.RATE_CODE,x.pagepremium,x.pospremium,x.adcat,x.adsubcat ,x.adsubcat3 ,
x.ratecd ,x.uom,x.uomdesc,x.booktype,x."AUDIT",x.app_status ,x.app_user,x.no_insert,x.branch_name,
x.package_name,x.edition,x.trade_disc,x.bill_remarks,x.bill_no,x.bill_date,x.edition_name,x.no_of_insertion,x.Bill_cycle,
x.bkdate,x.exec_code,x.retainer, x.translation_code,x.posprem_disc,x.translation_disc, x.page_prem,x.page_prem_per,
x.disc_on_page_prem,x.booking_type,x.edtn_wise_bill_req,x.ins_date,x.pack_code,x.edtn_code';


SET @query_group=@query_group+' order by edition_name,package_name, cioid,insert_date';


/*delete from SEARCHTBL111;
insert into SEARCHTBL111 values('@query_upper '+@query_upper); commit;
insert into SEARCHTBL111 values('@query1 '+@query1); commit;
insert into SEARCHTBL111 values('@vwherecl '+vwherecl); commit;
insert into SEARCHTBL111 values('@query2 '+@query2); commit;
insert into SEARCHTBL111 values('@query_group '+@query_group); commit;*/
--insert into SEARCHTBL111 values('@query_booked_by_others '+@query_booked_by_others); commit;
--delete from test1;insert into test1(vstring,vstring2) values('schedule1 ',@query1+@vwherecl+@query2);
--insert into test1(vstring,vstring2) values(' schedule2 ',@query_booked_by_others+@vwherecl+@query2+@query_group);
--SELECT * from SEARCHTBL111




--select getdate()
/*
print('@query_upper')
print(@query_upper)
print('@@query1')
print(@query1)
print('@vwherecl')
print(@vwherecl)
print('@@@query2')
print(@query2)
print('@@@query_booked_by_others')
print(@query_booked_by_others)
print('@@@vwherecl')
print(@vwherecl)
print('@@@query2')
print(@query2)
print('@@@query_group')
print(@query_group)
*/
print('111')
print(@query_upper+@query1+@vwherecl+@query2)
print('222')
print(@query_booked_by_others+@vwherecl+@query2+@query_group)
exec (@query_upper+@query1+@vwherecl+@query2+@query_booked_by_others+@vwherecl+@query2+@query_group)
--exec (@query_upper+@query1+@vwherecl+@query2+@query_booked_by_others+@vwherecl+@query2+@query_group)
--insert into SEARCHTBL111 values(@query_upper+@query1+@vwherecl+@query2+@query_booked_by_others+@vwherecl+@query2+@query_group+@query_upper);


select @vedtn="Edition_Alias"   from edition_mast where ("Pub_Code"=@pub_name or @pub_name is null)  and "Edition_Type"='Main Edition';

--select * from SEARCHTBL111
select "Edition_Alias"  as "Editions"  from edition_mast where ("Pub_Code"=@pub_name or @pub_name is null)  and "Edition_Type"='Main Edition';
--insert into SEARCHTBL111 values(@vedtn+@query_upper)
IF @fromdate IS NOT NULL and @dateto IS NOT NULL 
BEGIN 
    --@vwherecl:=@vwherecl+' and i."Insert_Date" between '''+@fromdate+''' and '''+@dateto+'''';
    SET @query2 =@query2+'and i."Insert_Date" between '''+@fromdate+''' and '''+@dateto+'''';
END 
If ISNULL(@poth_branch_flag,'N')='Y' and (@pub_cent IS NOT NULL) 
BEGIN
    SET @query2=' AND m."branch"='''+@p_branch+''' AND not exists (select ''x'' from tbl_booking_insert where "Cio_Booking_Id"=m."cio_booking_id" and "No_Insert"=i."No_Insert" and "Pub_Cent_Code"='''+@pub_cent+''')';
    END
else
BEGIN
   SET  @query2=' AND 1=2 ';
End 




--print(@query_upper+@query1+@vwherecl+@query2+@query_group)

exec (@query_upper+@query1+@vwherecl+@query2+@query_group)
insert into SEARCHTBL111 values(@query_upper+@query1+@vwherecl+@query2+@query_group+@query_upper+@query1+@vwherecl+@query2+@query_group)

  SET  @query1='select distinct m."Comp_code" comp_code,m."branch" branch, m."cio_booking_id" cioid,a."Agency_Name" agency,(select "City_Name" from city_mst where "City_Code"=a."City_Code") agency_city,
    ISNULL((select "Cust_Name" from cust_mast where "Cust_Code"=m."Client_code" and m."Comp_code"=cust_mast."Comp_Code" ),m."Client_code")  client,
    c."Col_Alias" hue,m."Card_rate" as cardrate,ISNULL(m."Agrred_rate",''0'') as agreedrate,
    case when ISNULL(m.DISC_PREMIUM,''0'')=''0'' then ISNULL(m."Special_disc_per",0) else 0 end as special_disc_per,
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
    dbo.fetch_insert_package(m."Comp_code",m."cio_booking_id",i."No_Insert",''N'') package_name,
    dbo.fetch_publish_edtnname(m."Comp_code",m."cio_booking_id",case when ISNULL(i."Insert_Date",convert(varchar(10),'''+@fromdate+''',103))=convert(varchar(10),'''+@fromdate+''',103) then ISNULL(i."Insert_Date",convert(varchar(10),'''+@fromdate+''',103)) else convert(varchar(10),'''+@fromdate+''',103) end,i.package_code,'''+@pub_name+''',i."Edition_Code",'''+@dateformat+''',i."No_Insert",null) as edition,
    m."Trade_disc" as trade_disc,i."Bill_Amt" as bill_amt,m."Print_remark" bill_remarks,i.bill_no bill_no,i.bill_date bill_date,
    dbo.fetch_insert_center_edtn(m."Comp_code",m."cio_booking_id", '''+@pub_cent+''',i."No_Insert") as edition_name,
    m."No_of_insertion" NO_OF_INSERTION,m."Bill_cycle" "BILL_CYCLE",m."date_time" as bkdate,m."Executive_code" as exec_code,
    m.RETAINER as retainer, m.translation_code as translation_code,m.posprem_disc posprem_disc,m.translation_disc translation_disc,
    m."Page_prem" as page_prem,m."Prem_per" as page_prem_per,
    case when ISNULL(m.disc_premium,''0'')=''0'' then 0 else m."Special_disc_per" end as disc_on_page_prem,m."Booking_type" booking_type,
    a.edtn_wise_bill_req edtn_wise_bill_req,
    i."Insert_Date"as pubdt ,
    i.package_code as pack_code,
    i."Edition_Code" as edtn_code
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,col_mast c,uom_mast u,branch_mst b,adv_cat_mast ac
    where m."Comp_code"='''+@compcode+''' and m."Comp_code"=i."Comp_Code" and ac."Comp_Code"=i."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
    i."Col_Code"=c."Col_Code" and b."Branch_Code"=m."branch" and ac."Adv_Cat_Code"=i."Ad_Cat"
    and lower(i."Insert_Status") not in(''cancel'',''hold'') and u."Uom_Code"=m."Uom_code"
    and not exists (select distinct ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
    and i."Insert_Date" between '''+@fromdate+''' and '''+@dateto+'''  and m."branch"='''+@p_branch+''' and 
    a.edtn_wise_bill_req=''Y''';
    


exec (@query_upper+@query1+@vwherecl+@query_group)
insert into SEARCHTBL111 values(@query_upper+@query1+@vwherecl+@query_group+@query_upper); 
select @v_booked_by_others = count(distinct i."Cio_Booking_Id"+i."No_Insert")   from tbl_booking_mast m,tbl_booking_insert i
    where m."Comp_code"=@compcode and m."cio_booking_id"=i."Cio_Booking_Id" and
    not exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "Branch_Code"=ISNULL(@p_branch,"Branch_Code") and "pub_center"=@pub_cent) and
    m."Ad_type_code"=ISNULL(@adtyp,m."Ad_type_code") AND i."Insert_Date" BETWEEN @fromdate AND @dateto       
    and not exists(select 'x' from tbl_booking_mast where m."Comp_code"=@compcode and "prev_cioid" is not null and "prev_cioid"=m."cio_booking_id")
    AND i."Pub_Cent_Code"=ISNULL(@pub_cent,i."Pub_Cent_Code") AND m."Uom_code"=ISNULL(@p_uom,m."Uom_code")
    and lower(i."Insert_Status") not in('cancel' ,'hold');
print('1')
select @v_direct_cash =  sum(x.direct_cash_ads)   from
    (select count(distinct i."Cio_Booking_Id"+i."No_Insert") as direct_cash_ads from tbl_booking_mast m,tbl_booking_insert i
    where m."Comp_code"=@compcode and m."cio_booking_id"=i."Cio_Booking_Id" and
    exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "Branch_Code"=ISNULL(@p_branch,"Branch_Code")) and
    m."Ad_type_code"=ISNULL(@adtyp,m."Ad_type_code") AND i."Insert_Date" BETWEEN @fromdate AND  @dateto and i.bill_no is null
    AND m."Uom_code"=ISNULL(@p_uom,m."Uom_code") and exists (select 'x' from AD_DIRECT_CLIENT_AGENCY where m."Agency_sub_code"=ag_main_code+ag_sub_code and flag_type='D')
    AND m."Bill_pay"='CA0'
    and lower(i."Insert_Status") not in('cancel' ,'hold'))x; 
print('2')
if @V_FMG_BILL ='Exclude' 
BEGIN
    select @v_fmg_ads =  sum(x.fmg_ads)   from
        (select count(distinct i."Cio_Booking_Id"+i."No_Insert") as fmg_ads from tbl_booking_mast m,tbl_booking_insert i
        where m."Comp_code"=@compcode and m."cio_booking_id"=i."Cio_Booking_Id" and
        exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "Branch_Code"=ISNULL(@p_branch,"Branch_Code")) and
        m."Ad_type_code"=ISNULL(@adtyp,m."Ad_type_code") AND i."Insert_Date" BETWEEN @fromdate AND  @dateto and i.bill_no is null
        AND m."Uom_code"=ISNULL(@p_uom,m."Uom_code") AND m."Booking_type" in ('2','4','5','6')
        and lower(i."Insert_Status") not in('cancel' ,'hold') )x;
        print('3')
end 
    
if @V_SCHEME_TYPE='EXCLUDE'  or @V_SCHEME_TYPE='EXCULDE' 
BEGIN
    select @v_scheme_ads =  sum(x.scheme_ads)   from
        (select count(distinct i."Cio_Booking_Id"+i."No_Insert") as scheme_ads from tbl_booking_mast m,tbl_booking_insert i
        where m."Comp_code"=@compcode and m."cio_booking_id"=i."Cio_Booking_Id" and
        exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "Branch_Code"=ISNULL(@p_branch,"Branch_Code")) and
        m."Ad_type_code"=ISNULL(@adtyp,m."Ad_type_code") AND i."Insert_Date" BETWEEN @fromdate AND  @dateto and i.bill_no is null
        AND m."Uom_code"=ISNULL(@p_uom,m."Uom_code") AND i."Pai_Free_Ins"  ='N' AND m."Booking_type" not in ('2','4','5','6','7')
        and lower(i."Insert_Status") not in('cancel' ,'hold') and not exists (select 'x' from AD_DIRECT_CLIENT_AGENCY where m."Agency_sub_code"=ag_main_code+ag_sub_code 
        and flag_type='D')
        AND m."cio_booking_id" not in(select distinct m."Cio_Booking_Id" from tbl_booking_mast m,tbl_booking_insert i
where m."cio_booking_id"=i."Cio_Booking_Id" and "Insert_Date"<'1-jun-2012' and m."Uom_code"='RO0') )x;
print('4')
end       
    

SELECT CONVERT(varchar(10),GETDATE(),103),dbo.initcap("Comp_Name") as "COMP_NAME" ,ISNULL(@v_billed,0) as "ALREADY_BILLED", ISNULL(@v_booked_by_others,0) as "BOOKED_BY_OTHERS",
ISNULL(@v_direct_cash,0) as "DIRECT_CASH",(ISNULL(@v_fmg_ads,0)+ISNULL(@v_scheme_ads,0)) as "SCHEME_ADS"
from comp_mst where "Comp_Code"=@compcode;

--DELETE FROM MULTIPAGE_BREAK where sess_id=@@SPID

set concat_null_yields_null on
end 




------------------------------------------------------




CREATE function [dbo].[fetch_insert_package](
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


-------------------------------------------------


CREATE  FUNCTION [dbo].[FETCH_PUBLISH_EDTNNAME](
    @pcomp_cd    varchar(200),
    @pbkid       varchar(200),
    @ppubdate    datetime,
    @ppkgcode    varchar(200),
    @ppublcode   varchar(200),
    @pedtncode   varchar(200),
    @pdateformat varchar(200),
    @pexrta1     varchar(200),
    @pexrta2     varchar(200)) RETURNS VARCHAR(4000) as
    BEGIN
DECLARE @v_edtn    AS      varchar(20)
DECLARE @v_edtn_alias  AS  varchar(200)
DECLARE @v_edtn_name  AS   varchar(2000)

     DECLARE c1 CURSOR FOR 
        select distinct x."Edition_Code",x."Edition_Alias" 
        from
        (
        select distinct a."Edition_Code",e."Edition_Alias" from tbl_booking_insert a,edition_mast e
        where a."Comp_Code"=e."Comp_Code" and a."Edition_Code"=e."Edition_Code" and a."Cio_Booking_Id"=@pbkid and 
            a."Insert_Date"=@ppubdate and package_code=ISNULL(@ppkgcode,package_code) and a."Publication_Code"=ISNULL(@ppublcode,a."Publication_Code") and 
            a."Edition_Code"=ISNULL(@pedtncode,a."Edition_Code") and a."Insert_Status" not in('cancel','hold') 
            and a."No_Insert"=ISNULL(@pexrta1,a."No_Insert")
        union
        select distinct a."EDITION" as "Edition_Code",e."Edition_Alias" from tbl_booking_subedition a,edition_mast e
        where a."COMP_CODE"=e."Comp_Code" and a."EDITION"=e."Edition_Code" and a."CIOID"=@pbkid and 
            a."INSERTDATE"=@ppubdate and a."PUBLICATION"=@ppublcode and 
            a."EDITION"=@pedtncode and a."INSERTSTATUS" not in('cancel','hold')
            and a."NO_INSERT"=ISNULL(@pexrta1,a."NO_INSERT")
       )x
           

    
     open c1
        
        FETCH NEXT FROM c1 into @v_edtn,@v_edtn_alias
        
        WHILE (@@FETCH_STATUS = 0) 
        BEGIN;
    
        if @v_edtn_name is null 
        BEGIN
            SET @v_edtn_name=@v_edtn_alias
            END
        else
        BEGIN
            SET @v_edtn_name=@v_edtn_name +','+ @v_edtn_alias
        end    
  FETCH NEXT FROM c1 into @v_edtn,@v_edtn_alias
       END
    close C1


    return ISNULL(@v_edtn_name,'?')
END 


------------------------------------------

CREATE  function [dbo].[fetch_insert_center_edtn](
    @pcompcode       varchar(2),
    @pcioid          varchar(2),
    @ppub_cent_code  varchar(2),
    @pinsertion_no   numeric) returns varchar(2000)

as
begin
DECLARE @v_val  as varchar(2000);

declare @v_pack as  varchar(2000);
declare @v1_pack as varchar(2000)

 DECLARE C1 CURSOR FOR 

    select distinct "Edition" edtn from tbl_booking_insert 
        where "Comp_Code"=@pcompcode and "Cio_Booking_Id"=@pcioid and "No_Insert" =ISNULL(@pinsertion_no,"No_Insert") and 
        "Insert_Status"!='cancel' and "Pub_Cent_Code"= ISNULL(@ppub_cent_code,"Pub_Cent_Code");

--v1 C1%rowtype;

open C1
  FETCH NEXT FROM c1 into @v1_pack
    --fetch C1 into v1;
     WHILE (@@FETCH_STATUS = 0) 
        BEGIN
    
   --SET @v_pack=v1.edtn;
   if isnull(@ppub_cent_code,'N')='N' begin--for Package name
			select @v_pack="Edition_Name" from edition_mast where "Edition_Code"=@v1_pack
    end
    
    else Begin
			set @v_pack=@v1_pack
		end
    if (@v_val is null) 
    begin
     SET   @v_val=@v_pack
        end
    else
    begin
       SET @v_val=@v_val +','+ @v_pack
        end
   

      FETCH NEXT FROM C1 into @v1_pack
 end
    
close C1
--deallocate C1

return @v_val

END 


////////////////////////////*******************************END *** ISSUE NO. 8893 ********************/////////////////////////////



///////////////////**********************issue 8944 anuj(30/10/2012) *********************************/////////////////////////////////

CREATE TABLE [dbo].[tbl_booking_mast_Q](
	[date_time] [datetime] NOT NULL,
	[branch] [varchar](25) NOT NULL,
	[booked_by] [varchar](25) NOT NULL,
	[cio_booking_id] [varchar](50) NOT NULL,
	[prev_booking] [varchar](25) NOT NULL,
	[applied_by] [varchar](25) NOT NULL,
	[audit] [varchar](25) NULL,
	[RO_No] [varchar](40) NULL,
	[RO_Date] [datetime] NULL,
	[Caption] [varchar](500) NULL,
	[bill_status] [varchar](8) NOT NULL,
	[ro_status] [varchar](8) NULL,
	[Agency_code] [varchar](15) NULL,
	[Agency_address] [varchar](500) NULL,
	[Client_code] [varchar](100) NULL,
	[Client_address] [varchar](500) NULL,
	[Agency_sub_code] [varchar](20) NULL,
	[Dockit_no] [varchar](25) NULL,
	[Executive_code] [varchar](50) NULL,
	[Executive_zone] [varchar](50) NULL,
	[Product_code] [varchar](50) NULL,
	[Brand_code] [varchar](50) NULL,
	[Key_no] [varchar](50) NULL,
	[Bill_remarks] [varchar](500) NULL,
	[Print_remark] [varchar](500) NULL,
	[Package_code] [varchar](500) NOT NULL,
	[No_of_insertion] [int] NULL,
	[Insertion_date] [datetime] NULL,
	[Repeating_day] [varchar](8) NULL,
	[Ad_type_code] [varchar](8) NULL,
	[Ad_cat_code] [varchar](50) NULL,
	[Ad_sub_cat_code] [varchar](50) NULL,
	[Color_code] [varchar](8) NULL,
	[Uom_code] [varchar](8) NULL,
	[Page_position_code] [varchar](8) NULL,
	[Page_type_code] [varchar](100) NULL,
	[Page_no] [int] NULL,
	[Ad_size_type_code] [varchar](8) NULL,
	[Ad_size_height] [float] NULL,
	[Ad_size_width] [float] NULL,
	[Rate_code] [varchar](100) NULL,
	[Scheme_type_code] [varchar](18) NULL,
	[Currency_code] [varchar](8) NULL,
	[Agrred_rate] [float] NULL,
	[Agreed_amount] [float] NULL,
	[Special_discount] [float] NULL,
	[Space_discount] [float] NULL,
	[Special_charges] [float] NULL,
	[Agency_status] [varchar](15) NULL,
	[Agency_type] [varchar](25) NULL,
	[Agency_pay] [varchar](25) NULL,
	[Agency_credit] [int] NULL,
	[Total_area] [float] NULL,
	[Card_rate] [float] NULL,
	[Card_amount] [float] NULL,
	[Discount] [float] NULL,
	[Discount_per] [float] NULL,
	[Bill_cycle] [varchar](8) NULL,
	[Revenue_center] [varchar](50) NULL,
	[Bill_pay] [varchar](8) NULL,
	[Bill_height] [float] NULL,
	[Bill_width] [float] NULL,
	[Bill_to] [varchar](100) NULL,
	[Invoices] [int] NULL,
	[Vts] [int] NULL,
	[Bill_add] [varchar](500) NULL,
	[Trade_disc] [float] NULL,
	[Agency_out] [varchar](50) NULL,
	[Box_code] [varchar](50) NULL,
	[Box_no] [varchar](8) NULL,
	[Box_agency] [varchar](2) NULL,
	[Box_client] [varchar](2) NULL,
	[Box_address] [varchar](500) NULL,
	[Comp_code] [varchar](8) NOT NULL,
	[Userid] [varchar](8) NOT NULL,
	[Creation_datetime] [datetime] NOT NULL,
	[Booking_type] [varchar](8) NULL,
	[Tfn] [varchar](2) NULL,
	[Coupan_ad] [varchar](2) NULL,
	[Campaign] [varchar](50) NULL,
	[Bill_amount] [float] NULL,
	[Page_prem] [varchar](8) NULL,
	[Page_amount] [float] NULL,
	[Prem_per] [float] NULL,
	[Gross_amount] [float] NULL,
	[Ad_size_column] [float] NULL,
	[Bill_column] [float] NULL,
	[Bill_area] [float] NULL,
	[Special_disc_per] [float] NULL,
	[Space_disc_per] [float] NULL,
	[Paid_ins] [int] NULL,
	[Contract_rate] [float] NULL,
	[Deviation] [float] NULL,
	[Variant_code] [varchar](8) NULL,
	[Contract_name] [varchar](50) NULL,
	[Contract_type] [varchar](50) NULL,
	[Card_name] [varchar](100) NULL,
	[Card_type] [varchar](50) NULL,
	[Card_month] [varchar](8) NULL,
	[Card_year] [varchar](8) NULL,
	[Card_number] [varchar](20) NULL,
	[Receipt_no] [varchar](50) NULL,
	[Ad_Subcat3] [varchar](8) NULL,
	[Ad_Subcat4] [varchar](8) NULL,
	[Ad_subcat5] [varchar](8) NULL,
	[Bg_color] [varchar](8) NULL,
	[Bullet_code] [varchar](8) NULL,
	[Bullet_premium] [float] NULL,
	[Material_status] [varchar](8) NULL,
	[Receipt_date] [datetime] NULL,
	[prev_cioid] [varchar](100) NULL,
	[prev_receipt] [varchar](50) NULL,
	[prev_grossamt] [float] NULL,
	[Region] [varchar](8) NULL,
	[Variant] [varchar](8) NULL,
	[status] [varchar](50) NULL,
	[Colortype] [varchar](8) NULL,
	[Logo_H] [varchar](5) NULL,
	[Logo_W] [varchar](5) NULL,
	[Logo_color] [varchar](8) NULL,
	[Logo_Uom] [varchar](8) NULL,
	[SAPID] [varchar](50) NULL,
	[RETAINER] [varchar](50) NULL,
	[ADD_AGENCY_COMM] [varchar](8) NULL,
	[AUDIT_COMMENT] [varchar](2000) NULL,
	[MOBILENO] [varchar](100) NULL,
	[ADD_AGENCY_COMM_AMT] [varchar](50) NULL,
	[RETAINER_COMM] [varchar](50) NULL,
	[RETAINER_COMM_AMT] [varchar](50) NULL,
	[CASH_RECIEVED] [float] NULL,
	[CONT_GROSS] [float] NULL,
	[CIRAGENCY] [varchar](100) NULL,
	[CIRRATE] [varchar](50) NULL,
	[CIREDITION] [varchar](50) NULL,
	[CIRPUBLICATION] [varchar](50) NULL,
	[CIRAGENCY_SUBCODE] [varchar](50) NULL,
	[BARTER_TYPE] [varchar](50) NULL,
	[APP_STATUS] [varchar](50) NULL,
	[APP_REMARKS] [varchar](500) NULL,
	[APP_DATE] [datetime] NULL,
	[APP_USER] [varchar](50) NULL,
	[RODOCSTATUS] [varchar](25) NULL,
	[RO_COMMENT] [varchar](500) NULL,
	[PROOFREAD] [varchar](50) NULL,
	[CASHDISCOUNT] [float] NULL,
	[CASHDISCTYPE] [varchar](5) NULL,
	[ATTACHMENT1] [varchar](50) NULL,
	[ATTACHMENT2] [varchar](50) NULL,
	[DISC_PREMIUM] [varchar](50) NULL,
	[DOCTYPE] [varchar](20) NULL,
	[CHKTRADEDISC] [varchar](1) NULL,
	[CHK_DATE] [datetime] NULL,
	[CHK_AMT] [float] NULL,
	[CHK_BANK_NAME] [varchar](50) NULL,
	[OUR_BANK] [varchar](50) NULL,
	[CHK_NO] [varchar](50) NULL,
	[DEALERPANEL] [varchar](1) NULL,
	[DEALER_H] [float] NULL,
	[DEALER_W] [float] NULL,
	[DEALERTYPE] [varchar](1) NULL,
	[ACTIVE_AGREEDRATE] [int] NULL,
	[ACTIVE_AGREEDAMT] [int] NULL,
	[temp_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[LOCALGROSSAMT] [float] NULL,
	[LOCALBILLAMT] [float] NULL,
	[PACKAGE_TYPE] [varchar](5) NULL,
	[AD_REFID] [varchar](50) NULL,
	[RECEIPT_CURRENCY] [varchar](8) NULL,
	[CONV_CURR_RATE] [varchar](8) NULL,
	[REVISE_DATE] [datetime] NULL,
	[CLIENT_TYPE] [varchar](5) NULL,
	[TRANSLATION_CODE] [varchar](25) NULL,
	[TRANSLATION_PREMIUM] [float] NULL,
	[MODIFIED_AUDIT] [varchar](5) NULL,
	[CANCELLATION_CHARGE] [varchar](1) NULL,
	[bill_language1] [varchar](50) NULL,
	[bill_page_type] [varchar](50) NULL,
	[RATE_AUDIT_FLAG] [varchar](1) NULL,
	[RATE_AUDIT_IP] [varchar](20) NULL,
	[TRANSLATION_DISC] [varchar](10) NULL,
	[POSPREM_DISC] [varchar](10) NULL,
	[QUOTATIONFLAG] [varchar](1) NULL,
	[QUOTATIONREMARKS] [varchar](200) NULL,
	[CONTACT_PERSON] [varchar](50) NULL,
	[CONTACT_PERSON_EMAIL] [varchar](200) NULL,
 CONSTRAINT [PK_tbl_booking_mast_Q] PRIMARY KEY CLUSTERED 
(
	[cio_booking_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)




//////////////////////////////////////**************end of ****************************/////////////////////////////////////////////


//////////////////////////////start of rate audit 30 oct 2012*************by rahul/////////////////////////////////////



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[websp_bindorderwise] 
@fromdate as  varchar(100),
@todate as  varchar(100),
@date as  varchar(100),
@branch as  varchar(100),
@adtype as  varchar(100),
@publication as  varchar(100),
@pub_cent as  varchar(100),
@edition as  varchar(100),
@agency as  varchar(100),
@client as  varchar(100),
@branchnew as  varchar(100),
@v_retainer as  varchar(100),
@v_executive as  varchar(100),
@v_supplement as  varchar(100),
@v_insert_status as  varchar(100),
@userid as varchar(100),
@v_payment_mode as varchar(100)

 AS



declare @query1 as varchar(8000)
declare @VAR_DATE as varchar(8000)
declare @VAR_DATE1 as varchar(8000)

set @VAR_DATE1=convert(varchar(100),@todate,103)


--SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@mydate)),@mydate),101) ,
--SELECT @VAR_DATE1= 
--select @VAR_DATE1= DATEADD(s,0,DATEADD(mm, DATEDIFF(m,0,@todate),0)) FirstDay_CurrentMonth
--print(@VAR_DATE1)



--select CONVERT(VARCHAR(25),DATEADD(s,0,DATEADD(mm, DATEDIFF(m,0,@VAR_DATE1),0)),101) FirstDay_CurrentMonth
--print(@VAR_DATE1)

--set @VAR_DATE=@todate
if(@v_insert_status ='publish')
begin

set @query1='select distinct tbl_booking_insert.Cio_Booking_Id as cio_booking_id,
isnull((select distinct cust_mast.Cust_Alias from cust_mast  where  cust_mast.Cust_Code=tbl_booking_mast.Client_code),Client_code) as client,
AGENCY_MAST.Agency_Name as Agency,
tbl_booking_mast.Gross_amount as gross_amount,
CASE '''+@date+'''
 WHEN ''mm/dd/yyyy'' THEN convert(varchar(100),Insertion_date,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(100),Insertion_date,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(100),Insertion_date,103)  END AS "Ins.date",
tbl_booking_mast.RO_No,
COL_MAST.Col_Alias as Col_Name,
tbl_booking_MAST.Ad_size_type_code    AS   Size_Book,
tbl_booking_MAST .Agrred_rate     AS Agreed_Rate,
tbl_booking_MAST . Bill_amount  AS   Bill_Amt,
Ad_size_height AS Height, Ad_size_width AS Width,

(SELECT count(tbl_booking_insert.Insert_Id) FROM  tbl_booking_insert WHERE tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id AND
Insert_Date between '''+@fromdate+''' and '''+CONVERT(VARCHAR(25),DATEADD(s,0,DATEADD(mm, DATEDIFF(m,0,@VAR_DATE1),0)),101) +'''   and  TBL_BOOKING_INSERT.Insert_Status ! =''cancel''  and  TBL_BOOKING_INSERT.Insert_Status not in (''audit by rate'',''billed'') )as TotalCount


,(SELECT count(tbl_booking_insert.Insert_Id) FROM  tbl_booking_insert WHERE tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id AND
Insert_Date between '''+@fromdate+''' and '''+CONVERT(VARCHAR(25),DATEADD(s,0,DATEADD(mm, DATEDIFF(m,0,@VAR_DATE1),0)),101) +'''  and  TBL_BOOKING_INSERT.Insert_Status =''publish''  and  TBL_BOOKING_INSERT.Insert_Status ! =''cancel'' and  TBL_BOOKING_INSERT.Insert_Status ! =''audit by rate'' )as PublishCount



from tbl_booking_insert,
tbl_booking_mast,
COL_MAST,
agency_mast where tbl_booking_mast .cio_booking_id=tbl_booking_insert.Cio_Booking_Id  and
 TBL_BOOKING_MAST.Color_code=COL_MAST.Col_Code  AND
 agency_mast.code_subcode=tbl_booking_mast.Agency_sub_code';

end 



if(@v_insert_status ='audit by rate')
begin

set @query1='select distinct tbl_booking_insert.Cio_Booking_Id as cio_booking_id,
isnull((select distinct cust_mast.Cust_Alias from cust_mast  where  cust_mast.Cust_Code=tbl_booking_mast.Client_code),Client_code) as client,
AGENCY_MAST.Agency_Name as Agency,
tbl_booking_mast.Gross_amount as gross_amount,
CASE '''+@date+'''
 WHEN ''mm/dd/yyyy'' THEN convert(varchar(100),Insertion_date,101)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(100),Insertion_date,103)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(100),Insertion_date,103)  END AS "Ins.date",
tbl_booking_mast.RO_No,
COL_MAST.Col_Alias as Col_Name,
tbl_booking_MAST.Ad_size_type_code    AS   Size_Book,
tbl_booking_MAST .Agrred_rate     AS Agreed_Rate,
tbl_booking_MAST . Bill_amount  AS   Bill_Amt,
Ad_size_height AS Height, Ad_size_width AS Width,

(SELECT count(tbl_booking_insert.Insert_Id) FROM  tbl_booking_insert WHERE tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id AND
Insert_Date between '''+@fromdate+''' and '''+CONVERT(VARCHAR(25),DATEADD(s,0,DATEADD(mm, DATEDIFF(m,0,@VAR_DATE1),0)),101)+'''   and  TBL_BOOKING_INSERT.Insert_Status ! =''cancel'' ) as TotalCount


,(SELECT count(tbl_booking_insert.Insert_Id) FROM  tbl_booking_insert WHERE tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id AND
Insert_Date between '''+@fromdate+''' and '''+CONVERT(VARCHAR(25),DATEADD(s,0,DATEADD(mm, DATEDIFF(m,0,@VAR_DATE1),0)),101)+''' and  TBL_BOOKING_INSERT.Insert_Status =''audit by rate''  and  TBL_BOOKING_INSERT.Insert_Status ! =''cancel'' )as PublishCount



from tbl_booking_insert,
tbl_booking_mast,
COL_MAST,
agency_mast where tbl_booking_mast .cio_booking_id=tbl_booking_insert.Cio_Booking_Id  and
 TBL_BOOKING_MAST.Color_code=COL_MAST.Col_Code  AND
 agency_mast.code_subcode=tbl_booking_mast.Agency_sub_code';

end 








if(@v_insert_status <> null or @v_insert_status <> '')
begin
set @query1=@query1 +' AND TBL_BOOKING_insert. Insert_Status ='''+@v_insert_status+''' '
end 







IF(@v_retainer   <> NULL or @v_retainer <> '' and @v_retainer <> '0')
begin
set @query1=@query1 +' and tbl_booking_mast .RETAINER='''+@v_retainer+'''';
END 


IF(@v_executive   <> NULL or @v_executive <> '')
begin
set @query1=@query1 +' and tbl_booking_mast .Executive_code='''+@v_executive+'''';
END 




IF(@v_supplement   <> NULL or @v_supplement <> '')
begin
set @query1=@query1 +'  and TBL_BOOKING_insert .Supp_Code='''+@v_supplement+'''';
END





IF(@branchnew   <> NULL or @branchnew <> '')
begin
set @query1=@query1 +'  and tbl_booking_mast .Branch='''+@branchnew+'''';
END 



IF(@client <> NULL or @client <> '')
begin
set @query1=@query1 +'  and tbl_booking_mast .Client_code='''+@client+'''';
END





IF(@pub_cent <> NULL or @pub_cent <> '' )
begin

set @query1=@query1 +'   and TBL_BOOKING_MAST.branch IN (SELECT Branch_CODE FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=branch_Code and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code='''+@pub_cent+'''))';

END 


IF(@agency <> NULL or @agency <> '')
begin
set @query1=@query1 +'   and  TBL_BOOKING_MAST.agency_sub_code ='''+@agency+'''';
END 







IF(@publication  <> NULL or @publication <> '')
begin
set @query1=@query1 +'  and  TBL_BOOKING_insert.Publication_Code='''+@publication+'''';
END




IF(@adtype  <> NULL or @adtype <> '')
begin
set @query1=@query1 +' and TBL_BOOKING_MAST. Ad_type_code ='''+@adtype+'''';
END 

IF(@fromdate  <> '' AND @todate  <> '' )
begin
set @query1=@query1 +'  and Insert_Date between  '''+@fromdate+''' and  '''+@todate+''' ';
END 

IF(@edition  <> NULL or   @edition <> '')
begin
set @query1=@query1 +'   and tbl_booking_insert.Edition_Code='''+@edition+'''';
END 

if(@v_payment_mode <> null or @v_payment_mode <>'')
begin
set @query1=@query1+' and tbl_booking_mast.bill_pay='''+@v_payment_mode+''''
end


print(@query1)
exec(@query1)

////////////////////////////////////////////////end of rate audit////////////////////////////////////////////////////////////////


////////////////////////////////start/////////////book audit 30 oct 2012////////////////////////////////////////

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




ALTER  PROCEDURE [dbo].[bindaudit]
	@fromdate                                 VARCHAR(4000) ,
	@todate                                   VARCHAR(4000) ,
	@date                                    VARCHAR(4000) ,
	@BRANCH1                                  VARCHAR(4000) ,
	@Adtype                                   VARCHAR(4000) ,
	@audittype                                VARCHAR(4000) ,
	@branch2                                  VARCHAR(4000) ,
	@v_Cat                                    VARCHAR(4000) ,
	@v_userid                                 VARCHAR(4000) ,
	@comp_code                                VARCHAR(4000) ,
	@v_package_code                           VARCHAR(4000) ,
	@pagency_code                             VARCHAR(4000) ,
	@pclient_code                             VARCHAR(4000) ,
	@psection_code                            VARCHAR(4000) ,
	@p_booktype                               VARCHAR(4000) ,
	@extra1                                   VARCHAR(4000) ,
	@extra2                                   VARCHAR(4000) ,
	@extra3                                   VARCHAR(4000) ,
	@extra4                                   VARCHAR(4000)
AS 
	BEGIN
		SET NOCOUNT ON
		
		DECLARE @v_branch1                                VARCHAR(50) 
		DECLARE @v_branch2                                VARCHAR(50) 
		DECLARE @v_approval_req                           VARCHAR(1) 
			DECLARE @v_query                                  VARCHAR(8000) 
		DECLARE @v_wherecl                                VARCHAR(5000) 
		DECLARE @v_query_group                            VARCHAR(5000) 
		IF @BRANCH1 = 'All' 
		BEGIN 
			SELECT @v_branch1  = null 
		END
		ELSE
		BEGIN 
			SELECT @v_branch1  = @BRANCH1 
		END
   
		IF @branch2 = 'All' 
		BEGIN 
			SELECT @v_branch2  = null 
		END
		ELSE
		BEGIN 
			SELECT @v_branch2  = @branch2 
		END
   
		SELECT @v_approval_req  = 'N' 
		SELECT @v_approval_req  =  relauthreqon
		FROM  preferrences 
		WHERE	 comp_code  = @comp_code
		
		SELECT @v_query  = 'SELECT distinct m."cio_booking_id" as "cio_booking_id",          
		isnull ((SELECT distinct  "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),          
		m."Client_code") AS "Client_code",          m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",
		m."Receipt_no" as "Receipt_no",          (SELECT top 1 "File_Name" FROM tbl_booking_insert          
		WHERE "Cio_Booking_Id" =m."cio_booking_id" AND "File_Name" IS NOT NULL ) AS "FILENAME",
		           CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m. Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime"
        ,m.ATTACHMENT1 as ATTACHMENT,          
         dbo.AD_GETAGENCY_ADD(''' + @comp_code + ''',m."cio_booking_id",''A'') as "Agency_Remark",          
         dbo.AD_GETAGENCY_ADD(''' + @comp_code + ''',m."cio_booking_id",''C'') as "Client_Remark",         
          case when''' +@v_approval_req+ '''=''N'' then''Y'' else           
          case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then''Y'' else isnull(m.app_status,''N'') 
          end           end as "APPROVAL_FLAG", convert(varchar(20),min(i."Insert_Date"),101),	
          CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),min(i."Insert_Date"),102) END AS "INSERT_DATE",
          min(i."Insert_Date") dd         FROM tbl_booking_mast m,tbl_booking_insert i,branch_mst b,
          login_branch_mast lb          WHERE m."cio_booking_id" =i."Cio_Booking_Id" AND m."Ad_type_code" ='''
           + @Adtype + '''          AND m."branch"= b."Branch_Code" and m."branch"= lb.branch_code AND 
           isnull (lb.user_flag,''N'') =''Y''' 
       
       	print '@v_wherecl-1'
       	
       	SELECT @v_wherecl =' and 1=1 '
 
           
		IF @pagency_code is not null 
		BEGIN 
			SELECT @v_wherecl  = @v_wherecl + ' and m."Agency_sub_code"=''' + @pagency_code + '''' 
		END
			print @v_wherecl
				print '@v_wherecl-2'
		IF @v_branch2 is not null 
		BEGIN 
			SELECT @v_wherecl  = @v_wherecl + ' and m."branch"=''' + @v_branch2 + '''' 
		END
		print @v_wherecl
				print '@v_wherecl-3'
   
		IF @pclient_code is not null 
		BEGIN 
			SELECT @v_wherecl  = @v_wherecl + ' and m."Client_code"=''' + @pclient_code + '''' 
		END
   print @v_wherecl
				print '@v_wherecl-4'
		IF @pclient_code is not null 
		BEGIN 
			SELECT @v_wherecl  = @v_wherecl + ' and m."Client_code"=''' + @pclient_code + '''' 
		END
        print @v_wherecl
				print '@v_wherecl-5'
		IF @audittype = 'audit' or ( @audittype = 'unaudit' or @audittype is null ) 
		BEGIN 
			IF @extra2 = 'P' 
			BEGIN 
				SELECT @v_wherecl  = @v_wherecl + ' and i."Insert_Date" BETWEEN''' + @fromdate + ''' AND''' + @todate + '''' 
			END
			ELSE
			BEGIN 
				SELECT @v_wherecl  = @v_wherecl + ' and m."date_time" BETWEEN''' + @fromdate + ''' AND''' + @todate + '''' 
			END
   
		END
		print @v_wherecl
				print '@v_wherecl-6'
   
		IF @v_Cat is not null 
		BEGIN 
			SELECT @v_wherecl  = @v_wherecl + ' and m."Ad_cat_code"=''' + @v_Cat + '''' 
		END
		print @v_wherecl
				print '@v_wherecl-7'
   
		IF @v_userid is not null 
		BEGIN 
			SELECT @v_wherecl  = @v_wherecl + ' and lb.user_code=''' + @v_userid + '''' 
		END
   print @v_wherecl
				print '@v_wherecl-8'
		IF @v_branch1 is not null 
		BEGIN 
			SELECT @v_wherecl  = @v_wherecl + ' and b."pub_center"=''' + @v_branch1 + '''' 
		END
   print @v_wherecl
				print '@v_wherecl-9'
		IF @v_package_code is not null 
		BEGIN 
			SELECT @v_wherecl  = @v_wherecl + ' and i."PACKAGE_CODE"=''' + @v_package_code + '''' 
		END
   print @v_wherecl
				print '@v_wherecl-10'
		IF @psection_code is not null 
		BEGIN 
			SELECT @v_wherecl  = @v_wherecl + ' and i."SECTIONCODE"=''' + @psection_code + '''' 
		END
		print @v_wherecl
				print '@v_wherecl-11'
   
		IF @extra1 is not null 
		BEGIN 
			SELECT @v_wherecl  = @v_wherecl + ' and m."Uom_code"=''' + @extra1 + '''' 
		END
   print @v_wherecl
				print '@v_wherecl-12'
		IF @p_booktype is not null 
		BEGIN 
			SELECT @v_wherecl  = @v_wherecl + ' and exists (select "userid" from login where "userid"=m."Userid" and                                      ((isnull("Agency_code",''0'')<>''0'' and isnull(''' + @p_booktype + ''',''A'') =''Q'') or                     (isnull("Agency_code",''0'')=''0'' and isnull(''' + @p_booktype + ''',''A'') =''D'') or isnull(''' + @p_booktype + ''',''A'') =''A''))' 
		END
   print @v_wherecl
				print '@v_wherecl-13'
		IF @audittype = 'audit' 
		BEGIN 
		print 'audit'
			SET @v_wherecl  = isnull(@v_wherecl,'') + ' AND m.audit != '''' ' 
		END
           print @v_wherecl
		print '@v_wherecl-14'
		IF @audittype = 'unaudit' or @audittype is null 
		BEGIN 
		print 'unaudit'
			SELECT @v_wherecl  = @v_wherecl + ' AND m.audit ='''' AND m.ro_status=''1'' and isnull(m.modified_audit,''N'')!=''Y''' 
		END
		
		print @v_wherecl
				print '@v_wherecl-15'
   
		IF @audittype = 'modified' 
		BEGIN 
		print 'modify'
			SELECT @v_wherecl  = @v_wherecl + ' AND m.audit IS NULL AND m.ro_status=''1'' and isnull(m.modified_audit,''N'')=''Y''' 
		END
		print @v_wherecl
				print '@v_wherecl-16'
   
		SELECT @v_query_group  = ' group by m."cio_booking_id" ,m."Client_code",m."audit", m."Ad_type_code",m."Receipt_no", m."Creation_datetime",m.ATTACHMENT1,isnull(m."Discount_per",0),isnull(m."Special_disc_per",0),m.app_status order by dd,"cio_booking_id"' 
		DELETE FROM   test1    
		
		INSERT INTO  test1   
				( vstring , 
				vstring2 )  
		 VALUES 		( 'bindaudit ' , 
				CAST(@v_query AS VARCHAR) + CAST(@v_wherecl AS VARCHAR) + CAST(@v_query_group AS VARCHAR) )  
		
		

		print @v_query
		print @v_wherecl
		print @v_query_group
		exec (@v_query+@v_wherecl+@v_query_group)

		SET NOCOUNT OFF

	END

///////////////////////////////////////end of book audit////////////////////////////////////////////////////

////////////////////////////////start of publish audit 30 oct 2012/////////////////////////////////////////////////


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
@v_userid        as varchar(100),
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
AGENCY_MAST
,login_branch_mast 

 WHERE TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT .Cio_Booking_Id
AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code
 AND TBL_BOOKING_insert.Col_Code =COL_MAST.Col_Code 
 
 AND TBL_BOOKING_Mast."Uom_code" =UOM_MAST."Uom_Code"
AND Insert_Date BETWEEN  '''+@fromdate+''' AND  '''+@todate+''' and
TBL_BOOKING_MAST."branch"= login_branch_mast.branch_code AND isnull(login_branch_mast.user_flag, ''N'') = ''Y''

'



If (@v_userid <> '') begin
set @query=@query+' and login_branch_mast.user_code= '''+@v_userid+'''';
end   


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




////////////////////////////end of publish audit 30 oct 2012///////////////by rahul/////////////////////////////











