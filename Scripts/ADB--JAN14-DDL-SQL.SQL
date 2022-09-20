----14/01/2014===============================

CREATE TABLE [dbo].[tbl_combinPrintEdition](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[pack_name] [nvarchar](250) NULL,
	[flag] [nchar](10) NULL,
	[combin_code] [nvarchar](150) NULL,
	[package_name] [nchar](250) NULL,
	[creat_date] [datetime] NULL,
	[adtype] [varchar](30) NULL,
	[comp_code] [varchar](30) NULL,
 CONSTRAINT [PK_tbl_combinPrintEdition] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

===========start 18-01-2014===========

USE [erp]
GO

/****** Object:  Table [dbo].[tbl_combinPrintEdition]    Script Date: 01/18/2014 15:59:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_combinPrintEdition](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[pack_name] [nvarchar](250) NULL,
	[flag] [nchar](10) NULL,
	[combin_code] [nvarchar](150) NULL,
	[package_name] [nchar](250) NULL,
	[creat_date] [datetime] NULL,
	[adtype] [varchar](30) NULL,
	[comp_code] [varchar](30) NULL,
 CONSTRAINT [PK_tbl_combinPrintEdition] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO






======end 18-01-2014===============