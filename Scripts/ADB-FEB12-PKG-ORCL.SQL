--------------------------avinash 6659 open------------

CREATE OR REPLACE FUNCTION FETCH_PACK(PCOMP_CD VARCHAR2) RETURN VARCHAR2

as
v_nm VARCHAR2(200);
v_gr varchar2(200);
v_val varchar2(2000);
v_vals varchar2(1200);

---for rate--
v_rate number(12,2);
v_type varchar2(200);
v_amt number(12,2);
v_tot number(12,2);
per_amount number(12,2);

Cursor C1 Is select pack from  multipack_rep where cioid=PCOMP_CD;

v1 C1%rowtype;
BEGIN


open C1;
loop
    fetch C1 into v1;
    exit when C1%notfound;
     begin
          if (v_val is null)
          then
          v_vals:=v1.pack;
          else
          v_vals:=v_vals || v1.pack;
          end if;
     end;
     
     
end loop;     
    
    
     
             

close C1;


return v_vals;
END;
/


----------------avinash 6659 close-------------------


--------------------------ankit 6181 open------------

CREATE OR REPLACE PACKAGE class_bindadcat3 Is



Type T_Accounts_Cursor Is Ref Cursor;
Procedure class_bindadcat3_P (adcat1 in varchar2,
compcode in varchar2,
value in varchar2,
P_Accounts Out T_Accounts_Cursor);

End class_bindadcat3;
/





CREATE OR REPLACE PACKAGE BODY class_bindadcat3 Is

Procedure class_bindadcat3_P (adcat1 in varchar2,
compcode in varchar2,
value in varchar2,
P_Accounts Out T_Accounts_Cursor) As

Begin


if value='0' then
Open P_Accounts For
   select "catname","catcode" from ad_cat3 where "compcode"=compcode and (STATUS='1' or STATUS is null) and  "subcatname"=adcat1 order by "catname";
elsif value='1' then
Open P_Accounts For
 select "Cat_Name","Cat_Code" from tbl_cat4 where "Comp_Code"=compcode and "Sub_Cat_Name"=adcat1 order by "Cat_Name";
elsif value='2' then
Open P_Accounts For
 select "Cat_Name","Cat_Code" from tbl_cat5 where "Comp_Code"=compcode and "Sub_Cat_Name"=adcat1 order by "Cat_Name";
end if;




End class_bindadcat3_P;

End class_bindadcat3;
/


--------------------------ankit 6181 end------------




--------------------------ankit representative ------------
CREATE OR REPLACE PACKAGE Representative IS
TYPE t_accounts_cursor IS REF CURSOR;
PROCEDURE representative_p(
fromdate    in varchar2,
dateto      in varchar2,
compcode    in varchar2,
pub_name    in varchar2:=null,
pub_cent    in varchar2,
dateformat  in varchar2,
descid      in varchar2:=null,
ascdesc     in varchar2:=null,
adtyp       in varchar2,
value       in varchar2,
execut      in varchar2,
team        in varchar2,
bill        in varchar2,
cl          in varchar2,
ag          in varchar2,
retainer    in varchar2,
rep         in varchar2,
puserid     in varchar2:=null,
chk_access  in varchar2:=null,
pbrancode   in varchar2,
pdistcode   in varchar2,
pextra1     in varchar2,
pextra2     in varchar2,
pextra3     in varchar2,
pextra4     in varchar2,
pextra5     in varchar2,
p_accounts  OUT t_accounts_cursor);
END Representative;
/








CREATE OR REPLACE PACKAGE BODY Representative IS
PROCEDURE representative_p(
fromdate    in varchar2,
dateto      in varchar2,
compcode    in varchar2,
pub_name    in varchar2:=null,
pub_cent    in varchar2,
dateformat  in varchar2,
descid      in varchar2:=null,
ascdesc     in varchar2:=null,
adtyp       in varchar2,
value       in varchar2,
execut      in varchar2,
team        in varchar2,
bill        in varchar2,
cl          in varchar2,
ag          in varchar2,
retainer    in varchar2,
rep         in varchar2,
puserid     in varchar2:=null,
chk_access  in varchar2:=null,
pbrancode   in varchar2,
pdistcode   in varchar2,
pextra1     in varchar2,
pextra2     in varchar2,
pextra3     in varchar2,
pextra4     in varchar2,
pextra5     in varchar2,
p_accounts  OUT t_accounts_cursor)
AS
Vquery      VARCHAR(8000);
center      VARCHAR(50);
reg         VARCHAR(900);
from_date   DATE;
date_to     DATE;
sortorder   VARCHAR(100);
Vquery1     VARCHAR(1000);

breakup     VARCHAR(8000);
breakgrp    VARCHAR(1000);

BEGIN

IF(fromdate IS NOT NULL AND dateto IS NULL ) THEN
    from_date   :=fromdate;
    date_to     :=fromdate ;
ELSIF(fromdate IS NOT NULL AND dateto IS NOT NULL ) THEN
    from_date   :=fromdate;
    date_to     :=dateto ;
END IF;

IF(descid IS NOT NULL) THEN

   sortorder:=descid ;

ELSIF(ascdesc IS NOT NULL ) THEN
    sortorder:=ascdesc ;
END IF;

------------------


--Dbms_output.put_line(Vquery1);
if(descid is null) then
    if(rep='2')then
      Vquery1 := ' ORDER BY "Retainer" asc';
    else
      Vquery1 := ' ORDER BY "Executive" asc';
    end if;
else
    Vquery1 := Vquery1||'order by "'||descid||'"';
    Vquery1 := Vquery1 || ''||ascdesc||'';
end if;

Vquery := Vquery || 'SELECT  i."Cio_Booking_Id" AS "CIOID",a."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
(select COMBIN_MAST."Package_Name" from combin_mast where COMBIN_MAST."Combin_Code"  in(m."Package_code"))AS "Package",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date" ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''yyyy/mm/dd'') END AS "Ins.date" ,
m."Key_no" AS "Key" ,
m."RO_No" AS "Ro.No.",
TO_CHAR(m."RO_Date",''dd-Mon-yyyy'') AS "Ro.Date",
NVL(i."Bill_Amt",''0'') AS "NetAmt",
(select EXEC_MAST."Exec_name" from exec_mast where  m."Executive_code"=EXEC_MAST."Exe_no") AS "Executive",
(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=i."Ad_Cat" ) as "Adcat",
(select Retainermaster."Retain_Alias" from Retainermaster where m."RETAINER"=Retainermaster."Retain_Code") as "Retainer",
DECODE( DECODE(a."Agency_Type_Code",''IA0'',''GOVT.'',''DA0'',''GOVT.''),''GOVT.'',''GOVT.'', DECODE(a."State_Code",''ORISSA'',''LOCAL'',''NATIONAL'') )  AS "FinalGRP",
i."Edition" as "edition",
(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
sysdate as "Rundate",

(select  "Branch_Name"  from branch_mst where m."branch"=  branch_mst."Branch_Code") as "Branch_Name",

(select  "Dist_Name"  from dist_mst where a."DISTRICT" =  dist_mst."Dist_Code") as "District_Name"

FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a 
WHERE m."Comp_code"='''||compcode||''' AND
m."cio_booking_id"=i."Cio_Booking_Id"
AND m."Agency_sub_code"=a."code_subcode" 
AND m."cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
and  lower(i."Insert_Status") !=''cancel''
and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'') or  ('''||chk_access||'''=''0'') )
AND  i."Insert_Date" BETWEEN '''||from_date||''' AND '''||date_to||'''
AND (m."Ad_type_code"='''||adtyp||''' OR '''||adtyp||'''  IS NULL)
AND (i."Pub_Cent_Code"='''||pub_cent||''' OR '''||pub_cent||''' IS NULL)
AND (m."Revenue_center"='''||pub_name||''' OR '''||pub_name||'''  IS NULL)
AND (m."Executive_code"  = '''||execut||''' OR '''||execut||'''  IS NULL)
AND (m."Executive_code" in (select exec_mast."Exe_no" from exec_mast where  EXEC_MAST."Team_code"  = '''||team||''' OR '''||team||''' IS NULL ) OR '''||team||''' IS NULL )
AND (m."Client_code"  = '''||cl||''' OR '''||cl||''' IS NULL)
AND (m."Agency_code"  = '''||ag||''' OR '''||ag||''' IS NULL)
AND (m.RETAINER  = '''||retainer||''' OR '''||retainer||''' IS NULL)
AND (('''||rep||'''=''2'' and m."RETAINER" is not null and m."RETAINER"!=''0'')or('''||rep||'''=''1'' and m."Executive_code" is not null and m."Executive_code" !=''0''))
AND (a.DISTRICT  = '''||pdistcode||''' OR '''||pdistcode||''' IS NULL)
AND (a."Branch_code"  = '''||pbrancode||''' OR '''||pbrancode||''' IS NULL)';


Vquery := Vquery || Vquery1;


insert into ank_search values(Vquery);

commit;
 

 OPEN p_accounts FOR Vquery;

END representative_p;
END Representative;
/


--------------------------ankit representative ------------


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@6020 kuldeep@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


ye wala



CREATE OR REPLACE PACKAGE BODY getstatuspaymode IS
PROCEDURE getstatuspaymode_p(
compcode in varchar2,
agency in varchar2,
agencysubcode in varchar2,
datecheck in varchar2,
adtype1 in varchar2,
dateformat in varchar2,
P_Accounts1  OUT  T_Accounts_cursor,P_Accounts2  OUT  T_Accounts_cursor,P_Accounts3  OUT  T_Accounts_cursor,P_Accounts4  OUT  T_Accounts_cursor,
P_Accounts5  OUT  T_Accounts_cursor,P_Accounts6  OUT  T_Accounts_cursor,P_Accounts7  OUT  T_Accounts_cursor,P_Accounts8  OUT  T_Accounts_cursor
)as
a number;
agtyp  varchar2(50);
pay1 varchar2(50);
par varchar2(8);
testcode varchar2(100);
idcou number;
cntadtype number;
V_OUTSTANDING_AMT_CRITERIA number;
begin
delete from temppay;
dbms_output.put_line('agencysub='||trim(agencysubcode));
dbms_output.put_line('compcode='||trim(compcode));
begin
select "SUB_Agency_Code","Agency_Code" into testcode,par from Agency_mast where (trim("Comp_Code")=upper(trim(compcode)) or trim("Comp_Code")=lower(trim(compcode))) and (trim("code_subcode")=upper(trim(agency)) or trim("code_subcode")=lower(trim(agency)));
--select "SUB_Agency_Code","Agency_Code" into testcode,par from Agency_mast where ("Comp_Code"=upper(trim(compcode)) or "Comp_Code"=lower(trim(compcode))) and ("code_subcode"=upper(trim(agencysubcode)) or "code_subcode"=lower(trim(agencysubcode)));
exception when no_data_found then
NULL ;
end;
dbms_output.put_line('par'||par);
dbms_output.put_line('testcode = ' ||testcode );
begin
select "Cash" into pay1 from pay_mode_mst  where (trim("Agency_Code")=upper(trim(par)) or trim("Agency_Code")=lower(trim(par))) and (trim("Agency_subcat_code")=upper(trim(testcode)) or trim("Agency_subcat_code")=lower(trim(testcode))) and (trim("Comp_Code")=upper(trim(compcode)) or trim("Comp_Code")=lower(trim(compcode)));
exception when no_data_found then
NULL ;
end;

a:=fn_SplitField(pay1,',');

insert into temppay  select Edition_Name from result;
dbms_output.put_line('par'||par);
dbms_output.put_line('testcode = ' ||testcode );
dbms_output.put_line(compcode);
--begin
--testcode :=testcode;



begin
select "Agency_Type_Code" into agtyp from agency_mast where (trim("Comp_Code")=upper(trim(compcode)) or trim("Comp_Code")=lower(trim(compcode)))
and  (trim("Agency_Code")=upper(trim(par)) or trim("Agency_Code")=lower(trim(par)))
and (trim("SUB_Agency_Code")=upper(trim(testcode)) or trim("SUB_Agency_Code")=lower(trim(testcode)));
exception when no_data_found then
NULL ;
end;

dbms_output.put_line('lata--'||agtyp);
open P_Accounts1 for
select "Agency_Type_Name" AS "agency_type_name" from agency_type_mst where (trim("Agency_Type_Code")=upper(trim(agtyp)) or trim("Agency_Type_Code")=lower(trim(agtyp))) and (trim("Comp_Code")=upper(trim(compcode)) or trim("Comp_Code")=lower(trim(compcode)));


open P_Accounts2 for
select tblstatus."Status_Name" AS "status_name" from status_detail,tblstatus where tblstatus."Status_Code"=status_detail."STATUS_NAME" and trim("agency_code")=par and trim("agency_subcat_code")=testcode and trim("comp_code")=upper(trim(compcode)) and datecheck between "FROM_DATE" and "TO_DATE";

open P_Accounts3 for
select "Credit_Days","ALERT",CREDIT_LIMIT,BOOKING_TYPE from agency_mast where "Comp_Code"=upper(trim(compcode)) and "Agency_Code"=par and "SUB_Agency_Code"=testcode;

open P_Accounts4 for
select "Rate_Group" from agency_mast where "Comp_Code"=upper(trim(compcode)) and "Agency_Code"=par and "SUB_Agency_Code"=testcode;
    begin 
        select count(*) into cntadtype from comm_details where "Agency_code"=par and "Agency_sub_code"=testcode and "Comp_code"=upper(trim(compcode)) and datecheck between "Eff_from_Date" and "Eff_Till_Date" and "ADTYPE"=adtype1;
    EXCEPTION WHEN NO_DATA_FOUND THEN
    cntadtype:=0;
    END;
    if(cntadtype>0) then
        open P_Accounts5 for
        select "Comm_Rate" as "comm_rate",agtyp as "agencytypecode" ,"Addl_Comm_Rate",nvl(ADDITIONAL_FLAG,'0') as FLAG,CASH_DISCOUNT,CASH_DISCOUNTTYPE,
        (SELECT CASH_DISCOUNT FROM PREFERRENCES WHERE "comp_code"=comm_details."Comp_code") AS CASH_DISCOUNT1,(SELECT CASH_DISCOUNTTYPE FROM PREFERRENCES WHERE "comp_code"=comm_details."Comp_code") AS CASH_DISCOUNTTYPE
         from comm_details where "Agency_code"=par and "Agency_sub_code"=testcode and "Comp_code"=upper(trim(compcode)) and datecheck between "Eff_from_Date" and "Eff_Till_Date" and "ADTYPE"=adtype1;
    else
        open P_Accounts5 for
        select "Comm_Rate" as "comm_rate",agtyp as "agencytypecode","Addl_Comm_Rate",nvl(ADDITIONAL_FLAG,'0') as FLAG,CASH_DISCOUNT,CASH_DISCOUNTTYPE,
        (SELECT CASH_DISCOUNT FROM PREFERRENCES WHERE "comp_code"=comm_details."Comp_code") AS CASH_DISCOUNT1,(SELECT CASH_DISCOUNTTYPE FROM PREFERRENCES WHERE "comp_code"=comm_details."Comp_code") AS CASH_DISCOUNTTYPE
          from comm_details where "Agency_code"=par and "Agency_sub_code"=testcode and "Comp_code"=upper(trim(compcode)) and datecheck between "Eff_from_Date" and "Eff_Till_Date" and ("ADTYPE"='0' or "ADTYPE" is null);
    end if;
           
open P_Accounts6 for

select "Payment_Mode_Name" as "payment_mode_name","Pay_Mode_Code" as "pay_mode_code" from payment_mode_mast where
    "Pay_Mode_Code" in (select "PAYNAME" from temppay) and "Comp_Code"=upper(trim(compcode)) order by "Pay_Mode_Code" desc;

--begin
  --  select  max("Receipt_no") into idcou from  Ad_tableid;
    --exception when no_data_found then NULL ;
--end;

select count(*) into idcou from Ad_tableid;
 select OUTSTANDING_AMT_CRITERIA into V_OUTSTANDING_AMT_CRITERIA from PREFERRENCES where "comp_code" =compcode;

 if(idcou>0)then
    open P_Accounts7 for
    select  max("Receipt_no") as recno from  Ad_tableid ;
    

    open P_Accounts8 for
    select adagency_outstanding(compcode,'','',agency,to_char(sysdate,dateformat),dateformat) as "outstand" ,V_OUTSTANDING_AMT_CRITERIA as "OUTSTANDING_AMT_CRITERIA"   from dual;

   -- idcou:=idcou+1;

--    update Ad_tableid set "Receipt_no"=(select nvl(max("Receipt_no"),0)+1 from ad_tableid);
    commit;
 else

    insert into Ad_tableid("Receipt_no") values(1);
    
    open P_Accounts7 for
    select  max("Receipt_no") as recno from  Ad_tableid ;

   -- select OUTSTANDING_AMT_CRITERIA into V_OUTSTANDING_AMT_CRITERIA from PREFERRENCES where "comp_code" =compcode;


    open P_Accounts8 for
    select adagency_outstanding(compcode,'','',agency,to_char(sysdate,dateformat),dateformat) as "outstand",V_OUTSTANDING_AMT_CRITERIA as "OUTSTANDING_AMT_CRITERIA"   from dual;


 end if;

end getstatuspaymode_p;
End getstatuspaymode;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@6020@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@KULDEEP 17/02/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//==============*********************Start Scripting****************==================//
CREATE OR REPLACE PROCEDURE fetchFMGrefID
(
    cioid_p     in varchar2,
   p_accounts   OUT   cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      --	select INSERTID from TBL_BOOKING_FMG_TRANS where cioid=cioid_p;
       select TBL_BOOKING_FMG_TRANS.INSERTID,"Col_Code","Height","Width","Size_Book" from tbl_booking_insert,TBL_BOOKING_FMG_TRANS 
 where tbl_booking_insert."Insert_Id"=TBL_BOOKING_FMG_TRANS.INSERTID
-- and tbl_booking_insert."Cio_Booking_Id"=TBL_BOOKING_FMG_TRANS.cioid
 and TBL_BOOKING_FMG_TRANS.cioid=cioid_p;
END;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE Procedure fmgdatabid(
comecode in varchar2,
todate in varchar2,
fromdate in varchar2,
bookingid in varchar2,
agency in varchar2,
client in varchar2,
insertid in varchar2,
p_adtye in varchar2,
extra in varchar2,
p_Accounts out Cur_Type_New1.cursor_type
)
is
a number;
 query1 varchar2(10000);
 
begin
if insertid is null then
-- query1:='select distinct tbl_booking_insert."Cio_Booking_Id",(select "Col_Name" from col_mast where "Col_Code"=tbl_booking_insert."Col_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION","Insert_Id",to_char("Insert_Date",''dd/mm/yyyy'') as "Insert_Date","Gross_Rate","Bill_Amt" from tbl_booking_insert,tbl_booking_mast where
 query1:='select distinct tbl_booking_insert."Cio_Booking_Id",tbl_booking_insert."Col_Code" as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION","Insert_Id",to_char("Insert_Date",''dd/mm/yyyy'') as "Insert_Date","Gross_Rate","Bill_Amt" from tbl_booking_insert,tbl_booking_mast where
 tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and tbl_booking_insert."Comp_Code"='''||comecode||''' and "Insert_Date" between '''||fromdate||''' and '''||todate||''' and tbl_booking_mast."Agency_sub_code"= '''||agency||''' and tbl_booking_mast."Ad_type_code"= '''||p_adtye||''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')';
 
 if(bookingid IS NOT NULL)then
 query1:=query1 || ' and tbl_booking_insert."Cio_Booking_Id"='''|| bookingid || '''';
 end if;

 if(client IS NOT NULL ) then
 query1:=query1 || ' and tbl_booking_mast."Client_code"='''|| client || '''';
  end if;
 
  query1:=query1 || ' order by "Insert_Id"';
 

 open  p_Accounts for
 query1;

else
delete from result;
a:=fn_splitfield(insertid,'~');
--query1:='select distinct tbl_booking_insert."Cio_Booking_Id",(select "Col_Name" from col_mast where "Col_Code"=tbl_booking_insert."Col_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION","Insert_Id",to_char("Insert_Date",''dd/mm/yyyy'') as "Insert_Date","Gross_Rate","Bill_Amt" from tbl_booking_insert,tbl_booking_mast where tbl_booking_insert."Comp_Code"='''||comecode||'''  and tbl_booking_mast."Agency_sub_code"= '''||agency||''' and tbl_booking_mast."Ad_type_code"= '''||p_adtye||''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')';
query1:='select distinct tbl_booking_insert."Cio_Booking_Id",tbl_booking_insert."Col_Code" as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION","Insert_Id",to_char("Insert_Date",''dd/mm/yyyy'') as "Insert_Date","Gross_Rate","Bill_Amt" from tbl_booking_insert,tbl_booking_mast where tbl_booking_insert."Comp_Code"='''||comecode||'''  and tbl_booking_mast."Agency_sub_code"= '''||agency||''' and tbl_booking_mast."Ad_type_code"= '''||p_adtye||''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')';
 query1:=query1 || ' and tbl_booking_insert."Insert_Id" in(select edition_name from result)';
  open  p_Accounts for
 query1;
end if;
 
 

end;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE Bindaudit IS
TYPE T_ACCOUNT_CURSOR IS REF CURSOR;

PROCEDURE bindaudit_p(
fromdate        IN VARCHAR2,
todate          IN VARCHAR2,
date1           IN VARCHAR2,
BRANCH1         IN VARCHAR2,
Adtype          IN VARCHAR2,
audittype       IN VARCHAR2,
branch2         IN VARCHAR2,
v_Cat           in varchar2,
v_userid        in varchar2,
comp_code       in varchar2,
v_package_code  in varchar2,
pagency_code    in varchar2,
pclient_code    in varchar2,
psection_code   in varchar2,
p_booktype      in varchar2,
extra1          in varchar2,
extra2          in varchar2,
extra3          in varchar2,
extra4          in varchar2,
P_ACCOUNT       OUT T_ACCOUNT_CURSOR);
END Bindaudit;
/

CREATE OR REPLACE PACKAGE BODY bindaudit IS
PROCEDURE bindaudit_p(
    fromdate        IN VARCHAR2,
    todate          IN VARCHAR2,
    date1           IN VARCHAR2,
    BRANCH1         IN VARCHAR2,
    Adtype          IN VARCHAR2,
    audittype       IN VARCHAR2,
    branch2         IN VARCHAR2,
    v_Cat           in varchar2,
    v_userid        in varchar2,
    comp_code       in varchar2,
    v_package_code  in varchar2,
    pagency_code    in varchar2,
    pclient_code    in varchar2,
    psection_code   in varchar2,
    p_booktype      in varchar2,--A for all ,D for Direct ,Q for Qbc Booking
    extra1          in varchar2,
    extra2          in varchar2,
    extra3          in varchar2,
    extra4          in varchar2,
    P_ACCOUNT       OUT T_ACCOUNT_CURSOR)
AS

v_branch1    varchar2(50);
v_branch2    varchar2(50);
BEGIN
    /* INSERT INTO test1(vstring)
    VALUES (   'fromdate '|| fromdate|| ' todate '|| todate|| ' date1 '|| date1|| ' BRANCH1 '|| branch1
    || ' Adtype '|| adtype|| ' audittype '|| audittype|| ' branch2 '|| branch2|| ' v_Cat '|| v_cat|| ' v_userid '|| v_userid);
    COMMIT;*/
    If branch1 = 'All' then
        v_branch1 := null; 
    End if;
    
    If branch2 = 'All' then
        v_branch2 := null;
    End if;
--"cio_booking_id", "Agency_sub_code", "Ad_type_code", "Agency_type", "Executive_code", 
--RETAINER, "Uom_code", "branch", "Client_code"
    IF audittype = 'audit' THEN
        OPEN p_account FOR
        SELECT distinct m."cio_booking_id" as "cio_booking_id",
        NVL ((SELECT distinct  "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),
        m."Client_code") AS "Client_code",
        m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",
        (SELECT distinct "File_Name" FROM tbl_booking_insert
        WHERE "Cio_Booking_Id" =m."cio_booking_id" AND "File_Name" IS NOT NULL AND ROWNUM <= 1) AS "FILENAME",
        CASE date1 WHEN 'mm/dd/yyyy' THEN TO_CHAR(m."Creation_datetime",'mm/dd/yyyy')
            WHEN 'dd/mm/yyyy' THEN TO_CHAR (m."Creation_datetime", 'dd/mm/yyyy')
            WHEN 'yyyy/mm/dd' THEN TO_CHAR (m."Creation_datetime", 'yyyy/mm/dd')
        END AS "Creation_datetime",m.ATTACHMENT1 as ATTACHMENT,
        AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'A') as "Agency_Remark",
        AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'C') as "Client_Remark"
        FROM tbl_booking_mast m,tbl_booking_insert i,branch_mst b,login_branch_mast lb
        WHERE m."cio_booking_id" =i."Cio_Booking_Id" 
        and m."Agency_sub_code"= nvl(pagency_code,m."Agency_sub_code")
        AND m."Ad_type_code" = adtype 
        AND m."branch" = nvl(v_branch2,m."branch")
        AND m."branch"= b."Branch_Code"
        and m."branch"= lb.branch_code
        and m."Client_code"= nvl(pclient_code,m."Client_code")
        and m."date_time" BETWEEN fromdate AND todate
        AND m."audit" IS NOT NULL
        AND m."Ad_cat_code" = nvl(v_cat,m."Ad_cat_code")
        AND lb.user_code = v_userid
        AND NVL (lb.user_flag, 'N') = 'Y'
        AND b."pub_center" = nvl(v_branch1,b."pub_center")
        and (i."PACKAGE_CODE"= v_package_code or v_package_code is null )
        and (i."SECTIONCODE"= psection_code or psection_code is null)
        and exists (select "userid" from login where "userid"=m."Userid" and 
        ((nvl("Agency_code",'0')<>'0' and nvl(p_booktype,'A') ='Q') or
        (nvl("Agency_code",'0')='0' and nvl(p_booktype,'A') ='D') or nvl(p_booktype,'A') ='A'))
        order by "cio_booking_id";
    END IF;

    IF audittype = 'unaudit' or audittype is null THEN
        OPEN p_account FOR
            SELECT distinct m."cio_booking_id" as "cio_booking_id",
            NVL ((SELECT distinct "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),
            m."Client_code") AS "Client_code",
            m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",
            (SELECT distinct  "File_Name" FROM tbl_booking_insert
            WHERE "Cio_Booking_Id" =m."cio_booking_id"
            AND "File_Name" IS NOT NULL
            AND ROWNUM <= 1) AS "FILENAME",
            CASE date1 WHEN 'mm/dd/yyyy' THEN TO_CHAR(m."Creation_datetime",'mm/dd/yyyy')
                WHEN 'dd/mm/yyyy' THEN TO_CHAR (m."Creation_datetime", 'dd/mm/yyyy')
                WHEN 'yyyy/mm/dd' THEN TO_CHAR (m."Creation_datetime", 'yyyy/mm/dd')
            END AS "Creation_datetime",m.ATTACHMENT1 as ATTACHMENT,
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'A') as "Agency_Remark",
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'C') as "Client_Remark"
            FROM tbl_booking_mast m,tbl_booking_insert i,branch_mst b,login_branch_mast lb
            WHERE m."cio_booking_id" =i."Cio_Booking_Id" 
            and m."Agency_sub_code"= nvl(pagency_code,m."Agency_sub_code")
            AND m."Ad_type_code" = adtype 
            AND m."branch" = nvl(v_branch2,m."branch")
            AND m."branch"= b."Branch_Code"
            and m."branch"= lb.branch_code
            and m."Client_code"= nvl(pclient_code,m."Client_code")
            and m."date_time" BETWEEN fromdate AND todate
            AND m."audit" IS NULL
            AND m."Ad_cat_code" = nvl(v_cat,m."Ad_cat_code")
            AND lb.user_code = v_userid
            AND NVL (lb.user_flag, 'N') = 'Y'
            AND b."pub_center" = nvl(v_branch1,b."pub_center")
            and (i."PACKAGE_CODE"= v_package_code or v_package_code is null )
            and (i."SECTIONCODE"= psection_code or psection_code is null)
            and nvl(m.modified_audit,'N')!='Y' and exists (select "userid" from login where "userid"=m."Userid" and 
            ((nvl("Agency_code",'0')<>'0' and nvl(p_booktype,'A') ='Q') or
            (nvl("Agency_code",'0')='0' and nvl(p_booktype,'A') ='D') or nvl(p_booktype,'A') ='A'))
            order by "cio_booking_id";
    END IF;

    IF audittype = 'modified' THEN
        OPEN p_account FOR
            SELECT distinct m."cio_booking_id" as "cio_booking_id",
            NVL ((SELECT distinct "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),
            m."Client_code") AS "Client_code",
            m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",
            (SELECT distinct  "File_Name" FROM tbl_booking_insert
            WHERE "Cio_Booking_Id" =m."cio_booking_id"
            AND "File_Name" IS NOT NULL
            AND ROWNUM <= 1) AS "FILENAME",
            CASE date1 WHEN 'mm/dd/yyyy' THEN TO_CHAR(m."Creation_datetime",'mm/dd/yyyy')
                WHEN 'dd/mm/yyyy' THEN TO_CHAR (m."Creation_datetime", 'dd/mm/yyyy')
                WHEN 'yyyy/mm/dd' THEN TO_CHAR (m."Creation_datetime", 'yyyy/mm/dd')
            END AS "Creation_datetime",m.ATTACHMENT1 as ATTACHMENT,
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'A') as "Agency_Remark",
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'C') as "Client_Remark"
            FROM tbl_booking_mast m,tbl_booking_insert i,branch_mst b,login_branch_mast lb
            WHERE m."cio_booking_id" =i."Cio_Booking_Id" 
            and m."Agency_sub_code"= nvl(pagency_code,m."Agency_sub_code")
            AND m."Ad_type_code" = adtype 
            AND m."branch" = nvl(v_branch2,m."branch")
            AND m."branch"= b."Branch_Code"
            and m."branch"= lb.branch_code
            and m."Client_code"= nvl(pclient_code,m."Client_code")
            /*and m."date_time" BETWEEN fromdate AND todate*/
            AND m."audit" IS NULL
            AND m."Ad_cat_code" = nvl(v_cat,m."Ad_cat_code")
            AND lb.user_code = v_userid
            AND NVL (lb.user_flag, 'N') = 'Y'
            AND b."pub_center" = nvl(v_branch1,b."pub_center")
            and (i."PACKAGE_CODE"= v_package_code or v_package_code is null )
            and (i."SECTIONCODE"= psection_code or psection_code is null)
            and nvl(m.modified_audit,'N')='Y' and exists (select "userid" from login where "userid"=m."Userid" and 
        ((nvl("Agency_code",'0')<>'0' and nvl(p_booktype,'A') ='Q') or
        (nvl("Agency_code",'0')='0' and nvl(p_booktype,'A') ='D') or nvl(p_booktype,'A') ='A'))
            order by "cio_booking_id";
    END IF;

   END bindaudit_p;
END bindaudit;
/

//==================================************End*********************==================//

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@KULDEEP 17/02/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


/********************mimoh 0006796***********************************************/



CREATE OR REPLACE PACKAGE pcmupdate is
procedure pcmupdate_p
(
compcode  in varchar2,
centercode in  varchar2,
centername in varchar2,
alias in  varchar2,
add1 in varchar2,
street in varchar2,
city in varchar2,
dist in varchar2,
country in  varchar2,
phone1 in varchar2,
phone2 in varchar2,
pin in varchar2,
state in varchar2,
fax in varchar2,
email in varchar2,
remarks in    varchar2,
region1 in  varchar2,
zone in varchar2,
fax1 in varchar2,
boxadd in varchar2,
printval in varchar2,
imgpath in varchar2,
cir_imgpath in varchar2,
pcompanyname in varchar2
);
end pcmupdate;
/


CREATE OR REPLACE PACKAGE BODY pcmupdate is
procedure pcmupdate_p
(
compcode  in varchar2,
centercode in  varchar2,
centername in varchar2,
alias in  varchar2,
add1 in varchar2,
street in varchar2,
city in varchar2,
dist in varchar2,
country in  varchar2,
phone1 in varchar2,
phone2 in varchar2,
pin in varchar2,
state in varchar2,
fax in varchar2,
email in varchar2,
remarks in    varchar2,
region1 in  varchar2,
zone in varchar2,
fax1 in varchar2,
boxadd in varchar2,
printval in varchar2,
imgpath in varchar2,
cir_imgpath in varchar2,
pcompanyname in varchar2
)
as
begin

 update pub_cent_mast set "Pub_Cent_name"=centername , "Pub_Cent_Alias"=alias, "Add1"=add1, "street"=street, "Country_Code"=country, "State_Code"=state, "Dist_Code"=dist, "City_Code"=city, "zip"=pin, "Phone1"=phone1, "Phone2"=phone2,"Fax"=fax, "EmailID"=email,

 "Remarks"=remarks,"Region_code"=region1,"Zone_code"=zone,"Fax1"=fax1, "BOXADDRESS"=boxadd , PRINT_CENT=printval,FILE_PATH=imgpath,CIR_FILE_PATH=cir_imgpath,CENTER_COMP_NAME=pcompanyname where "Comp_Code"=compcode  and   "Pub_cent_Code"=centercode;

 commit;


end pcmupdate_p;
end pcmupdate;
/


/*****************************************************************************************/

CREATE OR REPLACE PACKAGE pcminsert is

procedure pcminsert_p
(

compcode in varchar,
centercode in varchar2,
centername in varchar2,
alias in varchar2,
add1 in varchar2,
street in varchar2,
city in varchar2,
dist in varchar2,
country in varchar2,
phone1 in varchar2,
phone2 in varchar2,
pin in varchar2,
state in varchar2,
fax in varchar2,
email in varchar2,
remarks in varchar2,
userid in varchar2,
region1 in varchar2,
zone in varchar2,
fax1 in varchar2,
boxaddress in varchar2,
printval in varchar2,
imgpath in varchar2,
cir_imgpath in varchar2,
pcompanyname in varchar2
);
end pcminsert;
/



CREATE OR REPLACE PACKAGE BODY pcminsert is
procedure pcminsert_p
(

compcode in varchar,
centercode in varchar2,
centername in varchar2,
alias in varchar2,
add1 in varchar2,
street in varchar2,
city in varchar2,
dist in varchar2,
country in varchar2,
phone1 in varchar2,
phone2 in varchar2,
pin in varchar2,
state in varchar2,
fax in varchar2,
email in varchar2,
remarks in varchar2,
userid in varchar2,
region1 in varchar2,
zone in varchar2,
fax1 in varchar2,
boxaddress in varchar2,
printval IN VARCHAR2,
imgpath in varchar2,
cir_imgpath in varchar2,
pcompanyname in varchar2
)as

distcode  varchar2(50);
 statecode  varchar2(50);
 countrycode  varchar2(50);
begin



--select "Dist_Code"  into distcode  from dist_mst where "Dist_Name"=dist;
--select "State_Code"  into statecode from state_mst  where "State_Name"=state;
--select "Country_Code" into countrycode from count_mst  where "Country_Name"=country;

insert into pub_cent_mast("Comp_Code","Pub_cent_Code","Pub_Cent_name","Pub_Cent_Alias","Add1","street","Country_Code","State_Code","Dist_Code","City_Code","zip","Phone1","Phone2","Fax","EmailID","Pub_Cent_Status","Status_date","Remarks","UserId","Creation_Datetime","Region_code","Zone_code","Fax1","BOXADDRESS",PRINT_CENT,FILE_PATH,CIR_FILE_PATH,CENTER_COMP_NAME)

 values(compcode,centercode,centername, alias,add1,street,country, state, dist, city, pin,phone1,phone2, fax,email,'',sysdate,remarks,userid,sysdate,region1,zone,fax1,boxaddress,printval,imgpath,cir_imgpath,pcompanyname);


end  pcminsert_p;
end  pcminsert;
/
/******************************************************************************/

CREATE OR REPLACE PACKAGE pcmexe Is

Type T_Accounts_Cursor Is Ref Cursor;


Procedure pcmexe_P(
compcode in varchar2,
centcode in varchar2,
centname in varchar2,
alias in varchar2,
city in varchar2,
country in varchar2,
pcompname IN VARCHAR2,
p_Accounts Out T_Accounts_Cursor );

End pcmexe;
/

CREATE OR REPLACE PACKAGE BODY Pcmexe IS

PROCEDURE pcmexe_P(
compcode IN VARCHAR2,
centcode IN VARCHAR2,
centname IN VARCHAR2,
alias IN VARCHAR2,
city IN VARCHAR2,
country IN VARCHAR2,
pcompname IN VARCHAR2,
p_Accounts OUT T_Accounts_Cursor ) AS

BEGIN

DELETE FROM pcmdummy1; COMMIT;

--select "Comp_Code","Pub_cent_Code","Pub_Cent_name","Pub_Cent_Alias","Add1","street","Country_Code", "State_Code","Dist_Code","City_Code","zip","Phone1","Phone2","Fax","EmailID",(select "cent_status" from pcm_status where  "center_code" ="Pub_cent_Code"),sysdate,"Remarks","UserId",(select "TO_DATE" from pcm_status where "center_code"="Pub_cent_Code" ),(select "FROM_DATE" from pcm_status where "center_code"="Pub_cent_Code" ),"Creation_Datetime","Region_code" as "Region_code","Zone_code" as "Zone_code","Fax1" from pub_cent_mast
INSERT INTO pcmdummy1
SELECT "Comp_Code","Pub_cent_Code","Pub_Cent_name","Pub_Cent_Alias","Add1","street","Country_Code",
"State_Code","Dist_Code","City_Code","zip","Phone1","Phone2","Fax","EmailID","Pub_Cent_Status"
,SYSDATE,"Remarks","UserId",SYSDATE,SYSDATE,"Creation_Datetime","Region_code","Zone_code","Fax1","BOXADDRESS",PRINT_CENT,
(select "Region_Name" from region_mst where region_mst."Region_Code"=pub_cent_mast."Region_code") as "Region_Name",
(select "Zone_Name" from zone_mast where zone_mast."Zone_Code"= pub_cent_mast."Zone_code") as "Zone_Name",FILE_PATH,CIR_FILE_PATH,CENTER_COMP_NAME
FROM pub_cent_mast
WHERE "Comp_Code"=compcode AND  ("Pub_cent_Code"=centcode OR centcode IS NULL)AND
 ("Pub_Cent_name" LIKE centname||'%' OR centname IS NULL)
AND  ("Pub_Cent_Alias" LIKE alias||'%' OR alias IS NULL)
AND  ("Country_Code"=country OR country IS NULL)
AND  ("City_Code"=city OR city IS NULL)
AND  ("CENTER_COMP_NAME"=pcompname OR pcompname IS NULL)

ORDER BY "Pub_cent_Code";



DECLARE
CURSOR pcm  IS
SELECT "Pub_cent_Code" FROM pcmdummy1 ORDER BY "Pub_cent_Code";
pcm1 VARCHAR2(100);

BEGIN

OPEN pcm;
LOOP
FETCH pcm INTO pcm1;
EXIT WHEN PCM%NOTFOUND;

UPDATE pcmdummy1 SET "Pub_Cent_Status"=(SELECT "Status_Name" FROM tblstatus WHERE "Status_Code"=(SELECT "cent_status" FROM pcm_status WHERE "center_code"=pcm1 AND sysdate between "FROM_DATE" and "TO_DATE" AND ROWNUM<=1))
 WHERE "Pub_cent_Code"=pcm1;

UPDATE pcmdummy1 SET "To_date"=(SELECT  "TO_DATE" FROM pcm_status WHERE "center_code"=pcm1 AND ROWNUM<=1) WHERE "Pub_cent_Code"=pcm1;

UPDATE pcmdummy1 SET "From_date"=(SELECT  "FROM_DATE" FROM pcm_status WHERE "center_code"=pcm1 AND ROWNUM<=1) WHERE "Pub_cent_Code"=pcm1;

END  LOOP;

CLOSE pcm;

END;

OPEN p_accounts FOR
SELECT  DISTINCT * FROM pcmdummy1  ORDER BY "Pub_cent_Code";




END pcmexe_P;

END Pcmexe;
/



/********************mimoh 0006796***********************************************/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@6039@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


CREATE OR REPLACE PROCEDURE rpt_deal_detail (
   pcompcode      IN       VARCHAR2,
   padtype        IN       VARCHAR2,
   padcat         IN       VARCHAR2,
   pdeal_type     IN       VARCHAR2,
   pag_maincode   IN       VARCHAR2,
   pag_subcode    IN       VARCHAR2,
   pclient        IN       VARCHAR2,
   papproved      IN       VARCHAR2,
   ppackage       IN       VARCHAR2,
   pratecode      IN       VARCHAR2,
   pfromdt        IN       VARCHAR2,
   ptilldt        IN       VARCHAR2,
   pdate_flag     IN       VARCHAR2,
   puserid        IN       VARCHAR2,
   pdateformat    IN       VARCHAR2,
   pextra1        IN       VARCHAR2,
   pextra2        IN       VARCHAR2,
   pextra3        IN       VARCHAR2,
   pextra4        IN       VARCHAR2,
   pextra5        IN       VARCHAR2,
   pextra6        IN       VARCHAR2,
   pextra7        IN       VARCHAR2,
   pextra8        IN       VARCHAR2,
   pextra9        IN       VARCHAR2,
   pextra10       IN       VARCHAR2,
   p_accounts     OUT      cur_type_new1.cursor_type
)
AS
   v_frdt   DATE;
   v_todt   DATE;
BEGIN
   v_frdt := TO_DATE (pfromdt, '''' || pdateformat || '''');
   v_todt := TO_DATE (ptilldt, '''' || pdateformat || '''');

   OPEN p_accounts FOR
      SELECT (SELECT "Comp_Name"
                FROM comp_mst
               WHERE "Comp_Code" = m."Comp_code"
                 AND ROWNUM <= 1) AS "COMP_NAME",
             m."Deal_No" AS "DEAL_NO", m."deal_name" AS "DEAL_NAME",
             m."deal_type" AS "DEAL_TYPE",
             TO_CHAR (m."From_date", '' || pdateformat || '') AS "FROM_DATE",
             TO_CHAR (m."Till_date", '' || pdateformat || '') AS "TILL_DATE",
             m."Total_val" AS "TOTAL_VALUE", m."Total_volu" AS "TOTAL_VOLUM",
             m."Agency_code" AS "AGENCY_CODE",
             m."Sub_Agency_Code" AS "AGENCY_SUB_CODE",
             (SELECT "Agency_Name"
                FROM agency_mast
               WHERE agency_mast."Comp_Code" = m."Comp_code"
                 AND agency_mast."Agency_Code" = m."Agency_code"
                 AND agency_mast."SUB_Agency_Code" = m."Sub_Agency_Code")
                                                            AS "AGENCY_NAME",
             m."Client_code" AS "CLIENT_CODE",
             (SELECT "Cust_Name"
                FROM cust_mast
               WHERE cust_mast."Cust_Code" = m."Client_code")
                                                            AS "CLIENT_NAME",
             d."packagecode" AS "PACKAGECODE", m."Card_rate" AS "CARD_RATE",
             m."premium_code" AS "PREMIUM_CODE",
             m."Deal_rate" AS "CONTRACT_RATE", d."DISCPER" AS "DISCPER",
             d."DISCTYPE" AS "DISCTYPE", d."INSERTION" AS "INSERTION",
             d."SIZEFROM" AS "MIN_SIZE", d."SIZETO" AS "MAX_SIZE",
             d."valuefrom" AS "VALUEFROM", d."valueto" AS "VALUETO",
             d."Rate_code" AS "RATE_CODE", d."REMARKS" AS "REMARKS",
             d."approved" AS "APPROVED"
        FROM contract_mast m, contract_detail d
       WHERE m."Comp_code" = d."comp_code"
         AND m."Comp_code" = pcompcode
         AND m."Deal_No" = d."deal_code"
         AND m."deal_type" = NVL (pdeal_type, m."deal_type")
         AND m.contractdate BETWEEN v_frdt AND v_todt
         AND (d."ADTYPE" = padtype OR padtype IS NULL)
         AND (d."Advcategory" = padcat OR padcat IS NULL)
         AND (m."Agency_code" = pag_maincode OR pag_maincode IS NULL)
         AND (m."Sub_Agency_Code" = pag_subcode OR pag_subcode IS NULL)
         AND (m."Client_code" = pclient OR pclient IS NULL)
         AND (d."packagecode" = ppackage OR ppackage IS NULL)
         AND (d."approved" = papproved OR papproved IS NULL)
         AND (d."Rate_code" = pratecode OR pratecode IS NULL);
END rpt_deal_detail;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@6039@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
/*************************mimoh6797*************************/

CREATE OR REPLACE PROCEDURE ad_agency_bind_p(
    pcompcode       in  varchar2,
    pag_name        in  varchar2,
    puserid         in  varchar2,
    pdateformat     in  varchar2,
    pextra1         in  varchar2,
    pextra2         in  varchar2,
    pextra3         in  varchar2,
    pextra4         in  varchar2,
    pextra5         in  varchar2,
    p_Accounts      out cur_type_new1.cursor_type) as

begin

    open p_Accounts for
    select  distinct  "code_subcode","Agency_Name" as "agency_name","Add1",(select "City_Name" from  city_mst 
    where "Comp_Code"=pcompcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
    AS CITYNAME from Agency_mast where "Comp_Code"=pcompcode
    and ("Agency_Name" like '%'||pag_name||'%' or pag_name is null) order by "Agency_Name" ;
End ad_agency_bind_p;
/
******************************************************************



CREATE OR REPLACE PACKAGE bindclient11new IS
TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE bindclient11new_p(
compcode in varchar2,
client in varchar2,
P_Accounts  OUT  T_accounts_cursor
);
End bindclient11new;
/





CREATE OR REPLACE PACKAGE BODY bindclient11new IS
PROCEDURE bindclient11new_p(
compcode in varchar2,
client in varchar2,
P_Accounts  OUT  T_accounts_cursor
)as
begin
OPEN P_Accounts FOR

select "Cust_Code","Cust_Name" ,"Add1","City_Code" ,AD_GET_CITYNAME(compcode,"City_Code") "cityname" from cust_mast where "Comp_Code"=compcode and "Cust_Name" like '%'|| client || '%';


end bindclient11new_p;
End bindclient11new;
/


***************************************************************************

CREATE OR REPLACE procedure chkpanclientagency
(
pcompcode   in varchar2,
pbranch in varchar2,
pagency in varchar2,
ppanno in varchar2,
pextera  in varchar2,
pextera2  in varchar2,
pextera3  in varchar2,
p_accounts OUT CUR_TYPE_NEW1.cursor_type,
p_accounts1 OUT CUR_TYPE_NEW1.cursor_type
)
IS
BEGIN
OPEN p_accounts for
select "PAN_No" from agency_mast where "Comp_Code"=pcompcode and ("Branch_code"=pbranch OR pbranch IS NULL) and "Agency_Name"=pagency and "PAN_No"=ppanno;

OPEN p_accounts1 for
select "PAN_No" from cust_mast where "Comp_Code"=pcompcode and  "Cust_Name"=pagency and "PAN_No"=ppanno;




END;
/
/**********************************************************************************/
/*************booking audit***********mimoh 1march2012*************************************/



CREATE OR REPLACE PACKAGE Executebookingdispaudit
IS
  TYPE T_Accounts_Cursor IS REF CURSOR;
  PROCEDURE Executebookingdispaudit_p(
  compcode IN VARCHAR2,
  ciobookid IN VARCHAR2,
  docno IN VARCHAR2:=NULL,
  keyno IN VARCHAR2:=NULL,
  rono IN VARCHAR2:=NULL,
  agencycode IN VARCHAR2:=NULL,
  client IN VARCHAR2:=NULL,
  booking IN VARCHAR2,dateformat IN VARCHAR2,
  P_Accounts  OUT  T_Accounts_Cursor,P_Accounts1  OUT  T_Accounts_Cursor,P_Accounts2  OUT  T_Accounts_Cursor,
  P_Accounts3  OUT  T_Accounts_Cursor);
END Executebookingdispaudit ;
/





CREATE OR REPLACE PACKAGE BODY Executebookingdispaudit
IS
   PROCEDURE Executebookingdispaudit_p (
      compcode      IN       VARCHAR2,
      ciobookid     IN       VARCHAR2,
      docno         IN       VARCHAR2 := NULL,
      keyno         IN       VARCHAR2 := NULL,
      rono          IN       VARCHAR2 := NULL,
      agencycode    IN       VARCHAR2 := NULL,
      client        IN       VARCHAR2 := NULL,
      booking       IN       VARCHAR2,
      dateformat     IN          VARCHAR2,
      p_accounts    OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor,
      p_accounts2   OUT      t_accounts_cursor,
      P_Accounts3  OUT  T_Accounts_Cursor
   )
   AS
      VERSION1   NUMBER;
      count1    NUMBER;

   BEGIN

       DELETE FROM TEMPBOOKING_MAST_AUDIT;

      INSERT INTO TEMPBOOKING_MAST_AUDIT
         SELECT "date_time", "branch", "booked_by", "cio_booking_id",
                "prev_booking", "applied_by", "audit", "RO_No", "RO_Date",
                "Caption", "bill_status", "ro_status", "Agency_code",
                "Agency_address", "Client_code", "Client_address",
                "Agency_sub_code", "Dockit_no", "Executive_code",
                "Executive_zone", "Product_code", "Brand_code", "Key_no",
                "Bill_remarks", "Print_remark", "Package_code",
                "No_of_insertion", "Insertion_date", "Repeating_day",
                "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code",
                "Color_code", "Uom_code", "Page_position_code",
                "Page_type_code", "Page_no", "Ad_size_type_code",
                "Ad_size_height", 
                           
                
                
                
                nvl(TBL_BOOKING_MAST."Ad_size_column" ,TBL_BOOKING_MAST."Ad_size_width") AS "Ad_size_width"               
                
                
                , "Rate_code",
                "Scheme_type_code", "Currency_code", NVL("Agrred_rate",'0'),
                NVL("Agreed_amount",'0'), "Special_discount", "Space_discount",
                "Special_charges", "Agency_status", "Agency_type",
                "Agency_pay", "Agency_credit", "Total_area", "Card_rate",
                "Card_amount", NVL("Discount",'0'), "Discount_per", "Bill_cycle",
                "Revenue_center", "Bill_pay", "Bill_height", "Bill_width",
                "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc",
                "Agency_out", "Box_code", "Box_no", "Box_agency",
                "Box_client", "Box_address", "Comp_code", "Userid",
                "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad",
                "Campaign", "Bill_amount", "Page_prem", "Page_amount",
                "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column",
                "Bill_area", "Special_disc_per", "Space_disc_per",
                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                "Contract_name", "Contract_type", "Card_name", "Card_type",
                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                "Bullet_code", "Bullet_premium", "Material_status",
                TRUNC("Receipt_date"), "prev_cioid", "prev_receipt",
                "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H",
                "Logo_W", "Logo_color", "Logo_Uom",sapid,RETAINER,"ADD_AGENCY_COMM",
                MOBILENO,ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,
                "Bullet_code","Bullet_premium",DOCTYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM



           FROM TBL_BOOKING_MAST
          WHERE ("Comp_code" = compcode OR compcode IS NULL)
            AND ("cio_booking_id" = ciobookid OR ciobookid IS NULL
                )
            AND ("Dockit_no" = docno  OR docno IS NULL)
            AND ("Key_no" = keyno  OR keyno IS NULL)
            AND ("RO_No" = rono  OR rono IS NULL)
            AND ("Agency_sub_code" LIKE agencycode || '%'
                 OR agencycode IS NULL
                )
            AND ("Client_code" LIKE client || '%' OR client IS NULL)
        --    AND ("Ad_type_code" LIKE booking || '%' OR booking IS NULL)
            ;

      OPEN p_accounts FOR
      SELECT CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("date_time",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("date_time",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("date_time",'yyyy/mm/dd')  END AS date_time,
                     "branch","booked_by", "cio_booking_id", "prev_booking", "applied_by","audit", "RO_No",
            CASE dateformat
                 WHEN 'mm/dd/yyyy' THEN TO_CHAR("RO_Date",'mm/dd/yyyy')
                 WHEN 'dd/mm/yyyy' THEN TO_CHAR("RO_Date",'dd/mm/yyyy')
                 WHEN 'yyyy/mm/dd' THEN TO_CHAR("RO_Date",'yyyy/mm/dd')  END AS "RO_Date",
                  TO_CHAR("RO_Date", 'dd/mm/yyyy') AS "RO_Date",
                "Caption", "bill_status", "ro_status", "Agency_code",
                "Agency_address", "Client_code", "Client_address",
                "Agency_sub_code", "Dockit_no", "Executive_code",
                "Executive_zone", "Product_code", "Brand_code", "Key_no",
                "Bill_remarks", "Print_remark", "Package_code","No_of_insertion",
            CASE dateformat
                    WHEN 'mm/dd/yyyy' THEN TO_CHAR("Insertion_date",'mm/dd/yyyy')
                    WHEN 'dd/mm/yyyy' THEN TO_CHAR("Insertion_date",'dd/mm/yyyy')
                    WHEN 'yyyy/mm/dd' THEN TO_CHAR("Insertion_date",'yyyy/mm/dd')  END    AS "Insertion_date",
                "Repeating_day", "Ad_type_code", "Ad_cat_code",
                "Ad_sub_cat_code", "Color_code", "Uom_code",
                "Page_position_code", "Page_type_code", "Page_no",
                "Ad_size_type_code", "Ad_size_height", 
                
                "Ad_size_width"
                
                , "Rate_code",
                (SELECT "Scheme_Name" FROM SCHEME_MASTER WHERE "scheme_id" =TEMPBOOKING_MAST_AUDIT."Scheme_type_code")AS "Scheme_type_code",
                 "Currency_code", "Agrred_rate", "Agreed_amount",
                "Special_discount", "Space_discount", "Special_charges",
                TEMPBOOKING_MAST_AUDIT."Comp_code", TEMPBOOKING_MAST_AUDIT."Userid",
                TEMPBOOKING_MAST_AUDIT."Agency_status", "Agency_type", "Agency_pay",
                "Agency_credit", "Total_area", "Card_rate", "Card_amount",
                "Discount", "Discount_per", "Bill_cycle", "Revenue_center",
                "Bill_pay", "Bill_height", "Bill_width",
                TEMPBOOKING_MAST_AUDIT."Bill_to", "Invoices", "Vts", "Bill_add",
                "Trade_disc", "Agency_out", "Booking_type", "Campaign",
                "Page_prem", "Page_amount", "Prem_per", "Gross_amount",
                "Bill_amount", "Box_code", "Box_no", "Box_agency",
                "Box_client", "Box_address", "Tfn", "Coupan_ad",
                "Ad_size_column", "Bill_column", "Bill_area",
                "Special_disc_per", "Space_disc_per",
                AGENCY_MAST."Agency_Name" || '(' || AGENCY_MAST."code_subcode" || ')' AS "AgencyName",
                (SELECT EXEC_MAST."Exec_name" || '(' || TO_CHAR(EXEC_MAST."Exe_no") || ')' FROM EXEC_MAST
                  WHERE TEMPBOOKING_MAST_AUDIT."Executive_code" = EXEC_MAST."Exe_no"
                    AND TEMPBOOKING_MAST_AUDIT."Comp_code" = EXEC_MAST."comp_code") AS "execname",

                (SELECT  PRODUCT_CAT_MAST."prod_desc" || '(' || PRODUCT_CAT_MAST."prod_cat_code" || ')' FROM PRODUCT_CAT_MAST
                  WHERE TEMPBOOKING_MAST_AUDIT."Product_code" = PRODUCT_CAT_MAST."prod_cat_code"
                    AND TEMPBOOKING_MAST_AUDIT."Comp_code" = PRODUCT_CAT_MAST."comp_code") AS "product",

                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                "Contract_name", "Contract_type", "Card_name", "Card_type",

                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3"  , "Ad_Subcat4" , "Ad_subcat5" , "Bg_color",
                "Bullet_code", "Bullet_premium",
                (SELECT "Agency_Name" FROM AGENCY_MAST WHERE "code_subcode" =TEMPBOOKING_MAST_AUDIT."Agency_sub_code") AS "AgencySubCode",

                NVL ((SELECT "Cust_Name"||'('||"Cust_Code"||')' FROM CUST_MAST WHERE "Cust_Code" = "Client_code"), "Client_code") AS "Client",                                       --112
                (SELECT DISTINCT "Payment_Mode_Name" FROM PAYMENT_MODE_MAST WHERE "Comp_Code"=compcode and "Pay_Mode_Code" = "Agency_pay") AS "PayMode",
                (SELECT "Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code" =TEMPBOOKING_MAST_AUDIT."Ad_cat_code") AS "categoryname",
                
                (SELECT "Adv_Subcat_Name" FROM ADV_SUBCAT_MAST  WHERE ADV_SUBCAT_MAST."Adv_Cat_Code"=TEMPBOOKING_MAST_AUDIT."Ad_cat_code" AND ADV_SUBCAT_MAST."Adv_Subcat_Code" =TEMPBOOKING_MAST_AUDIT."Ad_sub_cat_code")
                 AS "subcategoryname",
                 
                (SELECT "brand_name" FROM BRAND_MST WHERE "brand_code" =TEMPBOOKING_MAST_AUDIT."Brand_code") AS "Brand",
                (SELECT "Uom_Name" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST_AUDIT."Uom_code") AS "UOM",
                (SELECT "premiumname" FROM ADVPOS_PREM_MAST WHERE "Premiumcode" =TEMPBOOKING_MAST_AUDIT."Page_prem") AS "PagePremium",
                 (SELECT "Pos_Type" FROM ADVPOS_TYPE_MAST
                  WHERE "Pos_Type_Code" = TEMPBOOKING_MAST_AUDIT."Page_position_code") AS "PositionPremium",
                (SELECT "Curr_Name" FROM CURR_MAST WHERE "Curr_Code" = TEMPBOOKING_MAST_AUDIT."Currency_code") AS "Currency",
                "Material_status", TO_CHAR("Receipt_date",'dd/mm/yyyy') AS "Receipt_date", TEMPBOOKING_MAST_AUDIT."Region",
                "Variant", "Colortype",
                (SELECT "UOM_DESC" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST_AUDIT."Uom_code") AS "uom_desc",
                (SELECT "Logo" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST_AUDIT."Uom_code") AS "logo","Logo_H", "Logo_W", "Logo_color", "Logo_Uom",
                (SELECT "Logo_Uom" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST_AUDIT."Uom_code")  AS "logocode",
                (SELECT "Box_Charges_Native" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING_MAST_AUDIT."Box_code") AS "boxchrg",TEMPBOOKING_MAST_AUDIT.sapid,
                retainer,(SELECT "Retain_Name"||'('||"Retain_Code"||')' FROM RETAINERMASTER WHERE RETAINERMASTER."Retain_Code"=TEMPBOOKING_MAST_AUDIT.RETAINER) AS "RETAINER1",
                (SELECT "Package_Name" FROM combin_mast WHERE "Combin_Code" =

                TEMPBOOKING_MAST_AUDIT."Package_code") as "Package_cod",(SELECT "Col_Name" FROM col_mast WHERE "Col_Code" = TEMPBOOKING_MAST_AUDIT."Color_code") as

                "Color_cod",(SELECT "Pos_Type" FROM advpos_type_mast WHERE "Pos_Type_Code" =

                TEMPBOOKING_MAST_AUDIT."Page_position_code") as "Page_position_cod",
                decode(TEMPBOOKING_MAST_AUDIT."Booking_type",'1','BARTER','2','FMG','3','NORMAL','4','INHOUSE') as "Book_type",
                (SELECT "catname"  FROM  AD_CAT3   WHERE

                AD_CAT3."catcode"=TEMPBOOKING_MAST_AUDIT."Ad_Subcat3")   as "SUBCAT3",(SELECT "Cat_Name"  FROM  TBL_CAT4   WHERE

                TBL_CAT4."Cat_Code"=TEMPBOOKING_MAST_AUDIT."Ad_Subcat4") as "SUBCAT4"  ,(SELECT "Cat_Name"  FROM  TBL_CAT5   WHERE

                TBL_CAT5."Cat_Code"=TEMPBOOKING_MAST_AUDIT."Ad_subcat5") as "SUBCAT5",(SELECT "Comm_Rate" FROM ret_comm_details WHERE

                ret_comm_details."Retain_Code"=TEMPBOOKING_MAST_AUDIT.RETAINER and rowid=(select max(rowid) from ret_comm_details where ret_comm_details."Retain_Code"=TEMPBOOKING_MAST_AUDIT.RETAINER)) AS "RETAINER_COMM",(select AUDIT_COMMENT from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=TEMPBOOKING_MAST_AUDIT."cio_booking_id") as "remarks","ADD_AGENCY_COMM",
                (SELECT "Box_Charges_Type" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING_MAST_AUDIT."Box_code") AS "boxchargetype",
                (SELECT "Box_Name" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING_MAST_AUDIT."Box_code") AS "boxname",
                ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,

                (select "Bullet_Desc" from  bullet_mast where bullet_mast ."Bullet_Code"=TEMPBOOKING_MAST_AUDIT  ."BULLET_DESP") as "Bullet_Desc",
                TEMPBOOKING_MAST_AUDIT."Bullet_premium",(select RO_COMMENT from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=TEMPBOOKING_MAST_AUDIT."cio_booking_id") as "RO_COMMENT"
                ,DOCTYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,
                (SELECT "Box_Charges_Native" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING_MAST_AUDIT."Box_code") AS "boxcharge"
                FROM TEMPBOOKING_MAST_AUDIT, AGENCY_MAST
                WHERE AGENCY_MAST."code_subcode" =TEMPBOOKING_MAST_AUDIT."Agency_sub_code"
                AND AGENCY_MAST."Comp_Code" = compcode ORDER BY "Creation_datetime";


      Dbms_output.put_line('rinki--');
----------------------------------------------------Lata------------------------------------------------------

      OPEN p_accounts1 FOR
         SELECT NVL(COUNT (*),'0') AS "count"
                     FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" = ciobookid AND "audit" IS NOT NULL;

      BEGIN
         SELECT MAX (VSEQNO) INTO VERSION1 FROM TBL_BOOKING_MAST_LOG
          WHERE "Receipt_no" = ciobookid AND VSEQNO < (SELECT MAX (VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" = ciobookid);
            EXCEPTION WHEN NO_DATA_FOUND THEN NULL;
      END;

      OPEN p_accounts2 FOR
         SELECT    CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("date_time",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("date_time",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("date_time",'yyyy/mm/dd')  END AS "date_time",
                 "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by","audit", "RO_No",
               CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("RO_Date",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("RO_Date",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("RO_Date",'yyyy/mm/dd')  END AS "RO_Date",
                "Caption","bill_status", "ro_status",
                TBL_BOOKING_MAST_LOG."Agency_code", "Agency_address",
                "Client_code", "Client_address", "Agency_sub_code",
                "Dockit_no", "Executive_code", "Executive_zone",
                "Product_code", "Brand_code", "Key_no", "Bill_remarks",
                "Print_remark", "Package_code", "No_of_insertion",
            CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("Insertion_date",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("Insertion_date",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("Insertion_date",'yyyy/mm/dd')  END AS "Insertion_date",

                "Repeating_day", "Ad_type_code", "Ad_cat_code",
                "Ad_sub_cat_code", "Color_code", "Uom_code",
                "Page_position_code", "Page_type_code", "Page_no",
                "Ad_size_type_code", "Ad_size_height", "Ad_size_width",
                "Rate_code", "Scheme_type_code", "Currency_code",
                "Agrred_rate", "Agreed_amount", "Special_discount",
                "Space_discount", "Special_charges",
                TBL_BOOKING_MAST_LOG."Comp_code",
                TBL_BOOKING_MAST_LOG."Userid",
                TBL_BOOKING_MAST_LOG."Agency_status", "Agency_type",
                "Agency_pay", "Agency_credit", "Total_area", "Card_rate",
                "Card_amount", "Discount", "Discount_per", "Bill_cycle",
                "Revenue_center", "Bill_pay", "Bill_height", "Bill_width",
                TBL_BOOKING_MAST_LOG."Bill_to", "Invoices", "Vts",
                "Bill_add", "Trade_disc", "Agency_out", "Booking_type",
                "Campaign", "Page_prem", "Page_amount", "Prem_per",
                "Gross_amount", "Bill_amount", "Box_code", "Box_no",
                "Box_agency", "Box_client", "Box_address", "Tfn" "Coupan_ad",
                "Ad_size_column", "Bill_column", "Bill_area",
                "Special_disc_per", "Space_disc_per",
                  AGENCY_MAST."Agency_Name"|| '('|| AGENCY_MAST."code_subcode"|| ')' AS "AgencyName",
                   (SELECT    EXEC_MAST."Exec_name" || '('|| TO_CHAR (EXEC_MAST."Exe_no") || ')'
                   FROM EXEC_MAST  WHERE TBL_BOOKING_MAST_LOG."Executive_code" =EXEC_MAST."Exe_no"
                    AND TBL_BOOKING_MAST_LOG."Comp_code" =EXEC_MAST."comp_code")AS "execname",
               (SELECT    PRODUCT_CAT_MAST."prod_desc"|| '('|| PRODUCT_CAT_MAST."prod_cat_code" || ')'
                   FROM PRODUCT_CAT_MAST WHERE TBL_BOOKING_MAST_LOG."Product_code" =PRODUCT_CAT_MAST."prod_cat_code"
                    AND TBL_BOOKING_MAST_LOG."Comp_code" =PRODUCT_CAT_MAST."comp_code")                                                                 AS "product",
                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                "Contract_name", "Contract_type", "Card_name", "Card_type",
                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                (SELECT "Agency_Name" FROM AGENCY_MAST WHERE "code_subcode" = TBL_BOOKING_MAST_LOG."Agency_sub_code")AS "AgencySubCode",
               NVL ((SELECT "Cust_Name"  FROM CUST_MAST WHERE "Cust_Code" = "Client_code"),'' ) AS "Client",
              (SELECT distinct "Payment_Mode_Name"  FROM PAYMENT_MODE_MAST WHERE "Comp_Code"=compcode and "Pay_Mode_Code" = "Agency_pay") AS "PayMode",
               (SELECT "Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code" =TBL_BOOKING_MAST_LOG."Ad_cat_code")AS "categoryname",
               (SELECT "Adv_Subcat_Name"  FROM ADV_SUBCAT_MAST WHERE ADV_SUBCAT_MAST."Adv_Subcat_Code" =TBL_BOOKING_MAST_LOG."Ad_sub_cat_code")
                 AS "subcategoryname",
               (SELECT "brand_name"  FROM BRAND_MST   WHERE "brand_code" = TBL_BOOKING_MAST_LOG."Brand_code")AS "Brand",
               (SELECT "Uom_Name" FROM UOM_MAST WHERE "Uom_Code" =TBL_BOOKING_MAST_LOG."Uom_code")AS "UOM",
               (SELECT "premiumname" FROM ADVPOS_PREM_MAST WHERE "Premiumcode" =TBL_BOOKING_MAST_LOG."Page_type_code")AS "PagePremium",
                (SELECT "Pos_Type" FROM ADVPOS_TYPE_MAST WHERE "Pos_Type_Code" =TBL_BOOKING_MAST_LOG."Page_position_code")AS "PositionPremium",
               (SELECT "Curr_Name"  FROM CURR_MAST WHERE "Curr_Code" =TBL_BOOKING_MAST_LOG."Currency_code") AS "Currency"
           FROM TBL_BOOKING_MAST_LOG, AGENCY_MAST
             WHERE TBL_BOOKING_MAST_LOG."Receipt_no" = ciobookid
            AND VSEQNO = VERSION1
            AND AGENCY_MAST."code_subcode" =
                                    TBL_BOOKING_MAST_LOG."Agency_sub_code"
            AND AGENCY_MAST."Comp_Code" = compcode;

      OPEN p_accounts3 FOR

         SELECT    CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("date_time",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("date_time",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("date_time",'yyyy/mm/dd')  END AS "date_time",
                   "branch","booked_by", "cio_booking_id", "prev_booking", "applied_by","audit", "RO_No",
              CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("RO_Date",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("RO_Date",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("RO_Date",'yyyy/mm/dd')  END AS "RO_Date",
                "Caption","bill_status", "ro_status",
                TBL_BOOKING_MAST_LOG."Agency_code", "Agency_address",
                "Client_code", "Client_address", "Agency_sub_code",
                "Dockit_no", "Executive_code", "Executive_zone",
                "Product_code", "Brand_code", "Key_no", "Bill_remarks",
                "Print_remark", "Package_code", "No_of_insertion",
            CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("Insertion_date",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("Insertion_date",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("Insertion_date",'yyyy/mm/dd')  END AS "Insertion_date",
                "Repeating_day", "Ad_type_code", "Ad_cat_code",
                "Ad_sub_cat_code", "Color_code", "Uom_code",
                "Page_position_code", "Page_type_code", "Page_no",
                "Ad_size_type_code", "Ad_size_height", "Ad_size_width",
                "Rate_code", "Scheme_type_code", "Currency_code",
                "Agrred_rate", "Agreed_amount", "Special_discount",
                "Space_discount", "Special_charges",
                TBL_BOOKING_MAST_LOG."Comp_code",
                TBL_BOOKING_MAST_LOG."Userid",
                TBL_BOOKING_MAST_LOG."Agency_status", "Agency_type",
                "Agency_pay", "Agency_credit", "Total_area", "Card_rate",
                "Card_amount", "Discount", "Discount_per", "Bill_cycle",
                "Revenue_center", "Bill_pay", "Bill_height", "Bill_width",
                TBL_BOOKING_MAST_LOG."Bill_to", "Invoices", "Vts",
                "Bill_add", "Trade_disc", "Agency_out", "Booking_type",
                "Campaign", "Page_prem", "Page_amount", "Prem_per",
                "Gross_amount", "Bill_amount", "Box_code", "Box_no",
                "Box_agency", "Box_client", "Box_address", "Tfn", "Coupan_ad",
                "Ad_size_column", "Bill_column", "Bill_area",
                "Special_disc_per", "Space_disc_per",
                 AGENCY_MAST."Agency_Name" || '('|| AGENCY_MAST."code_subcode"|| ')' AS "AgencyName",
                (SELECT    EXEC_MAST."Exec_name" || '('|| TO_CHAR (EXEC_MAST."Exe_no")|| ')'
                   FROM EXEC_MAST  WHERE TBL_BOOKING_MAST_LOG."Executive_code" = EXEC_MAST."Exe_no"
                    AND TBL_BOOKING_MAST_LOG."Comp_code" = EXEC_MAST."comp_code")AS "execname",
                (SELECT    PRODUCT_CAT_MAST."prod_desc" || '(' || PRODUCT_CAT_MAST."prod_cat_code" || ')'
                   FROM PRODUCT_CAT_MAST WHERE TBL_BOOKING_MAST_LOG."Product_code" =PRODUCT_CAT_MAST."prod_cat_code"
                    AND TBL_BOOKING_MAST_LOG."Comp_code" =PRODUCT_CAT_MAST."comp_code")AS "product",
                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                "Contract_name", "Contract_type", "Card_name", "Card_type",
                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                "Bullet_code", "Bullet_premium",
                (SELECT "Agency_Name" FROM AGENCY_MAST WHERE "code_subcode" =TBL_BOOKING_MAST_LOG."Agency_sub_code")AS "AgencySubCode",
                NVL ((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code" = "Client_code"),'' ) AS "Client",
                (SELECT distinct "Payment_Mode_Name" FROM PAYMENT_MODE_MAST WHERE "Comp_Code"=compcode and "Pay_Mode_Code" = "Agency_pay") AS "PayMode",
                (SELECT "Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code" =TBL_BOOKING_MAST_LOG."Ad_cat_code")AS "categoryname",
                (SELECT "Adv_Subcat_Name" FROM ADV_SUBCAT_MAST WHERE ADV_SUBCAT_MAST."Adv_Subcat_Code" =TBL_BOOKING_MAST_LOG."Ad_sub_cat_code")AS "subcategoryname",
                (SELECT "brand_name" FROM BRAND_MST WHERE "brand_code" =TBL_BOOKING_MAST_LOG."Brand_code")AS "Brand",
                (SELECT "Uom_Name" FROM UOM_MAST WHERE "Uom_Code" =TBL_BOOKING_MAST_LOG."Uom_code")AS "UOM",
                (SELECT "premiumname" FROM ADVPOS_PREM_MAST  WHERE "Premiumcode" =TBL_BOOKING_MAST_LOG."Page_type_code")AS "PagePremium",
                (SELECT "Pos_Type" FROM ADVPOS_TYPE_MAST WHERE "Pos_Type_Code" = TBL_BOOKING_MAST_LOG."Page_position_code")AS "PositionPremium",
                (SELECT "Curr_Name" FROM CURR_MAST WHERE "Curr_Code" =TBL_BOOKING_MAST_LOG."Currency_code")AS "Currency"
           FROM TBL_BOOKING_MAST_LOG, AGENCY_MAST
          WHERE TBL_BOOKING_MAST_LOG."Receipt_no" = ciobookid
            AND VSEQNO =(SELECT MAX (VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" = ciobookid AND VSEQNO <
            (SELECT MAX(VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" = ciobookid) AND "audit" IS NOT NULL)
                        AND AGENCY_MAST."code_subcode" =
             TBL_BOOKING_MAST_LOG."Agency_sub_code" AND AGENCY_MAST."Comp_Code" = compcode;


   END Executebookingdispaudit_p;
END Executebookingdispaudit;
/


/*************booking audit***********mimoh 1march2012*************************************/

