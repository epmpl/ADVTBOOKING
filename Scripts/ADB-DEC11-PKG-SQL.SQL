/*======================================= ISSUE 0005907 (Kuldeep Bhati) ==============================*/


create procedure websp_getbranchadd
(
@pcompcode	varchar(50), 
@pbranchcode	varchar(50), 
@extra1	varchar(50)
)

as
select Add1,Phone1,Phone2,Fax from branch_mst where Comp_Code=@pcompcode and Branch_Code=@pbranchcode
/*======================================= End of ISSUE 0005907 (Kuldeep Bhati) ==============================*/

/*======================================= ISSUE 0005930 (Kuldeep Bhati) ==============================*/

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
(select premiumname from advpos_prem_mast where comp_code='''+@compcode+''' and Premiumcode=tbl_booking_mast.Page_prem) as PAGEPERM,APP_STATUS,booked_by,
(select top 1 Payment_Mode_Name from payment_mode_mast where Comp_Code='''+@compcode+''' and Pay_Mode_Code=tbl_booking_mast.Agency_pay) as "paymode"
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
(select premiumname from advpos_prem_mast where comp_code='''+@compcode+''' and Premiumcode=tbl_booking_mast.Page_prem) as PAGEPERM,APP_STATUS,booked_by,
(select top 1 Payment_Mode_Name from payment_mode_mast where Comp_Code='''+@compcode+''' and Pay_Mode_Code=tbl_booking_mast.Agency_pay) as "paymode"
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
(select premiumname from advpos_prem_mast where comp_code='''+@compcode+''' and Premiumcode=tbl_booking_mast.Page_prem) as PAGEPERM,APP_STATUS,booked_by,
(select top 1 Payment_Mode_Name from payment_mode_mast where Comp_Code='''+@compcode+''' and Pay_Mode_Code=tbl_booking_mast.Agency_pay) as "paymode"
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


/*======================================= End of ISSUE 0005930 (Kuldeep Bhati) ==============================*/
/////////////////////////////5893


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

/*======================================= end ==============================*/

/*======================================= ISSUE 0005566 (Kuldeep Bhati) ==============================*/

 ALTER procedure [dbo].[AD_GET_BRANCH_NAME](
       @compcode       as varchar(10),
       @branch_code       as varchar(10)
       
)
as
Begin


    select Branch_Name  from branch_mst where comp_code=@compcode and Branch_Code=@branch_code;

    --return isnull(@v_name,'Not Def');
end


/*======================================= ISSUE 0005566 (Kuldeep Bhati) ==============================*/

/*======================================= ISSUE 5879 mimoh mahajan ==============================*/
set QUOTED_IDENTIFIER ON
go

ALTER procedure [dbo].[bind_publ_name]
    @pcompcode		as  varchar(20),
    @ppubtype		as  varchar(20),
    @ppublcode		as  varchar(20),
    @pexrta1		as  varchar(200),
    @pexrta2		as  varchar(20)
as 
begin

    SELECT "Pub_Code" as "PUBL_CODE", "Pub_Name" as "PUBL_NAME" FROM pub_mast
        WHERE "Comp_Code" = @pcompcode and ("publication_type"=@ppubtype or @ppubtype is null or @ppubtype='') and
          ("Pub_Code"=@ppublcode or @ppublcode is null or @ppublcode='');
          
end

/*************************************************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER PROCEDURE  [dbo].[AD_RETAIN_ADD_COMM_TARGET_INS] (@PCOMP_CODE       AS VARCHAR(40),
												@PRETAIN_CODE     AS VARCHAR(40),
												@PPUBL_CODE       AS VARCHAR(40),
												@PNO_OF_PUBL      AS VARCHAR(40),
												@PADCOMM_PER      AS VARCHAR(40),
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





/*======================================= ISSUE 5879 mimoh mahajan ==============================*/


/*======================================= ISSUE 0005981 (Kuldeep Bhati) ==============================*/

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
(select premiumname from advpos_prem_mast where comp_code='''+@compcode+''' and Premiumcode=tbl_booking_mast.Page_prem) as PAGEPERM,APP_STATUS,booked_by,
(select top 1 Payment_Mode_Name from payment_mode_mast where Comp_Code='''+@compcode+''' and Pay_Mode_Code=tbl_booking_mast.Agency_pay) as "paymode",Receipt_no
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
(select premiumname from advpos_prem_mast where comp_code='''+@compcode+''' and Premiumcode=tbl_booking_mast.Page_prem) as PAGEPERM,APP_STATUS,booked_by,
(select top 1 Payment_Mode_Name from payment_mode_mast where Comp_Code='''+@compcode+''' and Pay_Mode_Code=tbl_booking_mast.Agency_pay) as "paymode",Receipt_no
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
(select premiumname from advpos_prem_mast where comp_code='''+@compcode+''' and Premiumcode=tbl_booking_mast.Page_prem) as PAGEPERM,APP_STATUS,booked_by,
(select top 1 Payment_Mode_Name from payment_mode_mast where Comp_Code='''+@compcode+''' and Pay_Mode_Code=tbl_booking_mast.Agency_pay) as "paymode",Receipt_no
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





/*======================================= End of ISSUE 0005981 (Kuldeep Bhati) ==============================*/



/***********************mimoh 14-dec-2011*********************************5933****************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



















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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE
           FROM PREFERRENCES
          WHERE comp_code = @compcode




























/**************************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





ALTER PROCEDURE   [dbo].[wesp_updatedate1]

@compcode as varchar(15),
@userid as varchar(15),
@dateformat as varchar(15),
@code as varchar(4),
@curr as varchar(8),
@ratecode as varchar(8),
@solo as varchar(15),
@breakup as varchar(2),
@bwcode as varchar(8),
@rostatus as varchar(2),
@filename as varchar(2),
@tfn as VARCHAR(4),
@insertbreak as varchar(2),
@prem as varchar(8),
@dealtype as varchar(2),
@pre as varchar(5),
@suff as varchar(5),
@financestatus as  char(2),
@voucherst as varchar(30),
@adcode as varchar(100),
@rodatetime as varchar(8),
@spacearea as varchar(8),
@vat as varchar(50),
@bookstat as varchar(25),
@cio_id as varchar(8),
@receipt_no as varchar(50),
@uom as varchar(8),
@bgcolor as varchar(10),
@validdate as varchar(10),
@agencyratecode as varchar(10),
@audit as varchar(8),
@book_insert_date as varchar(8),
@agencycomm as varchar(8),
@rateaudit as varchar(8),
@billaudit as varchar(8),
@billtype as varchar(8),
@invoice_no as varchar(50),
@copybooking as varchar(8),
@ratecompany as varchar(50),
@addagenycomm as varchar(50),
@agencycommlinkretainer as varchar(50),
@subeditionr as varchar(50),
@displaybilltype as varchar(50),
@classifiedbilltype as varchar(50),
@billformat as varchar(50),
@ratechk as varchar(50),
@allpkg as varchar(50),
@dayrate1 as varchar(50),
@schemetype as varchar(50),
@PIncludeclassi as varchar(50),
@receiptformat as varchar(50),
@cash_receipt as varchar(50),
@bill_orderwiselast as varchar(50),
@floor_chk as varchar(50),
@Unsoldflag as varchar(1),
@Supplystopper as varchar(10),
@drpRokeychk as varchar(1),
@Agencycomm_seq as varchar(1),
@creditreciept as varchar(1),
@cashindisplay as varchar(8),
@cashinclassified as varchar(8),
@rate_audit_pref as varchar(25),
@v_barcoding_allow as varchar(25),
@v_fmgbills AS VARCHAR(25),
@v_billed_cashdis as varchar(25),
@v_billed_cashcls as varchar(25),
@v_drpbackdate as varchar(25),
@dockitbooking as varchar(1),
@allowprevbooking as varchar(1),
@ro_wisecashbill as varchar(50),
@chkval as varchar(5),
@approval1 as varchar(50),
@pckstatus as varchar(3),
@cash_disc as varchar(1),
@cash_amt as varchar(10),
@seperate_cashier1 as varchar(10),
@disp_bill as varchar(1),
@clas_bill as varchar(1),
@mantimepost as varchar(1),
@bkdaypost as int,
@maxterutn as int,
@cir_return as varchar(1),
@noofchkbounc as int,
@noofdaychkrec as int,
@retday as int,
@chngsuppord as int,
@max_publishday as int,
@p_billno_period as varchar(15),
@spl_trans_edit as varchar(5),
@spl_dis_trans_editable as varchar(5),
@mul_pac_sel_trans as varchar(5),
@shmon_minword	as varchar(1),
@tradon_spcrg	as varchar(1),
@rateauth       as varchar(1),
@f2day as int,
@rateauditmodify as varchar(1),
@bindrevenuecenter as varchar(1),
@p_led_allow as varchar(2),
@p_clear_allow as varchar(2),
@repeatday as varchar(2),
@premiumedit as varchar(2),
@P_BILL_GENERATION as varchar(20),
@P_PUBLICATION_CENTER as varchar(50),
@P_allow_discount_prem as varchar(1),
@P_SCHEME_BILLING as varchar(50),
@P_ALLOW_PDC as varchar(50),
@PAD_TYPE_FOR_MANUL_BILL AS VARCHAR(20),
@RO_OUTSTAND_P AS VARCHAR(5),
@genrate_agency_code AS VARCHAR(5),
@p_dispauditbk AS VARCHAR(5),
@p_aotosupply  AS VARCHAR(5),
@p_Authorization as VARCHAR(1),
@p_CIR_AUTO_APPROVAL_UNSOLD AS VARCHAR(5),
@p_CIR_AUTO_PHYSICAL_UNSOLD AS VARCHAR(5),
@p_CIR_UNSOLD_INCLUDE_INCT AS VARCHAR(5),
@p_CIR_UNSOLD_INCLUDE_INSFEE AS VARCHAR(5),
@p_CIR_UNSOLD_ON_RECEIVED_DT AS VARCHAR(5),
@p_AGENCY_UNBLOCK_APPROVAL AS VARCHAR(5),
@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT AS VARCHAR(5),
@p_CIR_BILL_PUBLWISE AS VARCHAR(5)


AS
declare @query as varchar(8000)
declare @query1 as varchar(8000)
/*
set @query='update login set date_format='''+@dateformat+''' , Autogenerate='''+@code+''',curr_code='''+@curr+''' where com_code='''+@compcode+'''   '
exec(@query)

set @query1='update preferrences set RATE_COMPANY_AGENCY='''+@ratecompany+''',ADDITIONAL_AGENCY_COMM='''+@addagenycomm+''',
AGENCY_RETAINER_COMM='''+@agencycommlinkretainer+''',SUBEDITIONRATE='''+@subeditionr+''',DIS_BILLTYPE='''+@displaybilltype+''',
CLS_BILLTYPE='''+@classifiedbilltype+''',autogenerated='''+@code+''',currency_code='''+@curr+''' ,rate_gr_code='''+@ratecode+''' , 
date_format='''+@dateformat+''',solo='''+@solo+''',breakup='''+@breakup+''' ,blackwhitecode='''+@bwcode+''',  rostatus='''+@rostatus+''',
File_name='''+@filename+''',Tfn='''+@tfn+''',Insert_breakup='''+@insertbreak+''',Premium_type='''+@prem+''',Deal_type='''+@dealtype+'''  ,    
prefix='''+@pre+''', suffix='''+@suff+'''  ,     financestatus='''+ @financestatus+''' , voucherst='''+@voucherst+''',Ad_category='''+@adcode+''' ,
Ro_datetime='''+@rodatetime+''' ,Space_area='''+@spacearea+''',Vat='''+@vat+''' ,Booking_status='''+@bookstat+''' ,Cio_id='''+@cio_id+''',
Receipt_no='''+@receipt_no+''' ,uom_code='''+@uom+''',Bgcolor_publication='''+@bgcolor+''' ,chkfor_valid_pubdates='''+@validdate+''', 
Agency_ratecode='''+@agencyratecode+''',   audit='''+@audit+''', book_insert_date='''+@book_insert_date+''',agencycomm='''+@agencycomm+''',
rate_audit='''+@rateaudit+''',bill_audit='''+@billaudit+''', billtype='''+@billtype+''', invoice_no='''+@invoice_no+''' , 
copy_booking='''+@copybooking+''', BILLING_FORMAT='''+@billformat+''' , RATE_CHECK='''+@ratechk+''', ALL_PACKAGE='''+@allpkg+''',
DAYRATE='''+@dayrate1+''' ,SCHEME_TYPE='''+@schemetype+'''    ,DISP_CLSBILL='''+@PIncludeclassi+ '''  , RECEIPT_FORMAT ='''+@receiptformat+''',
CASH_RECEIPT_BILL='''+@cash_receipt+''', BILL_ORDERWSLAST='''+@bill_orderwiselast+''',FLOOR_CHK='''+@floor_chk+''' ,
Unsold_Entry_Flag='''+@Unsoldflag+''' ,Supply_Stop_Percentage='''+@Supplystopper+''',ROKEYCHECK='''+@drpRokeychk+''',
AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''',DISP_CASHBILL='''+@cashindisplay+''',
CLA_CASHBILL='''+@cashinclassified+''',RATE_AUDIT_PREF='''+@rate_audit_pref+''',BARCODING_ALLOWED='''+@v_barcoding_allow+''', 
FMG_BILL_DIS='''+@v_fmgbills+''',BILL_DISP_CASHBILL='''+@v_billed_cashdis +''',BILL_CLA_CASHBILL ='''+@v_billed_cashcls+''',
BACKDATERECEIPT='''+@v_drpbackdate+''',DOCKIT_BOOKING='''+@dockitbooking+''',Allowed_old_date='''+@allowprevbooking+''',
ROWISE_CASHBOOKING='''+@ro_wisecashbill+''' where    comp_code='''+@compcode+'''   ' 
*/
/*********************************************************************************************************/
UPDATE LOGIN SET date_format=@dateformat, Autogenerate=@code,curr_code=@curr WHERE COM_CODE=@compcode

UPDATE PREFERRENCES SET  autogenerated=@code,
currency_code=@curr ,
rate_gr_code=@ratecode,
date_format=@dateformat,solo=@solo,breakup=@breakup,
blackwhitecode=@bwcode,rostatus=@rostatus,File_name=@filename,Tfn=@tfn,
Insert_breakup=@insertbreak,Premium_type=@prem,Deal_type=@dealtype  ,
 prefix=@pre, suffix=@suff, financestatus=@financestatus , voucherst=@voucherst,
 Ad_category=@adcode ,Ro_datetime=@rodatetime ,Space_area=@spacearea,Vat=@vat,
 Booking_status=@bookstat,Cio_id=@cio_id,Receipt_no=@receipt_no,uom_code=@uom,
 Bgcolor_publication=@bgcolor ,chkfor_valid_pubdates=@validdate, Agency_ratecode=@agencyratecode,
  audit=@AUDIT,book_insert_date=@book_insert_date,agencycomm=@agencycomm,
  rate_audit=@rateaudit,bill_audit=@billaudit,billtype=@billtype,invoice_no=@invoice_no,
  copy_booking=@copybooking,RATE_COMPANY_AGENCY=@ratecompany, ADDITIONAL_AGENCY_COMM=@addagenycomm ,
  AGENCY_RETAINER_COMM=@agencycommlinkretainer,SUBEDITIONRATE=@subeditionr,
  CLS_BILLTYPE=@classifiedbilltype,DIS_BILLTYPE=@displaybilltype,BILLING_FORMAT=@billformat,
  RATE_CHECK=@ratechk,ALL_PACKAGE=@allpkg,dayrate=@dayrate1,SCHEME_TYPE=@schemetype,DISP_CLSBILL=@PIncludeclassi   ,
  CASH_RECEIPT_BILL=@cash_receipt, BILL_ORDERWSLAST=@bill_orderwiselast, FLOOR_CHK=@floor_chk ,
  Unsold_Entry_Flag=@Unsoldflag ,Supply_Stop_Percentage=@Supplystopper,ROKEYCHECK=@drpRokeychk ,
  AGENCYCOMM_SEQ_COM=@Agencycomm_seq ,CREDIT_RECIPT=@creditreciept,DISP_CASHBILL=@cashindisplay,
  CLA_CASHBILL=@cashinclassified,RATE_AUDIT_PREF=@rate_audit_pref,BARCODING_ALLOWED=@v_barcoding_allow,
  FMG_BILL_DIS =@v_fmgbills, BILL_DISP_CASHBILL=@v_billed_cashdis , BILL_CLA_CASHBILL=@v_billed_cashcls,BACKDATERECEIPT=@v_drpbackdate,DOCKIT_BOOKING=@dockitbooking,Allowed_old_date=@allowprevbooking,ROWISE_CASHBOOKING=@ro_wisecashbill,CUTOFFTIME=@chkval,APPROVAL=@approval1,back_days=@pckstatus,CASH_DISCOUNT=@cash_amt,CASH_DISCOUNTTYPE=@cash_disc,SEPRATE_CASHIER=@seperate_cashier1,
 CIR_MANY_TIME_POSTING=@mantimepost, CIR_BACKDAYS_POSTING=@bkdaypost, CIR_MAX_RETURN_ALLOW=@maxterutn, CIR_RETURN_LIMIT_ALLOW=@cir_return, CIR_NO_OF_CHQBOUNCE=@noofchkbounc, CIR_DAYS_CHQBOUNCE=@noofdaychkrec, CIR_RETURN_DAYS=@retday, CIR_SUP_ORDER_LIMIT=@chngsuppord, DISP_BILLING_CRITERIA=@disp_bill, CLSD_BILLING_CRITERIA=@clas_bill,MAX_PUBLISHDAYS=@max_publishday,
 BILLNO_PERIODICITY=@p_billno_period,SPECIALDISC_TRANS_EDIT=@spl_trans_edit, SHARING_TRANS=@spl_dis_trans_editable, MULTIPACKAGE_SEL_TRANS=@mul_pac_sel_trans,SCHEME_MINWORD=@shmon_minword, TRADE_SPLCHARGE=@tradon_spcrg,RATE_AUTHORIZATION=@rateauth
  ,F2_RECORD=@f2day,PUBLISHAD_EDIT_RATEAUDIT=@rateauditmodify,BINDREVENUE_CENTER=@bindrevenuecenter,
FA_LEDGER_ALLOW=@p_led_allow,CLEARANCE_TYPE_ALLOW=@p_clear_allow,REPEAT_DAY_TYPE=@repeatday,PREMIUM_EDIT=@premiumedit,

BILL_GENERATION_PRIOR=@P_BILL_GENERATION,PUBLICATION_HO=@P_PUBLICATION_CENTER,

SPLDISC_ALLOWPREM=@P_allow_discount_prem,BILL_SCHEME=@P_SCHEME_BILLING,

ALLOWED_PDC_DAYS_RECEIPT=@P_ALLOW_PDC,AD_TYPE_MANUL_BILL=@PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=@RO_OUTSTAND_P,GENRATE_CIR_AGCD=@genrate_agency_code,DISP_AUDITBKG=@p_dispauditbk,CIR_DIS_AUTO_POSTING=@p_aotosupply,RELAUTHREQON=@p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=@p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=@p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=@p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=@p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=@p_CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL=@p_AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE=@p_CIR_BILL_PUBLWISE
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)











/***********************mimoh 14-dec-2011*********************************5933****************/


/*======================================= ISSUE 0005830,0005941 (Kuldeep Bhati) ==============================*/
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[Schedulereport1]    Script Date: 12/15/2011 17:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Schedulereport1] (
	@fromdate                VARCHAR(50) ,
	@dateto                  VARCHAR(50) ,
	@compcode                VARCHAR(50) ,
	@pub_name                VARCHAR(50) ,
	@pub_cent                VARCHAR(50) ,
	@dateformat              VARCHAR(50) ,
	@descid                  VARCHAR(50)                    = null ,
	@ascdesc                 VARCHAR(50)                    = null ,
	@adtyp                   VARCHAR(4000) ,
	@adcatg                  VARCHAR(4000) ,
	@edition_name            VARCHAR(50) ,
	@drpstatus               VARCHAR(50) ,
	@supplement_name         VARCHAR(50),
	@packagecode 	 varchar(50),
	@editiondtl 	 varchar(50),
@puserid	 varchar(50),
@chk_access  varchar(2),
@p_branch  varchar(50)	) 
	
AS 
	CREATE TABLE #MULTIPACK_RAT(CIOID VARCHAR(500),RAT VARCHAR(500),PER_AMT numeric(12,2)) 
	--CREATE TABLE #MULTIPACK_RATNEW (CIOID VARCHAR(500),RAT VARCHAR(500),PER_AMT numeric(12,2))
	CREATE TABLE #MULTIPACK_REP(CIOID  VARCHAR(500),PACK  VARCHAR(500))
	CREATE TABLE #MULTIPAGE_BREK(TOT  int,PACK  VARCHAR(500))
	
	BEGIN
		SET NOCOUNT ON  
		DECLARE @query1       VARCHAR(8000) 
		
		DECLARE @v_gau        FLOAT                           
		SET @v_gau = 17 
		DECLARE @v_val        NUMERIC(4) 
		DECLARE @vs_gau       NUMERIC(4) 

		
		DECLARE p1 Cursor LOCAL FOR 
		SELECT  TBL_BOOKING_INSERT.Edition as "edition", COUNT(*) as "tot"
		FROM  TBL_BOOKING_MAST, TBL_BOOKING_INSERT, AGENCY_MAST, COL_MAST, UOM_MAST 
		WHERE	TBL_BOOKING_MAST.Comp_code  = @compcode
		 AND	TBL_BOOKING_MAST.cio_booking_id  = TBL_BOOKING_INSERT.Cio_Booking_Id
		 AND	TBL_BOOKING_MAST.Agency_sub_code  = AGENCY_MAST.code_subcode
		 AND	TBL_BOOKING_insert.Col_Code  = COL_MAST.Col_Code
		 AND	UOM_MAST.Uom_Code  = TBL_BOOKING_MAST.Uom_code
		 AND	TBL_BOOKING_INSERT.Insert_Date  BETWEEN @fromdate  AND  @dateto
		 AND	(TBL_BOOKING_INSERT.Insert_Status  != @drpstatus OR	@drpstatus is null)
		 AND (TBL_BOOKING_INSERT.Publication_Code  = @pub_name OR @pub_name  is null)
		 AND (TBL_BOOKING_INSERT.Pub_Cent_Code = @pub_cent OR @pub_cent  is null)
		 AND (TBL_BOOKING_MAST.Ad_type_code  = @Adtyp OR @Adtyp  is null)
		 AND (tbl_booking_insert.Ad_Cat= @adcatg OR @adcatg  is null)
		 AND (TBL_BOOKING_INSERT.Edition_Code  = @edition_name  OR	@edition_name  is null)
		 AND (TBL_BOOKING_insert.Supp_Code  = @supplement_name  OR	@supplement_name  is null)
		 AND (TBL_BOOKING_mast."branch"  = @p_branch  OR	@p_branch  is null)
		and   (@packagecode in (tbl_booking_mast.Package_code) or @packagecode is null)
and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access='1')
or  (@chk_access='0') )
and tbl_booking_mast.cio_booking_id not in (select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)					
		GROUP BY  TBL_BOOKING_INSERT.Edition 
		ORDER BY TBL_BOOKING_INSERT.Edition 
		
		DECLARE @g1_edition  VARCHAR(200) 
		declare @g1_tot varchar(200)

		DECLARE C1 Cursor LOCAL FOR 
		SELECT DISTINCT TBL_BOOKING_INSERT.Cio_Booking_Id AS "CIOID", TBL_BOOKING_MAST.Package_code as package_code,
		TBL_BOOKING_mast.Gross_amount as Crate
		FROM  TBL_BOOKING_MAST, TBL_BOOKING_INSERT 
		WHERE TBL_BOOKING_MAST.Comp_code=@compcode AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
		AND TBL_BOOKING_INSERT.Insert_Date BETWEEN @fromdate AND @dateto
		AND (TBL_BOOKING_INSERT.Publication_Code=@pub_name or @pub_name is null)
		AND (TBL_BOOKING_INSERT.Pub_Cent_Code=@pub_cent or @pub_cent is null)
		AND (TBL_BOOKING_MAST.Ad_type_code=@Adtyp or @Adtyp is null)
		AND (tbl_booking_insert.Ad_Cat=@adcatg or @adcatg is null)
		AND (TBL_BOOKING_INSERT.Edition_Code=@edition_name or @edition_name is null)
		AND (TBL_BOOKING_insert.Supp_Code =@supplement_name or @supplement_name is null)
		AND (TBL_BOOKING_mast."branch"  = @p_branch  OR	@p_branch  is null)
		and   (@packagecode in (tbl_booking_mast.Package_code) or @packagecode is null)
and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access='1')
or  (@chk_access='0') )
and tbl_booking_mast.cio_booking_id not in (select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)					

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
		SELECT @count = 1 
		fetch NEXT FROM p1 INTO @g1_edition,@g1_tot
		WHILE (@@FETCH_STATUS != -1) 
		BEGIN
			
			insert into #multipage_brek SELECT  * from dbo.multipage_brek(@g1_edition, @g1_tot, @v_gau) --@vs_gau  =			
			SELECT @count=@count +1
			fetch NEXT FROM p1 INTO @g1_edition,@g1_tot
		END 		
		close p1
  
		delete from #MULTIPACK_REP	
		delete from #MULTIPACK_RAT
		OPEN c1 
		SELECT @count = 1 
		fetch NEXT FROM c1 INTO @v1_cioid,@v1_package_code,@v1_crate
		WHILE (@@FETCH_STATUS != -1) 
		BEGIN 
			--exec multipack_report @v1_cioid, @v1_package_code, @v1_crate, '1'
			insert into #MULTIPACK_REP select * from dbo.multipack_report1(@v1_cioid, @v1_package_code, @v1_crate, '1')
			insert into #MULTIPACK_RAT select * from dbo.multipack_report3(@v1_cioid, @v1_package_code, @v1_crate, '1')
			OPEN C2 
			SELECT @count = 1 
			fetch NEXT FROM C2 INTO	@v_edition
			WHILE (@@FETCH_STATUS != -1) 
			BEGIN 
				IF @v_edipkg is null 
				BEGIN 
					SELECT @v_edipkg  = @v_edition 
				END
				ELSE
				BEGIN 
					SELECT @v_edipkg  = @v_edipkg + ',' + @v_edition 
				END
   
				SELECT @count=@count +1
				fetch NEXT FROM C2 INTO	@v_edition
			END
			close C2
			
			SELECT @v_edition  = null 
			SELECT @v_edipkg  = null 
			SELECT @count=@count +1	
			fetch NEXT FROM c1 INTO @v1_cioid,@v1_package_code,@v1_crate
		end	
		close c1		
			

		---------------------- Changes done by gaurav 14 june 10-------------------------------------------
		if (@packagecode is null or @editiondtl ='1')	
		begin
print('1')
					IF ( @drpstatus = 'includecancel'  or @drpstatus ='includehold') 
					BEGIN 
								print('2')
											
		
								SELECT @query1  = 'SELECT TBL_BOOKING_MAST.cio_booking_id AS "CIOID", AGENCY_MAST.Agency_Name AS "Agency", 
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
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT"
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
					ELSE
					BEGIN 
								print ('3')

								SELECT @query1  = 'SELECT TBL_BOOKING_MAST.cio_booking_id AS "CIOID", AGENCY_MAST.Agency_Name AS "Agency", 
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
								,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT"
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
		else					
		begin
		print('4')
					IF ( @drpstatus = 'includecancel'  or @drpstatus ='includehold') 
					BEGIN 				
						print ('5')
						SELECT @query1  = 'SELECT distinct TBL_BOOKING_MAST.cio_booking_id AS "CIOID", AGENCY_MAST.Agency_Name AS "Agency", 
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
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT"
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
					ELSE
					BEGIN 
						print('7')			
						SELECT @query1 = 'SELECT distinct TBL_BOOKING_MAST.cio_booking_id AS "CIOID", AGENCY_MAST.Agency_Name AS "Agency", 
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
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT"
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

		IF ( @fromdate IS NOT NULL AND @dateto IS NOT NULL ) 
		BEGIN 

			SELECT @query1  = @query1 + ' AND TBL_BOOKING_INSERT.Insert_Date BETWEEN ''' + @fromdate + ''' AND''' + @dateto + '''' 
		END
   
		IF ( @pub_name IS NOT NULL ) 
		BEGIN 
			SELECT @query1  = @query1 + ' AND TBL_BOOKING_INSERT.Publication_Code=''' + @pub_name + '''' 
		END

		IF ( @p_branch IS NOT NULL ) 
		BEGIN 
			SELECT @query1  = @query1 + ' AND TBL_BOOKING_mast.branch=''' + @p_branch + '''' 
		END

		IF ( @pub_cent IS NOT NULL ) 
		BEGIN 
			SELECT @query1  = @query1 + '  AND TBL_BOOKING_INSERT.Pub_Cent_Code=''' + @pub_cent + '''' 
		END
   
		IF ( @adtyp IS NOT NULL ) 
		BEGIN 
			SELECT @query1  = @query1 + 'AND TBL_BOOKING_MAST.Ad_type_code=''' + @adtyp + '''' 
		END
   
		IF ( @adcatg IS NOT NULL ) 
		BEGIN 
			SELECT @query1  = @query1 + 'AND  tbl_booking_insert.Ad_Cat in (''' + @adcatg + ''' )' 
		END
   
		IF ( @edition_name IS NOT NULL ) 
		BEGIN 
			SELECT @query1  = @query1 + '  AND TBL_BOOKING_INSERT.Edition_Code=''' + @edition_name + '''' 
		END
   
		IF ( @supplement_name IS NOT NULL ) 
		BEGIN 
			SELECT @query1  = @query1 + 'AND (TBL_BOOKING_insert.Supp_Code =''' + @supplement_name + ''' )' 
		END
		IF(@packagecode IS NOT NULL )
		begin
			select @query1=@query1+' AND ('''+@packagecode+''' in (tbl_booking_mast.Package_code) )'
		END 
   		
		if(@packagecode is null)
		begin
			IF ( @descid IS NOT NULL ) 
			BEGIN 
				SELECT @query1  = @query1 + '  order by "' + @descid + '"' 
								if(@descid='edition')begin
								SELECT @query1  = @query1 + '' + @ascdesc + '' + '  '
								end
								else
								begin
								SELECT @query1  = @query1 + '' + @ascdesc + '' + ' ,TBL_BOOKING_INSERT.Edition '
								end
			END
			ELSE
			BEGIN 
				SELECT @query1  = @query1 + ' order by TBL_BOOKING_INSERT.Edition' 
			END
		end
		else
		begin
			IF ( @descid IS NOT NULL ) 
			BEGIN 
				SELECT @query1  = @query1 + '  order by "' + @descid + '"'
				SELECT @query1  = @query1 + '' + @ascdesc + '' 
			END
			ELSE
			BEGIN 
				SELECT @query1  = @query1 + 'order by TBL_BOOKING_MAST.cio_booking_id ' 
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

/*======================================= End of ISSUE 0005830,0005941 (Kuldeep Bhati) ==============================*/
///////////////////////////////change add by garima




set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go















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
@resourceno_p as varchar(50)
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
update tbl_booking_insert set Edition=@edition,Insert_date=@insertdate,Col_code=@colid,Height=@height,Width=@width,Size_book=@totalsize,Page_post=@pagepost,Premium1=@premium1,Prem_per1=@premper1,Premium2=@premium2,Prem_per2=@premper2,Premium_allow=@premallow,Ad_cat=@adcategory,Ad_sub_cat=@adsubcat,Latest_by=@latestdate,Status_material=@material,File_name=@matfilename,Card_rate=@cardrate,Disc_rate=@discrate,Insert_status=@insertstatus,Bill_status=@billstatus,comp_code=@compcode,Userid=@userid,Repeating_date=@repeat,no_insert=@insertno,Edition_code=@edi,Publication_code=@publi,Pub_cent_code=@pub_cent,Supp_code=@supp,Pai_free_ins=@paid,Agreed_rate=@agrrate,Solo_rate=@solorate,Gross_rate=@grossrate,Page_no=@insert_pageno,Remarks=@insert_remarks,Page_prem=@page_code,page_per=@page_per,No_ofcolumn=@noofcol,Bill_Amt=@billamt,Bill_rate=@billrate,Logo_H=@logo_h,Logo_W=@logo_w,Logo_name=@logo_name,AD_SUBCAT3=@ad_cat_3,AD_SUBCAT4=@ad_cat_4,AD_SUBCAT5=@ad_cat_5,PACKAGE_CODE=@pkgcode,INSERTS=@gridins,PKG_ALIAS=@pkgalias ,SPECIAL_SIZE1=@splboldsizevalue,VATAMT=@vatrate_p,BOXCHARGE=@boxcharge_p, VAT_INC=@vat_inc_p,LOCALGROSSAMT =@grossamtlocal_p,LOCALBILLAMT = @billamtlocal_p,sectioncode=@sectioncode_p,RESOURCE_NO=@resourceno_p
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
insert into tbl_booking_insert_g(cio_booking_id,Edition,Insert_date,Col_code,Height,Width,Size_book,Page_post,Premium1,Prem_per1,Premium2,Prem_per2,Premium_allow,Ad_cat,Ad_sub_cat,Latest_by,Status_material,File_name,Card_rate,Disc_rate,Insert_status,Bill_status,comp_code,Userid,Repeating_date,no_insert,Edition_code,Publication_code,Pub_cent_code,Supp_code,Pai_free_ins,Agreed_rate,Solo_rate,Gross_rate,Page_no,Remarks,Page_prem,page_per,No_ofcolumn,Bill_Amt,Bill_rate,Logo_H,Logo_W,Logo_name,AD_SUBCAT3,AD_SUBCAT4,AD_SUBCAT5,PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE,RESOURCE_NO)
values(@cioid,@edition,@insertdate,@colid,@height,@width,@totalsize,@pagepost,@premium1,@premper1,@premium2,@premper2,@premallow,@adcategory,@adsubcat,@latestdate,@material,@matfilename,@cardrate,@discrate,@insertstatus,@billstatus,@compcode,@userid,@repeat,@insertno,@edi,@publi,@pub_cent,@supp,@paid,@agrrate,@solorate,@grossrate,@insert_pageno,@insert_remarks,@page_code,@page_per,@noofcol,@billamt,@billrate,@logo_h,@logo_w,@logo_name,@ad_cat_3,@ad_cat_4,@ad_cat_5, @pkgcode,@gridins,@pkgalias,@splboldsizevalue,@vatrate_p,@boxcharge_p,@vat_inc_p,@grossamtlocal_p,@billamtlocal_p,@sectioncode_p,@resourceno_p)
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
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE)
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
           ,[LOCKSTATUS],SPECIAL_SIZE1,vatamt,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=@cioid
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

/******************************************************End of Issue****************************************/
/*======================================= ISSUE 0005968 (Kuldeep Bhati) ==============================*/

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
@p_raterevise as varchar(5)
--@bank as varchar(30),
--@validitydate as DATETIME




AS

--insert into Agency_mast(Comp_Code,Agency_Type_Code,Agency_Cat_Code,Agency_SubCat_Code,Agency_Code,Agency_Name,Agency_Alias,Agency_HO,Add1,Street,City_Code,Zip,Dist_Code,State_Code,Country_Code,Phone,Fax,EmailID,URL,Buss_Start_Date,Enroll_Date,MRV_Ref_No,No_of_VTS,Credit_Days ,PAN_No,TAN_No,ST_ACC_No,Pay_Mode_Code,Agency_Status,Status_Reason,Remarks,UserID,Creation_Datetime,SUB_Agency_HO,SUB_Agency_Code,BILL_TO,ALERT,CREDIT_LIMIT,CODE,representative_code,pin_code) values (@compcode,@agencytype,@agentcategory,@agentcategory2,@agentcode,@agentname,@alias,@agencyho,@address,@street,@city,@zip,@district,@state,@country,@phone,@mail,@fax,@url,@bussinessstartdate,@enrolldate,@mrerefferenceno,@novts,@credit,@pan,@tan,@stacno,@paymode,@statusdrp,@status,@remarks,@userid,@statusdate,@subagencyho,@agencycode,@billto,@alert ,@creditlimit,@code,@representative,@pin)
insert into Agency_mast(Comp_Code,Agency_Type_Code,Agency_Cat_Code,Agency_SubCat_Code,Agency_Code,Agency_Name,Agency_Alias,Agency_HO,Add1,     Street,City_Code,Dist_Code,State_Code,Country_Code,Phone,Fax,EmailID,URL,Buss_Start_Date,     Enroll_Date,MRV_Ref_No,      No_of_VTS,Credit_Days ,PAN_No,TAN_No,ST_ACC_No,Pay_Mode_Code,Status_Reason,Remarks, UserID, SUB_Agency_HO,SUB_Agency_Code,acagency,ALERT, CREDIT_LIMIT, CODE, representative_code,pin_code,region, type, code_subcode,          zone_code,Add2,     Add3,     CREDIT_TYPE,BILL_TO,fax1,    Rate_Group, qbc_userid,TALUKA,   zip,Branch_code,DISTRICT,    STATE,      BILL_FREQUENCY,OLD_AGENCY,BOOKING_TYPE,VAT,RATE_REVISE) values 
						(@compcode,@agencytype,    @agentcategory, @agentcategory2,   @agentcode, @agentname, @alias,      @agencyho,@address,@street,@city,    @district,@state,    @country,    @phone,@fax,@mail,@url,@bussinessstartdate,@enrolldate,@mrerefferenceno,@novts,   @credit,     @pan,  @tan,  @stacno,  @paymode,     @status,      @remarks,@userid,@subagencyho, @agencycode,    @acagen, @alert ,@creditlimit,@code,@representative,    @pin,    @region,@type,@agentcode+@agencycode,@zone,    @address1,@address2,@curtype,   @billto,@txtfax1,@rategrp,   @qbcuserid, @taluka,@zip,@branchcode,@hddistcode,@hdstatecode,@billf,        @oldagency,@booktype,   @vat,@p_raterevise)

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
@p_raterevise as varchar(5)


AS
declare @query as varchar(2000)
declare @query1 as varchar(2000)

update Agency_mast set Rate_Group=@rategrp, Agency_Code=@agentcode , fax1=@txtfax2,CREDIT_TYPE=@curtype, zone_code=@zone,  type=@type, Agency_Type_Code=@agencytype,Agency_Cat_Code=@agentcategory,Agency_SubCat_Code=@agentcategory2,Agency_Name=@agentname,Agency_Alias=@alias,Agency_HO=@agencyho,Add1=@address,Street=@street,City_Code=@city,Zip=@zip,Dist_Code=@district,State_Code=@state,Country_Code=@country,Phone=@phone,Fax=@fax,EmailID=@mail,URL=@url,Buss_Start_Date=@bussinessstartdate,Enroll_Date=@enrolldate ,MRV_Ref_No=@mrerefferenceno,No_of_VTS=@novts,Credit_Days=@credit,PAN_No=@pan,TAN_No=@tan,ST_ACC_No=@stacno1,Pay_Mode_Code=@paymode,Status_Reason=@status,Remarks=@remarks,SUB_Agency_HO=@subagencyho,SUB_Agency_Code=@agencycode ,BILL_TO =@acagen, acagency=@billto,ALERT=@alert,credit_limit=@creditlimit,code=@code ,region=@region,representative_code=@representative,pin_code=@pincode,Add2=@address1,Add3=@address2,qbc_userid=@qbcuserid , TALUKA=@taluka , Branch_code=@branchcode, DISTRICT=@hddistcode,STATE=@hdstatecode,BILL_FREQUENCY=@billf,OLD_AGENCY=@oldagen,BOOKING_TYPE=@booktype,VAT=@vat,RATE_REVISE=@p_raterevise where Comp_Code=@compcode  AND  SUB_Agency_Code=@agencycode

print(@query)
exec(@query)
print(@query1)
exec(@query1)
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
                (select AGENCY_CODE from ad_user where ad_user.AGENCY_CODE=agency_mast.code_subcode) AS AGENCYCODE,TALUKA ,Branch_code,(select dist_mst.Dist_Name from dist_mst where dist_mst.Dist_Code=agency_mast.DISTRICT) as DISTRICT,(select state_mst.State_Name from state_mst where state_mst.State_Code=agency_mast.STATE) as STATE,BILL_FREQUENCY,OLD_AGENCY,BOOKING_TYPE,VAT,RATE_REVISE FROM AGENCY_MAST  where comp_code='''+@compcode+''' '

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

/*======================================= End of ISSUE 0005968 (Kuldeep Bhati) ==============================*/

/*======================================= ISSUE 0005972 ==============================*/



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
@p_QBC_AGENCY as varchar(20),
 @p_type as varchar(5),
@p_parent as varchar(8)
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
				CLIENT_TYPE= @p_CLIENT_TYPE,QBC_AGENCY=@p_QBC_AGENCY,"TYPE"=@p_type,PARENT_CLIENT=@p_parent 
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
                      Credit_limit, Rate_Gr_Code, Client_category,TALUKA,AGENCY_CODE,CLIENT_TYPE,QBC_AGENCY,"TYPE",PARENT_CLIENT
                     ) values(@compcode,@custcode,@custname,@custalias,@add1,@street,@citycode,@zip,@dist,@state,@country,@phone1,@phone2,@fax,@emailid,@url,@vats,@servicetax,@pan,@creditdays,@paymodecode,@fatchstatus,@statusreason,@alert,@userid,getdate(),@zone,@region,@crdlimit,@rategroup,@clientcat,@taluka,@agency_sav,
					 @p_CLIENT_TYPE,@p_QBC_AGENCY,@p_type,@p_parent)
			
						--insert into cust_mast
			/*This is added by Amit */
			/* This query is automatically added after data is addded on cust_mast table*/
			--insert into pay_mode_client(Comp_Code,Client_code,userid,creation_datetime) values(@compcode,@custcode,@userid,getdate()) 
			
		
		end

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
,Status_Reason,Remarks,UserId,Creation_Datetime,Zone_code,Region_code,Credit_limit,Rate_Gr_Code,  getdate() ,Client_category ,TALUKA,(select top 1 TO_DATE from status_detail_client where status_detail_client.cust_code=cust_mast.Cust_Code) as to_date,CLIENT_TYPE,QBC_AGENCY,TYPE,PARENT_CLIENT    from cust_mast where comp_code='''+@compcode+'''' 

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



/***************************************************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[Add_bindParentclient]
@compcode varchar(50),
@client varchar(50)
AS
select Cust_Code,Cust_Name,Add1 from cust_mast
 where comp_code=@compcode and cust_name like @client+'%' 
and (isnull(Cust_Status,'ACTIVE')='ACTIVE' or Cust_Status='' ) and (client_type='' or client_type is null or client_type='B')
and "TYPE"='P'order by Cust_Name


/******************************************************************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER FUNCTION [dbo].[ADD_GET_CLIENT_NAME]
(
	@pcomp_code                               VARCHAR(4000) ,
	@catcode                                  VARCHAR(4000) 
)
RETURNS VARCHAR(4000) 
AS 
	BEGIN
		
		DECLARE @v_cust_name                               VARCHAR(200) 

		DECLARE @adv_error INT

		SELECT @v_cust_name  =  Cust_Name
		FROM  cust_mast 
		WHERE	 Cust_Code=@catcode
		 AND	Comp_Code=@pcomp_code
		

		SELECT @adv_error = @@ERROR
		IF @adv_error != 0 
		BEGIN
			GOTO Exception2
		END

		GOTO ExitLabel2
		Exception2:
			  
			BEGIN
			
			SELECT @v_cust_name  = null 
			/* SwisSQL (Oracle To SQL Server) : Manual Intervention to verify Exception is required */
			END
		ExitLabel2:
		
		return ISNULL(@v_cust_name, '') 

	END

/*======================================= End of ISSUE 0005972 ==============================*/


/*================================21/dec/2011=======  ISSUE 0005940 ==============================*/
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












/*================================21/dec/2011=======  ISSUE 0005940 ==============================*/


/*================================21/dec/2011=======  ISSUE 0005951 ==============================*/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go






ALTER PROCEDURE   [dbo].[wesp_updatedate1]

@compcode as varchar(15),
@userid as varchar(15),
@dateformat as varchar(15),
@code as varchar(4),
@curr as varchar(8),
@ratecode as varchar(8),
@solo as varchar(15),
@breakup as varchar(2),
@bwcode as varchar(8),
@rostatus as varchar(2),
@filename as varchar(2),
@tfn as VARCHAR(4),
@insertbreak as varchar(2),
@prem as varchar(8),
@dealtype as varchar(2),
@pre as varchar(5),
@suff as varchar(5),
@financestatus as  char(2),
@voucherst as varchar(30),
@adcode as varchar(100),
@rodatetime as varchar(8),
@spacearea as varchar(8),
@vat as varchar(50),
@bookstat as varchar(25),
@cio_id as varchar(8),
@receipt_no as varchar(50),
@uom as varchar(8),
@bgcolor as varchar(10),
@validdate as varchar(10),
@agencyratecode as varchar(10),
@audit as varchar(8),
@book_insert_date as varchar(8),
@agencycomm as varchar(8),
@rateaudit as varchar(8),
@billaudit as varchar(8),
@billtype as varchar(8),
@invoice_no as varchar(50),
@copybooking as varchar(8),
@ratecompany as varchar(50),
@addagenycomm as varchar(50),
@agencycommlinkretainer as varchar(50),
@subeditionr as varchar(50),
@displaybilltype as varchar(50),
@classifiedbilltype as varchar(50),
@billformat as varchar(50),
@ratechk as varchar(50),
@allpkg as varchar(50),
@dayrate1 as varchar(50),
@schemetype as varchar(50),
@PIncludeclassi as varchar(50),
@receiptformat as varchar(50),
@cash_receipt as varchar(50),
@bill_orderwiselast as varchar(50),
@floor_chk as varchar(50),
@Unsoldflag as varchar(1),
@Supplystopper as varchar(10),
@drpRokeychk as varchar(1),
@Agencycomm_seq as varchar(1),
@creditreciept as varchar(1),
@cashindisplay as varchar(8),
@cashinclassified as varchar(8),
@rate_audit_pref as varchar(25),
@v_barcoding_allow as varchar(25),
@v_fmgbills AS VARCHAR(25),
@v_billed_cashdis as varchar(25),
@v_billed_cashcls as varchar(25),
@v_drpbackdate as varchar(25),
@dockitbooking as varchar(1),
@allowprevbooking as varchar(1),
@ro_wisecashbill as varchar(50),
@chkval as varchar(5),
@approval1 as varchar(50),
@pckstatus as varchar(3),
@cash_disc as varchar(1),
@cash_amt as varchar(10),
@seperate_cashier1 as varchar(10),
@disp_bill as varchar(1),
@clas_bill as varchar(1),
@mantimepost as varchar(1),
@bkdaypost as int,
@maxterutn as int,
@cir_return as varchar(1),
@noofchkbounc as int,
@noofdaychkrec as int,
@retday as int,
@chngsuppord as int,
@max_publishday as int,
@p_billno_period as varchar(15),
@spl_trans_edit as varchar(5),
@spl_dis_trans_editable as varchar(5),
@mul_pac_sel_trans as varchar(5),
@shmon_minword	as varchar(1),
@tradon_spcrg	as varchar(1),
@rateauth       as varchar(1),
@f2day as int,
@rateauditmodify as varchar(1),
@bindrevenuecenter as varchar(1),
@p_led_allow as varchar(2),
@p_clear_allow as varchar(2),
@repeatday as varchar(2),
@premiumedit as varchar(2),
@P_BILL_GENERATION as varchar(20),
@P_PUBLICATION_CENTER as varchar(50),
@P_allow_discount_prem as varchar(1),
@P_SCHEME_BILLING as varchar(50),
@P_ALLOW_PDC as varchar(50),
@PAD_TYPE_FOR_MANUL_BILL AS VARCHAR(20),
@RO_OUTSTAND_P AS VARCHAR(5),
@genrate_agency_code AS VARCHAR(5),
@p_dispauditbk AS VARCHAR(5),
@p_aotosupply  AS VARCHAR(5),
@p_Authorization as VARCHAR(1),
@p_CIR_AUTO_APPROVAL_UNSOLD AS VARCHAR(5),
@p_CIR_AUTO_PHYSICAL_UNSOLD AS VARCHAR(5),
@p_CIR_UNSOLD_INCLUDE_INCT AS VARCHAR(5),
@p_CIR_UNSOLD_INCLUDE_INSFEE AS VARCHAR(5),
@p_CIR_UNSOLD_ON_RECEIVED_DT AS VARCHAR(5),
@p_AGENCY_UNBLOCK_APPROVAL AS VARCHAR(5),
@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT AS VARCHAR(5),
@p_CIR_BILL_PUBLWISE AS VARCHAR(5),
@paging         AS VARCHAR(4000) ,
@print          AS VARCHAR(4000) ,
@allowpage      AS VARCHAR(4000) ,
@agency_req     AS VARCHAR(4000) ,
@region_req     AS VARCHAR(4000) 


AS
declare @query as varchar(8000)
declare @query1 as varchar(8000)
/*
set @query='update login set date_format='''+@dateformat+''' , Autogenerate='''+@code+''',curr_code='''+@curr+''' where com_code='''+@compcode+'''   '
exec(@query)

set @query1='update preferrences set RATE_COMPANY_AGENCY='''+@ratecompany+''',ADDITIONAL_AGENCY_COMM='''+@addagenycomm+''',
AGENCY_RETAINER_COMM='''+@agencycommlinkretainer+''',SUBEDITIONRATE='''+@subeditionr+''',DIS_BILLTYPE='''+@displaybilltype+''',
CLS_BILLTYPE='''+@classifiedbilltype+''',autogenerated='''+@code+''',currency_code='''+@curr+''' ,rate_gr_code='''+@ratecode+''' , 
date_format='''+@dateformat+''',solo='''+@solo+''',breakup='''+@breakup+''' ,blackwhitecode='''+@bwcode+''',  rostatus='''+@rostatus+''',
File_name='''+@filename+''',Tfn='''+@tfn+''',Insert_breakup='''+@insertbreak+''',Premium_type='''+@prem+''',Deal_type='''+@dealtype+'''  ,    
prefix='''+@pre+''', suffix='''+@suff+'''  ,     financestatus='''+ @financestatus+''' , voucherst='''+@voucherst+''',Ad_category='''+@adcode+''' ,
Ro_datetime='''+@rodatetime+''' ,Space_area='''+@spacearea+''',Vat='''+@vat+''' ,Booking_status='''+@bookstat+''' ,Cio_id='''+@cio_id+''',
Receipt_no='''+@receipt_no+''' ,uom_code='''+@uom+''',Bgcolor_publication='''+@bgcolor+''' ,chkfor_valid_pubdates='''+@validdate+''', 
Agency_ratecode='''+@agencyratecode+''',   audit='''+@audit+''', book_insert_date='''+@book_insert_date+''',agencycomm='''+@agencycomm+''',
rate_audit='''+@rateaudit+''',bill_audit='''+@billaudit+''', billtype='''+@billtype+''', invoice_no='''+@invoice_no+''' , 
copy_booking='''+@copybooking+''', BILLING_FORMAT='''+@billformat+''' , RATE_CHECK='''+@ratechk+''', ALL_PACKAGE='''+@allpkg+''',
DAYRATE='''+@dayrate1+''' ,SCHEME_TYPE='''+@schemetype+'''    ,DISP_CLSBILL='''+@PIncludeclassi+ '''  , RECEIPT_FORMAT ='''+@receiptformat+''',
CASH_RECEIPT_BILL='''+@cash_receipt+''', BILL_ORDERWSLAST='''+@bill_orderwiselast+''',FLOOR_CHK='''+@floor_chk+''' ,
Unsold_Entry_Flag='''+@Unsoldflag+''' ,Supply_Stop_Percentage='''+@Supplystopper+''',ROKEYCHECK='''+@drpRokeychk+''',
AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''',DISP_CASHBILL='''+@cashindisplay+''',
CLA_CASHBILL='''+@cashinclassified+''',RATE_AUDIT_PREF='''+@rate_audit_pref+''',BARCODING_ALLOWED='''+@v_barcoding_allow+''', 
FMG_BILL_DIS='''+@v_fmgbills+''',BILL_DISP_CASHBILL='''+@v_billed_cashdis +''',BILL_CLA_CASHBILL ='''+@v_billed_cashcls+''',
BACKDATERECEIPT='''+@v_drpbackdate+''',DOCKIT_BOOKING='''+@dockitbooking+''',Allowed_old_date='''+@allowprevbooking+''',
ROWISE_CASHBOOKING='''+@ro_wisecashbill+''' where    comp_code='''+@compcode+'''   ' 
*/
/*********************************************************************************************************/
UPDATE LOGIN SET date_format=@dateformat, Autogenerate=@code,curr_code=@curr WHERE COM_CODE=@compcode

UPDATE PREFERRENCES SET  autogenerated=@code,
currency_code=@curr ,
rate_gr_code=@ratecode,
date_format=@dateformat,solo=@solo,breakup=@breakup,
blackwhitecode=@bwcode,rostatus=@rostatus,File_name=@filename,Tfn=@tfn,
Insert_breakup=@insertbreak,Premium_type=@prem,Deal_type=@dealtype  ,
 prefix=@pre, suffix=@suff, financestatus=@financestatus , voucherst=@voucherst,
 Ad_category=@adcode ,Ro_datetime=@rodatetime ,Space_area=@spacearea,Vat=@vat,
 Booking_status=@bookstat,Cio_id=@cio_id,Receipt_no=@receipt_no,uom_code=@uom,
 Bgcolor_publication=@bgcolor ,chkfor_valid_pubdates=@validdate, Agency_ratecode=@agencyratecode,
  audit=@AUDIT,book_insert_date=@book_insert_date,agencycomm=@agencycomm,
  rate_audit=@rateaudit,bill_audit=@billaudit,billtype=@billtype,invoice_no=@invoice_no,
  copy_booking=@copybooking,RATE_COMPANY_AGENCY=@ratecompany, ADDITIONAL_AGENCY_COMM=@addagenycomm ,
  AGENCY_RETAINER_COMM=@agencycommlinkretainer,SUBEDITIONRATE=@subeditionr,
  CLS_BILLTYPE=@classifiedbilltype,DIS_BILLTYPE=@displaybilltype,BILLING_FORMAT=@billformat,
  RATE_CHECK=@ratechk,ALL_PACKAGE=@allpkg,dayrate=@dayrate1,SCHEME_TYPE=@schemetype,DISP_CLSBILL=@PIncludeclassi   ,
  CASH_RECEIPT_BILL=@cash_receipt, BILL_ORDERWSLAST=@bill_orderwiselast, FLOOR_CHK=@floor_chk ,
  Unsold_Entry_Flag=@Unsoldflag ,Supply_Stop_Percentage=@Supplystopper,ROKEYCHECK=@drpRokeychk ,
  AGENCYCOMM_SEQ_COM=@Agencycomm_seq ,CREDIT_RECIPT=@creditreciept,DISP_CASHBILL=@cashindisplay,
  CLA_CASHBILL=@cashinclassified,RATE_AUDIT_PREF=@rate_audit_pref,BARCODING_ALLOWED=@v_barcoding_allow,
  FMG_BILL_DIS =@v_fmgbills, BILL_DISP_CASHBILL=@v_billed_cashdis , BILL_CLA_CASHBILL=@v_billed_cashcls,BACKDATERECEIPT=@v_drpbackdate,DOCKIT_BOOKING=@dockitbooking,Allowed_old_date=@allowprevbooking,ROWISE_CASHBOOKING=@ro_wisecashbill,CUTOFFTIME=@chkval,APPROVAL=@approval1,back_days=@pckstatus,CASH_DISCOUNT=@cash_amt,CASH_DISCOUNTTYPE=@cash_disc,SEPRATE_CASHIER=@seperate_cashier1,
 CIR_MANY_TIME_POSTING=@mantimepost, CIR_BACKDAYS_POSTING=@bkdaypost, CIR_MAX_RETURN_ALLOW=@maxterutn, CIR_RETURN_LIMIT_ALLOW=@cir_return, CIR_NO_OF_CHQBOUNCE=@noofchkbounc, CIR_DAYS_CHQBOUNCE=@noofdaychkrec, CIR_RETURN_DAYS=@retday, CIR_SUP_ORDER_LIMIT=@chngsuppord, DISP_BILLING_CRITERIA=@disp_bill, CLSD_BILLING_CRITERIA=@clas_bill,MAX_PUBLISHDAYS=@max_publishday,
 BILLNO_PERIODICITY=@p_billno_period,SPECIALDISC_TRANS_EDIT=@spl_trans_edit, SHARING_TRANS=@spl_dis_trans_editable, MULTIPACKAGE_SEL_TRANS=@mul_pac_sel_trans,SCHEME_MINWORD=@shmon_minword, TRADE_SPLCHARGE=@tradon_spcrg,RATE_AUTHORIZATION=@rateauth
  ,F2_RECORD=@f2day,PUBLISHAD_EDIT_RATEAUDIT=@rateauditmodify,BINDREVENUE_CENTER=@bindrevenuecenter,
FA_LEDGER_ALLOW=@p_led_allow,CLEARANCE_TYPE_ALLOW=@p_clear_allow,REPEAT_DAY_TYPE=@repeatday,PREMIUM_EDIT=@premiumedit,

BILL_GENERATION_PRIOR=@P_BILL_GENERATION,PUBLICATION_HO=@P_PUBLICATION_CENTER,

SPLDISC_ALLOWPREM=@P_allow_discount_prem,BILL_SCHEME=@P_SCHEME_BILLING,

ALLOWED_PDC_DAYS_RECEIPT=@P_ALLOW_PDC,AD_TYPE_MANUL_BILL=@PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=@RO_OUTSTAND_P,GENRATE_CIR_AGCD=@genrate_agency_code,DISP_AUDITBKG=@p_dispauditbk,CIR_DIS_AUTO_POSTING=@p_aotosupply,RELAUTHREQON=@p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=@p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=@p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=@p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=@p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=@p_CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL=@p_AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE=@p_CIR_BILL_PUBLWISE,
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)




















/***************************************************************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




















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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED
           FROM PREFERRENCES
          WHERE comp_code = @compcode
















































/*================================21/dec/2011=======  ISSUE 0005951 ==============================*/
/*======================================= ISSUE 0005970 (Kuldeep Bhati) ==============================*/

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
	Bill_to  varchar (8) ,
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
REVISE_DATE  datetime 
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
REVISE_DATE
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
 end as REVISE_DATE
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

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
@p_revisedate as datetime
AS
declare @sccode as varchar(50)
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
RECEIPT_CURRENCY=@rcpt_currency,CONV_CURR_RATE=@cur_convrate,REVISE_DATE=@p_revisedate
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
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
@p_revisedate as datetime
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
REVISE_DATE
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
@p_revisedate
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

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER PROCEDURE [dbo].[committransaction]
	@cioid varchar(50),@totalcount int
AS
declare @countnum int
declare @billpay varchar(20)
declare @rostatus varchar(10)
declare @remarks varchar(500)
declare @clientname varchar(200)
BEGIN
select @countnum=count(*) from tbl_booking_insert_g where Cio_Booking_Id=@cioid
if @countnum=@totalcount
begin

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
			REVISE_DATE)
SELECT [date_time]
           ,[branch]
           ,[booked_by]
           ,@cioid
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
			REVISE_DATE
			 FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=@cioid

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
SELECT insert_id,@cioid
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
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT, BOXCHARGE,VAT_INC, LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=@cioid

INSERT INTO TBL_BOOKING_VTS(COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE) 
SELECT COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE FROM TBL_BOOKING_VTS_G WHERE  cioid=@cioid


insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO)
select COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO, SRNO from tbl_booking_subedition_g
where tbl_booking_subedition_g.CIOID=@cioid;


insert into TBL_BOOKING_SHARING_TRANS(PUBLICATION, TYPE, SHARING, CIOID, SRNO)
select PUBLICATION, TYPE, SHARING, CIOID, SRNO from TBL_BOOKING_SHARING_TRANS_g where CIOID=@cioid

insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID, CREATIONDATETIME)
select CIOID, INSERTID, CREATIONDATETIME from TBL_BOOKING_FMG_TRANS_G where CIOID=@cioid

 select @billpay=Bill_pay,@rostatus=ro_status  from tbl_booking_mast where cio_booking_id=@cioid
PRINT @billpay
PRINT @rostatus
if (@billpay = 'CA0' or @billpay = 'CH0') and @rostatus='1'
begin
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
select @book_doctype=doctype,@book_client=client_code,@book_prev_cioid=prev_cioid,@book_Agency_code=Agency_code,@book_retainer=RETAINER,@book_exec=Executive_code,@book_Agency_sub_code=Agency_sub_code,@book_billpay=Bill_pay,@book_userid=userid,@book_datetime=date_time,@book_gross=Gross_amount,@book_billamt=Bill_amount,@prev_cioid=prev_cioid,@book_rec=receipt_no,@book_compcode=comp_code,@book_branch=branch,@book_agencycode=Agency_sub_code from tbl_booking_mast where cio_booking_id=@cioid

select @branchcode=Branch_Code  from branch_mst where Comp_Code=@book_compcode and Branch_Name=@book_branch

select @subagencyreg=SUB_Agency_Code  from agency_mast where Comp_Code=@book_compcode and code_subcode=@book_agencycode
set @vrecpt=@book_rec
set @prevcioid_v=@prev_cioid

if @prevcioid_v is null or @prevcioid_v=''
begin
		set @billamt_v=@book_billamt
		set @grossamt_v=@book_gross
		set @v_curdate=@book_datetime
end
else
begin
		select @billamt_v=Bill_amount,@grossamt_v=Gross_amount from tbl_booking_mast where cio_booking_id=@prevcioid_v
		set @billamt_v=@book_billamt - @billamt_v
		 set @grossamt_v=@book_gross - @grossamt_v
		IF @grossamt_v = 0 OR @grossamt_v IS NULL
		BEGIN
			set @grossamt_v=@book_gross
		END
		 set @v_curdate=getdate()
end

 SELECT @clientname=Cust_Name FROM CUST_MAST WHERE Cust_Code = @book_client and Comp_Code=@book_compcode
if @clientname=''
begin
set @clientname=@book_client
end	
print @cioid
print @clientname
select @remarks='RONO#'+RO_No +' RODATE# ' + isnull(convert(varchar(12),RO_Date,103),'') + ' BOOKINGID# ' + cio_booking_id + ' CLIENT#' + @clientname from tbl_booking_mast where cio_booking_id=@cioid
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
  '','','',@remarks,@vrepcode,@book_datetime,@book_Agency_code,@subagencyreg,'',@cioid,@book_exec,@book_retainer,@book_prev_cioid
select @v_rcptno_r=receipt_no from   #recpt_t
update tbl_booking_mast set Receipt_no=@v_rcptno_r where cio_booking_id=@cioid
drop table #recpt_t
end

end
END

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

CREATE PROCEDURE ADB_CHKAG_RATEREVISE
(
@p_compcode  as varchar(8),
@p_agcode  as varchar(20),
@extra1  as varchar(50),
@extra2  as varchar(50)
)
as
BEGIN
SELECT RATE_REVISE FROM AGENCY_MAST WHERE Comp_Code=@p_compcode AND code_subcode=@p_agcode

END
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER PROCEDURE [dbo].[ADB_FETCHPERMISSION]
(
@p_compcode  as varchar(8),
@p_userid  as varchar(20),
@extra1  as varchar(50),
@extra2  as varchar(50)
)
as
BEGIN
SELECT PERMISSION_DESC FROM USERPERMISSION WHERE USERID=@p_userid AND  COMM_CODE=@p_compcode

END







/**********************************/



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go






ALTER PROCEDURE   [dbo].[wesp_updatedate1]

@compcode as varchar(15),
@userid as varchar(15),
@dateformat as varchar(15),
@code as varchar(4),
@curr as varchar(8),
@ratecode as varchar(8),
@solo as varchar(15),
@breakup as varchar(2),
@bwcode as varchar(8),
@rostatus as varchar(2),
@filename as varchar(2),
@tfn as VARCHAR(4),
@insertbreak as varchar(2),
@prem as varchar(8),
@dealtype as varchar(2),
@pre as varchar(5),
@suff as varchar(5),
@financestatus as  char(2),
@voucherst as varchar(30),
@adcode as varchar(100),
@rodatetime as varchar(8),
@spacearea as varchar(8),
@vat as varchar(50),
@bookstat as varchar(25),
@cio_id as varchar(8),
@receipt_no as varchar(50),
@uom as varchar(8),
@bgcolor as varchar(10),
@validdate as varchar(10),
@agencyratecode as varchar(10),
@audit as varchar(8),
@book_insert_date as varchar(8),
@agencycomm as varchar(8),
@rateaudit as varchar(8),
@billaudit as varchar(8),
@billtype as varchar(8),
@invoice_no as varchar(50),
@copybooking as varchar(8),
@ratecompany as varchar(50),
@addagenycomm as varchar(50),
@agencycommlinkretainer as varchar(50),
@subeditionr as varchar(50),
@displaybilltype as varchar(50),
@classifiedbilltype as varchar(50),
@billformat as varchar(50),
@ratechk as varchar(50),
@allpkg as varchar(50),
@dayrate1 as varchar(50),
@schemetype as varchar(50),
@PIncludeclassi as varchar(50),
@receiptformat as varchar(50),
@cash_receipt as varchar(50),
@bill_orderwiselast as varchar(50),
@floor_chk as varchar(50),
@Unsoldflag as varchar(1),
@Supplystopper as varchar(10),
@drpRokeychk as varchar(1),
@Agencycomm_seq as varchar(1),
@creditreciept as varchar(1),
@cashindisplay as varchar(8),
@cashinclassified as varchar(8),
@rate_audit_pref as varchar(25),
@v_barcoding_allow as varchar(25),
@v_fmgbills AS VARCHAR(25),
@v_billed_cashdis as varchar(25),
@v_billed_cashcls as varchar(25),
@v_drpbackdate as varchar(25),
@dockitbooking as varchar(1),
@allowprevbooking as varchar(1),
@ro_wisecashbill as varchar(50),
@chkval as varchar(5),
@approval1 as varchar(50),
@pckstatus as varchar(3),
@cash_disc as varchar(1),
@cash_amt as varchar(10),
@seperate_cashier1 as varchar(10),
@disp_bill as varchar(1),
@clas_bill as varchar(1),
@mantimepost as varchar(1),
@bkdaypost as int,
@maxterutn as int,
@cir_return as varchar(1),
@noofchkbounc as int,
@noofdaychkrec as int,
@retday as int,
@chngsuppord as int,
@max_publishday as int,
@p_billno_period as varchar(15),
@spl_trans_edit as varchar(5),
@spl_dis_trans_editable as varchar(5),
@mul_pac_sel_trans as varchar(5),
@shmon_minword	as varchar(1),
@tradon_spcrg	as varchar(1),
@rateauth       as varchar(1),
@f2day as int,
@rateauditmodify as varchar(1),
@bindrevenuecenter as varchar(1),
@p_led_allow as varchar(2),
@p_clear_allow as varchar(2),
@repeatday as varchar(2),
@premiumedit as varchar(2),
@P_BILL_GENERATION as varchar(20),
@P_PUBLICATION_CENTER as varchar(50),
@P_allow_discount_prem as varchar(1),
@P_SCHEME_BILLING as varchar(50),
@P_ALLOW_PDC as varchar(50),
@PAD_TYPE_FOR_MANUL_BILL AS VARCHAR(20),
@RO_OUTSTAND_P AS VARCHAR(5),
@genrate_agency_code AS VARCHAR(5),
@p_dispauditbk AS VARCHAR(5),
@p_aotosupply  AS VARCHAR(5),
@p_Authorization as VARCHAR(1),
@p_CIR_AUTO_APPROVAL_UNSOLD AS VARCHAR(5),
@p_CIR_AUTO_PHYSICAL_UNSOLD AS VARCHAR(5),
@p_CIR_UNSOLD_INCLUDE_INCT AS VARCHAR(5),
@p_CIR_UNSOLD_INCLUDE_INSFEE AS VARCHAR(5),
@p_CIR_UNSOLD_ON_RECEIVED_DT AS VARCHAR(5),
@p_AGENCY_UNBLOCK_APPROVAL AS VARCHAR(5),
@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT AS VARCHAR(5),
@p_CIR_BILL_PUBLWISE AS VARCHAR(5),
@paging         AS VARCHAR(4000) ,
@print          AS VARCHAR(4000) ,
@allowpage      AS VARCHAR(4000) ,
@agency_req     AS VARCHAR(4000) ,
@region_req     AS VARCHAR(4000) ,
@p_ALLOW_FOLLOW_DT_BOOOK as varchar(1)


AS
declare @query as varchar(8000)
declare @query1 as varchar(8000)
/*
set @query='update login set date_format='''+@dateformat+''' , Autogenerate='''+@code+''',curr_code='''+@curr+''' where com_code='''+@compcode+'''   '
exec(@query)

set @query1='update preferrences set RATE_COMPANY_AGENCY='''+@ratecompany+''',ADDITIONAL_AGENCY_COMM='''+@addagenycomm+''',
AGENCY_RETAINER_COMM='''+@agencycommlinkretainer+''',SUBEDITIONRATE='''+@subeditionr+''',DIS_BILLTYPE='''+@displaybilltype+''',
CLS_BILLTYPE='''+@classifiedbilltype+''',autogenerated='''+@code+''',currency_code='''+@curr+''' ,rate_gr_code='''+@ratecode+''' , 
date_format='''+@dateformat+''',solo='''+@solo+''',breakup='''+@breakup+''' ,blackwhitecode='''+@bwcode+''',  rostatus='''+@rostatus+''',
File_name='''+@filename+''',Tfn='''+@tfn+''',Insert_breakup='''+@insertbreak+''',Premium_type='''+@prem+''',Deal_type='''+@dealtype+'''  ,    
prefix='''+@pre+''', suffix='''+@suff+'''  ,     financestatus='''+ @financestatus+''' , voucherst='''+@voucherst+''',Ad_category='''+@adcode+''' ,
Ro_datetime='''+@rodatetime+''' ,Space_area='''+@spacearea+''',Vat='''+@vat+''' ,Booking_status='''+@bookstat+''' ,Cio_id='''+@cio_id+''',
Receipt_no='''+@receipt_no+''' ,uom_code='''+@uom+''',Bgcolor_publication='''+@bgcolor+''' ,chkfor_valid_pubdates='''+@validdate+''', 
Agency_ratecode='''+@agencyratecode+''',   audit='''+@audit+''', book_insert_date='''+@book_insert_date+''',agencycomm='''+@agencycomm+''',
rate_audit='''+@rateaudit+''',bill_audit='''+@billaudit+''', billtype='''+@billtype+''', invoice_no='''+@invoice_no+''' , 
copy_booking='''+@copybooking+''', BILLING_FORMAT='''+@billformat+''' , RATE_CHECK='''+@ratechk+''', ALL_PACKAGE='''+@allpkg+''',
DAYRATE='''+@dayrate1+''' ,SCHEME_TYPE='''+@schemetype+'''    ,DISP_CLSBILL='''+@PIncludeclassi+ '''  , RECEIPT_FORMAT ='''+@receiptformat+''',
CASH_RECEIPT_BILL='''+@cash_receipt+''', BILL_ORDERWSLAST='''+@bill_orderwiselast+''',FLOOR_CHK='''+@floor_chk+''' ,
Unsold_Entry_Flag='''+@Unsoldflag+''' ,Supply_Stop_Percentage='''+@Supplystopper+''',ROKEYCHECK='''+@drpRokeychk+''',
AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''',DISP_CASHBILL='''+@cashindisplay+''',
CLA_CASHBILL='''+@cashinclassified+''',RATE_AUDIT_PREF='''+@rate_audit_pref+''',BARCODING_ALLOWED='''+@v_barcoding_allow+''', 
FMG_BILL_DIS='''+@v_fmgbills+''',BILL_DISP_CASHBILL='''+@v_billed_cashdis +''',BILL_CLA_CASHBILL ='''+@v_billed_cashcls+''',
BACKDATERECEIPT='''+@v_drpbackdate+''',DOCKIT_BOOKING='''+@dockitbooking+''',Allowed_old_date='''+@allowprevbooking+''',
ROWISE_CASHBOOKING='''+@ro_wisecashbill+''' where    comp_code='''+@compcode+'''   ' 
*/
/*********************************************************************************************************/
UPDATE LOGIN SET date_format=@dateformat, Autogenerate=@code,curr_code=@curr WHERE COM_CODE=@compcode

UPDATE PREFERRENCES SET  autogenerated=@code,
currency_code=@curr ,
rate_gr_code=@ratecode,
date_format=@dateformat,solo=@solo,breakup=@breakup,
blackwhitecode=@bwcode,rostatus=@rostatus,File_name=@filename,Tfn=@tfn,
Insert_breakup=@insertbreak,Premium_type=@prem,Deal_type=@dealtype  ,
 prefix=@pre, suffix=@suff, financestatus=@financestatus , voucherst=@voucherst,
 Ad_category=@adcode ,Ro_datetime=@rodatetime ,Space_area=@spacearea,Vat=@vat,
 Booking_status=@bookstat,Cio_id=@cio_id,Receipt_no=@receipt_no,uom_code=@uom,
 Bgcolor_publication=@bgcolor ,chkfor_valid_pubdates=@validdate, Agency_ratecode=@agencyratecode,
  audit=@AUDIT,book_insert_date=@book_insert_date,agencycomm=@agencycomm,
  rate_audit=@rateaudit,bill_audit=@billaudit,billtype=@billtype,invoice_no=@invoice_no,
  copy_booking=@copybooking,RATE_COMPANY_AGENCY=@ratecompany, ADDITIONAL_AGENCY_COMM=@addagenycomm ,
  AGENCY_RETAINER_COMM=@agencycommlinkretainer,SUBEDITIONRATE=@subeditionr,
  CLS_BILLTYPE=@classifiedbilltype,DIS_BILLTYPE=@displaybilltype,BILLING_FORMAT=@billformat,
  RATE_CHECK=@ratechk,ALL_PACKAGE=@allpkg,dayrate=@dayrate1,SCHEME_TYPE=@schemetype,DISP_CLSBILL=@PIncludeclassi   ,
  CASH_RECEIPT_BILL=@cash_receipt, BILL_ORDERWSLAST=@bill_orderwiselast, FLOOR_CHK=@floor_chk ,
  Unsold_Entry_Flag=@Unsoldflag ,Supply_Stop_Percentage=@Supplystopper,ROKEYCHECK=@drpRokeychk ,
  AGENCYCOMM_SEQ_COM=@Agencycomm_seq ,CREDIT_RECIPT=@creditreciept,DISP_CASHBILL=@cashindisplay,
  CLA_CASHBILL=@cashinclassified,RATE_AUDIT_PREF=@rate_audit_pref,BARCODING_ALLOWED=@v_barcoding_allow,
  FMG_BILL_DIS =@v_fmgbills, BILL_DISP_CASHBILL=@v_billed_cashdis , BILL_CLA_CASHBILL=@v_billed_cashcls,BACKDATERECEIPT=@v_drpbackdate,DOCKIT_BOOKING=@dockitbooking,Allowed_old_date=@allowprevbooking,ROWISE_CASHBOOKING=@ro_wisecashbill,CUTOFFTIME=@chkval,APPROVAL=@approval1,back_days=@pckstatus,CASH_DISCOUNT=@cash_amt,CASH_DISCOUNTTYPE=@cash_disc,SEPRATE_CASHIER=@seperate_cashier1,
 CIR_MANY_TIME_POSTING=@mantimepost, CIR_BACKDAYS_POSTING=@bkdaypost, CIR_MAX_RETURN_ALLOW=@maxterutn, CIR_RETURN_LIMIT_ALLOW=@cir_return, CIR_NO_OF_CHQBOUNCE=@noofchkbounc, CIR_DAYS_CHQBOUNCE=@noofdaychkrec, CIR_RETURN_DAYS=@retday, CIR_SUP_ORDER_LIMIT=@chngsuppord, DISP_BILLING_CRITERIA=@disp_bill, CLSD_BILLING_CRITERIA=@clas_bill,MAX_PUBLISHDAYS=@max_publishday,
 BILLNO_PERIODICITY=@p_billno_period,SPECIALDISC_TRANS_EDIT=@spl_trans_edit, SHARING_TRANS=@spl_dis_trans_editable, MULTIPACKAGE_SEL_TRANS=@mul_pac_sel_trans,SCHEME_MINWORD=@shmon_minword, TRADE_SPLCHARGE=@tradon_spcrg,RATE_AUTHORIZATION=@rateauth
  ,F2_RECORD=@f2day,PUBLISHAD_EDIT_RATEAUDIT=@rateauditmodify,BINDREVENUE_CENTER=@bindrevenuecenter,
FA_LEDGER_ALLOW=@p_led_allow,CLEARANCE_TYPE_ALLOW=@p_clear_allow,REPEAT_DAY_TYPE=@repeatday,PREMIUM_EDIT=@premiumedit,

BILL_GENERATION_PRIOR=@P_BILL_GENERATION,PUBLICATION_HO=@P_PUBLICATION_CENTER,

SPLDISC_ALLOWPREM=@P_allow_discount_prem,BILL_SCHEME=@P_SCHEME_BILLING,

ALLOWED_PDC_DAYS_RECEIPT=@P_ALLOW_PDC,AD_TYPE_MANUL_BILL=@PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=@RO_OUTSTAND_P,GENRATE_CIR_AGCD=@genrate_agency_code,DISP_AUDITBKG=@p_dispauditbk,CIR_DIS_AUTO_POSTING=@p_aotosupply,RELAUTHREQON=@p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=@p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=@p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=@p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=@p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=@p_CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL=@p_AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE=@p_CIR_BILL_PUBLWISE,
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)





/***************************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




















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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK
           FROM PREFERRENCES
          WHERE comp_code = @compcode































































/*======================================= End of ISSUE 0005970 (Kuldeep Bhati) ==============================*/




/**********************mimoh****************26/12/2011************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[book_advcategory]

@compcode as varchar(8),
@booking as varchar(8),
@center  AS varchar(50)=null


AS


--select * from adv_cat_mast where comp_code=@compcode

--if(@booking!='adtype')
--begin

select Adv_Cat_Code,Adv_Cat_Name from adv_cat_mast where comp_code=@compcode and (STATUS='1' or STATUS is null)  and adv_type=@booking  order by Adv_Cat_Name
select Uom_Code,Uom_Name from uom_mast where comp_code=@compcode and ad_type= @booking order by Uom_Name


 if(@center<>'0') 
begin
	 if(@booking<>'0') 
		select Combin_Code,Package_Name,(Combin_Code+'@'+Combin_Desc) as pck_code from combin_mast where comp_code=@compcode and Ad_Type_Code=@booking and pub_center=@center
	else
		select Combin_Code,Package_Name,(Combin_Code+'@'+Combin_Desc) as pck_code from combin_mast where comp_code=@compcode and  pub_center=@center

end
else
begin
		select Combin_Code,Package_Name,(Combin_Code+'@'+Combin_Desc) as pck_code from combin_mast where comp_code=@compcode and Ad_Type_Code=@booking
end



/*************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




ALTER PROCEDURE [dbo].[book_advcategory1]

@compcode as varchar(8),
@booking as varchar(8)


AS
if @booking = '0' or @booking = 'adtype'
	select Adv_Cat_Code,Adv_Cat_Name from adv_cat_mast where comp_code=@compcode and (STATUS='1' or STATUS is null)   order by Adv_Cat_Name
else
	select Adv_Cat_Code,Adv_Cat_Name from adv_cat_mast where comp_code=@compcode and (STATUS='1' or STATUS is null)   and adv_type=@booking  order by Adv_Cat_Name
--select Adv_Cat_Code, Adv_Cat_Name from adv_cat_mast where Comp_Code=@compcode order by Adv_Cat_Name

/**************/







CREATE OR REPLACE PACKAGE Book_Advsubcattyp
IS
  TYPE T_Accounts_Cursor IS REF CURSOR;
  PROCEDURE book_advsubcattyp_P (compcode VARCHAR2,catcode VARCHAR2,agencytype VARCHAR2,P_Accounts OUT T_Accounts_Cursor,P_Accounts1 OUT T_Accounts_Cursor);

END Book_Advsubcattyp;
/





CREATE OR REPLACE PACKAGE BODY Book_Advsubcattyp
IS

  PROCEDURE book_advsubcattyp_P (compcode VARCHAR2,catcode VARCHAR2,agencytype VARCHAR2,P_Accounts OUT T_Accounts_Cursor,P_Accounts1 OUT T_Accounts_Cursor)
  AS

  	BEGIN
 	    OPEN P_Accounts FOR
        select "Adv_Subcat_Code","Adv_Subcat_Name" from adv_subcat_mast where "Comp_Code"=compcode and (STATUS='1' or STATUS is null) and "Adv_Cat_Code"=catcode order by "Adv_Subcat_Name";
       -- SELECT "Adv_Subcat_Code","Adv_Subcat_Name" FROM ADV_SUBCAT_MAST WHERE "Comp_Code"=compcode AND  "Adv_Cat_Code"=catcode order by "Adv_Subcat_Name";
         		
        OPEN P_Accounts1 FOR
 		SELECT "Comm_Rate" FROM AGENCY_TYPE_MST WHERE "Comp_Code"=compcode AND  "Ad_category"=catcode AND "Agency_Type_Code"=agencytype;

    END book_advsubcattyp_P;
 END Book_Advsubcattyp;
/






/**********************mimoh****************26/12/2011************/

/*======================================= ISSUE 0005966 (Kuldeep Bhati) ==============================*/

ALTER  PROCEDURE [dbo].[websp_loginemployee]
@username varchar(50),
@password varchar(10),
@qbc varchar(8)=null

AS
declare @query as varchar(900)
declare @count as varchar(100)
declare @query1 as varchar(900)
declare @query2 as varchar(1000)
declare @userid varchar(100)

if(@qbc=null or @qbc='')
begin
set @query='select username,password,userid,date_format,com_code,autogenerate,curr_code  ,comp_name, datediff(dd,creation_datetime,getdate()) as diff,DISCOUNT,FILTER,ROLEID,retainer_code AS RETAINER          from login where userid='''+@username+''' and password='''+@password+''' and STATUS ! = ''I'''

select @count=com_code from login where userid=@username and password=@password
/*new change ankur for agency*/
set @query1='SELECT rate_gr_code,autogenerated,currency_code,date_format,solo,No_of_Decimal,
        breakup,blackwhitecode,uom_code,rostatus,Tfn,Insert_breakup,Premium_type,Deal_type     ,
        prefix,suffix,financestatus,voucherst,Ad_category,Ro_datetime,Space_area,Vat,Booking_status,Cio_id,Receipt_no,Bgcolor_publication, chkfor_valid_pubdates,Agency_ratecode,audit,copy_booking,RATE_COMPANY_AGENCY,SUBEDITIONRATE,ADDITIONAL_AGENCY_COMM,AGENCY_RETAINER_COMM,

        invoice_no,rate_audit,CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT, RATE_CHECK, ALL_PACKAGE,DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,ROKEYCHECK,
		DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF,FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,DISP_AUDITBKG,CIR_AUTO_PHYSICAL_UNSOLD,ALLOW_FOLLOW_DT_BOOOK

  from preferrences where comp_code= '''+@count+'''' 
select @userid=userid from login where username=@username and  password=@password  and com_code=@count

set @query2='select company_user,Admin from login where userid='''+@username+''''

end
else
begin
set @query='select username,password,userid,date_format,com_code,autogenerate,curr_code  ,comp_name  , datediff(dd,creation_datetime,getdate()) as diff,DISCOUNT,FILTER ,ROLEID ,retainer_code   AS RETAINER     from login where userid='''+@username+''' and password='''+@password+''' and retainer_code='''+@qbc+''' and STATUS ! = ''I'''

select @count=com_code from login where userid=@username and password=@password and retainer_code=@qbc

/*new change ankur for agency*/
set @query1='SELECT rate_gr_code,autogenerated,currency_code,date_format,solo,No_of_Decimal,
        breakup,blackwhitecode,uom_code,rostatus,Tfn,Insert_breakup,Premium_type,Deal_type     ,
        prefix,suffix,financestatus,voucherst,Ad_category,Ro_datetime,Space_area,Vat,Booking_status,Cio_id,Receipt_no,Bgcolor_publication, chkfor_valid_pubdates,Agency_ratecode,audit,copy_booking,RATE_COMPANY_AGENCY,SUBEDITIONRATE,ADDITIONAL_AGENCY_COMM,AGENCY_RETAINER_COMM,

        invoice_no,rate_audit,CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT, RATE_CHECK, ALL_PACKAGE,DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,ROKEYCHECK,
		DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF,FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,DISP_AUDITBKG,CIR_AUTO_PHYSICAL_UNSOLD,ALLOW_FOLLOW_DT_BOOOK
		 from preferrences where comp_code= '''+@count+''''

select @userid=userid from login where username=@username and  password=@password  and com_code=@count

set @query2='select company_user,Admin from login where userid='''+@username+''''
end


print(@query)
exec(@query)

print(@query1)
exec(@query1)


print(@query2)
exec(@query2)

/*======================================= End of ISSUE 0005966 (Kuldeep Bhati) ==============================*/

/***********************mimoh 26dec 2011*********************************0006137****************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go







ALTER PROCEDURE   [dbo].[wesp_updatedate1]

@compcode as varchar(15),
@userid as varchar(15),
@dateformat as varchar(15),
@code as varchar(4),
@curr as varchar(8),
@ratecode as varchar(8),
@solo as varchar(15),
@breakup as varchar(2),
@bwcode as varchar(8),
@rostatus as varchar(2),
@filename as varchar(2),
@tfn as VARCHAR(4),
@insertbreak as varchar(2),
@prem as varchar(8),
@dealtype as varchar(2),
@pre as varchar(5),
@suff as varchar(5),
@financestatus as  char(2),
@voucherst as varchar(30),
@adcode as varchar(100),
@rodatetime as varchar(8),
@spacearea as varchar(8),
@vat as varchar(50),
@bookstat as varchar(25),
@cio_id as varchar(8),
@receipt_no as varchar(50),
@uom as varchar(8),
@bgcolor as varchar(10),
@validdate as varchar(10),
@agencyratecode as varchar(10),
@audit as varchar(8),
@book_insert_date as varchar(8),
@agencycomm as varchar(8),
@rateaudit as varchar(8),
@billaudit as varchar(8),
@billtype as varchar(8),
@invoice_no as varchar(50),
@copybooking as varchar(8),
@ratecompany as varchar(50),
@addagenycomm as varchar(50),
@agencycommlinkretainer as varchar(50),
@subeditionr as varchar(50),
@displaybilltype as varchar(50),
@classifiedbilltype as varchar(50),
@billformat as varchar(50),
@ratechk as varchar(50),
@allpkg as varchar(50),
@dayrate1 as varchar(50),
@schemetype as varchar(50),
@PIncludeclassi as varchar(50),
@receiptformat as varchar(50),
@cash_receipt as varchar(50),
@bill_orderwiselast as varchar(50),
@floor_chk as varchar(50),
@Unsoldflag as varchar(1),
@Supplystopper as varchar(10),
@drpRokeychk as varchar(1),
@Agencycomm_seq as varchar(1),
@creditreciept as varchar(1),
@cashindisplay as varchar(8),
@cashinclassified as varchar(8),
@rate_audit_pref as varchar(25),
@v_barcoding_allow as varchar(25),
@v_fmgbills AS VARCHAR(25),
@v_billed_cashdis as varchar(25),
@v_billed_cashcls as varchar(25),
@v_drpbackdate as varchar(25),
@dockitbooking as varchar(1),
@allowprevbooking as varchar(1),
@ro_wisecashbill as varchar(50),
@chkval as varchar(5),
@approval1 as varchar(50),
@pckstatus as varchar(3),
@cash_disc as varchar(1),
@cash_amt as varchar(10),
@seperate_cashier1 as varchar(10),
@disp_bill as varchar(1),
@clas_bill as varchar(1),
@mantimepost as varchar(1),
@bkdaypost as int,
@maxterutn as int,
@cir_return as varchar(1),
@noofchkbounc as int,
@noofdaychkrec as int,
@retday as int,
@chngsuppord as int,
@max_publishday as int,
@p_billno_period as varchar(15),
@spl_trans_edit as varchar(5),
@spl_dis_trans_editable as varchar(5),
@mul_pac_sel_trans as varchar(5),
@shmon_minword	as varchar(1),
@tradon_spcrg	as varchar(1),
@rateauth       as varchar(1),
@f2day as int,
@rateauditmodify as varchar(1),
@bindrevenuecenter as varchar(1),
@p_led_allow as varchar(2),
@p_clear_allow as varchar(2),
@repeatday as varchar(2),
@premiumedit as varchar(2),
@P_BILL_GENERATION as varchar(20),
@P_PUBLICATION_CENTER as varchar(50),
@P_allow_discount_prem as varchar(1),
@P_SCHEME_BILLING as varchar(50),
@P_ALLOW_PDC as varchar(50),
@PAD_TYPE_FOR_MANUL_BILL AS VARCHAR(20),
@RO_OUTSTAND_P AS VARCHAR(5),
@genrate_agency_code AS VARCHAR(5),
@p_dispauditbk AS VARCHAR(5),
@p_aotosupply  AS VARCHAR(5),
@p_Authorization as VARCHAR(1),
@p_CIR_AUTO_APPROVAL_UNSOLD AS VARCHAR(5),
@p_CIR_AUTO_PHYSICAL_UNSOLD AS VARCHAR(5),
@p_CIR_UNSOLD_INCLUDE_INCT AS VARCHAR(5),
@p_CIR_UNSOLD_INCLUDE_INSFEE AS VARCHAR(5),
@p_CIR_UNSOLD_ON_RECEIVED_DT AS VARCHAR(5),
@p_AGENCY_UNBLOCK_APPROVAL AS VARCHAR(5),
@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT AS VARCHAR(5),
@p_CIR_BILL_PUBLWISE AS VARCHAR(5),
@paging         AS VARCHAR(4000) ,
@print          AS VARCHAR(4000) ,
@allowpage      AS VARCHAR(4000) ,
@agency_req     AS VARCHAR(4000) ,
@region_req     AS VARCHAR(4000) ,
@p_ALLOW_FOLLOW_DT_BOOOK as varchar(1),
@p_CRM_SUPPLY_TYPE_PAID   as varchar(10),
@p_CRM_SUPPLY_TYPE_FREE   as varchar(10)


AS
declare @query as varchar(8000)
declare @query1 as varchar(8000)
/*
set @query='update login set date_format='''+@dateformat+''' , Autogenerate='''+@code+''',curr_code='''+@curr+''' where com_code='''+@compcode+'''   '
exec(@query)

set @query1='update preferrences set RATE_COMPANY_AGENCY='''+@ratecompany+''',ADDITIONAL_AGENCY_COMM='''+@addagenycomm+''',
AGENCY_RETAINER_COMM='''+@agencycommlinkretainer+''',SUBEDITIONRATE='''+@subeditionr+''',DIS_BILLTYPE='''+@displaybilltype+''',
CLS_BILLTYPE='''+@classifiedbilltype+''',autogenerated='''+@code+''',currency_code='''+@curr+''' ,rate_gr_code='''+@ratecode+''' , 
date_format='''+@dateformat+''',solo='''+@solo+''',breakup='''+@breakup+''' ,blackwhitecode='''+@bwcode+''',  rostatus='''+@rostatus+''',
File_name='''+@filename+''',Tfn='''+@tfn+''',Insert_breakup='''+@insertbreak+''',Premium_type='''+@prem+''',Deal_type='''+@dealtype+'''  ,    
prefix='''+@pre+''', suffix='''+@suff+'''  ,     financestatus='''+ @financestatus+''' , voucherst='''+@voucherst+''',Ad_category='''+@adcode+''' ,
Ro_datetime='''+@rodatetime+''' ,Space_area='''+@spacearea+''',Vat='''+@vat+''' ,Booking_status='''+@bookstat+''' ,Cio_id='''+@cio_id+''',
Receipt_no='''+@receipt_no+''' ,uom_code='''+@uom+''',Bgcolor_publication='''+@bgcolor+''' ,chkfor_valid_pubdates='''+@validdate+''', 
Agency_ratecode='''+@agencyratecode+''',   audit='''+@audit+''', book_insert_date='''+@book_insert_date+''',agencycomm='''+@agencycomm+''',
rate_audit='''+@rateaudit+''',bill_audit='''+@billaudit+''', billtype='''+@billtype+''', invoice_no='''+@invoice_no+''' , 
copy_booking='''+@copybooking+''', BILLING_FORMAT='''+@billformat+''' , RATE_CHECK='''+@ratechk+''', ALL_PACKAGE='''+@allpkg+''',
DAYRATE='''+@dayrate1+''' ,SCHEME_TYPE='''+@schemetype+'''    ,DISP_CLSBILL='''+@PIncludeclassi+ '''  , RECEIPT_FORMAT ='''+@receiptformat+''',
CASH_RECEIPT_BILL='''+@cash_receipt+''', BILL_ORDERWSLAST='''+@bill_orderwiselast+''',FLOOR_CHK='''+@floor_chk+''' ,
Unsold_Entry_Flag='''+@Unsoldflag+''' ,Supply_Stop_Percentage='''+@Supplystopper+''',ROKEYCHECK='''+@drpRokeychk+''',
AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''',DISP_CASHBILL='''+@cashindisplay+''',
CLA_CASHBILL='''+@cashinclassified+''',RATE_AUDIT_PREF='''+@rate_audit_pref+''',BARCODING_ALLOWED='''+@v_barcoding_allow+''', 
FMG_BILL_DIS='''+@v_fmgbills+''',BILL_DISP_CASHBILL='''+@v_billed_cashdis +''',BILL_CLA_CASHBILL ='''+@v_billed_cashcls+''',
BACKDATERECEIPT='''+@v_drpbackdate+''',DOCKIT_BOOKING='''+@dockitbooking+''',Allowed_old_date='''+@allowprevbooking+''',
ROWISE_CASHBOOKING='''+@ro_wisecashbill+''' where    comp_code='''+@compcode+'''   ' 
*/
/*********************************************************************************************************/
UPDATE LOGIN SET date_format=@dateformat, Autogenerate=@code,curr_code=@curr WHERE COM_CODE=@compcode

UPDATE PREFERRENCES SET  autogenerated=@code,
currency_code=@curr ,
rate_gr_code=@ratecode,
date_format=@dateformat,solo=@solo,breakup=@breakup,
blackwhitecode=@bwcode,rostatus=@rostatus,File_name=@filename,Tfn=@tfn,
Insert_breakup=@insertbreak,Premium_type=@prem,Deal_type=@dealtype  ,
 prefix=@pre, suffix=@suff, financestatus=@financestatus , voucherst=@voucherst,
 Ad_category=@adcode ,Ro_datetime=@rodatetime ,Space_area=@spacearea,Vat=@vat,
 Booking_status=@bookstat,Cio_id=@cio_id,Receipt_no=@receipt_no,uom_code=@uom,
 Bgcolor_publication=@bgcolor ,chkfor_valid_pubdates=@validdate, Agency_ratecode=@agencyratecode,
  audit=@AUDIT,book_insert_date=@book_insert_date,agencycomm=@agencycomm,
  rate_audit=@rateaudit,bill_audit=@billaudit,billtype=@billtype,invoice_no=@invoice_no,
  copy_booking=@copybooking,RATE_COMPANY_AGENCY=@ratecompany, ADDITIONAL_AGENCY_COMM=@addagenycomm ,
  AGENCY_RETAINER_COMM=@agencycommlinkretainer,SUBEDITIONRATE=@subeditionr,
  CLS_BILLTYPE=@classifiedbilltype,DIS_BILLTYPE=@displaybilltype,BILLING_FORMAT=@billformat,
  RATE_CHECK=@ratechk,ALL_PACKAGE=@allpkg,dayrate=@dayrate1,SCHEME_TYPE=@schemetype,DISP_CLSBILL=@PIncludeclassi   ,
  CASH_RECEIPT_BILL=@cash_receipt, BILL_ORDERWSLAST=@bill_orderwiselast, FLOOR_CHK=@floor_chk ,
  Unsold_Entry_Flag=@Unsoldflag ,Supply_Stop_Percentage=@Supplystopper,ROKEYCHECK=@drpRokeychk ,
  AGENCYCOMM_SEQ_COM=@Agencycomm_seq ,CREDIT_RECIPT=@creditreciept,DISP_CASHBILL=@cashindisplay,
  CLA_CASHBILL=@cashinclassified,RATE_AUDIT_PREF=@rate_audit_pref,BARCODING_ALLOWED=@v_barcoding_allow,
  FMG_BILL_DIS =@v_fmgbills, BILL_DISP_CASHBILL=@v_billed_cashdis , BILL_CLA_CASHBILL=@v_billed_cashcls,BACKDATERECEIPT=@v_drpbackdate,DOCKIT_BOOKING=@dockitbooking,Allowed_old_date=@allowprevbooking,ROWISE_CASHBOOKING=@ro_wisecashbill,CUTOFFTIME=@chkval,APPROVAL=@approval1,back_days=@pckstatus,CASH_DISCOUNT=@cash_amt,CASH_DISCOUNTTYPE=@cash_disc,SEPRATE_CASHIER=@seperate_cashier1,
 CIR_MANY_TIME_POSTING=@mantimepost, CIR_BACKDAYS_POSTING=@bkdaypost, CIR_MAX_RETURN_ALLOW=@maxterutn, CIR_RETURN_LIMIT_ALLOW=@cir_return, CIR_NO_OF_CHQBOUNCE=@noofchkbounc, CIR_DAYS_CHQBOUNCE=@noofdaychkrec, CIR_RETURN_DAYS=@retday, CIR_SUP_ORDER_LIMIT=@chngsuppord, DISP_BILLING_CRITERIA=@disp_bill, CLSD_BILLING_CRITERIA=@clas_bill,MAX_PUBLISHDAYS=@max_publishday,
 BILLNO_PERIODICITY=@p_billno_period,SPECIALDISC_TRANS_EDIT=@spl_trans_edit, SHARING_TRANS=@spl_dis_trans_editable, MULTIPACKAGE_SEL_TRANS=@mul_pac_sel_trans,SCHEME_MINWORD=@shmon_minword, TRADE_SPLCHARGE=@tradon_spcrg,RATE_AUTHORIZATION=@rateauth
  ,F2_RECORD=@f2day,PUBLISHAD_EDIT_RATEAUDIT=@rateauditmodify,BINDREVENUE_CENTER=@bindrevenuecenter,
FA_LEDGER_ALLOW=@p_led_allow,CLEARANCE_TYPE_ALLOW=@p_clear_allow,REPEAT_DAY_TYPE=@repeatday,PREMIUM_EDIT=@premiumedit,

BILL_GENERATION_PRIOR=@P_BILL_GENERATION,PUBLICATION_HO=@P_PUBLICATION_CENTER,

SPLDISC_ALLOWPREM=@P_allow_discount_prem,BILL_SCHEME=@P_SCHEME_BILLING,

ALLOWED_PDC_DAYS_RECEIPT=@P_ALLOW_PDC,AD_TYPE_MANUL_BILL=@PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=@RO_OUTSTAND_P,GENRATE_CIR_AGCD=@genrate_agency_code,DISP_AUDITBKG=@p_dispauditbk,CIR_DIS_AUTO_POSTING=@p_aotosupply,RELAUTHREQON=@p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=@p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=@p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=@p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=@p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=@p_CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL=@p_AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE=@p_CIR_BILL_PUBLWISE,
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=@p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=@p_CRM_SUPPLY_TYPE_FREE
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)







































/********************/




set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





















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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE
           FROM PREFERRENCES
          WHERE comp_code = @compcode























/************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[Cir_Supply_Type_Bind_p]
	@pcomp_code			VARCHAR(20) ,
	@pdateformat        VARCHAR(20) ,
	@pextra1            VARCHAR(40) ,--for billing pay Y/N
	@pextra2            VARCHAR(400) 
AS 
	
	SELECT * FROM  cir_supply_type_mast 
	WHERE comp_code  = @pcomp_code and (bill_pay=@pextra1 or @pextra1 is null or @pextra1 ='')
	ORDER BY sup_seq_no,sup_ty_name 










/***********************mimoh 26dec 2011*********************************0006137****************/


/*********************mimoh 28dec2011********************************5972******************************/

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
@agency_sav varchar(20),
@p_parent varchar(5)

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
,Status_Reason,Remarks,UserId,Creation_Datetime,Zone_code,Region_code,Credit_limit,Rate_Gr_Code,  getdate() ,Client_category ,TALUKA,(select top 1 TO_DATE from status_detail_client where status_detail_client.cust_code=cust_mast.Cust_Code) as to_date,CLIENT_TYPE,QBC_AGENCY,TYPE,PARENT_CLIENT    from cust_mast where comp_code='''+@compcode+'''' 

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

if(@p_parent <> '')

--print(@status)

begin

set @query  =  @query + 'and TYPE  like ''%'+@p_parent+'%'''

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












/*********************mimoh 28dec2011********************************5972******************************/





/***********************mimoh 28dec 2011*********6162****************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go







ALTER PROCEDURE   [dbo].[wesp_updatedate1]

@compcode as varchar(15),
@userid as varchar(15),
@dateformat as varchar(15),
@code as varchar(4),
@curr as varchar(8),
@ratecode as varchar(8),
@solo as varchar(15),
@breakup as varchar(2),
@bwcode as varchar(8),
@rostatus as varchar(2),
@filename as varchar(2),
@tfn as VARCHAR(4),
@insertbreak as varchar(2),
@prem as varchar(8),
@dealtype as varchar(2),
@pre as varchar(5),
@suff as varchar(5),
@financestatus as  char(2),
@voucherst as varchar(30),
@adcode as varchar(100),
@rodatetime as varchar(8),
@spacearea as varchar(8),
@vat as varchar(50),
@bookstat as varchar(25),
@cio_id as varchar(8),
@receipt_no as varchar(50),
@uom as varchar(8),
@bgcolor as varchar(10),
@validdate as varchar(10),
@agencyratecode as varchar(10),
@audit as varchar(8),
@book_insert_date as varchar(8),
@agencycomm as varchar(8),
@rateaudit as varchar(8),
@billaudit as varchar(8),
@billtype as varchar(8),
@invoice_no as varchar(50),
@copybooking as varchar(8),
@ratecompany as varchar(50),
@addagenycomm as varchar(50),
@agencycommlinkretainer as varchar(50),
@subeditionr as varchar(50),
@displaybilltype as varchar(50),
@classifiedbilltype as varchar(50),
@billformat as varchar(50),
@ratechk as varchar(50),
@allpkg as varchar(50),
@dayrate1 as varchar(50),
@schemetype as varchar(50),
@PIncludeclassi as varchar(50),
@receiptformat as varchar(50),
@cash_receipt as varchar(50),
@bill_orderwiselast as varchar(50),
@floor_chk as varchar(50),
@Unsoldflag as varchar(1),
@Supplystopper as varchar(10),
@drpRokeychk as varchar(1),
@Agencycomm_seq as varchar(1),
@creditreciept as varchar(1),
@cashindisplay as varchar(8),
@cashinclassified as varchar(8),
@rate_audit_pref as varchar(25),
@v_barcoding_allow as varchar(25),
@v_fmgbills AS VARCHAR(25),
@v_billed_cashdis as varchar(25),
@v_billed_cashcls as varchar(25),
@v_drpbackdate as varchar(25),
@dockitbooking as varchar(1),
@allowprevbooking as varchar(1),
@ro_wisecashbill as varchar(50),
@chkval as varchar(5),
@approval1 as varchar(50),
@pckstatus as varchar(3),
@cash_disc as varchar(1),
@cash_amt as varchar(10),
@seperate_cashier1 as varchar(10),
@disp_bill as varchar(1),
@clas_bill as varchar(1),
@mantimepost as varchar(1),
@bkdaypost as int,
@maxterutn as int,
@cir_return as varchar(1),
@noofchkbounc as int,
@noofdaychkrec as int,
@retday as int,
@chngsuppord as int,
@max_publishday as int,
@p_billno_period as varchar(15),
@spl_trans_edit as varchar(5),
@spl_dis_trans_editable as varchar(5),
@mul_pac_sel_trans as varchar(5),
@shmon_minword	as varchar(1),
@tradon_spcrg	as varchar(1),
@rateauth       as varchar(1),
@f2day as int,
@rateauditmodify as varchar(1),
@bindrevenuecenter as varchar(1),
@p_led_allow as varchar(2),
@p_clear_allow as varchar(2),
@repeatday as varchar(2),
@premiumedit as varchar(2),
@P_BILL_GENERATION as varchar(20),
@P_PUBLICATION_CENTER as varchar(50),
@P_allow_discount_prem as varchar(1),
@P_SCHEME_BILLING as varchar(50),
@P_ALLOW_PDC as varchar(50),
@PAD_TYPE_FOR_MANUL_BILL AS VARCHAR(20),
@RO_OUTSTAND_P AS VARCHAR(5),
@genrate_agency_code AS VARCHAR(5),
@p_dispauditbk AS VARCHAR(5),
@p_aotosupply  AS VARCHAR(5),
@p_Authorization as VARCHAR(1),
@p_CIR_AUTO_APPROVAL_UNSOLD AS VARCHAR(5),
@p_CIR_AUTO_PHYSICAL_UNSOLD AS VARCHAR(5),
@p_CIR_UNSOLD_INCLUDE_INCT AS VARCHAR(5),
@p_CIR_UNSOLD_INCLUDE_INSFEE AS VARCHAR(5),
@p_CIR_UNSOLD_ON_RECEIVED_DT AS VARCHAR(5),
@p_AGENCY_UNBLOCK_APPROVAL AS VARCHAR(5),
@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT AS VARCHAR(5),
@p_CIR_BILL_PUBLWISE AS VARCHAR(5),
@paging         AS VARCHAR(4000) ,
@print          AS VARCHAR(4000) ,
@allowpage      AS VARCHAR(4000) ,
@agency_req     AS VARCHAR(4000) ,
@region_req     AS VARCHAR(4000) ,
@p_ALLOW_FOLLOW_DT_BOOOK as varchar(1),
@p_CRM_SUPPLY_TYPE_PAID   as varchar(10),
@p_CRM_SUPPLY_TYPE_FREE   as varchar(10),
@p_CURRENCY_MEASUREMENT   as varchar(5)


AS
declare @query as varchar(8000)
declare @query1 as varchar(8000)
/*
set @query='update login set date_format='''+@dateformat+''' , Autogenerate='''+@code+''',curr_code='''+@curr+''' where com_code='''+@compcode+'''   '
exec(@query)

set @query1='update preferrences set RATE_COMPANY_AGENCY='''+@ratecompany+''',ADDITIONAL_AGENCY_COMM='''+@addagenycomm+''',
AGENCY_RETAINER_COMM='''+@agencycommlinkretainer+''',SUBEDITIONRATE='''+@subeditionr+''',DIS_BILLTYPE='''+@displaybilltype+''',
CLS_BILLTYPE='''+@classifiedbilltype+''',autogenerated='''+@code+''',currency_code='''+@curr+''' ,rate_gr_code='''+@ratecode+''' , 
date_format='''+@dateformat+''',solo='''+@solo+''',breakup='''+@breakup+''' ,blackwhitecode='''+@bwcode+''',  rostatus='''+@rostatus+''',
File_name='''+@filename+''',Tfn='''+@tfn+''',Insert_breakup='''+@insertbreak+''',Premium_type='''+@prem+''',Deal_type='''+@dealtype+'''  ,    
prefix='''+@pre+''', suffix='''+@suff+'''  ,     financestatus='''+ @financestatus+''' , voucherst='''+@voucherst+''',Ad_category='''+@adcode+''' ,
Ro_datetime='''+@rodatetime+''' ,Space_area='''+@spacearea+''',Vat='''+@vat+''' ,Booking_status='''+@bookstat+''' ,Cio_id='''+@cio_id+''',
Receipt_no='''+@receipt_no+''' ,uom_code='''+@uom+''',Bgcolor_publication='''+@bgcolor+''' ,chkfor_valid_pubdates='''+@validdate+''', 
Agency_ratecode='''+@agencyratecode+''',   audit='''+@audit+''', book_insert_date='''+@book_insert_date+''',agencycomm='''+@agencycomm+''',
rate_audit='''+@rateaudit+''',bill_audit='''+@billaudit+''', billtype='''+@billtype+''', invoice_no='''+@invoice_no+''' , 
copy_booking='''+@copybooking+''', BILLING_FORMAT='''+@billformat+''' , RATE_CHECK='''+@ratechk+''', ALL_PACKAGE='''+@allpkg+''',
DAYRATE='''+@dayrate1+''' ,SCHEME_TYPE='''+@schemetype+'''    ,DISP_CLSBILL='''+@PIncludeclassi+ '''  , RECEIPT_FORMAT ='''+@receiptformat+''',
CASH_RECEIPT_BILL='''+@cash_receipt+''', BILL_ORDERWSLAST='''+@bill_orderwiselast+''',FLOOR_CHK='''+@floor_chk+''' ,
Unsold_Entry_Flag='''+@Unsoldflag+''' ,Supply_Stop_Percentage='''+@Supplystopper+''',ROKEYCHECK='''+@drpRokeychk+''',
AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''',DISP_CASHBILL='''+@cashindisplay+''',
CLA_CASHBILL='''+@cashinclassified+''',RATE_AUDIT_PREF='''+@rate_audit_pref+''',BARCODING_ALLOWED='''+@v_barcoding_allow+''', 
FMG_BILL_DIS='''+@v_fmgbills+''',BILL_DISP_CASHBILL='''+@v_billed_cashdis +''',BILL_CLA_CASHBILL ='''+@v_billed_cashcls+''',
BACKDATERECEIPT='''+@v_drpbackdate+''',DOCKIT_BOOKING='''+@dockitbooking+''',Allowed_old_date='''+@allowprevbooking+''',
ROWISE_CASHBOOKING='''+@ro_wisecashbill+''' where    comp_code='''+@compcode+'''   ' 
*/
/*********************************************************************************************************/
UPDATE LOGIN SET date_format=@dateformat, Autogenerate=@code,curr_code=@curr WHERE COM_CODE=@compcode

UPDATE PREFERRENCES SET  autogenerated=@code,
currency_code=@curr ,
rate_gr_code=@ratecode,
date_format=@dateformat,solo=@solo,breakup=@breakup,
blackwhitecode=@bwcode,rostatus=@rostatus,File_name=@filename,Tfn=@tfn,
Insert_breakup=@insertbreak,Premium_type=@prem,Deal_type=@dealtype  ,
 prefix=@pre, suffix=@suff, financestatus=@financestatus , voucherst=@voucherst,
 Ad_category=@adcode ,Ro_datetime=@rodatetime ,Space_area=@spacearea,Vat=@vat,
 Booking_status=@bookstat,Cio_id=@cio_id,Receipt_no=@receipt_no,uom_code=@uom,
 Bgcolor_publication=@bgcolor ,chkfor_valid_pubdates=@validdate, Agency_ratecode=@agencyratecode,
  audit=@AUDIT,book_insert_date=@book_insert_date,agencycomm=@agencycomm,
  rate_audit=@rateaudit,bill_audit=@billaudit,billtype=@billtype,invoice_no=@invoice_no,
  copy_booking=@copybooking,RATE_COMPANY_AGENCY=@ratecompany, ADDITIONAL_AGENCY_COMM=@addagenycomm ,
  AGENCY_RETAINER_COMM=@agencycommlinkretainer,SUBEDITIONRATE=@subeditionr,
  CLS_BILLTYPE=@classifiedbilltype,DIS_BILLTYPE=@displaybilltype,BILLING_FORMAT=@billformat,
  RATE_CHECK=@ratechk,ALL_PACKAGE=@allpkg,dayrate=@dayrate1,SCHEME_TYPE=@schemetype,DISP_CLSBILL=@PIncludeclassi   ,
  CASH_RECEIPT_BILL=@cash_receipt, BILL_ORDERWSLAST=@bill_orderwiselast, FLOOR_CHK=@floor_chk ,
  Unsold_Entry_Flag=@Unsoldflag ,Supply_Stop_Percentage=@Supplystopper,ROKEYCHECK=@drpRokeychk ,
  AGENCYCOMM_SEQ_COM=@Agencycomm_seq ,CREDIT_RECIPT=@creditreciept,DISP_CASHBILL=@cashindisplay,
  CLA_CASHBILL=@cashinclassified,RATE_AUDIT_PREF=@rate_audit_pref,BARCODING_ALLOWED=@v_barcoding_allow,
  FMG_BILL_DIS =@v_fmgbills, BILL_DISP_CASHBILL=@v_billed_cashdis , BILL_CLA_CASHBILL=@v_billed_cashcls,BACKDATERECEIPT=@v_drpbackdate,DOCKIT_BOOKING=@dockitbooking,Allowed_old_date=@allowprevbooking,ROWISE_CASHBOOKING=@ro_wisecashbill,CUTOFFTIME=@chkval,APPROVAL=@approval1,back_days=@pckstatus,CASH_DISCOUNT=@cash_amt,CASH_DISCOUNTTYPE=@cash_disc,SEPRATE_CASHIER=@seperate_cashier1,
 CIR_MANY_TIME_POSTING=@mantimepost, CIR_BACKDAYS_POSTING=@bkdaypost, CIR_MAX_RETURN_ALLOW=@maxterutn, CIR_RETURN_LIMIT_ALLOW=@cir_return, CIR_NO_OF_CHQBOUNCE=@noofchkbounc, CIR_DAYS_CHQBOUNCE=@noofdaychkrec, CIR_RETURN_DAYS=@retday, CIR_SUP_ORDER_LIMIT=@chngsuppord, DISP_BILLING_CRITERIA=@disp_bill, CLSD_BILLING_CRITERIA=@clas_bill,MAX_PUBLISHDAYS=@max_publishday,
 BILLNO_PERIODICITY=@p_billno_period,SPECIALDISC_TRANS_EDIT=@spl_trans_edit, SHARING_TRANS=@spl_dis_trans_editable, MULTIPACKAGE_SEL_TRANS=@mul_pac_sel_trans,SCHEME_MINWORD=@shmon_minword, TRADE_SPLCHARGE=@tradon_spcrg,RATE_AUTHORIZATION=@rateauth
  ,F2_RECORD=@f2day,PUBLISHAD_EDIT_RATEAUDIT=@rateauditmodify,BINDREVENUE_CENTER=@bindrevenuecenter,
FA_LEDGER_ALLOW=@p_led_allow,CLEARANCE_TYPE_ALLOW=@p_clear_allow,REPEAT_DAY_TYPE=@repeatday,PREMIUM_EDIT=@premiumedit,

BILL_GENERATION_PRIOR=@P_BILL_GENERATION,PUBLICATION_HO=@P_PUBLICATION_CENTER,

SPLDISC_ALLOWPREM=@P_allow_discount_prem,BILL_SCHEME=@P_SCHEME_BILLING,

ALLOWED_PDC_DAYS_RECEIPT=@P_ALLOW_PDC,AD_TYPE_MANUL_BILL=@PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=@RO_OUTSTAND_P,GENRATE_CIR_AGCD=@genrate_agency_code,DISP_AUDITBKG=@p_dispauditbk,CIR_DIS_AUTO_POSTING=@p_aotosupply,RELAUTHREQON=@p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=@p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=@p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=@p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=@p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=@p_CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL=@p_AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE=@p_CIR_BILL_PUBLWISE,
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=@p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=@p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=@p_CURRENCY_MEASUREMENT
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)







































/**************/


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





















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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT
           FROM PREFERRENCES
          WHERE comp_code = @compcode































/***********************mimoh 28dec 2011*********6162****************************************/









/***********************mimoh 28dec 2011*********deal****************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[tv_dealAudit]
   @compcode_p     VARCHAR(20),
   @adtype_p               VARCHAR(20),
   @validfrom_p            datetime,
   @validto_p           datetime,
   @agency_p             VARCHAR(20),
   @client_p           VARCHAR(20),
   @dealno_p                VARCHAR(20),
   @audittype_p             VARCHAR(20),
   @dateformat_p            VARCHAR(20)
AS
BEGIN
  SELECT (select Agency_Name+'('+ Agency_Code +')' from agency_mast where Agency_Code=contract_mast.Agency_code and agency_mast.SUB_Agency_Code=contract_mast.Sub_Agency_Code and Comp_Code=@compcode_p) as Agency_code,
      (select Cust_Name+'('+Cust_Code+')' from cust_mast where Cust_Code=Client_code and Comp_Code=@compcode_p) as Client_code,Deal_No,deal_name,
      Product_code,CAPTION,
	case @dateformat_p
	when 'dd/mm/yyyy' then convert(varchar(10),from_date,103)
	when 'mm/dd/yyyy' then convert(varchar(10),from_date,101)
	when 'yyyy/mm/dd' then convert(varchar(10),from_date,111)
	else convert(varchar(10),from_date,101)
	end as 'FROM_DATE' ,
		case @dateformat_p
	when 'dd/mm/yyyy' then convert(varchar(10),till_date,103)
	when 'mm/dd/yyyy' then convert(varchar(10),till_date,101)
	when 'yyyy/mm/dd' then convert(varchar(10),till_date,111)
	else convert(varchar(10),till_date,101)
	end as 'Till_DATE',
      '' as TOTALVAL
        FROM contract_mast
       WHERE Comp_code = @compcode_p
       AND Creation_datetime BETWEEN @validfrom_p and @validto_p
        AND (Deal_No = @dealno_p OR @dealno_p IS NULL OR @dealno_p = '')
         AND (DEALON = @adtype_p OR @adtype_p IS NULL OR @adtype_p = '')
         AND(Agency_code LIKE @agency_p+'%'OR @agency_p IS NULL)
         AND (Client_code = @client_p OR @client_p IS NULL OR @client_p = '');
END


/*****************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[tv_dealauditupdate]
	@pdealno                                  VARCHAR(4000) ,
	@puserid                                  VARCHAR(4000) ,
	@premark                                  VARCHAR(4000) 
AS 
	BEGIN
		SET NOCOUNT ON
		
		UPDATE  contract_mast   
		SET	AUDITBY = @puserid,	
		    AUDIT_DATE = GETDATE(),	
		    AUDIT_COMMENT = @premark 
		WHERE  'Deal_No'  = @pdealno 
		
		UPDATE  tv_deal_det   
		SET	APPROVED = 'Y' 
		WHERE  DEALNO  = @pdealno 
		
		
		-- IMPLICIT_TRANSACTIONS is set to OFF

		SET NOCOUNT OFF

	END

/************************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go






ALTER PROCEDURE [dbo].[bindagencyforbooking]
@compcode as varchar(8),
@userid as varchar(8),
@agency varchar(1000)
 AS

--select  distinct  code_subcode,agency_name,((select City_Name from  city_mst where Comp_Code=@compcode and City_Code=agency_mast.City_Code)+'-'+Add1++'-'+Add2+'-'+Add3+Street) as CITYNAME  from Agency_mast where comp_code=@compcode   and agency_name like @agency+'%' order by agency_name
--if pubcenter = '0' or pubcenter is null
	--begin
		select  distinct  code_subcode,Agency_Name as "agency_name",(select City_Name from  city_mst where Comp_Code=@compcode and City_Code=agency_mast.City_Code)+'-'+Add1+'-'+Add2+'-'+Add3+Street
		AS CITYNAME from Agency_mast where Comp_Code=@compcode 
		and(isnull((SELECT top 1 status_name FROM STATUS_DETAIL WHERE  agency_code + agency_subcat_code = AGENCY_MAST.code_subcode  AND getdate() between FROM_DATE and TO_DATE),'AC0')='AC0'
			or (SELECT top 1 status_name FROM STATUS_DETAIL WHERE  agency_code + agency_subcat_code = AGENCY_MAST.code_subcode  AND getdate() between FROM_DATE and TO_DATE) ='')
		and Agency_Name like '%'+@agency+'%'  order by Agency_Name 
		
	/*end
else
	begin
		select  distinct  code_subcode,Agency_Name as agency_name,(select City_Name from  city_mst where Comp_Code=@compcode and City_Code=agency_mast.City_Code)+'-'+Add1+'-'+Add2+'-'+Add3+Street
		AS CITYNAME from Agency_mast where Comp_Code=@compcode and
		ISNULL((SELECT TOP 1 status_name FROM STATUS_DETAIL WHERE  agency_code + agency_subcat_code = AGENCY_MAST.code_subcode  AND GETDATE() between FROM_DATE and TO_DATE),'AC0')='AC0'
		and Agency_Name like '%'+@agency+'%' and Dist_Code=(select Dist_Code from branch_mst where Branch_Code=pubcenter) order by Agency_Name
	end 
*/






/***************************/



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







/*******************************/




set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER  PROCEDURE [dbo].[bindagencyforagency]
(
 @compcode    as       VARCHAR(8),
 @client      as       VARCHAR(16),
 @VALUE       as       VARCHAR(25),
 @datecheck   as       VARCHAR(25)
)
as
    
BEGIN
  
SELECT DISTINCT Agency_Code, Agency_Name,
                            (Add1+''+Add2+''+Add3) AS address
                       FROM agency_mast
                      WHERE Comp_Code = @compcode AND code_subcode = @client --and rownum<=1;
END 


/****************************/




set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





ALTER PROCEDURE [dbo].[bindsubagencyforcontract]
@compcode as varchar(8),
@userid as varchar(8)=null,
@agency as varchar(8)

 AS
declare @count as varchar(8)
--select SUB_Agency_Code,agency_name from agency_mast where comp_code=@compcode and userid=@userid and agency_code=@agency and type <> 'P'

select @count=count(*)  from agency_mast where comp_code=@compcode  and agency_code=@agency and type <> 'P'

if(@count>0)
begin
select SUB_Agency_Code,Agency_Name AS Agency_Name from agency_mast where comp_code=@compcode  and agency_code=@agency and type <> 'P'
end

else
begin
select SUB_Agency_Code,agency_name  AS Agency_Name from agency_mast where comp_code=@compcode  and agency_code=@agency and   type = 'P'
end

select add1 + ' ' + add2 + ' ' + add3 AS address from agency_mast where comp_code=@compcode  and agency_code=@agency


/*********************************/


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[tv_paid_balance_cal]
	@pcomp_code                               VARCHAR(4000) ,
	@punit_code                               VARCHAR(4000) ,
	@pchannel                                 VARCHAR(4000) ,
	@plocation_code                           VARCHAR(4000) ,
	@pad_type                                 VARCHAR(4000) ,
	@pdealno                                  VARCHAR(4000) ,
	@pbtb_code                                VARCHAR(4000) ,
	@ppaid_bonus                              VARCHAR(4000) 
AS 
	BEGIN
		SET NOCOUNT ON
		
		DECLARE @vdur                                     FLOAT 
		DECLARE @v_no                                     FLOAT 
		SELECT @vdur  =  SUM(CONVERT(FLOAT, ISNULL(dur, 0) * ISNULL(no_of_spot, 0)))
		FROM  tv_booking_det 
		WHERE	 bkkno  IN
			(
		 	SELECT bkkno
			FROM  tv_booking_mst 
			WHERE	 comp_code  = @pcomp_code
			 AND	unit_code  = @punit_code
			 AND	deal_no  = @pdealno
			 AND	(channel  = @pchannel
			 OR	@pchannel  IS NULL)
			 AND	(loccd  = @plocation_code
			 OR	@plocation_code  IS NULL)
			)
		 AND	btb_code  = @pbtb_code
		 AND	paid_bonus  = @ppaid_bonus
		
		
		SELECT @v_no  =  ISNULL(no_of_ins, 0)
		FROM  tv_deal_det 
		WHERE	 comp_code  = @pcomp_code
		 AND	unit  = @punit_code
		 AND	dealno  = @pdealno
		 AND	(channel  = @pchannel
		 OR	@pchannel  IS NULL)
		 AND	(location_code  = @plocation_code
		 OR	@plocation_code  IS NULL)
		 AND	btb_code  = @pbtb_code
		 AND	pb_flg  = @ppaid_bonus
		

		SELECT
				 @vdur AS "vdur",
				 ISNULL(@v_no, 0) - ISNULL(@vdur, 0) AS "vbal"
		

		SET NOCOUNT OFF

	END



/**********************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go







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
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE approved
    END as APPROVED,ContractCode as CONTRACTCODE
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








/*******************************************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[tv_binddealforaudit]
@compcode VARCHAR(4000) ,
@deal VARCHAR(4000),
@mod VARCHAR(4000)

AS
BEGIN
SET NOCOUNT ON


SELECT DISTINCT
Deal_No,
deal_name
FROM contract_mast
WHERE Comp_code = @compcode and DEALON=@mod
AND deal_name LIKE @deal + '%'



SET NOCOUNT OFF

END


/************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[bindproductforcontract]
@client as varchar(8),
@compcode as varchar(8),
@userid as varchar(8)

 AS

--select Product_Name,Product_Code from product_mast where comp_code=@compcode and @userid=@userid and Client_Name=@client

select Product_Name,Product_Code from client_pro_master 
where comp_code=@compcode  and Client_code=@client



/***********************mimoh 28dec 2011*********deal****************************************/



/***********************mimoh 30dec 2011*********deal*************6036***************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[tv_dealAudit]
   @compcode_p     VARCHAR(20),
   @adtype_p               VARCHAR(20),
   @validfrom_p            datetime,
   @validto_p           datetime,
   @agency_p             VARCHAR(20),
   @client_p           VARCHAR(20),
   @dealno_p                VARCHAR(20),
   @audittype_p             VARCHAR(20),
   @dateformat_p            VARCHAR(20)
AS
BEGIN
if @audittype_p='0'
begin
  SELECT (select Agency_Name+'('+ Agency_Code +')' from agency_mast where Agency_Code=contract_mast.Agency_code and agency_mast.SUB_Agency_Code=contract_mast.Sub_Agency_Code and Comp_Code=@compcode_p) as Agency_code,
      (select Cust_Name+'('+Cust_Code+')' from cust_mast where Cust_Code=Client_code and Comp_Code=@compcode_p) as Client_code,Deal_No,deal_name,
      Product_code,CAPTION,
	case @dateformat_p
	when 'dd/mm/yyyy' then convert(varchar(10),from_date,103)
	when 'mm/dd/yyyy' then convert(varchar(10),from_date,101)
	when 'yyyy/mm/dd' then convert(varchar(10),from_date,111)
	else convert(varchar(10),from_date,101)
	end as 'FROM_DATE' ,
		case @dateformat_p
	when 'dd/mm/yyyy' then convert(varchar(10),till_date,103)
	when 'mm/dd/yyyy' then convert(varchar(10),till_date,101)
	when 'yyyy/mm/dd' then convert(varchar(10),till_date,111)
	else convert(varchar(10),till_date,101)
	end as 'Till_DATE',
      '' as TOTALVAL
        FROM contract_mast
       WHERE Comp_code = @compcode_p
       AND Creation_datetime BETWEEN @validfrom_p and @validto_p
        AND (Deal_No = @dealno_p OR @dealno_p IS NULL OR @dealno_p = '')
         AND (DEALON = @adtype_p OR @adtype_p IS NULL OR @adtype_p = '')
         AND(Agency_code LIKE @agency_p+'%'OR @agency_p IS NULL)
         AND (Client_code = @client_p OR @client_p IS NULL OR @client_p = '');
         
  end      
  else if @audittype_p='1'
  begin
  SELECT (select Agency_Name+'('+ Agency_Code +')' from agency_mast where Agency_Code=contract_mast.Agency_code and agency_mast.SUB_Agency_Code=contract_mast.Sub_Agency_Code and Comp_Code=@compcode_p) as Agency_code,
      (select Cust_Name+'('+Cust_Code+')' from cust_mast where Cust_Code=Client_code and Comp_Code=@compcode_p) as Client_code,Deal_No,deal_name,
      Product_code,CAPTION,
	case @dateformat_p
	when 'dd/mm/yyyy' then convert(varchar(10),from_date,103)
	when 'mm/dd/yyyy' then convert(varchar(10),from_date,101)
	when 'yyyy/mm/dd' then convert(varchar(10),from_date,111)
	else convert(varchar(10),from_date,101)
	end as 'FROM_DATE' ,
		case @dateformat_p
	when 'dd/mm/yyyy' then convert(varchar(10),till_date,103)
	when 'mm/dd/yyyy' then convert(varchar(10),till_date,101)
	when 'yyyy/mm/dd' then convert(varchar(10),till_date,111)
	else convert(varchar(10),till_date,101)
	end as 'Till_DATE',
      '' as TOTALVAL
        FROM contract_mast
       WHERE Comp_code = @compcode_p
       AND Creation_datetime BETWEEN @validfrom_p and @validto_p
        AND (Deal_No = @dealno_p OR @dealno_p IS NULL OR @dealno_p = '')
         AND (DEALON = @adtype_p OR @adtype_p IS NULL OR @adtype_p = '')
         AND(Agency_code LIKE @agency_p+'%'OR @agency_p IS NULL)
         AND (Client_code = @client_p OR @client_p IS NULL OR @client_p = '')
         AND (AUDITBY IS not NULL);
  end
  else
  begin
  SELECT (select Agency_Name+'('+ Agency_Code +')' from agency_mast where Agency_Code=contract_mast.Agency_code and agency_mast.SUB_Agency_Code=contract_mast.Sub_Agency_Code and Comp_Code=@compcode_p) as Agency_code,
      (select Cust_Name+'('+Cust_Code+')' from cust_mast where Cust_Code=Client_code and Comp_Code=@compcode_p) as Client_code,Deal_No,deal_name,
      Product_code,CAPTION,
	case @dateformat_p
	when 'dd/mm/yyyy' then convert(varchar(10),from_date,103)
	when 'mm/dd/yyyy' then convert(varchar(10),from_date,101)
	when 'yyyy/mm/dd' then convert(varchar(10),from_date,111)
	else convert(varchar(10),from_date,101)
	end as 'FROM_DATE' ,
		case @dateformat_p
	when 'dd/mm/yyyy' then convert(varchar(10),till_date,103)
	when 'mm/dd/yyyy' then convert(varchar(10),till_date,101)
	when 'yyyy/mm/dd' then convert(varchar(10),till_date,111)
	else convert(varchar(10),till_date,101)
	end as 'Till_DATE',
      '' as TOTALVAL
        FROM contract_mast
       WHERE Comp_code = @compcode_p
       AND Creation_datetime BETWEEN @validfrom_p and @validto_p
        AND (Deal_No = @dealno_p OR @dealno_p IS NULL OR @dealno_p = '')
         AND (DEALON = @adtype_p OR @adtype_p IS NULL OR @adtype_p = '')
         AND(Agency_code LIKE @agency_p+'%'OR @agency_p IS NULL)
         AND (Client_code = @client_p OR @client_p IS NULL OR @client_p = '')
         AND (AUDITBY IS NULL OR AUDITBY = '')
         AND (AUDIT_DATE IS NULL OR AUDIT_DATE = '')
         AND (AUDIT_COMMENT IS NULL OR AUDIT_COMMENT = '');
         
  end
  
END


/*************************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[tv_dealauditupdate]
	@pdealno                                  VARCHAR(4000) ,
	@puserid                                  VARCHAR(4000) ,
	@premark                                  VARCHAR(4000) 
AS 
	BEGIN
		SET NOCOUNT ON
		
		UPDATE  contract_mast   
		SET	AUDITBY = @puserid,	
		    AUDIT_DATE = GETDATE(),	
		    AUDIT_COMMENT = @premark 
		WHERE  Deal_No  = @pdealno 
		
		UPDATE  tv_deal_det   
		SET	APPROVED = 'Y' 
		WHERE  DEALNO  = @pdealno 
		
		
		-- IMPLICIT_TRANSACTIONS is set to OFF

		SET NOCOUNT OFF

	END


/***********************mimoh 30dec 2011*********deal*************6036***************************/


/*======================================= ISSUE 0005976 (Kuldeep Bhati) ==============================*/

ALTER PROCEDURE GETAUTOCODEBOOKING_PRE_SAVE
@compcode as varchar(8),
@auto as varchar(8),
@no as varchar(8)

AS
declare @query as varchar(900)
declare @per as varchar(800)
declare @idcou as int
declare @maxid as int


select @idcou=max(Booking_id)+1 from ad_tableid_pre_save

if(@idcou>0)
begin
	set @query='select max(Booking_id)+1 as ID,datepart(year,getdate()) as YEAR1  from ad_tableid_pre_save'
	select @maxid= max(Booking_id)+1 from ad_tableid_pre_save
	--exec(@query)
	update Ad_tableid set Booking_id=@maxid
end
else
begin
	insert into ad_tableid_pre_save(Booking_id) values('1')
	set @query='select max(Booking_id) as ID,datepart(year,getdate()) as YEAR1 from ad_tableid_pre_save'
	--exec(@query)
end 
--print(@query)
exec(@query)
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER PROCEDURE [dbo].[getautocodebooking_new]
@compcode	as varchar(8),
@auto		as varchar(8),
@no			as varchar(8),
@bkid		as varchar(50)output,
@pyear		as varchar(8) output

AS
declare @query	as varchar(900)
declare @per	as varchar(800)
declare @idcou	as int
declare @maxid	as int

declare @v_bkid		as varchar(50)	
declare @v_pyear	as varchar(8)

if(@no='0') begin
	select @idcou=max(Booking_id)+1 from Ad_tableid

	if(@idcou>0) begin

		--set @query='select max(Booking_id)+1 as ID,datepart(year,getdate()) as YEAR1  from Ad_tableid'
		
		select @v_bkid=max(Booking_id)+1,@v_pyear=datepart(year,getdate())  from Ad_tableid
		
		select @maxid= max(Booking_id)+1 from Ad_tableid

		update Ad_tableid set Booking_id=@maxid
		--print(@query)
		--exec(@query)
		
		set @bkid	=@v_bkid
		set @pyear	=@v_pyear
	end
	else begin
		insert into Ad_tableid(Booking_id) values('1')
		
		--set @query='select max(Booking_id) as ID,datepart(year,getdate()) as YEAR1 from Ad_tableid'
		--print(@query)
		--exec(@query)
		select @v_bkid=max(Booking_id),@v_pyear=datepart(year,getdate()) from Ad_tableid
		
		set @bkid=@v_bkid
		set @pyear=@v_pyear
	end
end
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
			REVISE_DATE)
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
			REVISE_DATE
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

/*======================================= End of ISSUE 0005976 (Kuldeep Bhati) ==============================*/

====================================================ankit tyagi  6173=====================================================
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO







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
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT


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
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT


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
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT

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
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT


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
WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),tbl_booking_mast.Creation_datetime,102) END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT FROM 
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
============================================closed========================================================

/*====================================3jan2012===  mimoh mahajan ==============================*/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[getautocodebooking_pre_save]
@compcode	as varchar(8),
@auto		as varchar(8),
@no			as varchar(8)
--@center1 as varchar(8),
--@agncodesubcode as varchar(8)

AS
declare @query as varchar(900)
declare @per as varchar(800)
declare @idcou as int
declare @maxid as int

if(@no='0') begin
	select @idcou=max(Booking_id)+1 from Ad_tableid_pre_save

	if(@idcou>0) begin
		set @query='select max(Booking_id)+1 as ID,datepart(year,getdate()) as YEAR1  from Ad_tableid_pre_save'
		select @maxid= max(Booking_id)+1 from Ad_tableid_pre_save
		exec(@query)
		update Ad_tableid_pre_save set Booking_id=@maxid
		
		select 'a' as "a"
	end
	else begin
		insert into Ad_tableid_pre_save(Booking_id) values('1')
		set @query='select max(Booking_id) as ID,datepart(year,getdate()) as YEAR1 from Ad_tableid_pre_save'
		exec(@query)
		select 'a' as "a"
	end 

end



/*====================================3jan2012===  mimoh mahajan ==============================*/
/*====================================3jan2012===  mimoh mahajan ===5568===========================*/


CREATE OR REPLACE PACKAGE xlsBindexecnew
IS
   TYPE t_accounts_cursor IS REF CURSOR;
   PROCEDURE xlsBindexecnew_p (compcode IN VARCHAR2,userid IN VARCHAR2,name1 IN VARCHAR2,executive in varchar2,p_accounts OUT t_accounts_cursor);
END xlsBindexecnew;
/





CREATE OR REPLACE PACKAGE BODY xlsBindexecnew
IS
   PROCEDURE xlsBindexecnew_p (compcode IN VARCHAR2,
   userid IN VARCHAR2,
   name1 IN VARCHAR2,
   executive in varchar2,
   p_accounts OUT t_accounts_cursor)
   AS
   BEGIN
      OPEN p_accounts FOR
           SELECT "Exec_name", "Exe_no" FROM EXEC_MAST WHERE "comp_code" = compcode AND ("Team_code"=name1 or name1 is null) and "Exec_name" like  '%' || upper(executive) || '%' order by "Exec_name";
   END xlsBindexecnew_p;
END xlsBindexecnew;
/

/*******************/




CREATE OR REPLACE PACKAGE xlsRetainerbind
IS
  TYPE t_account_cursor IS REF CURSOR;
  PROCEDURE xlsRetainerbind_p(
  --Region VARCHAR2,
  Compcode VARCHAR2,
    retainer VARCHAR2,
  p_accounts OUT t_account_cursor
  );
  END xlsRetainerbind;
/





CREATE OR REPLACE PACKAGE BODY xlsRetainerbind
  IS
  PROCEDURE xlsRetainerbind_p(
  --Region VARCHAR2,
  Compcode VARCHAR2,
  retainer VARCHAR2,
  p_accounts OUT t_account_cursor
  )
  AS
  BEGIN
  OPEN p_accounts FOR
    SELECT  "Retain_Code","Retain_Name"  FROM RETAINERMASTER WHERE "Comp_Code"= Compcode and "Retain_Name" like '%' || upper(retainer) || '%' order by "Retain_Name" ;
END xlsRetainerbind_p;
END xlsRetainerbind;
/


/**********************************************************/



CREATE OR REPLACE PACKAGE bindagencyforxls  Is
Type T_Accounts_Cursor Is Ref Cursor;

Procedure  bindagencyforxls_p (
compcode in varchar2,
agency in varchar2,

p_Accounts Out T_Accounts_Cursor);

End bindagencyforxls;
/





CREATE OR REPLACE PACKAGE BODY bindagencyforxls Is
Procedure bindagencyforxls_p(
compcode in varchar2,
agency in varchar2,
p_Accounts Out T_Accounts_Cursor)
 As

qry  varchar2(2000);
Begin
Open P_Accounts For

--select  distinct  "Agency_Code","Agency_Name","code_subcode" from Agency_mast where ("Comp_Code"=compcode) and "Agency_Name" like ''|| agency||'''%'  and ("Type"='P') order by "Agency_Name";

select  distinct  "Agency_Code","Agency_Name","code_subcode", "SUB_Agency_Code","EmailID" from Agency_mast where ("Comp_Code"=compcode) and "Agency_Name" like  '%'|| agency || '%'  and ("Type"='P') order by "Agency_Name";




End bindagencyforxls_p;

End bindagencyforxls;
/
/**********************************/




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






/*====================================3jan2012===  mimoh mahajan ===5568===========================*/



/*================================================3jan2012===  ankit ===6181=========================================*/


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER Procedure [dbo].[Cat3_MODIFY]

@compcode as varchar(8),
@subcatname as varchar(8),
@catname as varchar(50),
@catalias as varchar(50),
@catcode as varchar(15),
@userid as varchar(8),
@xml as varchar(50),
@prior as int,
@status1   as varchar(5)
as

begin

update ad_cat3 set compcode=@compcode, subcatname=@subcatname,catname=@catname,catalias=@catalias,userid=@userid ,adminwebxml=@xml,PRIORITY=@prior,STATUS=@status1 where catcode=@catcode


end



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE  [dbo].[cat3save]
@compcode as varchar(8),
@subcatname as varchar(8),
@catname as varchar(50),
@catalias as varchar(50),
@catcode as varchar(15),
@userid as varchar(8),
@xml as varchar(50)=null,
@prior as int,
@status1   as varchar(5)

AS

insert into ad_cat3(compcode,subcatname,catname,catcode,catalias,userid,adminwebxml,PRIORITY,STATUS) values(@compcode,@subcatname,@catname,@catcode,@catalias,@userid,@xml,@prior,@status1)










set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE   [dbo].[CAT_EXE1]
@compcode as varchar(8),
@subcatname as varchar(50),
@catcode as varchar(15),
@catname as varchar(50),

@catalias as varchar(50),

--@userid as varchar(8),
@xml as varchar(50)
AS



declare @query  as   varchar(1000)



CREATE TABLE #ad_cat3 (
	 
	compcode varchar(8),
subcatname  varchar(50),
catcode  varchar(15),
catname  varchar(50),

catalias  varchar(50),

--userid   varchar(8),
adminwebxml varchar(50),
PRIORITY int,
STATUS varchar(5)
 
               )


set @query='insert into #ad_cat3 select compcode,subcatname,catcode,catname,catalias,adminwebxml,PRIORITY,STATUS from ad_cat3  where compcode='''+@compcode+''''

if(@subcatname<>'')

begin
set @query=@query+'and subcatname like ''%'+@subcatname+'%'''
end


if(@catcode <>  '')



begin


set @query= @query+' and  catcode like  ''%'+@catcode+'%'''
end


if(@catname <> '')



begin
set @query=@query+ ' and  catname like  ''%'+@catname+'%'''
end



if(@catalias <> '')


 
begin
set @query=@query+ ' and  catalias like  ''%'+@catalias+'%'''
end

if(@xml<>'')
begin
set @query=@query+'and adminwebxml like ''%'+@xml+'%'''
end

print(@query)
exec(@query)



select  *  from #ad_cat3  where compcode=@compcode
drop table #ad_cat3





/*================================================3jan2012===  ankit ===6181=========================================*/



/************************************************************4jan2012***********/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Getautocodebox](
@compcode      as       VARCHAR(50),
@auto1         as       varchar(50),
@no1          as        varchar(50),
@center1      as        varchar(50),
@agency_codescode as    varchar(50),
@branch as varchar(50),
@save_val as varchar(1)
) AS
declare @idcou   int
declare @maxid  int
declare @fatchboxadd  varchar(1000)

select top 1 @fatchboxadd=BOX_ADDRESS from branch_mst where Branch_Code=@branch and Comp_Code=@compcode

--SELECT @idcou=MAX(CONVERT(NUMERIC(8, 2), SUBSTRING(Box_no, 3, LEN(Box_no))))
--	FROM  AD_TABLEID 
SELECT @idcou= MAX(DBO.TRANSLATE(Box_no,'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz','0')) FROM  AD_TABLEID 
print(@idcou)
if @idcou<>0 
begin
print('idcou  not =0')
	--SELECT MAX(CONVERT(NUMERIC(8, 2), SUBSTRING(Box_no, 3, LEN(Box_no)))) AS boxno
	--FROM  AD_TABLEID 
select top 1 Box_no as boxno FROM  AD_TABLEID 
SELECT
			 Box_Charges_Native,
			 Box_Charges_Type
	FROM  BOX_MAST 
	WHERE	 Box_Code  = @no1
	 AND Comp_Code  = @compcode
set @idcou = @idcou + 1
Begin
  if ISNULL(@save_val,'?')='S' 
    UPDATE AD_TABLEID SET Box_no =  cast (@idcou as varchar(50))
End
end	
else
begin
 INSERT INTO AD_TABLEID(Box_no) VALUES ('1')
--SELECT MAX(CONVERT(NUMERIC(8, 2), SUBSTRING(Box_no, 3, LEN(Box_no)))) AS boxno
	--FROM  AD_TABLEID 
select top 1 Box_no as boxno FROM   AD_TABLEID 

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



/************************************************************4jan2012***********/


/************************************************************  4jan2012  ankit   5805  ************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
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
getdate() as "Rundate"
FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a
WHERE m.Comp_code='''+@compcode+''' AND
m.cio_booking_id=i.Cio_Booking_Id
AND m.Agency_sub_code=a.code_subcode 
 AND m.cio_booking_id not in(select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)
 and  lower(i.Insert_Status) !=''cancel''
and ((i.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )
AND  i.Insert_Date BETWEEN '''+@fromdate+''' AND '''+@dateto+'''
AND (('''+@rep+'''=''2'' and m.RETAINER is not null and m.RETAINER!=''0'')or('''+@rep+'''=''1'' and m.Executive_code is not null and m.Executive_code !=''0''))'

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



/************************************************************  4jan2012  ankit   5805  ************************/

/*******************************************mimoh***********0006156******4jan2012***********/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[wesp_ModultPrevDisp_user]
@compcode as varchar(8),
@userid as varchar(20)=null,
@userhome as varchar(20)=null,
@admin as varchar(20)=null,
@retainer_code as varchar(20),
@username as varchar(20),
@p_extra1 as varchar(25),
@p_extra2 as varchar(25)
AS
declare @agename  varchar(15)
--select distinct a.username,b.userid from module_detail b,login a where a.userid=b.userid

if(@admin='yes' and @userhome='Agency')
begin

	select @agename=agency_code from login where  userid =@userid

	select distinct username+ '(' + FIRSTNAME + ' ' + LASTNAME+')' as username,userid from login where com_code=@compcode and company_user='Agency'  and agency_code=@agename and (UPPER(username) like '%' +@username+ '%' or UPPER(LASTNAME) like '%' +@username+ '%') order by username
end
else
begin
	select distinct username+ '(' + FIRSTNAME + ' ' + LASTNAME+')' as username,userid,admin,company_user from login where com_code=@compcode  and (UPPER(username) like '%' +@username+ '%' or UPPER(LASTNAME) like '%' +@username+ '%') order by username
end



/*******************************************mimoh***********0006156******4jan2012***********/



/*******************************************mimoh*****************5jan2012***********/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[websp_get10clientName]
@compcode	varchar(50),
@client		varchar(50)
AS
declare @v_f2_record	numeric(10)
declare @v_str			varchar(2000)
    select @v_f2_record=f2_record from preferrences where "comp_code"=@compcode
    
    if @v_f2_record=0 or @v_f2_record is null  Begin
        set @v_f2_record=10
	End
    
	set @v_str =' select top '+cast(@v_f2_record as varchar)+' Cust_Code,Cust_Name,Add1 from cust_mast 
		where comp_code='''+@compcode+''' and cust_name like '''+@client+''+'%'+''' and (isnull(Cust_Status,''ACTIVE'')=''ACTIVE'' or Cust_Status='''' ) 
		order by Cust_Name'
	print(@v_str)
	exec(@v_str)




/*******************************************mimoh*****************5jan2012***********/



/*******************************************ANKIT******6197***********6jan2012***********/



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[branchinsert]

@compcode as varchar(8),
@userid as varchar(8),
@branchcode as varchar(8), 
@branchname as varchar(50),
@alias as varchar(50),
@address as varchar(50),
@street as varchar(30),
@city as varchar(8),
@dist as varchar(20),
@state as varchar(20),
@country as varchar(8),
@fax as varchar(30),
@pin as varchar(12),
@phone1 as varchar(15),
@phone2 as varchar(15),
@email as varchar(50),
@region as varchar(8),
@zone as varchar(8),
@pubcenter as varchar(20),
@boxadd as varchar(1000),
@pbranchnick as varchar(50)

AS

begin

insert into branch_mst([Comp_Code]
      ,[Branch_Code]
      ,[Branch_Name]
      ,[Branch_Alias]
      ,[Add1]
      ,[Street]
      ,[Country_Code]
      ,[State_Code]
      ,[Dist_Code]
      ,[City_Code]
      ,[Zip]
      ,[Phone1]
      ,[Phone2]
      ,[Fax]
      ,[EmailID]
      ,[UserId]
      ,[Creation_Datetime]
      ,[Region_code]
      ,[Zone_code]
      ,[pub_center]
      ,[BOX_ADDRESS],[BRANCH_NICK]) values( @compcode,  @branchcode, @branchname, @alias,  @address,  @street, @country,  @state,  @dist,  @city, @pin, @phone1,  @phone2 , @fax, @email,  @userid,  getdate(),@region,@zone,@pubcenter,@boxadd,@pbranchnick)

end











set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[branchupdate]

@compcode as varchar(8),
@userid as varchar(8),
@branchcode as varchar(8), 
@branchname as varchar(50),
@alias as varchar(15),
@address as varchar(50),
@street as varchar(30),
@city as varchar(8),
@dist as varchar(20),
@state as varchar(20),
@country as varchar(8),
@fax as varchar(30),
@pin as varchar(12),
@phone1 as varchar(15),
@phone2 as varchar(15),
@email as varchar(50),
@region as varchar(8),
@zone as varchar(8),
@pubcenter as varchar(20),
@boxadd as varchar(1000),
@pbranchnick as varchar(50)
AS

begin

update branch_mst set  Branch_Name= @branchname, Branch_Alias=@alias, Add1= @address, Street= @street,Country_Code= @country , State_Code= @state, Dist_Code=@dist, City_Code= @city, Zip=@pin, Phone1=@phone1,Phone2=  @phone2 ,Fax= @fax, EmailID=@email,Region_code=@region,Zone_code=@zone ,pub_center=@pubcenter,BOX_ADDRESS=@boxadd,BRANCH_NICK=@pbranchnick  where comp_code=@compcode and Branch_Code=@branchcode --and userid=@userid 


--update branchmstdummy set  Branch_Name= @branchname, Branch_Alias=@alias, Add1= @address, Street= @street,Country_Code= @country , State_Code= @state, Dist_Code=@dist, City_Code= @city, Zip=@pin, Phone1=@phone1,Phone2=  @phone2 ,Fax= @fax, EmailID=@email,Region_code=@region,Zone_code=@zone     where comp_code=@compcode and userid=@userid and Branch_Code=@branchcode

end








set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[branchexe]

@compcode as varchar(8),
@userid as varchar(8),
@branchcode as varchar(8), 
@branchname as varchar(50),
@alias as varchar(15),
@city as varchar(8),
@country as varchar(8),
@pubcenter as varchar(20)
--@dateformat as varchar(30)
AS


declare @query varchar(1000)

/*CREATE TABLE #branch_msttemp (
	Comp_Code varchar (8)  ,
	Branch_Code varchar (8)  ,
	Branch_Name varchar (50)  ,
	Branch_Alias varchar (15)  ,
	Add1 varchar (50)  ,
	Street varchar (50)  ,
	Country_Code varchar (8)  ,
	State_Code varchar (20)  ,
	Dist_Code varchar (20)  ,
	City_Code varchar (8)  ,
	Zip varchar (12)  ,
	Phone1 varchar (15)  ,
	Phone2 varchar (15)  ,
	Fax varchar (30)  ,
	EmailID varchar (50)  ,
	UserId varchar (8)  ,
	Creation_Datetime datetime NOT NULL ,
	Region_code varchar (8)  ,
	Zone_code varchar (8)  
)*/
set  @branchname=replace(@branchname,'''','''''')
set  @alias=replace(@alias,'''','''''')

--if(@dateformat='dd/mm/yyyy')
 -- begin
	set @query='select Comp_Code,Branch_Code,Branch_Name,Branch_Alias,Add1,Street,Country_Code,State_Code,Dist_Code,City_Code,Zip,Phone1,Phone2,Fax,EmailID,UserId, convert(varchar,Creation_Datetime,103) as Creation_Datetime,Region_code,Zone_code,pub_center,BOX_ADDRESS,BRANCH_NICK from branch_mst where comp_code='''+@compcode+''''--and userid= '''+@userid+''' '  
 -- end

/* else if(@dateformat='mm/dd/yyyy')
         begin
	set @query=' select Comp_Code,Branch_Code,Branch_Name,Branch_Alias,Add1,Street,Country_Code,State_Code,Dist_Code,City_Code,Zip,Phone1,Phone2,Fax,EmailID,UserId, convert(varchar,Creation_Datetime,101) as Creation_Datetime,Region_code,Zone_code,pub_center from branch_mst where comp_code='''+@compcode+''' '--and userid= '''+@userid+''' '  
         end */
if( @branchcode <> '' )

begin
set @query= @query +' and Branch_Code like ''%'+@branchcode+'%'' '
end

if( @branchname <> '' )

begin
set @query= @query +' and Branch_Name like ''%'+@branchname+'%'' '
end

if( @alias <> '' )

begin
set @query= @query +' and Branch_Alias like ''%'+@alias+'%'' '
end

if( @country <> '' and @country<> '0' )

begin
set @query= @query +' and Country_Code = ''%'+@country+'%'' '
end
if( @city <> ''  and @city <> '0')

begin
set @query= @query +' and City_Code = ''%'+@city+'%'' '
end

if(@pubcenter <> '' and @pubcenter <> '0' )

begin
set @query= @query +' and pub_center = '''+@pubcenter+''' '
end

print(@query)
exec( @query)

--select * from #branch_msttemp order by Branch_Code
--drop table #branch_msttemp


////////////////////////////////////////////ankit/////6197////////////////////////////////////////////////////////////////

/********************************mimoh*********************9jan***************************************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[bindratecodeforrevisedate]
@compcode as varchar(8),
@adcat as varchar(8),
@previsedate as varchar(25)


AS
if(@previsedate is null)
begin
if(@adcat='contract')
begin
select distinct rate_mast_code from rate_mast where comp_code=@compcode 
end
else
begin
select distinct rate_mast_code from rate_mast where comp_code=@compcode  and adv_cat_code=@adcat 
end
end
else
begin
if(@adcat='contract')
begin
select distinct rate_mast_code from rate_mast where comp_code=@compcode and @previsedate between Valid_From and Valid_To
end
else
begin
select distinct rate_mast_code from rate_mast where comp_code=@compcode  and adv_cat_code=@adcat and @previsedate between Valid_From and Valid_To
end
end

/********************************mimoh*********************9jan***************************************************************/


/********************************ankit********4885******6228*******11jan***************************************************************/

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

/********************************ankit********4885******6228*******11jan***************************************************************/


/************************mimoh contaract master*****************************************************************/
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

/************************mimoh contaract master*****************************************************************/

