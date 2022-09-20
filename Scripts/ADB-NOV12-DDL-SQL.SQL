alter table preferrences add ALLOW_RET_AFTER_BANK varchar(2)


/**********************update by dhananjay for edition master**********************************/
CREATE TABLE [dbo].[SELECT_EDITION_TXT](
	[comp_code] [varchar](8) NULL,
	[edition_code] [varchar](8) NULL,
	[txtsun] [varchar](100) NULL,
	[txtmon] [varchar](100) NULL,
	[txttue] [varchar](100) NULL,
	[txtwed] [varchar](100) NULL,
	[txtthu] [varchar](100) NULL,
	[txtfri] [varchar](100) NULL,
	[txtsat] [varchar](100) NULL,
	[userid] [varchar](8) NULL,
	[temp_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
/**********************end*****************************/



/**********************update by dhananjay for ad category master**********************************/
CREATE TABLE [dbo].[Select_AdvCat_txt](
	[comp_code] [varchar](8) NULL,
	[Adv_Cat_Code] [varchar](8) NULL,
	[txtsun] [varchar](100) NULL,
	[txtmon] [varchar](100) NULL,
	[txttue] [varchar](100) NULL,
	[txtwed] [varchar](100) NULL,
	[txtthu] [varchar](100) NULL,
	[txtfri] [varchar](100) NULL,
	[txtsat] [varchar](100) NULL,
	[userid] [varchar](8) NULL,
	[temp_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
/**********************end*****************************/







/////////update by shipra issue no 9143/////////////////////////


ALTER TABLE agency_mast ADD AGENCY_DESIGNATION VARCHAR(100);







///////////end by shipra//////////////////////////////////////////
