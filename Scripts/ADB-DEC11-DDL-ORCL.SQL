/*=======================================  ISSUE 5952 (mimoh) ==============================*/

 ALTER TABLE RETAIN_ADCOMM_TARGET ADD (CONSTRAINT RETAIN_ADCOMM_TARGET_PK PRIMARY 
KEY(COMP_CODE, RETAIN_CODE, COMM_TARGET_ID,ADD_COMM_ID))

CREATE SEQUENCE RETAIN_ADCOMM_TARGET_SEQ
START WITH 555
MAXVALUE 999999999999999999
MINVALUE 1
NOCYCLE
NOCACHE
NOORDER;


exec add_col_in_table (' retain_comm_slab','COMM_TARGET_ID','INTEGER',null) ;


/************************/
ALTER TABLE RETAIN_ADCOMM_TARGET
 DROP PRIMARY KEY CASCADE;
DROP TABLE RETAIN_ADCOMM_TARGET CASCADE CONSTRAINTS;

CREATE TABLE RETAIN_ADCOMM_TARGET
(
  COMP_CODE       VARCHAR2(8 BYTE)              NOT NULL,
  RETAIN_CODE     VARCHAR2(8 BYTE)              NOT NULL,
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
TABLESPACE USERS
PCTUSED    0
PCTFREE    10
INITRANS   1
MAXTRANS   255
STORAGE    (
            INITIAL          64K
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            BUFFER_POOL      DEFAULT
           )
LOGGING 
NOCOMPRESS 
NOCACHE
NOPARALLEL
MONITORING;


CREATE UNIQUE INDEX RETAIN_ADCOMM_TARGET_PK ON RETAIN_ADCOMM_TARGET
(COMP_CODE, RETAIN_CODE, COMM_TARGET_ID, ADD_COMM_ID)
LOGGING
TABLESPACE USERS
PCTFREE    10
INITRANS   2
MAXTRANS   255
STORAGE    (
            INITIAL          64K
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            BUFFER_POOL      DEFAULT
           )
NOPARALLEL;


ALTER TABLE RETAIN_ADCOMM_TARGET ADD (
  CONSTRAINT RETAIN_ADCOMM_TARGET_PK
 PRIMARY KEY
 (COMP_CODE, RETAIN_CODE, COMM_TARGET_ID, ADD_COMM_ID)
    USING INDEX 
    TABLESPACE USERS
    PCTFREE    10
    INITRANS   2
    MAXTRANS   255
    STORAGE    (
                INITIAL          64K
                MINEXTENTS       1
                MAXEXTENTS       UNLIMITED
                PCTINCREASE      0
               ));




/*********************************************************/
ALTER TABLE RETAIN_COMM_TARGET
 DROP PRIMARY KEY CASCADE;
DROP TABLE RETAIN_COMM_TARGET CASCADE CONSTRAINTS;

CREATE TABLE RETAIN_COMM_TARGET
(
  COMP_CODE       VARCHAR2(8 BYTE)              NOT NULL,
  RETAIN_CODE     VARCHAR2(8 BYTE)              NOT NULL,
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
TABLESPACE USERS
PCTUSED    0
PCTFREE    10
INITRANS   1
MAXTRANS   255
STORAGE    (
            INITIAL          64K
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            BUFFER_POOL      DEFAULT
           )
LOGGING 
NOCOMPRESS 
NOCACHE
NOPARALLEL
MONITORING;


CREATE UNIQUE INDEX RETAIN_COMM_TARGET_PK ON RETAIN_COMM_TARGET
(COMP_CODE, RETAIN_CODE, COMM_TARGET_ID)
LOGGING
TABLESPACE USERS
PCTFREE    10
INITRANS   2
MAXTRANS   255
STORAGE    (
            INITIAL          64K
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            BUFFER_POOL      DEFAULT
           )
NOPARALLEL;


ALTER TABLE RETAIN_COMM_TARGET ADD (
  CONSTRAINT RETAIN_COMM_TARGET_PK
 PRIMARY KEY
 (COMP_CODE, RETAIN_CODE, COMM_TARGET_ID)
    USING INDEX 
    TABLESPACE USERS
    PCTFREE    10
    INITRANS   2
    MAXTRANS   255
    STORAGE    (
                INITIAL          64K
                MINEXTENTS       1
                MAXEXTENTS       UNLIMITED
                PCTINCREASE      0
               ));


/*=======================================  ISSUE 5952 (mimoh) ==============================*/

/*======================================= ISSUE 0005968 (Kuldeep Bhati) ==============================*/
ALTER TABLE AGENCY_MAST
 ADD (RATE_REVISE  VARCHAR2(5));
/*======================================= End of ISSUE 0005968 (Kuldeep Bhati) ==============================*/

/*======================================= ISSUE 0005972 ==============================*/
ALTER TABLE CUST_MAST
 ADD (TYPE  VARCHAR2(5));

ALTER TABLE CUST_MAST
 ADD (PARENT_CLIENT  VARCHAR2(8));
 
 ALTER TABLE CUST_MAST_TEMP
 ADD (TYPE  VARCHAR2(5));

ALTER TABLE CUST_MAST_TEMP
 ADD (PARENT_CLIENT  VARCHAR2(8));
/*======================================= End of ISSUE 0005972 ==============================*/

/*======================================= ISSUE 0005970 (Kuldeep Bhati) ==============================*/
exec add_col_in_table ('TBL_BOOKING_MAST','REVISE_DATE','DATE',null) ;
exec add_col_in_table ('TBL_BOOKING_MAST_G','REVISE_DATE','DATE',null) ;
exec add_col_in_table ('TEMPBOOKING_MAST','REVISE_DATE','DATE',null) ;
/*======================================= End of ISSUE 0005970 (Kuldeep Bhati) ==============================*/

/********************mimoh***********************************/
exec add_col_in_table ('preferrences','ALLOW_FOLLOW_DT_BOOOK','VARCHAR2(1)',null) ;


/********************mimoh***********************************/


/*******************************Laxman 26-dec-2011 issue no. 6137*************/
ALTER TABLE CRM_SCH_PUBL_EXPIRY ADD (EDITION_CODE VARCHAR(3),AGCD VARCHAR(8),DPCD VARCHAR(8),SUP_TY_CODE VARCHAR(5))

ALTER TABLE PREFERRENCES ADD (CRM_SUPPLY_TYPE_PAID VARCHAR(5),CRM_SUPPLY_TYPE_FREE VARCHAR(5))
/*******************************Laxman 26-dec-2011 issue no. 6137*************/
/***********************mimoh 28dec 2011*********6162****************************************/
ALTER TABLE PREFERRENCES
ADD (CURRENCY_MEASUREMENT VARCHAR2(5 BYTE));

/***********************mimoh 28dec 2011*********6162****************************************/

/*******************************contract************************/
ALTER TABLE tv_booking_det
ADD (DEAL_NO VARCHAR2(5 BYTE));


ALTER TABLE tv_ad_channel
ADD (MODE_TYPE VARCHAR2(20 BYTE));


ALTER TABLE tv_ad_channel
ADD (LOCID VARCHAR2(20 BYTE));

ALTER TABLE tv_ad_channel
ADD (MAX_BREAK_TIME NUMBER);


ALTER TABLE contract_mast
ADD (DEALON VARCHAR2(20 BYTE));



ALTER TABLE contract_mast
ADD (INDUSTRY_PRODUCT VARCHAR2(100 BYTE))

ALTER TABLE contract_mast
ADD (INDUSTRY VARCHAR2(10 BYTE))


ALTER TABLE contract_mast
ADD (AFT_PRTCLR_AD VARCHAR2(10 BYTE))


ALTER TABLE contract_mast
ADD (SEQNO VARCHAR2(10 BYTE))

ALTER TABLE contract_mast
ADD (SEQNO_ALLOW VARCHAR2(10 BYTE))



ALTER TABLE contract_mast
ADD (B2B VARCHAR2(10 BYTE))

ALTER TABLE contract_mast
ADD (CHKMULTIAD VARCHAR2(10 BYTE))
/*******************************contract************************/

/*======================================= ISSUE 0005976 (Kuldeep Bhati) ==============================*/
CREATE TABLE AD_TABLEID_PRE_SAVE
(
  "Booking_id"     VARCHAR2(50 BYTE),
  "Receipt_no"     INTEGER,
  "Box_no"         VARCHAR2(50 BYTE),
  "Dockit_no"      VARCHAR2(50 BYTE),
  "Contract_code"  INTEGER
)
/*======================================= End of ISSUE 0005976 (Kuldeep Bhati) ==============================*/

/**************************************************deal 6036****************************/
ALTER TABLE CONTRACT_MAST
 ADD (AUDITBY  VARCHAR2(20 BYTE));
ALTER TABLE CONTRACT_MAST
 ADD (AUDIT_COMMENT  VARCHAR2(500 BYTE));

ALTER TABLE CONTRACT_MAST
 ADD (AUDIT_DATE  DATE);

/**************************************************deal 6036****************************/


/**************************************************ankit deal 6181****************************/
ALTER TABLE ad_cat3 ADD (STATUS VARCHAR(5 BYTE))

/**************************************************ankit deal 6181****************************/
/*******************************************mimoh*****************5jan2012***********/
/*******19 jan*************end*************** issue 6211*************************************mimoh**********/

ALTER TABLE contract_mast ADD (ATTACHMENT   VARCHAR2(200));



/*******19 jan*************end*************** issue 6211*************************************mimoh**********/


