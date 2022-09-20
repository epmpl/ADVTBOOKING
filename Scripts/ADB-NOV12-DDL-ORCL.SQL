alter table preferrences add (ALLOW_RET_AFTER_BANK varchar2(2))



/**********************update by dhananjay for edition master**********************************/

CREATE TABLE HT18JULY.SELECT_EDITION_TXT
(
  COMP_CODE     VARCHAR2(8 BYTE),
  EDITION_CODE  VARCHAR2(8 BYTE),
  TXTSUN        VARCHAR2(100 BYTE),
  TXTMON        VARCHAR2(100 BYTE),
  TXTTUE        VARCHAR2(100 BYTE),
  TXTWED        VARCHAR2(100 BYTE),
  TXTTHU        VARCHAR2(100 BYTE),
  TXTFRI        VARCHAR2(100 BYTE),
  TXTSAT        VARCHAR2(100 BYTE),
  USERID        VARCHAR2(8 BYTE),
  TEMP_ID       NUMBER
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


CREATE OR REPLACE TRIGGER HT18JULY.FOO_trg
before insert ON HT18JULY.SELECT_EDITION_TXT for each row
begin
  select FOO_seq.nextval into :new.temp_id from dual;
end;
/




/**********************end*****************************/



/**********************update by dhananjay for ad category master**********************************/

CREATE TABLE HT18JULY.SELECT_ADVCAT_TXT
(
  COMP_CODE     VARCHAR2(8 BYTE),
  ADV_CAT_CODE  VARCHAR2(8 BYTE),
  TXTSUN        VARCHAR2(100 BYTE),
  TXTMON        VARCHAR2(100 BYTE),
  TXTTUE        VARCHAR2(100 BYTE),
  TXTWED        VARCHAR2(100 BYTE),
  TXTTHU        VARCHAR2(100 BYTE),
  TXTFRI        VARCHAR2(100 BYTE),
  TXTSAT        VARCHAR2(100 BYTE),
  USERID        VARCHAR2(8 BYTE),
  TEMP_ID       NUMBER
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


CREATE OR REPLACE TRIGGER HT18JULY.Select_AdvCat_txt_trg
before insert ON HT18JULY.SELECT_ADVCAT_TXT for each row
begin
  select Select_AdvCat_txt_seq.nextval into :new.temp_id from dual;
end;
/






/**********************end*****************************/









///////////update by shipra in agency master issue no 9143//////////////////////////////


ALTER TABLE AGENCY_MAST
 ADD (AGENCY_DESIGNATION VARCHAR2(50));






//////////////////end by shipra ////////////////////////////
