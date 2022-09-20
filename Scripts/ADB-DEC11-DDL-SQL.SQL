/*======================================= ISSUE 0005968 (Kuldeep Bhati) ==============================*/
ALTER TABLE AGENCY_MAST
 ADD RATE_REVISE  VARCHAR(5)
/*======================================= End of ISSUE 0005968 (Kuldeep Bhati) ==============================*/

/*======================================= ISSUE 0005972 ==============================*/
ALTER TABLE CUST_MAST
 ADD TYPE  VARCHAR(5)

ALTER TABLE CUST_MAST
 ADD PARENT_CLIENT  VARCHAR(8)
/*======================================= End of ISSUE 0005972 ==============================*/

/*======================================= ISSUE 0005970 (Kuldeep Bhati) ==============================*/
exec add_col_in_table 'TBL_BOOKING_MAST','REVISE_DATE','DATE',null ;
exec add_col_in_table 'TBL_BOOKING_MAST_G','REVISE_DATE','DATE',null ;
/*======================================= End of ISSUE 0005970 (Kuldeep Bhati) ==============================*/


exec add_col_in_table 'preferrences','ALLOW_FOLLOW_DT_BOOOK','VARCHAR2(1)',null ;

/*******************************Laxman 26-dec-2011 issue no. 6137*************/
ALTER TABLE CRM_SCH_PUBL_EXPIRY ADD (EDITION_CODE VARCHAR(3),AGCD VARCHAR(8),DPCD VARCHAR(8),SUP_TY_CODE VARCHAR(5))

ALTER TABLE PREFERRENCES ADD (CRM_SUPPLY_TYPE_PAID VARCHAR(5),CRM_SUPPLY_TYPE_FREE VARCHAR(5))
/*******************************Laxman 26-dec-2011 issue no. 6137*************/

/***********************mimoh 28dec 2011*********6162****************************************/
alter table PREFERRENCES add CURRENCY_MEASUREMENT varchar(5)
/***********************mimoh 28dec 2011*********6162****************************************/

/*======================================= ISSUE 0005976 (Kuldeep Bhati) ==============================*/
CREATE TABLE ad_tableid_pre_save(
	[Booking_id] [varchar](50) NULL,
	[Receipt_no] [int] NULL,
	[Box_no] [varchar](50) NULL,
	[Dockit_no] [varchar](50) NULL,
	[Contract_code] [int] NULL,
	[temp_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

/*======================================= End of ISSUE 0005976 (Kuldeep Bhati) ==============================*/
/**************************************************deal 6036****************************/



exec add_col_in_table 'tv_booking_det','DEAL_NO','varchar(5)',null ;

exec add_col_in_table 'tv_ad_channel','MODE_TYPE','varchar(20)',null ;


exec add_col_in_table 'tv_ad_channel','LOCID','varchar(20)',null ;


add_col_in_table 'tv_ad_channel','MAX_BREAK_TIME','NUMeric',null ;

exec add_col_in_table 'contract_mast','DEALON','varchar(20)',null ;



exec add_col_in_table 'contract_mast','INDUSTRY_PRODUCT','varchar(100)',null ;


exec add_col_in_table 'contract_mast','INDUSTRY','varchar(10)',null ;


exec add_col_in_table 'contract_mast','AFT_PRTCLR_AD','varchar(10)',null ;



exec add_col_in_table 'contract_mast','SEQNO','varchar(10)',null ;


exec add_col_in_table 'contract_mast','SEQNO_ALLOW','varchar(10)',null ;




exec add_col_in_table 'contract_mast','B2B','varchar(10)',null ;



exec add_col_in_table 'contract_mast','CHKMULTIAD','varchar(10)',null ;



exec add_col_in_table 'CONTRACT_MAST','AUDITBY','varchar(20)',null ;


exec add_col_in_table 'CONTRACT_MAST','AUDIT_COMMENT','varchar(500)',null ;

exec add_col_in_table 'CONTRACT_MAST','AUDIT_DATE','DATE',null ;





/********************************/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TV_BOOKING_DET](
	[COMP_CODE] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UNIT_CODE] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BKKNO] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BKDATE] [datetime] NULL,
	[AD_TYPE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SECTOR_CODE] [varchar](3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CLIENTCD] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CATEGORY_CODE] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PRIPROCTG] [varchar](3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SECPROCTG] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SEQ_NO] [numeric](18, 0) NULL,
	[BTB_CODE] [varchar](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FR_BND_CODE] [varchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TO_BND_CODE] [varchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BRK_CODE] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[POS] [numeric](18, 0) NULL,
	[CLIP_ID] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DUR] [numeric](10, 0) NULL,
	[PAID_BONUS] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AIR_DATE] [datetime] NOT NULL,
	[NO_OF_SPOT] [numeric](18, 0) NOT NULL,
	[BRD_DATE] [datetime] NULL,
	[BRD_FLAG] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RATE] [numeric](10, 4) NULL CONSTRAINT [DF__TV_BOOKING__RATE__6EA3A307]  DEFAULT ((0)),
	[GRS_AMT] [numeric](18, 4) NULL,
	[EFF_RATE] [numeric](18, 4) NULL,
	[EFF_AMT] [numeric](18, 4) NULL,
	[PITRT_VAL] [numeric](18, 4) NULL,
	[PITRT_AMT] [numeric](18, 4) NULL,
	[CARDRT_VAL] [numeric](18, 4) NULL,
	[CARDRT_AMT] [numeric](18, 4) NULL,
	[AG_COMM] [numeric](18, 4) NULL,
	[BILLNO] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BILL_DATE] [datetime] NULL,
	[BILL_SCHD_DATE] [datetime] NULL,
	[SER_TAX_PER] [numeric](18, 4) NULL,
	[SER_TAX_AMT] [numeric](18, 4) NULL,
	[NET_AMT] [numeric](18, 4) NULL,
	[BILLED_AMT] [numeric](18, 4) NULL,
	[BKUP_SNO] [int] IDENTITY(1,1) NOT NULL,
	[USERDATE] [datetime] NULL CONSTRAINT [DF__TV_BOOKIN__USERD__6F97C740]  DEFAULT (getdate()),
	[REMARK] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FLG] [varchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PRG_ID] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LOCCD] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CHANNEL] [varchar](40) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ROS] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[INSERT_ID] [numeric](18, 0) NOT NULL,
	[USERID] [varchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BOOK_STATUS] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PREM_PER] [numeric](18, 0) NULL,
	[PREM_AMT] [numeric](18, 0) NULL,
	[DISC_PER] [numeric](18, 0) NULL,
	[DISC_AMT] [numeric](18, 0) NULL,
	[RESOURCE_NO] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SECTIONCODE] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
/***************************************/


/**************************************************deal 6036****************************/

/**************************************************ankit  deal 6181****************************/
ALTER TABLE ad_cat3 ADD STATUS VARCHAR(5)
/**************************************************ankit  deal 6181****************************/

/*******19 jan*************end*************** issue 6211*************************************mimoh**********/

alter table contract_mast add ATTACHMENT varchar(200)



/*******19 jan*************end*************** issue 6211*************************************mimoh**********/
.

=================7343=====avinash=====start====================================================
ALTER TABLE Exec_mast
ADD EMAIL_ID varchar(200)

=================7343=====avinash=====END====================================================