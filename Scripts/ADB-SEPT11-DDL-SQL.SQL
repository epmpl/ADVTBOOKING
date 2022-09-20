
/********************************************************************************/
/*     To add Column in Table Call exec add_col_in_table 'TABLE_NAME', 'COLUMN_NAME', 'TYPE', 'Default Value'    */
/*     To Create table add_table 'TABLE_NAME','SCRIPT'   */
/*     tO CREATE INDEX add_index(p_index_name in varchar2, p_script in varchar2) */
/*     TO ADD CONSTRAINTS ADD_CONSTRAINT (p_cons_name in varchar2, p_script in varchar2) */
/********************************************************************************/


/************************************ Prachi 4797 ***************************************/
exec add_table 'AD_STATUS',
'CREATE TABLE AD_STATUS
(
  SALES_OFFICE       varchar(15 ),
  SAPID              varchar(12 ),
  PAGE_NO            varchar(10 ),
  BILL_NO            varchar(20 ),
  QBC_NAME           varchar(100 ),
  CLIENT_NAME        varchar(100 ),
  KEYWORDS           varchar(25 ),
  EDITION            varchar(15 ),
  WIDTH              varchar(10 ),
  HEIGHT             varchar(10 ),
  AMOUNT             float(53),
  PUB_DATE           DATEtime,
  COMP_CODE          varchar(5 ),
  ITEM_NO            int,
  SUB_CATEGORY_CODE  varchar(10 ),
  CATEGORY_CODE      varchar(10 ),
  STATUS             varchar(4 ),
  QBC_CODE           varchar(20 )
)'


/************************************ Prachi 4797 ***************************************/
/************************************ Mimod 4912 ***************************************/
exec add_col_in_table 'AGENCY_MAST','VAT','VARCHAR(1)',null	 ;
/************************************ Mimod 4912 ***************************************/


/************************************ Mimod 0004914 ***************************************/
exec add_col_in_table 'PREFERRENCES','OUTSTANDING_AMT_CRITERIA','VARCHAR(5)',null	 ;
/************************************ Mimod 0004914 ***************************************/


/*********************************4-oct-2011********************/
exec add_table 'LOGININFO',
'CREATE TABLE [LOGININFO](
	[COMPCODE] [varchar](50) ,
	[USERID] [varchar](50) ,
	[STARTTIME] [datetime] NULL,
	[LASTUSED] [datetime] NULL,
	[IP] [varchar](50) ,
	[SESSIONID] [varchar](50) 
)';


exec add_table 'LOGININFO_LOG',
'CREATE TABLE [LOGININFO_LOG](
	[COMPCODE] [varchar](50) ,
	[USERID] [varchar](50) ,
	[STARTTIME] [datetime] NULL,
	[ENDTIME] [datetime] NULL,
	[IP] [varchar](50) ,
	[SESSIONID] [varchar](50) 
) ';

exec add_col_in_table 'COMP_MST','LICENSE_INFO','varchar(100)',null	 ;

exec add_col_in_table 'COMP_MST','LAST_KEY_UPDATE ','Date',null	 ;

exec add_col_in_table 'COMP_MST','LAST_KEY_UPDATED_BY','varchar(50)',null	 ;

/***************************mimoh 10/10/2011***0005269****************************/

exec add_col_in_table 'PREFERRENCES','GENRATE_CIR_AGCD','numeric(2, 0)',null ;
/***************************mimoh 10/10/2011******0005269************************/


/***************************Kuldeep Bhati 12/10/2011***0005318 ****************************/

exec add_col_in_table 'PREFERRENCES','DISP_AUDITBKG','varchar(5)',null	 ;
/***************************Kuldeep Bhati 12/10/2011******0005318 ************************/

/***************************Kuldeep Bhati 12/10/2011***0005330 ****************************/

exec add_col_in_table 'uom_mast','FLAG','varchar(5)',null	 ;
/***************************Kuldeep Bhati 12/10/2011******0005330 ************************/

/***************************Kuldeep Bhati 13/10/2011***0004884   ****************************/

exec add_col_in_table ('LOGIN','STATUS','varchar(20)',null	 ;
/***************************Kuldeep Bhati 13/10/2011******0004884  ************************/



/***************************mimoh 10/10/2011***0005373****************************/

exec add_col_in_table 'PREFERRENCES','CIR_DIS_AUTO_POSTING ','VARCHAR(1)',null ;
/***************************mimoh 10/10/2011******0005373************************/


/********************* Lata 24oct11 ****************/
exec add_table 'TBL_EXT_BOOKING_RPT_DET',
'create table TBL_EXT_BOOKING_RPT_DET
(BOOKINGID VARCHAR(50),
RECEIPTNO VARCHAR(50),
COMPCODE VARCHAR(20),
USERID VARCHAR(20),
IP_USER VARCHAR(20),
DATE_TIME DATETIME)';


/*********************** LATA  31/10/2011  *******************/
exec add_col_in_table  'PREFERRENCES','RELAUTHREQON','VARCHAR(1)',null;
exec add_col_in_table 'colcm','AD_TYPE','VARCHAR(10)',null;
***************************************************************************
/*********************mimoh 31oct 2011********************0005464*****/
exec add_col_in_table  'Adv_Exec_Master','SIGN','VARCHAR(50)',null;

exec add_col_in_table  'RetainerMaster','SIGN','VARCHAR(50)',null;
/*********************mimoh 31oct 2011********************0005464*****/








//////////////issue no 8461//////////////

alter table preferrences add EXECUTIVECREDITLIMIT varchar(1) 


//////////end of issue no 8461////////////