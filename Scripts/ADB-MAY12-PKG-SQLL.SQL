
///////////////////////Start Isue No:7323(3/5/12)Diksha///////////////////////////////////////

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[adb_bindratecode]    Script Date: 05/03/2012 14:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE [dbo].[adb_bindratecode](
    @pcompcode       as  varchar(8),
    @pextra1         as  varchar(100),
    @pextra2         as  varchar(100)
    )

AS
begin
  select distinct "Rate_Mast_Code" from rate_mast where "Comp_code"=@pcompcode
    
end 

//////////////////////////////////end////////////////////////////////////////
///////


//////////////////////////issue no 7250///////////

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[Reportnew]    Script Date: 05/03/2012 17:10:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Reportnew]
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

set	@query='SELECT m.cio_booking_id AS CIOID,i.Edition as edition,
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),Insert_Date,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),Insert_Date,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),Insert_Date,111)  END AS "Ins.date" ,
a.Agency_Name AS Agency,(select "City_Name" from city_mst where "City_Code"=a."City_Code") as "AGENCY_CITY",
(SELECT  a.SUB_Agency_Code FROM AGENCY_MAST WHERE  a.Type <> ''P'' AND m.Agency_code=a.Agency_Code  AND m.Agency_sub_code=a.code_subcode and m.comp_code=a.comp_code) AS SubAg,
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code and CUST_MAST.comp_code=m.comp_code),Client_code)  AS Client,
(select COMBIN_MAST.Package_Name from combin_mast where COMBIN_MAST.comp_code=m.comp_code and COMBIN_MAST.Combin_Code  in(m.Package_code))AS Package,
i.Col_Code AS Color_code,
round(i.Size_Book,2) AS Area,
u.UOM_DESC  as "uom",
i.Height AS Depth,
i.Width  AS Width,
(SELECT ADVPOS_TYPE_MAST.Pos_Type_Alias FROM ADVPOS_TYPE_MAST WHERE i.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code  and i.comp_code=ADVPOS_TYPE_MAST.comp_code) AS Page,
m.Bullet_code AS BulletPremium ,
i.Page_Post AS PositionPremium ,
i.Premium1 AS PagePremium ,
RO_No AS "RoNo.",
CASE ro_status
WHEN ''2'' THEN ''Reservation''
WHEN ''1'' THEN ''Confirm'' END AS RoStatus,
(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=i.Ad_Cat and ADV_CAT_MAST.comp_code=i.comp_code) AS AdCat,
Rate_code AS RateCode,
m.Card_rate AS CardRate,
isnull(Agrred_rate,0) AS AgreedRate,
i.Bill_Amt  AS Amt,
m.Caption AS Cap,
Key_no AS "Key",
m.Trade_disc AS Disc,
i.Insert_Status AS Status,
i.Status_Material AS MatStatus,
(SELECT dbo.InitCap(Comp_Name) from comp_mst where Comp_Code='''+@compcode+''') AS companyname,
getdate() as Rundate,i.bill_no as "BILL_NO",i.bill_date as "BILL_DATE",
(select "Exec_name" from exec_mast where  "Exe_no" = m."Executive_code") as "EXECUTIVE",
(select "Retain_Name" from retainermaster where "Comp_Code"=m."Comp_code" and "Retain_Code"= m."RETAINER") as "RETAINER"
FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a,uom_mast u
WHERE m.Comp_code='''+@compcode+'''
 AND m.cio_booking_id=i.Cio_Booking_Id
 AND m.Agency_code=a.Agency_Code
 AND m.Agency_sub_code=a.code_subcode and m."Uom_code"=u."Uom_Code"
 AND m.cio_booking_id not in(select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)
/* and  lower(Insert_Status) !=''cancel'' */
and ((i.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )'

IF(@agname IS NOT NULL and @agname <> '')
begin
	set @query=@query+' and m.Agency_code ='''+@agname+''''
END

IF(@clientname IS NOT NULL and @clientname <> '')
begin
	set @query=@query+' and m.Client_code='''+@clientname +''''
END

/*IF(@status IS NOT NULL and @status<>'')
begin
set @query=@query+' and i.Insert_Status='''+@status+''''
END*/

IF(@status IS NOT NULL and @status<>'')
begin
	set @query=@query+' and i.Insert_Status='''+@status+''''
end
/*else
begin
set @query=@query+' and lower(Insert_Status) !=''cancel'' '
END*/ 

IF(@adtype1 IS NOT NULL and @adtype1 <>'')
begin
	set @query=@query+' and m.Ad_type_code='''+@adtype1+''''
END

IF(@Adcategory IS NOT NULL and @Adcategory<>'')
begin
	--set @query=@query+' and m.Ad_cat_code in('''+@Adcategory+''' )'
	set @query=@query+' and i.Ad_Cat in(select EDITION_NAME from #Results)'
END

IF(@pub_cent IS NOT NULL and @pub_cent<>'')
begin
	set @query=@query+'  and i.Pub_Cent_Code='''+@pub_cent+''''
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
	set @query=@query+'  and i.Edition_Code='''+@edition+''''
END

IF(@pub_name IS NOT NULL and @pub_name<>'')
begin
	set @query=@query+' and  i.Publication_Code='''+@pub_name+''''
END

IF(@pextra1 IS NOT NULL) Begin
    set @query = @query+'  and m."Uom_code"='''+@pextra1+''''
END

IF((@agtype IS NOT NULL and @agtype<>'') AND (@agtype <> 'Package') AND (@agtype <> 'Solo'))
begin
	set @query=@query+' and  m.Agency_type='''+upper(@agtype)+''''
END

IF(@descid IS NOT  NULL and @descid<>'')
begin
	set @query=@query+'  order by "'+@descid+'"'
	set @query=@query+''+@ascdesc+''
end
ELSE
begin
	set @query=@query+'  order by Insert_Date,m.cio_booking_id'
END

print(@query)
exec(@query)
END


////////////////////////end of issue no 7250//////////////////


=======start=========7356=====avinash03-may-2012===========================

CREATE PROCEDURE rate_expupdat
(
@compcode as varchar(10),
@expdate as  varchar(20),
@ratecod as varchar(100),
@extra1 as varchar(10)

)


AS 
begin

UPDATE Rate_Mast SET Valid_To=@expdate WHERE rateuniqueid=@ratecod;

 
end;


-------------------------





alter PROCEDURE rate_expiry
@compcode as varchar(10),
@adtypcod as varchar(10), 
@ratecod as varchar(10),
@categrycod as varchar(10),
@colorcod as varchar(10),
@uomcod as varchar(10),
@frdate as varchar(10),
@todate as varchar(10),
@packgcod as varchar(10),
@extra1 as varchar(10),
@extra2 as varchar(10)


AS

select Rate_Mast_Code,
 (Select distinct Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=rate_mast.Adv_Cat_Code) as Adv_Cat_Code
 ,Color,(select distinct Uom_Name from uom_mast where Uom_Code=Uom) as Uom,
 (select distinct premiumname from advpos_prem_mast where Premiumcode=Premium) as Premium,Size_To,Size_From,
 From_insertion,To_insertion,
 (select distinct Package_Name from combin_mast where combin_mast.Combin_Code=rate_mast.Combin_Code) as Package_Name,
       Week_Day_Rate,Week_Extra_Rate,rateuniqueid from Rate_Mast where
        (Adv_Type_Code=@adtypcod or @adtypcod is null )
         and (Rate_Mast_Code=@ratecod or  @ratecod is null)
       and (Adv_Cat_Code=@categrycod or  @categrycod is null)
        and (Color=@colorcod or  @colorcod is null)
         and (Uom=@uomcod or  @uomcod is null)
         and (Combin_Code=@packgcod or @packgcod is null)
       and (Valid_From=@frdate and Valid_To=@todate) 



========end========7356=====avinash03-may-2012===========================


========start========7356=====avinash04-may-2012===========================
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




ALTER PROCEDURE [dbo].[rate_expiry]
@compcode as varchar(10),
@adtypcod as varchar(10), 
@ratecod as varchar(10),
@categrycod as varchar(10),
@colorcod as varchar(10),
@uomcod as varchar(10),
@frdate as varchar(10),
@todate as varchar(10),
@packgcod as varchar(10),
@extra1 as varchar(10),
@extra2 as varchar(10)


AS

select Rate_Mast_Code,
 (Select distinct Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=rate_mast.Adv_Cat_Code) as Adv_Cat_Code
 ,Color,(select distinct Uom_Name from uom_mast where Uom_Code=Uom) as Uom,
 upper((select distinct premiumname from advpos_prem_mast where Premiumcode=Premium)) as Premium,Size_To,Size_From,
 From_insertion,To_insertion,
 (select distinct Package_Name from combin_mast where combin_mast.Combin_Code=rate_mast.Combin_Code) as Package_Name,
       Week_Day_Rate,Week_Extra_Rate,rateuniqueid from Rate_Mast where
        (Adv_Type_Code=@adtypcod or @adtypcod is null )
         and (Rate_Mast_Code=@ratecod or  @ratecod is null)
       and (Adv_Cat_Code=@categrycod or  @categrycod is null)
        and (Color=@colorcod or  @colorcod is null)
         and (Uom=@uomcod or  @uomcod is null)
         and (Combin_Code=@packgcod or @packgcod is null)
       and (Valid_From=@frdate and Valid_To=@todate) 


========end========7356=====avinash04-may-2012===========================

//===========================PAtch for Adon in combin_mast (Kuldeep Bhati)==================//
CREATE  PROCEDURE COMBINADON_INS_UPD_DEL (
                                         @PCOMP_CODE        AS VARCHAR(20),
                                         @PCOMBIN_CODE      AS VARCHAR(50),
                                         @PADON_CODE        AS VARCHAR(20),
                                         @PPACKAGE_CODE     AS VARCHAR(100),
                                         @PPUBLICATION      AS VARCHAR(500),
                                         @PNO_OF_INSERT     AS VARCHAR(100),
                                         @PUSERID           AS VARCHAR(50),
                                         @PTRN_TYPE         AS VARCHAR(20), --'I' For Insert, 'U' For Update, 'D' For Delete & 'E' For Execute
                                         @PEXTRA1           AS VARCHAR(500), --for PPACKAGE_NAME
                                         @PEXTRA2           AS VARCHAR(100), 
                                         @PEXTRA3           AS VARCHAR(100), 
                                         @PEXTRA4           AS VARCHAR(100),  
                                         @PEXTRA5           AS VARCHAR(100)
                                         )AS
BEGIN
 IF ISNULL(@PTRN_TYPE,'?')='I'
	 BEGIN
     INSERT INTO COMBIN_ADONS_DETAILS (COMBIN_CODE,  PACKAGE_CODE, --ADON_CODE,
                                        COMP_CODE, USERID, CRATEION_DATETIME,
                                         PUBLICATION, NO_OF_INSERT,PACKAGE_NAME)
                         VALUES (@PCOMBIN_CODE, @PPACKAGE_CODE, -- @AD_COMBINADON_SEQ.NEXTVAL,
                                        @PCOMP_CODE, @PUSERID, getdate(),
                                         @PPUBLICATION, @PNO_OF_INSERT,@PEXTRA1)
  END
  IF isnull(@PTRN_TYPE,'?')='U' 
  Begin
    UPDATE COMBIN_ADONS_DETAILS  SET --COMBIN_CODE=PCOMBIN_CODE, PACKAGE_CODE=PPACKAGE_CODE, 
                                    -- PUBLICATION=PPUBLICATION,,PACKAGE_NAME=PEXTRA1
                                      NO_OF_INSERT=@PNO_OF_INSERT
                   WHERE COMP_CODE = @PCOMP_CODE
                     AND ADON_CODE  = @PADON_CODE
                    
  END 
  IF isnull(@PTRN_TYPE,'?')='D' 
  Begin
     DELETE FROM COMBIN_ADONS_DETAILS
           WHERE COMP_CODE = @PCOMP_CODE
            AND ADON_CODE  = @PADON_CODE
  END 

END

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE  procedure bindsolopackage4combin
(
@compcode   AS VARCHAR(20),
@pubcode AS VARCHAR(50),
@padtype AS VARCHAR(20)
)as

begin

select "Combin_Code","Combin_Desc" from combin_mast where charindex("Combin_Desc",'+')<=0 and "Ad_Type_code"=@padtype
and "Combin_Desc" like @pubcode+'%'
end 
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE  procedure filladongrid4combin
(
@PCOMPCODE   AS VARCHAR(20),
@PADONCODE as VARCHAR(20)
)as

begin

select ADON_CODE, PUBLICATION AS "Pubcode",PACKAGE_CODE AS "Edition_code" , NO_OF_INSERT ,PACKAGE_NAME
    from COMBIN_ADONS_DETAILS where ADON_CODE=@PADONCODE and COMP_CODE=@PCOMPCODE;


end 
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE  procedure bindadongrid4combin
(
@PCOMPCODE   as VARCHAR(20),
@PCOMBINCODE as VARCHAR(50)
)as

begin

select ADON_CODE, PUBLICATION AS "Pubcode",PUBLICATION AS "Publication", PACKAGE_CODE AS "Edition_code" ,PACKAGE_NAME AS "Edition" , NO_OF_INSERT AS "noofinsert"
    from COMBIN_ADONS_DETAILS where COMBIN_CODE=@PCOMBINCODE and COMP_CODE=@PCOMPCODE;


end 

//===========================End PAtch for Adon in combin_mast (Kuldeep Bhati)==================//



/////////////////////issue no 7423/////////////////////

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[wesp_updatedate1]    Script Date: 05/05/2012 12:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











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
@p_CURRENCY_MEASUREMENT   as varchar(5),

@p_EDITABLE_AGENCY_COMM as varchar(1),
@p_CANCELLATION_CHARGE as varchar(1),
@P_taxi_entry_type     as VARCHAR(1),
@P_ApprovalWith          as VARCHAR(1),
@p_Auto_TDS_Credit_Note as varchar(1),
@p_TDS_Reason as varchar(10),
@p_Debit_Account_Head as varchar(10),
@p_credit_Account_Head as varchar(10),
@p_service_tax_credit_note as varchar(1),
@p_Tax_Reason as varchar(10),
@p_Debit_Account_Service_Tax as varchar(10),
@p_Credit_Account_Service_Tax as varchar(10),
@p_Auto_Patrakar_Credit_Note as varchar(1),
@p_Patrakar_Reason as varchar(10),
@p_Debit_Account_Patrakar as varchar(10),
@p_Credit_Account_Patrakar as varchar(10),
@p_Auto_Bank_Credit_Note as varchar(1),
@p_Bank_Reason as VARCHAR(10),
@p_Debit_Account_Bank as varchar(10),
@p_Credit_Account_Bank as varchar(10),
@P_BAR_CODE as VARCHAR(5),
@P_GEN_RCT_NO as VARCHAR(5),

@P_WEIGHT_CAL as VARCHAR(5)

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
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=@p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=@p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=@p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM =@p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE =@p_CANCELLATION_CHARGE,taxi_entry_type=@P_taxi_entry_type,APPROVAL_WITH =@P_ApprovalWith,

TDS_AUTO_CN=@p_Auto_TDS_Credit_Note,
TDS_AUTO_REASON=@p_TDS_Reason ,TDS_DB_CDP=@p_Debit_Account_Head,TDS_CR_CDP=@p_credit_Account_Head,SER_TAX_AUTO_CN=@p_service_tax_credit_note,SER_TAX_AUTO_REASON=@p_Tax_Reason,SER_TAX_DB_CDP=@p_Debit_Account_Service_Tax,SER_TAX_CR_CDP=@p_Credit_Account_Service_Tax,PKK_AUTO_CN=@p_Auto_Patrakar_Credit_Note,PKK_AUTO_REASON=@p_Patrakar_Reason ,PKK_DB_CDP=@p_Debit_Account_Patrakar,PKK_CR_CDP=@p_Credit_Account_Patrakar ,BANK_CHG_AUTO_CN=@p_Auto_Bank_Credit_Note ,
BANK_CHG_AUTO_REASON=@p_Bank_Reason ,BANK_CHG_DB_CDP=@p_Debit_Account_Bank ,BANK_CHG_CR_CDP=@p_Credit_Account_Bank,

 CIR_BARCODE= @P_BAR_CODE,CIR_WIEGHT_CALC_REQ= @P_WEIGHT_CAL,GEN_RCT_TYP = @P_GEN_RCT_NO

 
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)





//////////////////end of issue vno 7423///////////////


/////////////////////////issue no 7429(7/05/2012)////////////////////////

USE [upkar]
GO
/****** Object:  UserDefinedFunction [dbo].[getadd]    Script Date: 05/07/2012 11:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






ALTER function [dbo].[getadd](@compcode varchar(50),@cioid varchar(50)) returns varchar(400)
as
begin
declare @billto as varchar(50)
declare @clientname varchar(200)
declare @clientadd as varchar(200)
declare  @citycode  as  varchaR(200)
declare  @cityname  as  varchaR(200)
declare @address1 as varchar(200)
declare @address2 as varchar(200)
declare @address3 as varchar(200)
declare @street_new as varchar(200)

declare @l_no as varchar(200)


set @clientadd=''
set @l_no=''


 select @billto=Bill_to from tbl_booking_mast where cio_booking_id=@cioid;

select @address1=agency_mast.add1,@address2=agency_mast.add2,@address3=agency_mast.add3,@street_new=street from agency_mast where SUB_Agency_Code=@billto;





if(@address1<>'' and  @address2 ='' and   @address2 ='' and @street_new='')
begin
select @clientadd=isnull(agency_mast.add1,''),@clientname=Agency_Name,@citycode=city_code from agency_mast where SUB_Agency_Code=@billto;
end

else
if(@address1<>'' and  @address2 <> ''  and @address3='' and @street_new='')
begin
select @clientadd=isnull(agency_mast.add1+' ,'+agency_mast.add2,''),@clientname=Agency_Name,@citycode=city_code from agency_mast where SUB_Agency_Code=@billto;
end

else
if(@address1<>'' and  @address2 <>'' and @address3 <>'' and @street_new='' )
begin
select @clientadd=isnull(agency_mast.add1+' ,'+agency_mast.add2+' ,'+agency_mast.add3,''),@clientname=Agency_Name,@citycode=city_code from agency_mast where SUB_Agency_Code=@billto;
end



else
if(@address1<>'' and  @address2 <>'' and @address3 <>'' and  @street_new<>'')
begin
select @clientadd=isnull(agency_mast.add1+' ,'+agency_mast.add2+' ,'+agency_mast.add3+' ,'+agency_mast.street,''),@clientname=Agency_Name,@citycode=city_code from agency_mast where SUB_Agency_Code=@billto;
end


if(@clientadd = '' or @clientadd is null)begin
select @clientadd= isnull(ADD1,''),@clientname=Cust_Name from cust_mast  where Cust_Code=@billto; 
end

if(@clientadd =''  or  @clientadd is null )
begin
select @clientadd=isnull(Client_address,''),@clientname=Client_code from tbl_booking_mast where cio_booking_id=@cioid;
end 


if(@citycode !='')
begin


select @cityname=city_name from city_mst where  city_code=@citycode
enD

if(@l_no='')
begin
select @l_no= isnull(OLD_CLIENT_CODE,'') from cust_mast  where Cust_Code=@billto; 

end



if(@l_no<>'')
begin
select @l_no=isnull(agency_mast.OLD_AGENCY,'')  from agency_mast where SUB_Agency_Code=@billto;
end


return (@clientadd+'$$'+@clientname+'$$'+@cityname+'$$'+@l_no)
end

///////////////////end issue no7429//////////////////////


////////////////////again in 7423//////////////////////
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[currbindpreferpgld]    Script Date: 05/07/2012 13:13:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,Space_area,EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE,TAXI_ENTRY_TYPE,APPROVAL_WITH,   TDS_AUTO_CN,TDS_AUTO_REASON,TDS_DB_CDP,TDS_CR_CDP,SER_TAX_AUTO_CN,SER_TAX_AUTO_REASON,SER_TAX_DB_CDP,SER_TAX_CR_CDP,PKK_AUTO_CN,PKK_AUTO_REASON,PKK_DB_CDP,PKK_CR_CDP,BANK_CHG_AUTO_CN,BANK_CHG_AUTO_REASON,BANK_CHG_DB_CDP,BANK_CHG_CR_CDP ,


CIR_BARCODE,CIR_WIEGHT_CALC_REQ,GEN_RCT_TYP

           FROM PREFERRENCES
          WHERE comp_code = @compcode







/////////////////////end of again 7423///////////



/////////////////start issue no:7447(7/05/2012)/////////////////










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
    
    (select ad_cat3."catname" from ad_cat3,adv_subcat_mast where tbl_booking_mast."Ad_Subcat3"=ad_cat3."catcode" and ad_cat3."subcatname"=adv_subcat_mast."Adv_Subcat_Code" and TBL_BOOKING_INSERT ."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and TBL_BOOKING_INSERT ."Ad_Cat"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat3",
    
(SELECT "premiumname" FROM ADVPOS_PREM_MAST WHERE ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_MAST."Page_prem") AS  Page_prem1 ,


(SELECT distinct adv_subcat_mast."Adv_Subcat_Name" FROM adv_subcat_mast  WHERE adv_subcat_mast ."Adv_Subcat_Code"=TBL_BOOKING_INSERT ."Ad_Sub_Cat") AS "Sub_cat",

(SELECT ADVPOS_PREM_MAST."premiumname" FROM  ADVPOS_PREM_MAST WHERE TBL_BOOKING_insert."Premium1" =ADVPOS_PREM_MAST ."Premiumcode")AS "Page_prem",

(SELECT ADVPOS_TYPE_MAST."Pos_Type" FROM  ADVPOS_TYPE_MAST WHERE TBL_BOOKING_insert."Page_Post" =ADVPOS_TYPE_MAST  ."Pos_Type_Code")AS "Page_pos"

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








////////////////////end issueno:7447////////////////////////

////////////////issue no:7400(7/5/2012)////////////////////////////

USE [upkar]
GO
/****** Object:  UserDefinedFunction [dbo].[getadd]    Script Date: 05/07/2012 16:03:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






ALTER function [dbo].[getadd](@compcode varchar(50),@cioid varchar(50)) returns varchar(400)
as
begin
declare @billto as varchar(50)
declare @clientname varchar(200)
declare @clientadd as varchar(200)
declare  @citycode  as  varchaR(200)
declare  @cityname  as  varchaR(200)
declare @address1 as varchar(200)
declare @address2 as varchar(200)
declare @address3 as varchar(200)
declare @street_new as varchar(200)

declare @l_no as varchar(200)


set @clientadd=''
set @l_no=''


 select @billto=Bill_to from tbl_booking_mast where cio_booking_id=@cioid;

select @address1=agency_mast.add1,@address2=agency_mast.add2,@address3=agency_mast.add3,@street_new=street from agency_mast where SUB_Agency_Code=@billto;





if(@address1<>'' and  @address2 ='' and   @address2 ='' and @street_new='')
begin
select @clientadd=isnull(agency_mast.add1,''),@clientname=Agency_Name,@citycode=city_code from agency_mast where SUB_Agency_Code=@billto;
end

else
if(@address1<>'' and  @address2 <> ''  and @address3='' and @street_new='')
begin
select @clientadd=isnull(agency_mast.add1+' ,'+agency_mast.add2,''),@clientname=Agency_Name,@citycode=city_code from agency_mast where SUB_Agency_Code=@billto;
end

else
if(@address1<>'' and  @address2 <>'' and @address3 <>'' and @street_new='' )
begin
select @clientadd=isnull(agency_mast.add1+' ,'+agency_mast.add2+' ,'+agency_mast.add3,''),@clientname=Agency_Name,@citycode=city_code from agency_mast where SUB_Agency_Code=@billto;
end



else
if(@address1<>'' and  @address2 <>'' and @address3 <>'' and  @street_new<>'')
begin
select @clientadd=isnull(agency_mast.add1+' ,'+agency_mast.add2+' ,'+agency_mast.add3+' ,'+agency_mast.street,''),@clientname=Agency_Name,@citycode=city_code from agency_mast where SUB_Agency_Code=@billto;
end


if(@clientadd = '' or @clientadd is null)begin
select @clientadd= isnull(ADD1,''),@clientname=Cust_Name from cust_mast  where Cust_Code=@billto; 
end

if(@clientadd =''  or  @clientadd is null )
begin
select @clientadd=isnull(Client_address,''),@clientname=Client_code from tbl_booking_mast where cio_booking_id=@cioid;
end 


if(@citycode !='')
begin


select @cityname=city_name from city_mst where  city_code=@citycode
enD

if(@l_no='')
begin
select @l_no= isnull(OLD_CLIENT_CODE,'') from cust_mast  where Cust_Code=@billto; 

end



if(@l_no<>'')
begin
select @l_no=isnull(agency_mast.OLD_AGENCY,'')  from agency_mast where SUB_Agency_Code=@billto;
end


return (@clientadd+'$$'+@clientname+'$$'+@cityname+'$$'+@l_no)
end

//////////////////////////end issue no:7400////////////////////////////////

/////////////////////////////AGAIN START ISSUE NO:7400//////////////////////////

USE [upkar]
GO
/****** Object:  StoredProcedure [dbo].[Websp_Orderlastnew_b]    Script Date: 05/07/2012 17:59:41 ******/
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
(select  distinct lang_name from lang_mast where lang_mast.lang_code=pub_mast.lang_code) as "language" ,

(select distinct advpos_type_mast.pos_type from advpos_type_mast where advpos_type_mast.pos_type_code=tbl_booking_insert.page_post) as "pageposition",


   (select distinct  retain_Name from  retainermaster where retainermaster.retain_code=tbl_booking_mast.retainer)as "Retainer",
   (select distinct exec_name from exec_mast where exec_mast.exe_no=tbl_booking_mast.executive_code) as "Executive",


(select distinct premiumname from ADVPOS_PREM_MAST where   ADVPOS_PREM_MAST. premiumcode=tbl_booking_insert.premium1) as "premium_name",
(select edition_name  from edition_mast where edition_mast.edition_code=tbl_booking_insert.edition_code) as "Edition_Name"






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





//////////////////////END ISSUE NO:7400///////////////////////////////

======================start========0834=====Avinash============
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[Reportnew1]
@agname		as	VARCHAR(500)=NULL,
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
@pwithout_rono  as  varchar(50)=null,--it is for without agency ro no. list Y or N or All
@pdate_flag     as  varchar(5)=null,--it is used for booking date B or publish date P
@pextra1        as  varchar(50)=null,--for UOM
@pextra2        as  varchar(50)=null,
@pextra3        as  varchar(50)=null,
@pextra4        as  varchar(50)=null,
@pextra5        as  varchar(50)=null
AS
declare @center			VARCHAR(50)
declare @from_date		DATETIME
declare @date_to		DATETIME
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
/*(select COMBIN_MAST.Package_Name from combin_mast where COMBIN_MAST.comp_code=m.comp_code and COMBIN_MAST.Combin_Code  in(m.Package_code))AS "Package",*/
case when CHARINDEX('','', m."Package_code") >0 then 
	dbo.FETCH_PACK_new('''+@compcode+''', m."Package_code" ) 
else
    (select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=m."Package_code")
end AS "Package",
i.Height AS "Depth",i.Width   AS "Width",
round(i.Size_Book,2) AS "Area",
(select uom_mast.UOM_DESC from uom_mast where m.Uom_code=uom_mast.Uom_Code and m.comp_code=uom_mast.comp_code)as "uom",
i.Col_Code AS "Color_code",
(SELECT ADVPOS_TYPE_MAST.Pos_Type_Alias FROM ADVPOS_TYPE_MAST WHERE i.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code  and i.comp_code=ADVPOS_TYPE_MAST.comp_code) AS "Page",
m.Bullet_code AS "BulletPremium" ,i.Page_Post AS "PositionPremium" ,i.Premium1 AS "PagePremium" ,
m.RO_No AS "RoNo.",CASE m.ro_status WHEN ''2'' THEN ''Reservation'' WHEN ''1'' THEN ''Confirm'' END AS "RoStatus",
(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=i.Ad_Cat and ADV_CAT_MAST.comp_code=i.comp_code) AS "AdCat",
m.Card_rate AS "CardRate",isnull(Agrred_rate,0) AS "AgreedRate",i.Bill_Amt AS "Amt",m.Caption AS "Cap",Key_no AS "Key",
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


======================End========0834=====Avinash============


==================start======6791=======avinash===========================

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[Reportnew1]
@agname		as	VARCHAR(500)=NULL,
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
@pwithout_rono  as  varchar(50)=null,--it is for without agency ro no. list Y or N or All
@pdate_flag     as  varchar(5)=null,--it is used for booking date B or publish date P
@pextra1        as  varchar(50)=null,--for UOM
@pextra2        as  varchar(50)=null,
@pextra3        as  varchar(50)=null,
@pextra4        as  varchar(50)=null,
@pextra5        as  varchar(50)=null
AS
declare @center			VARCHAR(50)
declare @from_date		DATETIME
declare @date_to		DATETIME
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
/*(select COMBIN_MAST.Package_Name from combin_mast where COMBIN_MAST.comp_code=m.comp_code and COMBIN_MAST.Combin_Code  in(m.Package_code))AS "Package",*/
case when CHARINDEX('','', m."Package_code") >0 then 
	dbo.FETCH_PACK_new('''+@compcode+''', m."Package_code" ) 
else
    (select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=m."Package_code")
end AS "Package",
i.Height AS "Depth",i.Width   AS "Width",
round(i.Size_Book,2) AS "Area",
(select uom_mast.UOM_DESC from uom_mast where m.Uom_code=uom_mast.Uom_Code and m.comp_code=uom_mast.comp_code)as "uom",
i.Col_Code AS "Color_code",
(SELECT ADVPOS_TYPE_MAST.Pos_Type_Alias FROM ADVPOS_TYPE_MAST WHERE i.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code  and i.comp_code=ADVPOS_TYPE_MAST.comp_code) AS "Page",
m.Bullet_code AS "BulletPremium" ,i.Page_Post AS "PositionPremium" ,i.Premium1 AS "PagePremium" ,
m.RO_No AS "RoNo.",CASE m.ro_status WHEN ''2'' THEN ''Reservation'' WHEN ''1'' THEN ''Confirm'' END AS "RoStatus",
(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=i.Ad_Cat and ADV_CAT_MAST.comp_code=i.comp_code) AS "AdCat",
m.Card_rate AS "CardRate",isnull(Agrred_rate,0) AS "AgreedRate",i.Bill_Amt AS "Amt",m.Caption AS "Cap",Key_no AS "Key",
(SELECT dbo.InitCap(Comp_Name) from comp_mst where Comp_Code='''+@compcode+''')  AS "companyname",
getdate() as "Rundate",CASHDISCOUNT as "Cash_Disc",m.AUDIT_COMMENT as "COMMENT",m."Dockit_no" as "DOCKIT_NO"
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

if(@pextra2 ='')begin


	IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL ) Begin
		set @v_query=@v_query+' and m."date_time" between  '''+@fromdate +''' and  '''+@dateto+''' '
	END

	IF( @fromdate<>'' and @dateto<>'') Begin
		set @v_query=@v_query+' and m."date_time" between  '''+@fromdate +''' and  '''+@dateto+''' '
	END

end
End

If @pdate_flag='P' Begin

if(@pextra2 ='')begin
	IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL ) Begin
		set @v_query=@v_query+' and i.Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
	END

	IF( @fromdate<>'' and @dateto<>'') Begin
		set @v_query=@v_query+' and i.Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
	END
end
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



============end====6791==========avinash=============================



=======start====7469=================avinash=========================
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
	STATUS  VARCHAR(5),
	PREODICITY_CODE   VARCHAR(8),
	RO_HR   VARCHAR(8),
	RO_MIN   VARCHAR(8)
)

set @query=' insert  into #ADV_CAT_MAST select Comp_Code, adv_cat_code, Adv_Cat_Name,Adv_Cat_Alias,/*Edition_Code,*/userid, getdate(),Adv_Type,REGCLIENT,CAT_FILE_NAME,STATUS,Preodicity_Code ,RO_hr,RO_min   from adv_cat_mast where  Comp_Code='''+@compcode+'''  '--and  userid='''+@userid+''''


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



==========end========7469=============avinash=================


==========Start========7468=============avinash=================

ALTER PROCEDURE pub_Reportnew(
@agname			as VARCHAR(50)= NULL,
@Adtype			as VARCHAR(50)= NULL,
@fromdate		as VARCHAR(20)= NULL,
@dateto			as VARCHAR(20)= NULL,
@compcode		as VARCHAR(10)= NULL,
@pub_cent		as VARCHAR(50)= NULL,
@category		as VARCHAR(50)= NULL,
@edition		as VARCHAR(50)= NULL,
@dateformat		as VARCHAR(20)= NULL,
@Region			as VARCHAR(50)= NULL,
@product		as VARCHAR(50)= NULL,
@agency			as VARCHAR(50)= NULL,
@descid			as VARCHAR(10)= NULL,
@ascdesc		as VARCHAR(10)= NULL,
@agcat			as VARCHAR(50)=null,
@adcheck		as VARCHAR(10)=null,
@executive		as VARCHAR(50)=null,
@puserid		as VARCHAR(10)=null,
@chk_access		as VARCHAR(2),
@pstatecode     as VARCHAR(100)= NULL,
@pdistcode      as VARCHAR(100)= NULL)

as
declare @query1	VARCHAR(8000)
declare @grpnew VARCHAR(100)
declare @grpne	VARCHAR(100)
declare @grpst	VARCHAR(100)
declare @prefer as VARCHAR(10)
BEGIN
select distinct @prefer= AGENCY_RETAINER_COMM from preferrences where comp_code=@compcode


if(@adcheck=1) begin

set @query1='SELECT distinct m.cio_booking_id AS "CIOID",
a.Agency_Name AS "Agency",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE CUST_MAST.comp_code=m.comp_code and Cust_Code=m.Client_code),m.Client_code)  AS "Client",
p.Pub_Name AS "Publication",
round(m.Total_area,2) AS "Area",
(SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE BRANCH_MST.comp_code=m.comp_code and m.Revenue_center =BRANCH_MST.Branch_Code )AS "RevenueCenter",
m.Rate_code as "Rate",
m.Page_prem as "Premium",
m.Bill_remarks as "BillRemark",
m.Color_code as "Color",
m.Ad_cat_code  as "Category",
m.Ad_sub_cat_code as "SubCategory",
m.Package_code as "Package",
isnull(m.Agrred_rate,m.Card_rate ) AS "AgreedRate",
(i.Bill_amt) AS "BillAmt",
m.Trade_disc as "AgencyComm",
m.ADD_AGENCY_COMM as "AddlAgencyTD",
(SELECT dbo.initcap(Comp_Name) from comp_mst where Comp_Code='''+@compcode+''') AS "companyname",
getdate() as "Rundate"
,m.Booking_type as "booktype"
,i.BILL_NO as "Bill_No"
,CASE '''+@dateformat+'''
 WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),(CAST( FLOOR( CAST(i.BILL_DATE AS FLOAT ) ) AS DATETIME )),101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),(CAST( FLOOR( CAST(i.BILL_DATE AS FLOAT ) ) AS DATETIME )),103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),(CAST( FLOOR( CAST(i.BILL_DATE AS FLOAT ) ) AS DATETIME )),111)END AS "Bill_Date"

,(select city_mst.City_Name from city_mst where city_mst.City_Code=a.City_Code and a.Comp_Code=city_mst.Comp_Code) as "Agency_City"
,m.Agency_address AS "A_Place"
,m.Client_address AS "C_Place"
,u.Uom_Name  AS "Uom"
,m.Page_no as "Page_no"
,m.Card_rate as "Card_Rate"
,m.Discount_per as Discper
,m.Special_disc_per as Spdiscper
,m.Space_disc_per as Spacediscper
,m.Special_charges as Specialcharge
,isnull((i.Bill_amt-isnull(dbo.fun_actual('''+ @compcode +''',isnull(m.ADD_AGENCY_COMM,''0'' ),isnull(m.RETAINER,''0''),isnull(i.Gross_rate,''0''),'''+@prefer+''',''2'' ),''0'')  ),''0'') as ActualBusiness
,isnull((isnull(i.Gross_rate,''0'')*isnull(m.ADD_AGENCY_COMM,''0'')/100),''0'') as "AgencyAddlTDAmt"
,(isnull(i.Gross_rate,''0'')* isnull(m.Trade_disc,''0'' )/100 )as "AgencyTDAmt"
,m.CASHDISCOUNT as "Cash_Disc"
,isnull(i.Gross_rate,''0'') as Grossamt
,m.Ad_size_height as height
,m.Ad_size_width as width

FROM TBL_BOOKING_MAST m, TBL_BOOKING_INSERT i, AGENCY_MAST a,PUB_MAST p,uom_mast u
WHERE m.Comp_code='''+@compcode+''' AND
u.Uom_Code=m.Uom_code  and
m.cio_booking_id=i.Cio_Booking_Id AND
m.Agency_sub_code=a.code_subcode AND  
i.Publication_Code = p.Pub_Code
AND  not exists(select ''x'' from tbl_booking_mast where m.cio_booking_id=prev_cioid and prev_cioid is not null)
and  lower(i.Insert_Status) != ''cancel''
and ((i.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )'

IF(@agname IS NOT NULL and @agname<>'') begin
	set @query1=@query1 +'AND m.Agency_code ='''+@agname+''''
END 

IF(@Adtype IS NOT NULL and @Adtype<>'') begin
	set @query1=@query1 + 'and m.Ad_type_code='''+@Adtype+''''
END 


IF(@pub_cent IS NOT NULL and @pub_cent<>'') begin
	set @query1=@query1+'  and i.Pub_Cent_Code='''+@pub_cent+''''
END 

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL ) begin
    set @query1=@query1+' and i.Insert_Date between  '''+@fromdate+''' and  '''+@dateto+''' '
END 

IF(@edition IS NOT NULL and @edition<>'') begin
	set @query1=@query1+'  and i.Edition_Code='''+@edition+''''
END 

IF((@category IS NOT NULL) AND (@category <> 'Package') AND (@category <> 'Solo')) begin
	set @query1=@query1+' and m.Agency_type='''+upper(@category)+''''
END 


IF(@product IS NOT NULL and @product<>'')begin
	set @query1=@query1+' and i.Publication_Code='''+@product+''''
END 

IF(@Region IS NOT NULL and @Region<>'') begin
	set @query1=@query1 +'and i.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+@Region+''')'
END


IF(@agcat IS NOT NULL and @agcat<>'') begin
	set @query1=@query1 +'AND m.Agency_code =a.code_subcode and a.Agency_Cat_Code='''+@agcat+''''
END 

IF(@executive IS NOT NULL and @executive<>'') begin
	set @query1=@query1 +'AND m.Executive_code ='''+@executive+''''
END 

IF(@pstatecode IS NOT NULL or @pstatecode<>'') 
begin
set @query1=@query1 +' AND a.state ='''+@pstatecode +'''';
END

IF(@pdistcode IS NOT NULL or @pdistcode<>'')
begin
set @query1=@query1 +' AND a.district ='''+@pdistcode +'''';
END

IF(@descid IS NOT  NULL and @descid<>'') begin
	set @query1=@query1+'  ORDER BY "'+@descid+'"'
	set @query1=@query1+''+@ascdesc+''
end
else begin
	set @query1=@query1+' order by m.cio_booking_id'
END



print(@query1)
exec(@query1)
end 

if(@adcheck=2) begin

set @query1='SELECT distinct b.IDNUM AS "CIOID",
a.Agency_Name AS "Agency",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE b.comp_code_v=cust_mast.comp_code and Cust_Code=d.CLIENTCD),d.CLIENTCD)  AS "Client",
p.Pub_Name AS "Publication",
round(d.SIZE_BOOK,2) AS "Area",
(SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE b.comp_code_v=BRANCH_MST.comp_code and b.REVENUE_CENTER =BRANCH_MST.Branch_Code )AS "RevenueCenter",
d.RATECD as "Rate",
b.SPPREMIUM as "Premium",
b.BILL_RMRK as "BillRemark",
b.COLOUR as "Color",
d.PRIADCTG  as "Category",
d.SECADCTG as "SubCategory",
d.PACKAGE_CODE as "Package",
(select isnull(tbl_booking_mast.Agrred_rate,tbl_booking_mast.Card_rate ) from tbl_booking_mast where tbl_booking_mast.cio_booking_id=b.IDNUM)AS "AgreedRate",
(b.BILLAMT) AS "BillAmt",
isnull(b.DISCOUNT ,''0'' ) as "AgencyComm",
isnull((select tbl_booking_mast.ADD_AGENCY_COMM from tbl_booking_mast where tbl_booking_mast.cio_booking_id=b.IDNUM),''0'') as "AddlAgencyTD", 
(SELECT dbo.initcap(Comp_Name) from comp_mst where Comp_Code='''+@compcode+''') AS "companyname",
getdate() as "Rundate"
,(select tbl_booking_mast.Booking_type from tbl_booking_mast where b.IDNUM=tbl_booking_mast.cio_booking_id ) as "booktype"
,d.BILNO as "Bill_No"
,CASE '''+@dateformat+'''
 WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),(CAST( FLOOR( CAST(  d.BILDT AS FLOAT ) ) AS DATETIME )),101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),(CAST( FLOOR( CAST(  d.BILDT AS FLOAT ) ) AS DATETIME )),103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),(CAST( FLOOR( CAST(  d.BILDT AS FLOAT ) ) AS DATETIME )),111) END AS "Bill_Date"
,(select city_mst.City_Name from city_mst where city_mst.City_Code=a.City_Code and a.Comp_Code=city_mst.Comp_Code) as "Agency_City"
,a.Add1 AS "A_Place"
,(select cust_mast.Add1 from cust_mast where b.CLIENTCD=cust_mast.Cust_Code) AS "C_Place"
,(select UOM_MAST.Uom_Name from uom_mast where uom_mast.Uom_Code in(select tbl_booking_mast.Uom_code from tbl_booking_mast where  tbl_booking_mast.cio_booking_id=b.IDNUM ))  AS "Uom"
,b.PAGENUM as "Page_no"
,(select tbl_booking_mast.Card_rate from tbl_booking_mast where tbl_booking_mast.cio_booking_id=b.IDNUM ) as "Card_Rate"
,(select tbl_booking_mast.Discount_per from tbl_booking_mast where tbl_booking_mast.cio_booking_id=b.IDNUM ) as Discper
,(select tbl_booking_mast.Special_disc_per from tbl_booking_mast where tbl_booking_mast.cio_booking_id=b.IDNUM ) as Spdiscper
,(select tbl_booking_mast.Space_disc_per from tbl_booking_mast where tbl_booking_mast.cio_booking_id=b.IDNUM ) as Spacediscper
,(select tbl_booking_mast.Special_charges from tbl_booking_mast where tbl_booking_mast.cio_booking_id=b.IDNUM ) as Specialcharge
,(select isnull((b.BILLAMT -isnull(dbo.fun_actual('''+@compcode+''',isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),isnull(b.RETAINER_CODE ,''0''),isnull(b.GROSS_AMT ,''0''),'''+@prefer+''',''2'' ),''0'')  ),''0'') from tbl_booking_mast where tbl_booking_mast.cio_booking_id=b.IDNUM ) as ActualBusiness
,(select isnull((isnull(b.GROSS_AMT,''0'')*isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'')/100),''0'') from tbl_booking_mast where tbl_booking_mast.cio_booking_id=b.IDNUM )as "AgencyAddlTDAmt"
, (isnull(b.GROSS_AMT,''0'')* isnull(b.DISCOUNT,''0'' )/100 )as "AgencyTDAmt"
,isnull(b.GROSS_AMT,''0'') as Grossamt
,d.HEIGHT as height
,d.WIDTH as width
,b.GROSS_AMT,b.BOXCHRG,b.AGCOMM
FROM ad_bills b,ad_bills_det d,AGENCY_MAST a,PUB_MAST p
WHERE b.IDNUM=d.IDNUM and b.bilno=d.BILNO and
b.AGCODE=a.code_subcode AND  
b.PRIPUB = p.Pub_Code 
and ((d.BKFOR  in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )'

IF(@agname IS NOT NULL and @agname<>'') begin
	set @query1=@query1 +'  and b.AG_MAIN_CODE ='''+@agname+''''
END 


IF(@Adtype IS NOT NULL and @Adtype<>'') begin
	set @query1=@query1 + 'and d.AD_TYPE_V='''+@Adtype+''''
END 

iF(@pub_cent IS NOT NULL and @pub_cent<>'')	begin
	set @query1=@query1+'  AND d.BKFOR ='''+@pub_cent+''''
END 

IF(@fromdate IS NOT NULL AND @dateto IS NULL )begin
    set @query1=@query1+' and d.INSDATE ='''+@fromdate+''''
END 

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL ) begin
    set @query1=@query1+' and d.INSDATE between  '''+@fromdate+''' and  '''+@dateto+''' '
END 

IF(@edition IS NOT NULL and @edition<>'') begin
	set @query1=@query1+'  and d.EDITION='''+@edition+''''
END 



IF((@category IS NOT NULL) AND (@category <> 'Package') AND (@category <> 'Solo')) begin
	set @query1=@query1+' and  b.AGCODE= a.code_subcode and a.Agency_Type_Code= '''+upper(@category)+''''
END 


IF(@product IS NOT NULL and @product<>'') begin
	set @query1=@query1+' and b.PRIPUB='''+@product+''''
END 

IF(@Region IS NOT NULL and @Region<>'') begin
	set @query1=@query1 +' and b.UNIT in (select Branch_Code from branch_mst where  BRANCH_MST.Region_code='''+@Region +''')'
END 


IF(@agcat IS NOT NULL and @agcat<>'') begin
	set @query1=@query1 +'AND b.AGCODE =a.code_subcode and a.Agency_Cat_Code='''+@agcat+''''
END 

IF(@executive IS NOT NULL and @executive<>'') begin
	set @query1=@query1 +'AND b.EXECUTIVE_NAME='''+@executive+''''
END 

IF(@pstatecode IS NOT NULL or @pstatecode<>'') 
begin
set @query1=@query1 +' AND a.state ='''+@pstatecode +'''';
END

IF(@pdistcode IS NOT NULL or @pdistcode<>'')
begin
set @query1=@query1 +' AND a.district ='''+@pdistcode +'''';
END


IF(@descid IS NOT  NULL and @descid<>'') begin
	set @query1=@query1+'  ORDER BY "'+@descid+'"'
	set @query1=@query1+''+@ascdesc+''
end
else begin
	set @query1=@query1+' order by b.IDNUM'
END 




print(@query1)
exec(@query1)
end 
end



==========end========7468=============avinash=================
/**************************** Issue 0007493 ***********************************/

ALTER PROCEDURE [dbo].[websp_bindaudit]
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
@puom_code as  varchar(100)
 AS
declare @query1 as varchar(8000)

set @query1='select tbl_booking_insert.Cio_Booking_Id as cio_booking_id,
No_Insert as no_of_insertion ,
Edition  as edition,
isnull((select distinct cust_mast.Cust_Alias from cust_mast  where  cust_mast.Cust_Code=tbl_booking_mast.Client_code),Client_code) as client,
AGENCY_MAST.Agency_Name as Agency,
tbl_booking_mast.Gross_amount as gross_amount,
tbl_booking_insert .Insert_Status as status,
CASE '''+@date+'''
 WHEN ''mm/dd/yyyy'' THEN convert(varchar(100),Insert_Date,1)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(100),Insert_Date,3)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(100),Insert_Date,3)  END AS "Ins.date",
tbl_booking_mast.RO_No,
COL_MAST.Col_Alias as Col_Name,
tbl_booking_insert .Size_Book,
tbl_booking_insert.Agreed_Rate,
tbl_booking_insert.Bill_Amt,
tbl_booking_insert.Height, Width
from tbl_booking_insert,
tbl_booking_mast,
COL_MAST,
agency_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id  and
 TBL_BOOKING_MAST.Color_code=COL_MAST.Col_Code  AND
 agency_mast.code_subcode=tbl_booking_mast.Agency_sub_code';





/*
if(@date=mm/dd/yyyy)
begin

set @query='select tbl_booking_insert.cio_booking_id,no_insert as no_of_insertion ,edition ,
(select cust_mast.cust_alias from cust_mast  where cust_mast.cust_code = tbl_booking_mast.client_code) as client,
AGENCY_MAST.agency_name as Agency,tbl_booking_mast.gross_amount,tbl_booking_insert.insert_status as status
from tbl_booking_insert,tbl_booking_mast,agency_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.cio_booking_id  and
 tbl_booking_insert.insert_status=''publish'' and agency_mast.code_subcode=tbl_booking_mast.agency_sub_code  and  date_time between '''+@fromdate+''' and '''+@todate+''' and branch='''+@branch+''' and ad_type_code='''+@adtype+''''
end

if(@date= dd/mm/yyyy)
begin
set @query='select tbl_booking_insert.cio_booking_id,no_insert as no_of_insertion ,edition ,
(select cust_mast.cust_alias from cust_mast  where cust_mast.cust_code = tbl_booking_mast.client_code) as client,
AGENCY_MAST.agency_name as Agency,tbl_booking_mast.gross_amount,tbl_booking_insert.insert_status
from tbl_booking_insert,tbl_booking_mast,agency_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.cio_booking_id  and
 tbl_booking_insert.insert_status=''publish'' and agency_mast.code_subcode=tbl_booking_mast.agency_sub_code and date_time between '''+@fromdate+''' and '''+@todate+''' and branch='''+@branch+''' and ad_type_code='''+@adtype+''''
end

if(@date=  yyyy/mm/dd)
begin
set @query='select tbl_booking_insert.cio_booking_id,no_insert as no_of_insertion ,edition ,
(select cust_mast.cust_alias from cust_mast  where cust_mast.cust_code = tbl_booking_mast.client_code) as client,
AGENCY_MAST.agency_name as Agency,tbl_booking_mast.gross_amount,tbl_booking_insert.insert_status
from tbl_booking_insert,tbl_booking_mast,agency_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.cio_booking_id  and
 tbl_booking_insert.insert_status=''publish'' and agency_mast.code_subcode=tbl_booking_mast.agency_sub_code and date_time between '''+@fromdate+''' and '''+@todate+''' and branch='''+@branch+''' and ad_type_code='''+@adtype+''''
end

if(@date=null)
begin
set @query='select tbl_booking_insert.cio_booking_id,no_insert as no_of_insertion ,edition ,
(select cust_mast.cust_alias from cust_mast  where cust_mast.cust_code = tbl_booking_mast.client_code) as client,
AGENCY_MAST.agency_name as Agency,tbl_booking_mast.gross_amount,tbl_booking_insert.insert_status
from tbl_booking_insert,tbl_booking_mast,agency_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.cio_booking_id  and
 tbl_booking_insert.insert_status=''publish'' and agency_mast.code_subcode=tbl_booking_mast.agency_sub_code and date_time between '''+@fromdate+''' and '''+@todate+''' and branch='''+@branch+''' and ad_type_code='''+@adtype+''''
end

*/


if(@v_insert_status <> null or @v_insert_status <> '')
begin
set @query1=@query1 +' AND TBL_BOOKING_insert. "Insert_Status" ='''+@v_insert_status+''' '
end 







IF(@v_retainer   <> NULL or @v_retainer <> '')
begin
set @query1=@query1 +' and tbl_booking_mast ."RETAINER"='''+@v_retainer+'''';
END 


IF(@v_executive   <> NULL or @v_executive <> '')
begin
set @query1=@query1 +' and tbl_booking_mast ."Executive_code"='''+@v_executive+'''';
END 











IF(@v_supplement   <> NULL or @v_supplement <> '')
begin
set @query1=@query1 +'  and TBL_BOOKING_insert ."Supp_Code"='''+@v_supplement+'''';
END





IF(@branchnew   <> NULL or @branchnew <> '')
begin
set @query1=@query1 +'  and tbl_booking_mast ."branch"='''+@branchnew+'''';
END 



IF(@client <> NULL or @client <> '')
begin
set @query1=@query1 +'  and tbl_booking_mast ."Client_code"='''+@client+'''';
END





IF(@pub_cent <> NULL or @pub_cent <> '' )
begin

set @query1=@query1 +'   and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))';

END 


IF(@agency <> NULL or @agency <> '')
begin
set @query1=@query1 +'  TBL_BOOKING_MAST."Agency_code" ='''+@agency+'''';
END 







IF(@publication  <> NULL or @publication <> '')
begin
set @query1=@query1 +'  and  TBL_BOOKING_insert."Publication_Code"='''+@publication+'''';
END




IF(@adtype  <> NULL or @adtype <> '')
begin
set @query1=@query1 +' and TBL_BOOKING_MAST. "Ad_type_code" ='''+@adtype+'''';
END 

IF(@fromdate  <> '' AND @todate  <> '' )
begin
set @query1=@query1 +'  and "Insert_Date" between  '''+@fromdate+''' and  '''+@todate+''' ';
END 

IF(@edition  <> NULL or   @edition <> '')
begin
set @query1=@query1 +'   and tbl_booking_insert."Edition_Code"='''+@edition+'''';
END 

IF(@puom_code  <> NULL or   @puom_code <> '')
begin
set @query1=@query1 +'   and tbl_booking_mast."Uom_code"='''+@puom_code+'''';
END 

set @query1=@query1 +'   order by tbl_booking_insert.cio_booking_id'

print(@query1)
exec(@query1)




/**************************** End of Issue 0007493 ***********************************/



///////////////////////////////issue no 7168 shipra////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[getData_Export]    Script Date: 05/15/2012 12:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
                                                                     
                                                                     
                                                                     
                                             
ALTER PROCEDURE [dbo].[getData_Export]
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


/////////////////end of 7168////////////////


////////////////start of issue no 7292/////////////////////////

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[checkdatecomm]    Script Date: 05/16/2012 12:00:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





ALTER PROCEDURE  [dbo].[checkdatecomm]

@agencode as varchar(25),

@userid as varchar(10),
@compcode as varchar(10),
@fromdatecomm as varchar(50),
@tilldate as varchar(50),
@agencysubcode as varchar(8) ,
@adtype1 as varchar(8),
@uom11 as varchar(8)





AS

declare @query1 as varchar(900)
declare @fromdate as varchar(900)
declare @todate as varchar(900)
declare @query2 as varchar(900)
declare @query as varchar(900)



--set @query='select  comm_code, convert(varchar,Eff_from_date,101) as Eff_from_date,convert(varchar,Eff_Till_date,101) as Eff_Till_date,Comm_rate,Discount,comm_code  from comm_details where userid='''+@userid+''' and AGENCY_CODE='''+@agencode+'''    order by eff_till_date desc    '

--set @query1='select  Eff_from_date  from comm_details where userid='''+@userid+''' and AGENCY_CODE='''+@agencode+'''    order by eff_till_date desc   '

--set @query2='select   Eff_Till_date  from comm_details where userid='''+@userid+''' and AGENCY_CODE='''+@agencode +'''   order by eff_till_date desc   '


--set @query='select  comm_code, convert(varchar,Eff_from_date,101) as Eff_from_date,convert(varchar,Eff_Till_date,101) as Eff_Till_date,Comm_rate,Discount,comm_code  from comm_details where userid='''+@userid+''' and AGENCY_CODE='''+@agencode+'''  and ( '''+@fromdatecomm+''' = Eff_from_date  or  '''+@tilldate+'''=Eff_Till_date  or  '''+@fromdatecomm+''' between  Eff_from_date and Eff_Till_date   or  '''+@tilldate+''' between  Eff_from_date and Eff_Till_date or Eff_Till_date  between '''+@fromdatecomm+''' and '''+@tilldate+'''  or Eff_from_date  between '''+@fromdatecomm+''' and '''+@tilldate+'''  )  '

--set @query='select  comm_code, convert(varchar,Eff_from_date,101) as Eff_from_date,convert(varchar,Eff_Till_date,101) as Eff_Till_date,Comm_rate,Discount,comm_code  from comm_details where Agency_sub_code='''+@agencysubcode+'''  and AGENCY_CODE='''+@agencode+'''  and ( '''+@fromdatecomm+''' = Eff_from_date  or  '''+@tilldate+'''=Eff_Till_date  or  '''+@fromdatecomm+''' between  Eff_from_date and Eff_Till_date   or  '''+@tilldate+''' between  Eff_from_date and Eff_Till_date or Eff_Till_date  between '''+@fromdatecomm+''' and '''+@tilldate+'''  or Eff_from_date  between '''+@fromdatecomm+''' and '''+@tilldate+'''  )   and ADTYPE='''+@adtype1+''' and UOM='''+@uom11+''';'

-- change by bhanu discuss with sanjay sir-- select  comm_code, convert(varchar,Eff_from_date,101) as Eff_from_date,convert(varchar,Eff_Till_date,101) as Eff_Till_date,Comm_rate,Discount,comm_code  from comm_details where Agency_sub_code=@agencysubcode  and AGENCY_CODE=@agencode  and ( @fromdatecomm = Eff_from_date  or  @tilldate=Eff_Till_date  or  @fromdatecomm between  Eff_from_date and Eff_Till_date   or  @tilldate between  Eff_from_date and Eff_Till_date or Eff_Till_date  between @fromdatecomm and @tilldate  or Eff_from_date  between @fromdatecomm and @tilldate  )   and ADTYPE=@adtype1 and (UOM=@uom11 or UOM='0' or UOM is NULL)
select  comm_code, convert(varchar,Eff_from_date,101) as Eff_from_date,convert(varchar,Eff_Till_date,101) as Eff_Till_date,Comm_rate,Discount,comm_code  from comm_details where Agency_sub_code=@agencysubcode  and AGENCY_CODE=@agencode  and  Eff_Till_date =@tilldate    and ADTYPE=@adtype1 and (UOM=@uom11 or UOM='0' or UOM is NULL)

--print(@query)
--exec(@query)




////////////////////////////end of issue 7292///////////////////////


/////////////////////////////////issue no 7314///////////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[websp_executeagency]    Script Date: 05/16/2012 15:03:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







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
declare @query as varchar(2100)

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
                (SELECT top 1 status_name FROM STATUS_DETAIL WHERE comp_code='''+@compcode+''' and  STATUS_DETAIL.agency_code+STATUS_DETAIL.agency_subcat_code = AGENCY_MAST.code_subcode) AS status_name,
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













//////////////////////////end of issue no 7314//////////////////////////
///////////////////////////////issue  number//////////////////
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[websp_selectvalues]    Script Date: 05/16/2012 15:29:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[websp_selectvalues]

(@ciobooking	varchar(50), 
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
(select ADV_SUBCAT_MAST.Adv_Subcat_Name from ADV_SUBCAT_MAST where ADV_SUBCAT_MAST.Adv_Subcat_Code=TBL_BOOKING_MAST.ad_sub_cat_code) as "AdSubCat",

0 as "vat_rate",

dbo.get_printing_cent_street_fr_bran('''+@compcode+''',tbl_booking_mast.branch)as street_login,


(SELECT DISTINCT PACKAGE_NAME FROM COMBIN_MAST WHERE COMBIN_MAST.COMBIN_CODE=TBL_BOOKING_MAST.PACKAGE_CODE) AS "PACK_NAME"
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
 and TBL_BOOKING_MAST.agency_sub_code=AGENCY_MAST.code_subcode 

and comp_mst.comp_code='''+@compcode+''' 
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



select distinct bill_date as "bill_dt"  from tbl_booking_insert where cio_booking_id=@ciobooking


select scheme_code as "bill_dt"  from Scheme_Master where comp_code=@compcode and Scheme_id=@v_scheme_code


/* changes by GAurav for vision

select distinct edition_code from tbl_booking_insert where  cio_booking_id=@ciobooking

select top 1 insert_date from tbl_booking_insert where  cio_booking_id=@ciobooking 

select convert(varchar(25),dbo.UD_GET_MAXINSDT(@ciobooking,@insertion),3) as "bill_dt"

*/
////////////////////////////////////////////end of issue 7512

//////////////////////////ISSUE NO:7421(21/05/2012)//////////

                                                                     
                                                                     
                                                                     
                                             

ALTER  FUNCTION [dbo].[get_printing_cent_street_fr_bran](@pcomp_code AS varchar(10),@pbran_code AS varchar(10)) RETURNS VARCHAR(2000) AS

BEGIN
DECLARE @pub_cent_ADD varchar(500)
DECLARE @pub_cent_STREET varchar(500)
DECLARE @pub_cent_mail varchar(500)
DECLARE @pub_cent_phone1 VARCHAR (50)
DECLARE @pub_cent_phone2 VARCHAR (50)
DECLARE @pub_cent_FAX VARCHAR (50)
DECLARE @pub_cent_FAX1 VARCHAR (50)
   Begin
      select @pub_cent_ADD=Add1 from pub_cent_mast 
         where Comp_Code=@pcomp_code and 
               Pub_cent_Code= DBO.get_printing_cent_from_branch (@pcomp_code,@pbran_code)
               
                select @pub_cent_STREET=street from pub_cent_mast 
         where Comp_Code=@pcomp_code and 
               Pub_cent_Code= DBO.get_printing_cent_from_branch (@pcomp_code,@pbran_code)
           select @pub_cent_mail=emailid ,@pub_cent_phone1=Phone1 ,@pub_cent_phone2=Phone2 ,@pub_cent_FAX=Fax ,@pub_cent_FAX1=Fax1 from pub_cent_mast 
         where Comp_Code=@pcomp_code and 
               Pub_cent_Code= DBO.get_printing_cent_from_branch (@pcomp_code,@pbran_code)

   End

   return ISNULL(@pub_cent_ADD+@pub_cent_STREET+'~'+@pub_cent_mail +'~'+@pub_cent_phone1+'~'+@pub_cent_phone2+'~'+@pub_cent_FAX+'~'+@pub_cent_FAX1, '');
   
   
END 


--SELECT * FROM pub_cent_mast


////////////////////////END ISSUE NO:7421////////////////////////

/////////////////issue no:7421:(22/05/2012)/////////////////////

USE [new_db_hari]
GO
/****** Object:  UserDefinedFunction [dbo].[get_printing_cent_street_fr_bran]    Script Date: 05/22/2012 13:01:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER  FUNCTION [dbo].[get_printing_cent_street_fr_bran](@pcomp_code AS varchar(10),@pbran_code AS varchar(10)) RETURNS VARCHAR(2000) AS

BEGIN
DECLARE @pub_cent_ADD varchar(500)
DECLARE @pub_cent_STREET varchar(500)
DECLARE @pub_cent_mail varchar(500)
DECLARE @pub_cent_phone1 VARCHAR (50)
DECLARE @pub_cent_phone2 VARCHAR (50)
DECLARE @pub_cent_FAX VARCHAR (50)
DECLARE @pub_cent_FAX1 VARCHAR (50)
   Begin
      select @pub_cent_ADD=Add1 from pub_cent_mast 
         where Comp_Code=@pcomp_code and 
               Pub_cent_Code= DBO.get_printing_cent_from_branch (@pcomp_code,@pbran_code)
               
                select @pub_cent_STREET=street from pub_cent_mast 
         where Comp_Code=@pcomp_code and 
               Pub_cent_Code= DBO.get_printing_cent_from_branch (@pcomp_code,@pbran_code)
           select @pub_cent_mail=emailid ,@pub_cent_phone1=Phone1 ,@pub_cent_phone2=Phone2 ,@pub_cent_FAX=Fax ,@pub_cent_FAX1=Fax1 from pub_cent_mast 
         where Comp_Code=@pcomp_code and 
               Pub_cent_Code= DBO.get_printing_cent_from_branch (@pcomp_code,@pbran_code)

   End

   return ISNULL(@pub_cent_ADD+@pub_cent_STREET+'~'+@pub_cent_mail +'~'+@pub_cent_phone1+'~'+@pub_cent_phone2+'~'+@pub_cent_FAX+'~'+@pub_cent_FAX1, '');
   
   
END 


--SELECT * FROM pub_cent_mast
////////////////////////////end of issue no:7421////////////////////////////


/////////////////////////////issue no:7421(22/05/2012)///////////////


ALTER procedure [dbo].[websp_selectvalues]
add in last:-----

isnull((select Product_Name from Product_Mast where Product_Code=tbl_booking_mast.Product_code),''--'') as product

ADD IN from  Table:---------
Product_Mast



ALTER procedure [dbo].[Websp_Orderlastnew_b]
ad in last:-----

isnull((select Product_Name from Product_Mast where Product_Code=tbl_booking_mast.Product_code),tbl_booking_mast.Product_code) as product

ADD IN from  Table:------
Product_Mast


/////////////////issue no:7421/////////////////

/**************************mimoh 22 may 2012************************************/

















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
@p_CURRENCY_MEASUREMENT   as varchar(5),

@p_EDITABLE_AGENCY_COMM as varchar(1),
@p_CANCELLATION_CHARGE as varchar(1),
@P_taxi_entry_type     as VARCHAR(1),
@P_ApprovalWith          as VARCHAR(1),
@p_Auto_TDS_Credit_Note as varchar(1),
@p_TDS_Reason as varchar(10),
@p_Debit_Account_Head as varchar(10),
@p_credit_Account_Head as varchar(10),
@p_service_tax_credit_note as varchar(1),
@p_Tax_Reason as varchar(10),
@p_Debit_Account_Service_Tax as varchar(10),
@p_Credit_Account_Service_Tax as varchar(10),
@p_Auto_Patrakar_Credit_Note as varchar(1),
@p_Patrakar_Reason as varchar(10),
@p_Debit_Account_Patrakar as varchar(10),
@p_Credit_Account_Patrakar as varchar(10),
@p_Auto_Bank_Credit_Note as varchar(1),
@p_Bank_Reason as VARCHAR(10),
@p_Debit_Account_Bank as varchar(10),
@p_Credit_Account_Bank as varchar(10),
@P_BAR_CODE as VARCHAR(5),
@P_GEN_RCT_NO as VARCHAR(5),
@P_misdata as VARCHAR(5),
@P_WEIGHT_CAL as VARCHAR(5)

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
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=@p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=@p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=@p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM =@p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE =@p_CANCELLATION_CHARGE,taxi_entry_type=@P_taxi_entry_type,APPROVAL_WITH =@P_ApprovalWith,

TDS_AUTO_CN=@p_Auto_TDS_Credit_Note,
TDS_AUTO_REASON=@p_TDS_Reason ,TDS_DB_CDP=@p_Debit_Account_Head,TDS_CR_CDP=@p_credit_Account_Head,SER_TAX_AUTO_CN=@p_service_tax_credit_note,SER_TAX_AUTO_REASON=@p_Tax_Reason,SER_TAX_DB_CDP=@p_Debit_Account_Service_Tax,SER_TAX_CR_CDP=@p_Credit_Account_Service_Tax,PKK_AUTO_CN=@p_Auto_Patrakar_Credit_Note,PKK_AUTO_REASON=@p_Patrakar_Reason ,PKK_DB_CDP=@p_Debit_Account_Patrakar,PKK_CR_CDP=@p_Credit_Account_Patrakar ,BANK_CHG_AUTO_CN=@p_Auto_Bank_Credit_Note ,
BANK_CHG_AUTO_REASON=@p_Bank_Reason ,BANK_CHG_DB_CDP=@p_Debit_Account_Bank ,BANK_CHG_CR_CDP=@p_Credit_Account_Bank,

 CIR_BARCODE= @P_BAR_CODE,CIR_WIEGHT_CALC_REQ= @P_WEIGHT_CAL,GEN_RCT_TYP = @P_GEN_RCT_NO,PRODUCT_BRAND_REQ=@P_misdata 

 
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)




/**********************************************************************************/
















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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,Space_area,EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE,TAXI_ENTRY_TYPE,APPROVAL_WITH,   TDS_AUTO_CN,TDS_AUTO_REASON,TDS_DB_CDP,TDS_CR_CDP,SER_TAX_AUTO_CN,SER_TAX_AUTO_REASON,SER_TAX_DB_CDP,SER_TAX_CR_CDP,PKK_AUTO_CN,PKK_AUTO_REASON,PKK_DB_CDP,PKK_CR_CDP,BANK_CHG_AUTO_CN,BANK_CHG_AUTO_REASON,BANK_CHG_DB_CDP,BANK_CHG_CR_CDP ,


CIR_BARCODE,CIR_WIEGHT_CALC_REQ,GEN_RCT_TYP,PRODUCT_BRAND_REQ

           FROM PREFERRENCES
          WHERE comp_code = @compcode










/************************************************************************/



/**********************************mimoh 22 may 2012**************7561**********************/ 




//////////////////////////start by shipra//////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[wesp_updatedate1]    Script Date: 05/23/2012 14:33:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
@p_CURRENCY_MEASUREMENT   as varchar(5),

@p_EDITABLE_AGENCY_COMM as varchar(1),
@p_CANCELLATION_CHARGE as varchar(1),
@P_taxi_entry_type     as VARCHAR(1),
@P_ApprovalWith          as VARCHAR(1),
@p_Auto_TDS_Credit_Note as varchar(1),
@p_TDS_Reason as varchar(10),
@p_Debit_Account_Head as varchar(10),
@p_credit_Account_Head as varchar(10),
@p_service_tax_credit_note as varchar(1),
@p_Tax_Reason as varchar(10),
@p_Debit_Account_Service_Tax as varchar(10),
@p_Credit_Account_Service_Tax as varchar(10),
@p_Auto_Patrakar_Credit_Note as varchar(1),
@p_Patrakar_Reason as varchar(10),
@p_Debit_Account_Patrakar as varchar(10),
@p_Credit_Account_Patrakar as varchar(10),
@p_Auto_Bank_Credit_Note as varchar(1),
@p_Bank_Reason as VARCHAR(10),
@p_Debit_Account_Bank as varchar(10),
@p_Credit_Account_Bank as varchar(10),
@P_BAR_CODE as VARCHAR(5),
@P_GEN_RCT_NO as VARCHAR(5),
@P_misdata as VARCHAR(5),
@P_WEIGHT_CAL as VARCHAR(5),
@P_allowpremium as varchar(5)

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
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=@p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=@p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=@p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM =@p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE =@p_CANCELLATION_CHARGE,taxi_entry_type=@P_taxi_entry_type,APPROVAL_WITH =@P_ApprovalWith,

TDS_AUTO_CN=@p_Auto_TDS_Credit_Note,
TDS_AUTO_REASON=@p_TDS_Reason ,TDS_DB_CDP=@p_Debit_Account_Head,TDS_CR_CDP=@p_credit_Account_Head,SER_TAX_AUTO_CN=@p_service_tax_credit_note,SER_TAX_AUTO_REASON=@p_Tax_Reason,SER_TAX_DB_CDP=@p_Debit_Account_Service_Tax,SER_TAX_CR_CDP=@p_Credit_Account_Service_Tax,PKK_AUTO_CN=@p_Auto_Patrakar_Credit_Note,PKK_AUTO_REASON=@p_Patrakar_Reason ,PKK_DB_CDP=@p_Debit_Account_Patrakar,PKK_CR_CDP=@p_Credit_Account_Patrakar ,BANK_CHG_AUTO_CN=@p_Auto_Bank_Credit_Note ,
BANK_CHG_AUTO_REASON=@p_Bank_Reason ,BANK_CHG_DB_CDP=@p_Debit_Account_Bank ,BANK_CHG_CR_CDP=@p_Credit_Account_Bank,

 CIR_BARCODE= @P_BAR_CODE,CIR_WIEGHT_CALC_REQ= @P_WEIGHT_CAL,GEN_RCT_TYP = @P_GEN_RCT_NO,PRODUCT_BRAND_REQ=@P_misdata,ALLOWPREM_CARD_DISC_RATE=@P_allowpremium

 
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)




USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[currbindpreferpgld]    Script Date: 05/24/2012 12:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,Space_area,EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE,TAXI_ENTRY_TYPE,APPROVAL_WITH,   TDS_AUTO_CN,TDS_AUTO_REASON,TDS_DB_CDP,TDS_CR_CDP,SER_TAX_AUTO_CN,SER_TAX_AUTO_REASON,SER_TAX_DB_CDP,SER_TAX_CR_CDP,PKK_AUTO_CN,PKK_AUTO_REASON,PKK_DB_CDP,PKK_CR_CDP,BANK_CHG_AUTO_CN,BANK_CHG_AUTO_REASON,BANK_CHG_DB_CDP,BANK_CHG_CR_CDP ,


CIR_BARCODE,CIR_WIEGHT_CALC_REQ,GEN_RCT_TYP,PRODUCT_BRAND_REQ,ALLOWPREM_CARD_DISC_RATE

           FROM PREFERRENCES
          WHERE comp_code = @compcode













////////////////////////////////done by shipra///////////////////////////

=========start=======6189/////avinash23may2012================================
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

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
					a."Comp_code"=i."Comp_Code" 
	 AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
			AND a."cio_booking_id"=i."Cio_Booking_Id" and
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
            a."Agency_sub_code"=b."code_subcode" 
			 AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
			and i."Insert_Status"<>''cancel'' ';
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
				a.Comp_code='''+@pcompcode+''' AND a."Comp_code"=i."Comp_Code" 
		 AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
			AND a."cio_booking_id"=i."Cio_Booking_Id" and
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
			a.Comp_code='''+@pcompcode+''' AND a."Comp_code"=i."Comp_Code" 
		AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
		AND a."cio_booking_id"=i."Cio_Booking_Id" and
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
            a."Executive_code"=exec_mast."Exe_no"  
		AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
			and i."Insert_Status"<>''cancel'' '
end
         else begin
         set @query1='select distinct RETAINERMASTER.Retain_Name     as "EXE_RET",RETAINERMASTER.Dist_Code   as "DISTRICT",
            (SELECT Branch_Name FROM BRANCH_MST where  a.branch = Branch_Code) as "BRANCH",
           SUM(case RODOCSTATUS when ''o'' then 1 else 0 end) ORIGINAL,
			SUM(case RODOCSTATUS when ''f'' then 1 else 0 end) FAX,
			SUM(case RODOCSTATUS when ''x'' then 1 else 0 end) XEROX,
			SUM(case RODOCSTATUS when ''o'' then 0 when ''f'' then 0 when ''x'' then 0 else 1 end) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER ,agency_mast b/*,adv_cat_mast c*/
            where  a.Comp_code='''+@pcompcode+''' AND a."Comp_code"=i."Comp_Code" 
		AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
		AND a."cio_booking_id"=i."Cio_Booking_Id" and
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



============end 6189====avinash=================================



///////////////////////////////issue done by shipra///////////////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[wesp_updatedate1]    Script Date: 05/23/2012 14:33:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
@p_CURRENCY_MEASUREMENT   as varchar(5),

@p_EDITABLE_AGENCY_COMM as varchar(1),
@p_CANCELLATION_CHARGE as varchar(1),
@P_taxi_entry_type     as VARCHAR(1),
@P_ApprovalWith          as VARCHAR(1),
@p_Auto_TDS_Credit_Note as varchar(1),
@p_TDS_Reason as varchar(10),
@p_Debit_Account_Head as varchar(10),
@p_credit_Account_Head as varchar(10),
@p_service_tax_credit_note as varchar(1),
@p_Tax_Reason as varchar(10),
@p_Debit_Account_Service_Tax as varchar(10),
@p_Credit_Account_Service_Tax as varchar(10),
@p_Auto_Patrakar_Credit_Note as varchar(1),
@p_Patrakar_Reason as varchar(10),
@p_Debit_Account_Patrakar as varchar(10),
@p_Credit_Account_Patrakar as varchar(10),
@p_Auto_Bank_Credit_Note as varchar(1),
@p_Bank_Reason as VARCHAR(10),
@p_Debit_Account_Bank as varchar(10),
@p_Credit_Account_Bank as varchar(10),
@P_BAR_CODE as VARCHAR(5),
@P_GEN_RCT_NO as VARCHAR(5),
@P_misdata as VARCHAR(5),
@P_WEIGHT_CAL as VARCHAR(5),
@P_allowpremium as varchar(5)

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
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=@p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=@p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=@p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM =@p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE =@p_CANCELLATION_CHARGE,taxi_entry_type=@P_taxi_entry_type,APPROVAL_WITH =@P_ApprovalWith,

TDS_AUTO_CN=@p_Auto_TDS_Credit_Note,
TDS_AUTO_REASON=@p_TDS_Reason ,TDS_DB_CDP=@p_Debit_Account_Head,TDS_CR_CDP=@p_credit_Account_Head,SER_TAX_AUTO_CN=@p_service_tax_credit_note,SER_TAX_AUTO_REASON=@p_Tax_Reason,SER_TAX_DB_CDP=@p_Debit_Account_Service_Tax,SER_TAX_CR_CDP=@p_Credit_Account_Service_Tax,PKK_AUTO_CN=@p_Auto_Patrakar_Credit_Note,PKK_AUTO_REASON=@p_Patrakar_Reason ,PKK_DB_CDP=@p_Debit_Account_Patrakar,PKK_CR_CDP=@p_Credit_Account_Patrakar ,BANK_CHG_AUTO_CN=@p_Auto_Bank_Credit_Note ,
BANK_CHG_AUTO_REASON=@p_Bank_Reason ,BANK_CHG_DB_CDP=@p_Debit_Account_Bank ,BANK_CHG_CR_CDP=@p_Credit_Account_Bank,

 CIR_BARCODE= @P_BAR_CODE,CIR_WIEGHT_CALC_REQ= @P_WEIGHT_CAL,GEN_RCT_TYP = @P_GEN_RCT_NO,PRODUCT_BRAND_REQ=@P_misdata,ALLOWPREM_CARD_DISC_RATE=@P_allowpremium

 
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)


/////////////////////////////////////done by shipra///////////////



============Start 7600====avinash=======24-02-2012==========================


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER PROCEDURE  [dbo].[rpt_issue_pcentre_wise]
	@pcompcode			as VARCHAR(8),
	@ppubcent			as VARCHAR(50),
	@pedtncode			as VARCHAR(200),
	@pfrom_date			as VARCHAR(20),
	@ptill_date			as VARCHAR(20),
	@pdateformat		as VARCHAR(20),
	@puserid            as VARCHAR(8),
	@chk_access			as varchar(2),
	@pratio_type		as varchar(20),
    @pextra1			as varchar(200),
    @pextra2			as varchar(200),
@pagtype as varchar(200)
AS

declare @v_frdt     datetime
declare @v_todt     datetime
declare @v_query    VARCHAR(max)
declare @qry        VARCHAR(max)

declare @v_var       varchar(max);
declare @v_var1      varchar(max);
declare @v_var2      varchar(max);
declare @v_var_sum   varchar(max);
declare @v_var_sum1  varchar(max);
declare @v_var_sum2  varchar(max);



CREATE TABLE #TEMP_RPT_ISSUE_PCENTER
( PUBL_CODE        VARCHAR(20),
  PUBL_NAME        VARCHAR(200),
  MAIN_EDTN_CODE   VARCHAR(20),
  MAIN_EDTN_NAME   VARCHAR(200),
  EDTN_CODE        VARCHAR(20),
  EDTN_NAME        VARCHAR(200),
  PUB_CENTER_NAME  VARCHAR(100),
  RATIO_PER        numeric(15,2),
  PUBL_AREA        numeric(15,2),
  AMT              numeric(15,2),
  REC_AMT          numeric(15,2),
  SESS_ID          numeric(10),
  PUBL_LINE        int)

CREATE TABLE #EDITIONWISERATIO_TEMP
(
  COMP_CODE          VARCHAR(8),
  PUB_CODE           VARCHAR(8),
  MAIN_EDITION_CODE  VARCHAR(20),
  SUB_EDITION_CODE   VARCHAR(20),
  EDITION_NAME       VARCHAR(50),
  EDITION_ALIAS      VARCHAR(50),
  PERCENTAGE         NUMeric(12,2),
  EFFECTIVE_DATE     DATEtime
)

set @v_frdt   = @pfrom_date
set @v_todt   = @ptill_date

if @pratio_type='C' begin--based on circulation copy
   insert into #editionwiseratio_temp(comp_code ,pub_code,main_edition_code,sub_edition_code ,
            edition_name ,edition_alias ,percentage,effective_date) 
    select a.comp_code comp_code,a.pub_code pub_code,a.main_edtn_code main_edtn_code,b.Edition_Code edtn_code,
    b."Edition_Name" edtn_name,b.Edition_Alias edtn_alias,
    case when isnull(cast(a.main_no_of_cir as numeric),0)  >0 then round(((cast(b."No_Of_Circulation" as numeric)*100)/case isnull(a.main_no_of_cir,0) when 0 then 1 else a.main_no_of_cir end ),2)
    else round((
    (cast(b.No_Of_Circulation as numeric)*100)/
    case isnull(b.No_Of_Circulation,0) when 0 then 1 else b.No_Of_Circulation end 
    ),2) end edtn_ratio,getdate() eff_date  
    from
    (select Comp_Code comp_code,Pub_Code pub_code,City_Code city_code,Edition_Code main_edtn_code,Edition_Name main_edtn_name,Edition_Alias main_edtn_alias,
    isnull(coalesce(No_Of_Circulation,null,'0'),'0') main_no_of_cir from edition_mast 
    where Edition_Type='Main Edition') a,edition_mast b 
    where b.Comp_Code=a.comp_code and b.Pub_Code=a.pub_code and b.City_Code=a.city_code and b.Edition_Type='Edition'
    order by a.pub_code,a.edtn_alias,a.city_code; 
end
else--based on sub edition wise ratio 
begin
    insert into #editionwiseratio_temp(comp_code ,pub_code,main_edition_code,sub_edition_code ,
            edition_name ,edition_alias ,percentage,effective_date)
    select comp_code,pub_code,main_edition_code,sub_edition_code,edition_name edition_name,edition_name edition_alias,percentage,effective_date 
    from editionwiseratio_mast
    order by pub_code,main_edition_code,edition_alias
end



declare c11 cursor for
            select a.publ_code,B."Edition_Alias" as edition, new_edition_code Edition_Code, dbo.get_edtn(B."Edition_Alias",'-') main_edition_code, 
            PUB_CENT_NAME,sum(amount) amount,sum(dpub_size) dpub_size,sum(lpub_size) lpub_size  from ( 
            SELECT DISTINCT d.Comp_Code, d.Publication_Code publ_code, d.Edition_Code as Edition_Code, b.pub_center as PUB_CENT_NAME,
			ROUND((SUM(CONVERT(FLOAT, Bill_Amt * ISNULL(e.percentage, 100) / CONVERT(FLOAT, 100)))), 2) as amount,
			ISNULL(e.SUB_EDITION_CODE, d.Edition_Code) as new_edition_code,	SUM(CONVERT(FLOAT, Size_Book)) as dpub_size, 0 as lpub_size
			FROM  edition_mast m  LEFT OUTER JOIN  #editionwiseratio_temp e  ON  m.Edition_Code  = e."MAIN_EDITION_CODE" ,
			tbl_booking_insert d, branch_mst b, tbl_booking_mast t, agency_mast a 
			WHERE	 d.Comp_Code  = m.Comp_Code AND	d.Comp_Code  = t.Comp_code AND	d.Cio_Booking_Id  = t.cio_booking_id
			AND	d.Edition_Code  = m.Edition_Code AND	(b.pub_center  = @ppubcent OR	@ppubcent  is null OR	@ppubcent  ='') and
 ( t.Agency_type=@pagtype or @pagtype is null or @pagtype='') 
			AND	t.Agency_sub_code  = a.code_subcode AND	t.branch  = b.Branch_Code AND	d.Insert_Date  between @v_frdt  and  @v_todt
			AND	d.Insert_Status  not in ( 'cancel'  , 'hold'  , 'booked'  ) AND	Edition_Type  = 'Main Edition'
			AND	(d.Height  is not null AND	d.Width  is not null)	
			GROUP BY d.Comp_Code, d.Publication_Code, d.Edition_Code,b.pub_center, ISNULL(e.SUB_EDITION_CODE, d.Edition_Code) 
union all
            SELECT d.Comp_Code, d.Publication_Code publ_code, d.Edition_Code as Edition_Code, b.pub_center as PUB_CENT_NAME,
			ROUND((SUM(CONVERT(FLOAT, Bill_Amt * ISNULL(e.percentage, 100) / CONVERT(FLOAT, 100)))), 2) as amount,
			ISNULL(e.SUB_EDITION_CODE, d.Edition_Code) as new_edition_code, 0 as dpub_size,	SUM(CONVERT(FLOAT, Size_Book)) as lpub_size
			FROM  edition_mast m  LEFT OUTER JOIN  #editionwiseratio_temp e  ON  m.Edition_Code  = e.MAIN_EDITION_CODE ,
		    tbl_booking_insert d, branch_mst b, tbl_booking_mast t,agency_mast a 
			WHERE	 d.Comp_Code  = m.Comp_Code AND	d.Comp_Code  = t.Comp_code AND	d.Cio_Booking_Id  = t.cio_booking_id
			AND	d.Edition_Code  = m.Edition_Code AND	(b.pub_center  = @ppubcent OR	@ppubcent  is null OR	@ppubcent  ='')
and( t.Agency_type=@pagtype or @pagtype is null or @pagtype='') 
			AND	t.Agency_sub_code  = a.code_subcode AND	t.branch  = b.Branch_Code AND	d.Insert_Date  between @v_frdt  and  @v_todt
			AND	d.Insert_Status  not in ( 'cancel'  , 'hold'  , 'booked'  ) AND	Edition_Type  = 'Main Edition'
			AND	(d.Height  is null AND	d.Width  is null)
			GROUP BY d.Comp_Code,d.Publication_Code,d.Edition_Code,b.pub_center,ISNULL(e.SUB_EDITION_CODE, d.Edition_Code) 
union all            
            SELECT d.Comp_Code, d.Publication_Code publ_code, d.Edition_Code as Edition_Code, b.pub_center as PUB_CENT_NAME,
			ROUND(SUM(CONVERT(FLOAT, d.Bill_Amt)), 2) as amount, d.Edition_Code as new_edition_code,
			ROUND(SUM(CONVERT(FLOAT, Size_Book)), 2) as dpub_size, 0 as lpub_size
			FROM  edition_mast m, tbl_booking_insert d, branch_mst b, tbl_booking_mast t, agency_mast a 
			WHERE	 d.Comp_Code  = m.Comp_Code AND	d.Comp_Code  = t.Comp_code
			AND	d.Cio_Booking_Id  = t.cio_booking_id AND	d.Edition_Code  = m.Edition_Code 
			AND	(b.pub_center  = @ppubcent OR	@ppubcent  is null OR	@ppubcent  ='') AND	t.Agency_sub_code  = a.code_subcode
			AND	t.branch  = b.Branch_Code AND	d.Insert_Date  between @v_frdt  and  @v_todt
and( t.Agency_type=@pagtype or @pagtype is null or @pagtype='') 
			AND	d.Insert_Status  not in ( 'cancel'  , 'hold'  , 'booked'  ) AND	Edition_Type  <> 'Main Edition'
			AND	(d.Height  is not null AND	d.Width  is not null)
			GROUP BY d.Comp_Code, d.Publication_Code, d.Edition_Code, b.pub_center,d.Edition_Code 
union all
            SELECT d.Comp_Code, d.Publication_Code publ_code, d.Edition_Code as Edition_Code, b.pub_center as PUB_CENT_NAME,
			ROUND(SUM(CONVERT(FLOAT, d.Bill_Amt)), 2) as amount, d.Edition_Code as new_edition_code,
			0 as dpub_size, SUM(CONVERT(FLOAT, Size_Book)) as lpub_size
			FROM  edition_mast m, tbl_booking_insert d, branch_mst b, tbl_booking_mast t, agency_mast a 
			WHERE	 d.Comp_Code  = m.Comp_Code AND	d.Comp_Code  = t.Comp_code
			AND	d.Cio_Booking_Id  = t.cio_booking_id AND	d.Edition_Code  = m.Edition_Code
			AND	(b.pub_center  = @ppubcent OR	@ppubcent  is null OR	@ppubcent  ='')
and( t.Agency_type=@pagtype or @pagtype is null or @pagtype='') 
			AND	t.Agency_sub_code  = a.code_subcode AND	t.branch  = b.Branch_Code
			AND	d.Insert_Date  between @v_frdt  and  @v_todt AND	d.Insert_Status  not in ( 'cancel'  , 'hold'  , 'booked'  )
			AND	Edition_Type  <> 'Main Edition'	AND	(d.Height  is null AND	d.Width  is null)
			GROUP BY d.Comp_Code, d.Publication_Code, d.Edition_Code, b.pub_center,d.Edition_Code 
            ) A,  edition_mast B
            where new_edition_code=b.Edition_Code
            group by  a.publ_code,B.Edition_Alias , new_edition_code,  PUB_CENT_NAME order by B.Edition_Alias
            

declare c12 cursor for
            select a.publ_code,B."Edition_Alias" as edition, new_edition_code Edition_Code, dbo.get_edtn(B."Edition_Alias",'-') main_edition_code, 
            PUB_CENT_NAME,sum(amount) amount,sum(dpub_size) dpub_size,sum(lpub_size) lpub_size  from ( 
            SELECT DISTINCT d.Comp_Code, d.Publication_Code publ_code, d.Edition_Code as Edition_Code, b.pub_center as PUB_CENT_NAME,
			ROUND((SUM(CONVERT(FLOAT, Bill_Amt * ISNULL(e.percentage, 100) / CONVERT(FLOAT, 100)))), 2) as amount,
			ISNULL(e.SUB_EDITION_CODE, d.Edition_Code) as new_edition_code,	SUM(CONVERT(FLOAT, Size_Book)) as dpub_size, 0 as lpub_size
			FROM  edition_mast m  LEFT OUTER JOIN  #editionwiseratio_temp e  ON  m.Edition_Code  = e.MAIN_EDITION_CODE ,
			tbl_booking_insert d, branch_mst b, tbl_booking_mast t, agency_mast a 
			WHERE	 d.Comp_Code  = m.Comp_Code AND	d.Comp_Code  = t.Comp_code AND	d.Cio_Booking_Id  = t.cio_booking_id
			AND	d.Edition_Code  = m.Edition_Code AND	(b.pub_center  = @ppubcent OR	@ppubcent  is null OR	@ppubcent  ='')
and( t.Agency_type=@pagtype or @pagtype is null or @pagtype='') 
			AND	t.Agency_sub_code  = a.code_subcode and  a.Branch_code=b.Branch_Code and @pextra1='A'
			AND	d.Insert_Date  between @v_frdt  and  @v_todt
			AND	d.Insert_Status  not in ( 'cancel'  , 'hold'  , 'booked'  ) AND	Edition_Type  = 'Main Edition'
			AND	(d.Height  is not null AND	d.Width  is not null)	
			GROUP BY d.Comp_Code, d.Publication_Code, d.Edition_Code,b.pub_center, ISNULL(e.SUB_EDITION_CODE, d.Edition_Code) 
union all
            SELECT d.Comp_Code, d.Publication_Code publ_code, d.Edition_Code as Edition_Code, b.pub_center as PUB_CENT_NAME,
			ROUND((SUM(CONVERT(FLOAT, Bill_Amt * ISNULL(e.percentage, 100) / CONVERT(FLOAT, 100)))), 2) as amount,
			ISNULL(e.SUB_EDITION_CODE, d.Edition_Code) as new_edition_code, 0 as dpub_size,	SUM(CONVERT(FLOAT, Size_Book)) as lpub_size
			FROM  edition_mast m  LEFT OUTER JOIN  #editionwiseratio_temp e  ON  m.Edition_Code  = e.MAIN_EDITION_CODE ,
		    tbl_booking_insert d, branch_mst b, tbl_booking_mast t,agency_mast a 
			WHERE	 d.Comp_Code  = m.Comp_Code AND	d.Comp_Code  = t.Comp_code AND	d.Cio_Booking_Id  = t.cio_booking_id
			AND	d.Edition_Code  = m.Edition_Code AND	(b.pub_center  = @ppubcent OR	@ppubcent  is null OR	@ppubcent  ='')
and( t.Agency_type=@pagtype or @pagtype is null or @pagtype='') 
			AND	t.Agency_sub_code  = a.code_subcode  and  a.Branch_code=b.Branch_Code and @pextra1='A' 
			AND	d.Insert_Date  between @v_frdt  and  @v_todt
			AND	d.Insert_Status  not in ( 'cancel'  , 'hold'  , 'booked'  ) AND	Edition_Type  = 'Main Edition'
			AND	(d.Height  is null AND	d.Width  is null)
			GROUP BY d.Comp_Code,d.Publication_Code,d.Edition_Code,b.pub_center,ISNULL(e.SUB_EDITION_CODE, d.Edition_Code) 
union all            
            SELECT d.Comp_Code, d.Publication_Code publ_code, d.Edition_Code as Edition_Code, b.pub_center as PUB_CENT_NAME,
			ROUND(SUM(CONVERT(FLOAT, d.Bill_Amt)), 2) as amount, d.Edition_Code as new_edition_code,
			ROUND(SUM(CONVERT(FLOAT, Size_Book)), 2) as dpub_size, 0 as lpub_size
			FROM  edition_mast m, tbl_booking_insert d, branch_mst b, tbl_booking_mast t, agency_mast a 
			WHERE	 d.Comp_Code  = m.Comp_Code AND	d.Comp_Code  = t.Comp_code
			AND	d.Cio_Booking_Id  = t.cio_booking_id AND	d.Edition_Code  = m.Edition_Code 
			AND	(b.pub_center  = @ppubcent OR	@ppubcent  is null OR	@ppubcent  ='') AND	t.Agency_sub_code  = a.code_subcode
and( t.Agency_type=@pagtype or @pagtype is null or @pagtype='') 
			 and  a.Branch_code=b.Branch_Code and @pextra1='A' AND	d.Insert_Date  between @v_frdt  and  @v_todt
			AND	d.Insert_Status  not in ( 'cancel'  , 'hold'  , 'booked'  ) AND	Edition_Type  <> 'Main Edition'
			AND	(d.Height  is not null AND	d.Width  is not null)
			GROUP BY d.Comp_Code, d.Publication_Code, d.Edition_Code, b.pub_center,d.Edition_Code 
union all
            SELECT d.Comp_Code, d.Publication_Code publ_code, d.Edition_Code as Edition_Code, b.pub_center as PUB_CENT_NAME,
			ROUND(SUM(CONVERT(FLOAT, d.Bill_Amt)), 2) as amount, d.Edition_Code as new_edition_code,
			0 as dpub_size, SUM(CONVERT(FLOAT, Size_Book)) as lpub_size
			FROM edition_mast m, tbl_booking_insert d, branch_mst b, tbl_booking_mast t, agency_mast a 
			WHERE d.Comp_Code  = m.Comp_Code AND	d.Comp_Code  = t.Comp_code
			AND	d.Cio_Booking_Id  = t.cio_booking_id AND	d.Edition_Code  = m.Edition_Code
			AND	(b.pub_center  = @ppubcent OR	@ppubcent  is null OR	@ppubcent  ='')
and( t.Agency_type=@pagtype or @pagtype is null or @pagtype='') 
			AND	t.Agency_sub_code  = a.code_subcode  and  a.Branch_code=b.Branch_Code and @pextra1='A'
			AND	d.Insert_Date  between @v_frdt  and  @v_todt AND	d.Insert_Status  not in ( 'cancel'  , 'hold'  , 'booked'  )
			AND	Edition_Type  <> 'Main Edition'	AND	(d.Height  is null AND	d.Width  is null)
			GROUP BY d.Comp_Code, d.Publication_Code, d.Edition_Code, b.pub_center,d.Edition_Code 
            ) A,  edition_mast B
            where new_edition_code=b.Edition_Code
            group by  a.publ_code,B.Edition_Alias , new_edition_code,  PUB_CENT_NAME order by B.Edition_Alias

declare @v12_publ_code as varchar(200)
declare @v12_edition as varchar(200)
declare @v12_Edition_Code as varchar(200)
declare @v12_main_edition_code as varchar(200)
declare @v12_PUB_CENT_NAME as varchar(200)
declare @v12_amount as numeric(14,2)
declare @v12_dpub_size as numeric(14,2)
declare @v12_lpub_size as numeric(14,2)

declare @v11_publ_code as varchar(200)
declare @v11_edition as varchar(200)
declare @v11_Edition_Code as varchar(200)
declare @v11_main_edition_code as varchar(200)
declare @v11_PUB_CENT_NAME as varchar(200)
declare @v11_amount as numeric(14,2)
declare @v11_dpub_size as numeric(14,2)
declare @v11_lpub_size as numeric(14,2)

 if @pextra1='A' begin--branch based on agency master	
        OPEN c12 
			fetch NEXT FROM c12 INTO @v12_publ_code,@v12_edition,@v12_Edition_Code,@v12_main_edition_code,@v12_PUB_CENT_NAME,@v12_amount,@v12_dpub_size,@v12_lpub_size
			WHILE (@@FETCH_STATUS =0) begin
			
				insert into #temp_rpt_issue_pcenter(publ_code,edtn_code,edtn_name,pub_center_name,amt,sess_id,main_edtn_code,main_edtn_name,publ_area,publ_line)
							values(@v12_publ_code,@v12_Edition_Code,@v12_edition,@v12_PUB_CENT_NAME,@v12_amount,@@spid,@v12_main_edition_code,@v12_main_edition_code,@v12_dpub_size,@v12_lpub_size);
			
			fetch NEXT FROM c12 INTO @v12_publ_code,@v12_edition,@v12_Edition_Code,@v12_main_edition_code,@v12_PUB_CENT_NAME,@v12_amount,@v12_dpub_size,@v12_lpub_size
		END 		
		close c12		
		deallocate c12
end
else--branch based on transsaction     
begin
	OPEN c11 
			fetch NEXT FROM c11 INTO @v11_publ_code,@v11_edition,@v11_Edition_Code,@v11_main_edition_code,@v11_PUB_CENT_NAME,@v11_amount,@v11_dpub_size,@v11_lpub_size
			WHILE (@@FETCH_STATUS =0) begin
			print(@v11_PUB_CENT_NAME)
				insert into #temp_rpt_issue_pcenter(publ_code,edtn_code,edtn_name,pub_center_name,amt,sess_id,main_edtn_code,main_edtn_name,publ_area,publ_line)
						values(@v11_publ_code,@v11_Edition_Code,@v11_edition,@v11_PUB_CENT_NAME,@v11_amount,@@spid,@v11_main_edition_code,@v11_main_edition_code,@v11_dpub_size,@v11_lpub_size);
			
			fetch NEXT FROM c11 INTO @v11_publ_code,@v11_edition,@v11_Edition_Code,@v11_main_edition_code,@v11_PUB_CENT_NAME,@v11_amount,@v11_dpub_size,@v11_lpub_size
		END 		
		close c11		
		deallocate c11
end

declare c1 cursor for
        select distinct pub_center_name pubcent_name,isnull((select Pub_Cent_name from pub_cent_mast 
        where Pub_cent_Code=d.pub_center_name),pub_center_name) pub_name from #temp_rpt_issue_pcenter d  
        order by d.pub_center_name;

declare @v1_pubcent_name as varchar(500)
declare @v1_pub_name as varchar(500)
OPEN c1 
		fetch NEXT FROM c1 INTO @v1_pubcent_name,@v1_pub_name
        WHILE (@@FETCH_STATUS = 0) begin
			 if @pextra2 ='W' begin--with Size
				 if (@v_var is null or @v_var='') begin
					  
					  set @v_var       ='case d.pub_center_name when '+''''+@v1_pubcent_name+''''+' then d.publ_area else 0 end "'+'D#'+@v1_pubcent_name+'"';
					  --set  @v_var        ='(case  d.pub_center_name when  '+''''+@v1_pubcent_name+''''+' then abs(d.amt) end)"'+@v1_pubcent_name+'"';
					  set @v_var       =@v_var+','+'case d.pub_center_name when '+''''+@v1_pubcent_name+''''+' then d.publ_line else 0 end "'+'L#'+@v1_pubcent_name+'"';
                      set @v_var       =@v_var+','+'case d.pub_center_name when '+''''+@v1_pubcent_name+''''+' then (d.amt) else 0 end "'+'A#'+@v1_pubcent_name+'"';
					  set @v_var_sum   ='round(sum(a."'+'D#'+@v1_pubcent_name+'"),2)'+' "'+'D#'+@v1_pub_name+'"';
					  --set @v_var_sum    ='round(sum(a."'+@v1_pubcent_name+'"),2)'+' "'+@v1_pubcent_name+'"'
					  set @v_var_sum   =@v_var_sum+','+'round(sum("'+'L#'+@v1_pubcent_name+'"),2)'+' "'+'L#'+@v1_pub_name+'"';
                      set @v_var_sum   =@v_var_sum+','+'round(sum("'+'A#'+@v1_pubcent_name+'"),2)'+' "'+'A#'+@v1_pub_name	+'"';
				 end
				 else
				 begin
					  set @v_var       =@v_var+','+'case d.pub_center_name when '+''''+@v1_pubcent_name+''''+' then d.publ_area else 0 end "'+'D#'+@v1_pubcent_name+'"';
					  set @v_var       =@v_var+','+'case d.pub_center_name when '+''''+@v1_pubcent_name+''''+' then d.publ_line else 0 end "'+'L#'+@v1_pubcent_name+'"';
                      set @v_var       =@v_var+','+'case d.pub_center_name when '+''''+@v1_pubcent_name+''''+' then (d.amt) else 0 end "'+'A#'+@v1_pubcent_name+'"';
					  set @v_var_sum   =@v_var_sum+','+'round(sum(a."'+'D#'+@v1_pubcent_name+'"),2)'+' "'+'D#'+@v1_pub_name+'"';
					  set @v_var_sum   =@v_var_sum+','+'round(sum("'+'L#'+@v1_pubcent_name+'"),2)'+' "'+'L#'+@v1_pub_name+'"';
                      set @v_var_sum   =@v_var_sum+','+'round(sum("'+'A#'+@v1_pubcent_name+'"),2)'+' "'+'A#'+@v1_pub_name	+'"';
				 end 
			end
			else
			begin
				 if (@v_var is null or @v_var='') begin
					  
					set @v_var       ='case d.pub_center_name when '+''''+@v1_pubcent_name+''''+' then (d.amt) else 0 end "'+'A#'+@v1_pubcent_name+'"';
                    set @v_var_sum   ='round(sum("'+'A#'+@v1_pubcent_name+'"),2)'+' "'+'A#'+@v1_pub_name+'"';
				 end
				 else
				 begin
					set @v_var       =@v_var+','+'case d.pub_center_name when '+''''+@v1_pubcent_name+''''+' then (d.amt) else 0 end "'+'A#'+@v1_pubcent_name+'"';
                    set @v_var_sum   =@v_var_sum+','+'round(sum("'+'A#'+@v1_pubcent_name+'"),2)'+' "'+'A#'+@v1_pub_name+'"';
				 end				
			end
		fetch NEXT FROM c1 INTO  @v1_pubcent_name,@v1_pub_name
		END 		
close c1	
deallocate c1


print(@v_var)
if (@v_var is not null and @v_var<>'') begin
	 if @pextra2 ='W' begin--with Size
	 
		set @v_query='select a.main_edtn_name,a.edtn_code,a.edtn_name,dbo.edtn_pcenter_name('+''''+@pcompcode+''''+',a.edtn_code) as pcenter,'+@v_var_sum+',  round(sum("PUB_SIZE"),2) as "DISPLAY",round(sum("PUB_LINE"),2) as "LINEAGE" ,  round(sum(a.AMT),2) as "TOT",
		(select Edition_Type from Edition_mast where Edition_Code=edtn_code  )as "Type",
		 (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code in (select Pub_Code from edition_mast where Edition_Code=edtn_code ))as "Publication"
		from (
		select distinct d.publ_code,d.main_edtn_name as main_edtn_name,d.edtn_code as edtn_code,d.edtn_name as edtn_name,
		'+@v_var+',isnull(d.Amt,0) as "AMT",nvl(d.publ_area,0) as "PUB_SIZE",nvl(d.publ_line,0) as "PUB_LINE" from #temp_rpt_issue_pcenter d )a group by a.main_edtn_name,a.edtn_code,a.edtn_name order by a.edtn_name,pcenter'
	end
	else
	begin
		set @v_query='select
		a.main_edtn_name,a.edtn_code,a.edtn_name,dbo.edtn_pcenter_name('+''''+@pcompcode+''''+',a.edtn_code) as pcenter,'+@v_var_sum+' ,  round(sum(a.AMT),2) as "TOT",
		(select Edition_Type from Edition_mast where Edition_Code=edtn_code  )as "Type",
		 (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code in (select Pub_Code from edition_mast where Edition_Code=edtn_code ))as "Publication"
		from (
		select distinct d.publ_code,d.main_edtn_name as main_edtn_name,d.edtn_code as edtn_code,d.edtn_name as edtn_name,
		'+@v_var+',isnull(d.Amt,0) as "AMT" from #temp_rpt_issue_pcenter d )a group by a.main_edtn_name,a.edtn_code,a.edtn_name order by a.edtn_name,pcenter'
	end
end 
      
set @qry='

     select (SELECT dbo.initcap(Comp_Name)   from comp_mst where Comp_Code='''+@pcompcode+''')AS "companyname",
            dbo.edtn_pcenter_name('+''''+@pcompcode+''''+',a.edtn_code) as pcenter,'+@v_var_sum+'
            from (select distinct d.edtn_code as edtn_code,d.edtn_name,
           '+@v_var+' from #temp_rpt_issue_pcenter d )a group by dbo.edtn_pcenter_name('+''''+@pcompcode+''''+',a.edtn_code) 
           order by dbo.edtn_pcenter_name('+''''+@pcompcode+''''+',a.edtn_code)'

print(@v_query)
exec(@v_query)

print(@qry)

exec(@qry)


drop  table  #TEMP_RPT_ISSUE_PCENTER
drop  table  #EDITIONWISERATIO_TEMP


============End 7600====avinash=======24-02-2012==========================


/////////////////issue no 7583////////////////////////////////////////



USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[AdvTeamDetailSave]    Script Date: 05/24/2012 10:35:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[AdvTeamDetailSave]


@Comp_Code as varchar(8),
@Team_Code as varchar(8),
@Team_Name as varchar(20),
@userid as varchar(8),
@zone as varchar(50),
@attachment as varchar(50),
@signature as varchar(50)
as 



  insert into Adv_Exec_Master(Comp_Code,Team_Code,Team_Name,userid,creation_datetime,branch_code,SIGN,ATTACHMENT) values(@Comp_Code,@Team_Code,@Team_Name,@userid,getdate(),@zone,@signature,@attachment)













///////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[AdvTeamDetail]    Script Date: 05/24/2012 10:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








ALTER  proc [dbo].[AdvTeamDetail]
(
@Comp_Code as varchar(8),
@Team_Code as varchar(8),
@Team_Name as varchar(20),
@userid as varchar(8),
@zone as varchar(50),
@attachment as varchar(70),
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
	SIGN varchar(50),
	ATTACHMENT varchar(70)
) 


declare @countnum int
declare @query as varchar (1500)

set @Team_Code=replace(@Team_Code,'','''')
--set @Team_Name=replace(@Team_Name,'','''')


if(@Flag=0)
begin
 set  @query='insert #Adv_Exec_Master_tmp select  Comp_Code,Team_Code,Team_Name,userid,creation_datetime,ad_cat,branch_code,SIGN,ATTACHMENT  from Adv_Exec_Master  where Comp_Code='''+@Comp_Code+''' '  ---and userid='''+@userid+'''and Team_Code like '%''@Team_Code''%' and Team_Name like '%@Team_Name%'


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
			update Adv_Exec_Master set Team_Name=@Team_Name  , branch_code=@zone,SIGN=@signature,ATTACHMENT=@attachment where Team_Code=@Team_Code and Comp_Code=@Comp_Code  --and userid=@userid	
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









//////////////////////////////////end of 7583//////////////////////




/////////////////////////issue no 7584///////////////////////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[RetainerInsertDetail]    Script Date: 05/24/2012 15:59:12 ******/
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
@p_empcode as varchar(50),
@attachment as varchar(50),
@p_maincdp as varchar(50)
)
as

declare @query varchar(1000)
declare @query3 varchar(1000)


if(@flag=0)
begin

set @query = 'insert into RetainerMaster(Comp_Code ,Retain_Code ,userid ,Retain_Name ,Retain_Alias ,Add1 ,Street ,City_Code ,Zip ,Dist_Code ,State_Code ,Zone_Code,Region_Code,Country_Code ,phone1 ,Phone2 ,Fax ,EmailID ,PAN_No ,Credit_Days,Remarks , pubcent_code,Creation_Datetime, retain_status, to_date,BOXMATTER,PUBLICATION,EDITION,SUPPLEMENT,TALUKA,REPRESENTATIVE,Branch_code,CREDIT_LIMIT,MOBILENO,SIGN,HR_CODE,ATTACHMENT,CDP)values ('''+@Comp_Code1+''' ,'''+@Retain_Code1+''' ,'''+@userid1+''' ,'''+@Retain_Name1+''' ,'''+@Retain_Alias1+''' ,'''+@Add11+''' ,'''+@Street1+''','''+@City_Code1+''' ,'''+@Zip1+''' ,'''+@Dist_Code1+''','''+@State_Code1+''' ,'''+@zone_code1+''' ,'''+@region_code1+''' ,'''+@Country_Code1+''' ,'''+@phone11+''' ,'''+@Phone21+''' ,'''+@Fax1+''','''+@EmailID1+''','''+@PAN_No1+''' ,'''+@Credit_Days1+''' ,'''+@Remarks1+''','''+@pubcent1+''',getdate(),'''','''','''+@Box1+''','''+@Publication11+''' ,'''+@Edition11+''','''+@Supplement11+''','''+@taluka+''','''+@repname+''','''+@branchcode+''','''+@creditlimit+''','''+ @mobile1+''','''+@signature+''','''+@p_empcode+''','''+@attachment+''','''+@p_maincdp+''') '

end
if(@flag=1)
begin  
	set @query = 'update RetainerMaster set Retain_Name = '''+@Retain_Name1+'''  ,Retain_Alias = '''+@Retain_Alias1+'''  ,Add1 = '''+@Add11 +''',Street = '''+@Street1+''' ,City_Code = '''+@City_Code1+'''  ,Zip = '''+@Zip1+'''  ,Dist_Code = '''+@Dist_Code1+'''  ,State_Code = '''+@State_Code1+''' ,zone_code = '''+@zone_code1+'''  ,region_code = '''+@region_code1+'''  ,Country_Code = '''+@Country_Code1+'''  ,phone1 = '''+@phone11+'''  ,Phone2 = '''+@Phone21+'''  ,Fax = '''+@Fax1+'''  ,EmailID = '''+@EmailID1+'''  ,PAN_No = '''+@PAN_No1+'''  ,Credit_Days = '''+@Credit_Days1+''',Remarks = '''+@Remarks1+''' ,    pubcent_code='''+@pubcent1+''' 
,    BOXMATTER='''+@Box1+''' ,PUBLICATION = '''+@Publication11+'''  ,EDITION = '''+@Edition11 +''',SUPPLEMENT = '''+@Supplement11+''',TALUKA='''+@taluka+''',REPRESENTATIVE='''+@repname+''',Branch_code='''+@branchcode+''',CREDIT_LIMIT='''+@creditlimit+''',MOBILENO='''+ @mobile1+''',SIGN='''+@signature+''',HR_CODE='''+@p_empcode+''',CDP='''+@p_maincdp+''',ATTACHMENT='''+@attachment+''' where comp_code = '''+@Comp_Code1 +''' and Retain_Code = '''+@Retain_Code1+''''    --/*   and userid ='''+@userid+'''   */  
--set @query3 = 'update tmpretainer set Retain_Name = '''+@Retain_Name+'''  ,Retain_Alias = '''+@Retain_Alias+'''  ,Add1 = '''+@Add1 +''',Street = '''+@Street+''' ,City_Code = '''+@City_Code+'''  ,Zip = '''+@Zip+'''  ,Dist_Code = '''+@Dist_Code+'''  ,State_Code = '''+@State_Code+'''  ,Country_Code = '''+@Country_Code+'''  ,phone1 = '''+@phone1+'''  ,Phone2 = '''+@Phone2+'''  ,Fax = '''+@Fax+'''  ,EmailID = '''+@EmailID+'''  ,PAN_No = '''+@PAN_No+'''  ,Credit_Days = '''+@Credit_Days+''',Remarks = '''+@Remarks+'''   where comp_code = '''+@Comp_Code +'''and userid ='''+@userid+''' and Retain_Code = '''+@Retain_Code+'''' 
end


print(@query)
exec(@query)
--print(@query3)
--exec(@query3)








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
set @query=' select Comp_Code,userid,Retain_Code,Retain_Name,Retain_Alias,Add1,Street,City_Code,Zip,Dist_Code,State_Code,Region_Code,Country_Code,Phone1,Phone2,Fax,EmailID,Credit_Days,Remarks,PAN_No,Retain_status,getdate(),getdate(),pubcent_code,BOXMATTER,PUBLICATION,EDITION,SUPPLEMENT,TALUKA,REPRESENTATIVE as "repname",Branch_code,CREDIT_LIMIT,MOBILENO,SIGN,(select NAME+''(''+EMP_CODE+'')'' from HR_EMP_MST where COMP_CD='''+@compcode+''' AND EMP_CODE=RetainerMaster.HR_CODE)AS HR_CODE,(select ACC_NAME   from fa_acc_mast where COMP_CODE='''+@compcode+''' and CDP= RETAINERMASTER.CDP )AS ACC_NAME,CDP,ATTACHMENT from  RetainerMaster where Comp_code='''+@compcode+''''

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



















//////////////////////////////end of issue 7584/////////////////////////



////////////////////////////////issue no 7579///////////////////////

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[Ro_Report]    Script Date: 05/25/2012 10:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
					,a."branch" as BRANCH
					,a."Bill_pay" PAY_MODE_CODE
					,(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=a."Comp_code" and "Pay_Mode_Code"=a."Bill_pay") PAY_MODE_NAME
        
					
					 from tbl_booking_mast a ,tbl_booking_insert i ,agency_mast b,adv_cat_mast c where
 a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
					a.Comp_code='''+@pcompcode+''' AND
					a."Comp_code"=i."Comp_Code" 
	 AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
			AND a."cio_booking_id"=i."Cio_Booking_Id" and
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
            a."Agency_sub_code"=b."code_subcode" 
			 AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
			and i."Insert_Status"<>''cancel'' ';
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
					,a."Bill_pay" PAY_MODE_CODE
					,(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=a."Comp_code" and "Pay_Mode_Code"=a."Bill_pay") PAY_MODE_NAME

					
					
					from TBL_BOOKING_MAST a,tbl_booking_insert i ,EXEC_MAST,agency_mast b ,adv_cat_mast c
            where a."Ad_type_code"=c."Adv_Type" and a."Ad_cat_code"=c."Adv_Cat_Code" and a."Comp_code"=c."Comp_Code" and
				a.Comp_code='''+@pcompcode+''' AND a."Comp_code"=i."Comp_Code" 
		 AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
			AND a."cio_booking_id"=i."Cio_Booking_Id" and
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
					,a."Bill_pay" PAY_MODE_CODE
					,(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=a."Comp_code" and "Pay_Mode_Code"=a."Bill_pay") PAY_MODE_NAME
					
					 from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER,agency_mast b ,adv_cat_mast c
            where  a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and 
			a.Comp_code='''+@pcompcode+''' AND a."Comp_code"=i."Comp_Code" 
		AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
		AND a."cio_booking_id"=i."Cio_Booking_Id" and
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
            a."Executive_code"=exec_mast."Exe_no"  
		AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
			and i."Insert_Status"<>''cancel'' '
end
         else begin
         set @query1='select distinct RETAINERMASTER.Retain_Name     as "EXE_RET",RETAINERMASTER.Dist_Code   as "DISTRICT",
            (SELECT Branch_Name FROM BRANCH_MST where  a.branch = Branch_Code) as "BRANCH",
           SUM(case RODOCSTATUS when ''o'' then 1 else 0 end) ORIGINAL,
			SUM(case RODOCSTATUS when ''f'' then 1 else 0 end) FAX,
			SUM(case RODOCSTATUS when ''x'' then 1 else 0 end) XEROX,
			SUM(case RODOCSTATUS when ''o'' then 0 when ''f'' then 0 when ''x'' then 0 else 1 end) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER ,agency_mast b/*,adv_cat_mast c*/
            where  a.Comp_code='''+@pcompcode+''' AND a."Comp_code"=i."Comp_Code" 
		AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
		AND a."cio_booking_id"=i."Cio_Booking_Id" and
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
            set @query1=@query1+' GROUP BY a."cio_booking_id"  ,b."Agency_Name"   ,a."Executive_code",a.RETAINER,"Client_code",c."Adv_Cat_Name","RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT,a."Bill_pay",a."branch",a."Comp_code"'
        End    
        Else if(@age_exeret='2')Begin
            set @query1=@query1+' group by a."cio_booking_id"  ,b."Agency_Name",EXEC_MAST."Exec_name","Client_code",c."Adv_Cat_Name" ,"RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT ,a."Bill_pay",a."branch",a."Comp_code"'
        End    
        Else Begin
            set @query1=@query1+' GROUP BY a."cio_booking_id"  ,b."Agency_Name",RETAINERMASTER."Retain_Name","Client_code",c."Adv_Cat_Name" ,"RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT,a."Bill_pay",a."branch",a."Comp_code"'
        End
    End 

    print(@query1)
	exec(@query1)
    
    select comp_mst.Comp_Name from comp_mst where comp_mst.Comp_Code=@pcompcode









//////////////////////////////////end of issue 7579//////////////////////////


===start=======7588===avinash====25-may2012========================================
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


/****** Object:  StoredProcedure [dbo].[Schedulereport1]    Script Date: 01/24/2012 11:16:33 ******/
                                                                     
                                                                     
                                                                     
                                             
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
				isnull(Agrred_rate,TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", TBL_BOOKING_MAST.Caption as "Caption", 
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
				isnull(Agrred_rate,TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", TBL_BOOKING_MAST.Caption as "Caption", 
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
				isnull(TBL_BOOKING_MAST.Agrred_rate, TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", TBL_BOOKING_MAST.Caption as "Caption", 
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
				isnull(TBL_BOOKING_MAST.Agrred_rate, TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", TBL_BOOKING_MAST.Caption as "Caption", 
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


=============end=======7588=========avinash============================================================



//////////////// shipra --------5/25/2012------------done by lata mam/////////////////



USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[insertintobookchild]    Script Date: 05/25/2012 17:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
@disc_p as float
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


insert into tbl_booking_insert_g(cio_booking_id,Edition,Insert_date,Col_code,Height,Width,Size_book,Page_post,Premium1,Prem_per1,Premium2,Prem_per2,Premium_allow,Ad_cat,Ad_sub_cat,Latest_by,Status_material,File_name,Card_rate,Disc_rate,Insert_status,Bill_status,comp_code,Userid,Repeating_date,no_insert,Edition_code,Publication_code,Pub_cent_code,Supp_code,Pai_free_ins,Agreed_rate,Solo_rate,Gross_rate,Page_no,Remarks,Page_prem,page_per,No_ofcolumn,Bill_Amt,Bill_rate,Logo_H,Logo_W,Logo_name,AD_SUBCAT3,AD_SUBCAT4,AD_SUBCAT5,PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE,RESOURCE_NO,CAPTION,DEALER_H, DEALER_W,DISCOUNT)
values(@cioid,@edition,@insertdate,@colid,@height,@width,@totalsize,@pagepost,@premium1,@premper1,@premium2,@premper2,@premallow,@adcategory,@adsubcat,@latestdate,@material,@matfilename,@cardrate,@discrate,@insertstatus,@billstatus,@compcode,@userid,@repeat,@insertno,@edi,@publi,@pub_cent,@supp,@paid,@agrrate,@solorate,@grossrate,@insert_pageno,@insert_remarks,@page_code,@page_per,@noofcol,@billamt,@billrate,@logo_h,@logo_w,@logo_name,@ad_cat_3,@ad_cat_4,@ad_cat_5, @pkgcode,@gridins,@pkgalias,@splboldsizevalue,@vatrate_p,@boxcharge_p,@vat_inc_p,@grossamtlocal_p,@billamtlocal_p,@sectioncode_p,@resourceno_p,@caption_inserts_p,@dealerheight,@dealerwidth,@disc_p)

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











USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[insertintobookchild_display]    Script Date: 05/25/2012 17:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
@subedidata as varchar(5000), 
@disc_p as float
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
update tbl_booking_insert set Edition=@edition,Insert_date=@insertdate,Col_code=@colid,Height=@height,Width=@width,Size_book=@totalsize,Page_post=@pagepost,Premium1=@premium1,Prem_per1=@premper1,Premium2=@premium2,Prem_per2=@premper2,Premium_allow=@premallow,Ad_cat=@adcategory,Ad_sub_cat=@adsubcat,Latest_by=@latestdate,Status_material=@material,File_name=@matfilename,Card_rate=@cardrate,Disc_rate=@discrate,Insert_status=@insertstatus,Bill_status=@billstatus,comp_code=@compcode,Userid=@userid,Repeating_date=@repeat,no_insert=@insertno,Edition_code=@edi,Publication_code=@publi,Pub_cent_code=@pub_cent,Supp_code=@supp,Pai_free_ins=@paid,Agreed_rate=@agrrate,Solo_rate=@solorate,Gross_rate=@grossrate,Page_no=@insert_pageno,Remarks=@insert_remarks,Page_prem=@page_code,page_per=@page_per,No_ofcolumn=@noofcol,Bill_Amt=@billamt,Bill_rate=@billrate,Logo_H=@logo_h,Logo_W=@logo_w,Logo_name=@logo_name,AD_SUBCAT3=@ad_cat_3,AD_SUBCAT4=@ad_cat_4,AD_SUBCAT5=@ad_cat_5,PACKAGE_CODE=@pkgcode,INSERTS=@gridins,PKG_ALIAS=@pkgalias ,SPECIAL_SIZE1=@splboldsizevalue,VATAMT=@vatrate_p,BOXCHARGE=@boxcharge_p, VAT_INC=@vat_inc_p,LOCALGROSSAMT =@grossamtlocal_p,LOCALBILLAMT = @billamtlocal_p,sectioncode=@sectioncode_p,RESOURCE_NO=@resourceno_p,CAPTION=@caption_inserts_p, DISCOUNT=@disc_p
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
insert into tbl_booking_insert_g(cio_booking_id,Edition,Insert_date,Col_code,Height,Width,Size_book,Page_post,Premium1,Prem_per1,Premium2,Prem_per2,Premium_allow,Ad_cat,Ad_sub_cat,Latest_by,Status_material,File_name,Card_rate,Disc_rate,Insert_status,Bill_status,comp_code,Userid,Repeating_date,no_insert,Edition_code,Publication_code,Pub_cent_code,Supp_code,Pai_free_ins,Agreed_rate,Solo_rate,Gross_rate,Page_no,Remarks,Page_prem,page_per,No_ofcolumn,Bill_Amt,Bill_rate,Logo_H,Logo_W,Logo_name,AD_SUBCAT3,AD_SUBCAT4,AD_SUBCAT5,PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE,RESOURCE_NO,CAPTION,DISCOUNT)
values(@cioid,@edition,@insertdate,@colid,@height,@width,@totalsize,@pagepost,@premium1,@premper1,@premium2,@premper2,@premallow,@adcategory,@adsubcat,@latestdate,@material,@matfilename,@cardrate,@discrate,@insertstatus,@billstatus,@compcode,@userid,@repeat,@insertno,@edi,@publi,@pub_cent,@supp,@paid,@agrrate,@solorate,@grossrate,@insert_pageno,@insert_remarks,@page_code,@page_per,@noofcol,@billamt,@billrate,@logo_h,@logo_w,@logo_name,@ad_cat_3,@ad_cat_4,@ad_cat_5, @pkgcode,@gridins,@pkgalias,@splboldsizevalue,@vatrate_p,@boxcharge_p,@vat_inc_p,@grossamtlocal_p,@billamtlocal_p,@sectioncode_p,@resourceno_p,@caption_inserts_p,@disc_p)
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
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE,CAPTION,DISCOUNT)
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
           ,[LOCKSTATUS],SPECIAL_SIZE1,vatamt,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT,SECTIONCODE,CAPTION,DISCOUNT FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=@cioid
set @insertidval=@@identity
if @cirvts!='' 
insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE
)
                    values(@compcode,@cioid,@insertidval,@cirvts,@cirpub,@ciredi,@cirrate,@ciragency,@ciragencysubcode ,@center ,@branch ,@cirdate)
end

exec insert_edition_details @subedidata,null,@cioid,@insertidval,@compcode,@edition,@insertdate,@height,@width,@totalsize,@insertstatus,@pkgcode ,@insertno,@insert_pageno
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
















USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[committransaction]    Script Date: 05/25/2012 17:55:40 ******/
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
			REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,CANCELLATION_CHARGE)
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
			REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,CANCELLATION_CHARGE
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
           , LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION,DISCOUNT)
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
           , LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO,CAPTION, DISCOUNT
            FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=@pcioid

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










USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[getdataforexecute]    Script Date: 05/25/2012 17:56:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
isnull(sectioncode,'') as SECTIONCODE,isnull(RESOURCE_NO,'') as RESOURCE_NO,ISNULL(CAPTION,'') as CAPTION,DEALER_H,DEALER_W,ISNULL(DISCOUNT,'') AS DISCOUNT
  from tbl_booking_insert where comp_code=@compcode and cio_booking_id=@ciobid order by Insert_Id


select col_Name ,col_Code from col_mast where comp_code=@compcode
select premiumname,Premiumcode from ADVPOS_PREM_MAST where comp_code=@compcode
select Adv_Subcat_Name,Adv_Subcat_Code from adv_subcat_mast
select uom_name,uom_code from uom_mast where comp_code=@compcode
select adv_type_name,adv_type_code from adv_type_mast where comp_code=@compcode
select adv_cat_name,adv_cat_code from ADV_CAT_MAST where comp_code=@compcode
select pos_type_code,pos_type from advpos_type_mast where comp_code=@compcode


select   Paid_permission    from Module_DetaiButtonl  where comp_code=@compcode and Form_Name='Booking_master'










USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[getdataforexecute1]    Script Date: 05/25/2012 17:56:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[getdataforexecute1]
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
isnull(sectioncode,'') as SECTIONCODE,isnull(RESOURCE_NO,'') as RESOURCE_NO,ISNULL(CAPTION,'') as CAPTION,DEALER_H,DEALER_W,ISNULL(DISCOUNT,'') AS DISCOUNT
  from tbl_booking_insert where comp_code=@compcode and cio_booking_id=@ciobid order by Insert_Status


select col_Name ,col_Code from col_mast where comp_code=@compcode
select premiumname,Premiumcode from ADVPOS_PREM_MAST where comp_code=@compcode
select Adv_Subcat_Name,Adv_Subcat_Code from adv_subcat_mast
select uom_name,uom_code from uom_mast where comp_code=@compcode
select adv_type_name,adv_type_code from adv_type_mast where comp_code=@compcode
select adv_cat_name,adv_cat_code from ADV_CAT_MAST where comp_code=@compcode
select pos_type_code,pos_type from advpos_type_mast where comp_code=@compcode


select   Paid_permission    from Module_DetaiButtonl  where comp_code=@compcode and Form_Name='Booking_master'







USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[chkdiscountpremedit_per]    Script Date: 05/25/2012 17:57:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER Procedure [dbo].[chkdiscountpremedit_per]
@compcode as varchar(20),
@userid1 as varchar(20)
as



 select PERMISSION_DESC from userpermission where COMM_CODE=@compcode and USERID=@userid1
and PERMISSION_DESC='Allow Editing Discount Item Line Wise In Transaction'


/////////////--------shipra---5/25/2012--------------done by lata mam////////



------------------start---7233---avinash--------28may2012------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go









ALTER procedure [dbo].[billreportbilled]
(
@pcompcode 			as varchar(50),
@prowname 			as varchar(70),
@pcolumnname 		as varchar(70),
@pconditioncheck	as varchar(50),
@pfromdate 			as varchar(20),
@ptodate 			as varchar(20),
@pdateformat 		as varchar(20),
@puserid			as varchar(20),
@chk_access			as varchar(2)
)
AS
declare @prefer as varchar(10)
declare	@v_query as varchar(8000)
declare	@v_query_string as varchar(8000)
declare	@v_frdt  as  varchar(10)
declare	@v_todt as varchar(10)
declare	@v_var as varchar(4000)
declare @v_var_sum as varchar(4000)
-----------cursor variables--------------
declare @c1val1 as varchar(50)
declare @c1val2 as varchar(150)

CREATE TABLE #TEMP_COMPLETE_DYNAMIC_REPORT(  ROW_CODE    VARCHAR(50),  ROW_DESC    VARCHAR(150),  COL_CODE    VARCHAR(50),  COL_DESC    VARCHAR(150),  COL_BILAMT  float,  COL_ACTAMT  float)

declare c1 cursor for
	select distinct col_code,substring(upper(isnull(col_desc,col_code)),1,20) col_desc from #temp_complete_dynamic_report
	order by 2

--set @v_frdt=convert(datetime,@pfromdate)
--set @v_todt=convert(datetime,@ptodate)
set @v_frdt=@pfromdate
set @v_todt=@ptodate
select distinct @prefer= AGENCY_RETAINER_COMM from preferrences where comp_code=@pcompcode
delete from temp_complete_dynamic_report



   if(@prowname='Publication' and @pcolumnname='Suppliment')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    SELECT Pub_Code,Publication,Supplement_CODE,Supplement,SUM(Billamt),SUM(ActualBusiness) FROM(
	select  tbl_booking_insert.Publication_Code as Pub_Code,
    (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
	tbl_booking_insert.Supp_Code as Supplement_CODE,
	(select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and tbl_booking_insert.Publication_Code=supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition as Ed_Name
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				tbl_booking_mast.Comp_code=@pcompcode and
				--tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

			 ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_insert.Publication_Code is not null and tbl_booking_insert.Publication_Code !='0')a
	GROUP BY a.Pub_Code,a.Publication,a.Supplement_CODE,a.Supplement
	ORDER BY a.Pub_Code,a.Publication,a.Supplement_CODE,a.Supplement    end


	else if(@prowname='Publication' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    SELECT Pub_Code,Publication,Ad_catg_code,Adv_Catg_Name ,SUM(Billamt),SUM(ActualBusiness) FROM(
	select  tbl_booking_insert.Publication_Code as Pub_Code,
    (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
	tbl_booking_mast.Ad_cat_code as Ad_catg_code,
	(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition as Ed_Name
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
				--tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

				((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_insert.Publication_Code is not null and tbl_booking_insert.Publication_Code !='0')a
	GROUP BY a.Pub_Code,a.Publication,a.Ad_catg_code,a.Adv_Catg_Name
	  ORDER BY a.Pub_Code,a.Publication,a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='Publication' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    SELECT Pub_Code,Publication,Agency_Type_Code ,Agency_type_name ,SUM(Billamt),SUM(ActualBusiness) FROM(
	select  tbl_booking_insert.Publication_Code as Pub_Code,
    (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
	(select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition as Ed_Name
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

			 ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_insert.Publication_Code is not null and tbl_booking_insert.Publication_Code !='0')a
	GROUP BY a.Pub_Code,a.Publication,a.Agency_Type_Code ,a.Agency_type_name 
	  ORDER BY a.Pub_Code,a.Publication,a.Agency_Type_Code ,a.Agency_type_name     end

    else if(@prowname='Publication' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Pub_Code,Publication,Scheme_code,Scheme_name,SUM(Billamt),SUM(ActualBusiness) FROM(
	select  tbl_booking_insert.Publication_Code as Pub_Code,
    (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
    tbl_booking_mast.Scheme_type_code as Scheme_code,
	(select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition as Ed_Name
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_insert.Publication_Code is not null and tbl_booking_insert.Publication_Code !='0')a
	GROUP BY a.Pub_Code,a.Publication,a.Scheme_code,a.Scheme_name
	  ORDER BY a.Pub_Code,a.Publication,a.Scheme_code,a.Scheme_name    end


     else if(@prowname='Publication' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Pub_Code,Publication,Page_premium_code,Page_premium_name,SUM(Billamt),SUM(ActualBusiness) FROM(
	select  tbl_booking_insert.Publication_Code as Pub_Code,
    (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
    tbl_booking_mast.Page_prem as Page_premium_code,
	(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition as Ed_Name
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				tbl_booking_mast.Comp_code=@pcompcode and
				--tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_insert.Publication_Code is not null and tbl_booking_insert.Publication_Code !='0'
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0')a
	GROUP BY a.Pub_Code,a.Publication,a.Page_premium_code,a.Page_premium_name
	  ORDER BY a.Pub_Code,a.Publication,a.Page_premium_code,a.Page_premium_name    end

         else if(@prowname='Publication' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Pub_Code,Publication,Postprem_code,Postprem_name,SUM(Billamt),SUM(ActualBusiness) FROM(
	select  tbl_booking_insert.Publication_Code as Pub_Code,
    (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
    tbl_booking_mast.Page_position_code as Postprem_code,
	(select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition as Ed_Name
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_insert.Publication_Code is not null and tbl_booking_insert.Publication_Code !='0'
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0')a
	GROUP BY a.Pub_Code,a.Publication,a.Postprem_code,a.Postprem_name
	  ORDER BY a.Pub_Code,a.Publication,a.Postprem_code,a.Postprem_name    end


--edition

    else if(@prowname='Edition' and @pcolumnname='Publication')begin
	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    SELECT Edition_Code,Edition,Pub_Code,Publication,SUM(Billamt),SUM(ActualBusiness) FROM(
	select 
    tbl_booking_insert.Edition_Code as Edition_Code,tbl_booking_insert.Edition as Edition,
    tbl_booking_insert.Publication_Code as Pub_Code,
    (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition as Ed_Name
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Edition_Code,a.Edition,a.Pub_Code,a.Publication
	  ORDER BY a.Edition_Code,a.Edition,a.Pub_Code,a.Publication    end



else if(@prowname='Edition' and @pcolumnname='Suppliment')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    SELECT Edition_Code,Edition,Supplement_CODE,Supplement,SUM(Billamt),SUM(ActualBusiness) FROM(
	select 
    tbl_booking_insert.Edition_Code as Edition_Code,tbl_booking_insert.Edition as Edition,
	tbl_booking_insert.Supp_Code as Supplement_CODE,
	(select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and tbl_booking_insert.Publication_Code=supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition as Ed_Name
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				tbl_booking_mast.Comp_code=@pcompcode and
				--tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Edition_Code,a.Edition,a.Supplement_CODE,a.Supplement
	  ORDER BY a.Edition_Code,a.Edition,a.Supplement_CODE,a.Supplement    end


	else if(@prowname='Edition' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    SELECT Edition_Code,Edition,Ad_catg_code,Adv_Catg_Name,SUM(Billamt),SUM(ActualBusiness) FROM(
	select  tbl_booking_insert.Edition_Code as Edition_Code,tbl_booking_insert.Edition as Edition,
	tbl_booking_mast.Ad_cat_code as Ad_catg_code,
	(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition as Ed_Name
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

		((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Edition_Code,a.Edition,a.Ad_catg_code,a.Adv_Catg_Name
	  ORDER BY a.Edition_Code,a.Edition,a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='Edition' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    SELECT Edition_Code,Edition,Agency_Type_Code,Agency_type_name,SUM(Billamt),SUM(ActualBusiness) FROM(
	select  tbl_booking_insert.Edition_Code as Edition_Code,tbl_booking_insert.Edition as Edition,
	(select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition as Ed_Name
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
--				tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

 ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Edition_Code,a.Edition,a.Agency_Type_Code,a.Agency_type_name
	  ORDER BY a.Edition_Code,a.Edition,a.Agency_Type_Code,a.Agency_type_name    end

    else if(@prowname='Edition' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
     SELECT Edition_Code,Edition,Scheme_code,Scheme_name,SUM(Billamt),SUM(ActualBusiness) FROM(
	select  tbl_booking_insert.Edition_Code as Edition_Code,tbl_booking_insert.Edition as Edition,
    tbl_booking_mast.Scheme_type_code as Scheme_code,
	(select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition as Ed_Name
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
--				tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Edition_Code,a.Edition,a.Scheme_code,a.Scheme_name
	  ORDER BY a.Edition_Code,a.Edition,a.Scheme_code,a.Scheme_name    end


     else if(@prowname='Edition' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    SELECT Edition_Code,Edition,Page_premium_code,Page_premium_name,SUM(Billamt),SUM(ActualBusiness) FROM(
	select  tbl_booking_insert.Edition_Code as Edition_Code,tbl_booking_insert.Edition as Edition,
    tbl_booking_mast.Page_prem as Page_premium_code,
	(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition as Ed_Name
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
--				tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0')a
	GROUP BY a.Edition_Code,a.Edition,a.Page_premium_code,a.Page_premium_name
	  ORDER BY a.Edition_Code,a.Edition,a.Page_premium_code,a.Page_premium_name    end

         else if(@prowname='Edition' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    SELECT Edition_Code,Edition,Postprem_code,Postprem_name,SUM(Billamt),SUM(ActualBusiness) FROM(
	select  tbl_booking_insert.Edition_Code as Edition_Code,tbl_booking_insert.Edition as Edition,
    tbl_booking_mast.Page_position_code as Postprem_code,
	(select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0')a
	GROUP BY a.Edition_Code,a.Edition,a.Postprem_code,a.Postprem_name
	  ORDER BY a.Edition_Code,a.Edition,a.Postprem_code,a.Postprem_name    end

--AGENCY



else if(@prowname='Agency' and @pcolumnname='Publication')begin
	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Agency_Code,Agency_Namee,Pub_Code,Publication,sum(Billamt),SUM(ActualBusiness) from(
	select 
      (select Agency_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Agency_Code,
     (select Agency_Name from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Agency_Namee,
    tbl_booking_insert.Publication_Code as Pub_Code,
    (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY  a.Agency_Code,a.Agency_Namee,a.Pub_Code,a.Publication
	  ORDER BY a.Agency_Code,a.Agency_Namee,a.Pub_Code,a.Publication    end


else if(@prowname='Agency' and @pcolumnname='Suppliment')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
     select Agency_Code,Agency_Namee,Supplement_CODE,Supplement,sum(Billamt),SUM(ActualBusiness) from(
	select 
     (select Agency_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Agency_Code,
     (select Agency_Name from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Agency_Namee,
	tbl_booking_insert.Supp_Code as Supplement_CODE,
	(select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and tbl_booking_insert.Publication_Code =supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Agency_Code,a.Agency_Namee,a.Supplement_CODE,a.Supplement
	  ORDER BY a.Agency_Code,a.Agency_Namee,a.Supplement_CODE,a.Supplement    end


	else if(@prowname='Agency' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
     select Agency_Code,Agency_Namee,Ad_catg_code,Adv_Catg_Name,sum(Billamt),SUM(ActualBusiness) from(
	select 
    (select Agency_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Agency_Code,
     (select Agency_Name from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Agency_Namee,

	tbl_booking_mast.Ad_cat_code as Ad_catg_code,
	(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
		--		tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Agency_Code,a.Agency_Namee,a.Ad_catg_code,a.Adv_Catg_Name
	  ORDER BY a.Agency_Code,a.Agency_Namee,a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='Agency' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
     select Agency_Code,Agency_Namee,Agency_Type_Code,Agency_type_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
     (select Agency_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Agency_Code,
     (select Agency_Name from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Agency_Namee,

	(select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
 ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Agency_Code,a.Agency_Namee,a.Agency_Type_Code,a.Agency_type_name
	  ORDER BY a.Agency_Code,a.Agency_Namee,a.Agency_Type_Code,a.Agency_type_name    end

    else if(@prowname='Agency' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Agency_Code,Agency_Namee,Scheme_code,Scheme_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
    (select Agency_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Agency_Code,
     (select Agency_Name from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Agency_Namee,

    tbl_booking_mast.Scheme_type_code as Scheme_code,
	(select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
--				tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

 ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Agency_Code,a.Agency_Namee,a.Scheme_code,a.Scheme_name
	  ORDER BY a.Agency_Code,a.Agency_Namee,a.Scheme_code,a.Scheme_name    end


     else if(@prowname='Agency' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
	    select Agency_Code,Agency_Namee,Page_premium_code,Page_premium_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
    (select Agency_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Agency_Code,
     (select Agency_Name from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Agency_Namee,

    tbl_booking_mast.Page_prem as Page_premium_code,
	(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
				((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0')a
	GROUP BY a.Agency_Code,a.Agency_Namee,a.Page_premium_code,a.Page_premium_name
	  ORDER BY a.Agency_Code,a.Agency_Namee,a.Page_premium_code,a.Page_premium_name    end

         else if(@prowname='Agency' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Agency_Code,Agency_Namee,Postprem_code,Postprem_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
     (select Agency_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Agency_Code,
     (select Agency_Name from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Agency_Namee,

    tbl_booking_mast.Page_position_code as Postprem_code,
	(select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0')a
	GROUP BY a.Agency_Code,a.Agency_Namee,a.Postprem_code,a.Postprem_name
	  ORDER BY a.Agency_Code,a.Agency_Namee,a.Postprem_code,a.Postprem_name    end


--client




else if(@prowname='Client' and @pcolumnname='Publication')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Client_Code,Client_Name,Pub_Code,Publication,sum(Billamt),SUM(ActualBusiness) from(
	select 
      tbl_booking_mast.Client_code as Client_Code,
    isnull( (select Cust_Name from cust_mast where tbl_booking_mast.Client_code= cust_mast.Cust_Code ),tbl_booking_mast.Client_code) as Client_Name,
   tbl_booking_insert.Publication_Code as Pub_Code,
   (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code ) as Publication,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
			((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Client_Code,a.Client_Name,a.Pub_Code,a.Publication
	  ORDER BY a.Client_Code,a.Client_Name,a.Pub_Code,a.Publication    end


else if(@prowname='Client' and @pcolumnname='Suppliment')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Client_Code,Client_Name,Supplement_CODE,Supplement,sum(Billamt),SUM(ActualBusiness) from(
	select 
    tbl_booking_mast.Client_code as Client_Code,
    isnull( (select Cust_Name from cust_mast where tbl_booking_mast.Client_code= cust_mast.Cust_Code ),tbl_booking_mast.Client_code) as Client_Name,
 	tbl_booking_insert.Supp_Code as Supplement_CODE,
	(select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and tbl_booking_insert.Publication_Code=supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				tbl_booking_mast.Comp_code=@pcompcode and

				--tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Client_Code,a.Client_Name,a.Supplement_CODE,a.Supplement
	  ORDER BY a.Client_Code,a.Client_Name,a.Supplement_CODE,a.Supplement    end


	else if(@prowname='Client' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Client_Code,Client_Name,Ad_catg_code,Adv_Catg_Name,sum(Billamt),SUM(ActualBusiness) from(
	select 
    tbl_booking_mast.Client_code as Client_Code,
    isnull( (select Cust_Name from cust_mast where tbl_booking_mast.Client_code= cust_mast.Cust_Code ),tbl_booking_mast.Client_code) as Client_Name,
 	tbl_booking_mast.Ad_cat_code as Ad_catg_code,
	(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
				--tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Client_Code,a.Client_Name,a.Ad_catg_code,a.Adv_Catg_Name
	  ORDER BY a.Client_Code,a.Client_Name,a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='Client' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Client_Code,Client_Name,Agency_Type_Code,Agency_type_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
       tbl_booking_mast.Client_code as Client_Code,
    isnull( (select Cust_Name from cust_mast where tbl_booking_mast.Client_code= cust_mast.Cust_Code ),tbl_booking_mast.Client_code) as Client_Name,
 (select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
				--tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Client_Code,a.Client_Name,a.Agency_Type_Code,a.Agency_type_name
	  ORDER BY a.Client_Code,a.Client_Name,a.Agency_Type_Code,a.Agency_type_name    end

    else if(@prowname='Client' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
     select Client_Code,Client_Name,Scheme_code,Scheme_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
      tbl_booking_mast.Client_code as Client_Code,
    isnull( (select Cust_Name from cust_mast where tbl_booking_mast.Client_code= cust_mast.Cust_Code ),tbl_booking_mast.Client_code) as Client_Name,
   tbl_booking_mast.Scheme_type_code as Scheme_code,
	(select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
		--		tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

 ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Client_Code,a.Client_Name,a.Scheme_code,a.Scheme_name
	  ORDER BY a.Client_Code,a.Client_Name,a.Scheme_code,a.Scheme_name    end


     else if(@prowname='Client' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
     select Client_Code,Client_Name,Page_premium_code,Page_premium_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
      tbl_booking_mast.Client_code as Client_Code,
    isnull( (select Cust_Name from cust_mast where tbl_booking_mast.Client_code= cust_mast.Cust_Code ),tbl_booking_mast.Client_code) as Client_Name,
   tbl_booking_mast.Page_prem as Page_premium_code,
	(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
			((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0')a
	GROUP BY a.Client_Code,a.Client_Name,a.Page_premium_code,a.Page_premium_name
	  ORDER BY a.Client_Code,a.Client_Name,a.Page_premium_code,a.Page_premium_name    end

         else if(@prowname='Client' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Client_Code,Client_Name,Postprem_code,Postprem_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
        tbl_booking_mast.Client_code as Client_Code,
    isnull( (select Cust_Name from cust_mast where tbl_booking_mast.Client_code= cust_mast.Cust_Code ),tbl_booking_mast.Client_code) as Client_Name,
    tbl_booking_mast.Page_position_code as Postprem_code,
	(select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0')a
	GROUP BY a.Client_Code,a.Client_Name,a.Postprem_code,a.Postprem_name
	  ORDER BY a.Client_Code,a.Client_Name,a.Postprem_code,a.Postprem_name    end



--Revenue Center



else if(@prowname='Revenue Center' and @pcolumnname='Publication')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Revcode,Revcenter,Pub_Code,Publication,sum(Billamt),SUM(ActualBusiness) from(
	select 
      tbl_booking_mast.Revenue_center as Revcode,
    (SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE tbl_booking_mast.Revenue_center=BRANCH_MST.Branch_Code )as Revcenter,
   tbl_booking_insert.Publication_Code as Pub_Code,
   (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Revenue_center is not null and tbl_booking_mast.Revenue_center!='0')a
	GROUP BY  a.Revcode,a.Revcenter,a.Pub_Code,a.Publication
	  ORDER BY  a.Revcode,a.Revcenter,a.Pub_Code,a.Publication    end


else if(@prowname='Revenue Center' and @pcolumnname='Suppliment')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Revcode,Revcenter,Supplement_CODE,Supplement,sum(Billamt),SUM(ActualBusiness) from(
	select 
   tbl_booking_mast.Revenue_center as Revcode,
    (SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE tbl_booking_mast.Revenue_center=BRANCH_MST.Branch_Code )as Revcenter,
	tbl_booking_insert.Supp_Code as Supplement_CODE,
	(select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and tbl_booking_insert.Publication_Code=supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
    				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Revenue_center is not null and tbl_booking_mast.Revenue_center!='0')a
	GROUP BY  a.Revcode,a.Revcenter,a.Supplement_CODE,a.Supplement
	  ORDER BY  a.Revcode,a.Revcenter,a.Supplement_CODE,a.Supplement    end


	else if(@prowname='Revenue Center' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Revcode,Revcenter,Ad_catg_code,Adv_Catg_Name ,sum(Billamt),SUM(ActualBusiness) from(
	select 
  tbl_booking_mast.Revenue_center as Revcode,
    (SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE tbl_booking_mast.Revenue_center=BRANCH_MST.Branch_Code )as Revcenter,
	tbl_booking_mast.Ad_cat_code as Ad_catg_code,
	(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Revenue_center is not null and tbl_booking_mast.Revenue_center!='0')a
	GROUP BY a.Revcode,a.Revcenter,a.Ad_catg_code,a.Adv_Catg_Name 
	  ORDER BY a.Revcode,a.Revcenter,a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='Revenue Center' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Revcode,Revcenter,Agency_Type_Code ,Agency_type_name ,sum(Billamt),SUM(ActualBusiness) from(
	select 
      tbl_booking_mast.Revenue_center as Revcode,
    (SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE tbl_booking_mast.Revenue_center=BRANCH_MST.Branch_Code )as Revcenter,
	(select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Revenue_center is not null and tbl_booking_mast.Revenue_center!='0')a
	GROUP BY  a.Revcode,a.Revcenter,a.Agency_Type_Code ,a.Agency_type_name
	  ORDER BY  a.Revcode,a.Revcenter,a.Agency_Type_Code ,a.Agency_type_name    end

    else if(@prowname='Revenue Center' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Revcode,Revcenter,Scheme_code,Scheme_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
      tbl_booking_mast.Revenue_center as Revcode,
    (SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE tbl_booking_mast.Revenue_center=BRANCH_MST.Branch_Code )as Revcenter,
  tbl_booking_mast.Scheme_type_code as Scheme_code,
	(select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Revenue_center is not null and tbl_booking_mast.Revenue_center!='0')a
	GROUP BY a.Revcode,a.Revcenter,a.Scheme_code,a.Scheme_name
	  ORDER BY a.Revcode,a.Revcenter,a.Scheme_code,a.Scheme_name    end


     else if(@prowname='Revenue Center' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Revcode,Revcenter,Page_premium_code,Page_premium_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
      tbl_booking_mast.Revenue_center as Revcode,
    (SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE tbl_booking_mast.Revenue_center=BRANCH_MST.Branch_Code )as Revcenter,
     tbl_booking_mast.Page_prem as Page_premium_code,
	(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Revenue_center is not null and tbl_booking_mast.Revenue_center!='0'
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0')a
	GROUP BY  a.Revcode,a.Revcenter,a.Page_premium_code,a.Page_premium_name
	  ORDER BY  a.Revcode,a.Revcenter,a.Page_premium_code,a.Page_premium_name    end

         else if(@prowname='Revenue Center' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Revcode,Revcenter,Postprem_code,Postprem_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
      tbl_booking_mast.Revenue_center as Revcode,
    (SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE tbl_booking_mast.Revenue_center=BRANCH_MST.Branch_Code )as Revcenter,

    tbl_booking_mast.Page_position_code as Postprem_code,
	(select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
		--		tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0'
                and tbl_booking_mast.Revenue_center is not null and tbl_booking_mast.Revenue_center!='0')a
	GROUP BY a.Revcode,a.Revcenter,a.Postprem_code,a.Postprem_name
	  ORDER BY a.Revcode,a.Revcenter,a.Postprem_code,a.Postprem_name    end


--Printing Center




else if(@prowname='Printing Center' and @pcolumnname='Publication')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select pubcent_Code,pubcent_Name,Pub_Code,Publication,sum(Billamt),SUM(ActualBusiness) from(
	select 
      --tbl_booking_insert.Pub_Cent_Code as pubcent_Code,
     --(select Pub_Cent_name from pub_cent_mast where tbl_booking_insert.Pub_Cent_Code=pub_cent_mast.Pub_cent_Code  ) as pubcent_Name,
     (SELECT top 1 pub_cent_mast.Pub_cent_Code FROM PUB_CENT_MAST WHERE pub_cent_mast.Pub_cent_Code IN(SELECT branch_mst.pub_center FROM BRANCH_MST WHERE branch_mst.pub_center=pub_cent_mast.Pub_cent_Code AND TBL_BOOKING_MAST.branch=Branch_Name)) as pubcent_Code,
     (SELECT top 1 pub_cent_mast.Pub_Cent_name FROM PUB_CENT_MAST WHERE pub_cent_mast.Pub_cent_Code IN(SELECT branch_mst.pub_center FROM BRANCH_MST WHERE branch_mst.pub_center=pub_cent_mast.Pub_cent_Code AND TBL_BOOKING_MAST.branch=Branch_Name))as pubcent_Name,
       tbl_booking_insert.Publication_Code as Pub_Code,
       (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code)as Publication,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
				tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                  and TBL_BOOKING_MAST.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code ))
                and tbl_booking_insert.Pub_Cent_Code is not null and tbl_booking_insert.Pub_Cent_Code!='0'
               )a
	
              GROUP BY a.pubcent_Code,a.pubcent_Name,a.Pub_Code,a.Publication
	  ORDER BY a.pubcent_Code,a.pubcent_Name,a.Pub_Code,a.Publication    end


else if(@prowname='Printing Center' and @pcolumnname='Suppliment')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select  pubcent_Code,pubcent_Name,Supplement_CODE,Supplement,sum(Billamt),SUM(ActualBusiness) from(
	select 
    --tbl_booking_insert.Pub_Cent_Code as pubcent_Code,
   --(select Pub_Cent_name from pub_cent_mast where tbl_booking_insert.Pub_Cent_Code=pub_cent_mast.Pub_cent_Code  ) as pubcent_Name,
    (SELECT  top 1 pub_cent_mast.Pub_cent_Code FROM PUB_CENT_MAST WHERE pub_cent_mast.Pub_cent_Code IN(SELECT branch_mst.pub_center FROM BRANCH_MST WHERE branch_mst.pub_center=pub_cent_mast.Pub_cent_Code AND TBL_BOOKING_MAST.branch=Branch_Name)) as pubcent_Code,
     (SELECT top 1 pub_cent_mast.Pub_Cent_name FROM PUB_CENT_MAST WHERE pub_cent_mast.Pub_cent_Code IN(SELECT branch_mst.pub_center FROM BRANCH_MST WHERE branch_mst.pub_center=pub_cent_mast.Pub_cent_Code AND TBL_BOOKING_MAST.branch=Branch_Name))as pubcent_Name,
    
	tbl_booking_insert.Supp_Code as Supplement_CODE,
	(select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and tbl_booking_insert.Publication_Code=supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
			tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

			((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and TBL_BOOKING_MAST.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code ))
                and tbl_booking_insert.Pub_Cent_Code is not null and tbl_booking_insert.Pub_Cent_Code!='0')a
	GROUP BY  a.pubcent_Code,a.pubcent_Name,a.Supplement_CODE,a.Supplement
	  ORDER BY  a.pubcent_Code,a.pubcent_Name,a.Supplement_CODE,a.Supplement    end


	else if(@prowname='Printing Center' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select pubcent_Code,pubcent_Name,Ad_catg_code,Adv_Catg_Name,sum(Billamt),SUM(ActualBusiness) from(
	select 
   --tbl_booking_insert.Pub_Cent_Code as pubcent_Code,
    -- (select Pub_Cent_name from pub_cent_mast where tbl_booking_insert.Pub_Cent_Code=pub_cent_mast.Pub_cent_Code  ) as pubcent_Name,
     (SELECT top 1 pub_cent_mast.Pub_cent_Code FROM PUB_CENT_MAST WHERE pub_cent_mast.Pub_cent_Code IN(SELECT branch_mst.pub_center FROM BRANCH_MST WHERE branch_mst.pub_center=pub_cent_mast.Pub_cent_Code AND TBL_BOOKING_MAST.branch=Branch_Name)) as pubcent_Code,
     (SELECT top 1 pub_cent_mast.Pub_Cent_name FROM PUB_CENT_MAST WHERE pub_cent_mast.Pub_cent_Code IN(SELECT branch_mst.pub_center FROM BRANCH_MST WHERE branch_mst.pub_center=pub_cent_mast.Pub_cent_Code AND TBL_BOOKING_MAST.branch=Branch_Name))as pubcent_Name,
    
	tbl_booking_mast.Ad_cat_code as Ad_catg_code,
	(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and TBL_BOOKING_MAST.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code ))
                and tbl_booking_insert.Pub_Cent_Code is not null and tbl_booking_insert.Pub_Cent_Code!='0')a
	GROUP BY a.pubcent_Code,a.pubcent_Name,a.Ad_catg_code,a.Adv_Catg_Name
	  ORDER BY a.pubcent_Code,a.pubcent_Name,a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='Printing Center' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select pubcent_Code,pubcent_Name,Agency_Type_Code,Agency_type_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
      -- tbl_booking_insert.Pub_Cent_Code as pubcent_Code,
    -- (select Pub_Cent_name from pub_cent_mast where tbl_booking_insert.Pub_Cent_Code=pub_cent_mast.Pub_cent_Code  ) as pubcent_Name,
     (SELECT top 1 pub_cent_mast.Pub_cent_Code FROM PUB_CENT_MAST WHERE pub_cent_mast.Pub_cent_Code IN(SELECT branch_mst.pub_center FROM BRANCH_MST WHERE branch_mst.pub_center=pub_cent_mast.Pub_cent_Code AND TBL_BOOKING_MAST.branch=Branch_Name)) as pubcent_Code,
     (SELECT top 1 pub_cent_mast.Pub_Cent_name FROM PUB_CENT_MAST WHERE pub_cent_mast.Pub_cent_Code IN(SELECT branch_mst.pub_center FROM BRANCH_MST WHERE branch_mst.pub_center=pub_cent_mast.Pub_cent_Code AND TBL_BOOKING_MAST.branch=Branch_Name))as pubcent_Name,
    
	(select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and TBL_BOOKING_MAST.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code ))
                and tbl_booking_insert.Pub_Cent_Code is not null and tbl_booking_insert.Pub_Cent_Code!='0')a
	GROUP BY  a.pubcent_Code,a.pubcent_Name,a.Agency_Type_Code,a.Agency_type_name
	  ORDER BY  a.pubcent_Code,a.pubcent_Name,a.Agency_Type_Code,a.Agency_type_name    end

    else if(@prowname='Printing Center' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select pubcent_Code,pubcent_Name,Scheme_code,Scheme_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
    -- tbl_booking_insert.Pub_Cent_Code as pubcent_Code,
     --(select Pub_Cent_name from pub_cent_mast where tbl_booking_insert.Pub_Cent_Code=pub_cent_mast.Pub_cent_Code  ) as pubcent_Name,
      (SELECT top 1 pub_cent_mast.Pub_cent_Code FROM PUB_CENT_MAST WHERE pub_cent_mast.Pub_cent_Code IN(SELECT branch_mst.pub_center FROM BRANCH_MST WHERE branch_mst.pub_center=pub_cent_mast.Pub_cent_Code AND TBL_BOOKING_MAST.branch=Branch_Name)) as pubcent_Code,
     (SELECT top 1 pub_cent_mast.Pub_Cent_name FROM PUB_CENT_MAST WHERE pub_cent_mast.Pub_cent_Code IN(SELECT branch_mst.pub_center FROM BRANCH_MST WHERE branch_mst.pub_center=pub_cent_mast.Pub_cent_Code AND TBL_BOOKING_MAST.branch=Branch_Name))as pubcent_Name,
    
    tbl_booking_mast.Scheme_type_code as Scheme_code,
	(select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
   isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and TBL_BOOKING_MAST.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code ))
                and tbl_booking_insert.Pub_Cent_Code is not null and tbl_booking_insert.Pub_Cent_Code!='0')a
	GROUP BY a.pubcent_Code,a.pubcent_Name,a.Scheme_code,a.Scheme_name
	  ORDER BY a.pubcent_Code,a.pubcent_Name,a.Scheme_code,a.Scheme_name    end


     else if(@prowname='Printing Center' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select  pubcent_Code,pubcent_Name,Page_premium_code,Page_premium_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
    --tbl_booking_insert.Pub_Cent_Code as pubcent_Code,
    -- (select Pub_Cent_name from pub_cent_mast where tbl_booking_insert.Pub_Cent_Code=pub_cent_mast.Pub_cent_Code  ) as pubcent_Name,
     (SELECT top 1 pub_cent_mast.Pub_cent_Code FROM PUB_CENT_MAST WHERE pub_cent_mast.Pub_cent_Code IN(SELECT branch_mst.pub_center FROM BRANCH_MST WHERE branch_mst.pub_center=pub_cent_mast.Pub_cent_Code AND TBL_BOOKING_MAST.branch=Branch_Name)) as pubcent_Code,
     (SELECT  top 1 pub_cent_mast.Pub_Cent_name FROM PUB_CENT_MAST WHERE pub_cent_mast.Pub_cent_Code IN(SELECT branch_mst.pub_center FROM BRANCH_MST WHERE branch_mst.pub_center=pub_cent_mast.Pub_cent_Code AND TBL_BOOKING_MAST.branch=Branch_Name))as pubcent_Name,
    
    tbl_booking_mast.Page_prem as Page_premium_code,
	(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
		--		tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and TBL_BOOKING_MAST.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code ))
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0'
                and tbl_booking_insert.Pub_Cent_Code is not null and tbl_booking_insert.Pub_Cent_Code!='0')a
	GROUP BY a.pubcent_Code,a.pubcent_Name,a.Page_premium_code,a.Page_premium_name
	  ORDER BY a.pubcent_Code,a.pubcent_Name,a.Page_premium_code,a.Page_premium_name    end

         else if(@prowname='Printing Center' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
     select pubcent_Code,pubcent_Name,Postprem_code,Postprem_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
     --tbl_booking_insert.Pub_Cent_Code as pubcent_Code,
     --(select Pub_Cent_name from pub_cent_mast where tbl_booking_insert.Pub_Cent_Code=pub_cent_mast.Pub_cent_Code  ) as pubcent_Name,
      (SELECT top 1 pub_cent_mast.Pub_cent_Code FROM PUB_CENT_MAST WHERE pub_cent_mast.Pub_cent_Code IN(SELECT branch_mst.pub_center FROM BRANCH_MST WHERE branch_mst.pub_center=pub_cent_mast.Pub_cent_Code AND TBL_BOOKING_MAST.branch=Branch_Name)) as pubcent_Code,
     (SELECT top 1 pub_cent_mast.Pub_Cent_name FROM PUB_CENT_MAST WHERE pub_cent_mast.Pub_cent_Code IN(SELECT branch_mst.pub_center FROM BRANCH_MST WHERE branch_mst.pub_center=pub_cent_mast.Pub_cent_Code AND TBL_BOOKING_MAST.branch=Branch_Name))as pubcent_Name,
    

    tbl_booking_mast.Page_position_code as Postprem_code,
	(select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and TBL_BOOKING_MAST.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code ))
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0'
                and tbl_booking_insert.Pub_Cent_Code is not null and tbl_booking_insert.Pub_Cent_Code!='0')a
	GROUP BY a.pubcent_Code,a.pubcent_Name,a.Postprem_code,a.Postprem_name
	  ORDER BY a.pubcent_Code,a.pubcent_Name,a.Postprem_code,a.Postprem_name    end

--Region




else if(@prowname='Region' and @pcolumnname='Publication')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Region_Code,Region_Name,Pub_Code,Publication,sum(Billamt),SUM(ActualBusiness) from(
	select 
       (select AGENCY_MAST.region  from AGENCY_MAST where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Region_Code,
    (SELECT REGION_MST.Region_Name FROM REGION_MST WHERE REGION_MST.Region_Code IN(select AGENCY_MAST.region  from AGENCY_MAST where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)  )    as Region_Name,
     TBL_BOOKING_INSERT.Publication_Code as Pub_Code,
     (SELECT pub_mast.Pub_Name FROM PUB_MAST WHERE pub_mast.Pub_Code=tbl_booking_insert.Publication_Code  ) as Publication,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Region_Code,a.Region_Name,a.Pub_Code,a.Publication
	  ORDER BY a.Region_Code,a.Region_Name,a.Pub_Code,a.Publication    end


else if(@prowname='Region' and @pcolumnname='Suppliment')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Region_Code,Region_Name,Supplement_CODE,Supplement,sum(Billamt),SUM(ActualBusiness) from(
	select 
     (select AGENCY_MAST.region  from AGENCY_MAST where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Region_Code,
    (SELECT REGION_MST.Region_Name FROM REGION_MST WHERE REGION_MST.Region_Code IN(select AGENCY_MAST.region  from AGENCY_MAST where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)  )    as Region_Name,
   	tbl_booking_insert.Supp_Code as Supplement_CODE,
	(select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and TBL_BOOKING_INSERT.Publication_Code =supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				tbl_booking_mast.Comp_code=@pcompcode and
		--		tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Region_Code,a.Region_Name,a.Supplement_CODE,a.Supplement
	  ORDER BY a.Region_Code,a.Region_Name,a.Supplement_CODE,a.Supplement    end


	else if(@prowname='Region' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Region_Code,Region_Name,Ad_catg_code,Adv_Catg_Name,sum(Billamt),SUM(ActualBusiness) from(
	select 
  (select AGENCY_MAST.region  from AGENCY_MAST where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Region_Code,
    (SELECT REGION_MST.Region_Name FROM REGION_MST WHERE REGION_MST.Region_Code IN(select AGENCY_MAST.region  from AGENCY_MAST where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)  )    as Region_Name,
   	tbl_booking_mast.Ad_cat_code as Ad_catg_code,
	(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Region_Code,a.Region_Name,a.Ad_catg_code,a.Adv_Catg_Name
	  ORDER BY a.Region_Code,a.Region_Name,a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='Region' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Region_Code,Region_Name,Agency_Type_Code,Agency_type_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
    (select AGENCY_MAST.region  from AGENCY_MAST where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Region_Code,
    (SELECT REGION_MST.Region_Name FROM REGION_MST WHERE REGION_MST.Region_Code IN(select AGENCY_MAST.region  from AGENCY_MAST where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)  )    as Region_Name,
  	(select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Region_Code,a.Region_Name,a.Agency_Type_Code,a.Agency_type_name
	  ORDER BY a.Region_Code,a.Region_Name,a.Agency_Type_Code,a.Agency_type_name    end

    else if(@prowname='Region' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Region_Code,Region_Name,Scheme_code,Scheme_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
     (select AGENCY_MAST.region  from AGENCY_MAST where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Region_Code,
    (SELECT REGION_MST.Region_Name FROM REGION_MST WHERE REGION_MST.Region_Code IN(select AGENCY_MAST.region  from AGENCY_MAST where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)  )    as Region_Name,
   tbl_booking_mast.Scheme_type_code as Scheme_code,
	(select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
  isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Region_Code,a.Region_Name,a.Scheme_code,a.Scheme_name
	  ORDER BY a.Region_Code,a.Region_Name,a.Scheme_code,a.Scheme_name    end


     else if(@prowname='Region' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Region_Code,Region_Name,Page_premium_code,Page_premium_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
      (select AGENCY_MAST.region  from AGENCY_MAST where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Region_Code,
    (SELECT REGION_MST.Region_Name FROM REGION_MST WHERE REGION_MST.Region_Code IN(select AGENCY_MAST.region  from AGENCY_MAST where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)  )    as Region_Name,
   tbl_booking_mast.Page_prem as Page_premium_code,
	(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0')a
	GROUP BY a.Region_Code,a.Region_Name,a.Page_premium_code,a.Page_premium_name
	  ORDER BY a.Region_Code,a.Region_Name,a.Page_premium_code,a.Page_premium_name     end

         else if(@prowname='Region' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Region_Code,Region_Name,Postprem_code,Postprem_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
        (select AGENCY_MAST.region  from AGENCY_MAST where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Region_Code,
    (SELECT REGION_MST.Region_Name FROM REGION_MST WHERE REGION_MST.Region_Code IN(select AGENCY_MAST.region  from AGENCY_MAST where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)  )    as Region_Name,

    tbl_booking_mast.Page_position_code as Postprem_code,
	(select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
 ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0')a
	GROUP BY  a.Region_Code,a.Region_Name,a.Postprem_code,a.Postprem_name
	  ORDER BY  a.Region_Code,a.Region_Name,a.Postprem_code,a.Postprem_name    end

--State



else if(@prowname='State' and @pcolumnname='Publication')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select State_Code,State_Name,Pub_Code,Publication,sum(Billamt),SUM(ActualBusiness) from(
	select 
   (select AGENCY_MAST.State_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as State_Code,
      (select AGENCY_MAST.State_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as State_Name,
      tbl_booking_insert.Publication_Code as Pub_Code,
      (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.State_Code,a.State_Name,a.Pub_Code,a.Publication
	  ORDER BY a.State_Code,a.State_Name,a.Pub_Code,a.Publication    end


else if(@prowname='State' and @pcolumnname='Suppliment')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select State_Code,State_Name,Supplement_CODE,Supplement,sum(Billamt),SUM(ActualBusiness) from(
	select 
   (select AGENCY_MAST.State_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as State_Code,
      (select AGENCY_MAST.State_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as State_Name,
  	tbl_booking_insert.Supp_Code as Supplement_CODE,
	(select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and tbl_booking_insert.Publication_Code=supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.State_Code,a.State_Name,a.Supplement_CODE,a.Supplement
	  ORDER BY a.State_Code,a.State_Name,a.Supplement_CODE,a.Supplement    end


	else if(@prowname='State' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select State_Code,State_Name,Ad_catg_code,Adv_Catg_Name,sum(Billamt),SUM(ActualBusiness) from(
	select 
    (select AGENCY_MAST.State_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as State_Code,
      (select AGENCY_MAST.State_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as State_Name,
  	tbl_booking_mast.Ad_cat_code as Ad_catg_code,
	(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.State_Code,a.State_Name,a.Ad_catg_code,a.Adv_Catg_Name
	  ORDER BY a.State_Code,a.State_Name,a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='State' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select State_Code,State_Name,Agency_Type_Code,Agency_type_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
   (select AGENCY_MAST.State_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as State_Code,
      (select AGENCY_MAST.State_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as State_Name,
  	(select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

 ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.State_Code,a.State_Name,a.Agency_Type_Code,a.Agency_type_name
	  ORDER BY a.State_Code,a.State_Name,a.Agency_Type_Code,a.Agency_type_name    end

    else if(@prowname='State' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select State_Code,State_Name,Scheme_code,Scheme_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
    (select AGENCY_MAST.State_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as State_Code,
      (select AGENCY_MAST.State_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as State_Name,
    tbl_booking_mast.Scheme_type_code as Scheme_code,
	(select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
  isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY  a.State_Code,a.State_Name,a.Scheme_code,a.Scheme_name
	  ORDER BY  a.State_Code,a.State_Name,a.Scheme_code,a.Scheme_name    end


     else if(@prowname='State' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select State_Code,State_Name,Page_premium_code,Page_premium_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
  (select AGENCY_MAST.State_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as State_Code,
      (select AGENCY_MAST.State_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as State_Name,
      tbl_booking_mast.Page_prem as Page_premium_code,
	(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
		--		tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0')a
	GROUP BY a.State_Code,a.State_Name,a.Page_premium_code,a.Page_premium_name
	  ORDER BY a.State_Code,a.State_Name,a.Page_premium_code,a.Page_premium_name    end

         else if(@prowname='State' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select State_Code,State_Name,Postprem_code,Postprem_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
     (select AGENCY_MAST.State_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as State_Code,
      (select AGENCY_MAST.State_Code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as State_Name,

    tbl_booking_mast.Page_position_code as Postprem_code,
	(select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
		--		tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
		tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0')a
	GROUP BY  a.State_Code,a.State_Name,a.Postprem_code,a.Postprem_name
	  ORDER BY  a.State_Code,a.State_Name,a.Postprem_code,a.Postprem_name    end

--Zone


else if(@prowname='Zone' and @pcolumnname='Publication')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Zone_Code,Zone_Name,Pub_Code,Publication,sum(Billamt),SUM(ActualBusiness) from(
	select 
   (select AGENCY_MAST.zone_code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Zone_Code,
    (select zone_mast.Zone_Name from zone_mast where zone_mast.Zone_Code in(select AGENCY_MAST.zone_code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) ) as Zone_Name,
     tbl_booking_insert.Publication_Code as Pub_Code,
     (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Zone_Code,a.Zone_Name,a.Pub_Code,a.Publication
	  ORDER BY a.Zone_Code,a.Zone_Name,a.Pub_Code,a.Publication    end


else if(@prowname='Zone' and @pcolumnname='Suppliment')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Zone_Code,Zone_Name,Supplement_CODE,Supplement,sum(Billamt),SUM(ActualBusiness) from(
	select 
  (select AGENCY_MAST.zone_code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Zone_Code,
    (select zone_mast.Zone_Name from zone_mast where zone_mast.Zone_Code in(select AGENCY_MAST.zone_code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) ) as Zone_Name,
   	tbl_booking_insert.Supp_Code as Supplement_CODE,
	(select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and tbl_booking_insert.Publication_Code=supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				tbl_booking_mast.Comp_code=@pcompcode and

			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Zone_Code,a.Zone_Name,a.Supplement_CODE,a.Supplement
	  ORDER BY a.Zone_Code,a.Zone_Name,a.Supplement_CODE,a.Supplement    end


	else if(@prowname='Zone' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Zone_Code,Zone_Name,Ad_catg_code,Adv_Catg_Name,sum(Billamt),SUM(ActualBusiness) from(
	select 
 (select AGENCY_MAST.zone_code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Zone_Code,
    (select zone_mast.Zone_Name from zone_mast where zone_mast.Zone_Code in(select AGENCY_MAST.zone_code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) ) as Zone_Name,
  	tbl_booking_mast.Ad_cat_code as Ad_catg_code,
	(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Zone_Code,a.Zone_Name,a.Ad_catg_code,a.Adv_Catg_Name
	  ORDER BY a.Zone_Code,a.Zone_Name,a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='Zone' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Zone_Code,Zone_Name,Agency_Type_Code ,Agency_type_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
   (select AGENCY_MAST.zone_code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Zone_Code,
    (select zone_mast.Zone_Name from zone_mast where zone_mast.Zone_Code in(select AGENCY_MAST.zone_code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) ) as Zone_Name,
  	(select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Zone_Code,a.Zone_Name,a.Agency_Type_Code ,a.Agency_type_name
	  ORDER BY a.Zone_Code,a.Zone_Name,a.Agency_Type_Code ,a.Agency_type_name    end

    else if(@prowname='Zone' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Zone_Code,Zone_Name,Scheme_code,Scheme_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
 (select AGENCY_MAST.zone_code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Zone_Code,
    (select zone_mast.Zone_Name from zone_mast where zone_mast.Zone_Code in(select AGENCY_MAST.zone_code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) ) as Zone_Name,
     tbl_booking_mast.Scheme_type_code as Scheme_code,
	(select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
 isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Zone_Code,a.Zone_Name,a.Scheme_code,a.Scheme_name
	  ORDER BY a.Zone_Code,a.Zone_Name,a.Scheme_code,a.Scheme_name    end


     else if(@prowname='Zone' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Zone_Code,Zone_Name,Page_premium_code,Page_premium_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
   (select AGENCY_MAST.zone_code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Zone_Code,
    (select zone_mast.Zone_Name from zone_mast where zone_mast.Zone_Code in(select AGENCY_MAST.zone_code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) ) as Zone_Name,
    tbl_booking_mast.Page_prem as Page_premium_code,
	(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0')a
	GROUP BY a.Zone_Code,a.Zone_Name,a.Page_premium_code,a.Page_premium_name
	  ORDER BY a.Zone_Code,a.Zone_Name,a.Page_premium_code,a.Page_premium_name    end

         else if(@prowname='Zone' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Zone_Code,Zone_Name,Postprem_code,Postprem_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
   (select AGENCY_MAST.zone_code from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as Zone_Code,
    (select zone_mast.Zone_Name from zone_mast where zone_mast.Zone_Code in(select AGENCY_MAST.zone_code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) ) as Zone_Name,

    tbl_booking_mast.Page_position_code as Postprem_code,
	(select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0')a
	GROUP BY a.Zone_Code,a.Zone_Name,a.Postprem_code,a.Postprem_name
	  ORDER BY a.Zone_Code,a.Zone_Name,a.Postprem_code,a.Postprem_name    end

    --District


else if(@prowname='District' and @pcolumnname='Publication')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Dist_Code,Dist_Name,Pub_Code,Publication,sum(Billamt),SUM(ActualBusiness) from(
	select 
   (select dist_mst.Dist_Code from dist_mst where dist_mst.Dist_Name in(select AGENCY_MAST.Dist_Code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) ) as Dist_Code,
    (select AGENCY_MAST.Dist_Code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)  as Dist_Name,
      tbl_booking_insert.Publication_Code as Pub_Code,
      (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
			 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY  a.Dist_Code,a.Dist_Name,a.Pub_Code,a.Publication
	  ORDER BY  a.Dist_Code,a.Dist_Name,a.Pub_Code,a.Publication    end


else if(@prowname='District' and @pcolumnname='Suppliment')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Dist_Code,Dist_Name,Supplement_CODE,Supplement,sum(Billamt),SUM(ActualBusiness) from(
	select 
  (select dist_mst.Dist_Code from dist_mst where dist_mst.Dist_Name in(select AGENCY_MAST.Dist_Code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) ) as Dist_Code,
    (select AGENCY_MAST.Dist_Code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)  as Dist_Name,
    	tbl_booking_insert.Supp_Code as Supplement_CODE,
	(select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and tbl_booking_insert.Publication_Code =supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				tbl_booking_mast.Comp_code=@pcompcode and

			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Dist_Code,a.Dist_Name,a.Supplement_CODE,a.Supplement
	  ORDER BY a.Dist_Code,a.Dist_Name,a.Supplement_CODE,a.Supplement    end


	else if(@prowname='District' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Dist_Code,Dist_Name,Ad_catg_code,Adv_Catg_Name,sum(Billamt),SUM(ActualBusiness) from(
	select 
   (select dist_mst.Dist_Code from dist_mst where dist_mst.Dist_Name in(select AGENCY_MAST.Dist_Code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) ) as Dist_Code,
    (select AGENCY_MAST.Dist_Code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)  as Dist_Name,
   	tbl_booking_mast.Ad_cat_code as Ad_catg_code,
	(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
--				tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Dist_Code,a.Dist_Name,a.Ad_catg_code,a.Adv_Catg_Name
	  ORDER BY a.Dist_Code,a.Dist_Name,a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='District' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Dist_Code,Dist_Name,Agency_Type_Code,Agency_type_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
   (select dist_mst.Dist_Code from dist_mst where dist_mst.Dist_Name in(select AGENCY_MAST.Dist_Code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) ) as Dist_Code,
    (select AGENCY_MAST.Dist_Code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)  as Dist_Name,
   	(select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
		--		tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Dist_Code,a.Dist_Name,a.Agency_Type_Code,a.Agency_type_name
	  ORDER BY a.Dist_Code,a.Dist_Name,a.Agency_Type_Code,a.Agency_type_name    end

    else if(@prowname='District' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Dist_Code,Dist_Name,Scheme_code, Scheme_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
   (select dist_mst.Dist_Code from dist_mst where dist_mst.Dist_Name in(select AGENCY_MAST.Dist_Code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) ) as Dist_Code,
    (select AGENCY_MAST.Dist_Code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)  as Dist_Name,
     tbl_booking_mast.Scheme_type_code as Scheme_code,
	(select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
  isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY  a.Dist_Code,a.Dist_Name,a.Scheme_code, a.Scheme_name
	  ORDER BY  a.Dist_Code,a.Dist_Name,a.Scheme_code, a.Scheme_name    end


     else if(@prowname='District' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Dist_Code,Dist_Name,Page_premium_code, Page_premium_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
   (select dist_mst.Dist_Code from dist_mst where dist_mst.Dist_Name in(select AGENCY_MAST.Dist_Code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) ) as Dist_Code,
    (select AGENCY_MAST.Dist_Code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)  as Dist_Name,
    tbl_booking_mast.Page_prem as Page_premium_code,
	(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0')a
	GROUP BY a.Dist_Code,a.Dist_Name,a.Page_premium_code, a.Page_premium_name
	  ORDER BY a.Dist_Code,a.Dist_Name,a.Page_premium_code, a.Page_premium_name    end

         else if(@prowname='District' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Dist_Code,Dist_Name,Postprem_code, Postprem_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
    (select dist_mst.Dist_Code from dist_mst where dist_mst.Dist_Name in(select AGENCY_MAST.Dist_Code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) ) as Dist_Code,
    (select AGENCY_MAST.Dist_Code  from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)  as Dist_Name,

    tbl_booking_mast.Page_position_code as Postprem_code,
	(select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0')a
	GROUP BY a.Dist_Code,a.Dist_Name,a.Postprem_code, a.Postprem_name
	  ORDER BY a.Dist_Code,a.Dist_Name,a.Postprem_code, a.Postprem_name    end



    --Branch




else if(@prowname='Branch' and @pcolumnname='Publication')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Branch_Code,Branch_Name,Pub_Code,Publication,sum(Billamt),SUM(ActualBusiness) from(
	select 
  (select branch_mst.Branch_Code from  branch_mst  where branch_mst.Branch_Name= tbl_booking_mast.branch ) as Branch_Code,
     tbl_booking_mast.branch as Branch_Name,
   tbl_booking_insert.Publication_Code as Pub_Code,
   (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Branch_Code,a.Branch_Name,a.Pub_Code,a.Publication
	  ORDER BY a.Branch_Code,a.Branch_Name,a.Pub_Code,a.Publication    end


else if(@prowname='Branch' and @pcolumnname='Suppliment')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Branch_Code,Branch_Name,Supplement_CODE,Supplement,sum(Billamt),SUM(ActualBusiness) from(
	select 
 (select branch_mst.Branch_Code from  branch_mst  where branch_mst.Branch_Name= tbl_booking_mast.branch ) as Branch_Code,
     tbl_booking_mast.branch as Branch_Name,
   	tbl_booking_insert.Supp_Code as Supplement_CODE,
	(select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and  tbl_booking_insert.Publication_Code=supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
				tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Branch_Code,a.Branch_Name,a.Supplement_CODE,a.Supplement
	  ORDER BY a.Branch_Code,a.Branch_Name,a.Supplement_CODE,a.Supplement    end


	else if(@prowname='Branch' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Branch_Code,Branch_Name,Ad_catg_code,Adv_Catg_Name,sum(Billamt),SUM(ActualBusiness) from(
	select 
  (select branch_mst.Branch_Code from  branch_mst  where branch_mst.Branch_Name= tbl_booking_mast.branch ) as Branch_Code,
     tbl_booking_mast.branch as Branch_Name,
  	tbl_booking_mast.Ad_cat_code as Ad_catg_code,
	(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Branch_Code,a.Branch_Name,a.Ad_catg_code,a.Adv_Catg_Name
	  ORDER BY a.Branch_Code,a.Branch_Name,a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='Branch' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Branch_Code,Branch_Name,Agency_Type_Code ,Agency_type_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
  (select branch_mst.Branch_Code from  branch_mst  where branch_mst.Branch_Name= tbl_booking_mast.branch ) as Branch_Code,
     tbl_booking_mast.branch as Branch_Name,
	(select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Branch_Code,a.Branch_Name,a.Agency_Type_Code ,a.Agency_type_name
	  ORDER BY a.Branch_Code,a.Branch_Name,a.Agency_Type_Code ,a.Agency_type_name    end

    else if(@prowname='Branch' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Branch_Code,Branch_Name,Scheme_code ,Scheme_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
  (select branch_mst.Branch_Code from  branch_mst  where branch_mst.Branch_Name= tbl_booking_mast.branch ) as Branch_Code,
     tbl_booking_mast.branch as Branch_Name,
 tbl_booking_mast.Scheme_type_code as Scheme_code,
	(select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
  isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
	GROUP BY a.Branch_Code,a.Branch_Name,a.Scheme_code ,a.Scheme_name
	  ORDER BY a.Branch_Code,a.Branch_Name,a.Scheme_code ,a.Scheme_name    end


     else if(@prowname='Branch' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Branch_Code,Branch_Name,Page_premium_code ,Page_premium_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
  (select branch_mst.Branch_Code from  branch_mst  where branch_mst.Branch_Name= tbl_booking_mast.branch ) as Branch_Code,
     tbl_booking_mast.branch as Branch_Name,
   tbl_booking_mast.Page_prem as Page_premium_code,
	(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
 ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0')a
	GROUP BY a.Branch_Code,a.Branch_Name,a.Page_premium_code ,a.Page_premium_name
	  ORDER BY a.Branch_Code,a.Branch_Name,a.Page_premium_code ,a.Page_premium_name    end

         else if(@prowname='Branch' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Branch_Code,Branch_Name,Postprem_code ,Postprem_name,sum(Billamt),SUM(ActualBusiness) from(
	select 
  (select branch_mst.Branch_Code from  branch_mst  where branch_mst.Branch_Name= tbl_booking_mast.branch ) as Branch_Code,
     tbl_booking_mast.branch as Branch_Name,
    tbl_booking_mast.Page_position_code as Postprem_code,
	(select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
	round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
	,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
	from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
	where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
				 tbl_booking_mast.Comp_code=@pcompcode and
			--	tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0')a
	GROUP BY  a.Branch_Code,a.Branch_Name,a.Postprem_code ,a.Postprem_name
	  ORDER BY  a.Branch_Code,a.Branch_Name,a.Postprem_code ,a.Postprem_name    end

    --Taluka




else if(@prowname='Taluka' and @pcolumnname='Publication')begin

	insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Talu_code,Talu_name,Pub_Code,Publication,sum(Billamt),SUM(ActualBusiness) from(
	select 
 (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode ) as Talu_code,
   (select taluka_mast.TALU_NAME from taluka_mast where taluka_mast.TALU_CODE in (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode ) )  as Talu_name,
    tbl_booking_insert.Publication_Code as Pub_Code,
    (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
	isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
	isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
           --     tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY  a.Talu_code,a.Talu_name,a.Pub_Code,a.Publication
      ORDER BY  a.Talu_code,a.Talu_name,a.Pub_Code,a.Publication    end


else if(@prowname='Taluka' and @pcolumnname='Suppliment')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Talu_code,Talu_name,Supplement_CODE,Supplement,sum(Billamt),SUM(ActualBusiness) from(
    select 
 (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode ) as Talu_code,
   (select taluka_mast.TALU_NAME from taluka_mast where taluka_mast.TALU_CODE in (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode ) )  as Talu_name,
        tbl_booking_insert.Supp_Code as Supplement_CODE,
    (select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and tbl_booking_insert.Publication_Code=supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                tbl_booking_mast.Comp_code=@pcompcode and
           --     tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY a.Talu_code,a.Talu_name,a.Supplement_CODE,a.Supplement
      ORDER BY a.Talu_code,a.Talu_name,a.Supplement_CODE,a.Supplement    end


    else if(@prowname='Taluka' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Talu_code,Talu_name,Ad_catg_code,Adv_Catg_Name,sum(Billamt),SUM(ActualBusiness) from(
    select 
 (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode ) as Talu_code,
   (select taluka_mast.TALU_NAME from taluka_mast where taluka_mast.TALU_CODE in (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode ) )  as Talu_name,
      tbl_booking_mast.Ad_cat_code as Ad_catg_code,
    (select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
           --     tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY  a.Talu_code,a.Talu_name,a.Ad_catg_code,a.Adv_Catg_Name
      ORDER BY  a.Talu_code,a.Talu_name,a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='Taluka' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Talu_code,Talu_name, Agency_Type_Code,Agency_type_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
  (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode ) as Talu_code,
   (select taluka_mast.TALU_NAME from taluka_mast where taluka_mast.TALU_CODE in (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode ) )  as Talu_name,
    (select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
        ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
             --   tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY a.Talu_code,a.Talu_name, a.Agency_Type_Code,a.Agency_type_name
      ORDER BY a.Talu_code,a.Talu_name, a.Agency_Type_Code,a.Agency_type_name    end

    else if(@prowname='Taluka' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Talu_code,Talu_name, Scheme_code,Scheme_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
  (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode ) as Talu_code,
   (select taluka_mast.TALU_NAME from taluka_mast where taluka_mast.TALU_CODE in (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode ) )  as Talu_name,
   tbl_booking_mast.Scheme_type_code as Scheme_code,
    (select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
 isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
        ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
           --     tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY a.Talu_code,a.Talu_name, a.Scheme_code,a.Scheme_name
      ORDER BY a.Talu_code,a.Talu_name, a.Scheme_code,a.Scheme_name    end


     else if(@prowname='Taluka' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Talu_code,Talu_name, Page_premium_code,Page_premium_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
   (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode ) as Talu_code,
   (select taluka_mast.TALU_NAME from taluka_mast where taluka_mast.TALU_CODE in (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode ) )  as Talu_name,
  tbl_booking_mast.Page_prem as Page_premium_code,
    (select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
    round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
             --   tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0')a
    GROUP BY  a.Talu_code,a.Talu_name, a.Page_premium_code,a.Page_premium_name
      ORDER BY  a.Talu_code,a.Talu_name, a.Page_premium_code,a.Page_premium_name    end

         else if(@prowname='Taluka' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Talu_code,Talu_name, Postprem_code,Postprem_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
  (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode ) as Talu_code,
   (select taluka_mast.TALU_NAME from taluka_mast where taluka_mast.TALU_CODE in (select agency_mast.TALUKA from agency_mast where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode ) )  as Talu_name,
    tbl_booking_mast.Page_position_code as Postprem_code,
    (select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
    round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
         --       tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0')a
    GROUP BY a.Talu_code,a.Talu_name, a.Postprem_code,a.Postprem_name
      ORDER BY a.Talu_code,a.Talu_name, a.Postprem_code,a.Postprem_name    end

    --City

   

else if(@prowname='City' and @pcolumnname='Publication')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select City_code,City_name, Pub_Code,Publication,sum(Billamt),SUM(ActualBusiness) from(
    select 
   (select AGENCY_MAST.City_Code  from agency_mast  where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as City_code,
   (select city_mst.City_Name from city_mst where City_Code in(select AGENCY_MAST.City_Code  from agency_mast  where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)) as City_name,
    tbl_booking_insert.Publication_Code as Pub_Code,
    (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code ) as Publication,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
        ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
       --         tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY a.City_code,a.City_name, a.Pub_Code,Publication
      ORDER BY a.City_code,a.City_name, a.Pub_Code,Publication    end


else if(@prowname='City' and @pcolumnname='Suppliment')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select City_code,City_name, Supplement_CODE,Supplement,sum(Billamt),SUM(ActualBusiness) from(
    select 
  (select AGENCY_MAST.City_Code  from agency_mast  where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as City_code,
   (select city_mst.City_Name from city_mst where City_Code in(select AGENCY_MAST.City_Code  from agency_mast  where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)) as City_name,
         tbl_booking_insert.Supp_Code as Supplement_CODE,
    (select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and tbl_booking_insert.Publication_Code =supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                tbl_booking_mast.Comp_code=@pcompcode and

          --      tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY a.City_code,a.City_name, a.Supplement_CODE,a.Supplement
      ORDER BY a.City_code,a.City_name, a.Supplement_CODE,a.Supplement    end


    else if(@prowname='City' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select City_code,City_name, Ad_catg_code,Adv_Catg_Name,sum(Billamt),SUM(ActualBusiness) from(
    select 
  (select AGENCY_MAST.City_Code  from agency_mast  where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as City_code,
   (select city_mst.City_Name from city_mst where City_Code in(select AGENCY_MAST.City_Code  from agency_mast  where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)) as City_name,
      tbl_booking_mast.Ad_cat_code as Ad_catg_code,
    (select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
        ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
             --   tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
 ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY a.City_code,a.City_name, a.Ad_catg_code,a.Adv_Catg_Name
      ORDER BY a.City_code,a.City_name, a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='City' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select City_code,City_name, Agency_Type_Code,Agency_type_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
  (select AGENCY_MAST.City_Code  from agency_mast  where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as City_code,
   (select city_mst.City_Name from city_mst where City_Code in(select AGENCY_MAST.City_Code  from agency_mast  where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)) as City_name,
      (select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
             --   tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY a.City_code,a.City_name, a.Agency_Type_Code,a.Agency_type_name
      ORDER BY a.City_code,a.City_name, a.Agency_Type_Code,a.Agency_type_name    end

    else if(@prowname='City' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select City_code,City_name,Scheme_code,Scheme_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
  (select AGENCY_MAST.City_Code  from agency_mast  where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as City_code,
   (select city_mst.City_Name from city_mst where City_Code in(select AGENCY_MAST.City_Code  from agency_mast  where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)) as City_name,
     tbl_booking_mast.Scheme_type_code as Scheme_code,
    (select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
  isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
             --   tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY a.City_code,a.City_name,a.Scheme_code,a.Scheme_name
      ORDER BY a.City_code,a.City_name,a.Scheme_code,a.Scheme_name    end


     else if(@prowname='City' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select City_code,City_name,Page_premium_code,Page_premium_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
   (select AGENCY_MAST.City_Code  from agency_mast  where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as City_code,
   (select city_mst.City_Name from city_mst where City_Code in(select AGENCY_MAST.City_Code  from agency_mast  where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)) as City_name,
    tbl_booking_mast.Page_prem as Page_premium_code,
    (select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
    round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
            --    tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
 ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0')a
    GROUP BY a.City_code,a.City_name,a.Page_premium_code,a.Page_premium_name
      ORDER BY a.City_code,a.City_name,a.Page_premium_code,a.Page_premium_name    end

         else if(@prowname='City' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select City_code,City_name,Postprem_code,Postprem_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
  (select AGENCY_MAST.City_Code  from agency_mast  where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode) as City_code,
   (select city_mst.City_Name from city_mst where City_Code in(select AGENCY_MAST.City_Code  from agency_mast  where TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode)) as City_name,
      tbl_booking_mast.Page_position_code as Postprem_code,
    (select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
    round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
          --      tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0')a
    GROUP BY a.City_code,a.City_name,a.Postprem_code,a.Postprem_name
      ORDER BY a.City_code,a.City_name,a.Postprem_code,a.Postprem_name    end

  
    --Executive

  


else if(@prowname='Executive' and @pcolumnname='Publication')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Executive_Code,Executive_Name,Pub_Code,Publication,sum(Billamt),SUM(ActualBusiness) from(
    select 
    tbl_booking_mast.Executive_code AS Executive_Code,
    (select EXEC_MAST.Exec_name from exec_mast where tbl_booking_mast.Executive_code=exec_mast.Exe_no) AS Executive_Name,
   tbl_booking_insert.Publication_Code as Pub_Code,
   (select pub_mast.Pub_Name from pub_mast where pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
        ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
            --    tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                 and tbl_booking_mast.Executive_code is not null and tbl_booking_mast.Executive_code !='0')a
    GROUP BY a.Executive_Code,a.Executive_Name,a.Pub_Code,a.Publication
      ORDER BY a.Executive_Code,a.Executive_Name,a.Pub_Code,a.Publication    end


else if(@prowname='Executive' and @pcolumnname='Suppliment')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Executive_Code,Executive_Name,Supplement_CODE,Supplement,sum(Billamt),SUM(ActualBusiness) from(
    select 
   tbl_booking_mast.Executive_code AS Executive_Code,
    (select EXEC_MAST.Exec_name from exec_mast where tbl_booking_mast.Executive_code=exec_mast.Exe_no) AS Executive_Name,
          tbl_booking_insert.Supp_Code as Supplement_CODE,
    (select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and tbl_booking_insert.Publication_Code=supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
        ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                tbl_booking_mast.Comp_code=@pcompcode and

           --     tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Executive_code is not null and tbl_booking_mast.Executive_code !='0')a
    GROUP BY   a.Executive_Code,a.Executive_Name,a.Supplement_CODE,a.Supplement
      ORDER BY   a.Executive_Code,a.Executive_Name,a.Supplement_CODE,a.Supplement    end


    else if(@prowname='Executive' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Executive_Code,Executive_Name,Ad_catg_code,Adv_Catg_Name,sum(Billamt),SUM(ActualBusiness) from(
    select 
   tbl_booking_mast.Executive_code AS Executive_Code,
    (select EXEC_MAST.Exec_name from exec_mast where tbl_booking_mast.Executive_code=exec_mast.Exe_no) AS Executive_Name,
       tbl_booking_mast.Ad_cat_code as Ad_catg_code,
    (select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
        ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
              --  tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Executive_code is not null and tbl_booking_mast.Executive_code !='0')a
    GROUP BY  a.Executive_Code,a.Executive_Name,a.Ad_catg_code,a.Adv_Catg_Name
      ORDER BY  a.Executive_Code,a.Executive_Name,a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='Executive' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Executive_Code,Executive_Name,Agency_Type_Code,Agency_type_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
   tbl_booking_mast.Executive_code AS Executive_Code,
    (select EXEC_MAST.Exec_name from exec_mast where tbl_booking_mast.Executive_code=exec_mast.Exe_no) AS Executive_Name,
      (select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
        ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
            --    tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Executive_code is not null and tbl_booking_mast.Executive_code !='0')a
    GROUP BY  a.Executive_Code,a.Executive_Name,a.Agency_Type_Code,a.Agency_type_name
      ORDER BY  a.Executive_Code,a.Executive_Name,a.Agency_Type_Code,a.Agency_type_name    end

    else if(@prowname='Executive' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Executive_Code,Executive_Name,Scheme_code,Scheme_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
   tbl_booking_mast.Executive_code AS Executive_Code,
    (select EXEC_MAST.Exec_name from exec_mast where tbl_booking_mast.Executive_code=exec_mast.Exe_no) AS Executive_Name,
    tbl_booking_mast.Scheme_type_code as Scheme_code,
    (select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
   isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
              --  tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                 and tbl_booking_mast.Executive_code is not null and tbl_booking_mast.Executive_code !='0')a
    GROUP BY  a.Executive_Code,a.Executive_Name,a.Scheme_code,a.Scheme_name
      ORDER BY  a.Executive_Code,a.Executive_Name,a.Scheme_code,a.Scheme_name    end


     else if(@prowname='Executive' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Executive_Code,Executive_Name,Page_premium_code,Page_premium_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
   tbl_booking_mast.Executive_code AS Executive_Code,
    (select EXEC_MAST.Exec_name from exec_mast where tbl_booking_mast.Executive_code=exec_mast.Exe_no) AS Executive_Name,
      tbl_booking_mast.Page_prem as Page_premium_code,
    (select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
    round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
            --    tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0'
                 and tbl_booking_mast.Executive_code is not null and tbl_booking_mast.Executive_code !='0')a
    GROUP BY a.Executive_Code,a.Executive_Name,a.Page_premium_code,a.Page_premium_name
      ORDER BY a.Executive_Code,a.Executive_Name,a.Page_premium_code,a.Page_premium_name    end

         else if(@prowname='Executive' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Executive_Code,Executive_Name,Postprem_code,Postprem_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
  tbl_booking_mast.Executive_code AS Executive_Code,
    (select EXEC_MAST.Exec_name from exec_mast where tbl_booking_mast.Executive_code=exec_mast.Exe_no) AS Executive_Name,
        tbl_booking_mast.Page_position_code as Postprem_code,
    (select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
    round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
          --      tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0'
                 and tbl_booking_mast.Executive_code is not null and tbl_booking_mast.Executive_code !='0')a
    GROUP BY a.Executive_Code,a.Executive_Name,a.Postprem_code,a.Postprem_name
      ORDER BY a.Executive_Code,a.Executive_Name,a.Postprem_code,a.Postprem_name    end

        --Retainer

       

else if(@prowname='Retainer' and @pcolumnname='Publication')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Retainer_Code, Retainer_Name,Pub_Code,Publication,sum(Billamt),SUM(ActualBusiness) from(
    select 
  tbl_booking_mast.RETAINER AS Retainer_Code,
(select RETAINERMASTER.Retain_Name  FROM  RETAINERMASTER where RETAINERMASTER.Retain_Code=tbl_booking_mast.RETAINER ) AS Retainer_Name,
  tbl_booking_insert.Publication_Code as Pub_Code,
  (SELECT pub_mast.Pub_Name  FROM PUB_MAST WHERE pub_mast.Pub_Code=tbl_booking_insert.Publication_Code)as Publication,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
            --    tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                 and (tbl_booking_mast.RETAINER is not null and tbl_booking_mast.RETAINER !='0'))a
    GROUP BY a.Retainer_Code, a.Retainer_Name,a.Pub_Code,a.Publication
      ORDER BY a.Retainer_Code, a.Retainer_Name,a.Pub_Code,a.Publication    end


else if(@prowname='Retainer' and @pcolumnname='Suppliment')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Retainer_Code, Retainer_Name,Supplement_CODE, Supplement,sum(Billamt),SUM(ActualBusiness) from(
    select 
  tbl_booking_mast.RETAINER AS Retainer_Code,
(select RETAINERMASTER.Retain_Name  FROM  RETAINERMASTER where RETAINERMASTER.Retain_Code=tbl_booking_mast.RETAINER ) AS Retainer_Name,
        tbl_booking_insert.Supp_Code as Supplement_CODE,
    (select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and tbl_booking_insert.Publication_Code=supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
        ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                tbl_booking_mast.Comp_code=@pcompcode and
         --       tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                 and (tbl_booking_mast.RETAINER is not null and tbl_booking_mast.RETAINER !='0'))a
    GROUP BY a.Retainer_Code, a.Retainer_Name,a.Supplement_CODE, a.Supplement
      ORDER BY a.Retainer_Code, a.Retainer_Name,a.Supplement_CODE, a.Supplement    end


    else if(@prowname='Retainer' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Retainer_Code, Retainer_Name,Ad_catg_code,Adv_Catg_Name,sum(Billamt),SUM(ActualBusiness) from(
    select 
  tbl_booking_mast.RETAINER AS Retainer_Code,
(select RETAINERMASTER.Retain_Name  FROM  RETAINERMASTER where RETAINERMASTER.Retain_Code=tbl_booking_mast.RETAINER ) AS Retainer_Name,
     tbl_booking_mast.Ad_cat_code as Ad_catg_code,
    (select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
            --    tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                 and (tbl_booking_mast.RETAINER is not null and tbl_booking_mast.RETAINER !='0'))a
    GROUP BY  a.Retainer_Code, a.Retainer_Name,a.Ad_catg_code,a.Adv_Catg_Name
      ORDER BY  a.Retainer_Code, a.Retainer_Name,a.Ad_catg_code,a.Adv_Catg_Name    end

    else if(@prowname='Retainer' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Retainer_Code, Retainer_Name,Agency_Type_Code ,Agency_type_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
  tbl_booking_mast.RETAINER AS Retainer_Code,
(select RETAINERMASTER.Retain_Name  FROM  RETAINERMASTER where RETAINERMASTER.Retain_Code=tbl_booking_mast.RETAINER ) AS Retainer_Name,
    (select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
        ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
            --    tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                 and (tbl_booking_mast.RETAINER is not null and tbl_booking_mast.RETAINER !='0'))a
    GROUP BY a.Retainer_Code, a.Retainer_Name,a.Agency_Type_Code ,a.Agency_type_name
      ORDER BY a.Retainer_Code, a.Retainer_Name,a.Agency_Type_Code ,a.Agency_type_name    end

    else if(@prowname='Retainer' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Retainer_Code, Retainer_Name,Scheme_code ,Scheme_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
 tbl_booking_mast.RETAINER AS Retainer_Code,
(select RETAINERMASTER.Retain_Name  FROM  RETAINERMASTER where RETAINERMASTER.Retain_Code=tbl_booking_mast.RETAINER ) AS Retainer_Name,
    tbl_booking_mast.Scheme_type_code as Scheme_code,
    (select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
 isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
        ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
             --   tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                 and (tbl_booking_mast.RETAINER is not null and tbl_booking_mast.RETAINER !='0'))a
    GROUP BY a.Retainer_Code, a.Retainer_Name,a.Scheme_code ,a.Scheme_name
      ORDER BY a.Retainer_Code, a.Retainer_Name,a.Scheme_code ,a.Scheme_name    end


     else if(@prowname='Retainer' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Retainer_Code, Retainer_Name,Page_premium_code ,Page_premium_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
  tbl_booking_mast.RETAINER AS Retainer_Code,
(select RETAINERMASTER.Retain_Name  FROM  RETAINERMASTER where RETAINERMASTER.Retain_Code=tbl_booking_mast.RETAINER ) AS Retainer_Name,
    tbl_booking_mast.Page_prem as Page_premium_code,
    (select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
    round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
             --   tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0'
                and (tbl_booking_mast.RETAINER is not null and tbl_booking_mast.RETAINER !='0'))a
    GROUP BY a.Retainer_Code, a.Retainer_Name,a.Page_premium_code ,a.Page_premium_name
      ORDER BY a.Retainer_Code, a.Retainer_Name,a.Page_premium_code ,a.Page_premium_name    end

         else if(@prowname='Retainer' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Retainer_Code, Retainer_Name,Postprem_code ,Postprem_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
  tbl_booking_mast.RETAINER AS Retainer_Code,
(select RETAINERMASTER.Retain_Name  FROM  RETAINERMASTER where RETAINERMASTER.Retain_Code=tbl_booking_mast.RETAINER ) AS Retainer_Name,
      tbl_booking_mast.Page_position_code as Postprem_code,
    (select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
    round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
             --   tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0'
                 and (tbl_booking_mast.RETAINER is not null and tbl_booking_mast.RETAINER !='0'))a
    GROUP BY a.Retainer_Code, a.Retainer_Name,a.Postprem_code ,a.Postprem_name
      ORDER BY a.Retainer_Code, a.Retainer_Name,a.Postprem_code ,a.Postprem_name    end

    --Package



else if(@prowname='Package' and @pcolumnname='Publication')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Package_code, Package,Pub_Code ,Publication,sum(Billamt),SUM(ActualBusiness) from(
    select 
tbl_booking_mast.Package_code as Package_code,
    isnull((select combin_mast.Package_Name from combin_mast where combin_mast.Combin_Code in (tbl_booking_mast.Package_code) and tbl_booking_mast.Ad_type_code=combin_mast.Ad_Type_code ),tbl_booking_mast.Package_code) as Package ,

  tbl_booking_insert.Publication_Code  as Pub_Code,
  (SELECT pub_mast.Pub_Name FROM PUB_MAST WHERE pub_mast.Pub_Code=tbl_booking_insert.Publication_Code) as Publication,
isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                tbl_booking_mast.Comp_code=@pcompcode and
          --      tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY a.Package_code, a.Package,a.Pub_Code ,a.Publication
      ORDER BY a.Package_code, a.Package,a.Pub_Code ,a.Publication    end


else if(@prowname='Package' and @pcolumnname='Suppliment')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Package_code, Package,Supplement_CODE ,Supplement,sum(Billamt),SUM(ActualBusiness) from(
    select 
tbl_booking_mast.Package_code as Package_code,
    isnull((select combin_mast.Package_Name from combin_mast where combin_mast.Combin_Code in (tbl_booking_mast.Package_code) and tbl_booking_mast.Ad_type_code=combin_mast.Ad_Type_code ),tbl_booking_mast.Package_code) as Package ,

        tbl_booking_insert.Supp_Code as Supplement_CODE,
    (select supplement_mast.Supp_Name from supplement_mast where supplement_mast.Supp_Code=tbl_booking_insert.Supp_Code and tbl_booking_insert.Publication_Code=supplement_mast.Pub_Code and tbl_booking_insert.Edition_Code =supplement_mast.Edition_Code ) as Supplement,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
                tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                tbl_booking_mast.Comp_code=@pcompcode and

          --      tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY a.Package_code, a.Package,a.Supplement_CODE ,a.Supplement
      ORDER BY a.Package_code, a.Package,a.Supplement_CODE ,a.Supplement    end


    else if(@prowname='Package' and @pcolumnname='Ad Category')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Package_code, Package,Ad_catg_code ,Adv_Catg_Name,sum(Billamt),SUM(ActualBusiness) from(
    select 
  tbl_booking_mast.Package_code as Package_code,
        isnull((select combin_mast.Package_Name from combin_mast where combin_mast.Combin_Code in (tbl_booking_mast.Package_code) and tbl_booking_mast.Ad_type_code=combin_mast.Ad_Type_code ),tbl_booking_mast.Package_code) as Package ,
      tbl_booking_mast.Ad_cat_code as Ad_catg_code,
    (select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where adv_cat_mast.Adv_Cat_Code=tbl_booking_mast.Ad_cat_code ) as Adv_Catg_Name ,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
            --    tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY a.Package_code, a.Package,a.Ad_catg_code ,a.Adv_Catg_Name
      ORDER BY a.Package_code, a.Package,a.Ad_catg_code ,a.Adv_Catg_Name    end

    else if(@prowname='Package' and @pcolumnname='Agency Type')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Package_code, Package,Agency_Type_Code  ,Agency_type_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
 tbl_booking_mast.Package_code as Package_code,
    isnull((select combin_mast.Package_Name from combin_mast where combin_mast.Combin_Code in (tbl_booking_mast.Package_code) and tbl_booking_mast.Ad_type_code=combin_mast.Ad_Type_code ),tbl_booking_mast.Package_code) as Package ,
   (select agency_type_mst.Agency_Type_Code from agency_type_mst where agency_type_mst.Agency_Type_Name=tbl_booking_mast.Agency_type ) as Agency_Type_Code ,
    tbl_booking_mast.Agency_type as Agency_type_name,
    isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
            --    tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY a.Package_code, a.Package,a.Agency_Type_Code  ,a.Agency_type_name
      ORDER BY a.Package_code, a.Package,a.Agency_Type_Code  ,a.Agency_type_name    end

    else if(@prowname='Package' and @pcolumnname='Scheme')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Package_code, Package,Scheme_code ,Scheme_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
tbl_booking_mast.Package_code as Package_code,
    isnull((select combin_mast.Package_Name from combin_mast where combin_mast.Combin_Code in (tbl_booking_mast.Package_code) and tbl_booking_mast.Ad_type_code=combin_mast.Ad_Type_code ),tbl_booking_mast.Package_code) as Package ,
     tbl_booking_mast.Scheme_type_code as Scheme_code,
    (select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id)  as Scheme_name,
   isnull(tbl_booking_insert.Bill_Amt,0) as Billamt,
    isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
            --    tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
 ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code)a
    GROUP BY a.Package_code, a.Package,a.Scheme_code ,a.Scheme_name
      ORDER BY a.Package_code, a.Package,a.Scheme_code ,a.Scheme_name    end


     else if(@prowname='Package' and @pcolumnname='Page Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Package_code, Package,Page_premium_code , Page_premium_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
  tbl_booking_mast.Package_code as Package_code,
    isnull((select combin_mast.Package_Name from combin_mast where combin_mast.Combin_Code in (tbl_booking_mast.Package_code) and tbl_booking_mast.Ad_type_code=combin_mast.Ad_Type_code ),tbl_booking_mast.Package_code) as Package ,
    tbl_booking_mast.Page_prem as Page_premium_code,
    (select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_mast.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Page_premium_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
    round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
           --     tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and 
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and

((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_prem is not null and tbl_booking_mast.Page_prem !='0')a
    GROUP BY  a.Package_code, a.Package,a.Page_premium_code , a.Page_premium_name
      ORDER BY  a.Package_code, a.Package,a.Page_premium_code , a.Page_premium_name    end

         else if(@prowname='Package' and @pcolumnname='Post. Premium')begin

    insert into #temp_complete_dynamic_report(row_code,row_desc,col_code,col_desc,col_bilamt,col_actamt)
    select Package_code, Package,Postprem_code ,Postprem_name,sum(Billamt),SUM(ActualBusiness) from(
    select 
 tbl_booking_mast.Package_code as Package_code,
    isnull((select combin_mast.Package_Name from combin_mast where combin_mast.Combin_Code in (tbl_booking_mast.Package_code) and tbl_booking_mast.Ad_type_code=combin_mast.Ad_Type_code ),tbl_booking_mast.Package_code) as Package ,
     tbl_booking_mast.Page_position_code as Postprem_code,
    (select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_mast.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem_name,
    round(isnull(tbl_booking_insert.Bill_Amt,0),2) as Billamt,
    round(isnull((tbl_booking_insert.Bill_Amt-isnull(dbo.fun_actual(@pcompcode,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_insert.Gross_Rate,0),@prefer,2 ),0)  ),0),2) as ActualBusiness
    ,TBL_BOOKING_MAST.cio_booking_id
    ,AGENCY_MAST.Agency_Name
    ,adv_cat_mast.Adv_Cat_Name
    ,UOM_MAST.Uom_Name,pub_mast.Pub_Name ,TBL_BOOKING_INSERT.Edition   as Ed_Name   
    from pub_mast,TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,adv_cat_mast,adv_type_mast,TBL_BOOKING_insert
    where
             UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
             TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
             tbl_booking_mast.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
             tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code and tbl_booking_mast."Comp_code" = adv_type_mast."Comp_Code" AND
             adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
             lower(Insert_Status)!='cancel' AND
             tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and
                 tbl_booking_mast.Comp_code=@pcompcode and
         --       tbl_booking_insert.Insert_Date between @v_frdt and @v_todt  and
tbl_booking_insert.BILL_DATE between @v_frdt and @v_todt  and
 ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access=1) or (@chk_access=0) ) and  pub_mast.Pub_Code=TBL_BOOKING_insert.Publication_Code
                and tbl_booking_mast.Page_position_code is not null and tbl_booking_mast.Page_position_code !='0')a
    GROUP BY a.Package_code, a.Package,a.Postprem_code ,a.Postprem_name
      ORDER BY a.Package_code, a.Package,a.Postprem_code ,a.Postprem_name    end




------------------ cursor open---------
open c1
fetch next from c1
into @c1val1 ,@c1val2
while @@FETCH_STATUS=0
begin

	IF @c1val2 IS NOT NULL 
	begin
		if @v_var is null 
		begin
			print(@prowname) 
			print(@pcolumnname)
			--set @v_var        ='decode(d.col_desc,'+''''+@c1val2+''''+',d.col_bilamt)"'+@c1val2+'_BILL_AMT"'
			set @v_var        ='case when d.col_desc = '+''''+@c1val2+''''+' then d.col_bilamt end as "'+@c1val2+'_BILL_AMT"'
			--set @v_var        =@v_var+','+'decode(d.col_desc,'+''''+@c1val2+''''+',d.col_actamt)"'+@c1val2+'_ACT_AMT"'
			set @v_var        =@v_var+','+'case when d.col_desc = '+''''+@c1val2+''''+' then d.col_actamt end as "'+@c1val2+'_ACT_AMT"'
			set @v_var_sum    ='round(sum("'+@c1val2+'_BILL_AMT"),2)'+' "'+@c1val2+'_BILL_AMT"'
			set @v_var_sum    =@v_var_sum+','+'round(sum("'+@c1val2+'_ACT_AMT"),2)'+' "'+@c1val2+'_ACT_AMT"'
		end
		else
		begin
			--set @v_var        =@v_var+','+'decode(d.col_desc,'+''''+@c1val2+''''+',d.col_bilamt)"'+@c1val2+'_BILL_AMT"'
			--set @v_var        =@v_var+','+'decode(d.col_desc,'+''''+@c1val2+''''+',d.col_actamt)"'+@c1val2+'_ACT_AMT"'
			set @v_var        =@v_var+','+'case when d.col_desc='+''''+@c1val2+''''+' then d.col_bilamt end as "'+@c1val2+'_BILL_AMT"'
			set @v_var        =@v_var+','+'case when d.col_desc = '+''''+@c1val2+''''+' then d.col_actamt end as "'+@c1val2+'_ACT_AMT"'
			set @v_var_sum    =@v_var_sum+','+'round(sum("'+@c1val2+'_BILL_AMT"),2)'+' "'+@c1val2+'_BILL_AMT"'
			set @v_var_sum    =@v_var_sum+','+'round(sum("'+@c1val2+'_ACT_AMT"),2)'+' "'+@c1val2+'_ACT_AMT"'
		end
	end 
    ELSE
	begin		
        if @v_var is null 
		begin
        	set @v_var     =NULL
            set @v_var_sum =NULL
		end
        else
		begin
        	set @v_var      =@v_var+ NULL
            set @v_var_sum    =@v_var_sum+ NULL
        end 
        
 END
fetch next from c1
into @c1val1 ,@c1val2 
end
close c1
deallocate c1

if @v_var is not null 
begin
  	set @v_query='select row_code,row_desc,'+@v_var_sum+' from (select distinct d.row_code as row_code,d.row_desc as row_desc, '+@v_var+' from #temp_complete_dynamic_report d ) e group by e.row_code,e.row_desc order by e.row_desc'
 	--set @v_query='select * from abc'

end
ELSE
begin
	 set @v_query='select ''abc_pk'''
end 
print @v_query
exec (@v_query)
select * from #temp_complete_dynamic_report
drop table #temp_complete_dynamic_report





-----------end----avinash----------------------------------------------------------


-----------start----avinash-------7415----29may2012-----------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



/****** Object:  StoredProcedure [dbo].[Schedulereport1]    Script Date: 01/24/2012 11:16:33 ******/
                                                                     
                                                                     
                                                                     
                                             
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
	@packagecode 			varchar(50),
	@editiondtl 			varchar(50),
	@puserid				varchar(50),
	@chk_access				varchar(2),
@ro_statusres				varchar(2),
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
				isnull(Agrred_rate,TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", TBL_BOOKING_MAST.Caption as "Caption", 
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
				isnull(Agrred_rate,TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", TBL_BOOKING_MAST.Caption as "Caption", 
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
				isnull(TBL_BOOKING_MAST.Agrred_rate, TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", TBL_BOOKING_MAST.Caption as "Caption", 
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
				isnull(TBL_BOOKING_MAST.Agrred_rate, TBL_BOOKING_MAST.Card_rate) AS "AgreedRate", tbl_booking_insert.Status_Material as "InsertStatus", TBL_BOOKING_MAST.Caption as "Caption", 
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







-----------end----avinash----------7415------------------------------------------------


======start==avinash================by mimoh=======================================
ALTER procedure emp_code_bind 
    @pcomp_code	as	varchar(20),
    @pname      as	varchar(20),
    @pextra1    as	varchar(200),
    @pextra2    as	varchar(200),
    @pextra3    as	varchar(200),
    @pextra4    as	varchar(200)
as
begin
    select emp_code as "EMP_CODE",name as "NAME",addr1 as "ADDR1",addr2 as "ADDR2",addr3 as "ADDR3",pin as "PIN",
    father_name as "FATHER_NAME",last_name as "LAST_NAME",
    (select dept from hr_dept_mast where dept_code=hr_emp_mst.deptcode) "DEPT_NAME",email as "EMAIL",
    phone as "PHONE",mobile as "MOBILE",bran_code as "BRAN_CODE",
    (select "Branch_Name" from branch_mst where "Branch_Code"=hr_emp_mst.bran_code) as "BRANCH_NAME"
    from hr_emp_mst where comp_cd=@pcomp_code 
    and ( upper(name) like upper(@pname)+'%' or @pname is null or @pname='') order by "NAME";
         
    select 'a' as "A"
         
    select 'a'  as "A" 

    select 'a' as "A"
     
end

======end==avinash================by mimoh=======================================

