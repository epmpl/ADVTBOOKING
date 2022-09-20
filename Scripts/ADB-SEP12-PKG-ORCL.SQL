///*************************Neha****issue no 8282*****************************************/


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
and (m."Booking_type" =p_booktype or p_booktype is null)
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
         else  (nvl(m."Gross_amount",''0'')*(to_number(nvl(m."ADD_AGENCY_COMM",''0'')) )/100)  
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
m."Bill_remarks" as "BillRemark",m."Caption" as "CAPTION",
nvl((SELECT nvl(("Varient_Alias"),'''') FROM varient_mst where "Varient_Code"=m."Variant_code"),'''') as "VARIENT",
nvl((SELECT "prod_alias" FROM Product_cat_mast where "prod_cat_code"=m."Product_code" and "comp_code"=m."Comp_code"),'''') as PRODUCT,
nvl((SELECT "brand_alias" FROM brand_mst where "brand_code"=M."Brand_code"),'''') as BRAND,
(select distinct bktype_desc from ad_bktype_mast where bktype_code=m."Booking_type") AS bktype_desc
,(select "REASON_DESC" from ad_fmg_reason_mast where "REASON_CODE" in (select fmg_reasons from tbl_booking_fmg_trans f where f.CIOID=m."cio_booking_id" )) FMG_REASON
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
--insert into searchtbl values(query1);commit;
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
,BILL_REMARK as "BillRemark",
nvl((SELECT "brand_alias" FROM brand_mst where "brand_code"=temp_ad_bills_report."BRAND_CODE"),'''') as BRAND,
nvl((SELECT nvl(("Varient_Alias"),'''') FROM varient_mst where "Varient_Code"=temp_ad_bills_report."VARIENT_NAME"),'''') as "VARIENT",
nvl((SELECT "prod_alias" FROM Product_cat_mast where "prod_cat_code"=temp_ad_bills_report."PRIPROCTG" and "comp_code"=temp_ad_bills_report."COMP_CODE"),'''') as PRODUCT,
"CAPTION" AS CAPTION,
(select distinct bktype_desc from ad_bktype_mast a,tbl_booking_mast b 
where bktype_code=b."Booking_type" and b."cio_booking_id"=CIOID ) as  bktype_desc 
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
--insert into searchtbl values(query2);commit;
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
          else  (nvl(i."Gross_Rate",''0'')*(to_number(nvl(m."ADD_AGENCY_COMM",''0'')) )/100)  
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
,m."Bill_remarks" as "BillRemark",m."Caption" as "CAPTION",
nvl((SELECT nvl(("Varient_Alias"),'''') FROM varient_mst where "Varient_Code"=m."Variant_code"),'''') as "VARIENT",
nvl((SELECT "prod_alias" FROM Product_cat_mast where "prod_cat_code"=m."Product_code" and "comp_code"=m."Comp_code"),'''') as PRODUCT,
nvl((SELECT "brand_alias" FROM brand_mst where "brand_code"=M."Brand_code"),'''') as BRAND,"Booking_type",
(select distinct bktype_desc from ad_bktype_mast where bktype_code=m."Booking_type" ) AS bktype_desc
,(select "REASON_DESC" from ad_fmg_reason_mast where "REASON_CODE" in (select fmg_reasons from tbl_booking_fmg_trans f where f.CIOID=m."cio_booking_id" )) FMG_REASON
FROM TBL_BOOKING_MAST m,AGENCY_MAST a ,uom_mast,adv_cat_mast,adv_type_mast,pub_mast,TBL_BOOKING_insert i
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
delete from searchtbl;
--insert into searchtbl values(query3);commit;
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
         else  (nvl(a."Gross_amount",''0'')*(to_number(nvl(a."ADD_AGENCY_COMM",''0'')) )/100)
           END )

    ELSE (select 0  from dual)
end
,''0'')  ),''0'') ))as "ActualBusiness",
(select distinct bktype_desc from ad_bktype_mast where bktype_code=a."Booking_type") AS bktype_desc

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

query1:=query1 || ' group by a."date_time",a."Booking_type" order by "Date" ';

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
minus_to_zero(sum(ACTUALBUSINESS))as "ActualBusiness",
(select distinct bktype_desc from ad_bktype_mast a,tbl_booking_mast b 
where bktype_code=b."Booking_type" and b."cio_booking_id"=CIOID ) as  bktype_desc 
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



query2:=query2 || ' group by BILLDATE,CIOID   order by BILLDATE ';




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
           else  (nvl(b."Gross_Rate",''0'')*(to_number(nvl(a."ADD_AGENCY_COMM",''0'')) )/100)
        END )

    ELSE (select 0  from dual)
end
,''0'')  ),''0'')),2)) as "ActualBusiness",
(select distinct bktype_desc from ad_bktype_mast where bktype_code=a."Booking_type" ) AS bktype_desc
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

query3:=query3 || ' group by b."Insert_Date",a."Booking_type" order by "Date" ';

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

/*************************************function for issue no 8282**************************************************/



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
f_caption       varchar2(2000);
f_fmgcode       varchar2(2000);


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
         else  (nvl(FGrossamt,'0')*(to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",'0')) )/100)
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
,max("Uom_code")
,max("Caption")
,max((select "FMG_REASONS" from tbl_booking_fmg_trans f where f."CIOID"= nvl(tbl_booking_mast."cio_booking_id",0)))
 into FRetCommPer,FRetCommAmt,FRetTDPer,FRetTDAmt,FActualBusiness
,Fnoinsert,FPaidinsert,FDeviationamt,FDeviationper,FAggrate,Faggamt,FDiscper,FSpdiscper,FSpacediscper,FSpecialcharge,FAgencyAddlTDper,FAgencyAddlTDAmt
,FfUom
,f_caption
,f_fmgcode

  from tbl_booking_mast where tbl_booking_mast."cio_booking_id"=FCIOID;
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
  CITY_CODE,ZONE_CODE,DIST_CODE,STATE_CODE,PTALUKA,CITY_NAME,ZONE_NAME,STATE_NAME,PAGE_NO,BILL_REMARK,CAPTION,FMG_CODE
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
,f_caption,f_fmgcode
);
commit;


return 0;

--exception when others then
--insert into amit_amit(COMPCODE,subcode,name) values(comp_cod,cio_id,bil_no);  commit;
END;
/
//////////////issue no 8473///////////////////////


ALTER TABLE Pub_Cent_Mast ADD (STATE VARCHAR2(50 BYTE) );

ALTER TABLE  pcmdummy1 ADD (STATE VARCHAR2(50 BYTE) );



CREATE OR REPLACE PACKAGE RAJERP.pcminsert is

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
pcompanyname in varchar2,
plogopath in varchar2,
pstate in varchar2
);
end pcminsert;
/







/////////////////////////////////////////////////////////////////////////////////


CREATE OR REPLACE PACKAGE BODY RAJERP.pcminsert is
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
pcompanyname in varchar2,
plogopath in varchar2,
pstate in varchar2
)as

distcode  varchar2(50);
 statecode  varchar2(50);
 countrycode  varchar2(50);
begin



--select "Dist_Code"  into distcode  from dist_mst where "Dist_Name"=dist;
--select "State_Code"  into statecode from state_mst  where "State_Name"=state;
--select "Country_Code" into countrycode from count_mst  where "Country_Name"=country;

insert into pub_cent_mast("Comp_Code","Pub_cent_Code","Pub_Cent_name","Pub_Cent_Alias","Add1","street","Country_Code","State_Code","Dist_Code","City_Code","zip","Phone1","Phone2","Fax","EmailID","Pub_Cent_Status","Status_date","Remarks","UserId","Creation_Datetime","Region_code","Zone_code","Fax1","BOXADDRESS",PRINT_CENT,FILE_PATH,CIR_FILE_PATH,CENTER_COMP_NAME,LOGO_FILE_PATH,STATE)

 values(compcode,centercode,centername, alias,add1,street,country, state, dist, city, pin,phone1,phone2, fax,email,'',sysdate,remarks,userid,sysdate,region1,zone,fax1,boxaddress,printval,imgpath,cir_imgpath,pcompanyname,plogopath,pstate);


end  pcminsert_p;
end  pcminsert;
/
/////////////////////////////////////////////////////////////////////////////////////////////////




CREATE OR REPLACE PACKAGE RAJERP.pcmexe Is

Type T_Accounts_Cursor Is Ref Cursor;


Procedure pcmexe_P(
compcode in varchar2,
centcode in varchar2,
centname in varchar2,
alias in varchar2,
city in varchar2,
country in varchar2,
pcompname in varchar2,
pstate in varchar2,
p_Accounts Out T_Accounts_Cursor );

End pcmexe;
/
////////////////////////////////////////////////////////////////////////////////////////////////


CREATE OR REPLACE PACKAGE BODY RAJERP.Pcmexe IS

PROCEDURE pcmexe_P(
compcode IN VARCHAR2,
centcode IN VARCHAR2,
centname IN VARCHAR2,
alias IN VARCHAR2,
city IN VARCHAR2,
country IN VARCHAR2,
pcompname in varchar2,
pstate in varchar2,
p_Accounts OUT T_Accounts_Cursor ) AS

BEGIN

DELETE FROM pcmdummy1; COMMIT;

--select "Comp_Code","Pub_cent_Code","Pub_Cent_name","Pub_Cent_Alias","Add1","street","Country_Code", "State_Code","Dist_Code","City_Code","zip","Phone1","Phone2","Fax","EmailID",(select "cent_status" from pcm_status where  "center_code" ="Pub_cent_Code"),sysdate,"Remarks","UserId",(select "TO_DATE" from pcm_status where "center_code"="Pub_cent_Code" ),(select "FROM_DATE" from pcm_status where "center_code"="Pub_cent_Code" ),"Creation_Datetime","Region_code" as "Region_code","Zone_code" as "Zone_code","Fax1" from pub_cent_mast
INSERT INTO pcmdummy1
SELECT "Comp_Code","Pub_cent_Code","Pub_Cent_name","Pub_Cent_Alias","Add1","street","Country_Code",
"State_Code","Dist_Code","City_Code","zip","Phone1","Phone2","Fax","EmailID","Pub_Cent_Status"
,SYSDATE,"Remarks","UserId",SYSDATE,SYSDATE,"Creation_Datetime","Region_code","Zone_code","Fax1","BOXADDRESS",PRINT_CENT,
(select "Region_Name" from region_mst where region_mst."Region_Code"=pub_cent_mast."Region_code") as "Region_Name",
(select "Zone_Name" from zone_mast where zone_mast."Zone_Code"= pub_cent_mast."Zone_code") as "Zone_Name",FILE_PATH,CIR_FILE_PATH,CENTER_COMP_NAME,LOGO_FILE_PATH,STATE
FROM pub_cent_mast
WHERE "Comp_Code"=compcode AND  ("Pub_cent_Code"=centcode OR centcode IS NULL)AND
 ("Pub_Cent_name" LIKE centname||'%' OR centname IS NULL)
AND  ("Pub_Cent_Alias" LIKE alias||'%' OR alias IS NULL)
AND  ("Country_Code"=country OR country IS NULL)
AND  ("City_Code"=city OR city IS NULL)
AND  ("CENTER_COMP_NAME" LIKE pcompname||'%' OR pcompname IS NULL)
AND  ("STATE"=pstate OR pstate IS NULL)

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
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


CREATE OR REPLACE PACKAGE RAJERP.pcmupdate is
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
pcompanyname in varchar2,
plogopath    in varchar2,
pstate in varchar2
);
end pcmupdate;
/






////////////////////////////////////////////////////////////////////////////////










CREATE OR REPLACE PACKAGE BODY RAJERP.pcmupdate is
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
pcompanyname in varchar2,
plogopath    in varchar2,
pstate in varchar2
)
as
begin

 update pub_cent_mast set "Pub_Cent_name"=centername , "Pub_Cent_Alias"=alias, "Add1"=add1, "street"=street, "Country_Code"=country, "State_Code"=state, "Dist_Code"=dist, "City_Code"=city, "zip"=pin, "Phone1"=phone1, "Phone2"=phone2,"Fax"=fax, "EmailID"=email,

 "Remarks"=remarks,"Region_code"=region1,"Zone_code"=zone,"Fax1"=fax1, "BOXADDRESS"=boxadd , PRINT_CENT=printval,FILE_PATH=imgpath,CIR_FILE_PATH=cir_imgpath,CENTER_COMP_NAME=pcompanyname,LOGO_FILE_PATH=plogopath,STATE=pstate where "Comp_Code"=compcode  and   "Pub_cent_Code"=centercode;

 commit;


end pcmupdate_p;
end pcmupdate;
/
//////////////////////////////////////////////////////////////////////
//////////////////////////////











//////////end of issue 8473/////////////////////////////done by shipra///;




/**************************************************Issue 7948 Dhananjay **************************************************/

CREATE OR REPLACE PROCEDURE rpt_vts_report (
   pagency_code   IN       VARCHAR2,
   pclient_code   IN       VARCHAR2,
   pfrom_date     IN       VARCHAR2,
   pto_date       IN       VARCHAR2,
   pdateformat    IN       VARCHAR2,
   ppublication   IN       VARCHAR2,
   pedition       IN       VARCHAR2,
   ppub_center    IN       VARCHAR2,
   pbranch        IN       VARCHAR2,
   pcompcode      IN       VARCHAR2,
   puserid        IN       VARCHAR2,
   chk_access     IN       VARCHAR2,
   clienttype     IN       VARCHAR2,
   pextra1        IN       VARCHAR2,        --1 for billed data,2 for unbilled
   pextra2        IN       VARCHAR2,                           --state exclude
   p_accounts     OUT      cur_type_new1.cursor_type
)
IS
   query1    VARCHAR2 (8000);
   v_frdt    DATE;
   v_todt    DATE;
   v_pubdt   DATE;
BEGIN
--v_frdt :=to_date(pfrom_date,pdateformat);
--v_todt :=to_date(pto_date,pdateformat);
   IF pfrom_date = pto_date
   THEN
      v_pubdt := pfrom_date;
   END IF;

   v_frdt := pfrom_date;
   v_todt := pto_date;
   query1 :=
         query1
      || 'select distinct a."Comp_code", a."cio_booking_id" as "CIOID",a."date_time" as bkdate, c."Agency_Name" AS "AGENCY",c."Add1",c."Add2",c."Add3",(select "City_Name" from city_mst where "City_Code"=c."City_Code") city_name,
c."Dist_Code",c."State_Code",
nvl((SELECT "Cust_Name" FROM  CUST_MAST WHERE a."Comp_code"= CUST_MAST."Comp_Code" AND "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT",
nvl((SELECT "Add1" FROM  CUST_MAST WHERE a."Comp_code"= CUST_MAST."Comp_Code" AND "Cust_Code"=a."Client_code"),a."Client_address")  AS "CLIENT_ADDR", 
fetch_publish_edtnname(a."Comp_code",a."cio_booking_id",case when nvl(b."Insert_Date",'''
      || v_pubdt
      || ''')=nvl('''
      || v_pubdt
      || ''',b."Insert_Date") then nvl(b."Insert_Date",'''
      || v_pubdt
      || ''') else to_date('''
      || v_pubdt
      || ''',''dd/mm/yyyy'') end,null,null,null,null,b."No_Insert",null) as "EDITION",to_char(b."Insert_Date",'''
      || pdateformat
      || ''') AS "PUB_DATE" ,
a."No_of_insertion",nvl(a."Agrred_rate",a."Card_rate" ) AS "RATE",
(select "Comp_Name" from  comp_mst where comp_mst."Comp_Code"=a."Comp_code") comp_name,
(select "Package_Name" from combin_mast where "Combin_Code"=b.package_code) package_name,
nvl(a."Vts",0) as "VTS",nvl(a."CIRRATE",0) as "CIRRATE"
from  tbl_booking_mast a, tbl_booking_insert b, agency_mast c
WHERE a."Comp_code"='''
      || pcompcode
      || ''' AND
a."Agency_sub_code"=c."code_subcode" AND
a."cio_booking_id"=b."Cio_Booking_Id"  
and ((b."Pub_Cent_Code" in (select distinct pub_center from  login_center where newuser_id='''
      || puserid
      || ''') and '''
      || chk_access
      || '''=''1'')
or  ('''
      || chk_access
      || '''=''0'') )
';

   IF (pfrom_date IS NOT NULL AND pto_date IS NOT NULL)
   THEN
      query1 :=
            query1
         || ' and b."Insert_Date" between  '''
         || v_frdt
         || ''' and  '''
         || v_todt
         || ''' ';
   END IF;

   IF (pagency_code IS NOT NULL)
   THEN
      query1 :=
              query1 || ' and a."Agency_code" =  ''' || pagency_code || ''' ';
   END IF;

   IF (pclient_code IS NOT NULL)
   THEN
      query1 := query1 || ' and a."Client_code"=''' || pclient_code || '''';
   END IF;

   IF (ppublication IS NOT NULL)
   THEN
      query1 :=
            query1 || ' and  b."Publication_Code"=''' || ppublication || '''';
   END IF;

   IF (ppub_center IS NOT NULL) OR ppub_center <> '0'
   THEN
      query1 := query1 || '  and b."Pub_Cent_Code"=''' || ppub_center || '''';
   END IF;

   IF (pedition IS NOT NULL) AND pedition <> '0'
   THEN
      query1 := query1 || '  and b."Edition_Code" in (''' || pedition || ''' )';
   END IF;

   IF (pbranch IS NOT NULL) AND pbranch <> '0'
   THEN
      query1 := query1 || '  and a."branch"=''' || pbranch || '''';
   END IF;

   IF pextra1 = '1'
   THEN                                                               --billed
      query1 := query1 || '  and b.bill_no is not null';
   ELSIF pextra1 = '2'
   THEN                                                             --unbilled
      query1 := query1 || '  and b.bill_no is null';
   ELSE
      NULL;
   END IF;

   IF pextra2 IS NOT NULL OR pextra2 <> '0'
   THEN
      query1 := query1 || '  and c.state not in (''' || pextra2 || ''' )';
   END IF;

   IF (clienttype IS NOT NULL OR clienttype <> '')
   THEN
      IF clienttype = 'R'
      THEN
         query1 :=
               query1
            || '  and "Client_code" in (select "Cust_Code" from  cust_mast where "Comp_Code" = '''
            || pcompcode
            || ''''
            || 'and "Cust_Status"=''ACTIVE'')';
      ELSE
         IF clienttype = 'N'
         THEN
            query1 :=
                  query1
               || '  and "Client_code" not in (select "Cust_Code" from  cust_mast where "Comp_Code = '''
               || pcompcode
               || ''''
               || 'and "Cust_Status"=''ACTIVE'')';
         ELSE
            query1 := query1;
         END IF;
      END IF;
   END IF;

insert into test1 (vstring) values (query1);commit;
   OPEN p_accounts FOR query1;
--DELETE  FROM SEARCHTBL;INSERT INTO SEARCHTBL VALUES('PK'||query1);COMMIT;
END rpt_vts_report;
/



/************************************************END issue 7948****************************************/



/**************************************************Issue 8301 Dhananjay **************************************************/

CREATE OR REPLACE PROCEDURE completereport(
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
    p_fmgreason     in varchar2:=null,
    p_recordset1    OUT Cur_Type_New1.cursor_type,
    p_accounts      OUT Cur_Type_New1.cursor_type
    
    )

IS
query1          VARCHAR2(32000);
v_val           number(20);
query2          VARCHAR2(32000);
query3          VARCHAR2(32000);


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
and (m."Booking_type" =p_booktype or p_booktype is null)
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
         else  (nvl(m."Gross_amount",''0'')*(to_number(nvl(m."ADD_AGENCY_COMM",''0'')) )/100)  
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
m."Bill_remarks" as "BillRemark",m."Caption" as "CAPTION",
nvl((SELECT nvl(("Varient_Alias"),'''') FROM varient_mst where "Varient_Code"=m."Variant_code"),'''') as "VARIENT",
nvl((SELECT "prod_alias" FROM Product_cat_mast where "prod_cat_code"=m."Product_code" and "comp_code"=m."Comp_code"),'''') as PRODUCT,
nvl((SELECT "brand_alias" FROM brand_mst where "brand_code"=M."Brand_code"),'''') as BRAND,
(select distinct bktype_desc from ad_bktype_mast where bktype_code=m."Booking_type") AS bktype_desc
--,(select "REASON_DESC" from ad_fmg_reason_mast where "REASON_CODE" in (select fmg_reasons from tbl_booking_fmg_trans f where f.CIOID=m."cio_booking_id" )) FMG_REASON
,(select "REASON_DESC" from ad_fmg_reason_mast where "REASON_CODE" =f.FMG_REASONS) FMG_REASON
FROM TBL_BOOKING_MAST m,AGENCY_MAST a ,UOM_MAST,
adv_cat_mast,
adv_type_mast,
TBL_BOOKING_insert i,
tbl_booking_fmg_trans f
WHERE m."Comp_code"='''||p_compcode||''' AND
m."cio_booking_id"=i."Cio_Booking_Id" AND
f.CIOID=m."cio_booking_id"  and
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
insert into searchtbl values(query1,'nn','');commit;
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
,BILL_REMARK as "BillRemark",
nvl((SELECT "brand_alias" FROM brand_mst where "brand_code"=temp_ad_bills_report."BRAND_CODE"),'''') as BRAND,
nvl((SELECT nvl(("Varient_Alias"),'''') FROM varient_mst where "Varient_Code"=temp_ad_bills_report."VARIENT_NAME"),'''') as "VARIENT",
nvl((SELECT "prod_alias" FROM Product_cat_mast where "prod_cat_code"=temp_ad_bills_report."PRIPROCTG" and "comp_code"=temp_ad_bills_report."COMP_CODE"),'''') as PRODUCT,
"CAPTION" AS CAPTION,
(select distinct bktype_desc from ad_bktype_mast a,tbl_booking_mast b 
where bktype_code=b."Booking_type" and b."cio_booking_id"=CIOID ) as  bktype_desc 
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
          else  (nvl(i."Gross_Rate",''0'')*(to_number(nvl(m."ADD_AGENCY_COMM",''0'')) )/100)  
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
,m."Bill_remarks" as "BillRemark",m."Caption" as "CAPTION",
nvl((SELECT nvl(("Varient_Alias"),'''') FROM varient_mst where "Varient_Code"=m."Variant_code"),'''') as "VARIENT",
nvl((SELECT "prod_alias" FROM Product_cat_mast where "prod_cat_code"=m."Product_code" and "comp_code"=m."Comp_code"),'''') as PRODUCT,
nvl((SELECT "brand_alias" FROM brand_mst where "brand_code"=M."Brand_code"),'''') as BRAND,"Booking_type",
(select distinct bktype_desc from ad_bktype_mast where bktype_code=m."Booking_type" ) AS bktype_desc
--,(select "REASON_DESC" from ad_fmg_reason_mast where "REASON_CODE" in (select fmg_reasons from tbl_booking_fmg_trans f where f.CIOID=m."cio_booking_id" )) FMG_REASON
,(select "REASON_DESC" from ad_fmg_reason_mast where "REASON_CODE" =f.FMG_REASONS) FMG_REASON
FROM TBL_BOOKING_MAST m,AGENCY_MAST a ,uom_mast,adv_cat_mast,adv_type_mast,pub_mast,TBL_BOOKING_insert i,tbl_booking_fmg_trans f
WHERE m."Comp_code"='''||p_compcode||''' AND
m."cio_booking_id"=i."Cio_Booking_Id" and
f.CIOID=m."cio_booking_id" and
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
delete from searchtbl;
--insert into searchtbl values(query3);commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'OPEN p_recordset1 FOR   '||query3,dbg_seq.nextval);commit;
OPEN p_recordset1 FOR
query3;

end if;

else

if(p_adcheck=1)
then

delete from searchtbl;
insert into searchtbl values('gg','','');commit;
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
         else  (nvl(a."Gross_amount",''0'')*(to_number(nvl(a."ADD_AGENCY_COMM",''0'')) )/100)
           END )

    ELSE (select 0  from dual)
end
,''0'')  ),''0'') ))as "ActualBusiness",
(select distinct bktype_desc from ad_bktype_mast where bktype_code=a."Booking_type") AS bktype_desc

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

query1:=query1 || ' group by a."date_time",a."Booking_type" order by "Date" ';

--insert into dbgstr(rdate,str,seq) values(sysdate,'OPEN p_recordset1 FOR1   '||query1,dbg_seq.nextval);commit;

OPEN p_recordset1 FOR
query1;



elsif(p_adcheck=2)then
delete from searchtbl;
insert into searchtbl values('gg1','','');commit;
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
minus_to_zero(sum(ACTUALBUSINESS))as "ActualBusiness",
(select distinct bktype_desc from ad_bktype_mast a,tbl_booking_mast b 
where bktype_code=b."Booking_type" and b."cio_booking_id"=CIOID ) as  bktype_desc 
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



query2:=query2 || ' group by BILLDATE,CIOID   order by BILLDATE ';




OPEN p_recordset1 FOR
query2;

elsif(p_adcheck=3) then

delete from searchtbl;
insert into searchtbl values('gg2','','');commit;
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
           else  (nvl(b."Gross_Rate",''0'')*(to_number(nvl(a."ADD_AGENCY_COMM",''0'')) )/100)
        END )

    ELSE (select 0  from dual)
end
,''0'')  ),''0'')),2)) as "ActualBusiness",
(select distinct bktype_desc from ad_bktype_mast where bktype_code=a."Booking_type" ) AS bktype_desc
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

query3:=query3 || ' group by b."Insert_Date",a."Booking_type" order by "Date" ';

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


/************************************************END issue 8301****************************************/

/********************************issue 7880 update by Dhananjay ****************************************/

DROP PROCEDURE AD_REP_USER_FORM_RIGHTS;

CREATE OR REPLACE PROCEDURE ad_rep_user_form_rights (
   pcomp_code     IN       VARCHAR2,
   punit_code     IN       VARCHAR2,
   puser_code     IN       VARCHAR2,
   pmodule_code   IN       VARCHAR2,
   pdateformat    IN       VARCHAR2,
   pextra1        IN       VARCHAR2,
   pextra2        IN       VARCHAR2,
   p_accounts     OUT      cur_type_new1.cursor_type,
   p_accounts1    OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT DISTINCT a."userid" AS "USER_CODE", l."username" AS "USER_NAME",
                      a."comp_code" AS "COMP_CODE",
                      (SELECT "Comp_Name"
                         FROM comp_mst
                        WHERE a."comp_code" =
                                          comp_mst."Comp_Code")
                                                              AS "COMP_NAME",
                      "retainer_code" AS "UNIT_CODE",
                      (SELECT "Branch_Name"
                         FROM branch_mst
                        WHERE "Branch_Code" =
                                             l."retainer_code")
                                                              AS "UNIT_NAME",
                      a."Form_id" AS "FORM_ID", b."Form_Name" AS "FORM_NAME",
                      b."Form_Alias" AS "FORM_MENUNAME",
                      b.formtype AS "FORM_TYPE",
                      CASE
                         WHEN b.formtype = 'M'
                            THEN 'MASTER'
                         WHEN b.formtype = 'T'
                            THEN 'TRANSACTION'
                         ELSE 'REPORT'
                      END AS "FORM_TY_NAME",
                      CASE NVL (a."Button_id", '0')
                         WHEN '0'
                            THEN 'No Permission'
                         WHEN '1'
                            THEN 'Insert Only'
                         WHEN '2'
                            THEN 'Update Only'
                         WHEN '4'
                            THEN 'Delete Only'
                         WHEN '3'
                            THEN 'Insert,Update Only'
                         WHEN '5'
                            THEN 'Insert,Delete Only'
                         WHEN '6'
                            THEN 'Update,Delete Only'                         
                         WHEN '7'
                            THEN 'All Permission'
                         WHEN '9'
                            THEN 'Insert Only'
                         WHEN '10'
                            THEN 'Update Only'
                         WHEN '11'
                            THEN 'Insert,Update Only'                         
                         WHEN '12'
                            THEN 'Delete Only'
                         WHEN '13'
                            THEN 'Insert,Delete Only'
                         WHEN '14'
                            THEN 'Update,Delete Only'
                         WHEN '15'
                            THEN 'All Permission'
                         WHEN '8'
                            THEN 'View Only'
                         ELSE 'Not Applicable'
                      END AS "USER_RIGHT",
                      (SELECT "Agency_Role_Name"
                         FROM agency_role_master
                        WHERE "Agency_Role_Code" = l."ROLEID")
                                                              AS "ROLE_NAME"
                 FROM module_detaibuttonl a, formmast b, login l
                WHERE a."comp_code" = pcomp_code
                  AND (l."retainer_code" = punit_code OR punit_code IS NULL)
                  AND a."userid" = NVL (puser_code, a."userid")
                  AND l."userid" =NVL (puser_code, a."userid")
                  AND a.modulecode = pmodule_code
                  AND a.modulecode = b.modulecode
                  AND a."Form_id" = b."form_id"
             ORDER BY user_name,
                      comp_name,
                      unit_name,
                      form_ty_name,
                      form_menuname;

   OPEN p_accounts1 FOR
      SELECT DISTINCT a."userid" AS "USER_CODE", l."username" AS "USER_NAME",
                      a."comp_code" AS "COMP_CODE",
                      (SELECT "Comp_Name"
                         FROM comp_mst
                        WHERE a."comp_code" =
                                          comp_mst."Comp_Code")
                                                               AS "COMP_NAME",
                      "retainer_code" AS "UNIT_CODE",
                      (SELECT "Branch_Name"
                         FROM branch_mst
                        WHERE "Branch_Code" =
                                             l."retainer_code")
                                                               AS "UNIT_NAME",
                      (SELECT "Agency_Role_Name"
                         FROM agency_role_master
                        WHERE "Agency_Role_Code" = l."ROLEID") AS "ROLE_NAME"
                 FROM module_detaibuttonl a, formmast b, login l
                WHERE a."comp_code" = NVL (pcomp_code, a."comp_code")
                  AND (l."retainer_code" = punit_code OR punit_code IS NULL)
                  AND a."userid" = NVL (puser_code, a."userid")
                  AND l."userid" = a."userid"
                  AND a.modulecode = pmodule_code
                  AND a.modulecode = b.modulecode
                  AND a."Form_id" = b."form_id"
             ORDER BY user_name, comp_code, unit_name;
END ad_rep_user_form_rights;
/





/************************************************END issue 7880****************************************/


/****************************Issue no 7931 updated by Dhananjay ******************/

DROP PACKAGE RPT_CATEGORYWISEDATE_SUMMARY;

CREATE OR REPLACE PACKAGE rpt_categorywisedate_summary IS
  TYPE T_Accounts_Cursor is ref cursor;
  procedure rpt_categorywisedate_billing(
      pcompcode         IN VARCHAR2,
      ppcentcode        IN VARCHAR2,
      punitcode         IN VARCHAR2,
      padtype           IN VARCHAR2,
      padcat            IN VARCHAR2,
      padsubcat         IN VARCHAR2,
      pad_subcat3       IN VARCHAR2,
      pad_subcat4       IN VARCHAR2,
      pad_subcat5       IN VARCHAR2,
      pdist_code        IN VARCHAR2,
      pfrom_date        IN VARCHAR2,
      ptill_date        IN VARCHAR2,
      pdateformat       IN VARCHAR2,
      puserid           IN VARCHAR2,
      ppublcode         IN VARCHAR2,
      pedtncode         IN VARCHAR2,
      pteamcode         IN VARCHAR2,
      pexecode          IN VARCHAR2,
      pextra1           IN VARCHAR2,
      pextra2           IN VARCHAR2,
      pextra3           IN VARCHAR2,
      pextra4           IN VARCHAR2,
      pextra5           IN VARCHAR2,      
      p_accounts        OUT T_Accounts_Cursor,
      p_accounts1       OUT T_Accounts_Cursor,
      p_accounts2       OUT T_Accounts_Cursor);
End rpt_categorywisedate_summary;
/



DROP PACKAGE BODY RPT_CATEGORYWISEDATE_SUMMARY;

CREATE OR REPLACE PACKAGE BODY rpt_categorywisedate_summary IS
    procedure rpt_categorywisedate_billing(
      pcompcode         IN VARCHAR2,
      ppcentcode        IN VARCHAR2,
      punitcode         IN VARCHAR2,
      padtype           IN VARCHAR2,
      padcat            IN VARCHAR2,
      padsubcat         IN VARCHAR2,
      pad_subcat3       IN VARCHAR2,
      pad_subcat4       IN VARCHAR2,
      pad_subcat5       IN VARCHAR2,
      pdist_code        IN VARCHAR2,
      pfrom_date        IN VARCHAR2,
      ptill_date        IN VARCHAR2,
      pdateformat       IN VARCHAR2,
      puserid           IN VARCHAR2,
      ppublcode         IN VARCHAR2,
      pedtncode         IN VARCHAR2,
      pteamcode         IN VARCHAR2,
      pexecode          IN VARCHAR2,
      pextra1           IN VARCHAR2,
      pextra2           IN VARCHAR2,
      pextra3           IN VARCHAR2,
      pextra4           IN VARCHAR2,
      pextra5           IN VARCHAR2,
      p_accounts        OUT T_Accounts_Cursor,
      p_accounts1       OUT T_Accounts_Cursor,
      p_accounts2       OUT T_Accounts_Cursor)
  As
      v_frdt            date;
      v_todt            date;

      cursor c1 is
      select x.comp_code comp_code,x.ad_cat ad_cat,x.adcat_name adcat_name,
        x.ad_sub_cat ad_sub_cat,x.ad_subcat3 ad_subcat3,x.ad_subcat4 ad_subcat4,x.ad_subcat5 ad_subcat5,
        x.insertion_no insertion_no,x.disp_book_area disp_book_area,nvl(x.disp_amount,0)+nvl(x.lineage_amount,0) amount,
        x.lineage_book_area lineage_book_area,x. insert_date  insert_date from
        (select m."Comp_code" comp_code,i."Ad_Cat" ad_cat,c."Adv_Cat_Name" adcat_name,
        i."Ad_Sub_Cat" ad_sub_cat,i."AD_SUBCAT3" AD_SUBCAT3,i."AD_SUBCAT4" AD_SUBCAT4,i."AD_SUBCAT5" AD_SUBCAT5,
        count(i."No_Insert") insertion_no,sum(i."Size_Book") disp_book_area,round(Sum("Bill_Amt"),2) disp_amount,
        0 lineage_book_area,0 lineage_amount,i."Insert_Date" as  insert_date
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=pcompcode and c."Comp_Code"=m."Comp_code" and c."Adv_Cat_Code"=i."Ad_Cat" and
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"||a."SUB_Agency_Code"=m."Agency_sub_code" and
        i."Insert_Date" between v_frdt and v_todt and (m."Ad_type_code"=padtype or padtype is null) and
        i."Insert_Status" in('publish','audit by rate','billed') and
        (i."Ad_Cat"=padcat or padcat is null) and (i."Ad_Sub_Cat"=padsubcat or padsubcat is null) and
        (i."AD_SUBCAT3"=pad_subcat3 or pad_subcat3 is null) and (i."AD_SUBCAT4"=pad_subcat4 or pad_subcat4 is null) and
        (i."AD_SUBCAT5"=pad_subcat5 or pad_subcat5 is null) and
        (a.district =pdist_code or pdist_code is null) and
        m."branch"=b."Branch_Code" and
        (b."Branch_Code"=punitcode or punitcode is null) and (b."pub_center"=ppcentcode or ppcentcode is null) and
        (m."Executive_code"=pexecode or pexecode is null) and
        (i."Publication_Code"=ppublcode or ppublcode is null) and (i."Edition_Code"=pedtncode or pedtncode is null) and
        (i."Height" is not null and i."Width" is not null)
        group by m."Comp_code",i."Ad_Cat",c."Adv_Cat_Name",i."Ad_Sub_Cat",i."AD_SUBCAT3",i."AD_SUBCAT4",i."AD_SUBCAT5",i."Insert_Date"
        union all
        select m."Comp_code" comp_code,i."Ad_Cat" ad_cat,c."Adv_Cat_Name" adcat_name,
        i."Ad_Sub_Cat" ad_sub_cat,i."AD_SUBCAT3" AD_SUBCAT3,i."AD_SUBCAT4" AD_SUBCAT4,i."AD_SUBCAT5" AD_SUBCAT5,
        count(i."No_Insert") insertion_no,0 disp_book_area,0 disp_amount,
        sum(i."Size_Book") lineage_book_area,round(Sum("Bill_Amt"),2) lineage_amount,i."Insert_Date" as  insert_date
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=pcompcode and c."Comp_Code"=m."Comp_code" and c."Adv_Cat_Code"=i."Ad_Cat" and
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"||a."SUB_Agency_Code"=m."Agency_sub_code" and
        i."Insert_Date" between v_frdt and v_todt and (m."Ad_type_code"=padtype or padtype is null) and
        i."Insert_Status" in('publish','audit by rate','billed') and
        (i."Ad_Cat"=padcat or padcat is null) and (i."Ad_Sub_Cat"=padsubcat or padsubcat is null) and
        (i."AD_SUBCAT3"=pad_subcat3 or pad_subcat3 is null) and (i."AD_SUBCAT4"=pad_subcat4 or pad_subcat4 is null) and
        (i."AD_SUBCAT5"=pad_subcat5 or pad_subcat5 is null) and
        (a.district =pdist_code or pdist_code is null) and
        m."branch"=b."Branch_Code" and
        (b."Branch_Code"=punitcode or punitcode is null) and (b."pub_center"=ppcentcode or ppcentcode is null) and
        (m."Executive_code"=pexecode or pexecode is null) and
        (i."Publication_Code"=ppublcode or ppublcode is null) and (i."Edition_Code"=pedtncode or pedtncode is null) and
        (i."Height" is null and i."Width" is null)
        group by m."Comp_code",i."Ad_Cat",c."Adv_Cat_Name",i."Ad_Sub_Cat",i."AD_SUBCAT3",i."AD_SUBCAT4",i."AD_SUBCAT5",i."Insert_Date") x
        order by comp_code,insert_date,adcat_name,adcat_name,ad_sub_cat,ad_subcat3,ad_subcat4,ad_subcat5;

    v1_comp_code    varchar2(20);
    v1_ad_cat       varchar2(20);
    v1_adcat_name   varchar2(200);
    v1_ad_sub_cat   varchar2(20);
    v1_ad_subcat3   varchar2(20);
    v1_ad_subcat4   varchar2(20);
    v1_ad_subcat5   varchar2(20);
    v1_insertion    number(10);
    v1_disp_area    number(18,2);
    v1_line_area    number(18,2);
    v1_amt          number(18,2);
	v1_insert_date  date;
    v_rec_seqno     number:=0;
    v_adsubcat_nm   varchar2(200);
    v_adsubcat_nm3  varchar2(200);
    v_adsubcat_nm4  varchar2(200);
    v_adsubcat_nm5  varchar2(200);
  Begin
    v_frdt          :=to_date(pfrom_date,''''||pdateformat||'''');
    v_todt          :=to_date(ptill_date,''''||pdateformat||'''');
    delete from temp_ad_receipt_report where sess_id=userenv('sessionid');
    open c1;
    loop
        fetch c1 into v1_comp_code,v1_ad_cat,v1_adcat_name,v1_ad_sub_cat,v1_ad_subcat3,v1_ad_subcat4,v1_ad_subcat5,v1_insertion,v1_disp_area,v1_amt,v1_line_area,v1_insert_date;
        exit when c1%notfound;
        v_rec_seqno:=nvl(v_rec_seqno,0)+1;

        v_adsubcat_nm   :=AD_GET_catnameE (v1_comp_code,v1_ad_sub_cat,'subcat');
        v_adsubcat_nm3  :=AD_GET_catnameE (v1_comp_code,v1_ad_subcat3,'cat3');
        v_adsubcat_nm4  :=AD_GET_catnameE (v1_comp_code,v1_ad_subcat4,'cat4');
        v_adsubcat_nm5  :=AD_GET_catnameE (v1_comp_code,v1_ad_subcat5,'cat5');
        insert into temp_ad_receipt_report
                (comp_code,unit_code,pcentre_code,ad_main_category,ad_sub_category,ad_package,ret_code,exe_code,recovary_days,ad_size,
                amount,rec_seqno,ad_rate,insert_date)
          values(pcompcode,punitcode,ppcentcode,v1_adcat_name,v_adsubcat_nm,v_adsubcat_nm3,v_adsubcat_nm4,v_adsubcat_nm5,v1_insertion,v1_disp_area,
                v1_amt,v_rec_seqno,v1_line_area,v1_insert_date);
    end loop;
    close c1;
    commit;

    open p_accounts for
    select distinct a.comp_code as COMP_CODE,
    a.ad_main_category as AD_MAIN_CAT,a.ad_sub_category as AD_SUB_CAT,
    a.ad_package as AD_SUB_CAT3,
    (select "Comp_Name" from comp_mst where "Comp_Code"=a.comp_code)  as "CNAME",
    sum(a.recovary_days) as NO_OF_INSERTION,sum(a.ad_size) as BOOK_AREA,sum(a.amount) as AMOUNT,
    sum(a.ad_rate) as LINE_AREA,a.insert_date
    from temp_ad_receipt_report a
    where sess_id=userenv('sessionid')
    group by a.comp_code,a.ad_main_category,a.ad_sub_category,a.ad_package,a.insert_date
   /* ORDER BY AD_MAIN_CAT,AD_SUB_CAT,AD_SUB_CAT3,insert_date;*/
   ORDER BY insert_date;

    open p_accounts1 for
    select distinct a.comp_code as COMP_CODE,
    a.ad_main_category as AD_MAIN_CAT,a.ad_sub_category as AD_SUB_CAT,
    (select "Comp_Name" from comp_mst where "Comp_Code"=a.comp_code)  as "CNAME",
    sum(a.recovary_days) as NO_OF_INSERTION,sum(a.ad_size) as BOOK_AREA,sum(a.amount) as AMOUNT,
    sum(a.ad_rate) as LINE_AREA,a.insert_date
    from temp_ad_receipt_report a
    where sess_id=userenv('sessionid')
    group by a.comp_code,a.ad_main_category,a.ad_sub_category,a.insert_date
   /* ORDER BY AD_MAIN_CAT,AD_SUB_CAT,insert_date;*/
     ORDER BY insert_date;
     
    open p_accounts2 for
    select distinct a.comp_code as COMP_CODE,
    a.ad_main_category as AD_MAIN_CAT,
    (select "Comp_Name" from comp_mst where "Comp_Code"=a.comp_code)  as "CNAME",
    sum(a.recovary_days) as NO_OF_INSERTION,sum(a.ad_size) as BOOK_AREA,sum(a.amount) as AMOUNT,
    sum(a.ad_rate) as LINE_AREA,a.insert_date
    from temp_ad_receipt_report a
    where sess_id=userenv('sessionid')
    group by a.comp_code,a.ad_main_category,a.insert_date
   /* ORDER BY AD_MAIN_CAT,a.insert_date;*/
   ORDER BY a.insert_date;

    delete from temp_ad_receipt_report where sess_id=userenv('sessionid');commit;
   End rpt_categorywisedate_billing;
End rpt_categorywisedate_summary;
/




/********************END*****************/



/****************************Issue no 8542 updated by Dhananjay ******************/

CREATE OR REPLACE PROCEDURE  Ro_Report
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
            ,(select  branch_mst."Branch_Name" from branch_mst where branch_mst."Branch_Code"=a."branch" and branch_mst."Comp_Code"=a."Comp_code" ) as BRANCH
             ,a."Bill_pay" PAY_MODE_CODE
            ,(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=a."Comp_code" and "Pay_Mode_Code"=a."Bill_pay") PAY_MODE_NAME
            ,(SELECT p."Pub_Cent_name" FROM PUB_CENT_MAST p  WHERE p."Pub_cent_Code" in(select  branch_mst."pub_center" from branch_mst where branch_mst."pub_center"=p."Pub_cent_Code" and branch_mst."Comp_Code" =p."Comp_Code"  and branch_mst."Branch_Code"=a."branch" and branch_mst."Comp_Code"=a."Comp_code" and p."Comp_Code" =a."Comp_code" )  and a."Comp_code"=p."Comp_Code" ) PUB_CENT_CODE
            from tbl_booking_mast a ,tbl_booking_insert i ,agency_mast b,adv_cat_mast c where
            a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' 
            AND a."Comp_code"=i."Comp_Code" 
            
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            
            AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Agency_sub_code"=b."code_subcode"  and lower(i."Insert_Status")<>''cancel''';
        else/* for summary*/
            query1:='select DISTINCT b."Agency_Name" AS "AGENCY",
            b."Dist_Code"  as "DISTRICT",
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
           
            SUM(DECODE(RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,agency_mast b/*,adv_cat_mast c*/
            where  
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Agency_sub_code"=b."code_subcode" 
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            and i."Insert_Status"<>''cancel''';
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
            
            ,(select  branch_mst."Branch_Name" from branch_mst where branch_mst."Branch_Code"=a."branch" and branch_mst."Comp_Code"=a."Comp_code" ) as BRANCH
            
            
             ,a."Bill_pay" PAY_MODE_CODE
            ,(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=a."Comp_code" and "Pay_Mode_Code"=a."Bill_pay") PAY_MODE_NAME
            ,(SELECT p."Pub_Cent_name" FROM PUB_CENT_MAST p  WHERE p."Pub_cent_Code" in(select  branch_mst."pub_center" from branch_mst where branch_mst."pub_center"=p."Pub_cent_Code" and branch_mst."Comp_Code" =p."Comp_Code"  and branch_mst."Branch_Code"=a."branch" and branch_mst."Comp_Code"=a."Comp_code" and p."Comp_Code" =a."Comp_code" )  and a."Comp_code"=p."Comp_Code" ) PUB_CENT_CODE
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,EXEC_MAST,agency_mast b ,adv_cat_mast c
            where a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" 
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Executive_code"=exec_mast."Exe_no" AND 
             a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel'' ';
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
            
            ,(select  branch_mst."Branch_Name" from branch_mst where branch_mst."Branch_Code"=a."branch" and branch_mst."Comp_Code"=a."Comp_code" ) as BRANCH
            
             ,a."Bill_pay" PAY_MODE_CODE
            ,(select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=a."Comp_code" and "Pay_Mode_Code"=a."Bill_pay") PAY_MODE_NAME
            ,(SELECT p."Pub_Cent_name" FROM PUB_CENT_MAST p  WHERE p."Pub_cent_Code" in(select  branch_mst."pub_center" from branch_mst where branch_mst."pub_center"=p."Pub_cent_Code" and branch_mst."Comp_Code" =p."Comp_Code"  and branch_mst."Branch_Code"=a."branch" and branch_mst."Comp_Code"=a."Comp_code" and p."Comp_Code" =a."Comp_code" )  and a."Comp_code"=p."Comp_Code" ) PUB_CENT_CODE
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER,agency_mast b ,adv_cat_mast c
            where a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code"
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
             AND a."cio_booking_id"=i."Cio_Booking_Id" and
            RETAINERMASTER."Retain_Code"=a.RETAINER AND 
             a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel'' ';
            end if;
        else/* for summary*/
         
         if(age_exeret='2')then
            query1:='select distinct  
             EXEC_MAST."Exec_name"  as "EXE_RET",      
             EXEC_MAST."dist_code"  as "DISTRICT",
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
            
             
            SUM(DECODE(a.RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(a.RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(a.RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(a.RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,EXEC_MAST ,agency_mast b /*,adv_cat_mast c*/
            where  
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Executive_code"=exec_mast."Exe_no" 
            and a."Agency_sub_code"=b."code_subcode" 
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            and i."Insert_Status"<>''cancel'' ';
         else
          query1:='select distinct 
            
             RETAINERMASTER."Retain_Name"     as "EXE_RET",
           
             RETAINERMASTER."Dist_Code"   as "DISTRICT",
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
           
            SUM(DECODE(a.RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(a.RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(a.RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(a.RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER ,agency_mast b/*,adv_cat_mast c*/
            where 
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" 
            AND not exists (select ''x'' from tbl_booking_mast where a."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
            AND a."cio_booking_id"=i."Cio_Booking_Id" and
            RETAINERMASTER."Retain_Code"=a.RETAINER 
            and a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel'' ';
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

    if (pro_doc_status is not null) then
        if pro_doc_status ='0' then
            query1:=query1||' and nvl(a."RODOCSTATUS",''0'') = '''||pro_doc_status||''' ';
             elsif pro_doc_status ='NORO' then
            query1:=query1||' and NVL(a."RODOCSTATUS",''NORO'') not in(''o'',''f'',''x'') ';
        else
            query1:=query1||' and a."RODOCSTATUS" = '''||pro_doc_status||''' ';
        end if;    
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
                        group by o.comp_code,o.billno,o.billdt having sum(o.amount)>=10) OR i.bill_no IS NULL ) ';
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
            query1:=query1||' GROUP BY a."cio_booking_id"  ,b."Agency_Name"   ,a."Executive_code",a.RETAINER,"Client_code",c."Adv_Cat_Name","RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT,a."Bill_pay",a."branch",a."Comp_code"';
        elsif(age_exeret='2')then
            query1:=query1||' group by a."cio_booking_id"  ,b."Agency_Name",EXEC_MAST."Exec_name","Client_code",c."Adv_Cat_Name" ,"RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT,a."Bill_pay",a."branch",a."Comp_code" ';
        else
            query1:=query1||' GROUP BY a."cio_booking_id"  ,b."Agency_Name",RETAINERMASTER."Retain_Name","Client_code",c."Adv_Cat_Name" ,"RO_No","RODOCSTATUS",a."Bill_amount",a.RO_COMMENT,a."Bill_pay",a."branch",a."Comp_code"';
        end if;
        
        
        
    end if;

  delete from searchtbl;
   /* insert into searchtbl values(query1);commit;*/


    OPEN p_accounts FOR query1;
    open p_accounts1 for
    select comp_mst."Comp_Name" from comp_mst where comp_mst."Comp_Code"=pcompcode;
END Ro_Report;
/



/********************END*****************/


/******************bhanu**************/

create index tbl_booking_vts_idx on tbl_booking_vts (cioid,insertid);
create index advpos_prem_mast_idx on advpos_prem_mast("comp_code","Premiumcode");




/********************END*****************//////////


//////////changes send by mimoh sir////////////


CREATE OR REPLACE PACKAGE BODY editiontypecheck

IS

   PROCEDURE editiontypecheck_p (

      pub           IN       VARCHAR2,

      type1         IN       VARCHAR2,

      city          IN       VARCHAR2,

      compcode      IN       VARCHAR2,

      userid        IN       VARCHAR2,

      p_accounts    OUT      t_accounts_cursor,

      p_accounts1   OUT      t_accounts_cursor

   )

   AS

   BEGIN

      OPEN p_accounts FOR

         SELECT "Edition_Type"

           FROM edition_mast

          WHERE "Comp_Code" = compcode

            AND "Pub_Code" = pub

            AND "City_Code" = city

            AND "Edition_Type" = type1;




      OPEN p_accounts1 FOR

         SELECT "Edition_Type"

           FROM edition_mast

          WHERE "Comp_Code" = compcode

            AND "Pub_Code" = pub

            AND "City_Code" = city;      -- and ("Edition_Type"=Main Edition);

   END editiontypecheck_p;

END editiontypecheck;

//////////end by mimoh sir////////////done by shipra////////


/////////bhanu ////////

alter TABLE Payment_Mode_Mast modify "Payment_Mode_Name" VARCHAR2(50)


////////end bhanu/////////