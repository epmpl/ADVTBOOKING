//================================update by bhanu=====================//
ALTER PROCEDURE   [dbo].[insertintobookchild]

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
@insertstatus as varchar(8),
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
@splitdata_v as varchar(50),
@subedidata  as varchar(500),
@splboldsizevalue	as varchar(10),
@vatrate_p as float,
@boxcharge_p as float,
@vat_inc_p as varchar,
@grossamtlocal_p as float,
@billamtlocal_p as float,
@sectioncode_p as varchar(50),
@resourceno_p as varchar(50),
@caption_inserts_p as varchar(500),
@dealerheight as float,
@dealerwidth as float,
@disc_p as float,
@agncyamnt as varchar(20),
@adlgncyamnt as varchar(20),
@spldiscamt as varchar(20),
@cashdamnt as varchar(20),
@ROUNDOFF as float
AS
declare @edi as varchar(8)
declare @publi as varchar(8)
declare @pub_cent  as varchar(8)
declare @supp as varchar(8)
declare @cou as int
declare @id as int
declare @insertidval as int
declare @countcir as int
declare @receiptno_m as varchar(50)
declare @vatamtamt as varchar(50)

select top 1 @receiptno_m=Receipt_no  from tbl_booking_mast_g where cio_booking_id=@cioid --and rownum<=1;
print(@receiptno_m)
select @cou=count(*)   from edition_mast where edition_alias=@edition and comp_code=@compcode

if(isnull(@vatrate_p,0)>0)
begin
set @vatamtamt=CONVERT(varchar(30),round((@billamt-(@billamt/(1+(@vatrate_p/100)))),2))
end
else
begin
set @vatamtamt=NULL
end


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


insert into tbl_booking_insert_g(cio_booking_id,Edition,Insert_date,Col_code,Height,Width,Size_book,Page_post,Premium1,Prem_per1,Premium2,Prem_per2,Premium_allow,Ad_cat,Ad_sub_cat,Latest_by,Status_material,File_name,Card_rate,Disc_rate,Insert_status,Bill_status,comp_code,Userid,Repeating_date,no_insert,Edition_code,Publication_code,Pub_cent_code,Supp_code,Pai_free_ins,Agreed_rate,Solo_rate,Gross_rate,Page_no,Remarks,Page_prem,page_per,No_ofcolumn,Bill_Amt,Bill_rate,Logo_H,Logo_W,Logo_name,AD_SUBCAT3,AD_SUBCAT4,AD_SUBCAT5,PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE,RESOURCE_NO,CAPTION,DEALER_H, DEALER_W,DISCOUNT,INSERT_STATUS_PUB,SPECIAL_SIZE2,agncyamnt,adlgncyamt,spldisamt,cashdisamt,ROUND_VALUE)
values(@cioid,@edition,@insertdate,@colid,@height,@width,@totalsize,@pagepost,@premium1,@premper1,@premium2,@premper2,@premallow,@adcategory,@adsubcat,@latestdate,@material,@matfilename,@cardrate,@discrate,@insertstatus,@billstatus,@compcode,@userid,@repeat,@insertno,@edi,@publi,@pub_cent,@supp,@paid,@agrrate,@solorate,@grossrate,@insert_pageno,@insert_remarks,@page_code,@page_per,@noofcol,@billamt,@billrate,@logo_h,@logo_w,@logo_name,@ad_cat_3,@ad_cat_4,@ad_cat_5, @pkgcode,@gridins,@pkgalias,@splboldsizevalue,@vatrate_p,@boxcharge_p,@vat_inc_p,@grossamtlocal_p,@billamtlocal_p,@sectioncode_p,@resourceno_p,@caption_inserts_p,@dealerheight,@dealerwidth,@disc_p,@insertstatus,@vatamtamt,@agncyamnt,@adlgncyamnt,@spldiscamt,@cashdamnt,@ROUNDOFF )

set @insertidval=@@identity

exec insert_edition_details @subedidata,@receiptno_m,@cioid,@insertidval,@compcode,@edition,@insertdate,@height,@width,@totalsize,@insertstatus,@pkgcode ,@insertno,@insert_pageno



if @cirvts!='' 
insert into tbl_booking_vts_g(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE
)
 values(@compcode,@cioid,@insertidval,@cirvts,@cirpub,@ciredi,@cirrate,@ciragency,@ciragencysubcode ,@center ,@branch ,@cirdate)

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

////=================================================================////

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
@dealerheight_p as float,
@dealerwidth_inserts_p as float,
@subedidata as  varchar(5000),
@disc_p as float,
@P_ip        as  varchar(20),
@P_RATE_AUDIT_FLAG  as varchar(20),
@agncyamnt as varchar(20),
@adlgncyamnt as varchar(20),
@spldiscamt as varchar(20),
@cashdamnt as varchar(20),
@ROUNDOFF as float


AS
declare @edi as varchar(8)
declare @publi as varchar(8)
declare @pub_cent  as varchar(8)
declare @supp as varchar(8)
declare @cou as int
declare @id as int
declare @insertidval as int
declare @countcir as int
declare @vatamtamt as varchar(50)
print(@insertid)
select @cou=count(*)   from edition_mast where edition_alias=@edition and comp_code=@compcode

if(isnull(@vatrate_p,0)>0)
begin
set @vatamtamt=CONVERT(varchar(30),round((@billamt-(@billamt/(1+(@vatrate_p/100)))),2))
end
else
begin
set @vatamtamt=NULL
end

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
update tbl_booking_insert set Edition=@edition,Insert_date=@insertdate,Col_code=@colid,Height=@height,Width=@width,Size_book=@totalsize,Page_post=@pagepost,Premium1=@premium1,Prem_per1=@premper1,Premium2=@premium2,Prem_per2=@premper2,Premium_allow=@premallow,Ad_cat=@adcategory,Ad_sub_cat=@adsubcat,Latest_by=@latestdate,Status_material=@material,File_name=@matfilename,Card_rate=@cardrate,Disc_rate=@discrate,Insert_status=@insertstatus,Bill_status=@billstatus,comp_code=@compcode,Userid=@userid,Repeating_date=@repeat,no_insert=@insertno,Edition_code=@edi,Publication_code=@publi,Pub_cent_code=@pub_cent,Supp_code=@supp,Pai_free_ins=@paid,Agreed_rate=@agrrate,Solo_rate=@solorate,Gross_rate=@grossrate,Page_no=@insert_pageno,Remarks=@insert_remarks,Page_prem=@page_code,page_per=@page_per,No_ofcolumn=@noofcol,Bill_Amt=@billamt,Bill_rate=@billrate,Logo_H=@logo_h,Logo_W=@logo_w,Logo_name=@logo_name,AD_SUBCAT3=@ad_cat_3,AD_SUBCAT4=@ad_cat_4,AD_SUBCAT5=@ad_cat_5,PACKAGE_CODE=@pkgcode,INSERTS=@gridins,PKG_ALIAS=@pkgalias ,SPECIAL_SIZE1=@splboldsizevalue,VATAMT=@vatrate_p,BOXCHARGE=@boxcharge_p, VAT_INC=@vat_inc_p,LOCALGROSSAMT =@grossamtlocal_p,LOCALBILLAMT = @billamtlocal_p,sectioncode=@sectioncode_p,RESOURCE_NO=@resourceno_p,CAPTION=@caption_inserts_p,RATE_AUDIT_IP=@P_ip,RATE_AUDIT_FLAG=@P_RATE_AUDIT_FLAG,DISCOUNT=@disc_p,SPECIAL_SIZE2=@vatamtamt
,agncyamnt=@agncyamnt,adlgncyamt=@adlgncyamnt,spldisamt=@spldiscamt, cashdisamt=@cashdamnt,ROUND_VALUE=@ROUNDOFF
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
insert into tbl_booking_insert_g(cio_booking_id,Edition,Insert_date,Col_code,Height,Width,Size_book,Page_post,Premium1,Prem_per1,Premium2,Prem_per2,Premium_allow,Ad_cat,Ad_sub_cat,Latest_by,Status_material,File_name,Card_rate,Disc_rate,Insert_status,Bill_status,comp_code,Userid,Repeating_date,no_insert,Edition_code,Publication_code,Pub_cent_code,Supp_code,Pai_free_ins,Agreed_rate,Solo_rate,Gross_rate,Page_no,Remarks,Page_prem,page_per,No_ofcolumn,Bill_Amt,Bill_rate,Logo_H,Logo_W,Logo_name,AD_SUBCAT3,AD_SUBCAT4,AD_SUBCAT5,PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE,RESOURCE_NO,CAPTION,SPECIAL_SIZE2,agncyamnt,adlgncyamt,spldisamt,cashdisamt,ROUND_VALUE)
values(@cioid,@edition,@insertdate,@colid,@height,@width,@totalsize,@pagepost,@premium1,@premper1,@premium2,@premper2,@premallow,@adcategory,@adsubcat,@latestdate,@material,@matfilename,@cardrate,@discrate,@insertstatus,@billstatus,@compcode,@userid,@repeat,@insertno,@edi,@publi,@pub_cent,@supp,@paid,@agrrate,@solorate,@grossrate,@insert_pageno,@insert_remarks,@page_code,@page_per,@noofcol,@billamt,@billrate,@logo_h,@logo_w,@logo_name,@ad_cat_3,@ad_cat_4,@ad_cat_5, @pkgcode,@gridins,@pkgalias,@splboldsizevalue,@vatrate_p,@boxcharge_p,@vat_inc_p,@grossamtlocal_p,@billamtlocal_p,@sectioncode_p,@resourceno_p,@caption_inserts_p,@vatamtamt,@agncyamnt,@adlgncyamnt,@spldiscamt,@cashdamnt,@ROUNDOFF)
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
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE,CAPTION,SPECIAL_SIZE2,agncyamnt,adlgncyamt,spldisamt,cashdisamt,ROUND_VALUE)
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
           ,[LOCKSTATUS],SPECIAL_SIZE1,vatamt,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE,CAPTION,SPECIAL_SIZE2,agncyamnt,adlgncyamt,spldisamt,cashdisamt,ROUND_VALUE FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=@cioid
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

////======================================================================////

ALTER PROCEDURE [dbo].[committransaction]
	@pcioid          as  varchar(50),
	@totalcount      as  int,
	@pcompcode       as  varchar(20),
	@pcentname       as  varchar(20),
	@puserid         as  varchar(20),
	@pbkid_gentype   as  varchar(20),
	@pbk_type		 as  varchar(20),
	@pquotation		as varchar(1)
AS
declare @countnum int
declare @uomdesc varchar(50)
declare @billpay varchar(20)
declare @rostatus varchar(10)
declare @remarks varchar(500)
declare @clientname varchar(200)
declare @adtype varchar(100)
declare @v_cursor1_var1  varchar(50)
declare @v_cursor1_var2  varchar(50)
declare @newid			 varchar(50)	
declare @uomcode varchar(50)

BEGIN
select @countnum=count(*) from tbl_booking_insert_g where Cio_Booking_Id=@pcioid
if @countnum=@totalcount begin
if @pquotation ='Q'
begin
set @newid=@pcioid
INSERT INTO tbl_booking_mast_Q
           ([date_time]
           ,[branch]
           ,[booked_by]
           ,[cio_booking_id]
           ,[prev_booking]
           ,[applied_by]
           ,[audit]
           ,[RO_No]
           ,[RO_Date]
           ,[Caption]
           ,[bill_status]
           ,[ro_status]
           ,[Agency_code]
           ,[Agency_address]
           ,[Client_code]
           ,[Client_address]
           ,[Agency_sub_code]
           ,[Dockit_no]
           ,[Executive_code]
           ,[Executive_zone]
           ,[Product_code]
           ,[Brand_code]
           ,[Key_no]
           ,[Bill_remarks]
           ,[Print_remark]
           ,[Package_code]
           ,[No_of_insertion]
           ,[Insertion_date]
           ,[Repeating_day]
           ,[Ad_type_code]
           ,[Ad_cat_code]
           ,[Ad_sub_cat_code]
           ,[Color_code]
           ,[Uom_code]
           ,[Page_position_code]
           ,[Page_type_code]
           ,[Page_no]
           ,[Ad_size_type_code]
           ,[Ad_size_height]
           ,[Ad_size_width]
           ,[Rate_code]
           ,[Scheme_type_code]
           ,[Currency_code]
           ,[Agrred_rate]
           ,[Agreed_amount]
           ,[Special_discount]
           ,[Space_discount]
           ,[Special_charges]
           ,[Agency_status]
           ,[Agency_type]
           ,[Agency_pay]
           ,[Agency_credit]
           ,[Total_area]
           ,[Card_rate]
           ,[Card_amount]
           ,[Discount]
           ,[Discount_per]
           ,[Bill_cycle]
           ,[Revenue_center]
           ,[Bill_pay]
           ,[Bill_height]
           ,[Bill_width]
           ,[Bill_to]
           ,[Invoices]
           ,[Vts]
           ,[Bill_add]
           ,[Trade_disc]
           ,[Agency_out]
           ,[Box_code]
           ,[Box_no]
           ,[Box_agency]
           ,[Box_client]
           ,[Box_address]
           ,[Comp_code]
           ,[Userid]
           ,[Creation_datetime]
           ,[Booking_type]
           ,[Tfn]
           ,[Coupan_ad]
           ,[Campaign]
           ,[Bill_amount]
           ,[Page_prem]
           ,[Page_amount]
           ,[Prem_per]
           ,[Gross_amount]
           ,[Ad_size_column]
           ,[Bill_column]
           ,[Bill_area]
           ,[Special_disc_per]
           ,[Space_disc_per]
           ,[Paid_ins]
           ,[Contract_rate]
           ,[Deviation]
           ,[Variant_code]
           ,[Contract_name]
           ,[Contract_type]
           ,[Card_name]
           ,[Card_type]
           ,[Card_month]
           ,[Card_year]
           ,[Card_number]
           ,[Receipt_no]
           ,[Ad_Subcat3]
           ,[Ad_Subcat4]
           ,[Ad_subcat5]
           ,[Bg_color]
           ,[Bullet_code]
           ,[Bullet_premium]
           ,[Material_status]
           ,[Receipt_date]
           ,[prev_cioid]
           ,[prev_receipt]
           ,[prev_grossamt]
           ,[Region]
           ,[Variant]
           ,[status]
           ,[Colortype]
           ,[Logo_H]
           ,[Logo_W]
           ,[Logo_color]
           ,[Logo_Uom]
           ,[SAPID]
           ,[RETAINER]
           ,[ADD_AGENCY_COMM]
           ,[AUDIT_COMMENT]
           ,[MOBILENO]
           ,[ADD_AGENCY_COMM_AMT]
           ,[RETAINER_COMM]
           ,[RETAINER_COMM_AMT]
           ,[CASH_RECIEVED]
           ,[CONT_GROSS]
           ,[CIRAGENCY]
           ,[CIRRATE]
           ,[CIREDITION]
           ,[CIRPUBLICATION]
           ,[CIRAGENCY_SUBCODE]
           ,[BARTER_TYPE]
           ,[APP_STATUS]
           ,[APP_REMARKS]
           ,[APP_DATE]
           ,[APP_USER]
           ,[RODOCSTATUS]
           ,[RO_COMMENT],CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,
			DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL,
			DEALER_H,
			DEALER_W,
			DEALERTYPE,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT,PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,
			REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,CANCELLATION_CHARGE,TRANSLATION_DISC,POSPREM_DISC,CONTACT_PERSON,CONTACT_PERSON_EMAIL)
SELECT [date_time]
           ,[branch]
           ,[booked_by]
           ,@newid
           ,[prev_booking]
           ,[applied_by]
           ,[audit]
           ,[RO_No]
           ,[RO_Date]
           ,[Caption]
           ,[bill_status]
           ,[ro_status]
           ,[Agency_code]
           ,[Agency_address]
           ,[Client_code]
           ,[Client_address]
           ,[Agency_sub_code]
           ,[Dockit_no]
           ,[Executive_code]
           ,[Executive_zone]
           ,[Product_code]
           ,[Brand_code]
           ,[Key_no]
           ,[Bill_remarks]
           ,[Print_remark]
           ,[Package_code]
           ,[No_of_insertion]
           ,[Insertion_date]
           ,[Repeating_day]
           ,[Ad_type_code]
           ,[Ad_cat_code]
           ,[Ad_sub_cat_code]
           ,[Color_code]
           ,[Uom_code]
           ,[Page_position_code]
           ,[Page_type_code]
           ,[Page_no]
           ,[Ad_size_type_code]
           ,[Ad_size_height]
           ,[Ad_size_width]
           ,[Rate_code]
           ,[Scheme_type_code]
           ,[Currency_code]
           ,[Agrred_rate]
           ,[Agreed_amount]
           ,[Special_discount]
           ,[Space_discount]
           ,[Special_charges]
           ,[Agency_status]
           ,[Agency_type]
           ,[Agency_pay]
           ,[Agency_credit]
           ,[Total_area]
           ,[Card_rate]
           ,[Card_amount]
           ,[Discount]
           ,[Discount_per]
           ,[Bill_cycle]
           ,[Revenue_center]
           ,[Bill_pay]
           ,[Bill_height]
           ,[Bill_width]
           ,[Bill_to]
           ,[Invoices]
           ,[Vts]
           ,[Bill_add]
           ,[Trade_disc]
           ,[Agency_out]
           ,[Box_code]
           ,[Box_no]
           ,[Box_agency]
           ,[Box_client]
           ,[Box_address]
           ,[Comp_code]
           ,[Userid]
           ,[Creation_datetime]
           ,[Booking_type]
           ,[Tfn]
           ,[Coupan_ad]
           ,[Campaign]
           ,[Bill_amount]
           ,[Page_prem]
           ,[Page_amount]
           ,[Prem_per]
           ,[Gross_amount]
           ,[Ad_size_column]
           ,[Bill_column]
           ,[Bill_area]
           ,[Special_disc_per]
           ,[Space_disc_per]
           ,[Paid_ins]
           ,[Contract_rate]
           ,[Deviation]
           ,[Variant_code]
           ,[Contract_name]
           ,[Contract_type]
           ,[Card_name]
           ,[Card_type]
           ,[Card_month]
           ,[Card_year]
           ,[Card_number]
           ,[Receipt_no]
           ,[Ad_Subcat3]
           ,[Ad_Subcat4]
           ,[Ad_subcat5]
           ,[Bg_color]
           ,[Bullet_code]
           ,[Bullet_premium]
           ,[Material_status]
           ,[Receipt_date]
           ,[prev_cioid]
           ,[prev_receipt]
           ,[prev_grossamt]
           ,[Region]
           ,[Variant]
           ,[status]
           ,[Colortype]
           ,[Logo_H]
           ,[Logo_W]
           ,[Logo_color]
           ,[Logo_Uom]
           ,[SAPID]
           ,[RETAINER]
           ,[ADD_AGENCY_COMM]
           ,[AUDIT_COMMENT]
           ,[MOBILENO]
           ,[ADD_AGENCY_COMM_AMT]
           ,[RETAINER_COMM]
           ,[RETAINER_COMM_AMT]
           ,[CASH_RECIEVED]
           ,[CONT_GROSS]
           ,[CIRAGENCY]
           ,[CIRRATE]
           ,[CIREDITION]
           ,[CIRPUBLICATION]
           ,[CIRAGENCY_SUBCODE]
           ,[BARTER_TYPE]
           ,[APP_STATUS]
           ,[APP_REMARKS]
           ,[APP_DATE]
           ,[APP_USER]
           ,[RODOCSTATUS]
           ,[RO_COMMENT],CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,
			DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL,
			DEALER_H,
			DEALER_W,
			DEALERTYPE,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,
			REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,CANCELLATION_CHARGE,TRANSLATION_DISC,POSPREM_DISC,CONTACT_PERSON,CONTACT_PERSON_EMAIL
			 FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=@pcioid

INSERT INTO [tbl_booking_insert_Q]
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
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT
           , LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION,DISCOUNT,SPECIAL_SIZE2,agncyamnt,adlgncyamt,spldisamt,cashdisamt,ROUND_VALUE)
SELECT insert_id,@newid
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
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT, BOXCHARGE,VAT_INC
           , LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO,CAPTION, DISCOUNT,SPECIAL_SIZE2,agncyamnt,adlgncyamt,spldisamt,cashdisamt,ROUND_VALUE
            FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=@pcioid
end
else
begin
EXEC getautocodebooking_new
	@pcompcode,
	'0',
	'0',
	@v_cursor1_var1 OUTPUT, 
    @v_cursor1_var2 OUTPUT
                                            
    
    if  @pbkid_gentype='1' Begin--1 for First 3 character of Centre Name+Year + Slno  
        
        set @newid=substring(@pcentname,1,3)+@v_cursor1_var2+dbo.fnPadLeft('0',8,@v_cursor1_var1) 
    End
    else if  @pbkid_gentype='2' Begin--2 for First 3 character of Centre Name+Year + Userid + Slno
    
        set @newid=substring(@pcentname,1,3)+@v_cursor1_var2+dbo.fnPadLeft('0',8,@v_cursor1_var1) +@puserid
	End
    else if  @pbkid_gentype='4' Begin--4 for BK Type + Slno
        set @newid=@pbk_type+dbo.fnPadLeft('0',8,@v_cursor1_var1) 
    end	
    else if  @pbkid_gentype='3' Begin--3 for Slno only
        set @newid=dbo.fnPadLeft('0',8,@v_cursor1_var1) 
    end
    else 
    Begin
        set @newid=dbo.fnPadLeft('0',8,@v_cursor1_var1) 
    end
    print @newid
create table #recpt_t(receipt_no varchar(130))
select @adtype=ad_type_code,@uomcode=uom_code from tbl_booking_mast_g where cio_booking_id=@pcioid
select @uomdesc=uom_desc from uom_mast where uom_code=@uomcode
 INSERT INTO tbl_booking_mast
           ([date_time]
           ,[branch]
           ,[booked_by]
           ,[cio_booking_id]
           ,[prev_booking]
           ,[applied_by]
           ,[audit]
           ,[RO_No]
           ,[RO_Date]
           ,[Caption]
           ,[bill_status]
           ,[ro_status]
           ,[Agency_code]
           ,[Agency_address]
           ,[Client_code]
           ,[Client_address]
           ,[Agency_sub_code]
           ,[Dockit_no]
           ,[Executive_code]
           ,[Executive_zone]
           ,[Product_code]
           ,[Brand_code]
           ,[Key_no]
           ,[Bill_remarks]
           ,[Print_remark]
           ,[Package_code]
           ,[No_of_insertion]
           ,[Insertion_date]
           ,[Repeating_day]
           ,[Ad_type_code]
           ,[Ad_cat_code]
           ,[Ad_sub_cat_code]
           ,[Color_code]
           ,[Uom_code]
           ,[Page_position_code]
           ,[Page_type_code]
           ,[Page_no]
           ,[Ad_size_type_code]
           ,[Ad_size_height]
           ,[Ad_size_width]
           ,[Rate_code]
           ,[Scheme_type_code]
           ,[Currency_code]
           ,[Agrred_rate]
           ,[Agreed_amount]
           ,[Special_discount]
           ,[Space_discount]
           ,[Special_charges]
           ,[Agency_status]
           ,[Agency_type]
           ,[Agency_pay]
           ,[Agency_credit]
           ,[Total_area]
           ,[Card_rate]
           ,[Card_amount]
           ,[Discount]
           ,[Discount_per]
           ,[Bill_cycle]
           ,[Revenue_center]
           ,[Bill_pay]
           ,[Bill_height]
           ,[Bill_width]
           ,[Bill_to]
           ,[Invoices]
           ,[Vts]
           ,[Bill_add]
           ,[Trade_disc]
           ,[Agency_out]
           ,[Box_code]
           ,[Box_no]
           ,[Box_agency]
           ,[Box_client]
           ,[Box_address]
           ,[Comp_code]
           ,[Userid]
           ,[Creation_datetime]
           ,[Booking_type]
           ,[Tfn]
           ,[Coupan_ad]
           ,[Campaign]
           ,[Bill_amount]
           ,[Page_prem]
           ,[Page_amount]
           ,[Prem_per]
           ,[Gross_amount]
           ,[Ad_size_column]
           ,[Bill_column]
           ,[Bill_area]
           ,[Special_disc_per]
           ,[Space_disc_per]
           ,[Paid_ins]
           ,[Contract_rate]
           ,[Deviation]
           ,[Variant_code]
           ,[Contract_name]
           ,[Contract_type]
           ,[Card_name]
           ,[Card_type]
           ,[Card_month]
           ,[Card_year]
           ,[Card_number]
           ,[Receipt_no]
           ,[Ad_Subcat3]
           ,[Ad_Subcat4]
           ,[Ad_subcat5]
           ,[Bg_color]
           ,[Bullet_code]
           ,[Bullet_premium]
           ,[Material_status]
           ,[Receipt_date]
           ,[prev_cioid]
           ,[prev_receipt]
           ,[prev_grossamt]
           ,[Region]
           ,[Variant]
           ,[status]
           ,[Colortype]
           ,[Logo_H]
           ,[Logo_W]
           ,[Logo_color]
           ,[Logo_Uom]
           ,[SAPID]
           ,[RETAINER]
           ,[ADD_AGENCY_COMM]
           ,[AUDIT_COMMENT]
           ,[MOBILENO]
           ,[ADD_AGENCY_COMM_AMT]
           ,[RETAINER_COMM]
           ,[RETAINER_COMM_AMT]
           ,[CASH_RECIEVED]
           ,[CONT_GROSS]
           ,[CIRAGENCY]
           ,[CIRRATE]
           ,[CIREDITION]
           ,[CIRPUBLICATION]
           ,[CIRAGENCY_SUBCODE]
           ,[BARTER_TYPE]
           ,[APP_STATUS]
           ,[APP_REMARKS]
           ,[APP_DATE]
           ,[APP_USER]
           ,[RODOCSTATUS]
           ,[RO_COMMENT],CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,
			DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL,
			DEALER_H,
			DEALER_W,
			DEALERTYPE,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT,PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,
			REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,CANCELLATION_CHARGE,TRANSLATION_DISC,POSPREM_DISC,BILL_HOLD,DESIGN_BOX,LOGOTYPE_PREM,ONLINE_AD,STYLE,FIXED_BOOKING,VAT_CODE)
SELECT [date_time]
           ,[branch]
           ,[booked_by]
           ,@newid
           ,[prev_booking]
           ,[applied_by]
           ,[audit]
           ,[RO_No]
           ,[RO_Date]
           ,[Caption]
           ,[bill_status]
           ,[ro_status]
           ,[Agency_code]
           ,[Agency_address]
           ,[Client_code]
           ,[Client_address]
           ,[Agency_sub_code]
           ,[Dockit_no]
           ,[Executive_code]
           ,[Executive_zone]
           ,[Product_code]
           ,[Brand_code]
           ,[Key_no]
           ,[Bill_remarks]
           ,[Print_remark]
           ,[Package_code]
           ,[No_of_insertion]
           ,[Insertion_date]
           ,[Repeating_day]
           ,[Ad_type_code]
           ,[Ad_cat_code]
           ,[Ad_sub_cat_code]
           ,[Color_code]
           ,[Uom_code]
           ,[Page_position_code]
           ,[Page_type_code]
           ,[Page_no]
           ,[Ad_size_type_code]
           ,[Ad_size_height]
           ,[Ad_size_width]
           ,[Rate_code]
           ,[Scheme_type_code]
           ,[Currency_code]
           ,[Agrred_rate]
           ,[Agreed_amount]
           ,[Special_discount]
           ,[Space_discount]
           ,[Special_charges]
           ,[Agency_status]
           ,[Agency_type]
           ,[Agency_pay]
           ,[Agency_credit]
           ,[Total_area]
           ,[Card_rate]
           ,[Card_amount]
           ,[Discount]
           ,[Discount_per]
           ,[Bill_cycle]
           ,[Revenue_center]
           ,[Bill_pay]
           ,[Bill_height]
           ,[Bill_width]
           ,[Bill_to]
           ,[Invoices]
           ,[Vts]
           ,[Bill_add]
           ,[Trade_disc]
           ,[Agency_out]
           ,[Box_code]
           ,[Box_no]
           ,[Box_agency]
           ,[Box_client]
           ,[Box_address]
           ,[Comp_code]
           ,[Userid]
           ,[Creation_datetime]
           ,[Booking_type]
           ,[Tfn]
           ,[Coupan_ad]
           ,[Campaign]
           ,[Bill_amount]
           ,[Page_prem]
           ,[Page_amount]
           ,[Prem_per]
           ,[Gross_amount]
           ,[Ad_size_column]
           ,[Bill_column]
           ,[Bill_area]
           ,[Special_disc_per]
           ,[Space_disc_per]
           ,[Paid_ins]
           ,[Contract_rate]
           ,[Deviation]
           ,[Variant_code]
           ,[Contract_name]
           ,[Contract_type]
           ,[Card_name]
           ,[Card_type]
           ,[Card_month]
           ,[Card_year]
           ,[Card_number]
           ,[Receipt_no]
           ,[Ad_Subcat3]
           ,[Ad_Subcat4]
           ,[Ad_subcat5]
           ,[Bg_color]
           ,[Bullet_code]
           ,[Bullet_premium]
           ,[Material_status]
           ,[Receipt_date]
           ,[prev_cioid]
           ,[prev_receipt]
           ,[prev_grossamt]
           ,[Region]
           ,[Variant]
           ,[status]
           ,[Colortype]
           ,[Logo_H]
           ,[Logo_W]
           ,[Logo_color]
           ,[Logo_Uom]
           ,[SAPID]
           ,[RETAINER]
           ,[ADD_AGENCY_COMM]
           ,[AUDIT_COMMENT]
           ,[MOBILENO]
           ,[ADD_AGENCY_COMM_AMT]
           ,[RETAINER_COMM]
           ,[RETAINER_COMM_AMT]
           ,[CASH_RECIEVED]
           ,[CONT_GROSS]
           ,[CIRAGENCY]
           ,[CIRRATE]
           ,[CIREDITION]
           ,[CIRPUBLICATION]
           ,[CIRAGENCY_SUBCODE]
           ,[BARTER_TYPE]
           ,[APP_STATUS]
           ,[APP_REMARKS]
           ,[APP_DATE]
           ,[APP_USER]
           ,[RODOCSTATUS]
           ,[RO_COMMENT],CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,
			DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL,
			DEALER_H,
			DEALER_W,
			DEALERTYPE,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,
			REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,CANCELLATION_CHARGE,TRANSLATION_DISC,POSPREM_DISC,BILL_HOLD,DESIGN_BOX,LOGOTYPE_PREM,ONLINE_AD,STYLE,FIXED_BOOKING,VAT_CODE
			 FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=@pcioid
INSERT INTO [tbl_boking_days]
           ([Rotation]
           ,[Priority]
           ,[Sunday]
           ,[Sunday_From]
           ,[Sunday_To]
           ,[Monday]
           ,[Monday_From]
           ,[Monday_To]
           ,[Tuesday]
           ,[Tuesday_From]
           ,[Tuesday_To]
           ,[Wednesday]
           ,[Wednesday_From]
           ,[Wednesday_To]
           ,[Thursday]
           ,[Thursday_From]
           ,[Thursday_To]
           ,[Friday]
           ,[Friday_From]
           ,[Friday_To]
           ,[Saturday]
           ,[Saturday_From]
           ,[Saturday_To]
           ,[Demog_sex]
           ,[Demog_agegroup]
           ,[Demog_Occup]
           ,[Demog_inter]
           ,[cio_booking_id]
           ,[NO_INSERT]
           ,[Comp_Code]
           ,[EDITION]     
            ,[interest] )		select
           [Rotation]
           ,[Priority]
           ,[Sunday]
           ,[Sunday_From]
           ,[Sunday_To]
           ,[Monday]
           ,[Monday_From]
           ,[Monday_To]
           ,[Tuesday]
           ,[Tuesday_From]
           ,[Tuesday_To]
           ,[Wednesday]
           ,[Wednesday_From]
           ,[Wednesday_To]
           ,[Thursday]
           ,[Thursday_From]
           ,[Thursday_To]
           ,[Friday]
           ,[Friday_From]
           ,[Friday_To]
           ,[Saturday]
           ,[Saturday_From]
           ,[Saturday_To]
           ,[Demog_sex]
           ,[Demog_agegroup]
           ,[Demog_Occup]
           ,[Demog_inter]
           ,@newid
           ,[NO_INSERT]
           ,[Comp_Code]
           ,[EDITION] 
             ,[interest] from tbl_boking_days_g 	 WHERE CIO_BOOKING_ID=@pcioid
INSERT INTO tbl_booking_geography ([Country]
           ,[statecode]
           ,[City]
           ,[Edition]
           ,[cio_booking_id]
           ,[NO_INSERT]) SELECT [Country]
           ,[statecode]
           ,[City]
           ,[Edition]
           ,@newid
           ,[NO_INSERT] FROM tbl_booking_geography_G WHERE CIO_BOOKING_ID=@pcioid
           
INSERT INTO tbl_web_material ([CIOID]
           ,[IMAGEFILE]
           ,[IMAGENAME]
           ,[URL]
           ,[pfilename]
           ,[Comp_code]
           ,[NO_INSERT]
           ,[EDITION]) SELECT @newid
           ,[IMAGEFILE]
           ,[IMAGENAME]
           ,[URL]
           ,[pfilename]
           ,[Comp_code]
           ,[NO_INSERT]
           ,[EDITION] FROM tbl_web_material_g WHERE cioid=@pcioid
           
if @uomdesc!='CD'
begin           
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
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT
           , LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION,DISCOUNT,INSERT_STATUS_PUB,SPECIAL_SIZE2,agncyamnt,adlgncyamt,spldisamt,cashdisamt,ROUND_VALUE)
SELECT insert_id,@newid
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
            ,replace([File_name],@pcioid,@newid)--[File_name]
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
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT, BOXCHARGE,VAT_INC
           , LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO,CAPTION, DISCOUNT, INSERT_STATUS_PUB,SPECIAL_SIZE2,agncyamnt,adlgncyamt,spldisamt,cashdisamt,ROUND_VALUE
            FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=@pcioid
end
else
begin
print @pcioid
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
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT
           , LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION,DISCOUNT,INSERT_STATUS_PUB,SPECIAL_SIZE2,agncyamnt,adlgncyamt,spldisamt,cashdisamt,ROUND_VALUE)
SELECT insert_id,@newid
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
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT, BOXCHARGE,VAT_INC
           , LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO,CAPTION, DISCOUNT, INSERT_STATUS_PUB,SPECIAL_SIZE2,agncyamnt,adlgncyamt,spldisamt,cashdisamt,ROUND_VALUE
            FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=@pcioid
end            
update online_admaster set extend_id=@newid where extend_id=@pcioid
INSERT INTO TBL_BOOKING_VTS(COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE) 
SELECT COMPCODE, @newid CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE FROM TBL_BOOKING_VTS_G WHERE  cioid=@pcioid


insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO, NO_INSERT,PAGE_NO)
select COMP_CODE, @newid CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO, SRNO, NO_INSERT,PAGE_NO from tbl_booking_subedition_g
where tbl_booking_subedition_g.CIOID=@pcioid;


insert into TBL_BOOKING_SHARING_TRANS(PUBLICATION, TYPE, SHARING, CIOID, SRNO)
select PUBLICATION, TYPE, SHARING, @newid CIOID, SRNO from TBL_BOOKING_SHARING_TRANS_g where CIOID=@pcioid

insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID, CREATIONDATETIME,FMG_REASONS)
select @newid CIOID, INSERTID, CREATIONDATETIME,FMG_REASONS from TBL_BOOKING_FMG_TRANS_G where CIOID=@pcioid

 update tbl_matter set cioid=@newid where "cioid"=@pcioid 
 
 select @billpay=Bill_pay,@rostatus=ro_status  from tbl_booking_mast where cio_booking_id=@newid
PRINT @rostatus
if (@billpay = 'CA0' or @billpay = 'CH0') and @rostatus='1' and @adtype!='WE0' begin
	PRINT 'START'
	declare @v_rcptno_r      varchar(50)
	declare @vrecpt       varchar(20)
	declare @branchcode   varchar(20)
	declare @vrepcode     varchar(20)
	declare @subagencyreg varchar(20)
	declare @prevcioid_v varchar(50)
	declare @billamt_v float
	declare @grossamt_v float
	declare @v_curdate datetime
	declare @book_compcode varchar(50)
	declare @book_branch varchar(50)
	declare @book_agencycode varchar(50)

	declare @prev_cioid varchar(50)

	declare @book_rec varchar(50)
	declare @book_doctype varchar(50)
	declare @book_client varchar(500)

	declare @book_datetime datetime

	declare @book_gross float
	declare @book_billamt float
	declare @book_userid varchar(50)
	declare @book_billpay varchar(50)
	declare @book_Agency_sub_code varchar(50)
	declare @book_exec varchar(50)
	declare @book_retainer varchar(50)
	declare @book_Agency_code varchar(50)
	declare @book_prev_cioid varchar(50)
	declare @othercurrencyamt float
	declare @othercurrencyfinalamt float
	declare @currcode varchar(50)
	declare @conrate float
	declare @maincurrency varchar(50)
	
	select @book_doctype=doctype,@book_client=client_code,@book_prev_cioid=prev_cioid,@book_Agency_code=Agency_code,@book_retainer=RETAINER,@book_exec=Executive_code,@book_Agency_sub_code=Agency_sub_code,@book_billpay=Bill_pay,@book_userid=userid,@book_datetime=date_time,@book_gross=Gross_amount,@book_billamt=Bill_amount,@prev_cioid=prev_cioid,@book_rec=receipt_no,@book_compcode=comp_code,@book_branch=branch,@book_agencycode=Agency_sub_code,@othercurrencyamt=LOCALBILLAMT,@currcode=RECEIPT_CURRENCY,@maincurrency=Currency_code from tbl_booking_mast where cio_booking_id=@newid

	select @branchcode=Branch_Code  from branch_mst where Comp_Code=@book_compcode and Branch_Name=@book_branch
    select @conrate=isnull(convert(float,Conv_Rate),1) from  CURR_CONV_DET where Curr_Code=@maincurrency and CONV_CURRENCY=@currcode and @book_datetime BETWEEN Valid_From_Date AND Valid_Till_Date
	select @subagencyreg=SUB_Agency_Code  from agency_mast where Comp_Code=@book_compcode and code_subcode=@book_agencycode
	set @vrecpt		=@book_rec
	set @prevcioid_v=@prev_cioid

	if @prevcioid_v is null or @prevcioid_v='' begin
			set @billamt_v	=@book_billamt
			set @grossamt_v	=@book_gross
			set @v_curdate	=@book_datetime
			set @othercurrencyfinalamt=@othercurrencyamt
	end
	else begin
			select @billamt_v=Bill_amount,@grossamt_v=Gross_amount,@othercurrencyfinalamt=LOCALBILLAMT from tbl_booking_mast where cio_booking_id=@prevcioid_v
			set @billamt_v	=@book_billamt - @billamt_v
			 set @grossamt_v=@book_gross - @grossamt_v
			 set @othercurrencyfinalamt=@othercurrencyamt-@othercurrencyfinalamt
			IF @grossamt_v = 0 OR @grossamt_v IS NULL
			BEGIN
				set @grossamt_v=@book_gross
			END
			 set @v_curdate=getdate()
	end

	SELECT @clientname=Cust_Name FROM CUST_MAST WHERE Cust_Code = @book_client and Comp_Code=@book_compcode
	if @clientname='' begin
		set @clientname=@book_client
	end	
	print @pcioid
	print @clientname
	select @remarks='RONO#'+RO_No +' RODATE# ' + isnull(convert(varchar(12),RO_Date,103),'') + ' BOOKINGID# ' + cio_booking_id + ' CLIENT#' + @clientname from tbl_booking_mast where cio_booking_id=@pcioid
	--print 'lata'
	--print @book_Agency_code
	--print @subagencyreg
	--print @cioid
	--print @book_exec
	--print @book_retainer
	--print @book_prev_cioid
	--print 'f'
	--print(@book_compcode+'#,'+@book_userid+'#,'+ @book_branch+'#,'+'RCP'+'#,'+@vrecpt+'#,'+convert(varchar(12),@v_curdate,103)+'#,'+@book_billpay+'#,'+''+'#,'+''+'#,'+cast(@billamt_v as varchar(10))+'#,'+@book_Agency_sub_code+'#,'+cast(@grossamt_v as varchar(20))+'#,')
	 --  print(''+'#,'+''+'#,'+''+'#,'+@remarks+'#,'+@vrepcode+'#,'+convert(varchar(12),@book_datetime,103)+'#,'+@book_Agency_code+'#,'+@subagencyreg+'#,'+''+'#,'+@cioid+'#,'+@book_exec+'#,'+@book_retainer+'#,'+@book_prev_cioid)
	set @conrate=isnull(@conrate,1)
	insert into #recpt_t 
	 exec receiptsave_booking @book_compcode,@book_userid, @book_branch,@book_doctype,@vrecpt,@v_curdate,@book_billpay,'','',@billamt_v,@book_Agency_sub_code,@grossamt_v,
	  '','','',@remarks,@vrepcode,@book_datetime,@book_Agency_code,@subagencyreg,'',@newid,@book_exec,@book_retainer,@book_prev_cioid,@othercurrencyfinalamt, @currcode,@conrate
	
	select @v_rcptno_r=receipt_no from   #recpt_t
	
	update tbl_booking_mast set Receipt_no=@v_rcptno_r where cio_booking_id=@newid
	
	drop table #recpt_t
	end

end
end
select @newid as "CIO_ID",@v_rcptno_r as "REC"
END

/////=========================================================================///////

ALTER PROCEDURE [dbo].[getdataforexecute]
@compcode as varchar(8),
@ciobid  as varchar(50)




AS

select cio_booking_id,Edition,Insert_date,Col_code,Height,Width,Size_book,Page_post,Premium1,Prem_per1,Premium2,Prem_per2,Premium_allow,Ad_cat,Ad_sub_cat,convert(varchar(10),Latest_by,101) as Latest_by,Status_material,File_name,Card_rate,Disc_rate,Insert_status,Bill_status,comp_code,Userid,Repeating_date,no_insert,Edition_code,Publication_code,Pub_cent_code,Supp_code,Agreed_rate,Pai_free_ins,Solo_rate,insert_id,Gross_rate,Page_no,Remarks,Page_prem,page_per,No_ofcolumn,Bill_Amt,Bill_rate,Logo_H,Logo_W,Logo_name,AD_SUBCAT3,AD_SUBCAT4,AD_SUBCAT5,PACKAGE_CODE,INSERTS,PKG_ALIAS
,Publication_Code AS PUBCODE
 ,(SELECT VTS FROM TBL_BOOKING_VTS WHERE CIOID=Cio_Booking_Id and INSERTID=Insert_Id) as VTS,
 (SELECT PUBLICATION FROM TBL_BOOKING_VTS WHERE CIOID=Cio_Booking_Id and INSERTID=Insert_Id) as CIRPUBLICATION,
 (SELECT EDITION FROM TBL_BOOKING_VTS WHERE CIOID=Cio_Booking_Id and INSERTID=Insert_Id) as CIREDITION,
 (SELECT RATE FROM TBL_BOOKING_VTS WHERE CIOID=Cio_Booking_Id and INSERTID=Insert_Id) as CIRRATE,
 (SELECT PUBLISHDATE FROM TBL_BOOKING_VTS WHERE CIOID=Cio_Booking_Id and INSERTID=Insert_Id) as CIRPUBLISHDATE,
 (SELECT edtn_name FROM cir_edtn_mast WHERE comp_code=@compcode AND edtn=(SELECT EDITION FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id")) AS CIREDITIONNAME
,'' as 'PRIORITY','' as SPLIT,SPECIAL_SIZE1,VATAMT,isnull(BOXCHARGE,'') as BOXCHARGE,isnull(VAT_INC,'0') as VAT_INC,ISNULL(LOCALGROSSAMT,gross_rate) as LOCALGROSSAMT, ISNULL(LOCALBILLAMT,bill_amt) AS LOCALBILLAMT,
isnull(sectioncode,'') as SECTIONCODE,isnull(RESOURCE_NO,'') as RESOURCE_NO,ISNULL(CAPTION,'') as CAPTION,DEALER_H,DEALER_W,ISNULL(DISCOUNT,'') AS DISCOUNT,BILL_DATE,
(select publication_type from pub_mast where pub_code=Publication_Code) AS 'PUBTYPE',agncyamnt,adlgncyamt,spldisamt,cashdisamt,INSERT_STATUS_PUB,ROUND_VALUE
  from tbl_booking_insert where comp_code=@compcode and cio_booking_id=@ciobid order by Insert_Id

/*
select col_Name ,col_Code from col_mast where comp_code=@compcode
select premiumname,Premiumcode from ADVPOS_PREM_MAST where comp_code=@compcode
select Adv_Subcat_Name,Adv_Subcat_Code from adv_subcat_mast
select uom_name,uom_code from uom_mast where comp_code=@compcode
select adv_type_name,adv_type_code from adv_type_mast where comp_code=@compcode
select adv_cat_name,adv_cat_code from ADV_CAT_MAST where comp_code=@compcode
select pos_type_code,pos_type from advpos_type_mast where comp_code=@compcode


select   Paid_permission    from Module_DetaiButtonl  where comp_code=@compcode and Form_Name='Booking_master'

*/

select '' as col_Name ,'' as col_Code
select '' as premiumname,'' as Premiumcode
select '' as Adv_Subcat_Name,'' as Adv_Subcat_Code
select '' as uom_name,'' as uom_code
select '' as adv_type_name,'' as adv_type_code
select '' as adv_cat_name,'' as adv_cat_code
select '' as pos_type_code,'' as pos_type


select   '' as Paid_permission  




////====================Update By Bhanu ==============================//






