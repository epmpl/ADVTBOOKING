----------------start--issue--6918------06-03-2012-----------


New form for agency wise RO number allotment entry(Used for QBC)


For SQL
CREATE TABLE RO_BOOK_ALLOTMENT
(COMP_CODE VARCHAR(8) NOT NULL,
 TYP VARCHAR(1) NOT NULL,
 CODE_SUBCODE VARCHAR(20) NOT NULL,
 ISSUE_DT DATETIME NOT NULL,
 ISSUE_NO NUMERIC(8) NOT NULL,
 RONO_FROM NUMERIC(8) NOT NULL,
 RONO_TILL NUMERIC(8) NOT NULL,
 STATUS VARCHAR(1) DEFAULT 'A',
 CREATED_BY VARCHAR(30),
 CREATED_DT DATETIME DEFAULT GETDATE(),
 UPDATED_BY VARCHAR(30),
 UPDATED_DT DATETIME,
 CONSTRAINT RO_BOOK_ALLOTMENT_PK PRIMARY KEY (COMP_CODE, CODE_SUBCODE,RONO_FROM,RONO_TILL),
 CONSTRAINT RO_BOOK_ALLOTMENT_UK UNIQUE (ISSUE_NO))
 
----------------End--issue--6918------06-03-2012-----------
/***********************6932*********************************************************/

ALTER TABLE PREFERRENCES
 ADD BILL_DETAIL_ON_VOUCHER  VARCHAR (1)       DEFAULT 'N'

ALTER TABLE PREFERRENCES
 ADD CANCEL_VOUCHER_IN_LEDGER  VARCHAR(1)   DEFAULT 'N'

ALTER TABLE PREFERRENCES ADD BOOK_AUDIT_REQ_AFTER_MOD VARCHAR(5)
/***********************6932*********************************************************/


/************6940*********** ankit  13/11/2012  *******************/


ALTER TABLE PREFERRENCES ADD EDITABLE_AGENCY_COMM VARCHAR(1) DEFAULT 'N'

/************6940*********** ankit  13/11/2012  *******************/



/************************************6963***********RATE MASTER UPDATE************************MIMOH *******************************/

ALTER TABLE RATE_MAST
 ADD CANCELLATION_CHARGES  FLOAT



/************************************6963***********RATE MASTER UPDATE************************MIMOH *******************************/



/-----start-------------------6719-------20march2012----------------------------/

                                            
CREATE TABLE EDITIONWISERATIO_MAST
(
  COMP_CODE          VARCHAR(8),
  USERID             VARCHAR(8),
  PUB_CODE           VARCHAR(8),
  MAIN_EDITION_CODE  VARCHAR(20),
  SUB_EDITION_CODE   VARCHAR(20),
  EDITION_NAME       VARCHAR(50),
  CREATION_DATETIME  DATEtime,
  EFFECTIVE_DATE     DATEtime,
  PERCENTAGE         NUMeric
)


/-----End-------------------6719-------20march2012----------------------------/

//-------------------------------------start--------------------------------//
ALTER TABLE  PREFERRENCES add TAXI_ENTRY_TYPE VARCHAR(1)

ALTER TABLE CIR_TAXI_ROUTE add STATUS VARCHAR(1)

//-----------------------------------------end----------------------------------//


/******************************mimoh mahajan 22 march 2012****************************************6982*************************/
ALTER TABLE PREFERRENCES ADD APPROVAL_WITH VARCHAR(1) DEFAULT 'D'



/******************************mimoh mahajan 22 march 2012****************************************6982*************************/



/************************issue3691***********************/
ALTER TABLE PREFERRENCES ADD
TDS_AUTO_CN VARCHAR(1) DEFAULT 'N',TDS_AUTO_REASON VARCHAR(10),TDS_DB_CDP VARCHAR(10),TDS_CR_CDP VARCHAR(10),
SER_TAX_AUTO_CN VARCHAR(1) DEFAULT 'N',SER_TAX_AUTO_REASON VARCHAR(10),SER_TAX_DB_CDP VARCHAR(10),SER_TAX_CR_CDP VARCHAR(10),
PKK_AUTO_CN VARCHAR(1) DEFAULT 'N',PKK_AUTO_REASON VARCHAR(10),PKK_DB_CDP VARCHAR(10),PKK_CR_CDP VARCHAR(10),
BANK_CHG_AUTO_CN VARCHAR(1) DEFAULT 'N',BANK_CHG_AUTO_REASON VARCHAR(10),BANK_CHG_DB_CDP VARCHAR(10) ,BANK_CHG_CR_CDP VARCHAR(10)
/************************end 3691***********************/

////////////////////////uppdate By Ghanshyam sir
ALTER

TABLE EDITION_MAST ADD SEGMENT_CODE VARCHAR2(10)
//////////////////////////////////////
/*****mimoh 28 march 2012*********7061*************************************************/
ALTER TABLE PREFERRENCES ADD
TDS_AUTO_CN VARCHAR(1) DEFAULT 'N',TDS_AUTO_REASON VARCHAR(10),TDS_DB_CDP VARCHAR(10),TDS_CR_CDP VARCHAR(10),
SER_TAX_AUTO_CN VARCHAR(1) DEFAULT 'N',SER_TAX_AUTO_REASON VARCHAR(10),SER_TAX_DB_CDP VARCHAR(10),SER_TAX_CR_CDP VARCHAR(10),
PKK_AUTO_CN VARCHAR(1) DEFAULT 'N',PKK_AUTO_REASON VARCHAR(10),PKK_DB_CDP VARCHAR(10),PKK_CR_CDP VARCHAR(10),
BANK_CHG_AUTO_CN VARCHAR(1) DEFAULT 'N',BANK_CHG_AUTO_REASON VARCHAR(10),BANK_CHG_DB_CDP VARCHAR(10) ,BANK_CHG_CR_CDP VARCHAR(10)

/*****mimoh 28 march 2012*********7061*************************************************/

/**************************************************mimoh ***************/
CREATE TABLE AD_DIRECT_CLIENT_AGENCY
(COMP_CODE      VARCHAR(20),
 AG_MAIN_CODE   VARCHAR(8),
 AG_SUB_CODE    VARCHAR(8),
 CREATED_BY     VARCHAR(20),
 CREATED_DT     DATETIME    DEFAULT GETDATE(),
 UPDATED_BY     VARCHAR(20),
 UPDATED_DT     DATETIME,
 CONSTRAINT AD_DIRECT_CLIENT_PK PRIMARY KEY (AG_MAIN_CODE, AG_SUB_CODE))
/**************************************************mimoh ***************/

==============start===09april2012===avinash==7031=======================
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


============end========7031===========avinash======================




/*********************mimoh/*************************************7162********************/

ALTER TABLE CUST_MAST ADD OLD_CLIENT_CODE VARCHAR(50)

/*********************mimoh/*************************************7162********************/


/*********************mimoh*************************************7180**10 04 2012******************/

    alter table  retainermaster add  cdp varchar(8)
        alter table  retainermaster add  cds varchar(8)
/*********************mimoh/*************************************7180**10 04 2012******************/




/********************* issue 7141 (complete report)*************************

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


                                                                     
                                                                     
                                                                     
                                             
ALTER  function [dbo].[FUN_BILL_INSERT] ( @comp_cod varchar(20), @cio_id varchar(100),@bil_no varchar(100),@prefer varchar(10),@dateformate varchar(20),@f_agmain varchar(100),@f_agsub varchar(100),@f_agcode varchar(100),@f_agname varchar(200),@f_execcode varchar(100),@f_execname varchar(200),@f_retcode varchar(100),@f_retname varchar(200),@base varchar(10)) --RETURNs float(6) as

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
  PAGE_NO			int,
BILL_REMARK         varchar(500)

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
declare @f_billremark  varchar(500)


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
@ffPRIPROCTG=max(PRIPROCTG),@f_page_no=max(PAGENUM),@f_billremark =max(BILL_RMRK)
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
  CITY_CODE,ZONE_CODE,DIST_CODE,STATE_CODE,PTALUKA,CITY_NAME,ZONE_NAME,STATE_NAME,PAGE_NO,BILL_REMARK
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
,@f_billremark
)


return 


end

************************ end of issue 7141***********************************************




