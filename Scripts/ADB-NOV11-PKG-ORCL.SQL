//////////////////////issue no-4797/////////////////
CREATE OR REPLACE PROCEDURE HT18JULY.report
(
agname IN VARCHAR2:=NULL,
clientname IN VARCHAR2:=NULL,
adtype IN VARCHAR2,
adcategory IN VARCHAR2,
fromdate IN VARCHAR2,
dateto IN VARCHAR2,
compcode IN VARCHAR2,
pub_name IN VARCHAR2,
pub_cent IN VARCHAR2,
status IN VARCHAR2:=null,
edition IN VARCHAR2,
dateformat IN VARCHAR2,
hold IN VARCHAR2:=null,
descid IN VARCHAR2:=null,
ascdesc IN VARCHAR2:=null,
p_report OUT Cur_Type_New1.cursor_type

)
IS
 str   varchar2(3000);
 center   varchar2(50);



 BEGIN
str:='
select TBL_BOOKING_MAST."cio_booking_id" as "CIOID",AGENCY_MAST."Agency_Name" as "Agency",
nvl((select "Cust_Name" from CUST_MAST where "Cust_Code"="Client_code"),"Client_code")  as "Client",
PUB_CENT_MAST."Pub_Cent_name" as "City",
PUB_MAST."Pub_Name" as "Pub",COMBIN_MAST."Combin_Desc" as "Package","Ad_size_height" as "Depth",
"Ad_size_width" as "Width",TBL_BOOKING_MAST."Total_area" as "Area", COL_MAST."Col_Alias" as "Hue",
(select ADVPOS_TYPE_MAST."Pos_Type_Alias" from ADVPOS_TYPE_MAST where TBL_BOOKING_INSERT."Page_Post"=ADVPOS_TYPE_MAST."Pos_Type_Code") as "Page",
"No_Insert" as "Ins.No.",
 
   TO_CHAR(tbl_booking_insert."Insert_Date" ,'''||dateformat||''')  
 as "Ins.date" ,

 
  TO_CHAR(TBL_BOOKING_MAST."date_time" ,'''||dateformat||''')  
 as "BookDate"
  
  ,"RO_No" as "RoNo.",
case "ro_status"
when ''1'' then ''Reservation''
when ''2'' then ''Confirm''
end as "RoStatus",
 ADV_TYPE_MAST."Adv_Type_Name" as "AdType" 
,"Rate_code" as "RateCode",TBL_BOOKING_INSERT."Card_Rate" as "CardRate",
nvl(TBL_BOOKING_MAST."Card_amount",TBL_BOOKING_MAST."Gross_amount") as "Amt",
TBL_BOOKING_INSERT."Disc_Rate" as "Disc",  TBL_BOOKING_INSERT."Insert_Status" as "Status",TBL_BOOKING_INSERT."Status_Material" as "MatStatus","Caption" as "Cap","Key_no" as "Key","Agreed_Rate" as "AgreedRate",(select  AGENCY_MAST."SUB_Agency_Code" from agency_mast where  AGENCY_MAST."Type" <> ''P'' and TBL_BOOKING_MAST."Agency_code"=AGENCY_MAST."code_subcode" )as "SubAg",(select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where ADV_CAT_MAST."Adv_Cat_Code"=TBL_BOOKING_MAST."Ad_cat_code") as "AdCat",SAPID

from TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,PUB_MAST,PUB_CENT_MAST,ADV_TYPE_MAST ,COMBIN_MAST, COL_MAST 
 where TBL_BOOKING_MAST."Comp_code"='''||compcode||''' and TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
 and TBL_BOOKING_MAST."Agency_code"=AGENCY_MAST."Agency_Code" and TBL_BOOKING_MAST."Ad_type_code"=ADV_TYPE_MAST ."Adv_Type_Code"
 and tbl_booking_mast."Color_code"=col_mast."Col_Code"  and 
TBL_BOOKING_MAST."Package_code"=COMBIN_MAST."Combin_Code" and TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" and TBL_BOOKING_INSERT."Publication_Code" = PUB_MAST."Pub_Code" and TBL_BOOKING_INSERT."Pub_Cent_Code"=PUB_CENT_MAST."Pub_cent_Code"  ';

--select adv_cat_mast.adv_cat_name from adv_cat_mast where ADV_CAT_MAST.adv_cat_code=TBL_BOOKING_MAST.ad_cat_code



IF(hold IS NOT NULL)
THEN
str:=str||' and TBL_BOOKING_INSERT."insert_status"!=''Cancel''';
END IF;

IF(agname IS NOT NULL)
THEN
str:=str||' and TBL_BOOKING_MAST."agency_code" ='''||agname ||'''';
END IF;

IF(clientname IS NOT NULL)
THEN
str:=str||' and TBL_BOOKING_MAST."client_code" ='''||clientname ||'''';
END IF;
if(status IS NOT NULL)
THEN
str:=str||' and TBL_BOOKING_INSERT."insert_status"  ='''||status||'''';
END IF;


IF(adtype IS NOT NULL)
THEN

str:=str|| 'and TBL_BOOKING_MAST."ad_type_code" ='''||adtype||'''';
END IF;

IF(adcategory IS NOT NULL)
THEN
str:=str||' and TBL_BOOKING_MAST."ad_cat_code" in('''||adcategory||''' )';
END IF;


--if(@pub_cent<>null )
--begin
--select @center=substring(pub_cent_alias,1,3) from pub_cent_mast where pub_cent_code=@pub_cent

--print(@center)
--set @str=@str+'  and tbl_booking_insert.pub_cent_code='''+ @center +''''
--print(@str)
--end
IF(pub_cent IS NOT NULL)
THEN
str:=str||'  and tbl_booking_insert."pub_cent_code" ='''||pub_cent||'''';
END IF;




IF(fromdate IS NOT NULL AND dateto IS NULL )
THEN
str:=str||' and tbl_booking_insert."Insert_Date" ='''||fromdate ||'''';

END IF;


IF(fromdate IS NOT NULL AND dateto IS NULL )
THEN
str:=str||' and tbl_booking_insert."Insert_Date" between  '''||fromdate ||''' and  '''||dateto ||''' ';
END IF;

IF(edition IS NOT NULL)
THEN
str:=str||'  and tbl_booking_insert."edition_code"='''|| edition ||'''';
END IF;

IF(pub_name IS NOT NULL)
THEN
str:=str||' and  TBL_BOOKING_INSERT."publication_code"='''||pub_name ||'''';
END IF;

 
 
IF(descid IS NOT  NULL)
THEN
str:=str||'  order by "'||descid||'"';
str:=str||''||ascdesc||'';

END IF;


delete from searchtbl;
insert into searchtbl values('pk'||str);
commit;
OPEN p_report FOR str;

END;
/

//////////////end of issue////////////////////////////////



//////////////////5410//////////////mimoh 1nov 2011//////////////////start///////////////////////

DROP PROCEDURE GETPERIODDATE_EDITION;

CREATE OR REPLACE PROCEDURE HT18JULY.getperiodDate_Edition(Compcode In Varchar2,
pkgname In Varchar2,
dateday In date,P_Accounts OUT Cur_Type_New1.cursor_type)
 is
VCODE varchar2(10);
day_p NUMBER;
month_p NUMBER;
fcycle_p NUMBER;
scycle_p NUMBER;
    BEGIN
        begin
        select "ValidationCode" into VCODE from PREODICITY_MASTER where "Comp_Code"=Compcode and "Preodicity_Code"=(select "Preodicity_Code" from edition_mast where "Comp_Code"=Compcode and ltrim(rtrim("Edition_Alias"))=ltrim(rtrim(pkgname)));
            EXCEPTION
                           WHEN NO_DATA_FOUND THEN  NULL;
                         END;
select to_char(dateday,'dd') into  day_p from dual;     
select to_char(dateday,'mm') into  month_p from dual;   
IF VCODE ='2' OR VCODE = '3' OR VCODE = '4' OR VCODE = '6' OR VCODE = '7'  THEN      
    select "Date_Edition","AdditionalDate_Edit" INTO fcycle_p,scycle_p from edit_date  WHERE "Comp_Code"=Compcode and ltrim(rtrim("Edition_Alias"))= ltrim(rtrim(pkgname));
    -- VCODE = 6 BI-MONTHLY AND VCODE = 7 QUARTLY     
    IF VCODE  = 2 THEN -- MONTHLY
        IF fcycle_p = day_p THEN
            OPEN P_Accounts FOR
            SELECT '0' as MESSAGE FROM DUAL;
        ELSE
            OPEN P_Accounts FOR
            SELECT 'NOT A VALID DATE' AS MESSAGE FROM DUAL;    
        END IF;
    ELSIF VCODE  = 6   THEN -- BI-MONTHLY
        IF fcycle_p = day_p AND (scycle_p = month_p or to_char(add_months(to_date(scycle_p || '/' || fcycle_p || '/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),2),'mm')=month_p or to_char(add_months(to_date(scycle_p || '/' || fcycle_p ||'/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),4),'mm')=month_p or to_char(add_months(to_date(scycle_p || '/' || fcycle_p || '/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),6),'mm')=month_p or to_char(add_months(to_date(scycle_p || '/' || fcycle_p || '/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),8),'mm')=month_p or to_char(add_months(to_date(scycle_p || '/' || fcycle_p || '/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),10),'mm')=month_p) THEN
            OPEN P_Accounts FOR
            SELECT '0' as MESSAGE FROM DUAL;
        ELSE
            OPEN P_Accounts FOR
            SELECT 'NOT A VALID DATE' AS MESSAGE FROM DUAL;    
        END IF;
    ELSIF VCODE  = 7   THEN -- QUARTLY
        IF fcycle_p = day_p AND (scycle_p = month_p or to_char(add_months(to_date(scycle_p || '/' || fcycle_p || '/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),3),'mm')=month_p or to_char(add_months(to_date(scycle_p || '/' || fcycle_p ||'/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),6),'mm')=month_p or to_char(add_months(to_date(scycle_p || '/' || fcycle_p || '/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),9),'mm')=month_p ) THEN
            OPEN P_Accounts FOR
            SELECT '0' as MESSAGE FROM DUAL;
        ELSE
            OPEN P_Accounts FOR
            SELECT 'NOT A VALID DATE' AS MESSAGE FROM DUAL;    
        END IF;             
    ELSIF VCODE = 3 THEN --YEARLY
         IF fcycle_p = day_p  AND scycle_p = month_p THEN
            OPEN P_Accounts FOR
            SELECT '0' AS MESSAGE  FROM DUAL;
        ELSE
            OPEN P_Accounts FOR
            SELECT 'NOT A VALID DATE' AS MESSAGE  FROM DUAL;    
        END IF;
    ELSIF VCODE = 4 THEN --FORTNIGHTLY
         IF fcycle_p = day_p  OR scycle_p = month_p THEN
            OPEN P_Accounts FOR
            SELECT '0' AS MESSAGE  FROM DUAL;
        ELSE
            OPEN P_Accounts FOR
            SELECT 'NOT A VALID DATE' AS MESSAGE  FROM DUAL;    
        END IF;
    ELSE
    OPEN P_Accounts FOR
    SELECT '0' AS MESSAGE  FROM DUAL;
    END IF;   
else 
     OPEN P_Accounts FOR
    SELECT '0' AS MESSAGE  FROM DUAL;
   
END IF;                   
END ;
/

/*************************************************************************************************/
DROP PACKAGE QBC_GETINSERTION;

CREATE OR REPLACE PACKAGE qbc_getinsertion IS
TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE qbc_getinsertion_p(
package1 in varchar2,
noofinsertion in varchar2,
insertiondate in varchar2,
startdate in date,
dateformat in varchar2,
compcode in varchar2,
pck in number,
uom in varchar2,
dealrate in number,
adcategory in varchar2,
adsubcat1 in varchar2,
color in varchar2,
adtype1 in varchar2,
currency in varchar2,
ratecode11 in varchar2,
clickdate in varchar2,
flag in number,
code in varchar2,
checkforor in varchar2,
classinserts in varchar2,
lines in varchar2,
adcat3 in varchar2,
adcat4 in varchar2,
adcat5 in varchar2,
clientcode in varchar2,
user_id in varchar2,
center in varchar2,
P_Accounts  OUT  T_Accounts_Cursor,
P_Accounts1  OUT  T_Accounts_Cursor,
P_Accounts2  OUT  T_Accounts_Cursor,
P_Accounts3  OUT  T_Accounts_Cursor,
P_Accounts4  OUT  T_Accounts_Cursor,
P_Accounts5  OUT  T_Accounts_Cursor,
P_Accounts6  OUT  T_Accounts_Cursor,
P_Accounts7  OUT  T_Accounts_Cursor,
P_Accounts8  OUT  T_Accounts_Cursor,
P_Accounts9  OUT  T_Accounts_Cursor,
P_Accounts10  OUT  T_Accounts_Cursor,
P_Accounts11  OUT  T_Accounts_Cursor,
P_Accounts12  OUT  T_Accounts_Cursor
);
end qbc_getinsertion ;
/



DROP PACKAGE BODY QBC_GETINSERTION;

CREATE OR REPLACE PACKAGE BODY Qbc_Getinsertion IS
PROCEDURE qbc_getinsertion_p(
PACKAGE1 IN VARCHAR2,
noofinsertion IN VARCHAR2,
insertiondate IN VARCHAR2,
startdate IN DATE,
dateformat IN VARCHAR2,
compcode IN VARCHAR2,
pck IN NUMBER,
uom IN VARCHAR2,
dealrate IN NUMBER,
Adcategory IN VARCHAR2,
adsubcat1 IN VARCHAR2,
color IN VARCHAR2,
adtype1 IN VARCHAR2,
currency IN VARCHAR2,
ratecode11 IN VARCHAR2,
clickdate IN VARCHAR2,
flag IN NUMBER,
code IN VARCHAR2,
checkforor IN VARCHAR2,
classinserts IN VARCHAR2,
lines IN VARCHAR2,
adcat3 IN VARCHAR2,
adcat4 IN VARCHAR2,
adcat5 IN VARCHAR2,
clientcode IN VARCHAR2,
user_id IN VARCHAR2,
center IN VARCHAR2,
P_Accounts  OUT  T_Accounts_Cursor,
P_Accounts1  OUT  T_Accounts_Cursor,
P_Accounts2  OUT  T_Accounts_Cursor,
P_Accounts3  OUT  T_Accounts_Cursor,
P_Accounts4  OUT  T_Accounts_Cursor,
P_Accounts5  OUT  T_Accounts_Cursor,
P_Accounts6  OUT  T_Accounts_Cursor,
P_Accounts7  OUT  T_Accounts_Cursor,
P_Accounts8  OUT  T_Accounts_Cursor,
P_Accounts9  OUT  T_Accounts_Cursor,
P_Accounts10  OUT  T_Accounts_Cursor,
P_Accounts11  OUT  T_Accounts_Cursor,
P_Accounts12  OUT  T_Accounts_Cursor
)AS
 packagename VARCHAR2(1000);
 i NUMBER:=0;
 linechk NUMBER;
 finaldate DATE;
 a NUMBER;
 SNUM NUMBER;
 EDI_NAME VARCHAR(100);
 FL VARCHAR(100);
 INSERTS NUMBER;
 FINSERTS NUMBER;
 PRIORTY VARCHAR2(2);
 REPAETTYPE VARCHAR2(2);
 PERIODICITY_VALIDCODE VARCHAR2(1);
BEGIN
    DELETE FROM TMPINS;COMMIT;
    DELETE FROM TMP2;COMMIT;
    SELECT "REPEAT_DAY_TYPE" into REPAETTYPE FROM PREFERRENCES WHERE "comp_code"=compcode;
    IF(startdate='' OR startdate IS NULL)THEN
         finaldate := NULL;
    ELSE
        finaldate:=startdate;
    END IF;
    packagename:=PACKAGE1;
    ---  16 SEP 09
    a:=Multisplit(packagename,code,',');
  --  insert into TMPINS select SEGMENTNUM, EDITION_NAME,finaldate,SEGMENTNUM,FLAG from TMP_GRIDINS;
    DECLARE
     CURSOR subedition
     IS
       SELECT SEGMENTNUM, EDITION_NAME,FLAG,INSERTION  FROM TMP_GRIDINS ORDER BY TO_NUMBER(SEGMENTNUM);
      BEGIN
         OPEN subedition;

         LOOP
            FETCH subedition
             INTO SNUM, EDI_NAME, FL, INSERTS;

            EXIT WHEN subedition%NOTFOUND;
            BEGIN
            SELECT "ValidationCode" INTO PERIODICITY_VALIDCODE FROM PREODICITY_MASTER WHERE "Preodicity_Code"=(select "Preodicity_Code" from edition_mast where trim("Edition_Alias")=trim(EDI_NAME));
            EXCEPTION
            WHEN NO_DATA_FOUND THEN 
            SELECT "ValidationCode" INTO PERIODICITY_VALIDCODE FROM PREODICITY_MASTER WHERE "Preodicity_Code"=(select "Preodicity_Code" from SUPPLEMENT_MAST where trim("Supp_Alias")=trim(EDI_NAME));
            END; 
            FINSERTS:=  INSERTS * noofinsertion;
           -- dbms_output.put_line(FINSERTS);
            WHILE ( to_number(i) < to_number(FINSERTS))
             LOOP
                 IF(i=0 AND startdate  IS NOT NULL) THEN
                    finaldate:=startdate;
                 ELSE
                    IF(insertiondate IS NULL) THEN
                        finaldate:=NULL;
                    ELSE
                        if REPAETTYPE = 'y' then
                            finaldate:=add_months( to_date(finaldate), TO_NUMBER(insertiondate) * 12 );
                        elsif REPAETTYPE = 'm' then
                            finaldate:=add_months(finaldate, TO_NUMBER(insertiondate));
                        else
                            if PERIODICITY_VALIDCODE = '6' then
                             finaldate:=add_months(finaldate, 2);
                            elsif PERIODICITY_VALIDCODE = '7' then
                             finaldate:=add_months(finaldate, 3); 
                            else
                            finaldate:=(TO_NUMBER(insertiondate)+finaldate);
                            end if;
                        end if;
                    END IF;
                 END IF;
               BEGIN
               dbms_output.put_line(FL);
               dbms_output.put_line(EDI_NAME);
                SELECT PRIORITY INTO PRIORTY FROM TBL_PRIORITY_UOM WHERE COMBIN_CODE=FL AND EDITION_CODE=(SELECT "Edition_Code" from edition_mast where trim("Edition_Alias")=trim(EDI_NAME));
               EXCEPTION
                WHEN NO_DATA_FOUND THEN  PRIORTY:='1';
               END;
                 INSERT INTO TMPINS(SEGMENTNAME, EDITION_NAME, DATE1, IDNUM, EDITION_CODE,PRIORITY) VALUES(SNUM, EDI_NAME,finaldate,i,FL,PRIORTY);
                --  dbms_output.put_line('I--*' || i);
                 i:=i+1;
                
             END LOOP;
            i:=0; 
           
            FINSERTS:=0;
        END LOOP;

         CLOSE subedition;
      END;
   /* if(noofinsertion=0 or noofinsertion=1) then
        --a:=fn_SplitField1(packagename,'+');
        --insert into TMPINS select SEGMENTNUM, EDITION_NAME,finaldate,SEGMENTNUM from result1;
        a:=multisplit(packagename,code,',');
        insert into TMPINS select SEGMENTNUM, EDITION_NAME,finaldate,SEGMENTNUM,FLAG from TMP_GRIDINS;
    else
        finaldate:=startdate;
        dbms_output.put_line('lata');
        dbms_output.put_line(finaldate);
        while ( i < noofinsertion)
        loop
            if(i=0 and startdate  is not null)
            then
                dbms_output.put_line('lata- ');
                dbms_output.put_line(i);
                 finaldate:=startdate;
                  dbms_output.put_line(finaldate);
                    --a:=fn_SplitField1(packagename,'+');
                    --insert into TMPINS select SEGMENTNUM, EDITION_NAME,finaldate,i from result1 order by SEGMENTNUM;
                    a:=multisplit(packagename,code,',');
                    insert into TMPINS select SEGMENTNUM, EDITION_NAME,finaldate,i,FLAG from TMP_GRIDINS order by SEGMENTNUM;
                 i:=i+1;
            else
             dbms_output.put_line('lata- ');
                dbms_output.put_line(i);
                if(startdate is not null) then
                    if(insertiondate='0' or insertiondate is null) then
                        finaldate:=null;
                   -- elsif(insertiondate is null) then
                     --   finaldate:=null;
                    else
                         finaldate:=(to_number(insertiondate)+finaldate);
                    end if;
                    --a:=fn_SplitField1(packagename,'+');
                    --insert into TMPINS select SEGMENTNUM, EDITION_NAME,finaldate,i from result1 order by SEGMENTNUM;
                    a:=multisplit(packagename,code,',');
                    insert into TMPINS select SEGMENTNUM, EDITION_NAME,finaldate,i,FLAG from TMP_GRIDINS order by SEGMENTNUM;
                     i:=i+1;
                else
                    finaldate:=null;
                    --a:=fn_SplitField1(packagename,'+');
                    --insert into TMPINS select SEGMENTNUM, EDITION_NAME,finaldate,i from result1 order by SEGMENTNUM;
                    a:=multisplit(packagename,code,',');
                    insert into TMPINS select SEGMENTNUM, EDITION_NAME,finaldate,i,FLAG from TMP_GRIDINS order by SEGMENTNUM;
                    i:=i+1;
                end if;
            end if;
        end loop;
    end if;*/
  --  IF(flag = 0)THEN
        INSERT INTO TMP2(EDITION_NAME, DATE1, EDITION_CODE, IDNUM, PRIORITY) SELECT edition_name,date1,EDITION_CODE,IDNUM,TMPINS.PRIORITY FROM TMPINS ORDER BY idnum,EDITION_CODE,TO_NUMBER(segmentname);--order by date1,segmentname;
  --  END IF;
    IF(dateformat = 'mm/dd/yyyy')
    THEN
        IF insertiondate = NULL OR insertiondate ='' THEN
        OPEN P_Accounts FOR
        --BEGIN
            SELECT NVL((SELECT "Combin_Desc" FROM COMBIN_MAST WHERE "Comp_Code"=compcode and "Package_Name"=RTRIM(LTRIM(Edition_Name)) AND "Ad_Type_code"=adtype1 AND "pub_center"=center),RTRIM(LTRIM(Edition_Name))) AS "Edition_Name",NVL(TO_CHAR(date1,'mm/dd/yyyy'),'') AS "Date",
            EDITION_CODE,IDNUM,Edition_Name AS pkgname,(select "Pub_Code" from edition_mast where "Edition_Alias"=RTRIM(LTRIM(Edition_Name)) and rownum<=1) as PUBCODE,PRIORITY,(select SPLIT FROM COMBIN_MAST WHERE "Combin_Code"=EDITION_CODE) as SPLIT FROM TMP2 ORDER BY ROWID;-- order by TO_NUMBER(IDNUM),Edition_Name ;
        --END;
        ELSE
            OPEN P_Accounts FOR
            SELECT NVL((SELECT "Combin_Desc" FROM COMBIN_MAST WHERE "Comp_Code"=compcode and  "Package_Name"=RTRIM(LTRIM(Edition_Name)) AND "Ad_Type_code"=adtype1 AND "pub_center"=center),RTRIM(LTRIM(Edition_Name))) AS "Edition_Name",NVL(TO_CHAR(date1,'mm/dd/yyyy'),'') AS "Date",
            EDITION_CODE,IDNUM,Edition_Name AS pkgname,(select "Pub_Code" from edition_mast where "Edition_Alias"=RTRIM(LTRIM(Edition_Name)) and rownum<=1) as PUBCODE,PRIORITY,(select SPLIT FROM COMBIN_MAST WHERE "Combin_Code"=EDITION_CODE) as SPLIT FROM TMP2 ORDER BY ROWID;-- order by TO_NUMBER(IDNUM),Edition_Name;-- order by Date1 asc;
        END IF;
    END IF;
    IF(dateformat = 'dd/mm/yyyy')
    THEN
        IF insertiondate=NULL THEN
            OPEN P_Accounts FOR
            SELECT NVL((SELECT "Combin_Desc" FROM COMBIN_MAST WHERE "Comp_Code"=compcode and "Package_Name"=RTRIM(LTRIM(Edition_Name)) AND "Ad_Type_code"=adtype1 AND "pub_center"=center),RTRIM(LTRIM(Edition_Name))) AS "Edition_Name",NVL(TO_CHAR(date1,'dd/mm/yyyy'),'') AS "Date",
            EDITION_CODE,IDNUM,Edition_Name AS pkgname,(select "Pub_Code" from edition_mast where "Edition_Alias"=RTRIM(LTRIM(Edition_Name)) and rownum<=1) as PUBCODE,PRIORITY,(select SPLIT FROM COMBIN_MAST WHERE "Combin_Code"=EDITION_CODE) as SPLIT FROM TMP2 ORDER BY ROWID;-- order by TO_NUMBER(IDNUM),Edition_Name;-- order by Date1 desc;
        ELSE
            OPEN P_Accounts FOR
                SELECT NVL((SELECT "Combin_Desc" FROM COMBIN_MAST WHERE "Comp_Code"=compcode and "Package_Name"=RTRIM(LTRIM(Edition_Name)) AND "Ad_Type_code"=adtype1 AND "pub_center"=center),RTRIM(LTRIM(Edition_Name))) AS "Edition_Name",NVL(TO_CHAR(date1,'dd/mm/yyyy'),'') AS "Date",
                EDITION_CODE,IDNUM,Edition_Name AS pkgname,(select "Pub_Code" from edition_mast where "Edition_Alias"=RTRIM(LTRIM(Edition_Name)) and rownum<=1) as PUBCODE,PRIORITY,(select SPLIT FROM COMBIN_MAST WHERE "Combin_Code"=EDITION_CODE) as SPLIT FROM TMP2 ORDER BY ROWID;-- order by TO_NUMBER(IDNUM),Edition_Name;-- order by Date1 asc;
        END IF;
    END IF;
    IF(dateformat = 'yyyy/mm/dd')
    THEN
        IF insertiondate=NULL THEN
            OPEN P_Accounts FOR
            SELECT NVL((SELECT "Combin_Desc" FROM COMBIN_MAST WHERE "Comp_Code"=compcode and "Package_Name"=RTRIM(LTRIM(Edition_Name)) AND "Ad_Type_code"=adtype1 AND "pub_center"=center),RTRIM(LTRIM(Edition_Name))) AS "Edition_Name",NVL(TO_CHAR(date1,'yyyy/mm/dd'),'') AS "Date",
            EDITION_CODE,IDNUM,Edition_Name AS pkgname,(select "Pub_Code" from edition_mast where "Edition_Alias"=RTRIM(LTRIM(Edition_Name)) and rownum<=1) as PUBCODE,PRIORITY,(select SPLIT FROM COMBIN_MAST WHERE "Combin_Code"=EDITION_CODE) as SPLIT FROM TMP2 ORDER BY ROWID;-- order by TO_NUMBER(IDNUM),Edition_Name;-- order by Date1 desc;
            ELSE
            OPEN P_Accounts FOR
            SELECT NVL((SELECT "Combin_Desc" FROM COMBIN_MAST WHERE "Comp_Code"=compcode and "Package_Name"=RTRIM(LTRIM(Edition_Name)) AND "Ad_Type_code"=adtype1 AND "pub_center"=center),RTRIM(LTRIM(Edition_Name))) AS "Edition_Name",NVL(TO_CHAR(date1,'yyyy/mm/dd'),'') AS "Date",
            EDITION_CODE,IDNUM,Edition_Name AS pkgname,(select "Pub_Code" from edition_mast where "Edition_Alias"=RTRIM(LTRIM(Edition_Name)) and rownum<=1) as PUBCODE,PRIORITY,(select SPLIT FROM COMBIN_MAST WHERE "Combin_Code"=EDITION_CODE) as SPLIT FROM TMP2 ORDER BY ROWID;-- order by TO_NUMBER(IDNUM),Edition_Name;-- order by Date1 asc;
        END IF;
    END IF;
    IF(dateformat = NULL)
    THEN
        IF insertiondate=NULL THEN
            OPEN P_Accounts FOR
            SELECT NVL((SELECT "Combin_Desc" FROM COMBIN_MAST WHERE "Comp_Code"=compcode and "Package_Name"=RTRIM(LTRIM(Edition_Name)) AND "Ad_Type_code"=adtype1 AND "pub_center"=center),RTRIM(LTRIM(Edition_Name))) AS "Edition_Name",NVL(TO_CHAR(date1,'mm/dd/yyyy'),'') AS "Date",
            EDITION_CODE,IDNUM,Edition_Name AS pkgname,(select "Pub_Code" from edition_mast where "Edition_Alias"=RTRIM(LTRIM(Edition_Name)) and rownum<=1) as PUBCODE,PRIORITY,(select SPLIT FROM COMBIN_MAST WHERE "Combin_Code"=EDITION_CODE) as SPLIT FROM TMP2 ORDER BY ROWID;-- order by TO_NUMBER(IDNUM),Edition_Name;-- order by Date1 desc;
        ELSE
            OPEN P_Accounts FOR
            SELECT NVL((SELECT "Combin_Desc" FROM COMBIN_MAST WHERE "Comp_Code"=compcode and "Package_Name"=RTRIM(LTRIM(Edition_Name)) AND "Ad_Type_code"=adtype1 AND "pub_center"=center),RTRIM(LTRIM(Edition_Name))) AS "Edition_Name",NVL(TO_CHAR(date1,'mm/dd/yyyy'),'') AS "Date",
            EDITION_CODE,IDNUM,Edition_Name AS pkgname,(select "Pub_Code" from edition_mast where "Edition_Alias"=RTRIM(LTRIM(Edition_Name)) and rownum<=1) as PUBCODE,PRIORITY,(select SPLIT FROM COMBIN_MAST WHERE "Combin_Code"=EDITION_CODE) as SPLIT FROM TMP2 ORDER BY ROWID;-- order by TO_NUMBER(IDNUM),Edition_Name;-- order by Date1 asc;
        END IF;
    END IF;
OPEN P_Accounts1 FOR
    SELECT "Col_Name" AS "col_Name" ,"Col_Code" AS "col_Code"FROM COL_MAST WHERE "Comp_Code"=Compcode;
    OPEN P_Accounts2 FOR
    SELECT "premiumname","Premiumcode" FROM ADVPOS_PREM_MAST WHERE "comp_code"=Compcode;
    OPEN P_Accounts3 FOR
    SELECT "Adv_Subcat_Name","Adv_Subcat_Code" FROM ADV_SUBCAT_MAST WHERE "Adv_Cat_Code"=Adcategory AND "Comp_Code"=Compcode;
    OPEN P_Accounts4 FOR
    SELECT "Uom_Name" AS "uom_name","Uom_Code" AS "uom_code" FROM UOM_MAST WHERE "Comp_Code"=Compcode;
    OPEN P_Accounts5 FOR
    SELECT "Adv_Type_Name" AS "adv_type_name","Adv_Type_Code" AS "adv_type_code" FROM ADV_TYPE_MAST WHERE "Comp_Code"=Compcode;
    OPEN P_Accounts6 FOR
    SELECT "Adv_Cat_Name" AS "adv_cat_name","Adv_Cat_Code" AS "adv_cat_code" FROM ADV_CAT_MAST WHERE "Comp_Code"=Compcode;
    OPEN P_Accounts7 FOR
    SELECT "Pos_Type_Code" AS "pos_type_code","Pos_Type" AS "pos_type" FROM ADVPOS_TYPE_MAST WHERE "Comp_Code"=Compcode;
    OPEN P_Accounts8 FOR
    SELECT "Comp_Code" FROM EDITION_MAST WHERE "Comp_Code"='dummy';
    OPEN P_Accounts9 FOR
        SELECT "Paid_permission"    FROM MODULE_DETAIBUTTONL  WHERE "comp_code"=Compcode AND "Form_Name"='QBC';
    OPEN P_Accounts10 FOR
        SELECT "catname","catcode" FROM AD_CAT3 WHERE "subcatname"=adsubcat1 AND "compcode"=Compcode ORDER BY "catname";
    OPEN P_Accounts11 FOR
        SELECT "Cat_Name","Cat_Code" FROM TBL_CAT4 WHERE "Sub_Cat_Name"=adcat3 AND "Comp_Code"=Compcode ORDER BY "Cat_Name";
    OPEN P_Accounts12 FOR
        SELECT "Cat_Name","Cat_Code" FROM TBL_CAT5 WHERE "Sub_Cat_Name"=adcat4 AND "Comp_Code"=Compcode ORDER BY "Cat_Name";
END qbc_getinsertion_p;
END Qbc_Getinsertion ;
/

/********************************************************************************************************************************************/
DROP PACKAGE BINDAUDIT;

CREATE OR REPLACE PACKAGE HT18JULY.Bindaudit
IS
  TYPE T_ACCOUNT_CURSOR IS REF CURSOR;

  PROCEDURE bindaudit_p(fromdate IN VARCHAR2,todate IN VARCHAR2,date1 IN VARCHAR2,BRANCH1 IN VARCHAR2,Adtype IN VARCHAR2,
  audittype IN VARCHAR2
  ,branch2 IN VARCHAR2,
  v_Cat in varchar2,
  v_userid in varchar2,
  comp_code in varchar2:=null,
  P_ACCOUNT OUT T_ACCOUNT_CURSOR);
END Bindaudit;
/



DROP PACKAGE BODY BINDAUDIT;

CREATE OR REPLACE PACKAGE BODY HT18JULY.bindaudit
IS
   PROCEDURE bindaudit_p (
      fromdate    IN       VARCHAR2,
      todate      IN       VARCHAR2,
      date1       IN       VARCHAR2,
      branch1     IN       VARCHAR2,
      adtype      IN       VARCHAR2,
      audittype   IN       VARCHAR2,
      branch2     IN       VARCHAR2,
      v_cat       IN       VARCHAR2,
      v_userid    IN       VARCHAR2,
      comp_code   in varchar2:=null,
      p_account   OUT      t_account_cursor
   )
   AS
   RELAUTHREQ  varchar2(1);
   BEGIN
   select RELAUTHREQON INTO RELAUTHREQ from preferrences where ("comp_code"=comp_code or comp_code is null) ;
      INSERT INTO test1
                  (vstring
                  )
           VALUES (   'fromdate '
                   || fromdate
                   || ' todate '
                   || todate
                   || ' date1 '
                   || date1
                   || ' BRANCH1 '
                   || branch1
                   || ' Adtype '
                   || adtype
                   || ' audittype '
                   || audittype
                   || ' branch2 '
                   || branch2
                   || ' v_Cat '
                   || v_cat
                   || ' v_userid '
                   || v_userid
                  );

      COMMIT;
  
      IF audittype = 'audit'
      THEN
        IF RELAUTHREQ = 'A' THEN
                 IF (branch1 = 'All' AND branch2 IS NULL)
                 THEN
                    OPEN p_account FOR
                       SELECT "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                          and tbl_booking_mast.APP_STATUS='Y'    
                          AND tbl_booking_mast."branch" IN (
                                 SELECT branch_mst."Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y'));
                 ELSE
                    OPEN p_account FOR
                       SELECT "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "branch" IN (
                                 SELECT "Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                    AND "pub_center" = branch1)
                           and tbl_booking_mast.APP_STATUS='Y'            
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              );
                 END IF;
        ELSIF RELAUTHREQ ='D' THEN
                 IF (branch1 = 'All' AND branch2 IS NULL)
                 THEN
                    OPEN p_account FOR
                       SELECT "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                          and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')    
                          AND tbl_booking_mast."branch" IN (
                                 SELECT branch_mst."Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y'));
                 ELSE
                    OPEN p_account FOR
                       SELECT "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "branch" IN (
                                 SELECT "Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                    AND "pub_center" = branch1)
                          and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')          
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              );
                 END IF;
        ELSE
            IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NOT NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'));
         ELSE
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NOT NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      );
         END IF;
        END IF;
         
      END IF;

      IF audittype = 'unaudit'
      THEN
      IF RELAUTHREQ = 'A' THEN
        IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                   and tbl_booking_mast.APP_STATUS='Y'     
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'));
         -- SELECT "cio_booking_id",nvl((select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code","audit","Ad_type_code",(select "File_Name" from tbl_booking_insert where "Cio_Booking_Id"=tbl_booking_mast."cio_booking_id" and "File_Name" is not null and rownum<=1) as "FILENAME" FROM TBL_BOOKING_MAST WHERE  "date_time" BETWEEN fromdate AND todate AND "Ad_type_code"=Adtype AND "audit" IS  NULL and ("branch"=branch2 OR  branch2 IS NULL) and (tbl_booking_mast."Ad_cat_code"=v_Cat OR  v_Cat IS NULL);
         ELSE
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                   and tbl_booking_mast.APP_STATUS='Y'           
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      );
         END IF;
      ELSIF RELAUTHREQ = 'D' THEN
        IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')    
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'));
         -- SELECT "cio_booking_id",nvl((select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code","audit","Ad_type_code",(select "File_Name" from tbl_booking_insert where "Cio_Booking_Id"=tbl_booking_mast."cio_booking_id" and "File_Name" is not null and rownum<=1) as "FILENAME" FROM TBL_BOOKING_MAST WHERE  "date_time" BETWEEN fromdate AND todate AND "Ad_type_code"=Adtype AND "audit" IS  NULL and ("branch"=branch2 OR  branch2 IS NULL) and (tbl_booking_mast."Ad_cat_code"=v_Cat OR  v_Cat IS NULL);
         ELSE
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                  and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')          
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      );
         END IF;
      ELSE
        IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'));
         -- SELECT "cio_booking_id",nvl((select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code","audit","Ad_type_code",(select "File_Name" from tbl_booking_insert where "Cio_Booking_Id"=tbl_booking_mast."cio_booking_id" and "File_Name" is not null and rownum<=1) as "FILENAME" FROM TBL_BOOKING_MAST WHERE  "date_time" BETWEEN fromdate AND todate AND "Ad_type_code"=Adtype AND "audit" IS  NULL and ("branch"=branch2 OR  branch2 IS NULL) and (tbl_booking_mast."Ad_cat_code"=v_Cat OR  v_Cat IS NULL);
         ELSE
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      );
         END IF;
      END IF;
         
      END IF;

      IF audittype != 'unaudit' AND audittype != 'audit'
      THEN
        IF RELAUTHREQ = 'A' THEN
                     IF (branch1 = 'All')
                     THEN
                        OPEN p_account FOR
                           SELECT "cio_booking_id",
                                  NVL ((SELECT "Cust_Name"
                                          FROM cust_mast
                                         WHERE "Cust_Code" = "Client_code"),
                                       "Client_code"
                                      ) AS "Client_code",
                                  "audit", "Ad_type_code",
                                  (SELECT "File_Name"
                                     FROM tbl_booking_insert
                                    WHERE "Cio_Booking_Id" =
                                             tbl_booking_mast."cio_booking_id"
                                      AND "File_Name" IS NOT NULL
                                      AND ROWNUM <= 1) AS "FILENAME",
                                  CASE date1
                                     WHEN 'mm/dd/yyyy'
                                        THEN TO_CHAR
                                               ("Creation_datetime",
                                                'mm/dd/yyyy'
                                               )
                                     WHEN 'dd/mm/yyyy'
                                        THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                     WHEN 'yyyy/mm/dd'
                                        THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                                  END AS "Creation_datetime"
                             FROM tbl_booking_mast
                            WHERE "date_time" BETWEEN fromdate AND todate
                              AND "Ad_type_code" = adtype
                              AND ("branch" = branch2 OR branch2 IS NULL)
                              AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                                  )
                             and tbl_booking_mast.APP_STATUS='Y'     
                              AND tbl_booking_mast."branch" IN (
                                     SELECT branch_mst."Branch_Name"
                                       FROM branch_mst
                                      WHERE branch_mst."Branch_Code" IN (
                                               SELECT lb.branch_code
                                                 FROM login_branch_mast lb
                                                WHERE lb.user_code = v_userid
                                                  AND NVL (lb.user_flag, 'N') = 'Y'));
                     ELSE
                        OPEN p_account FOR
                           SELECT "cio_booking_id",
                                  NVL ((SELECT "Cust_Name"
                                          FROM cust_mast
                                         WHERE "Cust_Code" = "Client_code"),
                                       "Client_code"
                                      ) AS "Client_code",
                                  "audit", "Ad_type_code",
                                  (SELECT "File_Name"
                                     FROM tbl_booking_insert
                                    WHERE "Cio_Booking_Id" =
                                             tbl_booking_mast."cio_booking_id"
                                      AND "File_Name" IS NOT NULL
                                      AND ROWNUM <= 1) AS "FILENAME",
                                  CASE date1
                                     WHEN 'mm/dd/yyyy'
                                        THEN TO_CHAR
                                               ("Creation_datetime",
                                                'mm/dd/yyyy'
                                               )
                                     WHEN 'dd/mm/yyyy'
                                        THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                     WHEN 'yyyy/mm/dd'
                                        THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                                  END AS "Creation_datetime"
                             FROM tbl_booking_mast
                            WHERE "date_time" BETWEEN fromdate AND todate
                              AND "branch" IN (
                                     SELECT "Branch_Code"
                                       FROM branch_mst
                                      WHERE branch_mst."Branch_Code" IN (
                                               SELECT lb.branch_code
                                                 FROM login_branch_mast lb
                                                WHERE lb.user_code = v_userid
                                                  AND NVL (lb.user_flag, 'N') = 'Y')
                                        AND "pub_center" =
                                                        (SELECT "Pub_cent_Code"
                                                           FROM pub_cent_mast
                                                          WHERE "Pub_cent_Code" = branch1))
                              and tbl_booking_mast.APP_STATUS='Y'                            
                              AND "Ad_type_code" = adtype
                              AND ("branch" = branch2 OR branch2 IS NULL)
                              AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                                  );
                     END IF;
        ELSIF RELAUTHREQ = 'D' THEN
                 IF (branch1 = 'All')
                 THEN
                    OPEN p_account FOR
                       SELECT "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "Ad_type_code" = adtype
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                          and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')    
                          AND tbl_booking_mast."branch" IN (
                                 SELECT branch_mst."Branch_Name"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y'));
                 ELSE
                    OPEN p_account FOR
                       SELECT "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "branch" IN (
                                 SELECT "Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                    AND "pub_center" =
                                                    (SELECT "Pub_cent_Code"
                                                       FROM pub_cent_mast
                                                      WHERE "Pub_cent_Code" = branch1))
                          AND "Ad_type_code" = adtype
                            and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A') 
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              );
                 END IF;
        ELSE
             IF (branch1 = 'All')
         THEN
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Name"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'));
         ELSE
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" =
                                            (SELECT "Pub_cent_Code"
                                               FROM pub_cent_mast
                                              WHERE "Pub_cent_Code" = branch1))
                  AND "Ad_type_code" = adtype
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      );
         END IF;
        END IF;
        
      END IF;
   END bindaudit_p;
END bindaudit;
/

/***************************************************************************************************************************************************/
DROP PROCEDURE GETAPPROVALRO_WEB;

CREATE OR REPLACE PROCEDURE HT18JULY.getapprovalRo_web

(
vusername in varchar2,
compcode in varchar2,
agency in varchar2,
executive in varchar2,
client in varchar2,
varFromDate in date,
varToDate in date,
dateformat in varchar2,
cioid in varchar2,
flag in varchar2,
P_Accounts OUT Cur_Type_New1.cursor_type
)
is
RELAUTHREQ  varchar2(1);
begin
select RELAUTHREQON INTO RELAUTHREQ from preferrences where "comp_code"=compcode;
if flag ='A' then
 open P_Accounts for
SELECT (select "Agency_Name" from agency_mast where "Comp_Code"=compcode and "code_subcode"=tbl_booking_mast."Agency_sub_code") agency,
(select "Package_Name" from combin_mast where "Comp_Code"=compcode and "Combin_Code"=(
case when instr('abcdef',',') >0 then 
substr("Package_code",1,instr("Package_code",',')-1)  
else "Package_code" end)) as Package,
case when dateformat='dd/mm/yyyy' then
to_char("date_time",'dd/mm/yy') 
when dateformat='yyyy/mm/dd' then 
to_char("date_time",'yy/mm/dd')
else to_char("date_time",'mm/dd/yy') end as bookdate
,
(select "Cust_Name" from cust_mast where "Comp_Code"=compcode and "Cust_Code"= "Client_code") client,
"RO_No",case when dateformat='dd/mm/yyyy' then
to_char("RO_Date",'dd/mm/yy') 
when dateformat='yyyy/mm/dd' then 
to_char("RO_Date",'yy/mm/dd')
else to_char("RO_Date",'mm/dd/yy') end as rodate,(select "Exec_name" from exec_mast where  "Exe_no" = "Executive_code") executive,
(select "Retain_Name" from retainermaster where "Comp_Code"=compcode and "Retain_Code"= "RETAINER") retainer,"Card_rate",

Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") as deviation,"cio_booking_id","Bill_amount","Gross_amount",
(select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=tbl_booking_mast."Page_prem") as PAGEPERM,APP_STATUS,"booked_by"
from tbl_booking_mast where "Comp_code"=compcode  and APP_STATUS='Y'  
and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')

 AND ("Agency_sub_code" = agency  OR agency IS NULL)
 AND ("Executive_code" = executive  OR executive IS NULL)
 AND ("Client_code" = client  OR client IS NULL)
 and "date_time" between varFromDate and varToDate
 AND ("cio_booking_id" = cioid  OR cioid IS NULL)
 
 
 ORDER BY TBL_BOOKING_MAST."date_time" DESC;
 elsif flag ='R' then
 open P_Accounts for
SELECT (select "Agency_Name" from agency_mast where "Comp_Code"=compcode and "code_subcode"=tbl_booking_mast."Agency_sub_code") agency,
(select "Package_Name" from combin_mast where "Comp_Code"=compcode and "Combin_Code"=(
case when instr('abcdef',',') >0 then 
substr("Package_code",1,instr("Package_code",',')-1)  
else "Package_code" end)) as Package,
case when dateformat='dd/mm/yyyy' then
to_char("date_time",'dd/mm/yy') 
when dateformat='yyyy/mm/dd' then 
to_char("date_time",'yy/mm/dd')
else to_char("date_time",'mm/dd/yy') end as bookdate
,
(select "Cust_Name" from cust_mast where "Comp_Code"=compcode and "Cust_Code"= "Client_code") client,
"RO_No",case when dateformat='dd/mm/yyyy' then
to_char("RO_Date",'dd/mm/yy') 
when dateformat='yyyy/mm/dd' then 
to_char("RO_Date",'yy/mm/dd')
else to_char("RO_Date",'mm/dd/yy') end as rodate,(select "Exec_name" from exec_mast where  "Exe_no" = "Executive_code") executive,
(select "Retain_Name" from retainermaster where "Comp_Code"=compcode and "Retain_Code"= "RETAINER") retainer,"Card_rate",
Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") as deviation,"cio_booking_id","Bill_amount","Gross_amount",
(select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=tbl_booking_mast."Page_prem") as PAGEPERM,APP_STATUS,"booked_by"
from tbl_booking_mast where "Comp_code"=compcode  and APP_STATUS='N'  
and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')
 AND ("Agency_sub_code" = agency  OR agency IS NULL)
 AND ("Executive_code" = executive  OR executive IS NULL)
 AND ("Client_code" = client  OR client IS NULL)
 and "date_time" between varFromDate and varToDate
 AND ("cio_booking_id" = cioid  OR cioid IS NULL)
  ORDER BY TBL_BOOKING_MAST."date_time" DESC;
 else
 open P_Accounts for
SELECT (select "Agency_Name" from agency_mast where "Comp_Code"=compcode and "code_subcode"=tbl_booking_mast."Agency_sub_code") agency,
(select "Package_Name" from combin_mast where "Comp_Code"=compcode and "Combin_Code"=(
case when instr('abcdef',',') >0 then 
substr("Package_code",1,instr("Package_code",',')-1)  
else "Package_code" end)) as Package,
case when dateformat='dd/mm/yyyy' then
to_char("date_time",'dd/mm/yy') 
when dateformat='yyyy/mm/dd' then 
to_char("date_time",'yy/mm/dd')
else to_char("date_time",'mm/dd/yy') end as bookdate
,
(select "Cust_Name" from cust_mast where "Comp_Code"=compcode and "Cust_Code"= "Client_code") client,
"RO_No",case when dateformat='dd/mm/yyyy' then
to_char("RO_Date",'dd/mm/yy') 
when dateformat='yyyy/mm/dd' then 
to_char("RO_Date",'yy/mm/dd')
else to_char("RO_Date",'mm/dd/yy') end as rodate,(select "Exec_name" from exec_mast where  "Exe_no" = "Executive_code") executive,
(select "Retain_Name" from retainermaster where "Comp_Code"=compcode and "Retain_Code"= "RETAINER") retainer,"Card_rate",
Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") as deviation,"cio_booking_id","Bill_amount","Gross_amount",
(select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=tbl_booking_mast."Page_prem") as PAGEPERM,APP_STATUS,"booked_by"
from tbl_booking_mast where "Comp_code"=compcode and NVL(APP_STATUS,'#')!='Y'   and NVL(APP_STATUS,'#')!='N'  
and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')
 AND ("Agency_sub_code" = agency  OR agency IS NULL)
 AND ("Executive_code" = executive  OR executive IS NULL)
 AND ("Client_code" = client  OR client IS NULL)
 and "date_time" between varFromDate and varToDate
 AND ("cio_booking_id" = cioid  OR cioid IS NULL)
 
 
 ORDER BY TBL_BOOKING_MAST."date_time" DESC;
 end if;

end;
/

/********************************************************************************************************************************************************************************/
DROP FUNCTION GETCM1;

CREATE OR REPLACE FUNCTION HT18JULY.getcm1 
(
    col  in varchar2,
    prod in varchar2,
    adtype  in varchar2
)
RETURN number
is
 getsize varchar2(10);
BEGIN
   
    select col_size into getsize from COLCM where COL_NO=col and ADPRODUCT=prod and AD_TYPE=adtype;
    
    if getsize is null then
        getsize:= col;
    end if;
    return  getsize;
END;
/

/*****************************************************************************************************************************************/
DROP PACKAGE HT18JULY.INSERTINTOBOOKING;

CREATE OR REPLACE PACKAGE Insertintobooking
IS
   PROCEDURE  insertintobooking_P (
	date_time IN DATE,
	adsizetype IN VARCHAR2,
	branch IN VARCHAR2,
	booked_by IN VARCHAR2,
	prevbook IN VARCHAR2,
	approvedby IN VARCHAR2,
	ciobookid IN VARCHAR2,
	audit1 IN VARCHAR2,
	rono IN VARCHAR2,
	rodate IN DATE,
	caption IN VARCHAR2,
	billstatus IN VARCHAR2,
	rostatus IN VARCHAR2,
	agency IN VARCHAR2,
	client IN VARCHAR2,
	agencyaddress IN VARCHAR2,
	clientaddresses IN VARCHAR2,
	agencycode IN VARCHAR2,
	dockitno IN VARCHAR2,
	execname IN VARCHAR2,
	execzone IN VARCHAR2,
	product IN VARCHAR2,
	brand IN VARCHAR2,
	keyno IN VARCHAR2,
	billremark IN VARCHAR2,
	printremark IN VARCHAR2,
	PACKAGE1 IN VARCHAR2,
	insertion IN NUMBER,
	startdate IN DATE,
	repeatdate IN VARCHAR2,
	adtype1 IN VARCHAR2,
	Adcategory IN VARCHAR2,
	subcategory IN VARCHAR2,
	color IN VARCHAR2,
	uom IN VARCHAR2,
	pageposition IN VARCHAR2,
	pagetype1 IN VARCHAR2,
	pageno IN NUMBER,
	adsizheight IN NUMBER,
	adsizwidth IN NUMBER,
	scheme1 IN VARCHAR2,
	currency IN VARCHAR2,
	ratecode11 IN VARCHAR2,
	agreedrate IN NUMBER,
	agreedamt IN NUMBER,
	spedisc IN NUMBER,
	compcode IN VARCHAR2,
	spacedisx IN NUMBER,
	specialcharges IN NUMBER,
	userid IN VARCHAR2,
	agencytype IN VARCHAR2,
	agencystatus IN VARCHAR2,
	paymode IN VARCHAR2,
	agenccredit IN NUMBER,
	cardrate IN NUMBER,
	cardamount IN NUMBER,
	discount IN NUMBER,
	discountper IN NUMBER,
	billaddress IN VARCHAR2,
	totarea IN NUMBER,
	billcycle IN VARCHAR2,
	billpay IN VARCHAR2,
	revenuecenter IN VARCHAR2,
	billheight IN NUMBER,
	billwidth IN NUMBER,
	billto IN VARCHAR2,
	invoices IN NUMBER,
	vts IN NUMBER,
	tradedisc IN NUMBER,
	agencyout IN VARCHAR2,
	boxcode IN VARCHAR2,
	boxno IN VARCHAR2,
	boxagency IN VARCHAR2,
	boxaddress IN VARCHAR2,
	boxclient IN VARCHAR2,
	coupan IN VARCHAR2,
	bookingtype IN VARCHAR2,
	tfn IN VARCHAR2,
	campaign IN VARCHAR2,
	bill_amt IN NUMBER,
	pageprem IN VARCHAR2,
	pageamt IN NUMBER,
	premper IN NUMBER,
	grossamt IN NUMBER,
	adsizcolumn IN NUMBER,
	billcolumn IN NUMBER,
	specdiscper IN NUMBER,
	spacediscper IN NUMBER,
	billarea IN NUMBER,
	paidins IN NUMBER,
	dealrate IN NUMBER,
	deviation IN NUMBER,
	varient IN VARCHAR2,
	contractname IN VARCHAR2,
	dealtype IN VARCHAR2,
	cardname IN VARCHAR2,
	cardtype IN VARCHAR2,
	cardmonth IN VARCHAR2,
	cardyear IN VARCHAR2,
	cardno IN VARCHAR2,
	receiptno IN VARCHAR2,
	adscat3 IN VARCHAR2,
	adscat4 IN VARCHAR2,
	adscat5 IN VARCHAR2,
	bgcolor IN VARCHAR2,
	bulletcode IN VARCHAR2,
	bulletprm IN NUMBER,
	material IN VARCHAR2,
	receiptdate IN DATE:=NULL,
	prevcioid IN VARCHAR2:=NULL,
	prevreceipt IN VARCHAR2:=NULL,
	prev_ga IN NUMBER:=NULL,
	varient_name IN VARCHAR2:=NULL,
	region1 IN VARCHAR2:=NULL,
	coltype IN VARCHAR2,
	logo_h IN VARCHAR2,
	logo_w IN VARCHAR2,
	logo_col IN VARCHAR2,
	logo_uom IN VARCHAR2,
	retainer1 IN VARCHAR2,
	addagencyrate IN VARCHAR2,
    mobileno    in varchar2,
    addlamt in varchar2,
retamt in varchar2,
retper in varchar2,
cashrecieved in number,
CIRAGENCY_V in varchar2,
CIRRATE_V in varchar2,
CIREDITION_V in varchar2,
CIRPUBLICATION_V in varchar2,
CIRAGENCYSUBCODE_V in varchar2,
BARTERTYPE IN VARCHAR2,
CASHDISCOUNT_V IN VARCHAR2,
CASHDISCOUNTPER_V IN VARCHAR2,
attach1 in varchar2,
attach2 in varchar2,
drpdiscprem in varchar2,
doctype_v in varchar2,
CHKTRADE IN VARCHAR2,
sharepub_p in varchar2,
fmginsert in varchar2,
chkno in VARCHAR2,
chkdate in date:=null,
chkamt in VARCHAR2,
chkbankname in varchar2,
ourbank	in varchar2,
DEALERPANEL_P in VARCHAR2,
DEALERH_P in FLOAT,
DEALERW_P in FLOAT,
DEALERTYPE_P in VARCHAR2,
multiselect in VARCHAR2,
AGREEDRATE_ACTIVE NUMBER,
AGREEDAMT_ACTIVE NUMBER,
grossamtlocal_p number,
billamtlocal_p number,
p_error out varchar2
   );
END Insertintobooking;
/



DROP PACKAGE BODY HT18JULY.INSERTINTOBOOKING;

CREATE OR REPLACE PACKAGE BODY insertintobooking
IS
   PROCEDURE insertintobooking_p (
      date_time            IN       DATE,
      adsizetype           IN       VARCHAR2,
      branch               IN       VARCHAR2,
      booked_by            IN       VARCHAR2,
      prevbook             IN       VARCHAR2,
      approvedby           IN       VARCHAR2,
      ciobookid            IN       VARCHAR2,
      audit1               IN       VARCHAR2,
      rono                 IN       VARCHAR2,
      rodate               IN       DATE,
      caption              IN       VARCHAR2,
      billstatus           IN       VARCHAR2,
      rostatus             IN       VARCHAR2,
      agency               IN       VARCHAR2,
      client               IN       VARCHAR2,
      agencyaddress        IN       VARCHAR2,
      clientaddresses      IN       VARCHAR2,
      agencycode           IN       VARCHAR2,
      dockitno             IN       VARCHAR2,
      execname             IN       VARCHAR2,
      execzone             IN       VARCHAR2,
      product              IN       VARCHAR2,
      brand                IN       VARCHAR2,
      keyno                IN       VARCHAR2,
      billremark           IN       VARCHAR2,
      printremark          IN       VARCHAR2,
      package1             IN       VARCHAR2,
      insertion            IN       NUMBER,
      startdate            IN       DATE,
      repeatdate           IN       VARCHAR2,
      adtype1              IN       VARCHAR2,
      adcategory           IN       VARCHAR2,
      subcategory          IN       VARCHAR2,
      color                IN       VARCHAR2,
      uom                  IN       VARCHAR2,
      pageposition         IN       VARCHAR2,
      pagetype1            IN       VARCHAR2,
      pageno               IN       NUMBER,
      adsizheight          IN       NUMBER,
      adsizwidth           IN       NUMBER,
      scheme1              IN       VARCHAR2,
      currency             IN       VARCHAR2,
      ratecode11           IN       VARCHAR2,
      agreedrate           IN       NUMBER,
      agreedamt            IN       NUMBER,
      spedisc              IN       NUMBER,
      compcode             IN       VARCHAR2,
      spacedisx            IN       NUMBER,
      specialcharges       IN       NUMBER,
      userid               IN       VARCHAR2,
      agencytype           IN       VARCHAR2,
      agencystatus         IN       VARCHAR2,
      paymode              IN       VARCHAR2,
      agenccredit          IN       NUMBER,
      cardrate             IN       NUMBER,
      cardamount           IN       NUMBER,
      discount             IN       NUMBER,
      discountper          IN       NUMBER,
      billaddress          IN       VARCHAR2,
      totarea              IN       NUMBER,
      billcycle            IN       VARCHAR2,
      billpay              IN       VARCHAR2,
      revenuecenter        IN       VARCHAR2,
      billheight           IN       NUMBER,
      billwidth            IN       NUMBER,
      billto               IN       VARCHAR2,
      invoices             IN       NUMBER,
      vts                  IN       NUMBER,
      tradedisc            IN       NUMBER,
      agencyout            IN       VARCHAR2,
      boxcode              IN       VARCHAR2,
      boxno                IN       VARCHAR2,
      boxagency            IN       VARCHAR2,
      boxaddress           IN       VARCHAR2,
      boxclient            IN       VARCHAR2,
      coupan               IN       VARCHAR2,
      bookingtype          IN       VARCHAR2,
      tfn                  IN       VARCHAR2,
      campaign             IN       VARCHAR2,
      bill_amt             IN       NUMBER,
      pageprem             IN       VARCHAR2,
      pageamt              IN       NUMBER,
      premper              IN       NUMBER,
      grossamt             IN       NUMBER,
      adsizcolumn          IN       NUMBER,
      billcolumn           IN       NUMBER,
      specdiscper          IN       NUMBER,
      spacediscper         IN       NUMBER,
      billarea             IN       NUMBER,
      paidins              IN       NUMBER,
      dealrate             IN       NUMBER,
      deviation            IN       NUMBER,
      varient              IN       VARCHAR2,
      contractname         IN       VARCHAR2,
      dealtype             IN       VARCHAR2,
      cardname             IN       VARCHAR2,
      cardtype             IN       VARCHAR2,
      cardmonth            IN       VARCHAR2,
      cardyear             IN       VARCHAR2,
      cardno               IN       VARCHAR2,
      receiptno            IN       VARCHAR2,
      adscat3              IN       VARCHAR2,
      adscat4              IN       VARCHAR2,
      adscat5              IN       VARCHAR2,
      bgcolor              IN       VARCHAR2,
      bulletcode           IN       VARCHAR2,
      bulletprm            IN       NUMBER,
      material             IN       VARCHAR2,
      receiptdate          IN       DATE := NULL,
      prevcioid            IN       VARCHAR2 := NULL,
      prevreceipt          IN       VARCHAR2 := NULL,
      prev_ga              IN       NUMBER := NULL,
      varient_name         IN       VARCHAR2 := NULL,
      region1              IN       VARCHAR2 := NULL,
      coltype              IN       VARCHAR2,
      logo_h               IN       VARCHAR2,
      logo_w               IN       VARCHAR2,
      logo_col             IN       VARCHAR2,
      logo_uom             IN       VARCHAR2,
      retainer1            IN       VARCHAR2,
      addagencyrate        IN       VARCHAR2,
      mobileno             IN       VARCHAR2,
      addlamt              IN       VARCHAR2,
      retamt               IN       VARCHAR2,
      retper               IN       VARCHAR2,
      cashrecieved         IN       NUMBER,
      ciragency_v          IN       VARCHAR2,
      cirrate_v            IN       VARCHAR2,
      ciredition_v         IN       VARCHAR2,
      cirpublication_v     IN       VARCHAR2,
      ciragencysubcode_v   IN       VARCHAR2,
      bartertype           IN       VARCHAR2,
      CASHDISCOUNT_V IN VARCHAR2,
CASHDISCOUNTPER_V IN VARCHAR2,
attach1 in varchar2,
attach2 in varchar2,
drpdiscprem in varchar2,
doctype_v in varchar2,
CHKTRADE IN VARCHAR2,
sharepub_p in varchar2,
fmginsert in varchar2,
chkno in VARCHAR2,
chkdate in date:=null,
chkamt in VARCHAR2,
chkbankname in varchar2,
ourbank    in varchar2,
DEALERPANEL_P in VARCHAR2,
DEALERH_P in FLOAT,
DEALERW_P in FLOAT,
DEALERTYPE_P in VARCHAR2,
multiselect in VARCHAR2,
AGREEDRATE_ACTIVE NUMBER,
AGREEDAMT_ACTIVE NUMBER,
grossamtlocal_p number,
billamtlocal_p number,
      p_error              OUT      VARCHAR2
   )
   AS
      sccode   VARCHAR2 (50);
      agencytype1 varchar2(20);
       error1 varchar2(100);
       rate_auth varchar2(2);
       bk_audit varchar2(2);
       auditn varchar2(50);
       username_v varchar2(50);
       roleid_v varchar2(20);
       RELAUTHREQ varchar2(1);
   BEGIN
   agencytype1:=agencytype;
   if agencytype is null then
    select "Agency_Type_Code" into agencytype1 from agency_mast where "code_subcode"=agencycode;
   end if;
   select RATE_AUTHORIZATION,"audit",RELAUTHREQON into rate_auth,bk_audit,RELAUTHREQ from preferrences where "comp_code"=compcode;
      -- BEGIN
           --SELECT distinct "scheme_id" INTO sccode FROM SCHEME_MASTER WHERE "Scheme_Name"=LTRIM(RTRIM(scheme1)) AND ("Comp_code"=compcode);
          -- EXCEPTION WHEN NO_DATA_FOUND THEN NULL ;
      -- END;
     select "username",ROLEID into username_v,roleid_v from login where "userid"=userid;   
    if roleid_v!='SE0' AND RELAUTHREQ != 'A' then 
        IF RELAUTHREQ = 'D' THEN
            if rate_auth='Y' and bk_audit='y' and agreedamt is null then
               
                auditn:=username_v;
            else
                auditn:=audit1;    
            end if;
        ELSE
        
            auditn:=username_v;    
        END IF;    
    else
     auditn:=audit1; 
    end if;    
      sccode := scheme1;
  
     
      /*INSERT INTO tbl_booking_mast
                  ("date_time", "branch", "booked_by", "cio_booking_id",
                   "prev_booking", "applied_by", "audit", "RO_No",
                   "RO_Date", "Caption", "bill_status", "ro_status",
                   "Agency_code", "Agency_address", "Client_code",
                   "Client_address", "Agency_sub_code", "Dockit_no",
                   "Executive_code", "Executive_zone", "Product_code",
                   "Brand_code", "Key_no", "Bill_remarks", "Print_remark",
                   "Package_code", "No_of_insertion", "Insertion_date",
                   "Repeating_day", "Ad_type_code", "Ad_cat_code",
                   "Ad_sub_cat_code", "Color_code", "Uom_code",
                   "Page_position_code", "Page_type_code", "Page_no",
                   "Ad_size_type_code", "Ad_size_height", "Ad_size_width",
                   "Rate_code", "Scheme_type_code", "Currency_code",
                   "Agrred_rate", "Agreed_amount", "Special_discount",
                   "Space_discount", "Special_charges", "Comp_code",
                   "Userid", "Agency_status", "Agency_type", "Agency_pay",
                   "Agency_credit", "Total_area", "Card_rate",
                   "Card_amount", "Discount", "Discount_per", "Bill_cycle",
                   "Revenue_center", "Bill_pay", "Bill_height",
                   "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add",
                   "Trade_disc", "Agency_out", "Box_code", "Box_no",
                   "Box_agency", "Box_client", "Box_address",
                   "Booking_type", "Tfn", "Coupan_ad", "Campaign",
                   "Bill_amount", "Page_prem", "Page_amount", "Prem_per",
                   "Gross_amount", "Ad_size_column", "Bill_column",
                   "Bill_area", "Special_disc_per", "Space_disc_per",
                   "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                   "Contract_name", "Contract_type", "Card_name",
                   "Card_type", "Card_month", "Card_year", "Card_number",
                   "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5",
                   "Bg_color", "Bullet_code", "Bullet_premium",
                   "Material_status", "Receipt_date", "prev_cioid",
                   "prev_receipt", "prev_grossamt", "Region", "Variant",
                   "Colortype", "Logo_H", "Logo_W", "Logo_color",
                   "Logo_Uom", "Creation_datetime", "RETAINER",
                   "ADD_AGENCY_COMM", mobileno, add_agency_comm_amt,
                   retainer_comm, retainer_comm_amt, cash_recieved,
                   ciragency, cirrate, ciredition, cirpublication,
                   ciragency_subcode, barter_type
                  )
           VALUES (date_time, branch, booked_by, ciobookid,
                   prevbook, approvedby, audit1, rono,
                   rodate, caption, billstatus, rostatus,
                   agency, agencyaddress, client,
                   clientaddresses, agencycode, dockitno,
                   execname, execzone, product,
                   brand, keyno, billremark, printremark,
                   package1, insertion, startdate,
                   repeatdate, adtype1, adcategory,
                   subcategory, color, uom,
                   pageposition, pagetype1, pageno,
                   adsizetype, adsizheight, adsizwidth,
                   ratecode11, sccode, currency,
                   agreedrate, agreedamt, spedisc,
                   spacedisx, specialcharges, compcode,
                   userid, agencystatus, agencytype, paymode,
                   agenccredit, totarea, cardrate,
                   cardamount, discount, discountper, billcycle,
                   revenuecenter, billpay, billheight,
                   billwidth, billto, invoices, vts, billaddress,
                   tradedisc, agencyout, boxcode, boxno,
                   boxagency, boxclient, boxaddress,
                   bookingtype, tfn, coupan, campaign,
                   bill_amt, pageprem, pageamt, premper,
                   grossamt, adsizcolumn, billcolumn,
                   billarea, specdiscper, spacediscper,
                   paidins, dealrate, deviation, varient,
                   contractname, dealtype, cardname,
                   cardtype, cardmonth, cardyear, cardno,
                   receiptno, adscat3, adscat4, adscat5,
                   bgcolor, bulletcode, bulletprm,
                   material, receiptdate, prevcioid,
                   prevreceipt, prev_ga, region1, varient_name,
                   coltype, logo_h, logo_w, logo_col,
                   logo_uom, SYSDATE, retainer1,
                   addagencyrate, mobileno, addlamt,
                   retper, retamt, cashrecieved,
                   ciragency_v, cirrate_v, ciredition_v, cirpublication_v,
                   ciragencysubcode_v, bartertype
                  );
                  */
                  INSERT INTO tbl_booking_mast_g
                  (DATE_TIME, BRANCH, BOOKED_BY, CIO_BOOKING_ID,
                   PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO,
                   RO_DATE, CAPTION, BILL_STATUS, RO_STATUS,
                   AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE,
                   CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO,
                   EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE,
                   BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK,
                   PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE,
                   REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE,
                   AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE,
                   PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO,
                   AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH,
                   RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE,
                   AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT,
                   SPACE_DISCOUNT, SPECIAL_CHARGES, COMP_CODE,
                   USERID, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY,
                   AGENCY_CREDIT, TOTAL_AREA, CARD_RATE,
                   CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE,
                   REVENUE_CENTER, BILL_PAY, BILL_HEIGHT,
                   BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD,
                   TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO,
                   BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS,
                   BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN,
                   BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER,
                   GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN,
                   BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER,
                   PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE,
                   CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME,
                   CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER,
                   RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5,
                   BG_COLOR, BULLET_CODE, BULLET_PREMIUM,
                   MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID,
                   PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT,
                   COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR,
                   LOGO_UOM, CREATION_DATETIME, RETAINER,
                   ADD_AGENCY_COMM, MOBILENO, ADD_AGENCY_COMM_AMT,
                   RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED,
                   CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION,
                   CIRAGENCY_SUBCODE, BARTER_TYPE, SESID,CASHDISCOUNT,CASHDISCTYPE,ATTACHMENT1,ATTACHMENT2,DISC_PREMIUM,DOCTYPE,CHKTRADEDISC,
                   CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE, ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT, LOCALGROSSAMT, LOCALBILLAMT
                  )
           VALUES (date_time, branch, booked_by, ciobookid,
                   prevbook, approvedby, auditn, rono,
                   rodate, caption, billstatus, rostatus,
                   agency, agencyaddress, client,
                   clientaddresses, agencycode, dockitno,
                   execname, execzone, product,
                   brand, keyno, billremark, printremark,
                   package1, insertion, startdate,
                   repeatdate, adtype1, adcategory,
                   subcategory, color, uom,
                   pageposition, pagetype1, pageno,
                   adsizetype, adsizheight, adsizwidth,
                   ratecode11, sccode, currency,
                   agreedrate, agreedamt, spedisc,
                   spacedisx, specialcharges, compcode,
                   userid, agencystatus, agencytype1, paymode,
                   agenccredit, totarea, cardrate,
                   cardamount, discount, discountper, billcycle,
                   revenuecenter, billpay, billheight,
                   billwidth, billto, invoices, vts, billaddress,
                   tradedisc, agencyout, boxcode, boxno,
                   boxagency, boxclient, boxaddress,
                   bookingtype, tfn, coupan, campaign,
                   bill_amt, pageprem, pageamt, premper,
                   grossamt, adsizcolumn, billcolumn,
                   billarea, specdiscper, spacediscper,
                   paidins, dealrate, deviation, varient,
                   contractname, dealtype, cardname,
                   cardtype, cardmonth, cardyear, cardno,
                   receiptno, adscat3, adscat4, adscat5,
                   bgcolor, bulletcode, bulletprm,
                   material, receiptdate, prevcioid,
                   prevreceipt, prev_ga, region1, varient_name,
                   coltype, logo_h, logo_w, logo_col,
                   logo_uom, SYSDATE, retainer1,
                   addagencyrate, mobileno, addlamt,
                   retper, retamt, cashrecieved,
                   ciragency_v, cirrate_v, ciredition_v, cirpublication_v,
                   ciragencysubcode_v, bartertype,USERENV ('sessionid'),CASHDISCOUNT_V,CASHDISCOUNTPER_V,attach1,attach2,drpdiscprem,doctype_v,CHKTRADE
                  ,chkno,chkdate,chkamt,chkbankname,ourbank,DEALERPANEL_P,
DEALERH_P,
DEALERW_P,
DEALERTYPE_P,AGREEDRATE_ACTIVE,
AGREEDAMT_ACTIVE,grossamtlocal_p,billamtlocal_p);
                  IF sharepub_p is not null then
                        insert_sharepub_details(sharepub_p,ciobookid,'INSERT',error1);
                  end if;
                  
                  if fmginsert is not null then
                    insert_fmgTrans_details(fmginsert,ciobookid,'INSERT',error1);   
                  end if;   
                  if multiselect is not null then
                    insert_multiexec_details(userid,compcode,multiselect,ciobookid,'INSERT',error1);
                  end if;  
                 
   EXCEPTION
      WHEN OTHERS
      THEN
         p_error := 'Error :' || SQLERRM;
         
         
         
   END insertintobooking_p;
END insertintobooking;
/

/*********************************************************************************************************************************************************************************************************************/

DROP PROCEDURE HT18JULY.INSERTREMARKS_WEB;

CREATE OR REPLACE PROCEDURE insertRemarks_web
(
remarks in varchar2,
userid in varchar2,
appstatus in varchar2,
insertid in varchar2,
cioid in varchar2
)
is
countmain number;
countapp number;
countreject number;
username_v varchar2(50);
begin
if insertid is null then
update tbl_booking_mast set APP_STATUS=appstatus,APP_REMARKS=remarks,APP_DATE=SYSDATE,APP_USER=userid  where "cio_booking_id"=cioid;
update tbl_booking_INSERT set APP_STATUS=appstatus,APP_REMARKS=remarks,APP_DATE=SYSDATE,APP_USER=userid  where "Cio_Booking_Id"=cioid;
/*if appstatus = 'N' then
    update tbl_booking_mast set "audit"=null where "cio_booking_id"=cioid;
else 
 select "username" into username_v from login where "userid"=userid;
    update tbl_booking_mast set "audit"=username_v where "cio_booking_id"=cioid;    
end if;*/
else
update tbl_booking_INSERT set APP_STATUS=appstatus,APP_REMARKS=remarks,APP_DATE=SYSDATE,APP_USER=userid  where "Cio_Booking_Id"=cioid AND "Insert_Id"=insertid;
select count(*) into countmain from tbl_booking_INSERT where "Cio_Booking_Id"=cioid;
select count(*) into countapp from tbl_booking_INSERT where "Cio_Booking_Id"=cioid and APP_STATUS is not null;
    if countmain=countapp then
    select count(*) into countreject from tbl_booking_INSERT where "Cio_Booking_Id"=cioid and APP_STATUS ='N';
        if countreject=countmain then
        update tbl_booking_mast set APP_STATUS='N',APP_DATE=SYSDATE,APP_USER=userid  where "cio_booking_id"=cioid;
        else
        update tbl_booking_mast set APP_STATUS='Y',APP_DATE=SYSDATE,APP_USER=userid  where "cio_booking_id"=cioid;
        end if;
    end if;

end if;
commit;
end;
/

/***********************************************************end*********************************************************************************************************************************************************************/


//////////////////5410//////////////mimoh 1nov 2011//////////////////end///////////////////////

/*======================================= ISSUE 0005059 (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE PACKAGE getCenter_Agency Is



Type T_Accounts_Cursor Is Ref Cursor;
Procedure getCenter_Agency_P (Compcode In Varchar2,
agency In Varchar2,
P_Accounts Out T_Accounts_Cursor);

End getCenter_Agency;
/

CREATE OR REPLACE PACKAGE BODY getCenter_Agency Is




Procedure getCenter_Agency_P (Compcode In Varchar2,
agency In Varchar2,
P_Accounts Out T_Accounts_Cursor) As

Begin

Open P_Accounts For
select "pub_center",(select "Add1" || '^' || "Phone1" || '^' || "Phone2" from pub_cent_mast where "Pub_Cent_name"=branch_mst."pub_center") from branch_mst where "Comp_Code"=Compcode 
and  "Branch_Code"=agency;
--(select "retainer_code" from login where "Agency_code"=agency and "COM_CODE"=Compcode and "retainer_code" <>'0'  and rownum<=1);




End getCenter_Agency_P;

End getCenter_Agency;
/

/*======================================End of ISSUE 0005059 (Kuldeep Bhati) ==============================*/


/****************************Issue No.0005410 Lata********************************/
CREATE OR REPLACE PROCEDURE getperiodDate_Edition(Compcode In Varchar2,
pkgname In Varchar2,
dateday In date,P_Accounts OUT Cur_Type_New1.cursor_type)
 is
VCODE varchar2(10);
day_p NUMBER;
month_p NUMBER;
fcycle_p NUMBER;
scycle_p NUMBER;
    BEGIN
        begin
        select "ValidationCode" into VCODE from PREODICITY_MASTER where "Comp_Code"=Compcode and "Preodicity_Code"=(select "Preodicity_Code" from edition_mast where "Comp_Code"=Compcode and ltrim(rtrim("Edition_Alias"))=ltrim(rtrim(pkgname)));
            EXCEPTION
                           WHEN NO_DATA_FOUND THEN  NULL;
                         END;

                         
select to_char(dateday,'dd') into  day_p from dual;     
select to_char(dateday,'mm') into  month_p from dual;   
IF VCODE ='2' OR VCODE = '3' OR VCODE = '4' OR VCODE = '6' OR VCODE = '7'  THEN      
    select "Date_Edition","AdditionalDate_Edit" INTO fcycle_p,scycle_p from edit_date  WHERE "Comp_Code"=Compcode and ltrim(rtrim("Edition_Alias"))= ltrim(rtrim(pkgname));
    -- VCODE = 6 BI-MONTHLY AND VCODE = 7 QUARTLY     
    IF VCODE  = 2 THEN -- MONTHLY
        IF fcycle_p = day_p THEN
            OPEN P_Accounts FOR
            SELECT '0' as MESSAGE FROM DUAL;
        ELSE
            OPEN P_Accounts FOR
            SELECT 'NOT A VALID DATE' AS MESSAGE FROM DUAL;    
        END IF;
    ELSIF VCODE  = 6   THEN -- BI-MONTHLY
        IF fcycle_p = day_p AND (scycle_p = month_p or to_char(add_months(to_date(fcycle_p || '/' || scycle_p || '/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),2),'mm')=month_p or to_char(add_months(to_date(fcycle_p || '/' || scycle_p ||'/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),4),'mm')=month_p or to_char(add_months(to_date(fcycle_p || '/' || scycle_p || '/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),6),'mm')=month_p or to_char(add_months(to_date(fcycle_p || '/' || scycle_p || '/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),8),'mm')=month_p or to_char(add_months(to_date(fcycle_p || '/' || scycle_p || '/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),10),'mm')=month_p) THEN
            OPEN P_Accounts FOR
            SELECT '0' as MESSAGE FROM DUAL;
        ELSE
            OPEN P_Accounts FOR
            SELECT 'NOT A VALID DATE' AS MESSAGE FROM DUAL;    
        END IF;
    ELSIF VCODE  = 7   THEN -- QUARTLY
    DBMS_OUTPUT.PUT_LINE('VCODE');
    DBMS_OUTPUT.PUT_LINE(fcycle_p);
    DBMS_OUTPUT.PUT_LINE(day_p);
     DBMS_OUTPUT.PUT_LINE(scycle_p);
    DBMS_OUTPUT.PUT_LINE(month_p);
        IF fcycle_p = day_p AND (scycle_p = month_p or to_char(add_months(to_date(fcycle_p || '/' || scycle_p || '/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),3),'mm')=month_p or to_char(add_months(to_date(fcycle_p || '/' || scycle_p ||'/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),6),'mm')=month_p or to_char(add_months(to_date(fcycle_p || '/' || scycle_p || '/'||to_char(sysdate,'yyyy'),'dd-mm-yyyy'),9),'mm')=month_p ) THEN
            OPEN P_Accounts FOR
            SELECT '0' as MESSAGE FROM DUAL;
        ELSE
            OPEN P_Accounts FOR
            SELECT 'NOT A VALID DATE' AS MESSAGE FROM DUAL;    
        END IF;             
    ELSIF VCODE = 3 THEN --YEARLY
         IF fcycle_p = day_p  AND scycle_p = month_p THEN
            OPEN P_Accounts FOR
            SELECT '0' AS MESSAGE  FROM DUAL;
        ELSE
            OPEN P_Accounts FOR
            SELECT 'NOT A VALID DATE' AS MESSAGE  FROM DUAL;    
        END IF;
    ELSIF VCODE = 4 THEN --FORTNIGHTLY
         IF fcycle_p = day_p  OR scycle_p = month_p THEN
            OPEN P_Accounts FOR
            SELECT '0' AS MESSAGE  FROM DUAL;
        ELSE
            OPEN P_Accounts FOR
            SELECT 'NOT A VALID DATE' AS MESSAGE  FROM DUAL;    
        END IF;
    ELSE
    OPEN P_Accounts FOR
    SELECT '0' AS MESSAGE  FROM DUAL;
    END IF;   
else 
     OPEN P_Accounts FOR
    SELECT '0' AS MESSAGE  FROM DUAL;
   
END IF;                   
END ;
/


/*************************END ***************************/

/*======================================ISSUE 0005259 (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE  PROCEDURE GETRETAINER_ROFILE
    (
        COMPCODE1   IN  VARCHAR2,
        PUBCENTER   IN  VARCHAR2,
         center in varchar2,
        p_accounts  out CUR_TYPE_NEW1.CURSOR_TYPE
    )

    AS

    BEGIN
       
       -- SELECT "Retain_Name","Retain_Code" FROM RETAINERMASTER WHERE "Comp_Code"=COMPCODE1;-- AND "pubcent_code"=PUBCENTER;
       if center ='0' or center is null then
        OPEN p_accounts for
         SELECT "Retain_Name","Retain_Code" FROM RETAINERMASTER WHERE "Comp_Code"=COMPCODE1 AND "Retain_Name" LIKE  '%'|| PUBCENTER ||'%'
          --and (SELECT  "Status_Name" FROM TBLSTATUS WHERE "Status_Code" =(select STATUS_NAME from ret_status_detail where
            --"Retain_Code"=RETAINERMASTER."Retain_Code" and rownum <=1 AND sysdate between "FROM_DATE" and "TO_DATE"))='ACTIVE'
         ORDER BY "Retain_Name";
       else
        OPEN p_accounts for
         SELECT "Retain_Name","Retain_Code" FROM RETAINERMASTER WHERE "Comp_Code"=COMPCODE1 AND "Retain_Name" LIKE  '%'|| PUBCENTER ||'%'
            and "Dist_Code"=(select "Dist_Code" from branch_mst where "Branch_Code"=center) -- and (SELECT  "Status_Name" FROM TBLSTATUS WHERE "Status_Code" =(select STATUS_NAME from ret_status_detail where
           -- "Retain_Code"=RETAINERMASTER."Retain_Code" and rownum <=1 AND sysdate between "FROM_DATE" and "TO_DATE"))='ACTIVE'
         ORDER BY "Retain_Name";-- AND "pubcent_code"=PUBCENTER;
       end if;
      
    END;
/


CREATE OR REPLACE procedure websp_getExec_rofile(
compcode in varchar2,
execname in varchar2,
value in varchar2,
center in varchar2,
P_Accounts out CUR_TYPE_NEW1.CURSOR_TYPE
)
IS
BEGIN
if center is not null and center!='0' then
    if(value <> '3')then
    open P_Accounts for
    select "Exe_no" as "exe_no","Exec_name" as "exec_name" from exec_mast where "comp_code"=compcode and  "Exec_name" like '%' || execname||'%'
    and "dist_code"=(select "Dist_Code" from branch_mst where "Branch_Code"=center) order by "Exec_name";
    end if;
    if(value='3') then
    open P_Accounts for
    select "Exe_no" as "exe_no","Exec_name" as "exec_name" from exec_mast where "comp_code"=compcode and "Exe_no"=execname  order by "Exec_name";
    end if;
else
    if(value <> '3')then
    open P_Accounts for
    select "Exe_no" as "exe_no","Exec_name" as "exec_name" from exec_mast where "comp_code"=compcode and  "Exec_name" like '%' || execname||'%' 
     order by "Exec_name";
    end if;
    if(value='3') then
    open P_Accounts for
    select "Exe_no" as "exe_no","Exec_name" as "exec_name" from exec_mast where "comp_code"=compcode and "Exe_no"=execname  order by "Exec_name";
    end if;
end if;
END;
/

CREATE OR REPLACE procedure bindagencyforbooking_rofile(compcode in varchar2,
userid in varchar2,agency in varchar2,
pubcenter     in      varchar2,
p_Accounts out cur_type_new1.cursor_type
) as

begin
if pubcenter = '0' or pubcenter is null then

open p_Accounts for
select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
AS CITYNAME from Agency_mast where "Comp_Code"=compcode
and "Agency_Name" like '%'||agency||'%'  order by "Agency_Name" ;

else
open p_Accounts for
select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
AS CITYNAME from Agency_mast where "Comp_Code"=compcode
and "Agency_Name" like '%'||agency||'%' and "Dist_Code"=(select "Dist_Code" from branch_mst where "Branch_Code"=pubcenter) order by "Agency_Name" ;
end if;
end;
/

/*======================================End of ISSUE 0005259 (Kuldeep Bhati) ==============================*/

/**************************Issue 0005510 ********************************************************/
CREATE OR REPLACE PROCEDURE fetchMailId_ro
(
bkid IN varchar2,
P_Accounts OUT CUR_TYPE_NEW1.CURSOR_TYPE

)
AS
ret varchar(50);
exec1 varchar(50);
BEGIN
select RETAINER,"Executive_code" INTO ret,exec1 from tbl_booking_mast where "cio_booking_id"=bkid;

    if(ret ='' or ret is null) THEN
        BEGIN
        OPEN P_Accounts  FOR
        select EXEC_EMAILID from exec_mast where "Exe_no"=exec1;
        END;
	else 
        BEGIN
        OPEN P_Accounts  FOR
        select "EmailID" from retainermaster where "Retain_Code"=ret;
        END;
      END IF;

END;
/
/************************** End Issue 0005510 ********************************************************/



/************************************************************** 0005347* ******************************************/


DROP PACKAGECLIENTSAVE;

CREATE OR REPLACE PACKAGE clientsave
IS

   PROCEDURE clientsave_p (
      compcode       IN   VARCHAR2,
      custcode       IN   VARCHAR2,
      custname       IN   VARCHAR2,
      custalias      IN   VARCHAR2,
      add1           IN   VARCHAR2,
      street         IN   VARCHAR2,
      citycode       IN   VARCHAR2,
      zip            IN   VARCHAR2,
      dist           IN   VARCHAR2,
      state          IN   VARCHAR2,
      country        IN   VARCHAR2,
      phone1         IN   VARCHAR2,
      phone2         IN   VARCHAR2,
      fax            IN   VARCHAR2,
      emailid        IN   VARCHAR2,
      url1            IN   VARCHAR2,
      vats           IN   VARCHAR2,
      servicetax1     IN   VARCHAR2,
      pan1            IN   VARCHAR2,
      creditdays     IN   VARCHAR2,
      paymodecode    IN   VARCHAR2,
      custstatus     IN   VARCHAR2,
      statusreason   IN   VARCHAR2,
      alert          IN   VARCHAR2,
      userid         IN   VARCHAR2,
      zone           IN   VARCHAR2,
      region1         IN   VARCHAR2,
      crdlimit       IN   VARCHAR2,
      flag1           IN   VARCHAR2,
      rategroup      IN   VARCHAR2,
      clientcat      IN   VARCHAR2,
      taluka1        IN   VARCHAR2,
      agency_sav  in varchar2
   );
END clientsave;
/



DROP PACKAGE BODY CLIENTSAVE;

CREATE OR REPLACE PACKAGE BODY clientsave
IS
   PROCEDURE clientsave_p (
      compcode       IN   VARCHAR2,
      custcode       IN   VARCHAR2,
      custname       IN   VARCHAR2,
      custalias      IN   VARCHAR2,
      add1           IN   VARCHAR2,
      street         IN   VARCHAR2,
      citycode       IN   VARCHAR2,
      zip            IN   VARCHAR2,
      dist           IN   VARCHAR2,
      state          IN   VARCHAR2,
      country        IN   VARCHAR2,
      phone1         IN   VARCHAR2,
      phone2         IN   VARCHAR2,
      fax            IN   VARCHAR2,
      emailid        IN   VARCHAR2,
      url1            IN   VARCHAR2,
      vats           IN   VARCHAR2,
      servicetax1     IN   VARCHAR2,
      pan1            IN   VARCHAR2,
      creditdays     IN   VARCHAR2,
      paymodecode    IN   VARCHAR2,
      custstatus     IN   VARCHAR2,
      statusreason   IN   VARCHAR2,
      alert          IN   VARCHAR2,
      userid         IN   VARCHAR2,
      zone          IN   VARCHAR2,
      region1         IN   VARCHAR2,
      crdlimit       IN   VARCHAR2,
      flag1           IN   VARCHAR2,
      rategroup      IN   VARCHAR2,
      clientcat      IN   VARCHAR2,
      taluka1        IN   VARCHAR2,
      agency_sav  in varchar2
   )
   AS
      countrycode   VARCHAR2 (100);
      fatchstatus   VARCHAR2 (100);
   BEGIN
            begin
                 select "Status_Name" into fatchstatus from tblstatus where "Status_Code"=(select "CUST_STATUS" from status_detail_client where "cust_code"=custcode and "comp_code"=compcode and rownum<=1) and rownum<=1;
               
            EXCEPTION
                   WHEN NO_DATA_FOUND THEN  NULL;
            END;
      --SELECT "Country_Code"
        --INTO countrycode
        --FROM count_mst
       --WHERE "Country_Name" = country;
   --insert into test1(vstring,vstring2) values('clientsave '||' flag1 '||flag1,'compcode '||compcode||' custcode '||custcode||' servicetax1 '||servicetax1||' pan1 '||pan1); commit;
      IF (flag1 = '1')
      THEN
         UPDATE cust_mast
            SET "Zone_code" = zone,
                "Region_code" = region1,
                "Credit_limit" = crdlimit,
                "Cust_Name" = custname,
                "Cust_Alias" = custalias,
                "Add1" = add1,
                "Stree" = street,
                "City_Code" = citycode,
                "Zip" = zip,
                "Dist_Code" = dist,
                "State_Code" = state,
                "Country_Code" = country,
                "phone1" = phone1,
                "Phone2" = phone2,
                "Fax" = fax,
                "EmailID" = emailid,
                "URL" = url1,
                "No_of_VTS" = vats,
                "ST_ACC_No" = servicetax1,
                "PAN_No" = pan1,
                "Credit_Days" = creditdays,
                "Pay_Mode_Code" = paymodecode,
                "Cust_Status" = custstatus,
                "Status_Reason" = statusreason,
                "Remarks" = alert,
                "Rate_Gr_Code" = rategroup,
                "Client_category" = clientcat,
                "TALUKA"=taluka1,
                AGENCY_CODE=agency_sav
          WHERE "Comp_Code" = compcode
            AND "Cust_Code" = custcode;
           -- AND "UserId" = userid;

         COMMIT;
      END IF;

      IF (flag1 = '0')
      THEN
         INSERT INTO cust_mast
                     ("Comp_Code", "Cust_Code", "Cust_Name", "Cust_Alias",
                      "Add1", "Stree", "City_Code", "Zip", "Dist_Code",
                      "State_Code", "Country_Code", "phone1", "Phone2",
                      "Fax", "EmailID", "URL", "No_of_VTS", "ST_ACC_No",
                      "PAN_No", "Credit_Days", "Pay_Mode_Code",
                      "Cust_Status", "Status_Reason", "Remarks", "UserId",
                      "Creation_Datetime", "Zone_code", "Region_code",
                      "Credit_limit", "Rate_Gr_Code", "Client_category","TALUKA",AGENCY_CODE
                     )
              VALUES (compcode, custcode, custname, custalias,
                      add1, street, citycode, zip, dist,
                      state, country, phone1, phone2,
                      fax, emailid, url1, vats, servicetax1,
                      pan1, creditdays, paymodecode,
                      fatchstatus, statusreason, alert, userid,
                      SYSDATE, zone, region1,
                      crdlimit, rategroup, clientcat,taluka1,agency_sav
                     );
      END IF;
   END clientsave_p;
END clientsave;
/

/***************************************************************************** 0005347 *********************************


///////////////////////////////////////////// 08/11/2011 issue no 4890,5544////////////////////////////////////////

CREATE OR REPLACE PROCEDURE HT18JULY.Ro_Report
(pcompcode      in varchar2,
 pdateformat    in varchar2,
 puserid        in varchar2,
 chk_access     in varchar2,
 pfromdate      in varchar2,
 pdateto        in varchar2,
 pprint_cent    in varchar2,
 pagency        in varchar2,
 pbranch        in varchar2,
 pdistrict      in varchar2,
 ptaluka        in varchar2,
 pro_doc_status in varchar2,
 ppay_mode      in varchar2,
 pexecutive     in varchar2,
 pretainer      in varchar2,
 det_summry     in varchar2,
 age_exeret     in varchar2,
 pad_type       in varchar2,
 pad_cat        in varchar2,
 ptype          in varchar2,
 p_accounts     OUT Cur_Type_New1.cursor_type,
 p_accounts1    OUT Cur_Type_New1.cursor_type)
IS
query1      varchar2(10000);
vvar        varchar2(4000);
vvar_sum    varchar2(4000);
BEGIN
    if(age_exeret='1')then/*fot agency*/
        if(det_summry='1')then/*for detail*/
            query1:='select distinct a."cio_booking_id" as  "BOOKING_ID",b."Agency_Name" AS "AGENCY", 
            nvl((select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") ,(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER )) as "EXE_RET",
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            c."Adv_Cat_Name" as "Ad_Cat",
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT",
            min(TO_CHAR(i."Insert_Date",'''||pdateformat||''')) as "Publish_Date",a.RO_COMMENT as RO_COMMENT
            from tbl_booking_mast a ,tbl_booking_insert i ,agency_mast b,adv_cat_mast c where
            a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Agency_sub_code"=b."code_subcode"';
        else/* for summary*/
            query1:='select DISTINCT b."Agency_Name" AS "AGENCY",
            b."Dist_Code"  as "DISTRICT",
            --old version
            --a."branch" as "BRANCH",
            --new version
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
          
            SUM(DECODE(RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,agency_mast b/*,adv_cat_mast c*/
            where  
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Agency_sub_code"=b."code_subcode"';
        end if;
    else/* for  executive/retainer*/
        if(det_summry='1')then/*for detail*/
           /* query1:='select a."cio_booking_id" as  "BOOKING_ID",
            b."Agency_Name" AS "AGENCY",
            --(select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") AS "EXECUTIVE",
            --(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER ) AS "RETAINER",
            nvl((select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") ,(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER )) as "EXE_RET",
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT"
            from tbl_booking_mast a ,agency_mast b where
            a."Comp_code"='''||pcompcode||''' AND
            a."Agency_sub_code"=b."code_subcode"';*/
              if(age_exeret='2')then
            query1:='select distinct
            a."cio_booking_id" as  "BOOKING_ID",
            b."Agency_Name" AS "AGENCY",           
            EXEC_MAST."Exec_name"  as "EXE_RET",      
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            c."Adv_Cat_Name" as "Ad_Cat",            
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT",
            min(TO_CHAR(i."Insert_Date",'''||pdateformat||''')) as "Publish_Date",a.RO_COMMENT as RO_COMMENT
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,EXEC_MAST,agency_mast b ,adv_cat_mast c
            where a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Executive_code"=exec_mast."Exe_no" AND 
             a."Agency_sub_code"=b."code_subcode"';
         else
          query1:='select distinct
            a."cio_booking_id" as  "BOOKING_ID",
            b."Agency_Name" AS "AGENCY",  
             RETAINERMASTER."Retain_Name"     as "EXE_RET",
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            c."Adv_Cat_Name" as "Ad_Cat",            
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT",
            min(TO_CHAR(i."Insert_Date",'''||pdateformat||''')) as "Publish_Date",a.RO_COMMENT as RO_COMMENT
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER,agency_mast b ,adv_cat_mast c
            where a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            RETAINERMASTER."Retain_Code"=a.RETAINER AND 
             a."Agency_sub_code"=b."code_subcode"';
            end if;
        else/* for summary*/
         
         if(age_exeret='2')then
            query1:='select distinct  
             EXEC_MAST."Exec_name"  as "EXE_RET",      
             EXEC_MAST."dist_code"  as "DISTRICT",
            
             --old version
            --a."branch" as "BRANCH",
            --new version
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
             
            SUM(DECODE(a.RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(a.RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(a.RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(a.RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,EXEC_MAST ,agency_mast b /*,adv_cat_mast c*/
            where  
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Executive_code"=exec_mast."Exe_no" 
            and a."Agency_sub_code"=b."code_subcode"';
         else
          query1:='select distinct 
            
             RETAINERMASTER."Retain_Name"     as "EXE_RET",
           
             RETAINERMASTER."Dist_Code"   as "DISTRICT",
             --old version
            --a."branch" as "BRANCH",
            --new version
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
           
            SUM(DECODE(a.RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(a.RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(a.RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(a.RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER ,agency_mast b/*,adv_cat_mast c*/
            where 
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            RETAINERMASTER."Retain_Code"=a.RETAINER 
            and a."Agency_sub_code"=b."code_subcode"';
            end if;
        end if;
    end if;

    if(pfromdate is not null and pdateto is not null)then
        query1:=query1||' and a."date_time" between '''||pfromdate||''' and '''||pdateto||''' ';
    end if;
    
    if(pad_type is not null)then
        query1:=query1||' and a."Ad_type_code" = '''||pad_type||''' ';
    end if;

    if(pad_cat is not null)then
        query1:=query1||' and a."Ad_cat_code" = '''||pad_cat||''' ';
    end if;
    
    if(pagency is not null)then
        query1:=query1||' and a."Agency_code" = '''||pagency||''' ';
    end if;    
  --new version 

   if(pprint_cent is not null)then
        query1:=query1||' and a."branch" IN  (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code"  and "pub_center"='''||pprint_cent||''') ';
    end if;

    if(pbranch is not null)then
        query1:=query1||'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''||pbranch||''') ';
    end if;
    
--old version
   /* 
    if(pprint_cent is not null)then
        query1:=query1||' and a."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE a."branch"="Branch_Name" and "pub_center"='''||pprint_cent||''') ';
    end if;


    if(pbranch is not null)then
        query1:=query1||' and a."branch"='''||pbranch||'''';
    end if;
*/
    
    if(pdistrict is not null)then
        if(age_exeret='1')then
            query1:=query1||' and b."Dist_Code" = '''||pdistrict||''' ';
         elsif(age_exeret='2')then
            query1:=query1||' and (a."Executive_code" IS NOT NULL AND a."Executive_code" in(select exec_mast."Exe_no" from exec_mast  where EXEC_MAST."dist_code"='''||pdistrict||''' ) ) ';
        else
            query1:=query1||' and  (a.RETAINER IS NOT NULL AND a.RETAINER IN(SELECT RETAINERMASTER."Retain_Code" FROM RETAINERMASTER WHERE RETAINERMASTER."Dist_Code"='''||pdistrict||''')) ';
        end if;
    end if;
    if(ptaluka is not null)then
        if(age_exeret='1')then
            query1:=query1||' and b.TALUKA = '''||ptaluka||''' ';
        elsif(age_exeret='2')then
            query1:=query1||' and (a."Executive_code" IS NOT NULL AND a."Executive_code" in(select exec_mast."Exe_no" from exec_mast  where EXEC_MAST."TALUKA"='''||ptaluka||'''  ) ) ';
        else
            query1:=query1||' and (a.RETAINER IS NOT NULL AND a.RETAINER IN(SELECT RETAINERMASTER."Retain_Code" FROM RETAINERMASTER WHERE RETAINERMASTER."TALUKA"='''||ptaluka||''' )) ';
        end if;
    end if;

    if(pro_doc_status is not null)then
        query1:=query1||' and a.RODOCSTATUS = '''||pro_doc_status||''' ';
    end if;

    if(ppay_mode is not null)then
        query1:=query1||' and a."Bill_pay" = '''||ppay_mode||''' ';
    end if;

    if(pexecutive is not null)then
        query1:=query1||' and a."Executive_code" = '''||pexecutive||''' ';
    end if;

    if(pretainer  is not null)then
        query1:=query1||' and a.RETAINER = '''||pretainer||''' ';
    end if;

--new version
  query1:=query1||' and a."branch" in(select lb.branch_code from login_branch_mast lb where  lb.user_code='''||puserid||''' and nvl(lb.user_flag,''N'')=''Y'') ' ;
--old version
   -- query1:=query1||' and a."branch" in(select branch_mst."Branch_Name" from branch_mst where branch_mst."Branch_Code" in (select lb.branch_code from login_branch_mast lb where  lb.user_code='''||puserid||''' and nvl(lb.user_flag,''N'')=''Y'')) ' ;

    if(ptype is not null)then
        if ptype='U' then
            query1:=query1||' and (i."Comp_Code"||i.bill_no||i.bill_date in(select /*+ (AD_OUTSTAND IND_OUT) */ o.comp_code||o.billno||o.billdt 
                        from ad_outstand o where o.comp_code=i."Comp_Code" and o.ag_main_code=b."Agency_Code" and 
                        o.ag_sub_code=b."SUB_Agency_Code" and o.billdt=i.bill_date and o.billno=i.bill_no 
                        group by o.comp_code,o.billno,o.billdt having sum(o.amount)>10) OR i.bill_no IS NULL ) ';
        else 
            query1:=query1||' and i."Comp_Code"||i.bill_no||i.bill_date in(select /*+ (AD_OUTSTAND IND_OUT) */ o.comp_code||o.billno||o.billdt 
                        from ad_outstand o where o.comp_code=i."Comp_Code" and o.ag_main_code=b."Agency_Code" and 
                        o.ag_sub_code=b."SUB_Agency_Code" and o.billdt=i.bill_date and o.billno=i.bill_no 
                        group by o.comp_code,o.billno,o.billdt having sum(o.amount)=0)';
        end if;                
    end if;
    
    if(det_summry!='1')then/*for summary*/
        if(age_exeret='1')then/*fot agency*/
            query1:=query1||' GROUP BY b."Agency_Name" ,b."Dist_Code"  ,a."branch"';
        elsif(age_exeret='2')then
            query1:=query1||' group by EXEC_MAST."Exec_name",EXEC_MAST."dist_code",a."branch"';
        else
            query1:=query1||' GROUP BY RETAINERMASTER."Retain_Name",RETAINERMASTER."Dist_Code",a."branch"';
        end if;
        else
        
        if(age_exeret='1')then/*fot agency*/
            query1:=query1||' GROUP BY a."cio_booking_id"  ,b."Agency_Name"   ,a."Executive_code",a.RETAINER,"Client_code",c."Adv_Cat_Name","RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT';
        elsif(age_exeret='2')then
            query1:=query1||' group by a."cio_booking_id"  ,b."Agency_Name",EXEC_MAST."Exec_name","Client_code",c."Adv_Cat_Name" ,"RO_No",RODOCSTATUS",a."Bill_amount",a.RO_COMMENT ';
        else
            query1:=query1||' GROUP BY a."cio_booking_id"  ,b."Agency_Name",RETAINERMASTER."Retain_Name","Client_code",c."Adv_Cat_Name" ,"RO_No",RODOCSTATUS",a."Bill_amount",a.RO_COMMENT';
        end if;
        
        
        
    end if;

 --   delete from searchtbl;
   -- insert into searchtbl values(query1);commit;


    OPEN p_accounts FOR query1;
    open p_accounts1 for
    select comp_mst."Comp_Name" from comp_mst where comp_mst."Comp_Code"=pcompcode;
END ;
/


////////////////////////////////////////////////// end of issue no 4890,5544/////////////////////////////////////////////////////////////////


/******************************* 9-nov-2011 Lata*****************************/
CREATE OR REPLACE FUNCTION getRate_Code(center varchar2,PKGCODE varchar2,adtype varchar2,ADCAT1 

varchar2,COL varchar2,currency varchar2,RATECHKDATE date,uom varchar2,INSERTIONNUM number,ADCAT2 

varchar2,ADCAT3 varchar2,ADCAT4 varchar2,ADCAT5 varchar2,premiumval varchar2,rCode varchar2,num number,LINE 

NUMBER,chkadon_p varchar2) RETURN varchar2 IS
tmpVar varchar2(500);

BEGIN

IF rCode='qbc' then

        IF num=0 then
          DBMS_OUTPUT.PUT_LINE('1');
             SELECT MAX(ROWID) into tmpvar FROM
                       rate_mast
                       WHERE "pub_center"=UPPER(center)
                       AND "Combin_Code" = PKGCODE
                       AND "Adv_Type_Code" = UPPER(adtype)
                       AND "Adv_Cat_Code" = ADCAT1
                       AND "Color" = COL
                       AND "Currency" = UPPER(currency)
                       AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                       AND "Uom" = UPPER(uom)
                       AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                       AND "Adv_subcat_code" = ADCAT2
                       AND "Ad_Subcat4" = ADCAT3
                       AND "Ad_Subcat5" = ADCAT4
                       AND "Ad_subcat6" = ADCAT5
                     AND "Premium" = premiumval  AND (ADON=chkadon_p or ADON is null) ;
         END IF;
        IF num=1 then
                SELECT MAX(ROWID) into tmpvar FROM
                           rate_mast
                           WHERE "pub_center"=UPPER(center)
                           AND "Combin_Code" = PKGCODE
                           AND "Adv_Type_Code" = UPPER(adtype)
                           AND "Adv_Cat_Code" = ADCAT1
                           AND "Color" = COL
                           AND "Currency" = UPPER(currency)
                           AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                           AND "Uom" = UPPER(uom)
                           AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                           AND LINE BETWEEN "Size_From" AND "Size_To"
                           AND "Adv_subcat_code" = ADCAT2
                           AND "Ad_Subcat4" = ADCAT3
                           AND "Ad_Subcat5" = ADCAT4
                           AND "Ad_subcat6" = ADCAT5
                         AND "Premium" = premiumval  AND (ADON=chkadon_p or ADON is null) ;
         END IF;
        IF num=2 then
                SELECT MAX(ROWID) into tmpvar FROM
                               rate_mast
                               WHERE "pub_center"=UPPER(center)
                               AND "Combin_Code" = PKGCODE
                               AND "Adv_Type_Code" = UPPER(adtype)
                               AND "Adv_Cat_Code" = ADCAT1
                               AND "Color" = COL
                               AND "Currency" = UPPER(currency)
                               AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                               AND "Uom" = UPPER(uom)
                               AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                               AND "Size_To" < TO_NUMBER (LINE)
                               AND "Adv_subcat_code" = ADCAT2
                               AND "Ad_Subcat4" = ADCAT3
                               AND "Ad_Subcat5" = ADCAT4
                               AND "Ad_subcat6" = ADCAT5
                              AND "Premium" = premiumval  AND (ADON=chkadon_p or ADON is null) ;
        END IF;

else
             IF num=0 then
             SELECT MAX(ROWID) into tmpvar FROM
                       rate_mast
                       WHERE "Rate_Mast_Code"=rCode
                       AND "pub_center"=UPPER(center)
                       AND "Combin_Code" = PKGCODE
                       AND "Adv_Type_Code" = UPPER(adtype)
                       AND "Adv_Cat_Code" = ADCAT1
                       AND "Color" = COL
                       AND "Currency" = UPPER(currency)
                       AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                       AND "Uom" = UPPER(uom)
                       AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                       AND "Adv_subcat_code" = ADCAT2
                       AND "Ad_Subcat4" = ADCAT3
                       AND "Ad_Subcat5" = ADCAT4
                       AND "Ad_subcat6" = ADCAT5
                      AND "Premium" = premiumval  AND (ADON=chkadon_p or ADON is null) ;
         END IF;
        IF num=1 then
                SELECT MAX(ROWID) into tmpvar FROM
                           rate_mast
                           WHERE "Rate_Mast_Code"=rCode
                           AND "pub_center"=UPPER(center)
                           AND "Combin_Code" = PKGCODE
                           AND "Adv_Type_Code" = UPPER(adtype)
                           AND "Adv_Cat_Code" = ADCAT1
                           AND "Color" = COL
                           AND "Currency" = UPPER(currency)
                           AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                           AND "Uom" = UPPER(uom)
                           AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                           AND LINE BETWEEN "Size_From" AND "Size_To"
                           AND "Adv_subcat_code" = ADCAT2
                           AND "Ad_Subcat4" = ADCAT3
                           AND "Ad_Subcat5" = ADCAT4
                           AND "Ad_subcat6" = ADCAT5
                      AND "Premium" = premiumval  AND (ADON=chkadon_p or ADON is null) ;
         END IF;
        IF num=2 then
                if adtype = 'DI0' THEN
                 SELECT MAX(ROWID) into tmpvar FROM
                               rate_mast
                               WHERE "Rate_Mast_Code"=rCode
                               AND "pub_center"=UPPER(center)
                               AND "Combin_Code" = PKGCODE
                               AND "Adv_Type_Code" = UPPER(adtype)
                               AND "Adv_Cat_Code" = ADCAT1
                               AND "Color" = COL
                               AND "Currency" = UPPER(currency)
                               AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                               AND "Uom" = UPPER(uom)
                               AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                               AND "Size_To" < TO_NUMBER (LINE)
                               AND "Adv_subcat_code" = ADCAT2
                               AND "Ad_Subcat4" = ADCAT3
                               AND "Ad_Subcat5" = ADCAT4
                               AND "Ad_subcat6" = ADCAT5
                             AND "Premium" = premiumval  AND (ADON=chkadon_p or ADON is null)  AND "Size_From" ='0' AND 

"Size_To"='0' ;
                ELSE
                SELECT MAX(ROWID) into tmpvar FROM
                               rate_mast
                               WHERE "Rate_Mast_Code"=rCode
                               AND "pub_center"=UPPER(center)
                               AND "Combin_Code" = PKGCODE
                               AND "Adv_Type_Code" = UPPER(adtype)
                               AND "Adv_Cat_Code" = ADCAT1
                               AND "Color" = COL
                               AND "Currency" = UPPER(currency)
                               AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                               AND "Uom" = UPPER(uom)
                               AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                               AND "Size_To" < TO_NUMBER (LINE)
                               AND "Adv_subcat_code" = ADCAT2
                               AND "Ad_Subcat4" = ADCAT3
                               AND "Ad_Subcat5" = ADCAT4
                               AND "Ad_subcat6" = ADCAT5
                             AND "Premium" = premiumval  AND (ADON=chkadon_p or ADON is null)  ;
                END IF;             
        END IF;
end if;


   RETURN tmpVar;
   EXCEPTION
     WHEN NO_DATA_FOUND THEN
       NULL;
     WHEN OTHERS THEN
       -- Consider logging the error and then re-raise
       RAISE;
END getRate_Code;
/


CREATE OR REPLACE PACKAGE rate_qbc is
Type T_Accounts_Cursor  is ref Cursor;
procedure rate_qbc_p(
noofinsertion in varchar2,
dateformat in varchar2,
compcode in varchar2,
uom in varchar2,
adtype in varchar2,
currency in varchar2,
ratecode in varchar2,
clientcode in varchar2,
uomdesc in varchar2,
openreferExtra in varchar2,
agencycode in varchar2,
newcode in clob,
center in varchar2,
ratepremtype in varchar2,
premiumval in varchar2,
schemetype in varchar2,
fDate in date,
lDate in date,
counter int,
rateflag in varchar2,
chkadon_p in varchar2,
P_Accounts out T_Accounts_Cursor,
P_Accounts1 out T_Accounts_Cursor,
P_Accounts2 out T_Accounts_Cursor,
P_Accounts3 out T_Accounts_Cursor
);
end rate_qbc;
/



CREATE OR REPLACE PACKAGE BODY Rate_Qbc
IS
   PROCEDURE rate_qbc_p (
    noofinsertion IN VARCHAR2,
    dateformat IN VARCHAR2,
    compcode IN VARCHAR2,
    uom IN VARCHAR2,
    Adtype IN VARCHAR2,
    currency IN VARCHAR2,
    RATECODE IN VARCHAR2,
    clientcode IN VARCHAR2,
    uomdesc IN VARCHAR2,
    openreferExtra IN VARCHAR2,
    agencycode IN VARCHAR2,
    newcode IN clob,
    center IN VARCHAR2,
    ratepremtype IN VARCHAR2,
    premiumval IN VARCHAR2,
    schemetype in varchar2,
    fDate in date,
    lDate in date,
    counter int,
    rateflag in varchar2,
    chkadon_p in varchar2,
    P_Accounts OUT T_Accounts_Cursor,
    P_Accounts1 OUT T_Accounts_Cursor,
    P_Accounts2 OUT T_Accounts_Cursor,
    P_Accounts3 OUT T_Accounts_Cursor
       )
   AS
   SIZEFROM_FIX NUMBER;
   RATEGROUP VARCHAR2(20);
   FLOORAMT FLOAT;
   specialsize varchar2(20);
   specialsizerate float;
   compcode_M varchar2(50);
    combindesc_M varchar2(1000);
    advcatcode_M varchar2(50);
    advsubcatcode_M varchar2(50);
    rategroupcode_M varchar2(50);
    weekdayrate_M float;
    weekextrarate_M float;
    validfrom_M date;
    validto_M date; 
   EDITIONNAME VARCHAR(100);
   AEDITIONNAME VARCHAR(100);
   PKGCODE VARCHAR(50);
   ADCAT1 VARCHAR(50);
   ADCAT2 VARCHAR(50);
   ADCAT3 VARCHAR(50);
   ADCAT4 VARCHAR(50);
   ADCAT5 VARCHAR(50);
   DUMMY_ADCAT1 VARCHAR(50);
   DUMMY_ADCAT2 VARCHAR(50);
   DUMMY_ADCAT3 VARCHAR(50);
   DUMMY_ADCAT4 VARCHAR(50);
   DUMMY_ADCAT5 VARCHAR(50);
   COL VARCHAR(50);
   DUMMY_COL VARCHAR(50);
   LINE VARCHAR(50);
   RLINE VARCHAR(50);
   BDATE DATE;-- DATE FOR DAYWISE RATE
   RATECHKDATE DATE;-- FOR VALID RATECARD
   COUNTRATE NUMBER;
   COUNTRATE1 NUMBER;
   RATEUNIQUEID VARCHAR2(100);
   FRATEUNIQUEID VARCHAR2(100);
   ARATEUNIQUEID VARCHAR(100);
   COLREFER VARCHAR(50);
   PERC NUMBER;
   CARD_RATE NUMBER;
   EXTRA_RATE NUMBER;
   FCARD_RATE NUMBER;
   FEXTRA_RATE NUMBER;
   SOLORATEWEEK     FLOAT;
   DAY1     VARCHAR(10);
   FINALRATE     VARCHAR(100);
   PKGNAME     VARCHAR(1000);
   EXTRALINE    NUMBER;
   MIN_AREA     NUMBER;
   MAX_AREA     NUMBER;
   WIDTH        NUMBER;
   CONSUM       NUMBER;
   INSERTIONNUM NUMBER;
   AD_WIDTH     NUMBER;
   PKGALIAS     VARCHAR(100);
   PREM         VARCHAR2(50);
   PAGEPREMNO         VARCHAR2(50);
   DAYDIFF      NUMBER;
   HRDIFF       NUMBER;
   MINDIFF      NUMBER;
   CDAYDIFF      NUMBER;
   CHRDIFF       NUMBER;
   CMINDIFF      NUMBER;
   CRODATETIME  VARCHAR(20);
   COUNTSCHEMEEDITION NUMBER;
   COUNTADON NUMBER;
   COUNTADONEDITION  VARCHAR(100);
   COUNTADONINSERT  NUMBER;
   PAGEPREMNODUMMY VARCHAR2(50);
   uomcode varchar2(10);
   comm_rec number;
   MIN_SIZE VARCHAR2(20);
   DIFFSIZE NUMBER;
   PREMTYPE VARCHAR2(10);
   BEGIN
   DELETE FROM RATESPLIT;
   DELETE FROM FINALRATE;
   DELETE FROM ERRORMESSAGE;
   DELETE FROM SCHEME_TEMP;
   COMMIT;
    --EDITION_NAME $ PACKAGE_CODE $ COLOR $ CAT1 $ CAT2 $ CAT3 $ CAT4 $ CAT5 $ LINES $ BOOKINGDATE & 

RATECHECKDATE
    Splittest(newcode,'$',',');
    uomcode:=uom;
        
    UPDATE RATECHECK SET MINSIZE=(SELECT MIN(LINES) FROM RATECHECK);
    COMMIT;

     DECLARE CURSOR R_CURSOR
      IS
            SELECT UPPER(EDITION_NAME) , UPPER(PACKAGE_CODE) , UPPER(COLOR), UPPER(CAT1) , UPPER(CAT2) 

, UPPER(CAT3) , UPPER(CAT4) , UPPER(CAT5) , LINES , BOOKINGDATE , RATECODEDATE, INSERTION, WIDTH, 

UPPER(LTRIM(RTRIM(PKG_ALIAS))), PREMIUM, UPPER(PAGEPREM),MINSIZE, SPECIALSIZE1 FROM RATECHECK;
      BEGIN
       OPEN R_CURSOR;

         LOOP
            FETCH R_CURSOR
             INTO EDITIONNAME, PKGCODE, COL, ADCAT1, ADCAT2, ADCAT3, ADCAT4, ADCAT5, LINE , BDATE, 

RATECHKDATE, INSERTIONNUM, AD_WIDTH, PKGALIAS, PREM, 

PAGEPREMNO,MIN_SIZE,specialsize;--RATECHECKDATE FOR VALID RATECARD AND BDATE FOR DAYWISE RATE

            EXIT WHEN R_CURSOR%NOTFOUND;
            DUMMY_ADCAT1:=ADCAT1;
            DUMMY_ADCAT2:=ADCAT2;
            DUMMY_ADCAT3:=ADCAT3;
            DUMMY_ADCAT4:=ADCAT4;
            DUMMY_ADCAT5:=ADCAT5;
            DUMMY_COL:=COL;
            INSERTIONNUM:=INSERTIONNUM * noofinsertion;
            DBMS_OUTPUT.PUT_LINE('PAGEPREMNO-*'||PAGEPREMNO);
            --IF umdesc != 'CD' THEN
                BEGIN
                 SELECT COUNT(*) INTO COUNTRATE FROM RATE_MAST
                       WHERE "pub_center"=UPPER(center)
                       AND "Combin_Code" = PKGCODE
                       AND "Adv_Type_Code" = UPPER(Adtype)
                       AND "Adv_Cat_Code" = ADCAT1
                       AND "Color" = COL
                       AND "Currency" = UPPER(currency)
                       AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                       AND "Uom" = UPPER(uom)
                       AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                       AND "Adv_subcat_code" = ADCAT2
                       AND "Ad_Subcat4" = ADCAT3
                       AND "Ad_Subcat5" = ADCAT4
                       AND "Ad_subcat6" = ADCAT5
                      AND "Premium" = PAGEPREMNO
                      AND (ADON=chkadon_p or ADON is null) 
                       AND 

ROWID=(Getrate_Code(center,PKGCODE,Adtype,ADCAT1,COL,currency,RATECHKDATE,uom,INSERTIONNUM,ADCAT2,A

DCAT3,ADCAT4,ADCAT5,PAGEPREMNO,RATECODE,0,LINE,chkadon_p));


                EXCEPTION
                  WHEN NO_DATA_FOUND THEN  NULL;
                END;
                  DBMS_OUTPUT.PUT_LINE('COUNTRATE-*'||COUNTRATE);
                  DBMS_OUTPUT.PUT_LINE('RATECHKDATE-*'||RATECHKDATE);
                 IF COUNTRATE IS NULL OR COUNTRATE=0 THEN
                       ADCAT5:=0;
                       DBMS_OUTPUT.PUT_LINE('ADCAT5-*'||ADCAT5);
                 BEGIN
                   SELECT COUNT(*) INTO COUNTRATE FROM RATE_MAST
                       WHERE "pub_center"=UPPER(center)
                       AND "Combin_Code" = PKGCODE
                       AND "Adv_Type_Code" = UPPER(Adtype)
                       AND "Adv_Cat_Code" = ADCAT1
                       AND "Color" = COL
                       AND "Currency" = UPPER(currency)
                       AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                       AND "Uom" = UPPER(uom)
                       AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                       AND "Adv_subcat_code" = ADCAT2
                       AND "Ad_Subcat4" = ADCAT3
                       AND "Ad_Subcat5" = ADCAT4
                       AND "Ad_subcat6" = ADCAT5
                     AND "Premium" = PAGEPREMNO
                      AND (ADON=chkadon_p or ADON is null) 
                       AND 

ROWID=(Getrate_Code(center,PKGCODE,Adtype,ADCAT1,COL,currency,RATECHKDATE,uom,INSERTIONNUM,ADCAT2,A

DCAT3,ADCAT4,ADCAT5,PAGEPREMNO,RATECODE,0,LINE,chkadon_p));
                 EXCEPTION
                   WHEN NO_DATA_FOUND THEN  NULL;
                 END;
                 END IF;

                 IF COUNTRATE IS NULL OR COUNTRATE=0 THEN
                       ADCAT4:=0;
                 BEGIN
                  SELECT COUNT(*) INTO COUNTRATE FROM RATE_MAST
                       WHERE "pub_center"=UPPER(center)
                       AND "Combin_Code" = PKGCODE
                       AND "Adv_Type_Code" = UPPER(Adtype)
                       AND "Adv_Cat_Code" = ADCAT1
                       AND "Color" = COL
                       AND "Currency" = UPPER(currency)
                       AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                       AND "Uom" = UPPER(uom)
                       AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                       AND "Adv_subcat_code" = ADCAT2
                       AND "Ad_Subcat4" = ADCAT3
                       AND "Ad_Subcat5" = ADCAT4
                       AND "Ad_subcat6" = ADCAT5
                       AND "Premium" = PAGEPREMNO
                        AND (ADON=chkadon_p or ADON is null) 
                       AND 

ROWID=(Getrate_Code(center,PKGCODE,Adtype,ADCAT1,COL,currency,RATECHKDATE,uom,INSERTIONNUM,ADCAT2,A

DCAT3,ADCAT4,ADCAT5,PAGEPREMNO,RATECODE,0,LINE,chkadon_p));
                 EXCEPTION
                   WHEN NO_DATA_FOUND THEN  NULL;
                 END;
                 END IF;

                 IF COUNTRATE IS NULL OR COUNTRATE=0 THEN
                       ADCAT3:=0;
                 BEGIN
                  SELECT COUNT(*) INTO COUNTRATE FROM RATE_MAST
                       WHERE "pub_center"=UPPER(center)
                       AND "Combin_Code" = PKGCODE
                       AND "Adv_Type_Code" = UPPER(Adtype)
                       AND "Adv_Cat_Code" = ADCAT1
                       AND "Color" = COL
                       AND "Currency" = UPPER(currency)
                       AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                       AND "Uom" = UPPER(uom)
                       AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                       AND "Adv_subcat_code" = ADCAT2
                       AND "Ad_Subcat4" = ADCAT3
                       AND "Ad_Subcat5" = ADCAT4
                       AND "Ad_subcat6" = ADCAT5
                       AND "Premium" = PAGEPREMNO
                        AND (ADON=chkadon_p or ADON is null) 
                       AND 

ROWID=(Getrate_Code(center,PKGCODE,Adtype,ADCAT1,COL,currency,RATECHKDATE,uom,INSERTIONNUM,ADCAT2,A

DCAT3,ADCAT4,ADCAT5,PAGEPREMNO,RATECODE,0,LINE,chkadon_p));
                 EXCEPTION
                   WHEN NO_DATA_FOUND THEN  NULL;
                 END;
                 END IF;

                 IF COUNTRATE IS NULL OR COUNTRATE=0 THEN
                       ADCAT2:=0;
                       DBMS_OUTPUT.PUT_LINE('ADCAT2-*'||ADCAT2 || '****' || center);
                 BEGIN
                  SELECT COUNT(*) INTO COUNTRATE FROM RATE_MAST
                       WHERE "pub_center"=UPPER(center)
                       AND "Combin_Code" = PKGCODE
                       AND "Adv_Type_Code" = UPPER(Adtype)
                       AND "Adv_Cat_Code" = ADCAT1
                       AND "Color" = COL
                       AND "Currency" = UPPER(currency)
                       AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                       AND "Uom" = UPPER(uom)
                       AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                       AND "Adv_subcat_code" = ADCAT2
                       AND "Ad_Subcat4" = ADCAT3
                       AND "Ad_Subcat5" = ADCAT4
                       AND "Ad_subcat6" = ADCAT5
                       AND "Premium" = PAGEPREMNO
                        AND (ADON=chkadon_p or ADON is null) 
                       AND 

ROWID=(Getrate_Code(center,PKGCODE,Adtype,ADCAT1,COL,currency,RATECHKDATE,uom,INSERTIONNUM,ADCAT2,A

DCAT3,ADCAT4,ADCAT5,PAGEPREMNO,RATECODE,0,LINE,chkadon_p));

                 EXCEPTION
                   WHEN NO_DATA_FOUND THEN  NULL;
                 END;
                 END IF;

                 DBMS_OUTPUT.PUT_LINE(COUNTRATE||'***');
                 IF COUNTRATE IS NOT NULL THEN
                        BEGIN
                        SELECT "rateuniqueid" INTO RATEUNIQUEID FROM RATE_MAST
                           WHERE "pub_center"=UPPER(center)
                           AND "Combin_Code" = PKGCODE
                           AND "Adv_Type_Code" = UPPER(Adtype)
                           AND "Adv_Cat_Code" = ADCAT1
                           AND "Color" = COL
                           AND "Currency" = UPPER(currency)
                           AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                           AND "Uom" = UPPER(uom)
                           AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                           AND LINE BETWEEN "Size_From" AND "Size_To"
                           AND "Adv_subcat_code" = ADCAT2
                           AND "Ad_Subcat4" = ADCAT3
                           AND "Ad_Subcat5" = ADCAT4
                           AND "Ad_subcat6" = ADCAT5
                           AND "Premium" = PAGEPREMNO
                            AND (ADON=chkadon_p or ADON is null) 
                           AND 

ROWID=(Getrate_Code(center,PKGCODE,Adtype,ADCAT1,COL,currency,RATECHKDATE,uom,INSERTIONNUM,ADCAT2,A

DCAT3,ADCAT4,ADCAT5,PAGEPREMNO,RATECODE,1,LINE,chkadon_p));
                        EXCEPTION
                            WHEN NO_DATA_FOUND THEN  NULL;
                        END;

                     IF RATEUNIQUEID IS NULL THEN
                          BEGIN
                            SELECT "rateuniqueid" INTO RATEUNIQUEID FROM RATE_MAST
                               WHERE "pub_center"=UPPER(center)
                               AND "Combin_Code" = PKGCODE
                               AND "Adv_Type_Code" = UPPER(Adtype)
                               AND "Adv_Cat_Code" = ADCAT1
                               AND "Color" = COL
                               AND "Currency" = UPPER(currency)
                               AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                               AND "Uom" = UPPER(uom)
                               AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                               AND "Size_To" < TO_NUMBER (LINE)
                               AND "Adv_subcat_code" = ADCAT2
                               AND "Ad_Subcat4" = ADCAT3
                               AND "Ad_Subcat5" = ADCAT4
                               AND "Ad_subcat6" = ADCAT5
                              AND "Premium" = PAGEPREMNO
                               AND (ADON=chkadon_p or ADON is null) 
                              AND 

ROWID=(Getrate_Code(center,PKGCODE,Adtype,ADCAT1,COL,currency,RATECHKDATE,uom,INSERTIONNUM,ADCAT2,A

DCAT3,ADCAT4,ADCAT5,PAGEPREMNO,RATECODE,2,LINE,chkadon_p));
                          EXCEPTION
                                WHEN NO_DATA_FOUND THEN  NULL;
                            END;
                     END IF;

                  END IF;
               
               -- for color reference
                 IF RATEUNIQUEID IS NULL AND COL !='B' THEN
                    ADCAT1:=DUMMY_ADCAT1;
                    ADCAT2:=DUMMY_ADCAT2;
                    ADCAT3:=DUMMY_ADCAT3;
                    ADCAT4:=DUMMY_ADCAT4;
                    ADCAT5:=DUMMY_ADCAT5;

                    BEGIN
                        SELECT DISTINCT "color_rate","prcent_pr" INTO COLREFER,PERC FROM COLORRATEGROUPMAST 

WHERE "color_name" = COL AND "pkg_code"=PKGCODE;
                    EXCEPTION
                      WHEN NO_DATA_FOUND THEN  NULL;
                    END;
                    dbms_output.put_line('lata'||COL);
                    IF COLREFER = '2' THEN
                        COL:='B';
                        BEGIN
                         SELECT COUNT(*) INTO COUNTRATE FROM RATE_MAST
                               WHERE "pub_center"=UPPER(center)
                               AND "Combin_Code" = PKGCODE
                               AND "Adv_Type_Code" = UPPER(Adtype)
                               AND "Adv_Cat_Code" = ADCAT1
                               AND "Color" = COL
                               AND "Currency" = UPPER(currency)
                               AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                               AND "Uom" = UPPER(uom)
                               AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                               AND "Adv_subcat_code" = ADCAT2
                               AND "Ad_Subcat4" = ADCAT3
                               AND "Ad_Subcat5" = ADCAT4
                               AND "Ad_subcat6" = ADCAT5
                               AND "Premium" = PAGEPREMNO
                                AND (ADON=chkadon_p or ADON is null) 
                              AND 

ROWID=(Getrate_Code(center,PKGCODE,Adtype,ADCAT1,COL,currency,RATECHKDATE,uom,INSERTIONNUM,ADCAT2,A

DCAT3,ADCAT4,ADCAT5,PAGEPREMNO,RATECODE,0,LINE,chkadon_p));
                        EXCEPTION
                          WHEN NO_DATA_FOUND THEN  NULL;
                        END;

                         IF COUNTRATE IS NULL OR COUNTRATE=0 THEN
                               ADCAT5:=0;
                         BEGIN
                           SELECT COUNT(*) INTO COUNTRATE FROM RATE_MAST
                               WHERE "pub_center"=UPPER(center)
                               AND "Combin_Code" = PKGCODE
                               AND "Adv_Type_Code" = UPPER(Adtype)
                               AND "Adv_Cat_Code" = ADCAT1
                               AND "Color" = COL
                               AND "Currency" = UPPER(currency)
                               AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                               AND "Uom" = UPPER(uom)
                               AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                               AND "Adv_subcat_code" = ADCAT2
                               AND "Ad_Subcat4" = ADCAT3
                               AND "Ad_Subcat5" = ADCAT4
                               AND "Ad_subcat6" = ADCAT5
                              AND "Premium" = PAGEPREMNO
                               AND (ADON=chkadon_p or ADON is null) 
                               AND 

ROWID=(Getrate_Code(center,PKGCODE,Adtype,ADCAT1,COL,currency,RATECHKDATE,uom,INSERTIONNUM,ADCAT2,A

DCAT3,ADCAT4,ADCAT5,PAGEPREMNO,RATECODE,0,LINE,chkadon_p));
                         EXCEPTION
                           WHEN NO_DATA_FOUND THEN  NULL;
                         END;
                         END IF;

                         IF COUNTRATE IS NULL OR COUNTRATE=0 THEN
                               ADCAT4:=0;
                         BEGIN
                          SELECT COUNT(*) INTO COUNTRATE FROM RATE_MAST
                               WHERE "pub_center"=UPPER(center)
                               AND "Combin_Code" = PKGCODE
                               AND "Adv_Type_Code" = UPPER(Adtype)
                               AND "Adv_Cat_Code" = ADCAT1
                               AND "Color" = COL
                               AND "Currency" = UPPER(currency)
                               AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                               AND "Uom" = UPPER(uom)
                               AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                               AND "Adv_subcat_code" = ADCAT2
                               AND "Ad_Subcat4" = ADCAT3
                               AND "Ad_Subcat5" = ADCAT4
                               AND "Ad_subcat6" = ADCAT5
                               AND "Premium" = PAGEPREMNO
                                AND (ADON=chkadon_p or ADON is null) 
                               AND 

ROWID=(Getrate_Code(center,PKGCODE,Adtype,ADCAT1,COL,currency,RATECHKDATE,uom,INSERTIONNUM,ADCAT2,A

DCAT3,ADCAT4,ADCAT5,PAGEPREMNO,RATECODE,0,LINE,chkadon_p));
                         EXCEPTION
                           WHEN NO_DATA_FOUND THEN  NULL;
                         END;
                         END IF;

                         IF COUNTRATE IS NULL OR COUNTRATE=0 THEN
                               ADCAT3:=0;
                         BEGIN
                          SELECT COUNT(*) INTO COUNTRATE FROM RATE_MAST
                               WHERE "pub_center"=UPPER(center)
                               AND "Combin_Code" = PKGCODE
                               AND "Adv_Type_Code" = UPPER(Adtype)
                               AND "Adv_Cat_Code" = ADCAT1
                               AND "Color" = COL
                               AND "Currency" = UPPER(currency)
                               AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                               AND "Uom" = UPPER(uom)
                               AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                               AND "Adv_subcat_code" = ADCAT2
                               AND "Ad_Subcat4" = ADCAT3
                               AND "Ad_Subcat5" = ADCAT4
                               AND "Ad_subcat6" = ADCAT5
                              AND "Premium" = PAGEPREMNO
                               AND (ADON=chkadon_p or ADON is null) 
                               AND 

ROWID=(Getrate_Code(center,PKGCODE,Adtype,ADCAT1,COL,currency,RATECHKDATE,uom,INSERTIONNUM,ADCAT2,A

DCAT3,ADCAT4,ADCAT5,PAGEPREMNO,RATECODE,0,LINE,chkadon_p));
                         EXCEPTION
                           WHEN NO_DATA_FOUND THEN  NULL;
                         END;
                         END IF;

                         IF COUNTRATE IS NULL OR COUNTRATE=0 THEN
                               ADCAT2:=0;
                         BEGIN
                          SELECT COUNT(*) INTO COUNTRATE FROM RATE_MAST
                               WHERE "pub_center"=UPPER(center)
                               AND "Combin_Code" = PKGCODE
                               AND "Adv_Type_Code" = UPPER(Adtype)
                               AND "Adv_Cat_Code" = ADCAT1
                               AND "Color" = COL
                               AND "Currency" = UPPER(currency)
                               AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                               AND "Uom" = UPPER(uom)
                               AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                               AND "Adv_subcat_code" = ADCAT2
                               AND "Ad_Subcat4" = ADCAT3
                               AND "Ad_Subcat5" = ADCAT4
                               AND "Ad_subcat6" = ADCAT5
                            AND "Premium" = PAGEPREMNO
                             AND (ADON=chkadon_p or ADON is null) 
                              AND 

ROWID=(Getrate_Code(center,PKGCODE,Adtype,ADCAT1,COL,currency,RATECHKDATE,uom,INSERTIONNUM,ADCAT2,A

DCAT3,ADCAT4,ADCAT5,PAGEPREMNO,RATECODE,0,LINE,chkadon_p));
                         EXCEPTION
                           WHEN NO_DATA_FOUND THEN  NULL;
                         END;
                         END IF;

                        DBMS_OUTPUT.PUT_LINE('COUNTRATE*-'||COUNTRATE);
                        IF COUNTRATE IS NOT NULL THEN
                            BEGIN
                            SELECT "rateuniqueid" INTO RATEUNIQUEID FROM RATE_MAST
                               WHERE "pub_center"=UPPER(center)
                               AND "Combin_Code" = PKGCODE
                               AND "Adv_Type_Code" = UPPER(Adtype)
                               AND "Adv_Cat_Code" = ADCAT1
                               AND "Color" = COL
                               AND "Currency" = UPPER(currency)
                               AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                               AND "Uom" = UPPER(uom)
                               AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                               AND LINE BETWEEN "Size_From" AND "Size_To"
                               AND "Adv_subcat_code" = ADCAT2
                               AND "Ad_Subcat4" = ADCAT3
                               AND "Ad_Subcat5" = ADCAT4
                               AND "Ad_subcat6" = ADCAT5
                              AND "Premium" = PAGEPREMNO
                               AND (ADON=chkadon_p or ADON is null) 
                               AND 

ROWID=(Getrate_Code(center,PKGCODE,Adtype,ADCAT1,COL,currency,RATECHKDATE,uom,INSERTIONNUM,ADCAT2,A

DCAT3,ADCAT4,ADCAT5,PAGEPREMNO,RATECODE,1,LINE,chkadon_p));
                            EXCEPTION
                                WHEN NO_DATA_FOUND THEN  NULL;
                            END;

                             IF RATEUNIQUEID IS NULL THEN
                                  BEGIN
                                    SELECT "rateuniqueid" INTO RATEUNIQUEID FROM RATE_MAST
                                       WHERE "pub_center"=UPPER(center)
                                       AND "Combin_Code" = PKGCODE
                                       AND "Adv_Type_Code" = UPPER(Adtype)
                                       AND "Adv_Cat_Code" = ADCAT1
                                       AND "Color" = COL
                                       AND "Currency" = UPPER(currency)
                                       AND RATECHKDATE BETWEEN "Valid_From" AND "Valid_To"
                                       AND "Uom" = UPPER(uom)
                                       AND INSERTIONNUM BETWEEN "From_insertion" AND "To_insertion"
                                       AND "Size_To" < TO_NUMBER (LINE)
                                       AND "Adv_subcat_code" = ADCAT2
                                       AND "Ad_Subcat4" = ADCAT3
                                       AND "Ad_Subcat5" = ADCAT4
                                       AND "Ad_subcat6" = ADCAT5
                                     AND "Premium" = PAGEPREMNO
                                      AND (ADON=chkadon_p or ADON is null) 
                                      AND 

ROWID=(Getrate_Code(center,PKGCODE,Adtype,ADCAT1,COL,currency,RATECHKDATE,uom,INSERTIONNUM,ADCAT2,A

DCAT3,ADCAT4,ADCAT5,PAGEPREMNO,RATECODE,2,LINE,chkadon_p));
                                  EXCEPTION
                                        WHEN NO_DATA_FOUND THEN  NULL;
                                    END;
                             END IF;

                            END IF;
                    END IF;

                END IF;

          -- END IF;

            BEGIN
                SELECT "min_ad_area","Max_Area","MAXWIDTH","consumption_Per","Premium_Charges" INTO MIN_AREA, 

MAX_AREA, WIDTH,CONSUM, specialsizerate FROM RATE_MAST WHERE "rateuniqueid"=RATEUNIQUEID;
                 EXCEPTION
                    WHEN NO_DATA_FOUND THEN  NULL;
                 END;

            BEGIN
                SELECT "Package_Alias" INTO PKGNAME FROM COMBIN_MAST WHERE "Combin_Code" = PKGCODE;
             EXCEPTION
             WHEN NO_DATA_FOUND THEN  NULL;
             END;
            --    CHECK FOR  FIXED AND VARIABLE SIZE
            IF WIDTH IS NOT NULL AND WIDTH != '0' AND WIDTH != 0  THEN
                IF AD_WIDTH != WIDTH THEN
                    INSERT INTO ERRORMESSAGE(MESSAGE) VALUES('FOR PACKAGE ' || PKGNAME ||' SIZE CAN NOT BE 

GREATER OR LESS THAN '|| WIDTH);
                    COMMIT;
                    GOTO L;
                END IF;
            END IF;

            IF MAX_AREA IS NOT NULL AND MAX_AREA!='0' THEN
                IF LINE>MAX_AREA THEN
                     INSERT INTO ERRORMESSAGE(MESSAGE) VALUES('FOR PACKAGE ' || PKGNAME ||' SIZE CAN NOT BE 

GREATER THAN ' || MAX_AREA);
                     COMMIT;
                     GOTO L;
                END IF;
            END IF;
            
             IF MIN_AREA IS NOT NULL AND MIN_AREA!='0' THEN
                IF LINE<MIN_AREA  THEN
                     INSERT INTO ERRORMESSAGE(MESSAGE) VALUES('FOR PACKAGE ' || PKGNAME ||' SIZE CAN NOT BE 

LESS THAN ' || MIN_AREA);
                     COMMIT;
                     GOTO L;
                END IF;
            END IF;

            IF RATEUNIQUEID IS NULL THEN
                DELETE FROM RATESPLIT;
                INSERT INTO ERRORMESSAGE(MESSAGE) VALUES('RATES ARE NOT DEFINED FOR PACKAGE '|| 

PKGNAME);
                COMMIT;
                GOTO L;
             END IF;

            -- FOR CHECKING RO BOOKING DATETIME
            BEGIN
            SELECT "Ro_datetime" INTO CRODATETIME FROM PREFERRENCES WHERE "comp_code"=compcode;
             EXCEPTION
                        WHEN NO_DATA_FOUND THEN  NULL;
             END;
            
             IF(CONSUM IS NOT NULL  AND lDate IS NOT NULL AND fDate IS NOT NULL) THEN
             DAYDIFF:=0;
                      
               SELECT to_char(TO_DATE(lDate,'dd-mm-yy')-TO_DATE(fDate,'dd-mm-yy')) INTO DAYDIFF FROM DUAL;
            IF(DAYDIFF>CONSUM) THEN
                INSERT INTO ERRORMESSAGE(MESSAGE) VALUES('Consumption Period Exceed');
                 COMMIT;
                 GOTO L;
              END IF;
             END IF;
            IF CRODATETIME !='no' AND CRODATETIME IS NOT NULL THEN
                    SELECT to_char(TO_DATE(BDATE,'dd-mm-yy')-SYSDATE) INTO DAYDIFF FROM DUAL;
                    BEGIN
                    SELECT NVL("Production",0) INTO CDAYDIFF FROM EDITION_MAST WHERE 

"Edition_Alias"=EDITIONNAME;
                    EXCEPTION
                             WHEN NO_DATA_FOUND THEN  NULL;
                     END;
                    IF CDAYDIFF!=0 THEN
                        IF TO_NUMBER(DAYDIFF) <= TO_NUMBER(CDAYDIFF) THEN
                             DELETE FROM RATESPLIT;
                             INSERT INTO ERRORMESSAGE(MESSAGE) VALUES('FOR ' || EDITIONNAME ||' AD CAN BE TAKE 

BEFORE '|| CDAYDIFF || ' DAY OF PRODUCTION');
                             COMMIT;
                             GOTO L;
                        END IF;
                    END IF;
                    SELECT to_char((to_date(BDATE,'dd-mon-yy')-SYSDATE)*24) INTO HRDIFF from DUAL;
                    BEGIN
                    SELECT NVL("RO_hr",0) INTO CHRDIFF FROM EDITION_MAST  WHERE "Edition_Alias"=EDITIONNAME;
                    EXCEPTION
                             WHEN NO_DATA_FOUND THEN  NULL;
                     END;
                    IF CHRDIFF!=0 THEN
                        IF TO_NUMBER(HRDIFF) <= TO_NUMBER(CHRDIFF) THEN
                             DELETE FROM RATESPLIT;
                             INSERT INTO ERRORMESSAGE(MESSAGE) VALUES('FOR ' || EDITIONNAME ||' AD CAN BE TAKE 

BEFORE '|| CHRDIFF || ' HRs OF PRODUCTION');
                             COMMIT;
                             GOTO L;
                        END IF;
                    END IF;
                    select to_char((to_date(BDATE,'dd-mon-yy')-SYSDATE)*1440) INTO MINDIFF from DUAL;
                    BEGIN
                    SELECT NVL("RO_min",0) INTO CMINDIFF FROM EDITION_MAST  WHERE "Edition_Alias"=EDITIONNAME;
                    EXCEPTION
                             WHEN NO_DATA_FOUND THEN  NULL;
                     END;
                    IF CMINDIFF!=0 THEN
                         IF TO_NUMBER(MINDIFF) <= (CMINDIFF) THEN
                             DELETE FROM RATESPLIT;
                             INSERT INTO ERRORMESSAGE(MESSAGE) VALUES('FOR ' || EDITIONNAME ||' AD CAN BE TAKE 

BEFORE '|| CMINDIFF || ' MINs OF PRODUCTION');
                             COMMIT;
                             GOTO L;
                         END IF;
                     END IF;
                   
            END IF;
           SELECT "floor_amount","Rate_Gr_Code" INTO FLOORAMT,RATEGROUP  FROM RATE_MAST WHERE 

"rateuniqueid"=RATEUNIQUEID;
            IF COLREFER = '2' THEN
            
                  BEGIN
                        SELECT DISTINCT "prcent_pr" INTO PERC FROM COLORRATEGROUPMAST WHERE "color_name" = 

'CO0' AND "pkg_code"=PKGCODE AND COLORRATEGP_CODE=RATEGROUP;
                    EXCEPTION
                      WHEN NO_DATA_FOUND THEN  
                      SELECT DISTINCT "prcent_pr" INTO PERC FROM COLORRATEGROUPMAST WHERE "color_name" = 'CO0' 

AND "pkg_code"=PKGCODE;
                    END;
            END IF;
            -- INSERT RATEUBIQUEID, EDITION AND PKGCODE IN TEMP TABLE RATESPLIT
            IF DUMMY_COL != COL THEN
                INSERT INTO RATESPLIT(PCODE, EDITION_NAME, RATEID, 

COLORREF,PERCENTAGE,BOOKINGDATE,LINES,ADVCAT1,ADVCAT2,ADVCAT3,ADVCAT4,ADVCAT5,INSERTS,PKG_A

LIAS,PREMIUM,PAGEPREM,MINSIZE, SPECIALSIZE1) 

VALUES(PKGCODE,EDITIONNAME,RATEUNIQUEID,1,PERC,BDATE,LINE,ADCAT1,ADCAT2,ADCAT3,ADCAT4,ADCAT5,IN

SERTIONNUM,PKGALIAS,PREM,PAGEPREMNO,MIN_SIZE,specialsize);
            ELSE
                INSERT INTO RATESPLIT(PCODE, EDITION_NAME, RATEID, 

COLORREF,PERCENTAGE,BOOKINGDATE,LINES,ADVCAT1,ADVCAT2,ADVCAT3,ADVCAT4,ADVCAT5,INSERTS,PKG_A

LIAS,PREMIUM,PAGEPREM,MINSIZE,SPECIALSIZE1) 

VALUES(PKGCODE,EDITIONNAME,RATEUNIQUEID,0,0,BDATE,LINE,ADCAT1,ADCAT2,ADCAT3,ADCAT4,ADCAT5,INSER

TIONNUM,PKGALIAS,PREM,PAGEPREMNO,MIN_SIZE,specialsize);
            END IF;
            COUNTRATE:=NULL;
            RATEUNIQUEID:=NULL;
        END LOOP;
        END;
        BEGIN
        SELECT COUNT(*) INTO COUNTSCHEMEEDITION FROM SCHEME_MASTER_EDITION;
        EXCEPTION
                             WHEN NO_DATA_FOUND THEN  COUNTSCHEMEEDITION:=0;
        END;
        COUNTRATE:=NULL;
        RATEUNIQUEID:=NULL;
        PKGCODE:=NULL;
        EDITIONNAME:=NULL;
        BDATE:=NULL;
        PERC:=NULL;
        COLREFER:=NULL;
        LINE:=NULL;
        ADCAT1:=NULL;
        ADCAT2:=NULL;
        ADCAT3:=NULL;
        ADCAT4:=NULL;
        ADCAT5:=NULL;
        INSERTIONNUM:=0;
        PKGALIAS:='';
        PREM:='';
        PAGEPREMNO:='';
        MIN_SIZE:='';
        specialsize:='';
        -- CURSOR FOR FETCHING RATE INSERTWISE WITH RATEUNIQUEID
       DECLARE CURSOR R1_CURSOR
        IS
                SELECT 

PCODE,EDITION_NAME,RATEID,COLORREF,PERCENTAGE,BOOKINGDATE,LINES,ADVCAT1,ADVCAT2,ADVCAT3,ADV

CAT4,ADVCAT5,INSERTS, PKG_ALIAS, PREMIUM, PAGEPREM,MINSIZE, SPECIALSIZE1 FROM RATESPLIT ORDER BY 

RATEID;
        BEGIN
           OPEN R1_CURSOR;

             LOOP
                FETCH R1_CURSOR
                 INTO PKGCODE, EDITIONNAME, FRATEUNIQUEID, COLREFER, PERC, BDATE, LINE, ADCAT1, ADCAT2, 

ADCAT3, ADCAT4, ADCAT5, INSERTIONNUM, PKGALIAS, PREM, PAGEPREMNO,MIN_SIZE,specialsize;
                   EXIT WHEN R1_CURSOR%NOTFOUND;
                     BEGIN
                        --SELECT COUNT(*) INTO COUNTRATE FROM RATESPLIT WHERE RATEID=FRATEUNIQUEID GROUP 

BY RATEID HAVING COUNT(*) > 1;
                        DBMS_OUTPUT.PUT_LINE(FRATEUNIQUEID);
                        SELECT COUNT(*) INTO COUNTRATE FROM RATE_DETAILS WHERE "ratemastid"=FRATEUNIQUEID 

GROUP BY "ratemastid" HAVING COUNT(*) > 1;
                     EXCEPTION
                        WHEN NO_DATA_FOUND THEN  NULL;
                     END;
                     CARD_RATE:=NULL;
                     EXTRA_RATE:=NULL;
                     FCARD_RATE:=NULL;
                     FEXTRA_RATE:=NULL;

                    DAY1 := TO_CHAR (BDATE, 'Dy');
                    DBMS_OUTPUT.PUT_LINE('DAY-*'||DAY1);
                   -- IF uomdesc != 'CD' THEN
                        SELECT "Size_To" INTO RLINE FROM RATE_MAST WHERE "rateuniqueid"=FRATEUNIQUEID AND 

ROWNUM<=1;
                    --END IF;

                    IF COUNTRATE IS NULL THEN
                    -- NOT PACKAGE
                        IF COLREFER = '0' THEN
                                IF ratepremtype = 'per' THEN
                                    BEGIN
                                    SELECT CASE WHEN DAY1='Sun' THEN "Week_Day_Rate" + ("Week_Day_Rate" * 

"SUN_RATE")/100  || '$' || ("Week_Extra_Rate" + ("Week_Extra_Rate" * "SUN_RATE_EXTRA")/100)
                                                WHEN DAY1='Mon' THEN "Week_Day_Rate" + ("Week_Day_Rate" * "MON_RATE")/100  || 

'$' || ("Week_Extra_Rate" + ("Week_Extra_Rate" * "MON_RATE_EXTRA")/100)
                                                WHEN DAY1='Tue' THEN "Week_Day_Rate" + ("Week_Day_Rate" * "TUE_RATE")/100  || '$' 

|| ("Week_Extra_Rate" + ("Week_Extra_Rate" * "TUE_RATE_EXTRA")/100)
                                                WHEN DAY1='Wed' THEN "Week_Day_Rate" + ("Week_Day_Rate" * "WED_RATE")/100  || 

'$' || ("Week_Extra_Rate" + ("Week_Extra_Rate" * "WED_RATE_EXTRA")/100)
                                                WHEN DAY1='Thu' THEN "Week_Day_Rate" + ("Week_Day_Rate" * "THU_RATE")/100  || '$' 

|| ("Week_Extra_Rate" + ("Week_Extra_Rate" * "THU_RATE_EXTRA")/100)
                                                WHEN DAY1='Fri' THEN "Week_Day_Rate" + ("Week_Day_Rate" * "FRI_RATE")/100  || '$' || 

("Week_Extra_Rate" + ("Week_Extra_Rate" * "FRI_RATE_EXTRA")/100)
                                                WHEN DAY1='Sat' THEN "Week_Day_Rate" + ("Week_Day_Rate" * "SAT_RATE")/100  || '$' 

|| ("Week_Extra_Rate" + ("Week_Extra_Rate" * "SAT_RATE_EXTRA")/100)
                                     END
                                    INTO FINALRATE
                                    FROM RATE_MAST WHERE "rateuniqueid"=FRATEUNIQUEID;
                                    EXCEPTION
                                        WHEN NO_DATA_FOUND THEN  NULL;
                                      END;
                                ELSE
                                     BEGIN
                                        SELECT CASE WHEN DAY1='Sun' THEN ("Week_Day_Rate" + "SUN_RATE")  || '$' || 

("Week_Extra_Rate" + "SUN_RATE_EXTRA")
                                                    WHEN DAY1='Mon' THEN ("Week_Day_Rate" + "MON_RATE")  || '$' || 

("Week_Extra_Rate" + "MON_RATE_EXTRA")
                                                    WHEN DAY1='Tue' THEN ("Week_Day_Rate" + "TUE_RATE")  || '$' || 

("Week_Extra_Rate" + "TUE_RATE_EXTRA")
                                                    WHEN DAY1='Wed' THEN ("Week_Day_Rate" + "WED_RATE")  || '$' || 

("Week_Extra_Rate" + "WED_RATE_EXTRA")
                                                    WHEN DAY1='Thu' THEN ("Week_Day_Rate" + "THU_RATE")  || '$' || 

("Week_Extra_Rate" + "THU_RATE_EXTRA")
                                                    WHEN DAY1='Fri' THEN ("Week_Day_Rate" + "FRI_RATE")  || '$' || ("Week_Extra_Rate" 

+ "FRI_RATE_EXTRA")
                                                    WHEN DAY1='Sat' THEN ("Week_Day_Rate" + "SAT_RATE")  || '$' || 

("Week_Extra_Rate" + "SAT_RATE_EXTRA")
                                               END
                                            INTO FINALRATE
                                            FROM RATE_MAST WHERE "rateuniqueid"=FRATEUNIQUEID;
                                       EXCEPTION
                                        WHEN NO_DATA_FOUND THEN  NULL;
                                      END;
                                END IF;


                        ELSE

                                IF openreferExtra = 'open' THEN
                                    IF ratepremtype = 'per' THEN
                                          BEGIN
                                           SELECT CASE  WHEN DAY1='Sun' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"SUN_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "SUN_RATE")/100)* PERC/100))  || '$' || 

(("Week_Extra_Rate" + ("Week_Extra_Rate" * "SUN_RATE_EXTRA")/100) + (("Week_Extra_Rate" + ("Week_Extra_Rate" * 

"SUN_RATE_EXTRA")/100) * PERC/100))
                                                        WHEN DAY1='Mon' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"MON_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "MON_RATE")/100)* PERC/100))  || '$' || 

(("Week_Extra_Rate" + ("Week_Extra_Rate" * "MON_RATE_EXTRA")/100) + (("Week_Extra_Rate" + ("Week_Extra_Rate" * 

"MON_RATE_EXTRA")/100) * PERC/100))
                                                        WHEN DAY1='Tue' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"TUE_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "TUE_RATE")/100)* PERC/100))  || '$' || 

(("Week_Extra_Rate" + ("Week_Extra_Rate" * "TUE_RATE_EXTRA")/100) + (("Week_Extra_Rate" + ("Week_Extra_Rate" * 

"TUE_RATE_EXTRA")/100) * PERC/100))
                                                        WHEN DAY1='Wed' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"WED_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "WED_RATE")/100)* PERC/100))  || '$' || 

(("Week_Extra_Rate" + ("Week_Extra_Rate" * "WED_RATE_EXTRA")/100) + (("Week_Extra_Rate" + ("Week_Extra_Rate" * 

"WED_RATE_EXTRA")/100) * PERC/100))
                                                        WHEN DAY1='Thu' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"THU_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "THU_RATE")/100)* PERC/100))  || '$' || 

(("Week_Extra_Rate" + ("Week_Extra_Rate" * "THU_RATE_EXTRA")/100) + (("Week_Extra_Rate" + ("Week_Extra_Rate" * 

"THU_RATE_EXTRA")/100) * PERC/100))
                                                        WHEN DAY1='Fri' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"FRI_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "FRI_RATE")/100)* PERC/100))  || '$' || (("Week_Extra_Rate" 

+ ("Week_Extra_Rate" * "FRI_RATE_EXTRA")/100) + (("Week_Extra_Rate" + ("Week_Extra_Rate" * 

"FRI_RATE_EXTRA")/100) * PERC/100))
                                                        WHEN DAY1='Sat' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"SAT_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "SAT_RATE")/100)* PERC/100))  || '$' || 

(("Week_Extra_Rate" + ("Week_Extra_Rate" * "SAT_RATE_EXTRA")/100) + (("Week_Extra_Rate" + ("Week_Extra_Rate" * 

"SAT_RATE_EXTRA")/100) * PERC/100))
                                            END
                                                INTO FINALRATE
                                                FROM RATE_MAST WHERE "rateuniqueid"=FRATEUNIQUEID;
                                            EXCEPTION
                                            WHEN NO_DATA_FOUND THEN  NULL;
                                            END;
                                    ELSE
                                          BEGIN
                                           SELECT CASE WHEN  DAY1='Sun' THEN (("Week_Day_Rate" + "SUN_RATE") + 

(("Week_Day_Rate" + "SUN_RATE")* PERC/100))  || '$' || (("Week_Extra_Rate" + "SUN_RATE_EXTRA") + 

(("Week_Extra_Rate" + "SUN_RATE_EXTRA") * PERC/100))
                                                        WHEN DAY1='Mon' THEN (("Week_Day_Rate" + "MON_RATE") + 

(("Week_Day_Rate" + "MON_RATE")* PERC/100))  || '$' || (("Week_Extra_Rate" + "MON_RATE_EXTRA") + 

(("Week_Extra_Rate" + "MON_RATE_EXTRA") * PERC/100))
                                                        WHEN DAY1='Tue' THEN (("Week_Day_Rate" + "TUE_RATE") + (("Week_Day_Rate" 

+ "TUE_RATE")* PERC/100))  || '$' || (("Week_Extra_Rate" + "TUE_RATE_EXTRA") + (("Week_Extra_Rate" + 

"TUE_RATE_EXTRA") * PERC/100))
                                                        WHEN DAY1='Wed' THEN (("Week_Day_Rate" + "WED_RATE") + 

(("Week_Day_Rate" + "WED_RATE")* PERC/100))  || '$' || (("Week_Extra_Rate" + "WED_RATE_EXTRA") + 

(("Week_Extra_Rate" + "WED_RATE_EXTRA") * PERC/100))
                                                        WHEN DAY1='Thu' THEN (("Week_Day_Rate" + "THU_RATE") + (("Week_Day_Rate" 

+ "THU_RATE")* PERC/100))  || '$' || (("Week_Extra_Rate" + "THU_RATE_EXTRA") + (("Week_Extra_Rate" + 

"THU_RATE_EXTRA") * PERC/100))
                                                        WHEN DAY1='Fri' THEN (("Week_Day_Rate" + "FRI_RATE") + (("Week_Day_Rate" + 

"FRI_RATE")* PERC/100))  || '$' || (("Week_Extra_Rate" + "FRI_RATE_EXTRA") + (("Week_Extra_Rate" + 

"FRI_RATE_EXTRA") * PERC/100))
                                                        WHEN DAY1='Sat' THEN (("Week_Day_Rate" + "SAT_RATE") + (("Week_Day_Rate" 

+ "SAT_RATE")* PERC/100))  || '$' || (("Week_Extra_Rate" + "SAT_RATE_EXTRA") + (("Week_Extra_Rate" + 

"SAT_RATE_EXTRA") * PERC/100))
                                            END
                                             INTO FINALRATE
                                             FROM RATE_MAST WHERE "rateuniqueid"=FRATEUNIQUEID;
                                            EXCEPTION
                                            WHEN NO_DATA_FOUND THEN  NULL;
                                            END;
                                    END IF;
                                ELSE
                                    IF ratepremtype = 'per' THEN
                                          BEGIN
                                            SELECT CASE WHEN DAY1='Sun' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"SUN_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "SUN_RATE")/100)* PERC/100))  || '$' || 

("Week_Extra_Rate" + ("Week_Extra_Rate" * "SUN_RATE_EXTRA")/100)
                                                        WHEN DAY1='Mon' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"MON_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "MON_RATE")/100)* PERC/100))  || '$' || 

("Week_Extra_Rate" + ("Week_Extra_Rate" * "MON_RATE_EXTRA")/100)
                                                        WHEN DAY1='Tue' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"TUE_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "TUE_RATE")/100)* PERC/100))  || '$' || 

("Week_Extra_Rate" + ("Week_Extra_Rate" * "TUE_RATE_EXTRA")/100)
                                                        WHEN DAY1='Wed' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"WED_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "WED_RATE")/100)* PERC/100))  || '$' || 

("Week_Extra_Rate" + ("Week_Extra_Rate" * "WED_RATE_EXTRA")/100)
                                                        WHEN DAY1='Thu' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"THU_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "THU_RATE")/100)* PERC/100))  || '$' || 

("Week_Extra_Rate" + ("Week_Extra_Rate" * "THU_RATE_EXTRA")/100)
                                                        WHEN DAY1='Fri' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"FRI_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "FRI_RATE")/100)* PERC/100))  || '$' || ("Week_Extra_Rate" 

+ ("Week_Extra_Rate" * "FRI_RATE_EXTRA")/100)
                                                        WHEN DAY1='Sat' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"SAT_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "SAT_RATE")/100)* PERC/100))  || '$' || 

("Week_Extra_Rate" + ("Week_Extra_Rate" * "SAT_RATE_EXTRA")/100)
                                                    END
                                                        INTO FINALRATE
                                                FROM RATE_MAST WHERE "rateuniqueid"=FRATEUNIQUEID;
                                                EXCEPTION
                                                WHEN NO_DATA_FOUND THEN  NULL;
                                               END;
                                    ELSE
                                           BEGIN
                                            SELECT CASE WHEN DAY1='Sun' THEN (("Week_Day_Rate" + "SUN_RATE") + 

(("Week_Day_Rate" + "SUN_RATE")* PERC/100))  || '$' || ("Week_Extra_Rate" + "SUN_RATE_EXTRA")
                                                        WHEN DAY1='Mon' THEN (("Week_Day_Rate" + "MON_RATE") + 

(("Week_Day_Rate" + "MON_RATE")* PERC/100))  || '$' || ("Week_Extra_Rate" + "MON_RATE_EXTRA")
                                                        WHEN DAY1='Tue' THEN (("Week_Day_Rate" + "TUE_RATE") + (("Week_Day_Rate" 

+ "TUE_RATE")* PERC/100))  || '$' || ("Week_Extra_Rate" + "TUE_RATE_EXTRA")
                                                        WHEN DAY1='Wed' THEN (("Week_Day_Rate" + "WED_RATE") + 

(("Week_Day_Rate" + "WED_RATE")* PERC/100))  || '$' || ("Week_Extra_Rate" + "WED_RATE_EXTRA")
                                                        WHEN DAY1='Thu' THEN (("Week_Day_Rate" + "THU_RATE") + (("Week_Day_Rate" 

+ "THU_RATE")* PERC/100))  || '$' || ("Week_Extra_Rate" + "THU_RATE_EXTRA")
                                                        WHEN DAY1='Fri' THEN (("Week_Day_Rate" + "FRI_RATE") + (("Week_Day_Rate" + 

"FRI_RATE")* PERC/100))  || '$' || ("Week_Extra_Rate" + "FRI_RATE_EXTRA")
                                                        WHEN DAY1='Sat' THEN (("Week_Day_Rate" + "SAT_RATE") + (("Week_Day_Rate" 

+ "SAT_RATE")* PERC/100))  || '$' || ("Week_Extra_Rate" + "SAT_RATE_EXTRA")
                                                    END
                                                        INTO FINALRATE
                                                FROM RATE_MAST WHERE "rateuniqueid"=FRATEUNIQUEID;
                                                EXCEPTION
                                                WHEN NO_DATA_FOUND THEN  NULL;
                                               END;
                                    END IF;

                                END IF;

                        END IF;
                        if uomdesc = 'CD' then
                            SELECT "Week_Extra_Rate" INTO SOLORATEWEEK FROM RATE_MAST WHERE 

"rateuniqueid"=FRATEUNIQUEID;
                        else
                            SELECT "Week_Day_Rate" INTO SOLORATEWEEK FROM RATE_MAST WHERE 

"rateuniqueid"=FRATEUNIQUEID;
                        end if;
 dbms_output.put_line('FINALRATE'||FINALRATE);
                         SELECT SUBSTR(FINALRATE,1,INSTR(FINALRATE,'$')-1) INTO CARD_RATE FROM DUAL;
                         SELECT SUBSTR(FINALRATE,INSTR(FINALRATE,'$')+1) INTO EXTRA_RATE FROM DUAL;
                          FEXTRA_RATE:=0;
                          FCARD_RATE:=0;
                           dbms_output.put_line('CARD_RATE'||CARD_RATE);
                           
                        -- IF uomdesc != 'CD' THEN
                             IF EXTRA_RATE IS NULL THEN
                                EXTRA_RATE:=CARD_RATE;
                            END IF;
                             dbms_output.put_line('EXTRA_RATE'||EXTRA_RATE);
                             dbms_output.put_line('LINE'||LINE);
                             dbms_output.put_line('RLINE'||RLINE);
                             IF TO_NUMBER(LINE)>TO_NUMBER(RLINE) THEN
                                EXTRALINE:=LINE-RLINE;
                             --     dbms_output.put_line('EXTRALINE'||EXTRALINE);
                              --  CARD_RATE:= CARD_RATE * EXTRALINE;
                                FEXTRA_RATE:=EXTRA_RATE * EXTRALINE;
                                FCARD_RATE:= CARD_RATE + FEXTRA_RATE;
                             ELSE
                                FCARD_RATE:= CARD_RATE;
                                FEXTRA_RATE:=EXTRA_RATE;
                             END IF;
                       --  END IF;
                        dbms_output.put_line('premiumval'||PREM);
                        IF specialsize is not null and specialsizerate is not null then
                            FCARD_RATE:=TO_NUMBER(FCARD_RATE) + (TO_NUMBER(specialsize) * 

TO_NUMBER(specialsizerate));
                        end if;
                        IF PREM IS NOT NULL AND PREM!='0'  THEN
                            FCARD_RATE:=TO_NUMBER(FCARD_RATE) + (TO_NUMBER(FCARD_RATE) * 

TO_NUMBER(Getpospremium(PREM,compcode))/100);
                        END IF;
                        IF PAGEPREMNO IS NOT NULL AND PAGEPREMNO!='0'  THEN
                             dbms_output.put_line(PKGALIAS||'********'||PAGEPREMNO);
                             SELECT "premium_charges_type" INTO PREMTYPE FROM advpos_prem_mast WHERE 

"Premiumcode"=PAGEPREMNO  AND "comp_code"=compcode;
                             IF(PREMTYPE='per') then
                                FCARD_RATE:=TO_NUMBER(FCARD_RATE) + (TO_NUMBER(FCARD_RATE) * 

TO_NUMBER(Getpagepremium(PAGEPREMNO,compcode))/100);
                             ELSE
                                FCARD_RATE:=TO_NUMBER(FCARD_RATE) + 

TO_NUMBER(Getpagepremium(PAGEPREMNO,compcode));   
                             END IF;   
                        END IF;
                        ---- FOR FIX SIZE
                       
                        IF AdType='DI0' THEN
                             DBMS_OUTPUT.PUT_LINE('FIX SIZE12');
                            SELECT "Size_From" INTO SIZEFROM_FIX FROM RATE_MAST WHERE 

"rateuniqueid"=FRATEUNIQUEID;
                            DBMS_OUTPUT.PUT_LINE(SIZEFROM_FIX);
                            IF SIZEFROM_FIX IS NOT NULL AND SIZEFROM_FIX!='0' THEN
                            DBMS_OUTPUT.PUT_LINE('SIZEFROM_FIX');
                                CARD_RATE:=TO_NUMBER(CARD_RATE)/TO_NUMBER(SIZEFROM_FIX);
                                DBMS_OUTPUT.PUT_LINE(CARD_RATE);
                                EXTRA_RATE:=TO_NUMBER(EXTRA_RATE)/TO_NUMBER(SIZEFROM_FIX);
                            END IF;
                        END IF;
                        ----
                        INSERT INTO 

FINALRATE(PCODE,EDITION_NAME,RATEID,CARDRATE,EXTRARATE,FCARDRATE,FEXTRARATE,ADVCAT1,ADVCAT2,

ADVCAT3,ADVCAT4,ADVCAT5,LINES,PKG_ALIAS,SOLORATE) 

VALUES(PKGCODE,EDITIONNAME,FRATEUNIQUEID,CARD_RATE,EXTRA_RATE,FCARD_RATE,FEXTRA_RATE,ADCAT1,

ADCAT2,ADCAT3,ADCAT4,ADCAT5,LINE,PKGALIAS,SOLORATEWEEK);
                        IF schemetype = '1' THEN
                            INSERT INTO SCHEME_TEMP SELECT "From_Insertion_No","To_Insertion_No", "Discount", 

"Discount_Type", PKGCODE,"Scheme_Name","Scheme_Code","scheme_id" FROM SCHEME_MASTER WHERE 

"Scheme_Code" =(SELECT "Scheme_Code" FROM SCHEME_MASTER WHERE "scheme_id"=(SELECT "Scheme_Name" 

FROM RATE_MAST WHERE "rateuniqueid"=FRATEUNIQUEID) AND ROWNUM<=1) AND 

"From_Insertion_No"<=INSERTIONNUM AND "To_Insertion_No"<=INSERTIONNUM;
                        ELSE
                            INSERT INTO SCHEME_TEMP SELECT "From_Insertion_No","To_Insertion_No", "Discount", 

"Discount_Type", PKGCODE,"Scheme_Name","Scheme_Code","scheme_id" FROM SCHEME_MASTER WHERE 

"Scheme_Code" =(SELECT "Scheme_Code" FROM SCHEME_MASTER WHERE "scheme_id"=(SELECT "Scheme_Name" 

FROM RATE_MAST WHERE "rateuniqueid"=FRATEUNIQUEID) AND ROWNUM<=1) AND INSERTIONNUM 

="To_Insertion_No"; --BETWEEN "From_Insertion_No" AND "To_Insertion_No";
                        END IF;
                    ELSE
                    --PACKAGE

                                IF openreferExtra = 'open' THEN
                                    IF ratepremtype = 'per' THEN
                                          BEGIN
                                           DBMS_OUTPUT.PUT_LINE('LLL'|| EDITIONNAME || ',' || FRATEUNIQUEID || ','||PKGALIAS ||',' || 

DAY1 || ',' || PERC);
                                           SELECT CASE  WHEN DAY1='Sun' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"SUN_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "SUN_RATE")/100)* PERC/100))  || '$' || 

(("Week_Extra_Rate" + ("Week_Extra_Rate" * "SUN_RATE_EXTRA")/100) + (("Week_Extra_Rate" + ("Week_Extra_Rate" * 

"SUN_RATE_EXTRA")/100) * PERC/100))
                                                        WHEN DAY1='Mon' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"MON_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "MON_RATE")/100)* PERC/100))  || '$' || 

(("Week_Extra_Rate" + ("Week_Extra_Rate" * "MON_RATE_EXTRA")/100) + (("Week_Extra_Rate" + ("Week_Extra_Rate" * 

"MON_RATE_EXTRA")/100) * PERC/100))
                                                        WHEN DAY1='Tue' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"TUE_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "TUE_RATE")/100)* PERC/100))  || '$' || 

(("Week_Extra_Rate" + ("Week_Extra_Rate" * "TUE_RATE_EXTRA")/100) + (("Week_Extra_Rate" + ("Week_Extra_Rate" * 

"TUE_RATE_EXTRA")/100) * PERC/100))
                                                        WHEN DAY1='Wed' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"WED_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "WED_RATE")/100)* PERC/100))  || '$' || 

(("Week_Extra_Rate" + ("Week_Extra_Rate" * "WED_RATE_EXTRA")/100) + (("Week_Extra_Rate" + ("Week_Extra_Rate" * 

"WED_RATE_EXTRA")/100) * PERC/100))
                                                        WHEN DAY1='Thu' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"THU_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "THU_RATE")/100)* PERC/100))  || '$' || 

(("Week_Extra_Rate" + ("Week_Extra_Rate" * "THU_RATE_EXTRA")/100) + (("Week_Extra_Rate" + ("Week_Extra_Rate" * 

"THU_RATE_EXTRA")/100) * PERC/100))
                                                        WHEN DAY1='Fri' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"FRI_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "FRI_RATE")/100)* PERC/100))  || '$' || (("Week_Extra_Rate" 

+ ("Week_Extra_Rate" * "FRI_RATE_EXTRA")/100) + (("Week_Extra_Rate" + ("Week_Extra_Rate" * 

"FRI_RATE_EXTRA")/100) * PERC/100))
                                                        WHEN DAY1='Sat' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"SAT_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "SAT_RATE")/100)* PERC/100))  || '$' || 

(("Week_Extra_Rate" + ("Week_Extra_Rate" * "SAT_RATE_EXTRA")/100) + (("Week_Extra_Rate" + ("Week_Extra_Rate" * 

"SAT_RATE_EXTRA")/100) * PERC/100))
                                            END
                                                INTO FINALRATE
                                                FROM RATE_DETAILS WHERE "ratemastid"=FRATEUNIQUEID  AND 

LTRIM(RTRIM("edition_name"))=LTRIM(RTRIM(EDITIONNAME)) AND ("PKGNAME"=LTRIM(RTRIM(PKGALIAS)) OR 

"PKGNAME" IS NULL);
                                            EXCEPTION
                                            WHEN NO_DATA_FOUND THEN  NULL;
                                            END;
                                           
                                    ELSE
                                          BEGIN
                                           SELECT CASE WHEN  DAY1='Sun' THEN (("Week_Day_Rate" + "SUN_RATE") + 

(("Week_Day_Rate" + "SUN_RATE")* PERC/100))  || '$' || (("Week_Extra_Rate" + "SUN_RATE_EXTRA") + 

(("Week_Extra_Rate" + "SUN_RATE_EXTRA") * PERC/100))
                                                        WHEN DAY1='Mon' THEN (("Week_Day_Rate" + "MON_RATE") + 

(("Week_Day_Rate" + "MON_RATE")* PERC/100))  || '$' || (("Week_Extra_Rate" + "MON_RATE_EXTRA") + 

(("Week_Extra_Rate" + "MON_RATE_EXTRA") * PERC/100))
                                                        WHEN DAY1='Tue' THEN (("Week_Day_Rate" + "TUE_RATE") + (("Week_Day_Rate" 

+ "TUE_RATE")* PERC/100))  || '$' || (("Week_Extra_Rate" + "TUE_RATE_EXTRA") + (("Week_Extra_Rate" + 

"TUE_RATE_EXTRA") * PERC/100))
                                                        WHEN DAY1='Wed' THEN (("Week_Day_Rate" + "WED_RATE") + 

(("Week_Day_Rate" + "WED_RATE")* PERC/100))  || '$' || (("Week_Extra_Rate" + "WED_RATE_EXTRA") + 

(("Week_Extra_Rate" + "WED_RATE_EXTRA") * PERC/100))
                                                        WHEN DAY1='Thu' THEN (("Week_Day_Rate" + "THU_RATE") + (("Week_Day_Rate" 

+ "THU_RATE")* PERC/100))  || '$' || (("Week_Extra_Rate" + "THU_RATE_EXTRA") + (("Week_Extra_Rate" + 

"THU_RATE_EXTRA") * PERC/100))
                                                        WHEN DAY1='Fri' THEN (("Week_Day_Rate" + "FRI_RATE") + (("Week_Day_Rate" + 

"FRI_RATE")* PERC/100))  || '$' || (("Week_Extra_Rate" + "FRI_RATE_EXTRA") + (("Week_Extra_Rate" + 

"FRI_RATE_EXTRA") * PERC/100))
                                                        WHEN DAY1='Sat' THEN (("Week_Day_Rate" + "SAT_RATE") + (("Week_Day_Rate" 

+ "SAT_RATE")* PERC/100))  || '$' || (("Week_Extra_Rate" + "SAT_RATE_EXTRA") + (("Week_Extra_Rate" + 

"SAT_RATE_EXTRA") * PERC/100))
                                            END
                                             INTO FINALRATE
                                            FROM RATE_DETAILS WHERE "ratemastid"=FRATEUNIQUEID AND 

LTRIM(RTRIM("edition_name"))=LTRIM(RTRIM(EDITIONNAME)) AND ("PKGNAME"=LTRIM(RTRIM(PKGALIAS)) OR 

"PKGNAME" IS NULL);
                                            EXCEPTION
                                            WHEN NO_DATA_FOUND THEN  NULL;
                                            END;
                                    END IF;
                                ELSE
                                    IF ratepremtype = 'per' THEN
                                          BEGIN
                                            SELECT CASE WHEN DAY1='Sun' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"SUN_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "SUN_RATE")/100)* PERC/100))  || '$' || 

("Week_Extra_Rate" + ("Week_Extra_Rate" * "SUN_RATE_EXTRA")/100)
                                                        WHEN DAY1='Mon' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"MON_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "MON_RATE")/100)* PERC/100))  || '$' || 

("Week_Extra_Rate" + ("Week_Extra_Rate" * "MON_RATE_EXTRA")/100)
                                                        WHEN DAY1='Tue' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"TUE_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "TUE_RATE")/100)* PERC/100))  || '$' || 

("Week_Extra_Rate" + ("Week_Extra_Rate" * "TUE_RATE_EXTRA")/100)
                                                        WHEN DAY1='Wed' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"WED_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "WED_RATE")/100)* PERC/100))  || '$' || 

("Week_Extra_Rate" + ("Week_Extra_Rate" * "WED_RATE_EXTRA")/100)
                                                        WHEN DAY1='Thu' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"THU_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "THU_RATE")/100)* PERC/100))  || '$' || 

("Week_Extra_Rate" + ("Week_Extra_Rate" * "THU_RATE_EXTRA")/100)
                                                        WHEN DAY1='Fri' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"FRI_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "FRI_RATE")/100)* PERC/100))  || '$' || ("Week_Extra_Rate" 

+ ("Week_Extra_Rate" * "FRI_RATE_EXTRA")/100)
                                                        WHEN DAY1='Sat' THEN (("Week_Day_Rate" + ("Week_Day_Rate" * 

"SAT_RATE")/100) + (("Week_Day_Rate" + ("Week_Day_Rate" * "SAT_RATE")/100)* PERC/100))  || '$' || 

("Week_Extra_Rate" + ("Week_Extra_Rate" * "SAT_RATE_EXTRA")/100)
                                                    END
                                                        INTO FINALRATE
                                                FROM RATE_DETAILS WHERE "ratemastid"=FRATEUNIQUEID AND 

LTRIM(RTRIM("edition_name"))=LTRIM(RTRIM(EDITIONNAME)) AND ("PKGNAME"=LTRIM(RTRIM(PKGALIAS)) OR 

"PKGNAME" IS NULL);
                                                EXCEPTION
                                                WHEN NO_DATA_FOUND THEN  NULL;
                                               END;
                                    ELSE
                                           BEGIN
                                            SELECT CASE WHEN DAY1='Sun' THEN (("Week_Day_Rate" + "SUN_RATE") + 

(("Week_Day_Rate" + "SUN_RATE")* PERC/100))  || '$' || ("Week_Extra_Rate" + "SUN_RATE_EXTRA")
                                                        WHEN DAY1='Mon' THEN (("Week_Day_Rate" + "MON_RATE") + 

(("Week_Day_Rate" + "MON_RATE")* PERC/100))  || '$' || ("Week_Extra_Rate" + "MON_RATE_EXTRA")
                                                        WHEN DAY1='Tue' THEN (("Week_Day_Rate" + "TUE_RATE") + (("Week_Day_Rate" 

+ "TUE_RATE")* PERC/100))  || '$' || ("Week_Extra_Rate" + "TUE_RATE_EXTRA")
                                                        WHEN DAY1='Wed' THEN (("Week_Day_Rate" + "WED_RATE") + 

(("Week_Day_Rate" + "WED_RATE")* PERC/100))  || '$' || ("Week_Extra_Rate" + "WED_RATE_EXTRA")
                                                        WHEN DAY1='Thu' THEN (("Week_Day_Rate" + "THU_RATE") + (("Week_Day_Rate" 

+ "THU_RATE")* PERC/100))  || '$' || ("Week_Extra_Rate" + "THU_RATE_EXTRA")
                                                        WHEN DAY1='Fri' THEN (("Week_Day_Rate" + "FRI_RATE") + (("Week_Day_Rate" + 

"FRI_RATE")* PERC/100))  || '$' || ("Week_Extra_Rate" + "FRI_RATE_EXTRA")
                                                        WHEN DAY1='Sat' THEN (("Week_Day_Rate" + "SAT_RATE") + (("Week_Day_Rate" 

+ "SAT_RATE")* PERC/100))  || '$' || ("Week_Extra_Rate" + "SAT_RATE_EXTRA")
                                                    END
                                                        INTO FINALRATE
                                                FROM RATE_DETAILS WHERE "ratemastid"=FRATEUNIQUEID AND 

LTRIM(RTRIM("edition_name"))=LTRIM(RTRIM(EDITIONNAME)) AND ("PKGNAME"=LTRIM(RTRIM(PKGALIAS)) OR 

"PKGNAME" IS NULL);
                                                EXCEPTION
                                                WHEN NO_DATA_FOUND THEN  NULL;
                                               END;
                                    END IF;

                                END IF;
                                begin
                                SELECT "Solus_week_rate" INTO SOLORATEWEEK FROM RATE_DETAILS WHERE 

"ratemastid"=FRATEUNIQUEID AND LTRIM(RTRIM("edition_name"))=LTRIM(RTRIM(EDITIONNAME)) AND 

("PKGNAME"=LTRIM(RTRIM(PKGALIAS)) OR "PKGNAME" IS NULL);
                                  EXCEPTION
                                                WHEN NO_DATA_FOUND THEN  NULL;
                                               END;
                         SELECT SUBSTR(FINALRATE,1,INSTR(FINALRATE,'$')-1) INTO CARD_RATE FROM DUAL;
                         SELECT SUBSTR(FINALRATE,INSTR(FINALRATE,'$')+1) INTO EXTRA_RATE FROM DUAL;
                         FEXTRA_RATE:=0;
                         FCARD_RATE:=0;
                                IF EXTRA_RATE IS NULL THEN
                                    EXTRA_RATE:=CARD_RATE;
                                END IF;
                         --IF uomdesc != 'CD' THEN
                            IF SOLORATEWEEK IS NULL OR SOLORATEWEEK='0' THEN
                             DBMS_OUTPUT.PUT_LINE('SOLORATEWEEK...'||SOLORATEWEEK);
                                select 

"Comp_code","combin_desc","Adv_Cat_Code","Adv_subcat_code","Rate_Gr_Code","Valid_From","Valid_To"
                                into compcode_M,combindesc_M,advcatcode_M 

,advsubcatcode_M,rategroupcode_M,validfrom_M,validto_M
                                from rate_mast where "rateuniqueid"=FRATEUNIQUEID;
                                DBMS_OUTPUT.PUT_LINE('compcode_M...'||compcode_M);
                                DBMS_OUTPUT.PUT_LINE('combindesc_M...'||combindesc_M);
                                DBMS_OUTPUT.PUT_LINE('advcatcode_M...'||advcatcode_M);
                                DBMS_OUTPUT.PUT_LINE('advsubcatcode_M...'||advsubcatcode_M);
                                DBMS_OUTPUT.PUT_LINE('rategroupcode_M...'||rategroupcode_M);
                                DBMS_OUTPUT.PUT_LINE('validfrom_M...'||validfrom_M);
                                DBMS_OUTPUT.PUT_LINE('validto_M...'||validto_M);
                                DBMS_OUTPUT.PUT_LINE('EDITIONNAME_M...'||EDITIONNAME);
                               BEGIN
                                select "Week_Day_Rate","Week_Extra_Rate" into weekdayrate_M,weekextrarate_M from rate_mast 
                                where "Comp_code"=compcode_M AND "combin_desc"=EDITIONNAME  AND 

"Adv_Type_Code"=Adtype AND "Adv_Cat_Code"=advcatcode_M
                                AND "Adv_subcat_code"=advsubcatcode_M AND "Currency"=currency
                                AND "Rate_Gr_Code"=rategroupcode_M and "Color"=Col and "Premium"=premiumval
                                AND "Uom"=uom and "Valid_From"=validfrom_M and "Valid_To"=validto_M AND INSERTIONNUM 

BETWEEN "From_insertion" AND "To_insertion";-- and "Combin_Code"=  PKGCODE;
                                EXCEPTION
                                                WHEN NO_DATA_FOUND THEN  NULL;
                                               END;
                                IF weekdayrate_M IS NULL OR weekdayrate_M = '0' THEN
                                    SOLORATEWEEK:=weekextrarate_M;
                                ELSE
                                    SOLORATEWEEK:=weekdayrate_M;    
                                END IF;
                                DBMS_OUTPUT.PUT_LINE('SOLORATEWEEK...'||SOLORATEWEEK);
                            END IF;
                             IF TO_NUMBER(LINE)>TO_NUMBER(RLINE) THEN
                                DBMS_OUTPUT.PUT_LINE('LINES...'||LINE);
                                DBMS_OUTPUT.PUT_LINE('RLINE...'||RLINE);
                                DBMS_OUTPUT.PUT_LINE('MIN_SIZE...'||MIN_SIZE);
                                IF rateflag='Y' THEN
                                    
                                    IF uomdesc = 'CD' THEN
                                        IF(TO_NUMBER(LINE)>TO_NUMBER(MIN_SIZE)) THEN
                                            EXTRALINE:=MIN_SIZE-RLINE;
                                          --  CARD_RATE:= CARD_RATE * EXTRALINE;
                                            FEXTRA_RATE:=EXTRA_RATE * EXTRALINE;
                                            FCARD_RATE:= CARD_RATE + FEXTRA_RATE;  
                                            DIFFSIZE:=TO_NUMBER(LINE) - TO_NUMBER(MIN_SIZE);
                                            FEXTRA_RATE:=EXTRA_RATE + (SOLORATEWEEK * DIFFSIZE);
                                            FCARD_RATE:= FCARD_RATE + (SOLORATEWEEK * DIFFSIZE);
                                        else
                                             EXTRALINE:=LINE-RLINE;
                                            -- CARD_RATE:= CARD_RATE * EXTRALINE;
                                             FEXTRA_RATE:=EXTRA_RATE * EXTRALINE;
                                             FCARD_RATE:= CARD_RATE + FEXTRA_RATE;    
                                        END IF;
                                    else
                                         EXTRALINE:=LINE-RLINE;
                                      --   CARD_RATE:= CARD_RATE * EXTRALINE;
                                         FEXTRA_RATE:=EXTRA_RATE * EXTRALINE;
                                         FCARD_RATE:= CARD_RATE + FEXTRA_RATE;    
                                    END IF;
                                ELSE
                                     EXTRALINE:=LINE-RLINE;
                                   --  CARD_RATE:= CARD_RATE * EXTRALINE;
                                     FEXTRA_RATE:=EXTRA_RATE * EXTRALINE;
                                     FCARD_RATE:= CARD_RATE + FEXTRA_RATE;    
                                END IF;    
                             ELSE
                                FCARD_RATE:= CARD_RATE;
                                FEXTRA_RATE:=EXTRA_RATE;
                              
                             END IF;
                        -- END IF;
                           IF specialsize is not null and specialsizerate is not null then
                            FCARD_RATE:=TO_NUMBER(FCARD_RATE) + (TO_NUMBER(specialsize) * 

TO_NUMBER(specialsizerate));
                        end if;
                        IF PREM IS NOT NULL AND PREM !='0' THEN
                             FCARD_RATE:=TO_NUMBER(FCARD_RATE) + (TO_NUMBER(FCARD_RATE) * 

TO_NUMBER(Getpospremium(PREM,compcode))/100);
                        END IF;
                        IF PAGEPREMNO IS NOT NULL AND PAGEPREMNO !='0' THEN
                            FCARD_RATE:=TO_NUMBER(FCARD_RATE) + (TO_NUMBER(FCARD_RATE) * 

TO_NUMBER(Getpagepremium(PAGEPREMNO,compcode))/100);
                        END IF;
                         ---- FOR FIX SIZE
                          DBMS_OUTPUT.PUT_LINE('FIX SIZE');
                        IF AdType='DI0' THEN
                             DBMS_OUTPUT.PUT_LINE('FIX SIZE12');
                            SELECT "Size_From" INTO SIZEFROM_FIX FROM RATE_MAST WHERE 

"rateuniqueid"=FRATEUNIQUEID;
                            DBMS_OUTPUT.PUT_LINE(SIZEFROM_FIX);
                            IF SIZEFROM_FIX IS NOT NULL AND SIZEFROM_FIX!='0' THEN
                            DBMS_OUTPUT.PUT_LINE('SIZEFROM_FIX');
                                CARD_RATE:=TO_NUMBER(CARD_RATE)/TO_NUMBER(SIZEFROM_FIX);
                                DBMS_OUTPUT.PUT_LINE(CARD_RATE);
                                EXTRA_RATE:=TO_NUMBER(EXTRA_RATE)/TO_NUMBER(SIZEFROM_FIX);
                            END IF;
                        END IF;
                        ----
                        INSERT INTO 

FINALRATE(PCODE,EDITION_NAME,RATEID,CARDRATE,EXTRARATE,FCARDRATE,FEXTRARATE,ADVCAT1,ADVCAT2,

ADVCAT3,ADVCAT4,ADVCAT5,LINES,PKG_ALIAS,SOLORATE) 

VALUES(PKGCODE,EDITIONNAME,FRATEUNIQUEID,CARD_RATE,EXTRA_RATE,FCARD_RATE,FEXTRA_RATE,ADCAT1,

ADCAT2,ADCAT3,ADCAT4,ADCAT5,LINE,PKGALIAS,SOLORATEWEEK);
                        IF schemetype = '1' THEN
                            INSERT INTO SCHEME_TEMP SELECT "From_Insertion_No","To_Insertion_No", "Discount", 

"Discount_Type", PKGCODE,"Scheme_Name","Scheme_Code","scheme_id" FROM SCHEME_MASTER WHERE 

"Scheme_Code" =(SELECT "Scheme_Code" FROM SCHEME_MASTER WHERE "scheme_id"=(SELECT "Scheme_Name" 

FROM RATE_MAST WHERE "rateuniqueid"=FRATEUNIQUEID) AND ROWNUM<=1) AND 

"From_Insertion_No"<=INSERTIONNUM AND "To_Insertion_No"<=INSERTIONNUM;
                        ELSE
                            INSERT INTO SCHEME_TEMP SELECT "From_Insertion_No","To_Insertion_No", "Discount", 

"Discount_Type", PKGCODE,"Scheme_Name","Scheme_Code","scheme_id" FROM SCHEME_MASTER WHERE 

"Scheme_Code" =(SELECT "Scheme_Code" FROM SCHEME_MASTER WHERE "scheme_id"=(SELECT "Scheme_Name" 

FROM RATE_MAST WHERE "rateuniqueid"=FRATEUNIQUEID) AND ROWNUM<=1) AND INSERTIONNUM 

="To_Insertion_No";--BETWEEN "From_Insertion_No" AND "To_Insertion_No";
                        END IF;
                    END IF;
                 COUNTRATE:=NULL;
                 FINALRATE:=NULL;

             END LOOP;
        END ;
        COUNTRATE:=NULL;
        RATEUNIQUEID:=NULL;
        FRATEUNIQUEID:=NULL;
        PKGCODE:=NULL;
        EDITIONNAME:=NULL;
        BDATE:=NULL;
        PERC:=NULL;
        COLREFER:=NULL;
        LINE:=NULL;
        ADCAT1:=NULL;
        ADCAT2:=NULL;
        ADCAT3:=NULL;
        ADCAT4:=NULL;
        ADCAT5:=NULL;
        CARD_RATE:=NULL;
        EXTRA_RATE:=NULL;
        FCARD_RATE:=NULL;
        FEXTRA_RATE:=NULL;
       
       SELECT COUNT(*) INTO COUNTRATE FROM ADONS_DETAILS WHERE "rateuniqueid" IN (SELECT RATEID FROM 

FINALRATE);
       SELECT COUNT(*) INTO COUNTADON FROM ADONS_DETAILS WHERE "rateuniqueid" IN (SELECT RATEID FROM 

FINALRATE) AND "Edition_Name" IN(SELECT EDITION_NAME FROM FINALRATE);

       
       IF COUNTRATE!=COUNTADON THEN
              
        BEGIN
         SELECT "Edition_Name",NVL(NO_OF_INSERT,0) INTO COUNTADONEDITION,COUNTADONINSERT FROM 

ADONS_DETAILS WHERE "rateuniqueid" IN (SELECT RATEID FROM FINALRATE) AND "Edition_Name" NOT IN(SELECT 

EDITION_NAME FROM FINALRATE) AND ROWNUM<=1;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN  NULL;
        END;
        DBMS_OUTPUT.PUT_LINE('COUNTADON');
        DBMS_OUTPUT.PUT_LINE(COUNTADONINSERT);
         IF COUNTADONINSERT IS NOT NULL AND COUNTADONINSERT!=0 AND counter<=COUNTADONINSERT THEN
         INSERT INTO ERRORMESSAGE(MESSAGE) VALUES('Please Take '|| COUNTADONEDITION || ' as Ad-Ons');
         COMMIT;
         GOTO L;
         END IF;      
       END IF;  
        
        
       IF COUNTRATE IS NOT NULL THEN
        DECLARE CURSOR R2_CURSOR
        IS
                SELECT DISTINCT "rateuniqueid" FROM ADONS_DETAILS WHERE "rateuniqueid" IN (SELECT RATEID FROM 

FINALRATE) AND "Edition_Name" IN(SELECT EDITION_NAME FROM FINALRATE);
        BEGIN
           OPEN R2_CURSOR;

             LOOP
                FETCH R2_CURSOR
                 INTO FRATEUNIQUEID;
                   EXIT WHEN R2_CURSOR%NOTFOUND;
                        SELECT  ADVCAT1, ADVCAT2, ADVCAT3, ADVCAT4, ADVCAT5 INTO ADCAT1, ADCAT2, ADCAT3, 

ADCAT4, ADCAT5 FROM FINALRATE WHERE "RATEID" = FRATEUNIQUEID AND ROWNUM<=1;

                        SELECT COUNT(*) INTO COUNTRATE1 FROM FINALRATE WHERE RATEID != FRATEUNIQUEID AND 

ADVCAT1 = ADCAT1 AND ADVCAT2 = ADCAT2 AND ADVCAT3 = ADCAT3 AND ADVCAT4 = ADCAT4 AND ADVCAT5 = 

ADCAT5 AND EDITION_NAME IN(SELECT "Edition_Name" FROM ADONS_DETAILS WHERE 

"rateuniqueid"=FRATEUNIQUEID);
                          DBMS_OUTPUT.PUT_LINE('LATA MADAN');
                          DBMS_OUTPUT.PUT_LINE(COUNTRATE1);
                          
                      IF COUNTRATE1 IS NOT NULL THEN

                         DECLARE CURSOR R3_CURSOR
                            IS
                                    SELECT RATEID,EDITION_NAME,LINES FROM FINALRATE WHERE RATEID != FRATEUNIQUEID 

AND ADVCAT1 = ADCAT1 AND ADVCAT2 = ADCAT2 AND ADVCAT3 = ADCAT3 AND ADVCAT4 = ADCAT4 AND 

ADVCAT5 = ADCAT5 AND EDITION_NAME IN(SELECT "Edition_Name" FROM ADONS_DETAILS WHERE 

"rateuniqueid"=FRATEUNIQUEID);
                            BEGIN
                               OPEN R3_CURSOR;

                                     LOOP
                                        FETCH R3_CURSOR
                                         INTO ARATEUNIQUEID, AEDITIONNAME, LINE;
                                           EXIT WHEN R3_CURSOR%NOTFOUND;
                                           BEGIN
                                           DBMS_OUTPUT.PUT_LINE('TEST-*'||ARATEUNIQUEID);
                                            SELECT "Rate","EXTRARATE" INTO CARD_RATE, EXTRA_RATE FROM ADONS_DETAILS 

WHERE "rateuniqueid"=FRATEUNIQUEID AND "Edition_Name"=AEDITIONNAME;

                                                    IF CARD_RATE IS NOT NULL THEN
                                                      SELECT "Size_To" INTO RLINE FROM RATE_MAST WHERE 

"rateuniqueid"=ARATEUNIQUEID;
                                                       DBMS_OUTPUT.PUT_LINE('LINE*-'||LINE);
                                                       DBMS_OUTPUT.PUT_LINE('RLINE*-'||RLINE);
                                                         IF LINE>RLINE THEN
                                                            EXTRALINE:=LINE-RLINE;
                                                            FEXTRA_RATE:=EXTRA_RATE * EXTRALINE;
                                                            FCARD_RATE:= CARD_RATE + FEXTRA_RATE;
                                                         ELSE
                                                            FCARD_RATE:= CARD_RATE;
                                                            FEXTRA_RATE:=EXTRA_RATE;
                                                         END IF;
                                                    END IF;
                                                EXCEPTION
                                                WHEN NO_DATA_FOUND THEN  NULL;
                                                END;
                                                 DBMS_OUTPUT.PUT_LINE('AEDITIONNAME-*'||AEDITIONNAME);
                                         UPDATE FINALRATE SET CARDRATE=CARD_RATE , EXTRARATE=EXTRA_RATE, 

FCARDRATE = FCARD_RATE , FEXTRARATE=FEXTRA_RATE WHERE RATEID=ARATEUNIQUEID AND 

EDITION_NAME=AEDITIONNAME;
                                             CARD_RATE:=NULL;
                                             EXTRA_RATE:=NULL;
                                             FCARD_RATE:=NULL;
                                             FEXTRA_RATE:=NULL;
                                     END LOOP;
                             END;
                      END IF;
             END LOOP;
        END;

       END IF;
       COMMIT;
        <<L>>
            OPEN p_accounts FOR
                SELECT * FROM ERRORMESSAGE;
            OPEN p_accounts1 FOR
                SELECT PCODE, EDITION_NAME, RATEID, CARDRATE, EXTRARATE, FCARDRATE, 

FEXTRARATE,PKG_ALIAS,SOLORATE,(SELECT "Pub_Code" from  EDITION_MAST WHERE 

"Edition_Alias"=EDITION_NAME) as PUBCODE,(SELECT "Size_To" FROM RATE_MAST where "rateuniqueid"=RATEID) AS 

MINWORD,
                (SELECT NVL(VAT_DETAIL,'0') FROM RATE_MAST WHERE "rateuniqueid"=RATEID) as  VAT_INC
                FROM FINALRATE ORDER BY PCODE;
                
            IF COUNTSCHEMEEDITION IS NOT NULL AND COUNTSCHEMEEDITION!=0 THEN
                OPEN p_accounts2 FOR                 
                SELECT DISTINCT "From_Insertion_No" AS "FROM_INSERT","To_Insertion_No" AS "TO_INS","Discount" AS 

"AMT","Discount_Type" AS "TYPE",EDITION_NAME AS "PKG_CODE","Scheme_Name" AS 

"SCHEMENAME","Scheme_Code" AS "SCHEMECODE","scheme_id" AS "SCHEMEID",'T' AS "VAL" FROM 

SCHEME_MASTER , SCHEME_MASTER_EDITION WHERE 

SCHEME_MASTER_EDITION.SCHEMECODE=SCHEME_MASTER."Scheme_Code" ORDER BY EDITION_NAME ;
            ELSE
                OPEN p_accounts2 FOR
                SELECT distinct A.*,'P' AS "VAL" FROM SCHEME_TEMP A ORDER BY PKG_CODE;
            END IF;      
            dbg('agencycode:'||agencycode||'/'||uomcode);
        select count(*) into comm_rec  FROM COMM_DETAILS WHERE 

"Agency_code"||"Agency_sub_code"=UPPER(agencycode) AND UOM=uomcode AND ROWID=(SELECT MAX(ROWID) 

FROM COMM_DETAILS WHERE "Agency_code"||"Agency_sub_code"=UPPER(agencycode) and UOM=uomcode);
        if(comm_rec=0) THEN
          OPEN p_accounts3 FOR
              SELECT NVL("Comm_Rate",0) AS COMM_RATE , NVL("Addl_Comm_Rate",0) AS 

ADD_COMM_RATE,nvl(ADDITIONAL_FLAG,'0') as FLAG,FLOORAMT AS FLOORAMT FROM COMM_DETAILS WHERE 

"Agency_code"||"Agency_sub_code"=UPPER(agencycode) AND NVL(UOM,'!!') !=uomcode AND ROWID=(SELECT 

MAX(ROWID) FROM COMM_DETAILS WHERE "Agency_code"||"Agency_sub_code"=UPPER(agencycode) AND 

NVL(UOM,'!!')!=uomcode);
           
        else
           OPEN p_accounts3 FOR
            SELECT NVL("Comm_Rate",0) AS COMM_RATE , NVL("Addl_Comm_Rate",0) AS 

ADD_COMM_RATE,nvl(ADDITIONAL_FLAG,'0') as FLAG,FLOORAMT AS FLOORAMT FROM COMM_DETAILS WHERE 

"Agency_code"||"Agency_sub_code"=UPPER(agencycode) AND UOM=uomcode AND ROWID=(SELECT MAX(ROWID) 

FROM COMM_DETAILS WHERE "Agency_code"||"Agency_sub_code"=UPPER(agencycode) and UOM=uomcode);
           
         END IF;
commit;          
         END rate_qbc_p;
END Rate_Qbc;
/


/* Formatted on 2011/11/09 14:29 (Formatter Plus v4.8.8) */
CREATE OR REPLACE PROCEDURE bindpackage_adon (
   compcode     IN       VARCHAR2,
   adtype       IN       VARCHAR2,
   p_accounts   OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT   "Combin_Code", "Package_Name",
               ("Combin_Code" || '@' || "Combin_Desc") AS "pck_code"
          FROM combin_mast
         WHERE "Comp_Code" = compcode
           AND "Ad_Type_code" = adtype
           AND "Combin_Code" IN (
                                 SELECT DISTINCT "Combin_Code"
                                            FROM rate_mast
                                           WHERE "Comp_code" = compcode
                                             AND "ADON" = 'Y')
      ORDER BY "Package_Name";
END;
/

/* Formatted on 2011/11/09 14:30 (Formatter Plus v4.8.8) */
CREATE OR REPLACE PROCEDURE bindreferenceid_tv (
   compcode_p   IN       VARCHAR2,
   agency_p     IN       VARCHAR2,
   client_p     IN       VARCHAR2,
   p_accounts   OUT      cur_type_new1.cursor_type
)
IS
BEGIN
   OPEN p_accounts FOR
      SELECT bk_num AS cioid
        FROM tv_booking_mst
       WHERE comp_code = compcode_p
         AND (   agency_code || sub_agency = agency_p
              OR agency_p IS NULL
              OR agency_p = ''
             )
         AND (client_code = client_p OR client_p IS NULL OR client_p = '');
END;
/


/* Formatted on 2011/11/09 14:30 (Formatter Plus v4.8.8) */
CREATE OR REPLACE procedure committransaction(cioid varchar2,totalcount int, p_error              OUT      VARCHAR2)
is
countnum int;
newid varchar2(100);
billpay varchar2(20);
rostatus varchar2(20);
remarks varchar2(500);
clientname varchar2(200);
begin
newid:=cioid;

select count(*) into countnum from tbl_booking_insert_g where Cio_Booking_Id=cioid;
if(countnum=totalcount) then
  p_error :='Y';
 INSERT INTO tbladid_ins(CIOID,COUNTNUM,FLAG) VALUES(newid,countnum,p_error);
 INSERT INTO TBL_BOOKING_MAST("date_time", "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by", "audit", "RO_No", "RO_Date", "Caption", "bill_status", "ro_status", "Agency_code", "Agency_address", "Client_code", "Client_address", "Agency_sub_code", "Dockit_no", "Executive_code", "Executive_zone", "Product_code", "Brand_code", "Key_no", "Bill_remarks", "Print_remark", "Package_code", "No_of_insertion", "Insertion_date", "Repeating_day", "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code", "Color_code", "Uom_code", "Page_position_code", "Page_type_code", "Page_no", "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code", "Scheme_type_code", "Currency_code", "Agrred_rate", "Agreed_amount", "Special_discount", "Space_discount", "Special_charges", "Agency_status", "Agency_type", "Agency_pay", "Agency_credit", "Total_area", "Card_rate", "Card_amount", "Discount", "Discount_per", "Bill_cycle", "Revenue_center", "Bill_pay", "Bill_height", "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc", "Agency_out", "Box_code", "Box_no", "Box_agency", "Box_client", "Box_address", "Comp_code", "Userid", "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad", "Campaign", "Bill_amount", "Page_prem", "Page_amount", "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", "Bill_area", "Special_disc_per", "Space_disc_per", "Paid_ins", "Contract_rate", "Deviation", "Variant_code", "Contract_name", "Contract_type", "Card_name", "Card_type", "Card_month", "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", "Bullet_code", "Bullet_premium", "Material_status", "Receipt_date", "prev_cioid", "prev_receipt", "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom", "SAPID", "RETAINER", "ADD_AGENCY_COMM", "AUDIT_COMMENT", "MOBILENO", "ADD_AGENCY_COMM_AMT", "RETAINER_COMM", "RETAINER_COMM_AMT", "CASH_RECIEVED", "CONT_GROSS", "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION", "CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER", "RODOCSTATUS",CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID) 
SELECT DATE_TIME, BRANCH, BOOKED_BY, CIO_BOOKING_ID, PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO, RO_DATE, CAPTION, BILL_STATUS, RO_STATUS, AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE, CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO, EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE, BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK, PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE, REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE, AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE, PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO, AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH, RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE, AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT, SPACE_DISCOUNT, SPECIAL_CHARGES, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY, AGENCY_CREDIT, TOTAL_AREA, CARD_RATE, CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE, REVENUE_CENTER, BILL_PAY, BILL_HEIGHT, BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD, TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO, BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS, COMP_CODE, USERID, CREATION_DATETIME, BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN, BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER, GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN, BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER, PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE, CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME, CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER, RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, BG_COLOR, BULLET_CODE, BULLET_PREMIUM, MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID, PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT, COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR, LOGO_UOM, SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO, ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS, CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, RODOCSTATUS,CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK, DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=cioid;

INSERT INTO TBL_BOOKING_insert("Insert_Id", "Cio_Booking_Id", "No_Insert", "Edition_Code", "Publication_Code", "Pub_Cent_Code", "Supp_Code", "Edition", "Insert_Date", "Col_Code", "Height", "Width", "Size_Book", "Page_Post", "Premium1", "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow", "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Repeating_Date", "Status_Material", "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status", "Bill_Status", "Agreed_Rate", "Pai_Free_Ins", "Solo_Rate", "Gross_Rate", "Comp_Code", "Userid", "Page_No", "Remarks", "Pub_Height", "Pub_Width", "Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5", "PACKAGE_CODE", "BILL_NO", "BILL_DATE", "INSERTS", "PKG_ALIAS", "CONT_GROSS_AMT", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER",SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT, LOCALBILLAMT,SECTIONCODE,RESOURCE_NO) 
SELECT INSERT_ID, CIO_BOOKING_ID, NO_INSERT, EDITION_CODE, PUBLICATION_CODE, PUB_CENT_CODE, SUPP_CODE, EDITION, INSERT_DATE, COL_CODE, HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1, PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW, AD_CAT, AD_SUB_CAT, LATEST_BY, REPEATING_DATE, STATUS_MATERIAL, FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS, BILL_STATUS, AGREED_RATE, PAI_FREE_INS, SOLO_RATE, GROSS_RATE, COMP_CODE, USERID, PAGE_NO, REMARKS, PUB_HEIGHT, PUB_WIDTH, PAGE_PREM, PAGE_PER, NO_OFCOLUMN, BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, PACKAGE_CODE, BILL_NO, BILL_DATE, INSERTS, PKG_ALIAS, CONT_GROSS_AMT, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, SPECIAL_SIZE1,VATAMT, BOXCHARGE, VAT_INC,LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=cioid;

INSERT INTO TBL_BOOKING_VTS(COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE) 
SELECT COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE FROM TBL_BOOKING_VTS_G WHERE  cioid=newid;

insert into tbl_booking_insert_sizesplit(CIOID, RECEIPTNO, INSERTID, INSERTDATE, HEIGHT, WIDTH, AREA, SRNO, CREATIONDATETIME)
select CIOID, RECEIPTNO, INSERTID, INSERTDATE, HEIGHT, WIDTH, AREA, SRNO, CREATIONDATETIME from tbl_booking_insert_sizesplit_g where cioid=newid;

--INSERT INTO ABCTEST VALUES(newid,counttest);
insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO, NO_INSERT)
select COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO, SRNO, NO_INSERT from tbl_booking_subedition_g
where tbl_booking_subedition_g.CIOID=newid;

insert into TBL_BOOKING_SHARING_TRANS(PUBLICATION, TYPE, SHARING, CIOID, SRNO)
select PUBLICATION, TYPE, SHARING, CIOID, SRNO from TBL_BOOKING_SHARING_TRANS_g where CIOID=cioid ;

insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID, CREATIONDATETIME)
select CIOID, INSERTID, CREATIONDATETIME from TBL_BOOKING_FMG_TRANS_G where CIOID=cioid;
 select "Bill_pay","ro_status" into billpay,rostatus from tbl_booking_mast where "cio_booking_id"=cioid;
 if billpay = 'CA0' and rostatus='1' then
 declare
    cursor c1 is
        select * from tbl_booking_mast where "cio_booking_id"=cioid;
       
   v1 c1%rowtype;
   v_error      varchar2(2000);
    v_rcptno_r      varchar2(50);
   vrecpt       varchar2(20);
   branchcode   varchar2(20);
   vrepcode     varchar2(20);
   subagencyreg varchar2(20);
   prevcioid_v varchar2(50);
   billamt_v float;
   grossamt_v float;
  v_curdate date;
 begin
 open c1;
 fetch c1 into v1;
    Begin
        select "Branch_Code" into branchcode from branch_mst where "Comp_Code"=v1."Comp_code" and "Branch_Name"=v1."branch";
    Exception When no_data_found then
        branchcode:='';
    End;
   
    Begin
        select "SUB_Agency_Code" into subagencyreg from agency_mast where "Comp_Code"=v1."Comp_code" and "code_subcode"=v1."Agency_sub_code";
    Exception When no_data_found then
        subagencyreg:='';
    End;
   vrecpt:=v1."Receipt_no";
   prevcioid_v:=v1."prev_cioid";
   if prevcioid_v is null or v1."prev_receipt" is null then
    billamt_v:=v1."Bill_amount";
    grossamt_v:=v1."Gross_amount";
    v_curdate:=to_date(sysdate);
   else
    select "Bill_amount","Gross_amount" into  billamt_v,grossamt_v from tbl_booking_mast where "cio_booking_id"=prevcioid_v;
    billamt_v:=v1."Bill_amount" - billamt_v;
     grossamt_v:=v1."Gross_amount" - grossamt_v;
     IF grossamt_v=0 OR grossamt_v IS NULL THEN
         grossamt_v:=v1."Gross_amount";
     END IF;
     v_curdate:=to_date(sysdate);
   end if;
   -- select substr(max("recptno"),1,12)||lpad(substr(max("recptno"),-6)+1,6,'0') into vrecpt from ad_rcpthdr where "unit"=branchcode and "doctype"='RCP' and
   -- "recptdt" between '1-mar-2011' and '31-mar-2011';
 
 --receiptsave_booking.receiptsave_booking_P(pcompcode,puserid , punit ,ptype , precpt , prdate , ppaymodres ,preceivedreg ,pvouno  ,pamount  ,pagency , pothercd ,
  --pchno  ,pchedate , pbank  , pnarration ,prep   , pvdate , pag_main_code ,pag_sub_code , ourbank,  cioid , execname , retainer ,
   -- prevcioid , p_error)
   begin
 SELECT "Cust_Name" into clientname FROM CUST_MAST WHERE "Cust_Code" = v1."Client_code" and "Comp_Code"=v1."Comp_code";
exception
when NO_DATA_FOUND THEN
clientname:=v1."Client_code";
END;

remarks:='RONO#'||v1."RO_No" ||' RODATE# ' || to_char(v1."RO_Date",'dd-mon-yyyy') || ' BOOKINGID# ' || v1."cio_booking_id" || ' CLIENT#' || clientname;

   receiptsave_booking.receiptsave_booking_p(v1."Comp_code",v1."Userid", v1."branch",V1.DOCTYPE,vrecpt,v_curdate,v1."Bill_pay",'','',billamt_v,v1."Agency_sub_code",grossamt_v,
    '','','',remarks,vrepcode,v1."date_time",v1."Agency_code",subagencyreg,'',v1."cio_booking_id",v1."Executive_code",v1.RETAINER,v1."prev_cioid",v_rcptno_r,v_error);
   
  update tbl_booking_mast set "Receipt_no"=v_rcptno_r,"Receipt_date"= v_curdate where "cio_booking_id"=v1."cio_booking_id";
 close c1;
 commit;
 end;
 end if;
 /*
 INSERT INTO TBL_BOOKING_MAST("date_time", "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by", "audit", "RO_No", "RO_Date", "Caption", "bill_status", "ro_status", "Agency_code", "Agency_address", "Client_code", "Client_address", "Agency_sub_code", "Dockit_no", "Executive_code", "Executive_zone", "Product_code", "Brand_code", "Key_no", "Bill_remarks", "Print_remark", "Package_code", "No_of_insertion", "Insertion_date", "Repeating_day", "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code", "Color_code", "Uom_code", "Page_position_code", "Page_type_code", "Page_no", "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code", "Scheme_type_code", "Currency_code", "Agrred_rate", "Agreed_amount", "Special_discount", "Space_discount", "Special_charges", "Agency_status", "Agency_type", "Agency_pay", "Agency_credit", "Total_area", "Card_rate", "Card_amount", "Discount", "Discount_per", "Bill_cycle", "Revenue_center", "Bill_pay", "Bill_height", "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc", "Agency_out", "Box_code", "Box_no", "Box_agency", "Box_client", "Box_address", "Comp_code", "Userid", "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad", "Campaign", "Bill_amount", "Page_prem", "Page_amount", "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", "Bill_area", "Special_disc_per", "Space_disc_per", "Paid_ins", "Contract_rate", "Deviation", "Variant_code", "Contract_name", "Contract_type", "Card_name", "Card_type", "Card_month", "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", "Bullet_code", "Bullet_premium", "Material_status", "Receipt_date", "prev_cioid", "prev_receipt", "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom", "SAPID", "RETAINER", "ADD_AGENCY_COMM", "AUDIT_COMMENT", "MOBILENO", "ADD_AGENCY_COMM_AMT", "RETAINER_COMM", "RETAINER_COMM_AMT", "CASH_RECIEVED", "CONT_GROSS", "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION", "CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER", "RODOCSTATUS") 
SELECT DATE_TIME, BRANCH, BOOKED_BY, CIO_BOOKING_ID, PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO, RO_DATE, CAPTION, BILL_STATUS, RO_STATUS, AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE, CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO, EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE, BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK, PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE, REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE, AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE, PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO, AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH, RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE, AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT, SPACE_DISCOUNT, SPECIAL_CHARGES, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY, AGENCY_CREDIT, TOTAL_AREA, CARD_RATE, CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE, REVENUE_CENTER, BILL_PAY, BILL_HEIGHT, BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD, TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO, BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS, COMP_CODE, USERID, CREATION_DATETIME, BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN, BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER, GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN, BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER, PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE, CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME, CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER, RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, BG_COLOR, BULLET_CODE, BULLET_PREMIUM, MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID, PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT, COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR, LOGO_UOM, SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO, ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS, CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, RODOCSTATUS FROM TBL_BOOKING_MAST_G WHERE SESID=USERENV ('sessionid') and CIO_BOOKING_ID=cioid;

INSERT INTO TBL_BOOKING_insert("Insert_Id", "Cio_Booking_Id", "No_Insert", "Edition_Code", "Publication_Code", "Pub_Cent_Code", "Supp_Code", "Edition", "Insert_Date", "Col_Code", "Height", "Width", "Size_Book", "Page_Post", "Premium1", "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow", "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Repeating_Date", "Status_Material", "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status", "Bill_Status", "Agreed_Rate", "Pai_Free_Ins", "Solo_Rate", "Gross_Rate", "Comp_Code", "Userid", "Page_No", "Remarks", "Pub_Height", "Pub_Width", "Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5", "PACKAGE_CODE", "BILL_NO", "BILL_DATE", "INSERTS", "PKG_ALIAS", "CONT_GROSS_AMT", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER") 
SELECT INSERT_ID, CIO_BOOKING_ID, NO_INSERT, EDITION_CODE, PUBLICATION_CODE, PUB_CENT_CODE, SUPP_CODE, EDITION, INSERT_DATE, COL_CODE, HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1, PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW, AD_CAT, AD_SUB_CAT, LATEST_BY, REPEATING_DATE, STATUS_MATERIAL, FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS, BILL_STATUS, AGREED_RATE, PAI_FREE_INS, SOLO_RATE, GROSS_RATE, COMP_CODE, USERID, PAGE_NO, REMARKS, PUB_HEIGHT, PUB_WIDTH, PAGE_PREM, PAGE_PER, NO_OFCOLUMN, BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, PACKAGE_CODE, BILL_NO, BILL_DATE, INSERTS, PKG_ALIAS, CONT_GROSS_AMT, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER FROM TBL_BOOKING_INSERT_G WHERE SESID=USERENV ('sessionid') and CIO_BOOKING_ID=cioid;

*/
else
rollback;
 p_error :='N';
--DELETE FROM TBL_BOOKING_INSERT WHERE "Cio_Booking_Id"=cioid;
--DELETE FROM TBL_BOOKING_mast WHERE "cio_booking_id"=cioid;
INSERT INTO tbladid_ins(CIOID,COUNTNUM,FLAG) VALUES(newid,countnum,p_error);
end if;
--delete from tbl_booking_mast_g where  CIO_BOOKING_ID=cioid;
--delete from tbl_booking_insert_g where  CIO_BOOKING_ID=cioid;
--delete from tbl_booking_vts_g where  cioid=newid;
end;
/



/* Formatted on 2011/11/09 14:31 (Formatter Plus v4.8.8) */
CREATE OR REPLACE PROCEDURE fetchpassword (
   compcode_p   IN       VARCHAR2,
   userid_p     IN       VARCHAR2,
   p_accounts   OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT "password" AS "PASSWORD"
        FROM login
       WHERE "COM_CODE" = compcode_p AND "userid" = userid_p;
END;
/


CREATE OR REPLACE PACKAGE Insertintobooking
IS
   PROCEDURE  insertintobooking_P (
	date_time IN DATE,
	adsizetype IN VARCHAR2,
	branch IN VARCHAR2,
	booked_by IN VARCHAR2,
	prevbook IN VARCHAR2,
	approvedby IN VARCHAR2,
	ciobookid IN VARCHAR2,
	audit1 IN VARCHAR2,
	rono IN VARCHAR2,
	rodate IN DATE,
	caption IN VARCHAR2,
	billstatus IN VARCHAR2,
	rostatus IN VARCHAR2,
	agency IN VARCHAR2,
	client IN VARCHAR2,
	agencyaddress IN VARCHAR2,
	clientaddresses IN VARCHAR2,
	agencycode IN VARCHAR2,
	dockitno IN VARCHAR2,
	execname IN VARCHAR2,
	execzone IN VARCHAR2,
	product IN VARCHAR2,
	brand IN VARCHAR2,
	keyno IN VARCHAR2,
	billremark IN VARCHAR2,
	printremark IN VARCHAR2,
	PACKAGE1 IN VARCHAR2,
	insertion IN NUMBER,
	startdate IN DATE,
	repeatdate IN VARCHAR2,
	adtype1 IN VARCHAR2,
	Adcategory IN VARCHAR2,
	subcategory IN VARCHAR2,
	color IN VARCHAR2,
	uom IN VARCHAR2,
	pageposition IN VARCHAR2,
	pagetype1 IN VARCHAR2,
	pageno IN NUMBER,
	adsizheight IN NUMBER,
	adsizwidth IN NUMBER,
	scheme1 IN VARCHAR2,
	currency IN VARCHAR2,
	ratecode11 IN VARCHAR2,
	agreedrate IN NUMBER,
	agreedamt IN NUMBER,
	spedisc IN NUMBER,
	compcode IN VARCHAR2,
	spacedisx IN NUMBER,
	specialcharges IN NUMBER,
	userid IN VARCHAR2,
	agencytype IN VARCHAR2,
	agencystatus IN VARCHAR2,
	paymode IN VARCHAR2,
	agenccredit IN NUMBER,
	cardrate IN NUMBER,
	cardamount IN NUMBER,
	discount IN NUMBER,
	discountper IN NUMBER,
	billaddress IN VARCHAR2,
	totarea IN NUMBER,
	billcycle IN VARCHAR2,
	billpay IN VARCHAR2,
	revenuecenter IN VARCHAR2,
	billheight IN NUMBER,
	billwidth IN NUMBER,
	billto IN VARCHAR2,
	invoices IN NUMBER,
	vts IN NUMBER,
	tradedisc IN NUMBER,
	agencyout IN VARCHAR2,
	boxcode IN VARCHAR2,
	boxno IN VARCHAR2,
	boxagency IN VARCHAR2,
	boxaddress IN VARCHAR2,
	boxclient IN VARCHAR2,
	coupan IN VARCHAR2,
	bookingtype IN VARCHAR2,
	tfn IN VARCHAR2,
	campaign IN VARCHAR2,
	bill_amt IN NUMBER,
	pageprem IN VARCHAR2,
	pageamt IN NUMBER,
	premper IN NUMBER,
	grossamt IN NUMBER,
	adsizcolumn IN NUMBER,
	billcolumn IN NUMBER,
	specdiscper IN NUMBER,
	spacediscper IN NUMBER,
	billarea IN NUMBER,
	paidins IN NUMBER,
	dealrate IN NUMBER,
	deviation IN NUMBER,
	varient IN VARCHAR2,
	contractname IN VARCHAR2,
	dealtype IN VARCHAR2,
	cardname IN VARCHAR2,
	cardtype IN VARCHAR2,
	cardmonth IN VARCHAR2,
	cardyear IN VARCHAR2,
	cardno IN VARCHAR2,
	receiptno IN VARCHAR2,
	adscat3 IN VARCHAR2,
	adscat4 IN VARCHAR2,
	adscat5 IN VARCHAR2,
	bgcolor IN VARCHAR2,
	bulletcode IN VARCHAR2,
	bulletprm IN NUMBER,
	material IN VARCHAR2,
	receiptdate IN DATE:=NULL,
	prevcioid IN VARCHAR2:=NULL,
	prevreceipt IN VARCHAR2:=NULL,
	prev_ga IN NUMBER:=NULL,
	varient_name IN VARCHAR2:=NULL,
	region1 IN VARCHAR2:=NULL,
	coltype IN VARCHAR2,
	logo_h IN VARCHAR2,
	logo_w IN VARCHAR2,
	logo_col IN VARCHAR2,
	logo_uom IN VARCHAR2,
	retainer1 IN VARCHAR2,
	addagencyrate IN VARCHAR2,
    mobileno    in varchar2,
    addlamt in varchar2,
retamt in varchar2,
retper in varchar2,
cashrecieved in number,
CIRAGENCY_V in varchar2,
CIRRATE_V in varchar2,
CIREDITION_V in varchar2,
CIRPUBLICATION_V in varchar2,
CIRAGENCYSUBCODE_V in varchar2,
BARTERTYPE IN VARCHAR2,
CASHDISCOUNT_V IN VARCHAR2,
CASHDISCOUNTPER_V IN VARCHAR2,
attach1 in varchar2,
attach2 in varchar2,
drpdiscprem in varchar2,
doctype_v in varchar2,
CHKTRADE IN VARCHAR2,
sharepub_p in varchar2,
fmginsert in varchar2,
chkno in VARCHAR2,
chkdate in date:=null,
chkamt in VARCHAR2,
chkbankname in varchar2,
ourbank	in varchar2,
DEALERPANEL_P in VARCHAR2,
DEALERH_P in FLOAT,
DEALERW_P in FLOAT,
DEALERTYPE_P in VARCHAR2,
multiselect in VARCHAR2,
AGREEDRATE_ACTIVE NUMBER,
AGREEDAMT_ACTIVE NUMBER,
grossamtlocal_p number,
billamtlocal_p number,
chkadon_p varchar2,
refid_p varchar2,
p_error out varchar2
   );
END Insertintobooking;
/


CREATE OR REPLACE PACKAGE BODY insertintobooking
IS
   PROCEDURE insertintobooking_p (
      date_time            IN       DATE,
      adsizetype           IN       VARCHAR2,
      branch               IN       VARCHAR2,
      booked_by            IN       VARCHAR2,
      prevbook             IN       VARCHAR2,
      approvedby           IN       VARCHAR2,
      ciobookid            IN       VARCHAR2,
      audit1               IN       VARCHAR2,
      rono                 IN       VARCHAR2,
      rodate               IN       DATE,
      caption              IN       VARCHAR2,
      billstatus           IN       VARCHAR2,
      rostatus             IN       VARCHAR2,
      agency               IN       VARCHAR2,
      client               IN       VARCHAR2,
      agencyaddress        IN       VARCHAR2,
      clientaddresses      IN       VARCHAR2,
      agencycode           IN       VARCHAR2,
      dockitno             IN       VARCHAR2,
      execname             IN       VARCHAR2,
      execzone             IN       VARCHAR2,
      product              IN       VARCHAR2,
      brand                IN       VARCHAR2,
      keyno                IN       VARCHAR2,
      billremark           IN       VARCHAR2,
      printremark          IN       VARCHAR2,
      package1             IN       VARCHAR2,
      insertion            IN       NUMBER,
      startdate            IN       DATE,
      repeatdate           IN       VARCHAR2,
      adtype1              IN       VARCHAR2,
      adcategory           IN       VARCHAR2,
      subcategory          IN       VARCHAR2,
      color                IN       VARCHAR2,
      uom                  IN       VARCHAR2,
      pageposition         IN       VARCHAR2,
      pagetype1            IN       VARCHAR2,
      pageno               IN       NUMBER,
      adsizheight          IN       NUMBER,
      adsizwidth           IN       NUMBER,
      scheme1              IN       VARCHAR2,
      currency             IN       VARCHAR2,
      ratecode11           IN       VARCHAR2,
      agreedrate           IN       NUMBER,
      agreedamt            IN       NUMBER,
      spedisc              IN       NUMBER,
      compcode             IN       VARCHAR2,
      spacedisx            IN       NUMBER,
      specialcharges       IN       NUMBER,
      userid               IN       VARCHAR2,
      agencytype           IN       VARCHAR2,
      agencystatus         IN       VARCHAR2,
      paymode              IN       VARCHAR2,
      agenccredit          IN       NUMBER,
      cardrate             IN       NUMBER,
      cardamount           IN       NUMBER,
      discount             IN       NUMBER,
      discountper          IN       NUMBER,
      billaddress          IN       VARCHAR2,
      totarea              IN       NUMBER,
      billcycle            IN       VARCHAR2,
      billpay              IN       VARCHAR2,
      revenuecenter        IN       VARCHAR2,
      billheight           IN       NUMBER,
      billwidth            IN       NUMBER,
      billto               IN       VARCHAR2,
      invoices             IN       NUMBER,
      vts                  IN       NUMBER,
      tradedisc            IN       NUMBER,
      agencyout            IN       VARCHAR2,
      boxcode              IN       VARCHAR2,
      boxno                IN       VARCHAR2,
      boxagency            IN       VARCHAR2,
      boxaddress           IN       VARCHAR2,
      boxclient            IN       VARCHAR2,
      coupan               IN       VARCHAR2,
      bookingtype          IN       VARCHAR2,
      tfn                  IN       VARCHAR2,
      campaign             IN       VARCHAR2,
      bill_amt             IN       NUMBER,
      pageprem             IN       VARCHAR2,
      pageamt              IN       NUMBER,
      premper              IN       NUMBER,
      grossamt             IN       NUMBER,
      adsizcolumn          IN       NUMBER,
      billcolumn           IN       NUMBER,
      specdiscper          IN       NUMBER,
      spacediscper         IN       NUMBER,
      billarea             IN       NUMBER,
      paidins              IN       NUMBER,
      dealrate             IN       NUMBER,
      deviation            IN       NUMBER,
      varient              IN       VARCHAR2,
      contractname         IN       VARCHAR2,
      dealtype             IN       VARCHAR2,
      cardname             IN       VARCHAR2,
      cardtype             IN       VARCHAR2,
      cardmonth            IN       VARCHAR2,
      cardyear             IN       VARCHAR2,
      cardno               IN       VARCHAR2,
      receiptno            IN       VARCHAR2,
      adscat3              IN       VARCHAR2,
      adscat4              IN       VARCHAR2,
      adscat5              IN       VARCHAR2,
      bgcolor              IN       VARCHAR2,
      bulletcode           IN       VARCHAR2,
      bulletprm            IN       NUMBER,
      material             IN       VARCHAR2,
      receiptdate          IN       DATE := NULL,
      prevcioid            IN       VARCHAR2 := NULL,
      prevreceipt          IN       VARCHAR2 := NULL,
      prev_ga              IN       NUMBER := NULL,
      varient_name         IN       VARCHAR2 := NULL,
      region1              IN       VARCHAR2 := NULL,
      coltype              IN       VARCHAR2,
      logo_h               IN       VARCHAR2,
      logo_w               IN       VARCHAR2,
      logo_col             IN       VARCHAR2,
      logo_uom             IN       VARCHAR2,
      retainer1            IN       VARCHAR2,
      addagencyrate        IN       VARCHAR2,
      mobileno             IN       VARCHAR2,
      addlamt              IN       VARCHAR2,
      retamt               IN       VARCHAR2,
      retper               IN       VARCHAR2,
      cashrecieved         IN       NUMBER,
      ciragency_v          IN       VARCHAR2,
      cirrate_v            IN       VARCHAR2,
      ciredition_v         IN       VARCHAR2,
      cirpublication_v     IN       VARCHAR2,
      ciragencysubcode_v   IN       VARCHAR2,
      bartertype           IN       VARCHAR2,
      CASHDISCOUNT_V IN VARCHAR2,
CASHDISCOUNTPER_V IN VARCHAR2,
attach1 in varchar2,
attach2 in varchar2,
drpdiscprem in varchar2,
doctype_v in varchar2,
CHKTRADE IN VARCHAR2,
sharepub_p in varchar2,
fmginsert in varchar2,
chkno in VARCHAR2,
chkdate in date:=null,
chkamt in VARCHAR2,
chkbankname in varchar2,
ourbank    in varchar2,
DEALERPANEL_P in VARCHAR2,
DEALERH_P in FLOAT,
DEALERW_P in FLOAT,
DEALERTYPE_P in VARCHAR2,
multiselect in VARCHAR2,
AGREEDRATE_ACTIVE NUMBER,
AGREEDAMT_ACTIVE NUMBER,
grossamtlocal_p number,
billamtlocal_p number,
chkadon_p varchar2,
refid_p varchar2,
      p_error              OUT      VARCHAR2
   )
   AS
      sccode   VARCHAR2 (50);
      agencytype1 varchar2(20);
       error1 varchar2(100);
       rate_auth varchar2(2);
       bk_audit varchar2(2);
       auditn varchar2(50);
       username_v varchar2(50);
       roleid_v varchar2(20);
       RELAUTHREQ varchar2(1);
   BEGIN
   agencytype1:=agencytype;
   if agencytype is null then
    select "Agency_Type_Code" into agencytype1 from agency_mast where "code_subcode"=agencycode;
   end if;
   select RATE_AUTHORIZATION,"audit",RELAUTHREQON into rate_auth,bk_audit,RELAUTHREQ from preferrences where 

"comp_code"=compcode;
      -- BEGIN
           --SELECT distinct "scheme_id" INTO sccode FROM SCHEME_MASTER WHERE 

"Scheme_Name"=LTRIM(RTRIM(scheme1)) AND ("Comp_code"=compcode);
          -- EXCEPTION WHEN NO_DATA_FOUND THEN NULL ;
      -- END;
     select "username",ROLEID into username_v,roleid_v from login where "userid"=userid;   
    if roleid_v!='SE0' AND RELAUTHREQ != 'A' then 
        IF RELAUTHREQ = 'D' THEN
            if rate_auth='Y' and bk_audit='y' and agreedamt is null then
               
                auditn:=username_v;
            else
                auditn:=audit1;    
            end if;
        ELSE
        
            auditn:=username_v;    
        END IF;    
    else
     auditn:=audit1; 
    end if;    
      sccode := scheme1;
  
     
      /*INSERT INTO tbl_booking_mast
                  ("date_time", "branch", "booked_by", "cio_booking_id",
                   "prev_booking", "applied_by", "audit", "RO_No",
                   "RO_Date", "Caption", "bill_status", "ro_status",
                   "Agency_code", "Agency_address", "Client_code",
                   "Client_address", "Agency_sub_code", "Dockit_no",
                   "Executive_code", "Executive_zone", "Product_code",
                   "Brand_code", "Key_no", "Bill_remarks", "Print_remark",
                   "Package_code", "No_of_insertion", "Insertion_date",
                   "Repeating_day", "Ad_type_code", "Ad_cat_code",
                   "Ad_sub_cat_code", "Color_code", "Uom_code",
                   "Page_position_code", "Page_type_code", "Page_no",
                   "Ad_size_type_code", "Ad_size_height", "Ad_size_width",
                   "Rate_code", "Scheme_type_code", "Currency_code",
                   "Agrred_rate", "Agreed_amount", "Special_discount",
                   "Space_discount", "Special_charges", "Comp_code",
                   "Userid", "Agency_status", "Agency_type", "Agency_pay",
                   "Agency_credit", "Total_area", "Card_rate",
                   "Card_amount", "Discount", "Discount_per", "Bill_cycle",
                   "Revenue_center", "Bill_pay", "Bill_height",
                   "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add",
                   "Trade_disc", "Agency_out", "Box_code", "Box_no",
                   "Box_agency", "Box_client", "Box_address",
                   "Booking_type", "Tfn", "Coupan_ad", "Campaign",
                   "Bill_amount", "Page_prem", "Page_amount", "Prem_per",
                   "Gross_amount", "Ad_size_column", "Bill_column",
                   "Bill_area", "Special_disc_per", "Space_disc_per",
                   "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                   "Contract_name", "Contract_type", "Card_name",
                   "Card_type", "Card_month", "Card_year", "Card_number",
                   "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5",
                   "Bg_color", "Bullet_code", "Bullet_premium",
                   "Material_status", "Receipt_date", "prev_cioid",
                   "prev_receipt", "prev_grossamt", "Region", "Variant",
                   "Colortype", "Logo_H", "Logo_W", "Logo_color",
                   "Logo_Uom", "Creation_datetime", "RETAINER",
                   "ADD_AGENCY_COMM", mobileno, add_agency_comm_amt,
                   retainer_comm, retainer_comm_amt, cash_recieved,
                   ciragency, cirrate, ciredition, cirpublication,
                   ciragency_subcode, barter_type
                  )
           VALUES (date_time, branch, booked_by, ciobookid,
                   prevbook, approvedby, audit1, rono,
                   rodate, caption, billstatus, rostatus,
                   agency, agencyaddress, client,
                   clientaddresses, agencycode, dockitno,
                   execname, execzone, product,
                   brand, keyno, billremark, printremark,
                   package1, insertion, startdate,
                   repeatdate, adtype1, adcategory,
                   subcategory, color, uom,
                   pageposition, pagetype1, pageno,
                   adsizetype, adsizheight, adsizwidth,
                   ratecode11, sccode, currency,
                   agreedrate, agreedamt, spedisc,
                   spacedisx, specialcharges, compcode,
                   userid, agencystatus, agencytype, paymode,
                   agenccredit, totarea, cardrate,
                   cardamount, discount, discountper, billcycle,
                   revenuecenter, billpay, billheight,
                   billwidth, billto, invoices, vts, billaddress,
                   tradedisc, agencyout, boxcode, boxno,
                   boxagency, boxclient, boxaddress,
                   bookingtype, tfn, coupan, campaign,
                   bill_amt, pageprem, pageamt, premper,
                   grossamt, adsizcolumn, billcolumn,
                   billarea, specdiscper, spacediscper,
                   paidins, dealrate, deviation, varient,
                   contractname, dealtype, cardname,
                   cardtype, cardmonth, cardyear, cardno,
                   receiptno, adscat3, adscat4, adscat5,
                   bgcolor, bulletcode, bulletprm,
                   material, receiptdate, prevcioid,
                   prevreceipt, prev_ga, region1, varient_name,
                   coltype, logo_h, logo_w, logo_col,
                   logo_uom, SYSDATE, retainer1,
                   addagencyrate, mobileno, addlamt,
                   retper, retamt, cashrecieved,
                   ciragency_v, cirrate_v, ciredition_v, cirpublication_v,
                   ciragencysubcode_v, bartertype
                  );
                  */
                  INSERT INTO tbl_booking_mast_g
                  (DATE_TIME, BRANCH, BOOKED_BY, CIO_BOOKING_ID,
                   PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO,
                   RO_DATE, CAPTION, BILL_STATUS, RO_STATUS,
                   AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE,
                   CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO,
                   EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE,
                   BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK,
                   PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE,
                   REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE,
                   AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE,
                   PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO,
                   AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH,
                   RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE,
                   AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT,
                   SPACE_DISCOUNT, SPECIAL_CHARGES, COMP_CODE,
                   USERID, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY,
                   AGENCY_CREDIT, TOTAL_AREA, CARD_RATE,
                   CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE,
                   REVENUE_CENTER, BILL_PAY, BILL_HEIGHT,
                   BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD,
                   TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO,
                   BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS,
                   BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN,
                   BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER,
                   GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN,
                   BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER,
                   PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE,
                   CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME,
                   CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER,
                   RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5,
                   BG_COLOR, BULLET_CODE, BULLET_PREMIUM,
                   MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID,
                   PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT,
                   COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR,
                   LOGO_UOM, CREATION_DATETIME, RETAINER,
                   ADD_AGENCY_COMM, MOBILENO, ADD_AGENCY_COMM_AMT,
                   RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED,
                   CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION,
                   CIRAGENCY_SUBCODE, BARTER_TYPE, 

SESID,CASHDISCOUNT,CASHDISCTYPE,ATTACHMENT1,ATTACHMENT2,DISC_PREMIUM,DOCTYPE,CHKTRADEDISC,
                   CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL, DEALER_H, DEALER_W, 

DEALERTYPE, ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,
                    LOCALGROSSAMT, LOCALBILLAMT,PACKAGE_TYPE, AD_REFID
                  )
           VALUES (date_time, branch, booked_by, ciobookid,
                   prevbook, approvedby, auditn, rono,
                   rodate, caption, billstatus, rostatus,
                   agency, agencyaddress, client,
                   clientaddresses, agencycode, dockitno,
                   execname, execzone, product,
                   brand, keyno, billremark, printremark,
                   package1, insertion, startdate,
                   repeatdate, adtype1, adcategory,
                   subcategory, color, uom,
                   pageposition, pagetype1, pageno,
                   adsizetype, adsizheight, adsizwidth,
                   ratecode11, sccode, currency,
                   agreedrate, agreedamt, spedisc,
                   spacedisx, specialcharges, compcode,
                   userid, agencystatus, agencytype1, paymode,
                   agenccredit, totarea, cardrate,
                   cardamount, discount, discountper, billcycle,
                   revenuecenter, billpay, billheight,
                   billwidth, billto, invoices, vts, billaddress,
                   tradedisc, agencyout, boxcode, boxno,
                   boxagency, boxclient, boxaddress,
                   bookingtype, tfn, coupan, campaign,
                   bill_amt, pageprem, pageamt, premper,
                   grossamt, adsizcolumn, billcolumn,
                   billarea, specdiscper, spacediscper,
                   paidins, dealrate, deviation, varient,
                   contractname, dealtype, cardname,
                   cardtype, cardmonth, cardyear, cardno,
                   receiptno, adscat3, adscat4, adscat5,
                   bgcolor, bulletcode, bulletprm,
                   material, receiptdate, prevcioid,
                   prevreceipt, prev_ga, region1, varient_name,
                   coltype, logo_h, logo_w, logo_col,
                   logo_uom, SYSDATE, retainer1,
                   addagencyrate, mobileno, addlamt,
                   retper, retamt, cashrecieved,
                   ciragency_v, cirrate_v, ciredition_v, cirpublication_v,
                   ciragencysubcode_v, bartertype,USERENV 

('sessionid'),CASHDISCOUNT_V,CASHDISCOUNTPER_V,attach1,attach2,drpdiscprem,doctype_v,CHKTRADE
                  ,chkno,chkdate,chkamt,chkbankname,ourbank,DEALERPANEL_P,
DEALERH_P,
DEALERW_P,
DEALERTYPE_P,AGREEDRATE_ACTIVE,
AGREEDAMT_ACTIVE,grossamtlocal_p,billamtlocal_p,chkadon_p,refid_p);
                  IF sharepub_p is not null then
                        insert_sharepub_details(sharepub_p,ciobookid,'INSERT',error1);
                  end if;
                  
                  if fmginsert is not null then
                    insert_fmgTrans_details(fmginsert,ciobookid,'INSERT',error1);   
                  end if;   
                  if multiselect is not null then
                    insert_multiexec_details(userid,compcode,multiselect,ciobookid,'INSERT',error1);
                  end if;  
                 
   EXCEPTION
      WHEN OTHERS
      THEN
         p_error := 'Error :' || SQLERRM;
         
         
         
   END insertintobooking_p;
END insertintobooking;
/



CREATE OR REPLACE PACKAGE updatebooking IS
PROCEDURE updatebooking_p(
approvedby in varchar2,
audit1 in varchar2,
rono in varchar2,
rodate in date,
caption in varchar2,
billstatus in varchar2,
rostatus in varchar2,
agency in varchar2,
client in varchar2,
agencyaddress in varchar2,
clientaddresses in varchar2,
agencycode in varchar2,
dockitno in varchar2,
execname in varchar2,
execzone in varchar2,
product in varchar2,
brand in varchar2,
keyno in varchar2,
billremark in varchar2,
printremark in varchar2,
package1 in varchar2,
insertion in number,
startdate in date,
repeatdate in varchar2,
adtype1 in varchar2,
adcategory in varchar2,
subcategory in varchar2,
color in varchar2,
uom in varchar2,
pageposition in varchar2,
pagetype1 in varchar2,
pageno in number,
adsizheight in number,
adsizwidth in number,
ratecode11 in varchar2,
scheme1 in varchar2,
currency in varchar2,
agreedrate in number,
agreedamt in number,
spedisc in number,
spacedisx in number,
compcode in varchar2,
userid in varchar2,
ciobookid in varchar2,
date_time in date,
branch in varchar2,
booked_by in varchar2,
prevbook in varchar2,
adsizetype in varchar2,
specialcharges in number,
agencytype in varchar2,
agencystatus in varchar2,
paymode in varchar2,
agencredit in number,
cardrate in number,
cardamount in number,
discount in number,
discountper in number,
billaddress in varchar2,
totarea in number,
billcycle in varchar2,
revenuecenter in varchar2,
billpay in varchar2,
billheight in number,
billwidth in number,
billto in varchar2,
invoices in number,
vts in number,
tradedisc in number,
agencyout in varchar2,
boxcode in varchar2,
boxno in varchar2,
boxaddress in varchar2,
boxagency in varchar2,
boxclient in varchar2,
bookingtype in varchar2,
tfn in varchar2,
coupan in varchar2,
campaign in varchar2,
bill_amt in number,
pageprem in varchar2,
pageamt in number,
premper in number,
grossamt in number,
adsizcolumn in number,
billarea in number,
billcolumn in number,
spacediscper in number,
specdiscper in number,
paidins in number,
dealrate in number,
deviation in number,
varient in varchar2,
dealtype in varchar2,
contractname in varchar2,
cardname in varchar2,
cardtype in varchar2,
cardmonth in varchar2,
cardyear in varchar2,
cardno in varchar2,
receiptno in varchar2,
adscat3 in varchar2,
adscat4 in varchar2,
adscat5 in varchar2,
bgcolor in varchar2,
bulletcode in varchar2,
bulletprm in number,
material in varchar2,
region1 in varchar2,
varient_name in varchar2,
coltype in varchar2,
logo_h in varchar2,
logo_w in varchar2,
logo_col in varchar2,
logo_uom in varchar2,
retainer1 in varchar2,
addagencyrate in varchar2,
mobileno in varchar2,
addlamt in varchar2,
retamt in varchar2,
retper in varchar2,
cashrecieved in varchar2,
CIRAGENCY_V in varchar2,
CIRRATE_V in varchar2,
CIREDITION_V in varchar2,
CIRPUBLICATION_V in varchar2,
CIRAGENCYSUBCODE_V in varchar2,
BARTERTYPE IN VARCHAR2,
CASHDISCOUNT_V IN VARCHAR2,
CASHDISCOUNTPER_V IN VARCHAR2,
attach1 in varchar2,
attach2 in varchar2,
drpdiscprem in varchar2,
doctype_v in varchar2,
CHKTRADE IN VARCHAR2,
sharepub_p in varchar2,
fmginsert in varchar2,chkno in VARCHAR2,
chkdate in date:=null,
chkamt in VARCHAR2,
chkbankname in varchar2,
ourbank	in varchar2,
DEALERPANEL_P in VARCHAR2,
DEALERH_P in FLOAT,
DEALERW_P in FLOAT,
DEALERTYPE_P in VARCHAR2,
multiselect in VARCHAR2,
AGREEDRATE_ACTIVE NUMBER,
AGREEDAMT_ACTIVE NUMBER,
grossamtlocal_p number,
billamtlocal_p number,
chkadon_p varchar2,
refid_p varchar2
);
End updatebooking;
/


CREATE OR REPLACE PACKAGE BODY updatebooking IS
PROCEDURE updatebooking_p(
approvedby in varchar2,
audit1 in varchar2,
rono in varchar2,
rodate in date,
caption in varchar2,
billstatus in varchar2,
rostatus in varchar2,
agency in varchar2,
client in varchar2,
agencyaddress in varchar2,
clientaddresses in varchar2,
agencycode in varchar2,
dockitno in varchar2,
execname in varchar2,
execzone in varchar2,
product in varchar2,
brand in varchar2,
keyno in varchar2,
billremark in varchar2,
printremark in varchar2,
package1 in varchar2,
insertion in number,
startdate in date,
repeatdate in varchar2,
adtype1 in varchar2,
adcategory in varchar2,
subcategory in varchar2,
color in varchar2,
uom in varchar2,
pageposition in varchar2,
pagetype1 in varchar2,
pageno in number,
adsizheight in number,
adsizwidth in number,
ratecode11 in varchar2,
scheme1 in varchar2,
currency in varchar2,
agreedrate in number,
agreedamt in number,
spedisc in number,
spacedisx in number,
compcode in varchar2,
userid in varchar2,
ciobookid in varchar2,
date_time in date,
branch in varchar2,
booked_by in varchar2,
prevbook in varchar2,
adsizetype in varchar2,
specialcharges in number,
agencytype in varchar2,
agencystatus in varchar2,
paymode in varchar2,
agencredit in number,
cardrate in number,
cardamount in number,
discount in number,
discountper in number,
billaddress in varchar2,
totarea in number,
billcycle in varchar2,
revenuecenter in varchar2,
billpay in varchar2,
billheight in number,
billwidth in number,
billto in varchar2,
invoices in number,
vts in number,
tradedisc in number,
agencyout in varchar2,
boxcode in varchar2,
boxno in varchar2,
boxaddress in varchar2,
boxagency in varchar2,
boxclient in varchar2,
bookingtype in varchar2,
tfn in varchar2,
coupan in varchar2,
campaign in varchar2,
bill_amt in number,
pageprem in varchar2,
pageamt in number,
premper in number,
grossamt in number,
adsizcolumn in number,
billarea in number,
billcolumn in number,
spacediscper in number,
specdiscper in number,
paidins in number,
dealrate in number,
deviation in number,
varient in varchar2,
dealtype in varchar2,
contractname in varchar2,
cardname in varchar2,
cardtype in varchar2,
cardmonth in varchar2,
cardyear in varchar2,
cardno in varchar2,
receiptno in varchar2,
adscat3 in varchar2,
adscat4 in varchar2,
adscat5 in varchar2,
bgcolor in varchar2,
bulletcode in varchar2,
bulletprm in number,
material in varchar2,
region1 in varchar2,
varient_name in varchar2,
coltype in varchar2,
logo_h in varchar2,
logo_w in varchar2,
logo_col in varchar2,
logo_uom in varchar2,
retainer1 in varchar2,
addagencyrate in varchar2,
mobileno in varchar2,
addlamt in varchar2,
retamt in varchar2,
retper in varchar2,
cashrecieved in varchar2,
CIRAGENCY_V in varchar2,
CIRRATE_V in varchar2,
CIREDITION_V in varchar2,
CIRPUBLICATION_V in varchar2,
CIRAGENCYSUBCODE_V in varchar2,
BARTERTYPE IN VARCHAR2,
CASHDISCOUNT_V IN VARCHAR2,
CASHDISCOUNTPER_V IN VARCHAR2,
attach1 in varchar2,
attach2 in varchar2,
drpdiscprem in varchar2,
doctype_v in varchar2,
CHKTRADE IN VARCHAR2,
sharepub_p in varchar2,
fmginsert in varchar2,
chkno in VARCHAR2,
chkdate in date:=null,
chkamt in VARCHAR2,
chkbankname in varchar2,
ourbank    in varchar2,
DEALERPANEL_P in VARCHAR2,
DEALERH_P in FLOAT,
DEALERW_P in FLOAT,
DEALERTYPE_P in VARCHAR2,
multiselect in VARCHAR2,
AGREEDRATE_ACTIVE NUMBER,
AGREEDAMT_ACTIVE NUMBER,
grossamtlocal_p number,
billamtlocal_p number,
chkadon_p varchar2,
refid_p varchar2
)As
 error1 varchar2(100);
sccode varchar2(50);
mobileno1 varchar2(50);
remarks varchar2(500);
clientname varchar2(200);
Begin
mobileno1:=mobileno;
--begin
--select distinct "scheme_id" into  sccode  from scheme_master where "Scheme_Name"=ltrim(rtrim(scheme1)) and 

"Comp_code"=compcode;
--exception when no_data_found then
--NULL ;
--end;
sccode:=scheme1;
update tbl_booking_mast set 

"date_time"=date_time,"branch"=branch,"booked_by"=booked_by,"prev_booking"=prevbook,"applied_by"=approvedby,"audit"=

audit1,"RO_No"=rono,"RO_Date"=rodate,
"Caption"=caption,"bill_status"=billstatus,"ro_status"=rostatus,"Agency_code"=agency,"Agency_address"=agencyaddress,"C

lient_code"=client,"Client_address"=clientaddresses,"Agency_sub_code"=agencycode,
"Dockit_no"=dockitno,"Executive_code"=execname,"Executive_zone"=execzone,"Product_code"=product,"Brand_code"=bran

d,"Key_no"=keyno,"Bill_remarks"=billremark,"Print_remark"=printremark,
"Package_code"=package1,"No_of_insertion"=insertion,"Insertion_date"=startdate,"Repeating_day"=repeatdate,"Ad_type_cod

e"=adtype1,"Ad_cat_code"=adcategory,"Ad_sub_cat_code"=subcategory,
"Color_code"=color,"Uom_code"=uom,"Page_position_code"=pageposition,"Page_type_code"=pagetype1,"Page_no"=pageno

,"Ad_size_type_code"=adsizetype,"Ad_size_height"=adsizheight,
"Ad_size_width"=adsizwidth,"Rate_code"=ratecode11,"Scheme_type_code"=sccode,"Currency_code"=currency,"Agrred_rate

"=agreedrate,"Agreed_amount"=agreedamt,"Special_discount"=spedisc,
"Space_discount"=spacedisx,"Special_charges"=specialcharges,"Agency_status"=agencystatus,"Agency_type"=agencytype

,"Agency_pay"=paymode,"Agency_credit"=agencredit,
"Total_area"=totarea,"Card_rate"=cardrate,"Card_amount"=cardamount,"Discount"=discount,"Discount_per"=discountper,"Bill

_cycle"=billcycle,"Revenue_center"=revenuecenter,
"Bill_pay"=billpay,"Bill_height"=billheight,"Bill_width"=billwidth,"Bill_to"=billto,"Invoices"=invoices,"Vts"=vts,"Bill_add"=billaddr

ess,"Trade_disc"=tradedisc,"Agency_out"=agencyout,
"Box_code"=boxcode,"Box_no"=boxno,"Box_agency"=boxagency,"Box_client"=boxclient,"Box_address"=boxaddress,"Booki

ng_type"=bookingtype,"Tfn"=tfn,"Coupan_ad"=coupan,"Campaign"=campaign,
"Bill_amount"=bill_amt,"Page_prem"=pageprem,"Page_amount"=pageamt,"Prem_per"=premper,"Gross_amount"=grossamt,"

Ad_size_column"=adsizcolumn,"Bill_column"=billcolumn,
"Bill_area"=billarea,"Special_disc_per"=specdiscper,"Space_disc_per"=spacediscper,"Paid_ins"=paidins,"Contract_rate"=deal

rate,"Deviation"=deviation,"Variant_code"=varient,
"Contract_name"=contractname,"Contract_type"=dealtype,"Card_name"=cardname,"Card_type"=cardtype,"Card_month"=car

dmonth,"Card_year"=cardyear,"Card_number"=cardno,"Receipt_no"=receiptno,
"Ad_Subcat3"=adscat3,"Ad_Subcat4"=adscat4,"Ad_subcat5"=adscat5,"Bg_color"=bgcolor,"Bullet_code"=bulletcode,"Bullet_

premium"=bulletprm,"Material_status"=material

,"Region"=region1,"Variant"=varient_name,"Colortype"=coltype,
"Logo_H"=logo_h,"Logo_W"=logo_w,"Logo_color"=logo_col,"Logo_Uom"=logo_uom,
"RETAINER"=retainer1, "ADD_AGENCY_COMM"=addagencyrate, 

tbl_booking_mast.MOBILENO=mobileno1,ADD_AGENCY_COMM_AMT=addlamt,RETAINER_COMM=retper,RETAINER_CO

MM_AMT=retamt,CASH_RECIEVED=cashrecieved,
CIRAGENCY=CIRAGENCY_V,CIRRATE=CIRRATE_V,CIREDITION=CIREDITION_V,CIRPUBLICATION=CIRPUBLICATION_V,

CIRAGENCY_SUBCODE=CIRAGENCYSUBCODE_V,BARTER_TYPE=BARTERTYPE,
CASHDISCOUNT=CASHDISCOUNT_V, CASHDISCTYPE=CASHDISCOUNTPER_V, ATTACHMENT1=attach1, 

ATTACHMENT2=attach2, DISC_PREMIUM=drpdiscprem, DOCTYPE=doctype_v,CHKTRADEDISC=CHKTRADE,
CHK_NO=chkno,CHK_DATE=chkdate,CHK_AMT=chkamt,CHK_BANK_NAME=chkbankname,OUR_BANK=ourbank,DEALE

RPANEL=DEALERPANEL_P, DEALER_H=DEALERH_P, DEALER_W=DEALERW_P, DEALERTYPE=DEALERTYPE_P
,ACTIVE_AGREEDRATE=AGREEDRATE_ACTIVE, 

ACTIVE_AGREEDAMT=AGREEDAMT_ACTIVE,LOCALGROSSAMT=grossamtlocal_p,LOCALBILLAMT=billamtlocal_p,
PACKAGE_TYPE=chkadon_p, AD_REFID=refid_p
where "Comp_code"=compcode and "cio_booking_id"=ciobookid;

 IF sharepub_p is not null then
                        insert_sharepub_details(sharepub_p,ciobookid,'UPDATE',error1);
                  end if;

 delete from TBL_BOOKING_FMG_TRANS where CIOID=ciobookid;
  if fmginsert is not null then
    insert_fmgTrans_details(fmginsert,ciobookid,'UPDATE',error1);   
  end if;  
    if multiselect is not null then
                    insert_multiexec_details(userid,compcode,multiselect,ciobookid,'UPDATE',error1);
                  end if;                   
 if billpay = 'CA0' and rostatus='1' and (receiptno is null or receiptno = '') then
 declare
    cursor c1 is
        select * from tbl_booking_mast where "cio_booking_id"=ciobookid;
       
   v1 c1%rowtype;
   v_error      varchar2(2000);
    v_rcptno_r      varchar2(50);
   vrecpt       varchar2(20);
   branchcode   varchar2(20);
   vrepcode     varchar2(20);
   subagencyreg varchar2(20);
   prevcioid_v varchar2(50);
   billamt_v float;
   grossamt_v float;
  v_curdate date;
 begin
 open c1;
 fetch c1 into v1;
    Begin
        select "Branch_Code" into branchcode from branch_mst where "Comp_Code"=v1."Comp_code" and 

"Branch_Name"=v1."branch";
    Exception When no_data_found then
        branchcode:='';
    End;
   
    Begin
        select "SUB_Agency_Code" into subagencyreg from agency_mast where "Comp_Code"=v1."Comp_code" and 

"code_subcode"=v1."Agency_sub_code";
    Exception When no_data_found then
        subagencyreg:='';
    End;
   vrecpt:=v1."Receipt_no";
   prevcioid_v:=v1."prev_cioid";
   if prevcioid_v is null or v1."prev_receipt" is null then
    billamt_v:=v1."Bill_amount";
    grossamt_v:=v1."Gross_amount";
    v_curdate:=v1."date_time";
   else
    select "Bill_amount","Gross_amount" into  billamt_v,grossamt_v from tbl_booking_mast where 

"cio_booking_id"=prevcioid_v;
    billamt_v:=v1."Bill_amount" - billamt_v;
     grossamt_v:=v1."Gross_amount" - grossamt_v;
     v_curdate:=to_date(sysdate);
   end if;
   -- select substr(max("recptno"),1,12)||lpad(substr(max("recptno"),-6)+1,6,'0') into vrecpt from ad_rcpthdr where 

"unit"=branchcode and "doctype"='RCP' and
   -- "recptdt" between '1-mar-2011' and '31-mar-2011';
 
 --receiptsave_booking.receiptsave_booking_P(pcompcode,puserid , punit ,ptype , precpt , prdate , ppaymodres ,preceivedreg 

,pvouno  ,pamount  ,pagency , pothercd ,
  --pchno  ,pchedate , pbank  , pnarration ,prep   , pvdate , pag_main_code ,pag_sub_code , ourbank,  cioid , execname , 

retainer ,
   -- prevcioid , p_error)
   begin
 SELECT "Cust_Name" into clientname FROM CUST_MAST WHERE "Cust_Code" = v1."Client_code" and 

"Comp_Code"=v1."Comp_code";
exception
when NO_DATA_FOUND THEN
clientname:=v1."Client_code";
END;

remarks:='RONO#'||v1."RO_No" ||' RODATE# ' || to_char(v1."RO_Date",'dd-mon-yyyy') || ' BOOKINGID# ' || v1."cio_booking_id" 

|| ' CLIENT#' || clientname;

   receiptsave_booking.receiptsave_booking_p(v1."Comp_code",v1."Userid", 

v1."branch",v1.DOCTYPE,vrecpt,v_curdate,v1."Bill_pay",'','',billamt_v,v1."Agency_sub_code",grossamt_v,
    

'','','',remarks,vrepcode,v1."date_time",v1."Agency_code",subagencyreg,'',v1."cio_booking_id",v1."Executive_code",v1.RETAINE

R,v1."prev_cioid",v_rcptno_r,v_error);
   
  update tbl_booking_mast set "Receipt_no"=v_rcptno_r,"Receipt_date"=v_curdate where 

"cio_booking_id"=v1."cio_booking_id";
 close c1;
 commit;
 end;
 end if;
 
end updatebooking_p;
End updatebooking;
/

/******************************* END 9-nov-2011 Lata*****************************/

///////////////////////issue no-5475////////////////////
CREATE OR REPLACE PROCEDURE HT18JULY.Schedulereport1
(
fromdate IN VARCHAR2,
dateto IN VARCHAR2,
compcode IN VARCHAR2,
pub_name IN VARCHAR2,
pub_cent IN VARCHAR2,
dateformat IN VARCHAR2,
descid IN VARCHAR2:=NULL,
ascdesc IN VARCHAR2:=NULL,
adtyp IN VARCHAR2,
adcatg IN VARCHAR2,
edition_name in varchar2,
drpstatus in varchar2,
supplement_name in varchar2,
packagecode in varchar2,
editiondtl in varchar2,
puserid in varchar2:=null,
chk_access in varchar2:=null,
p_accounts OUT Cur_Type_New1.cursor_type,
p_accounts1 OUT Cur_Type_New1.cursor_type,
p_accounts2 OUT Cur_Type_New1.cursor_type,
p_accounts3 out Cur_Type_New1.cursor_type,
p_accounts4  out Cur_Type_New1.cursor_type
)

IS

query1 VARCHAR2(10000);
v_gau number:=17;
v_val number(4);
vs_gau number(4);


--if(drpstatus ='cancel') then
Cursor p1 Is
select TBL_BOOKING_INSERT."Edition" as "edition",count(*) as "tot"
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,COL_MAST, UOM_MAST
WHERE TBL_BOOKING_MAST."Comp_code"=compcode AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
TBL_BOOKING_insert."Col_Code" =COL_MAST."Col_Code" AND
UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
AND TBL_BOOKING_INSERT."Insert_Date" BETWEEN fromdate AND dateto
 and (TBL_BOOKING_INSERT."Insert_Status"!=drpstatus or drpstatus is null)
AND (TBL_BOOKING_INSERT."Publication_Code"=pub_name or pub_name is null)
AND (TBL_BOOKING_INSERT."Pub_Cent_Code"=pub_cent or pub_cent is null)
AND (TBL_BOOKING_MAST."Ad_type_code"=Adtyp or Adtyp is null)
AND (tbl_booking_insert."Ad_Cat"=adcatg or adcatg is null)
AND (TBL_BOOKING_INSERT."Edition_Code"=edition_name or edition_name is null)
AND (TBL_BOOKING_insert."Supp_Code" =supplement_name or supplement_name is null)
and (packagecode in (tbl_booking_mast."Package_code") or packagecode is null)
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1)
or  (chk_access=0) )
group by TBL_BOOKING_INSERT."Edition" order by TBL_BOOKING_INSERT."Edition";

g1 p1%rowtype;

Cursor C1 Is
SELECT distinct TBL_BOOKING_INSERT."Cio_Booking_Id" AS "CIOID",TBL_BOOKING_MAST."Package_code" as package_code
,TBL_BOOKING_mast."Gross_amount" as Crate
FROM TBL_BOOKING_MAST, TBL_BOOKING_INSERT--,multipack_rep
WHERE TBL_BOOKING_MAST."Comp_code"=compcode AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
AND TBL_BOOKING_INSERT."Insert_Date" BETWEEN fromdate AND dateto
AND (TBL_BOOKING_INSERT."Publication_Code"=pub_name or pub_name is null)
AND (TBL_BOOKING_INSERT."Pub_Cent_Code"=pub_cent or pub_cent is null)
AND (TBL_BOOKING_MAST."Ad_type_code"=Adtyp or Adtyp is null)
AND (tbl_booking_insert."Ad_Cat"=adcatg or adcatg is null)
AND (TBL_BOOKING_INSERT."Edition_Code"=edition_name or edition_name is null)
AND (TBL_BOOKING_insert."Supp_Code" =supplement_name or supplement_name is null)
and (packagecode in (tbl_booking_mast."Package_code") or packagecode is null)
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1)
or  (chk_access=0) );
v1 c1%rowtype;

Cursor C2 Is
SELECT distinct "Edition" from TBL_BOOKING_INSERT where "Cio_Booking_Id"=v1.cioid;
v_edition varchar2(100);
v_edipkg varchar2(500);

BEGIN
delete temp_edi;

delete from MULTIPAGE_BREAK where sess_id=userenv('sessionid');commit;


open p1;
loop
fetch p1 into g1;
exit when p1%notfound;
--multipage_brek(packag VARCHAR2,PCOMP_CD number,bre number)
vs_gau:=multipage_brek(g1."edition", g1."tot",v_gau);
     end loop;
close p1;
commit;

--------- fetch multiple  edition  ( ad by rinki)-----------
delete from multipack_rep where sess_id=userenv('sessionid');commit;
open c1;
loop
fetch c1 into v1;
exit when c1%notfound;

    
      v_val:=multipack_report(v1.CIOID,v1.package_code,v1.Crate,'1');
    open C2;
    Loop
    fetch C2 into v_edition;
    exit when C2%notfound;
    if v_edipkg is null then
        v_edipkg :=v_edition;
    else
        v_edipkg :=v_edipkg|| ',' ||v_edition;
    end if;
    end loop;
    close C2;

    v_edition:=null;v_edipkg:=null;
end loop;
close c1;
commit;
---------------------end -------------------------------
if(packagecode is null or editiondtl='1')then
if(drpstatus ='includecancel' or drpstatus ='includehold') then


query1:='SELECT TBL_BOOKING_MAST ."cio_booking_id" AS "CIOID",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code" and tbl_booking_mast."Comp_code"=cust_mast."Comp_Code" ),"Client_code")  AS "Client",
multipack_rep.PACK  AS "Package",
COL_MAST ."Col_Alias" AS "Hue",
TBL_BOOKING_MAST."Card_rate" AS "CardRate",
NVL("Agrred_rate",TBL_BOOKING_MAST."Card_rate") AS "AgreedRate",
tbl_booking_insert."Status_Material" as "InsertStatus",
TBL_BOOKING_MAST."Caption" as "Caption",
TBL_BOOKING_MAST."Key_no" as "Key_no",
TBL_BOOKING_INSERT."Edition" as "edition",
TBL_BOOKING_MAST."RO_No" as "RO_No",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_INSERT."Premium1" and ADVPOS_PREM_MAST."comp_code"=tbl_booking_insert."Comp_Code" ) as "PagePremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=tbl_booking_insert."Page_Post" and advpos_type_mast."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "PosPremium",
round(TBL_BOOKING_insert."Size_Book",2) AS "Area",
TBL_BOOKING_MAST."Bill_remarks" AS "Spl Instruction",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''MM-DD-YY'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''DD-MM-YY'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''YY-MM-DD'') END AS "Ins.date" ,
tbl_booking_insert."Width"  AS "Width",
tbl_booking_insert."Height" AS "Depth"
,(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=tbl_booking_insert."Ad_Cat" and ADV_CAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "Adcat",
 (select ADV_SUBCAT_MAST."Adv_Subcat_Name"   FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST."Adv_Subcat_Code"=tbl_booking_insert."Ad_Sub_Cat" and ADV_SUBCAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) AS "AdSubcat",
TBL_BOOKING_INSERT."Page_No" as "Pageno",
TBL_BOOKING_MAST."Paid_ins" as "Paidins",
TBL_BOOKING_MAST."Rate_code" as ratecd,
UOM_MAST."Uom_Name"  AS "Uom",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
,TBL_BOOKING_MAST."Booking_type" AS "booktype"
,tbl_booking_mast."audit" as "audit"
,tbl_booking_insert."File_Name" as "FILE_NAME"
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,multipack_rep,COL_MAST ,UOM_MAST
WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||'''AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
tbl_booking_mast."Comp_code"=tbl_booking_insert."Comp_Code" and
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
TBL_BOOKING_insert."Col_Code"=COL_MAST."Col_Code" AND
 UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
and  multipack_rep.CIOID=tbl_booking_mast."cio_booking_id"
and sess_id='||userenv('sessionid')||'
and "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
and (('''||drpstatus||''' =''includecancel'' and  lower("Insert_Status") !=''hold'') or ('''||drpstatus||''' =''includehold'' and lower("Insert_Status") !=''cancel''))
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') )';

else



query1:='SELECT TBL_BOOKING_MAST ."cio_booking_id" AS "CIOID",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code" and tbl_booking_mast."Comp_code"=cust_mast."Comp_Code" ),"Client_code")  AS "Client",
multipack_rep.PACK  AS "Package",
COL_MAST ."Col_Alias" AS "Hue",
TBL_BOOKING_MAST."Card_rate" AS "CardRate",
NVL("Agrred_rate",TBL_BOOKING_MAST."Card_rate") AS "AgreedRate",
tbl_booking_insert."Status_Material" as "InsertStatus",
TBL_BOOKING_MAST."Caption" as "Caption",
TBL_BOOKING_MAST."Key_no" as "Key_no",
TBL_BOOKING_INSERT."Edition" as "edition",
TBL_BOOKING_MAST."RO_No" as "RO_No",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_INSERT."Premium1" and ADVPOS_PREM_MAST."comp_code"=tbl_booking_insert."Comp_Code" ) as "PagePremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=tbl_booking_insert."Page_Post" and advpos_type_mast."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "PosPremium",
round(TBL_BOOKING_insert."Size_Book",2) AS "Area",
TBL_BOOKING_MAST."Bill_remarks" AS "Spl Instruction",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''MM-DD-YY'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''DD-MM-YY'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''YY-MM-DD'') END
 AS "Ins.date" ,
tbl_booking_insert."Width"  AS "Width",
tbl_booking_insert."Height" AS "Depth"
,(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=tbl_booking_insert."Ad_Cat" and ADV_CAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "Adcat",
 (select ADV_SUBCAT_MAST."Adv_Subcat_Name"   FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST."Adv_Subcat_Code"=tbl_booking_insert."Ad_Sub_Cat" and ADV_SUBCAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) AS "AdSubcat",
TBL_BOOKING_INSERT."Page_No" as "Pageno",
TBL_BOOKING_MAST."Paid_ins" as "Paidins",
TBL_BOOKING_MAST."Rate_code" as ratecd,
UOM_MAST."Uom_Name"  AS "Uom",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
,TBL_BOOKING_MAST."Booking_type" AS "booktype"
,tbl_booking_mast."audit" as "audit"
,tbl_booking_insert."File_Name" as "FILE_NAME"
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,multipack_rep,COL_MAST,UOM_MAST
WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||'''AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
tbl_booking_mast."Comp_code"=tbl_booking_insert."Comp_Code" and
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
TBL_BOOKING_insert."Col_Code"=COL_MAST."Col_Code"
and  multipack_rep.CIOID=tbl_booking_mast."cio_booking_id"
and sess_id='||userenv('sessionid')||'
and lower("Insert_Status") !=''cancel''
and lower("Insert_Status") !=''hold''
and  UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
and "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null) 
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') ) ';

end if;

else
if(drpstatus ='includecancel' or drpstatus ='includehold') then

query1:='SELECT distinct TBL_BOOKING_MAST ."cio_booking_id" AS "CIOID",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code" and tbl_booking_mast."Comp_code"=cust_mast."Comp_Code" ),"Client_code")  AS "Client",
multipack_rep.PACK  AS "Package",
COL_MAST ."Col_Alias" AS "Hue",
TBL_BOOKING_MAST."Card_rate" AS "CardRate",
NVL("Agrred_rate",TBL_BOOKING_MAST."Card_rate") AS "AgreedRate",
tbl_booking_insert."Status_Material" as "InsertStatus",
TBL_BOOKING_MAST."Caption" as "Caption",
TBL_BOOKING_MAST."Key_no" as "Key_no",
TBL_BOOKING_MAST."RO_No" as "RO_No",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_INSERT."Premium1" and ADVPOS_PREM_MAST."comp_code"=tbl_booking_insert."Comp_Code" ) as "PagePremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=tbl_booking_insert."Page_Post" and advpos_type_mast."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "PosPremium",
round(TBL_BOOKING_insert."Size_Book",2) AS "Area",
TBL_BOOKING_MAST."Bill_remarks" AS "Spl Instruction",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''MM-DD-YY'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''DD-MM-YY'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''YY-MM-DD'') END AS "Ins.date" ,
tbl_booking_insert."Width"  AS "Width",
tbl_booking_insert."Height" AS "Depth"
,(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=tbl_booking_insert."Ad_Cat" and ADV_CAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "Adcat",
 (select ADV_SUBCAT_MAST."Adv_Subcat_Name"   FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST."Adv_Subcat_Code"=tbl_booking_insert."Ad_Sub_Cat" and ADV_SUBCAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) AS "AdSubcat",
TBL_BOOKING_INSERT."Page_No" as "Pageno",
TBL_BOOKING_MAST."Paid_ins" as "Paidins",
TBL_BOOKING_MAST."Rate_code" as ratecd,
UOM_MAST."Uom_Name"  AS "Uom",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
,TBL_BOOKING_MAST."Booking_type" AS "booktype"
,tbl_booking_mast."audit" as "audit"
,tbl_booking_insert."File_Name" as "FILE_NAME"
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,multipack_rep,COL_MAST,UOM_MAST
WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||'''AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
tbl_booking_mast."Comp_code"=tbl_booking_insert."Comp_Code" and
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
TBL_BOOKING_insert."Col_Code"=COL_MAST."Col_Code" AND
 UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
and  multipack_rep.CIOID=tbl_booking_mast."cio_booking_id"
and sess_id='||userenv('sessionid')||'
and "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
and (('''||drpstatus||''' =''includecancel'' and  lower("Insert_Status") !=''hold'') or ('''||drpstatus||''' =''includehold'' and lower("Insert_Status") !=''cancel''))
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') )';

else

query1:='SELECT distinct TBL_BOOKING_MAST ."cio_booking_id" AS "CIOID",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code" and tbl_booking_mast."Comp_code"=cust_mast."Comp_Code" ),"Client_code")  AS "Client",
multipack_rep.PACK  AS "Package",
COL_MAST ."Col_Alias" AS "Hue",
TBL_BOOKING_MAST."Card_rate" AS "CardRate",
NVL("Agrred_rate",TBL_BOOKING_MAST."Card_rate") AS "AgreedRate",
tbl_booking_insert."Status_Material" as "InsertStatus",
TBL_BOOKING_MAST."Caption" as "Caption",
TBL_BOOKING_MAST."Key_no" as "Key_no",
TBL_BOOKING_MAST."RO_No" as "RO_No",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_INSERT."Premium1" and ADVPOS_PREM_MAST."comp_code"=tbl_booking_insert."Comp_Code" ) as "PagePremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=tbl_booking_insert."Page_Post" and advpos_type_mast."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "PosPremium",
round(TBL_BOOKING_insert."Size_Book",2) AS "Area",
TBL_BOOKING_MAST."Bill_remarks" AS "Spl Instruction",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''MM-DD-YY'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''DD-MM-YY'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''YY-MM-DD'') END
 AS "Ins.date" ,
tbl_booking_insert."Width"  AS "Width",
tbl_booking_insert."Height" AS "Depth"
,(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=tbl_booking_insert."Ad_Cat" and ADV_CAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "Adcat",
 (select ADV_SUBCAT_MAST."Adv_Subcat_Name"   FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST."Adv_Subcat_Code"=tbl_booking_insert."Ad_Sub_Cat" and ADV_SUBCAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) AS "AdSubcat",
TBL_BOOKING_INSERT."Page_No" as "Pageno",
TBL_BOOKING_MAST."Paid_ins" as "Paidins",
TBL_BOOKING_MAST."Rate_code" as ratecd,
UOM_MAST."Uom_Name"  AS "Uom",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
,TBL_BOOKING_MAST."Booking_type" AS "booktype"
,tbl_booking_mast."audit" as "audit"
,tbl_booking_insert."File_Name" as "FILE_NAME"
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,multipack_rep,COL_MAST,UOM_MAST
WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||'''AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
tbl_booking_mast."Comp_code"=tbl_booking_insert."Comp_Code" and
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
TBL_BOOKING_insert."Col_Code"=COL_MAST."Col_Code"
and  multipack_rep.CIOID=tbl_booking_mast."cio_booking_id"
and sess_id='||userenv('sessionid')||'
and lower("Insert_Status") !=''cancel''
and lower("Insert_Status") !=''hold''
and  UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
and "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') )';

end if;
end if;


IF(fromdate IS NOT NULL AND dateto IS NOT NULL )
THEN

query1:=query1||' AND TBL_BOOKING_INSERT."Insert_Date" BETWEEN '''||fromdate||''' AND '''||dateto||''' ';
END IF;


IF(pub_name IS NOT NULL )
THEN
query1:=query1||' AND TBL_BOOKING_INSERT."Publication_Code"='''||pub_name||'''';

END IF;


IF(pub_cent IS NOT NULL)
THEN
query1:=query1||'  AND TBL_BOOKING_INSERT."Pub_Cent_Code"='''||pub_cent||'''';

END IF;


IF(adtyp IS NOT NULL)
THEN
query1:=query1|| ' AND TBL_BOOKING_MAST."Ad_type_code"='''||Adtyp||''' ';

END IF;

IF(adcatg IS NOT NULL)
THEN
query1:=query1|| ' AND tbl_booking_insert."Ad_Cat" in ('''||adcatg||''' )';

END IF;

IF(edition_name IS NOT NULL )
THEN
query1:=query1||'  AND TBL_BOOKING_INSERT."Edition_Code"='''||edition_name||'''';

END IF;

IF(supplement_name IS NOT NULL )
THEN
query1:=query1||' AND (TBL_BOOKING_insert."Supp_Code" ='''||supplement_name||''' )';

END IF;

IF(packagecode IS NOT NULL )
THEN
query1:=query1||' AND ('''||packagecode||''' in (tbl_booking_mast."Package_code") )';

END IF;

if(packagecode is null)then

IF(descid IS NOT  NULL)
THEN
query1:=query1||'  order by "'||descid||'",TBL_BOOKING_INSERT."Edition"';
query1:=query1||''||ascdesc||'';
else
query1:=query1||' order by TBL_BOOKING_INSERT."Edition",TBL_BOOKING_MAST ."cio_booking_id"';
END IF;

else
IF(descid IS NOT  NULL)
THEN
query1:=query1||'  order by "'||descid||'"';
query1:=query1||''||ascdesc||'';
else
query1:=query1||' order by TBL_BOOKING_MAST ."cio_booking_id"';
END IF;
end if;
delete from searchtbl;
insert into searchtbl values(query1);
commit;
OPEN p_accounts FOR
query1;



OPEN p_accounts1 FOR
select "Edition_Alias"  as "Editions"  from edition_mast where ("Pub_Code"=pub_name or pub_name is null)  and "Edition_Type"='Main Edition';

OPEN p_accounts2 FOR
select sysdate from dual;
/*SELECT 
CASE dateformat
WHEN 'mm/dd/yyyy' THEN TO_CHAR("Insert_Date",'MM-DD-YY')
WHEN 'dd/mm/yyyy' THEN TO_CHAR("Insert_Date",'DD-MM-YY')
WHEN 'yyyy/mm/dd' THEN TO_CHAR("Insert_Date",'YY-MM-DD') END as "Insdate"
,TBL_BOOKING_INSERT."Edition" from TBL_BOOKING_INSERT
where  TBL_BOOKING_INSERT."Edition"
in (select "Edition_Alias"  as "Editions"
from edition_mast where ("Pub_Code"=pub_name or pub_name is null));*/


OPEN p_accounts3 FOR
select PACK, TOT from  MULTIPAGE_BREAK where  sess_id=userenv('sessionid') order by PACK,TOT desc;

OPEN  p_accounts4 FOR
SELECT SYSDATE,initcap("Comp_Name") from comp_mst where "Comp_Code"=compcode;

delete from multipack_rep where sess_id=userenv('sessionid')  ;
delete from multipack_rat where sess_id=userenv('sessionid') ;
DELETE FROM multipack_ratnew where sess_id=userenv('sessionid')  ; 
DELETE FROM MULTIPAGE_BREAK where sess_id=userenv('sessionid')  ;commit;
END ;
/

//////////////end of issue/////////////////////////////

/*********************** Kuldeep  09/11/2011  *******************/
CREATE OR REPLACE PACKAGE  insertratemast
IS
   PROCEDURE insertratemast_p (
      compcode        IN   VARCHAR2,
      userid          IN   VARCHAR2,
      ratecodes        IN   VARCHAR2,
      adtype1          IN   VARCHAR2,
      rategroupcode   IN   VARCHAR2,
      adcategory      IN   VARCHAR2,
      currency        IN   VARCHAR2,
      adsubcategory   IN   VARCHAR2,
      package1        IN   VARCHAR2,
      packagedesc     IN   VARCHAR2,
      uom             IN   VARCHAR2,
      sizefrom        IN   NUMBER,
      sizeto          IN   NUMBER,
      consumption     IN   NUMBER,
      color           IN   VARCHAR2,
      colorchrty      IN   VARCHAR2,
      weekdrate       IN   NUMBER,
      weeminrate      IN   NUMBER,
      extweerate      IN   NUMBER,
      focusdarate     IN   NUMBER,
      focminrate      IN   NUMBER,
      focexrate       IN   NUMBER,
      validfromdate   IN   DATE,
      validtill       IN   DATE,
      remarks         IN   VARCHAR2,
      premiumval      IN   VARCHAR2,
      premium         IN   VARCHAR2,
      rateuniqueid    IN   VARCHAR2,
      weekendrate     IN   NUMBER,
      weekendmin      IN   NUMBER,
      weekendextra    IN   NUMBER,
      minadarea       IN   NUMBER,
      editionfrom     IN   NUMBER,
      editionto       IN   NUMBER,
      flramount       IN   NUMBER,
      flrdiscount     IN   NUMBER,
      scheme1          IN   VARCHAR2,
      adscat4         IN   VARCHAR2,
      adscat5         IN   VARCHAR2,
      adscat6         IN   VARCHAR2,
      frominsert      IN   NUMBER,
      toinsert        IN   NUMBER,
      agtype          IN   VARCHAR2,
      clientcat       IN   VARCHAR2,
      maxadarea       IN   NUMBER,
	  type1           IN VARCHAR2,
      agencycode      IN VARCHAR2,
      pubcenter       IN VARCHAR2,

      rate_sun        IN NUMBER,
      rate_mon        IN NUMBER,
      rate_tue        IN NUMBER,
      rate_wed        IN NUMBER,
      rate_thu        IN NUMBER,
      rate_fri        IN NUMBER,
      rate_sat        IN NUMBER,

      rate_sun_extra  IN NUMBER,
      rate_mon_extra  IN NUMBER,
      rate_tue_extra  IN NUMBER,
      rate_wed_extra  IN NUMBER,
      rate_thu_extra  IN NUMBER,
      rate_fri_extra  IN NUMBER,
      rate_sat_extra  IN NUMBER,
	  width_max       IN NUMBER,
      priority_m        in number,
      vat             IN   VARCHAR2,
      Adon1            IN   VARCHAR2,
      refrence        IN   VARCHAR2
   );
END insertratemast;
/

CREATE OR REPLACE PACKAGE BODY insertratemast
IS
   PROCEDURE insertratemast_p (
      compcode        IN   VARCHAR2,
      userid          IN   VARCHAR2,
      ratecodes        IN   VARCHAR2,
      adtype1          IN   VARCHAR2,
      rategroupcode   IN   VARCHAR2,
      adcategory      IN   VARCHAR2,
      currency        IN   VARCHAR2,
      adsubcategory   IN   VARCHAR2,
      package1        IN   VARCHAR2,
      packagedesc     IN   VARCHAR2,
      uom             IN   VARCHAR2,
      sizefrom        IN   NUMBER,
      sizeto          IN   NUMBER,
      consumption     IN   NUMBER,
      color           IN   VARCHAR2,
      colorchrty      IN   VARCHAR2,
      weekdrate       IN   NUMBER,
      weeminrate      IN   NUMBER,
      extweerate      IN   NUMBER,
      focusdarate     IN   NUMBER,
      focminrate      IN   NUMBER,
      focexrate       IN   NUMBER,
      validfromdate   IN   DATE,
      validtill       IN   DATE,
      remarks         IN   VARCHAR2,
      premiumval      IN   VARCHAR2,
      premium         IN   VARCHAR2,
      rateuniqueid    IN   VARCHAR2,
      weekendrate     IN   NUMBER,
      weekendmin      IN   NUMBER,
      weekendextra    IN   NUMBER,
      minadarea       IN   NUMBER,
      editionfrom     IN   NUMBER,
      editionto       IN   NUMBER,
      flramount       IN   NUMBER,
      flrdiscount     IN   NUMBER,
      scheme1          IN   VARCHAR2,
      adscat4         IN   VARCHAR2,
      adscat5         IN   VARCHAR2,
      adscat6         IN   VARCHAR2,
      frominsert      IN   NUMBER,
      toinsert        IN   NUMBER,
      agtype          IN   VARCHAR2,
      clientcat       IN   VARCHAR2,
      maxadarea       IN   NUMBER,
	  type1           IN VARCHAR2,
      agencycode      IN VARCHAR2,
      pubcenter       IN VARCHAR2,

      rate_sun        IN NUMBER,
      rate_mon        IN NUMBER,
      rate_tue        IN NUMBER,
      rate_wed        IN NUMBER,
      rate_thu        IN NUMBER,
      rate_fri        IN NUMBER,
      rate_sat        IN NUMBER,

      rate_sun_extra  IN NUMBER,
      rate_mon_extra  IN NUMBER,
      rate_tue_extra  IN NUMBER,
      rate_wed_extra  IN NUMBER,
      rate_thu_extra  IN NUMBER,
      rate_fri_extra  IN NUMBER,
      rate_sat_extra  IN NUMBER,
	  width_max  IN NUMBER,
      priority_m    in number,
      vat          IN   VARCHAR2,
       Adon1            IN   VARCHAR2,
      refrence        IN   VARCHAR2
   )
   AS
   BEGIN
        if(type1='company')then
          INSERT INTO rate_mast
                      ("Comp_code", "Rate_Mast_Code", "Adv_Type_Code",
                       "Adv_Cat_Code", "Adv_subcat_code", "Rate_Gr_Code",
                       "Currency", "combin_desc", "Combin_Code", "Uom",
                       "Valid_From", "Valid_To", "Size_To", "Size_From",
                       "consumption_Per", "Color", "Col_chr_typ", "Remarks",
                       "Week_Day_Rate", "Week_min_rate", "Week_Extra_Rate",
                       "Focus_Day_Rate", "Focus_min_rate", "Focus_extra_rate",
                       "userid", "Premium", "Premium_Charges", "rateuniqueid",
                       "weekend_rate", "weekend_min_rate", "weekend_extra",
                       "min_ad_area", "Edition_from", "Edition_to",
                       "floor_amount", "floor_discount", "Scheme_Name",
                       "Ad_Subcat4", "Ad_Subcat5", "Ad_subcat6",
                       "From_insertion", "To_insertion", "Agency_type",
                       "Client_cat" ,"Max_Area" ,"Creation_DateTime","pub_center",
                       sun_rate,mon_rate,tue_rate,wed_rate,thu_rate,fri_rate,sat_rate,
                       sun_rate_extra,mon_rate_extra,tue_rate_extra,wed_rate_extra,thu_rate_extra,fri_rate_extra,sat_rate_extra,maxwidth ,PRIORITY,VAT_DETAIL,ADON, REF_ID              ---, "Max_ad_area"
                      )
               VALUES (compcode, ratecodes, adtype1,
                       adcategory, adsubcategory, rategroupcode,
                       currency, packagedesc, package1, uom,
                       validfromdate, validtill, sizeto, sizefrom,
                       consumption, color, colorchrty, remarks,
                       weekdrate, weeminrate, extweerate,
                       focusdarate, focminrate, focexrate,
                       userid, premium, premiumval, rateuniqueid,
                       weekendrate, weekendmin, weekendextra,
                       minadarea, editionfrom, editionto,
                       flramount, flrdiscount, scheme1,
                       adscat4, adscat5, adscat6,
                       frominsert, toinsert, agtype,
                       clientcat  ,maxadarea ,sysdate,pubcenter,
                       rate_sun,rate_mon,rate_tue,rate_wed,rate_thu,rate_fri,rate_sat,
                       rate_sun_extra,rate_mon_extra,rate_tue_extra,rate_wed_extra,rate_thu_extra,rate_fri_extra,rate_sat_extra,width_max ,priority_m,vat,Adon1,refrence                                --, maxadarea
                      );
        else
                INSERT INTO  agency_rate_mast
                      ("Comp_code", "Rate_Mast_Code", "Adv_Type_Code",
                       "Adv_Cat_Code", "Adv_subcat_code", "Rate_Gr_Code",
                       "Currency", "combin_desc", "Combin_Code", "Uom",
                       "Valid_From", "Valid_To", "Size_To", "Size_From",
                       "consumption_Per", "Color", "Col_chr_typ", "Remarks",
                       "Week_Day_Rate", "Week_min_rate", "Week_Extra_Rate",
                       "Focus_Day_Rate", "Focus_min_rate", "Focus_extra_rate",
                       "userid", "Premium", "Premium_Charges", "rateuniqueid",
                       "weekend_rate", "weekend_min_rate", "weekend_extra",
                       "min_ad_area", "Edition_from", "Edition_to",
                       "floor_amount", "floor_discount", "Scheme_Name",
                       "Ad_Subcat4", "Ad_Subcat5", "Ad_subcat6",
                       "From_insertion", "To_insertion", "Agency_type",
                       "Client_cat" ,"Max_Area" ,"Agency_code","Creation_DateTime"                           ---, "Max_ad_area"
                      )
               VALUES (compcode, ratecodes, adtype1,
                       adcategory, adsubcategory, rategroupcode,
                       currency, packagedesc, package1, uom,
                       validfromdate, validtill, sizeto, sizefrom,
                       consumption, color, colorchrty, remarks,
                       weekdrate, weeminrate, extweerate,
                       focusdarate, focminrate, focexrate,
                       userid, premium, premiumval, rateuniqueid,
                       weekendrate, weekendmin, weekendextra,
                       minadarea, editionfrom, editionto,
                       flramount, flrdiscount, scheme1,
                       adscat4, adscat5, adscat6,
                       frominsert, toinsert, agtype,
                       clientcat  ,maxadarea  ,agencycode,sysdate                                 --, maxadarea
                      );

        end if;

      COMMIT;
   END insertratemast_p;
END insertratemast;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

CREATE OR REPLACE PROCEDURE insertratemast_tv
(
 compcode        IN   VARCHAR2,
      userid          IN   VARCHAR2,
      ratecodes        IN   VARCHAR2,
      adtype1          IN   VARCHAR2,
      rategroupcode   IN   VARCHAR2,
      adcategory      IN   VARCHAR2,
      currency        IN   VARCHAR2,
      adsubcategory   IN   VARCHAR2,
      package1        IN   VARCHAR2,
      packagedesc     IN   VARCHAR2,
      uom             IN   VARCHAR2,
      sizefrom        IN   NUMBER,
      sizeto          IN   NUMBER,
      consumption     IN   NUMBER,
      color           IN   VARCHAR2,
      colorchrty      IN   VARCHAR2,
      weekdrate       IN   NUMBER,
      weeminrate      IN   NUMBER,
      extweerate      IN   NUMBER,
      focusdarate     IN   NUMBER,
      focminrate      IN   NUMBER,
      focexrate       IN   NUMBER,
      validfromdate   IN   DATE,
      validtill       IN   DATE,
      remarks         IN   VARCHAR2,
      premiumval      IN   VARCHAR2,
      premium         IN   VARCHAR2,
      rateuniqueid    IN   VARCHAR2,
      weekendrate     IN   NUMBER,
      weekendmin      IN   NUMBER,
      weekendextra    IN   NUMBER,
      minadarea       IN   NUMBER,
      editionfrom     IN   NUMBER,
      editionto       IN   NUMBER,
      flramount       IN   NUMBER,
      flrdiscount     IN   NUMBER,
      scheme1          IN   VARCHAR2,
      adscat4         IN   VARCHAR2,
      adscat5         IN   VARCHAR2,
      adscat6         IN   VARCHAR2,
      frominsert      IN   NUMBER,
      toinsert        IN   NUMBER,
      agtype          IN   VARCHAR2,
      clientcat       IN   VARCHAR2,
      maxadarea       IN   NUMBER,
      type1           IN VARCHAR2,
      agencycode      IN VARCHAR2,
      pubcenter       IN VARCHAR2,

      rate_sun        IN NUMBER,
      rate_mon        IN NUMBER,
      rate_tue        IN NUMBER,
      rate_wed        IN NUMBER,
      rate_thu        IN NUMBER,
      rate_fri        IN NUMBER,
      rate_sat        IN NUMBER,

      rate_sun_extra  IN NUMBER,
      rate_mon_extra  IN NUMBER,
      rate_tue_extra  IN NUMBER,
      rate_wed_extra  IN NUMBER,
      rate_thu_extra  IN NUMBER,
      rate_fri_extra  IN NUMBER,
      rate_sat_extra  IN NUMBER,
      width_max  IN NUMBER,
      priority_m    in number,
      vat          IN   VARCHAR2,
      BTB_CODE1          IN   VARCHAR2,
       Adon1            IN   VARCHAR2,
      refrence        IN   VARCHAR2
)
is
p_compcode  varchar2(50);
p_unit      varchar2(50);



BEGIN
 
 select COMP_CODE,UNIT  into p_compcode, p_unit from tv_ad_channel  where CHANNEL=pubcenter;
 
          INSERT INTO tv_rate_mast
                      ("COMP_CODE", "RATE_MAST_CODE", "ADV_TYPE_CODE",
                       "ADV_CAT_CODE", "ADV_SUBCAT_CODE", "RATE_GR_CODE",
                       "CURRENCY", "COMBIN_DESC", "COMBIN_CODE", "UOM",
                       "VALID_FROM", "VALID_TO", "SIZE_TO", "SIZE_FROM",
                       "CONSUMPTION_PER", "COLOR",BTB_CODE, 
                       "REMARKS",
                       "WEEK_DAY_RATE", "WEEK_MIN_RATE", "WEEK_EXTRA_RATE",
                       --"FOCUS_DAY_RATE", "FOCUS_MIN_RATE", "FOCUS_EXTRA_RATE",
                       "USERID", "PREMIUM", "PREMIUM_CHARGES", "RATEUNIQUEID",
                       --"weekend_rate", "weekend_min_rate", "weekend_extra",
                       "MIN_AD_AREA", "EDITION_FROM", "EDITION_TO",
                       "FLOOR_AMOUNT", "FLOOR_DISCOUNT", "SCHEME_NAME",
                     --  "Ad_Subcat4", "Ad_Subcat5", "Ad_subcat6",
                       "FROM_INSERTION", "TO_INSERTION", "AGENCY_TYPE",
                       "CLIENT_CAT" ,"MAX_AREA" ,"CREATION_DATETIME","CHANNEL",UNIT,
                       sun_rate,mon_rate,tue_rate,wed_rate,thu_rate,fri_rate,sat_rate,
                       sun_rate_extra,mon_rate_extra,tue_rate_extra,wed_rate_extra,thu_rate_extra,fri_rate_extra,sat_rate_extra,maxwidth ,PRIORITY,ADON, REF_ID--,VAT_DETAIL              ---, "Max_ad_area"
                      )
               VALUES (p_compcode, ratecodes, adtype1,
                       adcategory, adsubcategory, rategroupcode,
                       currency, packagedesc, package1, uom,
                       validfromdate, validtill, sizeto, sizefrom,
                       consumption, color,BTB_CODE1,
                        remarks,
                       weekdrate, weeminrate, extweerate,
                       --focusdarate, focminrate, focexrate,
                       userid, premium, premiumval, rateuniqueid,
                      -- weekendrate, weekendmin, weekendextra,
                       minadarea, editionfrom, editionto,
                       flramount, flrdiscount, scheme1,
                      -- adscat4, adscat5, adscat6,
                       frominsert, toinsert, agtype,
                       clientcat  ,maxadarea ,sysdate,pubcenter,p_unit,
                       rate_sun,rate_mon,rate_tue,rate_wed,rate_thu,rate_fri,rate_sat,
                       rate_sun_extra,rate_mon_extra,rate_tue_extra,rate_wed_extra,rate_thu_extra,rate_fri_extra,rate_sat_extra,width_max ,priority_m,Adon1,refrence--,vat                                 --, maxadarea
                      );
    

      COMMIT;
END;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE tv_modifyratecode
(
 compcode        IN   VARCHAR2,
      userid          IN   VARCHAR2,
      ratecodes        IN   VARCHAR2,
      adtype1          IN   VARCHAR2,
      rategroupcode   IN   VARCHAR2,
      adcategory      IN   VARCHAR2,
      currency        IN   VARCHAR2,
      adsubcategory   IN   VARCHAR2,
      package1        IN   VARCHAR2,
      packagedesc     IN   VARCHAR2,
      uom             IN   VARCHAR2,
      sizefrom        IN   NUMBER,
      sizeto          IN   NUMBER,
      consumption     IN   NUMBER,
      color           IN   VARCHAR2,
      colorchrty      IN   VARCHAR2,
      weekdrate       IN   NUMBER,
      weeminrate      IN   NUMBER,
      extweerate      IN   NUMBER,
      focusdarate     IN   NUMBER,
      focminrate      IN   NUMBER,
      focexrate       IN   NUMBER,
      validfromdate   IN   DATE,
      validtill       IN   DATE,
      remarks         IN   VARCHAR2,
      premiumval      IN   VARCHAR2,
      premium         IN   VARCHAR2,
      rateuniqueid    IN   VARCHAR2,
      weekendrate     IN   NUMBER,
      weekendmin      IN   NUMBER,
      weekendextra    IN   NUMBER,
      editionto       IN   NUMBER,
      editionfrom     IN   NUMBER,
      flramount       IN   NUMBER,
      flrdiscount     IN   NUMBER,
      scheme1          IN   VARCHAR2,
      minadarea       IN   NUMBER,
      adscat4         IN   VARCHAR2,
      adscat5         IN   VARCHAR2,
      adscat6         IN   VARCHAR2,
      frominsert      IN   NUMBER,
      toinsert        IN   NUMBER,
      agtype          IN   VARCHAR2,
      clientcat       IN   VARCHAR2,
      max_area      IN   NUMBER,
      type1 in varchar2,
      agencycode in varchar2,
      rate_sun in NUMBER,
      rate_mon in NUMBER,
      rate_tue in NUMBER,
      rate_wed in NUMBER,
      rate_thu in NUMBER,
      rate_fri in NUMBER,
      rate_sat in NUMBER,

      rate_sun_extra in NUMBER,
      rate_mon_extra in NUMBER,
      rate_tue_extra in NUMBER,
      rate_wed_extra in NUMBER,
      rate_thu_extra in NUMBER,
      rate_fri_extra in NUMBER,
      rate_sat_extra in NUMBER,
      width_max  IN NUMBER,
      priority_m    in number,
    vat          IN   VARCHAR2,
    BTB_CODE1          IN   VARCHAR2,
    Adon1            IN   VARCHAR2,
    refrence        IN   VARCHAR2
    )
IS
BEGIN
    UPDATE tv_rate_mast
         SET "ADV_TYPE_CODE" = adtype1,
             "ADV_CAT_CODE" = adcategory,
             "ADV_SUBCAT_CODE" = adsubcategory,
             "RATE_GR_CODE" = rategroupcode,
             "CURRENCY" = currency,
             "COMBIN_DESC" = packagedesc,
             "COMBIN_CODE" = package1,
             "UOM" = uom,
             "VALID_FROM" = validfromdate,
             "VALID_TO" = validtill,
             "SIZE_TO" = sizeto,
             "SIZE_FROM" = sizefrom,
             "CONSUMPTION_PER" = consumption,
             "COLOR" = color,
               BTB_CODE=  BTB_CODE1,
             "REMARKS" = remarks,
             "WEEK_DAY_RATE" = weekdrate,
             "WEEK_MIN_RATE" = weeminrate,
             "WEEK_EXTRA_RATE" = extweerate,
             --"Focus_Day_Rate" = focusdarate,
            -- "Focus_min_rate" = focminrate,
           --  "Focus_extra_rate" = focexrate,
             "PREMIUM" = premium,
             "PREMIUM_CHARGES" = premiumval,
            -- "weekend_rate" = weekendrate,
            -- "weekend_min_rate" = weekendmin,
            -- "WEEKEND_EXTRA" = weekendextra,
             "EDITION_FROM" = editionfrom,
             "EDITION_TO" = editionto,
             "FLOOR_AMOUNT" = flramount,
             "FLOOR_DISCOUNT" = flrdiscount,
             "SCHEME_NAME" = scheme1,
             "MIN_AD_AREA" = minadarea,
            -- "Ad_Subcat4" = adscat4,
            -- "Ad_Subcat5" = adscat5,
            -- "Ad_subcat6" = adscat6,
             "FROM_INSERTION" = frominsert,
             "TO_INSERTION" = toinsert,
             "AGENCY_TYPE" = agtype,
             "CLIENT_CAT" = clientcat,
			 "MAX_AREA"=max_area,
             sun_rate=rate_sun,
             mon_rate=rate_mon,
             tue_rate=rate_tue,
             wed_rate=rate_wed,
             thu_rate=rate_thu,
             fri_rate=rate_fri,
             sat_rate=rate_sat,

             sun_rate_extra=rate_sun_extra,
             mon_rate_extra=rate_mon_extra,
             tue_rate_extra=rate_tue_extra,
             wed_rate_extra=rate_wed_extra,
             thu_rate_extra=rate_thu_extra,
             fri_rate_extra=rate_fri_extra,
             sat_rate_extra=rate_sat_extra,
			 maxwidth=width_max,
             priority=priority_m
             --ADON=Adon1, REF_ID=refrence
             --VAT_DETAIL=vat
       --"max_ad_area" = maxadarea
      WHERE  "RATEUNIQUEID" = rateuniqueid AND "COMP_CODE" = compcode;
	

	

      COMMIT;
END;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE modifyratecode
IS
   PROCEDURE modifyratecode_p (
      compcode        IN   VARCHAR2,
      userid          IN   VARCHAR2,
      ratecodes        IN   VARCHAR2,
      adtype1          IN   VARCHAR2,
      rategroupcode   IN   VARCHAR2,
      adcategory      IN   VARCHAR2,
      currency        IN   VARCHAR2,
      adsubcategory   IN   VARCHAR2,
      package1        IN   VARCHAR2,
      packagedesc     IN   VARCHAR2,
      uom             IN   VARCHAR2,
      sizefrom        IN   NUMBER,
      sizeto          IN   NUMBER,
      consumption     IN   NUMBER,
      color           IN   VARCHAR2,
      colorchrty      IN   VARCHAR2,
      weekdrate       IN   NUMBER,
      weeminrate      IN   NUMBER,
      extweerate      IN   NUMBER,
      focusdarate     IN   NUMBER,
      focminrate      IN   NUMBER,
      focexrate       IN   NUMBER,
      validfromdate   IN   DATE,
      validtill       IN   DATE,
      remarks         IN   VARCHAR2,
      premiumval      IN   VARCHAR2,
      premium         IN   VARCHAR2,
      rateuniqueid    IN   VARCHAR2,
      weekendrate     IN   NUMBER,
      weekendmin      IN   NUMBER,
      weekendextra    IN   NUMBER,
      editionto       IN   NUMBER,
      editionfrom     IN   NUMBER,
      flramount       IN   NUMBER,
      flrdiscount     IN   NUMBER,
      scheme1          IN   VARCHAR2,
      minadarea       IN   NUMBER,
      adscat4         IN   VARCHAR2,
      adscat5         IN   VARCHAR2,
      adscat6         IN   VARCHAR2,
      frominsert      IN   NUMBER,
      toinsert        IN   NUMBER,
      agtype          IN   VARCHAR2,
      clientcat       IN   VARCHAR2,
      max_area      IN   NUMBER,
      type1 in varchar2,
      agencycode in varchar2,
      rate_sun in NUMBER,
      rate_mon in NUMBER,
      rate_tue in NUMBER,
      rate_wed in NUMBER,
      rate_thu in NUMBER,
      rate_fri in NUMBER,
      rate_sat in NUMBER,

      rate_sun_extra in NUMBER,
      rate_mon_extra in NUMBER,
      rate_tue_extra in NUMBER,
      rate_wed_extra in NUMBER,
      rate_thu_extra in NUMBER,
      rate_fri_extra in NUMBER,
      rate_sat_extra in NUMBER,
	  width_max  IN NUMBER,
      priority_m    in number,
      vat          IN   VARCHAR2,
 Adon1            IN   VARCHAR2,
      refrence        IN   VARCHAR2
   );
END modifyratecode;
/
CREATE OR REPLACE PACKAGE BODY modifyratecode
IS
   PROCEDURE modifyratecode_p (
      compcode        IN   VARCHAR2,
      userid          IN   VARCHAR2,
      ratecodes        IN   VARCHAR2,
      adtype1          IN   VARCHAR2,
      rategroupcode   IN   VARCHAR2,
      adcategory      IN   VARCHAR2,
      currency        IN   VARCHAR2,
      adsubcategory   IN   VARCHAR2,
      package1        IN   VARCHAR2,
      packagedesc     IN   VARCHAR2,
      uom             IN   VARCHAR2,
      sizefrom        IN   NUMBER,
      sizeto          IN   NUMBER,
      consumption     IN   NUMBER,
      color           IN   VARCHAR2,
      colorchrty      IN   VARCHAR2,
      weekdrate       IN   NUMBER,
      weeminrate      IN   NUMBER,
      extweerate      IN   NUMBER,
      focusdarate     IN   NUMBER,
      focminrate      IN   NUMBER,
      focexrate       IN   NUMBER,
      validfromdate   IN   DATE,
      validtill       IN   DATE,
      remarks         IN   VARCHAR2,
      premiumval      IN   VARCHAR2,
      premium         IN   VARCHAR2,
      rateuniqueid    IN   VARCHAR2,
      weekendrate     IN   NUMBER,
      weekendmin      IN   NUMBER,
      weekendextra    IN   NUMBER,
      editionto       IN   NUMBER,
      editionfrom     IN   NUMBER,
      flramount       IN   NUMBER,
      flrdiscount     IN   NUMBER,
      scheme1          IN   VARCHAR2,
      minadarea       IN   NUMBER,
      adscat4         IN   VARCHAR2,
      adscat5         IN   VARCHAR2,
      adscat6         IN   VARCHAR2,
      frominsert      IN   NUMBER,
      toinsert        IN   NUMBER,
      agtype          IN   VARCHAR2,
      clientcat       IN   VARCHAR2,
      max_area      IN   NUMBER,
      type1 in varchar2,
      agencycode in varchar2,
      rate_sun in NUMBER,
      rate_mon in NUMBER,
      rate_tue in NUMBER,
      rate_wed in NUMBER,
      rate_thu in NUMBER,
      rate_fri in NUMBER,
      rate_sat in NUMBER,

      rate_sun_extra in NUMBER,
      rate_mon_extra in NUMBER,
      rate_tue_extra in NUMBER,
      rate_wed_extra in NUMBER,
      rate_thu_extra in NUMBER,
      rate_fri_extra in NUMBER,
      rate_sat_extra in NUMBER,
	  width_max  IN NUMBER,
      priority_m    in number,
      vat          IN   VARCHAR2,
       Adon1            IN   VARCHAR2,
      refrence        IN   VARCHAR2
   )
   AS
   BEGIN 
  
      UPDATE rate_mast
         SET "Adv_Type_Code" = adtype1,
             "Adv_Cat_Code" = adcategory,
             "Adv_subcat_code" = adsubcategory,
             "Rate_Gr_Code" = rategroupcode,
             "Currency" = currency,
             "combin_desc" = packagedesc,
             "Combin_Code" = package1,
             "Uom" = uom,
             "Valid_From" = validfromdate,
             "Valid_To" = validtill,
             "Size_To" = sizeto,
             "Size_From" = sizefrom,
             "consumption_Per" = consumption,
             "Color" = color,
             "Col_chr_typ" = colorchrty,
             "Remarks" = remarks,
             "Week_Day_Rate" = weekdrate,
             "Week_min_rate" = weeminrate,
             "Week_Extra_Rate" = extweerate,
             "Focus_Day_Rate" = focusdarate,
             "Focus_min_rate" = focminrate,
             "Focus_extra_rate" = focexrate,
             "Premium" = premium,
             "Premium_Charges" = premiumval,
             "weekend_rate" = weekendrate,
             "weekend_min_rate" = weekendmin,
             "weekend_extra" = weekendextra,
             "Edition_from" = editionfrom,
             "Edition_to" = editionto,
             "floor_amount" = flramount,
             "floor_discount" = flrdiscount,
             "Scheme_Name" = scheme1,
             "min_ad_area" = minadarea,
             "Ad_Subcat4" = adscat4,
             "Ad_Subcat5" = adscat5,
             "Ad_subcat6" = adscat6,
             "From_insertion" = frominsert,
             "To_insertion" = toinsert,
             "Agency_type" = agtype,
             "Client_cat" = clientcat,
			 "Max_Area"=max_area,
             sun_rate=rate_sun,
             mon_rate=rate_mon,
             tue_rate=rate_tue,
             wed_rate=rate_wed,
             thu_rate=rate_thu,
             fri_rate=rate_fri,
             sat_rate=rate_sat,

             sun_rate_extra=rate_sun_extra,
             mon_rate_extra=rate_mon_extra,
             tue_rate_extra=rate_tue_extra,
             wed_rate_extra=rate_wed_extra,
             thu_rate_extra=rate_thu_extra,
             fri_rate_extra=rate_fri_extra,
             sat_rate_extra=rate_sat_extra,
			 maxwidth=width_max,
             priority=priority_m,
            VAT_DETAIL=vat
             --ADON=Adon1, REF_ID=refrence
       --"max_ad_area" = maxadarea
      WHERE  "rateuniqueid" = rateuniqueid AND "Comp_code" = compcode;
	

	

      COMMIT;
   END modifyratecode_p;
END modifyratecode;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE Executeratecode
IS
  TYPE T_Accounts_Cursor IS REF CURSOR;
  PROCEDURE executeratecode_p(
	compcode IN VARCHAR2,
	ratecodes IN VARCHAR2,
	adtype1 IN VARCHAR2,
	currency IN VARCHAR2,
	rategroup IN VARCHAR2,
	colorcode IN VARCHAR2,
	uomcode IN VARCHAR2,
	packagecode IN VARCHAR2,
	pubcenter IN VARCHAR2,
    adcate in varchar2, 
	P_Accounts OUT T_Accounts_cursor);

END  Executeratecode;
/
CREATE OR REPLACE PACKAGE BODY Executeratecode
IS
  PROCEDURE executeratecode_p(
	compcode IN VARCHAR2,
	ratecodes IN VARCHAR2,
	adtype1 IN VARCHAR2,
	currency IN VARCHAR2,
	rategroup IN VARCHAR2,
	colorcode IN VARCHAR2,
	uomcode IN VARCHAR2,
	packagecode IN VARCHAR2,
	pubcenter IN VARCHAR2,
     adcate in varchar2,
	P_Accounts OUT T_Accounts_cursor)
 AS
 BEGIN
 	  --IF(type1='company')THEN
        OPEN P_Accounts FOR
	    --SELECT "Comp_code","Rate_Mast_Code","Adv_Type_Code","Adv_Cat_Code","Adv_subcat_code","Rate_Gr_Code","Currency","combin_desc","Combin_Code","Uom",TO_CHAR("Valid_From",'dd/mm/yyyy')AS "Valid_From" ,TO_CHAR("Valid_To",'dd/mm/yyyy') AS "Valid_To" ,"Size_To","Size_From","consumption_Per","Color","Col_chr_typ","Remarks","Week_Day_Rate","Week_min_rate","Week_Extra_Rate","Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid","Premium","Premium_Charges","weekend_rate","weekend_min_rate","weekend_extra","chksolo","min_ad_area","Edition_from","Edition_to","floor_amount","floor_discount",(SELECT "Scheme_Code" FROM SCHEME_MASTER WHERE "scheme_id"=RATE_MAST."Scheme_Name") AS "Scheme_Name","Ad_Subcat4","Ad_Subcat5","Ad_subcat6","From_insertion","To_insertion","Agency_type","Client_cat","Max_Area","rateuniqueid","pub_center",sun_rate,mon_rate,tue_rate,wed_rate,thu_rate,fri_rate,sat_rate,sun_rate_extra,mon_rate_extra,tue_rate_extra,wed_rate_extra,thu_rate_extra,fri_rate_extra,sat_rate_extra,maxwidth FROM RATE_MAST
        SELECT "Comp_code","Rate_Mast_Code","Adv_Type_Code","Adv_Cat_Code","Adv_subcat_code","Rate_Gr_Code","Currency","combin_desc","Combin_Code","Uom","Valid_From","Valid_To","Size_To","Size_From","consumption_Per","Color","Col_chr_typ","Remarks","Week_Day_Rate","Week_min_rate","Week_Extra_Rate","Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid","Premium","Premium_Charges","weekend_rate","weekend_min_rate","weekend_extra","chksolo","min_ad_area","Edition_from","Edition_to","floor_amount","floor_discount",(SELECT "Scheme_Code" FROM SCHEME_MASTER WHERE "scheme_id"=RATE_MAST."Scheme_Name") AS "Scheme_Name","Ad_Subcat4","Ad_Subcat5","Ad_subcat6","From_insertion","To_insertion","Agency_type","Client_cat","Max_Area","rateuniqueid","pub_center",sun_rate,mon_rate,tue_rate,wed_rate,thu_rate,fri_rate,sat_rate,sun_rate_extra,mon_rate_extra,tue_rate_extra,wed_rate_extra,thu_rate_extra,fri_rate_extra,sat_rate_extra,maxwidth,(select "Combin_Desc" from combin_mast where "Combin_Code"=Rate_Mast."Combin_Code") as "desc",PRIORITY,VAT_DETAIL,ADON, REF_ID FROM RATE_MAST
	    WHERE ("Comp_code" = compcode OR compcode IS NULL)
	    AND ("Rate_Mast_Code" = ratecodes  OR ratecodes IS NULL)
	    AND ("Adv_Type_Code" = adtype1  OR adtype1 IS NULL)
        AND ("Adv_Cat_Code" = adcate  OR adcate IS NULL)
	    AND ("Currency" = currency  OR currency IS NULL)
	    AND ("Rate_Gr_Code" = rategroup  OR rategroup IS NULL)
	    AND ("Color" = colorcode  OR colorcode IS NULL)
	    AND ("Uom" = uomcode  OR uomcode IS NULL)
	    AND ("Combin_Code" = packagecode  OR packagecode IS NULL)
	    AND ("pub_center"=pubcenter OR pubcenter IS NULL);
      /*ELSE
	     OPEN P_Accounts FOR
    	 SELECT "Comp_code","Rate_Mast_Code","Adv_Type_Code","Adv_Cat_Code","Adv_subcat_code","Rate_Gr_Code","Currency","combin_desc","Combin_Code","Uom",TO_CHAR("Valid_From",'dd/mm/yyyy')AS "Valid_From" ,TO_CHAR("Valid_To",'dd/mm/yyyy') AS "Valid_To" ,"Size_To","Size_From","consumption_Per","Color","Col_chr_typ","Remarks","Week_Day_Rate","Week_min_rate","Week_Extra_Rate","Focus_Day_Rate","Focus_min_rate","Focus_extra_rate","userid","Premium","Premium_Charges","weekend_rate","weekend_min_rate","weekend_extra","chksolo","min_ad_area","Edition_from","Edition_to","floor_amount","floor_discount","Scheme_Name","Ad_Subcat4","Ad_Subcat5","Ad_subcat6","From_insertion","To_insertion","Agency_type","Client_cat","Max_Area","Agency_code","rateuniqueid" FROM AGENCY_RATE_MAST
    	 WHERE ("Comp_code" = compcode OR compcode IS NULL)
    	 AND ("Rate_Mast_Code" LIKE ratecodes || '%' OR ratecodes IS NULL)
    	 AND ("Adv_Type_Code" LIKE adtype1 || '%' OR adtype1 IS NULL)
    	 AND ("Currency" LIKE currency || '%' OR currency IS NULL)
    	 AND ("Rate_Gr_Code" LIKE rategroup || '%' OR rategroup IS NULL)
    	 AND ("Color" LIKE colorcode || '%' OR colorcode IS NULL)
    	 AND ("Uom" LIKE uomcode || '%' OR uomcode IS NULL)
    	 AND ("Combin_Code" LIKE packagecode || '%' OR packagecode IS NULL);
      END IF;*/
END executeratecode_p;
END  Executeratecode;
/

/*********************** Kuldeep  09/11/2011  *******************/

/**************************** LATA 10 nov 2011 ******************/
/* Formatted on 2011/11/10 17:25 (Formatter Plus v4.8.8) */
CREATE OR REPLACE PROCEDURE committransaction (
   cioid              VARCHAR2,
   totalcount         INT,
   p_error      OUT   VARCHAR2
)
IS
   countnum     INT;
   newid        VARCHAR2 (100);
   billpay      VARCHAR2 (20);
   rostatus     VARCHAR2 (20);
   remarks      VARCHAR2 (500);
   clientname   VARCHAR2 (200);
BEGIN
   newid := cioid;

   SELECT COUNT (*)
     INTO countnum
     FROM tbl_booking_insert_g
    WHERE cio_booking_id = cioid;

   IF (countnum = totalcount)
   THEN
      p_error := 'Y';

      INSERT INTO tbladid_ins
                  (cioid, countnum, flag
                  )
           VALUES (newid, countnum, p_error
                  );

      INSERT INTO tbl_booking_mast
                  ("date_time", "branch", "booked_by", "cio_booking_id",
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
                   "Ad_size_height", "Ad_size_width", "Rate_code",
                   "Scheme_type_code", "Currency_code", "Agrred_rate",
                   "Agreed_amount", "Special_discount", "Space_discount",
                   "Special_charges", "Agency_status", "Agency_type",
                   "Agency_pay", "Agency_credit", "Total_area", "Card_rate",
                   "Card_amount", "Discount", "Discount_per", "Bill_cycle",
                   "Revenue_center", "Bill_pay", "Bill_height", "Bill_width",
                   "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc",
                   "Agency_out", "Box_code", "Box_no", "Box_agency",
                   "Box_client", "Box_address", "Comp_code", "Userid",
                   "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad",
                   "Campaign", "Bill_amount", "Page_prem", "Page_amount",
                   "Prem_per", "Gross_amount", "Ad_size_column",
                   "Bill_column", "Bill_area", "Special_disc_per",
                   "Space_disc_per", "Paid_ins", "Contract_rate", "Deviation",
                   "Variant_code", "Contract_name", "Contract_type",
                   "Card_name", "Card_type", "Card_month", "Card_year",
                   "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4",
                   "Ad_subcat5", "Bg_color", "Bullet_code", "Bullet_premium",
                   "Material_status", "Receipt_date", "prev_cioid",
                   "prev_receipt", "prev_grossamt", "Region", "Variant",
                   "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom",
                   "SAPID", "RETAINER", "ADD_AGENCY_COMM", "AUDIT_COMMENT",
                   "MOBILENO", "ADD_AGENCY_COMM_AMT", "RETAINER_COMM",
                   "RETAINER_COMM_AMT", "CASH_RECIEVED", "CONT_GROSS",
                   "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION",
                   "CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS",
                   "APP_REMARKS", "APP_DATE", "APP_USER", "RODOCSTATUS",
                   cashdiscount, cashdisctype, attachment1, attachment2,
                   disc_premium, doctype, chktradedisc, chk_no, chk_date,
                   chk_amt, chk_bank_name, our_bank, dealerpanel, dealer_h,
                   dealer_w, dealertype, active_agreedrate, active_agreedamt,
                   localgrossamt, localbillamt, package_type, ad_refid)
         SELECT date_time, branch, booked_by, cio_booking_id, prev_booking,
                applied_by, audit_g, ro_no, ro_date, caption, bill_status,
                ro_status, agency_code, agency_address, client_code,
                client_address, agency_sub_code, dockit_no, executive_code,
                executive_zone, product_code, brand_code, key_no,
                bill_remarks, print_remark, package_code, no_of_insertion,
                insertion_date, repeating_day, ad_type_code, ad_cat_code,
                ad_sub_cat_code, color_code, uom_code, page_position_code,
                page_type_code, page_no, ad_size_type_code, ad_size_height,
                ad_size_width, rate_code, scheme_type_code, currency_code,
                agrred_rate, agreed_amount, special_discount, space_discount,
                special_charges, agency_status, agency_type, agency_pay,
                agency_credit, total_area, card_rate, card_amount, discount,
                discount_per, bill_cycle, revenue_center, bill_pay,
                bill_height, bill_width, bill_to, invoices, vts, bill_add,
                trade_disc, agency_out, box_code, box_no, box_agency,
                box_client, box_address, comp_code, userid, creation_datetime,
                booking_type, tfn, coupan_ad, campaign, bill_amount,
                page_prem, page_amount, prem_per, gross_amount,
                ad_size_column, bill_column, bill_area, special_disc_per,
                space_disc_per, paid_ins, contract_rate, deviation,
                variant_code, contract_name, contract_type, card_name,
                card_type, card_month, card_year, card_number, receipt_no,
                ad_subcat3, ad_subcat4, ad_subcat5, bg_color, bullet_code,
                bullet_premium, material_status, receipt_date, prev_cioid,
                prev_receipt, prev_grossamt, region, variant, colortype,
                logo_h, logo_w, logo_color, logo_uom, sapid, retainer,
                add_agency_comm, audit_comment, mobileno, add_agency_comm_amt,
                retainer_comm, retainer_comm_amt, cash_recieved, cont_gross,
                ciragency, cirrate, ciredition, cirpublication,
                ciragency_subcode, barter_type, app_status, app_remarks,
                app_date, app_user, rodocstatus, cashdiscount, cashdisctype,
                attachment1, attachment2, disc_premium, doctype, chktradedisc,
                chk_no, chk_date, chk_amt, chk_bank_name, our_bank,
                dealerpanel, dealer_h, dealer_w, dealertype,
                active_agreedrate, active_agreedamt, localgrossamt,
                localbillamt, package_type, ad_refid
           FROM tbl_booking_mast_g
          WHERE cio_booking_id = cioid;

      INSERT INTO tbl_booking_insert
                  ("Insert_Id", "Cio_Booking_Id", "No_Insert", "Edition_Code",
                   "Publication_Code", "Pub_Cent_Code", "Supp_Code",
                   "Edition", "Insert_Date", "Col_Code", "Height", "Width",
                   "Size_Book", "Page_Post", "Premium1", "Prem_Per1",
                   "Premium2", "Prem_Per2", "Premium_Allow", "Ad_Cat",
                   "Ad_Sub_Cat", "Latest_By", "Repeating_Date",
                   "Status_Material", "File_Name", "Card_Rate", "Disc_Rate",
                   "Insert_Status", "Bill_Status", "Agreed_Rate",
                   "Pai_Free_Ins", "Solo_Rate", "Gross_Rate", "Comp_Code",
                   "Userid", "Page_No", "Remarks", "Pub_Height", "Pub_Width",
                   "Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt",
                   "Bill_Rate", "Logo_H", "Logo_W", "Logo_name", "AD_SUBCAT3",
                   "AD_SUBCAT4", "AD_SUBCAT5", "PACKAGE_CODE", "BILL_NO",
                   "BILL_DATE", "INSERTS", "PKG_ALIAS", "CONT_GROSS_AMT",
                   "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER",
                   special_size1, vatamt, boxcharge, vat_inc, localgrossamt,
                   localbillamt, sectioncode)
         SELECT insert_id, cio_booking_id, no_insert, edition_code,
                publication_code, pub_cent_code, supp_code, edition,
                insert_date, col_code, height, width, size_book, page_post,
                premium1, prem_per1, premium2, prem_per2, premium_allow,
                ad_cat, ad_sub_cat, latest_by, repeating_date,
                status_material, file_name, card_rate, disc_rate,
                insert_status, bill_status, agreed_rate, pai_free_ins,
                solo_rate, gross_rate, comp_code, userid, page_no, remarks,
                pub_height, pub_width, page_prem, page_per, no_ofcolumn,
                bill_amt, bill_rate, logo_h, logo_w, logo_name, ad_subcat3,
                ad_subcat4, ad_subcat5, package_code, bill_no, bill_date,
                inserts, pkg_alias, cont_gross_amt, app_status, app_remarks,
                app_date, app_user, special_size1, vatamt, boxcharge, vat_inc,
                localgrossamt, localbillamt, sectioncode
           FROM tbl_booking_insert_g
          WHERE cio_booking_id = cioid;

      INSERT INTO tbl_booking_vts
                  (compcode, cioid, insertid, vts, publication, edition, rate,
                   creationdatetime, ciragcode, ciragsubcode, center, branch,
                   publishdate)
         SELECT compcode, cioid, insertid, vts, publication, edition, rate,
                creationdatetime, ciragcode, ciragsubcode, center, branch,
                publishdate
           FROM tbl_booking_vts_g
          WHERE cioid = newid;

      INSERT INTO tbl_booking_insert_sizesplit
                  (cioid, receiptno, insertid, insertdate, height, width,
                   area, srno, creationdatetime)
         SELECT cioid, receiptno, insertid, insertdate, height, width, area,
                srno, creationdatetime
           FROM tbl_booking_insert_sizesplit_g
          WHERE cioid = newid;

--INSERT INTO ABCTEST VALUES(newid,counttest);
      INSERT INTO tbl_booking_subedition
                  (comp_code, cioid, insertid, publication, edition,
                   insertdate, height, width, totalarea, insertstatus,
                   receiptno, srno, no_insert)
         SELECT comp_code, cioid, insertid, publication, edition, insertdate,
                height, width, totalarea, insertstatus, receiptno, srno,
                no_insert
           FROM tbl_booking_subedition_g
          WHERE tbl_booking_subedition_g.cioid = newid;

      INSERT INTO tbl_booking_sharing_trans
                  (publication, TYPE, sharing, cioid, srno)
         SELECT publication, TYPE, sharing, cioid, srno
           FROM tbl_booking_sharing_trans_g
          WHERE cioid = cioid;

      INSERT INTO tbl_booking_fmg_trans
                  (cioid, insertid, creationdatetime)
         SELECT cioid, insertid, creationdatetime
           FROM tbl_booking_fmg_trans_g
          WHERE cioid = cioid;

      SELECT "Bill_pay", "ro_status"
        INTO billpay, rostatus
        FROM tbl_booking_mast
       WHERE "cio_booking_id" = cioid;

      IF billpay = 'CA0' AND rostatus = '1'
      THEN
         DECLARE
            CURSOR c1
            IS
               SELECT *
                 FROM tbl_booking_mast
                WHERE "cio_booking_id" = cioid;

            v1             c1%ROWTYPE;
            v_error        VARCHAR2 (2000);
            v_rcptno_r     VARCHAR2 (50);
            vrecpt         VARCHAR2 (20);
            branchcode     VARCHAR2 (20);
            vrepcode       VARCHAR2 (20);
            subagencyreg   VARCHAR2 (20);
            prevcioid_v    VARCHAR2 (50);
            billamt_v      FLOAT;
            grossamt_v     FLOAT;
            v_curdate      DATE;
         BEGIN
            OPEN c1;

            FETCH c1
             INTO v1;

            BEGIN
               SELECT "Branch_Code"
                 INTO branchcode
                 FROM branch_mst
                WHERE "Comp_Code" = v1."Comp_code"
                  AND "Branch_Name" = v1."branch";
            EXCEPTION
               WHEN NO_DATA_FOUND
               THEN
                  branchcode := '';
            END;

            BEGIN
               SELECT "SUB_Agency_Code"
                 INTO subagencyreg
                 FROM agency_mast
                WHERE "Comp_Code" = v1."Comp_code"
                  AND "code_subcode" = v1."Agency_sub_code";
            EXCEPTION
               WHEN NO_DATA_FOUND
               THEN
                  subagencyreg := '';
            END;

            vrecpt := v1."Receipt_no";
            prevcioid_v := v1."prev_cioid";

            IF prevcioid_v IS NULL OR v1."prev_receipt" IS NULL
            THEN
               billamt_v := v1."Bill_amount";
               grossamt_v := v1."Gross_amount";
               v_curdate := TO_DATE (SYSDATE);
            ELSE
               SELECT "Bill_amount", "Gross_amount"
                 INTO billamt_v, grossamt_v
                 FROM tbl_booking_mast
                WHERE "cio_booking_id" = prevcioid_v;

               billamt_v := v1."Bill_amount" - billamt_v;
               grossamt_v := v1."Gross_amount" - grossamt_v;

               IF grossamt_v = 0 OR grossamt_v IS NULL
               THEN
                  grossamt_v := v1."Gross_amount";
               END IF;

               v_curdate := TO_DATE (SYSDATE);
            END IF;

            -- select substr(max("recptno"),1,12)||lpad(substr(max("recptno"),-6)+1,6,'0') into vrecpt from ad_rcpthdr where 

"unit"=branchcode and "doctype"='RCP' and
            -- "recptdt" between '1-mar-2011' and '31-mar-2011';

            --receiptsave_booking.receiptsave_booking_P(pcompcode,puserid , punit ,ptype , precpt , prdate , ppaymodres 

,preceivedreg ,pvouno  ,pamount  ,pagency , pothercd ,
             --pchno  ,pchedate , pbank  , pnarration ,prep   , pvdate , pag_main_code ,pag_sub_code , ourbank,  cioid , 

execname , retainer ,
              -- prevcioid , p_error)
            BEGIN
               SELECT "Cust_Name"
                 INTO clientname
                 FROM cust_mast
                WHERE "Cust_Code" = v1."Client_code"
                  AND "Comp_Code" = v1."Comp_code";
            EXCEPTION
               WHEN NO_DATA_FOUND
               THEN
                  clientname := v1."Client_code";
            END;

            remarks :=
                  'RONO#'
               || v1."RO_No"
               || ' RODATE# '
               || TO_CHAR (v1."RO_Date", 'dd-mon-yyyy')
               || ' BOOKINGID# '
               || v1."cio_booking_id"
               || ' CLIENT#'
               || clientname;
            receiptsave_booking.receiptsave_booking_p (v1."Comp_code",
                                                       v1."Userid",
                                                       v1."branch",
                                                       v1.doctype,
                                                       vrecpt,
                                                       v_curdate,
                                                       v1."Bill_pay",
                                                       '',
                                                       '',
                                                       billamt_v,
                                                       v1."Agency_sub_code",
                                                       grossamt_v,
                                                       '',
                                                       '',
                                                       '',
                                                       remarks,
                                                       vrepcode,
                                                       v1."date_time",
                                                       v1."Agency_code",
                                                       subagencyreg,
                                                       '',
                                                       v1."cio_booking_id",
                                                       v1."Executive_code",
                                                       v1.retainer,
                                                       v1."prev_cioid",
                                                       v_rcptno_r,
                                                       v_error
                                                      );

            UPDATE tbl_booking_mast
               SET "Receipt_no" = v_rcptno_r,
                   "Receipt_date" = v_curdate
             WHERE "cio_booking_id" = v1."cio_booking_id";

            CLOSE c1;

            COMMIT;
         END;
      END IF;
    /*
    INSERT INTO TBL_BOOKING_MAST("date_time", "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by", 

"audit", "RO_No", "RO_Date", "Caption", "bill_status", "ro_status", "Agency_code", "Agency_address", "Client_code", 

"Client_address", "Agency_sub_code", "Dockit_no", "Executive_code", "Executive_zone", "Product_code", "Brand_code", 

"Key_no", "Bill_remarks", "Print_remark", "Package_code", "No_of_insertion", "Insertion_date", "Repeating_day", 

"Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code", "Color_code", "Uom_code", "Page_position_code", "Page_type_code", 

"Page_no", "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code", "Scheme_type_code", "Currency_code", 

"Agrred_rate", "Agreed_amount", "Special_discount", "Space_discount", "Special_charges", "Agency_status", 

"Agency_type", "Agency_pay", "Agency_credit", "Total_area", "Card_rate", "Card_amount", "Discount", "Discount_per", 

"Bill_cycle", "Revenue_center", "Bill_pay", "Bill_height", "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc", 

"Agency_out", "Box_code", "Box_no", "Box_agency", "Box_client", "Box_address", "Comp_code", "Userid", 

"Creation_datetime", "Booking_type", "Tfn", "Coupan_ad", "Campaign", "Bill_amount", "Page_prem", "Page_amount", 

"Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", "Bill_area", "Special_disc_per", "Space_disc_per", 

"Paid_ins", "Contract_rate", "Deviation", "Variant_code", "Contract_name", "Contract_type", "Card_name", "Card_type", 

"Card_month", "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", 

"Bullet_code", "Bullet_premium", "Material_status", "Receipt_date", "prev_cioid", "prev_receipt", "prev_grossamt", "Region", 

"Variant", "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom", "SAPID", "RETAINER", "ADD_AGENCY_COMM", 

"AUDIT_COMMENT", "MOBILENO", "ADD_AGENCY_COMM_AMT", "RETAINER_COMM", "RETAINER_COMM_AMT", 

"CASH_RECIEVED", "CONT_GROSS", "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION", 

"CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER", 

"RODOCSTATUS")
   SELECT DATE_TIME, BRANCH, BOOKED_BY, CIO_BOOKING_ID, PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO, 

RO_DATE, CAPTION, BILL_STATUS, RO_STATUS, AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE, 

CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO, EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE, 

BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK, PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE, 

REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE, AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE, 

PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO, AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH, 

RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE, AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT, 

SPACE_DISCOUNT, SPECIAL_CHARGES, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY, AGENCY_CREDIT, 

TOTAL_AREA, CARD_RATE, CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE, REVENUE_CENTER, 

BILL_PAY, BILL_HEIGHT, BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD, TRADE_DISC, AGENCY_OUT, BOX_CODE, 

BOX_NO, BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS, COMP_CODE, USERID, CREATION_DATETIME, 

BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN, BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER, 

GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN, BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER, 

PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE, CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME, 

CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER, RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, 

AD_SUBCAT5, BG_COLOR, BULLET_CODE, BULLET_PREMIUM, MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID, 

PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT, COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR, 

LOGO_UOM, SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO, ADD_AGENCY_COMM_AMT, 

RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS, CIRAGENCY, CIRRATE, CIREDITION, 

CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, 

RODOCSTATUS FROM TBL_BOOKING_MAST_G WHERE SESID=USERENV ('sessionid') and CIO_BOOKING_ID=cioid;

   INSERT INTO TBL_BOOKING_insert("Insert_Id", "Cio_Booking_Id", "No_Insert", "Edition_Code", "Publication_Code", 

"Pub_Cent_Code", "Supp_Code", "Edition", "Insert_Date", "Col_Code", "Height", "Width", "Size_Book", "Page_Post", 

"Premium1", "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow", "Ad_Cat", "Ad_Sub_Cat", "Latest_By", 

"Repeating_Date", "Status_Material", "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status", "Bill_Status", "Agreed_Rate", 

"Pai_Free_Ins", "Solo_Rate", "Gross_Rate", "Comp_Code", "Userid", "Page_No", "Remarks", "Pub_Height", "Pub_Width", 

"Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name", "AD_SUBCAT3", 

"AD_SUBCAT4", "AD_SUBCAT5", "PACKAGE_CODE", "BILL_NO", "BILL_DATE", "INSERTS", "PKG_ALIAS", 

"CONT_GROSS_AMT", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER")
   SELECT INSERT_ID, CIO_BOOKING_ID, NO_INSERT, EDITION_CODE, PUBLICATION_CODE, PUB_CENT_CODE, 

SUPP_CODE, EDITION, INSERT_DATE, COL_CODE, HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1, 

PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW, AD_CAT, AD_SUB_CAT, LATEST_BY, REPEATING_DATE, 

STATUS_MATERIAL, FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS, BILL_STATUS, AGREED_RATE, 

PAI_FREE_INS, SOLO_RATE, GROSS_RATE, COMP_CODE, USERID, PAGE_NO, REMARKS, PUB_HEIGHT, 

PUB_WIDTH, PAGE_PREM, PAGE_PER, NO_OFCOLUMN, BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME, 

AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, PACKAGE_CODE, BILL_NO, BILL_DATE, INSERTS, PKG_ALIAS, 

CONT_GROSS_AMT, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER FROM TBL_BOOKING_INSERT_G 

WHERE SESID=USERENV ('sessionid') and CIO_BOOKING_ID=cioid;

   */
   ELSE
      ROLLBACK;
      p_error := 'N';

--DELETE FROM TBL_BOOKING_INSERT WHERE "Cio_Booking_Id"=cioid;
--DELETE FROM TBL_BOOKING_mast WHERE "cio_booking_id"=cioid;
      INSERT INTO tbladid_ins
                  (cioid, countnum, flag
                  )
           VALUES (newid, countnum, p_error
                  );
   END IF;
--delete from tbl_booking_mast_g where  CIO_BOOKING_ID=cioid;
--delete from tbl_booking_insert_g where  CIO_BOOKING_ID=cioid;
--delete from tbl_booking_vts_g where  cioid=newid;
END;
/


CREATE OR REPLACE PACKAGE BODY getdataforexecute
IS
   PROCEDURE  getdataforexecute_p (
           compcode in varchar2,
ciobid  in varchar2,
p_accounts   OUT      t_accounts_cursor,
p_accounts1   OUT      t_accounts_cursor,
p_accounts2   OUT      t_accounts_cursor,
p_accounts3   OUT      t_accounts_cursor,
p_accounts4   OUT      t_accounts_cursor,
p_accounts5   OUT      t_accounts_cursor,
p_accounts6   OUT      t_accounts_cursor,
p_accounts7   OUT      t_accounts_cursor,
p_accounts8   OUT      t_accounts_cursor,
p_accounts9   out      t_accounts_cursor,
p_accounts10   out       t_accounts_cursor,
p_accounts11   out       t_accounts_cursor,
p_accounts12   out       t_accounts_cursor
   )
   AS
   --adv_subcat_code   varchar2(20);
   --adcat3 varchar2(20);
   --adcat4 varchar2(20);
   BEGIN

    --BEGIN
        insert into advcategories select "Ad_Sub_Cat","AD_SUBCAT3","AD_SUBCAT4" from tbl_booking_insert where ("Comp_Code"=compcode) and ("Cio_Booking_Id"=ciobid);
        --EXCEPTION WHEN NO_DATA_FOUND
        --THEN NULL;
    --END;

    OPEN p_accounts FOR
        select "Cio_Booking_Id" as  "cio_booking_id","Edition","Insert_Date" as "Insert_date","Col_Code" as "Col_code" ,"Height","Width","Size_Book" as "Size_book","Page_Post" as "Page_post","Premium1","Prem_Per1" as "Prem_per1","Premium2",nvl("Prem_Per2",'0') as "Prem_per2","Premium_Allow" as "Premium_allow","Ad_Cat" as "Ad_cat","Ad_Sub_Cat" as "Ad_sub_cat","Latest_By"as "Latest_by","Status_Material" as "Status_material" ,"File_Name" as "File_name","Card_Rate" as "Card_rate",nvl("Disc_Rate",'0') as "Disc_rate","Insert_Status" as "Insert_status","Bill_Status" as "Bill_status","Comp_Code" as "comp_code","Userid","Repeating_Date" as "Repeating_date" ,"No_Insert" as "no_insert","Edition_Code" as "Edition_code","Publication_Code" as "Publication_code","Pub_Cent_Code" as "Pub_cent_code","Supp_Code" as "Supp_code",nvl("Agreed_Rate",'0') as "Agreed_rate","Pai_Free_Ins" as "Pai_free_ins",nvl("Solo_Rate",'0') as "Solo_rate","Insert_Id" as "insert_id","Gross_Rate" as "Gross_rate","Page_No" as "Page_no" ,"Remarks","Page_Prem" as "Page_prem",nvl("Page_Per",'0') as "page_per","No_Ofcolumn" as "No_ofcolumn","Bill_Amt" as "Bill_Amt","Bill_Rate" as "Bill_rate", "Logo_H" as "Logo_H", "Logo_W" as "Logo_W" , "Logo_name" as "Logo_name","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS
        ,"Publication_Code" AS "PUBCODE",
 (SELECT VTS FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as VTS,
 (SELECT PUBLICATION FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as CIRPUBLICATION,
 (SELECT EDITION FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as CIREDITION,
 (SELECT RATE FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as CIRRATE,
 (SELECT PUBLISHDATE FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id") as CIRPUBLISHDATE,
 (SELECT edtn_name FROM cir_edtn_mast WHERE comp_code=compcode AND edtn=(SELECT EDITION FROM TBL_BOOKING_VTS WHERE CIOID="Cio_Booking_Id" and INSERTID="Insert_Id")) AS CIREDITIONNAME
 ,
(select NVL(PRIORITY,'1') FROM TBL_PRIORITY_UOM WHERE EDITION_CODE=TBL_BOOKING_INSERT."Edition_Code" and TBL_PRIORITY_UOM.COMBIN_CODE=TBL_BOOKING_INSERT.PACKAGE_CODE) AS PRIORITY,
(SELECT SPLIT FROM COMBIN_MAST WHERE "Combin_Code"=PACKAGE_CODE)  as SPLIT,SPECIAL_SIZE1,VATAMT, nvl(BOXCHARGE,'') as BOXCHARGE,NVL(VAT_INC,'0') as VAT_INC,nvl(LOCALGROSSAMT,"Gross_Rate") as LOCALGROSSAMT, nvl(LOCALBILLAMT,"Bill_Amt") AS LOCALBILLAMT,
NVL(SECTIONCODE,'') AS SECTIONCODE, NVL(RESOURCE_NO,'') AS RESOURCE_NO
         from tbl_booking_insert where ("Comp_Code"=compcode) and ("Cio_Booking_Id"=ciobid) order by "Insert_Id";


    OPEN p_accounts1 FOR
        select "Col_Name" as  "col_Name","Col_Code" as "col_Code" from col_mast where ("Comp_Code"=compcode);
    OPEN p_accounts2 FOR
        select "premiumname" as "premiumname","Premiumcode" as "Premiumcode" from ADVPOS_PREM_MAST where ("comp_code"=compcode);
    OPEN p_accounts3 FOR
        select "Adv_Subcat_Name","Adv_Subcat_Code" from adv_subcat_mast;
    OPEN p_accounts4 FOR
        select "Uom_Name" as "uom_name","Uom_Code" as "uom_code" from uom_mast where ("Comp_Code"=compcode);
    OPEN p_accounts5 FOR
        select "Adv_Type_Name" as "adv_type_name","Adv_Type_Code" as "adv_type_code" from adv_type_mast where "Comp_Code"=compcode;
    OPEN p_accounts6 FOR
        select "Adv_Cat_Name" as "adv_cat_name","Adv_Cat_Code" as "adv_cat_code" from ADV_CAT_MAST where ("Comp_Code"=compcode);
    OPEN p_accounts7 FOR
        select "Pos_Type_Code" as "pos_type_code","Pos_Type" as "pos_type" from advpos_type_mast where ("Comp_Code"=compcode);
    OPEN p_accounts8 FOR
        select   "Paid_permission"   from Module_DetaiButtonl  where ("comp_code"=compcode) and ("Form_Name"='Booking_master');

    open p_accounts9 for
        select "Logo_name" as "Logo_name"from tbl_booking_insert where "Comp_Code"=compcode and "Cio_Booking_Id"=ciobid and rownum<=1;

    open p_accounts10 for
        select "catname","catcode" from ad_cat3 where "subcatname" in (select AD_SUB_CAT from advcategories) order by "catname";

    open p_accounts11 for
        select "Cat_Name","Cat_Code" from tbl_cat4 where "Sub_Cat_Name" in (select AD_SUBCAT3 from advcategories) order by "Cat_Name";

    open p_accounts12 for
        select "Cat_Name","Cat_Code" from tbl_cat5 where "Sub_Cat_Name" in (select AD_SUBCAT4 from advcategories) order by "Cat_Name";
    
 
 
   END  getdataforexecute_P;
END  getdataforexecute;
/



CREATE OR REPLACE PROCEDURE getsectioncode (
   name_p             VARCHAR2,
   p_accounts   OUT   cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT code, NAME
        FROM tbl_sectioncode
       WHERE UPPER (NAME) LIKE UPPER (name_p) || '%';
END;
/

CREATE OR REPLACE PACKAGE insertintobookchild
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  insertintobookchild_p (


    insertdate in date,
edition in varchar2,
premium1 in varchar2,
premium2 in varchar2,
premallow in varchar2,
adcategory in varchar2,
latestdate in date,
material in varchar2,
cardrate in number,
matfilename in varchar2,
discrate in number,
insertstatus in varchar2,
billstatus in varchar2,
adsubcat1 in varchar2,
compcode in varchar2,
userid in varchar2,
cioid in varchar2,
height in number,
width in number,
totalsize in number,
pagepost in varchar2,
premper1 in number,
premper2 in number,
colid in varchar2,
repeat in date,
insertno in int,
paid in varchar2,
agrrate in number,
solorate in number,
grossrate in number,
insert_pageno in number,
insert_remarks in varchar2,
page_code in varchar2,
page_per in number,
noofcol in number,
billamt in number,
billrate in number,
logo_h in varchar2,
logo_w in varchar2,
logo_name in varchar2,
ad_cat_3 in varchar2,
ad_cat_4 in varchar2,
ad_cat_5 in varchar2,
pkgcode in varchar2,
gridins in number,
pkgalias in varchar2,
cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date, 
ciragency_v in varchar2,
 ciragencysubcode_v in varchar2, 
 center_v in varchar2,
  branch_v in varchar2,
  splitdata_v in varchar2,
  subedidata in varchar2,
  splboldsizevalue IN VARCHAR2,
  vatrate_p in float,
  boxcharge_p in float,
  vat_inc_p in varchar2,
  grossamtlocal_p in varchar2,
  billamtlocal_p in varchar2,
  sectioncode_p in varchar2,
    p_error out varchar2

   );
END insertintobookchild;
/

CREATE OR REPLACE PACKAGE BODY insertintobookchild
IS
   PROCEDURE insertintobookchild_p (
      insertdate           IN       DATE,
      edition              IN       VARCHAR2,
      premium1             IN       VARCHAR2,
      premium2             IN       VARCHAR2,
      premallow            IN       VARCHAR2,
      adcategory           IN       VARCHAR2,
      latestdate           IN       DATE,
      material             IN       VARCHAR2,
      cardrate             IN       NUMBER,
      matfilename          IN       VARCHAR2,
      discrate             IN       NUMBER,
      insertstatus         IN       VARCHAR2,
      billstatus           IN       VARCHAR2,
      adsubcat1            IN       VARCHAR2,
      compcode             IN       VARCHAR2,
      userid               IN       VARCHAR2,
      cioid                IN       VARCHAR2,
      height               IN       NUMBER,
      width                IN       NUMBER,
      totalsize            IN       NUMBER,
      pagepost             IN       VARCHAR2,
      premper1             IN       NUMBER,
      premper2             IN       NUMBER,
      colid                IN       VARCHAR2,
      repeat               IN       DATE,
      insertno             IN       INT,
      paid                 IN       VARCHAR2,
      agrrate              IN       NUMBER,
      solorate             IN       NUMBER,
      grossrate            IN       NUMBER,
      insert_pageno        IN       NUMBER,
      insert_remarks       IN       VARCHAR2,
      page_code            IN       VARCHAR2,
      page_per             IN       NUMBER,
      noofcol              IN       NUMBER,
      billamt              IN       NUMBER,
      billrate             IN       NUMBER,
      logo_h               IN       VARCHAR2,
      logo_w               IN       VARCHAR2,
      logo_name            IN       VARCHAR2,
      ad_cat_3             IN       VARCHAR2,
      ad_cat_4             IN       VARCHAR2,
      ad_cat_5             IN       VARCHAR2,
      pkgcode              IN       VARCHAR2,
      gridins              IN       NUMBER,
      pkgalias             IN       VARCHAR2,
      cirvts               IN       VARCHAR2,
      cirpub               IN       VARCHAR2,
      ciredi               IN       VARCHAR2,
      cirrate              IN       VARCHAR2,
      cirdate_v            IN       DATE,
      ciragency_v          IN       VARCHAR2,
      ciragencysubcode_v   IN       VARCHAR2,
      center_v             IN       VARCHAR2,
      branch_v             IN       VARCHAR2,
        splitdata_v          IN       VARCHAR2,
         subedidata in varchar2,
         splboldsizevalue IN VARCHAR2,
          vatrate_p in float,
            boxcharge_p in float,
            vat_inc_p in varchar2,
            grossamtlocal_p in varchar2,
            billamtlocal_p in varchar2,
            sectioncode_p in varchar2,
      p_error              OUT      VARCHAR2
   )
   AS
      edi           VARCHAR2 (50);
      publi         VARCHAR2 (50);
      pub_cent      VARCHAR2 (50);
      supp          VARCHAR2 (50);
      cou1          NUMBER;
      ID            NUMBER;
      insertidval   NUMBER;
      receiptno_m varchar2(50);
      error1 varchar2(100);
   BEGIN
    BEGIN
    select Receipt_no into receiptno_m from tbl_booking_mast_g where cio_booking_id=cioid and rownum<=1;
     EXCEPTION
         WHEN NO_DATA_FOUND
         THEN
            NULL;
      END;
      BEGIN
         SELECT COUNT (*)
           INTO cou1
           FROM edition_mast
          WHERE ("Edition_Alias" = edition) AND ("Comp_Code" = compcode);
      EXCEPTION
         WHEN NO_DATA_FOUND
         THEN
            NULL;
      END;

      IF (cou1 > 0)
      THEN
         BEGIN
            SELECT "Edition_Code"
              INTO edi
              FROM edition_mast
             WHERE ("Edition_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Pub_Code"
              INTO publi
              FROM edition_mast
             WHERE ("Edition_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "City_Code"
              INTO pub_cent
              FROM edition_mast
             WHERE ("Edition_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         supp := '';
      ELSE
         BEGIN
            SELECT "Edition_Code"
              INTO edi
              FROM supplement_mast
             WHERE ("Supp_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Pub_Code"
              INTO publi
              FROM supplement_mast
             WHERE ("Supp_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Supp_Code"
              INTO supp
              FROM supplement_mast
             WHERE ("Supp_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "City_Code"
              INTO pub_cent
              FROM edition_mast
             WHERE ("Edition_Code" = edi)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;
      END IF;

      IF (supp IS NULL)
      THEN
         supp := 'MN';
      END IF;

--insertidval:=INSERTID.nextval;
      SELECT insertid.NEXTVAL
        INTO insertidval
        FROM DUAL;
        INSERT INTO tbl_booking_insert_G
                  (CIO_BOOKING_ID, EDITION, INSERT_DATE, COL_CODE,
                   HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1,
                   PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW,
                   AD_CAT, AD_SUB_CAT, LATEST_BY, STATUS_MATERIAL,
                   FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS,
                   BILL_STATUS, COMP_CODE, USERID, REPEATING_DATE,
                   NO_INSERT, EDITION_CODE, PUBLICATION_CODE,
                   PUB_CENT_CODE, SUPP_CODE, PAI_FREE_INS,
                   AGREED_RATE, SOLO_RATE, GROSS_RATE, PAGE_NO,
                   REMARKS, PAGE_PREM, PAGE_PER, NO_OFCOLUMN,
                   BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME,
                   INSERT_ID, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5,
                   PACKAGE_CODE, INSERTS, PKG_ALIAS, 

SESID,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE
                  )
           VALUES (cioid, edition, insertdate, colid,
                   height, width, totalsize, pagepost, premium1,
                   premper1, premium2, premper2, premallow,
                   adcategory, adsubcat1, latestdate, material,
                   matfilename, cardrate, discrate, insertstatus,
                   billstatus, compcode, userid, repeat,
                   insertno, edi, publi,
                   pub_cent, supp, paid,
                   agrrate, solorate, grossrate, insert_pageno,
                   insert_remarks, page_code, page_per, noofcol,
                   billamt, billrate, logo_h, logo_w, logo_name,
                   insertidval, ad_cat_3, ad_cat_4, ad_cat_5,
                   pkgcode, gridins, pkgalias,USERENV 

('sessionid'),splboldsizevalue,vatrate_p,boxcharge_p,vat_inc_p,grossamtlocal_p,billamtlocal_p,sectioncode_p
                  );
                  insert_split_details(splitdata_v,receiptno_m,cioid,insertidval,error1);
                 INSERT INTO TEST1 VALUES(edition,'EDITION');
                 

insert_edition_details(subedidata,receiptno_m,cioid,insertidval,compcode,edi,insertdate,height,width,totalsize,insertstatus,pkg

code,insertno,error1);
                 commit;
                  --insert into abctest values(edition);
/*                 
      INSERT INTO tbl_booking_insert
                  ("Cio_Booking_Id", "Edition", "Insert_Date", "Col_Code",
                   "Height", "Width", "Size_Book", "Page_Post", "Premium1",
                   "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow",
                   "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Status_Material",
                   "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status",
                   "Bill_Status", "Comp_Code", "Userid", "Repeating_Date",
                   "No_Insert", "Edition_Code", "Publication_Code",
                   "Pub_Cent_Code", "Supp_Code", "Pai_Free_Ins",
                   "Agreed_Rate", "Solo_Rate", "Gross_Rate", "Page_No",
                   "Remarks", "Page_Prem", "Page_Per", "No_Ofcolumn",
                   "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name",
                   "Insert_Id", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5",
                   package_code, inserts, pkg_alias
                  )
           VALUES (cioid, edition, insertdate, colid,
                   height, width, totalsize, pagepost, premium1,
                   premper1, premium2, premper2, premallow,
                   adcategory, adsubcat1, latestdate, material,
                   matfilename, cardrate, discrate, insertstatus,
                   billstatus, compcode, userid, repeat,
                   insertno, edi, publi,
                   pub_cent, supp, paid,
                   agrrate, solorate, grossrate, insert_pageno,
                   insert_remarks, page_code, page_per, noofcol,
                   billamt, billrate, logo_h, logo_w, logo_name,
                   insertidval, ad_cat_3, ad_cat_4, ad_cat_5,
                   pkgcode, gridins, pkgalias
                  );
*/
      IF (cirvts IS NOT NULL)
      THEN
         INSERT INTO TBL_BOOKING_VTS_g
                     (compcode, cioid, insertid, vts, publication, edition,
                      rate, ciragcode, ciragsubcode, center,
                      branch, publishdate ,SESID
                     )
              VALUES (compcode, cioid, insertidval, cirvts, cirpub, ciredi,
                      cirrate, ciragency_v, ciragencysubcode_v, center_v,
                      branch_v, cirdate_v,USERENV ('sessionid')
                     );
      END IF;
   EXCEPTION
      WHEN OTHERS
      THEN
         p_error := 'Error:' || SQLERRM;
   END insertintobookchild_p;
END insertintobookchild;
/


CREATE OR REPLACE PACKAGE insertintobookchild_display
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  insertintobookchild_display_p (


    insertdate in date,
edition in varchar2,
premium1 in varchar2,
premium2 in varchar2,
premallow in varchar2,
adcategory in varchar2,
latestdate in date,
material in varchar2,
cardrate in number,
matfilename in varchar2,
discrate in number,
insertstatus in varchar2,
billstatus in varchar2,
adsubcat1 in varchar2,
compcode in varchar2,
userid in varchar2,
cioid in varchar2,
height in number,
width in number,
totalsize in number,
pagepost in varchar2,
premper1 in number,
premper2 in number,
colid in varchar2,
repeat in date,
insertno in int,
paid in varchar2,
agrrate in number,
solorate in number,
grossrate in number,
insert_pageno in number,
insert_remarks in varchar2,
page_code in varchar2,
page_per in number,
noofcol in number,
billamt in number,
billrate in number,
logo_h in varchar2,
logo_w in varchar2,
logo_name in varchar2,
ad_cat_3 in varchar2,
ad_cat_4 in varchar2,
ad_cat_5 in varchar2,
pkgcode in varchar2,
gridins in number,
pkgalias in varchar2,
insertid1 in number,
cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date, 
ciragency_v in varchar2,
 ciragencysubcode_v in varchar2, 
 center_v in varchar2,
  branch_v in varchar2,
    boxcharge_p in float,
    vat_inc_p in varchar2,
    vatrate_p in float,
    grossamtlocal_p in number,
    billamtlocal_p in number,
    sectioncode_p in varchar2,
    resourceno_p in varchar2
   );
END insertintobookchild_display;
/


CREATE OR REPLACE PACKAGE BODY insertintobookchild_display
IS
   PROCEDURE insertintobookchild_display_p (
    insertdate in date,
    edition in varchar2,
    premium1 in varchar2,
    premium2 in varchar2,
    premallow in varchar2,
    adcategory in varchar2,
    latestdate in date,
    material in varchar2,
    cardrate in number,
    matfilename in varchar2,
    discrate in number,
    insertstatus in varchar2,
    billstatus in varchar2,
    adsubcat1 in varchar2,
    compcode in varchar2,
    userid in varchar2,
    cioid in varchar2,
    height in number,
    width in number,
    totalsize in number,
    pagepost in varchar2,
    premper1 in number,
    premper2 in number,
    colid in varchar2,
    repeat in date,
    insertno in int,
    paid in varchar2,
    agrrate in number,
    solorate in number,
    grossrate in number,
    insert_pageno in number,
    insert_remarks in varchar2,
    page_code in varchar2,
    page_per in number,
    noofcol in number,
    billamt in number,
    billrate in number,
    logo_h in varchar2,
    logo_w in varchar2,
    logo_name in varchar2,
    ad_cat_3 in varchar2,
    ad_cat_4 in varchar2,
    ad_cat_5 in varchar2,
    pkgcode in varchar2,
    gridins in number,
    pkgalias in varchar2,
    insertid1 in number,
    cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date, 
ciragency_v in varchar2,
 ciragencysubcode_v in varchar2, 
 center_v in varchar2,
  branch_v in varchar2,
    boxcharge_p in float,
     vat_inc_p in varchar2,
     vatrate_p in float,
     grossamtlocal_p in number,
    billamtlocal_p in number,
    sectioncode_p in varchar2,
    resourceno_p in varchar2
    )
   
AS
    edi varchar2(50);
    publi varchar2(50);
    pub_cent varchar2(50);
    supp varchar2(50);
    cou1 number;
    id number;
    billnum varchar2(50);
    retain varchar2(50);
    executive varchar(50);    
insertidval number;
countcir number;
    BEGIN
        begin
            select count(*) into cou1 from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

    if(cou1 >0) then
        begin
            select "Edition_Code" into edi from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select "Pub_Code" into publi from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select "City_Code" into pub_cent from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        supp:='';
    else
        begin
            select "Edition_Code" into edi from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select"Pub_Code" into publi from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select "Supp_Code"   into  supp  from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select "City_Code"  into pub_cent from edition_mast where ("Edition_Code"=edi) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;
    end if;

    if(supp is null) then
        supp:='MN';
    end if;

    if(insertid1 is null or insertid1='0' or insertid1='') then
        select INSERTID.nextval into insertidval from dual;
        
        insert into tbl_booking_insert("Cio_Booking_Id","Edition","Insert_Date","Col_Code","Height","Width","Size_Book","Page_Post","Premium1","Prem_Per1","Premium2","Prem_Per2","Premium_Allow","Ad_Cat","Ad_Sub_Cat","Latest_By","Status_Material","File_Name","Card_Rate","Disc_Rate","Insert_Status","Bill_Status","Comp_Code","Userid","Repeating_Date","No_Insert","Edition_Code","Publication_Code","Pub_Cent_Code","Supp_Code","Pai_Free_Ins","Agreed_Rate","Solo_Rate","Gross_Rate","Page_No","Remarks","Page_Prem","Page_Per","No_Ofcolumn","Bill_Amt","Bill_Rate","Logo_H", "Logo_W", "Logo_name","Insert_Id","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS,BOXCHARGE,VAT_INC,VATAMT,LOCALGROSSAMT,LOCALBILLAMT, SECTIONCODE,RESOURCE_NO)
        values(cioid,edition,insertdate,colid,height,width,totalsize,pagepost,premium1,premper1,premium2,premper2,premallow,adcategory,adsubcat1,latestdate,material,matfilename,cardrate,discrate,insertstatus,billstatus,compcode,userid,repeat,insertno,edi,publi,pub_cent,supp,paid,agrrate,solorate,grossrate,insert_pageno,insert_remarks,page_code,page_per,noofcol,billamt,billrate,logo_h,logo_w,logo_name,insertidval,ad_cat_3,ad_cat_4,ad_cat_5, pkgcode,gridins,pkgalias,boxcharge_p,vat_inc_p,vatrate_p,grossamtlocal_p,billamtlocal_p,sectioncode_p,resourceno_p);
        if(cirvts is not null) then
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                    values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
        end if;            
    else
        update  tbl_booking_insert set "Edition"=edition,"Insert_Date"=insertdate,"Col_Code"=colid,"Height"=height,"Width"=width,"Size_Book"=totalsize,"Page_Post"=pagepost,"Premium1"=premium1,"Prem_Per1"=premper1,"Premium2"=premium2,"Prem_Per2"=premper2,"Premium_Allow"=premallow,"Ad_Cat"=adcategory,"Ad_Sub_Cat"=adsubcat1,"Latest_By"=latestdate,"Status_Material"=material,"File_Name"=matfilename,"Card_Rate"=cardrate,"Disc_Rate"=discrate,"Insert_Status"=insertstatus,"Bill_Status"=billstatus,"Comp_Code"=compcode,"Userid"=userid,"Repeating_Date"=repeat,"No_Insert"=insertno,"Edition_Code"=edi,"Publication_Code"=publi,"Pub_Cent_Code"=pub_cent,"Supp_Code"=supp,"Pai_Free_Ins"=paid,"Agreed_Rate"=agrrate,"Solo_Rate"=solorate,"Gross_Rate"=grossrate,"Page_No"=insert_pageno,"Remarks"=insert_remarks,"Page_Prem"=page_code,"Page_Per"=page_per,"No_Ofcolumn"=noofcol,"Bill_Amt"=billamt,"Bill_Rate"=billrate,"Logo_H"=logo_h, "Logo_W"=logo_w, "Logo_name"=logo_name,"AD_SUBCAT3"=ad_cat_3,"AD_SUBCAT4"=ad_cat_4,"AD_SUBCAT5"=ad_cat_5,PACKAGE_CODE=pkgcode,INSERTS=gridins,PKG_ALIAS=pkgalias,BOXCHARGE=boxcharge_p, VAT_INC=vat_inc_p,VATAMT=vatrate_p, LOCALGROSSAMT=grossamtlocal_p, LOCALBILLAMT=billamtlocal_p, SECTIONCODE=sectioncode_p, RESOURCE_NO=resourceno_p where "Cio_Booking_Id"=cioid AND "Insert_Id"=insertid1;
        if insertstatus = 'cancel' then
            update tbl_booking_subedition set INSERTSTATUS='cancel' where tbl_booking_subedition.cioid=cioid and insertid=insertid1;
        end if;
         begin
            select count(*) into countcir from tbl_booking_vts where CIOID=cioid and INSERTID=insertid1;
            exception when no_data_found then countcir:=0 ;
        end;
        if(countcir=0) then
        insertidval:=insertid1;
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                    values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
        else
            update tbl_booking_vts set VTS=cirvts,PUBLICATION=cirpub,EDITION=ciredi,RATE=cirrate,CIRAGCODE=ciragency_v,CIRAGSUBCODE=ciragencysubcode_v,PUBLISHDATE=cirdate_v where  CIOID=cioid and INSERTID=insertid1;
        end if;

        
    if insertstatus = 'billed' then
        begin
            select BILL_NO into billnum from tbl_booking_insert where "Cio_Booking_Id"=cioid AND "Insert_Id"=insertid1;
            exception when no_data_found then NULL ;
        end;
        if billnum is not null then
            begin
                SELECT "Executive_code",RETAINER into executive, retain from tbl_booking_mast where "cio_booking_id"=cioid;
                exception when no_data_found then  NULL;
            end; 
            if retain is not null then
                update ad_bills set  retainer_code=retain,executive_name=NULL where bilno=billnum;
            end if;
            if executive is not null then
                update ad_bills set  executive_name=executive,retainer_code=NULL where bilno=billnum;
            end if;
        end if;
    
    end if;
end if;
   END insertintobookchild_display_p;
END insertintobookchild_display;
/



CREATE OR REPLACE PACKAGE insertintobookchild_update
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  insertintobookchild_update_p (


    insertdate in date,
edition in varchar2,
premium1 in varchar2,
premium2 in varchar2,
premallow in varchar2,
adcategory in varchar2,
latestdate in date,
material in varchar2,
cardrate in number,
matfilename in varchar2,
discrate in number,
insertstatus in varchar2,
billstatus in varchar2,
adsubcat1 in varchar2,
compcode in varchar2,
userid in varchar2,
cioid in varchar2,
height in number,
width in number,
totalsize in number,
pagepost in varchar2,
premper1 in number,
premper2 in number,
colid in varchar2,
repeat in date,
insertno in int,
paid in varchar2,
agrrate in number,
solorate in number,
grossrate in number,
insert_pageno in number,
insert_remarks in varchar2,
page_code in varchar2,
page_per in number,
noofcol in number,
billamt in number,
billrate in number,
logo_h in varchar2,
logo_w in varchar2,
logo_name in varchar2,
ad_cat_3 in varchar2,
ad_cat_4 in varchar2,
ad_cat_5 in varchar2,
pkgcode in varchar2,
gridins in number,
pkgalias in varchar2,
insertid1 in varchar2,
cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date, 
ciragency_v in varchar2,
 ciragencysubcode_v in varchar2, 
 center_v in varchar2,
  branch_v in varchar2,
  splboldsizevalue VARCHAR2,
  vatrate_p float,
  boxcharge_p FLOAT,
  vat_inc_p varchar2,
  grossamtlocal_p float,
  billamtlocal_p float,
  sectioncode_p varchar2,
   resourceno_p varchar2

   );
END insertintobookchild_update;
/


CREATE OR REPLACE PACKAGE BODY insertintobookchild_update
IS
   PROCEDURE insertintobookchild_update_p (
    insertdate in date,
edition in varchar2,
premium1 in varchar2,
premium2 in varchar2,
premallow in varchar2,
adcategory in varchar2,
latestdate in date,
material in varchar2,
cardrate in number,
matfilename in varchar2,
discrate in number,
insertstatus in varchar2,
billstatus in varchar2,
adsubcat1 in varchar2,
compcode in varchar2,
userid in varchar2,
cioid in varchar2,
height in number,
width in number,
totalsize in number,
pagepost in varchar2,
premper1 in number,
premper2 in number,
colid in varchar2,
repeat in date,
insertno in int,
paid in varchar2,
agrrate in number,
solorate in number,
grossrate in number,
insert_pageno in number,
insert_remarks in varchar2,
page_code in varchar2,
page_per in number,
noofcol in number,
billamt in number,
billrate in number,
logo_h in varchar2,
logo_w in varchar2,
logo_name in varchar2,
ad_cat_3 in varchar2,
ad_cat_4 in varchar2,
ad_cat_5 in varchar2,
pkgcode in varchar2,
gridins in number,
pkgalias in varchar2,
insertid1 in varchar2,
cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date, 
ciragency_v in varchar2,
 ciragencysubcode_v in varchar2, 
 center_v in varchar2,
  branch_v in varchar2,
   splboldsizevalue VARCHAR2,
   vatrate_p float,
   boxcharge_p FLOAT,
   vat_inc_p varchar2,
    grossamtlocal_p float,
  billamtlocal_p float,
  sectioncode_p varchar2,
  resourceno_p varchar2
   )
   AS




edi  varchar2(20);
publi  varchar2(20);
pub_cent   varchar2(20);
supp  varchar2(20);
cou1  number;
id  number;
insertidval number;
countcir number;
BEGIN
begin
select count(*) into  cou1   from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

if(cou1 >0)
then
begin
select "Edition_Code" into edi from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select "Pub_Code" into publi from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select  "City_Code" into pub_cent from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

 supp:='';


else

begin

select "Edition_Code" into edi from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select"Pub_Code" into publi from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select "Supp_Code"   into  supp  from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select "City_Code"  into pub_cent from edition_mast where ("Edition_Code"=edi) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

end if;

if(supp is null)
then

 supp:='MN';

end if;

if(insertid1 is null or insertid1='0' or insertid1='') then
 select INSERTID.nextval into insertidval from dual;
insert into tbl_booking_insert("Cio_Booking_Id","Edition","Insert_Date","Col_Code","Height","Width","Size_Book","Page_Post","Premium1","Prem_Per1","Premium2","Prem_Per2","Premium_Allow","Ad_Cat","Ad_Sub_Cat","Latest_By","Status_Material","File_Name","Card_Rate","Disc_Rate","Insert_Status","Bill_Status","Comp_Code","Userid","Repeating_Date","No_Insert","Edition_Code","Publication_Code","Pub_Cent_Code","Supp_Code","Pai_Free_Ins","Agreed_Rate","Solo_Rate","Gross_Rate","Page_No","Remarks","Page_Prem","Page_Per","No_Ofcolumn","Bill_Amt","Bill_Rate","Logo_H", "Logo_W", "Logo_name","Insert_Id","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT, SECTIONCODE,RESOURCE_NO)
values(cioid,edition,insertdate,colid,height,width,totalsize,pagepost,premium1,premper1,premium2,premper2,premallow,adcategory,adsubcat1,latestdate,material,matfilename,cardrate,discrate,insertstatus,billstatus,compcode,userid,repeat,insertno,edi,publi,pub_cent,supp,paid,agrrate,solorate,grossrate,insert_pageno,insert_remarks,page_code,page_per,noofcol,billamt,billrate,logo_h,logo_w,logo_name,insertidval,ad_cat_3,ad_cat_4,ad_cat_5, pkgcode,gridins,pkgalias, splboldsizevalue,vatrate_p,boxcharge_p,vat_inc_p ,grossamtlocal_p,billamtlocal_p,sectioncode_p,resourceno_p);
 if(cirvts is not null) then
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                    values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
        end if;
else

update  tbl_booking_insert set  "Edition"=edition,"Insert_Date"=insertdate,"Col_Code"=colid,"Height"=height,"Width"=width,"Size_Book"=totalsize,"Page_Post"=pagepost,"Premium1"=premium1,"Prem_Per1"=premper1,"Premium2"=premium2,"Prem_Per2"=premper2,"Premium_Allow"=premallow,"Ad_Cat"=adcategory,"Ad_Sub_Cat"=adsubcat1,"Latest_By"=latestdate,"Status_Material"=material,"File_Name"=matfilename,"Card_Rate"=cardrate,"Disc_Rate"=discrate,"Insert_Status"=insertstatus,"Bill_Status"=billstatus,"Comp_Code"=compcode,"Userid"=userid,"Repeating_Date"=repeat,"No_Insert"=insertno,"Edition_Code"=edi,"Publication_Code"=publi,"Pub_Cent_Code"=pub_cent,"Supp_Code"=supp,"Pai_Free_Ins"=paid,"Agreed_Rate"=agrrate,"Solo_Rate"=solorate,"Gross_Rate"=grossrate,"Page_No"=insert_pageno,"Remarks"=insert_remarks,"Page_Prem"=page_code,"Page_Per"=page_per,"No_Ofcolumn"=noofcol,"Bill_Amt"=billamt,"Bill_Rate"=billrate,"Logo_H"=logo_h, "Logo_W"=logo_w, "Logo_name"=logo_name,"AD_SUBCAT3"=ad_cat_3,"AD_SUBCAT4"=ad_cat_4,"AD_SUBCAT5"=ad_cat_5,PACKAGE_CODE=pkgcode,INSERTS=gridins,PKG_ALIAS=pkgalias, SPECIAL_SIZE1= splboldsizevalue,VATAMT=vatrate_p,BOXCHARGE=boxcharge_p,VAT_INC=vat_inc_p,LOCALGROSSAMT=grossamtlocal_p,LOCALBILLAMT=billamtlocal_p,SECTIONCODE=sectioncode_p,RESOURCE_NO=resourceno_p  where "Cio_Booking_Id"=cioid and "Insert_Id" = insertid1;
if insertstatus = 'cancel' then
            update tbl_booking_subedition set INSERTSTATUS='cancel' where tbl_booking_subedition.cioid=cioid and insertid=insertid1;
        end if;
  begin
            select count(*) into countcir from tbl_booking_vts where CIOID=cioid and INSERTID=insertid1;
            exception when no_data_found then countcir:=0 ;
        end;
        if(countcir=0) then
        insertidval:=insertid1;
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                    values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
        else
            update tbl_booking_vts set VTS=cirvts,PUBLICATION=cirpub,EDITION=ciredi,RATE=cirrate,CIRAGCODE=ciragency_v,CIRAGSUBCODE=ciragencysubcode_v,PUBLISHDATE=cirdate_v where  CIOID=cioid and INSERTID=insertid1;
        end if;
end if;
   END insertintobookchild_update_p;
END insertintobookchild_update;
/

/******************************END**************************/

/*======================================= ISSUE 0005576 (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE PACKAGE bindagencyforbooking
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  bindagencyforbooking_p (
      compcode     IN       VARCHAR2,
      userid       IN       VARCHAR2,
      agency       IN       VARCHAR2,
      pubcenter     in      varchar2,
      p_accounts   OUT      t_accounts_cursor
   );
END bindagencyforbooking;
/
CREATE OR REPLACE PACKAGE BODY bindagencyforbooking
is
procedure bindagencyforbooking_p(compcode in varchar2,
userid in varchar2,agency in varchar2,
pubcenter     in      varchar2,
p_Accounts out T_Accounts_Cursor) as

begin
if pubcenter = '0' or pubcenter is null then

open p_Accounts for
select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
and "Agency_Name" like '%'||agency||'%'  order by "Agency_Name" ;

else
open p_Accounts for
select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
and "Agency_Name" like '%'||agency||'%' and "Dist_Code"=(select "Dist_Code" from branch_mst where "Branch_Code"=pubcenter) order by "Agency_Name" ;
end if;
end   bindagencyforbooking_p;

end   bindagencyforbooking;
/


/*=======================================End of ISSUE 0005576 (Kuldeep Bhati) ==============================*/

/**************************************** lata 15 NOV 2011 **************************/
CREATE OR REPLACE PACKAGE insertintobookchild_update
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  insertintobookchild_update_p (


    insertdate in date,
edition in varchar2,
premium1 in varchar2,
premium2 in varchar2,
premallow in varchar2,
adcategory in varchar2,
latestdate in date,
material in varchar2,
cardrate in number,
matfilename in varchar2,
discrate in number,
insertstatus in varchar2,
billstatus in varchar2,
adsubcat1 in varchar2,
compcode in varchar2,
userid in varchar2,
cioid in varchar2,
height in number,
width in number,
totalsize in number,
pagepost in varchar2,
premper1 in number,
premper2 in number,
colid in varchar2,
repeat in date,
insertno in int,
paid in varchar2,
agrrate in number,
solorate in number,
grossrate in number,
insert_pageno in number,
insert_remarks in varchar2,
page_code in varchar2,
page_per in number,
noofcol in number,
billamt in number,
billrate in number,
logo_h in varchar2,
logo_w in varchar2,
logo_name in varchar2,
ad_cat_3 in varchar2,
ad_cat_4 in varchar2,
ad_cat_5 in varchar2,
pkgcode in varchar2,
gridins in number,
pkgalias in varchar2,
insertid1 in varchar2,
cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date, 
ciragency_v in varchar2,
 ciragencysubcode_v in varchar2, 
 center_v in varchar2,
  branch_v in varchar2,
  splboldsizevalue VARCHAR2,
  vatrate_p float,
  boxcharge_p FLOAT,
  vat_inc_p varchar2,
  grossamtlocal_p float,
  billamtlocal_p float,
  sectioncode_p varchar2,
   resourceno_p varchar2

   );
END insertintobookchild_update;
/



CREATE OR REPLACE PACKAGE BODY insertintobookchild_update
IS
   PROCEDURE insertintobookchild_update_p (
    insertdate in date,
edition in varchar2,
premium1 in varchar2,
premium2 in varchar2,
premallow in varchar2,
adcategory in varchar2,
latestdate in date,
material in varchar2,
cardrate in number,
matfilename in varchar2,
discrate in number,
insertstatus in varchar2,
billstatus in varchar2,
adsubcat1 in varchar2,
compcode in varchar2,
userid in varchar2,
cioid in varchar2,
height in number,
width in number,
totalsize in number,
pagepost in varchar2,
premper1 in number,
premper2 in number,
colid in varchar2,
repeat in date,
insertno in int,
paid in varchar2,
agrrate in number,
solorate in number,
grossrate in number,
insert_pageno in number,
insert_remarks in varchar2,
page_code in varchar2,
page_per in number,
noofcol in number,
billamt in number,
billrate in number,
logo_h in varchar2,
logo_w in varchar2,
logo_name in varchar2,
ad_cat_3 in varchar2,
ad_cat_4 in varchar2,
ad_cat_5 in varchar2,
pkgcode in varchar2,
gridins in number,
pkgalias in varchar2,
insertid1 in varchar2,
cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date, 
ciragency_v in varchar2,
 ciragencysubcode_v in varchar2, 
 center_v in varchar2,
  branch_v in varchar2,
   splboldsizevalue VARCHAR2,
   vatrate_p float,
   boxcharge_p FLOAT,
   vat_inc_p varchar2,
    grossamtlocal_p float,
  billamtlocal_p float,
  sectioncode_p varchar2,
  resourceno_p varchar2
   )
   AS




edi  varchar2(20);
publi  varchar2(20);
pub_cent   varchar2(20);
supp  varchar2(20);
cou1  number;
id  number;
insertidval number;
countcir number;
BEGIN
begin
select count(*) into  cou1   from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

if(cou1 >0)
then
begin
select "Edition_Code" into edi from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select "Pub_Code" into publi from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select  "City_Code" into pub_cent from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

 supp:='';


else

begin

select "Edition_Code" into edi from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select"Pub_Code" into publi from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select "Supp_Code"   into  supp  from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

begin
select "City_Code"  into pub_cent from edition_mast where ("Edition_Code"=edi) and ("Comp_Code"=compcode);
exception when no_data_found then
NULL ;
end;

end if;

if(supp is null)
then

 supp:='MN';

end if;

if(insertid1 is null or insertid1='0' or insertid1='') then
 select INSERTID.nextval into insertidval from dual;
insert into tbl_booking_insert("Cio_Booking_Id","Edition","Insert_Date","Col_Code","Height","Width","Size_Book","Page_Post","Premium1","Prem_Per1","Premium2","Prem_Per2","Premium_Allow","Ad_Cat","Ad_Sub_Cat","Latest_By","Status_Material","File_Name","Card_Rate","Disc_Rate","Insert_Status","Bill_Status","Comp_Code","Userid","Repeating_Date","No_Insert","Edition_Code","Publication_Code","Pub_Cent_Code","Supp_Code","Pai_Free_Ins","Agreed_Rate","Solo_Rate","Gross_Rate","Page_No","Remarks","Page_Prem","Page_Per","No_Ofcolumn","Bill_Amt","Bill_Rate","Logo_H", "Logo_W", "Logo_name","Insert_Id","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT, SECTIONCODE,RESOURCE_NO)
values(cioid,edition,insertdate,colid,height,width,totalsize,pagepost,premium1,premper1,premium2,premper2,premallow,adcategory,adsubcat1,latestdate,material,matfilename,cardrate,discrate,insertstatus,billstatus,compcode,userid,repeat,insertno,edi,publi,pub_cent,supp,paid,agrrate,solorate,grossrate,insert_pageno,insert_remarks,page_code,page_per,noofcol,billamt,billrate,logo_h,logo_w,logo_name,insertidval,ad_cat_3,ad_cat_4,ad_cat_5, pkgcode,gridins,pkgalias, splboldsizevalue,vatrate_p,boxcharge_p,vat_inc_p ,grossamtlocal_p,billamtlocal_p,sectioncode_p,resourceno_p);
 if(cirvts is not null) then
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                    values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
        end if;
else

update  tbl_booking_insert set  "Edition"=edition,"Insert_Date"=insertdate,"Col_Code"=colid,"Height"=height,"Width"=width,"Size_Book"=totalsize,"Page_Post"=pagepost,"Premium1"=premium1,"Prem_Per1"=premper1,"Premium2"=premium2,"Prem_Per2"=premper2,"Premium_Allow"=premallow,"Ad_Cat"=adcategory,"Ad_Sub_Cat"=adsubcat1,"Latest_By"=latestdate,"Status_Material"=material,"File_Name"=matfilename,"Card_Rate"=cardrate,"Disc_Rate"=discrate,"Insert_Status"=insertstatus,"Bill_Status"=billstatus,"Comp_Code"=compcode,"Userid"=userid,"Repeating_Date"=repeat,"No_Insert"=insertno,"Edition_Code"=edi,"Publication_Code"=publi,"Pub_Cent_Code"=pub_cent,"Supp_Code"=supp,"Pai_Free_Ins"=paid,"Agreed_Rate"=agrrate,"Solo_Rate"=solorate,"Gross_Rate"=grossrate,"Page_No"=insert_pageno,"Remarks"=insert_remarks,"Page_Prem"=page_code,"Page_Per"=page_per,"No_Ofcolumn"=noofcol,"Bill_Amt"=billamt,"Bill_Rate"=billrate,"Logo_H"=logo_h, "Logo_W"=logo_w, "Logo_name"=logo_name,"AD_SUBCAT3"=ad_cat_3,"AD_SUBCAT4"=ad_cat_4,"AD_SUBCAT5"=ad_cat_5,PACKAGE_CODE=pkgcode,INSERTS=gridins,PKG_ALIAS=pkgalias, SPECIAL_SIZE1= splboldsizevalue,VATAMT=vatrate_p,BOXCHARGE=boxcharge_p,VAT_INC=vat_inc_p,LOCALGROSSAMT=grossamtlocal_p,LOCALBILLAMT=billamtlocal_p,SECTIONCODE=sectioncode_p,RESOURCE_NO=resourceno_p  where "Cio_Booking_Id"=cioid and "Insert_Id" = insertid1;
if insertstatus = 'cancel' then
            update tbl_booking_subedition set INSERTSTATUS='cancel' where tbl_booking_subedition.cioid=cioid and insertid=insertid1;
        end if;
  begin
            select count(*) into countcir from tbl_booking_vts where CIOID=cioid and INSERTID=insertid1;
            exception when no_data_found then countcir:=0 ;
        end;
        if(countcir=0) then
        insertidval:=insertid1;
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                    values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
        else
            update tbl_booking_vts set VTS=cirvts,PUBLICATION=cirpub,EDITION=ciredi,RATE=cirrate,CIRAGCODE=ciragency_v,CIRAGSUBCODE=ciragencysubcode_v,PUBLISHDATE=cirdate_v where  CIOID=cioid and INSERTID=insertid1;
        end if;
end if;
   END insertintobookchild_update_p;
END insertintobookchild_update;
/

CREATE OR REPLACE PACKAGE insertintobookchild_display
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  insertintobookchild_display_p (


    insertdate in date,
edition in varchar2,
premium1 in varchar2,
premium2 in varchar2,
premallow in varchar2,
adcategory in varchar2,
latestdate in date,
material in varchar2,
cardrate in number,
matfilename in varchar2,
discrate in number,
insertstatus in varchar2,
billstatus in varchar2,
adsubcat1 in varchar2,
compcode in varchar2,
userid in varchar2,
cioid in varchar2,
height in number,
width in number,
totalsize in number,
pagepost in varchar2,
premper1 in number,
premper2 in number,
colid in varchar2,
repeat in date,
insertno in int,
paid in varchar2,
agrrate in number,
solorate in number,
grossrate in number,
insert_pageno in number,
insert_remarks in varchar2,
page_code in varchar2,
page_per in number,
noofcol in number,
billamt in number,
billrate in number,
logo_h in varchar2,
logo_w in varchar2,
logo_name in varchar2,
ad_cat_3 in varchar2,
ad_cat_4 in varchar2,
ad_cat_5 in varchar2,
pkgcode in varchar2,
gridins in number,
pkgalias in varchar2,
insertid1 in number,
cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date, 
ciragency_v in varchar2,
 ciragencysubcode_v in varchar2, 
 center_v in varchar2,
  branch_v in varchar2,
    boxcharge_p in float,
    vat_inc_p in varchar2,
    vatrate_p in float,
    grossamtlocal_p in number,
    billamtlocal_p in number,
    sectioncode_p in varchar2,
    resourceno_p in varchar2
   );
END insertintobookchild_display;
/


CREATE OR REPLACE PACKAGE BODY insertintobookchild_display
IS
   PROCEDURE insertintobookchild_display_p (
    insertdate in date,
    edition in varchar2,
    premium1 in varchar2,
    premium2 in varchar2,
    premallow in varchar2,
    adcategory in varchar2,
    latestdate in date,
    material in varchar2,
    cardrate in number,
    matfilename in varchar2,
    discrate in number,
    insertstatus in varchar2,
    billstatus in varchar2,
    adsubcat1 in varchar2,
    compcode in varchar2,
    userid in varchar2,
    cioid in varchar2,
    height in number,
    width in number,
    totalsize in number,
    pagepost in varchar2,
    premper1 in number,
    premper2 in number,
    colid in varchar2,
    repeat in date,
    insertno in int,
    paid in varchar2,
    agrrate in number,
    solorate in number,
    grossrate in number,
    insert_pageno in number,
    insert_remarks in varchar2,
    page_code in varchar2,
    page_per in number,
    noofcol in number,
    billamt in number,
    billrate in number,
    logo_h in varchar2,
    logo_w in varchar2,
    logo_name in varchar2,
    ad_cat_3 in varchar2,
    ad_cat_4 in varchar2,
    ad_cat_5 in varchar2,
    pkgcode in varchar2,
    gridins in number,
    pkgalias in varchar2,
    insertid1 in number,
    cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date, 
ciragency_v in varchar2,
 ciragencysubcode_v in varchar2, 
 center_v in varchar2,
  branch_v in varchar2,
    boxcharge_p in float,
     vat_inc_p in varchar2,
     vatrate_p in float,
     grossamtlocal_p in number,
    billamtlocal_p in number,
    sectioncode_p in varchar2,
    resourceno_p in varchar2
    )
   
AS
    edi varchar2(50);
    publi varchar2(50);
    pub_cent varchar2(50);
    supp varchar2(50);
    cou1 number;
    id number;
    billnum varchar2(50);
    retain varchar2(50);
    executive varchar(50);    
insertidval number;
countcir number;
    BEGIN
        begin
            select count(*) into cou1 from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

    if(cou1 >0) then
        begin
            select "Edition_Code" into edi from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select "Pub_Code" into publi from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select "City_Code" into pub_cent from edition_mast where ("Edition_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        supp:='';
    else
        begin
            select "Edition_Code" into edi from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select"Pub_Code" into publi from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select "Supp_Code"   into  supp  from  supplement_mast where ("Supp_Alias"=edition) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;

        begin
            select "City_Code"  into pub_cent from edition_mast where ("Edition_Code"=edi) and ("Comp_Code"=compcode);
            exception when no_data_found then NULL ;
        end;
    end if;

    if(supp is null) then
        supp:='MN';
    end if;

    if(insertid1 is null or insertid1='0' or insertid1='') then
        select INSERTID.nextval into insertidval from dual;
        
        insert into tbl_booking_insert("Cio_Booking_Id","Edition","Insert_Date","Col_Code","Height","Width","Size_Book","Page_Post","Premium1","Prem_Per1","Premium2","Prem_Per2","Premium_Allow","Ad_Cat","Ad_Sub_Cat","Latest_By","Status_Material","File_Name","Card_Rate","Disc_Rate","Insert_Status","Bill_Status","Comp_Code","Userid","Repeating_Date","No_Insert","Edition_Code","Publication_Code","Pub_Cent_Code","Supp_Code","Pai_Free_Ins","Agreed_Rate","Solo_Rate","Gross_Rate","Page_No","Remarks","Page_Prem","Page_Per","No_Ofcolumn","Bill_Amt","Bill_Rate","Logo_H", "Logo_W", "Logo_name","Insert_Id","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS,BOXCHARGE,VAT_INC,VATAMT,LOCALGROSSAMT,LOCALBILLAMT, SECTIONCODE,RESOURCE_NO)
        values(cioid,edition,insertdate,colid,height,width,totalsize,pagepost,premium1,premper1,premium2,premper2,premallow,adcategory,adsubcat1,latestdate,material,matfilename,cardrate,discrate,insertstatus,billstatus,compcode,userid,repeat,insertno,edi,publi,pub_cent,supp,paid,agrrate,solorate,grossrate,insert_pageno,insert_remarks,page_code,page_per,noofcol,billamt,billrate,logo_h,logo_w,logo_name,insertidval,ad_cat_3,ad_cat_4,ad_cat_5, pkgcode,gridins,pkgalias,boxcharge_p,vat_inc_p,vatrate_p,grossamtlocal_p,billamtlocal_p,sectioncode_p,resourceno_p);
        if(cirvts is not null) then
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                    values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
        end if;            
    else
        update  tbl_booking_insert set "Edition"=edition,"Insert_Date"=insertdate,"Col_Code"=colid,"Height"=height,"Width"=width,"Size_Book"=totalsize,"Page_Post"=pagepost,"Premium1"=premium1,"Prem_Per1"=premper1,"Premium2"=premium2,"Prem_Per2"=premper2,"Premium_Allow"=premallow,"Ad_Cat"=adcategory,"Ad_Sub_Cat"=adsubcat1,"Latest_By"=latestdate,"Status_Material"=material,"File_Name"=matfilename,"Card_Rate"=cardrate,"Disc_Rate"=discrate,"Insert_Status"=insertstatus,"Bill_Status"=billstatus,"Comp_Code"=compcode,"Userid"=userid,"Repeating_Date"=repeat,"No_Insert"=insertno,"Edition_Code"=edi,"Publication_Code"=publi,"Pub_Cent_Code"=pub_cent,"Supp_Code"=supp,"Pai_Free_Ins"=paid,"Agreed_Rate"=agrrate,"Solo_Rate"=solorate,"Gross_Rate"=grossrate,"Page_No"=insert_pageno,"Remarks"=insert_remarks,"Page_Prem"=page_code,"Page_Per"=page_per,"No_Ofcolumn"=noofcol,"Bill_Amt"=billamt,"Bill_Rate"=billrate,"Logo_H"=logo_h, "Logo_W"=logo_w, "Logo_name"=logo_name,"AD_SUBCAT3"=ad_cat_3,"AD_SUBCAT4"=ad_cat_4,"AD_SUBCAT5"=ad_cat_5,PACKAGE_CODE=pkgcode,INSERTS=gridins,PKG_ALIAS=pkgalias,BOXCHARGE=boxcharge_p, VAT_INC=vat_inc_p,VATAMT=vatrate_p, LOCALGROSSAMT=grossamtlocal_p, LOCALBILLAMT=billamtlocal_p, SECTIONCODE=sectioncode_p, RESOURCE_NO=resourceno_p where "Cio_Booking_Id"=cioid AND "Insert_Id"=insertid1;
        if insertstatus = 'cancel' then
            update tbl_booking_subedition set INSERTSTATUS='cancel' where tbl_booking_subedition.cioid=cioid and insertid=insertid1;
        end if;
         begin
            select count(*) into countcir from tbl_booking_vts where CIOID=cioid and INSERTID=insertid1;
            exception when no_data_found then countcir:=0 ;
        end;
        if(countcir=0) then
        insertidval:=insertid1;
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                    values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
        else
            update tbl_booking_vts set VTS=cirvts,PUBLICATION=cirpub,EDITION=ciredi,RATE=cirrate,CIRAGCODE=ciragency_v,CIRAGSUBCODE=ciragencysubcode_v,PUBLISHDATE=cirdate_v where  CIOID=cioid and INSERTID=insertid1;
        end if;

        
    if insertstatus = 'billed' then
        begin
            select BILL_NO into billnum from tbl_booking_insert where "Cio_Booking_Id"=cioid AND "Insert_Id"=insertid1;
            exception when no_data_found then NULL ;
        end;
        if billnum is not null then
            begin
                SELECT "Executive_code",RETAINER into executive, retain from tbl_booking_mast where "cio_booking_id"=cioid;
                exception when no_data_found then  NULL;
            end; 
            if retain is not null then
                update ad_bills set  retainer_code=retain,executive_name=NULL where bilno=billnum;
            end if;
            if executive is not null then
                update ad_bills set  executive_name=executive,retainer_code=NULL where bilno=billnum;
            end if;
        end if;
    
    end if;
end if;
   END insertintobookchild_display_p;
END insertintobookchild_display;
/

CREATE OR REPLACE PACKAGE insertintobookchild
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  insertintobookchild_p (


    insertdate in date,
edition in varchar2,
premium1 in varchar2,
premium2 in varchar2,
premallow in varchar2,
adcategory in varchar2,
latestdate in date,
material in varchar2,
cardrate in number,
matfilename in varchar2,
discrate in number,
insertstatus in varchar2,
billstatus in varchar2,
adsubcat1 in varchar2,
compcode in varchar2,
userid in varchar2,
cioid in varchar2,
height in number,
width in number,
totalsize in number,
pagepost in varchar2,
premper1 in number,
premper2 in number,
colid in varchar2,
repeat in date,
insertno in int,
paid in varchar2,
agrrate in number,
solorate in number,
grossrate in number,
insert_pageno in number,
insert_remarks in varchar2,
page_code in varchar2,
page_per in number,
noofcol in number,
billamt in number,
billrate in number,
logo_h in varchar2,
logo_w in varchar2,
logo_name in varchar2,
ad_cat_3 in varchar2,
ad_cat_4 in varchar2,
ad_cat_5 in varchar2,
pkgcode in varchar2,
gridins in number,
pkgalias in varchar2,
cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date, 
ciragency_v in varchar2,
 ciragencysubcode_v in varchar2, 
 center_v in varchar2,
  branch_v in varchar2,
  splitdata_v in varchar2,
  subedidata in varchar2,
  splboldsizevalue IN VARCHAR2,
  vatrate_p in float,
  boxcharge_p in float,
  vat_inc_p in varchar2,
  grossamtlocal_p in varchar2,
  billamtlocal_p in varchar2,
  sectioncode_p in varchar2,
  resourceno_p in varchar2,
    p_error out varchar2

   );
END insertintobookchild;
/


CREATE OR REPLACE PACKAGE BODY insertintobookchild
IS
   PROCEDURE insertintobookchild_p (
      insertdate           IN       DATE,
      edition              IN       VARCHAR2,
      premium1             IN       VARCHAR2,
      premium2             IN       VARCHAR2,
      premallow            IN       VARCHAR2,
      adcategory           IN       VARCHAR2,
      latestdate           IN       DATE,
      material             IN       VARCHAR2,
      cardrate             IN       NUMBER,
      matfilename          IN       VARCHAR2,
      discrate             IN       NUMBER,
      insertstatus         IN       VARCHAR2,
      billstatus           IN       VARCHAR2,
      adsubcat1            IN       VARCHAR2,
      compcode             IN       VARCHAR2,
      userid               IN       VARCHAR2,
      cioid                IN       VARCHAR2,
      height               IN       NUMBER,
      width                IN       NUMBER,
      totalsize            IN       NUMBER,
      pagepost             IN       VARCHAR2,
      premper1             IN       NUMBER,
      premper2             IN       NUMBER,
      colid                IN       VARCHAR2,
      repeat               IN       DATE,
      insertno             IN       INT,
      paid                 IN       VARCHAR2,
      agrrate              IN       NUMBER,
      solorate             IN       NUMBER,
      grossrate            IN       NUMBER,
      insert_pageno        IN       NUMBER,
      insert_remarks       IN       VARCHAR2,
      page_code            IN       VARCHAR2,
      page_per             IN       NUMBER,
      noofcol              IN       NUMBER,
      billamt              IN       NUMBER,
      billrate             IN       NUMBER,
      logo_h               IN       VARCHAR2,
      logo_w               IN       VARCHAR2,
      logo_name            IN       VARCHAR2,
      ad_cat_3             IN       VARCHAR2,
      ad_cat_4             IN       VARCHAR2,
      ad_cat_5             IN       VARCHAR2,
      pkgcode              IN       VARCHAR2,
      gridins              IN       NUMBER,
      pkgalias             IN       VARCHAR2,
      cirvts               IN       VARCHAR2,
      cirpub               IN       VARCHAR2,
      ciredi               IN       VARCHAR2,
      cirrate              IN       VARCHAR2,
      cirdate_v            IN       DATE,
      ciragency_v          IN       VARCHAR2,
      ciragencysubcode_v   IN       VARCHAR2,
      center_v             IN       VARCHAR2,
      branch_v             IN       VARCHAR2,
        splitdata_v          IN       VARCHAR2,
         subedidata in varchar2,
         splboldsizevalue IN VARCHAR2,
          vatrate_p in float,
            boxcharge_p in float,
            vat_inc_p in varchar2,
            grossamtlocal_p in varchar2,
            billamtlocal_p in varchar2,
            sectioncode_p in varchar2,
              resourceno_p in varchar2,
      p_error              OUT      VARCHAR2
   )
   AS
      edi           VARCHAR2 (50);
      publi         VARCHAR2 (50);
      pub_cent      VARCHAR2 (50);
      supp          VARCHAR2 (50);
      cou1          NUMBER;
      ID            NUMBER;
      insertidval   NUMBER;
      receiptno_m varchar2(50);
      error1 varchar2(100);
   BEGIN
    BEGIN
    select Receipt_no into receiptno_m from tbl_booking_mast_g where cio_booking_id=cioid and rownum<=1;
     EXCEPTION
         WHEN NO_DATA_FOUND
         THEN
            NULL;
      END;
      BEGIN
         SELECT COUNT (*)
           INTO cou1
           FROM edition_mast
          WHERE ("Edition_Alias" = edition) AND ("Comp_Code" = compcode);
      EXCEPTION
         WHEN NO_DATA_FOUND
         THEN
            NULL;
      END;

      IF (cou1 > 0)
      THEN
         BEGIN
            SELECT "Edition_Code"
              INTO edi
              FROM edition_mast
             WHERE ("Edition_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Pub_Code"
              INTO publi
              FROM edition_mast
             WHERE ("Edition_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "City_Code"
              INTO pub_cent
              FROM edition_mast
             WHERE ("Edition_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         supp := '';
      ELSE
         BEGIN
            SELECT "Edition_Code"
              INTO edi
              FROM supplement_mast
             WHERE ("Supp_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Pub_Code"
              INTO publi
              FROM supplement_mast
             WHERE ("Supp_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Supp_Code"
              INTO supp
              FROM supplement_mast
             WHERE ("Supp_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "City_Code"
              INTO pub_cent
              FROM edition_mast
             WHERE ("Edition_Code" = edi)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;
      END IF;

      IF (supp IS NULL)
      THEN
         supp := 'MN';
      END IF;

--insertidval:=INSERTID.nextval;
      SELECT insertid.NEXTVAL
        INTO insertidval
        FROM DUAL;
        INSERT INTO tbl_booking_insert_G
                  (CIO_BOOKING_ID, EDITION, INSERT_DATE, COL_CODE,
                   HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1,
                   PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW,
                   AD_CAT, AD_SUB_CAT, LATEST_BY, STATUS_MATERIAL,
                   FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS,
                   BILL_STATUS, COMP_CODE, USERID, REPEATING_DATE,
                   NO_INSERT, EDITION_CODE, PUBLICATION_CODE,
                   PUB_CENT_CODE, SUPP_CODE, PAI_FREE_INS,
                   AGREED_RATE, SOLO_RATE, GROSS_RATE, PAGE_NO,
                   REMARKS, PAGE_PREM, PAGE_PER, NO_OFCOLUMN,
                   BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME,
                   INSERT_ID, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5,
                   PACKAGE_CODE, INSERTS, PKG_ALIAS, SESID,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO
                  )
           VALUES (cioid, edition, insertdate, colid,
                   height, width, totalsize, pagepost, premium1,
                   premper1, premium2, premper2, premallow,
                   adcategory, adsubcat1, latestdate, material,
                   matfilename, cardrate, discrate, insertstatus,
                   billstatus, compcode, userid, repeat,
                   insertno, edi, publi,
                   pub_cent, supp, paid,
                   agrrate, solorate, grossrate, insert_pageno,
                   insert_remarks, page_code, page_per, noofcol,
                   billamt, billrate, logo_h, logo_w, logo_name,
                   insertidval, ad_cat_3, ad_cat_4, ad_cat_5,
                   pkgcode, gridins, pkgalias,USERENV ('sessionid'),splboldsizevalue,vatrate_p,boxcharge_p,vat_inc_p,grossamtlocal_p,billamtlocal_p,sectioncode_p,  resourceno_p
                  );
                  insert_split_details(splitdata_v,receiptno_m,cioid,insertidval,error1);
                 INSERT INTO TEST1 VALUES(edition,'EDITION');
                 insert_edition_details(subedidata,receiptno_m,cioid,insertidval,compcode,edi,insertdate,height,width,totalsize,insertstatus,pkgcode,insertno,error1);
                 commit;
                  --insert into abctest values(edition);
/*                 
      INSERT INTO tbl_booking_insert
                  ("Cio_Booking_Id", "Edition", "Insert_Date", "Col_Code",
                   "Height", "Width", "Size_Book", "Page_Post", "Premium1",
                   "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow",
                   "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Status_Material",
                   "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status",
                   "Bill_Status", "Comp_Code", "Userid", "Repeating_Date",
                   "No_Insert", "Edition_Code", "Publication_Code",
                   "Pub_Cent_Code", "Supp_Code", "Pai_Free_Ins",
                   "Agreed_Rate", "Solo_Rate", "Gross_Rate", "Page_No",
                   "Remarks", "Page_Prem", "Page_Per", "No_Ofcolumn",
                   "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name",
                   "Insert_Id", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5",
                   package_code, inserts, pkg_alias
                  )
           VALUES (cioid, edition, insertdate, colid,
                   height, width, totalsize, pagepost, premium1,
                   premper1, premium2, premper2, premallow,
                   adcategory, adsubcat1, latestdate, material,
                   matfilename, cardrate, discrate, insertstatus,
                   billstatus, compcode, userid, repeat,
                   insertno, edi, publi,
                   pub_cent, supp, paid,
                   agrrate, solorate, grossrate, insert_pageno,
                   insert_remarks, page_code, page_per, noofcol,
                   billamt, billrate, logo_h, logo_w, logo_name,
                   insertidval, ad_cat_3, ad_cat_4, ad_cat_5,
                   pkgcode, gridins, pkgalias
                  );
*/
      IF (cirvts IS NOT NULL)
      THEN
         INSERT INTO TBL_BOOKING_VTS_g
                     (compcode, cioid, insertid, vts, publication, edition,
                      rate, ciragcode, ciragsubcode, center,
                      branch, publishdate ,SESID
                     )
              VALUES (compcode, cioid, insertidval, cirvts, cirpub, ciredi,
                      cirrate, ciragency_v, ciragencysubcode_v, center_v,
                      branch_v, cirdate_v,USERENV ('sessionid')
                     );
      END IF;
   EXCEPTION
      WHEN OTHERS
      THEN
         p_error := 'Error:' || SQLERRM;
   END insertintobookchild_p;
END insertintobookchild;
/


CREATE OR REPLACE PROCEDURE getResourceNo
(
   name_p varchar2, 
   P_Accounts   OUT   cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN P_Accounts FOR
      SELECT RESOURCE_NO AS CODE ,NAME FROM TBL_RESOURCE WHERE UPPER(NAME) LIKE UPPER(name_p)||'%';
END;
/

CREATE OR REPLACE PACKAGE getdataforexecute
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  getdataforexecute_p (


compcode in varchar2,
ciobid  in varchar2,

      p_accounts   OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor,
      p_accounts2   OUT      t_accounts_cursor,
      p_accounts3   OUT      t_accounts_cursor,
      p_accounts4   OUT      t_accounts_cursor,
      p_accounts5   OUT      t_accounts_cursor,
      p_accounts6   OUT      t_accounts_cursor,
      p_accounts7   OUT      t_accounts_cursor,
      p_accounts8   OUT      t_accounts_cursor,
      p_accounts9   out       t_accounts_cursor,
      p_accounts10   out       t_accounts_cursor,
      p_accounts11   out       t_accounts_cursor,
      p_accounts12   out       t_accounts_cursor

   );
END  getdataforexecute;
/

CREATE OR REPLACE procedure committransaction(cioid varchar2,totalcount int, p_error              OUT      VARCHAR2)
is
countnum int;
newid varchar2(100);
billpay varchar2(20);
rostatus varchar2(20);
remarks varchar2(500);
clientname varchar2(200);
begin
newid:=cioid;

select count(*) into countnum from tbl_booking_insert_g where Cio_Booking_Id=cioid;
if(countnum=totalcount) then
  p_error :='Y';
 INSERT INTO tbladid_ins(CIOID,COUNTNUM,FLAG) VALUES(newid,countnum,p_error);
 INSERT INTO TBL_BOOKING_MAST("date_time", "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by", "audit", "RO_No", "RO_Date", "Caption", "bill_status", "ro_status", "Agency_code", "Agency_address", "Client_code", "Client_address", "Agency_sub_code", "Dockit_no", "Executive_code", "Executive_zone", "Product_code", "Brand_code", "Key_no", "Bill_remarks", "Print_remark", "Package_code", "No_of_insertion", "Insertion_date", "Repeating_day", "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code", "Color_code", "Uom_code", "Page_position_code", "Page_type_code", "Page_no", "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code", "Scheme_type_code", "Currency_code", "Agrred_rate", "Agreed_amount", "Special_discount", "Space_discount", "Special_charges", "Agency_status", "Agency_type", "Agency_pay", "Agency_credit", "Total_area", "Card_rate", "Card_amount", "Discount", "Discount_per", "Bill_cycle", "Revenue_center", "Bill_pay", "Bill_height", "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc", "Agency_out", "Box_code", "Box_no", "Box_agency", "Box_client", "Box_address", "Comp_code", "Userid", "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad", "Campaign", "Bill_amount", "Page_prem", "Page_amount", "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", "Bill_area", "Special_disc_per", "Space_disc_per", "Paid_ins", "Contract_rate", "Deviation", "Variant_code", "Contract_name", "Contract_type", "Card_name", "Card_type", "Card_month", "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", "Bullet_code", "Bullet_premium", "Material_status", "Receipt_date", "prev_cioid", "prev_receipt", "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom", "SAPID", "RETAINER", "ADD_AGENCY_COMM", "AUDIT_COMMENT", "MOBILENO", "ADD_AGENCY_COMM_AMT", "RETAINER_COMM", "RETAINER_COMM_AMT", "CASH_RECIEVED", "CONT_GROSS", "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION", "CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER", "RODOCSTATUS",CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID) 
SELECT DATE_TIME, BRANCH, BOOKED_BY, CIO_BOOKING_ID, PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO, RO_DATE, CAPTION, BILL_STATUS, RO_STATUS, AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE, CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO, EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE, BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK, PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE, REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE, AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE, PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO, AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH, RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE, AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT, SPACE_DISCOUNT, SPECIAL_CHARGES, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY, AGENCY_CREDIT, TOTAL_AREA, CARD_RATE, CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE, REVENUE_CENTER, BILL_PAY, BILL_HEIGHT, BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD, TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO, BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS, COMP_CODE, USERID, CREATION_DATETIME, BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN, BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER, GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN, BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER, PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE, CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME, CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER, RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, BG_COLOR, BULLET_CODE, BULLET_PREMIUM, MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID, PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT, COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR, LOGO_UOM, SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO, ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS, CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, RODOCSTATUS,CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK, DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=cioid;

INSERT INTO TBL_BOOKING_insert("Insert_Id", "Cio_Booking_Id", "No_Insert", "Edition_Code", "Publication_Code", "Pub_Cent_Code", "Supp_Code", "Edition", "Insert_Date", "Col_Code", "Height", "Width", "Size_Book", "Page_Post", "Premium1", "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow", "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Repeating_Date", "Status_Material", "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status", "Bill_Status", "Agreed_Rate", "Pai_Free_Ins", "Solo_Rate", "Gross_Rate", "Comp_Code", "Userid", "Page_No", "Remarks", "Pub_Height", "Pub_Width", "Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5", "PACKAGE_CODE", "BILL_NO", "BILL_DATE", "INSERTS", "PKG_ALIAS", "CONT_GROSS_AMT", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER",SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT, LOCALBILLAMT,SECTIONCODE,RESOURCE_NO) 
SELECT INSERT_ID, CIO_BOOKING_ID, NO_INSERT, EDITION_CODE, PUBLICATION_CODE, PUB_CENT_CODE, SUPP_CODE, EDITION, INSERT_DATE, COL_CODE, HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1, PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW, AD_CAT, AD_SUB_CAT, LATEST_BY, REPEATING_DATE, STATUS_MATERIAL, FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS, BILL_STATUS, AGREED_RATE, PAI_FREE_INS, SOLO_RATE, GROSS_RATE, COMP_CODE, USERID, PAGE_NO, REMARKS, PUB_HEIGHT, PUB_WIDTH, PAGE_PREM, PAGE_PER, NO_OFCOLUMN, BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, PACKAGE_CODE, BILL_NO, BILL_DATE, INSERTS, PKG_ALIAS, CONT_GROSS_AMT, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, SPECIAL_SIZE1,VATAMT, BOXCHARGE, VAT_INC,LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=cioid;

INSERT INTO TBL_BOOKING_VTS(COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE) 
SELECT COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE FROM TBL_BOOKING_VTS_G WHERE  cioid=newid;

insert into tbl_booking_insert_sizesplit(CIOID, RECEIPTNO, INSERTID, INSERTDATE, HEIGHT, WIDTH, AREA, SRNO, CREATIONDATETIME)
select CIOID, RECEIPTNO, INSERTID, INSERTDATE, HEIGHT, WIDTH, AREA, SRNO, CREATIONDATETIME from tbl_booking_insert_sizesplit_g where cioid=newid;

--INSERT INTO ABCTEST VALUES(newid,counttest);
insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO, NO_INSERT)
select COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO, SRNO, NO_INSERT from tbl_booking_subedition_g
where tbl_booking_subedition_g.CIOID=newid;

insert into TBL_BOOKING_SHARING_TRANS(PUBLICATION, TYPE, SHARING, CIOID, SRNO)
select PUBLICATION, TYPE, SHARING, CIOID, SRNO from TBL_BOOKING_SHARING_TRANS_g where CIOID=cioid ;

insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID, CREATIONDATETIME)
select CIOID, INSERTID, CREATIONDATETIME from TBL_BOOKING_FMG_TRANS_G where CIOID=cioid;
 select "Bill_pay","ro_status" into billpay,rostatus from tbl_booking_mast where "cio_booking_id"=cioid;
 if billpay = 'CA0' and rostatus='1' then
 declare
    cursor c1 is
        select * from tbl_booking_mast where "cio_booking_id"=cioid;
       
   v1 c1%rowtype;
   v_error      varchar2(2000);
    v_rcptno_r      varchar2(50);
   vrecpt       varchar2(20);
   branchcode   varchar2(20);
   vrepcode     varchar2(20);
   subagencyreg varchar2(20);
   prevcioid_v varchar2(50);
   billamt_v float;
   grossamt_v float;
  v_curdate date;
 begin
 open c1;
 fetch c1 into v1;
    Begin
        select "Branch_Code" into branchcode from branch_mst where "Comp_Code"=v1."Comp_code" and "Branch_Name"=v1."branch";
    Exception When no_data_found then
        branchcode:='';
    End;
   
    Begin
        select "SUB_Agency_Code" into subagencyreg from agency_mast where "Comp_Code"=v1."Comp_code" and "code_subcode"=v1."Agency_sub_code";
    Exception When no_data_found then
        subagencyreg:='';
    End;
   vrecpt:=v1."Receipt_no";
   prevcioid_v:=v1."prev_cioid";
   if prevcioid_v is null or v1."prev_receipt" is null then
    billamt_v:=v1."Bill_amount";
    grossamt_v:=v1."Gross_amount";
    v_curdate:=to_date(sysdate);
   else
    select "Bill_amount","Gross_amount" into  billamt_v,grossamt_v from tbl_booking_mast where "cio_booking_id"=prevcioid_v;
    billamt_v:=v1."Bill_amount" - billamt_v;
     grossamt_v:=v1."Gross_amount" - grossamt_v;
     IF grossamt_v=0 OR grossamt_v IS NULL THEN
         grossamt_v:=v1."Gross_amount";
     END IF;
     v_curdate:=to_date(sysdate);
   end if;
   -- select substr(max("recptno"),1,12)||lpad(substr(max("recptno"),-6)+1,6,'0') into vrecpt from ad_rcpthdr where "unit"=branchcode and "doctype"='RCP' and
   -- "recptdt" between '1-mar-2011' and '31-mar-2011';
 
 --receiptsave_booking.receiptsave_booking_P(pcompcode,puserid , punit ,ptype , precpt , prdate , ppaymodres ,preceivedreg ,pvouno  ,pamount  ,pagency , pothercd ,
  --pchno  ,pchedate , pbank  , pnarration ,prep   , pvdate , pag_main_code ,pag_sub_code , ourbank,  cioid , execname , retainer ,
   -- prevcioid , p_error)
   begin
 SELECT "Cust_Name" into clientname FROM CUST_MAST WHERE "Cust_Code" = v1."Client_code" and "Comp_Code"=v1."Comp_code";
exception
when NO_DATA_FOUND THEN
clientname:=v1."Client_code";
END;

remarks:='RONO#'||v1."RO_No" ||' RODATE# ' || to_char(v1."RO_Date",'dd-mon-yyyy') || ' BOOKINGID# ' || v1."cio_booking_id" || ' CLIENT#' || clientname;

   receiptsave_booking.receiptsave_booking_p(v1."Comp_code",v1."Userid", v1."branch",V1.DOCTYPE,vrecpt,v_curdate,v1."Bill_pay",'','',billamt_v,v1."Agency_sub_code",grossamt_v,
    '','','',remarks,vrepcode,v1."date_time",v1."Agency_code",subagencyreg,'',v1."cio_booking_id",v1."Executive_code",v1.RETAINER,v1."prev_cioid",v_rcptno_r,v_error);
   
  update tbl_booking_mast set "Receipt_no"=v_rcptno_r,"Receipt_date"= v_curdate where "cio_booking_id"=v1."cio_booking_id";
 close c1;
 commit;
 end;
 end if;
 /*
 INSERT INTO TBL_BOOKING_MAST("date_time", "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by", "audit", "RO_No", "RO_Date", "Caption", "bill_status", "ro_status", "Agency_code", "Agency_address", "Client_code", "Client_address", "Agency_sub_code", "Dockit_no", "Executive_code", "Executive_zone", "Product_code", "Brand_code", "Key_no", "Bill_remarks", "Print_remark", "Package_code", "No_of_insertion", "Insertion_date", "Repeating_day", "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code", "Color_code", "Uom_code", "Page_position_code", "Page_type_code", "Page_no", "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code", "Scheme_type_code", "Currency_code", "Agrred_rate", "Agreed_amount", "Special_discount", "Space_discount", "Special_charges", "Agency_status", "Agency_type", "Agency_pay", "Agency_credit", "Total_area", "Card_rate", "Card_amount", "Discount", "Discount_per", "Bill_cycle", "Revenue_center", "Bill_pay", "Bill_height", "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc", "Agency_out", "Box_code", "Box_no", "Box_agency", "Box_client", "Box_address", "Comp_code", "Userid", "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad", "Campaign", "Bill_amount", "Page_prem", "Page_amount", "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", "Bill_area", "Special_disc_per", "Space_disc_per", "Paid_ins", "Contract_rate", "Deviation", "Variant_code", "Contract_name", "Contract_type", "Card_name", "Card_type", "Card_month", "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", "Bullet_code", "Bullet_premium", "Material_status", "Receipt_date", "prev_cioid", "prev_receipt", "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom", "SAPID", "RETAINER", "ADD_AGENCY_COMM", "AUDIT_COMMENT", "MOBILENO", "ADD_AGENCY_COMM_AMT", "RETAINER_COMM", "RETAINER_COMM_AMT", "CASH_RECIEVED", "CONT_GROSS", "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION", "CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER", "RODOCSTATUS") 
SELECT DATE_TIME, BRANCH, BOOKED_BY, CIO_BOOKING_ID, PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO, RO_DATE, CAPTION, BILL_STATUS, RO_STATUS, AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE, CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO, EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE, BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK, PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE, REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE, AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE, PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO, AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH, RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE, AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT, SPACE_DISCOUNT, SPECIAL_CHARGES, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY, AGENCY_CREDIT, TOTAL_AREA, CARD_RATE, CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE, REVENUE_CENTER, BILL_PAY, BILL_HEIGHT, BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD, TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO, BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS, COMP_CODE, USERID, CREATION_DATETIME, BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN, BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER, GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN, BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER, PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE, CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME, CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER, RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, BG_COLOR, BULLET_CODE, BULLET_PREMIUM, MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID, PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT, COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR, LOGO_UOM, SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO, ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS, CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, RODOCSTATUS FROM TBL_BOOKING_MAST_G WHERE SESID=USERENV ('sessionid') and CIO_BOOKING_ID=cioid;

INSERT INTO TBL_BOOKING_insert("Insert_Id", "Cio_Booking_Id", "No_Insert", "Edition_Code", "Publication_Code", "Pub_Cent_Code", "Supp_Code", "Edition", "Insert_Date", "Col_Code", "Height", "Width", "Size_Book", "Page_Post", "Premium1", "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow", "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Repeating_Date", "Status_Material", "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status", "Bill_Status", "Agreed_Rate", "Pai_Free_Ins", "Solo_Rate", "Gross_Rate", "Comp_Code", "Userid", "Page_No", "Remarks", "Pub_Height", "Pub_Width", "Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5", "PACKAGE_CODE", "BILL_NO", "BILL_DATE", "INSERTS", "PKG_ALIAS", "CONT_GROSS_AMT", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER") 
SELECT INSERT_ID, CIO_BOOKING_ID, NO_INSERT, EDITION_CODE, PUBLICATION_CODE, PUB_CENT_CODE, SUPP_CODE, EDITION, INSERT_DATE, COL_CODE, HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1, PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW, AD_CAT, AD_SUB_CAT, LATEST_BY, REPEATING_DATE, STATUS_MATERIAL, FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS, BILL_STATUS, AGREED_RATE, PAI_FREE_INS, SOLO_RATE, GROSS_RATE, COMP_CODE, USERID, PAGE_NO, REMARKS, PUB_HEIGHT, PUB_WIDTH, PAGE_PREM, PAGE_PER, NO_OFCOLUMN, BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, PACKAGE_CODE, BILL_NO, BILL_DATE, INSERTS, PKG_ALIAS, CONT_GROSS_AMT, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER FROM TBL_BOOKING_INSERT_G WHERE SESID=USERENV ('sessionid') and CIO_BOOKING_ID=cioid;

*/
else
rollback;
 p_error :='N';
--DELETE FROM TBL_BOOKING_INSERT WHERE "Cio_Booking_Id"=cioid;
--DELETE FROM TBL_BOOKING_mast WHERE "cio_booking_id"=cioid;
INSERT INTO tbladid_ins(CIOID,COUNTNUM,FLAG) VALUES(newid,countnum,p_error);
end if;
--delete from tbl_booking_mast_g where  CIO_BOOKING_ID=cioid;
--delete from tbl_booking_insert_g where  CIO_BOOKING_ID=cioid;
--delete from tbl_booking_vts_g where  cioid=newid;
end;
/


CREATE OR REPLACE PROCEDURE getResourceNo
(
   name_p varchar2, 
   P_Accounts   OUT   cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN P_Accounts FOR
      SELECT RESOURCE_NO AS CODE ,NAME FROM TBL_RESOURCE WHERE UPPER(NAME) LIKE UPPER(name_p)||'%';
END;
/


/****************************************end lata 15 NOV 2011 **************************/

/*======================================= ISSUE 0005587   (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE PROCEDURE Ro_Report
(pcompcode      in varchar2,
 pdateformat    in varchar2,
 puserid        in varchar2,
 chk_access     in varchar2,
 pfromdate      in varchar2,
 pdateto        in varchar2,
 pprint_cent    in varchar2,
 pagency        in varchar2,
 pbranch        in varchar2,
 pdistrict      in varchar2,
 ptaluka        in varchar2,
 pro_doc_status in varchar2,
 ppay_mode      in varchar2,
 pexecutive     in varchar2,
 pretainer      in varchar2,
 det_summry     in varchar2,
 age_exeret     in varchar2,
 pad_type       in varchar2,
 pad_cat        in varchar2,
 ptype          in varchar2,
 p_accounts     OUT Cur_Type_New1.cursor_type,
 p_accounts1    OUT Cur_Type_New1.cursor_type)
IS
query1      varchar2(10000);
vvar        varchar2(4000);
vvar_sum    varchar2(4000);
BEGIN
    if(age_exeret='1')then/*fot agency*/
        if(det_summry='1')then/*for detail*/
            query1:='select distinct a."cio_booking_id" as  "BOOKING_ID",b."Agency_Name" AS "AGENCY", 
            nvl((select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") ,(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER )) as "EXE_RET",
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            c."Adv_Cat_Name" as "Ad_Cat",
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT",
            min(TO_CHAR(i."Insert_Date",'''||pdateformat||''')) as "Publish_Date",a.RO_COMMENT as RO_COMMENT
            from tbl_booking_mast a ,tbl_booking_insert i ,agency_mast b,adv_cat_mast c where
            a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Agency_sub_code"=b."code_subcode"';
        else/* for summary*/
            query1:='select DISTINCT b."Agency_Name" AS "AGENCY",
            b."Dist_Code"  as "DISTRICT",
            --old version
            --a."branch" as "BRANCH",
            --new version
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
          
            SUM(DECODE(RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,agency_mast b/*,adv_cat_mast c*/
            where  
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Agency_sub_code"=b."code_subcode"';
        end if;
    else/* for  executive/retainer*/
        if(det_summry='1')then/*for detail*/
           /* query1:='select a."cio_booking_id" as  "BOOKING_ID",
            b."Agency_Name" AS "AGENCY",
            --(select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") AS "EXECUTIVE",
            --(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER ) AS "RETAINER",
            nvl((select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") ,(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER )) as "EXE_RET",
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT"
            from tbl_booking_mast a ,agency_mast b where
            a."Comp_code"='''||pcompcode||''' AND
            a."Agency_sub_code"=b."code_subcode"';*/
              if(age_exeret='2')then
            query1:='select distinct
            a."cio_booking_id" as  "BOOKING_ID",
            b."Agency_Name" AS "AGENCY",           
            EXEC_MAST."Exec_name"  as "EXE_RET",      
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            c."Adv_Cat_Name" as "Ad_Cat",            
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT",
            min(TO_CHAR(i."Insert_Date",'''||pdateformat||''')) as "Publish_Date",a.RO_COMMENT as RO_COMMENT
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,EXEC_MAST,agency_mast b ,adv_cat_mast c
            where a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Executive_code"=exec_mast."Exe_no" AND 
             a."Agency_sub_code"=b."code_subcode"';
         else
          query1:='select distinct
            a."cio_booking_id" as  "BOOKING_ID",
            b."Agency_Name" AS "AGENCY",  
             RETAINERMASTER."Retain_Name"     as "EXE_RET",
            NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
            c."Adv_Cat_Name" as "Ad_Cat",            
            "RO_No" AS "RONO",
            CASE "RODOCSTATUS"
            WHEN ''o'' THEN ''ORIGINAL''
            WHEN ''f'' THEN ''FAX''
            WHEN ''x'' THEN ''XEROX'' END AS "ROSTATUS",
            nvl(a."Bill_amount",''0'') as "BILLAMT",
            min(TO_CHAR(i."Insert_Date",'''||pdateformat||''')) as "Publish_Date",a.RO_COMMENT as RO_COMMENT
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER,agency_mast b ,adv_cat_mast c
            where a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            RETAINERMASTER."Retain_Code"=a.RETAINER AND 
             a."Agency_sub_code"=b."code_subcode"';
            end if;
        else/* for summary*/
         
         if(age_exeret='2')then
            query1:='select distinct  
             EXEC_MAST."Exec_name"  as "EXE_RET",      
             EXEC_MAST."dist_code"  as "DISTRICT",
            
             --old version
            --a."branch" as "BRANCH",
            --new version
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
             
            SUM(DECODE(a.RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(a.RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(a.RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(a.RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,EXEC_MAST ,agency_mast b /*,adv_cat_mast c*/
            where  
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Executive_code"=exec_mast."Exe_no" 
            and a."Agency_sub_code"=b."code_subcode"';
         else
          query1:='select distinct 
            
             RETAINERMASTER."Retain_Name"     as "EXE_RET",
           
             RETAINERMASTER."Dist_Code"   as "DISTRICT",
             --old version
            --a."branch" as "BRANCH",
            --new version
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
           
            SUM(DECODE(a.RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(a.RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(a.RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(a.RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER ,agency_mast b/*,adv_cat_mast c*/
            where 
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            RETAINERMASTER."Retain_Code"=a.RETAINER 
            and a."Agency_sub_code"=b."code_subcode"';
            end if;
        end if;
    end if;

    if(pfromdate is not null and pdateto is not null)then
        query1:=query1||' and a."date_time" between '''||pfromdate||''' and '''||pdateto||''' ';
    end if;
    
    if(pad_type is not null)then
        query1:=query1||' and a."Ad_type_code" = '''||pad_type||''' ';
    end if;

    if(pad_cat is not null)then
        query1:=query1||' and a."Ad_cat_code" = '''||pad_cat||''' ';
    end if;
    
    if(pagency is not null)then
        query1:=query1||' and a."Agency_code" = '''||pagency||''' ';
    end if;    
  --new version 

   if(pprint_cent is not null)then
        query1:=query1||' and a."branch" IN  (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code"  and "pub_center"='''||pprint_cent||''') ';
    end if;

    if(pbranch is not null)then
        query1:=query1||'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''||pbranch||''') ';
    end if;
    
--old version
   /* 
    if(pprint_cent is not null)then
        query1:=query1||' and a."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE a."branch"="Branch_Name" and "pub_center"='''||pprint_cent||''') ';
    end if;


    if(pbranch is not null)then
        query1:=query1||' and a."branch"='''||pbranch||'''';
    end if;
*/
    
    if(pdistrict is not null)then
        if(age_exeret='1')then
            query1:=query1||' and b."Dist_Code" = '''||pdistrict||''' ';
         elsif(age_exeret='2')then
            query1:=query1||' and (a."Executive_code" IS NOT NULL AND a."Executive_code" in(select exec_mast."Exe_no" from exec_mast  where EXEC_MAST."dist_code"='''||pdistrict||''' ) ) ';
        else
            query1:=query1||' and  (a.RETAINER IS NOT NULL AND a.RETAINER IN(SELECT RETAINERMASTER."Retain_Code" FROM RETAINERMASTER WHERE RETAINERMASTER."Dist_Code"='''||pdistrict||''')) ';
        end if;
    end if;
    if(ptaluka is not null)then
        if(age_exeret='1')then
            query1:=query1||' and b.TALUKA = '''||ptaluka||''' ';
        elsif(age_exeret='2')then
            query1:=query1||' and (a."Executive_code" IS NOT NULL AND a."Executive_code" in(select exec_mast."Exe_no" from exec_mast  where EXEC_MAST."TALUKA"='''||ptaluka||'''  ) ) ';
        else
            query1:=query1||' and (a.RETAINER IS NOT NULL AND a.RETAINER IN(SELECT RETAINERMASTER."Retain_Code" FROM RETAINERMASTER WHERE RETAINERMASTER."TALUKA"='''||ptaluka||''' )) ';
        end if;
    end if;

    if(pro_doc_status is not null)then
        query1:=query1||' and a."RODOCSTATUS" = '''||pro_doc_status||''' ';
    end if;

    if(ppay_mode is not null)then
        query1:=query1||' and a."Bill_pay" = '''||ppay_mode||''' ';
    end if;

    if(pexecutive is not null)then
        query1:=query1||' and a."Executive_code" = '''||pexecutive||''' ';
    end if;

    if(pretainer  is not null)then
        query1:=query1||' and a.RETAINER = '''||pretainer||''' ';
    end if;

--new version
  query1:=query1||' and a."branch" in(select lb.branch_code from login_branch_mast lb where  lb.user_code='''||puserid||''' and nvl(lb.user_flag,''N'')=''Y'') ' ;
--old version
   -- query1:=query1||' and a."branch" in(select branch_mst."Branch_Name" from branch_mst where branch_mst."Branch_Code" in (select lb.branch_code from login_branch_mast lb where  lb.user_code='''||puserid||''' and nvl(lb.user_flag,''N'')=''Y'')) ' ;

    if(ptype is not null)then
        if ptype='U' then
            query1:=query1||' and (i."Comp_Code"||i.bill_no||i.bill_date in(select /*+ (AD_OUTSTAND IND_OUT) */ o.comp_code||o.billno||o.billdt 
                        from ad_outstand o where o.comp_code=i."Comp_Code" and o.ag_main_code=b."Agency_Code" and 
                        o.ag_sub_code=b."SUB_Agency_Code" and o.billdt=i.bill_date and o.billno=i.bill_no 
                        group by o.comp_code,o.billno,o.billdt having sum(o.amount)>10) OR i.bill_no IS NULL ) ';
        else 
            query1:=query1||' and i."Comp_Code"||i.bill_no||i.bill_date in(select /*+ (AD_OUTSTAND IND_OUT) */ o.comp_code||o.billno||o.billdt 
                        from ad_outstand o where o.comp_code=i."Comp_Code" and o.ag_main_code=b."Agency_Code" and 
                        o.ag_sub_code=b."SUB_Agency_Code" and o.billdt=i.bill_date and o.billno=i.bill_no 
                        group by o.comp_code,o.billno,o.billdt having sum(o.amount)=0)';
        end if;                
    end if;
    
    if(det_summry!='1')then/*for summary*/
        if(age_exeret='1')then/*fot agency*/
            query1:=query1||' GROUP BY b."Agency_Name" ,b."Dist_Code"  ,a."branch"';
        elsif(age_exeret='2')then
            query1:=query1||' group by EXEC_MAST."Exec_name",EXEC_MAST."dist_code",a."branch"';
        else
            query1:=query1||' GROUP BY RETAINERMASTER."Retain_Name",RETAINERMASTER."Dist_Code",a."branch"';
        end if;
        else
        
        if(age_exeret='1')then/*fot agency*/
            query1:=query1||' GROUP BY a."cio_booking_id"  ,b."Agency_Name"   ,a."Executive_code",a.RETAINER,"Client_code",c."Adv_Cat_Name","RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT';
        elsif(age_exeret='2')then
            query1:=query1||' group by a."cio_booking_id"  ,b."Agency_Name",EXEC_MAST."Exec_name","Client_code",c."Adv_Cat_Name" ,"RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT ';
        else
            query1:=query1||' GROUP BY a."cio_booking_id"  ,b."Agency_Name",RETAINERMASTER."Retain_Name","Client_code",c."Adv_Cat_Name" ,"RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT';
        end if;
        
        
        
    end if;

  delete from searchtbl;
    insert into searchtbl values(query1);commit;


    OPEN p_accounts FOR query1;
    open p_accounts1 for
    select comp_mst."Comp_Name" from comp_mst where comp_mst."Comp_Code"=pcompcode;
END ;
/

/*=======================================End of ISSUE 0005587 (Kuldeep Bhati) ==============================*/

/*======================================= ISSUE 0005625 (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE PACKAGE GETRETAINER
IS
    TYPE t_accounts_cursor IS REF CURSOR;
    PROCEDURE GETRETAINER_p
    (
        COMPCODE1   IN  VARCHAR2,
        PUBCENTER   IN  VARCHAR2,
        center in varchar2,
        p_accounts  out t_accounts_cursor
    );
    END GETRETAINER;
/

CREATE OR REPLACE PACKAGE BODY GETRETAINER
IS
     PROCEDURE GETRETAINER_p
    (
        COMPCODE1   IN  VARCHAR2,
        PUBCENTER   IN  VARCHAR2,
         center in varchar2,
        p_accounts  out t_accounts_cursor
    )

    AS

    BEGIN
       
       -- SELECT "Retain_Name","Retain_Code" FROM RETAINERMASTER WHERE "Comp_Code"=COMPCODE1;-- AND "pubcent_code"=PUBCENTER;
       if center ='0' or center is null then
        OPEN p_accounts for
         SELECT "Retain_Name","Retain_Code" FROM RETAINERMASTER WHERE "Comp_Code"=COMPCODE1 AND "Retain_Name" LIKE  '%'|| PUBCENTER ||'%'
          and (SELECT  "Status_Name" FROM TBLSTATUS WHERE "Status_Code" =(select STATUS_NAME from ret_status_detail where
            "Retain_Code"=RETAINERMASTER."Retain_Code" and rownum <=1 AND sysdate between "FROM_DATE" and "TO_DATE"))='ACTIVE'
         ORDER BY "Retain_Name";
       else
        OPEN p_accounts for
         SELECT "Retain_Name","Retain_Code" FROM RETAINERMASTER WHERE "Comp_Code"=COMPCODE1 AND "Retain_Name" LIKE  '%'|| PUBCENTER ||'%'
        and "Dist_Code"=(select "Dist_Code" from branch_mst where "Branch_Code"=center)  and (SELECT  "Status_Name" FROM TBLSTATUS WHERE "Status_Code" =(select STATUS_NAME from ret_status_detail where
            "Retain_Code"=RETAINERMASTER."Retain_Code" and rownum <=1 AND sysdate between "FROM_DATE" and "TO_DATE"))='ACTIVE'
         ORDER BY "Retain_Name";-- AND "pubcent_code"=PUBCENTER;
       end if;
      
    END GETRETAINER_p;
END GETRETAINER;
/

/*=======================================End of ISSUE 0005625 (Kuldeep Bhati) ==============================*/


//////////////////////////issue no-5688//////////////////////////////////////////////////
CREATE OR REPLACE PROCEDURE HT18JULY.Schedulereport1
(
fromdate IN VARCHAR2,
dateto IN VARCHAR2,
compcode IN VARCHAR2,
pub_name IN VARCHAR2,
pub_cent IN VARCHAR2,
dateformat IN VARCHAR2,
descid IN VARCHAR2:=NULL,
ascdesc IN VARCHAR2:=NULL,
adtyp IN VARCHAR2,
adcatg IN VARCHAR2,
edition_name in varchar2,
drpstatus in varchar2,
supplement_name in varchar2,
packagecode in varchar2,
editiondtl in varchar2,
puserid in varchar2:=null,
chk_access in varchar2:=null,
p_accounts OUT Cur_Type_New1.cursor_type,
p_accounts1 OUT Cur_Type_New1.cursor_type,
p_accounts2 OUT Cur_Type_New1.cursor_type,
p_accounts3 out Cur_Type_New1.cursor_type,
p_accounts4  out Cur_Type_New1.cursor_type
)

IS

query1 VARCHAR2(10000);
v_gau number:=17;
v_val number(4);
vs_gau number(4);


--if(drpstatus ='cancel') then
Cursor p1 Is
select TBL_BOOKING_INSERT."Edition" as "edition",count(*) as "tot"
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,COL_MAST, UOM_MAST
WHERE TBL_BOOKING_MAST."Comp_code"=compcode AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
TBL_BOOKING_insert."Col_Code" =COL_MAST."Col_Code" AND
UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
AND TBL_BOOKING_INSERT."Insert_Date" BETWEEN fromdate AND dateto
 and (TBL_BOOKING_INSERT."Insert_Status"!=drpstatus or drpstatus is null)
AND (TBL_BOOKING_INSERT."Publication_Code"=pub_name or pub_name is null)
AND (TBL_BOOKING_INSERT."Pub_Cent_Code"=pub_cent or pub_cent is null)
AND (TBL_BOOKING_MAST."Ad_type_code"=Adtyp or Adtyp is null)
AND (tbl_booking_insert."Ad_Cat"=adcatg or adcatg is null)
AND (TBL_BOOKING_INSERT."Edition_Code"=edition_name or edition_name is null)
AND (TBL_BOOKING_insert."Supp_Code" =supplement_name or supplement_name is null)
and (packagecode in (tbl_booking_mast."Package_code") or packagecode is null)
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1)
or  (chk_access=0) )
group by TBL_BOOKING_INSERT."Edition" order by TBL_BOOKING_INSERT."Edition";

g1 p1%rowtype;

Cursor C1 Is
SELECT distinct TBL_BOOKING_INSERT."Cio_Booking_Id" AS "CIOID",TBL_BOOKING_MAST."Package_code" as package_code
,TBL_BOOKING_mast."Gross_amount" as Crate
FROM TBL_BOOKING_MAST, TBL_BOOKING_INSERT--,multipack_rep
WHERE TBL_BOOKING_MAST."Comp_code"=compcode AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
AND TBL_BOOKING_INSERT."Insert_Date" BETWEEN fromdate AND dateto
AND (TBL_BOOKING_INSERT."Publication_Code"=pub_name or pub_name is null)
AND (TBL_BOOKING_INSERT."Pub_Cent_Code"=pub_cent or pub_cent is null)
AND (TBL_BOOKING_MAST."Ad_type_code"=Adtyp or Adtyp is null)
AND (tbl_booking_insert."Ad_Cat"=adcatg or adcatg is null)
AND (TBL_BOOKING_INSERT."Edition_Code"=edition_name or edition_name is null)
AND (TBL_BOOKING_insert."Supp_Code" =supplement_name or supplement_name is null)
and (packagecode in (tbl_booking_mast."Package_code") or packagecode is null)
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1)
or  (chk_access=0) );
v1 c1%rowtype;

Cursor C2 Is
SELECT distinct "Edition" from TBL_BOOKING_INSERT where "Cio_Booking_Id"=v1.cioid;
v_edition varchar2(100);
v_edipkg varchar2(500);

BEGIN
delete temp_edi;

delete from MULTIPAGE_BREAK where sess_id=userenv('sessionid');commit;


open p1;
loop
fetch p1 into g1;
exit when p1%notfound;
--multipage_brek(packag VARCHAR2,PCOMP_CD number,bre number)
vs_gau:=multipage_brek(g1."edition", g1."tot",v_gau);
     end loop;
close p1;
commit;

--------- fetch multiple  edition  ( ad by rinki)-----------
delete from multipack_rep where sess_id=userenv('sessionid');commit;
open c1;
loop
fetch c1 into v1;
exit when c1%notfound;

    
      v_val:=multipack_report(v1.CIOID,v1.package_code,v1.Crate,'1');
    open C2;
    Loop
    fetch C2 into v_edition;
    exit when C2%notfound;
    if v_edipkg is null then
        v_edipkg :=v_edition;
    else
        v_edipkg :=v_edipkg|| ',' ||v_edition;
    end if;
    end loop;
    close C2;

    v_edition:=null;v_edipkg:=null;
end loop;
close c1;
commit;
---------------------end -------------------------------
if(packagecode is null or editiondtl='1')then
if(drpstatus ='includecancel' or drpstatus ='includehold') then


query1:='SELECT TBL_BOOKING_MAST ."cio_booking_id" AS "CIOID",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code" and tbl_booking_mast."Comp_code"=cust_mast."Comp_Code" ),"Client_code")  AS "Client",
multipack_rep.PACK  AS "Package",
COL_MAST ."Col_Alias" AS "Hue",
TBL_BOOKING_MAST."Card_rate" AS "CardRate",
NVL("Agrred_rate",TBL_BOOKING_MAST."Card_rate") AS "AgreedRate",
tbl_booking_insert."Status_Material" as "InsertStatus",
TBL_BOOKING_MAST."Caption" as "Caption",
TBL_BOOKING_MAST."Key_no" as "Key_no",
TBL_BOOKING_INSERT."Edition" as "edition",
TBL_BOOKING_MAST."RO_No" as "RO_No",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_INSERT."Premium1" and ADVPOS_PREM_MAST."comp_code"=tbl_booking_insert."Comp_Code" ) as "PagePremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=tbl_booking_insert."Page_Post" and advpos_type_mast."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "PosPremium",
round(TBL_BOOKING_insert."Size_Book",2) AS "Area",
TBL_BOOKING_MAST."Bill_remarks" AS "Spl Instruction",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''MM-DD-YY'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''DD-MM-YY'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''YY-MM-DD'') END AS "Ins.date" ,
tbl_booking_insert."Width"  AS "Width",
tbl_booking_insert."Height" AS "Depth"
,(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=tbl_booking_insert."Ad_Cat" and ADV_CAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "Adcat",
 (select ADV_SUBCAT_MAST."Adv_Subcat_Name"   FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST."Adv_Subcat_Code"=tbl_booking_insert."Ad_Sub_Cat" and ADV_SUBCAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) AS "AdSubcat",
TBL_BOOKING_INSERT."Page_No" as "Pageno",
TBL_BOOKING_MAST."Paid_ins" as "Paidins",
TBL_BOOKING_MAST."Rate_code" as ratecd,
UOM_MAST."Uom_Name"  AS "Uom",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
,TBL_BOOKING_MAST."Booking_type" AS "booktype"
,tbl_booking_mast."audit" as "audit"
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS"
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,multipack_rep,COL_MAST ,UOM_MAST
WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||'''AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
tbl_booking_mast."Comp_code"=tbl_booking_insert."Comp_Code" and
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
TBL_BOOKING_insert."Col_Code"=COL_MAST."Col_Code" AND
 UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
and  multipack_rep.CIOID=tbl_booking_mast."cio_booking_id"
and sess_id='||userenv('sessionid')||'
and "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
and (('''||drpstatus||''' =''includecancel'' and  lower("Insert_Status") !=''hold'') or ('''||drpstatus||''' =''includehold'' and lower("Insert_Status") !=''cancel''))
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') )';

else



query1:='SELECT TBL_BOOKING_MAST ."cio_booking_id" AS "CIOID",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code" and tbl_booking_mast."Comp_code"=cust_mast."Comp_Code" ),"Client_code")  AS "Client",
multipack_rep.PACK  AS "Package",
COL_MAST ."Col_Alias" AS "Hue",
TBL_BOOKING_MAST."Card_rate" AS "CardRate",
NVL("Agrred_rate",TBL_BOOKING_MAST."Card_rate") AS "AgreedRate",
tbl_booking_insert."Status_Material" as "InsertStatus",
TBL_BOOKING_MAST."Caption" as "Caption",
TBL_BOOKING_MAST."Key_no" as "Key_no",
TBL_BOOKING_INSERT."Edition" as "edition",
TBL_BOOKING_MAST."RO_No" as "RO_No",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_INSERT."Premium1" and ADVPOS_PREM_MAST."comp_code"=tbl_booking_insert."Comp_Code" ) as "PagePremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=tbl_booking_insert."Page_Post" and advpos_type_mast."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "PosPremium",
round(TBL_BOOKING_insert."Size_Book",2) AS "Area",
TBL_BOOKING_MAST."Bill_remarks" AS "Spl Instruction",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''MM-DD-YY'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''DD-MM-YY'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''YY-MM-DD'') END
 AS "Ins.date" ,
tbl_booking_insert."Width"  AS "Width",
tbl_booking_insert."Height" AS "Depth"
,(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=tbl_booking_insert."Ad_Cat" and ADV_CAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "Adcat",
 (select ADV_SUBCAT_MAST."Adv_Subcat_Name"   FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST."Adv_Subcat_Code"=tbl_booking_insert."Ad_Sub_Cat" and ADV_SUBCAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) AS "AdSubcat",
TBL_BOOKING_INSERT."Page_No" as "Pageno",
TBL_BOOKING_MAST."Paid_ins" as "Paidins",
TBL_BOOKING_MAST."Rate_code" as ratecd,
UOM_MAST."Uom_Name"  AS "Uom",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
,TBL_BOOKING_MAST."Booking_type" AS "booktype"
,tbl_booking_mast."audit" as "audit"
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS"
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,multipack_rep,COL_MAST,UOM_MAST
WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||'''AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
tbl_booking_mast."Comp_code"=tbl_booking_insert."Comp_Code" and
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
TBL_BOOKING_insert."Col_Code"=COL_MAST."Col_Code"
and  multipack_rep.CIOID=tbl_booking_mast."cio_booking_id"
and sess_id='||userenv('sessionid')||'
and lower("Insert_Status") !=''cancel''
and lower("Insert_Status") !=''hold''
and  UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
and "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null) 
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') ) ';

end if;

else
if(drpstatus ='includecancel' or drpstatus ='includehold') then

query1:='SELECT distinct TBL_BOOKING_MAST ."cio_booking_id" AS "CIOID",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code" and tbl_booking_mast."Comp_code"=cust_mast."Comp_Code" ),"Client_code")  AS "Client",
multipack_rep.PACK  AS "Package",
COL_MAST ."Col_Alias" AS "Hue",
TBL_BOOKING_MAST."Card_rate" AS "CardRate",
NVL("Agrred_rate",TBL_BOOKING_MAST."Card_rate") AS "AgreedRate",
tbl_booking_insert."Status_Material" as "InsertStatus",
TBL_BOOKING_MAST."Caption" as "Caption",
TBL_BOOKING_MAST."Key_no" as "Key_no",
TBL_BOOKING_MAST."RO_No" as "RO_No",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_INSERT."Premium1" and ADVPOS_PREM_MAST."comp_code"=tbl_booking_insert."Comp_Code" ) as "PagePremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=tbl_booking_insert."Page_Post" and advpos_type_mast."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "PosPremium",
round(TBL_BOOKING_insert."Size_Book",2) AS "Area",
TBL_BOOKING_MAST."Bill_remarks" AS "Spl Instruction",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''MM-DD-YY'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''DD-MM-YY'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''YY-MM-DD'') END AS "Ins.date" ,
tbl_booking_insert."Width"  AS "Width",
tbl_booking_insert."Height" AS "Depth"
,(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=tbl_booking_insert."Ad_Cat" and ADV_CAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "Adcat",
 (select ADV_SUBCAT_MAST."Adv_Subcat_Name"   FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST."Adv_Subcat_Code"=tbl_booking_insert."Ad_Sub_Cat" and ADV_SUBCAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) AS "AdSubcat",
TBL_BOOKING_INSERT."Page_No" as "Pageno",
TBL_BOOKING_MAST."Paid_ins" as "Paidins",
TBL_BOOKING_MAST."Rate_code" as ratecd,
UOM_MAST."Uom_Name"  AS "Uom",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
,TBL_BOOKING_MAST."Booking_type" AS "booktype"
,tbl_booking_mast."audit" as "audit"
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS"
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,multipack_rep,COL_MAST,UOM_MAST
WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||'''AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
tbl_booking_mast."Comp_code"=tbl_booking_insert."Comp_Code" and
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
TBL_BOOKING_insert."Col_Code"=COL_MAST."Col_Code" AND
 UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
and  multipack_rep.CIOID=tbl_booking_mast."cio_booking_id"
and sess_id='||userenv('sessionid')||'
and "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
and (('''||drpstatus||''' =''includecancel'' and  lower("Insert_Status") !=''hold'') or ('''||drpstatus||''' =''includehold'' and lower("Insert_Status") !=''cancel''))
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') )';

else

query1:='SELECT distinct TBL_BOOKING_MAST ."cio_booking_id" AS "CIOID",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code" and tbl_booking_mast."Comp_code"=cust_mast."Comp_Code" ),"Client_code")  AS "Client",
multipack_rep.PACK  AS "Package",
COL_MAST ."Col_Alias" AS "Hue",
TBL_BOOKING_MAST."Card_rate" AS "CardRate",
NVL("Agrred_rate",TBL_BOOKING_MAST."Card_rate") AS "AgreedRate",
tbl_booking_insert."Status_Material" as "InsertStatus",
TBL_BOOKING_MAST."Caption" as "Caption",
TBL_BOOKING_MAST."Key_no" as "Key_no",
TBL_BOOKING_MAST."RO_No" as "RO_No",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_INSERT."Premium1" and ADVPOS_PREM_MAST."comp_code"=tbl_booking_insert."Comp_Code" ) as "PagePremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=tbl_booking_insert."Page_Post" and advpos_type_mast."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "PosPremium",
round(TBL_BOOKING_insert."Size_Book",2) AS "Area",
TBL_BOOKING_MAST."Bill_remarks" AS "Spl Instruction",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''MM-DD-YY'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''DD-MM-YY'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''YY-MM-DD'') END
 AS "Ins.date" ,
tbl_booking_insert."Width"  AS "Width",
tbl_booking_insert."Height" AS "Depth"
,(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=tbl_booking_insert."Ad_Cat" and ADV_CAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) as "Adcat",
 (select ADV_SUBCAT_MAST."Adv_Subcat_Name"   FROM ADV_SUBCAT_MAST WHERE  ADV_SUBCAT_MAST."Adv_Subcat_Code"=tbl_booking_insert."Ad_Sub_Cat" and ADV_SUBCAT_MAST."Comp_Code"=tbl_booking_insert."Comp_Code" ) AS "AdSubcat",
TBL_BOOKING_INSERT."Page_No" as "Pageno",
TBL_BOOKING_MAST."Paid_ins" as "Paidins",
TBL_BOOKING_MAST."Rate_code" as ratecd,
UOM_MAST."Uom_Name"  AS "Uom",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
,TBL_BOOKING_MAST."Booking_type" AS "booktype"
,tbl_booking_mast."audit" as "audit"
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS"
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,multipack_rep,COL_MAST,UOM_MAST
WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||'''AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
tbl_booking_mast."Comp_code"=tbl_booking_insert."Comp_Code" and
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
TBL_BOOKING_insert."Col_Code"=COL_MAST."Col_Code"
and  multipack_rep.CIOID=tbl_booking_mast."cio_booking_id"
and sess_id='||userenv('sessionid')||'
and lower("Insert_Status") !=''cancel''
and lower("Insert_Status") !=''hold''
and  UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"
and "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') )';

end if;
end if;


IF(fromdate IS NOT NULL AND dateto IS NOT NULL )
THEN

query1:=query1||' AND TBL_BOOKING_INSERT."Insert_Date" BETWEEN '''||fromdate||''' AND '''||dateto||''' ';
END IF;


IF(pub_name IS NOT NULL )
THEN
query1:=query1||' AND TBL_BOOKING_INSERT."Publication_Code"='''||pub_name||'''';

END IF;


IF(pub_cent IS NOT NULL)
THEN
query1:=query1||'  AND TBL_BOOKING_INSERT."Pub_Cent_Code"='''||pub_cent||'''';

END IF;


IF(adtyp IS NOT NULL)
THEN
query1:=query1|| ' AND TBL_BOOKING_MAST."Ad_type_code"='''||Adtyp||''' ';

END IF;

IF(adcatg IS NOT NULL)
THEN
query1:=query1|| ' AND tbl_booking_insert."Ad_Cat" in ('''||adcatg||''' )';

END IF;

IF(edition_name IS NOT NULL )
THEN
query1:=query1||'  AND TBL_BOOKING_INSERT."Edition_Code"='''||edition_name||'''';

END IF;

IF(supplement_name IS NOT NULL )
THEN
query1:=query1||' AND (TBL_BOOKING_insert."Supp_Code" ='''||supplement_name||''' )';

END IF;

IF(packagecode IS NOT NULL )
THEN
query1:=query1||' AND ('''||packagecode||''' in (tbl_booking_mast."Package_code") )';

END IF;

if(packagecode is null)then

IF(descid IS NOT  NULL)
THEN
query1:=query1||'  order by "'||descid||'",TBL_BOOKING_INSERT."Edition"';
query1:=query1||''||ascdesc||'';
else
query1:=query1||' order by TBL_BOOKING_INSERT."Edition",TBL_BOOKING_MAST ."cio_booking_id"';
END IF;

else
IF(descid IS NOT  NULL)
THEN
query1:=query1||'  order by "'||descid||'"';
query1:=query1||''||ascdesc||'';
else
query1:=query1||' order by TBL_BOOKING_MAST ."cio_booking_id"';
END IF;
end if;
delete from searchtbl;
insert into searchtbl values(query1);
commit;
OPEN p_accounts FOR
query1;



OPEN p_accounts1 FOR
select "Edition_Alias"  as "Editions"  from edition_mast where ("Pub_Code"=pub_name or pub_name is null)  and "Edition_Type"='Main Edition';

OPEN p_accounts2 FOR
select sysdate from dual;
/*SELECT 
CASE dateformat
WHEN 'mm/dd/yyyy' THEN TO_CHAR("Insert_Date",'MM-DD-YY')
WHEN 'dd/mm/yyyy' THEN TO_CHAR("Insert_Date",'DD-MM-YY')
WHEN 'yyyy/mm/dd' THEN TO_CHAR("Insert_Date",'YY-MM-DD') END as "Insdate"
,TBL_BOOKING_INSERT."Edition" from TBL_BOOKING_INSERT
where  TBL_BOOKING_INSERT."Edition"
in (select "Edition_Alias"  as "Editions"
from edition_mast where ("Pub_Code"=pub_name or pub_name is null));*/


OPEN p_accounts3 FOR
select PACK, TOT from  MULTIPAGE_BREAK where  sess_id=userenv('sessionid') order by PACK,TOT desc;

OPEN  p_accounts4 FOR
SELECT SYSDATE,initcap("Comp_Name") from comp_mst where "Comp_Code"=compcode;

delete from multipack_rep where sess_id=userenv('sessionid')  ;
delete from multipack_rat where sess_id=userenv('sessionid') ;
DELETE FROM multipack_ratnew where sess_id=userenv('sessionid')  ; 
DELETE FROM MULTIPAGE_BREAK where sess_id=userenv('sessionid')  ;commit;
END ;
/

///////////////////////////////end of issue///////////////////////////////////////////////////////

/*********************** Kuldeep  22/11/2011  *******************/
CREATE OR REPLACE PACKAGE bindcurrmast Is
Type T_Accounts_Cursor Is Ref Cursor;
Procedure  bindcurrmast_P(
code in varchar2,
compcode in varchar2,
userid in varchar2,
date1 in varchar2,
P_Accounts Out T_Accounts_Cursor);
End bindcurrmast ;
/

CREATE OR REPLACE PACKAGE BODY bindcurrmast Is
Procedure  bindcurrmast_P(
code in varchar2,
compcode in varchar2,
userid in varchar2,
date1 in varchar2,
P_Accounts Out T_Accounts_Cursor)as
begin
if(date1='mm/dd/yyyy') then
open P_Accounts for
select "Convert_code","Conv_Rate",to_char("Valid_From_Date",'mm/dd/yyyy') as "Valid_From_Date",to_char("Valid_Till_Date",'mm/dd/yyyy') as "Valid_Till_Date",CONV_CURRENCY from CURR_CONV_DET where "Curr_Code"=code and "Comp_code"=compcode;-- and "UserId"=userid;
end if;

if(date1='dd/mm/yyyy') then
open P_Accounts for
select "Convert_code","Conv_Rate",to_char("Valid_From_Date",'dd/mm/yyyy') as "Valid_From_Date",to_char("Valid_Till_Date",'dd/mm/yyyy') as "Valid_Till_Date",CONV_CURRENCY from CURR_CONV_DET where "Curr_Code"=code and "Comp_code"=compcode;-- and "UserId"=userid;
end if;

if(date1='yyyy/mm/dd') then
open P_Accounts for
select "Convert_code","Conv_Rate",to_char("Valid_From_Date",'yyyy/mm/dd') as "Valid_From_Date",to_char("Valid_Till_Date",'yyyy/mm/dd') as "Valid_Till_Date",CONV_CURRENCY from CURR_CONV_DET where "Curr_Code"=code and "Comp_code"=compcode;-- and "UserId"=userid;
end if;

if(date1=null) then
open P_Accounts for
select "Convert_code","Conv_Rate",to_char("Valid_From_Date",'mm/dd/yyyy') as "Valid_From_Date",to_char("Valid_Till_Date",'mm/dd/yyyy') as "Valid_Till_Date",CONV_CURRENCY from CURR_CONV_DET where "Curr_Code"=code and "Comp_code"=compcode;-- and "UserId"=userid;
end if;
end bindcurrmast_P;
End bindcurrmast ;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

CREATE OR REPLACE PACKAGE selectfromcurrmast is
type T_ACCOUNT_CURSOR is ref cursor;
procedure   selectfromcurrmast_p(compcode in varchar2,
 userid in varchar2,
 currcode in varchar2,
 code10 in varchar2,P_ACCOUNT out T_ACCOUNT_CURSOR
);
end  selectfromcurrmast;
/
CREATE OR REPLACE PACKAGE BODY selectfromcurrmast is
procedure   selectfromcurrmast_p(compcode in varchar2,
 userid in varchar2,
 currcode in varchar2,
 code10 in varchar2,P_ACCOUNT out T_ACCOUNT_CURSOR)as
begin
open P_ACCOUNT for
select "Conv_Rate","Valid_From_Date","Valid_Till_Date",CONV_CURRENCY from CURR_CONV_DET where "Comp_code"=compcode  and "Curr_Code"=currcode and "Convert_code"=code10;--and "UserId"=userid 

end   selectfromcurrmast_p;
end  selectfromcurrmast;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE updateconvertrate is

procedure  updateconvertrate_p(compcode in varchar2,
 userid in varchar2,
 txtconrate in varchar2,
 txtfromdate in date,
 txtefftill in date,
 currcode in varchar2,
 code10 in varchar2,
currency in varchar2
);
end  updateconvertrate;
/
CREATE OR REPLACE PACKAGE BODY HT18JULY.updateconvertrate is
procedure   updateconvertrate_p(compcode in varchar2,
 userid in varchar2,
 txtconrate in varchar2,
 txtfromdate in date,
 txtefftill in date,
 currcode in varchar2,
 code10 in varchar2,
 currency in varchar2)as
begin

update  CURR_CONV_DET set "Valid_From_Date"=txtfromdate,"Valid_Till_Date"=txtefftill,"Conv_Rate"=txtconrate,CONV_CURRENCY=currency where "Comp_code"=compcode /*and "UserId"=userid */ and "Curr_Code"=currcode and "Convert_code"=code10;
commit;
end   updateconvertrate_p;
end  updateconvertrate;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE insertconvertrate is
procedure   insertconvertrate_p(compcode in varchar2,
  userid in varchar2,
  txtconrate in varchar2,
  txtfromdate in date,
  txtefftill in date,
  currcode in varchar2,
  currency in varchar2
);
end  insertconvertrate;
/
CREATE OR REPLACE PACKAGE BODY insertconvertrate is
procedure   insertconvertrate_p(compcode in varchar2,
  userid in varchar2,
  txtconrate in varchar2,
  txtfromdate in date,
  txtefftill in date,
  currcode in varchar2,
  currency in varchar2)as
begin

insert into CURR_CONV_DET("Convert_code", "Conv_Rate","Valid_From_Date","Valid_Till_Date","UserId","Comp_code","Curr_Code","Creation_Datetime",CONV_CURRENCY )values(CONVERT_CODE.nextval,txtconrate,txtfromdate,txtefftill,userid,compcode,currcode,sysdate,currency);
commit;
end   insertconvertrate_p;
end   insertconvertrate;
/

/*********************** Kuldeep  22/11/2011  *******************/

/*********************** Lata  22/11/2011  *******************/

CREATE OR REPLACE PACKAGE Insertintobooking
IS
   PROCEDURE  insertintobooking_P (
	date_time IN DATE,
	adsizetype IN VARCHAR2,
	branch IN VARCHAR2,
	booked_by IN VARCHAR2,
	prevbook IN VARCHAR2,
	approvedby IN VARCHAR2,
	ciobookid IN VARCHAR2,
	audit1 IN VARCHAR2,
	rono IN VARCHAR2,
	rodate IN DATE,
	caption IN VARCHAR2,
	billstatus IN VARCHAR2,
	rostatus IN VARCHAR2,
	agency IN VARCHAR2,
	client IN VARCHAR2,
	agencyaddress IN VARCHAR2,
	clientaddresses IN VARCHAR2,
	agencycode IN VARCHAR2,
	dockitno IN VARCHAR2,
	execname IN VARCHAR2,
	execzone IN VARCHAR2,
	product IN VARCHAR2,
	brand IN VARCHAR2,
	keyno IN VARCHAR2,
	billremark IN VARCHAR2,
	printremark IN VARCHAR2,
	PACKAGE1 IN VARCHAR2,
	insertion IN NUMBER,
	startdate IN DATE,
	repeatdate IN VARCHAR2,
	adtype1 IN VARCHAR2,
	Adcategory IN VARCHAR2,
	subcategory IN VARCHAR2,
	color IN VARCHAR2,
	uom IN VARCHAR2,
	pageposition IN VARCHAR2,
	pagetype1 IN VARCHAR2,
	pageno IN NUMBER,
	adsizheight IN NUMBER,
	adsizwidth IN NUMBER,
	scheme1 IN VARCHAR2,
	currency IN VARCHAR2,
	ratecode11 IN VARCHAR2,
	agreedrate IN NUMBER,
	agreedamt IN NUMBER,
	spedisc IN NUMBER,
	compcode IN VARCHAR2,
	spacedisx IN NUMBER,
	specialcharges IN NUMBER,
	userid IN VARCHAR2,
	agencytype IN VARCHAR2,
	agencystatus IN VARCHAR2,
	paymode IN VARCHAR2,
	agenccredit IN NUMBER,
	cardrate IN NUMBER,
	cardamount IN NUMBER,
	discount IN NUMBER,
	discountper IN NUMBER,
	billaddress IN VARCHAR2,
	totarea IN NUMBER,
	billcycle IN VARCHAR2,
	billpay IN VARCHAR2,
	revenuecenter IN VARCHAR2,
	billheight IN NUMBER,
	billwidth IN NUMBER,
	billto IN VARCHAR2,
	invoices IN NUMBER,
	vts IN NUMBER,
	tradedisc IN NUMBER,
	agencyout IN VARCHAR2,
	boxcode IN VARCHAR2,
	boxno IN VARCHAR2,
	boxagency IN VARCHAR2,
	boxaddress IN VARCHAR2,
	boxclient IN VARCHAR2,
	coupan IN VARCHAR2,
	bookingtype IN VARCHAR2,
	tfn IN VARCHAR2,
	campaign IN VARCHAR2,
	bill_amt IN NUMBER,
	pageprem IN VARCHAR2,
	pageamt IN NUMBER,
	premper IN NUMBER,
	grossamt IN NUMBER,
	adsizcolumn IN NUMBER,
	billcolumn IN NUMBER,
	specdiscper IN NUMBER,
	spacediscper IN NUMBER,
	billarea IN NUMBER,
	paidins IN NUMBER,
	dealrate IN NUMBER,
	deviation IN NUMBER,
	varient IN VARCHAR2,
	contractname IN VARCHAR2,
	dealtype IN VARCHAR2,
	cardname IN VARCHAR2,
	cardtype IN VARCHAR2,
	cardmonth IN VARCHAR2,
	cardyear IN VARCHAR2,
	cardno IN VARCHAR2,
	receiptno IN VARCHAR2,
	adscat3 IN VARCHAR2,
	adscat4 IN VARCHAR2,
	adscat5 IN VARCHAR2,
	bgcolor IN VARCHAR2,
	bulletcode IN VARCHAR2,
	bulletprm IN NUMBER,
	material IN VARCHAR2,
	receiptdate IN DATE:=NULL,
	prevcioid IN VARCHAR2:=NULL,
	prevreceipt IN VARCHAR2:=NULL,
	prev_ga IN NUMBER:=NULL,
	varient_name IN VARCHAR2:=NULL,
	region1 IN VARCHAR2:=NULL,
	coltype IN VARCHAR2,
	logo_h IN VARCHAR2,
	logo_w IN VARCHAR2,
	logo_col IN VARCHAR2,
	logo_uom IN VARCHAR2,
	retainer1 IN VARCHAR2,
	addagencyrate IN VARCHAR2,
    mobileno    in varchar2,
    addlamt in varchar2,
retamt in varchar2,
retper in varchar2,
cashrecieved in number,
CIRAGENCY_V in varchar2,
CIRRATE_V in varchar2,
CIREDITION_V in varchar2,
CIRPUBLICATION_V in varchar2,
CIRAGENCYSUBCODE_V in varchar2,
BARTERTYPE IN VARCHAR2,
CASHDISCOUNT_V IN VARCHAR2,
CASHDISCOUNTPER_V IN VARCHAR2,
attach1 in varchar2,
attach2 in varchar2,
drpdiscprem in varchar2,
doctype_v in varchar2,
CHKTRADE IN VARCHAR2,
sharepub_p in varchar2,
fmginsert in varchar2,
chkno in VARCHAR2,
chkdate in date:=null,
chkamt in VARCHAR2,
chkbankname in varchar2,
ourbank	in varchar2,
DEALERPANEL_P in VARCHAR2,
DEALERH_P in FLOAT,
DEALERW_P in FLOAT,
DEALERTYPE_P in VARCHAR2,
multiselect in VARCHAR2,
AGREEDRATE_ACTIVE NUMBER,
AGREEDAMT_ACTIVE NUMBER,
grossamtlocal_p number,
billamtlocal_p number,
chkadon_p varchar2,
refid_p varchar2,
rcpt_currency varchar2,
cur_convrate varchar2,
p_error out varchar2
   );
END Insertintobooking;
/

CREATE OR REPLACE PACKAGE BODY insertintobooking
IS
   PROCEDURE insertintobooking_p (
      date_time            IN       DATE,
      adsizetype           IN       VARCHAR2,
      branch               IN       VARCHAR2,
      booked_by            IN       VARCHAR2,
      prevbook             IN       VARCHAR2,
      approvedby           IN       VARCHAR2,
      ciobookid            IN       VARCHAR2,
      audit1               IN       VARCHAR2,
      rono                 IN       VARCHAR2,
      rodate               IN       DATE,
      caption              IN       VARCHAR2,
      billstatus           IN       VARCHAR2,
      rostatus             IN       VARCHAR2,
      agency               IN       VARCHAR2,
      client               IN       VARCHAR2,
      agencyaddress        IN       VARCHAR2,
      clientaddresses      IN       VARCHAR2,
      agencycode           IN       VARCHAR2,
      dockitno             IN       VARCHAR2,
      execname             IN       VARCHAR2,
      execzone             IN       VARCHAR2,
      product              IN       VARCHAR2,
      brand                IN       VARCHAR2,
      keyno                IN       VARCHAR2,
      billremark           IN       VARCHAR2,
      printremark          IN       VARCHAR2,
      package1             IN       VARCHAR2,
      insertion            IN       NUMBER,
      startdate            IN       DATE,
      repeatdate           IN       VARCHAR2,
      adtype1              IN       VARCHAR2,
      adcategory           IN       VARCHAR2,
      subcategory          IN       VARCHAR2,
      color                IN       VARCHAR2,
      uom                  IN       VARCHAR2,
      pageposition         IN       VARCHAR2,
      pagetype1            IN       VARCHAR2,
      pageno               IN       NUMBER,
      adsizheight          IN       NUMBER,
      adsizwidth           IN       NUMBER,
      scheme1              IN       VARCHAR2,
      currency             IN       VARCHAR2,
      ratecode11           IN       VARCHAR2,
      agreedrate           IN       NUMBER,
      agreedamt            IN       NUMBER,
      spedisc              IN       NUMBER,
      compcode             IN       VARCHAR2,
      spacedisx            IN       NUMBER,
      specialcharges       IN       NUMBER,
      userid               IN       VARCHAR2,
      agencytype           IN       VARCHAR2,
      agencystatus         IN       VARCHAR2,
      paymode              IN       VARCHAR2,
      agenccredit          IN       NUMBER,
      cardrate             IN       NUMBER,
      cardamount           IN       NUMBER,
      discount             IN       NUMBER,
      discountper          IN       NUMBER,
      billaddress          IN       VARCHAR2,
      totarea              IN       NUMBER,
      billcycle            IN       VARCHAR2,
      billpay              IN       VARCHAR2,
      revenuecenter        IN       VARCHAR2,
      billheight           IN       NUMBER,
      billwidth            IN       NUMBER,
      billto               IN       VARCHAR2,
      invoices             IN       NUMBER,
      vts                  IN       NUMBER,
      tradedisc            IN       NUMBER,
      agencyout            IN       VARCHAR2,
      boxcode              IN       VARCHAR2,
      boxno                IN       VARCHAR2,
      boxagency            IN       VARCHAR2,
      boxaddress           IN       VARCHAR2,
      boxclient            IN       VARCHAR2,
      coupan               IN       VARCHAR2,
      bookingtype          IN       VARCHAR2,
      tfn                  IN       VARCHAR2,
      campaign             IN       VARCHAR2,
      bill_amt             IN       NUMBER,
      pageprem             IN       VARCHAR2,
      pageamt              IN       NUMBER,
      premper              IN       NUMBER,
      grossamt             IN       NUMBER,
      adsizcolumn          IN       NUMBER,
      billcolumn           IN       NUMBER,
      specdiscper          IN       NUMBER,
      spacediscper         IN       NUMBER,
      billarea             IN       NUMBER,
      paidins              IN       NUMBER,
      dealrate             IN       NUMBER,
      deviation            IN       NUMBER,
      varient              IN       VARCHAR2,
      contractname         IN       VARCHAR2,
      dealtype             IN       VARCHAR2,
      cardname             IN       VARCHAR2,
      cardtype             IN       VARCHAR2,
      cardmonth            IN       VARCHAR2,
      cardyear             IN       VARCHAR2,
      cardno               IN       VARCHAR2,
      receiptno            IN       VARCHAR2,
      adscat3              IN       VARCHAR2,
      adscat4              IN       VARCHAR2,
      adscat5              IN       VARCHAR2,
      bgcolor              IN       VARCHAR2,
      bulletcode           IN       VARCHAR2,
      bulletprm            IN       NUMBER,
      material             IN       VARCHAR2,
      receiptdate          IN       DATE := NULL,
      prevcioid            IN       VARCHAR2 := NULL,
      prevreceipt          IN       VARCHAR2 := NULL,
      prev_ga              IN       NUMBER := NULL,
      varient_name         IN       VARCHAR2 := NULL,
      region1              IN       VARCHAR2 := NULL,
      coltype              IN       VARCHAR2,
      logo_h               IN       VARCHAR2,
      logo_w               IN       VARCHAR2,
      logo_col             IN       VARCHAR2,
      logo_uom             IN       VARCHAR2,
      retainer1            IN       VARCHAR2,
      addagencyrate        IN       VARCHAR2,
      mobileno             IN       VARCHAR2,
      addlamt              IN       VARCHAR2,
      retamt               IN       VARCHAR2,
      retper               IN       VARCHAR2,
      cashrecieved         IN       NUMBER,
      ciragency_v          IN       VARCHAR2,
      cirrate_v            IN       VARCHAR2,
      ciredition_v         IN       VARCHAR2,
      cirpublication_v     IN       VARCHAR2,
      ciragencysubcode_v   IN       VARCHAR2,
      bartertype           IN       VARCHAR2,
      CASHDISCOUNT_V IN VARCHAR2,
CASHDISCOUNTPER_V IN VARCHAR2,
attach1 in varchar2,
attach2 in varchar2,
drpdiscprem in varchar2,
doctype_v in varchar2,
CHKTRADE IN VARCHAR2,
sharepub_p in varchar2,
fmginsert in varchar2,
chkno in VARCHAR2,
chkdate in date:=null,
chkamt in VARCHAR2,
chkbankname in varchar2,
ourbank    in varchar2,
DEALERPANEL_P in VARCHAR2,
DEALERH_P in FLOAT,
DEALERW_P in FLOAT,
DEALERTYPE_P in VARCHAR2,
multiselect in VARCHAR2,
AGREEDRATE_ACTIVE NUMBER,
AGREEDAMT_ACTIVE NUMBER,
grossamtlocal_p number,
billamtlocal_p number,
chkadon_p varchar2,
refid_p varchar2,
rcpt_currency varchar2,
cur_convrate varchar2,
      p_error              OUT      VARCHAR2
   )
   AS
      sccode   VARCHAR2 (50);
      agencytype1 varchar2(20);
       error1 varchar2(100);
       rate_auth varchar2(2);
       bk_audit varchar2(2);
       auditn varchar2(50);
       username_v varchar2(50);
       roleid_v varchar2(20);
       RELAUTHREQ varchar2(1);
   BEGIN
   agencytype1:=agencytype;
   if agencytype is null then
    select "Agency_Type_Code" into agencytype1 from agency_mast where "code_subcode"=agencycode;
   end if;
   select RATE_AUTHORIZATION,"audit",RELAUTHREQON into rate_auth,bk_audit,RELAUTHREQ from preferrences where "comp_code"=compcode;
      -- BEGIN
           --SELECT distinct "scheme_id" INTO sccode FROM SCHEME_MASTER WHERE "Scheme_Name"=LTRIM(RTRIM(scheme1)) AND ("Comp_code"=compcode);
          -- EXCEPTION WHEN NO_DATA_FOUND THEN NULL ;
      -- END;
     select "username",ROLEID into username_v,roleid_v from login where "userid"=userid;   
    if roleid_v!='SE0' AND RELAUTHREQ != 'A' then 
        IF RELAUTHREQ = 'D' THEN
            if rate_auth='Y' and bk_audit='y' and agreedamt is null then
               
                auditn:=username_v;
            else
                auditn:=audit1;    
            end if;
        ELSE
        
            auditn:=username_v;    
        END IF;    
    else
     auditn:=audit1; 
    end if;    
      sccode := scheme1;
  
     
      /*INSERT INTO tbl_booking_mast
                  ("date_time", "branch", "booked_by", "cio_booking_id",
                   "prev_booking", "applied_by", "audit", "RO_No",
                   "RO_Date", "Caption", "bill_status", "ro_status",
                   "Agency_code", "Agency_address", "Client_code",
                   "Client_address", "Agency_sub_code", "Dockit_no",
                   "Executive_code", "Executive_zone", "Product_code",
                   "Brand_code", "Key_no", "Bill_remarks", "Print_remark",
                   "Package_code", "No_of_insertion", "Insertion_date",
                   "Repeating_day", "Ad_type_code", "Ad_cat_code",
                   "Ad_sub_cat_code", "Color_code", "Uom_code",
                   "Page_position_code", "Page_type_code", "Page_no",
                   "Ad_size_type_code", "Ad_size_height", "Ad_size_width",
                   "Rate_code", "Scheme_type_code", "Currency_code",
                   "Agrred_rate", "Agreed_amount", "Special_discount",
                   "Space_discount", "Special_charges", "Comp_code",
                   "Userid", "Agency_status", "Agency_type", "Agency_pay",
                   "Agency_credit", "Total_area", "Card_rate",
                   "Card_amount", "Discount", "Discount_per", "Bill_cycle",
                   "Revenue_center", "Bill_pay", "Bill_height",
                   "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add",
                   "Trade_disc", "Agency_out", "Box_code", "Box_no",
                   "Box_agency", "Box_client", "Box_address",
                   "Booking_type", "Tfn", "Coupan_ad", "Campaign",
                   "Bill_amount", "Page_prem", "Page_amount", "Prem_per",
                   "Gross_amount", "Ad_size_column", "Bill_column",
                   "Bill_area", "Special_disc_per", "Space_disc_per",
                   "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                   "Contract_name", "Contract_type", "Card_name",
                   "Card_type", "Card_month", "Card_year", "Card_number",
                   "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5",
                   "Bg_color", "Bullet_code", "Bullet_premium",
                   "Material_status", "Receipt_date", "prev_cioid",
                   "prev_receipt", "prev_grossamt", "Region", "Variant",
                   "Colortype", "Logo_H", "Logo_W", "Logo_color",
                   "Logo_Uom", "Creation_datetime", "RETAINER",
                   "ADD_AGENCY_COMM", mobileno, add_agency_comm_amt,
                   retainer_comm, retainer_comm_amt, cash_recieved,
                   ciragency, cirrate, ciredition, cirpublication,
                   ciragency_subcode, barter_type
                  )
           VALUES (date_time, branch, booked_by, ciobookid,
                   prevbook, approvedby, audit1, rono,
                   rodate, caption, billstatus, rostatus,
                   agency, agencyaddress, client,
                   clientaddresses, agencycode, dockitno,
                   execname, execzone, product,
                   brand, keyno, billremark, printremark,
                   package1, insertion, startdate,
                   repeatdate, adtype1, adcategory,
                   subcategory, color, uom,
                   pageposition, pagetype1, pageno,
                   adsizetype, adsizheight, adsizwidth,
                   ratecode11, sccode, currency,
                   agreedrate, agreedamt, spedisc,
                   spacedisx, specialcharges, compcode,
                   userid, agencystatus, agencytype, paymode,
                   agenccredit, totarea, cardrate,
                   cardamount, discount, discountper, billcycle,
                   revenuecenter, billpay, billheight,
                   billwidth, billto, invoices, vts, billaddress,
                   tradedisc, agencyout, boxcode, boxno,
                   boxagency, boxclient, boxaddress,
                   bookingtype, tfn, coupan, campaign,
                   bill_amt, pageprem, pageamt, premper,
                   grossamt, adsizcolumn, billcolumn,
                   billarea, specdiscper, spacediscper,
                   paidins, dealrate, deviation, varient,
                   contractname, dealtype, cardname,
                   cardtype, cardmonth, cardyear, cardno,
                   receiptno, adscat3, adscat4, adscat5,
                   bgcolor, bulletcode, bulletprm,
                   material, receiptdate, prevcioid,
                   prevreceipt, prev_ga, region1, varient_name,
                   coltype, logo_h, logo_w, logo_col,
                   logo_uom, SYSDATE, retainer1,
                   addagencyrate, mobileno, addlamt,
                   retper, retamt, cashrecieved,
                   ciragency_v, cirrate_v, ciredition_v, cirpublication_v,
                   ciragencysubcode_v, bartertype
                  );
                  */
                  INSERT INTO tbl_booking_mast_g
                  (DATE_TIME, BRANCH, BOOKED_BY, CIO_BOOKING_ID,
                   PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO,
                   RO_DATE, CAPTION, BILL_STATUS, RO_STATUS,
                   AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE,
                   CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO,
                   EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE,
                   BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK,
                   PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE,
                   REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE,
                   AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE,
                   PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO,
                   AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH,
                   RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE,
                   AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT,
                   SPACE_DISCOUNT, SPECIAL_CHARGES, COMP_CODE,
                   USERID, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY,
                   AGENCY_CREDIT, TOTAL_AREA, CARD_RATE,
                   CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE,
                   REVENUE_CENTER, BILL_PAY, BILL_HEIGHT,
                   BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD,
                   TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO,
                   BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS,
                   BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN,
                   BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER,
                   GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN,
                   BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER,
                   PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE,
                   CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME,
                   CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER,
                   RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5,
                   BG_COLOR, BULLET_CODE, BULLET_PREMIUM,
                   MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID,
                   PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT,
                   COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR,
                   LOGO_UOM, CREATION_DATETIME, RETAINER,
                   ADD_AGENCY_COMM, MOBILENO, ADD_AGENCY_COMM_AMT,
                   RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED,
                   CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION,
                   CIRAGENCY_SUBCODE, BARTER_TYPE, SESID,CASHDISCOUNT,CASHDISCTYPE,ATTACHMENT1,ATTACHMENT2,DISC_PREMIUM,DOCTYPE,CHKTRADEDISC,
                   CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE, ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,
                    LOCALGROSSAMT, LOCALBILLAMT,PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE
                  )
           VALUES (date_time, branch, booked_by, ciobookid,
                   prevbook, approvedby, auditn, rono,
                   rodate, caption, billstatus, rostatus,
                   agency, agencyaddress, client,
                   clientaddresses, agencycode, dockitno,
                   execname, execzone, product,
                   brand, keyno, billremark, printremark,
                   package1, insertion, startdate,
                   repeatdate, adtype1, adcategory,
                   subcategory, color, uom,
                   pageposition, pagetype1, pageno,
                   adsizetype, adsizheight, adsizwidth,
                   ratecode11, sccode, currency,
                   agreedrate, agreedamt, spedisc,
                   spacedisx, specialcharges, compcode,
                   userid, agencystatus, agencytype1, paymode,
                   agenccredit, totarea, cardrate,
                   cardamount, discount, discountper, billcycle,
                   revenuecenter, billpay, billheight,
                   billwidth, billto, invoices, vts, billaddress,
                   tradedisc, agencyout, boxcode, boxno,
                   boxagency, boxclient, boxaddress,
                   bookingtype, tfn, coupan, campaign,
                   bill_amt, pageprem, pageamt, premper,
                   grossamt, adsizcolumn, billcolumn,
                   billarea, specdiscper, spacediscper,
                   paidins, dealrate, deviation, varient,
                   contractname, dealtype, cardname,
                   cardtype, cardmonth, cardyear, cardno,
                   receiptno, adscat3, adscat4, adscat5,
                   bgcolor, bulletcode, bulletprm,
                   material, receiptdate, prevcioid,
                   prevreceipt, prev_ga, region1, varient_name,
                   coltype, logo_h, logo_w, logo_col,
                   logo_uom, SYSDATE, retainer1,
                   addagencyrate, mobileno, addlamt,
                   retper, retamt, cashrecieved,
                   ciragency_v, cirrate_v, ciredition_v, cirpublication_v,
                   ciragencysubcode_v, bartertype,USERENV ('sessionid'),CASHDISCOUNT_V,CASHDISCOUNTPER_V,attach1,attach2,drpdiscprem,doctype_v,CHKTRADE
                  ,chkno,chkdate,chkamt,chkbankname,ourbank,DEALERPANEL_P,
DEALERH_P,
DEALERW_P,
DEALERTYPE_P,AGREEDRATE_ACTIVE,
AGREEDAMT_ACTIVE,grossamtlocal_p,billamtlocal_p,chkadon_p,refid_p,rcpt_currency,cur_convrate);
                  IF sharepub_p is not null then
                        insert_sharepub_details(sharepub_p,ciobookid,'INSERT',error1);
                  end if;
                  
                  if fmginsert is not null then
                    insert_fmgTrans_details(fmginsert,ciobookid,'INSERT',error1);   
                  end if;   
                  if multiselect is not null then
                    insert_multiexec_details(userid,compcode,multiselect,ciobookid,'INSERT',error1);
                  end if;  
                 
   EXCEPTION
      WHEN OTHERS
      THEN
         p_error := 'Error :' || SQLERRM;
         
         
         
   END insertintobooking_p;
END insertintobooking;
/


CREATE OR REPLACE PACKAGE updatebooking IS
PROCEDURE updatebooking_p(
approvedby in varchar2,
audit1 in varchar2,
rono in varchar2,
rodate in date,
caption in varchar2,
billstatus in varchar2,
rostatus in varchar2,
agency in varchar2,
client in varchar2,
agencyaddress in varchar2,
clientaddresses in varchar2,
agencycode in varchar2,
dockitno in varchar2,
execname in varchar2,
execzone in varchar2,
product in varchar2,
brand in varchar2,
keyno in varchar2,
billremark in varchar2,
printremark in varchar2,
package1 in varchar2,
insertion in number,
startdate in date,
repeatdate in varchar2,
adtype1 in varchar2,
adcategory in varchar2,
subcategory in varchar2,
color in varchar2,
uom in varchar2,
pageposition in varchar2,
pagetype1 in varchar2,
pageno in number,
adsizheight in number,
adsizwidth in number,
ratecode11 in varchar2,
scheme1 in varchar2,
currency in varchar2,
agreedrate in number,
agreedamt in number,
spedisc in number,
spacedisx in number,
compcode in varchar2,
userid in varchar2,
ciobookid in varchar2,
date_time in date,
branch in varchar2,
booked_by in varchar2,
prevbook in varchar2,
adsizetype in varchar2,
specialcharges in number,
agencytype in varchar2,
agencystatus in varchar2,
paymode in varchar2,
agencredit in number,
cardrate in number,
cardamount in number,
discount in number,
discountper in number,
billaddress in varchar2,
totarea in number,
billcycle in varchar2,
revenuecenter in varchar2,
billpay in varchar2,
billheight in number,
billwidth in number,
billto in varchar2,
invoices in number,
vts in number,
tradedisc in number,
agencyout in varchar2,
boxcode in varchar2,
boxno in varchar2,
boxaddress in varchar2,
boxagency in varchar2,
boxclient in varchar2,
bookingtype in varchar2,
tfn in varchar2,
coupan in varchar2,
campaign in varchar2,
bill_amt in number,
pageprem in varchar2,
pageamt in number,
premper in number,
grossamt in number,
adsizcolumn in number,
billarea in number,
billcolumn in number,
spacediscper in number,
specdiscper in number,
paidins in number,
dealrate in number,
deviation in number,
varient in varchar2,
dealtype in varchar2,
contractname in varchar2,
cardname in varchar2,
cardtype in varchar2,
cardmonth in varchar2,
cardyear in varchar2,
cardno in varchar2,
receiptno in varchar2,
adscat3 in varchar2,
adscat4 in varchar2,
adscat5 in varchar2,
bgcolor in varchar2,
bulletcode in varchar2,
bulletprm in number,
material in varchar2,
region1 in varchar2,
varient_name in varchar2,
coltype in varchar2,
logo_h in varchar2,
logo_w in varchar2,
logo_col in varchar2,
logo_uom in varchar2,
retainer1 in varchar2,
addagencyrate in varchar2,
mobileno in varchar2,
addlamt in varchar2,
retamt in varchar2,
retper in varchar2,
cashrecieved in varchar2,
CIRAGENCY_V in varchar2,
CIRRATE_V in varchar2,
CIREDITION_V in varchar2,
CIRPUBLICATION_V in varchar2,
CIRAGENCYSUBCODE_V in varchar2,
BARTERTYPE IN VARCHAR2,
CASHDISCOUNT_V IN VARCHAR2,
CASHDISCOUNTPER_V IN VARCHAR2,
attach1 in varchar2,
attach2 in varchar2,
drpdiscprem in varchar2,
doctype_v in varchar2,
CHKTRADE IN VARCHAR2,
sharepub_p in varchar2,
fmginsert in varchar2,chkno in VARCHAR2,
chkdate in date:=null,
chkamt in VARCHAR2,
chkbankname in varchar2,
ourbank	in varchar2,
DEALERPANEL_P in VARCHAR2,
DEALERH_P in FLOAT,
DEALERW_P in FLOAT,
DEALERTYPE_P in VARCHAR2,
multiselect in VARCHAR2,
AGREEDRATE_ACTIVE NUMBER,
AGREEDAMT_ACTIVE NUMBER,
grossamtlocal_p number,
billamtlocal_p number,
chkadon_p varchar2,
refid_p varchar2,
rcpt_currency varchar2,
cur_convrate varchar2
);
End updatebooking;
/

CREATE OR REPLACE PACKAGE BODY updatebooking IS
PROCEDURE updatebooking_p(
approvedby in varchar2,
audit1 in varchar2,
rono in varchar2,
rodate in date,
caption in varchar2,
billstatus in varchar2,
rostatus in varchar2,
agency in varchar2,
client in varchar2,
agencyaddress in varchar2,
clientaddresses in varchar2,
agencycode in varchar2,
dockitno in varchar2,
execname in varchar2,
execzone in varchar2,
product in varchar2,
brand in varchar2,
keyno in varchar2,
billremark in varchar2,
printremark in varchar2,
package1 in varchar2,
insertion in number,
startdate in date,
repeatdate in varchar2,
adtype1 in varchar2,
adcategory in varchar2,
subcategory in varchar2,
color in varchar2,
uom in varchar2,
pageposition in varchar2,
pagetype1 in varchar2,
pageno in number,
adsizheight in number,
adsizwidth in number,
ratecode11 in varchar2,
scheme1 in varchar2,
currency in varchar2,
agreedrate in number,
agreedamt in number,
spedisc in number,
spacedisx in number,
compcode in varchar2,
userid in varchar2,
ciobookid in varchar2,
date_time in date,
branch in varchar2,
booked_by in varchar2,
prevbook in varchar2,
adsizetype in varchar2,
specialcharges in number,
agencytype in varchar2,
agencystatus in varchar2,
paymode in varchar2,
agencredit in number,
cardrate in number,
cardamount in number,
discount in number,
discountper in number,
billaddress in varchar2,
totarea in number,
billcycle in varchar2,
revenuecenter in varchar2,
billpay in varchar2,
billheight in number,
billwidth in number,
billto in varchar2,
invoices in number,
vts in number,
tradedisc in number,
agencyout in varchar2,
boxcode in varchar2,
boxno in varchar2,
boxaddress in varchar2,
boxagency in varchar2,
boxclient in varchar2,
bookingtype in varchar2,
tfn in varchar2,
coupan in varchar2,
campaign in varchar2,
bill_amt in number,
pageprem in varchar2,
pageamt in number,
premper in number,
grossamt in number,
adsizcolumn in number,
billarea in number,
billcolumn in number,
spacediscper in number,
specdiscper in number,
paidins in number,
dealrate in number,
deviation in number,
varient in varchar2,
dealtype in varchar2,
contractname in varchar2,
cardname in varchar2,
cardtype in varchar2,
cardmonth in varchar2,
cardyear in varchar2,
cardno in varchar2,
receiptno in varchar2,
adscat3 in varchar2,
adscat4 in varchar2,
adscat5 in varchar2,
bgcolor in varchar2,
bulletcode in varchar2,
bulletprm in number,
material in varchar2,
region1 in varchar2,
varient_name in varchar2,
coltype in varchar2,
logo_h in varchar2,
logo_w in varchar2,
logo_col in varchar2,
logo_uom in varchar2,
retainer1 in varchar2,
addagencyrate in varchar2,
mobileno in varchar2,
addlamt in varchar2,
retamt in varchar2,
retper in varchar2,
cashrecieved in varchar2,
CIRAGENCY_V in varchar2,
CIRRATE_V in varchar2,
CIREDITION_V in varchar2,
CIRPUBLICATION_V in varchar2,
CIRAGENCYSUBCODE_V in varchar2,
BARTERTYPE IN VARCHAR2,
CASHDISCOUNT_V IN VARCHAR2,
CASHDISCOUNTPER_V IN VARCHAR2,
attach1 in varchar2,
attach2 in varchar2,
drpdiscprem in varchar2,
doctype_v in varchar2,
CHKTRADE IN VARCHAR2,
sharepub_p in varchar2,
fmginsert in varchar2,
chkno in VARCHAR2,
chkdate in date:=null,
chkamt in VARCHAR2,
chkbankname in varchar2,
ourbank    in varchar2,
DEALERPANEL_P in VARCHAR2,
DEALERH_P in FLOAT,
DEALERW_P in FLOAT,
DEALERTYPE_P in VARCHAR2,
multiselect in VARCHAR2,
AGREEDRATE_ACTIVE NUMBER,
AGREEDAMT_ACTIVE NUMBER,
grossamtlocal_p number,
billamtlocal_p number,
chkadon_p varchar2,
refid_p varchar2,
rcpt_currency varchar2,
cur_convrate varchar2
)As
 error1 varchar2(100);
sccode varchar2(50);
mobileno1 varchar2(50);
remarks varchar2(500);
clientname varchar2(200);
Begin
mobileno1:=mobileno;
--begin
--select distinct "scheme_id" into  sccode  from scheme_master where "Scheme_Name"=ltrim(rtrim(scheme1)) and "Comp_code"=compcode;
--exception when no_data_found then
--NULL ;
--end;
sccode:=scheme1;
update tbl_booking_mast set "date_time"=date_time,"branch"=branch,"booked_by"=booked_by,"prev_booking"=prevbook,"applied_by"=approvedby,"audit"=audit1,"RO_No"=rono,"RO_Date"=rodate,
"Caption"=caption,"bill_status"=billstatus,"ro_status"=rostatus,"Agency_code"=agency,"Agency_address"=agencyaddress,"Client_code"=client,"Client_address"=clientaddresses,"Agency_sub_code"=agencycode,
"Dockit_no"=dockitno,"Executive_code"=execname,"Executive_zone"=execzone,"Product_code"=product,"Brand_code"=brand,"Key_no"=keyno,"Bill_remarks"=billremark,"Print_remark"=printremark,
"Package_code"=package1,"No_of_insertion"=insertion,"Insertion_date"=startdate,"Repeating_day"=repeatdate,"Ad_type_code"=adtype1,"Ad_cat_code"=adcategory,"Ad_sub_cat_code"=subcategory,
"Color_code"=color,"Uom_code"=uom,"Page_position_code"=pageposition,"Page_type_code"=pagetype1,"Page_no"=pageno,"Ad_size_type_code"=adsizetype,"Ad_size_height"=adsizheight,
"Ad_size_width"=adsizwidth,"Rate_code"=ratecode11,"Scheme_type_code"=sccode,"Currency_code"=currency,"Agrred_rate"=agreedrate,"Agreed_amount"=agreedamt,"Special_discount"=spedisc,
"Space_discount"=spacedisx,"Special_charges"=specialcharges,"Agency_status"=agencystatus,"Agency_type"=agencytype,"Agency_pay"=paymode,"Agency_credit"=agencredit,
"Total_area"=totarea,"Card_rate"=cardrate,"Card_amount"=cardamount,"Discount"=discount,"Discount_per"=discountper,"Bill_cycle"=billcycle,"Revenue_center"=revenuecenter,
"Bill_pay"=billpay,"Bill_height"=billheight,"Bill_width"=billwidth,"Bill_to"=billto,"Invoices"=invoices,"Vts"=vts,"Bill_add"=billaddress,"Trade_disc"=tradedisc,"Agency_out"=agencyout,
"Box_code"=boxcode,"Box_no"=boxno,"Box_agency"=boxagency,"Box_client"=boxclient,"Box_address"=boxaddress,"Booking_type"=bookingtype,"Tfn"=tfn,"Coupan_ad"=coupan,"Campaign"=campaign,
"Bill_amount"=bill_amt,"Page_prem"=pageprem,"Page_amount"=pageamt,"Prem_per"=premper,"Gross_amount"=grossamt,"Ad_size_column"=adsizcolumn,"Bill_column"=billcolumn,
"Bill_area"=billarea,"Special_disc_per"=specdiscper,"Space_disc_per"=spacediscper,"Paid_ins"=paidins,"Contract_rate"=dealrate,"Deviation"=deviation,"Variant_code"=varient,
"Contract_name"=contractname,"Contract_type"=dealtype,"Card_name"=cardname,"Card_type"=cardtype,"Card_month"=cardmonth,"Card_year"=cardyear,"Card_number"=cardno,"Receipt_no"=receiptno,
"Ad_Subcat3"=adscat3,"Ad_Subcat4"=adscat4,"Ad_subcat5"=adscat5,"Bg_color"=bgcolor,"Bullet_code"=bulletcode,"Bullet_premium"=bulletprm,"Material_status"=material

,"Region"=region1,"Variant"=varient_name,"Colortype"=coltype,
"Logo_H"=logo_h,"Logo_W"=logo_w,"Logo_color"=logo_col,"Logo_Uom"=logo_uom,
"RETAINER"=retainer1, "ADD_AGENCY_COMM"=addagencyrate, tbl_booking_mast.MOBILENO=mobileno1,ADD_AGENCY_COMM_AMT=addlamt,RETAINER_COMM=retper,RETAINER_COMM_AMT=retamt,CASH_RECIEVED=cashrecieved,
CIRAGENCY=CIRAGENCY_V,CIRRATE=CIRRATE_V,CIREDITION=CIREDITION_V,CIRPUBLICATION=CIRPUBLICATION_V,CIRAGENCY_SUBCODE=CIRAGENCYSUBCODE_V,BARTER_TYPE=BARTERTYPE,
CASHDISCOUNT=CASHDISCOUNT_V, CASHDISCTYPE=CASHDISCOUNTPER_V, ATTACHMENT1=attach1, ATTACHMENT2=attach2, DISC_PREMIUM=drpdiscprem, DOCTYPE=doctype_v,CHKTRADEDISC=CHKTRADE,
CHK_NO=chkno,CHK_DATE=chkdate,CHK_AMT=chkamt,CHK_BANK_NAME=chkbankname,OUR_BANK=ourbank,DEALERPANEL=DEALERPANEL_P, DEALER_H=DEALERH_P, DEALER_W=DEALERW_P, DEALERTYPE=DEALERTYPE_P
,ACTIVE_AGREEDRATE=AGREEDRATE_ACTIVE, ACTIVE_AGREEDAMT=AGREEDAMT_ACTIVE,LOCALGROSSAMT=grossamtlocal_p,LOCALBILLAMT=billamtlocal_p,
PACKAGE_TYPE=chkadon_p, AD_REFID=refid_p,RECEIPT_CURRENCY=rcpt_currency,CONV_CURR_RATE=cur_convrate
where "Comp_code"=compcode and "cio_booking_id"=ciobookid;

 IF sharepub_p is not null then
                        insert_sharepub_details(sharepub_p,ciobookid,'UPDATE',error1);
                  end if;

 delete from TBL_BOOKING_FMG_TRANS where CIOID=ciobookid;
  if fmginsert is not null then
    insert_fmgTrans_details(fmginsert,ciobookid,'UPDATE',error1);   
  end if;  
    if multiselect is not null then
                    insert_multiexec_details(userid,compcode,multiselect,ciobookid,'UPDATE',error1);
                  end if;                   
 if billpay = 'CA0' and rostatus='1' and (receiptno is null or receiptno = '') then
 declare
    cursor c1 is
        select * from tbl_booking_mast where "cio_booking_id"=ciobookid;
       
   v1 c1%rowtype;
   v_error      varchar2(2000);
    v_rcptno_r      varchar2(50);
   vrecpt       varchar2(20);
   branchcode   varchar2(20);
   vrepcode     varchar2(20);
   subagencyreg varchar2(20);
   prevcioid_v varchar2(50);
   billamt_v float;
   grossamt_v float;
  v_curdate date;
 begin
 open c1;
 fetch c1 into v1;
    Begin
        select "Branch_Code" into branchcode from branch_mst where "Comp_Code"=v1."Comp_code" and "Branch_Name"=v1."branch";
    Exception When no_data_found then
        branchcode:='';
    End;
   
    Begin
        select "SUB_Agency_Code" into subagencyreg from agency_mast where "Comp_Code"=v1."Comp_code" and "code_subcode"=v1."Agency_sub_code";
    Exception When no_data_found then
        subagencyreg:='';
    End;
   vrecpt:=v1."Receipt_no";
   prevcioid_v:=v1."prev_cioid";
   if prevcioid_v is null or v1."prev_receipt" is null then
    billamt_v:=v1."Bill_amount";
    grossamt_v:=v1."Gross_amount";
    v_curdate:=v1."date_time";
   else
    select "Bill_amount","Gross_amount" into  billamt_v,grossamt_v from tbl_booking_mast where "cio_booking_id"=prevcioid_v;
    billamt_v:=v1."Bill_amount" - billamt_v;
     grossamt_v:=v1."Gross_amount" - grossamt_v;
     v_curdate:=to_date(sysdate);
   end if;
   -- select substr(max("recptno"),1,12)||lpad(substr(max("recptno"),-6)+1,6,'0') into vrecpt from ad_rcpthdr where "unit"=branchcode and "doctype"='RCP' and
   -- "recptdt" between '1-mar-2011' and '31-mar-2011';
 
 --receiptsave_booking.receiptsave_booking_P(pcompcode,puserid , punit ,ptype , precpt , prdate , ppaymodres ,preceivedreg ,pvouno  ,pamount  ,pagency , pothercd ,
  --pchno  ,pchedate , pbank  , pnarration ,prep   , pvdate , pag_main_code ,pag_sub_code , ourbank,  cioid , execname , retainer ,
   -- prevcioid , p_error)
   begin
 SELECT "Cust_Name" into clientname FROM CUST_MAST WHERE "Cust_Code" = v1."Client_code" and "Comp_Code"=v1."Comp_code";
exception
when NO_DATA_FOUND THEN
clientname:=v1."Client_code";
END;

remarks:='RONO#'||v1."RO_No" ||' RODATE# ' || to_char(v1."RO_Date",'dd-mon-yyyy') || ' BOOKINGID# ' || v1."cio_booking_id" || ' CLIENT#' || clientname;

   receiptsave_booking.receiptsave_booking_p(v1."Comp_code",v1."Userid", v1."branch",v1.DOCTYPE,vrecpt,v_curdate,v1."Bill_pay",'','',billamt_v,v1."Agency_sub_code",grossamt_v,
    '','','',remarks,vrepcode,v1."date_time",v1."Agency_code",subagencyreg,'',v1."cio_booking_id",v1."Executive_code",v1.RETAINER,v1."prev_cioid",v_rcptno_r,v_error);
   
  update tbl_booking_mast set "Receipt_no"=v_rcptno_r,"Receipt_date"=v_curdate where "cio_booking_id"=v1."cio_booking_id";
 close c1;
 commit;
 end;
 end if;
 
end updatebooking_p;
End updatebooking;
/


CREATE OR REPLACE procedure tv_convert_to_local(p_Comp_code varchar2,p_Curr_Code in varchar2, p_amount in number,p_amount1 in number, p_date in date,convertcurrency in varchar2 , p_accounts   OUT   cur_type_new1.cursor_type) as
l_ret_amount number;
l_ret_amount1 number;
l_local_curr_code varchar2(100);
l_conv_rate varchar2(8);
begin
select "currency_code" into l_local_curr_code from PREFERRENCES where "comp_code"= p_Comp_code  ;
/*
if l_local_curr_code = p_Curr_Code then 
  open p_accounts for 
  select p_amount AS "GROSS", p_amount1 AS "BILL", 'OK' STATUS, l_conv_rate as CONV_RATE from dual;
end if;
  */
begin  
select trunc("Conv_Rate"*p_amount,"No_of_Decimal"),trunc("Conv_Rate"*p_amount1,"No_of_Decimal"),"Conv_Rate"  into l_ret_amount,l_ret_amount1,l_conv_rate from 
CURR_CONV_DET a,PREFERRENCES b 
where "Comp_code" = p_Comp_code
and a."Comp_code" =b."comp_code"
and p_date between "Valid_From_Date" and "Valid_Till_Date"
and "Curr_Code" = p_Curr_Code and  conv_currency=convertcurrency;
open p_accounts for
select l_ret_amount AS "GROSS",l_ret_amount1 AS "BILL",'OK' STATUS, l_conv_rate as CONV_RATE from dual;

exception 
  when others then 
       open p_accounts for
       select p_amount as "GROSS", p_amount1 AS "BILL" , 'Error while converting to local...' STATUS,l_conv_rate as CONV_RATE from dual;
       end ;
end ;
/

CREATE OR REPLACE procedure committransaction(cioid varchar2,totalcount int, p_error              OUT      VARCHAR2)
is
countnum int;
newid varchar2(100);
billpay varchar2(20);
rostatus varchar2(20);
remarks varchar2(500);
clientname varchar2(200);
begin
newid:=cioid;

select count(*) into countnum from tbl_booking_insert_g where Cio_Booking_Id=cioid;
if(countnum=totalcount) then
  p_error :='Y';
 INSERT INTO tbladid_ins(CIOID,COUNTNUM,FLAG) VALUES(newid,countnum,p_error);
 INSERT INTO TBL_BOOKING_MAST("date_time", "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by", "audit", "RO_No", "RO_Date", "Caption", "bill_status", "ro_status", "Agency_code", "Agency_address", "Client_code", "Client_address", "Agency_sub_code", "Dockit_no", "Executive_code", "Executive_zone", "Product_code", "Brand_code", "Key_no", "Bill_remarks", "Print_remark", "Package_code", "No_of_insertion", "Insertion_date", "Repeating_day", "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code", "Color_code", "Uom_code", "Page_position_code", "Page_type_code", "Page_no", "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code", "Scheme_type_code", "Currency_code", "Agrred_rate", "Agreed_amount", "Special_discount", "Space_discount", "Special_charges", "Agency_status", "Agency_type", "Agency_pay", "Agency_credit", "Total_area", "Card_rate", "Card_amount", "Discount", "Discount_per", "Bill_cycle", "Revenue_center", "Bill_pay", "Bill_height", "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc", "Agency_out", "Box_code", "Box_no", "Box_agency", "Box_client", "Box_address", "Comp_code", "Userid", "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad", "Campaign", "Bill_amount", "Page_prem", "Page_amount", "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", "Bill_area", "Special_disc_per", "Space_disc_per", "Paid_ins", "Contract_rate", "Deviation", "Variant_code", "Contract_name", "Contract_type", "Card_name", "Card_type", "Card_month", "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", "Bullet_code", "Bullet_premium", "Material_status", "Receipt_date", "prev_cioid", "prev_receipt", "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom", "SAPID", "RETAINER", "ADD_AGENCY_COMM", "AUDIT_COMMENT", "MOBILENO", "ADD_AGENCY_COMM_AMT", "RETAINER_COMM", "RETAINER_COMM_AMT", "CASH_RECIEVED", "CONT_GROSS", "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION", "CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER", "RODOCSTATUS",CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID,RECEIPT_CURRENCY, CONV_CURR_RATE) 
SELECT DATE_TIME, BRANCH, BOOKED_BY, CIO_BOOKING_ID, PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO, RO_DATE, CAPTION, BILL_STATUS, RO_STATUS, AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE, CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO, EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE, BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK, PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE, REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE, AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE, PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO, AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH, RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE, AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT, SPACE_DISCOUNT, SPECIAL_CHARGES, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY, AGENCY_CREDIT, TOTAL_AREA, CARD_RATE, CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE, REVENUE_CENTER, BILL_PAY, BILL_HEIGHT, BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD, TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO, BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS, COMP_CODE, USERID, CREATION_DATETIME, BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN, BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER, GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN, BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER, PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE, CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME, CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER, RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, BG_COLOR, BULLET_CODE, BULLET_PREMIUM, MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID, PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT, COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR, LOGO_UOM, SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO, ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS, CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, RODOCSTATUS,CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK, DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=cioid;

INSERT INTO TBL_BOOKING_insert("Insert_Id", "Cio_Booking_Id", "No_Insert", "Edition_Code", "Publication_Code", "Pub_Cent_Code", "Supp_Code", "Edition", "Insert_Date", "Col_Code", "Height", "Width", "Size_Book", "Page_Post", "Premium1", "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow", "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Repeating_Date", "Status_Material", "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status", "Bill_Status", "Agreed_Rate", "Pai_Free_Ins", "Solo_Rate", "Gross_Rate", "Comp_Code", "Userid", "Page_No", "Remarks", "Pub_Height", "Pub_Width", "Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5", "PACKAGE_CODE", "BILL_NO", "BILL_DATE", "INSERTS", "PKG_ALIAS", "CONT_GROSS_AMT", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER",SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT, LOCALBILLAMT,SECTIONCODE,RESOURCE_NO) 
SELECT INSERT_ID, CIO_BOOKING_ID, NO_INSERT, EDITION_CODE, PUBLICATION_CODE, PUB_CENT_CODE, SUPP_CODE, EDITION, INSERT_DATE, COL_CODE, HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1, PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW, AD_CAT, AD_SUB_CAT, LATEST_BY, REPEATING_DATE, STATUS_MATERIAL, FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS, BILL_STATUS, AGREED_RATE, PAI_FREE_INS, SOLO_RATE, GROSS_RATE, COMP_CODE, USERID, PAGE_NO, REMARKS, PUB_HEIGHT, PUB_WIDTH, PAGE_PREM, PAGE_PER, NO_OFCOLUMN, BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, PACKAGE_CODE, BILL_NO, BILL_DATE, INSERTS, PKG_ALIAS, CONT_GROSS_AMT, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, SPECIAL_SIZE1,VATAMT, BOXCHARGE, VAT_INC,LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=cioid;

INSERT INTO TBL_BOOKING_VTS(COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE) 
SELECT COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE FROM TBL_BOOKING_VTS_G WHERE  cioid=newid;

insert into tbl_booking_insert_sizesplit(CIOID, RECEIPTNO, INSERTID, INSERTDATE, HEIGHT, WIDTH, AREA, SRNO, CREATIONDATETIME)
select CIOID, RECEIPTNO, INSERTID, INSERTDATE, HEIGHT, WIDTH, AREA, SRNO, CREATIONDATETIME from tbl_booking_insert_sizesplit_g where cioid=newid;

--INSERT INTO ABCTEST VALUES(newid,counttest);
insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO, NO_INSERT)
select COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO, SRNO, NO_INSERT from tbl_booking_subedition_g
where tbl_booking_subedition_g.CIOID=newid;

insert into TBL_BOOKING_SHARING_TRANS(PUBLICATION, TYPE, SHARING, CIOID, SRNO)
select PUBLICATION, TYPE, SHARING, CIOID, SRNO from TBL_BOOKING_SHARING_TRANS_g where CIOID=cioid ;

insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID, CREATIONDATETIME)
select CIOID, INSERTID, CREATIONDATETIME from TBL_BOOKING_FMG_TRANS_G where CIOID=cioid;
 select "Bill_pay","ro_status" into billpay,rostatus from tbl_booking_mast where "cio_booking_id"=cioid;
 if billpay = 'CA0' and rostatus='1' then
 declare
    cursor c1 is
        select * from tbl_booking_mast where "cio_booking_id"=cioid;
       
   v1 c1%rowtype;
   v_error      varchar2(2000);
    v_rcptno_r      varchar2(50);
   vrecpt       varchar2(20);
   branchcode   varchar2(20);
   vrepcode     varchar2(20);
   subagencyreg varchar2(20);
   prevcioid_v varchar2(50);
   billamt_v float;
   grossamt_v float;
  v_curdate date;
 begin
 open c1;
 fetch c1 into v1;
    Begin
        select "Branch_Code" into branchcode from branch_mst where "Comp_Code"=v1."Comp_code" and "Branch_Name"=v1."branch";
    Exception When no_data_found then
        branchcode:='';
    End;
   
    Begin
        select "SUB_Agency_Code" into subagencyreg from agency_mast where "Comp_Code"=v1."Comp_code" and "code_subcode"=v1."Agency_sub_code";
    Exception When no_data_found then
        subagencyreg:='';
    End;
   vrecpt:=v1."Receipt_no";
   prevcioid_v:=v1."prev_cioid";
   if prevcioid_v is null or v1."prev_receipt" is null then
    billamt_v:=v1."Bill_amount";
    grossamt_v:=v1."Gross_amount";
    v_curdate:=to_date(sysdate);
   else
    select "Bill_amount","Gross_amount" into  billamt_v,grossamt_v from tbl_booking_mast where "cio_booking_id"=prevcioid_v;
    billamt_v:=v1."Bill_amount" - billamt_v;
     grossamt_v:=v1."Gross_amount" - grossamt_v;
     IF grossamt_v=0 OR grossamt_v IS NULL THEN
         grossamt_v:=v1."Gross_amount";
     END IF;
     v_curdate:=to_date(sysdate);
   end if;
   -- select substr(max("recptno"),1,12)||lpad(substr(max("recptno"),-6)+1,6,'0') into vrecpt from ad_rcpthdr where "unit"=branchcode and "doctype"='RCP' and
   -- "recptdt" between '1-mar-2011' and '31-mar-2011';
 
 --receiptsave_booking.receiptsave_booking_P(pcompcode,puserid , punit ,ptype , precpt , prdate , ppaymodres ,preceivedreg ,pvouno  ,pamount  ,pagency , pothercd ,
  --pchno  ,pchedate , pbank  , pnarration ,prep   , pvdate , pag_main_code ,pag_sub_code , ourbank,  cioid , execname , retainer ,
   -- prevcioid , p_error)
   begin
 SELECT "Cust_Name" into clientname FROM CUST_MAST WHERE "Cust_Code" = v1."Client_code" and "Comp_Code"=v1."Comp_code";
exception
when NO_DATA_FOUND THEN
clientname:=v1."Client_code";
END;

remarks:='RONO#'||v1."RO_No" ||' RODATE# ' || to_char(v1."RO_Date",'dd-mon-yyyy') || ' BOOKINGID# ' || v1."cio_booking_id" || ' CLIENT#' || clientname;

   receiptsave_booking.receiptsave_booking_p(v1."Comp_code",v1."Userid", v1."branch",V1.DOCTYPE,vrecpt,v_curdate,v1."Bill_pay",'','',billamt_v,v1."Agency_sub_code",grossamt_v,
    '','','',remarks,vrepcode,v1."date_time",v1."Agency_code",subagencyreg,'',v1."cio_booking_id",v1."Executive_code",v1.RETAINER,v1."prev_cioid",v_rcptno_r,v_error);
   
  update tbl_booking_mast set "Receipt_no"=v_rcptno_r,"Receipt_date"= v_curdate where "cio_booking_id"=v1."cio_booking_id";
 close c1;
 commit;
 end;
 end if;
 /*
 INSERT INTO TBL_BOOKING_MAST("date_time", "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by", "audit", "RO_No", "RO_Date", "Caption", "bill_status", "ro_status", "Agency_code", "Agency_address", "Client_code", "Client_address", "Agency_sub_code", "Dockit_no", "Executive_code", "Executive_zone", "Product_code", "Brand_code", "Key_no", "Bill_remarks", "Print_remark", "Package_code", "No_of_insertion", "Insertion_date", "Repeating_day", "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code", "Color_code", "Uom_code", "Page_position_code", "Page_type_code", "Page_no", "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code", "Scheme_type_code", "Currency_code", "Agrred_rate", "Agreed_amount", "Special_discount", "Space_discount", "Special_charges", "Agency_status", "Agency_type", "Agency_pay", "Agency_credit", "Total_area", "Card_rate", "Card_amount", "Discount", "Discount_per", "Bill_cycle", "Revenue_center", "Bill_pay", "Bill_height", "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc", "Agency_out", "Box_code", "Box_no", "Box_agency", "Box_client", "Box_address", "Comp_code", "Userid", "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad", "Campaign", "Bill_amount", "Page_prem", "Page_amount", "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", "Bill_area", "Special_disc_per", "Space_disc_per", "Paid_ins", "Contract_rate", "Deviation", "Variant_code", "Contract_name", "Contract_type", "Card_name", "Card_type", "Card_month", "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", "Bullet_code", "Bullet_premium", "Material_status", "Receipt_date", "prev_cioid", "prev_receipt", "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom", "SAPID", "RETAINER", "ADD_AGENCY_COMM", "AUDIT_COMMENT", "MOBILENO", "ADD_AGENCY_COMM_AMT", "RETAINER_COMM", "RETAINER_COMM_AMT", "CASH_RECIEVED", "CONT_GROSS", "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION", "CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER", "RODOCSTATUS") 
SELECT DATE_TIME, BRANCH, BOOKED_BY, CIO_BOOKING_ID, PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO, RO_DATE, CAPTION, BILL_STATUS, RO_STATUS, AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE, CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO, EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE, BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK, PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE, REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE, AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE, PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO, AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH, RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE, AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT, SPACE_DISCOUNT, SPECIAL_CHARGES, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY, AGENCY_CREDIT, TOTAL_AREA, CARD_RATE, CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE, REVENUE_CENTER, BILL_PAY, BILL_HEIGHT, BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD, TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO, BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS, COMP_CODE, USERID, CREATION_DATETIME, BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN, BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER, GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN, BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER, PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE, CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME, CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER, RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, BG_COLOR, BULLET_CODE, BULLET_PREMIUM, MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID, PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT, COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR, LOGO_UOM, SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO, ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS, CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, RODOCSTATUS FROM TBL_BOOKING_MAST_G WHERE SESID=USERENV ('sessionid') and CIO_BOOKING_ID=cioid;

INSERT INTO TBL_BOOKING_insert("Insert_Id", "Cio_Booking_Id", "No_Insert", "Edition_Code", "Publication_Code", "Pub_Cent_Code", "Supp_Code", "Edition", "Insert_Date", "Col_Code", "Height", "Width", "Size_Book", "Page_Post", "Premium1", "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow", "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Repeating_Date", "Status_Material", "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status", "Bill_Status", "Agreed_Rate", "Pai_Free_Ins", "Solo_Rate", "Gross_Rate", "Comp_Code", "Userid", "Page_No", "Remarks", "Pub_Height", "Pub_Width", "Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5", "PACKAGE_CODE", "BILL_NO", "BILL_DATE", "INSERTS", "PKG_ALIAS", "CONT_GROSS_AMT", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER") 
SELECT INSERT_ID, CIO_BOOKING_ID, NO_INSERT, EDITION_CODE, PUBLICATION_CODE, PUB_CENT_CODE, SUPP_CODE, EDITION, INSERT_DATE, COL_CODE, HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1, PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW, AD_CAT, AD_SUB_CAT, LATEST_BY, REPEATING_DATE, STATUS_MATERIAL, FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS, BILL_STATUS, AGREED_RATE, PAI_FREE_INS, SOLO_RATE, GROSS_RATE, COMP_CODE, USERID, PAGE_NO, REMARKS, PUB_HEIGHT, PUB_WIDTH, PAGE_PREM, PAGE_PER, NO_OFCOLUMN, BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, PACKAGE_CODE, BILL_NO, BILL_DATE, INSERTS, PKG_ALIAS, CONT_GROSS_AMT, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER FROM TBL_BOOKING_INSERT_G WHERE SESID=USERENV ('sessionid') and CIO_BOOKING_ID=cioid;

*/
else
rollback;
 p_error :='N';
--DELETE FROM TBL_BOOKING_INSERT WHERE "Cio_Booking_Id"=cioid;
--DELETE FROM TBL_BOOKING_mast WHERE "cio_booking_id"=cioid;
INSERT INTO tbladid_ins(CIOID,COUNTNUM,FLAG) VALUES(newid,countnum,p_error);
end if;
--delete from tbl_booking_mast_g where  CIO_BOOKING_ID=cioid;
--delete from tbl_booking_insert_g where  CIO_BOOKING_ID=cioid;
--delete from tbl_booking_vts_g where  cioid=newid;
end;
/


CREATE OR REPLACE PACKAGE BODY executebooking
IS
   PROCEDURE executebooking_p (
      compcode      IN       VARCHAR2,
      ciobookid     IN       VARCHAR2,
      docno         IN       VARCHAR2 := NULL,
      keyno         IN       VARCHAR2 := NULL,
      rono          IN       VARCHAR2 := NULL,
      agencycode    IN       VARCHAR2 := NULL,
      client        IN       VARCHAR2 := NULL,
      booking       IN       VARCHAR2,
       dateformat     IN          VARCHAR2,
      revenue in varchar2,
      p_accounts    OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor,
      p_accounts2   OUT      t_accounts_cursor,
      P_Accounts3  OUT  T_Accounts_Cursor
   )
   AS
      VERSION1   NUMBER;
      count1    NUMBER;

   BEGIN

       DELETE from tempbooking_mast;

      INSERT INTO tempbooking_mast
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
                "Ad_size_height", "Ad_size_width", "Rate_code",
                "Scheme_type_code", "Currency_code", nvl("Agrred_rate",'0'),
                nvl("Agreed_amount",'0'), "Special_discount", "Space_discount",
                "Special_charges", "Agency_status", "Agency_type",
                "Agency_pay", "Agency_credit", "Total_area", "Card_rate",
                "Card_amount", nvl("Discount",'0'), "Discount_per", "Bill_cycle",
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
                trunc("Receipt_date"), "prev_cioid", "prev_receipt",
                "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H",
                "Logo_W", "Logo_color", "Logo_Uom",sapid,RETAINER,"ADD_AGENCY_COMM",MOBILENO,ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,CASH_RECIEVED,CIRAGENCY,CIRRATE,CIREDITION,CIRPUBLICATION,CIRAGENCY_SUBCODE,BARTER_TYPE,
                CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM,CHKTRADEDISC,CHK_DATE, CHK_AMT, CHK_BANK_NAME, OUR_BANK, CHK_NO,DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT,
                LOCALGROSSAMT, LOCALBILLAMT,PACKAGE_TYPE,AD_REFID,RECEIPT_CURRENCY, CONV_CURR_RATE
           FROM tbl_booking_mast
          WHERE ("Comp_code" = compcode OR compcode IS NULL)
            AND (("cio_booking_id" = ciobookid OR ciobookid IS NULL
                ) OR("Receipt_no"=ciobookid OR ciobookid IS NULL))
            AND ("Dockit_no" LIKE docno || '%' OR docno IS NULL)
            AND ("Key_no" LIKE keyno || '%' OR keyno IS NULL)
            AND ("RO_No" LIKE rono || '%' OR rono IS NULL)
            AND ("Agency_sub_code" LIKE agencycode || '%' OR agencycode IS NULL)
            AND ("Client_code" LIKE client || '%' OR client IS NULL)
           AND ("Ad_type_code" LIKE booking || '%' OR booking IS NULL) 
           AND "branch" in(SELECT LTRIM(RTRIM(BRANCH_CODE)) FROM LOGIN_BRANCH_MAST WHERE USER_CODE=revenue and COMP_CODE=compcode and USER_FLAG='Y')
            ORDER BY "Creation_datetime";



  --Dbms_output.put_line('rinki--');
      OPEN p_accounts FOR
           SELECT CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR("date_time",'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR("date_time",'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR("date_time",'yyyy/mm/dd')  END AS date_time,
                      "branch","booked_by", "cio_booking_id", "prev_booking", "applied_by",
                "audit", "RO_No", TO_CHAR("RO_Date", 'dd/mm/yyyy') AS "RO_Date",
                "Caption", "bill_status", "ro_status", "Agency_code",
                "Agency_address", "Client_code", "Client_address",
                "Agency_sub_code", "Dockit_no", "Executive_code",
                "Executive_zone", "Product_code", "Brand_code", "Key_no",
                "Bill_remarks", "Print_remark", "Package_code",
                "No_of_insertion",
                TO_CHAR("Insertion_date", 'dd/mm/yyyy') AS "Insertion_date",
                "Repeating_day", "Ad_type_code", "Ad_cat_code",
                "Ad_sub_cat_code", "Color_code", "Uom_code",
                "Page_position_code", "Page_type_code", "Page_no",
                "Ad_size_type_code", "Ad_size_height", "Ad_size_width",
                "Rate_code",
                (SELECT "Scheme_Name" FROM scheme_master WHERE "scheme_id" =tempbooking_mast."Scheme_type_code")AS "Scheme_type_code",
                 "Currency_code", "Agrred_rate", "Agreed_amount",
                "Special_discount", "Space_discount", "Special_charges",
                tempbooking_mast."Comp_code", tempbooking_mast."Userid",
                tempbooking_mast."Agency_status", "Agency_type", "Agency_pay",
                "Agency_credit", "Total_area", "Card_rate", "Card_amount",
                "Discount", "Discount_per", "Bill_cycle", "Revenue_center",
                "Bill_pay", "Bill_height", "Bill_width",
                tempbooking_mast."Bill_to", "Invoices", "Vts", "Bill_add",
                "Trade_disc", "Agency_out", "Booking_type", "Campaign",
                "Page_prem", "Page_amount", "Prem_per", "Gross_amount",
                "Bill_amount", "Box_code", "Box_no", "Box_agency",
                "Box_client", "Box_address", "Tfn", "Coupan_ad",
                "Ad_size_column", "Bill_column", "Bill_area",
                "Special_disc_per", "Space_disc_per",
                   agency_mast."Agency_Name"
                || '('
                || agency_mast."code_subcode"
                || ')' AS "AgencyName",
                (SELECT   exec_mast."Exec_name"
                        || '('
                        || TO_CHAR(exec_mast."Exe_no")
                        || ')'
                   FROM exec_mast
                  WHERE tempbooking_mast."Executive_code" = exec_mast."Exe_no"
                    AND tempbooking_mast."Comp_code" = exec_mast."comp_code") AS "execname",
                    --91
                (SELECT    product_cat_mast."prod_desc"
                        || '('
                        || product_cat_mast."prod_cat_code"
                        || ')'
                   FROM product_cat_mast
                  WHERE tempbooking_mast."Product_code" = product_cat_mast."prod_cat_code"
                    AND tempbooking_mast."Comp_code" = product_cat_mast."comp_code") AS "product",
                    --92
                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                (select "deal_name" from contract_mast where "Deal_No"= (select "deal_code" from contract_detail where "ContractCode"= "Contract_name")) as "Contract_name", "Contract_type", "Card_name", "Card_type",
                --100
                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                "Bullet_code", "Bullet_premium",
                (SELECT "Agency_Name" FROM agency_mast
                  WHERE "code_subcode" =tempbooking_mast."Agency_sub_code") AS "AgencySubCode",
              --111
                NVL ((SELECT "Cust_Name" FROM cust_mast WHERE "Cust_Code" = "Client_code"), '') AS "Client",                                       --112
                (SELECT "Payment_Mode_Name" FROM payment_mode_mast WHERE "Pay_Mode_Code" = "Agency_pay") AS "PayMode",
                (SELECT "Adv_Cat_Name" FROM adv_cat_mast WHERE adv_cat_mast."Adv_Cat_Code" =tempbooking_mast."Ad_cat_code") AS "categoryname",
                (SELECT "Adv_Subcat_Name" FROM adv_subcat_mast  WHERE adv_subcat_mast."Adv_Subcat_Code" =tempbooking_mast."Ad_sub_cat_code")
                 AS "subcategoryname",
                (SELECT "brand_name" FROM brand_mst WHERE "brand_code" =tempbooking_mast."Brand_code") AS "Brand",
                (SELECT "Uom_Name" FROM uom_mast WHERE "Uom_Code" = tempbooking_mast."Uom_code") AS "UOM",
                (SELECT "premiumname" FROM advpos_prem_mast WHERE "Premiumcode" =tempbooking_mast."Page_type_code")
                  AS "PagePremium",
                 (SELECT "Pos_Type"
                   FROM advpos_type_mast
                  WHERE "Pos_Type_Code" =
                           tempbooking_mast."Page_position_code")
                                                         AS "PositionPremium",
                (SELECT "Curr_Name"
                   FROM curr_mast
                  WHERE "Curr_Code" =
                               tempbooking_mast."Currency_code")
                                                                AS "Currency",
                "Material_status", TO_CHAR("Receipt_date",'dd/mm/yyyy') as "Receipt_date", tempbooking_mast."Region",
                "Variant", "Colortype",
                (SELECT "UOM_DESC"
                   FROM uom_mast
                  WHERE "Uom_Code" =
                                    tempbooking_mast."Uom_code")
                                                                AS "uom_desc",
                (SELECT "Logo"
                   FROM uom_mast
                  WHERE "Uom_Code" = tempbooking_mast."Uom_code") AS "logo",
                "Logo_H", "Logo_W", "Logo_color", "Logo_Uom",
                (SELECT "Logo_Uom"
                   FROM uom_mast
                  WHERE "Uom_Code" = tempbooking_mast."Uom_code")  AS "logocode",
                (select "Box_Charges_Native" from box_mast where box_mast."Box_Code"=tempbooking_mast."Box_code" and "pub_center"=(select "pub_center" from branch_mst where "Branch_Code"=tempbooking_mast."branch")) as "boxchrg",tempbooking_mast.sapid,
                retainer,(select "Retain_Name" from retainermaster where retainermaster."Retain_Code"=tempbooking_mast.retainer) as "RETAINER", (SELECT "Retain_Name"||'('||"Retain_Code"||')' FROM RETAINERMASTER WHERE RETAINERMASTER."Retain_Code"=TEMPBOOKING_MAST.RETAINER) AS "RETAINER1", (SELECT "Package_Name" FROM combin_mast WHERE "Combin_Code" = 

TEMPBOOKING_MAST."Package_code") as "Package_cod",(SELECT "Col_Name" FROM col_mast WHERE "Col_Code" = TEMPBOOKING_MAST."Color_code") as 

"Color_cod",(SELECT "Pos_Type" FROM advpos_type_mast WHERE "Pos_Type_Code" = 

TEMPBOOKING_MAST."Page_position_code") as "Page_position_cod",decode(TEMPBOOKING_MAST."Booking_type",'1','FMG','2','BARTER','3','NORMAL','4','COMPLIMEN

TRY') as "Book_type",(SELECT "catname"  FROM  AD_CAT3   WHERE 

AD_CAT3."catcode"=TEMPBOOKING_MAST."Ad_Subcat3")  as "Subcat3",(SELECT "Cat_Name"  FROM  TBL_CAT4   WHERE 

TBL_CAT4."Cat_Code"=TEMPBOOKING_MAST."Ad_Subcat4") as "Subcat4",(SELECT "Cat_Name"  FROM  TBL_CAT5   WHERE 

TBL_CAT5."Cat_Code"=TEMPBOOKING_MAST."Ad_subcat5") as "subcat5",(SELECT "Comm_Rate" FROM ret_comm_details WHERE 

ret_comm_details."Retain_Code"=TEMPBOOKING_MAST.RETAINER and rowid=(select max(rowid) from ret_comm_details where ret_comm_details."Retain_Code"=TEMPBOOKING_MAST.RETAINER)) AS "RETAINER_COMM","ADD_AGENCY_COMM",
tempbooking_mast."Scheme_type_code",MOBILENO,
CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM,CHKTRADE,CHK_DATE, CHK_AMT, CHK_BANK_NAME, OUR_BANK, CHK_NO, agency_mast.BOOKING_TYPE,
DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,MOBILENO,
                     (select "Comm_Rate" from comm_details where "Agency_code" || "Agency_sub_code"=TEMPBOOKING_MAST."Agency_sub_code"
 and "Comp_Code"=upper(compcode) and SYSDATE between "Eff_from_Date" and "Eff_Till_Date" AND ROWNUM<=1 ) as COMM_RATE,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT, NVL(LOCALGROSSAMT,"Gross_amount") AS LOCALGROSSAMT, NVL(LOCALBILLAMT,"Bill_amount") as LOCALBILLAMT 
/*for Display and classified*/
           FROM tempbooking_mast, agency_mast
          WHERE agency_mast."code_subcode" =
                                            tempbooking_mast."Agency_sub_code"
            AND agency_mast."Comp_Code" = compcode order by "Creation_datetime";


      Dbms_output.put_line('rinki--');
----------------------------------------------------Lata------------------------------------------------------

      OPEN p_accounts1 FOR
      SELECT 'A' AS A FROM DUAL;
      /*   SELECT NVL(COUNT (*),'0') AS "count"
                     FROM tbl_booking_mast_LOG
          WHERE "Receipt_no" = ciobookid AND "audit" IS NOT NULL;


      BEGIN

         SELECT MAX (VSEQNO)
           INTO VERSION1
           FROM tbl_booking_mast_LOG
          WHERE "Receipt_no" = ciobookid
            AND VSEQNO < (SELECT MAX (VSEQNO)
                               FROM tbl_booking_mast_LOG
                              WHERE "Receipt_no" = ciobookid);
      EXCEPTION
         WHEN NO_DATA_FOUND
         THEN
            NULL;
      END;
*/
      OPEN p_accounts2 FOR
      SELECT 'A' AS A FROM DUAL;
        /* SELECT TO_CHAR ("date_time", 'dd/mm/yyyy') AS "date_time", "branch",
                "booked_by", "cio_booking_id", "prev_booking", "applied_by",
                "audit", "RO_No",
                TO_CHAR ("RO_Date", 'dd/mm/yyyy') AS "RO_Date", "Caption",
                "bill_status", "ro_status",
                tbl_booking_mast_log."Agency_code", "Agency_address",
                "Client_code", "Client_address", "Agency_sub_code",
                "Dockit_no", "Executive_code", "Executive_zone",
                "Product_code", "Brand_code", "Key_no", "Bill_remarks",
                "Print_remark", "Package_code", "No_of_insertion",
                TO_CHAR ("Insertion_date", 'dd/mm/yyyy') AS "Insertion_date",
                "Repeating_day", "Ad_type_code", "Ad_cat_code",
                "Ad_sub_cat_code", "Color_code", "Uom_code",
                "Page_position_code", "Page_type_code", "Page_no",
                "Ad_size_type_code", "Ad_size_height", "Ad_size_width",
                "Rate_code", "Scheme_type_code", "Currency_code",
                "Agrred_rate", "Agreed_amount", "Special_discount",
                "Space_discount", "Special_charges",
                tbl_booking_mast_log."Comp_code",
                tbl_booking_mast_log."Userid",
                tbl_booking_mast_log."Agency_status", "Agency_type",
                "Agency_pay", "Agency_credit", "Total_area", "Card_rate",
                "Card_amount", "Discount", "Discount_per", "Bill_cycle",
                "Revenue_center", "Bill_pay", "Bill_height", "Bill_width",
                tbl_booking_mast_log."Bill_to", "Invoices", "Vts",
                "Bill_add", "Trade_disc", "Agency_out", "Booking_type",
                "Campaign", "Page_prem", "Page_amount", "Prem_per",
                "Gross_amount", "Bill_amount", "Box_code", "Box_no",
                "Box_agency", "Box_client", "Box_address", "Tfn" "Coupan_ad",
                "Ad_size_column", "Bill_column", "Bill_area",
                "Special_disc_per", "Space_disc_per",
                  agency_mast."Agency_Name"|| '('|| agency_mast."code_subcode"|| ')' AS "AgencyName",
                   (SELECT    exec_mast."Exec_name" || '('|| TO_CHAR (exec_mast."Exe_no") || ')'
                   FROM exec_mast  WHERE tbl_booking_mast_log."Executive_code" =exec_mast."Exe_no"
                    AND tbl_booking_mast_log."Comp_code" =exec_mast."comp_code")AS "execname",
               (SELECT    product_cat_mast."prod_desc"|| '('|| product_cat_mast."prod_cat_code" || ')'
                   FROM product_cat_mast WHERE tbl_booking_mast_log."Product_code" =product_cat_mast."prod_cat_code"
                    AND tbl_booking_mast_log."Comp_code" =product_cat_mast."comp_code")                                                                 AS "product",
                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                "Contract_name", "Contract_type", "Card_name", "Card_type",
                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                (SELECT "Agency_Name" FROM agency_mast WHERE "code_subcode" = tbl_booking_mast_log."Agency_sub_code")AS "AgencySubCode",
               NVL ((SELECT "Cust_Name"  FROM cust_mast WHERE "Cust_Code" = "Client_code"),'' ) AS "Client",
              (SELECT "Payment_Mode_Name"  FROM payment_mode_mast WHERE "Pay_Mode_Code" = "Agency_pay") AS "PayMode",
               (SELECT "Adv_Cat_Name" FROM adv_cat_mast WHERE adv_cat_mast."Adv_Cat_Code" =tbl_booking_mast_log."Ad_cat_code")AS "categoryname",
               (SELECT "Adv_Subcat_Name"  FROM adv_subcat_mast WHERE adv_subcat_mast."Adv_Subcat_Code" =tbl_booking_mast_log."Ad_sub_cat_code")
                 AS "subcategoryname",
               (SELECT "brand_name"  FROM brand_mst   WHERE "brand_code" = tbl_booking_mast_log."Brand_code")AS "Brand",
               (SELECT "Uom_Name" FROM uom_mast WHERE "Uom_Code" =tbl_booking_mast_log."Uom_code")AS "UOM",
               (SELECT "premiumname" FROM advpos_prem_mast WHERE "Premiumcode" =tbl_booking_mast_log."Page_type_code")AS "PagePremium",
                (SELECT "Pos_Type" FROM advpos_type_mast WHERE "Pos_Type_Code" =tbl_booking_mast_log."Page_position_code")AS "PositionPremium",
               (SELECT "Curr_Name"  FROM curr_mast WHERE "Curr_Code" =tbl_booking_mast_log."Currency_code") AS "Currency"
           FROM tbl_booking_mast_log, agency_mast
             WHERE tbl_booking_mast_log."Receipt_no" = ciobookid
            AND VSEQNO = VERSION1
            AND agency_mast."code_subcode" =
                                    tbl_booking_mast_log."Agency_sub_code"
            AND agency_mast."Comp_Code" = compcode;
*/
      OPEN p_accounts3 FOR
      SELECT 'A' AS A FROM DUAL;
--select * from tbl_booking_mast_log where cio_booking_id=@ciobookid and version=@version
       /*   SELECT TO_CHAR ("date_time", 'dd/mm/yyyy') AS "date_time", "branch",
                "booked_by", "cio_booking_id", "prev_booking", "applied_by",
                "audit", "RO_No",
                TO_CHAR ("RO_Date", 'dd/mm/yyyy') AS "RO_Date", "Caption",
                "bill_status", "ro_status",
                tbl_booking_mast_log."Agency_code", "Agency_address",
                "Client_code", "Client_address", "Agency_sub_code",
                "Dockit_no", "Executive_code", "Executive_zone",
                "Product_code", "Brand_code", "Key_no", "Bill_remarks",
                "Print_remark", "Package_code", "No_of_insertion",
                TO_CHAR ("Insertion_date", 'dd/mm/yyyy') AS "Insertion_date",
                "Repeating_day", "Ad_type_code", "Ad_cat_code",
                "Ad_sub_cat_code", "Color_code", "Uom_code",
                "Page_position_code", "Page_type_code", "Page_no",
                "Ad_size_type_code", "Ad_size_height", "Ad_size_width",
                "Rate_code", "Scheme_type_code", "Currency_code",
                "Agrred_rate", "Agreed_amount", "Special_discount",
                "Space_discount", "Special_charges",
                tbl_booking_mast_log."Comp_code",
                tbl_booking_mast_log."Userid",
                tbl_booking_mast_log."Agency_status", "Agency_type",
                "Agency_pay", "Agency_credit", "Total_area", "Card_rate",
                "Card_amount", "Discount", "Discount_per", "Bill_cycle",
                "Revenue_center", "Bill_pay", "Bill_height", "Bill_width",
                tbl_booking_mast_log."Bill_to", "Invoices", "Vts",
                "Bill_add", "Trade_disc", "Agency_out", "Booking_type",
                "Campaign", "Page_prem", "Page_amount", "Prem_per",
                "Gross_amount", "Bill_amount", "Box_code", "Box_no",
                "Box_agency", "Box_client", "Box_address", "Tfn", "Coupan_ad",
                "Ad_size_column", "Bill_column", "Bill_area",
                "Special_disc_per", "Space_disc_per",
                 agency_mast."Agency_Name" || '('|| agency_mast."code_subcode"|| ')' AS "AgencyName",
                (SELECT    exec_mast."Exec_name" || '('|| TO_CHAR (exec_mast."Exe_no")|| ')'
                   FROM exec_mast  WHERE tbl_booking_mast_log."Executive_code" = exec_mast."Exe_no"
                    AND tbl_booking_mast_log."Comp_code" = exec_mast."comp_code")AS "execname",
                (SELECT    product_cat_mast."prod_desc" || '(' || product_cat_mast."prod_cat_code" || ')'
                   FROM product_cat_mast WHERE tbl_booking_mast_log."Product_code" =product_cat_mast."prod_cat_code"
                    AND tbl_booking_mast_log."Comp_code" =product_cat_mast."comp_code")AS "product",
                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                "Contract_name", "Contract_type", "Card_name", "Card_type",
                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                "Bullet_code", "Bullet_premium",
                (SELECT "Agency_Name" FROM agency_mast WHERE "code_subcode" =tbl_booking_mast_log."Agency_sub_code")AS "AgencySubCode",
                NVL ((SELECT "Cust_Name" FROM cust_mast WHERE "Cust_Code" = "Client_code"),'' ) AS "Client",
                (SELECT "Payment_Mode_Name" FROM payment_mode_mast WHERE "Pay_Mode_Code" = "Agency_pay") AS "PayMode",
                (SELECT "Adv_Cat_Name" FROM adv_cat_mast WHERE adv_cat_mast."Adv_Cat_Code" =tbl_booking_mast_log."Ad_cat_code")AS "categoryname",
                (SELECT "Adv_Subcat_Name" FROM adv_subcat_mast WHERE adv_subcat_mast."Adv_Subcat_Code" =tbl_booking_mast_log."Ad_sub_cat_code")AS "subcategoryname",
                (SELECT "brand_name" FROM brand_mst WHERE "brand_code" =tbl_booking_mast_log."Brand_code")AS "Brand",
                (SELECT "Uom_Name" FROM uom_mast WHERE "Uom_Code" =tbl_booking_mast_log."Uom_code")AS "UOM",
                (SELECT "premiumname" FROM advpos_prem_mast  WHERE "Premiumcode" =tbl_booking_mast_log."Page_type_code")AS "PagePremium",
                (SELECT "Pos_Type" FROM advpos_type_mast WHERE "Pos_Type_Code" = tbl_booking_mast_log."Page_position_code")AS "PositionPremium",
                (SELECT "Curr_Name" FROM curr_mast WHERE "Curr_Code" =tbl_booking_mast_log."Currency_code")AS "Currency"
           FROM tbl_booking_mast_log, agency_mast
          WHERE tbl_booking_mast_log."Receipt_no" = ciobookid
            AND VSEQNO =(SELECT MAX (VSEQNO) FROM tbl_booking_mast_log WHERE "Receipt_no" = ciobookid AND VSEQNO <
            (SELECT MAX(VSEQNO) FROM tbl_booking_mast_log WHERE "Receipt_no" = ciobookid) AND "audit" IS NOT NULL)
                        AND agency_mast."code_subcode" =
             tbl_booking_mast_log."Agency_sub_code" AND agency_mast."Comp_Code" = compcode;
*/
   END executebooking_p;
END executebooking;
/

CREATE OR REPLACE PACKAGE BODY Executebookingdisp
IS
   PROCEDURE executebookingdisp_p (
      compcode      IN       VARCHAR2,
      ciobookid     IN       VARCHAR2,
      docno         IN       VARCHAR2 := NULL,
      keyno         IN       VARCHAR2 := NULL,
      rono          IN       VARCHAR2 := NULL,
      agencycode    IN       VARCHAR2 := NULL,
      client        IN       VARCHAR2 := NULL,
      booking       IN       VARCHAR2,
      dateformat     IN          VARCHAR2,
      revenue in varchar2,
      p_accounts    OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor,
      p_accounts2   OUT      t_accounts_cursor,
      P_Accounts3  OUT  T_Accounts_Cursor
    
   )
   AS
      VERSION1   NUMBER;
      count1    NUMBER;

   BEGIN

       DELETE FROM TEMPBOOKING_MAST;
        
      INSERT INTO TEMPBOOKING_MAST
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
                "Ad_size_height", "Ad_size_width", "Rate_code",
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
                "Logo_W", "Logo_color", "Logo_Uom",sapid,RETAINER,"ADD_AGENCY_COMM",MOBILENO,ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,CASH_RECIEVED,
                CIRAGENCY,CIRRATE,CIREDITION,CIRPUBLICATION,CIRAGENCY_SUBCODE,BARTER_TYPE,CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, CHKTRADEDISC,
                CHK_DATE, CHK_AMT, CHK_BANK_NAME, OUR_BANK, CHK_NO,DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT,
                LOCALGROSSAMT,LOCALBILLAMT,PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE
           FROM TBL_BOOKING_MAST
          WHERE ("Comp_code" = compcode OR compcode IS NULL)
            AND (("cio_booking_id" = ciobookid OR ciobookid IS NULL
                ) OR("Receipt_no"=ciobookid OR ciobookid IS NULL))
            AND ("Dockit_no" = docno  OR docno IS NULL)
            AND ("Key_no" = keyno  OR keyno IS NULL)
            AND ("RO_No" = rono  OR rono IS NULL)
            AND ("Agency_sub_code" LIKE agencycode || '%'
                 OR agencycode IS NULL
                )
            AND ("Client_code" LIKE client || '%' OR client IS NULL)
            AND ("Ad_type_code" = booking  OR booking IS NULL)
            AND "branch" in(SELECT LTRIM(RTRIM(BRANCH_CODE)) FROM LOGIN_BRANCH_MAST WHERE USER_CODE=revenue and COMP_CODE=compcode and USER_FLAG='Y')
         --AND "branch"=revenue 
            ;

  -- Dbms_output.put_line('rinki--');
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
                "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code",
                (SELECT "Scheme_Name" FROM SCHEME_MASTER WHERE "Comp_code"=compcode and "scheme_id" =TEMPBOOKING_MAST."Scheme_type_code")AS "Scheme_type_code",
                 "Currency_code", "Agrred_rate", "Agreed_amount",
                "Special_discount", "Space_discount", "Special_charges",
                TEMPBOOKING_MAST."Comp_code", TEMPBOOKING_MAST."Userid",
                TEMPBOOKING_MAST."Agency_status", "Agency_type", "Agency_pay",
                "Agency_credit", "Total_area", "Card_rate", "Card_amount",
                "Discount", "Discount_per", "Bill_cycle", "Revenue_center",
                "Bill_pay", "Bill_height", "Bill_width",
                TEMPBOOKING_MAST."Bill_to", "Invoices", "Vts", "Bill_add",
                "Trade_disc", "Agency_out", "Booking_type", "Campaign",
                "Page_prem", "Page_amount", "Prem_per", "Gross_amount",
                "Bill_amount", "Box_code", "Box_no", "Box_agency",
                "Box_client", "Box_address", "Tfn", "Coupan_ad",
                "Ad_size_column", "Bill_column", "Bill_area",
                "Special_disc_per", "Space_disc_per",
                AGENCY_MAST."Agency_Name" || '(' || AGENCY_MAST."code_subcode" || ')' AS "AgencyName",
                (SELECT EXEC_MAST."Exec_name" || '(' || TO_CHAR(EXEC_MAST."Exe_no") || ')' FROM EXEC_MAST
                  WHERE TEMPBOOKING_MAST."Executive_code" = EXEC_MAST."Exe_no"
                    AND TEMPBOOKING_MAST."Comp_code" = EXEC_MAST."comp_code" and TEMPBOOKING_MAST."Comp_code"=compcode) AS "execname",
                    --91
                (SELECT  PRODUCT_CAT_MAST."prod_desc" || '(' || PRODUCT_CAT_MAST."prod_cat_code" || ')' FROM PRODUCT_CAT_MAST
                  WHERE TEMPBOOKING_MAST."Product_code" = PRODUCT_CAT_MAST."prod_cat_code"
                    AND TEMPBOOKING_MAST."Comp_code" = PRODUCT_CAT_MAST."comp_code" and TEMPBOOKING_MAST."Comp_code"=compcode) AS "product",
                    --92
                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                 (select "deal_name" from contract_mast where "Deal_No"= (select "deal_code" from contract_detail where "ContractCode"= "Contract_name")) as "Contract_name", "Contract_type", "Card_name", "Card_type",
                --100
                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                "Bullet_code", "Bullet_premium",
                (SELECT "Agency_Name" FROM AGENCY_MAST WHERE "code_subcode" =TEMPBOOKING_MAST."Agency_sub_code" and agency_mast."Comp_Code"=compcode) AS "AgencySubCode",
              --111
                NVL ((SELECT DISTINCT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code" = "Client_code" and "Comp_Code"=compcode), '') AS "Client",                                       --112
                (SELECT DISTINCT "Payment_Mode_Name" FROM PAYMENT_MODE_MAST WHERE "Pay_Mode_Code" = "Agency_pay" and "Comp_Code"=compcode) AS "PayMode",
                (SELECT DISTINCT "Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code" =TEMPBOOKING_MAST."Ad_cat_code" and "Comp_Code"=compcode) AS "categoryname",
                (SELECT DISTINCT "Adv_Subcat_Name" FROM ADV_SUBCAT_MAST  WHERE ADV_SUBCAT_MAST."Adv_Subcat_Code" =TEMPBOOKING_MAST."Ad_sub_cat_code" and "Comp_Code"=compcode)
                 AS "subcategoryname",
                (SELECT DISTINCT "brand_name" FROM BRAND_MST WHERE "brand_code" =TEMPBOOKING_MAST."Brand_code" and "comp_code"=compcode) AS "Brand",
                (SELECT DISTINCT "Uom_Name" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST."Uom_code" and "Comp_Code"=compcode) AS "UOM",
                (SELECT "premiumname" FROM ADVPOS_PREM_MAST WHERE "Premiumcode" =TEMPBOOKING_MAST."Page_prem" and "comp_code"=compcode) AS "PagePremium",
                 (SELECT DISTINCT "Pos_Type" FROM ADVPOS_TYPE_MAST
                  WHERE "Pos_Type_Code" = TEMPBOOKING_MAST."Page_position_code" and "Comp_Code"=compcode) AS "PositionPremium",
                (SELECT DISTINCT "Curr_Name" FROM CURR_MAST WHERE "Curr_Code" = TEMPBOOKING_MAST."Currency_code" and "Comp_Code"=compcode) AS "Currency",
                "Material_status", TO_CHAR("Receipt_date",'dd/mm/yyyy') AS "Receipt_date", TEMPBOOKING_MAST."Region",
                "Variant", "Colortype",
                (SELECT DISTINCT "UOM_DESC" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST."Uom_code" and "Comp_Code"=compcode) AS "uom_desc",
                (SELECT DISTINCT "Logo" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST."Uom_code" and "Comp_Code"=compcode) AS "logo","Logo_H", "Logo_W", "Logo_color", "Logo_Uom",
                (SELECT DISTINCT "Logo_Uom" FROM UOM_MAST WHERE "Uom_Code" = TEMPBOOKING_MAST."Uom_code" and "Comp_Code"=compcode)  AS "logocode",
                (SELECT DISTINCT "Box_Charges_Native" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING_MAST."Box_code" and "Comp_Code"=compcode) AS "boxchrg",TEMPBOOKING_MAST.sapid,
                retainer,(SELECT "Retain_Name"||'('||"Retain_Code"||')' FROM RETAINERMASTER WHERE RETAINERMASTER."Retain_Code"=TEMPBOOKING_MAST.RETAINER and "Comp_Code"=compcode) AS "RETAINER1",
                (SELECT DISTINCT "Package_Name" FROM combin_mast WHERE "Combin_Code" =

TEMPBOOKING_MAST."Package_code" and "Comp_Code"=compcode) as "Package_cod",(SELECT DISTINCT "Col_Name" FROM col_mast WHERE "Col_Code" = TEMPBOOKING_MAST."Color_code" and "Comp_Code"=compcode) as

"Color_cod",(SELECT DISTINCT "Pos_Type" FROM advpos_type_mast WHERE "Pos_Type_Code" =

TEMPBOOKING_MAST."Page_position_code" and "Comp_Code"=compcode) as "Page_position_cod",
decode(TEMPBOOKING_MAST."Booking_type",'1','BARTER','2','FMG','3','NORMAL','4','INHOUSE') as "Book_type",
(SELECT DISTINCT "catname"  FROM  AD_CAT3   WHERE

AD_CAT3."catcode"=TEMPBOOKING_MAST."Ad_Subcat3" and "compcode"=compcode)  as "Subcat3",(SELECT DISTINCT "Cat_Name"  FROM  TBL_CAT4   WHERE

TBL_CAT4."Cat_Code"=TEMPBOOKING_MAST."Ad_Subcat4" and "Comp_Code"=compcode) as "Subcat4",(SELECT DISTINCT "Cat_Name"  FROM  TBL_CAT5   WHERE

TBL_CAT5."Cat_Code"=TEMPBOOKING_MAST."Ad_subcat5" and "Comp_Code"=compcode) as "subcat5",(SELECT DISTINCT "Comm_Rate" FROM ret_comm_details WHERE

ret_comm_details."Retain_Code"=TEMPBOOKING_MAST.RETAINER and "Comp_code"=compcode and rowid=(select max(rowid) from ret_comm_details where ret_comm_details."Retain_Code"=TEMPBOOKING_MAST.RETAINER and "Comp_code"=compcode)) AS "RETAINER_COMM",(select AUDIT_COMMENT from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=TEMPBOOKING_MAST."cio_booking_id" and tbl_booking_mast."Comp_code"=compcode) as "remarks","ADD_AGENCY_COMM",
 (SELECT DISTINCT "Box_Charges_Type" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING_MAST."Box_code" and "Comp_code"=compcode) AS "boxchargetype",
 ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,TEMPBOOKING_MAST."Scheme_type_code" as "SCHEMEID",TEMPBOOKING_MAST.CASH_RECIEVED,
 (select DISTINCT "pub_center" from branch_mst where "Branch_Code"=tempbooking_mast."branch" and "Comp_Code"=compcode) as "pub_center",
  CIRAGENCY,CIRRATE,CIREDITION,CIRPUBLICATION,CIRAGENCY_SUBCODE,BARTERTYPE,(SELECT BARTE_DESC FROM AD_BARTER WHERE COMP_CODE=compcode AND BARTER_CODE=TEMPBOOKING_MAST.BARTERTYPE) AS BARTE_DESC,
  (SELECT DISTINCT BARTER_AMOUNT FROM AD_BARTER WHERE COMP_CODE=compcode AND  BARTER_CODE=TEMPBOOKING_MAST.BARTERTYPE) AS BARTE_AMOUNT,
  (SELECT DISTINCT ADDITIONAL_FLAG  FROM COMM_DETAILS WHERE "Agency_code"||"Agency_sub_code"=TEMPBOOKING_MAST."Agency_sub_code"
 and "Comp_Code"=upper(compcode) and SYSDATE between "Eff_from_Date" and "Eff_Till_Date" AND ROWNUM<=1) AS ADDFLAG,
  CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, CHKTRADE, CASE dateformat
                     WHEN 'mm/dd/yyyy' THEN TO_CHAR(CHK_DATE,'mm/dd/yyyy')
                  WHEN 'dd/mm/yyyy' THEN TO_CHAR(CHK_DATE,'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd' THEN TO_CHAR(CHK_DATE,'yyyy/mm/dd')  END as CHK_DATE, CHK_AMT, CHK_BANK_NAME, OUR_BANK, CHK_NO, agency_mast.BOOKING_TYPE,
                     DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,MOBILENO,
                     (select "Comm_Rate" from comm_details where "Agency_code" || "Agency_sub_code"=TEMPBOOKING_MAST."Agency_sub_code"
 and "Comp_Code"=upper(compcode) and SYSDATE between "Eff_from_Date" and "Eff_Till_Date" AND ROWNUM<=1 ) as COMM_RATE,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT, NVL(LOCALGROSSAMT,"Gross_amount") as LOCALGROSSAMT, NVL(LOCALBILLAMT,"Bill_amount") as LOCALBILLAMT
/*for Display and classified*/
           FROM TEMPBOOKING_MAST, AGENCY_MAST
          WHERE AGENCY_MAST."code_subcode" =
                                            TEMPBOOKING_MAST."Agency_sub_code"
            AND AGENCY_MAST."Comp_Code" = compcode ORDER BY "Creation_datetime";


      Dbms_output.put_line('rinki--');
----------------------------------------------------Lata------------------------------------------------------

      OPEN p_accounts1 FOR
      SELECT 'A' AS A FROM DUAL;
    /*     SELECT NVL(COUNT (*),'0') AS "count"
                     FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" = ciobookid AND "audit" IS NOT NULL;

      BEGIN
         SELECT MAX (VSEQNO) INTO VERSION1 FROM TBL_BOOKING_MAST_LOG
          WHERE "Receipt_no" = ciobookid AND VSEQNO < (SELECT MAX (VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" = ciobookid);
            EXCEPTION WHEN NO_DATA_FOUND THEN NULL;
      END;
*/
      OPEN p_accounts2 FOR
      SELECT 'A' AS A FROM DUAL;
         /*SELECT    CASE dateformat
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
               -- TO_CHAR ("Insertion_date", 'dd/mm/yyyy') AS "Insertion_date",
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
                    AND TBL_BOOKING_MAST_LOG."Comp_code" =EXEC_MAST."comp_code" and "comp_code"=compcode)AS "execname",
               (SELECT    PRODUCT_CAT_MAST."prod_desc"|| '('|| PRODUCT_CAT_MAST."prod_cat_code" || ')'
                   FROM PRODUCT_CAT_MAST WHERE TBL_BOOKING_MAST_LOG."Product_code" =PRODUCT_CAT_MAST."prod_cat_code"
                    AND TBL_BOOKING_MAST_LOG."Comp_code" =PRODUCT_CAT_MAST."comp_code")                                                                 AS "product",
                "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                "Contract_name", "Contract_type", "Card_name", "Card_type",
                "Card_month", "Card_year", "Card_number", "Receipt_no",
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
                (SELECT "Agency_Name" FROM AGENCY_MAST WHERE "code_subcode" = TBL_BOOKING_MAST_LOG."Agency_sub_code" and "Comp_Code"=compcode)AS "AgencySubCode",
               NVL ((SELECT "Cust_Name"  FROM CUST_MAST WHERE "Cust_Code" = "Client_code" and "Comp_Code"=compcode),'' ) AS "Client",
              (SELECT "Payment_Mode_Name"  FROM PAYMENT_MODE_MAST WHERE "Pay_Mode_Code" = "Agency_pay" and "Comp_Code"=compcode) AS "PayMode",
               (SELECT "Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code" =TBL_BOOKING_MAST_LOG."Ad_cat_code" and "Comp_Code"=compcode)AS "categoryname",
               (SELECT "Adv_Subcat_Name"  FROM ADV_SUBCAT_MAST WHERE ADV_SUBCAT_MAST."Adv_Subcat_Code" =TBL_BOOKING_MAST_LOG."Ad_sub_cat_code" and "Comp_Code"=compcode)
                 AS "subcategoryname",
               (SELECT "brand_name"  FROM BRAND_MST   WHERE "brand_code" = TBL_BOOKING_MAST_LOG."Brand_code" and "comp_code"=compcode)AS "Brand",
               (SELECT "Uom_Name" FROM UOM_MAST WHERE "Uom_Code" =TBL_BOOKING_MAST_LOG."Uom_code" and "Comp_Code"=compcode)AS "UOM",
               (SELECT "premiumname" FROM ADVPOS_PREM_MAST WHERE "Premiumcode" =TBL_BOOKING_MAST_LOG."Page_type_code" and "comp_code"=compcode)AS "PagePremium",
                (SELECT "Pos_Type" FROM ADVPOS_TYPE_MAST WHERE "Pos_Type_Code" =TBL_BOOKING_MAST_LOG."Page_position_code" and "Comp_Code"=compcode)AS "PositionPremium",
               (SELECT "Curr_Name"  FROM CURR_MAST WHERE "Curr_Code" =TBL_BOOKING_MAST_LOG."Currency_code" and "Comp_Code"=compcode) AS "Currency"
           FROM TBL_BOOKING_MAST_LOG, AGENCY_MAST
             WHERE TBL_BOOKING_MAST_LOG."Receipt_no" = ciobookid
            AND VSEQNO = VERSION1
            AND AGENCY_MAST."code_subcode" =
                                    TBL_BOOKING_MAST_LOG."Agency_sub_code"
            AND AGENCY_MAST."Comp_Code" = compcode;
*/
      OPEN p_accounts3 FOR
      SELECT 'A' AS A FROM DUAL;
--select * from tbl_booking_mast_log where cio_booking_id=@ciobookid and version=@version
      /*   SELECT    CASE dateformat
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
                (SELECT "Agency_Name" FROM AGENCY_MAST WHERE "code_subcode" =TBL_BOOKING_MAST_LOG."Agency_sub_code" and "Comp_Code"=compcode)AS "AgencySubCode",
                NVL ((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code" = "Client_code" and "Comp_Code"=compcode),'' ) AS "Client",
                (SELECT "Payment_Mode_Name" FROM PAYMENT_MODE_MAST WHERE "Pay_Mode_Code" = "Agency_pay" and "Comp_Code"=compcode) AS "PayMode",
                (SELECT "Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code" =TBL_BOOKING_MAST_LOG."Ad_cat_code" and "Comp_Code"=compcode)AS "categoryname",
                (SELECT "Adv_Subcat_Name" FROM ADV_SUBCAT_MAST WHERE ADV_SUBCAT_MAST."Adv_Subcat_Code" =TBL_BOOKING_MAST_LOG."Ad_sub_cat_code" and "Comp_Code"=compcode)AS "subcategoryname",
                (SELECT "brand_name" FROM BRAND_MST WHERE "brand_code" =TBL_BOOKING_MAST_LOG."Brand_code" and "comp_code"=compcode)AS "Brand",
                (SELECT "Uom_Name" FROM UOM_MAST WHERE "Uom_Code" =TBL_BOOKING_MAST_LOG."Uom_code" and "Comp_Code"=compcode)AS "UOM",
                (SELECT "premiumname" FROM ADVPOS_PREM_MAST  WHERE "Premiumcode" =TBL_BOOKING_MAST_LOG."Page_type_code" and "comp_code"=compcode)AS "PagePremium",
                (SELECT "Pos_Type" FROM ADVPOS_TYPE_MAST WHERE "Pos_Type_Code" = TBL_BOOKING_MAST_LOG."Page_position_code" and "Comp_Code"=compcode)AS "PositionPremium",
                (SELECT "Curr_Name" FROM CURR_MAST WHERE "Curr_Code" =TBL_BOOKING_MAST_LOG."Currency_code" and "Comp_Code"=compcode)AS "Currency"
           FROM TBL_BOOKING_MAST_LOG, AGENCY_MAST
          WHERE TBL_BOOKING_MAST_LOG."Receipt_no" = ciobookid
            AND VSEQNO =(SELECT MAX (VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" = ciobookid AND VSEQNO <
            (SELECT MAX(VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE "Receipt_no" = ciobookid) AND "audit" IS NOT NULL)
                        AND AGENCY_MAST."code_subcode" =
             TBL_BOOKING_MAST_LOG."Agency_sub_code" AND AGENCY_MAST."Comp_Code" = compcode;
             */
            -- open P_Accounts4 for 
             -- select CASHAMOUNT as "cashreceived" from tbl_cashreceiptdetail where BOOKING_ID =ciobookid ; -- and RECEIPTNO=

   END executebookingdisp_p;
END Executebookingdisp;
/


/*********************** Lata  22/11/2011  *******************/
////////////////////////////issue number    5708
CREATE OR REPLACE PACKAGE Bindaudit
IS
  TYPE T_ACCOUNT_CURSOR IS REF CURSOR;

  PROCEDURE bindaudit_p(fromdate IN VARCHAR2,todate IN VARCHAR2,date1 IN VARCHAR2,BRANCH1 IN VARCHAR2,Adtype IN VARCHAR2,
  audittype IN VARCHAR2
  ,branch2 IN VARCHAR2,
  v_Cat in varchar2,
  v_userid in varchar2,
  comp_code in varchar2:=null,
  v_package_code in varchar2,
  P_ACCOUNT OUT T_ACCOUNT_CURSOR);
END Bindaudit;
/
CREATE OR REPLACE PACKAGE BODY bindaudit
IS
   PROCEDURE bindaudit_p (
      fromdate    IN       VARCHAR2,
      todate      IN       VARCHAR2,
      date1       IN       VARCHAR2,
      branch1     IN       VARCHAR2,
      adtype      IN       VARCHAR2,
      audittype   IN       VARCHAR2,
      branch2     IN       VARCHAR2,
      v_cat       IN       VARCHAR2,
      v_userid    IN       VARCHAR2,
      comp_code   in varchar2:=null,
      v_package_code in varchar2,
      p_account   OUT      t_account_cursor
   )
   AS
   RELAUTHREQ  varchar2(1);
   BEGIN
   select RELAUTHREQON INTO RELAUTHREQ from preferrences where ("comp_code"=comp_code or comp_code is null) ;
      INSERT INTO test1
                  (vstring
                  )
           VALUES (   'fromdate '
                   || fromdate
                   || ' todate '
                   || todate
                   || ' date1 '
                   || date1
                   || ' BRANCH1 '
                   || branch1
                   || ' Adtype '
                   || adtype
                   || ' audittype '
                   || audittype
                   || ' branch2 '
                   || branch2
                   || ' v_Cat '
                   || v_cat
                   || ' v_userid '
                   || v_userid
                  );

      COMMIT;
  
      IF audittype = 'audit'
      THEN
        IF RELAUTHREQ = 'A' THEN
                 IF (branch1 = 'All' AND branch2 IS NULL)
                 THEN
                    OPEN p_account FOR
                       SELECT distinct "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                          and tbl_booking_mast.APP_STATUS='Y'    
                          AND tbl_booking_mast."branch" IN (
                                 SELECT branch_mst."Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                              )
                                              and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                              
                                              and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                              ;
                 ELSE
                    OPEN p_account FOR
                       SELECT distinct "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "branch" IN (
                                 SELECT "Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                    AND "pub_center" = branch1)
                           and tbl_booking_mast.APP_STATUS='Y'            
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL)
                            and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                          ;
                 END IF;
        ELSIF RELAUTHREQ ='D' THEN
                 IF (branch1 = 'All' AND branch2 IS NULL)
                 THEN
                    OPEN p_account FOR
                       SELECT distinct "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                          and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')    
                          AND tbl_booking_mast."branch" IN (
                                 SELECT branch_mst."Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                                and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"                                           
                                              )
                                                  and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                              ;
                 ELSE
                    OPEN p_account FOR
                       SELECT distinct "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "branch" IN (
                                 SELECT "Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                    AND "pub_center" = branch1)
                          and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')          
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                              
                                and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                    and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                ;
                 END IF;
        ELSE
            IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT distinct "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NOT NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                      
                                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         ELSE
            OPEN p_account FOR
               SELECT distinct "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NOT NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                      
                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                        
                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         END IF;
        END IF;
         
      END IF;

      IF audittype = 'unaudit'
      THEN
      IF RELAUTHREQ = 'A' THEN
        IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT  distinct "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                   and tbl_booking_mast.APP_STATUS='Y'     
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         -- SELECT "cio_booking_id",nvl((select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code","audit","Ad_type_code",(select "File_Name" from tbl_booking_insert where "Cio_Booking_Id"=tbl_booking_mast."cio_booking_id" and "File_Name" is not null and rownum<=1) as "FILENAME" FROM TBL_BOOKING_MAST WHERE  "date_time" BETWEEN fromdate AND todate AND "Ad_type_code"=Adtype AND "audit" IS  NULL and ("branch"=branch2 OR  branch2 IS NULL) and (tbl_booking_mast."Ad_cat_code"=v_Cat OR  v_Cat IS NULL);
         ELSE
            OPEN p_account FOR
               SELECT distinct "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                   and tbl_booking_mast.APP_STATUS='Y'           
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                      
                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         END IF;
      ELSIF RELAUTHREQ = 'D' THEN
        IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT distinct "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')    
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                      
                                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         -- SELECT "cio_booking_id",nvl((select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code","audit","Ad_type_code",(select "File_Name" from tbl_booking_insert where "Cio_Booking_Id"=tbl_booking_mast."cio_booking_id" and "File_Name" is not null and rownum<=1) as "FILENAME" FROM TBL_BOOKING_MAST WHERE  "date_time" BETWEEN fromdate AND todate AND "Ad_type_code"=Adtype AND "audit" IS  NULL and ("branch"=branch2 OR  branch2 IS NULL) and (tbl_booking_mast."Ad_cat_code"=v_Cat OR  v_Cat IS NULL);
         ELSE
            OPEN p_account FOR
               SELECT distinct "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast ,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                  and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')          
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                      
                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                        
                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         END IF;
      ELSE
        IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT  distinct "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                            and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                          and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         -- SELECT "cio_booking_id",nvl((select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code","audit","Ad_type_code",(select "File_Name" from tbl_booking_insert where "Cio_Booking_Id"=tbl_booking_mast."cio_booking_id" and "File_Name" is not null and rownum<=1) as "FILENAME" FROM TBL_BOOKING_MAST WHERE  "date_time" BETWEEN fromdate AND todate AND "Ad_type_code"=Adtype AND "audit" IS  NULL and ("branch"=branch2 OR  branch2 IS NULL) and (tbl_booking_mast."Ad_cat_code"=v_Cat OR  v_Cat IS NULL);
         ELSE
            OPEN p_account FOR
               SELECT distinct "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                      
                          and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"  
                          and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
                      
         END IF;
      END IF;
         
      END IF;

      IF audittype != 'unaudit' AND audittype != 'audit'
      THEN
        IF RELAUTHREQ = 'A' THEN
                     IF (branch1 = 'All')
                     THEN
                        OPEN p_account FOR
                           SELECT  distinct "cio_booking_id",
                                  NVL ((SELECT "Cust_Name"
                                          FROM cust_mast
                                         WHERE "Cust_Code" = "Client_code"),
                                       "Client_code"
                                      ) AS "Client_code",
                                  "audit", "Ad_type_code",
                                  (SELECT "File_Name"
                                     FROM tbl_booking_insert
                                    WHERE "Cio_Booking_Id" =
                                             tbl_booking_mast."cio_booking_id"
                                      AND "File_Name" IS NOT NULL
                                      AND ROWNUM <= 1) AS "FILENAME",
                                  CASE date1
                                     WHEN 'mm/dd/yyyy'
                                        THEN TO_CHAR
                                               ("Creation_datetime",
                                                'mm/dd/yyyy'
                                               )
                                     WHEN 'dd/mm/yyyy'
                                        THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                     WHEN 'yyyy/mm/dd'
                                        THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                                  END AS "Creation_datetime"
                             FROM tbl_booking_mast,tbl_booking_insert
                            WHERE "date_time" BETWEEN fromdate AND todate
                              AND "Ad_type_code" = adtype
                              AND ("branch" = branch2 OR branch2 IS NULL)
                              AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                                  )
                             and tbl_booking_mast.APP_STATUS='Y'     
                              AND tbl_booking_mast."branch" IN (
                                     SELECT branch_mst."Branch_Name"
                                       FROM branch_mst
                                      WHERE branch_mst."Branch_Code" IN (
                                               SELECT lb.branch_code
                                                 FROM login_branch_mast lb
                                                WHERE lb.user_code = v_userid
                                                  AND NVL (lb.user_flag, 'N') = 'Y'))
                                                     and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"  
                                                  and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
                                                  
                                                  
                     ELSE
                        OPEN p_account FOR
                           SELECT distinct "cio_booking_id",
                                  NVL ((SELECT "Cust_Name"
                                          FROM cust_mast
                                         WHERE "Cust_Code" = "Client_code"),
                                       "Client_code"
                                      ) AS "Client_code",
                                  "audit", "Ad_type_code",
                                  (SELECT "File_Name"
                                     FROM tbl_booking_insert
                                    WHERE "Cio_Booking_Id" =
                                             tbl_booking_mast."cio_booking_id"
                                      AND "File_Name" IS NOT NULL
                                      AND ROWNUM <= 1) AS "FILENAME",
                                  CASE date1
                                     WHEN 'mm/dd/yyyy'
                                        THEN TO_CHAR
                                               ("Creation_datetime",
                                                'mm/dd/yyyy'
                                               )
                                     WHEN 'dd/mm/yyyy'
                                        THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                     WHEN 'yyyy/mm/dd'
                                        THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                                  END AS "Creation_datetime"
                             FROM tbl_booking_mast, tbl_booking_insert
                            WHERE "date_time" BETWEEN fromdate AND todate
                              AND "branch" IN (
                                     SELECT "Branch_Code"
                                       FROM branch_mst
                                      WHERE branch_mst."Branch_Code" IN (
                                               SELECT lb.branch_code
                                                 FROM login_branch_mast lb
                                                WHERE lb.user_code = v_userid
                                                  AND NVL (lb.user_flag, 'N') = 'Y')
                                        AND "pub_center" =
                                                        (SELECT "Pub_cent_Code"
                                                           FROM pub_cent_mast
                                                          WHERE "Pub_cent_Code" = branch1))
                              and tbl_booking_mast.APP_STATUS='Y'                            
                              AND "Ad_type_code" = adtype
                              AND ("branch" = branch2 OR branch2 IS NULL)
                              AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                                  )  and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                  and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
                                  
                     END IF;
        ELSIF RELAUTHREQ = 'D' THEN
                 IF (branch1 = 'All')
                 THEN
                    OPEN p_account FOR
                       SELECT distinct "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "Ad_type_code" = adtype
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                          and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')    
                          AND tbl_booking_mast."branch" IN (
                                 SELECT branch_mst."Branch_Name"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y'))
                                                and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                                and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
                                                
                 ELSE
                    OPEN p_account FOR
                       SELECT distinct "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "branch" IN (
                                 SELECT "Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                    AND "pub_center" =
                                                    (SELECT "Pub_cent_Code"
                                                       FROM pub_cent_mast
                                                      WHERE "Pub_cent_Code" = branch1))
                          AND "Ad_type_code" = adtype
                            and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A') 
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                                and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                              and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
                 END IF;
        ELSE
             IF (branch1 = 'All')
         THEN
            OPEN p_account FOR
               SELECT distinct  "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Name"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                        and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         ELSE
            OPEN p_account FOR
               SELECT distinct  "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" =
                                            (SELECT "Pub_cent_Code"
                                               FROM pub_cent_mast
                                              WHERE "Pub_cent_Code" = branch1))
                  AND "Ad_type_code" = adtype
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                        
                        and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         END IF;
        END IF;
        
      END IF;
   END bindaudit_p;
END bindaudit;
/

///////////////////////garima 23 nov



/*************************************************0005704*****mimoh 24 nov*********************************/



CREATE OR REPLACE PACKAGE ptexe is
Type T_Accounts_Cursor Is Ref Cursor;
procedure ptexe_p
(
drppublication in varchar2,
pagetypecode in varchar2,
pagename in varchar2,
height in varchar2,
width in varchar2,
nocolumns in varchar2,
compcode in varchar2,
p_Accounts Out T_Accounts_Cursor
);
end ptexe;
/





CREATE OR REPLACE PACKAGE BODY ptexe is

procedure ptexe_p
(
drppublication in varchar2,
pagetypecode in varchar2,
pagename in varchar2,
height in varchar2,
width in varchar2,
nocolumns in varchar2,
compcode in varchar2,
p_Accounts Out T_Accounts_Cursor
)
as
begin


open p_Accounts for
--select "Comp_Code","publication" ,"PageTypeCode","PageName","Height","Width", "NoColumns" from PageType
select * from PageType
where ("Comp_Code"=compcode or compcode is null)
and ("publication" like drppublication || '%' or drppublication is null)
and ("PageTypeCode" like pagetypecode || '%' or pagetypecode is null)
and ("PageName" like pagename ||'%' or pagename is null)
and ("Height" like height || '%' or height is null)
and ("Width" like width || '%' or width is null)
and ("NoColumns" like nocolumns || '%' or nocolumns is null);





end ptexe_p;
 end ptexe;
/


/*********************************************0005704*********mimoh 24 nov*********************************/
/////////////////////
CREATE OR REPLACE PROCEDURE Websp_Selectvaluesnew
(
ciobooking IN  VARCHAR2,
editionname IN  VARCHAR2,
compcode  IN  VARCHAR2,
insertion IN  VARCHAR2,
dateformat IN VARCHAR2,
p_getbookingrecord OUT Cur_Type_New1.cursor_type,
p_accounts1 OUT Cur_Type_New1.cursor_type,
P_ACCOUNTS2 OUT Cur_Type_New1.cursor_type

)


IS
str   VARCHAR(10000);
package_cd   VARCHAR(300);
package_result   VARCHAR(300);
package_cd1   VARCHAR(300);
A NUMBER;

BEGIN

str :='SELECT DISTINCT TBL_BOOKING_MAST."cio_booking_id" AS "CIOID",
AGENCY_MAST."Agency_Name" AS "Agency",
PUB_MAST."Pub_Name" AS "Pub",
PUB_MAST."Pub_Name"AS "Pub"
,TBL_BOOKING_INSERT."Height" AS "Depth"
,TBL_BOOKING_INSERT."Width" AS "Width"
, COL_MAST."Col_Alias" AS "Hue"
,TBL_BOOKING_INSERT."No_Insert" AS "Ins.No."
  ,"RO_No" AS "RoNo.",
TBL_BOOKING_MAST."Card_amount" AS "Amt"
,TBL_BOOKING_INSERT."Disc_Rate" AS "Disc",
(SELECT ADVPOS_TYPE_MAST."Pos_Type" FROM ADVPOS_TYPE_MAST WHERE ADVPOS_TYPE_MAST."Pos_Type_Code"=TBL_BOOKING_INSERT."Page_Post" ) AS "pageposition",
(SELECT ADV_TYPE_MAST."Adv_Type_Name" FROM ADV_TYPE_MAST  WHERE ADV_TYPE_MAST."Adv_Type_Code"=TBL_BOOKING_MAST."Ad_type_code" ) AS "AdType",
TBL_BOOKING_INSERT."Size_Book" AS "Volume",

case nvl("Agrred_rate",0)
when 0 then "Card_rate"
else "Agrred_rate" end as "package rate",

 --nvl(TBL_BOOKING_MAST."Agrred_rate",TBL_BOOKING_MAST."Card_rate") as "package rate",

TBL_BOOKING_INSERT."Edition_Code" AS "Edition"
,nvl(substr(((SELECT DISTINCT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE  CUST_MAST."Cust_Code"=TBL_BOOKING_MAST."Client_code")),1,18),TBL_BOOKING_MAST."Client_code") AS "advertiser" ,
TBL_BOOKING_MAST."Agency_sub_code",TBL_BOOKING_MAST."Gross_amount",AGENCY_MAST."Add1" , CITY_MST."City_Name",
(SELECT BOX_MAST."Box_Charges_Native" FROM BOX_MAST  WHERE  TBL_BOOKING_MAST."Box_code"=BOX_MAST."Box_Code"
 ) AS "boxchares" ,
TBL_BOOKING_insert."Gross_Rate",
TBL_BOOKING_MAST."Creation_datetime",
(SELECT DISTINCT  "Package_Name" FROM COMBIN_MAST WHERE TBL_BOOKING_MAST."Package_code"=COMBIN_MAST."Combin_Code"  AND "Combin_Desc"='''||editionname||''' )AS "package_name",



nvl((SELECT DISTINCT CUST_MAST."Add1"  || "Stree" FROM CUST_MAST WHERE  CUST_MAST."Cust_Code"=TBL_BOOKING_MAST."Client_code" ),"Client_address") AS "clientAd",








NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "Client",
TBL_BOOKING_MAST."No_of_insertion",
CASE '''||dateformat||'''
 WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''yyyy/mm/dd'')  END AS "Ins.Date",
tbl_booking_insert."Edition" as"Page_No",
tbl_booking_insert ."Page_No" as "Page_insrt",
(SELECT "premiumname" FROM ADVPOS_PREM_MAST  WHERE   ADVPOS_PREM_MAST. "Premiumcode"=TBL_BOOKING_INSERT."Premium1"    )as "premiumname",
TBL_BOOKING_MAST."Special_discount",
TBL_BOOKING_MAST."Special_charges"
,TBL_BOOKING_MAST."Trade_disc",
(SELECT "premium_charges" FROM ADVPOS_PREM_MAST  WHERE   ADVPOS_PREM_MAST. "Premiumcode"=TBL_BOOKING_INSERT."Premium1" ) AS "premiumch",
TBL_BOOKING_INSERT."Card_Rate",

initcap(branch_mst."Add1") as "Add1" , branch_mst."Phone1", branch_mst."Phone2", branch_mst."Fax"  as "Fax1",


TBL_BOOKING_MAST."Key_no" AS "Key No",
TBL_BOOKING_MAST."Agency_type",
 lower(branch_mst."EmailID") as  "Email" ,
(select to_char((SELECT distinct AD_BILLS."BILDT" + (select distinct AGENCY_MAST."Credit_Days" from AGENCY_MAST where  AGENCY_MAST."code_subcode"=AD_BILLS."AGCODE" and AD_BILLS."IDNUM" =  '''||ciobooking||''')  FROM  AD_BILLS   WHERE AD_BILLS."IDNUM" =  '''||ciobooking||''' AND AGENCY_MAST."code_subcode"=AD_BILLS."AGCODE" and ad_bills.insnum= '''||insertion||''' ),''dd-Mon-yyyy'') from dual) AS "paydate",

(select to_char((SELECT SYSDATE + (SELECT DISTINCT AGENCY_MAST."Credit_Days" FROM AGENCY_MAST WHERE  AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code" AND TBL_BOOKING_MAST."cio_booking_id" =  '''||ciobooking||''' )  FROM  dual),''dd-Mon-yyyy'') from dual) as "paydatesys",
AGENCY_MAST."Add2",
AGENCY_MAST."Add3"
,tbl_booking_mast."Caption" as "Cap",

tbl_booking_insert."Insert_Id",

TBL_BOOKING_INSERT."Bill_Amt",

TBL_BOOKING_mast.ADD_AGENCY_COMM as "addcom",

tbl_booking_insert."Insert_Date" as  "insert_date",
branch_mst."Street" as "street",
tbl_booking_mast."Box_no",

CASE '''||dateformat||'''
 WHEN ''mm/dd/yyyy'' THEN TO_CHAR("BILL_DATE",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("BILL_DATE",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("BILL_DATE",''yyyy/mm/dd'')  END AS "BILL_DATE",

CASE '''||dateformat||'''
 WHEN ''mm/dd/yyyy'' THEN TO_CHAR(TBL_BOOKING_MAST."RO_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(TBL_BOOKING_MAST."RO_Date",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(TBL_BOOKING_MAST."RO_Date",''yyyy/mm/dd'')  END AS "RO_Date",
tbl_booking_mast."Bill_remarks",
(select "Scheme_Name"  from Scheme_Master where Scheme_Master."scheme_id"=tbl_booking_mast."Scheme_type_code" and Scheme_Master."Comp_code"=tbl_booking_mast."Comp_code" and rownum <=1) as "Scheme",

TBL_BOOKING_INSERT."Insert_Status" as "status"
FROM TBL_BOOKING_MAST,PUB_CENT_MAST,
TBL_BOOKING_INSERT,
AGENCY_MAST ,
PUB_MAST,
COL_MAST ,
CITY_MST,
RATE_MAST,branch_mst

 WHERE TBL_BOOKING_MAST ."Comp_code"='''||compcode||'''
 --AND TBL_BOOKING_MAST."Package_code" =RATE_MAST."Combin_Code"
AND TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
 AND TBL_BOOKING_MAST."Agency_code"=AGENCY_MAST."Agency_Code"
 AND TBL_BOOKING_INSERT."Col_Code"=COL_MAST."Col_Code"
  AND PUB_CENT_MAST."Pub_cent_Code"  =TBL_BOOKING_INSERT."Pub_Cent_Code"

  AND CITY_MST."City_Code"=AGENCY_MAST."City_Code"  AND TBL_BOOKING_INSERT."Publication_Code" = PUB_MAST."Pub_Code" AND   TBL_BOOKING_INSERT."Cio_Booking_Id"='''||ciobooking||''' AND   TBL_BOOKING_INSERT."No_Insert"='''||insertion||'''

  and branch_mst ."Branch_Code"=tbl_booking_mast ."branch"

  AND tbl_booking_insert."Edition"  ='''||editionname||'''';



/*str :='SELECT DISTINCT TBL_BOOKING_MAST."cio_booking_id" AS "CIOID",
AGENCY_MAST."Agency_Name" AS "Agency",
PUB_MAST."Pub_Name" AS "Pub",
PUB_MAST."Pub_Name"AS "Pub"
,TBL_BOOKING_INSERT."Height" AS "Depth"
,TBL_BOOKING_INSERT."Width" AS "Width"
, COL_MAST."Col_Alias" AS "Hue"
,TBL_BOOKING_INSERT."No_Insert" AS "Ins.No."
  ,"RO_No" AS "RoNo.",
TBL_BOOKING_MAST."Card_amount" AS "Amt"
,TBL_BOOKING_INSERT."Disc_Rate" AS "Disc",
(SELECT ADVPOS_TYPE_MAST."Pos_Type" FROM ADVPOS_TYPE_MAST,TBL_BOOKING_INSERT WHERE ADVPOS_TYPE_MAST."Pos_Type_Code"=TBL_BOOKING_INSERT."Page_Post" AND TBL_BOOKING_INSERT."Cio_Booking_Id"='''||ciobooking||''') AS "pageposition",
(SELECT ADV_TYPE_MAST."Adv_Type_Name" FROM ADV_TYPE_MAST,TBL_BOOKING_MAST WHERE ADV_TYPE_MAST."Adv_Type_Code"=TBL_BOOKING_MAST."Ad_type_code" AND TBL_BOOKING_MAST."cio_booking_id"='''||ciobooking||''') AS "AdType",
TBL_BOOKING_INSERT."Size_Book" AS "Volume",
TBL_BOOKING_MAST."Card_rate" AS "package rate",
TBL_BOOKING_INSERT."Edition_Code" AS "Edition"
,(SELECT DISTINCT CUST_MAST."Cust_Alias" FROM CUST_MAST ,TBL_BOOKING_MAST WHERE  CUST_MAST."Cust_Code"=TBL_BOOKING_MAST."Client_code" AND TBL_BOOKING_MAST."cio_booking_id"='''||ciobooking||''') AS "advertiser",
TBL_BOOKING_MAST."Agency_sub_code",TBL_BOOKING_MAST."Gross_amount",AGENCY_MAST."Add1" , CITY_MST."City_Name",
(SELECT BOX_MAST."Box_Charges_Native" FROM BOX_MAST  ,TBL_BOOKING_MAST WHERE  TBL_BOOKING_MAST."Box_code"=BOX_MAST."Box_Code"
AND TBL_BOOKING_MAST."cio_booking_id"='''||ciobooking||''' ) AS "boxchares" ,
TBL_BOOKING_Mast."Agreed_amount",
TBL_BOOKING_MAST."Creation_datetime",
(SELECT DISTINCT  "Package_Name" FROM COMBIN_MAST,TBL_BOOKING_MAST WHERE TBL_BOOKING_MAST."Package_code"=COMBIN_MAST."Combin_Code"  AND "Combin_Desc"='''||editionname||''' AND TBL_BOOKING_MAST."cio_booking_id"='''||ciobooking||''')AS "package_name",
(SELECT DISTINCT CUST_MAST."Add1" FROM CUST_MAST,TBL_BOOKING_MAST  WHERE  CUST_MAST."Cust_Code"=TBL_BOOKING_MAST."Client_code" AND TBL_BOOKING_MAST."cio_booking_id"='''||ciobooking||''') AS "clientAd",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "Client",
TBL_BOOKING_MAST."No_of_insertion",
CASE '''||dateformat||'''
 WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insertion_date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insertion_date",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insertion_date",''yyyy/mm/dd'')  END AS "Ins.Date",

TBL_BOOKING_INSERT. "Page_No",
(SELECT "premiumname" FROM ADVPOS_PREM_MAST,TBL_BOOKING_INSERT WHERE   ADVPOS_PREM_MAST. "Premiumcode"=TBL_BOOKING_INSERT."Premium1" AND   TBL_BOOKING_INSERT."Cio_Booking_Id"='''||ciobooking||''' AND   TBL_BOOKING_INSERT."No_Insert"='''||insertion||''' AND  TBL_BOOKING_INSERT."Edition"='''||editionname||''' ),
TBL_BOOKING_MAST."Special_discount",
TBL_BOOKING_MAST."Special_charges"
,TBL_BOOKING_MAST."Trade_disc",
(SELECT "premium_charges" FROM ADVPOS_PREM_MAST,TBL_BOOKING_INSERT WHERE   ADVPOS_PREM_MAST. "Premiumcode"=TBL_BOOKING_INSERT."Premium1" AND   TBL_BOOKING_INSERT."Cio_Booking_Id"='''||ciobooking||''' AND   TBL_BOOKING_INSERT."No_Insert"='''||insertion||''' AND  TBL_BOOKING_INSERT."Edition"='''||editionname||''') AS "premiumch",
TBL_BOOKING_INSERT."Card_Rate",
(SELECT PUB_CENT_MAST ."Add1" FROM PUB_CENT_MAST WHERE "Pub_Cent_name" =(SELECT RETAINERMASTER."Retain_Name" FROM RETAINERMASTER WHERE "Retain_Code"=TBL_BOOKING_MAST."Revenue_center" AND TBL_BOOKING_MAST."cio_booking_id" =  '''||ciobooking||''' )) as "Add1",
(SELECT PUB_CENT_MAST ."Phone1" FROM PUB_CENT_MAST WHERE "Pub_Cent_name" =(SELECT RETAINERMASTER."Retain_Name" FROM RETAINERMASTER WHERE "Retain_Code"=TBL_BOOKING_MAST."Revenue_center" AND TBL_BOOKING_MAST."cio_booking_id" =  '''||ciobooking||''' )) as "Phone1",
(SELECT PUB_CENT_MAST ."Phone2" FROM PUB_CENT_MAST WHERE "Pub_Cent_name" =(SELECT RETAINERMASTER."Retain_Name" FROM RETAINERMASTER WHERE "Retain_Code"=TBL_BOOKING_MAST."Revenue_center" AND TBL_BOOKING_MAST."cio_booking_id" =  '''||ciobooking||''')) as "Phone2",
(SELECT PUB_CENT_MAST ."Fax1" FROM PUB_CENT_MAST WHERE "Pub_Cent_name" =(SELECT RETAINERMASTER."Retain_Name" FROM RETAINERMASTER WHERE "Retain_Code"=TBL_BOOKING_MAST."Revenue_center" AND TBL_BOOKING_MAST."cio_booking_id" =  '''||ciobooking||''')) as "Fax1",

TBL_BOOKING_MAST."Key_no" AS "Key No",
TBL_BOOKING_MAST."Agency_type",
lower((SELECT PUB_CENT_MAST."EmailID" FROM PUB_CENT_MAST WHERE "Pub_Cent_name" =(SELECT RETAINERMASTER."Retain_Name" FROM RETAINERMASTER WHERE "Retain_Code"=TBL_BOOKING_MAST."Revenue_center" AND TBL_BOOKING_MAST."cio_booking_id" =  '''||ciobooking||''' )))as "Email",
(select to_char((SELECT distinct AD_BILLS."BILDT" + (select distinct AGENCY_MAST."Credit_Days" from AGENCY_MAST where  AGENCY_MAST."code_subcode"=AD_BILLS."AGCODE" and AD_BILLS."IDNUM" =  '''||ciobooking||''')  FROM  AD_BILLS   WHERE AD_BILLS."IDNUM" =  '''||ciobooking||''' AND AGENCY_MAST."code_subcode"=AD_BILLS."AGCODE" and ad_bills.insnum= '''||insertion||''' ),''dd-Mon-yyyy'') from dual) AS "paydate",

(select to_char((SELECT SYSDATE + (SELECT DISTINCT AGENCY_MAST."Credit_Days" FROM AGENCY_MAST WHERE  AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code" AND TBL_BOOKING_MAST."cio_booking_id" =  '''||ciobooking||''' )  FROM  dual),''dd-Mon-yyyy'') from dual) as "paydatesys"

FROM TBL_BOOKING_MAST,PUB_CENT_MAST,
TBL_BOOKING_INSERT,
AGENCY_MAST ,
PUB_MAST,
COL_MAST ,

CITY_MST,
RATE_MAST
 WHERE TBL_BOOKING_MAST ."Comp_code"='''||compcode||'''
 AND TBL_BOOKING_MAST."Package_code" =RATE_MAST."Combin_Code"
AND TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
 AND TBL_BOOKING_MAST."Agency_code"=AGENCY_MAST."Agency_Code"
 AND TBL_BOOKING_INSERT."Col_Code"=COL_MAST."Col_Code"
  AND PUB_CENT_MAST."Pub_cent_Code"  =TBL_BOOKING_INSERT."Pub_Cent_Code"

  AND CITY_MST."City_Code"=AGENCY_MAST."City_Code"  AND TBL_BOOKING_INSERT."Publication_Code" = PUB_MAST."Pub_Code" AND   TBL_BOOKING_INSERT."Cio_Booking_Id"='''||ciobooking||''' AND   TBL_BOOKING_INSERT."No_Insert"='''||insertion||'''

  AND tbl_booking_insert."Edition"  ='''||editionname||'''';
*/



delete from PACKAGE1;

 BEGIN
SELECT  "Package_code" INTO  package_cd1 FROM TBL_BOOKING_MAST WHERE "cio_booking_id"=ciobooking;
EXCEPTION WHEN NO_DATA_FOUND THEN NULL; END;


A:=Fn_Splitfield(package_cd1,',');

        DECLARE
         CURSOR c1 IS SELECT Edition_Name FROM RESULT;

        BEGIN

            OPEN c1;
            LOOP
            FETCH  c1	INTO package_result;
            EXIT WHEN C1%NOTFOUND;


            INSERT INTO PACKAGE1 SELECT "Combin_Desc" FROM COMBIN_MAST WHERE "Combin_Code"=package_result;



            END LOOP;

            --print(@package_result)
        CLOSE c1;
        END ;


insert into searchtbl values(str);commit;


OPEN p_getbookingrecord FOR
str;

		OPEN p_accounts1 FOR
SELECT * FROM PACKAGE1;

OPEN P_ACCOUNTS2 FOR
SELECT DISTINCT "Edition_Code" FROM TBL_BOOKING_INSERT WHERE  "Cio_Booking_Id"=ciobooking;





END ;
/
///////////////////////


*************************************issue no- 4702***************************************************************
CREATE OR REPLACE PROCEDURE HT18JULY.rpt_weekwise_billing_summ
   (pcompcode           in varchar2,
    pcenter             in varchar2,
    pbranchcode         in varchar2,
    ppublcode           in varchar2,
    pdatefrom           in varchar2,
    pdateto             in varchar2,
    puserid             in varchar2,
    pdateformat         in varchar2,
    pdate_basedon       in number,----for booking date(1),publish date(2) or on billing date(3)
    pextra1             in varchar2,
    pextra2             in varchar2,
    pextra3             in varchar2,
    pextra4             in varchar2,
    pextra5             in varchar2,
    pextra6             in varchar2,
    pextra7             in varchar2,
    pextra8             in varchar2,
    pextra9             in varchar2,
    pextra10            in varchar2,    
    p_accounts          OUT Cur_Type_New1.cursor_type,
    p_accounts1         OUT Cur_Type_New1.cursor_type)
IS
    v_frdt      date; 
    v_todt      date;
        
    v_query             varchar2(8000);
    rec_v1_comp_code    varchar2(20);
    rec_v1_pcenter      varchar2(20);
    rec_v1_branch_code  varchar2(20);
    rec_v1_branch_name  varchar2(200);
    rec_v1_bill_date    date;
    rec_v1_publ_code    varchar2(20);
    rec_v1_publ_name    varchar2(200);
    rec_v1_ad_cat       varchar2(200);
    rec_v1_adcat_name   varchar2(200);
    rec_v1_insertion_no number(10);
    rec_v1_amount       number(18,2);
    v_week_name         varchar2(10);
     cursor c1 is
        select x.comp_code,x.pub_center,x.branch_code,x.branch_name, x.bill_date ,x.publ_code,x.publ_name,
        x.ad_cat,x.adcat_name,x.insertion_no,nvl(x.amount,0) from
        (select m."Comp_code" comp_code,b."pub_center" pub_center,b."Branch_Code" branch_code,b."Branch_Name" branch_name,m."date_time" bill_date,
        i."Publication_Code" publ_code,(select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=i."Publication_Code") publ_name,
        i."Ad_Cat" ad_cat,c."Adv_Cat_Name" adcat_name,
        count(i."No_Insert") insertion_no,round(Sum(i."Bill_Amt"),2) amount
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=pcompcode and c."Comp_Code"=m."Comp_code" and c."Adv_Cat_Code"=i."Ad_Cat" and 
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"||a."SUB_Agency_Code"=m."Agency_sub_code" and 
        m."date_time" between v_frdt and v_todt and  
        --new version
        m."branch"=b."Branch_Code" and
        --old version 
        --m."branch"=b."Branch_Name" and
        (b."Branch_Code"=pbranchcode or pbranchcode is null) and (b."pub_center"=pcenter or pcenter is null) and
        (i."Publication_Code"=ppublcode or ppublcode is null) and pdate_basedon=1
        group by m."Comp_code",b."pub_center",b."Branch_Code",b."Branch_Name",m."date_time",i."Publication_Code",i."Ad_Cat",c."Adv_Cat_Name"
        union 
        select m."Comp_code" comp_code,b."pub_center" pub_center,b."Branch_Code" branch_code,b."Branch_Name" branch_name,i."Insert_Date" bill_date,
        i."Publication_Code" publ_code,(select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=i."Publication_Code") publ_name,
        i."Ad_Cat" ad_cat,c."Adv_Cat_Name" adcat_name,
        count(i."No_Insert") insertion_no,round(Sum(i."Bill_Amt"),2) amount
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=pcompcode and c."Comp_Code"=m."Comp_code" and c."Adv_Cat_Code"=i."Ad_Cat" and 
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"||a."SUB_Agency_Code"=m."Agency_sub_code" and 
        i."Insert_Date" between v_frdt and v_todt and  
        --new version
        m."branch"=b."Branch_Code" and
        --old version 
        --m."branch"=b."Branch_Name" and
        (b."Branch_Code"=pbranchcode or pbranchcode is null) and (b."pub_center"=pcenter or pcenter is null) and
        (i."Publication_Code"=ppublcode or ppublcode is null) and pdate_basedon=2
        group by m."Comp_code",b."pub_center",b."Branch_Code",b."Branch_Name",i."Insert_Date",i."Publication_Code",i."Ad_Cat",c."Adv_Cat_Name"
        union 
        select m."Comp_code" comp_code,b."pub_center" pub_center,b."Branch_Code" branch_code,b."Branch_Name" branch_name,i.bill_date bill_date,
        i."Publication_Code" publ_code,(select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=i."Publication_Code") publ_name,
        i."Ad_Cat" ad_cat,c."Adv_Cat_Name" adcat_name,
        count(i."No_Insert") insertion_no,round(Sum(i."Bill_Amt"),2) amount
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=pcompcode and c."Comp_Code"=m."Comp_code" and c."Adv_Cat_Code"=i."Ad_Cat" and 
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"||a."SUB_Agency_Code"=m."Agency_sub_code" and 
        i.bill_date between v_frdt and v_todt and 
        --new version
        m."branch"=b."Branch_Code" and
        --old version 
        --m."branch"=b."Branch_Name" and
        (b."Branch_Code"=pbranchcode or pbranchcode is null) and (b."pub_center"=pcenter or pcenter is null) and
        (i."Publication_Code"=ppublcode or ppublcode is null) and pdate_basedon=3
        group by m."Comp_code",b."pub_center",b."Branch_Code",b."Branch_Name",i.bill_date,i."Publication_Code",i."Ad_Cat",c."Adv_Cat_Name"        ) x;

    v_rec_seqno number(10);
    
    cursor c11 is
            select distinct doctype from temp_ad_receipt_report  
                where sess_id=userenv('sessionid') order by doctype;
    v_var       varchar2(4000);
    v_var_sum   varchar2(4000);
Begin
    v_frdt      := to_date(pdatefrom,''''||pdateformat||'''');
    v_todt      := to_date(pdateto,''''||pdateformat||'''');

    delete from temp_ad_receipt_report where sess_id=userenv('sessionid');
    open c1;
    loop
        fetch c1 into rec_v1_comp_code,rec_v1_pcenter,rec_v1_branch_code,rec_v1_branch_name,rec_v1_bill_date,rec_v1_publ_code,rec_v1_publ_name,rec_v1_ad_cat,rec_v1_adcat_name,rec_v1_insertion_no,rec_v1_amount;
        exit when c1%notfound;
        v_rec_seqno:=nvl(v_rec_seqno,0)+1;
        
        v_week_name:='WEEK'||floor(((rec_v1_bill_date-v_frdt)/7)+1);
        
        insert into temp_ad_receipt_report
            (comp_code,unit_code,pcentre_code,recptdt,exe_code,ad_main_category,ret_code,ad_sub_category,recovary_days,
             amount,rec_seqno,debit_head,doctype)
        values(rec_v1_comp_code,rec_v1_branch_code,rec_v1_pcenter,rec_v1_bill_date,rec_v1_ad_cat,rec_v1_adcat_name,rec_v1_publ_code,rec_v1_publ_name,rec_v1_insertion_no,
                rec_v1_amount,v_rec_seqno,rec_v1_branch_name,v_week_name);
    end loop;
    close c1;
    commit;
    
    v_week_name:=null;
    
    open c11;
    loop
        fetch c11 into v_week_name;
        exit when c11%notfound;
            if v_var is null then
                v_var       :='case when d.doctype='||''''||v_week_name||''''||' then d.recovary_days else 0 end "'||'R#'||v_week_name||'"';
                v_var       :=v_var||','||'case when d.doctype='||''''||v_week_name||''''||' then d.amount else 0 end "'||'A#'||v_week_name||'"';
                v_var_sum   :='round(sum("'||'R#'||v_week_name||'"),2)'||' "'||'R#'||v_week_name||'"';
                v_var_sum   :=v_var_sum||','||'sum("'||'A#'||v_week_name||'")'||' "'||'A#'||v_week_name||'"';
            else
                v_var       :=v_var||','||'case when d.doctype='||''''||v_week_name||''''||' then d.recovary_days else 0 end "'||'R#'||v_week_name||'"';
                v_var       :=v_var||','||'case when d.doctype='||''''||v_week_name||''''||' then d.amount else 0 end "'||'A#'||v_week_name||'"';
                v_var_sum   :=v_var_sum||','||'round(sum("'||'R#'||v_week_name||'"),2)'||' "'||'R#'||v_week_name||'"';
                v_var_sum   :=v_var_sum||','||'sum("'||'A#'||v_week_name||'")'||' "'||'A#'||v_week_name||'"';
            end if;
     end loop;
     close c11;

        
    if v_var is null then
        v_query:='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.branch_code branch_code,x.branch_name branch_name,
        x.publ_code publ_code,x.publ_name publ_name,
        round(sum("AMOUNT"),2) as "TOTOL",  sum("NO_OF_INSERT") as "NO_OF_INSERT" from
        (select d.comp_code,d.unit_code branch_code,d.debit_head branch_name,d.ret_code publ_code,d.ad_sub_category publ_name,
       nvl(d.recovary_days,0) no_of_insert,nvl(d.amount,0) amount from temp_ad_receipt_report d where sess_id='||userenv('sessionid')||') x 
       group by x.comp_code,x.publ_code,x.publ_name,x.branch_code,x.branch_name order by x.comp_code,x.branch_name,x.publ_name,x.publ_code';
    else
       v_query:='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.branch_code branch_code,x.branch_name branch_name,
        x.publ_code publ_code,x.publ_name publ_name,
        '||v_var_sum||' ,round(sum("AMOUNT"),2) as "TOTOL",  sum("NO_OF_INSERT") as "NO_OF_INSERT" from
        (select d.comp_code,d.unit_code branch_code,d.debit_head branch_name,d.ret_code publ_code,d.ad_sub_category publ_name,
       '||v_var||',nvl(d.recovary_days,0) no_of_insert,nvl(d.amount,0) amount from temp_ad_receipt_report d where sess_id='||userenv('sessionid')||') x 
       group by x.comp_code,x.publ_code,x.publ_name,x.branch_code,x.branch_name order by x.comp_code,x.branch_name,x.publ_name,x.publ_code';
    end if;
        
    delete test1;insert into test1(vstring,vstring2) values('rpt_categ_billing_summ1',v_query);commit;
        
    open p_accounts for v_query;
        
    if v_var is null then
        v_query:='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.branch_code branch_code,x.branch_name branch_name,
        round(sum("AMOUNT"),2) as "TOTOL",  sum("NO_OF_INSERT") as "NO_OF_INSERT" from
        (select d.comp_code,d.unit_code branch_code,d.debit_head branch_name,d.ret_code publ_code,d.ad_sub_category publ_name,
       nvl(d.recovary_days,0) no_of_insert,nvl(d.amount,0) amount from temp_ad_receipt_report d where sess_id='||userenv('sessionid')||') x 
       group by x.comp_code,x.branch_code,x.branch_name order by x.comp_code,x.branch_name';
    else
        v_query:='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.branch_code branch_code,x.branch_name branch_name,
        '||v_var_sum||' ,round(sum("AMOUNT"),2) as "TOTOL",  sum("NO_OF_INSERT") as "NO_OF_INSERT" from
        (select d.comp_code,d.unit_code branch_code,d.debit_head branch_name,d.ret_code publ_code,d.ad_sub_category publ_name,
       '||v_var||',nvl(d.recovary_days,0) no_of_insert,nvl(d.amount,0) amount from temp_ad_receipt_report d where sess_id='||userenv('sessionid')||') x 
       group by x.comp_code,x.branch_code,x.branch_name order by x.comp_code,x.branch_name';
    end if;

    insert into test1(vstring,vstring2) values('rpt_categ_billing_summ2',v_query);commit;

    open p_accounts1 for v_query;
    --delete from temp_ad_receipt_report where sess_id=userenv('sessionid');commit;
End rpt_weekwise_billing_summ;
/


*******************************************end of issue***************************************************

/*********************** Kuldeep  25/11/2011  *******************/
CREATE OR REPLACE PACKAGE insertconvertrate is
procedure   insertconvertrate_p(compcode in varchar2,
  userid in varchar2,
  txtconrate in varchar2,
  txtfromdate in date,
  txtefftill in date,
  currcode in varchar2,
  currency in varchar2,
  txtunit in varchar2
);
end  insertconvertrate;
/

CREATE OR REPLACE PACKAGE BODY insertconvertrate is
procedure   insertconvertrate_p(compcode in varchar2,
  userid in varchar2,
  txtconrate in varchar2,
  txtfromdate in date,
  txtefftill in date,
  currcode in varchar2,
  currency in varchar2,
  txtunit in varchar2)as
begin

insert into CURR_CONV_DET("Convert_code", "Conv_Rate","Valid_From_Date","Valid_Till_Date","UserId","Comp_code","Curr_Code","Creation_Datetime",CONV_CURRENCY,UNIT )values(CONVERT_CODE.nextval,txtconrate,txtfromdate,txtefftill,userid,compcode,currcode,sysdate,currency,txtunit);
commit;
end   insertconvertrate_p;
end   insertconvertrate;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE updateconvertrate is

procedure  updateconvertrate_p(compcode in varchar2,
 userid in varchar2,
 txtconrate in varchar2,
 txtfromdate in date,
 txtefftill in date,
 currcode in varchar2,
 code10 in varchar2,
currency in varchar2,
txtunit in varchar2
);
end  updateconvertrate;
/

CREATE OR REPLACE PACKAGE BODY updateconvertrate is
procedure   updateconvertrate_p(compcode in varchar2,
 userid in varchar2,
 txtconrate in varchar2,
 txtfromdate in date,
 txtefftill in date,
 currcode in varchar2,
 code10 in varchar2,
 currency in varchar2,
 txtunit in varchar2)as
begin

update  CURR_CONV_DET set "Valid_From_Date"=txtfromdate,"Valid_Till_Date"=txtefftill,"Conv_Rate"=txtconrate,CONV_CURRENCY=currency,UNIT=txtunit where "Comp_code"=compcode /*and "UserId"=userid */ and "Curr_Code"=currcode and "Convert_code"=code10;
commit;
end   updateconvertrate_p;
end  updateconvertrate;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE bindcurrmast Is
Type T_Accounts_Cursor Is Ref Cursor;
Procedure  bindcurrmast_P(
code in varchar2,
compcode in varchar2,
userid in varchar2,
date1 in varchar2,
P_Accounts Out T_Accounts_Cursor);
End bindcurrmast ;
/

CREATE OR REPLACE PACKAGE BODY bindcurrmast Is
Procedure  bindcurrmast_P(
code in varchar2,
compcode in varchar2,
userid in varchar2,
date1 in varchar2,
P_Accounts Out T_Accounts_Cursor)as
begin
if(date1='mm/dd/yyyy') then
open P_Accounts for
select "Convert_code","Conv_Rate",to_char("Valid_From_Date",'mm/dd/yyyy') as "Valid_From_Date",to_char("Valid_Till_Date",'mm/dd/yyyy') as "Valid_Till_Date",CONV_CURRENCY,UNIT from CURR_CONV_DET where "Curr_Code"=code and "Comp_code"=compcode;-- and "UserId"=userid;
end if;

if(date1='dd/mm/yyyy') then
open P_Accounts for
select "Convert_code","Conv_Rate",to_char("Valid_From_Date",'dd/mm/yyyy') as "Valid_From_Date",to_char("Valid_Till_Date",'dd/mm/yyyy') as "Valid_Till_Date",CONV_CURRENCY,UNIT from CURR_CONV_DET where "Curr_Code"=code and "Comp_code"=compcode;-- and "UserId"=userid;
end if;

if(date1='yyyy/mm/dd') then
open P_Accounts for
select "Convert_code","Conv_Rate",to_char("Valid_From_Date",'yyyy/mm/dd') as "Valid_From_Date",to_char("Valid_Till_Date",'yyyy/mm/dd') as "Valid_Till_Date",CONV_CURRENCY,UNIT from CURR_CONV_DET where "Curr_Code"=code and "Comp_code"=compcode;-- and "UserId"=userid;
end if;

if(date1=null) then
open P_Accounts for
select "Convert_code","Conv_Rate",to_char("Valid_From_Date",'mm/dd/yyyy') as "Valid_From_Date",to_char("Valid_Till_Date",'mm/dd/yyyy') as "Valid_Till_Date",CONV_CURRENCY,UNIT from CURR_CONV_DET where "Curr_Code"=code and "Comp_code"=compcode;-- and "UserId"=userid;
end if;
end bindcurrmast_P;
End bindcurrmast ;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE selectfromcurrmast is
type T_ACCOUNT_CURSOR is ref cursor;
procedure   selectfromcurrmast_p(compcode in varchar2,
 userid in varchar2,
 currcode in varchar2,
 code10 in varchar2,P_ACCOUNT out T_ACCOUNT_CURSOR
);
end  selectfromcurrmast;
/

CREATE OR REPLACE PACKAGE BODY selectfromcurrmast is
procedure   selectfromcurrmast_p(compcode in varchar2,
 userid in varchar2,
 currcode in varchar2,
 code10 in varchar2,P_ACCOUNT out T_ACCOUNT_CURSOR)as
begin
open P_ACCOUNT for
select "Conv_Rate","Valid_From_Date","Valid_Till_Date",CONV_CURRENCY,UNIT from CURR_CONV_DET where "Comp_code"=compcode  and "Curr_Code"=currcode and "Convert_code"=code10;--and "UserId"=userid 

end   selectfromcurrmast_p;
end  selectfromcurrmast;
/

/*********************** Kuldeep  25/11/2011  *******************/

/*********************** Lata  25/11/2011  *******************/
CREATE OR REPLACE procedure tv_convert_to_local(p_Comp_code varchar2,p_Curr_Code in varchar2, p_amount in number,p_amount1 in number, p_date in date,convertcurrency in varchar2 , p_accounts   OUT   cur_type_new1.cursor_type) as
l_ret_amount number;
l_ret_amount1 number;
l_local_curr_code varchar2(100);
l_conv_rate varchar2(8);
begin
select "currency_code" into l_local_curr_code from PREFERRENCES where "comp_code"= p_Comp_code  ;
/*
if l_local_curr_code = p_Curr_Code then 
  open p_accounts for 
  select p_amount AS "GROSS", p_amount1 AS "BILL", 'OK' STATUS, l_conv_rate as CONV_RATE from dual;
end if;
  */
begin  
select trunc(("Conv_Rate"/nvl(unit,1))*p_amount,"No_of_Decimal"),trunc(("Conv_Rate"/nvl(unit,1))*p_amount1,"No_of_Decimal"),"Conv_Rate"  into l_ret_amount,l_ret_amount1,l_conv_rate from 
CURR_CONV_DET a,PREFERRENCES b 
where "Comp_code" = p_Comp_code
and a."Comp_code" =b."comp_code"
and p_date between "Valid_From_Date" and "Valid_Till_Date"
and "Curr_Code" = p_Curr_Code and  conv_currency=convertcurrency;
open p_accounts for
select l_ret_amount AS "GROSS",l_ret_amount1 AS "BILL",'OK' STATUS, l_conv_rate as CONV_RATE from dual;

exception 
  when others then 
       open p_accounts for
       select p_amount as "GROSS", p_amount1 AS "BILL" , 'Error while converting to local...' STATUS,l_conv_rate as CONV_RATE from dual;
       end ;
end ;
/

/*********************** Lata  25/11/2011  *******************/

/*======================================28-November-2011 (currency) (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE PACKAGE chkdateconrate
is
Type T_Account_cursor is Ref cursor;
procedure  chkdateconrate_p (compcode in varchar2,
userid in varchar2,
txtconrate in varchar2,
txtfromdate in varchar2,
txtefftill in varchar2,
currcode in varchar2,
pcurrency in varchar2,
P_ACCOUNTS out T_Account_cursor);
end   chkdateconrate ;
/

CREATE OR REPLACE PACKAGE BODY HT18JULY.chkdateconrate
is

procedure  chkdateconrate_p (compcode in varchar2,
userid in varchar2,
txtconrate in varchar2,
txtfromdate in varchar2,
txtefftill in varchar2,
currcode in varchar2,
pcurrency in varchar2,
P_ACCOUNTS out T_Account_cursor) as

begin
open  P_ACCOUNTS for
select to_char("Valid_From_Date",'mm-dd-yyyy') as "Valid_From_Date",to_char("Valid_Till_Date",'mm-dd-yyyy') as "Valid_Till_Date" from CURR_CONV_DET where "CONV_CURRENCY"=pcurrency and "Curr_Code"=currcode  and ( txtfromdate = "Valid_From_Date"  or  txtefftill="Valid_Till_Date"  or  txtfromdate between  "Valid_From_Date" and "Valid_Till_Date"   or  txtefftill between  "Valid_From_Date" and "Valid_Till_Date" or "Valid_Till_Date"  between txtfromdate and txtefftill  or "Valid_From_Date"  between txtfromdate and txtefftill  ) ;

end   chkdateconrate_p ;
end   chkdateconrate ;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

CREATE OR REPLACE PACKAGE chkdateupdate
is
Type T_Account_cursor is Ref cursor;
procedure chkdateupdate_p (compcode in varchar2,
userid in varchar2,
txtconrate in varchar2,
txtfromdate in varchar2,
txtefftill in varchar2,
currcode in varchar2,
code10 in varchar2,
pcurrency in varchar2,
P_ACCOUNTS out T_Account_cursor);
end  chkdateupdate ;
/

CREATE OR REPLACE PACKAGE BODY chkdateupdate
is

procedure chkdateupdate_p (compcode in varchar2,
userid in varchar2,
txtconrate in varchar2,
txtfromdate in varchar2,
txtefftill in varchar2,
currcode in varchar2,
code10 in varchar2,
pcurrency in varchar2,
P_ACCOUNTS out T_Account_cursor) as

begin
open  P_ACCOUNTS for
select to_char("Valid_From_Date",'mm-dd-yyyy') as "Valid_From_Date",to_char("Valid_Till_Date",'mm-dd-yyyy') as "Valid_Till_Date" from CURR_CONV_DET where "CONV_CURRENCY"=pcurrency and "Curr_Code"=currcode  and ( txtfromdate between  "Valid_From_Date" and "Valid_Till_Date"   or  txtefftill between  "Valid_From_Date" and "Valid_Till_Date" or "Valid_Till_Date"  between txtfromdate and txtefftill or "Valid_From_Date"  between txtfromdate and txtefftill ) and   "Convert_code"  <> code10;

end  chkdateupdate_p ;
end  chkdateupdate ;
/

/*======================================End 28-November-2011 (currency) (Kuldeep Bhati) ==============================*/

/*====================================== Issue( 0005763 ) 28-November-2011 (currency) (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE PROCEDURE Reportnew1
(
agname IN VARCHAR2:=NULL,
clientname IN VARCHAR2:=NULL,
adtype1 IN VARCHAR2,
Adcategory IN VARCHAR2,
Adsubcategory IN VARCHAR2,
fromdate IN VARCHAR2,
dateto IN VARCHAR2,
compcode IN  VARCHAR2,
pub_name IN VARCHAR2,
pub_cent IN  VARCHAR2,
status IN VARCHAR2:=NULL,
edition IN VARCHAR2,
dateformat IN VARCHAR2,
hold IN  VARCHAR2:=NULL,
descid IN VARCHAR2:=NULL,
ascdesc IN VARCHAR2:=NULL,
agtype in varchar2:=null,
puserid in varchar2:=null,
chk_access in varchar2:=null,
pbranch in varchar2:=null,
pprint_center in varchar2:=null,
p_reportnew OUT Cur_Type_New1.cursor_type
)
IS

center  VARCHAR(50);
from_date DATE;
date_to DATE;
query VARCHAR(8000);
a number;





BEGIN
query:='
SELECT TBL_BOOKING_MAST."cio_booking_id" AS "CIOID",
TBL_BOOKING_INSERT."Edition" as "edition",
CASE '''||dateformat||'''
 WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''yyyy/mm/dd'')  END AS "Ins.date" ,
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "Client",
(select COMBIN_MAST."Package_Name" from combin_mast where COMBIN_MAST."Combin_Code"  in(TBL_BOOKING_MAST."Package_code"))AS "Package",
--"Ad_size_height" AS "Depth",
--"Ad_size_width" AS "Width",
tbl_booking_insert."Height" AS "Depth",
tbl_booking_insert."Width"   AS "Width",
round(TBL_BOOKING_insert."Size_Book",2) AS "Area",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code")as "uom",
TBL_BOOKING_INSERT."Col_Code" AS "Color_code",
(SELECT ADVPOS_TYPE_MAST."Pos_Type_Alias" FROM ADVPOS_TYPE_MAST WHERE TBL_BOOKING_INSERT."Page_Post"=ADVPOS_TYPE_MAST."Pos_Type_Code") AS "Page",
TBL_BOOKING_MAST."Bullet_code" AS "BulletPremium" ,
--TBL_BOOKING_MAST."Page_position_code" AS "PositionPremium" ,
--TBL_BOOKING_MAST."Page_prem" AS "PagePremium" ,
tbl_booking_insert."Page_Post" AS "PositionPremium" ,
TBL_BOOKING_INSERT."Premium1" AS "PagePremium" ,
"RO_No" AS "RoNo.",
CASE "ro_status"
WHEN ''2'' THEN ''Reservation''
WHEN ''1'' THEN ''Confirm'' END AS "RoStatus",
(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=tbl_booking_insert."Ad_Cat") AS "AdCat",
TBL_BOOKING_mast."Card_rate" AS "CardRate",
NVL("Agrred_rate",0) AS "AgreedRate",
TBL_BOOKING_insert."Bill_Amt" AS "Amt",
"Caption" AS "Cap",
"Key_no" AS "Key",
(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
sysdate as "Rundate",
CASHDISCOUNT as "Cash_Disc", 
TBL_BOOKING_MAST."AUDIT_COMMENT" as "COMMENT"
FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST
 WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||'''
  AND TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
 AND TBL_BOOKING_MAST."Agency_code"=AGENCY_MAST."Agency_Code"
and TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode"
 AND "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
 and  lower("Insert_Status") !=''cancel''
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where  newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') )';


/*
IF(hold IS NOT NULL)THEN
query:=query||' and TBL_BOOKING_INSERT."Insert_Status"!='''||'Cancel'||'''';

END IF;
*/
IF(agname IS NOT NULL)
THEN

query:=query||' and TBL_BOOKING_MAST."Agency_code" ='''||agname||'''';
END IF;

IF(clientname IS NOT NULL)
THEN
query:=query||' and TBL_BOOKING_MAST."Client_code"='''||clientname ||'''';
END IF;

IF(status IS NOT NULL)
THEN
query:=query||' and TBL_BOOKING_INSERT."Insert_Status"='''||status||'''';
END IF;

IF(adtype1 IS NOT NULL)
THEN

query:=query||' and TBL_BOOKING_MAST."Ad_type_code"='''||adtype1||'''';
END IF;

IF(Adcategory IS NOT NULL)
THEN
a:=Fn_Splitfield(Adcategory,',');
--query:=query||' and TBL_BOOKING_MAST."Ad_cat_code" in('''||Adcategory||''' )';
query:=query||' and tbl_booking_insert."Ad_Cat" in(select "EDITION_NAME" from result  )';
END IF;

IF(Adsubcategory IS NOT NULL)
THEN
a:=fn_SplitField_new(Adsubcategory,',');
query:=query||' and TBL_BOOKING_MAST."Ad_sub_cat_code" in(select "EDITION_NAME" from result_new where sess_id='||userenv('sessionid')||' )';
END IF;

IF(pub_cent IS NOT NULL)
THEN
query:=query||'  and tbl_booking_insert."Pub_Cent_Code"='''||pub_cent||'''';
END IF;



IF(fromdate IS NOT NULL AND dateto IS NULL )
THEN
    query:=query||' and "Insert_Date" ='''||fromdate||'''';

END IF;

IF(fromdate IS NOT NULL AND dateto IS NOT NULL )
THEN
    query:=query||' and "Insert_Date" between  '''||fromdate ||''' and  '''||dateto||''' ';
END IF;

IF(edition IS NOT NULL)
THEN
query:=query||'  and tbl_booking_insert."Edition_Code"='''||edition||'''';
END IF;

IF(pub_name IS NOT NULL)
THEN
query:=query||' and  TBL_BOOKING_INSERT."Publication_Code"='''||pub_name||'''';
END IF;

IF((agtype IS NOT NULL) AND (agtype <> 'Package') AND (agtype <> 'Solo'))
THEN
query:=query||' and  TBL_BOOKING_mast."Agency_type"='''||upper(agtype)||'''';
END IF;


if(pprint_center is not null)then
query:=query||' and TBL_BOOKING_mast."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_mast."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||pprint_center||''')) ';
end if;

if(pbranch is not null)then
query:=query||' and TBL_BOOKING_mast."branch" = '''||pbranch||''' ';
end if;


IF(descid IS NOT  NULL)
THEN
query:=query||'  order by "'||descid||'"';
query:=query||''||ascdesc||'';
ELSE
query:=query||'  order by "Insert_Date",TBL_BOOKING_MAST."cio_booking_id"';


END IF;
delete from searchtbl;
insert into searchtbl values(query);
commit;

OPEN p_reportnew FOR
query;
END;
/

/*======================================End Issue( 0005763 ) 28-November-2011 (currency) (Kuldeep Bhati) ==============================*/
/////////////////////////






CREATE OR REPLACE PROCEDURE HT18JULY.bookingdetailgrid (
      cioid     IN       VARCHAR2,
     P_Accounts OUT Cur_Type_New1.cursor_type

   )
is
newcioid varchar2(50);
countmatter number;
countinsert number;
filename varchar2(50);
BEGIN
newcioid:=cioid;
select count(*) into countmatter from tbl_matter where "cioid"=newcioid;
select count(*) into countinsert from tbl_booking_insert where "Cio_Booking_Id"=cioid and "File_Name" is not null;
if countmatter>countinsert then
    select "matter_filename" into filename from tbl_matter where "cioid"=newcioid and rownum<=1;
    update tbl_booking_insert set "File_Name"=filename where "Cio_Booking_Id"=cioid;
    commit;
end if;
OPEN p_Accounts FOR
select "No_Insert",
(select "pub_alias" from pub_mast where "Pub_Code"=tbl_booking_insert."Publication_Code") as Publication,
"Pub_Cent_Code" as Center,
"Edition",to_char("Insert_Date",'dd-mon-yyyy') as "Insert_Date","Col_Code","Page_No","Size_Book",
(select "Adv_Cat_Alias" from adv_cat_mast where "Adv_Cat_Code"=tbl_booking_insert."Ad_Cat" ) as AdCategory,
(select "Adv_Subcat_Alias" from adv_subcat_mast where "Adv_Subcat_Code"=tbl_booking_insert."Ad_Sub_Cat") as AdSubcategory,
"File_Name","Insert_Status",
case "Pai_Free_Ins"
when 'Y' then 'Yes'
when 'N' then 'No'
end as "Pai_Free_Ins"
,"Gross_Rate","Bill_Amt",BILL_NO,
SECTIONCODE,RESOURCE_NO
from tbl_booking_insert where "Cio_Booking_Id"=cioid order by "Insert_Id";


END ;
/
///////////////////////////////CREATE OR REPLACE PACKAGE Bindaudit
IS
  TYPE T_ACCOUNT_CURSOR IS REF CURSOR;

  PROCEDURE bindaudit_p(fromdate IN VARCHAR2,todate IN VARCHAR2,date1 IN VARCHAR2,BRANCH1 IN VARCHAR2,Adtype IN VARCHAR2,
  audittype IN VARCHAR2
  ,branch2 IN VARCHAR2,
  v_Cat in varchar2,
  v_userid in varchar2,
  comp_code in varchar2,
  v_package_code in varchar2,
  pagency_code in varchar2,
      pclient_code in varchar2,
      psection_code in varchar2,
  P_ACCOUNT OUT T_ACCOUNT_CURSOR);
END Bindaudit;
/






CREATE OR REPLACE PACKAGE BODY bindaudit
IS
   PROCEDURE bindaudit_p (
      fromdate    IN       VARCHAR2,
      todate      IN       VARCHAR2,
      date1       IN       VARCHAR2,
      branch1     IN       VARCHAR2,
      adtype      IN       VARCHAR2,
      audittype   IN       VARCHAR2,
      branch2     IN       VARCHAR2,
      v_cat       IN       VARCHAR2,
      v_userid    IN       VARCHAR2,
      comp_code   in varchar2,
      v_package_code in varchar2,
      pagency_code in varchar2,
      pclient_code in varchar2,
      psection_code in varchar2,
      p_account   OUT      t_account_cursor
   )
   AS
   RELAUTHREQ  varchar2(1);
   BEGIN
   select distinct RELAUTHREQON INTO RELAUTHREQ from preferrences where ("comp_code"=comp_code or comp_code is null) ;
      INSERT INTO test1
                  (vstring
                  )
           VALUES (   'fromdate '
                   || fromdate
                   || ' todate '
                   || todate
                   || ' date1 '
                   || date1
                   || ' BRANCH1 '
                   || branch1
                   || ' Adtype '
                   || adtype
                   || ' audittype '
                   || audittype
                   || ' branch2 '
                   || branch2
                   || ' v_Cat '
                   || v_cat
                   || ' v_userid '
                   || v_userid
                  );

      COMMIT;
  
      IF audittype = 'audit'
      THEN
        IF RELAUTHREQ = 'A' THEN
                 IF (branch1 = 'All' AND branch2 IS NULL)
                 THEN
                    OPEN p_account FOR
                       SELECT distinct "cio_booking_id",
                              NVL ((SELECT distinct  "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT distinct "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                          and tbl_booking_mast.APP_STATUS='Y'    
                          AND tbl_booking_mast."branch" IN (
                                 SELECT branch_mst."Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                              )
                                              and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                              
                                              and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                              and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                                              ;
                 ELSE
                    OPEN p_account FOR
                       SELECT distinct "cio_booking_id",
                              NVL ((SELECT distinct "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT distinct "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "branch" IN (
                                 SELECT "Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                    AND "pub_center" = branch1)
                           and tbl_booking_mast.APP_STATUS='Y'            
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL)
                            and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                 and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                          ;
                 END IF;
        ELSIF RELAUTHREQ ='D' THEN
                 IF (branch1 = 'All' AND branch2 IS NULL)
                 THEN
                    OPEN p_account FOR
                       SELECT distinct "cio_booking_id",
                              NVL ((SELECT distinct "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT distinct "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                          and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')    
                          AND tbl_booking_mast."branch" IN (
                                 SELECT branch_mst."Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                                and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"                                           
                                              )
                                                  and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                                   and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                                              ;
                 ELSE
                    OPEN p_account FOR
                       SELECT distinct "cio_booking_id",
                              NVL ((SELECT  distinct "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT  distinct "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "branch" IN (
                                 SELECT "Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                    AND "pub_center" = branch1)
                          and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')          
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                              
                                and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                    and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                     and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                                ;
                 END IF;
        ELSE
            IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT distinct "cio_booking_id",
                      NVL ((SELECT distinct "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT distinct  "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NOT NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                      
                                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                            
                                             and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                                            
                                            ;
         ELSE
            OPEN p_account FOR
               SELECT distinct "cio_booking_id",
                      NVL ((SELECT distinct "Cust_Name"
                              FROM cust_mast
                             WHERE  "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT distinct "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NOT NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                      
                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                        
                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                             and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                            
                            ;
         END IF;
        END IF;
         
      END IF;

      IF audittype = 'unaudit'
      THEN
      IF RELAUTHREQ = 'A' THEN
        IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT  distinct "cio_booking_id",
                      NVL ((SELECT distinct "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT distinct "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                   and tbl_booking_mast.APP_STATUS='Y'     
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                            
                                             and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                                            ;
         -- SELECT "cio_booking_id",nvl((select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code","audit","Ad_type_code",(select "File_Name" from tbl_booking_insert where "Cio_Booking_Id"=tbl_booking_mast."cio_booking_id" and "File_Name" is not null and rownum<=1) as "FILENAME" FROM TBL_BOOKING_MAST WHERE  "date_time" BETWEEN fromdate AND todate AND "Ad_type_code"=Adtype AND "audit" IS  NULL and ("branch"=branch2 OR  branch2 IS NULL) and (tbl_booking_mast."Ad_cat_code"=v_Cat OR  v_Cat IS NULL);
         ELSE
            OPEN p_account FOR
               SELECT distinct "cio_booking_id",
                      NVL ((SELECT distinct "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT distinct "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                   and tbl_booking_mast.APP_STATUS='Y'           
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                      
                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                             and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                            
                            ;
         END IF;
      ELSIF RELAUTHREQ = 'D' THEN
        IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT distinct "cio_booking_id",
                      NVL ((SELECT distinct "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT distinct "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')    
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                      
                                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                            
                                             and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                                            ;
         -- SELECT "cio_booking_id",nvl((select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code","audit","Ad_type_code",(select "File_Name" from tbl_booking_insert where "Cio_Booking_Id"=tbl_booking_mast."cio_booking_id" and "File_Name" is not null and rownum<=1) as "FILENAME" FROM TBL_BOOKING_MAST WHERE  "date_time" BETWEEN fromdate AND todate AND "Ad_type_code"=Adtype AND "audit" IS  NULL and ("branch"=branch2 OR  branch2 IS NULL) and (tbl_booking_mast."Ad_cat_code"=v_Cat OR  v_Cat IS NULL);
         ELSE
            OPEN p_account FOR
               SELECT distinct "cio_booking_id",
                      NVL ((SELECT distinct "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT distinct "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast ,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                  and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')          
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                      
                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                        
                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                             and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                            ;
         END IF;
      ELSE
        IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT  distinct "cio_booking_id",
                      NVL ((SELECT  distinct "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT distinct "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                            and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                          and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                          and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null) 
                                          
                                          ;
         -- SELECT "cio_booking_id",nvl((select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code","audit","Ad_type_code",(select "File_Name" from tbl_booking_insert where "Cio_Booking_Id"=tbl_booking_mast."cio_booking_id" and "File_Name" is not null and rownum<=1) as "FILENAME" FROM TBL_BOOKING_MAST WHERE  "date_time" BETWEEN fromdate AND todate AND "Ad_type_code"=Adtype AND "audit" IS  NULL and ("branch"=branch2 OR  branch2 IS NULL) and (tbl_booking_mast."Ad_cat_code"=v_Cat OR  v_Cat IS NULL);
         ELSE
            OPEN p_account FOR
               SELECT distinct "cio_booking_id",
                      NVL ((SELECT distinct "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT  distinct "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                      
                          and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"  
                          and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                           and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                          ;
                      
         END IF;
      END IF;
         
      END IF;

      IF audittype != 'unaudit' AND audittype != 'audit'
      THEN
        IF RELAUTHREQ = 'A' THEN
                     IF (branch1 = 'All')
                     THEN
                        OPEN p_account FOR
                           SELECT  distinct "cio_booking_id",
                                  NVL ((SELECT distinct "Cust_Name"
                                          FROM cust_mast
                                         WHERE "Cust_Code" = "Client_code"),
                                       "Client_code"
                                      ) AS "Client_code",
                                  "audit", "Ad_type_code",
                                  (SELECT distinct "File_Name"
                                     FROM tbl_booking_insert
                                    WHERE "Cio_Booking_Id" =
                                             tbl_booking_mast."cio_booking_id"
                                      AND "File_Name" IS NOT NULL
                                      AND ROWNUM <= 1) AS "FILENAME",
                                  CASE date1
                                     WHEN 'mm/dd/yyyy'
                                        THEN TO_CHAR
                                               ("Creation_datetime",
                                                'mm/dd/yyyy'
                                               )
                                     WHEN 'dd/mm/yyyy'
                                        THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                     WHEN 'yyyy/mm/dd'
                                        THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                                  END AS "Creation_datetime"
                             FROM tbl_booking_mast,tbl_booking_insert
                            WHERE "date_time" BETWEEN fromdate AND todate
                              AND "Ad_type_code" = adtype
                              AND ("branch" = branch2 OR branch2 IS NULL)
                              AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                                  )
                             and tbl_booking_mast.APP_STATUS='Y'     
                              AND tbl_booking_mast."branch" IN (
                                     SELECT branch_mst."Branch_Name"
                                       FROM branch_mst
                                      WHERE branch_mst."Branch_Code" IN (
                                               SELECT lb.branch_code
                                                 FROM login_branch_mast lb
                                                WHERE lb.user_code = v_userid
                                                  AND NVL (lb.user_flag, 'N') = 'Y'))
                                                     and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"  
                                                  and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                                  
                                                   and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                                                  ;
                                                  
                                                  
                     ELSE
                        OPEN p_account FOR
                           SELECT distinct "cio_booking_id",
                                  NVL ((SELECT distinct "Cust_Name"
                                          FROM cust_mast
                                         WHERE "Cust_Code" = "Client_code"),
                                       "Client_code"
                                      ) AS "Client_code",
                                  "audit", "Ad_type_code",
                                  (SELECT distinct "File_Name"
                                     FROM tbl_booking_insert
                                    WHERE "Cio_Booking_Id" =
                                             tbl_booking_mast."cio_booking_id"
                                      AND "File_Name" IS NOT NULL
                                      AND ROWNUM <= 1) AS "FILENAME",
                                  CASE date1
                                     WHEN 'mm/dd/yyyy'
                                        THEN TO_CHAR
                                               ("Creation_datetime",
                                                'mm/dd/yyyy'
                                               )
                                     WHEN 'dd/mm/yyyy'
                                        THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                     WHEN 'yyyy/mm/dd'
                                        THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                                  END AS "Creation_datetime"
                             FROM tbl_booking_mast, tbl_booking_insert
                            WHERE "date_time" BETWEEN fromdate AND todate
                              AND "branch" IN (
                                     SELECT "Branch_Code"
                                       FROM branch_mst
                                      WHERE branch_mst."Branch_Code" IN (
                                               SELECT lb.branch_code
                                                 FROM login_branch_mast lb
                                                WHERE lb.user_code = v_userid
                                                  AND NVL (lb.user_flag, 'N') = 'Y')
                                        AND "pub_center" =
                                                        (SELECT "Pub_cent_Code"
                                                           FROM pub_cent_mast
                                                          WHERE "Pub_cent_Code" = branch1))
                              and tbl_booking_mast.APP_STATUS='Y'                            
                              AND "Ad_type_code" = adtype
                              AND ("branch" = branch2 OR branch2 IS NULL)
                              AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                                  )  and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                  and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                   and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                                  
                                  ;
                                  
                     END IF;
        ELSIF RELAUTHREQ = 'D' THEN
                 IF (branch1 = 'All')
                 THEN
                    OPEN p_account FOR
                       SELECT distinct "cio_booking_id",
                              NVL ((SELECT  distinct "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT distinct "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "Ad_type_code" = adtype
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                          and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')    
                          AND tbl_booking_mast."branch" IN (
                                 SELECT branch_mst."Branch_Name"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y'))
                                                and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                                and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                                
                                                 and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                                                ;
                                                
                 ELSE
                    OPEN p_account FOR
                       SELECT distinct "cio_booking_id",
                              NVL ((SELECT  distinct "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT  distinct "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "branch" IN (
                                 SELECT "Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                    AND "pub_center" =
                                                    (SELECT "Pub_cent_Code"
                                                       FROM pub_cent_mast
                                                      WHERE "Pub_cent_Code" = branch1))
                          AND "Ad_type_code" = adtype
                            and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A') 
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                                and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                              and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                               and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                              
                              ;
                 END IF;
        ELSE
             IF (branch1 = 'All')
         THEN
            OPEN p_account FOR
               SELECT distinct  "cio_booking_id",
                      NVL ((SELECT distinct "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT distinct "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Name"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                        and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                         and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                                        
                                        ;
         ELSE
            OPEN p_account FOR
               SELECT distinct  "cio_booking_id",
                      NVL ((SELECT distinct "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT distinct "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" =
                                            (SELECT "Pub_cent_Code"
                                               FROM pub_cent_mast
                                              WHERE "Pub_cent_Code" = branch1))
                  AND "Ad_type_code" = adtype
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                        
                        and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                        
                         and (tbl_booking_insert."SECTIONCODE"= psection_code or psection_code is null)
                                              and (tbl_booking_mast."Agency_sub_code"= pagency_code or pagency_code is null)
                                                  and (tbl_booking_mast."Client_code"= pclient_code or pclient_code is null)
                        ;
         END IF;
        END IF;
        
      END IF;
   END bindaudit_p;
END bindaudit;
/






//==============================================issue no. 5825 02/12/2011=======================================



CREATE OR REPLACE PROCEDURE HT18JULY.completereport
(
p_compcode IN VARCHAR2:= NULL,
p_fromdate IN VARCHAR2:= NULL,
p_dateto IN VARCHAR2:= NULL,
p_dateformat IN VARCHAR2:= NULL,
p_publication IN VARCHAR2:= NULL, 
p_pub_cent IN VARCHAR2:= NULL,
p_edition IN VARCHAR2:= NULL,
p_suppliment IN VARCHAR2:= NULL,
p_zone IN VARCHAR2:= NULL,
p_branch IN VARCHAR2:= NULL,
p_district IN VARCHAR2:= NULL,
p_region IN VARCHAR2:= NULL,
p_city IN VARCHAR2:= NULL,
p_revcenter IN VARCHAR2:= NULL,
p_adtype IN VARCHAR2:= NULL,
p_agencytype IN VARCHAR2:= NULL,
p_ratetype IN VARCHAR2:= NULL,
p_adcat IN VARCHAR2:= NULL,
p_adsubcat IN VARCHAR2:= NULL,
p_adsubcat3 IN VARCHAR2:= NULL,
p_adsubcat4 IN VARCHAR2:= NULL,
p_adsubcat5 IN VARCHAR2:= NULL,
p_package IN VARCHAR2:= NULL,
p_scheme IN VARCHAR2:= NULL,
p_agency IN VARCHAR2:= NULL,
p_client IN VARCHAR2:= NULL,
p_executive IN VARCHAR2:= NULL,
p_retainer IN VARCHAR2:= NULL,
p_product IN VARCHAR2:= NULL,
p_brand IN VARCHAR2:= NULL,
p_varient IN VARCHAR2:= NULL,
p_pagetype IN VARCHAR2:= NULL,
p_pageprem IN VARCHAR2:= NULL,
p_postprem IN VARCHAR2:= NULL,
p_rostatus IN VARCHAR2:= NULL,
p_booktype IN VARCHAR2:= NULL,
p_contractname IN varchar2:= NULL,
p_filterby IN varchar2:= NULL,
p_adcheck in varchar2:=null,
p_state in varchar2:=null,
p_taluka in varchar2:=null,
p_base in varchar2:=null,
p_drpstatus in varchar2:=null,
p_chkdetail in varchar2:=null,
p_insertstatus in varchar2:=null,
p_puserid in varchar2:=null,
p_chk_access in varchar2:=null,
p_recordset1 OUT Cur_Type_New1.cursor_type,
p_accounts OUT Cur_Type_New1.cursor_type
)

IS
query1 VARCHAR2(20000);
v_val number(5);
query2 VARCHAR2(20000);
query3 VARCHAR2(20000);


bookdate varchar2(50);
noinsert varchar2(50);
Paidinsert varchar2(50);
Area varchar2(50);
Pagepremium varchar2(50);
cardamt varchar2(50);
Deviationamt varchar2(50);
Deviationper varchar2(50);
aggamt varchar2(50);
DiscAmt varchar2(50);
Discper varchar2(50);
posamt varchar2(50);
posper varchar2(50);
Spdiscamt varchar2(50);
Spdiscper varchar2(50);
Spacedisc varchar2(50);
Spacediscper varchar2(50);
Specialcharge varchar2(50);
AgencyAddlTDper varchar2(50);
AgencyAddlTDAmt varchar2(50);
Grossamt varchar2(50);
RetTDper varchar2(50);
RetTDAmt varchar2(50);
AgencyTDper varchar2(50);
AgencyTDAmt varchar2(50);
Billamt varchar2(50);
RetCommper varchar2(50);
RetCommAmt varchar2(50);
ActualBusines varchar2(50);



Cursor C1 Is
SELECT /*+ index(TBL_BOOKING_MAST IND_TBL_BOOKING_MAST) index(TBL_BOOKING_INSERT  INSERT_I) */  distinct TBL_BOOKING_mast."cio_booking_id" AS "CIOID",
TBL_BOOKING_MAST."Package_code" as package_code,TBL_BOOKING_mast."Gross_amount" as Crate,'1' as chk_var
FROM TBL_BOOKING_MAST, TBL_BOOKING_INSERT
WHERE TBL_BOOKING_MAST."Comp_code"=p_compcode
AND TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
AND ((tbl_booking_mast."Insertion_date" BETWEEN p_fromdate AND p_dateto and p_filterby='Publish Date') or (tbl_booking_mast."date_time" BETWEEN p_fromdate AND p_dateto and p_filterby='Booking Date'))
AND (TBL_BOOKING_INSERT."Publication_Code"=p_publication or p_publication is null)
--old version

and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
and (tbl_booking_mast."branch" =p_branch or p_branch is null)

--new version
--and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
--and (tbl_booking_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" =p_branch))

AND (TBL_BOOKING_MAST."Ad_type_code"=p_adtype or p_adtype is null)
AND (TBL_BOOKING_MAST."Ad_cat_code"=p_adcat or p_adcat is null)
AND (TBL_BOOKING_INSERT."Edition_Code"=p_edition or p_edition is null)
and (TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where agency_mast."region" =p_region  or p_region is null))
and (tbl_booking_mast."Revenue_center" =p_revcenter or p_revcenter is null)
and (TBL_BOOKING_MAST."Agency_type" =p_agencytype or p_agencytype is null)
and (TBL_BOOKING_MAST."Ad_sub_cat_code" =p_adsubcat or p_adsubcat is null)
and (TBL_BOOKING_MAST."Ad_Subcat3" =p_adsubcat3 or p_adsubcat3 is null)
and (TBL_BOOKING_MAST."Ad_Subcat4" =p_adsubcat4 or p_adsubcat4 is null)
and (TBL_BOOKING_MAST."Ad_subcat5" =p_adsubcat5 or p_adsubcat5 is null)
and (TBL_BOOKING_MAST."Package_code" =p_package or p_package is null)
and (TBL_BOOKING_MAST."Scheme_type_code" =p_scheme or p_scheme is null)
and (TBL_BOOKING_MAST."Agency_code" =p_agency or p_agency is null)
and (TBL_BOOKING_MAST."Client_code" =p_client or p_client is null)
and (TBL_BOOKING_MAST."Executive_code" =p_executive or p_executive is null)
and (TBL_BOOKING_MAST.RETAINER =p_retainer or p_retainer is null)
and (TBL_BOOKING_MAST."Product_code" =p_product  or p_product is null)
and (TBL_BOOKING_MAST."Brand_code" =p_brand or p_brand is null)
and (TBL_BOOKING_MAST."Variant_code" =p_varient or p_varient is null)
and (TBL_BOOKING_MAST."Page_type_code" =p_pagetype or p_pagetype is null)
and (TBL_BOOKING_MAST."Page_prem" =p_pageprem or p_pageprem is null)
and (TBL_BOOKING_MAST."Page_position_code" =p_postprem or p_postprem is null)
and (TBL_BOOKING_MAST."ro_status" =p_rostatus or p_rostatus is null)
and (TBL_BOOKING_MAST."Booking_type" =p_booktype or p_booktype is null)
and (TBL_BOOKING_MAST."Contract_name" =p_contractname or p_contractname is null)
and (tbl_booking_insert."Supp_Code" =p_suppliment or p_suppliment is null)
and (tbl_booking_MAST."Rate_code" =p_ratetype or p_ratetype is null)

and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."City_Code" =p_city or p_city is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" =p_city or p_city is null))
or (p_base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"=p_city or p_city is null)))

and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."zone_code" =p_zone or p_zone is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= p_zone or p_zone is null) ))
or (p_base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))

and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."Dist_Code" =p_district or p_district is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code"= p_district or p_district is null ))
or (p_base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"=p_district or p_district is null)))

and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."State_Code" =p_state or p_state is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code"= p_state or p_state is null ))
or (p_base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"=p_state or p_state is null)))

and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST.TALUKA=p_taluka or p_taluka is null) )
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA= p_taluka or p_taluka is null ))
or (p_base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))

and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code" IS NOT NULL AND TBL_BOOKING_MAST."Agency_sub_code"!='0')
or (p_base='2' and tbl_booking_mast."Executive_code"    is not null and tbl_booking_mast."Executive_code" !='0' )
or (p_base='3' and tbl_booking_mast.RETAINER is not null  and tbl_booking_mast.RETAINER !='0'))

and ((p_drpstatus is  not null and  TBL_BOOKING_INSERT."Insert_Status"!='XYZ') or (p_drpstatus is  null and  lower("Insert_Status")!='cancel'))
and (lower("Insert_Status")=p_insertstatus or p_insertstatus is null)

and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=p_puserid) and p_chk_access=1)
or  (p_chk_access=0) )

  
and p_adcheck='1'

union

SELECT /*+ index(TBL_BOOKING_MAST IND_TBL_BOOKING_MAST) index(TBL_BOOKING_INSERT  INSERT_I) */ distinct TBL_BOOKING_mast."cio_booking_id" AS "CIOID",
TBL_BOOKING_MAST."Package_code" as package_code,tbl_booking_insert."Gross_Rate" as Crate,'1' as chk_var
FROM TBL_BOOKING_MAST, TBL_BOOKING_INSERT
WHERE TBL_BOOKING_MAST."Comp_code"=p_compcode
AND TBL_BOOKING_MAST."Comp_code"=TBL_BOOKING_INSERT."Comp_Code"
AND TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
AND (tbl_booking_insert."Insert_Date" BETWEEN p_fromdate AND p_dateto )
AND (TBL_BOOKING_INSERT."Publication_Code"=p_publication or p_publication is null)
--old version

and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
and (tbl_booking_mast."branch" =p_branch or p_branch is null)

--new version
--and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
--and (tbl_booking_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" =p_branch))


AND (TBL_BOOKING_MAST."Ad_type_code"=p_adtype or p_adtype is null)
AND (TBL_BOOKING_insert."Ad_Cat" =p_adcat or p_adcat is null)
AND (TBL_BOOKING_INSERT."Edition_Code"=p_edition or p_edition is null)
and (TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where agency_mast."region" =p_region  or p_region is null))
and (tbl_booking_mast."Revenue_center" =p_revcenter or p_revcenter is null)
and (TBL_BOOKING_MAST."Agency_type" =p_agencytype or p_agencytype is null)
and (TBL_BOOKING_MAST."Ad_sub_cat_code" =p_adsubcat or p_adsubcat is null)
and (TBL_BOOKING_MAST."Ad_Subcat3" =p_adsubcat3 or p_adsubcat3 is null)
and (TBL_BOOKING_MAST."Ad_Subcat4" =p_adsubcat4 or p_adsubcat4 is null)
and (TBL_BOOKING_MAST."Ad_subcat5" =p_adsubcat5 or p_adsubcat5 is null)
and (TBL_BOOKING_MAST."Package_code" =p_package or p_package is null)
and (TBL_BOOKING_MAST."Scheme_type_code" =p_scheme or p_scheme is null)
and (TBL_BOOKING_MAST."Agency_code" =p_agency or p_agency is null)
and (TBL_BOOKING_MAST."Client_code" =p_client or p_client is null)
and (TBL_BOOKING_MAST."Executive_code" =p_executive or p_executive is null)
and (TBL_BOOKING_MAST.RETAINER =p_retainer or p_retainer is null)
and (TBL_BOOKING_MAST."Product_code" =p_product  or p_product is null)
and (TBL_BOOKING_MAST."Brand_code" =p_brand or p_brand is null)
and (TBL_BOOKING_MAST."Variant_code" =p_varient or p_varient is null)
and (TBL_BOOKING_MAST."Page_type_code" =p_pagetype or p_pagetype is null)
and (TBL_BOOKING_insert."Premium1"  =p_pageprem or p_pageprem is null)
and (tbl_booking_insert."Page_Post" =p_postprem or p_postprem is null)
and (TBL_BOOKING_MAST."ro_status" =p_rostatus or p_rostatus is null)
and (TBL_BOOKING_MAST."Booking_type" =p_booktype or p_booktype is null)
and (TBL_BOOKING_MAST."Contract_name" =p_contractname or p_contractname is null)
and (tbl_booking_insert."Supp_Code" =p_suppliment or p_suppliment is null)
and (tbl_booking_MAST."Rate_code" =p_ratetype or p_ratetype is null)
and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."City_Code" =p_city or p_city is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" =p_city or p_city is null))
or (p_base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"=p_city or p_city is null)))
and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."zone_code" =p_zone or p_zone is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select /*+ index(city_mst ind_city_mst) */ city_mst."City_Code" from city_mst where city_mst."Zone_Code"= p_zone or p_zone is null) 
))
or (p_base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))
and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."Dist_Code" =p_district or p_district is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code"= p_district or p_district is null ))
or (p_base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"=p_district or p_district is null)))
and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."State_Code" =p_state or p_state is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code"= p_state or p_state is null ))
or (p_base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"=p_state or p_state is null)))
and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST.TALUKA=p_taluka or p_taluka is null) )
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA= p_taluka or p_taluka is null ))
or (p_base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))
and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code" IS NOT NULL AND TBL_BOOKING_MAST."Agency_sub_code"!='0')
or (p_base='2' and tbl_booking_mast."Executive_code"    is not null and tbl_booking_mast."Executive_code" !='0' )
or (p_base='3' and tbl_booking_mast.RETAINER is not null  and tbl_booking_mast.RETAINER !='0'))
and ((p_drpstatus is  not null and  TBL_BOOKING_INSERT."Insert_Status"!='XYZ')
or (p_drpstatus is  null and  lower("Insert_Status")!='cancel'))
and (lower("Insert_Status")=p_insertstatus or p_insertstatus is null)

and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=p_puserid) and p_chk_access=1)
or  (p_chk_access=0) )

and p_adcheck='3'

union

SELECT /*+ index (ad_bills_det ind1_ad_bills_det) */distinct ad_bills."IDNUM" AS "CIOID",
ad_bills_det.PACKAGE_CODE as package_code,ad_bills.GROSS_AMT as Crate,'2' as chk_var
FROM ad_bills, ad_bills_det,agency_mast,branch_mst
WHERE ad_bills.IDNUM=ad_bills_det.IDNUM
AND ad_bills.BILDT >= p_fromdate and ad_bills.BILDT <= p_dateto
and (ad_bills."PRIPUB"=p_publication  or p_publication is null)
and (ad_bills_det."EDITION"=p_edition or p_edition is null)
and ad_bills.AGCODE =AGENCY_MAST."code_subcode" and (agency_mast."region" =p_region  or p_region is null)
and (ad_bills_det."AD_TYPE_V"=p_adtype or p_adtype is null)
and (agency_mast."Agency_Type_Code" =p_agencytype or p_agencytype is null)
and (ad_bills_det.PRIADCTG =p_adcat or p_adcat is null)
and (ad_bills_det.SECADCTG =p_adsubcat or p_adsubcat is null)
and (ad_bills_det."AD_SUBCAT3"  =p_adsubcat3 or p_adsubcat3 is null)
and (ad_bills_det.AD_SUBCAT4 =p_adsubcat4 or p_adsubcat4 is null)
and (ad_bills_det.AD_SUBCAT5 =p_adsubcat5 or p_adsubcat5 is null)
and (ad_bills_det.PACKAGE_CODE =p_package or p_package is null)
and (agency_mast."Agency_Code" =p_agency or p_agency is null)
and (ad_bills."CLIENTCD"=p_client or p_client is null)
and (ad_bills."EXECUTIVE_NAME"=p_executive or p_executive is null)
and (ad_bills."PRIPROCTG"=p_product or p_product is null)
and ((ad_bills."PRIPROCTG" in (select /*+ index(brand_mst brand_mst_pk)*/ brand_mst."prod_cat_code" from brand_mst where brand_mst."brand_code"=p_brand or p_brand is null) 
and ad_bills."PRIPROCTG" is not null)or (ad_bills."PRIPROCTG" is null))
and ((ad_bills."PRIPROCTG" in (select /*+ index(brand_mst brand_mst_pk)*/ brand_mst."prod_cat_code" from brand_mst where brand_mst."brand_code" in(select /*+ index(varient_mst ind_varient_mst) */ varient_mst."Brand_Code" from varient_mst where varient_mst."Varient_Name"=p_varient or p_varient is null)) 
and ad_bills."PRIPROCTG" is not null) or (ad_bills."PRIPROCTG" is null))
and (ad_bills_det.PAGE_PREM =p_pageprem or p_pageprem is null)
and (ad_bills_det.PAGE_POST =p_postprem or p_postprem is null)
and (ad_bills.CONTRACT_NAME =p_contractname or p_contractname is null)
and (ad_bills_det.SUPP_CODE =p_suppliment or p_suppliment is null)
and (ad_bills.RETAINER_CODE =p_retainer or p_retainer is null)
and (ad_bills_det.RATECD =p_ratetype or p_ratetype is null)
and ad_bills.UNIT = branch_mst."Branch_Code" and (branch_mst."Branch_Name" =p_branch or p_branch is null) 
and (branch_mst."pub_center"=p_pub_cent or p_pub_cent is null)
and (ad_bills.SCHEME=scheme or scheme is null)
and (AD_BILLS.REVENUE_CENTER =p_revcenter or p_revcenter is null)
and (AD_BILLS.RO_STATUS =p_rostatus or p_rostatus is null)
and (AD_BILLS.PAGE_TYPE =p_pagetype or p_pagetype is null)
and (AD_BILLS.BOOKING_TYPE =p_booktype or p_booktype is null)
 and (ad_bills.SCHEME=p_scheme or p_scheme is null)
 and (AD_BILLS.REVENUE_CENTER =p_revcenter or p_revcenter is null)
 and (AD_BILLS.RO_STATUS =p_rostatus or p_rostatus is null)
 and (AD_BILLS.PAGE_TYPE =p_pagetype or p_pagetype is null)
 and (AD_BILLS.BOOKING_TYPE =p_booktype or p_booktype is null)
and ((p_base='1' and (AGENCY_MAST."City_Code" =p_city or p_city is null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" =p_city or p_city is null))
or (p_base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"=p_city or p_city is null)))

and ((p_base='1' and (AGENCY_MAST."zone_code" =p_zone or p_zone is null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= p_zone or p_zone is null) ))
or (p_base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))

and ((p_base='1' and (AGENCY_MAST."Dist_Code" =p_district or p_district is null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code"= p_district or p_district is null ))
or (p_base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"=p_district or p_district is null)))

and ((p_base='1' and (AGENCY_MAST."State_Code" =p_state or p_state is null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code"= p_state or p_state is null ))
or (p_base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"=p_state or p_state is null)))

and ((p_base='1' and (AGENCY_MAST.TALUKA=p_taluka or p_taluka is null) )
or (p_base='2' and ad_bills.EXECUTIVE_NAME   in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA= p_taluka or p_taluka is null ))
or (p_base='3' and ad_bills.RETAINER_CODE  in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))

and ((p_base='1' and ad_bills.AGCODE IS NOT NULL AND ad_bills.AGCODE!='0')
or (p_base='2' and ad_bills.EXECUTIVE_NAME   is not null and ad_bills.EXECUTIVE_NAME !='0' )
or (p_base='3' and ad_bills.RETAINER_CODE  is not null  and ad_bills.RETAINER_CODE !='0'))

and ((ad_bills_det."BKFOR" in (select distinct pub_center from login_center where newuser_id=p_puserid) and p_chk_access=1)
or  (p_chk_access=0) )

and p_adcheck='2';

v1 c1%rowtype;


---**************************************  For Billing Data*************************
Cursor C2 Is
SELECT distinct ad_bills."IDNUM" AS "CIOID",ad_bills.BILNO as "BILLNO" ,ad_bills.ag_main_code as "AGMAINCODE",ad_bills.ag_sub_code as "AG_SUB_CODE",ad_bills.agcode as "AGCODE",
"Agency_Name" as "AGNAME",nvl(ad_bills.executive_name,0) as "EXECCODE",AD_GET_EXECNAME(p_compcode,ad_bills.EXECUTIVE_NAME) as "EXECNAME",ad_bills.RETAINER_CODE as "RETCODE",AD_GET_RETAINER(p_compcode,ad_bills.RETAINER_CODE) as "RETNAME"
FROM ad_bills,AGENCY_MAST,branch_mst WHERE ad_bills.comp_code_v=p_compcode 
and ad_bills.BILDT >= p_fromdate and ad_bills.BILDT <=p_dateto 
and ad_bills.UNIT=branch_mst."Branch_Code" and (branch_mst."Branch_Name" =p_branch or p_branch is null) 
and (BRANCH_MST."pub_center" =p_pub_cent or p_pub_cent is null)
and ad_bills.AGCODE =AGENCY_MAST."code_subcode" and (agency_mast."region" =p_region  or p_region is null)
and (agency_mast."Agency_Type_Code" =p_agencytype or p_agencytype is null)
and (ad_bills."PRIPUB"=p_publication  or p_publication is null)
and (agency_mast."Agency_Code" =p_agency or p_agency is null)
and (ad_bills."CLIENTCD"=p_client or p_client is null)
and (ad_bills."EXECUTIVE_NAME"=p_executive or p_executive is null)
and (ad_bills."PRIPROCTG"=p_product or p_product is null)
and ((ad_bills."PRIPROCTG" in (select brand_mst."prod_cat_code" from brand_mst where brand_mst."brand_code"=p_brand or p_brand is null) and ad_bills."PRIPROCTG" is not null)or (ad_bills."PRIPROCTG" is null))
and ((ad_bills."PRIPROCTG" in (select brand_mst."prod_cat_code" from brand_mst where brand_mst."brand_code" in(select varient_mst."Brand_Code" from varient_mst where varient_mst."Varient_Name"=p_varient or p_varient is null)) and ad_bills."PRIPROCTG" is not null) or (ad_bills."PRIPROCTG" is null))
and (ad_bills.CONTRACT_NAME =p_contractname or p_contractname is null)
and (ad_bills.RETAINER_CODE =p_retainer or p_retainer is null)
and (ad_bills.SCHEME=p_scheme or p_scheme is null)
and (AD_BILLS.REVENUE_CENTER =p_revcenter or p_revcenter is null)
and (AD_BILLS.RO_STATUS =p_rostatus or p_rostatus is null)
and (AD_BILLS.PAGE_TYPE =p_pagetype or p_pagetype is null)
and (AD_BILLS.BOOKING_TYPE =p_booktype or p_booktype is null)
and ((p_base='1' and (AGENCY_MAST."City_Code" =p_city or p_city is null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" =p_city or p_city is null))
or (p_base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"=p_city or p_city is null)))
and ((p_base='1' and (AGENCY_MAST."zone_code" =p_zone or p_zone is null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= p_zone or p_zone is null) ))
or (p_base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))
and ((p_base='1' and (AGENCY_MAST."Dist_Code" =p_district or p_district is null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code"= p_district or p_district is null ))
or (p_base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"=p_district or p_district is null)))
and ((p_base='1' and (AGENCY_MAST."State_Code" =p_state or p_state is null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code"= p_state or p_state is null ))
or (p_base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"=p_state or p_state is null)))
and ((p_base='1' and (AGENCY_MAST.TALUKA=p_taluka or p_taluka is null) )
or (p_base='2' and ad_bills.EXECUTIVE_NAME   in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA= p_taluka or p_taluka is null ))
or (p_base='3' and ad_bills.RETAINER_CODE  in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))
and ((p_base='1' and ad_bills.AGCODE IS NOT NULL AND ad_bills.AGCODE!='0')
or (p_base='2' and ad_bills.EXECUTIVE_NAME   is not null and ad_bills.EXECUTIVE_NAME !='0' )
or (p_base='3' and ad_bills.RETAINER_CODE  is not null  and ad_bills.RETAINER_CODE !='0'));

v2 C2%rowtype;

--**********************************************************************************

v_edition varchar2(100);
v_edipkg varchar2(500);
prefer   varchar2(10);

BEGIN
delete from searchtbl;
/*insert into searchtbl values('compcode-'||compcode||'fromdate-'||fromdate||'dateto-'||dateto||'dateformat-'||dateformat||'publication-'||publication
||'pub_cent-'||pub_cent||'edition-'||edition||'suppliment-'||suppliment||'zone-'||zone||'branch-'||branch||'district-'||district||'region-'||region||
'city-'||city||'revcenter-'||revcenter||'adtype-'||adtype||'agencytype-'||agencytype||'ratetype-'||ratetype||'adcat-'||adcat||'adsubcat-'||adsubcat||
'adsubcat3-'||adsubcat3||'adsubcat4-'||adsubcat4||'adsubcat5-'||adsubcat5||'package-'||package||'scheme-'||scheme||'agency-'||agency||'client-'||client||
'executive-'||executive||'retainer-'||retainer||'product-'||product||'brand-'||brand||'varient-'||varient||'pagetype-'||pagetype||'pageprem-'||pageprem||
'postprem-'||postprem||'rostatus-'||rostatus||'booktype-'||booktype||'contractname-'||contractname||'filterby-'||filterby||'adcheck-'||adcheck||'state-'||state||
'taluka-'||taluka||'base-'||base||'drpstatus-'||drpstatus||'chkdetail-'||chkdetail||'insertstatus-'||insertstatus||'puserid-'||puserid||'chk_access-'||chk_access);

*/


select DISTINCT AGENCY_RETAINER_COMM into prefer from preferrences where "comp_code"=p_compcode;

delete from multipack_rep where sess_id=userenv('sessionid')  ;
delete from multipack_rat where sess_id=userenv('sessionid') ;
DELETE FROM multipack_ratnew where sess_id=userenv('sessionid')  ;

commit;
open c1;
loop
fetch c1 into v1;
exit when c1%notfound;

     v_val:=multipack_report(v1.CIOID,v1.package_code,v1.Crate,v1.chk_var);

    v_edition:=null;v_edipkg:=null;
end loop;
close c1; 
commit;

if(p_chkdetail='Detail')then

if(p_adcheck=1)
then
query1:=query1||'SELECT distinct TBL_BOOKING_MAST."cio_booking_id" AS "CIOID",
to_char(TBL_BOOKING_MAST."date_time",'''||p_dateformat||''') as "BookDate",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "Client",
"RO_No" AS "RoNo.",
CASE '''||p_dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("RO_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("RO_Date" ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("RO_Date",''yyyy/mm/dd'') END AS "Ro.Date",
(select EXEC_MAST."Exec_name" from exec_mast where tbl_booking_mast."Executive_code"=exec_mast."Exe_no") AS "Executive",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=tbl_booking_mast.RETAINER ) AS "Retainer",
decode(tbl_booking_mast."Booking_type",''1'',''Barter'',''2'',''FMG'',''3'',''Normal'',''4'',''InHouse'',''5'',''Complimentary'',''Normal'') as "BookType",
(select col_mast."Col_Alias" from col_mast where tbl_booking_mast."Color_code"=col_mast."Col_Code") as "Color",
adv_cat_mast."Adv_Cat_Name" as "Adcat",
(select adv_subcat_mast."Adv_Subcat_Name" from adv_subcat_mast where tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code")as "Adsubcat",
(select ad_cat3."catname" from ad_cat3,adv_subcat_mast  where tbl_booking_mast."Ad_Subcat3"=ad_cat3."catcode" and ad_cat3."subcatname"=adv_subcat_mast."Adv_Subcat_Code" and tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat3",
(select tbl_cat4."Cat_Name" from tbl_cat4,adv_subcat_mast where tbl_booking_mast."Ad_Subcat4"=tbl_cat4."Cat_Code" and tbl_cat4."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat4",
(select tbl_cat5."Cat_Name" from tbl_cat5,adv_subcat_mast where tbl_booking_mast."Ad_subcat5"=tbl_cat5."Cat_Code" and tbl_cat5."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat5",
FETCH_PACK(tbl_booking_mast."cio_booking_id") AS "Package",
to_char(tbl_booking_mast."Insertion_date",'''||p_dateformat||''') as "PubDate",
tbl_booking_mast."No_of_insertion" as "noinsert",
tbl_booking_mast."Paid_ins" as "Paidinsert",
tbl_booking_mast."Ad_size_height" as "height",
 tbl_booking_mast."Ad_size_width" as "width",
tbl_booking_mast."Total_area" as "Area",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Pagepremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem",
(select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id") as "scheme",
tbl_booking_mast."Rate_code" as "Ratecode",
tbl_booking_mast."Card_rate" as "cardrate",
tbl_booking_mast."Card_amount" as "cardamt",
tbl_booking_mast."Contract_rate" as "contractrate",
TBL_BOOKING_mast."Deviation" as "Deviationamt",
TBL_BOOKING_mast."Deviation" AS "Deviation(%)",
tbl_booking_mast."Agrred_rate" as "Aggrate",
tbl_booking_mast."Agreed_amount" as "aggamt",
(tbl_booking_mast."Card_amount" - DECODE(NVL(tbl_booking_mast."Agreed_amount",0),0,tbl_booking_mast."Card_amount",tbl_booking_mast."Agreed_amount")) as "DiscAmt",
tbl_booking_mast."Discount_per" as "Discper",
(select SUM(nvl(RAT,0)) from multipack_rat where cioid=tbl_booking_mast."cio_booking_id"  and sess_id='||userenv('sessionid')||') as  "posamt",
(select SUM(nvl(PER_AMT,0)) from multipack_rat where cioid=tbl_booking_mast."cio_booking_id"   and sess_id='||userenv('sessionid')||') as "pos(%)",
round(((tbl_booking_mast."Special_disc_per" * tbl_booking_mast."Total_area" * tbl_booking_mast."Card_rate")/100),2) as "Spdiscamt",
tbl_booking_mast."Special_disc_per" as "Spdiscper",
round(((tbl_booking_mast."Space_disc_per" * tbl_booking_mast."Total_area" * tbl_booking_mast."Card_rate")/100),2) as "Spacedisc",
tbl_booking_mast."Space_disc_per" as "Spacediscper",
tbl_booking_mast."Special_charges" as "Specialcharge",
nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0'') as "AgencyAddlTD(%)",
nvl((nvl(tbl_booking_mast."Gross_amount",''0'')*nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0'')/100),''0'') as "AgencyAddlTDAmt",
nvl(tbl_booking_mast."Gross_amount",''0'') as "Grossamt",
(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1 ) as "RetTD(%)",
nvl(tbl_booking_mast."Gross_amount",''0'')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1 )/100 as "RetTDAmt",
nvl(tbl_booking_mast."Trade_disc",''0'' )as "AgencyTD(%)",
(nvl(tbl_booking_mast."Gross_amount",''0'')* nvl(tbl_booking_mast."Trade_disc",''0'' )/100 )as "AgencyTDAmt",
nvl(tbl_booking_mast."Bill_amount",''0'') as "Billamt",
nvl(case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then
                (
                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,''0''))-to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0'' )))
                 end )
         when ''Net''   then  to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,''0''))
        END )
       
    ELSE (select 0  from dual)
end  ,''0'') as "RetComm(%)",
nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then 
                 (
                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,''0''))-(nvl((nvl(tbl_booking_mast."Gross_amount",''0'')*to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )
         
          
         when ''Net''   then  (nvl(tbl_booking_mast."Gross_amount",''0'')*(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,''0'')) )/100)
        END )
       
    ELSE (select 0  from dual)
end
,''0'') as "RetCommAmt",
minus_to_zero(nvl((  NVL(tbl_booking_mast."Bill_amount",''0'')-
nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then 
         
                 (
                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,''0''))-(nvl((nvl(tbl_booking_mast."Gross_amount",''0'')*to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )
                
          
         when ''Net''   then  (nvl(tbl_booking_mast."Gross_amount",''0'')*(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,''0'')) )/100)
        END )
       
    ELSE (select 0  from dual)
end
,''0'') ),''0'')) as "ActualBusiness",

(SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE tbl_booking_mast."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter",
UOM_MAST."Uom_Name"  AS "Uom",
uom_mast.UOM_DESC as "uomdesc"
,(select pub_cent_mast."Pub_Cent_name" from pub_cent_mast where pub_cent_mast."Pub_cent_Code" in(select "pub_center" from  BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name") ) as "Printcenter"
--old version
,tbl_booking_mast."branch" as "Branch"
--new version
--,(SELECT "Branch_Name" FROM BRANCH_MST where  TBL_BOOKING_mast."branch" = "Branch_Code") as "Branch"


,case '''||p_base||'''
when ''1'' then  AGENCY_MAST."Dist_Code"
when ''2'' then (select dist_mst."Dist_Name" from dist_mst where dist_mst."Dist_Code" in(select exec_mast."dist_code" from exec_mast where  exec_mast."Exe_no"=tbl_booking_mast."Executive_code" )  )
when ''3'' then (select dist_mst."Dist_Name" from dist_mst where dist_mst."Dist_Code" in(select RETAINERMASTER."Dist_Code" from RETAINERMASTER where  RETAINERMASTER."Retain_Code"= tbl_booking_mast.RETAINER )  ) end as "District"
,case '''||p_base||'''
when ''1'' then (select taluka_mast.TALU_NAME  from taluka_mast where AGENCY_MAST.TALUKA=taluka_mast.TALU_CODE )
when ''2'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select exec_mast.TALUKA from exec_mast where  exec_mast."Exe_no"=tbl_booking_mast."Executive_code" )  )
when ''3'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select RETAINERMASTER.TALUKA from RETAINERMASTER where  RETAINERMASTER."Retain_Code"= tbl_booking_mast.RETAINER )  ) end as "Taluka"
,nvl(TBL_BOOKING_MAST."Page_no",0) as "Page_No"
,CASHDISCOUNT as "Cash_Disc"
,"Box_code" as "BoxCode"
,TBL_BOOKING_MAST."Userid" as USERID,(SELECT max("username") from login where com_code = TBL_BOOKING_MAST."Comp_code" and "userid"=TBL_BOOKING_MAST."Userid") as USERNAME
FROM TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,
adv_cat_mast,
adv_type_mast,
TBL_BOOKING_insert
WHERE TBL_BOOKING_MAST."Comp_code"='''||p_compcode||''' AND
 UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code"
and adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id"
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||p_puserid||''') and '''||p_chk_access||'''=''1'')
or  ('''||p_chk_access||'''=''0'') )' ;


if(p_base='2')then
query1:=query1||' and (tbl_booking_mast."Executive_code" is not null and tbl_booking_mast."Executive_code" !=''0'')  ';
end if;

if(p_base='3')then
query1:=query1||' and (tbl_booking_mast.RETAINER is not null  and tbl_booking_mast.RETAINER !=''0'')  ';
end if;


if(p_drpstatus is null) then
query1:=query1||' and lower("Insert_Status")!='''||'cancel'||'''';
end if;

if(p_insertstatus is not null) then
query1:=query1||' and lower("Insert_Status")='''||p_insertstatus||'''';
end if;

IF(p_fromdate IS NOT NULL AND p_dateto IS NULL  and  p_filterby='Booking Date')
THEN
query1:=query1||' and tbl_booking_mast."date_time" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL and p_filterby='Booking Date' )
THEN
query1:=query1||' and tbl_booking_mast."date_time" between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NULL  and  p_filterby='Publish Date')
THEN
query1:=query1||' and tbl_booking_mast."Insertion_date" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL and p_filterby='Publish Date' )
THEN
query1:=query1||' and tbl_booking_mast."Insertion_date"  between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query1:=query1||' and TBL_BOOKING_insert."Publication_Code"='''||p_publication||'''    ';
END IF;

--old version
IF(p_pub_cent IS NOT NULL)
THEN
query1:=query1||'  and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_mast."branch" ='''||p_branch||'''';
END IF;


--new version
/*IF(p_pub_cent IS NOT NULL)
THEN
query1:=query1||'  and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query1:=query1||'  and TBL_BOOKING_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''||p_branch||''') ';
END IF;
*/

IF(p_edition IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_insert."Edition_Code"='''||p_edition||'''';
END IF;

IF(p_region IS NOT NULL)
THEN
query1:=query1 ||' and agency_mast."region" ='''||p_region ||''' ';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query1:=query1 ||' and tbl_booking_mast."Revenue_center" ='''||p_revcenter||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Ad_type_code"='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Agency_type" ='''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Ad_cat_code" ='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Ad_sub_cat_code" ='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Ad_Subcat3" ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Ad_Subcat4" ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Ad_subcat5" ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Package_code" ='''||p_package||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Scheme_type_code" ='''||p_scheme||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Agency_code" ='''||p_agency||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Client_code" ='''||p_client||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Executive_code" ='''||p_executive||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST.RETAINER ='''||p_retainer||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Product_code" ='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Brand_code" ='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Variant_code" ='''||p_varient||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Page_type_code" ='''||p_pagetype||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Page_prem" ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Page_position_code" ='''||p_postprem||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."ro_status" ='''||p_rostatus||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Booking_type" ='''||p_booktype||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Contract_name" ='''||p_contractname ||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query1:=query1 || ' and tbl_booking_insert."Supp_Code" ='''||p_suppliment||'''';
END IF;

IF(p_ratetype  IS NOT NULL)
THEN
query1:=query1 || ' and tbl_booking_MAST."Rate_code" ='''||p_ratetype||'''';
END IF;

IF(p_city  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."City_Code" ='''||p_city||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and tbl_booking_mast."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" ='''||p_city||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"='''||p_city||''')';
end if;
END IF;

IF(p_zone  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."zone_code" ='''||p_zone||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and tbl_booking_mast."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= '''||p_zone||''') )';
end if;

if(p_base='3')then
query1:=query1 || ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"='''||p_zone||''')';
end if;
END IF;

IF(p_district  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."Dist_Code" ='''||p_district||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and tbl_booking_mast."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code" ='''||p_district||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"='''||p_district||''')';
end if;
END IF;

IF(p_state  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."State_Code" ='''||p_state||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and tbl_booking_mast."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code" ='''||p_state||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"='''||p_state||''')';
end if;
END IF;

IF(p_taluka  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST.TALUKA='''||p_taluka||'''  ';
end if;

if(p_base='2')then
query1:=query1 || ' and tbl_booking_mast."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA ='''||p_taluka||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA='''||p_taluka||''')';
end if;
END IF;

query1:=query1 || ' order by TBL_BOOKING_MAST."cio_booking_id"';


--insert into searchtbl values(query1);
--commit;
OPEN p_recordset1 FOR
query1;


elsif(p_adcheck=2)then
delete from temp_ad_bills_report where sess_id=userenv('sessionid')  ;
open c2;
loop
fetch c2 into v2;
exit when c2%notfound;
--insert into test_amit(a,b)values('amit-',v2.BILLNO);commit;

         v_val:=FUN_BILL_INSERT(p_compcode,v2.CIOID,v2.BILLNO,prefer,p_dateformat,v2.AGMAINCODE,v2.AG_SUB_CODE,v2.AGCODE,v2.AGNAME,v2.EXECCODE,v2.EXECNAME,v2.RETCODE,v2.RETNAME,p_base );    
end loop;
close c2;
commit;

query2:=query2 || 'select CIOID AS "CIOID",BILLNO AS "Billno" ,AGENCY AS "Agency", CLIENT AS "Client" ,
RONO  AS "RoNo.",
CASE '''||p_dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR(RODATE ,''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(RODATE ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(RODATE,''yyyy/mm/dd'') END AS "Ro.Date",
EXECUTIVE  AS "Executive",RETAINER  AS "Retainer" ,BOOKTYPE as "BookType",COLOR as "Color",ADCAT as "Adcat",
ADSUBCAT as "Adsubcat",ADSUBCAT3 as "Adsubcat3",ADSUBCAT4  as "Adsubcat4",ADSUBCAT5 as "Adsubcat5",PACKAG AS "Package",
to_char(BILLDATE,'''||p_dateformat||''') as "BillDate",
NOINSERT as "noinsert",PAIDINSERT as "Paidinsert" ,HEIGHT as "height",WIDTH as "width",AREA as "Area",PAGEPREMIUM as "Pagepremium",POSTPREM as "Postprem",
SCHEME as "scheme",RATECOD as "Ratecode",CARDRATE as "cardrate",CARDAMT as "cardamt",
CONTRACTRATE as "contractrate",DEVIATIONAMT as "Deviationamt",DEVIATIONPER AS "Deviation(%)",
AGGRATE as "Aggrate",AGGAMT as "aggamt",DISCAMT as "DiscAmt",DISCPER as "Discper",
POSAMT as  "posamt",POSPER as "pos(%)",SPDISCAMT as "Spdiscamt",
SPDISCPER as "Spdiscper",SPACEDISC as "Spacedisc",SPACEDISCPER as "Spacediscper",SPECIALCHARGE as "Specialcharge",AGENCYADDLTDPER  as "AgencyAddlTD(%)",
AGENCYADDLTDAMT as "AgencyAddlTDAmt",GROSSAMT as "Grossamt",
RETTDPER as "RetTD(%)",RETTDAMT as "RetTDAmt",AGENCYTDPER as "AgencyTD(%)",AGENCYTDAMT as "AgencyTDAmt",BILLAMT as "Billamt",
RETCOMMPER as "RetComm(%)",RETCOMMAMT as "RetCommAmt",minus_to_zero(ACTUALBUSINESS) as "ActualBusiness",
REVCENTER as "Revcenter",UOM AS "Uom",UOMDESC as "uomdesc"
,PUB_CENT_NAME as "Printcenter"
,BRANCH_NAME  as "Branch"
,DIST_NAME as "District"
,TALU_NAME as "Taluka"
,PAGE_NO as "Page_No"
from temp_ad_bills_report where sess_id='||userenv('sessionid');

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL )
THEN
query2:=query2||' and BILLDATE between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query2:=query2||' and PRIPUB='''||p_publication||'''';
END IF;

IF(p_pub_cent IS NOT NULL)
THEN
query2:=query2||'   and PUB_CENT_CODE='''||p_pub_cent||'''';
END IF;

IF(p_edition IS NOT NULL)
THEN
query2:=query2||'  and PEDITION='''||p_edition||'''';
END IF;

IF(p_branch IS NOT NULL)
THEN
query2:=query2||'  and  BRANCH_NAME ='''||p_branch||''' ';
END IF;

IF(p_region IS NOT NULL)
THEN
query2:=query2 ||' and REGION='''||p_region ||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query2:=query2 || ' and PADTYPE='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query2:=query2 || ' and AGENCY_TYPE_CODE= '''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query2:=query2 || ' and PRIADCTG='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query2:=query2 || ' and SECADCTG ='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query2:=query2 || ' and AD_SUBCAT3 ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query2:=query2 || ' and AD_SUBCAT4 ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query2:=query2 || ' and AD_SUBCAT5 ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query2:=query2 || ' and PACKAGE_CODE='''||p_package||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query2:=query2 || ' and AG_MAIN_CODE ='''||p_agency ||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query2:=query2 || ' and CLIENTCD='''||p_client ||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query2:=query2 || ' and EXECUTIVE_NAME='''||p_executive||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query2:=query2 || ' and PRIPROCTG='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query2:=query2 || ' and BRAND_CODE='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query2:=query2 || ' and   VARIENT_NAME='''||p_varient||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query2:=query2 || ' and PAGE_PREM ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query2:=query2 || ' and PAGE_POST ='''||p_postprem||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query2:=query2 || ' and CONTRACT_NAME ='''||p_contractname ||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query2:=query2 || ' and SUPP_CODE='''||p_suppliment||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query2:=query2 || ' and RETAINER_CODE='''||p_retainer||'''';
END IF;

IF(p_ratetype  IS NOT NULL)
THEN
query2:=query2 || ' and RATECD ='''||p_ratetype||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query2:=query2 || ' and PSCHEME='''||p_scheme||'''';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query2:=query2 ||' and REVENUE_CENTER='''||p_revcenter||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query2:=query2 || ' and RO_STATUS='''||p_rostatus||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query2:=query2 || ' and PAGE_TYPE ='''||p_pagetype||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query2:=query2 || ' and BOOKING_TYPE='''||p_booktype||'''';
END IF;

IF(p_city  IS NOT NULL)
THEN
query2:=query2 || ' and CITY_CODE ='''||p_city||'''';
END IF;

IF(p_zone  IS NOT NULL)
THEN
query2:=query2 || ' and ZONE_CODE ='''||p_zone||'''';
end if;

IF(p_district  IS NOT NULL)
THEN
query2:=query2 || ' and DIST_CODE ='''||p_district||'''';
end if;

IF(p_state  IS NOT NULL)
THEN
query2:=query2 || ' and STATE_CODE ='''||p_state||'''';
end if;

IF(p_taluka  IS NOT NULL)
THEN
query2:=query2 || ' and PTALUKA='''||p_taluka||'''  ';
end if;


if(p_base='2')then
query2:=query2 ||' and (EXECUTIVE_NAME   is not null and EXECUTIVE_NAME !=''0'')  ';
end if;

if(p_base='3')then
query2:=query2 ||' and (RETAINER_CODE  is not null  and RETAINER_CODE  !=''0'')  ';
end if;



query2:=query2 || ' order by CIOID';

--delete from searchtbl;
--insert into searchtbl values(query2);
--commit;

OPEN p_recordset1 FOR 
query2;

elsif(p_adcheck=3) then
query3:=query3 ||'SELECT  TBL_BOOKING_MAST."cio_booking_id" AS "CIOID",
to_char(TBL_BOOKING_MAST."date_time",'''||p_dateformat||''') as "BookDate",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "Client",
"RO_No" AS "RoNo.",
CASE '''||p_dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("RO_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("RO_Date" ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("RO_Date",''yyyy/mm/dd'') END AS "Ro.Date",
(select EXEC_MAST."Exec_name" from exec_mast where tbl_booking_mast."Executive_code"=exec_mast."Exe_no") AS "Executive",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=tbl_booking_mast.RETAINER ) AS "Retainer",
decode(tbl_booking_mast."Booking_type",''1'',''Barter'',''2'',''FMG'',''3'',''Normal'',''4'',''InHouse'',''5'',''Complimentary'',''Normal'') as "BookType",
(select col_mast."Col_Alias" from col_mast where tbl_booking_insert."Col_Code" =col_mast."Col_Code") as "Color",
adv_cat_mast."Adv_Cat_Name" as "Adcat",
(select adv_subcat_mast."Adv_Subcat_Name" from adv_subcat_mast where tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code")as "Adsubcat",
(select ad_cat3."catname" from ad_cat3,adv_subcat_mast  where tbl_booking_mast."Ad_Subcat3"=ad_cat3."catcode" and ad_cat3."subcatname"=adv_subcat_mast."Adv_Subcat_Code" and tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat3",
(select tbl_cat4."Cat_Name" from tbl_cat4,adv_subcat_mast where tbl_booking_mast."Ad_Subcat4"=tbl_cat4."Cat_Code" and tbl_cat4."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat4",
(select tbl_cat5."Cat_Name" from tbl_cat5,adv_subcat_mast where tbl_booking_mast."Ad_subcat5"=tbl_cat5."Cat_Code" and tbl_cat5."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat5",
FETCH_PACK(tbl_booking_mast."cio_booking_id") AS "Package",
to_char(tbl_booking_insert."Insert_Date" ,'''||p_dateformat||''') as "PubDate",
 tbl_booking_insert."Height" as "height",
 tbl_booking_insert."Width"  as "width",
tbl_booking_insert."Size_Book" as "Area",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where tbl_booking_insert."Premium1" =ADVPOS_PREM_MAST."Premiumcode") as "Pagepremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where tbl_booking_insert."Page_Post" =advpos_type_mast."Pos_Type_Code") as "Postprem",
(select scheme_master."Scheme_Name" from scheme_master where tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id") as "scheme",
tbl_booking_mast."Rate_code" as "Ratecode",
tbl_booking_mast."Card_rate" as "cardrate",
tbl_booking_mast."Card_rate"*tbl_booking_insert."Size_Book" as "cardamt",
tbl_booking_mast."Contract_rate" as "contractrate",
TBL_BOOKING_mast."Deviation" as "Deviationamt",
TBL_BOOKING_mast."Deviation" AS "Deviation(%)",
tbl_booking_mast."Agrred_rate" as "Aggrate",
tbl_booking_insert."Agreed_Rate"  as "aggamt",
((tbl_booking_mast."Card_rate"*tbl_booking_insert."Size_Book") - DECODE(NVL(tbl_booking_insert."Agreed_Rate",0),0,(tbl_booking_mast."Card_rate"*tbl_booking_insert."Size_Book"),tbl_booking_insert."Agreed_Rate")) as "DiscAmt",
tbl_booking_mast."Discount_per" as "Discper",
(select SUM(nvl(RAT,0)) from multipack_rat where cioid=tbl_booking_mast."cio_booking_id"  and sess_id='||userenv('sessionid')||') as  "posamt",
(select SUM(nvl(PER_AMT,0)) from multipack_rat where cioid=tbl_booking_mast."cio_booking_id"   and sess_id='||userenv('sessionid')||') as "pos(%)",
round(((tbl_booking_mast."Special_disc_per" * tbl_booking_insert."Size_Book" * tbl_booking_mast."Card_rate")/100),2) as "Spdiscamt",
tbl_booking_mast."Special_disc_per" as "Spdiscper",
round(((tbl_booking_mast."Space_disc_per" * tbl_booking_insert."Size_Book" * tbl_booking_mast."Card_rate")/100),2) as "Spacedisc",
tbl_booking_mast."Space_disc_per" as "Spacediscper",
tbl_booking_mast."Special_charges" as "Specialcharge",
nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0'') as "AgencyAddlTD(%)",
nvl((nvl(tbl_booking_insert."Gross_Rate" ,''0'')*nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0'')/100),''0'') as "AgencyAddlTDAmt",
nvl(tbl_booking_insert."Gross_Rate",''0'') as "Grossamt",
(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1 ) as "RetTD(%)",
nvl(tbl_booking_insert."Gross_Rate",''0'')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1 )/100 as "RetTDAmt",
nvl(tbl_booking_mast."Trade_disc",''0'' )as "AgencyTD(%)",
(nvl(tbl_booking_insert."Gross_Rate",''0'')* nvl(tbl_booking_mast."Trade_disc",''0'' )/100 )as "AgencyTDAmt",
NVL(TBL_BOOKING_INSERT."Bill_Amt",''0'') as "Billamt",
nvl(case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then 
         
               (
                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,''0''))-to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0'') ))
                end  )
         
         
         when ''Net''   then  to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,''0''))
        END )
       
    ELSE (select 0  from dual)
end  ,''0'') as "RetComm(%)",

nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then 
         
        
               
                (
                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
               -- ELSE (to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,''0''))-(nvl((nvl(tbl_booking_insert."Gross_Rate",''0'')*to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0''))/100),''0'')))
                else (nvl(tbl_booking_insert."Gross_Rate",0)*(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,''0''))-to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0'')) )/100)
                 end )
         
         
          
         when ''Net''   then  (nvl(tbl_booking_insert."Gross_Rate",''0'')*(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,''0'')) )/100)
        END )
       
    ELSE (select 0  from dual)
end
,''0'') as "RetCommAmt",


minus_to_zero(nvl((  NVL(TBL_BOOKING_INSERT."Bill_Amt",''0'')-
nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then 
           (
                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                -- ELSE (to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,''0''))-(nvl((nvl(tbl_booking_insert."Gross_Rate",''0'')*to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 else (nvl(tbl_booking_insert."Gross_Rate",0)*(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,''0''))-to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0'')) )/100)
               
                 end )
          
         when ''Net''   then  (nvl(tbl_booking_insert."Gross_Rate",''0'')*(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,''0'')) )/100)
        END )
       
    
    
    ELSE (select 0  from dual)
end
,''0'') ),''0'')) as "ActualBusiness",
(SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE tbl_booking_mast."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter"
,UOM_MAST."Uom_Name"  AS "Uom",
pub_mast."Pub_Name" as "Publication",
TBL_BOOKING_INSERT."Edition" as "Edition",
uom_mast.UOM_DESC as "uomdesc"
,(select pub_cent_mast."Pub_Cent_name" from pub_cent_mast where pub_cent_mast."Pub_cent_Code" in(select "pub_center" from  BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name") ) as "Printcenter"
--old version
,tbl_booking_mast."branch" as "Branch"
--new version
--,(SELECT "Branch_Name" FROM BRANCH_MST where  TBL_BOOKING_mast."branch" = "Branch_Code") as "Branch"

,case '''||p_base||'''
when ''1'' then  AGENCY_MAST."Dist_Code"
when ''2'' then (select dist_mst."Dist_Name" from dist_mst where dist_mst."Dist_Code" in(select exec_mast."dist_code" from exec_mast where  exec_mast."Exe_no"=tbl_booking_mast."Executive_code" )  )
when ''3'' then (select dist_mst."Dist_Name" from dist_mst where dist_mst."Dist_Code" in(select RETAINERMASTER."Dist_Code" from RETAINERMASTER where  RETAINERMASTER."Retain_Code"= tbl_booking_mast.RETAINER )  ) end as "District"
,case '''||p_base||'''
when ''1'' then (select taluka_mast.TALU_NAME  from taluka_mast where AGENCY_MAST.TALUKA=taluka_mast.TALU_CODE )
when ''2'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select exec_mast.TALUKA from exec_mast where  exec_mast."Exe_no"=tbl_booking_mast."Executive_code" )  )
when ''3'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select RETAINERMASTER.TALUKA from RETAINERMASTER where  RETAINERMASTER."Retain_Code"= tbl_booking_mast.RETAINER )  ) end as "Taluka"
,tbl_booking_insert."Page_No" as "Page_No"
,CASHDISCOUNT as "Cash_Disc"
,"Insert_Status" as "Status"
,"Box_code" as "BoxCode",TBL_BOOKING_MAST."Userid" as USERID,(SELECT max("username") from login where com_code = TBL_BOOKING_MAST."Comp_code" and "userid"=TBL_BOOKING_MAST."Userid") as USERNAME
FROM TBL_BOOKING_MAST,AGENCY_MAST ,uom_mast,
adv_cat_mast,
adv_type_mast,pub_mast,
TBL_BOOKING_insert
WHERE TBL_BOOKING_MAST."Comp_code"='''||p_compcode||''' AND
UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
tbl_booking_insert."Ad_Cat" =adv_cat_mast."Adv_Cat_Code" and
tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code"
and adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code" and
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" 
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||p_puserid||''') and '''||p_chk_access||'''=''1'')
or  ('''||p_chk_access||'''=''0'') )' ;

if(p_base='2')then
query3:=query3 ||' and (tbl_booking_mast."Executive_code" is not null and tbl_booking_mast."Executive_code" !=''0'')  ';
end if;

if(p_base='3')then
query3:=query3 ||' and (tbl_booking_mast.RETAINER is not null  and tbl_booking_mast.RETAINER !=''0'')  ';
end if;


if(p_drpstatus is null) then
query3:=query3||' and lower("Insert_Status")!='''||'cancel'||'''';
end if;


if(p_insertstatus is not null) then
query3:=query3||' and lower("Insert_Status")='''||p_insertstatus||'''';
end if;


IF(p_fromdate IS NOT NULL AND p_dateto IS NULL )
THEN
query3:=query3 ||' and tbl_booking_insert."Insert_Date" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL)
THEN
query3:=query3 ||' and tbl_booking_insert."Insert_Date" between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query3:=query3 ||' and TBL_BOOKING_insert."Publication_Code"='''||p_publication||'''    ';
END IF;

--old version
IF(p_pub_cent IS NOT NULL)
THEN
query3:=query3||'  and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;

IF(p_branch IS NOT NULL)
THEN
query3:=query3 ||'  and tbl_booking_mast."branch" ='''||p_branch||'''';
END IF;
--new version
/*
IF(p_pub_cent IS NOT NULL)
THEN
query3:=query3||'  and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query3:=query3||'  and TBL_BOOKING_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''||p_branch||''') ';
END IF;
*/
IF(p_edition IS NOT NULL)
THEN
query3:=query3 ||'  and tbl_booking_insert."Edition_Code"='''||p_edition||'''';
END IF;
IF(p_region IS NOT NULL)
THEN
query3:=query3  ||' and agency_mast."region" ='''||p_region||'''';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query3:=query3  ||' and tbl_booking_mast."Revenue_center" ='''||p_revcenter||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Ad_type_code"='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Agency_type" ='''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_insert."Ad_Cat" ='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Ad_sub_cat_code" ='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Ad_Subcat3" ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Ad_Subcat4" ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Ad_subcat5" ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Package_code" ='''||p_package||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Scheme_type_code" ='''||p_scheme||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Agency_code" ='''||p_agency||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Client_code" ='''||p_client||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Executive_code" ='''||p_executive||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST.RETAINER ='''||p_retainer||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query3:=query3 || ' and TBL_BOOKING_MAST."Product_code" ='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Brand_code" ='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Variant_code" ='''||p_varient||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Page_type_code" ='''||p_pagetype||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query3:=query3 || ' and TBL_BOOKING_insert."Premium1" ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query3:=query3 || ' and TBL_BOOKING_insert."Page_Post" ='''||p_postprem||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query3:=query3 || ' and TBL_BOOKING_MAST."ro_status" ='''||p_rostatus||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query3:=query3 || ' and TBL_BOOKING_MAST."Booking_type" ='''||p_booktype||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query3:=query3 || ' and TBL_BOOKING_MAST."Contract_name" ='''||p_contractname ||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query3:=query3 || ' and tbl_booking_insert."Supp_Code" ='''||p_suppliment||'''';
END IF;

IF(p_ratetype  IS NOT NULL)
THEN
query3:=query3 || ' and tbl_booking_MAST."Rate_code" ='''||p_ratetype||'''';
END IF;

IF(p_city  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."City_Code" ='''||p_city||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and tbl_booking_mast."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" ='''||p_city||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"='''||p_city||''')';
end if;
END IF;

IF(p_zone  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."zone_code" ='''||p_zone||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and tbl_booking_mast."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= '''||p_zone||''') )';
end if;

if(p_base='3')then
query3:=query3 || ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"='''||p_zone||''')';
end if;
END IF;

IF(p_district  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."Dist_Code" ='''||p_district||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and tbl_booking_mast."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code" ='''||p_district||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"='''||p_district||''')';
end if;
END IF;

IF(p_state  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."State_Code" ='''||p_state||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and tbl_booking_mast."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code" ='''||p_state||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"='''||p_state||''')';
end if;
END IF;

IF(p_taluka  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST.TALUKA='''||p_taluka||'''  ';
end if;

if(p_base='2')then
query3:=query3 || ' and tbl_booking_mast."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA ='''||p_taluka||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA='''||p_taluka||''')';
end if;
END IF;

query3:=query3 || ' order by tbl_booking_insert."Insert_Date" ,TBL_BOOKING_MAST."cio_booking_id"';
--DELETE FROM SEARCHTBL;
--insert into searchtbl values(query3);
--commit;
OPEN p_recordset1 FOR
query3;

end if;

else

if(p_adcheck=1)
then


query1:=query1||'SELECT
to_char(a."date_time",''dd/mm/yyyy'') as "Date",
sum(a."No_of_insertion") as "noinsert",
sum(a."Paid_ins") as "Paidinsert",sum(a."Total_area") as "Area",
sum(a."Card_amount") as "cardamt",
sum(a."Deviation") as "Deviationamt",
round(((nvl(sum(a."Deviation"),0)*100)/sum(a."Card_amount")),2) AS "Deviation(%)",
sum(a."Agreed_amount") as "aggamt",
(sum(a."Card_amount")- DECODE(NVL(sum(a."Agreed_amount"),0),0,sum(a."Card_amount"),sum(a."Agreed_amount"))) as "DiscAmt",
round((((sum(a."Card_amount")- DECODE(NVL(sum(a."Agreed_amount"),0),0,sum(a."Card_amount"),sum(a."Agreed_amount"))) *100)/sum(a."Card_amount")),2)  as "Discper",
sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id"  and sess_id='||userenv('sessionid')||')) as  "posamt",
round(((sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id"  and sess_id='||userenv('sessionid')||'))*100)/sum(a."Card_amount")),2)   as "pos(%)",
sum(a."Special_disc_per" * a."Total_area" * a."Card_rate"/100) as "Spdiscamt",
round(((sum(a."Special_disc_per" * a."Total_area" * a."Card_rate"/100)*100)/sum(a."Card_amount")),2)  as "Spdiscper",
sum(a."Space_disc_per" * a."Total_area" * a."Card_rate"/100) as "Spacedisc",
round(((sum(a."Space_disc_per" * a."Total_area" * a."Card_rate"/100) *100)/sum(a."Card_amount")),2) as "Spacediscper",
sum(a."Special_charges") as "Specialcharge",
round(((sum(nvl((nvl(a."Gross_amount",''0'')*nvl(a."ADD_AGENCY_COMM",''0'')/100),''0''))*100)/(sum(a."Card_amount")+sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id" and sess_id='||userenv('sessionid')||'))+sum(a."Special_charges")-sum(a."Deviation")-(sum(a."Card_amount")- DECODE(NVL(sum(a."Agreed_amount"),0),0,sum(a."Card_amount"),sum(a."Agreed_amount"))) -sum(a."Space_disc_per" * a."Total_area" * a."Card_rate"/100)-sum(a."Special_disc_per" * a."Total_area" * a."Card_rate"/100))),2) as "AgencyAddlTD(%)",
sum(nvl((nvl(a."Gross_amount",''0'')*nvl(a."ADD_AGENCY_COMM",''0'')/100),''0'')) as "AgencyAddlTDAmt",
sum(nvl(a."Gross_amount",''0'')) as "Grossamt",
round(((sum(nvl(nvl(a."Gross_amount",''0'')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1 )/100,''0''))*100)/sum(nvl(a."Gross_amount",''0''))),2) as "RetTD(%)",
sum(nvl(nvl(a."Gross_amount",''0'')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1 )/100,''0''))as "RetTDAmt",
round(((sum((nvl(a."Gross_amount",''0'')* nvl(a."Trade_disc",''0'' )/100) )*100)/(sum(a."Card_amount")+sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id"  and sess_id='||userenv('sessionid')||'))+sum(a."Special_charges")-sum(a."Deviation")-(sum(a."Card_amount")- DECODE(NVL(sum(a."Agreed_amount"),0),0,sum(a."Card_amount"),sum(a."Agreed_amount"))) -sum(a."Space_disc_per" * a."Total_area" * a."Card_rate"/100)-sum(a."Special_disc_per" * a."Total_area" * a."Card_rate"/100))),2)as "AgencyTD(%)",
sum((nvl(a."Gross_amount",''0'')* nvl(a."Trade_disc",''0'' )/100) )as "AgencyTDAmt",
sum(nvl(a."Bill_amount",''0'')) as "Billamt",
round(((sum(nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1)
       when ''Gross'' then 
       
         (
                 CASE to_number(nvl(a.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(a.RETAINER_COMM,''0''))-to_number(nvl(a."ADD_AGENCY_COMM",''0'') ))
                 end )
       
       
         when ''Net''   then  to_number(nvl(a.RETAINER_COMM,''0''))
          END )
        
        
       
    ELSE (select 0  from dual)
end
,''0''))*100)/sum(nvl(a."Gross_amount",''0''))),2) as "RetComm(%)",
sum(nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1)
       when ''Gross'' then 
       
                
                 (
                 CASE to_number(nvl(a.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(a.RETAINER_COMM_AMT,''0''))-(nvl((nvl(a."Gross_amount",''0'')*to_number(nvl(a."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )
        
         when ''Net''   then  (nvl(a."Gross_amount",''0'')*(to_number(nvl(a.RETAINER_COMM,''0'')) )/100)
            END )
        
        
      
       
    ELSE (select 0  from dual)
end
,''0'')) as "RetCommAmt",

minus_to_zero(sum(nvl((a."Bill_amount"-nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1)
       when ''Gross'' then 
       (
                 CASE to_number(nvl(a.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(a.RETAINER_COMM_AMT,''0''))-(nvl((nvl(a."Gross_amount",''0'')*to_number(nvl(a."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )
       
        
         when ''Net''   then  (nvl(a."Gross_amount",''0'')*(to_number(nvl(a.RETAINER_COMM,''0'')) )/100)
           END )
       
    ELSE (select 0  from dual)
end
,''0'')  ),''0'') ))as "ActualBusiness"
/*,TBL_BOOKING_MAST."Userid" as USERID,(SELECT max("username") from login where com_code = TBL_BOOKING_MAST."Comp_code" and "userid"=TBL_BOOKING_MAST."Userid") as USERNAME*/
FROM TBL_BOOKING_MAST a,
agency_mast
WHERE a."Comp_code"='''||p_compcode||''' AND
a."Agency_sub_code"=AGENCY_MAST."code_subcode"' ;


if(p_chk_access='1')then
query1:=query1||' and a."cio_booking_id"  in (select distinct b."Cio_Booking_Id" from tbl_booking_insert b where a."cio_booking_id"=b."Cio_Booking_Id" and b."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||p_puserid||''')) ';
end if;

if(p_base='2')then
query1:=query1||' and (a."Executive_code" is not null and a."Executive_code" !=''0'')  ';
end if;

if(p_base='3')then
query1:=query1||' and (a.RETAINER is not null  and a.RETAINER !=''0'')  ';
end if;


if(p_drpstatus is null) then
query1:=query1||' and a."cio_booking_id"  in (select distinct b."Cio_Booking_Id" from tbl_booking_insert b where a."cio_booking_id"=b."Cio_Booking_Id" AND lower("Insert_Status")!='''||'cancel'||''' )';
end if;

if(p_insertstatus is not null) then
query1:=query1||' and a."cio_booking_id"  in (select distinct b."Cio_Booking_Id" from tbl_booking_insert b where a."cio_booking_id"=b."Cio_Booking_Id" AND lower("Insert_Status")='''||p_insertstatus||''' )';
end if;


IF(p_fromdate IS NOT NULL AND p_dateto IS NULL  and  p_filterby='Booking Date')
THEN
query1:=query1||' and a."date_time" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL and p_filterby='Booking Date' )
THEN
query1:=query1||' and a."date_time" between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NULL  and  p_filterby='Publish Date')
THEN
query1:=query1||' and a."Insertion_date" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL and p_filterby='Publish Date' )
THEN
query1:=query1||' and a."Insertion_date"  between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query1:=query1||'  and a."cio_booking_id"  in (select distinct b."Cio_Booking_Id" from tbl_booking_insert b where b."Publication_Code"='''||p_publication||''' )    ';
END IF;

--old version
IF(p_pub_cent IS NOT NULL)
THEN
query1:=query1||'  and a."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE a."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query1:=query1||' and a."branch" ='''||p_branch||'''';
END IF;


--new version
/*
IF(p_pub_cent IS NOT NULL)
THEN
query1:=query1||'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query1:=query1||'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''||p_branch||''') ';
END IF;
*/

IF(p_edition IS NOT NULL)
THEN
query1:=query1||' and a."cio_booking_id"  in (select distinct b."Cio_Booking_Id" from tbl_booking_insert b where b."Edition_Code"='''||p_edition||''' )';
END IF;

IF(p_region IS NOT NULL)
THEN
query1:=query1 ||'  and agency_mast."region" ='''||p_region||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query1:=query1 || '  and a."cio_booking_id"  in (select distinct b."Cio_Booking_Id" from tbl_booking_insert b where b."Supp_Code" ='''||p_suppliment||''' )';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query1:=query1 ||' and a."Revenue_center" ='''||p_revcenter||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query1:=query1 || ' and a."Ad_type_code"='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query1:=query1 || ' and a."Agency_type" ='''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query1:=query1 || ' and a."Ad_cat_code" ='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query1:=query1 || ' and a."Ad_sub_cat_code" ='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query1:=query1 || ' and a."Ad_Subcat3" ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query1:=query1 || ' and a."Ad_Subcat4" ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query1:=query1 || ' and a."Ad_subcat5" ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query1:=query1 || ' and a."Package_code" ='''||p_package||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query1:=query1 || ' and a."Scheme_type_code" ='''||p_scheme||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query1:=query1 || ' and a."Agency_code" ='''||p_agency||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query1:=query1 || ' and a."Client_code" ='''||p_client||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query1:=query1 || ' and a."Executive_code" ='''||p_executive||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query1:=query1 || ' and a.RETAINER ='''||p_retainer||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query1:=query1 || ' and a."Product_code" ='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query1:=query1 || ' and a."Brand_code" ='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query1:=query1 || ' and a."Variant_code" ='''||p_varient||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query1:=query1 || ' and a."Page_type_code" ='''||p_pagetype||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query1:=query1 || ' and a."Page_prem" ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query1:=query1 || ' and a."Page_position_code" ='''||p_postprem||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query1:=query1 || ' and a."ro_status" ='''||p_rostatus||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query1:=query1 || ' and a."Booking_type" ='''||p_booktype||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query1:=query1 || ' and a."Contract_name" ='''||p_contractname ||'''';
END IF;



IF(p_ratetype  IS NOT NULL)
THEN
query1:=query1 || ' and a."Rate_code" ='''||p_ratetype||'''';
END IF;

IF(p_city  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."City_Code" ='''||p_city||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" ='''||p_city||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  RETAINERMASTER RET where  RET."City_Code"='''||p_city||''')';
end if;
END IF;

IF(p_zone  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."zone_code" ='''||p_zone||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= '''||p_zone||''') )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  RETAINERMASTER RET where  RET."Zone_Code"='''||p_zone||''')';
end if;
END IF;

IF(p_district  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."Dist_Code" ='''||p_district||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code" ='''||p_district||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  RETAINERMASTER RET where  RET."Dist_Code"='''||p_district||''')';
end if;
END IF;

IF(p_state  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."State_Code" ='''||p_state||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code" ='''||p_state||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  RETAINERMASTER RET where  RET."State_Code"='''||p_state||''')';
end if;
END IF;

IF(p_taluka  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST.TALUKA='''||p_taluka||'''  ';
end if;

if(p_base='2')then
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA ='''||p_taluka||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  RETAINERMASTER RET where  RET.TALUKA='''||p_taluka||''')';
end if;
END IF;

query1:=query1 || ' group by a."date_time" order by "Date" ';



OPEN p_recordset1 FOR
query1;



elsif(p_adcheck=2)then

delete from temp_ad_bills_report where sess_id=userenv('sessionid');
open c2;
loop
fetch c2 into v2;
exit when c2%notfound;
     v_val:=FUN_BILL_INSERT(p_compcode,v2.CIOID,v2.BILLNO,prefer,p_dateformat,v2.AGMAINCODE,v2.AG_SUB_CODE,v2.AGCODE,v2.AGNAME,v2.EXECCODE,v2.EXECNAME,v2.RETCODE,v2.RETNAME,p_base );    
end loop;
close c2;
commit;


query2:=query2||'SELECT 
to_char(BILLDATE,'''||p_dateformat||''') as "Date",
sum(NOINSERT) as "noinsert",
sum(PAIDINSERT) as "Paidinsert" ,
sum(AREA) as "Area",
sum(CARDAMT) as "cardamt",
sum(DEVIATIONAMT) as "Deviationamt",
round(((nvl(sum(DEVIATIONAMT),0) *100)/nvl(sum(CARDAMT),0)),2)   AS "Deviation(%)",
sum(AGGAMT)  as "aggamt",
sum(DISCAMT) as "DiscAmt",
round(((nvl(sum(DISCAMT),0) *100)/nvl(sum(CARDAMT),0)),2) as "Discper",
sum(POSAMT)as  "posamt",
round(((nvl(sum(POSAMT),0) *100)/nvl(sum(CARDAMT),0)),2)  as "pos(%)",
sum(SPDISCAMT) as "Spdiscamt",
round(((nvl(sum(SPDISCAMT),0)*100)/nvl(sum(CARDAMT),0)),2)  as "Spdiscper",
sum(SPACEDISC) as "Spacedisc",
round(((nvl(sum(SPACEDISC),0)*100)/nvl(sum(CARDAMT),0)),2)  as "Spacediscper",
sum(SPECIALCHARGE) as "Specialcharge",
sum(AGENCYADDLTDAMT) as "AgencyAddlTDAmt",
round(((nvl(sum(AGENCYADDLTDAMT),0)*100)/(nvl(sum(CARDAMT),0)+nvl(sum(POSAMT),0)+nvl(sum(SPECIALCHARGE),0)-nvl(sum(DEVIATIONAMT),0)-nvl(sum(DISCAMT),0)-nvl(sum(SPDISCAMT),0)-nvl(sum(SPACEDISC),0))),2) as "AgencyAddlTD(%)",
sum(GROSSAMT)  as "Grossamt",
sum(RETTDAMT)as "RetTDAmt",
round(((nvl(sum(RETTDAMT),0)*100)/nvl(sum(GROSSAMT),0) ),2) as "RetTD(%)",
sum(AGENCYTDAMT)as "AgencyTDAmt",
round(((nvl(sum(AGENCYTDAMT),0)*100)/(nvl(sum(CARDAMT),0)+nvl(sum(POSAMT),0)+nvl(sum(SPECIALCHARGE),0)-nvl(sum(DEVIATIONAMT),0)-nvl(sum(DISCAMT),0)-nvl(sum(SPDISCAMT),0)-nvl(sum(SPACEDISC),0))),2)as "AgencyTD(%)",
sum(BILLAMT )as "Billamt",
sum(RETCOMMAMT)as "RetCommAmt",
round(((nvl(sum(RETCOMMAMT),0)*100)/nvl(sum(GROSSAMT),0)),2) as "RetComm(%)",
minus_to_zero(sum(ACTUALBUSINESS))as "ActualBusiness"
from temp_ad_bills_report where sess_id='||userenv('sessionid');




IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL )
THEN
query2:=query2||' and BILLDATE between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query2:=query2||' and PRIPUB='''||p_publication||'''';
END IF;

IF(p_pub_cent IS NOT NULL)
THEN
query2:=query2||'   and PUB_CENT_CODE='''||p_pub_cent||'''';
END IF;

IF(p_edition IS NOT NULL)
THEN
query2:=query2||'  and PEDITION='''||p_edition||'''';
END IF;

IF(p_branch IS NOT NULL)
THEN
query2:=query2||'  and  BRANCH_NAME ='''||p_branch||''' ';
END IF;

IF(p_region IS NOT NULL)
THEN
query2:=query2 ||' and REGION='''||p_region ||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query2:=query2 || ' and PADTYPE='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query2:=query2 || ' and AGENCY_TYPE_CODE= '''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query2:=query2 || ' and PRIADCTG='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query2:=query2 || ' and SECADCTG ='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query2:=query2 || ' and AD_SUBCAT3 ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query2:=query2 || ' and AD_SUBCAT4 ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query2:=query2 || ' and AD_SUBCAT5 ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query2:=query2 || ' and PACKAGE_CODE='''||p_package||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query2:=query2 || ' and AG_MAIN_CODE ='''||p_agency ||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query2:=query2 || ' and CLIENTCD='''||p_client ||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query2:=query2 || ' and EXECUTIVE_NAME='''||p_executive||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query2:=query2 || ' and PRIPROCTG='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query2:=query2 || ' and BRAND_CODE='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query2:=query2 || ' and   VARIENT_NAME='''||p_varient||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query2:=query2 || ' and PAGE_PREM ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query2:=query2 || ' and PAGE_POST ='''||p_postprem||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query2:=query2 || ' and CONTRACT_NAME ='''||p_contractname ||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query2:=query2 || ' and SUPP_CODE='''||p_suppliment||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query2:=query2 || ' and RETAINER_CODE='''||p_retainer||'''';
END IF;

IF(p_ratetype  IS NOT NULL)
THEN
query2:=query2 || ' and RATECD ='''||p_ratetype||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query2:=query2 || ' and PSCHEME='''||p_scheme||'''';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query2:=query2 ||' and REVENUE_CENTER='''||p_revcenter||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query2:=query2 || ' and RO_STATUS='''||p_rostatus||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query2:=query2 || ' and PAGE_TYPE ='''||p_pagetype||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query2:=query2 || ' and BOOKING_TYPE='''||p_booktype||'''';
END IF;



IF(p_city  IS NOT NULL)
THEN
query2:=query2 || ' and CITY_CODE ='''||p_city||'''';
END IF;

IF(p_zone  IS NOT NULL)
THEN
query2:=query2 || ' and ZONE_CODE ='''||p_zone||'''';
end if;

IF(p_district  IS NOT NULL)
THEN
query2:=query2 || ' and DIST_CODE ='''||p_district||'''';
end if;

IF(p_state  IS NOT NULL)
THEN
query2:=query2 || ' and STATE_CODE ='''||p_state||'''';
end if;

IF(p_taluka  IS NOT NULL)
THEN
query2:=query2 || ' and PTALUKA='''||p_taluka||'''  ';
end if;

if(p_base='2')then
query2:=query2 ||' and (EXECUTIVE_NAME   is not null and EXECUTIVE_NAME !=''0'')  ';
end if;

if(p_base='3')then
query2:=query2 ||' and (RETAINER_CODE  is not null  and RETAINER_CODE  !=''0'')  ';
end if;



query2:=query2 || ' group by BILLDATE   order by BILLDATE ';




OPEN p_recordset1 FOR
query2;

elsif(p_adcheck=3) then
query3:=query3 ||'SELECT  
to_char(b."Insert_Date" ,'''||p_dateformat||''') as "Date",
sum(a."No_of_insertion") as "noinsert",
sum(a."Paid_ins") as "Paidinsert",
sum(b."Size_Book") as "Area",
sum(a."Card_rate"*b."Size_Book") as "cardamt",
sum(a."Deviation") as "Deviationamt",
round(((sum(a."Deviation")*100)/sum(a."Card_rate"*b."Size_Book")),2) AS "Deviation(%)",
sum(b."Agreed_Rate")  as "aggamt",
(sum(a."Card_rate"*b."Size_Book")- DECODE(NVL(sum(b."Agreed_Rate"),0),0,sum(a."Card_rate"*b."Size_Book"),sum(b."Agreed_Rate"))) as "DiscAmt",
round((((sum(a."Card_rate"*b."Size_Book")- DECODE(NVL(sum(b."Agreed_Rate"),0),0,sum(a."Card_rate"*b."Size_Book"),sum(b."Agreed_Rate")))*100)/sum(a."Card_rate"*b."Size_Book")),2) as "Discper",
sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id" and sess_id='||userenv('sessionid')||')) as  "posamt",
round(((sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id" and sess_id='||userenv('sessionid')||'))*100)/sum(a."Card_rate"*b."Size_Book")),2)  as "pos(%)",
sum(a."Special_disc_per" * b."Size_Book" * a."Card_rate"/100) as "Spdiscamt",
round(((sum(a."Special_disc_per" * b."Size_Book" * a."Card_rate"/100)*100)/sum(a."Card_rate"*b."Size_Book")),2) as "Spdiscper",
sum(a."Space_disc_per" * b."Size_Book" * a."Card_rate"/100) as "Spacedisc",
round(((sum(a."Space_disc_per" * b."Size_Book" * a."Card_rate"/100)*100)/sum(a."Card_rate"*b."Size_Book")),2) as "Spacediscper",
sum(a."Special_charges") as "Specialcharge",
round(((sum(nvl((nvl(b."Gross_Rate" ,''0'')*nvl(a."ADD_AGENCY_COMM",''0'')/100),''0''))*100)/(sum(a."Card_rate"*b."Size_Book")+sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id" and sess_id='||userenv('sessionid')||'))+sum(a."Special_charges") -sum(a."Deviation")-(sum(a."Card_rate"*b."Size_Book")- DECODE(NVL(sum(b."Agreed_Rate"),0),0,sum(a."Card_rate"*b."Size_Book"),sum(b."Agreed_Rate")))-sum(a."Special_discount")-sum(a."Space_discount"))),2) as "AgencyAddlTD(%)",
sum(nvl((nvl(b."Gross_Rate" ,''0'')*nvl(a."ADD_AGENCY_COMM",''0'')/100),''0'')) as "AgencyAddlTDAmt",
ROUND(sum(nvl(b."Gross_Rate",''0'') ))as "Grossamt",
case sum(nvl(b."Gross_Rate",''0'') )
 when  0 then 0
   else  round(((sum(nvl(b."Gross_Rate",''0'')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1 )/100)*100)/sum(nvl(b."Gross_Rate",''0'') )),2)
 end  as "RetTD(%)",
sum(nvl(nvl(b."Gross_Rate",''0'')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1 )/100
,''0''))as "RetTDAmt",

round(((sum((nvl(b."Gross_Rate",''0'')* nvl(a."Trade_disc",''0'' )/100 ))*100)/(sum(a."Card_rate"*b."Size_Book")+sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id" and sess_id='||userenv('sessionid')||'))+sum(a."Special_charges") -sum(a."Deviation")-(sum(a."Card_rate"*b."Size_Book")- DECODE(NVL(sum(b."Agreed_Rate"),0),0,sum(a."Card_rate"*b."Size_Book"),sum(b."Agreed_Rate")))-sum(a."Special_discount")-sum(a."Space_discount"))),2) as "AgencyTD(%)",

sum((nvl(b."Gross_Rate",''0'')* nvl(a."Trade_disc",''0'' )/100 ))as "AgencyTDAmt",
ROUND(sum(NVL(b."Bill_Amt",''0'')),2) as "Billamt",
 case sum(nvl(b."Gross_Rate",''0'') )
 when  0 then 0
 else  round(((sum(nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1)
        when ''Gross'' then 
        
         (
                 CASE to_number(nvl(a.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(a.RETAINER_COMM,''0''))-to_number(nvl(a."ADD_AGENCY_COMM",''0'' )))
               end   )
        
        
        
         when ''Net''   then  to_number(nvl(a.RETAINER_COMM,''0''))
          END )
        
          
       
       
    ELSE (select 0  from dual)
end
,''0'')) *100)/sum(nvl(b."Gross_Rate",''0'') )),2)
 
 end  as "RetComm(%)",

sum(nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1)
       when ''Gross'' then 
       
       
              
                
                 (
                 CASE to_number(nvl(a.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(a.RETAINER_COMM_AMT,''0''))-(nvl((nvl(b."Gross_Rate",''0'')*to_number(nvl(a."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )
       
       
        
         when ''Net''   then  (nvl(b."Gross_Rate",''0'')*(to_number(nvl(a.RETAINER_COMM,''0'')) )/100)
        END )
       
       
    ELSE (select 0  from dual)
end
,''0''))as "RetCommAmt",


minus_to_zero(ROUND(sum(nvl((  NVL(b."Bill_Amt",''0'')-nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1)
        when ''Gross'' then 
        (
                 CASE to_number(nvl(a.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(a.RETAINER_COMM_AMT,''0''))-(nvl((nvl(b."Gross_Rate",''0'')*to_number(nvl(a."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )
        
         
         when ''Net''   then  (nvl(b."Gross_Rate",''0'')*(to_number(nvl(a.RETAINER_COMM,''0'')) )/100)
        END )
       
    ELSE (select 0  from dual)
end
,''0'')  ),''0'')),2)) as "ActualBusiness"
,TBL_BOOKING_MAST."Userid" as USERID,(SELECT max("username") from login where com_code = TBL_BOOKING_MAST."Comp_code" and "userid"=TBL_BOOKING_MAST."Userid") as USERNAME
FROM TBL_BOOKING_MAST a,AGENCY_MAST ,TBL_BOOKING_insert b
WHERE a."Comp_code"='''||p_compcode||''' AND
a."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
a."cio_booking_id"=b."Cio_Booking_Id"
and ((b."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||p_puserid||''') and '''||p_chk_access||'''=''1'')
or  ('''||p_chk_access||'''=''0'') )'; 


if(p_base='2')then
query3:=query3 ||' and (a."Executive_code" is not null and a."Executive_code" !=''0'')  ';
end if;

if(p_base='3')then
query3:=query3 ||' and (a.RETAINER is not null  and a.RETAINER !=''0'')  ';
end if;


if(p_drpstatus is null) then
query3:=query3||' and lower("Insert_Status")!='''||'cancel'||'''';
end if;


if(p_insertstatus is not null) then
query3:=query3||' and lower("Insert_Status")='''||p_insertstatus||'''';
end if;


IF(p_fromdate IS NOT NULL AND p_dateto IS NULL )
THEN
query3:=query3 ||' and b."Insert_Date" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL)
THEN
query3:=query3 ||' and b."Insert_Date" between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query3:=query3 ||' and b."Publication_Code"='''||p_publication||'''    ';
END IF;

--old version

IF(p_pub_cent IS NOT NULL)
THEN
query3:=query3||'  and a."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE a."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;

IF(p_branch IS NOT NULL)
THEN
query3:=query3 ||'  and a."branch" ='''||p_branch||'''';
END IF;

--new version
/*
IF(p_pub_cent IS NOT NULL)
THEN
query3:=query3||'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query3:=query3||'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''||p_branch||''') ';
END IF;
*/
IF(p_edition IS NOT NULL)
THEN
query3:=query3 ||'  and b."Edition_Code"='''||p_edition||'''';
END IF;

IF(p_region IS NOT NULL)
THEN
query3:=query3 ||'  and agency_mast."region" ='''||p_region||'''';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query3:=query3  ||' and a."Revenue_center" ='''||p_revcenter||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query3:=query3  || ' and a."Ad_type_code"='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query3:=query3  || ' and a."Agency_type" ='''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query3:=query3  || ' and b."Ad_Cat" ='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query3:=query3  || ' and a."Ad_sub_cat_code" ='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query3:=query3  || ' and a."Ad_Subcat3" ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query3:=query3  || ' and a."Ad_Subcat4" ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query3:=query3  || ' and a."Ad_subcat5" ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query3:=query3  || ' and a."Package_code" ='''||p_package||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query3:=query3  || ' and a."Scheme_type_code" ='''||p_scheme||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query3:=query3  || ' and a."Agency_code" ='''||p_agency||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query3:=query3  || ' and a."Client_code" ='''||p_client||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query3:=query3  || ' and a."Executive_code" ='''||p_executive||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query3:=query3  || ' and a.RETAINER ='''||p_retainer||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query3:=query3 || ' and a."Product_code" ='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query3:=query3  || ' and a."Brand_code" ='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query3:=query3  || ' and a."Variant_code" ='''||p_varient||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query3:=query3  || ' and a."Page_type_code" ='''||p_pagetype||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query3:=query3 || ' and b."Premium1" ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query3:=query3 || ' and b."Page_Post"  ='''||p_postprem||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query3:=query3 || ' and a."ro_status" ='''||p_rostatus||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query3:=query3 || ' and a."Booking_type" ='''||p_booktype||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query3:=query3 || ' and a."Contract_name" ='''||p_contractname ||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query3:=query3 || ' and b."Supp_Code" ='''||p_suppliment||'''';
END IF;

IF(p_ratetype  IS NOT NULL)
THEN
query3:=query3 || ' and a."Rate_code" ='''||p_ratetype||'''';
END IF;

IF(p_city  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."City_Code" ='''||p_city||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" ='''||p_city||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"='''||p_city||''')';
end if;
END IF;

IF(p_zone  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."zone_code" ='''||p_zone||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= '''||p_zone||''') )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"='''||p_zone||''')';
end if;
END IF;

IF(p_district  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."Dist_Code" ='''||p_district||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code" ='''||p_district||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"='''||p_district||''')';
end if;
END IF;

IF(p_state  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."State_Code" ='''||p_state||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code" ='''||p_state||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"='''||p_state||''')';
end if;
END IF;

IF(p_taluka  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST.TALUKA='''||p_taluka||''' ';
end if;

if(p_base='2')then
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA ='''||p_taluka||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA='''||p_taluka||''')';
end if;
END IF;

query3:=query3 || ' group by b."Insert_Date" order by "Date" ';

OPEN p_recordset1 FOR
query3;

end if;
end if;




OPEN  p_accounts FOR
SELECT to_char( SYSDATE,p_dateformat) AS "Rundate",initcap("Comp_Name") AS "companyname" from comp_mst where "Comp_Code"=p_compcode;
delete from multipack_rep where sess_id=userenv('sessionid')  ;
delete from multipack_rat where sess_id=userenv('sessionid') ;
DELETE FROM multipack_ratnew where sess_id=userenv('sessionid')  ; commit;

END ;
/


/////////////////////////////////////////////end of issue-5825/////////////////////////////////////////////////////

/*======================================= nov-30-11 (Kuldeep Bhati)Retainer MAster ==============================*/
CREATE OR REPLACE PROCEDURE AD_RETAIN_COMM_TARGET_INS (PCOMP_CODE      IN VARCHAR2,
                                            PRETAIN_CODE   IN VARCHAR2,
                                            PTEAM_CODE      IN VARCHAR2,
                                            PADCTG_CODE     IN VARCHAR2,
                                            PFROM_TGT       IN NUMBER,
                                            PTO_TGT         IN NUMBER,
                                            PCUST_TYPE      IN VARCHAR2,
                                            PAD_TYPE        IN VARCHAR2,
                                            PPUB_TYPE       IN VARCHAR2,
                                            PPUBL_CODE      IN VARCHAR2,
                                            PCREATED_BY     IN VARCHAR2,
                                            PCREATED_DT     IN DATE,
                                            PUPDATED_BY     IN VARCHAR2,
                                            PUPDATED_DT     IN DATE,
                                            PCOMM_TARGET_ID IN NUMBER,
                                            PDML_TYPE        IN VARCHAR) AS
BEGIN
 IF NVL(PDML_TYPE,'?')='I' THEN
     INSERT INTO RETAIN_COMM_TARGET (COMP_CODE,RETAIN_CODE,TEAM_CODE,ADCTG_CODE,FROM_TGT,
                                     TO_TGT,CUST_TYPE,AD_TYPE,PUB_TYPE,PUBL_CODE,
                                     CREATED_BY,CREATED_DT,UPDATED_BY,UPDATED_DT,COMM_TARGET_ID)
                            VALUES  (PCOMP_CODE,PRETAIN_CODE,PTEAM_CODE,PADCTG_CODE,PFROM_TGT,
                                     PTO_TGT,PCUST_TYPE,PAD_TYPE,PPUB_TYPE,PPUBL_CODE,
                                     PCREATED_BY,PCREATED_DT,PUPDATED_BY,PUPDATED_DT,PCOMM_TARGET_ID);
     COMMIT;
 END IF;
 IF NVL(PDML_TYPE,'?')='U' THEN
     UPDATE RETAIN_COMM_TARGET SET TEAM_CODE = PTEAM_CODE, ADCTG_CODE = PADCTG_CODE, FROM_TGT = PFROM_TGT,
                                   TO_TGT = PTO_TGT, CUST_TYPE = PCUST_TYPE, AD_TYPE = PAD_TYPE,
                                   PUB_TYPE = PPUB_TYPE, PUBL_CODE = PPUBL_CODE, CREATED_BY = PCREATED_BY,
                                   CREATED_DT = PCREATED_DT,UPDATED_BY = PUPDATED_BY,UPDATED_DT = PUPDATED_DT
        WHERE COMP_CODE      = PCOMP_CODE
          AND RETAIN_CODE    = PRETAIN_CODE
          AND COMM_TARGET_ID = PCOMM_TARGET_ID;
     COMMIT;
 END IF;
 IF NVL(PDML_TYPE,'?')='D' THEN
     DELETE FROM RETAIN_COMM_TARGET
        WHERE COMP_CODE      = PCOMP_CODE
          AND RETAIN_CODE    = PRETAIN_CODE
          AND COMM_TARGET_ID = PCOMM_TARGET_ID;
     COMMIT;
 END IF;
END;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE AD_RETAIN_ADD_COMM_TARGET_INS (PCOMP_CODE      IN VARCHAR2,
                                            PRETAIN_CODE   IN VARCHAR2,
                                            PPUBL_CODE      IN VARCHAR2,
                                            PNO_OF_PUBL     IN VARCHAR2,
                                            PADCOMM_PER     IN NUMBER,
                                            PCOMM_TYPE      IN VARCHAR2,
                                            PCREATED_BY     IN VARCHAR2,
                                            PCREATED_DT     IN DATE,
                                            PUPDATED_BY     IN VARCHAR2,
                                            PUPDATED_DT     IN DATE,
                                            PCOMM_TARGET_ID IN NUMBER,
                                            PADD_COMM_ID    IN NUMBER,
                                            PDML_TYPE       IN VARCHAR) AS
BEGIN
 IF NVL(PDML_TYPE,'?')='I' THEN
     INSERT INTO RETAIN_ADCOMM_TARGET (COMP_CODE, RETAIN_CODE, PUBL_CODE, NO_OF_PUBL,ADCOMM_PER,
									  COMM_TYPE, CREATED_BY, CREATED_DT, UPDATED_BY, UPDATED_DT,COMM_TARGET_ID)
                            VALUES  (PCOMP_CODE,PRETAIN_CODE,PPUBL_CODE,PNO_OF_PUBL,PADCOMM_PER,
                                     PCOMM_TYPE,sysdate,PCREATED_DT,PUPDATED_BY,PUPDATED_DT,PCOMM_TARGET_ID);
     COMMIT;
 END IF;
 IF NVL(PDML_TYPE,'?')='U' THEN
     UPDATE RETAIN_ADCOMM_TARGET SET PUBL_CODE = PPUBL_CODE, NO_OF_PUBL = PNO_OF_PUBL, ADCOMM_PER = PADCOMM_PER,
                                   COMM_TYPE = PCOMM_TYPE,UPDATED_BY = PUPDATED_BY,UPDATED_DT = sysdate
        WHERE COMP_CODE      = PCOMP_CODE
          AND RETAIN_CODE    = PRETAIN_CODE
          AND ADD_COMM_ID = PADD_COMM_ID;
     COMMIT;
 END IF;
 IF NVL(PDML_TYPE,'?')='D' THEN
     DELETE FROM RETAIN_ADCOMM_TARGET
       WHERE COMP_CODE      = PCOMP_CODE
          AND RETAIN_CODE    =PRETAIN_CODE
         AND ADD_COMM_ID = PADD_COMM_ID;
     COMMIT;
 END IF;
END;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

CREATE OR REPLACE procedure retselectstructslab
(
compcode in varchar2,
userid in varchar2,
retcode in varchar2,
code11 in NUMBER,
p_accounts OUT Cur_Type_New1.cursor_type

)

as
begin

open p_accounts for
select TEAM_CODE,ADCTG_CODE,FROM_TGT,TO_TGT,CUST_TYPE,AD_TYPE,PUB_TYPE,PUBL_CODE,COMM_TARGET_ID from RETAIN_COMM_TARGET where COMP_CODE=compcode and RETAIN_CODE=retcode and COMM_TARGET_ID=code11;


end;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE procedure AD_RETAIN_COMM_TARGET_BIND
(
retcode in varchar2,
userid in varchar2,
compcode in varchar2,
p_accounts OUT Cur_Type_New1.cursor_type

)

as
begin

open p_accounts for
select * from RETAIN_COMM_TARGET where COMP_CODE=compcode  and RETAIN_CODE=retcode;


end;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE procedure insertretstatus_slab
(
compcode in varchar2,
userid in varchar2,
retcode in varchar2,
--enln in NUMBER, 
fromdays in NUMBER,
todays in NUMBER,
drpcommon in VARCHAR2,
P_COMM_TARGET_ID in VARCHAR2,
commrate in NUMBER
)

as
begin

insert into retain_comm_slab (COMP_CODE,RETAIN_CODE,ENLN,FROM_DAYS,TILL_DAYS,COMM_ON,COMM_RATE,CREATED_BY,UPDATED_BY,UPDATED_DATE,COMM_TARGET_ID) 
values(compcode,retcode,retslab.nextval,fromdays,todays,drpcommon,commrate,userid,'','',P_COMM_TARGET_ID);

commit;
end;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE procedure retaddselectslab
(
retcode in varchar2,
userid in varchar2,
compcode in varchar2,
code11 in varchar2,
p_accounts OUT Cur_Type_New1.cursor_type

)

as
begin

open p_accounts for
select  PUBL_CODE, NO_OF_PUBL,ADCOMM_PER,COMM_TYPE,COMM_TARGET_ID from retain_adcomm_target where COMP_CODE=compcode and RETAIN_CODE=retcode and ADD_COMM_ID=code11;


end;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE procedure retaddstatusbind
(
retcode in varchar2,
userid in varchar2,
compcode in varchar2,
commid in varchar2,
p_accounts OUT Cur_Type_New1.cursor_type

)

as
begin

open p_accounts for
select * from retain_adcomm_target where COMP_CODE=compcode  and RETAIN_CODE=retcode and COMM_TARGET_ID=commid;


end;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE procedure gencodeforcommstruct
(
p_compcode in varchar2,
p_userid in varchar2,
p_accounts OUT Cur_Type_New1.cursor_type

)

as
 num   NUMBER;
begin
SELECT  NVL(MAX(COMM_TARGET_ID), 0) + 1  into num FROM  RETAIN_COMM_TARGET;
open p_accounts for
 SELECT NVL (num, 0) AS "IDNO"
        FROM DUAL;


end;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@]
CREATE OR REPLACE PACKAGE sp_retstatusbind_b

is
Type T_Account_cursor is Ref cursor;
procedure sp_retstatusbind_b_p (retcode in varchar2,
userid in varchar2,
compcode in varchar2,
commid in varchar2,
P_ACCOUNTS out T_Account_cursor);
end sp_retstatusbind_b;
/

CREATE OR REPLACE PACKAGE BODY sp_retstatusbind_b

is

procedure sp_retstatusbind_b_p (retcode in varchar2,
userid in varchar2,
compcode in varchar2,
commid in varchar2,
P_ACCOUNTS out T_Account_cursor) as

begin
open  P_ACCOUNTS for


select * from retain_comm_slab where "COMP_CODE"=compcode  and "RETAIN_CODE"=retcode and "COMM_TARGET_ID"=commid;
--and "userid"=userid
end sp_retstatusbind_b_p;
end sp_retstatusbind_b;
/

/*======================================= nov-30-11 (Kuldeep Bhati)Retainer MAster ==============================*/


/*======================================= nov-30-11 mimoh mahajan client MAster ===============5747===============*/
DROP PACKAGE CLIENTSAVE;

CREATE OR REPLACE PACKAGE clientsave
IS

   PROCEDURE clientsave_p (
      compcode       IN   VARCHAR2,
      custcode       IN   VARCHAR2,
      custname       IN   VARCHAR2,
      custalias      IN   VARCHAR2,
      add1           IN   VARCHAR2,
      street         IN   VARCHAR2,
      citycode       IN   VARCHAR2,
      zip            IN   VARCHAR2,
      dist           IN   VARCHAR2,
      state          IN   VARCHAR2,
      country        IN   VARCHAR2,
      phone1         IN   VARCHAR2,
      phone2         IN   VARCHAR2,
      fax            IN   VARCHAR2,
      emailid        IN   VARCHAR2,
      url1            IN   VARCHAR2,
      vats           IN   VARCHAR2,
      servicetax1     IN   VARCHAR2,
      pan1            IN   VARCHAR2,
      creditdays     IN   VARCHAR2,
      paymodecode    IN   VARCHAR2,
      custstatus     IN   VARCHAR2,
      statusreason   IN   VARCHAR2,
      alert          IN   VARCHAR2,
      userid         IN   VARCHAR2,
      zone           IN   VARCHAR2,
      region1         IN   VARCHAR2,
      crdlimit       IN   VARCHAR2,
      flag1           IN   VARCHAR2,
      rategroup      IN   VARCHAR2,
      clientcat      IN   VARCHAR2,
      taluka1        IN   VARCHAR2,
      agency_sav  in varchar2,
      p_CLIENT_TYPE      IN   VARCHAR2,
      p_QBC_AGENCY        IN   VARCHAR2
   );
END clientsave;
/



;

CREATE OR REPLACE PACKAGE BODY clientsave
IS
   PROCEDURE clientsave_p (
      compcode       IN   VARCHAR2,
      custcode       IN   VARCHAR2,
      custname       IN   VARCHAR2,
      custalias      IN   VARCHAR2,
      add1           IN   VARCHAR2,
      street         IN   VARCHAR2,
      citycode       IN   VARCHAR2,
      zip            IN   VARCHAR2,
      dist           IN   VARCHAR2,
      state          IN   VARCHAR2,
      country        IN   VARCHAR2,
      phone1         IN   VARCHAR2,
      phone2         IN   VARCHAR2,
      fax            IN   VARCHAR2,
      emailid        IN   VARCHAR2,
      url1            IN   VARCHAR2,
      vats           IN   VARCHAR2,
      servicetax1     IN   VARCHAR2,
      pan1            IN   VARCHAR2,
      creditdays     IN   VARCHAR2,
      paymodecode    IN   VARCHAR2,
      custstatus     IN   VARCHAR2,
      statusreason   IN   VARCHAR2,
      alert          IN   VARCHAR2,
      userid         IN   VARCHAR2,
      zone          IN   VARCHAR2,
      region1         IN   VARCHAR2,
      crdlimit       IN   VARCHAR2,
      flag1           IN   VARCHAR2,
      rategroup      IN   VARCHAR2,
      clientcat      IN   VARCHAR2,
      taluka1        IN   VARCHAR2,
      agency_sav  in varchar2,
       p_CLIENT_TYPE      IN   VARCHAR2,
      p_QBC_AGENCY        IN   VARCHAR2
   )
   AS
      countrycode   VARCHAR2 (100);
      fatchstatus   VARCHAR2 (100);
   BEGIN
            begin
                 select "Status_Name" into fatchstatus from tblstatus where "Status_Code"=(select "CUST_STATUS" from status_detail_client where "cust_code"=custcode and "comp_code"=compcode and rownum<=1) and rownum<=1;
               
            EXCEPTION
                   WHEN NO_DATA_FOUND THEN  NULL;
            END;
      --SELECT "Country_Code"
        --INTO countrycode
        --FROM count_mst
       --WHERE "Country_Name" = country;
   --insert into test1(vstring,vstring2) values('clientsave '||' flag1 '||flag1,'compcode '||compcode||' custcode '||custcode||' servicetax1 '||servicetax1||' pan1 '||pan1); commit;
      IF (flag1 = '1')
      THEN
         UPDATE cust_mast
            SET "Zone_code" = zone,
                "Region_code" = region1,
                "Credit_limit" = crdlimit,
                "Cust_Name" = custname,
                "Cust_Alias" = custalias,
                "Add1" = add1,
                "Stree" = street,
                "City_Code" = citycode,
                "Zip" = zip,
                "Dist_Code" = dist,
                "State_Code" = state,
                "Country_Code" = country,
                "phone1" = phone1,
                "Phone2" = phone2,
                "Fax" = fax,
                "EmailID" = emailid,
                "URL" = url1,
                "No_of_VTS" = vats,
                "ST_ACC_No" = servicetax1,
                "PAN_No" = pan1,
                "Credit_Days" = creditdays,
                "Pay_Mode_Code" = paymodecode,
                "Cust_Status" = custstatus,
                "Status_Reason" = statusreason,
                "Remarks" = alert,
                "Rate_Gr_Code" = rategroup,
                "Client_category" = clientcat,
                "TALUKA"=taluka1,
                AGENCY_CODE=agency_sav,
                CLIENT_TYPE= p_CLIENT_TYPE,
                QBC_AGENCY=p_QBC_AGENCY
          WHERE "Comp_Code" = compcode
            AND "Cust_Code" = custcode;
           -- AND "UserId" = userid;

         COMMIT;
      END IF;

      IF (flag1 = '0')
      THEN
         INSERT INTO cust_mast
                     ("Comp_Code", "Cust_Code", "Cust_Name", "Cust_Alias",
                      "Add1", "Stree", "City_Code", "Zip", "Dist_Code",
                      "State_Code", "Country_Code", "phone1", "Phone2",
                      "Fax", "EmailID", "URL", "No_of_VTS", "ST_ACC_No",
                      "PAN_No", "Credit_Days", "Pay_Mode_Code",
                      "Cust_Status", "Status_Reason", "Remarks", "UserId",
                      "Creation_Datetime", "Zone_code", "Region_code",
                      "Credit_limit", "Rate_Gr_Code", "Client_category","TALUKA",AGENCY_CODE,
                      CLIENT_TYPE,QBC_AGENCY
                     )
              VALUES (compcode, custcode, custname, custalias,
                      add1, street, citycode, zip, dist,
                      state, country, phone1, phone2,
                      fax, emailid, url1, vats, servicetax1,
                      pan1, creditdays, paymodecode,
                      fatchstatus, statusreason, alert, userid,
                      SYSDATE, zone, region1,
                      crdlimit, rategroup, clientcat,taluka1,agency_sav,
                      p_CLIENT_TYPE,p_QBC_AGENCY
                     );
      END IF;
   END clientsave_p;
END clientsave;
/

/*****************************************************************************************************************************/


CREATE OR REPLACE PACKAGE Clientexecute
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE clientexecute_p (
      compcode     IN       VARCHAR2,
      userid       IN       VARCHAR2,
      custcode     IN       VARCHAR2,
      custname     IN       VARCHAR2,
      alias        IN       VARCHAR2,
      citycode     IN       VARCHAR2,
      status       IN       VARCHAR2,
      rategroup    IN       VARCHAR2,
      country      IN       VARCHAR2,
      agency_sav   IN       VARCHAR2,
      p_accounts   OUT      t_accounts_cursor
   );
END Clientexecute;
/





CREATE OR REPLACE PACKAGE BODY Clientexecute
IS
   PROCEDURE clientexecute_p (
      compcode     IN       VARCHAR2,
      userid       IN       VARCHAR2,
      custcode     IN       VARCHAR2,
      custname     IN       VARCHAR2,
      alias        IN       VARCHAR2,
      citycode     IN       VARCHAR2,
      status       IN       VARCHAR2,
      rategroup    IN       VARCHAR2,
      country      IN       VARCHAR2,
      agency_sav   IN       VARCHAR2,
      p_accounts   OUT      t_accounts_cursor
   )
   AS
      curscod   VARCHAR (12);
      code      VARCHAR (8);
   BEGIN
   DELETE FROM CUST_MAST_TEMP; COMMIT;
      INSERT INTO CUST_MAST_TEMP
         SELECT "Comp_Code", "Cust_Code", "Cust_Name", "Cust_Alias", "Add1",
                "Stree", "City_Code", "Zip", "Dist_Code", "State_Code",
                "Country_Code", "phone1", "Phone2", "Fax", "EmailID", "URL",
                "No_of_VTS", "ST_ACC_No", "PAN_No", "Credit_Days",
                "Pay_Mode_Code", "Cust_Status", "Status_Reason", "Remarks",
                "UserId", "Creation_Datetime", "Zone_code", "Region_code",
                "Credit_limit", "Rate_Gr_Code", SYSDATE, "Client_category","TALUKA",
                AGENCY_CODE, DIVISION, CLIENT_TYPE, QBC_AGENCY
           FROM CUST_MAST
          WHERE ("Comp_Code" = compcode OR compcode IS NULL)
            AND ("Cust_Code" = custcode OR custcode IS NULL)
            AND ("Cust_Name" LIKE custname ||'%' OR custname IS NULL)
            AND ("Cust_Alias" LIKE alias||'%' OR alias IS NULL)
            AND ("City_Code" = citycode OR citycode IS NULL)
            AND ("Cust_Status" = status OR status IS NULL)
            AND ("Rate_Gr_Code" = rategroup OR rategroup IS NULL)
            and (AGENCY_CODE = agency_sav OR agency_sav IS NULL)
            AND ("Country_Code" = country OR country IS NULL);


DECLARE
 CURSOR client IS SELECT Cust_Code FROM CUST_MAST_TEMP ORDER BY Cust_Code;
 curscod VARCHAR2(12);
BEGIN
OPEN client;
LOOP

FETCH client INTO curscod;

EXIT WHEN client%NOTFOUND;


UPDATE CUST_MAST_TEMP SET Cust_Status=
(SELECT  "Status_Name" FROM TBLSTATUS WHERE "Status_Code" =
(SELECT "CUST_STATUS" FROM STATUS_DETAIL_CLIENT WHERE "cust_code"=curscod AND sysdate between "FROM_DATE" and "TO_DATE" AND ROWNUM<=1  ))-- order by "TO_DATE" desc   ))
WHERE Cust_Code=curscod;

UPDATE CUST_MAST_TEMP SET TO_DATE=(SELECT "TO_DATE" FROM STATUS_DETAIL_CLIENT WHERE "cust_code"=curscod AND ROWNUM<=1)-- order by to_date desc)
 WHERE Cust_Code=curscod;




END LOOP;
CLOSE client;
END;
COMMIT;
OPEN p_accounts FOR
--SELECT  CUST_STATUS as "Cust_Status" FROM CUST_MAST_TEMP ORDER BY Cust_Code;
SELECT COMP_CODE as "Comp_Code", CUST_CODE as "Cust_Code", CUST_NAME as "Cust_Name", CUST_ALIAS as "Cust_Alias", ADD1 as "Add1", STREE as "Stree", CITY_CODE as "City_Code", ZIP as "Zip", DIST_CODE as "Dist_Code", STATE_CODE as "State_Code", COUNTRY_CODE as "Country_Code", PHONE1 as "phone1", PHONE2 as "Phone2", FAX as "Fax", EMAILID as "EmailID", URL, NO_OF_VTS as "No_of_VTS", ST_ACC_NO, PAN_NO, CREDIT_DAYS as "Credit_Days", PAY_MODE_CODE as "Pay_Mode_Code", CUST_STATUS as "Cust_Status", STATUS_REASON as "Status_Reason", REMARKS as "Remarks", USERID as "UserId", CREATION_DATETIME as "Creation_Datetime", ZONE_CODE as "Zone_code", REGION_CODE as "Region_code", CREDIT_LIMIT as "Credit_limit", RATE_GR_CODE as "Rate_Gr_Code", TO_DATE as "to_date", CLIENT_CATEGORY as "Client_category",TALUKA1 as "TALUKA",CLIENT_TYPE, QBC_AGENCY FROM CUST_MAST_TEMP ORDER BY Cust_Code;

   END clientexecute_p;
END Clientexecute;
/

/*************************************************************************************************************************************/


CREATE OR REPLACE PACKAGE websp_getclientName  is
type t_accounts_cursor is ref cursor;
procedure websp_getclientName_p
(
compcode in varchar2,
client in varchar2:=null,
center in varchar2,
p_accounts out t_accounts_cursor
);
end websp_getclientName ;
/





CREATE OR REPLACE PACKAGE BODY websp_getclientName
IS
   PROCEDURE websp_getclientName_p (
      compcode          IN       VARCHAR2,
       client in varchar2:=null,
       center in varchar2,
      p_accounts        OUT      t_accounts_cursor
   )
   AS
   BEGIN
   if(center != '0' and center is not null) then
      OPEN p_accounts FOR
         select "Cust_Code" as "Cust_Code","Cust_Name" as "Cust_Name","Add1"  from cust_mast where "Comp_Code"=compcode and "Cust_Name" 
         like '%'|| upper(client)|| '%' and "Dist_Code"=(select "Dist_Code" from branch_mst where "Branch_Code"=center) 
         and nvl("Cust_Status",'ACTIVE')='ACTIVE' and (client_type='' or client_type is null or client_type='B') order by "Cust_Name";
   else
     OPEN p_accounts FOR
         select "Cust_Code" as "Cust_Code","Cust_Name" as "Cust_Name","Add1"  from cust_mast where "Comp_Code"=compcode and "Cust_Name" 
         like '%'|| upper(client) || '%' and nvl("Cust_Status",'ACTIVE')='ACTIVE' and (client_type='' or client_type is null or client_type='B') order by "Cust_Name";
   end if;      

   END websp_getclientName_p;
END websp_getclientName;
/

/***************************************************************************************************/


CREATE OR REPLACE PACKAGE websp_getclientName_b  is
type t_accounts_cursor is ref cursor;
procedure websp_getclientName_b_p
(
compcode in varchar2,
client in varchar2:=null,
center in varchar2,
agencycode in varchar2,
p_accounts out t_accounts_cursor
);
end websp_getclientName_b ;
/





CREATE OR REPLACE PACKAGE BODY websp_getclientName_b
IS
   PROCEDURE websp_getclientName_b_p (
      compcode          IN       VARCHAR2,
       client in varchar2:=null,
       center in varchar2,
       agencycode in varchar2,
      p_accounts        OUT      t_accounts_cursor
   )
   AS
   BEGIN
   if(center != '0' and center is not null) then
      OPEN p_accounts FOR
         select "Cust_Code" as "Cust_Code","Cust_Name" as "Cust_Name","Add1"  from cust_mast where "Comp_Code"=compcode and "Cust_Name" 
         like '%' || upper(client) || '%' and "Dist_Code"=(select "Dist_Code" from branch_mst where "Branch_Code"=center) 
         and (AGENCY_CODE = agencycode OR agencycode IS NULL) and (client_type='Q') order by "Cust_Name";
   else
     OPEN p_accounts FOR
         select "Cust_Code" as "Cust_Code","Cust_Name" as "Cust_Name","Add1"  from cust_mast where "Comp_Code"=compcode and "Cust_Name" 
         like '%' || upper(client) || '%' and (AGENCY_CODE = agencycode OR agencycode IS NULL) and (client_type='Q') order by "Cust_Name";
   end if;      

   END websp_getclientName_b_p;
END websp_getclientName_b;
/



/*======================================= nov-30-11 mimoh mahajan client MAster ===============5747===============*/
////////////////////////////////issue number 0005831
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
                "Bullet_code","Bullet_premium",DOCTYPE



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
                "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color",
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

AD_CAT3."catcode"=TEMPBOOKING_MAST_AUDIT."Ad_Subcat3")  as "Subcat3",(SELECT "Cat_Name"  FROM  TBL_CAT4   WHERE

TBL_CAT4."Cat_Code"=TEMPBOOKING_MAST_AUDIT."Ad_Subcat4") as "Subcat4",(SELECT "Cat_Name"  FROM  TBL_CAT5   WHERE

TBL_CAT5."Cat_Code"=TEMPBOOKING_MAST_AUDIT."Ad_subcat5") as "subcat5",(SELECT "Comm_Rate" FROM ret_comm_details WHERE

ret_comm_details."Retain_Code"=TEMPBOOKING_MAST_AUDIT.RETAINER and rowid=(select max(rowid) from ret_comm_details where ret_comm_details."Retain_Code"=TEMPBOOKING_MAST_AUDIT.RETAINER)) AS "RETAINER_COMM",(select AUDIT_COMMENT from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=TEMPBOOKING_MAST_AUDIT."cio_booking_id") as "remarks","ADD_AGENCY_COMM",
 (SELECT "Box_Charges_Type" FROM BOX_MAST WHERE BOX_MAST."Box_Code"=TEMPBOOKING_MAST_AUDIT."Box_code") AS "boxchargetype",
 ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,

 (select "Bullet_Desc" from  bullet_mast where bullet_mast ."Bullet_Code"=TEMPBOOKING_MAST_AUDIT  ."BULLET_DESP") as "Bullet_Desc",
 TEMPBOOKING_MAST_AUDIT."Bullet_premium",(select RO_COMMENT from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=TEMPBOOKING_MAST_AUDIT."cio_booking_id") as "RO_COMMENT"
,DOCTYPE
           FROM TEMPBOOKING_MAST_AUDIT, AGENCY_MAST
          WHERE AGENCY_MAST."code_subcode" =
                                            TEMPBOOKING_MAST_AUDIT."Agency_sub_code"
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
////////////////////////end of issue number 5831

/*********************** Issue 5846    *******************/
CREATE OR REPLACE PACKAGE Subcatexe IS
TYPE T_ACCOUNTS_CURSOR IS REF CURSOR;
PROCEDURE subcatexe_p
(compcode IN VARCHAR2,catcode IN VARCHAR2,subcatcode IN VARCHAR2,
subcatname IN VARCHAR2,subcatalias IN VARCHAR2,userid IN VARCHAR2,P_ACCOUNTS OUT T_ACCOUNTS_CURSOR);
END Subcatexe;
/
CREATE OR REPLACE PACKAGE BODY Subcatexe IS
PROCEDURE subcatexe_p
(compcode IN VARCHAR2,catcode IN VARCHAR2,subcatcode IN VARCHAR2,
subcatname IN VARCHAR2,subcatalias IN VARCHAR2,userid IN VARCHAR2,P_ACCOUNTS OUT T_ACCOUNTS_CURSOR)AS
BEGIN

OPEN P_ACCOUNTS FOR
SELECT "Comp_Code", "Adv_Cat_Code", "Adv_Subcat_Code", "Adv_Subcat_Name", "Adv_Subcat_Alias", "UserId",
SYSDATE AS "Creation_DateTime", "Image_name" AS "Image_name",ADMINWEBXML AS "ADMINWEBXML",PRIORITY,STATUS  FROM ADV_SUBCAT_MAST
WHERE ("Comp_Code"=compcode OR compcode IS NULL)
AND ("Adv_Cat_Code" LIKE catcode || '%' OR catcode IS NULL)
AND ("Adv_Subcat_Code" LIKE subcatcode || '%' OR subcatcode IS NULL)
AND ("Adv_Subcat_Name" LIKE subcatname || '%' OR subcatname IS NULL)
AND ("Adv_Subcat_Alias" LIKE subcatalias || '%' OR subcatalias IS NULL);


END subcatexe_p;
END Subcatexe;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE subcatsave is
procedure subcatsave_p
(compcode in varchar2,catcode in varchar2,subcatcode in varchar2,subcatname in varchar2,subcatalias in varchar2,userid in varchar2,
imagename in varchar2,subcatxml in varchar2,pri in varchar2,status1 varchar2);
end subcatsave;
/

CREATE OR REPLACE PACKAGE BODY subcatsave is
procedure subcatsave_p
(compcode in varchar2,catcode in varchar2,subcatcode in varchar2,subcatname in varchar2,subcatalias in varchar2,userid in varchar2,
imagename in varchar2,subcatxml in varchar2,pri in varchar2,status1 varchar2)as
begin
insert into adv_subcat_mast("Comp_Code", "Adv_Cat_Code", "Adv_Subcat_Code", "Adv_Subcat_Name", "Adv_Subcat_Alias", "UserId", "Creation_Datetime","Image_name","ADMINWEBXML",PRIORITY,STATUS)
values(compcode,catcode,subcatcode,subcatname,subcatalias,userid,sysdate,imagename,subcatxml,pri,status1);
commit;

end subcatsave_p;

end subcatsave;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE subcatupdate is
procedure subcatupdate_p
(compcode in varchar2,catcode in varchar2,subcatcode in varchar2,subcatname in varchar2,subcatalias in varchar2,userid in varchar2,
imagename in varchar2,subcatxml in varchar2,pri in varchar2,
status1 varchar2);
end subcatupdate;
/
CREATE OR REPLACE PACKAGE BODY HT18JULY.subcatupdate is
procedure subcatupdate_p
(compcode in varchar2,catcode in varchar2,subcatcode in varchar2,subcatname in varchar2,subcatalias in varchar2,userid in varchar2,
imagename in varchar2,subcatxml in varchar2,pri in varchar2,status1 varchar2)as
begin

update adv_subcat_mast set  PRIORITY=pri,"Adv_Subcat_Name" = subcatname  , "Adv_Subcat_Alias" = subcatalias , "Image_name"=imagename,"ADMINWEBXML"=subcatxml,STATUS=status1 where "Comp_Code"=compcode  and "Adv_Cat_Code"=catcode and "Adv_Subcat_Code"=subcatcode;


update subcatdummy set "Adv_Subcat_Name" = subcatname  ,"Adv_Subcat_Alias"= subcatalias where "Comp_Code"=compcode and "Userid"=userid and "Adv_Cat_Code"=catcode and "Adv_Subcat_Code"=subcatcode;

commit;

end subcatupdate_p;

end subcatupdate;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE Advinsert IS
PROCEDURE advinsert_p(
compcode  IN VARCHAR2,
userid IN VARCHAR2,
adcatcode IN VARCHAR2,
catalias IN VARCHAR2,
catname IN VARCHAR2,
Adtype IN VARCHAR2,
rclient in varchar2,
filename in varchar2,
status1 in varchar2
);
END Advinsert;
/
CREATE OR REPLACE PACKAGE BODY Advinsert IS
PROCEDURE advinsert_p(
compcode  IN VARCHAR2,
userid IN VARCHAR2,
adcatcode IN VARCHAR2,
catalias IN VARCHAR2,
catname IN VARCHAR2,
Adtype IN VARCHAR2,
rclient in varchar2,
filename in varchar2,
status1 in varchar2
)AS
BEGIN

INSERT INTO ADV_CAT_MAST ("Comp_Code", "UserId", "Adv_Cat_Code","Adv_Cat_Name","Adv_Cat_Alias","Creation_Datetime","Adv_Type",REGCLIENT,CAT_FILE_NAME,STATUS) VALUES (compcode, userid, adcatcode,  catname, catalias,SYSDATE,Adtype,rclient,filename,status1);
COMMIT;
END advinsert_p;
END Advinsert;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE advupdate Is

Procedure advupdate_P (
compcode in varchar2,
adcatcode in varchar2,
catalias in varchar2,
catname in varchar2,
adtype in varchar2,
rclient in varchar2,
filename in varchar2,
status1 in varchar2
);

End advupdate;
/
CREATE OR REPLACE PACKAGE BODY advupdate Is
Procedure advupdate_P(
compcode in varchar2,
adcatcode in varchar2,
catalias in varchar2,
catname in varchar2,
adtype in varchar2,
rclient in varchar2,
filename in varchar2,
status1 in varchar2
)As
Begin
update Adv_Cat_Mast set REGCLIENT=rclient, "Adv_Cat_Name"=catname,"Adv_Cat_Alias"=catalias,"Creation_Datetime"=sysdate(),"Adv_Type"=adtype,CAT_FILE_NAME=filename,STATUS=status1 where "Comp_Code"=compcode and "Adv_Cat_Code"=adcatcode;
End advupdate_P;
End advupdate;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE Advcatexec IS
TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE advcatexec_p
(
compcode IN VARCHAR2,
adcatcode IN VARCHAR2,
catalias IN VARCHAR2,
catname IN VARCHAR2,
Adtype IN VARCHAR2,
p_Accounts OUT T_Accounts_Cursor
);
END Advcatexec;
/
CREATE OR REPLACE PACKAGE BODY Advcatexec IS
PROCEDURE advcatexec_p
(
compcode IN VARCHAR2,
adcatcode IN VARCHAR2,
catalias IN VARCHAR2,
catname IN VARCHAR2,
Adtype IN VARCHAR2,
p_Accounts OUT T_Accounts_Cursor
)AS
BEGIN


OPEN P_Accounts FOR
SELECT "Comp_Code", "Adv_Cat_Code", "Adv_Cat_Name","Adv_Cat_Alias","UserId","Creation_Datetime","Adv_Type",REGCLIENT,CAT_FILE_NAME,STATUS FROM ADV_CAT_MAST
WHERE  ("Comp_Code"=compcode OR compcode IS NULL)
AND ("Adv_Cat_Code"=adcatcode OR adcatcode IS NULL)
AND ("Adv_Type" LIKE Adtype || '%' OR Adtype IS NULL)
AND ("Adv_Cat_Alias" LIKE catalias || '%' OR catalias IS NULL)
AND ("Adv_Cat_Name" LIKE catname || '%' OR catname IS NULL);


END advcatexec_P;

END Advcatexec;
/

/*********************** End of Issue 5846   *******************/


issue number 5877
CREATE OR REPLACE PROCEDURE Websp_Updatestatus
(
fromdate IN VARCHAR2,
todate IN VARCHAR2,
Adtype IN VARCHAR2,
branch in varchar2,
publication in varchar2,
dateformat in varchar2,
v_edition IN VARCHAR2,
v_supplement IN  VARCHAR2,
v_booking_audit in varchar2,
v_status_value in varchar2,
v_pub_cent_code IN VARCHAR2,
V_AD_CATEGORY IN VARCHAR2,


p_recordset OUT Cur_Type_New1.cursor_type
)
IS
query1 VARCHAR2(10000);
BEGIN
query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id",
"No_Insert" AS "no_of_insertion" ,

case TBL_BOOKING_INSERT."Supp_Code"
    when ''MN''then
    (select distinct EDITION_MAST."Edition_Alias" from EDITION_MAST where  tbl_booking_insert."Edition_Code"=EDITION_MAST ."Edition_Code")
    else
    (select distinct supplement_MAST."Supp_Name" from supplement_MAST where  tbl_booking_insert."Supp_Code"=supplement_MAST ."Supp_Code")
    end as "Editionname",

--(select distinct EDITION_MAST."Edition_Name" from EDITION_MAST where  tbl_booking_insert."Edition_Code"=EDITION_MAST ."Edition_Code") as "Editionname",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "client",
AGENCY_MAST."Agency_Name" AS "Agency",
TBL_BOOKING_INSERT."Gross_Rate" as "agreed_rate",
tbl_booking_mast ."Caption",
TBL_BOOKING_MAST."Trade_disc" AS "Commission",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date" ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''yyyy/mm/dd'') END AS "Ins.date" ,
tbl_booking_mast."RO_No",


TBL_BOOKING_INSERT."Height" AS "Depth" ,

nvl(TBL_BOOKING_INSERT."No_Ofcolumn" ,TBL_BOOKING_INSERT."Width") AS "Width" ,


TBL_BOOKING_INSERT. "Size_Book" AS "Area",


COL_MAST."Col_Alias" AS "Hue",

TBL_BOOKING_INSERT."Insert_Status" AS "status",
TBL_BOOKING_MAST."No_of_insertion" AS "total",



TBL_BOOKING_MAST."Bill_remarks",

tbl_booking_insert."Page_No"  as "Page_no",

(SELECT ADVPOS_TYPE_MAST."Pos_Type" FROM  ADVPOS_TYPE_MAST WHERE TBL_BOOKING_MAST."Page_position_code" =ADVPOS_TYPE_MAST ."Pos_Type_Code")AS "Page_pos1",

(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=TBL_BOOKING_INSERT ."Ad_Cat") AS "AdCat","Uom_Alias" as "Uom",

(SELECT distinct adv_subcat_mast."Adv_Subcat_Name" FROM adv_subcat_mast  WHERE adv_subcat_mast ."Adv_Subcat_Code"=TBL_BOOKING_INSERT ."Ad_Sub_Cat") AS "Sub_cat",


trim(TBL_BOOKING_INSERT."Edition") as "Edition",

(SELECT "premiumname" FROM ADVPOS_PREM_MAST WHERE ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_MAST."Page_prem") AS  Page_prem1 ,


(SELECT distinct adv_subcat_mast."Adv_Subcat_Name" FROM adv_subcat_mast  WHERE adv_subcat_mast ."Adv_Subcat_Code"=TBL_BOOKING_INSERT ."Ad_Sub_Cat") AS "Sub_cat",

(SELECT ADVPOS_PREM_MAST."premiumname" FROM  ADVPOS_PREM_MAST WHERE TBL_BOOKING_insert."Premium1" =ADVPOS_PREM_MAST ."Premiumcode")AS "Page_prem",

(SELECT ADVPOS_TYPE_MAST."Pos_Type" FROM  ADVPOS_TYPE_MAST WHERE TBL_BOOKING_insert."Page_Post" =ADVPOS_TYPE_MAST  ."Pos_Type_Code")AS "Page_pos",

,tbl_booking_insert."Bill_Amt"






FROM TBL_BOOKING_INSERT,
TBL_BOOKING_MAST,COL_MAST,UOM_MAST,
AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT ."Cio_Booking_Id"
AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"
 AND TBL_BOOKING_insert  ."Col_Code" =COL_MAST."Col_Code"
 AND TBL_BOOKING_Mast."Uom_code" =UOM_MAST."Uom_Code"
AND "Insert_Date" BETWEEN  '''||fromdate ||''' AND  '''||todate ||'''    ';




if(v_status_value is not null)
then
query1:=query1 ||' AND TBL_BOOKING_insert. "Insert_Status" ='''||v_status_value||''' ';
end if;





if(v_status_value is  null)
then
query1:=query1 ||' AND TBL_BOOKING_insert. "Insert_Status" in (''publish'',''booked'') ';
end if;


if ((v_booking_audit ='Y')or(v_booking_audit ='y'))
then
query1:=query1 ||' AND TBL_BOOKING_MAST. "audit" is not null ';

end if;




IF(Adtype IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST. "Ad_type_code" ='''||Adtype||''' ';
END IF;

IF(publication IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_insert. "Publication_Code" ='''||publication||''' ';
END IF;



IF(v_pub_cent_code IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_insert."Pub_Cent_Code" ='''||v_pub_cent_code ||''' ';
END IF;




IF(branch IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST."branch" ='''||branch||''' ';
END IF;



IF(v_edition  IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_insert ."Edition_Code" ='''||v_edition||''' ';
END IF;


IF(v_supplement IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_INSERT."Supp_Code" ='''||v_supplement||''' ';
END IF;





IF(V_AD_CATEGORY IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_INSERT."Ad_Cat" ='''||V_AD_CATEGORY||''' ';
END IF;

query1:=query1 ||'ORDER BY "no_of_insertion"  ' ;






--delete from ANK_SEARCH ;
--iNSERT INTO ANK_SEARCH VALUES(query1);

OPEN p_recordset FOR
 query1;



END ;
/
///////////////////////end of issue CREATE OR REPLACE PROCEDURE Websp_Updatestatus
(
fromdate IN VARCHAR2,
todate IN VARCHAR2,
Adtype IN VARCHAR2,
branch in varchar2,
publication in varchar2,
dateformat in varchar2,
v_edition IN VARCHAR2,
v_supplement IN  VARCHAR2,
v_booking_audit in varchar2,
v_status_value in varchar2,
v_pub_cent_code IN VARCHAR2,
V_AD_CATEGORY IN VARCHAR2,


p_recordset OUT Cur_Type_New1.cursor_type
)
IS
query1 VARCHAR2(10000);
BEGIN
query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id",
"No_Insert" AS "no_of_insertion" ,

case TBL_BOOKING_INSERT."Supp_Code"
    when ''MN''then
    (select distinct EDITION_MAST."Edition_Alias" from EDITION_MAST where  tbl_booking_insert."Edition_Code"=EDITION_MAST ."Edition_Code")
    else
    (select distinct supplement_MAST."Supp_Name" from supplement_MAST where  tbl_booking_insert."Supp_Code"=supplement_MAST ."Supp_Code")
    end as "Editionname",

--(select distinct EDITION_MAST."Edition_Name" from EDITION_MAST where  tbl_booking_insert."Edition_Code"=EDITION_MAST ."Edition_Code") as "Editionname",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "client",
AGENCY_MAST."Agency_Name" AS "Agency",
TBL_BOOKING_INSERT."Gross_Rate" as "agreed_rate",
tbl_booking_mast ."Caption",
TBL_BOOKING_MAST."Trade_disc" AS "Commission",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date" ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''yyyy/mm/dd'') END AS "Ins.date" ,
tbl_booking_mast."RO_No",


TBL_BOOKING_INSERT."Height" AS "Depth" ,

nvl(TBL_BOOKING_INSERT."No_Ofcolumn" ,TBL_BOOKING_INSERT."Width") AS "Width" ,


TBL_BOOKING_INSERT. "Size_Book" AS "Area",


COL_MAST."Col_Alias" AS "Hue",

TBL_BOOKING_INSERT."Insert_Status" AS "status",
TBL_BOOKING_MAST."No_of_insertion" AS "total",



TBL_BOOKING_MAST."Bill_remarks",

tbl_booking_insert."Page_No"  as "Page_no",

(SELECT ADVPOS_TYPE_MAST."Pos_Type" FROM  ADVPOS_TYPE_MAST WHERE TBL_BOOKING_MAST."Page_position_code" =ADVPOS_TYPE_MAST ."Pos_Type_Code")AS "Page_pos1",

(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=TBL_BOOKING_INSERT ."Ad_Cat") AS "AdCat","Uom_Alias" as "Uom",

(SELECT distinct adv_subcat_mast."Adv_Subcat_Name" FROM adv_subcat_mast  WHERE adv_subcat_mast ."Adv_Subcat_Code"=TBL_BOOKING_INSERT ."Ad_Sub_Cat") AS "Sub_cat",


trim(TBL_BOOKING_INSERT."Edition") as "Edition",

(SELECT "premiumname" FROM ADVPOS_PREM_MAST WHERE ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_MAST."Page_prem") AS  Page_prem1 ,


(SELECT distinct adv_subcat_mast."Adv_Subcat_Name" FROM adv_subcat_mast  WHERE adv_subcat_mast ."Adv_Subcat_Code"=TBL_BOOKING_INSERT ."Ad_Sub_Cat") AS "Sub_cat",

(SELECT ADVPOS_PREM_MAST."premiumname" FROM  ADVPOS_PREM_MAST WHERE TBL_BOOKING_insert."Premium1" =ADVPOS_PREM_MAST ."Premiumcode")AS "Page_prem",

(SELECT ADVPOS_TYPE_MAST."Pos_Type" FROM  ADVPOS_TYPE_MAST WHERE TBL_BOOKING_insert."Page_Post" =ADVPOS_TYPE_MAST  ."Pos_Type_Code")AS "Page_pos",

,tbl_booking_insert."Bill_Amt"






FROM TBL_BOOKING_INSERT,
TBL_BOOKING_MAST,COL_MAST,UOM_MAST,
AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT ."Cio_Booking_Id"
AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"
 AND TBL_BOOKING_insert  ."Col_Code" =COL_MAST."Col_Code"
 AND TBL_BOOKING_Mast."Uom_code" =UOM_MAST."Uom_Code"
AND "Insert_Date" BETWEEN  '''||fromdate ||''' AND  '''||todate ||'''    ';




if(v_status_value is not null)
then
query1:=query1 ||' AND TBL_BOOKING_insert. "Insert_Status" ='''||v_status_value||''' ';
end if;





if(v_status_value is  null)
then
query1:=query1 ||' AND TBL_BOOKING_insert. "Insert_Status" in (''publish'',''booked'') ';
end if;


if ((v_booking_audit ='Y')or(v_booking_audit ='y'))
then
query1:=query1 ||' AND TBL_BOOKING_MAST. "audit" is not null ';

end if;




IF(Adtype IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST. "Ad_type_code" ='''||Adtype||''' ';
END IF;

IF(publication IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_insert. "Publication_Code" ='''||publication||''' ';
END IF;



IF(v_pub_cent_code IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_insert."Pub_Cent_Code" ='''||v_pub_cent_code ||''' ';
END IF;




IF(branch IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST."branch" ='''||branch||''' ';
END IF;



IF(v_edition  IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_insert ."Edition_Code" ='''||v_edition||''' ';
END IF;


IF(v_supplement IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_INSERT."Supp_Code" ='''||v_supplement||''' ';
END IF;





IF(V_AD_CATEGORY IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_INSERT."Ad_Cat" ='''||V_AD_CATEGORY||''' ';
END IF;

query1:=query1 ||'ORDER BY "no_of_insertion"  ' ;






--delete from ANK_SEARCH ;
--iNSERT INTO ANK_SEARCH VALUES(query1);

OPEN p_recordset FOR
 query1;



END ;
/
