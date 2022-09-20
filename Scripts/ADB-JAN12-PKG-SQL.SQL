/************************** Isusse 6199***********************/

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

set @query1='select 
c.Agency_Name AS "AGENCY",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE a.comp_code=CUST_MAST.comp_code AND Cust_Code=Client_code),Client_code)  AS "CLIENT", 
b.Edition as "EDITION",
CASE '''+@pdateformat+'''
 WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),Insert_Date,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),Insert_Date,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),Insert_Date,111)  END AS "PUB_DATE" ,
a."NO_OF_INSERTION",
isnull(a.Agrred_rate,a.Card_rate ) AS "RATE",
(select Comp_Name from comp_mst where comp_mst.Comp_Code=a.Comp_code) comp_name
from tbl_booking_mast a,tbl_booking_insert b,agency_mast c
WHERE a.Comp_code='''+@pcompcode+''' AND
a.Agency_sub_code=c.code_subcode AND
a.cio_booking_id=b.Cio_Booking_Id  and
 ((b.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )'

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

/************************** Isusse 6199***********************/

/*************************************************************************vts report by dimple********************************************************

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

set @query1='select 
c.Agency_Name AS "AGENCY",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE a.comp_code=CUST_MAST.comp_code AND Cust_Code=Client_code),Client_code)  AS "CLIENT", 
b.Edition as "EDITION",
CASE '''+@pdateformat+'''
 WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),Insert_Date,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),Insert_Date,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),Insert_Date,111)  END AS "PUB_DATE" ,
a."NO_OF_INSERTION",
isnull(a.Agrred_rate,a.Card_rate ) AS "RATE",
(select Comp_Name from comp_mst where comp_mst.Comp_Code=a.Comp_code) comp_name
from tbl_booking_mast a,tbl_booking_insert b,agency_mast c
WHERE a.Comp_code='''+@pcompcode+''' AND
a.Agency_sub_code=c.code_subcode AND
a.cio_booking_id=b.Cio_Booking_Id  and
 ((b.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )'

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

*********************************************************************vts report end**************************************************************



/*******************************contract***********************/


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[TV_packagebind]
	-- Add the parameters for the stored procedure here
	@compcode varchar(50),
	@adtype varchar(50),
	@channel_p varchar(50)
AS
BEGIN
if @adtype = 'EL0'
BEGIN
	select Combin_Code,Package_Name,(Combin_Code +'@'+ Combin_Desc) as 'pck_code' from tv_combin_mast
where Comp_Code=@compcode and (CHANNEL=@channel_p or @channel_p is null or @channel_p='') order by Package_Name
END
ELSE
BEGIN
select Combin_Code,Package_Name,(Combin_Code +'@'+ Combin_Desc) as 'pck_code' from combin_mast
where Comp_Code=@compcode and Ad_Type_code = @adtype order by Package_Name
END
END




/******************************contract***********************************************/

/******************mimoh 11jan2011********************/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[executebooking]
@compcode as varchar(8),
@ciobookid as varchar(50),
@docno as varchar(25)=null,
@keyno as varchar(50)=null,
@rono as varchar(20)=null,
@agencycode as varchar(50)=null,
@client as varchar(100)=null,
@booking as varchar(8),
@dateformat as varchar(20),
@revenue as varchar(50)

AS
declare @query as varchar(8000)


CREATE TABLE #tempbooking_mast (
	date_time  datetime ,
	branch  varchar (25) ,
	booked_by  varchar (25) ,
	cio_booking_id  varchar (50) ,
	prev_booking  varchar (25) ,
	applied_by  varchar (25) ,
	audit  varchar (25) ,
	RO_No  varchar (20) ,
	RO_Date  datetime ,
	Caption  varchar (500) ,
	bill_status  varchar (8) ,
	ro_status  varchar (8) ,
	Agency_code  varchar (8) ,
	Agency_address  varchar (500) ,
	Client_code  varchar (100) ,
	Client_address  varchar (500) ,
	Agency_sub_code  varchar (28) ,
	Dockit_no  varchar (25) ,
	Executive_code  varchar (8) ,
	Executive_zone  varchar (8) ,
	Product_code  varchar (8) ,
	Brand_code  varchar (8) ,
	Key_no  varchar (50) ,
	Bill_remarks  varchar (500) ,
	Print_remark  varchar (500) ,
	Package_code  varchar (500) ,
	No_of_insertion  int ,
	Insertion_date  datetime ,
	Repeating_day  varchar (8) ,
	Ad_type_code  varchar (8) ,
	Ad_cat_code  varchar (8) ,
	Ad_sub_cat_code  varchar (50) ,
	Color_code  varchar (8) ,
	Uom_code  varchar (8) ,
	Page_position_code  varchar (8) ,
	Page_type_code  varchar (100) ,
	Page_no  int ,
	Ad_size_type_code  varchar (8) ,
	Ad_size_height  float ,
	Ad_size_width  float ,
	Rate_code  varchar (100) ,
	Scheme_type_code  varchar (18) ,
	Currency_code  varchar (8) ,
	Agrred_rate  float ,
	Agreed_amount  float ,
	Special_discount  float ,
	Space_discount  float ,
	Special_charges  float ,
	Agency_status  varchar (15) ,
	Agency_type  varchar (25) ,
	Agency_pay  varchar (25) ,
	Agency_credit  int ,
	Total_area  float ,
	Card_rate  float ,
	Card_amount  float ,
	Discount  float ,
	Discount_per  float ,
	Bill_cycle  varchar (8) ,
	Revenue_center  varchar (8) ,
	Bill_pay  varchar (8) ,
	Bill_height  float ,
	Bill_width  float ,
	Bill_to  varchar (100) ,
	Invoices  int ,
	Vts  int ,
	Bill_add  varchar (500) ,
	Trade_disc  float ,
	Agency_out  varchar (50) ,
	Box_code  varchar (8) ,
	Box_no  varchar (8) ,
	Box_agency  varchar (2) ,
	Box_client  varchar (2) ,
	Box_address  varchar (500) ,
	Comp_code  varchar (8) ,
	Userid  varchar (8) ,
	Creation_datetime  datetime ,
	Booking_type  varchar (8) ,
	Tfn  varchar (2) ,
	Coupan_ad  varchar (2) ,
	Campaign  varchar (50) ,
	Bill_amount  float ,
	Page_prem  varchar (8) ,
	Page_amount  float ,
	Prem_per  float ,
	Gross_amount  float ,
	Ad_size_column  float ,
	Bill_column  float ,
	Bill_area  float ,
	Special_disc_per  float ,
	Space_disc_per  float ,
	Paid_ins  int ,
	Contract_rate  float ,
	Deviation  float ,
	Variant_code  varchar (8) ,
	Contract_name  varchar (50) ,
	Contract_type  varchar (50) ,
	Card_name  varchar (100) ,
	Card_type  varchar (50) ,
	Card_month  varchar (8) ,
	Card_year  varchar (8) ,
	Card_number  varchar (20) ,
	Receipt_no  varchar (50) ,
	Ad_Subcat3  varchar (8) ,
	Ad_Subcat4  varchar (8) ,
	Ad_subcat5  varchar (8) ,
	Bg_color  varchar (8) ,
	Bullet_code  varchar (8) ,
	Bullet_premium  float ,
	Material_status  varchar (8) ,
	Receipt_date  datetime ,
	prev_cioid  varchar (100) ,
	prev_receipt  varchar (50) ,
	prev_grossamt  float ,
	Region  varchar (8) ,
	Variant  varchar (8) ,
	status  varchar (50) ,
	Colortype  varchar (8) ,
	Logo_H  varchar (5) ,
	Logo_W  varchar (5) ,
	Logo_color  varchar (8) ,
	Logo_Uom  varchar (8) ,
	SAPID  varchar (50) ,
	RETAINER  varchar (50) ,
	ADD_AGENCY_COMM  varchar (8) ,
MOBILENO varchar (50) ,
ADD_AGENCY_COMM_AMT  varchar (50),
RETAINER_COMM  varchar (50),
RETAINER_COMM_AMT  varchar (50),
CASH_RECIEVED numeric,
CIRAGENCY varchar (50),
CIRRATE varchar (50),
CIREDITION varchar (50),
CIRPUBLICATION varchar (50),
CIRAGENCY_SUBCODE varchar (50),
BARTERTYPE VARCHAR(50),
addflag varchar(10),
CASHDISCOUNT FLOAT,
CASHDISCTYPE VARCHAR(5 ),
ATTACHMENT1 VARCHAR(50 ),
ATTACHMENT2 VARCHAR(50 ),
DISC_PREMIUM VARCHAR(50),
CHKTRADEDISC VARCHAR(1),
CHK_DATE datetime,CHK_AMT float,CHK_BANK_NAME varchar(50),OUR_BANK varchar(50),CHK_NO varchar(50),
DEALERPANEL VARCHAR(1),
DEALER_H float,
DEALER_W float,
DEALERTYPE VARCHAR(1),
ACTIVE_AGREEDRATE INT,ACTIVE_AGREEDAMT INT,
LOCALGROSSAMT FLOAT,
LOCALBILLAMT FLOAT,
PACKAGE_TYPE VARCHAR(5),
AD_REFID VARCHAR(50),
RECEIPT_CURRENCY VARCHAR(8),
CONV_CURR_RATE VARCHAR(8),
REVISE_DATE  datetime ,
CLIENT_TYPE VARCHAR(5)
)

set @query=' insert  #tempbooking_mast  select 
	date_time,
	branch,
	booked_by,
	cio_booking_id,
	prev_booking,
	applied_by,
	audit ,
	RO_No,
	RO_Date,
	Caption,
	bill_status,
	ro_status,
	Agency_code,
	Agency_address,
	Client_code,
	Client_address,
	Agency_sub_code,
	Dockit_no,
	Executive_code,
	Executive_zone,
	Product_code,
	Brand_code,
	Key_no,
	Bill_remarks,
	Print_remark,
	Package_code,
	No_of_insertion,
	Insertion_date,
	Repeating_day,
	Ad_type_code,
	Ad_cat_code,
	Ad_sub_cat_code,
	Color_code,
	Uom_code,
	Page_position_code,
	Page_type_code,
	Page_no,
	Ad_size_type_code,
	Ad_size_height,
	Ad_size_width,
	Rate_code,
	Scheme_type_code,
	Currency_code,
	Agrred_rate,
	Agreed_amount,
	Special_discount,
	Space_discount,
	Special_charges,
	Agency_status,
	Agency_type,
	Agency_pay,
	Agency_credit  ,
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
	Invoices  ,
	Vts  ,
	Bill_add,
	Trade_disc,
	Agency_out,
	Box_code,
	Box_no,
	Box_agency,
	Box_client,
	Box_address,
	Comp_code,
	Userid,
	Creation_datetime,
	Booking_type,
	Tfn,
	Coupan_ad,
	Campaign ,
	Bill_amount,
	Page_prem,
	Page_amount,
	Prem_per,
	Gross_amount,
	Ad_size_column,
	Bill_column,
	Bill_area,
	Special_disc_per,
	Space_disc_per ,
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
	status,
	Colortype,
	Logo_H,
	Logo_W,
	Logo_color,
	Logo_Uom,
	SAPID,
	RETAINER,
	ADD_AGENCY_COMM,
MOBILENO,ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,CASH_RECIEVED,
CIRAGENCY,CIRRATE,CIREDITION,CIRPUBLICATION,CIRAGENCY_SUBCODE,BARTER_TYPE,
(SELECT top 1 ADDITIONAL_FLAG  FROM COMM_DETAILS WHERE Agency_code+Agency_sub_code=tbl_booking_mast.Agency_sub_code and getdate() between eff_from_date and eff_till_date) AS ADDFLAG,
CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,CHKTRADEDISC,
CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,CHK_NO,DEALERPANEL,
DEALER_H,
DEALER_W,
DEALERTYPE
,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT,LOCALGROSSAMT,LOCALBILLAMT,PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,
REVISE_DATE,CLIENT_TYPE
	 from tbl_booking_mast where comp_code='''+@compcode+'''  '
print @ciobookid

if(@booking <> '0')
begin
set @query=@query+'and  (Ad_type_code = '''+@booking+''')' 
end 


if(@ciobookid<>'' )
begin
set @query=@query+'and  ( receipt_no='''+@ciobookid+''' or  cio_booking_id='''+@ciobookid+''')' 
end

--cio_booking_id = '''+@ciobookid+''' or

if(@docno<>'')
begin
set @query=@query+'and  Dockit_no = '''+@docno+''''
end

if(@keyno<>'')
begin
set @query=@query+'and  Key_no = '''+@keyno+''''
end

if(@rono<>'')
begin
set @query=@query+'and  RO_No = '''+@rono+''''
end

if(@agencycode<>'' )
begin
set @query=@query+'and  Agency_sub_code = '''+@agencycode+''''
end

if(@client<>'' ) 
begin
set @query=@query+'and  Client_code = '''+@client+''''
end

/*if(@booking<> '')
begin
set @query=@query +' and Ad_type_code='''+@booking+''''
end*/
 --set @query=@query + 'and branch='''+@revenue+''''
IF (@revenue IS NOT NULL or @revenue <> '')
--	set @query=@query + 'and branch in(select BRANCH_CODE FROM LOGIN_BRANCH_MAST  WHERE COMP_CODE='''+@compcode+''' and USER_CODE='''+@revenue+'''  and USER_FLAG=''Y'')'
-- SELECT BRANCH_CODE FROM LOGIN_BRANCH_MAST WHERE USER_CODE=revenue and COMP_CODE=compcode and USER_FLAG='Y')
print(@query)
exec(@query)


--insert into #tempbooking_mast(packgename)  select package_name from combin_mast where combin_code in (select Package_code from #tempbooking_mast)

--select convert(varchar(10),date_time,101) as  date_time,branch ,booked_by ,cio_booking_id ,prev_booking ,applied_by ,audit ,RO_No ,convert(varchar(10),RO_Date,101) as RO_Date ,Caption ,bill_status ,ro_status ,Agency_code ,Agency_address ,Client_code ,Client_address ,
select 
CASE @dateformat
                     WHEN 'mm/dd/yyyy' then convert(varchar(10),date_time,101)
	 WHEN 'dd/mm/yyyy' then convert(varchar(10),date_time,103)
WHEN 'yyyy/mm/dd' then convert(varchar(10),date_time,111)
	end	 as  DATE_TIME
,branch ,(select "Branch_Name" from branch_mst where "Branch_Code"="branch") as "BRANCH_NAME",
	booked_by ,cio_booking_id ,prev_booking ,applied_by ,audit ,RO_No ,CASE @dateformat
                     WHEN 'mm/dd/yyyy' then convert(varchar(10),ro_date,101)
	 WHEN 'dd/mm/yyyy' then convert(varchar(10),ro_date,103)
WHEN 'yyyy/mm/dd' then convert(varchar(10),ro_date,111)
	end  as RO_Date ,Caption ,bill_status ,ro_status ,#tempbooking_mast.Agency_code ,Agency_address ,Client_code  ,Client_address ,
	Agency_sub_code ,Dockit_no ,Executive_code  ,Executive_zone ,Product_code ,Brand_code ,Key_no ,Bill_remarks ,Print_remark ,Package_code ,No_of_insertion, CASE @dateformat
                     WHEN 'mm/dd/yyyy' then convert(varchar(10),Insertion_date,101)
	 WHEN 'dd/mm/yyyy' then convert(varchar(10),Insertion_date,103)
WHEN 'yyyy/mm/dd' then convert(varchar(10),Insertion_date,111)
	end as Insertion_date ,Repeating_day ,
	Ad_type_code ,	Ad_cat_code ,Ad_sub_cat_code ,Color_code ,Uom_code ,Page_position_code ,Page_type_code ,Page_no ,Ad_size_type_code ,Ad_size_height ,Ad_size_width ,Rate_code ,
   (select scheme_name from scheme_master where comp_code=@compcode and scheme_id=#tempbooking_mast.Scheme_type_code) as Scheme_type_code ,Currency_code ,Agrred_rate ,Agreed_amount ,Special_discount ,Space_discount ,Special_charges ,#tempbooking_mast.Comp_code ,	#tempbooking_mast.Userid,
	#tempbooking_mast.Agency_status ,
	Agency_type  ,
	Agency_pay  ,
	Agency_credit  ,
	Total_area  ,
	Card_rate  ,
	Card_amount  ,
	Discount  ,
	Discount_per  ,
	Bill_cycle,
	Revenue_center ,
	Bill_pay ,
	Bill_height  ,
	Bill_width  ,
	#tempbooking_mast.Bill_to ,
	Invoices  ,
	Vts  ,
	Bill_add ,
	Trade_disc  ,
	Agency_out ,
	#tempbooking_mast.Booking_type,
    Campaign,
	Page_prem,
	Page_amount,
	Prem_per,
	Gross_amount,
	Bill_amount,
	Box_code,
	Box_no,
	Box_agency,
	Box_client,
	Box_address,
	Tfn,
	Coupan_ad,
	Ad_size_column,
	Bill_column,
	Bill_area,
	Special_disc_per,
	Space_disc_per,
	agency_mast.agency_name+'('+agency_mast.code_subcode+')' as AgencyName,
(select exec_mast.exec_name+'('+convert(varchar(10),exec_mast.exe_no,101)+')' from exec_mast where   #tempbooking_mast.Executive_code=exec_mast.exe_no and #tempbooking_mast.comp_code=exec_mast.comp_code )  as execname ,
--	product_cat_mast.prod_desc+'('+product_cat_mast.prod_cat_code+')' ,

(select product_cat_mast.prod_desc+'('+product_cat_mast.prod_cat_code+')'  from   product_cat_mast where #tempbooking_mast.product_code=product_cat_mast.prod_cat_code
	and 	#tempbooking_mast.comp_code=product_cat_mast.comp_code) as product,	  

	Paid_ins,Contract_rate,Deviation,Variant_code,Contract_name,Contract_type,Card_name ,
	Card_type ,
	Card_month ,
	Card_year ,
	Card_number,
	Receipt_no ,
	Ad_Subcat3,
	Ad_Subcat4,
	Ad_subcat5,
	Bg_color,
	Bullet_code,
	Bullet_premium,
(select agency_name from agency_mast where comp_code=@compcode and code_subcode=#tempbooking_mast.agency_sub_code) as AgencySubCode,
isnull((select cust_name from CUST_MAST where comp_code=@compcode and cust_code=client_code),'')  as "Client",
(select payment_mode_name from Payment_Mode_Mast where comp_code=@compcode and pay_mode_code=agency_pay) as PayMode,
(select adv_cat_name from adv_cat_mast where comp_code=@compcode and adv_cat_mast.adv_cat_code=#tempbooking_mast.ad_cat_code) as categoryname,
(select  adv_subcat_name from adv_subcat_mast where comp_code=@compcode and adv_subcat_mast.adv_subcat_code=#tempbooking_mast.ad_sub_cat_code) as subcategoryname,
(select brand_name from brand_mst where comp_code=@compcode and brand_code=#tempbooking_mast.brand_code) as Brand,
(select uom_name from uom_mast where comp_code = @compcode and uom_code=#tempbooking_mast.uom_code) as UOM,
(select premiumname  from advpos_prem_mast where COMP_code=@compcode and premiumcode=#tempbooking_mast.page_type_code) as PagePremium,
(select pos_type from advpos_type_mast where comp_code=@compcode and pos_type_code=#tempbooking_mast.page_position_code) as PositionPremium,
(select curr_name from curr_mast where comp_code=@compcode and curr_code=#tempbooking_mast.currency_code) as Currency,
Material_status,
Receipt_date,#tempbooking_mast.region,Variant ,Colortype,	(select	uom_desc from uom_mast where comp_code=@compcode and uom_code=#tempbooking_mast.uom_code) as uom_desc,(select logo from uom_mast where comp_code=@compcode and uom_code=#tempbooking_mast.uom_code) as logo
	
	,Logo_H,Logo_W,Logo_color,Logo_Uom	,(select Logo_Uom from uom_mast  where comp_code=@compcode and uom_code=#tempbooking_mast.uom_code) as logocode,
	(select Box_Charges_Native from box_mast where comp_code=@compcode and box_mast.Box_Code=#tempbooking_mast.Box_code) as boxchrg,
retainer,(SELECT Retain_Name+'('+Retain_Code+')' FROM RETAINERMASTER WHERE comp_code=@compcode and RETAINERMASTER.Retain_Code=#TEMPBOOKING_MAST.RETAINER) AS RETAINER1,#tempbooking_mast.Booking_type as Booking_type,
(select Box_Charges_Type from box_mast where comp_code=@compcode and box_mast.Box_Code=#tempbooking_mast.Box_code) as boxchargetype,
ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,CASH_RECIEVED,
(select pub_center from branch_mst where Branch_Code=#tempbooking_mast.branch and Comp_Code=@compcode) as pub_center,
  CIRAGENCY,CIRRATE,CIREDITION,CIRPUBLICATION,CIRAGENCY_SUBCODE,BARTERTYPE,(SELECT BARTE_DESC FROM AD_BARTER WHERE COMP_CODE=@compcode AND BARTER_CODE=#TEMPBOOKING_MAST.BARTERTYPE) AS BARTE_DESC,
  (SELECT BARTER_AMOUNT FROM AD_BARTER WHERE COMP_CODE=@compcode AND  BARTER_CODE=#TEMPBOOKING_MAST.BARTERTYPE) AS BARTE_AMOUNT,ADD_AGENCY_COMM,ADDFLAG,
CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,CHKTRADEDISC AS CHKTRADE,CASE @dateformat
 WHEN 'mm/dd/yyyy' then convert(varchar(10),CHK_DATE,101)
WHEN 'dd/mm/yyyy' then convert(varchar(10),CHK_DATE,103)
WHEN 'yyyy/mm/dd' then convert(varchar(10),CHK_DATE,111)
	end as CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,CHK_NO, AGENCY_MAST.BOOKING_TYPE,
DEALERPANEL,
DEALER_H,
DEALER_W,
DEALERTYPE,MOBILENO,ISNULL(ACTIVE_AGREEDRATE,0) as ACTIVE_AGREEDRATE,ISNULL(ACTIVE_AGREEDAMT,0) as ACTIVE_AGREEDRATE,
ISNULL(LOCALGROSSAMT,GROSS_AMOUNT) AS LOCALGROSSAMT, ISNULL(LOCALBILLAMT,BILL_AMOUNT) AS LOCALBILLAMT,PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,
(select TOP 1 Comm_Rate from comm_details where Agency_code + Agency_sub_code=#tempbooking_mast.agency_sub_code
 and Comp_code=upper(@compcode) and getdate() between Eff_from_Date and Eff_Till_Date ) as COMM_RATE,
 CASE @dateformat
	WHEN 'mm/dd/yyyy' then convert(varchar(10),REVISE_DATE,101)
	WHEN 'dd/mm/yyyy' then convert(varchar(10),REVISE_DATE,103)
	WHEN 'yyyy/mm/dd' then convert(varchar(10),REVISE_DATE,111)
 end as REVISE_DATE,CLIENT_TYPE
	  from #tempbooking_mast,agency_mast where  agency_mast.code_subcode=#tempbooking_mast.agency_sub_code and agency_mast.comp_code=@compcode 
print('ankur')

----------------------------------------------------Lata------------------------------------------------------
/*
select count(*) as [count] from tbl_booking_mast_history where cio_booking_id=@ciobookid and audit<>''
declare @version int
select @version=max(version) from tbl_booking_mast_history where cio_booking_id=@ciobookid and version<(select max(version) from tbl_booking_mast_history where cio_booking_id=@ciobookid)



select convert(varchar(10),date_time,101) as  date_time,branch ,booked_by ,cio_booking_id ,prev_booking ,applied_by ,audit ,RO_No ,convert(varchar(10),RO_Date,101) as RO_Date ,Caption ,bill_status ,ro_status ,tbl_booking_mast_history.Agency_code ,Agency_address ,client_code  ,Client_address ,
	Agency_sub_code ,Dockit_no ,Executive_code  ,Executive_zone ,Product_code ,Brand_code ,Key_no ,Bill_remarks ,Print_remark ,Package_code ,No_of_insertion ,convert(varchar(10),Insertion_date,101) as Insertion_date ,Repeating_day ,
	Ad_type_code ,	Ad_cat_code ,Ad_sub_cat_code ,Color_code ,Uom_code ,Page_position_code ,Page_type_code ,Page_no ,Ad_size_type_code ,Ad_size_height ,Ad_size_width ,Rate_code ,
	Scheme_type_code ,Currency_code ,Agrred_rate ,Agreed_amount ,Special_discount ,Space_discount ,Special_charges ,tbl_booking_mast_history.Comp_code ,	tbl_booking_mast_history.Userid,
	tbl_booking_mast_history.Agency_status ,
	Agency_type  ,
	Agency_pay  ,
	Agency_credit  ,
	Total_area  ,
	Card_rate  ,
	Card_amount  ,
	Discount  ,
	Discount_per  ,
	Bill_cycle,
	Revenue_center ,
	Bill_pay ,
	Bill_height  ,
	Bill_width  ,
	tbl_booking_mast_history.Bill_to ,
	Invoices  ,
	Vts  ,
	Bill_add ,
	Trade_disc  ,
	Agency_out ,

	booking_type,
Campaign,
	Page_prem,
	Page_amount,
	Prem_per,
	Gross_amount,
	Bill_amount,
	Box_code,
	Box_no,
	Box_agency,
	Box_client,
	Box_address,
	Tfn,
	Coupan_ad,
	Ad_size_column,
	Bill_column,
	Bill_area,
	Special_disc_per,
	Space_disc_per,

	--(select agency_name+'('+agency_code+')' from agency_mast where agency_code in(select Agency_code from #tempbooking_mast) and type='p'  and comp_code=@compcode),
	--(select exec_name+'('+convert(varchar(10),exe_no,101)+')' from exec_mast where exe_no in (select Executive_code from #tempbooking_mast)  and comp_code=@compcode),
	--(select prod_desc+'('+prod_cat_code+')' from product_cat_mast where prod_cat_code in (select Product_code from #tempbooking_mast) and comp_code=@compcode),
	agency_mast.agency_name+'('+agency_mast.code_subcode+')' as AgencyName,
(select exec_mast.exec_name+'('+convert(varchar(10),exec_mast.exe_no,101)+')'  from exec_mast where   tbl_booking_mast_history.Executive_code=exec_mast.exe_no and tbl_booking_mast_history.comp_code=exec_mast.comp_code )  as execname ,
--	product_cat_mast.prod_desc+'('+product_cat_mast.prod_cat_code+')' ,

(select product_cat_mast.prod_desc+'('+product_cat_mast.prod_cat_code+')'  from   product_cat_mast where tbl_booking_mast_history.product_code=product_cat_mast.prod_cat_code
	and 	tbl_booking_mast_history.comp_code=product_cat_mast.comp_code) as product,	  

	Paid_ins,Contract_rate,Deviation,Variant_code,Contract_name,Contract_type,Card_name ,
	Card_type ,
	Card_month ,
	Card_year ,
	Card_number,
	Receipt_no ,
	Ad_Subcat3,
	Ad_Subcat4,
	Ad_subcat5,
	Bg_color,
	Bullet_code,
	Bullet_premium,
(select agency_name from agency_mast where code_subcode=tbl_booking_mast_history.agency_sub_code) as AgencySubCode,
isnull((select cust_name from CUST_MAST where cust_code=client_code),client_code)  as "Client",
(select payment_mode_name from Payment_Mode_Mast where pay_mode_code=agency_pay) as PayMode,
(select adv_cat_name from adv_cat_mast where adv_cat_mast.adv_cat_code=tbl_booking_mast_history.ad_cat_code) as categoryname,
(select  adv_subcat_name from adv_subcat_mast where adv_subcat_mast.adv_subcat_code=tbl_booking_mast_history.ad_sub_cat_code) as subcategoryname,
(select brand_name from brand_mst where brand_code=tbl_booking_mast_history.brand_code) as Brand,
(select uom_name from uom_mast where uom_code=tbl_booking_mast_history.uom_code) as UOM,
(select premiumname  from advpos_prem_mast where premiumcode=tbl_booking_mast_history.page_type_code) as PagePremium,
(select pos_type from advpos_type_mast where pos_type_code=tbl_booking_mast_history.page_position_code) as PositionPremium,
(select curr_name from curr_mast where curr_code=tbl_booking_mast_history.currency_code) as Currency
	
	
	  from tbl_booking_mast_history,agency_mast where tbl_booking_mast_history.cio_booking_id=@ciobookid and version=@version and agency_mast.code_subcode=tbl_booking_mast_history.agency_sub_code and agency_mast.comp_code=@compcode 


















--select * from tbl_booking_mast_history where cio_booking_id=@ciobookid and version=@version
select convert(varchar(10),date_time,101) as  date_time,branch ,booked_by ,cio_booking_id ,prev_booking ,applied_by ,audit ,RO_No ,convert(varchar(10),RO_Date,101) as RO_Date ,Caption ,bill_status ,ro_status ,tbl_booking_mast_history.Agency_code ,Agency_address ,client_code  ,Client_address ,
	Agency_sub_code ,Dockit_no ,Executive_code  ,Executive_zone ,Product_code ,Brand_code ,Key_no ,Bill_remarks ,Print_remark ,Package_code ,No_of_insertion ,convert(varchar(10),Insertion_date,101) as Insertion_date ,Repeating_day ,
	Ad_type_code ,	Ad_cat_code ,Ad_sub_cat_code ,Color_code ,Uom_code ,Page_position_code ,Page_type_code ,Page_no ,Ad_size_type_code ,Ad_size_height ,Ad_size_width ,Rate_code ,
	Scheme_type_code ,Currency_code ,Agrred_rate ,Agreed_amount ,Special_discount ,Space_discount ,Special_charges ,tbl_booking_mast_history.Comp_code ,	tbl_booking_mast_history.Userid,
	tbl_booking_mast_history.Agency_status ,
	Agency_type  ,
	Agency_pay  ,

	Agency_credit  ,
	Total_area  ,
	Card_rate  ,
	Card_amount  ,
	Discount  ,
	Discount_per  ,
	Bill_cycle,
	Revenue_center ,
	Bill_pay ,
	Bill_height  ,
	Bill_width  ,
	tbl_booking_mast_history.Bill_to ,
	Invoices  ,
	Vts  ,

	Bill_add ,
	Trade_disc  ,
	Agency_out ,
	booking_type,
Campaign,
	Page_prem,
	Page_amount,
	Prem_per,
	Gross_amount,
	Bill_amount,
	Box_code,
	Box_no,
	Box_agency,
	Box_client,
	Box_address,
	Tfn,
	Coupan_ad,
	Ad_size_column,
	Bill_column,
	Bill_area,
	Special_disc_per,
	Space_disc_per,
	--(select agency_name+'('+agency_code+')' from agency_mast where agency_code in(select Agency_code from #tempbooking_mast) and type='p'  and comp_code=@compcode),
	--(select exec_name+'('+convert(varchar(10),exe_no,101)+')' from exec_mast where exe_no in (select Executive_code from #tempbooking_mast)  and comp_code=@compcode),
	--(select prod_desc+'('+prod_cat_code+')' from product_cat_mast where prod_cat_code in (select Product_code from #tempbooking_mast) and comp_code=@compcode),
	agency_mast.agency_name+'('+agency_mast.code_subcode+')' as AgencyName,
(select exec_mast.exec_name+'('+convert(varchar(10),exec_mast.exe_no,101)+')'  from exec_mast where   tbl_booking_mast_history.Executive_code=exec_mast.exe_no and tbl_booking_mast_history.comp_code=exec_mast.comp_code )  as execname ,
--	product_cat_mast.prod_desc+'('+product_cat_mast.prod_cat_code+')' ,

(select product_cat_mast.prod_desc+'('+product_cat_mast.prod_cat_code+')'  from   product_cat_mast where tbl_booking_mast_history.product_code=product_cat_mast.prod_cat_code
	and 	tbl_booking_mast_history.comp_code=product_cat_mast.comp_code) as product,	  

	Paid_ins,Contract_rate,Deviation,Variant_code,Contract_name,Contract_type,Card_name ,
	Card_type ,
	Card_month ,
	Card_year ,
	Card_number,
	Receipt_no ,
	Ad_Subcat3,
	Ad_Subcat4,
	Ad_subcat5,
	Bg_color,
	Bullet_code,
	Bullet_premium,
(select agency_name from agency_mast where code_subcode=tbl_booking_mast_history.agency_sub_code) as AgencySubCode,
isnull((select cust_name from CUST_MAST where cust_code=client_code),client_code)  as "Client",
(select payment_mode_name from Payment_Mode_Mast where pay_mode_code=agency_pay) as PayMode,
(select adv_cat_name from adv_cat_mast where adv_cat_mast.adv_cat_code=tbl_booking_mast_history.ad_cat_code) as categoryname,
(select  adv_subcat_name from adv_subcat_mast where adv_subcat_mast.adv_subcat_code=tbl_booking_mast_history.ad_sub_cat_code) as subcategoryname,
(select brand_name from brand_mst where brand_code=tbl_booking_mast_history.brand_code) as Brand,
(select uom_name from uom_mast where uom_code=tbl_booking_mast_history.uom_code) as UOM,
(select premiumname  from advpos_prem_mast where premiumcode=tbl_booking_mast_history.page_type_code) as PagePremium,
(select pos_type from advpos_type_mast where pos_type_code=tbl_booking_mast_history.page_position_code) as PositionPremium,
(select curr_name from curr_mast where curr_code=tbl_booking_mast_history.currency_code) as Currency
	
	
	  from tbl_booking_mast_history,agency_mast where tbl_booking_mast_history.cio_booking_id=@ciobookid and version=(select max(version) from tbl_booking_mast_history where cio_booking_id=@ciobookid and version<(select max(version) from tbl_booking_mast_history where cio_booking_id=@ciobookid) and audit<>'')  and agency_mast.code_subcode=tbl_booking_mast_history.agency_sub_code and agency_mast.comp_code=@compcode 

--select * from tbl_booking_mast_history where cio_booking_id=@ciobookid and  version=(select max(version) from tbl_booking_mast_history where cio_booking_id=@ciobookid and version<(select max(version) from tbl_booking_mast_history where cio_booking_id=@ciobookid) and audit<>'') 
----------------------------------------------------END------------------------------------------------------
--#tempbooking_mast.Agency_sub_code


drop table #tempbooking_mast
*/

/**************************************************************************************************/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[committransaction]
	@pcioid          as  varchar(50),
	@totalcount      as  int,
	@pcompcode       as  varchar(20),
	@pcentname       as  varchar(20),
	@puserid         as  varchar(20),
	@pbkid_gentype   as  varchar(20),
	@pbk_type		 as  varchar(20)
AS
declare @countnum int
declare @billpay varchar(20)
declare @rostatus varchar(10)
declare @remarks varchar(500)
declare @clientname varchar(200)

declare @v_cursor1_var1  varchar(50)
declare @v_cursor1_var2  varchar(50)
declare @newid			 varchar(50)	

BEGIN
select @countnum=count(*) from tbl_booking_insert_g where Cio_Booking_Id=@pcioid
if @countnum=@totalcount begin

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
create table #recpt_t(receipt_no varchar(130))
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
			REVISE_DATE,CLIENT_TYPE)
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
			REVISE_DATE,CLIENT_TYPE
			 FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=@pcioid

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
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE,RESOURCE_NO)
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
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT, BOXCHARGE,VAT_INC, LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=@pcioid

INSERT INTO TBL_BOOKING_VTS(COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE) 
SELECT COMPCODE, @newid CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE FROM TBL_BOOKING_VTS_G WHERE  cioid=@pcioid


insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO)
select COMP_CODE, @newid CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO, SRNO from tbl_booking_subedition_g
where tbl_booking_subedition_g.CIOID=@pcioid;


insert into TBL_BOOKING_SHARING_TRANS(PUBLICATION, TYPE, SHARING, CIOID, SRNO)
select PUBLICATION, TYPE, SHARING, @newid CIOID, SRNO from TBL_BOOKING_SHARING_TRANS_g where CIOID=@pcioid

insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID, CREATIONDATETIME)
select @newid CIOID, INSERTID, CREATIONDATETIME from TBL_BOOKING_FMG_TRANS_G where CIOID=@pcioid

 select @billpay=Bill_pay,@rostatus=ro_status  from tbl_booking_mast where cio_booking_id=@newid
PRINT @rostatus
if (@billpay = 'CA0' or @billpay = 'CH0') and @rostatus='1' begin
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
	
	select @book_doctype=doctype,@book_client=client_code,@book_prev_cioid=prev_cioid,@book_Agency_code=Agency_code,@book_retainer=RETAINER,@book_exec=Executive_code,@book_Agency_sub_code=Agency_sub_code,@book_billpay=Bill_pay,@book_userid=userid,@book_datetime=date_time,@book_gross=Gross_amount,@book_billamt=Bill_amount,@prev_cioid=prev_cioid,@book_rec=receipt_no,@book_compcode=comp_code,@book_branch=branch,@book_agencycode=Agency_sub_code from tbl_booking_mast where cio_booking_id=@newid

	select @branchcode=Branch_Code  from branch_mst where Comp_Code=@book_compcode and Branch_Name=@book_branch

	select @subagencyreg=SUB_Agency_Code  from agency_mast where Comp_Code=@book_compcode and code_subcode=@book_agencycode
	set @vrecpt		=@book_rec
	set @prevcioid_v=@prev_cioid

	if @prevcioid_v is null or @prevcioid_v='' begin
			set @billamt_v	=@book_billamt
			set @grossamt_v	=@book_gross
			set @v_curdate	=@book_datetime
	end
	else begin
			select @billamt_v=Bill_amount,@grossamt_v=Gross_amount from tbl_booking_mast where cio_booking_id=@prevcioid_v
			set @billamt_v	=@book_billamt - @billamt_v
			 set @grossamt_v=@book_gross - @grossamt_v
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

	insert into #recpt_t 
	 exec receiptsave_booking @book_compcode,@book_userid, @book_branch,@book_doctype,@vrecpt,@v_curdate,@book_billpay,'','',@billamt_v,@book_Agency_sub_code,@grossamt_v,
	  '','','',@remarks,@vrepcode,@book_datetime,@book_Agency_code,@subagencyreg,'',@newid,@book_exec,@book_retainer,@book_prev_cioid
	
	select @v_rcptno_r=receipt_no from   #recpt_t
	
	update tbl_booking_mast set Receipt_no=@v_rcptno_r where cio_booking_id=@newid
	
	drop table #recpt_t
	end

end
select @newid as "CIO_ID"
END





/*******************************************************/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




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
@billamtlocal_p as float,
@chkadon_p as varchar(5),
@refid_p as varchar(50),
@rcpt_currency as varchar(8),
@cur_convrate as varchar(8),
@p_revisedate as datetime,
@clienttype as varchar(5)
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
LOCALBILLAMT,
PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY,CONV_CURR_RATE,
REVISE_DATE,CLIENT_TYPE
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
@billamtlocal_p,
@chkadon_p,@refid_p,@rcpt_currency,@cur_convrate,
@p_revisedate,@clienttype
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

































/******************mimoh 11jan2011********************/
///////////////////////////updated by Garima 
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





ALTER procedure  [dbo].[websp_bindcioidlatest12]
--@code as varchar(10),
@fromdate as varchar(10),
 @todate as varchar(10),
@date as varchar(15),
@publication as varchar(50),
@bookingcenter as varchar(40),
@revenuecenter as varchar(40),
@agencytype as varchar(30),
@package as varchar(40),
@adtype as varchar(50),
@agency as varchar(50),
@client as varchar(50),
@billstatus as varchar(50),
@rate_audit as varchar(8),
@billmode as  varchar(10),
@billcycle as varchar(10),
@v_retainer_name AS varchar(10),
@v_executive_name AS varchar(10),
@v_branch_name AS varchar(10),
@v_ad_category AS varchar(10),
@v_district AS varchar(10),
@v_taluka AS varchar(10),
@pcompcode AS varchar(10),
@billno as varchar(200),
@BILL_GEN_PRIOR as varchar(50)=null,
@PUB_CENT_HO as varchar(50)=null,
@centerlogin as varchar(50)=null,
@fmg_bills as varchar(20)=null,
@scheme_type as varchar(50)=null,
@pto_bill_no as varchar(50)

 AS



declare @package_cd  as varchar(300)
declare @package_result  as varchar(300)
declare @package_cd1  as varchar(300)
declare  @str as varchar(8000)
declare @billcyc as varchar(40)

declare @v_bill_criteria as varchar(10);

create table #package ( package_name varchar (100) )


print(@billcycle)


if @adtype='DI0' begin
    select @v_bill_criteria=disp_billing_criteria from preferrences where comp_code=@pcompcode
	end
else
	begin
    select @v_bill_criteria=clsd_billing_criteria From preferrences where comp_code=@pcompcode
	end


if(@billstatus='2')
begin


 set  @str='select distinct max(tbl_booking_insert.cio_booking_id) cio_booking_id,max(no_insert)as no_of_insertion ,max(tbl_booking_mast.package_code) as edition ,
/*isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=tbl_booking_mast.Client_code),tbl_booking_mast.Client_code)*/ ''''  AS client,
max(tbl_booking_mast.trade_disc) as Commission,convert(varchar,max(tbl_booking_insert.Insert_Date),101) as "pub_date",
AGENCY_MAST.agency_name as Agency,sum(tbl_booking_insert.gross_rate) as gross_rate,tbl_booking_insert.insert_status as status,count(tbl_booking_mast.no_of_insertion) as total,max(TBL_BOOKING_MAST.Bill_remarks) as Bill_remarks,
tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount"
from tbl_booking_insert,tbl_booking_mast,agency_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.cio_booking_id  
 and agency_mast.code_subcode=tbl_booking_mast.agency_sub_code  and ( tbl_booking_insert.insert_status=''billed'')' 
end






if(@billstatus=1 and @rate_audit='n' and ( @billmode='3' ))
begin
set  @str='SELECT  DISTINCT  TBL_BOOKING_INSERT.Cio_Booking_Id, No_Insert AS no_of_insertion ,TBL_BOOKING_MAST.Package_code  AS edition,
    isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client,
      AGENCY_MAST.Agency_Name AS Agency,sum(TBL_BOOKING_INSERT.Gross_Rate) as Gross_Rate,TBL_BOOKING_MAST.Trade_disc AS Commission,convert(varchar,tbl_booking_insert.Insert_Date,101) as "pub_date",
      TBL_BOOKING_INSERT.Insert_Status AS status,TBL_BOOKING_MAST.No_of_insertion AS total,TBL_BOOKING_MAST.Bill_remarks,

	  tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount"

      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
 AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code  AND (TBL_BOOKING_INSERT.Insert_Status=''billed'')' ;

end

if( @billstatus='3' )
begin
set  @str='select distinct  tbl_booking_insert.cio_booking_id,no_insert as no_of_insertion ,tbl_booking_mast.package_code as edition ,
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client,
tbl_booking_mast.trade_disc as Commission,convert(varchar,tbl_booking_insert.Insert_Date,101) as "pub_date",
AGENCY_MAST.agency_name as Agency,sum(tbl_booking_insert.gross_rate) as gross_rate,tbl_booking_insert.insert_status as status,tbl_booking_mast.no_of_insertion as total,TBL_BOOKING_MAST.Bill_remarks as Bill_remarks,

tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount"
from tbl_booking_insert,tbl_booking_mast,agency_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.cio_booking_id  
 and agency_mast.code_subcode=tbl_booking_mast.agency_sub_code  and ( tbl_booking_insert.insert_status=''audit by rate'')' 

end


IF(@billstatus=6)
begin
set  @str=' SELECT DISTINCT  TBL_BOOKING_INSERT.Cio_Booking_Id,No_Insert AS no_of_insertion ,TBL_BOOKING_MAST.Package_code AS edition ,
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client,
AGENCY_MAST.Agency_Name AS Agency,sum(TBL_BOOKING_INSERT.Gross_Rate) as Gross_Rate,TBL_BOOKING_MAST.Trade_disc AS Commission,convert(varchar,tbl_booking_insert.Insert_Date,101) as "pub_date",
TBL_BOOKING_INSERT.Insert_Status AS status,TBL_BOOKING_MAST.No_of_insertion AS  total,TBL_BOOKING_MAST.Bill_remarks,
tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount"
FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id  AND
 TBL_BOOKING_INSERT.Insert_Status=''booked'' AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code ';
END 


IF(@billstatus=5)
 begin

    set  @str='SELECT  DISTINCT  TBL_BOOKING_INSERT.Cio_Booking_Id, No_Insert AS no_of_insertion ,TBL_BOOKING_MAST.Package_code  AS edition,
      isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client,
      AGENCY_MAST.Agency_Name AS Agency,sum(TBL_BOOKING_INSERT.Gross_Rate) as Gross_Rate,TBL_BOOKING_MAST.Trade_disc AS Commission,convert(varchar,tbl_booking_insert.Insert_Date,101) as "pub_date",
      TBL_BOOKING_INSERT.Insert_Status AS status,TBL_BOOKING_MAST.No_of_insertion AS total,TBL_BOOKING_MAST.Bill_remarks,
      tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount"
      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id  AND
       TBL_BOOKING_INSERT.Insert_Status=''publish'' AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code' ;
   END 

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
if @v_bill_criteria='R' begin --it is for bill cycle in booking
	if(@billcycle is not null )
	begin
		set @str=@str+' and replace(TBL_BOOKING_MAST.Bill_cycle,''0'',''1'') ='''+@billcycle +''''
--print(@billcycle)
	end
end

if(@agency is not null)
begin

set @str=@str+' and TBL_BOOKING_MAST.agency_sub_code ='''+@agency +''''
end

if(@client is not null)
begin
set @str=@str+' and TBL_BOOKING_MAST.client_code ='''+@client +''''
end
if(@agencytype is not null)
begin
set @str=@str+' and TBL_BOOKING_mast.agency_type  ='''+@agencytype+''''
end


if(@adtype is not null)
begin
print(@adtype)
set @str=@str + ' and TBL_BOOKING_MAST. ad_type_code ='''+@adtype+''' '
End


if(@bookingcenter is not null)
begin
--print(@adtype)
set @str=@str + 'and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@bookingcenter+'''))';
--set @str=@str + ' and TBL_BOOKING_MAST. branch ='''+@bookingcenter+''' '
End


if(@revenuecenter is not null)
begin

set @str=@str + ' and TBL_BOOKING_MAST. branch ='''+@revenuecenter+''' '
End


if(@publication is not null)
begin
set @str=@str+' and  TBL_BOOKING_INSERT.publication_code='''+ @publication +''''
End

 if(@fromdate is not null and @todate is not null )
begin
	set @str=@str+' and insert_date between  '''+@fromdate +''' and  '''+@todate +''' '
end


--print('ankur33')
print(@package)
if(@package is not null)
begin
print(@package)
set @str=@str+' and  TBL_BOOKING_insert.edition ='''+@package +''''
End

/*
if(@BILL_GEN_PRIOR = 'PUB_CENT_HO')
begin
		if(@PUB_CENT_HO is not null) and @PUB_CENT_HO=@centerlogin
		begin
		set @str=@str+' and  ((TBL_BOOKING_INSERT.pub_cent_code='''+@PUB_CENT_HO+''''+') or (tbl_booking_insert.package_code in (SELECT package_code FROM temp_packagename)))'
		end
		else
		begin
		set @str=@str+' and  ((TBL_BOOKING_INSERT.pub_cent_code='''+@centerlogin+''''+') and (tbl_booking_insert.package_code not in (SELECT package_code FROM temp_packagename)))'
		end
end
*/
if((@billno is not null) and (@pto_bill_no is not null))
begin
		set @str=@str+' and  TBL_BOOKING_INSERT.bill_no between '''+@billno+'''  and '''+@pto_bill_no+''''

end



if(@fmg_bills !='Include')
begin
set @str=@str+' and tbl_booking_mast.Booking_type not in (''2'',''4'',''5'')'

end

if(@billstatus='2')
begin
	set @str=@str+' group by AGENCY_MAST.agency_name,tbl_booking_insert.insert_status ,
	tbl_booking_insert.bill_no,tbl_booking_insert.Comp_Code
	order by tbl_booking_insert.bill_no,cio_booking_id'
end
else
begin
	set @str=@str+' group by tbl_booking_insert.cio_booking_id,no_insert,tbl_booking_mast.package_code
	,tbl_booking_mast.client_code,tbl_booking_mast.trade_disc,AGENCY_MAST.agency_name
	,tbl_booking_insert.insert_status 
	,tbl_booking_mast.no_of_insertion ,TBL_BOOKING_MAST.Bill_remarks,tbl_booking_insert.bill_no,
	tbl_booking_insert.Comp_Code,tbl_booking_insert.Insert_Date 
	order by tbl_booking_insert.cio_booking_id,tbl_booking_insert.no_insert'
end












select  @package_cd1=tbl_booking_insert.package_code from tbl_booking_insert,tbl_booking_mast,agency_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.cio_booking_id  
 and agency_mast.code_subcode=tbl_booking_mast.agency_sub_code  and (tbl_booking_insert.insert_status ='publish' or tbl_booking_insert.insert_status='billed')
--insert into #package select replace(package_code,'''','') from dbo.PA_Splitedition(@editioncode,',' )


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




print( @str)
exec( @str)



select * from #package
delete from #package


/*if(@billstatus <> null)
begin
set @str=@str+' and  TBL_BOOKING_INSERT.insert_status='''+ @billstatus +''''
End*/





//////////////////////////////////////////Issue No. 4887/////////////////////////////////////////////////////////////////

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[completereport](
@compcode		as varchar(50)= NULL,
@fromdate		as varchar(50)= NULL,
@dateto			as varchar(50)= NULL,
@dateformat		as varchar(50)= NULL,
@publication	as varchar(50)= NULL,
@pub_cent		as varchar(50)= NULL,
@edition		as varchar(50)= NULL,
@suppliment		as varchar(50)= NULL,
@zone			as varchar(50)= NULL,
@branch			as varchar(50)= NULL,
@district		as varchar(50)= NULL,
@region			as varchar(50)= NULL,
@city			as varchar(50)= NULL,
@revcenter		as varchar(50)= NULL,
@adtype			as varchar(50)= NULL,
@agencytype		as varchar(50)= NULL,
@ratetype		as varchar(50)= NULL,
@adcat			as varchar(50)= NULL,
@adsubcat		as varchar(50)= NULL,
@adsubcat3		as varchar(50)= NULL,
@adsubcat4		as varchar(50)= NULL,
@adsubcat5		as varchar(50)= NULL,
@package		as varchar(50)= NULL,
@scheme			as varchar(50)= NULL,
@agency			as varchar(50)= NULL,
@client			as varchar(50)= NULL,
@executive		as varchar(50)= NULL,
@retainer		as varchar(50)= NULL,
@product		as varchar(50)= NULL,
@brand			as varchar(50)= NULL,
@varient		as varchar(50)= NULL,
@pagetype		as varchar(50)= NULL,
@pageprem		as varchar(50)= NULL,
@postprem		as varchar(50)= NULL,
@rostatus		as varchar(50)= NULL,
@booktype		as varchar(50)= NULL,
@contractname	as varchar(50)= NULL,
@filterby		as varchar(50)= NULL,
@adcheck		as varchar(50)=null,
@state			as varchar(50)=null,
@taluka			as varchar(50)=null,
@base			as varchar(50)=null,
@drpstatus		as varchar(50)=null,
@chkdetail		as varchar(50)=null,
@insertstatus	as varchar(50)=null,
@puserid		as varchar(50)=null,
@p_baxcode      as varchar(20)=null,
@chk_access		as varchar(2)=null)
AS
declare @query1 as VARCHAR(8000)
declare @v_val  as int
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
		and (tbl_booking_mast.Box_code = @p_baxcode or @p_baxcode is null)
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
		and (tbl_booking_mast.Box_code = @p_baxcode or @p_baxcode is null)
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
(select tbl_cat4.Cat_Name from tbl_cat4 where tbl_cat4.Cat_Code=a.Ad_Subcat4) as Adsubcat4,
(select tbl_cat5.Cat_Name from tbl_cat5 where tbl_cat5.Cat_Code=a.Ad_subcat5) as Adsubcat5,
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

IF(@p_baxcode IS NOT NULL and @p_baxcode <>'')
begin
set @query4=@query4 + ' and a.Box_code ='''+@p_baxcode+''''
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
PRINT 'LL'
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

IF(@p_baxcode IS NOT NULL and @p_baxcode <>'')
begin
set @query4=@query4 + ' and tbl_booking_mast.Box_code ='''+@p_baxcode+''''
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
PRINT 'SSK'
PRINT @QUERY1
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




///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/**********************ankit************* issue 6233***********16 jan*************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[getData_Export]
	@adtype_p varchar(20),
	@fromdate_p datetime,
	@todate_p datetime
AS
BEGIN
	SELECT Rate_Mast.[rateuniqueid]
      ,Rate_Mast.[Comp_code]
      ,Rate_Mast.[Rate_Mast_Code]
      ,Rate_Mast.[Adv_Type_Code]
      ,Rate_Mast.[Adv_Cat_Code]
      ,Rate_Mast.[Adv_subcat_code]
      ,Rate_Mast.[Rate_Gr_Code]
      ,Rate_Mast.[Currency]
      ,Rate_Mast.[combin_desc]
      ,Rate_Mast.[Combin_Code]
      ,Rate_Mast.[Uom]
      ,CONVERT(VARCHAR(12),Rate_Mast.[Valid_From],101) AS Valid_From
      ,CONVERT(VARCHAR(12),Rate_Mast.[Valid_To],101) AS Valid_To
      ,Rate_Mast.[Size_To]
      ,Rate_Mast.[Size_From]
      ,Rate_Mast.[consumption_Per]
      ,Rate_Mast.[Color]
      ,Rate_Mast.[Col_chr_typ]
      ,Rate_Mast.[Remarks]
      ,Rate_Mast.[Week_Day_Rate]
      ,Rate_Mast.[Week_min_rate]
      ,Rate_Mast.[Week_Extra_Rate]
      ,Rate_Mast.[Focus_Day_Rate]
      ,Rate_Mast.[Focus_min_rate]
      ,Rate_Mast.[Focus_extra_rate]
      ,Rate_Mast.[userid]
      ,Rate_Mast.[Creation_DateTime]
      ,Rate_Mast.[Premium]
      ,Rate_Mast.[Premium_Charges]
      ,Rate_Mast.[weekend_rate]
      ,Rate_Mast.[weekend_min_rate]
      ,Rate_Mast.[weekend_extra]
      ,Rate_Mast.[chksolo]
      ,Rate_Mast.[min_ad_area]
      ,Rate_Mast.[Edition_from]
      ,Rate_Mast.[Edition_to]
      ,Rate_Mast.[floor_amount]
      ,Rate_Mast.[floor_discount]
      ,Rate_Mast.[Scheme_Name]
      ,Rate_Mast.[Ad_Subcat4]
      ,Rate_Mast.[Ad_Subcat5]
      ,Rate_Mast.[Ad_subcat6]
      ,Rate_Mast.[From_insertion]
      ,Rate_Mast.[To_insertion]
      ,Rate_Mast.[Agency_type]
      ,Rate_Mast.[Client_cat]
      ,Rate_Mast.[Max_Area]
      ,Rate_Mast.[pub_center]
      ,Rate_Mast.[SUN_RATE]
      ,Rate_Mast.[MON_RATE]
      ,Rate_Mast.[TUE_RATE]
      ,Rate_Mast.[WED_RATE]
      ,Rate_Mast.[THU_RATE]
      ,Rate_Mast.[FRI_RATE]
      ,Rate_Mast.[SAT_RATE]
      ,Rate_Mast.[SUN_RATE_EXTRA]
      ,Rate_Mast.[MON_RATE_EXTRA]
      ,Rate_Mast.[TUE_RATE_EXTRA]
      ,Rate_Mast.[WED_RATE_EXTRA]
      ,Rate_Mast.[THU_RATE_EXTRA]
      ,Rate_Mast.[FRI_RATE_EXTRA]
      ,Rate_Mast.[SAT_RATE_EXTRA]
      ,Rate_Mast.[MAXWIDTH]
      ,Rate_Mast.[PRIORITY]
      ,Rate_Mast.[VAT_DETAIL]
      ,Rate_Mast.[ADON]
      ,Rate_Mast.[REF_ID]
	  ,RATE_DETAILS.[ratemastid]
      ,RATE_DETAILS.[id]
      ,RATE_DETAILS.[rate_code]
      ,RATE_DETAILS.[edition_name]
      ,RATE_DETAILS.[Week_Day_Rate]
      ,RATE_DETAILS.[Week_min_rate]
      ,RATE_DETAILS.[Week_Extra_Rate]
      ,RATE_DETAILS.[Focus_Day_Rate]
      ,RATE_DETAILS.[Focus_min_rate]
      ,RATE_DETAILS.[Focus_extra_rate]
      ,RATE_DETAILS.[userid]
      ,RATE_DETAILS.[Creation_DateTime]
      ,RATE_DETAILS.[Comp_Code]
      ,RATE_DETAILS.[Solus_week_rate]
      ,RATE_DETAILS.[Solus_focus_rate]
      ,RATE_DETAILS.[weekend_rate]
      ,RATE_DETAILS.[weekend_min]
      ,RATE_DETAILS.[weekend_extra]
      ,RATE_DETAILS.[Solo_weekendrate]
      ,RATE_DETAILS.[SUN_RATE]
      ,RATE_DETAILS.[MON_RATE]
      ,RATE_DETAILS.[TUE_RATE]
      ,RATE_DETAILS.[WED_RATE]
      ,RATE_DETAILS.[THU_RATE]
      ,RATE_DETAILS.[FRI_RATE]
      ,RATE_DETAILS.[SAT_RATE]
      ,RATE_DETAILS.[SUN_RATE_EXTRA]
      ,RATE_DETAILS.[MON_RATE_EXTRA]
      ,RATE_DETAILS.[TUE_RATE_EXTRA]
      ,RATE_DETAILS.[WED_RATE_EXTRA]
      ,RATE_DETAILS.[THU_RATE_EXTRA]
      ,RATE_DETAILS.[FRI_RATE_EXTRA]
      ,RATE_DETAILS.[SAT_RATE_EXTRA]
      ,RATE_DETAILS.[PKGNAME]	
  FROM [Rate_Mast]
FULL JOIN RATE_DETAILS ON
RATE_MAST.RATEUNIQUEID=RATE_DETAILS.RATEMASTID WHERE ADV_TYPE_CODE=@adtype_p and VALID_FROM>=@fromdate_p AND VALID_TO<=@todate_p  ORDER BY RATE_MAST.RATEUNIQUEID

  
END


/*******end***************ankit************* issue 6233***********16 jan*************/




/*************mimoh 6196*************************************************/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Getautocodebox](
@compcode      as       VARCHAR(50),
@auto1         as       varchar(50),
@no1          as        varchar(50),
@center1      as        varchar(50),
@agency_codescode as    varchar(50),
@branch as varchar(50),
@save_val as varchar(1)) 
AS
declare @idcou   int
declare @maxid  int
declare @fatchboxadd  varchar(1000)
declare @v_branch_nick  varchar(10)
declare @v_getno varchar(50)

select top 1 @fatchboxadd=BOX_ADDRESS,@v_branch_nick=UPPER(branch_nick) from branch_mst where Branch_Code=@branch and Comp_Code=@compcode

--SELECT @idcou=MAX(CONVERT(NUMERIC(8, 2), SUBSTRING(Box_no, 3, LEN(Box_no))))
--	FROM  AD_TABLEID 
SELECT @idcou= MAX(DBO.TRANSLATE(upper(Box_no),'ABCDEFGHIJKLMNOPQRSTUVWXYZ','0')) FROM  AD_TABLEID 
    where DBO.TRANSLATE(upper(Box_no),'1234567890','')=@v_branch_nick
    
print(@idcou)
if ISNULL(@idcou,0)<>0 
	begin
		print('idcou  not =0')
		--SELECT MAX(CONVERT(NUMERIC(8, 2), SUBSTRING(Box_no, 3, LEN(Box_no)))) AS boxno
		--FROM  AD_TABLEID 
		select @v_getno= @v_branch_nick+CONVERT(VARCHAR(10),MAX(DBO.TRANSLATE(upper(Box_no),'ABCDEFGHIJKLMNOPQRSTUVWXYZ','0'))+1) FROM  AD_TABLEID 
		   where DBO.TRANSLATE(upper(Box_no),'1234567890','')=@v_branch_nick
		select @v_getno as boxno   
		SELECT Box_Charges_Native, Box_Charges_Type	FROM  BOX_MAST 
			  WHERE	 Box_Code  = @no1
			 AND Comp_Code  = @compcode
	--set @idcou = @idcou + 1
		
		  if ISNULL(@save_val,'?')='S' 
			Begin
			   UPDATE AD_TABLEID SET Box_no =  @v_getno
				 where DBO.TRANSLATE(upper(Box_no),'1234567890','')=@v_branch_nick
			End
	end	
else
begin
  if ISNULL(@save_val,'?')='S'  and ISNULL(@idcou,0) = 0
  
    Begin
       INSERT INTO AD_TABLEID(Box_no) VALUES (@v_branch_nick+'1')
       select box_no AS BOXNO FROM   AD_TABLEID
         where DBO.TRANSLATE(upper(Box_no),'1234567890','')=@v_branch_nick 
    End
    
  else
    Begin
       select convert(varchar(10), @v_branch_nick)+'1' as boxno
    End  
--SELECT MAX(CONVERT(NUMERIC(8, 2), SUBSTRING(Box_no, 3, LEN(Box_no)))) AS boxno
	--FROM  AD_TABLEID 

    SELECT Box_Charges_Native,Box_Charges_Type  FROM BOX_MAST WHERE Box_Code = @no1 AND Comp_Code = @compcode
	
 end

if(@fatchboxadd='')
begin
 IF(@center1 IS NOT NULL and @center1!='0') 
	SELECT BOXADDRESS FROM PUB_CENT_MAST WHERE Pub_cent_Code=@center1
else

	SELECT BOXADDRESS FROM PUB_CENT_MAST WHERE City_Code=(SELECT City_Code FROM AGENCY_MAST WHERE code_subcode=@agency_codescode)
end
else
begin
select BOX_ADDRESS as BOXADDRESS from branch_mst where Branch_Code=@branch and Comp_Code=@compcode
end

/*************mimoh 6196*************************************************/


/**************************17 jan********************************* Isusse 6189**********************ankit***********************/



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE [dbo].[Ro_Report]
(@pcompcode      as varchar(20),
 @pdateformat    as varchar(20),
 @puserid        as varchar(20),
 @chk_access     as varchar(2),
 @pfromdate      as varchar(20),
 @pdateto        as varchar(20),
 @pprint_cent    as varchar(50),
 @pagency        as varchar(50),
 @pbranch        as varchar(50),
 @pdistrict      as varchar(50),
 @ptaluka        as varchar(50),
 @pro_doc_status as varchar(50),
 @ppay_mode      as varchar(50),
 @pexecutive     as varchar(50),
 @pretainer      as varchar(50),
 @det_summry     as varchar(50),
 @age_exeret     as varchar(50),
@pad_type       as varchar(50),
 @pad_cat        as varchar(50),
 @ptype          as varchar(50)
 )
as

BEGIN

declare @query1      varchar(8000)
declare @vvar        varchar(4000)
declare @vvar_sum    varchar(4000)

    if(@age_exeret='1')begin/*fot agency*/
				if(@det_summry='1')begin/*for detail*/
					set @query1='select distinct a.cio_booking_id as  "BOOKING_ID",b.Agency_Name AS "AGENCY", 
					isnull((select EXEC_MAST.Exec_name from exec_mast where a.Executive_code=exec_mast.Exe_no) ,(select RETAINERMASTER.Retain_Name  FROM  RETAINERMASTER where RETAINERMASTER.Retain_Code=a.RETAINER )) as "EXE_RET",
					isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS "CLIENT",
					c."Adv_Cat_Name" as "Ad_Cat",RO_No AS "RONO",
					CASE RODOCSTATUS
					WHEN ''o'' then ''ORIGINAL''
					WHEN ''f'' then ''FAX''
					WHEN ''x'' then ''XEROX'' END AS "ROSTATUS",
					isnull(a.Bill_amount,''0'') as "BILLAMT",
					min(convert(varchar(10), i."Insert_Date",101)) as "Publish_Date",
					a.RO_COMMENT as RO_COMMENT
					 from tbl_booking_mast a ,tbl_booking_insert i ,agency_mast b,adv_cat_mast c where
 a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
					a.Comp_code='''+@pcompcode+''' AND
					a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel'' '
				  end
					else/* for summary*/
					 begin
						set @query1='select DISTINCT b.Agency_Name AS "AGENCY",b.Dist_Code  as "DISTRICT",
						(SELECT Branch_Name FROM BRANCH_MST where  a.branch = Branch_Code) as "BRANCH",
						SUM(case RODOCSTATUS when ''o'' then 1 else 0 end) ORIGINAL,
    					SUM(case RODOCSTATUS when ''f'' then 1 else 0 end) FAX,
						SUM(case RODOCSTATUS when ''x'' then 1 else 0 end) XEROX,
						SUM(case RODOCSTATUS when ''o'' then 0 when ''f'' then 0 
						when ''x'' then 0 else 1 end) REMAIN					
						from TBL_BOOKING_MAST a,tbl_booking_insert i ,agency_mast b/*,adv_cat_mast c*/
            where a.Comp_code='''+@pcompcode+''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel'' ';
						end 
  end
    else/* for  executive/retainer*/
begin
				if(@det_summry='1')begin/*for detail*/
		          
					  if(@age_exeret='2')begin
					set @query1='select distinct a.cio_booking_id as  "BOOKING_ID",
					b.Agency_Name AS "AGENCY", EXEC_MAST.Exec_name  as "EXE_RET",      
					isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS "CLIENT",            
					c."Adv_Cat_Name" as "Ad_Cat",RO_No AS "RONO",
					CASE RODOCSTATUS
					WHEN ''o'' then ''ORIGINAL''
					WHEN ''f'' then ''FAX''
					WHEN ''x'' then ''XEROX'' END AS "ROSTATUS",
					isnull(a.Bill_amount,''0'') as "BILLAMT",
					min(convert(varchar(10), i."Insert_Date",101)) as "Publish_Date",
					a.RO_COMMENT as RO_COMMENT
					from TBL_BOOKING_MAST a,tbl_booking_insert i ,EXEC_MAST,agency_mast b ,adv_cat_mast c
            where a."Ad_type_code"=c."Adv_Type" and a."Ad_cat_code"=c."Adv_Cat_Code" and a."Comp_code"=c."Comp_Code" and
				a.Comp_code='''+@pcompcode+''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Executive_code"=exec_mast."Exe_no" AND 
             a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel'' '
				 end
				 else 
				begin
				 set @query1='select distinct a.cio_booking_id as  "BOOKING_ID",b.Agency_Name AS "AGENCY",  
					 RETAINERMASTER.Retain_Name     as "EXE_RET",
					isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS "CLIENT",            
					c."Adv_Cat_Name" as "Ad_Cat",  RO_No AS "RONO",
					CASE RODOCSTATUS
					WHEN ''o'' then ''ORIGINAL''
					WHEN ''f'' then ''FAX''
					WHEN ''x'' then ''XEROX'' END AS "ROSTATUS",
					isnull(a.Bill_amount,''0'') as "BILLAMT",
					min(convert(varchar(10), i."Insert_Date",101)) as "Publish_Date",
					a.RO_COMMENT as RO_COMMENT
					 from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER,agency_mast b ,adv_cat_mast c
            where  a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and 
a.Comp_code='''+@pcompcode+''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            RETAINERMASTER."Retain_Code"=a.RETAINER AND 
             a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel'' '
					end 
           end
        else/* for summary*/
begin
         
         if(@age_exeret='2')begin
            set @query1='select distinct EXEC_MAST.Exec_name  as "EXE_RET", EXEC_MAST.dist_code  as "DISTRICT",
            (SELECT Branch_Name FROM BRANCH_MST where  a.branch = Branch_Code) as "BRANCH",
           SUM(case RODOCSTATUS when ''o'' then 1 else 0 end) ORIGINAL,
			SUM(case RODOCSTATUS when ''f'' then 1 else 0 end) FAX,
			SUM(case RODOCSTATUS when ''x'' then 1 else 0 end) XEROX,
			SUM(case RODOCSTATUS when ''o'' then 0 when ''f'' then 0 when ''x'' then 0 else 1 end) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,EXEC_MAST ,agency_mast b /*,adv_cat_mast c*/
            where  a.Comp_code='''+@pcompcode+''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Executive_code"=exec_mast."Exe_no"  and i."Insert_Status"<>''cancel'' '
end
         else begin
         set @query1='select distinct RETAINERMASTER.Retain_Name     as "EXE_RET",RETAINERMASTER.Dist_Code   as "DISTRICT",
            (SELECT Branch_Name FROM BRANCH_MST where  a.branch = Branch_Code) as "BRANCH",
           SUM(case RODOCSTATUS when ''o'' then 1 else 0 end) ORIGINAL,
			SUM(case RODOCSTATUS when ''f'' then 1 else 0 end) FAX,
			SUM(case RODOCSTATUS when ''x'' then 1 else 0 end) XEROX,
			SUM(case RODOCSTATUS when ''o'' then 0 when ''f'' then 0 when ''x'' then 0 else 1 end) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER ,agency_mast b/*,adv_cat_mast c*/
            where  a.Comp_code='''+@pcompcode+''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            RETAINERMASTER."Retain_Code"=a.RETAINER and i."Insert_Status"<>''cancel'' '
            end 
        end 
    end 

    if(@pfromdate is not null and @pdateto is not null)begin
       set @query1=@query1+' and a.date_time between '''+@pfromdate+''' and '''+@pdateto+''' '
    end 


  if(@pad_type is not null)BEGIN
        SET @query1=@query1+' and a."Ad_type_code" = '''+@pad_type+''' '
    end 

    if(@pad_cat is not null)BEGIN
       SET @query1=@query1+' and a."Ad_cat_code" = '''+@pad_cat+''' '
    end 


 if(@pagency is not null)begin
         set @query1=@query1+' and a.Agency_code = '''+@pagency+''' '
    end 
    
  --new version 
    
 if(@pprint_cent is not null)begin
 set @query1=@query1+' and a.branch IN  (SELECT Branch_Code FROM BRANCH_MST WHERE a.branch=Branch_Code  and pub_center='''+@pprint_cent+''') '
end 

if(@pbranch is not null)begin
  set @query1=@query1+'  and a.branch = (SELECT Branch_Code FROM BRANCH_MST where Branch_Name ='''+@pbranch+''') '
end 
    

    
    if(@pdistrict is not null)begin
        if(@age_exeret='1')begin
             set @query1=@query1+' and b.Dist_Code = '''+@pdistrict+''' '
end
         else if(@age_exeret='2')begin
             set @query1=@query1+' and (a.Executive_code IS NOT NULL AND a.Executive_code in(select exec_mast.Exe_no from exec_mast  where EXEC_MAST.dist_code='''+@pdistrict+''' ) ) '
end
        else
             set @query1=@query1+' and  (a.RETAINER IS NOT NULL AND a.RETAINER IN(SELECT RETAINERMASTER.Retain_Code FROM RETAINERMASTER WHERE RETAINERMASTER.Dist_Code='''+@pdistrict+''')) '
        end 
    end 
    if(@ptaluka is not null)begin
        if(@age_exeret='1')begin
             set @query1=@query1+' and b.TALUKA = '''+@ptaluka+''' '
end
        else if(@age_exeret='2')begin
             set @query1=@query1+' and (a.Executive_code IS NOT NULL AND a.Executive_code in(select exec_mast.Exe_no from exec_mast  where EXEC_MAST.TALUKA='''+@ptaluka+'''  ) ) '
end
        else
begin
             set @query1=@query1+' and (a.RETAINER IS NOT NULL AND a.RETAINER IN(SELECT RETAINERMASTER.Retain_Code FROM RETAINERMASTER WHERE RETAINERMASTER.TALUKA='''+@ptaluka+''' )) '
        end 
    end 

    if(@pro_doc_status is not null)begin
         set @query1=@query1+' and a.RODOCSTATUS = '''+@pro_doc_status+''' '
    end 

    if(@ppay_mode is not null)begin
         set @query1=@query1+' and a.Bill_pay = '''+@ppay_mode+''' '
    end 

    if(@pexecutive is not null)begin
         set @query1=@query1+' and a.Executive_code = '''+@pexecutive+''' '
    end 

    if(@pretainer  is not null)begin
         set @query1=@query1+' and a.RETAINER = '''+@pretainer+''' '
    end 

--new version
  set @query1=@query1+' and a.branch in(select lb.branch_code from login_branch_mast lb where  lb.user_code='''+@puserid+''' and isnull(lb.user_flag,''N'')=''Y'') ' ;
--old version
   -- query1:=query1+' and a."branch" in(select branch_mst."Branch_Name" from branch_mst where branch_mst."Branch_Code" in (select lb.branch_code from login_branch_mast lb where  lb.user_code='''+puserid+''' and isnull(lb.user_flag,''N'')=''Y'')) ' ;


  if(@ptype is not null AND @ptype!='')BEGIN
        if (@ptype='U') BEGIN
          SET  @query1=@query1+' and (cast(i."Comp_Code" as varchar)+cast(i.bill_no as varchar)+cast(i.bill_date as varchar)  in(select /*+ (AD_OUTSTAND IND_OUT) */cast(o.comp_code as varchar)+cast(o.billno as varchar)+cast(o.billdt as varchar) 
                        from ad_outstand o where o.comp_code=i."Comp_Code" and o.ag_main_code=b."Agency_Code" and 
                        o.ag_sub_code=b."SUB_Agency_Code" and o.billdt=i.bill_date and o.billno=i.bill_no 
                        group by o.comp_code,o.billno,o.billdt having sum(o.amount)>=10) OR i.bill_no IS NULL ) ';
END
        else 
BEGIN
            SET  @query1=@query1+' and cast(i."Comp_Code" as varchar)+cast(i.bill_no as varchar)+cast(i.bill_date as varchar)  in(select /*+ (AD_OUTSTAND IND_OUT) */ cast(o.comp_code as varchar)+cast(o.billno as varchar)+cast(o.billdt as varchar) 
                        from ad_outstand o where o.comp_code=i."Comp_Code" and o.ag_main_code=b."Agency_Code" and 
                        o.ag_sub_code=b."SUB_Agency_Code" and o.billdt=i.bill_date and o.billno=i.bill_no 
                        group by o.comp_code,o.billno,o.billdt having sum(o.amount)=0)';
        end                 
    end 




    If(@det_summry!='1')Begin/*for summary*/
		if(@age_exeret='1')begin/*fot agency*/
			set @query1=@query1+' GROUP BY b.Agency_Name ,b.Dist_Code  ,a.branch'
		end
		else if(@age_exeret='2')begin
           set @query1=@query1+' group by EXEC_MAST.Exec_name,EXEC_MAST.dist_code,a.branch'
		end
		else begin
			set @query1=@query1+' GROUP BY RETAINERMASTER.Retain_Name,RETAINERMASTER.Dist_Code,a.branch'
		end 
    End
    Else Begin
		if(@age_exeret='1')Begin/*fot agency*/
            set @query1=@query1+' GROUP BY a."cio_booking_id"  ,b."Agency_Name"   ,a."Executive_code",a.RETAINER,"Client_code",c."Adv_Cat_Name","RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT'
        End    
        Else if(@age_exeret='2')Begin
            set @query1=@query1+' group by a."cio_booking_id"  ,b."Agency_Name",EXEC_MAST."Exec_name","Client_code",c."Adv_Cat_Name" ,"RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT '
        End    
        Else Begin
            set @query1=@query1+' GROUP BY a."cio_booking_id"  ,b."Agency_Name",RETAINERMASTER."Retain_Name","Client_code",c."Adv_Cat_Name" ,"RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT'
        End
    End 

    print(@query1)
	exec(@query1)
    
    select comp_mst.Comp_Name from comp_mst where comp_mst.Comp_Code=@pcompcode








set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER Procedure [dbo].[bindagencyforxls](
@compcode as varchar(10),
@agency as varchar(50)
)
 As

declare @qry  varchar(2000)
Begin


select  distinct  Agency_Code,Agency_Name+'-'+(Select distinct city_name from city_mst x where x.City_Code=Agency_mast.City_Code)
+'-'+Add1++'-'+Add2+'-'+Add3+Street AS Agency_Name,code_subcode, SUB_Agency_Code from Agency_mast where (Comp_Code=@compcode) and Agency_Name like '%'+ @agency + '%'  and (Type='P') order by Agency_Name

End








set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[xlsBindexecnew] 
(@compcode as VARCHAR(10),
@userid as VARCHAR(10),
@name1 as VARCHAR(50),
@executive as varchar(50)
)
   AS
   BEGIN

       	SELECT ltrim(rtrim(Exec_name)) Exec_name, ltrim(rtrim(Exe_no)) Exe_no FROM EXEC_MAST WHERE comp_code = @compcode AND (Team_code=@name1 or @name1 is null or @name1='')  
and Exec_name like  '%'+@executive + '%' order by Exec_name
   END







set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[xlsRetainerbind](
  @Compcode as VARCHAR(50),
  @retainer as VARCHAR(50)
  )
  AS
  BEGIN
  
    SELECT  Retain_Code,Retain_Name  FROM RETAINERMASTER WHERE Comp_Code= @Compcode and Retain_Name like '%'+ @retainer + '%' order by Retain_Name


END


*******end***************ankit************* issue 6289***********17 jan*************/


**********************ankit************* issue 6344***********18 jan*************/


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO





















ALTER PROCEDURE [dbo].[currbindpreferpgld]
@compcode as varchar(8)

AS

/*select date_format,autogenerated,currency_code,rate_gr_code,solo,breakup,blackwhitecode,rostatus,File_name,Tfn,Insert_breakup  , prefix,suffix,financestatus,voucherst,Ad_category,Ro_datetime,Vat,Booking_status,Cio_id,Receipt_no,uom_code,Bgcolor_publication,chkfor_valid_pubdates,
Agency_ratecode,audit,book_insert_date,agencycomm,rate_audit,bill_audit,billtype,Premium_type,copy_booking,RATE_COMPANY_AGENCY,ADDITIONAL_AGENCY_COMM,AGENCY_RETAINER_COMM,SUBEDITIONRATE,CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT,RATE_CHECK,ALL_PACKAGE,DAYRATE,SCHEME_TYPE,DISP_CLSBILL, RECEIPT_FORMAT ,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF ,  FMG_BILL_DIS,BARCODING_ALLOWED,BILL_DISP_CASHBILL,BILL_CLA_CASHBILL ,BACKDATERECEIPT,ROWISE_CASHBOOKING from preferrences where comp_code=@compcode
*/

  SELECT date_format, autogenerated, currency_code,
                rate_gr_code, solo, breakup, blackwhitecode,
                rostatus, File_name, Tfn, Insert_breakup, prefix,
                suffix, financestatus, voucherst, Ad_category,
                Ro_datetime, Vat, Booking_status, Cio_id,
                Receipt_no,uom_code,Bgcolor_publication,chkfor_valid_pubdates,Agency_ratecode,audit,book_insert_date,agencycomm,
                rate_audit,bill_audit,billtype,Premium_type,copy_booking,RATE_COMPANY_AGENCY,ADDITIONAL_AGENCY_COMM,AGENCY_RETAINER_COMM,SUBEDITIONRATE,CLS_BILLTYPE,DIS_BILLTYPE,
				BILLING_FORMAT,RATE_CHECK,ALL_PACKAGE,dayrate,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,
                ROKEYCHECK, AGENCYCOMM_SEQ_COM, CREDIT_RECIPT,  DISP_CASHBILL, CLA_CASHBILL,
				RATE_AUDIT_PREF,BARCODING_ALLOWED, FMG_BILL_DIS,BILL_DISP_CASHBILL, BILL_CLA_CASHBILL,BACKDATERECEIPT,ROWISE_CASHBOOKING,CUTOFFTIME,DOCKIT_BOOKING,APPROVAL,back_days as BACK_DAYS,CASH_DISCOUNT,CASH_DISCOUNTTYPE,Allowed_old_date,SEPRATE_CASHIER,
                CIR_MANY_TIME_POSTING, CIR_BACKDAYS_POSTING, CIR_MAX_RETURN_ALLOW, CIR_RETURN_LIMIT_ALLOW, CIR_NO_OF_CHQBOUNCE, CIR_DAYS_CHQBOUNCE, CIR_RETURN_DAYS, CIR_SUP_ORDER_LIMIT, DISP_BILLING_CRITERIA, CLSD_BILLING_CRITERIA,MAX_PUBLISHDAYS,BILLNO_PERIODICITY, SPECIALDISC_TRANS_EDIT, SHARING_TRANS, MULTIPACKAGE_SEL_TRANS,SCHEME_MINWORD, TRADE_SPLCHARGE,RATE_AUTHORIZATION,F2_RECORD,PUBLISHAD_EDIT_RATEAUDIT,BINDREVENUE_CENTER, FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,REPEAT_DAY_TYPE,PREMIUM_EDIT,
BILL_GENERATION_PRIOR,PUBLICATION_HO,SPLDISC_ALLOWPREM,BILL_SCHEME,
ALLOWED_PDC_DAYS_RECEIPT,AD_TYPE_MANUL_BILL, OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD,DISP_AUDITBKG,CIR_DIS_AUTO_POSTING,RELAUTHREQON,
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,Space_area
           FROM PREFERRENCES
          WHERE comp_code = @compcode





***********end***********ankit************* issue 6344***********18 jan*************/




/*******19 jan*************end*************** issue 6211*************************************mimoh**********/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[cheackdeal]
(
 @compcode as varchar(8),
 @dealno as varchar(10)
)
AS 
BEGIN
	
	SELECT AUDITBY, AUDIT_COMMENT FROM  CONTRACT_MAST WHERE Comp_code= @compcode and Deal_No=@dealno and AUDITBY is not null
		
END

/**********************************************************************************/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






ALTER PROCEDURE [dbo].[executecontract]

@compcode as varchar(8),--
@userid as varchar(8),--
@DealNo as varchar(8),--
@dealname as varchar(50),--
@agencycode as varchar(8),--
@subagencycode as varchar(8),--
@representative as varchar(8),
@dealtype as varchar(8)
--@contract_id as varchar(100)--



AS

declare @query as varchar(2000)



CREATE TABLE #Temp_Contract_mast (
	Deal_No varchar (8)  ,
	Comp_code varchar (8)  ,
	Agency_code varchar (80)  ,
	Sub_Agency_Code varchar (8)  ,
	Client_code varchar (80)  ,
	Product_code varchar (8)  ,
	From_date datetime  ,
	Till_date datetime  ,
	representative varchar (8)  ,
	Userid varchar (8)  ,
	Creation_datetime datetime  ,
	Total_val int ,
	Total_volu int ,
	team_code varchar(8),
	deal_type varchar(8),
	deal_name varchar(50),
	contract_id varchar(100),
	Ad_type varchar(12),
	REMARKS varchar(1000),
	EXECUTIVE varchar(20), 
	RETAINER varchar(20),
	CONTRACTDATE datetime,
	CLOSEDATE datetime,
	SERVICETAX datetime,
	PAYMENTTYPE varchar(200),
	CAPTION varchar(500),
B2B varchar(10), CHKMULTIAD varchar(10), SEQNO_ALLOW varchar(10), SEQNO varchar(10), AFT_PRTCLR_AD varchar(10), INDUSTRY varchar(10), INDUSTRY_PRODUCT varchar(100), DEALON VARCHAR(20),ATTACHMENT VARCHAR(20)
) 
/*

CREATE TABLE #temp_Contract_mast (
	Deal_No varchar (8) ,
	Comp_code varchar (8) ,
	Agency_code varchar (8)  ,
	Sub_Agency_Code varchar (8)  ,
	Client_code varchar (8)  ,
	Product_code varchar (8)  ,
	From_date datetime  ,
	Till_date datetime  ,
	representative varchar (8)  ,
	Adv_cat_code varchar (8)  ,
	Publication_code varchar (8)  ,
	suppliment_code varchar (8)  ,
	Edition_code varchar (8)  ,
	Booked_for varchar (8)  ,
	Color_code varchar (8)  ,
	Card_rate decimal(18, 0)  ,
	Deal_rate decimal(18, 0)  ,
	premium_code varchar (8)  ,
	Card_premium varchar (8)  ,
	Deal_premium varchar (8)  ,
	Volume_billed varchar (15)  ,
	Volume_disc varchar (15)  ,
	Value_from varchar (15)  ,
	Value_to varchar (15)  ,
	UOM_Code varchar (8)  ,
	Package_code varchar (8)  ,
	Userid varchar (8) ,
	Creation_datetime datetime ,
	Total_val int  ,
	Total_volu int  ,
	curr_code varchar (8)  ,
	team_code varchar (8)  ,
	deal_type varchar (8)  ,
	deal_name varchar (50)  
)*/




--delete from temp_contract_mast where comp_code=@compcode and userid=@userid
/*
set @query='insert into #Temp_Contract_mast  select   Deal_No AS Deal_No
,Comp_code AS Comp_code,
(select agency_name + ''('' + Agency_code + '')'' from agency_mast where agency_mast.Agency_code=contract_mast.agency_code and agency_mast.SUB_Agency_Code=contract_mast.Sub_Agency_Code)as Agency_code
,Sub_Agency_Code,(select Cust_Name + ''(''+Cust_Code+'')'' from cust_mast where cust_mast.Cust_Code=contract_mast.Client_Code) as Client_code,
Product_code,convert(varchar(10),From_date,101) as From_date,convert(varchar(10),Till_date,101) as Till_date,
representative,Userid,getdate(),Total_val,Total_volu,
team_code,deal_type,deal_name, contract_id,Ad_type,REMARKS,
(select Exec_name + ''(''+CAST(Exe_no AS VARCHAR(20))+'')'' 
from exec_mast where Exe_no=EXECUTIVE) as EXECUTIVE, 
(select Retain_Name+''('' + Retain_Code + '')'' from  retainermaster where Retain_Code=RETAINER) as RETAINER
, CONTRACTDATE, CLOSEDATE, SERVICETAX, PAYMENTTYPE, CAPTION,B2B, CHKMULTIAD, SEQNO_ALLOW, 
SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON  from contract_mast 
 where comp_code='''+@compcode+''''
*/
set @query='select   Deal_No AS Deal_No
,Comp_code AS Comp_code,
(select agency_name + ''('' + Agency_code + '')'' from agency_mast where agency_mast.Agency_code=contract_mast.agency_code and agency_mast.SUB_Agency_Code=contract_mast.Sub_Agency_Code)as Agency_code
,Sub_Agency_Code,(select Cust_Name + ''(''+Cust_Code+'')'' from cust_mast where cust_mast.Cust_Code=contract_mast.Client_Code) as Client_code,
Product_code,convert(varchar(10),From_date,101) as From_date,convert(varchar(10),Till_date,101) as Till_date,
representative,Userid,getdate(),Total_val,Total_volu,
team_code,deal_type,deal_name, contract_id,Ad_type,REMARKS,
(select Exec_name + ''(''+CAST(Exe_no AS VARCHAR(20))+'')'' 
from exec_mast where Exe_no=EXECUTIVE) as EXECUTIVE, 
(select Retain_Name+''('' + Retain_Code + '')'' from  retainermaster where Retain_Code=RETAINER) as RETAINER
, convert(varchar(10),CONTRACTDATE,101) as CONTRACTDATE, convert(varchar(10),CLOSEDATE,101) as CLOSEDATE, SERVICETAX, PAYMENTTYPE, CAPTION,B2B, CHKMULTIAD, SEQNO_ALLOW, 
SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON,ATTACHMENT  from contract_mast 
 where comp_code='''+@compcode+''''
if(@DealNo <> '')
begin
set @query=@query+'and Deal_No like ''%'+@DealNo+'%'''
end

if(@dealname <> '')
begin
set @query=@query+'and deal_name like ''%'+@dealname+'%'''
end

if(@agencycode <> '0' and @agencycode <>'')
begin
set @query=@query+'and Agency_code like '''+@agencycode+''''
end

if(@dealtype <> '0' and @dealtype <> '')
begin
set @query=@query+'and deal_type like '''+@dealtype+''''
end


if(@subagencycode <>''  and @subagencycode <> '0')
begin
	
	
	set @query=@query+' and Sub_Agency_Code like '''+@subagencycode+''''
	
end

if(@representative <> '0'  and  @representative <>'' ) 
begin
set @query=@query+' and Representative like '''+@representative+''''
end

print(@query)
exec(@query)
/*
select   Deal_No,Comp_code,Agency_code,Sub_Agency_Code,Client_code,Product_code,
convert(varchar(10),From_date,101) as From_date,convert(varchar(10),Till_date,101) as Till_date,
representative,Userid,Total_val,Total_volu,team_code,deal_type,deal_name,contract_id,Ad_type,REMARKS,EXECUTIVE, RETAINER, CONTRACTDATE, CLOSEDATE, SERVICETAX, PAYMENTTYPE, CAPTION,B2B, CHKMULTIAD, SEQNO_ALLOW, SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON   from #Temp_Contract_mast
*/
drop table #Temp_Contract_mast





/***************************************************/




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[BINDDEALforf2]
@p_compcode varchar(10),
@p_dealname  varchar(25)

AS


SELECT DISTINCT "Deal_No", "deal_name"
                 FROM contract_mast  where  "Comp_code"=@p_compcode 
                 AND ("deal_name" LIKE @p_dealname + '%' OR @p_dealname IS NULL) ;



/*******************************************************/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[updatecontactmast]

@compcode as varchar(8),
@userid as varchar(8),
@DealNo as varchar(8),
@dealname as varchar(50),
@agencycode as varchar(8),
@subagencycode as varchar(8),
@product as varchar(8),
@validfromdate as datetime,
@validtill as datetime,
@representative as varchar(8),
@clientname as varchar(8),
@totalvalue as float,
@totalvolume as float,
@currencys as varchar(8),
@teamname as varchar(8),
@dealtype as varchar(8),
@adtype as varchar(8),
@remarks as varchar(200),
@executive_var as varchar(20),
@retainer_var as varchar(20),
@contdate_var as datetime,
@closedate_var as datetime,
@servicetax_var as varchar(5),
@caption_var as varchar(500),
@paymode_var as varchar(200),
@b2b_var as varchar(10),
@chkmulti_var as varchar(10),
@chkseq_var as varchar(10),
@seqno_var as varchar(10),
@chkparti_var as varchar(10),
@indus_var as varchar(10),
@induspro_var as varchar(100),
@dealon_var as varchar(20),
@attachment1 as varchar(20)
AS

--insert into contract_mast(Deal_No,Comp_code,Agency_code,Sub_Agency_Code,Client_code,Product_code,From_date,Till_date,representative,Userid)values(@DealNo,@compcode,@agencycode,@subagencycode,@clientname,@product,@validfromdate,@validtill,@representative,@userid)

--update contract_mast set Agency_code=@agencycode,Sub_Agency_Code=@subagencycode,Client_code=@clientname,Product_code=@product,From_date=@validfromdate,Till_date=@validtill,representative=@representative,Total_val=@totalvalue,Total_volu=@totalvolume,curr_code=@currencys,team_code=@teamname,deal_type=@dealtype  where Deal_No=@DealNo and comp_code=@compcode and userid=@userid

update contract_mast set deal_name=@dealname,Agency_code=@agencycode,Sub_Agency_Code=@subagencycode,Client_code=@clientname,Product_code=@product,From_date=@validfromdate,Till_date=@validtill,representative=@representative,Total_val=@totalvalue,Total_volu=@totalvolume,curr_code=@currencys,team_code=@teamname,deal_type=@dealtype,Ad_type=@adtype,
REMARKS=@remarks,EXECUTIVE=@executive_var,RETAINER=@retainer_var,CONTRACTDATE=@contdate_var, CLOSEDATE=@closedate_var,
 SERVICETAX=@servicetax_var,PAYMENTTYPE=@paymode_var,CAPTION=@caption_var,
B2B=@b2b_var, CHKMULTIAD=@chkmulti_var, SEQNO_ALLOW=@chkseq_var, SEQNO=@seqno_var, AFT_PRTCLR_AD=@chkparti_var, INDUSTRY=@indus_var, INDUSTRY_PRODUCT=@induspro_var,
DEALON=@dealon_var,ATTACHMENT=@attachment1
  where Deal_No=@DealNo and comp_code=@compcode



/***********************************************************/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






ALTER PROCEDURE [dbo].[insertcontactmast]
@compcode as varchar(8),
@userid as varchar(8),
@DealNo as varchar(8),
@dealname as varchar(50),
@agencycode as varchar(8),
@subagencycode as varchar(8),
@product as varchar(8),
@validfromdate as datetime,
@validtill as datetime,
@representative as varchar(8),
@clientname as varchar(8),
@totalvalue as float,
@totalvolume as float,
@currencys as varchar(8),
@teamname as varchar(8),
@dealtype as varchar(8),
@adtype as varchar(8),
@remarks as varchar(200),
@executive_var as varchar(20),
@retainer_var as varchar(20),
@contdate_var as datetime,
@closedate_var as datetime,
@servicetax_var as varchar(5),
@caption_var as varchar(500),
@paymode_var as varchar(200),
@b2b_var as varchar(10),
@chkmulti_var as varchar(10),
@chkseq_var as varchar(10),
@seqno_var as varchar(10),
@chkparti_var as varchar(10),
@indus_var as varchar(10),
@induspro_var as varchar(100),
@dealon_var as varchar(20),
@attachment1 as varchar(20)
AS

insert into contract_mast(Deal_No,Comp_code,Agency_code,Sub_Agency_Code,Client_code,Product_code,From_date,Till_date,representative,Userid,Total_val,Total_volu,curr_code,team_code,deal_type,deal_name,Ad_type,REMARKS,EXECUTIVE,RETAINER,CONTRACTDATE, CLOSEDATE, SERVICETAX,PAYMENTTYPE,CAPTION,B2B, CHKMULTIAD, SEQNO_ALLOW, SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON,ATTACHMENT )
values(@DealNo,@compcode,@agencycode,@subagencycode,@clientname,@product,@validfromdate,@validtill,@representative,@userid,@totalvalue,@totalvolume,@currencys,@teamname,@dealtype,@dealname,@adtype,@remarks,@executive_var,@retainer_var,@contdate_var,@closedate_var,@servicetax_var,@paymode_var,@caption_var,@b2b_var,@chkmulti_var,@chkseq_var,@seqno_var,@chkparti_var,@indus_var,@induspro_var,@dealon_var,@attachment1)














/*******19 jan*************end*************** issue 6211*************************************mimoh**********/


/*******18 jan*************end*************** issue 6257*************************************kuldeep**********/



ALTER PROCEDURE [dbo].[advsubcattyp]
@compcode as varchar(8),
--@userid as varchar(50),
@catcode as varchar(20)
--@agencytype as varchar(20)



AS

--select Adv_Type_Code,Adv_Type_Name from adv_type_mast where comp_code=@compcode and  userid=@userid

select Adv_Subcat_Code,Adv_Subcat_Name from adv_subcat_mast where comp_code=@compcode and (STATUS='1' or STATUS is null) and  adv_cat_code=@catcode

--select Comm_Rate from agency_type_mst where comp_code=@compcode and  ad_category=@catcode and agency_type_code=@agencytype


--select distinct Edition_combin_code from combin_mast where comp_code=@compcode and  userid=@userid



@@@@@@@@@@@@@@@@@@@@@@@@@@@@

CREATE  PROCEDURE ADB_GETBILLNOBILLDAET(
@p_cioid          as varchar(50),
@p_insertno       as varchar(50),
@p_compcode       as varchar(20),
@p_dateformat     as varchar(50),
@extra1           as varchar(50),
@extra2           as varchar(50),
@extra3           as varchar(50)
)
as
BEGIN
  select BILL_NO,dbo.fnFormatDate(BILL_DATE,@p_dateformat) as "BILL_DATE" from tbl_booking_insert where Comp_Code=@p_compcode and Cio_Booking_Id=@p_cioid and No_Insert=@p_insertno

END

/*******18 jan*************end*************** issue 6257*************************************kuldeep**********/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@6051 start@@@@@@@@KULDEEP@@@@@@@@@@





ALTER  PROCEDURE [dbo].[ADB_GETAGENCY_REMARKDETAIL](
@p_agency_code          as varchar(50),
@p_subagency_code       as varchar(50),
@p_cust_code            as varchar(50),
@p_type                 as varchar(50),
@p_compcode             as varchar(20),
@p_dateformat           as varchar(50),
@extra                  as varchar(50)
)
as
BEGIN
    IF @p_type ='A' 
        BEGIN
        SELECT AGENCY_ALERT as "AGENCY_REMARK",dbo.fnFormatDate(CREATION_DATETIME,@p_dateformat) as "CREATION_DATE" FROM  AGENCY_REMARK_DETAIL 
        WHERE COMP_CODE=@p_compcode AND AGENCY_CODE=@p_agency_code AND SUB_AGENCY_CODE=@p_subagency_code order by CREATION_DATETIME
        END
    ELSE
		BEGIN
        SELECT CUST_REMARK,dbo.fnFormatDate(CREATION_DATETIME,@p_dateformat) as "CREATION_DATE" FROM CUST_REMARK_DETAIL 
        WHERE COMP_CODE=@p_compcode AND CUST_CODE=@p_cust_code  order by CREATION_DATETIME
        END
END


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

CREATE  PROCEDURE ADB_GETAGENCY_REMARKDETAIL(
@p_agency_code          as varchar(50),
@p_subagency_code       as varchar(50),
@p_cust_code            as varchar(50),
@p_type                 as varchar(50),
@p_compcode             as varchar(20),
@p_dateformat           as varchar(50),
@extra                  as varchar(50)
)
as
BEGIN
    IF @p_type ='A' 
        BEGIN
        SELECT AGENCY_REMARK,dbo.fnFormatDate(CREATION_DATETIME,@p_dateformat) as "CREATION_DATE" FROM  AGENCY_REMARK_DETAIL 
        WHERE COMP_CODE=@p_compcode AND AGENCY_CODE=@p_agency_code AND SUB_AGENCY_CODE=@p_subagency_code order by CREATION_DATETIME
        END
    ELSE
		BEGIN
        SELECT CUST_REMARK,dbo.fnFormatDate(CREATION_DATETIME,@p_dateformat) as "CREATION_DATE" FROM CUST_REMARK_DETAIL 
        WHERE COMP_CODE=@p_compcode AND CUST_CODE=@p_cust_code  order by CREATION_DATETIME
        END
END

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER PROCEDURE [dbo].[advsubcattyp]
@compcode as varchar(8),
--@userid as varchar(50),
@catcode as varchar(20)
--@agencytype as varchar(20)



AS

--select Adv_Type_Code,Adv_Type_Name from adv_type_mast where comp_code=@compcode and  userid=@userid

select Adv_Subcat_Code,Adv_Subcat_Name from adv_subcat_mast where comp_code=@compcode and (STATUS='1' or STATUS is null) and  adv_cat_code=@catcode

--select Comm_Rate from agency_type_mst where comp_code=@compcode and  ad_category=@catcode and agency_type_code=@agencytype


--select distinct Edition_combin_code from combin_mast where comp_code=@compcode and  userid=@userid

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@6051 END@@@@@@@@@@@@@@@@@@@@@@@@



/******* jan**************************** issue 6336*************************************ankit**********/


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[paymentexe]

@compcode as varchar(8),
@paycode as varchar(8),
@payname as varchar(20),

@userid  as varchar(8)


AS
declare @query varchar(1000)
/*create table #Payment_Mode_Mast (
	Comp_Code varchar (8)  ,
	Pay_Mode_Code varchar (8)  ,
	Payment_Mode_Name varchar (20),
	Userid varchar (8) 
             ---Creation_Datetime 
	
) 
*/
begin

--set @query= ' insert  into   #Payment_Mode_Mast  select Comp_Code, Pay_Mode_Code,Payment_Mode_Name,Userid  from   payment_mode_mast where Comp_Code='''+@compcode+'''  '--and userid='''+@userid+'''   '
set @query= 'select Comp_Code, Pay_Mode_Code,Payment_Mode_Name,Userid,PAYMENT_MODE_ALIAS,CASHDISCOUNT AS CASH  from   payment_mode_mast where Comp_Code='''+@compcode+'''  '

end

if(  @paycode <> '')
begin
set @query = @query + '  and   Pay_Mode_Code like ''%'+@paycode+'%''  '    
end


if(  @payname <> '' )
begin
set @query = @query + '  and   Payment_Mode_Name like ''%'+@payname+'%''  '    
end

print(@query)
exec(@query)

--select * from #Payment_Mode_Mast 
--drop table #Payment_Mode_Mast



/******* jan**************************** issue 6336*************************************ankit**********/


/******* jan**************************** issue *************ankit************************vishal**********/


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
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
@PREFIX AS VARCHAR(10)
as 

update PUB_MAST set PREFIX_PUB_NAME=@PREFIX,pub_name=@pubname, pub_alias=@pubalias, lang_code=@langcode, priority=@priority, establish_date=@estdate, cont_person=@contperson, phone=@phone, fax=@fax, emailid=@emailid,publication_type=@pubtype,preodicity=@preocity,Phone1=@phone2,Fax1=@fax2,Gutter_Space=@gutter_space,Column_Space=@column_space, rotimehr=@hr, rotimemin=@mint, production=@prod,No_Of_Collumn=@noofcol ,publisher_code=@publish_code where comp_code=@comcode /*and userid=@userid*/ and pub_code=@pubcode

--update Publicationfirst set pub_name=@pubname, pub_alias=@pubalias, lang_code=@langcode, priority=@priority, establish_date=@estdate, cont_person=@contperson, phone=@phone, fax=@fax, emailid=@emailid,publication_type=@pubtype,preodicity=@preocity,Phone1=@phone2,Fax1=@fax2,Gutter_Space=@gutter_space,Column_Space=@column_space    where comp_code=@comcode /*and userid=@userid*/ and pub_code=@pubcode








set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
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
@PREFIX AS VARCHAR(10)
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
           ,[PUBLISHER_CODE],PREFIX_PUB_NAME
           ) values(@comcode ,@priority,@pubcode,@pubname,@pubalias,@langcode,@estdate,@contperson,@phone,@fax,@emailid,@userid, getdate(),@pubtype,@preocity,@phone2,@fax2,@gutter_space,@column_space,@hr,@mint,@prod,@noofcol,@publish_code,@PREFIX)






/******* jan**************************** issue *************ankit************************vishal**********/



@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@6421@@@@@@@@@@@@@@@



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
@caption_inserts_p as varchar(500)
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
update tbl_booking_insert set Edition=@edition,Insert_date=@insertdate,Col_code=@colid,Height=@height,Width=@width,Size_book=@totalsize,Page_post=@pagepost,Premium1=@premium1,Prem_per1=@premper1,Premium2=@premium2,Prem_per2=@premper2,Premium_allow=@premallow,Ad_cat=@adcategory,Ad_sub_cat=@adsubcat,Latest_by=@latestdate,Status_material=@material,File_name=@matfilename,Card_rate=@cardrate,Disc_rate=@discrate,Insert_status=@insertstatus,Bill_status=@billstatus,comp_code=@compcode,Userid=@userid,Repeating_date=@repeat,no_insert=@insertno,Edition_code=@edi,Publication_code=@publi,Pub_cent_code=@pub_cent,Supp_code=@supp,Pai_free_ins=@paid,Agreed_rate=@agrrate,Solo_rate=@solorate,Gross_rate=@grossrate,Page_no=@insert_pageno,Remarks=@insert_remarks,Page_prem=@page_code,page_per=@page_per,No_ofcolumn=@noofcol,Bill_Amt=@billamt,Bill_rate=@billrate,Logo_H=@logo_h,Logo_W=@logo_w,Logo_name=@logo_name,AD_SUBCAT3=@ad_cat_3,AD_SUBCAT4=@ad_cat_4,AD_SUBCAT5=@ad_cat_5,PACKAGE_CODE=@pkgcode,INSERTS=@gridins,PKG_ALIAS=@pkgalias ,SPECIAL_SIZE1=@splboldsizevalue,VATAMT=@vatrate_p,BOXCHARGE=@boxcharge_p, VAT_INC=@vat_inc_p,LOCALGROSSAMT =@grossamtlocal_p,LOCALBILLAMT = @billamtlocal_p,sectioncode=@sectioncode_p,RESOURCE_NO=@resourceno_p,CAPTION=@caption_inserts_p
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

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER PROCEDURE [dbo].[getdataforexecute]
@compcode as varchar(8),
@ciobid  as varchar(50)




AS

select cio_booking_id,Edition,Insert_date,Col_code,Height,Width,Size_book,Page_post,Premium1,Prem_per1,Premium2,Prem_per2,Premium_allow,Ad_cat,Ad_sub_cat,Latest_by,Status_material,File_name,Card_rate,Disc_rate,Insert_status,Bill_status,comp_code,Userid,Repeating_date,no_insert,Edition_code,Publication_code,Pub_cent_code,Supp_code,Agreed_rate,Pai_free_ins,Solo_rate,insert_id,Gross_rate,Page_no,Remarks,Page_prem,page_per,No_ofcolumn,Bill_Amt,Bill_rate,Logo_H,Logo_W,Logo_name,AD_SUBCAT3,AD_SUBCAT4,AD_SUBCAT5,PACKAGE_CODE,INSERTS,PKG_ALIAS
,Publication_Code AS PUBCODE
 ,(SELECT VTS FROM TBL_BOOKING_VTS WHERE CIOID=Cio_Booking_Id and INSERTID=Insert_Id) as VTS,
 (SELECT PUBLICATION FROM TBL_BOOKING_VTS WHERE CIOID=Cio_Booking_Id and INSERTID=Insert_Id) as CIRPUBLICATION,
 (SELECT EDITION FROM TBL_BOOKING_VTS WHERE CIOID=Cio_Booking_Id and INSERTID=Insert_Id) as CIREDITION,
 (SELECT RATE FROM TBL_BOOKING_VTS WHERE CIOID=Cio_Booking_Id and INSERTID=Insert_Id) as CIRRATE,
 (SELECT PUBLISHDATE FROM TBL_BOOKING_VTS WHERE CIOID=Cio_Booking_Id and INSERTID=Insert_Id) as CIRPUBLISHDATE,
 (SELECT edtn_name FROM cir_edtn_mast WHERE comp_code=@compcode AND edtn=(SELECT EDITION FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id")) AS CIREDITIONNAME
,'' as 'PRIORITY','' as SPLIT,SPECIAL_SIZE1,VATAMT,isnull(BOXCHARGE,'') as BOXCHARGE,isnull(VAT_INC,'0') as VAT_INC,ISNULL(LOCALGROSSAMT,gross_rate) as LOCALGROSSAMT, ISNULL(LOCALBILLAMT,bill_amt) AS LOCALBILLAMT,
isnull(sectioncode,'') as SECTIONCODE,isnull(RESOURCE_NO,'') as RESOURCE_NO,ISNULL(CAPTION,'') as CAPTION
  from tbl_booking_insert where comp_code=@compcode and cio_booking_id=@ciobid order by Insert_Id


select col_Name ,col_Code from col_mast where comp_code=@compcode
select premiumname,Premiumcode from ADVPOS_PREM_MAST where comp_code=@compcode
select Adv_Subcat_Name,Adv_Subcat_Code from adv_subcat_mast
select uom_name,uom_code from uom_mast where comp_code=@compcode
select adv_type_name,adv_type_code from adv_type_mast where comp_code=@compcode
select adv_cat_name,adv_cat_code from ADV_CAT_MAST where comp_code=@compcode
select pos_type_code,pos_type from advpos_type_mast where comp_code=@compcode


select   Paid_permission    from Module_DetaiButtonl  where comp_code=@compcode and Form_Name='Booking_master'





@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
@caption_inserts_p as varchar(500)
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

select @receiptno_m=Receipt_no  from tbl_booking_mast_g where cio_booking_id=@cioid --and rownum<=1;
print(@receiptno_m)
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


insert into tbl_booking_insert_g(cio_booking_id,Edition,Insert_date,Col_code,Height,Width,Size_book,Page_post,Premium1,Prem_per1,Premium2,Prem_per2,Premium_allow,Ad_cat,Ad_sub_cat,Latest_by,Status_material,File_name,Card_rate,Disc_rate,Insert_status,Bill_status,comp_code,Userid,Repeating_date,no_insert,Edition_code,Publication_code,Pub_cent_code,Supp_code,Pai_free_ins,Agreed_rate,Solo_rate,Gross_rate,Page_no,Remarks,Page_prem,page_per,No_ofcolumn,Bill_Amt,Bill_rate,Logo_H,Logo_W,Logo_name,AD_SUBCAT3,AD_SUBCAT4,AD_SUBCAT5,PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE,RESOURCE_NO,CAPTION)
values(@cioid,@edition,@insertdate,@colid,@height,@width,@totalsize,@pagepost,@premium1,@premper1,@premium2,@premper2,@premallow,@adcategory,@adsubcat,@latestdate,@material,@matfilename,@cardrate,@discrate,@insertstatus,@billstatus,@compcode,@userid,@repeat,@insertno,@edi,@publi,@pub_cent,@supp,@paid,@agrrate,@solorate,@grossrate,@insert_pageno,@insert_remarks,@page_code,@page_per,@noofcol,@billamt,@billrate,@logo_h,@logo_w,@logo_name,@ad_cat_3,@ad_cat_4,@ad_cat_5, @pkgcode,@gridins,@pkgalias,@splboldsizevalue,@vatrate_p,@boxcharge_p,@vat_inc_p,@grossamtlocal_p,@billamtlocal_p,@sectioncode_p,@resourceno_p,@caption_inserts_p)

set @insertidval=@@identity
exec insert_edition_details @subedidata,@receiptno_m,@cioid,@insertidval,@compcode,@edition,@insertdate,@height,@width,@totalsize,@insertstatus,@pkgcode ,@insertno

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

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER PROCEDURE [dbo].[committransaction]
	@pcioid          as  varchar(50),
	@totalcount      as  int,
	@pcompcode       as  varchar(20),
	@pcentname       as  varchar(20),
	@puserid         as  varchar(20),
	@pbkid_gentype   as  varchar(20),
	@pbk_type		 as  varchar(20)
AS
declare @countnum int
declare @billpay varchar(20)
declare @rostatus varchar(10)
declare @remarks varchar(500)
declare @clientname varchar(200)

declare @v_cursor1_var1  varchar(50)
declare @v_cursor1_var2  varchar(50)
declare @newid			 varchar(50)	

BEGIN
select @countnum=count(*) from tbl_booking_insert_g where Cio_Booking_Id=@pcioid
if @countnum=@totalcount begin

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
create table #recpt_t(receipt_no varchar(130))
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
			REVISE_DATE,CLIENT_TYPE)
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
			REVISE_DATE,CLIENT_TYPE
			 FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=@pcioid

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
           , LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION)
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
           , LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO,CAPTION
            FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=@pcioid

INSERT INTO TBL_BOOKING_VTS(COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE) 
SELECT COMPCODE, @newid CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE FROM TBL_BOOKING_VTS_G WHERE  cioid=@pcioid


insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO)
select COMP_CODE, @newid CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO, SRNO from tbl_booking_subedition_g
where tbl_booking_subedition_g.CIOID=@pcioid;


insert into TBL_BOOKING_SHARING_TRANS(PUBLICATION, TYPE, SHARING, CIOID, SRNO)
select PUBLICATION, TYPE, SHARING, @newid CIOID, SRNO from TBL_BOOKING_SHARING_TRANS_g where CIOID=@pcioid

insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID, CREATIONDATETIME)
select @newid CIOID, INSERTID, CREATIONDATETIME from TBL_BOOKING_FMG_TRANS_G where CIOID=@pcioid

 select @billpay=Bill_pay,@rostatus=ro_status  from tbl_booking_mast where cio_booking_id=@newid
PRINT @rostatus
if (@billpay = 'CA0' or @billpay = 'CH0') and @rostatus='1' begin
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
	
	select @book_doctype=doctype,@book_client=client_code,@book_prev_cioid=prev_cioid,@book_Agency_code=Agency_code,@book_retainer=RETAINER,@book_exec=Executive_code,@book_Agency_sub_code=Agency_sub_code,@book_billpay=Bill_pay,@book_userid=userid,@book_datetime=date_time,@book_gross=Gross_amount,@book_billamt=Bill_amount,@prev_cioid=prev_cioid,@book_rec=receipt_no,@book_compcode=comp_code,@book_branch=branch,@book_agencycode=Agency_sub_code from tbl_booking_mast where cio_booking_id=@newid

	select @branchcode=Branch_Code  from branch_mst where Comp_Code=@book_compcode and Branch_Name=@book_branch

	select @subagencyreg=SUB_Agency_Code  from agency_mast where Comp_Code=@book_compcode and code_subcode=@book_agencycode
	set @vrecpt		=@book_rec
	set @prevcioid_v=@prev_cioid

	if @prevcioid_v is null or @prevcioid_v='' begin
			set @billamt_v	=@book_billamt
			set @grossamt_v	=@book_gross
			set @v_curdate	=@book_datetime
	end
	else begin
			select @billamt_v=Bill_amount,@grossamt_v=Gross_amount from tbl_booking_mast where cio_booking_id=@prevcioid_v
			set @billamt_v	=@book_billamt - @billamt_v
			 set @grossamt_v=@book_gross - @grossamt_v
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

	insert into #recpt_t 
	 exec receiptsave_booking @book_compcode,@book_userid, @book_branch,@book_doctype,@vrecpt,@v_curdate,@book_billpay,'','',@billamt_v,@book_Agency_sub_code,@grossamt_v,
	  '','','',@remarks,@vrepcode,@book_datetime,@book_Agency_code,@subagencyreg,'',@newid,@book_exec,@book_retainer,@book_prev_cioid
	
	select @v_rcptno_r=receipt_no from   #recpt_t
	
	update tbl_booking_mast set Receipt_no=@v_rcptno_r where cio_booking_id=@newid
	
	drop table #recpt_t
	end

end
select @newid as "CIO_ID"
END




@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@6421@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//=======================================kuldeep 21/01/12===============================//
ALTER PROCEDURE [dbo].[getpageamount]
@compcode as varchar(8),
@pagecode as varchar(8),
@bookingdate as varchar(28)


AS
select Amount,Premium from advpos_type_mast where pos_type_code=@pagecode 
and comp_code=@compcode and @bookingdate between FROM_DATE and "TO_DATE"
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER PROCEDURE [dbo].[rate_bindgrid]
@compcode as varchar(8),
@packagecode as varchar(8),
@dateformat as varchar(12)


AS

if(@dateformat='mm/dd/yyyy')
begin

select combin_desc,Week_Day_Rate,Focus_Day_Rate,weekend_rate,"Week_Extra_Rate",(select Adv_Cat_Name from adv_cat_mast where  adv_cat_mast.Adv_cat_code=rate_mast.Adv_cat_code) as Catname,
(select Adv_type_name from Adv_type_mast where Adv_type_mast.Adv_type_code=rate_mast.Adv_type_code and comp_code=@compcode) as type,
(select Uom_name from uom_mast where uom_code=rate_mast.uom) as uom,
(select curr_name from curr_mast where curr_code=rate_mast.Currency) as currency,
(select adv_subcat_name from adv_subcat_mast where adv_subcat_mast.adv_subcat_code=rate_mast.Adv_subcat_code) as subcat,
convert(varchar,Valid_From,101) as Valid_From ,convert(varchar,Valid_To,101) as Valid_To,
(select col_name from col_mast where rate_mast.Color=col_code) as color,(select premiumname from ADVPOS_PREM_MAST where Premiumcode=Premium and comp_code=@compcode) as premium
from rate_mast where Combin_Code=@packagecode and Comp_code=@compcode order by Valid_From,color,Catname

end

if(@dateformat='dd/mm/yyyy')
begin

select combin_desc,Week_Day_Rate,Focus_Day_Rate,weekend_rate,"Week_Extra_Rate",(select Adv_Cat_Name from adv_cat_mast where  adv_cat_mast.Adv_cat_code=rate_mast.Adv_cat_code) as Catname,
(select Adv_type_name from Adv_type_mast where Adv_type_mast.Adv_type_code=rate_mast.Adv_type_code and comp_code=@compcode) as type,
(select Uom_name from uom_mast where uom_code=rate_mast.uom) as uom,
(select curr_name from curr_mast where curr_code=rate_mast.Currency) as currency,
(select adv_subcat_name from adv_subcat_mast where adv_subcat_mast.adv_subcat_code=rate_mast.Adv_subcat_code) as subcat,
convert(varchar,Valid_From,103) as Valid_From ,convert(varchar,Valid_To,103) as Valid_To,
(select col_name from col_mast where rate_mast.Color=col_code) as color,(select premiumname from ADVPOS_PREM_MAST where Premiumcode=Premium and comp_code=@compcode) as premium
from rate_mast where Combin_Code=@packagecode and Comp_code=@compcode order by Valid_From,color,Catname


end


if(@dateformat='yyyy/mm/dd')
begin

select combin_desc,Week_Day_Rate,Focus_Day_Rate,weekend_rate,"Week_Extra_Rate",(select Adv_Cat_Name from adv_cat_mast where  adv_cat_mast.Adv_cat_code=rate_mast.Adv_cat_code) as Catname,
(select Adv_type_name from Adv_type_mast where Adv_type_mast.Adv_type_code=rate_mast.Adv_type_code and comp_code=@compcode) as type,
(select Uom_name from uom_mast where uom_code=rate_mast.uom) as uom,
(select curr_name from curr_mast where curr_code=rate_mast.Currency) as currency,
(select adv_subcat_name from adv_subcat_mast where adv_subcat_mast.adv_subcat_code=rate_mast.Adv_subcat_code) as subcat,
convert(varchar,Valid_From,111) as Valid_From ,convert(varchar,Valid_To,111) as Valid_To,
(select col_name from col_mast where rate_mast.Color=col_code) as color,(select premiumname from ADVPOS_PREM_MAST where Premiumcode=Premium and comp_code=@compcode) as premium
from rate_mast where Combin_Code=@packagecode and Comp_code=@compcode order by Valid_From,color,Catname

end


//=======================================Start Procedure===============================//

ALTER PROCEDURE [dbo].[committransaction]
	@pcioid          as  varchar(50),
	@totalcount      as  int,
	@pcompcode       as  varchar(20),
	@pcentname       as  varchar(20),
	@puserid         as  varchar(20),
	@pbkid_gentype   as  varchar(20),
	@pbk_type		 as  varchar(20)
AS
declare @countnum int
declare @billpay varchar(20)
declare @rostatus varchar(10)
declare @remarks varchar(500)
declare @clientname varchar(200)

declare @v_cursor1_var1  varchar(50)
declare @v_cursor1_var2  varchar(50)
declare @newid			 varchar(50)	

BEGIN
select @countnum=count(*) from tbl_booking_insert_g where Cio_Booking_Id=@pcioid
if @countnum=@totalcount begin

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
create table #recpt_t(receipt_no varchar(130))
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
			REVISE_DATE,CLIENT_TYPE)
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
			REVISE_DATE,CLIENT_TYPE
			 FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=@pcioid

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
           , LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION)
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
           , LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO,CAPTION
            FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=@pcioid

INSERT INTO TBL_BOOKING_VTS(COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE) 
SELECT COMPCODE, @newid CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE FROM TBL_BOOKING_VTS_G WHERE  cioid=@pcioid


insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO)
select COMP_CODE, @newid CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO, SRNO from tbl_booking_subedition_g
where tbl_booking_subedition_g.CIOID=@pcioid;


insert into TBL_BOOKING_SHARING_TRANS(PUBLICATION, TYPE, SHARING, CIOID, SRNO)
select PUBLICATION, TYPE, SHARING, @newid CIOID, SRNO from TBL_BOOKING_SHARING_TRANS_g where CIOID=@pcioid

insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID, CREATIONDATETIME)
select @newid CIOID, INSERTID, CREATIONDATETIME from TBL_BOOKING_FMG_TRANS_G where CIOID=@pcioid

 update tbl_matter set cioid=@newid where "cioid"=@pcioid 
 
 select @billpay=Bill_pay,@rostatus=ro_status  from tbl_booking_mast where cio_booking_id=@newid
PRINT @rostatus
if (@billpay = 'CA0' or @billpay = 'CH0') and @rostatus='1' begin
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
	
	select @book_doctype=doctype,@book_client=client_code,@book_prev_cioid=prev_cioid,@book_Agency_code=Agency_code,@book_retainer=RETAINER,@book_exec=Executive_code,@book_Agency_sub_code=Agency_sub_code,@book_billpay=Bill_pay,@book_userid=userid,@book_datetime=date_time,@book_gross=Gross_amount,@book_billamt=Bill_amount,@prev_cioid=prev_cioid,@book_rec=receipt_no,@book_compcode=comp_code,@book_branch=branch,@book_agencycode=Agency_sub_code from tbl_booking_mast where cio_booking_id=@newid

	select @branchcode=Branch_Code  from branch_mst where Comp_Code=@book_compcode and Branch_Name=@book_branch

	select @subagencyreg=SUB_Agency_Code  from agency_mast where Comp_Code=@book_compcode and code_subcode=@book_agencycode
	set @vrecpt		=@book_rec
	set @prevcioid_v=@prev_cioid

	if @prevcioid_v is null or @prevcioid_v='' begin
			set @billamt_v	=@book_billamt
			set @grossamt_v	=@book_gross
			set @v_curdate	=@book_datetime
	end
	else begin
			select @billamt_v=Bill_amount,@grossamt_v=Gross_amount from tbl_booking_mast where cio_booking_id=@prevcioid_v
			set @billamt_v	=@book_billamt - @billamt_v
			 set @grossamt_v=@book_gross - @grossamt_v
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

	insert into #recpt_t 
	 exec receiptsave_booking @book_compcode,@book_userid, @book_branch,@book_doctype,@vrecpt,@v_curdate,@book_billpay,'','',@billamt_v,@book_Agency_sub_code,@grossamt_v,
	  '','','',@remarks,@vrepcode,@book_datetime,@book_Agency_code,@subagencyreg,'',@newid,@book_exec,@book_retainer,@book_prev_cioid
	
	select @v_rcptno_r=receipt_no from   #recpt_t
	
	update tbl_booking_mast set Receipt_no=@v_rcptno_r where cio_booking_id=@newid
	
	drop table #recpt_t
	end

end
select @newid as "CIO_ID"
END




//=======================================================================================//

//=======================================Start Procedure===============================//
ALTER PROCEDURE [dbo].[getpageamount]
@compcode as varchar(8),
@pagecode as varchar(8),
@bookingdate as varchar(28)


AS
select Amount,Premium from advpos_type_mast where pos_type_code=@pagecode 
and comp_code=@compcode and @bookingdate between FROM_DATE and "TO_DATE"
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER PROCEDURE [dbo].[rate_bindgrid]
@compcode as varchar(8),
@packagecode as varchar(8),
@dateformat as varchar(12)


AS

if(@dateformat='mm/dd/yyyy')
begin

select combin_desc,Week_Day_Rate,Focus_Day_Rate,weekend_rate,"Week_Extra_Rate",(select Adv_Cat_Name from adv_cat_mast where  adv_cat_mast.Adv_cat_code=rate_mast.Adv_cat_code) as Catname,
(select Adv_type_name from Adv_type_mast where Adv_type_mast.Adv_type_code=rate_mast.Adv_type_code and comp_code=@compcode) as type,
(select Uom_name from uom_mast where uom_code=rate_mast.uom) as uom,
(select curr_name from curr_mast where curr_code=rate_mast.Currency) as currency,
(select adv_subcat_name from adv_subcat_mast where adv_subcat_mast.adv_subcat_code=rate_mast.Adv_subcat_code) as subcat,
convert(varchar,Valid_From,101) as Valid_From ,convert(varchar,Valid_To,101) as Valid_To,
(select col_name from col_mast where rate_mast.Color=col_code) as color,(select premiumname from ADVPOS_PREM_MAST where Premiumcode=Premium and comp_code=@compcode) as premium
from rate_mast where Combin_Code=@packagecode and Comp_code=@compcode order by Valid_From,color,Catname

end

if(@dateformat='dd/mm/yyyy')
begin

select combin_desc,Week_Day_Rate,Focus_Day_Rate,weekend_rate,"Week_Extra_Rate",(select Adv_Cat_Name from adv_cat_mast where  adv_cat_mast.Adv_cat_code=rate_mast.Adv_cat_code) as Catname,
(select Adv_type_name from Adv_type_mast where Adv_type_mast.Adv_type_code=rate_mast.Adv_type_code and comp_code=@compcode) as type,
(select Uom_name from uom_mast where uom_code=rate_mast.uom) as uom,
(select curr_name from curr_mast where curr_code=rate_mast.Currency) as currency,
(select adv_subcat_name from adv_subcat_mast where adv_subcat_mast.adv_subcat_code=rate_mast.Adv_subcat_code) as subcat,
convert(varchar,Valid_From,103) as Valid_From ,convert(varchar,Valid_To,103) as Valid_To,
(select col_name from col_mast where rate_mast.Color=col_code) as color,(select premiumname from ADVPOS_PREM_MAST where Premiumcode=Premium and comp_code=@compcode) as premium
from rate_mast where Combin_Code=@packagecode and Comp_code=@compcode order by Valid_From,color,Catname


end


if(@dateformat='yyyy/mm/dd')
begin

select combin_desc,Week_Day_Rate,Focus_Day_Rate,weekend_rate,"Week_Extra_Rate",(select Adv_Cat_Name from adv_cat_mast where  adv_cat_mast.Adv_cat_code=rate_mast.Adv_cat_code) as Catname,
(select Adv_type_name from Adv_type_mast where Adv_type_mast.Adv_type_code=rate_mast.Adv_type_code and comp_code=@compcode) as type,
(select Uom_name from uom_mast where uom_code=rate_mast.uom) as uom,
(select curr_name from curr_mast where curr_code=rate_mast.Currency) as currency,
(select adv_subcat_name from adv_subcat_mast where adv_subcat_mast.adv_subcat_code=rate_mast.Adv_subcat_code) as subcat,
convert(varchar,Valid_From,111) as Valid_From ,convert(varchar,Valid_To,111) as Valid_To,
(select col_name from col_mast where rate_mast.Color=col_code) as color,(select premiumname from ADVPOS_PREM_MAST where Premiumcode=Premium and comp_code=@compcode) as premium
from rate_mast where Combin_Code=@packagecode and Comp_code=@compcode order by Valid_From,color,Catname

end
//=======================================================================================//
//=======================================kuldeep 21/01/12===============================//


//====================ankit===================payment mode ===============================//

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[paymantinsert]

@paycode as varchar(8),
@payname as varchar(20),
@compcode as varchar(8),
@userid  as varchar(8),
@alias as varchar(8),
@CASH AS VARCHAR(1)

AS





begin

insert into payment_mode_mast([Comp_Code]
           ,[Pay_Mode_Code]
           ,[Payment_Mode_Name]
           ,[Userid]
           ,[Creation_Datetime]
           ,[PAYMENT_MODE_ALIAS],CASHDISCOUNT) values(  @compcode, @paycode, @payname, @userid, getdate(),@alias,@CASH )

end







set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[paymentexe]

@compcode as varchar(8),
@paycode as varchar(8),
@payname as varchar(20),

@userid  as varchar(8)


AS
declare @query varchar(1000)
/*create table #Payment_Mode_Mast (
	Comp_Code varchar (8)  ,
	Pay_Mode_Code varchar (8)  ,
	Payment_Mode_Name varchar (20),
	Userid varchar (8) 
             ---Creation_Datetime 
	
) 
*/
begin

--set @query= ' insert  into   #Payment_Mode_Mast  select Comp_Code, Pay_Mode_Code,Payment_Mode_Name,Userid  from   payment_mode_mast where Comp_Code='''+@compcode+'''  '--and userid='''+@userid+'''   '
set @query= 'select Comp_Code, Pay_Mode_Code,Payment_Mode_Name,Userid,PAYMENT_MODE_ALIAS,CASHDISCOUNT AS CASH  from   payment_mode_mast where Comp_Code='''+@compcode+'''  '

end

if(  @paycode <> '')
begin
set @query = @query + '  and   Pay_Mode_Code like ''%'+@paycode+'%''  '    
end


if(  @payname <> '' )
begin
set @query = @query + '  and   Payment_Mode_Name like ''%'+@payname+'%''  '    
end

print(@query)
exec(@query)

--select * from #Payment_Mode_Mast 
--drop table #Payment_Mode_Mast



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[paymantmodify]

@paycode as varchar(8),
@payname as varchar(20),
@compcode as varchar(8),
@userid  as varchar(8),
@alias as varchar(8),
@CASH AS VARCHAR(1)
AS

begin

update payment_mode_mast set Payment_Mode_Name=@payname,PAYMENT_MODE_ALIAS=@alias,CASHDISCOUNT=@CASH where comp_code=@compcode /*and userid=@userid*/ and Pay_Mode_Code=@paycode

--update paymodedummy set Paymant_Mode_Name=@payname where comp_code=@compcode and userid=@userid and Pay_Mode_Code=@paycode

end

//====================ankit===================payment mode ===============================//


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@LAXMAN SIR @@@@@@@@23/01/12@@@@@@@@@@@@@@@@@@@@@@@@@

                                                                     
                                                                     
                                                                     
                                             
alter FUNCTION FETCH_PACK_new(
	@PCOMP_CD	as	VARCHAR(200),
	@v_pack		as	varchar(2000)) 

RETURNS VARCHAR(2000) as
BEGIN

declare @v_vals          varchar(2000)
declare @NumSegments     numeric(5)
declare @CurrentSegment  numeric(5)
declare @SegmentVal      VARCHAR(500)
declare @vtxt            varchar(8000)
declare @Delim           varchar(1)
set @Delim	=','

declare @v_pack_name     varchar(8000)

set @NumSegments     = (len(@v_pack) - len(replace(@v_pack, @Delim, ''))) + 1
set @CurrentSegment  = 1
set @vtxt            = @v_pack

WHILE (@CurrentSegment < @NumSegments) Begin
    
    set @SegmentVal  = LEFT(@vtxt, CHARINDEX(@Delim, @vtxt)-1)
    set @vtxt        = SUBSTRING(@vtxt, CHARINDEX(@Delim, @vtxt)+1, LEN(@vtxt))
	
    select @v_vals = "Combin_Desc" from combin_mast where "Combin_Code"=ltrim(@SegmentVal)
    
    if @v_pack_name is null or @v_pack_name='' Begin
        set @v_pack_name=@v_vals
    End    
    else Begin
        set @v_pack_name=@v_pack_name+','+@v_vals
    end

    set @CurrentSegment= @CurrentSegment + 1
END

    select @v_vals = "Combin_Desc" from combin_mast where "Combin_Code"=ltrim(@vtxt)
    
    if @v_pack_name is null or @v_pack_name='' Begin
        set @v_pack_name=isnull(@v_vals,@vtxt)
    End    
    else Begin
        set @v_pack_name=@v_pack_name+','+@v_vals
    end
    return isnull(@v_pack_name,@v_pack)
END



//==============******************6306***Start Scripting****************==================//

ALTER PROCEDURE [dbo].[getpageamount]
@compcode as varchar(8),
@pagecode as varchar(8)
--@bookingdate as varchar(28)


AS
select Amount,Premium from advpos_type_mast where pos_type_code=@pagecode 
and comp_code=@compcode --and @bookingdate between FROM_DATE and "TO_DATE"

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE  PROCEDURE WEBSP_GETPAGEPOSITION_DATEWISE
(
@compcode       varchar(50),
@bookingdate     varchar(50)
)
AS
BEGIN
         SELECT "Pos_Type_Code", "Pos_Type" FROM advpos_type_mast
          WHERE Comp_Code = @compcode and @bookingdate between FROM_DATE and TO_DATE order by Pos_Type


END

//==================================***6306*********End*********************==================//


////////**************************************ISSUE NO.0006384 ***********************************//////////////////////


                                                                     
                                                                     
                                                                     
                                             
ALTER PROCEDURE Schedulereport1(
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
	@packagecode 			varchar(50),
	@editiondtl 			varchar(50),
	@puserid				varchar(50),
	@chk_access				varchar(2),
	@p_branch				varchar(50)) 
	
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
		 AND (i.Insert_Status  != @drpstatus OR	@drpstatus is null)
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
				isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS "Client", 
				#multipack_rep.PACK  AS "Package", COL_MAST.Col_Alias AS "Hue", TBL_BOOKING_MAST.Card_rate AS "CardRate",
				isnull(Agrred_rate,TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", TBL_BOOKING_MAST.Caption as "Caption", 
				TBL_BOOKING_MAST.Key_no as "Key_no", TBL_BOOKING_INSERT.Edition as "edition", TBL_BOOKING_MAST.RO_No as "RO_No",
				(SELECT ADVPOS_PREM_MAST.Premiumcode FROM ADVPOS_PREM_MAST WHERE TBL_BOOKING_INSERT.Premium1=ADVPOS_PREM_MAST.Premiumcode AND TBL_BOOKING_INSERT.Col_Code= ADVPOS_PREM_MAST.col_code) AS PagePremium,
				(SELECT ADVPOS_TYPE_MAST.Pos_Type_Code FROM ADVPOS_TYPE_MAST WHERE TBL_BOOKING_INSERT.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code) AS "PosPremium", 
				round(TBL_BOOKING_insert.Size_Book,2)  AS "Area", TBL_BOOKING_MAST.Bill_remarks AS "Spl Instruction", 
				CASE ''' + @dateformat + '''  WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),Insert_Date,101)  
				WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),Insert_Date,103)  
				WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),Insert_Date,112)  END AS "Ins.date" ,
				tbl_booking_insert.Width  AS "Width",  tbl_booking_insert.Height AS "Depth",
				(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=tbl_booking_insert.Ad_Cat) as "Adcat", 
				(select ADV_SUBCAT_MAST.Adv_Subcat_Name FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST.Adv_Subcat_Code=tbl_booking_insert.Ad_Sub_Cat) AS "AdSubcat", 
				(select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3",
				TBL_BOOKING_INSERT.Page_No as "Pageno", TBL_BOOKING_MAST.Paid_ins as "Paidins",  
				TBL_BOOKING_MAST.Rate_code as ratecd, UOM_MAST.Uom_Name  AS "Uom",
				(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast.Uom_code=uom_mast.Uom_Code)as "uomdesc" 
				,TBL_BOOKING_MAST.Booking_type AS "booktype"   ,tbl_booking_mast.audit as "audit"	
				,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT",
				(select distinct "Branch_Name" from branch_mst where "Branch_Code"=TBL_BOOKING_MAST."branch") as "BRANCH_NAME"
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
				isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS "Client", 
				#multipack_rep.PACK  AS "Package", COL_MAST.Col_Alias AS "Hue", TBL_BOOKING_MAST.Card_rate AS "CardRate",
				isnull(Agrred_rate,TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", TBL_BOOKING_MAST.Caption as "Caption", 
				TBL_BOOKING_MAST.Key_no as "Key_no", TBL_BOOKING_INSERT.Edition as "edition", TBL_BOOKING_MAST.RO_No as "RO_No",
				(SELECT ADVPOS_PREM_MAST.Premiumcode FROM ADVPOS_PREM_MAST WHERE TBL_BOOKING_INSERT.Premium1=ADVPOS_PREM_MAST.Premiumcode AND TBL_BOOKING_INSERT.Col_Code= ADVPOS_PREM_MAST.col_code) AS PagePremium,
				(SELECT ADVPOS_TYPE_MAST.Pos_Type_Code FROM ADVPOS_TYPE_MAST WHERE TBL_BOOKING_INSERT.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code) AS "PosPremium", 
				round(TBL_BOOKING_insert.Size_Book,2)  AS "Area", TBL_BOOKING_MAST.Bill_remarks AS "Spl Instruction", 
				CASE ''' + @dateformat + '''  WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),Insert_Date,101)  
				WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),Insert_Date,103)  
				WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),Insert_Date,112)  END AS "Ins.date" ,
				tbl_booking_insert.Width  AS "Width",  tbl_booking_insert.Height AS "Depth",
				(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=tbl_booking_insert.Ad_Cat) as "Adcat", 
				(select ADV_SUBCAT_MAST.Adv_Subcat_Name FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST.Adv_Subcat_Code=tbl_booking_insert.Ad_Sub_Cat) AS "AdSubcat",
				(select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3",
				TBL_BOOKING_INSERT.Page_No as "Pageno", TBL_BOOKING_MAST.Paid_ins as "Paidins",  
				TBL_BOOKING_MAST.Rate_code as ratecd, UOM_MAST.Uom_Name  AS "Uom",
				(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast.Uom_code=uom_mast.Uom_Code)as "uomdesc" 
				,TBL_BOOKING_MAST.Booking_type AS "booktype"   ,tbl_booking_mast.audit as "audit"	
				,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT",
				(select distinct "Branch_Name" from branch_mst where "Branch_Code"=TBL_BOOKING_MAST."branch") as "BRANCH_NAME"
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
				isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS "Client", 
				#multipack_rep.PACK  AS "Package", COL_MAST.Col_Alias AS "Hue", TBL_BOOKING_MAST.Card_rate AS "CardRate",
				isnull(TBL_BOOKING_MAST.Agrred_rate, TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", TBL_BOOKING_MAST.Caption as "Caption", 
				TBL_BOOKING_MAST.Key_no as "Key_no", TBL_BOOKING_MAST.RO_No as "RO_No",
				(SELECT ADVPOS_PREM_MAST.Premiumcode FROM ADVPOS_PREM_MAST WHERE TBL_BOOKING_INSERT.Premium1=ADVPOS_PREM_MAST.Premiumcode AND TBL_BOOKING_INSERT.Col_Code= ADVPOS_PREM_MAST.col_code) AS PagePremium,
				(SELECT ADVPOS_TYPE_MAST.Pos_Type_Code FROM ADVPOS_TYPE_MAST WHERE TBL_BOOKING_INSERT.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code) AS "PosPremium", 
				round(TBL_BOOKING_insert.Size_Book,2)  AS "Area", TBL_BOOKING_MAST.Bill_remarks AS "Spl Instruction", 
				CASE ''' + @dateformat + '''  WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),Insert_Date,101)  
				WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),Insert_Date,103)  
				WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),Insert_Date,112) 
				END AS "Ins.date" ,
				tbl_booking_insert.Width  AS "Width",
				tbl_booking_insert.Height AS "Depth",
				(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=tbl_booking_insert.Ad_Cat) as "Adcat", 
				(select ADV_SUBCAT_MAST.Adv_Subcat_Name FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST.Adv_Subcat_Code=tbl_booking_insert.Ad_Sub_Cat) AS "AdSubcat",
				(select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3", 
				TBL_BOOKING_INSERT.Page_No as "Pageno", TBL_BOOKING_MAST.Paid_ins as "Paidins",  
				TBL_BOOKING_MAST.Rate_code as ratecd, UOM_MAST.Uom_Name  AS "Uom"
				,(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code")as "uomdesc"
				,TBL_BOOKING_MAST.Booking_type AS "booktype"   ,tbl_booking_mast.audit as "audit"	
				,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT",
				(select distinct "Branch_Name" from branch_mst where "Branch_Code"=TBL_BOOKING_MAST."branch") as "BRANCH_NAME"
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
				isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS "Client", 
				#multipack_rep.PACK  AS "Package", COL_MAST.Col_Alias AS "Hue", TBL_BOOKING_MAST.Card_rate AS "CardRate",
				isnull(TBL_BOOKING_MAST.Agrred_rate, TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", TBL_BOOKING_MAST.Caption as "Caption", 
				TBL_BOOKING_MAST.Key_no as "Key_no", TBL_BOOKING_MAST.RO_No as "RO_No",
				(SELECT ADVPOS_PREM_MAST.Premiumcode FROM ADVPOS_PREM_MAST WHERE TBL_BOOKING_INSERT.Premium1=ADVPOS_PREM_MAST.Premiumcode AND TBL_BOOKING_INSERT.Col_Code= ADVPOS_PREM_MAST.col_code) AS PagePremium,
				(SELECT ADVPOS_TYPE_MAST.Pos_Type_Code FROM ADVPOS_TYPE_MAST WHERE TBL_BOOKING_INSERT.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code) AS "PosPremium", 
				round(TBL_BOOKING_insert.Size_Book,2)  AS "Area", TBL_BOOKING_MAST.Bill_remarks AS "Spl Instruction", 
				CASE ''' + @dateformat + '''  WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),Insert_Date,101)  
				WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),Insert_Date,103)  
				WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),Insert_Date,112) 
				END AS "Ins.date" ,
				tbl_booking_insert.Width  AS "Width",
				tbl_booking_insert.Height AS "Depth",
				(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=tbl_booking_insert.Ad_Cat) as "Adcat", 
				(select ADV_SUBCAT_MAST.Adv_Subcat_Name FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST.Adv_Subcat_Code=tbl_booking_insert.Ad_Sub_Cat) AS "AdSubcat", 
				(select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3",
				TBL_BOOKING_INSERT.Page_No as "Pageno", TBL_BOOKING_MAST.Paid_ins as "Paidins",  
				TBL_BOOKING_MAST.Rate_code as ratecd, UOM_MAST.Uom_Name  AS "Uom"
				,(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code")as "uomdesc"
				,TBL_BOOKING_MAST.Booking_type AS "booktype"   ,tbl_booking_mast.audit as "audit"	
				,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT",
				(select distinct "Branch_Name" from branch_mst where "Branch_Code"=TBL_BOOKING_MAST."branch") as "BRANCH_NAME"
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




////////************************************** END OF ISSUE NO.0006384 ***********************************//////////////////////



////////************************************** 6339 *****************ankit******************//////////////////////


set ANSI_NULLS OFF
set QUOTED_IDENTIFIER OFF
GO
ALTER PROCEDURE  [dbo].[chkcurrcode]
@code as varchar(10),
@compcode as varchar(10),
@userid as varchar(10)


 AS
declare @query as varchar(900)
declare @query1 as varchar(900)

set @query='select Curr_Code from  CURR_MAST where comp_code='''+@compcode+'''  and Curr_Code='''+@code+''''

set @query1='select  Curr_Code from CURR_CONV_DET where comp_code='''+@compcode+'''  and Curr_Code='''+@code+''''

print(@query)
exec(@query)

print(@query1)
exec(@query1)




set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[chkcurrencycodename]

@str as varchar(30),
@country as varchar(8),
@cod as varchar(2)

as

declare @query as  varchar(1000)

declare @query1 as  varchar(1000)
set @query='select * from CURR_MAST where  Country_Code='''+@country+'''   and Curr_Name= '''+@str+''''




--set @query1='select max(Curr_Code) as Curr_Code from CURR_MAST where Curr_Code like '''+@cod+'%'''
set @query1='select MAX(cast(dbo.translate(Curr_Code,''ABCDEFGHIJKLMNOPQRSTUVWXYZ@#$%^&*()!><?/_+|=-'',0) as int )) as Curr_Code from CURR_MAST where  Curr_Code like '''+@cod+'%'''


--print(@query)

print(@query)
exec(@query)

--print(@query)

print(@query1)
exec(@query1)





////////************************************** 6339 *****************ankit******************//////////////////////


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@6455@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


                                                                     
                                                                     
                                                                     
                                             
ALTER  function FUN_BILL_INSERT ( @comp_cod varchar(20), @cio_id varchar(100),@bil_no varchar(100),@prefer varchar(10),@dateformate varchar(20),@f_agmain varchar(100),@f_agsub varchar(100),@f_agcode varchar(100),@f_agname varchar(200),@f_execcode varchar(100),@f_execname varchar(200),@f_retcode varchar(100),@f_retname varchar(200),@base varchar(10)) --RETURNs float(6) as

RETURNS @temp_ad_bills_report TABLE      
(
  CIOID             varchar(50),
  BILLNO            varchar(25),
  AGENCY            varchar(50),
  CLIENT            varchar(200),
  RONO              varchar(40),
  RODATE            DATEtime,
  EXECUTIVE         varchar(50),
  RETAINER          varchar(80),
  BOOKTYPE          varchar(50),
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
  PAGE_NO			int

)


begin

declare @FCIOID  varchar(50)
declare @FBillno  varchar(25)
declare @FAgency  varchar(50)
declare @FClient  varchar(200)
declare @FRoNo  varchar(40)
declare @FRoDate  datetime
declare @FExecutive  varchar(50)
declare @FRetainer  varchar(80)
declare @FBookType  varchar(50)
declare @FColor  varchar(20)
declare @FAdcat  varchar(50)
declare @FAdsubcat  varchar(50)
declare @FAdsubcat3  varchar(50)
declare @FAdsubcat4  varchar(50)
declare @FAdsubcat5  varchar(50)
declare @FPackag  varchar(500)
declare @FBillDate  datetime
declare @Fnoinsert  int
declare @FPaidinsert  int
declare @Fheight  int
declare @Fwidth  int
declare @FArea  int
declare @FPagepremium  varchar(30)
declare @FPostprem  varchar(30)
declare @Fscheme  varchar(50)
declare @FRatecod  varchar(40)
declare @Fcardrate  float
declare @Fcardamt  float
declare @Fcontractrate  int
declare @FDeviationamt  int
declare @FDeviationper  int
declare @FAggrate  int
declare @Faggamt  int
declare @FDiscAmt  float
declare @FDiscper  int
declare @Fposamt  int
declare @Fposper  int
declare @FSpdiscamt  int
declare @FSpdiscper  int
declare @FSpacedisc  int
declare @FSpacediscper  int
declare @FSpecialcharge  int
declare @FAgencyAddlTDper  varchar(8)
declare @FAgencyAddlTDAmt  int
declare @FGrossamt  int
declare @FRetTDPer   int
declare @FRetTDAmt  int
declare @FAgencyTDPer  int
declare @FAgencyTDAmt  int
declare @FBillamt  int
declare @FRetCommPer  int
declare @FRetCommAmt   int
declare @FActualBusiness  int
declare @FRevcenter   varchar(50)
declare @FUom  varchar(20)
declare @FUomDesc  varchar(50)
declare @FCOMP_CODE  varchar(10)
declare @Fpadtype  varchar(20)
declare @FPRIPUB  varchar(10)
declare @FPEDITION  varchar(50)
declare @FBranch_Name  varchar(50)
declare @FPub_cent_Code  varchar(50)
declare @Fregion  varchar(12)
declare @FAgency_Type_Code  varchar(10)
declare @FPRIADCTG  varchar(40)
declare @FSECADCTG  varchar(40)
declare @FAD_SUBCAT3  varchar(15)
declare @FAD_SUBCAT4  varchar(15)
declare @FAD_SUBCAT5  varchar(15)
declare @FPACKAGE_CODE  varchar(500)
declare @FAG_MAIN_CODE  varchar(10)
declare @FAG_SUB_CODE  varchar(10)
declare @FCLIENTCD  varchar(200)
declare @FEXECUTIVE_NAME  varchar(100)
declare @FPRIPROCTG  varchar(10)
declare @Fbrand_code  varchar(10)
declare @FVarient_Name  varchar(25)
declare @FPAGE_PREM  varchar(10)
declare @FPAGE_POST  varchar(10)
declare @FCONTRACT_NAME  varchar(50)
declare @FSUPP_CODE  varchar(50)
declare @FRETAINER_CODE  varchar(10)
declare @FRATECD  varchar(40)
declare @FCity_Code  varchar(10)
declare @Fzone_code  varchar(10)
declare @FDist_Code  varchar(10)
declare @FState_Code  varchar(10)
declare @FPTALUKA  varchar(10)
declare @FPSCHEME  varchar(18)
declare @FREVENUE_CENTER  varchar(10)
declare @FRO_STATUS  varchar(10)
declare @FPAGE_TYPE  varchar(100)
declare @FBOOKING_TYPE  varchar(10)
declare @FPUB_CENT_PERMIT varchar(50)
declare @FfAdcat varchar(50)
declare @FfAdsubcat varchar(50)
declare @FfAdsubcat3 varchar(50)
declare @FfAdsubcat4 varchar(50)
declare @FfAdsubcat5 varchar(50)
declare @FfPagepremium varchar(50)
declare @Ffscheme varchar(50)
declare @f_bil_amt int
declare @FfAgencyAddlTDAmt int
declare @FfUom varchar(50)
declare @FfBranch_Name varchar(50)
declare @FfClient varchar(100)
declare @FfColor varchar(20)
declare @FfPub_cent_Code varchar(30)
declare @FffPub_cent_Code varchar(30)
declare @FffBranch_Name varchar(50)
declare @ffPRIPROCTG varchar(30)
declare @Fag_dist_code varchar(50)
declare @Fag_talu_code varchar(50)
declare @Fdist_name varchar(50)
declare @Ftalu_name varchar(50)
declare @FPub_cent_Name varchar(50)

declare @Fag_city_code varchar(50) 
declare @Fag_zone_code varchar(50) 
declare @Fag_state_code varchar(50) 
declare @Fcity_name varchar(30)
declare @Fzone_name varchar(30)
declare @Fstate_name varchar(30)
declare @f_exec_city varchar(8)
declare @f_city_zone varchar(8)
declare @f_page_no varchar(8)



/****************************  For Ad_bills  *******************************/
SELECT @FCIOID=max(ad_bills.IDNUM),
@FBillno=max(AD_BILLS.BILNO),@FRoNo=max(ad_bills.RONUM),@FRoDate=MAX(ad_bills.RODATE),
@FBookType=max(case AD_BILLS.BOOKING_TYPE  
when '1' then 'Barter' 
when '2' then 'FMG' 
when '3' then 'Normal' 
when '4' then 'InHouse' 
when '5' then 'Complimentary' 
else 'Normal' end),
@FPackag=max(dbo.FETCH_PACK(ad_bills.idnum)), --PACKAGE
@FBillDate=MAX(ad_bills.BILDT),@Fcontractrate=max(ad_bills.CONTRACT_RATE),
@Fposamt=max(dbo.FETCH_RATAMT(ad_bills.idnum,'1','2')),   --posamt
@Fposper=max(dbo.FETCH_RATAMT(ad_bills.idnum,'2','2')) ,  --POSPER
@FGrossamt=max(ad_bills.GROSS_AMT),@FBillamt=max(ad_bills.BILLAMT) ,@FAgencyTDPer=max(isnull(ad_bills.DISCOUNT ,0 )),
@FAgencyTDAmt=max((isnull(ad_bills.GROSS_AMT,0)* isnull(ad_bills.DISCOUNT,0 )/100 ))   ,@FCOMP_CODE=MAX(COMP_CODE_V)
,@FfClient=max(ad_bills.CLIENTCD),@FfColor=max(COLOUR),
@FfPagepremium=max(SCHEME),@FAgencyAddlTDAmt=sum(isnull(ad_bills.GROSS_AMT,0)),@f_bil_amt=sum(BILLAMT),@FfPub_cent_Code=max(UNIT),
@FfBranch_Name=max(ad_bills.UNIT),@FPRIPUB=max(ad_bills.PRIPUB) ,@FAG_MAIN_CODE=max(ad_bills.AG_MAIN_CODE),@FAG_SUB_CODE=MAX(AD_BILLS.AG_SUB_CODE),
@FCLIENTCD=max(ad_bills.CLIENTCD),@FEXECUTIVE_NAME=max( ad_bills.EXECUTIVE_NAME),@FPRIPROCTG=max(ad_bills.PRIPROCTG),
@FCONTRACT_NAME=max(ad_bills.CONTRACT_NAME),@FRETAINER_CODE=max(ad_bills.RETAINER_CODE),@FPSCHEME=max(ad_bills.SCHEME),@FREVENUE_CENTER=max(AD_BILLS.REVENUE_CENTER)
,@FRO_STATUS=max(AD_BILLS.RO_STATUS),@FPAGE_TYPE=max(AD_BILLS.PAGE_TYPE),@FBOOKING_TYPE=max(AD_BILLS.BOOKING_TYPE ),
@ffPRIPROCTG=max(PRIPROCTG),@f_page_no=max(PAGENUM)
FROM AD_BILLS WHERE ad_bills.IDNUM=@cio_id AND ad_bills.BILNO=@bil_no  and ad_bills.COMP_CODE_V=@comp_cod 
/**************************************  For Ad_bills_det  ***********************************/
select @FfAdcat=max(PRIADCTG),@FfAdsubcat=max(SECADCTG),@FfAdsubcat3=max(AD_SUBCAT3),@FfAdsubcat4=max(AD_SUBCAT4),@FfAdsubcat5=max(AD_SUBCAT5) ,
@FfPagepremium=max(PAGE_PREM),@Fheight=max(ad_bills_det.HEIGHT),@Fwidth=max(ad_bills_det.WIDTH),@FArea=max(ad_bills_det.SIZE_BOOK),@FRatecod=max(ad_bills_det.RATECD)
,@Fcardrate=sum(ad_bills_det.CARD_RATE_V),@FPEDITION=max(ad_bills_det.EDITION),@Fpadtype=max(ad_bills_det.AD_TYPE_V),@FPRIADCTG=max(ad_bills_det.PRIADCTG) ,
@FSECADCTG=max(ad_bills_det.SECADCTG),@FAD_SUBCAT3=max(ad_bills_det.AD_SUBCAT3),
@FAD_SUBCAT4=max(ad_bills_det.AD_SUBCAT4),@FAD_SUBCAT5=max(ad_bills_det.AD_SUBCAT5),@FPACKAGE_CODE=max(ad_bills_det.PACKAGE_CODE),@FPAGE_PREM=max(ad_bills_det.PAGE_PREM),
@FPAGE_POST=max(ad_bills_det.PAGE_POST),@FSUPP_CODE=max(ad_bills_det.SUPP_CODE),@FRATECD=max(ad_bills_det.RATECD),@FPUB_CENT_PERMIT=MAX(ad_bills_det.BKFOR)

from ad_bills_det where bilno=@bil_no;
/**************************  For Tbl_booking_mast  *********************************************/
select @FRetCommPer=max(isnull(dbo.fun_actual(@comp_cod,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_mast.Gross_amount,0),@prefer,1 ),0)),-- RetComm(%)
@FRetCommAmt=max(isnull(dbo.fun_actual(@comp_cod,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_mast.Gross_amount,0),@prefer,2 ),0)),--RetCommAmt
@FRetTDPer=max(isnull(dbo.fun_actual(@comp_cod,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_mast.Gross_amount,0),@prefer,3 ),0)),--RetTD(%)
@FRetTDAmt=max(isnull(dbo.fun_actual(@comp_cod,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_mast.Gross_amount,0),@prefer,4 ),0)),--RetTDAmt
@FActualBusiness=max(isnull((@f_bil_amt-isnull(dbo.fun_actual(@comp_cod,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_mast.Gross_amount,0),@prefer,2 ),0)  ),0))--ActualBusiness
,@Fnoinsert=max(tbl_booking_mast.No_of_insertion),@FPaidinsert=max(tbl_booking_mast.Paid_ins),
@FDeviationamt=max(tbl_booking_mast.Deviation),@FDeviationper=max(tbl_booking_mast.Deviation) ,@FAggrate=max(tbl_booking_mast.Agrred_rate),@Faggamt=max(tbl_booking_mast.Agreed_amount),
@FDiscper=max(tbl_booking_mast.Discount_per) ,@FSpdiscper=max(tbl_booking_mast.Special_disc_per),@FSpacediscper=max(tbl_booking_mast.Space_disc_per),
@FSpecialcharge=max(tbl_booking_mast.Special_charges),@FAgencyAddlTDper=max(isnull(tbl_booking_mast.ADD_AGENCY_COMM,0)),
@FAgencyAddlTDAmt=max(isnull((@FfAgencyAddlTDAmt*isnull(tbl_booking_mast.ADD_AGENCY_COMM,0)/100),0))
,@FfUom=max(Uom_code) 
 from tbl_booking_mast where tbl_booking_mast.cio_booking_id=@FCIOID;
--***************************  variables  ***********************************************************
set @Fagency=@f_agname

set @FClient=dbo.AD_GET_CLIENTNAME (@comp_cod,@FfClient)

set @FExecutive=@f_execname
set @FRetainer=@f_retname

set @FAdcat=dbo.AD_GET_catnameE(@comp_cod,@FfAdcat,'cat')
set @FAdsubcat=dbo.AD_GET_catnameE(@comp_cod,@FfAdsubcat,'subcat')
set @FAdsubcat3=dbo.AD_GET_catnameE(@comp_cod,@FfAdsubcat3,'cat3')
set @FAdsubcat4=dbo.AD_GET_catnameE(@comp_cod,@FfAdsubcat4,'cat4')
set @FAdsubcat5=dbo.AD_GET_catnameE(@comp_cod,@FfAdsubcat5,'cat5')
set @FPagepremium=dbo.AD_GET_catnameE(@comp_cod,@FfPagepremium,'pprem')
set @Fscheme=dbo.AD_GET_catnameE(@comp_cod,@Ffscheme,'fschem')
set @FColor=dbo.AD_GET_catnameE(@comp_cod,@FfColor,'fcol')

set @FSpdiscamt= (round((( isnull(@FSpdiscper,0) * isnull(@FArea,0) * isnull(@Fcardrate,0))/100),2))  
set @FSpacedisc= (round(((isnull(@FSpacediscper,0) * isnull(@FArea,0) * isnull(@Fcardrate,0))/100),2))  
set @Fcardamt=(isnull(@Fcardrate,0) * isnull(@FArea,0) * isnull(@Fnoinsert,0))     
select @FDiscAmt=max((isnull(@Fcardrate,0) * isnull(@FArea,0) * isnull(@Fnoinsert,0)) - case isnull(@Faggamt,0) when 0 then (isnull(@Fcardrate,0) * isnull(@FArea,0) * isnull(@Fnoinsert,0))   else isnull(@Faggamt,0) end           )
select @FUom=max(UOM_MAST.Uom_Name),@FUomDesc=max(uom_mast.UOM_DESC)     from uom_mast where Uom_Code =@FfUom;
select @FffPub_cent_Code=pub_center   from BRANCH_MST where Branch_Code=@FfPub_cent_Code;
select @FPub_cent_Code=max(Pub_cent_Code),@FPub_cent_Name=MAX(Pub_Cent_name) /*into ,*/ from PUB_CENT_MAST where Pub_cent_Code=@FffPub_cent_Code;
select @FBranch_Name=max(branch_mst.Branch_Name)   from branch_mst where branch_mst.Branch_Code= @FfBranch_Name;
select @Fregion=max(agency_mast.region),@FAgency_Type_Code=max(agency_mast.Agency_Type_Code) /*into ,*/ from agency_mast where AGENCY_MAST.code_subcode=@f_agcode; 
select @Fbrand_code=max(brand_mst.brand_code)   from brand_mst where brand_mst.prod_cat_code=@ffPRIPROCTG;
select @FVarient_Name=max(varient_mst.Varient_Name)   from varient_mst where varient_mst.Brand_Code=@Fbrand_code;
--**********************************************************************************************************************
 
select @f_exec_city=max(exec_mast.city_code)   from exec_mast where Exe_no=@f_execcode;
select @f_city_zone=max(city_mst.Zone_Code)   from city_mst where city_mst.City_Code=@f_exec_city
  
if(@base='1') begin
     select @Fag_dist_code=max(Agency_mast.Dist_Code),@Fag_talu_code=max(AGENCY_MAST.TALUKA) ,@Fag_city_code=max(AGENCY_MAST.City_Code),
@Fag_zone_code=max(AGENCY_MAST.zone_code),@Fag_state_code=max(AGENCY_MAST.State_Code)
     from agency_mast where code_subcode=@f_agcode 
     end
 else if(@base='2') begin
      select @Fag_dist_code=max(exec_mast.dist_code),@Fag_talu_code=max(exec_mast.TALUKA) ,@Fag_city_code=max(exec_mast.city_code),
@Fag_zone_code=@f_city_zone,@Fag_state_code=max(exec_mast.State_code)
      from exec_mast where Exe_no=@f_execcode 
end
      
 else
begin
       select @Fag_dist_code=max(RETAINERMASTER.Dist_Code),@Fag_talu_code=max(RETAINERMASTER.TALUKA) ,@Fag_city_code=max(RETAINERMASTER.City_Code),
@Fag_zone_code=max(RETAINERMASTER.Zone_Code),@Fag_state_code=max(RETAINERMASTER.State_Code)
       from RETAINERMASTER where Retain_Code =@f_retcode;
       
  end 

select @Fdist_name=max(dist_mst.Dist_Name)   from dist_mst where Dist_Name=@Fag_dist_code

select @Ftalu_name=max(taluka_mast.TALU_NAME)   from taluka_mast where TALU_CODE=@Fag_talu_code

select @Fcity_name=max(city_mst.City_Name)    from city_mst where City_Code=@Fag_city_code

select @Fzone_name=max(zone_mast.Zone_Name)   from zone_mast where  Zone_Code=@Fag_zone_code

select @Fstate_name=max(state_mst.State_Name)   from state_mst where  State_Code=@Fag_state_code

insert into @temp_ad_bills_report
(
CIOID,Billno,Agency,Client,RoNo,RoDate,Executive,Retainer,BookType,Color,Adcat,Adsubcat,Adsubcat3,Adsubcat4,Adsubcat5,Packag,BillDate,
noinsert,Paidinsert,height,width,Area,Pagepremium,Postprem,scheme,Ratecod,cardrate,cardamt,contractrate,Deviationamt,Deviationper,
Aggrate,aggamt,DiscAmt,Discper,posamt,posper,Spdiscamt,Spdiscper,Spacedisc,Spacediscper,Specialcharge,AgencyAddlTDper,AgencyAddlTDAmt,
Grossamt,RetTDPer,RetTDAmt,AgencyTDPer,AgencyTDAmt,Billamt,RetCommPer,RetCommAmt,ActualBusiness,Revcenter,Uom,UomDesc,
    PADTYPE ,  PRIPUB,  PEDITION,  BRANCH_NAME ,  PUB_CENT_CODE ,  REGION,  AGENCY_TYPE_CODE,  PRIADCTG,  SECADCTG,  AD_SUBCAT3,  AD_SUBCAT4,
  AD_SUBCAT5,  PACKAGE_CODE,  AG_MAIN_CODE,   CLIENTCD,  EXECUTIVE_NAME,  PRIPROCTG ,  BRAND_CODE,  VARIENT_NAME,  PAGE_PREM ,  PAGE_POST ,
  CONTRACT_NAME ,  SUPP_CODE ,  RETAINER_CODE ,  RATECD,    PSCHEME ,  REVENUE_CENTER,  RO_STATUS ,  PAGE_TYPE ,  BOOKING_TYPE,COMP_CODE,AG_SUB_CODE,
  PUB_CENT_PERMIT,DIST_NAME,TALU_NAME,PUB_CENT_NAME,
  CITY_CODE,ZONE_CODE,DIST_CODE,STATE_CODE,PTALUKA,CITY_NAME,ZONE_NAME,STATE_NAME,PAGE_NO
)
values
(
@FCIOID  ,@FBillno  ,@FAgency  ,@FClient  ,@FRoNo  ,@FRoDate  ,@FExecutive  ,@FRetainer  ,@FBookType  ,@FColor  ,@FAdcat  ,
@FAdsubcat  ,@FAdsubcat3  ,@FAdsubcat4  ,@FAdsubcat5  ,@FPackag  ,@FBillDate  ,@Fnoinsert  ,@FPaidinsert  ,@Fheight  ,@Fwidth  ,
@FArea  ,@FPagepremium  ,@FPostprem  ,@Fscheme  ,@FRatecod  ,@Fcardrate  ,@Fcardamt  ,@Fcontractrate  ,@FDeviationamt  ,
@FDeviationper  ,@FAggrate  ,@Faggamt  ,@FDiscAmt  ,@FDiscper  ,@Fposamt  ,@Fposper  ,@FSpdiscamt  ,@FSpdiscper  ,@FSpacedisc  ,
@FSpacediscper  ,@FSpecialcharge  ,@FAgencyAddlTDper  ,@FAgencyAddlTDAmt  ,@FGrossamt  ,@FRetTDPer   ,@FRetTDAmt  ,
@FAgencyTDPer  ,@FAgencyTDAmt  ,@FBillamt  ,@FRetCommPer  ,@FRetCommAmt   ,@FActualBusiness  ,@FRevcenter   ,@FUom ,
@FUomDesc,@Fpadtype,@FPRIPUB,@FPEDITION,@FBranch_Name,@FPub_cent_Code,@Fregion,@FAgency_Type_Code,@FPRIADCTG,@FSECADCTG,
@FAD_SUBCAT3,@FAD_SUBCAT4,@FAD_SUBCAT5,@FPACKAGE_CODE,@FAG_MAIN_CODE,@FCLIENTCD,@FEXECUTIVE_NAME,@FPRIPROCTG,@Fbrand_code,
@FVarient_Name,@FPAGE_PREM,@FPAGE_POST,@FCONTRACT_NAME,@FSUPP_CODE,@FRETAINER_CODE,@FRATECD,@FPSCHEME,@FREVENUE_CENTER,
@FRO_STATUS,@FPAGE_TYPE,@FBOOKING_TYPE,@FCOMP_CODE,@FAG_SUB_CODE,@FPUB_CENT_PERMIT,@Fdist_name,@Ftalu_name,@FPub_cent_Name,
@Fag_city_code,@Fag_zone_code,@Fag_dist_code,@Fag_state_code,@Fag_talu_code,@Fcity_name,@Fzone_name,@Fstate_name,@f_page_no
)


return 


end


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@6455@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

/**************mimoh*****Issue No. 0006211*********************/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[savecontract_detail]
@dealno_p  varchar(50),
@adtype_p  varchar(20),
@hue_p  varchar(20),
@uom_p  varchar(20),
@package_p  varchar(100),
@category_p  varchar(50),
@premium_p  varchar(50),
@cardprem_p  varchar(50),
@contractprem_p  varchar(50),
@contrate_p  varchar(50),
@cardrate_p  varchar(50),
@deviation_p  varchar(50),
@disctype_p  varchar(50),
@discper_p  varchar(50),
@discon_p  varchar(50),
@minsize_p  varchar(50),
@maxsize_p  varchar(50),
@valuefrom_p  varchar(50),
@valueto_p  varchar(50),
@day_p  varchar(200),
@insertion_p  varchar(50),
@commallow_p  varchar(50),
@dealstart_p  varchar(50),
@currency_p  varchar(50),
@ratecode_p  varchar(50),
@totalrate_p  varchar(50),
@incentive_p  varchar(50),
@remarks_p  varchar(500),
@approved_p  varchar(50),
@compcode_p  varchar(50),
@userid_p  varchar(50),
@id_p  varchar(50),
@positionprem varchar(50),
@contractamount1 varchar(50)
AS
BEGIN
IF @id_p=''
BEGIN
insert into contract_detail(deal_code,ADTYPE,color,Uom,packagecode,Advcategory,premiumcode,cardpremium,dealpremium,Dealarte,cardrate,deviation,discounted,DISCTYPE,DISCPER,SIZEFROM,SIZETO,valuefrom,valueto,DAYNAME,INSERTION,COMMITION_ALLOW,DEAL_START,currency,Rate_code,convertrate,INCENTIVE,REMARKS,approved,creation_datetimetime,comp_code,userid,POSITION_PREM,CONTRACT_AMOUNT)
values(@dealno_p,@adtype_p,@hue_p,@uom_p,@package_p,@category_p,@premium_p,@cardprem_p,@contractprem_p,@contrate_p,@cardrate_p,@deviation_p,@discon_p,@disctype_p,@discper_p,@minsize_p,@maxsize_p,@valuefrom_p,@valueto_p,@day_p,@insertion_p,@commallow_p,@dealstart_p,@currency_p,@ratecode_p,@totalrate_p,@incentive_p,@remarks_p,@approved_p,GETDATE(),@compcode_p,@userid_p,@positionprem,@contractamount1)

END
ELSE
BEGIN
update  contract_detail set ADTYPE=@adtype_p, color=@hue_p,Uom=@uom_p,packagecode=@package_p,Advcategory=@category_p,premiumcode=@premium_p,cardpremium=@cardprem_p,dealpremium=@contractprem_p,Dealarte=@contrate_p,cardrate=@cardrate_p,deviation=@deviation_p,discounted=@discon_p,DISCTYPE=@disctype_p,DISCPER=@discper_p,SIZEFROM=@minsize_p,SIZETO=@maxsize_p,valuefrom=@valuefrom_p,valueto=@valueto_p,DAYNAME=@day_p,INSERTION=@insertion_p,COMMITION_ALLOW=@commallow_p,DEAL_START=@dealstart_p,currency=@currency_p,Rate_code=@ratecode_p,convertrate=@totalrate_p,INCENTIVE=@incentive_p,REMARKS=@remarks_p,approved=@approved_p,POSITION_PREM=@positionprem,CONTRACT_AMOUNT=@contractamount1
where deal_code=@dealno_p and ContractCode=@id_p
END
END


/**********************************/

CREATE PROCEDURE bindadvposition

@p_compcode   varchar(50),
@p_name   varchar(50),
@extra1   varchar(50),
@extra2   varchar(50)


as


SELECT "Pos_Type_Code" as POS_TYPE_CODE,"Pos_Type" as POS_TYPE FROM advpos_type_mast WHERE  "Comp_Code"=@p_compcode      AND
("Pos_Type" LIKE @p_name + '%' OR @p_name IS NULL);


/**************************************************************/


GO
SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[updatecontactmast]

@compcode as varchar(8),
@userid as varchar(8),
@DealNo as varchar(8),
@dealname as varchar(50),
@agencycode as varchar(8),
@subagencycode as varchar(8),
@product as varchar(8),
@validfromdate as datetime,
@validtill as datetime,
@representative as varchar(8),
@clientname as varchar(8),
@totalvalue as float,
@totalvolume as float,
@currencys as varchar(8),
@teamname as varchar(8),
@dealtype as varchar(8),
@adtype as varchar(8),
@remarks as varchar(200),
@executive_var as varchar(20),
@retainer_var as varchar(20),
@contdate_var as datetime,
@closedate_var as datetime,
@servicetax_var as varchar(5),
@caption_var as varchar(500),
@paymode_var as varchar(200),
@b2b_var as varchar(10),
@chkmulti_var as varchar(10),
@chkseq_var as varchar(10),
@seqno_var as varchar(10),
@chkparti_var as varchar(10),
@indus_var as varchar(10),
@induspro_var as varchar(100),
@dealon_var as varchar(20),
@attachment1 as varchar(20),
@dealfrom as varchar(50),
@dealcenter as varchar(50),
@translation as varchar(50)
AS

--insert into contract_mast(Deal_No,Comp_code,Agency_code,Sub_Agency_Code,Client_code,Product_code,From_date,Till_date,representative,Userid)values(@DealNo,@compcode,@agencycode,@subagencycode,@clientname,@product,@validfromdate,@validtill,@representative,@userid)

--update contract_mast set Agency_code=@agencycode,Sub_Agency_Code=@subagencycode,Client_code=@clientname,Product_code=@product,From_date=@validfromdate,Till_date=@validtill,representative=@representative,Total_val=@totalvalue,Total_volu=@totalvolume,curr_code=@currencys,team_code=@teamname,deal_type=@dealtype  where Deal_No=@DealNo and comp_code=@compcode and userid=@userid

update contract_mast set deal_name=@dealname,Agency_code=@agencycode,Sub_Agency_Code=@subagencycode,Client_code=@clientname,Product_code=@product,From_date=@validfromdate,Till_date=@validtill,representative=@representative,Total_val=@totalvalue,Total_volu=@totalvolume,curr_code=@currencys,team_code=@teamname,deal_type=@dealtype,Ad_type=@adtype,
REMARKS=@remarks,EXECUTIVE=@executive_var,RETAINER=@retainer_var,CONTRACTDATE=@contdate_var, CLOSEDATE=@closedate_var,
 SERVICETAX=@servicetax_var,PAYMENTTYPE=@paymode_var,CAPTION=@caption_var,
B2B=@b2b_var, CHKMULTIAD=@chkmulti_var, SEQNO_ALLOW=@chkseq_var, SEQNO=@seqno_var, AFT_PRTCLR_AD=@chkparti_var, INDUSTRY=@indus_var, INDUSTRY_PRODUCT=@induspro_var,
DEALON=@dealon_var,ATTACHMENT=@attachment1, DEAL_FROM=@dealfrom,DEAL_CENTER=@dealcenter,TRANSLATION_CHARGES=@translation
  where Deal_No=@DealNo and comp_code=@compcode



/***************************************************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






ALTER PROCEDURE [dbo].[insertcontactmast]
@compcode as varchar(8),
@userid as varchar(8),
@DealNo as varchar(8),
@dealname as varchar(50),
@agencycode as varchar(8),
@subagencycode as varchar(8),
@product as varchar(8),
@validfromdate as datetime,
@validtill as datetime,
@representative as varchar(8),
@clientname as varchar(8),
@totalvalue as float,
@totalvolume as float,
@currencys as varchar(8),
@teamname as varchar(8),
@dealtype as varchar(8),
@adtype as varchar(8),
@remarks as varchar(200),
@executive_var as varchar(20),
@retainer_var as varchar(20),
@contdate_var as datetime,
@closedate_var as datetime,
@servicetax_var as varchar(5),
@caption_var as varchar(500),
@paymode_var as varchar(200),
@b2b_var as varchar(10),
@chkmulti_var as varchar(10),
@chkseq_var as varchar(10),
@seqno_var as varchar(10),
@chkparti_var as varchar(10),
@indus_var as varchar(10),
@induspro_var as varchar(100),
@dealon_var as varchar(20),
@attachment1 as varchar(20),
@dealfrom as varchar(50),
@dealcenter as varchar(50),
@translation as varchar(50)
AS

insert into contract_mast(Deal_No,Comp_code,Agency_code,Sub_Agency_Code,Client_code,Product_code,From_date,Till_date,representative,Userid,Total_val,Total_volu,curr_code,team_code,deal_type,deal_name,Ad_type,REMARKS,EXECUTIVE,RETAINER,CONTRACTDATE, CLOSEDATE, SERVICETAX,PAYMENTTYPE,CAPTION,B2B, CHKMULTIAD, SEQNO_ALLOW, SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON,ATTACHMENT,DEAL_FROM, DEAL_CENTER, TRANSLATION_CHARGES )
values(@DealNo,@compcode,@agencycode,@subagencycode,@clientname,@product,@validfromdate,@validtill,@representative,@userid,@totalvalue,@totalvolume,@currencys,@teamname,@dealtype,@dealname,@adtype,@remarks,@executive_var,@retainer_var,@contdate_var,@closedate_var,@servicetax_var,@paymode_var,@caption_var,@b2b_var,@chkmulti_var,@chkseq_var,@seqno_var,@chkparti_var,@indus_var,@induspro_var,@dealon_var,@attachment1,@dealfrom,@dealcenter,@translation)




/*******************************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[bindGridDetails_Contract]
	@compcode varchar(50),
	@dealcode varchar(50),
	@seqno_p	varchar(50)	
AS
BEGIN
	select (select  Adv_Type_Name+'('+ Adv_Type_Code +')' from Adv_Type_Mast where Comp_Code=@compcode and Adv_Type_Code=ADTYPE) as ADTYPE,
    (select col_name + '(' + color + ')' from Col_Mast where Comp_Code=@compcode and Col_Code=contract_detail.color) as COLOR,
    (select Uom_Name + '(' + contract_detail.Uom + ')' from Uom_Mast where Comp_Code=@compcode and Uom_Code=contract_detail.Uom) as UOM,
    (select combin_desc + '(' + packagecode + ')' from Combin_Mast where Comp_Code=@compcode and Combin_Code=contract_detail.packagecode) as PACKAGECODE,
    (select Adv_Cat_Name + '(' + Advcategory + ')' from adv_cat_mast where comp_code=@compcode and Adv_Cat_Code=contract_detail.Advcategory) as ADVCATEGORY,
    (select premiumname + '(' + premiumcode + ')' from ADVPOS_PREM_MAST where comp_code=@compcode and Premiumcode=contract_detail.premiumcode) as PREMIUMCODE,
    cardpremium as CARDPREMIUM,dealpremium as DEALPREMIUM,
Dealarte as DEALARTE,cardrate as CARDRATE,
    deviation as DEVIATION,
    CASE  DISCTYPE
    WHEN 1 THEN 'Free(1)'
    WHEN 2 THEN 'Discounted(2)'
    WHEN 3 THEN 'Fixed Rate(3)'
    ELSE DISCTYPE
    END as DISCTYPE,
    isnull(DISCPER,'')  as DISCPER,
    CASE  discounted
    WHEN 1 THEN 'Discount On Bill(1)'
    WHEN 2 THEN 'Discount through Credit Note(2)'
    ELSE discounted
    END as DISCOUNTED,
    isnull(SIZEFROM,'') as SIZEFROM,isnull(SIZETO,'') as SIZETO,
    isnull(valuefrom,'') as VALUEFROM,
	isnull(valueto,'') as VALUETO,
	isnull(DAYNAME,'') as DAYNAME,
	isnull(INSERTION,'') as INSERTION,
    CASE COMMITION_ALLOW
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE COMMITION_ALLOW
    END as COMMITION_ALLOW,
    CASE  DEAL_START
    WHEN 'A' THEN 'After Target Achived(A)'
    WHEN 'B' THEN 'From Begining(B)'
    ELSE DEAL_START
    END as DEAL_START,
    (select Curr_Name + '(' + currency + ')' from Curr_Mast where Comp_Code=@compcode and Curr_Code=currency) as CURRENCY,
   isnull(Rate_code,'') as Rate_code,isnull(convertrate,'') as CONVERTRATE,
	isnull(INCENTIVE,'') as INCENTIVE,isnull(REMARKS,'') as REMARKS,
     CASE approved
    WHEN 'Y' THEN 'Active(Y)'
    WHEN 'N' THEN 'Inactive(N)'
    ELSE approved
    END as APPROVED,ContractCode as CONTRACTCODE,
    (select Pos_Type + '(' + Pos_Type_Code + ')' from advpos_type_mast where Comp_Code=@compcode and Pos_Type_Code=contract_detail.POSITION_PREM) AS POSITION_PREM, CONTRACT_AMOUNT
		from contract_detail where deal_code=@dealcode

if @seqno_p='' OR @seqno_p IS NULL 
BEGIN
 SELECT 
    (SELECT NAME + '('+ cast(TV_DEAL_DET.CHANNEL as varchar(20))+ ')' FROM TV_AD_CHANNEL WHERE COMP_CODE=@compcode AND TV_AD_CHANNEL.CHANNEL=TV_DEAL_DET.CHANNEL)  as CHANNEL,
    (SELECT NAME + '(' + cast(LOCATION_CODE as varchar(20)) + ')' FROM TV_AD_LOCATION WHERE COMP_CODE=@compcode AND LOCCD=LOCATION_CODE) as LOCATION_CODE,
    (SELECT DES + '(' + CAST(AD_TYPE AS VARCHAR(20)) + ')' FROM TV_AD_TYPE WHERE COMP_CODE=@compcode AND TV_AD_TYPE.AD_TYPE=TV_DEAL_DET.AD_TYPE AND TV_AD_TYPE.CHANNEL=TV_DEAL_DET.CHANNEL)  as AD_TYPE,
    CASE  PB_FLG
    WHEN 'P' THEN 'Paid(P)'
    WHEN 'B' THEN 'Bonus(B)'
    ELSE PB_FLG
    END AS PB_FLG,
    (SELECT SHORT_NAME + '(' + CAST(PRG_CODE AS VARCHAR(20)) + ')' FROM TV_AD_PROGRAMME WHERE COMP_CODE=@compcode AND CAST(PRG_ID AS VARCHAR(20))=CAST(PRG_CODE AS VARCHAR(20))) as PRG_CODE,
    (SELECT BTB_DESC + '(' + cast(BTB_CODE as varchar(20)) + ')' FROM TV_BTB_MST WHERE COMP_CODE=@compcode AND TV_BTB_MST.BTB_CODE=TV_DEAL_DET.BTB_CODE and TV_BTB_MST.CHANNEL=TV_DEAL_DET.CHANNEL) as BTB_CODE,
  --  AD_GET_FIELDNAME('COMP_CODE',compcode,'BND_CODE',ROS_CODE,'BND_DESC','TV_BND_MST','BTB_CODE',BTB_CODE)  as ROS_CODE,
    ISNULL(ROS_CODE,'') as ROS_CODE,
    ISNULL(DAYS,'') as DAYS,ISNULL(NO_OF_INS,'') as NO_OF_INS,
    (SELECT top 1 Combin_Desc + '(' + cast(PACKAGE_CODE as varchar(20)) + ')' FROM TV_COMBIN_MAST WHERE Comp_Code=@compcode AND Combin_Code=PACKAGE_CODE) as PACKAGE_CODE, 
    ISNULL(VALUE_FROM,'') as VALUE_FROM, ISNULL(VALUE_TO,'') as VALUE_TO,
     CASE  DISC_TYPE
    WHEN 1 THEN 'Free(1)'
    WHEN 2 THEN 'Discounted(2)'
    WHEN 3 THEN 'Fixed Rate(3)'
    ELSE DISC_TYPE
    END as DISC_TYPE, 
    DISC_VAL as DISC_VAL,
    (SELECT premiumname + '(' + cast(PREM_CODE as varchar(20)) + ')' FROM ADVPOS_PREM_MAST WHERE comp_code=@compcode AND Premiumcode=PREM_CODE) as PREM_CODE,
     CONTRACT_PREM_VALUE as CONTRACT_PREM_VALUE,CONTRACT_RATE as CONTRACT_RATE, 
CARD_RATE as CARD_RATE, 
     DEVIATION_RATE as DEVIATION_RATE,CARD_PREM_VALUE as CARD_PREM_VALUE,
MIN_SIZE as MIN_SIZE, MAX_SIZE as MAX_SIZE,
      (SELECT Curr_Name + '(' + cast(CURRENCY  as varchar(20)) + ')' FROM Curr_Mast WHERE Comp_Code=@compcode AND Curr_Code=CURRENCY) as CURRENCY,
     CASE  DEAL_START
    WHEN 'A' THEN 'After Target Achived(A)'
    WHEN 'B' THEN 'From Begining(B)'
    ELSE DEAL_START
    END as DEAL_START,
    (SELECT NAME + '(' + cast(PRG_TYPE  as varchar(20))+ ')' FROM TV_AD_PROGRAMME_TY WHERE comp_code=@compcode AND PROGRAMME_TY=PRG_TYPE) as PRG_TYPE,
     (SELECT Adv_Cat_Name + '(' + AD_CTG + ')' FROM Adv_Cat_Mast WHERE Comp_Code=@compcode AND Adv_Cat_Code=AD_CTG) as AD_CTG,
      CASE COMM_ALLOW
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE COMM_ALLOW
    END as COMM_ALLOW,
    ISNULL(REMARKS,'') as REMARKS, ISNULL(RATE_CODE,'') as RATE_CODE,
    CASE DISC_ON
     WHEN '1' THEN 'Discount On Bill(1)'
    WHEN '2' THEN 'Discount through Credit Note(2)'
    ELSE DISC_ON
    END AS DISC_ON,
    ISNULL(convert(varchar(10),SPN_ST_DT,103),'') as SPN_ST_DT, ISNULL(convert(varchar(10),SPN_END_DT,103),'') as SPN_END_DT,ISNULL(INCENTIVE,'') as INCENTIVE,
    CASE APPROVED
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE APPROVED
    END as APPROVED, SEQNO,(SELECT Uom_Alias + '(' + cast(RATE_TYPE as varchar(20)) + ')' FROM UOM_MAST WHERE Comp_Code=@compcode AND Uom_Code=RATE_TYPE) as RATE_TYPE,
    (SELECT NAME + '(' + cast(SOURCE as varchar(20)) + ')' FROM TV_SOURCE_TYPE WHERE COMP_CODE=@compcode AND SOURCE_TYPE=SOURCE) as SOURCE,
    ISNULL(TOTALVAL,'') AS TOTALVAL
     FROM tv_deal_det WHERE DEALNO=@dealcode
END
else
BEGIN
 SELECT 
    (SELECT NAME + '('+ cast(TV_DEAL_DET.CHANNEL as varchar(20))+ ')' FROM TV_AD_CHANNEL WHERE COMP_CODE=@compcode AND TV_AD_CHANNEL.CHANNEL=TV_DEAL_DET.CHANNEL)  as CHANNEL,
    (SELECT NAME + '(' + cast(LOCATION_CODE as varchar(20)) + ')' FROM TV_AD_LOCATION WHERE COMP_CODE=@compcode AND LOCCD=LOCATION_CODE) as LOCATION_CODE,
    (SELECT DES + '(' + CAST(AD_TYPE AS VARCHAR(20)) + ')' FROM TV_AD_TYPE WHERE COMP_CODE=@compcode AND TV_AD_TYPE.AD_TYPE=TV_DEAL_DET.AD_TYPE AND TV_AD_TYPE.CHANNEL=TV_DEAL_DET.CHANNEL)  as AD_TYPE,
    CASE  PB_FLG
    WHEN 'P' THEN 'Paid(P)'
    WHEN 'B' THEN 'Bonus(B)'
    ELSE PB_FLG
    END AS PB_FLG,
    (SELECT SHORT_NAME + '(' + CAST(PRG_CODE AS VARCHAR(20)) + ')' FROM TV_AD_PROGRAMME WHERE COMP_CODE=@compcode AND CAST(PRG_ID AS VARCHAR(20))=CAST(PRG_CODE AS VARCHAR(20))) as PRG_CODE,
    (SELECT BTB_DESC + '(' + cast(BTB_CODE as varchar(20)) + ')' FROM TV_BTB_MST WHERE COMP_CODE=@compcode AND TV_BTB_MST.BTB_CODE=TV_DEAL_DET.BTB_CODE and TV_BTB_MST.CHANNEL=TV_DEAL_DET.CHANNEL) as BTB_CODE,
  --  AD_GET_FIELDNAME('COMP_CODE',compcode,'BND_CODE',ROS_CODE,'BND_DESC','TV_BND_MST','BTB_CODE',BTB_CODE)  as ROS_CODE,
    ISNULL(ROS_CODE,'') as ROS_CODE,
    ISNULL(DAYS,'') as DAYS,ISNULL(NO_OF_INS,'') as NO_OF_INS,
    (SELECT top 1 Combin_Desc + '(' + cast(PACKAGE_CODE as varchar(20)) + ')' FROM TV_COMBIN_MAST WHERE Comp_Code=@compcode AND Combin_Code=PACKAGE_CODE) as PACKAGE_CODE, 
    ISNULL(VALUE_FROM,'') as VALUE_FROM, ISNULL(VALUE_TO,'') as VALUE_TO,
     CASE  DISC_TYPE
    WHEN 1 THEN 'Free(1)'
    WHEN 2 THEN 'Discounted(2)'
    WHEN 3 THEN 'Fixed Rate(3)'
    ELSE DISC_TYPE
    END as DISC_TYPE, 
    DISC_VAL as DISC_VAL,
    (SELECT premiumname + '(' + cast(PREM_CODE as varchar(20)) + ')' FROM ADVPOS_PREM_MAST WHERE comp_code=@compcode AND Premiumcode=PREM_CODE) as PREM_CODE,
     CONTRACT_PREM_VALUE as CONTRACT_PREM_VALUE,CONTRACT_RATE as CONTRACT_RATE, 
CARD_RATE as CARD_RATE, 
     DEVIATION_RATE as DEVIATION_RATE,CARD_PREM_VALUE as CARD_PREM_VALUE,
MIN_SIZE as MIN_SIZE, MAX_SIZE as MAX_SIZE,
      (SELECT Curr_Name + '(' + cast(CURRENCY  as varchar(20)) + ')' FROM Curr_Mast WHERE Comp_Code=@compcode AND Curr_Code=CURRENCY) as CURRENCY,
     CASE  DEAL_START
    WHEN 'A' THEN 'After Target Achived(A)'
    WHEN 'B' THEN 'From Begining(B)'
    ELSE DEAL_START
    END as DEAL_START,
    (SELECT NAME + '(' + cast(PRG_TYPE  as varchar(20))+ ')' FROM TV_AD_PROGRAMME_TY WHERE comp_code=@compcode AND PROGRAMME_TY=PRG_TYPE) as PRG_TYPE,
     (SELECT Adv_Cat_Name + '(' + AD_CTG + ')' FROM Adv_Cat_Mast WHERE Comp_Code=@compcode AND Adv_Cat_Code=AD_CTG) as AD_CTG,
      CASE COMM_ALLOW
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE COMM_ALLOW
    END as COMM_ALLOW,
    ISNULL(REMARKS,'') as REMARKS, ISNULL(RATE_CODE,'') as RATE_CODE,
    CASE DISC_ON
     WHEN '1' THEN 'Discount On Bill(1)'
    WHEN '2' THEN 'Discount through Credit Note(2)'
    ELSE DISC_ON
    END AS DISC_ON,
    ISNULL(convert(varchar(10),SPN_ST_DT,103),'') as SPN_ST_DT, ISNULL(convert(varchar(10),SPN_END_DT,103),'') as SPN_END_DT,ISNULL(INCENTIVE,'') as INCENTIVE,
    CASE APPROVED
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE APPROVED
    END as APPROVED, SEQNO,(SELECT Uom_Alias + '(' + cast(RATE_TYPE as varchar(20)) + ')' FROM UOM_MAST WHERE Comp_Code=@compcode AND Uom_Code=RATE_TYPE) as RATE_TYPE,
    (SELECT NAME + '(' + cast(SOURCE as varchar(20)) + ')' FROM TV_SOURCE_TYPE WHERE COMP_CODE=@compcode AND SOURCE_TYPE=SOURCE) as SOURCE,
    ISNULL(TOTALVAL,'') AS TOTALVAL
     FROM tv_deal_det WHERE DEALNO=@dealcode  and SEQNO=@seqno_p
END
END
/*******************************************************/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[bindGridDetails_Contract]
	@compcode varchar(50),
	@dealcode varchar(50),
	@seqno_p	varchar(50)	
AS
BEGIN
	select (select  Adv_Type_Name+'('+ Adv_Type_Code +')' from Adv_Type_Mast where Comp_Code=@compcode and Adv_Type_Code=ADTYPE) as ADTYPE,
    (select col_name + '(' + color + ')' from Col_Mast where Comp_Code=@compcode and Col_Code=contract_detail.color) as COLOR,
    (select Uom_Name + '(' + contract_detail.Uom + ')' from Uom_Mast where Comp_Code=@compcode and Uom_Code=contract_detail.Uom) as UOM,
    (select combin_desc + '(' + packagecode + ')' from Combin_Mast where Comp_Code=@compcode and Combin_Code=contract_detail.packagecode) as PACKAGECODE,
    (select Adv_Cat_Name + '(' + Advcategory + ')' from adv_cat_mast where comp_code=@compcode and Adv_Cat_Code=contract_detail.Advcategory) as ADVCATEGORY,
    (select premiumname + '(' + premiumcode + ')' from ADVPOS_PREM_MAST where comp_code=@compcode and Premiumcode=contract_detail.premiumcode) as PREMIUMCODE,
    cardpremium as CARDPREMIUM,dealpremium as DEALPREMIUM,
Dealarte as DEALARTE,cardrate as CARDRATE,
    deviation as DEVIATION,
    CASE  DISCTYPE
    WHEN 1 THEN 'Free(1)'
    WHEN 2 THEN 'Discounted(2)'
    WHEN 3 THEN 'Fixed Rate(3)'
    ELSE DISCTYPE
    END as DISCTYPE,
    isnull(DISCPER,'')  as DISCPER,
    CASE  discounted
    WHEN 1 THEN 'Discount On Bill(1)'
    WHEN 2 THEN 'Discount through Credit Note(2)'
    ELSE discounted
    END as DISCOUNTED,
    isnull(SIZEFROM,'') as SIZEFROM,isnull(SIZETO,'') as SIZETO,
    isnull(valuefrom,'') as VALUEFROM,
	isnull(valueto,'') as VALUETO,
	isnull(DAYNAME,'') as DAYNAME,
	isnull(INSERTION,'') as INSERTION,
    CASE COMMITION_ALLOW
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE COMMITION_ALLOW
    END as COMMITION_ALLOW,
    CASE  DEAL_START
    WHEN 'A' THEN 'After Target Achived(A)'
    WHEN 'B' THEN 'From Begining(B)'
    ELSE DEAL_START
    END as DEAL_START,
    (select Curr_Name + '(' + currency + ')' from Curr_Mast where Comp_Code=@compcode and Curr_Code=currency) as CURRENCY,
   isnull(Rate_code,'') as Rate_code,isnull(convertrate,'') as CONVERTRATE,
	isnull(INCENTIVE,'') as INCENTIVE,isnull(REMARKS,'') as REMARKS,
     CASE approved
    WHEN 'Y' THEN 'Active(Y)'
    WHEN 'N' THEN 'Inactive(N)'
    ELSE approved
    END as APPROVED,ContractCode as CONTRACTCODE,
    (select Pos_Type + '(' + Pos_Type_Code + ')' from advpos_type_mast where Comp_Code=@compcode and Pos_Type_Code=contract_detail.POSITION_PREM) AS POSITION_PREM, CONTRACT_AMOUNT
		from contract_detail where deal_code=@dealcode

if @seqno_p='' OR @seqno_p IS NULL 
BEGIN
 SELECT 
    (SELECT NAME + '('+ cast(TV_DEAL_DET.CHANNEL as varchar(20))+ ')' FROM TV_AD_CHANNEL WHERE COMP_CODE=@compcode AND TV_AD_CHANNEL.CHANNEL=TV_DEAL_DET.CHANNEL)  as CHANNEL,
    (SELECT NAME + '(' + cast(LOCATION_CODE as varchar(20)) + ')' FROM TV_AD_LOCATION WHERE COMP_CODE=@compcode AND LOCCD=LOCATION_CODE) as LOCATION_CODE,
    (SELECT DES + '(' + CAST(AD_TYPE AS VARCHAR(20)) + ')' FROM TV_AD_TYPE WHERE COMP_CODE=@compcode AND TV_AD_TYPE.AD_TYPE=TV_DEAL_DET.AD_TYPE AND TV_AD_TYPE.CHANNEL=TV_DEAL_DET.CHANNEL)  as AD_TYPE,
    CASE  PB_FLG
    WHEN 'P' THEN 'Paid(P)'
    WHEN 'B' THEN 'Bonus(B)'
    ELSE PB_FLG
    END AS PB_FLG,
    (SELECT SHORT_NAME + '(' + CAST(PRG_CODE AS VARCHAR(20)) + ')' FROM TV_AD_PROGRAMME WHERE COMP_CODE=@compcode AND CAST(PRG_ID AS VARCHAR(20))=CAST(PRG_CODE AS VARCHAR(20))) as PRG_CODE,
    (SELECT BTB_DESC + '(' + cast(BTB_CODE as varchar(20)) + ')' FROM TV_BTB_MST WHERE COMP_CODE=@compcode AND TV_BTB_MST.BTB_CODE=TV_DEAL_DET.BTB_CODE and TV_BTB_MST.CHANNEL=TV_DEAL_DET.CHANNEL) as BTB_CODE,
  --  AD_GET_FIELDNAME('COMP_CODE',compcode,'BND_CODE',ROS_CODE,'BND_DESC','TV_BND_MST','BTB_CODE',BTB_CODE)  as ROS_CODE,
    ISNULL(ROS_CODE,'') as ROS_CODE,
    ISNULL(DAYS,'') as DAYS,ISNULL(NO_OF_INS,'') as NO_OF_INS,
    (SELECT top 1 Combin_Desc + '(' + cast(PACKAGE_CODE as varchar(20)) + ')' FROM TV_COMBIN_MAST WHERE Comp_Code=@compcode AND Combin_Code=PACKAGE_CODE) as PACKAGE_CODE, 
    ISNULL(VALUE_FROM,'') as VALUE_FROM, ISNULL(VALUE_TO,'') as VALUE_TO,
     CASE  DISC_TYPE
    WHEN 1 THEN 'Free(1)'
    WHEN 2 THEN 'Discounted(2)'
    WHEN 3 THEN 'Fixed Rate(3)'
    ELSE DISC_TYPE
    END as DISC_TYPE, 
    DISC_VAL as DISC_VAL,
    (SELECT premiumname + '(' + cast(PREM_CODE as varchar(20)) + ')' FROM ADVPOS_PREM_MAST WHERE comp_code=@compcode AND Premiumcode=PREM_CODE) as PREM_CODE,
     CONTRACT_PREM_VALUE as CONTRACT_PREM_VALUE,CONTRACT_RATE as CONTRACT_RATE, 
CARD_RATE as CARD_RATE, 
     DEVIATION_RATE as DEVIATION_RATE,CARD_PREM_VALUE as CARD_PREM_VALUE,
MIN_SIZE as MIN_SIZE, MAX_SIZE as MAX_SIZE,
      (SELECT Curr_Name + '(' + cast(CURRENCY  as varchar(20)) + ')' FROM Curr_Mast WHERE Comp_Code=@compcode AND Curr_Code=CURRENCY) as CURRENCY,
     CASE  DEAL_START
    WHEN 'A' THEN 'After Target Achived(A)'
    WHEN 'B' THEN 'From Begining(B)'
    ELSE DEAL_START
    END as DEAL_START,
    (SELECT NAME + '(' + cast(PRG_TYPE  as varchar(20))+ ')' FROM TV_AD_PROGRAMME_TY WHERE comp_code=@compcode AND PROGRAMME_TY=PRG_TYPE) as PRG_TYPE,
     (SELECT Adv_Cat_Name + '(' + AD_CTG + ')' FROM Adv_Cat_Mast WHERE Comp_Code=@compcode AND Adv_Cat_Code=AD_CTG) as AD_CTG,
      CASE COMM_ALLOW
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE COMM_ALLOW
    END as COMM_ALLOW,
    ISNULL(REMARKS,'') as REMARKS, ISNULL(RATE_CODE,'') as RATE_CODE,
    CASE DISC_ON
     WHEN '1' THEN 'Discount On Bill(1)'
    WHEN '2' THEN 'Discount through Credit Note(2)'
    ELSE DISC_ON
    END AS DISC_ON,
    ISNULL(convert(varchar(10),SPN_ST_DT,103),'') as SPN_ST_DT, ISNULL(convert(varchar(10),SPN_END_DT,103),'') as SPN_END_DT,ISNULL(INCENTIVE,'') as INCENTIVE,
    CASE APPROVED
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE APPROVED
    END as APPROVED, SEQNO,(SELECT Uom_Alias + '(' + cast(RATE_TYPE as varchar(20)) + ')' FROM UOM_MAST WHERE Comp_Code=@compcode AND Uom_Code=RATE_TYPE) as RATE_TYPE,
    (SELECT NAME + '(' + cast(SOURCE as varchar(20)) + ')' FROM TV_SOURCE_TYPE WHERE COMP_CODE=@compcode AND SOURCE_TYPE=SOURCE) as SOURCE,
    ISNULL(TOTALVAL,'') AS TOTALVAL
     FROM tv_deal_det WHERE DEALNO=@dealcode
END
else
BEGIN
 SELECT 
    (SELECT NAME + '('+ cast(TV_DEAL_DET.CHANNEL as varchar(20))+ ')' FROM TV_AD_CHANNEL WHERE COMP_CODE=@compcode AND TV_AD_CHANNEL.CHANNEL=TV_DEAL_DET.CHANNEL)  as CHANNEL,
    (SELECT NAME + '(' + cast(LOCATION_CODE as varchar(20)) + ')' FROM TV_AD_LOCATION WHERE COMP_CODE=@compcode AND LOCCD=LOCATION_CODE) as LOCATION_CODE,
    (SELECT DES + '(' + CAST(AD_TYPE AS VARCHAR(20)) + ')' FROM TV_AD_TYPE WHERE COMP_CODE=@compcode AND TV_AD_TYPE.AD_TYPE=TV_DEAL_DET.AD_TYPE AND TV_AD_TYPE.CHANNEL=TV_DEAL_DET.CHANNEL)  as AD_TYPE,
    CASE  PB_FLG
    WHEN 'P' THEN 'Paid(P)'
    WHEN 'B' THEN 'Bonus(B)'
    ELSE PB_FLG
    END AS PB_FLG,
    (SELECT SHORT_NAME + '(' + CAST(PRG_CODE AS VARCHAR(20)) + ')' FROM TV_AD_PROGRAMME WHERE COMP_CODE=@compcode AND CAST(PRG_ID AS VARCHAR(20))=CAST(PRG_CODE AS VARCHAR(20))) as PRG_CODE,
    (SELECT BTB_DESC + '(' + cast(BTB_CODE as varchar(20)) + ')' FROM TV_BTB_MST WHERE COMP_CODE=@compcode AND TV_BTB_MST.BTB_CODE=TV_DEAL_DET.BTB_CODE and TV_BTB_MST.CHANNEL=TV_DEAL_DET.CHANNEL) as BTB_CODE,
  --  AD_GET_FIELDNAME('COMP_CODE',compcode,'BND_CODE',ROS_CODE,'BND_DESC','TV_BND_MST','BTB_CODE',BTB_CODE)  as ROS_CODE,
    ISNULL(ROS_CODE,'') as ROS_CODE,
    ISNULL(DAYS,'') as DAYS,ISNULL(NO_OF_INS,'') as NO_OF_INS,
    (SELECT top 1 Combin_Desc + '(' + cast(PACKAGE_CODE as varchar(20)) + ')' FROM TV_COMBIN_MAST WHERE Comp_Code=@compcode AND Combin_Code=PACKAGE_CODE) as PACKAGE_CODE, 
    ISNULL(VALUE_FROM,'') as VALUE_FROM, ISNULL(VALUE_TO,'') as VALUE_TO,
     CASE  DISC_TYPE
    WHEN 1 THEN 'Free(1)'
    WHEN 2 THEN 'Discounted(2)'
    WHEN 3 THEN 'Fixed Rate(3)'
    ELSE DISC_TYPE
    END as DISC_TYPE, 
    DISC_VAL as DISC_VAL,
    (SELECT premiumname + '(' + cast(PREM_CODE as varchar(20)) + ')' FROM ADVPOS_PREM_MAST WHERE comp_code=@compcode AND Premiumcode=PREM_CODE) as PREM_CODE,
     CONTRACT_PREM_VALUE as CONTRACT_PREM_VALUE,CONTRACT_RATE as CONTRACT_RATE, 
CARD_RATE as CARD_RATE, 
     DEVIATION_RATE as DEVIATION_RATE,CARD_PREM_VALUE as CARD_PREM_VALUE,
MIN_SIZE as MIN_SIZE, MAX_SIZE as MAX_SIZE,
      (SELECT Curr_Name + '(' + cast(CURRENCY  as varchar(20)) + ')' FROM Curr_Mast WHERE Comp_Code=@compcode AND Curr_Code=CURRENCY) as CURRENCY,
     CASE  DEAL_START
    WHEN 'A' THEN 'After Target Achived(A)'
    WHEN 'B' THEN 'From Begining(B)'
    ELSE DEAL_START
    END as DEAL_START,
    (SELECT NAME + '(' + cast(PRG_TYPE  as varchar(20))+ ')' FROM TV_AD_PROGRAMME_TY WHERE comp_code=@compcode AND PROGRAMME_TY=PRG_TYPE) as PRG_TYPE,
     (SELECT Adv_Cat_Name + '(' + AD_CTG + ')' FROM Adv_Cat_Mast WHERE Comp_Code=@compcode AND Adv_Cat_Code=AD_CTG) as AD_CTG,
      CASE COMM_ALLOW
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE COMM_ALLOW
    END as COMM_ALLOW,
    ISNULL(REMARKS,'') as REMARKS, ISNULL(RATE_CODE,'') as RATE_CODE,
    CASE DISC_ON
     WHEN '1' THEN 'Discount On Bill(1)'
    WHEN '2' THEN 'Discount through Credit Note(2)'
    ELSE DISC_ON
    END AS DISC_ON,
    ISNULL(convert(varchar(10),SPN_ST_DT,103),'') as SPN_ST_DT, ISNULL(convert(varchar(10),SPN_END_DT,103),'') as SPN_END_DT,ISNULL(INCENTIVE,'') as INCENTIVE,
    CASE APPROVED
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE APPROVED
    END as APPROVED, SEQNO,(SELECT Uom_Alias + '(' + cast(RATE_TYPE as varchar(20)) + ')' FROM UOM_MAST WHERE Comp_Code=@compcode AND Uom_Code=RATE_TYPE) as RATE_TYPE,
    (SELECT NAME + '(' + cast(SOURCE as varchar(20)) + ')' FROM TV_SOURCE_TYPE WHERE COMP_CODE=@compcode AND SOURCE_TYPE=SOURCE) as SOURCE,
    ISNULL(TOTALVAL,'') AS TOTALVAL
     FROM tv_deal_det WHERE DEALNO=@dealcode  and SEQNO=@seqno_p
END
END











/**************mimoh*****Issue No. 0006211*********************/


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@bullet master@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//==============*********************Start Scripting****************==================//
ALTER PROCEDURE  [dbo].[updatebullet]
@bulletcode as varchar(10),
----@advtype as varchar(10),
--@edition as varchar(10),
@bulletdesc as varchar(30),
@bulletcharge as varchar(10),
@bullettext as varchar(10),
@remarks as varchar(200),
----@listboxvalue as varchar(200),
@validatedate as datetime,
@validatetill as datetime,
@compcode as varchar(10),
@userid as varchar(10),
@sumble as nvarchar(50),
@pubcenter as varchar(50),
@font1   as varchar(50),
@adcat   as varchar(50)


 AS
--insert into bullet_mast(comp_code,edition_code,adv_type_code,adv_cat_code,bullet_code,bullet_desc,bullet_charges_type,bullet_charges,validity_from_date,validity_till_date,remarks,userid) values(@compcode,@edition,@advtype,@listboxvalue,@bulletcode,@bulletdesc,@bulletcharge,@bullettext,@validatedate,@validatetill,@remarks,@userid)

----update bullet_mast set edition_code=@edition,adv_type_code=@advtype,adv_cat_code=@listboxvalue,bullet_desc=@bulletdesc,bullet_charges_type=@bulletcharge,bullet_charges=@bullettext,validity_from_date=@validatedate,validity_till_date=@validatetill,remarks=@remarks where comp_code=@compcode and userid=@userid and  bullet_code=@bulletcode


update bullet_mast set bullet_desc=@bulletdesc,bullet_charges_type=@bulletcharge,bullet_charges=@bullettext,validity_from_date=@validatedate,validity_till_date=@validatetill,remarks=@remarks ,Sumble=@sumble,  pub_center=@pubcenter, FONT=@font1,Adv_Cat_Code=@adcat where comp_code=@compcode  and    bullet_code=@bulletcode

--update temp_bullet_mast set edition_code=@edition,adv_type_code=@advtype,adv_cat_code=@listboxvalue,bullet_desc=@bulletdesc,bullet_charges_type=@bulletcharge,bullet_charges=@bullettext,validity_from_date=@validatedate,validity_till_date=@validatetill,remarks=@remarks where comp_code=@compcode and userid=@userid and  bullet_code=@bulletcode
--update temp_bullet_mast set bullet_desc=@bulletdesc,bullet_charges_type=@bulletcharge,bullet_charges=@bullettext,validity_from_date=@validatedate,validity_till_date=@validatetill,remarks=@remarks where comp_code=@compcode and userid=@userid and  bullet_code=@bulletcode
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER PROCEDURE  [dbo].[executebulletbullet]

@bulletcode as varchar(10),
----@advtype as varchar(10),
----@edition as varchar(10),
@bulletdesc as varchar(30),
@bulletcharge as varchar(10),
@bullettext as varchar(10),

----@listboxvalue as varchar(200),

@compcode as varchar(10),
@userid as varchar(10),
@pubcenter as varchar(30),
@dateformat as varchar(30),
@adcat   as varchar(50)
 AS
declare @query varchar(2000)


/*CREATE TABLE #temp_bullet_mast
(
	comp_code varchar(8),
	edition_code varchar(25),
	----adv_type_code varchar(8),
	----adv_cat_code varchar(8),
	bullet_code varchar(10),
	bullet_desc varchar(30),
	bullet_charges_type varchar(25),
	bullet_charges varchar(25),
	validity_from_date datetime,
	validity_till_date datetime,
	Remarks varchar(25),
             
	userid varchar(8),
Sumble nvarchar(50)
)*/

----set @query='insert into #temp_bullet_mast select  comp_code,edition_code,adv_type_code,adv_cat_code,bullet_code,bullet_desc,bullet_charges_type,bullet_charges,validity_from_date,validity_till_date,remarks,userid  from bullet_mast  where comp_code='''+@compcode+''' and userid='''+@userid+''''
if(@dateformat='dd/mm/yyyy')

begin
	set @query='select  comp_code,edition_code,bullet_code,bullet_desc,bullet_charges_type,bullet_charges,convert(varchar,validity_from_date,103)  as validity_from_date,convert(varchar,validity_till_date,103) as validity_till_date,Remarks,userid ,Cration_Datetime,Sumble,pub_center,FONT,Adv_Cat_Code from bullet_mast  where comp_code='''+@compcode+''' '
end
else if(@dateformat='mm/dd/yyyy')
begin
	set @query='select  comp_code,edition_code,bullet_code,bullet_desc,bullet_charges_type,bullet_charges,convert(varchar,validity_from_date,101)  as validity_from_date,convert(varchar,validity_till_date,101) as validity_till_date,Remarks,userid ,Cration_Datetime,Sumble,pub_center,FONT,Adv_Cat_Code from bullet_mast  where comp_code='''+@compcode+''' '
end
else if(@dateformat='yyyy/mm/dd')
begin
	set @query='select  comp_code,edition_code,bullet_code,bullet_desc,bullet_charges_type,bullet_charges,convert(varchar,validity_from_date,111)  as validity_from_date,convert(varchar,validity_till_date,111) as validity_till_date,Remarks,userid ,Cration_Datetime,Sumble,pub_center,FONT,Adv_Cat_Code from bullet_mast  where comp_code='''+@compcode+''' '
end
if(@bulletcode <> '')

begin
set @query=@query + 'and bullet_code  like ''%'+@bulletcode+'%'''
end

/*if(@advtype <> "0")

begin
set @query=@query +'and adv_type_code like '''+@advtype+''''
end

if(@edition <> '')

begin
set @query=@query +'and edition_code like '''+@edition+''''
end*/

if(@bulletdesc <> '')

begin
set @query=@query +'and bullet_desc like ''%'+@bulletdesc+'%'''
end

if(@bulletcharge <> '0')

begin
set @query=@query +'and bullet_charges_type like '''+@bulletcharge+''''
end

if(@adcat <> '' and @adcat <> null)
begin
set @query=@query + 'and Adv_Cat_Code = '''+@adcat+''''
end

if(@pubcenter <> '0')
begin
set @query=@query +'and pub_center like '''+@pubcenter+''''
end

/*
if(@listboxvalue <> '')

begin
set @query=@query +'and adv_cat_code like '''+@listboxvalue+''''
end
*/
print(@query)
exec(@query)


--select  comp_code,bullet_code,bullet_desc,bullet_charges_type,bullet_charges,validity_from_date,validity_till_date,Remarks,userid ,Sumble  from #temp_bullet_mast
--drop table #temp_bullet_mast

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER PROCEDURE  [dbo].[insertbullet]
@bulletcode as varchar(10),
--@advtype as varchar(10),
--@edition as varchar(10),
@bulletdesc as varchar(30),
@bulletcharge as varchar(10),
@bullettext as varchar(10),
@remarks as varchar(200),
--@listboxvalue as varchar(200),
@validatedate as datetime,
@validatetill as datetime,
@compcode as varchar(10),
@userid as varchar(10),
@sumble as nvarchar(50),
@pubcenter as varchar(50),
@font as varchar(50),
@adcat   as varchar(50)


 AS
declare @query as varchar(900)

insert into bullet_mast(comp_code,bullet_code,bullet_desc,bullet_charges_type,bullet_charges,validity_from_date,validity_till_date,remarks,userid,Sumble,Cration_Datetime,pub_center,FONT,Adv_Cat_Code) 
		values(@compcode,@bulletcode,@bulletdesc,@bulletcharge,@bullettext,@validatedate,@validatetill,@remarks,@userid,@sumble,getdate(),@pubcenter,@font,@adcat)

--insert into bullet_mast(comp_code,edition_code,adv_type_code,adv_cat_code,bullet_code,bullet_desc,bullet_charges_type,bullet_charges,validity_from_date,validity_till_date,remarks,userid) values(@compcode,@edition,@advtype,@listboxvalue,@bulletcode,@bulletdesc,@bulletcharge,@bullettext,@validatedate,@validatetill,@remarks,@userid)
--set @query='insert into bullet_mast(comp_code,bullet_code,bullet_desc,bullet_charges_type,bullet_charges,validity_from_date,validity_till_date,remarks,userid) values('''+@compcode+''','''+@bulletcode+''','''+@bulletdesc+''','''+@bulletcharge+''','''+@bullettext+''','''+@validatedate+''','''+@validatetill+''','''+@remarks+''','''+@userid+''')'
--set @query='insert into bullet_mast(comp_code,edition_code,adv_type_code,adv_cat_code,bullet_code,bullet_desc,bullet_charges_type,bullet_charges,validity_from_date,validity_till_date,remarks,userid) values('''+@compcode+''','''+@edition+''','''+@advtype+''','''+@listboxvalue+''','''+@bulletcode+''','''+@bulletdesc+''','''+@bulletcharge+''','''+@bullettext+''','''+@validatedate+''','''+@validatetill+''','''+@remarks+''','''+@userid+''')'
--print(@query)
--exec(@query)
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER TABLE TBL_BOOKING_SUBEDITION
 ADD PAGE_NO  int
 
 ALTER TABLE TBL_BOOKING_SUBEDITION_g
 ADD PAGE_NO  int
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER PROCEDURE [dbo].[committransaction]
	@pcioid          as  varchar(50),
	@totalcount      as  int,
	@pcompcode       as  varchar(20),
	@pcentname       as  varchar(20),
	@puserid         as  varchar(20),
	@pbkid_gentype   as  varchar(20),
	@pbk_type		 as  varchar(20)
AS
declare @countnum int
declare @billpay varchar(20)
declare @rostatus varchar(10)
declare @remarks varchar(500)
declare @clientname varchar(200)

declare @v_cursor1_var1  varchar(50)
declare @v_cursor1_var2  varchar(50)
declare @newid			 varchar(50)	

BEGIN
select @countnum=count(*) from tbl_booking_insert_g where Cio_Booking_Id=@pcioid
if @countnum=@totalcount begin

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
create table #recpt_t(receipt_no varchar(130))
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
			REVISE_DATE,CLIENT_TYPE)
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
			REVISE_DATE,CLIENT_TYPE
			 FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=@pcioid

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
           , LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION)
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
           , LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO,CAPTION
            FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=@pcioid

INSERT INTO TBL_BOOKING_VTS(COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE) 
SELECT COMPCODE, @newid CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE FROM TBL_BOOKING_VTS_G WHERE  cioid=@pcioid


insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO, NO_INSERT,PAGE_NO)
select COMP_CODE, @newid CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO, SRNO, NO_INSERT,PAGE_NO from tbl_booking_subedition_g
where tbl_booking_subedition_g.CIOID=@pcioid;


insert into TBL_BOOKING_SHARING_TRANS(PUBLICATION, TYPE, SHARING, CIOID, SRNO)
select PUBLICATION, TYPE, SHARING, @newid CIOID, SRNO from TBL_BOOKING_SHARING_TRANS_g where CIOID=@pcioid

insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID, CREATIONDATETIME)
select @newid CIOID, INSERTID, CREATIONDATETIME from TBL_BOOKING_FMG_TRANS_G where CIOID=@pcioid

 update tbl_matter set cioid=@newid where "cioid"=@pcioid 
 
 select @billpay=Bill_pay,@rostatus=ro_status  from tbl_booking_mast where cio_booking_id=@newid
PRINT @rostatus
if (@billpay = 'CA0' or @billpay = 'CH0') and @rostatus='1' begin
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
	
	select @book_doctype=doctype,@book_client=client_code,@book_prev_cioid=prev_cioid,@book_Agency_code=Agency_code,@book_retainer=RETAINER,@book_exec=Executive_code,@book_Agency_sub_code=Agency_sub_code,@book_billpay=Bill_pay,@book_userid=userid,@book_datetime=date_time,@book_gross=Gross_amount,@book_billamt=Bill_amount,@prev_cioid=prev_cioid,@book_rec=receipt_no,@book_compcode=comp_code,@book_branch=branch,@book_agencycode=Agency_sub_code from tbl_booking_mast where cio_booking_id=@newid

	select @branchcode=Branch_Code  from branch_mst where Comp_Code=@book_compcode and Branch_Name=@book_branch

	select @subagencyreg=SUB_Agency_Code  from agency_mast where Comp_Code=@book_compcode and code_subcode=@book_agencycode
	set @vrecpt		=@book_rec
	set @prevcioid_v=@prev_cioid

	if @prevcioid_v is null or @prevcioid_v='' begin
			set @billamt_v	=@book_billamt
			set @grossamt_v	=@book_gross
			set @v_curdate	=@book_datetime
	end
	else begin
			select @billamt_v=Bill_amount,@grossamt_v=Gross_amount from tbl_booking_mast where cio_booking_id=@prevcioid_v
			set @billamt_v	=@book_billamt - @billamt_v
			 set @grossamt_v=@book_gross - @grossamt_v
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

	insert into #recpt_t 
	 exec receiptsave_booking @book_compcode,@book_userid, @book_branch,@book_doctype,@vrecpt,@v_curdate,@book_billpay,'','',@billamt_v,@book_Agency_sub_code,@grossamt_v,
	  '','','',@remarks,@vrepcode,@book_datetime,@book_Agency_code,@subagencyreg,'',@newid,@book_exec,@book_retainer,@book_prev_cioid
	
	select @v_rcptno_r=receipt_no from   #recpt_t
	
	update tbl_booking_mast set Receipt_no=@v_rcptno_r where cio_booking_id=@newid
	
	drop table #recpt_t
	end

end
select @newid as "CIO_ID"
END




@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
@caption_inserts_p as varchar(500)
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

select @receiptno_m=Receipt_no  from tbl_booking_mast_g where cio_booking_id=@cioid --and rownum<=1;
print(@receiptno_m)
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


insert into tbl_booking_insert_g(cio_booking_id,Edition,Insert_date,Col_code,Height,Width,Size_book,Page_post,Premium1,Prem_per1,Premium2,Prem_per2,Premium_allow,Ad_cat,Ad_sub_cat,Latest_by,Status_material,File_name,Card_rate,Disc_rate,Insert_status,Bill_status,comp_code,Userid,Repeating_date,no_insert,Edition_code,Publication_code,Pub_cent_code,Supp_code,Pai_free_ins,Agreed_rate,Solo_rate,Gross_rate,Page_no,Remarks,Page_prem,page_per,No_ofcolumn,Bill_Amt,Bill_rate,Logo_H,Logo_W,Logo_name,AD_SUBCAT3,AD_SUBCAT4,AD_SUBCAT5,PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE,RESOURCE_NO,CAPTION)
values(@cioid,@edition,@insertdate,@colid,@height,@width,@totalsize,@pagepost,@premium1,@premper1,@premium2,@premper2,@premallow,@adcategory,@adsubcat,@latestdate,@material,@matfilename,@cardrate,@discrate,@insertstatus,@billstatus,@compcode,@userid,@repeat,@insertno,@edi,@publi,@pub_cent,@supp,@paid,@agrrate,@solorate,@grossrate,@insert_pageno,@insert_remarks,@page_code,@page_per,@noofcol,@billamt,@billrate,@logo_h,@logo_w,@logo_name,@ad_cat_3,@ad_cat_4,@ad_cat_5, @pkgcode,@gridins,@pkgalias,@splboldsizevalue,@vatrate_p,@boxcharge_p,@vat_inc_p,@grossamtlocal_p,@billamtlocal_p,@sectioncode_p,@resourceno_p,@caption_inserts_p)

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



@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER  PROCEDURE [dbo].[insert_edition_details]
(
@p_str as varchar(1000),
@receiptnom as varchar(50),
@cioidm as varchar(50),
@insertidm as varchar(50),
@compcodem as varchar(20),
@editioncodem as varchar(20),
@insertdatem as datetime,
@heightm as varchar(10),
@widthm as varchar(10),
@totaream varchar(10),
@insstatusm varchar(10),
@pkgcode varchar(50),
@insertno as int,
@pageno as int
--@p_error_text out varchar2

) 

As
declare @tmpVar as NUMERIC;
declare @tmpStr as VARCHAR(4000)
declare @l_str as VARCHAR(4000)
declare @l_ed as varchar(50)
declare @l_date as varchar(20)
declare @l_hight as varchar(20)
declare @l_width as varchar(20)
declare @l_size as varchar(20)
declare @l_pageno as varchar(20)
declare @l_status as varchar(20)
declare @pubcode as varchar(10)
declare @editioncode as varchar(50)
--declare @sr_no int 
declare @spli_str as varchar(100)
declare @combinname as varchar(3000)
if (@p_str <> null or @p_str <> '')
begin
 
    set @tmpStr= @p_str
   -- set @l_str = @p_str
  
    create table #tempsplitstr(param_str varchar(500))
    insert into #tempsplitstr select edition_name from dbo.fn_SplitField(@p_str,'$')
    
    declare c1 cursor for select param_str from #tempsplitstr 
    OPEN c1
    FETCH next from c1 INTO @spli_str
    WHILE @@fetch_status=0
    begin
          set @l_str = @spli_str
		 --@l_str='HH-LUC-CITY~19/03/2011~15.00~15~225~cancel'
		  set @l_ed =  substring(@l_str,1,CHARINDEX('~',@l_str)-1)
		  set @l_str = substring(@l_str,CHARINDEX('~',@l_str)+1,len(@l_str))
		  set @l_date = convert(varchar(10),substring(@l_str,1,CHARINDEX('~',@l_str)-1),101)
		  set @l_str = substring(@l_str,CHARINDEX('~',@l_str)+1,len(@l_str))
		  set @l_hight = substring(@l_str,1,CHARINDEX('~',@l_str)-1)
		  set @l_str =   substring(@l_str,CHARINDEX('~',@l_str)+1,len(@l_str))
		  set @l_width = substring(@l_str,1,CHARINDEX('~',@l_str)-1)
		  set @l_str = substring(@l_str,CHARINDEX('~',@l_str)+1,len(@l_str))
		  set @l_size=substring(@l_str,1,CHARINDEX('~',@l_str)-1)  
		  set @l_str = substring(@l_str,CHARINDEX('~',@l_str)+1,len(@l_str)) 
		  set @l_pageno=substring(@l_str,1,CHARINDEX('~',@l_str)-1)  
		  set @l_str = substring(@l_str,CHARINDEX('~',@l_str)+1,len(@l_str))
		  set @l_status =@l_str
	     print(@l_date)
		 -- set @tmpStr = substring(@tmpStr,CHARINDEX('$',@tmpStr)+1,len(@l_str))
	   
		  select @pubcode=Pub_Code,@editioncode=Edition_Code from edition_mast where Edition_Alias=@l_ed-- AND ROWNUM<=1;
		  --select @sr_no=max(SRno)+1 from tbl_booking_subedition_g
	   
		  insert into tbl_booking_subedition_g(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,PAGE_NO) 
		  values(@compcodem,@cioidm,@insertidm,@pubcode,@editioncode,@l_date,@l_hight,@l_width,@l_size,@l_status,@receiptnom,@l_pageno)
	   
		  FETCH next from c1 INTO @spli_str
    end 
    close c1
    deallocate c1
 drop table #tempsplitstr
 end
 else
 begin
       select @pubcode=Pub_Code,@editioncode=Edition_Code from edition_mast where ltrim(Edition_Code)=ltrim(@editioncodem)-- and rownum<=1;
     -- insert into abctest values(pubcode,editioncode);
      -- select @sr_no=max(SRno)+1 from tbl_booking_subedition_g
    select @combinname=Combin_Desc from combin_mast where Combin_Code=@pkgcode
		if(charindex('+',@combinname)>0)
insert into tbl_booking_subedition_g(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,NO_INSERT,PAGE_NO)
       select @compcodem,@cioidm,@insertidm,Pub_Code,Edition_Code,@insertdatem,@heightm,@widthm,@totaream,'booked',@receiptnom,@insertno,@pageno
       from edition_mast where  Pub_Code=@pubcode and City_Code=@editioncode and Edition_Type='Edition'
begin
       insert into tbl_booking_subedition_g(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,NO_INSERT,PAGE_NO)
       select @compcodem,@cioidm,@insertidm,Pub_Code,Edition_Code,@insertdatem,@heightm,@widthm,@totaream,'cancel',@receiptnom,@insertno,@pageno
       from edition_mast where  Pub_Code=@pubcode and City_Code=@editioncode and Edition_Type='Edition'
end       
     
 end 



@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER PROCEDURE [dbo].[FetchSubEditionDetail]
(
 @compcode as  VARCHAR(8),
 @edition as varchar(20),
 @insertid as varchar(50),
 @dateformat as VARCHAR(20),
@pkgcode as varchar(50)
 )
as

declare @pubcode as varchar(10)
declare @centcode  as varchar(10)
declare @insertidm as varchar(20)

set @insertidm=@insertid
select @pubcode=Pub_Code ,@centcode=  City_Code from edition_mast where Edition_Alias=@edition and "Edition_Type"= 'Main Edition'
--set @pubcode =(select Pub_Code from edition_mast where Edition_Alias=@edition)
--set @centcode=(select City_Code from edition_mast where Edition_Alias=@edition)
if (@insertid is null or @insertid ='' )
begin
        select Edition_Alias as Edition from edition_mast where Comp_Code=@compcode and Edition_Type='Edition' and Pub_Code=@pubcode and City_Code=@centcode
end
else
begin
if (@dateformat='dd/mm/yyyy') 
     begin
        select COMP_CODE, CIOID, INSERTID, PUBLICATION, (SELECT Edition_Alias from edition_Mast where Edition_Code=EDITION) as EDITION,convert(varchar(10),INSERTDATE,103) as INSERTDATE, isnull(HEIGHT,'') as HEIGHT, isnull(WIDTH,'') AS WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO,isnull(PAGE_NO,'') as "PAGE_NO" from tbl_booking_subedition  where insertid=@insertidm;
     end
else if (@dateformat='mm/dd/yyyy') 
   begin
        select COMP_CODE, CIOID, INSERTID, PUBLICATION, (SELECT Edition_Alias from edition_Mast where Edition_Code=EDITION) as EDITION,convert(varchar(10),INSERTDATE,101) as INSERTDATE, isnull(HEIGHT,'') as HEIGHT, isnull(WIDTH,'') AS WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO,isnull(PAGE_NO,'') as "PAGE_NO" from tbl_booking_subedition  where insertid=@insertidm;        
   end
else
  begin
        select COMP_CODE, CIOID, INSERTID, PUBLICATION, (SELECT Edition_Alias from edition_Mast where Edition_Code=EDITION) as EDITION, convert(varchar(10),INSERTDATE,111) as INSERTDATE, isnull(HEIGHT,'') as HEIGHT, isnull(WIDTH,'') AS WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO,isnull(PAGE_NO,'') as "PAGE_NO" from tbl_booking_subedition  where insertid=@insertidm;        
   end

 end            


 select Combin_Desc from combin_mast where Combin_Code=@pkgcode 
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER  PROCEDURE [dbo].[updateDataEditionDetail]
(
 @srno_p as  int,
 @insertid_p as varchar(50),
 @height_p as float,
 @width_p as float,
 @totarea_p as float,
 @dateI_p as datetime,
 @edition_p as varchar(20),
 @receiptno_p as varchar(50),
 @insstatus_p as varchar(20),
 @pageno_p	  as varchar(50)
)
As
 update tbl_booking_subedition set INSERTDATE=@dateI_p,HEIGHT=@height_p,WIDTH=@width_p,TOTALAREA=@totarea_p, INSERTSTATUS=@insstatus_p,PAGE_NO= @pageno_p 
 where RECEIPTNO=@receiptno_p and INSERTID=@insertid_p AND SRNO=@srno_p
   
//==================================************End*********************==================//

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@bullet master@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


**********************************************start issue no:6305********************************************************
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
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
set @query1='select 
c.Agency_Name AS "AGENCY",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE a.comp_code=CUST_MAST.comp_code AND Cust_Code=Client_code),Client_code)  AS "CLIENT", 
b.Edition as "EDITION",
CASE '''+@pdateformat+'''
 WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),Insert_Date,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),Insert_Date,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),Insert_Date,111)  END AS "PUB_DATE" ,
a."NO_OF_INSERTION",
isnull(a.Agrred_rate,a.Card_rate ) AS "RATE",
(select Comp_Name from comp_mst where comp_mst.Comp_Code=a.Comp_code) comp_name
from tbl_booking_mast a,tbl_booking_insert b,agency_mast c
WHERE a.Comp_code='''+@pcompcode+''' AND
a.Agency_sub_code=c.code_subcode AND
a.cio_booking_id=b.Cio_Booking_Id  and
 ((b.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )'

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




*************************************************end isue no:6305**********************************************************


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@5647@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


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
SECTIONCODE,RESOURCE_NO,Remarks,CAPTION
from tbl_booking_insert where Cio_Booking_Id=@cioid order by Insert_Id;


end


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@5647@@@@@@@@@@@end@@@@@@@@@@@@@@@@@@@@@@@

/*********************mimoh 0006376**********************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




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
@p_empcode as varchar(50)


as

declare @query as varchar(1000)

declare @query2 as varchar(1000)

--set @query='insert into Exec_mast(Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,phone,exe_status,userid,comp_code,pin_code)  values('''+@teamcode+''','''+@exename+''','''+@designation+''','''+@address+''','''+@street+''' ,'''+@country+''','''+@state+''','''+@district+''','''+@city+''','''+@phone+''','''+@status+''','''+@userid+''','''+@compcode+''','''+@pin+''')'

set @query='update  Exec_mast set  Exec_name='''+@exename+''' ,Designation='''+@designation+''',Add1='''+@address+''',Street='''+@street+''',Country_code='''+@country+''',State_code='''+@state+''',dist_code='''+@district+''',city_code='''+@city+''',phone='''+@phone+''',exe_status='''+@status+''' ,pin_code='''+@pin+''', report_to='''+@report+''',TALUKA='''+@TALUKA1+''',REPRESENTATIVE='''+@repname+''',ADTYPE='''+@adtype+''',Branch_code='''+@branchcode+''',CREDIT_LIMIT='''+@craditlimit+''',MOBILENO='''+@mobile+''',EMAILID='''+@email+''',HR_CODE='''+@p_empcode+''' where comp_code='''+@compcode+''' and Exe_no='''+@code+'''  ' --EXEC_EMAILID='''+@EXEC_EMAILID+''',EXEC_USERID='''+@EXEC_USERID+'''
print(@query)
exec(@query)


set @query2='update Exec_mast set city_name=(select city_name from city_mst where city_code='''+@city+''') where city_code='''+@city+''' '
print(@query2)
exec(@query2)





/******************************/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







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
(Exe_no,Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,phone,exe_status,userid,comp_code,pin_code,report_to,TALUKA,creation_datetime,REPRESENTATIVE,ADTYPE,Branch_code,CREDIT_LIMIT,MOBILENO,EMAILID,HR_CODE ) 
 values(@exeno  ,@teamcode,@exename,@designation,@address,@street ,@country,@state,@district,@city,@phone,@status,@userid,@compcode,@pin,@report,@taluka1,getdate(),@repname,@adtype,@zone,@craditlimit,@mobile,@email,@p_empcode)/*'''+@EXEC_USERID+''','''+@EXEC_EMAILID+'''*/
--print(@query)
exec(@query)
--set @query='insert into tmp_exec_mast(Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,phone,exe_status,userid,comp_code,pin_code)  values('''+@teamcode+''','''+@exename+''','''+@designation+''','''+@address+''','''+@street+''' ,'''+@country+''','''+@state+''','''+@district+''','''+@city+''','''+@phone+''','''+@status+''','''+@userid+''','''+@compcode+''','''+@pin+''')'



set @query2='update Exec_mast set city_name=(select city_name from city_mst where city_code='''+@city+''') where city_code='''+@city+''' '
select @exeno as 'exeno'
print(@query2)
exec(@query2)

/************************************************/


ALTER Procedure [dbo].[execselectbind]

@code as varchar(10),
@compcode as varchar(10),
@userid as varchar(10)

as

declare @query as varchar(1000)
declare @query1 as varchar(1000)
declare @query2 as varchar(1000)
--set @query='insert into Exec_mast(Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,phone,exe_status,userid,comp_code,pin_code)  values('''+@teamcode+''','''+@exename+''','''+@designation+''','''+@address+''','''+@street+''' ,'''+@country+''','''+@state+''','''+@district+''','''+@city+''','''+@phone+''','''+@status+''','''+@userid+''','''+@compcode+''','''+@pin+''')'

set @query='select Exec_name,Designation,Add1,Street,city_code,dist_code,State_code,Country_code,pin_code,phone,exe_status,Exe_no,report_to, EXEC_EMAILID,EXEC_USERID,TALUKA,REPRESENTATIVE  as repname ,ADTYPE as adtype,Branch_code,CREDIT_LIMIT,MOBILENO,EMAILID,(select NAME+''(''+EMP_CODE+'')'' from HR_EMP_MST where COMP_CD='''+@compcode+''' AND EMP_CODE=Exec_mast.HR_CODE)AS HR_CODE from Exec_mast where comp_code='''+@compcode+'''  and Exe_no ='''+@code+''''/*and userid='''+@userid+'''*/
print(@query)
exec(@query)

set @query1='select TALU_CODE,TALU_NAME from taluka_mast,Exec_mast WHERE taluka_mast.DIST_CODE=(select Dist_Code from dist_mst where Dist_Name =(SELECT dist_code FROM Exec_mast where comp_code='''+@compcode+'''  and Exe_no ='''+@code+''')  ) and Exec_mast.comp_code='''+@compcode+'''  and Exec_mast.Exe_no ='''+@code+''''
print(@query1)
exec(@query1)

set @query2='select catcode as adcat from exec_adcat where compcode='''+@compcode+'''  and execcode ='''+@code+''''
print(@query2)
exec(@query2)



/******************************************/



/*********************************************************/

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
      ,(select NAME+''(''+EMP_CODE+'')'' from HR_EMP_MST where COMP_CD='''+@com_code+''' AND EMP_CODE=login.HR_CODE)AS HR_CODE from login where   admin!=''yes'''  --username='''+@username+''''
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
      ,(select NAME+''(''+EMP_CODE+'')'' from HR_EMP_MST where COMP_CD='''+@com_code+''' AND EMP_CODE=login.HR_CODE)AS HR_CODE from login where admin=''yes'''

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
/****************************************************************/

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
@lastname   as VARCHAR(20)



AS

update login set FIRSTNAME=@firstname,LASTNAME =@lastname,username=@username, password=@password, date_format=@date_format, comp_name=@comp_name, com_code=@com_code, curr_code=@curr_code, 
retainer_code=@retainer_code,Agency_code=@agencycode,user_status=@user,Admin=@admin,Company_user=@comp_user ,
 BOOKING_EDITLINES=@editlines, ROLEID=@role,FILTER=@fil, DISCOUNT=@disc, USER_COMPANY=@companylist,EMAIL=@emailid where userid=@userid

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
/*************************************************/
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
@p_empcode as varchar(50)
AS

insert into login(username,   password,   userid,   date_format,    comp_name,com_code, curr_code, retainer_code, Agency_code,user_status,Admin,Company_user,USER_COMPANY,EMAIL ,DISCOUNT,FILTER,ROLEID,BOOKING_EDITLINES,FIRSTNAME,LASTNAME,STATUS,HR_CODE)
values(@username,@password,@userid,@date_format,@comp_name,@com_code,@curr_code,@retainer_code,@agencycode,@user,@admin,@comp_user ,@compnamelist,@emailid,@discount,@filter,@rolename,@editlines,@firstname,@lastname,@pstatus,@p_empcode)


 DELETE FROM MODULE_DETAIBUTTONL WHERE MODULE_DETAIBUTTONL.userid=@userid

 INSERT INTO MODULE_DETAIBUTTONL SELECT BUTTONID, FORM_NAME,COMPCODE,@userid,'',FORM_ID,'','','','','0',''  FROM ROLE_PERMISSION WHERE ROLEID=@rolename










/*********************************************************/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









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
set @query=' select Comp_Code,userid,Retain_Code,Retain_Name,Retain_Alias,Add1,Street,City_Code,Zip,Dist_Code,State_Code,Region_Code,Country_Code,Phone1,Phone2,Fax,EmailID,Credit_Days,Remarks,PAN_No,Retain_status,getdate(),getdate(),pubcent_code,BOXMATTER,PUBLICATION,EDITION,SUPPLEMENT,TALUKA,REPRESENTATIVE as "repname",Branch_code,CREDIT_LIMIT,MOBILENO,SIGN,(select NAME+''(''+EMP_CODE+'')'' from HR_EMP_MST where COMP_CD='''+@compcode+''' AND EMP_CODE=RetainerMaster.HR_CODE)AS HR_CODE from  RetainerMaster where Comp_code='''+@compcode+''''

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









/*****************************************************/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


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
@signature	as varchar(50),
@p_empcode as varchar(50)
)
as

declare @query varchar(1000)
declare @query3 varchar(1000)


if(@flag=0)
begin

set @query = 'insert into RetainerMaster(Comp_Code ,Retain_Code ,userid ,Retain_Name ,Retain_Alias ,Add1 ,Street ,City_Code ,Zip ,Dist_Code ,State_Code ,Zone_Code,Region_Code,Country_Code ,phone1 ,Phone2 ,Fax ,EmailID ,PAN_No ,Credit_Days,Remarks , pubcent_code,Creation_Datetime, retain_status, to_date,BOXMATTER,PUBLICATION,EDITION,SUPPLEMENT,TALUKA,REPRESENTATIVE,Branch_code,CREDIT_LIMIT,MOBILENO,SIGN,HR_CODE)values ('''+@Comp_Code1+''' ,'''+@Retain_Code1+''' ,'''+@userid1+''' ,'''+@Retain_Name1+''' ,'''+@Retain_Alias1+''' ,'''+@Add11+''' ,'''+@Street1+''','''+@City_Code1+''' ,'''+@Zip1+''' ,'''+@Dist_Code1+''','''+@State_Code1+''' ,'''+@zone_code1+''' ,'''+@region_code1+''' ,'''+@Country_Code1+''' ,'''+@phone11+''' ,'''+@Phone21+''' ,'''+@Fax1+''','''+@EmailID1+''','''+@PAN_No1+''' ,'''+@Credit_Days1+''' ,'''+@Remarks1+''','''+@pubcent1+''',getdate(),'''','''','''+@Box1+''','''+@Publication11+''' ,'''+@Edition11+''','''+@Supplement11+''','''+@taluka+''','''+@repname+''','''+@branchcode+''','''+@creditlimit+''','''+ @mobile1+''','''+@signature+''','''+@p_empcode+''') '

end
if(@flag=1)
begin  
	set @query = 'update RetainerMaster set Retain_Name = '''+@Retain_Name1+'''  ,Retain_Alias = '''+@Retain_Alias1+'''  ,Add1 = '''+@Add11 +''',Street = '''+@Street1+''' ,City_Code = '''+@City_Code1+'''  ,Zip = '''+@Zip1+'''  ,Dist_Code = '''+@Dist_Code1+'''  ,State_Code = '''+@State_Code1+''' ,zone_code = '''+@zone_code1+'''  ,region_code = '''+@region_code1+'''  ,Country_Code = '''+@Country_Code1+'''  ,phone1 = '''+@phone11+'''  ,Phone2 = '''+@Phone21+'''  ,Fax = '''+@Fax1+'''  ,EmailID = '''+@EmailID1+'''  ,PAN_No = '''+@PAN_No1+'''  ,Credit_Days = '''+@Credit_Days1+''',Remarks = '''+@Remarks1+''' ,    pubcent_code='''+@pubcent1+''' 
,    BOXMATTER='''+@Box1+''' ,PUBLICATION = '''+@Publication11+'''  ,EDITION = '''+@Edition11 +''',SUPPLEMENT = '''+@Supplement11+''',TALUKA='''+@taluka+''',REPRESENTATIVE='''+@repname+''',Branch_code='''+@branchcode+''',CREDIT_LIMIT='''+@creditlimit+''',MOBILENO='''+ @mobile1+''',SIGN='''+@signature+''',HR_CODE='''+@p_empcode+''' where comp_code = '''+@Comp_Code1 +''' and Retain_Code = '''+@Retain_Code1+''''    --/*   and userid ='''+@userid+'''   */  
--set @query3 = 'update tmpretainer set Retain_Name = '''+@Retain_Name+'''  ,Retain_Alias = '''+@Retain_Alias+'''  ,Add1 = '''+@Add1 +''',Street = '''+@Street+''' ,City_Code = '''+@City_Code+'''  ,Zip = '''+@Zip+'''  ,Dist_Code = '''+@Dist_Code+'''  ,State_Code = '''+@State_Code+'''  ,Country_Code = '''+@Country_Code+'''  ,phone1 = '''+@phone1+'''  ,Phone2 = '''+@Phone2+'''  ,Fax = '''+@Fax+'''  ,EmailID = '''+@EmailID+'''  ,PAN_No = '''+@PAN_No+'''  ,Credit_Days = '''+@Credit_Days+''',Remarks = '''+@Remarks+'''   where comp_code = '''+@Comp_Code +'''and userid ='''+@userid+''' and Retain_Code = '''+@Retain_Code+'''' 
end


print(@query)
exec(@query)
--print(@query3)
--exec(@query3)









/***********************************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[emp_code_bind]

  @pcomp_code  as    VARCHAr(50),                 
   @pname     as       VARCHAr(50) ,
   @pextra1     as       VARCHAr(50) ,
   @pextra2     as       VARCHAr(50) ,
   @pextra3     as       VARCHAr(50) ,
   @pextra4     as       VARCHAr(50) 
as
SELECT DISTINCT "EMP_CODE", "NAME"
                 FROM hr_emp_mst  where  "COMP_CD"=  @pcomp_code  and ( name like @pname+'%' or @pname is null); 
                
                
/*********************mimoh 0006376**********************************/

/*********ankit***************** Isusse 6578***********************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[check_status_code]
@compcode as varchar(8),
@statuscode as varchar(8),
@statusname as varchar(50)


AS

select Status_code from tblstatus where  Status_code=@statuscode and comp_code=@compcode
--select Status_name from tblstatus where  Status_code=@statuscode and comp_code=@compcode
select Status_name from tblstatus where  Status_name=@statusname and comp_code=@compcode

/*********ankit***************** Isusse 6578***********************/


/***************ajay*********Issue 6650***********/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[autoagtypecode]

@str as varchar(30),
@cod as varchar(2)

as

declare @query as  varchar(1000)

declare @query1 as  varchar(1000)
set @query='select * from Agency_type_mst where Agency_Type_Name= '''+@str+'''   '




--set @query1='select max(Agency_Type_Code) as Agency_Type_Code from Agency_type_mst where Agency_Type_Code like '''+@cod+'%'''

set @query1='select MAX(cast(dbo.translate(Agency_Type_Code,''ABCDEFGHIJKLMNOPQRSTUVWXYZ@#$%^&*()!>~<?/_+|=-'',0) as int )) as Agency_Type_Code from Agency_type_mst where  Agency_Type_Code like '''+@cod+'%'''


--print(@query)

print(@query)
exec(@query)

--print(@query)

print(@query1)
exec(@query1)





@@@@@@@@@@@@@@@@@@@@@@@@@@@@@(0006447,0006448)kuldeep@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//==============*********************Start Scripting****************==================//
alter table tbl_booking_mast add MODIFIED_AUDIT varchar(5)

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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

convert(varchar(10),Insert_Date,101) as Insert_Date,Col_Code,Page_No,Size_Book,Width,Height,
(select Adv_Cat_Alias from adv_cat_mast where Adv_Cat_Code=tbl_booking_insert.Ad_Cat ) as AdCategory,
(select Adv_Subcat_Alias from adv_subcat_mast where Adv_Subcat_Code=tbl_booking_insert.Ad_Sub_Cat) as AdSubcategory,
File_Name,Insert_Status,
case Pai_Free_Ins
when 'Y' then 'Yes'
when 'N' then 'No'
end as Pai_Free_Ins
,Gross_Rate,Bill_Amt,BILL_NO,
SECTIONCODE,RESOURCE_NO,Remarks,CAPTION
from tbl_booking_insert where Cio_Booking_Id=@cioid order by Insert_Id;

end
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER PROCEDURE [dbo].[updateauditbooking] 
@cioid varchar(50),
@auditname varchar(50)
 AS
update tbl_booking_mast set audit=@auditname , "ro_status"='1',modified_audit=null where cio_booking_id=@cioid

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
                TRANSLATION_CODE, TRANSLATION_PREMIUM
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

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER PROCEDURE [dbo].[websp_getExec] 
@compcode varchar(50),
@execname varchar(100),
@value varchar(2)
AS
if(@value <> '3')
begin
select exe_no, exec_name from exec_mast where comp_code=@compcode and  exec_name like '%'+upper(@execname)+'%' and exe_status='Active' order by exec_name
end

if(@value='3')
begin
select exe_no, exec_name from exec_mast where comp_code=@compcode and exe_no=@execname and exe_status='Active' order by exec_name
end
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
@psection_code	as varchar(100)
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

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER PROCEDURE [dbo].[updatebooking]

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
@agencycode as varchar(18),
@dockitno as varchar(25),
@execname as varchar(8),
@execzone as varchar(8),
@product as varchar(8),
@brand as varchar(8),
@keyno as varchar(50),
@billremark as varchar(500),
@printremark as varchar(500),
@package as varchar(8),
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
@billto as varchar(100),
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
@dealrate as float,
@deviation as float,
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
@region as varchar(8),
@varient_name as varchar(8),
@status as varchar(50),
@coltype as varchar(8),
@logo_h as varchar(5),
@logo_w as varchar(5),
@logo_col as varchar(8),
@logo_uom as varchar(8),
@retainer1 as varchar(50),
@addagencyrate as varchar(50),
@mobileno as varchar(100),
@addlamt as varchar(50),
@retamt as varchar(50),
@retper as varchar(50),
@cashrecieved as numeric,
@CIRAGENCY AS VARCHAR(100),
@CIRRATE AS VARCHAR(50),
@CIREDITION AS VARCHAR(50),
@CIRPUBLICATION AS VARCHAR(50),
@CIRAGENCYSUBCODE AS VARCHAR(50),
@BARTERTYPE AS VARCHAR(50),
@CASHDISCOUNT_V AS FLOAT,
@CASHDISCOUNTPER_V AS VARCHAR(5),
@attach1 AS varchar(50),
@attach2 AS varchar(50),
@drpdiscprem AS VARCHAR(50),
@doctype as varchar(20),
@CHKTRADE AS VARCHAR(1),
@sharepub_p as varchar(4000),
@fmginsert as varchar(100),
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
@billamtlocal_p as float,
@chkadon_p as varchar(5),
@refid_p as varchar(50),
@rcpt_currency as varchar(8),
@cur_convrate as varchar(8),
@p_revisedate as datetime,
@clienttype as varchar(5),
@translation as varchar(25),
@translationcharge as float
AS
declare @sccode			as varchar(50)
declare @v_modifed_audit varchar(1)
declare @v_audit_exist   numeric(1)

set @v_modifed_audit=null
If @audit is null and @rostatus='1' Begin
    
    select @v_audit_exist=count(*) from tbl_booking_mast 
        where "Comp_code"=@compcode and "cio_booking_id"=@ciobookid and "ro_status"='1' and 
        ("audit" is not null and "audit"!='')
    
    If @v_audit_exist>0 Begin
        set @v_modifed_audit='Y'
    End
End

select @sccode=scheme_id from scheme_master where scheme_name=ltrim(rtrim(@scheme)) and comp_code=@compcode
--insert into tbl_booking_mast( ,  ,  ,  ,  ,  ,  ,  , , ,	 ,  ,  , ,  , ,  ,  ,  ,  ,  ,  ,	  , , , , , ,  ,  ,  ,	 ,  ,	  ,  ,  , ,  ,  ,  ,  ,  ,  ,  ,	  ,  ,  ,  ,Comp_code ,Userid  )
--values			(,,,,, , , , ,, , , ,, ,, , , , , , , ,,, ,,  , , , , , , , , ,,,  , , , , , , , , ,,@compcode ,@userid )

--,,,,,,,,,,,,,,,,,,, 
--,,,,,,,, ,, ,, , ,, , , , , 
create table #recpt_t(receipt_no varchar(30))
update tbl_booking_mast set date_time=@date_time,branch=@branch,booked_by=@booked_by,prev_booking=@prevbook,applied_by=@approvedby,RO_No=@rono,RO_Date=@rodate,
Caption=@caption,bill_status=@billstatus,ro_status=@rostatus,Agency_code=@agency,Agency_address=@agencyaddress,Client_code=@client,Client_address=@clientaddresses,Agency_sub_code=@agencycode,
Dockit_no=@dockitno,Executive_code=@execname,Executive_zone=@execzone,Product_code=@product,Brand_code=@brand,Key_no=@keyno,Bill_remarks=@billremark,Print_remark=@printremark,
Package_code=@package,No_of_insertion=@insertion,Insertion_date=@startdate,Repeating_day=@repeatdate,Ad_type_code=@adtype,Ad_cat_code=@adcategory,Ad_sub_cat_code=@subcategory,
Color_code=@color,Uom_code=@uom,Page_position_code=@pageposition,Page_type_code=@pagetype,Page_no=@pageno,Ad_size_type_code=@adsizetype,Ad_size_height=@adsizheight,
Ad_size_width=@adsizwidth,Rate_code=@ratecode,Scheme_type_code=@sccode,Currency_code=@currency,Agrred_rate=@agreedrate,Agreed_amount=@agreedamt,Special_discount=@spedisc,
Space_discount=@spacedisx,Special_charges=@specialcharges,Agency_status=@agencystatus,Agency_type=@agencytype,Agency_pay=@paymode,Agency_credit=@agencredit,
Total_area=@totarea,Card_rate=@cardrate,Card_amount=@cardamount,Discount=@discount,Discount_per=@discountper,Bill_cycle=@billcycle,Revenue_center=@revenuecenter,
Bill_pay=@billpay,Bill_height=@billheight,Bill_width=@billwidth,Bill_to=@billto,Invoices=@invoices,Vts=@vts,Bill_add=@billaddress,Trade_disc=@tradedisc,Agency_out=@agencyout,
Box_code=@boxcode,Box_no=@boxno,Box_agency=@boxagency,Box_client=@boxclient,Box_address=@boxaddress,Booking_type=@bookingtype,Tfn=@tfn,Coupan_ad=@coupan,Campaign=@campaign,
Bill_amount=@bill_amt,Page_prem=@pageprem,Page_amount=@pageamt,Prem_per=@premper,Gross_amount=@grossamt,Ad_size_column=@adsizcolumn,Bill_column=@billcolumn,
Bill_area=@billarea,Special_disc_per=@specdiscper,Space_disc_per=@spacediscper,Paid_ins= @paidins,Contract_rate=@dealrate,Deviation=@deviation,Variant_code=@varient,
Contract_name=@contractname,Contract_type=@dealtype,Card_name=@cardname,Card_type=@cardtype,Card_month=@cardmonth,Card_year=@cardyear,Card_number=@cardno,Receipt_no=@receiptno,
Ad_Subcat3=@adscat3,Ad_Subcat4=@adscat4,Ad_subcat5=@adscat5,Bg_color=@bgcolor,Bullet_code=@bulletcode,Bullet_premium=@bulletprm,Material_status=@material,region=@region,variant=@varient_name,
status=@status,colortype=@coltype,logo_h=@logo_h,logo_w=@logo_w,logo_color=@logo_col,logo_uom=@logo_uom,RETAINER=@retainer1, ADD_AGENCY_COMM=@addagencyrate, tbl_booking_mast.MOBILENO=@mobileno,
add_agency_comm_amt=@addlamt,retainer_comm=@retper,retainer_comm_amt=@retamt,CASH_RECIEVED=@cashrecieved,CIRAGENCY=@CIRAGENCY,CIRRATE=@CIRRATE,CIREDITION=@CIREDITION,
CIRPUBLICATION=@CIRPUBLICATION,CIRAGENCY_SUBCODE=@CIRAGENCYSUBCODE,BARTER_TYPE=@BARTERTYPE,
CASHDISCOUNT=@CASHDISCOUNT_V, CASHDISCTYPE=@CASHDISCOUNTPER_V, ATTACHMENT1=@attach1, ATTACHMENT2=@attach2, DISC_PREMIUM=@drpdiscprem, DOCTYPE=@doctype,
CHKTRADEDISC=@CHKTRADE,CHK_NO=@chkno,CHK_DATE=@chkdate,CHK_AMT=@chkamt,CHK_BANK_NAME=@chkbankname,OUR_BANK=@ourbank,
DEALERPANEL=@DEALERPANEL_P,
DEALER_H=@DEALERH_P,
DEALER_W=@DEALERW_P,
DEALERTYPE=@DEALERTYPE_P,
ACTIVE_AGREEDRATE=@AGREEDRATE_ACTIVE,
ACTIVE_AGREEDAMT=@AGREEDAMT_ACTIVE,
LOCALGROSSAMT=@grossamtlocal_p,
LOCALBILLAMT=@billamtlocal_p,
PACKAGE_TYPE=@chkadon_p, AD_REFID=@refid_p,
RECEIPT_CURRENCY=@rcpt_currency,CONV_CURR_RATE=@cur_convrate,REVISE_DATE=@p_revisedate,CLIENT_TYPE=@clienttype,
TRANSLATION_CODE=@translation, TRANSLATION_PREMIUM=@translationcharge,MODIFIED_AUDIT=@v_modifed_audit
 where comp_code=@compcode and cio_booking_id=@ciobookid


IF @sharepub_p is not null and @sharepub_p!=''
begin
	exec insert_sharepub_details @sharepub_p,@ciobookid,'UPDATE'
end
 delete from TBL_BOOKING_FMG_TRANS where CIOID=@ciobookid
if @fmginsert is not null and @fmginsert!=''
begin
	exec insert_fmgTrans_details @fmginsert,@ciobookid,'UPDATE'
end
if @multiselect is not null and @multiselect!=''
begin
	exec insert_multiexec_details @userid,@compcode,@multiselect,@ciobookid,'UPDATE'
end

IF @billpay='CA0' AND @rostatus='1' and (@receiptno='' or @receiptno is null)
BEGIN
declare @clientname varchar(500)
declare @remarks varchar(600)
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
select @book_client=client_code,@book_prev_cioid=prev_cioid,@book_Agency_code=Agency_code,@book_retainer=RETAINER,@book_exec=Executive_code,@book_Agency_sub_code=Agency_sub_code,@book_billpay=Bill_pay,@book_userid=userid,@book_datetime=date_time,@book_gross=Gross_amount,@book_billamt=Bill_amount,@prev_cioid=prev_cioid,@book_rec=receipt_no,@book_compcode=comp_code,@book_branch=branch,@book_agencycode=Agency_sub_code from tbl_booking_mast where cio_booking_id=@ciobookid

select @branchcode=Branch_Code  from branch_mst where Comp_Code=@book_compcode and Branch_Name=@book_branch

select @subagencyreg=SUB_Agency_Code  from agency_mast where Comp_Code=@book_compcode and code_subcode=@book_agencycode
set @vrecpt=@book_rec
set @prevcioid_v=@prev_cioid

if @prevcioid_v is null or @prevcioid_v=''
begin
		set @billamt_v=@book_billamt
		set @grossamt_v=@book_gross
		set @v_curdate=getdate()
end
else
begin
		select @billamt_v=Bill_amount,@grossamt_v=Gross_amount from tbl_booking_mast where cio_booking_id=@prevcioid_v
		set @billamt_v=@book_billamt - @billamt_v
		 set @grossamt_v=@book_gross - @grossamt_v
		 set @v_curdate=getdate()
end

 SELECT @clientname=Cust_Name FROM CUST_MAST WHERE Cust_Code = @book_client and Comp_Code=@book_compcode
if @clientname=''
begin
set @clientname=@book_client
end	

print @clientname
select @remarks='RONO#'+RO_No +' RODATE# ' + isnull(convert(varchar(12),RO_Date,103),'') + ' BOOKINGID# ' + cio_booking_id + ' CLIENT#' + @clientname from tbl_booking_mast where cio_booking_id=@ciobookid
insert into #recpt_t 
 exec receiptsave_booking @book_compcode,@book_userid, @book_branch,@doctype,@vrecpt,@v_curdate,@book_billpay,'','',@billamt_v,@book_Agency_sub_code,@grossamt_v,
  '','','',@remarks,@vrepcode,@book_datetime,@book_Agency_code,@subagencyreg,'',@ciobookid,@book_exec,@book_retainer,@book_prev_cioid
select @v_rcptno_r=receipt_no from   #recpt_t
update tbl_booking_mast set Receipt_no=@v_rcptno_r,receipt_date=@v_curdate where cio_booking_id=@ciobookid
drop table #recpt_t
END
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
    set @query='select distinct tbl_booking_insert.cio_booking_id,(select "Col_Name" from col_mast where "Col_Code"=tbl_booking_insert."Col_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION",insert_id,Insert_date,Gross_rate,Bill_Amt from tbl_booking_insert,tbl_booking_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and tbl_booking_insert.comp_code='''+@compcode+''' and insert_date between '''+@fromdate+''' and '''+@todate+''' and tbl_booking_mast.Agency_sub_code= '''+@agency+''' and tbl_booking_mast.Ad_type_code= '''+@p_adtye+''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')' 

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
set @query='select distinct tbl_booking_insert.cio_booking_id,(select "Col_Name" from col_mast where "Col_Code"=tbl_booking_insert."Col_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION",insert_id,Insert_date,Gross_rate,Bill_Amt from tbl_booking_insert,tbl_booking_mast where tbl_booking_insert.comp_code='''+@compcode+'''  and tbl_booking_mast.Agency_sub_code= '''+@agency+''' and tbl_booking_mast.Ad_type_code= '''+@p_adtye+''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')' 
 set @query=@query + ' and tbl_booking_insert.Insert_Id in(select insert_id from #tmp1)'
print(@query)
exec(@query)
drop table #tmp1
end


  End 

//==================================************End*********************==================//
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@(0006447,0006448)kuldeep@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

///////////////////////////////////updated by Garima





alter FUNCTION FETCH_NO_OF_INSERT(@PCOMP_CD VARCHAR(max),@pub_date datetime,@pak_code as varchar(2000)) RETURNs VARCHAR(max)

as
BEGIN
declare @v_nm as VARCHAR(200)
declare @v_gr as varchar(200)
declare @v_val as varchar(2000)
declare @v_vals as varchar(2000)

---for rate--
declare @v_rate as float
declare @v_type as varchar(200)
declare @v_amt as float
declare @v_tot as float
declare @per_amount as float
declare @c1pack as varchar(100)


set @v_val=''
declare C1 cursor for
 select no_insert from  tbl_booking_insert where cio_booking_id=@PCOMP_CD and insert_date=@pub_date and package_code=@pak_code




open C1;
fetch next from c1
into @c1pack
while @@fetch_status=0
     begin
          if (@v_val='')
          begin

          set @v_val=@c1pack

		  end
          else
		  begin
          set @v_val=@v_val+'~' + @c1pack

          end     
fetch next from c1
into @c1pack
end
close c1  

return @v_val
END




///////////////////
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER procedure [dbo].[websp_selectinvoiceno_insertion1]
(
@ciobooking  varchar(50), 
@insertion varchar(50),
@pub_date datetime
)

as 

declare @str  as varchar(3000)
declare @package_cd  as varchar(300)
declare @package_result  as varchar(300)
declare @package_cd1  as varchar(300)
declare @combin_code as varchar(50)

create table #package ( package_name varchar (100) )

--select bilno from ad_bills where idnum=@ciobooking  and insnum=@insertion and BILDT=@pub_date


select bilno from ad_bills where idnum=@ciobooking   and BILDT=@pub_date


select  @package_cd1=package_code from tbl_booking_mast where cio_booking_id=@ciobooking

DECLARE c1 CURSOR READ_ONLY
FOR
select Edition_Name from fn_SplitField(@package_cd1,',')
	open c1
	FETCH NEXT FROM c1
	INTO @package_result
	WHILE @@FETCH_STATUS = 0
	BEGIN
	insert into #package select combin_desc from combin_mast where combin_code=@package_result
	FETCH NEXT FROM c1
	INTO  @package_result
	END
	print(@package_result)
CLOSE c1
DEALLOCATE c1

exec(@str)
select * from #package
delete from #package
select distinct edition_code from tbl_booking_insert 
where  cio_booking_id=@ciobooking 

--and no_insert=@insertion





////////////////////////////////////////////



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go








ALTER procedure  [dbo].[websp_getinsertionwise]
--@code as varchar(10),
@fromdate as varchar(10),
 @todate as varchar(10),
@date as varchar(15),
@publication as varchar(50),
@bookingcenter as varchar(40),
@revenuecenter as varchar(40),
@agencytype as varchar(30),
@package as varchar(40),
@adtype as varchar(50),
@agency as varchar(50),
@client as varchar(50),
@billstatus as varchar(50),
@rate_audit as varchar(8),
@billmode as  varchar(10),
@billcycle as varchar(10),
@v_retainer_name AS varchar(10),
@v_executive_name AS varchar(10),
@v_branch_name AS varchar(10),
@v_ad_category AS varchar(10),
@v_district AS varchar(10),
@v_taluka AS varchar(10),
@pcompcode AS varchar(10),
@billno as varchar(200),
@BILL_GEN_PRIOR as varchar(50)=null,
@PUB_CENT_HO as varchar(50)=null,
@centerlogin as varchar(50)=null,
@fmg_bills as varchar(20)=null,
@scheme_type as varchar(50)=null,
@pto_bill_no as varchar(50)

 AS



declare @package_cd  as varchar(300)
declare @package_result  as varchar(300)
declare @package_cd1  as varchar(300)
declare  @str as varchar(8000)
declare @billcyc as varchar(40)
declare @v_bill_criteria as varchar(10);
create table #package ( package_name varchar (100) )
declare @c1pack as varchar(100)
print(@billcycle)


if @adtype='DI0' begin
    select @v_bill_criteria=disp_billing_criteria from preferrences where comp_code=@pcompcode
	end
else
	begin
    select @v_bill_criteria=clsd_billing_criteria From preferrences where comp_code=@pcompcode
	end











if(@billstatus='2')
begin



 set  @str='SELECT  DISTINCT  TBL_BOOKING_INSERT.Cio_Booking_Id, dbo.FETCH_NO_OF_INSERT(TBL_BOOKING_INSERT.Cio_Booking_Id,TBL_BOOKING_INSERT.insert_date,tbl_booking_insert.package_code) AS no_of_insertion ,TBL_BOOKING_MAST.Package_code  AS edition,
      isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client,
      AGENCY_MAST.Agency_Name AS Agency,sum(TBL_BOOKING_INSERT.Gross_Rate) as Gross_Rate,TBL_BOOKING_MAST.Trade_disc AS Commission,convert(varchar,tbl_booking_insert.Insert_Date,101) as "pub_date",
      TBL_BOOKING_INSERT.Insert_Status AS status,TBL_BOOKING_MAST.No_of_insertion AS total,TBL_BOOKING_MAST.Bill_remarks,
      tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount",
tbl_booking_insert.package_code
      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id  AND
       TBL_BOOKING_INSERT.Insert_Status=''billed'' AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code'



/*
 set  @str='select distinct max(tbl_booking_insert.cio_booking_id) cio_booking_id,max(no_insert)as no_of_insertion ,max(tbl_booking_mast.package_code) as edition ,
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=tbl_booking_mast.Client_code),tbl_booking_mast.Client_code) ''''  AS client,
max(tbl_booking_mast.trade_disc) as Commission,convert(varchar,max(tbl_booking_insert.Insert_Date),101) as "pub_date",
AGENCY_MAST.agency_name as Agency,sum(tbl_booking_insert.gross_rate) as gross_rate,tbl_booking_insert.insert_status as status,count(tbl_booking_mast.no_of_insertion) as total,max(TBL_BOOKING_MAST.Bill_remarks) as Bill_remarks,
tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount",

tbl_booking_insert.package_code
from tbl_booking_insert,tbl_booking_mast,agency_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.cio_booking_id  
 and agency_mast.code_subcode=tbl_booking_mast.agency_sub_code  and ( tbl_booking_insert.insert_status=''billed'')' 

*/
end






if(@billstatus=1 and @rate_audit='n' and ( @billmode='3' ))
begin
set  @str='SELECT  DISTINCT  TBL_BOOKING_INSERT.Cio_Booking_Id, dbo.FETCH_NO_OF_INSERT(TBL_BOOKING_INSERT.Cio_Booking_Id,TBL_BOOKING_INSERT.insert_date,tbl_booking_insert.package_code) AS no_of_insertion  ,TBL_BOOKING_MAST.Package_code  AS edition,
    isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client,
      AGENCY_MAST.Agency_Name AS Agency,sum(TBL_BOOKING_INSERT.Gross_Rate) as Gross_Rate,TBL_BOOKING_MAST.Trade_disc AS Commission,convert(varchar,tbl_booking_insert.Insert_Date,101) as "pub_date",
      TBL_BOOKING_INSERT.Insert_Status AS status,TBL_BOOKING_MAST.No_of_insertion AS total,TBL_BOOKING_MAST.Bill_remarks,

	  tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount",
tbl_booking_insert.package_code
      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
 AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code  AND (TBL_BOOKING_INSERT.Insert_Status=''billed'')' ;

end

if( @billstatus='3' )
begin
set  @str='select distinct  tbl_booking_insert.cio_booking_id,dbo.FETCH_NO_OF_INSERT(TBL_BOOKING_INSERT.Cio_Booking_Id,TBL_BOOKING_INSERT.insert_date,tbl_booking_insert.package_code) AS no_of_insertion  ,tbl_booking_mast.package_code as edition ,
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client,
tbl_booking_mast.trade_disc as Commission,convert(varchar,tbl_booking_insert.Insert_Date,101) as "pub_date",
AGENCY_MAST.agency_name as Agency,sum(tbl_booking_insert.gross_rate) as gross_rate,tbl_booking_insert.insert_status as status,tbl_booking_mast.no_of_insertion as total,TBL_BOOKING_MAST.Bill_remarks as Bill_remarks,

tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount",
tbl_booking_insert.package_code
from tbl_booking_insert,tbl_booking_mast,agency_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.cio_booking_id  
 and agency_mast.code_subcode=tbl_booking_mast.agency_sub_code  and ( tbl_booking_insert.insert_status=''audit by rate'')' 

end


IF(@billstatus=6)
begin
set  @str=' SELECT DISTINCT  TBL_BOOKING_INSERT.Cio_Booking_Id,dbo.FETCH_NO_OF_INSERT(TBL_BOOKING_INSERT.Cio_Booking_Id,TBL_BOOKING_INSERT.insert_date,tbl_booking_insert.package_code) AS no_of_insertion  ,TBL_BOOKING_MAST.Package_code AS edition ,
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client,
AGENCY_MAST.Agency_Name AS Agency,sum(TBL_BOOKING_INSERT.Gross_Rate) as Gross_Rate,TBL_BOOKING_MAST.Trade_disc AS Commission,convert(varchar,tbl_booking_insert.Insert_Date,101) as "pub_date",
TBL_BOOKING_INSERT.Insert_Status AS status,TBL_BOOKING_MAST.No_of_insertion AS  total,TBL_BOOKING_MAST.Bill_remarks,
tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount",
tbl_booking_insert.package_code
FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id  AND
 TBL_BOOKING_INSERT.Insert_Status=''booked'' AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code ';
END 


IF(@billstatus=5)
 begin

    set  @str='SELECT  DISTINCT  TBL_BOOKING_INSERT.Cio_Booking_Id, dbo.FETCH_NO_OF_INSERT(TBL_BOOKING_INSERT.Cio_Booking_Id,TBL_BOOKING_INSERT.insert_date,tbl_booking_insert.package_code) AS no_of_insertion ,TBL_BOOKING_MAST.Package_code  AS edition,
      isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client,
      AGENCY_MAST.Agency_Name AS Agency,sum(TBL_BOOKING_INSERT.Gross_Rate) as Gross_Rate,TBL_BOOKING_MAST.Trade_disc AS Commission,convert(varchar,tbl_booking_insert.Insert_Date,101) as "pub_date",
      TBL_BOOKING_INSERT.Insert_Status AS status,TBL_BOOKING_MAST.No_of_insertion AS total,TBL_BOOKING_MAST.Bill_remarks,
      tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount",
tbl_booking_insert.package_code
      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id  AND
       TBL_BOOKING_INSERT.Insert_Status=''publish'' AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code' ;
   END 

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
if @v_bill_criteria='R' begin --it is for bill cycle in booking
	if(@billcycle is not null )
	begin
		set @str=@str+' and replace(TBL_BOOKING_MAST.Bill_cycle,''0'',''1'') ='''+@billcycle +''''
--print(@billcycle)
	end
end

if(@agency is not null)
begin

set @str=@str+' and TBL_BOOKING_MAST.agency_sub_code ='''+@agency +''''
end

if(@client is not null)
begin
set @str=@str+' and TBL_BOOKING_MAST.client_code ='''+@client +''''
end
if(@agencytype is not null)
begin
set @str=@str+' and TBL_BOOKING_mast.agency_type  ='''+@agencytype+''''
end


if(@adtype is not null)
begin
print(@adtype)
set @str=@str + ' and TBL_BOOKING_MAST. ad_type_code ='''+@adtype+''' '
End


if(@bookingcenter is not null)
begin
--print(@adtype)
set @str=@str + 'and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@bookingcenter+'''))';
--set @str=@str + ' and TBL_BOOKING_MAST. branch ='''+@bookingcenter+''' '
End


if(@revenuecenter is not null)
begin

set @str=@str + ' and TBL_BOOKING_MAST. branch ='''+@revenuecenter+''' '
End


if(@publication is not null)
begin
set @str=@str+' and  TBL_BOOKING_INSERT.publication_code='''+ @publication +''''
End

 if(@fromdate is not null and @todate is not null )
begin
	set @str=@str+' and insert_date between  '''+@fromdate +''' and  '''+@todate +''' '
end


--print('ankur33')
print(@package)
if(@package is not null)
begin
print(@package)
set @str=@str+' and  TBL_BOOKING_insert.edition ='''+@package +''''
End

/*
if(@BILL_GEN_PRIOR = 'PUB_CENT_HO')
begin
		if(@PUB_CENT_HO is not null) and @PUB_CENT_HO=@centerlogin
		begin
		set @str=@str+' and  ((TBL_BOOKING_INSERT.pub_cent_code='''+@PUB_CENT_HO+''''+') or (tbl_booking_insert.package_code in (SELECT package_code FROM temp_packagename)))'
		end
		else
		begin
		set @str=@str+' and  ((TBL_BOOKING_INSERT.pub_cent_code='''+@centerlogin+''''+') and (tbl_booking_insert.package_code not in (SELECT package_code FROM temp_packagename)))'
		end
end
*/
if((@billno is not null) and (@pto_bill_no is not null))
begin
		set @str=@str+' and  TBL_BOOKING_INSERT.bill_no between '''+@billno+'''  and '''+@pto_bill_no+''''

end



if(@fmg_bills !='Include')
begin
set @str=@str+' and tbl_booking_mast.Booking_type not in (''2'',''4'',''5'')'

end

if(@billstatus='2')
begin


set @str=@str+' group by tbl_booking_insert.cio_booking_id,tbl_booking_mast.package_code
	,tbl_booking_mast.client_code,tbl_booking_mast.trade_disc,AGENCY_MAST.agency_name
	,tbl_booking_insert.insert_status 
	,tbl_booking_mast.no_of_insertion ,TBL_BOOKING_MAST.Bill_remarks,tbl_booking_insert.bill_no,
	tbl_booking_insert.Comp_Code,tbl_booking_insert.Insert_Date ,tbl_booking_insert.package_code

	order by tbl_booking_insert.cio_booking_id'

/*
	set @str=@str+' group by AGENCY_MAST.agency_name,tbl_booking_insert.insert_status ,
	tbl_booking_insert.bill_no,tbl_booking_insert.Comp_Code
	order by tbl_booking_insert.bill_no,cio_booking_id'
*/
end
else
begin
	set @str=@str+' group by tbl_booking_insert.cio_booking_id,tbl_booking_mast.package_code
	,tbl_booking_mast.client_code,tbl_booking_mast.trade_disc,AGENCY_MAST.agency_name
	,tbl_booking_insert.insert_status 
	,tbl_booking_mast.no_of_insertion ,TBL_BOOKING_MAST.Bill_remarks,tbl_booking_insert.bill_no,
	tbl_booking_insert.Comp_Code,tbl_booking_insert.Insert_Date ,tbl_booking_insert.package_code

	order by tbl_booking_insert.cio_booking_id'
end












select  @package_cd1=tbl_booking_insert.package_code from tbl_booking_insert,tbl_booking_mast,agency_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.cio_booking_id  
 and agency_mast.code_subcode=tbl_booking_mast.agency_sub_code  and (tbl_booking_insert.insert_status ='publish' or tbl_booking_insert.insert_status='billed')
--insert into #package select replace(package_code,'''','') from dbo.PA_Splitedition(@editioncode,',' )


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




print( @str)
exec( @str)



select * from #package
delete from #package


/*if(@billstatus <> null)
begin
set @str=@str+' and  TBL_BOOKING_INSERT.insert_status='''+ @billstatus +''''
End*/




///////////////////////////////////////////////update by Garima

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

create procedure [dbo].[websp_selectvalues_vision]
(

@ciobooking  varchar(50), 
@editionname varchar(50),
@compcode  VARCHAR(50),
@insertion varchar(50),
@dateformat varchar(50),
@pubdate as datetime
)
as 
declare @str  as varchar(8000)
declare @str1 as varchar(8000)
declare @str3 as varchar(8000)
declare @package_cd  as varchar(300)
declare @package_result  as varchar(300)
declare @package_cd1  as varchar(300)
--declare @subcat as varchar(50)
--change for card rate two lines
declare @adtype as varchar(8)
declare @p_bill_no as varchar(50)
select @adtype=Ad_type_code from tbl_booking_mast where comp_code=@compcode and cio_booking_id=@ciobooking

create table #package ( package_name varchar (200) )
print(@pubdate)

select @p_bill_no=BILL_NO from  tbl_booking_insert where Cio_Booking_Id=@ciobooking and INSERTS=@insertion
PRINT @p_bill_no
set @str='select  TBL_BOOKING_MAST.cio_booking_id as "CIOID",
AGENCY_MAST.agency_name as "Agency",
PUB_MAST.pub_name as "Pub",PUB_MAST.pub_name as "Pub"
,tbl_booking_insert.height as "Depth",
case 
when TBL_BOOKING_MAST.uom_code=''CO0'' then tbl_booking_insert.No_ofcolumn
when TBL_BOOKING_MAST.uom_code <> ''CO0'' then tbl_booking_insert.width end as "Width"
, COL_MAST.col_alias as "Hue"
,tbl_booking_insert.no_insert as "Ins.No."
  ,ro_no as "RoNo.",TBL_BOOKING_MAST.card_amount as "Amt"
,TBL_BOOKING_INSERT.disc_rate as "Disc",
(select distinct  advpos_type_mast.pos_type from advpos_type_mast where advpos_type_mast.pos_type_code=tbl_booking_insert.page_post) as "pageposition",
(select distinct adv_cat_mast.adv_cat_name from adv_cat_mast where ADV_CAT_MAST.adv_cat_code=TBL_BOOKING_MAST.ad_cat_code) as "AdCat",
tbl_booking_insert.size_book as "volume",tbl_booking_mast.card_rate as "package rate", edition_mast. edition_alias as "edition"
,isnull((select distinct cust_mast.cust_alias from cust_mast  where  cust_mast.cust_code=tbl_booking_mast.client_code),tbl_booking_mast.client_code) as "advertiser",
tbl_booking_mast.agency_sub_code,tbl_booking_insert.gross_rate as gross_amount,agency_mast.add1 , city_mst.city_name,
(select box_mast.box_charges_native from box_mast  ,tbl_booking_mast where  tbl_booking_mast.box_code=box_mast.box_code and TBL_BOOKING_MAST.cio_booking_id='''+@ciobooking+''' ) as "boxchares" ,
tbl_booking_insert.gross_rate,tbl_booking_mast.creation_datetime,
(select distinct  min(package_name) from combin_mast where combin_desc='''+@editionname+''')as package_name,
(select distinct cust_mast.ADD1 from cust_mast  where  cust_mast.cust_code=tbl_booking_mast.client_code) as "clientAd",
isnull((select cust_name from CUST_MAST where cust_code=client_code),client_code)  as "Client",tbl_booking_mast.no_of_insertion,
case '''+@dateformat + '''
 when ''mm/dd/yyyy'' then convert(varchar(10),insertion_date,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),insertion_date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),insertion_date,3)  end as "Ins.date" ,tbl_booking_insert. page_no,
(select top 1 premiumname from ADVPOS_PREM_MAST,tbl_booking_insert where   ADVPOS_PREM_MAST. premiumcode=tbl_booking_insert.premium1 and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' and   tbl_booking_insert.no_insert='''+@insertion+''' and  tbl_booking_insert.edition='''+@editionname+''' ),
tbl_booking_mast.special_discount,
isnull(tbl_booking_mast.special_charges,0)as "special_charges"
,tbl_booking_mast.trade_disc,'
print('x')
set @str1='(select top 1 premium_charges from ADVPOS_PREM_MAST,tbl_booking_insert where   ADVPOS_PREM_MAST. premiumcode=tbl_booking_insert.premium1 and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' and   tbl_booking_insert.no_insert='''+@insertion+''' and  tbl_booking_insert.edition='''+@editionname+''' ) as "premiumch",
case '''+@adtype+'''
when ''DI0'' then tbl_booking_insert.card_rate 
when ''CL0'' then
( select top 1 isnull(Week_Extra_Rate,0) from RATE_MAST where Rate_Mast_Code=tbl_booking_mast.Rate_Code
 and combin_code=tbl_booking_mast.Package_code and adv_type_code=tbl_booking_mast.Ad_type_code) end as "card_rate",
pub_cent_mast.add1,
pub_cent_mast.phone1,
pub_cent_mast.phone2 ,
pub_cent_mast.fax1,
TBL_BOOKING_INSERT.agreed_rate,
TBL_BOOKING_INSERT.Edition as "EditionName",
agency_mast.bill_to,
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),insert_date,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),insert_date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),insert_date,3)  end as "insert_date",
tbl_booking_mast.uom_code,
(select distinct Uom_Name from uom_mast where uom_code=tbl_booking_mast.uom_code) as uom_name,
(select distinct  Adv_Type_Name from adv_type_mast where Adv_Type_Code=tbl_booking_mast.Ad_type_code) as ad_type,
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
when ''mm/dd/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,dbo.UD_GET_MAXINSDT('''+@ciobooking+''','''+@insertion+''')),1) 
when ''dd/mm/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,dbo.UD_GET_MAXINSDT('''+@ciobooking+''','''+@insertion+''') ),3) 
when ''yyyy/mm/dd'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,dbo.UD_GET_MAXINSDT('''+@ciobooking+''','''+@insertion+''')),3)  end as "paydatesys",
tbl_booking_insert.insert_id,
AGENCY_MAST."Add2",
AGENCY_MAST."Add3",
dbo.getadd('''+@compcode+''','''+@ciobooking+''') as "agenadd",
tbl_booking_mast."Bill_to" as "bill2",
/*Modified*/
PUB_MAST.Pub_Code as "pub_cod",
edition_mast.Edition_Code as "edit_code",
tbl_booking_mast.Scheme_type_code as "scheme",
tbl_booking_mast.CASHDISCOUNT as "cashdis_per",
TBL_BOOKING_MAST.Agreed_amount as "AgreedAmt",
tbl_booking_mast.Rate_code as "rate_code",
tbl_booking_insert.Insert_status as "status",
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
TBL_BOOKING_MAST.RO_Date ,
AGENCY_MAST.pin_code,
(select top 1 COLORRATEGROUPMAST.prcent_pr from COLORRATEGROUPMAST 
where tbl_booking_mast.comp_code=COLORRATEGROUPMAST.comp_code and 
tbl_booking_mast.ad_type_code=COLORRATEGROUPMAST.ad_type and tbl_booking_insert.package_code=COLORRATEGROUPMAST.pkg_code 
 and tbl_booking_insert.col_code=COLORRATEGROUPMAST.color_name
 and (select top 1 Adv_Subcat_Name from adv_subcat_mast where adv_subcat_mast.Adv_Subcat_Code=tbl_booking_mast.Ad_sub_cat_code)=(select top 1 rate_gr_name from rate_gr_mast where rate_gr_mast.rate_gr_code=COLORRATEGROUPMAST.COLORRATEGP_CODE)) as "Extra",
(select top 1 vat_rate from tbl_vat_mast where tbl_vat_mast.PUBLICATION=
(select top 1 Publication_Code from tbl_booking_insert where Cio_Booking_Id='''+@ciobooking+''')) as "vat_rate",
 (select top 1 Cont_Person from cont_details where tbl_booking_mast.Comp_code=cont_details.Comp_Code 
and cont_details.Agency_Code=tbl_booking_mast.Agency_code) as "contact",
tbl_booking_mast.RETAINER,tbl_booking_mast.Executive_code
from TBL_BOOKING_MAST,pub_cent_mast,
TBL_BOOKING_INSERT,
AGENCY_MAST ,
PUB_MAST,
COL_MAST ,
edition_mast,
city_mst,
comp_mst
 where TBL_BOOKING_MAST.comp_code='''+@compcode+''' and TBL_BOOKING_INSERT.pub_cent_code=pub_cent_mast.pub_cent_code
and TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.cio_booking_id
 and TBL_BOOKING_MAST.agency_code=AGENCY_MAST.agency_code  and comp_mst.comp_code='''+@compcode+''' 
 and tbl_booking_insert.Col_code=col_mast.Col_code   and pub_mast.pub_code=tbl_booking_insert.publication_code 
  and edition_mast.edition_code=tbl_booking_insert.edition_code and city_mst.city_code=agency_mast.city_code  and TBL_BOOKING_INSERT.publication_code = PUB_MAST.pub_code 
and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' and   tbl_booking_insert.no_insert='''+@insertion+''' 
and  tbl_booking_insert.edition='''+@editionname+''''
print('d')
set @str3=' and tbl_booking_insert.insert_date='''+convert (varchar(10),@pubdate,101)+''''
select  @package_cd1=package_code from tbl_booking_mast where cio_booking_id=@ciobooking



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

select distinct edition_code from tbl_booking_insert where  cio_booking_id=@ciobooking

select top 1 insert_date from tbl_booking_insert where  cio_booking_id=@ciobooking 

select convert(varchar(25),dbo.UD_GET_MAXINSDT(@ciobooking,@insertion),3) as "bill_dt"



/////////////////////////////////////////////////////update by Garima


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 10/2/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//==============*********************Start Scripting****************==================//
CREATE OR REPLACE PACKAGE BODY updatebooking IS
PROCEDURE updatebooking_p(
approvedby      in varchar2,
audit1          in varchar2,
rono            in varchar2,
rodate          in date,
caption         in varchar2,
billstatus      in varchar2,
rostatus        in varchar2,
agency          in varchar2,
client          in varchar2,
agencyaddress   in varchar2,
clientaddresses in varchar2,
agencycode      in varchar2,
dockitno        in varchar2,
execname        in varchar2,
execzone        in varchar2,
product         in varchar2,
brand           in varchar2,
keyno           in varchar2,
billremark      in varchar2,
printremark     in varchar2,
package1        in varchar2,
insertion       in number,
startdate       in date,
repeatdate      in varchar2,
adtype1         in varchar2,
adcategory      in varchar2,
subcategory     in varchar2,
color           in varchar2,
uom             in varchar2,
pageposition    in varchar2,
pagetype1       in varchar2,
pageno          in number,
adsizheight     in number,
adsizwidth      in number,
ratecode11      in varchar2,
scheme1         in varchar2,
currency        in varchar2,
agreedrate      in number,
agreedamt       in number,
spedisc         in number,
spacedisx       in number,
compcode        in varchar2,
userid          in varchar2,
ciobookid       in varchar2,
date_time       in date,
branch          in varchar2,
booked_by       in varchar2,
prevbook        in varchar2,
adsizetype      in varchar2,
specialcharges  in number,
agencytype      in varchar2,
agencystatus    in varchar2,
paymode         in varchar2,
agencredit      in number,
cardrate        in number,
cardamount      in number,
discount        in number,
discountper     in number,
billaddress     in varchar2,
totarea         in number,
billcycle       in varchar2,
revenuecenter   in varchar2,
billpay         in varchar2,
billheight      in number,
billwidth       in number,
billto          in varchar2,
invoices        in number,
vts             in number,
tradedisc       in number,
agencyout       in varchar2,
boxcode         in varchar2,
boxno           in varchar2,
boxaddress      in varchar2,
boxagency       in varchar2,
boxclient       in varchar2,
bookingtype     in varchar2,
tfn             in varchar2,
coupan          in varchar2,
campaign        in varchar2,
bill_amt        in number,
pageprem        in varchar2,
pageamt         in number,
premper         in number,
grossamt        in number,
adsizcolumn     in number,
billarea        in number,
billcolumn      in number,
spacediscper    in number,
specdiscper     in number,
paidins         in number,
dealrate        in number,
deviation       in number,
varient         in varchar2,
dealtype        in varchar2,
contractname    in varchar2,
cardname        in varchar2,
cardtype        in varchar2,
cardmonth       in varchar2,
cardyear        in varchar2,
cardno          in varchar2,
receiptno       in varchar2,
adscat3         in varchar2,
adscat4         in varchar2,
adscat5         in varchar2,
bgcolor         in varchar2,
bulletcode      in varchar2,
bulletprm       in number,
material        in varchar2,
region1         in varchar2,
varient_name    in varchar2,
coltype         in varchar2,
logo_h          in varchar2,
logo_w          in varchar2,
logo_col        in varchar2,
logo_uom        in varchar2,
retainer1       in varchar2,
addagencyrate   in varchar2,
mobileno        in varchar2,
addlamt         in varchar2,
retamt          in varchar2,
retper          in varchar2,
cashrecieved    in varchar2,
CIRAGENCY_V     in varchar2,
CIRRATE_V       in varchar2,
CIREDITION_V    in varchar2,
CIRPUBLICATION_V    in varchar2,
CIRAGENCYSUBCODE_V  in varchar2,
BARTERTYPE          IN VARCHAR2,
CASHDISCOUNT_V      IN VARCHAR2,
CASHDISCOUNTPER_V   IN VARCHAR2,
attach1             in varchar2,
attach2             in varchar2,
drpdiscprem         in varchar2,
doctype_v           in varchar2,
CHKTRADE            IN VARCHAR2,
sharepub_p          in varchar2,
fmginsert           in varchar2,
chkno               in VARCHAR2,
chkdate             in date:=null,
chkamt              in VARCHAR2,
chkbankname         in varchar2,
ourbank             in varchar2,
DEALERPANEL_P       in VARCHAR2,
DEALERH_P           in FLOAT,
DEALERW_P           in FLOAT,
DEALERTYPE_P        in VARCHAR2,
multiselect         in VARCHAR2,
AGREEDRATE_ACTIVE   IN NUMBER,
AGREEDAMT_ACTIVE    IN NUMBER,
grossamtlocal_p     IN number,
billamtlocal_p      IN number,
chkadon_p           IN varchar2,
refid_p             IN varchar2,
rcpt_currency       IN varchar2,
cur_convrate        IN varchar2,
clienttype          IN varchar2,
translation         in varchar2,
translationcharge   in number,
p_revisedate        IN DATE
)As
error1          varchar2(100);
sccode          varchar2(50);
mobileno1       varchar2(50);
remarks         varchar2(500);
clientname      varchar2(200);
v_modifed_audit varchar2(1);
v_audit_exist   number(1);
Begin

mobileno1:=mobileno;
--begin
--select distinct "scheme_id" into  sccode  from scheme_master where "Scheme_Name"=ltrim(rtrim(scheme1)) and "Comp_code"=compcode;
--exception when no_data_found then
--NULL ;
--end;  

sccode:=scheme1;


v_modifed_audit:=null;

If audit1 is null and rostatus='1' then
    
    /*select count(*) into v_audit_exist from
    (select count(*) from tbl_booking_mast 
        where "Comp_code"=compcode and "cio_booking_id"=ciobookid and "ro_status"='1' and "audit" is not null
    union
    select count(*) from tbl_booking_mast 
    where "Comp_code"=compcode and "cio_booking_id"=ciobookid and "ro_status"='1' and nvl(modified_audit,'N')='Y') x;
    
    If v_audit_exist>0 then 
        v_modifed_audit:='Y';
    End if;*/
    
    select  case when "audit" is not null then 'Y' 
                 when nvl(modified_audit,'N')='Y' then 'Y' 
            else null  End as modifed_audit into v_modifed_audit from tbl_booking_mast 
        where "Comp_code"=compcode and "cio_booking_id"=ciobookid and "ro_status"='1';

End If;


update tbl_booking_mast set "date_time"=date_time,"branch"=branch,"booked_by"=booked_by,"prev_booking"=prevbook,"applied_by"=approvedby,"audit"=audit1,"RO_No"=rono,"RO_Date"=rodate,
"Caption"=caption,"bill_status"=billstatus,"ro_status"=rostatus,"Agency_code"=agency,"Agency_address"=agencyaddress,"Client_code"=client,"Client_address"=clientaddresses,"Agency_sub_code"=agencycode,
"Dockit_no"=dockitno,"Executive_code"=execname,"Executive_zone"=execzone,"Product_code"=product,"Brand_code"=brand,"Key_no"=keyno,"Bill_remarks"=billremark,"Print_remark"=printremark,
"Package_code"=package1,"No_of_insertion"=insertion,"Insertion_date"=startdate,"Repeating_day"=repeatdate,"Ad_type_code"=adtype1,"Ad_cat_code"=adcategory,"Ad_sub_cat_code"=subcategory,
"Color_code"=color,"Uom_code"=uom,"Page_position_code"=pageposition,"Page_type_code"=pagetype1,"Page_no"=pageno,"Ad_size_type_code"=adsizetype,"Ad_size_height"=adsizheight,
"Ad_size_width"=adsizwidth,"Rate_code"=ratecode11,"Scheme_type_code"=sccode,"Currency_code"=currency,"Agrred_rate"=agreedrate,"Agreed_amount"=agreedamt,"Special_discount"=spedisc,
"Space_discount"=spacedisx,"Special_charges"=specialcharges,"Agency_status"=agencystatus,"Agency_type"=agencytype,"Agency_pay"=paymode,"Agency_credit"=agencredit,
"Total_area"=totarea,"Card_rate"=cardrate,"Card_amount"=cardamount,"Discount"=discount,"Discount_per"=discountper,"Bill_cycle"=billcycle,"Revenue_center"=revenuecenter,
"Bill_pay"=billpay,"Bill_height"=billheight,"Bill_width"=billwidth,"Bill_to"=billto,"Invoices"=invoices,"Vts"=vts,"Bill_add"=billaddress,"Trade_disc"=tradedisc,"Agency_out"=agencyout,
"Box_code"=boxcode,"Box_no"=boxno,"Box_agency"=boxagency,"Box_client"=boxclient,"Box_address"=boxaddress,"Booking_type"=bookingtype,"Tfn"=tfn,"Coupan_ad"=coupan,"Campaign"=campaign,
"Bill_amount"=bill_amt,"Page_prem"=pageprem,"Page_amount"=pageamt,"Prem_per"=premper,"Gross_amount"=grossamt,"Ad_size_column"=adsizcolumn,"Bill_column"=billcolumn,
"Bill_area"=billarea,"Special_disc_per"=specdiscper,"Space_disc_per"=spacediscper,"Paid_ins"=paidins,"Contract_rate"=dealrate,"Deviation"=deviation,"Variant_code"=varient,
"Contract_name"=contractname,"Contract_type"=dealtype,"Card_name"=cardname,"Card_type"=cardtype,"Card_month"=cardmonth,"Card_year"=cardyear,"Card_number"=cardno,"Receipt_no"=receiptno,
"Ad_Subcat3"=adscat3,"Ad_Subcat4"=adscat4,"Ad_subcat5"=adscat5,"Bg_color"=bgcolor,"Bullet_code"=bulletcode,"Bullet_premium"=bulletprm,"Material_status"=material

,"Region"=region1,"Variant"=varient_name,"Colortype"=coltype,
"Logo_H"=logo_h,"Logo_W"=logo_w,"Logo_color"=logo_col,"Logo_Uom"=logo_uom,
"RETAINER"=retainer1, "ADD_AGENCY_COMM"=addagencyrate, tbl_booking_mast.MOBILENO=mobileno1,ADD_AGENCY_COMM_AMT=addlamt,RETAINER_COMM=retper,RETAINER_COMM_AMT=retamt,CASH_RECIEVED=cashrecieved,
CIRAGENCY=CIRAGENCY_V,CIRRATE=CIRRATE_V,CIREDITION=CIREDITION_V,CIRPUBLICATION=CIRPUBLICATION_V,CIRAGENCY_SUBCODE=CIRAGENCYSUBCODE_V,BARTER_TYPE=BARTERTYPE,
CASHDISCOUNT=CASHDISCOUNT_V, CASHDISCTYPE=CASHDISCOUNTPER_V, ATTACHMENT1=attach1, ATTACHMENT2=attach2, DISC_PREMIUM=drpdiscprem, DOCTYPE=doctype_v,CHKTRADEDISC=CHKTRADE,
CHK_NO=chkno,CHK_DATE=chkdate,CHK_AMT=chkamt,CHK_BANK_NAME=chkbankname,OUR_BANK=ourbank,DEALERPANEL=DEALERPANEL_P, DEALER_H=DEALERH_P, DEALER_W=DEALERW_P, DEALERTYPE=DEALERTYPE_P
,ACTIVE_AGREEDRATE=AGREEDRATE_ACTIVE, ACTIVE_AGREEDAMT=AGREEDAMT_ACTIVE,LOCALGROSSAMT=grossamtlocal_p,LOCALBILLAMT=billamtlocal_p,
PACKAGE_TYPE=chkadon_p, AD_REFID=refid_p,RECEIPT_CURRENCY=rcpt_currency,CONV_CURR_RATE=cur_convrate,REVISE_DATE=p_revisedate,CLIENT_TYPE=clienttype,TRANSLATION_CODE=translation, TRANSLATION_PREMIUM=translationcharge,
MODIFIED_AUDIT=v_modifed_audit
where "Comp_code"=compcode and "cio_booking_id"=ciobookid;

    IF sharepub_p is not null then
        insert_sharepub_details(sharepub_p,ciobookid,'UPDATE',error1);
    end if;

    delete from TBL_BOOKING_FMG_TRANS where CIOID=ciobookid;
    if fmginsert is not null then
        insert_fmgTrans_details(fmginsert,ciobookid,'UPDATE',error1);   
    end if;
      
    if multiselect is not null then
        insert_multiexec_details(userid,compcode,multiselect,ciobookid,'UPDATE',error1);
    end if;
                       
if billpay = 'CA0' and rostatus='1' and (receiptno is null or receiptno = '') then

    declare
        cursor c1 is
            select * from tbl_booking_mast where "cio_booking_id"=ciobookid;
       
    v1 c1%rowtype;
    v_error         varchar2(2000);
    v_rcptno_r      varchar2(50);
    vrecpt          varchar2(20);
    branchcode      varchar2(20);
    vrepcode        varchar2(20);
    subagencyreg    varchar2(20);
    prevcioid_v     varchar2(50);
    billamt_v       float;
    grossamt_v      float;
    v_curdate       date;
    begin

        open c1;
        fetch c1 into v1;
        
            Begin
                select "Branch_Code" into branchcode from branch_mst where "Comp_Code"=v1."Comp_code" and "Branch_Name"=v1."branch";
            Exception When no_data_found then
                branchcode:='';
            End;
       
            Begin
                select "SUB_Agency_Code" into subagencyreg from agency_mast where "Comp_Code"=v1."Comp_code" and "code_subcode"=v1."Agency_sub_code";
            Exception When no_data_found then
                subagencyreg:='';
            End;
            vrecpt      :=v1."Receipt_no";
            prevcioid_v :=v1."prev_cioid";

            if prevcioid_v is null or v1."prev_receipt" is null then
                billamt_v   :=v1."Bill_amount";
                grossamt_v  :=v1."Gross_amount";
                v_curdate   :=v1."date_time";
            else
                select "Bill_amount","Gross_amount" into  billamt_v,grossamt_v from tbl_booking_mast where "cio_booking_id"=prevcioid_v;
                billamt_v   :=v1."Bill_amount" - billamt_v;
                grossamt_v  :=v1."Gross_amount" - grossamt_v;
                v_curdate   :=to_date(sysdate);
            end if;
        
            -- select substr(max("recptno"),1,12)||lpad(substr(max("recptno"),-6)+1,6,'0') into vrecpt from ad_rcpthdr where "unit"=branchcode and "doctype"='RCP' and
            -- "recptdt" between '1-mar-2011' and '31-mar-2011';
             
            --receiptsave_booking.receiptsave_booking_P(pcompcode,puserid , punit ,ptype , precpt , prdate , ppaymodres ,preceivedreg ,pvouno  ,pamount  ,pagency , pothercd ,
            --pchno  ,pchedate , pbank  , pnarration ,prep   , pvdate , pag_main_code ,pag_sub_code , ourbank,  cioid , execname , retainer ,
            -- prevcioid , p_error)
                
            Begin
                SELECT "Cust_Name" into clientname FROM CUST_MAST WHERE "Cust_Code" = v1."Client_code" and "Comp_Code"=v1."Comp_code";
            Exception when NO_DATA_FOUND THEN
                clientname:=v1."Client_code";
            END;

            remarks:='RONO#'||v1."RO_No" ||' RODATE# ' || to_char(v1."RO_Date",'dd-mon-yyyy') || ' BOOKINGID# ' || v1."cio_booking_id" || ' CLIENT#' || clientname;

            receiptsave_booking.receiptsave_booking_p(v1."Comp_code",v1."Userid", v1."branch",v1.DOCTYPE,vrecpt,v_curdate,v1."Bill_pay",'','',billamt_v,v1."Agency_sub_code",grossamt_v,
            '','','',remarks,vrepcode,v1."date_time",v1."Agency_code",subagencyreg,'',v1."cio_booking_id",v1."Executive_code",v1.RETAINER,v1."prev_cioid",v_rcptno_r,v_error);
       
            update tbl_booking_mast set "Receipt_no"=v_rcptno_r,"Receipt_date"=v_curdate where "cio_booking_id"=v1."cio_booking_id";
        close c1;
        commit;
    End;
End if;
 
end updatebooking_p;
End updatebooking;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE Websp_Insert_Package1 (suppcode IN VARCHAR2)
AS
sun VARCHAR2(2);
mon VARCHAR2(2);
tue VARCHAR2(2);
wed VARCHAR2(2);
thu VARCHAR2(2);
fri VARCHAR2(2);
sat VARCHAR2(2);
all1 VARCHAR2(2);
packagename VARCHAR2(1000):=null;
edi_alias VARCHAR2(200):=null;
packagecode VARCHAR2(500);
combcode VARCHAR2(50);
count1 NUMBER;
pubname VARCHAR2(100);
compcode VARCHAR2(100);
userid VARCHAR2(100);
pubtype varchar(200);
pubname1 varchar(200);
pubcenter varchar2(200);
BEGIN
select "Pub_Code","Comp_Code","UserId","Supp_Alias","Supp_Alias" into pubname1,compcode,userid,packagename,edi_alias from SUPPLEMENT_MAST where "Supp_Code"=suppcode;
select "publication_type" into pubtype from pub_mast where "Pub_Code"=(pubname1);
if pubtype != 'CO0' then
begin
select "sun","mon","tue","wed","thu","fri","sat","all"
INTO sun,mon,tue,wed,thu,fri,sat,all1
from SELECT_SUPPLEMENT_DAY where "Supp_code"=suppcode;

exception when no_data_found then
null;
end;

combcode:=substr(packagename,1,2);

    begin
        select NVL(max(TO_NUMBER(SUBSTR("Combin_Code",3,lenGTH("Combin_Code")))),-1) INTO COUNT1 from  combin_mast where "Combin_Code" like  combcode||'%';
        exception when no_data_found then
    null;
    end;

if(COUNT1!=-1)THEN
COUNT1:=COUNT1+1;
else
COUNT1:=0;
END IF;

combcode:=combcode||TO_CHAR(COUNT1);

if(sun='Y')
THEN
packagecode:=packagename||'(SUN)';
end IF;
--delete from abc;commit;
--insert into abc values('packagecode',packagecode);
if(mon='Y')
THEN

    IF(packagecode is not null)THEN
    packagecode:=packagecode||'+'||packagename||'(Mon)';
    else
    packagecode:=packagecode||packagename||'(Mon)';
    END IF;

END IF;

--insert into abc values('packagecode',packagecode);
--commit;
if(tue='Y')THEN


    IF(packagecode is not null)THEN
    packagecode:=packagecode||'+'||packagename||'(Tue)';
    else
    packagecode:=packagecode||packagename||'(Tue)';
    END IF;

END IF;

if(wed='Y')
THEN

    IF(packagecode is not null)THEN
    packagecode:=packagecode||'+'||packagename||'(Wed)';
    else
    packagecode:=packagecode||packagename||'(Wed)';
    END IF;

END IF;


if(thu='Y')
THEN

    IF(packagecode  is not null)THEN
    packagecode:=packagecode||'+'||packagename||'(Thu)';
    else
    packagecode:=packagecode||packagename||'(Thu)';
    END IF;

END IF;


if(fri='Y')
THEN

    IF(packagecode is not null)THEN
    packagecode:=packagecode||'+'||packagename||'(Fri)';
    else
    packagecode:=packagecode||packagename||'(Fri)';
    END IF;

END IF;


if(sat='Y')
THEN
--insert into abc values('saty',sat);
    IF(packagecode is not null)THEN

    packagecode:=packagecode||'+'||packagename||'(Sat)';
     
    else
    packagecode:=packagecode||packagename||'(Sat)';
    
    END IF;

END IF;



select COUNT(*) INTO COUNT1 from combin_mast where "Combin_Desc"=packagename;


if(COUNT1=0)
THEN
select COUNT(*) INTO COUNT1 from ADV_TYPE_MAST where "Adv_Type_Code"='DI0';
IF (COUNT1>0) THEN
insert into combin_mast("Comp_Code","Combin_Code","Edition_Combin_Code","Combin_Desc","Package_Name","Package_Alias","UserId","No_Of_Edition","Share_Distribution","Ad_Type_code","Edition_Type","Creation_Datetime","pub_center")
values(compcode,combcode,packagecode,packagename,packagename,packagename,userid,1,'SO0','DI0',2,sysdate,'0');

INSERT INTO COMBIN_DAYS(COMP_CODE,COMBIN_CODE,EDITION_COMBIN_CODE,SUN,MON,TUE,WED,THU,FRI,SAT,ALLDAY,FOCUSDAY) VALUES(compcode,combcode,edi_alias,sun,mon,tue,wed,thu,fri,sat,all1,'N');
END IF;
-------------------------------------
combcode:=substr(packagename,1,2);

select NVL(MAX(TO_NUMBER(NVL(translate("Combin_Code",'ABCDEFGHIJKLMNOPQRSTUVWXYZ',0),0))),-1) INTO COUNT1 from combin_mast where "Combin_Code" like  combcode||'%';

if(COUNT1!=-1)THEN
COUNT1:=COUNT1+1;
else
COUNT1:=0;
END IF;

combcode:=combcode||TO_CHAR(COUNT1);
select COUNT(*) INTO COUNT1 from ADV_TYPE_MAST where "Adv_Type_Code"='CL0';
IF (COUNT1>0) THEN
insert into combin_mast("Comp_Code","Combin_Code","Edition_Combin_Code","Combin_Desc","Package_Name","Package_Alias","UserId","No_Of_Edition","Share_Distribution","Ad_Type_code","Edition_Type","Creation_Datetime","pub_center")
values(compcode,combcode,packagecode,packagename,packagename,packagename,userid,1,'SO0','CL0',2,sysdate,'0');

INSERT INTO COMBIN_DAYS(COMP_CODE,COMBIN_CODE,EDITION_COMBIN_CODE,SUN,MON,TUE,WED,THU,FRI,SAT,ALLDAY,FOCUSDAY) VALUES(compcode,combcode,edi_alias,sun,mon,tue,wed,thu,fri,sat,all1,'N');
END IF;
end IF;


end if;
commit;
END Websp_Insert_Package1;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE Websp_Insert_Package (editioncode IN VARCHAR2)
AS
sun VARCHAR2(2);
mon VARCHAR2(2);
tue VARCHAR2(2);
wed VARCHAR2(2);
thu VARCHAR2(2);
fri VARCHAR2(2);
sat VARCHAR2(2);
all1 VARCHAR2(2);
packagename VARCHAR2(1000):=null;
edi_alias VARCHAR2(50):=null;
packagecode VARCHAR2(500);
combcode VARCHAR2(50);
count1 NUMBER;
pubname VARCHAR2(100);
compcode VARCHAR2(100);
userid VARCHAR2(100);
pubtype varchar(50);
pubname1 varchar(50);
pubcenter varchar2(50);
BEGIN
select "Pub_Code","Comp_Code","UserId","Edition_Alias","Edition_Alias" into pubname1,compcode,userid,packagename,edi_alias from edition_mast where "Edition_Code"=editioncode;
select "publication_type" into pubtype from pub_mast where "Pub_Code"=(pubname1);
if pubtype != 'CO0' then
begin
select "sun","mon","tue","wed","thu","fri","sat","all"
INTO sun,mon,tue,wed,thu,fri,sat,all1
from select_edition_day where "edition_code"=editioncode;

exception when no_data_found then
null;
end;

combcode:=substr(packagename,1,2);

    begin
        select NVL(max(TO_NUMBER(SUBSTR("Combin_Code",3,lenGTH("Combin_Code")))),-1) INTO COUNT1 from  combin_mast where "Combin_Code" like  combcode||'%';
        exception when no_data_found then
    null;
    end;

if(COUNT1!=-1)THEN
COUNT1:=COUNT1+1;
else
COUNT1:=0;
END IF;

combcode:=combcode||TO_CHAR(COUNT1);

if(sun='Y')
THEN
packagecode:=packagename||'(SUN)';
end IF;
--delete from abc;commit;
--insert into abc values('packagecode',packagecode);
if(mon='Y')
THEN

    IF(packagecode is not null)THEN
    packagecode:=packagecode||'+'||packagename||'(Mon)';
    else
    packagecode:=packagecode||packagename||'(Mon)';
    END IF;

END IF;

--insert into abc values('packagecode',packagecode);
--commit;
if(tue='Y')THEN


    IF(packagecode is not null)THEN
    packagecode:=packagecode||'+'||packagename||'(Tue)';
    else
    packagecode:=packagecode||packagename||'(Tue)';
    END IF;

END IF;

if(wed='Y')
THEN

    IF(packagecode is not null)THEN
    packagecode:=packagecode||'+'||packagename||'(Wed)';
    else
    packagecode:=packagecode||packagename||'(Wed)';
    END IF;

END IF;


if(thu='Y')
THEN

    IF(packagecode  is not null)THEN
    packagecode:=packagecode||'+'||packagename||'(Thu)';
    else
    packagecode:=packagecode||packagename||'(Thu)';
    END IF;

END IF;


if(fri='Y')
THEN

    IF(packagecode is not null)THEN
    packagecode:=packagecode||'+'||packagename||'(Fri)';
    else
    packagecode:=packagecode||packagename||'(Fri)';
    END IF;

END IF;


if(sat='Y')
THEN
--insert into abc values('saty',sat);
    IF(packagecode is not null)THEN

    packagecode:=packagecode||'+'||packagename||'(Sat)';
     
    else
    packagecode:=packagecode||packagename||'(Sat)';
    
    END IF;

END IF;



select COUNT(*) INTO COUNT1 from combin_mast where "Combin_Desc"=packagename;


if(COUNT1=0)
THEN
select COUNT(*) INTO COUNT1 from ADV_TYPE_MAST where "Adv_Type_Code"='DI0';
IF (COUNT1>0) THEN
insert into combin_mast("Comp_Code","Combin_Code","Edition_Combin_Code","Combin_Desc","Package_Name","Package_Alias","UserId","No_Of_Edition","Share_Distribution","Ad_Type_code","Edition_Type","Creation_Datetime","pub_center")
values(compcode,combcode,packagecode,packagename,packagename,packagename,userid,1,'SO0','DI0',1,sysdate,'0');

INSERT INTO COMBIN_DAYS(COMP_CODE,COMBIN_CODE,EDITION_COMBIN_CODE,SUN,MON,TUE,WED,THU,FRI,SAT,ALLDAY,FOCUSDAY) VALUES(compcode,combcode,edi_alias,sun,mon,tue,wed,thu,fri,sat,all1,'N');
END IF;
-------------------------------------
combcode:=substr(packagename,1,2);

select NVL(MAX(TO_NUMBER(NVL(translate("Combin_Code",'ABCDEFGHIJKLMNOPQRSTUVWXYZ',0),0))),-1) INTO COUNT1 from combin_mast where "Combin_Code" like  combcode||'%';

if(COUNT1!=-1)THEN
COUNT1:=COUNT1+1;
else
COUNT1:=0;
END IF;

combcode:=combcode||TO_CHAR(COUNT1);
select COUNT(*) INTO COUNT1 from ADV_TYPE_MAST where "Adv_Type_Code"='CL0';
IF (COUNT1>0) THEN
insert into combin_mast("Comp_Code","Combin_Code","Edition_Combin_Code","Combin_Desc","Package_Name","Package_Alias","UserId","No_Of_Edition","Share_Distribution","Ad_Type_code","Edition_Type","Creation_Datetime","pub_center")
values(compcode,combcode,packagecode,packagename,packagename,packagename,userid,1,'SO0','CL0',1,sysdate,'0');

INSERT INTO COMBIN_DAYS(COMP_CODE,COMBIN_CODE,EDITION_COMBIN_CODE,SUN,MON,TUE,WED,THU,FRI,SAT,ALLDAY,FOCUSDAY) VALUES(compcode,combcode,edi_alias,sun,mon,tue,wed,thu,fri,sat,all1,'N');
END IF;
end IF;


end if;
commit;
END Websp_Insert_Package;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE insert_edition_details(
p_str           in varchar2,
receiptnom      in varchar2,
cioidm          in varchar2,
insertidm       in varchar2,
compcodem       in varchar2,
editioncodem    in varchar2,
insertdatem     in date,
heightm         in varchar2,
widthm          in varchar2,
totaream        in varchar2,
insstatusm      in varchar2,
pkgcode         in varchar2,
insertno        in number ,
pageno          in number, 
p_error_text    out varchar2)  
IS
tmpVar  NUMBER;
tmpStr  VARCHAR2(4000);
l_str   VARCHAR2(4000);
l_ed    varchar2(50);
l_date  date;
l_hight number;
l_width number;
l_size  number;
l_pageno number;
l_status    varchar2(20);
pubcode     varchar2(10);
editioncode varchar2(50);
combinname  varchar2(3000);
uomdesc     varchar2(50);
v_edtn_type varchar2(50);
BEGIN

if p_str is not null then
    --INSERT INTO TEST1 VALUES('pubcode','editioncode'); COMMIT;

    --insert into abctest values(insertidm,l_status);
    tmpVar  := 0;
    tmpStr  := p_str;
    l_str   := p_str;

    for i in 1..length(tmpStr)-length(replace(tmpStr,'$',null))+1 
    loop
      
        if instr(tmpStr,'$') > 0 then 
            l_str := substr(tmpStr,1,instr(tmpStr,'$')-1);
        else
            l_str := tmpStr;
        end if;
        --dbms_output.put_line('l_str:'||l_str);
        l_ed := substr(l_str,1,instr(l_str,'~')-1);
        l_str := substr(l_str,instr(l_str,'~')+1);
        l_date := to_date(substr(l_str,1,instr(l_str,'~')-1),'mm/dd/yyyy');
        l_str := substr(l_str,instr(l_str,'~')+1);
                             
        l_hight := substr(l_str,1,instr(l_str,'~')-1);
        l_str := substr(l_str,instr(l_str,'~')+1);
        l_width := substr(l_str,1,instr(l_str,'~')-1);   
        l_str := substr(l_str,instr(l_str,'~')+1);
        l_size:=substr(l_str,1,instr(l_str,'~')-1);  
        l_str := substr(l_str,instr(l_str,'~')+1); 
        l_pageno:=substr(l_str,1,instr(l_str,'~')-1);  
        l_str := substr(l_str,instr(l_str,'~')+1);
        l_status :=l_str;
        -- insert into abctest values(insertidm,'Str:'||l_status||':'||receiptnom||':'||editioncode||':'||pubcode||':'||insertidm||':'||compcodem||':'||cioidm||':'||l_date||':'||l_ed||':'||l_hight||':'||l_width||':'||l_size);
        tmpStr := substr(tmpStr,instr(tmpStr,'$')+1);

        select "Pub_Code","Edition_Code" into pubcode,editioncode from edition_mast where "Edition_Alias"=l_ed AND ROWNUM<=1;
        
        dbms_output.put_line('Str:'||l_date||':'||l_ed||':'||l_hight||':'||l_width||':'||l_size);

        insert into tbl_booking_subedition_g(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,SRNO,NO_INSERT,PAGE_NO) 
        values(compcodem,cioidm,insertidm,pubcode,editioncode,l_date,l_hight,l_width,l_size,l_status,receiptnom,SUBEDI_S.NEXTVAL,insertno,l_pageno);
        -- insert into 
    end loop;
else

    dbms_output.put_line('lata');

    --INSERT INTO TEST1 VALUES('pubcodeMAIN',editioncodem);
    
    select "Pub_Code","City_Code","Edition_Type" into pubcode,editioncode,v_edtn_type 
        from edition_mast 
            where trim("Edition_Code")=trim(editioncodem) and rownum<=1;
    
    -- insert into abctest values(pubcode,editioncode);
    dbms_output.put_line(pubcode);
    dbms_output.put_line(editioncode);
    dbms_output.put_line(pkgcode);
    
    If v_edtn_type='Main Edition' then
        select "Combin_Desc" into combinname from combin_mast where "Combin_Code"=pkgcode;
        
        select UOM_DESC into uomdesc from uom_mast where "Uom_Code"=(select Uom_code from tbl_booking_mast_g 
            where cio_booking_id=cioidm);
        dbms_output.put_line(combinname);
        
        if instr(combinname,'+')<0 and uomdesc='CD' then
            --INSERT INTO TEST1 VALUES(pubcode,editioncode);COMMIT;
            
            insert into tbl_booking_subedition_g(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,SRNO,NO_INSERT,PAGE_NO)
            select compcodem,cioidm,insertidm,"Pub_Code","Edition_Code",insertdatem,heightm,widthm,totaream,'cancel',receiptnom,SUBEDI_S.NEXTVAL,insertno,pageno
            from edition_mast where  "Pub_Code"=pubcode and "City_Code"=editioncode and "Edition_Type"='Edition';
            
        else
            dbms_output.put_line('lata111');
            insert into tbl_booking_subedition_g(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,SRNO,NO_INSERT,PAGE_NO)
            select compcodem,cioidm,insertidm,"Pub_Code","Edition_Code",insertdatem,heightm,widthm,totaream,'booked',receiptnom,SUBEDI_S.NEXTVAL,insertno,pageno
            from edition_mast where  "Pub_Code"=pubcode and "City_Code"=editioncode and "Edition_Type"='Edition';
        end if;
    End if;           
end if;
    COMMIT;  
    exception when others then 
    p_error_text :=sqlerrm;       
END insert_edition_details;
/

//==================================************End*********************==================//

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 10/02/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 11/02/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//==============*********************Start Scripting****************==================//
ALTER PROCEDURE [dbo].[Editioncodecheck]

@EditionCode as varchar(8),
@compcode as varchar(8),
@userid as varchar(8),
@editionalias as varchar(50)

AS

declare @query varchar(900)

select Edition_Code from EDITION_MAST where Comp_Code=@compcode  and  Edition_Code=@EditionCode --and UserId='''+@userid+'''
select "Edition_Alias" from EDITION_MAST where Comp_Code=@compcode and Edition_Alias=@editionalias -- and "UserId"=userid
--print(@query)

--exec(@query)
//==================================************End*********************==================//


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 11/02/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@






































