/****************************NEHA ISSUE NO 8282**********************************/

USE [abhi]
GO
/****** Object:  UserDefinedFunction [dbo].[FUN_BILL_INSERT]    Script Date: 09/03/2012 16:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
                                           
ALTER  function [dbo].[FUN_BILL_INSERT] ( @comp_cod varchar(20), @cio_id varchar(100),@bil_no varchar(100),@prefer varchar(10),@dateformate varchar(20),@f_agmain varchar(100),@f_agsub varchar(100),@f_agcode varchar(100),@f_agname varchar(200),@f_execcode varchar(100),@f_execname varchar(200),@f_retcode varchar(100),@f_retname varchar(200),@base varchar(10)) --RETURNs float(6) as

RETURNS @temp_ad_bills_report TABLE      
(
  CIOID             varchar(50),
  BILLNO            varchar(25),
  AGENCY            varchar(50),
  CLIENT            varchar(200),
  RONO              varchar(40),
  RODATE            DATEtime,
  EXECUTIVE         varchar(50),
  RETAINER          varchar(80),
  BOOKTYPE          varchar(50),
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
  REVCENTER         varchar(50),
  UOM               varchar(20),
  UOMDESC           varchar(50),
  COMP_CODE         varchar(10),
  PADTYPE           varchar(20),
  PRIPUB            varchar(10),
  PEDITION          varchar(50),
  BRANCH_NAME       varchar(50),
  PUB_CENT_CODE     varchar(50),
  REGION            varchar(12),
  AGENCY_TYPE_CODE  varchar(10),
  PRIADCTG          varchar(40),
  SECADCTG          varchar(40),
  AD_SUBCAT3        varchar(15),
  AD_SUBCAT4        varchar(15),
  AD_SUBCAT5        varchar(15),
  PACKAGE_CODE      varchar(500),
  AG_MAIN_CODE      varchar(10),
  AG_SUB_CODE       varchar(10),
  CLIENTCD          varchar(200),
  EXECUTIVE_NAME    varchar(100),
  PRIPROCTG         varchar(10),
  BRAND_CODE        varchar(10),
  VARIENT_NAME      varchar(25),
  PAGE_PREM         varchar(10),
  PAGE_POST         varchar(10),
  CONTRACT_NAME     varchar(50),
  SUPP_CODE         varchar(50),
  RETAINER_CODE     varchar(10),
  RATECD            varchar(40),
  CITY_CODE         varchar(20),
  ZONE_CODE         varchar(20),
  DIST_CODE         varchar(20),
  STATE_CODE        varchar(20),
  PTALUKA           varchar(20),
  PSCHEME           varchar(18),
  REVENUE_CENTER    varchar(10),
  RO_STATUS         varchar(10),
  PAGE_TYPE         varchar(100),
  BOOKING_TYPE      varchar(10),
  PUB_CENT_PERMIT   varchar(50),
  SESS_ID           int                      ,
  DIST_NAME         varchar(50),
  TALU_NAME         varchar(50),
  PUB_CENT_NAME     varchar(50),
  CITY_NAME         varchar(30),
  ZONE_NAME         varchar(30),
  STATE_NAME        varchar(30),
  PAGE_NO			int,
BILL_REMARK         varchar(500),
 CAPTION        varchar(2000),
 FMGCODE			VARCHAR(2000)
 
)


begin

declare @FCIOID  varchar(50)
declare @FBillno  varchar(25)
declare @FAgency  varchar(50)
declare @FClient  varchar(200)
declare @FRoNo  varchar(40)
declare @FRoDate  datetime
declare @FExecutive  varchar(50)
declare @FRetainer  varchar(80)
declare @FBookType  varchar(50)
declare @FColor  varchar(20)
declare @FAdcat  varchar(50)
declare @FAdsubcat  varchar(50)
declare @FAdsubcat3  varchar(50)
declare @FAdsubcat4  varchar(50)
declare @FAdsubcat5  varchar(50)
declare @FPackag  varchar(500)
declare @FBillDate  datetime
declare @Fnoinsert  int
declare @FPaidinsert  int
declare @Fheight  int
declare @Fwidth  int
declare @FArea  int
declare @FPagepremium  varchar(30)
declare @FPostprem  varchar(30)
declare @Fscheme  varchar(50)
declare @FRatecod  varchar(40)
declare @Fcardrate  float
declare @Fcardamt  float
declare @Fcontractrate  int
declare @FDeviationamt  int
declare @FDeviationper  int
declare @FAggrate  int
declare @Faggamt  int
declare @FDiscAmt  float
declare @FDiscper  int
declare @Fposamt  int
declare @Fposper  int
declare @FSpdiscamt  int
declare @FSpdiscper  int
declare @FSpacedisc  int
declare @FSpacediscper  int
declare @FSpecialcharge  int
declare @FAgencyAddlTDper  varchar(8)
declare @FAgencyAddlTDAmt  int
declare @FGrossamt  int
declare @FRetTDPer   int
declare @FRetTDAmt  int
declare @FAgencyTDPer  int
declare @FAgencyTDAmt  int
declare @FBillamt  int
declare @FRetCommPer  int
declare @FRetCommAmt   int
declare @FActualBusiness  int
declare @FRevcenter   varchar(50)
declare @FUom  varchar(20)
declare @FUomDesc  varchar(50)
declare @FCOMP_CODE  varchar(10)
declare @Fpadtype  varchar(20)
declare @FPRIPUB  varchar(10)
declare @FPEDITION  varchar(50)
declare @FBranch_Name  varchar(50)
declare @FPub_cent_Code  varchar(50)
declare @Fregion  varchar(12)
declare @FAgency_Type_Code  varchar(10)
declare @FPRIADCTG  varchar(40)
declare @FSECADCTG  varchar(40)
declare @FAD_SUBCAT3  varchar(15)
declare @FAD_SUBCAT4  varchar(15)
declare @FAD_SUBCAT5  varchar(15)
declare @FPACKAGE_CODE  varchar(500)
declare @FAG_MAIN_CODE  varchar(10)
declare @FAG_SUB_CODE  varchar(10)
declare @FCLIENTCD  varchar(200)
declare @FEXECUTIVE_NAME  varchar(100)
declare @FPRIPROCTG  varchar(10)
declare @Fbrand_code  varchar(10)
declare @FVarient_Name  varchar(25)
declare @FPAGE_PREM  varchar(10)
declare @FPAGE_POST  varchar(10)
declare @FCONTRACT_NAME  varchar(50)
declare @FSUPP_CODE  varchar(50)
declare @FRETAINER_CODE  varchar(10)
declare @FRATECD  varchar(40)
declare @FCity_Code  varchar(10)
declare @Fzone_code  varchar(10)
declare @FDist_Code  varchar(10)
declare @FState_Code  varchar(10)
declare @FPTALUKA  varchar(10)
declare @FPSCHEME  varchar(18)
declare @FREVENUE_CENTER  varchar(10)
declare @FRO_STATUS  varchar(10)
declare @FPAGE_TYPE  varchar(100)
declare @FBOOKING_TYPE  varchar(10)
declare @FPUB_CENT_PERMIT varchar(50)
declare @FfAdcat varchar(50)
declare @FfAdsubcat varchar(50)
declare @FfAdsubcat3 varchar(50)
declare @FfAdsubcat4 varchar(50)
declare @FfAdsubcat5 varchar(50)
declare @FfPagepremium varchar(50)
declare @Ffscheme varchar(50)
declare @f_bil_amt int
declare @FfAgencyAddlTDAmt int
declare @FfUom varchar(50)
declare @FfBranch_Name varchar(50)
declare @FfClient varchar(100)
declare @FfColor varchar(20)
declare @FfPub_cent_Code varchar(30)
declare @FffPub_cent_Code varchar(30)
declare @FffBranch_Name varchar(50)
declare @ffPRIPROCTG varchar(30)
declare @Fag_dist_code varchar(50)
declare @Fag_talu_code varchar(50)
declare @Fdist_name varchar(50)
declare @Ftalu_name varchar(50)
declare @FPub_cent_Name varchar(50)

declare @Fag_city_code varchar(50) 
declare @Fag_zone_code varchar(50) 
declare @Fag_state_code varchar(50) 
declare @Fcity_name varchar(30)
declare @Fzone_name varchar(30)
declare @Fstate_name varchar(30)
declare @f_exec_city varchar(8)
declare @f_city_zone varchar(8)
declare @f_page_no varchar(8)
declare @f_billremark  varchar(500)
declare @f_captn varchar(2000)
declare @f_fmgcode varchar(2000)

/****************************  For Ad_bills  *******************************/
SELECT @FCIOID=max(ad_bills.IDNUM),
@FBillno=max(AD_BILLS.BILNO),@FRoNo=max(ad_bills.RONUM),@FRoDate=MAX(ad_bills.RODATE),
@FBookType=max(case AD_BILLS.BOOKING_TYPE  
when '1' then 'Barter' 
when '2' then 'FMG' 
when '3' then 'Normal' 
when '4' then 'InHouse' 
when '5' then 'Complimentary' 
else 'Normal' end),
@FPackag=max(dbo.FETCH_PACK(ad_bills.idnum)), --PACKAGE
@FBillDate=MAX(ad_bills.BILDT),@Fcontractrate=max(ad_bills.CONTRACT_RATE),
@Fposamt=max(dbo.FETCH_RATAMT(ad_bills.idnum,'1','2')),   --posamt
@Fposper=max(dbo.FETCH_RATAMT(ad_bills.idnum,'2','2')) ,  --POSPER
@FGrossamt=max(ad_bills.GROSS_AMT),@FBillamt=max(ad_bills.BILLAMT) ,@FAgencyTDPer=max(isnull(ad_bills.DISCOUNT ,0 )),
@FAgencyTDAmt=max((isnull(ad_bills.GROSS_AMT,0)* isnull(ad_bills.DISCOUNT,0 )/100 ))   ,@FCOMP_CODE=MAX(COMP_CODE_V)
,@FfClient=max(ad_bills.CLIENTCD),@FfColor=max(COLOUR),
@FfPagepremium=max(SCHEME),@FAgencyAddlTDAmt=sum(isnull(ad_bills.GROSS_AMT,0)),@f_bil_amt=sum(BILLAMT),@FfPub_cent_Code=max(UNIT),
@FfBranch_Name=max(ad_bills.UNIT),@FPRIPUB=max(ad_bills.PRIPUB) ,@FAG_MAIN_CODE=max(ad_bills.AG_MAIN_CODE),@FAG_SUB_CODE=MAX(AD_BILLS.AG_SUB_CODE),
@FCLIENTCD=max(ad_bills.CLIENTCD),@FEXECUTIVE_NAME=max( ad_bills.EXECUTIVE_NAME),@FPRIPROCTG=max(ad_bills.PRIPROCTG),
@FCONTRACT_NAME=max(ad_bills.CONTRACT_NAME),@FRETAINER_CODE=max(ad_bills.RETAINER_CODE),@FPSCHEME=max(ad_bills.SCHEME),@FREVENUE_CENTER=max(AD_BILLS.REVENUE_CENTER)
,@FRO_STATUS=max(AD_BILLS.RO_STATUS),@FPAGE_TYPE=max(AD_BILLS.PAGE_TYPE),@FBOOKING_TYPE=max(AD_BILLS.BOOKING_TYPE ),
@ffPRIPROCTG=max(PRIPROCTG),@f_page_no=max(PAGENUM),@f_billremark =max(BILL_RMRK)
FROM AD_BILLS WHERE ad_bills.IDNUM=@cio_id AND ad_bills.BILNO=@bil_no  and ad_bills.COMP_CODE_V=@comp_cod 
/**************************************  For Ad_bills_det  ***********************************/
select @FfAdcat=max(PRIADCTG),@FfAdsubcat=max(SECADCTG),@FfAdsubcat3=max(AD_SUBCAT3),@FfAdsubcat4=max(AD_SUBCAT4),@FfAdsubcat5=max(AD_SUBCAT5) ,
@FfPagepremium=max(PAGE_PREM),@Fheight=max(ad_bills_det.HEIGHT),@Fwidth=max(ad_bills_det.WIDTH),@FArea=max(ad_bills_det.SIZE_BOOK),@FRatecod=max(ad_bills_det.RATECD)
,@Fcardrate=sum(ad_bills_det.CARD_RATE_V),@FPEDITION=max(ad_bills_det.EDITION),@Fpadtype=max(ad_bills_det.AD_TYPE_V),@FPRIADCTG=max(ad_bills_det.PRIADCTG) ,
@FSECADCTG=max(ad_bills_det.SECADCTG),@FAD_SUBCAT3=max(ad_bills_det.AD_SUBCAT3),
@FAD_SUBCAT4=max(ad_bills_det.AD_SUBCAT4),@FAD_SUBCAT5=max(ad_bills_det.AD_SUBCAT5),@FPACKAGE_CODE=max(ad_bills_det.PACKAGE_CODE),@FPAGE_PREM=max(ad_bills_det.PAGE_PREM),
@FPAGE_POST=max(ad_bills_det.PAGE_POST),@FSUPP_CODE=max(ad_bills_det.SUPP_CODE),@FRATECD=max(ad_bills_det.RATECD),@FPUB_CENT_PERMIT=MAX(ad_bills_det.BKFOR)

from ad_bills_det where bilno=@bil_no;
/**************************  For Tbl_booking_mast  *********************************************/
select @FRetCommPer=max(isnull(dbo.fun_actual(@comp_cod,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_mast.Gross_amount,0),@prefer,1 ),0)),-- RetComm(%)
@FRetCommAmt=max(isnull(dbo.fun_actual(@comp_cod,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_mast.Gross_amount,0),@prefer,2 ),0)),--RetCommAmt
@FRetTDPer=max(isnull(dbo.fun_actual(@comp_cod,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_mast.Gross_amount,0),@prefer,3 ),0)),--RetTD(%)
@FRetTDAmt=max(isnull(dbo.fun_actual(@comp_cod,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_mast.Gross_amount,0),@prefer,4 ),0)),--RetTDAmt
@FActualBusiness=max(isnull((@f_bil_amt-isnull(dbo.fun_actual(@comp_cod,isnull(tbl_booking_mast.ADD_AGENCY_COMM,0 ),isnull(tbl_booking_mast.RETAINER,0),isnull(tbl_booking_mast.Gross_amount,0),@prefer,5 ),0)  ),0))--ActualBusiness
,@Fnoinsert=max(tbl_booking_mast.No_of_insertion),@FPaidinsert=max(tbl_booking_mast.Paid_ins),
@FDeviationamt=max(tbl_booking_mast.Deviation),@FDeviationper=max(tbl_booking_mast.Deviation) ,@FAggrate=max(tbl_booking_mast.Agrred_rate),@Faggamt=max(tbl_booking_mast.Agreed_amount),
@FDiscper=max(tbl_booking_mast.Discount_per) ,@FSpdiscper=max(tbl_booking_mast.Special_disc_per),@FSpacediscper=max(tbl_booking_mast.Space_disc_per),
@FSpecialcharge=max(tbl_booking_mast.Special_charges),@FAgencyAddlTDper=max(isnull(tbl_booking_mast.ADD_AGENCY_COMM,0)),
@FAgencyAddlTDAmt=max(isnull((@FfAgencyAddlTDAmt*isnull(tbl_booking_mast.ADD_AGENCY_COMM,0)/100),0))
,@FfUom=max(Uom_code) 
,@f_captn=MAX(Caption)
--,(select @f_fmgcode = max(FMG_REASONS)   from tbl_booking_fmg_trans f where f.CIOID = isnull(tbl_booking_mast.cio_booking_id,''))


 from tbl_booking_mast where tbl_booking_mast.cio_booking_id=@FCIOID;
--***************************  variables  ***********************************************************
set @Fagency=@f_agname

set @FClient=dbo.AD_GET_CLIENTNAME (@comp_cod,@FfClient)

set @FExecutive=@f_execname
set @FRetainer=@f_retname

set @FAdcat=dbo.AD_GET_catnameE(@comp_cod,@FfAdcat,'cat')
set @FAdsubcat=dbo.AD_GET_catnameE(@comp_cod,@FfAdsubcat,'subcat')
set @FAdsubcat3=dbo.AD_GET_catnameE(@comp_cod,@FfAdsubcat3,'cat3')
set @FAdsubcat4=dbo.AD_GET_catnameE(@comp_cod,@FfAdsubcat4,'cat4')
set @FAdsubcat5=dbo.AD_GET_catnameE(@comp_cod,@FfAdsubcat5,'cat5')
set @FPagepremium=dbo.AD_GET_catnameE(@comp_cod,@FfPagepremium,'pprem')
set @Fscheme=dbo.AD_GET_catnameE(@comp_cod,@Ffscheme,'fschem')
set @FColor=dbo.AD_GET_catnameE(@comp_cod,@FfColor,'fcol')

set @FSpdiscamt= (round((( isnull(@FSpdiscper,0) * isnull(@FArea,0) * isnull(@Fcardrate,0))/100),2))  
set @FSpacedisc= (round(((isnull(@FSpacediscper,0) * isnull(@FArea,0) * isnull(@Fcardrate,0))/100),2))  
set @Fcardamt=(isnull(@Fcardrate,0) * isnull(@FArea,0) * isnull(@Fnoinsert,0))     
select @FDiscAmt=max((isnull(@Fcardrate,0) * isnull(@FArea,0) * isnull(@Fnoinsert,0)) - case isnull(@Faggamt,0) when 0 then (isnull(@Fcardrate,0) * isnull(@FArea,0) * isnull(@Fnoinsert,0))   else isnull(@Faggamt,0) end           )
select @FUom=max(UOM_MAST.Uom_Name),@FUomDesc=max(uom_mast.UOM_DESC)     from uom_mast where Uom_Code =@FfUom;
select @FffPub_cent_Code=pub_center   from BRANCH_MST where Branch_Code=@FfPub_cent_Code;
select @FPub_cent_Code=max(Pub_cent_Code),@FPub_cent_Name=MAX(Pub_Cent_name) /*into ,*/ from PUB_CENT_MAST where Pub_cent_Code=@FffPub_cent_Code;
select @FBranch_Name=max(branch_mst.Branch_Name)   from branch_mst where branch_mst.Branch_Code= @FfBranch_Name;
select @Fregion=max(agency_mast.region),@FAgency_Type_Code=max(agency_mast.Agency_Type_Code) /*into ,*/ from agency_mast where AGENCY_MAST.code_subcode=@f_agcode; 
select @Fbrand_code=max(brand_mst.brand_code)   from brand_mst where brand_mst.prod_cat_code=@ffPRIPROCTG;
select @FVarient_Name=max(varient_mst.Varient_Name)   from varient_mst where varient_mst.Brand_Code=@Fbrand_code;
--**********************************************************************************************************************
 
select @f_exec_city=max(exec_mast.city_code)   from exec_mast where Exe_no=@f_execcode;
select @f_city_zone=max(city_mst.Zone_Code)   from city_mst where city_mst.City_Code=@f_exec_city
  
if(@base='1') begin
     select @Fag_dist_code=max(Agency_mast.Dist_Code),@Fag_talu_code=max(AGENCY_MAST.TALUKA) ,@Fag_city_code=max(AGENCY_MAST.City_Code),
@Fag_zone_code=max(AGENCY_MAST.zone_code),@Fag_state_code=max(AGENCY_MAST.State_Code)
     from agency_mast where code_subcode=@f_agcode 
     end
 else if(@base='2') begin
      select @Fag_dist_code=max(exec_mast.dist_code),@Fag_talu_code=max(exec_mast.TALUKA) ,@Fag_city_code=max(exec_mast.city_code),
@Fag_zone_code=@f_city_zone,@Fag_state_code=max(exec_mast.State_code)
      from exec_mast where Exe_no=@f_execcode 
end
      
 else
begin
       select @Fag_dist_code=max(RETAINERMASTER.Dist_Code),@Fag_talu_code=max(RETAINERMASTER.TALUKA) ,@Fag_city_code=max(RETAINERMASTER.City_Code),
@Fag_zone_code=max(RETAINERMASTER.Zone_Code),@Fag_state_code=max(RETAINERMASTER.State_Code)
       from RETAINERMASTER where Retain_Code =@f_retcode;
       
  end 

select @Fdist_name=max(dist_mst.Dist_Name)   from dist_mst where Dist_Name=@Fag_dist_code

select @Ftalu_name=max(taluka_mast.TALU_NAME)   from taluka_mast where TALU_CODE=@Fag_talu_code

select @Fcity_name=max(city_mst.City_Name)    from city_mst where City_Code=@Fag_city_code

select @Fzone_name=max(zone_mast.Zone_Name)   from zone_mast where  Zone_Code=@Fag_zone_code

select @Fstate_name=max(state_mst.State_Name)   from state_mst where  State_Code=@Fag_state_code

insert into @temp_ad_bills_report
(
CIOID,Billno,Agency,Client,RoNo,RoDate,Executive,Retainer,BookType,Color,Adcat,Adsubcat,Adsubcat3,Adsubcat4,Adsubcat5,Packag,BillDate,
noinsert,Paidinsert,height,width,Area,Pagepremium,Postprem,scheme,Ratecod,cardrate,cardamt,contractrate,Deviationamt,Deviationper,
Aggrate,aggamt,DiscAmt,Discper,posamt,posper,Spdiscamt,Spdiscper,Spacedisc,Spacediscper,Specialcharge,AgencyAddlTDper,AgencyAddlTDAmt,
Grossamt,RetTDPer,RetTDAmt,AgencyTDPer,AgencyTDAmt,Billamt,RetCommPer,RetCommAmt,ActualBusiness,Revcenter,Uom,UomDesc,
    PADTYPE ,  PRIPUB,  PEDITION,  BRANCH_NAME ,  PUB_CENT_CODE ,  REGION,  AGENCY_TYPE_CODE,  PRIADCTG,  SECADCTG,  AD_SUBCAT3,  AD_SUBCAT4,
  AD_SUBCAT5,  PACKAGE_CODE,  AG_MAIN_CODE,   CLIENTCD,  EXECUTIVE_NAME,  PRIPROCTG ,  BRAND_CODE,  VARIENT_NAME,  PAGE_PREM ,  PAGE_POST ,
  CONTRACT_NAME ,  SUPP_CODE ,  RETAINER_CODE ,  RATECD,    PSCHEME ,  REVENUE_CENTER,  RO_STATUS ,  PAGE_TYPE ,  BOOKING_TYPE,COMP_CODE,AG_SUB_CODE,
  PUB_CENT_PERMIT,DIST_NAME,TALU_NAME,PUB_CENT_NAME,
  CITY_CODE,ZONE_CODE,DIST_CODE,STATE_CODE,PTALUKA,CITY_NAME,ZONE_NAME,STATE_NAME,PAGE_NO,BILL_REMARK,CAPTION,FMGCODE
)
values
(
@FCIOID  ,@FBillno  ,@FAgency  ,@FClient  ,@FRoNo  ,@FRoDate  ,@FExecutive  ,@FRetainer  ,@FBookType  ,@FColor  ,@FAdcat  ,
@FAdsubcat  ,@FAdsubcat3  ,@FAdsubcat4  ,@FAdsubcat5  ,@FPackag  ,@FBillDate  ,@Fnoinsert  ,@FPaidinsert  ,@Fheight  ,@Fwidth  ,
@FArea  ,@FPagepremium  ,@FPostprem  ,@Fscheme  ,@FRatecod  ,@Fcardrate  ,@Fcardamt  ,@Fcontractrate  ,@FDeviationamt  ,
@FDeviationper  ,@FAggrate  ,@Faggamt  ,@FDiscAmt  ,@FDiscper  ,@Fposamt  ,@Fposper  ,@FSpdiscamt  ,@FSpdiscper  ,@FSpacedisc  ,
@FSpacediscper  ,@FSpecialcharge  ,@FAgencyAddlTDper  ,@FAgencyAddlTDAmt  ,@FGrossamt  ,@FRetTDPer   ,@FRetTDAmt  ,
@FAgencyTDPer  ,@FAgencyTDAmt  ,@FBillamt  ,@FRetCommPer  ,@FRetCommAmt   ,@FActualBusiness  ,@FRevcenter   ,@FUom ,
@FUomDesc,@Fpadtype,@FPRIPUB,@FPEDITION,@FBranch_Name,@FPub_cent_Code,@Fregion,@FAgency_Type_Code,@FPRIADCTG,@FSECADCTG,
@FAD_SUBCAT3,@FAD_SUBCAT4,@FAD_SUBCAT5,@FPACKAGE_CODE,@FAG_MAIN_CODE,@FCLIENTCD,@FEXECUTIVE_NAME,@FPRIPROCTG,@Fbrand_code,
@FVarient_Name,@FPAGE_PREM,@FPAGE_POST,@FCONTRACT_NAME,@FSUPP_CODE,@FRETAINER_CODE,@FRATECD,@FPSCHEME,@FREVENUE_CENTER,
@FRO_STATUS,@FPAGE_TYPE,@FBOOKING_TYPE,@FCOMP_CODE,@FAG_SUB_CODE,@FPUB_CENT_PERMIT,@Fdist_name,@Ftalu_name,@FPub_cent_Name,
@Fag_city_code,@Fag_zone_code,@Fag_dist_code,@Fag_state_code,@Fag_talu_code,@Fcity_name,@Fzone_name,@Fstate_name,@f_page_no
,@f_billremark,@f_captn,@f_fmgcode
)


return 


end





USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[completereport]    Script Date: 09/03/2012 16:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



                                          
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
isnull((SELECT "prod_alias" FROM Product_cat_mast where "prod_cat_code"=a."Product_code" and "comp_code"=a."Comp_code"),'''') as PRODUCT,
isnull((SELECT "brand_alias" FROM brand_mst where "brand_code"=a."Brand_code"),'''') as BRAND,
isnull((select distinct bktype_desc from ad_bktype_mast where bktype_code=m.Booking_type),'''') AS bktype_desc
,isnull((select REASON_DESC from ad_fmg_reason_mast where REASON_CODE in (select fmg_reasons from tbl_booking_fmg_trans f where f.CIOID=m.cio_booking_id )),'''') FMG_REASON
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
isnull((SELECT "prod_alias" FROM Product_cat_mast where "prod_cat_code"=#temp_ad_bills_report."PRIPROCTG" and "comp_code"=#temp_ad_bills_report."Comp_code"),'''') as PRODUCT,
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
isnull((SELECT "prod_alias" FROM Product_cat_mast where "prod_cat_code"=TBL_BOOKING_MAST."Product_code" and "comp_code"=TBL_BOOKING_MAST."Comp_code"),'''') as PRODUCT,
isnull((SELECT "brand_alias" FROM brand_mst where "brand_code"=TBL_BOOKING_MAST."Brand_code"),'''') as BRAND,
isnull((select distinct bktype_desc from ad_bktype_mast where bktype_code=m.Booking_type),'''') AS bktype_desc
,isnull((select REASON_DESC from ad_fmg_reason_mast where REASON_CODE in (select fmg_reasons from tbl_booking_fmg_trans f where f.CIOID=m.cio_booking_id )),'''') FMG_REASON
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









/**********************************************************************



*********************************/



/////////////////issue no8473///////////////////////


ALTER TABLE Pub_Cent_Mast ADD STATE VARCHAR(50) ;

ALTER TABLE pcmdummy ADD STATE VARCHAR(50) ;
/////////////////////////////////////////////////////////////////////////


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[pcminsert]

@compcode as varchar(8),
@centercode as varchar(8),
@centername as varchar(50),
@alias as varchar(50),
@add1 as varchar(50),
@street as varchar(50),
@city as varchar(15),
@dist as varchar(15),
@country as varchar(8),
@phone1 as varchar(5),
@phone2 as varchar(10),
@pin as varchar(15),
@state as varchar(15),
@fax as varchar(5),
@email as varchar(50),
--@status as varchar(15),
--@statusdate as varchar(15),
@remarks as varchar(200),
@userid as varchar(8),
@region as varchar(8),
@zone As varchar(8),
@fax1 as varchar(10),
@boxaddress as varchar(200),
@printval as VARCHAR(20),
@imgpath as varchar(50),
@cir_imgpath as varchar(50),
@pcompanyname as varchar(50),
@plogopath as varchar(200),
@pstate as varchar(50)
 AS

declare @query as varchar(1000)


declare @distcode as varchar(50)
declare @statecode as varchar(50)
declare @countrycode as varchar(50)

select @distcode =dist_code from dist_mst where dist_name=@dist
select @statecode=state_code from state_mst  where state_Name=@state
select @countrycode=country_code from count_mst  where country_Name=@country



insert into pub_cent_mast ([Comp_Code]
      ,[Pub_cent_Code]
      ,[Pub_Cent_name]
      ,[Pub_Cent_Alias]
      ,[Add1]
      ,[street]
      ,[Country_Code]
      ,[State_Code]
      ,[Dist_Code]
      ,[City_Code]
      ,[zip]
      ,[Phone1]
      ,[Phone2]
      ,[Fax]
      ,[EmailID]
      ,[Pub_Cent_Status]
      ,[Status_date]
      ,[Remarks]
      ,[UserId]
      ,[Creation_Datetime]
      ,[Region_code]
      ,[Zone_code]
      ,[Fax1]
      ,[BOXADDRESS]
      ,[PRINT_CENT]
      ,[IP]
      ,[FILE_PATH]
      ,[CIR_FILE_PATH],[CENTER_COMP_NAME],[LOGO_FILE_PATH],[STATE]) values(@compcode,@centercode,@centername, @alias,@add1,@street,@country, @state, @dist, @city, @pin,@phone1,@phone2, @fax,@email,'',getdate(),@remarks,@userid,getdate(),@region,@zone,@fax1,@boxaddress,@printval ,'',@imgpath,@cir_imgpath,@pcompanyname,@plogopath,@pstate)
--insert into pub_cent_mast values(@compcode,@centercode,@centername, @alias,@add1,@street,@country, @state, @dist, @city, @pin,@phone1,@phone2, @fax,@email,'','',@remarks,@userid,@region,@zone,@txtdate),@fax2


exec(@query)
print(@query)

////////////////////////////////////////////////////////////////////////////




set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





ALTER PROCEDURE [dbo].[pcmexe]

@compcode as varchar(8),
@centcode as varchar(8),
@centname as varchar(50),
@alias as varchar(50),
@city as varchar(15),
--@userid as varchar(8),
@country as varchar(8),
@pcompname as varchar(50),
@pstate as varchar(8)



AS


declare @query1 varchar(2000)
declare @query2 varchar(900)
declare @query3 varchar(900)
declare @querys varchar(900)
declare @query4 varchar(900)

declare @pcm1 char(12)

--delete from pcmdummy 

CREATE TABLE #pcmdummy(
	Comp_Code varchar(8)  ,
	Pub_cent_Code varchar(8)  ,
	Pub_Cent_name varchar(50)  ,
	Pub_Cent_Alias varchar(50)  ,
	Add1 varchar(50)  ,
	street varchar(50)  ,
	Country_Code varchar(8)  ,
	State_Code varchar(15)  ,
	Dist_Code varchar(15)  ,
	City_Code varchar(15)  ,
	zip	varchar(12)  ,
	Phone1	varchar(5)  ,
	Phone2	varchar(10)  ,
	Fax	varchar(15)  ,
	EmailID	varchar(50)  ,
	Pub_Cent_Status	varchar(20)  ,
	Status_date	datetime	NOT NULL ,
	Remarks	varchar(200)  ,
	UserId	varchar(8)  ,
	To_date	datetime	NULL ,
	From_date	datetime	NULL ,
	Creation_Datetime	datetime	NULL ,
	Region_code	varchar(8)  ,
	Zone_code	varchar(8)  ,
	Fax1	varchar(10)  ,
             BOXADDRESS  varchar(200) ,
PRINT_CENT varchar(20),
FILE_PATH varchar(50),
CIR_FILE_PATH varchar(50),
CENTER_COMP_NAME varchar(50),
STATE varchar(50)
)

/*
CREATE TABLE #Pub_Cent_Mast (
	Comp_Code varchar (8) ,
	Pub_cent_Code varchar (8) ,
	Pub_Cent_name varchar (50) ,
	Pub_Cent_Alias varchar (15) ,
	Add1 varchar (50) ,
	street varchar (50) ,
	Country_Code varchar (8) ,
	State_Code varchar (15) ,
	Dist_Code varchar (15) ,
	City_Code varchar (15) ,
	zip varchar (12) ,
	Phone1 varchar (5) ,
	Phone2 varchar (10) ,
	Fax varchar (5) ,
	EmailID varchar (50) ,
	Pub_Cent_Status varchar (20) ,
	Status_date datetime ,
	Remarks varchar (200) ,
	UserId varchar (8) ,
	Creation_Datetime datetime,
	Region_code varchar (8) ,
	Zone_code varchar (8) ,
	Fax1 varchar (10) 
)
*/
--set @query1=' insert #pcmdummy select Comp_Code,Pub_cent_Code,Pub_Cent_name,Pub_Cent_Alias,Add1,street,Country_Code, State_Code,Dist_Code,City_Code,zip,Phone1,Phone2,Fax,EmailID,Pub_Cent_Status,getdate(),Remarks,UserId,getdate(),creation_datetime,region_code,zone_code,Fax1 from pub_cent_mast where comp_code='''+@compcode+'''  and userid='''+@userid+'''  '
-- set @query1=' insert #pcmdummy select Comp_Code,Pub_cent_Code,Pub_Cent_name,Pub_Cent_Alias,Add1,street,Country_Code, State_Code,Dist_Code,City_Code,zip,Phone1,Phone2,Fax,EmailID, Pub_Cent_Status,getdate(),Remarks,UserId,getdate(),getdate(),creation_datetime,region_code,zone_code,Fax1,BOXADDRESS,PRINT_CENT  from pub_cent_mast where comp_code='''+@compcode+''' '
set @query1=' insert #pcmdummy select Comp_Code,Pub_cent_Code,Pub_Cent_name,Pub_Cent_Alias,Add1,street,Country_Code, State_Code,Dist_Code,City_Code,zip,Phone1,Phone2,Fax,EmailID, 
 (select top 1 status_name from tblstatus where status_code=(SELECT top 1 cent_status FROM pcm_status where pcm_status.center_code=pub_cent_mast.pub_cent_code and getdate() between FROM_DATE and TO_DATE) )  as   Pub_Cent_Status,
getdate(),Remarks,UserId,getdate(),getdate(),creation_datetime,region_code,zone_code,Fax1,BOXADDRESS,PRINT_CENT,FILE_PATH,CIR_FILE_PATH,CENTER_COMP_NAME,STATE  from pub_cent_mast where comp_code='''+@compcode+''' '


if(@centcode <> '' and @centcode<>'0')
begin

set @query1= @query1 + 'and  Pub_cent_Code like ''%'+@centcode +'%'''

end

if(@centname <> '' and @centname<>'0')
begin

set @query1  =  @query1 + 'and Pub_Cent_name  like ''%'+@centname +'%'''

end

if(@alias <> '' and @alias<>'0')
begin

set @query1  =  @query1 + 'and Pub_Cent_Alias  like ''%'+@alias+'%'''

end

if(@city <>'' and @city<>'0')
begin

set @query1  =  @query1 + 'and city_code  like ''%'+@city +'%'''

end


if(@country <>'' and @country <>'0')
begin

set @query1  =  @query1 + 'and Country_Code  like ''%'+@country+'%'''

end


if(@pcompname <>'' and @pcompname <>'0')
begin

set @query1  =  @query1 + 'and CENTER_COMP_NAME  like ''%'+@pcompname+'%'''

end


if(@pstate <>'' and @pstate <>'0')
begin

set @query1  =  @query1 + 'and STATE  like ''%'+@pstate+'%'''

end



print(@query1)

exec(@query1)

print(@query4)

exec(@query4)

print(@query2)

exec(@query2)


/*declare pcm cursor read_only
for 
select pub_cent_code from #pcmdummy order by pub_cent_code
--select pub_cent_code from #Pub_Cent_Mast order by pub_cent_code


open pcm

FETCH NEXT FROM pcm
INTO @pcm1

WHILE @@FETCH_STATUS = 0
BEGIN


set @query2='update #pcmdummy set Pub_Cent_Status=(select top 1 cent_status from pcm_status where center_code='''+@pcm1+''') where PUB_cent_code='''+@pcm1+''''

set @query3='update #pcmdummy set to_date=(select top 1 to_date from pcm_status where center_code='''+@pcm1+''' order by to_date desc) where PUB_cent_code='''+@pcm1+''''

set @querys='update #pcmdummy set from_date=(select top 1 from_date from pcm_status where center_code='''+@pcm1+''' order by from_date asc) where PUB_cent_code='''+@pcm1+''''

--set @querys='update #pcmdummy set from_date=(select top 1 from_date from pcm_status where center_code='''+@pcm1+''' order by from_date asc) where PUB_cent_code='''+@pcm1+''''

print(@query2)

exec(@query2)

print(@query3)

exec(@query3)

print(@querys)

exec(@querys)


	FETCH NEXT FROM pcm
	INTO @pcm1


end

CLOSE pcm
DEALLOCATE pcm*/


select  distinct * from #pcmdummy  order by pub_cent_code
drop table #pcmdummy



//////////////////////////////////////////////////////////////////////////////////////////////////////////////////



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[pcmupdate]

@compcode as varchar(8),
@centercode as varchar(8),
@centername as varchar(50),
@alias as varchar(50),
@add1 as varchar(50),
@street as varchar(50),
@city as varchar(15),
@dist as varchar(15),
@country as varchar(8),
@phone1 as varchar(5),
@phone2 as varchar(10),
@pin as varchar(15),
@state as varchar(15),
@fax as varchar(5),
@email as varchar(50),
--@status as varchar(15),
--@statusdate as varchar(15),
@remarks    as varchar(200),
--@userid as varchar(8),
@region as varchar(8),
@zone as varchar(8),
@fax1 as varchar(10),
@boxadd  varchar(200),
@printval as varchar(20),
@imgpath as varchar(50),
@cir_imgpath as varchar(50),
@pcompanyname as varchar(50),
@plogopath as varchar(50),
@pstate AS varchar(50)
AS

declare @query varchar(1000)
declare @query1 varchar(1000)

set @query=' update pub_cent_mast set Pub_Cent_name='''+@centername+''' , Pub_Cent_Alias='''+@alias+''' , Add1='''+@add1+''' , street='''+@street+''', Country_Code='''+@country+''', State_Code='''+@state+''', Dist_Code='''+@dist+''', City_Code='''+@city+''', zip='''+@pin+''', Phone1='''+@phone1+''', Phone2='''+@phone2+''',Fax='''+@fax+''', EmailID='''+@email+''',Remarks='''+@remarks+''',region_code='''+@region+''',zone_code='''+@zone+''',Fax1='''+@fax1+''' ,BOXADDRESS='''+@boxadd+''',PRINT_CENT='''+@printval+''',FILE_PATH='''+@imgpath+''',CIR_FILE_PATH='''+@cir_imgpath+''',CENTER_COMP_NAME='''+@pcompanyname+''',LOGO_FILE_PATH='''+@plogopath+''' ,STATE='''+@pstate+''' where comp_code='''+@compcode+'''   and   Pub_cent_Code='''+@centercode+'''   '

--set @query1=' update pcmdummy set Pub_Cent_name='''+@centername+''' , Pub_Cent_Alias='''+@alias+''' , Add1='''+@add1+''' , street='''+@street+''', Country_Code='''+@country+''', State_Code='''+@state+''', Dist_Code='''+@dist+''', City_Code='''+@city+''', zip='''+@pin+''', Phone1='''+@phone1+''', Phone2='''+@phone2+''',Fax='''+@fax+''', EmailID='''+@email+''',Remarks='''+@remarks+''',region_code='''+@region+''',zone_code='''+@zone+''',Fax1='''+@fax1+'''  where comp_code='''+@compcode+'''    and   Pub_cent_Code='''+@centercode+'''   '


print (@query)
exec(@query)
--print(@query1)
--exec(@query1)
/////////////////////////////////////////////////////////////////////////////////////////////////







//////////////////end of issue 8473////////////////

/////////////////////Issue no 7947////////////////////////////


alter table Exec_mast add ATTACHMENT varchar(50)     



USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[execcontactinsert]    Script Date: 09/06/2012 14:35:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








ALTER Procedure [dbo].[execcontactinsert]
@exename as varchar(30),
@teamcode as varchar(10),
@designation as varchar(30),
@address as varchar(50),
@street as varchar(30),
@city as varchar(20),
@district as varchar(18),

@state as varchar(18),
@country as varchar(10),
@pin as varchar(20),
@phone as varchar(50),
@status as varchar(18),
@compcode as varchar(10),
@userid as varchar(10),
@report as varchar(8),
@taluka1 as varchar(20),
@repname as varchar(50),
@adtype as varchar(8),
@zone as varchar(20),
@craditlimit as varchar(20),
@mobile as varchar(50),
@email as varchar(200),
@mailto as varchar(200),
@p_empcode as varchar(50),
@attachment as varchar(50)




as

declare @exeno as int
declare @query as varchar(1000)
declare @query2 as varchar(1000)

select @exeno= max(isnull(Exe_no,0)+1)  from exec_mast
if @exeno is null
	set @exeno=1
print(@exeno)
if @exeno is null
	set @exeno=1
insert into Exec_mast
(Exe_no,Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,phone,exe_status,userid,comp_code,pin_code,report_to,TALUKA,creation_datetime,REPRESENTATIVE,ADTYPE,Branch_code,CREDIT_LIMIT,MOBILENO,EMAILID,HR_CODE,EMAIL_ID,ATTACHMENT) 
 values(@exeno  ,@teamcode,@exename,@designation,@address,@street ,@country,@state,@district,@city,@phone,@status,@userid,@compcode,@pin,@report,@taluka1,getdate(),@repname,@adtype,@zone,@craditlimit,@mobile,@email,@p_empcode,@mailto,@attachment)/*'''+@EXEC_USERID+''','''+@EXEC_EMAILID+'''*/
--print(@query)
exec(@query)
--set @query='insert into tmp_exec_mast(Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,phone,exe_status,userid,comp_code,pin_code)  values('''+@teamcode+''','''+@exename+''','''+@designation+''','''+@address+''','''+@street+''' ,'''+@country+''','''+@state+''','''+@district+''','''+@city+''','''+@phone+''','''+@status+''','''+@userid+''','''+@compcode+''','''+@pin+''')'



set @query2='update Exec_mast set city_name=(select city_name from city_mst where comp_code = '''+@compcode+''' and city_code='''+@city+''') where comp_code = '''+@compcode+''' and city_code='''+@city+''' '
select @exeno as 'exeno'
print(@query2)
exec(@query2)










//////////////////////////////////////////////////////////////////////////////////////////////



USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[execcontactupdate]    Script Date: 09/06/2012 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







ALTER Procedure [dbo].[execcontactupdate]
@exename as varchar(30),
@teamcode as varchar(10),
@designation as varchar(30),
@address as varchar(50),
@street as varchar(30),
@city as varchar(10),
@district as varchar(18),

@state as varchar(18),
@country as varchar(10),
@pin as varchar(20),
@phone as varchar(50),
@status as varchar(10),
@compcode as varchar(10),
@userid as varchar(10),
@code as varchar(10),
@report as varchar(8),
@TALUKA1 as varchar(23),
@repname as varchar(50),
@adtype as varchar(8),
@branchcode as varchar(20),
@craditlimit as varchar(20),
@mobile as varchar(50),
@email as varchar(200),
@mailto as varchar(200),
@p_empcode as varchar(50),
@pattachment as varchar(50)


as

declare @query as varchar(1000)

declare @query2 as varchar(1000)

--set @query='insert into Exec_mast(Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,phone,exe_status,userid,comp_code,pin_code)  values('''+@teamcode+''','''+@exename+''','''+@designation+''','''+@address+''','''+@street+''' ,'''+@country+''','''+@state+''','''+@district+''','''+@city+''','''+@phone+''','''+@status+''','''+@userid+''','''+@compcode+''','''+@pin+''')'

set @query='update  Exec_mast set  Exec_name='''+@exename+''' ,Designation='''+@designation+''',Add1='''+@address+''',Street='''+@street+''',Country_code='''+@country+''',State_code='''+@state+''',dist_code='''+@district+''',city_code='''+@city+''',phone='''+@phone+''',exe_status='''+@status+''' ,pin_code='''+@pin+''', report_to='''+@report+''',TALUKA='''+@TALUKA1+''',REPRESENTATIVE='''+@repname+''',ADTYPE='''+@adtype+''',Branch_code='''+@branchcode+''',CREDIT_LIMIT='''+@craditlimit+''',MOBILENO='''+@mobile+''',EMAILID='''+@email+''',HR_CODE='''+@p_empcode+''',EMAIL_ID='''+@mailto+''',ATTACHMENT='''+@pattachment+''' where comp_code='''+@compcode+''' and Exe_no='''+@code+'''   ' --EXEC_EMAILID='''+@EXEC_EMAILID+''',EXEC_USERID='''+@EXEC_USERID+'''
print(@query)
exec(@query)


set @query2='update Exec_mast set city_name=(select city_name from city_mst where city_code='''+@city+''' and exec_mast.comp_code=city_mst.comp_code) where city_code='''+@city+''' '
print(@query2)
exec(@query2)



/////////////////////////////////////////////////////////////////////////////////////






USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[execcontactbind_grid]    Script Date: 09/06/2012 15:02:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






ALTER PROCEDURE [dbo].[execcontactbind_grid]

@teamcode as varchar(30),
@compcode as varchar(30),
@userid as varchar(30)

AS
declare @Designation1 varchar(350)
declare @Country_code1 as varchar(520)
declare @city_code1 varchar(250)
declare @report_to1 varchar(250)
declare @Exec_name as varchar(350)
declare @Designation varchar(350)
declare @Add1 varchar(505)
declare @Street varchar(505)
declare @city_code varchar(58)
declare @dist_code varchar(158)
declare @State_code varchar(158)

declare @Country_code as varchar(85)
declare @pin_code varchar(205)
declare @phone varchar(350)
declare @exe_status varchar(520)
declare @Exe_no varchar(205)
declare @TALUKACODE varchar(100)
declare @TALUKA2 varchar(385)
declare @city_name varchar(250)
declare @Team_code varchar(58)
declare @zip varchar(105)
declare @comp_code varchar(58)

declare @report_to varchar(85)
declare @exec_userid varchar(85)
declare @exec_emailid varchar(105)
declare @creation_datetime varchar(105)
declare @repname varchar(350);
declare @Repcode  varchar(350);
declare @Branch_code varchar(50);
declare @Branch_Name varchar(100);
declare @ATTACHMENT varchar(100);
declare @query as varchar(4005)


--select ContractCode,Advcategory,publication,suppliment,edition,Bookedfor,color,cardrate,Dealarte,premiumcode,cardpremium,dealpremium,volumebilled,volumedisc,valuefrom,valueto,Uom,packagecode from contract_detail where comp_code=@compcode and userid=@userid and deal_code=@dealno
CREATE TABLE #tmpExec_mast  (
	Exe_no int  ,
	Team_code varchar (53)  ,
	Exec_name varchar (50)  ,
	Designation varchar (50)  ,
	Add1 varchar (60)  ,
	Street varchar (60)  ,
	Country_code varchar (38)  ,
	State_code varchar (38)  ,
	dist_code varchar (38)  ,
	city_code varchar (38)  ,
	zip varchar (30)  ,
	phone varchar (40)  ,
	exe_status varchar (50)  ,
	userid varchar (48)  ,
	comp_code varchar (48)  ,
	--creation_datetime datetime  ,
	pin_code varchar (40)  ,
	CIty_Name varchar (40)  ,
	report_to varchar (48) ,
    exec_userid varchar (100) ,
    exec_emailid varchar (80)   ,
    TALUKA  varchar (23) ,
    REPRESENTATIVE varchar (50),
    Branch_code varchar (20),
    ATTACHMENT varchar(100)
) 

	
DECLARE sss CURSOR 
--FOR select distinct Advcategory,publication,suppliment,edition, currency,contractcode,color,uom,packagecode,premiumcode from contract_detail where comp_code=@compcode and userid=@userid and deal_code=@dealno
--FOR select Exec_name,Designation,Add1,Street,city_code,dist_code,State_code,Country_code,pin_code,phone,exe_status,Exe_no,city_name,Team_code,zip,comp_code,userid,report_to from Exec_mast where comp_code=@compcode  and Team_code =@teamcode
FOR select distinct  Designation,city_code,Country_code,report_to,Exe_no,TALUKA ,REPRESENTATIVE,Branch_code,ATTACHMENT  from Exec_mast where comp_code=@compcode  and Team_code =@teamcode



OPEN sss
FETCH NEXT FROM sss into @Designation,@city_code,@Country_code,@report_to,@Exe_no,@TALUKACODE,@Repcode,@Branch_code,@ATTACHMENT


WHILE @@FETCH_STATUS = 0
BEGIN

select @Designation1=Agency_Role_Name from Agency_Role_Master where Agency_Role_Code=@Designation
select @city_code1=city_name from city_mst where city_code=@city_code
select @Country_code1=country_name from count_mst where country_code=@Country_code
select @Branch_Name=branch_name from branch_mst where branch_code=@Branch_code
if(@report_to <> '0')
begin
select @report_to1=Name_all from all_module_master where All_module_code=@report_to
end
else
begin
set @report_to1=''
end
select @TALUKA2=TALU_NAME  from taluka_mast where TALU_CODE=@TALUKACODE

select @repname=Rep_Name  from rep_mast where Rep_code=@Repcode





--insert into #tmpContract_detail select ContractCode,@Advcategoryname,@publicationname,@supplimentname,@editionname,Bookedfor,@packagecode,@colorname,cardrate,Dealarte,@premiumcode,cardpremium,dealpremium,volumebilled,volumedisc,valuefrom,valueto,@uomname, @currencyname, convertrate,deal_code,ContractCode,editionaldisc,approved,quantity,weight,discounted,Cyop,deviation from contract_detail where comp_code=@compcode and userid=@userid and deal_code=@dealno and contractcode=@contractcode

insert into #tmpExec_mast select distinct Exe_no,Team_code,Exec_name,@Designation1,Add1,Street,@Country_code1,State_code,dist_code,@city_code1,zip,phone,exe_status,userid,comp_code,pin_code,city_name,@report_to1,exec_userid,exec_emailid ,@TALUKA2 ,@repname as repname,@Branch_Name,@ATTACHMENT from Exec_mast where comp_code=@compcode  and Team_code =@teamcode and Exe_no=@Exe_no
set @report_to1=''
set @EXEC_USERID=''
set @EXEC_EMAILID=''
set @TALUKA2=''
set @repname=''
FETCH NEXT FROM sss into @Designation,@city_code,@Country_code,@report_to,@Exe_no,@TALUKACODE,@Repcode,@Branch_code,@ATTACHMENT
end
CLOSE sss
DEALLOCATE sss

--select * from #tmpContract_detail


--select *  from #tmpExec_mast


set @query='select  distinct Exe_no,Exec_name, Designation,Add1,Street, city_code,dist_code,State_code, Country_code,pin_code,phone,exe_status,Exe_no,city_name,Branch_code,report_to,exec_userid,exec_emailid ,TALUKA , REPRESENTATIVE as repname,ATTACHMENT from #tmpExec_mast'


--delete from #tmpExec_mast


print(@query)
exec(@query)
drop table #tmpExec_mast
--select ContractCode,Advcategory,publication,suppliment,edition,Bookedfor,packagecode,color,cardrate,Dealarte,premiumcode,cardpremium,dealpremium,volumebilled,volumedisc,valuefrom,valueto,Uom, currency, convertrate,deal_code,ContractCode from contract_detail where comp_code=@compcode and userid=@userid and deal_code=@dealno






////////////////////////////////////////////////////////////////////////////////////////////



///////////////////end of issue 7947///////////////////////////////////


/******************************************issue no 7948 updated by Dhananjay****************/
ALTER procedure [dbo].[rpt_vts_report]
@pagency_code as varchar(50),
@pclient_code as varchar(50),
@pfrom_date as varchar(20),
@pto_date as varchar(20),
@pdateformat as varchar(20),
@ppublication as varchar(50),
@pedition as varchar(50),
@ppub_center as varchar(50),
@pbranch as varchar(50),
@pcompcode as varchar(20),
@puserid as varchar(20),
@chk_access as varchar(20),
@clienttype as varchar(8),
@pextra1 as varchar(50),
@pextra2 as varchar(50)
as 
declare @query1 varchar(8000)

begin
set @query1='select distinct a."Comp_code", a."cio_booking_id" as "CIOID",a."date_time" as bkdate, 
c.Agency_Name AS "AGENCY",c."Add1",c."Add2",c."Add3",(select "City_Name" from city_mst where "City_Code"=c."City_Code") city_name,c."Dist_Code",c."State_Code",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE a.comp_code=CUST_MAST.comp_code AND Cust_Code=Client_code),Client_code)  AS "CLIENT", 
isnull((SELECT "Add1" FROM  CUST_MAST WHERE a."Comp_code"= CUST_MAST."Comp_Code" AND "Cust_Code"=a."Client_code"),a."Client_address")  AS "CLIENT_ADDR", 
b.Edition as "EDITION",
CASE '''+@pdateformat+'''
 WHEN ''mm/dd/yyyy'' THEN CONVERT(varchar(10),Insert_Date,101)
WHEN ''dd/mm/yyyy'' THEN CONVERT(varchar(10),Insert_Date,103)
WHEN ''yyyy/mm/dd'' THEN CONVERT(varchar(10),Insert_Date,111)  END AS "PUB_DATE" ,
a."NO_OF_INSERTION",
isnull(a.Agrred_rate,a.Card_rate ) AS "RATE",
(select Comp_Name from comp_mst where comp_mst.Comp_Code=a.Comp_code) comp_name,
(select "Package_Name" from combin_mast where "Combin_Code"=b.package_code) package_name,
case when a."Vts"='+''''+''''+' then 0 else cast(isnull(a."Vts",0) as numeric) end AS "VTS",case when CIRRATE='+''''+''''+' then 0.00 else cast(isnull(a.CIRRATE,0) as numeric) END as "CIRRATE"
from tbl_booking_mast a,tbl_booking_insert b,agency_mast c
   WHERE a.Comp_code='''+@pcompcode+''' 
     AND a.Agency_sub_code=c.code_subcode 
     AND a.cio_booking_id=b.Cio_Booking_Id 
     and case when a."Vts"='+''''+''''+' then 0 else cast(isnull(a."Vts",0) as numeric) end>0
     and exists (select cioid from tbl_booking_vts 
                  where compcode=a.comp_code
                    and cioid=a.cio_booking_id)
     and ((b.Pub_Cent_Code in (select distinct pub_center from login_center 
                                  where newuser_id='''+@puserid+''') 
                                   and '''+@chk_access+'''=''1'') or  ('''+@chk_access+'''=''0'') )'

IF(@pfrom_date IS NOT NULL AND @pto_date IS NOT NULL)
begin
set @query1=@query1+' and b.Insert_Date between  '''+@pfrom_date +''' and  '''+@pto_date+''' '
END

IF(@pagency_code IS NOT NULL )
begin
set @query1=@query1+' and a.Agency_code =  '''+@pagency_code+''' '
END

IF(@pclient_code IS NOT NULL )
begin
set @query1=@query1+' and a.Client_code='''+@pclient_code +''''
END

IF(@ppublication IS NOT NULL )
begin
set @query1=@query1+' and  b.Publication_Code='''+@ppublication+''''
END

IF(@ppub_center IS NOT NULL )
begin
set @query1=@query1+'  and b.Pub_Cent_Code='''+@ppub_center+''''
END

IF(@pedition IS NOT NULL )
begin
set @query1=@query1+'  and b.Edition_Code='''+@pedition+''''
END

IF(@pbranch IS NOT NULL )
begin
set @query1=@query1+'  and a.branch='''+@pbranch+''''
END

if (@clienttype is not null or @clienttype<>'')
  Begin
    if @clienttype = 'R'
      Begin
         set @query1=@query1+'  and client_code in (select cust_code from cust_mast where comp_code = '''+@pcompcode+''''+'and cust_status=''ACTIVE'')'
      End
    else if @clienttype = 'N'
      Begin
         set @query1=@query1+'  and client_code not in (select cust_code from cust_mast where comp_code = '''+@pcompcode+''''+'and cust_status=''ACTIVE'')'
      End
    else
      Begin
         set @query1=@query1
      End   
   End

print(@query1)
exec(@query1)

end



/****************************End*********************************/


/********************issue no 7931 updated by Dhananjay*****************/



CREATE PROCEDURE [dbo].[rpt_categorywisedate_summary_rpt_categorywisedate_billing] 
   (
      @pcompcode         as VARCHAR(10),
      @ppcentcode        as VARCHAR(10),
      @punitcode         as VARCHAR(10),
      @padtype           as VARCHAR(20),
      @padcat            as VARCHAR(20),
      @padsubcat         as VARCHAR(20),
      @pad_subcat3       as VARCHAR(20),
      @pad_subcat4       as VARCHAR(20),
      @pad_subcat5       as VARCHAR(20),
      @pdist_code        as VARCHAR(20),
      @pfrom_date        as VARCHAR(20),
      @ptill_date        as VARCHAR(20),
      @pdateformat       as VARCHAR(20),
      @puserid           as VARCHAR(20),
      @ppublcode         as VARCHAR(20),
      @pedtncode         as VARCHAR(20),
      @pteamcode         as VARCHAR(20),
      @pexecode          as VARCHAR(20),
      @pextra1           as VARCHAR(20),
      @pextra2           as VARCHAR(20),
      @pextra3           as VARCHAR(20),
      @pextra4           as VARCHAR(20),
      @pextra5           as VARCHAR(20)
     )
  As
  
  declare @v_frdt as datetime
declare @v_todt as datetime 
 
 SELECT @v_frdt  = @pfrom_date--CONVERT(DATETIME, @pfrom_date)
 SELECT @v_todt  =  @ptill_date--CONVERT(DATETIME, @pto_date)
 
   declare @v1_comp_code    varchar(200)
    declare @v1_ad_cat       varchar(200)
    declare @v1_adcat_name   varchar(200)
    declare @v1_ad_sub_cat   varchar(200)
    declare @v1_ad_subcat3   varchar(200)      
    declare @v1_ad_subcat4   varchar(200)      
    declare @v1_ad_subcat5   varchar(200)
    declare @v1_insertion    int
    declare @v1_book_area    decimal(18,2)
	declare @v1_line_area    decimal(18,2)
    declare @v1_amt          decimal(15,2)
    declare @v_rec_seqno     int
    declare @v_adsubcat_nm   varchar(500)
    declare @v_adsubcat_nm3  varchar(500)
    declare @v_adsubcat_nm4  varchar(500)
    declare @v_adsubcat_nm5  varchar(500)
    declare @v1_insert_date  date;
     declare @v1_disp_area  varchar(500)

  Begin
    	CREATE TABLE #TEMP_AD_RECEIPT_REPORT
		(COMP_CODE         VARCHAR(10),
		UNIT_CODE         VARCHAR(10),
		PCENTRE_CODE      VARCHAR(10),
		ad_package        varchar(100),
		insert_date       datetime,
		recovary_days      int,
        ret_code           varchar(100),
        exe_code           varchar(100),
		ad_main_category  VARCHAR(500),
		ad_sub_category	  VARCHAR(500),
		ad_sub_category3  VARCHAR(500),
		ad_sub_category4  VARCHAR(500),
		ad_sub_category5  VARCHAR(500),	  	  
		NO_OF_INSERTION   INT,
		AD_SIZE           DECIMAL(18,2),
		AMOUNT            DECIMAL(14,2)                DEFAULT 0,
		REC_SEQNO         INT,
		AD_RATE			  DECIMAL(18,2)) 
     

     DECLARE c1 cursor LOCAL FOR 
      select x.comp_code comp_code,x.ad_cat ad_cat,x.adcat_name adcat_name,
        x.ad_sub_cat ad_sub_cat,x.ad_subcat3 ad_subcat3,x.ad_subcat4 ad_subcat4,x.ad_subcat5 ad_subcat5,
        x.insertion_no insertion_no,x.disp_book_area disp_book_area,isnull(x.disp_amount,0)+isnull(x.lineage_amount,0) amount,
        x.lineage_book_area lineage_book_area,x. insert_date  insert_date from
        (select m."Comp_code" comp_code,i."Ad_Cat" ad_cat,c."Adv_Cat_Name" adcat_name,
        i."Ad_Sub_Cat" ad_sub_cat,i."AD_SUBCAT3" AD_SUBCAT3,i."AD_SUBCAT4" AD_SUBCAT4,i."AD_SUBCAT5" AD_SUBCAT5,
        count(i."No_Insert") insertion_no,sum(i."Size_Book") disp_book_area,round(Sum(CONVERT(FLOAT,"Bill_Amt")),2) disp_amount,
        0 lineage_book_area,0 lineage_amount,i."Insert_Date" as  insert_date
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=@pcompcode and c."Comp_Code"=m."Comp_code" and c."Adv_Cat_Code"=i."Ad_Cat" and
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"+a."SUB_Agency_Code"=m."Agency_sub_code" and
        i."Insert_Date" between @v_frdt and @v_todt and (m."Ad_type_code"=@padtype or @padtype is null) and
        i."Insert_Status" in('publish','audit by rate','billed') and
        (i."Ad_Cat"=@padcat or @padcat is null) and (i."Ad_Sub_Cat"=@padsubcat or @padsubcat is null) and
        (i."AD_SUBCAT3"=@pad_subcat3 or @pad_subcat3 is null) and (i."AD_SUBCAT4"=@pad_subcat4 or @pad_subcat4 is null) and
        (i."AD_SUBCAT5"=@pad_subcat5 or @pad_subcat5 is null) and
        (a.district =@pdist_code or @pdist_code is null) and
        m."branch"=b."Branch_Code" and
        (b."Branch_Code"=@punitcode or @punitcode is null) and (b."pub_center"=@ppcentcode or @ppcentcode is null) and
        (m."Executive_code"=@pexecode or @pexecode is null) and
        (i."Publication_Code"=@ppublcode or @ppublcode is null) and (i."Edition_Code"=@pedtncode or @pedtncode is null) and
        (i."Height" is not null and i."Width" is not null)
        group by m."Comp_code",i."Ad_Cat",c."Adv_Cat_Name",i."Ad_Sub_Cat",i."AD_SUBCAT3",i."AD_SUBCAT4",i."AD_SUBCAT5",i."Insert_Date"
        union all
        select m."Comp_code" comp_code,i."Ad_Cat" ad_cat,c."Adv_Cat_Name" adcat_name,
        i."Ad_Sub_Cat" ad_sub_cat,i."AD_SUBCAT3" AD_SUBCAT3,i."AD_SUBCAT4" AD_SUBCAT4,i."AD_SUBCAT5" AD_SUBCAT5,
        count(i."No_Insert") insertion_no,0 disp_book_area,0 disp_amount,
        sum(i."Size_Book") lineage_book_area,round(Sum("Bill_Amt"),2) lineage_amount,i."Insert_Date" as  insert_date
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=@pcompcode and c."Comp_Code"=m."Comp_code" and c."Adv_Cat_Code"=i."Ad_Cat" and
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"+a."SUB_Agency_Code"=m."Agency_sub_code" and
        i."Insert_Date" between @v_frdt and @v_todt and (m."Ad_type_code"=@padtype or @padtype is null) and
        i."Insert_Status" in('publish','audit by rate','billed') and
        (i."Ad_Cat"=@padcat or @padcat is null) and (i."Ad_Sub_Cat"=@padsubcat or @padsubcat is null) and
        (i."AD_SUBCAT3"=@pad_subcat3 or @pad_subcat3 is null) and (i."AD_SUBCAT4"=@pad_subcat4 or @pad_subcat4 is null) and
        (i."AD_SUBCAT5"=@pad_subcat5 or @pad_subcat5 is null) and
        (a.district =@pdist_code or @pdist_code is null) and
        m."branch"=b."Branch_Code" and
        (b."Branch_Code"=@punitcode or @punitcode is null) and (b."pub_center"=@ppcentcode or @ppcentcode is null) and
        (m."Executive_code"=@pexecode or @pexecode is null) and
        (i."Publication_Code"=@ppublcode or @ppublcode is null) and (i."Edition_Code"=@pedtncode or @pedtncode is null) and
        (i."Height" is null and i."Width" is null)
        group by m."Comp_code",i."Ad_Cat",c."Adv_Cat_Name",i."Ad_Sub_Cat",i."AD_SUBCAT3",i."AD_SUBCAT4",i."AD_SUBCAT5",i."Insert_Date") x
        order by comp_code,insert_date,ad_cat,adcat_name,ad_sub_cat,ad_subcat3,ad_subcat4,ad_subcat5;

   

   
   
  open c1
   
   PRINT('11')
   
        fetch NEXT FROM c1 into @v1_comp_code,@v1_ad_cat,@v1_adcat_name,@v1_ad_sub_cat,@v1_ad_subcat3,@v1_ad_subcat4,@v1_ad_subcat5,@v1_insertion,@v1_disp_area,@v1_amt,@v1_line_area,@v1_insert_date
        
 WHILE (@@FETCH_STATUS = 0) 
	Begin
	set @v_rec_seqno=ISNULL(@v_rec_seqno,0)+1
        set @v_adsubcat_nm   =DBO.AD_GET_catnameE (@v1_comp_code,@v1_ad_sub_cat,'subcat');
       set @v_adsubcat_nm3  =DBO.AD_GET_catnameE (@v1_comp_code,@v1_ad_subcat3,'cat3');
        set @v_adsubcat_nm4  =DBO.AD_GET_catnameE (@v1_comp_code,@v1_ad_subcat4,'cat4');
       set @v_adsubcat_nm5  =DBO.AD_GET_catnameE (@v1_comp_code,@v1_ad_subcat5,'cat5');
       insert into #TEMP_AD_RECEIPT_REPORT
                (comp_code,unit_code,pcentre_code,ad_main_category,ad_sub_category,ad_package,ret_code,exe_code,recovary_days,ad_size,
                amount,rec_seqno,ad_rate,insert_date)
          values(@pcompcode,@punitcode,@ppcentcode,@v1_adcat_name,@v_adsubcat_nm,@v_adsubcat_nm3,@v_adsubcat_nm4,@v_adsubcat_nm5,@v1_insertion,@v1_disp_area,
                @v1_amt,@v_rec_seqno,@v1_line_area,@v1_insert_date);
                 fetch NEXT FROM c1 into @v1_comp_code,@v1_ad_cat,@v1_adcat_name,@v1_ad_sub_cat,@v1_ad_subcat3,@v1_ad_subcat4,@v1_ad_subcat5,@v1_insertion,@v1_disp_area,@v1_amt,@v1_line_area,@v1_insert_date
   end
    close c1
    deallocate c1
	print('close cursor c1')

   
    select distinct a.comp_code as COMP_CODE,
    a.ad_main_category as AD_MAIN_CAT,a.ad_sub_category as AD_SUB_CAT,
    a.ad_package as AD_SUB_CAT3,
    (select "Comp_Name" from comp_mst where "Comp_Code"=a.comp_code)  as "CNAME",
    sum(a.recovary_days) as NO_OF_INSERTION,sum(a.ad_size) as BOOK_AREA,sum(a.amount) as AMOUNT,
    sum(a.ad_rate) as LINE_AREA,a.insert_date
    from #TEMP_AD_RECEIPT_REPORT a
    
    group by a.comp_code,a.ad_main_category,a.ad_sub_category,a.ad_package,a.insert_date
    ORDER BY insert_date

   
    select distinct a.comp_code as COMP_CODE,
    a.ad_main_category as AD_MAIN_CAT,a.ad_sub_category as AD_SUB_CAT,
    (select "Comp_Name" from comp_mst where "Comp_Code"=a.comp_code)  as "CNAME",
    sum(a.recovary_days) as NO_OF_INSERTION,sum(a.ad_size) as BOOK_AREA,sum(a.amount) as AMOUNT,
    sum(a.ad_rate) as LINE_AREA,a.insert_date
    from #TEMP_AD_RECEIPT_REPORT a
    
    group by a.comp_code,a.ad_main_category,a.ad_sub_category,a.insert_date
    ORDER BY insert_date

    
    select distinct a.comp_code as COMP_CODE,
    a.ad_main_category as AD_MAIN_CAT,
    (select "Comp_Name" from comp_mst where "Comp_Code"=a.comp_code)  as "CNAME",
    sum(a.recovary_days) as NO_OF_INSERTION,sum(a.ad_size) as BOOK_AREA,sum(a.amount) as AMOUNT,
    sum(a.ad_rate) as LINE_AREA,a.insert_date
    from #TEMP_AD_RECEIPT_REPORT a
    group by a.comp_code,a.ad_main_category,a.insert_date
    ORDER BY a.insert_date

   
	DROP TABLE #TEMP_AD_RECEIPT_REPORT 
End






/*********************END**********************/



///////////////issue no 8461/////////////////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[currbindpreferpgld]    Script Date: 09/11/2012 14:33:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[currbindpreferpgld]
@compcode as varchar(8)

AS

/*select date_format,autogenerated,currency_code,rate_gr_code,solo,breakup,blackwhitecode,rostatus,File_name,Tfn,Insert_breakup  , prefix,suffix,financestatus,voucherst,Ad_category,Ro_datetime,Vat,Booking_status,Cio_id,Receipt_no,uom_code,Bgcolor_publication,chkfor_valid_pubdates,
Agency_ratecode,audit,book_insert_date,agencycomm,rate_audit,bill_audit,billtype,Premium_type,copy_booking,RATE_COMPANY_AGENCY,ADDITIONAL_AGENCY_COMM,AGENCY_RETAINER_COMM,SUBEDITIONRATE,CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT,RATE_CHECK,ALL_PACKAGE,DAYRATE,SCHEME_TYPE,DISP_CLSBILL, RECEIPT_FORMAT ,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF ,  FMG_BILL_DIS,BARCODING_ALLOWED,BILL_DISP_CASHBILL,BILL_CLA_CASHBILL ,BACKDATERECEIPT,ROWISE_CASHBOOKING from preferrences where comp_code=@compcode
*/

  SELECT date_format, autogenerated, currency_code,
                rate_gr_code, solo, breakup, blackwhitecode,
                rostatus, File_name, Tfn, Insert_breakup, prefix,
                suffix, financestatus, voucherst, Ad_category,
                Ro_datetime, Vat, Booking_status, Cio_id,
                Receipt_no,uom_code,Bgcolor_publication,chkfor_valid_pubdates,Agency_ratecode,audit,book_insert_date,agencycomm,
                rate_audit,bill_audit,billtype,Premium_type,copy_booking,RATE_COMPANY_AGENCY,ADDITIONAL_AGENCY_COMM,AGENCY_RETAINER_COMM,SUBEDITIONRATE,CLS_BILLTYPE,DIS_BILLTYPE,
				BILLING_FORMAT,RATE_CHECK,ALL_PACKAGE,dayrate,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,
                ROKEYCHECK, AGENCYCOMM_SEQ_COM, CREDIT_RECIPT,  DISP_CASHBILL, CLA_CASHBILL,
				RATE_AUDIT_PREF,BARCODING_ALLOWED, FMG_BILL_DIS,BILL_DISP_CASHBILL, BILL_CLA_CASHBILL,BACKDATERECEIPT,ROWISE_CASHBOOKING,CUTOFFTIME,DOCKIT_BOOKING,APPROVAL,back_days as BACK_DAYS,CASH_DISCOUNT,CASH_DISCOUNTTYPE,Allowed_old_date,SEPRATE_CASHIER,
                CIR_MANY_TIME_POSTING, CIR_BACKDAYS_POSTING, CIR_MAX_RETURN_ALLOW, CIR_RETURN_LIMIT_ALLOW, CIR_NO_OF_CHQBOUNCE, CIR_DAYS_CHQBOUNCE, CIR_RETURN_DAYS, CIR_SUP_ORDER_LIMIT, DISP_BILLING_CRITERIA, CLSD_BILLING_CRITERIA,MAX_PUBLISHDAYS,BILLNO_PERIODICITY, SPECIALDISC_TRANS_EDIT, SHARING_TRANS, MULTIPACKAGE_SEL_TRANS,SCHEME_MINWORD, TRADE_SPLCHARGE,RATE_AUTHORIZATION,F2_RECORD,PUBLISHAD_EDIT_RATEAUDIT,BINDREVENUE_CENTER, FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,REPEAT_DAY_TYPE,PREMIUM_EDIT,
BILL_GENERATION_PRIOR,PUBLICATION_HO,SPLDISC_ALLOWPREM,BILL_SCHEME,
ALLOWED_PDC_DAYS_RECEIPT,AD_TYPE_MANUL_BILL, OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD,DISP_AUDITBKG,CIR_DIS_AUTO_POSTING,RELAUTHREQON,
CIR_AUTO_APPROVAL_UNSOLD, CIR_AUTO_PHYSICAL_UNSOLD, CIR_UNSOLD_INCLUDE_INCT, CIR_UNSOLD_INCLUDE_INSFEE, CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,Space_area,EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE,TAXI_ENTRY_TYPE,APPROVAL_WITH,   TDS_AUTO_CN,TDS_AUTO_REASON,TDS_DB_CDP,TDS_CR_CDP,SER_TAX_AUTO_CN,SER_TAX_AUTO_REASON,SER_TAX_DB_CDP,SER_TAX_CR_CDP,PKK_AUTO_CN,PKK_AUTO_REASON,PKK_DB_CDP,PKK_CR_CDP,BANK_CHG_AUTO_CN,BANK_CHG_AUTO_REASON,BANK_CHG_DB_CDP,BANK_CHG_CR_CDP ,


CIR_BARCODE,CIR_WIEGHT_CALC_REQ,GEN_RCT_TYP,PRODUCT_BRAND_REQ,ALLOWPREM_CARD_DISC_RATE,FINANCE_CADE,EXECUTIVE_PUBLICATION_VISE,EXECUTIVECREDITLIMIT,
---NEW ADD
    CIR_POST_DIS,
	CIR_VAT_ALLOW,
	CIR_SUP_ALT_ROUTE,
	SHOW_REC_ALL_AGENCY,
	CIR_SUP_ORDER_DEC_LIMIT,
	CIR_ALLOW_HOLIDAY_SUN,
	CIR_ALLOW_HOLIDAY_MON,
	CIR_ALLOW_HOLIDAY_TUE,
	CIR_ALLOW_HOLIDAY_WED,
	CIR_ALLOW_HOLIDAY_THU,
	CIR_ALLOW_HOLIDAY_FRI,
	CIR_ALLOW_HOLIDAY_SAT
	
           FROM PREFERRENCES
          WHERE comp_code = @compcode






/////////////////////////////////////////////////////

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[wesp_updatedate1]    Script Date: 09/11/2012 14:28:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE   [dbo].[wesp_updatedate1]

@compcode as varchar(15),
@userid as varchar(15),
@dateformat as varchar(15),
@code as varchar(4),
@curr as varchar(8),
@ratecode as varchar(8),
@solo as varchar(15),
@breakup as varchar(2),
@bwcode as varchar(8),
@rostatus as varchar(2),
@filename as varchar(2),
@tfn as VARCHAR(4),
@insertbreak as varchar(2),
@prem as varchar(8),
@dealtype as varchar(2),
@pre as varchar(5),
@suff as varchar(5),
@financestatus as  char(2),
@voucherst as varchar(30),
@adcode as varchar(100),
@rodatetime as varchar(8),
@spacearea as varchar(8),
@vat as varchar(50),
@bookstat as varchar(25),
@cio_id as varchar(8),
@receipt_no as varchar(50),
@uom as varchar(8),
@bgcolor as varchar(10),
@validdate as varchar(10),
@agencyratecode as varchar(10),
@audit as varchar(8),
@book_insert_date as varchar(8),
@agencycomm as varchar(8),
@rateaudit as varchar(8),
@billaudit as varchar(8),
@billtype as varchar(8),
@invoice_no as varchar(50),
@copybooking as varchar(8),
@ratecompany as varchar(50),
@addagenycomm as varchar(50),
@agencycommlinkretainer as varchar(50),
@subeditionr as varchar(50),
@displaybilltype as varchar(50),
@classifiedbilltype as varchar(50),
@billformat as varchar(50),
@ratechk as varchar(50),
@allpkg as varchar(50),
@dayrate1 as varchar(50),
@schemetype as varchar(50),
@PIncludeclassi as varchar(50),
@receiptformat as varchar(50),
@cash_receipt as varchar(50),
@bill_orderwiselast as varchar(50),
@floor_chk as varchar(50),
@Unsoldflag as varchar(1),
@Supplystopper as varchar(10),
@drpRokeychk as varchar(1),
@Agencycomm_seq as varchar(1),
@creditreciept as varchar(1),
@cashindisplay as varchar(8),
@cashinclassified as varchar(8),
@rate_audit_pref as varchar(25),
@v_barcoding_allow as varchar(25),
@v_fmgbills AS VARCHAR(25),
@v_billed_cashdis as varchar(25),
@v_billed_cashcls as varchar(25),
@v_drpbackdate as varchar(25),
@dockitbooking as varchar(1),
@allowprevbooking as varchar(1),
@ro_wisecashbill as varchar(50),
@chkval as varchar(5),
@approval1 as varchar(50),
@pckstatus as varchar(3),
@cash_disc as varchar(1),
@cash_amt as varchar(10),
@seperate_cashier1 as varchar(10),
@disp_bill as varchar(1),
@clas_bill as varchar(1),
@mantimepost as varchar(1),
@bkdaypost as int,
@maxterutn as int,
@cir_return as varchar(1),
@noofchkbounc as int,
@noofdaychkrec as int,
@retday as int,
@chngsuppord as int,
@max_publishday as int,
@p_billno_period as varchar(15),
@spl_trans_edit as varchar(5),
@spl_dis_trans_editable as varchar(5),
@mul_pac_sel_trans as varchar(5),
@shmon_minword	as varchar(1),
@tradon_spcrg	as varchar(1),
@rateauth       as varchar(1),
@f2day as int,
@rateauditmodify as varchar(1),
@bindrevenuecenter as varchar(1),
@p_led_allow as varchar(2),
@p_clear_allow as varchar(2),
@repeatday as varchar(2),
@premiumedit as varchar(2),
@P_BILL_GENERATION as varchar(20),
@P_PUBLICATION_CENTER as varchar(50),
@P_allow_discount_prem as varchar(1),
@P_SCHEME_BILLING as varchar(50),
@P_ALLOW_PDC as varchar(50),
@PAD_TYPE_FOR_MANUL_BILL AS VARCHAR(20),
@RO_OUTSTAND_P AS VARCHAR(5),
@genrate_agency_code AS VARCHAR(5),
@p_dispauditbk AS VARCHAR(5),
@p_aotosupply  AS VARCHAR(5),
@p_Authorization as VARCHAR(1),
@p_CIR_AUTO_APPROVAL_UNSOLD AS VARCHAR(5),
@p_CIR_AUTO_PHYSICAL_UNSOLD AS VARCHAR(5),
@p_CIR_UNSOLD_INCLUDE_INCT AS VARCHAR(5),
@p_CIR_UNSOLD_INCLUDE_INSFEE AS VARCHAR(5),
@p_CIR_UNSOLD_ON_RECEIVED_DT AS VARCHAR(5),
@p_AGENCY_UNBLOCK_APPROVAL AS VARCHAR(5),
@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT AS VARCHAR(5),
@p_CIR_BILL_PUBLWISE AS VARCHAR(5),
@paging         AS VARCHAR(4000) ,
@print          AS VARCHAR(4000) ,
@allowpage      AS VARCHAR(4000) ,
@agency_req     AS VARCHAR(4000) ,
@region_req     AS VARCHAR(4000) ,
@p_ALLOW_FOLLOW_DT_BOOOK as varchar(1),
@p_CRM_SUPPLY_TYPE_PAID   as varchar(10),
@p_CRM_SUPPLY_TYPE_FREE   as varchar(10),
@p_CURRENCY_MEASUREMENT   as varchar(5),

@p_EDITABLE_AGENCY_COMM as varchar(1),
@p_CANCELLATION_CHARGE as varchar(1),
@P_taxi_entry_type     as VARCHAR(1),
@P_ApprovalWith          as VARCHAR(1),
@p_Auto_TDS_Credit_Note as varchar(1),
@p_TDS_Reason as varchar(10),
@p_Debit_Account_Head as varchar(10),
@p_credit_Account_Head as varchar(10),
@p_service_tax_credit_note as varchar(1),
@p_Tax_Reason as varchar(10),
@p_Debit_Account_Service_Tax as varchar(10),
@p_Credit_Account_Service_Tax as varchar(10),
@p_Auto_Patrakar_Credit_Note as varchar(1),
@p_Patrakar_Reason as varchar(10),
@p_Debit_Account_Patrakar as varchar(10),
@p_Credit_Account_Patrakar as varchar(10),
@p_Auto_Bank_Credit_Note as varchar(1),
@p_Bank_Reason as VARCHAR(10),
@p_Debit_Account_Bank as varchar(10),
@p_Credit_Account_Bank as varchar(10),
@P_BAR_CODE as VARCHAR(5),
@P_GEN_RCT_NO as VARCHAR(5),
@P_misdata as VARCHAR(5) =null,
@P_WEIGHT_CAL as VARCHAR(5) =null,
@P_allowpremium as varchar(5) =null,
@p_financecode as varchar(5) =null,
@p_exepub as varchar(5)=null,
@p_executivecreditlimit as varchar(5)=null,
--new add
@P_postdis as varchar(5) =null,
@P_suppdecreselimit as varchar(5) =null,
@P_allowvat as varchar(5) =null,
@P_alterroute as varchar(5) =null,
@P_showrecptag as varchar(5) =null,
@P_allowhoSUN as varchar(5) =null,
@P_allowhoMON as varchar(5) =null,
@P_allowhoTUE as varchar(5) =null,
@P_allowhoWED as varchar(5) =null,
@P_allowhoTHU as varchar(5) =null,
@P_allowhoFRI as varchar(5) =null,
@P_allowhoSAT as varchar(5) =null

AS
declare @query as varchar(8000)
declare @query1 as varchar(8000)
/*
set @query='update login set date_format='''+@dateformat+''' , Autogenerate='''+@code+''',curr_code='''+@curr+''' where com_code='''+@compcode+'''   '
exec(@query)

set @query1='update preferrences set RATE_COMPANY_AGENCY='''+@ratecompany+''',ADDITIONAL_AGENCY_COMM='''+@addagenycomm+''',
AGENCY_RETAINER_COMM='''+@agencycommlinkretainer+''',SUBEDITIONRATE='''+@subeditionr+''',DIS_BILLTYPE='''+@displaybilltype+''',
CLS_BILLTYPE='''+@classifiedbilltype+''',autogenerated='''+@code+''',currency_code='''+@curr+''' ,rate_gr_code='''+@ratecode+''' , 
date_format='''+@dateformat+''',solo='''+@solo+''',breakup='''+@breakup+''' ,blackwhitecode='''+@bwcode+''',  rostatus='''+@rostatus+''',
File_name='''+@filename+''',Tfn='''+@tfn+''',Insert_breakup='''+@insertbreak+''',Premium_type='''+@prem+''',Deal_type='''+@dealtype+'''  ,    
prefix='''+@pre+''', suffix='''+@suff+'''  ,     financestatus='''+ @financestatus+''' , voucherst='''+@voucherst+''',Ad_category='''+@adcode+''' ,
Ro_datetime='''+@rodatetime+''' ,Space_area='''+@spacearea+''',Vat='''+@vat+''' ,Booking_status='''+@bookstat+''' ,Cio_id='''+@cio_id+''',
Receipt_no='''+@receipt_no+''' ,uom_code='''+@uom+''',Bgcolor_publication='''+@bgcolor+''' ,chkfor_valid_pubdates='''+@validdate+''', 
Agency_ratecode='''+@agencyratecode+''',   audit='''+@audit+''', book_insert_date='''+@book_insert_date+''',agencycomm='''+@agencycomm+''',
rate_audit='''+@rateaudit+''',bill_audit='''+@billaudit+''', billtype='''+@billtype+''', invoice_no='''+@invoice_no+''' , 
copy_booking='''+@copybooking+''', BILLING_FORMAT='''+@billformat+''' , RATE_CHECK='''+@ratechk+''', ALL_PACKAGE='''+@allpkg+''',
DAYRATE='''+@dayrate1+''' ,SCHEME_TYPE='''+@schemetype+'''    ,DISP_CLSBILL='''+@PIncludeclassi+ '''  , RECEIPT_FORMAT ='''+@receiptformat+''',
CASH_RECEIPT_BILL='''+@cash_receipt+''', BILL_ORDERWSLAST='''+@bill_orderwiselast+''',FLOOR_CHK='''+@floor_chk+''' ,
Unsold_Entry_Flag='''+@Unsoldflag+''' ,Supply_Stop_Percentage='''+@Supplystopper+''',ROKEYCHECK='''+@drpRokeychk+''',
AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''',DISP_CASHBILL='''+@cashindisplay+''',
CLA_CASHBILL='''+@cashinclassified+''',RATE_AUDIT_PREF='''+@rate_audit_pref+''',BARCODING_ALLOWED='''+@v_barcoding_allow+''', 
FMG_BILL_DIS='''+@v_fmgbills+''',BILL_DISP_CASHBILL='''+@v_billed_cashdis +''',BILL_CLA_CASHBILL ='''+@v_billed_cashcls+''',
BACKDATERECEIPT='''+@v_drpbackdate+''',DOCKIT_BOOKING='''+@dockitbooking+''',Allowed_old_date='''+@allowprevbooking+''',
ROWISE_CASHBOOKING='''+@ro_wisecashbill+''' where    comp_code='''+@compcode+'''   ' 
*/
/*********************************************************************************************************/
UPDATE LOGIN SET date_format=@dateformat, Autogenerate=@code,curr_code=@curr WHERE COM_CODE=@compcode

UPDATE PREFERRENCES SET  autogenerated=@code,
currency_code=@curr ,
rate_gr_code=@ratecode,
date_format=@dateformat,solo=@solo,breakup=@breakup,
blackwhitecode=@bwcode,rostatus=@rostatus,File_name=@filename,Tfn=@tfn,
Insert_breakup=@insertbreak,Premium_type=@prem,Deal_type=@dealtype  ,
 prefix=@pre, suffix=@suff, financestatus=@financestatus , voucherst=@voucherst,
 Ad_category=@adcode ,Ro_datetime=@rodatetime ,Space_area=@spacearea,Vat=@vat,
 Booking_status=@bookstat,Cio_id=@cio_id,Receipt_no=@receipt_no,uom_code=@uom,
 Bgcolor_publication=@bgcolor ,chkfor_valid_pubdates=@validdate, Agency_ratecode=@agencyratecode,
  audit=@AUDIT,book_insert_date=@book_insert_date,agencycomm=@agencycomm,
  rate_audit=@rateaudit,bill_audit=@billaudit,billtype=@billtype,invoice_no=@invoice_no,
  copy_booking=@copybooking,RATE_COMPANY_AGENCY=@ratecompany, ADDITIONAL_AGENCY_COMM=@addagenycomm ,
  AGENCY_RETAINER_COMM=@agencycommlinkretainer,SUBEDITIONRATE=@subeditionr,
  CLS_BILLTYPE=@classifiedbilltype,DIS_BILLTYPE=@displaybilltype,BILLING_FORMAT=@billformat,
  RATE_CHECK=@ratechk,ALL_PACKAGE=@allpkg,dayrate=@dayrate1,SCHEME_TYPE=@schemetype,DISP_CLSBILL=@PIncludeclassi   ,
  CASH_RECEIPT_BILL=@cash_receipt, BILL_ORDERWSLAST=@bill_orderwiselast, FLOOR_CHK=@floor_chk ,
  Unsold_Entry_Flag=@Unsoldflag ,Supply_Stop_Percentage=@Supplystopper,ROKEYCHECK=@drpRokeychk ,
  AGENCYCOMM_SEQ_COM=@Agencycomm_seq ,CREDIT_RECIPT=@creditreciept,DISP_CASHBILL=@cashindisplay,
  CLA_CASHBILL=@cashinclassified,RATE_AUDIT_PREF=@rate_audit_pref,BARCODING_ALLOWED=@v_barcoding_allow,
  FMG_BILL_DIS =@v_fmgbills, BILL_DISP_CASHBILL=@v_billed_cashdis , BILL_CLA_CASHBILL=@v_billed_cashcls,BACKDATERECEIPT=@v_drpbackdate,DOCKIT_BOOKING=@dockitbooking,Allowed_old_date=@allowprevbooking,ROWISE_CASHBOOKING=@ro_wisecashbill,CUTOFFTIME=@chkval,APPROVAL=@approval1,back_days=@pckstatus,CASH_DISCOUNT=@cash_amt,CASH_DISCOUNTTYPE=@cash_disc,SEPRATE_CASHIER=@seperate_cashier1,
 CIR_MANY_TIME_POSTING=@mantimepost, CIR_BACKDAYS_POSTING=@bkdaypost, CIR_MAX_RETURN_ALLOW=@maxterutn, CIR_RETURN_LIMIT_ALLOW=@cir_return, CIR_NO_OF_CHQBOUNCE=@noofchkbounc, CIR_DAYS_CHQBOUNCE=@noofdaychkrec, CIR_RETURN_DAYS=@retday, CIR_SUP_ORDER_LIMIT=@chngsuppord, DISP_BILLING_CRITERIA=@disp_bill, CLSD_BILLING_CRITERIA=@clas_bill,MAX_PUBLISHDAYS=@max_publishday,
 BILLNO_PERIODICITY=@p_billno_period,SPECIALDISC_TRANS_EDIT=@spl_trans_edit, SHARING_TRANS=@spl_dis_trans_editable, MULTIPACKAGE_SEL_TRANS=@mul_pac_sel_trans,SCHEME_MINWORD=@shmon_minword, TRADE_SPLCHARGE=@tradon_spcrg,RATE_AUTHORIZATION=@rateauth
  ,F2_RECORD=@f2day,PUBLISHAD_EDIT_RATEAUDIT=@rateauditmodify,BINDREVENUE_CENTER=@bindrevenuecenter,
FA_LEDGER_ALLOW=@p_led_allow,CLEARANCE_TYPE_ALLOW=@p_clear_allow,REPEAT_DAY_TYPE=@repeatday,PREMIUM_EDIT=@premiumedit,

BILL_GENERATION_PRIOR=@P_BILL_GENERATION,PUBLICATION_HO=@P_PUBLICATION_CENTER,

SPLDISC_ALLOWPREM=@P_allow_discount_prem,BILL_SCHEME=@P_SCHEME_BILLING,

ALLOWED_PDC_DAYS_RECEIPT=@P_ALLOW_PDC,AD_TYPE_MANUL_BILL=@PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=@RO_OUTSTAND_P,GENRATE_CIR_AGCD=@genrate_agency_code,DISP_AUDITBKG=@p_dispauditbk,CIR_DIS_AUTO_POSTING=@p_aotosupply,RELAUTHREQON=@p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=@p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=@p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=@p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=@p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=@p_CIR_UNSOLD_ON_RECEIVED_DT,AGENCY_UNBLOCK_APPROVAL=@p_AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=@p_UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE=@p_CIR_BILL_PUBLWISE,
RECORDS_ON_PAGE = @paging,RECORDS_ON_PRINT = @print,HEADER_ON_PAGE = @allowpage,AGENCY_REQUIRED = @agency_req,REGION_REQUIRED = @region_req,ALLOW_FOLLOW_DT_BOOOK=@p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=@p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=@p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=@p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM =@p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE =@p_CANCELLATION_CHARGE,taxi_entry_type=@P_taxi_entry_type,APPROVAL_WITH =@P_ApprovalWith,

TDS_AUTO_CN=@p_Auto_TDS_Credit_Note,
TDS_AUTO_REASON=@p_TDS_Reason ,TDS_DB_CDP=@p_Debit_Account_Head,TDS_CR_CDP=@p_credit_Account_Head,SER_TAX_AUTO_CN=@p_service_tax_credit_note,SER_TAX_AUTO_REASON=@p_Tax_Reason,SER_TAX_DB_CDP=@p_Debit_Account_Service_Tax,SER_TAX_CR_CDP=@p_Credit_Account_Service_Tax,PKK_AUTO_CN=@p_Auto_Patrakar_Credit_Note,PKK_AUTO_REASON=@p_Patrakar_Reason ,PKK_DB_CDP=@p_Debit_Account_Patrakar,PKK_CR_CDP=@p_Credit_Account_Patrakar ,BANK_CHG_AUTO_CN=@p_Auto_Bank_Credit_Note ,
BANK_CHG_AUTO_REASON=@p_Bank_Reason ,BANK_CHG_DB_CDP=@p_Debit_Account_Bank ,BANK_CHG_CR_CDP=@p_Credit_Account_Bank,

 CIR_BARCODE= @P_BAR_CODE,CIR_WIEGHT_CALC_REQ= @P_WEIGHT_CAL,GEN_RCT_TYP = @P_GEN_RCT_NO,PRODUCT_BRAND_REQ=@P_misdata,ALLOWPREM_CARD_DISC_RATE=@P_allowpremium,FINANCE_CADE=@p_financecode,EXECUTIVE_PUBLICATION_VISE=@p_exepub,EXECUTIVECREDITLIMIT=@p_executivecreditlimit,
--NEW ADD
 CIR_POST_DIS=@P_postdis,
 CIR_VAT_ALLOW=@P_allowvat,
 CIR_SUP_ALT_ROUTE=@P_alterroute,
 SHOW_REC_ALL_AGENCY=@P_showrecptag,
 CIR_SUP_ORDER_DEC_LIMIT=@P_suppdecreselimit,
 CIR_ALLOW_HOLIDAY_SUN=@P_allowhoSUN,
 CIR_ALLOW_HOLIDAY_MON=@P_allowhoMON,       
 CIR_ALLOW_HOLIDAY_TUE=@P_allowhoTUE,
 CIR_ALLOW_HOLIDAY_WED=@P_allowhoWED,
 CIR_ALLOW_HOLIDAY_THU=@P_allowhoTHU,
 CIR_ALLOW_HOLIDAY_FRI=@P_allowhoFRI,
 CIR_ALLOW_HOLIDAY_SAT=@P_allowhoSAT
 
 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)


////////////////////end of 8461////////////////////////////////


///////////////////////done by shipra./////////////////////////////


 
alter table Exec_mast add PAYMENTMODE varchar(50) ;



USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[execcontactinsert]    Script Date: 09/12/2012 13:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








ALTER Procedure [dbo].[execcontactinsert]
@exename as varchar(30),
@teamcode as varchar(10),
@designation as varchar(30),
@address as varchar(50),
@street as varchar(30),
@city as varchar(20),
@district as varchar(18),

@state as varchar(18),
@country as varchar(10),
@pin as varchar(20),
@phone as varchar(50),
@status as varchar(18),
@compcode as varchar(10),
@userid as varchar(10),
@report as varchar(8),
@taluka1 as varchar(20),
@repname as varchar(50),
@adtype as varchar(8),
@zone as varchar(20),
@craditlimit as varchar(20),
@mobile as varchar(50),
@email as varchar(200),
@mailto as varchar(200),
@p_empcode as varchar(50),
@attachment as varchar(50),
@paymode as varchar(50)



as

declare @exeno as int
declare @query as varchar(1000)
declare @query2 as varchar(1000)

select @exeno= max(isnull(Exe_no,0)+1)  from exec_mast
if @exeno is null
	set @exeno=1
print(@exeno)
if @exeno is null
	set @exeno=1
insert into Exec_mast
(Exe_no,Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,phone,exe_status,userid,comp_code,pin_code,report_to,TALUKA,creation_datetime,REPRESENTATIVE,ADTYPE,Branch_code,CREDIT_LIMIT,MOBILENO,EMAILID,HR_CODE,EMAIL_ID,ATTACHMENT,PAYMENTMODE) 
 values(@exeno  ,@teamcode,@exename,@designation,@address,@street ,@country,@state,@district,@city,@phone,@status,@userid,@compcode,@pin,@report,@taluka1,getdate(),@repname,@adtype,@zone,@craditlimit,@mobile,@email,@p_empcode,@mailto,@attachment,@paymode)/*'''+@EXEC_USERID+''','''+@EXEC_EMAILID+'''*/
--print(@query)
exec(@query)
--set @query='insert into tmp_exec_mast(Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,phone,exe_status,userid,comp_code,pin_code)  values('''+@teamcode+''','''+@exename+''','''+@designation+''','''+@address+''','''+@street+''' ,'''+@country+''','''+@state+''','''+@district+''','''+@city+''','''+@phone+''','''+@status+''','''+@userid+''','''+@compcode+''','''+@pin+''')'



set @query2='update Exec_mast set city_name=(select city_name from city_mst where comp_code = '''+@compcode+''' and city_code='''+@city+''') where comp_code = '''+@compcode+''' and city_code='''+@city+''' '
select @exeno as 'exeno'
print(@query2)
exec(@query2)







/////////////////////////////////////////////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[execcontactupdate]    Script Date: 09/12/2012 17:11:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







ALTER Procedure [dbo].[execcontactupdate]
@exename as varchar(30),
@teamcode as varchar(10),
@designation as varchar(30),
@address as varchar(50),
@street as varchar(30),
@city as varchar(10),
@district as varchar(18),

@state as varchar(18),
@country as varchar(10),
@pin as varchar(20),
@phone as varchar(50),
@status as varchar(10),
@compcode as varchar(10),
@userid as varchar(10),
@code as varchar(10),
@report as varchar(8),
@TALUKA1 as varchar(23),
@repname as varchar(50),
@adtype as varchar(8),
@branchcode as varchar(20),
@craditlimit as varchar(20),
@mobile as varchar(50),
@email as varchar(200),
@mailto as varchar(200),
@p_empcode as varchar(50),
@pattachment as varchar(50),
@paymode as varchar(50)


as

declare @query as varchar(1000)

declare @query2 as varchar(1000)

--set @query='insert into Exec_mast(Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,phone,exe_status,userid,comp_code,pin_code)  values('''+@teamcode+''','''+@exename+''','''+@designation+''','''+@address+''','''+@street+''' ,'''+@country+''','''+@state+''','''+@district+''','''+@city+''','''+@phone+''','''+@status+''','''+@userid+''','''+@compcode+''','''+@pin+''')'

set @query='update  Exec_mast set  Exec_name='''+@exename+''' ,Designation='''+@designation+''',Add1='''+@address+''',Street='''+@street+''',Country_code='''+@country+''',State_code='''+@state+''',dist_code='''+@district+''',city_code='''+@city+''',phone='''+@phone+''',exe_status='''+@status+''' ,pin_code='''+@pin+''', report_to='''+@report+''',TALUKA='''+@TALUKA1+''',REPRESENTATIVE='''+@repname+''',ADTYPE='''+@adtype+''',Branch_code='''+@branchcode+''',CREDIT_LIMIT='''+@craditlimit+''',MOBILENO='''+@mobile+''',EMAILID='''+@email+''',HR_CODE='''+@p_empcode+''',EMAIL_ID='''+@mailto+''',ATTACHMENT='''+@pattachment+''',PAYMENTMODE='''+@paymode+'''where comp_code='''+@compcode+''' and Exe_no='''+@code+'''   ' --EXEC_EMAILID='''+@EXEC_EMAILID+''',EXEC_USERID='''+@EXEC_USERID+'''
print(@query)
exec(@query)


set @query2='update Exec_mast set city_name=(select city_name from city_mst where city_code='''+@city+''' and exec_mast.comp_code=city_mst.comp_code) where city_code='''+@city+''' '
print(@query2)
exec(@query2)



///////////////////////////////////////////////////

/////////////////////////////end by shipra//////////////////
/////////////bhanu///////////
alter TABLE Payment_Mode_Mast ALTER COLUMN payment_mode_name VARCHAR(50)


//////////////end by bhanu////////



/****************************up dateed by Dhananjay ISSUE NO 8666**********************************/
ALTER PROCEDURE  [dbo].[executecommdetail]
@compcode as varchar(10),
@userid as varchar(10),
@comcode as varchar(10),
@alias as varchar(50),
@packagename as varchar(50),
@editiontype as varchar(2),
@adtype as varchar(8),
@pubcenter as varchar(50),
@split as varchar(5)





  AS

--create table #temp_commbin_mast (Comp_code  varchar(8), Combin_code  varchar(8), Edition_combin_code  varchar(100), combin_desc  varchar(1000),package_name  varchar(100),package_alias  varchar(15) , userid  varchar(8)   )

CREATE TABLE #temp_commbin_mast (
	Comp_Code varchar (8) ,
	Combin_Code varchar (8) ,
	Edition_Combin_Code varchar (3000) ,
	Combin_Desc varchar (1000) ,
	Package_Name varchar (1000)  ,
	Package_Alias varchar (1000)  ,
	UserId varchar (10) ,
	Creation_Datetime datetime   ,
	Ad_Cat_Code varchar (8)  ,
	Ad_Subcat_code varchar (8)  ,
	Share_Distribution varchar (100)  ,
	Ad_Type_code varchar (8) ,
	No_Of_Edition varchar (15) ,
	Edition_Type varchar(2) ,
	No_of_inserts varchar(10),
	pub_center	varchar(50),
	SPLIT varchar(5),
	CONSUM_PERIOD int
) 

declare @query varchar(1000)

set @packagename=replace(@packagename,'''','''''')
set @alias=replace(@alias,'''','''''')


--delete from temp_commbin_mast
--insert into combin_mast(Comp_code,Combin_code,Edition_combin_code,combin_desc,package_name,package_alias,userid) values(@compcode,@comcode,@codepub,@combinationname,@packagename,@alias,@userid)

--select  Comp_code,Combin_code,Edition_combin_code,combin_desc,	package_name,	package_alias,userid  from  commbin_mast

set @query='insert #temp_commbin_mast select [Comp_Code]
      ,[Combin_Code]
      ,[Edition_Combin_Code]
      ,[Combin_Desc]
      ,[Package_Name]
      ,[Package_Alias]
      ,[UserId]
      ,[Creation_Datetime]
      ,[Ad_Cat_Code]
      ,[Ad_Subcat_code]
      ,[Share_Distribution]
      ,[Ad_Type_code]
      ,[No_Of_Edition]
      ,[Edition_Type]
      ,[No_of_inserts]
      ,[pub_center]
      ,[SPLIT]
      ,[CONSUM_PERIOD]  from combin_mast  where comp_code='''+@compcode+'''  and  edition_Type='''+@editiontype+''' '

if(@comcode <> '')
begin
set @query  =  @query + 'and Combin_code like ''%'+@comcode +'%'''
end

if(@alias <> '')
begin
set @query  =  @query + 'and package_alias like ''%'+@alias +'%'''
end

if(@packagename <> '')
begin
set @query  =  @query + 'and package_name like ''%'+@packagename+'%'''
end


if(@adtype <>'0' and @adtype <> '')
begin
set @query  =  @query + 'and Ad_Type_code = '''+@adtype+''''
end

if(@split <>'0' and @split <> '')
begin
set @query  =  @query + 'and SPLIT = '''+@split+''''
end

if(@pubcenter <>'0' and @pubcenter <> '' and @pubcenter <> null)
begin
set @query  =  @query + 'and pub_center = '''+@pubcenter+''''
end

print(@adtype)

print(@query)
exec(@query)

select  *  from  #temp_commbin_mast

--delete from #temp_commbin_mast
drop table #temp_commbin_mast






/****************************ENDISSUE NO 8282**********************************/