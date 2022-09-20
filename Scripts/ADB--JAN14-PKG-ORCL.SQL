



CREATE OR REPLACE PACKAGE BODY Dateinsert  IS


PROCEDURE    dateinsert_p(
date1 IN VARCHAR2,
noissueday IN VARCHAR2,
--noedition IN VARCHAR2,
issuecode IN VARCHAR2,
compcode IN VARCHAR2,
userid IN VARCHAR2) AS
pubcode_p  varchar2(50);
citycode_p  varchar2(50);
count1 int;

BEGIN

select COUNT(*) into count1 from No_Iss_Grid where "No_Iss_Code"=issuecode and "no_issue_date"=date1;
if count1=0  then
INSERT INTO NO_ISS_GRID
 ("datecode",  "Comp_Code" ,   "No_Iss_Code",   "no_issue_date",  "No_Iss_day"  ,  "UserId")
VALUES (DATECODE.nextval,compcode,issuecode, date1,  noissueday,  userid );
COMMIT;

/*
select "Pub_Code","City_Code" into pubcode_p,citycode_p from edition_mast where "Edition_Code"=noedition;

select COUNT(*) into count1 from No_Iss_Grid where "No_Iss_Code"=issuecode and "no_issue_date"=date1;
if count1=0  then
delete from  No_Iss_Grid where "No_Iss_Code" in(select "Edition_Code" from edition_mast where "Pub_Code"=pubcode_p and "City_Code"=citycode_p) and "no_issue_date"=date1;

delete from  No_Iss_Grid where "No_Iss_Code" in(select "Edition_Code" from supplement_mast where "Edition_Code" in
(Select "Edition_Code" from edition_mast where "Pub_Code"=pubcode_p and "City_Code"=citycode_p)) and "no_issue_date"=date1;


INSERT INTO NO_ISS_GRID
 ("datecode",  "Comp_Code" ,   "No_Iss_Code",   "no_issue_date",  "No_Iss_day"  ,  "UserId")
 select DATECODE.nextval,compcode,issuecode, date1,  noissueday,  userid from edition_mast where "Pub_Code"=pubcode_p and "City_Code"=citycode_p;
 
 iNSERT INTO NO_ISS_GRID
 ("datecode",  "Comp_Code" ,   "No_Iss_Code",   "no_issue_date",  "No_Iss_day"  ,  "UserId")
 select DATECODE.nextval,compcode,issuecode, date1,  noissueday,  userid  from 
 supplement_mast where "Edition_Code" in(Select "Edition_Code" from edition_mast where "Pub_Code"=pubcode_p and "City_Code"=citycode_p);  
*/
--VALUES (DATECODE.nextval,compcode,issuecode, date1,  noissueday,  userid );
COMMIT;

end if;
END dateinsert_p;
END Dateinsert;
/
--=============************ 14/01/2014--------------------------------------

CREATE OR REPLACE PACKAGE BODY advtypbind
IS
   PROCEDURE advtypbind_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
         SELECT "Adv_Type_Code", "Adv_Type_Name"
           FROM adv_type_mast
          WHERE "Comp_Code" = compcode order by "Adv_Type_Name";
   END advtypbind_p;
END advtypbind;
/
***********************************************************


CREATE OR REPLACE PACKAGE advtypbind
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE advtypbind_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END advtypbind;
/

************************************************************

CREATE OR REPLACE PROCEDURE select_addType_with_plus(
       compcode     in varchar2,
       adtype       in varchar2,
       p_accounts  out cur_type_new1.cursor_type
      )
   As
  Begin
  open p_accounts for
   select "Combin_Code","Package_Name" from combin_mast where "Comp_Code"=compcode and "Ad_Type_code"=adtype
and "Combin_Desc" like '%+%'  order by "Package_Name";

  END;
/



***************************************************************************

CREATE OR REPLACE PROCEDURE select_edition_combin_code(
    packdes         in varchar2,
    pcombin_code    in varchar2,
    p_accounts      out cur_type_new1.cursor_type
      )
As
   pcountnum int;
   vquery varchar2(1000);
   
Begin
  

  select count(*) into pcountnum FROM tbl_combinPrintEdition 
  WHERE package_name = packdes AND combin_code = pcombin_code;

    --delete from test1
    --insert into test1(vstring,vstring2) values (pcountnum,'packdes'||packdes||'pcombin_code'||pcombin_code);commit; 
 
  
      if (nvl(pcountnum,0)>0) 
      then
       
          vquery:='select ''Already added'' as COMBIN_DESC from dual'; 
      
      else
      
          vquery:='select distinct "Combin_Desc" as COMBIN_DESC from combin_mast where "Package_Name" ='''||packdes||''' and "Combin_Code"='''||pcombin_code||'''';
      end if;

    --  insert into test1(vstring,vstring2) values (pcountnum,'vquery '||vquery);commit;
      
OPEN p_accounts FOR
vquery;
      

  END;
/

******************************************************************************************




CREATE OR REPLACE PROCEDURE execute_packbill(
       pcompcode     in varchar2,
       padtype       in varchar2,
       ppackagecode         in varchar2,
       p_accounts  out cur_type_new1.cursor_type
      )
   As
  
  Begin
      open p_accounts for
   select * from tbl_combinPrintEdition where comp_code=pcompcode
    AND (   adtype = padtype OR padtype IS NULL)
     AND (   combin_code = ppackagecode OR ppackagecode IS NULL);

  END;
/

***********************************************************************************************


CREATE OR REPLACE PROCEDURE SP_combinPrintEdition(
       prctype     in varchar2,
       pack_name       in varchar2,
       flag         in varchar2,
       combin_code         in varchar2,
       package_name in varchar2,
       adtye in varchar2,
       comp_code in varchar2,
       p_accounts  out cur_type_new1.cursor_type
      )
   As
   query varchar2(4000);
  Begin
    if prctype = 'MOD_INSERT' then
	INSERT INTO tbl_combinPrintEdition (ID,pack_name,flag,combin_code,package_name,creat_date,adtype,comp_code)
    VALUES(CMBPRINTEDI.nextval,pack_name,flag,package_name,combin_code,sysdate(),adtye,comp_code);
    commit;
    open p_accounts for
    select 'A' from dual;
    END if;
    
    IF prctype = 'MOD_UPDATE' then
        query:='UPDATE tbl_combinPrintEdition SET FLAG ='''|| pack_name||''' 
        WHERE ID=CAST('''||flag||''' AS int)';
       execute immediate(query);
         COMMIT;
        --delete from test1;
        insert into test1(vstring,vstring2)values ('dik',query);
         open p_accounts for
    select 'A' from dual;
	END if;
	
	IF prctype = 'MOD_SELECT' then
     open p_accounts for
			SELECT  distinct combin_code, (rtrim(package_name)||'~'||combin_code)as package_name,adtype  FROM tbl_combinPrintEdition WHERE comp_code=comp_code;
	END if;
	
	IF prctype = 'MOD_SELECT_DISTINCT_PACKAGE_NAME' then
     open p_accounts for
			SELECT distinct package_name FROM tbl_combinPrintEdition ;
	END if;
  

  END;
/

--end 14/01/2014===============================================

////*************************15-01-2014***************

CREATE OR REPLACE PACKAGE BODY Dateinsert  IS


PROCEDURE    dateinsert_p(
date1 IN VARCHAR2,
noissueday IN VARCHAR2,
--noedition IN VARCHAR2,
issuecode IN VARCHAR2,
compcode IN VARCHAR2,
userid IN VARCHAR2) AS
pubcode_p  varchar2(50);
citycode_p  varchar2(50);
count1 int;

BEGIN

select COUNT(*) into count1 from No_Iss_Grid where "No_Iss_Code"=issuecode and "no_issue_date"=date1;
if count1=0  then
INSERT INTO NO_ISS_GRID
 ("datecode",  "Comp_Code" ,   "No_Iss_Code",   "no_issue_date",  "No_Iss_day"  ,  "UserId")
VALUES (DATECODE.nextval,compcode,issuecode, date1,  noissueday,  userid );
COMMIT;

/*
select "Pub_Code","City_Code" into pubcode_p,citycode_p from edition_mast where "Edition_Code"=noedition;

select COUNT(*) into count1 from No_Iss_Grid where "No_Iss_Code"=issuecode and "no_issue_date"=date1;
if count1=0  then
delete from  No_Iss_Grid where "No_Iss_Code" in(select "Edition_Code" from edition_mast where "Pub_Code"=pubcode_p and "City_Code"=citycode_p) and "no_issue_date"=date1;

delete from  No_Iss_Grid where "No_Iss_Code" in(select "Edition_Code" from supplement_mast where "Edition_Code" in
(Select "Edition_Code" from edition_mast where "Pub_Code"=pubcode_p and "City_Code"=citycode_p)) and "no_issue_date"=date1;


INSERT INTO NO_ISS_GRID
 ("datecode",  "Comp_Code" ,   "No_Iss_Code",   "no_issue_date",  "No_Iss_day"  ,  "UserId")
 select DATECODE.nextval,compcode,issuecode, date1,  noissueday,  userid from edition_mast where "Pub_Code"=pubcode_p and "City_Code"=citycode_p;
 
 iNSERT INTO NO_ISS_GRID
 ("datecode",  "Comp_Code" ,   "No_Iss_Code",   "no_issue_date",  "No_Iss_day"  ,  "UserId")
 select DATECODE.nextval,compcode,issuecode, date1,  noissueday,  userid  from 
 supplement_mast where "Edition_Code" in(Select "Edition_Code" from edition_mast where "Pub_Code"=pubcode_p and "City_Code"=citycode_p);  
*/
--VALUES (DATECODE.nextval,compcode,issuecode, date1,  noissueday,  userid );
COMMIT;

end if;
END dateinsert_p;
END Dateinsert;
/


============

CREATE OR REPLACE PACKAGE BODY noissdelete  is


procedure   noissdelete_p(edition in varchar2,
issuecode in varchar2,
compcode in varchar2,
userid in varchar2) as
begin
delete from NO_ISS_MAST where "Comp_Code"=compcode and "No_Iss_Code"=issuecode and "Edition_Code" =edition;

delete from NO_ISS_GRID where "Comp_Code"=compcode and "No_Iss_Code"=issuecode;

commit;
end noissdelete_p;

end noissdelete;
/

///=========

CREATE OR REPLACE PACKAGE BODY Noissexe IS
PROCEDURE noissexe_P(
edition IN VARCHAR2,
editionali in varchar2,
issuecode IN VARCHAR2,
compcode IN VARCHAR2,
userid IN VARCHAR2,
P_Accounts OUT T_Accounts_Cursor)AS
BEGIN
OPEN p_accounts FOR
         SELECT  "Comp_Code", "No_Iss_Code","Edition_Code", "UserId","EDITIONALIAS" FROM NO_ISS_MAST
          WHERE ("Comp_Code" = compcode OR compcode IS NULL)
            AND ("Edition_Code"= edition )
            AND ("EDITIONALIAS" =  editionali OR editionali IS NULL)
            AND ("No_Iss_Code" LIKE issuecode || '%' OR issuecode IS NULL);
END noissexe_P;
END Noissexe;
/

=======================

CREATE OR REPLACE PACKAGE BODY noissmodify  is


procedure   noissmodify_p(edition in varchar2,
issuecode in varchar2,
compcode in varchar2,
userid in varchar2,
peditionalias in varchar2) as
begin
update NO_ISS_MAST set  "Edition_Code" =edition ,"EDITIONALIAS"=peditionalias where "Comp_Code"=compcode and "No_Iss_Code"=issuecode;


commit;
end noissmodify_p;
end noissmodify;
/

==================
CREATE OR REPLACE PACKAGE BODY Noissinsert  IS


PROCEDURE   noissinsert_p(edition IN VARCHAR2,
issuecode IN VARCHAR2,
compcode IN VARCHAR2,
userid IN VARCHAR2,
peditionalias in varchar2) AS
pubcode_p  varchar2(50);
citycode_p  varchar2(50);
BEGIN
INSERT INTO NO_ISS_MAST("Comp_Code","No_Iss_Code","Edition_Code","UserId","Creation_Datetime","EDITIONALIAS") VALUES(compcode,issuecode,edition,userid,sysdate,peditionalias);
--COMMIT;

--INSERT INTO NO_ISS_MAST("Comp_Code","No_Iss_Code","Edition_Code","UserId","Creation_Datetime") VALUES(compcode,issuecode,edition,userid,sysdate);
COMMIT;
END noissinsert_p;
END Noissinsert;
/

CREATE OR REPLACE procedure editionnamebind_supp
(

compcode   in varchar2,
pedition in varchar2,
userid     in varchar2,
p_Accounts out  cur_type_new1.cursor_type,
p_Accounts1 out  cur_type_new1.cursor_type

) 
 as
editioncode_p varchar2(50);
editionname_p varchar2(500);
editiontype_p varchar2(100);
editionalias_p varchar2(100);
begin

delete from result2;

         DECLARE
         CURSOR r_cursor
         IS
            SELECT  "Pub_Code","City_Code" from edition_mast 
            --,pub_mast p 
            where    "Comp_Code" = compcode          
            and      "Edition_Code"=pedition            
            order by "Edition_Alias";
            
      BEGIN
         OPEN r_cursor;

         LOOP
            FETCH r_cursor
             INTO editioncode_p,editionname_p;

            --RATECHECKDATE FOR VALID RATECARD AND BDATE FOR DAYWISE RATE
            EXIT WHEN r_cursor%NOTFOUND;
            insert into result2(EDITIONPRIOR,EDITION_CODE,EDITIONALIAS)
            select "Edition_Code",replace(nvl(SHORT_NAME,"Edition_Alias"),'null',"Edition_Alias"),
            "Edition_Alias" from edition_mast where "Pub_Code"=editioncode_p 
            and ("Edition_Type"!='Main Edition')
             and "City_Code"=editionname_p;
 
                insert into result2(EDITIONPRIOR,EDITION_CODE,EDITIONALIAS) select 
                "Supp_Code",replace(NVL(SHORT_NAME,"Supp_Alias"),
                'null',"Supp_Alias"),"Supp_Alias"
                from supplement_mast where "Edition_Code" 
                in(Select "Edition_Code" from edition_mast where "Pub_Code"=editioncode_p 
                and "City_Code"=editionname_p);  
                
                
            
            END LOOP;
      END;  

open p_Accounts for
select EDITION_CODE as "Edition_Alias", EDITIONPRIOR as "Edition_Code",EDITIONALIAS from result2;
open p_Accounts1 for
select "No_Iss_Day_Code", "No_Iss_Day"  from No_ISSUE_DAY  
 where "Comp_Code" = compcode  order by "No_Iss_Day";
delete from result2;

end;
/

///==============================
CREATE OR REPLACE package  body TESTCOPY.editionnamebind is
procedure   editionnamebind_p
(compcode   in varchar2,
userid     in varchar2,
p_Accounts out T_Accounts_Cursor,
p_Accounts1 out T_Accounts_Cursor) as
editioncode_p varchar2(50);
editionname_p varchar2(500);
editiontype_p varchar2(100);
editionalias_p varchar2(100);
begin

delete from result2;
    /* open p_Accounts for
   select e."Edition_Alias" "Edition_Alias", e."Edition_Code" "Edition_Code",replace(nvl(e.SHORT_NAME,e."Edition_Alias"),'null',e."Edition_Alias") SHORT_NAME from edition_mast e,pub_mast p
        where e."Comp_Code" = compcode and e."Comp_Code" = p."Comp_Code" and e."Pub_Code"=p."Pub_Code" and
        p."publication_type"<>'CO0'
          UNION 
          select e1."Supp_Alias" "Edition_Alias",e1."Supp_Code" "Edition_Code",replace(NVL(e1.SHORT_NAME,e1."Supp_Alias"),'null',e1."Supp_Alias") SHORT_NAME from supplement_mast e1,pub_mast p1
        where e1."Comp_Code" = compcode and e1."Comp_Code" = p1."Comp_Code" and e1."Pub_Code"=p1."Pub_Code" and
        p1."publication_type"<>'CO0'
        order by "Edition_Alias" ;*/
         DECLARE
         CURSOR r_cursor
         IS
            SELECT  "Edition_Code",replace(nvl(e.SHORT_NAME,e."Edition_Alias"),'null',e."Edition_Alias"),e."Edition_Type",e."Edition_Alias" from edition_mast e,pub_mast p 
             where e."Comp_Code" = compcode
              and e."Comp_Code" = p."Comp_Code" 
              and e."Pub_Code"=p."Pub_Code" 
              and e."Edition_Type"='Main Edition'
              and
        p."publication_type"<>'CO0'   
         order by "Edition_Alias";
      BEGIN
         OPEN r_cursor;

         LOOP
            FETCH r_cursor
             INTO editioncode_p,editionname_p,editiontype_p,editionalias_p;

            --RATECHECKDATE FOR VALID RATECARD AND BDATE FOR DAYWISE RATE
            EXIT WHEN r_cursor%NOTFOUND;
           -- if editiontype_p='Main Edition' then
                insert into result2(EDITIONPRIOR,EDITION_CODE,EDITIONALIAS) values(editioncode_p,editionname_p,editionalias_p);
           -- end if;    
               -- insert into result2(EDITIONPRIOR,EDITION_CODE,EDITIONALIAS) select "Supp_Code",replace(NVL(SHORT_NAME,"Supp_Alias"),'null',"Supp_Alias"),"Supp_Alias" from supplement_mast where "Edition_Code"=editioncode_p;
            END LOOP;
      END;  

open p_Accounts for
select EDITION_CODE as "Edition_Alias", EDITIONPRIOR as "Edition_Code",EDITIONALIAS from result2;
    open p_Accounts1 for
    select "No_Iss_Day_Code", "No_Iss_Day"  from No_ISSUE_DAY   where "Comp_Code" = compcode  order by "No_Iss_Day";
delete from result2;
end   editionnamebind_p;
end   editionnamebind;
/
======= end 15-01-2014==================

-=========start 18-01-2014=================


CREATE OR REPLACE PACKAGE BODY HT18JULY.advtypbind
IS
   PROCEDURE advtypbind_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
         SELECT "Adv_Type_Code", "Adv_Type_Name"
           FROM adv_type_mast
          WHERE "Comp_Code" = compcode order by "Adv_Type_Name";
   END advtypbind_p;
END advtypbind;
/
--
CREATE OR REPLACE PACKAGE HT18JULY.advtypbind
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE advtypbind_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END advtypbind;
/

---------------------------------------------------


CREATE OR REPLACE PROCEDURE HT18JULY.select_addType_with_plus(
       compcode     in varchar2,
       adtype       in varchar2,
       p_accounts  out cur_type_new1.cursor_type
      )
   As
  Begin
  open p_accounts for
   select "Combin_Code","Package_Name" from combin_mast where "Comp_Code"=compcode and "Ad_Type_code"=adtype
and "Combin_Desc" like '%+%'  order by "Package_Name";

  END;
/
-----------------------------------------------------



CREATE OR REPLACE PROCEDURE HT18JULY.select_edition_combin_code(
    packdes         in varchar2,
    pcombin_code    in varchar2,
    p_accounts      out cur_type_new1.cursor_type
      )
As
   pcountnum int;
   vquery varchar2(1000);
   
Begin
  

  select count(*) into pcountnum FROM tbl_combinPrintEdition 
  WHERE package_name = packdes AND combin_code = pcombin_code;

    --delete from test1
    --insert into test1(vstring,vstring2) values (pcountnum,'packdes'||packdes||'pcombin_code'||pcombin_code);commit; 
 
  
      if (nvl(pcountnum,0)>0) 
      then
       
          vquery:='select ''Already added'' as COMBIN_DESC from dual'; 
      
      else
      
          vquery:='select distinct "Combin_Desc" as COMBIN_DESC from combin_mast where "Package_Name" ='''||packdes||''' and "Combin_Code"='''||pcombin_code||'''';
      end if;

    --  insert into test1(vstring,vstring2) values (pcountnum,'vquery '||vquery);commit;
      
OPEN p_accounts FOR
vquery;
      

  END;
/
-----------------------------------------------------------------------------------



CREATE OR REPLACE PROCEDURE HT18JULY.execute_packbill(
       pcompcode     in varchar2,
       padtype       in varchar2,
       ppackagecode         in varchar2,
       p_accounts  out cur_type_new1.cursor_type
      )
   As
  
  Begin
      open p_accounts for
   select * from tbl_combinPrintEdition where comp_code=pcompcode
    AND (   adtype = padtype OR padtype IS NULL)
     AND (   combin_code = ppackagecode OR ppackagecode IS NULL);

  END;
/
-------------------------------------------------------------------------------------------



CREATE OR REPLACE PROCEDURE HT18JULY.SP_combinPrintEdition(
       prctype     in varchar2,
       pack_name       in varchar2,
       flag         in varchar2,
       combin_code         in varchar2,
       package_name in varchar2,
       adtye in varchar2,
       comp_code in varchar2,
       p_accounts  out cur_type_new1.cursor_type
      )
   As
   query varchar2(4000);
  Begin
    if prctype = 'MOD_INSERT' then
	INSERT INTO tbl_combinPrintEdition (ID,pack_name,flag,combin_code,package_name,creat_date,adtype,comp_code)
    VALUES(CMBPRINTEDI.nextval,pack_name,flag,package_name,combin_code,sysdate(),adtye,comp_code);
    commit;
    open p_accounts for
    select 'A' from dual;
    END if;
    
    IF prctype = 'MOD_UPDATE' then
        query:='UPDATE tbl_combinPrintEdition SET FLAG ='''|| pack_name||''' 
        WHERE ID=CAST('''||flag||''' AS int)';
       execute immediate(query);
         COMMIT;
        --delete from test1;
        insert into test1(vstring,vstring2)values ('dik',query);
         open p_accounts for
    select 'A' from dual;
	END if;
	
	IF prctype = 'MOD_SELECT' then
     open p_accounts for
			SELECT  distinct combin_code, (rtrim(package_name)||'~'||combin_code)as package_name,adtype  FROM tbl_combinPrintEdition WHERE comp_code=comp_code;
	END if;
	
	IF prctype = 'MOD_SELECT_DISTINCT_PACKAGE_NAME' then
     open p_accounts for
			SELECT distinct package_name FROM tbl_combinPrintEdition ;
	END if;
  

  END;
/


======end 18-01-2-14===================