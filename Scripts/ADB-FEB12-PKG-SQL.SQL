/*************mimoh 6720***********************14feb 2012************/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
@p_insertremarkdet as varchar(5)

AS
declare @query as varchar(2000)
declare @query1 as varchar(2000)

update Agency_mast set Rate_Group=@rategrp, Agency_Code=@agentcode , fax1=@txtfax2,CREDIT_TYPE=@curtype, zone_code=@zone,  type=@type, Agency_Type_Code=@agencytype,Agency_Cat_Code=@agentcategory,Agency_SubCat_Code=@agentcategory2,Agency_Name=@agentname,Agency_Alias=@alias,Agency_HO=@agencyho,Add1=@address,Street=@street,City_Code=@city,Zip=@zip,Dist_Code=@district,State_Code=@state,Country_Code=@country,Phone=@phone,Fax=@fax,EmailID=@mail,URL=@url,Buss_Start_Date=@bussinessstartdate,Enroll_Date=@enrolldate ,MRV_Ref_No=@mrerefferenceno,No_of_VTS=@novts,Credit_Days=@credit,PAN_No=@pan,TAN_No=@tan,ST_ACC_No=@stacno1,Pay_Mode_Code=@paymode,Status_Reason=@status,Remarks=@remarks,SUB_Agency_HO=@subagencyho,SUB_Agency_Code=@agencycode ,BILL_TO =@acagen, acagency=@billto,ALERT=@alert,credit_limit=@creditlimit,code=@code ,region=@region,representative_code=@representative,pin_code=@pincode,Add2=@address1,Add3=@address2,qbc_userid=@qbcuserid , TALUKA=@taluka , Branch_code=@branchcode, DISTRICT=@hddistcode,STATE=@hdstatecode,BILL_FREQUENCY=@billf,OLD_AGENCY=@oldagen,BOOKING_TYPE=@booktype,VAT=@vat,RATE_REVISE=@p_raterevise 
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
/*************mimoh 6720*******************************14feb 2012****/
/*************mimoh 6741*******************************17feb 2012****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[websp_selectvalues](
@ciobooking		varchar(50), 
@editionname	varchar(50),
@compcode		VARCHAR(50),
@insertion		varchar(50),
@dateformat		varchar(50)

)
as 
declare @str			as varchar(8000)
declare @str1			as varchar(8000)
declare @str3 as varchar(8000)
declare @package_cd		as varchar(300)
declare @package_result as varchar(300)
declare @package_cd1	as varchar(300)
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
(select Uom_Name from uom_mast where uom_code=tbl_booking_mast.uom_code) as uom_name,
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
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))) AS CITY_NAMEnew,
tbl_booking_mast.RETAINER,tbl_booking_mast.Executive_code,
(select ADV_SUBCAT_MAST.Adv_Subcat_Name from ADV_SUBCAT_MAST where ADV_SUBCAT_MAST.Adv_Subcat_Code=TBL_BOOKING_MAST.ad_sub_cat_code) as "AdSubCat"

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
 and TBL_BOOKING_MAST.agency_code=AGENCY_MAST.agency_code  and comp_mst.comp_code='''+@compcode+''' 
 and tbl_booking_insert.Col_code=col_mast.Col_code   and pub_mast.pub_code=tbl_booking_insert.publication_code 
  and edition_mast.edition_code=tbl_booking_insert.edition_code and city_mst.city_code=agency_mast.city_code  and TBL_BOOKING_INSERT.publication_code = PUB_MAST.pub_code and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' and   tbl_booking_insert.no_insert='''+@insertion+''' and  tbl_booking_insert.edition='''+@editionname+''' '



print('d')
--set @str3=' and tbl_booking_insert.insert_date='''+convert (varchar(10),@pubdate,101)+''''
select  @package_cd1=package_code from tbl_booking_mast where cio_booking_id=@ciobooking




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

exec(@str+@str1+@str3)


select * from #package
delete from #package

select distinct edition_code from tbl_booking_insert where  cio_booking_id=@ciobooking and Insert_status not in ('Hold','cancel')

-- select top 1 insert_date from tbl_booking_insert where  cio_booking_id=@ciobooking order by insert_date
select top 1 DateName( Month,insert_date )+'-'+ DateName( Year, insert_date ) as "insert_date" from tbl_booking_insert where  cio_booking_id=@ciobooking and tbl_booking_insert.no_insert=@insertion order by insert_date

select scheme_code  from Scheme_Master where comp_code=@compcode and Scheme_id=@v_scheme_code


/* changes by GAurav for vision

select distinct edition_code from tbl_booking_insert where  cio_booking_id=@ciobooking

select top 1 insert_date from tbl_booking_insert where  cio_booking_id=@ciobooking 

select convert(varchar(25),dbo.UD_GET_MAXINSDT(@ciobooking,@insertion),3) as "bill_dt"

*/

/*************mimoh 6741*******************************17feb 2012****/


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 17/02/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//==============*********************Start Scripting****************==================//
ALTER procedure [dbo].[fmgdatabid](
       @compcode     as varchar(20),
       @todate 	as  varchar(25),
       @fromdate		 as varchar(25),
       @bookingid		 as varchar(20),
       @agency		 as varchar(20),
	   @client		 as varchar(20),
	   @insertid	as varchar(200),
	   @p_adtye		 as varchar(200),
	   @extra	as varchar(200)
       )
   As
declare @query as varchar(4000)
  Begin
 if @insertid = ''
begin
   -- set @query='select distinct tbl_booking_insert.cio_booking_id,(select "Col_Name" from col_mast where "Col_Code"=tbl_booking_insert."Col_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION",insert_id,Insert_date,Gross_rate,Bill_Amt from tbl_booking_insert,tbl_booking_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and tbl_booking_insert.comp_code='''+@compcode+''' and insert_date between '''+@fromdate+''' and '''+@todate+''' and tbl_booking_mast.Agency_sub_code= '''+@agency+''' and tbl_booking_mast.Ad_type_code= '''+@p_adtye+''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')' 
 set @query='select distinct tbl_booking_insert.cio_booking_id,tbl_booking_insert."Col_Code"  as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION",insert_id,Insert_date,Gross_rate,Bill_Amt from tbl_booking_insert,tbl_booking_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and tbl_booking_insert.comp_code='''+@compcode+''' and insert_date between '''+@fromdate+''' and '''+@todate+''' and tbl_booking_mast.Agency_sub_code= '''+@agency+''' and tbl_booking_mast.Ad_type_code= '''+@p_adtye+''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')' 
if(@bookingid <>  '')
begin
set @query=@query+' and tbl_booking_insert.cio_booking_id like '''+@bookingid+'%'''
end
if(@client <>  '')
begin
set @query=@query+' and tbl_booking_mast.Client_code like '''+@client+''''
end
print(@query)
exec(@query)
end
else
begin
create table #tmp1(insert_id varchar(50))
insert into #tmp1 select edition_name from dbo.fn_splitfield(@insertid,'~')
--set @query='select distinct tbl_booking_insert.cio_booking_id,(select "Col_Name" from col_mast where "Col_Code"=tbl_booking_insert."Col_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION",insert_id,Insert_date,Gross_rate,Bill_Amt from tbl_booking_insert,tbl_booking_mast where tbl_booking_insert.comp_code='''+@compcode+'''  and tbl_booking_mast.Agency_sub_code= '''+@agency+''' and tbl_booking_mast.Ad_type_code= '''+@p_adtye+''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')' 
set @query='select distinct tbl_booking_insert.cio_booking_id,tbl_booking_insert."Col_Code"  as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION",insert_id,Insert_date,Gross_rate,Bill_Amt from tbl_booking_insert,tbl_booking_mast where tbl_booking_insert.comp_code='''+@compcode+'''  and tbl_booking_mast.Agency_sub_code= '''+@agency+''' and tbl_booking_mast.Ad_type_code= '''+@p_adtye+''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')' 
 set @query=@query + ' and tbl_booking_insert.Insert_Id in(select insert_id from #tmp1)'
print(@query)
exec(@query)
drop table #tmp1
end


  End 
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER PROCEDURE [dbo].[fetchFMGrefID]
	@cioid_p varchar(50)
AS
BEGIN

	--select INSERTID from TBL_BOOKING_FMG_TRANS where cioid=@cioid_p
select TBL_BOOKING_FMG_TRANS.INSERTID,"Col_Code","Height","Width","Size_Book" from tbl_booking_insert,TBL_BOOKING_FMG_TRANS 
 where tbl_booking_insert."Insert_Id"=TBL_BOOKING_FMG_TRANS.INSERTID
 and TBL_BOOKING_FMG_TRANS.cioid=@cioid_p
	
END
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER PROCEDURE [dbo].[bindaudit]
--@code		as varchar(10),
@fromdate	as varchar(10),
@todate		as varchar(10),
@date		as varchar(15),
@branch1	as varchar(50),
@adtype		as varchar(50),
@audittype	as VARCHAR(50),
@branch2	as VARCHAR(50),
@v_Cat		as varchar(50),
@comp_code	as varchar(50),
@package_code	as varchar(100),
@pagency_code	as varchar(100),
@pclient_code	as varchar(100),
@psection_code	as varchar(100),
@p_booktype     as varchar(100),--A for all ,D for Direct ,Q for Qbc Booking
@extra1         as varchar(100),
@extra2         as varchar(100),
@extra3         as varchar(100),
@extra4         as varchar(100)
AS

declare @query as varchar(8000)

IF (@audittype = 'audit') begin
	IF(@branch1='All') begin
		set @query  ='SELECT distinct TBL_BOOKING_MAST.cio_booking_id,
		isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) as Client_code,
		audit,Ad_type_code,
		(select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=tbl_booking_mast .cio_booking_id and File_Name <> null ) as FILENAME,
		CASE '''+@date+'''
		WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
		WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
		WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT,dbo.AD_GETAGENCY_ADD('''+@comp_code+''',TBL_BOOKING_MAST.cio_booking_id,''A'') as "Agency_Remark",dbo.AD_GETAGENCY_ADD('''+@comp_code+''',TBL_BOOKING_MAST.cio_booking_id,''C'') as "Client_Remark"
		FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT WHERE  date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''' 
		AND Ad_type_code='''+@Adtype+''' AND audit <>''''
		AND TBL_BOOKING_MAST.cio_booking_id=tbl_booking_insert.cio_booking_id'
		--and (branch=@branch2 OR  @branch2 IS NULL) 
		--and (tbl_booking_mast.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL)
    end
    ELSE begin
		set @query  ='SELECT distinct TBL_BOOKING_MAST.cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) 
		as Client_code,audit,Ad_type_code,(select top 1  File_Name from tbl_booking_insert 
		where Cio_Booking_Id=tbl_booking_mast.cio_booking_id and File_Name <> null ) as FILENAME,
		CASE '''+@date+'''
		WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
		WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
		WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT,dbo.AD_GETAGENCY_ADD('''+@comp_code+''',TBL_BOOKING_MAST.cio_booking_id,''A'') as "Agency_Remark",dbo.AD_GETAGENCY_ADD('''+@comp_code+''',TBL_BOOKING_MAST.cio_booking_id,''C'') as "Client_Remark"


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
		WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT,dbo.AD_GETAGENCY_ADD('''+@comp_code+''',TBL_BOOKING_MAST.cio_booking_id,''A'') as "Agency_Remark",dbo.AD_GETAGENCY_ADD('''+@comp_code+''',TBL_BOOKING_MAST.cio_booking_id,''C'') as "Client_Remark"
		FROM 
		TBL_BOOKING_MAST,tbl_booking_insert WHERE  
		TBL_BOOKING_MAST.cio_booking_id=tbl_booking_insert.cio_booking_id
		AND Ad_type_code='''+@Adtype+''' AND audit = ''''
		and date_time BETWEEN '''+@fromdate+''' AND '''+@todate +'''
		and nvl(m.modified_audit,''N'')!=''Y'''
	end 		
    ELSE begin 
		set @query  =' SELECT distinct TBL_BOOKING_MAST.cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) as Client_code,audit,Ad_type_code,
		(select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=tbl_booking_mast.cio_booking_id and File_Name <> null ) as FILENAME ,


		CASE '''+@date+'''
		WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
		WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
		WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT,dbo.AD_GETAGENCY_ADD('''+@comp_code+''',TBL_BOOKING_MAST.cio_booking_id,''A'') as "Agency_Remark",dbo.AD_GETAGENCY_ADD('''+@comp_code+''',TBL_BOOKING_MAST.cio_booking_id,''C'') as "Client_Remark"

		FROM TBL_BOOKING_MAST,tbl_booking_insert WHERE TBL_BOOKING_MAST.cio_booking_id=tbl_booking_insert.cio_booking_id AND 
		branch IN(SELECT Branch_CODE FROM BRANCH_MST WHERE pub_center=(SELECT  top 1 Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+''' )) 
		AND Ad_type_code='''+@Adtype+''' AND audit = ''''
		AND  date_time BETWEEN '''+@fromdate+''' AND '''+@todate+'''
		and nvl(m.modified_audit,''N'')!=''Y'''
	END
END 

IF (@audittype = 'modified') begin
	IF(@branch1='All')begin

		set @query  ='SELECT distinct TBL_BOOKING_MAST.cio_booking_id,
		isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) as Client_code,
		audit,Ad_type_code,(select top 1 File_Name from tbl_booking_insert where Cio_Booking_Id=tbl_booking_mast.cio_booking_id and File_Name <> null ) as FILENAME,
		CASE '''+@date+'''
		WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
		WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
		WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT,dbo.AD_GETAGENCY_ADD('''+@comp_code+''',TBL_BOOKING_MAST.cio_booking_id,''A'') as "Agency_Remark",dbo.AD_GETAGENCY_ADD('''+@comp_code+''',TBL_BOOKING_MAST.cio_booking_id,''C'') as "Client_Remark"

		FROM TBL_BOOKING_MAST,tbl_booking_insert WHERE TBL_BOOKING_MAST.cio_booking_id=tbl_booking_insert.cio_booking_id AND 
		Ad_type_code='''+@Adtype+''' AND date_time BETWEEN '''+@fromdate+''' AND '''+@todate+'''
		and nvl(m.modified_audit,''N'')=''Y'''
	end		
	ELSE begin

		set @query  ='SELECT distinct TBL_BOOKING_MAST.cio_booking_id,
		isnull((select Cust_Name from cust_mast where Cust_Code=Client_code),Client_code) as Client_code,
		audit,Ad_type_code,(select top 1 File_Name from tbl_booking_insert where Cio_Booking_Id=tbl_booking_mast.cio_booking_id and File_Name is not null 
		) as FILENAME,
		CASE '''+@date+'''
		WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),tbl_booking_mast. Creation_datetime,101)
		WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,103)
		WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT ,dbo.AD_GETAGENCY_ADD('''+@comp_code+''',TBL_BOOKING_MAST.cio_booking_id,''A'') as "Agency_Remark",dbo.AD_GETAGENCY_ADD('''+@comp_code+''',TBL_BOOKING_MAST.cio_booking_id,''C'') as "Client_Remark"
		FROM TBL_BOOKING_MAST,tbl_booking_insert WHERE TBL_BOOKING_MAST.cio_booking_id=tbl_booking_insert.cio_booking_id AND 
		branch IN(SELECT Branch_CODE FROM BRANCH_MST WHERE pub_center=(SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+''')) AND
		Ad_type_code='''+@Adtype+''' AND date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''' 
		and nvl(m.modified_audit,''N'')=''Y'''
	END 
END 

if(@package_code <> null or @package_code <> '') begin
	set @query= @query+' and tbl_booking_insert.package_code in ('''+@package_code+''') '
end

if(@pagency_code <> null or @pagency_code <> '') begin
	set @query= @query+' and tbl_booking_mast.Agency_sub_code in ('''+@pagency_code+''') '
end


if(@pclient_code <> null or @pclient_code <> '') begin
	set @query= @query+' and tbl_booking_mast.Client_code in ('''+@pclient_code+''') '
end

if(@psection_code <> null or @psection_code <> '') begin
	set @query= @query+' and tbl_booking_insert.SECTIONCODE in ('''+@psection_code+''') '
end

if(@branch2 <> null or @branch2 <> '') begin
	set @query= @query+' and branch='''+@branch2+''' '
end 

if(@v_Cat <> null or @v_Cat <> '') begin
	set @query=@query+' and tbl_booking_mast.Ad_cat_code='''+@v_Cat+''' '
end 

print(@query)
exec(@query)

//==================================************End*********************==================//

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 17/02/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

/********************mimoh 0006796***********************************************/
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
@pcompanyname as varchar(50)
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
      ,[CIR_FILE_PATH],[CENTER_COMP_NAME ]) values(@compcode,@centercode,@centername, @alias,@add1,@street,@country, @state, @dist, @city, @pin,@phone1,@phone2, @fax,@email,'',getdate(),@remarks,@userid,getdate(),@region,@zone,@fax1,@boxaddress,@printval ,'',@imgpath,@cir_imgpath,@pcompanyname)
--insert into pub_cent_mast values(@compcode,@centercode,@centername, @alias,@add1,@street,@country, @state, @dist, @city, @pin,@phone1,@phone2, @fax,@email,'','',@remarks,@userid,@region,@zone,@txtdate),@fax2


exec(@query)
print(@query)


/*****************************************************************************/





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
@pcompanyname as varchar(50)

AS

declare @query varchar(1000)
declare @query1 varchar(1000)

set @query=' update pub_cent_mast set Pub_Cent_name='''+@centername+''' , Pub_Cent_Alias='''+@alias+''' , Add1='''+@add1+''' , street='''+@street+''', Country_Code='''+@country+''', State_Code='''+@state+''', Dist_Code='''+@dist+''', City_Code='''+@city+''', zip='''+@pin+''', Phone1='''+@phone1+''', Phone2='''+@phone2+''',Fax='''+@fax+''', EmailID='''+@email+''',Remarks='''+@remarks+''',region_code='''+@region+''',zone_code='''+@zone+''',Fax1='''+@fax1+''' ,BOXADDRESS='''+@boxadd+''',PRINT_CENT='''+@printval+''',FILE_PATH='''+@imgpath+''',CIR_FILE_PATH='''+@cir_imgpath+''',CENTER_COMP_NAME='''+@pcompanyname+'''  where comp_code='''+@compcode+'''   and   Pub_cent_Code='''+@centercode+'''   '

--set @query1=' update pcmdummy set Pub_Cent_name='''+@centername+''' , Pub_Cent_Alias='''+@alias+''' , Add1='''+@add1+''' , street='''+@street+''', Country_Code='''+@country+''', State_Code='''+@state+''', Dist_Code='''+@dist+''', City_Code='''+@city+''', zip='''+@pin+''', Phone1='''+@phone1+''', Phone2='''+@phone2+''',Fax='''+@fax+''', EmailID='''+@email+''',Remarks='''+@remarks+''',region_code='''+@region+''',zone_code='''+@zone+''',Fax1='''+@fax1+'''  where comp_code='''+@compcode+'''    and   Pub_cent_Code='''+@centercode+'''   '


print (@query)
exec(@query)
--print(@query1)
--exec(@query1)



/*************************************************************************************/








ALTER PROCEDURE [dbo].[pcmexe]

@compcode as varchar(8),
@centcode as varchar(8),
@centname as varchar(50),
@alias as varchar(50),
@city as varchar(15),
--@userid as varchar(8),
@country as varchar(8),
@pcompname as varchar(50)



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
CENTER_COMP_NAME varchar(50)
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
getdate(),Remarks,UserId,getdate(),getdate(),creation_datetime,region_code,zone_code,Fax1,BOXADDRESS,PRINT_CENT,FILE_PATH,CIR_FILE_PATH,CENTER_COMP_NAME  from pub_cent_mast where comp_code='''+@compcode+''' '


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
























/********************mimoh 0006796***********************************************/

/*************************mimoh6797*************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[ad_agency_bind_p]
    @pcompcode       as  varchar(20),
    @pag_name        as  varchar(200),
    @puserid         as  varchar(20),
    @pdateformat     as  varchar(20),
    @pextra1         as  varchar(200),
    @pextra2         as  varchar(200),
    @pextra3         as  varchar(200),
    @pextra4         as  varchar(200),
    @pextra5         as  varchar(200)
    As
Begin

    select  distinct  "code_subcode","Agency_Name" as "agency_name","Add1",(select "City_Name" from  city_mst 
    where "Comp_Code"=@pcompcode and "City_Code"=agency_mast."City_Code")+'-'+"Add1"+'-'+"Add2"+'-'+"Add3"+"Street"
    AS CITYNAME from Agency_mast where "Comp_Code"=@pcompcode
    and "Agency_Name" like '%'+@pag_name+'%'  order by "Agency_Name"
    
End
*********************************************************

create procedure bindclient11new
@compcode as varchar(10),
@client as varchar(50)

as



select "Cust_Code","Cust_Name" ,"Add1","City_Code" ,dbo.AD_GET_CITYNAME(@compcode,"City_Code") "cityname" from cust_mast where "Comp_Code"=@compcode and "Cust_Name" like '%'+ @client + '%';



/*************************mimoh6797*************************/


/*************booking audit***********mimoh 1march2012*************************************/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
  CASH_RECIEVED        VARCHAR (50),
  doctype			   varchar(20),
  APP_REMARKS		   varchar(500), 
  TRANSLATION_CODE     VARCHAR(50),
  TRANSLATION_PREMIUM  VARCHAR(50)
  )


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
                Logo_W, Logo_color, Logo_Uom,sapid,RETAINER,ADD_AGENCY_COMM,MOBILENO,ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,'''',doctype,APP_REMARKS,
                TRANSLATION_CODE, TRANSLATION_PREMIUM,(SELECT Box_Charges_Native FROM BOX_MAST WHERE BOX_MAST.Box_Code=TBL_BOOKING_MAST.Box_code) AS "boxcharge"
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
               -- Ad_Subcat3 as "SUBCAT3" 

(SELECT "catname"  FROM  AD_CAT3   WHERE

AD_CAT3."catcode"=#TEMPBOOKING_MAST."Ad_Subcat3")   as "SUBCAT3"



, 


(SELECT "Cat_Name"  FROM  TBL_CAT4   WHERE
TBL_CAT4."Cat_Code"=#TEMPBOOKING_MAST."Ad_Subcat4") as "SUBCAT4"  ,
(SELECT "Cat_Name"  FROM  TBL_CAT5   WHERE

TBL_CAT5."Cat_Code"=#TEMPBOOKING_MAST."Ad_subcat5") as "SUBCAT5"
--Ad_Subcat4 as "SUBCAT4", Ad_subcat5 as "SUBCAT5"


,

 Bg_color,
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
, DOCTYPE,APP_REMARKS,TRANSLATION_PREMIUM,--(select CHARGES_TYPE from ad_charge_mast where ad_charge_mast.COMP_CODE and ad_charge_mast.CHARGE_CODE=TEMPBOOKING_MAST_AUDIT.TRANSLATION_CODE) 
 '' as "TRANS_TYPE",(SELECT "Box_Name" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=#TEMPBOOKING_MAST."Box_code") AS "boxname"
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



/*************booking audit***********mimoh 1march2012*************************************/
