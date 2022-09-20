/************************************************** Prachi 4797 ************************************/

CREATE  procedure bindSapAdReport
(
@sedition varchar,
@fromdate    varchar,
@todate  varchar,
@agencycode varchar
)
as
BEGIN
if @agencycode is null or @agencycode='' begin
    if @sedition is null or @sedition='' begin
        
            SELECT sapid,edition,page_no,pub_date,category_code,sub_category_code from ad_status where convert(varchar(10),pub_date,3)   between convert(varchar(10),@fromdate,3)  and  convert(varchar(10),@todate,3) ;
   end
 else begin
        
            SELECT sapid,edition,page_no,pub_date,category_code,sub_category_code from ad_status where convert(varchar(10),pub_date,3) between convert(varchar(10),@fromdate,3) and convert(varchar(10),@todate,3)  and CLIENT_NAME=@sedition;        
    end 
end else begin
		    if @sedition is null  or @sedition =''
	        begin	        
				SELECT sapid,edition,page_no,pub_date,category_code,sub_category_code from ad_status where convert(varchar(10),pub_date,3) between convert(varchar(10),@fromdate,3) and convert(varchar(10),@todate,3)  and QBC_CODE=@agencycode;
		    end 
		   else 
		   begin        
					SELECT sapid,edition,page_no,pub_date,category_code,sub_category_code from ad_status where convert(varchar(10),pub_date,3) between convert(varchar(10),@fromdate,3) and convert(varchar(10),@todate,3)  and CLIENT_NAME=@sedition  and QBC_CODE=@agencycode;        
			end 
end 
end



CREATE PROCEDURE bindSapReportEdition
as
BEGIN
SELECT distinct CLIENT_NAME from ad_status;
END 

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[report]
(
@agname varchar(50)=null,
@clientname varchar(50)=null,
@adtype varchar(50),
@adcategory varchar(50),
@fromdate varchar(50),
@dateto varchar(50),
@compcode varchar(10),
@pub_name varchar(50),
@pub_cent varchar(50),
@status varchar(50)=null,
@edition varchar(50),
@dateformat varchar(50),
@hold varchar(10)=null,
@descid varchar(50)=null,
@ascdesc varchar(50)=null


)
as 
declare @str  as varchar(3000)
declare @center  as varchar(50)



set @str='select TBL_BOOKING_MAST.cio_booking_id as "CIOID",AGENCY_MAST.agency_name as "Agency",isnull((select cust_name from CUST_MAST where cust_code=client_code),client_code)  as "Client",PUB_CENT_MAST.pub_cent_name as "City",
PUB_MAST.pub_name as "Pub",COMBIN_MAST.combin_desc as "Package",ad_size_height as "Depth",ad_size_width as "Width",TBL_BOOKING_MAST.total_area as "Area", COL_MAST.col_alias as "Hue",(select ADVPOS_TYPE_MAST.pos_type_alias from ADVPOS_TYPE_MAST where TBL_BOOKING_INSERT.page_post=ADVPOS_TYPE_MAST.pos_type_code) as "Page",no_insert as "Ins.No.",
case '''+@dateformat + '''

 when ''mm/dd/yyyy'' then convert(varchar(10),insertion_date,1) 

when ''dd/mm/yyyy'' then convert(varchar(10),insertion_date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),insertion_date,3)  end as "Ins.date" ,

case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),TBL_BOOKING_MAST.creation_datetime,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),TBL_BOOKING_MAST.creation_datetime,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),TBL_BOOKING_MAST.creation_datetime,3)  end as "BookDate"
  ,ro_no as "RoNo.",
case ro_status
when ''1'' then ''Reservation''
when ''2'' then ''Confirm''
end as "RoStatus",
 ADV_TYPE_MAST. Adv_type_name as "AdType" 
,rate_Code as "RateCode",TBL_BOOKING_INSERT.card_rate as "CardRate",isnull(TBL_BOOKING_MAST.card_amount,TBL_BOOKING_MAST.gross_amount) as "Amt",TBL_BOOKING_INSERT.disc_rate as "Disc",  TBL_BOOKING_INSERT.insert_status as "Status",TBL_BOOKING_INSERT.status_material as "MatStatus",caption as "Cap",key_no as "Key",agrred_rate as "AgreedRate",(select  AGENCY_MAST.Sub_Agency_code from agency_mast where  AGENCY_MAST.type <> ''P'' and TBL_BOOKING_MAST.agency_code=AGENCY_MAST.code_subcode )as "SubAg",(select adv_cat_mast.adv_cat_name from adv_cat_mast where ADV_CAT_MAST.adv_cat_code=TBL_BOOKING_MAST.ad_cat_code) as "AdCat",SAPID

from TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,PUB_MAST,PUB_CENT_MAST,ADV_TYPE_MAST ,COMBIN_MAST, COL_MAST 
 where TBL_BOOKING_MAST.comp_code='''+@compcode+''' and TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.cio_booking_id
 and TBL_BOOKING_MAST.agency_code=AGENCY_MAST.agency_code and TBL_BOOKING_MAST.Ad_type_code=ADV_TYPE_MAST .adv_type_code
 and tbl_booking_mast.Color_code=col_mast.Col_code  and 
TBL_BOOKING_MAST.package_code=COMBIN_MAST.combin_code and TBL_BOOKING_MAST.agency_sub_code=AGENCY_MAST.code_subcode and TBL_BOOKING_INSERT.publication_code = PUB_MAST.pub_code and TBL_BOOKING_INSERT.pub_cent_code=PUB_CENT_MAST.pub_cent_code '

--select adv_cat_mast.adv_cat_name from adv_cat_mast where ADV_CAT_MAST.adv_cat_code=TBL_BOOKING_MAST.ad_cat_code



if(@hold<>null)
begin
set @str=@str+' and TBL_BOOKING_INSERT.insert_status!="Cancel"'
end

if(@agname <>null)
begin

set @str=@str+' and TBL_BOOKING_MAST.agency_code ='''+@agname +''''
end

if(@clientname <>null)
begin
set @str=@str+' and TBL_BOOKING_MAST.client_code ='''+@clientname +''''
end
if(@status <>null)
begin
set @str=@str+' and TBL_BOOKING_INSERT.insert_status  ='''+@status+''''
end


if(@adtype<>null)
begin
print(@adtype)
set @str=@str + 'and TBL_BOOKING_MAST. ad_type_code ='''+@adtype+''' '
End

if(@adcategory <> null)
begin
set @str=@str +  ' and TBL_BOOKING_MAST. ad_cat_code in('''+@adcategory+''' )'
End


--if(@pub_cent<>null )
--begin
--select @center=substring(pub_cent_alias,1,3) from pub_cent_mast where pub_cent_code=@pub_cent

--print(@center)
--set @str=@str+'  and tbl_booking_insert.pub_cent_code='''+ @center +''''
--print(@str)
--end
if(@pub_cent<>null)
begin
set @str=@str+'  and tbl_booking_insert.pub_cent_code ='''+  @pub_cent+''''
end




if(@fromdate is not null and @dateto is null )
begin
	set @str=@str+' and insertion_date ='''+@fromdate +''''

end

else if(@fromdate is not null and @dateto is not null )
begin
	set @str=@str+' and insertion_date between  '''+@fromdate +''' and  '''+@dateto +''' '
end

if(@edition <> null)
begin
set @str=@str+'  and tbl_booking_insert.edition_code='''+ @edition +''''
End

if(@pub_name <> null)
begin
set @str=@str+' and  TBL_BOOKING_INSERT.publication_code='''+ @pub_name +''''
End



if(@descid <>  null)
begin
set @str=@str+'  order by '''+@descid + ''''
set @str=@str+ ''+@ascdesc+''

End







print(@str)
exec(@str)

/*****************************prachi 4797 20-sept****************************/


ALTER  PROCEDURE [dbo].[report_booking_confirm]
(
@fromdate as datetime,
@todate   as datetime,
@status1  as varchar,
@flag     as varchar,
@userid   as varchar,
@descid   as varchar,
@ascdesc  as varchar,
@filter   as varchar,
@agency  as varchar
)
as
declare @userid1 varchar(10)


BEGIN
set @userid1=@userid
if @agency is null begin

    if(@flag='0')begin


								if(@status1='0')begin
												if(@filter='0') begin
											     
												 select tbl_booking_mast."cio_booking_id","Insert_Date","Creation_datetime","Total_area",
tbl_booking_mast."Package_code",TBL_BOOKING_INSERT."Card_Rate" as "Card_rate",TBL_BOOKING_insert."Gross_Rate" as "Gross_amount","ro_status",
(select "Agency_Name" from agency_mast where agency_mast."code_subcode"=tbl_booking_mast."Agency_sub_code" and tbl_booking_mast.comp_code=agency_mast.comp_code)as Agency_name,
(select "Cust_Name" from cust_mast where "Cust_Code"="Client_code" and tbl_booking_mast.comp_code=cust_mast.comp_code)as client_name,
(select "Uom_Name" from uom_mast where uom_mast."Uom_Code"=tbl_booking_mast."Uom_code" and tbl_booking_mast.comp_code=uom_mast.comp_code)as uom_name,
(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"="Ad_cat_code" and tbl_booking_mast.comp_code=adv_cat_mast.comp_code)as cat_name,
(select "Adv_Subcat_Name" from adv_subcat_mast where "Adv_Subcat_Code"="Ad_sub_cat_code" and tbl_booking_mast.comp_code=adv_subcat_mast.comp_code) as subcat_name,
(select "Col_Name" from col_mast where "Col_Code"="Color_code" and tbl_booking_mast.comp_code=col_mast.comp_code) as col_name,"Receipt_no",SAPID
												   from tbl_booking_mast,tbl_booking_insert
												  where tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id"
													and tbl_booking_mast."Creation_datetime">=@fromdate
												   and tbl_booking_mast."Creation_datetime"<=@todate ;
												end else begin
											     
												 select tbl_booking_mast."cio_booking_id","Insert_Date","Creation_datetime","Total_area",tbl_booking_mast."Package_code",TBL_BOOKING_INSERT."Card_Rate" as "Card_rate",TBL_BOOKING_insert."Gross_Rate" as "Gross_amount","ro_status",
(select "Agency_Name" from agency_mast where agency_mast."code_subcode"=tbl_booking_mast."Agency_sub_code"  and tbl_booking_mast.comp_code=agency_mast.comp_code)as Agency_name,
(select "Cust_Name" from cust_mast where "Cust_Code"="Client_code" and tbl_booking_mast.comp_code=cust_mast.comp_code)as client_name,
(select "Uom_Name" from uom_mast where uom_mast."Uom_Code"=tbl_booking_mast."Uom_code" and tbl_booking_mast.comp_code=uom_mast.comp_code)as uom_name,
(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"="Ad_cat_code" and tbl_booking_mast.comp_code=adv_cat_mast.comp_code)as cat_name,
(select "Adv_Subcat_Name" from adv_subcat_mast where "Adv_Subcat_Code"="Ad_sub_cat_code" and tbl_booking_mast.comp_code=adv_subcat_mast.comp_code) as subcat_name,
(select "Col_Name" from col_mast where "Col_Code"="Color_code" and tbl_booking_mast.comp_code=col_mast.comp_code) as col_name,"Receipt_no",SAPID
												   from tbl_booking_mast,tbl_booking_insert
												  where tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id"
													and tbl_booking_insert."Insert_Date">=@fromdate
												   and tbl_booking_insert."Insert_Date"<=@todate ;
												end    
							   end else begin
							    
								select tbl_booking_mast."cio_booking_id","Insert_Date","Creation_datetime","Total_area",tbl_booking_mast."PACKAGE_CODE",TBL_BOOKING_INSERT."Card_Rate" as "Card_rate",TBL_BOOKING_insert."Gross_Rate" as "Gross_amount","ro_status",
(select "Agency_Name" from agency_mast where agency_mast."code_subcode"=tbl_booking_mast."Agency_sub_code" and tbl_booking_mast.comp_code=agency_mast.comp_code)as Agency_name,
(select "Cust_Name" from cust_mast where "Cust_Code"="Client_code" and tbl_booking_mast.comp_code=cust_mast.comp_code)as client_name,
(select "Uom_Name" from uom_mast where uom_mast."Uom_Code"=tbl_booking_mast."Uom_code" and tbl_booking_mast.comp_code=uom_mast.comp_code)as uom_name,
(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"="Ad_cat_code" and tbl_booking_mast.comp_code=adv_cat_mast.comp_code)as cat_name,
(select "Adv_Subcat_Name" from adv_subcat_mast where "Adv_Subcat_Code"="Ad_sub_cat_code" and tbl_booking_mast.comp_code=adv_subcat_mast.comp_code) as subcat_name,
(select "Col_Name" from col_mast where "Col_Code"="Color_code" and tbl_booking_mast.comp_code=col_mast.comp_code) as col_name,"Receipt_no",SAPID
								  from tbl_booking_mast,tbl_booking_insert
								  where tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id"
									--and tbl_booking_mast."Creation_datetime">=TO_date(fromdate,'yyyy/mm/dd')
								  --and tbl_booking_mast."Creation_datetime"<=to_date(todate ,'yyyy/mm/dd')
								   and "ro_status"=@status1;
								end 
   end else if (@flag='1')begin
    
    select distinct tbl_booking_mast_confirm.cio_booking_id,(select "username" from login where login."userid"=tbl_booking_mast_confirm.Userid) as userid,Insert_Date,Creation_datetime,Total_area,tbl_booking_mast_confirm.PACKAGE_CODE,TBL_BOOKING_INSERT_confirm.Card_Rate as "Card_rate",TBL_BOOKING_insert_confirm.Gross_Rate as "Gross_amount",ro_status,
(select "Agency_Name" from agency_mast where agency_mast."code_subcode"=tbl_booking_mast_confirm.Agency_sub_code and tbl_booking_mast_confirm.comp_code=agency_mast.comp_code)as Agency_name,
(select "Cust_Name" from cust_mast where "Cust_Code"=Client_code and tbl_booking_mast_confirm.comp_code=cust_mast.comp_code)as client_name,
(select "Uom_Name" from uom_mast where uom_mast."Uom_Code"=tbl_booking_mast_confirm.Uom_code and tbl_booking_mast_confirm.comp_code=uom_mast.comp_code)as uom_name,
(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=Ad_cat_code and tbl_booking_mast_confirm.comp_code=adv_cat_mast.comp_code)as cat_name,
(select "Adv_Subcat_Name" from adv_subcat_mast where "Adv_Subcat_Code"=Ad_sub_cat_code and tbl_booking_mast_confirm.comp_code=adv_subcat_mast.comp_code) as subcat_name,
(select "Col_Name" from col_mast where "Col_Code"=Color_code and tbl_booking_mast_confirm.comp_code=col_mast.comp_code) as col_name,Receipt_no,SAPID
      from tbl_booking_mast_confirm,tbl_booking_insert_confirm
     where tbl_booking_mast_confirm.cio_booking_id=tbl_booking_insert_confirm.Cio_Booking_Id
        and tbl_booking_mast_confirm.Creation_datetime>=@fromdate
      and tbl_booking_mast_confirm.Creation_datetime<=@todate
       and tbl_booking_mast_confirm.SEND_STATUS='Y';
   end  else if (@flag='2')begin
							if(@userid='0')begin
						    
							select distinct tbl_booking_mast_confirm.cio_booking_id,(select "username" from login where login."userid"=tbl_booking_mast_confirm.Userid) as userid,Insert_Date,Creation_datetime,Total_area,tbl_booking_mast_confirm.PACKAGE_CODE,TBL_BOOKING_INSERT_confirm.Card_Rate as "Card_rate",TBL_BOOKING_insert_confirm.Gross_Rate as "Gross_amount",ro_status,(select "Agency_Name" from agency_mast where agency_mast."code_subcode"=tbl_booking_mast_confirm.Agency_sub_code and tbl_booking_mast_confirm.comp_code=agency_mast.comp_code)as Agency_name,(select "Cust_Name" from cust_mast where "Cust_Code"=Client_code and tbl_booking_mast_confirm.comp_code=cust_mast.comp_code)as client_name,(select "Uom_Name" from uom_mast where uom_mast."Uom_Code"=tbl_booking_mast_confirm.Uom_code and tbl_booking_mast_confirm.comp_code=uom_mast.comp_code)as uom_name,(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=Ad_cat_code and tbl_booking_mast_confirm.comp_code=adv_cat_mast.comp_code)as cat_name,(select "Adv_Subcat_Name" from adv_subcat_mast where "Adv_Subcat_Code"=Ad_sub_cat_code and tbl_booking_mast_confirm.comp_code=adv_subcat_mast.comp_code) as subcat_name,(select "Col_Name" from col_mast where "Col_Code"=Color_code and tbl_booking_mast_confirm.comp_code=col_mast.comp_code) as col_name,Receipt_no,SAPID
							  from tbl_booking_mast_confirm,tbl_booking_insert_confirm
							 where tbl_booking_mast_confirm.cio_booking_id=tbl_booking_insert_confirm.Cio_Booking_Id
								and tbl_booking_mast_confirm.Creation_datetime>=@fromdate
							  and tbl_booking_mast_confirm.Creation_datetime<=@todate
							   and tbl_booking_mast_confirm.SEND_STATUS='Y';
							end else begin
			
							select distinct tbl_booking_mast_confirm.cio_booking_id,(select "username" from login where login."userid"=tbl_booking_mast_confirm.Userid) as userid,Insert_Date,Creation_datetime,Total_area,tbl_booking_mast_confirm.PACKAGE_CODE,TBL_BOOKING_INSERT_confirm.Card_Rate as "Card_rate",TBL_BOOKING_insert_confirm.Gross_Rate as "Gross_amount",ro_status,(select "Agency_Name" from agency_mast where agency_mast."code_subcode"=tbl_booking_mast_confirm.Agency_sub_code and tbl_booking_mast_confirm.comp_code=agency_mast.comp_code)as Agency_name,(select "Cust_Name" from cust_mast where "Cust_Code"=Client_code and tbl_booking_mast_confirm.comp_code=cust_mast.comp_code)as client_name,(select "Uom_Name" from uom_mast where uom_mast."Uom_Code"=tbl_booking_mast_confirm.Uom_code and tbl_booking_mast_confirm.comp_code=uom_mast.comp_code)as uom_name,(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=Ad_cat_code and tbl_booking_mast_confirm.comp_code=adv_cat_mast.comp_code)as cat_name,(select "Adv_Subcat_Name" from adv_subcat_mast where "Adv_Subcat_Code"=Ad_sub_cat_code and tbl_booking_mast_confirm.comp_code=adv_subcat_mast.comp_code) as subcat_name,(select "Col_Name" from col_mast where "Col_Code"=Color_code and tbl_booking_mast_confirm.comp_code=col_mast.comp_code) as col_name,Receipt_no,SAPID
							  from tbl_booking_mast_confirm ,tbl_booking_insert_confirm
							 where tbl_booking_mast_confirm.cio_booking_id=tbl_booking_insert_confirm.Cio_Booking_Id
								and tbl_booking_mast_confirm.Creation_datetime>=@fromdate
							  and tbl_booking_mast_confirm.Creation_datetime<=@todate
							   and tbl_booking_mast_confirm.SEND_STATUS='Y'
							and   tbl_booking_mast_confirm.Userid = @userid1 ;
							end 
    end 
end 


else begin
    if(@flag='0')begin
				if(@status1='0')begin
										if(@filter='0') begin
									     
										 select tbl_booking_mast."cio_booking_id","Insert_Date","Creation_datetime","Total_area",tbl_booking_mast."Package_code",TBL_BOOKING_INSERT."Card_Rate" as "Card_rate",TBL_BOOKING_insert."Gross_Rate" as "Gross_amount","ro_status",(select "Agency_Name" from agency_mast where agency_mast."code_subcode"=tbl_booking_mast."Agency_sub_code" and tbl_booking_mast.comp_code=agency_mast.comp_code)as Agency_name,(select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"  and  tbl_booking_mast.comp_code=cust_mast.comp_code)as client_name,(select "Uom_Name" from uom_mast where uom_mast."Uom_Code"=tbl_booking_mast."Uom_code" and tbl_booking_mast.comp_code=uom_mast.comp_code)as uom_name,(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"="Ad_cat_code" and  tbl_booking_mast.comp_code=adv_cat_mast.comp_code)as cat_name,(select "Adv_Subcat_Name" from adv_subcat_mast where "Adv_Subcat_Code"="Ad_sub_cat_code" and  tbl_booking_mast.comp_code=adv_subcat_mast.comp_code) as subcat_name,(select "Col_Name" from col_mast where "Col_Code"="Color_code"  and  tbl_booking_mast.comp_code=col_mast.comp_code) as col_name,"Receipt_no",SAPID
										   from tbl_booking_mast,tbl_booking_insert
										  where tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id"
											and tbl_booking_mast."Creation_datetime">=@fromdate
										   and tbl_booking_mast."Creation_datetime"<=@todate
										   and "Agency_sub_code"=@agency
									     
										end else begin
										 
										 select tbl_booking_mast."cio_booking_id","Insert_Date","Creation_datetime","Total_area",tbl_booking_mast."Package_code",TBL_BOOKING_INSERT."Card_Rate" as "Card_rate",TBL_BOOKING_insert."Gross_Rate" as "Gross_amount","ro_status",(select "Agency_Name" from agency_mast where agency_mast."code_subcode"=tbl_booking_mast."Agency_sub_code" and  tbl_booking_mast.comp_code=agency_mast.comp_code)as Agency_name,(select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"  and tbl_booking_mast.comp_code=cust_mast.comp_code)as client_name,(select "Uom_Name" from uom_mast where uom_mast."Uom_Code"=tbl_booking_mast."Uom_code" and  tbl_booking_mast.comp_code=uom_mast.comp_code)as uom_name,(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"="Ad_cat_code" and  tbl_booking_mast.comp_code=adv_cat_mast.comp_code)as cat_name,(select "Adv_Subcat_Name" from adv_subcat_mast where "Adv_Subcat_Code"="Ad_sub_cat_code" and  tbl_booking_mast.comp_code=adv_subcat_mast.comp_code) as subcat_name,(select "Col_Name" from col_mast where "Col_Code"="Color_code" and  tbl_booking_mast.comp_code=col_mast.comp_code) as col_name,"Receipt_no",SAPID
										   from tbl_booking_mast,tbl_booking_insert
										  where tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id"
											and tbl_booking_insert."Insert_Date">=@fromdate
										   and tbl_booking_insert."Insert_Date"<=@todate and "Agency_sub_code"=@agency;
										end   
			   end else begin
			    
				select tbl_booking_mast."cio_booking_id","Insert_Date","Creation_datetime","Total_area",tbl_booking_mast."PACKAGE_CODE",TBL_BOOKING_INSERT."Card_Rate" as "Card_rate",TBL_BOOKING_insert."Gross_Rate" as "Gross_amount","ro_status",(select "Agency_Name" from agency_mast where agency_mast."code_subcode"=tbl_booking_mast."Agency_sub_code" and tbl_booking_mast.comp_code=agency_mast.comp_code)as Agency_name,(select "Cust_Name" from cust_mast where "Cust_Code"="Client_code" and tbl_booking_mast.comp_code=cust_mast.comp_code)as client_name,(select "Uom_Name" from uom_mast where uom_mast."Uom_Code"=tbl_booking_mast."Uom_code" and tbl_booking_mast.comp_code=uom_mast.comp_code)as uom_name,(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"="Ad_cat_code" and tbl_booking_mast.comp_code=adv_cat_mast.comp_code)as cat_name,(select "Adv_Subcat_Name" from adv_subcat_mast where "Adv_Subcat_Code"="Ad_sub_cat_code" and tbl_booking_mast.comp_code=adv_subcat_mast.comp_code) as subcat_name,(select "Col_Name" from col_mast where "Col_Code"="Color_code" and tbl_booking_mast.comp_code=col_mast.comp_code) as col_name,"Receipt_no",SAPID
				  from tbl_booking_mast,tbl_booking_insert
				  where tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id"
					--and tbl_booking_mast."Creation_datetime">=TO_date(fromdate,'yyyy/mm/dd')
				  --and tbl_booking_mast."Creation_datetime"<=to_date(todate ,'yyyy/mm/dd')
				   and "ro_status"=@status1 and "Agency_sub_code"=@agency;
				end 
   end else if (@flag='1')begin
    
    select distinct tbl_booking_mast_confirm.cio_booking_id,(select "username" from login where login."userid"=tbl_booking_mast_confirm.Userid) as userid,Insert_Date,Creation_datetime,Total_area,tbl_booking_mast_confirm.PACKAGE_CODE,TBL_BOOKING_INSERT_confirm.Card_Rate as "Card_rate",TBL_BOOKING_insert_confirm.Gross_Rate as "Gross_amount",ro_status,(select "Agency_Name" from agency_mast where agency_mast."code_subcode"=tbl_booking_mast_confirm.Agency_sub_code and tbl_booking_mast_confirm.comp_code=agency_mast.comp_code)as Agency_name,(select "Cust_Name" from cust_mast where "Cust_Code"=Client_code and tbl_booking_mast_confirm.comp_code=cust_mast.comp_code)as client_name,(select "Uom_Name" from uom_mast where uom_mast."Uom_Code"=tbl_booking_mast_confirm.Uom_code and tbl_booking_mast_confirm.comp_code=uom_mast.comp_code)as uom_name,(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=Ad_cat_code and tbl_booking_mast_confirm.comp_code=adv_cat_mast.comp_code)as cat_name,(select "Adv_Subcat_Name" from adv_subcat_mast where "Adv_Subcat_Code"=Ad_sub_cat_code and tbl_booking_mast_confirm.comp_code=adv_subcat_mast.comp_code) as subcat_name,(select "Col_Name" from col_mast where "Col_Code"=Color_code and tbl_booking_mast_confirm.comp_code=col_mast.comp_code) as col_name,Receipt_no,SAPID
      from tbl_booking_mast_confirm,tbl_booking_insert_confirm
     where tbl_booking_mast_confirm.cio_booking_id=tbl_booking_insert_confirm.Cio_Booking_Id
        and tbl_booking_mast_confirm.Creation_datetime>=@fromdate
      and tbl_booking_mast_confirm.Creation_datetime<=@todate
       and tbl_booking_mast_confirm.SEND_STATUS='Y' and AGENCY_SUB_CODE=@agency;
    end else if (@flag='2')begin
						if(@userid='0')begin
					    
						select distinct tbl_booking_mast_confirm.cio_booking_id,(select "username" from login where login."userid"=tbl_booking_mast_confirm.Userid) as userid,Insert_Date,Creation_datetime,Total_area,tbl_booking_mast_confirm.PACKAGE_CODE,TBL_BOOKING_INSERT_confirm.Card_Rate as "Card_rate",TBL_BOOKING_insert_confirm.Gross_Rate as "Gross_amount",ro_status,(select "Agency_Name" from agency_mast where agency_mast."code_subcode"=tbl_booking_mast_confirm.Agency_sub_code and tbl_booking_mast_confirm.comp_code=agency_mast.comp_code)as Agency_name,(select "Cust_Name" from cust_mast where "Cust_Code"=Client_code and tbl_booking_mast_confirm.comp_code=cust_mast.comp_code)as client_name,(select "Uom_Name" from uom_mast where uom_mast."Uom_Code"=tbl_booking_mast_confirm.Uom_code and tbl_booking_mast_confirm.comp_code=uom_mast.comp_code)as uom_name,(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=Ad_cat_code and tbl_booking_mast_confirm.comp_code=adv_cat_mast.comp_code)as cat_name,(select "Adv_Subcat_Name" from adv_subcat_mast where "Adv_Subcat_Code"=Ad_sub_cat_code and tbl_booking_mast_confirm.comp_code=adv_subcat_mast.comp_code) as subcat_name,(select "Col_Name" from col_mast where "Col_Code"=Color_code and tbl_booking_mast_confirm.comp_code=col_mast.comp_code) as col_name,Receipt_no,SAPID
						  from tbl_booking_mast_confirm,tbl_booking_insert_confirm
						 where tbl_booking_mast_confirm.cio_booking_id=tbl_booking_insert_confirm.Cio_Booking_Id
							and tbl_booking_mast_confirm.Creation_datetime>=@fromdate
						  and tbl_booking_mast_confirm.Creation_datetime<=@todate
						   and tbl_booking_mast_confirm.SEND_STATUS='Y' and AGENCY_SUB_CODE=@agency;
						end else begin
					    
						select distinct tbl_booking_mast_confirm.cio_booking_id,(select "username" from login where login."userid"=tbl_booking_mast_confirm.Userid) as userid,Insert_Date,Creation_datetime,Total_area,tbl_booking_mast_confirm.PACKAGE_CODE,TBL_BOOKING_INSERT_confirm.Card_Rate as "Card_rate",TBL_BOOKING_insert_confirm.Gross_Rate as "Gross_amount",ro_status,(select "Agency_Name" from agency_mast where agency_mast."code_subcode"=tbl_booking_mast_confirm.Agency_sub_code  and tbl_booking_mast_confirm.comp_code=agency_mast.comp_code)as Agency_name,(select "Cust_Name" from cust_mast where "Cust_Code"=Client_code  and tbl_booking_mast_confirm.comp_code=cust_mast.comp_code)as client_name,(select "Uom_Name" from uom_mast where uom_mast."Uom_Code"=tbl_booking_mast_confirm.Uom_code  and tbl_booking_mast_confirm.comp_code=uom_mast.comp_code)as uom_name,(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=Ad_cat_code  and tbl_booking_mast_confirm.comp_code=adv_cat_mast.comp_code)as cat_name,(select "Adv_Subcat_Name" from adv_subcat_mast where "Adv_Subcat_Code"=Ad_sub_cat_code  and tbl_booking_mast_confirm.comp_code=adv_subcat_mast.comp_code) as subcat_name,(select "Col_Name" from col_mast where "Col_Code"=Color_code  and tbl_booking_mast_confirm.comp_code=col_mast.comp_code) as col_name,Receipt_no,SAPID
						  from tbl_booking_mast_confirm ,tbl_booking_insert_confirm
						 where tbl_booking_mast_confirm.cio_booking_id=tbl_booking_insert_confirm.Cio_Booking_Id
							and tbl_booking_mast_confirm.Creation_datetime>=@fromdate
						  and tbl_booking_mast_confirm.Creation_datetime<=@todate
						   and tbl_booking_mast_confirm.SEND_STATUS='Y'
						and   tbl_booking_mast_confirm.Userid = @userid1 and AGENCY_SUB_CODE=@agency;
						end 
		   end  
end    
END



/**********************************prachi 4797 20-sept***********/

/************************************************** Prachi 4797 ************************************/
/************************************************** Laxman 4700 ************************************/
ALTER PROCEDURE rpt_branch_collection_summ
    @pcompcode           as varchar(200),
    @pcenter             as varchar(200),
    @punitcode           as varchar(200),
    @pdatefrom           as datetime,
    @pdateto             as datetime,
    @ppaymode            as varchar(200),
    @pagency_type        as varchar(200),
    @pzonecode           as varchar(200),
    @pregioncode         as varchar(200),
    @pstatecode          as varchar(200),
    @pdistcode           as varchar(200),
    @ptalukacode         as varchar(200),
    @pcitycode           as varchar(200),
    @pbased_on           as varchar(200),--branch based on
    @puserid             as varchar(200),
    @pdateformat         as varchar(200),
    @pextra1             as varchar(200),
    @pextra2             as varchar(200),
    @pextra3             as varchar(200),
    @pextra4             as varchar(200),
    @pextra5             as varchar(200)
AS

    declare @v_query1	as varchar(8000)
	declare @rec_paymode_unit	as varchar(20)
	declare @rec_paymode_unit_name	as varchar(200)

	declare @v_var       varchar(4000)
	declare @v_var_sum   varchar(4000)
	declare @v_doctype   varchar(50)

     DECLARE cur_paymode  CURSOR FOR 
		select distinct x.unit as "UNIT",x.unit_name AS "UNIT_NAME"
        from (select distinct h."unit" unit,b."Branch_Name" unit_name
        from agency_mast m,ad_rcpthdr h ,branch_mst b
        where h."comp_code"=@pcompcode and h."unit"=b."Branch_Code" and (h."unit"=@punitcode or @punitcode is null or @punitcode='') and h."doctype" in('RCR','RCP') and 
              h."recptdt" between @pdatefrom and @pdateto and h."ag_main_code"=m."Agency_Code" and h."ag_sub_code"=m."SUB_Agency_Code" and
              (h."reason"=@ppaymode or @ppaymode is null or @ppaymode='') and (m."Agency_Type_Code"=@pagency_type or @pagency_type is null or @pagency_type='') and
              (m."City_Code"=@pcitycode or @pcitycode is null or @pcitycode ='') and (m.state=@pstatecode or @pstatecode is null or @pstatecode='') and
              (m.district=@pdistcode or @pdistcode is null or @pdistcode='') and (m."region"=@pregioncode or @pregioncode is null or @pregioncode='') and
              (m."zone_code"=@pzonecode or @pzonecode is null or @pzonecode='') and (b."pub_center"=@pcenter or @pcenter is null or @pcenter=''))x      
              order by unit_name
    Begin
		
		open cur_paymode
          fetch NEXT FROM cur_paymode INTO @rec_paymode_unit,@rec_paymode_unit_name
          WHILE (@@FETCH_STATUS = 0) 
		  BEGIN
            if @v_var is null Begin
                set @v_var       ='case when h.unit='+''''+@rec_paymode_unit+''''+' then abs(h.amount) else 0 end "'+@rec_paymode_unit+'"'
                set @v_var_sum   ='round(sum("'+@rec_paymode_unit+'"),2)'+' "'+@rec_paymode_unit+'"'
			End
            else Begin
                set @v_var       =@v_var+','+'case when h.unit='+''''+@rec_paymode_unit+''''+' then abs(h.amount) else 0 end "'+@rec_paymode_unit+'"';
                set @v_var_sum   =@v_var_sum+','+'round(sum("'+@rec_paymode_unit+'"),2)'+' "'+@rec_paymode_unit+'"';
            End
		fetch NEXT FROM cur_paymode INTO @rec_paymode_unit,@rec_paymode_unit_name
        End
        close cur_paymode
		deallocate cur_paymode

		print('@v_var')
		print(@v_var)

        if @v_var is null Begin
            set @v_query1='SELECT DISTINCT X.COMP_CODE COMP_CODE,X.RECPTDT RECPTDT,ABS(SUM(X.AMOUNT)) AMT
            from(select h.comp_code comp_code,h.unit unit,h.recptdt recptdt,h.amount amount from agency_mast m,ad_rcpthdr h ,branch_mst b
			where h."comp_code"='+''''+@pcompcode+''''+' and h."unit"=b."Branch_Code" and (h."unit"='+''''+isnull(@punitcode,'')+''''+' or '+''''+isnull(@punitcode,'')+''''+' is null or '+''''+isnull(@punitcode,'')+''''+'='''') and h."doctype" in ('+''''+'RCR'+''''+','+''''+'RCP'+''''+') and 
              h."recptdt" between '+''''+convert(varchar(20),@pdatefrom,101)+''''+' and '+''''+convert(varchar(20),@pdateto,101)+''''+' and h.ag_main_code=m.Agency_Code and h.ag_sub_code=m.SUB_Agency_Code and
              (h."reason"='+''''+isnull(@ppaymode,'')+''''+' or '+''''+isnull(@ppaymode,'')+''''+' is null or '+''''+isnull(@ppaymode,'')+''''+'='''') and (m.Agency_Type_Code='+''''+isnull(@pagency_type,'')+''''+' or '+''''+isnull(@pagency_type,'')+''''+' is null or '+''''+isnull(@pagency_type,'')+''''+'='''') and 
			  (m."City_Code"='+''''+isnull(@pcitycode,'')+''''+' or '+''''+isnull(@pcitycode,'')+''''+' is null or '+''''+isnull(@pcitycode,'')+''''+'='''') and
			  (m.state='+''''+isnull(@pstatecode,'')+''''+' or '+''''+isnull(@pstatecode,'')+''''+' is null or '+''''+isnull(@pstatecode,'')+''''+'='''') and (m."district"='+''''+isnull(@ptalukacode,'')+''''+' or '+''''+isnull(@pdistcode,'')+''''+' is null or '+''''+isnull(@pdistcode,'')+''''+'='''') and
			  (m."region"='+''''+isnull(@pregioncode,'')+''''+' or '+''''+isnull(@pregioncode,'')+''''+' is null or '+''''+isnull(@pregioncode,'')+''''+'='''') and (m."zone_code"='+''''+isnull(@pzonecode,'')+''''+' or '+''''+isnull(@pzonecode,'')+''''+' is null or '+''''+isnull(@pzonecode,'')+''''+'='''') and
			  (m."taluka"='+''''+isnull(@ptalukacode,'')+''''+' or '+''''+isnull(@ptalukacode,'')+''''+' is null or '+''''+isnull(@ptalukacode,'')+''''+'='''') and
              (b."pub_center"='+''''+isnull(@pcenter,'')+''''+' or '+''''+isnull(@pcenter,'')+''''+' is null or '+''''+isnull(@pcenter,'')+''''+'='''')) x
        group by x.comp_code,x.recptdt
        order by comp_code,recptdt'
			End
        else Begin
            set @v_query1='SELECT DISTINCT X.COMP_CODE COMP_CODE,X.RECPTDT RECPTDT,
            '+@v_var_sum+',sum(amt) TOTAL from(select h.comp_code comp_code,h.unit unit,h.recptdt recptdt,'+@v_var+',abs(h.amount) amt from agency_mast m,ad_rcpthdr h ,branch_mst b
			where h."comp_code"='+''''+@pcompcode+''''+' and h."unit"=b."Branch_Code" and (h."unit"='+''''+isnull(@punitcode,'')+''''+' or '+''''+isnull(@punitcode,'')+''''+' is null or '+''''+isnull(@punitcode,'')+''''+'='''') and h."doctype" in ('+''''+'RCR'+''''+','+''''+'RCP'+''''+') and 
              h."recptdt" between '+''''+convert(varchar(20),@pdatefrom,101)+''''+' and '+''''+convert(varchar(20),@pdateto,101)+''''+' and h.ag_main_code=m.Agency_Code and h.ag_sub_code=m.SUB_Agency_Code and
              (h."reason"='+''''+isnull(@ppaymode,'')+''''+' or '+''''+isnull(@ppaymode,'')+''''+' is null or '+''''+isnull(@ppaymode,'')+''''+'='''') and (m.Agency_Type_Code='+''''+isnull(@pagency_type,'')+''''+' or '+''''+isnull(@pagency_type,'')+''''+' is null or '+''''+isnull(@pagency_type,'')+''''+'='''') and 
			  (m."City_Code"='+''''+isnull(@pcitycode,'')+''''+' or '+''''+isnull(@pcitycode,'')+''''+' is null or '+''''+isnull(@pcitycode,'')+''''+'='''') and
			  (m.state='+''''+isnull(@pstatecode,'')+''''+' or '+''''+isnull(@pstatecode,'')+''''+' is null or '+''''+isnull(@pstatecode,'')+''''+'='''') and (m."district"='+''''+isnull(@ptalukacode,'')+''''+' or '+''''+isnull(@pdistcode,'')+''''+' is null or '+''''+isnull(@pdistcode,'')+''''+'='''') and
			  (m."region"='+''''+isnull(@pregioncode,'')+''''+' or '+''''+isnull(@pregioncode,'')+''''+' is null or '+''''+isnull(@pregioncode,'')+''''+'='''') and (m."zone_code"='+''''+isnull(@pzonecode,'')+''''+' or '+''''+isnull(@pzonecode,'')+''''+' is null or '+''''+isnull(@pzonecode,'')+''''+'='''') and
			  (m."taluka"='+''''+isnull(@ptalukacode,'')+''''+' or '+''''+isnull(@ptalukacode,'')+''''+' is null or '+''''+isnull(@ptalukacode,'')+''''+'='''') and
              (b."pub_center"='+''''+isnull(@pcenter,'')+''''+' or '+''''+isnull(@pcenter,'')+''''+' is null or '+''''+isnull(@pcenter,'')+''''+'='''')) x
			group by x.comp_code,x.recptdt
			order by comp_code,recptdt'
        End
		print @v_query1
		exec(@v_query1)

End

/************************************************** Laxman 4700 ************************************/
/************************************************** Anupama 14/9/11 4702 ************************************/

ALTER PROCEDURE rpt_weekwise_billing_summ
    @pcompcode           as varchar(200),
    @pcenter             as varchar(200),
    @pbranchcode         as varchar(200),
    @ppublcode           as varchar(200),
    @pdatefrom           as datetime,
    @pdateto             as datetime,
    @puserid             as varchar(200),
    @pdateformat         as varchar(200),
    @pdate_basedon       as int,----for booking date(1),publish date(2) or on billing date(3)
	@pextra1             as varchar(200),
    @pextra2             as varchar(200),
    @pextra3             as varchar(200),
    @pextra4             as varchar(200),
    @pextra5             as varchar(200),
	@pextra6             as varchar(200),
    @pextra7             as varchar(200),
    @pextra8             as varchar(200),
    @pextra9             as varchar(200),
    @pextra10            as varchar(200)
AS
    declare @v_query             varchar(8000)
    declare @rec_v1_comp_code    varchar(200)
	declare @rec_v1_pcenter	     varchar(200)
	declare @rec_v1_branch_code  varchar(200)
	declare @rec_v1_branch_name  varchar(200)    
	declare @rec_v1_bill_date    datetime
    declare @rec_v1_publ_code    varchar(200)
    declare @rec_v1_publ_name    varchar(200)
    declare @rec_v1_ad_cat       varchar(200)
    declare @rec_v1_adcat_name   varchar(200)
    declare @rec_v1_insertion_no numeric(10)
    declare @rec_v1_amount       numeric(18,2)
    declare @v_week_name         varchar(10)

	declare c1 cursor for
        select x.comp_code,x.pub_center,x.branch_code,x.branch_name, x.bill_date ,x.publ_code,x.publ_name,
        x.ad_cat,x.adcat_name,x.insertion_no,isnull(x.amount,0) from
        (select m."Comp_code" comp_code,b."pub_center" pub_center,b."Branch_Code" branch_code,b."Branch_Name" branch_name,m."date_time" bill_date,
        i."Publication_Code" publ_code,(select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=i."Publication_Code") publ_name,
        i."Ad_Cat" ad_cat,c."Adv_Cat_Name" adcat_name,
        count(i."No_Insert") insertion_no,round(Sum(i."Bill_Amt"),2) amount
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=@pcompcode and c."Comp_Code"=m."Comp_code" and c."Adv_Cat_Code"=i."Ad_Cat" and 
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"+a."SUB_Agency_Code"=m."Agency_sub_code" and 
        m."date_time" between @pdatefrom and @pdateto and  
		m."branch"=b."Branch_Code" and
        (b."Branch_Code"=@pbranchcode or @pbranchcode is null or @pbranchcode='') and (b."pub_center"=@pcenter or @pcenter is null or @pcenter='') and
        (i."Publication_Code"=@ppublcode or @ppublcode is null or @ppublcode='') and @pdate_basedon=1
        group by m."Comp_code",b."pub_center",b."Branch_Code",b."Branch_Name",m."date_time",i."Publication_Code",i."Ad_Cat",c."Adv_Cat_Name"
        union 
        select m."Comp_code" comp_code,b."pub_center" pub_center,b."Branch_Code" branch_code,b."Branch_Name" branch_name,i."Insert_Date" bill_date,
        i."Publication_Code" publ_code,(select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=i."Publication_Code") publ_name,
        i."Ad_Cat" ad_cat,c."Adv_Cat_Name" adcat_name,
        count(i."No_Insert") insertion_no,round(Sum(i."Bill_Amt"),2) amount
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=@pcompcode and c."Comp_Code"=m."Comp_code" and c."Adv_Cat_Code"=i."Ad_Cat" and 
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"+a."SUB_Agency_Code"=m."Agency_sub_code" and 
        i."Insert_Date" between @pdatefrom and @pdateto and  
        m."branch"=b."Branch_Code" and
        m."branch"=b."Branch_Name" and
        (b."Branch_Code"=@pbranchcode or @pbranchcode is null or @pbranchcode='') and (b."pub_center"=@pcenter or @pcenter is null or @pcenter='') and
        (i."Publication_Code"=@ppublcode or @ppublcode is null or @ppublcode='') and @pdate_basedon=2
        group by m."Comp_code",b."pub_center",b."Branch_Code",b."Branch_Name",i."Insert_Date",i."Publication_Code",i."Ad_Cat",c."Adv_Cat_Name"
        union 
        select m."Comp_code" comp_code,b."pub_center" pub_center,b."Branch_Code" branch_code,b."Branch_Name" branch_name,i.bill_date bill_date,
        i."Publication_Code" publ_code,(select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=i."Publication_Code") publ_name,
        i."Ad_Cat" ad_cat,c."Adv_Cat_Name" adcat_name,
        count(i."No_Insert") insertion_no,round(Sum(i."Bill_Amt"),2) amount
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=@pcompcode and c."Comp_Code"=m."Comp_code" and c."Adv_Cat_Code"=i."Ad_Cat" and 
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"+a."SUB_Agency_Code"=m."Agency_sub_code" and 
        i.bill_date between @pdatefrom and @pdateto and 
        m."branch"=b."Branch_Code" and
        (b."Branch_Code"=@pbranchcode or @pbranchcode is null or @pbranchcode='') and (b."pub_center"=@pcenter or @pcenter is null or @pcenter='') and
        (i."Publication_Code"=@ppublcode or @ppublcode is null or @ppublcode='') and @pdate_basedon=3
        group by m."Comp_code",b."pub_center",b."Branch_Code",b."Branch_Name",i.bill_date,i."Publication_Code",i."Ad_Cat",c."Adv_Cat_Name") x
        
    declare @v_rec_seqno numeric(10)         
    
    declare @v_var       varchar(4000)
    declare @v_var_sum   varchar(4000)
Begin

CREATE TABLE #TEMP_AD_RECEIPT_REPORT
( COMP_CODE         VARCHAR(10),
  UNIT_CODE         VARCHAR(10),
  PCENTRE_CODE      VARCHAR(10),
  AGCODE            VARCHAR(50),
  RECPTNO           VARCHAR(50),
  RECPTDT           DATEtime,
  AMOUNT            float,
  REP_CODE          VARCHAR(20),
  REMARKS           VARCHAR(500),
  CHQNO             VARCHAR(50),
  CHQDT             DATEtime,
  CHQ_BANK          VARCHAR(100),
  REASON            VARCHAR(30),
  BILLNO            VARCHAR(50),
  BILLDT            DATEtime,
  BILLAMT           float,
  ADJAMT            float,
  LEFTAMT           float,
  RET_CODE          VARCHAR(200),
  EXE_CODE          VARCHAR(200),
  SESS_ID           int         ,
  DEBIT_HEAD        VARCHAR(200),
  CREDIT_HEAD       VARCHAR(200),
  AG_MAIN_CODE      VARCHAR(20),
  AG_SUB_CODE       VARCHAR(20),
  DOCTYPE           VARCHAR(10),
  REC_SEQNO         int,
  RECOVARY_DAYS     int,
  AGNAME            VARCHAR(500),
  AD_RATE           float,
  AD_SIZE           float,
  AD_COLOR          VARCHAR(5),
  AD_SUB_CATEGORY   VARCHAR(200),
  AD_PACKAGE        VARCHAR(500),
  INSDATE           DATEtime,
  CLIENT            VARCHAR(200),
  AD_MAIN_CATEGORY  VARCHAR(200),
  RECOVERY_DAYS		VARCHAR(200),
  ADDR				VARCHAR(500))

    open c1
    fetch NEXT FROM C1 INTO @rec_v1_comp_code,@rec_v1_pcenter,@rec_v1_branch_code,@rec_v1_branch_name,@rec_v1_bill_date,@rec_v1_publ_code,@rec_v1_publ_name,@rec_v1_ad_cat,@rec_v1_adcat_name,@rec_v1_insertion_no,@rec_v1_amount
		WHILE (@@FETCH_STATUS = 0) 
		BEGIN

        SET @v_rec_seqno=ISNULL(@v_rec_seqno,0)+1
		PRINT(@rec_v1_bill_date)
		PRINT(@pdatefrom)
		SET @v_week_name='WEEK '+CONVERT(VARCHAR(10),((CONVERT(INT,(@rec_v1_bill_date-@pdatefrom))/7)+1))

		PRINT @v_week_name
        insert into #temp_ad_receipt_report
                (comp_code,unit_code,pcentre_code,recptdt,exe_code,ad_main_category,ret_code,ad_sub_category,recovary_days,
                amount,rec_seqno,debit_head,doctype)
          values(@rec_v1_comp_code,@rec_v1_branch_code,@rec_v1_pcenter,@rec_v1_bill_date,@rec_v1_ad_cat,@rec_v1_adcat_name,@rec_v1_publ_code,@rec_v1_publ_name,@rec_v1_insertion_no,
                @rec_v1_amount,@v_rec_seqno,@rec_v1_branch_name,@v_week_name)
    fetch NEXT FROM C1 INTO @rec_v1_comp_code,@rec_v1_pcenter,@rec_v1_branch_code,@rec_v1_branch_name,@rec_v1_bill_date,@rec_v1_publ_code,@rec_v1_publ_name,@rec_v1_ad_cat,@rec_v1_adcat_name,@rec_v1_insertion_no,@rec_v1_amount
	End
	close c1
	deallocate c1

	SET @rec_v1_ad_cat=NULL
	SET @rec_v1_adcat_name=NULL

    declare c11 cursor for
            select distinct doctype from #temp_ad_receipt_report 
			order by doctype
	
    SET @v_week_name=NULL
	open c11
		fetch NEXT FROM C11 INTO @v_week_name
		WHILE (@@FETCH_STATUS = 0) 
		BEGIN
            if @v_var is null or @v_var='' Begin
                SET @v_var       ='case when d.doctype='+''''+@v_week_name+''''+' then d.recovary_days else 0 end "'+'R#'+@v_week_name+'"'
                SET @v_var       =@v_var+','+'case when d.doctype='+''''+@v_week_name+''''+' then d.amount else 0 end "'+'A#'+@v_week_name+'"'
                SET @v_var_sum   ='round(sum("'+'R#'+@v_week_name+'"),2)'+' "'+'R#'+@v_week_name+'"'
                SET @v_var_sum   =@v_var_sum+','+'sum("'+'A#'+@v_week_name+'")'+' "'+'A#'+@v_week_name+'"'
				End
            else Begin
                SET @v_var       =@v_var+','+'case when d.doctype='+''''+@v_week_name+''''+' then d.recovary_days else 0 end "'+'R#'+@v_week_name+'"'
                SET @v_var       =@v_var+','+'case when d.doctype='+''''+@v_week_name+''''+' then d.amount else 0 end "'+'A#'+@v_week_name+'"'
                SET @v_var_sum   =@v_var_sum+','+'round(sum("'+'R#'+@v_week_name+'"),2)'+' "'+'R#'+@v_week_name+'"'
                SET @v_var_sum   =@v_var_sum+','+'sum("'+'A#'+@v_week_name+'")'+' "'+'A#'+@v_week_name+'"'
            End 
		fetch NEXT FROM C11 INTO @v_week_name
		End
     close c11
	 
        
    if @v_var is null or @v_var='' Begin
       set @v_query='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.branch_code AS "BRANCH_CODE",x.branch_name AS "BRANCH_NAME",
        x.publ_code AS "PUBL_CODE",x.publ_name AS "PUBL_NAME",
        round(sum("AMOUNT"),2) as "TOTOL",  sum("NO_OF_INSERT") as "NO_OF_INSERT" from
        (select d.comp_code,d.unit_code branch_code,d.debit_head branch_name,d.ret_code publ_code,d.ad_sub_category publ_name,
       ISNULL(d.recovary_days,0) no_of_insert,ISNULL(d.amount,0) amount from #temp_ad_receipt_report d ) x 
       group by x.comp_code,x.publ_code,x.publ_name,x.branch_code,x.branch_name order by x.comp_code,x.branch_name,x.publ_name,x.publ_code '
		End
    else Begin
       set @v_query='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.branch_code AS "BRANCH_CODE",x.branch_name AS "BRANCH_NAME",
        x.publ_code AS "PUBL_CODE",x.publ_name AS "PUBL_NAME",
        '+@v_var_sum+' ,round(sum("AMOUNT"),2) as "TOTOL",  sum("NO_OF_INSERT") as "NO_OF_INSERT" from
        (select d.comp_code,d.unit_code branch_code,d.debit_head branch_name,d.ret_code publ_code,d.ad_sub_category publ_name,
       '+@v_var+',ISNULL(d.recovary_days,0) no_of_insert,ISNULL(d.amount,0) amount from #temp_ad_receipt_report d ) x 
       group by x.comp_code,x.publ_code,x.publ_name,x.branch_code,x.branch_name order by x.comp_code,x.branch_name,x.publ_name,x.publ_code'
    End
        
	print(@v_query)
	exec(@v_query)
        
    if @v_var is null or @v_var='' Begin
       set @v_query='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.branch_code AS "BRANCH_CODE",x.branch_name AS "BRANCH_NAME",
        round(sum("AMOUNT"),2) as "TOTOL",  sum("NO_OF_INSERT") as "NO_OF_INSERT" from
        (select d.comp_code,d.unit_code branch_code,d.debit_head branch_name,d.ret_code publ_code,d.ad_sub_category publ_name,
       ISNULL(d.recovary_days,0) no_of_insert,ISNULL(d.amount,0) amount from #temp_ad_receipt_report d ) x 
       group by x.comp_code,x.branch_code,x.branch_name order by x.comp_code,x.branch_name'
		End
    else Begin
       set @v_query='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.branch_code AS "BRANCH_CODE",x.branch_name AS "BRANCH_NAME",
        '+@v_var_sum+' ,round(sum("AMOUNT"),2) as "TOTOL",  sum("NO_OF_INSERT") as "NO_OF_INSERT" from
        (select d.comp_code,d.unit_code branch_code,d.debit_head branch_name,d.ret_code publ_code,d.ad_sub_category publ_name,
       '+@v_var+',ISNULL(d.recovary_days,0) no_of_insert,ISNULL(d.amount,0) amount from #temp_ad_receipt_report d ) x 
       group by x.comp_code,x.branch_code,x.branch_name order by x.comp_code,x.branch_name'
    End

	print(@v_query)
	exec(@v_query)
	
	
	deallocate c11
    drop table #temp_ad_receipt_report
End
/************************************************** Anupama 14/9/11 4702 ************************************/
/************************************************** Mimoh 14/9/11 4683,4569 ************************************/
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
    Branch_code varchar (20)
) 

	
DECLARE sss CURSOR 
--FOR select distinct Advcategory,publication,suppliment,edition, currency,contractcode,color,uom,packagecode,premiumcode from contract_detail where comp_code=@compcode and userid=@userid and deal_code=@dealno
--FOR select Exec_name,Designation,Add1,Street,city_code,dist_code,State_code,Country_code,pin_code,phone,exe_status,Exe_no,city_name,Team_code,zip,comp_code,userid,report_to from Exec_mast where comp_code=@compcode  and Team_code =@teamcode
FOR select distinct  Designation,city_code,Country_code,report_to,Exe_no,TALUKA ,REPRESENTATIVE,Branch_code  from Exec_mast where comp_code=@compcode  and Team_code =@teamcode



OPEN sss
FETCH NEXT FROM sss into @Designation,@city_code,@Country_code,@report_to,@Exe_no,@TALUKACODE,@Repcode,@Branch_code


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

insert into #tmpExec_mast select distinct Exe_no,Team_code,Exec_name,@Designation1,Add1,Street,@Country_code1,State_code,dist_code,@city_code1,zip,phone,exe_status,userid,comp_code,pin_code,city_name,@report_to1,exec_userid,exec_emailid ,@TALUKA2 ,@repname as repname,@Branch_Name from Exec_mast where comp_code=@compcode  and Team_code =@teamcode and Exe_no=@Exe_no
set @report_to1=''
set @EXEC_USERID=''
set @EXEC_EMAILID=''
set @TALUKA2=''
set @repname=''
FETCH NEXT FROM sss into @Designation,@city_code,@Country_code,@report_to,@Exe_no,@TALUKACODE,@Repcode,@Branch_code
end
CLOSE sss
DEALLOCATE sss

--select * from #tmpContract_detail


--select *  from #tmpExec_mast


set @query='select  distinct Exe_no,Exec_name, Designation,Add1,Street, city_code,dist_code,State_code, Country_code,pin_code,phone,exe_status,Exe_no,city_name,Branch_code,report_to,exec_userid,exec_emailid ,TALUKA , REPRESENTATIVE as repname from #tmpExec_mast'


--delete from #tmpExec_mast


print(@query)
exec(@query)
drop table #tmpExec_mast
--select ContractCode,Advcategory,publication,suppliment,edition,Bookedfor,packagecode,color,cardrate,Dealarte,premiumcode,cardpremium,dealpremium,volumebilled,volumedisc,valuefrom,valueto,Uom, currency, convertrate,deal_code,ContractCode from contract_detail where comp_code=@compcode and userid=@userid and deal_code=@dealno


/************************************************** Mimoh 14/9/11  4683,4569 ************************************/

/************************************************** Mimoh 15/9/11  4912 ************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go







ALTER PROCEDURE  [dbo].[websp_agencymodify]

@compcode as varchar(25),
@agencytype as varchar(25),
@agentcategory as varchar(25),
@agentcategory2 varchar(50),
@agentcode as varchar(25),
@agentname as varchar(50),
@alias as varchar(50),
@agencyho as varchar(25),
@type as varchar(5),
@address as varchar(25),
@street as varchar(25),
@city varchar(50),
@zip as varchar(25),
@district as varchar(25),
@state as varchar(25),
@country as varchar(25),
@phone as varchar(25),
@txtfax2 as varchar(15),
@fax varchar(50),
@mail as varchar(25),
@url as varchar(25),
@bussinessstartdate as DATETIME,
@enrolldate as DATETIME,
@novts as varchar(25),
@credit as varchar(25),
@pan as varchar(25),
@tan as varchar(25),
@stacno as varchar(25),
@paymode as varchar(25),

@status as varchar(250),
@remarks as varchar(200),
@userid as varchar(10),

@mrerefferenceno as varchar(50),
@subagencyho as varchar(10),

@agencycode as varchar(8),
@billto as varchar(50),
@alert as varchar(200),
@creditlimit as varchar(10),
@code as varchar(12),
@region as varchar(10),
@representative as varchar(10),
@pincode as varchar(12),
@stacno1 as varchar(25),
@zone as varchar(8),

@address1 as varchar(50),
@address2 as varchar(50),
@curtype as varchar(8),
@acagen as varchar(8),
@rategrp as varchar(8),
@qbcuserid as varchar(50),
@depocode as varchar(8),
@taluka as varchar(50),
@branchcode    as varchar(20),
@hddistcode as varchar(50),
@hdstatecode    as varchar(20),
@billf as varchar(8),
@oldagen as varchar(50),
@booktype as varchar(100),
@vat as varchar(1)


AS
declare @query as varchar(2000)
declare @query1 as varchar(2000)

update Agency_mast set Rate_Group=@rategrp, Agency_Code=@agentcode , fax1=@txtfax2,CREDIT_TYPE=@curtype, zone_code=@zone,  type=@type, Agency_Type_Code=@agencytype,Agency_Cat_Code=@agentcategory,Agency_SubCat_Code=@agentcategory2,Agency_Name=@agentname,Agency_Alias=@alias,Agency_HO=@agencyho,Add1=@address,Street=@street,City_Code=@city,Zip=@zip,Dist_Code=@district,State_Code=@state,Country_Code=@country,Phone=@phone,Fax=@fax,EmailID=@mail,URL=@url,Buss_Start_Date=@bussinessstartdate,Enroll_Date=@enrolldate ,MRV_Ref_No=@mrerefferenceno,No_of_VTS=@novts,Credit_Days=@credit,PAN_No=@pan,TAN_No=@tan,ST_ACC_No=@stacno1,Pay_Mode_Code=@paymode,Status_Reason=@status,Remarks=@remarks,SUB_Agency_HO=@subagencyho,SUB_Agency_Code=@agencycode ,BILL_TO =@acagen, acagency=@billto,ALERT=@alert,credit_limit=@creditlimit,code=@code ,region=@region,representative_code=@representative,pin_code=@pincode,Add2=@address1,Add3=@address2,qbc_userid=@qbcuserid , TALUKA=@taluka , Branch_code=@branchcode, DISTRICT=@hddistcode,STATE=@hdstatecode,BILL_FREQUENCY=@billf,OLD_AGENCY=@oldagen,BOOKING_TYPE=@booktype,VAT=@vat where Comp_Code=@compcode  AND  SUB_Agency_Code=@agencycode

print(@query)
exec(@query)
print(@query1)
exec(@query1)







set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go








ALTER PROCEDURE [dbo].[websp_executeagency]

@compcode as varchar(9),
@userid as varchar(9),
@agentcode as varchar(12),
@subagencycode as varchar(15),
@agencyname1  as varchar(50),
@alias as varchar(30),
@agenttype as varchar(12),
@agentcategory as varchar(12),
@agentsubcategory as varchar(12),
@city as varchar(12),
@count as varchar(12),
@branchcode    as varchar(20),
@billf as varchar(8)

AS

--Comp_Code,Agency_Type_Code,Agency_Cat_Code,Agency_SubCat_Code,Agency_Code,Agency_Name,Agency_Alias,Agency_HO,Add1,Street,City_Code,Zip,Dist_Code,State_Code,Country_Code,Phone,Fax,EmailID,URL,Buss_Start_Date,Enroll_Date,MRV_Ref_No,No_of_VTS,Credit_Days ,PAN_No,TAN_No,ST_ACC_No,Pay_Mode_Code,Agency_Status,Status_Reason,Remarks,UserID,Creation_Datetime,SUB_Agency_HO,SUB_Agency_Code
declare @query as varchar(2000)

declare @comp as varchar(10)
declare @agencytycode as varchar(10)
declare @agencycatcode as varchar(10)
declare @agencysubcat as varchar(10)
declare @agencycod as varchar(10)
declare @agencyname as varchar(30)
declare @agencyalias as varchar(30)
declare @agencyho  as varchar(15)
declare @add as varchar(30)
declare @agencystreet as varchar(30)
declare @agencycity as varchar(10)
declare @agencyzip as varchar(10)
declare @agencudistt as varchar(10)
declare @agencystate as varchar(10)
declare @agencycountry as varchar(10)
declare @agencyphone as varchar(10)
declare @fax as varchar(10)
declare @mail as varchar(20)
declare @url as varchar(20)
declare @buss as VARCHAR(20)
declare @enroll as VARCHAR(20)
declare @mrv as varchar(10)
declare @nov as varchar(10)
declare @credit as varchar(10)
declare @pan as varchar(10)
declare @tan as varchar(10)
declare @st as varchar(10)
declare @pay as varchar(10)
declare @status as varchar(10)
declare @reason as varchar(200)
declare @remarks as varchar(200)
declare @user as varchar(10)
declare @date as varchar(20)
declare @use as varchar(10)
declare @subagencyho as varchar(10)
declare @sagencode as varchar(10)
declare @bill as varchar(10) 
declare @alert as varchar(200)
declare @crlimit as varchar(10)
declare @cod as varchar(10)
declare @repcode as varchar(10)
declare @pin as varchar(10)
declare @region as varchar(10)
declare @todate as varchar(10)
declare @query1 as varchar(1000)
declare @firstagencycode as varchar(100)
declare @agen as varchar(100)
declare @check as varchar(900)




declare @agencycode as varchar(100)
declare @abc as varchar(100)
DECLARE @AuthorID char(11)
declare @query5 as varchar(1000)
declare @query6 as varchar(1000)
declare @xx as varchar(1000)

declare @agencyname2 as varchar(50)

declare @agentcode1 as varchar(12)

declare @subagencycode1 as varchar(15)

declare @alias1 as varchar(30)

declare @vat as varchar(1)

CREATE TABLE #first (
	Comp_Code varchar (50)  ,
	Agency_Type_Code varchar (50)  ,
	Agency_Cat_Code varchar (50)  ,
	Agency_SubCat_Code varchar (50)  ,
	Agency_Code varchar (50)  ,
	Agency_Name varchar (50)  ,
	Agency_Alias varchar (50)  ,
	Agency_HO varchar (50)  ,
	Add1 varchar (50)  ,
	Street varchar (50)  ,
	City_Code varchar (50)  ,
	Zip varchar (50)  ,
	Dist_Code varchar (50)  ,
	State_Code varchar (50)  ,
	Country_Code varchar (50)  ,
	Phone varchar (50)  ,
	Fax varchar (50)  ,
	EmailID varchar (50)  ,
	URL varchar (50)  ,
	Buss_Start_Date datetime NULL ,
	Enroll_Date datetime NULL ,
	MRV_Ref_No varchar (50)  ,
	No_of_VTS varchar (50)  ,
	Credit_Days varchar (50)  ,
	PAN_No varchar (50)  ,
	TAN_No varchar (50)  ,
	ST_ACC_No varchar (50)  ,
	Pay_Mode_Code varchar (50)  ,
	status_name varchar (50)  ,
	Status_Reason varchar (500)  ,
	Remarks varchar (500)  ,
	UserID varchar (50)  ,
	current_Datetime datetime NULL ,
	users varchar (50)  ,
	SUB_Agency_HO varchar (50)  ,
	SUB_Agency_Code varchar (50)  ,
	BILL_TO varchar (50)  ,
	ALERT varchar (500)  ,
	CREDIT_LIMIT varchar (50)  ,
	CODE varchar (50)  ,
	representative_code varchar (50)  ,
	pin_code varchar (50)  ,
	region varchar (50)  ,
	to_date datetime NULL ,
	Type varchar (5)  ,
	code_subcode varchar (16)  ,
	zone_code varchar (8)  ,
	Add2 varchar (50)  ,
	Add3 varchar (50)  ,
	CREDIT_TYPE varchar (8)  ,
	acagency varchar (12)  ,
	fax1 varchar (15) ,
	Rate_Group varchar(8) ,
	qbc_userid varchar(50),
    TALUKA varchar(8),
    Branch_code varchar(20),
	billf varchar(8),
    VAT varchar(1)
)



set @agencyname2= replace(@agencyname1,'''','''')

set  @agentcode1=  replace(@agentcode ,'''','''')

set @subagencycode1=replace(@subagencycode,'''','''')

set @alias1=replace(@alias,'''','''')


--set @query=' insert  #first select a.Comp_Code,a.Agency_Type_Code,a.Agency_Cat_Code,a.Agency_SubCat_Code,a.Agency_Code,a.Agency_Name,a.Agency_Alias,a.Agency_HO,a.Add1,a.Street,a.City_Code,a.Zip,a.Dist_Code,a.State_Code,a.Country_Code,a.Phone,a.Fax,a.EmailID,a.URL,a.Buss_Start_Date,a.Enroll_Date,a.MRV_Ref_No,a.No_of_VTS,a.Credit_Days ,a.PAN_No,a.TAN_No,a.ST_ACC_No,a.Pay_Mode_Code,,a.Status_Reason,a.Remarks,a.UserID,getdate(),a.userid,a.SUB_Agency_HO,a.SUB_Agency_Code,a.BILL_TO,a.ALERT,a.CREDIT_LIMIT,a.CODE,a.representative_code,a.pin_code,a.region ,,a.type, a.code_subcode,a.zone_code,a.add2,a.add3,a.CREDIT_TYPE,a.acagency,a.fax1, a.Rate_Group,a.qbc_userid, a.TALKUA from Agency_mast a where a.userid='''+@userid+''' and a.comp_code='''+@compcode+''' '
set @query='SELECT Comp_Code, Agency_Type_Code, Agency_Cat_Code,  Agency_SubCat_Code, Agency_Code, Agency_Name AS Agency_Name,Agency_Alias, Agency_HO, Add1, Street, City_Code,
                Zip, Dist_Code, State_Code, Country_Code, Phone,
                Fax, EmailID, URL, Buss_Start_Date, Enroll_Date,
                MRV_Ref_No, No_of_VTS, Credit_Days, PAN_No, TAN_No,
                ST_ACC_No, Pay_Mode_Code,
                (select status_name from tblstatus where comp_code='''+@compcode+''' and status_code=(SELECT top 1 status_name FROM STATUS_DETAIL WHERE comp_code='''+@compcode+''' and  STATUS_DETAIL.agency_code+STATUS_DETAIL.agency_subcat_code = AGENCY_MAST.code_subcode)) AS status_name,
                Status_Reason, Remarks, UserID, getdate() AS current_Datetime, UserID,
                SUB_Agency_HO AS SUB_Agency_HO, SUB_Agency_Code AS SUB_Agency_Code, BILL_TO, ALERT,
                CREDIT_LIMIT, CODE, Representative_code as representative_code, pin_code, region,
                (SELECT top 1 TO_DATE FROM STATUS_DETAIL
                  WHERE  agency_code = AGENCY_MAST.Agency_Code) AS to_date,
                (SELECT top 1 FROM_DATE FROM STATUS_DETAIL
                  WHERE  agency_code = AGENCY_MAST.Agency_Code) AS FROM_DATE,
                Type, code_subcode, zone_code, Add2, Add3,
                CREDIT_TYPE, acagency, fax1, Rate_Group,
                qbc_userid,(select DEPO_CODE from ad_user where ad_user.AGENCY_CODE=agency_mast.code_subcode) AS DEPOCODE,
                (select AGENCY_CODE from ad_user where ad_user.AGENCY_CODE=agency_mast.code_subcode) AS AGENCYCODE,TALUKA ,Branch_code,(select dist_mst.Dist_Name from dist_mst where dist_mst.Dist_Code=agency_mast.DISTRICT) as DISTRICT,(select state_mst.State_Name from state_mst where state_mst.State_Code=agency_mast.STATE) as STATE,BILL_FREQUENCY,OLD_AGENCY,BOOKING_TYPE,VAT FROM AGENCY_MAST  where comp_code='''+@compcode+''' '

if(@agentcode1 <> '')
begin

set @query= @query + 'and  agency_code  like ''%'+@agentcode1+'%'''
end



if(@subagencycode1 <> '')
begin

set @query  =  @query + 'and SUB_Agency_Code like ''%'+@subagencycode1+'%'' '
end



if(@agencyname2 <> '')
begin

set @query  =  @query + 'and Agency_Name like ''%'+@agencyname2 +'%'''
end

if(@alias1 <> '')
begin

set @query  =  @query + 'and Agency_Alias  like ''%'+@alias1 +'%'''
end



if(@agenttype <> '' and @agenttype <> '0')
begin

set @query  =  @query + 'and agency_type_code  like ''%'+@agenttype +'%'''
end


if(@agentcategory <> '' and @agentcategory <> '0')
begin

set @query  =  @query + 'and agency_type_code  like ''%'+@agentcategory +'%'''
end





if(@agentsubcategory <> '' and @agentsubcategory <> '0')
begin

set @query  =  @query + 'and Agency_Cat_Code  like ''%'+@agentsubcategory +'%'''
end



if(@city <> '' and @city <> '0')
begin

set @query  =  @query + 'and City_Code  like ''%'+@city +'%'''
end


if(@count <> '' and @count <> '0')
begin

set @query  =  @query + 'and Country_Code  like ''%'+@count +'%'''
end

if(@branchcode <> '' and @branchcode <> '0')
begin

set @query= @query + 'and  Branch_code  like ''%'+@branchcode+'%'''
end
if(@billf <> '' and @billf <> '0')
begin

set @query  =  @query + 'and BILL_FREQUENCY  like ''%'+@billf +'%'''
end

print(@query)
exec(@query)

DECLARE c1 CURSOR READ_ONLY
FOR
select  sub_agency_code from first order by sub_agency_code

OPEN c1

FETCH NEXT FROM c1
INTO @AuthorID

WHILE @@FETCH_STATUS = 0
BEGIN

	--PRINT @AuthorID

	









--set @query='select     top 1   @xx= status_name ,agency_code   from status_detail where agency_code='''+@AuthorID+''' order by current_datetime desc,agency_code'

set @query5='update #first set status_name= (select     top 1    status_name    from status_detail where agency_subcat_code='''+@AuthorID+''' order by current_datetime   )   where sub_agency_code='''+@AuthorID+''''

set @query6='update #first set to_date= (select     top 1    to_date    from status_detail where agency_subcat_code='''+@AuthorID+'''  order by current_datetime   )   where sub_agency_code='''+@AuthorID+''''

print(@xx)
exec(@xx)
print(@query5)
exec(@query5)

print(@query6)
exec(@query6)
FETCH NEXT FROM c1
	INTO @AuthorID


END

CLOSE c1
DEALLOCATE c1








select   distinct  *  from #first  order by agency_code
drop table #first














set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go










ALTER PROCEDURE  [dbo].[websp_saveagent]

@compcode as varchar(25),
@agencytype as varchar(25),
@agentcategory as varchar(25),
@agentcategory2 varchar(50),
@agentcode as varchar(25),
@agentname as varchar(50),
@alias as varchar(50),
@agencyho as varchar(25),
@txtfax1 as varchar(15),
@address as varchar(50),
@street as varchar(50),
@city varchar(50),
@zip as varchar(25),
@district as varchar(50),
@state as varchar(50),
@country as varchar(25),
@phone as varchar(25),

@fax varchar(50),
@mail as varchar(50),
@url as varchar(50),
@bussinessstartdate as DATETIME,
@enrolldate as DATETIME,
@novts as varchar(25),
@credit as varchar(25),
@pan as varchar(25),
@tan as varchar(25),
@stacno as varchar(25),
@paymode as varchar(25),
--@statusdrp as varchar(25),
@status as varchar(250),
@remarks as varchar(200),
@userid as varchar(10),

@mrerefferenceno as varchar(50),
@subagencyho as varchar(10),

@agencycode as varchar(8),
@billto as varchar(50),
@alert as varchar(200),
@creditlimit as varchar(10),
@code as varchar(16),
@representative as varchar(10),
@pin as varchar(15),
@region as varchar(25),
@type as varchar(5),
@zone as varchar(8),
@address1 as varchar(50),
@address2 as varchar(50),
@curtype as varchar(8),
@acagen as varchar(12),
@rategrp as varchar(8),
@qbcuserid as varchar(50),
@taluka as varchar(50),
@branchcode    as varchar(20),
@hddistcode as varchar(50),
@hdstatecode    as varchar(20),
@billf as varchar(8),
@oldagency as varchar(50),
@booktype as varchar(100),
@vat as varchar(1)     
--@bank as varchar(30),
--@validitydate as DATETIME




AS

--insert into Agency_mast(Comp_Code,Agency_Type_Code,Agency_Cat_Code,Agency_SubCat_Code,Agency_Code,Agency_Name,Agency_Alias,Agency_HO,Add1,Street,City_Code,Zip,Dist_Code,State_Code,Country_Code,Phone,Fax,EmailID,URL,Buss_Start_Date,Enroll_Date,MRV_Ref_No,No_of_VTS,Credit_Days ,PAN_No,TAN_No,ST_ACC_No,Pay_Mode_Code,Agency_Status,Status_Reason,Remarks,UserID,Creation_Datetime,SUB_Agency_HO,SUB_Agency_Code,BILL_TO,ALERT,CREDIT_LIMIT,CODE,representative_code,pin_code) values (@compcode,@agencytype,@agentcategory,@agentcategory2,@agentcode,@agentname,@alias,@agencyho,@address,@street,@city,@zip,@district,@state,@country,@phone,@mail,@fax,@url,@bussinessstartdate,@enrolldate,@mrerefferenceno,@novts,@credit,@pan,@tan,@stacno,@paymode,@statusdrp,@status,@remarks,@userid,@statusdate,@subagencyho,@agencycode,@billto,@alert ,@creditlimit,@code,@representative,@pin)
insert into Agency_mast(Comp_Code,Agency_Type_Code,Agency_Cat_Code,Agency_SubCat_Code,Agency_Code,Agency_Name,Agency_Alias,Agency_HO,Add1,     Street,City_Code,Dist_Code,State_Code,Country_Code,Phone,Fax,EmailID,URL,Buss_Start_Date,     Enroll_Date,MRV_Ref_No,      No_of_VTS,Credit_Days ,PAN_No,TAN_No,ST_ACC_No,Pay_Mode_Code,Status_Reason,Remarks, UserID, SUB_Agency_HO,SUB_Agency_Code,acagency,ALERT, CREDIT_LIMIT, CODE, representative_code,pin_code,region, type, code_subcode,          zone_code,Add2,     Add3,     CREDIT_TYPE,BILL_TO,fax1,    Rate_Group, qbc_userid,TALUKA,   zip,Branch_code,DISTRICT,    STATE,      BILL_FREQUENCY,OLD_AGENCY,BOOKING_TYPE,VAT) values 
						(@compcode,@agencytype,    @agentcategory, @agentcategory2,   @agentcode, @agentname, @alias,      @agencyho,@address,@street,@city,    @district,@state,    @country,    @phone,@fax,@mail,@url,@bussinessstartdate,@enrolldate,@mrerefferenceno,@novts,   @credit,     @pan,  @tan,  @stacno,  @paymode,     @status,      @remarks,@userid,@subagencyho, @agencycode,    @acagen, @alert ,@creditlimit,@code,@representative,    @pin,    @region,@type,@agentcode+@agencycode,@zone,    @address1,@address2,@curtype,   @billto,@txtfax1,@rategrp,   @qbcuserid, @taluka,@zip,@branchcode,@hddistcode,@hdstatecode,@billf,        @oldagency,@booktype,   @vat)












/************************************************** Mimoh 15/9/11  4912 ************************************/
/************************************************Laxman Sir 16/9/11 4689******************************/
                                                                                                                                                                                                                              
CREATE PROCEDURE rpt_publwise_billing_summ
    @pcompcode           as varchar(200),
    @pcenter             as varchar(200),
    @pbranchcode         as varchar(200),
    @ppublcode           as varchar(200),
    @padtype             as varchar(200),
    @pcatgcode           as varchar(200),
    @pdatefrom           as datetime,
    @pdateto             as datetime,
    @puserid             as varchar(200),
    @pdateformat         as varchar(200),
    @pextra1             as varchar(200),
    @pextra2             as varchar(200),
    @pextra3             as varchar(200),
    @pextra4             as varchar(200),
    @pextra5             as varchar(200)
AS
        
    declare @v_query             varchar(8000)
    declare @rec_v1_comp_code    varchar(200)
	declare @rec_v1_pcenter	     varchar(200)
	declare @rec_v1_bill_date    datetime
    declare @rec_v1_publ_code    varchar(200)
    declare @rec_v1_publ_name    varchar(200)
    declare @rec_v1_edtn_code    varchar(200)
    declare @rec_v1_edtn_name	 varchar(200)
    declare @rec_v1_amount       numeric(18,2)
    
     declare c1 cursor for
        select x.comp_code comp_code,x.bill_date bill_date,x.publ_code publ_code,x.publ_name publ_name,
        x.edtn_code edtn_code,x.edtn_name edtn_name,isnull(x.amount,0) amount from
        (select m."Comp_code" comp_code,i.bill_date bill_date,
        i."Publication_Code" publ_code,(select pub_mast."Pub_Name" from pub_mast where 
        pub_mast."Pub_Code"=i."Publication_Code") publ_name,i."Edition_Code" edtn_code,
        (select distinct "Pub_Cent_name" from pub_cent_mast where "Pub_cent_Code"=e."City_Code")  edtn_name,
        round(Sum(i."Bill_Amt"),2) amount
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c,edition_mast e
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=@pcompcode and c."Comp_Code"=m."Comp_code" and e."Comp_Code"=m."Comp_code" and 
        c."Adv_Cat_Code"=i."Ad_Cat" and 
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"+a."SUB_Agency_Code"=m."Agency_sub_code" and 
        i.bill_date between @pdatefrom and @pdateto and (m."Ad_type_code"=@padtype or @padtype is null or @padtype='') and
        (i."Ad_Cat"=@pcatgcode or @pcatgcode is null or @pcatgcode='') and 
        m."branch"=b."Branch_Code" and
        (b."Branch_Code"=@pbranchcode or @pbranchcode is null or @pbranchcode='') and (b."pub_center"=@pcenter or @pcenter is null or @pcenter='') and
        (i."Publication_Code"=@ppublcode or @ppublcode is null or @ppublcode='') and e."Edition_Code"=i."Edition_Code" and i."Bill_Amt">0
        group by m."Comp_code",i.bill_date,i."Publication_Code",i."Edition_Code",e."City_Code" ) x        
        order by comp_code,publ_name,edtn_name,bill_date;

    declare @v_rec_seqno numeric(10)         
    
    declare @v_var       varchar(4000)
    declare @v_var_sum   varchar(4000)
Begin

CREATE TABLE #TEMP_AD_RECEIPT_REPORT
( COMP_CODE         VARCHAR(10),
  UNIT_CODE         VARCHAR(10),
  PCENTRE_CODE      VARCHAR(10),
  AGCODE            VARCHAR(50),
  RECPTNO           VARCHAR(50),
  RECPTDT           DATEtime,
  AMOUNT            float,
  REP_CODE          VARCHAR(20),
  REMARKS           VARCHAR(500),
  CHQNO             VARCHAR(50),
  CHQDT             DATEtime,
  CHQ_BANK          VARCHAR(100),
  REASON            VARCHAR(30),
  BILLNO            VARCHAR(50),
  BILLDT            DATEtime,
  BILLAMT           float,
  ADJAMT            float,
  LEFTAMT           float,
  RET_CODE          VARCHAR(200),
  EXE_CODE          VARCHAR(200),
  SESS_ID           int         ,
  DEBIT_HEAD        VARCHAR(200),
  CREDIT_HEAD       VARCHAR(200),
  AG_MAIN_CODE      VARCHAR(20),
  AG_SUB_CODE       VARCHAR(20),
  DOCTYPE           VARCHAR(10),
  REC_SEQNO         int,
  RECOVARY_DAYS     int,
  AGNAME            VARCHAR(500),
  AD_RATE           float,
  AD_SIZE           float,
  AD_COLOR          VARCHAR(5),
  AD_SUB_CATEGORY   VARCHAR(200),
  AD_PACKAGE        VARCHAR(500),
  INSDATE           DATEtime,
  CLIENT            VARCHAR(200),
  AD_MAIN_CATEGORY  VARCHAR(200),
  RECOVERY_DAYS		VARCHAR(200),
  ADDR				VARCHAR(500))

    open c1
    fetch NEXT FROM C1 INTO @rec_v1_comp_code,@rec_v1_bill_date,@rec_v1_publ_code,@rec_v1_publ_name,@rec_v1_edtn_code,@rec_v1_edtn_name,@rec_v1_amount
		WHILE (@@FETCH_STATUS = 0) 
		BEGIN

        SET @v_rec_seqno=ISNULL(@v_rec_seqno,0)+1
        
        insert into #temp_ad_receipt_report
                (comp_code,pcentre_code,recptdt,exe_code,ad_main_category,ret_code,ad_sub_category,
                amount,rec_seqno)
          values(@rec_v1_comp_code,@rec_v1_pcenter,@rec_v1_bill_date,@rec_v1_publ_code,@rec_v1_publ_name,@rec_v1_edtn_code,@rec_v1_edtn_name,
                @rec_v1_amount,@v_rec_seqno)
    fetch NEXT FROM C1 INTO @rec_v1_comp_code,@rec_v1_bill_date,@rec_v1_publ_code,@rec_v1_publ_name,@rec_v1_edtn_code,@rec_v1_edtn_name,@rec_v1_amount
	End
	close c1
	deallocate c1



    declare c11 cursor for
            select distinct exe_code publ_code, ad_main_category publ_name,ad_sub_category edtn_name from #temp_ad_receipt_report 
			order by publ_name,edtn_name

    open c11
		fetch NEXT FROM C11 INTO @rec_v1_publ_code,@rec_v1_publ_name,@rec_v1_edtn_name
		WHILE (@@FETCH_STATUS = 0) 
		BEGIN
            if @v_var is null or @v_var='' Begin
                set @v_var       ='case when d.exe_code+''#''+d.ad_sub_category='+''''+@rec_v1_publ_code+'#'+@rec_v1_edtn_name+''''+' then d.amount else 0 end "'+@rec_v1_publ_code+'#'+@rec_v1_edtn_name+'"';
                set @v_var_sum   ='round(sum("'+@rec_v1_publ_code+'#'+@rec_v1_edtn_name+'"),2)'+' "'+@rec_v1_publ_code+'#'+@rec_v1_edtn_name+'"'
				End
            else Begin
                set @v_var       =@v_var+','+'case when d.exe_code+''#''+d.ad_sub_category='+''''+@rec_v1_publ_code+'#'+@rec_v1_edtn_name+''''+' then d.amount else 0 end "'+@rec_v1_publ_code+'#'+@rec_v1_edtn_name+'"'
                set @v_var_sum   =@v_var_sum+','+'round(sum("'+@rec_v1_publ_code+'#'+@rec_v1_edtn_name+'"),2)'+' "'+@rec_v1_publ_code+'#'+@rec_v1_edtn_name+'"'
            End 
		fetch NEXT FROM C11 INTO @rec_v1_publ_code,@rec_v1_publ_name,@rec_v1_edtn_name
		End
	close c11
	 
	if @v_var is null or @v_var='' Begin
       set @v_query='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,
		x.bill_date as "BILL_DATE", x.publ_code as "PUBL_CODE",x.publ_name AS "PUBL_NAME",
        x.edtn_name AS "EDTN_NAME",round(sum("AMOUNT"),2) as "TOTOL" from
        (select d.comp_code,d.recptdt bill_date,d.exe_code publ_code,d.ad_main_category publ_name, 
        d.ad_sub_category edtn_name,isnull(d.amount,0) amount from #temp_ad_receipt_report d ) x 
        group by x.comp_code,x.publ_code,x.publ_name,x.edtn_name,x.bill_date order by x.comp_code,x.publ_name,x.publ_code,x.edtn_name,x.bill_date';
		End
    else Begin
       set @v_query='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.bill_date as "BILL_DATE", 
        '+@v_var_sum+' ,round(sum("AMOUNT"),2) as "TOTOL" from
        (select d.comp_code,d.recptdt bill_date,d.exe_code publ_code,d.ad_main_category publ_name,d.ad_sub_category edtn_name,
       '+@v_var+',isnull(d.amount,0) amount from #temp_ad_receipt_report d) x 
       group by x.comp_code,x.bill_date order by x.comp_code,x.bill_date';
    End
        
	print(@v_query)
	exec(@v_query)
        
    if @v_var is null or @v_var='' Begin
       set @v_query='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,round(sum("AMOUNT"),2) as "TOTOL" from
        (select d.comp_code,d.recptdt bill_date,d.exe_code publ_code,d.ad_main_category publ_name,d.ad_sub_category edtn_name,
        isnull(d.amount,0) amount from #temp_ad_receipt_report d) x 
        group by x.comp_code order by x.comp_code'
		End
    else Begin
       set @v_query='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,
        '+@v_var_sum+' ,round(sum("AMOUNT"),2) as "TOTOL" from
        (select d.comp_code,d.recptdt bill_date,d.exe_code publ_code,d.ad_main_category publ_name,d.ret_code edtn_code,d.ad_sub_category edtn_name,
       '+@v_var+',isnull(d.amount,0) amount from #temp_ad_receipt_report d ) x 
        group by x.comp_code order by x.comp_code';
    End

	print(@v_query)
	exec(@v_query)
	deallocate c11
    drop table #temp_ad_receipt_report
End

/**************************************************Laxman Sir 16/9/11 4689******************************/

/*************************************************Bhanu 16/9/11 4689***************************/

CREATE FUNCTION AD_GET_catnameE (@pcomp_code  varchar(20),@cat_code  varchar(200),@value1 varchar(20))returns varchar(200)
 as
Begin
declare @vexec_name VARCHAR(200)

if(@value1='cat') begin
        select @vexec_name=Adv_Cat_Name    from adv_cat_mast where Comp_Code=@pcomp_code and Adv_Cat_Code=@cat_code
end

else if (@value1='subcat') BEGIN
        select @vexec_name=Adv_Subcat_Name   from adv_subcat_mast where Comp_Code=@pcomp_code and Adv_Subcat_Code=@cat_code
end

else if (@value1='cat3') BEGIN
        select @vexec_name=catname   from ad_cat3 where compcode=@pcomp_code and catcode=@cat_code
end

else if (@value1='cat4') BEGIN
        select @vexec_name=Cat_Name   from tbl_cat4 where Comp_Code=@pcomp_code and Cat_Code=@cat_code
 end

else if (@value1='pprem')BEGIN
        select @vexec_name=Pos_Type  from advpos_type_mast where Comp_Code=@pcomp_code and Pos_Type_Code=@cat_code
end
else if (@value1='publication')BEGIN
        select @vexec_name=Pub_Name  from PUB_MAST where Comp_Code=@pcomp_code and Pub_Code=@cat_code
end
else if (@value1='fschem') BEGIN
        select @vexec_name=Scheme_Name  from scheme_master where Comp_code=@pcomp_code and scheme_id=@cat_code
        
end
else
    BEGIN
        select @vexec_name=Cat_Name  from tbl_cat5 where Comp_Code=@pcomp_code and Cat_Code=@cat_code
        
    end

  return isnull(@vexec_name,'');
END

/*************************************************Bhanu 16/9/11 4689***************************/

/**********************************************************mimoh 21/09/2011  0004914***********************************/



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go














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
@RO_OUTSTAND_P AS VARCHAR(5)
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

ALLOWED_PDC_DAYS_RECEIPT=@P_ALLOW_PDC,AD_TYPE_MANUL_BILL=@PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=@RO_OUTSTAND_P

 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)



-------------------------------------------------------------------------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go














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
ALLOWED_PDC_DAYS_RECEIPT,AD_TYPE_MANUL_BILL, OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND
           FROM PREFERRENCES
          WHERE comp_code = @compcode























************************************************************mimoh 21/09/2011 0004914***********************************************



/************************************************** Kuldeep Bhati 0004966 ************************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[websp_savepkgstatus]

    @compcode varchar(8),
    @userid varchar(8),
    @ad_type varchar(10),
    @pkgcode varchar(100),
    @pkgstatus varchar(8)
    
as

    declare @recordid as int
	select @recordid=isnull(max(cast(record_id as decimal))+1,0) from EditionStatus
    insert into EditionStatus (COMP_CODE,USERID,AD_TYPE,PACKAGECODE,STATUS,record_id) values (@compcode,@userid,@ad_type,@pkgcode,@pkgstatus,@recordid)




/************************************************** Kuldeep Bhati 0004966 ************************************/


/*******************************Anupama 24/sep/11 issue no. 4835**************************************/


ALTER PROCEDURE Bind_PubName

@compcode as varchar(8)

AS


declare @query as varchar(100)

select Pub_Name, Pub_Code from pub_mast where comp_code=@compcode and  publication_type<>'CO0' order by Pub_Name





/*******************************Anupama 24/sep/11 issue no. 4835**************************************/


/*******************************Anupama 29/sep/11 issue no. 5083**************************************/

create PROCEDURE Bind_PubEdName

@compcode as varchar(8)

AS


declare @query as varchar(100)

select Pub_Name, Pub_Code from pub_mast where comp_code=@compcode order by Pub_Name

/*******************************end of issue no. 5083 Anupama 29/sep/11**************************************/

/**************************4-oct-2011 Lata***************************/

create FUNCTION [dbo].[fnInitRc4]
(
	@Pwd VARCHAR(256)
)
RETURNS @Box TABLE (i TINYINT, v TINYINT)
AS

BEGIN
	DECLARE	@Key TABLE (i TINYINT, v TINYINT)

	DECLARE	@Index SMALLINT,
		@PwdLen TINYINT

	SELECT	@Index = 0,
		@PwdLen = LEN(@Pwd)

	WHILE @Index <= 255
		BEGIN
			INSERT	@Key
				(
					i,
					v
				)
			VALUES	(
					@Index,
					 ASCII(SUBSTRING(@Pwd, @Index % @PwdLen + 1, 1))
				)

			INSERT	@Box
				(
					i,
					v
				)
			VALUES	(
					@Index,
					@Index
				)

			SELECT	@Index = @Index + 1
		END


	DECLARE	@t TINYINT,
		@b SMALLINT

	SELECT	@Index = 0,
		@b = 0

	WHILE @Index <= 255
		BEGIN
			SELECT		@b = (@b + b.v + k.v) % 256
			FROM		@Box AS b
			INNER JOIN	@Key AS k ON k.i = b.i
			WHERE		b.i = @Index

			SELECT	@t = v
			FROM	@Box
			WHERE	i = @Index

			UPDATE	b1
			SET	b1.v = (SELECT b2.v FROM @Box b2 WHERE b2.i = @b)
			FROM	@Box b1
			WHERE	b1.i = @Index

			UPDATE	@Box
			SET	v = @t
			WHERE	i = @b

			SELECT	@Index = @Index + 1
		END

	RETURN
END





set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

create FUNCTION [dbo].[fnEncDecRc4]
(
	@Pwd VARCHAR(256),
	@Text VARCHAR(8000)
)
RETURNS	VARCHAR(8000)
AS

BEGIN
	DECLARE	@Box TABLE (i TINYINT, v TINYINT)

	INSERT	@Box
		(
			i,
			v
		)
	SELECT	i,
		v
	FROM	dbo.fnInitRc4(@Pwd)

	DECLARE	@Index SMALLINT,
		@i SMALLINT,
		@j SMALLINT,
		@t TINYINT,
		@k SMALLINT,
      		@CipherBy TINYINT,
      		@Cipher VARCHAR(8000)

	SELECT	@Index = 1,
		@i = 0,
		@j = 0,
		@Cipher = ''

	WHILE @Index <= DATALENGTH(@Text)
		BEGIN
			SELECT	@i = (@i + 1) % 256

			SELECT	@j = (@j + b.v) % 256
			FROM	@Box b
			WHERE	b.i = @i

			SELECT	@t = v
			FROM	@Box
			WHERE	i = @i

			UPDATE	b
			SET	b.v = (SELECT w.v FROM @Box w WHERE w.i = @j)
			FROM	@Box b
			WHERE	b.i = @i

			UPDATE	@Box
			SET	v = @t
			WHERE	i = @j

			SELECT	@k = v
			FROM	@Box
			WHERE	i = @i

			SELECT	@k = (@k + v) % 256
			FROM	@Box
			WHERE	i = @j

			SELECT	@k = v
			FROM	@Box
			WHERE	i = @k

			SELECT	@CipherBy = ASCII(SUBSTRING(@Text, @Index, 1)) ^ @k,
				@Cipher = @Cipher + CHAR(@CipherBy)

			SELECT	@Index = @Index  +1
      		END

	RETURN	@Cipher
END


create PROCEDURE [saveLoginInfo]
	@compcode_p  varchar(20),
	@userid_p  varchar(20),
	@ip_p     varchar(20),
	@filter_p	varchar(20),
	@session_p	varchar(50)
AS
DECLARE @l_sessionid varchar(20)
BEGIN
SELECT @l_sessionid=@@SPID
if @filter_p = 'INSERT'
begin	
insert into logininfo(COMPCODE, USERID, STARTTIME, LASTUSED, IP, SESSIONID)
    values(@compcode_p,@userid_p,getdate(),getdate(),@ip_p,@l_sessionid);
end
ELSE if @filter_p = 'UPDATE'
begin
UPDATE LOGININFO SET LASTUSED=GETDATE() WHERE COMPCODE=@compcode_p and USERID=@userid_p AND SESSIONID=@session_p
END
ELSE if @filter_p = 'DELETE'
BEGIN
 INSERT INTO LOGININFO_LOG(COMPCODE, USERID, STARTTIME, ENDTIME, IP, SESSIONID)
        SELECT COMPCODE,USERID,STARTTIME,GETDATE(),IP,@session_p FROM LOGININFO
    DELETE FROM LOGININFO WHERE    COMPCODE=@compcode_p and USERID=@userid_p AND SESSIONID=@session_p
END
SELECT @l_sessionid AS 'SESSION'
END




create PROCEDURE [FETCHLICENSEINFO]

AS
BEGIN
	select dbo.fnEncDecRc4 ('12345',isnull(A.LICENSE_INFO,'X')) AS LICENSEINFO,
replace(convert(varchar(11),A.LAST_KEY_UPDATE,106),' ','-'),A.LAST_KEY_UPDATED_BY
        from COMP_MST A,PREFERRENCES B WHERE A.Comp_Code=B.comp_code
END



create PROCEDURE [updateKey] 
@compname_p varchar(100),
@keyno_p varchar(100),
@userid_p varchar(20)
AS
DECLARE @keyno varchar(50)
DECLARE @comp_name varchar(100)
DECLARE @f_compname varchar(200)
BEGIN
	declare Rateforweb cursor
for SELECT Comp_Name from comp_mst where Comp_Code in(select comp_code  FROM PREFERRENCES)
open Rateforweb

FETCH NEXT FROM Rateforweb
INTO @comp_name
WHILE @@FETCH_STATUS = 0
BEGIN

if @f_compname is null or @f_compname = ''
    SET @f_compname=@comp_name
else
    SET @f_compname=@f_compname + ',' + @comp_name
update comp_mst set license_info=@keyno_p, last_key_update=GETDATE(),last_key_updated_by=@userid_p 
where Comp_Name=@compname_p

FETCH NEXT FROM Rateforweb
	INTO @comp_name
end	
CLOSE Rateforweb
DEALLOCATE Rateforweb
  select @f_compname as "COMPANY_NAME" 
END




create PROCEDURE [fetchCompanyName] 
	
AS
DECLARE @comp_name varchar(100)
DECLARE @f_compname varchar(200)
BEGIN
declare Rateforweb cursor
for SELECT Comp_Name from comp_mst where Comp_Code in(select comp_code  FROM PREFERRENCES)
open Rateforweb

FETCH NEXT FROM Rateforweb
INTO @comp_name
WHILE @@FETCH_STATUS = 0
BEGIN

if @f_compname is null or @f_compname = ''
    SET @f_compname=@comp_name
else
    SET @f_compname=@f_compname + ',' + @comp_name    


FETCH NEXT FROM Rateforweb
	INTO @comp_name
end	
CLOSE Rateforweb
DEALLOCATE Rateforweb
select @f_compname as "COMPANY_NAME"
END



create PROCEDURE [fetchLicenseKeyDate] 
	@compcode VARCHAR(50)
AS
DECLARE @dstr varchar(100)
DECLARE @diff date
BEGIN
BEGIN TRY

select @dstr=dbo.fnEncDecRc4 ('12345',license_info
                             )   from comp_mst where Comp_Code=@compcode
IF @dstr = ''
	SET @dstr='X'
if @dstr!='X'
BEGIN
SET @dstr=substrING(@dstr,CHARINDEX('~',@dstr)+1,11)
SET @diff=@dstr
	select datediff(dd,getdate(),@diff) as "DIFF",@dstr as "DATE",'' as "MSG"
END
ELSE
BEGIN
select 'X' as "DIFF",'X' as "DATE",'' as "MSG"
END
END TRY 
BEGIN CATCH
	select 'X' as "DIFF",'X' as "DATE",'Invalid License Key' as "MSG"
END CATCH
END


/**************************5-oct-2011Kuldeep Bhati  Issue 0004807 ***************************/

ALTER PROCEDURE [dbo].[receiptsave_booking]
@pcompcode      as varchar(8),
@puserid      as varchar(8),
@punit         as varchar(10),
@ptype          as varchar(20),
@precpt         as varchar(20),
@prdate         as date,
@ppaymodres      as varchar(10),
@preceivedreg    as varchar(8),
@pvouno         as varchar(20),
@pamount        as float,
@pagency         as varchar(18),
@pothercd        as float,
@pchno          as varchar(30),
@pchedate       as  datetime,
@pbank          as varchar(30),
@pnarration      as varchar(200),
@prep             as varchar(8),
@pvdate          as datetime,
@pag_main_code    as varchar(50),
@pag_sub_code    as varchar(50),
@ourbank        as varchar(100),
@cioid          as varchar(50),
@execname       as  varchar(50),
@retainer        as varchar(50),
@prevcioid      as  varchar(50)



 AS
declare @countnum int
declare @vquery  float
declare @vamount float
declare @agencyreg varchar(50)
declare @branchcode varchar(50)

declare @v_rcpno         varchar(50)
declare @v_prefix_recpt  varchar(30)
declare @v_sufix_recpt   varchar(30)
declare @vcond_flag      varchar(30)
declare @v_branch_alias  varchar(30)
declare @prcptno varchar(50)
declare @rcptgeninp		varchar(50)
declare @rcptusernam	varchar(50)
set @vcond_flag='F'
set @vquery=0
set @agencyreg='OT0'
--create table #recpt_t(receipt_no varchar(30))
--For receipt no generation according to user initial
select @rcptgeninp=Receipt_no from preferrences where comp_code=@pcompcode
select @rcptusernam=username from login where COM_CODE=@pcompcode and userid=@puserid

 select @branchcode=Branch_Code,@v_branch_alias=Branch_Alias from branch_mst where Comp_Code=@pcompcode and Branch_Code=@punit
if @ptype='RCP'
begin
	if @rcptgeninp='7'
		set @v_prefix_recpt='R/'+substring(@rcptusernam,1,3)+'/'+Right(Year(@prdate),2)+'-'+convert(varchar(2),@prdate,101)+'/'
	else
		set @v_prefix_recpt='R/'+substring(@v_branch_alias,1,3)+'/'+Right(Year(@prdate),2)+'-'+convert(varchar(2),@prdate,101)+'/'
end
ELSE
	set @v_prefix_recpt='R/'+substring(@v_branch_alias,1,3)+'/'+Right(Year(@prdate),2)+'-'+convert(varchar(2),@prdate,101)+'/'
set @v_sufix_recpt=''
PRINT 'R1'
PRINT @pcompcode
PRINT @v_prefix_recpt
PRINT @v_sufix_recpt
PRINT @ptype
PRINT @prdate
PRINT @vcond_flag
--insert into #recpt_t exec chkreceiptno_advt @pcompcode,@v_prefix_recpt,@v_sufix_recpt,@ptype,@prdate,'',@vcond_flag
	select @v_rcpno=dbo.chkreceiptno_advt_fn(@pcompcode,@v_prefix_recpt,@v_sufix_recpt,@ptype,@prdate,'',@vcond_flag)

--insert into #recpt_t values(@precpt)
-- -- -- set @v_rcpno=chkreceiptno_advt(@pcompcode,@v_prefix_recpt,@v_sufix_recpt,@ptype,@prdate,'',@vcond_flag)
--select @v_rcpno=receipt_no from #recpt_t
set @prcptno=@v_rcpno 
select @vquery=Dsign  from fa_Docmst where Comp_code=@pcompcode and doc_type=@ptype

select @agencyreg=region  from agency_mast where Comp_Code=@pcompcode and code_subcode=@pagency

if(@vquery=-1) 
     SET @vamount=@pamount*@vquery
else
     SET @vamount=@pamount*@vquery

IF @pothercd<0
	set @pothercd = @pothercd * -1
IF @pamount<0
	SET @vamount= @pamount* -1

print @prcptno
select @countnum=count(*) from ad_rcpthdr where recptno=@prcptno
print 'receiptsave_booking'
print @countnum

if @countnum=0
begin
print 'end'
insert into ad_rcpthdr(ROIDNUM,comp_code,userid,unit,doctype,recptno,recptdt,reason,received_region,voucherno,amount,agcode,
                                                 oth_amount,chno,bank,remark,repcode,voucherdate,ag_main_code,ag_sub_code,cashbank)-- ,chdt
                                    values(@cioid,@pcompcode,@puserid,@branchcode,@ptype,@prcptno,@prdate ,@ppaymodres,@agencyreg ,@pvouno,@vamount,@pagency,
                                                 @pothercd,@pchno  ,@pbank,@pnarration,@prep,@pvdate,@pag_main_code,@pag_sub_code,@ourbank)-- ,@pchedate
print 'end11'
end
print 'end11121212'
select @countnum=count(*) from ad_outstand where recptno=@prcptno
if @countnum=0
begin
    insert into ad_outstand(COMP_CODE,USERID,UNIT,DOCTYPE,RECPTNO,RECPTDT,REASON,RECEIVED_REGION,
                                                  VOUCHERNO,AMOUNT,AGCODE,CHNO,CHDT,BANK,VOUCHERDATE,AG_MAIN_CODE,AG_SUB_CODE,REMARK,RECEIPT_NO,REF_AMOUNT,EXEC_CODE,RETAINER_CODE,ROIDNUM,PREV_CIOID)
                                     values(@pcompcode,@puserid,@branchcode,@ptype,@prcptno,@prdate,@ppaymodres,@agencyreg,
                                                     @pvouno,@vamount,@pagency,@pchno,@pchedate ,@pbank,@pvdate,@pag_main_code,@pag_sub_code,@pnarration,@cioid,@vamount,@execname,@retainer,@cioid,@prevcioid)
end   
select @countnum=count(*) from AD_RCPTDET where recptno=@prcptno
if @countnum=0
begin
      INSERT INTO AD_RCPTDET(roidnum,comp_code,userid,unit,doctype,recptno,recptdt,reason,received_region,
                           voucherno,amount,agcode,/*chno,chdt,bank,remark,repcode,*/voucherdate,ag_main_code,ag_sub_code)
                     VALUES(@cioid,@pcompcode,@puserid,@branchcode,@ptype,@prcptno,@prdate,@ppaymodres,@agencyreg,
                            @pvouno,@vamount,@pagency,/*pchno ,pchedate ,pbank,pnarrationprep,*/@pvdate,@pag_main_code,@pag_sub_code)
end
select @prcptno as 'Receipt_no'

/*
declare @query  as int
set @query=1
select  @query=Dsign  from fa_Docmst  where Comp_Code=@compcode and doc_type=@type



if(@query=-1)
begin
set @amount=@amount*@query
end
else
begin
set @amount=@amount*@query
end


insert into ad_rcpthdr(comp_code,userid,unit,doctype,recptno,recptdt,reason,received_region,voucherno,amount,agcode,oth_amount,chno,chdt,bank,remark,repcode,voucherdate,ag_main_code,ag_sub_code,cashbank)values(@compcode,@userid,
@unit,@type,@recpt,@rdate ,@paymodres,@receivedreg ,@vouno,@amount,@agency,@othercd,@chno ,@chedate ,@bank,@narration,@rep,@vdate,@pag_main_code,@pag_sub_code,@ourbank)
*/

/*******************************end of issue no. 0004807  Kuldeep Bhati   5-oct-2011**************************************/

/**************************5-oct-2011Kuldeep Bhati  Issue 0005137 ***************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




ALTER procedure [dbo].[websp_selectvalues_kannad]


(

@ciobooking  varchar(50), 
@editionname varchar(50),
@compcode  VARCHAR(50),
@insertion varchar(50),
@dateformat varchar(50)
)
as 
declare @str  as varchar(8000)
declare @str1  as varchar(8000)
declare @package_cd  as varchar(300)
declare @package_result  as varchar(300)
declare @package_cd1  as varchar(300)
create table #package ( package_name varchar (100) )

declare @v_scheme_code  as varchar(300)


set @str='select TBL_BOOKING_MAST.cio_booking_id as "CIOID",
AGENCY_MAST.agency_name as "Agency",
PUB_MAST.pub_name as "Pub",PUB_MAST.pub_name as "Pub"

,tbl_booking_insert.height as "Depth",

case 
when TBL_BOOKING_MAST.uom_code=''CO0'' then tbl_booking_insert.No_ofcolumn
when TBL_BOOKING_MAST.uom_code <> ''CO0'' then tbl_booking_insert.width end as "Width"

/*,tbl_booking_insert.width as "Width"*/
, COL_MAST.col_alias as "Hue"
,tbl_booking_insert.no_insert as "Ins.No."
  ,ro_no as "RoNo.",
TBL_BOOKING_MAST.card_amount as "Amt"
,TBL_BOOKING_INSERT.disc_rate as "Disc",
(select advpos_type_mast.pos_type from advpos_type_mast where advpos_type_mast.pos_type_code=tbl_booking_insert.page_post) as "pageposition",
(select adv_cat_mast.adv_cat_name from adv_cat_mast where ADV_CAT_MAST.adv_cat_code=TBL_BOOKING_MAST.ad_cat_code) as "AdCat",
tbl_booking_insert.size_book as "volume",tbl_booking_mast.card_rate as "package rate", edition_mast. edition_alias as "edition"
,isnull((select distinct cust_mast.cust_alias from cust_mast  where  cust_mast.cust_code=tbl_booking_mast.client_code),tbl_booking_mast.client_code) as "advertiser",
tbl_booking_mast.agency_sub_code,tbl_booking_mast.gross_amount,agency_mast.add1 , city_mst.city_name,

(select box_mast.box_charges_native from box_mast  ,tbl_booking_mast where  tbl_booking_mast.box_code=box_mast.box_code and TBL_BOOKING_MAST.cio_booking_id='''+@ciobooking+''' ) as "boxchares" ,
tbl_booking_insert.gross_rate,
tbl_booking_mast.creation_datetime,

(select distinct  min(package_name) from combin_mast where combin_desc='''+@editionname+''')as package_name,
(select distinct cust_mast.ADD1 from cust_mast  where  cust_mast.cust_code=tbl_booking_mast.client_code) as "clientAd",
isnull((select cust_name from CUST_MAST where cust_code=client_code),client_code)  as "Client",tbl_booking_mast.no_of_insertion,

case '''+@dateformat + '''

 when ''mm/dd/yyyy'' then convert(varchar(10),insertion_date,1) 

when ''dd/mm/yyyy'' then convert(varchar(10),insertion_date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),insertion_date,3)  end as "Ins.date" ,
tbl_booking_insert. page_no,

(select premiumname from ADVPOS_PREM_MAST,tbl_booking_insert where   ADVPOS_PREM_MAST. premiumcode=tbl_booking_insert.premium1 and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' and   tbl_booking_insert.no_insert='''+@insertion+''' and  tbl_booking_insert.edition='''+@editionname+''' ),
tbl_booking_mast.special_discount,
tbl_booking_mast.Special_disc_per,
tbl_booking_mast.special_charges
,tbl_booking_mast.trade_disc,

(select premium_charges from ADVPOS_PREM_MAST,tbl_booking_insert where   ADVPOS_PREM_MAST. premiumcode=tbl_booking_insert.premium1 and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' and   tbl_booking_insert.no_insert='''+@insertion+''' and  tbl_booking_insert.edition='''+@editionname+''' ) as "premiumch",tbl_booking_insert.card_rate,
pub_cent_mast.add1 as add11,
pub_cent_mast.phone1,
pub_cent_mast.phone2 ,
pub_cent_mast.fax1,
isnull(TBL_BOOKING_INSERT.agreed_rate,0) as agreed_rate,
TBL_BOOKING_INSERT.Edition as "EditionName",
agency_mast.bill_to,
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),insert_date,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),insert_date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),insert_date,3)  end as "insert_date",
tbl_booking_mast.uom_code,
(select Uom_Name from uom_mast where uom_mast.Comp_Code=tbl_booking_mast.Comp_Code and uom_code=tbl_booking_mast.uom_code) as uom_name,
(select Adv_Type_Name from adv_type_mast where Adv_Type_Code=tbl_booking_mast.Ad_type_code) as ad_type,

comp_mst.COMP_NAME as "companyname",
comp_mst.PAN_NO as "pan",
PUB_CENT_MAST.Pub_Cent_name as "pubname",
comp_mst.ADD1 as "address",
comp_mst.STREET as "street",
comp_mst.FAX as "fax",
tbl_booking_insert.Bill_Amt,
1 as "Email",
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),1) 
when ''dd/mm/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),3) 
when ''yyyy/mm/dd'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),3)  end as "paydate",
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),1) 
when ''dd/mm/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),3) 
when ''yyyy/mm/dd'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),3)  end as "paydatesys",
tbl_booking_insert.insert_id,
AGENCY_MAST."Add2",
AGENCY_MAST."Add3",
dbo.getadd('''+@compcode+''','''+@ciobooking+''') as "agenadd",
tbl_booking_mast."Bill_to" as "bill2",
/*Modified*/
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),tbl_booking_insert.Insert_date,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),tbl_booking_insert.Insert_date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),tbl_booking_insert.Insert_date,3)  end as "insert_date1",
--convert(varchar(10),tbl_booking_insert.Insert_date,1) as "insert_date1",
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),tbl_booking_insert.bill_date,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),tbl_booking_insert.bill_date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),tbl_booking_insert.bill_date,3)  end as "bill_date1",
--convert(varchar(10),tbl_booking_insert.bill_date,1) as "bill_date1",
PUB_MAST.Pub_Code as "pub_cod",
edition_mast.Edition_Code as "edit_code",
tbl_booking_mast.Scheme_type_code as "scheme",
tbl_booking_mast.CASHDISCOUNT as "cashdis_per",
isnull(TBL_BOOKING_mast.Agreed_amount,0) as "AgreedAmt",
tbl_booking_mast.Rate_code as "rate_code",
tbl_booking_insert.Insert_status as "status",
tbl_booking_insert.Pai_free_ins AS "PAI_FREE_INS",
tbl_booking_insert.BOXCHARGE as "boxcrg",
agency_mast.Agency_Code as "agency_cod",
(select top 1 Box_Charges_Native from Box_mast where Box_mast.Box_Code=tbl_booking_mast.Box_code) as "Box_Charge",
tbl_booking_mast.Page_amount as "Pag_amt",
tbl_booking_mast.Prem_per as "pag_prem",
tbl_booking_mast.Agrred_rate as "agree_rate",
dbo.get_printing_cent_name_fr_bran('''+@compcode+''',tbl_booking_mast.branch) as Print_cent_name,
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),date_time,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),date_time,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),date_time,3)  end as "date_time",
case tbl_booking_mast.ad_type_code
when ''DI0'' then tbl_booking_mast."Caption"
else tbl_booking_mast."key_no" end as "Cap",
TBL_BOOKING_mast.ADD_AGENCY_COMM as "addcom",
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),TBL_BOOKING_MAST.RO_Date,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),TBL_BOOKING_MAST.RO_Date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),TBL_BOOKING_MAST.RO_Date,3)  end as "RO_Date",
tbl_booking_mast."key_no" as "key_no",
AGENCY_MAST.pin_code,
isnull(tbl_booking_insert.agreed_rate,ISNULL(tbl_booking_insert.card_rate,0)*isnull(tbl_booking_insert.size_book,0))  as insert_gross_amt';


set @str1=',(select distinct COLORRATEGROUPMAST.prcent_pr from COLORRATEGROUPMAST 
where tbl_booking_mast.comp_code=COLORRATEGROUPMAST.comp_code and 
tbl_booking_mast.ad_type_code=COLORRATEGROUPMAST.ad_type and tbl_booking_insert.package_code=COLORRATEGROUPMAST.pkg_code 
 and tbl_booking_insert.col_code=COLORRATEGROUPMAST.color_name) as "Extra",
(select top 1 Cont_Person from cont_details where tbl_booking_mast.Comp_code=cont_details.Comp_Code 
and cont_details.Agency_Code=tbl_booking_mast.Agency_code) as "contact",

 (select  dbo.initcap(PUB_CENT_MAST.Add1) FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_code=TBL_BOOKING_MAST.branch AND 
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS addressnew,



(select  dbo.initcap(PUB_CENT_MAST.street) FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_code=TBL_BOOKING_MAST.branch AND 
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS streetnew,

(select  PUB_CENT_MAST.zip FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_code=TBL_BOOKING_MAST.branch AND 
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS Fax2new,


(select  PUB_CENT_MAST.phone1 FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_code=TBL_BOOKING_MAST.branch AND 
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS phone11,

(select  PUB_CENT_MAST.phone2 FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_code=TBL_BOOKING_MAST.branch AND 
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS phone22,

(SELECT dbo.initcap(City_Name)  from city_mst WHERE COMP_CODE='''+@compcode+''' AND city_mst.City_Code=
(select  PUB_CENT_MAST.CITY_CODE FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_code=TBL_BOOKING_MAST.branch AND 
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))) AS CITY_NAMEnew

from TBL_BOOKING_MAST,pub_cent_mast,
TBL_BOOKING_INSERT,
AGENCY_MAST ,
PUB_MAST
,
COL_MAST ,
edition_mast,
city_mst,
comp_mst

 where TBL_BOOKING_MAST.comp_code='''+@compcode+''' and TBL_BOOKING_INSERT.pub_cent_code=pub_cent_mast.pub_cent_code
and TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.cio_booking_id
 and TBL_BOOKING_MAST.agency_SUB_code=AGENCY_MAST.code_subcode  and comp_mst.comp_code='''+@compcode+''' 
 and tbl_booking_insert.Col_code=col_mast.Col_code   and pub_mast.pub_code=tbl_booking_insert.publication_code 
  and edition_mast.edition_code=tbl_booking_insert.edition_code and city_mst.city_code=agency_mast.city_code  and TBL_BOOKING_INSERT.publication_code = PUB_MAST.pub_code and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' and   tbl_booking_insert.no_insert='''+@insertion+''' and  tbl_booking_insert.edition='''+@editionname+''' '






select  @package_cd1=package_code,@v_scheme_code=Scheme_type_code from tbl_booking_mast where cio_booking_id=@ciobooking



DECLARE c1 CURSOR READ_ONLY
FOR
 
    
select Edition_Name from fn_SplitField(@package_cd1,',')


           
    open c1
    FETCH NEXT FROM c1
    INTO @package_result
                 

    WHILE @@FETCH_STATUS = 0
    BEGIN


    insert into #package select combin_desc from combin_mast where combin_code=@package_result
    --select * from #package         

    FETCH NEXT FROM c1
    INTO  @package_result
    END
    print(@package_result)
CLOSE c1
DEALLOCATE c1





print(@str)
print(@str1)

exec(@str+@str1)


select * from #package	
delete from #package

select distinct edition_code from tbl_booking_insert where  cio_booking_id=@ciobooking and Insert_status not in ('Hold','cancel')

-- select top 1 insert_date from tbl_booking_insert where  cio_booking_id=@ciobooking order by insert_date
select top 1 DateName( Month,insert_date )+'-'+ DateName( Year, insert_date ) as "insert_date" from tbl_booking_insert where  cio_booking_id=@ciobooking and tbl_booking_insert.no_insert=@insertion order by insert_date

select scheme_code  from Scheme_Master where comp_code=@compcode and Scheme_id=@v_scheme_code
select AGENCYCOMM_SEQ_COM from preferrences where comp_code=@compcode





/*******************************end of issue no. 0005137  Kuldeep Bhati   5-oct-2011**************************************/



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER PROCEDURE [dbo].[get_validdate_qbc](@DATEFORMAT    as      VARCHAR(50),
@datetoadd     as      DATETIME,
@pkgname       as      VARCHAR(100),
@adcat1        as      VARCHAR(100),
@adtype1       as      VARCHAR(50),
@center      as  varchar(50),
@pkgid       as varchar(100),
@pkgalias    as varchar(500)) AS
DECLARE @fixdate      DATETIME
DECLARE @validdate      dateTIME
DECLARE @validdays     VARCHAR (100)
DECLARE @dateofday     VARCHAR (20)
DECLARE @day1          VARCHAR (18)
DECLARE @flag          INT
DECLARE @count1        INT
DECLARE @count2        INT
DECLARE @editioncode   VARCHAR (12)
DECLARE @sun           VARCHAR (5)
DECLARE @mon           VARCHAR (5)
DECLARE @tue           VARCHAR (5)
DECLARE @wed           VARCHAR (5)
DECLARE @thu           VARCHAR (5)
DECLARE @fri           VARCHAR (5)
DECLARE @sat           VARCHAR (5)

DECLARE @sun1           VARCHAR (5)
DECLARE @mon1           VARCHAR (5)
DECLARE @tue1           VARCHAR (5)
DECLARE @wed1           VARCHAR (5)
DECLARE @thu1           VARCHAR (5)
DECLARE @fri1           VARCHAR (5)
DECLARE @sat1           VARCHAR (5)
DECLARE @i             INT
DECLARE @end1          INT
DECLARE @noisscode     VARCHAR (8)
DECLARE @a             INT
DECLARE @datetoadd1    DATETIME

CREATE TABLE #RESULTS_TMP
(
  EDITION_CODE  VARCHAR(500),
  DATE_NOISSUE  DATETIME
)

CREATE TABLE #TMP1(Edition_Name varchar(100))

CREATE TABLE #TEMP6
(
  EDITION_CODE  VARCHAR(500),
  SUN           VARCHAR(8),
  MON           VARCHAR(8),
  TUE           VARCHAR(8),
  WED           VARCHAR(8),
  THU           VARCHAR(8),
  FRI           VARCHAR(8),
  SAT           VARCHAR(8)
)
INSERT INTO #TMP1 SELECT EDITION_NAME FROM DBO.FN_SPLITFIELD(@pkgid,'^')

IF  @pkgalias != '' 
BEGIN
print @pkgalias
	INSERT INTO #temp6
	SELECT  (SELECT EDITION_CODE FROM EDITION_MAST WHERE EDITION_ALIAS=EDITION_COMBIN_CODE) , SUN, MON,
                          TUE, WED, THU, FRI, SAT
                    FROM combin_days where combin_code IN ( SELECT LTRIM (RTRIM (edition_name))
                                            FROM #TMP1)
END
ELSE
BEGIN
DELETE FROM #TMP1
	INSERT INTO #TMP1 SELECT EDITION_NAME FROM DBO.FN_SPLITFIELD(@pkgname,'+')
	INSERT INTO #temp6
	SELECT DISTINCT select_edition_day.edition_code, sun, mon,
                         tue, wed, thu, fri, sat
                    FROM select_edition_day
                   WHERE select_edition_day.edition_code IN (
                            SELECT edition_mast.Edition_Code
                              FROM edition_mast
                             WHERE Edition_Alias IN (
                                          SELECT LTRIM (RTRIM (edition_name))
                                            FROM #TMP1))
END

SELECT @count1=COUNT(*)  FROM #TEMP6
if @count1=0 
BEGIN
	DELETE FROM #TMP1
	INSERT INTO #TMP1 SELECT EDITION_NAME FROM DBO.FN_SPLITFIELD(@pkgname,'+')
	INSERT INTO #temp6 
	SELECT DISTINCT select_edition_day.edition_code, sun, mon,
                         tue, wed, thu, fri, sat
                    FROM select_edition_day
                   WHERE select_edition_day.edition_code IN (
                            SELECT edition_mast.Edition_Code
                              FROM edition_mast
                             WHERE Edition_Alias IN (
                                          SELECT LTRIM (RTRIM (edition_name))
                                            FROM #TMP1))

END
SET @count1=0
SET  @fixdate = @datetoadd
SET  @datetoadd1 =@datetoadd

DECLARE c1 CURSOR READ_ONLY
FOR
	SELECT  edition_code, sun, mon, tue, wed, thu, fri, sat FROM #temp6
OPEN c1
FETCH NEXT FROM c1
INTO @editioncode, @sun, @mon, @tue, @wed, @thu, @fri, @sat
WHILE @@FETCH_STATUS = 0
BEGIN

select @sun1=sun ,@mon1=mon ,@tue1=tue,@wed1=wed,@thu1=thu,@fri1=fri,@sat1=sat  from categorywiseedition where Edition_code=@editioncode and Adv_Cat_Code=@adcat1
SET @validdate=null
SET @datetoadd1 =@datetoadd

SET @noisscode = '0'

SELECT @noisscode=No_Iss_Code 
                 FROM no_iss_mast
                WHERE Edition_Code = @editioncode

 SELECT @count1=COUNT (*)
              FROM no_iss_grid
             WHERE No_Iss_Code = @noisscode AND no_issue_date = @datetoadd1

  IF (@count1 > 0)
  BEGIN
	SET @datetoadd1=DATEADD(DAY,1,@datetoadd1)
  END
  ELSE
  BEGIN
	SET @datetoadd1 = @datetoadd1
  END
SET @i = 0
SET @end1 = 1
SET @day1 = substring(datename(weekday,@datetoadd1),0,4)

WHILE (@i <= @end1)
BEGIN
	IF (upper(@day1) = upper('Sun') and @sun is not null )
	BEGIN
	      IF (@sun != 'Y')
		BEGIN
	                     IF (@mon = 'Y')
	                        SET @validdate = DATEADD(DAY,1,@datetoadd1)
	                     ELSE IF (@tue = 'Y')
	                        SET @validdate = DATEADD(DAY,2,@datetoadd1)
	                     ELSE IF (@wed = 'Y')
	                        SET @validdate = DATEADD(DAY,3,@datetoadd1)
	                     ELSE IF (@thu = 'Y')
	                        SET @validdate = DATEADD(DAY,4,@datetoadd1)
	                     ELSE IF (@fri = 'Y')
	                        SET @validdate = DATEADD(DAY,5,@datetoadd1)
	                     ELSE IF (@sat = 'Y')
	                        SET @validdate = DATEADD(DAY,6,@datetoadd1)
          END
         ELSE
	     BEGIN
	                    IF(@validdate IS NULL OR @validdate='')
	                        SET @validdate =@datetoadd1 
        END
                  
                   IF (@sun1 != 'Y')
	    BEGIN 	
	                     IF (@mon1 = 'Y')
	                        SET @validdate = DATEADD(DAY,1,@datetoadd1)
	                     ELSE IF (@tue1 = 'Y')
	                        SET @validdate = DATEADD(DAY,2,@datetoadd1)
	                     ELSE IF (@wed1 = 'Y')
	                        SET @validdate = DATEADD(DAY,3,@datetoadd1)
	                     ELSE IF (@thu1 = 'Y')
	                        SET @validdate = DATEADD(DAY,4,@datetoadd1)
	                     ELSE IF (@fri1 = 'Y')
	                        SET @validdate = DATEADD(DAY,5,@datetoadd1)
	                     ELSE IF (@sat1 = 'Y')
	                        SET @validdate = DATEADD(DAY,6,@datetoadd1)
	     END
                  ELSE
	     BEGIN
	                    IF(@validdate IS NULL  OR @validdate='')
	                        SET @validdate =@datetoadd1
                  END



	END
	  ELSE IF (upper(@day1) = upper('Mon') and  @mon is not null)	
	BEGIN
		 IF (@mon != 'Y')
		 BEGIN
		                     IF (@tue = 'Y')
		                        SET @validdate = DATEADD(DAY,1,@datetoadd1)
		                     ELSE IF (@wed = 'Y')
		                        SET @validdate =DATEADD(DAY,2,@datetoadd1)
		                     ELSE IF (@thu = 'Y')
		                        SET @validdate = DATEADD(DAY,3,@datetoadd1)
		                     ELSE IF (@fri = 'Y')
		                       SET  @validdate = DATEADD(DAY,4,@datetoadd1)
		                     ELSE IF (@sat = 'Y')
		                       SET  @validdate = DATEADD(DAY,5,@datetoadd1)
		                     ELSE IF (@sun = 'Y')
		                       SET  @validdate =DATEADD(DAY,6,@datetoadd1)
		END
		ELSE
		BEGIN
		                    IF(@validdate IS NULL OR @validdate='')
		                        SET @validdate =@datetoadd1 
		END
		IF (@mon1 != 'Y')
		BEGIN
		                     IF (@tue1 = 'Y')
		                        SET @validdate = DATEADD(DAY,1,@datetoadd1)
		                     ELSE IF (@wed1 = 'Y')
		                        SET @validdate =DATEADD(DAY,2,@datetoadd1)
		                     ELSE IF (@thu1 = 'Y')
		                        SET @validdate = DATEADD(DAY,3,@datetoadd1)
		                     ELSE IF (@fri1 = 'Y')
		                        SET @validdate = DATEADD(DAY,4,@datetoadd1)
		                     ELSE IF (@sat1 = 'Y')
		                        SET @validdate = DATEADD(DAY,5,@datetoadd1)
		                     ELSE IF (@sun1 = 'Y')
		                        SET @validdate =DATEADD(DAY,6,@datetoadd1)
		END
		ELSE
		BEGIN
		                    IF(@validdate IS NULL OR @validdate='')
		                        SET @validdate =@datetoadd1 
		END

	END

	 ELSE IF (upper(@day1) = upper('Tue') and  @tue is not null)
	BEGIN
	  IF (@tue != 'Y')
	   BEGIN	
	                     IF (@wed = 'Y')
	                        SET @validdate = DATEADD(DAY,1,@datetoadd1)
	                     ELSE IF (@thu = 'Y')
	                        SET @validdate =DATEADD(DAY,2,@datetoadd1)
	                     ELSE IF (@fri = 'Y')
	                        SET @validdate =DATEADD(DAY,3,@datetoadd1)
	                     ELSE IF (@sat = 'Y')
	                        SET @validdate = DATEADD(DAY,4,@datetoadd1)
	                     ELSE IF (@sun = 'Y')
	                        SET @validdate = DATEADD(DAY,5,@datetoadd1)
	                     ELSE IF (@mon = 'Y')
	                        SET @validdate =DATEADD(DAY,6,@datetoadd1)
	END
	ELSE
	BEGIN
	                    IF(@validdate IS NULL OR @validdate='') 
	                        SET @validdate =@datetoadd1 
	END
	                  
	IF (@tue1 != 'Y')
	BEGIN
	                     IF (@wed1 = 'Y')
	                        SET @validdate = DATEADD(DAY,1,@datetoadd1)
	                     ELSE IF (@thu1 = 'Y')
	                        SET @validdate = DATEADD(DAY,2,@datetoadd1)
	                     ELSE IF (@fri1 = 'Y')
	                        SET @validdate =DATEADD(DAY,3,@datetoadd1)
	                     ELSE IF (@sat1 = 'Y')
	                        SET @validdate = DATEADD(DAY,4,@datetoadd1)
	                     ELSE IF (@sun1 = 'Y')
	                        SET @validdate = DATEADD(DAY,5,@datetoadd1)
	                     ELSE IF (@mon1 = 'Y')
	                        SET @validdate =DATEADD(DAY,6,@datetoadd1)
	END
	ELSE
	BEGIN
	                    IF(@validdate IS NULL OR @validdate='')
	                        SET @validdate =@datetoadd1 
	END
END
	ELSE IF (upper(@day1) = upper('Wed')  and  @wed is not null)
	BEGIN
		 IF (@wed != 'Y')
		BEGIN
		                     IF (@thu = 'Y')
		                        SET @validdate =DATEADD(DAY,1,@datetoadd1)
		                     ELSE IF (@fri = 'Y')
		                        SET @validdate =DATEADD(DAY,2,@datetoadd1)
		                     ELSE IF (@sat = 'Y')
		                       SET  @validdate = DATEADD(DAY,3,@datetoadd1)
		                     ELSE IF (@sun = 'Y')
		                        SET @validdate = DATEADD(DAY,4,@datetoadd1)
		                     ELSE IF (@mon = 'Y')
		                        SET @validdate = DATEADD(DAY,5,@datetoadd1)
		                     ELSE IF (@tue = 'Y')
		                        SET @validdate =DATEADD(DAY,6,@datetoadd1)
		END
		ELSE
		BEGIN
		                    IF(@validdate IS NULL OR @validdate='')
		                       SET  @validdate = @datetoadd1 
		END
		                  
		IF (@wed1 != 'Y')
		BEGIN
		                     IF (@thu1 = 'Y')
		                        SET @validdate =DATEADD(DAY,1,@datetoadd1)
		                     ELSE IF (@fri1 = 'Y')
		                       SET  @validdate =DATEADD(DAY,2,@datetoadd1)
		                     ELSE IF (@sat1 = 'Y')
		                       SET  @validdate = DATEADD(DAY,3,@datetoadd1)
		                     ELSE IF (@sun1 = 'Y')
		                       SET  @validdate = DATEADD(DAY,4,@datetoadd1)
		                     ELSE IF (@mon1 = 'Y')
		                        SET @validdate = DATEADD(DAY,5,@datetoadd1)
		                     ELSE IF (@tue1 = 'Y')
		                       SET  @validdate =DATEADD(DAY,6,@datetoadd1)
		END
		ELSE
		BEGIN
		                    IF(@validdate IS NULL OR @validdate='')
		                        SET @validdate = @datetoadd1 
		END
	END


	 ELSE IF (upper(@day1) = upper('Thu')  and  @thu is not null)
	BEGIN
		 IF (@thu != 'Y')
		BEGIN
		                     IF (@fri = 'Y')
		                        SET @validdate = DATEADD(DAY,1,@datetoadd1)
		                     ELSE IF (@sat = 'Y')
		                        SET @validdate = DATEADD(DAY,2,@datetoadd1)
		                     ELSE IF (@sun = 'Y')
		                        SET @validdate = DATEADD(DAY,3,@datetoadd1)
		                     ELSE IF (@mon = 'Y')
		                        SET @validdate = DATEADD(DAY,4,@datetoadd1)
		                     ELSE IF (@tue = 'Y')
		                        SET @validdate = DATEADD(DAY,5,@datetoadd1)
		                     ELSE IF (@wed = 'Y')
		                        SET @validdate = DATEADD(DAY,6,@datetoadd1)
		END
		ELSE
		BEGIN
		                    IF(@validdate IS NULL OR @validdate='')
		                        SET @validdate =@datetoadd1 
		END
		                  
		IF (@thu1 != 'Y')
		BEGIN
		                     IF (@fri1 = 'Y')
		                        SET @validdate = DATEADD(DAY,1,@datetoadd1)
		                     ELSE IF (@sat1 = 'Y')
		                        SET @validdate =DATEADD(DAY,2,@datetoadd1)
		                     ELSE IF (@sun1 = 'Y')
		                        SET @validdate = DATEADD(DAY,3,@datetoadd1)
		                     ELSE IF (@mon1 = 'Y')
		                        SET @validdate = DATEADD(DAY,4,@datetoadd1)
		                     ELSE IF (@tue1 = 'Y')
		                        SET @validdate = DATEADD(DAY,5,@datetoadd1)
		                     ELSE IF (@wed1 = 'Y')
		                        SET @validdate = DATEADD(DAY,6,@datetoadd1)
		END
		ELSE
		BEGIN
		                    IF(@validdate IS NULL OR @validdate='')
		                        SET @validdate =@datetoadd1 
		END
	END
	
	 ELSE IF (upper(@day1) = upper('Fri')  and  @fri is not null)
	BEGIN
		IF (@fri != 'Y')
		BEGIN
		                     IF (@sat = 'Y')
		                        SET @validdate =DATEADD(DAY,1,@datetoadd1)
		                     ELSE IF (@sun = 'Y')
		                        SET @validdate =DATEADD(DAY,2,@datetoadd1)
		                     ELSE IF (@mon = 'Y')
		                        SET @validdate =DATEADD(DAY,3,@datetoadd1)
		                     ELSE IF (@tue = 'Y')
		                        SET @validdate = DATEADD(DAY,4,@datetoadd1)
		                     ELSE IF (@wed = 'Y')
		                        SET @validdate = DATEADD(DAY,5,@datetoadd1)
		                     ELSE IF (@thu = 'Y')
		                        SET @validdate =DATEADD(DAY,6,@datetoadd1)
		END
		ELSE
		BEGIN
		                    IF(@validdate IS NULL OR @validdate='')
		                        SET @validdate =@datetoadd1
		END
		                  
		IF (@fri1 != 'Y')
		BEGIN
		                     IF (@sat1 = 'Y')
		                        SET @validdate =DATEADD(DAY,1,@datetoadd1)
		                     ELSE IF (@sun1 = 'Y')
		                        SET @validdate =DATEADD(DAY,2,@datetoadd1)
		                     ELSE IF (@mon1 = 'Y')
		                        SET @validdate =DATEADD(DAY,3,@datetoadd1)
		                     ELSE IF (@tue1 = 'Y')
		                        SET @validdate = DATEADD(DAY,4,@datetoadd1)
		                     ELSE IF (@wed1 = 'Y')
		                       SET  @validdate = DATEADD(DAY,5,@datetoadd1)
		                     ELSE IF (@thu1 = 'Y')
		                        SET @validdate =DATEADD(DAY,6,@datetoadd1)
		END
		ELSE
		BEGIN
		                    IF(@validdate IS NULL OR @validdate='') 
		                        SET @validdate =@datetoadd1
		END
	END

	 ELSE IF (upper(@day1) = upper('Sat')  and  @sat is not null)
	BEGIN
	 IF (@sat != 'Y')
	BEGIN
	                     IF (@sun = 'Y')
	                        SET @validdate = DATEADD(DAY,1,@datetoadd1)
	                     ELSE IF (@mon = 'Y')
	                        SET @validdate = DATEADD(DAY,2,@datetoadd1)
	                     ELSE IF (@tue = 'Y')

	                        SET @validdate = DATEADD(DAY,3,@datetoadd1)
	                     ELSE IF (@wed = 'Y')
	                        SET @validdate = DATEADD(DAY,4,@datetoadd1)
	                     ELSE IF (@thu = 'Y')
	                        SET @validdate = DATEADD(DAY,5,@datetoadd1)
	                     ELSE IF (@fri = 'Y')
	                        SET @validdate = DATEADD(DAY,6,@datetoadd1)
	                     ELSE
	                      SET  @validdate = @datetoadd1
	END
	ELSE
	BEGIN
	                    IF(@validdate IS NULL OR @validdate='')
	                        SET @validdate =@datetoadd1
	END
	
	IF (@sat1 != 'Y')
	BEGIN
	                     IF (@sun1 = 'Y')
	                        SET @validdate = DATEADD(DAY,1,@datetoadd1)
	                     ELSE IF (@mon1 = 'Y')
	                        SET @validdate = DATEADD(DAY,2,@datetoadd1)
	                     ELSE IF (@tue1= 'Y')
	                        SET @validdate = DATEADD(DAY,3,@datetoadd1)
	                     ELSE IF (@wed1 = 'Y')
	                        SET @validdate = DATEADD(DAY,4,@datetoadd1)
	                     ELSE IF (@thu1 = 'Y')
	                        SET @validdate = DATEADD(DAY,5,@datetoadd1)
	                     ELSE IF (@fri1 = 'Y')
	                        SET @validdate = DATEADD(DAY,6,@datetoadd1)
	                     ELSE
	                       SET @validdate = @datetoadd1
	END
	ELSE
	BEGIN
	                    IF(@validdate IS NULL OR @validdate='') 
	                        SET @validdate =@datetoadd1
	END
	END

SELECT @noisscode=No_Iss_Code
                    FROM no_iss_mast
                   WHERE Edition_Code = @editioncode
SET @count1=0
 SELECT @count1=COUNT (*)
                    FROM no_iss_grid
                   WHERE No_Iss_Code = @noisscode
                   AND no_issue_date = @validdate
 IF (@count1 > 0)
BEGIN
	SET @validdate=DATEADD(DAY,1,@validdate)
	SET @datetoadd1=@validdate
              SET @day1=   substring(datename(weekday,@datetoadd1),0,4)
END
ELSE
BEGIN
	 SET @validdate = @validdate
	SET @i=1
              BREAK
END

END

	  INSERT INTO #RESULTS_TMP
	SELECT (SELECT Edition_Alias
                FROM edition_mast
                WHERE Edition_Code =
                LTRIM (RTRIM (@editioncode)))
                edition_alias,@validdate


FETCH NEXT FROM c1
	INTO @editioncode, @sun, @mon, @tue, @wed, @thu, @fri, @sat


END

CLOSE c1
DEALLOCATE c1

SELECT @count2=COUNT (*)
        FROM #RESULTS_TMP

 SELECT @count1=COUNT (*)
        FROM #RESULTS_TMP
       WHERE date_noissue = @fixdate

IF (@count1 = @count2)
BEGIN
	 IF (@DATEFORMAT = 'mm/dd/yyyy')
	BEGIN
		SELECT CONVERT(VARCHAR(10),@fixdate,101) AS date_noissue
		SELECT EDITION_CODE as Edition_code,CONVERT(VARCHAR(10),date_noissue,101) as date_noissue
	             FROM #RESULTS_TMP
	END
	ELSE IF (@DATEFORMAT = 'dd/mm/yyyy')
	BEGIN
		SELECT CONVERT(VARCHAR(10),@fixdate,103) AS date_noissue
		SELECT EDITION_CODE as Edition_code,CONVERT(VARCHAR(10),date_noissue,103) as date_noissue
	             FROM #RESULTS_TMP
	END
	ELSE IF (@DATEFORMAT = 'yyyy/mm/dd')
	BEGIN
		SELECT CONVERT(VARCHAR(10),@fixdate,111) AS date_noissue
		SELECT EDITION_CODE as Edition_code,CONVERT(VARCHAR(10),date_noissue,111) as date_noissue
	             FROM #RESULTS_TMP
	END
	
END
ELSE
BEGIN
	 IF (@DATEFORMAT = 'mm/dd/yyyy')
	BEGIN
		SELECT TOP 1 CONVERT(VARCHAR(10),date_noissue,101) AS date_noissue FROM #RESULTS_TMP where edition_code=@pkgname
		SELECT EDITION_CODE as Edition_code,CONVERT(VARCHAR(10),date_noissue,101) as date_noissue
	             FROM #RESULTS_TMP
	END
	ELSE IF (@DATEFORMAT = 'dd/mm/yyyy')
	BEGIN
		SELECT TOP 1  CONVERT(VARCHAR(10),date_noissue,103) AS date_noissue FROM #RESULTS_TMP where edition_code=@pkgname
		SELECT EDITION_CODE as Edition_code,CONVERT(VARCHAR(10),date_noissue,103) as date_noissue
	             FROM #RESULTS_TMP
	END
	ELSE IF (@DATEFORMAT = 'yyyy/mm/dd')
	BEGIN
		SELECT TOP 1  CONVERT(VARCHAR(10),date_noissue,111) AS date_noissue FROM #RESULTS_TMP where edition_code=@pkgname
		SELECT EDITION_CODE as Edition_code,CONVERT(VARCHAR(10),date_noissue,111) as date_noissue
	             FROM #RESULTS_TMP
	END
END
*****************************************************************************************************************************************
*****************************************************************mimoh//10/10/2011***************issue-0005269***************************

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go















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
@genrate_agency_code AS VARCHAR(5)
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

ALLOWED_PDC_DAYS_RECEIPT=@P_ALLOW_PDC,AD_TYPE_MANUL_BILL=@PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=@RO_OUTSTAND_P,GENRATE_CIR_AGCD=@genrate_agency_code

 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)

**************************************************************************************************************

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go















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
ALLOWED_PDC_DAYS_RECEIPT,AD_TYPE_MANUL_BILL, OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD
           FROM PREFERRENCES
          WHERE comp_code = @compcode







*****************************************************************mimoh//10/10/2011********endof*******issue-0005269***************************




//****************************************************************garima 11/10/2011 start **********isssue 4740**************
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





ALTER procedure [dbo].[websp_selectvalues_pra]
(	@pcompcode		VARCHAR(50),
	@pinvoiceno		varchar(50), 
	@pbillcycle		varchar(50), 
	@pdateformat	varchar(50),
	@pextra1		varchar(50),
	@pextra2		varchar(50),
	@pextra3		varchar(50),
	@pextra4		varchar(50),
	@pextra5		varchar(50))
as 
declare @str  as varchar(8000)
declare @package_cd  as varchar(300)
declare @package_result  as varchar(300)
declare @package_cd1  as varchar(300)
create table #package ( package_name varchar (100) )

set @str='select distinct TBL_BOOKING_MAST.cio_booking_id as "CIOID",
AGENCY_MAST.agency_name as "Agency",
PUB_MAST.pub_name as "Pub",PUB_MAST.pub_name as "Pub"
,tbl_booking_insert.height as "Depth",

case 
when TBL_BOOKING_MAST.uom_code=''CO0'' then tbl_booking_insert.No_ofcolumn
when TBL_BOOKING_MAST.uom_code <> ''CO0'' then tbl_booking_insert.width end as "Width"

/*,tbl_booking_insert.width as "Width"*/
, COL_MAST.col_alias as "Hue",tbl_booking_insert.no_insert as "Ins.No."
 ,ro_no as "RoNo.",
TBL_BOOKING_MAST.card_amount as "Amt",TBL_BOOKING_INSERT.disc_rate as "Disc",
(select advpos_type_mast.pos_type from advpos_type_mast where advpos_type_mast.pos_type_code=tbl_booking_insert.page_post) as "pageposition",
(select adv_cat_mast.adv_cat_name from adv_cat_mast where ADV_CAT_MAST.adv_cat_code=TBL_BOOKING_MAST.ad_cat_code) as "AdCat",
tbl_booking_insert.size_book as "volume",tbl_booking_mast.card_rate as "package rate", edition_mast. edition_alias as "edition"
,isnull((select distinct cust_mast.cust_alias from cust_mast  where  cust_mast.cust_code=tbl_booking_mast.client_code),tbl_booking_mast.client_code) as "advertiser",
tbl_booking_mast.agency_sub_code,tbl_booking_mast.gross_amount,agency_mast.add1 , city_mst.city_name,
(select distinct box_mast.box_charges_native from box_mast where tbl_booking_mast.box_code=box_mast.box_code) as "boxchares" ,
tbl_booking_insert.gross_rate,
tbl_booking_mast.creation_datetime,
(select distinct  min(package_name) from combin_mast where combin_desc=tbl_booking_insert.edition)as package_name,
(select distinct max(cust_mast.ADD1) from cust_mast  where  cust_mast.cust_code=tbl_booking_mast.client_code) as "clientAd",
isnull((select max(cust_name) from CUST_MAST where cust_code=client_code),client_code)  as "Client",tbl_booking_mast.no_of_insertion,

case '''+@pdateformat + '''

 when ''mm/dd/yyyy'' then convert(varchar(10),insertion_date,1) 

when ''dd/mm/yyyy'' then convert(varchar(10),insertion_date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),insertion_date,3)  end as "Ins.date" ,
tbl_booking_insert. page_no,
(select premiumname from ADVPOS_PREM_MAST where ADVPOS_PREM_MAST. premiumcode=tbl_booking_insert.premium1),
tbl_booking_mast.special_discount,
tbl_booking_mast.special_charges,tbl_booking_mast.trade_disc,
(select distinct premium_charges from ADVPOS_PREM_MAST where ADVPOS_PREM_MAST. premiumcode=tbl_booking_insert.premium1 ) as "premiumch",
tbl_booking_insert.card_rate,
pub_cent_mast.add1,
pub_cent_mast.phone1,
pub_cent_mast.phone2 ,
pub_cent_mast.fax1,
TBL_BOOKING_INSERT.agreed_rate,
TBL_BOOKING_INSERT.Edition as "EditionName",
agency_mast.bill_to,
case '''+@pdateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),insert_date,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),insert_date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),insert_date,3)  end as "insert_date",
tbl_booking_mast.uom_code,
(select distinct Uom_Name from uom_mast where uom_code=tbl_booking_mast.uom_code) as uom_name,
(select Adv_Type_Name from adv_type_mast where Adv_Type_Code=tbl_booking_mast.Ad_type_code) as ad_type,

comp_mst.COMP_NAME as "companyname",
comp_mst.PAN_NO as "pan",
PUB_CENT_MAST.Pub_Cent_name as "pubname",
comp_mst.ADD1 as "address",
comp_mst.STREET as "street",
comp_mst.FAX as "fax",
tbl_booking_insert.Bill_Amt,
1 as "Email",
case '''+@pdateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),1) 
when ''dd/mm/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),3) 
when ''yyyy/mm/dd'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),3)  end as "paydate",
case '''+@pdateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),1) 
when ''dd/mm/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),3) 
when ''yyyy/mm/dd'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),3)  end as "paydatesys",
tbl_booking_insert.insert_id,
AGENCY_MAST."Add2",
AGENCY_MAST."Add3",
tbl_booking_mast.Scheme_type_code as "scheme",
tbl_booking_mast.Rate_code as "rate_code",
agency_mast.Agency_Code as "agency_cod",
(select top 1 Box_Charges_Native from Box_mast where Box_mast.Box_Code=tbl_booking_mast.Box_code) as "Box_Charge",
tbl_booking_mast.Page_amount as "Pag_amt",
tbl_booking_mast.Prem_per as "pag_prem",
dbo.get_printing_cent_name_fr_bran('''+@pcompcode+''',tbl_booking_mast.branch) as Print_cent_name,
case '''+@pdateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),date_time,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),date_time,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),date_time,3)  end as "date_time",
case tbl_booking_mast.ad_type_code
when ''DI0'' then tbl_booking_mast."Caption"
else tbl_booking_mast."key_no" end as "Cap",
TBL_BOOKING_mast.ADD_AGENCY_COMM as "addcom",
TBL_BOOKING_MAST.RO_Date ,
AGENCY_MAST.pin_code,
(select distinct COLORRATEGROUPMAST.prcent_pr from COLORRATEGROUPMAST 
where tbl_booking_mast.comp_code=COLORRATEGROUPMAST.comp_code and 
tbl_booking_mast.ad_type_code=COLORRATEGROUPMAST.ad_type and tbl_booking_insert.package_code=COLORRATEGROUPMAST.pkg_code 
 and tbl_booking_insert.col_code=COLORRATEGROUPMAST.color_name) as "Extra",
(select top 1 Cont_Person from cont_details where tbl_booking_mast.Comp_code=cont_details.Comp_Code 
and cont_details.Agency_Code=tbl_booking_mast.Agency_code) as "contact",
dbo.AD_GET_RETAINER('''+@pcompcode+''',TBL_BOOKING_MAST.RETAINER) as "RETAINER",dbo.AD_GET_EXECNAME('''+@pcompcode+''',TBL_BOOKING_MAST.EXECUTIVE_CODE)as "EXECUTIVE_CODE",
case '''+@pdateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),getdate(),1) 
when ''dd/mm/yyyy'' then convert(varchar(10),getdate(),3) 
when ''yyyy/mm/dd'' then convert(varchar(10),getdate(),3)  end as "rundate",


case '''+@pdateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),TBL_BOOKING_INSERT.BILL_DATE,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),TBL_BOOKING_INSERT.BILL_DATE,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),TBL_BOOKING_INSERT.BILL_DATE,3)  end as "BILL_DATE",

(select min(VAT_RATE)  from tbl_vat_mast where tbl_vat_mast.comp_code=tbl_booking_mast.Comp_code and vat_description=''VAT'') as "Vat"

from TBL_BOOKING_MAST,pub_cent_mast,
TBL_BOOKING_INSERT,
AGENCY_MAST ,
PUB_MAST,
COL_MAST ,
edition_mast,
city_mst,
comp_mst
	where TBL_BOOKING_MAST.comp_code='''+@pcompcode+''' and TBL_BOOKING_INSERT.pub_cent_code=pub_cent_mast.pub_cent_code
	and TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.cio_booking_id
	and TBL_BOOKING_MAST.agency_code=AGENCY_MAST.agency_code  and comp_mst.comp_code='''+@pcompcode+''' 
	and tbl_booking_insert.Col_code=col_mast.Col_code and pub_mast.pub_code=tbl_booking_insert.publication_code 
	and edition_mast.edition_code=tbl_booking_insert.edition_code and city_mst.city_code=agency_mast.city_code  and TBL_BOOKING_INSERT.publication_code = PUB_MAST.pub_code 
	and tbl_booking_insert.bill_no='''+@pinvoiceno+'''  '

select @package_cd1=max(tbl_booking_mast.package_code) from tbl_booking_mast,tbl_booking_insert 
	where tbl_booking_mast.cio_booking_id=tbl_booking_insert.cio_booking_id and tbl_booking_insert.bill_no=@pinvoiceno

DECLARE c1 CURSOR READ_ONLY FOR
	select Edition_Name from fn_SplitField(@package_cd1,',')
	       
	open c1
		FETCH NEXT FROM c1 INTO @package_result

		WHILE @@FETCH_STATUS = 0
		BEGIN


			insert into #package select combin_desc from combin_mast where combin_code=@package_result
			--select * from #package		 

		FETCH NEXT FROM c1	INTO  @package_result
		END
		print(@package_result)
	CLOSE c1
	DEALLOCATE c1

print(@str)
exec(@str)

select * from #package
delete from #package

select distinct edition_code from tbl_booking_insert where bill_no=@pinvoiceno

select top 1 insert_date from tbl_booking_insert where bill_no=@pinvoiceno order by insert_date




//**************************************************end of issue 4740***************************************************


//**************************************************issue 4797//Prachi***************************************************


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER PROCEDURE [dbo].[report]
(
@agname varchar(50)=null,
@clientname varchar(50)=null,
@adtype varchar(50),
@adcategory varchar(50),
@fromdate varchar(50),
@dateto varchar(50),
@compcode varchar(10),
@pub_name varchar(50),
@pub_cent varchar(50),
@status varchar(50)=null,
@edition varchar(50),
@dateformat varchar(50),
@hold varchar(10)=null,
@descid varchar(50)=null,
@ascdesc varchar(50)=null


)
as 
declare @str  as varchar(3000)
declare @center  as varchar(50)



set @str='select TBL_BOOKING_MAST.cio_booking_id as "CIOID",AGENCY_MAST.agency_name as "Agency",isnull((select cust_name from CUST_MAST where cust_code=client_code),client_code)  as "Client",PUB_CENT_MAST.pub_cent_name as "City",
PUB_MAST.pub_name as "Pub",COMBIN_MAST.combin_desc as "Package",ad_size_height as "Depth",ad_size_width as "Width",TBL_BOOKING_MAST.total_area as "Area", COL_MAST.col_alias as "Hue",(select ADVPOS_TYPE_MAST.pos_type_alias from ADVPOS_TYPE_MAST where TBL_BOOKING_INSERT.page_post=ADVPOS_TYPE_MAST.pos_type_code) as "Page",no_insert as "Ins.No.",
case '''+@dateformat + '''

 when ''mm/dd/yyyy'' then convert(varchar(10),Insert_Date,101) 

when ''dd/mm/yyyy'' then convert(varchar(10),Insert_Date,103) 
when ''yyyy/mm/dd'' then convert(varchar(10),Insert_Date,111)  end as "Ins.date" ,

case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),TBL_BOOKING_MAST.date_time,101) 
when ''dd/mm/yyyy'' then convert(varchar(10),TBL_BOOKING_MAST.date_time,103) 
when ''yyyy/mm/dd'' then convert(varchar(10),TBL_BOOKING_MAST.date_time,111)  end as "BookDate"
  ,ro_no as "RoNo.",
case ro_status
when ''1'' then ''Reservation''
when ''2'' then ''Confirm''
end as "RoStatus",
 ADV_TYPE_MAST. Adv_type_name as "AdType" 
,rate_Code as "RateCode",TBL_BOOKING_INSERT.card_rate as "CardRate",isnull(TBL_BOOKING_MAST.card_amount,TBL_BOOKING_MAST.gross_amount) as "Amt",TBL_BOOKING_INSERT.disc_rate as "Disc",  TBL_BOOKING_INSERT.insert_status as "Status",TBL_BOOKING_INSERT.status_material as "MatStatus",caption as "Cap",key_no as "Key",agrred_rate as "AgreedRate",(select  AGENCY_MAST.Sub_Agency_code from agency_mast where  AGENCY_MAST.type <> ''P'' and TBL_BOOKING_MAST.agency_code=AGENCY_MAST.code_subcode )as "SubAg",(select adv_cat_mast.adv_cat_name from adv_cat_mast where ADV_CAT_MAST.adv_cat_code=TBL_BOOKING_MAST.ad_cat_code) as "AdCat",SAPID

from TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,PUB_MAST,PUB_CENT_MAST,ADV_TYPE_MAST ,COMBIN_MAST, COL_MAST 
 where TBL_BOOKING_MAST.comp_code='''+@compcode+''' and TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.cio_booking_id
 and TBL_BOOKING_MAST.agency_code=AGENCY_MAST.agency_code and TBL_BOOKING_MAST.Ad_type_code=ADV_TYPE_MAST .adv_type_code
 and tbl_booking_mast.Color_code=col_mast.Col_code  and 
TBL_BOOKING_MAST.package_code=COMBIN_MAST.combin_code and TBL_BOOKING_MAST.agency_sub_code=AGENCY_MAST.code_subcode and TBL_BOOKING_INSERT.publication_code = PUB_MAST.pub_code and TBL_BOOKING_INSERT.pub_cent_code=PUB_CENT_MAST.pub_cent_code '

--select adv_cat_mast.adv_cat_name from adv_cat_mast where ADV_CAT_MAST.adv_cat_code=TBL_BOOKING_MAST.ad_cat_code



if(@hold<>null)
begin
set @str=@str+' and TBL_BOOKING_INSERT.insert_status!="Cancel"'
end

if(@agname <>null)
begin

set @str=@str+' and TBL_BOOKING_MAST.agency_code ='''+@agname +''''
end

if(@clientname <>null)
begin
set @str=@str+' and TBL_BOOKING_MAST.client_code ='''+@clientname +''''
end
if(@status <>null)
begin
set @str=@str+' and TBL_BOOKING_INSERT.insert_status  ='''+@status+''''
end


if(@adtype<>null)
begin
print(@adtype)
set @str=@str + 'and TBL_BOOKING_MAST. ad_type_code ='''+@adtype+''' '
End

if(@adcategory <> null)
begin
set @str=@str +  ' and TBL_BOOKING_MAST. ad_cat_code in('''+@adcategory+''' )'
End


--if(@pub_cent<>null )
--begin
--select @center=substring(pub_cent_alias,1,3) from pub_cent_mast where pub_cent_code=@pub_cent

--print(@center)
--set @str=@str+'  and tbl_booking_insert.pub_cent_code='''+ @center +''''
--print(@str)
--end
if(@pub_cent<>null)
begin
set @str=@str+'  and tbl_booking_insert.pub_cent_code ='''+  @pub_cent+''''
end




if(@fromdate is not null and @dateto is null )
begin
	set @str=@str+' and Insert_Date ='''+@fromdate +''''

end

else if(@fromdate is not null and @dateto is not null )
begin
	set @str=@str+' and Insert_Date between  '''+@fromdate +''' and  '''+@dateto +''' '
end

if(@edition <> null)
begin
set @str=@str+'  and tbl_booking_insert.edition_code='''+ @edition +''''
End

if(@pub_name <> null)
begin
set @str=@str+' and  TBL_BOOKING_INSERT.publication_code='''+ @pub_name +''''
End



if(@descid <>  null)
begin
set @str=@str+'  order by '''+@descid + ''''
set @str=@str+ ''+@ascdesc+''

End







print(@str)
exec(@str)

//**************************************************end of issue 4797*************************************************

/***************************Kuldeep Bhati 12/10/2011***0005318 ****************************/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go







ALTER  PROCEDURE [dbo].[websp_loginemployee]
@username varchar(50),
@password varchar(10),
@qbc varchar(8)=null

AS
declare @query as varchar(900)
declare @count as varchar(100)
declare @query1 as varchar(900)
declare @query2 as varchar(1000)
declare @userid varchar(100)

if(@qbc=null or @qbc='')
begin
set @query='select username,password,userid,date_format,com_code,autogenerate,curr_code  ,comp_name, datediff(dd,creation_datetime,getdate()) as diff,DISCOUNT,FILTER,ROLEID,retainer_code AS RETAINER          from login where userid='''+@username+''' and password='''+@password+''''

select @count=com_code from login where userid=@username and password=@password
/*new change ankur for agency*/
set @query1='SELECT rate_gr_code,autogenerated,currency_code,date_format,solo,No_of_Decimal,
        breakup,blackwhitecode,uom_code,rostatus,Tfn,Insert_breakup,Premium_type,Deal_type     ,
        prefix,suffix,financestatus,voucherst,Ad_category,Ro_datetime,Space_area,Vat,Booking_status,Cio_id,Receipt_no,Bgcolor_publication, chkfor_valid_pubdates,Agency_ratecode,audit,copy_booking,RATE_COMPANY_AGENCY,SUBEDITIONRATE,ADDITIONAL_AGENCY_COMM,AGENCY_RETAINER_COMM,

        invoice_no,rate_audit,CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT, RATE_CHECK, ALL_PACKAGE,DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,ROKEYCHECK,
		DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF,FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,DISP_AUDITBKG

  from preferrences where comp_code= '''+@count+'''' 
select @userid=userid from login where username=@username and  password=@password  and com_code=@count

set @query2='select company_user,Admin from login where userid='''+@username+''''

end
else
begin
set @query='select username,password,userid,date_format,com_code,autogenerate,curr_code  ,comp_name  , datediff(dd,creation_datetime,getdate()) as diff,DISCOUNT,FILTER ,ROLEID ,retainer_code   AS RETAINER     from login where userid='''+@username+''' and password='''+@password+''' and retainer_code='''+@qbc+''''

select @count=com_code from login where userid=@username and password=@password and retainer_code=@qbc

/*new change ankur for agency*/
set @query1='SELECT rate_gr_code,autogenerated,currency_code,date_format,solo,No_of_Decimal,
        breakup,blackwhitecode,uom_code,rostatus,Tfn,Insert_breakup,Premium_type,Deal_type     ,
        prefix,suffix,financestatus,voucherst,Ad_category,Ro_datetime,Space_area,Vat,Booking_status,Cio_id,Receipt_no,Bgcolor_publication, chkfor_valid_pubdates,Agency_ratecode,audit,copy_booking,RATE_COMPANY_AGENCY,SUBEDITIONRATE,ADDITIONAL_AGENCY_COMM,AGENCY_RETAINER_COMM,

        invoice_no,rate_audit,CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT, RATE_CHECK, ALL_PACKAGE,DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,ROKEYCHECK,
		DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF,FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,DISP_AUDITBKG from preferrences where comp_code= '''+@count+''''

select @userid=userid from login where username=@username and  password=@password  and com_code=@count

set @query2='select company_user,Admin from login where userid='''+@username+''''
end


print(@query)
exec(@query)

print(@query1)
exec(@query1)


print(@query2)
exec(@query2)

==================================================================================================================
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[Bindaudit_grid](
  @date        as VARCHAR(50),
  @adtype       as VARCHAR(50),
  @branch2      as VARCHAR(50),
  @userid      as varchar(50),
  @comp_code   as VARCHAR(20)
)
AS
     BEGIN
     
    SELECT "cio_booking_id",
    isnull((select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code",AUDIT_COMMENT
    FROM TBL_BOOKING_MAST WHERE  TBL_BOOKING_MAST."Comp_code" =@comp_code and "branch" IN
    (SELECT "Branch_Code" FROM BRANCH_MST WHERE branch_mst."Branch_Code" in
    (select lb.branch_code from login_branch_mast lb where  lb.user_code=@userid and isnull(lb.user_flag,'N')='Y')
	 AND "pub_center"=@branch2)
    AND "Ad_type_code"=@adtype AND (audit IS   NULL or audit='') and AUDIT_COMMENT is not null;
END 


===============================================================================================================

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
















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
ALLOWED_PDC_DAYS_RECEIPT,AD_TYPE_MANUL_BILL, OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD,DISP_AUDITBKG
           FROM PREFERRENCES
          WHERE comp_code = @compcode

=============================================================================================================
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


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
@p_dispauditbk AS VARCHAR(5)
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

ALLOWED_PDC_DAYS_RECEIPT=@P_ALLOW_PDC,AD_TYPE_MANUL_BILL=@PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=@RO_OUTSTAND_P,GENRATE_CIR_AGCD=@genrate_agency_code,DISP_AUDITBKG=@p_dispauditbk

 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)


//**************************************************end of issue 0005318*************************************************

//*************************************************************issue 0005143 mimoh 12 oct 2011************************************************************


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER proc [dbo].[updateClientPay]
(
@Cash varchar(50) ,
--@Credit varchar(10),
--@Bank varchar(10),
@Comp_Code varchar (8),
@Client_Code varchar (8),
@userid varchar (8) ,
@Flag int

)

as

	if(@Flag=0)
	begin
		insert into pay_mode_client(Comp_Code,Client_Code,userid,creation_datetime,pay_mode) values(@Comp_Code,@Client_Code,@userid,getdate(),@cash) 
	end


	if(@Flag=1)
		begin
			declare @Resultset varchar(900)
declare @count int
select @count=count(*) from pay_mode_client where Comp_Code=@Comp_Code  and Client_Code =@Client_Code
if( @count = 0) 
		insert into pay_mode_client(Comp_Code,Client_Code,userid,creation_datetime,pay_mode) values(@Comp_Code,@Client_Code,@userid,getdate(),@cash) 
else
			set @Resultset = 'update pay_mode_client set pay_mode = '''+ @cash+'''where Comp_Code = '''+@Comp_Code+''' and Client_Code = '''+@Client_Code+''''	
		end
	if(@Flag=2)
		begin
			delete from pay_mode_client where Comp_Code = @Comp_Code and Client_Code = @Client_Code and userid = @userid
		end
print(@Resultset)
exec(@Resultset)



//*****************************************************end********issue 0005143 mimoh 12 oct 2011************************************************************


/***************************Kuldeep Bhati 12/10/2011***0005330 ****************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[getuomdesc]
@compcode as varchar(8),
@value as varchar(8)
AS
select uom_desc,Logo,Logo_Uom,FLAG,Uom_Name from uom_mast where uom_code=@value


======================================================================================
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER  procedure [dbo].[ad_getuomfvalue]
(
@p_compcode as VARCHAR(20),
@p_uomcode as  VARCHAR(20)
)
AS
BEGIN

SELECT Uom_Name,FLAG FROM UOM_MAST WHERE Comp_Code=@p_compcode AND Uom_Code=@p_uomcode

END


/***************************Kuldeep Bhati 12/10/2011******0005330 ************************/



//================================issue no. 4785,4887 13/10/2011==========================================================


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




ALTER procedure [dbo].[completereport]
(
@compcode as varchar(50)= NULL,
@fromdate as varchar(50)= NULL,
@dateto as varchar(50)= NULL,
@dateformat as varchar(50)= NULL,
@publication as varchar(50)= NULL,
@pub_cent as varchar(50)= NULL,
@edition as varchar(50)= NULL,
@suppliment as varchar(50)= NULL,
@zone as varchar(50)= NULL,
@branch as varchar(50)= NULL,
@district as varchar(50)= NULL,
@region as varchar(50)= NULL,
@city as varchar(50)= NULL,
@revcenter as varchar(50)= NULL,
@adtype as varchar(50)= NULL,
@agencytype as varchar(50)= NULL,
@ratetype as varchar(50)= NULL,
@adcat as varchar(50)= NULL,
@adsubcat as varchar(50)= NULL,
@adsubcat3 as varchar(50)= NULL,
@adsubcat4 as varchar(50)= NULL,
@adsubcat5 as varchar(50)= NULL,
@package as varchar(50)= NULL,
@scheme as varchar(50)= NULL,
@agency as varchar(50)= NULL,
@client as varchar(50)= NULL,
@executive as varchar(50)= NULL,
@retainer as varchar(50)= NULL,
@product as varchar(50)= NULL,
@brand as varchar(50)= NULL,
@varient as varchar(50)= NULL,
@pagetype as varchar(50)= NULL,
@pageprem as varchar(50)= NULL,
@postprem as varchar(50)= NULL,
@rostatus as varchar(50)= NULL,
@booktype as varchar(50)= NULL,
@contractname as varchar(50)= NULL,
@filterby as varchar(50)= NULL,
@adcheck as varchar(50)=null,
@state as varchar(50)=null,
@taluka as varchar(50)=null,
@base as varchar(50)=null,
@drpstatus as varchar(50)=null,
@chkdetail as varchar(50)=null,
@puserid as varchar(50)=null,
@insertstatus as varchar(50)=null,
@chk_access as varchar(2)
)
AS
declare @query1 as VARCHAR(8000)
declare @v_val as int
declare @query2 as VARCHAR(8000)
declare @query4 as VARCHAR(8000)
declare @query3 as VARCHAR(8000)

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
(
  CIOID             varchar(50),
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
PAGE_NO int

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

--old version

--and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
--and (tbl_booking_mast."branch" =p_branch or p_branch is null)

--new version
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
		and ((@drpstatus is  not null and  TBL_BOOKING_INSERT.Insert_Status!='XYZ')
		or (@drpstatus is  null and  lower(Insert_Status)!='cancel'))
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
--old version

--and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
--and (tbl_booking_mast."branch" =p_branch or p_branch is null)

--new version
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
		and ((@drpstatus is  not null and  TBL_BOOKING_INSERT.Insert_Status!='XYZ')
		or (@drpstatus is  null and  lower(Insert_Status)!='cancel'))
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
fetch next from c1
into @c1cioid ,@c1pckcode,@c1gramt,@c1chkvar
PRINT(@@FETCH_STATUS)
while @@FETCH_STATUS=0
begin
PRINT('KHARE')
PRINT(@c1chkvar)
	if(@c1chkvar='1')begin	
		insert into MULTIPACK_REP select * from dbo.multipack_report1(@c1cioid, @c1pckcode, @c1gramt, '1')

	end
	else if(@c1chkvar='3') begin
		insert into MULTIPACK_RAT select * from dbo.multipack_report3(@c1cioid, @c1pckcode, @c1gramt, '3')
	end
	else
	begin
		insert into MULTIPACK_RATNEW select * from dbo.multipack_report2(@c1cioid, @c1pckcode, @c1gramt, '2')
	end
	set @v_edition=null
	set @v_edipkg=null
fetch next from c1
into @c1cioid ,@c1pckcode,@c1gramt,@c1chkvar
end
close c1
print('145466')
print(@chkdetail)
print(@adcheck)
print('xz')
if(@chkdetail='Detail')begin

if(@adcheck=1)
begin
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
(select tbl_cat4.Cat_Name from tbl_cat4,adv_subcat_mast where a.Ad_Subcat4=tbl_cat4.Cat_Code and tbl_cat4.Sub_Cat_Name=adv_subcat_mast.Adv_Subcat_Code and a.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code) as Adsubcat4,
(select tbl_cat5.Cat_Name from tbl_cat5,adv_subcat_mast where a.Ad_subcat5=tbl_cat5.Cat_Code and tbl_cat5.Sub_Cat_Name=adv_subcat_mast.Adv_Subcat_Code and a.Ad_sub_cat_code=adv_subcat_mast.Adv_Subcat_Code and  adv_cat_mast.Adv_Cat_Code=adv_subcat_mast.Adv_Cat_Code) as Adsubcat5,
dbo.FETCH_PACK(a.cio_booking_id) AS Package,
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
isnull((a.Bill_amount-isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''2'' ),''0'')  ),''0'') as ActualBusiness,
(SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE a.Revenue_center=BRANCH_MST.Branch_Code )as Revcenter,
UOM_MAST.Uom_Name  AS Uom,
uom_mast.UOM_DESC as uomdesc
,(select top 1 pub_cent_mast.Pub_Cent_name from pub_cent_mast where pub_cent_mast.Pub_cent_Code in(select pub_center from  BRANCH_MST WHERE a.branch=Branch_Name) ) as Printcenter
,a.branch as Branch
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
,Box_code as "BoxCode"
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
		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' )
		begin
		set @query4=' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 


		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' )
		begin
		set @query4=' and a.Insertion_date  between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 
end
else 
begin
		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' )
		begin
		set @query4=@query4+' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 

		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' )
		begin
		set @query4=@query4+' and a.Insertion_date  between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 
end
if(@base='2')begin
set @query4=@query4+' and (a.Executive_code is not null and a.Executive_code<>'''' and a.Executive_code !=''0'')  '
end 

if(@base='3')begin
set @query4=@query4+' and (a.RETAINER is not null and a.RETAINER<>''''  and a.RETAINER !=''0'')  '
end 


if(@drpstatus is null or  @drpstatus = '') begin
set @query4=@query4+' and lower(Insert_Status)!=''cancel'''
end 
if(@insertstatus is not null and @insertstatus<>'') begin
set @query4=@query4+' and lower(Insert_Status)='''+@insertstatus+''''
end 




IF(@publication IS NOT NULL)
begin
set @query4=@query4+' and TBL_BOOKING_insert.publication_Code='''+@publication+'''    '
END 

/*IF(@pub_cent IS NOT NULL)
begin
--set @query4=@query4+'  and tbl_booking_insert.Pub_Cent_Code='''+pub_cent+''''
set @query4=@query4+'  and a.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE a.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code='''+@pub_cent+'''))'

END

IF(@branch IS NOT NULL  and @branch<>'')
begin
set @query4=@query4+'  and a.branch ='''+@branch+''''
END*/


--old version
/*IF(@publication IS NOT NULL)
begin
set @query4=@query4+'  and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_mast."branch" ='''||p_branch||'''';
END IF;
*/

--new version
IF(@pub_cent IS NOT NULL)
begin
set @query4=@query4+'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
END 


IF(@branch IS NOT NULL  and @branch<>'')
begin
set @query4=@query4+'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
END 


IF(@edition IS NOT NULL  and @edition<>'')
begin
set @query4=@query4+'  and tbl_booking_insert.Edition_Code='''+@edition+''''
END 

 

IF(@region IS NOT NULL and @region <>'')
begin
--set @query4=@query4 +' and tbl_booking_insert.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+region +''')'
set @query4=@query4 +' and agency_mast.region ='''+@region +''' '
END 

IF(@revcenter IS NOT NULL and @revcenter <>'')
begin
set @query4=@query4 +' and a.Revenue_center ='''+@revcenter+''''
END 

IF(@adtype IS NOT NULL and @adtype <>'')
begin
set @query4=@query4 + ' and a.Ad_type_code='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype <>'')
begin
set @query4=@query4 + ' and a.Agency_type ='''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat <>'')
begin
set @query4=@query4 + ' and a.Ad_cat_code ='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat <>'')
begin
set @query4=@query4 + ' and a.Ad_sub_cat_code ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'')
begin
set @query4=@query4 + ' and a.Ad_Subcat3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'')
begin
set @query4=@query4 + ' and a.Ad_Subcat4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'')
begin
set @query4=@query4 + ' and a.Ad_subcat5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package <>'')
begin
set @query4=@query4 + ' and a.Package_code ='''+@package+''''
END 

IF(@scheme IS NOT NULL and @scheme <>'')
begin
set @query4=@query4 + ' and a.Scheme_type_code ='''+@scheme+''''
END 

IF(@agency IS NOT NULL and @agency <>'')
begin
set @query4=@query4 + ' and a.Agency_code ='''+@agency+''''
END 

IF(@client IS NOT NULL and @client  <>'')
begin
set @query4=@query4 + ' and a.Client_code ='''+@client+''''
END 

IF(@executive IS NOT NULL and @executive <>'')
begin
set @query4=@query4 + ' and a.Executive_code ='''+@executive+''''
END 

IF(@retainer IS NOT NULL and @retainer <>'')
begin
set @query4=@query4 + ' and a.RETAINER ='''+@retainer+''''
END 

IF(@product IS NOT NULL and @product <>'')
begin
set @query4=@query4 + ' and a.Product_code ='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand <>'')
begin
set @query4=@query4 + ' and a.Brand_code ='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient <>'')
begin
set @query4=@query4 + ' and a.Variant_code ='''+@varient+''''
END 

IF(@pagetype IS NOT NULL and @pagetype <>'')
begin
set @query4=@query4 + ' and a.Page_type_code ='''+@pagetype+''''
END 

IF(@pageprem IS NOT NULL and @pageprem <>'')
begin
set @query4=@query4 + ' and a.Page_prem ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem <>'')
begin
set @query4=@query4 + ' and a.Page_position_code ='''+@postprem+''''
END 

IF(@rostatus IS NOT NULL and @rostatus <>'')
begin
set @query4=@query4 + ' and a.ro_status ='''+@rostatus+''''
END 

IF(@booktype IS NOT NULL and @booktype <>'')
begin
set @query4=@query4 + ' and a.Booking_type ='''+@booktype+''''
END 

IF(@contractname  IS NOT NULL and @contractname  <>'')
begin
set @query4=@query4 + ' and a.Contract_name ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment  <>'')
begin
set @query4=@query4 + ' and tbl_booking_insert.Supp_Code ='''+@suppliment+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype  <>'')
begin
set @query4=@query4 + ' and a.Rate_code ='''+@ratetype+''''
END 

IF(@city  IS NOT NULL and @city  <>'')
begin
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

IF(@zone  IS NOT NULL and @zone  <>'')
begin
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

IF(@district  IS NOT NULL and @district  <>'')
begin
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

IF(@state  IS NOT NULL and @state  <>'')
begin
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

IF(@taluka  IS NOT NULL and @taluka  <>'')
begin
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
print(@query1+@query4)
exec(@query1+@query4)



--print(@query1)
--exec(@query1)
end 

else if(@adcheck=2)begin
open c2
fetch next from c2
into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME

print(@@FETCH_STATUS)
while @@FETCH_STATUS=0

begin

insert into #temp_ad_bills_report select * from dbo.FUN_BILL_INSERT(@compcode,@v2_CIOID,@v2_BILLNO,@prefer,@dateformat,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME,@base )  

fetch next from c2
into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME

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
from #temp_ad_bills_report where'

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL )
begin
set @query4= '  BILLDATE between  '''+@fromdate +''' and  '''+@dateto+''' '
END 

IF(@publication IS NOT NULL and @publication<>'')
begin
set @query4=@query4+ ' and PRIPUB='''+@publication+''''
END 

IF(@pub_cent IS NOT NULL and @pub_cent<>'')
begin
set @query4=@query4+ '   and PUB_CENT_CODE='''+@pub_cent+''''
END 

IF(@edition IS NOT NULL and @edition<>'')
begin
set @query4=@query4+ '  and PEDITION='''+@edition+''''
END 

IF(@branch IS NOT NULL and @branch<>'')
begin
set @query4=@query4+ '  and  BRANCH_NAME ='''+@branch+''' '
END 

IF(@region IS NOT NULL and @region<>'')
begin
set @query4=@query4 +' and REGION='''+@region +''''
END 

IF(@adtype IS NOT NULL and @adtype<>'')
begin
set @query4=@query4 + ' and PADTYPE='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype<>'')
begin
set @query4=@query4 + ' and AGENCY_TYPE_CODE= '''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat<>'')
begin
set @query4=@query4 + ' and PRIADCTG='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat<>'')
begin
set @query4=@query4 + ' and SECADCTG ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3<>'')
begin
set @query4=@query4 + ' and AD_SUBCAT3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4<>'')
begin
set @query4=@query4 + ' and AD_SUBCAT4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5<>'')
begin
set @query4=@query4 + ' and AD_SUBCAT5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package<>'')
begin
set @query4=@query4 + ' and PACKAGE_CODE='''+@package+''''
END 

IF(@agency IS NOT NULL and @agency<>'')
begin
set @query4=@query4 + ' and AG_MAIN_CODE ='''+@agency +''''
END 

IF(@client IS NOT NULL and @client<>'')
begin
set @query4=@query4 + ' and CLIENTCD='''+@client +''''
END 

IF(@executive IS NOT NULL and @executive<>'')
begin
set @query4=@query4 + ' and EXECUTIVE_NAME='''+@executive+''''
END 

IF(@product IS NOT NULL and @product<>'')
begin
set @query4=@query4 + ' and PRIPROCTG='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand<>'')
begin
set @query4=@query4 + ' and BRAND_CODE='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient<>'')
begin
set @query4=@query4 + ' and   VARIENT_NAME='''+@varient+''''
END 

IF(@pageprem IS NOT NULL and @pageprem<>'')
begin
set @query4=@query4 + ' and PAGE_PREM ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem<>'')
begin
set @query4=@query4 + ' and PAGE_POST ='''+@postprem+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'')
begin
set @query4=@query4 + ' and CONTRACT_NAME ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment<>'')
begin
set @query4=@query4 + ' and SUPP_CODE='''+@suppliment+''''
END 

IF(@retainer IS NOT NULL and @retainer<>'')
begin
set @query4=@query4 + ' and RETAINER_CODE='''+@retainer+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype<>'')
begin
set @query4=@query4 + ' and RATECD ='''+@ratetype+''''
END 

IF(@scheme IS NOT NULL and @scheme<>'')
begin
set @query4=@query4 + ' and PSCHEME='''+@scheme+''''
END 

IF(@revcenter IS NOT NULL and @revcenter<>'')
begin
set @query4=@query4 +' and REVENUE_CENTER='''+@revcenter+''''
END 

IF(@rostatus IS NOT NULL and @rostatus<>'')
begin
set @query4=@query4 + ' and RO_STATUS='''+@rostatus+''''
END 

IF(@pagetype IS NOT NULL and @pagetype<>'')
begin
set @query4=@query4 + ' and PAGE_TYPE ='''+@pagetype+''''
END 

IF(@booktype IS NOT NULL and @booktype<>'')
begin
set @query4=@query4 + ' and BOOKING_TYPE='''+@booktype+''''
END 

IF(@city  IS NOT NULL and @city<>'')
begin
set @query4=@query4 + ' and CITY_CODE ='''+@city+''''
END 

IF(@zone  IS NOT NULL and @zone<>'')
begin
set @query4=@query4 + ' and ZONE_CODE ='''+@zone+''''
end 

IF(@district  IS NOT NULL and @district<>'')
begin
set @query4=@query4 + ' and DIST_CODE ='''+@district+''''
end 

IF(@state  IS NOT NULL and @state<>'')
begin
set @query4=@query4 + ' and STATE_CODE ='''+@state+''''
end 

IF(@taluka  IS NOT NULL and @taluka<>'')
begin
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
dbo.FETCH_PACK(tbl_booking_mast.cio_booking_id) AS Package,
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
isnull((  isnull(TBL_BOOKING_INSERT.Bill_Amt,''0'')-isnull(dbo.fun_actual('''+ @compcode +''',isnull(tbl_booking_mast.ADD_AGENCY_COMM,''0'' ),isnull(tbl_booking_mast.RETAINER,''0''),isnull(tbl_booking_insert.Gross_Rate,''0''),'''+@prefer+''',''2'' ),''0'')  ),''0'') as ActualBusiness,
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
tbl_booking_insert.Page_No as "Page_No"
,CASHDISCOUNT as "Cash_Disc"
,Insert_Status as "Status"
,Box_code as "BoxCode"
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

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL)
begin
set @query4=@query4+' and tbl_booking_insert.Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
END

if(@base='2')begin
set @query4=@query4 +' and (tbl_booking_mast.Executive_code is not null and tbl_booking_mast.Executive_code !=''0'')  '
end 

if(@base='3')begin

 
set @query4=@query4 +' and (tbl_booking_mast.retainer IS NOT NULL and retainer <>''''  and tbl_booking_mast.RETAINER !=''0'')  '

end 


if(@drpstatus is null or  @drpstatus = '') begin
set @query4=@query4+' and lower(Insert_Status)!=''cancel'''
end 

if(@insertstatus is not null and @insertstatus<>'' ) begin
set @query4=@query4+' and lower(Insert_Status)='''+@insertstatus+''''
end 





IF(@publication IS NOT NULL)
begin
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

IF(@pub_cent IS NOT NULL)
begin
set @query4=@query4+'  and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
END 


IF(@branch IS NOT NULL  and @branch<>'')
begin
set @query4=@query4+'  and TBL_BOOKING_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
END 


IF(@edition IS NOT NULL and @edition<>'')
begin
set @query4=@query4 +'  and tbl_booking_insert.Edition_Code='''+@edition+''''
END 



IF(@region IS NOT NULL and @region <>'')
begin
--set @query4=@query4  +' and tbl_booking_insert.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+@region +''')'
set @query4=@query4  +' and agency_mast.region ='''+@region+''''

END 

IF(@revcenter IS NOT NULL and @revcenter <>'')
begin
set @query4=@query4  +' and tbl_booking_mast.Revenue_center ='''+@revcenter+''''
END 

IF(@adtype IS NOT NULL and @adtype <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_type_code='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Agency_type ='''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_insert.Ad_Cat ='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_sub_cat_code ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_Subcat3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_Subcat4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Ad_subcat5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Package_code ='''+@package+''''
END 

IF(@scheme IS NOT NULL and @scheme <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Scheme_type_code ='''+@scheme+''''
END 

IF(@agency IS NOT NULL and @agency <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Agency_code ='''+@agency+''''
END 

IF(@client IS NOT NULL and @client  <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Client_code ='''+@client+''''
END 

IF(@executive IS NOT NULL and @executive <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Executive_code ='''+@executive+''''
END 

IF(@retainer IS NOT NULL and @retainer <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.RETAINER ='''+@retainer+''''
END 

IF(@product IS NOT NULL and @product <>'')
begin
set @query4=@query4 + ' and TBL_BOOKING_MAST.Product_code ='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Brand_code ='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Variant_code ='''+@varient+''''
END 

IF(@pagetype IS NOT NULL and @pagetype <>'')
begin
set @query4=@query4  + ' and TBL_BOOKING_MAST.Page_type_code ='''+@pagetype+''''
END 

IF(@pageprem IS NOT NULL and @pageprem <>'')
begin
set @query4=@query4 + ' and TBL_BOOKING_insert.Premium1 ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem <>'')
begin
set @query4=@query4 + ' and TBL_BOOKING_insert.Page_Post ='''+@postprem+''''
END 

IF(@rostatus IS NOT NULL and @rostatus <>'')
begin
set @query4=@query4 + ' and TBL_BOOKING_MAST.ro_status ='''+@rostatus+''''
END 

IF(@booktype IS NOT NULL and @booktype <>'')
begin
set @query4=@query4 + ' and TBL_BOOKING_MAST.Booking_type ='''+@booktype+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'')
begin
set @query4=@query4 + ' and TBL_BOOKING_MAST.Contract_name ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment  <>'')
begin
set @query4=@query4 + ' and tbl_booking_insert.Supp_Code ='''+@suppliment+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype  <>'')
begin
set @query4=@query4 + ' and tbl_booking_MAST.Rate_code ='''+@ratetype+''''
END 

IF(@city  IS NOT NULL and @city  <>'')
begin
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

IF(@zone  IS NOT NULL and @zone  <>'')
begin
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

IF(@district  IS NOT NULL and @district  <>'')
begin
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

IF(@state  IS NOT NULL and @state  <>'')
begin
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

IF(@taluka  IS NOT NULL and @taluka  <>'')
begin
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

print(@query3+@query4)
exec(@query3+@query4)

end end

else

if(@adcheck=1)
begin
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
sum(isnull((a.Bill_amount-isnull(dbo.fun_actual('''+@compcode+''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(a.Gross_amount,''0''),'''+@prefer+''',''2'' ),''0'')  ),''0'') )as ActualBusiness
FROM TBL_BOOKING_MAST a,
agency_mast
WHERE a.Comp_code='''+@compcode+''' AND
a.Agency_sub_code=AGENCY_MAST.code_subcode' 
if(@query4='' or @query4 is null) begin

		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' )
		begin
		set @query4=' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 


		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' )
		begin
		set @query4=' and a.Insertion_date  between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 

end
else
begin 

      IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Booking Date' )
		begin
		set @query4=@query4+' and a.date_time between  '''+@fromdate +''' and  '''+@dateto+''' '
		END 


		IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL and @filterby='Publish Date' )
		begin
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


if(@drpstatus is null or  @drpstatus = '') begin
set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where a.cio_booking_id=b.Cio_Booking_Id AND lower(Insert_Status)!='''+'cancel'+''' )'
end 

if(@insertstatus is not null and @insertstatus<>'') begin
set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where a.cio_booking_id=b.Cio_Booking_Id AND lower(Insert_Status)='''+@insertstatus+''' )';
end 




IF(@publication IS NOT NULL)
begin
set @query4=@query4+'  and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.publication_Code='''+@publication+''' )    '
END 

/*
IF(@pub_cent IS NOT NULL and @pub_cent <>'')
begin
--set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Pub_Cent_Code='''+@pub_cent+''' )  '
set @query4=@query4+'  and a.branch IN (SELECT Branch_Name FROM BRANCH_MST WHERE a.branch=Branch_Name and pub_center in (SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE  branch_mst.pub_center=pub_cent_mast.Pub_cent_Code and Pub_cent_Code='''+@pub_cent+'''))'

END 
IF(@branch IS NOT NULL and @branch<>'')
begin
set @query4=@query4+' and a.branch ='''+@branch+''''
END 
*/



IF(@pub_cent IS NOT NULL)
begin
set @query4=@query4+'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
END 


IF(@branch IS NOT NULL  and @branch<>'')
begin
set @query4=@query4+'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
END 


IF(@edition IS NOT NULL and @edition<>'')
begin

set @query4=@query4+' and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Edition_Code='''+@edition+''' )'
END 



IF(@region IS NOT NULL and @region <>'')
begin
--set @query4=@query4 +'  and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+@region +''') )'
set @query4=@query4 +'  and agency_mast.region ='''+@region+''''
END 

IF(@suppliment  IS NOT NULL and @suppliment  <>'')
begin
set @query4=@query4 + '  and a.cio_booking_id  in (select distinct b.Cio_Booking_Id from tbl_booking_insert b where b.Supp_Code ='''+@suppliment+''' )'
END 







IF(@revcenter IS NOT NULL and @revcenter <>'')
begin
set @query4=@query4 +' and a.Revenue_center ='''+@revcenter+''''
END 

IF(@adtype IS NOT NULL and @adtype <>'')
begin
set @query4=@query4 + ' and a.Ad_type_code='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype <>'')
begin
set @query4=@query4 + ' and a.Agency_type ='''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat <>'')
begin
set @query4=@query4 + ' and a.Ad_cat_code ='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat <>'')
begin
set @query4=@query4 + ' and a.Ad_sub_cat_code ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'')
begin
set @query4=@query4 + ' and a.Ad_Subcat3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'')
begin
set @query4=@query4 + ' and a.Ad_Subcat4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'')
begin
set @query4=@query4 + ' and a.Ad_subcat5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package <>'')
begin
set @query4=@query4 + ' and a.Package_code ='''+@package+''''
END 

IF(@scheme IS NOT NULL and @scheme <>'')
begin
set @query4=@query4 + ' and a.Scheme_type_code ='''+@scheme+''''
END 

IF(@agency IS NOT NULL and @agency <>'')
begin
set @query4=@query4 + ' and a.Agency_code ='''+@agency+''''
END 

IF(@client IS NOT NULL and @client  <>'')
begin
set @query4=@query4 + ' and a.Client_code ='''+@client+''''
END 

IF(@executive IS NOT NULL and @executive <>'')
begin
set @query4=@query4 + ' and a.Executive_code ='''+@executive+''''
END 

IF(@retainer IS NOT NULL and @retainer <>'')
begin
set @query4=@query4 + ' and a.RETAINER ='''+@retainer+''''
END 

IF(@product IS NOT NULL and @product <>'')
begin
set @query4=@query4 + ' and a.Product_code ='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand <>'')
begin
set @query4=@query4 + ' and a.Brand_code ='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient <>'')
begin
set @query4=@query4 + ' and a.Variant_code ='''+@varient+''''
END 

IF(@pagetype IS NOT NULL and @pagetype <>'')
begin
set @query4=@query4 + ' and a.Page_type_code ='''+@pagetype+''''
END 

IF(@pageprem IS NOT NULL and @pageprem <>'')
begin
set @query4=@query4 + ' and a.Page_prem ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem <>'')
begin
set @query4=@query4 + ' and a.Page_position_code ='''+@postprem+''''
END 

IF(@rostatus IS NOT NULL and @rostatus <>'')
begin
set @query4=@query4 + ' and a.ro_status ='''+@rostatus+''''
END 

IF(@booktype IS NOT NULL and @booktype <>'')
begin
set @query4=@query4 + ' and a.Booking_type ='''+@booktype+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'')
begin
set @query4=@query4 + ' and a.Contract_name ='''+@contractname +''''
END 



IF(@ratetype  IS NOT NULL and @ratetype  <>'')
begin
set @query4=@query4 + ' and a.Rate_code ='''+@ratetype+''''
END 

IF(@city  IS NOT NULL and @city  <>'')
begin
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

IF(@zone  IS NOT NULL and @zone  <>'')
begin
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

IF(@district  IS NOT NULL and @district  <>'')
begin
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

IF(@state  IS NOT NULL and @state  <>'')
begin
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

IF(@taluka  IS NOT NULL and @taluka  <>'')
begin
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
fetch next from c2
into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME
while @@FETCH_STATUS=0
begin
insert into #temp_ad_bills_report select * from dbo.FUN_BILL_INSERT(@compcode,@v2_CIOID,@v2_BILLNO,@prefer,@dateformat,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME,@base )  
fetch next from c2
into @v2_CIOID,@v2_BILLNO,@v2_AGMAINCODE,@v2_AG_SUB_CODE,@v2_AGCODE,@v2_AGNAME,@v2_EXECCODE,@v2_EXECNAME,@v2_RETCODE,@v2_RETNAME

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



IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL )
begin
set @query4= '  BILLDATE between  '''+@fromdate +''' and  '''+@dateto+''' '
END 

IF(@publication IS NOT NULL and @publication<>'')
begin
set @query4=@query4+ ' and PRIPUB='''+@publication+''''
END 

IF(@pub_cent IS NOT NULL and @pub_cent<>'')
begin
set @query4=@query4+ '   and PUB_CENT_CODE='''+@pub_cent+''''
END 

IF(@edition IS NOT NULL and @edition<>'')
begin
set @query4=@query4+ '  and PEDITION='''+@edition+''''
END 

IF(@branch IS NOT NULL and @branch<>'')
begin
set @query4=@query4+ '  and  BRANCH_NAME ='''+@branch+''' '
END 

IF(@region IS NOT NULL and @region<>'')
begin
set @query4=@query4 +' and REGION='''+@region +''''
END 

IF(@adtype IS NOT NULL and @adtype<>'')
begin
set @query4=@query4 + ' and PADTYPE='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype<>'')
begin
set @query4=@query4 + ' and AGENCY_TYPE_CODE= '''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat<>'')
begin
set @query4=@query4 + ' and PRIADCTG='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat<>'')
begin
set @query4=@query4 + ' and SECADCTG ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3<>'')
begin
set @query4=@query4 + ' and AD_SUBCAT3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4<>'')
begin
set @query4=@query4 + ' and AD_SUBCAT4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5<>'')
begin
set @query4=@query4 + ' and AD_SUBCAT5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package<>'')
begin
set @query4=@query4 + ' and PACKAGE_CODE='''+@package+''''
END 

IF(@agency IS NOT NULL and @agency<>'')
begin
set @query4=@query4 + ' and AG_MAIN_CODE ='''+@agency +''''
END 

IF(@client IS NOT NULL and @client<>'')
begin
set @query4=@query4 + ' and CLIENTCD='''+@client +''''
END 

IF(@executive IS NOT NULL and @executive<>'')
begin
set @query4=@query4 + ' and EXECUTIVE_NAME='''+@executive+''''
END 

IF(@product IS NOT NULL and @product<>'')
begin
set @query4=@query4 + ' and PRIPROCTG='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand<>'')
begin
set @query4=@query4 + ' and BRAND_CODE='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient<>'')
begin
set @query4=@query4 + ' and   VARIENT_NAME='''+@varient+''''
END 

IF(@pageprem IS NOT NULL and @pageprem<>'')
begin
set @query4=@query4 + ' and PAGE_PREM ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem<>'')
begin
set @query4=@query4 + ' and PAGE_POST ='''+@postprem+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'')
begin
set @query4=@query4 + ' and CONTRACT_NAME ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment<>'')
begin
set @query4=@query4 + ' and SUPP_CODE='''+@suppliment+''''
END 

IF(@retainer IS NOT NULL and @retainer<>'')
begin
set @query4=@query4 + ' and RETAINER_CODE='''+@retainer+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype<>'')
begin
set @query4=@query4 + ' and RATECD ='''+@ratetype+''''
END 

IF(@scheme IS NOT NULL and @scheme<>'')
begin
set @query4=@query4 + ' and PSCHEME='''+@scheme+''''
END 

IF(@revcenter IS NOT NULL and @revcenter<>'')
begin
set @query4=@query4 +' and REVENUE_CENTER='''+@revcenter+''''
END 

IF(@rostatus IS NOT NULL and @rostatus<>'')
begin
set @query4=@query4 + ' and RO_STATUS='''+@rostatus+''''
END 

IF(@pagetype IS NOT NULL and @pagetype<>'')
begin
set @query4=@query4 + ' and PAGE_TYPE ='''+@pagetype+''''
END 

IF(@booktype IS NOT NULL and @booktype<>'')
begin
set @query4=@query4 + ' and BOOKING_TYPE='''+@booktype+''''
END 

IF(@city  IS NOT NULL and @city<>'')
begin
set @query4=@query4 + ' and CITY_CODE ='''+@city+''''
END 

IF(@zone  IS NOT NULL and @zone<>'')
begin
set @query4=@query4 + ' and ZONE_CODE ='''+@zone+''''
end 

IF(@district  IS NOT NULL and @district<>'')
begin
set @query4=@query4 + ' and DIST_CODE ='''+@district+''''
end 

IF(@state  IS NOT NULL and @state<>'')
begin
set @query4=@query4 + ' and STATE_CODE ='''+@state+''''
end 

IF(@taluka  IS NOT NULL and @taluka<>'')
begin
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
ROUND(sum(isnull((  isnull(b.Bill_Amt,''0'')-isnull(dbo.fun_actual('''+ @compcode +''',isnull(a.ADD_AGENCY_COMM,''0'' ),isnull(a.RETAINER,''0''),isnull(b.Gross_Rate,''0''),'''+@prefer+''',''2'' ),''0'')  ),''0'')),2) as ActualBusiness
FROM TBL_BOOKING_MAST a,AGENCY_MAST ,
TBL_BOOKING_insert b
WHERE a.Comp_code='''+@compcode+''' AND
a.Agency_sub_code=AGENCY_MAST.code_subcode AND
a.cio_booking_id=b.Cio_Booking_Id '
--and ((b.Pub_Cent_Code in (select distinct pub_center from login_center where newuser_id='''+@puserid+''') and '''+@chk_access+'''=''1'')
--or  ('''+@chk_access+'''=''0'') )' 

IF(@fromdate IS NOT NULL AND @dateto IS NOT NULL)
begin
set @query4=' and b.Insert_Date between  '''+@fromdate +''' and  '''+@dateto+''' '
END 

if(@base='2')begin
set @query4=@query4 +' and (a.Executive_code is not null and a.Executive_code !=''0'')  '
end 

if(@base='3')begin
set @query4=@query4 +' and (a.retainer IS NOT NULL and retainer <>''  and a.RETAINER !=''0'')  '
end 


if(@drpstatus is null or  @drpstatus = '') begin
set @query4=@query4+' and lower(Insert_Status)!='''+'cancel'+''''
end 

if(@insertstatus is not null and @insertstatus<>'' ) begin
set @query4=@query4+' and lower(Insert_Status)='''+@insertstatus+''''
end 





IF(@publication IS NOT NULL)
begin
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
END 
*/

IF(@pub_cent IS NOT NULL)
begin
set @query4=@query4+'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@pub_cent+'''))'
END 


IF(@branch IS NOT NULL  and @branch<>'')
begin
set @query4=@query4+'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''+@branch+''') ';
END 

IF(@edition IS NOT NULL and @edition<>'')
begin
set @query4=@query4 +'  and b.Edition_Code='''+@edition+''''
END 



IF(@region IS NOT NULL and @region <>'')
begin
--set @query4=@query4  +' and b.Pub_Cent_Code in(select pub_cent_mast.Pub_cent_Code from pub_cent_mast where pub_cent_mast.Region_code ='''+@region +''')'
set @query4=@query4  +' and agency_mast.region ='''+@region+''''

END 

IF(@revcenter IS NOT NULL and @revcenter <>'')
begin
set @query4=@query4  +' and a.Revenue_center ='''+@revcenter+''''
END 

IF(@adtype IS NOT NULL and @adtype <>'')
begin
set @query4=@query4  + ' and a.Ad_type_code='''+@adtype+''''
END 

IF(@agencytype IS NOT NULL and @agencytype <>'')
begin
set @query4=@query4  + ' and a.Agency_type ='''+@agencytype+''''
END 

IF(@adcat IS NOT NULL and @adcat <>'')
begin
set @query4=@query4  + ' and b.Ad_Cat ='''+@adcat+''''
END 

IF(@adsubcat IS NOT NULL and @adsubcat <>'')
begin
set @query4=@query4  + ' and a.Ad_sub_cat_code ='''+@adsubcat+''''
END 

IF(@adsubcat3 IS NOT NULL and @adsubcat3 <>'')
begin
set @query4=@query4  + ' and a.Ad_Subcat3 ='''+@adsubcat3+''''
END 

IF(@adsubcat4 IS NOT NULL and @adsubcat4 <>'')
begin
set @query4=@query4  + ' and a.Ad_Subcat4 ='''+@adsubcat4+''''
END 

IF(@adsubcat5 IS NOT NULL and @adsubcat5 <>'')
begin
set @query4=@query4  + ' and a.Ad_subcat5 ='''+@adsubcat5+''''
END 

IF(@package IS NOT NULL and @package <>'')
begin
set @query4=@query4  + ' and a.Package_code ='''+@package+''''
END 

IF(@scheme IS NOT NULL and @scheme <>'')
begin
set @query4=@query4  + ' and a.Scheme_type_code ='''+@scheme+''''
END 

IF(@agency IS NOT NULL and @agency <>'')
begin
set @query4=@query4  + ' and a.Agency_code ='''+@agency+''''
END 

IF(@client IS NOT NULL and @client  <>'')
begin
set @query4=@query4  + ' and a.Client_code ='''+@client+''''
END 

IF(@executive IS NOT NULL and @executive <>'')
begin
set @query4=@query4  + ' and a.Executive_code ='''+@executive+''''
END 

IF(@retainer IS NOT NULL and @retainer <>'')
begin
set @query4=@query4  + ' and a.RETAINER ='''+@retainer+''''
END 

IF(@product IS NOT NULL and @product <>'')
begin
set @query4=@query4 + ' and a.Product_code ='''+@product+''''
END 

IF(@brand IS NOT NULL and @brand <>'')
begin
set @query4=@query4  + ' and a.Brand_code ='''+@brand+''''
END 

IF(@varient IS NOT NULL and @varient <>'')
begin
set @query4=@query4  + ' and a.Variant_code ='''+@varient+''''
END 

IF(@pagetype IS NOT NULL and @pagetype <>'')
begin
set @query4=@query4  + ' and a.Page_type_code ='''+@pagetype+''''
END 

IF(@pageprem IS NOT NULL and @pageprem <>'')
begin
set @query4=@query4 + ' and b.Premium1 ='''+@pageprem+''''
END 

IF(@postprem IS NOT NULL and @postprem <>'')
begin
set @query4=@query4 + ' and b.Page_Post ='''+@postprem+''''
END 

IF(@rostatus IS NOT NULL and @rostatus <>'')
begin
set @query4=@query4 + ' and a.ro_status ='''+@rostatus+''''
END 

IF(@booktype IS NOT NULL and @booktype <>'')
begin
set @query4=@query4 + ' and a.Booking_type ='''+@booktype+''''
END 

IF(@contractname  IS NOT NULL and @contractname<>'')
begin
set @query4=@query4 + ' and a.Contract_name ='''+@contractname +''''
END 

IF(@suppliment  IS NOT NULL and @suppliment  <>'')
begin
set @query4=@query4 + ' and b.Supp_Code ='''+@suppliment+''''
END 

IF(@ratetype  IS NOT NULL and @ratetype  <>'')
begin
set @query4=@query4 + ' and a.Rate_code ='''+@ratetype+''''
END 

IF(@city  IS NOT NULL and @city  <>'')
begin
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

IF(@zone  IS NOT NULL and @zone  <>'')
begin
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

IF(@district  IS NOT NULL and @district  <>'')
begin
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

IF(@state  IS NOT NULL and @state  <>'')
begin
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

IF(@taluka  IS NOT NULL and @taluka  <>'')
begin
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
drop table #MULTIPACK_RATNEW



*/


///////////////////////////////////////////////////end of procedure 4785,4887///////////////////////////////////////////////

/***************************Kuldeep Bhati 13/10/2011***0004884   ****************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go







ALTER  PROCEDURE [dbo].[websp_loginemployee]
@username varchar(50),
@password varchar(10),
@qbc varchar(8)=null

AS
declare @query as varchar(900)
declare @count as varchar(100)
declare @query1 as varchar(900)
declare @query2 as varchar(1000)
declare @userid varchar(100)

if(@qbc=null or @qbc='')
begin
set @query='select username,password,userid,date_format,com_code,autogenerate,curr_code  ,comp_name, datediff(dd,creation_datetime,getdate()) as diff,DISCOUNT,FILTER,ROLEID,retainer_code AS RETAINER          from login where userid='''+@username+''' and password='''+@password+''' and STATUS ! = ''I'''

select @count=com_code from login where userid=@username and password=@password
/*new change ankur for agency*/
set @query1='SELECT rate_gr_code,autogenerated,currency_code,date_format,solo,No_of_Decimal,
        breakup,blackwhitecode,uom_code,rostatus,Tfn,Insert_breakup,Premium_type,Deal_type     ,
        prefix,suffix,financestatus,voucherst,Ad_category,Ro_datetime,Space_area,Vat,Booking_status,Cio_id,Receipt_no,Bgcolor_publication, chkfor_valid_pubdates,Agency_ratecode,audit,copy_booking,RATE_COMPANY_AGENCY,SUBEDITIONRATE,ADDITIONAL_AGENCY_COMM,AGENCY_RETAINER_COMM,

        invoice_no,rate_audit,CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT, RATE_CHECK, ALL_PACKAGE,DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,ROKEYCHECK,
		DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF,FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,DISP_AUDITBKG

  from preferrences where comp_code= '''+@count+'''' 
select @userid=userid from login where username=@username and  password=@password  and com_code=@count

set @query2='select company_user,Admin from login where userid='''+@username+''''

end
else
begin
set @query='select username,password,userid,date_format,com_code,autogenerate,curr_code  ,comp_name  , datediff(dd,creation_datetime,getdate()) as diff,DISCOUNT,FILTER ,ROLEID ,retainer_code   AS RETAINER     from login where userid='''+@username+''' and password='''+@password+''' and retainer_code='''+@qbc+''' and STATUS ! = ''I'''

select @count=com_code from login where userid=@username and password=@password and retainer_code=@qbc

/*new change ankur for agency*/
set @query1='SELECT rate_gr_code,autogenerated,currency_code,date_format,solo,No_of_Decimal,
        breakup,blackwhitecode,uom_code,rostatus,Tfn,Insert_breakup,Premium_type,Deal_type     ,
        prefix,suffix,financestatus,voucherst,Ad_category,Ro_datetime,Space_area,Vat,Booking_status,Cio_id,Receipt_no,Bgcolor_publication, chkfor_valid_pubdates,Agency_ratecode,audit,copy_booking,RATE_COMPANY_AGENCY,SUBEDITIONRATE,ADDITIONAL_AGENCY_COMM,AGENCY_RETAINER_COMM,

        invoice_no,rate_audit,CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT, RATE_CHECK, ALL_PACKAGE,DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,ROKEYCHECK,
		DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF,FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,DISP_AUDITBKG from preferrences where comp_code= '''+@count+''''

select @userid=userid from login where username=@username and  password=@password  and com_code=@count

set @query2='select company_user,Admin from login where userid='''+@username+''''
end


print(@query)
exec(@query)

print(@query1)
exec(@query1)


print(@query2)
exec(@query2)
========================================================================================================
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




ALTER PROCEDURE  [dbo].[loginModify]

@username as varchar(50),
@password as varchar(20),
@userid as varchar(10),
@date_format as varchar(50),
@comp_name as varchar(50),
@com_code as varchar(10),
@curr_code as varchar(8),
@retainer_code as varchar(8),
@agencycode as varchar(50),
@user as varchar(50),
@admin as varchar(50),
@comp_user as varchar(20),
@companylist as varchar(25),
@emailid as varchar(50),
@disc as varchar(20),
@fil as varchar(8),
@role as varchar(8),
@editlines as varchar(1),
@firstname  as VARCHAR(20),
@lastname   as VARCHAR(20),
@pstatus    AS VARCHAR(20)



AS

update login set FIRSTNAME=@firstname,LASTNAME =@lastname,username=@username, password=@password, date_format=@date_format, comp_name=@comp_name, com_code=@com_code, curr_code=@curr_code, 
retainer_code=@retainer_code,Agency_code=@agencycode,user_status=@user,Admin=@admin,Company_user=@comp_user ,
 BOOKING_EDITLINES=@editlines, ROLEID=@role,FILTER=@fil, DISCOUNT=@disc, USER_COMPANY=@companylist,EMAIL=@emailid,STATUS=@pstatus where userid=@userid

DELETE FROM MODULE_DETAIBUTTONL WHERE MODULE_DETAIBUTTONL.userid=@userid

INSERT INTO MODULE_DETAIBUTTONL
           ([Button_id]
           ,[Form_Name]
           ,[comp_code]
           ,[userid]
           ,[Module_No]
           ,[Form_id]
           ,[Paid_permission]
           ,[Backdate_booking]
           ,[Ro_date_perm]
           ,[Confirm_qbc])
            SELECT BUTTONID, FORM_NAME,COMPCODE,@userid,'',FORM_ID,'','','',''  FROM ROLE_PERMISSION WHERE ROLEID=@role;

=========================================================================================================================
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go







ALTER PROCEDURE [dbo].[loginInsert]
@username as varchar(50),
@password as varchar(20),
@userid as varchar(10),
@date_format as varchar(50),
@comp_name as varchar(50),
@com_code as varchar(10),
@curr_code as varchar(8),
@retainer_code as varchar(8),
@agencycode as varchar(50),
@user as  varchar(50),
@admin as varchar(50),
@comp_user as varchar(20),
@compnamelist as varchar(25),
@emailid  as varchar(50),
@discount as varchar(20),
@filter as varchar(50),
@rolename as varchar(20),
@editlines as varchar(50),
@firstname  as VARCHAR(20),
@lastname   as VARCHAR(20),
@pstatus    AS VARCHAR(20)
AS

insert into login(username,   password,   userid,   date_format,    comp_name,com_code, curr_code, retainer_code, Agency_code,user_status,Admin,Company_user,USER_COMPANY,EMAIL ,DISCOUNT,FILTER,ROLEID,BOOKING_EDITLINES,FIRSTNAME,LASTNAME,STATUS)
values(@username,@password,@userid,@date_format,@comp_name,@com_code,@curr_code,@retainer_code,@agencycode,@user,@admin,@comp_user ,@compnamelist,@emailid,@discount,@filter,@rolename,@editlines,@firstname,@lastname,@pstatus)


 DELETE FROM MODULE_DETAIBUTTONL WHERE MODULE_DETAIBUTTONL.userid=@userid

 INSERT INTO MODULE_DETAIBUTTONL SELECT BUTTONID, FORM_NAME,COMPCODE,@userid,'',FORM_ID,'','','','','0',''  FROM ROLE_PERMISSION WHERE ROLEID=@rolename

=================================================================================================================
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





ALTER PROCEDURE [dbo].[loginexecute]

@username as varchar(50),
@userid as varchar(10),
@com_code as varchar(10),
@admin as varchar(8)

AS

declare @query  as   varchar(1000)



	if(@admin='')
		set @query='select * from login where   admin!=''yes'''  --username='''+@username+''''
	else
		set @query='select * from login where admin=''yes'''

if(@com_code<>''  and @com_code <>'0')
begin
	set @query= @query + ' and com_code= '''+@com_code+''''
end

if(@username<>'')
begin
	set @query= @query + ' and username like ''%'+@username+'%'''
end

if(@userid<>'')
begin
	set @query= @query + ' and userid = '''+@userid+''''
end



print(@query)
exec(@query)


============================================================================================================
                                                                     
                                                                     
                                                                     
                                             
ALTER PROCEDURE FA_RPT_accountmast1_FA_RPT_accountmast1_p
	@pcompcode                                VARCHAR(4000) ,
	@pmaingrpcode                             VARCHAR(4000) ,
	@pprmgrpcode                              VARCHAR(4000) ,
	@psecgrpcode                              VARCHAR(4000) ,
	@pthirdgrpcode                            VARCHAR(4000) --,
AS 
	BEGIN
		SELECT
				 MAIN_GROUP as "MAIN_GRP_CODE",
				( SELECT main_group_name FROM  fa_group_mast WHERE	 comp_code  =  @pcompcode
		         AND	main_group  = FA_ACC_MAST.MAIN_GROUP )as "MAIN_GRP_NAME",
				 PSUB_GROUP as "PSUB_GRP_CODE",(SELECT  psub_group_name
		FROM  fa_psub_group_mast 
		WHERE	 comp_code  = @pcompcode
		 AND	main_group_code  = FA_ACC_MAST.MAIN_GROUP
		 AND	psub_group_code  = FA_ACC_MAST.PSUB_GROUP)as "PSUB_GRP_CODE",
				 SSUB_GROUP as "SSUB_GRP_CODE",
				(SELECT ssub_group_name
		FROM  fa_ssub_group_mast 
		WHERE	 comp_code  =  @pcompcode
		 AND	main_group_code  = FA_ACC_MAST.MAIN_GROUP
		 AND	psub_group_code  = FA_ACC_MAST.PSUB_GROUp
		 AND	ssub_group_code  = FA_ACC_MAST.SSUB_GROUP)as "SSUB_GRP_NAME",
				  TSUB_GROUP as "TSUB_GRP_CODE",
	(SELECT tsub_group_name
	FROM  fa_tsub_group_mast 
		WHERE	 comp_code  =  @pcompcode
		 AND	main_group_code  = FA_ACC_MAST.MAIN_GROUP
		 AND	psub_group_code  = FA_ACC_MAST.PSUB_GROUP
		 AND	ssub_group_code  = FA_ACC_MAST.SSUB_GROUP
		 AND	tsub_group_code  = FA_ACC_MAST.TSUB_GROUP)as "TSUB_GRP_NAME",ACC_TY as "ACC_TYPE_CODE",
			(SELECT AC_TYPE_DESC
				FROM  FA_ACCOUNT_TYPE_MAST 
				WHERE FA_ACCOUNT_TYPE_MAST.COMP_CODE=FA_ACC_MAST.COMP_CODE AND FA_ACCOUNT_TYPE_MAST.AC_TYPE_CODE  = FA_ACC_MAST.ACC_TY
		) as "ACC_TYPE_NAME", CDP,ACC_NAME,ACC_NATURE
		FROM  FA_ACC_MAST 
		WHERE	 (COMP_CODE  = @pcompcode)
		 AND	(MAIN_GROUP  = @pmaingrpcode OR	@pmaingrpcode  IS NULL)
		 AND	(PSUB_GROUP  = @pprmgrpcode OR	@pprmgrpcode  IS NULL)
		 AND	(SSUB_GROUP  = @psecgrpcode OR	@psecgrpcode  IS NULL)
		 AND	(TSUB_GROUP  = @pthirdgrpcode OR	@pthirdgrpcode  IS NULL)
		ORDER BY MAIN_GROUP,PSUB_GROUP,SSUB_GROUP,TSUB_GROUP,CDP 

END


/***************************Kuldeep Bhati 13/10/2011******0004884  ************************/


/****************start***********Mimoh mahajan 14/10/2011******0005264 ************************/
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER  PROCEDURE [dbo].[ADD_CHKEDITCODE]
(
@pcompcode  as varchar(10),
@pedit_code  as varchar(10),
@pextra  as varchar(50)
)
as
BEGIN
Select * from EDITION_MAST where Comp_Code= @pcompcode and Edition_Code=@pedit_code

END


/****************end***********Mimoh mahajan 14/10/2011******0005264 ************88

*****************************Garima  4731************************************







ALTER PROCEDURE [dbo].[executebooking_new1]
@compcode as varchar(8),
@ciobookid as varchar(50),
@docno as varchar(25)=null,
@keyno as varchar(25)=null,
@rono as varchar(20)=null,
@agencycode as varchar(8)=null,
@client as varchar(100)=null,
@booking as varchar(8),
@dateformat as varchar(20),
@revenue as varchar(50)

AS
declare @query as varchar(8000)
 declare @VERSION1 as   float
 declare @count1  as    float


CREATE TABLE #tempbooking_mast ( 
  date_time            DATETIME         , 
  branch               VARCHAR(25)  , 
  booked_by            VARCHAR (25)  , 
  cio_booking_id       VARCHAR (50), 
  prev_booking         VARCHAR (25), 
  applied_by           VARCHAR (25), 
  audit                VARCHAR (25), 
  RO_No                VARCHAR (20), 
  RO_Date              DATETIME, 
  Caption              VARCHAR (500), 
  bill_status          VARCHAR (8)  , 
  ro_status            VARCHAR (8), 
  Agency_code          VARCHAR (50), 
  Agency_address       VARCHAR (500), 
  Client_code          VARCHAR (100), 
  Client_address       VARCHAR (500), 
  Agency_sub_code      VARCHAR (50), 
  Dockit_no            VARCHAR (25), 
  Executive_code       VARCHAR (50), 
  Executive_zone       VARCHAR (50), 
  Product_code         VARCHAR (50), 
  Brand_code           VARCHAR (50), 
  Key_no               VARCHAR (100), 
  Bill_remarks         VARCHAR (500), 
  Print_remark         VARCHAR (500), 
  Package_code         VARCHAR (500) , 
  No_of_insertion      FLOAT, 
  Insertion_date       DATETIME, 
  Repeating_day        VARCHAR (8), 
  Ad_type_code         VARCHAR (8), 
  Ad_cat_code          VARCHAR (8), 
  Ad_sub_cat_code      VARCHAR (50), 
  Color_code           VARCHAR (8), 
  Uom_code             VARCHAR (8), 
  Page_position_code   VARCHAR (8), 
  Page_type_code       VARCHAR (100), 
  Page_no              FLOAT, 
  Ad_size_type_code    VARCHAR (8), 
  Ad_size_height       FLOAT, 
  Ad_size_width        FLOAT, 
  Rate_code            VARCHAR (100), 
  Scheme_type_code     VARCHAR (18), 
  Currency_code        VARCHAR (8), 
  Agrred_rate          FLOAT, 
  Agreed_amount        FLOAT, 
  Special_discount     FLOAT, 
  Space_discount       FLOAT, 
  Special_charges      FLOAT, 
  Agency_status        VARCHAR (15), 
  Agency_type          VARCHAR (25), 
  Agency_pay           VARCHAR (25), 
  Agency_credit        FLOAT, 
  Total_area           FLOAT, 
  Card_rate            FLOAT, 
  Card_amount          FLOAT, 
  Discount             FLOAT, 
  Discount_per         FLOAT, 
  Bill_cycle           VARCHAR (8), 
  Revenue_center       VARCHAR (50), 
  Bill_pay             VARCHAR (8), 
  Bill_height          FLOAT, 
  Bill_width           FLOAT, 
  Bill_to              VARCHAR (100), 
  Invoices             FLOAT, 
  Vts                  FLOAT, 
  Bill_add             VARCHAR (500), 
  Trade_disc           FLOAT, 
  Agency_out           VARCHAR (50), 
  Box_code             VARCHAR (8), 
  Box_no               VARCHAR (50), 
  Box_agency           VARCHAR (2), 
  Box_client           VARCHAR (2), 
  Box_address          VARCHAR (500), 
  Comp_code            VARCHAR (8)  , 
  Userid               VARCHAR (8), 
  Creation_datetime    DATETIME          , 
  Booking_type         VARCHAR (8), 
  Tfn                  VARCHAR (2), 
  Coupan_ad            VARCHAR (2), 
  Campaign             VARCHAR (50), 
  Bill_amount          FLOAT, 
  Page_prem            VARCHAR (8), 
  Page_amount          FLOAT, 
  Prem_per             FLOAT, 
  Gross_amount         FLOAT, 
  Ad_size_column       FLOAT, 
  Bill_column          FLOAT, 
  Bill_area            FLOAT, 
  Special_disc_per     FLOAT, 
  Space_disc_per       FLOAT, 
  Paid_ins             FLOAT, 
  Contract_rate        FLOAT, 
  Deviation            FLOAT, 
  Variant_code         VARCHAR (8), 
  Contract_name        VARCHAR (50), 
  Contract_type        VARCHAR (50), 
  Card_name            VARCHAR (100), 
  Card_type            VARCHAR (50), 
  Card_month           VARCHAR (8), 
  Card_year            VARCHAR (8), 
  Card_number          VARCHAR (20), 
  Receipt_no           VARCHAR (50), 
  Ad_Subcat3           VARCHAR (8), 
  Ad_Subcat4           VARCHAR (8), 
  Ad_subcat5           VARCHAR (8), 
  Bg_color             VARCHAR (8), 
  Bullet_code          VARCHAR (8), 
  Bullet_premium       FLOAT, 
  Material_status      VARCHAR (50), 
  Receipt_date         DATETIME, 
  prev_cioid           VARCHAR (100), 
  prev_receipt         VARCHAR (50), 
  prev_grossamt        FLOAT, 
  Region               VARCHAR (8), 
  Variant              VARCHAR (8), 
  Colortype            VARCHAR (8), 
  Logo_H               VARCHAR (5), 
  Logo_W               VARCHAR (5), 
  Logo_color           VARCHAR (8), 
  Logo_Uom             VARCHAR (8), 
  SAPID                VARCHAR (10), 
  RETAINER             VARCHAR (100), 
  ADD_AGENCY_COMM      VARCHAR (8), 
  MOBILENO             VARCHAR (50), 
  ADD_AGENCY_COMM_AMT  VARCHAR (50), 
  RETAINER_COMM        VARCHAR (50), 
  RETAINER_COMM_AMT    VARCHAR (50), 
  CASH_RECIEVED        VARCHAR (50),doctype varchar(20),APP_REMARKS varchar(500) )


declare @booking_type11  as varchar(8) 

set @booking_type11='3'

set @query=' insert  #tempbooking_mast   SELECT date_time, branch, booked_by, cio_booking_id,
                prev_booking, applied_by, audit, RO_No, RO_Date,
                Caption, bill_status, ro_status, Agency_code,
                Agency_address, Client_code, Client_address,
                Agency_sub_code, Dockit_no, Executive_code,
                Executive_zone, Product_code, Brand_code, Key_no,
                Bill_remarks, Print_remark, Package_code,
                No_of_insertion, Insertion_date, Repeating_day,
                Ad_type_code, Ad_cat_code, Ad_sub_cat_code,
                Color_code, Uom_code, Page_position_code,
                Page_type_code, Page_no, Ad_size_type_code,
                Ad_size_height, Ad_size_width, Rate_code,
                Scheme_type_code, Currency_code, ISNULL(Agrred_rate,''0''),
                ISNULL(Agreed_amount,''0''), Special_discount, Space_discount,
                Special_charges, Agency_status, Agency_type,
                Agency_pay, Agency_credit, Total_area, Card_rate,
                Card_amount, ISNULL(Discount,''0''), Discount_per, Bill_cycle,
                Revenue_center, Bill_pay, Bill_height, Bill_width,
                Bill_to, Invoices, Vts, Bill_add, Trade_disc,
                Agency_out, Box_code, Box_no, Box_agency,
                Box_client, Box_address, Comp_code, Userid,
                Creation_datetime, Booking_type, Tfn, Coupan_ad,
                Campaign, Bill_amount, Page_prem, Page_amount,
                Prem_per, Gross_amount, Ad_size_column, Bill_column,
                Bill_area, Special_disc_per, Space_disc_per,
                Paid_ins, Contract_rate, Deviation, Variant_code,
                Contract_name, Contract_type, Card_name, Card_type,
                Card_month, Card_year, Card_number, Receipt_no,
                Ad_Subcat3, Ad_Subcat4, Ad_subcat5, Bg_color,
                Bullet_code, Bullet_premium, Material_status,
                (Receipt_date), prev_cioid, prev_receipt,
                prev_grossamt, Region, Variant, Colortype, Logo_H,
                Logo_W, Logo_color, Logo_Uom,sapid,RETAINER,ADD_AGENCY_COMM,MOBILENO,ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,'''',doctype,APP_REMARKS
           FROM TBL_BOOKING_MAST where comp_code='''+@compcode+''''
--  and  Ad_type_code='''+@booking+'''    '


if(@ciobookid <>'' or @ciobookid<>null)
begin
set @query=@query+'and  cio_booking_id = '''+@ciobookid+''''
end

/*

if(@docno<>'' and @docno<>null)
begin
set @query=@query+'and  Dockit_no = '''+@docno+''''
end

if(@keyno<>'' and @keyno<>null)
begin
set @query=@query+'and  Key_no = '''+@keyno+''''
end

if(@rono<>'' and @rono<>null)
begin
set @query=@query+'and  RO_No = '''+@rono+''''
end

if(@agencycode<>'' and @agencycode<>null)
begin
set @query=@query+'and  Agency_sub_code = '''+@agencycode+''''
end

if(@client<>'' and @client<>null) 
begin
set @query=@query+'and  Client_code = '''+@client+''''
end

if(@booking<> '' and @booking <> null)
begin
set @query=@query +' and Ad_type_code='''+@booking+''''
end

set @query=@query + 'and branch='''+@revenue+''''

*/
print(@query)
exec(@query)

SELECT CASE @dateformat
                     WHEN 'mm/dd/yyyy' THEN convert(varchar(100),date_time,101)
                  WHEN 'dd/mm/yyyy' THEN convert(varchar(100),date_time,103)
                     WHEN 'yyyy/mm/dd' THEN convert(varchar(100),date_time,103)  END AS date_time,
                     branch,booked_by, cio_booking_id, prev_booking, applied_by,audit, RO_No,
            CASE @dateformat
                 WHEN 'mm/dd/yyyy' THEN convert(varchar(100),RO_Date,101)
                 WHEN 'dd/mm/yyyy' THEN convert(varchar(100),RO_Date,103)
                 WHEN 'yyyy/mm/dd' THEN convert(varchar(100),RO_Date,103)  END AS RO_Date,
                 -- TO_CHAR(RO_Date, 'dd/mm/yyyy') AS RO_Date,
                Caption, bill_status, ro_status,#TEMPBOOKING_MAST.Agency_code,
                Agency_address, Client_code, Client_address,
                Agency_sub_code, Dockit_no, Executive_code,
                Executive_zone, Product_code, Brand_code, Key_no,
                Bill_remarks, Print_remark, Package_code,No_of_insertion,
            CASE @dateformat
                    WHEN 'mm/dd/yyyy' THEN convert(varchar(100),Insertion_date,101)
                    WHEN 'dd/mm/yyyy' THEN convert(varchar(100),Insertion_date,103)
                    WHEN 'yyyy/mm/dd' THEN convert(varchar(100),Insertion_date,103)  END    AS Insertion_date,
                Repeating_day, Ad_type_code, Ad_cat_code,
                Ad_sub_cat_code, Color_code, Uom_code,
                Page_position_code, Page_type_code, Page_no,
                Ad_size_type_code, Ad_size_height, Ad_size_width, Rate_code,
                (SELECT Scheme_Name FROM SCHEME_MASTER WHERE scheme_id =#TEMPBOOKING_MAST.Scheme_type_code)AS Scheme_type_code,
                 Currency_code, Agrred_rate, Agreed_amount,
                Special_discount, Space_discount, Special_charges,
                #TEMPBOOKING_MAST.Comp_code, #TEMPBOOKING_MAST.Userid,
                #TEMPBOOKING_MAST.Agency_status, Agency_type, Agency_pay,
                Agency_credit, Total_area, Card_rate, Card_amount,
                Discount, Discount_per, Bill_cycle, Revenue_center,
                Bill_pay, Bill_height, Bill_width,
                #TEMPBOOKING_MAST.Bill_to, Invoices, Vts, Bill_add,
                Trade_disc, Agency_out,#TEMPBOOKING_MAST. Booking_type, Campaign,
                Page_prem, Page_amount, Prem_per, Gross_amount,
                Bill_amount, Box_code, Box_no, Box_agency,
                Box_client, Box_address, Tfn, Coupan_ad,
                Ad_size_column, Bill_column, Bill_area,
                Special_disc_per, Space_disc_per,
                AGENCY_MAST.Agency_Name + '(' + AGENCY_MAST.code_subcode + ')'+ '('+(select city_mst.city_name from city_mst  where city_mst.city_code=agency_mast.city_code)  +')' AS AgencyName,
                (SELECT EXEC_MAST.Exec_name + '(' + convert(varchar(100),EXEC_MAST.Exe_no)+ ')' FROM EXEC_MAST
                  WHERE #TEMPBOOKING_MAST.Executive_code = EXEC_MAST.Exe_no
                    AND #TEMPBOOKING_MAST.Comp_code = EXEC_MAST.comp_code) AS execname,
               
                (SELECT  PRODUCT_CAT_MAST.prod_desc + '(' +PRODUCT_CAT_MAST.prod_cat_code + ')' FROM PRODUCT_CAT_MAST
                  WHERE #TEMPBOOKING_MAST.Product_code = PRODUCT_CAT_MAST.prod_cat_code
                    AND #TEMPBOOKING_MAST.Comp_code = PRODUCT_CAT_MAST.comp_code) AS product,
                
                Paid_ins, Contract_rate, Deviation, Variant_code,
                Contract_name, Contract_type, Card_name, Card_type,
          
                Card_month, Card_year, Card_number, Receipt_no,
                Ad_Subcat3, Ad_Subcat4, Ad_subcat5, Bg_color,
                Bullet_code, Bullet_premium,
                (SELECT Agency_Name FROM AGENCY_MAST WHERE code_subcode =#TEMPBOOKING_MAST.Agency_sub_code) AS AgencySubCode,
      
                isnull ((SELECT Cust_Name+'('+Cust_Code+')' FROM CUST_MAST WHERE Cust_Code = Client_code), Client_code) AS Client,                                       --112
                (SELECT DISTINCT Payment_Mode_Name FROM PAYMENT_MODE_MAST WHERE PAYMENT_MODE_MAST.Comp_Code=#TEMPBOOKING_MAST. Comp_code  and Pay_Mode_Code = Agency_pay) AS PayMode,
                (SELECT Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code =#TEMPBOOKING_MAST.Ad_cat_code) AS categoryname,
                (SELECT Adv_Subcat_Name FROM ADV_SUBCAT_MAST  WHERE ADV_SUBCAT_MAST.Adv_Subcat_Code =#TEMPBOOKING_MAST.Ad_sub_cat_code)
                 AS subcategoryname,
                (SELECT brand_name FROM BRAND_MST WHERE brand_code =#TEMPBOOKING_MAST.Brand_code) AS Brand,
                (SELECT Uom_Name FROM UOM_MAST WHERE Uom_Code = #TEMPBOOKING_MAST.Uom_code) AS UOM,
                (SELECT premiumname FROM ADVPOS_PREM_MAST WHERE Premiumcode =#TEMPBOOKING_MAST.Page_prem) AS PagePremium,
                 (SELECT Pos_Type FROM ADVPOS_TYPE_MAST
                  WHERE Pos_Type_Code = #TEMPBOOKING_MAST.Page_position_code) AS PositionPremium,
                (SELECT Curr_Name FROM CURR_MAST WHERE Curr_Code = #TEMPBOOKING_MAST.Currency_code) AS Currency,
                Material_status, convert(varchar(100),Receipt_date,102) AS Receipt_date, #TEMPBOOKING_MAST.Region,
                Variant, Colortype,
                (SELECT UOM_DESC FROM UOM_MAST WHERE Uom_Code = #TEMPBOOKING_MAST.Uom_code) AS uom_desc,
                (SELECT Logo FROM UOM_MAST WHERE Uom_Code =#TEMPBOOKING_MAST.Uom_code) AS logo,Logo_H, Logo_W, Logo_color, Logo_Uom,
                (SELECT Logo_Uom FROM UOM_MAST WHERE Uom_Code = #TEMPBOOKING_MAST.Uom_code)  AS logocode,
                (SELECT Box_Charges_Native FROM BOX_MAST WHERE BOX_MAST.Box_Code=#TEMPBOOKING_MAST.Box_code) AS boxchrg,#TEMPBOOKING_MAST.sapid,
                retainer,(SELECT Retain_Name+'('+Retain_Code+')' FROM RETAINERMASTER WHERE RETAINERMASTER.Retain_Code=#TEMPBOOKING_MAST.RETAINER) AS RETAINER1,
                (SELECT Package_Name FROM combin_mast WHERE Combin_Code =

#TEMPBOOKING_MAST.Package_code) as Package_cod,(SELECT Col_Name FROM col_mast WHERE Col_Code = #TEMPBOOKING_MAST.Color_code) as

Color_cod,(SELECT Pos_Type FROM advpos_type_mast WHERE Pos_Type_Code =

#TEMPBOOKING_MAST.Page_position_code) as Page_position_cod,





 CASE #TEMPBOOKING_MAST.Booking_type
                    WHEN '1'  THEN 'BARTER'
                    WHEN  '2' THEN 'FMG'
                    WHEN '3' THEN 'NORMAL'  
when '4' then 'INHOUSE'
when '5' then 'COMPLIMENTARY'

END    AS Book_type,
         

--decode(TEMPBOOKING_MAST.Booking_type,'1','BARTER','2','FMG','3','NORMAL','4','INHOUSE') as Book_type,
(SELECT catname  FROM  AD_CAT3   WHERE AD_CAT3.catcode=#TEMPBOOKING_MAST.Ad_Subcat3)  as Subcat3,
(SELECT Cat_Name  FROM  TBL_CAT4   WHERE

TBL_CAT4.Cat_Code=#TEMPBOOKING_MAST.Ad_Subcat4) as Ad_Subcat4,
(SELECT Cat_Name  FROM  TBL_CAT5   WHERE

TBL_CAT5.Cat_Code=#TEMPBOOKING_MAST.Ad_subcat5) as Ad_subcat5,
/*(SELECT Comm_Rate FROM ret_comm_details WHERE
ret_comm_details.Retain_Code=#TEMPBOOKING_MAST.RETAINER 
and rowid=
(select max(rowid) from ret_comm_details where ret_comm_details.Retain_Code=#TEMPBOOKING_MAST.RETAINER))*/
 RETAINER_COMM AS RETAINER_COMM,
(select AUDIT_COMMENT from tbl_booking_mast where tbl_booking_mast.cio_booking_id=#TEMPBOOKING_MAST.cio_booking_id) as remarks,
ADD_AGENCY_COMM,
 (SELECT Box_Charges_Type FROM BOX_MAST WHERE BOX_MAST.Box_Code=#TEMPBOOKING_MAST.Box_code) AS boxchargetype,
 ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,
(select RO_COMMENT from tbl_booking_mast where tbl_booking_mast.cio_booking_id=#TEMPBOOKING_MAST.cio_booking_id) as RO_COMMENT
, DOCTYPE,APP_REMARKS
 FROM #TEMPBOOKING_MAST, AGENCY_MAST
 WHERE
 AGENCY_MAST.code_subcode = #TEMPBOOKING_MAST.Agency_sub_code
AND 
AGENCY_MAST.Comp_Code =#TEMPBOOKING_MAST. Comp_code 
ORDER BY #TEMPBOOKING_MAST.Creation_datetime




 --SELECT isnull(COUNT (*),'0') AS count    FROM TBL_BOOKING_MAST_LOG WHERE Receipt_no = @ciobookid AND audit <> ''

 SELECT @VERSION1 = MAX (VSEQNO)   FROM TBL_BOOKING_MAST_LOG   WHERE Receipt_no = @ciobookid AND VSEQNO < (SELECT MAX (VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE Receipt_no = @ciobookid);      




 SELECT    CASE 
@dateformat
                     WHEN 'mm/dd/yyyy' THEN CONVERT(varchar(50),datetime_time,101)
                  WHEN 'dd/mm/yyyy' THEN CONVERT(varchar(50),datetime_time,102)
                     WHEN 'yyyy/mm/dd' THEN CONVERT(varchar(50),datetime_time,103)  END AS date_time,
                 branch, booked_by, cio_booking_id, prev_booking, applied_by,audit, RO_No,
               CASE @dateformat
                     WHEN 'mm/dd/yyyy' THEN CONVERT(varchar(50),RO_Datetime,101)
                  WHEN 'dd/mm/yyyy' THEN CONVERT(varchar(50),RO_Datetime,102)
                     WHEN 'yyyy/mm/dd' THEN CONVERT(varchar(50),RO_Datetime,103)  END AS RO_Date,
                Caption,bill_status, ro_status,
                TBL_BOOKING_MAST_LOG.Agency_code, Agency_address,
                Client_code, Client_address, Agency_sub_code,
                Dockit_no, Executive_code, Executive_zone,
                Product_code, Brand_code, Key_no, Bill_remarks,
                Print_remark, Package_code, No_of_insertion,
            CASE @dateformat
                     WHEN 'mm/dd/yyyy' THEN CONVERT(varchar(50),Insertion_datetime,101)
                  WHEN 'dd/mm/yyyy' THEN CONVERT(varchar(50),Insertion_datetime,102)
                     WHEN 'yyyy/mm/dd' THEN CONVERT(varchar(50),Insertion_datetime,103)  END AS Insertion_date,
             
                Repeating_day, Ad_type_code, Ad_cat_code,
                Ad_sub_cat_code, Color_code, Uom_code,
                Page_position_code, Page_type_code, Page_no,
                Ad_size_type_code, Ad_size_height, Ad_size_width,
                Rate_code, Scheme_type_code, Currency_code,
                Agrred_rate, Agreed_amount, Special_discount,
                Space_discount, Special_charges,
                TBL_BOOKING_MAST_LOG.Comp_code,
                TBL_BOOKING_MAST_LOG.Userid,
                TBL_BOOKING_MAST_LOG.Agency_status, Agency_type,
                Agency_pay, Agency_credit, Total_area, Card_rate,
                Card_amount, Discount, Discount_per, Bill_cycle,
                Revenue_center, Bill_pay, Bill_height, Bill_width,
                TBL_BOOKING_MAST_LOG.Bill_to, Invoices, Vts,
                Bill_add, Trade_disc, Agency_out,TBL_BOOKING_MAST_LOG.Booking_type,
                Campaign, Page_prem, Page_amount, Prem_per,
                Gross_amount, Bill_amount, Box_code, Box_no,
                Box_agency, Box_client, Box_address, Tfn Coupan_ad,
                Ad_size_column, Bill_column, Bill_area,
                Special_disc_per, Space_disc_per,
                  AGENCY_MAST.Agency_Name+ '('+ AGENCY_MAST.code_subcode+ ')' AS AgencyName,
                   (SELECT    EXEC_MAST.Exec_name + '('+convert(varchar(100),EXEC_MAST.Exe_no) + ')'
                   FROM EXEC_MAST  WHERE TBL_BOOKING_MAST_LOG.Executive_code =EXEC_MAST.Exe_no
                    AND TBL_BOOKING_MAST_LOG.Comp_code =EXEC_MAST.comp_code)AS execname,
               (SELECT    PRODUCT_CAT_MAST.prod_desc+ '('+ PRODUCT_CAT_MAST.prod_cat_code + ')'
                   FROM PRODUCT_CAT_MAST WHERE TBL_BOOKING_MAST_LOG.Product_code =PRODUCT_CAT_MAST.prod_cat_code
                    AND TBL_BOOKING_MAST_LOG.Comp_code =PRODUCT_CAT_MAST.comp_code)                                                                 AS product,
                Paid_ins, Contract_rate, Deviation, Variant_code,
                Contract_name, Contract_type, Card_name, Card_type,
                Card_month, Card_year, Card_number, Receipt_no,
                Ad_Subcat3, Ad_Subcat4, Ad_subcat5, Bg_color,
                (SELECT Agency_Name FROM AGENCY_MAST WHERE code_subcode = TBL_BOOKING_MAST_LOG.Agency_sub_code)AS AgencySubCode,
               isnull ((SELECT Cust_Name  FROM CUST_MAST WHERE Cust_Code = Client_code),'' ) AS Client,
              (SELECT distinct Payment_Mode_Name  FROM PAYMENT_MODE_MAST WHERE PAYMENT_MODE_MAST.Comp_Code=TBL_BOOKING_MAST_LOG.Comp_Code and Pay_Mode_Code = Agency_pay) AS PayMode,
               (SELECT Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code =TBL_BOOKING_MAST_LOG.Ad_cat_code)AS categoryname,
               (SELECT Adv_Subcat_Name  FROM ADV_SUBCAT_MAST WHERE ADV_SUBCAT_MAST.Adv_Subcat_Code =TBL_BOOKING_MAST_LOG.Ad_sub_cat_code)
                 AS subcategoryname,
               (SELECT brand_name  FROM BRAND_MST   WHERE brand_code = TBL_BOOKING_MAST_LOG.Brand_code)AS Brand,
               (SELECT Uom_Name FROM UOM_MAST WHERE Uom_Code =TBL_BOOKING_MAST_LOG.Uom_code)AS UOM,
               (SELECT premiumname FROM ADVPOS_PREM_MAST WHERE Premiumcode =TBL_BOOKING_MAST_LOG.Page_type_code)AS PagePremium,
                (SELECT Pos_Type FROM ADVPOS_TYPE_MAST WHERE Pos_Type_Code =TBL_BOOKING_MAST_LOG.Page_position_code)AS PositionPremium,
               (SELECT Curr_Name  FROM CURR_MAST WHERE Curr_Code =TBL_BOOKING_MAST_LOG.Currency_code) AS Currency
           FROM TBL_BOOKING_MAST_LOG, AGENCY_MAST
             WHERE TBL_BOOKING_MAST_LOG.Receipt_no = @ciobookid
            AND VSEQNO = @VERSION1
           AND AGENCY_MAST.code_subcode =TBL_BOOKING_MAST_LOG.Agency_sub_code
            AND AGENCY_MAST.Comp_Code =TBL_BOOKING_MAST_LOG. Comp_Code





SELECT    
CASE 
@dateformat
                     WHEN 'mm/dd/yyyy' THEN convert(varchar(50) ,datetime_time,101)
                  WHEN 'dd/mm/yyyy' THEN convert(varchar(50) , datetime_time,102)
                     WHEN 'yyyy/mm/dd' THEN convert(varchar(50) , datetime_time,103)  END AS date_time,
                   branch,booked_by, cio_booking_id, prev_booking, applied_by,audit, RO_No,
              CASE @dateformat
                     WHEN 'mm/dd/yyyy' THEN convert(varchar(50) , RO_Datetime,101)
                  WHEN 'dd/mm/yyyy' THEN convert(varchar(50) ,RO_Datetime,102)
                     WHEN 'yyyy/mm/dd' THEN convert(varchar(50) ,RO_Datetime,103)  END AS RO_Date,
                Caption,bill_status, ro_status,
                TBL_BOOKING_MAST_LOG.Agency_code, Agency_address,
                Client_code, Client_address, Agency_sub_code,
                Dockit_no, Executive_code, Executive_zone,
                Product_code, Brand_code, Key_no, Bill_remarks,
                Print_remark, Package_code, No_of_insertion,
            CASE @dateformat
                     WHEN 'mm/dd/yyyy' THEN convert(varchar(50) ,Insertion_datetime,101)
                  WHEN 'dd/mm/yyyy' THEN convert(varchar(50) ,Insertion_datetime,102)
                     WHEN 'yyyy/mm/dd' THEN convert(varchar(50) ,Insertion_datetime,103)  END AS Insertion_date,
                Repeating_day, Ad_type_code, Ad_cat_code,
                Ad_sub_cat_code, Color_code, Uom_code,
                Page_position_code, Page_type_code, Page_no,
                Ad_size_type_code, Ad_size_height, Ad_size_width,
                Rate_code, Scheme_type_code, Currency_code,
                Agrred_rate, Agreed_amount, Special_discount,
                Space_discount, Special_charges,
                TBL_BOOKING_MAST_LOG.Comp_code,
                TBL_BOOKING_MAST_LOG.Userid,
                TBL_BOOKING_MAST_LOG.Agency_status, Agency_type,
                Agency_pay, Agency_credit, Total_area, Card_rate,
                Card_amount, Discount, Discount_per, Bill_cycle,
                Revenue_center, Bill_pay, Bill_height, Bill_width,
                TBL_BOOKING_MAST_LOG.Bill_to, Invoices, Vts,
                Bill_add, Trade_disc, Agency_out,TBL_BOOKING_MAST_LOG. Booking_type,
                Campaign, Page_prem, Page_amount, Prem_per,
                Gross_amount, Bill_amount, Box_code, Box_no,
                Box_agency, Box_client, Box_address, Tfn, Coupan_ad,
                Ad_size_column, Bill_column, Bill_area,
                Special_disc_per, Space_disc_per,
                 AGENCY_MAST.Agency_Name + '('+ AGENCY_MAST.code_subcode+ ')' AS AgencyName,
                (SELECT    EXEC_MAST.Exec_name + '('+ convert(varchar(100), EXEC_MAST.Exe_no)+ ')'
                   FROM EXEC_MAST  WHERE TBL_BOOKING_MAST_LOG.Executive_code = EXEC_MAST.Exe_no
                    AND TBL_BOOKING_MAST_LOG.Comp_code = EXEC_MAST.comp_code)AS execname,
                (SELECT    PRODUCT_CAT_MAST.prod_desc + '(' + PRODUCT_CAT_MAST.prod_cat_code + ')'
                   FROM PRODUCT_CAT_MAST WHERE TBL_BOOKING_MAST_LOG.Product_code =PRODUCT_CAT_MAST.prod_cat_code
                    AND TBL_BOOKING_MAST_LOG.Comp_code =PRODUCT_CAT_MAST.comp_code)AS product,
                Paid_ins, Contract_rate, Deviation, Variant_code,
                Contract_name, Contract_type, Card_name, Card_type,
                Card_month, Card_year, Card_number, Receipt_no,
                Ad_Subcat3, Ad_Subcat4, Ad_subcat5, Bg_color,
                Bullet_code, Bullet_premium,
                (SELECT Agency_Name FROM AGENCY_MAST WHERE code_subcode =TBL_BOOKING_MAST_LOG.Agency_sub_code)AS AgencySubCode,
                isnull ((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code = Client_code),'' ) AS Client,
                (SELECT distinct Payment_Mode_Name FROM PAYMENT_MODE_MAST WHERE Comp_Code=TBL_BOOKING_MAST_LOG. Comp_Code and Pay_Mode_Code = Agency_pay) AS PayMode,
                (SELECT Adv_Cat_Name FROM ADV_CAT_MAST WHERE ADV_CAT_MAST.Adv_Cat_Code =TBL_BOOKING_MAST_LOG.Ad_cat_code)AS categoryname,
                (SELECT Adv_Subcat_Name FROM ADV_SUBCAT_MAST WHERE ADV_SUBCAT_MAST.Adv_Subcat_Code =TBL_BOOKING_MAST_LOG.Ad_sub_cat_code)AS subcategoryname,
                (SELECT brand_name FROM BRAND_MST WHERE brand_code =TBL_BOOKING_MAST_LOG.Brand_code)AS Brand,
                (SELECT Uom_Name FROM UOM_MAST WHERE Uom_Code =TBL_BOOKING_MAST_LOG.Uom_code)AS UOM,
                (SELECT premiumname FROM ADVPOS_PREM_MAST  WHERE Premiumcode =TBL_BOOKING_MAST_LOG.Page_type_code)AS PagePremium,
                (SELECT Pos_Type FROM ADVPOS_TYPE_MAST WHERE Pos_Type_Code = TBL_BOOKING_MAST_LOG.Page_position_code)AS PositionPremium,
                (SELECT Curr_Name FROM CURR_MAST WHERE Curr_Code =TBL_BOOKING_MAST_LOG.Currency_code)AS Currency
           FROM TBL_BOOKING_MAST_LOG, AGENCY_MAST
          WHERE TBL_BOOKING_MAST_LOG.Receipt_no = @ciobookid
            AND VSEQNO =(SELECT MAX (VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE Receipt_no = @ciobookid AND VSEQNO <
            (SELECT MAX(VSEQNO) FROM TBL_BOOKING_MAST_LOG WHERE Receipt_no = @ciobookid) AND audit IS NOT NULL)
                        AND AGENCY_MAST.code_subcode = TBL_BOOKING_MAST_LOG.Agency_sub_code 
AND AGENCY_MAST.Comp_Code = TBL_BOOKING_MAST_LOG. Comp_Code























**********************************************end of issue number 4731**********************************





//==============================ISSUE NO.4887 19/10/2011============================================================


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER Procedure [dbo].[bindadcat345] (@adcat as varchar(50),
@adsubcat as varchar(50)=null,
@adssubcat as varchar(50)=null,
@compcode as varchar(10)
)As

Begin



   select catname,catcode from ad_cat3 where compcode=@compcode and subcatname=@adcat order by catname

 select Cat_Name,Cat_Code from tbl_cat4 where Comp_Code=@compcode and Sub_Cat_Name=@adsubcat order by Cat_Name


 select Cat_Name,Cat_Code from tbl_cat5 where Comp_Code=@compcode and Sub_Cat_Name=@adssubcat order by Cat_Name





End




//============================== END OF ISSUE NO.4887 19/10/2011============================================================



=*************************************mimoh 19/oct/2011**************************0005373***********************************


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



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
@p_aotosupply  AS VARCHAR(5)
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

ALLOWED_PDC_DAYS_RECEIPT=@P_ALLOW_PDC,AD_TYPE_MANUL_BILL=@PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=@RO_OUTSTAND_P,GENRATE_CIR_AGCD=@genrate_agency_code,DISP_AUDITBKG=@p_dispauditbk,CIR_DIS_AUTO_POSTING=@p_aotosupply

 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)



































*****************************************************************************************************
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

















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
ALLOWED_PDC_DAYS_RECEIPT,AD_TYPE_MANUL_BILL, OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD,DISP_AUDITBKG,CIR_DIS_AUTO_POSTING
           FROM PREFERRENCES
          WHERE comp_code = @compcode

/*************************************mimoh 19/oct/2011**************************0005373***********************************


/******************* Lata 24-oct11 ************/

create PROCEDURE InsertCashDetailExternalSource 
@cioid as varchar(50),
@receipt as varchar(50),
@compcode_p as varchar(20),
@userid_p as varchar(20),
@ip as varchar(20)
AS
declare @billpay varchar(20)
declare @rostatus varchar(20)
declare @receiptno varchar(20)
BEGIN
select @billpay=Bill_pay,@rostatus=ro_status,@receiptno=Receipt_no  from  tbl_booking_mast where cio_booking_id=@cioid
IF @billpay='CA0' and (@receiptno='' or @receiptno is null)
BEGIN
	 update tbl_booking_mast set Receipt_no=@receipt, Receipt_date = getdate(),
                ro_status = 1 where cio_booking_id=@cioid
    INSERT INTO TBL_EXT_BOOKING_RPT_DET(BOOKINGID, RECEIPTNO, COMPCODE, USERID, IP_USER, DATE_TIME)
        VALUES(@cioid,@receipt,@compcode_p,@userid_p,@ip,GETDATE());
END
select @receipt as RECPTNO
END
GO


*******************
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
*****************************mimoh 24 oct 2011***********0005367***********************************
ALTER procedure [dbo].[Adbarter_checkduplicacy]

@compcode as varchar(8),
@unitcode as varchar(8),
@branchcode as varchar(8),
@bartercode as varchar(8),
@barterdesc as varchar(8),
@agencycode as varchar(10),
@agencysubcode as varchar(10)

as

 select * from ad_barter where COMP_CODE=@compcode and UNIT_CODE=@unitcode and BRAN_CODE=@branchcode and BARTER_CODE =@bartercode  and AG_CODE=@agencycode and AG_SUBCODE=@agencysubcode
 
 select * from ad_barter where COMP_CODE=@compcode and UNIT_CODE=@unitcode and BRAN_CODE=@branchcode and BARTE_DESC =@barterdesc  and AG_CODE=@agencycode and AG_SUBCODE=@agencysubcode


*****************************mimoh 24 oct 2011***********0005367***********************************


//*****************************sql mimoh 31oct 2011**********start-0005464/**********************







set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER proc [dbo].[RetainerInsertDetail]
(
@Comp_Code1 as varchar(8),
@Retain_Code1 as varchar(8),
@userid1 as varchar(10),
@Retain_Name1 as varchar(150),
@Retain_Alias1 as varchar(150),
@Add11 as varchar(50) ,
@Street1 as varchar(50) ,
@City_Code1 as varchar(8),
@pubcent1   as varchar(20),
@Zip1 as varchar(12) ,
@Dist_Code1 as varchar(8) ,
@State_Code1 as varchar(8),
@zone_code1 as varchar(10),
@region_code1 as varchar(10),
@Country_Code1 as varchar(8),
@phone11 as varchar(30) ,
@Phone21 as varchar(30) ,
@Fax1 as varchar(30) ,
@EmailID1 as varchar(200) ,
@PAN_No1 as varchar(30) ,
@Credit_Days1 as varchar(5),
@Remarks1 as varchar(200) ,

@flag as int,
@Box1 as varchar(50),
@Publication11 as varchar(50),
@Edition11 as varchar(50),
@Supplement11 as varchar(50),
@taluka as varchar(23),
@repname as varchar(23),
@branchcode  as varchar(20),
@creditlimit  as varchar(50),
@mobile1 as varchar(20),
@signature	as varchar(50)
)
as

declare @query varchar(1000)
declare @query3 varchar(1000)


if(@flag=0)
begin

set @query = 'insert into RetainerMaster(Comp_Code ,Retain_Code ,userid ,Retain_Name ,Retain_Alias ,Add1 ,Street ,City_Code ,Zip ,Dist_Code ,State_Code ,Zone_Code,Region_Code,Country_Code ,phone1 ,Phone2 ,Fax ,EmailID ,PAN_No ,Credit_Days,Remarks , pubcent_code,Creation_Datetime, retain_status, to_date,BOXMATTER,PUBLICATION,EDITION,SUPPLEMENT,TALUKA,REPRESENTATIVE,Branch_code,CREDIT_LIMIT,MOBILENO,SIGN)values ('''+@Comp_Code1+''' ,'''+@Retain_Code1+''' ,'''+@userid1+''' ,'''+@Retain_Name1+''' ,'''+@Retain_Alias1+''' ,'''+@Add11+''' ,'''+@Street1+''','''+@City_Code1+''' ,'''+@Zip1+''' ,'''+@Dist_Code1+''','''+@State_Code1+''' ,'''+@zone_code1+''' ,'''+@region_code1+''' ,'''+@Country_Code1+''' ,'''+@phone11+''' ,'''+@Phone21+''' ,'''+@Fax1+''','''+@EmailID1+''','''+@PAN_No1+''' ,'''+@Credit_Days1+''' ,'''+@Remarks1+''','''+@pubcent1+''',getdate(),'''','''','''+@Box1+''','''+@Publication11+''' ,'''+@Edition11+''','''+@Supplement11+''','''+@taluka+''','''+@repname+''','''+@branchcode+''','''+@creditlimit+''','''+ @mobile1+''','''+@signature+''') '

end
if(@flag=1)
begin  
	set @query = 'update RetainerMaster set Retain_Name = '''+@Retain_Name1+'''  ,Retain_Alias = '''+@Retain_Alias1+'''  ,Add1 = '''+@Add11 +''',Street = '''+@Street1+''' ,City_Code = '''+@City_Code1+'''  ,Zip = '''+@Zip1+'''  ,Dist_Code = '''+@Dist_Code1+'''  ,State_Code = '''+@State_Code1+''' ,zone_code = '''+@zone_code1+'''  ,region_code = '''+@region_code1+'''  ,Country_Code = '''+@Country_Code1+'''  ,phone1 = '''+@phone11+'''  ,Phone2 = '''+@Phone21+'''  ,Fax = '''+@Fax1+'''  ,EmailID = '''+@EmailID1+'''  ,PAN_No = '''+@PAN_No1+'''  ,Credit_Days = '''+@Credit_Days1+''',Remarks = '''+@Remarks1+''' ,    pubcent_code='''+@pubcent1+''' 
,    BOXMATTER='''+@Box1+''' ,PUBLICATION = '''+@Publication11+'''  ,EDITION = '''+@Edition11 +''',SUPPLEMENT = '''+@Supplement11+''',TALUKA='''+@taluka+''',REPRESENTATIVE='''+@repname+''',Branch_code='''+@branchcode+''',CREDIT_LIMIT='''+@creditlimit+''',MOBILENO='''+ @mobile1+''',SIGN='''+@signature+''' where comp_code = '''+@Comp_Code1 +''' and Retain_Code = '''+@Retain_Code1+''''    --/*   and userid ='''+@userid+'''   */  
--set @query3 = 'update tmpretainer set Retain_Name = '''+@Retain_Name+'''  ,Retain_Alias = '''+@Retain_Alias+'''  ,Add1 = '''+@Add1 +''',Street = '''+@Street+''' ,City_Code = '''+@City_Code+'''  ,Zip = '''+@Zip+'''  ,Dist_Code = '''+@Dist_Code+'''  ,State_Code = '''+@State_Code+'''  ,Country_Code = '''+@Country_Code+'''  ,phone1 = '''+@phone1+'''  ,Phone2 = '''+@Phone2+'''  ,Fax = '''+@Fax+'''  ,EmailID = '''+@EmailID+'''  ,PAN_No = '''+@PAN_No+'''  ,Credit_Days = '''+@Credit_Days+''',Remarks = '''+@Remarks+'''   where comp_code = '''+@Comp_Code +'''and userid ='''+@userid+''' and Retain_Code = '''+@Retain_Code+'''' 
end


print(@query)
exec(@query)
--print(@query3)
--exec(@query3)










//************************************************************************************************************************

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go










ALTER PROCEDURE [dbo].[RetainerExec]

@compcode  varchar(8),
@Retain_Code  varchar(8),
@retname  varchar(150),
@retalias  varchar(150),
@citycode varchar(10),
@pubcent varchar(20),
@country varchar(8),
@Box varchar(50),
@repname  varchar(50),
@branchname  varchar(20)




AS

--saurabh added

--declare @query1 varchar(900)
declare @query2 varchar(900)
declare @query3 varchar(900)
declare @query4 varchar(900)
declare @cc varchar(28)
--declare @reatiner1 varchar(12)



--delete  from tmpretainer 

/*CREATE TABLE #RetainerMaster (
	Comp_Code varchar (8)  NOT NULL ,
	userid varchar (10)  NOT NULL ,
	Retain_Code varchar (8)  NOT NULL ,
	Retain_Name varchar (50)  NOT NULL ,
	Retain_Alias varchar (15)  NOT NULL ,
	Add1 varchar (50)  NULL ,
	Street varchar (50)  NULL ,
	City_Code varchar (8)  NOT NULL ,
	Zip varchar (12)  NULL ,
	Dist_Code varchar (8)  NULL ,
	State_Code varchar (8)  NOT NULL ,
  --  Region_Code varchar (8)  NOT NULL ,
	Country_Code varchar (8)  NOT NULL ,
	Phone1 varchar (30)  NULL ,
	Phone2 varchar (30)  NULL ,
	Fax varchar (30)  NULL ,
	EmailID varchar (50)  NULL ,
	Credit_Days varchar (5)  NULL ,
	Remarks varchar (200)  NULL ,
	PAN_No varchar (50)  NULL ,
	Retain_status varchar (50)  NULL ,
	To_date datetime NULL ,
	--status_date datetime null,
	Creation_Datetime datetime NOT NULL ,
	pubcent_code varchar (20)  NULL,
	Zone_Code  varchar (10),
	Region_Code  varchar (10),
	Branch_code  varchar (8),
    BOXMATTER varchar (50)  NULL,
	PUBLICATION varchar (50),
	EDITION  varchar (50),
	SUPPLEMENT  varchar (50),
	TALUKA  varchar (23)
) */










declare @retainer1 char(12)

declare @query  varchar(3000)
declare @query1  varchar(3000)

--set @query='insert into #RetainerMaster select Comp_Code,userid,Retain_Code,Retain_Name,Retain_Alias,Add1,Street,City_Code,Zip,Dist_Code,State_Code,Region_Code,Country_Code,Phone1,Phone2,Fax,EmailID,Credit_Days,Remarks,PAN_No,Retain_status,getdate(),getdate(),pubcent_code,BOXMATTER,PUBLICATION,EDITION,SUPPLEMENT,TALUKA from  RetainerMaster where Comp_code='''+@compcode+''''
set @query=' select Comp_Code,userid,Retain_Code,Retain_Name,Retain_Alias,Add1,Street,City_Code,Zip,Dist_Code,State_Code,Region_Code,Country_Code,Phone1,Phone2,Fax,EmailID,Credit_Days,Remarks,PAN_No,Retain_status,getdate(),getdate(),pubcent_code,BOXMATTER,PUBLICATION,EDITION,SUPPLEMENT,TALUKA,REPRESENTATIVE as "repname",Branch_code,CREDIT_LIMIT,MOBILENO,SIGN from  RetainerMaster where Comp_code='''+@compcode+''''

if(@Retain_Code <>'')

begin

set @query= @query + 'and  Retain_Code like ''%'+@Retain_Code +'%'''

end

if(@retname <>'')

--print(@retname)

begin

set @query  =  @query + 'and Retain_Name  like ''%'+@retname +'%'''

end

if(@retalias <> '')

--print(@retalias)

begin

set @query  =  @query + 'and Retain_Alias  like ''%'+@retalias+'%'''

end

if(@citycode <> '0' and @citycode <> '')

--print(@citycode)

begin

set @query  =  @query + 'and City_Code  like ''%'+@citycode +'%'''

end


if(@pubcent <> '0' and @pubcent <> '')

--print(@pubcent)

begin

set @query  =  @query + 'and pubcent_code  like ''%'+@pubcent +'%'''

end



if(@country <> '0' and @country <> '')

--print(@country)

begin

set @query  =  @query + 'and Country_Code  like ''%'+@country +'%'''

end

if(@branchname <> '0' and @branchname <> '')
begin
   set @query  =  @query + 'and Branch_code  like ''%'+@branchname +'%'''
end

print(@query)

exec(@query)


--saurabh added



/*declare retainer cursor read_only
for 

select Retain_Code from #RetainerMaster order by Retain_Code

open retainer

FETCH NEXT FROM retainer
INTO @retainer1

WHILE @@FETCH_STATUS = 0
BEGIN

set @query2='update #RetainerMaster set Retain_status =(select  status_name from tblstatus where status_code = (select top 1 status_name from RET_STATUS_DETAIL where retain_code='''+RTRIM(LTRIM(@retainer1))+'''  order by to_date desc)) where retain_code='''+@retainer1+''''

set @query3='update #RetainerMaster set status_date=(select top 1 to_date from RET_STATUS_DETAIL where retain_code='''+@retainer1+''' order by to_date desc) where retain_code='''+@retainer1+''''

set @query4='update #RetainerMaster set To_date=(select top 1 from_date from RET_STATUS_DETAIL where retain_code='''+@retainer1+''' order by from_date asc) where retain_code='''+@retainer1+''''

print(@query2)

exec(@query2)

print(@query3)

exec(@query3)

print(@query4)

exec(@query4)

FETCH NEXT FROM retainer
	INTO @retainer1


end

CLOSE retainer
DEALLOCATE retainer

select  *  from #RetainerMaster  order by  Retain_Code

drop table     #RetainerMaster*/










//**********************************************************************************************************************************
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER proc [dbo].[AdvTeamDetailSave]


@Comp_Code as varchar(8),
@Team_Code as varchar(8),
@Team_Name as varchar(20),
@userid as varchar(8),
@zone as varchar(50),
@signature as varchar(50)
as 



  insert into Adv_Exec_Master(Comp_Code,Team_Code,Team_Name,userid,creation_datetime,branch_code,SIGN) values(@Comp_Code,@Team_Code,@Team_Name,@userid,getdate(),@zone,@signature)

//****************************************************************************************************************************************
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go









ALTER  proc [dbo].[AdvTeamDetail]
(
@Comp_Code as varchar(8),
@Team_Code as varchar(8),
@Team_Name as varchar(20),
@userid as varchar(8),
@zone as varchar(50),
@Flag as int,
@signature as varchar(50)
)

as


CREATE TABLE #Adv_Exec_Master_tmp(
	Comp_Code varchar (8)  ,
	Team_Code varchar (8)  ,
	Team_Name varchar (20)  ,
    Userid varchar (8)  ,
	ad_cat varchar (50) ,
	Creation_Datetime datetime ,
    branch_code varchar(50),
	SIGN varchar(50)
) 


declare @countnum int
declare @query as varchar (1500)

set @Team_Code=replace(@Team_Code,'','''')
--set @Team_Name=replace(@Team_Name,'','''')


if(@Flag=0)
begin
 set  @query='insert #Adv_Exec_Master_tmp select  Comp_Code,Team_Code,Team_Name,userid,creation_datetime,ad_cat,branch_code,SIGN  from Adv_Exec_Master  where Comp_Code='''+@Comp_Code+''' '  ---and userid='''+@userid+'''and Team_Code like '%''@Team_Code''%' and Team_Name like '%@Team_Name%'


if(@Team_Code <>'')
begin
set @query=@query+'and Team_Code like ''%'+@Team_Code+'%'''
end

if(@Team_Name <>'')
begin
set @query=@query+'and Team_Name like ''%'+@Team_Name+'%'''
end

/*if(@cat <>"0")
begin
set @query=@query+'and ad_cat like''%'+@cat+'%'''
end */

if(@zone <> '0')
begin
set @query=@query+'and branch_code like''%'+@zone+'%'''
end

print(@query)
exec(@query)
		
select * from #Adv_Exec_Master_tmp where  Comp_Code = @Comp_Code --and userid=@userid
end

else if(@Flag=1)
	begin
	      insert into Adv_Exec_Master(Comp_Code,Team_Code,Team_Name,userid,creation_datetime,branch_code,SIGN) values(@Comp_Code,@Team_Code,@Team_Name,@userid,getdate(),@zone,@signature) 
        --insert  Exec_mast select Team_code,Exec_name,Designation,Add1,Street,Country_code,State_code,dist_code,city_code,zip,phone,exe_status,userid,comp_code,creation_datetime,pin_code from tmp_exec_mast where Team_code = @Team_Code and comp_code = @Comp_Code and userid=@userid
	end

else if(@Flag=2)
	begin

		declare @teamnm as varchar(30)
		declare @regionnm as varchar(30)
			update Adv_Exec_Master set Team_Name=@Team_Name  , branch_code=@zone,SIGN=@signature where Team_Code=@Team_Code and Comp_Code=@Comp_Code  --and userid=@userid	
             -- update exec_mast set Branch_code=@zone where Team_code=@Team_Code and comp_code=@Comp_Code
          --update temp_Adv_Exec set Team_Name = @Team_Name where Team_Code = @Team_Code	and Comp_Code = @Comp_Code and userid=@userid
    end

else if(@Flag=3)
	begin
		print(@Flag)
select @countnum=count(*) from tbl_booking_mast where executive_code in(select exe_no from Exec_mast where Team_Code = @Team_Code)
	if @countnum = 0 
	begin
		delete from Adv_Exec_Master where  Comp_Code=@Comp_Code and Team_Code = @Team_Code and Team_Name = @Team_Name and   branch_code=@zone  --and userid=@userid  
		delete from Exec_mast where  Comp_Code = @Comp_Code and Team_Code = @Team_Code --and userid=@userid
        delete from exec_adcat where TEAMCODE=@Team_Code    
	end
 --delete from temp_Adv_Exec where  Comp_Code = @Comp_Code and Team_Code = @Team_Code and Team_Name = @Team_Name and userid=@userid
	end
else if(@Flag=5)
	begin
		/*check if the team code is present or not */
		select * from exec_mast where  Comp_Code = @Comp_Code and Team_Code = @Team_Code --and userid=@userid
	end
else if(@Flag=6)
	begin
		select * from adv_exec_master where  Comp_Code = @Comp_Code and Team_Code = @Team_Code --and userid=@userid
	end
else
	begin
		select * from #Adv_Exec_Master_tmp where Comp_Code = @Comp_Code  --and userid=@userid
	end

drop table #Adv_Exec_Master_tmp











//*****************************sql mimoh 31oct 2011**********end*******-0005464/**********************

//*********************************mimoh 31 oct  2011*********0005467 *******start *************************//

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

















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
ALLOWED_PDC_DAYS_RECEIPT,AD_TYPE_MANUL_BILL, OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD,DISP_AUDITBKG,CIR_DIS_AUTO_POSTING,RELAUTHREQON
           FROM PREFERRENCES
          WHERE comp_code = @compcode


//****************************************************************************************************//
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




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
@p_Authorization as VARCHAR(1)
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

ALLOWED_PDC_DAYS_RECEIPT=@P_ALLOW_PDC,AD_TYPE_MANUL_BILL=@PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=@RO_OUTSTAND_P,GENRATE_CIR_AGCD=@genrate_agency_code,DISP_AUDITBKG=@p_dispauditbk,CIR_DIS_AUTO_POSTING=@p_aotosupply,RELAUTHREQON=@p_Authorization

 WHERE comp_code=@compcode




/* ,
',Unsold_Entry_Flag='''+@Unsoldflag+''',Supply_Stop_Percentage='''+@Supplystopper+'''

,ROKEYCHECK='''+@drpRokeychk+''',AGENCYCOMM_SEQ_COM='''+@Agencycomm_seq+''' ,CREDIT_RECIPT='''+@creditreciept+''' where    comp_code='''+@compcode+'''   ' 



--,DISP_CASHBILL='''+@cashindisplay+''',CLA_CASHBILL='''+@cashinclassified+'''
*/

print(@query1)
exec(@query1)


//*********************************mimoh 31 oct  2011*********0005467 *******end *************************//


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





ALTER   PROCEDURE [dbo].[pubexecute]
@compcode varchar(8),
@pubcode varchar(8),
@pubname varchar(30),
@pubalias varchar(30),
@langcode varchar(8),
--@userid varchar(8),
@pubtype  varchar(10),
@preocity  varchar(50)
--@gutter_space  int,
--@column_space  int


AS
--delete  publicationfirst 

declare @query as varchar(3000)



CREATE TABLE #Publicationfirst (
	Comp_Code varchar (8) ,
	Priority varchar (4) ,
	Pub_Code varchar (8) ,
	Pub_Name varchar (30) ,
	pub_alias varchar (30) ,
	Lang_Code varchar (8) ,
	Establish_Date datetime ,
	Cont_Person varchar (30) ,
	Phone varchar (5) ,
	Fax varchar (5) ,
	EmailID varchar (50) ,
	UserId varchar (8) ,
	Creation_Datetime datetime ,
	publication_type varchar (10) ,
	preodicity varchar (9) ,
	Phone1 varchar (10) ,
	Fax1 varchar (10) ,
	Gutter_Space varchar(10) ,
	Column_Space varchar(10),
	hr  varchar(10),
	mint  varchar(10),
	prod  varchar(10),
	No_Of_Collumn varchar(5),
    PUBLISHER_CODE  varchar(8),
prefix_pub_name varchar(10),
auto_number int
	
)




set @query='insert into #Publicationfirst select * from PUB_MAST where Comp_Code='''+@compcode+''''-- and userid='''+@userid+'''' 

if(@pubcode <> '')
print(@pubcode)
begin
set @query= @query + 'and  pub_code like ''%'+@pubcode+'%''' 					--'''+@pubcode+''''
end

if(@pubname <> '')
print(@pubname)
begin
set @query  =  @query + 'and pub_name  like ''%'+@pubname+'%'''					--'''+@pubname+''''      -- ''%'+@pubname+'%'''
end

if(@pubalias <> '')
print(@pubalias)
begin
set @query  =  @query + 'and pub_alias  like ''%'+@pubalias+'%'''				--'''+@pubalias+''''		--''%'+@pubalias+'%'''
end

if(@langcode <>'' and @langcode <> '0')
begin
set @query  =  @query + 'and lang_code  like ''%'+@langcode+'%'''				--'''+@langcode +''''			---''%'+@pubalias+'%'''
end

if(@preocity <>'' and  @preocity <>'0')
begin
set @query  =  @query + 'and preodicity  like  ''%'+@preocity +'%''' 				--'''+@preocity +''''		-- ''%'+@preocity +'%'''
end


if(@pubtype <>'' and @pubtype <>'0')
begin
set @query  =  @query + 'and publication_type  like  ''%'+@pubtype +'%''' 				--'''+@preocity +''''		-- ''%'+@preocity +'%'''
end

--if(@Gutter_space <>"")
--begin
--set @query  =  @query + 'and gutter_space  like ''%'+@gutter_space +'%'''
--end


--if(@column_space<>"")
--begin
--set @query  =  @query + 'and column_space  like ''%'+@column_space+%'''
--end



print(@query)
exec(@query)



select   distinct  *,prefix_pub_name AS PREFIX  from #Publicationfirst  order by Pub_Code
--drop table #Publicationfirst






































