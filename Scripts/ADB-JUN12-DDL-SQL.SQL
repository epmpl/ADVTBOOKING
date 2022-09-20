////////////////shipra///////////////done by lata mam//////////////

ALTER TABLE EDITION_MAST
ADD GROUPCODE int


/////////////////end by shipra//////////////////////////////////////////////


===start=======avinash==================07june2012===================by lata mam======
alter table tbl_booking_mast add RATE_AUDIT_IP varchar(20);

alter table tbl_booking_insert add RATE_AUDIT_IP varchar(20);
    alter table PREFERRENCES add rate_audit_log_required varchar2(1);

alter table  tbl_booking_mast add RATE_AUDIT_FLAG varchar(1)
alter table  tbl_booking_insert add RATE_AUDIT_FLAG varchar(1)


 alter table tbl_booking_mast add TRANSLATION_DISC varchar(10)
        alter table tbl_booking_mast add POSPREM_DISC varchar(10)
   
      alter table tbl_booking_mast_g add TRANSLATION_DISC varchar(10)
        alter table tbl_booking_mast_g add POSPREM_DISC varchar(10)


===start=======avinash=====================================by lata mam======

///////////////start///avinash==========15-06==2012===================================

alter table contract_mast add QUOTATION varchar(2);
///////////////end///avinash==========15-06==2012===================================


==start==========7854===avinash=============================26/06/2012=========

CREATE TABLE ALLTHUMBIMAGE_LOG
( ORIGINALNAME VARCHAR(1000),
  SAPNAME VARCHAR(30),
  FLAG CHAR(1) DEFAULT 'N',
  INSDATE DATETIME,
  PRIPUB VARCHAR(5),
  BKFOR VARCHAR(3),
  EDITION VARCHAR(3),
  SECPUB VARCHAR(8),
  USERNAME VARCHAR(50),
  MACHINE_IP VARCHAR(20),
  UPD_DATETIME DATETIME)

==end==========7854===avinash=============================26/06/2012=========





