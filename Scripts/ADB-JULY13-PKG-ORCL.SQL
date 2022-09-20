-----------------09/07/2013-----updated by hemant----------open---------
CREATE OR REPLACE PROCEDURE HT18JULY.GetAgency_agency  (
compcode  varchar2,  
client  varchar2,  
value1  varchar2,
p_accounts    OUT      cur_type_new1.cursor_type
)  
  
AS  
begin
  
if value1 ='0'  then 
open P_Accounts for
select    "SUB_Agency_Code","Agency_Name" from Agency_mast where "Comp_Code"=compcode and "SUB_Agency_Code" =client; --and  "type"='P';  
end if; 
  
if value1 ='1' then  
open P_Accounts for
select "Cust_Code","Cust_Name","Add1" from cust_mast where "Comp_Code"=compcode and "Cust_Code"=client;  
end if ;
/*  
if(@value="2")  
begin  
select prod_cat_code,prod_desc from product_cat_mast where comp_code=@compcode and prod_cat_code=@client  
end*/  
if value1='3' then 
open P_Accounts for
select  distinct  "SUB_Agency_Code","Agency_Name","Agency_Code" from Agency_mast where "Comp_Code"=compcode and "code_subcode"=client;   
end if; 

end GetAgency_agency;
/
-------------------09/07/2013----------------updated by hemant------close