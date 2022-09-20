========start=======avinash=====17/08/2012======================================


CREATE  procedure clientupdttrasac
   @pcomp_code   varchar(12),
   @puserid      varchar(10),
   @pclientcod   varchar(10)
   
as 

select "cio_booking_id",(select "Agency_Name" from agency_mast where "code_subcode"=m."Agency_sub_code" and "Comp_Code"=@pcomp_code) as "Agency_Name" ,
"Client_code",(select "Package_Name" from combin_mast where "Combin_Code"=m."Package_code" and "Comp_Code"=@pcomp_code) as "Package_Name" 
from tbl_booking_mast m 
where "Comp_code"=@pcomp_code and "Client_code"=@pclientcod;


****************************************************
CREATE  procedure clientupdttrasac2
   @pciobookid  VARCHAR(15),

  @pclientcod  VARCHAR(10),
  @pcomp_cod  varchar(12)
  

   AS
  

         UPDATE TBL_BOOKING_Mast SET "Client_code"=@pclientcod,
"Client_address"=isnull((SELECT isnull("Add1",'') FROM CUST_MAST where "Cust_Name"=@pclientcod),'') 
WHERE  "cio_booking_id"=@pciobookid
          and "Comp_code"=@pcomp_cod







========end=======avinash=====17/08/2012======================================


========start===8199====avinash=====20/08/2012======================================

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


                                          
ALTER procedure [dbo].[completereport](
	@compcode		as varchar(50)= NULL,
	@fromdate		as varchar(50)= NULL,
	@dateto			as varchar(50)= NULL,
	@dateformat		as varchar(50)= NULL,
	@publication	as varchar(50)= NULL,
	@pub_cent		as varchar(50)= NULL,
	@edition		as varchar(50)= NULL,
	@suppliment		as varchar(50)= NULL,
	@zone			as varchar(50)= NULL,
	@branch			as varchar(50)= NULL,
	@district		as varchar(50)= NULL,
	@region			as varchar(50)= NULL,
	@city			as varchar(50)= NULL,
	@revcenter		as varchar(50)= NULL,
	@adtype			as varchar(50)= NULL,
	@agencytype		as varchar(50)= NULL,
	@ratetype		as varchar(50)= NULL,
	@adcat			as varchar(50)= NULL,
	@adsubcat		as varchar(50)= NULL,
	@adsubcat3		as varchar(50)= NULL,
	@adsubcat4		as varchar(50)= NULL,
	@adsubcat5		as varchar(50)= NULL,
	@package		as varchar(50)= NULL,
	@scheme			as varchar(50)= NULL,
	@agency			as varchar(50)= NULL,
	@client			as varchar(50)= NULL,
	@executive		as varchar(50)= NULL,
	@retainer		as varchar(50)= NULL,
	@product		as varchar(50)= NULL,
	@brand			as varchar(50)= NULL,
	@varient		as varchar(50)= NULL,
	@pagetype		as varchar(50)= NULL,
	@pageprem		as varchar(50)= NULL,
	@postprem		as varchar(50)= NULL,
	@rostatus		as varchar(50)= NULL,
	@booktype		as varchar(50)= NULL,
	@contractname	as varchar(50)= NULL,
	@filterby		as varchar(50)= NULL,
	@adcheck		as varchar(50)=null,
	@state			as varchar(50)=null,
	@taluka			as varchar(50)=null,
	@base			as varchar(50)=null,
	@drpstatus		as varchar(50)=null,
	@chkdetail		as varchar(50)=null,
	@insertstatus	as varchar(50)=null,
	@puserid		as varchar(50)=null,
	@p_baxcode      as varchar(20)=null,
	@chk_access		as varchar(2)=null)
AS
declare @query1 as VARCHAR(8000)
declare @v_val  as int
declare @query2 as VARCHAR(8000)
declare @query4 as VARCHAR(8000)
declare @query3 as VARCHAR(8000)
declare @queryp as VARCHAR(8000)
declare @bookdate as VARCHAR(50)
declare @noinsert as VARCHAR(50)
declare @Paidinsert as VARCHAR(50)
declare @Area as VARCHAR(50)
declare @Pagepremium as VARCHAR(50)
declare @cardamt as VARCHAR(50)
declare @Deviationamt as VARCHAR(50)
declare @Deviationper as VARCHAR(50)
declare @aggamt as VARCHAR(50)
declare @DiscAmt as VARCHAR(50)
declare @Discper as VARCHAR(50)
declare @posamt as VARCHAR(50)
declare @posper as VARCHAR(50)
declare @Spdiscamt as VARCHAR(50)
declare @Spdiscper as VARCHAR(50)
declare @Spacedisc as VARCHAR(50)
declare @Spacediscper as VARCHAR(50)
declare @Specialcharge as VARCHAR(50)
declare @AgencyAddlTDper as VARCHAR(50)
declare @AgencyAddlTDAmt as VARCHAR(50)
declare @Grossamt as VARCHAR(50)
declare @RetTDper as VARCHAR(50)
declare @RetTDAmt as VARCHAR(50)
declare @AgencyTDper as VARCHAR(50)
declare @AgencyTDAmt as VARCHAR(50)
declare @Billamt as VARCHAR(50)
declare @RetCommper as VARCHAR(50)
declare @RetCommAmt as VARCHAR(50)
declare @ActualBusines as VARCHAR(50)
----------------------------------------
declare @v_edition  as VARCHAR(100)
declare @v_edipkg  as VARCHAR(500)
declare @prefer    as VARCHAR(10)
declare @v_frdt as varchar(10)
declare @v_todt as varchar(10)
-----------cursor variables--------------
declare @c1cioid as varchar(50)
declare @c1pckcode as varchar(50)
declare @c1gramt as float
declare @c1chkvar as varchar(4)
/********************************for billing***********************************************/
declare @v2_CIOID as varchar(100)
declare @v2_BILLNO as varchar(100) 
declare @v2_AGMAINCODE as varchar(100) 
declare @v2_AG_SUB_CODE as varchar(100)
declare @v2_AGCODE as varchar(100)
declare @v2_AGNAME as varchar(200)
declare @v2_EXECCODE as varchar(100)
declare @v2_EXECNAME as varchar(200)
declare @v2_RETCODE as varchar(100)
declare @v2_RETNAME as varchar(200)
declare @q_n as varchar(8000)


/*********************************for billing************************************************/
/*
CREATE TABLE #TEMP_COMPLETE_DYNAMIC_REPORT(  ROW_CODE    VARCHAR(50),  ROW_DESC    VARCHAR(150),  COL_CODE    VARCHAR(50),  COL_DESC    VARCHAR(150),  COL_BILAMT  float,  COL_ACTAMT  float)
CREATE TABLE #MULTIPACK_REP(  CIOID  VARCHAR(500),  PACK   VARCHAR(500))
CREATE TABLE #MULTIPACK_RAT(  CIOID    VARCHAR(500),  RAT      VARCHAR(500),  PER_AMT  int)
CREATE TABLE #MULTIPACK_RATNEW(  CIOID    VARCHAR(500),  RAT      VARCHAR(500),  PER_AMT  int)
*/
create table #temp_ad_bills_report 
( CIOID             varchar(50),
  BILLNO            varchar(25),
  AGENCY            varchar(50),
  CLIENT            varchar(200),
  RONO              varchar(40),
  RODATE            DATEtime,
  EXECUTIVE         varchar(50),
  RETAINER          varchar(80),
  BOOKTYPE          varchar(8),
  COLOR             varchar(20),
  ADCAT             varchar(50),
  ADSUBCAT          varchar(50),
  ADSUBCAT3         varchar(50),
  ADSUBCAT4         varchar(50),
  ADSUBCAT5         varchar(50),
  PACKAG            varchar(500),
  BILLDATE          DATEtime,
  NOINSERT          int,
  PAIDINSERT        int,
  HEIGHT            int,
  WIDTH             int,
  AREA              int,
  PAGEPREMIUM       varchar(30),
  POSTPREM          varchar(30),
  SCHEME            varchar(50),
  RATECOD           varchar(40),
  CARDRATE          FLOAT,
  CARDAMT           FLOAT,
  CONTRACTRATE      int,
  DEVIATIONAMT      int,
  DEVIATIONPER      int,
  AGGRATE           int,
  AGGAMT            int,
  DISCAMT           FLOAT,
  DISCPER           int,
  POSAMT            int,
  POSPER            int,
  SPDISCAMT         int,
  SPDISCPER         int,
  SPACEDISC         int,
  SPACEDISCPER      int,
  SPECIALCHARGE     int,
  AGENCYADDLTDPER   varchar(8),
  AGENCYADDLTDAMT   int,
  GROSSAMT          int,
  RETTDPER          int,
  RETTDAMT          int,
  AGENCYTDPER       int,
  AGENCYTDAMT       int,
  BILLAMT           int,
  RETCOMMPER        int,
  RETCOMMAMT        int,
  ACTUALBUSINESS    int,
  REVCENTER         varchar(2000),
  UOM               varchar(2000),
  UOMDESC           varchar(2000),
  COMP_CODE         varchar(2000),
  PADTYPE           varchar(2000),
  PRIPUB            varchar(2000),
  PEDITION          varchar(2000),
  BRANCH_NAME       varchar(2000),
  PUB_CENT_CODE     varchar(2000),
  REGION            varchar(2000),
  AGENCY_TYPE_CODE  varchar(2000),
  PRIADCTG          varchar(2000),
  SECADCTG          varchar(2000),
  AD_SUBCAT3        varchar(2000),
  AD_SUBCAT4        varchar(2000),
  AD_SUBCAT5        varchar(2000),
  PACKAGE_CODE      varchar(2000),
  AG_MAIN_CODE      varchar(2000),
  AG_SUB_CODE       varchar(2000),
  CLIENTCD          varchar(2000),
  EXECUTIVE_NAME    varchar(2000),
  PRIPROCTG         varchar(2000),
  BRAND_CODE        varchar(2000),
  VARIENT_NAME      varchar(2000),
  PAGE_PREM         varchar(2000),
  PAGE_POST         varchar(2000),
  CONTRACT_NAME     varchar(2000),
  SUPP_CODE         varchar(2000),
  RETAINER_CODE     varchar(2000),
  RATECD            varchar(2000),
  CITY_CODE         varchar(2000),
  ZONE_CODE         varchar(2000),
  DIST_CODE         varchar(2000),
  STATE_CODE        varchar(2000),
  PTALUKA           varchar(2000),
  PSCHEME           varchar(2000),
  REVENUE_CENTER    varchar(2000),
  RO_STATUS         varchar(2000),
  PAGE_TYPE         varchar(2000),
  BOOKING_TYPE      varchar(2000),
  PUB_CENT_PERMIT   varchar(2000),
  SESS_ID           int        ,
  DIST_NAME         varchar(2000),
  TALU_NAME         varchar(2000),
  PUB_CENT_NAME     varchar(2000),
  CITY_NAME         varchar(2000),
  ZONE_NAME         varchar(2000),
  STATE_NAME        varchar(2000),
PAGE_NO int,
BILL_REMARK         varchar(2000),
CAPTION VARCHAR(2000)


)
declare c1 cursor for
		SELECT distinct TBL_BOOKING_mast.cio_booking_id AS "CIOID",
		TBL_BOOKING_MAST.Package_code as "package_code",TBL_BOOKING_mast.Gross_amount as "Crate",'1' as "chk_var"
		FROM TBL_BOOKING_MAST, TBL_BOOKING_INSERT
		WHERE TBL_BOOKING_MAST.Comp_code=@compcode
		AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
		AND ((tbl_booking_mast.Insertion_date BETWEEN @fromdate AND @dateto and @filterby='Publish Date') or (tbl_booking_mast.date_time BETWEEN @fromdate AND @dateto and @filterby='Booking Date'))
		AND (TBL_BOOKING_INSERT.Publication_Code=@publication or @publication is null)
		--and TBL_BOOKING_MAST.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code=@pub_cent or @pub_cent is null))
		and TBL_BOOKING_MAST."branch" IN (SELECT  "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT  "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=@pub_cent or @pub_cent is null))
		and((@branch is null) or  (tbl_booking_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" =@branch) ))

		AND (TBL_BOOKING_MAST.Ad_type_code=@adtype or @adtype is null)
		AND (TBL_BOOKING_MAST.Ad_cat_code=@adcat or @adcat is null)
		AND (TBL_BOOKING_INSERT.Edition_Code=@edition or @edition is null)
		and (tbl_booking_mast.branch =@branch or @branch is null)
		and (TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.region =@region  or @region is null))
		and (tbl_booking_mast.Revenue_center =@revcenter or @revcenter is null)
		and (TBL_BOOKING_MAST.Agency_type =@agencytype or @agencytype is null)
		and (TBL_BOOKING_MAST.Ad_sub_cat_code =@adsubcat or @adsubcat is null)
		and (TBL_BOOKING_MAST.Ad_Subcat3 =@adsubcat3 or @adsubcat3 is null)
		and (TBL_BOOKING_MAST.Ad_Subcat4 =@adsubcat4 or @adsubcat4 is null or @adsubcat4='')
		and (TBL_BOOKING_MAST.Ad_subcat5 =@adsubcat5 or @adsubcat5 is null or @adsubcat5='')
		and (TBL_BOOKING_MAST.Package_code =@package or @package is null)
		and (TBL_BOOKING_MAST.Scheme_type_code =@scheme or @scheme is null)
		and (TBL_BOOKING_MAST.Agency_code =@agency or @agency is null)
		and (TBL_BOOKING_MAST.Client_code =@client or @client is null)
		and (TBL_BOOKING_MAST.Executive_code =@executive or @executive is null)
		and (TBL_BOOKING_MAST.RETAINER =@retainer or @retainer is null)
		and (TBL_BOOKING_MAST.Product_code =@product  or @product is null)
		and (TBL_BOOKING_MAST.Brand_code =@brand or @brand is null)
		and (TBL_BOOKING_MAST.Variant_code =@varient or @varient is null)
		and (TBL_BOOKING_MAST.Page_type_code =@pagetype or @pagetype is null)
		and (TBL_BOOKING_MAST.Page_prem =@pageprem or @pageprem is null)
		and (TBL_BOOKING_MAST.Page_position_code =@postprem or @postprem is null)
		and (TBL_BOOKING_MAST.ro_status =@rostatus or @rostatus is null)
		and (TBL_BOOKING_MAST.Booking_type =@booktype or @booktype is null)
		and (TBL_BOOKING_MAST.Contract_name =@contractname or @contractname is null)
		and (tbl_booking_insert.Supp_Code =@suppliment or @suppliment is null)
		and (tbl_booking_MAST.Rate_code =@ratetype or @ratetype is null)
		and (tbl_booking_mast.Box_code = @p_baxcode or @p_baxcode is null)
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.City_Code =@city or @city is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code =@city or @city is null))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.City_Code=@city or @city is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.zone_code =@zone or @zone is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= @zone or @zone is null) ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Zone_Code=@zone or @zone is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.Dist_Code =@district or @district is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code= @district or @district is null ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Dist_Code=@district or @district is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.State_Code =@state or @state is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code= @state or @state is null ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.State_Code=@state or @state is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.TALUKA=@taluka or @taluka is null ))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA= @taluka or @taluka is null ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.TALUKA=@taluka or @taluka is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code IS NOT NULL AND TBL_BOOKING_MAST.Agency_sub_code!='0')
		or (@base='2' and tbl_booking_mast.Executive_code    is not null and tbl_booking_mast.Executive_code !='0' )
		or (@base='3' and tbl_booking_mast.RETAINER is not null  and tbl_booking_mast.RETAINER !='0'))

--and ((@drpstatus is  not null and  TBL_BOOKING_INSERT.Insert_Status!='XYZ')or(@drpstatus is  null and  lower(Insert_Status)!='cancel'))

and ((@drpstatus ='1' and  lower(TBL_BOOKING_INSERT.Insert_Status)!='hold')
or (@drpstatus ='2' and  lower(TBL_BOOKING_INSERT.Insert_Status)!='cancel')
or (@drpstatus is null and  TBL_BOOKING_INSERT.Insert_Status!='XYZ')
)

        and (lower(Insert_Status)=@insertstatus or @insertstatus is null)

      -- and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access='1')
      -- or  (@chk_access='0') )
		and @adcheck='1'
		union--************** union****************************
		SELECT distinct TBL_BOOKING_mast.cio_booking_id AS "CIOID",
		TBL_BOOKING_MAST.Package_code as "package_code",tbl_booking_insert.Gross_Rate as "Crate",'1' as "chk_var"
		FROM TBL_BOOKING_MAST, TBL_BOOKING_INSERT
		WHERE TBL_BOOKING_MAST.Comp_code=@compcode
		AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
		AND (tbl_booking_insert.Insert_Date BETWEEN @fromdate AND @dateto )
		AND (TBL_BOOKING_INSERT.Publication_Code=@publication or @publication is null)
		--and TBL_BOOKING_MAST.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code=@pub_cent or @pub_cent is null))

and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=@pub_cent or @pub_cent is null))
and (tbl_booking_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" =@branch))

		AND (TBL_BOOKING_MAST.Ad_type_code=@adtype or @adtype is null)
		AND (TBL_BOOKING_insert.Ad_Cat=@adcat or @adcat is null)
		AND (TBL_BOOKING_INSERT.Edition_Code=@edition or @edition is null)
		and (tbl_booking_mast.branch =@branch or @branch is null)
		and (TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.region =@region  or @region is null))
		and (tbl_booking_mast.Revenue_center =@revcenter or @revcenter is null)
		and (TBL_BOOKING_MAST.Agency_type =@agencytype or @agencytype is null)
		and (TBL_BOOKING_MAST.Ad_sub_cat_code =@adsubcat or @adsubcat is null)
		and (TBL_BOOKING_MAST.Ad_Subcat3 =@adsubcat3 or @adsubcat3 is null)
		and (TBL_BOOKING_MAST.Ad_Subcat4 =@adsubcat4 or @adsubcat4 is null)
		and (TBL_BOOKING_MAST.Ad_subcat5 =@adsubcat5 or @adsubcat5 is null)
		and (TBL_BOOKING_MAST.Package_code =@package or @package is null)
		and (TBL_BOOKING_MAST.Scheme_type_code =@scheme or @scheme is null)
		and (TBL_BOOKING_MAST.Agency_code =@agency or @agency is null)
		and (TBL_BOOKING_MAST.Client_code =@client or @client is null)
		and (TBL_BOOKING_MAST.Executive_code =@executive or @executive is null)
		and (TBL_BOOKING_MAST.RETAINER =@retainer or @retainer is null)
		and (TBL_BOOKING_MAST.Product_code =@product  or @product is null)
		and (TBL_BOOKING_MAST.Brand_code =@brand or @brand is null)
		and (TBL_BOOKING_MAST.Variant_code =@varient or @varient is null)
		and (TBL_BOOKING_MAST.Page_type_code =@pagetype or @pagetype is null)
		and (TBL_BOOKING_insert.Premium1 =@pageprem or @pageprem is null)
		and (tbl_booking_insert.Page_Post =@postprem or @postprem is null)
		and (TBL_BOOKING_MAST.ro_status =@rostatus or @rostatus is null)
		and (TBL_BOOKING_MAST.Booking_type =@booktype or @booktype is null)
		and (TBL_BOOKING_MAST.Contract_name =@contractname or @contractname is null)
		and (tbl_booking_insert.Supp_Code =@suppliment or @suppliment is null)
		and (tbl_booking_MAST.Rate_code =@ratetype or @ratetype is null)
		and (tbl_booking_mast.Box_code = @p_baxcode or @p_baxcode is null)
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.City_Code =@city or @city is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code =@city or @city is null))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.City_Code=@city or @city is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.zone_code =@zone or @zone is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= @zone or @zone is null) ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Zone_Code=@zone or @zone is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.Dist_Code =@district or @district is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code= @district or @district is null ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Dist_Code=@district or @district is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.State_Code =@state or @state is null))
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code= @state or @state is null ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.State_Code=@state or @state is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code  in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.TALUKA=@taluka or @taluka is null) )  
		or (@base='2' and tbl_booking_mast.Executive_code  in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA= @taluka or @taluka is null ))
		or (@base='3' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.TALUKA=@taluka or @taluka is null)))
		and ((@base='1' and TBL_BOOKING_MAST.Agency_sub_code IS NOT NULL AND TBL_BOOKING_MAST.Agency_sub_code!='0')
		or (@base='2' and tbl_booking_mast.Executive_code    is not null and tbl_booking_mast.Executive_code !='0' )
		or (@base='3' and tbl_booking_mast.RETAINER is not null  and tbl_booking_mast.RETAINER !='0'))
		--and ((@drpstatus is  not null and  TBL_BOOKING_INSERT.Insert_Status!='XYZ')		or (@drpstatus is  null and  lower(Insert_Status)!='cancel'))

and ((@drpstatus ='1' and  lower(TBL_BOOKING_INSERT.Insert_Status)!='hold')
or (@drpstatus ='2' and  lower(TBL_BOOKING_INSERT.Insert_Status)!='cancel')
or (@drpstatus is null and  TBL_BOOKING_INSERT.Insert_Status!='XYZ')
)

and (lower(Insert_Status)=@insertstatus or @insertstatus is null)
--and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access='1')
--or  (@chk_access='0') )
		and @adcheck='3'
		union--***********************Union*****************************
		SELECT distinct ad_bills.IDNUM AS "CIOID",
		ad_bills_det.PACKAGE_CODE as "package_code",ad_bills.GROSS_AMT as "Crate",'2' as "chk_var"
		FROM ad_bills, ad_bills_det
		WHERE ad_bills.IDNUM=ad_bills_det.IDNUM
		AND (ad_bills.BILDT between @fromdate and @dateto)
		and (ad_bills.PRIPUB=@publication  or @publication is null)
		and (ad_bills_det.EDITION=@edition or @edition is null)
		and (ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.region =@region  or @region is null))
		and (ad_bills_det.AD_TYPE_V=@adtype or @adtype is null)
		and (ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.Agency_Type_Code =@agencytype or @agencytype is null))
		and (ad_bills_det.PRIADCTG =@adcat or @adcat is null)
		and (ad_bills_det.SECADCTG =@adsubcat or @adsubcat is null)
		and (ad_bills_det.AD_SUBCAT3  =@adsubcat3 or @adsubcat3 is null)
		and (ad_bills_det.AD_SUBCAT4 =@adsubcat4 or @adsubcat4 is null)
		and (ad_bills_det.AD_SUBCAT5 =@adsubcat5 or @adsubcat5 is null)
		and (ad_bills_det.PACKAGE_CODE =@package or @package is null)
		--and (ad_bills.AGCODE =@agency  or @agency is null)
and (ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.Agency_Code =@agency or @agency is null))
		and (ad_bills.CLIENTCD=@client or @client is null)
		and (ad_bills.EXECUTIVE_NAME=@executive or @executive is null)
		and (ad_bills.PRIPROCTG=@product or @product is null)
		and ((ad_bills.PRIPROCTG in (select brand_mst.prod_cat_code from brand_mst where brand_mst.brand_code=@brand or @brand is null) and ad_bills.PRIPROCTG is not null)or (ad_bills.PRIPROCTG is null))
		and ((ad_bills.PRIPROCTG in (select brand_mst.prod_cat_code from brand_mst where brand_mst.brand_code in(select varient_mst.Brand_Code from varient_mst where varient_mst.Varient_Name=@varient or @varient is null)) and ad_bills.PRIPROCTG is not null) or (ad_bills.PRIPROCTG is null))
		and (ad_bills_det.PAGE_PREM =@pageprem or @pageprem is null)
		and (ad_bills_det.PAGE_POST =@postprem or @postprem is null)
		and (ad_bills.CONTRACT_NAME =@contractname or @contractname is null)
		and (ad_bills_det.SUPP_CODE =@suppliment or @suppliment is null)
		and (ad_bills.RETAINER_CODE =@retainer or @retainer is null)
		and (ad_bills_det.RATECD =@ratetype or @ratetype is null)
		and ((ad_bills.UNIT  in(select branch_mst.Branch_Code from branch_mst where  branch_mst.Branch_Name =@branch or @branch is null) and ad_bills.UNIT is not null ) or (ad_bills.UNIT is not null))
		and ad_bills.UNIT IN (SELECT Branch_Code FROM BRANCH_MST WHERE ad_bills.UNIT=Branch_Code and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code=@pub_cent or @pub_cent is null))
		and (ad_bills.SCHEME=@scheme or @scheme is null)
		and (AD_BILLS.REVENUE_CENTER =@revcenter or @revcenter is null)
		and (AD_BILLS.RO_STATUS =@rostatus or @rostatus is null)
		and (AD_BILLS.PAGE_TYPE =@pagetype or @pagetype is null)
		and (AD_BILLS.BOOKING_TYPE =@booktype or @booktype is null)
		and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.City_Code =@city or @city is null))
		or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code =@city or @city is null))
		or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.City_Code=@city or @city is null)))
		and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.zone_code =@zone or @zone is null))
		or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= @zone or @zone is null) ))
		or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Zone_Code=@zone or @zone is null)))
		and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.Dist_Code =@district or @district is null))
		or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code= @district or @district is null ))
		or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Dist_Code=@district or @district is null)))
		and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.State_Code =@state or @state is null))
		or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code= @state or @state is null ))
		or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.State_Code=@state or @state is null)))
		and ((@base='1' and ad_bills.AGCODE   in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.TALUKA=@taluka or @taluka is null) )  
		or (@base='2' and ad_bills.EXECUTIVE_NAME   in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA= @taluka or @taluka is null ))
		or (@base='3' and ad_bills.RETAINER_CODE  in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.TALUKA=@taluka or @taluka is null)))
		and ((@base='1' and ad_bills.AGCODE IS NOT NULL AND ad_bills.AGCODE!='0')
		or (@base='2' and ad_bills.EXECUTIVE_NAME   is not null and ad_bills.EXECUTIVE_NAME !='0' )
		or (@base='3' and ad_bills.RETAINER_CODE  is not null  and ad_bills.RETAINER_CODE !='0'))
       --and ((ad_bills_det.BKFOR in (select distinct pub_center from login_center where newuser_id=@puserid) and @chk_access='1')
       --or  (@chk_access='0') )
		and @adcheck='2'

declare  C2 Cursor for
SELECT distinct ad_bills.IDNUM AS "CIOID",ad_bills.BILNO as "BILLNO" ,ag_main_code as "AGMAINCODE",ag_sub_code as "AG_SUB_CODE",agcode as "AGCODE",
dbo.agename(@compcode,agcode) as "AGNAME",
isnull(executive_name,0) as "EXECCODE",
dbo.AD_GET_EXECNAME(@compcode,EXECUTIVE_NAME) as "EXECNAME",
RETAINER_CODE as "RETCODE",
dbo.AD_GET_RETAINER(@compcode,RETAINER_CODE) as "RETNAME"
FROM ad_bills WHERE ((ad_bills.UNIT  in(select branch_mst.Branch_Code from branch_mst where  branch_mst.Branch_Name =@branch or @branch is null) and ad_bills.UNIT is not null ) or (ad_bills.UNIT is  null))
and ad_bills.UNIT IN (SELECT Branch_Code FROM BRANCH_MST WHERE ad_bills.UNIT=Branch_Code and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code=@pub_cent or @pub_cent is null))
and (ad_bills.BILDT between @fromdate and @dateto)
and (ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.region =@region  or @region is null))
and (ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.Agency_Type_Code =@agencytype or @agencytype is null))
and (ad_bills.PRIPUB=@publication  or @publication is null)
and (ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where agency_mast.Agency_Code =@agency or @agency is null))
and (ad_bills.CLIENTCD=@client or @client is null)
and (ad_bills.EXECUTIVE_NAME=@executive or @executive is null)
and (ad_bills.PRIPROCTG=@product or @product is null)
and ((ad_bills.PRIPROCTG in (select brand_mst.prod_cat_code from brand_mst where brand_mst.brand_code=@brand or @brand is null) and ad_bills.PRIPROCTG is not null)or (ad_bills.PRIPROCTG is null or ad_bills.PRIPROCTG=''))
and ((ad_bills.PRIPROCTG in (select brand_mst.prod_cat_code from brand_mst where brand_mst.brand_code in(select varient_mst.Brand_Code from varient_mst where varient_mst.Varient_Name=@varient or @varient is null)) and ad_bills.PRIPROCTG is not null) or (ad_bills.PRIPROCTG is null or ad_bills.PRIPROCTG=''))
and (ad_bills.CONTRACT_NAME =@contractname or @contractname is null)
and (ad_bills.RETAINER_CODE =@retainer or @retainer is null)
and (ad_bills.SCHEME=@scheme or @scheme is null)
and (AD_BILLS.REVENUE_CENTER =@revcenter or @revcenter is null)
and (AD_BILLS.RO_STATUS =@rostatus or @rostatus is null)
and (AD_BILLS.PAGE_TYPE =@pagetype or @pagetype is null)
and (AD_BILLS.BOOKING_TYPE =@booktype or @booktype is null)
and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.City_Code =@city or @city is null))
or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code =@city or @city is null))
or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.City_Code=@city or @city is null)))
and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.zone_code =@zone or @zone is null))
or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= @zone or @zone is null) ))
or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Zone_Code=@zone or @zone is null)))
and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.Dist_Code =@district  or @district  is null))
or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code= @district  or @district  is null ))
or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Dist_Code=@district  or @district  is null)))
and ((@base='1' and ad_bills.AGCODE in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.State_Code =@state or @state is null))
or (@base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code= @state or @state is null ))
or (@base='3' and ad_bills.RETAINER_CODE in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.State_Code=@state or @state is null)))
and ((@base='1' and ad_bills.AGCODE   in (select AGENCY_MAST.code_subcode from agency_mast where AGENCY_MAST.TALUKA=@taluka or @taluka is null) )
or (@base='2' and ad_bills.EXECUTIVE_NAME   in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA= @taluka or @taluka is null ))
or (@base='3' and ad_bills.RETAINER_CODE  in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.TALUKA=@taluka or @taluka is null)))
and ((@base='1' and ad_bills.AGCODE IS NOT NULL AND ad_bills.AGCODE!='0')
or (@base='2' and ad_bills.EXECUTIVE_NAME   is not null and ad_bills.EXECUTIVE_NAME !='0' )
or (@base='3' and ad_bills.RETAINER_CODE  is not null  and ad_bills.RETAINER_CODE !='0'))



set @v_frdt=@fromdate
set @v_todt=@dateto
select distinct @prefer= AGENCY_RETAINER_COMM from preferrences where comp_code=@compcode
delete from temp_complete_dynamic_report


delete from MULTIPACK_REP	
delete from MULTIPACK_RAT
delete from MULTIPACK_RATNEW
open c1
fetch next from c1 into @c1cioid ,@c1pckcode,@c1gramt,@c1chkvar
	PRINT(@@FETCH_STATUS)
	while @@FETCH_STATUS=0 begin
		PRINT('prachi')
		PRINT(@c1chkvar)
	if(@c1chkvar='1')begin	
		insert into MULTIPACK_REP select * from dbo.multipack_report1(@c1cioid, @c1pckcode, @c1gramt, '1')

	end
	else if(@c1chkvar='3') begin
		insert into MULTIPACK_RAT select * from dbo.multipack_report3(@c1cioid, @c1pckcode, @c1gramt, '3')
	end
	else begin
		insert into MULTIPACK_RATNEW select * from dbo.multipack_report2(@c1cioid, @c1pckcode, @c1gramt, '2')
	end
	set @v_edition=null
	set @v_edipkg=null
fetch next from c1 into @c1cioid ,@c1pckcode,@c1gramt,@c1chkvar
end
close c1

print('145466')
print(@chkdetail)
print(@adcheck)
print('xz')
if(@chkdetail='Detail')begin
	if(@adcheck=1) begin
	set @query1='SELECT distinct a.cio_booking_id AS CIOID
	,CASE '''+@dateformat+'''
	 WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),a.date_time,101)
	WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),a.date_time,103)
	WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),a.date_time,111) END as BookDate,
	AGENCY_MAST.Agency_Name AS Agency,
	isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS Client,
	RO_No AS "RoNo.",
	CASE '''+@dateformat+'''
	WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),RO_Date,101)
	WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),RO_Date,103)
	WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),RO_Date,111) END AS "Ro.Date",
	(select EXEC_MAST.Exec_name from exec_mast where a.Executive_code=exec_mast.Exe_no) AS Executive,
	(select RETAINERMASTER.Retain_Name  FROM  RETAINERMASTER where RETAINERMASTER.Retain_Code=a.RETAINER ) AS Retainer,
	case a.Booking_type
	when ''1'' then ''Barter''
	when ''2'' then ''FMG''
	when ''3'' then ''Normal''
	when ''4'' then ''InHouse''
	when ''5'' then ''Complimentary''
	else ''Normal'' end as BookType,
	(select col_mast.Col_Alias from col_mast where a.Color_code=col_mast.Col_Code) as Color,
	adv_cat_mast.Adv_Cat_Name as Adcat,
	(select adv_subcat_mast.Adv_Subcat_Name from adv_subcat_mast where a.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code)as Adsubcat,
	(select ad_cat3.catname from ad_cat3,adv_subcat_mast  where a.Ad_Subcat3=ad_cat3.catcode and ad_cat3.subcatname=adv_subcat_mast.Adv_Subcat_Code and a.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code) as Adsubcat3,
	(select tbl_cat4.Cat_Name from tbl_cat4 where tbl_cat4.Cat_Code=a.Ad_Subcat4) as Adsubcat4,
	(select tbl_cat5.Cat_Name from tbl_cat5 where tbl_cat5.Cat_Code=a.Ad_subcat5) as Adsubcat5,
	/*dbo.FETCH_PACK(a.cio_booking_id) AS Package,*/
	case when CHARINDEX('','', a."Package_code")>0 then
		dbo.FETCH_PACK_new('''+ @compcode +''', a."Package_code" ) 
	else
		(select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=a."Package_code")
	end AS "Package",
	CASE '''+@dateformat+'''
	WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),a.Insertion_date,101)
	WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),a.Insertion_date,103)
	WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),a.Insertion_date,111) END as PubDate,
	a.No_of_insertion as noinsert,
	a.Paid_ins as Paidinsert,
	a.Ad_size_height as height,
	a.Ad_size_width as width,
	a.Total_area as Area,
	(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where a.Page_prem=ADVPOS_PREM_MAST.Premiumcode) as Pagepremium,
	(select advpos_type_mast.Pos_Type from advpos_type_mast where a.Page_position_code=advpos_type_mast.Pos_Type_Code) as Postprem,
	(select scheme_master.Scheme_Name from scheme_master where a.Scheme_type_code=scheme_master.scheme_id) as scheme,
	a.Rate_code as Ratecode,
	a.Card_rate as cardrate,
	a.Card_amount as cardamt,
	a.Contract_rate as contractrate,
	a.Deviation as Deviationamt,
	a.Deviation AS  "Deviation(%)",
	a.Agrred_rate as Aggrate,
	a.Agreed_amount as aggamt,
	(a.Card_amount - 
	case isnull(a.Agreed_amount,0)
	when 0 then a.Card_amount
	else a.Agreed_amount end)  as DiscAmt,
	a.Discount_per as Discper,
	dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1'') as  posamt,
	dbo.FETCH_RATAMT(a.cio_booking_id,''2'',''1'')  as  "pos(%)",
	round(((a.Special_disc_per * a.Total_area * a.Card_rate)/100),2) as Spdiscamt,
	a.Special_disc_per as Spdiscper,
	round(((a.Space_disc_per * a.Total_area * a.Card_rate)/100),2) as Spacedisc,
	a.Space_disc_per as Spacediscper,
	a.Special_charges as Specialcharge,
	isnull(a.ADD_AGENCY_COMM,''0'') as  "AgencyAddlTD(%)",
	isnull((isnull(a.Gross_amount,''0'')*isnull(a.ADD_AGENCY_COMM,''0'')/100),''0'') as AgencyAddlTDAmt,
	isnull(a.Gross_amount,''0'') as Grossamt,
	isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''3'' ),''0'')as  "RetTD(%)",
	isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''4'' ),''0'')as RetTDAmt,
	isnull(a.Trade_disc,''0'' )as "AgencyTD(%)",
	(isnull(a.Gross_amount,''0'')* isnull(a.Trade_disc,''0'' )/100 )as AgencyTDAmt,
	isnull(a.Bill_amount,''0'') as Billamt,

	isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''1'' ),''0'') as "RetComm(%)",
	isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''2'' ),''0'') as RetCommAmt,
	isnull((a.Bill_amount-isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''5'' ),''0'')  ),''0'') as ActualBusiness,
	(SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE a.Revenue_center=BRANCH_MST.Branch_Code )as Revcenter,
	UOM_MAST.Uom_Name  AS Uom,
	uom_mast.UOM_DESC as uomdesc
	,(select top 1 pub_cent_mast.Pub_Cent_name from pub_cent_mast where pub_cent_mast.Pub_cent_Code in(select pub_center from  BRANCH_MST WHERE a.branch=Branch_Name) ) as Printcenter
	,(SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as Branch
	,case '''+@base+'''
	when ''1'' then  AGENCY_MAST.Dist_Code
	when ''2'' then (select dist_mst.Dist_Name from dist_mst where dist_mst.Dist_Code in(select exec_mast.dist_code from exec_mast where  exec_mast.Exe_no=a.Executive_code )  )
	when ''3'' then (select dist_mst.Dist_Name from dist_mst where dist_mst.Dist_Code in(select RETAINERMASTER.Dist_Code from RETAINERMASTER where  RETAINERMASTER.Retain_Code= a.RETAINER )  ) end as District
	,case '''+@base+'''
	when ''1'' then (select taluka_mast.TALU_NAME  from taluka_mast where AGENCY_MAST.TALUKA=taluka_mast.TALU_CODE )
	when ''2'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select exec_mast.TALUKA from exec_mast where  exec_mast.Exe_no=a.Executive_code )  )
	when ''3'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select RETAINERMASTER.TALUKA from RETAINERMASTER where  RETAINERMASTER.Retain_Code= a.RETAINER )  ) end as Taluka
	,isnull(a.Page_no,0) as "Page_No"
	,CASHDISCOUNT as "Cash_Disc"
	,(select distinct "Box_Name" from box_mast where "Box_Code"=a."Box_code") as "BoxCode",
	a.Userid as USERID,(SELECT max(username) from login where com_code = a.Comp_code and userid=a.Userid) as USERNAME
,a.Bill_remarks as "BillRemark"
,a.caption as "CAPTION"
,tbl_booking_insert.BILL_NO as "Billno",
isnull((SELECT isnull(("Varient_Alias"),'''') FROM varient_mst where "Varient_Code"=a."Variant_code"),'''') as "VARIENT",
isnull((SELECT "Product_Name" FROM PRODUCT_MAST where "Product_Code"=a."Product_code" and "Comp_Code"=a."Comp_code"),'''') as PRODUCT,
isnull((SELECT "brand_alias" FROM brand_mst where "brand_code"=a."Brand_code"),'''') as BRAND
	FROM TBL_BOOKING_MAST a,AGENCY_MAST ,UOM_MAST,
	adv_cat_mast,adv_type_mast,
	TBL_BOOKING_insert
	WHERE a.Comp_code='''+@compcode+''' AND
	 UOM_MAST.Uom_Code=a.Uom_code and
	a.Agency_sub_code=AGENCY_MAST.code_subcode AND
	a.Ad_cat_code=adv_cat_mast.Adv_Cat_Code and
	a.Ad_type_code=adv_type_mast.Adv_Type_Code
	and adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
	a.cio_booking_id=tbl_booking_insert.Cio_Booking_Id'
	--and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
	--or  ('''+@chk_access+'''=''0'') )' 
	--

	if(@query4='' or @query4 is null)begin
		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' ) begin
			set @query4=' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 

		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' ) begin
			set @query4=' and a.Insertion_date  between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 
	end
	else begin
		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' ) begin
			set @query4=@query4+' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 

		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' ) begin
			set @query4=@query4+' and a.Insertion_date  between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 
	end
	if(@base='2')begin
		set @query4=@query4+' and (a.Executive_code is not null and a.Executive_code<>'''' and a.Executive_code !=''0'')  '
	end 

	if(@base='3')begin
		set @query4=@query4+' and (a.RETAINER is not null and a.RETAINER<>''''  and a.RETAINER !=''0'')  '
	end 

	/*if(@drpstatus is null or  @drpstatus = '') begin
		set @query4=@query4+' and lower(Insert_Status)!=''cancel'''
	end */

if(@drpstatus = '1') begin
		set @query4=@query4+' and lower(TBL_BOOKING_INSERT.Insert_Status)!=''hold'''
	end

if(@drpstatus = '2') begin
		set @query4=@query4+' and lower(TBL_BOOKING_INSERT.Insert_Status)!=''cancel'''
	end



	if(@insertstatus is not null and @insertstatus<>'') begin
		set @query4=@query4+' and lower(Insert_Status)='''+@insertstatus+''''
	end 


	IF(@publication IS NOT NULL) begin
		set @query4=@query4+' and TBL_BOOKING_insert.publication_Code='''+@publication+'''    '
	END 

	IF(@pub_cent IS NOT NULL) begin
		set @query4=@query4+'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
	END 

	IF(@branch IS NOT NULL  and @branch<>'') begin
		set @query4=@query4+'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
	END 

	IF(@edition IS NOT NULL  and @edition<>'') begin
		set @query4=@query4+'  and tbl_booking_insert.Edition_Code='''+@edition+''''
	END 
	
 
	IF(@region IS NOT NULL and @region <>'') begin
		--set @query4=@query4 +' and tbl_booking_insert.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+region +''')'
		set @query4=@query4 +' and agency_mast.region ='''+@region +''' '
	END 

	IF(@revcenter IS NOT NULL and @revcenter <>'') begin
		set @query4=@query4 +' and a.Revenue_center ='''+@revcenter+''''
	END 

	IF(@adtype IS NOT NULL and @adtype <>'') begin
		set @query4=@query4 + ' and a.Ad_type_code='''+@adtype+''''
	END 

	IF(@agencytype IS NOT NULL and @agencytype <>'') begin
		set @query4=@query4 + ' and a.Agency_type ='''+@agencytype+''''
	END 

	IF(@adcat IS NOT NULL and @adcat <>'') begin
		set @query4=@query4 + ' and a.Ad_cat_code ='''+@adcat+''''
	END 

	IF(@adsubcat IS NOT NULL and @adsubcat <>'') begin
		set @query4=@query4 + ' and a.Ad_sub_cat_code ='''+@adsubcat+''''
	END 

	IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'') begin
		set @query4=@query4 + ' and a.Ad_Subcat3 ='''+@adsubcat3+''''
	END 

	IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'') begin
		set @query4=@query4 + ' and a.Ad_Subcat4 ='''+@adsubcat4+''''
	END 

	IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'') begin
		set @query4=@query4 + ' and a.Ad_subcat5 ='''+@adsubcat5+''''
	END 

	IF(@package IS NOT NULL and @package <>'') begin
		set @query4=@query4 + ' and a.Package_code ='''+@package+''''
	END 

	IF(@scheme IS NOT NULL and @scheme <>'') begin
		set @query4=@query4 + ' and a.Scheme_type_code ='''+@scheme+''''
	END 

	IF(@agency IS NOT NULL and @agency <>'') begin
		set @query4=@query4 + ' and a.Agency_code ='''+@agency+''''
	END 

	IF(@client IS NOT NULL and @client  <>'') begin
		set @query4=@query4 + ' and a.Client_code ='''+@client+''''
	END 

	IF(@executive IS NOT NULL and @executive <>'') begin
		set @query4=@query4 + ' and a.Executive_code ='''+@executive+''''
	END 

	IF(@retainer IS NOT NULL and @retainer <>'') begin
		set @query4=@query4 + ' and a.RETAINER ='''+@retainer+''''
	END 

	IF(@product IS NOT NULL and @product <>'') begin
		set @query4=@query4 + ' and a.Product_code ='''+@product+''''
	END 

	IF(@brand IS NOT NULL and @brand <>'') begin
		set @query4=@query4 + ' and a.Brand_code ='''+@brand+''''
	END 

	IF(@varient IS NOT NULL and @varient <>'') begin
		set @query4=@query4 + ' and a.Variant_code ='''+@varient+''''
	END 

	IF(@pagetype IS NOT NULL and @pagetype <>'') begin
		set @query4=@query4 + ' and a.Page_type_code ='''+@pagetype+''''
	END 

	IF(@pageprem IS NOT NULL and @pageprem <>'') begin
		set @query4=@query4 + ' and a.Page_prem ='''+@pageprem+''''
	END 

	IF(@postprem IS NOT NULL and @postprem <>'') begin
		set @query4=@query4 + ' and a.Page_position_code ='''+@postprem+''''
	END 

	IF(@rostatus IS NOT NULL and @rostatus <>'') begin
		set @query4=@query4 + ' and a.ro_status ='''+@rostatus+''''
	END 

	IF(@booktype IS NOT NULL and @booktype <>'') begin
		set @query4=@query4 + ' and a.Booking_type ='''+@booktype+''''
	END 

	IF(@contractname  IS NOT NULL and @contractname  <>'') begin
		set @query4=@query4 + ' and a.Contract_name ='''+@contractname +''''
	END 

	IF(@suppliment  IS NOT NULL and @suppliment  <>'') begin
		set @query4=@query4 + ' and tbl_booking_insert.Supp_Code ='''+@suppliment+''''
	END 

	IF(@ratetype  IS NOT NULL and @ratetype  <>'') begin
		set @query4=@query4 + ' and a.Rate_code ='''+@ratetype+''''
	END 

	IF(@p_baxcode IS NOT NULL and @p_baxcode <>'') begin
		set @query4=@query4 + ' and a.Box_code ='''+@p_baxcode+''''
	END 

	IF(@city  IS NOT NULL and @city  <>'') begin
		if(@base='1')begin
			set @query4=@query4 + ' and AGENCY_MAST.City_Code ='''+@city+''''
		end 

		if(@base='2')begin
			set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code ='''+@city+''' )'
		end 

		if(@base='3')begin
			set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.City_Code='''+@city+''')'
		end 
	END 

	IF(@zone  IS NOT NULL and @zone  <>'') begin
		if(@base='1')begin
			set @query4=@query4 + ' and AGENCY_MAST.zone_code ='''+@zone+''''
		end 

		if(@base='2')begin
			set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= '''+@zone+''') )'
		end 

		if(@base='3')begin
			set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Zone_Code='''+@zone+''')'
		end 
	END 

	IF(@district  IS NOT NULL and @district  <>'') begin
		if(@base='1')begin
			set @query4=@query4 + ' and AGENCY_MAST.Dist_Code ='''+@district+''''
		end 

		if(@base='2')begin
			set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code ='''+@district+''' )'
		end 

		if(@base='3')begin
			set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Dist_Code='''+@district+''')'
		end 
	END 

	IF(@state  IS NOT NULL and @state  <>'') begin
		if(@base='1')begin
			set @query4=@query4 + ' and AGENCY_MAST.State_Code ='''+@state+''''
		end 

		if(@base='2')begin
			set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code ='''+@state+''' )'
		end 

		if(@base='3')begin
			set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.State_Code='''+@state+''')'
		end 
	END 

	IF(@taluka  IS NOT NULL and @taluka  <>'') begin
		if(@base='1')begin	
			set @query4=@query4 + ' and AGENCY_MAST.TALUKA='''+@taluka+'''  '
		end 

		if(@base='2')begin
			set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA ='''+@taluka+''' )'
		end 

		if(@base='3')begin
			set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.TALUKA='''+@taluka+''')'
		end 
	END 

	set @query4=@query4 + ' order by a.cio_booking_id'
	PRINT 'LL'
	print(@query1)
print(@query4)
	
	exec(@query1+@query4)

	--print(@query1)
	--exec(@query1)
end 

else if(@adcheck=2)begin
open c2
fetch next from c2 into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME

print(@@FETCH_STATUS)
while @@FETCH_STATUS=0 begin
print('prachi')
insert into #temp_ad_bills_report select * from dbo.FUN_BILL_INSERT(@compcode,@v2_CIOID,@v2_BILLNO,@prefer,@dateformat,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME,@base )  

fetch next from c2 into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME

end
close c2


set @query2='select CIOID AS "CIOID",BILLNO AS "Billno" ,AGENCY AS "Agency", CLIENT AS "Client" ,
RONO  AS "RoNo.",
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),RODATE,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),RODATE,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),RODATE,111) END AS "Ro.Date",
EXECUTIVE  AS "Executive",RETAINER  AS "Retainer" ,BOOKTYPE as "BookType",COLOR as "Color",ADCAT as "Adcat",
ADSUBCAT as "Adsubcat",ADSUBCAT3 as "Adsubcat3",ADSUBCAT4  as "Adsubcat4",ADSUBCAT5 as "Adsubcat5",PACKAG AS "Package",
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),BILLDATE,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),BILLDATE,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),BILLDATE,111) END AS "BillDate",
NOINSERT as "noinsert",PAIDINSERT as "Paidinsert" ,HEIGHT as "height",WIDTH as "width",AREA as "Area",PAGEPREMIUM as "Pagepremium",POSTPREM as "Postprem",
SCHEME as "scheme",RATECOD as "Ratecode",CARDRATE as "cardrate",CARDAMT as "cardamt",
CONTRACTRATE as "contractrate",DEVIATIONAMT as "Deviationamt",DEVIATIONPER AS "Deviation(%)",
AGGRATE as "Aggrate",AGGAMT as "aggamt",DISCAMT as "DiscAmt",DISCPER as "Discper",
POSAMT as  "posamt",POSPER as "pos(%)",SPDISCAMT as "Spdiscamt",
SPDISCPER as "Spdiscper",SPACEDISC as "Spacedisc",SPACEDISCPER as "Spacediscper",SPECIALCHARGE as "Specialcharge",AGENCYADDLTDPER  as "AgencyAddlTD(%)",
AGENCYADDLTDAMT as "AgencyAddlTDAmt",GROSSAMT as "Grossamt",
RETTDPER as "RetTD(%)",RETTDAMT as "RetTDAmt",AGENCYTDPER as "AgencyTD(%)",AGENCYTDAMT as "AgencyTDAmt",BILLAMT as "Billamt",
RETCOMMPER as "RetComm(%)",RETCOMMAMT as "RetCommAmt",ACTUALBUSINESS as "ActualBusiness",
REVCENTER as "Revcenter",UOM AS "Uom",UOMDESC as "uomdesc"
,PUB_CENT_NAME as "Printcenter"
,BRANCH_NAME  as "Branch"
,DIST_NAME as "District"
,TALU_NAME as "Taluka"
,PAGE_NO as "Page_No"
,BILL_REMARK as "BillRemark"
,CAPTION as "CAPTION",
isnull((SELECT isnull(("Varient_Alias"),'''') FROM varient_mst where "Varient_Code"=#temp_ad_bills_report."VARIENT_NAME"),'''') as "VARIENT",
isnull((SELECT "Product_Name" FROM PRODUCT_MAST where "Product_Code"=#temp_ad_bills_report."PRIPROCTG" and "Comp_Code"=#temp_ad_bills_report."Comp_code"),'''') as PRODUCT,
isnull((SELECT "brand_alias" FROM brand_mst where "brand_code"=#temp_ad_bills_report."Brand_code"),'''') as BRAND
from #temp_ad_bills_report where'

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL ) begin
	set @query4= '  BILLDATE between  '''+@fromdate +''' and  '''+@dateto+''' '
END 

IF(@publication IS NOT NULL and @publication<>'') begin
	set @query4=@query4+ ' and PRIPUB='''+@publication+''''
END 

IF(@pub_cent IS NOT NULL and @pub_cent<>'')	begin
	set @query4=@query4+ '   and PUB_CENT_CODE='''+@pub_cent+''''
END 

IF(@edition IS NOT NULL and @edition<>'')begin
	set @query4=@query4+ '  and PEDITION='''+@edition+''''
END 

IF(@branch IS NOT NULL and @branch<>'')begin
	set @query4=@query4+ '  and  BRANCH_NAME ='''+@branch+''' '
END 

IF(@region IS NOT NULL and @region<>'') begin
	set @query4=@query4 +' and REGION='''+@region +''''
END 

IF(@adtype IS NOT NULL and @adtype<>'') begin
	set @query4=@query4 + ' and PADTYPE='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype<>'') begin
	set @query4=@query4 + ' and AGENCY_TYPE_CODE= '''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat<>'') begin
	set @query4=@query4 + ' and PRIADCTG='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat<>'') begin
	set @query4=@query4 + ' and SECADCTG ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3<>'') begin
	set @query4=@query4 + ' and AD_SUBCAT3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4<>'') begin
	set @query4=@query4 + ' and AD_SUBCAT4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5<>'') begin
	set @query4=@query4 + ' and AD_SUBCAT5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package<>'') begin
	set @query4=@query4 + ' and PACKAGE_CODE='''+@package+''''
END 

IF(@agency IS NOT NULL and @agency<>'') begin
	set @query4=@query4 + ' and AG_MAIN_CODE ='''+@agency +''''
END 

IF(@client IS NOT NULL and @client<>'') begin
	set @query4=@query4 + ' and CLIENTCD='''+@client +''''
END 

IF(@executive IS NOT NULL and @executive<>'') begin
	set @query4=@query4 + ' and EXECUTIVE_NAME='''+@executive+''''
END 

IF(@product IS NOT NULL and @product<>'') begin
	set @query4=@query4 + ' and PRIPROCTG='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand<>'') begin
	set @query4=@query4 + ' and BRAND_CODE='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient<>'') begin
	set @query4=@query4 + ' and   VARIENT_NAME='''+@varient+''''
END 

IF(@pageprem IS NOT NULL and @pageprem<>'') begin
	set @query4=@query4 + ' and PAGE_PREM ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem<>'') begin
	set @query4=@query4 + ' and PAGE_POST ='''+@postprem+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'') begin
	set @query4=@query4 + ' and CONTRACT_NAME ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment<>'') begin
	set @query4=@query4 + ' and SUPP_CODE='''+@suppliment+''''
END 

IF(@retainer IS NOT NULL and @retainer<>'') begin
	set @query4=@query4 + ' and RETAINER_CODE='''+@retainer+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype<>'') begin
	set @query4=@query4 + ' and RATECD ='''+@ratetype+''''
END 

IF(@scheme IS NOT NULL and @scheme<>'') begin
	set @query4=@query4 + ' and PSCHEME='''+@scheme+''''
END 

IF(@revcenter IS NOT NULL and @revcenter<>'') begin
	set @query4=@query4 +' and REVENUE_CENTER='''+@revcenter+''''
END 

IF(@rostatus IS NOT NULL and @rostatus<>'') begin
	set @query4=@query4 + ' and RO_STATUS='''+@rostatus+''''
END 

IF(@pagetype IS NOT NULL and @pagetype<>'') begin
	set @query4=@query4 + ' and PAGE_TYPE ='''+@pagetype+''''
END 

IF(@booktype IS NOT NULL and @booktype<>'') begin
	set @query4=@query4 + ' and BOOKING_TYPE='''+@booktype+''''
END 

IF(@city  IS NOT NULL and @city<>'') begin
	set @query4=@query4 + ' and CITY_CODE ='''+@city+''''
END 

IF(@zone  IS NOT NULL and @zone<>'') begin
	set @query4=@query4 + ' and ZONE_CODE ='''+@zone+''''
end 

IF(@district  IS NOT NULL and @district<>'') begin
	set @query4=@query4 + ' and DIST_CODE ='''+@district+''''
end 

IF(@state  IS NOT NULL and @state<>'') begin
	set @query4=@query4 + ' and STATE_CODE ='''+@state+''''
end 

IF(@taluka  IS NOT NULL and @taluka<>'') begin
	set @query4=@query4 + ' and PTALUKA='''+@taluka+'''  '
end 


if(@base='2')begin
	set @query4=@query4 +' and (EXECUTIVE_NAME   is not null and EXECUTIVE_NAME !=''0'')  '
end 

if(@base='3')begin
	set @query4=@query4 +' and (RETAINER_CODE  is not null  and RETAINER_CODE  !=''0'')  '
end 



set @query4=@query4 + ' order by CIOID'


print(@query2+@query4)
exec(@query2+@query4)
end 

else if(@adcheck=3) begin
set @query3='SELECT  TBL_BOOKING_MAST.cio_booking_id AS CIOID,
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),TBL_BOOKING_MAST.date_time,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),TBL_BOOKING_MAST.date_time,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),TBL_BOOKING_MAST.date_time,111) END as BookDate,
AGENCY_MAST.Agency_Name AS Agency,
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS Client,
RO_No AS "RoNo.",
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),RO_Date,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),RO_Date,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),RO_Date,111) END AS "Ro.Date",
(select EXEC_MAST.Exec_name from exec_mast where tbl_booking_mast.Executive_code=exec_mast.Exe_no) AS Executive,
(select RETAINERMASTER.Retain_Name  FROM  RETAINERMASTER where RETAINERMASTER.Retain_Code=tbl_booking_mast.RETAINER ) AS Retainer,
case tbl_booking_mast.Booking_type
when ''1'' then ''Barter''
when ''2'' then ''FMG''
when ''3'' then ''Normal''
when ''4'' then ''InHouse''
when ''5'' then ''Complimentary''
else ''Normal'' end as BookType,
(select col_mast.Col_Alias from col_mast where tbl_booking_insert.Col_Code =col_mast.Col_Code) as Color,
adv_cat_mast.Adv_Cat_Name as Adcat,
(select adv_subcat_mast.Adv_Subcat_Name from adv_subcat_mast where tbl_booking_mast.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code)as Adsubcat,
(select ad_cat3.catname from ad_cat3,adv_subcat_mast  where tbl_booking_mast.Ad_Subcat3=ad_cat3.catcode and ad_cat3.subcatname=adv_subcat_mast.Adv_Subcat_Code and tbl_booking_mast.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code) as Adsubcat3,
(select tbl_cat4.Cat_Name from tbl_cat4,adv_subcat_mast where tbl_booking_mast.Ad_Subcat4=tbl_cat4.Cat_Code and tbl_cat4.Sub_Cat_Name=adv_subcat_mast.Adv_Subcat_Code and tbl_booking_mast.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code) as Adsubcat4,
(select tbl_cat5.Cat_Name from tbl_cat5,adv_subcat_mast where tbl_booking_mast.Ad_subcat5=tbl_cat5.Cat_Code and tbl_cat5.Sub_Cat_Name=adv_subcat_mast.Adv_Subcat_Code and tbl_booking_mast.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code) as Adsubcat5,
case when CHARINDEX('','', TBL_BOOKING_MAST."Package_code")>0 then
	dbo.FETCH_PACK_new('''+ @compcode +''', TBL_BOOKING_MAST."Package_code" ) 
else
	(select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=TBL_BOOKING_MAST."Package_code")
end AS "Package",
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),tbl_booking_insert.Insert_Date,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),tbl_booking_insert.Insert_Date,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),tbl_booking_insert.Insert_Date,111) END as PubDate,
 tbl_booking_insert.Height as "height",
 tbl_booking_insert.Width  as "width",
tbl_booking_insert.Size_Book as Area,
(select ADVPOS_PREM_MAST.premiumname from advpos_prem_mast where tbl_booking_insert.Premium1=ADVPOS_PREM_MAST.Premiumcode) as Pagepremium,
(select advpos_type_mast.Pos_Type from advpos_type_mast where tbl_booking_insert.Page_Post=advpos_type_mast.Pos_Type_Code) as Postprem,
(select scheme_master.Scheme_Name from scheme_master where tbl_booking_mast.Scheme_type_code=scheme_master.scheme_id) as scheme,
tbl_booking_mast.Rate_code as Ratecode,
tbl_booking_mast.Card_rate as cardrate,
tbl_booking_mast.Card_rate*tbl_booking_insert.Size_Book as cardamt,
tbl_booking_mast.Contract_rate as contractrate,
TBL_BOOKING_mast.Deviation as Deviationamt,
TBL_BOOKING_mast.Deviation AS  "Deviation(%)",
tbl_booking_mast.Agrred_rate as Aggrate,
tbl_booking_insert.Agreed_Rate  as aggamt,
((tbl_booking_mast.Card_rate*tbl_booking_insert.Size_Book) - 
case isnull(tbl_booking_insert.Agreed_Rate,0)
when 0 then (tbl_booking_mast.Card_rate*tbl_booking_insert.Size_Book)
else tbl_booking_insert.Agreed_Rate end)  as DiscAmt,
tbl_booking_mast.Discount_per as Discper,
dbo.FETCH_RATAMT(tbl_booking_mast.cio_booking_id ,''1'',''1'') as  posamt,
dbo.FETCH_RATAMT(tbl_booking_mast.cio_booking_id,''2'',''1'')  as  "pos(%)",
round(((tbl_booking_mast.Special_disc_per * tbl_booking_insert.Size_Book * tbl_booking_mast.Card_rate)/100),2) as Spdiscamt,
tbl_booking_mast.Special_disc_per as Spdiscper,
round(((tbl_booking_mast.Space_disc_per * tbl_booking_insert.Size_Book * tbl_booking_mast.Card_rate)/100),2) as Spacedisc,
tbl_booking_mast.Space_disc_per as Spacediscper,
tbl_booking_mast.Special_charges as Specialcharge,
isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'') as  "AgencyAddlTD(%)",
isnull((isnull(tbl_booking_insert.Gross_Rate ,''0'')*isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'')/100),''0'') as AgencyAddlTDAmt,
isnull(tbl_booking_insert.Gross_Rate,''0'') as Grossamt,
isnull(dbo.fun_actual('''+ @compcode +''',isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),isnull(tbl_booking_mast.RETAINER,''0''),isnull(tbl_booking_insert.Gross_Rate,''0''),'''+@prefer+''',''3'' ),''0'')as  "RetTD(%)",
isnull(dbo.fun_actual('''+ @compcode +''',isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),isnull(tbl_booking_mast.RETAINER,''0''),isnull(tbl_booking_insert.Gross_Rate,''0''),'''+@prefer+''',''4'' ),''0'')as RetTDAmt,
isnull(tbl_booking_mast.Trade_disc,''0'' )as "AgencyTD(%)",
(isnull(tbl_booking_insert.Gross_Rate,''0'')* isnull(tbl_booking_mast.Trade_disc,''0'' )/100 )as AgencyTDAmt,
isnull(TBL_BOOKING_INSERT.Bill_Amt,''0'') as Billamt,
isnull(dbo.fun_actual('''+ @compcode +''',isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),isnull(tbl_booking_mast.RETAINER,''0''),isnull(tbl_booking_insert.Gross_Rate,''0''),'''+@prefer+''',''1'' ),''0'') as "RetComm(%)",
isnull(dbo.fun_actual('''+ @compcode +''',isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),isnull(tbl_booking_mast.RETAINER,''0''),isnull(tbl_booking_insert.Gross_Rate,''0''),'''+@prefer+''',''2'' ),''0'') as RetCommAmt,
isnull((  isnull(TBL_BOOKING_INSERT.Bill_Amt,''0'')-isnull(dbo.fun_actual('''+ @compcode +''',isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),isnull(tbl_booking_mast.RETAINER,''0''),isnull(tbl_booking_insert.Gross_Rate,''0''),'''+@prefer+''',''5'' ),''0'')  ),''0'') as ActualBusiness,
(SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE tbl_booking_mast.Revenue_center=BRANCH_MST.Branch_Code )as Revcenter
,UOM_MAST.Uom_Name  AS Uom,
pub_mast.Pub_Name as publication,
TBL_BOOKING_INSERT.Edition as Edition,
uom_mast.UOM_DESC as uomdesc
,(select top 1 pub_cent_mast.Pub_Cent_name from pub_cent_mast where pub_cent_mast.Pub_cent_Code in(select pub_center from  BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name) ) as Printcenter
,tbl_booking_mast.branch as Branch
,case '''+@base+'''
when ''1'' then  AGENCY_MAST.Dist_Code
when ''2'' then (select dist_mst.Dist_Name from dist_mst where dist_mst.Dist_Code in(select exec_mast.dist_code from exec_mast where  exec_mast.Exe_no=tbl_booking_mast.Executive_code )  )
when ''3'' then (select dist_mst.Dist_Name from dist_mst where dist_mst.Dist_Code in(select RETAINERMASTER.Dist_Code from RETAINERMASTER where  RETAINERMASTER.Retain_Code= tbl_booking_mast.RETAINER )  ) end as District
,case '''+@base+'''
when ''1'' then (select taluka_mast.TALU_NAME  from taluka_mast where AGENCY_MAST.TALUKA=taluka_mast.TALU_CODE )
when ''2'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select exec_mast.TALUKA from exec_mast where  exec_mast.Exe_no=tbl_booking_mast.Executive_code )  )
when ''3'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select RETAINERMASTER.TALUKA from RETAINERMASTER where  RETAINERMASTER.Retain_Code= tbl_booking_mast.RETAINER )  ) end as Taluka,
tbl_booking_insert.Page_No as "Page_No" '

set @queryp='
,CASHDISCOUNT as "Cash_Disc"
,Insert_Status as "Status"
,(select distinct "Box_Name" from box_mast where "Box_Code"=TBL_BOOKING_MAST."Box_code") as "BoxCode",
TBL_BOOKING_MAST.Userid as USERID,
(SELECT max(username) from login where com_code = TBL_BOOKING_MAST.Comp_code and userid=TBL_BOOKING_MAST.Userid) as USERNAME
,TBL_BOOKING_MAST.Bill_remarks as "BillRemark"
,TBL_BOOKING_MAST.caption as "CAPTION"
,tbl_booking_insert.BILL_NO as "Billno",
isnull((SELECT isnull(("Varient_Alias"),'''') FROM varient_mst where "Varient_Code"=TBL_BOOKING_MAST."Variant_code"),'''') as "VARIENT",
isnull((SELECT "Product_Name" FROM PRODUCT_MAST where "Product_Code"=TBL_BOOKING_MAST."Product_code" and "Comp_Code"=TBL_BOOKING_MAST."Comp_code"),'''') as PRODUCT,
isnull((SELECT "brand_alias" FROM brand_mst where "brand_code"=TBL_BOOKING_MAST."Brand_code"),'''') as BRAND
FROM TBL_BOOKING_MAST,AGENCY_MAST ,uom_mast,
adv_cat_mast,adv_type_mast,pub_mast,TBL_BOOKING_insert'

set @query4=' WHERE TBL_BOOKING_MAST.Comp_code='''+@compcode+''' AND
UOM_MAST.Uom_Code=TBL_BOOKING_MAST.Uom_code and
TBL_BOOKING_MAST.Agency_sub_code=AGENCY_MAST.code_subcode AND
tbl_booking_insert.Ad_Cat=adv_cat_mast.Adv_Cat_Code and
tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code
and adv_type_mast.Adv_Type_Code=adv_cat_mast.Adv_Type and
pub_mast.Pub_Code=TBL_BOOKING_insert.publication_Code and
tbl_booking_mast.cio_booking_id=tbl_booking_insert.Cio_Booking_Id '
--and ((tbl_booking_insert.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
--or  ('''+@chk_access+'''=''0'') )' 

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL) begin
	set @query4=@query4+' and tbl_booking_insert.Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
END

IF(@p_baxcode IS NOT NULL and @p_baxcode <>'') begin
	set @query4=@query4 + ' and tbl_booking_mast.Box_code ='''+@p_baxcode+''''
END 

if(@base='2')begin
	set @query4=@query4 +' and (tbl_booking_mast.Executive_code is not null and tbl_booking_mast.Executive_code !=''0'')  '
end 

if(@base='3')begin
	set @query4=@query4 +' and (tbl_booking_mast.retainer IS NOT NULL and retainer <>''''  and tbl_booking_mast.RETAINER !=''0'')  '
end 

/*
if(@drpstatus is null or  @drpstatus = '') begin
	set @query4=@query4+' and lower(Insert_Status)!=''cancel'''
end */

if(@drpstatus = '1') begin
		set @query4=@query4+' and lower(TBL_BOOKING_INSERT.Insert_Status)!=''hold'''
	end

if(@drpstatus = '2') begin
		set @query4=@query4+' and lower(TBL_BOOKING_INSERT.Insert_Status)!=''cancel'''
	end




if(@insertstatus is not null and @insertstatus<>'' ) begin
	set @query4=@query4+' and lower(Insert_Status)='''+@insertstatus+''''
end 





IF(@publication IS NOT NULL) begin
	set @query4=@query4 +' and TBL_BOOKING_insert.publication_Code='''+@publication+'''    '
END 

/*IF(@pub_cent IS NOT NULL and @pub_cent <>'')
begin
--set @query4=@query4 +'  and tbl_booking_insert.Pub_Cent_Code='''+@pub_cent+''''
set @query4=@query4+'  and TBL_BOOKING_MAST.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE TBL_BOOKING_MAST.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code='''+@pub_cent+'''))'

END 
IF(@branch IS NOT NULL and @branch<>'')
begin
set @query4=@query4 +'  and tbl_booking_mast.branch ='''+@branch+''''
END 

*/

IF(@pub_cent IS NOT NULL) begin
	set @query4=@query4+'  and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
END 


IF(@branch IS NOT NULL  and @branch<>'') begin
	set @query4=@query4+'  and TBL_BOOKING_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
END 


IF(@edition IS NOT NULL and @edition<>'') begin
	set @query4=@query4 +'  and tbl_booking_insert.Edition_Code='''+@edition+''''
END 



IF(@region IS NOT NULL and @region <>'') begin
	--set @query4=@query4  +' and tbl_booking_insert.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+@region +''')'
	set @query4=@query4  +' and agency_mast.region ='''+@region+''''
END 

IF(@revcenter IS NOT NULL and @revcenter <>'') begin
	set @query4=@query4  +' and tbl_booking_mast.Revenue_center ='''+@revcenter+''''
END 

IF(@adtype IS NOT NULL and @adtype <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_type_code='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Agency_type ='''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_insert.Ad_Cat ='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_sub_cat_code ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_Subcat3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_Subcat4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_subcat5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Package_code ='''+@package+''''
END 

IF(@scheme IS NOT NULL and @scheme <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Scheme_type_code ='''+@scheme+''''
END 

IF(@agency IS NOT NULL and @agency <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Agency_code ='''+@agency+''''
END 

IF(@client IS NOT NULL and @client  <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Client_code ='''+@client+''''
END 

IF(@executive IS NOT NULL and @executive <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Executive_code ='''+@executive+''''
END 

IF(@retainer IS NOT NULL and @retainer <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.RETAINER ='''+@retainer+''''
END 

IF(@product IS NOT NULL and @product <>'') begin
	set @query4=@query4 + ' and TBL_BOOKING_MAST.Product_code ='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Brand_code ='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Variant_code ='''+@varient+''''
END 

IF(@pagetype IS NOT NULL and @pagetype <>'') begin
	set @query4=@query4  + ' and TBL_BOOKING_MAST.Page_type_code ='''+@pagetype+''''
END 

IF(@pageprem IS NOT NULL and @pageprem <>'') begin
	set @query4=@query4 + ' and TBL_BOOKING_insert.Premium1 ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem <>'') begin
	set @query4=@query4 + ' and TBL_BOOKING_insert.Page_Post ='''+@postprem+''''
END 

IF(@rostatus IS NOT NULL and @rostatus <>'') begin
	set @query4=@query4 + ' and TBL_BOOKING_MAST.ro_status ='''+@rostatus+''''
END 

IF(@booktype IS NOT NULL and @booktype <>'') begin
	set @query4=@query4 + ' and TBL_BOOKING_MAST.Booking_type ='''+@booktype+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'') begin
	set @query4=@query4 + ' and TBL_BOOKING_MAST.Contract_name ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment  <>'') begin
	set @query4=@query4 + ' and tbl_booking_insert.Supp_Code ='''+@suppliment+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype  <>'') begin
	set @query4=@query4 + ' and tbl_booking_MAST.Rate_code ='''+@ratetype+''''
END 

IF(@city  IS NOT NULL and @city  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.City_Code ='''+@city+''''
	end 

	if(@base='2')begin
		set @query4=@query4 + ' and tbl_booking_mast.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code ='''+@city+''' )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.City_Code='''+@city+''')'
	end 
END 

IF(@zone  IS NOT NULL and @zone  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.zone_code ='''+@zone+''''
	end 

	if(@base='2')begin
		set @query4=@query4 + ' and tbl_booking_mast.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= '''+@zone+''') )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Zone_Code='''+@zone+''')'
	end 
END 

IF(@district  IS NOT NULL and @district  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.Dist_Code ='''+@district+''''
	end 

	if(@base='2')begin
		set @query4=@query4 + ' and tbl_booking_mast.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code ='''+@district+''' )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Dist_Code='''+@district+''')'
	end
END 

IF(@state  IS NOT NULL and @state  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.State_Code ='''+@state+''''
	end 

	if(@base='2')begin
		set @query4=@query4 + ' and tbl_booking_mast.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code ='''+@state+''' )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.State_Code='''+@state+''')'
	end
END 

IF(@taluka  IS NOT NULL and @taluka  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.TALUKA='''+@taluka+'''  '
	end 

	if(@base='2')begin
		set @query4=@query4 + ' and tbl_booking_mast.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA ='''+@taluka+''' )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and tbl_booking_mast.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.TALUKA='''+@taluka+''')'
	end
END 

set @query4=@query4 + ' order by tbl_booking_insert.Insert_Date ,TBL_BOOKING_MAST.cio_booking_id'

print(@query3+@queryp+@query4)
exec(@query3+@queryp+@query4)

end end

else

if(@adcheck=1) begin
print('prachi')
print(@adsubcat3)
print(@adsubcat4)
set @query1='SELECT
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),a.date_time,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),a.date_time,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),a.date_time,111) END as "Date",
sum(a.No_of_insertion) as noinsert,
sum(a.Paid_ins) as Paidinsert,sum(a.Total_area) as Area,
sum(a.Card_amount) as cardamt,
sum(a.Deviation) as Deviationamt,
round(((isnull(sum(a.Deviation),0)*100)/sum(a.Card_amount)),2) AS  "Deviation(%)",
sum(a.Agreed_amount) as aggamt,
(sum(a.Card_amount)-
case isnull(sum(a.Agreed_amount),0)
when 0 then sum(a.Card_amount)
else sum(a.Agreed_amount) end)  as DiscAmt,
round((((sum(a.Card_amount)- 
case isnull(sum(a.Agreed_amount),0)
when 0 then sum(a.Card_amount)
else sum(a.Agreed_amount) end ) *100) /sum(a.Card_amount)),2)  as Discper,
sum(dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1'')) as  posamt,
round(((sum(dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1''))*100)/sum(a.Card_amount)),2)   as  "pos(%)",
sum(a.Special_disc_per * a.Total_area * a.Card_rate/100) as Spdiscamt,
round(((sum(a.Special_disc_per * a.Total_area * a.Card_rate/100)*100)/sum(a.Card_amount)),2)  as Spdiscper,
sum(a.Space_disc_per * a.Total_area * a.Card_rate/100) as Spacedisc,
round(((sum(a.Space_disc_per * a.Total_area * a.Card_rate/100) *100)/sum(a.Card_amount)),2) as Spacediscper,
sum(a.Special_charges) as Specialcharge,
round(((sum(isnull((isnull(a.Gross_amount,''0'')*isnull(a.ADD_AGENCY_COMM,''0'')/100),''0''))*100)/(sum(a.Card_amount)+sum(dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1''))+sum(a.Special_charges)-sum(a.Deviation)-(sum(a.Card_amount)- 
case isnull(sum(a.Agreed_amount),0)
when 0 then sum(a.Card_amount)
else sum(a.Agreed_amount) end) -sum(a.Space_disc_per * a.Total_area * a.Card_rate/100)-sum(a.Special_disc_per * a.Total_area * a.Card_rate/100))),2) as  "AgencyAddlTD(%)",
sum(isnull((isnull(a.Gross_amount,''0'')*isnull(a.ADD_AGENCY_COMM,''0'')/100),''0'')) as AgencyAddlTDAmt,
sum(isnull(a.Gross_amount,''0'')) as Grossamt,
round(((sum(isnull(dbo.fun_actual('''+@compcode+''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''4'' ),''0''))*100)/sum(isnull(a.Gross_amount,''0''))),2) as  "RetTD(%)",
sum(isnull(dbo.fun_actual('''+@compcode+''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''4'' ),''0''))as RetTDAmt,
round(((sum((isnull(a.Gross_amount,''0'')* isnull(a.Trade_disc,''0'' )/100) )*100)/(sum(a.Card_amount)+sum(dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1''))+sum(a.Special_charges)-sum(a.Deviation)-(sum(a.Card_amount)- 
case isnull(sum(a.Agreed_amount),0)
when 0 then sum(a.Card_amount)
else sum(a.Agreed_amount)end) -sum(a.Space_disc_per * a.Total_area * a.Card_rate/100)-sum(a.Special_disc_per * a.Total_area * a.Card_rate/100))),2)as "AgencyTD(%)",
sum((isnull(a.Gross_amount,''0'')* isnull(a.Trade_disc,''0'' )/100) )as AgencyTDAmt,
sum(isnull(a.Bill_amount,''0'')) as Billamt,
round(((sum(isnull(dbo.fun_actual('''+@compcode+''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''2'' ),''0''))*100)/sum(isnull(a.Gross_amount,''0''))),2) as "RetComm(%)",
sum(isnull(dbo.fun_actual('''+@compcode+''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''2'' ),''0'')) as RetCommAmt,
sum(isnull((a.Bill_amount-isnull(dbo.fun_actual('''+@compcode+''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''5'' ),''0'')  ),''0'') )as ActualBusiness
FROM TBL_BOOKING_MAST a,
agency_mast
WHERE a.Comp_code='''+@compcode+''' AND
a.Agency_sub_code=AGENCY_MAST.code_subcode' 
PRINT 'SSK'
PRINT @QUERY1

if(@query4='' or @query4 is null) begin

	IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' ) begin
		set @query4=' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
	END 


	IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' ) begin
		set @query4=' and a.Insertion_date  between  '''+@fromdate +''' and  '''+@dateto+''' '
	END 

end
else begin 

	IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' ) begin
		set @query4=@query4+' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
	END 

	IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' ) begin
		set @query4=@query4+' and a.Insertion_date  between  '''+@fromdate +''' and  '''+@dateto+''' '
	END 

end
/*if(@chk_access='1')begin
	set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where a.cio_booking_id=b.Cio_Booking_Id and b.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''')) ';
end 
*/
if(@base='2')begin
	set @query4=@query4+' and (a.Executive_code is not null and a.Executive_code !=''0'')  '
end 

if(@base='3')begin
	set @query4=@query4+' and (a.retainer IS NOT NULL and retainer <>''  and a.RETAINER !=''0'')  '
end 

/*
if(@drpstatus is null or  @drpstatus = '') begin
	set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where a.cio_booking_id=b.Cio_Booking_Id AND lower(Insert_Status)!='''+'cancel'+''' )'
end 
*/

if(@drpstatus = '1') begin
		set @query4=@query4+' and  a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where a.cio_booking_id=b.Cio_Booking_Id AND lower(Insert_Status)!=''hold'''
	end

if(@drpstatus = '2') begin
		set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where a.cio_booking_id=b.Cio_Booking_Id AND lower(Insert_Status)!=''cancel'''
	end



if(@insertstatus is not null and @insertstatus<>'') begin
	set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where a.cio_booking_id=b.Cio_Booking_Id AND lower(Insert_Status)='''+@insertstatus+''' )';
end 


IF(@publication IS NOT NULL) begin
	set @query4=@query4+'  and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.publication_Code='''+@publication+''' )    '
END 

/*
IF(@pub_cent IS NOT NULL and @pub_cent <>'') begin
	--set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Pub_Cent_Code='''+@pub_cent+''' )  '
	set @query4=@query4+'  and a.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE a.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code='''+@pub_cent+'''))'
END 
IF(@branch IS NOT NULL and @branch<>'') begin
	set @query4=@query4+' and a.branch ='''+@branch+''''
END */



IF(@pub_cent IS NOT NULL) begin
	set @query4=@query4+'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
END 


IF(@branch IS NOT NULL  and @branch<>'') begin
	set @query4=@query4+'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
END 


IF(@edition IS NOT NULL and @edition<>'') begin
	set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Edition_Code='''+@edition+''' )'
END 



IF(@region IS NOT NULL and @region <>'') begin
	--set @query4=@query4 +'  and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+@region +''') )'
	set @query4=@query4 +'  and agency_mast.region ='''+@region+''''
END 

IF(@suppliment  IS NOT NULL and @suppliment  <>'') begin
	set @query4=@query4 + '  and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Supp_Code ='''+@suppliment+''' )'
END 


IF(@revcenter IS NOT NULL and @revcenter <>'') begin
	set @query4=@query4 +' and a.Revenue_center ='''+@revcenter+''''
END 

IF(@adtype IS NOT NULL and @adtype <>'') begin
	set @query4=@query4 + ' and a.Ad_type_code='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype <>'') begin
	set @query4=@query4 + ' and a.Agency_type ='''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat <>'') begin
	set @query4=@query4 + ' and a.Ad_cat_code ='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat <>'') begin
	set @query4=@query4 + ' and a.Ad_sub_cat_code ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'') begin
	set @query4=@query4 + ' and a.Ad_Subcat3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'') begin
	set @query4=@query4 + ' and a.Ad_Subcat4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'') begin
	set @query4=@query4 + ' and a.Ad_subcat5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package <>'') begin
	set @query4=@query4 + ' and a.Package_code ='''+@package+''''
END 

IF(@scheme IS NOT NULL and @scheme <>'') begin
	set @query4=@query4 + ' and a.Scheme_type_code ='''+@scheme+''''
END 

IF(@agency IS NOT NULL and @agency <>'') begin
	set @query4=@query4 + ' and a.Agency_code ='''+@agency+''''
END 

IF(@client IS NOT NULL and @client  <>'') begin
	set @query4=@query4 + ' and a.Client_code ='''+@client+''''
END 

IF(@executive IS NOT NULL and @executive <>'') begin
	set @query4=@query4 + ' and a.Executive_code ='''+@executive+''''
END 

IF(@retainer IS NOT NULL and @retainer <>'') begin
	set @query4=@query4 + ' and a.RETAINER ='''+@retainer+''''
END 

IF(@product IS NOT NULL and @product <>'') begin
	set @query4=@query4 + ' and a.Product_code ='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand <>'') begin
	set @query4=@query4 + ' and a.Brand_code ='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient <>'') begin
	set @query4=@query4 + ' and a.Variant_code ='''+@varient+''''
END 

IF(@pagetype IS NOT NULL and @pagetype <>'') begin
	set @query4=@query4 + ' and a.Page_type_code ='''+@pagetype+''''
END 

IF(@pageprem IS NOT NULL and @pageprem <>'') begin
	set @query4=@query4 + ' and a.Page_prem ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem <>'') begin
	set @query4=@query4 + ' and a.Page_position_code ='''+@postprem+''''
END 

IF(@rostatus IS NOT NULL and @rostatus <>'') begin
	set @query4=@query4 + ' and a.ro_status ='''+@rostatus+''''
END 

IF(@booktype IS NOT NULL and @booktype <>'') begin
	set @query4=@query4 + ' and a.Booking_type ='''+@booktype+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'') begin
	set @query4=@query4 + ' and a.Contract_name ='''+@contractname +''''
END 



IF(@ratetype  IS NOT NULL and @ratetype  <>'') begin
	set @query4=@query4 + ' and a.Rate_code ='''+@ratetype+''''
END 

IF(@city  IS NOT NULL and @city  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.City_Code ='''+@city+''''
	end 

	if(@base='2')begin
		set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code ='''+@city+''' )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and a.RETAINER in(select RET.Retain_Code from  RETAINERMASTER RET where  RET.City_Code='''+@city+''')'
	end 
END 

IF(@zone  IS NOT NULL and @zone  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.zone_code ='''+@zone+''''
	end 

	if(@base='2')begin
		set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= '''+@zone+''') )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and a.RETAINER in(select RET.Retain_Code from  RETAINERMASTER RET where  RET.Zone_Code='''+@zone+''')'
	end 
END 

IF(@district  IS NOT NULL and @district  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.Dist_Code ='''+@district+''''
	end 

	if(@base='2')begin
		set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code ='''+@district+''' )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and a.RETAINER in(select RET.Retain_Code from  RETAINERMASTER RET where  RET.Dist_Code='''+@district+''')'
	end 
END 

IF(@state  IS NOT NULL and @state  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.State_Code ='''+@state+''''
	end 

	if(@base='2')begin
		set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code ='''+@state+''' )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and a.RETAINER in(select RET.Retain_Code from  RETAINERMASTER RET where  RET.State_Code='''+@state+''')'
	end 
END 

IF(@taluka  IS NOT NULL and @taluka  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.TALUKA='''+@taluka+'''  '
	end 

	if(@base='2')begin
		set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA ='''+@taluka+''' )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and a.RETAINER in(select RET.Retain_Code from  RETAINERMASTER RET where  RET.TALUKA='''+@taluka+''')'
	end 
END 

set @query4=@query4 + ' group by a.date_time order by Date '


print(@query1+@query4)
exec(@query1+@query4)
end

else if(@adcheck=2)begin


open c2
fetch next from c2 into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME
	while @@FETCH_STATUS=0 begin
		insert into #temp_ad_bills_report select * from dbo.FUN_BILL_INSERT(@compcode,@v2_CIOID,@v2_BILLNO,@prefer,@dateformat,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME,@base )  

fetch next from c2 into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME

end
close c2



set @query2='SELECT 
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),BILLDATE,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),BILLDATE,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),BILLDATE,111) END AS "Date",
sum(NOINSERT) as "noinsert",
sum(PAIDINSERT) as "Paidinsert" ,
sum(AREA) as "Area",
sum(CARDAMT) as "cardamt",
sum(DEVIATIONAMT) as "Deviationamt",
case isnull(sum(CARDAMT),0)
when 0 then 0
else round(((isnull(sum(DEVIATIONAMT),0) *100)/isnull(sum(CARDAMT),0)),2) end  AS "Deviation(%)",

sum(AGGAMT)  as "aggamt",
sum(DISCAMT) as "DiscAmt",
case isnull(sum(CARDAMT),0)
when 0 then 0
else round(((isnull(sum(DISCAMT),0) *100)/isnull(sum(CARDAMT),0)),2) end as "Discper",

sum(POSAMT)as  "posamt",
case isnull(sum(CARDAMT),0)
when 0 then 0
else round(((isnull(sum(POSAMT),0) *100)/isnull(sum(CARDAMT),0)),2) end as "pos(%)",

sum(SPDISCAMT) as "Spdiscamt",
case isnull(sum(CARDAMT),0)
when 0 then 0
else round(((isnull(sum(SPDISCAMT),0)*100)/isnull(sum(CARDAMT),0)),2) end as "Spdiscper",

sum(SPACEDISC) as "Spacedisc",
case isnull(sum(CARDAMT),0)
when 0 then 0
else round(((isnull(sum(SPACEDISC),0)*100)/isnull(sum(CARDAMT),0)),2) end as "Spacediscper",

sum(SPECIALCHARGE) as "Specialcharge",
sum(AGENCYADDLTDAMT) as "AgencyAddlTDAmt",
case (isnull(sum(CARDAMT),0)+isnull(sum(POSAMT),0)+isnull(sum(SPECIALCHARGE),0)-isnull(sum(DEVIATIONAMT),0)-isnull(sum(DISCAMT),0)-isnull(sum(SPDISCAMT),0)-isnull(sum(SPACEDISC),0))
when 0 then 0
else round(((isnull(sum(AGENCYADDLTDAMT),0)*100)/(isnull(sum(CARDAMT),0)+isnull(sum(POSAMT),0)+isnull(sum(SPECIALCHARGE),0)-isnull(sum(DEVIATIONAMT),0)-isnull(sum(DISCAMT),0)-isnull(sum(SPDISCAMT),0)-isnull(sum(SPACEDISC),0))),2) end as "AgencyAddlTD(%)",

sum(GROSSAMT)  as "Grossamt",
sum(RETTDAMT)as "RetTDAmt",
case isnull(sum(GROSSAMT),0) 
when 0 then 0
else round(((isnull(sum(RETTDAMT),0)*100)/isnull(sum(GROSSAMT),0) ),2) end as "RetTD(%)",

sum(AGENCYTDAMT)as "AgencyTDAmt",
case (isnull(sum(CARDAMT),0)+isnull(sum(POSAMT),0)+isnull(sum(SPECIALCHARGE),0)-isnull(sum(DEVIATIONAMT),0)-isnull(sum(DISCAMT),0)-isnull(sum(SPDISCAMT),0)-isnull(sum(SPACEDISC),0))
when 0 then 0
else round(((isnull(sum(AGENCYTDAMT),0)*100)/(isnull(sum(CARDAMT),0)+isnull(sum(POSAMT),0)+isnull(sum(SPECIALCHARGE),0)-isnull(sum(DEVIATIONAMT),0)-isnull(sum(DISCAMT),0)-isnull(sum(SPDISCAMT),0)-isnull(sum(SPACEDISC),0))),2) end as "AgencyTD(%)",

sum(BILLAMT )as "Billamt",
sum(RETCOMMAMT)as "RetCommAmt",
case isnull(sum(GROSSAMT),0)
when 0 then 0
else round(((isnull(sum(RETCOMMAMT),0)*100)/isnull(sum(GROSSAMT),0)),2) end as "RetComm(%)",

sum(ACTUALBUSINESS)as "ActualBusiness"
from #temp_ad_bills_report where '



IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL ) begin
	set @query4= '  BILLDATE between  '''+@fromdate +''' and  '''+@dateto+''' '
END 

IF(@publication IS NOT NULL and @publication<>'') begin
	set @query4=@query4+ ' and PRIPUB='''+@publication+''''
END 

IF(@pub_cent IS NOT NULL and @pub_cent<>'') begin
	set @query4=@query4+ '   and PUB_CENT_CODE='''+@pub_cent+''''
END 

IF(@edition IS NOT NULL and @edition<>'') begin
	set @query4=@query4+ '  and PEDITION='''+@edition+''''
END 

IF(@branch IS NOT NULL and @branch<>'') begin
	set @query4=@query4+ '  and  BRANCH_NAME ='''+@branch+''' '
END 

IF(@region IS NOT NULL and @region<>'') begin
	set @query4=@query4 +' and REGION='''+@region +''''
END 

IF(@adtype IS NOT NULL and @adtype<>'') begin
	set @query4=@query4 + ' and PADTYPE='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype<>'') begin
	set @query4=@query4 + ' and AGENCY_TYPE_CODE= '''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat<>'') begin
	set @query4=@query4 + ' and PRIADCTG='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat<>'') begin
	set @query4=@query4 + ' and SECADCTG ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3<>'') begin
	set @query4=@query4 + ' and AD_SUBCAT3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4<>'') begin
	set @query4=@query4 + ' and AD_SUBCAT4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5<>'') begin
	set @query4=@query4 + ' and AD_SUBCAT5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package<>'') begin
	set @query4=@query4 + ' and PACKAGE_CODE='''+@package+''''
END 

IF(@agency IS NOT NULL and @agency<>'') begin
	set @query4=@query4 + ' and AG_MAIN_CODE ='''+@agency +''''
END 

IF(@client IS NOT NULL and @client<>'') begin
	set @query4=@query4 + ' and CLIENTCD='''+@client +''''
END 

IF(@executive IS NOT NULL and @executive<>'') begin
	set @query4=@query4 + ' and EXECUTIVE_NAME='''+@executive+''''
END 

IF(@product IS NOT NULL and @product<>'') begin
	set @query4=@query4 + ' and PRIPROCTG='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand<>'') begin
	set @query4=@query4 + ' and BRAND_CODE='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient<>'') begin
	set @query4=@query4 + ' and   VARIENT_NAME='''+@varient+''''
END 

IF(@pageprem IS NOT NULL and @pageprem<>'') begin
	set @query4=@query4 + ' and PAGE_PREM ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem<>'') begin
	set @query4=@query4 + ' and PAGE_POST ='''+@postprem+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'') begin
	set @query4=@query4 + ' and CONTRACT_NAME ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment<>'') begin
	set @query4=@query4 + ' and SUPP_CODE='''+@suppliment+''''
END 

IF(@retainer IS NOT NULL and @retainer<>'') begin
	set @query4=@query4 + ' and RETAINER_CODE='''+@retainer+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype<>'') begin
	set @query4=@query4 + ' and RATECD ='''+@ratetype+''''
END 

IF(@scheme IS NOT NULL and @scheme<>'') begin
	set @query4=@query4 + ' and PSCHEME='''+@scheme+''''
END 

IF(@revcenter IS NOT NULL and @revcenter<>'') begin
	set @query4=@query4 +' and REVENUE_CENTER='''+@revcenter+''''
END 

IF(@rostatus IS NOT NULL and @rostatus<>'') begin
	set @query4=@query4 + ' and RO_STATUS='''+@rostatus+''''
END 

IF(@pagetype IS NOT NULL and @pagetype<>'') begin
	set @query4=@query4 + ' and PAGE_TYPE ='''+@pagetype+''''
END 

IF(@booktype IS NOT NULL and @booktype<>'') begin
	set @query4=@query4 + ' and BOOKING_TYPE='''+@booktype+''''
END 

IF(@city  IS NOT NULL and @city<>'') begin
	set @query4=@query4 + ' and CITY_CODE ='''+@city+''''
END 

IF(@zone  IS NOT NULL and @zone<>'') begin
	set @query4=@query4 + ' and ZONE_CODE ='''+@zone+''''
end 

IF(@district  IS NOT NULL and @district<>'') begin
	set @query4=@query4 + ' and DIST_CODE ='''+@district+''''
end 

IF(@state  IS NOT NULL and @state<>'') begin
	set @query4=@query4 + ' and STATE_CODE ='''+@state+''''
end 

IF(@taluka  IS NOT NULL and @taluka<>'') begin
	set @query4=@query4 + ' and PTALUKA='''+@taluka+'''  '
end 


if(@base='2')begin
	set @query4=@query4 +' and (EXECUTIVE_NAME   is not null and EXECUTIVE_NAME !=''0'')  '
end 

if(@base='3')begin
	set @query4=@query4 +' and (RETAINER_CODE  is not null  and RETAINER_CODE  !=''0'')  '
end 

set @query4=@query4 + ' group by BILLDATE'
set @query4=@query4 + ' order by BILLDATE'


print(@query2+@query4)
exec(@query2+@query4)
end 

else if(@adcheck=3) begin
set @query3='SELECT  distinct
CASE '''+@dateformat+'''
WHEN ''mm/dd/yyyy'' then CONVERT(varchar(10),b.Insert_Date,101)
WHEN ''dd/mm/yyyy'' then CONVERT(varchar(10),b.Insert_Date,103)
WHEN ''yyyy/mm/dd'' then CONVERT(varchar(10),b.Insert_Date,111) END as Date,
sum(a.No_of_insertion) as noinsert,
sum(a.Paid_ins) as Paidinsert,
sum(b.Size_Book) as Area,
sum(a.Card_rate*b.Size_Book) as cardamt,
sum(a.Deviation) as Deviationamt,
round(((sum(a.Deviation)*100)/sum(a.Card_rate*b.Size_Book)),2) AS  "Deviation(%)",
sum(b.Agreed_Rate)  as aggamt,
(sum(a.Card_rate*b.Size_Book)- 
case isnull(sum(b.Agreed_Rate),0)
when 0 then sum(a.Card_rate*b.Size_Book)
else sum(b.Agreed_Rate)end) as DiscAmt,
round((((sum(a.Card_rate*b.Size_Book)- 
case isnull(sum(b.Agreed_Rate),0)
when 0 then sum(a.Card_rate*b.Size_Book)
else sum(b.Agreed_Rate)end)*100)/sum(a.Card_rate*b.Size_Book)),2) as Discper,
sum(dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1'') )as  posamt,
round(((sum(dbo.FETCH_RATAMT(a.cio_booking_id,''1'',''1''))*100)/sum(a.Card_rate*b.Size_Book)),2)  as  "pos(%)",
sum(a.Special_disc_per * b.Size_Book * a.Card_rate/100) as Spdiscamt,
round(((sum(a.Special_disc_per * b.Size_Book * a.Card_rate/100)*100)/sum(a.Card_rate*b.Size_Book)),2) as Spdiscper,
sum(a.Space_disc_per * b.Size_Book * a.Card_rate/100) as Spacedisc,
round(((sum(a.Space_disc_per * b.Size_Book * a.Card_rate/100)*100)/sum(a.Card_rate*b.Size_Book)),2) as Spacediscper,
sum(a.Special_charges) as Specialcharge,
round(((sum(isnull((isnull(b.Gross_Rate ,''0'')*isnull(a.ADD_AGENCY_COMM,''0'')/100),''0''))*100)/(sum(a.Card_rate*b.Size_Book)+sum(dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1'') )+sum(a.Special_charges) -sum(a.Deviation)-(sum(a.Card_rate*b.Size_Book)- 
case isnull(sum(b.Agreed_Rate),0)
when 0 then sum(a.Card_rate*b.Size_Book)
else sum(b.Agreed_Rate)end)-sum(a.Special_discount)-sum(a.Space_discount))),2) as  "AgencyAddlTD(%)",
sum(isnull((isnull(b.Gross_Rate ,''0'')*isnull(a.ADD_AGENCY_COMM,''0'')/100),''0'')) as AgencyAddlTDAmt,
ROUND(sum(isnull(b.Gross_Rate,''0'') ),2)as Grossamt,
 case sum(isnull(b.Gross_Rate,''0'') )
 when  0 then 0
 else  round(((sum(isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(b.Gross_Rate,''0''),'''+@prefer+''',''4'' ),''0''))*100)/sum(isnull(b.Gross_Rate,''0'') )),2)  
 end  as  "RetTD(%)",
sum(isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(b.Gross_Rate,''0''),'''+@prefer+''',''4'' ),''0''))as RetTDAmt,
round(((sum((isnull(b.Gross_Rate,''0'')* isnull(a.Trade_disc,''0'' )/100 ))*100)/(sum(a.Card_rate*b.Size_Book)+sum(dbo.FETCH_RATAMT(a.cio_booking_id ,''1'',''1'') )+sum(a.Special_charges) -sum(a.Deviation)-(sum(a.Card_rate*b.Size_Book)- 
case isnull(sum(b.Agreed_Rate),0)
when 0 then sum(a.Card_rate*b.Size_Book)
else sum(b.Agreed_Rate)end)-sum(a.Special_discount)-sum(a.Space_discount))),2) as "AgencyTD(%)",
sum((isnull(b.Gross_Rate,''0'')* isnull(a.Trade_disc,''0'' )/100 ))as AgencyTDAmt,
ROUND(sum(isnull(b.Bill_Amt,''0'')),2) as Billamt,
 case sum(isnull(b.Gross_Rate,''0'') )
 when  0 then 0
 else  round(((sum(isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(b.Gross_Rate,''0''),'''+@prefer+''',''2'' ),''0'') ) *100)/sum(isnull(b.Gross_Rate,''0'') )),2)  
 end  as "RetComm(%)",
sum(isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(b.Gross_Rate,''0''),'''+@prefer+''',''2'' ),''0'') )as RetCommAmt,
ROUND(sum(isnull((  isnull(b.Bill_Amt,''0'')-isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(b.Gross_Rate,''0''),'''+@prefer+''',''5'' ),''0'')  ),''0'')),2) as ActualBusiness
FROM TBL_BOOKING_MAST a,AGENCY_MAST ,
TBL_BOOKING_insert b
WHERE a.Comp_code='''+@compcode+''' AND
a.Agency_sub_code=AGENCY_MAST.code_subcode AND
a.cio_booking_id=b.Cio_Booking_Id '
--and ((b.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
--or  ('''+@chk_access+'''=''0'') )' 

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL) begin
	set @query4=' and b.Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
END 

if(@base='2')begin
	set @query4=@query4 +' and (a.Executive_code is not null and a.Executive_code !=''0'')  '
end 

if(@base='3')begin
	set @query4=@query4 +' and (a.retainer IS NOT NULL and retainer <>''  and a.RETAINER !=''0'')  '
end 

/*
if(@drpstatus is null or  @drpstatus = '') begin
	set @query4=@query4+' and lower(Insert_Status)!='''+'cancel'+''''
end */


if(@drpstatus = '1') begin
		set @query4=@query4+' and  lower(Insert_Status)!=''hold'''
	end

if(@drpstatus = '2') begin
		set @query4=@query4+' and lower(Insert_Status)!=''cancel'''
	end


if(@insertstatus is not null and @insertstatus<>'' ) begin
	set @query4=@query4+' and lower(Insert_Status)='''+@insertstatus+''''
end 


IF(@publication IS NOT NULL) begin
	set @query4=@query4 +' and b.publication_Code='''+@publication+'''    '
END 

/*IF(@pub_cent IS NOT NULL and @pub_cent <>'')
begin
--set @query4=@query4 +'  and b.Pub_Cent_Code='''+@pub_cent+''''
set @query4=@query4+'  and a.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE a.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code='''+@pub_cent+'''))'

END 
IF(@branch IS NOT NULL and @branch<>'')
begin
set @query4=@query4 +'  and a.branch ='''+@branch+''''
END */

IF(@pub_cent IS NOT NULL) begin
	set @query4=@query4+'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
END 


IF(@branch IS NOT NULL  and @branch<>'') begin
	set @query4=@query4+'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
END 

IF(@edition IS NOT NULL and @edition<>'') begin
	set @query4=@query4 +'  and b.Edition_Code='''+@edition+''''
END 

IF(@region IS NOT NULL and @region <>'') begin
	--set @query4=@query4  +' and b.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+@region +''')'
	set @query4=@query4  +' and agency_mast.region ='''+@region+''''

END 

IF(@revcenter IS NOT NULL and @revcenter <>'') begin
	set @query4=@query4  +' and a.Revenue_center ='''+@revcenter+''''
END 

IF(@adtype IS NOT NULL and @adtype <>'') begin
	set @query4=@query4  + ' and a.Ad_type_code='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype <>'') begin
	set @query4=@query4  + ' and a.Agency_type ='''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat <>'') begin
	set @query4=@query4  + ' and b.Ad_Cat ='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat <>'') begin
	set @query4=@query4  + ' and a.Ad_sub_cat_code ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'') begin
	set @query4=@query4  + ' and a.Ad_Subcat3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'') begin
	set @query4=@query4  + ' and a.Ad_Subcat4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'') begin
	set @query4=@query4  + ' and a.Ad_subcat5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package <>'') begin
	set @query4=@query4  + ' and a.Package_code ='''+@package+''''
END 

IF(@scheme IS NOT NULL and @scheme <>'') begin
	set @query4=@query4  + ' and a.Scheme_type_code ='''+@scheme+''''
END 

IF(@agency IS NOT NULL and @agency <>'') begin
	set @query4=@query4  + ' and a.Agency_code ='''+@agency+''''
END 

IF(@client IS NOT NULL and @client  <>'') begin
	set @query4=@query4  + ' and a.Client_code ='''+@client+''''
END 

IF(@executive IS NOT NULL and @executive <>'') begin
	set @query4=@query4  + ' and a.Executive_code ='''+@executive+''''
END 

IF(@retainer IS NOT NULL and @retainer <>'') begin
	set @query4=@query4  + ' and a.RETAINER ='''+@retainer+''''
END 

IF(@product IS NOT NULL and @product <>'') begin
	set @query4=@query4 + ' and a.Product_code ='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand <>'') begin
	set @query4=@query4  + ' and a.Brand_code ='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient <>'') begin
	set @query4=@query4  + ' and a.Variant_code ='''+@varient+''''
END 

IF(@pagetype IS NOT NULL and @pagetype <>'') begin
	set @query4=@query4  + ' and a.Page_type_code ='''+@pagetype+''''
END 

IF(@pageprem IS NOT NULL and @pageprem <>'') begin
	set @query4=@query4 + ' and b.Premium1 ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem <>'') begin
	set @query4=@query4 + ' and b.Page_Post ='''+@postprem+''''
END 

IF(@rostatus IS NOT NULL and @rostatus <>'') begin
	set @query4=@query4 + ' and a.ro_status ='''+@rostatus+''''
END 

IF(@booktype IS NOT NULL and @booktype <>'') begin
	set @query4=@query4 + ' and a.Booking_type ='''+@booktype+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'') begin
	set @query4=@query4 + ' and a.Contract_name ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment  <>'') begin
	set @query4=@query4 + ' and b.Supp_Code ='''+@suppliment+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype  <>'') begin
	set @query4=@query4 + ' and a.Rate_code ='''+@ratetype+''''
END 

IF(@city  IS NOT NULL and @city  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.City_Code ='''+@city+''''
	end 

	if(@base='2')begin
		set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code ='''+@city+''' )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.City_Code='''+@city+''')'
	end 
END 

IF(@zone  IS NOT NULL and @zone  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.zone_code ='''+@zone+''''
	end 
	
	if(@base='2')begin
		set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.city_code in (select city_mst.City_Code from city_mst where city_mst.Zone_Code= '''+@zone+''') )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Zone_Code='''+@zone+''')'
	end 
END 

IF(@district  IS NOT NULL and @district  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.Dist_Code ='''+@district+''''
	end 

	if(@base='2')begin
		set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.dist_code ='''+@district+''' )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.Dist_Code='''+@district+''')'
	end 
END 

IF(@state  IS NOT NULL and @state  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.State_Code ='''+@state+''''
	end 

	if(@base='2')begin
		set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.State_code ='''+@state+''' )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.State_Code='''+@state+''')'
	end 
END 

IF(@taluka  IS NOT NULL and @taluka  <>'') begin
	if(@base='1')begin
		set @query4=@query4 + ' and AGENCY_MAST.TALUKA='''+@taluka+'''  '
	end 

	if(@base='2')begin	
		set @query4=@query4 + ' and a.Executive_code in(select exec_mast.Exe_no from exec_mast where exec_mast.TALUKA ='''+@taluka+''' )'
	end 

	if(@base='3')begin
		set @query4=@query4 + ' and a.RETAINER in(select RETAINERMASTER.Retain_Code from  RETAINERMASTER where  RETAINERMASTER.TALUKA='''+@taluka+''')'
	end 
END 

set @query4=@query4 + ' group by b.Insert_Date order by Date'

print(@query3+@query4)
exec(@query3+@query4)

end 
 
SELECT getdate() AS "Rundate",dbo.initcap(Comp_Name) AS "companyname" from comp_mst where Comp_Code=@compcode
select * from  #temp_ad_bills_report

deallocate c1
deallocate c2

drop table #temp_ad_bills_report
/*drop table #temp_complete_dynamic_report
drop table #MULTIPACK_REP	
drop table #MULTIPACK_RAT
drop table #MULTIPACK_RATNEW*/





========end===8199====avinash=====20/08/2012======================================




