///////////////issue no 7423////////////////////

ALTER TABLE PREFERRENCES ADD P_GEN_RCT_TYP VARCHAR2(5);

///////////////////end of issue 7423///////////////

/**************************mimoh 7561 22 may 2012*********************************/

ALTER TABLE PREFERRENCES
 ADD (PRODUCT_BRAND_REQ  VARCHAR2(1 BYTE)           DEFAULT 'N');
/**************************mimoh 7561 22 may 2012*********************************/



////////////////////start by shipra////////////////


ALTER TABLE HT18JULY.PREFERRENCES
ADD (ALLOWPREM_CARD_DISC_RATE  VARCHAR2(1 BYTE));


///////////////////////shipra////////////////////////////

===============start===avinash=====24-05-2012===============
ALTER TABLE FINALRATE
ADD (PREM2 NUMBER);
=================end=====avinash====================================




//////////////////////////////issue no 7583/////////////////////


ALTER TABLE adv_exec_master
ADD (ATTACHMENT  VARCHAR2(70 BYTE));

////////////////////////////////end of issue no 7583


///////////////////////////////////////issue no 7584///////////////////////



ALTER TABLE RetainerMaster
ADD (ATTACHMENT  VARCHAR2(10 BYTE));



/////////////////////////////////////end of issue 7584///////////////////////



//////////shipra--------5/25/2012----------------done by lata mam///////////

ALTER TABLE HT18JULY.TBL_BOOKING_INSERT_G
ADD (DISCOUNT FLOAT);


ALTER TABLE HT18JULY.TBL_BOOKING_INSERT
ADD (DISCOUNT FLOAT);




/////////////shipra-------5/25/2012-------------done by lata mam///////////////


====start======avinash============by mimoh========31-05-2012==================================
CREATE TABLE EXECUTIVE_ADCOMM_TARGET
(
  COMP_CODE       VARCHAR2(8 BYTE)              NOT NULL,
  EXECUTIVE_CODE     VARCHAR2(8 BYTE)              NOT NULL,
  COMM_TARGET_ID  NUMBER(10)                    NOT NULL,
  PUBL_CODE       VARCHAR2(200 BYTE),
  NO_OF_PUBL      NUMBER(3),
  ADCOMM_PER      NUMBER(12,2),
  COMM_TYPE       VARCHAR2(1 BYTE)              DEFAULT 'P',
  CREATED_BY      VARCHAR2(30 BYTE),
  CREATED_DT      DATE                          DEFAULT SYSDATE,
  UPDATED_BY      VARCHAR2(30 BYTE),
  UPDATED_DT      DATE,
  ADD_COMM_ID     NUMBER                        NOT NULL
)


/********************************************************************************************************************************************************************/

CREATE TABLE EXECUTIVE_COMM_TARGET
(
  COMP_CODE       VARCHAR2(8 BYTE)              NOT NULL,
  EXECU_CODE     VARCHAR2(8 BYTE)              NOT NULL,
  TEAM_CODE       VARCHAR2(8 BYTE),
  ADCTG_CODE      VARCHAR2(8 BYTE),
  FROM_TGT        NUMBER(5,2),
  TO_TGT          NUMBER(5,2),
  CUST_TYPE       VARCHAR2(10 BYTE),
  AD_TYPE         VARCHAR2(8 BYTE),
  PUB_TYPE        VARCHAR2(8 BYTE),
  PUBL_CODE       VARCHAR2(200 BYTE),
  CREATED_BY      VARCHAR2(30 BYTE),
  CREATED_DT      DATE                          DEFAULT SYSDATE,
  UPDATED_BY      VARCHAR2(30 BYTE),
  UPDATED_DT      DATE,
  COMM_TARGET_ID  NUMBER(10)                    NOT NULL
)


/*****************************************************************************************************************************/


CREATE TABLE EXECUTIVE_COMM_SLAB
(
  COMP_CODE       VARCHAR2(8 BYTE),
  EXE_CODE     VARCHAR2(8 BYTE),
  ENLN            NUMBER,
  FROM_DAYS       NUMBER(10),
  TILL_DAYS       NUMBER(10),
  COMM_ON         VARCHAR2(8 BYTE),
  COMM_RATE       NUMBER(10,2),
  CREATED_BY      VARCHAR2(8 BYTE),
  CREATED_DATE    DATE                          DEFAULT sysdate,
  UPDATED_BY      VARCHAR2(8 BYTE),
  UPDATED_DATE    DATE,
  COMM_TARGET_ID  NUMBER(10)
)

====end======avinash============by mimoh==========================================



////////////issue no 8461/////////////////



ALTER TABLE preferrences ADD (EXECUTIVECREDITLIMIT  VARCHAR2(1 BYTE));


////////////////end of issue no 8461//////////
