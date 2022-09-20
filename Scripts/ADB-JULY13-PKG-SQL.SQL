----------09/07/2013---------updated by hemant---------open---------
CREATE PROCEDURE [dbo].[GetAgency_agency]  
@compcode as varchar(8),  
@client as varchar(8),  
@value as varchar(2)  
  
AS  
  
if(@value="0")  
begin  
--select  distinct  Agency_Code,agency_name from Agency_mast where comp_code=@compcode and code_subcode =@client and  type='P'  
  
select  distinct  sub_agency_code,agency_name from Agency_mast where comp_code=@compcode and sub_agency_code =@client and  type='P'  
end  
  
if(@value="1")  
begin  
select Cust_Code,Cust_Name,Add1 from cust_mast where comp_code=@compcode and Cust_Code =@client  
end  
/*  
if(@value="2")  
begin  
select prod_cat_code,prod_desc from product_cat_mast where comp_code=@compcode and prod_cat_code=@client  
end*/  
if(@value="3")  
begin  
--select  distinct  Agency_Code,agency_name from Agency_mast where comp_code=@compcode and code_subcode =@client and  type='P'  
  
select  distinct  sub_agency_code,agency_name,agency_code from Agency_mast where comp_code=@compcode and agency_code+sub_agency_code =@client   
end



/////////////////////second procedure///////////////////////
  
  
create procedure agency_secinsert  
@COMP_CODE varchar(15),  
@AG_MAIN_CODE varchar(15),  
@AG_SUB_CODE varchar(15),  
@SEC_RATE_TYPE varchar(1),  
@SEC_RATE varchar(10),  
@SEC_LIMIT_AMT varchar(15),  
@CREATED_BY varchar(15),  
@CREATED_DATE as varchar(15),  
@flag as varchar(15)  
  
as   
if(@flag='sav')  
begin  
insert into AGENCY_SECURITY_MAST(COMP_CODE,AG_MAIN_CODE,AG_SUB_CODE,SEC_RATE_TYPE,SEC_RATE,SEC_LIMIT_AMT,CREATED_BY,CREATED_DATE)  
 values (@COMP_CODE,@AG_MAIN_CODE,@AG_SUB_CODE,@SEC_RATE_TYPE,@SEC_RATE,@SEC_LIMIT_AMT,@CREATED_BY,@CREATED_DATE)  
 end  
   
 if(@flag='up')  
begin  
 update  AGENCY_SECURITY_MAST set SEC_RATE_TYPE=@SEC_RATE_TYPE,SEC_RATE=@SEC_RATE,SEC_LIMIT_AMT=@SEC_LIMIT_AMT  
,UPDATED_BY=@CREATED_BY,UPDATED_DATE=@CREATED_DATE  where AG_MAIN_CODE=@AG_MAIN_CODE and AG_SUB_CODE=@AG_SUB_CODE  
 end


//////////////third procedure///////////////////////////////
CREATE Procedure [dbo].[bindagencyforxls](  
@compcode as varchar(10),  
@agency as varchar(50)  
)  
 As  
  
declare @qry  varchar(2000)  
Begin  
  
  
select  distinct  Agency_Code,Agency_Name+'-'+(Select distinct city_name from city_mst x where x.City_Code=Agency_mast.City_Code)  
+'-'+Add1++'-'+Add2+'-'+Add3+Street AS Agency_Name,code_subcode, SUB_Agency_Code,agency_code,Agency_Name as Agencynam from Agency_mast where (Comp_Code=@compcode) and Agency_Name like '%'+ @agency + '%'  and (Type='P') order by Agency_Name  
  
End  
//////////////////forth procedure//////////////////////////////////////
CREATE    PROCEDURE bindclientforxls (  
      @compcode     as       VARCHAR(10),  
      @client as varchar(50)  
        
   )  
   AS  
   BEGIN  
        
         SELECT Cust_Name, Cust_Code  
           FROM cust_mast  
          WHERE Comp_Code = @compcode and Cust_Name like  @client + '%' order by Cust_Name  
   END
///////////////////fifth procedure//////////////////////////////
create  PROCEDURE websp_getBrand1    
@compcode varchar(50),@pro varchar(50)    
AS    
--select brand_code,brand_name from brand_mst where prod_code in(select prosubcode from pro_subsub_catmast where pro_cat_code=@procat) and comp_code=@compcode    
  
select brand_code,brand_name from brand_mst where brand_name like (@pro+'%')  and comp_code=@compcode  

///////////////////////////////sixth procedure///////////////////////
CREATE procedure [deal_comparison_report](    
    
@comp_code as varchar(400),    
@agency_code  as varchar(400),    
@product_code as varchar(400),    
@client_code as varchar(400),    
@from_dt  as datetime,    
@to_dt as datetime)    
 as    
declare @v_query varchar(4000)    
begin    
    
--set @v_query='select a.Deal_code,b.agency_code,b.client_code,b.product_code,b.from_date,b.till_date,a.contract_amount    
-- from contract_detail a,contract_mast b    
--where  a.comp_code=b.comp_code and a.comp_code='''+@comp_code+'''    
--and b.agency_code='''+@agency_code+'''     
-- and a.creation_datetimetime between '''+@from_dt+''' and '''+@to_dt+''''    
-- if @client_code is not null    
-- begin    
-- set @v_query=@v_query+' and b.client_code='''+@client_code+''' '    
-- end    
-- if @product_code is not null begin    
--  set @v_query=@v_query+'and b.product_code='''+@product_code+''''    
--  end    
--  print @v_query    
--  exec @v_query    
select a.Deal_code,(select agency_name from agency_mast where agency_code=b.agency_code) agency_name,(select cust_name from cust_mast where cust_code=b.client_code) as cust_name,  
b.product_code,b.from_date,b.till_date,a.contract_amount    
 from contract_detail a,contract_mast b    
where  a.comp_code=b.comp_code and a.comp_code=@comp_code    
and b.agency_code=@agency_code  and a.Deal_code=b.deal_no  
 and a.creation_datetimetime between @from_dt and @to_dt    
  end 



  
-----------------09/07/2013--------------updated by hemant---------close-------