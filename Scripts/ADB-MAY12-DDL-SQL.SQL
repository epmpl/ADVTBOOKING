
//===========================PAtch for Adon in combin_mast (Kuldeep Bhati)==================//
CREATE TABLE [dbo].[COMBIN_ADONS_DETAILS](
	[COMBIN_CODE] [varchar](100) NOT NULL,
	[ADON_CODE] [int] IDENTITY(1,1) NOT NULL,
	[PACKAGE_CODE] [varchar](10) NOT NULL,
	[COMP_CODE] [varchar](8) NOT NULL,
	[USERID] [varchar](8) NOT NULL,
	[CRATEION_DATETIME] [datetime] NOT NULL,
	[PUBLICATION] [varchar](8) NOT NULL,
	[NO_OF_INSERT] [varchar](5) NULL,
	[PACKAGE_NAME] [varchar](100) NULL
) 
//===========================End PAtch for Adon in combin_mast (Kuldeep Bhati)==================//


//-------------------issue no 7423----------------------------

ALTER TABLE PREFERRENCES ADD @P_GEN_RCT_NO VARCHAR(5);

--------------end of issue no 7423------------------------
/**************************mimoh 7561 22 may 2012*********************************/
ALTER TABLE PREFERRENCES
 ADD PRODUCT_BRAND_REQ  VARCHAR(1 )           DEFAULT 'N'

/**************************mimoh 7561 22 may 2012*********************************/



////////////////////////start by shipra/////////////////////////////

 ALTER TABLE HT18JULY.PREFERRENCES
ADD ALLOWPREM_CARD_DISC_RATE  VARCHAR(1);


//////////////////////////shipra//////////////////////////////////////////

====start===============avinash==24-05-2012====================================
ALTER TABLE FINALRATE
ADD (PREM1 NUMBER);
========end===========avinash


//////////////////////////issue no 7583//////////////////


ALTER TABLE adv_exec_master
ADD ATTACHMENT  VARCHAR(50);

////////////////////////////////end of issue 7583///////////////////



/////////////////////////////////////issue no 7584////////////////////////////



ALTER TABLE RetainerMaster
ADD ATTACHMENT  VARCHAR(50);



////////////////////////////////////////end of issue no 7584//////////////////////




///////////shipra ////////5/25/2012///////////done by lata mam///////////////////



ALTER TABLE TBL_BOOKING_INSERT_G
ADD DISCOUNT FLOAT

ALTER TABLE TBL_BOOKING_INSERT
ADD DISCOUNT FLOAT


//////////shipra//////////5/25/2012////////////////done by lata mam