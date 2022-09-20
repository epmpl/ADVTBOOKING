
==start==========avinash===by mimoh=====13/july/2012======================================================

CREATE OR REPLACE PACKAGE websp_insertMatter is
procedure websp_insertMatter_p(
cioid            varchar2,
matter_filename  varchar2,
RTFformat        varchar2,
XTGformat        varchar2,
matter           varchar2,
receiptno        varchar2,
p_lang           varchar2,
p_userid           varchar2
);
end websp_insertMatter;
/

/************************************************************************************************/

CREATE OR REPLACE PACKAGE BODY websp_insertMatter is
procedure websp_insertMatter_p(
cioid            varchar2,
matter_filename  varchar2,
RTFformat        varchar2,
XTGformat        varchar2,
matter           varchar2,
receiptno        varchar2,
p_lang           varchar2,
p_userid           varchar2
)as
begin
insert into tbl_matter("cioid","matter_filename","RTFformat","XTGformat","matter","receipt",LANG,CREATED_BY,CREATED_DATE) values(cioid,matter_filename,RTFformat,XTGformat,matter,receiptno,p_lang,p_userid,sysdate);
end websp_insertMatter_p;
end websp_insertMatter;
/




/************************************************************************************************/

CREATE OR REPLACE PACKAGE websp_modifyMatter is
procedure websp_modifyMatter_p(
cioid in varchar2,
matter_filename in varchar2,
RTFformat in varchar2,
XTGformat in varchar2,
matter in varchar2,
flag in varchar2,
receiptnumber in varchar2,
p_lang  in varchar2,
p_userid in varchar2
);
end  websp_modifyMatter;
/


CREATE OR REPLACE PACKAGE BODY websp_modifyMatter is
procedure websp_modifyMatter_p(
cioid in varchar2,
matter_filename in varchar2,
RTFformat in varchar2,
XTGformat in varchar2,
matter in varchar2,
flag in varchar2,
receiptnumber in varchar2,
p_lang  in varchar2,
p_userid in varchar2
)as
begin
if(flag='1') then
update tbl_matter set "RTFformat"=RTFformat,"XTGformat"=XTGformat,"matter"=matter,LANG=p_lang,UPDATED_BY=p_userid,UPDATED_DATE=sysdate where "cioid"=cioid and "matter_filename"=matter_filename;
else
insert into tbl_matter("cioid","matter_filename","RTFformat","XTGformat","matter","receipt",LANG,CREATED_BY,CREATED_DATE) values(cioid,matter_filename,RTFformat,XTGformat,matter,receiptnumber,p_lang,p_userid,sysdate);
end if;
end websp_modifyMatter_p;
end  websp_modifyMatter;
/


/****************************************************************************************************/


CREATE OR REPLACE PROCEDURE checkID_matter
(

cioid1 IN VARCHAR2,

P_Accounts OUT Cur_Type_New1.cursor_type

)


IS
previd varchar2(100);
RECEIPT VARCHAR2(50);
count1 int;
BEGIN
select count(*) into count1 from tbl_MATTER WHERE "cioid"=cioid1;
begin
select "prev_cioid","Receipt_no" into previd , RECEIPT from tbl_booking_mast where "cio_booking_id"=cioid1;
  EXCEPTION
                  WHEN NO_DATA_FOUND THEN  NULL;
                END;
if previd is not null and count1=0 then
insert into tbl_matter("cioid","matter_filename","matter","receipt","RTFformat","XTGformat",CREATED_BY,CREATED_DATE) select cioid1,"matter_filename","matter",RECEIPT,"RTFformat","XTGformat",CREATED_BY,CREATED_DATE from tbl_matter where "cioid"=previd;
end if;
OPEN p_accounts FOR
select "prev_cioid" from tbl_booking_mast where "cio_booking_id"=cioid1;



END ;
/


==end==========avinash===by mimoh=====13/july/2012======================================================

/////////////done by shipra ////////////8096///////////////


CREATE TABLE AD_FMG_REASON_MAST
 (COMP_CODE VARCHAR2(8),
  REASON_CODE NUMBER(5),
  REASON_DESC VARCHAR2(30),
  CREATED_BY VARCHAR2(30),
  CREATED_DT DATE DEFAULT SYSDATE,
  UPDATED_BY VARCHAR2(30),
  UPDATED_DT DATE,
  CONSTRAINT AD_FMG_REASON_MAST_PK
  PRIMARY KEY (REASON_CODE)) 


////////////////////////////end by shipra////////////////8096//////////


////////////***********************************Sumit Roy(Rate Code Master)*************************//////////////////////

DROP TABLE RATE_CODE_MAST CASCADE CONSTRAINTS;

CREATE TABLE RATE_CODE_MAST
(
  RATE_CODE    VARCHAR2(50 BYTE),
  RATE_DESC    VARCHAR2(100 BYTE),
  STATUS       VARCHAR2(50 BYTE),
  REMARKS      VARCHAR2(500 BYTE),
  COMP_CODE    VARCHAR2(12 BYTE),
  USERID       VARCHAR2(50 BYTE),
  CREATE_DATE  DATE,
  MODIFY_USER  VARCHAR2(50 BYTE),
  MODIFY_DATE  DATE
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







///////////////////////////////////****************************END*********************************//////////////////////