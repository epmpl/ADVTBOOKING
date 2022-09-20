@@@@@@@@@@@@@@@@@@@@@@@@@@@@ fmg reasion by bhanu @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

alter table TBL_BOOKING_FMG_TRANS add FMG_REASONS varchar(50)

alter table TBL_BOOKING_FMG_TRANS_g add FMG_REASONS varchar(50)


@@@@@@@@@@@@@@@@@@


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[fetchFMGrefID]
	@cioid_p varchar(50)
AS
BEGIN

	--select INSERTID from TBL_BOOKING_FMG_TRANS where cioid=@cioid_p
select TBL_BOOKING_FMG_TRANS.INSERTID,"Col_Code","Height","Width","Size_Book",FMG_REASONS from tbl_booking_insert,TBL_BOOKING_FMG_TRANS 
 where tbl_booking_insert."Insert_Id"=TBL_BOOKING_FMG_TRANS.INSERTID
 and TBL_BOOKING_FMG_TRANS.cioid=@cioid_p
	
END


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


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
			REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM)
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
			REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM
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

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





ALTER  PROCEDURE [dbo].[insert_fmgTrans_details]
(
@p_str as varchar(1000),
@cioidm as varchar(50),
@STATUS as varchar(50),
@fmgreasons as varchar(50)

) 

As
declare @tmpVar as NUMERIC;
declare @tmpStr as VARCHAR(4000)
declare @l_str as VARCHAR(4000)
declare @l_pub as varchar(50)
declare @l_share as varchar(20)
declare @l_type as varchar(20)
declare @countnum as int
DECLARE @spli_str AS VARCHAR(4000)

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
		
	   
IF @STATUS = 'INSERT' 
BEGIN
   insert into TBL_BOOKING_FMG_TRANS_G(CIOID, INSERTID,CREATIONDATETIME,FMG_REASONS) 
   values(@cioidm,@l_str,getdate(),@fmgreasons)
END
 ELSE 
BEGIN
    SELECT @countnum=COUNT(*)   FROM TBL_BOOKING_FMG_TRANS WHERE CIOID=@cioidm AND insertid=@l_str
    IF(@countnum=0) 
           insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID,CREATIONDATETIME,FMG_REASONS) 
   values(@cioidm,@l_str,getdate(),@fmgreasons)
   -- ELSE
        
 
END 
		  FETCH next from c1 INTO @spli_str
    end 
    close c1
    deallocate c1
 drop table #tempsplitstr
 end





@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@2


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
@clienttype as varchar(5),
@translation as varchar(25),
@translationcharge as float,
@fmgreasons as varchar(50)
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
REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM
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
@p_revisedate,@clienttype,@translation,@translationcharge
)


IF @sharepub_p is not null and @sharepub_p!=''
begin
	exec insert_sharepub_details @sharepub_p,@ciobookid,'INSERT'
end


if @fmginsert is not null and @fmginsert!=''
begin
	exec insert_fmgTrans_details @fmginsert,@ciobookid,'INSERT',@fmgreasons
end




if @multiselect is not null and @multiselect!=''
begin
	exec insert_multiexec_details @userid,@compcode,@multiselect,@ciobookid,'INSERT'
end





#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
@translationcharge as float,
@fmgreasons as varchar(50)
AS
declare @sccode			as varchar(50)
declare @v_modifed_audit varchar(1)
declare @v_audit_exist   numeric(1)

set @v_modifed_audit=null
If @audit is null and @rostatus='1' Begin
    
    /*select @v_audit_exist=count(x.rec) from
    (select count(*) rec from tbl_booking_mast 
        where "Comp_code"=@compcode and "cio_booking_id"=@ciobookid and "ro_status"='1' and "audit" is not null
    union
    select count(*) from tbl_booking_mast 
    where "Comp_code"=@compcode and "cio_booking_id"=@ciobookid and "ro_status"='1' and isnull(modified_audit,'N')='Y') x
    
    If @v_audit_exist>0 Begin
        set @v_modifed_audit='Y'
    End*/
    
    select  @v_modifed_audit =case when ("audit" is not null and "audit"!='') then 'Y' 
								when isnull(modified_audit,'N')='Y' then 'Y' 
							else null  End from tbl_booking_mast 
        where "Comp_code"=@compcode and "cio_booking_id"=@ciobookid and "ro_status"='1'    
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
	exec insert_fmgTrans_details @fmginsert,@ciobookid,'UPDATE',@fmgreasons
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


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
 set @query='select distinct tbl_booking_insert.cio_booking_id,tbl_booking_insert."Col_Code"  as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION",insert_id,Insert_date,Gross_rate,Bill_Amt,RO_No from tbl_booking_insert,tbl_booking_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and tbl_booking_insert.comp_code='''+@compcode+''' and insert_date between '''+@fromdate+''' and '''+@todate+''' and tbl_booking_mast.Agency_sub_code= '''+@agency+''' and tbl_booking_mast.Ad_type_code= '''+@p_adtye+''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')' 
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
set @query='select distinct tbl_booking_insert.cio_booking_id,tbl_booking_insert."Col_Code"  as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION",insert_id,Insert_date,Gross_rate,Bill_Amt,RO_No from tbl_booking_insert,tbl_booking_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id and tbl_booking_insert.comp_code='''+@compcode+'''  and tbl_booking_mast.Agency_sub_code= '''+@agency+''' and tbl_booking_mast.Ad_type_code= '''+@p_adtye+''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')' 
 set @query=@query + ' and tbl_booking_insert.Insert_Id in(select insert_id from #tmp1)'
print(@query)
exec(@query)
drop table #tmp1
end


  End 

@@@@@@@@@@@@@@@@@@@@@@@@@@@@ fmg reasion by bhanu @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

@@@@@@@@@@@@@@@@@@@@@@@@@@@@ 6890 ankit  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[vat_delete]    Script Date: 03/05/2012 16:48:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[vat_delete]


@comp_code as varchar(8),
@vat_description as varchar(50),
@p_fromdate as varchar(50),
@p_todate as varchar(50),
@p_publicat as varchar(50),
@p_edit as varchar(50)

as 

declare @query as varchar(900)

delete from tbl_vat_mast where  comp_code=@comp_code and    vat_description =@vat_description 
 and Vat_From_Date=@p_fromdate AND Vat_To_Date = @p_todate  and PUBLICATION=@p_publicat and  EDITION=@p_edit








USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[vat_modify]    Script Date: 03/05/2012 16:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[vat_modify]
@comp_code as varchar(8),
@userid as varchar(8),
@vat_description as varchar(50),
@vat_rate as varchar(50),
@vat_from_date as  datetime,
@vat_to_date as datetime,
@vat_gross_type as varchar(50),
@vat_code as varchar(50)=null,
@vat_order_no as varchar(50),
@publicat     as varchar(25),
@edit		  as varchar(25)


 AS
begin
--update tbl_vat_mast set comp_code=@comp_code,userid=@userid, vat_rate=@vat_rate,vat_from_date=@vat_from_date , vat_to_date =@vat_to_date,vat_gross_type=@vat_gross_type,vat_code=@vat_code,vat_order_no=@vat_order_no,PUBLICATION=@publicat, EDITION=@edit where  vat_description=@vat_description
update tbl_vat_mast set vat_rate=@vat_rate,vat_gross_type=@vat_gross_type,vat_code=@vat_code,vat_order_no=@vat_order_no
where  vat_description=@vat_description and vat_from_date=@vat_from_date and vat_to_date =@vat_to_date and PUBLICATION=@publicat and EDITION=@edit 
end




USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[vatsave]    Script Date: 03/05/2012 16:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[vatsave]
@comp_code as varchar(8),
@userid as varchar(8),
@vat_description as varchar(50),
@vat_rate as varchar(50),
@vat_from_date as  datetime,
@vat_to_date as datetime,
@vat_gross_type as varchar(50),
@vat_code as varchar(50)=null,
@vat_order_no as varchar(50),
@publicat     as varchar(25),
@edit		  as varchar(25)

 AS
insert into tbl_vat_mast(comp_code,userid,vat_description,vat_rate,vat_from_date,vat_to_date,vat_gross_type,vat_code,vat_order_no,Creation_Datetime,PUBLICATION, EDITION)
values(@comp_code,@userid,@vat_description,@vat_rate,@vat_from_date,@vat_to_date,@vat_gross_type,@vat_code,@vat_order_no,getdate(),@publicat,@edit)





USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[Vat_Exe]    Script Date: 03/05/2012 17:46:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE   [dbo].[Vat_Exe]
@comp_code as varchar(8),
@userid as varchar(8),
@vat_description as varchar(50),
@vat_rate as varchar(50),
@vat_from_date as  datetime,
@vat_to_date as datetime,
@vat_gross_type as varchar(50),
@vat_code as varchar(50)=null,
@vat_order_no as varchar(50)

AS



declare @query  as   varchar(1000)

--set @query='insert into #tbl_vat_mast select comp_code,userid,vat_description,vat_rate,    vat_from_date   ,   vat_to_date, vat_gross_type,vat_code,vat_order_no from tbl_vat_mast  where comp_code='''+@comp_code+''''
set @query='select comp_code,userid,vat_description,vat_rate,convert(varchar(10) ,vat_from_date,101)  vat_from_date  ,   convert(varchar (10) ,vat_to_date,101) vat_to_date, vat_gross_type,vat_code,vat_order_no,PUBLICATION,EDITION from tbl_vat_mast  where comp_code='''+@comp_code+''''

if(@vat_description<>'0')
begin
set @query=@query+'and vat_description = '''+@vat_description+''''
end
if(@vat_rate <>  '')
begin
set @query= @query+' and  vat_rate like  ''%'+@vat_rate+'%'''
end
if(@vat_from_date <> '')
begin
set @query=@query+ ' and  vat_from_date like  ''%'+cast(@vat_from_date as varchar)+'%'''
end
if(@vat_to_date <> '')
begin
set @query=@query+ ' and  vat_to_date like  ''%'+cast(@vat_to_date as varchar)+'%'''
end

if(@vat_gross_type <>'0')
begin
set @query=@query+ ' and vat_gross_type =  '''+@vat_gross_type+''''
end



if(@vat_order_no <> '')
begin
set @query=@query+ ' and vat_order_no like  ''%'+@vat_order_no+'%'''
end

print(@query)
exec(@query)



--select   comp_code,userid,vat_description,vat_rate,    convert(varchar(10) ,vat_from_date,101)  vat_from_date  ,   convert(varchar (10) ,vat_to_date,101) vat_to_date, vat_gross_type,vat_code,vat_order_no  from #tbl_vat_mast

--drop table #tbl_vat_mast





@@@@@@@@@@@@@@@@@@@@@@@@@@@@ 6890 ankit  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

@@@@@@@@@@@@@@@@@@@@@@@@@@@@ 6892 ankit  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[pubtypeinsert]    Script Date: 03/05/2012 18:02:58 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE  [dbo].[pubtypeinsert]

@compcode as varchar(8),
@pubcode as varchar(8),
@pubname as varchar(30),
@Alias as varchar(30),
@userid as varchar(8)
--@creationdatetime as varchar(8)

as 

declare @query as varchar (1000)


insert into pub_type_mast (Comp_Code,pubtypecode,pubname,pubalias,UserId,creationdate)values (@compcode,@pubcode,@pubname,@Alias,@userid,getdate())

--set @query='update ADVPOS_TYPE_MAST set  Pos_Type_Code='''+@PosTypCode+''',Pos_Type='''+@PosType+''',Pos_Type_Alias='''+@Alias+''',Comp_Code='''+@compcode+''',UserId='''+@userid+'''  where  Comp_Code='''+@compcode+''' and UserId='''+@userid+''' and Pos_Type_Code='''+@PosTypCode+''''

print(@query)
exec(@query)





USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[pubtypeexe]    Script Date: 03/05/2012 18:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE  [dbo].[pubtypeexe]

@compcode as varchar(8),
@pubcode as varchar(8),
@pubname as varchar(30),
@Alias as varchar(30)
--@userid as varchar(8)




AS
declare @query as varchar (1000)

--delete from ADVPOS_TYPE_MASTTEMP

CREATE TABLE #pubtypedummy(
	Comp_Code varchar(8) ,
	pubtypecode varchar(8)  ,
	pubname varchar(30)  ,
	pubalias varchar(30)  ,
	UserId varchar(8),
	creationdate datetime  
)

set @query='insert #pubtypedummy select * from  pub_type_mast where  Comp_Code='''+@compcode+''' '--and UserId='''+@userid+'''   '


if(@pubcode <>'')
begin
set @query=@query+'and  pubtypecode like ''%'+@pubcode+'%'''
end
if(@pubname <>'')
begin
set  @query=@query+'and  pubname like ''%'+@pubname+'%'''
end

if(@Alias<>'')
begin
set @query=@query+'and pubalias like  ''%'+@Alias+'%'''
end

print(@query)
exec(@query)


select  distinct  * from #pubtypedummy order by pubtypecode
drop table  #pubtypedummy


--elect  distinct  * from SUPPLEMENT_MASTTEMP


@@@@@@@@@@@@@@@@@@@@@@@@@@@@ 6892 ankit  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

@@@@@@@@@@@@@@@@@@@@@@@@@@@@ 6892 ankit  06 march @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[pubtypeinsert]    Script Date: 03/06/2012 14:58:32 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE  [dbo].[pubtypeinsert]

@compcode as varchar(8),
@pubcode as varchar(8),
@pubname as varchar(30),
@Alias as varchar(30),
@userid as varchar(8)
--@creationdatetime as varchar(8)

as 

declare @query as varchar (1000)


insert into pub_type_mast (Comp_Code,pubtypecode,pubname,pubalias,UserId,creationdate)values (@compcode,@pubcode,@pubname,@Alias,@userid,getdate())

--set @query='update ADVPOS_TYPE_MAST set  Pos_Type_Code='''+@PosTypCode+''',Pos_Type='''+@PosType+''',Pos_Type_Alias='''+@Alias+''',Comp_Code='''+@compcode+''',UserId='''+@userid+'''  where  Comp_Code='''+@compcode+''' and UserId='''+@userid+''' and Pos_Type_Code='''+@PosTypCode+''''

print(@query)
exec(@query)






USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[pubtypeexe]    Script Date: 03/06/2012 15:00:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE  [dbo].[pubtypeexe]

@compcode as varchar(8),
@pubcode as varchar(8),
@pubname as varchar(30),
@Alias as varchar(30)
--@userid as varchar(8)




AS
declare @query as varchar (1000)

--delete from ADVPOS_TYPE_MASTTEMP

CREATE TABLE #pubtypedummy(
	Comp_Code varchar(8) ,
	pubtypecode varchar(8)  ,
	pubname varchar(30)  ,
	pubalias varchar(30)  ,
	UserId varchar(8),
	creationdate datetime  
)

set @query='insert #pubtypedummy select * from  pub_type_mast where  Comp_Code='''+@compcode+''' '--and UserId='''+@userid+'''   '


if(@pubcode <>'')
begin
set @query=@query+'and  pubtypecode like ''%'+@pubcode+'%'''
end
if(@pubname <>'')
begin
set  @query=@query+'and  pubname like ''%'+@pubname+'%'''
end

if(@Alias<>'')
begin
set @query=@query+'and pubalias like  ''%'+@Alias+'%'''
end

print(@query)
exec(@query)


select  distinct  * from #pubtypedummy order by pubtypecode
drop table  #pubtypedummy


--elect  distinct  * from SUPPLEMENT_MASTTEMP








USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[pubtypemodify]    Script Date: 03/06/2012 15:03:28 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER PROCEDURE [dbo].[pubtypemodify]



@compcode as varchar(8),
@pubcode as varchar(8),
@pubname as varchar(30),
@Alias as varchar(30)
--@userid as varchar(8)




AS

declare @query as varchar (1000)
declare @query1 as varchar (1000)


set @query='update pub_type_mast set pubtypecode='''+@pubcode+''',pubname='''+@pubname+''',pubalias='''+@Alias+'''  where  Comp_Code='''+@compcode+''' and pubtypecode='''+@pubcode+'''' --and UserId='''+@userid+'''
set @query1='update pubtypedummy set  pubtypecode='''+@pubcode+''',pubname='''+@pubname+''',pubalias='''+@Alias+'''  where  Comp_Code='''+@compcode+''' and pubtypecode='''+@pubcode+''''--and UserId='''+@userid+''' 

print(@query)
print(@query1)
exec(@query)
exec(@query1)


@@@@@@@@@@@@@@@@@@@@@@@@@@@@ 6892 ankit  06 march @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


@@@@@@@@@@@@@@@@@@@@@@@@@@@@ tax rate ankit  06 march @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[vat_delete]    Script Date: 03/06/2012 15:21:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[vat_delete]


@comp_code as varchar(8),
@vat_description as varchar(50),
@p_fromdate as varchar(50),
@p_todate as varchar(50),
@p_publicat as varchar(50),
@p_edit as varchar(50)

as 

declare @query as varchar(900)

delete from tbl_vat_mast where  comp_code=@comp_code and    vat_description =@vat_description 
 and Vat_From_Date=@p_fromdate AND Vat_To_Date = @p_todate  and PUBLICATION=@p_publicat and  EDITION=@p_edit










USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[vatsave]    Script Date: 03/06/2012 15:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[vatsave]
@comp_code as varchar(8),
@userid as varchar(8),
@vat_description as varchar(50),
@vat_rate as varchar(50),
@vat_from_date as  datetime,
@vat_to_date as datetime,
@vat_gross_type as varchar(50),
@vat_code as varchar(50)=null,
@vat_order_no as varchar(50),
@publicat     as varchar(25),
@edit		  as varchar(25)

 AS
insert into tbl_vat_mast(comp_code,userid,vat_description,vat_rate,vat_from_date,vat_to_date,vat_gross_type,vat_code,vat_order_no,Creation_Datetime,PUBLICATION, EDITION)
values(@comp_code,@userid,@vat_description,@vat_rate,@vat_from_date,@vat_to_date,@vat_gross_type,@vat_code,@vat_order_no,getdate(),@publicat,@edit)






USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[Vat_Exe]    Script Date: 03/06/2012 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE   [dbo].[Vat_Exe]
@comp_code as varchar(8),
@userid as varchar(8),
@vat_description as varchar(50),
@vat_rate as varchar(50),
@vat_from_date as  datetime,
@vat_to_date as datetime,
@vat_gross_type as varchar(50),
@vat_code as varchar(50)=null,
@vat_order_no as varchar(50)

AS



declare @query  as   varchar(1000)

--set @query='insert into #tbl_vat_mast select comp_code,userid,vat_description,vat_rate,    vat_from_date   ,   vat_to_date, vat_gross_type,vat_code,vat_order_no from tbl_vat_mast  where comp_code='''+@comp_code+''''
set @query='select comp_code,userid,vat_description,vat_rate,convert(varchar(10) ,vat_from_date,101)  vat_from_date  ,   convert(varchar (10) ,vat_to_date,101) vat_to_date, vat_gross_type,vat_code,vat_order_no,PUBLICATION,EDITION from tbl_vat_mast  where comp_code='''+@comp_code+''''

if(@vat_description<>'0')
begin
set @query=@query+'and vat_description = '''+@vat_description+''''
end
if(@vat_rate <>  '')
begin
set @query= @query+' and  vat_rate like  ''%'+@vat_rate+'%'''
end
if(@vat_from_date <> '')
begin
set @query=@query+ ' and  vat_from_date like  ''%'+cast(@vat_from_date as varchar)+'%'''
end
if(@vat_to_date <> '')
begin
set @query=@query+ ' and  vat_to_date like  ''%'+cast(@vat_to_date as varchar)+'%'''
end

if(@vat_gross_type <>'0')
begin
set @query=@query+ ' and vat_gross_type =  '''+@vat_gross_type+''''
end



if(@vat_order_no <> '')
begin
set @query=@query+ ' and vat_order_no like  ''%'+@vat_order_no+'%'''
end

print(@query)
exec(@query)



--select   comp_code,userid,vat_description,vat_rate,    convert(varchar(10) ,vat_from_date,101)  vat_from_date  ,   convert(varchar (10) ,vat_to_date,101) vat_to_date, vat_gross_type,vat_code,vat_order_no  from #tbl_vat_mast

--drop table #tbl_vat_mast





@@@@@@@@@@@@@@@@@@@@@@@@@@@@ tax rate ankit  06 march @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@



-----------start issue-6198------06-03-2012--------------------------


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER procedure  [dbo].[get_adagenc_bysubcode]

	@pcompcode                                VARCHAR(4000) ,
	@pagsubcode                               VARCHAR(4000) 
 
AS 
			SELECT *
			FROM  agency_mast 
			WHERE	 (Comp_Code = @pcompcode or @pcompcode ='')
			 
			 
			 AND	(SUB_Agency_Code  = @pagsubcode or @pagsubcode ='')


-----------End issue-6198------06-03-2012--------------------------
/*******************************************************************agency bind*****************/

ALTER PROCEDURE [dbo].[bindagencyfromadd]
@compcode          as varchar(8),
@userid            as varchar(8),
@agency            as varchar(1000),
@pubcenter         as varchar(200),
@p_agencyaddress   as varchar(1000)
 
 AS
 
 SET CONCAT_NULL_YIELDS_NULL OFF

if @pubcenter = '0' or @pubcenter is null  or @pubcenter =''
begin 
		select  distinct  code_subcode,Agency_Name as agency_name,(select City_Name from  city_mst where Comp_Code=@compcode and City_Code=agency_mast.City_Code)+'-'+Add1+'-'+Add2+'-'+Add3+Street
        AS CITYNAME from Agency_mast where Comp_Code=@compcode and
        isnull((SELECT top 1 status_name FROM STATUS_DETAIL WHERE agency_code + agency_subcat_code = AGENCY_MAST.code_subcode  AND getdate() between FROM_DATE and TO_DATE),'AC0')='AC0'
        and Agency_Name+Add1+Add2+Add3 like '%'+@p_agencyaddress+'%'  order by Agency_Name 
end
else
begin
		select  distinct  code_subcode,Agency_Name as agency_name,(select City_Name from  city_mst where Comp_Code=@compcode and City_Code=agency_mast.City_Code)+'-'+Add1+'-'+Add2+'-'+Add3+Street
        AS CITYNAME from Agency_mast where Comp_Code=@compcode and
        isnull((SELECT top 1 status_name FROM STATUS_DETAIL WHERE agency_code + agency_subcat_code = AGENCY_MAST.code_subcode  AND getdate() between FROM_DATE and TO_DATE),'AC0')='AC0'
        and Agency_Name+Add1+Add2+Add3 like '%'+@p_agencyaddress+'%' and Dist_Code=(select Dist_Code from branch_mst where Branch_Code=@pubcenter) 
        order by Agency_Name ;
end

SET CONCAT_NULL_YIELDS_NULL on
/*******************************************************************agency bind*****************/

/************************ankit***************6887**************************** *****************/
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[CityMstModify]    Script Date: 03/12/2012 11:26:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[CityMstModify]

@compcode as varchar(8),
@CityCode as varchar(8),
@CityName as varchar(30),
@Alias as varchar(30),
@DistrictName as varchar(15),
@StateName as varchar(30),
@ZoneName as varchar(8),
@CountryName as varchar(8), 
@CitySTD as varchar(10),
@Region as varchar(10)
--@userid as varchar(8)

AS

declare @query as varchar (1000)

declare @query1 as varchar (1000)

set @query='update city_mst set  City_Name='''+@CityName+''', City_Alias='''+@Alias+''', Country_Code='''+@CountryName+''', State_Code='''+@StateName+''', Zone_Code='''+@ZoneName+''', Dist_Code='''+@DistrictName+''', STD_Code='''+@CitySTD+''', Region_Code='''+@Region+'''  where  Comp_Code='''+@compcode+'''  and City_Code='''+@CityCode+''''

set @query1='update CITY_MASTTEMP set  City_Name='''+@CityName+''', City_Alias='''+@Alias+''', Country_Code='''+@CountryName+''', State_Code='''+@StateName+''', Zone_Code='''+@ZoneName+''', Dist_Code='''+@DistrictName+''', STD_Code='''+@CitySTD+''', Region_Code='''+@Region+'''  where  Comp_Code='''+@compcode+'''  and City_Code='''+@CityCode+''''

exec(@query)
exec(@query1)







USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[CityMstInsert]    Script Date: 03/12/2012 11:29:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[CityMstInsert]

@compcode as varchar(8),
@CityCode as varchar(8),
@CityName as varchar(30),
@Alias as varchar(30),
@CountryName as varchar(8), 
@StateName as varchar(30),
@ZoneName as varchar(8),
@DistrictName as varchar(15),
@CitySTD as varchar(10),
@Region as varchar(10),
@userid as varchar(8)


AS

declare @query as varchar (1000)

set @query='insert into city_mst(Comp_Code, City_Code, City_Name, City_Alias, Country_Code, State_Code, Zone_Code, Dist_Code, STD_Code, Region_Code, UserId,Creation_Datetime) values('''+@compcode+''', '''+@CityCode+''', '''+@CityName+''', '''+@Alias+''', '''+@CountryName+''', '''+@StateName+''', '''+@ZoneName+''', '''+@DistrictName+''', '''+@CitySTD+''', '''+@Region+''', '''+@userid+''',getdate())'

print(@query)
exec(@query)







USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[CityMastDelete]    Script Date: 03/12/2012 11:32:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER PROCEDURE [dbo].[CityMastDelete]

@compcode as varchar(8),
@CityCode as varchar(8),
@userid as varchar(8)


AS

delete from  city_mst  where  City_Code=@CityCode and Comp_Code=@compcode and UserId=@userid

delete from CITY_MASTTEMP where  City_Code=@CityCode and Comp_Code=@compcode and UserId=@userid

delete from city_branch_mast where city_code=@CityCode and COMPCODE=@compcode;




/************************ankit***************6887**************************** *****************/

/************************ankit***************6889**************************** *****************/

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[insertcurrencymst]    Script Date: 03/12/2012 11:40:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE  [dbo].[insertcurrencymst]
@compcode as varchar(10),
@userid as varchar(10),
@txtcurrcode as varchar(10),
@txtcurrname as varchar(30),
@txtalias as varchar(30),
@drpcountryname as varchar(10),
@SYMBOL_P AS VARCHAR(5)


 AS

insert into CURR_MAST(Comp_Code,Curr_Code,Curr_Name,Curr_Alias,Country_Code,UserId,Creation_Datetime,SYMBOL)
values(@compcode,@txtcurrcode,@txtcurrname,@txtalias,@drpcountryname,@userid,getdate(),@SYMBOL_P)






USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[modifycurrmast]    Script Date: 03/12/2012 11:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE  [dbo].[modifycurrmast]
@compcode as varchar(10),
@userid as varchar(10),
@txtcurrcode as varchar(10),
@txtcurrname as varchar(30),
@txtalias as varchar(30),
@drpcountryname as varchar(10),
@SYMBOL_P AS VARCHAR(5)


 AS

--insert into CURR_MAST(Comp_Code,Curr_Code,Curr_Name,Curr_Alias,Country_Code,UserId)values(@compcode,@txtcurrcode,@txtcurrname,@txtalias,@drpcountryname,@userid)

update CURR_MAST set Curr_Name=@txtcurrname,Curr_Alias=@txtalias,Country_Code=@drpcountryname,SYMBOL=@SYMBOL_P where comp_code=@compcode  and Curr_Code=@txtcurrcode --and userid=@userid

--update TEMP_CURR_MAST set Curr_Name=@txtcurrname,Curr_Alias=@txtalias,Country_Code=@drpcountryname where comp_code=@compcode and userid=@userid and Curr_Code=@txtcurrcode





USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[deletecurrmast]    Script Date: 03/12/2012 11:54:12 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER PROCEDURE  [dbo].[deletecurrmast]

@code as varchar(8),
@compcode as varchar(8),
@userid as varchar(8)


 AS

delete from CURR_MAST where Comp_Code=@compcode  and Curr_Code=@code --and UserId=@userid

--delete from TEMP_CURR_MAST where Comp_Code=@compcode and UserId=@userid and Curr_Code=@code

delete from CURR_CONV_DET where Comp_Code=@compcode and Curr_Code=@code --and UserId=@userid


/************************ankit***************6889**************************** *****************/


/********************************************************6932***************/
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
@p_bookingapproval as varchar(5)


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
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=@p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=@p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=@p_CURRENCY_MEASUREMENT,BOOK_AUDIT_REQ_AFTER_MOD =@p_bookingapproval
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)







































/******************************************************************************/



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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,Space_area,BOOK_AUDIT_REQ_AFTER_MOD 
           FROM PREFERRENCES
          WHERE comp_code = @compcode



/********************************************************6932***************/
/***********************ankit*********************************6917***************/
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[websp_statusbind]    Script Date: 03/13/2012 10:03:16 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER PROCEDURE  [dbo].[websp_statusbind]

@agencode as varchar(25),

@userid as varchar(10),
@compcode as varchar(10),
@hiddenccode as varchar(10)





AS
declare @query as varchar(900)


--insert into Agency_mast(Comp_Code,Agency_Type_Code,Agency_Cat_Code,Agency_SubCat_Code,Agency_Code,Agency_Name,Agency_Alias,Agency_HO,Add1,Street,City_Code,Zip,Dist_Code,State_Code,Country_Code,Phone,Fax,EmailID,URL,Buss_Start_Date,Enroll_Date,MRV_Ref_No,No_of_VTS,Credit_Days ,PAN_No,TAN_No,ST_ACC_No,Pay_Mode_Code,Agency_Status,Status_Reason,Remarks,UserID,Creation_Datetime,SUB_Agency_HO,SUB_Agency_Code) values (@compcode,@agencytype,@agentcategory,@agentcategory2,@agentcode,@agentname,@alias,@agencyho,@address,@street,@city,@zip,@district,@state,@country,@phone,@mail,@fax,@url,@bussinessstartdate,@enrolldate,@mrerefferenceno,@novts,@credit,@pan,@tan,@stacno,@paymode,@statusdrp,@status,@remarks,@userid,@statusdate,@subagencyho,@agencycode)

--set @query='select Eff_from_date,Eff_Till_date,Comm_rate,Discount,comm_code  from comm_details where userid='''+@userid+''' and AGENCY_CODE='''+@agencode+''''

--set @query='select Status_name,From_date,to_date,stat_code,agency_code from status_detail  where userid='''+@userid+''' and AGENCY_CODE='''+@agencode+'''  and comp_code='''+@compcode+''''

set @query='select  stat_code, Status_name,convert(varchar,From_date,101) as From_date,convert(varchar,to_date,101) as  to_date,circular_no,stat_code,agency_code,remarks,ATTACHMENT from status_detail  where userid='''+@userid+''' and AGENCY_CODE='''+@agencode+''' and stat_code='''+@hiddenccode+'''  and comp_code='''+@compcode+''''  



print(@query)
exec(@query)



/***********************ankit*********************************6917***************/
/***************************************mimoh**********6944*********************/

create PROCEDURE rpt_deal_detail
    @pcompcode       as	varchar(20),
    @padtype         as	varchar(20),
    @padcat          as	varchar(50),
    @pdeal_type      as	varchar(50),
    @pag_maincode    as	varchar(50),
    @pag_subcode     as	varchar(50),
    @pclient         as	varchar(50),
    @papproved       as	varchar(50),
    @ppackage        as	varchar(50),
    @pratecode       as	varchar(50),
    @pfromdt         as	datetime,
    @ptilldt         as	datetime,
    @pdate_flag      as	varchar(20),
    @puserid         as	varchar(20),
    @pdateformat     as	varchar(20),
    @pextra1         as	varchar(200),
    @pextra2         as	varchar(200),
    @pextra3         as	varchar(200),
    @pextra4         as	varchar(200),
    @pextra5         as	varchar(200),
    @pextra6         as	varchar(200),
    @pextra7         as	varchar(200),
    @pextra8         as	varchar(200),
    @pextra9         as	varchar(200),
    @pextra10        as	varchar(200)

AS
begin
	If @padtype='' Begin
		set @padtype =null
	End	

	If @padcat='' Begin
		set @padcat =null
	End    
	If @pdeal_type='' Begin
		set @pdeal_type =null
	End
	If @pag_maincode='' Begin
		set @pag_maincode =null
	End
	If @pag_subcode='' Begin
		set @pag_subcode =null
	End
	If @pclient='' Begin
		set @pclient =null
	End
	If @papproved='' Begin
		set @papproved =null
	End
	If @ppackage='' Begin
		set @ppackage =null
	End

	If @pratecode='' Begin
		set @pratecode =null
	End
	If @papproved='' Begin
		set @papproved =null
	End
	
	If @pdate_flag='' Begin
		set @pdate_flag =null
	End
	
	If @puserid='' Begin
		set @puserid =null
	End

    select (select "Comp_Name" from comp_mst where "Comp_Code"=m."Comp_code") as "COMP_NAME",m."Deal_No" as "DEAL_NO",m."deal_name" as "DEAL_NAME",m."deal_type" as "DEAL_TYPE",
    CASE @pdateformat WHEN 'mm/dd/yyyy' THEN CONVERT(varchar(20),m."From_date",101)
					WHEN 'dd/mm/yyyy' THEN CONVERT(varchar(10),m."From_date",103)
					WHEN 'yyyy/mm/dd' THEN CONVERT(varchar(10),m."From_date",111)  END AS "FROM_DATE" ,
    CASE @pdateformat WHEN 'mm/dd/yyyy' THEN CONVERT(varchar(20),m."Till_date",101)
					WHEN 'dd/mm/yyyy' THEN CONVERT(varchar(10),m."Till_date",103)
					WHEN 'yyyy/mm/dd' THEN CONVERT(varchar(10),m."Till_date",111)  END AS "TILL_DATE" ,
    m."Total_val" as "TOTAL_VALUE",m."Total_volu" as "TOTAL_VOLUM",
    m."Agency_code" as "AGENCY_CODE",m."Sub_Agency_Code" as "AGENCY_SUB_CODE",
    (select "Agency_Name" from agency_mast where agency_mast."Comp_Code"=m."Comp_code" and agency_mast."Agency_Code"=m."Agency_code" and agency_mast."SUB_Agency_Code"=m."Sub_Agency_Code") as "AGENCY_NAME",
    m."Client_code" as "CLIENT_CODE",(select "Cust_Name"  from cust_mast where cust_mast."Cust_Code"=m."Client_code") as "CLIENT_NAME",
    d."packagecode" as "PACKAGECODE",m."Card_rate" as "CARD_RATE",m."premium_code" as "PREMIUM_CODE",m."Deal_rate" as "CONTRACT_RATE",
    d."DISCPER" as "DISCPER",d."DISCTYPE" as "DISCTYPE",d."INSERTION" as "INSERTION",d."SIZEFROM" as "MIN_SIZE",
    d."SIZETO" as "MAX_SIZE",d."valuefrom" as "VALUEFROM",d."valueto" as "VALUETO",d."Rate_code" as "RATE_CODE",d."REMARKS" as "REMARKS",d."approved" as "APPROVED"
    from contract_mast m,contract_detail d
    where m."Comp_code"=d."comp_code" and m."Comp_code"=@pcompcode and m."Deal_No"=d."deal_code" and m."deal_type"=isnull(@pdeal_type,m."deal_type") and
    m.contractdate between @pfromdt and @ptilldt and (d."ADTYPE"=@padtype or @padtype is null) and (d."Advcategory"=@padcat or @padcat is null) and
    (m."Agency_code" = @pag_maincode or @pag_maincode is null) and (m."Sub_Agency_Code"=@pag_subcode or @pag_subcode is null) and
    (m."Client_code"=@pclient or @pclient is null) and (d."packagecode"=@ppackage or @ppackage is null) and
    (d."approved"=@papproved or @papproved is null) and (d."Rate_code"=@pratecode or @pratecode is null);
   
END

/**************************6944*************mimoh*******************************/

/**************************6940*************ankit*******************************/
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[currbindpreferpgld]    Script Date: 03/13/2012 17:06:39 ******/
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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,Space_area,BOOK_AUDIT_REQ_AFTER_MOD,EDITABLE_AGENCY_COMM
           FROM PREFERRENCES
          WHERE comp_code = @compcode







USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[wesp_updatedate1]    Script Date: 03/13/2012 16:57:58 ******/
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
@p_bookingapproval as varchar(5),
@p_EDITABLE_AGENCY_COMM as varchar(1)


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
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=@p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=@p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=@p_CURRENCY_MEASUREMENT,BOOK_AUDIT_REQ_AFTER_MOD =@p_bookingapproval,EDITABLE_AGENCY_COMM =@p_EDITABLE_AGENCY_COMM
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)

/**************************6940*************ankit*******************************/

/***********************************MIMOH RO REPORT******************************************************************/
ALTER  PROCEDURE Ro_Report
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
		if @pro_doc_status ='0' begin
			set @query1=@query1+' and isnull(a.RODOCSTATUS,''0'') = '''+@pro_doc_status+''' '
		End	
		Else begin
			set @query1=@query1+' and a.RODOCSTATUS = '''+@pro_doc_status+''' '
		END
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










/***********************************MIMOH RO REPORT******************************************************************/ 

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 13/3/2012 @@Agency_merging @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


//=========================================Begin Procedure==================================//

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
@subedidata as varchar(5000)
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
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER  PROCEDURE [dbo].[insert_edition_details](
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
declare @uomdesc     varchar(50)
declare @v_edtn_type varchar(50)
if (@p_str <> null or @p_str <> '') begin
 
    set @tmpStr= @p_str
   -- set @l_str = @p_str
  
    create table #tempsplitstr(param_str varchar(500))
    insert into #tempsplitstr select edition_name from dbo.fn_SplitField(@p_str,'$')
    
    declare c1 cursor for select param_str from #tempsplitstr 
    
    OPEN c1
    FETCH next from c1 INTO @spli_str
    WHILE @@fetch_status=0 begin
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
        
        if @insstatusm = 'cancel' Begin
        set @l_status =@insstatusm
        end
        else Begin
        set @l_status =@l_str
        end
        
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
 else begin
    
    select @pubcode=Pub_Code,@editioncode=Edition_Code,@v_edtn_type ="Edition_Type" from edition_mast 
    where ltrim(Edition_Code)=ltrim(@editioncodem)
    
    select @uomdesc=UOM_DESC from uom_mast where "Uom_Code"=(select Uom_code from tbl_booking_mast_g 
            where cio_booking_id=@cioidm)
                
    -- insert into abctest values(pubcode,editioncode);
    -- select @sr_no=max(SRno)+1 from tbl_booking_subedition_g
    
    If @v_edtn_type='Main Edition' Begin
        select @combinname=Combin_Desc from combin_mast where Combin_Code=@pkgcode
        
        if(charindex('+',@combinname)>0 and @uomdesc='CD') Begin
            
            insert into tbl_booking_subedition_g(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,NO_INSERT,PAGE_NO)
            --select @compcodem,@cioidm,@insertidm,Pub_Code,Edition_Code,@insertdatem,@heightm,@widthm,@totaream,'booked',@receiptnom,@insertno,@pageno
            select @compcodem,@cioidm,@insertidm,Pub_Code,Edition_Code,@insertdatem,@heightm,@widthm,@totaream,@insstatusm,@receiptnom,@insertno,@pageno
            from edition_mast where  Pub_Code=@pubcode and City_Code=@editioncode and Edition_Type='Edition'
        End    
        Else begin
            insert into tbl_booking_subedition_g(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,NO_INSERT,PAGE_NO)
            --select @compcodem,@cioidm,@insertidm,Pub_Code,Edition_Code,@insertdatem,@heightm,@widthm,@totaream,'cancel',@receiptnom,@insertno,@pageno
            select @compcodem,@cioidm,@insertidm,Pub_Code,Edition_Code,@insertdatem,@heightm,@widthm,@totaream,@insstatusm,@receiptnom,@insertno,@pageno
            from edition_mast where  Pub_Code=@pubcode and City_Code=@editioncode and Edition_Type='Edition'
        end       
    End 
end
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER  PROCEDURE insert_edition_details_update(
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
declare @uomdesc     varchar(50)
declare @v_edtn_type varchar(50)
if (@p_str <> null or @p_str <> '') begin
 
    set @tmpStr= @p_str
   -- set @l_str = @p_str
  
    create table #tempsplitstr(param_str varchar(500))
    insert into #tempsplitstr select edition_name from dbo.fn_SplitField(@p_str,'$')
    
    declare c1 cursor for select param_str from #tempsplitstr 
    
    OPEN c1
    FETCH next from c1 INTO @spli_str
    WHILE @@fetch_status=0 begin
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
        
        if @insstatusm = 'cancel' Begin
        set @l_status =@insstatusm
        end
        else Begin
        set @l_status =@l_str
        end
        
        print(@l_date)
        -- set @tmpStr = substring(@tmpStr,CHARINDEX('$',@tmpStr)+1,len(@l_str))

        select @pubcode=Pub_Code,@editioncode=Edition_Code from edition_mast where Edition_Alias=@l_ed-- AND ROWNUM<=1;
        --select @sr_no=max(SRno)+1 from tbl_booking_subedition_g

        insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,PAGE_NO) 
        values(@compcodem,@cioidm,@insertidm,@pubcode,@editioncode,@l_date,@l_hight,@l_width,@l_size,@l_status,@receiptnom,@l_pageno)

        FETCH next from c1 INTO @spli_str
    end
    close c1
    deallocate c1
    drop table #tempsplitstr
 end
 else begin
    
    select @pubcode=Pub_Code,@editioncode=Edition_Code,@v_edtn_type ="Edition_Type" from edition_mast 
    where ltrim(Edition_Code)=ltrim(@editioncodem)
    
    select @uomdesc=UOM_DESC from uom_mast where "Uom_Code"=(select Uom_code from tbl_booking_mast_g 
            where cio_booking_id=@cioidm)
                
    -- insert into abctest values(pubcode,editioncode);
    -- select @sr_no=max(SRno)+1 from tbl_booking_subedition_g
    
    If @v_edtn_type='Main Edition' Begin
        select @combinname=Combin_Desc from combin_mast where Combin_Code=@pkgcode
        
        if(charindex('+',@combinname)>0 and @uomdesc='CD') Begin
            
            insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,NO_INSERT,PAGE_NO)
            --select @compcodem,@cioidm,@insertidm,Pub_Code,Edition_Code,@insertdatem,@heightm,@widthm,@totaream,'booked',@receiptnom,@insertno,@pageno
            select @compcodem,@cioidm,@insertidm,Pub_Code,Edition_Code,@insertdatem,@heightm,@widthm,@totaream,@insstatusm,@receiptnom,@insertno,@pageno
            from edition_mast where  Pub_Code=@pubcode and City_Code=@editioncode and Edition_Type='Edition'
        End    
        Else begin
            insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,NO_INSERT,PAGE_NO)
            --select @compcodem,@cioidm,@insertidm,Pub_Code,Edition_Code,@insertdatem,@heightm,@widthm,@totaream,'cancel',@receiptnom,@insertno,@pageno
            select @compcodem,@cioidm,@insertidm,Pub_Code,Edition_Code,@insertdatem,@heightm,@widthm,@totaream,@insstatusm,@receiptnom,@insertno,@pageno
            from edition_mast where  Pub_Code=@pubcode and City_Code=@editioncode and Edition_Type='Edition'
        end       
    End 
end
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//===========================================End of Script==================================//

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 13/3/2012 @@Agency_merging @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ankit 14/3/2012 @@CANCELLATION CHARGES @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[currbindpreferpgld]    Script Date: 03/14/2012 01:38:01 ******/
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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,Space_area,BOOK_AUDIT_REQ_AFTER_MOD,EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE
           FROM PREFERRENCES
          WHERE comp_code = @compcode











USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[wesp_updatedate1]    Script Date: 03/14/2012 01:35:02 ******/
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
@p_bookingapproval as varchar(5),
@p_EDITABLE_AGENCY_COMM as varchar(1),
@p_CANCELLATION_CHARGE as varchar(1)


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
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=@p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=@p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=@p_CURRENCY_MEASUREMENT,BOOK_AUDIT_REQ_AFTER_MOD =@p_bookingapproval,EDITABLE_AGENCY_COMM =@p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE =@p_CANCELLATION_CHARGE
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ankit 14/3/2012 @@CANCELLATION CHARGES @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


/************************************6963***********RATE MASTER UPDATE************************MIMOH *******************************/



CREATE OR REPLACE PACKAGE insertratemast
IS
   PROCEDURE insertratemast_p (
      compcode        IN   VARCHAR2,
      userid          IN   VARCHAR2,
      ratecodes        IN   VARCHAR2,
      adtype1          IN   VARCHAR2,
      rategroupcode   IN   VARCHAR2,
      adcategory      IN   VARCHAR2,
      currency        IN   VARCHAR2,
      adsubcategory   IN   VARCHAR2,
      package1        IN   VARCHAR2,
      packagedesc     IN   VARCHAR2,
      uom             IN   VARCHAR2,
      sizefrom        IN   NUMBER,
      sizeto          IN   NUMBER,
      consumption     IN   NUMBER,
      color           IN   VARCHAR2,
      colorchrty      IN   VARCHAR2,
      weekdrate       IN   NUMBER,
      weeminrate      IN   NUMBER,
      extweerate      IN   NUMBER,
      focusdarate     IN   NUMBER,
      focminrate      IN   NUMBER,
      focexrate       IN   NUMBER,
      validfromdate   IN   DATE,
      validtill       IN   DATE,
      remarks         IN   VARCHAR2,
      premiumval      IN   VARCHAR2,
      premium         IN   VARCHAR2,
      rateuniqueid    IN   VARCHAR2,
      weekendrate     IN   NUMBER,
      weekendmin      IN   NUMBER,
      weekendextra    IN   NUMBER,
      minadarea       IN   NUMBER,
      editionfrom     IN   NUMBER,
      editionto       IN   NUMBER,
      flramount       IN   NUMBER,
      flrdiscount     IN   NUMBER,
      scheme1          IN   VARCHAR2,
      adscat4         IN   VARCHAR2,
      adscat5         IN   VARCHAR2,
      adscat6         IN   VARCHAR2,
      frominsert      IN   NUMBER,
      toinsert        IN   NUMBER,
      agtype          IN   VARCHAR2,
      clientcat       IN   VARCHAR2,
      maxadarea       IN   NUMBER,
	  type1           IN VARCHAR2,
      agencycode      IN VARCHAR2,
      pubcenter       IN VARCHAR2,

      rate_sun        IN NUMBER,
      rate_mon        IN NUMBER,
      rate_tue        IN NUMBER,
      rate_wed        IN NUMBER,
      rate_thu        IN NUMBER,
      rate_fri        IN NUMBER,
      rate_sat        IN NUMBER,

      rate_sun_extra  IN NUMBER,
      rate_mon_extra  IN NUMBER,
      rate_tue_extra  IN NUMBER,
      rate_wed_extra  IN NUMBER,
      rate_thu_extra  IN NUMBER,
      rate_fri_extra  IN NUMBER,
      rate_sat_extra  IN NUMBER,
	  width_max       IN NUMBER,
      priority_m        in number,
      vat             IN   VARCHAR2,
      Adon1            IN   VARCHAR2,
      refrence        IN   VARCHAR2,
      p_cancellation IN VARCHAR2
   );
END insertratemast;
/





CREATE OR REPLACE PACKAGE BODY insertratemast
IS
   PROCEDURE insertratemast_p (
      compcode        IN   VARCHAR2,
      userid          IN   VARCHAR2,
      ratecodes        IN   VARCHAR2,
      adtype1          IN   VARCHAR2,
      rategroupcode   IN   VARCHAR2,
      adcategory      IN   VARCHAR2,
      currency        IN   VARCHAR2,
      adsubcategory   IN   VARCHAR2,
      package1        IN   VARCHAR2,
      packagedesc     IN   VARCHAR2,
      uom             IN   VARCHAR2,
      sizefrom        IN   NUMBER,
      sizeto          IN   NUMBER,
      consumption     IN   NUMBER,
      color           IN   VARCHAR2,
      colorchrty      IN   VARCHAR2,
      weekdrate       IN   NUMBER,
      weeminrate      IN   NUMBER,
      extweerate      IN   NUMBER,
      focusdarate     IN   NUMBER,
      focminrate      IN   NUMBER,
      focexrate       IN   NUMBER,
      validfromdate   IN   DATE,
      validtill       IN   DATE,
      remarks         IN   VARCHAR2,
      premiumval      IN   VARCHAR2,
      premium         IN   VARCHAR2,
      rateuniqueid    IN   VARCHAR2,
      weekendrate     IN   NUMBER,
      weekendmin      IN   NUMBER,
      weekendextra    IN   NUMBER,
      minadarea       IN   NUMBER,
      editionfrom     IN   NUMBER,
      editionto       IN   NUMBER,
      flramount       IN   NUMBER,
      flrdiscount     IN   NUMBER,
      scheme1          IN   VARCHAR2,
      adscat4         IN   VARCHAR2,
      adscat5         IN   VARCHAR2,
      adscat6         IN   VARCHAR2,
      frominsert      IN   NUMBER,
      toinsert        IN   NUMBER,
      agtype          IN   VARCHAR2,
      clientcat       IN   VARCHAR2,
      maxadarea       IN   NUMBER,
	  type1           IN VARCHAR2,
      agencycode      IN VARCHAR2,
      pubcenter       IN VARCHAR2,

      rate_sun        IN NUMBER,
      rate_mon        IN NUMBER,
      rate_tue        IN NUMBER,
      rate_wed        IN NUMBER,
      rate_thu        IN NUMBER,
      rate_fri        IN NUMBER,
      rate_sat        IN NUMBER,

      rate_sun_extra  IN NUMBER,
      rate_mon_extra  IN NUMBER,
      rate_tue_extra  IN NUMBER,
      rate_wed_extra  IN NUMBER,
      rate_thu_extra  IN NUMBER,
      rate_fri_extra  IN NUMBER,
      rate_sat_extra  IN NUMBER,
	  width_max  IN NUMBER,
      priority_m    in number,
      vat          IN   VARCHAR2,
       Adon1            IN   VARCHAR2,
      refrence        IN   VARCHAR2,
      p_cancellation IN VARCHAR2
   )
   AS
   BEGIN
        if(type1='company')then
          INSERT INTO rate_mast
                      ("Comp_code", "Rate_Mast_Code", "Adv_Type_Code",
                       "Adv_Cat_Code", "Adv_subcat_code", "Rate_Gr_Code",
                       "Currency", "combin_desc", "Combin_Code", "Uom",
                       "Valid_From", "Valid_To", "Size_To", "Size_From",
                       "consumption_Per", "Color", "Col_chr_typ", "Remarks",
                       "Week_Day_Rate", "Week_min_rate", "Week_Extra_Rate",
                       "Focus_Day_Rate", "Focus_min_rate", "Focus_extra_rate",
                       "userid", "Premium", "Premium_Charges", "rateuniqueid",
                       "weekend_rate", "weekend_min_rate", "weekend_extra",
                       "min_ad_area", "Edition_from", "Edition_to",
                       "floor_amount", "floor_discount", "Scheme_Name",
                       "Ad_Subcat4", "Ad_Subcat5", "Ad_subcat6",
                       "From_insertion", "To_insertion", "Agency_type",
                       "Client_cat" ,"Max_Area" ,"Creation_DateTime","pub_center",
                       sun_rate,mon_rate,tue_rate,wed_rate,thu_rate,fri_rate,sat_rate,
                       sun_rate_extra,mon_rate_extra,tue_rate_extra,wed_rate_extra,thu_rate_extra,fri_rate_extra,sat_rate_extra,maxwidth ,PRIORITY,VAT_DETAIL,ADON, REF_ID,CANCELLATION_CHARGES              ---, "Max_ad_area"
                      )
               VALUES (compcode, ratecodes, adtype1,
                       adcategory, adsubcategory, rategroupcode,
                       currency, packagedesc, package1, uom,
                       validfromdate, validtill, sizeto, sizefrom,
                       consumption, color, colorchrty, remarks,
                       weekdrate, weeminrate, extweerate,
                       focusdarate, focminrate, focexrate,
                       userid, premium, premiumval, rateuniqueid,
                       weekendrate, weekendmin, weekendextra,
                       minadarea, editionfrom, editionto,
                       flramount, flrdiscount, scheme1,
                       adscat4, adscat5, adscat6,
                       frominsert, toinsert, agtype,
                       clientcat  ,maxadarea ,sysdate,pubcenter,
                       rate_sun,rate_mon,rate_tue,rate_wed,rate_thu,rate_fri,rate_sat,
                       rate_sun_extra,rate_mon_extra,rate_tue_extra,rate_wed_extra,rate_thu_extra,rate_fri_extra,rate_sat_extra,width_max ,priority_m,vat,Adon1,refrence,p_cancellation                                --, maxadarea
                      );
        else
                INSERT INTO  agency_rate_mast
                      ("Comp_code", "Rate_Mast_Code", "Adv_Type_Code",
                       "Adv_Cat_Code", "Adv_subcat_code", "Rate_Gr_Code",
                       "Currency", "combin_desc", "Combin_Code", "Uom",
                       "Valid_From", "Valid_To", "Size_To", "Size_From",
                       "consumption_Per", "Color", "Col_chr_typ", "Remarks",
                       "Week_Day_Rate", "Week_min_rate", "Week_Extra_Rate",
                       "Focus_Day_Rate", "Focus_min_rate", "Focus_extra_rate",
                       "userid", "Premium", "Premium_Charges", "rateuniqueid",
                       "weekend_rate", "weekend_min_rate", "weekend_extra",
                       "min_ad_area", "Edition_from", "Edition_to",
                       "floor_amount", "floor_discount", "Scheme_Name",
                       "Ad_Subcat4", "Ad_Subcat5", "Ad_subcat6",
                       "From_insertion", "To_insertion", "Agency_type",
                       "Client_cat" ,"Max_Area" ,"Agency_code","Creation_DateTime"                           ---, "Max_ad_area"
                      )
               VALUES (compcode, ratecodes, adtype1,
                       adcategory, adsubcategory, rategroupcode,
                       currency, packagedesc, package1, uom,
                       validfromdate, validtill, sizeto, sizefrom,
                       consumption, color, colorchrty, remarks,
                       weekdrate, weeminrate, extweerate,
                       focusdarate, focminrate, focexrate,
                       userid, premium, premiumval, rateuniqueid,
                       weekendrate, weekendmin, weekendextra,
                       minadarea, editionfrom, editionto,
                       flramount, flrdiscount, scheme1,
                       adscat4, adscat5, adscat6,
                       frominsert, toinsert, agtype,
                       clientcat  ,maxadarea  ,agencycode,sysdate                                 --, maxadarea
                      );

        end if;

      COMMIT;
   END insertratemast_p;
END insertratemast;
/

/***************************************************************************************/

CREATE OR REPLACE PACKAGE modifyratecode
IS
   PROCEDURE modifyratecode_p (
      compcode        IN   VARCHAR2,
      userid          IN   VARCHAR2,
      ratecodes        IN   VARCHAR2,
      adtype1          IN   VARCHAR2,
      rategroupcode   IN   VARCHAR2,
      adcategory      IN   VARCHAR2,
      currency        IN   VARCHAR2,
      adsubcategory   IN   VARCHAR2,
      package1        IN   VARCHAR2,
      packagedesc     IN   VARCHAR2,
      uom             IN   VARCHAR2,
      sizefrom        IN   NUMBER,
      sizeto          IN   NUMBER,
      consumption     IN   NUMBER,
      color           IN   VARCHAR2,
      colorchrty      IN   VARCHAR2,
      weekdrate       IN   NUMBER,
      weeminrate      IN   NUMBER,
      extweerate      IN   NUMBER,
      focusdarate     IN   NUMBER,
      focminrate      IN   NUMBER,
      focexrate       IN   NUMBER,
      validfromdate   IN   DATE,
      validtill       IN   DATE,
      remarks         IN   VARCHAR2,
      premiumval      IN   VARCHAR2,
      premium         IN   VARCHAR2,
      rateuniqueid    IN   VARCHAR2,
      weekendrate     IN   NUMBER,
      weekendmin      IN   NUMBER,
      weekendextra    IN   NUMBER,
      editionto       IN   NUMBER,
      editionfrom     IN   NUMBER,
      flramount       IN   NUMBER,
      flrdiscount     IN   NUMBER,
      scheme1          IN   VARCHAR2,
      minadarea       IN   NUMBER,
      adscat4         IN   VARCHAR2,
      adscat5         IN   VARCHAR2,
      adscat6         IN   VARCHAR2,
      frominsert      IN   NUMBER,
      toinsert        IN   NUMBER,
      agtype          IN   VARCHAR2,
      clientcat       IN   VARCHAR2,
      max_area      IN   NUMBER,
      type1 in varchar2,
      agencycode in varchar2,
      rate_sun in NUMBER,
      rate_mon in NUMBER,
      rate_tue in NUMBER,
      rate_wed in NUMBER,
      rate_thu in NUMBER,
      rate_fri in NUMBER,
      rate_sat in NUMBER,

      rate_sun_extra in NUMBER,
      rate_mon_extra in NUMBER,
      rate_tue_extra in NUMBER,
      rate_wed_extra in NUMBER,
      rate_thu_extra in NUMBER,
      rate_fri_extra in NUMBER,
      rate_sat_extra in NUMBER,
	  width_max  IN NUMBER,
      priority_m    in number,
      vat          IN   VARCHAR2,
 Adon1            IN   VARCHAR2,
      refrence        IN   VARCHAR2,
      p_cancellation         IN   VARCHAR2
   );
END modifyratecode;
/




CREATE OR REPLACE PACKAGE BODY modifyratecode
IS
   PROCEDURE modifyratecode_p (
      compcode        IN   VARCHAR2,
      userid          IN   VARCHAR2,
      ratecodes        IN   VARCHAR2,
      adtype1          IN   VARCHAR2,
      rategroupcode   IN   VARCHAR2,
      adcategory      IN   VARCHAR2,
      currency        IN   VARCHAR2,
      adsubcategory   IN   VARCHAR2,
      package1        IN   VARCHAR2,
      packagedesc     IN   VARCHAR2,
      uom             IN   VARCHAR2,
      sizefrom        IN   NUMBER,
      sizeto          IN   NUMBER,
      consumption     IN   NUMBER,
      color           IN   VARCHAR2,
      colorchrty      IN   VARCHAR2,
      weekdrate       IN   NUMBER,
      weeminrate      IN   NUMBER,
      extweerate      IN   NUMBER,
      focusdarate     IN   NUMBER,
      focminrate      IN   NUMBER,
      focexrate       IN   NUMBER,
      validfromdate   IN   DATE,
      validtill       IN   DATE,
      remarks         IN   VARCHAR2,
      premiumval      IN   VARCHAR2,
      premium         IN   VARCHAR2,
      rateuniqueid    IN   VARCHAR2,
      weekendrate     IN   NUMBER,
      weekendmin      IN   NUMBER,
      weekendextra    IN   NUMBER,
      editionto       IN   NUMBER,
      editionfrom     IN   NUMBER,
      flramount       IN   NUMBER,
      flrdiscount     IN   NUMBER,
      scheme1          IN   VARCHAR2,
      minadarea       IN   NUMBER,
      adscat4         IN   VARCHAR2,
      adscat5         IN   VARCHAR2,
      adscat6         IN   VARCHAR2,
      frominsert      IN   NUMBER,
      toinsert        IN   NUMBER,
      agtype          IN   VARCHAR2,
      clientcat       IN   VARCHAR2,
      max_area      IN   NUMBER,
      type1 in varchar2,
      agencycode in varchar2,
      rate_sun in NUMBER,
      rate_mon in NUMBER,
      rate_tue in NUMBER,
      rate_wed in NUMBER,
      rate_thu in NUMBER,
      rate_fri in NUMBER,
      rate_sat in NUMBER,

      rate_sun_extra in NUMBER,
      rate_mon_extra in NUMBER,
      rate_tue_extra in NUMBER,
      rate_wed_extra in NUMBER,
      rate_thu_extra in NUMBER,
      rate_fri_extra in NUMBER,
      rate_sat_extra in NUMBER,
	  width_max  IN NUMBER,
      priority_m    in number,
      vat          IN   VARCHAR2,
       Adon1            IN   VARCHAR2,
      refrence        IN   VARCHAR2,
      p_cancellation         IN   VARCHAR2
   )
   AS
   BEGIN 
  
      UPDATE rate_mast
         SET "Adv_Type_Code" = adtype1,
             "Adv_Cat_Code" = adcategory,
             "Adv_subcat_code" = adsubcategory,
             "Rate_Gr_Code" = rategroupcode,
             "Currency" = currency,
             "combin_desc" = packagedesc,
             "Combin_Code" = package1,
             "Uom" = uom,
             "Valid_From" = validfromdate,
             "Valid_To" = validtill,
             "Size_To" = sizeto,
             "Size_From" = sizefrom,
             "consumption_Per" = consumption,
             "Color" = color,
             "Col_chr_typ" = colorchrty,
             "Remarks" = remarks,
             "Week_Day_Rate" = weekdrate,
             "Week_min_rate" = weeminrate,
             "Week_Extra_Rate" = extweerate,
             "Focus_Day_Rate" = focusdarate,
             "Focus_min_rate" = focminrate,
             "Focus_extra_rate" = focexrate,
             "Premium" = premium,
             "Premium_Charges" = premiumval,
             "weekend_rate" = weekendrate,
             "weekend_min_rate" = weekendmin,
             "weekend_extra" = weekendextra,
             "Edition_from" = editionfrom,
             "Edition_to" = editionto,
             "floor_amount" = flramount,
             "floor_discount" = flrdiscount,
             "Scheme_Name" = scheme1,
             "min_ad_area" = minadarea,
             "Ad_Subcat4" = adscat4,
             "Ad_Subcat5" = adscat5,
             "Ad_subcat6" = adscat6,
             "From_insertion" = frominsert,
             "To_insertion" = toinsert,
             "Agency_type" = agtype,
             "Client_cat" = clientcat,
			 "Max_Area"=max_area,
             sun_rate=rate_sun,
             mon_rate=rate_mon,
             tue_rate=rate_tue,
             wed_rate=rate_wed,
             thu_rate=rate_thu,
             fri_rate=rate_fri,
             sat_rate=rate_sat,

             sun_rate_extra=rate_sun_extra,
             mon_rate_extra=rate_mon_extra,
             tue_rate_extra=rate_tue_extra,
             wed_rate_extra=rate_wed_extra,
             thu_rate_extra=rate_thu_extra,
             fri_rate_extra=rate_fri_extra,
             sat_rate_extra=rate_sat_extra,
			 maxwidth=width_max,
             priority=priority_m,
            VAT_DETAIL=vat,
            CANCELLATION_CHARGES=p_cancellation 
             --ADON=Adon1, REF_ID=refrence
       --"max_ad_area" = maxadarea
      WHERE  "rateuniqueid" = rateuniqueid AND "Comp_code" = compcode;
	

	

      COMMIT;
   END modifyratecode_p;
END modifyratecode;
/
/*****************************************************************************/

CREATE OR REPLACE PACKAGE Executeratecode
IS
  TYPE T_Accounts_Cursor IS REF CURSOR;
  PROCEDURE executeratecode_p(
	compcode IN VARCHAR2,
	ratecodes IN VARCHAR2,
	adtype1 IN VARCHAR2,
	currency IN VARCHAR2,
	rategroup IN VARCHAR2,
	colorcode IN VARCHAR2,
	uomcode IN VARCHAR2,
	packagecode IN VARCHAR2,
	pubcenter IN VARCHAR2,
    adcate in varchar2, 
	P_Accounts OUT T_Accounts_cursor);

END  Executeratecode;
/


CREATE OR REPLACE PACKAGE BODY Executeratecode
IS
  PROCEDURE executeratecode_p(
	compcode IN VARCHAR2,
	ratecodes IN VARCHAR2,
	adtype1 IN VARCHAR2,
	currency IN VARCHAR2,
	rategroup IN VARCHAR2,
	colorcode IN VARCHAR2,
	uomcode IN VARCHAR2,
	packagecode IN VARCHAR2,
	pubcenter IN VARCHAR2,
     adcate in varchar2,
	P_Accounts OUT T_Accounts_cursor)
 AS
 BEGIN
 	  --IF(type1='company')THEN
        OPEN P_Accounts FOR
	    --SELECT "Comp_code","Rate_Mast_Code","Adv_Type_Code","Adv_Cat_Code","Adv_subcat_code","Rate_Gr_Code","Currency","combin_desc","Combin_Code","Uom",TO_CHAR("Valid_From",'dd/mm/yyyy')AS "Valid_From" ,TO_CHAR("Valid_To",'dd/mm/yyyy') AS "Valid_To" ,"Size_To","Size_From","consumption_Per","Color","Col_chr_typ","Remarks","Week_Day_Rate","Week_min_rate","Week_Extra_Rate","Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid","Premium","Premium_Charges","weekend_rate","weekend_min_rate","weekend_extra","chksolo","min_ad_area","Edition_from","Edition_to","floor_amount","floor_discount",(SELECT "Scheme_Code" FROM SCHEME_MASTER WHERE "scheme_id"=RATE_MAST."Scheme_Name") AS "Scheme_Name","Ad_Subcat4","Ad_Subcat5","Ad_subcat6","From_insertion","To_insertion","Agency_type","Client_cat","Max_Area","rateuniqueid","pub_center",sun_rate,mon_rate,tue_rate,wed_rate,thu_rate,fri_rate,sat_rate,sun_rate_extra,mon_rate_extra,tue_rate_extra,wed_rate_extra,thu_rate_extra,fri_rate_extra,sat_rate_extra,maxwidth FROM RATE_MAST
        SELECT "Comp_code","Rate_Mast_Code","Adv_Type_Code","Adv_Cat_Code","Adv_subcat_code","Rate_Gr_Code","Currency","combin_desc","Combin_Code","Uom","Valid_From","Valid_To","Size_To","Size_From","consumption_Per","Color","Col_chr_typ","Remarks","Week_Day_Rate","Week_min_rate","Week_Extra_Rate","Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid","Premium","Premium_Charges","weekend_rate","weekend_min_rate","weekend_extra","chksolo","min_ad_area","Edition_from","Edition_to","floor_amount","floor_discount",(SELECT "Scheme_Code" FROM SCHEME_MASTER WHERE "scheme_id"=RATE_MAST."Scheme_Name") AS "Scheme_Name","Ad_Subcat4","Ad_Subcat5","Ad_subcat6","From_insertion","To_insertion","Agency_type","Client_cat","Max_Area","rateuniqueid","pub_center",sun_rate,mon_rate,tue_rate,wed_rate,thu_rate,fri_rate,sat_rate,sun_rate_extra,mon_rate_extra,tue_rate_extra,wed_rate_extra,thu_rate_extra,fri_rate_extra,sat_rate_extra,maxwidth,(select "Combin_Desc" from combin_mast where "Combin_Code"=Rate_Mast."Combin_Code") as "desc",PRIORITY,VAT_DETAIL,ADON, REF_ID,CANCELLATION_CHARGES FROM RATE_MAST
	    WHERE ("Comp_code" = compcode OR compcode IS NULL)
	    AND ("Rate_Mast_Code" = ratecodes  OR ratecodes IS NULL)
	    AND ("Adv_Type_Code" = adtype1  OR adtype1 IS NULL)
        AND ("Adv_Cat_Code" = adcate  OR adcate IS NULL)
	    AND ("Currency" = currency  OR currency IS NULL)
	    AND ("Rate_Gr_Code" = rategroup  OR rategroup IS NULL)
	    AND ("Color" = colorcode  OR colorcode IS NULL)
	    AND ("Uom" = uomcode  OR uomcode IS NULL)
	    AND ("Combin_Code" = packagecode  OR packagecode IS NULL)
	    AND ("pub_center"=pubcenter OR pubcenter IS NULL);
      /*ELSE
	     OPEN P_Accounts FOR
    	 SELECT "Comp_code","Rate_Mast_Code","Adv_Type_Code","Adv_Cat_Code","Adv_subcat_code","Rate_Gr_Code","Currency","combin_desc","Combin_Code","Uom",TO_CHAR("Valid_From",'dd/mm/yyyy')AS "Valid_From" ,TO_CHAR("Valid_To",'dd/mm/yyyy') AS "Valid_To" ,"Size_To","Size_From","consumption_Per","Color","Col_chr_typ","Remarks","Week_Day_Rate","Week_min_rate","Week_Extra_Rate","Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid","Premium","Premium_Charges","weekend_rate","weekend_min_rate","weekend_extra","chksolo","min_ad_area","Edition_from","Edition_to","floor_amount","floor_discount","Scheme_Name","Ad_Subcat4","Ad_Subcat5","Ad_subcat6","From_insertion","To_insertion","Agency_type","Client_cat","Max_Area","Agency_code","rateuniqueid" FROM AGENCY_RATE_MAST
    	 WHERE ("Comp_code" = compcode OR compcode IS NULL)
    	 AND ("Rate_Mast_Code" LIKE ratecodes || '%' OR ratecodes IS NULL)
    	 AND ("Adv_Type_Code" LIKE adtype1 || '%' OR adtype1 IS NULL)
    	 AND ("Currency" LIKE currency || '%' OR currency IS NULL)
    	 AND ("Rate_Gr_Code" LIKE rategroup || '%' OR rategroup IS NULL)
    	 AND ("Color" LIKE colorcode || '%' OR colorcode IS NULL)
    	 AND ("Uom" LIKE uomcode || '%' OR uomcode IS NULL)
    	 AND ("Combin_Code" LIKE packagecode || '%' OR packagecode IS NULL);
      END IF;*/
END executeratecode_p;
END  Executeratecode;
/

/************************************6963***********RATE MASTER UPDATE************************MIMOH *******************************/



/****************mimoh pref**********************************************************/




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
@p_CANCELLATION_CHARGE as varchar(1)


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
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=@p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=@p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=@p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM =@p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE =@p_CANCELLATION_CHARGE
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)


/*******************************************************************************************/



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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,Space_area,EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE
           FROM PREFERRENCES
          WHERE comp_code = @compcode



































/****************mimoh pref**********************************************************/


/****************ankit 6938 **********************************************************/

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[executebooking_new1]    Script Date: 03/14/2012 03:39:32 ******/
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
  TRANSLATION_PREMIUM  VARCHAR(50),
  boxcharge  VARCHAR(50),
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

/****************ankit 6938 **********************************************************/

////  updated by Rikkee Garg ////////////// issue 6965 ///////// Booking Detail Report ////////////////////////////


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go







ALTER procedure [dbo].[rpt_booking_report]

@pagency_code	as varchar(50),
@pclient_code	as varchar(50),
@pfrom_date		as varchar(20),
@pto_date		as varchar(20),
@pdateformat	as varchar(20),
@ppublication	as varchar(50),
@pedition		as varchar(50),
@ppub_center	as varchar(50),
@pbranch		as varchar(50),
@pcompcode		as varchar(20),
@puserid		as varchar(20),
@chk_access		as varchar(20),
@pagency_type	as varchar(50),
@pextra1		as varchar(50),
@pextra2		as varchar(50)
as 
declare @query1 varchar(8000)

begin

set @query1='select a.cio_booking_id as "BOOKING_ID",
c.Agency_Name AS "AGENCY",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE a.comp_code=CUST_MAST.comp_code AND Cust_Code=Client_code),Client_code)  AS "CLIENT", 
a.Caption AS "CAPTION",
Key_no AS "KEY",
b.Height AS "Depth",
b.Width   AS "Width",
round(b.Size_Book,2) AS "Area",
/*(select col_mast.Col_Alias from col_mast where b.Col_Code =col_mast.Col_Code)*/ b.Col_Code as COLOR,
b.Page_No as "Page_No",
isnull((select EXEC_MAST.Exec_name from exec_mast where a.Executive_code=exec_mast.Exe_no) ,(select RETAINERMASTER.Retain_Name  FROM  RETAINERMASTER where RETAINERMASTER.Retain_Code=a.RETAINER )) as "EXE_RET",
a.Card_rate as "CARDRATE",
A.Agrred_rate as "AGGRATE",
isnull(b.Gross_Rate,''0'') as "GROSSAMT",
isnull(a.Trade_disc,''0'' )as "AGENCYTD(%)",
isnull(a.ADD_AGENCY_COMM,''0'') as  "AgencyAddlTD(%)",
CASHDISCOUNT as "Cash_Disc",
isnull(b.Bill_Amt,''0'') as "BILLAMT",(select Comp_Name from comp_mst where comp_mst.Comp_Code=a.Comp_code) comp_name
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

IF(@pagency_type IS NOT NULL )
begin
	set @query1=@query1+' and c.Agency_Type_Code =  '''+@pagency_type+''' '
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

print(@query1)
exec(@query1)

end


////////////// end of issue 6965 /////////////////////////////////////////////////////////////




******************************SEND SUMIT DHAMA*******************************
ALTER PROCEDURE rpt_unregistered_client
   @pcompcode      as	varchar(20),
   @pbranchcode    as	varchar(20),
   @pdatefrom      as	datetime,
   @pdateto        as	datetime,
   @pdateformate   as	varchar(20),
   @padtype        as	varchar(20),
   @puomcode       as	varchar(20),
   @pdate_flag     as	varchar(20),--for on booking date B or Publish date P 
   @pextra1        as	varchar(200),
   @pextra2        as	varchar(200),
   @pextra3        as	varchar(200),
   @pextra4        as	varchar(200),
   @pextra5        as	varchar(200)
AS
   
BEGIN
	declare @v_query  varchar(8000)
    
    set @v_query='SELECT distinct a."date_time" as "BKDATE",a."Client_code" AS "CLIENTNAME", "Client_address" AS "CLIENT_ADDRESS",
        a."cio_booking_id" AS "CIOID", b."Agency_Name" as "AGENCY_NAME", c."Adv_Type_Name" as "ADV_TYPE_NAME",
        (select "Package_Name" from combin_mast where "Comp_Code"='''+@pcompcode+''' and "Combin_Code"=(
        case when instr(''abcdef'','','') >0 then substring(a."Package_code",1,instr(a."Package_code",'','')-1)  
        else a."Package_code" end)) as "PACKAGE_NAME", e."Adv_Cat_Name" as "ADV_CAT_NAME", 
        a."Total_area" as "TOTAL_AREA", a."Rate_code" as "RATE_CODE",
        a."Card_rate" as "CARD_RATE", a."Bill_amount" as "BILL_AMOUNT", a."Gross_amount" as "GROSS_AMOUNT", 
        f."Uom_Name" as "UOM_NAME",g."Comp_Name" as "COMP_NAME"
    FROM tbl_booking_mast a,agency_mast b,adv_type_mast c,adv_cat_mast e,uom_mast f,comp_mst g,tbl_booking_insert i
    WHERE a."Comp_code" = g."Comp_Code" AND a."Comp_code" = i."Comp_Code" AND a."Comp_code" ='''+@pcompcode+''' and 
        a."cio_booking_id" = i."Cio_Booking_Id"'
                
    If @pdate_flag='B' Begin
        set @v_query=@v_query+' AND a."date_time" BETWEEN '''+convert(varchar(20),@pdatefrom,101)+''' AND '''+convert(varchar(20),@pdateto,101)+''' 
                    AND b."code_subcode" = a."Agency_sub_code" and 
                    not exists (SELECT ''x'' FROM cust_mast where "Cust_Code"=a."Client_code")
                    AND a."Ad_type_code" = c."Adv_Type_Code" AND a."Ad_type_code" =isnull('''+@padtype+''',a."Ad_type_code") 
                    AND a."Uom_code" = f."Uom_Code" AND a."Uom_code" =isnull('''+@puomcode+''',a."Uom_code")
                    AND a."Ad_cat_code" = e."Adv_Cat_Code"
                    AND a."branch" = isnull('''+@pbranchcode+''',a."branch")'
	End                    
    Else Begin
        set @v_query=@v_query+' AND i."Insert_Date" BETWEEN '''+@pdatefrom+''' AND '''+convert(varchar(20),@pdateto,101)+''' 
                    AND b."code_subcode" = a."Agency_sub_code" and 
                    not exists (SELECT ''x'' FROM cust_mast where "Cust_Code"=a."Client_code")
                    AND a."Ad_type_code" = c."Adv_Type_Code" AND a."Ad_type_code" =isnull('''+@padtype+''',a."Ad_type_code") 
                    AND a."Uom_code" = f."Uom_Code" AND a."Uom_code" =isnull('''+@puomcode+''',a."Uom_code")
                    AND a."Ad_cat_code" = e."Adv_Cat_Code"
                    AND a."branch" = isnull('''+@pbranchcode+''',a."branch")';
    End  
    
    if @pextra1 is not null Begin
        set @v_query=@v_query+' AND i."Cio_Booking_Id" in ('+@pextra1+') order by bkdate,cioid';
    End
    else Begin
        set @v_query=@v_query+' order by bkdate,cioid';
    end
     
	exec(@v_query)
    
END
*********************************END PROC BY SUMIT *************************************


@@@@@@@@@@@@@@sumit  follow up $ mis  @@@@@@@@@@@@ 14\3\2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


ALTER PROCEDURE FA_OPBAL_fa_ladger_view
    @pcomp_code                               VARCHAR(4000) ,
    @punit_code                               VARCHAR(4000) ,
    @pbran_code                               VARCHAR(4000) ,
    @pacc_type                                VARCHAR(4000) ,
    @pcdp                                     VARCHAR(4000) ,
    @ptocdp                                   VARCHAR(4000) ,
    @pdate                                    VARCHAR(4000),
    @ptodt                                    VARCHAR(4000),
    @pdateformat                              VARCHAR(4000) ,
    @pnarr                                    VARCHAR(4000) ,
    @pbill                                    VARCHAR(4000) ,
    @pvch_detail                              VARCHAR(4000) ,
    @pextra1                                  VARCHAR(4000) ,
    @pextra2                                  VARCHAR(4000)  
AS                   
    
    
BEGIN
/*exec FA_OPBAL_fa_ladger_view  'HT001' , 'DEL' , NULL ,'01' ,'0000030' ,'0000030' ,'01/01/2008','01/01/2012','DD/MM/YYYY' ,'Y' ,'Y' ,'' ,''*/
        
        
        DECLARE @rec_acc                                  VARCHAR(200)
        DECLARE @v_dt                                     VARCHAR(200) 
        DECLARE @v_todt                                   VARCHAR(200) 
        DECLARE @v_fin_dt                                 VARCHAR(200) 
        DECLARE @v_mon                                    VARCHAR(5) 
        DECLARE @v_year                                   VARCHAR(5) 
        DECLARE @v_op_bal                                 NUMERIC(15,2) 
        DECLARE @vdr_op_bal                               NUMERIC(15,2) 
        DECLARE @vcr_op_bal                               NUMERIC(15,2) 
        DECLARE @v_tran_amt                               NUMERIC(15,2) 
        DECLARE @v_opening                                NUMERIC(15,2) 
        DECLARE @v_account_name                           VARCHAR(200) 
        DECLARE @v_closing                                NUMERIC(15,2) 
        DECLARE @v_tot_dr                                 NUMERIC(15,2) 
        DECLARE @v_tot_cr                                NUMERIC(15,2) 
        DECLARE @v_cdp                                    VARCHAR(20) 
        DECLARE @v_cdp1                                   VARCHAR(20) 
        DECLARE @v_vch_ln1                                VARCHAR (4000)
        DECLARE @v_vch_ln2                                VARCHAR (4000)
        DECLARE @v_rec_seqno                              NUMERIC(10)  
        SET @v_rec_seqno = 0     
        DECLARE @rec_vch                                  VARCHAR(200) 
        DECLARE @rec_vch_comp_code                        VARCHAR (4000) 
        DECLARE @rec_vch_unit_code                        VARCHAR (4000) 
        DECLARE @rec_vch_doc_type                         VARCHAR (4000) 
        DECLARE @rec_vch_vch_id                           VARCHAR (4000) 
        DECLARE @rec_vch_vch_date                         VARCHAR (4000) 
        DECLARE @rec_vch_vch_enln                         VARCHAR (4000) 
        DECLARE @rec_vch_acc_cdp                          VARCHAR (4000) 
        DECLARE @rec_vch_vch_gamt                         VARCHAR (4000) 
        DECLARE @rec_vch_debit                            VARCHAR (4000) 
        DECLARE @rec_vch_credit                           VARCHAR (4000) 
        DECLARE @rec_vch_posted                           VARCHAR (4000) 
        DECLARE @rec_vch_vch_ln1                          VARCHAR (4000) 
        DECLARE @rec_vch_vch_ln2                          VARCHAR (4000) 
        DECLARE @rec_vch_vch_chdate                       VARCHAR (4000) 
        DECLARE @rec_vch_cc_cd                            VARCHAR (4000) 
        DECLARE @rec_vch_cac_cd                           VARCHAR (4000) 
        DECLARE @rec_vch_ac_cd                            VARCHAR (4000) 
        DECLARE @rec_vch_main_group                       VARCHAR (4000) 
        DECLARE @rec_vch_psub_group                       VARCHAR (4000) 
        DECLARE @rec_vch_ssub_group                       VARCHAR (4000) 
        DECLARE @rec_vch_tsub_group                       VARCHAR (4000) 
        DECLARE @rec_vch_control_no                       VARCHAR (4000) 
        DECLARE @rec_vch_control_dt                       VARCHAR (4000) 
        DECLARE @rec_vch_seg_code                         VARCHAR (4000)        
        DECLARE @rec_bill                                 VARCHAR(200) 
        DECLARE @rec_bill_cdp                              VARCHAR (4000)
        DECLARE @rec_bill_acc_name                          VARCHAR (4000)
        DECLARE @rec_bill_bill_ref_type                   VARCHAR (4000)
        DECLARE @rec_bill_billid                          VARCHAR (4000)
        DECLARE @rec_bill_dt                              VARCHAR (4000)
        DECLARE @rec_bill_amt                             VARCHAR (4000)
        DECLARE @rec_vch_bran_code                             VARCHAR (4000)
        DECLARE @rec_vch_status   VARCHAR (4000)
        DECLARE @v_run_bal        numeric(15,2)
        DECLARE @v_run_bal_chr    varchar(50)
        DECLARE @rec_vch_detail_acc_name VARCHAR (4000)
        DECLARE @rec_vch_detail_amount   VARCHAR (4000)
        
        --DELETE FROM   fa_ladger_view_temp WHERE  sess_id  = @@SPID 
        
CREATE TABLE #FA_LADGER_VIEW_TEMP
( COMP_CODE     VARCHAR(50),
  UNIT_CODE     VARCHAR(50),
  DOC_TYPE      VARCHAR(50),
  VCH_ID        VARCHAR(150),
  VCH_DATE      DATETIME,
  VCH_ENLN      INT,
  ACC_CDP       VARCHAR(80),
  ACC_NAME      VARCHAR(4000),
  VCH_GAMT      NUMERIC(12,2),
  POSTED        VARCHAR(1),
  VCH_LN1       VARCHAR(4000),
  VCH_LN2       VARCHAR(4000),
  VCH_CHNO      VARCHAR(250),
  VCH_CHDATE    DATETIME,
  CC_CD         VARCHAR(120),
  CAC_CD        VARCHAR(120),
  AC_CD         VARCHAR(120),
  MAIN_GROUP    VARCHAR(50),
  PSUB_GROUP    VARCHAR(50),
  SSUB_GROUP    VARCHAR(50),
  QSUB_GROUP    VARCHAR(40),
  TSUB_GROUP    VARCHAR(100),
  PASSED        VARCHAR(1),
  STATUS        VARCHAR(1),
  CONTROL_NO    VARCHAR(150),
  CONTROL_DT    VARCHAR(150),
  SEG_CODE      VARCHAR(150),
  TYPE_CRDR     VARCHAR(1),
  BRAN_CODE     VARCHAR(80),
  OP_BAL        NUMERIC(12,2),
  CR_BAL        NUMERIC(12,2),
  DR_BAL        NUMERIC(12,2),
  SESS_ID       NUMERIC(10) ,
  REC_SEQNO     NUMERIC(10),
  RUN_BAL       NUMERIC(15,2),
  RUN_BAL_CHAR  VARCHAR(500),
  VCH_FLAG      VARCHAR(500),
  BILL_FLAG     VARCHAR(500))
        
        SELECT @v_dt  = DBO.convert_user_date('/',@pdate,@pdateformat) --@pdate 
        SELECT @v_todt  =DBO.convert_user_date('/',@ptodt,@pdateformat)-- @ptodt
        
print 'amit'
        DECLARE cur_acc CURSOR LOCAL FOR 
        SELECT cdp,acc_name
        FROM  fa_acc_mast 
        WHERE  comp_code  = @pcomp_code
         AND acc_ty  = ISNULL(@pacc_type, acc_ty)
         AND cdp  BETWEEN ISNULL(@pcdp, cdp)  AND  ISNULL(@ptocdp, cdp)
            
         set @v_run_bal = 0
            open cur_acc
            fetch NEXT FROM cur_acc INTO @rec_bill_cdp, @rec_bill_acc_name

            WHILE (@@FETCH_STATUS = 0)
            BEGIN    

          print  @rec_bill_cdp

            IF @pdate IS NOT NULL BEGIN 
                print 'a'
                SET @v_fin_dt  = DBO.fa_fin_dt(@pcomp_code, CONVERT(DATETIME,@v_dt))
            END
          print @v_fin_dt
            print 'b'
print(@pcomp_code)
print(@punit_code)
print(@v_cdp)
PRINT (@v_fin_dt)
            SELECT @v_op_bal  =  ISNULL(SUM(CONVERT(FLOAT, op_bal)),0)
            FROM  fa_acc_sum 
            WHERE comp_code  = @pcomp_code
             AND  (unit_code  = ISNULL(@punit_code,UNIT_CODE) OR @punit_code='')
            -- AND cdp  = @v_cdp
           AND  cdp  = @rec_bill_cdp
             AND  dt  = CONVERT(DATETIME, @v_fin_dt)
        print(@v_op_bal)
               print 'c'
    
            SELECT @v_tran_amt  =  ISNULL(SUM(CONVERT(FLOAT, vch_gamt)),0)
            FROM  fa_vch_mst 
            WHERE comp_code  = @pcomp_code
             AND (unit_code  = ISNULL(@punit_code, unit_code) or @punit_code='')
        --     AND  bran_code  = ISNULL(@pbran_code, bran_code)
             AND  acc_cdp  = ISNULL(@rec_bill_cdp,'?')
             AND  vch_date  BETWEEN CONVERT(DATETIME, @v_fin_dt) AND  CONVERT(DATETIME,@v_dt )- 1
print(@v_tran_amt)
 print 'd'
            ---------------------------------------------------------------------------------PRINT('LL')
            SET @v_opening  = ISNULL(@v_op_bal, 0)+ ISNULL(@v_tran_amt, 0)
            set @v_run_bal  = ISNULL(@v_run_bal,0)+isnull(@v_opening,0) 
            
            print 'eee'
            print @v_run_bal
            
            if ISNULL(@v_run_bal,0)>0 Begin 
                  set @v_run_bal_chr = cast(@v_run_bal as varchar)+' Dr.';
               End   
            if ISNULL(@v_run_bal,0)<0 Begin 
                  set @v_run_bal_chr = cast(abs(@v_run_bal) as varchar)+' Cr.';
               End
            
            IF ISNULL(@v_opening, 0)< 0  BEGIN 
                SET @vcr_op_bal  = ABS(ISNULL(@v_opening, 0))
            END
            ELSE BEGIN 
                SET @vcr_op_bal  = 0 
            END
   
            IF ISNULL(@v_opening, 0)> 0 BEGIN 
                SET @vdr_op_bal  = ABS(ISNULL(@v_opening, 0))
            END
            ELSE BEGIN 
                SET @vdr_op_bal  = 0 
            END
   
            SET @v_rec_seqno  = ISNULL(@v_rec_seqno, 0)+ 1 
            

 print 'e'
 print @v_run_bal
 print @v_run_bal_chr
            INSERT INTO  #fa_ladger_view_temp   
                    ( acc_name , 
                    op_bal , 
                    dr_bal , 
                    cr_bal , 
                    rec_seqno , 
                    sess_id,
                    acc_cdp,
                    run_bal,
                    run_bal_char )  
             VALUES         ( /*pcomp_code,punit_code,pbran_code,V_cdp,V_acc_name ,*/ /*pcomp_code,punit_code,pbran_code,V_cdp,V_acc_name ,*/ ' Opening Bal->' , 
                    @v_opening , 
                    @vdr_op_bal , 
                    @vcr_op_bal , 
                    @v_rec_seqno , 
                    @@SPID,
                    @rec_bill_cdp,
                    isnull(@v_run_bal,0),
                    @v_run_bal_chr)  
            
     print 'f'
    print @v_cdp
    print @v_dt    
    print @v_todt    

            DECLARE cur_vch CURSOR LOCAL FOR 
        SELECT
                 comp_code,
                 unit_code,
                 doc_type,
                 vch_id,
                 vch_date "VCH_DATE",
                 vch_enln,
                 acc_cdp,
                 vch_gamt,
                 ABS(CASE SIGN(vch_gamt) 
                    WHEN 1 THEN vch_gamt 
                    ELSE 0 
                END) debit,
                 ABS(CASE SIGN(vch_gamt) 
                    WHEN - 1 THEN vch_gamt 
                    ELSE 0 
                END) credit,
                 posted,
                 vch_ln1,
                 vch_ln2,
                 vch_chdate,
                 cc_cd,
                 cac_cd,
                 ac_cd,
                 main_group,
                 psub_group,
                 ssub_group,
                 tsub_group,
                 status,
                 control_no,
                 control_dt,
                 seg_code,
                 bran_code
        FROM  fa_vch_mst 
    WHERE comp_code  = @pcomp_code
     AND (unit_code  = ISNULL(@punit_code, unit_code) or @punit_code='')
     AND (bran_code  = ISNULL(@pbran_code, bran_code) OR @PBRAN_CODE='')
     AND  acc_cdp  =@rec_bill_cdp--'0000030'-- @v_cdp
     AND  vch_date  BETWEEN @v_dt  AND  @v_todt


            OPEN cur_vch         
                FETCH NEXT FROM cur_vch INTO 
                                    @rec_vch_comp_code, @rec_vch_unit_code, @rec_vch_doc_type, 
                                    @rec_vch_vch_id, @rec_vch_vch_date, @rec_vch_vch_enln, 
                                    @rec_vch_acc_cdp, @rec_vch_vch_gamt, @rec_vch_debit, 
                                    @rec_vch_credit, @rec_vch_posted, @rec_vch_vch_ln1, 
                                    @rec_vch_vch_ln2, @rec_vch_vch_chdate, @rec_vch_cc_cd, 
                                    @rec_vch_cac_cd, @rec_vch_ac_cd, @rec_vch_main_group, 
                                    @rec_vch_psub_group, @rec_vch_ssub_group, @rec_vch_tsub_group,
                                    @rec_vch_status, 
                                    @rec_vch_control_no, @rec_vch_control_dt, @rec_vch_seg_code,
                                    @rec_vch_bran_code
                WHILE (@@FETCH_STATUS = 0) BEGIN

                print 'amit11'
					set @v_run_bal  = ISNULL(@v_run_bal,0)+isnull(@rec_vch_vch_gamt,0) 
            print 'eee'
            print @v_run_bal
            if ISNULL(@v_run_bal,0)>0 Begin 
                  set @v_run_bal_chr = cast(@v_run_bal as varchar)+' Dr.';
               End   
            if ISNULL(@v_run_bal,0)<0 Begin 
                  set @v_run_bal_chr = cast(abs(@v_run_bal) as varchar)+' Cr.';
               End
            
            IF ISNULL(@v_opening, 0)< 0  BEGIN 
                SET @vcr_op_bal  = ABS(ISNULL(@v_opening, 0))
            END
            ELSE BEGIN 
                SET @vcr_op_bal  = 0 
            END

                IF @pnarr = 'Y'  BEGIN 
                    SET @v_vch_ln1  = @rec_vch_vch_ln1 
                    SET @v_vch_ln2  = @rec_vch_vch_ln2 
                END
                ELSE BEGIN 
					print 'vjzxzx'
                    SET @v_vch_ln1  = 0 
                    SET @v_vch_ln2  = 0 
                END
   
                SET @v_rec_seqno  = ISNULL(@v_rec_seqno, 0)+ 1 
                INSERT INTO  #fa_ladger_view_temp   
                        ( comp_code , 
                        unit_code , 
                        doc_type , 
                        vch_id , 
                        vch_date , 
                        vch_enln , 
                        acc_cdp , 
                        acc_name , 
                        op_bal , 
                        dr_bal , 
                        cr_bal , 
                        posted , 
                        vch_ln1 , 
                        vch_ln2 , 
                        vch_chdate , 
                        cc_cd , 
                        cac_cd , 
                        ac_cd , 
                        main_group , 
                        psub_group , 
                        ssub_group , 
                        tsub_group , 
                        status , 
                        control_no , 
                        control_dt , 
                        seg_code , 
                        rec_seqno , 
                        sess_id,
                        run_bal,
                        run_bal_char)  
                 VALUES         ( @rec_vch_comp_code , 
                        @rec_vch_unit_code , 
                        @rec_vch_doc_type , 
                        @rec_vch_vch_id , 
                        @rec_vch_vch_date , 
                        @rec_vch_vch_enln , 
                        @rec_vch_acc_cdp , 
                        @rec_bill_acc_name , 
                        @rec_vch_vch_gamt , 
                        @rec_vch_debit , 
                        @rec_vch_credit , 
                        @rec_vch_posted , 
                        @v_vch_ln1 , 
                        @v_vch_ln2 , 
                        @rec_vch_vch_chdate , 
                        @rec_vch_cc_cd , 
                        @rec_vch_cac_cd , 
                        @rec_vch_ac_cd , 
                        @rec_vch_main_group , 
                        @rec_vch_psub_group , 
                        @rec_vch_ssub_group , 
                        @rec_vch_tsub_group , 
                        @rec_vch_status , 
                        @rec_vch_control_no , 
                        @rec_vch_control_dt , 
                        @rec_vch_seg_code , 
                        @v_rec_seqno , 
                        @@SPID,
                        isnull(@v_run_bal,0),
                        @v_run_bal_chr )  

 /*UPDATE fa_ladger_view_temp SET dr_bal='1' WHERE ACC_NAME=' Opening Bal->'
                                  AND   sess_id = @@SPID*/
                
                IF @pbill = 'Y' BEGIN 

                    DECLARE cur_bill CURSOR LOCAL FOR 
                    SELECT bill_ref_type,billid ,dt,amt 
                    FROM  fa_vch_billdet 
                    WHERE comp_code  = @pcomp_code
                    AND  (unit_code  = ISNULL(@punit_code, unit_code) OR @punit_code='')
                    AND  (bran_code  = ISNULL(@pbran_code, bran_code) OR @pbran_code='')
                    AND  cdp  = @rec_vch_acc_cdp
                    AND  ID  = @rec_vch_vch_id
                    
                    OPEN cur_bill         
                        FETCH NEXT FROM cur_bill INTO @rec_bill_bill_ref_type, @rec_bill_billid, @rec_bill_dt, @rec_bill_amt
                        WHILE (@@FETCH_STATUS = 0) BEGIN
                        SET @v_rec_seqno  = ISNULL(@v_rec_seqno, 0)+ 1 
                        INSERT INTO  #fa_ladger_view_temp (vch_ln1, 
                                                          rec_seqno,sess_id,bill_flag)  
                                                  VALUES (CAST(@rec_bill_bill_ref_type AS VARCHAR) + '  ' + CAST(@rec_bill_billid AS VARCHAR) + '  ' + CAST(CONVERT(DATETIME, @rec_bill_dt) AS VARCHAR) + ' ' + CAST(@rec_bill_amt AS VARCHAR) , 
                                                          @v_rec_seqno, @@SPID, 'Y')  
                        
                        FETCH NEXT FROM cur_bill INTO @rec_bill_bill_ref_type, @rec_bill_billid, @rec_bill_dt, @rec_bill_amt
                    END --)                 
                    
                    CLOSE cur_bill
                     DEALLOCATE cur_bill
                    
                END
                print 'zxzx'
                print @pvch_detail
                print @rec_vch_comp_code
                  print @rec_vch_unit_code
                  print @rec_vch_bran_code
                  print @rec_vch_acc_cdp
                print @rec_vch_doc_type
                print @rec_vch_vch_date
                print @rec_vch_vch_id
                if @pvch_detail = 'Y' Begin 
                  
                  
                        DECLARE cur_vch_detail CURSOR LOCAL FOR 
                           select dbo.fa_get_account_name(comp_code, acc_cdp) ACC_NAME,
                                  cast(ABS(vch_gamt) as varchar)+(CASE SIGN (vch_gamt) WHEN  1 THEN ' Dr.' ELSE ' Cr.' END) amount from fa_vch_mst 
                                     where comp_code =  @rec_vch_comp_code
                                       and unit_code =  @rec_vch_unit_code
                                       and bran_code =  @rec_vch_bran_code
                                       and acc_cdp   <> @rec_vch_acc_cdp
                                       and doc_type  =  @rec_vch_doc_type
                                       and vch_date  =  @rec_vch_vch_date
                                       and vch_id    =  @rec_vch_vch_id;
                  OPEN cur_vch_detail  FETCH NEXT FROM cur_vch_detail INTO @rec_vch_detail_acc_name,@rec_vch_detail_amount
                        WHILE (@@FETCH_STATUS = 0) BEGIN

                        SET @v_rec_seqno  = ISNULL(@v_rec_seqno, 0)+ 1 

                  INSERT INTO #fa_ladger_view_temp (vch_ln1, run_bal_char, rec_seqno, sess_id,vch_flag)
                                           VALUES (@rec_vch_detail_acc_name,@rec_vch_detail_amount,@v_rec_seqno,@@SPID ,'Y');
                    FETCH NEXT FROM cur_vch_detail INTO @rec_vch_detail_acc_name,@rec_vch_detail_amount
                    
                    END --)                 
                    
                    CLOSE cur_vch_detail
                     DEALLOCATE cur_vch_detail
                    
                  End
                IF @rec_vch_vch_gamt>= '0' BEGIN 
print 'cc'
                    SET @v_tot_dr  = ISNULL(@v_tot_dr, 0)+ ISNULL(@rec_vch_vch_gamt, 0)
                END
                ELSE BEGIN 
print 'dd'
                    SET @v_tot_cr  = ISNULL(@v_tot_cr, 0)+ ISNULL(ABS(@rec_vch_vch_gamt), 0)
                END
   

            
            FETCH NEXT FROM cur_vch INTO 
                                    @rec_vch_comp_code, @rec_vch_unit_code, @rec_vch_doc_type, 
                                    @rec_vch_vch_id, @rec_vch_vch_date, @rec_vch_vch_enln, 
                                    @rec_vch_acc_cdp, @rec_vch_vch_gamt, @rec_vch_debit, 
                                    @rec_vch_credit, @rec_vch_posted, @rec_vch_vch_ln1, 
                                    @rec_vch_vch_ln2, @rec_vch_vch_chdate, @rec_vch_cc_cd, 
                                    @rec_vch_cac_cd, @rec_vch_ac_cd, @rec_vch_main_group, 
                                    @rec_vch_psub_group, @rec_vch_ssub_group, @rec_vch_tsub_group,
                                    @rec_vch_status, 
                                    @rec_vch_control_no, @rec_vch_control_dt, @rec_vch_seg_code,
                                    @rec_vch_bran_code
            END --) 
            CLOSE cur_vch
            DEALLOCATE cur_vch
            
            SET @v_rec_seqno  = ISNULL(@v_rec_seqno, 0)+ 1 


            IF ( ABS(@v_tot_dr)> 0 OR ABS(@v_tot_cr)> 0 ) BEGIN 
                INSERT INTO  #fa_ladger_view_temp   
                        ( acc_name , 
                        op_bal , 
                        dr_bal , 
                        cr_bal , 
                        rec_seqno , 
                        sess_id )  
                 VALUES         ( 'Total->' , 
                        @v_closing , 
                        @v_tot_dr , 
                        @v_tot_cr , 
                        @v_rec_seqno , 
                        @@SPID )  
                
            END
   
            SET @v_rec_seqno  = ISNULL(@v_rec_seqno, 0)+ 1 
            SET @v_closing  = ISNULL(@v_opening, 0)+ ISNULL(@v_tot_dr, 0)- ISNULL(@v_tot_cr, 0)
            SET @v_tot_dr  = 0 
            SET @v_tot_cr  = 0 
            IF ISNULL(@v_closing, 0)>= 0  BEGIN 
                SET @v_tot_dr  = ISNULL(@v_closing, 0)
            END
            ELSE BEGIN 
                SET @v_tot_cr  = ISNULL(ABS(@v_closing), 0)
            END
   
            IF ( ABS(@v_tot_dr)> 0 OR ABS(@v_tot_cr)> 0 ) BEGIN 
                INSERT INTO  #fa_ladger_view_temp   
                        ( acc_name , 
                        op_bal , 
                        dr_bal , 
                        cr_bal , 
                        rec_seqno , 
                        sess_id )  
                 VALUES         ( 'Closing->' , 
                        @v_closing , 
                        @v_tot_dr , 
                        @v_tot_cr , 
                        @v_rec_seqno , 
                        @@SPID )  
                
            END
   
            SET @v_op_bal  = 0 
            SET @vdr_op_bal  = 0 
            SET @vcr_op_bal  = 0 
            SET @v_tran_amt  = 0 
            SET @v_opening  = 0 
            SET @v_account_name  = '' 
            SET @v_closing  = 0 
            SET @v_tot_dr  = 0 
            SET @v_tot_cr  = 0 

        END --) 
        
           
  
        
        fetch NEXT FROM cur_acc INTO @rec_bill_cdp, @rec_bill_acc_name
        CLOSE cur_acc
         DEALLOCATE cur_acc
        
           IF (@rec_vch_vch_gamt='0' OR @rec_vch_vch_gamt IS NULL) begin
                                             
                    DELETE FROM #fa_ladger_view_temp WHERE  ACC_NAME=' Opening Bal->'
                    AND (op_bal Is NULL OR op_bal ='0')AND sess_id = @@SPID AND dr_bal<>'1'
                                
                    END 
    
        
        
        
        
        
        SELECT COMP_CODE, UNIT_CODE, DOC_TYPE, VCH_ID,cast(convert(varchar(10), VCH_DATE,101) as varchar)+char(10)+char(10)+CHAR(10)+CHAR(10)+cast(unit_code as varchar) VCH_DATE, VCH_ENLN, ACC_CDP, ACC_NAME, VCH_GAMT, POSTED, VCH_LN1, VCH_LN2, VCH_CHNO, VCH_CHDATE, CC_CD, CAC_CD, AC_CD, MAIN_GROUP, PSUB_GROUP, SSUB_GROUP, QSUB_GROUP, TSUB_GROUP, PASSED, STATUS, CONTROL_NO, CONTROL_DT, SEG_CODE, TYPE_CRDR, BRAN_CODE, OP_BAL, CR_BAL, DR_BAL, SESS_ID, REC_SEQNO,
        run_bal RUN_BAL,    run_bal_char RUN_BAL_CHAR,bill_flag BILL_FLAG,vch_flag VCH_FLAG
        FROM  #fa_ladger_view_temp  WHERE     sess_id  = @@SPID
        ORDER BY rec_seqno 
        
        --DELETE FROM  #fa_ladger_view_temp WHERE  sess_id  = @@SPID 
        
		DROP TABLE #fa_ladger_view_temp
        SET NOCOUNT OFF

END


@@@@@@@@@@

alter PROCEDURE fetch_booking_for_mis
    @pcompcode       as  varchar(20),
    @pcenter         as  varchar(200),
    @pbranch         as  varchar(200),
    @padtype         as  varchar(200),
    @padcatg         as  varchar(2000),
    @pag_main_code   as  varchar(200),
    @pag_sub_code    as  varchar(200),
    @pclient         as  varchar(200),
    @pexec_code      as  varchar(200),
    @pret_code       as  varchar(200),
    @pbkid           as  varchar(2000),
    @pfrom_date      as	datetime,
    @ptill_date      as	datetime,
    @pfetch_on       as  varchar(200),--B for booking date.P for published date
    @pdateformat     as  varchar(200),
    @puserid         as  varchar(200),
    @pextra1         as  varchar(200),
    @pextra2         as  varchar(200),
    @pextra3         as  varchar(200),
    @pextra4         as  varchar(200),
    @pextra5         as  varchar(200),
    @pextra6         as  varchar(200),
    @pextra7         as  varchar(200),
    @pextra8         as  varchar(200),
    @pextra9         as  varchar(200),
    @pextra10        as  varchar(200)
As
Begin
	If @pcenter='' Begin
		set @pcenter=null
	End
	If @pbranch='' Begin
		set @pbranch=null
	End
	If @padtype='' Begin
		set @padtype=null
	End
	If @padcatg='' Begin
		set @padcatg=null
	End
	If @pag_main_code='' Begin
		set @pag_main_code=null
	End
	If @pag_sub_code='' Begin
		set @pag_sub_code=null
	End
	If @pclient='' Begin
		set @pclient=null
	End
	If @pexec_code='' Begin
		set @pexec_code=null
	End							
	If @pret_code='' Begin
		set @pret_code=null
	End	
	If @pbkid='' Begin
		set @pbkid=null
	End		
    
    if @pfetch_on='B' Begin
        select distinct m."cio_booking_id" as CIO_BOOKING_ID, m."Comp_code" as "COMP_CODE",m."date_time" as "DATE_TIME",m."branch" as "BRANCH",
        (select "Branch_Name" from branch_mst where "Branch_Code"=m."branch") as "BRANCH_NAME",m."Ad_size_height" as "HEIGHT",m."Ad_size_width" as "WIDTH",
        m."RO_No" as "RO_NO",m."RO_Date" as "RO_DATE",m."Key_no" as "KEY_NO",m."Caption" "CAPTION",m."Page_no" as "PAGE_NO",
        m."Client_code" as "CLIENT_CODE",isnull((select "Cust_Name" from cust_mast where  cust_mast."Comp_Code"=m."Comp_code" and cust_mast."Cust_Code"=m."Client_code"),m."Client_code")  as "CLIENT_NAME",
        m."Agency_sub_code" as "AGENCY_SUB_CODE",a."Agency_Name" as "AGENCY_NAME",m."Insertion_date" as "INSERTION_DATE",
        m."Executive_code" as "EXECUTIVE_CODE",(select "Exec_name" from exec_mast where cast(exec_mast."Exe_no" as varchar(20))=m."Executive_code") as "EXECUTIVE_NAME",
        m.RETAINER as "RETAINER",(select "Retain_Name" from retainermaster where "Retain_Code"=m.RETAINER) as "RETAINER_NAME",
        (select distinct i."industry_name" from INDUSTRY_MASTER i,product_cat_mast p where p."prod_cat_code"=m."Product_code" and i."industry_code"=p."industry_code") as "INDUSTRY_NAME",
          (select distinct i."industry_code" from INDUSTRY_MASTER i,product_cat_mast p where p."prod_cat_code"=m."Product_code" and i."industry_code"=p."industry_code") as "INDUSTRY_CODE",
         m."Product_code" as "PRODUCT_CODE",(select "prod_desc" from product_cat_mast where "prod_cat_code"=m."Product_code") as "PRODUCT_NAME",
        m."Brand_code" as "BRAND_CODE",(select "brand_name" from brand_mst where "brand_code"=m."Brand_code") as "BRAND_NAME",
        m."Ad_type_code" as "AD_TYPE_CODE",(select "Adv_Type_Name" from adv_type_mast where "Adv_Type_Code"=m."Ad_type_code") as "AD_TYPE_NAME", 
        m."Ad_cat_code"as "AD_CAT_CODE",(select "Adv_Cat_Name" from adv_cat_mast where "Comp_Code"=m."Comp_code" and "Adv_Cat_Code"=m."Ad_cat_code") as "AD_CAT_NAME", 
        case when m."Ad_sub_cat_code"='0' or m."Ad_sub_cat_code"='' then null else m."Ad_sub_cat_code" end as "AD_SUB_CAT_CODE",(select "Adv_Subcat_Name" from adv_subcat_mast 
        where "Comp_Code"=m."Comp_code" and "Adv_Subcat_Code"=m."Ad_sub_cat_code") as "AD_SUBCAT_NAME",
        m."Color_code" as "COLOR_CODE",(select "Col_Name" from col_mast where "Col_Code"=m."Color_code") as "COLOR_NAME",
        m."Uom_code",(select "UOM_DESC" from uom_mast where "Uom_Code"=m."Uom_code") as "UOM_NAME", 
        case when m."Variant"='0' or "Variant"='' then null else m."Variant" end as "VARIANT",(select "Varient_Name" from varient_mst 
        where "Comp_Code"=m."Comp_code" and "Varient_Code"=m."Variant") as "VARIANT_NAME"
        from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,branch_mst b
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=@pcompcode and 
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"+a."SUB_Agency_Code" = m."Agency_sub_code" and
        a."Agency_Code"=isnull(@pag_main_code,a."Agency_Code") and a."SUB_Agency_Code"=isnull(@pag_sub_code,a."SUB_Agency_Code") and
        m."date_time" between @pfrom_date and @ptill_date and m."Client_code"=isnull(@pclient,m."Client_code") and 
        m."branch"=isnull(@pbranch,m."branch") and b."pub_center"=isnull(@pcenter,b."pub_center") 
       and  m."cio_booking_id" =isnull(@pbkid,m."cio_booking_id") 
       and m."Ad_type_code"=isnull(@padtype,m."Ad_type_code")
       and m."Executive_code"=isnull(@pexec_code ,m."Executive_code") 
       and i."Page_No"=isnull(@pextra1 ,i."Page_No")
        order by comp_code,cio_booking_id,date_time
	End        
    else Begin
    
        select distinct m."cio_booking_id" as CIO_BOOKING_ID,m."Comp_code" as "COMP_CODE",m."date_time" as "DATE_TIME",m."branch" as "BRANCH",
        (select "Branch_Name" from branch_mst where "Branch_Code"=m."branch") as "BRANCH_NAME",m."Ad_size_height" as "HEIGHT",m."Ad_size_width" as "WIDTH",
        m."RO_No" as "RO_NO",m."RO_Date" as "RO_DATE",m."Key_no" as "KEY_NO",m."Caption" "CAPTION",m."Page_no" as "PAGE_NO",
        m."Client_code" as "CLIENT_CODE",isnull((select "Cust_Name" from cust_mast where  cust_mast."Comp_Code"=m."Comp_code" and cust_mast."Cust_Code"=m."Client_code"),m."Client_code")  as "CLIENT_NAME",
        m."Agency_sub_code" as "AGENCY_SUB_CODE",a."Agency_Name" as "AGENCY_NAME",m."Insertion_date" as "INSERTION_DATE",
        m."Executive_code" as "EXECUTIVE_CODE",(select "Exec_name" from exec_mast where cast(exec_mast."Exe_no" as varchar(20))=m."Executive_code") as "EXECUTIVE_NAME",
        m.RETAINER as "RETAINER",(select "Retain_Name" from retainermaster where "Retain_Code"=m.RETAINER) as "RETAINER_NAME",
        (select distinct i."industry_name" from INDUSTRY_MASTER i,product_cat_mast p where p."prod_cat_code"=m."Product_code" and i."industry_code"=p."industry_code") as "INDUSTRY_NAME",
        (select distinct i."industry_code" from INDUSTRY_MASTER i,product_cat_mast p where p."prod_cat_code"=m."Product_code" and i."industry_code"=p."industry_code") as "INDUSTRY_CODE",
         m."Product_code" as "PRODUCT_CODE",(select "prod_desc" from product_cat_mast where "prod_cat_code"=m."Product_code") as "PRODUCT_NAME",
        m."Brand_code" as "BRAND_CODE",(select "brand_name" from brand_mst where "brand_code"=m."Brand_code") as "BRAND_NAME",
        m."Ad_type_code" as "AD_TYPE_CODE",(select "Adv_Type_Name" from adv_type_mast where "Adv_Type_Code"=m."Ad_type_code") as "AD_TYPE_NAME", 
        m."Ad_cat_code"as "AD_CAT_CODE",(select "Adv_Cat_Name" from adv_cat_mast where "Comp_Code"=m."Comp_code" and "Adv_Cat_Code"=m."Ad_cat_code") as "AD_CAT_NAME", 
        case when m."Ad_sub_cat_code"='0' or m."Ad_sub_cat_code"='' then null else m."Ad_sub_cat_code" end as "AD_SUB_CAT_CODE",(select "Adv_Subcat_Name" from adv_subcat_mast 
        where "Comp_Code"=m."Comp_code" and "Adv_Subcat_Code"=m."Ad_sub_cat_code") as "AD_SUBCAT_NAME",
        m."Color_code" as "COLOR_CODE",(select "Col_Name" from col_mast where "Col_Code"=m."Color_code") as "COLOR_NAME",
        m."Uom_code",(select "UOM_DESC" from uom_mast where "Uom_Code"=m."Uom_code") as "UOM_NAME", 
        case when m."Variant"='0' or "Variant"='' then null else m."Variant" end as "VARIANT",(select "Varient_Name" from varient_mst 
        where "Comp_Code"=m."Comp_code" and "Varient_Code"=m."Variant") as "VARIANT_NAME"
        from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,branch_mst b
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=@pcompcode and 
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"+a."SUB_Agency_Code" = m."Agency_sub_code" and
        a."Agency_Code"=isnull(@pag_main_code,a."Agency_Code") and a."SUB_Agency_Code"=isnull(@pag_sub_code,a."SUB_Agency_Code") and
        i."Insert_Date" between @pfrom_date and @ptill_date and m."Client_code"=isnull(@pclient,m."Client_code") and 
        m."branch"=isnull(@pbranch,m."branch") and b."pub_center"=isnull(@pcenter,b."pub_center") 
        and  m."cio_booking_id" =isnull(@pbkid,m."cio_booking_id") 
        and m."Ad_type_code"=isnull(@padtype,m."Ad_type_code")
       and m."Executive_code"=isnull(@pexec_code ,m."Executive_code") 
       and i."Page_No"=isnull(@pextra1 ,i."Page_No")
        order by comp_code,cio_booking_id,date_time;
    End
    
    select getdate() as "CUR_DATE"
    
end


@@@@@@@@@@@@@@@@@@@

CREATE PROCEDURE followup
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
                  AND (f."Insert_Date" IS NULL OR "Insert_Date" = '')
                  AND "Insert_Status" != 'cancel'
                  AND a."Agency_sub_code" = b."code_subcode"
                  AND a."Package_code" = d."Combin_Code"
                  AND f."Edition_Code" = e."Edition_Code"
                  AND a."Agency_sub_code" = isnull (@pagency, a."Agency_sub_code")
                  AND a."cio_booking_id" = isnull (@pextra1, a."cio_booking_id")
                  AND a."Client_code" = isnull (@pclient, a."Client_code");
END

@@@@@@@@@@@@@@@@@@@

CREATE PROCEDURE industryselect
@compcode	as varchar(200),
@industry	as varchar(200)
AS
BEGIN
If @industry='' Begin
	set @industry=null
End	
select "industry_code", "industry_name"  from INDUSTRY_MASTER  where "comp_code"=@compcode  
 and   "industry_name" LIKE '%' + @industry + '%' order by "industry_name"
END

@@@@@@@@@@@@@@@@

CREATE PROCEDURE productselect
@compcode	as	varchar(200),
@product	as	varchar(200),
@ind_code	as	varchar(200)
AS
BEGIN

If @product='' Begin
	set @product=null
End

select "prod_cat_code", "prod_desc"  from product_cat_mast 
where "comp_code"=@compcode  and "industry_code"=@ind_code and "prod_desc" LIKE '%' + @product + '%' order by "prod_desc";

END

@@@@@@@@@@@@

CREATE procedure websp_misupdate
@pcompcode	as	varchar(20),
@pbkid		as	varchar(200),
@PRODUCT_CODE	as	varchar(200),
@BRAND_CODE		as	varchar(200),
@Varient_Code	as	varchar(200)
as
begin

	update tbl_booking_mast set "Product_code"=PRODUCT_CODE,"Brand_code"=BRAND_CODE,"Variant"=@Varient_Code where "Comp_code"=@pcompcode and  "cio_booking_id"=@pbkid
   
end



@@@@@@@@@@@@@@sumit  follow up $ mis  @@@@@@@@@@@@ 14\3\2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@




/********************ajay******0006650*****14/03/2012***********************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

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








/*******************end********************/



/************************6968***********BOOKING MASTE********************MIMOH*****/

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
CLIENT_TYPE VARCHAR(5),
TRANSLATION_CODE VARCHAR(25), 
TRANSLATION_PREMIUM FLOAT,
APP_USER VARCHAR(50)
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
REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,APP_USER
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
 end as REVISE_DATE,CLIENT_TYPE,
 CASE @dateformat
	WHEN 'mm/dd/yyyy' then convert(DATETIME,#TEMPBOOKING_MAST.Creation_datetime,101)
	WHEN 'dd/mm/yyyy' then convert(DATETIME,#TEMPBOOKING_MAST.Creation_datetime,103)
	WHEN 'yyyy/mm/dd' then convert(DATETIME,#TEMPBOOKING_MAST.Creation_datetime,111)
 end as
 CREATION_DATETIME,TRANSLATION_CODE, TRANSLATION_PREMIUM,
 (SELECT CHARGES_TYPE FROM  AD_CHARGE_MAST WHERE AD_CHARGE_MAST.CHARGE_CODE=#TEMPBOOKING_MAST.TRANSLATION_CODE and COMP_CODE=@compcode) AS TRANSLATION_TYPE,
 (SELECT username FROM  LOGIN WHERE LOGIN.userid=TEMPBOOKING_MAST.APP_USER and LOGIN.COM_CODE=compcode) as APP_USER
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




































/************************6968***********BOOKING MASTE********************MIMOH*****/



@@@@@@@@@@@@@@@@@@@@@@@@@@  cat_seq_no.  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER procedure fetch_ad_cat_flow_sequence
    @pcompcode           as varchar(20),
    @pcenter             as varchar(20),
    @pday                as varchar(20),
    @padtype             as varchar(20),
    @puserid             as varchar(20),
    @pdateformat         as varchar(20),
    @pextra1             as varchar(200),
    @pextra2             as varchar(200),
    @pextra3             as varchar(200),
    @pextra4             as varchar(200),
    @pextra5             as varchar(200)
as

begin
    declare c1 cursor for
    select "Adv_Cat_Code" as cat_code,"Adv_Cat_Name" as cat_name from adv_cat_mast where "Adv_Type"=@padtype 
    order by cat_name

declare @v_cat_name  varchar(100)
declare @v_cat_code  varchar(20)
declare @v_cat_seqno numeric(5)
declare @v_recno     numeric(5)
declare @rec_count   numeric(5)

CREATE TABLE #TEMP_AD_RECEIPT_REPORT
( COMP_CODE           VARCHAR(200),
  PCENTRE_CODE        VARCHAR(200),
  DOCTYPE			  VARCHAR(200),
  AG_MAIN_CODE        VARCHAR(200),
  AG_SUB_CODE         VARCHAR(200),
  REC_SEQNO           NUMERIC(10),
  RECOVARY_DAYS       NUMERIC(5),
  AD_MAIN_CATEGORY    VARCHAR(2000),
  AD_SUB_CATEGORY     VARCHAR(2000),
  AD_THIRD_CATEGORY   VARCHAR(2000),
  AD_FOURTH_CATEGORY  VARCHAR(2000),
  AD_FIFTH_CATEGORY   VARCHAR(2000))
  
    open c1;
        fetch NEXT FROM c1 INTO @v_cat_code,@v_cat_name
        WHILE (@@FETCH_STATUS = 0)  BEGIN
        set @v_recno=isnull(@v_recno,0)+1
        
        select @rec_count=count(*) from ad_cat_flow_sequence 
            where comp_code= @pcompcode and cat_code=@v_cat_code and page_day=@pday and pub_center=@pcenter
        if isnull(@rec_count,0)=0 Begin
            insert into #temp_ad_receipt_report(comp_code,pcentre_code,ad_main_category,ad_sub_category,ag_main_code,recovary_days,rec_seqno,doctype)
            values(@pcompcode,@pcenter,@v_cat_code,@v_cat_name,@pday,null,@v_recno,'I')
		End            
        else Begin
            select cat_seqno into v_cat_seqno from ad_cat_flow_sequence 
            where comp_code= @pcompcode and cat_code=@v_cat_code and page_day=@pday and pub_center=@pcenter

            insert into #temp_ad_receipt_report(comp_code,pcentre_code,ad_main_category,ad_sub_category,ag_main_code,recovary_days,rec_seqno,doctype)
            values(@pcompcode,@pcenter,@v_cat_code,@v_cat_name,@pday,@v_cat_seqno,@v_recno,'U')
        End
        fetch NEXT FROM c1 INTO @v_cat_code,@v_cat_name
    end
    close c1
    DEALLOCATE C1;
    select comp_code as "COMP_CODE",pcentre_code as "PCENTER_CODE",ad_main_category as "CATEGORY_CODE",ad_sub_category as "CATEGORY_NAME",
        ag_main_code as "DAYNAME",recovary_days as "CATEGORY_SEQNO",rec_seqno as "REC_SLNO",doctype as "REC_TYPE" 
        from #temp_ad_receipt_report order by rec_seqno; 
    
    drop table #temp_ad_receipt_report
end


@@@@@@@@@@@@@@



alter procedure ad_cat_flow_sequence_dml
    @pcompcode           as	varchar(20),
    @pcenter             as	varchar(200),
    @pday                as	varchar(200),
    @padtype             as	varchar(200),
    @pcatcode            as	varchar(200),
    @pcat_seqno          as int,
    @pflag               as	varchar(20),
    @puserid             as	varchar(200),
    @pins_upd            as	varchar(20),--for insert I, for update U 
    @pdateformat         as	varchar(20),
    @pextra1             as	varchar(200),
    @pextra2             as	varchar(200),
    @pextra3             as	varchar(200),
    @pextra4             as	varchar(200),
    @pextra5             as	varchar(200)
As
DECLARE @v_cnt numeric(5)
begin
    If @pins_upd='U' Begin

        update ad_cat_flow_sequence set cat_seqno= @pcat_seqno,updated_by=@puserid, updated_dt=getdate()
            where comp_code= @pcompcode and cat_code=@pcatcode and page_day=@pday and pub_center=@pcenter
	End
    
    if @pins_upd='I' Begin
        select @v_cnt=count(*) from ad_cat_flow_sequence 
            where comp_code= @pcompcode and cat_code=@pcatcode and page_day=@pday and pub_center=@pcenter
        If isnull(@v_cnt,0)=0 Begin
            insert into ad_cat_flow_sequence(comp_code, pub_center, page_day, cat_code, cat_seqno, flag, created_by, created_dt)
            values(@pcompcode,@pcenter,@pday,@pcatcode,@pcat_seqno,@pflag,@puserid,GETDATE())
        End    
        Else Begin
            update ad_cat_flow_sequence set cat_seqno= @pcat_seqno,updated_by=@puserid, updated_dt=getdate()
                where comp_code= @pcompcode and cat_code=@pcatcode and page_day=@pday and pub_center=@pcenter
        End
    End
 
end



@@@@@@@@@@@@@@@@@@@@@@@@@@  cat_seq_no.  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


##############################sumit ###############################################

ALTER PROCEDURE rpt_unregistered_client
   @pcompcode      as	varchar(20),
   @pbranchcode    as	varchar(20),
   @pdatefrom      as	datetime,
   @pdateto        as	datetime,
   @pdateformate   as	varchar(20),
   @padtype        as	varchar(20),
   @puomcode       as	varchar(20),
   @pdate_flag     as	varchar(20),--for on booking date B or Publish date P 
   @pextra1        as	varchar(200),
   @pextra2        as	varchar(200),
   @pextra3        as	varchar(200),
   @pextra4        as	varchar(200),
   @pextra5        as	varchar(200)
AS
   
BEGIN
	declare @v_query  varchar(8000)
    If @pbranchcode is null Begin
		set @pbranchcode=''
    End

    If @padtype is null Begin
		set @padtype=''
    End
    
    If @puomcode is null Begin
		set @puomcode=''
    End 
         
    set @v_query='SELECT distinct a."date_time" as "BKDATE",a."Client_code" AS "CLIENTNAME", "Client_address" AS "CLIENT_ADDRESS",
        a."cio_booking_id" AS "CIOID", b."Agency_Name" as "AGENCY_NAME", c."Adv_Type_Name" as "ADV_TYPE_NAME",
        (select "Package_Name" from combin_mast where "Comp_Code"='''+@pcompcode+''' and "Combin_Code"=(
        case when charindex('','',''abcdef'') >0 then substring(a."Package_code",1,charindex(a."Package_code",'','')-1)  
        else a."Package_code" end)) as "PACKAGE_NAME", e."Adv_Cat_Name" as "ADV_CAT_NAME", 
        a."Total_area" as "TOTAL_AREA", a."Rate_code" as "RATE_CODE",
        a."Card_rate" as "CARD_RATE", a."Bill_amount" as "BILL_AMOUNT", a."Gross_amount" as "GROSS_AMOUNT", 
        f."Uom_Name" as "UOM_NAME",g."Comp_Name" as "COMP_NAME"
    FROM tbl_booking_mast a,agency_mast b,adv_type_mast c,adv_cat_mast e,uom_mast f,comp_mst g,tbl_booking_insert i
    WHERE a."Comp_code" = g."Comp_Code" AND a."Comp_code" = i."Comp_Code" AND a."Comp_code" ='''+@pcompcode+''' and 
        a."cio_booking_id" = i."Cio_Booking_Id"'
	print(@v_query)
	         
    If @pdate_flag='B' Begin
        set @v_query=@v_query+' AND a."date_time" BETWEEN '''+convert(varchar(20),@pdatefrom,101)+''' AND '''+convert(varchar(20),@pdateto,101)+''' 
                    AND b."code_subcode" = a."Agency_sub_code" and 
                    not exists (SELECT ''x'' FROM cust_mast where "Cust_Code"=a."Client_code")
                    AND a."Ad_type_code" = c."Adv_Type_Code" AND (a."Ad_type_code" =isnull('''+@padtype+''',a."Ad_type_code") or '''''+'='+''''')
                    AND a."Uom_code" = f."Uom_Code" AND (a."Uom_code" =isnull('''+@puomcode+''',a."Uom_code")  or '''''+'='+''''')
                    AND a."Ad_cat_code" = e."Adv_Cat_Code"
                    AND (a."branch" = isnull('''+@pbranchcode+''',a."branch")  or '''''+'='+''''')'
	End                    
    Else Begin
        set @v_query=@v_query+' AND i."Insert_Date" BETWEEN '''+@pdatefrom+''' AND '''+convert(varchar(20),@pdateto,101)+''' 
                    AND b."code_subcode" = a."Agency_sub_code" and 
                    not exists (SELECT ''x'' FROM cust_mast where "Cust_Code"=a."Client_code")
                    AND a."Ad_type_code" = c."Adv_Type_Code" AND (a."Ad_type_code" =isnull('''+@padtype+''',a."Ad_type_code")  or '''''+'='+''''')
                    AND a."Uom_code" = f."Uom_Code" AND (a."Uom_code" =isnull('''+@puomcode+''',a."Uom_code")  or '''''+'='+''''')
                    AND a."Ad_cat_code" = e."Adv_Cat_Code"
                    AND (a."branch" = isnull('''+@pbranchcode+''',a."branch")  or '''''+'='+''''')';
    End  
    print('2')
    print('@pextra1')print(@pextra1)
    print(@v_query)
    
    if @pextra1 is not null or @pextra1<>'' Begin
        set @v_query=@v_query+' AND i."Cio_Booking_Id" in ('+@pextra1+') order by bkdate,cioid';
    End
    else Begin
        set @v_query=@v_query+' order by bkdate,cioid';
    end
    print('3')
    print(@v_query)
    print('4')
	exec(@v_query)
    
END
##############################sumit#########################################


/******************6658***********19march2012***********************/
                                                                     
                                                                     
                                                                     
                                             
CREATE PROCEDURE bindagencyfromadd
@compcode            as varchar(20),
@userid              as varchar(200),
@agency              as varchar(200),
@pubcenter           as varchar(200),
@p_agencyaddress     as varchar(2000)
As

Begin

declare @v_filter    varchar(20)
declare @v_pcenter   varchar(50)

    select distinct @v_filter=filter from login where "userid"=@userid
    
    If @v_filter='D' Begin--for district wise
        set @v_pcenter=@pubcenter;
    End
    Else if @v_filter='P' Begin--for Printing center wise
        set @v_pcenter=@pubcenter
    End
    Else Begin--for all
        set @v_pcenter='0'
    End
    
    If @v_pcenter = '0' or @v_pcenter is null or @v_pcenter='' Begin
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=@compcode and "City_Code"=agency_mast."City_Code")+'-'+"Add1"+'-'+"Add2"+'-'+"Add3"+'-'+"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=@compcode and
        isnull((SELECT top 1 status_name FROM STATUS_DETAIL WHERE "agency_code" + "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND GETDATE() between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name"+"Add1"+"Add2"+"Add3") like '%'+upper(@p_agencyaddress)+'%'  order by "Agency_Name" ;
	End
    Else Begin
        select  distinct  x."code_subcode" as "code_subcode",x."agency_name" as "agency_name",x.CITYNAME AS CITYNAME from
        (select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=@compcode and "City_Code"=agency_mast."City_Code")+'-'+"Add1"+'-'+"Add2"+'-'+"Add3"+'-'+"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=@compcode and
        isnull((SELECT top 1 status_name FROM STATUS_DETAIL WHERE "agency_code" + "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND getdate() between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name"+"Add1"+"Add2"+"Add3") like '%'+upper(@p_agencyaddress)+'%' and exists (select 'x' from branch_mst 
        where "Branch_Code"=@v_pcenter and "Dist_Code"=agency_mast."Dist_Code") and @v_filter='D' 
        union
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=@compcode and "City_Code"=agency_mast."City_Code")+'-'+"Add1"+'-'+"Add2"+'-'+"Add3"+'-'+"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=@compcode and
        isnull((SELECT top 1 status_name FROM STATUS_DETAIL WHERE "agency_code" + "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND getdate() between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name"+"Add1"+"Add2"+"Add3") like '%'+upper(@p_agencyaddress)+'%' and exists (select 'x' from branch_mst 
        where "Branch_Code"=agency_mast."Branch_code" and "pub_center"=@v_pcenter) and @v_filter='P') x
        order by "agency_name";
    End
END

/*************************************************************/

                                                                     
                                                                     
                                                                     
                                             
ALTER procedure bindagencyforbooking
    @compcode    as varchar(20),
    @userid      as varchar(50),
    @agency      as varchar(200),
    @pubcenter   as varchar(200)
as
declare @v_filter    varchar(20)
declare @v_pcenter   varchar(50)
Begin

    select distinct @v_filter=filter from login where "userid"=@userid
    
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
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=@compcode and "City_Code"=agency_mast."City_Code")+'-'+"Add1"+'-'+"Add2"+'-'+"Add3"+"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=@compcode and
        isnull((SELECT top 1 status_name FROM STATUS_DETAIL WHERE "agency_code" + "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND GETDATE() between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name") like '%'+UPPER(@agency)+'%'   order by "Agency_Name" ;
    End
    Else Begin
        select  distinct  x."code_subcode" as "code_subcode",x."agency_name" as "agency_name",x.CITYNAME AS CITYNAME from
        (select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=@compcode and "City_Code"=agency_mast."City_Code")+'-'+"Add1"+'-'+"Add2"+'-'+"Add3"+"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=@compcode and
        isnull((SELECT top 1 status_name FROM STATUS_DETAIL WHERE "agency_code" + "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND GETDATE() between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name") like '%'+UPPER(@agency)+'%' and exists (select 'x' from branch_mst where "Branch_Code"=@pubcenter and "Dist_Code"=agency_mast."Dist_Code") and @v_filter='D' 
        union
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=@compcode and "City_Code"=agency_mast."City_Code")+'-'+"Add1"+'-'+"Add2"+'-'+"Add3"+"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=@compcode and
        isnull((SELECT top 1 status_name FROM STATUS_DETAIL WHERE "agency_code" + "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND GETDATE() between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name") like '%'+UPPER(@agency)+'%' and exists (select 'x' from branch_mst 
        where "Branch_Code"=agency_mast."Branch_code" and "pub_center"=@v_pcenter) and @v_filter='P') x
        order by "agency_name" ;
    end
end


/***************************************************************/


ALTER procedure [dbo].[bind10agencyforbooking]
    @compcode    as varchar(20),
    @userid      as varchar(50),
    @agency      as varchar(200),
    @pubcenter   as varchar(200)
as
declare @v_filter    varchar(20)
declare @v_pcenter   varchar(50)
Begin

    select distinct @v_filter=filter from login where "userid"=@userid
    
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
        select  distinct top 10  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=@compcode and "City_Code"=agency_mast."City_Code")+'-'+"Add1"+'-'+"Add2"+'-'+"Add3"+"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=@compcode and
        isnull((SELECT top 1 status_name FROM STATUS_DETAIL WHERE "agency_code" + "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND GETDATE() between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name") like '%'+UPPER(@agency)+'%'   order by "Agency_Name" ;
    End
    Else Begin
        select  distinct top 10 x."code_subcode" as "code_subcode",x."agency_name" as "agency_name",x.CITYNAME AS CITYNAME from
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
/***************************************************************************************/


DROP PROCEDURE HT18JULY.BIND10AGENCYFORBOOKING;

CREATE OR REPLACE PROCEDURE HT18JULY.bind10agencyforbooking
(compcode in varchar2,
userid in varchar2,agency in varchar2,
pubcenter     in      varchar2,
p_Accounts OUT Cur_Type_New1.cursor_type
)
 is
    v_filter    varchar2(20);
v_pcenter   varchar2(50);
    begin
select distinct filter into v_filter from login where "userid"=userid;
    
    If v_filter='D' then--for district wise
        v_pcenter:=pubcenter;
    Elsif v_filter='P' then--for Printing center wise
        v_pcenter:=pubcenter;
    Else--for all
        v_pcenter:='0';
    End if;

    if v_pcenter = '0' or v_pcenter is null then
        open p_Accounts for
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name") like '%'||UPPER(agency)||'%' and ROWNUM <= 10  order by "Agency_Name" ;
    else
        open p_Accounts for
        select  distinct  x."code_subcode" as "code_subcode",x."agency_name" as "agency_name",x.CITYNAME AS CITYNAME from
        (select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name") like '%'||UPPER(agency)||'%' and exists (select 'x' from branch_mst where "Branch_Code"=pubcenter and "Dist_Code"=agency_mast."Dist_Code") and v_filter='D' and ROWNUM <= 10
        union
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name") like '%'||UPPER(agency)||'%' and exists (select 'x' from branch_mst 
        where "Branch_Code"=agency_mast."Branch_code" and "pub_center"=v_pcenter) and v_filter='P' and ROWNUM <= 10 ) x 
        order by "agency_name" ;
    end if;
end ;
/


/******************6658***********19march2012***********************/


/-----start-------------------6719 Avi-------20march2012----------------------------/
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
    @pextra2			as varchar(200)
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
			AND	d.Edition_Code  = m.Edition_Code AND	(b.pub_center  = @ppubcent OR	@ppubcent  is null OR	@ppubcent  ='')
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





                                            
create FUNCTION  GET_EDTN (@V_STR as varchar(4000),@V_dlm as varchar(100))  
returns varchar(2000)

AS  

BEGIN 
DECLARE @v_no as numeric(10) 
DECLARE @v_char as varchar(1);
DECLARE @v_stno as numeric(10);
DECLARE @v_cnt as numeric
set @v_cnt=0

set @v_no=len(@V_STR)
declare @cut as int
DECLARE @i INTEGER
	set @i  = 1 
	WHILE @i <= @v_no 
	BEGIN	
		set @v_char  = SUBSTRING(@v_str, @i, 1)
		IF @v_char = @V_dlm 
		BEGIN 
			set @v_stno  = @i 
		END 
		set @i = @i + 1
	END

set @cut=isnull(@v_stno,0)-1
select @v_cnt=count(*) from edition_mast 
where Edition_Alias=substring(@v_str,1,@cut)  and Edition_Type='Main Edition'

if isnull(@v_cnt,0)=1 begin
set @cut=isnull(@v_stno,0)-1
    set @v_str= substring(@v_str,1,@cut)
end
else
begin
    set @v_str= @v_str;
end

return @v_str
	   
END




/-----End-------------------6719-------20march2012----------------------------/


//--------------------------------start-----------------------------------//

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
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
@P_taxi_entry_type     as VARCHAR(1)


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
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=@p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=@p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=@p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM =@p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE =@p_CANCELLATION_CHARGE,taxi_entry_type=@P_taxi_entry_type 
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)

//--------------------------------------end-------------------------//

//-----------------------------start-------------------------------//


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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,Space_area,EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE,TAXI_ENTRY_TYPE
           FROM PREFERRENCES
          WHERE comp_code = @compcode

//-----------------------------------end--------------------------------------------///


//-----------------------------------ankit ------------pending for dummy--------------------------------///


alter PROCEDURE pending_for_dummy
@pcompcode       as varchar(20),
@ppubcenter      as varchar(2000), 
@padtype         as varchar(20),
@ppubdate        as datetime,
@ppublcode       as varchar(20),
@pedtncode       as varchar(20),
@psuplcode       as varchar(20),
@preason         as varchar(20),--1 for unapproval ,2 for unaduited 3 for material not upload
@pdateformat     as varchar(20),
@puserid         as varchar(20),
@pextra1         as varchar(2000),
@pextra2         as varchar(2000),
@pextra3         as varchar(2000),
@pextra4         as varchar(2000),
@pextra5         as varchar(2000)

as
declare @v_dt				datetime
declare @v_approval_flag	varchar(1)

if @ppubcenter='' begin
	set @ppubcenter =null
end
if @padtype='' begin
	set @padtype =null
end	
if @ppublcode='' begin
	set @ppublcode =null
end	
if @pedtncode='' begin
	set @pedtncode =null
end	
if @psuplcode='' begin
	set @psuplcode =null
end	
if @preason='' begin
	set @preason=null
end
    
    declare c1 cursor for
    select distinct x.comp_code AS "COMP_CODE",x.cio_booking_id AS "CIO_BOOKING_ID",x.date_time AS "DATE_TIME",x.agency_code AS "AGENCY_CODE",x.sub_agency_code AS "SUB_AGENCY_CODE" ,x.agency_name AS "AGENCY_NAME",
    x.client_name AS "CLIENT_NAME",x.package_code AS "PACKAGE_CODE",x.package_name AS "PACKAGE_NAME",
    x.ad_cat as "AD_CAT",x.category_name as "CATEGORY_NAME",x.edition as "EDITION",x.no_insert "NO_INSERT",
    x.discount as "DISCOUNT",x."AUDIT" AS "AUDIT",x.file_name AS "FILE_NAME",x.reason_type as "REASON_TYPE" from
    (select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    isnull((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",NULL AS "EDITION",1 "NO_INSERT",
    isnull(m."Discount",0)+isnull(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",NULL AS "FILE_NAME",'1' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=@pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and i."Insert_Date"=@ppubdate and 
            m."Ad_type_code"=isnull(@padtype,m."Ad_type_code") and i."Pub_Cent_Code"=isnull(@ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=isnull(@ppublcode,i."Publication_Code") and
            i."Edition_Code"=isnull(@pedtncode,i."Edition_Code") and i."Supp_Code"=isnull(@psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','publish','audit by rate','billed','hold') and
            (isnull(m."Discount",0)+isnull(m."Special_discount",0))>0 and isnull(m.app_status,'N')='N' and @v_approval_flag='D' 
    union
    select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    isnull((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",NULL AS "EDITION",1 "NO_INSERT",
    isnull(m."Discount",0)+isnull(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",NULL AS "FILE_NAME",'2' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=@pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and i."Insert_Date"=@ppubdate and 
            m."Ad_type_code"=isnull(@padtype,m."Ad_type_code") and i."Pub_Cent_Code"=isnull(@ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=isnull(@ppublcode,i."Publication_Code") and
            i."Edition_Code"=isnull(@pedtncode,i."Edition_Code") and i."Supp_Code"=isnull(@psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','publish','audit by rate','billed','hold') and
            (isnull(m."Discount",0)+isnull(m."Special_discount",0))>0 and m."audit" is null and isnull(m.app_status,'N')='Y' and @v_approval_flag='D'
    union
    select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    isnull((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",NULL AS "EDITION",1 "NO_INSERT",
    isnull(m."Discount",0)+isnull(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",NULL AS "FILE_NAME",'2' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=@pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and i."Insert_Date"=@ppubdate and 
            m."Ad_type_code"=isnull(@padtype,m."Ad_type_code") and i."Pub_Cent_Code"=isnull(@ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=isnull(@ppublcode,i."Publication_Code") and
            i."Edition_Code"=isnull(@pedtncode,i."Edition_Code") and i."Supp_Code"=isnull(@psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','publish','audit by rate','billed','hold') and
            m."audit" is null and @v_approval_flag='N'
    union
    select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    isnull((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",i."Edition" AS "EDITION",i."No_Insert" "NO_INSERT",
    isnull(m."Discount",0)+isnull(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",i."File_Name" AS "FILE_NAME",'3' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=@pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and i."Insert_Date"=@ppubdate and 
            m."Ad_type_code"=isnull(@padtype,m."Ad_type_code") and i."Pub_Cent_Code"=isnull(@ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=isnull(@ppublcode,i."Publication_Code") and
            i."Edition_Code"=isnull(@pedtncode,i."Edition_Code") and i."Supp_Code"=isnull(@psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','publish','audit by rate','billed','hold') and
            m."audit" is not null and i."File_Name" is null) x where reason_type=isnull(@preason,reason_type)
            order by reason_type,date_time,cio_booking_id,edition;        
declare @v1_comp_code		varchar(500)
declare @v1_cio_booking_id	varchar(500)
declare @v1_date_time		datetime
declare @v1_agency_code		varchar(500)
declare @v1_sub_agency_code varchar(500)
declare @v1_agency_name		varchar(500)
declare @v1_client_name		varchar(500)
declare @v1_package_code	varchar(500)
declare @v1_package_name	varchar(500)
declare @v1_ad_cat			varchar(500)
declare @v1_category_name	varchar(500)
declare @v1_edition			varchar(500)
declare @v1_no_insert		varchar(500)
declare @v1_discount		varchar(500)
declare @v1_AUDIT			varchar(500)
declare @v1_file_name		varchar(500)
declare @v1_reason_type		varchar(500)
declare @v_rec_count		int
BEGIN

	
CREATE TABLE #TEMP_AD_BILLS_REPORT
( CIOID             VARCHAR(50),
  AGENCY            VARCHAR(50),
  CLIENT            VARCHAR(200),
  RONO              VARCHAR(40),
  RODATE            DATETIME,
  ADCAT             VARCHAR(500),
  PACKAG            VARCHAR(500),
  NOINSERT          INT,
  COMP_CODE         VARCHAR(10),
  PACKAGE_CODE      VARCHAR(500),
  AG_MAIN_CODE      VARCHAR(10),
  AG_SUB_CODE       VARCHAR(10),
  CLIENTCD          VARCHAR(200),
  PAGE_TYPE         VARCHAR(100),
  PAGE_NO           NUMERIC(10),
  padtype			VARCHAR(100))
  
    set @v_approval_flag='N'
    
    select @v_approval_flag=relauthreqon from preferrences where "comp_code"=@pcompcode;
    
    Open c1;

        fetch NEXT FROM c1 INTO @v1_comp_code ,@v1_cio_booking_id ,@v1_date_time, @v1_agency_code , @v1_sub_agency_code,@v1_agency_name,
			@v1_client_name,@v1_package_code,@v1_package_name ,@v1_ad_cat ,@v1_category_name ,@v1_edition ,@v1_no_insert ,
			@v1_discount ,@v1_AUDIT ,@v1_file_name ,@v1_reason_type,@v_rec_count
		WHILE (@@FETCH_STATUS = 0) BEGIN

        set @v_rec_count=isnull(@v_rec_count,0)+1;
        
        insert into #TEMP_AD_BILLS_REPORT
				(cioid,				rodate,		client,			package_code,		adcat,		packag,		 comp_code,    padtype,  ag_main_code,   ag_sub_code,        noinsert
        ,clientcd,page_type,page_no)
		values(@v1_cio_booking_id,@v1_date_time,@v1_client_name,@v1_package_code,@v1_ad_cat,@v1_package_name,@v1_comp_code,@padtype,@v1_agency_code,@v1_sub_agency_code,@v1_no_insert
			,@v1_edition,@v1_reason_type,@v_rec_count);        
       -- values(@v1_cio_booking_id,@v1_date_time,@v1_client_name,@v1_agency_name,@v1_category_name,@v1_package_name,@v1_comp_code,@padtype,@v1_agency_code,@v1_sub_agency_code,@v1_no_insert,@v1_edition,@v1_reason_type,@v_rec_count);
        
        fetch NEXT FROM c1 INTO @v1_comp_code ,@v1_cio_booking_id ,@v1_date_time, @v1_agency_code , @v1_sub_agency_code,@v1_agency_name,
			@v1_client_name,@v1_package_code,@v1_package_name ,@v1_ad_cat ,@v1_category_name ,@v1_edition ,@v1_no_insert ,
			@v1_discount ,@v1_AUDIT ,@v1_file_name ,@v1_reason_type,@v_rec_count
    End
    Close c1;        
    deallocate c1;
    
    select comp_code as "COMP_CODE",cioid as "BKID",rodate as "BK_DATE",client as "CLIENT_NAME"
    ,package_code as "AGENCY_NAME",adcat as "CAT_NAME",
    packag as "PACKAGE_NAME",padtype as "AD_TYPE",ag_main_code as "AG_MAIN_CODE"
    ,ag_sub_code as "AG_SUB_CODE",noinsert as "NOINSERT",
    clientcd as "EDITION",page_type as "REASON_TYPE",page_no as "REC_NO"
    from #temp_ad_bills_report order by rec_no;
    
    drop table #TEMP_AD_BILLS_REPORT;
END


//-----------------------------------ankit ------------pending for dummy--------------------------------///

/**************mimoh 22 march ***************qbc procedure*****************************/



ALTER PROCEDURE [dbo].[chkrono]
	@compcode                                 VARCHAR(4000) ,
	@userid                                   VARCHAR(4000) ,
	@agency                                   VARCHAR(4000) ,
	@p_rono                                   VARCHAR(4000) 
AS 
	BEGIN
		SET NOCOUNT ON
		
		DECLARE @cnt_agen                                 FLOAT 
		DECLARE @CNT                                      FLOAT 
		

						SELECT RO_No
						FROM  tbl_booking_mast 
						WHERE	RO_No  = @p_rono
						 AND	Comp_code  = @compcode
						 AND	Agency_sub_code  = @agency
		
						SELECT @cnt_agen  =  COUNT(*)
						FROM  ro_book_allotment 
						WHERE	 comp_code  = @compcode
						 AND	code_subcode  = @agency
		
						SELECT @CNT  =  COUNT(*)
						FROM  ro_book_allotment 
						WHERE	 comp_code  = @compcode
						 AND	code_subcode  = @agency
						 AND	(CONVERT(NUMERIC(8, 2), @p_rono)  BETWEEN rono_from  AND  rono_till
						 OR	rono_from  IS NULL
						 OR	rono_till  IS NULL)
		
		IF @cnt_agen > 0 
		BEGIN 
			IF @CNT > 0 
			BEGIN 
				
			
								SELECT *
								FROM  ro_book_allotment 
								WHERE	 comp_code  = @compcode
								 AND	code_subcode  = @agency
								 AND	(CONVERT(NUMERIC(8, 2), @p_rono)  BETWEEN rono_from  AND  rono_till
								 OR	rono_from  IS NULL
								 OR	rono_till  IS NULL)
				
			END
			ELSE
			BEGIN 
				
				
								SELECT
										 'N' res,
										 'NOT IN RO RANGE' res1
				
			END
   
		END
		ELSE
		BEGIN 
			
		
							SELECT
									 'Y' res,
									 'AGENCY NOT ENTERED' res1
			
		END
   

		SET NOCOUNT OFF

	END



/**************mimoh 22 march ***************qbc procedure*****************************/



/******************************mimoh mahajan 22 march 2012****************************************6982*************************/


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
CLIENT_TYPE VARCHAR(5),
TRANSLATION_CODE VARCHAR(25), 
TRANSLATION_PREMIUM FLOAT,
APP_USER VARCHAR(50),
CANCELLATION_CHARGE  VARCHAR(1)
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
REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,APP_USER,CANCELLATION_CHARGE
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
 end as REVISE_DATE,CLIENT_TYPE,
 CASE @dateformat
	WHEN 'mm/dd/yyyy' then convert(DATETIME,#TEMPBOOKING_MAST.Creation_datetime,101)
	WHEN 'dd/mm/yyyy' then convert(DATETIME,#TEMPBOOKING_MAST.Creation_datetime,103)
	WHEN 'yyyy/mm/dd' then convert(DATETIME,#TEMPBOOKING_MAST.Creation_datetime,111)
 end as
 CREATION_DATETIME,TRANSLATION_CODE, TRANSLATION_PREMIUM,
 (SELECT CHARGES_TYPE FROM  AD_CHARGE_MAST WHERE AD_CHARGE_MAST.CHARGE_CODE=#TEMPBOOKING_MAST.TRANSLATION_CODE and COMP_CODE=@compcode) AS TRANSLATION_TYPE,
 (SELECT username FROM  LOGIN WHERE LOGIN.userid=#TEMPBOOKING_MAST.APP_USER and LOGIN.COM_CODE=@compcode) as APP_USER,CANCELLATION_CHARGE
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


































/******************************mimoh mahajan 22 march 2012****************************************6982*************************/




/************************mimoh6992***********************/







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
@P_ApprovalWith          as VARCHAR(1)

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
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=@p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=@p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=@p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM =@p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE =@p_CANCELLATION_CHARGE,taxi_entry_type=@P_taxi_entry_type,APPROVAL_WITH =@P_ApprovalWith 
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)
/**************************************************************************************/


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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,Space_area,EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE,TAXI_ENTRY_TYPE,APPROVAL_WITH 
           FROM PREFERRENCES
          WHERE comp_code = @compcode



/************************mimoh6992***********************/


/*********start***************ankit create user ***********************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[bindagencynameonkey]
@compcode as varchar(8),
@userid as varchar(8),
@agency varchar(1000)
 AS

--select  distinct  Agency_Code,agency_name from Agency_mast where comp_code=@compcode and userid=@userid and type='P'

select  distinct  SUB_Agency_Code,Agency_Name,code_subcode from Agency_mast where comp_code=@compcode  and agency_name like '%'+@agency+'%'







set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





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
      ,(select NAME+''(''+EMP_CODE+'')'' from HR_EMP_MST where COMP_CD='''+@com_code+''' AND EMP_CODE=login.HR_CODE)AS HR_CODE,(select Agency_Name from agency_mast where  agency_mast.code_subcode=LOGIN.Agency_code)as AGENCY_NAME from login where   admin!=''yes'''  --username='''+@username+''''
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
      ,(select NAME+''(''+EMP_CODE+'')'' from HR_EMP_MST where COMP_CD='''+@com_code+''' AND EMP_CODE=login.HR_CODE)AS HR_CODE,(select Agency_Name from agency_mast where  agency_mast.code_subcode=LOGIN.Agency_code)as AGENCY_NAME from login where admin=''yes'''

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




/*********end***************ankit create user ***********************/



//////////////////////////////////////////27/03/2012//////////////////////////////////////////////


/////////////////////////for insert 

ALTER PROCEDURE  [dbo].[websp_editorinsert]

@PubName as varchar(8),
@CityName as varchar(8),
@EditonCode as varchar(8),
@EditionName as varchar(50),
@Alias as varchar(1000),
@userid as varchar(8),
@compcode as varchar(8),
@country as varchar(8),
@circulation as varchar(8),
@uom as varchar(500),
@column as varchar(8),
@height as varchar(8),
@width as varchar(8),
@area as varchar(15),
@periodicity as varchar(8),
@gutter as varchar(8),
@col_space as varchar(8),
@hr as varchar(8),
@min as varchar(8),
@prod as varchar(8),
@type as varchar(20),
@noofcol as varchar(5),
@printcent as varchar(50),
@psegmentcod as varchar(50)

AS
declare @query as varchar(900)
--insert into  EDITION_MAST(Pub_Code,City_Code,Edition_Name,Edition_Alias,Edition_Code,Comp_Code,UserId,Country_Code,No_Of_Circulation,UOM_Code,No_Of_Columns,Size_Height,Size_Width,Edition_Area,Preodicity_Code) values (@PubName,@CityName,@EditionName,@Alias,@EditonCode,@compcode,@userid,@country,@circulation,@uom,@column,@height,@width,@area,@periodicity)


set @query='insert into  EDITION_MAST(Pub_Code,City_Code,Edition_Name,Edition_Alias,Edition_Code,Comp_Code,UserId,Country_Code,No_Of_Circulation,UOM_Code,No_Of_Columns,Size_Height,Size_Width,Edition_Area,Preodicity_Code,Gutter_Space,Column_Space,RO_hr,RO_min,Production,Edition_Type,No_Of_Collumn,PRINT_CENT,SEGMENT_CODE) values ('''+@PubName+''','''+@CityName+''','''+@EditionName+''','''+@Alias+''','''+@EditonCode+''','''+@compcode+''','''+@userid+''','''+@country+''','''+@circulation+''','''+@uom+''','''+@column+''','''+@height+''','''+@width+''','''+@area+''','''+@periodicity+''','''+@gutter+''','''+@col_space+''','''+@hr+''','''+@min+''','''+@prod+''','''+@type+''','''+@noofcol+''','''+@printcent+''','''+@psegmentcod+''')'


print(@query)
exec(@query)





////////////////////for modify

ALTER PROCEDURE  [dbo].[websp_editormodify]

@PubName as varchar(8),
@CityName as varchar(8),
@EditonCode as varchar(8),
@EditionName as varchar(50),
@Alias as varchar(50),
@userid as varchar(8),
@compcode as varchar(8),
@country as varchar(8),
@circulation as varchar(8),
@uom as varchar(500),
@column as varchar(8),
@height as varchar(8),
@width as varchar(8),
@area as varchar(15),
@periodicity as varchar(8),
@gutter as varchar(8),
@col_space as varchar(8),
@hr as varchar(8),
@min as varchar(8),
@prod as varchar(8),
@type as varchar(20),
@noofcol as varchar(5),
@printcent as varchar(50),
@psegmentcod as varchar(50)

AS

declare @query as varchar (1000)
declare @query1 as varchar (1000)

--insert into EDITION_MAST(Pub_Code,Sup_Code,City_Code,Edition_Name,Edition_Alias,Edition_Code,Comp_Code,UserId) values (@PubName,@SuppName,@CityName,@EditionName,@Alias,@EditonCode,@compcode,@userid)

set @query='update EDITION_MAST set  Pub_Code='''+@PubName+''',City_Code='''+@CityName+''',Edition_Name='''+@EditionName+''',Edition_Alias='''+@Alias+''',Edition_Code='''+@EditonCode+''',Comp_Code='''+@compcode+''',UserId='''+@userid+''',Country_Code='''+@country+'''  ,No_Of_Circulation='''+@circulation+''' ,UOM_Code='''+@uom+''' ,No_Of_Columns='''+@column+''',Size_Height='''+@height+''',Size_Width='''+@width+''',Edition_Area='''+@area+''' , Preodicity_Code='''+@periodicity+''' , Gutter_Space='''+@gutter+''', Column_Space='''+@col_space+''', RO_hr='''+@hr+''' , RO_min='''+@min+''' , Production='''+@prod+''', Edition_Type='''+@type+''',No_Of_Collumn='''+@noofcol+''',PRINT_CENT='''+@printcent+''', segment_code='''+@psegmentcod+''' where  Comp_Code='''+@compcode+''' and Edition_Code='''+@EditonCode+''' '--and UserId='''+@userid+''' '
--set @query1='update EDITION_MASTTEMP set  Pub_Code='''+@PubName+''',City_Code='''+@CityName+''',Edition_Name='''+@EditionName+''',Edition_Alias='''+@Alias+''',Edition_Code='''+@EditonCode+''',Comp_Code='''+@compcode+''',UserId='''+@userid+''',Country_Code='''+@country+''' ,No_Of_Circulation='''+@circulation+''' ,UOM_Code='''+@uom+''' ,No_Of_Columns='''+@column+''',Size_Height='''+@height+''',Size_Width='''+@width+''',Edition_Area='''+@area+''',and Preodicity_Code='''+@periodicity+''' where  Comp_Code='''+@compcode+''' and UserId='''+@userid+''' and Edition_Code='''+@EditonCode+''' and Preodicity_Code='''+@periodicity+''''

print(@query)
--print(@query1)
exec(@query)
--exec(@query1)

////////////////////////for execute

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
    PRINT_CENT varchar(50)
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


///////////////////////////////////////////////27/03/2012 end of insert modify and execute procedures//////////////////////////////

/*****mimoh 28 march 2012*********7061*************************************************/






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
@p_Credit_Account_Bank as varchar(10)

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
BANK_CHG_AUTO_REASON=@p_Bank_Reason ,BANK_CHG_DB_CDP=@p_Debit_Account_Bank ,BANK_CHG_CR_CDP=@p_Credit_Account_Bank 

 
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)

/************************************************************************************************************/






















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
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,Space_area,EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE,TAXI_ENTRY_TYPE,APPROVAL_WITH,   TDS_AUTO_CN,TDS_AUTO_REASON,TDS_DB_CDP,TDS_CR_CDP,SER_TAX_AUTO_CN,SER_TAX_AUTO_REASON,SER_TAX_DB_CDP,SER_TAX_CR_CDP,PKK_AUTO_CN,PKK_AUTO_REASON,PKK_DB_CDP,PKK_CR_CDP,BANK_CHG_AUTO_CN,BANK_CHG_AUTO_REASON,BANK_CHG_DB_CDP,BANK_CHG_CR_CDP 
           FROM PREFERRENCES
          WHERE comp_code = @compcode








/*********************************************/

create FUNCTION  [dbo].[AD_GET_REASONNAME] 
(@pcompcode VARCHAR(10),@preason_code varchar(20))  returns varchar(200)
AS  

BEGIN 
DECLARE @v_name VARCHAR(200)
select @v_name=reason_name from reason_mst where Comp_Code=@pcompcode and reason_code=@preason_code

if @v_name is null or @v_name='' begin 
	set @v_name=null
end

RETURN isnull(@v_name,'');
END




























/*****mimoh 28 march 2012*********7061*************************************************/


/*****ankit 29 march 2012*********7016*************************************************/


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[pagepremiumreport]    Script Date: 03/29/2012 12:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER procedure [dbo].[pagepremiumreport]
(
@page as VARCHAR(50)=NULL,
@position as VARCHAR(50)=NULL,
@agname as VARCHAR(500)=NULL,
@clientname as VARCHAR(500)=NULL,
@adtype1 as VARCHAR(50),
@Adcategory as VARCHAR(500),
@fromdate as VARCHAR(20),
@dateto as VARCHAR(20),
@compcode as  VARCHAR(10),
@pub_name as VARCHAR(200),
@pub_cent as  VARCHAR(200),
@status as VARCHAR(50)=NULL,
@edition as VARCHAR(100),
@dateformat as VARCHAR(20),
@hold as  VARCHAR(20)=NULL,
@descid as VARCHAR(20)=NULL,
@ascdesc as VARCHAR(20)=NULL,
@agtype as varchar(50)=null,
@puserid as varchar(10)=null,
@chk_access as varchar(2)
)
as
declare @query1 VARCHAR(8000)
declare @can VARCHAR(8)
begin
set @can='Cancel'

create table #Results(SegmentNum INT, Edition_Name  VARCHAR(255))
insert into #Results select * from dbo.Fn_Splitfield(@Adcategory,',')

/*set	@query1='
SELECT TBL_BOOKING_MAST.cio_booking_id AS "CIOID",
AGENCY_MAST.Agency_Name AS "Agency",
ISNULL((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS "Client",
PUB_CENT_MAST.Pub_Cent_name AS "City",PUB_MAST.Pub_Name AS "Pub",
(select COMBIN_MAST.Package_Name from combin_mast where COMBIN_MAST.Combin_Code  in(TBL_BOOKING_MAST.Package_code))AS "Package",
Ad_size_height AS "Depth",
Ad_size_width AS "Width",
round(TBL_BOOKING_MAST.Total_area,2) AS "Area",
COL_MAST.Col_Alias AS "Hue",
(SELECT ADVPOS_TYPE_MAST.Pos_Type_Alias FROM ADVPOS_TYPE_MAST WHERE TBL_BOOKING_INSERT.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code) AS "Page",
No_Insert AS "Ins.No.",
CASE '''+@dateformat+'''
 WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),Insert_Date,103)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),Insert_Date,101)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),Insert_Date,111)  END AS "Ins.date" ,
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),TBL_BOOKING_MAST.Creation_datetime,103)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),TBL_BOOKING_MAST.Creation_datetime,101)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),TBL_BOOKING_MAST.Creation_datetime,111)  END AS "BookDate"
,RO_No AS "RoNo.",
CASE ro_status
WHEN ''2'' THEN ''Reservation''
WHEN ''1'' THEN ''Confirm''END AS "RoStatus",
 ADV_TYPE_MAST.Adv_Type_Name AS "AdType",
 Rate_code AS "RateCode",
 TBL_BOOKING_INSERT.Card_Rate AS "CardRate",
 ISNULL(tbl_booking_mast.Agrred_rate,tbl_booking_mast.Card_rate) AS "AgreedRate",
dbo.Fn_Deviatio(TBL_BOOKING_INSERT.Card_Rate,TBL_BOOKING_MAST.Agrred_rate) AS "Deviation(%)",
TBL_BOOKING_INSERT.Insert_Status AS "Status",
(SELECT ADVPOS_PREM_MAST.premiumname FROM ADVPOS_PREM_MAST WHERE TBL_BOOKING_INSERT.Premium1=ADVPOS_PREM_MAST.Premiumcode) AS  "PagePremium",
(SELECT ADVPOS_TYPE_MAST.Pos_Type FROM ADVPOS_TYPE_MAST WHERE TBL_BOOKING_INSERT.Page_Post  =ADVPOS_TYPE_MAST.Pos_Type_Code) AS  "PosPremium",
(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=TBL_BOOKING_MAST."Ad_cat_code") AS "AdCat",
TBL_BOOKING_MAST."Bullet_code" AS "BulletPremium" ,
TBL_BOOKING_MAST."Page_position_code" AS "PositionPremium" ,
TBL_BOOKING_MAST."Page_prem" AS "PagePremiumcd" ,
Caption AS "Cap",
Key_no AS "Key"
,TBL_BOOKING_insert.Gross_Rate  AS "Amt",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast.Uom_code=uom_mast.Uom_Code)as "uom",
TBL_BOOKING_INSERT.Edition as "edition",
(SELECT dbo.InitCap(Comp_Name) from comp_mst where Comp_Code='''+@compcode+''') AS "companyname",
getdate() as "Rundate"
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,
PUB_MAST,PUB_CENT_MAST,ADV_TYPE_MAST ,
COL_MAST
 WHERE TBL_BOOKING_MAST.Comp_code='''+@Compcode+''' 
 AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
 AND TBL_BOOKING_MAST.Agency_code=AGENCY_MAST.Agency_Code 
 AND TBL_BOOKING_MAST.Ad_type_code=ADV_TYPE_MAST.Adv_Type_Code
 AND TBL_BOOKING_INSERT.Col_Code=COL_MAST.Col_Code  AND
 TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode
AND TBL_BOOKING_INSERT.Publication_Code = PUB_MAST.Pub_Code
AND TBL_BOOKING_INSERT.Pub_Cent_Code=PUB_CENT_MAST.Pub_cent_Code
and tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''')'*/

set	@query1='SELECT TBL_BOOKING_MAST.cio_booking_id AS "CIOID",
TBL_BOOKING_INSERT.Edition as "edition",
CASE '''+@dateformat+'''
 WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),Insert_Date,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),Insert_Date,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),Insert_Date,111)  END AS "Ins.date" ,
AGENCY_MAST.Agency_Name AS "Agency",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS "Client",
(select COMBIN_MAST.Package_Name from combin_mast where COMBIN_MAST.Combin_Code  in(TBL_BOOKING_MAST.Package_code))AS "Package",
round(TBL_BOOKING_insert.Size_Book,2) AS "Area",
TBL_BOOKING_INSERT.Col_Code AS "Hue",
(SELECT ADVPOS_TYPE_MAST.Pos_Type_Alias FROM ADVPOS_TYPE_MAST WHERE TBL_BOOKING_INSERT.Page_Post=ADVPOS_TYPE_MAST.Pos_Type_Code) AS "Page",
TBL_BOOKING_INSERT.Premium1 AS "PagePremiumcd" ,
TBL_BOOKING_MAST.Bullet_code AS "BulletPremium" ,
tbl_booking_insert.Page_Post AS "PositionPremium" ,
RO_No AS "RoNo.",
CASE "ro_status"
WHEN ''2'' THEN ''Reservation''
WHEN ''1'' THEN ''Confirm''END AS "RoStatus",
(SELECT ADV_CAT_MAST.Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code=tbl_booking_insert.Ad_Cat) AS "AdCat",
Rate_code AS "RateCode",
 isnull(tbl_booking_mast.Agrred_rate,tbl_booking_mast.Card_rate) AS "AgreedRate",
TBL_BOOKING_MAST.Caption AS "Cap",
Key_no AS "Key",
TBL_BOOKING_insert.Bill_Amt  AS "Amt",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast.Uom_code=uom_mast.Uom_Code and tbl_booking_mast.comp_code=uom_mast.comp_code)as "uom",
(SELECT dbo.initcap(Comp_Name) from comp_mst where Comp_Code='''+@compcode+''') AS "companyname",
getdate() as "Rundate"
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST
 WHERE TBL_BOOKING_MAST.Comp_code='''+@Compcode+'''
 AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
 AND TBL_BOOKING_MAST.Agency_code=AGENCY_MAST.Agency_Code
 AND TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode
  AND TBL_BOOKING_MAST.cio_booking_id not in(select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)
 and  lower(Insert_Status) !=''cancel''
and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )'

IF(@agname IS NOT NULL and @agname<>'')
begin
set @query1=@query1 +'  and  TBL_BOOKING_MAST.Agency_code ='''+@agname +''''
END 

IF(@pub_cent IS NOT NULL and @pub_cent<>'')
begin
set @query1=@query1 +'  and tbl_booking_insert.Pub_Cent_Code='''+@pub_cent+''''
END 

IF(@clientname IS NOT NULL and @clientname<>'')
begin
set @query1=@query1 +'  and TBL_BOOKING_MAST.Client_code='''+@clientname+''''
END 

IF(@adtype1  IS NOT NULL and @adtype1<>'')
begin
set @query1=@query1 +'  and TBL_BOOKING_MAST.Ad_type_code='''+@adtype1+''''
END 

IF(@Adcategory  IS NOT NULL and @Adcategory <>'')
begin
set @query1=@query1 +'and tbl_booking_insert.Ad_Cat in(select EDITION_NAME from #Results  )'
END 

IF(@pub_name  IS NOT NULL and @pub_name<>'')
begin
set @query1=@query1 +'  and TBL_BOOKING_INSERT.Publication_Code='''+@pub_name+''''
END

IF(@status  IS NOT NULL and @status <>'')
begin
set @query1=@query1 +'  and TBL_BOOKING_INSERT.Insert_Status='''+@status+''''
END 

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @fromdate<>'' and  @dateto<>'')
begin
set @query1=@query1 +' and tbl_booking_insert.Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
END 

IF(@edition IS NOT NULL or @edition<>'')
begin
set @query1=@query1 +'  and tbl_booking_insert.Edition_Code='''+@edition+''''
END 

IF(@page  IS NOT NULL or @page<>'')
begin
set @query1=@query1 +'  and tbl_booking_insert.Premium1='''+@page+''''
END 

IF(@position IS NOT NULL and @position<>'')
begin
set @query1=@query1 +'  and tbl_booking_insert.Page_Post='''+@position+''''
END 

IF((@agtype IS NOT NULL and @agtype<>'') AND (@agtype <> 'Package') AND (@agtype <> 'Solo'))
begin
set @query1=@query1 +' and  TBL_BOOKING_mast.Agency_type='''+upper(@agtype)+''''
END 

IF(@descid IS NOT  NULL and @descid <>'')
begin
set @query1=@query1 +'  order by '''+@descid+''''
set @query1=@query1 + ''+@ascdesc+''	
end
ELSE
set @query1=@query1 +'   order by tbl_booking_insert.Insert_Date,TBL_BOOKING_MAST.cio_booking_id'
END 
print(@query1)
exec(@query1)

/*****ankit 29 march 2012*********7016**********************end***************************/


/*****ankit 29 march 2012*********7077**********************start***************************/

ALTER PROCEDURE [dbo].[pub_Reportnew]
(
@agname as VARCHAR(50)= NULL,
@Adtype as VARCHAR(50)= NULL,
@fromdate as VARCHAR(20)= NULL,
@dateto as VARCHAR(20)= NULL,
@compcode as VARCHAR(10)= NULL,
@pub_cent as VARCHAR(50)= NULL,
@category as VARCHAR(50)= NULL,
@edition as VARCHAR(50)= NULL,
@dateformat as VARCHAR(20)= NULL,
@Region as VARCHAR(50)= NULL,
@product as VARCHAR(50)= NULL,
@agency as VARCHAR(50)= NULL,
@descid as VARCHAR(10)= NULL,
@ascdesc as VARCHAr(10)= NULL,
@agcat as varchar(50)=null,
@adcheck as varchar(10)=null,
@executive as varchar(50)=null,
@puserid as varchar(10)=null,
@chk_access as varchar(2)
)

as
declare @query1 VARCHAR(8000)
declare @grpnew VARCHAR(100)
declare @grpne VARCHAR(100)
declare @grpst VARCHAR(100)
declare @prefer    as VARCHAR(10)
BEGIN
select distinct @prefer= AGENCY_RETAINER_COMM from preferrences where comp_code=@compcode


if(@adcheck=1)
begin

set @query1='SELECT distinct TBL_BOOKING_MAST.cio_booking_id AS "CIOID",
AGENCY_MAST.Agency_Name AS "Agency",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE CUST_MAST.comp_code=tbl_booking_mast.comp_code and Cust_Code=Client_code),Client_code)  AS "Client",
PUB_MAST.Pub_Name AS "Publication",
round(TBL_BOOKING_MAST.Total_area,2) AS "Area",
(SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE BRANCH_MST.comp_code=tbl_booking_mast.comp_code and tbl_booking_mast.Revenue_center =BRANCH_MST.Branch_Code )AS "RevenueCenter",
tbl_booking_mast.Rate_code as "Rate",
TBL_BOOKING_MAST.Page_prem as "Premium",
tbl_booking_mast.Bill_remarks as "BillRemark",
tbl_booking_mast.Color_code as "Color",
tbl_booking_mast.Ad_cat_code  as "Category",
tbl_booking_mast.Ad_sub_cat_code as "SubCategory",
tbl_booking_mast.Package_code as "Package",
isnull(tbl_booking_mast.Agrred_rate,tbl_booking_mast.Card_rate ) AS "AgreedRate",
(tbl_booking_insert.Bill_amt) AS "BillAmt",
tbl_booking_mast.Trade_disc as "AgencyComm",
tbl_booking_mast.ADD_AGENCY_COMM as "AddlAgencyTD",
(SELECT dbo.initcap(Comp_Name) from comp_mst where Comp_Code='''+@compcode+''') AS "companyname",
getdate() as "Rundate"
,tbl_booking_mast.Booking_type as "booktype"
,tbl_booking_insert.BILL_NO as "Bill_No"
,CASE '''+@dateformat+'''
 WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),(CAST( FLOOR( CAST(  tbl_booking_insert.BILL_DATE AS FLOAT ) ) AS DATETIME )),101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),(CAST( FLOOR( CAST(  tbl_booking_insert.BILL_DATE AS FLOAT ) ) AS DATETIME )),103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),(CAST( FLOOR( CAST(  tbl_booking_insert.BILL_DATE AS FLOAT ) ) AS DATETIME )),111)END AS "Bill_Date"

,(select city_mst.City_Name from city_mst where city_mst.City_Code=agency_mast.City_Code and agency_mast.Comp_Code=city_mst.Comp_Code) as "Agency_City"
,TBL_BOOKING_MAST.Agency_address AS "A_Place"
,TBL_BOOKING_MAST.Client_address AS "C_Place"
,UOM_MAST.Uom_Name  AS "Uom"
,tbl_booking_mast.Page_no as "Page_no"
,tbl_booking_mast.Card_rate as "Card_Rate"
,tbl_booking_mast.Discount_per as Discper
,tbl_booking_mast.Special_disc_per as Spdiscper
,tbl_booking_mast.Space_disc_per as Spacediscper
,tbl_booking_mast.Special_charges as Specialcharge
,isnull((tbl_booking_insert.Bill_amt-isnull(dbo.fun_actual('''+ @compcode +''',isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),isnull(tbl_booking_mast.RETAINER,''0''),isnull(tbl_booking_insert.Gross_rate,''0''),'''+@prefer+''',''2'' ),''0'')  ),''0'') as ActualBusiness
,isnull((isnull(tbl_booking_insert.Gross_rate,''0'')*isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'')/100),''0'') as "AgencyAddlTDAmt"
,(isnull(tbl_booking_insert.Gross_rate,''0'')* isnull(tbl_booking_mast.Trade_disc,''0'' )/100 )as "AgencyTDAmt"
,CASHDISCOUNT as "Cash_Disc"
,isnull(tbl_booking_insert.Gross_rate,''0'') as Grossamt
,tbl_booking_mast.Ad_size_height as height
,tbl_booking_mast.Ad_size_width as width

FROM TBL_BOOKING_MAST,
TBL_BOOKING_INSERT,
AGENCY_MAST ,
PUB_MAST,uom_mast
WHERE TBL_BOOKING_MAST.Comp_code='''+@compcode+''' AND
UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code  and
TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id AND
TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND  
TBL_BOOKING_INSERT.Publication_Code = PUB_MAST.Pub_Code
AND TBL_BOOKING_MAST.cio_booking_id not in(select distinct prev_cioid from tbl_booking_mast where prev_cioid is not null)
and  lower(Insert_Status) != ''cancel''
and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )'

IF(@agname IS NOT NULL and @agname<>'')
begin
set @query1=@query1 +'AND TBL_BOOKING_MAST.Agency_code ='''+@agname+''''
END 

IF(@Adtype IS NOT NULL and @Adtype<>'')
begin
set @query1=@query1 + 'and TBL_BOOKING_MAST.Ad_type_code='''+@Adtype+''''
END 


IF(@pub_cent IS NOT NULL and @pub_cent<>'')
begin
set @query1=@query1+'  and tbl_booking_insert.Pub_Cent_Code='''+@pub_cent+''''
END 



IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL )
begin
    set @query1=@query1+' and Insert_Date between  '''+@fromdate+''' and  '''+@dateto+''' '
END 

IF(@edition IS NOT NULL and @edition<>'')
begin
set @query1=@query1+'  and tbl_booking_insert.Edition_Code='''+@edition+''''
END 

IF((@category IS NOT NULL) AND (@category <> 'Package') AND (@category <> 'Solo'))
begin
set @query1=@query1+' and  TBL_BOOKING_mast.Agency_type='''+upper(@category)+''''
END 


IF(@product IS NOT NULL and @product<>'')begin
set @query1=@query1+' and TBL_BOOKING_insert.Publication_Code='''+@product+''''
END 

IF(@Region IS NOT NULL and @Region<>'')
begin
set @query1=@query1 +'and tbl_booking_insert.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+@Region+''')'
END


IF(@agcat IS NOT NULL and @agcat<>'')
begin
set @query1=@query1 +'AND TBL_BOOKING_MAST.Agency_code =agency_mast.code_subcode and agency_mast.Agency_Cat_Code='''+@agcat+''''
END 

IF(@executive IS NOT NULL and @executive<>'')
begin
set @query1=@query1 +'AND TBL_BOOKING_MAST.Executive_code ='''+@executive+''''
END 






IF(@descid IS NOT  NULL and @descid<>'')
begin
set @query1=@query1+'  ORDER BY "'+@descid+'"'
set @query1=@query1+''+@ascdesc+''
end
else
begin
set @query1=@query1+' order by TBL_BOOKING_MAST.cio_booking_id'

END



print(@query1)
exec(@query1)
end 

if(@adcheck=2)
begin


set @query1='SELECT distinct ad_bills.IDNUM AS "CIOID",
AGENCY_MAST.Agency_Name AS "Agency",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE ad_bills.comp_code_v=cust_mast.comp_code and Cust_Code=ad_bills_det.CLIENTCD),ad_bills_det.CLIENTCD)  AS "Client",
PUB_MAST.Pub_Name AS "Publication",
round(ad_bills_det.SIZE_BOOK,2) AS "Area",
(SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE ad_bills.comp_code_v=BRANCH_MST.comp_code and ad_bills.REVENUE_CENTER =BRANCH_MST.Branch_Code )AS "RevenueCenter",
ad_bills_det.RATECD as "Rate",
ad_bills.SPPREMIUM as "Premium",
ad_bills.BILL_RMRK as "BillRemark",
ad_bills.COLOUR as "Color",
ad_bills_det.PRIADCTG  as "Category",
ad_bills_det.SECADCTG as "SubCategory",
ad_bills_det.PACKAGE_CODE as "Package",
(select isnull(tbl_booking_mast.Agrred_rate,tbl_booking_mast.Card_rate ) from tbl_booking_mast where tbl_booking_mast.cio_booking_id=ad_bills.IDNUM)AS "AgreedRate",
(ad_bills.BILLAMT) AS "BillAmt",
isnull(ad_bills.DISCOUNT ,''0'' ) as "AgencyComm",
isnull((select tbl_booking_mast.ADD_AGENCY_COMM from tbl_booking_mast where tbl_booking_mast.cio_booking_id=ad_bills.IDNUM),''0'') as "AddlAgencyTD", 
(SELECT dbo.initcap(Comp_Name) from comp_mst where Comp_Code='''+@compcode+''') AS "companyname",
getdate() as "Rundate"
,(select tbl_booking_mast.Booking_type from tbl_booking_mast where ad_bills.IDNUM=tbl_booking_mast.cio_booking_id ) as "booktype"
,ad_bills_det.BILNO as "Bill_No"
,CASE '''+@dateformat+'''
 WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),(CAST( FLOOR( CAST(  ad_bills_det.BILDT AS FLOAT ) ) AS DATETIME )),101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),(CAST( FLOOR( CAST(  ad_bills_det.BILDT AS FLOAT ) ) AS DATETIME )),103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),(CAST( FLOOR( CAST(  ad_bills_det.BILDT AS FLOAT ) ) AS DATETIME )),111) END AS "Bill_Date"

,(select city_mst.City_Name from city_mst where city_mst.City_Code=agency_mast.City_Code and agency_mast.Comp_Code=city_mst.Comp_Code) as "Agency_City"
,agency_mast.Add1 AS "A_Place"
,(select cust_mast.Add1 from cust_mast where ad_bills.CLIENTCD=cust_mast.Cust_Code) AS "C_Place"
,(select UOM_MAST.Uom_Name from uom_mast where  uom_mast.Uom_Code in(select tbl_booking_mast.Uom_code from tbl_booking_mast where  tbl_booking_mast.cio_booking_id=ad_bills.IDNUM ))  AS "Uom"
,ad_bills.PAGENUM as "Page_no"
,(select tbl_booking_mast.Card_rate from tbl_booking_mast where tbl_booking_mast.cio_booking_id=ad_bills.IDNUM ) as "Card_Rate"
,(select tbl_booking_mast.Discount_per from tbl_booking_mast where tbl_booking_mast.cio_booking_id=ad_bills.IDNUM ) as Discper
,(select tbl_booking_mast.Special_disc_per from tbl_booking_mast where tbl_booking_mast.cio_booking_id=ad_bills.IDNUM ) as Spdiscper
,(select tbl_booking_mast.Space_disc_per from tbl_booking_mast where tbl_booking_mast.cio_booking_id=ad_bills.IDNUM ) as Spacediscper
,(select tbl_booking_mast.Special_charges from tbl_booking_mast where tbl_booking_mast.cio_booking_id=ad_bills.IDNUM ) as Specialcharge
,(select isnull((ad_bills.BILLAMT -isnull(dbo.fun_actual('''+@compcode+''',isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),isnull(ad_bills.RETAINER_CODE ,''0''),isnull(ad_bills.GROSS_AMT ,''0''),'''+@prefer+''',''2'' ),''0'')  ),''0'') from tbl_booking_mast where tbl_booking_mast.cio_booking_id=ad_bills.IDNUM ) as ActualBusiness

,(select isnull((isnull(ad_bills.GROSS_AMT,''0'')*isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'')/100),''0'') from tbl_booking_mast where tbl_booking_mast.cio_booking_id=ad_bills.IDNUM )as "AgencyAddlTDAmt"
, (isnull(ad_bills.GROSS_AMT,''0'')* isnull(ad_bills.DISCOUNT,''0'' )/100 )as "AgencyTDAmt"

,isnull(ad_bills.GROSS_AMT,''0'') as Grossamt
,ad_bills_det.HEIGHT as height
,ad_bills_det.WIDTH as width
,ad_bills.GROSS_AMT,ad_bills.BOXCHRG,ad_bills.AGCOMM
FROM ad_bills,ad_bills_det,AGENCY_MAST ,PUB_MAST
WHERE 
ad_bills.IDNUM=ad_bills_det.IDNUM and ad_bills.bilno=ad_bills_det.BILNO and
ad_bills.AGCODE=AGENCY_MAST.code_subcode AND  
ad_bills.PRIPUB = PUB_MAST.Pub_Code 
and ((ad_bills_det.BKFOR  in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
or  ('''+@chk_access+'''=''0'') )'

IF(@agname IS NOT NULL and @agname<>'')
begin
set @query1=@query1 +'  and ad_bills.AG_MAIN_CODE ='''+@agname+''''
END 


IF(@Adtype IS NOT NULL and @Adtype<>'')
begin
set @query1=@query1 + 'and ad_bills_det.AD_TYPE_V='''+@Adtype+''''
END 

iF(@pub_cent IS NOT NULL and @pub_cent<>'')
begin
set @query1=@query1+'  AND AD_BILLS_DET.BKFOR ='''+@pub_cent+''''
END 

IF(@fromdate IS NOT NULL AND @dateto IS NULL )
begin
    set @query1=@query1+' and ad_bills_det.INSDATE ='''+@fromdate+''''
END 

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL )
begin
    set @query1=@query1+' and ad_bills_det.INSDATE between  '''+@fromdate+''' and  '''+@dateto+''' '
END 

IF(@edition IS NOT NULL and @edition<>'')
begin
set @query1=@query1+'  and ad_bills_det.EDITION='''+@edition+''''
END 



IF((@category IS NOT NULL) AND (@category <> 'Package') AND (@category <> 'Solo'))
begin
set @query1=@query1+' and  ad_bills.AGCODE= agency_mast.code_subcode and agency_mast.Agency_Type_Code= '''+upper(@category)+''''
END 


IF(@product IS NOT NULL and @product<>'')
begin
set @query1=@query1+' and ad_bills.PRIPUB='''+@product+''''
END 

IF(@Region IS NOT NULL and @Region<>'')
begin
set @query1=@query1 +' and ad_bills.UNIT in (select Branch_Code from branch_mst where  BRANCH_MST.Region_code='''+@Region +''')'
END 


IF(@agcat IS NOT NULL and @agcat<>'')
begin
set @query1=@query1 +'AND ad_bills.AGCODE =agency_mast.code_subcode and agency_mast.Agency_Cat_Code='''+@agcat+''''
END 

IF(@executive IS NOT NULL and @executive<>'')
begin
set @query1=@query1 +'AND ad_bills.EXECUTIVE_NAME='''+@executive+''''
END 

IF(@descid IS NOT  NULL and @descid<>'')
begin
set @query1=@query1+'  ORDER BY "'+@descid+'"'
set @query1=@query1+''+@ascdesc+''
end
else
begin
set @query1=@query1+' order by ad_bills.IDNUM'
END 




print(@query1)
exec(@query1)
end 
end















/*****ankit 29 march 2012*********7077**********************end***************************/


@@@@@@@@@@@@@@@@@@@@@ r o file @@@@@@@@@@@@@@@@@@@@@  ankit  7098  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[ad_ro_filing]    Script Date: 04/02/2012 12:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




 ALTER PROCEDURE [dbo].[ad_ro_filing]
	@pcompcode                                VARCHAR(8) ,
	@ppaymode                                 VARCHAR(8) ,
	@ptodate                                  VARCHAR(25) ,
	@pfromdate                                VARCHAR(25) ,
	@pclient                                  VARCHAR(100) ,
	@ptaluka                                  VARCHAR(50) ,
	@pagency                                  VARCHAR(50) ,
	@ppcenter                                 VARCHAR(8) ,
	@pexename                                 VARCHAR(50) ,
	@pdistrict                                VARCHAR(20) ,
	@pretainer                                VARCHAR(100) ,
	@pbranch                                  VARCHAR(8) ,
	@prodocstatus                             VARCHAR(100) ,
	@pdateformate                             VARCHAR(15),
	@pbookingid									VARCHAR(50),
	@prono										VARCHAR(50)
AS 
----amit
	BEGIN
		SET NOCOUNT ON
		
		DECLARE @v_frdt                                   DATETIME 
		DECLARE @v_todt                                   DATETIME 
		SELECT @v_frdt  = CONVERT(DATETIME, @pfromdate)
		SELECT @v_todt  = CONVERT(DATETIME, @ptodate)

		IF @prodocstatus is null 
			begin
		select distinct a.branch branch_name ,a.cio_booking_id,a.RO_No as "Agency R.o.No",a.RO_Date,b.Agency_Name as "Agency Name"
,
        isnull((select cust_mast.Cust_Name from cust_mast where cust_mast.Cust_Code=a.Client_code),a.Client_code) as "Client Name"
,Ad_type_code ,a.RODOCSTATUS
        from tbl_booking_mast a,agency_mast b,pub_cent_mast c,branch_mst d
        where a.Comp_code=@pcompcode and a.Comp_code=b.Comp_Code and b.code_subcode=a.Agency_sub_code and 
        a.branch=d.Branch_Code and c.Pub_cent_Code=d.pub_center and d.Branch_Code=isnull(@pbranch,d.Branch_Code) and
        c.Pub_cent_Code=isnull(@ppcenter,c.Pub_cent_Code) and a.date_time>=@v_frdt and a.date_time<=@v_todt and
        a.Agency_sub_code=isnull(@pagency,a.Agency_sub_code) and  (a.Client_code=@pclient or @pclient is null) 
  and  (a.cio_booking_id=@pbookingid or @pbookingid is null)
         and  (a.RO_No=@prono or @prono is null) 
and 
        b.Dist_Code=isnull(@pdistrict,d.Dist_Code) and (b.taluka=@ptaluka or @ptaluka is null) and 
        (a.Bill_pay=@ppaymode or @ppaymode is null) and (a.Executive_code=@pexename or @pexename is null) and
        (a.RETAINER=@pretainer or @pretainer is null) and a.RODOCSTATUS is null
        order by branch_name,cio_booking_id
			
		END
	else if @prodocstatus='A'
		BEGIN 
					 select distinct a.branch branch_name ,a.cio_booking_id,a.RO_No as "Agency R.o.No",a.RO_Date,b.Agency_Name as "Agency Name",
					isnull((select cust_mast.Cust_Name from cust_mast where cust_mast.Cust_Code=a.Client_code),a.Client_code) as "Client Name",Ad_type_code ,a.RODOCSTATUS
					from tbl_booking_mast a,agency_mast b,pub_cent_mast c,branch_mst d
					where a."Comp_code"=@pcompcode and a.Comp_code=b.Comp_Code and b.code_subcode=a.Agency_sub_code and 
					a.branch=d.Branch_Code and c.Pub_cent_Code=d.pub_center and d.Branch_Code=isnull(@pbranch,d.Branch_Code) and
					c.Pub_cent_Code=isnull(@ppcenter,c.Pub_cent_Code) and a.date_time>=@v_frdt and a.date_time<=@v_todt and
					a.Agency_sub_code=isnull(@pagency,a.Agency_sub_code) and  (a.Client_code=@pclient or @pclient is null)
  and  (a.cio_booking_id=@pbookingid or @pbookingid is null)
         and  (a.RO_No=@prono or @prono is null) 
 and 
					b.Dist_Code=isnull(@pdistrict,d.Dist_Code) and (b.taluka=@ptaluka or @ptaluka is null) and 
					(a."Bill_pay"=@ppaymode or @ppaymode is null) and (a.Executive_code=@pexename or @pexename is null) and
					(a.RETAINER=@pretainer or @pretainer is null)-- and a.RODOCSTATUS=@prodocstatus
					order by branch_name,cio_booking_id;    
					
					end

		ELSE
					BEGIN 
						

							 select distinct a.branch branch_name ,a.cio_booking_id,a.RO_No as "Agency R.o.No",a.RO_Date,b.Agency_Name as "Agency Name",
					isnull((select cust_mast.Cust_Name from cust_mast where cust_mast.Cust_Code=a.Client_code),a.Client_code) as "Client Name",Ad_type_code ,a.RODOCSTATUS
					from tbl_booking_mast a,agency_mast b,pub_cent_mast c,branch_mst d
					where a."Comp_code"=@pcompcode and a.Comp_code=b.Comp_Code and b.code_subcode=a.Agency_sub_code and 
					a.branch=d.Branch_Code and c.Pub_cent_Code=d.pub_center and d.Branch_Code=isnull(@pbranch,d.Branch_Code) and
					c.Pub_cent_Code=isnull(@ppcenter,c.Pub_cent_Code) and a.date_time>=@v_frdt and a.date_time<=@v_todt and
					a.Agency_sub_code=isnull(@pagency,a.Agency_sub_code) and  (a.Client_code=@pclient or @pclient is null)
  and  (a.cio_booking_id=@pbookingid or @pbookingid is null)
         and  (a.RO_No=@prono or @prono is null) 
 and 
					b.Dist_Code=isnull(@pdistrict,d.Dist_Code) and (b.taluka=@ptaluka or @ptaluka is null) and 
					(a."Bill_pay"=@ppaymode or @ppaymode is null) and (a.Executive_code=@pexename or @pexename is null) and
					(a.RETAINER=@pretainer or @pretainer is null) and a.RODOCSTATUS=@prodocstatus
					order by branch_name,cio_booking_id;    
					
					end

end


		

	


@@@@@@@@@@@@@@@@@@@@@ r o file @@@@@@@@@ end @@@@@@@@@@@@  ankit  7098  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@



@@@@@@@@@@@@@@@@@@@@@ @@@@@@@@@  @@@@@@@@@@@@  ankit  7040  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[Reportnew]    Script Date: 04/03/2012 15:25:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[Reportnew]
@agname as VARCHAR(500)=NULL,
@clientname as VARCHAR(500)=NULL,
@adtype1 as VARCHAR(50),
@Adcategory as VARCHAR(500),
@fromdate as VARCHAR(20),
@dateto as VARCHAR(20),
@compcode as  VARCHAR(10),
@pub_name as VARCHAR(200),
@pub_cent as  VARCHAR(200),
@status as VARCHAR(50)=NULL,
@edition as VARCHAR(100),
@dateformat as VARCHAR(20),
@hold as  VARCHAR(20)=NULL,
@descid as VARCHAR(20)=NULL,
@ascdesc as VARCHAR(20)=NULL,
@agtype as varchar(20)=null,
@puserid as varchar(10)=null,
@chk_access as varchar(2)
AS

declare @center  VARCHAR(50)
declare @from_date DATETIME
declare @date_to DATETIME
declare @query VARCHAR(8000)
BEGIN
	create table #Results(SegmentNum INT, Edition_Name  VARCHAR(255))

insert into #Results select * from dbo.Fn_Splitfield(@Adcategory,',')

set	@query='SELECT TBL_BOOKING_MAST.cio_booking_id AS CIOID,
TBL_BOOKING_INSERT.Edition as edition,
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

@@@@@@@@@@@@@@@@@@@@@ @@@@@@@@@  @@@@@@@@@@@@  ankit  7040  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


////////////start///////////avinash////7030//////////////////////


CREATE OR REPLACE procedure HT18JULY.getdistrict(
compcode in varchar2,
userid in varchar2,
pextra1 in varchar2,
 p_Accounts      out cur_type_new1.cursor_type) AS

BEGIN


Open P_Accounts For
select "Dist_Name","Dist_Code" from dist_mst where "Comp_Code"=compcode 
  and (
  (upper("Dist_Name") like upper(pextra1)||'%') or (pextra1 is null))

 order by "Dist_Code";
 
 END;



////////////End///////////avinash////7030//////////////////////





------------Start-------------------------Avinash------------7015---------------------



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER PROCEDURE [dbo].[Reportnew]
@agname as VARCHAR(500)=NULL,
@clientname as VARCHAR(500)=NULL,
@adtype1 as VARCHAR(50),
@Adcategory as VARCHAR(500),
@fromdate as VARCHAR(20),
@dateto as VARCHAR(20),
@compcode as  VARCHAR(10),
@pub_name as VARCHAR(200),
@pub_cent as  VARCHAR(200),
@status as VARCHAR(50)=NULL,
@edition as VARCHAR(100),
@dateformat as VARCHAR(20),
@hold as  VARCHAR(20)=NULL,
@descid as VARCHAR(20)=NULL,
@ascdesc as VARCHAR(20)=NULL,
@agtype as varchar(20)=null,
@puserid as varchar(10)=null,
@chk_access as varchar(2)
AS

declare @center  VARCHAR(50)
declare @from_date DATETIME
declare @date_to DATETIME
declare @query VARCHAR(8000)
BEGIN
	create table #Results(SegmentNum INT, Edition_Name  VARCHAR(255))

insert into #Results select * from dbo.Fn_Splitfield(@Adcategory,',')

set	@query='SELECT TBL_BOOKING_MAST.cio_booking_id AS CIOID,
TBL_BOOKING_INSERT.Edition as edition,
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





------------End-------------------------Avinash------------7015---------------------




--------------Start-----------------------Avinash-----------7026---------------------


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


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





--------------End-----------------------Avinash-----------7026---------------------



--------------start-----------------------Avinash-----------7050---------------------



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go







ALTER procedure [dbo].[rpt_booking_report]

@pagency_code	as varchar(50),
@pclient_code	as varchar(50),
@pfrom_date		as varchar(20),
@pto_date		as varchar(20),
@pdateformat	as varchar(20),
@ppublication	as varchar(50),
@pedition		as varchar(50),
@ppub_center	as varchar(50),
@pbranch		as varchar(50),
@pcompcode		as varchar(20),
@puserid		as varchar(20),
@chk_access		as varchar(20),
@pagency_type	as varchar(50),
@pextra1		as varchar(50),
@pextra2		as varchar(50)
as 
declare @query1 varchar(8000)

begin

set @query1='select a.cio_booking_id as "BOOKING_ID",
c.Agency_Name AS "AGENCY",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE a.comp_code=CUST_MAST.comp_code AND Cust_Code=Client_code),Client_code)  AS "CLIENT", 
a.Caption AS "CAPTION",
Key_no AS "KEY",
b.Height AS "Depth",
b.Width   AS "Width",
round(b.Size_Book,2) AS "Area",
/*(select col_mast.Col_Alias from col_mast where b.Col_Code =col_mast.Col_Code)*/ b.Col_Code as COLOR,
b.Page_No as "Page_No",
isnull((select EXEC_MAST.Exec_name from exec_mast where a.Executive_code=exec_mast.Exe_no) ,(select RETAINERMASTER.Retain_Name  FROM  RETAINERMASTER where RETAINERMASTER.Retain_Code=a.RETAINER )) as "EXE_RET",
a.Card_rate as "CARDRATE",
A.Agrred_rate as "AGGRATE",
isnull(b.Gross_Rate,''0'') as "GROSSAMT",
isnull(a.Trade_disc,''0'' )as "AGENCYTD(%)",
isnull(a.ADD_AGENCY_COMM,''0'') as  "AgencyAddlTD(%)",
CASHDISCOUNT as "Cash_Disc",
isnull(b.Bill_Amt,''0'') as "BILLAMT",(select Comp_Name from comp_mst where comp_mst.Comp_Code=a.Comp_code) comp_name
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

IF(@pagency_type IS NOT NULL )
begin
	set @query1=@query1+' and c.Agency_Type_Code =  '''+@pagency_type+''' '
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

print(@query1)
exec(@query1)

end



--------------end-----------------------Avinash-----------7050---------------------





//////////////////////////issue number 6978
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




ALTER function [dbo].[getadd](@compcode varchar(50),@cioid varchar(50)) returns varchar(200)
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


 select @billto=Bill_to from tbl_booking_mast where cio_booking_id=@cioid;

select @address1=agency_mast.add1,@address2=agency_mast.add2,@address3=agency_mast.add3,@street_new=street from agency_mast where SUB_Agency_Code=@billto;





if(@address1<>'' and  @address2 ='' and   @address2 ='' and @street_new='')
begin
select @clientadd=isnull(agency_mast.add1,''),@clientname=Agency_Name,@citycode=city_code from agency_mast where SUB_Agency_Code=@billto;
end

else
if(@address1<>'' and  @address2 <> ''  and @address3='' and @street_new='')
begin
select @clientadd=isnull(agency_mast.add1+','+agency_mast.add2,''),@clientname=Agency_Name,@citycode=city_code from agency_mast where SUB_Agency_Code=@billto;
end

else
if(@address1<>'' and  @address2 <>'' and @address3 <>'' and @street_new='' )
begin
select @clientadd=isnull(agency_mast.add1+','+agency_mast.add2+','+agency_mast.add3,''),@clientname=Agency_Name,@citycode=city_code from agency_mast where SUB_Agency_Code=@billto;
end



else
if(@address1<>'' and  @address2 <>'' and @address3 <>'' and  @street_new<>'')
begin
select @clientadd=isnull(agency_mast.add1+','+agency_mast.add2+','+agency_mast.add3+','+agency_mast.street,''),@clientname=Agency_Name,@citycode=city_code from agency_mast where SUB_Agency_Code=@billto;
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

return (@clientadd+'$$'+@clientname+'$$'+@cityname)
end









//////////////////////////////////////end of issue 6978


==========start ============6918=========avinash====05-april-2012========

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER procedure [dbo].[updateroqbc]

@compcode as varchar(8),
@userid as varchar(8),
@typ as varchar(8),

@codesubcod as varchar(8),
@issudt as varchar(25),
@issno as varchar(8),

@ronofrm as varchar(8),
@ronotll as varchar(8),
@status as varchar(8),
@crntdate as varchar(25)


as
begin

update RO_BOOK_ALLOTMENT set  TYP=@typ, CODE_SUBCODE=@codesubcod, ISSUE_DT=@issudt, 
RONO_FROM=@ronofrm , RONO_TILL=@ronotll, STATUS=@status, UPDATED_BY=@userid, UPDATED_DT=@crntdate 
where comp_code=@compcode and ISSUE_NO=cast(@issno  as numeric)

end




set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER procedure  [dbo].[get_adagenc_bysubcode]

	@pcompcode                                VARCHAR(4000) ,
	@pagsubcode                               VARCHAR(4000), 
	@pcodsubcode							varchar(4000)
 
AS 
			SELECT *
			FROM  agency_mast 			WHERE	 (Comp_Code = @pcompcode)		 
			 
			 AND	(SUB_Agency_Code  = @pagsubcode or @pagsubcode ='')
			

	SELECT *
			FROM  agency_mast 
			WHERE	 (Comp_Code = @pcompcode)
			 
			 
			 AND	(SUB_Agency_Code  = @pagsubcode or @pagsubcode ='')
			and    (code_subcode= @pcodsubcode or @pcodsubcode='')




==========end ============6918=========avinash====05-april-2012========

==========================================ankit==============7143=======================================

create procedure fa_account_mast_typewise 
      @pcompcode     as    varchar(20),
      @paccty        as    varchar(20),
      @paccname      as    varchar(200),
      @puserid       as    varchar(20),
      @pextra1       as    varchar(200),
      @pextra2       as    varchar(200)
   as
begin

if @paccty='' Begin
    set @paccty=null
end

if @paccname='' Begin
    set @paccname=null
end
if @puserid='' Begin
    set @puserid=null
end
if @pextra1='' Begin
    set @pextra1=null
end
if @pextra2='' Begin
    set @pextra2=null
end
         select m.comp_code as "COMP_CODE", m.cdp as "CDP", m.acc_name as "ACC_NAME", m.acc_alias as "ACC_ALIAS",
         m.acc_nature as "ACC_NATURE", m.ACC_TY as "ACC_TY",t.ac_type_desc as "AC_TYPE_DESC",t.ac_cash_bank as "AC_CASH_BANK"
           from fa_acc_mast m,fa_account_type_mast t
            where m.comp_code = @pcompcode and m.comp_code = t.comp_code
                and m.acc_ty =t.ac_type_code and t.ac_cash_bank=isnull(@paccty,t.ac_cash_bank)
                and (upper (m.acc_name) like upper ('%' +@paccname + '%') or @paccname is null)
                order by acc_name
             
            
END





USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[chkprefren]    Script Date: 04/07/2012 14:13:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  procedure [dbo].[chkprefren]
@Pcompcode as varchar(10)

as 

select * from PREFERRENCES where "comp_code"=@Pcompcode;


====================end======================ankit==============7143=======================================

//=======================************* Start Procedure Scripts *************kuldeep**===============//
alter table pub_cent_mast add LOGO_FILE_PATH varchar(200)

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
      ,[CIR_FILE_PATH],[LOGO_FILE_PATH],,[CENTER_COMP_NAME]) values(@compcode,@centercode,@centername, @alias,@add1,@street,@country, @state, @dist, @city, @pin,@phone1,@phone2, @fax,@email,'',getdate(),@remarks,@userid,getdate(),@region,@zone,@fax1,@boxaddress,@printval ,'',@imgpath,@cir_imgpath,@pcompanyname,@plogopath)
--insert into pub_cent_mast values(@compcode,@centercode,@centername, @alias,@add1,@street,@country, @state, @dist, @city, @pin,@phone1,@phone2, @fax,@email,'','',@remarks,@userid,@region,@zone,@txtdate),@fax2


exec(@query)
print(@query)


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
    zip    varchar(12)  ,
    Phone1    varchar(5)  ,
    Phone2    varchar(10)  ,
    Fax    varchar(15)  ,
    EmailID    varchar(50)  ,
    Pub_Cent_Status    varchar(20)  ,
    Status_date    datetime    NOT NULL ,
    Remarks    varchar(200)  ,
    UserId    varchar(8)  ,
    To_date    datetime    NULL ,
    From_date    datetime    NULL ,
    Creation_Datetime    datetime    NULL ,
    Region_code    varchar(8)  ,
    Zone_code    varchar(8)  ,
    Fax1    varchar(10)  ,
             BOXADDRESS  varchar(200) ,
PRINT_CENT varchar(20),
FILE_PATH varchar(50),
CIR_FILE_PATH varchar(50),
CENTER_COMP_NAME varchar(50),
LOGO_FILE_PATH varchar(200)
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
getdate(),Remarks,UserId,getdate(),getdate(),creation_datetime,region_code,zone_code,Fax1,BOXADDRESS,PRINT_CENT,FILE_PATH,CIR_FILE_PATH,CENTER_COMP_NAME,LOGO_FILE_PATH  from pub_cent_mast where comp_code='''+@compcode+''' '


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

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
@plogopath as varchar(200)
AS

declare @query varchar(1000)
declare @query1 varchar(1000)

set @query=' update pub_cent_mast set Pub_Cent_name='''+@centername+''' , Pub_Cent_Alias='''+@alias+''' , Add1='''+@add1+''' , street='''+@street+''', Country_Code='''+@country+''', State_Code='''+@state+''', Dist_Code='''+@dist+''', City_Code='''+@city+''', zip='''+@pin+''', Phone1='''+@phone1+''', Phone2='''+@phone2+''',Fax='''+@fax+''', EmailID='''+@email+''',Remarks='''+@remarks+''',region_code='''+@region+''',zone_code='''+@zone+''',Fax1='''+@fax1+''' ,BOXADDRESS='''+@boxadd+''',PRINT_CENT='''+@printval+''',FILE_PATH='''+@imgpath+''',CIR_FILE_PATH='''+@cir_imgpath+''',CENTER_COMP_NAME='''+@pcompanyname+''',LOGO_FILE_PATH='''+@plogopath+'''  where comp_code='''+@compcode+'''   and   Pub_cent_Code='''+@centercode+'''   '

--set @query1=' update pcmdummy set Pub_Cent_name='''+@centername+''' , Pub_Cent_Alias='''+@alias+''' , Add1='''+@add1+''' , street='''+@street+''', Country_Code='''+@country+''', State_Code='''+@state+''', Dist_Code='''+@dist+''', City_Code='''+@city+''', zip='''+@pin+''', Phone1='''+@phone1+''', Phone2='''+@phone2+''',Fax='''+@fax+''', EmailID='''+@email+''',Remarks='''+@remarks+''',region_code='''+@region+''',zone_code='''+@zone+''',Fax1='''+@fax1+'''  where comp_code='''+@compcode+'''    and   Pub_cent_Code='''+@centercode+'''   '


print (@query)
exec(@query)
--print(@query1)
--exec(@query1)

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE procedure ad_rep_user_form_rights
	@pcomp_code      as varchar(20),
	@punit_code      as varchar(20),
	@puser_code      as varchar(20),
	@pmodule_code    as varchar(20),
	@pdateformat     as varchar(20),
	@pextra1         as varchar(200),
	@pextra2         as varchar(200)
As
Begin
	if @pcomp_code='' begin
		set @pcomp_code=null
	end
	if @punit_code='' begin
		set @punit_code=null
	end	
	if @puser_code='' begin
		set @puser_code=null
	end
	if @pmodule_code='' begin
		set @pmodule_code=null
	end
	if @pextra1='' begin
		set @pextra1=null
	end			
	if @pextra2='' begin
		set @pextra2=null
	end
    select distinct a."userid" AS "USER_CODE",l."username" AS "USER_NAME",
    a."comp_code" AS "COMP_CODE",(select "Comp_Name" from comp_mst where a."comp_code"=comp_mst."Comp_Code") AS "COMP_NAME",
    "retainer_code" AS "UNIT_CODE",(select "Branch_Name" from branch_mst where "Branch_Code"=l."retainer_code") AS "UNIT_NAME",
    a."Form_id" AS "FORM_ID",b."Form_Name" AS "FORM_NAME",b."Form_Alias" AS "FORM_MENUNAME",b.FORMTYPE AS "FORM_TYPE",
    case when b.FORMTYPE='M' then 'MASTER' when b.FORMTYPE='T' then 'TRANSACTION' else 'REPORT' end AS "FORM_TY_NAME",
    CASE isnull(a."Button_id",'0') WHEN '0' THEN 'No Permission' WHEN '1' THEN 'Insert Only' WHEN '2' THEN 'Update Only' WHEN '3' THEN 'Delete Only' 
    WHEN '4' THEN 'Insert,Update Only' WHEN '5' THEN 'Insert,Delete Only' 
    WHEN '6' THEN 'Update,Delete Only' WHEN '7' THEN 'All Permission' WHEN '8' THEN 'View Only' ELSE 'Not Applicable' 
    END AS "USER_RIGHT",
    (select "Agency_Role_Name" from agency_role_master where "Agency_Role_Code"=l."ROLEID") AS "ROLE_NAME"
    from module_detaibuttonl a,formmast b,login l
    where a."comp_code" = @pcomp_code and (l."retainer_code" =@punit_code or @punit_code is null) and
    a."userid"      =isnull(@puser_code,a."userid") and l."userid"=a."userid" and
    a.MODULECODE     =@pmodule_code and
    a.MODULECODE     =b.MODULECODE and a."Form_id"    =b."form_id"
    order by user_name,comp_name,unit_name,form_ty_name,Form_Menuname;

    select distinct a."userid" AS "USER_CODE",l."username" AS "USER_NAME",
    a."comp_code" AS "COMP_CODE",(select "Comp_Name" from comp_mst where a."comp_code"=comp_mst."Comp_Code") AS "COMP_NAME",
    "retainer_code" AS "UNIT_CODE",(select "Branch_Name" from branch_mst where "Branch_Code"=l."retainer_code") AS "UNIT_NAME",
    (select "Agency_Role_Name" from agency_role_master where "Agency_Role_Code"=l."ROLEID") AS "ROLE_NAME"
    from module_detaibuttonl a,formmast b,login l
    where a."comp_code" =isnull(@pcomp_code,a."comp_code") and (l."retainer_code" =@punit_code or @punit_code is null) and
    a."userid"    =isnull(@puser_code,a."userid" ) and l."userid"=a."userid" and
    a.MODULECODE  =@pmodule_code and
    a.MODULECODE  =b.MODULECODE and a."Form_id"    =b."form_id"
    order by user_name,comp_code,unit_name;

End

//=======================************* End of Procedure Scripts ***************===============//

/**************************************mimoh*****7162***************************************************/


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
,Status_Reason,Remarks,UserId,Creation_Datetime,Zone_code,Region_code,Credit_limit,Rate_Gr_Code,  getdate() ,Client_category ,TALUKA,(select top 1 TO_DATE from status_detail_client where status_detail_client.cust_code=cust_mast.Cust_Code) as to_date,CLIENT_TYPE,QBC_AGENCY,TYPE,PARENT_CLIENT,OLD_CLIENT_CODE     from cust_mast where comp_code='''+@compcode+'''' 

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








/**************************************************************************************************************/


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
@p_parent as varchar(8),
@poldclient as varchar(50)
as

declare @distcode as varchar(50)
declare @statecode as varchar(50)
declare @countrycode as varchar(50)
declare @fatchstatus as varchar(50)
declare @p_remark     as VARCHAR(500)
--select @distcode =dist_code from dist_mst where dist_name=@dist
--select @statecode=state_code from state_mst  where state_Name=@state
select @countrycode=country_code from count_mst  where country_Name=@country
select top 1 @fatchstatus=status_name from tblstatus where status_code=(select top 1 cust_status from status_detail_client where cust_code=@custcode and Comp_Code=@compcode)
select top 1  @p_remark=Remarks from cust_mast where Comp_Code=@compcode and Cust_Code=@custcode
/*Transaction Variable*/

	if(@flag=1)
		begin 
        		update cust_mast  set zone_code=@zone,region_code=@region, credit_limit=@crdlimit,Cust_Name=@custname,Cust_Alias=@custalias,Add1=@add1,Stree=@street,City_Code=@citycode,Zip=@zip,Dist_Code=@dist,State_Code=@state,Country_Code=@country,Phone1=@phone1,Phone2=@phone2,Fax=@fax,Emailid=@emailid,Url=@url,No_of_VTS=@vats,ST_ACC_No=@servicetax,PAN_No=@pan,Credit_Days=@creditdays,Pay_Mode_Code=@paymodecode,Cust_Status=@custstatus,Status_Reason=@statusreason,Remarks=@alert,UserId=@userid,Creation_Datetime=getdate(),Rate_Gr_Code=@rategroup,Client_category=@clientcat ,TALUKA=@taluka , AGENCY_CODE=@agency_sav,
				CLIENT_TYPE= @p_CLIENT_TYPE,QBC_AGENCY=@p_QBC_AGENCY,"TYPE"=@p_type,PARENT_CLIENT=@p_parent,OLD_CLIENT_CODE = @poldclient
				WHERE Comp_Code = @compcode AND Cust_Code=@custcode 		
		--update clientfirst  set  zone_code=@zone,region_code=@region, credit_limit=@crdlimit,Cust_Name=@custname,Cust_Alias=@custalias,Add1=@add1,Stree=@street,City_Code=@citycode,Zip=@zip,Dist_Code=@dist,State_Code=@state,Country_Code=@country,Phone1=@phone1,Phone2=@phone2,Fax=@fax,Emailid=@emailid,Url=@url,No_of_VTS=@vats,ST_ACC_No=@servicetax,PAN_No=@pan,Credit_Days=@creditdays,Pay_Mode_Code=@paymodecode,Cust_Status=@custstatus,Status_Reason=@statusreason,Remarks=@alert,UserId=@userid,Creation_Datetime=getdate(),Rate_Gr_Code=@rategroup WHERE Comp_Code = @compcode AND Cust_Code=@custcode and UserId=@userid		
		/* TO INSERT DATA IN CLIENT HISTORY LOG*/
         IF (@p_remark != @alert)
         begin
         INSERT INTO CUST_REMARK_DETAIL(COMP_CODE, CUST_CODE,CUST_REMARK, USERID)
                        VALUES(@compcode,@custcode,@alert,@userid)
         end

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
                      Credit_limit, Rate_Gr_Code, Client_category,TALUKA,AGENCY_CODE,CLIENT_TYPE,QBC_AGENCY,"TYPE",PARENT_CLIENT,OLD_CLIENT_CODE 
                     ) values(@compcode,@custcode,@custname,@custalias,@add1,@street,@citycode,@zip,@dist,@state,@country,@phone1,@phone2,@fax,@emailid,@url,@vats,@servicetax,@pan,@creditdays,@paymodecode,@fatchstatus,@statusreason,@alert,@userid,getdate(),@zone,@region,@crdlimit,@rategroup,@clientcat,@taluka,@agency_sav,
					 @p_CLIENT_TYPE,@p_QBC_AGENCY,@p_type,@p_parent,@poldclient)
			
						--insert into cust_mast
			/*This is added by Amit */
			/* This query is automatically added after data is addded on cust_mast table*/
			--insert into pay_mode_client(Comp_Code,Client_code,userid,creation_datetime) values(@compcode,@custcode,@userid,getdate()) 
			INSERT INTO CUST_REMARK_DETAIL(COMP_CODE, CUST_CODE,CUST_REMARK, USERID)
                        VALUES(@compcode,@custcode,@alert,@userid)
		
		end




/**************************************mimoh*****7162***************************************************/

/************************************************MIMOH******7169***************************/
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
    
End/************************************************MIMOH******7169***************************/
/**************************************mimoh************7180********11/april/2012***************************************************************/

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
set @query=' select Comp_Code,userid,Retain_Code,Retain_Name,Retain_Alias,Add1,Street,City_Code,Zip,Dist_Code,State_Code,Region_Code,Country_Code,Phone1,Phone2,Fax,EmailID,Credit_Days,Remarks,PAN_No,Retain_status,getdate(),getdate(),pubcent_code,BOXMATTER,PUBLICATION,EDITION,SUPPLEMENT,TALUKA,REPRESENTATIVE as "repname",Branch_code,CREDIT_LIMIT,MOBILENO,SIGN,(select NAME+''(''+EMP_CODE+'')'' from HR_EMP_MST where COMP_CD='''+@compcode+''' AND EMP_CODE=RetainerMaster.HR_CODE)AS HR_CODE,(select ACC_NAME   from fa_acc_mast where COMP_CODE=compcode and CDP= RETAINERMASTER.CDP )AS ACC_NAME,CDP from  RetainerMaster where Comp_code='''+@compcode+''''

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


/***************************************************************************************************/

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
@p_maincdp as varchar(50)
)
as

declare @query varchar(1000)
declare @query3 varchar(1000)


if(@flag=0)
begin

set @query = 'insert into RetainerMaster(Comp_Code ,Retain_Code ,userid ,Retain_Name ,Retain_Alias ,Add1 ,Street ,City_Code ,Zip ,Dist_Code ,State_Code ,Zone_Code,Region_Code,Country_Code ,phone1 ,Phone2 ,Fax ,EmailID ,PAN_No ,Credit_Days,Remarks , pubcent_code,Creation_Datetime, retain_status, to_date,BOXMATTER,PUBLICATION,EDITION,SUPPLEMENT,TALUKA,REPRESENTATIVE,Branch_code,CREDIT_LIMIT,MOBILENO,SIGN,HR_CODE,CDP)values ('''+@Comp_Code1+''' ,'''+@Retain_Code1+''' ,'''+@userid1+''' ,'''+@Retain_Name1+''' ,'''+@Retain_Alias1+''' ,'''+@Add11+''' ,'''+@Street1+''','''+@City_Code1+''' ,'''+@Zip1+''' ,'''+@Dist_Code1+''','''+@State_Code1+''' ,'''+@zone_code1+''' ,'''+@region_code1+''' ,'''+@Country_Code1+''' ,'''+@phone11+''' ,'''+@Phone21+''' ,'''+@Fax1+''','''+@EmailID1+''','''+@PAN_No1+''' ,'''+@Credit_Days1+''' ,'''+@Remarks1+''','''+@pubcent1+''',getdate(),'''','''','''+@Box1+''','''+@Publication11+''' ,'''+@Edition11+''','''+@Supplement11+''','''+@taluka+''','''+@repname+''','''+@branchcode+''','''+@creditlimit+''','''+ @mobile1+''','''+@signature+''','''+@p_empcode+''','''+@p_maincdp+''') '

end
if(@flag=1)
begin  
	set @query = 'update RetainerMaster set Retain_Name = '''+@Retain_Name1+'''  ,Retain_Alias = '''+@Retain_Alias1+'''  ,Add1 = '''+@Add11 +''',Street = '''+@Street1+''' ,City_Code = '''+@City_Code1+'''  ,Zip = '''+@Zip1+'''  ,Dist_Code = '''+@Dist_Code1+'''  ,State_Code = '''+@State_Code1+''' ,zone_code = '''+@zone_code1+'''  ,region_code = '''+@region_code1+'''  ,Country_Code = '''+@Country_Code1+'''  ,phone1 = '''+@phone11+'''  ,Phone2 = '''+@Phone21+'''  ,Fax = '''+@Fax1+'''  ,EmailID = '''+@EmailID1+'''  ,PAN_No = '''+@PAN_No1+'''  ,Credit_Days = '''+@Credit_Days1+''',Remarks = '''+@Remarks1+''' ,    pubcent_code='''+@pubcent1+''' 
,    BOXMATTER='''+@Box1+''' ,PUBLICATION = '''+@Publication11+'''  ,EDITION = '''+@Edition11 +''',SUPPLEMENT = '''+@Supplement11+''',TALUKA='''+@taluka+''',REPRESENTATIVE='''+@repname+''',Branch_code='''+@branchcode+''',CREDIT_LIMIT='''+@creditlimit+''',MOBILENO='''+ @mobile1+''',SIGN='''+@signature+''',HR_CODE='''+@p_empcode+''',CDP='''+@p_maincdp+''' where comp_code = '''+@Comp_Code1 +''' and Retain_Code = '''+@Retain_Code1+''''    --/*   and userid ='''+@userid+'''   */  
--set @query3 = 'update tmpretainer set Retain_Name = '''+@Retain_Name+'''  ,Retain_Alias = '''+@Retain_Alias+'''  ,Add1 = '''+@Add1 +''',Street = '''+@Street+''' ,City_Code = '''+@City_Code+'''  ,Zip = '''+@Zip+'''  ,Dist_Code = '''+@Dist_Code+'''  ,State_Code = '''+@State_Code+'''  ,Country_Code = '''+@Country_Code+'''  ,phone1 = '''+@phone1+'''  ,Phone2 = '''+@Phone2+'''  ,Fax = '''+@Fax+'''  ,EmailID = '''+@EmailID+'''  ,PAN_No = '''+@PAN_No+'''  ,Credit_Days = '''+@Credit_Days+''',Remarks = '''+@Remarks+'''   where comp_code = '''+@Comp_Code +'''and userid ='''+@userid+''' and Retain_Code = '''+@Retain_Code+'''' 
end


print(@query)
exec(@query)
--print(@query3)
--exec(@query3)






/***********************************************************/

ALTER procedure [dbo].[ad_acc_name_bind]
(
@pcompcode as varchar(15),
@paccname as varchar(30),
@pextra2 as varchar(50)
)
as
   select  ACC_NAME,CDP   from fa_acc_mast where ACC_NAME like '%'+@paccname+'%' and comp_code=@pcompcode;

      
        






/**************************************mimoh************7180********11/april/2012***************************************************************/

/**************** issue no. 7141(complete Report) ******************************
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




                                                                     
                                                                     
                                                                     
                                             
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
declare @queryp as VARCHAR(8000)
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
( CIOID             varchar(50),
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
PAGE_NO int,
BILL_REMARK         varchar(500)

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
fetch next from c1 into @c1cioid ,@c1pckcode,@c1gramt,@c1chkvar
	PRINT(@@FETCH_STATUS)
	while @@FETCH_STATUS=0 begin
		PRINT('prachi')
		PRINT(@c1chkvar)
	if(@c1chkvar='1')begin	
		insert into MULTIPACK_REP select * from dbo.multipack_report1(@c1cioid, @c1pckcode, @c1gramt, '1')

	end
	else if(@c1chkvar='3') begin
		insert into MULTIPACK_RAT select * from dbo.multipack_report3(@c1cioid, @c1pckcode, @c1gramt, '3')
	end
	else begin
		insert into MULTIPACK_RATNEW select * from dbo.multipack_report2(@c1cioid, @c1pckcode, @c1gramt, '2')
	end
	set @v_edition=null
	set @v_edipkg=null
fetch next from c1 into @c1cioid ,@c1pckcode,@c1gramt,@c1chkvar
end
close c1

print('145466')
print(@chkdetail)
print(@adcheck)
print('xz')
if(@chkdetail='Detail')begin
	if(@adcheck=1) begin
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
	/*dbo.FETCH_PACK(a.cio_booking_id) AS Package,*/
	case when CHARINDEX('','', a."Package_code")>0 then
		dbo.FETCH_PACK_new('''+ @compcode +''', a."Package_code" ) 
	else
		(select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=a."Package_code")
	end AS "Package",
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
	,(SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as Branch
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
	,(select distinct "Box_Name" from box_mast where "Box_Code"=a."Box_code") as "BoxCode",
	a.Userid as USERID,(SELECT max(username) from login where com_code = a.Comp_code and userid=a.Userid) as USERNAME
,a.Bill_remarks as "BillRemark"
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
		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' ) begin
			set @query4=' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 

		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' ) begin
			set @query4=' and a.Insertion_date  between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 
	end
	else begin
		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' ) begin
			set @query4=@query4+' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 

		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' ) begin
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


	IF(@publication IS NOT NULL) begin
		set @query4=@query4+' and TBL_BOOKING_insert.publication_Code='''+@publication+'''    '
	END 

	IF(@pub_cent IS NOT NULL) begin
		set @query4=@query4+'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
	END 

	IF(@branch IS NOT NULL  and @branch<>'') begin
		set @query4=@query4+'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
	END 

	IF(@edition IS NOT NULL  and @edition<>'') begin
		set @query4=@query4+'  and tbl_booking_insert.Edition_Code='''+@edition+''''
	END 
	
 
	IF(@region IS NOT NULL and @region <>'') begin
		--set @query4=@query4 +' and tbl_booking_insert.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+region +''')'
		set @query4=@query4 +' and agency_mast.region ='''+@region +''' '
	END 

	IF(@revcenter IS NOT NULL and @revcenter <>'') begin
		set @query4=@query4 +' and a.Revenue_center ='''+@revcenter+''''
	END 

	IF(@adtype IS NOT NULL and @adtype <>'') begin
		set @query4=@query4 + ' and a.Ad_type_code='''+@adtype+''''
	END 

	IF(@agencytype IS NOT NULL and @agencytype <>'') begin
		set @query4=@query4 + ' and a.Agency_type ='''+@agencytype+''''
	END 

	IF(@adcat IS NOT NULL and @adcat <>'') begin
		set @query4=@query4 + ' and a.Ad_cat_code ='''+@adcat+''''
	END 

	IF(@adsubcat IS NOT NULL and @adsubcat <>'') begin
		set @query4=@query4 + ' and a.Ad_sub_cat_code ='''+@adsubcat+''''
	END 

	IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'') begin
		set @query4=@query4 + ' and a.Ad_Subcat3 ='''+@adsubcat3+''''
	END 

	IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'') begin
		set @query4=@query4 + ' and a.Ad_Subcat4 ='''+@adsubcat4+''''
	END 

	IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'') begin
		set @query4=@query4 + ' and a.Ad_subcat5 ='''+@adsubcat5+''''
	END 

	IF(@package IS NOT NULL and @package <>'') begin
		set @query4=@query4 + ' and a.Package_code ='''+@package+''''
	END 

	IF(@scheme IS NOT NULL and @scheme <>'') begin
		set @query4=@query4 + ' and a.Scheme_type_code ='''+@scheme+''''
	END 

	IF(@agency IS NOT NULL and @agency <>'') begin
		set @query4=@query4 + ' and a.Agency_code ='''+@agency+''''
	END 

	IF(@client IS NOT NULL and @client  <>'') begin
		set @query4=@query4 + ' and a.Client_code ='''+@client+''''
	END 

	IF(@executive IS NOT NULL and @executive <>'') begin
		set @query4=@query4 + ' and a.Executive_code ='''+@executive+''''
	END 

	IF(@retainer IS NOT NULL and @retainer <>'') begin
		set @query4=@query4 + ' and a.RETAINER ='''+@retainer+''''
	END 

	IF(@product IS NOT NULL and @product <>'') begin
		set @query4=@query4 + ' and a.Product_code ='''+@product+''''
	END 

	IF(@brand IS NOT NULL and @brand <>'') begin
		set @query4=@query4 + ' and a.Brand_code ='''+@brand+''''
	END 

	IF(@varient IS NOT NULL and @varient <>'') begin
		set @query4=@query4 + ' and a.Variant_code ='''+@varient+''''
	END 

	IF(@pagetype IS NOT NULL and @pagetype <>'') begin
		set @query4=@query4 + ' and a.Page_type_code ='''+@pagetype+''''
	END 

	IF(@pageprem IS NOT NULL and @pageprem <>'') begin
		set @query4=@query4 + ' and a.Page_prem ='''+@pageprem+''''
	END 

	IF(@postprem IS NOT NULL and @postprem <>'') begin
		set @query4=@query4 + ' and a.Page_position_code ='''+@postprem+''''
	END 

	IF(@rostatus IS NOT NULL and @rostatus <>'') begin
		set @query4=@query4 + ' and a.ro_status ='''+@rostatus+''''
	END 

	IF(@booktype IS NOT NULL and @booktype <>'') begin
		set @query4=@query4 + ' and a.Booking_type ='''+@booktype+''''
	END 

	IF(@contractname  IS NOT NULL and @contractname  <>'') begin
		set @query4=@query4 + ' and a.Contract_name ='''+@contractname +''''
	END 

	IF(@suppliment  IS NOT NULL and @suppliment  <>'') begin
		set @query4=@query4 + ' and tbl_booking_insert.Supp_Code ='''+@suppliment+''''
	END 

	IF(@ratetype  IS NOT NULL and @ratetype  <>'') begin
		set @query4=@query4 + ' and a.Rate_code ='''+@ratetype+''''
	END 

	IF(@p_baxcode IS NOT NULL and @p_baxcode <>'') begin
		set @query4=@query4 + ' and a.Box_code ='''+@p_baxcode+''''
	END 

	IF(@city  IS NOT NULL and @city  <>'') begin
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

	IF(@zone  IS NOT NULL and @zone  <>'') begin
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

	IF(@district  IS NOT NULL and @district  <>'') begin
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

	IF(@state  IS NOT NULL and @state  <>'') begin
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

	IF(@taluka  IS NOT NULL and @taluka  <>'') begin
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
fetch next from c2 into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME

print(@@FETCH_STATUS)
while @@FETCH_STATUS=0 begin
print('prachi')
insert into #temp_ad_bills_report select * from dbo.FUN_BILL_INSERT(@compcode,@v2_CIOID,@v2_BILLNO,@prefer,@dateformat,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME,@base )  

fetch next from c2 into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME

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
,BILL_REMARK as "BillRemark"
from #temp_ad_bills_report where'

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL ) begin
	set @query4= '  BILLDATE between  '''+@fromdate +''' and  '''+@dateto+''' '
END 

IF(@publication IS NOT NULL and @publication<>'') begin
	set @query4=@query4+ ' and PRIPUB='''+@publication+''''
END 

IF(@pub_cent IS NOT NULL and @pub_cent<>'')	begin
	set @query4=@query4+ '   and PUB_CENT_CODE='''+@pub_cent+''''
END 

IF(@edition IS NOT NULL and @edition<>'')begin
	set @query4=@query4+ '  and PEDITION='''+@edition+''''
END 

IF(@branch IS NOT NULL and @branch<>'')begin
	set @query4=@query4+ '  and  BRANCH_NAME ='''+@branch+''' '
END 

IF(@region IS NOT NULL and @region<>'') begin
	set @query4=@query4 +' and REGION='''+@region +''''
END 

IF(@adtype IS NOT NULL and @adtype<>'') begin
	set @query4=@query4 + ' and PADTYPE='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype<>'') begin
	set @query4=@query4 + ' and AGENCY_TYPE_CODE= '''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat<>'') begin
	set @query4=@query4 + ' and PRIADCTG='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat<>'') begin
	set @query4=@query4 + ' and SECADCTG ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3<>'') begin
	set @query4=@query4 + ' and AD_SUBCAT3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4<>'') begin
	set @query4=@query4 + ' and AD_SUBCAT4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5<>'') begin
	set @query4=@query4 + ' and AD_SUBCAT5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package<>'') begin
	set @query4=@query4 + ' and PACKAGE_CODE='''+@package+''''
END 

IF(@agency IS NOT NULL and @agency<>'') begin
	set @query4=@query4 + ' and AG_MAIN_CODE ='''+@agency +''''
END 

IF(@client IS NOT NULL and @client<>'') begin
	set @query4=@query4 + ' and CLIENTCD='''+@client +''''
END 

IF(@executive IS NOT NULL and @executive<>'') begin
	set @query4=@query4 + ' and EXECUTIVE_NAME='''+@executive+''''
END 

IF(@product IS NOT NULL and @product<>'') begin
	set @query4=@query4 + ' and PRIPROCTG='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand<>'') begin
	set @query4=@query4 + ' and BRAND_CODE='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient<>'') begin
	set @query4=@query4 + ' and   VARIENT_NAME='''+@varient+''''
END 

IF(@pageprem IS NOT NULL and @pageprem<>'') begin
	set @query4=@query4 + ' and PAGE_PREM ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem<>'') begin
	set @query4=@query4 + ' and PAGE_POST ='''+@postprem+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'') begin
	set @query4=@query4 + ' and CONTRACT_NAME ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment<>'') begin
	set @query4=@query4 + ' and SUPP_CODE='''+@suppliment+''''
END 

IF(@retainer IS NOT NULL and @retainer<>'') begin
	set @query4=@query4 + ' and RETAINER_CODE='''+@retainer+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype<>'') begin
	set @query4=@query4 + ' and RATECD ='''+@ratetype+''''
END 

IF(@scheme IS NOT NULL and @scheme<>'') begin
	set @query4=@query4 + ' and PSCHEME='''+@scheme+''''
END 

IF(@revcenter IS NOT NULL and @revcenter<>'') begin
	set @query4=@query4 +' and REVENUE_CENTER='''+@revcenter+''''
END 

IF(@rostatus IS NOT NULL and @rostatus<>'') begin
	set @query4=@query4 + ' and RO_STATUS='''+@rostatus+''''
END 

IF(@pagetype IS NOT NULL and @pagetype<>'') begin
	set @query4=@query4 + ' and PAGE_TYPE ='''+@pagetype+''''
END 

IF(@booktype IS NOT NULL and @booktype<>'') begin
	set @query4=@query4 + ' and BOOKING_TYPE='''+@booktype+''''
END 

IF(@city  IS NOT NULL and @city<>'') begin
	set @query4=@query4 + ' and CITY_CODE ='''+@city+''''
END 

IF(@zone  IS NOT NULL and @zone<>'') begin
	set @query4=@query4 + ' and ZONE_CODE ='''+@zone+''''
end 

IF(@district  IS NOT NULL and @district<>'') begin
	set @query4=@query4 + ' and DIST_CODE ='''+@district+''''
end 

IF(@state  IS NOT NULL and @state<>'') begin
	set @query4=@query4 + ' and STATE_CODE ='''+@state+''''
end 

IF(@taluka  IS NOT NULL and @taluka<>'') begin
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
case when CHARINDEX('','', TBL_BOOKING_MAST."Package_code")>0 then
	dbo.FETCH_PACK_new('''+ @compcode +''', TBL_BOOKING_MAST."Package_code" ) 
else
	(select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=TBL_BOOKING_MAST."Package_code")
end AS "Package",
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
tbl_booking_insert.Page_No as "Page_No" '

set @queryp='
,CASHDISCOUNT as "Cash_Disc"
,Insert_Status as "Status"
,(select distinct "Box_Name" from box_mast where "Box_Code"=TBL_BOOKING_MAST."Box_code") as "BoxCode",
TBL_BOOKING_MAST.Userid as USERID,
(SELECT max(username) from login where com_code = TBL_BOOKING_MAST.Comp_code and userid=TBL_BOOKING_MAST.Userid) as USERNAME
,TBL_BOOKING_MAST.Bill_remarks as "BillRemark"
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

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL) begin
	set @query4=@query4+' and tbl_booking_insert.Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
END

IF(@p_baxcode IS NOT NULL and @p_baxcode <>'') begin
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





IF(@publication IS NOT NULL) begin
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

IF(@pub_cent IS NOT NULL) begin
	set @query4=@query4+'  and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
END 


IF(@branch IS NOT NULL  and @branch<>'') begin
	set @query4=@query4+'  and TBL_BOOKING_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
END 


IF(@edition IS NOT NULL and @edition<>'') begin
	set @query4=@query4 +'  and tbl_booking_insert.Edition_Code='''+@edition+''''
END 



IF(@region IS NOT NULL and @region <>'') begin
	--set @query4=@query4  +' and tbl_booking_insert.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+@region +''')'
	set @query4=@query4  +' and agency_mast.region ='''+@region+''''
END 

IF(@revcenter IS NOT NULL and @revcenter <>'') begin
	set @query4=@query4  +' and tbl_booking_mast.Revenue_center ='''+@revcenter+''''
END 

IF(@adtype IS NOT NULL and @adtype <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_type_code='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Agency_type ='''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_insert.Ad_Cat ='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_sub_cat_code ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_Subcat3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_Subcat4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_subcat5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Package_code ='''+@package+''''
END 

IF(@scheme IS NOT NULL and @scheme <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Scheme_type_code ='''+@scheme+''''
END 

IF(@agency IS NOT NULL and @agency <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Agency_code ='''+@agency+''''
END 

IF(@client IS NOT NULL and @client  <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Client_code ='''+@client+''''
END 

IF(@executive IS NOT NULL and @executive <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Executive_code ='''+@executive+''''
END 

IF(@retainer IS NOT NULL and @retainer <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.RETAINER ='''+@retainer+''''
END 

IF(@product IS NOT NULL and @product <>'') begin
	set @query4=@query4 + ' and TBL_BOOKING_MAST.Product_code ='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Brand_code ='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Variant_code ='''+@varient+''''
END 

IF(@pagetype IS NOT NULL and @pagetype <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Page_type_code ='''+@pagetype+''''
END 

IF(@pageprem IS NOT NULL and @pageprem <>'') begin
	set @query4=@query4 + ' and TBL_BOOKING_insert.Premium1 ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem <>'') begin
	set @query4=@query4 + ' and TBL_BOOKING_insert.Page_Post ='''+@postprem+''''
END 

IF(@rostatus IS NOT NULL and @rostatus <>'') begin
	set @query4=@query4 + ' and TBL_BOOKING_MAST.ro_status ='''+@rostatus+''''
END 

IF(@booktype IS NOT NULL and @booktype <>'') begin
	set @query4=@query4 + ' and TBL_BOOKING_MAST.Booking_type ='''+@booktype+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'') begin
	set @query4=@query4 + ' and TBL_BOOKING_MAST.Contract_name ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment  <>'') begin
	set @query4=@query4 + ' and tbl_booking_insert.Supp_Code ='''+@suppliment+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype  <>'') begin
	set @query4=@query4 + ' and tbl_booking_MAST.Rate_code ='''+@ratetype+''''
END 

IF(@city  IS NOT NULL and @city  <>'') begin
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

IF(@zone  IS NOT NULL and @zone  <>'') begin
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

IF(@district  IS NOT NULL and @district  <>'') begin
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

IF(@state  IS NOT NULL and @state  <>'') begin
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

IF(@taluka  IS NOT NULL and @taluka  <>'') begin
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

print(@query3+@queryp+@query4)
exec(@query3+@queryp+@query4)

end end

else

if(@adcheck=1) begin
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

	IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' ) begin
		set @query4=' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
	END 


	IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' ) begin
		set @query4=' and a.Insertion_date  between  '''+@fromdate +''' and  '''+@dateto+''' '
	END 

end
else begin 

	IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' ) begin
		set @query4=@query4+' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
	END 

	IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' ) begin
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


IF(@publication IS NOT NULL) begin
	set @query4=@query4+'  and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.publication_Code='''+@publication+''' )    '
END 

/*
IF(@pub_cent IS NOT NULL and @pub_cent <>'') begin
	--set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Pub_Cent_Code='''+@pub_cent+''' )  '
	set @query4=@query4+'  and a.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE a.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code='''+@pub_cent+'''))'
END 
IF(@branch IS NOT NULL and @branch<>'') begin
	set @query4=@query4+' and a.branch ='''+@branch+''''
END */



IF(@pub_cent IS NOT NULL) begin
	set @query4=@query4+'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
END 


IF(@branch IS NOT NULL  and @branch<>'') begin
	set @query4=@query4+'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
END 


IF(@edition IS NOT NULL and @edition<>'') begin
	set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Edition_Code='''+@edition+''' )'
END 



IF(@region IS NOT NULL and @region <>'') begin
	--set @query4=@query4 +'  and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+@region +''') )'
	set @query4=@query4 +'  and agency_mast.region ='''+@region+''''
END 

IF(@suppliment  IS NOT NULL and @suppliment  <>'') begin
	set @query4=@query4 + '  and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Supp_Code ='''+@suppliment+''' )'
END 


IF(@revcenter IS NOT NULL and @revcenter <>'') begin
	set @query4=@query4 +' and a.Revenue_center ='''+@revcenter+''''
END 

IF(@adtype IS NOT NULL and @adtype <>'') begin
	set @query4=@query4 + ' and a.Ad_type_code='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype <>'') begin
	set @query4=@query4 + ' and a.Agency_type ='''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat <>'') begin
	set @query4=@query4 + ' and a.Ad_cat_code ='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat <>'') begin
	set @query4=@query4 + ' and a.Ad_sub_cat_code ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'') begin
	set @query4=@query4 + ' and a.Ad_Subcat3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'') begin
	set @query4=@query4 + ' and a.Ad_Subcat4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'') begin
	set @query4=@query4 + ' and a.Ad_subcat5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package <>'') begin
	set @query4=@query4 + ' and a.Package_code ='''+@package+''''
END 

IF(@scheme IS NOT NULL and @scheme <>'') begin
	set @query4=@query4 + ' and a.Scheme_type_code ='''+@scheme+''''
END 

IF(@agency IS NOT NULL and @agency <>'') begin
	set @query4=@query4 + ' and a.Agency_code ='''+@agency+''''
END 

IF(@client IS NOT NULL and @client  <>'') begin
	set @query4=@query4 + ' and a.Client_code ='''+@client+''''
END 

IF(@executive IS NOT NULL and @executive <>'') begin
	set @query4=@query4 + ' and a.Executive_code ='''+@executive+''''
END 

IF(@retainer IS NOT NULL and @retainer <>'') begin
	set @query4=@query4 + ' and a.RETAINER ='''+@retainer+''''
END 

IF(@product IS NOT NULL and @product <>'') begin
	set @query4=@query4 + ' and a.Product_code ='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand <>'') begin
	set @query4=@query4 + ' and a.Brand_code ='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient <>'') begin
	set @query4=@query4 + ' and a.Variant_code ='''+@varient+''''
END 

IF(@pagetype IS NOT NULL and @pagetype <>'') begin
	set @query4=@query4 + ' and a.Page_type_code ='''+@pagetype+''''
END 

IF(@pageprem IS NOT NULL and @pageprem <>'') begin
	set @query4=@query4 + ' and a.Page_prem ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem <>'') begin
	set @query4=@query4 + ' and a.Page_position_code ='''+@postprem+''''
END 

IF(@rostatus IS NOT NULL and @rostatus <>'') begin
	set @query4=@query4 + ' and a.ro_status ='''+@rostatus+''''
END 

IF(@booktype IS NOT NULL and @booktype <>'') begin
	set @query4=@query4 + ' and a.Booking_type ='''+@booktype+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'') begin
	set @query4=@query4 + ' and a.Contract_name ='''+@contractname +''''
END 



IF(@ratetype  IS NOT NULL and @ratetype  <>'') begin
	set @query4=@query4 + ' and a.Rate_code ='''+@ratetype+''''
END 

IF(@city  IS NOT NULL and @city  <>'') begin
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

IF(@zone  IS NOT NULL and @zone  <>'') begin
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

IF(@district  IS NOT NULL and @district  <>'') begin
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

IF(@state  IS NOT NULL and @state  <>'') begin
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

IF(@taluka  IS NOT NULL and @taluka  <>'') begin
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
fetch next from c2 into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME
	while @@FETCH_STATUS=0 begin
		insert into #temp_ad_bills_report select * from dbo.FUN_BILL_INSERT(@compcode,@v2_CIOID,@v2_BILLNO,@prefer,@dateformat,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME,@base )  

fetch next from c2 into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME

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



IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL ) begin
	set @query4= '  BILLDATE between  '''+@fromdate +''' and  '''+@dateto+''' '
END 

IF(@publication IS NOT NULL and @publication<>'') begin
	set @query4=@query4+ ' and PRIPUB='''+@publication+''''
END 

IF(@pub_cent IS NOT NULL and @pub_cent<>'') begin
	set @query4=@query4+ '   and PUB_CENT_CODE='''+@pub_cent+''''
END 

IF(@edition IS NOT NULL and @edition<>'') begin
	set @query4=@query4+ '  and PEDITION='''+@edition+''''
END 

IF(@branch IS NOT NULL and @branch<>'') begin
	set @query4=@query4+ '  and  BRANCH_NAME ='''+@branch+''' '
END 

IF(@region IS NOT NULL and @region<>'') begin
	set @query4=@query4 +' and REGION='''+@region +''''
END 

IF(@adtype IS NOT NULL and @adtype<>'') begin
	set @query4=@query4 + ' and PADTYPE='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype<>'') begin
	set @query4=@query4 + ' and AGENCY_TYPE_CODE= '''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat<>'') begin
	set @query4=@query4 + ' and PRIADCTG='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat<>'') begin
	set @query4=@query4 + ' and SECADCTG ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3<>'') begin
	set @query4=@query4 + ' and AD_SUBCAT3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4<>'') begin
	set @query4=@query4 + ' and AD_SUBCAT4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5<>'') begin
	set @query4=@query4 + ' and AD_SUBCAT5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package<>'') begin
	set @query4=@query4 + ' and PACKAGE_CODE='''+@package+''''
END 

IF(@agency IS NOT NULL and @agency<>'') begin
	set @query4=@query4 + ' and AG_MAIN_CODE ='''+@agency +''''
END 

IF(@client IS NOT NULL and @client<>'') begin
	set @query4=@query4 + ' and CLIENTCD='''+@client +''''
END 

IF(@executive IS NOT NULL and @executive<>'') begin
	set @query4=@query4 + ' and EXECUTIVE_NAME='''+@executive+''''
END 

IF(@product IS NOT NULL and @product<>'') begin
	set @query4=@query4 + ' and PRIPROCTG='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand<>'') begin
	set @query4=@query4 + ' and BRAND_CODE='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient<>'') begin
	set @query4=@query4 + ' and   VARIENT_NAME='''+@varient+''''
END 

IF(@pageprem IS NOT NULL and @pageprem<>'') begin
	set @query4=@query4 + ' and PAGE_PREM ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem<>'') begin
	set @query4=@query4 + ' and PAGE_POST ='''+@postprem+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'') begin
	set @query4=@query4 + ' and CONTRACT_NAME ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment<>'') begin
	set @query4=@query4 + ' and SUPP_CODE='''+@suppliment+''''
END 

IF(@retainer IS NOT NULL and @retainer<>'') begin
	set @query4=@query4 + ' and RETAINER_CODE='''+@retainer+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype<>'') begin
	set @query4=@query4 + ' and RATECD ='''+@ratetype+''''
END 

IF(@scheme IS NOT NULL and @scheme<>'') begin
	set @query4=@query4 + ' and PSCHEME='''+@scheme+''''
END 

IF(@revcenter IS NOT NULL and @revcenter<>'') begin
	set @query4=@query4 +' and REVENUE_CENTER='''+@revcenter+''''
END 

IF(@rostatus IS NOT NULL and @rostatus<>'') begin
	set @query4=@query4 + ' and RO_STATUS='''+@rostatus+''''
END 

IF(@pagetype IS NOT NULL and @pagetype<>'') begin
	set @query4=@query4 + ' and PAGE_TYPE ='''+@pagetype+''''
END 

IF(@booktype IS NOT NULL and @booktype<>'') begin
	set @query4=@query4 + ' and BOOKING_TYPE='''+@booktype+''''
END 

IF(@city  IS NOT NULL and @city<>'') begin
	set @query4=@query4 + ' and CITY_CODE ='''+@city+''''
END 

IF(@zone  IS NOT NULL and @zone<>'') begin
	set @query4=@query4 + ' and ZONE_CODE ='''+@zone+''''
end 

IF(@district  IS NOT NULL and @district<>'') begin
	set @query4=@query4 + ' and DIST_CODE ='''+@district+''''
end 

IF(@state  IS NOT NULL and @state<>'') begin
	set @query4=@query4 + ' and STATE_CODE ='''+@state+''''
end 

IF(@taluka  IS NOT NULL and @taluka<>'') begin
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

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL) begin
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


IF(@publication IS NOT NULL) begin
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
END */

IF(@pub_cent IS NOT NULL) begin
	set @query4=@query4+'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
END 


IF(@branch IS NOT NULL  and @branch<>'') begin
	set @query4=@query4+'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
END 

IF(@edition IS NOT NULL and @edition<>'') begin
	set @query4=@query4 +'  and b.Edition_Code='''+@edition+''''
END 

IF(@region IS NOT NULL and @region <>'') begin
	--set @query4=@query4  +' and b.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+@region +''')'
	set @query4=@query4  +' and agency_mast.region ='''+@region+''''

END 

IF(@revcenter IS NOT NULL and @revcenter <>'') begin
	set @query4=@query4  +' and a.Revenue_center ='''+@revcenter+''''
END 

IF(@adtype IS NOT NULL and @adtype <>'') begin
	set @query4=@query4  + ' and a.Ad_type_code='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype <>'') begin
	set @query4=@query4  + ' and a.Agency_type ='''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat <>'') begin
	set @query4=@query4  + ' and b.Ad_Cat ='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat <>'') begin
	set @query4=@query4  + ' and a.Ad_sub_cat_code ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'') begin
	set @query4=@query4  + ' and a.Ad_Subcat3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'') begin
	set @query4=@query4  + ' and a.Ad_Subcat4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'') begin
	set @query4=@query4  + ' and a.Ad_subcat5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package <>'') begin
	set @query4=@query4  + ' and a.Package_code ='''+@package+''''
END 

IF(@scheme IS NOT NULL and @scheme <>'') begin
	set @query4=@query4  + ' and a.Scheme_type_code ='''+@scheme+''''
END 

IF(@agency IS NOT NULL and @agency <>'') begin
	set @query4=@query4  + ' and a.Agency_code ='''+@agency+''''
END 

IF(@client IS NOT NULL and @client  <>'') begin
	set @query4=@query4  + ' and a.Client_code ='''+@client+''''
END 

IF(@executive IS NOT NULL and @executive <>'') begin
	set @query4=@query4  + ' and a.Executive_code ='''+@executive+''''
END 

IF(@retainer IS NOT NULL and @retainer <>'') begin
	set @query4=@query4  + ' and a.RETAINER ='''+@retainer+''''
END 

IF(@product IS NOT NULL and @product <>'') begin
	set @query4=@query4 + ' and a.Product_code ='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand <>'') begin
	set @query4=@query4  + ' and a.Brand_code ='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient <>'') begin
	set @query4=@query4  + ' and a.Variant_code ='''+@varient+''''
END 

IF(@pagetype IS NOT NULL and @pagetype <>'') begin
	set @query4=@query4  + ' and a.Page_type_code ='''+@pagetype+''''
END 

IF(@pageprem IS NOT NULL and @pageprem <>'') begin
	set @query4=@query4 + ' and b.Premium1 ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem <>'') begin
	set @query4=@query4 + ' and b.Page_Post ='''+@postprem+''''
END 

IF(@rostatus IS NOT NULL and @rostatus <>'') begin
	set @query4=@query4 + ' and a.ro_status ='''+@rostatus+''''
END 

IF(@booktype IS NOT NULL and @booktype <>'') begin
	set @query4=@query4 + ' and a.Booking_type ='''+@booktype+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'') begin
	set @query4=@query4 + ' and a.Contract_name ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment  <>'') begin
	set @query4=@query4 + ' and b.Supp_Code ='''+@suppliment+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype  <>'') begin
	set @query4=@query4 + ' and a.Rate_code ='''+@ratetype+''''
END 

IF(@city  IS NOT NULL and @city  <>'') begin
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

IF(@zone  IS NOT NULL and @zone  <>'') begin
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

IF(@district  IS NOT NULL and @district  <>'') begin
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

IF(@state  IS NOT NULL and @state  <>'') begin
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

IF(@taluka  IS NOT NULL and @taluka  <>'') begin
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
drop table #MULTIPACK_RATNEW*/

/***************end of issue 7141 *******************************************

//=======================************* Start Procedure Scripts ***************===============//
                                                                    

ALTER PROCEDURE [dbo].[websp_modifyMatter]

@cioid as varchar(50),
@matter_filename as varchar(50),
@RTFformat as varchar(5000),
@XTGformat as varchar(5000),
@matter as varchar(5000),
@flag as varchar(2),
@receiptnumber as varchar(50),
@p_lang      as varchar(50)

AS

if(@flag='1')
begin
update tbl_matter set RTFformat=@RTFformat, XTGformat=@XTGformat,matter=@matter,LANG=@p_lang where cioid=@cioid and matter_filename=@matter_filename
end

else
begin
insert into tbl_matter(cioid,matter_filename,RTFformat,XTGformat,matter,receipt,LANG) values(@cioid,@matter_filename,@RTFformat,@XTGformat,@matter,@receiptnumber,@p_lang)
end


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER PROCEDURE [dbo].[websp_insertMatter]

@cioid as varchar(50),
@matter_filename as varchar(50),
@RTFformat as varchar(5000),
@XTGformat as varchar(5000),
@matter as varchar(5000),
@receiptno as varchar(50),
@p_lang    as varchar(50)
 AS

insert into tbl_matter(cioid,matter_filename,RTFformat,XTGformat,matter,receipt,LANG) values(@cioid,@matter_filename,@RTFformat,@XTGformat,@matter,@receiptno,@p_lang)


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


ALTER PROCEDURE [dbo].[pending_for_dummy]
@pcompcode       as varchar(20),
@ppubcenter      as varchar(2000), 
@padtype         as varchar(20),
@ppubfrdate       as datetime,
@ppubtodate       as datetime,
@ppublcode       as varchar(20),
@pedtncode       as varchar(20),
@psuplcode       as varchar(20),
@preason         as varchar(20),--1 for unapproval ,2 for unaduited 3 for material not upload
@pdateformat     as varchar(20),
@puserid         as varchar(20),
@pextra1         as varchar(2000),
@pextra2         as varchar(2000),
@pextra3         as varchar(2000),
@pextra4         as varchar(2000),
@pextra5         as varchar(2000)

as
declare @v_frdt                datetime
declare @v_todt                datetime
declare @v_approval_flag    varchar(1)

if @ppubcenter='' begin
    set @ppubcenter =null
end
if @padtype='' begin
    set @padtype =null
end    
if @ppublcode='' begin
    set @ppublcode =null
end    
if @pedtncode='' begin
    set @pedtncode =null
end    
if @psuplcode='' begin
    set @psuplcode =null
end    
if @preason='' begin
    set @preason=null
end
    
    declare c1 cursor for
    select distinct x.comp_code AS "COMP_CODE",x.cio_booking_id AS "CIO_BOOKING_ID",x.date_time AS "DATE_TIME",x.agency_code AS "AGENCY_CODE",x.sub_agency_code AS "SUB_AGENCY_CODE" ,x.agency_name AS "AGENCY_NAME",
    x.client_name AS "CLIENT_NAME",x.package_code AS "PACKAGE_CODE",x.package_name AS "PACKAGE_NAME",
    x.ad_cat as "AD_CAT",x.category_name as "CATEGORY_NAME",x.edition as "EDITION",x.no_insert "NO_INSERT",
    x.discount as "DISCOUNT",x."AUDIT" AS "AUDIT",x.file_name AS "FILE_NAME",x.reason_type as "REASON_TYPE" from
    (select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    isnull((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",NULL AS "EDITION",1 "NO_INSERT",
    isnull(m."Discount",0)+isnull(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",NULL AS "FILE_NAME",'1' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=@pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and (i."Insert_Date" between @v_frdt and @v_todt) and 
            m."Ad_type_code"=isnull(@padtype,m."Ad_type_code") and i."Pub_Cent_Code"=isnull(@ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=isnull(@ppublcode,i."Publication_Code") and
            i."Edition_Code"=isnull(@pedtncode,i."Edition_Code") and i."Supp_Code"=isnull(@psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','publish','audit by rate','billed','hold') and
            (isnull(m."Discount",0)+isnull(m."Special_discount",0))>0 and isnull(m.app_status,'N')='N' and @v_approval_flag='D' 
    union
    select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    isnull((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",NULL AS "EDITION",1 "NO_INSERT",
    isnull(m."Discount",0)+isnull(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",NULL AS "FILE_NAME",'2' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=@pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and (i."Insert_Date"  between @v_frdt and @v_todt) and 
            m."Ad_type_code"=isnull(@padtype,m."Ad_type_code") and i."Pub_Cent_Code"=isnull(@ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=isnull(@ppublcode,i."Publication_Code") and
            i."Edition_Code"=isnull(@pedtncode,i."Edition_Code") and i."Supp_Code"=isnull(@psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','publish','audit by rate','billed','hold') and
            (isnull(m."Discount",0)+isnull(m."Special_discount",0))>0 and m."audit" is null and isnull(m.app_status,'N')='Y' and @v_approval_flag='D'
    union
    select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    isnull((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",NULL AS "EDITION",1 "NO_INSERT",
    isnull(m."Discount",0)+isnull(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",NULL AS "FILE_NAME",'2' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=@pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and (i."Insert_Date"  between @v_frdt and @v_todt) and 
            m."Ad_type_code"=isnull(@padtype,m."Ad_type_code") and i."Pub_Cent_Code"=isnull(@ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=isnull(@ppublcode,i."Publication_Code") and
            i."Edition_Code"=isnull(@pedtncode,i."Edition_Code") and i."Supp_Code"=isnull(@psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','publish','audit by rate','billed','hold') and
            m."audit" is null and @v_approval_flag='N'
    union
    select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    isnull((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",i."Edition" AS "EDITION",i."No_Insert" "NO_INSERT",
    isnull(m."Discount",0)+isnull(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",i."File_Name" AS "FILE_NAME",'3' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=@pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and (i."Insert_Date"  between @v_frdt and @v_todt) and 
            m."Ad_type_code"=isnull(@padtype,m."Ad_type_code") and i."Pub_Cent_Code"=isnull(@ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=isnull(@ppublcode,i."Publication_Code") and
            i."Edition_Code"=isnull(@pedtncode,i."Edition_Code") and i."Supp_Code"=isnull(@psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','publish','audit by rate','billed','hold') and
            m."audit" is not null and i."File_Name" is null) x where reason_type=isnull(@preason,reason_type)
            order by reason_type,date_time,cio_booking_id,edition;        
declare @v1_comp_code        varchar(500)
declare @v1_cio_booking_id    varchar(500)
declare @v1_date_time        datetime
declare @v1_agency_code        varchar(500)
declare @v1_sub_agency_code varchar(500)
declare @v1_agency_name        varchar(500)
declare @v1_client_name        varchar(500)
declare @v1_package_code    varchar(500)
declare @v1_package_name    varchar(500)
declare @v1_ad_cat            varchar(500)
declare @v1_category_name    varchar(500)
declare @v1_edition            varchar(500)
declare @v1_no_insert        varchar(500)
declare @v1_discount        varchar(500)
declare @v1_AUDIT            varchar(500)
declare @v1_file_name        varchar(500)
declare @v1_reason_type        varchar(500)
declare @v_rec_count        int
BEGIN

    
CREATE TABLE #TEMP_AD_BILLS_REPORT
( CIOID             VARCHAR(50),
  AGENCY            VARCHAR(50),
  CLIENT            VARCHAR(200),
  RONO              VARCHAR(40),
  RODATE            DATETIME,
  ADCAT             VARCHAR(500),
  PACKAG            VARCHAR(500),
  NOINSERT          INT,
  COMP_CODE         VARCHAR(10),
  PACKAGE_CODE      VARCHAR(500),
  AG_MAIN_CODE      VARCHAR(10),
  AG_SUB_CODE       VARCHAR(10),
  CLIENTCD          VARCHAR(200),
  PAGE_TYPE         VARCHAR(100),
  PAGE_NO           NUMERIC(10),
  padtype            VARCHAR(100))
  
    set @v_approval_flag='N'
    
    select @v_approval_flag=relauthreqon from preferrences where "comp_code"=@pcompcode;
    
    Open c1;

        fetch NEXT FROM c1 INTO @v1_comp_code ,@v1_cio_booking_id ,@v1_date_time, @v1_agency_code , @v1_sub_agency_code,@v1_agency_name,
            @v1_client_name,@v1_package_code,@v1_package_name ,@v1_ad_cat ,@v1_category_name ,@v1_edition ,@v1_no_insert ,
            @v1_discount ,@v1_AUDIT ,@v1_file_name ,@v1_reason_type,@v_rec_count
        WHILE (@@FETCH_STATUS = 0) BEGIN

        set @v_rec_count=isnull(@v_rec_count,0)+1;
        
        insert into #TEMP_AD_BILLS_REPORT
                (cioid,                rodate,        client,            package_code,        adcat,        packag,         comp_code,    padtype,  ag_main_code,   ag_sub_code,        noinsert
        ,clientcd,page_type,page_no)
        values(@v1_cio_booking_id,@v1_date_time,@v1_client_name,@v1_package_code,@v1_ad_cat,@v1_package_name,@v1_comp_code,@padtype,@v1_agency_code,@v1_sub_agency_code,@v1_no_insert
            ,@v1_edition,@v1_reason_type,@v_rec_count);        
       -- values(@v1_cio_booking_id,@v1_date_time,@v1_client_name,@v1_agency_name,@v1_category_name,@v1_package_name,@v1_comp_code,@padtype,@v1_agency_code,@v1_sub_agency_code,@v1_no_insert,@v1_edition,@v1_reason_type,@v_rec_count);
        
        fetch NEXT FROM c1 INTO @v1_comp_code ,@v1_cio_booking_id ,@v1_date_time, @v1_agency_code , @v1_sub_agency_code,@v1_agency_name,
            @v1_client_name,@v1_package_code,@v1_package_name ,@v1_ad_cat ,@v1_category_name ,@v1_edition ,@v1_no_insert ,
            @v1_discount ,@v1_AUDIT ,@v1_file_name ,@v1_reason_type,@v_rec_count
    End
    Close c1;        
    deallocate c1;
    
    select comp_code as "COMP_CODE",cioid as "BKID",rodate as "BK_DATE",client as "CLIENT_NAME"
    ,package_code as "AGENCY_NAME",adcat as "CAT_NAME",
    packag as "PACKAGE_NAME",padtype as "AD_TYPE",ag_main_code as "AG_MAIN_CODE"
    ,ag_sub_code as "AG_SUB_CODE",noinsert as "NOINSERT",
    clientcd as "EDITION",page_type as "REASON_TYPE",page_no as "REC_NO"
    from #temp_ad_bills_report order by rec_no;
    
    drop table #TEMP_AD_BILLS_REPORT;
END




//=======================************* End of Procedure Scripts ***************===============//

//=======================************* Start Procedure Scripts ***************===============//
ALTER PROCEDURE [dbo].[bindaudit]
--@code			as varchar(10),
@fromdate		as varchar(10),
@todate			as varchar(10),
@date			as varchar(15),
@branch1		as varchar(50),
@adtype			as varchar(50),
@audittype		as VARCHAR(50),
@branch2		as VARCHAR(50),
@v_Cat			as varchar(50),
@comp_code		as varchar(50),
@package_code   as varchar(100),
@pagency_code   as varchar(100),
@pclient_code   as varchar(100),
@psection_code  as varchar(100),
@p_booktype     as varchar(100),--A for all ,D for Direct ,Q for Qbc Booking
@extra1         as varchar(100),--for UOM
@extra2         as varchar(100),
@extra3         as varchar(100),
@extra4         as varchar(100)
AS

declare @v_approval_req		as varchar(1)
declare @query				as varchar(8000)

    set @v_approval_req='N'
    
    select @v_approval_req=relauthreqon from preferrences where "comp_code"=@comp_code
    
IF (@audittype = 'audit') begin
    IF(@branch1='All') begin
        set @query  ='SELECT distinct m.cio_booking_id cio_booking_id,
        isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,
        (select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name <> null ) as FILENAME,
        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m. Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
        case when @v_approval_req=''N'' then ''Y'' else
            case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
        end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m."Insertion_date",101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m."Insertion_date",103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m."Insertion_date",102) END AS "INSERT_DATE",
        m."Insertion_date" dd        
        FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i WHERE m.date_time BETWEEN '''+@fromdate+''' AND '''+@todate+'''
        AND m.Ad_type_code='''+@Adtype+''' AND m.audit <>''''
        AND m.cio_booking_id=i.cio_booking_id'
        --and (branch=@branch2 OR  @branch2 IS NULL)
        --and (m.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL)
    end
    ELSE begin
        set @query  ='SELECT distinct m.cio_booking_id cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code)
        as Client_code,m.audit audit,m.Ad_type_code Ad_type_code,(select top 1  File_Name from tbl_booking_insert
        where Cio_Booking_Id=m.cio_booking_id and File_Name <> null ) as FILENAME,
        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
		case when @v_approval_req=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m."Insertion_date",101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m."Insertion_date",103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m."Insertion_date",102) END AS "INSERT_DATE",
        m."Insertion_date" dd		
        FROM
        TBL_BOOKING_MAST m,tbl_booking_insert i WHERE  m.date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''' AND m.branch IN (SELECT Branch_CODE FROM BRANCH_MST
        WHERE pub_center=(SELECT top 1 Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+'''))
        AND m.Ad_type_code='''+@Adtype+'''  AND  m.audit <> ''''
        AND m.cio_booking_id=i.cio_booking_id'
        --and (branch=@branch2 OR  @branch2 IS NULL)
        --AND (m.Ad_cat_code=@v_Cat OR  @v_Cat IS NULL)
     END
END
IF (@audittype = 'unaudit') begin
    IF(@branch1='All')begin
                     
        set @query  =' SELECT  distinct m.cio_booking_id cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,
        (select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name <> null) as FILENAME,

        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
		case when @v_approval_req=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m."Insertion_date",101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m."Insertion_date",103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m."Insertion_date",102) END AS "INSERT_DATE",
        m."Insertion_date" dd
        FROM
        TBL_BOOKING_MAST m,tbl_booking_insert i WHERE  m.cio_booking_id=i.cio_booking_id
        AND m.Ad_type_code='''+@Adtype+''' AND audit = ''''
        and m.date_time BETWEEN '''+@fromdate+''' AND '''+@todate +'''
        and isnull(m.modified_audit,''N'')!=''Y'''
    end         
    ELSE begin
        set @query  =' SELECT distinct m.cio_booking_id cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,
        (select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name <> null ) as FILENAME ,


        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
        case when @v_approval_req=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m."Insertion_date",101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m."Insertion_date",103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m."Insertion_date",102) END AS "INSERT_DATE",
        m."Insertion_date" dd
        FROM TBL_BOOKING_MAST m,tbl_booking_insert i WHERE m.cio_booking_id=i.cio_booking_id AND
        branch IN(SELECT Branch_CODE FROM BRANCH_MST WHERE pub_center=(SELECT  top 1 Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+''' ))
        AND m.Ad_type_code='''+@Adtype+''' AND m.audit = ''''
        AND m.date_time BETWEEN '''+@fromdate+''' AND '''+@todate+'''
        and isnull(m.modified_audit,''N'')!=''Y'''
    END
END

IF (@audittype = 'modified') begin
    IF(@branch1='All')begin

        set @query  ='SELECT distinct m.cio_booking_id cio_booking_id,
        isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,(select top 1 File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name <> null ) as FILENAME,
        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
		case when @v_approval_req=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m."Insertion_date",101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m."Insertion_date",103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m."Insertion_date",102) END AS "INSERT_DATE",
        m."Insertion_date" dd        
        FROM TBL_BOOKING_MAST m,tbl_booking_insert i WHERE m.cio_booking_id=i.cio_booking_id AND
        m.Ad_type_code='''+@Adtype+''' AND m.date_time BETWEEN '''+@fromdate+''' AND '''+@todate+'''
        and isnull(m.modified_audit,''N'')!=''Y'''
    end        
    ELSE begin

        set @query  ='SELECT distinct m.cio_booking_id,
        isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,(select top 1 File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name is not null
        ) as FILENAME,
        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT ,
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
		case when @v_approval_req=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m."Insertion_date",101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m."Insertion_date",103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m."Insertion_date",102) END AS "INSERT_DATE",
        m."Insertion_date" dd        
        FROM TBL_BOOKING_MAST m,tbl_booking_insert i WHERE m.cio_booking_id=i.cio_booking_id AND
        m.branch IN(SELECT Branch_CODE FROM BRANCH_MST WHERE pub_center=(SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+''')) AND
        m.Ad_type_code='''+@Adtype+''' AND m.date_time BETWEEN '''+@fromdate+''' AND '''+@todate+'''
        and isnull(m.modified_audit,''N'')!=''Y'''
    END
END

if(@package_code <> null or @package_code <> '') begin
    set @query= @query+' and i.package_code in ('''+@package_code+''') '
end

if(@pagency_code <> null or @pagency_code <> '') begin
    set @query= @query+' and m.Agency_sub_code in ('''+@pagency_code+''') '
end

if(@pclient_code <> null or @pclient_code <> '') begin
    set @query= @query+' and m.Client_code in ('''+@pclient_code+''') '
end

if(@psection_code <> null or @psection_code <> '') begin
    set @query= @query+' and i.SECTIONCODE in ('''+@psection_code+''') '
end

if(@branch2 <> null or @branch2 <> '') begin
    set @query= @query+' and m.branch='''+@branch2+''' '
end

if(@v_Cat <> null or @v_Cat <> '') begin
    set @query=@query+' and m.Ad_cat_code='''+@v_Cat+''' '
end

if(@extra1 <> null or @extra1 <> '') begin
    set @query=@query+' and m."Uom_code"='''+@extra1+''' '
end

set @query=@query+' order by m."Insertion_date",m."cio_booking_id"';

print(@query)
exec(@query)
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

CREATE function fetch_unpublish_edtn(
    @pcompcode       varchar(20),
    @pcioid          varchar(20),
    @pinsertion_no   int,
    @pinsertion_type varchar(20),--1 for single insertion or 2 for all insertion
    @pshowedtn       varchar(20),--for Y show edtn and N for NOt show
    @pextra1         varchar(20),
    @pextra2         varchar(20)) returns varchar(200) 
as
Begin
declare @v_val   varchar(2000)
declare @v_edtn  varchar(200)

declare @v1_edtn	varchar(50)

DECLARE c1 CURSOR FOR 
	select distinct x.edtn edtn from
(select distinct "Edition" edtn from tbl_booking_insert 
        where "Comp_Code"=@pcompcode and "Cio_Booking_Id"=@pcioid and 
        "No_Insert" =@pinsertion_no and "Insert_Status" in('booked','hold') and bill_no is null and 
        @pinsertion_type='1' 
    union        
    select distinct "Edition" edtn from tbl_booking_insert 
        where "Comp_Code"=@pcompcode and "Cio_Booking_Id"=@pcioid 
        and "Insert_Status" in('booked','hold') and bill_no is null and @pinsertion_type='2') x

If isnull(@pshowedtn,'N')='Y' Begin
    open c1
        FETCH NEXT FROM c1 into @v1_edtn
        WHILE (@@FETCH_STATUS = 0) BEGIN
        set @v_edtn=@v1_edtn

        if (@v_val is null) Begin
            set @v_val=@v_edtn
        end    
        else begin
            set @v_val=@v_val +','+ @v_edtn
        end
        FETCH NEXT FROM c1 into @v1_edtn
    end
    close C1;
End
else Begin
    select @v_val=sum(x.edtn) from 
    (select  count(distinct "Edition") edtn from tbl_booking_insert 
        where "Comp_Code"=@pcompcode and "Cio_Booking_Id"=@pcioid and 
        "No_Insert" =@pinsertion_no and "Insert_Status" in('booked','hold') and bill_no is null and 
        @pinsertion_type='1' 
    union        
    select count(distinct "Edition") edtn from tbl_booking_insert 
        where "Comp_Code"=@pcompcode and "Cio_Booking_Id"=@pcioid 
        and "Insert_Status" in('booked','hold') and bill_no is null and @pinsertion_type='2') x
end

return @v_val

END

//=======================************* End of Procedure Scripts ***************===============//




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

/////////////////////////////////statr of issue no 7477/////////////



                                                                     
                                                                     
                                                                     
                                             
ALTER PROCEDURE getapprovalRo_web
@vusername		as	varchar(50),
@compcode		as	varchar(50),
@agency			as	varchar(50),
@executive		as  varchar(50),
@client			as	varchar(50),
@varFromDate	as	datetime,
@varToDate		as	datetime,
@dateformat		as	varchar(20),
@cioid			as	varchar(50),
@flag			as	varchar(1),
@pbranch        as	varchar(20),
@pdate_based_on as	varchar(20),--for Booking date B,Publish Date P
@porder         as	varchar(20)--1 for deviation asce ,2 for deviation desc
AS
declare @query varchar(3000)

declare @RELAUTHREQ as varchar(1)

BEGIN

select @RELAUTHREQ=RELAUTHREQON from preferrences where comp_code=@compcode

if(@flag='A') begin

	set @query='SELECT (select Agency_Name from agency_mast where Comp_Code='''+@compcode+''' and code_subcode=tbl_booking_mast.Agency_sub_code) agency,
	(select Package_Name from combin_mast where Comp_Code='''+@compcode+''' and Combin_Code=(
	case when charindex(''abcdef'','','') >0 then 
	substrING(Package_code,1,charindex(Package_code,'','')-1)  
	else Package_code end)) as Package,
	case '''+@dateformat+''' when ''dd/mm/yyyy'' then
	convert(varchar(12),date_time,103)  when ''mm/dd/yyyy'' then convert(varchar(12),date_time,101) 
	else convert(varchar(12),date_time,111)  end  as bookdate,
	(select Cust_Name from cust_mast where Comp_Code='''+@compcode+''' and Cust_Code= Client_code) client,
	RO_No,case '''+@dateformat+''' when ''dd/mm/yyyy'' then convert(varchar(12),ro_date,103) 
	when ''mm/dd/yyyy'' then convert(varchar(12),ro_date,101) 
	else convert(varchar(12),ro_date,111) end  as rodate,(select Exec_name from exec_mast where  Exe_no = Executive_code) executive,
	(select Retain_Name from retainermaster where Comp_Code='''+@compcode+''' and Retain_Code= RETAINER) retainer,Card_rate,
	DBO.Fn_Deviatio(tbl_booking_mast.Card_rate,tbl_booking_mast.Agrred_rate) as deviation,cio_booking_id ,Bill_amount,Gross_amount,
	(select premiumname from advpos_prem_mast where comp_code='''+@compcode+''' and Premiumcode=tbl_booking_mast.Page_prem) as PAGEPERM,APP_STATUS,booked_by,
	(select top 1 Payment_Mode_Name from payment_mode_mast where Comp_Code='''+@compcode+''' and Pay_Mode_Code=tbl_booking_mast.Agency_pay) as "paymode",Receipt_no
	from tbl_booking_mast where Comp_code='''+@compcode+'''  and APP_STATUS=''Y'' and (DBO.Fn_Deviatio(tbl_booking_mast.Card_rate,tbl_booking_mast.Agrred_rate)!=''0'' OR DBO.Fn_chkSalesExec(tbl_booking_mast.Userid)=''SE0'' or ''' + @RELAUTHREQ+ '''= ''A'')'
	---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------BHANU
	if @agency!='' begin
		set @query = @query + ' and Agency_sub_code = '''+@agency+''''
	end
	if @executive!='' begin
		set @query = @query + ' and Executive_code = '''+ @executive+''''
	end
	if @client!='' begin
		set @query = @query + ' and Client_code = '''+ @client+''''
	end
	if @cioid!='' begin
		set @query = @query + ' and cio_booking_id = '''+ @cioid+''''
	end

    if @pdate_based_on='P' begin--On Published date
        set @query=@query+' and i."Insert_Date" between '''+CAST(@varFromDate AS VARCHAR(20))+''' and '''+CAST(@varToDate AS VARCHAR(20))+''''
    end
    else begin--on Booking date
        set @query = @query + ' and date_time between '''+ CAST(@varFromDate AS VARCHAR(20))+''' and '''+ CAST(@varToDate AS VARCHAR(20))+''''
    end
    
    if @pbranch ='B' begin--If B then Data will show Acc. to Branch Permission
        set @query = @query +' AND m."branch" in(select ltrim(rtrim(branch_code)) from login_branch_mast where user_code='''+@vusername+''' and comp_code='''+@compcode+''' and user_flag=''Y'')';
    end
end
else if(@flag='R') begin

	set @query='SELECT (select Agency_Name from agency_mast where Comp_Code='''+@compcode+''' and code_subcode=tbl_booking_mast.Agency_sub_code) agency,
	(select Package_Name from combin_mast where Comp_Code='''+@compcode+''' and Combin_Code=(
	case when charindex(''abcdef'','','') >0 then 
	substrING(Package_code,1,charindex(Package_code,'','')-1)  
	else Package_code end)) as Package,
	case '''+@dateformat+''' when ''dd/mm/yyyy'' then convert(varchar(12),date_time,103) 
	when ''mm/dd/yyyy'' then convert(varchar(12),date_time,101) 
	else convert(varchar(12),date_time,111) end  as bookdate,
	(select Cust_Name from cust_mast where Comp_Code='''+@compcode+''' and Cust_Code= Client_code) client,
	RO_No,case '''+@dateformat+''' when ''dd/mm/yyyy'' then convert(varchar(12),ro_date,103) 
	when ''mm/dd/yyyy'' then convert(varchar(12),ro_date,101) 
	else convert(varchar(12),ro_date,111) end  as rodate,(select Exec_name from exec_mast where  Exe_no = Executive_code) executive,
	(select Retain_Name from retainermaster where Comp_Code='''+@compcode+''' and Retain_Code= RETAINER) retainer,Card_rate,
	DBO.Fn_Deviatio(tbl_booking_mast.Card_rate,tbl_booking_mast.Agrred_rate) as deviation,cio_booking_id ,Bill_amount,Gross_amount,
	(select premiumname from advpos_prem_mast where comp_code='''+@compcode+''' and Premiumcode=tbl_booking_mast.Page_prem) as PAGEPERM,APP_STATUS,booked_by,
	(select top 1 Payment_Mode_Name from payment_mode_mast where Comp_Code='''+@compcode+''' and Pay_Mode_Code=tbl_booking_mast.Agency_pay) as "paymode",Receipt_no
	from tbl_booking_mast where Comp_code='''+@compcode+'''  and  APP_STATUS=''N'' and (DBO.Fn_Deviatio(tbl_booking_mast.Card_rate,tbl_booking_mast.Agrred_rate)!=''0'' OR DBO.Fn_chkSalesExec(tbl_booking_mast.Userid)=''SE0'' or ''' + @RELAUTHREQ+ '''= ''A'')'
	----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------BHANU
	if @agency!='' begin
		set @query = @query + ' and Agency_sub_code = '''+@agency+''''
	end
	if @executive!='' begin
		set @query = @query + ' and Executive_code = '''+ @executive+''''
	end
	if @client!='' begin
		set @query = @query + ' and Client_code = '''+ @client+''''
	end
	if @cioid!='' begin
		set @query = @query + ' and cio_booking_id = '''+ @cioid+''''
	end

    if @pdate_based_on='P' begin--On Published date
        set @query=@query+' and i."Insert_Date" between '''+CAST(@varFromDate AS VARCHAR(20))+''' and '''+CAST(@varToDate AS VARCHAR(20))+''''
    end
    else begin--on Booking date
        set @query = @query + ' and date_time between '''+ CAST(@varFromDate AS VARCHAR(20))+''' and '''+ CAST(@varToDate AS VARCHAR(20))+''''
    end
    
    if @pbranch ='B' begin--If B then Data will show Acc. to Branch Permission
        set @query = @query +' AND m."branch" in(select ltrim(rtrim(branch_code)) from login_branch_mast where user_code='''+@vusername+''' and comp_code='''+@compcode+''' and user_flag=''Y'')';
    end	
end
else begin
	set @query='SELECT (select Agency_Name from agency_mast where Comp_Code='''+@compcode+''' and code_subcode=tbl_booking_mast.Agency_sub_code) agency,
	(select Package_Name from combin_mast where Comp_Code='''+@compcode+''' and Combin_Code=(
	case when charindex(''abcdef'','','') >0 then 
	substrING(Package_code,1,charindex(Package_code,'','')-1)  
	else Package_code end)) as Package,
	case '''+@dateformat+''' when ''dd/mm/yyyy'' then convert(varchar(12),date_time,103) 
	when ''mm/dd/yyyy'' then convert(varchar(12),date_time,101) 
	else convert(varchar(12),date_time,111) end  as bookdate,
	(select Cust_Name from cust_mast where Comp_Code='''+@compcode+''' and Cust_Code= Client_code) client,
	RO_No,case '''+@dateformat+''' when ''dd/mm/yyyy'' then
	convert(varchar(12),ro_date,103) 
	when ''mm/dd/yyyy'' then convert(varchar(12),ro_date,101)  else 
	convert(varchar(12),ro_date,111) end  as rodate,(select Exec_name from exec_mast where  Exe_no = Executive_code) executive,
	(select Retain_Name from retainermaster where Comp_Code='''+@compcode+''' and Retain_Code= RETAINER) retainer,Card_rate,
	DBO.Fn_Deviatio(tbl_booking_mast.Card_rate,tbl_booking_mast.Agrred_rate) as deviation,cio_booking_id ,Bill_amount,Gross_amount,
	(select premiumname from advpos_prem_mast where comp_code='''+@compcode+''' and Premiumcode=tbl_booking_mast.Page_prem) as PAGEPERM,APP_STATUS,booked_by,
	(select top 1 Payment_Mode_Name from payment_mode_mast where Comp_Code='''+@compcode+''' and Pay_Mode_Code=tbl_booking_mast.Agency_pay) as "paymode",Receipt_no
	from tbl_booking_mast where Comp_code='''+@compcode+''' and isnull(APP_STATUS,''#'')!=''Y''   and isnull(APP_STATUS,''#'')!=''N'' and (DBO.Fn_Deviatio(tbl_booking_mast.Card_rate,tbl_booking_mast.Agrred_rate)!=''0'' OR DBO.Fn_chkSalesExec(tbl_booking_mast.Userid)=''SE0'' or ''' + @RELAUTHREQ+ '''= ''A'')'
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------BHANU
	if @agency!='' begin
		set @query = @query + ' and Agency_sub_code = '''+@agency+''''
	end
	if @executive!='' begin
		set @query = @query + ' and Executive_code = '''+ @executive+''''
	end
	if @client!='' begin
		set @query = @query + ' and Client_code = '''+ @client+''''
	end
	if @cioid!='' begin
		set @query = @query + ' and cio_booking_id = '''+ @cioid+''''
	end

    if @pdate_based_on='P' begin--On Published date
        set @query=@query+' and i."Insert_Date" between '''+CAST(@varFromDate AS VARCHAR(20))+''' and '''+CAST(@varToDate AS VARCHAR(20))+''''
    end
    else begin--on Booking date
        set @query = @query + ' and date_time between '''+ CAST(@varFromDate AS VARCHAR(20))+''' and '''+ CAST(@varToDate AS VARCHAR(20))+''''
    end
    
    if @pbranch ='B' begin--If B then Data will show Acc. to Branch Permission
        set @query = @query +' AND m."branch" in(select ltrim(rtrim(branch_code)) from login_branch_mast where user_code='''+@vusername+''' and comp_code='''+@compcode+''' and user_flag=''Y'')';
    end	
end

print @query
EXEC(@query)

END


/////////////////////////////////end of issue 7477/////////////////////

///////////////////////////start issue no:7421//////////////////
USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[websp_bindcioidlatest12]    Script Date: 05/17/2012 14:29:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






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
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount",
tbl_booking_insert.Bill_Amt,
null as "UNPUBLISHED"
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
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount",

tbl_booking_insert.Bill_Amt,
null as "UNPUBLISHED"

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
,tbl_booking_insert.Bill_Amt,
null as "UNPUBLISHED"
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
,tbl_booking_insert.Bill_Amt,
null as "UNPUBLISHED"
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
,tbl_booking_insert.Bill_Amt,
null as "UNPUBLISHED"

      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id  AND
       TBL_BOOKING_INSERT.Insert_Status=''publish'' AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code' ;
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
if @v_bill_criteria='R' begin --it is for bill cycle in booking
	if(@billcycle is not null )
	begin
		set @str=@str+' and replace(TBL_BOOKING_MAST.Bill_cycle,''0'',''1'') ='''+@billcycle +''''
--print(@billcycle)
	end
end

*/

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

,tbl_booking_insert.Bill_Amt

	order by tbl_booking_insert.bill_no,cio_booking_id'
end
else
begin
	set @str=@str+' group by tbl_booking_insert.cio_booking_id,no_insert,tbl_booking_mast.package_code
	,tbl_booking_mast.client_code,tbl_booking_mast.trade_disc,AGENCY_MAST.agency_name
	,tbl_booking_insert.insert_status 
	,tbl_booking_mast.no_of_insertion ,TBL_BOOKING_MAST.Bill_remarks,tbl_booking_insert.bill_no,
	tbl_booking_insert.Comp_Code,tbl_booking_insert.Insert_Date 
,tbl_booking_insert.Bill_Amt
	order by tbl_booking_insert.cio_booking_id,tbl_booking_insert.no_insert'
end













 --select nvl(last_billno,0) as "LAST_BILLNO",to_char(v_last_dt,v_dateformat) as "LAST_BILLDT",nvl(v_billed,0) as "ALREADY_BILLED",
  --   nvl(v_booked_by_others,0) as "BOOKED_BY_OTHERS" from dual;





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


select 0 as "LAST_BILLNO",0 as "LAST_BILLDT",0 as "ALREADY_BILLED",
   0 as "BOOKED_BY_OTHERS" 


select * from #package
delete from #package


/*if(@billstatus <> null)
begin
set @str=@str+' and  TBL_BOOKING_INSERT.insert_status='''+ @billstatus +''''
End*/
////////////////////////end issue no:7421////////////////////////

//////////////////////////

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

INSERT INTO  #TMPINS VALUES (@SNUM,@EDI_NAME,@finaldate,@i,@FL) SELECT @i  = @i + 1 

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
 FROM  #TMP2 order by IDNUM,EDITION_NAME
	END
	ELSE
	BEGIN 
	SELECT  ISNULL((SELECT Combin_Desc FROM  COMBIN_MAST  WHERE	Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND	pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name", ISNULL(CONVERT(VARCHAR(10), date1, 101), '') AS "Date", EDITION_CODE, IDNUM, Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 order by IDNUM,EDITION_NAME
	END

END

IF ( @dateformat = 'dd/mm/yyyy' ) 
BEGIN 
	IF @insertiondate = null  OR @insertiondate = '' 
	BEGIN 
	SELECT ISNULL((SELECT Combin_Desc FROM  COMBIN_MAST  WHERE	 Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND	pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name", ISNULL(CONVERT(VARCHAR(10), date1, 103), '') AS "Date", EDITION_CODE, IDNUM,Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 order by IDNUM,EDITION_NAME
	END
	ELSE
	BEGIN 
	SELECT ISNULL((SELECT Combin_Desc FROM  COMBIN_MAST  WHERE	 Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND	pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name", ISNULL(CONVERT(VARCHAR(10), date1, 103), '') AS "Date", EDITION_CODE,  IDNUM, Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 order by IDNUM,EDITION_NAME
	END

END

IF ( @dateformat = 'yyyy/mm/dd' ) 
BEGIN 
	IF @insertiondate = null OR @insertiondate = '' 
	BEGIN 
	SELECT ISNULL((SELECT Combin_Desc FROM  COMBIN_MAST WHERE	 Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND	pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name", ISNULL(CONVERT(VARCHAR(10), date1, 111), '') AS "Date",  EDITION_CODE, IDNUM, Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 order by IDNUM,EDITION_NAME
	END
	ELSE
	BEGIN 
	SELECT ISNULL((SELECT Combin_Desc FROM  COMBIN_MAST WHERE	 Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND	pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name", ISNULL(CONVERT(VARCHAR(10), date1, 111), '') AS "Date", EDITION_CODE, IDNUM, Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 order by IDNUM,EDITION_NAME
	END
END

IF ( @dateformat = null OR @dateformat='') 
BEGIN 
	IF @insertiondate = null OR @insertiondate=''
	BEGIN 
	SELECT
	ISNULL((SELECT Combin_Desc FROM  COMBIN_MAST  WHERE	 Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND	pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name", ISNULL(CONVERT(VARCHAR(10), date1, 101), '') AS "Date", EDITION_CODE, IDNUM, Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 order by IDNUM,EDITION_NAME
	END
	ELSE
	BEGIN 
	SELECT ISNULL((SELECT Combin_Desc FROM  COMBIN_MAST WHERE	 Comp_Code  = @compcode AND	Package_Name  = RTRIM(LTRIM(Edition_Name)) AND	Ad_Type_code  = @adtype AND	pub_center  = @center ), RTRIM(LTRIM(Edition_Name))) AS "Edition_Name", ISNULL(CONVERT(VARCHAR(10), date1, 101), '') AS "Date", EDITION_CODE, IDNUM, Edition_Name AS PKGNAME
,(select TOP 1 Pub_Code from edition_mast where Edition_Alias=RTRIM(LTRIM(#TMP2.Edition_Name))) as 'PUBCODE','' as 'PRIORITY','' as SPLIT
 FROM  #TMP2 order by IDNUM,EDITION_NAME
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



























