
/***********mimoh 16042012****************************7196********************************/
ALTER TABLE AGENCY_MAST ADD EDTN_WISE_BILL_REQ VARCHAR2(1) DEFAULT 'N'

/***********mimoh 16042012****************************7196********************************/


/***********ankit****************************add category********************************/

alter table Adv_Cat_Mast add (Preodicity_Code  VARCHAR2(8))
alter table Adv_Cat_Mast add (RO_hr  VARCHAR2(8))
alter table Adv_Cat_Mast add (RO_min  VARCHAR2(8))

/***********ankit****************************add category********************************/


==============start===7343====avinash==================================

ALTER TABLE HT18JULY.ADV_Exec_mast
ADD (EMAIL_ID VARCHAR2(200 BYTE));

==============END===7343====avinash==================================