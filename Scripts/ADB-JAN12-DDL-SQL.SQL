/****************************Issue 6197 **********************/
ALTER TABLE BRANCH_MST ADD BRANCH_NICK VARCHAR2(3) NOT NULL

/****************************Issue 6197 **********************/
/******************mimoh 11jan2011********************/
alter table tbl_booking_mast add CLIENT_TYPE varchar(5)

alter table tbl_booking_mast_g add CLIENT_TYPE varchar(5)
/******************mimoh 11jan2011********************/

/******************ankit**************** 13jan2011**********6228*****************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Reportnew1]
@agname			as	VARCHAR(500)=NULL,
@clientname		as	VARCHAR(500)=NULL,
@adtype1		as	VARCHAR(50),
@Adcategory		as	VARCHAR(500),
@Adsubcategory	as	VARCHAR(500),
@fromdate		as	VARCHAR(20),
@dateto			as	VARCHAR(20),
@compcode		as  VARCHAR(10),
@pub_name		as	VARCHAR(200),
@pub_cent		as  VARCHAR(200),
@status			as	VARCHAR(50)=NULL,
@edition		as	VARCHAR(100),
@dateformat		as	VARCHAR(20),
@hold			as	VARCHAR(20)=NULL,
@descid			as	VARCHAR(20)=NULL,
@ascdesc		as	VARCHAR(20)=NULL,
@agtype			as	varchar(20)=null,
@puserid		as	varchar(10)=null,
@chk_access		as	varchar(2),
@pbranch		as	varchar(50)=null,
@pprint_center	as	varchar(50)=null,
@pwithout_rono  as  varchar(50)=null,
@pdate_flag     as  varchar(5)=null,--it is used for booking date B or publish date P
@pextra1        as  varchar(50)=null,
@pextra2        as  varchar(50)=null,
@pextra3        as  varchar(50)=null,
@pextra4        as  varchar(50)=null,
@pextra5        as  varchar(50)=null
AS
	declare @center		VARCHAR(50)
	declare @from_date	DATETIME
	declare @date_to	DATETIME
	declare @v_query		VARCHAR(8000)
	declare @v_query1		VARCHAR(200)
	declare @v_query2		VARCHAR(200)
BEGIN

create table #Results(SegmentNum INT, Edition_Name  VARCHAR(255))
create table #result_new(SegmentNum INT, Edition_Name  VARCHAR(255))
insert into #Results select * from dbo.Fn_Splitfield(@Adcategory,',')
insert into #result_new select * from dbo.Fn_Splitfield_NEW(@Adsubcategory,',')


set	@v_query='SELECT m.cio_booking_id AS "CIOID",i.Edition as "edition",
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),i.Insert_Date,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),i.Insert_Date,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),i.Insert_Date,111)  END AS "Ins.date" ,
a.Agency_Name AS "Agency",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=m.Client_code and CUST_MAST.comp_code=m.comp_code),m.Client_code)  AS "Client",
(select COMBIN_MAST.Package_Name from combin_mast where COMBIN_MAST.comp_code=m.comp_code and COMBIN_MAST.Combin_Code  in(m.Package_code))AS "Package",
i.Height AS "Depth",i.Width   AS "Width",
round(i.Size_Book,2) AS "Area",
(select uom_mast.UOM_DESC from uom_mast where m.Uom_code=uom_mast.Uom_Code and m.comp_code=uom_mast.comp_code)as "uom",
i.Col_Code AS "Color_code",
(SELECT ADVPOS_TYPE_MAST.Pos_Type_Alias FROM ADVPOS_TYPE_MAST WHERE i.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code  and i.comp_code=ADVPOS_TYPE_MAST.comp_code) AS "Page",
m.Bullet_code AS "BulletPremium" ,i.Page_Post AS "PositionPremium" ,i.Premium1 AS "PagePremium" ,
m.RO_No AS "RoNo.",CASE m.ro_status WHEN ''2'' THEN ''Reservation'' WHEN ''1'' THEN ''Confirm'' END AS "RoStatus",
(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=i.Ad_Cat and ADV_CAT_MAST.comp_code=i.comp_code) AS "AdCat",
m.Card_rate AS "CardRate",isnull(Agrred_rate,0) AS "AgreedRate",i.Bill_Amt AS "Amt",Caption AS "Cap",Key_no AS "Key",
(SELECT dbo.InitCap(Comp_Name) from comp_mst where Comp_Code='''+@compcode+''')  AS "companyname",
getdate() as "Rundate",CASHDISCOUNT as "Cash_Disc",m.AUDIT_COMMENT as "COMMENT",m."Dockit_no" as "DOCKIT_NO"
FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a
 WHERE m.Comp_code='''+@compcode+''' AND m.cio_booking_id=i.Cio_Booking_Id
 AND m.Agency_code=a.Agency_Code and m.Agency_sub_code=a.code_subcode
 AND m.cio_booking_id not in(select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)
 and  lower(i.Insert_Status) !=''cancel''
and ((i.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )'



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

	IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL ) Begin
		set @v_query=@v_query+' and m."date_time" between  '''+@fromdate +''' and  '''+@dateto+''' '
	END

	IF( @fromdate<>'' and @dateto<>'') Begin
		set @v_query=@v_query+' and m."date_time" between  '''+@fromdate +''' and  '''+@dateto+''' '
	END
End

If @pdate_flag='P' Begin

	IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL ) Begin
		set @v_query=@v_query+' and i.Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
	END

	IF( @fromdate<>'' and @dateto<>'') Begin
		set @v_query=@v_query+' and i.Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
	END
End

IF(@edition IS NOT NULL and @edition<>'') Begin
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
	set @v_query=@v_query+' and m."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@pbranch+''') '
end 

if(@pwithout_rono='Y') Begin
    set @v_query=@v_query+' and (m."RO_No" is null or m."RO_No"='''') ';
End

if(@pwithout_rono='N') Begin
    set @v_query=@v_query+' and (m."RO_No" is not null or m."RO_No"<>'''') ';
End

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

END


/******************ankit**************** 13jan2011**********6228*****************/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@6421@@@@@@@@@@@@@@@

ALTER TABLE TBL_BOOKING_INSERT
 ADD CAPTION  VARCHAR(500)
 
ALTER TABLE TBL_BOOKING_INSERT_G
 ADD CAPTION  VARCHAR(500)


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@6421@@@@@@@@@@@@@@@




/**************mimoh*****Issue No. 0006211*********************/

alter table contract_mast add ATTACHMENT varchar(200)

ALTER TABLE CONTRACT_MAST
ADD DEAL_FROM varchar(50)

ALTER TABLE CONTRACT_MAST
ADD DEAL_CENTER varchar(50 )

ALTER TABLE CONTRACT_MAST
ADD TRANSLATION_CHARGES varchar(50)

  
ALTER TABLE CONTRACT_DETAIL
ADD POSITION_PREM varchar(50 )

ALTER TABLE CONTRACT_DETAIL
ADD CONTRACT_AMOUNT FLOAT

/**************mimoh*****Issue No. 0006211*********************/


/*********************mimoh 0006376**********************************/
ALTER TABLE EXEC_MAST ADD HR_CODE VARCHAR(6)
ALTER TABLE RETAINERMASTER ADD HR_CODE VARCHAR(6)
ALTER TABLE LOGIN ADD HR_CODE VARCHAR(6)
/*********************mimoh 0006376**********************************/






/*************ajay*******Issue 6650***********/
USE [abhi]
GO
/****** Object:  Table [dbo].[AD_CHARGE_MAST]    Script Date: 02/08/2012 12:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AD_CHARGE_MAST](
	[COMP_CODE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AD_TYPE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CHARGE_CODE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CHARGE_NAME] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CHARGE_ALIAS] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CHARGES_TYPE] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CHARGE_AMT] [numeric](6, 2) NOT NULL,
	[VALID_FROM_DATE] [datetime] NOT NULL,
	[VALID_TILL_DATE] [datetime] NULL,
	[CHARGE_ACTIVE] [varchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL DEFAULT ('Y'),
	[USERID] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CREATION_DATETIME] [datetime] NOT NULL,
	[UPDATED_BY] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UPDATED_DATE] [datetime] NULL,
 CONSTRAINT [AD_CHARGE_MAST_PK] PRIMARY KEY CLUSTERED 
(
	[CHARGE_CODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF