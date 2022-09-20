/*********************** Kuldeep  09/11/2011  *******************/
exec add_col_in_table 'rate_mast','ADON','VARCHAR(5)',null ;
exec add_col_in_table 'rate_mast','REF_ID','VARCHAR(200)',null ;
exec add_col_in_table 'tv_rate_mast','ADON','VARCHAR(5)',null) ;
exec add_col_in_table 'tv_rate_mast','REF_ID','VARCHAR(200)',null ;
/*********************** Kuldeep  09/11/2011  *******************/

/*********************LATA 9 nov 2011********************0005464*****/
exec add_col_in_table  'TBL_BOOKING_MAST_g','PACKAGE_TYPE','VARCHAR(5)',null;

exec add_col_in_table  'TBL_BOOKING_MAST_g','AD_REFID','VARCHAR(50)',null;

exec add_col_in_table  'TBL_BOOKING_MAST','PACKAGE_TYPE','VARCHAR(5)',null;

exec add_col_in_table  'TBL_BOOKING_MAST','AD_REFID','VARCHAR(50)',null;
/*********************Lata 9 nov 2011********************0005464*****/

/*********************LATA 10 nov 2011********************0005464*****/
exec add_col_in_table  'TBL_BOOKING_INSERT_g','SECTIONCODE','VARCHAR(50)',null;

exec add_col_in_table  'TBL_BOOKING_INSERT','SECTIONCODE','VARCHAR(50)',null;


exec add_table 'TBL_SECTIONCODE',
'CREATE TABLE TBL_SECTIONCODE
(
 CODE VARCHAR(50),
 NAME VARCHAR(100)
)'

/*********************Lata 10 nov 2011********************0005464*****/


/*********************amit dhama 15 nov 2011*************************/
exec add_col_in_table  'login','DOMAIN_USER','VARCHAR(50)',null;

/*********************amit dhama 15 nov 2011*************************/

/********************* LATA 15 nov 2011*******************/

exec add_col_in_table  'TBL_BOOKING_INSERT_g','RESOURCE_NO','VARCHAR(50)',null;

exec add_col_in_table 'TBL_BOOKING_INSERT','RESOURCE_NO','VARCHAR2(50)',null;


exec add_table 'TBL_RESOURCE',
'CREATE TABLE TBL_RESOURCE
(RESOURCE_NO VARCHAR(50),
NAME VARCHAR(100),
COST_CENTER_CODE VARCHAR(20),
REVENUE_STREAMS_CODE VARCHAR(10),
TYPE VARCHAR(10),
UNIT_MEASURE VARCHAR(20)
)';

/*******************************************************/

/*********************** Kuldeep  22/11/2011  *******************/
exec add_col_in_table ' CURR_CONV_DET','CONV_CURRENCY','VARCHAR(50)',null;
/*********************** Kuldeep  22/11/2011  *******************/

/*********************** Lata  22/11/2011  *******************/
exec add_col_in_table 'TBL_BOOKING_MAST_G','RECEIPT_CURRENCY','VARCHAR(8)',null;

exec add_col_in_table 'TBL_BOOKING_MAST_G','CONV_CURR_RATE','VARCHAR(8)',null;

exec add_col_in_table 'TBL_BOOKING_MAST','RECEIPT_CURRENCY','VARCHAR(8)',null;

exec add_col_in_table 'TBL_BOOKING_MAST','CONV_CURR_RATE','VARCHAR(8)',null;
/*********************** Lata  22/11/2011  *******************/

/*********************** Kuldeep  25/11/2011  *******************/
exec add_col_in_table ' CURR_CONV_DET','UNIT','VARCHAR(20)',null;
/*********************** Kuldeep  25/11/2011  *******************/
/*********************** Kuldeep  30/11/2011  *******************/
CREATE TABLE [dbo].[RETAIN_COMM_TARGET](
	[COMP_CODE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RETAIN_CODE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TEAM_CODE] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ADCTG_CODE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FROM_TGT] [numeric](5, 2) NULL,
	[TO_TGT] [numeric](5, 2) NULL,
	[CUST_TYPE] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AD_TYPE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PUB_TYPE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PUBL_CODE] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CREATED_BY] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CREATED_DT] [datetime] NULL CONSTRAINT [DF__RETAIN_CO__CREAT__7D31B980]  DEFAULT (getdate()),
	[UPDATED_BY] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UPDATED_DT] [datetime] NULL,
	[COMM_TARGET_ID] [int] NOT NULL,
 CONSTRAINT [RETAIN_COMM_TARGET_PK] PRIMARY KEY CLUSTERED 
(
	[COMP_CODE] ASC,
	[RETAIN_CODE] ASC,
	[COMM_TARGET_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE TABLE [dbo].[RETAIN_ADCOMM_TARGET](
	[COMP_CODE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RETAIN_CODE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[COMM_TARGET_ID] [int] NOT NULL,
	[PUBL_CODE] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NO_OF_PUBL] [numeric](3, 0) NULL,
	[ADCOMM_PER] [numeric](12, 2) NULL,
	[COMM_TYPE] [varchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__RETAIN_AD__COMM___000E262B]  DEFAULT ('P'),
	[CREATED_BY] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CREATED_DT] [datetime] NULL CONSTRAINT [DF__RETAIN_AD__CREAT__01024A64]  DEFAULT (getdate()),
	[UPDATED_BY] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UPDATED_DT] [datetime] NULL,
	[ADD_COMM_ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_RETAIN_ADCOMM_TARGET] PRIMARY KEY CLUSTERED 
(
	[COMP_CODE] ASC,
	[RETAIN_CODE] ASC,
	[COMM_TARGET_ID] ASC,
	[ADD_COMM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
/*********************** Kuldeep  30/11/2011  *******************/

/*********************** Kuldeep  02/12/2011  *******************/
exec add_col_in_table ' retain_comm_slab','COMM_TARGET_ID','int',null;
/*********************** Kuldeep  02/12/2011  *******************/


/*======================================= 5-12-11 mimoh mahajan client MAster ===============5747===============*/

ALTER TABLE CUST_MAST
 ADD CLIENT_TYPE  VARCHAR(5)

ALTER TABLE CUST_MAST
 ADD QBC_AGENCY  VARCHAR(20)

/*======================================= 5-12-11 mimoh mahajan client MAster ===============5747===============*/

/*********************** Issue 5846  29/11/2011  *******************/
ALTER TABLE ADV_SUBCAT_MAST
 ADD (STATUS  VARCHAR2(5));
 
 ALTER TABLE Adv_Cat_Mast
 ADD (STATUS  VARCHAR2(5));
/*********************** End of Issue 5846 29/11/2011  *******************/


/*******************************************mimoh 6/12/2011*******************0005879********************************/
alter retain_comm_slab add COMM_TARGET_ID int

/*******************************************************/
CREATE TABLE [dbo].[RETAIN_ADCOMM_TARGET](
	[COMP_CODE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RETAIN_CODE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[COMM_TARGET_ID] [int] NOT NULL,
	[PUBL_CODE] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NO_OF_PUBL] [numeric](3, 0) NULL,
	[ADCOMM_PER] [numeric](12, 2) NULL,
	[COMM_TYPE] [varchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__RETAIN_AD__COMM___000E262B]  DEFAULT ('P'),
	[CREATED_BY] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CREATED_DT] [datetime] NULL CONSTRAINT [DF__RETAIN_AD__CREAT__01024A64]  DEFAULT (getdate()),
	[UPDATED_BY] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UPDATED_DT] [datetime] NULL,
	[ADD_COMM_ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_RETAIN_ADCOMM_TARGET] PRIMARY KEY CLUSTERED 
(
	[COMP_CODE] ASC,
	[RETAIN_CODE] ASC,
	[COMM_TARGET_ID] ASC,
	[ADD_COMM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/********************************************************************************************/



CREATE TABLE [dbo].[RETAIN_COMM_TARGET](
	[COMP_CODE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RETAIN_CODE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TEAM_CODE] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ADCTG_CODE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FROM_TGT] [numeric](5, 2) NULL,
	[TO_TGT] [numeric](5, 2) NULL,
	[CUST_TYPE] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AD_TYPE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PUB_TYPE] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PUBL_CODE] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CREATED_BY] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CREATED_DT] [datetime] NULL CONSTRAINT [DF__RETAIN_CO__CREAT__7D31B980]  DEFAULT (getdate()),
	[UPDATED_BY] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UPDATED_DT] [datetime] NULL,
	[COMM_TARGET_ID] [int] NOT NULL,
 CONSTRAINT [RETAIN_COMM_TARGET_PK] PRIMARY KEY CLUSTERED 
(
	[COMP_CODE] ASC,
	[RETAIN_CODE] ASC,
	[COMM_TARGET_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
/*******************************************mimoh 6/12/2011*******************0005879********************************/




