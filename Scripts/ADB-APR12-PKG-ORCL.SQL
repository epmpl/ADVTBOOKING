==============7032=====avinash====16apr2012=================
CREATE OR REPLACE PACKAGE BIND_EDITION_PRINT IS
type t_accounts_cursor is ref cursor;
procedure BIND_EDITION_PRINT_P
(
p_compcode in varchar2,
p_pubcode in varchar2,
p_printcent in varchar2,
p_accounts out t_accounts_cursor 
);
end BIND_EDITION_PRINT;
/

CREATE OR REPLACE PACKAGE BODY BIND_EDITION_PRINT IS
procedure BIND_EDITION_PRINT_P
(
p_compcode in varchar2,
p_pubcode in varchar2,
p_printcent in varchar2,
p_accounts out t_accounts_cursor 
)
AS
BEGIN

OPEN p_accounts FOR
SELECT "Edition_Code" ,"Edition_Alias" from edition_mast where 
("Comp_Code"=p_compcode or p_compcode is null) 
and ("Pub_Code"=p_pubcode or p_pubcode is null) 
and (PRINT_CENT=p_printcent or p_printcent is null) order by "Edition_Alias";


end BIND_EDITION_PRINT_P;
end BIND_EDITION_PRINT;
/


*******************************************

CREATE OR REPLACE PROCEDURE HT18JULY.completereport(
    p_compcode      IN VARCHAR2:= NULL,
    p_fromdate      IN VARCHAR2:= NULL,
    p_dateto        IN VARCHAR2:= NULL,
    p_dateformat    IN VARCHAR2:= NULL,
    p_publication   IN VARCHAR2:= NULL,
    p_pub_cent      IN VARCHAR2:= NULL,
    p_edition       IN VARCHAR2:= NULL,
    p_suppliment    IN VARCHAR2:= NULL,
    p_zone          IN VARCHAR2:= NULL,
    p_branch        IN VARCHAR2:= NULL,
    p_district      IN VARCHAR2:= NULL,
    p_region        IN VARCHAR2:= NULL,
    p_city          IN VARCHAR2:= NULL,
    p_revcenter     IN VARCHAR2:= NULL,
    p_adtype        IN VARCHAR2:= NULL,
    p_agencytype    IN VARCHAR2:= NULL,
    p_ratetype      IN VARCHAR2:= NULL,
    p_adcat         IN VARCHAR2:= NULL,
    p_adsubcat      IN VARCHAR2:= NULL,
    p_adsubcat3     IN VARCHAR2:= NULL,
    p_adsubcat4     IN VARCHAR2:= NULL,
    p_adsubcat5     IN VARCHAR2:= NULL,
    p_package       IN VARCHAR2:= NULL,
    p_scheme        IN VARCHAR2:= NULL,
    p_agency        IN VARCHAR2:= NULL,
    p_client        IN VARCHAR2:= NULL,
    p_executive     IN VARCHAR2:= NULL,
    p_retainer      IN VARCHAR2:= NULL,
    p_product       IN VARCHAR2:= NULL,
    p_brand         IN VARCHAR2:= NULL,
    p_varient       IN VARCHAR2:= NULL,
    p_pagetype      IN VARCHAR2:= NULL,
    p_pageprem      IN VARCHAR2:= NULL,
    p_postprem      IN VARCHAR2:= NULL,
    p_rostatus      IN VARCHAR2:= NULL,
    p_booktype      IN VARCHAR2:= NULL,
    p_contractname  IN varchar2:= NULL,
    p_filterby      IN varchar2:= NULL,
    p_adcheck       in varchar2:=null,
    p_state         in varchar2:=null,
    p_taluka        in varchar2:=null,
    p_base          in varchar2:=null,
    p_drpstatus     in varchar2:=null,
    p_chkdetail     in varchar2:=null,
    p_insertstatus  in varchar2:=null,
    p_puserid       in varchar2:=null,
    p_baxcode       in varchar2:=null, 
    p_chk_access    in varchar2:=null,
    p_recordset1    OUT Cur_Type_New1.cursor_type,
    p_accounts      OUT Cur_Type_New1.cursor_type)

IS
query1          VARCHAR2(20000);
v_val           number(5);
query2          VARCHAR2(20000);
query3          VARCHAR2(20000);


bookdate        varchar2(50);
noinsert        varchar2(50);
Paidinsert      varchar2(50);
Area            varchar2(50);
Pagepremium     varchar2(50);
cardamt         varchar2(50);
Deviationamt    varchar2(50);
Deviationper    varchar2(50);
aggamt          varchar2(50);
DiscAmt         varchar2(50);
Discper         varchar2(50);
posamt          varchar2(50);
posper          varchar2(50);
Spdiscamt       varchar2(50);
Spdiscper       varchar2(50);
Spacedisc       varchar2(50);
Spacediscper    varchar2(50);
Specialcharge   varchar2(50);
AgencyAddlTDper varchar2(50);
AgencyAddlTDAmt varchar2(50);
Grossamt        varchar2(50);
RetTDper        varchar2(50);
RetTDAmt        varchar2(50);
AgencyTDper     varchar2(50);
AgencyTDAmt     varchar2(50);
Billamt         varchar2(50);
RetCommper      varchar2(50);
RetCommAmt      varchar2(50);
ActualBusines   varchar2(50);



Cursor C1 Is
SELECT /*+ index(TBL_BOOKING_MAST IND_TBL_BOOKING_MAST) index(TBL_BOOKING_INSERT  INSERT_I) */  distinct m."cio_booking_id" AS "CIOID",
m."Package_code" as package_code,m."Gross_amount" as Crate,'1' as chk_var
FROM TBL_BOOKING_MAST m, TBL_BOOKING_INSERT i,agency_mast a
WHERE m."Comp_code"=p_compcode and m."Comp_code"=a."Comp_Code"
AND m."cio_booking_id"=i."Cio_Booking_Id"
AND ((m."Insertion_date" BETWEEN p_fromdate AND p_dateto and p_filterby='Publish Date') or (m."date_time" BETWEEN p_fromdate AND p_dateto and p_filterby='Booking Date'))
AND i."Publication_Code"=nvl(p_publication,i."Publication_Code")
--old version
--and m."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE m."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
and m."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE m."branch"="Branch_Code" and "pub_center"=nvl(p_pub_cent,"pub_center"))
and m."branch" =nvl(p_branch,m."branch")

AND m."Ad_type_code"=nvl(p_adtype,m."Ad_type_code")
AND i."Ad_Cat"=nvl(p_adcat,i."Ad_Cat")
AND i."Edition_Code"=nvl(p_edition,i."Edition_Code")
and m."Agency_sub_code"= a."code_subcode" 
and (a."region" =p_region  or p_region is null)
and (m."Revenue_center" =p_revcenter or p_revcenter is null)
and (m."Agency_type" =p_agencytype or p_agencytype is null)
and (i."Ad_Sub_Cat" =p_adsubcat or p_adsubcat is null)
and (i."AD_SUBCAT3" =p_adsubcat3 or p_adsubcat3 is null)
and (i."AD_SUBCAT4" =p_adsubcat4 or p_adsubcat4 is null)
and (i."AD_SUBCAT5" =p_adsubcat5 or p_adsubcat5 is null)
and (m."Package_code" =p_package or p_package is null)
and (m."Scheme_type_code" =p_scheme or p_scheme is null)
and a."Agency_Code" =nvl(p_agency,a."Agency_Code")
and (m."Client_code" =p_client or p_client is null)
and (m."Executive_code" =p_executive or p_executive is null)
and (m.RETAINER =p_retainer or p_retainer is null)
and (m."Product_code" =p_product  or p_product is null)
and (m."Brand_code" =p_brand or p_brand is null)
and (m."Variant_code" =p_varient or p_varient is null)
and (m."Page_type_code" =p_pagetype or p_pagetype is null)
and (m."Page_prem" =p_pageprem or p_pageprem is null)
and (m."Page_position_code" =p_postprem or p_postprem is null)
and (m."ro_status" =p_rostatus or p_rostatus is null)
and (m."Booking_type" =p_booktype or p_booktype is null)
and (m."Contract_name" =p_contractname or p_contractname is null)
and (i."Supp_Code" =p_suppliment or p_suppliment is null)
and (m."Rate_code" =p_ratetype or p_ratetype is null)

and ((p_base='1' and a."City_Code" =p_city or p_city is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" =p_city or p_city is null))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"=p_city or p_city is null)))

and ((p_base='1' and a."zone_code" =p_zone or p_zone is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= p_zone or p_zone is null) ))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))

and ((p_base='1' and a."Dist_Code" =p_district or p_district is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code"= p_district or p_district is null ))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"=p_district or p_district is null)))

and ((p_base='1' and a."State_Code" =p_state or p_state is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code"= p_state or p_state is null ))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"=p_state or p_state is null)))

and ((p_base='1' and a.TALUKA=p_taluka or p_taluka is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA= p_taluka or p_taluka is null ))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))

and ((p_base='1' and m."Agency_sub_code" IS NOT NULL AND m."Agency_sub_code"!='0')
or (p_base='2' and m."Executive_code"    is not null and m."Executive_code" !='0' )
or (p_base='3' and m.RETAINER is not null  and m.RETAINER !='0'))

and ((p_drpstatus is  not null and  i."Insert_Status"!='XYZ') or 
(p_drpstatus is  null and  lower(i."Insert_Status")!='cancel'))
and (lower(i."Insert_Status")=p_insertstatus or p_insertstatus is null)

and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=p_puserid) and p_chk_access=1)
or  (p_chk_access=0) )
and p_adcheck='1'

union

SELECT /*+ index(TBL_BOOKING_MAST IND_TBL_BOOKING_MAST) index(TBL_BOOKING_INSERT  INSERT_I) */ distinct m."cio_booking_id" AS "CIOID",
m."Package_code" as package_code,i."Gross_Rate" as Crate,'1' as chk_var
FROM TBL_BOOKING_MAST m, TBL_BOOKING_INSERT i,AGENCY_MAST a
WHERE m."Comp_code"=p_compcode
AND m."Comp_code"=i."Comp_Code" AND m."Comp_code"=a."Comp_Code"
AND m."cio_booking_id"=i."Cio_Booking_Id"
AND (i."Insert_Date" BETWEEN p_fromdate AND p_dateto )
AND (i."Publication_Code"=p_publication or p_publication is null)
--old version

--and m."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE m."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
and m."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE m."branch"="Branch_Code" and "pub_center" =nvl(p_pub_cent,"pub_center"))
and m."branch" =nvl(p_branch,m."branch")

AND m."Ad_type_code"=nvl(p_adtype,m."Ad_type_code")
AND i."Ad_Cat" =nvl(p_adcat,i."Ad_Cat")
AND i."Edition_Code"=nvl(p_edition,i."Edition_Code")
and m."Agency_sub_code"  =a."code_subcode" 
and (a."region" =p_region  or p_region is null)
and (m."Revenue_center" =p_revcenter or p_revcenter is null)
and (m."Agency_type" =p_agencytype or p_agencytype is null)
and (m."Ad_sub_cat_code" =p_adsubcat or p_adsubcat is null)
and (i."AD_SUBCAT3" =p_adsubcat3 or p_adsubcat3 is null)
and (i."AD_SUBCAT4" =p_adsubcat4 or p_adsubcat4 is null)
and (i."AD_SUBCAT5" =p_adsubcat5 or p_adsubcat5 is null)
and (m."Package_code" =p_package or p_package is null)
and (m."Scheme_type_code" =p_scheme or p_scheme is null)
and a."Agency_Code" =nvl(p_agency,a."Agency_Code")
and (m."Client_code" =p_client or p_client is null)
and (m."Executive_code" =p_executive or p_executive is null)
and (m.RETAINER =p_retainer or p_retainer is null)
and (m."Product_code" =p_product  or p_product is null)
and (m."Brand_code" =p_brand or p_brand is null)
and (m."Variant_code" =p_varient or p_varient is null)
and (m."Page_type_code" =p_pagetype or p_pagetype is null)
and (i."Premium1"  =p_pageprem or p_pageprem is null)
and (i."Page_Post" =p_postprem or p_postprem is null)
and (m."ro_status" =p_rostatus or p_rostatus is null)
and (m."Booking_type" =p_booktype or p_booktype is null)
and (m."Contract_name" =p_contractname or p_contractname is null)
and (i."Supp_Code" =p_suppliment or p_suppliment is null)
and (m."Rate_code" =p_ratetype or p_ratetype is null)
and ((p_base='1' and a."City_Code" =p_city or p_city is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" =p_city or p_city is null))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"=p_city or p_city is null)))
and ((p_base='1' and a."zone_code" =p_zone or p_zone is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select /*+ index(city_mst ind_city_mst) */ city_mst."City_Code" from city_mst where city_mst."Zone_Code"= p_zone or p_zone is null)
))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))
and ((p_base='1' and a."Dist_Code" =p_district or p_district is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code"= p_district or p_district is null ))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"=p_district or p_district is null)))
and ((p_base='1' and a."State_Code" =p_state or p_state is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code"= p_state or p_state is null ))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"=p_state or p_state is null)))
and ((p_base='1' and a.TALUKA=p_taluka or p_taluka is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA= p_taluka or p_taluka is null ))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))
and ((p_base='1' and m."Agency_sub_code" IS NOT NULL AND m."Agency_sub_code"!='0')
or (p_base='2' and m."Executive_code"    is not null and m."Executive_code" !='0' )
or (p_base='3' and m.RETAINER is not null  and m.RETAINER !='0'))
and ((p_drpstatus is  not null and i."Insert_Status"!='XYZ')
or (p_drpstatus is  null and  lower(i."Insert_Status")!='cancel'))
and (lower(i."Insert_Status")=p_insertstatus or p_insertstatus is null)

and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=p_puserid) and p_chk_access=1)
or  (p_chk_access=0) )

and p_adcheck='3'

union

SELECT /*+ index (ad_bills_det ind1_ad_bills_det) */distinct bl."IDNUM" AS "CIOID",
bld.PACKAGE_CODE as package_code,bl.GROSS_AMT as Crate,'2' as chk_var
FROM ad_bills bl, ad_bills_det bld,agency_mast a,branch_mst b
WHERE bl.IDNUM=bld.IDNUM
AND bl.BILDT >= p_fromdate and bl.BILDT <= p_dateto
and (bl."PRIPUB"=p_publication  or p_publication is null)
and (bld."EDITION"=p_edition or p_edition is null)
and bl.AGCODE =a."code_subcode" and (a."region" =p_region  or p_region is null)
and (bld."AD_TYPE_V"=p_adtype or p_adtype is null)
and (a."Agency_Type_Code" =p_agencytype or p_agencytype is null)
and (bld.PRIADCTG =p_adcat or p_adcat is null)
and (bld.SECADCTG =p_adsubcat or p_adsubcat is null)
and (bld."AD_SUBCAT3"  =p_adsubcat3 or p_adsubcat3 is null)
and (bld.AD_SUBCAT4 =p_adsubcat4 or p_adsubcat4 is null)
and (bld.AD_SUBCAT5 =p_adsubcat5 or p_adsubcat5 is null)
and (bld.PACKAGE_CODE =p_package or p_package is null)
and (a."Agency_Code" =p_agency or p_agency is null)
and (bl."CLIENTCD"=p_client or p_client is null)
and (bl."EXECUTIVE_NAME"=p_executive or p_executive is null)
and (bl."PRIPROCTG"=p_product or p_product is null)
and ((bl."PRIPROCTG" in (select /*+ index(brand_mst brand_mst_pk)*/ brand_mst."prod_cat_code" from brand_mst where brand_mst."brand_code"=p_brand or p_brand is null)
and bl."PRIPROCTG" is not null)or (bl."PRIPROCTG" is null))
and ((bl."PRIPROCTG" in (select /*+ index(brand_mst brand_mst_pk)*/ brand_mst."prod_cat_code" from brand_mst where brand_mst."brand_code" in(select /*+ index(varient_mst ind_varient_mst) */ varient_mst."Brand_Code" from varient_mst where varient_mst."Varient_Name"=p_varient or p_varient is null))
and bl."PRIPROCTG" is not null) or (bl."PRIPROCTG" is null))
and (bld.PAGE_PREM =p_pageprem or p_pageprem is null)
and (bld.PAGE_POST =p_postprem or p_postprem is null)
and (bl.CONTRACT_NAME =p_contractname or p_contractname is null)
and (bld.SUPP_CODE =p_suppliment or p_suppliment is null)
and (bl.RETAINER_CODE =p_retainer or p_retainer is null)
and (bld.RATECD =p_ratetype or p_ratetype is null)
and bl.UNIT = b."Branch_Code" and b."Branch_Code" =nvl(p_branch,b."Branch_Code")
and (b."pub_center"=p_pub_cent or p_pub_cent is null)
and (bl.SCHEME=scheme or scheme is null)
and (bl.REVENUE_CENTER =p_revcenter or p_revcenter is null)
and (bl.RO_STATUS =p_rostatus or p_rostatus is null)
and (bl.PAGE_TYPE =p_pagetype or p_pagetype is null)
and (bl.BOOKING_TYPE =p_booktype or p_booktype is null)
 and (bl.SCHEME=p_scheme or p_scheme is null)
 and (bl.REVENUE_CENTER =p_revcenter or p_revcenter is null)
 and (bl.RO_STATUS =p_rostatus or p_rostatus is null)
 and (bl.PAGE_TYPE =p_pagetype or p_pagetype is null)
 and (bl.BOOKING_TYPE =p_booktype or p_booktype is null)
and ((p_base='1' and (a."City_Code" =p_city or p_city is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" =p_city or p_city is null))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"=p_city or p_city is null)))

and ((p_base='1' and (a."zone_code" =p_zone or p_zone is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= p_zone or p_zone is null) ))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))

and ((p_base='1' and (a."Dist_Code" =p_district or p_district is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code"= p_district or p_district is null ))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"=p_district or p_district is null)))

and ((p_base='1' and (a."State_Code" =p_state or p_state is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code"= p_state or p_state is null ))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"=p_state or p_state is null)))

and ((p_base='1' and (a.TALUKA=p_taluka or p_taluka is null) )
or (p_base='2' and bl.EXECUTIVE_NAME   in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA= p_taluka or p_taluka is null ))
or (p_base='3' and bl.RETAINER_CODE  in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))

and ((p_base='1' and bl.AGCODE IS NOT NULL AND bl.AGCODE!='0')
or (p_base='2' and bl.EXECUTIVE_NAME   is not null and bl.EXECUTIVE_NAME !='0' )
or (p_base='3' and bl.RETAINER_CODE  is not null  and bl.RETAINER_CODE !='0'))

and ((bld."BKFOR" in (select distinct pub_center from login_center where newuser_id=p_puserid) and p_chk_access=1)
or  (p_chk_access=0) )

and p_adcheck='2';

v1 c1%rowtype;


---**************************************  For Billing Data*************************
Cursor C2 Is
SELECT distinct bl."IDNUM" AS "CIOID",bl.BILNO as "BILLNO" ,bl.ag_main_code as "AGMAINCODE",
bl.ag_sub_code as "AG_SUB_CODE",bl.agcode as "AGCODE",
a."Agency_Name" as "AGNAME",nvl(bl.executive_name,0) as "EXECCODE",
AD_GET_EXECNAME(bl.comp_code_v,bl.EXECUTIVE_NAME) as "EXECNAME",bl.RETAINER_CODE as "RETCODE",
AD_GET_RETAINER(bl.comp_code_v,bl.RETAINER_CODE) as "RETNAME"
FROM ad_bills bl ,AGENCY_MAST a,branch_mst b WHERE bl.comp_code_v=p_compcode
and bl.UNIT=b."Branch_Code" and b."Branch_Code" =nvl(p_branch,b."Branch_Code")
and bl.BILDT >= p_fromdate and bl.bildt <=p_dateto
and b."pub_center" =nvl(p_pub_cent,b."pub_center")
and bl.ag_main_code =a."Agency_Code" and bl.ag_sub_code =a."SUB_Agency_Code" and 
(a."region" =p_region  or p_region is null)
and a."Agency_Type_Code" =nvl(p_agencytype,a."Agency_Type_Code")
and (bl."PRIPUB"=p_publication  or p_publication is null)
and a."Agency_Code" =nvl(p_agency,a."Agency_Code")
and (bl."CLIENTCD"=p_client or p_client is null)
and (bl."EXECUTIVE_NAME"=p_executive or p_executive is null)
and (bl."PRIPROCTG"=p_product or p_product is null)
and ((bl."PRIPROCTG" in (select brand_mst."prod_cat_code" from brand_mst where brand_mst."brand_code"=p_brand or p_brand is null) 
and bl."PRIPROCTG" is not null)or (bl."PRIPROCTG" is null))
and ((bl."PRIPROCTG" in (select brand_mst."prod_cat_code" from brand_mst where brand_mst."brand_code" 
in(select varient_mst."Brand_Code" from varient_mst where varient_mst."Varient_Name"=p_varient or p_varient is null)) 
and bl."PRIPROCTG" is not null) or (bl."PRIPROCTG" is null))
and (bl.CONTRACT_NAME =p_contractname or p_contractname is null)
and (bl.RETAINER_CODE =p_retainer or p_retainer is null)
and (bl.SCHEME=p_scheme or p_scheme is null)
and (bl.REVENUE_CENTER =p_revcenter or p_revcenter is null)
and (bl.RO_STATUS =p_rostatus or p_rostatus is null)
and (bl.PAGE_TYPE =p_pagetype or p_pagetype is null)
and (bl.BOOKING_TYPE =p_booktype or p_booktype is null)
and ((p_base='1' and (a."City_Code" =p_city or p_city is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" =p_city or p_city is null))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"=p_city or p_city is null)))
and ((p_base='1' and (a."zone_code" =p_zone or p_zone is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= p_zone or p_zone is null) ))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))
and ((p_base='1' and (a."Dist_Code" =p_district or p_district is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code"= p_district or p_district is null ))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"=p_district or p_district is null)))
and ((p_base='1' and (a."State_Code" =p_state or p_state is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code"= p_state or p_state is null ))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"=p_state or p_state is null)))
and ((p_base='1' and (a.TALUKA=p_taluka or p_taluka is null) )
or (p_base='2' and bl.EXECUTIVE_NAME   in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA= p_taluka or p_taluka is null ))
or (p_base='3' and bl.RETAINER_CODE  in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))
and ((p_base='1' and bl.AGCODE IS NOT NULL AND bl.AGCODE!='0')
or (p_base='2' and bl.EXECUTIVE_NAME   is not null and bl.EXECUTIVE_NAME !='0' )
or (p_base='3' and bl.RETAINER_CODE  is not null  and bl.RETAINER_CODE !='0'));

v2 C2%rowtype;

--**********************************************************************************

v_edition varchar2(100);
v_edipkg varchar2(500);
prefer   varchar2(10);

BEGIN
/*insert into dbgstr(rdate,str,seq) values(sysdate,'Start of Complete Report',dbg_seq.nextval);commit;
delete from searchtbl;
insert into searchtbl values('compcode-'||p_compcode||'fromdate-'||p_fromdate||'dateto-'||p_dateto||'dateformat-'||p_dateformat||'publication-'||p_publication
||'pub_cent-'||p_pub_cent||'edition-'||p_edition||'suppliment-'||p_suppliment||'zone-'||p_zone||'branch-'||p_branch||'district-'||p_district||'region-'||p_region||
'city-'||p_city||'revcenter-'||p_revcenter||'adtype-'||p_adtype||'agencytype-'||p_agencytype||'ratetype-'||p_ratetype||'adcat-'||p_adcat||'adsubcat-'||p_adsubcat||
'adsubcat3-'||p_adsubcat3||'adsubcat4-'||p_adsubcat4||'adsubcat5-'||p_adsubcat5||'package-'||p_package||'scheme-'||p_scheme||'agency-'||p_agency||'client-'||p_client||
'executive-'||p_executive||'retainer-'||p_retainer||'product-'||p_product||'brand-'||p_brand||'varient-'||p_varient||'pagetype-'||p_pagetype||'pageprem-'||p_pageprem||
'postprem-'||p_postprem||'rostatus-'||p_rostatus||'booktype-'||p_booktype||'contractname-'||p_contractname||'filterby-'||p_filterby||'adcheck-'||p_adcheck||'state-'||p_state||
'taluka-'||p_taluka||'base-'||p_base||'drpstatus-'||p_drpstatus||'chkdetail-'||p_chkdetail||'insertstatus-'||p_insertstatus||'puserid-'||p_puserid||'chk_access-'||p_chk_access);

commit;*/








select DISTINCT AGENCY_RETAINER_COMM into prefer from preferrences where "comp_code"=p_compcode;

delete from multipack_rep where sess_id=userenv('sessionid')  ;
delete from multipack_rat where sess_id=userenv('sessionid') ;
DELETE FROM multipack_ratnew where sess_id=userenv('sessionid')  ;

commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'Delete multipack tables',dbg_seq.nextval);commit;
open c1;
loop
fetch c1 into v1;
exit when c1%notfound;
    --insert into dbgstr(rdate,str,seq) values(sysdate,'Open C1',dbg_seq.nextval);commit;
    
     v_val:=multipack_report(v1.CIOID,v1.package_code,v1.Crate,v1.chk_var);
   -- insert into dbgstr(rdate,str,seq) values(sysdate,'Open C1 multipack_report',dbg_seq.nextval);commit;
    v_edition:=null;v_edipkg:=null;
end loop;
close c1;
--insert into dbgstr(rdate,str,seq) values(sysdate,'close C1',dbg_seq.nextval);commit;
commit;

if(p_chkdetail='Detail')then

if(p_adcheck=1)
then
query1:=query1||'SELECT distinct m."cio_booking_id" AS "CIOID",
to_char(m."date_time",'''||p_dateformat||''') as "BookDate",
a."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
m."RO_No" AS "RoNo.",
CASE '''||p_dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR(m."RO_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(m."RO_Date" ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(m."RO_Date",''yyyy/mm/dd'') END AS "Ro.Date",
(select EXEC_MAST."Exec_name" from exec_mast where m."Executive_code"=to_char(exec_mast."Exe_no")) AS "Executive",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=m.RETAINER ) AS "Retainer",
decode(m."Booking_type",''1'',''Barter'',''2'',''FMG'',''3'',''Normal'',''4'',''InHouse'',''5'',''Complimentary'',''Normal'') as "BookType",
(select col_mast."Col_Alias" from col_mast where m."Color_code"=col_mast."Col_Code") as "Color",
adv_cat_mast."Adv_Cat_Name" as "Adcat",
(select adv_subcat_mast."Adv_Subcat_Name" from adv_subcat_mast where i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code")as "Adsubcat",
(select ad_cat3."catname" from ad_cat3,adv_subcat_mast  where m."Ad_Subcat3"=ad_cat3."catcode" and ad_cat3."subcatname"=adv_subcat_mast."Adv_Subcat_Code" and i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat3",
(select tbl_cat4."Cat_Name" from tbl_cat4,adv_subcat_mast where i."AD_SUBCAT4"=tbl_cat4."Cat_Code" and tbl_cat4."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat4",
(select tbl_cat5."Cat_Name" from tbl_cat5,adv_subcat_mast where i."AD_SUBCAT5"=tbl_cat5."Cat_Code" and tbl_cat5."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat5",
--FETCH_PACK(m."cio_booking_id") AS "Package",
case when instr(m."Package_code",'','') >0 then
    FETCH_PACK_new(m."cio_booking_id", m."Package_code" ) 
else
(select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=m."Package_code")
end AS "Package",   
to_char(m."Insertion_date",'''||p_dateformat||''') as "PubDate",
m."No_of_insertion" as "noinsert",
m."Paid_ins" as "Paidinsert",
m."Ad_size_height" as "height",
m."Ad_size_width" as "width",
m."Total_area" as "Area",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where m."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Pagepremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where m."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem",
(select scheme_master."Scheme_Name" from scheme_master where m."Scheme_type_code"=scheme_master."scheme_id") as "scheme",
m."Rate_code" as "Ratecode",
m."Card_rate" as "cardrate",
m."Card_amount" as "cardamt",
m."Contract_rate" as "contractrate",
m."Deviation" as "Deviationamt",
m."Deviation" AS "Deviation(%)",
m."Agrred_rate" as "Aggrate",
m."Agreed_amount" as "aggamt",
(m."Card_amount" - DECODE(NVL(m."Agreed_amount",0),0,m."Card_amount",m."Agreed_amount")) as "DiscAmt",
m."Discount_per" as "Discper",
(select SUM(nvl(RAT,0)) from multipack_rat where cioid=m."cio_booking_id"  and sess_id='||userenv('sessionid')||') as  "posamt",
(select SUM(nvl(PER_AMT,0)) from multipack_rat where cioid=m."cio_booking_id"   and sess_id='||userenv('sessionid')||') as "pos(%)",
round(((m."Special_disc_per" * m."Total_area" * m."Card_rate")/100),2) as "Spdiscamt",
m."Special_disc_per" as "Spdiscper",
round(((m."Space_disc_per" * m."Total_area" * m."Card_rate")/100),2) as "Spacedisc",
m."Space_disc_per" as "Spacediscper",
m."Special_charges" as "Specialcharge",
nvl(m."ADD_AGENCY_COMM",''0'') as "AgencyAddlTD(%)",
nvl((nvl(m."Gross_amount",''0'')*nvl(m."ADD_AGENCY_COMM",''0'')/100),''0'') as "AgencyAddlTDAmt",
nvl(m."Gross_amount",''0'') as "Grossamt",
(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1 ) as "RetTD(%)",
nvl(m."Gross_amount",''0'')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1 )/100 as "RetTDAmt",
nvl(m."Trade_disc",''0'' )as "AgencyTD(%)",
(nvl(m."Gross_amount",''0'')* nvl(m."Trade_disc",''0'' )/100 )as "AgencyTDAmt",
nvl(m."Bill_amount",''0'') as "Billamt",
nvl(case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then
                (
                 CASE to_number(nvl(m.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(m.RETAINER_COMM,''0''))-to_number(nvl(m."ADD_AGENCY_COMM",''0'' )))
                 end )
         when ''Net''   then  to_number(nvl(m.RETAINER_COMM,''0''))
        END )

    ELSE (select 0  from dual)
end  ,''0'') as "RetComm(%)",
nvl(
case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then
                 (
                 CASE to_number(nvl(m.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(m.RETAINER_COMM_AMT,''0''))-(nvl((nvl(m."Gross_amount",''0'')*to_number(nvl(m."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )


         when ''Net''   then  (nvl(m."Gross_amount",''0'')*(to_number(nvl(m.RETAINER_COMM,''0'')) )/100)
        END )

    ELSE (select 0  from dual)
end
,''0'') as "RetCommAmt",
minus_to_zero(nvl((  NVL(m."Bill_amount",''0'')-
nvl(
case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then

                 (
                 CASE to_number(nvl(m.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(m.RETAINER_COMM_AMT,''0''))-(nvl((nvl(m."Gross_amount",''0'')*to_number(nvl(m."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )


         when ''Net''   then  (nvl(m."Gross_amount",''0'')*(to_number(nvl(m.RETAINER_COMM,''0'')) )/100)
        END )

    ELSE (select 0  from dual)
end
,''0'') ),''0'')) as "ActualBusiness",

(SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE m."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter",
UOM_MAST."Uom_Name"  AS "Uom",
uom_mast.UOM_DESC as "uomdesc"
,(select pub_cent_mast."Pub_Cent_name" from pub_cent_mast where pub_cent_mast."Pub_cent_Code" in(select "pub_center" from  BRANCH_MST WHERE m."branch"="Branch_Code") ) as "Printcenter"
,(SELECT "Branch_Name" FROM BRANCH_MST where  m."branch" = "Branch_Code") as "Branch"


,case '''||p_base||'''
when ''1'' then  a."Dist_Code"
when ''2'' then (select dist_mst."Dist_Name" from dist_mst where dist_mst."Dist_Code" in(select exec_mast."dist_code" from exec_mast where  to_char(exec_mast."Exe_no")=m."Executive_code" )  )
when ''3'' then (select dist_mst."Dist_Name" from dist_mst where dist_mst."Dist_Code" in(select RETAINERMASTER."Dist_Code" from RETAINERMASTER where  RETAINERMASTER."Retain_Code"= m.RETAINER )  ) end as "District"
,case '''||p_base||'''
when ''1'' then (select taluka_mast.TALU_NAME  from taluka_mast where a.TALUKA=taluka_mast.TALU_CODE )
when ''2'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select exec_mast.TALUKA from exec_mast where  to_char(exec_mast."Exe_no")=m."Executive_code" )  )
when ''3'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select RETAINERMASTER.TALUKA from RETAINERMASTER where  RETAINERMASTER."Retain_Code"= m.RETAINER )  ) end as "Taluka"
,nvl(m."Page_no",0) as "Page_No"
,m.CASHDISCOUNT as "Cash_Disc"
,m."Box_code" as "BoxCode",m."Userid" as USERID,
(SELECT max("username") from login where com_code = m."Comp_code" and "userid"=m."Userid") as USERNAME,
m."Bill_remarks" as "BillRemark"
FROM TBL_BOOKING_MAST m,AGENCY_MAST a ,UOM_MAST,
adv_cat_mast,
adv_type_mast,
TBL_BOOKING_insert i
WHERE m."Comp_code"='''||p_compcode||''' AND
m."cio_booking_id"=i."Cio_Booking_Id" AND
UOM_MAST."Uom_Code"=m."Uom_code" and
m."Agency_sub_code"=a."Agency_Code"||a."SUB_Agency_Code" AND
i."Ad_Cat"=adv_cat_mast."Adv_Cat_Code" and
m."Ad_type_code"=adv_type_mast."Adv_Type_Code"
and adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||p_puserid||''') and '''||p_chk_access||'''=''1'')
or  ('''||p_chk_access||'''=''0'') )' ;


if(p_base='2')then
query1:=query1||' and (m."Executive_code" is not null and m."Executive_code" !=''0'')  ';
end if;

if(p_base='3')then
query1:=query1||' and (m.RETAINER is not null  and m.RETAINER !=''0'')  ';
end if;


if(p_drpstatus is null) then
query1:=query1||' and lower(i."Insert_Status")!='''||'cancel'||'''';
end if;

if(p_insertstatus is not null) then
query1:=query1||' and lower(i."Insert_Status")='''||p_insertstatus||'''';
end if;

IF(p_fromdate IS NOT NULL AND p_dateto IS NULL  and  p_filterby='Booking Date')
THEN
query1:=query1||' and m."date_time" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL and p_filterby='Booking Date' )
THEN
query1:=query1||' and m."date_time" between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NULL  and  p_filterby='Publish Date')
THEN
--query1:=query1||' and m."Insertion_date" ='''||p_fromdate||'''';
query1:=query1||' and i."Insert_Date" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL and p_filterby='Publish Date' )
THEN
--query1:=query1||' and m."Insertion_date"  between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
query1:=query1||' and i."Insert_Date"  between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query1:=query1||' and i."Publication_Code"='''||p_publication||'''    ';
END IF;

IF(p_pub_cent IS NOT NULL)
THEN
query1:=query1||'  and m."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE m."branch"="Branch_Code" and "pub_center" ='''||p_pub_cent||''')';
END IF;


IF(p_branch IS NOT NULL)
THEN
query1:=query1||'  and m."branch" ='''||p_branch||'''';
END IF;


IF(p_edition IS NOT NULL)
THEN
query1:=query1||'  and i."Edition_Code"='''||p_edition||'''';
END IF;

IF(p_region IS NOT NULL)
THEN
query1:=query1 ||' and a."region" ='''||p_region ||''' ';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query1:=query1 ||' and m."Revenue_center" ='''||p_revcenter||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query1:=query1 || ' and m."Ad_type_code"='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query1:=query1 || ' and m."Agency_type" ='''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query1:=query1 || ' and i."Ad_Cat" ='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query1:=query1 || ' and i."Ad_Sub_Cat" ='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query1:=query1 || ' and i."AD_SUBCAT3" ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query1:=query1 || ' and i."AD_SUBCAT4" ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query1:=query1 || ' and i."AD_SUBCAT5" ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query1:=query1 || ' and m."Package_code" ='''||p_package||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query1:=query1 || ' and m."Scheme_type_code" ='''||p_scheme||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query1:=query1 || ' and m."Agency_code" ='''||p_agency||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query1:=query1 || ' and m."Client_code" ='''||p_client||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query1:=query1 || ' and m."Executive_code" ='''||p_executive||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query1:=query1 || ' and m.RETAINER ='''||p_retainer||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query1:=query1 || ' and m."Product_code" ='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query1:=query1 || ' and m."Brand_code" ='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query1:=query1 || ' and m."Variant_code" ='''||p_varient||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query1:=query1 || ' and m."Page_type_code" ='''||p_pagetype||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query1:=query1 || ' and m."Page_prem" ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query1:=query1 || ' and m."Page_position_code" ='''||p_postprem||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query1:=query1 || ' and m."ro_status" ='''||p_rostatus||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query1:=query1 || ' and m."Booking_type" ='''||p_booktype||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query1:=query1 || ' and m."Contract_name" ='''||p_contractname ||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query1:=query1 || ' and i."Supp_Code" ='''||p_suppliment||'''';
END IF;

IF(p_ratetype  IS NOT NULL)
THEN
query1:=query1 || ' and m."Rate_code" ='''||p_ratetype||'''';
END IF;

IF(p_city  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and a."City_Code" ='''||p_city||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" ='''||p_city||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"='''||p_city||''')';
end if;
END IF;

IF(p_zone  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and a."zone_code" ='''||p_zone||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= '''||p_zone||''') )';
end if;

if(p_base='3')then
query1:=query1 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"='''||p_zone||''')';
end if;
END IF;

IF(p_district  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and a."Dist_Code" ='''||p_district||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code" ='''||p_district||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"='''||p_district||''')';
end if;
END IF;

IF(p_state  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and a."State_Code" ='''||p_state||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code" ='''||p_state||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"='''||p_state||''')';
end if;
END IF;

IF(p_taluka  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and a.TALUKA='''||p_taluka||'''  ';
end if;

if(p_base='2')then
query1:=query1 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA ='''||p_taluka||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA='''||p_taluka||''')';
end if;
END IF;

query1:=query1 || ' order by m."cio_booking_id"';

DELETE FROM searchtbl;
insert into searchtbl values(query1);commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'OPEN p_recordset1 FOR '||query1,dbg_seq.nextval);commit;
OPEN p_recordset1 FOR
query1;


elsif(p_adcheck=2)then
delete from temp_ad_bills_report where sess_id=userenv('sessionid')  ;
--insert into dbgstr(rdate,str,seq) values(sysdate,'open c2  ',dbg_seq.nextval);commit;
open c2;
loop
fetch c2 into v2;
exit when c2%notfound;
--insert into test_amit(a,b)values('amit-',v2.BILLNO);commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'before FUN_BILL_INSERT  ',dbg_seq.nextval);commit;
         v_val:=FUN_BILL_INSERT(p_compcode,v2.CIOID,v2.BILLNO,prefer,p_dateformat,v2.AGMAINCODE,v2.AG_SUB_CODE,v2.AGCODE,v2.AGNAME,v2.EXECCODE,v2.EXECNAME,v2.RETCODE,v2.RETNAME,p_base );
--insert into dbgstr(rdate,str,seq) values(sysdate,'after FUN_BILL_INSERT  ',dbg_seq.nextval);commit;
        
end loop;
close c2;
commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'close c2  ',dbg_seq.nextval);commit;
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
,BILL_REMARK as "BillRemark"
from temp_ad_bills_report where sess_id='||userenv('sessionid') ;


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

delete from searchtbl;
insert into searchtbl values(query2);commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'OPEN p_recordset1 FOR   '||query2,dbg_seq.nextval);commit;
OPEN p_recordset1 FOR
query2;

elsif(p_adcheck=3) then
query3:=query3 ||'SELECT m."cio_booking_id" AS "CIOID",
to_char(m."date_time",'''||p_dateformat||''') as "BookDate",
a."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
m."RO_No" AS "RoNo.",
CASE '''||p_dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR(m."RO_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(m."RO_Date" ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(m."RO_Date",''yyyy/mm/dd'') END AS "Ro.Date",
(select EXEC_MAST."Exec_name" from exec_mast where m."Executive_code"=to_char(exec_mast."Exe_no")) AS "Executive",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=m.RETAINER ) AS "Retainer",
decode(m."Booking_type",''1'',''Barter'',''2'',''FMG'',''3'',''Normal'',''4'',''InHouse'',''5'',''Complimentary'',''Normal'') as "BookType",
(select col_mast."Col_Alias" from col_mast where i."Col_Code" =col_mast."Col_Code") as "Color",
adv_cat_mast."Adv_Cat_Name" as "Adcat",
(select adv_subcat_mast."Adv_Subcat_Name" from adv_subcat_mast where i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code")as "Adsubcat",
(select ad_cat3."catname" from ad_cat3,adv_subcat_mast  where m."Ad_Subcat3"=ad_cat3."catcode" and ad_cat3."subcatname"=adv_subcat_mast."Adv_Subcat_Code" and i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat3",
(select tbl_cat4."Cat_Name" from tbl_cat4,adv_subcat_mast where i."AD_SUBCAT4"=tbl_cat4."Cat_Code" and tbl_cat4."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat4",
(select tbl_cat5."Cat_Name" from tbl_cat5,adv_subcat_mast where i."AD_SUBCAT5"=tbl_cat5."Cat_Code" and tbl_cat5."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat5",
-- FETCH_PACK(m."cio_booking_id") AS "Package",
FETCH_PACK_new(m."cio_booking_id", m."Package_code" ) AS "Package",
to_char(i."Insert_Date" ,'''||p_dateformat||''') as "PubDate",
 i."Height" as "height",
 i."Width"  as "width",
i."Size_Book" as "Area",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where i."Premium1" =ADVPOS_PREM_MAST."Premiumcode") as "Pagepremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where i."Page_Post" =advpos_type_mast."Pos_Type_Code") as "Postprem",
(select scheme_master."Scheme_Name" from scheme_master where m."Scheme_type_code"=scheme_master."scheme_id") as "scheme",
m."Rate_code" as "Ratecode",
m."Card_rate" as "cardrate",
m."Card_rate"*i."Size_Book" as "cardamt",
m."Contract_rate" as "contractrate",
m."Deviation" as "Deviationamt",
m."Deviation" AS "Deviation(%)",
m."Agrred_rate" as "Aggrate",
i."Agreed_Rate"  as "aggamt",
((m."Card_rate"*i."Size_Book") - DECODE(NVL(i."Agreed_Rate",0),0,(m."Card_rate"*i."Size_Book"),i."Agreed_Rate")) as "DiscAmt",
m."Discount_per" as "Discper",
(select SUM(nvl(RAT,0)) from multipack_rat where cioid=m."cio_booking_id"  and sess_id='||userenv('sessionid')||') as  "posamt",
(select SUM(nvl(PER_AMT,0)) from multipack_rat where cioid=m."cio_booking_id"   and sess_id='||userenv('sessionid')||') as "pos(%)",
round(((m."Special_disc_per" * i."Size_Book" * m."Card_rate")/100),2) as "Spdiscamt",
m."Special_disc_per" as "Spdiscper",
round(((m."Space_disc_per" * i."Size_Book" * m."Card_rate")/100),2) as "Spacedisc",
m."Space_disc_per" as "Spacediscper",
m."Special_charges" as "Specialcharge",
nvl(m."ADD_AGENCY_COMM",''0'') as "AgencyAddlTD(%)",
nvl((nvl(i."Gross_Rate" ,''0'')*nvl(m."ADD_AGENCY_COMM",''0'')/100),''0'') as "AgencyAddlTDAmt",
nvl(i."Gross_Rate",''0'') as "Grossamt",
(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1 ) as "RetTD(%)",
nvl(i."Gross_Rate",''0'')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1 )/100 as "RetTDAmt",
nvl(m."Trade_disc",''0'' )as "AgencyTD(%)",
(nvl(i."Gross_Rate",''0'')* nvl(m."Trade_disc",''0'' )/100 )as "AgencyTDAmt",
NVL(i."Bill_Amt",''0'') as "Billamt",
nvl(case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then

               (
                 CASE to_number(nvl(m.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(m.RETAINER_COMM,''0''))-to_number(nvl(m."ADD_AGENCY_COMM",''0'') ))
                end  )


         when ''Net''   then  to_number(nvl(m.RETAINER_COMM,''0''))
        END )

    ELSE (select 0  from dual)
end  ,''0'') as "RetComm(%)",

nvl(
case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then



                (
                 CASE to_number(nvl(m.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(m.RETAINER_COMM_AMT,''0''))-(nvl((nvl(i."Gross_Rate",''0'')*to_number(nvl(m."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )


         when ''Net''   then  (nvl(i."Gross_Rate",''0'')*(to_number(nvl(m.RETAINER_COMM,''0'')) )/100)
        END )

    ELSE (select 0  from dual)
end
,''0'') as "RetCommAmt",


minus_to_zero(nvl((  NVL(i."Bill_Amt",''0'')-
nvl(
case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then
           (
                 CASE to_number(nvl(m.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(m.RETAINER_COMM_AMT,''0''))-(nvl((nvl(i."Gross_Rate",''0'')*to_number(nvl(m."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )

         when ''Net''   then  (nvl(i."Gross_Rate",''0'')*(to_number(nvl(m.RETAINER_COMM,''0'')) )/100)
        END )



    ELSE (select 0  from dual)
end
,''0'') ),''0'')) as "ActualBusiness",
(SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE m."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter"
,UOM_MAST."Uom_Name"  AS "Uom",
pub_mast."Pub_Name" as "Publication",
i."Edition" as "Edition",
uom_mast.UOM_DESC as "uomdesc"
,(select pub_cent_mast."Pub_Cent_name" from pub_cent_mast where pub_cent_mast."Pub_cent_Code" in(select "pub_center" from  BRANCH_MST WHERE m."branch"="Branch_Code") ) as "Printcenter"
,(SELECT "Branch_Name" FROM BRANCH_MST where  m."branch" = "Branch_Code") as "Branch"

,case '''||p_base||'''
when ''1'' then  a."Dist_Code"
when ''2'' then (select dist_mst."Dist_Name" from dist_mst where dist_mst."Dist_Code" in(select exec_mast."dist_code" from exec_mast where  to_char(exec_mast."Exe_no")=m."Executive_code" )  )
when ''3'' then (select dist_mst."Dist_Name" from dist_mst where dist_mst."Dist_Code" in(select RETAINERMASTER."Dist_Code" from RETAINERMASTER where  RETAINERMASTER."Retain_Code"= m.RETAINER )  ) end as "District"
,case '''||p_base||'''
when ''1'' then (select taluka_mast.TALU_NAME  from taluka_mast where a.TALUKA=taluka_mast.TALU_CODE )
when ''2'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select exec_mast.TALUKA from exec_mast where  to_char(exec_mast."Exe_no")=m."Executive_code" )  )
when ''3'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select RETAINERMASTER.TALUKA from RETAINERMASTER where  RETAINERMASTER."Retain_Code"= m.RETAINER )  ) end as "Taluka"
,i."Page_No" as "Page_No"
,m.CASHDISCOUNT as "Cash_Disc",i."Insert_Status" as "Status"
,m."Box_code" as "BoxCode",m."Userid" as USERID,(SELECT max("username") from login where com_code = m."Comp_code" and "userid"=m."Userid") as USERNAME
,m."Bill_remarks" as "BillRemark"
FROM TBL_BOOKING_MAST m,AGENCY_MAST a ,uom_mast,
adv_cat_mast,
adv_type_mast,pub_mast,
TBL_BOOKING_insert i
WHERE m."Comp_code"='''||p_compcode||''' AND
m."cio_booking_id"=i."Cio_Booking_Id" and
UOM_MAST."Uom_Code"=m."Uom_code" and
m."Agency_sub_code"=a."code_subcode" AND
i."Ad_Cat" =adv_cat_mast."Adv_Cat_Code" and
m."Ad_type_code"=adv_type_mast."Adv_Type_Code"
and adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
pub_mast."Pub_Code"=i."Publication_Code" and
((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||p_puserid||''') and '''||p_chk_access||'''=''1'')
or  ('''||p_chk_access||'''=''0'') )' ;

if(p_base='2')then
query3:=query3 ||' and (m."Executive_code" is not null and m."Executive_code" !=''0'')  ';
end if;

if(p_base='3')then
query3:=query3 ||' and (m.RETAINER is not null  and m.RETAINER !=''0'')  ';
end if;


if(p_drpstatus is null) then
query3:=query3||' and lower(i."Insert_Status")!='''||'cancel'||'''';
end if;


if(p_insertstatus is not null) then
query3:=query3||' and lower(i."Insert_Status")='''||p_insertstatus||'''';
end if;


IF(p_fromdate IS NOT NULL AND p_dateto IS NULL )
THEN
query3:=query3 ||' and i."Insert_Date" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL)
THEN
query3:=query3 ||' and i."Insert_Date" between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query3:=query3 ||' and i."Publication_Code"='''||p_publication||'''    ';
END IF;

IF(p_pub_cent IS NOT NULL)
THEN
query3:=query3||'  and m."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE m."branch"="Branch_Code" and "pub_center"='''||p_pub_cent||''')';
END IF;

IF(p_branch IS NOT NULL)
THEN
query3:=query3 ||'  and m."branch" ='''||p_branch||'''';
END IF;

IF(p_edition IS NOT NULL)
THEN
query3:=query3 ||'  and i."Edition_Code"='''||p_edition||'''';
END IF;
IF(p_region IS NOT NULL)
THEN
query3:=query3  ||' and a."region" ='''||p_region||'''';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query3:=query3  ||' and m."Revenue_center" ='''||p_revcenter||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query3:=query3  || ' and m."Ad_type_code"='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query3:=query3  || ' and m."Agency_type" ='''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query3:=query3  || ' and i."Ad_Cat" ='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query3:=query3  || ' and i."Ad_Sub_Cat" ='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query3:=query3  || ' and i."AD_SUBCAT3" ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query3:=query3  || ' and i."AD_SUBCAT4" ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query3:=query3  || ' and i."AD_SUBCAT5" ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query3:=query3  || ' and m."Package_code" ='''||p_package||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query3:=query3  || ' and m."Scheme_type_code" ='''||p_scheme||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query3:=query3  || ' and a."Agency_Code" ='''||p_agency||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query3:=query3  || ' and m."Client_code" ='''||p_client||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query3:=query3  || ' and m."Executive_code" ='''||p_executive||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query3:=query3  || ' and m.RETAINER ='''||p_retainer||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query3:=query3 || ' and m."Product_code" ='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query3:=query3  || ' and m."Brand_code" ='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query3:=query3  || ' and m."Variant_code" ='''||p_varient||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query3:=query3  || ' and m."Page_type_code" ='''||p_pagetype||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query3:=query3 || ' and i."Premium1" ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query3:=query3 || ' and i."Page_Post" ='''||p_postprem||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query3:=query3 || ' and m."ro_status" ='''||p_rostatus||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query3:=query3 || ' and m."Booking_type" ='''||p_booktype||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query3:=query3 || ' and m."Contract_name" ='''||p_contractname ||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query3:=query3 || ' and i."Supp_Code" ='''||p_suppliment||'''';
END IF;

IF(p_ratetype  IS NOT NULL)
THEN
query3:=query3 || ' and m."Rate_code" ='''||p_ratetype||'''';
END IF;

IF(p_city  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and a."City_Code" ='''||p_city||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" ='''||p_city||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"='''||p_city||''')';
end if;
END IF;

IF(p_zone  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and a."zone_code" ='''||p_zone||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= '''||p_zone||''') )';
end if;

if(p_base='3')then
query3:=query3 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"='''||p_zone||''')';
end if;
END IF;

IF(p_district  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and a."Dist_Code" ='''||p_district||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code" ='''||p_district||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"='''||p_district||''')';
end if;
END IF;

IF(p_state  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and a."State_Code" ='''||p_state||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code" ='''||p_state||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"='''||p_state||''')';
end if;
END IF;

IF(p_taluka  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and a.TALUKA='''||p_taluka||'''  ';
end if;

if(p_base='2')then
query3:=query3 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA ='''||p_taluka||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA='''||p_taluka||''')';
end if;
END IF;

query3:=query3 || ' order by i."Insert_Date" ,m."cio_booking_id"';

insert into searchtbl values(query3);commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'OPEN p_recordset1 FOR   '||query3,dbg_seq.nextval);commit;
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

--insert into dbgstr(rdate,str,seq) values(sysdate,'OPEN p_recordset1 FOR1   '||query1,dbg_seq.nextval);commit;

OPEN p_recordset1 FOR
query1;



elsif(p_adcheck=2)then

delete from temp_ad_bills_report where sess_id=userenv('sessionid');
open c2;
loop
fetch c2 into v2;
exit when c2%notfound;
--insert into dbgstr(rdate,str,seq) values(sysdate,'before FUN_BILL_INSERT1   ',dbg_seq.nextval);commit;
     v_val:=FUN_BILL_INSERT(p_compcode,v2.CIOID,v2.BILLNO,prefer,p_dateformat,v2.AGMAINCODE,v2.AG_SUB_CODE,v2.AGCODE,v2.AGNAME,v2.EXECCODE,v2.EXECNAME,v2.RETCODE,v2.RETNAME,p_base );
--insert into dbgstr(rdate,str,seq) values(sysdate,'after FUN_BILL_INSERT1   ',dbg_seq.nextval);commit;     
end loop;
close c2;
commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'close c2   ',dbg_seq.nextval);commit;

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


************************************************


CREATE OR REPLACE FUNCTION HT18JULY.FUN_BILL_INSERT ( comp_cod varchar2, cio_id varchar2,bil_no varchar2,prefer varchar2,dateformate varchar2,f_agmain varchar2,f_agsub varchar2,f_agcode varchar2,f_agname varchar2,f_execcode varchar2,f_execname varchar2,f_retcode varchar2,f_retname varchar2,base varchar2) RETURN number IS

FCIOID      varchar2(50);
FBillno     varchar2(25);
FAgency     varchar2(50);
FClient     varchar2(200);
FRoNo       varchar2(40);
FRoDate     date;
FExecutive  varchar2(50);
FRetainer   varchar2(80);
FBookType   varchar2(50);
FColor      varchar2(20);
FAdcat      varchar2(50);
FAdsubcat   varchar2(50);
FAdsubcat3  varchar2(50);
FAdsubcat4  varchar2(50);
FAdsubcat5  varchar2(50);
FPackag     varchar2(1200);
FBillDate   date;
Fnoinsert   number;
FPaidinsert         number;
Fheight             number;
Fwidth              number;
FArea               number;
FPagepremium        varchar2(30);
FPostprem           varchar2(30);
Fscheme             varchar2(50);
FRatecod            varchar2(40);
Fcardrate           float;
Fcardamt            float;
Fcontractrate       number;
FDeviationamt       number;
FDeviationper       number;
FAggrate            number;
Faggamt             number;
FDiscAmt            float;
FDiscper            number;
Fposamt             number;
Fposper             number;
FSpdiscamt          number;
FSpdiscper          number;
FSpacedisc          number;
FSpacediscper       number;
FSpecialcharge      number;
FAgencyAddlTDper    varchar2(8);
FAgencyAddlTDAmt    number;
FGrossamt           number;
FRetTDPer           number;
FRetTDAmt           number;
FAgencyTDPer        number;
FAgencyTDAmt        number;
FBillamt            number;
FRetCommPer         number;
FRetCommAmt         number;
FActualBusiness     number;
FRevcenter          varchar2(50);
FUom                varchar(20);
FUomDesc            varchar2(50);
FCOMP_CODE          varCHAR2(10);
Fpadtype            varchar2(20);
FPRIPUB             varchar2(10);
FPEDITION           varchar2(50);
FBranch_Name        varchar2(50);
FPub_cent_Code      varchar2(50);
Fregion             varchar2(12);
FAgency_Type_Code   varchar2(10);
FPRIADCTG           varchar2(40);
FSECADCTG           varchar2(40);
FAD_SUBCAT3         varchar2(15);
FAD_SUBCAT4         varchar2(15);
FAD_SUBCAT5         varchar2(15);
FPACKAGE_CODE       varchar2(1000);
FAG_MAIN_CODE       varchar2(10);
FAG_SUB_CODE        varchar2(10);
FCLIENTCD           varchar2(200);
FEXECUTIVE_NAME     varchar2(100);
FPRIPROCTG          varchar2(10);
Fbrand_code         varchar2(10);
FVarient_Name       varchar2(25);
FPAGE_PREM          varchar2(10);
FPAGE_POST          varchar2(10);
FCONTRACT_NAME      varchar2(50);
FSUPP_CODE          varchar2(50);
FRETAINER_CODE      varchar2(10);
FRATECD             varchar2(40);
FCity_Code          varchar2(10);
Fzone_code          varchar2(10);
FDist_Code          varchar2(10);
FState_Code         varchar2(10);
FPTALUKA            varchar2(10);
FPSCHEME            varchar2(18);
FREVENUE_CENTER     varchar2(10);
FRO_STATUS          varchar2(10);
FPAGE_TYPE          varchar2(100);
FBOOKING_TYPE       varchar2(10);
FPUB_CENT_PERMIT    VARCHAR2(50);

FfAdcat             varchar2(50);
FfAdsubcat          varchar2(50);
FfAdsubcat3         varchar2(50);
FfAdsubcat4         varchar2(50);
FfAdsubcat5         varchar2(50);
FfPagepremium       varchar2(50);
Ffscheme            varchar2(50);
f_bil_amt           number;
FfAgencyAddlTDAmt   number;
FfUom               varchar2(50);
FfBranch_Name       varchar2(50);
FfClient            varchar2(100);
FfColor             varchar2(20);
FfPub_cent_Code     varchar2(30);
FffPub_cent_Code    varchar2(30);
FffBranch_Name      varchar2(50);
ffPRIPROCTG         varchar2(30);

Fag_dist_code       varchar2(50);
Fag_talu_code       varchar2(50);
Fdist_name          varchar2(50);
Ftalu_name          varchar2(50);
FPub_cent_Name      varchar2(50);

Fag_city_code       varchar2(50);
Fag_zone_code       varchar2(50);
Fag_state_code      varchar2(50);
Fcity_name          varchar2(30);
Fzone_name          varchar2(30);
Fstate_name         varchar2(30);
f_exec_city         varchar2(8);
f_city_zone         varchar2(8);
f_page_no           varchar(8);
f_billremark        varchar2(500);

begin

/****************************  For Ad_bills  *******************************/

SELECT max(ad_bills.IDNUM),max(AD_BILLS.BILNO),max(ad_bills.RONUM),MAX(ad_bills.RODATE),
max(decode(AD_BILLS.BOOKING_TYPE ,'1','Barter','2','FMG','3','Normal','4','InHouse','5','Complimentary','Normal')),
max(FETCH_PACK(ad_bills.idnum)), --PACKAGE
MAX(ad_bills.BILDT),max(ad_bills.CONTRACT_RATE),
max(FETCH_RATAMT(ad_bills.idnum,'1','2')),   --posamt
max(FETCH_RATAMT(ad_bills.idnum,'2','2')) ,  --POSPER
max(ad_bills.GROSS_AMT),max(ad_bills.BILLAMT) ,max(nvl(ad_bills.DISCOUNT ,0 )),
max((nvl(ad_bills.GROSS_AMT,0)* nvl(ad_bills.DISCOUNT,0 )/100 ))   ,MAX(COMP_CODE_V)
,max(ad_bills.CLIENTCD),max("COLOUR"),
max(SCHEME),sum(nvl(ad_bills.GROSS_AMT,0)),sum(BILLAMT),max(UNIT),
max(ad_bills.UNIT),max(ad_bills."PRIPUB") ,max(ad_bills.AG_MAIN_CODE),MAX(AD_BILLS.AG_SUB_CODE),max(ad_bills."CLIENTCD"),max( ad_bills."EXECUTIVE_NAME"),max(ad_bills."PRIPROCTG"),
max(ad_bills.CONTRACT_NAME),max(ad_bills.RETAINER_CODE),max(ad_bills.SCHEME),max(AD_BILLS.REVENUE_CENTER),max(AD_BILLS.RO_STATUS),
max(AD_BILLS.PAGE_TYPE),max(AD_BILLS.BOOKING_TYPE ),max("PRIPROCTG"),max(PAGENUM),
max(ad_bills.BILL_RMRK)
INTO FCIOID,FBillno,FRoNo,FRoDate,FBookType,FPackag,FBillDate,Fcontractrate,Fposamt,Fposper ,FGrossamt,FBillamt,FAgencyTDPer,FAgencyTDAmt,FCOMP_CODE
,FfClient,FfColor,
FfPagepremium,FAgencyAddlTDAmt,f_bil_amt,FfPub_cent_Code,
FfBranch_Name,FPRIPUB ,FAG_MAIN_CODE,FAG_SUB_CODE,FCLIENTCD,FEXECUTIVE_NAME,FPRIPROCTG,FCONTRACT_NAME,FRETAINER_CODE,FPSCHEME,FREVENUE_CENTER,FRO_STATUS,FPAGE_TYPE,FBOOKING_TYPE
,ffPRIPROCTG,f_page_no,f_billremark  FROM AD_BILLS WHERE ad_bills.COMP_CODE_V=comp_cod AND ad_bills.BILNO=bil_no and ad_bills.IDNUM=cio_id ;

/**************************************  For Ad_bills_det  ***********************************/
select max(PRIADCTG),max(SECADCTG),max(AD_SUBCAT3),max(AD_SUBCAT4),max(AD_SUBCAT5) ,max(PAGE_PREM)
,max(ad_bills_det.HEIGHT),max(ad_bills_det.WIDTH),max(ad_bills_det."SIZE_BOOK"),max(ad_bills_det.RATECD)
,sum(ad_bills_det.CARD_RATE_V),max(ad_bills_det."EDITION"),max(ad_bills_det."AD_TYPE_V"),max(ad_bills_det.PRIADCTG) ,max(ad_bills_det.SECADCTG),max(ad_bills_det."AD_SUBCAT3"),
max(ad_bills_det.AD_SUBCAT4),max(ad_bills_det.AD_SUBCAT5),max(ad_bills_det.PACKAGE_CODE),max(ad_bills_det.PAGE_PREM),max(ad_bills_det.PAGE_POST),
max(ad_bills_det.SUPP_CODE),max(ad_bills_det.RATECD),MAX(ad_bills_det."BKFOR")
into FfAdcat,FfAdsubcat,FfAdsubcat3,FfAdsubcat4,FfAdsubcat5,FfPagepremium
,Fheight,Fwidth,FArea,FRatecod,Fcardrate,FPEDITION,Fpadtype,FPRIADCTG,FSECADCTG,FAD_SUBCAT3,FAD_SUBCAT4,FAD_SUBCAT5,FPACKAGE_CODE,FPAGE_PREM,FPAGE_POST,FSUPP_CODE ,FRATECD
,FPUB_CENT_PERMIT from ad_bills_det where ad_bills_det.COMP_CODE_V=comp_cod AND ad_bills_det.bilno=bil_no;
/**************************  For Tbl_booking_mast  *********************************************/
--select max(nvl(fun_actual(comp_cod,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_mast."Gross_amount",0),prefer,1 ),0)),-- "RetComm(%)"
select max(
nvl(case(prefer)
    when 'Y' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",0) AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",0)) AND ROWNUM<=1)


          when 'Gross' then
                 (
                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,0))-to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 )))
                end )

         when 'Net'   then  to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,'0'))


         --when 'Gross' then ((select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )-nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0' ))
         --when 'Net'   then  (select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )
        END )

    ELSE (select 0  from dual)
end  ,'0')),
--max(nvl(fun_actual(comp_cod,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_mast."Gross_amount",0),prefer,2 ),0)),--"RetCommAmt"
max(nvl(
case( prefer )
    when 'Y' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1)

        when 'Gross' then


         (

                 --CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,0))
                    -- WHEN 0 THEN 0
                    -- ELSE (to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,'0'))-(nvl((nvl(FGrossamt,'0')*to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0'))/100),'0')))

                -- end

                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (nvl(FGrossamt,0)*(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,'0'))-to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0')) )/100)
                 end
                )

         when 'Net'   then  (nvl(FGrossamt,0)*(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,'0')) )/100)




         --when 'Gross' then (nvl(tbl_booking_mast."Gross_amount",'0')*((select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )-nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0' ))/100)
         --when 'Net'   then  (nvl(tbl_booking_mast."Gross_amount",'0')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )/100)
        END )

    ELSE (select 0  from dual)
end
,'0')),

--max(nvl(fun_actual(comp_cod,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_mast."Gross_amount",0),prefer,3 ),0)),--"RetTD(%)"
max((select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )),

--max(nvl(fun_actual(comp_cod,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_mast."Gross_amount",0),prefer,4 ),0)),--"RetTDAmt"
max(nvl(FGrossamt,'0')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )/100),

--max(nvl((f_bil_amt-nvl(fun_actual(comp_cod,nvl(tbl_booking_mast."ADD_AGENCY_COMM",0 ),nvl(tbl_booking_mast."RETAINER",0),nvl(tbl_booking_mast."Gross_amount",0),prefer,2 ),0)  ),0))--"ActualBusiness"
max(nvl((f_bil_amt-nvl(
case( prefer )
    when 'Y' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1)
         when 'Gross' then
                 (
                -- CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,0))
                -- WHEN 0 THEN 0
                -- ELSE (to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,'0'))-(nvl((nvl(FGrossamt,'0')*to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0'))/100),'0')))
                -- end

                CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (nvl(FGrossamt,0)*(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,'0'))-to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0')) )/100)
                 end



                 )

         when 'Net'   then  (nvl(FGrossamt,'0')*(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,'0')) )/100)

         --when 'Gross' then (nvl(tbl_booking_mast."Gross_amount",'0')*((select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )-nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0' ))/100)
         --when 'Net'   then  (nvl(tbl_booking_mast."Gross_amount",'0')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",'0'))    from RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"=comp_cod and "Retain_Code"=nvl(tbl_booking_mast."RETAINER",'0')) AND ROWNUM<=1 )/100)
        END )

    ELSE (select 0  from dual)
end
,'0')  ),0))--"ActualBusiness"

,max(tbl_booking_mast."No_of_insertion"),max(tbl_booking_mast."Paid_ins"),
max(tbl_booking_mast."Deviation"),max(tbl_booking_mast."Deviation") ,max(tbl_booking_mast."Agrred_rate"),max(tbl_booking_mast."Agreed_amount"),
max(tbl_booking_mast."Discount_per") ,max(tbl_booking_mast."Special_disc_per"),max(tbl_booking_mast."Space_disc_per"),
max(tbl_booking_mast."Special_charges"),max(nvl(tbl_booking_mast."ADD_AGENCY_COMM",0)),
max(nvl((FAgencyAddlTDAmt*nvl(tbl_booking_mast."ADD_AGENCY_COMM",0)/100),0))
,max("Uom_code") into FRetCommPer,FRetCommAmt,FRetTDPer,FRetTDAmt,FActualBusiness
,Fnoinsert,FPaidinsert,FDeviationamt,FDeviationper,FAggrate,Faggamt,FDiscper,FSpdiscper,FSpacediscper,FSpecialcharge,FAgencyAddlTDper,FAgencyAddlTDAmt
,FfUom  from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=FCIOID;
--***************************  variables  ***********************************************************
Fagency:=f_agname;
FClient:=AD_GET_CLIENTNAME (comp_cod,FfClient);
FExecutive:=f_execname;
FRetainer:=f_retname;
FAdcat:=AD_GET_catnameE(comp_cod,FfAdcat,'cat');
FAdsubcat:=AD_GET_catnameE(comp_cod,FfAdsubcat,'subcat');
FAdsubcat3:=AD_GET_catnameE(comp_cod,FfAdsubcat3,'cat3');
FAdsubcat4:=AD_GET_catnameE(comp_cod,FfAdsubcat4,'cat4');
FAdsubcat5:=AD_GET_catnameE(comp_cod,FfAdsubcat5,'cat5');
FPagepremium:=AD_GET_catnameE(comp_cod,FfPagepremium,'pprem');
Fscheme:=AD_GET_catnameE(comp_cod,Ffscheme,'fschem');
FColor:=AD_GET_catnameE(comp_cod,FfColor,'fcol');
FSpdiscamt:= (round((( nvl(FSpdiscper,0) * nvl(FArea,0) * nvl(Fcardrate,0))/100),2)) ;
FSpacedisc:= (round(((nvl(FSpacediscper,0) * nvl(FArea,0) * nvl(Fcardrate,0))/100),2))  ;
Fcardamt:=(nvl(Fcardrate,0) * nvl(FArea,0) * nvl(Fnoinsert,0))     ;
select max((nvl(Fcardrate,0) * nvl(FArea,0) * nvl(Fnoinsert,0)) - DECODE(NVL(Faggamt,0) ,0,(nvl(Fcardrate,0) * nvl(FArea,0) * nvl(Fnoinsert,0)),NVL(Faggamt,0) )) into FDiscAmt from dual  ;
select max(UOM_MAST."Uom_Name"),max(uom_mast.UOM_DESC)  into FUom,FUomDesc   from uom_mast where "Uom_Code" =FfUom;

BEGIN
select "pub_center" into FffPub_cent_Code from BRANCH_MST where "Branch_Code"=FfPub_cent_Code;
EXCEPTION WHEN no_data_found then
FffPub_cent_Code:=null;
end;

select max("Pub_cent_Code"),MAX("Pub_Cent_name") into FPub_cent_Code,FPub_cent_Name from PUB_CENT_MAST where "Pub_cent_Code"=FffPub_cent_Code;
select max(branch_mst."Branch_Name") into FBranch_Name from branch_mst where branch_mst."Branch_Code"= FfBranch_Name;
select max(agency_mast."region"),max(agency_mast."Agency_Type_Code") into Fregion,FAgency_Type_Code from agency_mast where AGENCY_MAST."code_subcode"=f_agcode;
select max(brand_mst."brand_code") into Fbrand_code from brand_mst where brand_mst."prod_cat_code"=ffPRIPROCTG;
select max(varient_mst."Varient_Name") into FVarient_Name from varient_mst where varient_mst."Brand_Code"=Fbrand_code;
--**********************************************************************************************************************

select max(exec_mast."city_code") into f_exec_city from exec_mast where "Exe_no"=f_execcode;
select max(city_mst."Zone_Code") into f_city_zone from city_mst where city_mst."City_Code"=f_exec_city;

if(base='1') then
     select max(Agency_mast."Dist_Code"),max(AGENCY_MAST.TALUKA) ,max(AGENCY_MAST."City_Code"),max(AGENCY_MAST."zone_code"),max(AGENCY_MAST."State_Code")
     into Fag_dist_code,Fag_talu_code,Fag_city_code,Fag_zone_code,Fag_state_code
     from agency_mast where "code_subcode"=f_agcode ;

 elsif(base='2') then
      select max(exec_mast."dist_code"),max(exec_mast.TALUKA) ,max(exec_mast."city_code"),f_city_zone,max(exec_mast."State_code")
      into Fag_dist_code,Fag_talu_code,Fag_city_code,Fag_zone_code,Fag_state_code
      from exec_mast where "Exe_no"=f_execcode ;

 else
       select max(RETAINERMASTER."Dist_Code"),max(RETAINERMASTER.TALUKA) ,max(RETAINERMASTER."City_Code"),max(RETAINERMASTER."Zone_Code"),max(RETAINERMASTER."State_Code")
       into Fag_dist_code,Fag_talu_code,Fag_city_code,Fag_zone_code,Fag_state_code
       from RETAINERMASTER where "Retain_Code" =f_retcode;

  end if;

select max(dist_mst."Dist_Name") into Fdist_name from dist_mst where "Dist_Name"=Fag_dist_code;

select max(taluka_mast.TALU_NAME) into Ftalu_name from taluka_mast where TALU_CODE=Fag_talu_code;

select max(city_mst."City_Name") into Fcity_name  from city_mst where "City_Code"=Fag_city_code;

select max(zone_mast."Zone_Name") into Fzone_name from zone_mast where  "Zone_Code"=Fag_zone_code;

select max(state_mst."State_Name") into Fstate_name from state_mst where  "State_Code"=Fag_state_code;

insert into temp_ad_bills_report
(
CIOID,Billno,Agency,Client,RoNo,RoDate,Executive,Retainer,BookType,Color,Adcat,Adsubcat,Adsubcat3,Adsubcat4,Adsubcat5,Packag,BillDate,
noinsert,Paidinsert,height,width,Area,Pagepremium,Postprem,scheme,Ratecod,cardrate,cardamt,contractrate,Deviationamt,Deviationper,
Aggrate,aggamt,DiscAmt,Discper,posamt,posper,Spdiscamt,Spdiscper,Spacedisc,Spacediscper,Specialcharge,AgencyAddlTDper,AgencyAddlTDAmt,
Grossamt,RetTDPer,RetTDAmt,AgencyTDPer,AgencyTDAmt,Billamt,RetCommPer,RetCommAmt,ActualBusiness,Revcenter,Uom,UomDesc,
    PADTYPE ,  PRIPUB,  PEDITION,  BRANCH_NAME ,  PUB_CENT_CODE ,  REGION,  AGENCY_TYPE_CODE,  PRIADCTG,  SECADCTG,  AD_SUBCAT3,  AD_SUBCAT4,
  AD_SUBCAT5,  PACKAGE_CODE,  AG_MAIN_CODE,   CLIENTCD,  EXECUTIVE_NAME,  PRIPROCTG ,  BRAND_CODE,  VARIENT_NAME,  PAGE_PREM ,  PAGE_POST ,
  CONTRACT_NAME ,  SUPP_CODE ,  RETAINER_CODE ,  RATECD,    PSCHEME ,  REVENUE_CENTER,  RO_STATUS ,  PAGE_TYPE ,  BOOKING_TYPE,COMP_CODE,AG_SUB_CODE,
  PUB_CENT_PERMIT,sess_id,DIST_NAME,TALU_NAME,PUB_CENT_NAME,
  CITY_CODE,ZONE_CODE,DIST_CODE,STATE_CODE,PTALUKA,CITY_NAME,ZONE_NAME,STATE_NAME,PAGE_NO,BILL_REMARK
)
values
(
FCIOID  ,FBillno  ,FAgency  ,FClient  ,FRoNo  ,FRoDate  ,FExecutive  ,FRetainer  ,FBookType  ,FColor  ,FAdcat  ,FAdsubcat  ,FAdsubcat3  ,FAdsubcat4  ,
FAdsubcat5  ,FPackag  ,FBillDate  ,Fnoinsert  ,FPaidinsert  ,Fheight  ,Fwidth  ,FArea  ,FPagepremium  ,FPostprem  ,Fscheme  ,FRatecod  ,Fcardrate  ,
Fcardamt  ,Fcontractrate  ,FDeviationamt  ,FDeviationper  ,FAggrate  ,Faggamt  ,FDiscAmt  ,FDiscper  ,Fposamt  ,Fposper  ,FSpdiscamt  ,FSpdiscper  ,
FSpacedisc  ,FSpacediscper  ,FSpecialcharge  ,FAgencyAddlTDper  ,FAgencyAddlTDAmt  ,FGrossamt  ,FRetTDPer   ,FRetTDAmt  ,FAgencyTDPer  ,
FAgencyTDAmt  ,FBillamt  ,FRetCommPer  ,FRetCommAmt   ,FActualBusiness  ,FRevcenter   ,FUom ,FUomDesc,
Fpadtype,FPRIPUB,FPEDITION,FBranch_Name,FPub_cent_Code,Fregion,FAgency_Type_Code,FPRIADCTG,FSECADCTG,FAD_SUBCAT3,FAD_SUBCAT4,
FAD_SUBCAT5,FPACKAGE_CODE,FAG_MAIN_CODE,FCLIENTCD,FEXECUTIVE_NAME,FPRIPROCTG,Fbrand_code,FVarient_Name,FPAGE_PREM,FPAGE_POST,
FCONTRACT_NAME,FSUPP_CODE,FRETAINER_CODE,FRATECD,FPSCHEME,FREVENUE_CENTER,FRO_STATUS,FPAGE_TYPE,FBOOKING_TYPE,FCOMP_CODE,FAG_SUB_CODE,
FPUB_CENT_PERMIT,userenv('sessionid'),Fdist_name,Ftalu_name,FPub_cent_Name,
Fag_city_code,Fag_zone_code,Fag_dist_code,Fag_state_code,Fag_talu_code,Fcity_name,Fzone_name, Fstate_name,f_page_no,f_billremark
);
commit;


return 0;

--exception when others then
--insert into amit_amit(COMPCODE,subcode,name) values(comp_cod,cio_id,bil_no);  commit;
END;
/


========================end=================7032====avinash====16apr2012========================

/***********mimoh 16042012****************************7196********************************/
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
      p_raterevise        in varchar2,
      p_editionwisebilling    in varchar2
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
      p_raterevise        in varchar2,
      p_editionwisebilling    in varchar2
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
                   "qbc_userid","Creation_Datetime","TALUKA","Branch_code",DISTRICT,STATE,BILL_FREQUENCY,OLD_AGENCY,BOOKING_TYPE,VAT,RATE_REVISE,EDTN_WISE_BILL_REQ
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
                   qbcuserid,sysdate,taluka1,branchcode,hddistcode,hdstatecode,billf,oldagency,booktype1,vat1, p_raterevise,p_editionwisebilling
                  );
     /* TO INSERT DATA IN AGENCY HISTORY LOG*/
                 INSERT INTO AGENCY_REMARK_DETAIL(COMP_CODE, AGENCY_CODE, SUB_AGENCY_CODE, CODE_SUBCODE, AGENCY_ALERT, AGENCY_REMARK, USERID)
                        VALUES(compcode,agentcode,agencycode,agentcode || agencycode,alert,remarks,userid);

      COMMIT;
   END websp_saveagent_p;
END websp_saveagent;
/


/*********************************************************************************************************/


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
      depocode             IN    VARCHAR2,
      taluka1              IN    VARCHAR2,
      branchcode           IN    VARCHAR2,
      hddistcode           in varchar2,
      hdstatecode          in varchar2 ,
      billf                in varchar2,
      oldagen              in varchar2,
      booktype1            in varchar2,
      vat1                 in varchar2,
      p_raterevise         in varchar2,
      p_insertremarkdet    in varchar2,
      p_editionwisebilling    in varchar2
   );
END websp_agencymodify;
/
/*************************************************************************************************/

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
      depocode                IN    VARCHAR2,
      taluka1              IN    VARCHAR2,
      branchcode           IN    VARCHAR2,
      hddistcode           in varchar2,
      hdstatecode          in varchar2 ,
      billf                in varchar2,
      oldagen              in varchar2,
      booktype1            in varchar2,
      vat1                 in varchar2,
      p_raterevise         in varchar2,
      p_insertremarkdet    in varchar2,
      p_editionwisebilling    in varchar2
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
             RATE_REVISE=p_raterevise,EDTN_WISE_BILL_REQ =p_editionwisebilling
       WHERE "Comp_Code" = compcode AND "SUB_Agency_Code" = agencycode;

        --UPDATE ad_user SET "DEPO_CODE"=depocode where "AGENCY_CODE"=agentcode;
        
        /* TO INSERT DATA IN AGENCY HISTORY LOG*/
        IF(p_insertremarkdet = '1') THEN
                 INSERT INTO AGENCY_REMARK_DETAIL(COMP_CODE, AGENCY_CODE, SUB_AGENCY_CODE, CODE_SUBCODE, AGENCY_ALERT, AGENCY_REMARK, USERID)
                        VALUES(compcode,agentcode,agencycode,agentcode || agencycode,alert1,remarks,userid);
                        
        END IF;

      COMMIT;
   END websp_agencymodify_p;
END websp_agencymodify;
/
/********************************************************************/


DROP PACKAGE HT18JULY.WEBSP_EXECUTEAGENCY;

CREATE OR REPLACE PACKAGE HT18JULY.Websp_Executeagency
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



DROP PACKAGE BODY HT18JULY.WEBSP_EXECUTEAGENCY;

CREATE OR REPLACE PACKAGE BODY HT18JULY.Websp_Executeagency
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
                RATE_REVISE,EDTN_WISE_BILL_REQ 
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












/*

DECLARE

 CURSOR c1 IS SELECT  SUB_AGENCY_CODE FROM FIRST1 ORDER BY sub_agency_code;
 AuthorID VARCHAR(100);
 BEGIN



OPEN c1;
LOOP
FETCH c1 INTO AuthorID;

EXIT WHEN c1%NOTFOUND;













UPDATE FIRST1 SET STATUS_NAME= (SELECT   "STATUS_NAME"    FROM STATUS_DETAIL WHERE AGENCY_SUBCAT_CODE=AuthorID AND ROWNUM<=1)
 WHERE SUB_AGENCY_CODE=AuthorID;

UPDATE FIRST1 SET TO_DATE= (SELECT "TO_DATE"    FROM STATUS_DETAIL WHERE AGENCY_SUBCAT_CODE=AuthorID AND ROWNUM<=1  )
 WHERE SUB_AGENCY_CODE=AuthorID;
END LOOP;

CLOSE c1;
END;







OPEN p_accounts FOR
SELECT  COMP_CODE AS "Comp_Code", AGENCY_TYPE_CODE AS "Agency_Type_Code", AGENCY_CAT_CODE AS "Agency_Cat_Code" , AGENCY_SUBCAT_CODE AS "Agency_SubCat_Code" , AGENCY_CODE AS "Agency_Code", AGENCY_NAME AS "Agency_Name" , AGENCY_ALIAS AS "Agency_Alias" , AGENCY_HO AS "Agency_HO", ADD1 AS "Add1", STREET AS "Street" , CITY_CODE AS "City_Code", ZIP AS "Zip", DIST_CODE AS "Dist_Code", STATE_CODE AS "State_Code", COUNTRY_CODE AS "Country_Code", PHONE AS "Phone" , FAX AS "Fax", EMAILID AS "EmailID", URL, BUSS_START_DATE AS "Buss_Start_Date", ENROLL_DATE AS "Enroll_Date", MRV_REF_NO AS "MRV_Ref_No", NO_OF_VTS AS "No_of_VTS", CREDIT_DAYS AS "Credit_Days", PAN_NO, TAN_NO, ST_ACC_NO, PAY_MODE_CODE AS "Pay_Mode_Code" , STATUS_NAME, STATUS_REASON AS "Status_Reason" , REMARKS AS "Remarks", USERID AS "UserID", CURRENT_DATETIME AS "current_Datetime", USERS AS "users", SUB_AGENCY_HO AS "SUB_Agency_HO", SUB_AGENCY_CODE AS "SUB_Agency_Code", BILL_TO, ALERT, CREDIT_LIMIT, CODE, REPRESENTATIVE_CODE AS "Representative_code", PIN_CODE AS"pin_code"  , Region AS "region", TO_DATE, "TYPE" AS "Type", CODE_SUBCODE AS "code_subcode", ZONE_CODE AS "zone_code", ADD2 AS "Add2", ADD3 AS "Add2", CREDIT_TYPE, ACAGENCY AS "acagency", FAX1 AS "fax1" , RATE_GROUP AS "Rate_Group", QBC_USERID AS "qbc_userid"
  FROM FIRST1      WHERE COMP_CODE = compcode OR compcode IS NULL
                AND AGENCY_CODE LIKE agentcode || '%' OR agentcode IS NULL
                AND SUB_AGENCY_CODE LIKE subagencycode || '%'  OR subagencycode IS NULL
                AND AGENCY_NAME LIKE agencyname1 || '%' OR agencyname1  IS NULL
                AND AGENCY_ALIAS LIKE alias || '%'  OR alias IS NULL
                AND AGENCY_TYPE_CODE LIKE agenttype || '%'  OR agenttype IS NULL
                AND AGENCY_CAT_CODE LIKE agentcategory  || '%' OR agentcategory IS NULL;

*/

       END websp_executeagency_p;
END Websp_Executeagency;
/


/***********mimoh 16042012****************************7196********************************/

/***********ankit****************************ad category********************************/


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
status1 in varchar2,
productivity in varchar2,
hrs in varchar2,
min in varchar2
);
END Advinsert;
/


-------------------------------------------------------------------------------------
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
status1 in varchar2,
productivity in varchar2,
hrs in varchar2,
min in varchar2

)AS
BEGIN

INSERT INTO ADV_CAT_MAST ("Comp_Code", "UserId", "Adv_Cat_Code","Adv_Cat_Name","Adv_Cat_Alias","Creation_Datetime","Adv_Type",REGCLIENT,CAT_FILE_NAME,STATUS,PREODICITY_CODE,RO_HR,RO_MIN) VALUES (compcode, userid, adcatcode,  catname, catalias,SYSDATE,Adtype,rclient,filename,status1,productivity,hrs,min);
COMMIT;
END advinsert_p;
END Advinsert;
/



--------------------------------------------------------------------------------------

CREATE OR REPLACE PACKAGE advupdate Is

Procedure advupdate_P (
compcode in varchar2,
adcatcode in varchar2,
catalias in varchar2,
catname in varchar2,
adtype in varchar2,
rclient in varchar2,
filename in varchar2,
status1 in varchar2,
productivity in varchar2,
hrs in varchar2,
min in varchar2
);

End advupdate;
/






--------------------------------------------------------------------------------------




CREATE OR REPLACE PACKAGE BODY advupdate Is
Procedure advupdate_P(
compcode in varchar2,
adcatcode in varchar2,
catalias in varchar2,
catname in varchar2,
adtype in varchar2,
rclient in varchar2,
filename in varchar2,
status1 in varchar2,
productivity in varchar2,
hrs in varchar2,
min in varchar2
)As
Begin
update Adv_Cat_Mast set REGCLIENT=rclient, "Adv_Cat_Name"=catname,"Adv_Cat_Alias"=catalias,"Creation_Datetime"=sysdate(),"Adv_Type"=adtype,CAT_FILE_NAME=filename,STATUS=status1,PREODICITY_CODE=productivity , RO_HR=hrs ,RO_MIN=min  where "Comp_Code"=compcode and "Adv_Cat_Code"=adcatcode;
End advupdate_P;
End advupdate;
/




-----------------------------------------------------------------------------------------------------





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
SELECT "Comp_Code", "Adv_Cat_Code", "Adv_Cat_Name","Adv_Cat_Alias","UserId","Creation_Datetime","Adv_Type",REGCLIENT,CAT_FILE_NAME,STATUS,PREODICITY_CODE,RO_HR,RO_MIN FROM ADV_CAT_MAST
WHERE  ("Comp_Code"=compcode OR compcode IS NULL)
AND ("Adv_Cat_Code"=adcatcode OR adcatcode IS NULL)
AND ("Adv_Type" LIKE Adtype || '%' OR Adtype IS NULL)
AND ("Adv_Cat_Alias" LIKE catalias || '%' OR catalias IS NULL)
AND ("Adv_Cat_Name" LIKE catname || '%' OR catname IS NULL);





/*AND ("Adv_Cat_Code"=adcatcode OR adcatcode IS NULL)
AND ("Adv_Type"=Adtype OR Adtype IS NULL)
AND ("Adv_Cat_Alias"=catalias || '%')
AND ("Adv_Cat_Name"=catname || '%');






ELSIF catalias IS NOT NULL THEN
OPEN P_Accounts FOR
SELECT "Comp_Code", "Adv_Cat_Code", "Adv_Cat_Name","Adv_Cat_Alias","UserId","Creation_Datetime","Adv_Type" FROM ADV_CAT_MAST
WHERE  ("Comp_Code"=compcode OR compcode IS NULL)
AND ("Adv_Cat_Code"=adcatcode OR adcatcode IS NULL)
AND ("Adv_Type"=Adtype OR Adtype IS NULL)
AND ("Adv_Cat_Alias"=catalias || '%');


ELSIF catname IS NOT NULL THEN
OPEN P_Accounts FOR
SELECT "Comp_Code", "Adv_Cat_Code", "Adv_Cat_Name","Adv_Cat_Alias","UserId","Creation_Datetime","Adv_Type" FROM ADV_CAT_MAST
WHERE  ("Comp_Code"=compcode OR compcode IS NULL)
AND ("Adv_Cat_Code"=adcatcode OR adcatcode IS NULL)
AND ("Adv_Type"=Adtype OR Adtype IS NULL)
AND ("Adv_Cat_Name"=catname || '%');

ELSE
OPEN p_Accounts FOR
SELECT "Comp_Code", "Adv_Cat_Code", "Adv_Cat_Name","Adv_Cat_Alias","UserId",SYSDATE AS "Creation_Datetime" ,"Adv_Type" FROM ADV_CAT_MAST
WHERE ("Comp_Code"=compcode OR compcode IS NULL)
AND  ("Adv_Cat_Code"=adcatcode OR adcatcode IS NULL)
AND ("Adv_Type"=Adtype OR Adtype IS NULL);


END IF;*/


END advcatexec_P;

END Advcatexec;
/








----------------------------------------------------------------------------------------------------------

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







/***********ankit****************************ad category********************************/





/***********ankit*************************************creat user*******************7143***********************/





CREATE OR REPLACE PACKAGE BODY Logininsert
IS


   PROCEDURE  loginInsert_p (
username IN VARCHAR2,
password IN VARCHAR2,
userid1 IN VARCHAR2,
date_format IN VARCHAR2,
comp_name IN VARCHAR2,
com_code IN VARCHAR2,
curr_code IN VARCHAR2,
retainer_code IN VARCHAR2,
agencycode IN VARCHAR2,
USER IN  VARCHAR2,
ADMIN1 IN VARCHAR2,
comp_user IN VARCHAR2,
compnamelist in varchar2,
emailid  in varchar2,
disc in varchar2,
fil in varchar2,
role in varchar2,
editlines in varchar2,
firstname in varchar2,
lastname in varchar2,
pstatus  in varchar2,
p_empcode  in varchar2,
p_acccode  in varchar2
) AS

BEGIN


INSERT INTO LOGIN("username","password","userid","date_format","comp_name","COM_CODE","curr_code","retainer_code","Agency_code","User_status","Admin","Company_user",USER_COMPANY,EMAIL,DISCOUNT,FILTER,ROLEID,BOOKING_EDITLINES,FIRSTNAME,LASTNAME,STATUS,HR_CODE,ACC_CODE)

VALUES(username,password,userid1,date_format,comp_name,com_code,curr_code,retainer_code,agencycode,USER,ADMIN1,comp_user,compnamelist,emailid,disc,fil,role,editlines,firstname,lastname,pstatus,p_empcode,p_acccode);
DELETE FROM MODULE_DETAIBUTTONL WHERE MODULE_DETAIBUTTONL."userid"=userid1;
COMMIT;
dbms_output.put_line(userid1);
INSERT INTO MODULE_DETAIBUTTONL("Button_id", "Form_Name", "comp_code", "userid", "Module_No", "Form_id", "Paid_permission", "Backdate_booking", "Ro_date_perm", "Confirm_qbc", BACK_DAYS) SELECT BUTTONID, FORM_NAME,COMPCODE,userid1,'',FORM_ID,'','','','',''  FROM ROLE_PERMISSION WHERE ROLEID=role;
update MODULE_DETAIBUTTONL set modulecode=(select modulecode from formmast where "Form_Name"= MODULE_DETAIBUTTONL."Form_Name" and rownum<=1) where "userid"=userid1;
COMMIT;

END   loginInsert_p;
END   Logininsert;
/




---------------------------------------------------------------------------------------------------------------------------


CREATE OR REPLACE PACKAGE Logininsert
IS


   PROCEDURE  loginInsert_p (  username IN VARCHAR2,
password IN VARCHAR2,
userid1 IN VARCHAR2,
date_format IN VARCHAR2,
comp_name IN VARCHAR2,
com_code IN VARCHAR2,
curr_code IN VARCHAR2,
retainer_code IN VARCHAR2,

agencycode IN VARCHAR2,
USER IN  VARCHAR2,
ADMIN1 IN VARCHAR2,
comp_user IN VARCHAR2,
compnamelist in varchar2,
emailid  in varchar2,
disc in varchar2,
fil in varchar2,
role in varchar2,
editlines in varchar2,
firstname in varchar2,
lastname in varchar2,
pstatus  in varchar2,
p_empcode  in varchar2,
p_acccode  in varchar2
);
END   Logininsert;
/






==========================================================================================================


CREATE OR REPLACE PACKAGE Loginmodify
IS


   PROCEDURE   loginModify_p (username IN VARCHAR2,
password IN VARCHAR2,
userid1 IN VARCHAR2,
date_format IN VARCHAR2,
comp_name IN VARCHAR2,
compcode IN VARCHAR2,
curr_code IN VARCHAR2,
retainer_code IN VARCHAR2,

agencycode IN VARCHAR2,
USER IN  VARCHAR2,
ADMIN1 IN VARCHAR2,
comp_user IN VARCHAR2,
companylist in varchar2,
emailid  in varchar2,
disc in varchar2,
fil in varchar2,
role in varchar2,
editlines in varchar2,
fname in varchar2,
lname in varchar2,
pstatus  in varchar2,
p_empcode  in varchar2,
p_acccode  in varchar2
 );
END    Loginmodify ;
/



-
------------------------------------------------------------------------------------------------------------------------





CREATE OR REPLACE PACKAGE BODY Loginmodify
IS


   PROCEDURE   loginModify_p (username IN VARCHAR2,
password IN VARCHAR2,
userid1 IN VARCHAR2,
date_format IN VARCHAR2,
comp_name IN VARCHAR2,
compcode IN VARCHAR2,
curr_code IN VARCHAR2,
retainer_code IN VARCHAR2,

agencycode IN VARCHAR2,
USER IN  VARCHAR2,
ADMIN1 IN VARCHAR2,
comp_user IN VARCHAR2,
companylist in varchar2,
emailid  in varchar2,
disc in varchar2,
fil in varchar2,
role in varchar2,
editlines in varchar2,
fname in varchar2,
lname in varchar2,
pstatus  in varchar2,
p_empcode  in varchar2,
p_acccode  in varchar2
) AS


BEGIN

UPDATE LOGIN SET FIRSTNAME=fname,LASTNAME=lname , BOOKING_EDITLINES=editlines, ROLEID=role,FILTER=fil, DISCOUNT=disc, "username"=username, "password"=password, "date_format"=date_format, "comp_name"=comp_name, "COM_CODE"=com_code, "curr_code"=curr_code,

"retainer_code"=retainer_code,"Agency_code"=agencycode,"User_status"=USER,"Admin"=ADMIN1,"Company_user"=comp_user,USER_COMPANY=companylist,EMAIL=emailid,STATUS=pstatus,HR_CODE=p_empcode,ACC_CODE=p_acccode WHERE "userid"=userid1;
/*
if(role!='0' or  role is not null)
then
DELETE FROM MODULE_DETAIBUTTONL WHERE MODULE_DETAIBUTTONL."userid"=userid1;
COMMIT;
INSERT INTO MODULE_DETAIBUTTONL SELECT BUTTONID, FORM_NAME,COMPCODE,userid1,'',FORM_ID,'','','',''  FROM ROLE_PERMISSION WHERE ROLEID=role;
COMMIT;
end if;*/

END    loginModify_p ;
END    Loginmodify ;
/




==================================================================================================================================

CREATE OR REPLACE PACKAGE BODY Loginexecute IS
PROCEDURE  Loginexecute_p (
username IN VARCHAR2,
userid IN VARCHAR2,
com_code IN VARCHAR2,
admin1 IN VARCHAR2,
p_accounts   OUT  t_accounts_cursor

)AS
BEGIN
dbms_output.put_line(admin1);
if(admin1 is null) then

 OPEN p_accounts FOR
         SELECT "username", "password", "userid", "date_format", "COM_CODE", "comp_name", "Autogenerate", "curr_code", "retainer_code",AD_GET_FIELDNAME1('Comp_Code',com_code,'code_subcode',LOGIN."Agency_code",'Agency_Name','Agency_mast','','') AS AGENCY_NAME,"Agency_code", "User_status", "Admin", "Company_user", USER_COMPANY, CREATION_DATETIME, EMAIL, DISCOUNT, FILTER, ROLEID, BOOKING_EDITLINES, FIRSTNAME, LASTNAME, ROLE, STATUS, DOMAIN_USER, ad_get_fieldname('COMP_CD',com_code,'EMP_CODE',LOGIN.HR_CODE,'NAME','HR_EMP_MST','','') AS HR_CODE,(select ACC_NAME from fa_acc_mast where CDP=LOGIN.ACC_CODE) as ACC_NAME,ACC_CODE   FROM LOGIN 
          WHERE "Admin"is null
            and ("COM_CODE" = com_code OR com_code IS NULL)
            AND ("username" LIKE username || '%' OR username IS NULL)
            AND ("userid" LIKE userid || '%' OR userid IS NULL);
  else
     OPEN p_accounts FOR
         SELECT "username", "password", "userid", "date_format", "COM_CODE", "comp_name", "Autogenerate", "curr_code", "retainer_code",AD_GET_FIELDNAME1('Comp_Code',com_code,'code_subcode',LOGIN."Agency_code",'Agency_Name','Agency_mast','','') AS AGENCY_NAME, "Agency_code", "User_status", "Admin", "Company_user", USER_COMPANY, CREATION_DATETIME, EMAIL, DISCOUNT, FILTER, ROLEID, BOOKING_EDITLINES, FIRSTNAME, LASTNAME, ROLE, STATUS, DOMAIN_USER, ad_get_fieldname('COMP_CD',com_code,'EMP_CODE',LOGIN.HR_CODE,'NAME','HR_EMP_MST','','') AS HR_CODE,(select ACC_NAME from fa_acc_mast where CDP=LOGIN.ACC_CODE) as ACC_NAME,ACC_CODE  FROM LOGIN
          WHERE  "Admin"='yes'
          and ("COM_CODE" = com_code OR com_code IS NULL)
            AND ("username" LIKE username || '%' OR username IS NULL)
            AND ("userid" LIKE userid || '%' OR userid IS NULL);       
end if;

END Loginexecute_p;
END Loginexecute;
/

===
================================================================================================================================

CREATE OR REPLACE PACKAGE Loginexecute IS
 TYPE t_accounts_cursor IS REF CURSOR;
 PROCEDURE  loginexecute_p (
 username IN VARCHAR2,
 userid IN VARCHAR2,
 com_code IN VARCHAR2,
 admin1 IN VARCHAR2,
 p_accounts   OUT      t_accounts_cursor
 --p_accounts1   OUT      t_accounts_cursor,
 --p_accounts2   OUT      t_accounts_cursor
 );
 END Loginexecute;
/





CREATE OR REPLACE PACKAGE BODY Loginmodify
IS


   PROCEDURE   loginModify_p (username IN VARCHAR2,
password IN VARCHAR2,
userid1 IN VARCHAR2,
date_format IN VARCHAR2,
comp_name IN VARCHAR2,
compcode IN VARCHAR2,
curr_code IN VARCHAR2,
retainer_code IN VARCHAR2,

agencycode IN VARCHAR2,
USER IN  VARCHAR2,
ADMIN1 IN VARCHAR2,
comp_user IN VARCHAR2,
companylist in varchar2,
emailid  in varchar2,
disc in varchar2,
fil in varchar2,
role in varchar2,
editlines in varchar2,
fname in varchar2,
lname in varchar2,
pstatus  in varchar2,
p_empcode  in varchar2,
p_acccode  in varchar2
) AS


BEGIN

UPDATE LOGIN SET FIRSTNAME=fname,LASTNAME=lname , BOOKING_EDITLINES=editlines, ROLEID=role,FILTER=fil, DISCOUNT=disc, "username"=username, "password"=password, "date_format"=date_format, "comp_name"=comp_name, "COM_CODE"=com_code, "curr_code"=curr_code,

"retainer_code"=retainer_code,"Agency_code"=agencycode,"User_status"=USER,"Admin"=ADMIN1,"Company_user"=comp_user,USER_COMPANY=companylist,EMAIL=emailid,STATUS=pstatus,HR_CODE=p_empcode,ACC_CODE=p_acccode WHERE "userid"=userid1;
/*
if(role!='0' or  role is not null)
then
DELETE FROM MODULE_DETAIBUTTONL WHERE MODULE_DETAIBUTTONL."userid"=userid1;
COMMIT;
INSERT INTO MODULE_DETAIBUTTONL SELECT BUTTONID, FORM_NAME,COMPCODE,userid1,'',FORM_ID,'','','',''  FROM ROLE_PERMISSION WHERE ROLEID=role;
COMMIT;
end if;*/

END    loginModify_p ;
END    Loginmodify ;
/



CREATE OR REPLACE PACKAGE BODY Loginmodify
IS


   PROCEDURE   loginModify_p (username IN VARCHAR2,
password IN VARCHAR2,
userid1 IN VARCHAR2,
date_format IN VARCHAR2,
comp_name IN VARCHAR2,
compcode IN VARCHAR2,
curr_code IN VARCHAR2,
retainer_code IN VARCHAR2,

agencycode IN VARCHAR2,
USER IN  VARCHAR2,
ADMIN1 IN VARCHAR2,
comp_user IN VARCHAR2,
companylist in varchar2,
emailid  in varchar2,
disc in varchar2,
fil in varchar2,
role in varchar2,
editlines in varchar2,
fname in varchar2,
lname in varchar2,
pstatus  in varchar2,
p_empcode  in varchar2,
p_acccode  in varchar2
) AS


BEGIN

UPDATE LOGIN SET FIRSTNAME=fname,LASTNAME=lname , BOOKING_EDITLINES=editlines, ROLEID=role,FILTER=fil, DISCOUNT=disc, "username"=username, "password"=password, "date_format"=date_format, "comp_name"=comp_name, "COM_CODE"=com_code, "curr_code"=curr_code,

"retainer_code"=retainer_code,"Agency_code"=agencycode,"User_status"=USER,"Admin"=ADMIN1,"Company_user"=comp_user,USER_COMPANY=companylist,EMAIL=emailid,STATUS=pstatus,HR_CODE=p_empcode,ACC_CODE=p_acccode WHERE "userid"=userid1;
/*
if(role!='0' or  role is not null)
then
DELETE FROM MODULE_DETAIBUTTONL WHERE MODULE_DETAIBUTTONL."userid"=userid1;
COMMIT;
INSERT INTO MODULE_DETAIBUTTONL SELECT BUTTONID, FORM_NAME,COMPCODE,userid1,'',FORM_ID,'','','',''  FROM ROLE_PERMISSION WHERE ROLEID=role;
COMMIT;
end if;*/

END    loginModify_p ;
END    Loginmodify ;
/


/***********ankit*************************************creat user*******************7143***********************/





============================7217======Avinash======19apr2012==================================================

CREATE OR REPLACE PROCEDURE Reportnew(
agname      IN VARCHAR2:=NULL,
clientname  IN VARCHAR2:=NULL,
adtype1     IN VARCHAR2,
Adcategory  IN VARCHAR2,
fromdate    IN VARCHAR2,
dateto      IN VARCHAR2,
compcode    IN VARCHAR2,
pub_name    IN VARCHAR2,
pub_cent    IN VARCHAR2,
status      IN VARCHAR2:=NULL,
edition     IN VARCHAR2,
dateformat  IN VARCHAR2,
hold        IN VARCHAR2:=NULL,
descid      IN VARCHAR2:=NULL,
ascdesc     IN VARCHAR2:=NULL,
agtype      in varchar2:=null,
puserid     in varchar2:=null,
chk_access  in varchar2:=null,
pextra1     in varchar2:=null,--for UOM
pextra2     in varchar2:=null,
pextra3     in varchar2:=null,
pextra4     in varchar2:=null,
pextra5     in varchar2:=null,
p_reportnew OUT Cur_Type_New1.cursor_type)
IS

center      VARCHAR(50);
from_date   DATE;
date_to     DATE;
v_query     VARCHAR(8000);
a           number;

BEGIN

v_query:='SELECT TBL_BOOKING_MAST."cio_booking_id" AS "CIOID",TBL_BOOKING_INSERT."Edition" as "edition",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR(tbl_booking_insert."Insert_Date" ,''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(tbl_booking_insert."Insert_Date",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(tbl_booking_insert."Insert_Date",''yyyy/mm/dd'')  END AS "Ins.date" ,
AGENCY_MAST."Agency_Name" AS "Agency",
(SELECT  AGENCY_MAST."SUB_Agency_Code" FROM AGENCY_MAST WHERE AGENCY_MAST."Type" <> ''P'' AND TBL_BOOKING_MAST."Agency_code"=AGENCY_MAST."Agency_Code" AND TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode") AS "SubAg",
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
    v_query:=v_query||' and TBL_BOOKING_MAST."Agency_code" ='''||agname||'''';
END IF;

IF(clientname IS NOT NULL)
THEN
    v_query:=v_query||' and TBL_BOOKING_MAST."Client_code"='''||clientname ||'''';
END IF;

IF(status IS NOT NULL)
THEN
    v_query:=v_query||' and TBL_BOOKING_INSERT."Insert_Status"='''||status||'''';
/*
else
query:=query||' and lower("Insert_Status") !=''cancel'' ';*/
END IF;

IF(adtype1 IS NOT NULL)
THEN
    v_query:=v_query||' and TBL_BOOKING_MAST."Ad_type_code"='''||adtype1||'''';
END IF;

IF(Adcategory IS NOT NULL)
THEN
    a:=Fn_Splitfield(Adcategory,',');
    v_query:=v_query||' and tbl_booking_insert."Ad_Cat" in(select "EDITION_NAME" from result)';

    --v_query:=v_query||' and TBL_BOOKING_MAST."Ad_cat_code" in('''||Adcategory||''' )';
END IF;

IF(pub_cent IS NOT NULL)
THEN
    v_query:=v_query||'  and tbl_booking_insert."Pub_Cent_Code"='''||pub_cent||'''';
END IF;

IF(fromdate IS NOT NULL AND dateto IS NULL )
THEN
    v_query:=v_query||' and tbl_booking_insert."Insert_Date" ='''||fromdate||'''';
END IF;

IF(fromdate IS NOT NULL AND dateto IS NOT NULL )
THEN
    v_query:=v_query||' and tbl_booking_insert."Insert_Date" between  '''||fromdate ||''' and  '''||dateto||''' ';
END IF;

IF(edition IS NOT NULL)
THEN
    v_query:=v_query||'  and tbl_booking_insert."Edition_Code"='''||edition||'''';
END IF;

IF(pub_name IS NOT NULL)
THEN
    v_query:=v_query||' and  TBL_BOOKING_INSERT."Publication_Code"='''||pub_name||'''';
END IF;

IF(pextra1 IS NOT NULL) THEN
    v_query:=v_query||'  and TBL_BOOKING_MAST."Uom_code"='''||pextra1||'''';
END IF;

IF((agtype IS NOT NULL) AND (agtype <> 'Package') AND (agtype <> 'Solo'))
THEN
    v_query:=v_query||' and  TBL_BOOKING_mast."Agency_type"='''||upper(agtype)||'''';
END IF;

IF(descid IS NOT  NULL)
THEN
    v_query:=v_query||'  order by "'||descid||'"';
    v_query:=v_query||''||ascdesc||'';
ELSE
    v_query:=v_query||'  order by "Insert_Date",TBL_BOOKING_MAST."cio_booking_id"';
END IF;

delete from searchtbl;insert into searchtbl values('All Ads of the Day'||v_query);commit;

OPEN p_reportnew FOR v_query;

END Reportnew;
/


**************************************************************************


CREATE OR REPLACE PROCEDURE Deviationreportnew(
    page        IN VARCHAR2:=NULL,
    position    IN VARCHAR2:=NULL,
    agname      IN VARCHAR2:=NULL,
    clientname  IN VARCHAR2:=NULL,
    adtype1     IN VARCHAR2,
    Adcategory  IN VARCHAR2,
    fromdate    IN VARCHAR2,
    dateto      IN VARCHAR2,
    compcode    IN VARCHAR2,
    pub_name    IN VARCHAR2,
    pub_cent    IN VARCHAR2,
    status      IN VARCHAR2:=NULL,
    edition     IN VARCHAR2,
    dateformat  IN VARCHAR2,
    hold        IN VARCHAR2:=NULL,
    descid      IN VARCHAR2:=NULL,
    ascdesc     IN VARCHAR2:=NULL,
    agtype      in varchar2:=null,
    puserid     in varchar2:=null,
    chk_access  in varchar2:=null,
    puomcode    in varchar2:=null,
    pextra1     in varchar2:=null,
    pextra2     in varchar2:=null,
    pextra3     in varchar2:=null,
    pextra4     in varchar2:=null,
    pextra5     in varchar2:=null,
    p_recordset1 OUT Cur_Type_New1.cursor_type)

IS
query1  VARCHAR2(10000);
can     VARCHAR(8);
a       number;
BEGIN
can:='Cancel';

query1:='SELECT distinct m."cio_booking_id" AS "CIOID",/*i."Edition"*/ 
null as "edition",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR(min(i."Insert_Date"),''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(min(i."Insert_Date"),''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(min(i."Insert_Date"),''yyyy/mm/dd'')  END AS "Ins.date" ,
min(i."Insert_Date") as "Insert_Date",
a."Agency_Name" AS "Agency",(select "City_Name" from city_mst where city_mst."City_Code"=a."City_Code") as "AGENCY_CITY",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
fetch_insert_package('''||compcode||''',m."cio_booking_id",null,''N'') as "Package",
--m."Total_area" AS "Area",
max(round(i."Size_Book",2)) AS "Area",
max(i."Col_Code") AS "Hue",
CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR(m."date_time",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(m."date_time",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(m."date_time",''yyyy/mm/dd'')  END AS "BookDate",
m."RO_No" AS "RoNo",
CASE m."ro_status"
WHEN ''2'' THEN ''Reservation''
WHEN ''1'' THEN ''Confirm''END AS "RoStatus",
(SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=m."Ad_cat_code" ) AS "AdCat",
m."Rate_code" AS "RateCode",
m."Card_rate" AS "CardRate",
m."Agrred_rate" AS "AgreedRate",
Fn_Deviatio(m."Card_rate",m."Agrred_rate") AS "Deviation(%)",
m.APP_STATUS AS "Status",
m."booked_by",m."audit" "audit",u.UOM_DESC as "uom",
(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
sysdate as "Rundate"
from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,uom_mast u
 where m."Comp_code"='''||Compcode||''' AND
 m."cio_booking_id"=i."Cio_Booking_Id"  AND
 m."Agency_code"=a."Agency_Code" AND
 m."Agency_sub_code"=a."code_subcode" and m."Uom_code"=u."Uom_Code"
and (m."Card_rate" != m."Agrred_rate" and m."Agrred_rate" <>0)
and (nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0))>0
AND not exists (select ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
and  lower(i."Insert_Status") !=''cancel''
and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') )';

if(agname is not null)
then
    query1:=query1 ||' and m."Agency_code" ='''||agname ||'''';
end if;


if(pub_cent is not null)
then
    query1:=query1||'  and i."Pub_Cent_Code"='''||pub_cent||'''';
end if;

if(clientname is not null)
then
    query1:=query1||'  and m."Client_code"='''||clientname||'''';
end if;

if(adtype1  is not null)
then
    query1:=query1||'  and m."Ad_type_code"='''||adtype1||'''';
end if;

if(adcategory  is not null)
then
a:=fn_splitfield(adcategory,',');
--query1:=query1||' and m."ad_cat_code" in('''||adcategory||''' )';
    query1:=query1||' and i."Ad_Cat" in(select "EDITION_NAME" from result )';
end if;


if(pub_name  is not null)
then
    query1:=query1||'  and i."Publication_Code"='''||pub_name||'''';
end if;


if(status  is not null)
then
    query1:=query1||'  and i."Insert_Status"='''||status||'''';
end if;
/*
if(hold  is not null)
then
query1:=query1||'  and tbl_booking_insert."insert_status"!='''||can||'''';
end if;*/


if(fromdate is not null and dateto is not null )
then
    query1:=query1||' and i."Insert_Date" between  '''||fromdate ||''' and  '''||dateto||''' ';
end if;

if(edition is not null)
then
    query1:=query1||'  and i."Edition_Code"='''||edition||'''';
end if;


if(page  is not null)
then
    query1:=query1||'  and i."Premium1"='''||page||'''';
end if;

if(position is not null)
then
    query1:=query1||'  and i."Page_Post"='''||position||'''';
end if;

if((agtype is not null) and (agtype <> 'Package') and (agtype <> 'Solo'))
then
    query1:=query1||' and  m."Agency_type"='''||upper(agtype)||'''';
end if;

if(puomcode is not null)
then
    query1:=query1||'  and m."Uom_code" ='''||puomcode||'''';
end if;

query1:=query1||' group by m."cio_booking_id",a."Agency_Name",a."City_Code",
m."Client_code",m."date_time",m."RO_No",m."ro_status",m."Ad_cat_code",m."Rate_code",m."Card_rate",m."Agrred_rate",m.APP_STATUS,m."booked_by",m."audit",u.UOM_DESC ';

if(descid is not  null)
then
query1:=query1||'  order by "'||descid||'"';
query1:=query1||''||ascdesc||'';
else
query1:=query1||'  order by "Insert_Date",m."cio_booking_id"';

end if;

delete from searchtbl;insert into searchtbl values(query1); commit;

open p_recordset1 for query1;

end deviationreportnew;
/


****************************************************************************


CREATE OR REPLACE function HT18JULY.fetch_insert_package(
    pcompcode       varchar2,
    pcioid          varchar2,
    pinsertion_no   int,
    ppkg_type       varchar2) return varchar2

as
v_val   varchar2(2000);

v_pack  varchar2(200);

Cursor C1 Is 
    select distinct package_code pack from tbl_booking_insert 
        where "Comp_Code"=pcompcode and "Cio_Booking_Id"=pcioid and "No_Insert" =pinsertion_no  and "Insert_Status"!='cancel';

v1 C1%rowtype;
BEGIN
open C1;
loop
    fetch C1 into v1;
    exit when C1%notfound;
    
    if nvl(ppkg_type,'N')='N' then--for Package name
        --v_pack:=v1.pack;
        select "Package_Name" into v_pack from combin_mast where "Combin_Code"=v1.pack;
        
    else--for Package code
        v_pack:=v1.pack;
    end if;
    
    begin
          if (v_val is null) then
            v_val:=v_pack;
          else
            v_val:=v_val ||','|| v_pack;
          end if;
     end;
     
end loop;
    
close C1;

return v_val;

END fetch_insert_package;
/


====================end===================7217===========avinash=====19Apr2012=====================

/**********************************mimoh 20april2012**********************************************7274*/

CREATE OR REPLACE procedure discchk(
compcode in varchar2,
disccode in varchar2,
discdes in varchar2,
padtype in varchar2,
p_accounts   OUT   cur_type_new1.cursor_type,
p_accounts1  OUT   cur_type_new1.cursor_type
)
as
begin
open p_accounts for
select DISC_CODE, DISC_DESC, AD_TYPE, DISC_TYPE from DISC_MASTER where COMP_CODE=compcode and DISC_CODE=disccode;

open p_accounts1 for
select DISC_CODE, DISC_DESC, AD_TYPE, DISC_TYPE from DISC_MASTER where COMP_CODE=compcode and DISC_DESC=discdes and AD_TYPE=padtype;

end;
/


/**********************************mimoh 20april2012**********************************************7274*/




@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@bhanu 26/04/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

CREATE OR REPLACE PROCEDURE getdata_export (
   adtype_p     IN       VARCHAR2,
   fromdate_p   IN       VARCHAR2,
   todate_p     IN       VARCHAR2,
   p_solo       IN       VARCHAR2,
   p_ratecode   IN       VARCHAR2,
   p_pubcent    IN       VARCHAR2,
   pedtn_flag   IN       VARCHAR2,--M for Main,E for Edition ,S for Suppliment and A for All
   p_accounts   OUT      cur_type_new1.cursor_type)
IS
BEGIN
   IF NVL (p_solo, '') = 'S'
   THEN
      OPEN p_accounts FOR
            select x."rateuniqueid",x."pub_center", x."Adv_Cat_Code", x."Adv_subcat_code",x."Ad_Subcat4", x."Ad_Subcat5",x."Ad_subcat6",x."Premium", x."Scheme_Name",
            x."Comp_code",x."Rate_Mast_Code", x."Adv_Type_Code", x."Rate_Gr_Code", x."Currency",x."combin_desc", x."Combin_Code",x."Uom",x."Size_To",x."Size_From",
            x."consumption_Per", x."Color",x."Col_chr_typ", x."Remarks",x.Valid_From AS valid_from,x.Valid_To AS valid_to, 
            x."Package_Name" as "Package_Name",
            x."Adv_Cat_Name" as "Adv_Cat_Name",
            x."Adv_Subcat_Name" as "Adv_Subcat_Name",
            x."Uom_Name" as "Uom_Name",
            x."Week_Day_Rate", x."Week_min_rate",x."Week_Extra_Rate", x."Focus_Day_Rate",x."Focus_min_rate", x."Focus_extra_rate",
            x."userid", x."Creation_DateTime", x."Premium_Charges",x."weekend_rate", x."weekend_min_rate",x."weekend_extra", x."chksolo",x."min_ad_area", x."Edition_from",
            x."Edition_to", x."floor_amount",x."floor_discount", x."From_insertion",x."To_insertion", x."Agency_type",
            x."Client_cat", x."Max_Area", x.sun_rate,x.mon_rate, x.tue_rate, x.wed_rate,x.thu_rate, x.fri_rate, x.sat_rate,x.sun_rate_extra, x.mon_rate_extra,
            x.tue_rate_extra, x.wed_rate_extra,x.thu_rate_extra, x.fri_rate_extra,x.sat_rate_extra, x.maxwidth,x.priority, x.vat_detail, x.adon,x.ref_id, x.cancellation_charges,
            x."ratemastid" "ratemastid", x."id" "id",x."rate_code" AS "rate_code" from
            (select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
            r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
            r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'mm/dd/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'mm/dd/yyyy') AS valid_to, 
            (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
            (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
            (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
            (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
            r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
            r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
            r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
            r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
            r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,
            '' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
            --,'' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
            FROM rate_mast r
            WHERE "Adv_Type_Code" = adtype_p  AND "Valid_From" >= fromdate_p AND "Valid_To" <= todate_p AND INSTR ("combin_desc", '+') <= 0 
            and r."Rate_Mast_Code"=nvl(p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=p_pubcent or p_pubcent is null) and 
            exists(select 'x' from edition_mast where edition_mast."Edition_Alias"=r."combin_desc" and 
            (("Edition_Type"='Main Edition' and pedtn_flag='M') or ("Edition_Type"='Edition' and pedtn_flag='E')))
            union
            select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
            r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
            r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'mm/dd/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'mm/dd/yyyy') AS valid_to, 
            (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
            (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
            (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
            (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
            r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
            r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
            r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
            r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
            r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,
            '' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
            --,'' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
            FROM rate_mast r
            WHERE "Adv_Type_Code" = adtype_p  AND "Valid_From" >= fromdate_p AND "Valid_To" <= todate_p AND INSTR ("combin_desc", '+') <= 0
            and r."Rate_Mast_Code"=nvl(p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=p_pubcent or p_pubcent is null) and 
            exists(select 'x' from supplement_mast where supplement_mast."Supp_Alias"=r."combin_desc" and pedtn_flag='S')
            union
            select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
            r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
            r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'mm/dd/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'mm/dd/yyyy') AS valid_to, 
            (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
            (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
            (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
            (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
            r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
            r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
            r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
            r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
            r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,
            '' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
            --,'' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
            FROM rate_mast r
            WHERE r."Adv_Type_Code" = adtype_p  AND r."Valid_From" >= fromdate_p AND r."Valid_To" <= todate_p AND INSTR (r."combin_desc", '+') <= 0
            and r."Rate_Mast_Code"=nvl(p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=p_pubcent or p_pubcent is null) and pedtn_flag='A') x
         ORDER BY x."rateuniqueid";
   END IF;

   IF NVL (p_solo, '') = 'P'
   THEN
      OPEN p_accounts FOR
        select r."rateuniqueid",r."pub_center", r."Adv_Cat_Code", r."Adv_subcat_code",r."Ad_Subcat4", r."Ad_Subcat5",r."Ad_subcat6",r."Premium", r."Scheme_Name",
            r."Comp_code",r."Rate_Mast_Code", r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",r."combin_desc", r."Combin_Code",r."Uom",r."Size_To", r."Size_From",
            r."consumption_Per", r."Color",r."Col_chr_typ", r."Remarks",TO_CHAR (r."Valid_From",'mm/dd/yyyy') AS valid_from,TO_CHAR (r."Valid_To", 'mm/dd/yyyy') AS valid_to, 
            (select "Package_Name" from combin_mast where combin_mast."Combin_Code"=r."Combin_Code" and combin_mast."Comp_Code"=r."Comp_code") as "Package_Name",
            (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code" =r."Adv_Cat_Code" and adv_cat_mast."Comp_Code" =r."Comp_code") as "Adv_Cat_Name",
            (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" and adv_subcat_mast."Comp_Code" =r."Comp_code") as "Adv_Subcat_Name",
            (select "Uom_Name" from uom_mast where uom_mast."Uom_Code" =r."Uom" and uom_mast."Comp_Code" =r."Comp_code") as "Uom_Name",
            r."Week_Day_Rate", r."Week_min_rate",r."Week_Extra_Rate", r."Focus_Day_Rate",r."Focus_min_rate", r."Focus_extra_rate",
            r."userid", r."Creation_DateTime", r."Premium_Charges",r."weekend_rate", r."weekend_min_rate",r."weekend_extra", r."chksolo",r."min_ad_area", r."Edition_from",
            r."Edition_to", r."floor_amount",r."floor_discount", r."From_insertion",r."To_insertion", r."Agency_type",
            r."Client_cat", r."Max_Area", r.sun_rate,r.mon_rate, r.tue_rate, r.wed_rate,r.thu_rate, r.fri_rate, r.sat_rate,r.sun_rate_extra, r.mon_rate_extra,
            r.tue_rate_extra, r.wed_rate_extra,r.thu_rate_extra, r.fri_rate_extra,r.sat_rate_extra, r.maxwidth,r.priority, r.vat_detail, r.adon,r.ref_id, r.cancellation_charges,
            '' "ratemastid", '' "id","Rate_Mast_Code" AS "rate_code"
            --, '' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
            FROM rate_mast r
            WHERE "Adv_Type_Code" = adtype_p
              AND "Valid_From" >= fromdate_p
              AND "Valid_To" <= todate_p
              AND INSTR ("combin_desc", '+') > 0
              and r."Rate_Mast_Code"=nvl(p_ratecode,r."Rate_Mast_Code") and (r."pub_center"=p_pubcent or p_pubcent is null)
         ORDER BY r."rateuniqueid";
   END IF;
/*open p_Accounts for

SELECT RATE_MAST."rateuniqueid", RATE_MAST."Comp_code", RATE_MAST."Rate_Mast_Code", RATE_MAST."Adv_Type_Code", RATE_MAST."Adv_Cat_Code", RATE_MAST."Adv_subcat_code", RATE_MAST."Rate_Gr_Code", RATE_MAST."Currency", RATE_MAST."combin_desc", RATE_MAST."Combin_Code", RATE_MAST."Uom", to_char(RATE_MAST."Valid_From",'mm/dd/yyyy') as Valid_From, to_char(RATE_MAST."Valid_To",'mm/dd/yyyy') as Valid_To, RATE_MAST."Size_To", RATE_MAST."Size_From", RATE_MAST."consumption_Per", RATE_MAST."Color", RATE_MAST."Col_chr_typ", RATE_MAST."Remarks", RATE_MAST."Week_Day_Rate", RATE_MAST."Week_min_rate", RATE_MAST."Week_Extra_Rate", RATE_MAST."Focus_Day_Rate", RATE_MAST."Focus_min_rate", RATE_MAST."Focus_extra_rate", RATE_MAST."userid", RATE_MAST."Creation_DateTime", RATE_MAST."Premium", RATE_MAST."Premium_Charges", RATE_MAST."weekend_rate", RATE_MAST."weekend_min_rate", RATE_MAST."weekend_extra", RATE_MAST."chksolo", RATE_MAST."min_ad_area", RATE_MAST."Edition_from", RATE_MAST."Edition_to", RATE_MAST."floor_amount", RATE_MAST."floor_discount", RATE_MAST."Scheme_Name", RATE_MAST."Ad_Subcat4", RATE_MAST."Ad_Subcat5", RATE_MAST."Ad_subcat6", RATE_MAST."From_insertion", RATE_MAST."To_insertion", RATE_MAST."Agency_type", RATE_MAST."Client_cat", RATE_MAST."Max_Area", RATE_MAST."pub_center", RATE_MAST.SUN_RATE, RATE_MAST.MON_RATE, RATE_MAST.TUE_RATE, RATE_MAST.WED_RATE, RATE_MAST.THU_RATE, RATE_MAST.FRI_RATE, RATE_MAST.SAT_RATE, RATE_MAST.SUN_RATE_EXTRA, RATE_MAST.MON_RATE_EXTRA, RATE_MAST.TUE_RATE_EXTRA, RATE_MAST.WED_RATE_EXTRA, RATE_MAST.THU_RATE_EXTRA, RATE_MAST.FRI_RATE_EXTRA, RATE_MAST.SAT_RATE_EXTRA, RATE_MAST.MAXWIDTH, RATE_MAST.PRIORITY,RATE_MAST.VAT_DETAIL,RATE_MAST.ADON,RATE_MAST.REF_ID,RATE_MAST.CANCELLATION_CHARGES
,RATE_DETAILS."ratemastid", RATE_DETAILS."id", RATE_DETAILS."rate_code", RATE_DETAILS."edition_name", RATE_DETAILS."Week_Day_Rate", RATE_DETAILS."Week_min_rate", RATE_DETAILS."Week_Extra_Rate", RATE_DETAILS."Focus_Day_Rate", RATE_DETAILS."Focus_min_rate", RATE_DETAILS."Focus_extra_rate", RATE_DETAILS."userid", RATE_DETAILS."Creation_DateTime", RATE_DETAILS."Comp_Code", RATE_DETAILS."Solus_week_rate", RATE_DETAILS."Solus_focus_rate", RATE_DETAILS."weekend_rate", RATE_DETAILS."weekend_min", RATE_DETAILS."weekend_extra", RATE_DETAILS."Solo_weekendrate", RATE_DETAILS.SUN_RATE, RATE_DETAILS.MON_RATE, RATE_DETAILS.TUE_RATE, RATE_DETAILS.WED_RATE, RATE_DETAILS.THU_RATE, RATE_DETAILS.FRI_RATE, RATE_DETAILS.SAT_RATE, RATE_DETAILS.SUN_RATE_EXTRA, RATE_DETAILS.MON_RATE_EXTRA, RATE_DETAILS.TUE_RATE_EXTRA, RATE_DETAILS.WED_RATE_EXTRA, RATE_DETAILS.THU_RATE_EXTRA, RATE_DETAILS.FRI_RATE_EXTRA, RATE_DETAILS.SAT_RATE_EXTRA, RATE_DETAILS.PKGNAME
 FROM RATE_MAST FULL JOIN RATE_DETAILS ON
 RATE_MAST."rateuniqueid"=RATE_DETAILS."ratemastid"
 WHERE "Adv_Type_Code"=adtype_p
 and "Valid_From">=fromdate_p AND "Valid_To"<=todate_p
   ORDER BY RATE_MAST."rateuniqueid";*/
END;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

===========start==========avinash===7343=====26apr2012====================================


CREATE OR REPLACE PACKAGE HT18JULY.execcontactinsert is
Type T_Accounts_Cursor is Ref Cursor;
procedure execcontactinsert_p(
exename in varchar2,
teamcode in varchar2,
designation in varchar2,
address in varchar2,
street in varchar2,
city in varchar2,
district in varchar2,
state in varchar2,
country in varchar2,
pin in varchar2,
phone in varchar2,
status in varchar2,
compcode in varchar2,
userid in varchar2,
report in varchar2,
taluka1 in varchar2,
repname in varchar2,
adtype1 in varchar2,
branchcode in varchar2,
craditlimit in varchar2,
mobile in varchar2,
email in varchar2,
mailto in varchar2,
p_empcode in varchar2,
P_Accounts out T_Accounts_Cursor
);
end execcontactinsert;
/

CREATE OR REPLACE PACKAGE BODY HT18JULY.execcontactinsert is
procedure execcontactinsert_p(
exename in varchar2,
teamcode in varchar2,
designation in varchar2,
address in varchar2,
street in varchar2,
city in varchar2,
district in varchar2,
state in varchar2,
country in varchar2,
pin in varchar2,
phone in varchar2,
status in varchar2,
compcode in varchar2,
userid in varchar2,
report in varchar2,
taluka1 in varchar2,
repname in varchar2,
adtype1 in varchar2,
branchcode in varchar2,
craditlimit in varchar2,
mobile in varchar2,
email in varchar2,
mailto in varchar2,
p_empcode in varchar2,
P_Accounts out T_Accounts_Cursor
)as
exeno int;
begin
select Exe_no_ident1.nextval into exeno from dual;
insert into Exec_mast("Exe_no","Team_code","Exec_name","Designation","Add1","Street","Country_code","State_code","dist_code","city_code","phone","exe_status","userid","comp_code","pin_code","report_to","TALUKA","creation_datetime",REPRESENTATIVE,ADTYPE,"Branch_code",CREDIT_LIMIT,MOBILENO,EMAILID,HR_CODE,EMAIL_ID )
values(exeno,teamcode,exename,designation,address,street,country,state,district,city,phone,status,userid,compcode,pin,report,taluka1,sysdate,repname,adtype1,branchcode,craditlimit,mobile,email,p_empcode,mailto);



update Exec_mast set "CIty_Name"=(select "City_Name" from city_mst where "City_Code"=city) where "city_code"=city;
commit;
open P_Accounts for
select exeno as "exeno" from dual;
end execcontactinsert_p;
end execcontactinsert;
/



*******************************************************

CREATE OR REPLACE PACKAGE HT18JULY.execselectbind is

Type T_Accounts_Cursor Is Ref Cursor;
procedure execselectbind_p(
code in varchar2,
compcode in varchar2,
userid in varchar2,P_Accounts Out T_Accounts_Cursor,
P_Accounts1 Out T_Accounts_Cursor,
P_Accounts2 Out T_Accounts_Cursor
);
end execselectbind;
/


CREATE OR REPLACE PACKAGE BODY HT18JULY.execselectbind is
procedure execselectbind_p(
code in varchar2,
compcode in varchar2,
userid in varchar2,P_Accounts Out T_Accounts_Cursor,
P_Accounts1 Out T_Accounts_Cursor,
P_Accounts2 Out T_Accounts_Cursor
)as

dist_code1 varchar2(100);

begin
Open P_Accounts For
select "Exec_name","Designation","Add1","Street","city_code","dist_code","State_code","Country_code","pin_code","phone","exe_status","Exe_no","report_to","TALUKA",REPRESENTATIVE AS "repname",ADTYPE as "adtype","Branch_code",CREDIT_LIMIT,MOBILENO,EMAILID,ad_get_fieldname('COMP_CD',compcode,'EMP_CODE',Exec_mast.HR_CODE,'NAME','HR_EMP_MST','','') AS HR_CODE,EMAIL_ID from Exec_mast where "comp_code"=compcode  and "Exe_no" =code;
Open P_Accounts1 For
-- select talu_code,talu_name from taluka_mast WHERE DIST_CODE=(select "Dist_Code" from dist_mst where "Dist_Name" =(SELECT "dist_code" FROM Exec_mast where "comp_code"=compcode  and "Exe_no" =code)); 
select talu_code,talu_name from taluka_mast,Exec_mast WHERE DIST_CODE=(select "Dist_Code" from dist_mst where "Dist_Name" =(SELECT "dist_code" FROM Exec_mast where "comp_code"=compcode  and "Exe_no" =code)  ) and Exec_mast."comp_code"=compcode  and Exec_mast."Exe_no" =code;

open P_Accounts2 for
select catcode as "adcat" from exec_adcat where compcode=compcode  and execcode =code;

end  execselectbind_p;
end execselectbind;
/


*****************************************************

CREATE OR REPLACE PACKAGE HT18JULY.execcontactupdate is
procedure execcontactupdate_p(
exename varchar2,
teamcode  varchar2,
designation  varchar2,
address  varchar2,
street  varchar2,
city  varchar2,
district  varchar2,
state  varchar2,
country  varchar2,
pin  varchar2,
phone  varchar2,
status  varchar2,
compcode  varchar2,
userid  varchar2,
code  varchar2,
report  varchar2,
TALUKA1  varchar2,
repname in varchar2,
adtype1 in varchar2,
branchcode in varchar2,
craditlimit varchar2,
mobile in varchar2,
email in varchar2,
mailto in varchar2,
p_empcode in varchar2
);
end  execcontactupdate;
/


CREATE OR REPLACE PACKAGE BODY HT18JULY.execcontactupdate is
procedure execcontactupdate_p(
exename varchar2,
teamcode  varchar2,
designation  varchar2,
address  varchar2,
street  varchar2,
city  varchar2,
district  varchar2,
state  varchar2,
country  varchar2,
pin  varchar2,
phone  varchar2,
status  varchar2,
compcode  varchar2,
userid  varchar2,
code  varchar2,
report  varchar2,
TALUKA1  varchar2,
repname in varchar2,
adtype1 in varchar2,
branchcode in varchar2,
craditlimit in varchar2,
mobile in varchar2,
email in varchar2,
mailto in varchar2,
p_empcode in varchar2
)as

cityname varchar2(10);
countryname varchar2(10);

begin

update  Exec_mast set  "Exec_name"=exename,"Designation"=designation,"Add1"=address,"Street"=street,"Country_code"=country,"State_code"=state,"dist_code"=district,"city_code"=city,"phone"=phone,"exe_status"=status,"pin_code"=pin, "report_to"=report ,"TALUKA" = TALUKA1, REPRESENTATIVE=repname,ADTYPE=adtype1,"Branch_code"=branchcode,CREDIT_LIMIT=craditlimit,MOBILENO=mobile,EMAILID=email,HR_CODE =p_empcode,EMAIL_ID=mailto where "comp_code"=compcode and "Exe_no"=code;


update Exec_mast set "CIty_Name"=(select "City_Code" from city_mst where "City_Code"=city) where "city_code"=city;

--update Exec_mast set "CIty_Name"=(select "CIty_Name" from city_mst where "city_code"=city) where "city_code"=city;
--update EXEC_ADCAT set catcode=adcategory;
commit;

end execcontactupdate_p;

end  execcontactupdate;
/

======================end=============7343===avinash==26apr2012==============




==========start===============7342====avinash========================
CREATE OR REPLACE PACKAGE HT18JULY.Websp_Executeagency
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


CREATE OR REPLACE PACKAGE BODY HT18JULY.Websp_Executeagency
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
                RATE_REVISE,EDTN_WISE_BILL_REQ 
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












/*

DECLARE

 CURSOR c1 IS SELECT  SUB_AGENCY_CODE FROM FIRST1 ORDER BY sub_agency_code;
 AuthorID VARCHAR(100);
 BEGIN



OPEN c1;
LOOP
FETCH c1 INTO AuthorID;

EXIT WHEN c1%NOTFOUND;













UPDATE FIRST1 SET STATUS_NAME= (SELECT   "STATUS_NAME"    FROM STATUS_DETAIL WHERE AGENCY_SUBCAT_CODE=AuthorID AND ROWNUM<=1)
 WHERE SUB_AGENCY_CODE=AuthorID;

UPDATE FIRST1 SET TO_DATE= (SELECT "TO_DATE"    FROM STATUS_DETAIL WHERE AGENCY_SUBCAT_CODE=AuthorID AND ROWNUM<=1  )
 WHERE SUB_AGENCY_CODE=AuthorID;
END LOOP;

CLOSE c1;
END;







OPEN p_accounts FOR
SELECT  COMP_CODE AS "Comp_Code", AGENCY_TYPE_CODE AS "Agency_Type_Code", AGENCY_CAT_CODE AS "Agency_Cat_Code" , AGENCY_SUBCAT_CODE AS "Agency_SubCat_Code" , AGENCY_CODE AS "Agency_Code", AGENCY_NAME AS "Agency_Name" , AGENCY_ALIAS AS "Agency_Alias" , AGENCY_HO AS "Agency_HO", ADD1 AS "Add1", STREET AS "Street" , CITY_CODE AS "City_Code", ZIP AS "Zip", DIST_CODE AS "Dist_Code", STATE_CODE AS "State_Code", COUNTRY_CODE AS "Country_Code", PHONE AS "Phone" , FAX AS "Fax", EMAILID AS "EmailID", URL, BUSS_START_DATE AS "Buss_Start_Date", ENROLL_DATE AS "Enroll_Date", MRV_REF_NO AS "MRV_Ref_No", NO_OF_VTS AS "No_of_VTS", CREDIT_DAYS AS "Credit_Days", PAN_NO, TAN_NO, ST_ACC_NO, PAY_MODE_CODE AS "Pay_Mode_Code" , STATUS_NAME, STATUS_REASON AS "Status_Reason" , REMARKS AS "Remarks", USERID AS "UserID", CURRENT_DATETIME AS "current_Datetime", USERS AS "users", SUB_AGENCY_HO AS "SUB_Agency_HO", SUB_AGENCY_CODE AS "SUB_Agency_Code", BILL_TO, ALERT, CREDIT_LIMIT, CODE, REPRESENTATIVE_CODE AS "Representative_code", PIN_CODE AS"pin_code"  , Region AS "region", TO_DATE, "TYPE" AS "Type", CODE_SUBCODE AS "code_subcode", ZONE_CODE AS "zone_code", ADD2 AS "Add2", ADD3 AS "Add2", CREDIT_TYPE, ACAGENCY AS "acagency", FAX1 AS "fax1" , RATE_GROUP AS "Rate_Group", QBC_USERID AS "qbc_userid"
  FROM FIRST1      WHERE COMP_CODE = compcode OR compcode IS NULL
                AND AGENCY_CODE LIKE agentcode || '%' OR agentcode IS NULL
                AND SUB_AGENCY_CODE LIKE subagencycode || '%'  OR subagencycode IS NULL
                AND AGENCY_NAME LIKE agencyname1 || '%' OR agencyname1  IS NULL
                AND AGENCY_ALIAS LIKE alias || '%'  OR alias IS NULL
                AND AGENCY_TYPE_CODE LIKE agenttype || '%'  OR agenttype IS NULL
                AND AGENCY_CAT_CODE LIKE agentcategory  || '%' OR agentcategory IS NULL;

*/

       END websp_executeagency_p;
END Websp_Executeagency;
/


======================7342=========end===================================================

******************************* issue 7369 *************************************
CREATE OR REPLACE PROCEDURE HT18JULY.pub_Reportnew
(
agname IN VARCHAR2:= NULL,
Adtype IN VARCHAR2:= NULL,
fromdate IN VARCHAR2:= NULL,
dateto IN VARCHAR2:= NULL,
compcode IN VARCHAR2:= NULL,
pub_cent IN VARCHAR2:= NULL,
category IN VARCHAR2:= NULL,
edition IN VARCHAR2:= NULL,
dateformat IN VARCHAR2:= NULL,
Region IN VARCHAR2:= NULL,
product IN VARCHAR2:= NULL,
agency IN VARCHAR2:= NULL,
descid IN VARCHAR2:= NULL,
ascdesc IN VARCHAR2:= NULL,
agcat in varchar2:=null,
adcheck in varchar2:=null,
executive in varchar2:=null,
 puserid            IN VARCHAR2,
chk_access in varchar2:=null,
p_recordset1 OUT Cur_Type_New1.cursor_type
)

IS
query1 VARCHAR2(10000);
grpnew VARCHAR2(100);
grpne VARCHAR2(100);
grpst VARCHAR2(100);

 prefer     VARCHAR(10);
  v_frdt     date;     
    v_todt        date;
BEGIN
 v_frdt          :=to_date(fromdate,''''||dateformat||'''');
    v_todt          :=to_date(dateto,''''||dateformat||'''');
select distinct  AGENCY_RETAINER_COMM into prefer from preferrences where "comp_code"=compcode;

if(adcheck=1)
then
query1:='SELECT distinct TBL_BOOKING_MAST."cio_booking_id" AS "CIOID",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "Client",
PUB_MAST."Pub_Name" AS "Publication",
round(TBL_BOOKING_MAST."Total_area",2) AS "Area",

--round(tbl_booking_insert."Size_Book",2 )  AS "Area",
(SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE tbl_booking_mast."Revenue_center" =BRANCH_MST."Branch_Code" )AS "RevenueCenter",
tbl_booking_mast."Rate_code" as "Rate",
TBL_BOOKING_MAST."Page_prem" as "Premium",
--tbl_booking_insert."Premium1" as "Premium",
tbl_booking_mast."Bill_remarks" as "BillRemark",
tbl_booking_mast."Color_code" as "Color",
--tbl_booking_insert."Col_Code"  as "Color",
tbl_booking_mast."Ad_cat_code"  as "Category",
tbl_booking_mast."Ad_sub_cat_code" as "SubCategory",
tbl_booking_mast."Package_code" as "Package",
nvl(tbl_booking_mast."Agrred_rate",tbl_booking_mast."Card_rate" ) AS "AgreedRate",
tbl_booking_mast."Bill_amount" AS "BillAmt",
tbl_booking_mast."Trade_disc" as "AgencyComm",
tbl_booking_mast."ADD_AGENCY_COMM" as "AddlAgencyTD",
(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
sysdate as "Rundate"
,tbl_booking_mast."Booking_type" as "booktype"
,tbl_booking_insert.BILL_NO as "Bill_No"
,to_char(tbl_booking_insert.BILL_DATE,'||''''||dateformat||''''||') as "Bill_Date"

/*,TBL_BOOKING_MAST."Agency_address" AS "A_Place"
,TBL_BOOKING_MAST."Client_address" AS "C_Place"
,UOM_MAST."Uom_Name"  AS "Uom"
,tbl_booking_mast."Page_no" as "Page_no"
,tbl_booking_mast."Card_rate" as "Card_Rate"
,tbl_booking_mast."Discount_per" as Discper
,tbl_booking_mast."Special_disc_per" as Spdiscper
,tbl_booking_mast."Space_disc_per" as Spacediscper
,tbl_booking_mast."Special_charges" as Specialcharge
,nvl((tbl_booking_mast."Bill_amount"-nvl(fun_actual('''||compcode ||''',nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0'' ),nvl(tbl_booking_mast."RETAINER",''0''),nvl(tbl_booking_mast."Gross_amount",''0''),'''||prefer||''',''2'' ),''0'')  ),''0'') as ActualBusiness
*/
,CASHDISCOUNT as "Cash_Disc"

FROM TBL_BOOKING_MAST,
TBL_BOOKING_INSERT,
AGENCY_MAST ,
PUB_MAST,uom_mast
WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||''' AND
UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code"  and
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND  
TBL_BOOKING_INSERT."Publication_Code" = PUB_MAST."Pub_Code"
AND "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
and  lower("Insert_Status") not in (''cancel'',''hold'')
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') )';


IF(agname IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST."Agency_code" ='''||agname ||'''';
END IF;

IF(Adtype IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Ad_type_code"='''||Adtype||'''';
END IF;

IF(pub_cent IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_insert."Pub_Cent_Code"='''||pub_cent||'''';
END IF;

IF(fromdate IS NOT NULL AND dateto IS NULL )
THEN
query1:=query1||' and "Insert_Date" ='''||v_frdt||'''';
END IF;

IF(fromdate IS NOT NULL AND dateto IS NOT NULL )
THEN
query1:=query1||' and "Insert_Date" between  '''||v_frdt ||''' and  '''||v_todt||''' ';
END IF;

IF(edition IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_insert."Edition_Code"='''||edition||'''';
END IF;

IF((category IS NOT NULL) AND (category <> 'Package') AND (category <> 'Solo'))
THEN
query1:=query1||' and  TBL_BOOKING_mast."Agency_type"='''||upper(category)||'''';
END IF;

IF(product IS NOT NULL)
THEN
query1:=query1||' and TBL_BOOKING_insert."Publication_Code"='''||product||'''';
END IF;

IF(Region IS NOT NULL)
THEN
query1:=query1 ||' and tbl_booking_insert."Pub_Cent_Code" in(select pub_cent_mast."Pub_cent_Code" from pub_cent_mast where pub_cent_mast."Region_code" ='''||Region ||''')';
END IF;


IF(agcat IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST."Agency_code" =agency_mast."code_subcode" and agency_mast."Agency_Cat_Code"='''||agcat ||'''';
END IF;

IF(executive IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST."Executive_code" ='''||executive ||'''';
END IF;


IF(descid IS NOT  NULL)
THEN
query1:=query1||'  ORDER BY "'||descid||'"';
query1:=query1||''||ascdesc||'';
else
query1:=query1||' order by TBL_BOOKING_MAST."cio_booking_id"';

END IF;
DELETE FROM SEARCHTBL;
--insert into searchtbl values(query1);
--commit;
insert into searchtbl values(query1);
commit;
OPEN p_recordset1 FOR
query1;
end if;

if(adcheck=2)
then
query1:='SELECT  ad_bills.IDNUM AS "CIOID",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=ad_bills_det."CLIENTCD"),ad_bills_det."CLIENTCD")  AS "Client",
PUB_MAST."Pub_Name" AS "Publication",
round(ad_bills_det."SIZE_BOOK",2) AS "Area",
(SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE ad_bills.REVENUE_CENTER =BRANCH_MST."Branch_Code" )AS "RevenueCenter",
ad_bills_det.RATECD as "Rate",
ad_bills."SPPREMIUM" as "Premium",
ad_bills."BILL_RMRK" as "BillRemark",
ad_bills."COLOUR" as "Color",
ad_bills_det.PRIADCTG  as "Category",
ad_bills_det.SECADCTG as "SubCategory",
ad_bills_det."PACKAGE_CODE" as "Package",
(select nvl(tbl_booking_mast."Agrred_rate",tbl_booking_mast."Card_rate" ) from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=ad_bills.IDNUM)AS "AgreedRate",
SUM(ROUND(ad_bills_DET.BILL_AMT)) AS "BillAmt",
nvl(ad_bills.DISCOUNT ,''0'' ) as "AgencyComm",
nvl((select tbl_booking_mast."ADD_AGENCY_COMM" from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=ad_bills.IDNUM),''0'') as "AddlAgencyTD", 
(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
sysdate as "Rundate"
,(select tbl_booking_mast."Booking_type" from tbl_booking_mast where ad_bills.IDNUM=tbl_booking_mast."cio_booking_id" ) as "booktype"
,ad_bills_det.BILNO as "Bill_No"
,to_char(ad_bills_det.BILDT,'||''''||dateformat||''''||') as "Bill_Date",
ad_bills.GROSS_AMT,ad_bills.BOXCHRG,ad_bills.AGCOMM


/*,agency_mast."Add1" AS "A_Place"
,(select cust_mast."Add1" from cust_mast where ad_bills_det."CLIENTCD"=cust_mast."Cust_Code") AS "C_Place"
,(select UOM_MAST."Uom_Name" from uom_mast where  uom_mast."Uom_Code" in(select tbl_booking_mast."Uom_code" from tbl_booking_mast where  tbl_booking_mast."cio_booking_id"=ad_bills.IDNUM ))  AS "Uom"
,ad_bills.PAGENUM as "Page_no"
,(select tbl_booking_mast."Card_rate" from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=ad_bills.IDNUM ) as "Card_Rate"
,(select tbl_booking_mast."Discount_per" from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=ad_bills.IDNUM ) as Discper
,(select tbl_booking_mast."Special_disc_per" from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=ad_bills.IDNUM ) as Spdiscper
,(select tbl_booking_mast."Space_disc_per" from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=ad_bills.IDNUM ) as Spacediscper
,(select tbl_booking_mast."Special_charges" from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=ad_bills.IDNUM ) as Specialcharge
--,(select nvl((sum(ad_bills_DET.BILL_AMT) -nvl(fun_actual('''||compcode||''',nvl(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),nvl(ad_bills.RETAINER_CODE ,''0''),nvl(sum(ad_bills_det.GROSS_AMT) ,''0''),'''||prefer||''',''2'' ),''0'')  ),''0'') from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=ad_bills.IDNUM ) as ActualBusiness
*/



FROM ad_bills,ad_bills_det,
AGENCY_MAST ,
PUB_MAST
WHERE 
AD_BILLS.BILNO=AD_BILLS_DET.BILNO AND
AD_BILLS.BILDT=AD_BILLS_DET.BILDT AND
ad_bills."IDNUM"=ad_bills_det."IDNUM" and
ad_bills."AGCODE"=AGENCY_MAST."code_subcode" AND  
ad_bills."PRIPUB" = PUB_MAST."Pub_Code" 
and ((ad_bills_det."BKFOR"  in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') )';

IF(agname IS NOT NULL)
THEN
query1:=query1 ||' AND ad_bills.AG_MAIN_CODE ='''||agname ||'''';
END IF;

----NEED TO FIND
IF(Adtype IS NOT NULL)
THEN
query1:=query1 || ' and ad_bills_det."AD_TYPE_V"='''||Adtype||'''';

END IF;
----NEED TO FIND

iF(pub_cent IS NOT NULL)
THEN
query1:=query1||'  AND AD_BILLS_DET."BKFOR"  ='''||pub_cent||'''';
END IF;

IF(fromdate IS NOT NULL AND dateto IS NULL )
THEN
query1:=query1||' and ad_bills_det.BILDT ='''||v_frdt||'''';
END IF;

IF(fromdate IS NOT NULL AND dateto IS NOT NULL )
THEN
query1:=query1||' and ad_bills_det.BILDT between  '''||v_frdt ||''' and  '''||v_todt||''' ';
END IF;

IF(edition IS NOT NULL)
THEN
query1:=query1||'  and ad_bills_det."EDITION"='''||edition||'''';
END IF;

----NEED TO FIND
IF((category IS NOT NULL) AND (category <> 'Package') AND (category <> 'Solo'))
THEN
query1:=query1||' and  ad_bills."AGCODE"= agency_mast."code_subcode" and agency_mast."Agency_Type_Code"= '''||upper(category)||'''';
END IF;
----NEED TO FIND

IF(product IS NOT NULL)
THEN
query1:=query1||' and ad_bills."PRIPUB"='''||product||'''';
END IF;

IF(Region IS NOT NULL)
THEN
query1:=query1 ||' and ad_bills.UNIT in (select "Branch_Code" from branch_mst where  BRANCH_MST."Region_code"='''||Region ||''')';
END IF;

IF(agcat IS NOT NULL)
THEN
query1:=query1 ||' AND ad_bills."AGCODE" =agency_mast."code_subcode" and agency_mast."Agency_Cat_Code"='''||agcat ||'''';
END IF;

IF(executive IS NOT NULL)
THEN
query1:=query1 ||' AND ad_bills."EXECUTIVE_NAME"='''||executive||'''';
END IF;

IF(descid IS NOT  NULL)
THEN
query1:=query1||'GROUP BY ad_bills.IDNUM ,AGENCY_MAST."Agency_Name" ,ad_bills_det."CLIENTCD",
PUB_MAST."Pub_Name" ,ad_bills_det."SIZE_BOOK", ad_bills.REVENUE_CENTER ,
ad_bills_det.RATECD ,ad_bills."BILL_RMRK" ,ad_bills."COLOUR" ,ad_bills_det.PRIADCTG  ,
ad_bills_det.SECADCTG ,ad_bills_det."PACKAGE_CODE" ,ad_bills.DISCOUNT ,ad_bills_det.BILNO ,
ad_bills_det.BILDT ,ad_bills."SPPREMIUM", ad_bills.GROSS_AMT,ad_bills.BOXCHRG ,ad_bills.AGCOMM
 --,agency_mast."Add1",ad_bills.PAGENUM,ad_bills.RETAINER_CODE
 ORDER BY "'||descid||'"';
query1:=query1||''||ascdesc||'';
else
query1:=query1||' GROUP BY ad_bills.IDNUM ,AGENCY_MAST."Agency_Name" ,ad_bills_det."CLIENTCD",
PUB_MAST."Pub_Name" ,ad_bills_det."SIZE_BOOK", ad_bills.REVENUE_CENTER ,
ad_bills_det.RATECD ,ad_bills."BILL_RMRK" ,ad_bills."COLOUR" ,ad_bills_det.PRIADCTG  ,
ad_bills_det.SECADCTG ,
ad_bills_det."PACKAGE_CODE" ,
ad_bills.DISCOUNT ,ad_bills_det.BILNO ,ad_bills_det.BILDT 
,ad_bills."SPPREMIUM", ad_bills.GROSS_AMT,ad_bills.BOXCHRG, ad_bills.AGCOMM
    --,agency_mast."Add1",ad_bills.PAGENUM,ad_bills.RETAINER_CODE


order by ad_bills.IDNUM';
END IF;
--DELETE FROM SEARCHTBL;
--insert into searchtbl values(query1);
--commit;

insert into searchtbl values(query1);
OPEN p_recordset1 FOR
query1;
end if;

END ;
/
************************ end of issue 7369 *********************************************************





