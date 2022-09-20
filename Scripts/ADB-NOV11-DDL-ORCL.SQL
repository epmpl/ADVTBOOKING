
/*********************** Kuldeep  09/11/2011  *******************/
exec add_col_in_table ('rate_mast','ADON','VARCHAR2(5)',null) ;
exec add_col_in_table ('rate_mast','REF_ID','VARCHAR2(200)',null) ;
exec add_col_in_table ('tv_rate_mast','ADON','VARCHAR2(5)',null) ;
exec add_col_in_table ('tv_rate_mast','REF_ID','VARCHAR2(200)',null) ;
/*********************** Kuldeep  09/11/2011  *******************/

/*********************** LATA  09/11/2011  *******************/
exec add_col_in_table ('TBL_BOOKING_MAST_g','PACKAGE_TYPE','VARCHAR2(5)',null) ;

exec add_col_in_table ('TBL_BOOKING_MAST_g','AD_REFID','VARCHAR2(50)',null) ;

exec add_col_in_table ('TBL_BOOKING_MAST','PACKAGE_TYPE','VARCHAR2(5)',null) ;

exec add_col_in_table ('TBL_BOOKING_MAST','AD_REFID','VARCHAR2(50)',null) ;
***************************************************************************


/********************* LATA 10 nov 2011*******************/

exec add_col_in_table ('TBL_BOOKING_INSERT_g','SECTIONCODE','VARCHAR(50)',null);

exec add_col_in_table ('TBL_BOOKING_INSERT','SECTIONCODE','VARCHAR(50)',null);


exec add_table('TBL_SECTIONCODE',
'CREATE TABLE TBL_SECTIONCODE
(
 CODE VARCHAR2(50),
 NAME VARCHAR2(100)
)');

/*******************************************************/
/********************* amit 15 nov 2011*******************/

exec add_col_in_table ('login','DOMAIN_USER','VARCHAR2(50)',null);

/*******************************************************/


/********************* LATA 15 nov 2011*******************/

exec add_col_in_table ('TBL_BOOKING_INSERT_g','RESOURCE_NO','VARCHAR2(50)',null);

exec add_col_in_table ('TBL_BOOKING_INSERT','RESOURCE_NO','VARCHAR2(50)',null);


exec add_table('TBL_RESOURCE',
'CREATE TABLE TBL_RESOURCE
(RESOURCE_NO VARCHAR(50),
NAME VARCHAR(100),
COST_CENTER_CODE VARCHAR(20),
REVENUE_STREAMS_CODE VARCHAR(10),
TYPE VARCHAR(10),
UNIT_MEASURE VARCHAR(20)
)');

/*******************************************************/

/*********************** Kuldeep  22/11/2011  *******************/
exec add_col_in_table (' CURR_CONV_DET','CONV_CURRENCY','VARCHAR2(50)',null) ;
/*********************** Kuldeep  22/11/2011  *******************/

/*********************** Lata  22/11/2011  *******************/
exec add_col_in_table('TBL_BOOKING_MAST_G','RECEIPT_CURRENCY','VARCHAR2(8)',null);

exec add_col_in_table('TBL_BOOKING_MAST_G','CONV_CURR_RATE','VARCHAR2(8)',null);

exec add_col_in_table ('TBL_BOOKING_MAST','RECEIPT_CURRENCY','VARCHAR2(8)',null);

exec add_col_in_table ('TBL_BOOKING_MAST','CONV_CURR_RATE','VARCHAR2(8)',null);

exec add_col_in_table ('tempbooking_mast','PACKAGE_TYPE','VARCHAR2(5)',null);

exec add_col_in_table ('tempbooking_mast','AD_REFID','VARCHAR2(50)',null);

exec add_col_in_table ('tempbooking_mast','RECEIPT_CURRENCY','VARCHAR2(8)',null);

exec add_col_in_table ('tempbooking_mast','CONV_CURR_RATE','VARCHAR2(8)',null);

/*********************** Lata  22/11/2011  *******************/

/*********************** Kuldeep  25/11/2011  *******************/
exec add_col_in_table (' CURR_CONV_DET','UNIT','INTEGER',null) ;
/*********************** Kuldeep  25/11/2011  *******************/

/*********************** Kuldeep  29/11/2011  *******************/
exec add_col_in_table (' retain_comm_slab','COMM_TARGET_ID','INTEGER',null) ;
/*********************** Kuldeep  29/11/2011  *******************/

/*======================================= 5-12-11 mimoh mahajan client MAster ===============5747===============*/

ALTER TABLE CUST_MAST
 ADD (CLIENT_TYPE  VARCHAR2(5));

ALTER TABLE CUST_MAST
 ADD (QBC_AGENCY  VARCHAR2(20));
 

 
ALTER TABLE CUST_MAST_TEMP
 ADD (AGENCY_CODE VARCHAR2(20)),
 
 ALTER TABLE CUST_MAST_TEMP
 ADD (DIVISION VARCHAR2(50)),
 
 ALTER TABLE CUST_MAST_TEMP
 ADD (CLIENT_TYPE  VARCHAR2(5));

ALTER TABLE CUST_MAST_TEMP
 ADD (QBC_AGENCY  VARCHAR2(20));
////////////////////////////////////

/*======================================= 5-12-11 mimoh mahajan client MAster ===============5747===============*/

/*********************** Issue 5846  29/11/2011  *******************/
ALTER TABLE ADV_SUBCAT_MAST
 ADD STATUS  VARCHAR(5)
 
 ALTER TABLE Adv_Cat_Mast
 ADD STATUS  VARCHAR(5)
/*********************** End of Issue 5846 29/11/2011  *******************/