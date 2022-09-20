//////////////////////done by shipra////////////issue no 8096//////////////

CREATE TABLE AD_FMG_REASON_MAST
 (COMP_CODE VARCHAR(8),
  REASON_CODE NUMERIC(5),
  REASON_DESC VARCHAR(30),
  CREATED_BY VARCHAR(30),
  CREATED_DT DATETIME DEFAULT GETDATE(),
  UPDATED_BY VARCHAR(30),
  UPDATED_DT DATETIME,
  CONSTRAINT AD_FMG_REASON_MAST_PK
  PRIMARY KEY (REASON_CODE))
 
////////////////end by shipra///////////////////issue no 8096/////////////////




?//////////////////////////////////////**************************Sumit Roy(Rate Code Master)***********************///////////////////

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RATE_CODE_MAST](
	[RATE_CODE] [varchar](50) NULL,
	[RATE_DESC] [varchar](100) NULL,
	[STATUS] [varchar](100) NOT NULL,
	[REMARKS] [varchar](500) NOT NULL,
	[COMP_CODE] [varchar](12) NOT NULL,
	[USERID] [varchar](50) NULL,
	[CREATE_DATE] [datetime] NULL,
	[MODIFY_USER] [varchar](50) NULL,
	[MODIFY_DATE] [datetime] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO







///////////////////////////////////////////*******************END**************************///////////////////////