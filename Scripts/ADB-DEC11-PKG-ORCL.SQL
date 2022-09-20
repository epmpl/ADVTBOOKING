/*======================================= ISSUE 0005741 (Kuldeep Bhati) ==============================*/
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
tbl_booking_insert."Edition" as"EditionName",
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


/*======================================= End of ISSUE 0005741 (Kuldeep Bhati) ==============================*/

/*======================================= ISSUE 0005930 (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE procedure getapprovalRo_web

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
(select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=tbl_booking_mast."Page_prem") as PAGEPERM,APP_STATUS,"booked_by",
(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=tbl_booking_mast."Agency_pay") as "paymode"
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
(select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=tbl_booking_mast."Page_prem") as PAGEPERM,APP_STATUS,"booked_by",
(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=tbl_booking_mast."Agency_pay") as "paymode"
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
(select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=tbl_booking_mast."Page_prem") as PAGEPERM,APP_STATUS,"booked_by",
(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=tbl_booking_mast."Agency_pay") as "paymode"
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

/*======================================= End of ISSUE 0005930 (Kuldeep Bhati) ==============================*/

issue number by  garima 5893


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

/*------------------------------------------------------------------------------------------------*/

/*======================================= ISSUE 0005731 (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE PROCEDURE Reportnew
(
agname IN VARCHAR2:=NULL,
clientname IN VARCHAR2:=NULL,
adtype1 IN VARCHAR2,
Adcategory IN VARCHAR2,
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
 WHEN ''mm/dd/yyyy'' THEN TO_CHAR(tbl_booking_insert."Insert_Date" ,''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(tbl_booking_insert."Insert_Date",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(tbl_booking_insert."Insert_Date",''yyyy/mm/dd'')  END AS "Ins.date" ,
AGENCY_MAST."Agency_Name" AS "Agency",
(SELECT  AGENCY_MAST."SUB_Agency_Code" FROM AGENCY_MAST WHERE  AGENCY_MAST."Type" <> ''P'' AND TBL_BOOKING_MAST."Agency_code"=AGENCY_MAST."Agency_Code"  AND TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") AS "SubAg",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "Client",
(select COMBIN_MAST."Package_Name" from combin_mast where COMBIN_MAST."Combin_Code"  in(TBL_BOOKING_MAST."Package_code"))AS "Package",
TBL_BOOKING_INSERT."Col_Code" AS "Color_code",
round(TBL_BOOKING_insert."Size_Book",2) AS "Area",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code")as "uom",
--"Ad_size_height" AS "Depth",
--"Ad_size_width" AS "Width",
tbl_booking_insert."Height" AS "Depth",
tbl_booking_insert."Width"  AS "Width",
(SELECT ADVPOS_TYPE_MAST."Pos_Type_Alias" FROM ADVPOS_TYPE_MAST WHERE TBL_BOOKING_INSERT."Page_Post"=ADVPOS_TYPE_MAST."Pos_Type_Code") AS "Page",
TBL_BOOKING_MAST."Bullet_code" AS "BulletPremium" ,
--TBL_BOOKING_MAST."Page_position_code" AS "PositionPremium" ,
tbl_booking_insert."Page_Post" AS "PositionPremium" ,
--TBL_BOOKING_MAST."Page_prem" AS "PagePremium" ,
TBL_BOOKING_INSERT."Premium1" AS "PagePremium" ,
"RO_No" AS "RoNo.",
CASE "ro_status"
WHEN ''2'' THEN ''Reservation''
WHEN ''1'' THEN ''Confirm'' END AS "RoStatus",
--(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=TBL_BOOKING_MAST."Ad_cat_code") AS "AdCat",
(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=tbl_booking_insert."Ad_Cat") AS "AdCat",
"Rate_code" AS "RateCode",
TBL_BOOKING_mast."Card_rate" AS "CardRate",
--tbl_booking_mast."Agrred_rate" AS "AgreedRate",
NVL("Agrred_rate",TBL_BOOKING_MAST."Card_rate") AS "AgreedRate",
--TBL_BOOKING_insert."Gross_Rate" AS "Amt",
TBL_BOOKING_insert."Bill_Amt"  AS "Amt",

"Caption" AS "Cap",
"Key_no" AS "Key",
TBL_BOOKING_MAST."Trade_disc" AS "Disc",
TBL_BOOKING_INSERT."Insert_Status" AS "Status",
TBL_BOOKING_INSERT."Status_Material" AS "MatStatus",
(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
sysdate as "Rundate"

FROM TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST 

 WHERE
 TBL_BOOKING_MAST."Comp_code"='''||compcode||'''
 AND TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
 AND TBL_BOOKING_MAST."Agency_code"=AGENCY_MAST."Agency_Code"
 AND TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode"
 AND "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
 /*and  lower("Insert_Status") !=''cancel'' */
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and nvl('''||chk_access||''',''0'')=''1'')
or  (nvl('''||chk_access||''',''0'')=''0'') )';



/*
IF(hold IS NOT NULL)THEN
query:=query||' and TBL_BOOKING_INSERT."Insert_Status"!='''||'Cancel'||'''';
END IF;*/

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
/*
else
query:=query||' and lower("Insert_Status") !=''cancel'' ';*/
END IF;

IF(adtype1 IS NOT NULL)
THEN
query:=query||' and TBL_BOOKING_MAST."Ad_type_code"='''||adtype1||'''';
END IF;

IF(Adcategory IS NOT NULL)
THEN
a:=Fn_Splitfield(Adcategory,',');
query:=query||' and tbl_booking_insert."Ad_Cat" in(select "EDITION_NAME" from result)';

--query:=query||' and TBL_BOOKING_MAST."Ad_cat_code" in('''||Adcategory||''' )';
END IF;

IF(pub_cent IS NOT NULL)
THEN
query:=query||'  and tbl_booking_insert."Pub_Cent_Code"='''||pub_cent||'''';
END IF;

IF(fromdate IS NOT NULL AND dateto IS NULL )
THEN
query:=query||' and tbl_booking_insert."Insert_Date" ='''||fromdate||'''';
END IF;

IF(fromdate IS NOT NULL AND dateto IS NOT NULL )
THEN
query:=query||' and tbl_booking_insert."Insert_Date" between  '''||fromdate ||''' and  '''||dateto||''' ';
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

IF(descid IS NOT  NULL)
THEN
query:=query||'  order by "'||descid||'"';
query:=query||''||ascdesc||'';
ELSE
query:=query||'  order by "Insert_Date",TBL_BOOKING_MAST."cio_booking_id"';
END IF;

delete from searchtbl;
insert into searchtbl values('pk'||query);
commit;
OPEN p_reportnew FOR
query;


END;
/

/*======================================= End of ISSUE 0005731 (Kuldeep Bhati) ==============================*/

/*======================================= ISSUE 0005566 (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE procedure AD_GET_BRANCH_NAME(
       compcode       in varchar2,
       branch_code       in varchar2,
       p_accounts   OUT   cur_type_new1.cursor_type
)
as
Begin

open p_accounts for
    select "Branch_Name" from branch_mst where "Comp_Code"=compcode and "Branch_Code"=branch_code;

 
end;
/

/*======================================= ISSUE 0005566 (Kuldeep Bhati) ==============================*/


/*======================================= ISSUE 5879 mimoh mahajan ==============================*/


CREATE OR REPLACE PROCEDURE bind_publ_name(
    pcompcode  in  varchar2,
    ppubtype   in  varchar2,
    ppublcode  in  varchar2,
    pexrta1    in  varchar2,
    pexrta2    in  varchar2,    
    p_accounts out Cur_Type_New1.cursor_type)
is 
begin

    open p_accounts for 
    SELECT "Pub_Code" as "PUBL_CODE", "Pub_Name" as "PUBL_NAME" FROM pub_mast
        WHERE "Comp_Code" = pcompcode and ("publication_type"=ppubtype or ppubtype is null) and
          ("Pub_Code"=ppublcode or ppublcode is null);
          
end bind_publ_name;
/


/*======================================= ISSUE 5879 mimoh mahajan ==============================*/

/*======================================= ISSUE 0005981 (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE procedure getapprovalRo_web

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
(select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=tbl_booking_mast."Page_prem") as PAGEPERM,APP_STATUS,"booked_by",
(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=tbl_booking_mast."Agency_pay") as "paymode","Receipt_no"
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
(select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=tbl_booking_mast."Page_prem") as PAGEPERM,APP_STATUS,"booked_by",
(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=tbl_booking_mast."Agency_pay") as "paymode","Receipt_no"
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
(select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=tbl_booking_mast."Page_prem") as PAGEPERM,APP_STATUS,"booked_by",
(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=tbl_booking_mast."Agency_pay") as "paymode","Receipt_no"
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

/*======================================= End of ISSUE 0005981 (Kuldeep Bhati) ==============================*/


/***********************mimoh 14-dec-2011*********************************5933****************/


CREATE OR REPLACE PACKAGE Wesp_Updatedate
IS
PROCEDURE      Wesp_Updatedate_p(
compcode IN VARCHAR2,
userid IN VARCHAR2,
dateformat IN VARCHAR2,
code IN VARCHAR2,
curr IN VARCHAR2,
RATECODE11 IN VARCHAR2,
solo  IN VARCHAR2,
breakup VARCHAR2,
bwcode IN VARCHAR2,
rostatus IN VARCHAR2,
filename IN VARCHAR2,
tfn IN NUMBER,
insertbreak IN VARCHAR2,
prem IN VARCHAR2,
dealtype IN VARCHAR2,
pre IN VARCHAR2,
suff IN VARCHAR2,
financestatus IN  VARCHAR2,
voucherst IN VARCHAR2,
adcode IN VARCHAR2,
rodatetime IN VARCHAR2,
spacearea IN VARCHAR2,
vat IN VARCHAR2,
bookstat IN VARCHAR2,
cio_id IN VARCHAR2,
receipt_no IN VARCHAR2,
uom IN VARCHAR2,
bgcolor IN VARCHAR2,
validdate IN VARCHAR2,
agencyratecode IN VARCHAR2,
AUDIT1 IN VARCHAR2,
book_insert_date IN VARCHAR2,
agencycomm IN VARCHAR2,
rateaudit IN VARCHAR2,
billaudit IN VARCHAR2,
bill_type IN VARCHAR2,
invoice_no1 IN VARCHAR2,
copybooking IN VARCHAR2,
ratecompany IN VARCHAR2,
addagenycomm IN VARCHAR2,
agencycommlinkretainer IN VARCHAR2,
subeditionr IN VARCHAR2,
displaybilltype IN VARCHAR2,
classifiedbilltype IN VARCHAR2,
billformat IN VARCHAR2,
ratechk IN VARCHAR2,
allpkg IN VARCHAR2,
dayrate1 in varchar2,
schemetype in varchar2,
PIncludeclassi in varchar2,
receiptformat IN VARCHAR2,
v_cash_receipt in varchar2,
v_bill_orderwiselast in varchar2,
v_floor_chk in varchar2,
Unsoldflag in varchar2,
Supplystopper in  number,
drpRokeychk in varchar2,
Agencycomm_seq in varchar2,
creditreciept in varchar,
cashindisplay IN VARCHAR,
cashinclassified IN VARCHAR,
v_rate_audit_pref in varchar,
v_barcoding_allow_pref in varchar2,
v_fmgbills IN VARCHAR2,
v_billed_cashdis in varchar2,
v_billed_cashcls in varchar,
v_drpbackdate in varchar,
dockitbooking in varchar2,
allowprevbooking in varchar2,
ro_wisecashbill in varchar2,
chkval in varchar2,
approval1 in varchar2,
pckstatus in varchar2,
cash_disc in varchar2,
cash_amt in varchar2,
seperate_cashier1 in varchar2,
disp_bill in varchar2,
clas_bill in varchar2,
mantimepost in varchar2,
bkdaypost in number,
maxterutn in number,
cir_return in varchar2,
noofchkbounc in number,
noofdaychkrec in number,
retday in number,
chngsuppord in number,
max_publishday in number,
p_billno_period in varchar,
spl_trans_edit in varchar2,
spl_dis_trans_editable in varchar2,
mul_pac_sel_trans in varchar2,
shmon_minword in varchar2,
tradon_spcrg in varchar2,
rateauth     in varchar2,
f2day in number,
rateauditmodify in varchar,
bindrevenuecenter in varchar,
p_led_allow in varchar,
p_clear_allow in varchar,
repeatday in varchar,
premiumedit in varchar,
P_BILL_GENERATION in varchar,
P_PUBLICATION_CENTER in varchar,
P_allow_discount_prem IN VARCHAR,
P_SCHEME_BILLING in varchar,
P_ALLOW_PDC in varchar,
PAD_TYPE_FOR_MANUL_BILL in varchar,
RO_OUTSTAND_P IN VARCHAR2,
genrate_agency_code IN VARCHAR2,
p_dispauditbk IN VARCHAR2,
p_aotosupply  IN VARCHAR2,
p_Authorization IN VARCHAR2,
p_CIR_AUTO_APPROVAL_UNSOLD IN VARCHAR2,
p_CIR_AUTO_PHYSICAL_UNSOLD IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INCT IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INSFEE IN VARCHAR2,
p_CIR_UNSOLD_ON_RECEIVED_DT IN VARCHAR2,
p_AGENCY_UNBLOCK_APROV IN VARCHAR2,
p_UNBLOCK_APROV_OUT_LMT IN VARCHAR2,
p_CIR_BILL_PUBLWISE IN VARCHAR2

);
END      Wesp_Updatedate;
/





CREATE OR REPLACE PACKAGE BODY Wesp_Updatedate IS
PROCEDURE      Wesp_Updatedate_p(
compcode IN VARCHAR2,
userid IN VARCHAR2,
dateformat IN VARCHAR2,
code IN VARCHAR2,
curr IN VARCHAR2,
RATECODE11 IN VARCHAR2,
solo  IN VARCHAR2,
breakup VARCHAR2,
bwcode IN VARCHAR2,
rostatus IN VARCHAR2,
filename IN VARCHAR2,
tfn IN NUMBER,
insertbreak IN VARCHAR2,
prem IN VARCHAR2,
dealtype IN VARCHAR2,
pre IN VARCHAR2,
suff IN VARCHAR2,
financestatus IN  VARCHAR2,
voucherst IN VARCHAR2,
adcode IN VARCHAR2,
rodatetime IN VARCHAR2,
spacearea IN VARCHAR2,
vat IN VARCHAR2,
bookstat IN VARCHAR2,
cio_id IN VARCHAR2,
receipt_no IN VARCHAR2,
uom IN VARCHAR2,
bgcolor IN VARCHAR2,
validdate IN VARCHAR2,
agencyratecode IN VARCHAR2,
AUDIT1 IN VARCHAR2,
book_insert_date IN VARCHAR2,
agencycomm IN VARCHAR2,
rateaudit IN VARCHAR2,
billaudit IN VARCHAR2,
bill_type IN VARCHAR2,
invoice_no1 IN VARCHAR2,
copybooking IN VARCHAR2,
ratecompany IN VARCHAR2,
addagenycomm IN VARCHAR2,
agencycommlinkretainer IN VARCHAR2,
subeditionr IN VARCHAR2,
displaybilltype IN VARCHAR2,
classifiedbilltype IN VARCHAR2,
billformat IN VARCHAR2,
ratechk IN VARCHAR2,
allpkg IN VARCHAR2,
dayrate1 in varchar2,
schemetype in varchar2,
PIncludeclassi in varchar2,
receiptformat IN VARCHAR2,
v_cash_receipt in varchar2,
v_bill_orderwiselast in varchar2,
v_floor_chk in varchar2,
Unsoldflag in varchar2,
Supplystopper in  number,
drpRokeychk in varchar2,
Agencycomm_seq in varchar2,
creditreciept in varchar,
cashindisplay IN VARCHAR,
cashinclassified IN VARCHAR,
v_rate_audit_pref in varchar,
v_barcoding_allow_pref in varchar2,
v_fmgbills IN VARCHAR2,
v_billed_cashdis in varchar2,
v_billed_cashcls in varchar,
v_drpbackdate in varchar,
dockitbooking in varchar2,
allowprevbooking in varchar2,
ro_wisecashbill in varchar2,
chkval in varchar2,
approval1 in varchar2,
pckstatus in varchar2,
cash_disc in varchar2,
cash_amt in varchar2,
seperate_cashier1 in varchar2,
disp_bill in varchar2,
clas_bill in varchar2,
mantimepost in varchar2,
bkdaypost in number,
maxterutn in number,
cir_return in varchar2,
noofchkbounc in number,
noofdaychkrec in number,
retday in number,
chngsuppord in number,
max_publishday in number,
p_billno_period in varchar,
spl_trans_edit in varchar2,
spl_dis_trans_editable in varchar2,
mul_pac_sel_trans in varchar2,
shmon_minword in varchar2,
tradon_spcrg in varchar2,
rateauth     in varchar2,
f2day in number,
rateauditmodify in varchar,
bindrevenuecenter in varchar,
p_led_allow in varchar,
p_clear_allow in varchar,
repeatday in varchar,
premiumedit in varchar,
P_BILL_GENERATION in varchar,
P_PUBLICATION_CENTER in varchar,
P_allow_discount_prem IN VARCHAR,
P_SCHEME_BILLING in varchar,
P_ALLOW_PDC in varchar,
PAD_TYPE_FOR_MANUL_BILL in varchar,
RO_OUTSTAND_P IN VARCHAR2,
genrate_agency_code IN VARCHAR2,
p_dispauditbk IN VARCHAR2,
p_aotosupply  IN VARCHAR2,
p_Authorization IN VARCHAR2,
p_CIR_AUTO_APPROVAL_UNSOLD IN VARCHAR2,
p_CIR_AUTO_PHYSICAL_UNSOLD IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INCT IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INSFEE IN VARCHAR2,
p_CIR_UNSOLD_ON_RECEIVED_DT IN VARCHAR2,
p_AGENCY_UNBLOCK_APROV IN VARCHAR2,
p_UNBLOCK_APROV_OUT_LMT IN VARCHAR2,
p_CIR_BILL_PUBLWISE IN VARCHAR2


)AS
BEGIN
UPDATE LOGIN SET "date_format"=dateformat, "Autogenerate"=code,"curr_code"=curr WHERE "COM_CODE"=compcode;
COMMIT;
        UPDATE PREFERRENCES SET  "autogenerated"=code,
"currency_code"=curr ,
"rate_gr_code"=RATECODE11,
"date_format"=dateformat,"solo"=solo,"breakup"=breakup,
"blackwhitecode"=bwcode,"rostatus"=rostatus,"File_name"=filename,"Tfn"=tfn,
"Insert_breakup"=insertbreak,"Premium_type"=prem,"Deal_type"=dealtype  ,
 "prefix"=pre, "suffix"=suff, "financestatus"=financestatus , "voucherst"=voucherst,
 "Ad_category"=adcode ,"Ro_datetime"=rodatetime ,"Space_area"=spacearea,"Vat"=vat,
 "Booking_status"=bookstat,"Cio_id"=cio_id,"Receipt_no"=receipt_no,"uom_code"=uom,
 "Bgcolor_publication"=bgcolor ,"chkfor_valid_pubdates"=validdate, "Agency_ratecode"=agencyratecode,
  "audit"=AUDIT1,"book_insert_date"=book_insert_date,"agencycomm"=agencycomm,
  "rate_audit"=rateaudit,"bill_audit"=billaudit,"billtype"=bill_type,"invoice_no"=invoice_no1,
  "copy_booking"=copybooking,"RATE_COMPANY_AGENCY"=ratecompany, "ADDITIONAL_AGENCY_COMM"=addagenycomm ,
  "AGENCY_RETAINER_COMM"=agencycommlinkretainer,"SUBEDITIONRATE"=subeditionr,
  "CLS_BILLTYPE"=classifiedbilltype,"DIS_BILLTYPE"=displaybilltype,"BILLING_FORMAT"=billformat,
  "RATE_CHECK"=ratechk,"ALL_PACKAGE"=allpkg,"DAYRATE"=dayrate1,"SCHEME_TYPE"=schemetype,"DISP_CLSBILL"=PIncludeclassi   ,
  "CASH_RECEIPT_BILL"=v_cash_receipt, "BILL_ORDERWSLAST"=v_bill_orderwiselast, "FLOOR_CHK"=v_floor_chk ,
  "UNSOLD_ENTRY_FLAG"=Unsoldflag ,"SUPPLY_STOP_PERCENTAGE"=Supplystopper,"ROKEYCHECK"=drpRokeychk ,
  "AGENCYCOMM_SEQ_COM"=Agencycomm_seq ,"CREDIT_RECIPT"=creditreciept,"DISP_CASHBILL"=cashindisplay,
  "CLA_CASHBILL"=cashinclassified,"RATE_AUDIT_PREF"=v_rate_audit_pref,"BARCODING_ALLOWED"=v_barcoding_allow_pref,
  "FMG_BILL_DIS" =v_fmgbills, "BILL_DISP_CASHBILL"=v_billed_cashdis , "BILL_CLA_CASHBILL"=v_billed_cashcls,"BACKDATERECEIPT"=v_drpbackdate,"DOCKIT_BOOKING"=dockitbooking,"Allowed_old_date"=allowprevbooking,"ROWISE_CASHBOOKING"=ro_wisecashbill,"CUTOFFTIME"=chkval,"APPROVAL"=approval1,"BACK_DAYS"=pckstatus ,CASH_DISCOUNT=cash_amt,CASH_DISCOUNTTYPE=cash_disc,SEPRATE_CASHIER=seperate_cashier1,
   CIR_MANY_TIME_POSTING=mantimepost, CIR_BACKDAYS_POSTING=bkdaypost, CIR_MAX_RETURN_ALLOW=maxterutn, CIR_RETURN_LIMIT_ALLOW=cir_return, CIR_NO_OF_CHQBOUNCE=noofchkbounc, CIR_DAYS_CHQBOUNCE=noofdaychkrec, CIR_RETURN_DAYS=retday, CIR_SUP_ORDER_LIMIT=chngsuppord, DISP_BILLING_CRITERIA=disp_bill, CLSD_BILLING_CRITERIA=clas_bill,MAX_PUBLISHDAYS=max_publishday,BILLNO_PERIODICITY=p_billno_period,
   SPECIALDISC_TRANS_EDIT=spl_trans_edit, SHARING_TRANS=spl_dis_trans_editable, MULTIPACKAGE_SEL_TRANS=mul_pac_sel_trans,SCHEME_MINWORD=shmon_minword, TRADE_SPLCHARGE=tradon_spcrg,RATE_AUTHORIZATION=rateauth
  ,F2_RECORD=f2day,PUBLISHAD_EDIT_RATEAUDIT=rateauditmodify,BINDREVENUE_CENTER=bindrevenuecenter,  
  FA_LEDGER_ALLOW=p_led_allow ,CLEARANCE_TYPE_ALLOW=p_clear_allow,REPEAT_DAY_TYPE=repeatday,PREMIUM_EDIT=premiumedit,
BILL_GENERATION_PRIOR=P_BILL_GENERATION,PUBLICATION_HO=P_PUBLICATION_CENTER,SPLDISC_ALLOWPREM=P_allow_discount_prem,

BILL_SCHEME=P_SCHEME_BILLING,ALLOWED_PDC_DAYS_RECEIPT=P_ALLOW_PDC ,AD_TYPE_MANUL_BILL=PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=RO_OUTSTAND_P,GENRATE_CIR_AGCD=genrate_agency_code,DISP_AUDITBKG=p_dispauditbk,CIR_DIS_AUTO_POSTING=p_aotosupply,RELAUTHREQON=p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=p_CIR_UNSOLD_ON_RECEIVED_DT,
AGENCY_UNBLOCK_APPROVAL=p_AGENCY_UNBLOCK_APROV,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=p_UNBLOCK_APROV_OUT_LMT,CIR_BILL_PUBLWISE=p_CIR_BILL_PUBLWISE


  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/






/******************************************************************************************************************/



CREATE OR REPLACE PACKAGE Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/





CREATE OR REPLACE PACKAGE BODY Currbindpreferpgld
IS
   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
         SELECT "date_format", "autogenerated", "currency_code",
                "rate_gr_code", "solo", "breakup", "blackwhitecode",
                "rostatus", "File_name", "Tfn", "Insert_breakup", "prefix",
                "suffix", "financestatus", "voucherst", "Ad_category",
                "Ro_datetime", "Vat", "Booking_status", "Cio_id",
                "Receipt_no","uom_code","Bgcolor_publication","chkfor_valid_pubdates","Agency_ratecode","audit","book_insert_date","agencycomm",
                "rate_audit","bill_audit","billtype","Premium_type","copy_booking","RATE_COMPANY_AGENCY","ADDITIONAL_AGENCY_COMM","AGENCY_RETAINER_COMM","SUBEDITIONRATE",CLS_BILLTYPE,DIS_BILLTYPE,
                "BILLING_FORMAT","RATE_CHECK","ALL_PACKAGE",dayrate,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,
                ROKEYCHECK, AGENCYCOMM_SEQ_COM, CREDIT_RECIPT,  DISP_CASHBILL, CLA_CASHBILL,
                RATE_AUDIT_PREF,BARCODING_ALLOWED, FMG_BILL_DIS,BILL_DISP_CASHBILL, BILL_CLA_CASHBILL,BACKDATERECEIPT,ROWISE_CASHBOOKING,CUTOFFTIME,DOCKIT_BOOKING,APPROVAL,BACK_DAYS,CASH_DISCOUNT,CASH_DISCOUNTTYPE,"Allowed_old_date",SEPRATE_CASHIER,
                CIR_MANY_TIME_POSTING, CIR_BACKDAYS_POSTING, CIR_MAX_RETURN_ALLOW, CIR_RETURN_LIMIT_ALLOW, CIR_NO_OF_CHQBOUNCE, CIR_DAYS_CHQBOUNCE, CIR_RETURN_DAYS, CIR_SUP_ORDER_LIMIT, DISP_BILLING_CRITERIA, CLSD_BILLING_CRITERIA,MAX_PUBLISHDAYS,
                BILLNO_PERIODICITY, SPECIALDISC_TRANS_EDIT, SHARING_TRANS, MULTIPACKAGE_SEL_TRANS,SCHEME_MINWORD, TRADE_SPLCHARGE,RATE_AUTHORIZATION,
           F2_RECORD,PUBLISHAD_EDIT_RATEAUDIT,BINDREVENUE_CENTER, FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,REPEAT_DAY_TYPE,PREMIUM_EDIT,
           
           BILL_GENERATION_PRIOR,PUBLICATION_HO,SPLDISC_ALLOWPREM,BILL_SCHEME,ALLOWED_PDC_DAYS_RECEIPT,
           AD_TYPE_MANUL_BILL,OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD,DISP_AUDITBKG,CIR_DIS_AUTO_POSTING,RELAUTHREQON,
        CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,
        AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE   
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/



























/***********************mimoh 14-dec-2011*********************************5933****************/

/*======================================= ISSUE 0005830,0005941 (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE PROCEDURE Schedulereport1(
fromdate        IN VARCHAR2,
dateto          IN VARCHAR2,
compcode        IN VARCHAR2,
pub_name        IN VARCHAR2,
pub_cent        IN VARCHAR2,
dateformat      IN VARCHAR2,
descid          IN VARCHAR2:=NULL,
ascdesc         IN VARCHAR2:=NULL,
adtyp           IN VARCHAR2,
adcatg          IN VARCHAR2,
edition_name    in varchar2,
drpstatus       in varchar2,
supplement_name in varchar2,
packagecode     in varchar2,
editiondtl      in varchar2,
puserid         in varchar2:=null,
chk_access      in varchar2:=null,
p_branch        in varchar2:=null,
p_accounts      OUT Cur_Type_New1.cursor_type,
p_accounts1     OUT Cur_Type_New1.cursor_type,
p_accounts2     OUT Cur_Type_New1.cursor_type,
p_accounts3     out Cur_Type_New1.cursor_type,
p_accounts4     out Cur_Type_New1.cursor_type
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
AND (TBL_BOOKING_mast."branch"  = p_branch  OR	p_branch  is null)
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
AND (TBL_BOOKING_mast."branch"  = p_branch  OR	p_branch  is null)
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
 (select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3",
TBL_BOOKING_INSERT."Page_No" as "Pageno",
TBL_BOOKING_MAST."Paid_ins" as "Paidins",
TBL_BOOKING_MAST."Rate_code" as ratecd,
UOM_MAST."Uom_Name"  AS "Uom",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
,TBL_BOOKING_MAST."Booking_type" AS "booktype"
,tbl_booking_mast."audit" as "audit"
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT"
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
 (select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3",
TBL_BOOKING_INSERT."Page_No" as "Pageno",
TBL_BOOKING_MAST."Paid_ins" as "Paidins",
TBL_BOOKING_MAST."Rate_code" as ratecd,
UOM_MAST."Uom_Name"  AS "Uom",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
,TBL_BOOKING_MAST."Booking_type" AS "booktype"
,tbl_booking_mast."audit" as "audit"
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT"
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
 (select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3",
TBL_BOOKING_INSERT."Page_No" as "Pageno",
TBL_BOOKING_MAST."Paid_ins" as "Paidins",
TBL_BOOKING_MAST."Rate_code" as ratecd,
UOM_MAST."Uom_Name"  AS "Uom",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
,TBL_BOOKING_MAST."Booking_type" AS "booktype"
,tbl_booking_mast."audit" as "audit"
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT"
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
 (select AD_CAT3."catname"   FROM AD_CAT3 WHERE  AD_CAT3."catcode"=tbl_booking_mast."Ad_Subcat3" and AD_CAT3."compcode"=tbl_booking_mast."Comp_code" ) AS "AdSubcat3",
TBL_BOOKING_INSERT."Page_No" as "Pageno",
TBL_BOOKING_MAST."Paid_ins" as "Paidins",
TBL_BOOKING_MAST."Rate_code" as ratecd,
UOM_MAST."Uom_Name"  AS "Uom",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code" and tbl_booking_mast."Comp_code"=uom_mast."Comp_Code"  )as "uomdesc"
,TBL_BOOKING_MAST."Booking_type" AS "booktype"
,tbl_booking_mast."audit" as "audit"
,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT"
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


IF(pub_name IS NOT NULL )THEN
query1:=query1||' AND TBL_BOOKING_INSERT."Publication_Code"='''||pub_name||'''';

END IF;

IF(p_branch IS NOT NULL )THEN
query1:=query1||' AND TBL_BOOKING_INSERT."branch"='''||p_branch||'''';

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

/*======================================= End of ISSUE 0005830,0005941 (Kuldeep Bhati) ==============================*/

/*=======================================  ISSUE 5952 (mimoh) ==============================*/

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
     INSERT INTO RETAIN_ADCOMM_TARGET (ADD_COMM_ID,COMP_CODE, RETAIN_CODE, PUBL_CODE, NO_OF_PUBL,ADCOMM_PER,
									  COMM_TYPE, CREATED_BY, CREATED_DT, UPDATED_BY, UPDATED_DT,COMM_TARGET_ID)
                            VALUES  (RETAIN_ADCOMM_TARGET_seq.nextval,PCOMP_CODE,PRETAIN_CODE,PPUBL_CODE,PNO_OF_PUBL,PADCOMM_PER,
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

/*********************************************************************************************/
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




/**************************new****************/
CREATE OR REPLACE PACKAGE Ra_Bindadcategory IS
TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE RA_bindadcategory_p(

advtype VARCHAR2,
compcode VARCHAR2,
P_Accounts OUT  T_Accounts_Cursor
);
END Ra_Bindadcategory;
/



CREATE OR REPLACE PACKAGE BODY Ra_Bindadcategory IS
PROCEDURE RA_bindadcategory_p(

advtype VARCHAR2,
compcode VARCHAR2,
P_Accounts OUT  T_Accounts_Cursor
)AS

BEGIN
OPEN P_Accounts FOR
SELECT "Adv_Cat_Code","Adv_Cat_Name" FROM ADV_CAT_MAST WHERE  "Comp_Code"=compcode and ("Adv_Type"=advtype or advtype is null);

END RA_bindadcategory_p;
END Ra_Bindadcategory;
/


/*************************/

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
     INSERT INTO RETAIN_ADCOMM_TARGET (ADD_COMM_ID,COMP_CODE, RETAIN_CODE, PUBL_CODE, NO_OF_PUBL,ADCOMM_PER,
									  COMM_TYPE, CREATED_BY, CREATED_DT, UPDATED_BY, UPDATED_DT,COMM_TARGET_ID)
                            VALUES  (RETAIN_ADCOMM_TARGET_seq.nextval,PCOMP_CODE,PRETAIN_CODE,PPUBL_CODE,PNO_OF_PUBL,PADCOMM_PER,
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


/*********************************************************************/

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
select  PUBL_CODE, NO_OF_PUBL,ADCOMM_PER,COMM_TYPE,COMM_TARGET_ID,ADD_COMM_ID from retain_adcomm_target where COMP_CODE=compcode and RETAIN_CODE=retcode and ADD_COMM_ID=code11;


end;
/

/*=======================================  ISSUE 5952 (mimoh) ==============================*/

/*======================================= ISSUE 0005968 (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE PACKAGE websp_saveagent
IS
   PROCEDURE websp_saveagent_p (
      compcode             IN   VARCHAR2,
      agencytype           IN   VARCHAR2,
      agentcategory        IN   VARCHAR2,
      agentcategory2       IN   VARCHAR2,
      agentcode            IN   VARCHAR2,
      agentname            IN   VARCHAR2,
      alias                IN   VARCHAR2,
      agencyho             IN   VARCHAR2,
      txtfax1              IN   VARCHAR2,
      address              IN   VARCHAR2,
      street               IN   VARCHAR2,
      city                 IN   VARCHAR2,
      district1             IN   VARCHAR2,
      state1                IN   VARCHAR2,
      country              IN   VARCHAR2,
      phone                IN   VARCHAR2,
      fax                  IN   VARCHAR2,
      mail                 IN   VARCHAR2,
      url1                  IN   VARCHAR2,
      bussinessstartdate   IN   DATE,
      enrolldate           IN   DATE,
      novts                IN   VARCHAR2,
      credit               IN   VARCHAR2,
      pan                  IN   VARCHAR2,
      TAN                  IN   VARCHAR2,
      stacno               IN   VARCHAR2,
      paymode              IN   VARCHAR2,
      status               IN   VARCHAR2,
      remarks              IN   VARCHAR2,
      userid               IN   VARCHAR2,
      mrerefferenceno      IN   VARCHAR2,
      subagencyho          IN   VARCHAR2,
      agencycode           IN   VARCHAR2,
      billto               IN   VARCHAR2,
      alert                IN   VARCHAR2,
      creditlimit          IN   VARCHAR2,
      code                 IN   VARCHAR2,
      representative       IN   VARCHAR2,
      pin                  IN   VARCHAR2,
      region1               IN   VARCHAR2,
      TYPE1                 IN   VARCHAR2,
      ZONE1                 IN   VARCHAR2,
      address1             IN   VARCHAR2,
      address2             IN   VARCHAR2,
      curtype              IN   VARCHAR2,
      acagen               IN   VARCHAR2,
      rategrp              IN   VARCHAR2,
      qbcuserid            IN   VARCHAR2,
      taluka1            IN   VARCHAR2,
      branchcode         in varchar2,
      hddistcode            IN   VARCHAR2,
      hdstatecode         in varchar2,
      billf               in varchar2,
      oldagency           in varchar2,
      booktype1           in varchar2,
      vat1                in varchar2,
      p_raterevise        in varchar2
   );
END websp_saveagent;
/

CREATE OR REPLACE PACKAGE BODY websp_saveagent
IS
   PROCEDURE websp_saveagent_p (
      compcode             IN   VARCHAR2,
      agencytype           IN   VARCHAR2,
      agentcategory        IN   VARCHAR2,
      agentcategory2       IN   VARCHAR2,
      agentcode            IN   VARCHAR2,
      agentname            IN   VARCHAR2,
      alias                IN   VARCHAR2,
      agencyho             IN   VARCHAR2,
      txtfax1              IN   VARCHAR2,
      address              IN   VARCHAR2,
      street               IN   VARCHAR2,
      city                 IN   VARCHAR2,
      district1             IN   VARCHAR2,
      state1                IN   VARCHAR2,
      country              IN   VARCHAR2,
      phone                IN   VARCHAR2,
      fax                  IN   VARCHAR2,
      mail                 IN   VARCHAR2,
      url1                  IN   VARCHAR2,
      bussinessstartdate   IN   DATE,
      enrolldate           IN   DATE,
      novts                IN   VARCHAR2,
      credit               IN   VARCHAR2,
      pan                  IN   VARCHAR2,
      TAN                  IN   VARCHAR2,
      stacno               IN   VARCHAR2,
      paymode              IN   VARCHAR2,
      status               IN   VARCHAR2,
      remarks              IN   VARCHAR2,
      userid               IN   VARCHAR2,
      mrerefferenceno      IN   VARCHAR2,
      subagencyho          IN   VARCHAR2,
      agencycode           IN   VARCHAR2,
      billto               IN   VARCHAR2,
      alert                IN   VARCHAR2,
      creditlimit          IN   VARCHAR2,
      code                 IN   VARCHAR2,
      representative       IN   VARCHAR2,
      pin                  IN   VARCHAR2,
      region1               IN   VARCHAR2,
      TYPE1                 IN   VARCHAR2,
      ZONE1                IN   VARCHAR2,
      address1             IN   VARCHAR2,
      address2             IN   VARCHAR2,
      curtype              IN   VARCHAR2,
      acagen               IN   VARCHAR2,
      rategrp              IN   VARCHAR2,
      qbcuserid            IN   VARCHAR2,
      taluka1            IN   VARCHAR2,
        branchcode         in varchar2,
        hddistcode            IN   VARCHAR2,
      hdstatecode         in varchar2,
      billf               in varchar2,
      oldagency           in varchar2,
      booktype1           in varchar2,
      vat1                in varchar2,
      p_raterevise        in varchar2
   )
   AS
   BEGIN
      INSERT INTO agency_mast
                  ("Comp_Code", "Agency_Type_Code", "Agency_Cat_Code",
                   "Agency_SubCat_Code", "Agency_Code", "Agency_Name",
                   "Agency_Alias", "Agency_HO", "Add1", "Street",
                   "City_Code", "Dist_Code", "State_Code", "Country_Code",
                   "Phone", "Fax", "EmailID", "URL", "Buss_Start_Date",
                   "Enroll_Date", "MRV_Ref_No", "No_of_VTS", "Credit_Days",
                   "PAN_No", "TAN_No", "ST_ACC_No", "Pay_Mode_Code",
                   "Status_Reason", "Remarks", "UserID", "SUB_Agency_HO",
                   "SUB_Agency_Code", "acagency", "ALERT", "CREDIT_LIMIT",
                   "CODE", "Representative_code", "pin_code", "region",
                   "Type", "code_subcode", "zone_code", "Add2", "Add3",
                   "CREDIT_TYPE", "BILL_TO", "fax1", "Rate_Group",
                   "qbc_userid","Creation_Datetime","TALUKA","Branch_code",DISTRICT,STATE,BILL_FREQUENCY,OLD_AGENCY,BOOKING_TYPE,VAT,RATE_REVISE
                  )
           VALUES (compcode,agencytype, agentcategory, agentcategory2,
                    agentcode, agentname,
                   alias, agencyho, address, street,
                   city, district1, state1, country,
                   phone, fax, mail, url1, bussinessstartdate,
                   enrolldate, mrerefferenceno, novts, credit,
                   pan, TAN, stacno, paymode,
                   status, remarks, userid, subagencyho,
                   agencycode, acagen, alert, creditlimit,
                   code, representative, pin, region1,
                   TYPE1, agentcode || agencycode, zone1, address1, address2,
                   curtype, billto, txtfax1, rategrp,
                   qbcuserid,sysdate,taluka1,branchcode,hddistcode,hdstatecode,billf,oldagency,booktype1,vat1, p_raterevise
                  );

      COMMIT;
   END websp_saveagent_p;
END websp_saveagent;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE websp_agencymodify
IS
   PROCEDURE websp_agencymodify_p (
      compcode             IN   VARCHAR2,
      agencytype           IN   VARCHAR2,
      agentcategory        IN   VARCHAR2,
      agentcategory2       IN   VARCHAR2,
      agentcode            IN   VARCHAR2,
      agentname            IN   VARCHAR2,
      alias                IN   VARCHAR2,
      agencyho             IN   VARCHAR2,
      TYPE1                 IN   VARCHAR2,
      address              IN   VARCHAR2,
      street               IN   VARCHAR2,
      city                 IN   VARCHAR2,
      zip                  IN   VARCHAR2,
      district1             IN   VARCHAR2,
      state1               IN   VARCHAR2,
      country              IN   VARCHAR2,
      phone                IN   VARCHAR2,
      txtfax2              IN   VARCHAR2,
      fax                  IN   VARCHAR2,
      mail                 IN   VARCHAR2,
      url1                  IN   VARCHAR2,
      bussinessstartdate   IN   DATE,
      enrolldate           IN   DATE,
      novts                IN   VARCHAR2,
      credit               IN   VARCHAR2,
      pan                  IN   VARCHAR2,
      TAN                  IN   VARCHAR2,
      stacno               IN   VARCHAR2,
      paymode              IN   VARCHAR2,
      status               IN   VARCHAR2,
      remarks              IN   VARCHAR2,
      userid               IN   VARCHAR2,
      mrerefferenceno      IN   VARCHAR2,
      subagencyho          IN   VARCHAR2,
      agencycode           IN   VARCHAR2,
      billto               IN   VARCHAR2,
      alert1                IN   VARCHAR2,
      creditlimit          IN   VARCHAR2,
      code                 IN   VARCHAR2,
      region1               IN   VARCHAR2,
      representative       IN   VARCHAR2,
      pincode              IN   VARCHAR2,
      stacno1              IN   VARCHAR2,
      ZONE1                 IN   VARCHAR2,
      address1             IN   VARCHAR2,
      address2             IN   VARCHAR2,
      curtype              IN   VARCHAR2,
      acagen               IN   VARCHAR2,
      rategrp              IN   VARCHAR2,
      qbcuserid            IN   VARCHAR2,
      depocode                IN    VARCHAR2,
      taluka1              IN    VARCHAR2,
      branchcode              IN	VARCHAR2,
      hddistcode in varchar2,
      hdstatecode    in varchar2 ,
      billf           in varchar2,
      oldagen         in varchar2,
      booktype1           in varchar2,
      vat1    in varchar2,
      p_raterevise        in varchar2
   );
END websp_agencymodify;
/

CREATE OR REPLACE PACKAGE BODY websp_agencymodify
IS
   PROCEDURE websp_agencymodify_p (
      compcode             IN   VARCHAR2,
      agencytype           IN   VARCHAR2,
      agentcategory        IN   VARCHAR2,
      agentcategory2       IN   VARCHAR2,
      agentcode            IN   VARCHAR2,
      agentname            IN   VARCHAR2,
      alias                IN   VARCHAR2,
      agencyho             IN   VARCHAR2,
      TYPE1                 IN   VARCHAR2,
      address              IN   VARCHAR2,
      street               IN   VARCHAR2,
      city                 IN   VARCHAR2,
      zip                  IN   VARCHAR2,
      district1             IN   VARCHAR2,
      state1                IN   VARCHAR2,
      country              IN   VARCHAR2,
      phone                IN   VARCHAR2,
      txtfax2              IN   VARCHAR2,
      fax                  IN   VARCHAR2,
      mail                 IN   VARCHAR2,
      url1                  IN   VARCHAR2,
      bussinessstartdate   IN   DATE,
      enrolldate           IN   DATE,
      novts                IN   VARCHAR2,
      credit               IN   VARCHAR2,
      pan                  IN   VARCHAR2,
      TAN                  IN   VARCHAR2,
      stacno               IN   VARCHAR2,
      paymode              IN   VARCHAR2,
      status               IN   VARCHAR2,
      remarks              IN   VARCHAR2,
      userid               IN   VARCHAR2,
      mrerefferenceno      IN   VARCHAR2,
      subagencyho          IN   VARCHAR2,
      agencycode           IN   VARCHAR2,
      billto               IN   VARCHAR2,
      alert1                IN   VARCHAR2,
      creditlimit          IN   VARCHAR2,
      code                 IN   VARCHAR2,
      region1               IN   VARCHAR2,
      representative       IN   VARCHAR2,
      pincode              IN   VARCHAR2,
      stacno1              IN   VARCHAR2,
      zone1                IN   VARCHAR2,
      address1             IN   VARCHAR2,
      address2             IN   VARCHAR2,
      curtype              IN   VARCHAR2,
      acagen               IN   VARCHAR2,
      rategrp              IN   VARCHAR2,
      qbcuserid            IN   VARCHAR2,
	  depocode 			   IN	VARCHAR2,
      taluka1              IN	VARCHAR2,
      branchcode               IN	VARCHAR2,
      hddistcode in varchar2,
      hdstatecode    in varchar2 ,
      billf           in varchar2,
      oldagen         in varchar2,
      booktype1           in varchar2,
      vat1    in varchar2,
     p_raterevise        in varchar2
   )
   AS
   BEGIN
      UPDATE agency_mast
         SET "Rate_Group" = rategrp,
             "Agency_Code" = agentcode,
             "fax1" = txtfax2,
             "CREDIT_TYPE" = curtype,
             "zone_code" = zone1,
             "Type" = TYPE1,
             "Agency_Type_Code" = agencytype,
             "Agency_Cat_Code" = agentcategory,
             "Agency_SubCat_Code" = agentcategory2,
             "Agency_Name" = agentname,
             "Agency_Alias" = alias,
             "Agency_HO" = agencyho,
             "Add1" = address,
             "Street" = street,
             "City_Code" = city,
             "Zip" = zip,
             "Dist_Code" = district1,
             "State_Code" = state1,
             "Country_Code" = country,
             "Phone" = phone,
             "Fax" = fax,
             "EmailID" = mail,
             "URL" = url1,
             "Buss_Start_Date" = bussinessstartdate,
             "Enroll_Date" = enrolldate,
             "MRV_Ref_No" = mrerefferenceno,
             "No_of_VTS" = novts,
             "Credit_Days" = credit,
             "PAN_No" = pan,
             "TAN_No" = TAN,
             "ST_ACC_No" = stacno1,
             "Pay_Mode_Code" = paymode,
             "Status_Reason" = status,
             "Remarks" = remarks,
             "SUB_Agency_HO" = subagencyho,
             "SUB_Agency_Code" = agencycode,
             "BILL_TO" = acagen,
             "acagency" = billto,
             "ALERT" = alert1,
             "CREDIT_LIMIT" = creditlimit,
             "CODE" = code,
             "region" = region1,
             "Representative_code" = representative,
             "pin_code" = pincode,
             "Add2" = address1,
             "Add3" = address2,
             "qbc_userid" = qbcuserid,
             "TALUKA"=taluka1,
             "Branch_code"=branchcode, DISTRICT=hddistcode,STATE=hdstatecode,BILL_FREQUENCY=billf,OLD_AGENCY=oldagen,BOOKING_TYPE=booktype1,VAT=vat1,
             RATE_REVISE=p_raterevise
       WHERE "Comp_Code" = compcode AND "SUB_Agency_Code" = agencycode;

        --UPDATE ad_user SET "DEPO_CODE"=depocode where "AGENCY_CODE"=agentcode;

      COMMIT;
   END websp_agencymodify_p;
END websp_agencymodify;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE Websp_Executeagency
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE websp_executeagency_p (
      compcode           IN       VARCHAR2,
      userid             IN       VARCHAR2,
      agentcode          IN       VARCHAR2,
      subagencycode      IN       VARCHAR2,
      agencyname1        IN       VARCHAR2,
      alias              IN       VARCHAR2,
      agenttype          IN       VARCHAR2,
      agentcategory      IN       VARCHAR2,
      agentsubcategory   IN       VARCHAR2,
      city               IN       VARCHAR2,
      COUNT1             IN       VARCHAR2,
      branchcode         IN       VARCHAR2,
      billf              in       varchar2,
      p_accounts         OUT      t_accounts_cursor
   );
END Websp_Executeagency;
/

CREATE OR REPLACE PACKAGE BODY Websp_Executeagency
IS
   PROCEDURE websp_executeagency_p (
      compcode           IN       VARCHAR2,
      userid             IN       VARCHAR2,
      agentcode          IN       VARCHAR2,
      subagencycode      IN       VARCHAR2,
      agencyname1        IN       VARCHAR2,
      alias              IN       VARCHAR2,
      agenttype          IN       VARCHAR2,
      agentcategory      IN       VARCHAR2,
      agentsubcategory   IN       VARCHAR2,
      city               IN       VARCHAR2,
      COUNT1              IN       VARCHAR2,
      branchcode         IN       VARCHAR2,
      billf              in       varchar2,
      p_accounts         OUT      t_accounts_cursor
   )
   AS
      agencyname2      VARCHAR (50);
      agentcode1       VARCHAR (12);
      subagencycode1   VARCHAR (15);
      alias1           VARCHAR (30);
   BEGIN
  DELETE FROM FIRST1 ; COMMIT;
   --  INSERT INTO FIRST1


    OPEN p_accounts FOR

     SELECT "Comp_Code", "Agency_Type_Code", "Agency_Cat_Code",
                "Agency_SubCat_Code", "Agency_Code", "Agency_Name" AS "Agency_Name",
                "Agency_Alias", "Agency_HO", "Add1", "Street", "City_Code",
                "Zip", "Dist_Code", "State_Code", "Country_Code", "Phone",
                "Fax", "EmailID", "URL", "Buss_Start_Date", "Enroll_Date",
                "MRV_Ref_No", "No_of_VTS", "Credit_Days", "PAN_No", "TAN_No",
                "ST_ACC_No", "Pay_Mode_Code",
                (SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE") AS "status_name",
                "Status_Reason", "Remarks", "UserID", SYSDATE AS "current_Datetime", "UserID",
                "SUB_Agency_HO" AS "SUB_Agency_HO", "SUB_Agency_Code" AS "SUB_Agency_Code", "BILL_TO", "ALERT",
                "CREDIT_LIMIT", "CODE", "Representative_code" as "representative_code", "pin_code",
                "region",
                (SELECT "TO_DATE"
                   FROM STATUS_DETAIL
                  WHERE ROWNUM <= 1
                    AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode") AS "to_date",
                "Type", "code_subcode", "zone_code", "Add2", "Add3",
                "CREDIT_TYPE", "acagency", "fax1", "Rate_Group",
                "qbc_userid",(select "DEPO_CODE" from ad_user where ad_user."AGENCY_CODE"=agency_mast."code_subcode"  AND ROWNUM<=1) AS "DEPOCODE",
                (select "AGENCY_CODE" from ad_user where ad_user."AGENCY_CODE"=agency_mast."code_subcode"  AND ROWNUM<=1) AS "AGENCYCODE","TALUKA","Branch_code",/*(select dist_mst."Dist_Name" from dist_mst where dist_mst."Dist_Code"=agency_mast.DISTRICT and "Comp_Code"=compcode) as */DISTRICT,/*(select state_mst."State_Name" from state_mst where state_mst."State_Code"=agency_mast.STATE and "Comp_Code"=compcode) as */STATE,BILL_FREQUENCY,OLD_AGENCY,BOOKING_TYPE,VAT,
                RATE_REVISE
           FROM AGENCY_MAST
                WHERE ("Comp_Code" = compcode OR compcode IS NULL)
                AND ("Agency_Code" like agentcode||'%')
                AND ("SUB_Agency_Code" like  subagencycode   OR subagencycode IS NULL)
                AND ("Agency_Name" like agencyname1||'%')-- OR agencyname1  IS NULL)
                AND ("Agency_Alias" like alias   OR alias IS NULL)
                AND ("Agency_Type_Code" like agenttype   OR agenttype IS NULL)
                 AND ("Branch_code" like branchcode   OR branchcode IS NULL)
                AND ("Agency_Cat_Code"like agentcategory   OR agentcategory IS NULL)
                AND (BILL_FREQUENCY =billf OR billf IS NULL);



       END websp_executeagency_p;
END Websp_Executeagency;
/

/*======================================= End of ISSUE 0005968 (Kuldeep Bhati) ==============================*/

/*======================================= ISSUE 0005972 ==============================*/
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
      p_QBC_AGENCY        IN   VARCHAR2,
      p_type        IN   VARCHAR2,
      p_parent        IN   VARCHAR2
   );
END clientsave;
/
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
      p_QBC_AGENCY        IN   VARCHAR2,
      p_type        IN   VARCHAR2,
      p_parent        IN   VARCHAR2
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
                QBC_AGENCY=p_QBC_AGENCY,
                "TYPE"=p_type,
                PARENT_CLIENT=p_parent
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
                      CLIENT_TYPE,QBC_AGENCY,"TYPE",PARENT_CLIENT
                     )
              VALUES (compcode, custcode, custname, custalias,
                      add1, street, citycode, zip, dist,
                      state, country, phone1, phone2,
                      fax, emailid, url1, vats, servicetax1,
                      pan1, creditdays, paymodecode,
                      fatchstatus, statusreason, alert, userid,
                      SYSDATE, zone, region1,
                      crdlimit, rategroup, clientcat,taluka1,agency_sav,
                      p_CLIENT_TYPE,p_QBC_AGENCY,p_type,p_parent
                     );
      END IF;
   END clientsave_p;
END clientsave;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
      INSERT INTO CUST_MAST_TEMP(
            comp_code, cust_code, cust_name, cust_alias, add1, 
            stree, city_code, zip, dist_code, state_code, 
            country_code, phone1, phone2, fax, emailid, url, 
            no_of_vts, st_acc_no, pan_no, credit_days, 
            pay_mode_code, cust_status, status_reason, remarks, 
            userid, creation_datetime, zone_code, region_code,
            credit_limit, rate_gr_code, to_date, client_category, taluka1, 
            agency_code, division, client_type, qbc_agency,"TYPE",PARENT_CLIENT)
         SELECT "Comp_Code", "Cust_Code", "Cust_Name", "Cust_Alias", "Add1",
                "Stree", "City_Code", "Zip", "Dist_Code", "State_Code",
                "Country_Code", "phone1", "Phone2", "Fax", "EmailID", "URL",
                "No_of_VTS", "ST_ACC_No", "PAN_No", "Credit_Days",
                "Pay_Mode_Code", "Cust_Status", "Status_Reason", "Remarks",
                "UserId", "Creation_Datetime", "Zone_code", "Region_code",
                "Credit_limit", "Rate_Gr_Code", SYSDATE, "Client_category","TALUKA",
                AGENCY_CODE, DIVISION, CLIENT_TYPE, QBC_AGENCY,"TYPE",PARENT_CLIENT
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
SELECT COMP_CODE as "Comp_Code", CUST_CODE as "Cust_Code", CUST_NAME as "Cust_Name", CUST_ALIAS as "Cust_Alias", ADD1 as "Add1", STREE as "Stree", CITY_CODE as "City_Code", ZIP as "Zip", DIST_CODE as "Dist_Code", STATE_CODE as "State_Code", COUNTRY_CODE as "Country_Code", PHONE1 as "phone1", PHONE2 as "Phone2", FAX as "Fax", EMAILID as "EmailID", URL, NO_OF_VTS as "No_of_VTS", ST_ACC_NO, PAN_NO, CREDIT_DAYS as "Credit_Days", PAY_MODE_CODE as "Pay_Mode_Code", CUST_STATUS as "Cust_Status", STATUS_REASON as "Status_Reason", REMARKS as "Remarks", USERID as "UserId", CREATION_DATETIME as "Creation_Datetime", ZONE_CODE as "Zone_code", REGION_CODE as "Region_code", CREDIT_LIMIT as "Credit_limit", RATE_GR_CODE as "Rate_Gr_Code", TO_DATE as "to_date", CLIENT_CATEGORY as "Client_category",TALUKA1 as "TALUKA",CLIENT_TYPE, QBC_AGENCY,"TYPE",PARENT_CLIENT FROM CUST_MAST_TEMP ORDER BY Cust_Code;

   END clientexecute_p;
END Clientexecute;
/





/********************************************************************************/
CREATE OR REPLACE FUNCTION ADD_GET_CLIENT_NAME(pcomp_code in varchar2,catcode in varchar2) RETURN CHAR IS
v_cust_name cust_mast."Cust_Name"%type;
BEGIN
  Begin
     select "Cust_Name" into v_cust_name from cust_mast where "Cust_Code"=catcode and "Comp_Code"=pcomp_code;
       exception when others then
                 v_cust_name:=null;
  End;
  return nvl(v_cust_name,'');  
END ADD_GET_CLIENT_NAME;
/



/*****************************************************************************************/



CREATE OR REPLACE PROCEDURE Add_bindParentclient
(
compcode          IN       VARCHAR2,
client            in varchar2:=null,
center            in varchar2,
p_accounts        OUT Cur_Type_New1.cursor_type)
 as 
 begin
if(center != '0' and center is not null) then
      OPEN p_accounts FOR
         select "Cust_Code" as "Cust_Code","Cust_Name" as "Cust_Name","Add1"  from cust_mast where "Comp_Code"=compcode and "Cust_Name" 
         like '%'|| upper(client)|| '%' and "Dist_Code"=(select "Dist_Code" from branch_mst where "Branch_Code"=center) 
         and nvl("Cust_Status",'ACTIVE')='ACTIVE' and (client_type='' or client_type is null or client_type='B') 
         and "TYPE"='P' order by "Cust_Name";
   else
     OPEN p_accounts FOR
         select "Cust_Code" as "Cust_Code","Cust_Name" as "Cust_Name","Add1"  from cust_mast where "Comp_Code"=compcode and "Cust_Name" 
         like '%'|| upper(client) || '%' and nvl("Cust_Status",'ACTIVE')='ACTIVE' and (client_type='' or client_type is null or client_type='B') 
         and "TYPE"='P' order by "Cust_Name";
   end if;    
end;
/


/*======================================= End of ISSUE 0005972 ==============================*/


/*================================21/dec/2011=======  ISSUE 0005940 ==============================*/


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

(select ad_cat3."catname" from ad_cat3,adv_subcat_mast where tbl_booking_mast."Ad_Subcat3"=ad_cat3."catcode" and ad_cat3."subcatname"=adv_subcat_mast."Adv_Subcat_Code" and TBL_BOOKING_INSERT ."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and TBL_BOOKING_INSERT ."Ad_Cat"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat3",

trim(TBL_BOOKING_INSERT."Edition") as "Edition",

(SELECT "premiumname" FROM ADVPOS_PREM_MAST WHERE ADVPOS_PREM_MAST."Premiumcode"=TBL_BOOKING_MAST."Page_prem") AS  Page_prem1 ,


(SELECT distinct adv_subcat_mast."Adv_Subcat_Name" FROM adv_subcat_mast  WHERE adv_subcat_mast ."Adv_Subcat_Code"=TBL_BOOKING_INSERT ."Ad_Sub_Cat") AS "Sub_cat",

(SELECT ADVPOS_PREM_MAST."premiumname" FROM  ADVPOS_PREM_MAST WHERE TBL_BOOKING_insert."Premium1" =ADVPOS_PREM_MAST ."Premiumcode")AS "Page_prem",

(SELECT ADVPOS_TYPE_MAST."Pos_Type" FROM  ADVPOS_TYPE_MAST WHERE TBL_BOOKING_insert."Page_Post" =ADVPOS_TYPE_MAST  ."Pos_Type_Code")AS "Page_pos"

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
--commit;
OPEN p_recordset FOR
 query1;



END ;
/


/*================================21/dec/2011=======  ISSUE 0005940 ==============================*/

/*================================21/dec/2011=======  ISSUE 0005951 ==============================*/


CREATE OR REPLACE PACKAGE Wesp_Updatedate
IS
PROCEDURE      Wesp_Updatedate_p(
compcode IN VARCHAR2,
userid IN VARCHAR2,
dateformat IN VARCHAR2,
code IN VARCHAR2,
curr IN VARCHAR2,
RATECODE11 IN VARCHAR2,
solo  IN VARCHAR2,
breakup VARCHAR2,
bwcode IN VARCHAR2,
rostatus IN VARCHAR2,
filename IN VARCHAR2,
tfn IN NUMBER,
insertbreak IN VARCHAR2,
prem IN VARCHAR2,
dealtype IN VARCHAR2,
pre IN VARCHAR2,
suff IN VARCHAR2,
financestatus IN  VARCHAR2,
voucherst IN VARCHAR2,
adcode IN VARCHAR2,
rodatetime IN VARCHAR2,
spacearea IN VARCHAR2,
vat IN VARCHAR2,
bookstat IN VARCHAR2,
cio_id IN VARCHAR2,
receipt_no IN VARCHAR2,
uom IN VARCHAR2,
bgcolor IN VARCHAR2,
validdate IN VARCHAR2,
agencyratecode IN VARCHAR2,
AUDIT1 IN VARCHAR2,
book_insert_date IN VARCHAR2,
agencycomm IN VARCHAR2,
rateaudit IN VARCHAR2,
billaudit IN VARCHAR2,
bill_type IN VARCHAR2,
invoice_no1 IN VARCHAR2,
copybooking IN VARCHAR2,
ratecompany IN VARCHAR2,
addagenycomm IN VARCHAR2,
agencycommlinkretainer IN VARCHAR2,
subeditionr IN VARCHAR2,
displaybilltype IN VARCHAR2,
classifiedbilltype IN VARCHAR2,
billformat IN VARCHAR2,
ratechk IN VARCHAR2,
allpkg IN VARCHAR2,
dayrate1 in varchar2,
schemetype in varchar2,
PIncludeclassi in varchar2,
receiptformat IN VARCHAR2,
v_cash_receipt in varchar2,
v_bill_orderwiselast in varchar2,
v_floor_chk in varchar2,
Unsoldflag in varchar2,
Supplystopper in  number,
drpRokeychk in varchar2,
Agencycomm_seq in varchar2,
creditreciept in varchar,
cashindisplay IN VARCHAR,
cashinclassified IN VARCHAR,
v_rate_audit_pref in varchar,
v_barcoding_allow_pref in varchar2,
v_fmgbills IN VARCHAR2,
v_billed_cashdis in varchar2,
v_billed_cashcls in varchar,
v_drpbackdate in varchar,
dockitbooking in varchar2,
allowprevbooking in varchar2,
ro_wisecashbill in varchar2,
chkval in varchar2,
approval1 in varchar2,
pckstatus in varchar2,
cash_disc in varchar2,
cash_amt in varchar2,
seperate_cashier1 in varchar2,
disp_bill in varchar2,
clas_bill in varchar2,
mantimepost in varchar2,
bkdaypost in number,
maxterutn in number,
cir_return in varchar2,
noofchkbounc in number,
noofdaychkrec in number,
retday in number,
chngsuppord in number,
max_publishday in number,
p_billno_period in varchar,
spl_trans_edit in varchar2,
spl_dis_trans_editable in varchar2,
mul_pac_sel_trans in varchar2,
shmon_minword in varchar2,
tradon_spcrg in varchar2,
rateauth     in varchar2,
f2day in number,
rateauditmodify in varchar,
bindrevenuecenter in varchar,
p_led_allow in varchar,
p_clear_allow in varchar,
repeatday in varchar,
premiumedit in varchar,
P_BILL_GENERATION in varchar,
P_PUBLICATION_CENTER in varchar,
P_allow_discount_prem IN VARCHAR,
P_SCHEME_BILLING in varchar,
P_ALLOW_PDC in varchar,
PAD_TYPE_FOR_MANUL_BILL in varchar,
RO_OUTSTAND_P IN VARCHAR2,
genrate_agency_code IN VARCHAR2,
p_dispauditbk IN VARCHAR2,
p_aotosupply  IN VARCHAR2,
p_Authorization IN VARCHAR2,
p_CIR_AUTO_APPROVAL_UNSOLD IN VARCHAR2,
p_CIR_AUTO_PHYSICAL_UNSOLD IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INCT IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INSFEE IN VARCHAR2,
p_CIR_UNSOLD_ON_RECEIVED_DT IN VARCHAR2,
p_AGENCY_UNBLOCK_APROV IN VARCHAR2,
p_UNBLOCK_APROV_OUT_LMT IN VARCHAR2,
p_CIR_BILL_PUBLWISE IN VARCHAR2,
p_paging         IN VARCHAR2,
p_print          IN VARCHAR2,
p_allowpage      IN VARCHAR2,
p_agency_req     IN VARCHAR2,
p_region_req     IN VARCHAR2

);
END      Wesp_Updatedate;
/





CREATE OR REPLACE PACKAGE BODY Wesp_Updatedate IS
PROCEDURE      Wesp_Updatedate_p(
compcode IN VARCHAR2,
userid IN VARCHAR2,
dateformat IN VARCHAR2,
code IN VARCHAR2,
curr IN VARCHAR2,
RATECODE11 IN VARCHAR2,
solo  IN VARCHAR2,
breakup VARCHAR2,
bwcode IN VARCHAR2,
rostatus IN VARCHAR2,
filename IN VARCHAR2,
tfn IN NUMBER,
insertbreak IN VARCHAR2,
prem IN VARCHAR2,
dealtype IN VARCHAR2,
pre IN VARCHAR2,
suff IN VARCHAR2,
financestatus IN  VARCHAR2,
voucherst IN VARCHAR2,
adcode IN VARCHAR2,
rodatetime IN VARCHAR2,
spacearea IN VARCHAR2,
vat IN VARCHAR2,
bookstat IN VARCHAR2,
cio_id IN VARCHAR2,
receipt_no IN VARCHAR2,
uom IN VARCHAR2,
bgcolor IN VARCHAR2,
validdate IN VARCHAR2,
agencyratecode IN VARCHAR2,
AUDIT1 IN VARCHAR2,
book_insert_date IN VARCHAR2,
agencycomm IN VARCHAR2,
rateaudit IN VARCHAR2,
billaudit IN VARCHAR2,
bill_type IN VARCHAR2,
invoice_no1 IN VARCHAR2,
copybooking IN VARCHAR2,
ratecompany IN VARCHAR2,
addagenycomm IN VARCHAR2,
agencycommlinkretainer IN VARCHAR2,
subeditionr IN VARCHAR2,
displaybilltype IN VARCHAR2,
classifiedbilltype IN VARCHAR2,
billformat IN VARCHAR2,
ratechk IN VARCHAR2,
allpkg IN VARCHAR2,
dayrate1 in varchar2,
schemetype in varchar2,
PIncludeclassi in varchar2,
receiptformat IN VARCHAR2,
v_cash_receipt in varchar2,
v_bill_orderwiselast in varchar2,
v_floor_chk in varchar2,
Unsoldflag in varchar2,
Supplystopper in  number,
drpRokeychk in varchar2,
Agencycomm_seq in varchar2,
creditreciept in varchar,
cashindisplay IN VARCHAR,
cashinclassified IN VARCHAR,
v_rate_audit_pref in varchar,
v_barcoding_allow_pref in varchar2,
v_fmgbills IN VARCHAR2,
v_billed_cashdis in varchar2,
v_billed_cashcls in varchar,
v_drpbackdate in varchar,
dockitbooking in varchar2,
allowprevbooking in varchar2,
ro_wisecashbill in varchar2,
chkval in varchar2,
approval1 in varchar2,
pckstatus in varchar2,
cash_disc in varchar2,
cash_amt in varchar2,
seperate_cashier1 in varchar2,
disp_bill in varchar2,
clas_bill in varchar2,
mantimepost in varchar2,
bkdaypost in number,
maxterutn in number,
cir_return in varchar2,
noofchkbounc in number,
noofdaychkrec in number,
retday in number,
chngsuppord in number,
max_publishday in number,
p_billno_period in varchar,
spl_trans_edit in varchar2,
spl_dis_trans_editable in varchar2,
mul_pac_sel_trans in varchar2,
shmon_minword in varchar2,
tradon_spcrg in varchar2,
rateauth     in varchar2,
f2day in number,
rateauditmodify in varchar,
bindrevenuecenter in varchar,
p_led_allow in varchar,
p_clear_allow in varchar,
repeatday in varchar,
premiumedit in varchar,
P_BILL_GENERATION in varchar,
P_PUBLICATION_CENTER in varchar,
P_allow_discount_prem IN VARCHAR,
P_SCHEME_BILLING in varchar,
P_ALLOW_PDC in varchar,
PAD_TYPE_FOR_MANUL_BILL in varchar,
RO_OUTSTAND_P IN VARCHAR2,
genrate_agency_code IN VARCHAR2,
p_dispauditbk IN VARCHAR2,
p_aotosupply  IN VARCHAR2,
p_Authorization IN VARCHAR2,
p_CIR_AUTO_APPROVAL_UNSOLD IN VARCHAR2,
p_CIR_AUTO_PHYSICAL_UNSOLD IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INCT IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INSFEE IN VARCHAR2,
p_CIR_UNSOLD_ON_RECEIVED_DT IN VARCHAR2,
p_AGENCY_UNBLOCK_APROV IN VARCHAR2,
p_UNBLOCK_APROV_OUT_LMT IN VARCHAR2,
p_CIR_BILL_PUBLWISE IN VARCHAR2,
p_paging         IN VARCHAR2,
p_print          IN VARCHAR2,
p_allowpage      IN VARCHAR2,
p_agency_req     IN VARCHAR2,
p_region_req     IN VARCHAR2


)AS
BEGIN
UPDATE LOGIN SET "date_format"=dateformat, "Autogenerate"=code,"curr_code"=curr WHERE "COM_CODE"=compcode;
COMMIT;
        UPDATE PREFERRENCES SET  "autogenerated"=code,
"currency_code"=curr ,
"rate_gr_code"=RATECODE11,
"date_format"=dateformat,"solo"=solo,"breakup"=breakup,
"blackwhitecode"=bwcode,"rostatus"=rostatus,"File_name"=filename,"Tfn"=tfn,
"Insert_breakup"=insertbreak,"Premium_type"=prem,"Deal_type"=dealtype  ,
 "prefix"=pre, "suffix"=suff, "financestatus"=financestatus , "voucherst"=voucherst,
 "Ad_category"=adcode ,"Ro_datetime"=rodatetime ,"Space_area"=spacearea,"Vat"=vat,
 "Booking_status"=bookstat,"Cio_id"=cio_id,"Receipt_no"=receipt_no,"uom_code"=uom,
 "Bgcolor_publication"=bgcolor ,"chkfor_valid_pubdates"=validdate, "Agency_ratecode"=agencyratecode,
  "audit"=AUDIT1,"book_insert_date"=book_insert_date,"agencycomm"=agencycomm,
  "rate_audit"=rateaudit,"bill_audit"=billaudit,"billtype"=bill_type,"invoice_no"=invoice_no1,
  "copy_booking"=copybooking,"RATE_COMPANY_AGENCY"=ratecompany, "ADDITIONAL_AGENCY_COMM"=addagenycomm ,
  "AGENCY_RETAINER_COMM"=agencycommlinkretainer,"SUBEDITIONRATE"=subeditionr,
  "CLS_BILLTYPE"=classifiedbilltype,"DIS_BILLTYPE"=displaybilltype,"BILLING_FORMAT"=billformat,
  "RATE_CHECK"=ratechk,"ALL_PACKAGE"=allpkg,"DAYRATE"=dayrate1,"SCHEME_TYPE"=schemetype,"DISP_CLSBILL"=PIncludeclassi   ,
  "CASH_RECEIPT_BILL"=v_cash_receipt, "BILL_ORDERWSLAST"=v_bill_orderwiselast, "FLOOR_CHK"=v_floor_chk ,
  "UNSOLD_ENTRY_FLAG"=Unsoldflag ,"SUPPLY_STOP_PERCENTAGE"=Supplystopper,"ROKEYCHECK"=drpRokeychk ,
  "AGENCYCOMM_SEQ_COM"=Agencycomm_seq ,"CREDIT_RECIPT"=creditreciept,"DISP_CASHBILL"=cashindisplay,
  "CLA_CASHBILL"=cashinclassified,"RATE_AUDIT_PREF"=v_rate_audit_pref,"BARCODING_ALLOWED"=v_barcoding_allow_pref,
  "FMG_BILL_DIS" =v_fmgbills, "BILL_DISP_CASHBILL"=v_billed_cashdis , "BILL_CLA_CASHBILL"=v_billed_cashcls,"BACKDATERECEIPT"=v_drpbackdate,"DOCKIT_BOOKING"=dockitbooking,"Allowed_old_date"=allowprevbooking,"ROWISE_CASHBOOKING"=ro_wisecashbill,"CUTOFFTIME"=chkval,"APPROVAL"=approval1,"BACK_DAYS"=pckstatus ,CASH_DISCOUNT=cash_amt,CASH_DISCOUNTTYPE=cash_disc,SEPRATE_CASHIER=seperate_cashier1,
   CIR_MANY_TIME_POSTING=mantimepost, CIR_BACKDAYS_POSTING=bkdaypost, CIR_MAX_RETURN_ALLOW=maxterutn, CIR_RETURN_LIMIT_ALLOW=cir_return, CIR_NO_OF_CHQBOUNCE=noofchkbounc, CIR_DAYS_CHQBOUNCE=noofdaychkrec, CIR_RETURN_DAYS=retday, CIR_SUP_ORDER_LIMIT=chngsuppord, DISP_BILLING_CRITERIA=disp_bill, CLSD_BILLING_CRITERIA=clas_bill,MAX_PUBLISHDAYS=max_publishday,BILLNO_PERIODICITY=p_billno_period,
   SPECIALDISC_TRANS_EDIT=spl_trans_edit, SHARING_TRANS=spl_dis_trans_editable, MULTIPACKAGE_SEL_TRANS=mul_pac_sel_trans,SCHEME_MINWORD=shmon_minword, TRADE_SPLCHARGE=tradon_spcrg,RATE_AUTHORIZATION=rateauth
  ,F2_RECORD=f2day,PUBLISHAD_EDIT_RATEAUDIT=rateauditmodify,BINDREVENUE_CENTER=bindrevenuecenter,  
  FA_LEDGER_ALLOW=p_led_allow ,CLEARANCE_TYPE_ALLOW=p_clear_allow,REPEAT_DAY_TYPE=repeatday,PREMIUM_EDIT=premiumedit,
BILL_GENERATION_PRIOR=P_BILL_GENERATION,PUBLICATION_HO=P_PUBLICATION_CENTER,SPLDISC_ALLOWPREM=P_allow_discount_prem,

BILL_SCHEME=P_SCHEME_BILLING,ALLOWED_PDC_DAYS_RECEIPT=P_ALLOW_PDC ,AD_TYPE_MANUL_BILL=PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=RO_OUTSTAND_P,GENRATE_CIR_AGCD=genrate_agency_code,DISP_AUDITBKG=p_dispauditbk,CIR_DIS_AUTO_POSTING=p_aotosupply,RELAUTHREQON=p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=p_CIR_UNSOLD_ON_RECEIVED_DT,
AGENCY_UNBLOCK_APPROVAL=p_AGENCY_UNBLOCK_APROV,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=p_UNBLOCK_APROV_OUT_LMT,CIR_BILL_PUBLWISE=p_CIR_BILL_PUBLWISE,
RECORDS_ON_PAGE = p_paging,RECORDS_ON_PRINT = p_print,HEADER_ON_PAGE = p_allowpage,AGENCY_REQUIRED = p_agency_req,REGION_REQUIRED = p_region_req

  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/
/*******************************************************************/


CREATE OR REPLACE PACKAGE Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/




CREATE OR REPLACE PACKAGE BODY Currbindpreferpgld
IS
   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
         SELECT "date_format", "autogenerated", "currency_code",
                "rate_gr_code", "solo", "breakup", "blackwhitecode",
                "rostatus", "File_name", "Tfn", "Insert_breakup", "prefix",
                "suffix", "financestatus", "voucherst", "Ad_category",
                "Ro_datetime", "Vat", "Booking_status", "Cio_id",
                "Receipt_no","uom_code","Bgcolor_publication","chkfor_valid_pubdates","Agency_ratecode","audit","book_insert_date","agencycomm",
                "rate_audit","bill_audit","billtype","Premium_type","copy_booking","RATE_COMPANY_AGENCY","ADDITIONAL_AGENCY_COMM","AGENCY_RETAINER_COMM","SUBEDITIONRATE",CLS_BILLTYPE,DIS_BILLTYPE,
                "BILLING_FORMAT","RATE_CHECK","ALL_PACKAGE",dayrate,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,
                ROKEYCHECK, AGENCYCOMM_SEQ_COM, CREDIT_RECIPT,  DISP_CASHBILL, CLA_CASHBILL,
                RATE_AUDIT_PREF,BARCODING_ALLOWED, FMG_BILL_DIS,BILL_DISP_CASHBILL, BILL_CLA_CASHBILL,BACKDATERECEIPT,ROWISE_CASHBOOKING,CUTOFFTIME,DOCKIT_BOOKING,APPROVAL,BACK_DAYS,CASH_DISCOUNT,CASH_DISCOUNTTYPE,"Allowed_old_date",SEPRATE_CASHIER,
                CIR_MANY_TIME_POSTING, CIR_BACKDAYS_POSTING, CIR_MAX_RETURN_ALLOW, CIR_RETURN_LIMIT_ALLOW, CIR_NO_OF_CHQBOUNCE, CIR_DAYS_CHQBOUNCE, CIR_RETURN_DAYS, CIR_SUP_ORDER_LIMIT, DISP_BILLING_CRITERIA, CLSD_BILLING_CRITERIA,MAX_PUBLISHDAYS,
                BILLNO_PERIODICITY, SPECIALDISC_TRANS_EDIT, SHARING_TRANS, MULTIPACKAGE_SEL_TRANS,SCHEME_MINWORD, TRADE_SPLCHARGE,RATE_AUTHORIZATION,
           F2_RECORD,PUBLISHAD_EDIT_RATEAUDIT,BINDREVENUE_CENTER, FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,REPEAT_DAY_TYPE,PREMIUM_EDIT,
           
           BILL_GENERATION_PRIOR,PUBLICATION_HO,SPLDISC_ALLOWPREM,BILL_SCHEME,ALLOWED_PDC_DAYS_RECEIPT,
           AD_TYPE_MANUL_BILL,OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD,DISP_AUDITBKG,CIR_DIS_AUTO_POSTING,RELAUTHREQON,
        CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,
        AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE ,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED  
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/



/*================================21/dec/2011=======  ISSUE 0005951 ==============================*/

/*======================================= ISSUE 0005970 (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE PACKAGE Executebookingdisp
IS
  TYPE T_Accounts_Cursor IS REF CURSOR;
  PROCEDURE executebookingdisp_p(
  compcode IN VARCHAR2,
  ciobookid IN VARCHAR2,
  docno IN VARCHAR2:=NULL,
  keyno IN VARCHAR2:=NULL,
  rono IN VARCHAR2:=NULL,
  agencycode IN VARCHAR2:=NULL,
  client IN VARCHAR2:=NULL,
  booking IN VARCHAR2,dateformat IN VARCHAR2,
  revenue in varchar2,
  P_Accounts  OUT  T_Accounts_Cursor,P_Accounts1  OUT  T_Accounts_Cursor,P_Accounts2  OUT  T_Accounts_Cursor,
  P_Accounts3  OUT  T_Accounts_Cursor);
END Executebookingdisp ;
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
                LOCALGROSSAMT,LOCALBILLAMT,PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,REVISE_DATE
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
                     "branch",(select "Branch_Name" from branch_mst where "Branch_Code"="branch") as "BRANCH_NAME",
                     "booked_by", "cio_booking_id", "prev_booking", "applied_by","audit", "RO_No",
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
                 and "Comp_Code"=upper(compcode) and SYSDATE between "Eff_from_Date" and "Eff_Till_Date" AND ROWNUM<=1 ) as COMM_RATE,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT, NVL(LOCALGROSSAMT,"Gross_amount") as LOCALGROSSAMT, NVL(LOCALBILLAMT,"Bill_amount") as LOCALBILLAMT,
                 CASE dateformat
                         WHEN 'mm/dd/yyyy' THEN TO_CHAR("REVISE_DATE",'mm/dd/yyyy')
                         WHEN 'dd/mm/yyyy' THEN TO_CHAR("REVISE_DATE",'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd' THEN TO_CHAR("REVISE_DATE",'yyyy/mm/dd')  END AS "REVISE_DATE"
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
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
cur_convrate varchar2,
p_revisedate IN       DATE
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
cur_convrate varchar2,
p_revisedate IN       DATE
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
PACKAGE_TYPE=chkadon_p, AD_REFID=refid_p,RECEIPT_CURRENCY=rcpt_currency,CONV_CURR_RATE=cur_convrate,REVISE_DATE=p_revisedate
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
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
p_revisedate IN       DATE,
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
p_revisedate IN       DATE,
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
                    LOCALGROSSAMT, LOCALBILLAMT,PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,
                    REVISE_DATE
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
                    AGREEDAMT_ACTIVE,grossamtlocal_p,billamtlocal_p,chkadon_p,refid_p,rcpt_currency,cur_convrate,
                    p_revisedate);
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
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
 INSERT INTO TBL_BOOKING_MAST("date_time", "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by", "audit", "RO_No", "RO_Date", "Caption", "bill_status", "ro_status", "Agency_code", "Agency_address", "Client_code", "Client_address", "Agency_sub_code", "Dockit_no", "Executive_code", "Executive_zone", "Product_code", "Brand_code", "Key_no", "Bill_remarks", "Print_remark", "Package_code", "No_of_insertion", "Insertion_date", "Repeating_day", "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code", "Color_code", "Uom_code", "Page_position_code", "Page_type_code", "Page_no", "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code", "Scheme_type_code", "Currency_code", "Agrred_rate", "Agreed_amount", "Special_discount", "Space_discount", "Special_charges", "Agency_status", "Agency_type", "Agency_pay", "Agency_credit", "Total_area", "Card_rate", "Card_amount", "Discount", "Discount_per", "Bill_cycle", "Revenue_center", "Bill_pay", "Bill_height", "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc", "Agency_out", "Box_code", "Box_no", "Box_agency", "Box_client", "Box_address", "Comp_code", "Userid", "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad", "Campaign", "Bill_amount", "Page_prem", "Page_amount", "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", "Bill_area", "Special_disc_per", "Space_disc_per", "Paid_ins", "Contract_rate", "Deviation", "Variant_code", "Contract_name", "Contract_type", "Card_name", "Card_type", "Card_month", "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", "Bullet_code", "Bullet_premium", "Material_status", "Receipt_date", "prev_cioid", "prev_receipt", "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom", "SAPID", "RETAINER", "ADD_AGENCY_COMM", "AUDIT_COMMENT", "MOBILENO", "ADD_AGENCY_COMM_AMT", "RETAINER_COMM", "RETAINER_COMM_AMT", "CASH_RECIEVED", "CONT_GROSS", "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION", "CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER", "RODOCSTATUS",CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID,RECEIPT_CURRENCY, CONV_CURR_RATE,REVISE_DATE) 
SELECT DATE_TIME, BRANCH, BOOKED_BY, CIO_BOOKING_ID, PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO, RO_DATE, CAPTION, BILL_STATUS, RO_STATUS, AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE, CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO, EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE, BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK, PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE, REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE, AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE, PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO, AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH, RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE, AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT, SPACE_DISCOUNT, SPECIAL_CHARGES, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY, AGENCY_CREDIT, TOTAL_AREA, CARD_RATE, CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE, REVENUE_CENTER, BILL_PAY, BILL_HEIGHT, BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD, TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO, BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS, COMP_CODE, USERID, CREATION_DATETIME, BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN, BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER, GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN, BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER, PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE, CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME, CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER, RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, BG_COLOR, BULLET_CODE, BULLET_PREMIUM, MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID, PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT, COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR, LOGO_UOM, SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO, ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS, CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, RODOCSTATUS,CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK, DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,REVISE_DATE FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=cioid;

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
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE ADB_CHKAG_RATEREVISE
(
p_compcode  in varchar2,
p_agcode  in varchar2,
extra1  in varchar2,
extra2  in varchar2,
p_accounts   OUT   cur_type_new1.cursor_type
)
as
BEGIN
OPEN p_accounts FOR
SELECT RATE_REVISE FROM AGENCY_MAST WHERE "Comp_Code"=p_compcode AND "code_subcode"=p_agcode;

END;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE ADB_FETCHPERMISSION
(
p_compcode  in varchar2,
p_userid  in varchar2,
extra1  in varchar2,
extra2  in varchar2,
p_accounts   OUT   cur_type_new1.cursor_type
)
as
BEGIN
OPEN p_accounts FOR
SELECT PERMISSION_DESC FROM USERPERMISSION WHERE USERID=p_userid AND  COMM_CODE=p_compcode;

END;
/
/******************/




CREATE OR REPLACE PACKAGE Wesp_Updatedate
IS
PROCEDURE      Wesp_Updatedate_p(
compcode IN VARCHAR2,
userid IN VARCHAR2,
dateformat IN VARCHAR2,
code IN VARCHAR2,
curr IN VARCHAR2,
RATECODE11 IN VARCHAR2,
solo  IN VARCHAR2,
breakup VARCHAR2,
bwcode IN VARCHAR2,
rostatus IN VARCHAR2,
filename IN VARCHAR2,
tfn IN NUMBER,
insertbreak IN VARCHAR2,
prem IN VARCHAR2,
dealtype IN VARCHAR2,
pre IN VARCHAR2,
suff IN VARCHAR2,
financestatus IN  VARCHAR2,
voucherst IN VARCHAR2,
adcode IN VARCHAR2,
rodatetime IN VARCHAR2,
spacearea IN VARCHAR2,
vat IN VARCHAR2,
bookstat IN VARCHAR2,
cio_id IN VARCHAR2,
receipt_no IN VARCHAR2,
uom IN VARCHAR2,
bgcolor IN VARCHAR2,
validdate IN VARCHAR2,
agencyratecode IN VARCHAR2,
AUDIT1 IN VARCHAR2,
book_insert_date IN VARCHAR2,
agencycomm IN VARCHAR2,
rateaudit IN VARCHAR2,
billaudit IN VARCHAR2,
bill_type IN VARCHAR2,
invoice_no1 IN VARCHAR2,
copybooking IN VARCHAR2,
ratecompany IN VARCHAR2,
addagenycomm IN VARCHAR2,
agencycommlinkretainer IN VARCHAR2,
subeditionr IN VARCHAR2,
displaybilltype IN VARCHAR2,
classifiedbilltype IN VARCHAR2,
billformat IN VARCHAR2,
ratechk IN VARCHAR2,
allpkg IN VARCHAR2,
dayrate1 in varchar2,
schemetype in varchar2,
PIncludeclassi in varchar2,
receiptformat IN VARCHAR2,
v_cash_receipt in varchar2,
v_bill_orderwiselast in varchar2,
v_floor_chk in varchar2,
Unsoldflag in varchar2,
Supplystopper in  number,
drpRokeychk in varchar2,
Agencycomm_seq in varchar2,
creditreciept in varchar,
cashindisplay IN VARCHAR,
cashinclassified IN VARCHAR,
v_rate_audit_pref in varchar,
v_barcoding_allow_pref in varchar2,
v_fmgbills IN VARCHAR2,
v_billed_cashdis in varchar2,
v_billed_cashcls in varchar,
v_drpbackdate in varchar,
dockitbooking in varchar2,
allowprevbooking in varchar2,
ro_wisecashbill in varchar2,
chkval in varchar2,
approval1 in varchar2,
pckstatus in varchar2,
cash_disc in varchar2,
cash_amt in varchar2,
seperate_cashier1 in varchar2,
disp_bill in varchar2,
clas_bill in varchar2,
mantimepost in varchar2,
bkdaypost in number,
maxterutn in number,
cir_return in varchar2,
noofchkbounc in number,
noofdaychkrec in number,
retday in number,
chngsuppord in number,
max_publishday in number,
p_billno_period in varchar,
spl_trans_edit in varchar2,
spl_dis_trans_editable in varchar2,
mul_pac_sel_trans in varchar2,
shmon_minword in varchar2,
tradon_spcrg in varchar2,
rateauth     in varchar2,
f2day in number,
rateauditmodify in varchar,
bindrevenuecenter in varchar,
p_led_allow in varchar,
p_clear_allow in varchar,
repeatday in varchar,
premiumedit in varchar,
P_BILL_GENERATION in varchar,
P_PUBLICATION_CENTER in varchar,
P_allow_discount_prem IN VARCHAR,
P_SCHEME_BILLING in varchar,
P_ALLOW_PDC in varchar,
PAD_TYPE_FOR_MANUL_BILL in varchar,
RO_OUTSTAND_P IN VARCHAR2,
genrate_agency_code IN VARCHAR2,
p_dispauditbk IN VARCHAR2,
p_aotosupply  IN VARCHAR2,
p_Authorization IN VARCHAR2,
p_CIR_AUTO_APPROVAL_UNSOLD IN VARCHAR2,
p_CIR_AUTO_PHYSICAL_UNSOLD IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INCT IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INSFEE IN VARCHAR2,
p_CIR_UNSOLD_ON_RECEIVED_DT IN VARCHAR2,
p_AGENCY_UNBLOCK_APROV IN VARCHAR2,
p_UNBLOCK_APROV_OUT_LMT IN VARCHAR2,
p_CIR_BILL_PUBLWISE IN VARCHAR2,
p_paging         IN VARCHAR2,
p_print          IN VARCHAR2,
p_allowpage      IN VARCHAR2,
p_agency_req     IN VARCHAR2,
p_region_req     IN VARCHAR2,
p_ALLOW_FOLLOW_DT_BOOOK     IN VARCHAR2

);
END      Wesp_Updatedate;
/





CREATE OR REPLACE PACKAGE BODY Wesp_Updatedate IS
PROCEDURE      Wesp_Updatedate_p(
compcode IN VARCHAR2,
userid IN VARCHAR2,
dateformat IN VARCHAR2,
code IN VARCHAR2,
curr IN VARCHAR2,
RATECODE11 IN VARCHAR2,
solo  IN VARCHAR2,
breakup VARCHAR2,
bwcode IN VARCHAR2,
rostatus IN VARCHAR2,
filename IN VARCHAR2,
tfn IN NUMBER,
insertbreak IN VARCHAR2,
prem IN VARCHAR2,
dealtype IN VARCHAR2,
pre IN VARCHAR2,
suff IN VARCHAR2,
financestatus IN  VARCHAR2,
voucherst IN VARCHAR2,
adcode IN VARCHAR2,
rodatetime IN VARCHAR2,
spacearea IN VARCHAR2,
vat IN VARCHAR2,
bookstat IN VARCHAR2,
cio_id IN VARCHAR2,
receipt_no IN VARCHAR2,
uom IN VARCHAR2,
bgcolor IN VARCHAR2,
validdate IN VARCHAR2,
agencyratecode IN VARCHAR2,
AUDIT1 IN VARCHAR2,
book_insert_date IN VARCHAR2,
agencycomm IN VARCHAR2,
rateaudit IN VARCHAR2,
billaudit IN VARCHAR2,
bill_type IN VARCHAR2,
invoice_no1 IN VARCHAR2,
copybooking IN VARCHAR2,
ratecompany IN VARCHAR2,
addagenycomm IN VARCHAR2,
agencycommlinkretainer IN VARCHAR2,
subeditionr IN VARCHAR2,
displaybilltype IN VARCHAR2,
classifiedbilltype IN VARCHAR2,
billformat IN VARCHAR2,
ratechk IN VARCHAR2,
allpkg IN VARCHAR2,
dayrate1 in varchar2,
schemetype in varchar2,
PIncludeclassi in varchar2,
receiptformat IN VARCHAR2,
v_cash_receipt in varchar2,
v_bill_orderwiselast in varchar2,
v_floor_chk in varchar2,
Unsoldflag in varchar2,
Supplystopper in  number,
drpRokeychk in varchar2,
Agencycomm_seq in varchar2,
creditreciept in varchar,
cashindisplay IN VARCHAR,
cashinclassified IN VARCHAR,
v_rate_audit_pref in varchar,
v_barcoding_allow_pref in varchar2,
v_fmgbills IN VARCHAR2,
v_billed_cashdis in varchar2,
v_billed_cashcls in varchar,
v_drpbackdate in varchar,
dockitbooking in varchar2,
allowprevbooking in varchar2,
ro_wisecashbill in varchar2,
chkval in varchar2,
approval1 in varchar2,
pckstatus in varchar2,
cash_disc in varchar2,
cash_amt in varchar2,
seperate_cashier1 in varchar2,
disp_bill in varchar2,
clas_bill in varchar2,
mantimepost in varchar2,
bkdaypost in number,
maxterutn in number,
cir_return in varchar2,
noofchkbounc in number,
noofdaychkrec in number,
retday in number,
chngsuppord in number,
max_publishday in number,
p_billno_period in varchar,
spl_trans_edit in varchar2,
spl_dis_trans_editable in varchar2,
mul_pac_sel_trans in varchar2,
shmon_minword in varchar2,
tradon_spcrg in varchar2,
rateauth     in varchar2,
f2day in number,
rateauditmodify in varchar,
bindrevenuecenter in varchar,
p_led_allow in varchar,
p_clear_allow in varchar,
repeatday in varchar,
premiumedit in varchar,
P_BILL_GENERATION in varchar,
P_PUBLICATION_CENTER in varchar,
P_allow_discount_prem IN VARCHAR,
P_SCHEME_BILLING in varchar,
P_ALLOW_PDC in varchar,
PAD_TYPE_FOR_MANUL_BILL in varchar,
RO_OUTSTAND_P IN VARCHAR2,
genrate_agency_code IN VARCHAR2,
p_dispauditbk IN VARCHAR2,
p_aotosupply  IN VARCHAR2,
p_Authorization IN VARCHAR2,
p_CIR_AUTO_APPROVAL_UNSOLD IN VARCHAR2,
p_CIR_AUTO_PHYSICAL_UNSOLD IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INCT IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INSFEE IN VARCHAR2,
p_CIR_UNSOLD_ON_RECEIVED_DT IN VARCHAR2,
p_AGENCY_UNBLOCK_APROV IN VARCHAR2,
p_UNBLOCK_APROV_OUT_LMT IN VARCHAR2,
p_CIR_BILL_PUBLWISE IN VARCHAR2,
p_paging         IN VARCHAR2,
p_print          IN VARCHAR2,
p_allowpage      IN VARCHAR2,
p_agency_req     IN VARCHAR2,
p_region_req     IN VARCHAR2,
p_ALLOW_FOLLOW_DT_BOOOK     IN VARCHAR2


)AS
BEGIN
UPDATE LOGIN SET "date_format"=dateformat, "Autogenerate"=code,"curr_code"=curr WHERE "COM_CODE"=compcode;
COMMIT;
        UPDATE PREFERRENCES SET  "autogenerated"=code,
"currency_code"=curr ,
"rate_gr_code"=RATECODE11,
"date_format"=dateformat,"solo"=solo,"breakup"=breakup,
"blackwhitecode"=bwcode,"rostatus"=rostatus,"File_name"=filename,"Tfn"=tfn,
"Insert_breakup"=insertbreak,"Premium_type"=prem,"Deal_type"=dealtype  ,
 "prefix"=pre, "suffix"=suff, "financestatus"=financestatus , "voucherst"=voucherst,
 "Ad_category"=adcode ,"Ro_datetime"=rodatetime ,"Space_area"=spacearea,"Vat"=vat,
 "Booking_status"=bookstat,"Cio_id"=cio_id,"Receipt_no"=receipt_no,"uom_code"=uom,
 "Bgcolor_publication"=bgcolor ,"chkfor_valid_pubdates"=validdate, "Agency_ratecode"=agencyratecode,
  "audit"=AUDIT1,"book_insert_date"=book_insert_date,"agencycomm"=agencycomm,
  "rate_audit"=rateaudit,"bill_audit"=billaudit,"billtype"=bill_type,"invoice_no"=invoice_no1,
  "copy_booking"=copybooking,"RATE_COMPANY_AGENCY"=ratecompany, "ADDITIONAL_AGENCY_COMM"=addagenycomm ,
  "AGENCY_RETAINER_COMM"=agencycommlinkretainer,"SUBEDITIONRATE"=subeditionr,
  "CLS_BILLTYPE"=classifiedbilltype,"DIS_BILLTYPE"=displaybilltype,"BILLING_FORMAT"=billformat,
  "RATE_CHECK"=ratechk,"ALL_PACKAGE"=allpkg,"DAYRATE"=dayrate1,"SCHEME_TYPE"=schemetype,"DISP_CLSBILL"=PIncludeclassi   ,
  "CASH_RECEIPT_BILL"=v_cash_receipt, "BILL_ORDERWSLAST"=v_bill_orderwiselast, "FLOOR_CHK"=v_floor_chk ,
  "UNSOLD_ENTRY_FLAG"=Unsoldflag ,"SUPPLY_STOP_PERCENTAGE"=Supplystopper,"ROKEYCHECK"=drpRokeychk ,
  "AGENCYCOMM_SEQ_COM"=Agencycomm_seq ,"CREDIT_RECIPT"=creditreciept,"DISP_CASHBILL"=cashindisplay,
  "CLA_CASHBILL"=cashinclassified,"RATE_AUDIT_PREF"=v_rate_audit_pref,"BARCODING_ALLOWED"=v_barcoding_allow_pref,
  "FMG_BILL_DIS" =v_fmgbills, "BILL_DISP_CASHBILL"=v_billed_cashdis , "BILL_CLA_CASHBILL"=v_billed_cashcls,"BACKDATERECEIPT"=v_drpbackdate,"DOCKIT_BOOKING"=dockitbooking,"Allowed_old_date"=allowprevbooking,"ROWISE_CASHBOOKING"=ro_wisecashbill,"CUTOFFTIME"=chkval,"APPROVAL"=approval1,"BACK_DAYS"=pckstatus ,CASH_DISCOUNT=cash_amt,CASH_DISCOUNTTYPE=cash_disc,SEPRATE_CASHIER=seperate_cashier1,
   CIR_MANY_TIME_POSTING=mantimepost, CIR_BACKDAYS_POSTING=bkdaypost, CIR_MAX_RETURN_ALLOW=maxterutn, CIR_RETURN_LIMIT_ALLOW=cir_return, CIR_NO_OF_CHQBOUNCE=noofchkbounc, CIR_DAYS_CHQBOUNCE=noofdaychkrec, CIR_RETURN_DAYS=retday, CIR_SUP_ORDER_LIMIT=chngsuppord, DISP_BILLING_CRITERIA=disp_bill, CLSD_BILLING_CRITERIA=clas_bill,MAX_PUBLISHDAYS=max_publishday,BILLNO_PERIODICITY=p_billno_period,
   SPECIALDISC_TRANS_EDIT=spl_trans_edit, SHARING_TRANS=spl_dis_trans_editable, MULTIPACKAGE_SEL_TRANS=mul_pac_sel_trans,SCHEME_MINWORD=shmon_minword, TRADE_SPLCHARGE=tradon_spcrg,RATE_AUTHORIZATION=rateauth
  ,F2_RECORD=f2day,PUBLISHAD_EDIT_RATEAUDIT=rateauditmodify,BINDREVENUE_CENTER=bindrevenuecenter,  
  FA_LEDGER_ALLOW=p_led_allow ,CLEARANCE_TYPE_ALLOW=p_clear_allow,REPEAT_DAY_TYPE=repeatday,PREMIUM_EDIT=premiumedit,
BILL_GENERATION_PRIOR=P_BILL_GENERATION,PUBLICATION_HO=P_PUBLICATION_CENTER,SPLDISC_ALLOWPREM=P_allow_discount_prem,

BILL_SCHEME=P_SCHEME_BILLING,ALLOWED_PDC_DAYS_RECEIPT=P_ALLOW_PDC ,AD_TYPE_MANUL_BILL=PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=RO_OUTSTAND_P,GENRATE_CIR_AGCD=genrate_agency_code,DISP_AUDITBKG=p_dispauditbk,CIR_DIS_AUTO_POSTING=p_aotosupply,RELAUTHREQON=p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=p_CIR_UNSOLD_ON_RECEIVED_DT,
AGENCY_UNBLOCK_APPROVAL=p_AGENCY_UNBLOCK_APROV,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=p_UNBLOCK_APROV_OUT_LMT,CIR_BILL_PUBLWISE=p_CIR_BILL_PUBLWISE,
RECORDS_ON_PAGE = p_paging,RECORDS_ON_PRINT = p_print,HEADER_ON_PAGE = p_allowpage,AGENCY_REQUIRED = p_agency_req,REGION_REQUIRED = p_region_req,ALLOW_FOLLOW_DT_BOOOK=p_ALLOW_FOLLOW_DT_BOOOK

  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/
/**************************************************************************/







CREATE OR REPLACE PACKAGE Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/


CREATE OR REPLACE PACKAGE BODY Currbindpreferpgld
IS
   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
         SELECT "date_format", "autogenerated", "currency_code",
                "rate_gr_code", "solo", "breakup", "blackwhitecode",
                "rostatus", "File_name", "Tfn", "Insert_breakup", "prefix",
                "suffix", "financestatus", "voucherst", "Ad_category",
                "Ro_datetime", "Vat", "Booking_status", "Cio_id",
                "Receipt_no","uom_code","Bgcolor_publication","chkfor_valid_pubdates","Agency_ratecode","audit","book_insert_date","agencycomm",
                "rate_audit","bill_audit","billtype","Premium_type","copy_booking","RATE_COMPANY_AGENCY","ADDITIONAL_AGENCY_COMM","AGENCY_RETAINER_COMM","SUBEDITIONRATE",CLS_BILLTYPE,DIS_BILLTYPE,
                "BILLING_FORMAT","RATE_CHECK","ALL_PACKAGE",dayrate,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,
                ROKEYCHECK, AGENCYCOMM_SEQ_COM, CREDIT_RECIPT,  DISP_CASHBILL, CLA_CASHBILL,
                RATE_AUDIT_PREF,BARCODING_ALLOWED, FMG_BILL_DIS,BILL_DISP_CASHBILL, BILL_CLA_CASHBILL,BACKDATERECEIPT,ROWISE_CASHBOOKING,CUTOFFTIME,DOCKIT_BOOKING,APPROVAL,BACK_DAYS,CASH_DISCOUNT,CASH_DISCOUNTTYPE,"Allowed_old_date",SEPRATE_CASHIER,
                CIR_MANY_TIME_POSTING, CIR_BACKDAYS_POSTING, CIR_MAX_RETURN_ALLOW, CIR_RETURN_LIMIT_ALLOW, CIR_NO_OF_CHQBOUNCE, CIR_DAYS_CHQBOUNCE, CIR_RETURN_DAYS, CIR_SUP_ORDER_LIMIT, DISP_BILLING_CRITERIA, CLSD_BILLING_CRITERIA,MAX_PUBLISHDAYS,
                BILLNO_PERIODICITY, SPECIALDISC_TRANS_EDIT, SHARING_TRANS, MULTIPACKAGE_SEL_TRANS,SCHEME_MINWORD, TRADE_SPLCHARGE,RATE_AUTHORIZATION,
           F2_RECORD,PUBLISHAD_EDIT_RATEAUDIT,BINDREVENUE_CENTER, FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,REPEAT_DAY_TYPE,PREMIUM_EDIT,
           
           BILL_GENERATION_PRIOR,PUBLICATION_HO,SPLDISC_ALLOWPREM,BILL_SCHEME,ALLOWED_PDC_DAYS_RECEIPT,
           AD_TYPE_MANUL_BILL,OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD,DISP_AUDITBKG,CIR_DIS_AUTO_POSTING,RELAUTHREQON,
        CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,
        AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE ,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK  
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/



/*======================================= End of ISSUE 0005970 (Kuldeep Bhati) ==============================*/



/**********************mimoh****************26/12/2011************/
DROP PACKAGE HT18JULY.BOOK_ADVCATEGORY;

CREATE OR REPLACE PACKAGE HT18JULY.book_advcategory Is
Type T_Accounts_Cursor Is Ref Cursor;
Procedure  book_advcategory_P(
compcode in varchar2,
booking  in varchar2,
center  in varchar2:=null,
p_Accounts Out T_Accounts_Cursor,
p_Accounts1 Out T_Accounts_Cursor,
p_Accounts2 Out T_Accounts_Cursor);

End book_advcategory ;
/





CREATE OR REPLACE PACKAGE BODY book_advcategory is

Procedure  book_advcategory_P(
compcode in varchar2,
booking  in varchar2,
center  in varchar2:=null,
p_Accounts Out T_Accounts_Cursor,
p_Accounts1 Out T_Accounts_Cursor,
p_Accounts2 Out T_Accounts_Cursor )as
begin


--if(booking<>'adtype') then

open p_Accounts for
select "Adv_Cat_Code", "Adv_Cat_Name" from adv_cat_mast where "Comp_Code"=compcode and (STATUS='1' or STATUS is null)   and "Adv_Type"=booking order by "Adv_Cat_Name" ;

open p_Accounts1 for
select "Uom_Code","Uom_Name" from uom_mast where "Comp_Code"=compcode and "Ad_Type"=booking order by "Uom_Name";

    if(center is not null) then
        if(booking is not null) then
            open  p_Accounts2 for
            select "Combin_Code","Package_Name",("Combin_Code"||'@'||"Combin_Desc") as "pck_code" from combin_mast where "Comp_Code"=compcode and "Ad_Type_code"=booking and "pub_center"=center AND "Combin_Code" not in(select PACKAGECODE FROM EDITIONSTATUS WHERE STATUS='I') ORDER BY "Package_Name";
        else
            open  p_Accounts2 for
            select "Combin_Code","Package_Name",("Combin_Code"||'@'||"Combin_Desc") as "pck_code" from combin_mast where "Comp_Code"=compcode and "pub_center"=center AND "Combin_Code" not in(select PACKAGECODE FROM EDITIONSTATUS WHERE STATUS='I') ORDER BY "Package_Name";
        end if;                    
    else
        open  p_Accounts2 for
        select "Combin_Code","Package_Name",("Combin_Code"||'@'||"Combin_Desc") as "pck_code" from combin_mast where "Comp_Code"=compcode and "Ad_Type_code"=booking AND "Combin_Code" not in(select PACKAGECODE FROM EDITIONSTATUS WHERE STATUS='I') ORDER BY "Package_Name";
    end if;        

/*
else
open p_Accounts for
select "Adv_Cat_Code", "Adv_Cat_Name" from adv_cat_mast where "Comp_Code"=compcode;
end if;
*/
end  book_advcategory_p;
end book_advcategory;
/



/************************************************************************/








set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[book_advsubcattyp]
@compcode as varchar(8),
--@userid as varchar(50),
@catcode as varchar(20),
@agencytype as varchar(20)



AS

--select Adv_Type_Code,Adv_Type_Name from adv_type_mast where comp_code=@compcode and  userid=@userid

select Adv_Subcat_Code,Adv_Subcat_Name from adv_subcat_mast where comp_code=@compcode and (STATUS='1' or STATUS is null)  and  adv_cat_code=@catcode

select Comm_Rate from agency_type_mst where comp_code=@compcode and  ad_category=@catcode and agency_type_code=@agencytype


--select distinct Edition_combin_code from combin_mast where comp_code=@compcode and  userid=@userid












/**********************mimoh****************26/12/2011************/
/*======================================= ISSUE 0005966 (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE PACKAGE Websp_Loginemployee IS

TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE Websp_Loginemployee_P (Vusername IN VARCHAR2 ,vpassword IN VARCHAR2 ,vqbc IN VARCHAR2, P_Accounts OUT T_Accounts_Cursor,
P_Accounts1 OUT T_Accounts_Cursor,
P_Accounts2 OUT T_Accounts_Cursor);


END Websp_Loginemployee;
/
CREATE OR REPLACE PACKAGE BODY Websp_Loginemployee
IS

--var a refcursor;
--var b refcursor;
--var c refcursor;
--exec websp_loginemployee.websp_loginemployee_p('bh01','123','',:a,:b,:c);
    PROCEDURE Websp_Loginemployee_P (Vusername IN VARCHAR2 ,vpassword IN VARCHAR2 ,vqbc IN VARCHAR2,
        P_Accounts OUT T_Accounts_Cursor,
        P_Accounts1 OUT T_Accounts_Cursor,
        P_Accounts2 OUT T_Accounts_Cursor)
    AS
        vuserid VARCHAR2(100);
        v_nm varchar2(100);
        COUNT VARCHAR2(100);
    BEGIN
        IF Vqbc IS NULL THEN
        OPEN P_Accounts FOR
        SELECT "username","password","userid","date_format","COM_CODE","Autogenerate","curr_code","comp_name",
        to_date(sysdate)-to_date(CREATION_DATETIME) as "diff",DISCOUNT,FILTER,ROLEID,"retainer_code" AS RETAINER FROM LOGIN
        WHERE "userid"=Vusername  AND "password"=Vpassword and STATUS !='I';

        OPEN P_Accounts1 FOR SELECT "rate_gr_code","autogenerated","currency_code","date_format","solo","No_of_Decimal",
        "breakup","blackwhitecode","uom_code","rostatus","Tfn","Insert_breakup","Premium_type","Deal_type"     ,
        "prefix","suffix","financestatus","voucherst","Ad_category","Ro_datetime","Space_area","Vat","Booking_status","Cio_id","Receipt_no","Bgcolor_publication", "chkfor_valid_pubdates","Agency_ratecode","audit","copy_booking","RATE_COMPANY_AGENCY","SUBEDITIONRATE","ADDITIONAL_AGENCY_COMM","AGENCY_RETAINER_COMM",

        "invoice_no","rate_audit",CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT, RATE_CHECK, ALL_PACKAGE,DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,ROKEYCHECK,
		DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF,        
        FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,DISP_AUDITBKG, CIR_AUTO_PHYSICAL_UNSOLD,ALLOW_FOLLOW_DT_BOOOK
        FROM PREFERRENCES WHERE "comp_code"=(SELECT "COM_CODE" FROM LOGIN WHERE "userid"=Vusername AND "password"=Vpassword);
        
        BEGIN
              SELECT "COM_CODE","username" INTO COUNT,v_nm FROM LOGIN WHERE "userid"=vusername AND "password"=vpassword;
              EXCEPTION WHEN NO_DATA_FOUND THEN NULL;
        END;
      
      -- Using Userid,UserNAme & User MAchine ID For Log Purpose
          sec_user.set_userid(vusername);
          sec_user.set_username(v_nm);
          sec_user.set_userip('');
      -- Using Userid,UserNAme & User MAchine ID For Log Purpose     

    OPEN P_Accounts2 FOR
    SELECT "Company_user","Admin" FROM LOGIN WHERE "userid"=Vusername;

ELSE
    OPEN P_Accounts FOR SELECT "username","password","userid","date_format","COM_CODE","Autogenerate","curr_code","comp_name",to_date(sysdate)-to_date(CREATION_DATETIME) as "diff", DISCOUNT,FILTER,ROLEID,"retainer_code" AS RETAINER FROM LOGIN
    WHERE "userid"=Vusername AND "password"=Vpassword AND ("retainer_code"=Vqbc) and STATUS !='I'/* or "retainer_code" in(select BRANCH_CODE from login_branch_mast where BRANCH_CODE =Vqbc and USER_CODE=Vusername and USER_FLAG='Y') )*/ and "Company_user" is null;

OPEN P_Accounts1 FOR SELECT "rate_gr_code","autogenerated","currency_code","date_format","solo","No_of_Decimal",
"breakup","blackwhitecode","uom_code","rostatus","Tfn","Insert_breakup","Premium_type","Deal_type"     ,
"prefix","suffix","financestatus","voucherst","Ad_category","Ro_datetime","Space_area","Vat","Booking_status","Cio_id","Receipt_no","Bgcolor_publication", "chkfor_valid_pubdates","Agency_ratecode","audit","copy_booking","RATE_COMPANY_AGENCY","SUBEDITIONRATE","ADDITIONAL_AGENCY_COMM","AGENCY_RETAINER_COMM",
"invoice_no","rate_audit",CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT, RATE_CHECK, ALL_PACKAGE, DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,ROKEYCHECK,

DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF ,FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,DISP_AUDITBKG,CIR_AUTO_PHYSICAL_UNSOLD,ALLOW_FOLLOW_DT_BOOOK
FROM PREFERRENCES WHERE "comp_code"=(SELECT "COM_CODE" FROM LOGIN WHERE "userid"=Vusername AND "password"=Vpassword);
BEGIN
SELECT "COM_CODE","username" INTO COUNT,v_nm FROM LOGIN WHERE "userid"=vusername AND "password"=vpassword AND "retainer_code"=vqbc;
EXCEPTION WHEN NO_DATA_FOUND THEN NULL;
END;

      -- Using Userid,UserNAme & User MAchine ID For Log Purpose
          sec_user.set_userid(vusername);
          sec_user.set_username(v_nm);
          sec_user.set_userip('');
      -- Using Userid,UserNAme & User MAchine ID For Log Purpose 

OPEN P_Accounts2 FOR
SELECT "Company_user","Admin" FROM LOGIN WHERE "userid"=Vusername;
END IF;



END Websp_Loginemployee_P;

END Websp_Loginemployee;
/

/*======================================= End of ISSUE 0005966 (Kuldeep Bhati) ==============================*/

/***********************mimoh 26dec 2011*********************************0006137****************/


CREATE OR REPLACE PACKAGE Wesp_Updatedate
IS
PROCEDURE      Wesp_Updatedate_p(
compcode IN VARCHAR2,
userid IN VARCHAR2,
dateformat IN VARCHAR2,
code IN VARCHAR2,
curr IN VARCHAR2,
RATECODE11 IN VARCHAR2,
solo  IN VARCHAR2,
breakup VARCHAR2,
bwcode IN VARCHAR2,
rostatus IN VARCHAR2,
filename IN VARCHAR2,
tfn IN NUMBER,
insertbreak IN VARCHAR2,
prem IN VARCHAR2,
dealtype IN VARCHAR2,
pre IN VARCHAR2,
suff IN VARCHAR2,
financestatus IN  VARCHAR2,
voucherst IN VARCHAR2,
adcode IN VARCHAR2,
rodatetime IN VARCHAR2,
spacearea IN VARCHAR2,
vat IN VARCHAR2,
bookstat IN VARCHAR2,
cio_id IN VARCHAR2,
receipt_no IN VARCHAR2,
uom IN VARCHAR2,
bgcolor IN VARCHAR2,
validdate IN VARCHAR2,
agencyratecode IN VARCHAR2,
AUDIT1 IN VARCHAR2,
book_insert_date IN VARCHAR2,
agencycomm IN VARCHAR2,
rateaudit IN VARCHAR2,
billaudit IN VARCHAR2,
bill_type IN VARCHAR2,
invoice_no1 IN VARCHAR2,
copybooking IN VARCHAR2,
ratecompany IN VARCHAR2,
addagenycomm IN VARCHAR2,
agencycommlinkretainer IN VARCHAR2,
subeditionr IN VARCHAR2,
displaybilltype IN VARCHAR2,
classifiedbilltype IN VARCHAR2,
billformat IN VARCHAR2,
ratechk IN VARCHAR2,
allpkg IN VARCHAR2,
dayrate1 in varchar2,
schemetype in varchar2,
PIncludeclassi in varchar2,
receiptformat IN VARCHAR2,
v_cash_receipt in varchar2,
v_bill_orderwiselast in varchar2,
v_floor_chk in varchar2,
Unsoldflag in varchar2,
Supplystopper in  number,
drpRokeychk in varchar2,
Agencycomm_seq in varchar2,
creditreciept in varchar,
cashindisplay IN VARCHAR,
cashinclassified IN VARCHAR,
v_rate_audit_pref in varchar,
v_barcoding_allow_pref in varchar2,
v_fmgbills IN VARCHAR2,
v_billed_cashdis in varchar2,
v_billed_cashcls in varchar,
v_drpbackdate in varchar,
dockitbooking in varchar2,
allowprevbooking in varchar2,
ro_wisecashbill in varchar2,
chkval in varchar2,
approval1 in varchar2,
pckstatus in varchar2,
cash_disc in varchar2,
cash_amt in varchar2,
seperate_cashier1 in varchar2,
disp_bill in varchar2,
clas_bill in varchar2,
mantimepost in varchar2,
bkdaypost in number,
maxterutn in number,
cir_return in varchar2,
noofchkbounc in number,
noofdaychkrec in number,
retday in number,
chngsuppord in number,
max_publishday in number,
p_billno_period in varchar,
spl_trans_edit in varchar2,
spl_dis_trans_editable in varchar2,
mul_pac_sel_trans in varchar2,
shmon_minword in varchar2,
tradon_spcrg in varchar2,
rateauth     in varchar2,
f2day in number,
rateauditmodify in varchar,
bindrevenuecenter in varchar,
p_led_allow in varchar,
p_clear_allow in varchar,
repeatday in varchar,
premiumedit in varchar,
P_BILL_GENERATION in varchar,
P_PUBLICATION_CENTER in varchar,
P_allow_discount_prem IN VARCHAR,
P_SCHEME_BILLING in varchar,
P_ALLOW_PDC in varchar,
PAD_TYPE_FOR_MANUL_BILL in varchar,
RO_OUTSTAND_P IN VARCHAR2,
genrate_agency_code IN VARCHAR2,
p_dispauditbk IN VARCHAR2,
p_aotosupply  IN VARCHAR2,
p_Authorization IN VARCHAR2,
p_CIR_AUTO_APPROVAL_UNSOLD IN VARCHAR2,
p_CIR_AUTO_PHYSICAL_UNSOLD IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INCT IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INSFEE IN VARCHAR2,
p_CIR_UNSOLD_ON_RECEIVED_DT IN VARCHAR2,
p_AGENCY_UNBLOCK_APROV IN VARCHAR2,
p_UNBLOCK_APROV_OUT_LMT IN VARCHAR2,
p_CIR_BILL_PUBLWISE IN VARCHAR2,
p_paging         IN VARCHAR2,
p_print          IN VARCHAR2,
p_allowpage      IN VARCHAR2,
p_agency_req     IN VARCHAR2,
p_region_req     IN VARCHAR2,
p_ALLOW_FOLLOW_DT_BOOOK     IN VARCHAR2,
p_CRM_SUPPLY_TYPE_PAID     IN VARCHAR2,
p_CRM_SUPPLY_TYPE_FREE     IN VARCHAR2

);
END      Wesp_Updatedate;
/





CREATE OR REPLACE PACKAGE BODY Wesp_Updatedate IS
PROCEDURE      Wesp_Updatedate_p(
compcode IN VARCHAR2,
userid IN VARCHAR2,
dateformat IN VARCHAR2,
code IN VARCHAR2,
curr IN VARCHAR2,
RATECODE11 IN VARCHAR2,
solo  IN VARCHAR2,
breakup VARCHAR2,
bwcode IN VARCHAR2,
rostatus IN VARCHAR2,
filename IN VARCHAR2,
tfn IN NUMBER,
insertbreak IN VARCHAR2,
prem IN VARCHAR2,
dealtype IN VARCHAR2,
pre IN VARCHAR2,
suff IN VARCHAR2,
financestatus IN  VARCHAR2,
voucherst IN VARCHAR2,
adcode IN VARCHAR2,
rodatetime IN VARCHAR2,
spacearea IN VARCHAR2,
vat IN VARCHAR2,
bookstat IN VARCHAR2,
cio_id IN VARCHAR2,
receipt_no IN VARCHAR2,
uom IN VARCHAR2,
bgcolor IN VARCHAR2,
validdate IN VARCHAR2,
agencyratecode IN VARCHAR2,
AUDIT1 IN VARCHAR2,
book_insert_date IN VARCHAR2,
agencycomm IN VARCHAR2,
rateaudit IN VARCHAR2,
billaudit IN VARCHAR2,
bill_type IN VARCHAR2,
invoice_no1 IN VARCHAR2,
copybooking IN VARCHAR2,
ratecompany IN VARCHAR2,
addagenycomm IN VARCHAR2,
agencycommlinkretainer IN VARCHAR2,
subeditionr IN VARCHAR2,
displaybilltype IN VARCHAR2,
classifiedbilltype IN VARCHAR2,
billformat IN VARCHAR2,
ratechk IN VARCHAR2,
allpkg IN VARCHAR2,
dayrate1 in varchar2,
schemetype in varchar2,
PIncludeclassi in varchar2,
receiptformat IN VARCHAR2,
v_cash_receipt in varchar2,
v_bill_orderwiselast in varchar2,
v_floor_chk in varchar2,
Unsoldflag in varchar2,
Supplystopper in  number,
drpRokeychk in varchar2,
Agencycomm_seq in varchar2,
creditreciept in varchar,
cashindisplay IN VARCHAR,
cashinclassified IN VARCHAR,
v_rate_audit_pref in varchar,
v_barcoding_allow_pref in varchar2,
v_fmgbills IN VARCHAR2,
v_billed_cashdis in varchar2,
v_billed_cashcls in varchar,
v_drpbackdate in varchar,
dockitbooking in varchar2,
allowprevbooking in varchar2,
ro_wisecashbill in varchar2,
chkval in varchar2,
approval1 in varchar2,
pckstatus in varchar2,
cash_disc in varchar2,
cash_amt in varchar2,
seperate_cashier1 in varchar2,
disp_bill in varchar2,
clas_bill in varchar2,
mantimepost in varchar2,
bkdaypost in number,
maxterutn in number,
cir_return in varchar2,
noofchkbounc in number,
noofdaychkrec in number,
retday in number,
chngsuppord in number,
max_publishday in number,
p_billno_period in varchar,
spl_trans_edit in varchar2,
spl_dis_trans_editable in varchar2,
mul_pac_sel_trans in varchar2,
shmon_minword in varchar2,
tradon_spcrg in varchar2,
rateauth     in varchar2,
f2day in number,
rateauditmodify in varchar,
bindrevenuecenter in varchar,
p_led_allow in varchar,
p_clear_allow in varchar,
repeatday in varchar,
premiumedit in varchar,
P_BILL_GENERATION in varchar,
P_PUBLICATION_CENTER in varchar,
P_allow_discount_prem IN VARCHAR,
P_SCHEME_BILLING in varchar,
P_ALLOW_PDC in varchar,
PAD_TYPE_FOR_MANUL_BILL in varchar,
RO_OUTSTAND_P IN VARCHAR2,
genrate_agency_code IN VARCHAR2,
p_dispauditbk IN VARCHAR2,
p_aotosupply  IN VARCHAR2,
p_Authorization IN VARCHAR2,
p_CIR_AUTO_APPROVAL_UNSOLD IN VARCHAR2,
p_CIR_AUTO_PHYSICAL_UNSOLD IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INCT IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INSFEE IN VARCHAR2,
p_CIR_UNSOLD_ON_RECEIVED_DT IN VARCHAR2,
p_AGENCY_UNBLOCK_APROV IN VARCHAR2,
p_UNBLOCK_APROV_OUT_LMT IN VARCHAR2,
p_CIR_BILL_PUBLWISE IN VARCHAR2,
p_paging         IN VARCHAR2,
p_print          IN VARCHAR2,
p_allowpage      IN VARCHAR2,
p_agency_req     IN VARCHAR2,
p_region_req     IN VARCHAR2,
p_ALLOW_FOLLOW_DT_BOOOK     IN VARCHAR2,
p_CRM_SUPPLY_TYPE_PAID     IN VARCHAR2,
p_CRM_SUPPLY_TYPE_FREE     IN VARCHAR2

)AS
BEGIN
UPDATE LOGIN SET "date_format"=dateformat, "Autogenerate"=code,"curr_code"=curr WHERE "COM_CODE"=compcode;
COMMIT;
        UPDATE PREFERRENCES SET  "autogenerated"=code,
"currency_code"=curr ,
"rate_gr_code"=RATECODE11,
"date_format"=dateformat,"solo"=solo,"breakup"=breakup,
"blackwhitecode"=bwcode,"rostatus"=rostatus,"File_name"=filename,"Tfn"=tfn,
"Insert_breakup"=insertbreak,"Premium_type"=prem,"Deal_type"=dealtype  ,
 "prefix"=pre, "suffix"=suff, "financestatus"=financestatus , "voucherst"=voucherst,
 "Ad_category"=adcode ,"Ro_datetime"=rodatetime ,"Space_area"=spacearea,"Vat"=vat,
 "Booking_status"=bookstat,"Cio_id"=cio_id,"Receipt_no"=receipt_no,"uom_code"=uom,
 "Bgcolor_publication"=bgcolor ,"chkfor_valid_pubdates"=validdate, "Agency_ratecode"=agencyratecode,
  "audit"=AUDIT1,"book_insert_date"=book_insert_date,"agencycomm"=agencycomm,
  "rate_audit"=rateaudit,"bill_audit"=billaudit,"billtype"=bill_type,"invoice_no"=invoice_no1,
  "copy_booking"=copybooking,"RATE_COMPANY_AGENCY"=ratecompany, "ADDITIONAL_AGENCY_COMM"=addagenycomm ,
  "AGENCY_RETAINER_COMM"=agencycommlinkretainer,"SUBEDITIONRATE"=subeditionr,
  "CLS_BILLTYPE"=classifiedbilltype,"DIS_BILLTYPE"=displaybilltype,"BILLING_FORMAT"=billformat,
  "RATE_CHECK"=ratechk,"ALL_PACKAGE"=allpkg,"DAYRATE"=dayrate1,"SCHEME_TYPE"=schemetype,"DISP_CLSBILL"=PIncludeclassi   ,
  "CASH_RECEIPT_BILL"=v_cash_receipt, "BILL_ORDERWSLAST"=v_bill_orderwiselast, "FLOOR_CHK"=v_floor_chk ,
  "UNSOLD_ENTRY_FLAG"=Unsoldflag ,"SUPPLY_STOP_PERCENTAGE"=Supplystopper,"ROKEYCHECK"=drpRokeychk ,
  "AGENCYCOMM_SEQ_COM"=Agencycomm_seq ,"CREDIT_RECIPT"=creditreciept,"DISP_CASHBILL"=cashindisplay,
  "CLA_CASHBILL"=cashinclassified,"RATE_AUDIT_PREF"=v_rate_audit_pref,"BARCODING_ALLOWED"=v_barcoding_allow_pref,
  "FMG_BILL_DIS" =v_fmgbills, "BILL_DISP_CASHBILL"=v_billed_cashdis , "BILL_CLA_CASHBILL"=v_billed_cashcls,"BACKDATERECEIPT"=v_drpbackdate,"DOCKIT_BOOKING"=dockitbooking,"Allowed_old_date"=allowprevbooking,"ROWISE_CASHBOOKING"=ro_wisecashbill,"CUTOFFTIME"=chkval,"APPROVAL"=approval1,"BACK_DAYS"=pckstatus ,CASH_DISCOUNT=cash_amt,CASH_DISCOUNTTYPE=cash_disc,SEPRATE_CASHIER=seperate_cashier1,
   CIR_MANY_TIME_POSTING=mantimepost, CIR_BACKDAYS_POSTING=bkdaypost, CIR_MAX_RETURN_ALLOW=maxterutn, CIR_RETURN_LIMIT_ALLOW=cir_return, CIR_NO_OF_CHQBOUNCE=noofchkbounc, CIR_DAYS_CHQBOUNCE=noofdaychkrec, CIR_RETURN_DAYS=retday, CIR_SUP_ORDER_LIMIT=chngsuppord, DISP_BILLING_CRITERIA=disp_bill, CLSD_BILLING_CRITERIA=clas_bill,MAX_PUBLISHDAYS=max_publishday,BILLNO_PERIODICITY=p_billno_period,
   SPECIALDISC_TRANS_EDIT=spl_trans_edit, SHARING_TRANS=spl_dis_trans_editable, MULTIPACKAGE_SEL_TRANS=mul_pac_sel_trans,SCHEME_MINWORD=shmon_minword, TRADE_SPLCHARGE=tradon_spcrg,RATE_AUTHORIZATION=rateauth
  ,F2_RECORD=f2day,PUBLISHAD_EDIT_RATEAUDIT=rateauditmodify,BINDREVENUE_CENTER=bindrevenuecenter,  
  FA_LEDGER_ALLOW=p_led_allow ,CLEARANCE_TYPE_ALLOW=p_clear_allow,REPEAT_DAY_TYPE=repeatday,PREMIUM_EDIT=premiumedit,
BILL_GENERATION_PRIOR=P_BILL_GENERATION,PUBLICATION_HO=P_PUBLICATION_CENTER,SPLDISC_ALLOWPREM=P_allow_discount_prem,

BILL_SCHEME=P_SCHEME_BILLING,ALLOWED_PDC_DAYS_RECEIPT=P_ALLOW_PDC ,AD_TYPE_MANUL_BILL=PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=RO_OUTSTAND_P,GENRATE_CIR_AGCD=genrate_agency_code,DISP_AUDITBKG=p_dispauditbk,CIR_DIS_AUTO_POSTING=p_aotosupply,RELAUTHREQON=p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=p_CIR_UNSOLD_ON_RECEIVED_DT,
AGENCY_UNBLOCK_APPROVAL=p_AGENCY_UNBLOCK_APROV,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=p_UNBLOCK_APROV_OUT_LMT,CIR_BILL_PUBLWISE=p_CIR_BILL_PUBLWISE,
RECORDS_ON_PAGE = p_paging,RECORDS_ON_PRINT = p_print,HEADER_ON_PAGE = p_allowpage,AGENCY_REQUIRED = p_agency_req,REGION_REQUIRED = p_region_req,ALLOW_FOLLOW_DT_BOOOK=p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=p_CRM_SUPPLY_TYPE_FREE

  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/

/**********************/



CREATE OR REPLACE PACKAGE Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/





CREATE OR REPLACE PACKAGE BODY Currbindpreferpgld
IS
   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
         SELECT "date_format", "autogenerated", "currency_code",
                "rate_gr_code", "solo", "breakup", "blackwhitecode",
                "rostatus", "File_name", "Tfn", "Insert_breakup", "prefix",
                "suffix", "financestatus", "voucherst", "Ad_category",
                "Ro_datetime", "Vat", "Booking_status", "Cio_id",
                "Receipt_no","uom_code","Bgcolor_publication","chkfor_valid_pubdates","Agency_ratecode","audit","book_insert_date","agencycomm",
                "rate_audit","bill_audit","billtype","Premium_type","copy_booking","RATE_COMPANY_AGENCY","ADDITIONAL_AGENCY_COMM","AGENCY_RETAINER_COMM","SUBEDITIONRATE",CLS_BILLTYPE,DIS_BILLTYPE,
                "BILLING_FORMAT","RATE_CHECK","ALL_PACKAGE",dayrate,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,
                ROKEYCHECK, AGENCYCOMM_SEQ_COM, CREDIT_RECIPT,  DISP_CASHBILL, CLA_CASHBILL,
                RATE_AUDIT_PREF,BARCODING_ALLOWED, FMG_BILL_DIS,BILL_DISP_CASHBILL, BILL_CLA_CASHBILL,BACKDATERECEIPT,ROWISE_CASHBOOKING,CUTOFFTIME,DOCKIT_BOOKING,APPROVAL,BACK_DAYS,CASH_DISCOUNT,CASH_DISCOUNTTYPE,"Allowed_old_date",SEPRATE_CASHIER,
                CIR_MANY_TIME_POSTING, CIR_BACKDAYS_POSTING, CIR_MAX_RETURN_ALLOW, CIR_RETURN_LIMIT_ALLOW, CIR_NO_OF_CHQBOUNCE, CIR_DAYS_CHQBOUNCE, CIR_RETURN_DAYS, CIR_SUP_ORDER_LIMIT, DISP_BILLING_CRITERIA, CLSD_BILLING_CRITERIA,MAX_PUBLISHDAYS,
                BILLNO_PERIODICITY, SPECIALDISC_TRANS_EDIT, SHARING_TRANS, MULTIPACKAGE_SEL_TRANS,SCHEME_MINWORD, TRADE_SPLCHARGE,RATE_AUTHORIZATION,
           F2_RECORD,PUBLISHAD_EDIT_RATEAUDIT,BINDREVENUE_CENTER, FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,REPEAT_DAY_TYPE,PREMIUM_EDIT,
           
           BILL_GENERATION_PRIOR,PUBLICATION_HO,SPLDISC_ALLOWPREM,BILL_SCHEME,ALLOWED_PDC_DAYS_RECEIPT,
           AD_TYPE_MANUL_BILL,OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD,DISP_AUDITBKG,CIR_DIS_AUTO_POSTING,RELAUTHREQON,
        CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,
        AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE ,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE  
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/

/*************************/



CREATE OR REPLACE PACKAGE Cir_Supply_Type_Bind IS
    type t_accounts_type is ref cursor;
procedure Cir_Supply_Type_Bind_p(
    pcomp_code      in varchar2,
    pdateformat 	in varchar2,
    pextra1 		in varchar2,
    pextra2 		in varchar2,
    p_accounts 		out t_accounts_type);
        
END Cir_Supply_Type_Bind;
/





CREATE OR REPLACE PACKAGE BODY Cir_Supply_Type_Bind IS
procedure Cir_Supply_Type_Bind_p(
  	pcomp_code      in varchar2,
    pdateformat 	in varchar2,
    pextra1 		in varchar2,--for billing pay Y/N
    pextra2 		in varchar2,
    p_accounts 		out t_accounts_type)
  As
  Begin
	  open  p_accounts for
	  select * from cir_supply_type_mast where comp_code=pcomp_code and (bill_pay=pextra1 or pextra1 is null)
	  order by sup_seq_no,sup_ty_name;
      
  End Cir_Supply_Type_Bind_p;
END Cir_Supply_Type_Bind;
/


/***********************mimoh 26dec 2011*********************************0006137****************/

/*********************mimoh 28dec2011********************************5972******************************/



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
      p_parent     in       varchar2,
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
      p_parent     in       varchar2,
      p_accounts   OUT      t_accounts_cursor
   )
   AS
      curscod   VARCHAR (12);
      code      VARCHAR (8);
   BEGIN
   DELETE FROM CUST_MAST_TEMP; COMMIT;
      INSERT INTO CUST_MAST_TEMP(
            comp_code, cust_code, cust_name, cust_alias, add1, 
            stree, city_code, zip, dist_code, state_code, 
            country_code, phone1, phone2, fax, emailid, url, 
            no_of_vts, st_acc_no, pan_no, credit_days, 
            pay_mode_code, cust_status, status_reason, remarks, 
            userid, creation_datetime, zone_code, region_code,
            credit_limit, rate_gr_code, to_date, client_category, taluka1, 
            agency_code, division, client_type, qbc_agency,"TYPE",PARENT_CLIENT)
         SELECT "Comp_Code", "Cust_Code", "Cust_Name", "Cust_Alias", "Add1",
                "Stree", "City_Code", "Zip", "Dist_Code", "State_Code",
                "Country_Code", "phone1", "Phone2", "Fax", "EmailID", "URL",
                "No_of_VTS", "ST_ACC_No", "PAN_No", "Credit_Days",
                "Pay_Mode_Code", "Cust_Status", "Status_Reason", "Remarks",
                "UserId", "Creation_Datetime", "Zone_code", "Region_code",
                "Credit_limit", "Rate_Gr_Code", SYSDATE, "Client_category","TALUKA",
                AGENCY_CODE, DIVISION, CLIENT_TYPE, QBC_AGENCY,"TYPE","PARENT_CLIENT"
           FROM CUST_MAST
          WHERE ("Comp_Code" = compcode OR compcode IS NULL)
            AND ("Cust_Code" = custcode OR custcode IS NULL)
            AND ("TYPE" = p_parent OR p_parent IS NULL)
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
SELECT COMP_CODE as "Comp_Code", CUST_CODE as "Cust_Code", CUST_NAME as "Cust_Name", CUST_ALIAS as "Cust_Alias", ADD1 as "Add1", STREE as "Stree", CITY_CODE as "City_Code", ZIP as "Zip", DIST_CODE as "Dist_Code", STATE_CODE as "State_Code", COUNTRY_CODE as "Country_Code", PHONE1 as "phone1", PHONE2 as "Phone2", FAX as "Fax", EMAILID as "EmailID", URL, NO_OF_VTS as "No_of_VTS", ST_ACC_NO, PAN_NO, CREDIT_DAYS as "Credit_Days", PAY_MODE_CODE as "Pay_Mode_Code", CUST_STATUS as "Cust_Status", STATUS_REASON as "Status_Reason", REMARKS as "Remarks", USERID as "UserId", CREATION_DATETIME as "Creation_Datetime", ZONE_CODE as "Zone_code", REGION_CODE as "Region_code", CREDIT_LIMIT as "Credit_limit", RATE_GR_CODE as "Rate_Gr_Code", TO_DATE as "to_date", CLIENT_CATEGORY as "Client_category",TALUKA1 as "TALUKA",CLIENT_TYPE, QBC_AGENCY,"TYPE",PARENT_CLIENT FROM CUST_MAST_TEMP ORDER BY Cust_Code;

   END clientexecute_p;
END Clientexecute;
/

/*********************mimoh 28dec2011********************************5972******************************/
/***********************mimoh 28dec 2011*********6162****************************************/


CREATE OR REPLACE PACKAGE Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/





CREATE OR REPLACE PACKAGE BODY Currbindpreferpgld
IS
   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
         SELECT "date_format", "autogenerated", "currency_code",
                "rate_gr_code", "solo", "breakup", "blackwhitecode",
                "rostatus", "File_name", "Tfn", "Insert_breakup", "prefix",
                "suffix", "financestatus", "voucherst", "Ad_category",
                "Ro_datetime", "Vat", "Booking_status", "Cio_id",
                "Receipt_no","uom_code","Bgcolor_publication","chkfor_valid_pubdates","Agency_ratecode","audit","book_insert_date","agencycomm",
                "rate_audit","bill_audit","billtype","Premium_type","copy_booking","RATE_COMPANY_AGENCY","ADDITIONAL_AGENCY_COMM","AGENCY_RETAINER_COMM","SUBEDITIONRATE",CLS_BILLTYPE,DIS_BILLTYPE,
                "BILLING_FORMAT","RATE_CHECK","ALL_PACKAGE",dayrate,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,
                ROKEYCHECK, AGENCYCOMM_SEQ_COM, CREDIT_RECIPT,  DISP_CASHBILL, CLA_CASHBILL,
                RATE_AUDIT_PREF,BARCODING_ALLOWED, FMG_BILL_DIS,BILL_DISP_CASHBILL, BILL_CLA_CASHBILL,BACKDATERECEIPT,ROWISE_CASHBOOKING,CUTOFFTIME,DOCKIT_BOOKING,APPROVAL,BACK_DAYS,CASH_DISCOUNT,CASH_DISCOUNTTYPE,"Allowed_old_date",SEPRATE_CASHIER,
                CIR_MANY_TIME_POSTING, CIR_BACKDAYS_POSTING, CIR_MAX_RETURN_ALLOW, CIR_RETURN_LIMIT_ALLOW, CIR_NO_OF_CHQBOUNCE, CIR_DAYS_CHQBOUNCE, CIR_RETURN_DAYS, CIR_SUP_ORDER_LIMIT, DISP_BILLING_CRITERIA, CLSD_BILLING_CRITERIA,MAX_PUBLISHDAYS,
                BILLNO_PERIODICITY, SPECIALDISC_TRANS_EDIT, SHARING_TRANS, MULTIPACKAGE_SEL_TRANS,SCHEME_MINWORD, TRADE_SPLCHARGE,RATE_AUTHORIZATION,
           F2_RECORD,PUBLISHAD_EDIT_RATEAUDIT,BINDREVENUE_CENTER, FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,REPEAT_DAY_TYPE,PREMIUM_EDIT,
           
           BILL_GENERATION_PRIOR,PUBLICATION_HO,SPLDISC_ALLOWPREM,BILL_SCHEME,ALLOWED_PDC_DAYS_RECEIPT,
           AD_TYPE_MANUL_BILL,OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD,DISP_AUDITBKG,CIR_DIS_AUTO_POSTING,RELAUTHREQON,
        CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,
        AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE ,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT  
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/

/******************************************************************/



CREATE OR REPLACE PACKAGE Wesp_Updatedate
IS
PROCEDURE      Wesp_Updatedate_p(
compcode IN VARCHAR2,
userid IN VARCHAR2,
dateformat IN VARCHAR2,
code IN VARCHAR2,
curr IN VARCHAR2,
RATECODE11 IN VARCHAR2,
solo  IN VARCHAR2,
breakup VARCHAR2,
bwcode IN VARCHAR2,
rostatus IN VARCHAR2,
filename IN VARCHAR2,
tfn IN NUMBER,
insertbreak IN VARCHAR2,
prem IN VARCHAR2,
dealtype IN VARCHAR2,
pre IN VARCHAR2,
suff IN VARCHAR2,
financestatus IN  VARCHAR2,
voucherst IN VARCHAR2,
adcode IN VARCHAR2,
rodatetime IN VARCHAR2,
spacearea IN VARCHAR2,
vat IN VARCHAR2,
bookstat IN VARCHAR2,
cio_id IN VARCHAR2,
receipt_no IN VARCHAR2,
uom IN VARCHAR2,
bgcolor IN VARCHAR2,
validdate IN VARCHAR2,
agencyratecode IN VARCHAR2,
AUDIT1 IN VARCHAR2,
book_insert_date IN VARCHAR2,
agencycomm IN VARCHAR2,
rateaudit IN VARCHAR2,
billaudit IN VARCHAR2,
bill_type IN VARCHAR2,
invoice_no1 IN VARCHAR2,
copybooking IN VARCHAR2,
ratecompany IN VARCHAR2,
addagenycomm IN VARCHAR2,
agencycommlinkretainer IN VARCHAR2,
subeditionr IN VARCHAR2,
displaybilltype IN VARCHAR2,
classifiedbilltype IN VARCHAR2,
billformat IN VARCHAR2,
ratechk IN VARCHAR2,
allpkg IN VARCHAR2,
dayrate1 in varchar2,
schemetype in varchar2,
PIncludeclassi in varchar2,
receiptformat IN VARCHAR2,
v_cash_receipt in varchar2,
v_bill_orderwiselast in varchar2,
v_floor_chk in varchar2,
Unsoldflag in varchar2,
Supplystopper in  number,
drpRokeychk in varchar2,
Agencycomm_seq in varchar2,
creditreciept in varchar,
cashindisplay IN VARCHAR,
cashinclassified IN VARCHAR,
v_rate_audit_pref in varchar,
v_barcoding_allow_pref in varchar2,
v_fmgbills IN VARCHAR2,
v_billed_cashdis in varchar2,
v_billed_cashcls in varchar,
v_drpbackdate in varchar,
dockitbooking in varchar2,
allowprevbooking in varchar2,
ro_wisecashbill in varchar2,
chkval in varchar2,
approval1 in varchar2,
pckstatus in varchar2,
cash_disc in varchar2,
cash_amt in varchar2,
seperate_cashier1 in varchar2,
disp_bill in varchar2,
clas_bill in varchar2,
mantimepost in varchar2,
bkdaypost in number,
maxterutn in number,
cir_return in varchar2,
noofchkbounc in number,
noofdaychkrec in number,
retday in number,
chngsuppord in number,
max_publishday in number,
p_billno_period in varchar,
spl_trans_edit in varchar2,
spl_dis_trans_editable in varchar2,
mul_pac_sel_trans in varchar2,
shmon_minword in varchar2,
tradon_spcrg in varchar2,
rateauth     in varchar2,
f2day in number,
rateauditmodify in varchar,
bindrevenuecenter in varchar,
p_led_allow in varchar,
p_clear_allow in varchar,
repeatday in varchar,
premiumedit in varchar,
P_BILL_GENERATION in varchar,
P_PUBLICATION_CENTER in varchar,
P_allow_discount_prem IN VARCHAR,
P_SCHEME_BILLING in varchar,
P_ALLOW_PDC in varchar,
PAD_TYPE_FOR_MANUL_BILL in varchar,
RO_OUTSTAND_P IN VARCHAR2,
genrate_agency_code IN VARCHAR2,
p_dispauditbk IN VARCHAR2,
p_aotosupply  IN VARCHAR2,
p_Authorization IN VARCHAR2,
p_CIR_AUTO_APPROVAL_UNSOLD IN VARCHAR2,
p_CIR_AUTO_PHYSICAL_UNSOLD IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INCT IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INSFEE IN VARCHAR2,
p_CIR_UNSOLD_ON_RECEIVED_DT IN VARCHAR2,
p_AGENCY_UNBLOCK_APROV IN VARCHAR2,
p_UNBLOCK_APROV_OUT_LMT IN VARCHAR2,
p_CIR_BILL_PUBLWISE IN VARCHAR2,
p_paging         IN VARCHAR2,
p_print          IN VARCHAR2,
p_allowpage      IN VARCHAR2,
p_agency_req     IN VARCHAR2,
p_region_req     IN VARCHAR2,
p_ALLOW_FOLLOW_DT_BOOOK     IN VARCHAR2,
p_CRM_SUPPLY_TYPE_PAID     IN VARCHAR2,
p_CRM_SUPPLY_TYPE_FREE     IN VARCHAR2,
p_CURRENCY_MEASUREMENT     IN VARCHAR2

);
END      Wesp_Updatedate;
/





CREATE OR REPLACE PACKAGE BODY Wesp_Updatedate IS
PROCEDURE      Wesp_Updatedate_p(
compcode IN VARCHAR2,
userid IN VARCHAR2,
dateformat IN VARCHAR2,
code IN VARCHAR2,
curr IN VARCHAR2,
RATECODE11 IN VARCHAR2,
solo  IN VARCHAR2,
breakup VARCHAR2,
bwcode IN VARCHAR2,
rostatus IN VARCHAR2,
filename IN VARCHAR2,
tfn IN NUMBER,
insertbreak IN VARCHAR2,
prem IN VARCHAR2,
dealtype IN VARCHAR2,
pre IN VARCHAR2,
suff IN VARCHAR2,
financestatus IN  VARCHAR2,
voucherst IN VARCHAR2,
adcode IN VARCHAR2,
rodatetime IN VARCHAR2,
spacearea IN VARCHAR2,
vat IN VARCHAR2,
bookstat IN VARCHAR2,
cio_id IN VARCHAR2,
receipt_no IN VARCHAR2,
uom IN VARCHAR2,
bgcolor IN VARCHAR2,
validdate IN VARCHAR2,
agencyratecode IN VARCHAR2,
AUDIT1 IN VARCHAR2,
book_insert_date IN VARCHAR2,
agencycomm IN VARCHAR2,
rateaudit IN VARCHAR2,
billaudit IN VARCHAR2,
bill_type IN VARCHAR2,
invoice_no1 IN VARCHAR2,
copybooking IN VARCHAR2,
ratecompany IN VARCHAR2,
addagenycomm IN VARCHAR2,
agencycommlinkretainer IN VARCHAR2,
subeditionr IN VARCHAR2,
displaybilltype IN VARCHAR2,
classifiedbilltype IN VARCHAR2,
billformat IN VARCHAR2,
ratechk IN VARCHAR2,
allpkg IN VARCHAR2,
dayrate1 in varchar2,
schemetype in varchar2,
PIncludeclassi in varchar2,
receiptformat IN VARCHAR2,
v_cash_receipt in varchar2,
v_bill_orderwiselast in varchar2,
v_floor_chk in varchar2,
Unsoldflag in varchar2,
Supplystopper in  number,
drpRokeychk in varchar2,
Agencycomm_seq in varchar2,
creditreciept in varchar,
cashindisplay IN VARCHAR,
cashinclassified IN VARCHAR,
v_rate_audit_pref in varchar,
v_barcoding_allow_pref in varchar2,
v_fmgbills IN VARCHAR2,
v_billed_cashdis in varchar2,
v_billed_cashcls in varchar,
v_drpbackdate in varchar,
dockitbooking in varchar2,
allowprevbooking in varchar2,
ro_wisecashbill in varchar2,
chkval in varchar2,
approval1 in varchar2,
pckstatus in varchar2,
cash_disc in varchar2,
cash_amt in varchar2,
seperate_cashier1 in varchar2,
disp_bill in varchar2,
clas_bill in varchar2,
mantimepost in varchar2,
bkdaypost in number,
maxterutn in number,
cir_return in varchar2,
noofchkbounc in number,
noofdaychkrec in number,
retday in number,
chngsuppord in number,
max_publishday in number,
p_billno_period in varchar,
spl_trans_edit in varchar2,
spl_dis_trans_editable in varchar2,
mul_pac_sel_trans in varchar2,
shmon_minword in varchar2,
tradon_spcrg in varchar2,
rateauth     in varchar2,
f2day in number,
rateauditmodify in varchar,
bindrevenuecenter in varchar,
p_led_allow in varchar,
p_clear_allow in varchar,
repeatday in varchar,
premiumedit in varchar,
P_BILL_GENERATION in varchar,
P_PUBLICATION_CENTER in varchar,
P_allow_discount_prem IN VARCHAR,
P_SCHEME_BILLING in varchar,
P_ALLOW_PDC in varchar,
PAD_TYPE_FOR_MANUL_BILL in varchar,
RO_OUTSTAND_P IN VARCHAR2,
genrate_agency_code IN VARCHAR2,
p_dispauditbk IN VARCHAR2,
p_aotosupply  IN VARCHAR2,
p_Authorization IN VARCHAR2,
p_CIR_AUTO_APPROVAL_UNSOLD IN VARCHAR2,
p_CIR_AUTO_PHYSICAL_UNSOLD IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INCT IN VARCHAR2,
p_CIR_UNSOLD_INCLUDE_INSFEE IN VARCHAR2,
p_CIR_UNSOLD_ON_RECEIVED_DT IN VARCHAR2,
p_AGENCY_UNBLOCK_APROV IN VARCHAR2,
p_UNBLOCK_APROV_OUT_LMT IN VARCHAR2,
p_CIR_BILL_PUBLWISE IN VARCHAR2,
p_paging         IN VARCHAR2,
p_print          IN VARCHAR2,
p_allowpage      IN VARCHAR2,
p_agency_req     IN VARCHAR2,
p_region_req     IN VARCHAR2,
p_ALLOW_FOLLOW_DT_BOOOK     IN VARCHAR2,
p_CRM_SUPPLY_TYPE_PAID     IN VARCHAR2,
p_CRM_SUPPLY_TYPE_FREE     IN VARCHAR2,
p_CURRENCY_MEASUREMENT     IN VARCHAR2

)AS
BEGIN
UPDATE LOGIN SET "date_format"=dateformat, "Autogenerate"=code,"curr_code"=curr WHERE "COM_CODE"=compcode;
COMMIT;
        UPDATE PREFERRENCES SET  "autogenerated"=code,
"currency_code"=curr ,
"rate_gr_code"=RATECODE11,
"date_format"=dateformat,"solo"=solo,"breakup"=breakup,
"blackwhitecode"=bwcode,"rostatus"=rostatus,"File_name"=filename,"Tfn"=tfn,
"Insert_breakup"=insertbreak,"Premium_type"=prem,"Deal_type"=dealtype  ,
 "prefix"=pre, "suffix"=suff, "financestatus"=financestatus , "voucherst"=voucherst,
 "Ad_category"=adcode ,"Ro_datetime"=rodatetime ,"Space_area"=spacearea,"Vat"=vat,
 "Booking_status"=bookstat,"Cio_id"=cio_id,"Receipt_no"=receipt_no,"uom_code"=uom,
 "Bgcolor_publication"=bgcolor ,"chkfor_valid_pubdates"=validdate, "Agency_ratecode"=agencyratecode,
  "audit"=AUDIT1,"book_insert_date"=book_insert_date,"agencycomm"=agencycomm,
  "rate_audit"=rateaudit,"bill_audit"=billaudit,"billtype"=bill_type,"invoice_no"=invoice_no1,
  "copy_booking"=copybooking,"RATE_COMPANY_AGENCY"=ratecompany, "ADDITIONAL_AGENCY_COMM"=addagenycomm ,
  "AGENCY_RETAINER_COMM"=agencycommlinkretainer,"SUBEDITIONRATE"=subeditionr,
  "CLS_BILLTYPE"=classifiedbilltype,"DIS_BILLTYPE"=displaybilltype,"BILLING_FORMAT"=billformat,
  "RATE_CHECK"=ratechk,"ALL_PACKAGE"=allpkg,"DAYRATE"=dayrate1,"SCHEME_TYPE"=schemetype,"DISP_CLSBILL"=PIncludeclassi   ,
  "CASH_RECEIPT_BILL"=v_cash_receipt, "BILL_ORDERWSLAST"=v_bill_orderwiselast, "FLOOR_CHK"=v_floor_chk ,
  "UNSOLD_ENTRY_FLAG"=Unsoldflag ,"SUPPLY_STOP_PERCENTAGE"=Supplystopper,"ROKEYCHECK"=drpRokeychk ,
  "AGENCYCOMM_SEQ_COM"=Agencycomm_seq ,"CREDIT_RECIPT"=creditreciept,"DISP_CASHBILL"=cashindisplay,
  "CLA_CASHBILL"=cashinclassified,"RATE_AUDIT_PREF"=v_rate_audit_pref,"BARCODING_ALLOWED"=v_barcoding_allow_pref,
  "FMG_BILL_DIS" =v_fmgbills, "BILL_DISP_CASHBILL"=v_billed_cashdis , "BILL_CLA_CASHBILL"=v_billed_cashcls,"BACKDATERECEIPT"=v_drpbackdate,"DOCKIT_BOOKING"=dockitbooking,"Allowed_old_date"=allowprevbooking,"ROWISE_CASHBOOKING"=ro_wisecashbill,"CUTOFFTIME"=chkval,"APPROVAL"=approval1,"BACK_DAYS"=pckstatus ,CASH_DISCOUNT=cash_amt,CASH_DISCOUNTTYPE=cash_disc,SEPRATE_CASHIER=seperate_cashier1,
   CIR_MANY_TIME_POSTING=mantimepost, CIR_BACKDAYS_POSTING=bkdaypost, CIR_MAX_RETURN_ALLOW=maxterutn, CIR_RETURN_LIMIT_ALLOW=cir_return, CIR_NO_OF_CHQBOUNCE=noofchkbounc, CIR_DAYS_CHQBOUNCE=noofdaychkrec, CIR_RETURN_DAYS=retday, CIR_SUP_ORDER_LIMIT=chngsuppord, DISP_BILLING_CRITERIA=disp_bill, CLSD_BILLING_CRITERIA=clas_bill,MAX_PUBLISHDAYS=max_publishday,BILLNO_PERIODICITY=p_billno_period,
   SPECIALDISC_TRANS_EDIT=spl_trans_edit, SHARING_TRANS=spl_dis_trans_editable, MULTIPACKAGE_SEL_TRANS=mul_pac_sel_trans,SCHEME_MINWORD=shmon_minword, TRADE_SPLCHARGE=tradon_spcrg,RATE_AUTHORIZATION=rateauth
  ,F2_RECORD=f2day,PUBLISHAD_EDIT_RATEAUDIT=rateauditmodify,BINDREVENUE_CENTER=bindrevenuecenter,  
  FA_LEDGER_ALLOW=p_led_allow ,CLEARANCE_TYPE_ALLOW=p_clear_allow,REPEAT_DAY_TYPE=repeatday,PREMIUM_EDIT=premiumedit,
BILL_GENERATION_PRIOR=P_BILL_GENERATION,PUBLICATION_HO=P_PUBLICATION_CENTER,SPLDISC_ALLOWPREM=P_allow_discount_prem,

BILL_SCHEME=P_SCHEME_BILLING,ALLOWED_PDC_DAYS_RECEIPT=P_ALLOW_PDC ,AD_TYPE_MANUL_BILL=PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=RO_OUTSTAND_P,GENRATE_CIR_AGCD=genrate_agency_code,DISP_AUDITBKG=p_dispauditbk,CIR_DIS_AUTO_POSTING=p_aotosupply,RELAUTHREQON=p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=p_CIR_UNSOLD_ON_RECEIVED_DT,
AGENCY_UNBLOCK_APPROVAL=p_AGENCY_UNBLOCK_APROV,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=p_UNBLOCK_APROV_OUT_LMT,CIR_BILL_PUBLWISE=p_CIR_BILL_PUBLWISE,
RECORDS_ON_PAGE = p_paging,RECORDS_ON_PRINT = p_print,HEADER_ON_PAGE = p_allowpage,AGENCY_REQUIRED = p_agency_req,REGION_REQUIRED = p_region_req,ALLOW_FOLLOW_DT_BOOOK=p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=p_CURRENCY_MEASUREMENT

  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/



/***********************mimoh 28dec 2011*********6162****************************************/


/***********************mimoh 28dec 2011*********deal****************************************/


CREATE OR REPLACE PROCEDURE tv_dealAudit (
   compcode_p     IN       VARCHAR2,
   adtype_p        IN       VARCHAR2,
   validfrom_p     IN       VARCHAR2,
   validto_p    IN       VARCHAR2,
   agency_p      IN       VARCHAR2,
   client_p    IN       VARCHAR2,
   dealno_p         IN       VARCHAR2,
   audittype_p      IN       VARCHAR2,
   dateformat_p     IN       VARCHAR2,   
   p_accounts   OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT (select "Agency_Name"||'('|| "Agency_Code" ||')' from agency_mast where "Agency_Code"="Agency_code" and agency_mast."SUB_Agency_Code"=contract_mast."Sub_Agency_Code") as "Agency_code",
      (select "Cust_Name"||'('||"Cust_Code"||')' from cust_mast where "Cust_Code"="Client_code") as "Client_code","Deal_No","deal_name",
      "Product_code",CAPTION,TO_CHAR("From_date",dateformat_p) as "FROM_DATE",TO_CHAR("Till_date",dateformat_p) as "TILL_DATE",
      '' as TOTALVAL
        FROM contract_mast
       WHERE "Comp_code" = compcode_p
       AND "Creation_datetime" BETWEEN validfrom_p and validto_p
        AND ("Deal_No" = dealno_p OR dealno_p IS NULL OR dealno_p = '')
         AND (DEALON = adtype_p OR adtype_p IS NULL OR adtype_p = '')
         AND("Agency_code" LIKE agency_p||'%'OR agency_p IS NULL)
         AND ("Client_code" = client_p OR client_p IS NULL OR client_p = '');
END;
/

/*********************************************************/



CREATE OR REPLACE PROCEDURE tv_dealauditupdate
(
pdealno IN VARCHAR2,
puserid IN VARCHAR2,
premark IN VARCHAR2

)
as
begin 

update contract_mast set AUDITBY=puserid,AUDIT_DATE=sysdate,AUDIT_COMMENT=premark where "Deal_No"=pdealno  ;

update tv_deal_det set APPROVED='Y' where DEALNO=pdealno;

commit;
end;
/




/***********************mimoh 28dec 2011*********deal****************************************/



/*******************************contract************************/

CREATE OR REPLACE PROCEDURE tv_paid_balance_cal (
   pcomp_code       IN       VARCHAR2,
   punit_code       IN       VARCHAR2,
   pchannel         IN       VARCHAR2,
   plocation_code   IN       VARCHAR2,
   pad_type         IN       VARCHAR2,
   pdealno          IN       VARCHAR2,
   pbtb_code        IN       VARCHAR2,
   ppaid_bonus      IN       VARCHAR2,
   p_accounts       OUT      cur_type_new1.cursor_type
)
IS
   vdur   NUMBER;
   v_no number;
BEGIN
   BEGIN
      SELECT SUM (NVL (dur, 0) * NVL (no_of_spot, 0))
        INTO vdur
        FROM tv_booking_det
       WHERE bkkno IN (
                SELECT bkkno
                  FROM tv_booking_mst
                 WHERE comp_code = pcomp_code
                   AND UNIT_CODE = punit_code
                   AND DEAL_NO = pdealno
                   AND (channel = pchannel OR pchannel IS NULL)
                   AND (loccd = plocation_code OR plocation_code IS NULL))
         AND btb_code = pbtb_code
         AND paid_bonus = ppaid_bonus;
   EXCEPTION
      WHEN NO_DATA_FOUND
      THEN
         vdur:=0;
   END;
   
    begin
         select nvl(NO_OF_INS,0) into v_no from tv_deal_det 
                    where comp_code = pcomp_code
                   AND unit = punit_code
                   AND dealno = pdealno
                   AND (channel = pchannel OR pchannel IS NULL)
                   AND (LOCATION_CODE= plocation_code OR plocation_code IS NULL)
                    AND btb_code = pbtb_code
                   AND PB_FLG = ppaid_bonus;
                    exception when no_data_found then 
                    v_no:=0;
          end;    

   OPEN p_accounts FOR
      SELECT vdur as "vdur", NVL (v_no, 0) - NVL (vdur, 0)  as "vbal"
        FROM DUAL;
END;
/



CREATE OR REPLACE procedure bindGridDetails_Contract
(
compcode in varchar2,
dealcode in varchar2,
seqno_p in varchar2,
p_accounts out Cur_Type_New1.cursor_type,
p_accounts1 out Cur_Type_New1.cursor_type
)
is 
begin
open p_accounts for 
    select  AD_GET_FIELDNAME('Comp_Code',compcode,'Adv_Type_Code',ADTYPE,'Adv_Type_Name','Adv_Type_Mast','','')  as ADTYPE,
    AD_GET_FIELDNAME('Comp_Code',compcode,'Col_Code',contract_detail."color",'Col_Name','Col_Mast','','') as color,
    AD_GET_FIELDNAME('Comp_Code',compcode,'Uom_Code',contract_detail."Uom",'Uom_Name','Uom_Mast','','') as Uom,
    AD_GET_FIELDNAME('Comp_Code',compcode,'Combin_Code',contract_detail."packagecode",'Combin_Desc','Combin_Mast','','') as packagecode,
    AD_GET_FIELDNAME('Comp_Code',compcode,'Adv_Cat_Code',contract_detail."Advcategory",'Adv_Cat_Name','Adv_Cat_Mast','','') as Advcategory,
    AD_GET_FIELDNAME('comp_code',compcode,'Premiumcode',contract_detail."premiumcode",'premiumname','ADVPOS_PREM_MAST','','') as premiumcode,
    nvl("cardpremium",'') as cardpremium,nvl("dealpremium",'') as dealpremium,nvl("Dealarte",'') as Dealarte,nvl("cardrate",'') as cardrate,
    nvl("deviation",'') as deviation,
    CASE  "discounted"
    WHEN '1' THEN 'Free(1)'
    WHEN '2' THEN 'Discounted(2)'
    WHEN '3' THEN 'Fixed Rate(3)'
    ELSE "discounted"
    END as discounted,
    nvl(DISCPER,'')  as DISCPER,
    CASE  DISCTYPE
    WHEN '1' THEN 'Discount On Bill(1)'
    WHEN '2' THEN 'Discount through Credit Note(2)'
    ELSE DISCTYPE
    END as DISCTYPE,
    nvl(SIZEFROM,'') as SIZEFROM,nvl(SIZETO,'') as SIZETO,
    nvl("valuefrom",'') as valuefrom,nvl("valueto",'') as valueto,nvl(DAYNAME,'') as DAYNAME,nvl(INSERTION,'') as INSERTION,
    CASE COMMITION_ALLOW
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE COMMITION_ALLOW
    END as COMMITION_ALLOW,
    CASE  DEAL_START
    WHEN 'A' THEN 'After Target Achived(A)'
    WHEN 'B' THEN 'From Begining(B)'
    ELSE DEAL_START
    END as DEAL_START,
    AD_GET_FIELDNAME('Comp_Code',compcode,'Curr_Code',"currency",'Curr_Name','Curr_Mast','','') as currency,nvl("Rate_code",'') as Rate_code,nvl("convertrate",'') as convertrate,nvl(INCENTIVE,'') as INCENTIVE,nvl(REMARKS,'') as REMARKS,
     CASE "approved"
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE "approved"
    END as approved,"ContractCode" as CONTRACTCODE
     from contract_detail where "deal_code"=dealcode;
if seqno_p is null then
open p_accounts1 for 
    SELECT 
    AD_GET_FIELDNAME('COMP_CODE',compcode,'CHANNEL',CHANNEL,'NAME','TV_AD_CHANNEL','','')  as CHANNEL,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'LOCCD',LOCATION_CODE,'NAME','TV_AD_LOCATION','','')  as LOCATION_CODE,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'AD_TYPE',AD_TYPE,'DES','TV_AD_TYPE','CHANNEL',CHANNEL)  as AD_TYPE,
    CASE  PB_FLG
    WHEN 'P' THEN 'Paid(P)'
    WHEN 'B' THEN 'Bonus(B)'
    ELSE PB_FLG
    END AS PB_FLG,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'PRG_ID',PRG_CODE,'SHORT_NAME','TV_AD_PROGRAMME','','')  as PRG_CODE,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'TV_BTB_MST.BTB_CODE',BTB_CODE,'BTB_DESC','TV_BTB_MST','CHANNEL',CHANNEL)  as BTB_CODE,
  --  AD_GET_FIELDNAME('COMP_CODE',compcode,'BND_CODE',ROS_CODE,'BND_DESC','TV_BND_MST','BTB_CODE',BTB_CODE)  as ROS_CODE,
    NVL(ROS_CODE,'') as ROS_CODE,
    nvl(DAYS,'') as DAYS,nvl(NO_OF_INS,'') as NO_OF_INS,
    AD_GET_FIELDNAME('Comp_Code',compcode,'Combin_Code',PACKAGE_CODE,'Combin_Desc','TV_COMBIN_MAST','','') as PACKAGE_CODE, 
    nvl(VALUE_FROM,'') as VALUE_FROM, nvl(VALUE_TO,'') as VALUE_TO,
     CASE  DISC_TYPE
    WHEN '1' THEN 'Free(1)'
    WHEN '2' THEN 'Discounted(2)'
    WHEN '3' THEN 'Fixed Rate(3)'
    ELSE DISC_TYPE
    END as DISC_TYPE, 
    nvl(DISC_VAL,'') as DISC_VAL,
    AD_GET_FIELDNAME('comp_code',compcode,'Premiumcode',PREM_CODE,'premiumname','ADVPOS_PREM_MAST','','') as PREM_CODE,
     nvl(CONTRACT_PREM_VALUE,'') as CONTRACT_PREM_VALUE,nvl(CONTRACT_RATE,'') as CONTRACT_RATE, nvl(CARD_RATE,'') as CARD_RATE, 
     nvl(DEVIATION_RATE,'') as DEVIATION_RATE,nvl(CARD_PREM_VALUE,'') as CARD_PREM_VALUE,nvl(MIN_SIZE,'') as MIN_SIZE, nvl(MAX_SIZE,'') as MAX_SIZE,
      AD_GET_FIELDNAME('Comp_Code',compcode,'Curr_Code',CURRENCY,'Curr_Name','Curr_Mast','','') as CURRENCY,
     CASE  DEAL_START
    WHEN 'A' THEN 'After Target Achived(A)'
    WHEN 'B' THEN 'From Begining(B)'
    ELSE DEAL_START
    END as DEAL_START,
    AD_GET_FIELDNAME('comp_code',compcode,'PROGRAMME_TY',PRG_TYPE,'NAME','TV_AD_PROGRAMME_TY','','') as PRG_TYPE,
     AD_GET_FIELDNAME('Comp_Code',compcode,'Adv_Cat_Code',AD_CTG,'Adv_Cat_Name','Adv_Cat_Mast','','') as AD_CTG,
      CASE COMM_ALLOW
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE COMM_ALLOW
    END as COMM_ALLOW,
    nvl(REMARKS,'') as REMARKS, nvl(RATE_CODE,'') as RATE_CODE,
    CASE DISC_ON
     WHEN '1' THEN 'Discount On Bill(1)'
    WHEN '2' THEN 'Discount through Credit Note(2)'
    ELSE DISC_ON
    END AS DISC_ON,
    nvl(to_char(SPN_ST_DT,'dd/mm/yyyy'),'') as SPN_ST_DT, nvl(to_char(SPN_END_DT,'dd/mm/yyyy'),'') as SPN_END_DT,nvl(INCENTIVE,'') as INCENTIVE,
    CASE APPROVED
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE APPROVED
    END as APPROVED, SEQNO,AD_GET_FIELDNAME('Comp_Code',compcode,'Uom_Code',RATE_TYPE,'Uom_Alias','UOM_MAST','','') as RATE_TYPE,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'SOURCE_TYPE',SOURCE,'NAME','TV_SOURCE_TYPE','','') as SOURCE,
    NVL(TOTALVAL,'') AS TOTALVAL
     FROM tv_deal_det WHERE DEALNO=dealcode;
else
open p_accounts1 for 
    SELECT 
    AD_GET_FIELDNAME('COMP_CODE',compcode,'CHANNEL',CHANNEL,'NAME','TV_AD_CHANNEL','','')  as CHANNEL,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'LOCCD',LOCATION_CODE,'NAME','TV_AD_LOCATION','','')  as LOCATION_CODE,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'AD_TYPE',AD_TYPE,'DES','TV_AD_TYPE','','')  as AD_TYPE,
    CASE  PB_FLG
    WHEN 'P' THEN 'Paid(P)'
    WHEN 'B' THEN 'Bonus(B)'
    ELSE PB_FLG
    END AS PB_FLG,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'PRG_ID',PRG_CODE,'SHORT_NAME','TV_AD_PROGRAMME','','')  as PRG_CODE,
   AD_GET_FIELDNAME('COMP_CODE',compcode,'TV_BTB_MST.BTB_CODE',BTB_CODE,'BTB_DESC','TV_BTB_MST','CHANNEL',CHANNEL)  as BTB_CODE,
  --  AD_GET_FIELDNAME('COMP_CODE',compcode,'BND_CODE',ROS_CODE,'BND_DESC','TV_BND_MST','BTB_CODE',BTB_CODE)  as ROS_CODE,
    NVL(ROS_CODE,'') as ROS_CODE,
    nvl(DAYS,'') as DAYS,nvl(NO_OF_INS,'') as NO_OF_INS,
    AD_GET_FIELDNAME('Comp_Code',compcode,'Combin_Code',PACKAGE_CODE,'Combin_Desc','Combin_Mast','','') as PACKAGE_CODE, 
    nvl(VALUE_FROM,'') as VALUE_FROM, nvl(VALUE_TO,'') as VALUE_TO,
     CASE  DISC_TYPE
    WHEN '1' THEN 'Free(1)'
    WHEN '2' THEN 'Discounted(2)'
    WHEN '3' THEN 'Fixed Rate(3)'
    ELSE DISC_TYPE
    END as DISC_TYPE, 
    nvl(DISC_VAL,'') as DISC_VAL,
    AD_GET_FIELDNAME('comp_code',compcode,'Premiumcode',PREM_CODE,'premiumname','ADVPOS_PREM_MAST','','') as PREM_CODE,
     nvl(CONTRACT_PREM_VALUE,'') as CONTRACT_PREM_VALUE,nvl(CONTRACT_RATE,'') as CONTRACT_RATE, nvl(CARD_RATE,'') as CARD_RATE, 
     nvl(DEVIATION_RATE,'') as DEVIATION_RATE,nvl(CARD_PREM_VALUE,'') as CARD_PREM_VALUE,nvl(MIN_SIZE,'') as MIN_SIZE, nvl(MAX_SIZE,'') as MAX_SIZE,
      AD_GET_FIELDNAME('Comp_Code',compcode,'Curr_Code',CURRENCY,'Curr_Name','Curr_Mast','','') as CURRENCY,
     CASE  DEAL_START
    WHEN 'A' THEN 'After Target Achived(A)'
    WHEN 'B' THEN 'From Begining(B)'
    ELSE DEAL_START
    END as DEAL_START,
    AD_GET_FIELDNAME('comp_code',compcode,'PROGRAMME_TY',PRG_TYPE,'NAME','TV_AD_PROGRAMME_TY','','') as PRG_TYPE,
     AD_GET_FIELDNAME('Comp_Code',compcode,'Adv_Cat_Code',AD_CTG,'Adv_Cat_Name','Adv_Cat_Mast','','') as AD_CTG,
      CASE COMM_ALLOW
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE COMM_ALLOW
    END as COMM_ALLOW,
    nvl(REMARKS,'') as REMARKS, nvl(RATE_CODE,'') as RATE_CODE,
    CASE DISC_ON
     WHEN '1' THEN 'Discount On Bill(1)'
    WHEN '2' THEN 'Discount through Credit Note(2)'
    ELSE DISC_ON
    END AS DISC_ON,
    nvl(SPN_ST_DT,'') as SPN_ST_DT, nvl(SPN_END_DT,'') as SPN_END_DT,nvl(INCENTIVE,'') as INCENTIVE,
    CASE APPROVED
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE APPROVED
    END as APPROVED, SEQNO,AD_GET_FIELDNAME('Comp_Code',compcode,'Uom_Code',RATE_TYPE,'Uom_Alias','UOM_MAST','','') as RATE_TYPE,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'SOURCE_TYPE',SOURCE,'NAME','TV_SOURCE_TYPE','','') as SOURCE,
    NVL(TOTALVAL,'') AS TOTALVAL
     FROM tv_deal_det WHERE DEALNO=dealcode and SEQNO=seqno_p;            
end if;      
end bindGridDetails_Contract;
/






/*********************************/

CREATE OR REPLACE PROCEDURE savecontractelec_detail
(
dealno_p in varchar2,
channel_p in varchar2,
location_p in varchar2,
advtype_p in varchar2,
paidbonus_p in varchar2,
progname_p in varchar2,
btb_p in varchar2,
ros_p in varchar2,
day_p in varchar2,
fct_p in varchar2,
package_p in varchar2,
valuefrom_p in varchar2,
valueto_p in varchar2,
disctype_p in varchar2,
discper_p in varchar2,
premium_p in varchar2,
contpremium_p in varchar2,
contrate_p in varchar2,
cardrate_p in varchar2,
deviation_p in varchar2,
cardprem_p in varchar2,
minsize_p in varchar2,
maxsize_p in varchar2,
currency_p in varchar2,
dealstart_p in varchar2,
progtype_p in varchar2,
category_p in varchar2,
commallow_p in varchar2,
remarks_p in varchar2,
ratecode_p in varchar2,
discon_p in varchar2,
sponfrom_p in varchar2,
sponto_p in varchar2,
compcode_p in varchar2,
userid_p in varchar2,
username_p in varchar2,
incentive_p in varchar2,
approved_p in varchar2,
unit_p in varchar2,
seqno_p in varchar2,
id_p in varchar2,
ratetype_p in varchar2,
source_p in varchar2,
totalval_p in varchar2
)
as
UNIT_M VARCHAR2(20);
COMPCODE_M VARCHAR2(20);
LOCATION_M VARCHAR2(20);
begin
select COMP_CODE,UNIT
 ,LOCID INTO COMPCODE_M,UNIT_M,LOCATION_M
 from tv_ad_channel z where CHANNEL=channel_p ;
if id_p is null then 
insert into tv_deal_det(COMP_CODE, UNIT, DEALNO, DEALDT, SEQNO, CHANNEL, LOCATION_CODE, AD_TYPE, PB_FLG, PRG_TYPE, PRG_CODE, BTB_CODE, ROS_CODE, DAYS, NO_OF_INS, AD_CTG, PACKAGE_CODE, VALUE_FROM, VALUE_TO, DISC_TYPE, DISC_VAL, DISC_ON, PREM_CODE, CARD_PREM_VALUE, CONTRACT_PREM_VALUE, CONTRACT_RATE, CARD_RATE, TOT_RATE, DEVIATION_RATE, MIN_SIZE, MAX_SIZE, DEAL_START, COMM_ALLOW, REMARKS, RATE_CODE, APPROVED, INCENTIVE, SPN_ST_DT, SPN_END_DT, USERID, USERNAME, USERDATE, USERIP, CURRENCY,RATE_TYPE,SOURCE, TOTALVAL)
values(COMPCODE_M,UNIT_M,dealno_p,sysdate,seqno_p,channel_p,LOCATION_M,advtype_p,paidbonus_p,progtype_p,progname_p,btb_p,ros_p,day_p,fct_p,category_p,package_p,valuefrom_p,valueto_p,disctype_p,discper_p,discon_p,premium_p ,cardprem_p,contpremium_p,contrate_p,cardrate_p,'0',deviation_p,minsize_p,maxsize_p,dealstart_p,commallow_p,remarks_p,ratecode_p,approved_p,incentive_p,sponfrom_p,sponto_p,userid_p,username_p,sysdate,'',currency_p,ratetype_p,source_p,totalval_p);
else
update tv_deal_det set CHANNEL=channel_p, LOCATION_CODE=LOCATION_M, AD_TYPE=advtype_p, PB_FLG=paidbonus_p, PRG_TYPE=progtype_p, PRG_CODE=progname_p, BTB_CODE=btb_p, ROS_CODE=ros_p, DAYS=day_p, NO_OF_INS=fct_p, AD_CTG=category_p, PACKAGE_CODE=package_p, VALUE_FROM=valuefrom_p, VALUE_TO=valueto_p, DISC_TYPE=disctype_p, DISC_VAL=discper_p, DISC_ON=discon_p, PREM_CODE=premium_p , CARD_PREM_VALUE=cardprem_p, CONTRACT_PREM_VALUE=contpremium_p, CONTRACT_RATE=contrate_p, CARD_RATE=cardrate_p, TOT_RATE='0', DEVIATION_RATE=deviation_p, MIN_SIZE=minsize_p, MAX_SIZE=maxsize_p, DEAL_START=dealstart_p, COMM_ALLOW=commallow_p, REMARKS=remarks_p, RATE_CODE=ratecode_p, APPROVED=approved_p, INCENTIVE=incentive_p, SPN_ST_DT=sponfrom_p, SPN_END_DT=sponto_p, CURRENCY=currency_p, RATE_TYPE=ratetype_p,SOURCE=source_p, TOTALVAL=totalval_p
where DEALNO=dealno_p and SEQNO=seqno_p;
end if; 
commit;
end;
/


/*******************************/
CREATE OR REPLACE PROCEDURE savecontract_detail
(
dealno_p in varchar2,
adtype_p in varchar2,
hue_p in varchar2,
uom_p in varchar2,
package_p in varchar2,
category_p in varchar2,
premium_p in varchar2,
cardprem_p in varchar2,
contractprem_p in varchar2,
contrate_p in varchar2,
cardrate_p in varchar2,
deviation_p in varchar2,
disctype_p in varchar2,
discper_p in varchar2,
discon_p in varchar2,
minsize_p in varchar2,
maxsize_p in varchar2,
valuefrom_p in varchar2,
valueto_p in varchar2,
day_p in varchar2,
insertion_p in varchar2,
commallow_p in varchar2,
dealstart_p in varchar2,
currency_p in varchar2,
ratecode_p in varchar2,
totalrate_p in varchar2,
incentive_p in varchar2,
remarks_p in varchar2,
approved_p in varchar2,
compcode_p in varchar2,
userid_p in varchar2,
id_p in varchar2
)
as
begin 
if id_p is null then
insert into contract_detail("ContractCode","deal_code",ADTYPE,"color","Uom","packagecode","Advcategory","premiumcode","cardpremium","dealpremium","Dealarte","cardrate","deviation","discounted",DISCTYPE,DISCPER,SIZEFROM,SIZETO,"valuefrom","valueto",DAYNAME,INSERTION,COMMITION_ALLOW,DEAL_START,"currency","Rate_code","convertrate",INCENTIVE,REMARKS,"approved","creation_datetime","comp_code","userid")
values(ContractCode_ident.NEXTVAL,dealno_p,adtype_p,hue_p,uom_p,package_p,category_p,premium_p,cardprem_p,contractprem_p,contrate_p,cardrate_p,deviation_p,disctype_p,discon_p,discper_p,minsize_p,maxsize_p,valuefrom_p,valueto_p,day_p,insertion_p,commallow_p,dealstart_p,currency_p,ratecode_p,totalrate_p,incentive_p,remarks_p,approved_p,sysdate,compcode_p,userid_p);

else
update  contract_detail set ADTYPE=adtype_p, "color"=hue_p,"Uom"=uom_p,"packagecode"=package_p,"Advcategory"=category_p,"premiumcode"=premium_p,"cardpremium"=cardprem_p,"dealpremium"=contractprem_p,"Dealarte"=contrate_p,"cardrate"=cardrate_p,"deviation"=deviation_p,"discounted"=disctype_p,DISCTYPE=discon_p,DISCPER=discper_p,SIZEFROM=minsize_p,SIZETO=maxsize_p,"valuefrom"=valuefrom_p,"valueto"=valueto_p,DAYNAME=day_p,INSERTION=insertion_p,COMMITION_ALLOW=commallow_p,DEAL_START=dealstart_p,"currency"=currency_p,"Rate_code"=ratecode_p,"convertrate"=totalrate_p,INCENTIVE=incentive_p,REMARKS=remarks_p,"approved"=approved_p
where "deal_code"=dealno_p and "ContractCode"=id_p;
end if; 
commit;
end;
/
/************************/



CREATE OR REPLACE PACKAGE checkcontractcode
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE checkcontractcode_p (
      compcode      IN       VARCHAR2,
      dealname      IN       VARCHAR2,
      dealno        IN       VARCHAR2,
      dealtype      IN       VARCHAR2,
      p_accounts    OUT      t_account_cursor,
      p_accounts1   OUT      t_account_cursor
   );
END checkcontractcode;
/





CREATE OR REPLACE PACKAGE BODY checkcontractcode
IS
   PROCEDURE checkcontractcode_p (
      compcode      IN       VARCHAR2,
      dealname      IN       VARCHAR2,
      dealno        IN       VARCHAR2,
      dealtype      IN       VARCHAR2,
      p_accounts    OUT      t_account_cursor,
      p_accounts1   OUT      t_account_cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
         SELECT "Deal_No"
           FROM contract_mast
          WHERE "Deal_No" = dealno AND "Comp_code" = compcode;

      OPEN p_accounts1 FOR
         SELECT "Deal_No"
           FROM contract_mast
          WHERE "deal_name" = dealname
            AND "deal_type" = dealtype
            AND "Comp_code" = compcode;
   END checkcontractcode_p;
END checkcontractcode;
/




/***********/

CREATE OR REPLACE PACKAGE insertcontactmast
IS
   PROCEDURE insertcontactmast_p (
      compcode         IN   VARCHAR2,
      userid           IN   VARCHAR2,
      dealno           IN   VARCHAR2,
      dealname         IN   VARCHAR2,
      agencycode       IN   VARCHAR2,
      subagencycode    IN   VARCHAR2,
      product          IN   VARCHAR2,
      validfromdate    IN   DATE,
      validtill        IN   DATE,
      representative   IN   VARCHAR2,
      clientname       IN   VARCHAR2,
      totalvalue       IN   NUMBER,
      totalvolume      IN   NUMBER,
      currencys        IN   VARCHAR2,
      teamname         IN   VARCHAR2,
      dealtype         IN   VARCHAR2,
      adtype1           IN   VARCHAR2,
      REMARK           IN  VARCHAR2,
      executive_var           IN  VARCHAR2,
        retainer_var           IN  VARCHAR2,
        contdate_var           IN  DATE,
        closedate_var           IN  DATE,
        servicetax_var           IN  VARCHAR2,
        caption_var           IN  VARCHAR2,
        paymode_var in varchar2,
        b2b_var in varchar2,
        chkmulti_var in varchar2,
        chkseq_var in varchar2,
        seqno_var in varchar2,
        chkparti_var in varchar2,
        indus_var in varchar2,
        induspro_var in varchar2,
        dealon_var in varchar2
   );
END insertcontactmast;
/



CREATE OR REPLACE PACKAGE BODY insertcontactmast
IS
   PROCEDURE insertcontactmast_p (
        compcode         IN   VARCHAR2,
        userid           IN   VARCHAR2,
        dealno           IN   VARCHAR2,
        dealname         IN   VARCHAR2,
        agencycode       IN   VARCHAR2,
        subagencycode    IN   VARCHAR2,
        product          IN   VARCHAR2,
        validfromdate    IN   DATE,
        validtill        IN   DATE,
        representative   IN   VARCHAR2,
        clientname       IN   VARCHAR2,
        totalvalue       IN   NUMBER,
        totalvolume      IN   NUMBER,
        currencys        IN   VARCHAR2,
        teamname         IN   VARCHAR2,
        dealtype         IN   VARCHAR2,
        adtype1           IN   VARCHAR2,
        REMARK           IN  VARCHAR2,
        executive_var           IN  VARCHAR2,
        retainer_var           IN  VARCHAR2,
        contdate_var           IN  DATE,
        closedate_var           IN  DATE,
        servicetax_var           IN  VARCHAR2,
        caption_var           IN  VARCHAR2,
        paymode_var in varchar2,
         b2b_var in varchar2,
        chkmulti_var in varchar2,
        chkseq_var in varchar2,
        seqno_var in varchar2,
        chkparti_var in varchar2,
        indus_var in varchar2,
        induspro_var in varchar2,
        dealon_var in varchar2
        )
   AS
   BEGIN
      INSERT INTO contract_mast
                  ("Deal_No", "Comp_code", "Agency_code", "Sub_Agency_Code",
                   "Client_code", "Product_code", "From_date", "Till_date",
                   "representative", "Userid", "Total_val", "Total_volu",
                   "curr_code", "team_code", "deal_type", "deal_name",
                   "Ad_type","Creation_datetime","REMARKS",EXECUTIVE, RETAINER, CONTRACTDATE, CLOSEDATE, SERVICETAX, PAYMENTTYPE, CAPTION, B2B, CHKMULTIAD, SEQNO_ALLOW, SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON
                  )
           VALUES (dealno, compcode, agencycode, subagencycode,
                   clientname, product, validfromdate, validtill,
                   representative, userid, totalvalue, totalvolume,
                   currencys, teamname, dealtype, dealname,
                   adtype1,sysdate,REMARK,executive_var,retainer_var,contdate_var,closedate_var,servicetax_var,paymode_var,caption_var,
                   b2b_var,chkmulti_var,chkseq_var,seqno_var,chkparti_var,indus_var,induspro_var,dealon_var
                  );

      COMMIT;
   END insertcontactmast_p;
END insertcontactmast;
/
/*****************************************/


CREATE OR REPLACE PACKAGE updatecontactmast
IS
   PROCEDURE updatecontactmast_p (
      compcode         IN   VARCHAR2,
      userid           IN   VARCHAR2,
      dealno           IN   VARCHAR2,
      dealname         IN   VARCHAR2,
      agencycode       IN   VARCHAR2,
      subagencycode    IN   VARCHAR2,
      product          IN   VARCHAR2,
      validfromdate    IN   DATE,
      validtill        IN   DATE,
      representative   IN   VARCHAR2,
      clientname       IN   VARCHAR2,
      totalvalue       IN   NUMBER,
      totalvolume      IN   NUMBER,
      currencys        IN   VARCHAR2,
      teamname         IN   VARCHAR2,
      dealtype         IN   VARCHAR2,
      adtype           IN   VARCHAR2,
       REMARK           IN  VARCHAR2,
      executive_var           IN  VARCHAR2,
        retainer_var           IN  VARCHAR2,
        contdate_var           IN  DATE,
        closedate_var           IN  DATE,
        servicetax_var           IN  VARCHAR2,
        caption_var           IN  VARCHAR2,
        paymode_var in varchar2,
         b2b_var in varchar2,
        chkmulti_var in varchar2,
        chkseq_var in varchar2,
        seqno_var in varchar2,
        chkparti_var in varchar2,
        indus_var in varchar2,
        induspro_var in varchar2,
        dealon_var in varchar2
   );
END updatecontactmast;
/


CREATE OR REPLACE PACKAGE BODY updatecontactmast
IS
   PROCEDURE updatecontactmast_p (
      compcode         IN   VARCHAR2,
      userid           IN   VARCHAR2,
      dealno           IN   VARCHAR2,
      dealname         IN   VARCHAR2,
      agencycode       IN   VARCHAR2,
      subagencycode    IN   VARCHAR2,
      product          IN   VARCHAR2,
      validfromdate    IN   DATE,
      validtill        IN   DATE,
      representative   IN   VARCHAR2,
      clientname       IN   VARCHAR2,
      totalvalue       IN   NUMBER,
      totalvolume      IN   NUMBER,
      currencys        IN   VARCHAR2,
      teamname         IN   VARCHAR2,
      dealtype         IN   VARCHAR2,
      adtype           IN   VARCHAR2,
       REMARK           IN  VARCHAR2,
      executive_var           IN  VARCHAR2,
        retainer_var           IN  VARCHAR2,
        contdate_var           IN  DATE,
        closedate_var           IN  DATE,
        servicetax_var           IN  VARCHAR2,
        caption_var           IN  VARCHAR2,
        paymode_var in varchar2,
         b2b_var in varchar2,
        chkmulti_var in varchar2,
        chkseq_var in varchar2,
        seqno_var in varchar2,
        chkparti_var in varchar2,
        indus_var in varchar2,
        induspro_var in varchar2,
         dealon_var in varchar2
   )
   AS
   BEGIN
      UPDATE contract_mast
         SET "deal_name" = dealname,
             "Agency_code" = agencycode,
             "Sub_Agency_Code" = subagencycode,
             "Client_code" = clientname,
             "Product_code" = product,
             "From_date" = validfromdate,
             "Till_date" = validtill,
             "representative" = representative,
             "Total_val" = totalvalue,
             "Total_volu" = totalvolume,
             "curr_code" = currencys,
             "team_code" = teamname,
             "deal_type" = dealtype,
             "Ad_type" = adtype,
             "REMARKS"=REMARK,
             EXECUTIVE=executive_var,
              RETAINER=retainer_var,
              CONTRACTDATE=contdate_var,
              CLOSEDATE=closedate_var,
               SERVICETAX=servicetax_var,
               PAYMENTTYPE=paymode_var,
                CAPTION=caption_var,
                B2B=b2b_var, CHKMULTIAD=chkmulti_var, SEQNO_ALLOW=chkseq_var, SEQNO=seqno_var, AFT_PRTCLR_AD=chkparti_var, INDUSTRY=indus_var, INDUSTRY_PRODUCT=induspro_var,
                DEALON=dealon_var
       WHERE "Deal_No" = dealno AND "Comp_code" = compcode;

      COMMIT;
   END updatecontactmast_p;
END updatecontactmast;
/
/**************/


CREATE OR REPLACE PACKAGE dealmodifychk
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE dealmodifychk_p (
      dealno        IN       VARCHAR2,
      dealname      IN       VARCHAR2,
      compcode      IN       VARCHAR2,
     dealtype      IN       VARCHAR2,
      --contract_id   IN       VARCHAR2,
      p_accounts    OUT      t_account_cursor
   );
END dealmodifychk;
/







CREATE OR REPLACE PACKAGE BODY dealmodifychk
IS
   PROCEDURE dealmodifychk_p (
     dealno        IN       VARCHAR2,
      dealname      IN       VARCHAR2,
      compcode      IN       VARCHAR2,
      dealtype      IN       VARCHAR2,
     -- contract_id   IN       VARCHAR2,
      p_accounts    OUT      t_account_cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
         SELECT *
           FROM contract_mast
          WHERE "deal_name" = dealname
           AND "deal_type" = dealtype
            AND "Comp_code" = compcode;
           -- AND "contract_id" != contract_id;
   END dealmodifychk_p;
END dealmodifychk;
/
/***********************************/




CREATE OR REPLACE PACKAGE executecontract IS
Type T_Accounts_Cursor is Ref Cursor;
PROCEDURE executecontract_P(
compcode in varchar2,
userid in varchar2,--
DealNo in varchar2,--
dealname in varchar2,--
agencycode in varchar2,--
subagencycode in varchar2,--
representative in varchar2,
dealtype in varchar2,
P_Accounts  OUT  T_Accounts_Cursor
);
end executecontract;
/



CREATE OR REPLACE PACKAGE BODY Executecontract
IS
  PROCEDURE executecontract_P(
              compcode IN VARCHAR2,
            userid IN VARCHAR2,--
            DealNo IN VARCHAR2,--
            dealname IN VARCHAR2,--
            agencycode IN VARCHAR2,--
            subagencycode IN VARCHAR2,--
            Representative IN VARCHAR2,
            dealtype IN VARCHAR2,
            P_Accounts  OUT  T_Accounts_Cursor)
    AS
    BEGIN
         OPEN P_Accounts FOR
         SELECT  "Deal_No","Comp_code",(select "Agency_Name"||'('|| "Agency_Code" ||')' from agency_mast where "Agency_Code"="Agency_code" and agency_mast."SUB_Agency_Code"=contract_mast."Sub_Agency_Code") as "Agency_code","Sub_Agency_Code",(select "Cust_Name"||'('||"Cust_Code"||')' from cust_mast where "Cust_Code"="Client_code") as "Client_code","Product_code",TO_CHAR("From_date",'mm/dd/yyyy') as "From_date",TO_CHAR("Till_date",'mm/dd/yyyy') as "Till_date","representative","Userid","Total_val","Total_volu","team_code","deal_type","deal_name","contract_id","Ad_type",REMARKS,(select "Exec_name"||'('||"Exe_no"||')' from exec_mast where "Exe_no"=EXECUTIVE) as EXECUTIVE, (select "Retain_Name"||'(' || "Retain_Code" || ')' from  retainermaster where "Retain_Code"=RETAINER) as RETAINER, TO_CHAR(CONTRACTDATE,'mm/dd/yyyy') as CONTRACTDATE,TO_CHAR(CLOSEDATE,'mm/dd/yyyy') as  CLOSEDATE, SERVICETAX, PAYMENTTYPE, CAPTION, B2B, CHKMULTIAD, SEQNO_ALLOW, SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON
          FROM CONTRACT_MAST
         WHERE ("Comp_code" = compcode OR compcode IS NULL)
         AND ("Deal_No" LIKE DealNo || '%' OR DealNo IS NULL)
         AND("deal_name"  LIKE dealname ||'%'OR dealname IS NULL)
         AND("Agency_code" LIKE agencycode||'%'OR agencycode IS NULL)
         AND("deal_type" LIKE dealtype||'%'OR dealtype IS NULL)
         AND("Sub_Agency_Code" LIKE subagencycode||'%'OR subagencycode IS NULL)
         AND("representative" LIKE Representative||'%'OR Representative IS NULL);

END executecontract_P;
END Executecontract;
/




/*********/


CREATE OR REPLACE PACKAGE bindpackageActive IS
TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE bindpackageActive_p(
compcode in varchar2,
userid in varchar2,
P_Accounts  OUT  T_accounts_cursor
);
End bindpackageActive;
/

CREATE OR REPLACE PACKAGE BODY bindpackageActive IS
PROCEDURE bindpackageActive_p(
compcode in varchar2,
userid in varchar2,
P_Accounts  OUT  T_accounts_cursor
)as
begin
OPEN P_Accounts FOR

select "Combin_Code","Package_Name",("Combin_Code" ||'@' ||"Combin_Desc") as "pck_code" from combin_mast
where "Comp_Code"=compcode and "Ad_Type_code"=userid AND "Combin_Code" not in(select PACKAGECODE FROM EDITIONSTATUS WHERE STATUS='I') order by "Package_Name";
end bindpackageActive_p;
End bindpackageActive;
/








/*******************************contract************************/

/***********************mimoh 30dec 2011*********deal****************************************/


CREATE OR REPLACE PROCEDURE tv_dealAudit (
   compcode_p     IN       VARCHAR2,
   adtype_p        IN       VARCHAR2,
   validfrom_p     IN       VARCHAR2,
   validto_p    IN       VARCHAR2,
   agency_p      IN       VARCHAR2,
   client_p    IN       VARCHAR2,
   dealno_p         IN       VARCHAR2,
   audittype_p      IN       VARCHAR2,
   dateformat_p     IN       VARCHAR2,   
   p_accounts   OUT      cur_type_new1.cursor_type
)
AS
BEGIN
IF audittype_p = '0' THEN
begin
   OPEN p_accounts FOR
      SELECT (select "Agency_Name"||'('|| "Agency_Code" ||')' from agency_mast where "Agency_Code"="Agency_code" and agency_mast."SUB_Agency_Code"=contract_mast."Sub_Agency_Code") as "Agency_code",
      (select "Cust_Name"||'('||"Cust_Code"||')' from cust_mast where "Cust_Code"="Client_code") as "Client_code","Deal_No","deal_name",
      "Product_code",CAPTION,TO_CHAR("From_date",dateformat_p) as "FROM_DATE",TO_CHAR("Till_date",dateformat_p) as "TILL_DATE",
      '' as TOTALVAL
        FROM contract_mast
       WHERE "Comp_code" = compcode_p
       AND "Creation_datetime" BETWEEN validfrom_p and validto_p
        AND ("Deal_No" = dealno_p OR dealno_p IS NULL OR dealno_p = '')
         AND (DEALON = adtype_p OR adtype_p IS NULL OR adtype_p = '')
         AND("Agency_code" LIKE agency_p||'%'OR agency_p IS NULL)
         AND ("Client_code" = client_p OR client_p IS NULL OR client_p = '');
         
end;
end if;
IF audittype_p = '1' THEN
begin
   OPEN p_accounts FOR
      SELECT (select "Agency_Name"||'('|| "Agency_Code" ||')' from agency_mast where "Agency_Code"="Agency_code" and agency_mast."SUB_Agency_Code"=contract_mast."Sub_Agency_Code") as "Agency_code",
      (select "Cust_Name"||'('||"Cust_Code"||')' from cust_mast where "Cust_Code"="Client_code") as "Client_code","Deal_No","deal_name",
      "Product_code",CAPTION,TO_CHAR("From_date",dateformat_p) as "FROM_DATE",TO_CHAR("Till_date",dateformat_p) as "TILL_DATE",
      '' as TOTALVAL
        FROM contract_mast
       WHERE "Comp_code" = compcode_p
       AND "Creation_datetime" BETWEEN validfrom_p and validto_p
        AND ("Deal_No" = dealno_p OR dealno_p IS NULL OR dealno_p = '')
         AND (DEALON = adtype_p OR adtype_p IS NULL OR adtype_p = '')
         AND("Agency_code" LIKE agency_p||'%'OR agency_p IS NULL)
         AND ("Client_code" = client_p OR client_p IS NULL OR client_p = '')
         AND (AUDITBY IS not NULL);
         
end;
end if;
IF audittype_p = '2' THEN
begin
   OPEN p_accounts FOR
      SELECT (select "Agency_Name"||'('|| "Agency_Code" ||')' from agency_mast where "Agency_Code"="Agency_code" and agency_mast."SUB_Agency_Code"=contract_mast."Sub_Agency_Code") as "Agency_code",
      (select "Cust_Name"||'('||"Cust_Code"||')' from cust_mast where "Cust_Code"="Client_code") as "Client_code","Deal_No","deal_name",
      "Product_code",CAPTION,TO_CHAR("From_date",dateformat_p) as "FROM_DATE",TO_CHAR("Till_date",dateformat_p) as "TILL_DATE",
      '' as TOTALVAL
        FROM contract_mast
       WHERE "Comp_code" = compcode_p
       AND "Creation_datetime" BETWEEN validfrom_p and validto_p
        AND ("Deal_No" = dealno_p OR dealno_p IS NULL OR dealno_p = '')
         AND (DEALON = adtype_p OR adtype_p IS NULL OR adtype_p = '')
         AND("Agency_code" LIKE agency_p||'%'OR agency_p IS NULL)
         AND ("Client_code" = client_p OR client_p IS NULL OR client_p = '')
         AND (AUDITBY IS NULL OR AUDITBY = '')
         AND (AUDIT_DATE IS NULL OR AUDIT_DATE = '')
         AND (AUDIT_COMMENT IS NULL OR AUDIT_COMMENT = '');
         
end;
end if;

         
END;
/

/**************************************/




CREATE OR REPLACE PROCEDURE tv_binddealforaudit
(
 compcode    IN       VARCHAR2,
      deal      IN       VARCHAR2,
      mod       IN       VARCHAR,
      p_account   OUT      cur_type_new1.cursor_type
)
 is
    
BEGIN
   OPEN p_account FOR
            SELECT DISTINCT "Deal_No","deal_name" FROM contract_mast WHERE "Comp_code" = compcode and DEALON=mod AND "deal_name" LIKE deal + '%';
END ;
/
/***************************************/


CREATE OR REPLACE PROCEDURE bindGridDetails_Contract
(
compcode in varchar2,
dealcode in varchar2,
seqno_p in varchar2,
p_accounts out Cur_Type_New1.cursor_type,
p_accounts1 out Cur_Type_New1.cursor_type
)
is 
begin
open p_accounts for 
    select  AD_GET_FIELDNAME('Comp_Code',compcode,'Adv_Type_Code',ADTYPE,'Adv_Type_Name','Adv_Type_Mast','','')  as ADTYPE,
    AD_GET_FIELDNAME('Comp_Code',compcode,'Col_Code',contract_detail."color",'Col_Name','Col_Mast','','') as color,
    AD_GET_FIELDNAME('Comp_Code',compcode,'Uom_Code',contract_detail."Uom",'Uom_Name','Uom_Mast','','') as Uom,
    AD_GET_FIELDNAME('Comp_Code',compcode,'Combin_Code',contract_detail."packagecode",'Combin_Desc','Combin_Mast','','') as packagecode,
    AD_GET_FIELDNAME('Comp_Code',compcode,'Adv_Cat_Code',contract_detail."Advcategory",'Adv_Cat_Name','Adv_Cat_Mast','','') as Advcategory,
    AD_GET_FIELDNAME('comp_code',compcode,'Premiumcode',contract_detail."premiumcode",'premiumname','ADVPOS_PREM_MAST','','') as premiumcode,
    nvl("cardpremium",'') as cardpremium,nvl("dealpremium",'') as dealpremium,nvl("Dealarte",'') as Dealarte,nvl("cardrate",'') as cardrate,
    nvl("deviation",'') as deviation,
    CASE  "discounted"
    WHEN '1' THEN 'Free(1)'
    WHEN '2' THEN 'Discounted(2)'
    WHEN '3' THEN 'Fixed Rate(3)'
    ELSE "discounted"
    END as discounted,
    nvl(DISCPER,'')  as DISCPER,
    CASE  DISCTYPE
    WHEN '1' THEN 'Discount On Bill(1)'
    WHEN '2' THEN 'Discount through Credit Note(2)'
    ELSE DISCTYPE
    END as DISCTYPE,
    nvl(SIZEFROM,'') as SIZEFROM,nvl(SIZETO,'') as SIZETO,
    nvl("valuefrom",'') as valuefrom,nvl("valueto",'') as valueto,nvl(DAYNAME,'') as DAYNAME,nvl(INSERTION,'') as INSERTION,
    CASE COMMITION_ALLOW
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE COMMITION_ALLOW
    END as COMMITION_ALLOW,
    CASE  DEAL_START
    WHEN 'A' THEN 'After Target Achived(A)'
    WHEN 'B' THEN 'From Begining(B)'
    ELSE DEAL_START
    END as DEAL_START,
    AD_GET_FIELDNAME('Comp_Code',compcode,'Curr_Code',"currency",'Curr_Name','Curr_Mast','','') as currency,nvl("Rate_code",'') as Rate_code,nvl("convertrate",'') as convertrate,nvl(INCENTIVE,'') as INCENTIVE,nvl(REMARKS,'') as REMARKS,
     CASE "approved"
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE "approved"
    END as approved,"ContractCode" as CONTRACTCODE
     from contract_detail where "deal_code"=dealcode;
if seqno_p is null then
open p_accounts1 for 
    SELECT 
    AD_GET_FIELDNAME('COMP_CODE',compcode,'CHANNEL',CHANNEL,'NAME','TV_AD_CHANNEL','','')  as CHANNEL,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'LOCCD',LOCATION_CODE,'NAME','TV_AD_LOCATION','','')  as LOCATION_CODE,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'AD_TYPE',AD_TYPE,'DES','TV_AD_TYPE','CHANNEL',CHANNEL)  as AD_TYPE,
    CASE  PB_FLG
    WHEN 'P' THEN 'Paid(P)'
    WHEN 'B' THEN 'Bonus(B)'
    ELSE PB_FLG
    END AS PB_FLG,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'PRG_ID',PRG_CODE,'SHORT_NAME','TV_AD_PROGRAMME','','')  as PRG_CODE,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'TV_BTB_MST.BTB_CODE',BTB_CODE,'BTB_DESC','TV_BTB_MST','CHANNEL',CHANNEL)  as BTB_CODE,
  --  AD_GET_FIELDNAME('COMP_CODE',compcode,'BND_CODE',ROS_CODE,'BND_DESC','TV_BND_MST','BTB_CODE',BTB_CODE)  as ROS_CODE,
    NVL(ROS_CODE,'') as ROS_CODE,
    nvl(DAYS,'') as DAYS,nvl(NO_OF_INS,'') as NO_OF_INS,
    AD_GET_FIELDNAME('Comp_Code',compcode,'Combin_Code',PACKAGE_CODE,'Combin_Desc','TV_COMBIN_MAST','','') as PACKAGE_CODE, 
    nvl(VALUE_FROM,'') as VALUE_FROM, nvl(VALUE_TO,'') as VALUE_TO,
     CASE  DISC_TYPE
    WHEN '1' THEN 'Free(1)'
    WHEN '2' THEN 'Discounted(2)'
    WHEN '3' THEN 'Fixed Rate(3)'
    ELSE DISC_TYPE
    END as DISC_TYPE, 
    nvl(DISC_VAL,'') as DISC_VAL,
    AD_GET_FIELDNAME('comp_code',compcode,'Premiumcode',PREM_CODE,'premiumname','ADVPOS_PREM_MAST','','') as PREM_CODE,
     nvl(CONTRACT_PREM_VALUE,'') as CONTRACT_PREM_VALUE,nvl(CONTRACT_RATE,'') as CONTRACT_RATE, nvl(CARD_RATE,'') as CARD_RATE, 
     nvl(DEVIATION_RATE,'') as DEVIATION_RATE,nvl(CARD_PREM_VALUE,'') as CARD_PREM_VALUE,nvl(MIN_SIZE,'') as MIN_SIZE, nvl(MAX_SIZE,'') as MAX_SIZE,
      AD_GET_FIELDNAME('Comp_Code',compcode,'Curr_Code',CURRENCY,'Curr_Name','Curr_Mast','','') as CURRENCY,
     CASE  DEAL_START
    WHEN 'A' THEN 'After Target Achived(A)'
    WHEN 'B' THEN 'From Begining(B)'
    ELSE DEAL_START
    END as DEAL_START,
    AD_GET_FIELDNAME('comp_code',compcode,'PROGRAMME_TY',PRG_TYPE,'NAME','TV_AD_PROGRAMME_TY','','') as PRG_TYPE,
     AD_GET_FIELDNAME('Comp_Code',compcode,'Adv_Cat_Code',AD_CTG,'Adv_Cat_Name','Adv_Cat_Mast','','') as AD_CTG,
      CASE COMM_ALLOW
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE COMM_ALLOW
    END as COMM_ALLOW,
    nvl(REMARKS,'') as REMARKS, nvl(RATE_CODE,'') as RATE_CODE,
    CASE DISC_ON
     WHEN '1' THEN 'Discount On Bill(1)'
    WHEN '2' THEN 'Discount through Credit Note(2)'
    ELSE DISC_ON
    END AS DISC_ON,
    nvl(to_char(SPN_ST_DT,'dd/mm/yyyy'),'') as SPN_ST_DT, nvl(to_char(SPN_END_DT,'dd/mm/yyyy'),'') as SPN_END_DT,nvl(INCENTIVE,'') as INCENTIVE,
    CASE APPROVED
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE APPROVED
    END as APPROVED, SEQNO,AD_GET_FIELDNAME('Comp_Code',compcode,'Uom_Code',RATE_TYPE,'Uom_Alias','UOM_MAST','','') as RATE_TYPE,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'SOURCE_TYPE',SOURCE,'NAME','TV_SOURCE_TYPE','','') as SOURCE,
    NVL(TOTALVAL,'') AS TOTALVAL
     FROM tv_deal_det WHERE DEALNO=dealcode;
else
open p_accounts1 for 
    SELECT 
    AD_GET_FIELDNAME('COMP_CODE',compcode,'CHANNEL',CHANNEL,'NAME','TV_AD_CHANNEL','','')  as CHANNEL,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'LOCCD',LOCATION_CODE,'NAME','TV_AD_LOCATION','','')  as LOCATION_CODE,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'AD_TYPE',AD_TYPE,'DES','TV_AD_TYPE','','')  as AD_TYPE,
    CASE  PB_FLG
    WHEN 'P' THEN 'Paid(P)'
    WHEN 'B' THEN 'Bonus(B)'
    ELSE PB_FLG
    END AS PB_FLG,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'PRG_ID',PRG_CODE,'SHORT_NAME','TV_AD_PROGRAMME','','')  as PRG_CODE,
   AD_GET_FIELDNAME('COMP_CODE',compcode,'TV_BTB_MST.BTB_CODE',BTB_CODE,'BTB_DESC','TV_BTB_MST','CHANNEL',CHANNEL)  as BTB_CODE,
  --  AD_GET_FIELDNAME('COMP_CODE',compcode,'BND_CODE',ROS_CODE,'BND_DESC','TV_BND_MST','BTB_CODE',BTB_CODE)  as ROS_CODE,
    NVL(ROS_CODE,'') as ROS_CODE,
    nvl(DAYS,'') as DAYS,nvl(NO_OF_INS,'') as NO_OF_INS,
    AD_GET_FIELDNAME('Comp_Code',compcode,'Combin_Code',PACKAGE_CODE,'Combin_Desc','Combin_Mast','','') as PACKAGE_CODE, 
    nvl(VALUE_FROM,'') as VALUE_FROM, nvl(VALUE_TO,'') as VALUE_TO,
     CASE  DISC_TYPE
    WHEN '1' THEN 'Free(1)'
    WHEN '2' THEN 'Discounted(2)'
    WHEN '3' THEN 'Fixed Rate(3)'
    ELSE DISC_TYPE
    END as DISC_TYPE, 
    nvl(DISC_VAL,'') as DISC_VAL,
    AD_GET_FIELDNAME('comp_code',compcode,'Premiumcode',PREM_CODE,'premiumname','ADVPOS_PREM_MAST','','') as PREM_CODE,
     nvl(CONTRACT_PREM_VALUE,'') as CONTRACT_PREM_VALUE,nvl(CONTRACT_RATE,'') as CONTRACT_RATE, nvl(CARD_RATE,'') as CARD_RATE, 
     nvl(DEVIATION_RATE,'') as DEVIATION_RATE,nvl(CARD_PREM_VALUE,'') as CARD_PREM_VALUE,nvl(MIN_SIZE,'') as MIN_SIZE, nvl(MAX_SIZE,'') as MAX_SIZE,
      AD_GET_FIELDNAME('Comp_Code',compcode,'Curr_Code',CURRENCY,'Curr_Name','Curr_Mast','','') as CURRENCY,
     CASE  DEAL_START
    WHEN 'A' THEN 'After Target Achived(A)'
    WHEN 'B' THEN 'From Begining(B)'
    ELSE DEAL_START
    END as DEAL_START,
    AD_GET_FIELDNAME('comp_code',compcode,'PROGRAMME_TY',PRG_TYPE,'NAME','TV_AD_PROGRAMME_TY','','') as PRG_TYPE,
     AD_GET_FIELDNAME('Comp_Code',compcode,'Adv_Cat_Code',AD_CTG,'Adv_Cat_Name','Adv_Cat_Mast','','') as AD_CTG,
      CASE COMM_ALLOW
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE COMM_ALLOW
    END as COMM_ALLOW,
    nvl(REMARKS,'') as REMARKS, nvl(RATE_CODE,'') as RATE_CODE,
    CASE DISC_ON
     WHEN '1' THEN 'Discount On Bill(1)'
    WHEN '2' THEN 'Discount through Credit Note(2)'
    ELSE DISC_ON
    END AS DISC_ON,
    nvl(SPN_ST_DT,'') as SPN_ST_DT, nvl(SPN_END_DT,'') as SPN_END_DT,nvl(INCENTIVE,'') as INCENTIVE,
    CASE APPROVED
    WHEN 'Y' THEN 'Yes(Y)'
    WHEN 'N' THEN 'No(N)'
    ELSE APPROVED
    END as APPROVED, SEQNO,AD_GET_FIELDNAME('Comp_Code',compcode,'Uom_Code',RATE_TYPE,'Uom_Alias','UOM_MAST','','') as RATE_TYPE,
    AD_GET_FIELDNAME('COMP_CODE',compcode,'SOURCE_TYPE',SOURCE,'NAME','TV_SOURCE_TYPE','','') as SOURCE,
    NVL(TOTALVAL,'') AS TOTALVAL
     FROM tv_deal_det WHERE DEALNO=dealcode and SEQNO=seqno_p;            
end if;      
end bindGridDetails_Contract;
/


/***********************************/



CREATE OR REPLACE PROCEDURE tv_paid_balance_cal (
   pcomp_code       IN       VARCHAR2,
   punit_code       IN       VARCHAR2,
   pchannel         IN       VARCHAR2,
   plocation_code   IN       VARCHAR2,
   pad_type         IN       VARCHAR2,
   pdealno          IN       VARCHAR2,
   pbtb_code        IN       VARCHAR2,
   ppaid_bonus      IN       VARCHAR2,
   p_accounts       OUT      cur_type_new1.cursor_type
)
IS
   vdur   NUMBER;
   v_no number;
BEGIN
   BEGIN
      SELECT SUM (NVL (dur, 0) * NVL (no_of_spot, 0))
        INTO vdur
        FROM tv_booking_det
       WHERE bkkno IN (
                SELECT bkkno
                  FROM tv_booking_mst
                 WHERE comp_code = pcomp_code
                   AND UNIT_CODE = punit_code
                   AND DEAL_NO = pdealno
                   AND (channel = pchannel OR pchannel IS NULL)
                   AND (loccd = plocation_code OR plocation_code IS NULL))
         AND btb_code = pbtb_code
         AND paid_bonus = ppaid_bonus;
   EXCEPTION
      WHEN NO_DATA_FOUND
      THEN
         vdur:=0;
   END;
   
    begin
         select nvl(NO_OF_INS,0) into v_no from tv_deal_det 
                    where comp_code = pcomp_code
                   AND unit = punit_code
                   AND dealno = pdealno
                   AND (channel = pchannel OR pchannel IS NULL)
                   AND (LOCATION_CODE= plocation_code OR plocation_code IS NULL)
                    AND btb_code = pbtb_code
                   AND PB_FLG = ppaid_bonus;
                    exception when no_data_found then 
                    v_no:=0;
          end;    

   OPEN p_accounts FOR
      SELECT vdur as "vdur", NVL (v_no, 0) - NVL (vdur, 0)  as "vbal"
        FROM DUAL;
END;
/



/***************************************/



CREATE OR REPLACE PACKAGE bindsubagencyforcontract IS
TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE bindsubagencyforcontract_p(
compcode in varchar2,
userid in varchar2,
agency in varchar2,
P_Accounts  OUT  T_Accounts_Cursor,P_Accounts1  OUT  T_Accounts_Cursor);
End bindsubagencyforcontract;
/





CREATE OR REPLACE PACKAGE BODY bindsubagencyforcontract IS
PROCEDURE bindsubagencyforcontract_p(
compcode in varchar2,
userid in varchar2,
agency in varchar2,
P_Accounts  OUT  T_Accounts_Cursor,P_Accounts1  OUT  T_Accounts_Cursor)as
count1 varchar2(8);
begin

select count(*) into count1 from agency_mast where "Comp_Code"=compcode  and "Agency_Code"=agency and "Type"<> 'P';

if(count1>0) then
open P_Accounts for
select "SUB_Agency_Code","Agency_Name" from agency_mast where "Comp_Code"=compcode  and "Agency_Code"=agency and "Type"<> 'P';

else
open P_Accounts for
select "SUB_Agency_Code","Agency_Name" from agency_mast where "Comp_Code"=compcode  and "Agency_Code"=agency and "Type"= 'P';
end if;

open P_Accounts1 for
select "Add1" || ' ' || "Add2" || ' ' || "Add3" AS "address"  from agency_mast where "Comp_Code"=compcode  and "Agency_Code"=agency;


end bindsubagencyforcontract_p;
End bindsubagencyforcontract;
/

/****************************************/


CREATE OR REPLACE PROCEDURE bindagencyforagency
(
 compcode    IN       VARCHAR2,
      client      IN       VARCHAR2,
      VALUE       IN       VARCHAR,
      datecheck   IN       VARCHAR,
      p_account   OUT      cur_type_new1.cursor_type
)
 is
    
BEGIN
   OPEN p_account FOR
            SELECT DISTINCT "Agency_Code", "Agency_Name",
                            ("Add1" || "Add2" || "Add3") AS address
                       FROM agency_mast
                      WHERE "Comp_Code" = compcode AND "code_subcode" = client and rownum<=1;
END ;
/

/*************************************************/



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

/******************************************/



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

/******************************************/



CREATE OR REPLACE PROCEDURE tv_dealauditupdate
(
pdealno IN VARCHAR2,
puserid IN VARCHAR2,
premark IN VARCHAR2

)
as
begin 

update contract_mast set AUDITBY=puserid,AUDIT_DATE=sysdate,AUDIT_COMMENT=premark where "Deal_No"=pdealno  ;

update tv_deal_det set APPROVED='Y' where DEALNO=pdealno;

commit;
end;
/

/**********************************************/


CREATE OR REPLACE PROCEDURE tv_binddealforaudit
(
 compcode    IN       VARCHAR2,
      deal      IN       VARCHAR2,
      mod1       IN       VARCHAR,
      p_account   OUT      cur_type_new1.cursor_type
)
 is
    
BEGIN
   OPEN p_account FOR
            SELECT DISTINCT "Deal_No","deal_name" FROM contract_mast; --WHERE "Comp_code" = compcode and DEALON='print' AND ("deal_name" LIKE deal + '%' or "deal_name" is null) ;
END ;
/

/***********************mimoh 30dec 2011*********deal*************6036***************************/


/*======================================= ISSUE 0005976 (Kuldeep Bhati) ==============================*/
CREATE OR REPLACE procedure committransaction(
    pcioid          in  varchar2,
    totalcount      in  int,
    pcompcode       in  varchar2,
    pcentname       in  varchar2,
    puserid         in  varchar2,
    pbkid_gentype   in  varchar2,
    pbk_type        in  varchar2,
    p_error         OUT VARCHAR2,
    p_new_cioid     OUT VARCHAR2) is
    
countnum        int;
newid           varchar2(100);
billpay         varchar2(20);
rostatus        varchar2(20);
remarks         varchar2(500);
clientname      varchar2(200);
v_cursor1       TYPES.cursor_type;
v_cursor2       TYPES.cursor_type;

v_cursor1_var1  varchar2(50);
v_cursor1_var2  varchar2(50);
v_cursor2_var1  varchar2(50);

begin
newid:=pcioid;

select count(*) into countnum from tbl_booking_insert_g where Cio_Booking_Id=pcioid;
if(countnum=totalcount) then 
     
    
   getautocodebooking.getautocodebooking_p (compcode        =>  pcompcode,
                                            auto1           =>  '0',
                                            no1             =>  '0',
                                            p_accounts      =>  v_cursor1,
                                            p_accounts1     =>  v_cursor2);
                                            
    FETCH v_cursor1 INTO v_cursor1_var1, v_cursor1_var2;
    
    FETCH v_cursor2 INTO v_cursor2_var1;
    
    if  pbkid_gentype='1' then--1 for First 3 character of Centre Name+Year + Slno  
        
        newid:=substr(pcentname,1,3)||v_cursor1_var2||LPAD(v_cursor1_var1,8,'0');
    
    elsif  pbkid_gentype='2' then--2 for First 3 character of Centre Name+Year + Userid + Slno
    
        newid:=substr(pcentname,1,3)||v_cursor1_var2||LPAD(v_cursor1_var1,8,'0')||puserid;

    elsif  pbkid_gentype='4' then--BK Type + Slno

        newid:=pbk_type||LPAD(v_cursor1_var1,8,'0');

    else

        newid:=LPAD(v_cursor1_var1,8,'0');

    end if; 
    
    p_error     :='Y';
    p_new_cioid := newid;

    INSERT INTO tbladid_ins(CIOID,COUNTNUM,FLAG) VALUES(newid,countnum,p_error);
    INSERT INTO TBL_BOOKING_MAST("date_time", "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by", "audit", "RO_No", "RO_Date", "Caption", "bill_status", "ro_status", "Agency_code", "Agency_address", "Client_code", "Client_address", "Agency_sub_code", "Dockit_no", "Executive_code", "Executive_zone", "Product_code", "Brand_code", "Key_no", "Bill_remarks", "Print_remark", "Package_code", "No_of_insertion", "Insertion_date", "Repeating_day", "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code", "Color_code", "Uom_code", "Page_position_code", "Page_type_code", "Page_no", "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code", "Scheme_type_code", "Currency_code", "Agrred_rate", "Agreed_amount", "Special_discount", "Space_discount", "Special_charges", "Agency_status", "Agency_type", "Agency_pay", "Agency_credit", "Total_area", "Card_rate", "Card_amount", "Discount", "Discount_per", "Bill_cycle", "Revenue_center", "Bill_pay", "Bill_height", "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc", "Agency_out", "Box_code", "Box_no", "Box_agency", "Box_client", "Box_address", "Comp_code", "Userid", "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad", "Campaign", "Bill_amount", "Page_prem", "Page_amount", "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", "Bill_area", "Special_disc_per", "Space_disc_per", "Paid_ins", "Contract_rate", "Deviation", "Variant_code", "Contract_name", "Contract_type", "Card_name", "Card_type", "Card_month", "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", "Bullet_code", "Bullet_premium", "Material_status", "Receipt_date", "prev_cioid", "prev_receipt", "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom", "SAPID", "RETAINER", "ADD_AGENCY_COMM", "AUDIT_COMMENT", "MOBILENO", "ADD_AGENCY_COMM_AMT", "RETAINER_COMM", "RETAINER_COMM_AMT", "CASH_RECIEVED", "CONT_GROSS", "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION", "CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER", "RODOCSTATUS",CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID,RECEIPT_CURRENCY, CONV_CURR_RATE,REVISE_DATE) 
    SELECT DATE_TIME, BRANCH, BOOKED_BY, newid CIO_BOOKING_ID, PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO, RO_DATE, CAPTION, BILL_STATUS, RO_STATUS, AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE, CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO, EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE, BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK, PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE, REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE, AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE, PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO, AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH, RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE, AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT, SPACE_DISCOUNT, SPECIAL_CHARGES, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY, AGENCY_CREDIT, TOTAL_AREA, CARD_RATE, CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE, REVENUE_CENTER, BILL_PAY, BILL_HEIGHT, BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD, TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO, BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS, COMP_CODE, USERID, CREATION_DATETIME, BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN, BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER, GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN, BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER, PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE, CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME, CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER, RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, BG_COLOR, BULLET_CODE, BULLET_PREMIUM, MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID, PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT, COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR, LOGO_UOM, SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO, ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS, CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, RODOCSTATUS,CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK, DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,REVISE_DATE FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=pcioid;

    INSERT INTO TBL_BOOKING_insert("Insert_Id", "Cio_Booking_Id", "No_Insert", "Edition_Code", "Publication_Code", "Pub_Cent_Code", "Supp_Code", "Edition", "Insert_Date", "Col_Code", "Height", "Width", "Size_Book", "Page_Post", "Premium1", "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow", "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Repeating_Date", "Status_Material", "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status", "Bill_Status", "Agreed_Rate", "Pai_Free_Ins", "Solo_Rate", "Gross_Rate", "Comp_Code", "Userid", "Page_No", "Remarks", "Pub_Height", "Pub_Width", "Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5", "PACKAGE_CODE", "BILL_NO", "BILL_DATE", "INSERTS", "PKG_ALIAS", "CONT_GROSS_AMT", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER",SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT, LOCALBILLAMT,SECTIONCODE,RESOURCE_NO) 
    SELECT INSERT_ID, newid CIO_BOOKING_ID, NO_INSERT, EDITION_CODE, PUBLICATION_CODE, PUB_CENT_CODE, SUPP_CODE, EDITION, INSERT_DATE, COL_CODE, HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1, PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW, AD_CAT, AD_SUB_CAT, LATEST_BY, REPEATING_DATE, STATUS_MATERIAL, FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS, BILL_STATUS, AGREED_RATE, PAI_FREE_INS, SOLO_RATE, GROSS_RATE, COMP_CODE, USERID, PAGE_NO, REMARKS, PUB_HEIGHT, PUB_WIDTH, PAGE_PREM, PAGE_PER, NO_OFCOLUMN, BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, PACKAGE_CODE, BILL_NO, BILL_DATE, INSERTS, PKG_ALIAS, CONT_GROSS_AMT, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, SPECIAL_SIZE1,VATAMT, BOXCHARGE, VAT_INC,LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=pcioid;

    INSERT INTO TBL_BOOKING_VTS(COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE) 
    SELECT COMPCODE, newid CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE FROM TBL_BOOKING_VTS_G WHERE  cioid=pcioid;

    insert into tbl_booking_insert_sizesplit(CIOID, RECEIPTNO, INSERTID, INSERTDATE, HEIGHT, WIDTH, AREA, SRNO, CREATIONDATETIME)
    select newid CIOID, RECEIPTNO, INSERTID, INSERTDATE, HEIGHT, WIDTH, AREA, SRNO, CREATIONDATETIME from tbl_booking_insert_sizesplit_g where cioid=pcioid;

    --INSERT INTO ABCTEST VALUES(newid,counttest);
    insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO, NO_INSERT)
    select COMP_CODE, newid CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO, SRNO, NO_INSERT from tbl_booking_subedition_g
    where tbl_booking_subedition_g.CIOID=pcioid;

    insert into TBL_BOOKING_SHARING_TRANS(PUBLICATION, TYPE, SHARING, CIOID, SRNO)
    select PUBLICATION, TYPE, SHARING, newid CIOID, SRNO from TBL_BOOKING_SHARING_TRANS_g where CIOID=pcioid ;

    insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID, CREATIONDATETIME)
    select newid CIOID, INSERTID, CREATIONDATETIME from TBL_BOOKING_FMG_TRANS_G where CIOID=cioid;

    select "Bill_pay","ro_status" into billpay,rostatus from tbl_booking_mast where "cio_booking_id"=newid;

    if billpay = 'CA0' and rostatus='1' then
        declare
            cursor c1 is
            select * from tbl_booking_mast where "cio_booking_id"=newid;
        v1 c1%rowtype;

        v_error      varchar2(2000);
        v_rcptno_r   varchar2(50);
        vrecpt       varchar2(20);
        branchcode   varchar2(20);
        vrepcode     varchar2(20);
        subagencyreg varchar2(20);
        prevcioid_v  varchar2(50);
        billamt_v    float;
        grossamt_v   float;
        v_curdate     date;
    begin
        open c1;
            fetch c1 into v1;
        Begin
            select "Branch_Code" into branchcode from branch_mst where "Comp_Code"=v1."Comp_code" and "Branch_Name"=v1."branch";
        Exception When no_data_found then
            branchcode:=v1."branch";
        End;
   
        Begin
            select "SUB_Agency_Code" into subagencyreg from agency_mast where "Comp_Code"=v1."Comp_code" and "code_subcode"=v1."Agency_sub_code";
        Exception When no_data_found then
            subagencyreg:='';
        End;
        vrecpt       :=v1."Receipt_no";
        prevcioid_v  :=v1."prev_cioid";
        if prevcioid_v is null or v1."prev_receipt" is null then
            billamt_v   :=v1."Bill_amount";
            grossamt_v  :=v1."Gross_amount";
            v_curdate   :=to_date(sysdate);
        else
            select "Bill_amount","Gross_amount" into  billamt_v,grossamt_v from tbl_booking_mast where "cio_booking_id"=prevcioid_v;
            billamt_v   :=v1."Bill_amount" - billamt_v;
            grossamt_v :=v1."Gross_amount" - grossamt_v;
            IF grossamt_v=0 OR grossamt_v IS NULL THEN
                grossamt_v:=v1."Gross_amount";
            END IF;
            v_curdate  :=to_date(sysdate);
        end if;

        -- select substr(max("recptno"),1,12)||lpad(substr(max("recptno"),-6)+1,6,'0') into vrecpt from ad_rcpthdr where "unit"=branchcode and "doctype"='RCP' and
        -- "recptdt" between '1-mar-2011' and '31-mar-2011';
         
        --receiptsave_booking.receiptsave_booking_P(pcompcode,puserid , punit ,ptype , precpt , prdate , ppaymodres ,preceivedreg ,pvouno  ,pamount  ,pagency , pothercd ,
        --pchno  ,pchedate , pbank  , pnarration ,prep   , pvdate , pag_main_code ,pag_sub_code , ourbank,  cioid , execname , retainer ,
        -- prevcioid , p_error)
        begin
            SELECT "Cust_Name" into clientname FROM CUST_MAST WHERE "Cust_Code" = v1."Client_code" and "Comp_Code"=v1."Comp_code";
        exception when NO_DATA_FOUND THEN
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
 p_error        :=  'N';
 p_new_cioid    :=  newid;
--DELETE FROM TBL_BOOKING_INSERT WHERE "Cio_Booking_Id"=cioid;
--DELETE FROM TBL_BOOKING_mast WHERE "cio_booking_id"=cioid;
INSERT INTO tbladid_ins(CIOID,COUNTNUM,FLAG) VALUES(newid,countnum,p_error);
end if;
--delete from tbl_booking_mast_g where  CIO_BOOKING_ID=cioid;
--delete from tbl_booking_insert_g where  CIO_BOOKING_ID=cioid;
--delete from tbl_booking_vts_g where  cioid=newid;
end;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE GETAUTOCODEBOOKING_PRE_SAVE IS
   TYPE t_accounts_cursor IS REF CURSOR;
   PROCEDURE GETAUTOCODEBOOKING_PRE_SAVE_P (
      compcode     IN       VARCHAR2,
      auto1        IN       VARCHAR2,
      no1          IN       VARCHAR2,
      p_accounts   OUT      t_accounts_cursor,
      p_accounts1  OUT      t_accounts_cursor
   );
END GETAUTOCODEBOOKING_PRE_SAVE;
/
CREATE OR REPLACE PACKAGE BODY GETAUTOCODEBOOKING_PRE_SAVE
IS
   PROCEDURE GETAUTOCODEBOOKING_PRE_SAVE_P (
      compcode      IN       VARCHAR2,
      auto1         IN       VARCHAR2,
      no1           IN       VARCHAR2,
      p_accounts    OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor
   )
   AS
      idcou   NUMBER:=0;
      maxid   NUMBER;
      
   BEGIN
   
    SELECT COUNT(*) INTO idcou FROM ad_tableid_pre_save;
      
       IF (idcou > 0) THEN
            OPEN  p_accounts FOR SELECT MAX("Booking_id") + 1 AS "ID",to_char(sysdate,'yyyy') as YEAR1 FROM ad_tableid_pre_save;
               
            OPEN  p_accounts1 FOR select 'a' as "a" from dual;
            
          begin
            SELECT MAX("Booking_id") + 1 INTO maxid FROM ad_tableid_pre_save;
            exception when no_data_found then NULL ;
          end;

            UPDATE ad_tableid_pre_save SET "Booking_id" = maxid;
       ELSE
            INSERT INTO ad_tableid_pre_save ("Booking_id") VALUES ('1');
            
           OPEN  p_accounts FOR SELECT MAX ("Booking_id") AS "ID",to_char(sysdate,'yyyy') as YEAR1 FROM ad_tableid_pre_save;
           OPEN  p_accounts1 FOR select 'a' as "a" from dual;
       END IF;

   END GETAUTOCODEBOOKING_PRE_SAVE_P;
END GETAUTOCODEBOOKING_PRE_SAVE;
/

/*======================================= End of ISSUE 0005976 (Kuldeep Bhati) ==============================*/
=========================================anklit ISSUE 6169=====================================================
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
decode(TEMPBOOKING_MAST_AUDIT."Booking_type",'1','BARTER','2','FMG','3','NORMAL','4','INHOUSE','5','Complimentary','6','Corrindom') as "Book_type",
(SELECT "catname"  FROM  AD_CAT3   WHERE

AD_CAT3."catcode"=TEMPBOOKING_MAST_AUDIT."Ad_Subcat3")   as "SUBCAT3",(SELECT "Cat_Name"  FROM  TBL_CAT4   WHERE

TBL_CAT4."Cat_Code"=TEMPBOOKING_MAST_AUDIT."Ad_Subcat4") as "SUBCAT4"  ,(SELECT "Cat_Name"  FROM  TBL_CAT5   WHERE

TBL_CAT5."Cat_Code"=TEMPBOOKING_MAST_AUDIT."Ad_subcat5") as "SUBCAT5",(SELECT "Comm_Rate" FROM ret_comm_details WHERE

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
===============================================end issue 6169============================================================
==============================================ankit  issue 6173===========================================================


CREATE OR REPLACE PACKAGE Bindaudit
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
                              END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                              END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                              END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                              END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                      END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                      END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                      END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                      END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                      END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                      END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                      END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                      END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                                  END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                                  END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                              END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                              END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                      END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
                      END AS "Creation_datetime",tbl_booking_mast.ATTACHMENT1 as ATTACHMENT
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
====================================================closed  issue 6173 =========================================================================================
/*====================================3jan2012===  mimoh mahajan ==============================*/


CREATE OR REPLACE PACKAGE GETAUTOCODEBOOKING_PRE_SAVE IS
   TYPE t_accounts_cursor IS REF CURSOR;
   PROCEDURE GETAUTOCODEBOOKING_PRE_SAVE_P (
      compcode     IN       VARCHAR2,
      auto1        IN       VARCHAR2,
      no1          IN       VARCHAR2,
      p_accounts   OUT      t_accounts_cursor,
      p_accounts1  OUT      t_accounts_cursor
   );
END GETAUTOCODEBOOKING_PRE_SAVE;
/





CREATE OR REPLACE PACKAGE BODY GETAUTOCODEBOOKING_PRE_SAVE
IS
   PROCEDURE GETAUTOCODEBOOKING_PRE_SAVE_P (
      compcode      IN       VARCHAR2,
      auto1         IN       VARCHAR2,
      no1           IN       VARCHAR2,
      p_accounts    OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor
   )
   AS
      idcou   NUMBER:=0;
      maxid   NUMBER;
      
   BEGIN
   
    SELECT COUNT(*) INTO idcou FROM ad_tableid_pre_save;
      
       IF (idcou > 0) THEN
            OPEN  p_accounts FOR SELECT MAX("Booking_id") + 1 AS "ID",to_char(sysdate,'yyyy') as YEAR1 FROM ad_tableid_pre_save;
               
            OPEN  p_accounts1 FOR select 'a' as "a" from dual;
            
          begin
            SELECT MAX("Booking_id") + 1 INTO maxid FROM ad_tableid_pre_save;
            exception when no_data_found then NULL ;
          end;

            UPDATE ad_tableid_pre_save SET "Booking_id" = maxid;
       ELSE
            INSERT INTO ad_tableid_pre_save ("Booking_id") VALUES ('1');
            
           OPEN  p_accounts FOR SELECT MAX ("Booking_id") AS "ID",to_char(sysdate,'yyyy') as YEAR1 FROM ad_tableid_pre_save;
           OPEN  p_accounts1 FOR select 'a' as "a" from dual;
       END IF;

   END GETAUTOCODEBOOKING_PRE_SAVE_P;
END GETAUTOCODEBOOKING_PRE_SAVE;
/



/*====================================3jan2012===  mimoh mahajan ==============================*/
/*====================================3jan2012===  mimoh mahajan ==============================*/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER Procedure [dbo].[bindagencyforxls](
@compcode as varchar(10),
@agency as varchar(50)
)
 As

declare @qry  varchar(2000)
Begin


select  distinct  Agency_Code,Agency_Name+'-'+(Select distinct city_name from city_mst x where x.City_Code=Agency_mast.City_Code)
+'-'+Add1++'-'+Add2+'-'+Add3+Street AS Agency_Name,code_subcode, SUB_Agency_Code from Agency_mast where (Comp_Code=@compcode) and Agency_Name like '%'+ @agency + '%'  and (Type='P') order by Agency_Name

End

/***********************************/


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[xlsRetainerbind](
  @Compcode as VARCHAR(50),
  @retainer as VARCHAR(50)
  )
  AS
  BEGIN
  
    SELECT  Retain_Code,Retain_Name  FROM RETAINERMASTER WHERE Comp_Code= @Compcode and Retain_Name like '%'+ @retainer + '%' order by Retain_Name


END


/*====================================3jan2012===  mimoh mahajan ==============================*/



/*================================================3jan2012===  ankit  6181======== ==============================*/



CREATE OR REPLACE PACKAGE Cat_Exe1 IS
TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE CAT_EXE1_P(
compcode IN VARCHAR2,
subcatname IN VARCHAR2,
catcode IN VARCHAR2,
catname IN VARCHAR2,
catalias IN VARCHAR2,
xml IN VARCHAR2,
p_Accounts OUT T_Accounts_Cursor);
END Cat_Exe1;
/



CREATE OR REPLACE PACKAGE BODY Cat_Exe1 IS
PROCEDURE CAT_EXE1_P(
compcode IN VARCHAR2,
subcatname IN VARCHAR2,
catcode IN VARCHAR2,
catname IN VARCHAR2,
catalias IN VARCHAR2,
xml IN VARCHAR2,
p_Accounts OUT T_Accounts_Cursor)AS
BEGIN

OPEN P_Accounts FOR
 SELECT *  FROM AD_CAT3 WHERE ("compcode"=compcode OR compcode IS NULL)
AND ("subcatname" LIKE subcatname || '%' OR subcatname IS NULL)
AND ("catname" LIKE catname || '%' OR catname IS NULL)
AND ("catcode"=catcode OR catcode IS NULL)

AND ("catalias" LIKE catalias || '%' OR catalias IS NULL);





 /*AND ("subcatname"=subcatname||'%')AND("catname"LIKE catname||'%')
AND ("catcode"LIKE catcode||'%') AND ("catalias"LIKE catalias||'%') AND ("adminwebxml" LIKE xml||'%');

ELSIF subcatname IS NOT NULL THEN
OPEN P_Accounts FOR
 SELECT *  FROM AD_CAT3 WHERE
("compcode"=compcode OR compcode IS NULL)
AND ("subcatname"=subcatname||'%');
--and("catname"like catname||'%')
--and ("catcode"like catcode||'%')
--and ("catalias"like catalias||'%')
--and ("adminwebxml" like xml||'%');

ELSIF catcode IS NOT NULL THEN
OPEN P_Accounts FOR
 SELECT *  FROM AD_CAT3 WHERE
("compcode"=compcode OR compcode IS NULL)
--and ("subcatname"=subcatname||'%')
--and("catname"like catname||'%');
AND ("catcode"LIKE catcode||'%');
--and ("catalias"like catalias||'%')
--and ("adminwebxml" like xml||'%');

ELSIF catname IS NOT NULL THEN
OPEN P_Accounts FOR
 SELECT *  FROM AD_CAT3 WHERE
("compcode"=compcode OR compcode IS NULL)
--and ("subcatname"=subcatname||'%')
AND("catname"LIKE catname||'%');
--and ("catcode"like catcode||'%')
--and ("catalias"like catalias||'%')
--and ("adminwebxml" like xml||'%');

ELSIF catalias IS NOT NULL THEN
OPEN P_Accounts FOR
 SELECT *  FROM AD_CAT3 WHERE
("compcode"=compcode OR compcode IS NULL)
--and ("subcatname"=subcatname||'%')
--and("catname"like catname||'%');
--and ("catcode"like catcode||'%')
AND ("catalias"LIKE catalias||'%');
--and ("adminwebxml" like xml||'%');

ELSIF xml IS NOT NULL THEN
OPEN P_Accounts FOR
 SELECT *  FROM AD_CAT3 WHERE
("compcode"=compcode OR compcode IS NULL)
--and ("subcatname"=subcatname||'%')
--and("catname"like catname||'%');
--and ("catcode"like catcode||'%')
--and ("catalias"like catalias||'%');
AND ("adminwebxml" LIKE xml||'%');

ELSE
OPEN P_Accounts FOR
 SELECT *  FROM AD_CAT3 WHERE
("compcode"=compcode OR compcode IS NULL);
--and ("subcatname"=subcatname||'%')
--and("catname"like catname||'%');
--and ("catcode"like catcode||'%')
--and ("catalias"like catalias||'%');
--and ("adminwebxml" like xml||'%');
END IF;
*/
END CAT_EXE1_P;
END Cat_Exe1;
/




CREATE OR REPLACE PACKAGE Cat3_MODIFY
 is

procedure   Cat3_MODIFY_p(compcode in varchar2,
subcatname in varchar2,
catname in varchar2,
catalias in varchar2,
catcode in varchar2,
userid in varchar2,
xml in varchar2,
prior1 in number,
status1 in varchar2

);
end Cat3_MODIFY;
/




CREATE OR REPLACE PACKAGE BODY Cat3_MODIFY
 is

procedure   Cat3_MODIFY_p(compcode in varchar2,
subcatname in varchar2,
catname in varchar2,
catalias in varchar2,
catcode in varchar2,
userid in varchar2,
xml in varchar2,
prior1 in number,
status1 in varchar2

) as
begin
update ad_cat3 set "compcode"=compcode, "subcatname"=subcatname,"catname"=catname,"catalias"=catalias,"userid"=userid ,"adminwebxml"=xml,PRIORITY=prior1,STATUS=status1 where "catcode"=catcode;

commit;
end Cat3_MODIFY_p;
end Cat3_MODIFY;
/



CREATE OR REPLACE PACKAGE cat3save Is

Procedure cat3save_P (
compcode in varchar2,
subcatname in varchar2,
catname in varchar2,
catalias in varchar2,
catcode in varchar2,
userid  in varchar2,
xml in varchar2,
prior1 in number,
status1 in varchar2
);

End cat3save;
/




CREATE OR REPLACE PACKAGE BODY cat3save Is


Procedure cat3save_P (
compcode in varchar2,
subcatname in varchar2,
catname in varchar2,
catalias in varchar2,
catcode in varchar2,
userid  in varchar2,
xml in varchar2,
prior1 in number,
status1 in varchar2
)As

Begin

insert into ad_cat3("compcode","subcatname","catname","catcode","catalias","userid","adminwebxml",PRIORITY,STATUS)
values(compcode,subcatname,catname,catcode,catalias,userid,xml,prior1,status1);



Commit;

End cat3save_P;

End cat3save;
/




/*================================================3jan2012===  ankit  6181======== ==============================*/
/************************************************************4jan2012***********/



CREATE OR REPLACE PACKAGE getautocodebox
IS
   TYPE t_accounts_cursor IS REF CURSOR;
   PROCEDURE getautocodebox_p (
      compcode     IN       VARCHAR2,
      auto1        IN       VARCHAR2,
      no1          IN       VARCHAR2,
      center1      IN       varchar2,
      agency_codescode      IN       varchar2,
       branch            IN VARCHAR2,
       save_val in varchar2,
      p_accounts   OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor,
      p_accounts2   OUT      t_accounts_cursor
   );
END getautocodebox;
/





CREATE OR REPLACE PACKAGE BODY getautocodebox
IS
   PROCEDURE getautocodebox_p (
      compcode      IN       VARCHAR2,
      auto1         IN       VARCHAR2,
      no1          IN       VARCHAR2,
      center1      IN       varchar2,
      agency_codescode      IN       varchar2,
      branch            IN VARCHAR2,
      save_val in varchar2,
      p_accounts   OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor,
      p_accounts2   OUT      t_accounts_cursor
   )
   AS
      idcou NUMBER (10);
      maxid   NUMBER (10);
      countnum int;
      fatchboxadd VARCHAR2(1000);
      begin
                  --begin
                 --SELECT MAX (TO_NUMBER (SUBSTR ("Box_no", 3, LENGTH ("Box_no")))) INTO idcou FROM ad_tableid;
                  --exception when no_data_found then NULL ;
                 --end;
                 
         select BOX_ADDRESS INTO fatchboxadd from branch_mst where "Branch_Code"=branch and "Comp_Code"=compcode AND ROWNUM<=1;
        
         select count(*) into idcou from ad_tableid;
         if(auto1 is not null) then
         
             IF (idcou >0) THEN
                OPEN p_accounts FOR SELECT nvl(MAX(TO_NUMBER(SUBSTR("Box_no",3,LENGTH ("Box_no")))),0) AS "boxno" FROM ad_tableid;

                OPEN p_accounts1 FOR SELECT "Box_Charges_Native","Box_Charges_Type" FROM box_mast
                WHERE "Box_Code" = no1 AND "Comp_Code" = compcode;

               -- idcou := idcou + 1;
               
                select nvl(MAX(TO_NUMBER(SUBSTR("Box_no",3,LENGTH ("Box_no")))),0) + 1 into idcou from ad_tableid ;
                if nvl(save_val,'?')='S' then
                   UPDATE ad_tableid SET "Box_no" = auto1 || TO_CHAR (idcou);
                   commit;
                end if;   
             ELSE
                INSERT INTO ad_tableid ("Box_no")  VALUES (auto1 || '1');

                OPEN p_accounts FOR SELECT MAX(TO_NUMBER(SUBSTR("Box_no",3,LENGTH ("Box_no")))) AS "boxno" FROM ad_tableid;

                OPEN p_accounts1 FOR SELECT "Box_Charges_Native","Box_Charges_Type" FROM box_mast
                           WHERE "Box_Code" = no1 AND "Comp_Code" = compcode;
             END IF;
         else
                 OPEN p_accounts FOR select 'a' from dual;
                 OPEN p_accounts1 FOR select 'a' from dual; 
         end if;
         IF fatchboxadd = '' THEN
                 select count(*) into countnum from pub_cent_box_add where centercode=center1;
                 if(center1 is not null) then
                    if countnum>0 then
                      OPEN p_accounts2 FOR
                        select ENGLISH_BOX,HINDI_BOX,PUNJABI_BOX from pub_cent_box_add where CENTERCODE=center1;
                    else
                    OPEN p_accounts2 FOR
                         select BOXADDRESS,BOXADDRESS,BOXADDRESS from pub_cent_mast where "Pub_cent_Code"=center1;    
                    end if;
                  
                 else
                    OPEN p_accounts2 FOR
                    select BOXADDRESS from pub_cent_mast where "City_Code"=(select "City_Code" from agency_mast where "code_subcode"=agency_codescode);
                end if;
        ELSE
                OPEN p_accounts2 FOR
                 select BOX_ADDRESS AS BOXADDRESS from branch_mst where "Branch_Code"=branch and "Comp_Code"=compcode;        
        END IF;
      end getautocodebox_p;
end getautocodebox;
/

/************************************************************4jan2012***********/


/*********************************************************************  4jan2012 ankit   5805 ************************************************/


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
DECODE( DECODE("Agency_Type_Code",''IA0'',''GOVT.'',''DA0'',''GOVT.''),''GOVT.'',''GOVT.'', DECODE(AGENCY_MAST."State_Code",''ORISSA'',''LOCAL'',''NATIONAL'') )  AS "FinalGRP",
i."Edition" as "edition",
(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
sysdate as "Rundate"
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



 OPEN p_accounts FOR Vquery;


END representative_p;
END Representative;
/

/*********************************************************************  4jan2012 ankit   5805 ************************************************/

/*******************************************mimoh***********0006156******4jan2012***********/


CREATE OR REPLACE PACKAGE wesp_Modultuser
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE wesp_wesp_Modultuser_p(
      compcode     IN       VARCHAR2,
       userid IN VARCHAR2:=NULL,
       userhome IN VARCHAR2:=NULL,
        ADMIN1 IN  VARCHAR2:=NULL,
        Retainer in varchar2,
        username1    in varchar2,
        p_extra1    in varchar2,
        p_extra2    in varchar2,
      p_accounts   OUT      t_account_cursor
   );
END wesp_Modultuser;
/





CREATE OR REPLACE PACKAGE BODY wesp_Modultuser
IS
   PROCEDURE wesp_wesp_Modultuser_p(
      compcode     IN       VARCHAR2,
       userid IN VARCHAR2:=NULL,
       userhome IN VARCHAR2:=NULL,
        ADMIN1 IN  VARCHAR2:=NULL,
        Retainer in varchar2,
        username1    in varchar2,
         p_extra1    in varchar2,
        p_extra2    in varchar2,
      p_accounts   OUT      t_account_cursor
   )
   AS
     agename  VARCHAR2(15);

   BEGIN



--select distinct a.username,b.userid from module_detail b,login a where a.userid=b.userid

IF(ADMIN1='yes' AND userhome='Agency')THEN

    SELECT "Agency_code" INTO agename FROM LOGIN WHERE "userid"=userid;
    OPEN p_accounts FOR
    SELECT DISTINCT "username"|| '(' || FIRSTNAME || ' ' || LASTNAME||')' as "username","userid" FROM LOGIN WHERE "COM_CODE"=compcode AND "Company_user"='Agency' AND "Agency_code"=agename and (UPPER("username") like '%' ||UPPER(username1)|| '%' or UPPER(LASTNAME) like '%' ||UPPER(username1)|| '%') order by "username";

ELSE
     OPEN p_accounts FOR
    SELECT DISTINCT "username"|| '(' || FIRSTNAME || ' ' || LASTNAME||')' as  "username","userid","Admin","Company_user" FROM LOGIN WHERE "COM_CODE"=compcode and (UPPER("username") like '%' ||UPPER(username1)|| '%' or UPPER(LASTNAME) like '%' ||UPPER(username1)|| '%') order by "username";
END IF;

   END wesp_wesp_Modultuser_p;
END wesp_Modultuser;
/



/*******************************************mimoh***********0006156******4jan2012***********/

/*******************************************mimoh*****************5jan2012***********/
CREATE OR REPLACE PROCEDURE websp_get10clientName(
compcode    in varchar2,
client      in varchar2:=null,
center      in varchar2,
P_Accounts  OUT      cur_type_new1.cursor_type)
IS
    v_f2_record number;
BEGIN

    select f2_record into v_f2_record  from preferrences where "comp_code"=compcode;
    
    if v_f2_record=0 or v_f2_record is null then
        v_f2_record:=10;
    end if;
    
    if(center != '0' and center is not null) then
      OPEN P_Accounts FOR
         select "Cust_Code" as "Cust_Code","Cust_Name" as "Cust_Name","Add1"  from cust_mast where "Comp_Code"=compcode and "Cust_Name" 
         like /*'%' ||*/ upper(client) || '%' and "Dist_Code"=(select "Dist_Code" from branch_mst where "Branch_Code"=center) and nvl("Cust_Status",'ACTIVE')='ACTIVE' and rownum<=v_f2_record order by "Cust_Name";
    else
        OPEN P_Accounts FOR
         select "Cust_Code" as "Cust_Code","Cust_Name" as "Cust_Name","Add1"  from cust_mast where "Comp_Code"=compcode and "Cust_Name" 
         like /*'%' ||*/ upper(client) || '%' and nvl("Cust_Status",'ACTIVE')='ACTIVE' and rownum<=v_f2_record order by "Cust_Name";
    end if;
END;
/

/*******************************************mimoh*****************5jan2012***********/

/*******************************************ANKIT*******6197**********6jan2012***********/


CREATE OR REPLACE PACKAGE branchinsert Is



Type T_Accounts_Cursor Is Ref Cursor;
Procedure branchinsert_P (compcode varchar2,
userid varchar2,
branchcode varchar2,
branchname  varchar2,
alias varchar2,
address varchar2,
street varchar2,
city varchar2,
dist varchar2,
state varchar2,
country varchar2,
fax varchar2,
pin varchar2,
phone1 varchar2,
phone2 varchar2,
email varchar2,
region varchar2,
zone varchar2,
pubcenter varchar2,
boxadd varchar2,
pbranchnick varchar2
);

End branchinsert;
/







CREATE OR REPLACE PACKAGE BODY branchinsert Is

 Procedure branchinsert_P (compcode varchar2,
userid varchar2,
branchcode varchar2,
branchname  varchar2,
alias varchar2,
address varchar2,
street varchar2,
city varchar2,
dist varchar2,
state varchar2,
country varchar2,
fax varchar2,
pin varchar2,
phone1 varchar2,
phone2 varchar2,
email varchar2,
region varchar2,
zone varchar2,
pubcenter varchar2,
boxadd varchar2,
pbranchnick varchar2
)

As

 Begin
 insert into branch_mst("Comp_Code", "Branch_Code", "Branch_Name", "Branch_Alias", "Add1", "Street", "Country_Code", "State_Code", "Dist_Code", "City_Code", "Zip", "Phone1", "Phone2", "Fax", "EmailID", "UserId", "Creation_Datetime", "Region_code", "Zone_code","pub_center",BOX_ADDRESS,BRANCH_NICK) values( compcode,  branchcode, branchname, alias,  address,  street, country,  state,  dist, city, pin, phone1,  phone2 , fax, email,  userid,  sysdate,region,zone, pubcenter,boxadd,pbranchnick);
 commit;
 End branchinsert_P;

 End branchinsert;
/







CREATE OR REPLACE PACKAGE branchupdate Is



Type T_Accounts_Cursor Is Ref Cursor;
Procedure branchupdate_P (compcode varchar2,
userid varchar2,
branchcode varchar2,
branchname  varchar2,
alias varchar2,
address varchar2,
street varchar2,
city varchar2,
dist varchar2,
state varchar2,
country varchar2,
fax varchar2,
pin varchar2,
phone1 varchar2,
phone2 varchar2,
email varchar2,
region varchar2,
zone varchar2,
pubcenter varchar2,
boxadd varchar2,
pbranchnick varchar2
);

End branchupdate;
/





CREATE OR REPLACE PACKAGE BODY branchupdate Is

 Procedure branchupdate_P (compcode varchar2,
userid varchar2,
branchcode varchar2,
branchname  varchar2,
alias varchar2,
address varchar2,
street varchar2,
city varchar2,
dist varchar2,
state varchar2,
country varchar2,
fax varchar2,
pin varchar2,
phone1 varchar2,
phone2 varchar2,
email varchar2,
region varchar2,
zone varchar2,
pubcenter varchar2,
boxadd varchar2,
pbranchnick varchar2) 

As

 Begin
 update branch_mst set "Branch_Name"=branchname, "Branch_Alias"=alias, "Add1"=address, "Street"=street, "Country_Code"=country, "State_Code"=state, "Dist_Code"=dist, "City_Code"=city, "Zip"=pin, "Phone1"=phone1, "Phone2"=phone2, "Fax"=fax, "EmailID"=email, "Region_code"=region, "Zone_code"=zone , "pub_center"=pubcenter,BOX_ADDRESS=boxadd,BRANCH_NICK=pbranchnick  where "Comp_Code"=compcode and /*"UserId"=userid and*/ "Branch_Code"=branchcode;

 commit;
 End branchupdate_P;

 End branchupdate;
/





CREATE OR REPLACE PACKAGE branchexe Is

Type T_Accounts_Cursor Is Ref Cursor;


Procedure branchexe_P(
compcode in varchar2,
userid in varchar2,
branchcode in varchar2,
branchname in varchar2,
alias in varchar2,
city in varchar2,
country IN varchar2,
pubcenter IN varchar2,
p_Accounts Out T_Accounts_Cursor );

End branchexe;
/






CREATE OR REPLACE PACKAGE BODY branchexe IS

Procedure branchexe_P(
compcode in varchar2,
userid in varchar2,
branchcode in varchar2,
branchname in varchar2,
alias in varchar2,
city in varchar2,
country IN varchar2,
pubcenter IN varchar2,
p_Accounts Out T_Accounts_Cursor ) AS

BEGIN


Open P_Accounts For
 select * from branch_mst
where "Comp_Code"=compcode and  ("Branch_Code"=branchcode or branchcode is null)and
 ("Branch_Name" like branchname||'%' or branchname is null)
and  ("Branch_Alias" like alias||'%' or alias is null)
and  ("Country_Code"=country or country is null)
and  ("City_Code"=city or city is null)
and  ("pub_center"=pubcenter or pubcenter is null)
;


END branchexe_P;

END branchexe;
/

***********************///////////////////////////// ANKIT////6197 *********************/////////////////////////////////

********************************************************ankit***** 5805 **************************************************


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
sysdate as "Rundate"
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



 OPEN p_accounts FOR Vquery;

END representative_p;
END Representative;
/

********************************ankit*********************5805*********************6 jan******************************************
/********************************mimoh*********************9jan*********************6 jan******************************************/


CREATE OR REPLACE PROCEDURE          bindratecodeforrevisedate
(
compcode  in varchar2,
adcat1  in varchar2,
previsedate  in varchar2,

p_Accounts   OUT   cur_type_new1.cursor_type
)
as
BEGIN

if(previsedate is null) then
begin
if(adcat1='contract')then
Open p_Accounts for
select  distinct  "Rate_Mast_Code" AS "rate_mast_code" from   rate_mast  where "Comp_code"= compcode and sysdate between "Valid_From" and "Valid_To";
else
Open p_Accounts for
select  distinct  "Rate_Mast_Code" AS "rate_mast_code" from  rate_mast  where ("Comp_code"= compcode ) and ("Adv_Cat_Code"= adcat1) and sysdate between "Valid_From" and "Valid_To";
end if;
end;
else
begin


if(adcat1='contract')then
Open p_Accounts for
select  distinct  "Rate_Mast_Code" AS "rate_mast_code" from   rate_mast  where "Comp_code"= compcode and previsedate between "Valid_From" and "Valid_To";
else
Open p_Accounts for
select  distinct  "Rate_Mast_Code" AS "rate_mast_code" from  rate_mast  where ("Comp_code"= compcode ) and ("Adv_Cat_Code"= adcat1) and previsedate between "Valid_From" and "Valid_To";
end if;
end;
end if;
END;
/


/********************************mimoh*********************9jan*********************6 jan******************************************/

/********************************ankit*********************4885********6228*************11 jan******************************************/



CREATE OR REPLACE PROCEDURE Reportnew1(
    agname          IN  VARCHAR2:=NULL,
    clientname      IN  VARCHAR2:=NULL,
    adtype1         IN  VARCHAR2,
    Adcategory      IN  VARCHAR2,
    Adsubcategory   IN  VARCHAR2,
    fromdate        IN  VARCHAR2,
    dateto          IN  VARCHAR2,
    compcode        IN  VARCHAR2,
    pub_name        IN  VARCHAR2,
    pub_cent        IN  VARCHAR2,
    status          IN  VARCHAR2:=NULL,
    edition         IN  VARCHAR2,
    dateformat      IN  VARCHAR2,
    hold            IN  VARCHAR2:=NULL,
    descid          IN  VARCHAR2:=NULL,
    ascdesc         IN  VARCHAR2:=NULL,
    agtype          in  varchar2:=null,
    puserid         in  varchar2:=null,
    chk_access      in  varchar2:=null,
    pbranch         in  varchar2:=null,
    pprint_center   in  varchar2:=null,
    pwithout_rono   in  varchar2:=null,--it is for without agency ro no. list Y or N or All
    pdate_flag      in  varchar2:=null,--it is used for booking date B or publish date P
    pextra1         in  varchar2:=null,
    pextra2         in  varchar2:=null,
    pextra3         in  varchar2:=null,
    pextra4         in  varchar2:=null,
    pextra5         in  varchar2:=null,
    p_reportnew     OUT Cur_Type_New1.cursor_type)
IS

center      VARCHAR(50);
from_date   DATE;
date_to     DATE;
v_query     VARCHAR(8000);
a           number;
BEGIN
    v_query:=' SELECT m."cio_booking_id" AS "CIOID",i."Edition" as "edition",
    CASE '''||dateformat||'''WHEN ''mm/dd/yyyy'' THEN TO_CHAR(i."Insert_Date",''mm/dd/yyyy'')
    WHEN ''dd/mm/yyyy'' THEN TO_CHAR(i."Insert_Date",''dd/mm/yyyy'')
    WHEN ''yyyy/mm/dd'' THEN TO_CHAR(i."Insert_Date",''yyyy/mm/dd'')  END AS "Ins.date" ,
    a."Agency_Name" AS "Agency",
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
    (select COMBIN_MAST."Package_Name" from combin_mast where COMBIN_MAST."Combin_Code"  in(m."Package_code"))AS "Package",
    i."Height" AS "Depth",i."Width"   AS "Width",round(i."Size_Book",2) AS "Area",
    (select uom_mast.UOM_DESC from uom_mast where m."Uom_code"=uom_mast."Uom_Code")as "uom",i."Col_Code" AS "Color_code",
    (SELECT ADVPOS_TYPE_MAST."Pos_Type_Alias" FROM ADVPOS_TYPE_MAST WHERE i."Page_Post"=ADVPOS_TYPE_MAST."Pos_Type_Code") AS "Page",
    m."Bullet_code" AS "BulletPremium" ,i."Page_Post" AS "PositionPremium" ,i."Premium1" AS "PagePremium" ,
    m."RO_No" AS "RoNo.",CASE m."ro_status" WHEN ''2'' THEN ''Reservation'' WHEN ''1'' THEN ''Confirm'' END AS "RoStatus",
    (SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=i."Ad_Cat") AS "AdCat",
    m."Card_rate" AS "CardRate",NVL("Agrred_rate",0) AS "AgreedRate",i."Bill_Amt" AS "Amt",m."Caption" AS "Cap",m."Key_no" AS "Key",
    (SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
    sysdate as "Rundate",
    m.CASHDISCOUNT as "Cash_Disc", m."AUDIT_COMMENT" as "COMMENT",m."Dockit_no" as "DOCKIT_NO"
    FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a
    WHERE m."Comp_code"='''||compcode||'''
    AND m."cio_booking_id"=i."Cio_Booking_Id"
    AND m."Agency_code"=a."Agency_Code"
    and m."Agency_sub_code"=a."code_subcode"
    AND m."cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
    and  lower(i."Insert_Status") !=''cancel''
    and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where  newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
    or  ('''||chk_access||'''=''0'') )';


/*
IF(hold IS NOT NULL)THEN
v_query:=v_query||' and m."Insert_Status"!='''||'Cancel'||'''';

END IF;
*/
IF(agname IS NOT NULL) THEN
    v_query:=v_query||' and m."Agency_code" ='''||agname||'''';
END IF;

IF(clientname IS NOT NULL) THEN
    v_query:=v_query||' and m."Client_code"='''||clientname ||'''';
END IF;

IF(status IS NOT NULL) THEN
    v_query:=v_query||' and i."Insert_Status"='''||status||'''';
END IF;

IF(adtype1 IS NOT NULL) THEN
    v_query:=v_query||' and m."Ad_type_code"='''||adtype1||'''';
END IF;

IF(Adcategory IS NOT NULL) THEN
    a:=Fn_Splitfield(Adcategory,',');
    --v_query:=v_query||' and m."Ad_cat_code" in('''||Adcategory||''' )';
    v_query:=v_query||' and i."Ad_Cat" in(select "EDITION_NAME" from result  )';
END IF;

IF(Adsubcategory IS NOT NULL) THEN
    a:=fn_SplitField_new(Adsubcategory,',');
    v_query:=v_query||' and m."Ad_sub_cat_code" in(select "EDITION_NAME" from result_new where sess_id='||userenv('sessionid')||' )';
END IF;

IF(pub_cent IS NOT NULL) THEN
    v_query:=v_query||'  and i."Pub_Cent_Code"='''||pub_cent||'''';
END IF;

If pdate_flag='B' then
    IF(fromdate IS NOT NULL AND dateto IS NULL ) THEN
        v_query:=v_query||' and m."date_time" ='''||fromdate||'''';

    END IF;

    IF(fromdate IS NOT NULL AND dateto IS NOT NULL ) THEN
        v_query:=v_query||' and m."date_time" between  '''||fromdate ||''' and  '''||dateto||''' ';
    END IF;
Else
    IF(fromdate IS NOT NULL AND dateto IS NULL ) THEN
        v_query:=v_query||' and i."Insert_Date" ='''||fromdate||'''';
    END IF;

    IF(fromdate IS NOT NULL AND dateto IS NOT NULL ) THEN
        v_query:=v_query||' and i."Insert_Date" between  '''||fromdate ||''' and  '''||dateto||''' ';
    END IF;
End If;    

IF(edition IS NOT NULL) THEN
    v_query:=v_query||'  and i."Edition_Code"='''||edition||'''';
END IF;

IF(pub_name IS NOT NULL) THEN
    v_query:=v_query||' and  i."Publication_Code"='''||pub_name||'''';
END IF;

IF((agtype IS NOT NULL) AND (agtype <> 'Package') AND (agtype <> 'Solo')) THEN
    v_query:=v_query||' and  m."Agency_type"='''||upper(agtype)||'''';
END IF;


if(pprint_center is not null)then
    v_query:=v_query||' and m."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE m."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||pprint_center||''')) ';
end if;

if(pbranch is not null)then
    v_query:=v_query||' and m."branch" = '''||pbranch||''' ';
end if;

If pwithout_rono='Y' then
    
    v_query:=v_query||' and (m."RO_No" is null or m."RO_No"='''') ';
End if;    

If pwithout_rono='N' then
    
    v_query:=v_query||' and (m."RO_No" is not null or m."RO_No"<>'''') ';
    
End if;

IF(descid IS NOT  NULL) THEN
    v_query:=v_query||'  order by "'||descid||'"';
    v_query:=v_query||''||ascdesc||'';
ELSE
    v_query:=v_query||'  order by i."Insert_Date",m."cio_booking_id"';
END IF;

delete from searchtbl;insert into searchtbl values(v_query);commit;

OPEN p_reportnew FOR v_query;

END Reportnew1;
/

/********************************ankit*********************4885********6228*************11 jan******************************************/

/************************mimoh contaract master*****************************************************************/
CREATE OR REPLACE procedure cheackdeal
(
 compcode in varchar2,
 dealno in varchar2,
 P_Accounts OUT Cur_Type_New1.cursor_type
)
IS
BEGIN
    OPEN P_Accounts FOR
    SELECT AUDITBY, AUDIT_COMMENT FROM  CONTRACT_MAST WHERE "Comp_code"= compcode and "Deal_No"=dealno and AUDITBY is not null;
        
END;
/


/************************mimoh contaract master*****************************************************************/
