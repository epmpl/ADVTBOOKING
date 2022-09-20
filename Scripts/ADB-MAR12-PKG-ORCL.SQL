@@@@@@@@@@@@@@@@@@@@@@@@@@@@ fmg reasion by bhanu @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

ALTER TABLE HT18JULY.TBL_BOOKING_FMG_TRANS_g
ADD (FMG_REASONS  VARCHAR2(50 BYTE));

 ALTER TABLE HT18JULY.TBL_BOOKING_FMG_TRANS
ADD (FMG_REASONS  VARCHAR2(50 BYTE));


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


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
 query1:='select distinct tbl_booking_insert."Cio_Booking_Id",tbl_booking_insert."Col_Code" as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION","Insert_Id",to_char("Insert_Date",''dd/mm/yyyy'') as "Insert_Date","Gross_Rate","Bill_Amt","RO_No" from tbl_booking_insert,tbl_booking_mast where
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
query1:='select distinct tbl_booking_insert."Cio_Booking_Id",tbl_booking_insert."Col_Code" as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION","Insert_Id",to_char("Insert_Date",''dd/mm/yyyy'') as "Insert_Date","Gross_Rate","Bill_Amt","RO_No" from tbl_booking_insert,tbl_booking_mast where tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and tbl_booking_insert."Comp_Code"='''||comecode||'''  and tbl_booking_mast."Agency_sub_code"= '''||agency||''' and tbl_booking_mast."Ad_type_code"= '''||p_adtye||''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')';
 query1:=query1 || ' and tbl_booking_insert."Insert_Id" in(select edition_name from result)';
  open  p_Accounts for
 query1;
end if;
 
 

end;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
clienttype varchar2,
translation in varchar2,
translationcharge in number,
fmgreasons in varchar2,
p_revisedate IN       DATE
);
End updatebooking;
/

CREATE OR REPLACE PACKAGE BODY updatebooking IS
PROCEDURE updatebooking_p(
approvedby      in varchar2,
audit1          in varchar2,
rono            in varchar2,
rodate          in date,
caption         in varchar2,
billstatus      in varchar2,
rostatus        in varchar2,
agency          in varchar2,
client          in varchar2,
agencyaddress   in varchar2,
clientaddresses in varchar2,
agencycode      in varchar2,
dockitno        in varchar2,
execname        in varchar2,
execzone        in varchar2,
product         in varchar2,
brand           in varchar2,
keyno           in varchar2,
billremark      in varchar2,
printremark     in varchar2,
package1        in varchar2,
insertion       in number,
startdate       in date,
repeatdate      in varchar2,
adtype1         in varchar2,
adcategory      in varchar2,
subcategory     in varchar2,
color           in varchar2,
uom             in varchar2,
pageposition    in varchar2,
pagetype1       in varchar2,
pageno          in number,
adsizheight     in number,
adsizwidth      in number,
ratecode11      in varchar2,
scheme1         in varchar2,
currency        in varchar2,
agreedrate      in number,
agreedamt       in number,
spedisc         in number,
spacedisx       in number,
compcode        in varchar2,
userid          in varchar2,
ciobookid       in varchar2,
date_time       in date,
branch          in varchar2,
booked_by       in varchar2,
prevbook        in varchar2,
adsizetype      in varchar2,
specialcharges  in number,
agencytype      in varchar2,
agencystatus    in varchar2,
paymode         in varchar2,
agencredit      in number,
cardrate        in number,
cardamount      in number,
discount        in number,
discountper     in number,
billaddress     in varchar2,
totarea         in number,
billcycle       in varchar2,
revenuecenter   in varchar2,
billpay         in varchar2,
billheight      in number,
billwidth       in number,
billto          in varchar2,
invoices        in number,
vts             in number,
tradedisc       in number,
agencyout       in varchar2,
boxcode         in varchar2,
boxno           in varchar2,
boxaddress      in varchar2,
boxagency       in varchar2,
boxclient       in varchar2,
bookingtype     in varchar2,
tfn             in varchar2,
coupan          in varchar2,
campaign        in varchar2,
bill_amt        in number,
pageprem        in varchar2,
pageamt         in number,
premper         in number,
grossamt        in number,
adsizcolumn     in number,
billarea        in number,
billcolumn      in number,
spacediscper    in number,
specdiscper     in number,
paidins         in number,
dealrate        in number,
deviation       in number,
varient         in varchar2,
dealtype        in varchar2,
contractname    in varchar2,
cardname        in varchar2,
cardtype        in varchar2,
cardmonth       in varchar2,
cardyear        in varchar2,
cardno          in varchar2,
receiptno       in varchar2,
adscat3         in varchar2,
adscat4         in varchar2,
adscat5         in varchar2,
bgcolor         in varchar2,
bulletcode      in varchar2,
bulletprm       in number,
material        in varchar2,
region1         in varchar2,
varient_name    in varchar2,
coltype         in varchar2,
logo_h          in varchar2,
logo_w          in varchar2,
logo_col        in varchar2,
logo_uom        in varchar2,
retainer1       in varchar2,
addagencyrate   in varchar2,
mobileno        in varchar2,
addlamt         in varchar2,
retamt          in varchar2,
retper          in varchar2,
cashrecieved    in varchar2,
CIRAGENCY_V     in varchar2,
CIRRATE_V       in varchar2,
CIREDITION_V    in varchar2,
CIRPUBLICATION_V    in varchar2,
CIRAGENCYSUBCODE_V  in varchar2,
BARTERTYPE          IN VARCHAR2,
CASHDISCOUNT_V      IN VARCHAR2,
CASHDISCOUNTPER_V   IN VARCHAR2,
attach1             in varchar2,
attach2             in varchar2,
drpdiscprem         in varchar2,
doctype_v           in varchar2,
CHKTRADE            IN VARCHAR2,
sharepub_p          in varchar2,
fmginsert           in varchar2,
chkno               in VARCHAR2,
chkdate             in date:=null,
chkamt              in VARCHAR2,
chkbankname         in varchar2,
ourbank             in varchar2,
DEALERPANEL_P       in VARCHAR2,
DEALERH_P           in FLOAT,
DEALERW_P           in FLOAT,
DEALERTYPE_P        in VARCHAR2,
multiselect         in VARCHAR2,
AGREEDRATE_ACTIVE   IN NUMBER,
AGREEDAMT_ACTIVE    IN NUMBER,
grossamtlocal_p     IN number,
billamtlocal_p      IN number,
chkadon_p           IN varchar2,
refid_p             IN varchar2,
rcpt_currency       IN varchar2,
cur_convrate        IN varchar2,
clienttype          IN varchar2,
translation         in varchar2,
translationcharge   in number,
fmgreasons in varchar2,
p_revisedate        IN DATE
)As
error1          varchar2(100);
sccode          varchar2(50);
mobileno1       varchar2(50);
remarks         varchar2(500);
clientname      varchar2(200);
v_modifed_audit varchar2(1);
v_audit_exist   number(1);
Begin

mobileno1:=mobileno;
--begin
--select distinct "scheme_id" into  sccode  from scheme_master where "Scheme_Name"=ltrim(rtrim(scheme1)) and "Comp_code"=compcode;
--exception when no_data_found then
--NULL ;
--end;  

sccode:=scheme1;


v_modifed_audit:=null;

If audit1 is null and rostatus='1' then
    
    /*select count(*) into v_audit_exist from
    (select count(*) from tbl_booking_mast 
        where "Comp_code"=compcode and "cio_booking_id"=ciobookid and "ro_status"='1' and "audit" is not null
    union
    select count(*) from tbl_booking_mast 
    where "Comp_code"=compcode and "cio_booking_id"=ciobookid and "ro_status"='1' and nvl(modified_audit,'N')='Y') x;
    
    If v_audit_exist>0 then 
        v_modifed_audit:='Y';
    End if;*/
    begin
    select  case when "audit" is not null then 'Y' 
                 when nvl(modified_audit,'N')='Y' then 'Y' 
            else null  End as modifed_audit into v_modifed_audit from tbl_booking_mast 
        where "Comp_code"=compcode and "cio_booking_id"=ciobookid and "ro_status"='1';
                   EXCEPTION
                   WHEN NO_DATA_FOUND THEN  NULL;
                   end;
End If;


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
PACKAGE_TYPE=chkadon_p, AD_REFID=refid_p,RECEIPT_CURRENCY=rcpt_currency,CONV_CURR_RATE=cur_convrate,REVISE_DATE=p_revisedate,CLIENT_TYPE=clienttype,TRANSLATION_CODE=translation, TRANSLATION_PREMIUM=translationcharge,
MODIFIED_AUDIT=v_modifed_audit
where "Comp_code"=compcode and "cio_booking_id"=ciobookid;

    IF sharepub_p is not null then
        insert_sharepub_details(sharepub_p,ciobookid,'UPDATE',error1);
    end if;

    delete from TBL_BOOKING_FMG_TRANS where CIOID=ciobookid;
    if fmginsert is not null then
        insert_fmgTrans_details(fmginsert,ciobookid,'UPDATE',error1,fmgreasons);   
    end if;
      
    if multiselect is not null then
        insert_multiexec_details(userid,compcode,multiselect,ciobookid,'UPDATE',error1);
    end if;
                       
if billpay = 'CA0' and rostatus='1' and (receiptno is null or receiptno = '') then

    declare
        cursor c1 is
            select * from tbl_booking_mast where "cio_booking_id"=ciobookid;
       
    v1 c1%rowtype;
    v_error         varchar2(2000);
    v_rcptno_r      varchar2(50);
    vrecpt          varchar2(20);
    branchcode      varchar2(20);
    vrepcode        varchar2(20);
    subagencyreg    varchar2(20);
    prevcioid_v     varchar2(50);
    billamt_v       float;
    grossamt_v      float;
    v_curdate       date;
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
            vrecpt      :=v1."Receipt_no";
            prevcioid_v :=v1."prev_cioid";

            if prevcioid_v is null or v1."prev_receipt" is null then
                billamt_v   :=v1."Bill_amount";
                grossamt_v  :=v1."Gross_amount";
                v_curdate   :=v1."date_time";
            else
                select "Bill_amount","Gross_amount" into  billamt_v,grossamt_v from tbl_booking_mast where "cio_booking_id"=prevcioid_v;
                billamt_v   :=v1."Bill_amount" - billamt_v;
                grossamt_v  :=v1."Gross_amount" - grossamt_v;
                v_curdate   :=to_date(sysdate);
            end if;
        
            -- select substr(max("recptno"),1,12)||lpad(substr(max("recptno"),-6)+1,6,'0') into vrecpt from ad_rcpthdr where "unit"=branchcode and "doctype"='RCP' and
            -- "recptdt" between '1-mar-2011' and '31-mar-2011';
             
            --receiptsave_booking.receiptsave_booking_P(pcompcode,puserid , punit ,ptype , precpt , prdate , ppaymodres ,preceivedreg ,pvouno  ,pamount  ,pagency , pothercd ,
            --pchno  ,pchedate , pbank  , pnarration ,prep   , pvdate , pag_main_code ,pag_sub_code , ourbank,  cioid , execname , retainer ,
            -- prevcioid , p_error)
                
            Begin
                SELECT "Cust_Name" into clientname FROM CUST_MAST WHERE "Cust_Code" = v1."Client_code" and "Comp_Code"=v1."Comp_code";
            Exception when NO_DATA_FOUND THEN
                clientname:=v1."Client_code";
            END;

            remarks:='RONO#'||v1."RO_No" ||' RODATE# ' || to_char(v1."RO_Date",'dd-mon-yyyy') || ' BOOKINGID# ' || v1."cio_booking_id" || ' CLIENT#' || clientname;

            receiptsave_booking.receiptsave_booking_p(v1."Comp_code",v1."Userid", v1."branch",v1.DOCTYPE,vrecpt,v_curdate,v1."Bill_pay",'','',billamt_v,v1."Agency_sub_code",grossamt_v,
            '','','',remarks,vrepcode,v1."date_time",v1."Agency_code",subagencyreg,'',v1."cio_booking_id",v1."Executive_code",v1.RETAINER,v1."prev_cioid",v_rcptno_r,v_error);
       
            update tbl_booking_mast set "Receipt_no"=v_rcptno_r,"Receipt_date"=v_curdate where "cio_booking_id"=v1."cio_booking_id";
        close c1;
        commit;
    End;
End if;
 
end updatebooking_p;
End updatebooking;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

CREATE OR REPLACE PROCEDURE fetchFMGrefID
(
    cioid_p     in varchar2,
   p_accounts   OUT   cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      --    select INSERTID from TBL_BOOKING_FMG_TRANS where cioid=cioid_p;
       select TBL_BOOKING_FMG_TRANS.INSERTID,"Col_Code","Height","Width","Size_Book",FMG_REASONS from tbl_booking_insert,TBL_BOOKING_FMG_TRANS 
 where tbl_booking_insert."Insert_Id"=TBL_BOOKING_FMG_TRANS.INSERTID
-- and tbl_booking_insert."Cio_Booking_Id"=TBL_BOOKING_FMG_TRANS.cioid
 and TBL_BOOKING_FMG_TRANS.cioid=cioid_p;
END;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE committransaction(
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
    INSERT INTO TBL_BOOKING_MAST("date_time", "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by", "audit", "RO_No", "RO_Date", "Caption", "bill_status", "ro_status", "Agency_code", "Agency_address", "Client_code", "Client_address", "Agency_sub_code", "Dockit_no", "Executive_code", "Executive_zone", "Product_code", "Brand_code", "Key_no", "Bill_remarks", "Print_remark", "Package_code", "No_of_insertion", "Insertion_date", "Repeating_day", "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code", "Color_code", "Uom_code", "Page_position_code", "Page_type_code", "Page_no", "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code", "Scheme_type_code", "Currency_code", "Agrred_rate", "Agreed_amount", "Special_discount", "Space_discount", "Special_charges", "Agency_status", "Agency_type", "Agency_pay", "Agency_credit", "Total_area", "Card_rate", "Card_amount", "Discount", "Discount_per", "Bill_cycle", "Revenue_center", "Bill_pay", "Bill_height", "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc", "Agency_out", "Box_code", "Box_no", "Box_agency", "Box_client", "Box_address", "Comp_code", "Userid", "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad", "Campaign", "Bill_amount", "Page_prem", "Page_amount", "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", "Bill_area", "Special_disc_per", "Space_disc_per", "Paid_ins", "Contract_rate", "Deviation", "Variant_code", "Contract_name", "Contract_type", "Card_name", "Card_type", "Card_month", "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", "Bullet_code", "Bullet_premium", "Material_status", "Receipt_date", "prev_cioid", "prev_receipt", "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom", "SAPID", "RETAINER", "ADD_AGENCY_COMM", "AUDIT_COMMENT", "MOBILENO", "ADD_AGENCY_COMM_AMT", "RETAINER_COMM", "RETAINER_COMM_AMT", "CASH_RECIEVED", "CONT_GROSS", "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION", "CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER", "RODOCSTATUS",CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID,RECEIPT_CURRENCY, CONV_CURR_RATE,REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM) 
    SELECT DATE_TIME, BRANCH, BOOKED_BY, newid CIO_BOOKING_ID, PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO, RO_DATE, CAPTION, BILL_STATUS, RO_STATUS, AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE, CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO, EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE, BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK, PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE, REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE, AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE, PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO, AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH, RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE, AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT, SPACE_DISCOUNT, SPECIAL_CHARGES, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY, AGENCY_CREDIT, TOTAL_AREA, CARD_RATE, CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE, REVENUE_CENTER, BILL_PAY, BILL_HEIGHT, BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD, TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO, BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS, COMP_CODE, USERID, CREATION_DATETIME, BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN, BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER, GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN, BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER, PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE, CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME, CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER, RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, BG_COLOR, BULLET_CODE, BULLET_PREMIUM, MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID, PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT, COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR, LOGO_UOM, SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO, ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS, CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, RODOCSTATUS,CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK, DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE,ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=pcioid;

    INSERT INTO TBL_BOOKING_insert("Insert_Id", "Cio_Booking_Id", "No_Insert", "Edition_Code", "Publication_Code", "Pub_Cent_Code", "Supp_Code", "Edition", "Insert_Date", "Col_Code", "Height", "Width", "Size_Book", "Page_Post", "Premium1", "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow", "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Repeating_Date", "Status_Material", "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status", "Bill_Status", "Agreed_Rate", "Pai_Free_Ins", "Solo_Rate", "Gross_Rate", "Comp_Code", "Userid", "Page_No", "Remarks", "Pub_Height", "Pub_Width", "Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5", "PACKAGE_CODE", "BILL_NO", "BILL_DATE", "INSERTS", "PKG_ALIAS", "CONT_GROSS_AMT", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER",SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT, LOCALBILLAMT,SECTIONCODE,RESOURCE_NO,CAPTION) 
    SELECT INSERT_ID, newid CIO_BOOKING_ID, NO_INSERT, EDITION_CODE, PUBLICATION_CODE, PUB_CENT_CODE, SUPP_CODE, EDITION, INSERT_DATE, COL_CODE, HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1, PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW, AD_CAT, AD_SUB_CAT, LATEST_BY, REPEATING_DATE, STATUS_MATERIAL, FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS, BILL_STATUS, AGREED_RATE, PAI_FREE_INS, SOLO_RATE, GROSS_RATE, COMP_CODE, USERID, PAGE_NO, REMARKS, PUB_HEIGHT, PUB_WIDTH, PAGE_PREM, PAGE_PER, NO_OFCOLUMN, BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, PACKAGE_CODE, BILL_NO, BILL_DATE, INSERTS, PKG_ALIAS, CONT_GROSS_AMT, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, SPECIAL_SIZE1,VATAMT, BOXCHARGE, VAT_INC,LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO,CAPTION FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=pcioid;

    INSERT INTO TBL_BOOKING_VTS(COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE) 
    SELECT COMPCODE, newid CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE FROM TBL_BOOKING_VTS_G WHERE  cioid=pcioid;

    insert into tbl_booking_insert_sizesplit(CIOID, RECEIPTNO, INSERTID, INSERTDATE, HEIGHT, WIDTH, AREA, SRNO, CREATIONDATETIME)
    select newid CIOID, RECEIPTNO, INSERTID, INSERTDATE, HEIGHT, WIDTH, AREA, SRNO, CREATIONDATETIME from tbl_booking_insert_sizesplit_g where cioid=pcioid;

    --INSERT INTO ABCTEST VALUES(newid,counttest);
    insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO, NO_INSERT,PAGE_NO)
    select COMP_CODE, newid CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO, SRNO, NO_INSERT,PAGE_NO from tbl_booking_subedition_g
    where tbl_booking_subedition_g.CIOID=pcioid;

    insert into TBL_BOOKING_SHARING_TRANS(PUBLICATION, TYPE, SHARING, CIOID, SRNO)
    select PUBLICATION, TYPE, SHARING, newid CIOID, SRNO from TBL_BOOKING_SHARING_TRANS_g where CIOID=pcioid ;

    insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID, CREATIONDATETIME,FMG_REASONS)
    select newid CIOID, INSERTID, CREATIONDATETIME,FMG_REASONS from TBL_BOOKING_FMG_TRANS_G where CIOID=pcioid;
    
    update tbl_matter set "cioid"=newid where "cioid"=pcioid; 

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
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

CREATE OR REPLACE PROCEDURE insert_fmgTrans_details(p_str in varchar2,cioidm in varchar2,STATUS IN VARCHAR2 ,p_error_text out varchar2,fmgreasons in varchar)  IS
tmpVar NUMBER;
tmpStr VARCHAR2(4000);
l_str VARCHAR2(4000);
l_pub varchar2(50);
l_share varchar2(20);
l_type varchar2(10);
COUNTNUM NUMBER;
BEGIN
 --insert into abctest values(insertidm,l_status);
   tmpVar := 0;
   tmpStr := p_str;
   l_str := p_str;
    dbms_output.put_line('l_str:'||l_str);
   for i in 1..length(tmpStr)-length(replace(tmpStr,'$',null))+1 
   loop 
      
      if instr(tmpStr,'$') > 0 then 
         l_str := substr(tmpStr,1,instr(tmpStr,'$')-1);
         else
          l_str := tmpStr;
      end if;
     
     -- insert into abctest values(insertidm,'Str:'||l_status||':'||receiptnom||':'||editioncode||':'||pubcode||':'||insertidm||':'||compcodem||':'||cioidm||':'||l_date||':'||l_ed||':'||l_hight||':'||l_width||':'||l_size);
      tmpStr := substr(tmpStr,instr(tmpStr,'$')+1);

 IF STATUS = 'INSERT' THEN
 dbms_output.put_line('STATUS:'||STATUS);
   insert into TBL_BOOKING_FMG_TRANS_G(CIOID, INSERTID,CREATIONDATETIME,FMG_REASONS) 
   values(cioidm,l_str,SYSDATE,fmgreasons);
 ELSE 
    SELECT COUNT(*) INTO COUNTNUM FROM TBL_BOOKING_FMG_TRANS WHERE CIOID=cioidm AND insertid=l_str;
    IF(COUNTNUM=0) THEN
           insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID,CREATIONDATETIME,FMG_REASONS) 
           values(cioidm,l_str,SYSDATE,fmgreasons);
   -- ELSE
     
    END IF;       
 END IF;  
 commit;
  -- insert into 
   end loop;
 

exception 
   when others then 
p_error_text :=sqlerrm;       
END insert_fmgTrans_details;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
clienttype varchar2,
translation in varchar2,
translationcharge in number,
fmgreasons in varchar2,
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
clienttype varchar2,
translation in varchar2,
translationcharge in number,
fmgreasons in varchar2,
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
                    REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM
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
                    p_revisedate,clienttype,translation,translationcharge);
                  IF sharepub_p is not null then
                        insert_sharepub_details(sharepub_p,ciobookid,'INSERT',error1);
                  end if;
                  
                  if fmginsert is not null then
                    insert_fmgTrans_details(fmginsert,ciobookid,'INSERT',error1,fmgreasons);   
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
@@@@@@@@@@@@@@@@@@@@@@@@@@@@ fmg reasion by bhanu @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@



-----------start issue-6918------06-03-2012--------------------------

CREATE OR REPLACE function ro_book_allotmentno( pcomp_code  in varchar2,
            pissue_dt in varchar2,
            pdateformat in varchar2) return char is
 v_allotmentno varchar2(20);
 v_issue_dt date;
 Begin
        v_issue_dt:=to_date(pissue_dt,''''||pdateformat||'''');
  select max(to_number(substr(issue_no,-7))) into v_allotmentno from ro_book_allotment
      where comp_code=pcomp_code and to_char(issue_dt,'YY')=to_char(v_issue_dt,'YY');
       if v_allotmentno is null or v_allotmentno ='0' then
   v_allotmentno:=pcomp_code||to_char(v_issue_dt,'YY')||'00001';
  else
   v_allotmentno:=pcomp_code||lpad(to_number(v_allotmentno)+1,7,'0');
  end if;
  return v_allotmentno;
 End ro_book_allotmentno;


-----------end issue-6918------06-03-2012--------------------------
CREATE OR REPLACE PROCEDURE bindagencyfromadd
(
compcode            in varchar2,
userid              in varchar2,
agency              in varchar2,
pubcenter           in varchar2,
p_agencyaddress     in varchar2,
p_Accounts OUT Cur_Type_New1.cursor_type
)
 is
Begin
    if pubcenter = '0' or pubcenter is null then
        open p_Accounts for
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and "Agency_Name"||"Add1"||"Add2"||"Add3" like '%'||p_agencyaddress||'%'  order by "Agency_Name" ;

    else
        open p_Accounts for
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and "Agency_Name"||"Add1"||"Add2"||"Add3" like '%'||p_agencyaddress||'%' and "Dist_Code"=(select "Dist_Code" from branch_mst where "Branch_Code"=pubcenter) 
        order by "Agency_Name" ;
    end if;
END;
/

CREATE OR REPLACE PROCEDURE bindagencyfromadd
(
compcode            in varchar2,
userid              in varchar2,
agency              in varchar2,
pubcenter           in varchar2,
p_agencyaddress     in varchar2,
p_Accounts OUT Cur_Type_New1.cursor_type
)
 is
Begin
    if pubcenter = '0' or pubcenter is null then
        open p_Accounts for
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and "Agency_Name"||"Add1"||"Add2"||"Add3" like '%'||p_agencyaddress||'%'  order by "Agency_Name" ;

    else
        open p_Accounts for
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and "Agency_Name"||"Add1"||"Add2"||"Add3" like '%'||p_agencyaddress||'%' and "Dist_Code"=(select "Dist_Code" from branch_mst where "Branch_Code"=pubcenter) 
        order by "Agency_Name" ;
    end if;
END;
/
CREATE OR REPLACE PROCEDURE bindagencyfromadd
(
compcode            in varchar2,
userid              in varchar2,
agency              in varchar2,
pubcenter           in varchar2,
p_agencyaddress     in varchar2,
p_Accounts OUT Cur_Type_New1.cursor_type
)
 is
Begin
    if pubcenter = '0' or pubcenter is null then
        open p_Accounts for
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and "Agency_Name"||"Add1"||"Add2"||"Add3" like '%'||p_agencyaddress||'%'  order by "Agency_Name" ;

    else
        open p_Accounts for
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and "Agency_Name"||"Add1"||"Add2"||"Add3" like '%'||p_agencyaddress||'%' and "Dist_Code"=(select "Dist_Code" from branch_mst where "Branch_Code"=pubcenter) 
        order by "Agency_Name" ;
    end if;
END;
/
/*************************************6932**************************************************************/


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
p_CURRENCY_MEASUREMENT     IN VARCHAR2,
p_bookingapproval     IN VARCHAR2

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
p_CURRENCY_MEASUREMENT     IN VARCHAR2,
p_bookingapproval     IN VARCHAR2

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
RECORDS_ON_PAGE = p_paging,RECORDS_ON_PRINT = p_print,HEADER_ON_PAGE = p_allowpage,AGENCY_REQUIRED = p_agency_req,REGION_REQUIRED = p_region_req,ALLOW_FOLLOW_DT_BOOOK=p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=p_CURRENCY_MEASUREMENT,BOOK_AUDIT_REQ_AFTER_MOD =p_bookingapproval

  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/


*************************************************************************




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
        AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE ,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,"Space_area",BOOK_AUDIT_REQ_AFTER_MOD   
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/






/*************************************6932**************************************************************/

--------------start-------6918----12-03-2012--------------------------------

CREATE OR REPLACE PACKAGE Cir_Dynamic_DML IS
  procedure variable_insert_stmt(
      ptable_name in varchar2,
      pcolname in varchar2,
      pcolvalue in varchar2,
      pdelimiter in varchar2,
      pdateformat in varchar2,
      pextra1 in varchar2,
      pextra2 in varchar2);
  /*procedure variable_insert_stmt(
      ptable_name in varchar2,
      pcolname in varchar2,
      pcolvalue in varchar2,
      pdelimiter in varchar2,
      pdateformat in varchar2,
      pextra1 in varchar2,
      pextra2 in varchar2,
      p_error_text out varchar2);*/

  procedure variable_update_stmt(
      ptable_name in varchar2,
      pcolname in varchar2,
      pcolvalue in varchar2,
      pcond_colname in varchar2,
      pdelimiter in varchar2,
      pdateformat in varchar2,
      pextra1 in varchar2,
      pextra2 in varchar2);
  procedure variable_delete_stmt(
      ptable_name in varchar2,
      pcond_colname in varchar2,
      pcond_colval in varchar2,
      pdelimiter in varchar2,
      pdateformat in varchar2,
      pextra1 in varchar2,
      pextra2 in varchar2);
      type t_accounts_type is ref cursor;
  procedure variable_execute_stmt(
      ptable_name in varchar2,
      pcond_colname in varchar2,
      pcond_colval in varchar2,
      pdelimiter in varchar2,
      pdateformat in varchar2,
      pextra1 in varchar2,
      pextra2 in varchar2,
      p_accounts out t_accounts_type);
      type t_accounts is ref cursor;
   
   procedure variable_order(
      pcomp_code in varchar2,
      pcomp_val in varchar2,
      punit_code in varchar2,
      punit_val in varchar2,
      ptable_name in varchar2,
      pcolname in varchar2,
      porder in varchar2,
      pdateformat in varchar2,
      pextra1 in varchar2,
      pextra2 in varchar2,
      p_accounts out t_accounts);
END Cir_Dynamic_DML;
/

CREATE OR REPLACE PACKAGE BODY Cir_Dynamic_DML IS
PROCEDURE variable_insert_stmt(
    ptable_name     in varchar2,
    pcolname        in varchar2,
    pcolvalue       in varchar2,
    pdelimiter      in varchar2,
    pdateformat     in varchar2,
    pextra1         in varchar2,
    pextra2         in varchar2) as

    pstmt_str   varchar2(4000);
    v_sess_id   number;
cursor cur_stmt is

--delete from temp_col_ins;
--commit;
    select * from temp_col_ins  where session_id=v_sess_id order by sqno;
    rec_stmt cur_stmt%rowtype;

    vlength     number(5);
    vcolval     varchar2(4000);
    vrunval     varchar2(1);
    vcol_name     varchar2(500);
    vno         number(5);
    vrec         varchar2(4000);
    vrec_upd     varchar2(4000);
    vformat     varchar2(20);
    v_col_exists number(5);
Begin
    --insert into test1(vstring) values (pcolname||'33333'||pcolvalue);commit;
    dbg('vrec:');
   -- delete from
    insert into searchtbl(search) values ('neha');commit;


    Begin
        select userenv('sessionid') into v_sess_id from dual;
          delete from temp_col_ins where session_id=v_sess_id;
        vlength    :=null;    vcolval:=null;    vrunval:=null;    vcol_name:=null;vno:=null;

        vcolval    :=replace(pcolname,pdelimiter,',');
        vlength    :=length(vcolval);
        vno            :=1;

        for i in 1.. vlength loop
          vrunval:=substr(vcolval,i,1);
          if vrunval!=',' then
              vcol_name:=vcol_name||vrunval;
          else
            --insert into test1(vstring2) values (vno||','||upper(ltrim(rtrim(vcol_name)))||','||v_sess_id);
            --commit;
              insert into temp_col_ins (sqno,col_name,session_id) values (vno,upper(ltrim(rtrim(vcol_name))),v_sess_id);
              vno:=vno+1;
            vcol_name:='';
          end if;
        end loop;

         insert into searchtbl(search) values ('neha_1');commit;
        /*select count(*) into v_col_exists from col where tname=upper(ltrim(rtrim(ptable_name))) and
                cname=upper(ltrim(rtrim(vcol_name)));*/
        select count(*) into v_col_exists from temp_col_ins where session_id=v_sess_id and
            col_name=upper(ltrim(rtrim(vcol_name)));
        if nvl(v_col_exists,0)=0 then
            insert into temp_col_ins(sqno,col_name,session_id) values (vno,upper(vcol_name),v_sess_id);
        end if;
        commit;
        vlength:=null;    vcolval:=null;     vrunval:=null;    vcol_name:=null;    vno:=null;
        if instr(pcolvalue,',')>0 or instr(pcolvalue,'''')>0 then
           vcolval:=replace(pcolvalue,',','~~~');
        else
             vcolval:=pcolvalue;
        end if;
        vcolval:=replace(vcolval,pdelimiter,',');
        vlength:=length(vcolval);
        vno:=1;
        for i in 1.. vlength loop
          vrunval            :=substr(vcolval,i,1);
          if vrunval    !=',' then
              vcol_name    :=vcol_name||vrunval;
          else
              vcol_name    :=replace(vcol_name,'~~~',',');
            update temp_col_ins set col_value=vcol_name where sqno=vno and session_id=v_sess_id;
              vno:=vno+1;
            vcol_name:='';
          end if;
        end loop;
        if vcol_name is not null then
            update temp_col_ins set col_value=vcol_name where sqno=vno and session_id=v_sess_id;
        end if;
        update temp_col_ins set col_data_type=(select coltype from col where tname = upper(ltrim(rtrim(ptable_name))) and cname = upper(ltrim(rtrim(temp_col_ins.col_name))))
            where session_id=v_sess_id;
        commit;
         insert into searchtbl(search) values ('neha_2');commit;
        vrec:='insert into '||ptable_name||'('||replace(pcolname,pdelimiter,',')||') values ( ';

        insert into searchtbl(search) values (vrec);commit;

        --select "date_format" into vformat from preferrences;
          vformat:=pdateformat;
        open cur_stmt;
          loop
            fetch cur_stmt into rec_stmt;
               exit when cur_stmt%notfound;
               if rec_stmt.col_data_type='DATE' then
                    vrec:=vrec||'to_date('||rec_stmt.col_value||','||''''||vformat||''''||')'||',';
               else
                    vrec:=vrec||rec_stmt.col_value||',';
               end if;
          end loop;
        vrec        :=substr(vrec,1,length(vrec)-1)||')';
        vlength    :=null;
        vcolval    :=null;
        vrunval    :=null;
        vcol_name:=null;
        vno:=null;
        /*vcolval:=replace(pcond_colname,pdelimiter,',');
        vlength:=length(vcolval);
        for i in 1.. vlength loop
          vrunval:=substr(vcolval,i,1);
          if vrunval!=',' then
                   vcol_name:=vcol_name||vrunval;
          else
                 update temp_col_ins set upd_flag='I' where col_name=vcol_name and session_id=userenv('sessionid');
               vcol_name:='';
          end if;
        end loop;
        commit;
     close cur_stmt; */
     update temp_col_ins set upd_str=vrec where session_id=v_sess_id and rownum<2;
     --update temp_col_ins1 set upd_str=vrec where session_id=v_sess_id and rownum<2;
     --insert into test1(vstring) values (pcolname||'33333'||vrec);
     commit;

    End;
    dbg('vrec:'||vrec);
    execute immediate vrec;
    commit;
     --delete from temp_col_ins where session_id=userenv('sessionid');
    commit;
End variable_insert_stmt;

PROCEDURE variable_update_stmt(
   ptable_name      in varchar2,
   pcolname         in varchar2,
   pcolvalue        in varchar2,
   pcond_colname    in varchar2,
   pdelimiter       in varchar2,
   pdateformat      in varchar2,
   pextra1          in varchar2,
   pextra2          in varchar2) as

pstmt_str varchar2(4000);
cursor cur_stmt is select * from temp_col_ins  where session_id=userenv('sessionid') order by sqno;
    rec_stmt cur_stmt%rowtype;
cursor cur_upd_stmt is select * from temp_col_ins  where nvl(upd_flag,'N')='U' and session_id=userenv('sessionid');
    rec_upd_stmt cur_upd_stmt%rowtype;

    vlength     number(5);
    vcolval     varchar2(4000);
    vrunval     varchar2(1);
    vcol_name     varchar2(500);
    vno         number(5);
    vrec         varchar2(4000);
    vrec_upd     varchar2(4000);
    vpextra1     varchar2(4000);
    vformat     varchar2(20);
Begin
insert into searchtbl values('tblname-'|| ptable_name||'colname-'|| pcolname||'colvalue-'|| pcolvalue|| 'condname-' || pcond_colname|| 'delimeter-'|| pdelimiter || 'dateformat-'|| pdateformat || 'pextra1-'||pextra1||'pextra2-'|| pextra2);commit;






    --insert into test1(vstring) values (vrec||vrec_upd||ptable_name||','||pcolname||','||pcolvalue||','||pcond_colname||','||pdelimiter||','||pdateformat||','||pextra1||','||pextra2);
    Begin
        delete from temp_col_ins where session_id=userenv('sessionid');
        vlength        :=null;    vcolval:=null;    vrunval:=null;    vcol_name    :=null;    vno:=null;

        vcolval        :=replace(pcolname,pdelimiter,',');    vlength        :=length(vcolval);    vno:=1;
        for i in 1.. vlength loop
          vrunval:=substr(vcolval,i,1);
          if vrunval!=',' then
              vcol_name:=vcol_name||vrunval;
          else
              insert into temp_col_ins (sqno,col_name,session_id) values (vno,vcol_name,userenv('sessionid'));
              vno                :=vno+1;
            vcol_name    :='';
          end if;
        end loop;
        commit;
        vlength:=null;    vcolval:=null;    vrunval:=null;    vcol_name:=null;    vno:=null;

        if instr(pcolvalue,',')>0 then
            vcolval:=replace(pcolvalue,',','~~~');
        else
            vcolval:=pcolvalue;
        end if;

        vcolval:=replace(vcolval,pdelimiter,',');    vlength:=length(vcolval);    vno:=1;
        for i in 1.. vlength loop
          vrunval:=substr(vcolval,i,1);
          if vrunval!=',' then
                   vcol_name:=vcol_name||vrunval;
          else
                 vcol_name:=replace(vcol_name,'~~~',',');
               update temp_col_ins set col_value=vcol_name where sqno=vno and session_id=userenv('sessionid');
                 vno:=vno+1;
               vcol_name:='';
          end if;
        end loop;
        /*Start New Change For Old and New Concept */
        if pextra1='' or pextra1 is null then
             vpextra1:=pcolvalue;
        else
             vpextra1:=pextra1;
        end if;
        vlength:=null;    vcolval:=null;    vrunval:=null;    vcol_name:=null;    vno:=null;

        if instr(vpextra1,',')>0 then
            vcolval:=replace(vpextra1,',','~~~');
        else
            vcolval:=vpextra1;
        end if;

        vcolval:=replace(vcolval,pdelimiter,',');    vlength:=length(vcolval);    vno:=1;
        for i in 1.. vlength loop
          vrunval:=substr(vcolval,i,1);
          if vrunval!=',' then
                   vcol_name:=vcol_name||vrunval;
          else
                 vcol_name:=replace(vcol_name,'~~~',',');
               update temp_col_ins set col_value_old=vcol_name where sqno=vno and session_id=userenv('sessionid');
                 vno:=vno+1;
               vcol_name:='';
          end if;
        end loop;
        /*End New Change For Old and New Concept */
        update temp_col_ins set temp_col_ins.col_data_type=(select col.coltype from col where col.tname = upper(ltrim(rtrim(ptable_name))) and col.cname = upper(ltrim(rtrim(temp_col_ins.col_name))))
            where session_id=userenv('sessionid');
        commit;
        vrec:='update '||ptable_name||' set ';
        --select "date_format" into vformat from preferrences;
          vformat:=pdateformat;
        open cur_stmt;
          loop
            fetch cur_stmt into rec_stmt;
               exit when cur_stmt%notfound;
               if rec_stmt.col_data_type='DATE' then
                    vrec:=vrec||rec_stmt.col_name||'=to_date('||rec_stmt.col_value||','||''''||vformat||''''||')'||',';
               else
                    vrec:=vrec||rec_stmt.col_name||'='||replace(rec_stmt.col_value,'null','')||',';
               end if;
          end loop;
          vrec:=substr(vrec,1,length(vrec)-1);
        vlength:=null;    vcolval:=null;    vrunval:=null;    vcol_name:=null;    vno:=null;

        vcolval:=replace(pcond_colname,pdelimiter,',');    vlength:=length(vcolval);

        for i in 1.. vlength loop
          vrunval:=substr(vcolval,i,1);
          if vrunval!=',' then
              vcol_name:=vcol_name||vrunval;
          else
              update temp_col_ins set upd_flag='U' where col_name=vcol_name and session_id=userenv('sessionid');
            vcol_name:='';
          end if;
        end loop;
        commit;
      close cur_stmt;
        if pcond_colname is not null then
             vrec_upd:=' where ';
        else
             vrec_upd:='';
        end if;

        open cur_upd_stmt;
          loop
            fetch cur_upd_stmt into rec_upd_stmt;
               exit when cur_upd_stmt%notfound;
               if rec_upd_stmt.col_data_type='DATE' then
                    vrec_upd:=vrec_upd||rec_upd_stmt.col_name||'=to_date('||rec_upd_stmt.col_value_old||','||''''||vformat||''''||')'||' and ';
               else
                    vrec_upd:=vrec_upd||rec_upd_stmt.col_name||'='||rec_upd_stmt.col_value_old||' and ';
               end if;
          end loop;
         close cur_upd_stmt;
         vrec_upd:=substr(vrec_upd,1,length(vrec_upd)-5);
         update temp_col_ins set upd_str=vrec||vrec_upd where session_id=userenv('sessionid') and rownum<2;
         commit;

    End;
     insert into test1(vstring) values (vrec||vrec_upd);commit;
    execute immediate vrec||vrec_upd;
   -- insert into temp_col_ins1 values (vrec||vrec_upd);
    commit;
       --delete from temp_col_ins where session_id=userenv('sessionid');commit;

End variable_update_stmt;

procedure variable_delete_stmt(
  ptable_name   in varchar2,
  pcond_colname in varchar2,
  pcond_colval  in varchar2,
  pdelimiter    in varchar2,
  pdateformat   in varchar2,
  pextra1       in varchar2,
  pextra2       in varchar2) as

  pstmt_str varchar2(4000);
cursor cur_stmt is select * from temp_col_ins  where session_id=userenv('sessionid') order by sqno;
    rec_stmt cur_stmt%rowtype;

cursor cur_upd_stmt is select * from temp_col_ins  where nvl(upd_flag,'N')='U' and session_id=userenv('sessionid');
    rec_upd_stmt cur_upd_stmt%rowtype;

    vlength     number(5);
    vcolval     varchar2(4000);
    vrunval     varchar2(1);
    vcol_name   varchar2(500);
    vno         number(5);
    vrec        varchar2(4000);
    vformat     varchar2(20);
Begin
    Begin
        delete from temp_col_ins where session_id=userenv('sessionid');
        vlength:=null;
        vcolval:=null;
        vrunval:=null;
        vcol_name:=null;
        vno:=null;
        vcolval:=replace(pcond_colname,pdelimiter,',');
        vlength:=length(vcolval);
        vno:=1;
        for i in 1.. vlength loop
          vrunval:=substr(vcolval,i,1);
          if vrunval!=',' then
                   vcol_name:=vcol_name||vrunval;
          else
                 insert into temp_col_ins (sqno,col_name,upd_flag,session_id,upd_str) values (vno,vcol_name,'U',userenv('sessionid'),pcond_colval);
                 vno:=vno+1;
               vcol_name:='';
          end if;
        end loop;
        commit;
        vlength:=null;
        vcolval:=null;
        vrunval:=null;
        vcol_name:=null;
        vno:=null;
        if instr(pcond_colval,',')>0 then
           vcolval:=replace(pcond_colval,',','~~~');
        else
             vcolval:=pcond_colval;
        end if;
        vcolval:=replace(vcolval,pdelimiter,',');
        vlength:=length(vcolval);
        vno:=1;
        for i in 1.. vlength loop
          vrunval:=substr(vcolval,i,1);
          if vrunval!=',' then
                   vcol_name:=vcol_name||vrunval;
          else
                 --vcol_name:=replace(vcol_name,'~~~',',');
               update temp_col_ins set col_value=vcol_name where sqno=vno and session_id=userenv('sessionid');
                 vno:=vno+1;
               vcol_name:='';
          end if;
        end loop;
        update temp_col_ins set temp_col_ins.col_data_type=(select col.coltype from col where col.tname = upper(ltrim(rtrim(ptable_name))) and cname = upper(ltrim(rtrim(temp_col_ins.col_name))))
            where session_id=userenv('sessionid');
        commit;
        vrec:='delete from '||ptable_name||' where ';
        --select "date_format" into vformat from preferrences;
        vformat:=pdateformat;
        open cur_stmt;
          loop
            fetch cur_stmt into rec_stmt;
               exit when cur_stmt%notfound;
               if rec_stmt.col_data_type='DATE' then
                    vrec:=vrec||rec_stmt.col_name||'=to_date('||rec_stmt.col_value||','||''''||vformat||''''||')'||' and ';
               else
                    vrec:=vrec||rec_stmt.col_name||'='||rec_stmt.col_value||' and ';
               end if;
          end loop;
         vrec:=substr(vrec,1,length(vrec)-5);
         --update temp_col_ins set upd_str=vrec where session_id=userenv('sessionid') and rownum<2;
         --commit;

    End;
    insert  into temp_col_ins_c (vstr) values (vrec);
    commit;
    execute immediate vrec;
    commit;
    delete from temp_col_ins where session_id=userenv('sessionid');
    commit;

End variable_delete_stmt;

procedure variable_execute_stmt(
  ptable_name   in varchar2,
  pcond_colname in varchar2,
  pcond_colval  in varchar2,
  pdelimiter    in varchar2,
  pdateformat   in varchar2,
  pextra1       in varchar2,
  pextra2       in varchar2,
  p_accounts    out t_accounts_type) as

  pstmt_str varchar2(4000);
cursor cur_stmt is select * from temp_col_ins  where session_id=userenv('sessionid');
	rec_stmt cur_stmt%rowtype;

/*cursor cur_upd_stmt is select * from temp_col_ins  where nvl(upd_flag,'N')='U' and session_id=userenv('sessionid');
	rec_upd_stmt cur_upd_stmt%rowtype;*/

	vlength     number(5);
	vcolval     varchar2(4000);
	vrunval     varchar2(1);
	vcol_name   varchar2(100);
	vno         number(5);
	vrec        varchar2(4000);
	vformat     varchar2(20);
Begin
	 insert into temp_col_ins1 (sqno,col_name,upd_str,session_id) values (9999,'',sysdate||pcond_colname||'#'||pcond_colval||'#'||vrec,userenv('sessionid'));
    Begin
		delete from temp_col_ins where session_id=userenv('sessionid');
        delete from temp_col_ins1 where session_id=userenv('sessionid');
		vlength	:=null;	vcolval	:=null;	vrunval	:=null;	vcol_name	:=null;vno:=null;
		vcolval	:=replace(pcond_colname,pdelimiter,',');
		vlength	:=length(vcolval);vno:=1;

		for i in 1.. vlength loop
		  vrunval:=substr(vcolval,i,1);
		  if vrunval!=',' then
		  	vcol_name:=vcol_name||vrunval;
		  else
		  	insert into temp_col_ins (sqno,col_name,upd_flag,session_id) values (vno,vcol_name,'U',userenv('sessionid'));
            insert into temp_col_ins1 (sqno,col_name,upd_flag,session_id) values (vno,vcol_name,'U',userenv('sessionid'));
            vno:=vno+1;
		    vcol_name:='';
		  end if;
		end loop;
		commit;
		vlength:=null;
		vcolval:=null;
		vrunval:=null;
		vcol_name:=null;
		vno:=null;
		vcolval:=replace(replace(pcond_colval,',','^'),pdelimiter,',');
		vlength:=length(vcolval);
		vno:=1;
		for i in 1.. vlength loop
		  vrunval:=substr(vcolval,i,1);
		  if vrunval!=',' then
		  		 vcol_name:=vcol_name||vrunval;
		  else
		       update temp_col_ins set col_value=vcol_name where sqno=vno and session_id=userenv('sessionid');
               vno:=vno+1;
		       vcol_name:='';
		  end if;
		end loop;
		update temp_col_ins set temp_col_ins.col_data_type=(select col.coltype from col where col.tname = upper(ltrim(rtrim(ptable_name))) and cname = upper(ltrim(rtrim(temp_col_ins.col_name))))
			where session_id=userenv('sessionid');
       		delete from temp_col_ins where col_value=''''||'''' and session_id=userenv('sessionid');
		commit;
		vrec:='select * from '||ptable_name||' where ';
		--select "date_format" into vformat from preferrences;
          vformat:=pdateformat;
		open cur_stmt;
		  loop
		    fetch cur_stmt into rec_stmt;
		       exit when cur_stmt%notfound;
		       if rec_stmt.col_data_type='DATE' then
		       	 vrec:=vrec||rec_stmt.col_name||'=to_date('||replace(rec_stmt.col_value,'^',',')||','||''''||vformat||''''||')'||' and   ';
		       else
		       	 --vrec:=vrec||rec_stmt.col_name||'='||rec_stmt.col_value||' and ';
		       	 vrec:=vrec||'(('||rec_stmt.col_name||'='||replace(rec_stmt.col_value,'^',',')||') or ('||rec_stmt.col_name||' like '||rec_stmt.col_value||'))'||' and   ';
		       end if;
		  end loop;
          /*if substr(vrec,length(vrec)-5,5)=' and ' then
		     vrec:=substr(vrec,1,length(vrec)-4);
          elsif substr(vrec,length(vrec)-7,7)=' where ' then
             vrec:=substr(vrec,1,length(vrec)-6);
          end if;*/
             vrec:=substr(vrec,1,length(vrec)-7);
             --insert into test1(vstring) values(vrec);
		 update temp_col_ins set upd_str=vrec where session_id=userenv('sessionid') and rownum<2;
		 commit;

	End;
    delete from searchtbl;
    insert into searchtbl values(pextra1);commit;
    
    if pextra1 is not null then
       vrec:=vrec||' order by '||pextra1;
       insert into temp_col_ins1 (sqno,col_name,upd_str,session_id) values (1234,'',pcond_colname||'#'||pcond_colval||'#'||vrec,userenv('sessionid'));
    else
       vrec:=vrec||' order by rowid ';
    end if;
    insert into searchtbl values(vrec);commit;
    
    --insert into temp_col_ins1 values (vrec);
    insert into temp_col_ins1 (sqno,col_name,upd_str,session_id) values (9999,'',pcond_colname||'#'||pcond_colval||'#'||vrec,userenv('sessionid'));
	open p_accounts for vrec;
	--delete from temp_col_ins where session_id=userenv('sessionid');
	commit;
End variable_execute_stmt;

--var a refcursor;
--exec CIR_DYNAMIC_DML.variable_order('','','','','ABC_CHARGE_MAST','CHG_CODE','ASC','','','',:A);
--var a refcursor;
--exec CIR_DYNAMIC_DML.variable_order('','','','','ABC_CHARGE_MAST','CHG_CODE','ASC','','','',:A);

procedure variable_order(
 pcomp_code     in varchar2,
 pcomp_val         in varchar2,
 punit_code     in varchar2,
 punit_val         in varchar2,
 ptable_name     in varchar2,
 pcolname         in varchar2,
 porder         in varchar2,
 pdateformat     in varchar2,
 pextra1         in varchar2,
 pextra2         in varchar2,
 p_accounts     out t_accounts) as
Begin


   if punit_code is null and pcomp_code is not null then
      open p_accounts for ' select * from '||ptable_name||' where '||pcomp_code||'='||''''||pcomp_val||''''||' order by '||pcolname||' '||porder;
   elsif pcomp_code is null and punit_code is not null then
      open p_accounts for ' select * from '||ptable_name||' where '||punit_code||'='||''''||punit_val||''''||' order by '||pcolname||' '||porder;
   elsif pcomp_code is null and punit_code is null then
      open p_accounts for ' select * from '||ptable_name||' order by '||pcolname||' '||porder;
   else
         open p_accounts for ' select * from '||ptable_name||' where '||pcomp_code||'='||''''||pcomp_val||''''||' and '||punit_code||'='||''''||punit_val||''''||' order by '||pcolname||' '||porder;
   end if;
End variable_order;

PROCEDURE variable_insert_stmt(
    ptable_name     in varchar2,
    pcolname        in varchar2,
    pcolvalue       in varchar2,
    pdelimiter      in varchar2,
    pdateformat     in varchar2,
    pextra1         in varchar2,
    pextra2         in varchar2,
    p_error_text    out varchar2) as

    pstmt_str   varchar2(4000);
    v_sess_id   number;
cursor cur_stmt is
    select * from temp_col_ins  where session_id=v_sess_id order by sqno;
    rec_stmt cur_stmt%rowtype;
/*cursor cur_upd_stmt is
    select * from temp_col_ins  where nvl(upd_flag,'N')='I' and session_id=v_sess_id;
    rec_upd_stmt cur_upd_stmt%rowtype;*/
    vlength     number(5);
    vcolval     varchar2(4000);
    vrunval     varchar2(1);
    vcol_name     varchar2(100);
    vno         number(5);
    vrec         varchar2(4000);
    vrec_upd     varchar2(4000);
    vformat     varchar2(20);
    v_col_exists number(5);
Begin
    --insert into test1(vstring) values (pcolname||'33333'||pcolvalue);commit;
    Begin
        select userenv('sessionid') into v_sess_id from dual;
        delete from temp_col_ins where session_id=v_sess_id;
        vlength    :=null;    vcolval:=null;    vrunval:=null;    vcol_name:=null;vno:=null;

        vcolval    :=replace(pcolname,pdelimiter,',');
        vlength    :=length(vcolval);
        vno            :=1;

        for i in 1.. vlength loop
          vrunval:=substr(vcolval,i,1);
          if vrunval!=',' then
              vcol_name:=vcol_name||vrunval;
          else
            --insert into test1(vstring2) values (vno||','||upper(ltrim(rtrim(vcol_name)))||','||v_sess_id);
            --commit;
              insert into temp_col_ins (sqno,col_name,session_id) values (vno,upper(ltrim(rtrim(vcol_name))),v_sess_id);
              vno:=vno+1;
            vcol_name:='';
          end if;
        end loop;
        /*select count(*) into v_col_exists from col where tname=upper(ltrim(rtrim(ptable_name))) and
                cname=upper(ltrim(rtrim(vcol_name)));*/
        select count(*) into v_col_exists from temp_col_ins where session_id=v_sess_id and
            col_name=upper(ltrim(rtrim(vcol_name)));
        if nvl(v_col_exists,0)=0 then
            insert into temp_col_ins(sqno,col_name,session_id) values (vno,upper(vcol_name),v_sess_id);
        end if;
        commit;
        vlength:=null;    vcolval:=null;     vrunval:=null;    vcol_name:=null;    vno:=null;
        if instr(pcolvalue,',')>0 or instr(pcolvalue,'''')>0 then
           vcolval:=replace(pcolvalue,',','~~~');
        else
             vcolval:=pcolvalue;
        end if;
        vcolval:=replace(vcolval,pdelimiter,',');
        vlength:=length(vcolval);
        vno:=1;
        for i in 1.. vlength loop
          vrunval            :=substr(vcolval,i,1);
          if vrunval    !=',' then
              vcol_name    :=vcol_name||vrunval;
          else
              vcol_name    :=replace(vcol_name,'~~~',',');
            update temp_col_ins set col_value=vcol_name where sqno=vno and session_id=v_sess_id;
              vno:=vno+1;
            vcol_name:='';
          end if;
        end loop;
        if vcol_name is not null then
            update temp_col_ins set col_value=vcol_name where sqno=vno and session_id=v_sess_id;
        end if;
        update temp_col_ins set col_data_type=(select coltype from col where tname = upper(ltrim(rtrim(ptable_name))) and cname = upper(ltrim(rtrim(temp_col_ins.col_name))))
            where session_id=v_sess_id;
        commit;
        vrec:='insert into '||ptable_name||'('||replace(pcolname,pdelimiter,',')||') values ( ';

        --select "date_format" into vformat from preferrences;
          vformat:=pdateformat;
        open cur_stmt;
          loop
            fetch cur_stmt into rec_stmt;
               exit when cur_stmt%notfound;
               if rec_stmt.col_data_type='DATE' then
                    vrec:=vrec||'to_date('||rec_stmt.col_value||','||''''||vformat||''''||')'||',';
               else
                    vrec:=vrec||rec_stmt.col_value||',';
               end if;
          end loop;
        vrec        :=substr(vrec,1,length(vrec)-1)||')';
        vlength    :=null;
        vcolval    :=null;
        vrunval    :=null;
        vcol_name:=null;
        vno:=null;
        /*vcolval:=replace(pcond_colname,pdelimiter,',');
        vlength:=length(vcolval);
        for i in 1.. vlength loop
          vrunval:=substr(vcolval,i,1);
          if vrunval!=',' then
                   vcol_name:=vcol_name||vrunval;
          else
                 update temp_col_ins set upd_flag='I' where col_name=vcol_name and session_id=userenv('sessionid');
               vcol_name:='';
          end if;
        end loop;
        commit;
     close cur_stmt; */
     update temp_col_ins set upd_str=vrec where session_id=v_sess_id and rownum<2;
     --update temp_col_ins1 set upd_str=vrec where session_id=v_sess_id and rownum<2;
     --insert into test1(vstring) values (pcolname||'33333'||vrec);
     commit;

    End;
    execute immediate vrec;
    commit;
     --delete from temp_col_ins where session_id=userenv('sessionid');
    commit;
    exception
       when others then
            p_error_text := 'Error:'||sqlerrm;
End variable_insert_stmt;

END Cir_Dynamic_DML;
/



--------------end 6918 -------------------12-03-2012------------------
--------------start 6918 -------------------13-03-2012------------------

ALTER TABLE RO_BOOK_ALLOTMENT
MODIFY(ISSUE_NO varchar2(15));




--------------end 6918 -------------------13-03-2012------------------

@@@@@@  ankit  @@@@@@@@@@@@@@@@@@@@@@  6940  13 march  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
p_CURRENCY_MEASUREMENT     IN VARCHAR2,
p_bookingapproval     IN VARCHAR2,
p_EDITABLE_AGENCY_COMM      IN VARCHAR2

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
RECORDS_ON_PAGE = p_paging,RECORDS_ON_PRINT = p_print,HEADER_ON_PAGE = p_allowpage,AGENCY_REQUIRED = p_agency_req,REGION_REQUIRED = p_region_req,ALLOW_FOLLOW_DT_BOOOK=p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=p_CURRENCY_MEASUREMENT,BOOK_AUDIT_REQ_AFTER_MOD =p_bookingapproval,EDITABLE_AGENCY_COMM=p_EDITABLE_AGENCY_COMM 

  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
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
        AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE ,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,"Space_area",BOOK_AUDIT_REQ_AFTER_MOD,EDITABLE_AGENCY_COMM   
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/

@@@@@@  ankit  @@@@@@@@@@@@@@@@@@@@@@  6940  13 march  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

/********************************************MIMOH ****************************************************RO REPORT*****/
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
            (SELECT "Branch_Name" FROM BRANCH_MST where  a."branch" = "Branch_Code") as "BRANCH",
          
            SUM(DECODE(RODOCSTATUS,''o'',1,0)) ORIGINAL
            ,SUM(DECODE(RODOCSTATUS,''f'',1,0)) FAX
            ,SUM(DECODE(RODOCSTATUS,''x'',1,0)) XEROX
            ,SUM(DECODE(RODOCSTATUS,''o'',0,''f'',0,''x'',0,1)) REMAIN
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,agency_mast b/*,adv_cat_mast c*/
            where  
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
            a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel''';
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
            from TBL_BOOKING_MAST a,tbl_booking_insert i ,RETAINERMASTER,agency_mast b ,adv_cat_mast c
            where a."Ad_type_code"=c."Adv_Type" and
            a."Ad_cat_code"=c."Adv_Cat_Code" and
            a."Comp_code"=c."Comp_Code" and
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
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
            and a."Agency_sub_code"=b."code_subcode" and i."Insert_Status"<>''cancel'' ';
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
            a."Comp_code"='''||pcompcode||''' AND a."Comp_code"=i."Comp_Code" AND a."cio_booking_id"=i."Cio_Booking_Id" and
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
END Ro_Report;
/

/********************************************MIMOH ****************************************************RO REPORT*****/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 13/3/2012 @@Agency_merging @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//=========================================Begin Procedure==================================//
CREATE OR REPLACE PROCEDURE insert_edition_details(
p_str           in varchar2,
receiptnom      in varchar2,
cioidm          in varchar2,
insertidm       in varchar2,
compcodem       in varchar2,
editioncodem    in varchar2,
insertdatem     in date,
heightm         in varchar2,
widthm          in varchar2,
totaream        in varchar2,
insstatusm      in varchar2,
pkgcode         in varchar2,
insertno        in number ,
pageno          in number, 
p_error_text    out varchar2)  
IS
tmpVar  NUMBER;
tmpStr  VARCHAR2(4000);
l_str   VARCHAR2(4000);
l_ed    varchar2(50);
l_date  date;
l_hight number;
l_width number;
l_size  number;
l_pageno number;
l_status    varchar2(20);
pubcode     varchar2(10);
editioncode varchar2(50);
combinname  varchar2(3000);
uomdesc     varchar2(50);
v_edtn_type varchar2(50);
BEGIN

if p_str is not null then
    --INSERT INTO TEST1 VALUES('pubcode','editioncode'); COMMIT;

    --insert into abctest values(insertidm,l_status);
    tmpVar  := 0;
    tmpStr  := p_str;
    l_str   := p_str;

    for i in 1..length(tmpStr)-length(replace(tmpStr,'$',null))+1 
    loop
      
        if instr(tmpStr,'$') > 0 then 
            l_str := substr(tmpStr,1,instr(tmpStr,'$')-1);
        else
            l_str := tmpStr;
        end if;
        --dbms_output.put_line('l_str:'||l_str);
        l_ed := substr(l_str,1,instr(l_str,'~')-1);
        l_str := substr(l_str,instr(l_str,'~')+1);
        l_date := to_date(substr(l_str,1,instr(l_str,'~')-1),'mm/dd/yyyy');
        l_str := substr(l_str,instr(l_str,'~')+1);
                             
        l_hight := substr(l_str,1,instr(l_str,'~')-1);
        l_str := substr(l_str,instr(l_str,'~')+1);
        l_width := substr(l_str,1,instr(l_str,'~')-1);   
        l_str := substr(l_str,instr(l_str,'~')+1);
        l_size:=substr(l_str,1,instr(l_str,'~')-1);  
        l_str := substr(l_str,instr(l_str,'~')+1); 
        l_pageno:=substr(l_str,1,instr(l_str,'~')-1);  
        l_str := substr(l_str,instr(l_str,'~')+1);
        
        if(insstatusm = 'cancel') then 
        l_status :=insstatusm;
        else
        l_status :=l_str;
        end if;
        -- insert into abctest values(insertidm,'Str:'||l_status||':'||receiptnom||':'||editioncode||':'||pubcode||':'||insertidm||':'||compcodem||':'||cioidm||':'||l_date||':'||l_ed||':'||l_hight||':'||l_width||':'||l_size);
        tmpStr := substr(tmpStr,instr(tmpStr,'$')+1);

        select "Pub_Code","Edition_Code" into pubcode,editioncode from edition_mast where "Edition_Alias"=l_ed AND ROWNUM<=1;
        
        dbms_output.put_line('Str:'||l_date||':'||l_ed||':'||l_hight||':'||l_width||':'||l_size);

        insert into tbl_booking_subedition_g(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,SRNO,NO_INSERT,PAGE_NO) 
        values(compcodem,cioidm,insertidm,pubcode,editioncode,l_date,l_hight,l_width,l_size,l_status,receiptnom,SUBEDI_S.NEXTVAL,insertno,l_pageno);
        -- insert into 
    end loop;
else

    dbms_output.put_line('lata');

    --INSERT INTO TEST1 VALUES('pubcodeMAIN',editioncodem);
    
    select "Pub_Code","City_Code","Edition_Type" into pubcode,editioncode,v_edtn_type 
        from edition_mast 
            where trim("Edition_Code")=trim(editioncodem) and rownum<=1;
    
    -- insert into abctest values(pubcode,editioncode);
    dbms_output.put_line(pubcode);
    dbms_output.put_line(editioncode);
    dbms_output.put_line(pkgcode);
    
    If v_edtn_type='Main Edition' then
        select "Combin_Desc" into combinname from combin_mast where "Combin_Code"=pkgcode;
        
        select UOM_DESC into uomdesc from uom_mast where "Uom_Code"=(select Uom_code from tbl_booking_mast_g 
            where cio_booking_id=cioidm);
        dbms_output.put_line(combinname);
        
        if instr(combinname,'+')<0 and uomdesc='CD' then
            --INSERT INTO TEST1 VALUES(pubcode,editioncode);COMMIT;
            
            insert into tbl_booking_subedition_g(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,SRNO,NO_INSERT,PAGE_NO)
            --select compcodem,cioidm,insertidm,"Pub_Code","Edition_Code",insertdatem,heightm,widthm,totaream,'cancel',receiptnom,SUBEDI_S.NEXTVAL,insertno,pageno
            select compcodem,cioidm,insertidm,"Pub_Code","Edition_Code",insertdatem,heightm,widthm,totaream,insstatusm,receiptnom,SUBEDI_S.NEXTVAL,insertno,pageno
            from edition_mast where  "Pub_Code"=pubcode and "City_Code"=editioncode and "Edition_Type"='Edition';
            
        else
            dbms_output.put_line('lata111');
            insert into tbl_booking_subedition_g(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,SRNO,NO_INSERT,PAGE_NO)
            --select compcodem,cioidm,insertidm,"Pub_Code","Edition_Code",insertdatem,heightm,widthm,totaream,'booked',receiptnom,SUBEDI_S.NEXTVAL,insertno,pageno
            select compcodem,cioidm,insertidm,"Pub_Code","Edition_Code",insertdatem,heightm,widthm,totaream,insstatusm,receiptnom,SUBEDI_S.NEXTVAL,insertno,pageno
            from edition_mast where  "Pub_Code"=pubcode and "City_Code"=editioncode and "Edition_Type"='Edition';
        end if;
    End if;           
end if;
    COMMIT;  
    exception when others then 
    p_error_text :=sqlerrm;       
END insert_edition_details;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE insert_edition_details_update(
p_str           in varchar2,
receiptnom      in varchar2,
cioidm          in varchar2,
insertidm       in varchar2,
compcodem       in varchar2,
editioncodem    in varchar2,
insertdatem     in date,
heightm         in varchar2,
widthm          in varchar2,
totaream        in varchar2,
insstatusm      in varchar2,
pkgcode         in varchar2,
insertno        in number ,
pageno          in number, 
p_error_text    out varchar2)  
IS
tmpVar  NUMBER;
tmpStr  VARCHAR2(4000);
l_str   VARCHAR2(4000);
l_ed    varchar2(50);
l_date  date;
l_hight number;
l_width number;
l_size  number;
l_pageno number;
l_status    varchar2(20);
pubcode     varchar2(10);
editioncode varchar2(50);
combinname  varchar2(3000);
uomdesc     varchar2(50);
v_edtn_type varchar2(50);
BEGIN

if p_str is not null then
    --INSERT INTO TEST1 VALUES('pubcode','editioncode'); COMMIT;

    --insert into abctest values(insertidm,l_status);
    tmpVar  := 0;
    tmpStr  := p_str;
    l_str   := p_str;

    for i in 1..length(tmpStr)-length(replace(tmpStr,'$',null))+1 
    loop
      
        if instr(tmpStr,'$') > 0 then 
            l_str := substr(tmpStr,1,instr(tmpStr,'$')-1);
        else
            l_str := tmpStr;
        end if;
        --dbms_output.put_line('l_str:'||l_str);
        l_ed := substr(l_str,1,instr(l_str,'~')-1);
        l_str := substr(l_str,instr(l_str,'~')+1);
        l_date := to_date(substr(l_str,1,instr(l_str,'~')-1),'mm/dd/yyyy');
        l_str := substr(l_str,instr(l_str,'~')+1);
                             
        l_hight := substr(l_str,1,instr(l_str,'~')-1);
        l_str := substr(l_str,instr(l_str,'~')+1);
        l_width := substr(l_str,1,instr(l_str,'~')-1);   
        l_str := substr(l_str,instr(l_str,'~')+1);
        l_size:=substr(l_str,1,instr(l_str,'~')-1);  
        l_str := substr(l_str,instr(l_str,'~')+1); 
        l_pageno:=substr(l_str,1,instr(l_str,'~')-1);  
        l_str := substr(l_str,instr(l_str,'~')+1);
        
         if(insstatusm = 'cancel') then 
        l_status :=insstatusm;
        else
        l_status :=l_str;
        end if;
        -- insert into abctest values(insertidm,'Str:'||l_status||':'||receiptnom||':'||editioncode||':'||pubcode||':'||insertidm||':'||compcodem||':'||cioidm||':'||l_date||':'||l_ed||':'||l_hight||':'||l_width||':'||l_size);
        tmpStr := substr(tmpStr,instr(tmpStr,'$')+1);

        select "Pub_Code","Edition_Code" into pubcode,editioncode from edition_mast where "Edition_Alias"=l_ed AND ROWNUM<=1;
        
        dbms_output.put_line('Str:'||l_date||':'||l_ed||':'||l_hight||':'||l_width||':'||l_size);

        insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,SRNO,NO_INSERT,PAGE_NO) 
        values(compcodem,cioidm,insertidm,pubcode,editioncode,l_date,l_hight,l_width,l_size,l_status,receiptnom,SUBEDI_S.NEXTVAL,insertno,l_pageno);
        -- insert into 
    end loop;
else

    dbms_output.put_line('lata');

    --INSERT INTO TEST1 VALUES('pubcodeMAIN',editioncodem);
    
    select "Pub_Code","City_Code","Edition_Type" into pubcode,editioncode,v_edtn_type 
        from edition_mast 
            where trim("Edition_Code")=trim(editioncodem) and rownum<=1;
    
    -- insert into abctest values(pubcode,editioncode);
    dbms_output.put_line(pubcode);
    dbms_output.put_line(editioncode);
    dbms_output.put_line(pkgcode);
    
    If v_edtn_type='Main Edition' then
        select "Combin_Desc" into combinname from combin_mast where "Combin_Code"=pkgcode;
        
        select UOM_DESC into uomdesc from uom_mast where "Uom_Code"=(select "Uom_code" from tbl_booking_mast 
            where "cio_booking_id"=cioidm);
        dbms_output.put_line(combinname);
        
        if instr(combinname,'+')<0 and uomdesc='CD' then
            --INSERT INTO TEST1 VALUES(pubcode,editioncode);COMMIT;
            
            insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,SRNO,NO_INSERT,PAGE_NO)
           -- select compcodem,cioidm,insertidm,"Pub_Code","Edition_Code",insertdatem,heightm,widthm,totaream,'cancel',receiptnom,SUBEDI_S.NEXTVAL,insertno,pageno
            select compcodem,cioidm,insertidm,"Pub_Code","Edition_Code",insertdatem,heightm,widthm,totaream,insstatusm,receiptnom,SUBEDI_S.NEXTVAL,insertno,pageno
            from edition_mast where  "Pub_Code"=pubcode and "City_Code"=editioncode and "Edition_Type"='Edition';
            
        else
            dbms_output.put_line('lata111');
            insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS,RECEIPTNO,SRNO,NO_INSERT,PAGE_NO)
            --select compcodem,cioidm,insertidm,"Pub_Code","Edition_Code",insertdatem,heightm,widthm,totaream,'booked',receiptnom,SUBEDI_S.NEXTVAL,insertno,pageno
            select compcodem,cioidm,insertidm,"Pub_Code","Edition_Code",insertdatem,heightm,widthm,totaream,insstatusm,receiptnom,SUBEDI_S.NEXTVAL,insertno,pageno
            from edition_mast where  "Pub_Code"=pubcode and "City_Code"=editioncode and "Edition_Type"='Edition';
        end if;
    End if;           
end if;
    COMMIT;  
    exception when others then 
    p_error_text :=sqlerrm;       
END insert_edition_details_update;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
resourceno_p in varchar2,
caption_inserts_p in varchar2,
dealerheight in NUMBER,
dealerwidth in NUMBER,
subedidata in varchar2
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
    resourceno_p in varchar2,
    caption_inserts_p in varchar2,
    dealerheight in NUMBER,
    dealerwidth in NUMBER,
    subedidata in varchar2
    
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
error1      varchar2(409);
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
        
        insert into tbl_booking_insert("Cio_Booking_Id","Edition","Insert_Date","Col_Code","Height","Width","Size_Book","Page_Post","Premium1","Prem_Per1","Premium2","Prem_Per2","Premium_Allow","Ad_Cat","Ad_Sub_Cat","Latest_By","Status_Material","File_Name","Card_Rate","Disc_Rate","Insert_Status","Bill_Status","Comp_Code","Userid","Repeating_Date","No_Insert","Edition_Code","Publication_Code","Pub_Cent_Code","Supp_Code","Pai_Free_Ins","Agreed_Rate","Solo_Rate","Gross_Rate","Page_No","Remarks","Page_Prem","Page_Per","No_Ofcolumn","Bill_Amt","Bill_Rate","Logo_H", "Logo_W", "Logo_name","Insert_Id","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS,BOXCHARGE,VAT_INC,VATAMT,LOCALGROSSAMT,LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION,DEALER_H,DEALER_W)
        values(cioid,edition,insertdate,colid,height,width,totalsize,pagepost,premium1,premper1,premium2,premper2,premallow,adcategory,adsubcat1,latestdate,material,matfilename,cardrate,discrate,insertstatus,billstatus,compcode,userid,repeat,insertno,edi,publi,pub_cent,supp,paid,agrrate,solorate,grossrate,insert_pageno,insert_remarks,page_code,page_per,noofcol,billamt,billrate,logo_h,logo_w,logo_name,insertidval,ad_cat_3,ad_cat_4,ad_cat_5, pkgcode,gridins,pkgalias,boxcharge_p,vat_inc_p,vatrate_p,grossamtlocal_p,billamtlocal_p,sectioncode_p,resourceno_p,caption_inserts_p,dealerheight,dealerwidth);
        if(cirvts is not null) then
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                    values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
        end if; 
         insert_edition_details_update(subedidata,null,cioid,insertidval,compcode,edi,insertdate,height,width,totalsize,insertstatus,pkgcode,insertno,insert_pageno,error1);
                   
    else
        update  tbl_booking_insert set "Edition"=edition,"Insert_Date"=insertdate,"Col_Code"=colid,"Height"=height,"Width"=width,"Size_Book"=totalsize,"Page_Post"=pagepost,"Premium1"=premium1,"Prem_Per1"=premper1,"Premium2"=premium2,"Prem_Per2"=premper2,"Premium_Allow"=premallow,"Ad_Cat"=adcategory,"Ad_Sub_Cat"=adsubcat1,"Latest_By"=latestdate,"Status_Material"=material,"File_Name"=matfilename,"Card_Rate"=cardrate,"Disc_Rate"=discrate,"Insert_Status"=insertstatus,"Bill_Status"=billstatus,"Comp_Code"=compcode,"Userid"=userid,"Repeating_Date"=repeat,"No_Insert"=insertno,"Edition_Code"=edi,"Publication_Code"=publi,"Pub_Cent_Code"=pub_cent,"Supp_Code"=supp,"Pai_Free_Ins"=paid,"Agreed_Rate"=agrrate,"Solo_Rate"=solorate,"Gross_Rate"=grossrate,"Page_No"=insert_pageno,"Remarks"=insert_remarks,"Page_Prem"=page_code,"Page_Per"=page_per,"No_Ofcolumn"=noofcol,"Bill_Amt"=billamt,"Bill_Rate"=billrate,"Logo_H"=logo_h, "Logo_W"=logo_w, "Logo_name"=logo_name,"AD_SUBCAT3"=ad_cat_3,"AD_SUBCAT4"=ad_cat_4,"AD_SUBCAT5"=ad_cat_5,PACKAGE_CODE=pkgcode,INSERTS=gridins,PKG_ALIAS=pkgalias,BOXCHARGE=boxcharge_p, VAT_INC=vat_inc_p,VATAMT=vatrate_p, LOCALGROSSAMT=grossamtlocal_p, LOCALBILLAMT=billamtlocal_p, SECTIONCODE=sectioncode_p, RESOURCE_NO=resourceno_p,CAPTION=caption_inserts_p,DEALER_H=dealerheight,DEALER_W=dealerwidth where "Cio_Booking_Id"=cioid AND "Insert_Id"=insertid1;
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

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
resourceno_p varchar2,
caption_inserts_p in varchar2,
subedidata in varchar2

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
resourceno_p varchar2,
caption_inserts_p in varchar2,
subedidata in varchar2
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
error1      varchar2(409);
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

    insert into tbl_booking_insert("Cio_Booking_Id","Edition","Insert_Date","Col_Code","Height","Width","Size_Book","Page_Post","Premium1","Prem_Per1","Premium2","Prem_Per2","Premium_Allow","Ad_Cat","Ad_Sub_Cat","Latest_By","Status_Material","File_Name","Card_Rate","Disc_Rate","Insert_Status","Bill_Status","Comp_Code","Userid","Repeating_Date","No_Insert","Edition_Code","Publication_Code","Pub_Cent_Code","Supp_Code","Pai_Free_Ins","Agreed_Rate","Solo_Rate","Gross_Rate","Page_No","Remarks","Page_Prem","Page_Per","No_Ofcolumn","Bill_Amt","Bill_Rate","Logo_H", "Logo_W", "Logo_name","Insert_Id","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION)
    values(cioid,edition,insertdate,colid,height,width,totalsize,pagepost,premium1,premper1,premium2,premper2,premallow,adcategory,adsubcat1,latestdate,material,matfilename,cardrate,discrate,insertstatus,billstatus,compcode,userid,repeat,insertno,edi,publi,pub_cent,supp,paid,agrrate,solorate,grossrate,insert_pageno,insert_remarks,page_code,page_per,noofcol,billamt,billrate,logo_h,logo_w,logo_name,insertidval,ad_cat_3,ad_cat_4,ad_cat_5, pkgcode,gridins,pkgalias, splboldsizevalue,vatrate_p,boxcharge_p,vat_inc_p ,grossamtlocal_p,billamtlocal_p,sectioncode_p,resourceno_p,caption_inserts_p);
       
    
      if(cirvts is not null) then
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                            values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
      end if;

        insert_edition_details_update(subedidata,null,cioid,insertidval,compcode,edi,insertdate,height,width,totalsize,insertstatus,pkgcode,insertno,insert_pageno,error1);
    else
        update  tbl_booking_insert set  "Edition"=edition,"Insert_Date"=insertdate,"Col_Code"=colid,"Height"=height,"Width"=width,"Size_Book"=totalsize,"Page_Post"=pagepost,"Premium1"=premium1,"Prem_Per1"=premper1,"Premium2"=premium2,"Prem_Per2"=premper2,"Premium_Allow"=premallow,"Ad_Cat"=adcategory,"Ad_Sub_Cat"=adsubcat1,"Latest_By"=latestdate,"Status_Material"=material,"File_Name"=matfilename,"Card_Rate"=cardrate,"Disc_Rate"=discrate,"Insert_Status"=insertstatus,"Bill_Status"=billstatus,"Comp_Code"=compcode,"Userid"=userid,"Repeating_Date"=repeat,"No_Insert"=insertno,"Edition_Code"=edi,"Publication_Code"=publi,"Pub_Cent_Code"=pub_cent,"Supp_Code"=supp,"Pai_Free_Ins"=paid,"Agreed_Rate"=agrrate,"Solo_Rate"=solorate,"Gross_Rate"=grossrate,"Page_No"=insert_pageno,"Remarks"=insert_remarks,"Page_Prem"=page_code,"Page_Per"=page_per,"No_Ofcolumn"=noofcol,"Bill_Amt"=billamt,"Bill_Rate"=billrate,"Logo_H"=logo_h, "Logo_W"=logo_w, "Logo_name"=logo_name,"AD_SUBCAT3"=ad_cat_3,"AD_SUBCAT4"=ad_cat_4,"AD_SUBCAT5"=ad_cat_5,PACKAGE_CODE=pkgcode,INSERTS=gridins,PKG_ALIAS=pkgalias, SPECIAL_SIZE1= splboldsizevalue,VATAMT=vatrate_p,BOXCHARGE=boxcharge_p,VAT_INC=vat_inc_p,LOCALGROSSAMT=grossamtlocal_p,LOCALBILLAMT=billamtlocal_p,SECTIONCODE=sectioncode_p,RESOURCE_NO=resourceno_p,CAPTION=caption_inserts_p  where "Cio_Booking_Id"=cioid and "Insert_Id" = insertid1;
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

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE procedure ad_merge_agency_proc  (
    pcomp_code              in varchar2,
    pfrom_agency_main_code  in varchar2, -- From Agency Main Code
    pfrom_agency_sub_code   in varchar2, -- From Agency Sub Code
    pfrom_agency_code       in varchar2, -- From Agency Code
    pto_agency_main_code    in varchar2,   -- To Agency Main Code
    pto_agency_sub_code     in varchar2,   -- To Agency Sub Code
    pto_agency_code         in varchar2,   -- To Agency Code
    pon_date                in varchar2,
    premarks                in varchar2,
    puser                   in varchar2,
    pdateformat             in varchar2,
    pextra1                 in varchar2,
    pextra2                 in varchar2,
    pextra3                 in varchar2,
    pextra4                 in varchar2,
    pextra5                 in varchar2) 
As
                                                            
v_cnt_ad_merge_agency  number(10);
v_cnt_ad_rcpthdr       number(10);
v_cnt_ad_rcptdet       number(10);
v_cnt_ad_outstand      number(10);
v_cnt_ad_bills         number(10);
v_cnt_ad_bills_det     number(10);
v_cnt_tbl_booking_mast number(10);
v_cnt_status_detail    number(10);
v_cnt_agency_mast      number(10);
v_cnt_tot              number(10);
v_error varchar2(2000);
                                                            
Begin
  v_cnt_ad_merge_agency  :=0;
  v_cnt_ad_rcpthdr       :=0;
  v_cnt_ad_rcptdet       :=0;
  v_cnt_ad_outstand      :=0;
  v_cnt_ad_bills         :=0;
  v_cnt_ad_bills_det     :=0;
  v_cnt_tbl_booking_mast :=0;
  v_cnt_status_detail    :=0;
  v_cnt_agency_mast      :=0;
  v_cnt_tot              :=0;
    
    /*INSERT INTO TEST1 (VSTRING) VALUES ('pcomp_code'||pcomp_code||' pfrom_agency_main_code '||pfrom_agency_main_code
    ||' pfrom_agency_sub_code '||pfrom_agency_sub_code
    ||' pfrom_agency_code '||pfrom_agency_code
    ||' pto_agency_main_code '||pto_agency_main_code
    ||' pto_agency_sub_code '||pto_agency_sub_code
    ||' pto_agency_code '||pto_agency_code
    ||' pon_date '||pon_date
    ||' premarks '||premarks
    ||' puser '||puser
    ||' pdateformat '||pdateformat
    ||' pextra1 '||pextra1
    ||' pextra2 '||pextra2
    ||' pextra3 '||pextra3
    ||' pextra4 '||pextra4
    ||' pextra5 '||pextra5);
    COMMIT; */
    Begin
        insert into ad_merge_agency (comp_code, from_agency_code, from_sub_agency_code, from_code_subcode, to_agency_code,
                                 to_sub_agency_code, to_code_subcode, on_date, remarks, ins_dt, ins_user)
                         values (pcomp_code,pfrom_agency_main_code, pfrom_agency_sub_code, pfrom_agency_code, pto_agency_main_code,
                                 pto_agency_sub_code, pto_agency_code, sysdate, premarks, sysdate, puser);
              v_cnt_ad_merge_agency:=0;                   
          exception when others then
              v_cnt_ad_merge_agency:=1;
    End;
    --INSERT INTO TEST1 (VSTRING) VALUES ('1pcomp_code'||v_cnt_ad_merge_agency);
    Begin
        update ad_rcpthdr set "agcode" = pto_agency_code, "ag_main_code" = pto_agency_main_code, "ag_sub_code" = pto_agency_sub_code
            where "comp_code"    = pcomp_code
              and "agcode"       = pfrom_agency_code
              and "ag_main_code" = pfrom_agency_main_code
              and "ag_sub_code"  = pfrom_agency_sub_code;
             
            v_cnt_ad_rcpthdr:=0;
          exception when others then
             v_cnt_ad_rcpthdr:=1;
             v_error:='1 '||sqlerrm;
    End;
     --INSERT INTO TEST1 (VSTRING) VALUES ('2pcomp_code'||v_cnt_ad_rcpthdr||' ,'||v_error||pto_agency_code||','||pfrom_agency_sub_code||',');
    Begin
        update ad_rcptdet set "agcode" = pto_agency_code, "ag_main_code" = pto_agency_main_code, "ag_sub_code" = pto_agency_sub_code
            where "comp_code"   = pcomp_code
              and "agcode"        = pfrom_agency_code
              and "ag_main_code"  = pfrom_agency_main_code
              and "ag_sub_code"   = pfrom_agency_sub_code;
            v_cnt_ad_rcptdet:=0;
    Exception when others then
             v_cnt_ad_rcptdet:=1;
    End;
     --INSERT INTO TEST1 (VSTRING) VALUES ('3pcomp_code'||v_cnt_ad_rcptdet);
    Begin
        update ad_outstand set agcode = pto_agency_code, ag_main_code = pto_agency_main_code, ag_sub_code = pto_agency_sub_code
            where comp_code    = pcomp_code
              and agcode       = pfrom_agency_code
              and ag_main_code = pfrom_agency_main_code
              and ag_sub_code  = pfrom_agency_sub_code;
          v_cnt_ad_outstand:=0;
    Exception when others then
             v_cnt_ad_outstand:=1;
    End;
     INSERT INTO TEST1 (VSTRING) VALUES ('4pcomp_code'||v_cnt_ad_outstand);
    Begin
        update ad_bills set agcode = pto_agency_code, ag_main_code = pto_agency_main_code, ag_sub_code = pto_agency_sub_code
            where comp_code_v  = pcomp_code
              and  agcode      = pfrom_agency_code
              and ag_main_code = pfrom_agency_main_code
              and ag_sub_code  = pfrom_agency_sub_code;
             v_cnt_ad_bills:=0;
    Exception when others then
             v_cnt_ad_bills:=1;
    End;
    -- INSERT INTO TEST1 (VSTRING) VALUES ('5pcomp_code'||v_cnt_ad_bills);
    Begin
        update ad_bills_det set agcode = pto_agency_code, ag_main_code = pto_agency_main_code, ag_sub_code = pto_agency_sub_code
            where comp_code_v   = pcomp_code
               and agcode       = pfrom_agency_code
               and ag_main_code = pfrom_agency_main_code
               and ag_sub_code  = pfrom_agency_sub_code;
             v_cnt_ad_bills_det:=0;
    Exception when others then
        v_cnt_ad_bills_det:=1;
    End;
     --INSERT INTO TEST1 (VSTRING) VALUES ('6pcomp_code'||v_cnt_ad_bills_det);
    Begin
        update tbl_booking_mast set "Agency_sub_code" = pto_agency_code, "Agency_code" = pto_agency_main_code
            where "Comp_code"       = pcomp_code
              and "Agency_sub_code" = pfrom_agency_code
              and "Agency_code"     = pfrom_agency_main_code;
             v_cnt_tbl_booking_mast:=0;
    Exception when others then
             v_cnt_tbl_booking_mast:=1;
    End;
    -- INSERT INTO TEST1 (VSTRING) VALUES ('7pcomp_code'||v_cnt_tbl_booking_mast);
    Begin
      insert into status_detail (stat_code, status_name, status_alias, from_date, to_date, 
                                 current_datetime, userid, "comp_code", "agency_code", "agency_subcat_code", 
                                 "circular_no", "Remarks",  attachment)
                         values (statuscode_ident.nextval, 'IN0','' ,sysdate, null,
                                 sysdate, puser, pcomp_code, pfrom_agency_main_code,pfrom_agency_code,
                                 '', premarks, '');
              v_cnt_status_detail:=0;                   
          exception when others then
              v_cnt_status_detail:=1;
    End;
    
    /*Begin
      update agency_mast set =
         where "Agency_Code"     = pfrom_agency_main_code
           and "SUB_Agency_Code" = pfrom_agency_sub_code
           and "code_subcode"    = pfrom_agency_code
              v_cnt_agency_mast:=0;                   
          exception when others then
              v_cnt_agency_mast:=1;
  End;*/
  -- INSERT INTO TEST1 (VSTRING) VALUES ('5pcomp_code'||v_cnt_status_detail);
  -- COMMIT;
  Begin
     v_cnt_tot:=nvl(v_cnt_ad_merge_agency,0)+nvl(v_cnt_ad_rcpthdr,0)+nvl(v_cnt_ad_rcptdet,0)+nvl(v_cnt_ad_outstand,0)+nvl(v_cnt_ad_bills,0)+nvl(v_cnt_ad_bills_det,0)+nvl(v_cnt_tbl_booking_mast,0)+nvl(v_cnt_status_detail,0)+nvl(v_cnt_agency_mast,0);
     INSERT INTO TEST1 (VSTRING) VALUES ('pcomp_code'||v_cnt_tot);
     if nvl(v_cnt_tot,0)=0 then
        commit;
     else
        rollback;
     end if;       
  End;   
  
End;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE adb_bindagencyformerge(
    compcode        IN       VARCHAR2,
    agency          IN       VARCHAR2,
    ag_main_code    IN       VARCHAR2,
    agtype          IN       VARCHAR2,
    extra1          IN       VARCHAR2,
    extra2          IN       VARCHAR2,
    p_accounts      OUT      cur_type_new1.cursor_type
)
IS
BEGIN

    if agtype ='P' then
        begin
        OPEN p_accounts FOR
        select  distinct  "Agency_Code","Agency_Name","code_subcode", "SUB_Agency_Code","EmailID","Add1"||"Add2"||"Add3"||"Street" as "Add1",ALERT ALERT from Agency_mast 
        where ("Comp_Code"=compcode) 
          and (("Agency_Name" like  '%'|| agency || '%') or ("Add1"||"Add2"||"Add3"||"Street" like '%'|| agency || '%'))  and ("Type"='P') order by "Agency_Name";
        end;

    elsif agtype ='C' then 
        begin
        OPEN p_accounts FOR
        select  distinct  "Agency_Code","Agency_Name","code_subcode", "SUB_Agency_Code","EmailID","Add1"||"Add2"||"Add3"||"Street" as "Add1",ALERT ALERT from Agency_mast 
        where ("Comp_Code"=compcode) 
          and ("Agency_Code"=ag_main_code)
          and ("Type"='C')
          and (("Agency_Name" like  '%'|| agency || '%') or ("Add1"||"Add2"||"Add3"||"Street" like '%'|| agency || '%'))   order by "Agency_Name";
       
        end; 
    elsif agtype ='CP' then 
        begin
        OPEN p_accounts FOR
        select  distinct  "Agency_Code","Agency_Name","code_subcode", "SUB_Agency_Code","EmailID","Add1"||"Add2"||"Add3"||"Street" as "Add1",ALERT ALERT from Agency_mast 
        where ("Comp_Code"=compcode) 
          and ("Agency_Code"=ag_main_code)
          and (("Agency_Name" like  '%'|| agency || '%') or ("Add1"||"Add2"||"Add3"||"Street" like '%'|| agency || '%'))   order by "Agency_Name";
       
        end;           
     else 
        begin
        OPEN p_accounts FOR
        select  distinct  "Agency_Code","Agency_Name","code_subcode", "SUB_Agency_Code","EmailID","Add1" from Agency_mast 
        where ("Comp_Code"=compcode) and "Agency_Name" like  '%'|| agency || '%'   order by "Agency_Name";
        end;  
    end if;
END;
/

//===========================================End of Script==================================//
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 13/3/2012 @@Agency_merging @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ANKIT 14/3/2012 @@CANCELLATION CHARGE @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
        AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE ,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,"Space_area",BOOK_AUDIT_REQ_AFTER_MOD,EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE   
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
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
p_CURRENCY_MEASUREMENT     IN VARCHAR2,
p_bookingapproval     IN VARCHAR2,
p_EDITABLE_AGENCY_COMM      IN VARCHAR2,
p_CANCELLATION_CHARGE      IN VARCHAR2

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
RECORDS_ON_PAGE = p_paging,RECORDS_ON_PRINT = p_print,HEADER_ON_PAGE = p_allowpage,AGENCY_REQUIRED = p_agency_req,REGION_REQUIRED = p_region_req,ALLOW_FOLLOW_DT_BOOOK=p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=p_CURRENCY_MEASUREMENT,BOOK_AUDIT_REQ_AFTER_MOD =p_bookingapproval,EDITABLE_AGENCY_COMM=p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE=p_CANCELLATION_CHARGE 

  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ANKIT 14/3/2012 @@CANCELLATION CHARGE @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


/************************************6963***********RATE MASTER UPDATE************************MIMOH *******************************/



ALTER PROCEDURE [dbo].[executeratecode]
@compcode as varchar(8),
@ratecode as varchar(8),
@adtype as varchar(8),
@currency as varchar(8),
@rategroup as varchar(8),
@colorcode as varchar(8),
@uomcode as varchar(8),
@packagecode as varchar(8),
@pubcenter as varchar(10),
@adcat as varchar(8)




AS
declare @query as varchar(2000)

/*

CREATE TABLE #Rate_Mast (
	Comp_code varchar (8)  ,
	Rate_Mast_Code varchar (8)  ,
	Adv_Type_Code varchar (8)  ,
	Adv_Cat_Code varchar (8)  ,
	Adv_subcat_code varchar (8)  ,
	Rate_Gr_Code varchar (8)  ,
	Currency varchar (8)  ,
	combin_desc varchar (50)  ,
	Combin_Code varchar (8)  ,
	Uom varchar (8)  ,
	Valid_From datetime ,
	Valid_To datetime ,
	Size_To int ,
	Size_From int ,
	consumption_Per int ,
	Color varchar (8)  ,
	Col_chr_typ varchar (8)  ,
	Remarks varchar (200)  ,
	Week_Day_Rate int ,
	Week_min_rate int ,
	Week_Extra_Rate int ,
	Focus_Day_Rate int ,
	Focus_min_rate int ,
	Focus_extra_rate int ,
	userid varchar (8) ,
	Premium varchar(8),
	Premium_Charges varchar(8),
	weekend_rate float,
	weekend_min_rate float,
	weekend_extra float,
	chksolo varchar(2),
	min_ad_area float,
	Edition_from int,
	Edition_to int,
	floor_amount float,
	floor_discount float,
	scheme_name varchar(50),
	Ad_Subcat4 varchar(8),
	Ad_Subcat5 varchar(8),
	Ad_subcat6 varchar(8),
	From_insertion int,
	To_insertion int,
	Agency_type varchar(8),
	Client_cat varchar(8),
	Max_Area varchar(15),
	rateuniqueid varchar(100)
	
) 


CREATE TABLE #Agency_Rate_Mast (
	Comp_code varchar (8)  ,
	Rate_Mast_Code varchar (8)  ,
	Adv_Type_Code varchar (8)  ,
	Adv_Cat_Code varchar (8)  ,
	Adv_subcat_code varchar (8)  ,
	Rate_Gr_Code varchar (8)  ,
	Currency varchar (8)  ,
	combin_desc varchar (50)  ,
	Combin_Code varchar (8)  ,
	Uom varchar (8)  ,
	Valid_From datetime ,
	Valid_To datetime ,
	Size_To int ,
	Size_From int ,
	consumption_Per int ,
	Color varchar (8)  ,
	Col_chr_typ varchar (8)  ,
	Remarks varchar (200)  ,
	Week_Day_Rate int ,
	Week_min_rate int ,
	Week_Extra_Rate int ,
	Focus_Day_Rate int ,
	Focus_min_rate int ,
	Focus_extra_rate int ,
	userid varchar (8) ,
	Premium varchar(8),
	Premium_Charges varchar(8),
	weekend_rate float,
	weekend_min_rate float,
	weekend_extra float,
	chksolo varchar(2),
	min_ad_area float,
	Edition_from int,
	Edition_to int,
	floor_amount float,
	floor_discount float,
	scheme_name varchar(50),
	Ad_Subcat4 varchar(8),
	Ad_Subcat5 varchar(8),
	Ad_subcat6 varchar(8),
	From_insertion int,
	To_insertion int,
	Agency_type varchar(8),
	Client_cat varchar(8),
	Max_Area varchar(15),
	agency_code varchar(10),
	rateuniqueid varchar(100)
	
)
*/
/*new change ankur for agency*/
set @query='SELECT Comp_code,Rate_Mast_Code,Adv_Type_Code,Adv_Cat_Code,Adv_subcat_code,Rate_Gr_Code,Currency,combin_desc,Combin_Code,Uom,Valid_From,Valid_To,Size_To,Size_From,consumption_Per,Color,Col_chr_typ,Remarks,Week_Day_Rate,Week_min_rate,Week_Extra_Rate,Focus_Day_Rate,Focus_min_rate,Focus_extra_rate,userid,Premium,Premium_Charges,weekend_rate,weekend_min_rate,weekend_extra,chksolo,min_ad_area,Edition_from,Edition_to,floor_amount,floor_discount,(SELECT top 1 Scheme_Code FROM SCHEME_MASTER WHERE scheme_id=RATE_MAST.Scheme_Name) AS Scheme_Name,Ad_Subcat4,Ad_Subcat5,Ad_subcat6,From_insertion,To_insertion,Agency_type,Client_cat,Max_Area,rateuniqueid,pub_center,SUN_RATE,MON_RATE,TUE_RATE,WED_RATE,THU_RATE,FRI_RATE,SAT_RATE,SUN_RATE_EXTRA,MON_RATE_EXTRA,TUE_RATE_EXTRA,WED_RATE_EXTRA,THU_RATE_EXTRA,FRI_RATE_EXTRA,SAT_RATE_EXTRA,MAXWIDTH,(select Combin_Desc from combin_mast where Combin_Code=Rate_Mast.Combin_Code) as [desc],PRIORITY,VAT_DETAIL,ADON, REF_ID,CANCELLATION_CHARGES    FROM RATE_MAST where comp_code='''+@compcode+''''
/*if(@type='company')
begin
	set @query='insert #Rate_Mast select Comp_code,Rate_Mast_Code,Adv_Type_Code,Adv_Cat_Code,Adv_subcat_code,Rate_Gr_Code,Currency,combin_desc,Combin_Code,Uom,Valid_From,Valid_To,Size_To,Size_From,consumption_Per,Color,Col_chr_typ,Remarks,Week_Day_Rate,Week_min_rate,Week_Extra_Rate,Focus_Day_Rate,Focus_min_rate,Focus_extra_rate,userid,Premium,Premium_Charges,weekend_rate,weekend_min_rate,weekend_extra,chksolo,min_ad_area,Edition_from,Edition_to,floor_amount,floor_discount,scheme_name,Ad_Subcat4,Ad_Subcat5,Ad_subcat6,From_insertion,To_insertion,Agency_type,Client_cat,Max_Area,rateuniqueid from rate_mast where comp_code='''+@compcode+''''
end
else
begin
	set @query='insert #Agency_Rate_Mast select Comp_code,Rate_Mast_Code,Adv_Type_Code,Adv_Cat_Code,Adv_subcat_code,Rate_Gr_Code,Currency,combin_desc,Combin_Code,Uom,Valid_From,Valid_To,Size_To,Size_From,consumption_Per,Color,Col_chr_typ,Remarks,Week_Day_Rate,Week_min_rate,Week_Extra_Rate,Focus_Day_Rate,Focus_min_rate,Focus_extra_rate,userid,Premium,Premium_Charges,weekend_rate,weekend_min_rate,weekend_extra,chksolo,min_ad_area,Edition_from,Edition_to,floor_amount,floor_discount,scheme_name,Ad_Subcat4,Ad_Subcat5,Ad_subcat6,From_insertion,To_insertion,Agency_type,Client_cat,Max_Area,agency_code,rateuniqueid from agency_rate_mast where comp_code='''+@compcode+''''

end
*/

if(@ratecode <>'')
begin
set @query=@query+'  and Rate_Mast_Code like ''%'+@ratecode+'%'''
end

if(@adtype <>'0')
begin
set @query=@query+ '  and Adv_Type_Code = '''+@adtype+''''
end

if(@adcat <>'0')
begin
set @query=@query+ '  and Adv_Cat_Code = '''+@adcat+''''
end

if(@currency <> '0')
begin
set @query=@query+'  and Currency = '''+@currency+''''
end

if(@rategroup <> '0')
begin
set @query=@query+'  and Rate_Gr_Code = '''+@rategroup+''''
end

if(@colorcode <> '0')
begin
set @query=@query+'  and Color = '''+@colorcode+''''
end

if(@uomcode <> '0')
begin
set @query=@query+'  and Uom = '''+@uomcode+''''
end

if(@packagecode <> '0')
begin
set @query=@query+'  and combin_code like ''%'+@packagecode+'%'''
end

if(@pubcenter <> '0')
begin
set @query=@query+'  and pub_center  = '''+@pubcenter+''''
end

print(@query)
exec(@query)

/*new change ankur for agency*/
/*
if(@type='company')
begin
	 select Comp_code,Rate_Mast_Code,Adv_Type_Code,Adv_Cat_Code,Adv_subcat_code,Rate_Gr_Code,Currency,combin_desc,Combin_Code,Uom,convert(varchar(10),Valid_From,101) as Valid_From,convert(varchar(10),Valid_To,101) as Valid_To,Size_To,Size_From,consumption_Per,Color,Col_chr_typ,Remarks,cast(Week_Day_Rate as decimal(9,2)) as Week_Day_Rate  ,Week_min_rate,Week_Extra_Rate,cast(Focus_Day_Rate as decimal(9,2)) as Focus_Day_Rate,Focus_min_rate,Focus_extra_rate,userid,Premium,Premium_Charges,cast(weekend_rate as decimal(9,2)) as weekend_rate,weekend_min_rate,weekend_extra,chksolo,min_ad_area,Edition_from,Edition_to,floor_amount,floor_discount,scheme_name,Ad_Subcat4,Ad_Subcat5,Ad_subcat6,From_insertion,To_insertion,Agency_type,Client_cat,Max_Area,rateuniqueid from #Rate_Mast
end
else
begin

	 select Comp_code,Rate_Mast_Code,Adv_Type_Code,Adv_Cat_Code,Adv_subcat_code,Rate_Gr_Code,Currency,combin_desc,Combin_Code,Uom,convert(varchar(10),Valid_From,101) as Valid_From,convert(varchar(10),Valid_To,101) as Valid_To,Size_To,Size_From,consumption_Per,Color,Col_chr_typ,Remarks,cast(Week_Day_Rate as decimal(9,2)) as Week_Day_Rate  ,Week_min_rate,Week_Extra_Rate,cast(Focus_Day_Rate as decimal(9,2)) as Focus_Day_Rate,Focus_min_rate,Focus_extra_rate,userid,Premium,Premium_Charges,cast(weekend_rate as decimal(9,2)) as weekend_rate,weekend_min_rate,weekend_extra,chksolo,min_ad_area,Edition_from,Edition_to,floor_amount,floor_discount,scheme_name,Ad_Subcat4,Ad_Subcat5,Ad_subcat6,From_insertion,To_insertion,Agency_type,Client_cat,Max_Area,agency_code,rateuniqueid from #Agency_Rate_Mast
end
*/
--drop table #Rate_Mast



/**************************************************************************************************************/




ALTER PROCEDURE [dbo].[modifyratecode]
@compcode as varchar(8),
@userid as varchar(8),
@ratecode as varchar(8),
@adtype as varchar(8),
@rategroupcode as varchar(8),
@adcategory as varchar(8),
@currency as varchar(8),
@adsubcategory as varchar(8),
@package as varchar(8),
@packagedesc as varchar(2000),
@uom as varchar(8),
@sizefrom as float,
@sizeto as float,
@consumption as int,
@color as varchar(8),
@colorchrty as varchar(8),
@weekdrate as float,
@weeminrate as float,
@extweerate as float,
@focusdarate as float,
@focminrate as float,
@focexrate as float,
@validfromdate as datetime,
@validtill as datetime,
@remarks as varchar(200),
@premiumval as varchar(8),
@premium as varchar(8),
@rateuniqueid as varchar(100),
@weekendrate as float,
@weekendmin as float,
@weekendextra as float,
@editionto as int,
@editionfrom as int,
@flramount as float,
@flrdiscount as float,
@scheme as varchar(50),
@minadarea as float,
@adscat4 as varchar(8),
@adscat5 as varchar(8),
@adscat6 as varchar(8),
@frominsert as int,
@toinsert as int,
@agtype as varchar(8),
@clientcat as varchar(8),
@max_area as varchar(15),
/*new change ankur for agency*/
@type as varchar(10),
@agencycode as varchar(20),
@rate_sun as float,
@rate_mon as float,
@rate_tue as float,
@rate_wed as float,
@rate_thu as float,
@rate_fri as float,
@rate_sat as float,

@rate_sun_extra as float,
@rate_mon_extra as float,
@rate_tue_extra as float,
@rate_wed_extra as float,
@rate_thu_extra as float,
@rate_fri_extra as float,
@rate_sat_extra as float,
@width_max  as float,
@priority_m as int,
@vat as varchar(5),
@Adon	as varchar(5),
@refrence	as varchar(200),
@p_cancellation as varchar(100)
AS

--declare @rateuniqueid  varchar(100)

--set @rateuniqueid=@ratecode+@adtype+@adcategory+@adsubcategory+@color+@package+@currency+cast(@validfromdate as varchar(10))+cast(@validtill as varchar(10))
/*new change ankur for agency*/

update rate_mast set Adv_Type_Code=@adtype,Adv_Cat_Code=@adcategory,Adv_subcat_code=@adsubcategory,Rate_Gr_Code=@rategroupcode,Currency=@currency,combin_desc=@packagedesc,
Combin_Code=@package,Uom=@uom,Valid_From=@validfromdate,Valid_To=@validtill,Size_To=@sizeto,Size_From=@sizefrom,consumption_Per=@consumption,Color=@color,Col_chr_typ=@colorchrty,
Remarks=@remarks,Week_Day_Rate=@weekdrate,Week_min_rate=@weeminrate,Week_Extra_Rate=@extweerate,Focus_Day_Rate=@focusdarate,Focus_min_rate=@focminrate,Focus_extra_rate=@focexrate,
Premium=@Premium,Premium_Charges=@Premiumval,weekend_rate=@weekendrate,weekend_min_rate=@weekendmin,weekend_extra=@weekendextra,Edition_from=@editionfrom,Edition_to=@editionto, floor_amount=@flramount, floor_discount=@flrdiscount,Scheme_Name=@scheme,min_ad_area=@minadarea,

Ad_Subcat4=@adscat4 , Ad_Subcat5=@adscat5 , Ad_subcat6=@adscat6 ,From_insertion=@frominsert,To_insertion=@toinsert,Agency_type=@agtype,Client_cat=@clientcat,Max_Area=@max_area, 
  sun_rate=@rate_sun,
             mon_rate=@rate_mon,
             tue_rate=@rate_tue,
             wed_rate=@rate_wed,
             thu_rate=@rate_thu,
             fri_rate=@rate_fri,
             sat_rate=@rate_sat,

             sun_rate_extra=@rate_sun_extra,
             mon_rate_extra=@rate_mon_extra,
             tue_rate_extra=@rate_tue_extra,
             wed_rate_extra=@rate_wed_extra,
             thu_rate_extra=@rate_thu_extra,
             fri_rate_extra=@rate_fri_extra,
             sat_rate_extra=@rate_sat_extra,
			 maxwidth=@width_max,
			priority=@priority_m,
			VAT_DETAIL=@vat,
			CANCELLATION_CHARGES=@p_cancellation
			--ADON=@Adon, 
			--REF_ID=@refrence  
where  rateuniqueid=@rateuniqueid and comp_code=@compcode





/**************************************************************************************/

ALTER PROCEDURE [dbo].[insertratemast]
@compcode as varchar(8),
@userid as varchar(8),
@ratecode as varchar(8),
@adtype as varchar(8),
@rategroupcode as varchar(8),
@adcategory as varchar(8),
@currency as varchar(8),
@adsubcategory as varchar(8),
@package as varchar(8),
@packagedesc as varchar(2000),
@uom as varchar(8),
@sizefrom as float,
@sizeto as float,
@consumption as int,
@color as varchar(8),
@colorchrty as varchar(8),
@weekdrate as float,
@weeminrate as float,
@extweerate as float,
@focusdarate as float,
@focminrate as float,
@focexrate as float,
@validfromdate as datetime,
@validtill as datetime,
@remarks as varchar(200),
@premiumval as varchar(8),
@premium as varchar(8),
@rateuniqueid as varchar(100),
@weekendrate as float,
@weekendmin as float,
@weekendextra as float,
@minadarea as float,
@editionfrom as int,
@editionto as int,
@flramount as float,
@flrdiscount as float,
@scheme as varchar(50),
@adscat4 as varchar(8),
@adscat5 as varchar(8),
@adscat6 as varchar(8),
@frominsert as int,
@toinsert as int,
@agtype as varchar(8),
@clientcat as varchar(8),
@max_area as varchar(15),
@type as varchar(10),
@agencycode as varchar(20),
@pubcenter       as varchar(50),

@rate_sun        as float,
@rate_mon        as float,
@rate_tue          as float,
@rate_wed        as float,
@rate_thu        as float,
@rate_fri         as float,
@rate_sat      as float,

@rate_sun_extra   as float,
@rate_mon_extra   as float,
@rate_tue_extra   as float,
@rate_wed_extra   as float,
@rate_thu_extra   as float,
@rate_fri_extra   as float,
@rate_sat_extra   as float,
@width_max   as float,
@priority_m	as int,
@vat as varchar(5),
@Adon	as varchar(5),
@refrence	as varchar(200),
@p_cancellation as varchar(100)

AS
/*new change ankur for agency*/

 INSERT INTO rate_mast
                      (rateuniqueid,Comp_code, Rate_Mast_Code, Adv_Type_Code,
                       Adv_Cat_Code, Adv_subcat_code, Rate_Gr_Code,
                       Currency, combin_desc, Combin_Code, Uom,
                       Valid_From, Valid_To, Size_To, Size_From,
                       consumption_Per, Color, Col_chr_typ, Remarks,
                       Week_Day_Rate, Week_min_rate, Week_Extra_Rate,
                       Focus_Day_Rate, Focus_min_rate, Focus_extra_rate,
                       userid, Premium, Premium_Charges,
                       weekend_rate, weekend_min_rate, weekend_extra,
                       min_ad_area, Edition_from, Edition_to,
                       floor_amount, floor_discount, Scheme_Name,
                       Ad_Subcat4, Ad_Subcat5, Ad_subcat6,
                       From_insertion, To_insertion, Agency_type,
                       Client_cat ,Max_Area ,pub_center,
                       sun_rate,mon_rate,tue_rate,wed_rate,thu_rate,fri_rate,sat_rate,
                       sun_rate_extra,mon_rate_extra,tue_rate_extra,wed_rate_extra,thu_rate_extra,fri_rate_extra,sat_rate_extra,maxwidth ,priority,VAT_DETAIL,
					   ADON, REF_ID ,CANCELLATION_CHARGES     
                      )
               VALUES (@rateuniqueid,@compcode, @ratecode, @adtype,
                       @adcategory, @adsubcategory, @rategroupcode,
                       @currency, @packagedesc, @package, @uom,
                       @validfromdate, @validtill, @sizeto, @sizefrom,
                       @consumption, @color, @colorchrty, @remarks,
                       @weekdrate, @weeminrate, @extweerate,
                       @focusdarate, @focminrate, @focexrate,
                       @userid, @premium, @premiumval,
                       @weekendrate, @weekendmin, @weekendextra,
                       @minadarea, @editionfrom, @editionto,
                       @flramount, @flrdiscount, @scheme,
                       @adscat4, @adscat5, @adscat6,
                       @frominsert, @toinsert, @agtype,
                       @clientcat  ,@max_area ,@pubcenter,
                       @rate_sun,@rate_mon,@rate_tue,@rate_wed,@rate_thu,@rate_fri,@rate_sat,
                       @rate_sun_extra,@rate_mon_extra,@rate_tue_extra,@rate_wed_extra,@rate_thu_extra,@rate_fri_extra,@rate_sat_extra,@width_max,@priority_m,@vat,
					   @Adon,@refrence,@p_cancellation
                      )













/************************************6963***********RATE MASTER UPDATE************************MIMOH *******************************/

@@@@@@  ankit  @@@@@@@@@@@@@@@@@@@@@@  6940  13 march  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
p_CURRENCY_MEASUREMENT     IN VARCHAR2,
p_bookingapproval     IN VARCHAR2,
p_EDITABLE_AGENCY_COMM      IN VARCHAR2

);
END      Wesp_Updatedate;
/

@@@@@@  ankit  @@@@@@@@@@@@@@@@@@@@@@  6940  13 march  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


@@@@@@  ankit  @@@@@@@@@@@@@@@@@@@@@@  CANCELLATION CHARGE  14 march  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


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
p_CURRENCY_MEASUREMENT     IN VARCHAR2,
p_bookingapproval     IN VARCHAR2,
p_EDITABLE_AGENCY_COMM      IN VARCHAR2,
p_CANCELLATION_CHARGE      IN VARCHAR2

);
END      Wesp_Updatedate;
/

@@@@@@  ankit  @@@@@@@@@@@@@@@@@@@@@@  CANCELLATION CHARGE  14 march  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
/**********************************mimoh prefrences****************************************************/
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
        AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE ,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,"Space_area",EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE   
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/
/***********************************************************/
CREATE OR REPLACE PACKAGE HT18JULY.Wesp_Updatedate
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
p_CURRENCY_MEASUREMENT     IN VARCHAR2,

p_EDITABLE_AGENCY_COMM      IN VARCHAR2,
p_CANCELLATION_CHARGE      IN VARCHAR2

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
p_CURRENCY_MEASUREMENT     IN VARCHAR2,

p_EDITABLE_AGENCY_COMM      IN VARCHAR2,
p_CANCELLATION_CHARGE      IN VARCHAR2

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
RECORDS_ON_PAGE = p_paging,RECORDS_ON_PRINT = p_print,HEADER_ON_PAGE = p_allowpage,AGENCY_REQUIRED = p_agency_req,REGION_REQUIRED = p_region_req,ALLOW_FOLLOW_DT_BOOOK=p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=p_CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT=p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM=p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE=p_CANCELLATION_CHARGE 

  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/
/****************************************************************/


/**********************************mimoh prefrences****************************************************/

******************************8SEND SUMIT DHAMA  PROC *************************
CREATE OR REPLACE PROCEDURE rpt_unregistered_client (
   pcompcode      IN       VARCHAR2,
   pbranchcode    IN       VARCHAR2,
   pdatefrom      IN       VARCHAR2,
   pdateto        IN       VARCHAR2,
   pdateformate   IN       VARCHAR2,
   padtype        IN       VARCHAR2,
   puomcode       IN       VARCHAR2,
   pdate_flag     IN       VARCHAR2, --for on booking date B or Publish date P
   pextra1        IN       VARCHAR2,
   pextra2        IN       VARCHAR2,
   pextra3        IN       VARCHAR2,
   pextra4        IN       VARCHAR2,
   pextra5        IN       VARCHAR2,
   p_accounts     OUT      cur_type_new1.cursor_type
)
IS
   v_frdt    DATE;
   v_todt    DATE;
   v_query   VARCHAR2 (8000);
BEGIN
   v_frdt := TO_DATE (pdatefrom, '''' || pdateformate || '''');
   v_todt := TO_DATE (pdateto, '''' || pdateformate || '''');
   v_query :=
         'SELECT distinct a."date_time" as "BKDATE",a."Client_code" AS "CLIENTNAME", "Client_address" AS "CLIENT_ADDRESS",
        a."cio_booking_id" AS "CIOID", b."Agency_Name" as "AGENCY_NAME", c."Adv_Type_Name" as "ADV_TYPE_NAME",
        (select "Package_Name" from combin_mast where "Comp_Code"='''
      || pcompcode
      || ''' and "Combin_Code"=(
        case when instr(''abcdef'','','') >0 then substr(a."Package_code",1,instr(a."Package_code",'','')-1)  
        else a."Package_code" end)) as "PACKAGE_NAME", e."Adv_Cat_Name" as "ADV_CAT_NAME", 
        a."Total_area" as "TOTAL_AREA", a."Rate_code" as "RATE_CODE",
        a."Card_rate" as "CARD_RATE", a."Bill_amount" as "BILL_AMOUNT", a."Gross_amount" as "GROSS_AMOUNT", 
        f."Uom_Name" as "UOM_NAME",g."Comp_Name" as "COMP_NAME"
    FROM tbl_booking_mast a,agency_mast b,adv_type_mast c,adv_cat_mast e,uom_mast f,comp_mst g,tbl_booking_insert i
    WHERE a."Comp_code" = g."Comp_Code" AND a."Comp_code" = i."Comp_Code" AND a."Comp_code" ='''
      || pcompcode
      || ''' and 
        a."cio_booking_id" = i."Cio_Booking_Id"';

   IF pdate_flag = 'B'
   THEN
      v_query :=
            v_query
         || ' AND a."date_time" BETWEEN '''
         || v_frdt
         || ''' AND '''
         || v_todt
         || ''' 
                    AND b."code_subcode" = a."Agency_sub_code" and 
                    not exists (SELECT ''x'' FROM cust_mast where "Cust_Code"=a."Client_code")
                    AND a."Ad_type_code" = c."Adv_Type_Code" AND a."Ad_type_code" =nvl('''
         || padtype
         || ''',a."Ad_type_code") 
                    AND a."Uom_code" = f."Uom_Code" AND a."Uom_code" =nvl('''
         || puomcode
         || ''',a."Uom_code")
                    AND a."Ad_cat_code" = e."Adv_Cat_Code"
                    AND a."branch" = nvl('''
         || pbranchcode
         || ''',a."branch")';
   ELSE
      v_query :=
            v_query
         || ' AND i."Insert_Date" BETWEEN '''
         || v_frdt
         || ''' AND '''
         || v_todt
         || ''' 
                    AND b."code_subcode" = a."Agency_sub_code" and 
                    not exists (SELECT ''x'' FROM cust_mast where "Cust_Code"=a."Client_code")
                    AND a."Ad_type_code" = c."Adv_Type_Code" AND a."Ad_type_code" =nvl('''
         || padtype
         || ''',a."Ad_type_code") 
                    AND a."Uom_code" = f."Uom_Code" AND a."Uom_code" =nvl('''
         || puomcode
         || ''',a."Uom_code")
                    AND a."Ad_cat_code" = e."Adv_Cat_Code"
                    AND a."branch" = nvl('''
         || pbranchcode
         || ''',a."branch")';
   END IF;

   IF pextra1 IS NOT NULL
   THEN
      v_query :=
            v_query
         || ' AND i."Cio_Booking_Id" in ('
         || pextra1
         || ') order by bkdate,cioid';
   ELSE
      v_query := v_query || ' order by bkdate,cioid';
   END IF;

   DELETE FROM test1;

   INSERT INTO test1
               (vstring, vstring2
               )
        VALUES (' unregistered_client ' || pextra1, v_query
               );

   COMMIT;

   OPEN p_accounts FOR v_query;
END rpt_unregistered_client;
/

*****************************************END SUMIT DHAMA PRUC.*******************



@@@@@@@@@@@@@@@@@@@sumit@@@@@@@@follow up $ mis@@@@@@@@14\03\2012@@@@@@@@@@@

CREATE OR REPLACE PROCEDURE fetch_booking_for_mis (
   pcompcode       IN       VARCHAR2,
   pcenter         IN       VARCHAR2,
   pbranch         IN       VARCHAR2,
   padtype         IN       VARCHAR2,
   padcatg         IN       VARCHAR2,
   pag_main_code   IN       VARCHAR2,
   pag_sub_code    IN       VARCHAR2,
   pclient         IN       VARCHAR2,
   pexec_code      IN       VARCHAR2,
   pret_code       IN       VARCHAR2,
   pbkid           IN       VARCHAR2,
   pfrom_date      IN       VARCHAR2,
   ptill_date      IN       VARCHAR2,
   pfetch_on       IN       VARCHAR2,
                                     --B for booking date.P for published date
   pdateformat     IN       VARCHAR2,
   puserid         IN       VARCHAR2,
   pextra1         IN       VARCHAR2,
   pextra2         IN       VARCHAR2,
   pextra3         IN       VARCHAR2,
   pextra4         IN       VARCHAR2,
   pextra5         IN       VARCHAR2,
   pextra6         IN       VARCHAR2,
   pextra7         IN       VARCHAR2,
   pextra8         IN       VARCHAR2,
   pextra9         IN       VARCHAR2,
   pextra10        IN       VARCHAR2,
   p_accounts      OUT      cur_type_new1.cursor_type,
   p_accounts1     OUT      cur_type_new1.cursor_type
)
IS
   v_frdt   DATE;
   v_todt   DATE;
BEGIN
   v_frdt := TO_DATE (pfrom_date, pdateformat);
   v_todt := TO_DATE (ptill_date, pdateformat);

   IF pfetch_on = 'B'
   THEN
      OPEN p_accounts FOR
         SELECT DISTINCT m."cio_booking_id" AS cio_booking_id,
                         m."Comp_code" AS "COMP_CODE",
                         m."date_time" AS "DATE_TIME",
                         m."branch" AS "BRANCH",
                         (SELECT "Branch_Name"
                            FROM branch_mst
                           WHERE "Branch_Code" = m."branch")
                                                            AS "BRANCH_NAME",
                         m."Ad_size_height" AS "HEIGHT",
                         m."Ad_size_width" AS "WIDTH", m."RO_No" AS "RO_NO",
                         m."RO_Date" AS "RO_DATE", m."Key_no" AS "KEY_NO",
                         m."Caption" "CAPTION", m."Page_no" AS "PAGE_NO",
                         m."Client_code" AS "CLIENT_CODE",
                         NVL
                            ((SELECT "Cust_Name"
                                FROM cust_mast
                               WHERE cust_mast."Comp_Code" = m."Comp_code"
                                 AND cust_mast."Cust_Code" = m."Client_code"),
                             m."Client_code"
                            ) AS "CLIENT_NAME",
                         m."Agency_sub_code" AS "AGENCY_SUB_CODE",
                         a."Agency_Name" AS "AGENCY_NAME",
                         m."Insertion_date" AS "INSERTION_DATE",
                         m."Executive_code" AS "EXECUTIVE_CODE",
                         (SELECT "Exec_name"
                            FROM exec_mast
                           WHERE TO_CHAR
                                      (exec_mast."Exe_no") =
                                       m."Executive_code")
                                                         AS "EXECUTIVE_NAME",
                         m.retainer AS "RETAINER",
                         (SELECT "Retain_Name"
                            FROM retainermaster
                           WHERE "Retain_Code" =
                                                m.retainer)
                                                          AS "RETAINER_NAME",
                         (SELECT DISTINCT i."industry_name"
                                     FROM industry_master i,
                                          product_cat_mast p
                                    WHERE p."prod_cat_code" = m."Product_code"
                                      AND i."industry_code" =
                                                             p."industry_code")
                                                          AS "INDUSTRY_NAME",
                         (SELECT DISTINCT i."industry_code"
                                     FROM industry_master i,
                                          product_cat_mast p
                                    WHERE p."prod_cat_code" = m."Product_code"
                                      AND i."industry_code" =
                                                             p."industry_code")
                                                          AS "INDUSTRY_CODE",
                         m."Product_code" AS "PRODUCT_CODE",
                         (SELECT "prod_desc"
                            FROM product_cat_mast
                           WHERE "prod_cat_code" =
                                           m."Product_code")
                                                           AS "PRODUCT_NAME",
                         m."Brand_code" AS "BRAND_CODE",
                         (SELECT "brand_name"
                            FROM brand_mst
                           WHERE "brand_code" =
                                               m."Brand_code")
                                                             AS "BRAND_NAME",
                         m."Ad_type_code" AS "AD_TYPE_CODE",
                         (SELECT "Adv_Type_Name"
                            FROM adv_type_mast
                           WHERE "Adv_Type_Code" =
                                           m."Ad_type_code")
                                                           AS "AD_TYPE_NAME",
                         m."Ad_cat_code" AS "AD_CAT_CODE",
                         (SELECT "Adv_Cat_Name"
                            FROM adv_cat_mast
                           WHERE "Comp_Code" = m."Comp_code"
                             AND "Adv_Cat_Code" = m."Ad_cat_code")
                                                            AS "AD_CAT_NAME",
                         CASE
                            WHEN m."Ad_sub_cat_code" =
                                                     '0'
                             OR m."Ad_sub_cat_code" = ''
                               THEN NULL
                            ELSE m."Ad_sub_cat_code"
                         END AS "AD_SUB_CAT_CODE",
                         (SELECT "Adv_Subcat_Name"
                            FROM adv_subcat_mast
                           WHERE "Comp_Code" =
                                            m."Comp_code"
                             AND "Adv_Subcat_Code" = m."Ad_sub_cat_code")
                                                         AS "AD_SUBCAT_NAME",
                         m."Color_code" AS "COLOR_CODE",
                         (SELECT "Col_Name"
                            FROM col_mast
                           WHERE "Col_Code" = m."Color_code")
                                                             AS "COLOR_NAME",
                         m."Uom_code",
                         (SELECT "UOM_DESC"
                            FROM uom_mast
                           WHERE "Uom_Code" = m."Uom_code") AS "UOM_NAME",
                         CASE
                            WHEN m."Variant" = '0'
                             OR "Variant" = ''
                               THEN NULL
                            ELSE m."Variant"
                         END AS "VARIANT",
                         (SELECT "Varient_Name"
                            FROM varient_mst
                           WHERE "Comp_Code" =
                                              m."Comp_code"
                             AND "Varient_Code" = m."Variant")
                                                           AS "VARIANT_NAME"
                    FROM tbl_booking_mast m,
                         tbl_booking_insert i,
                         agency_mast a,
                         branch_mst b
                   WHERE m."Comp_code" = i."Comp_Code"
                     AND m."Comp_code" = a."Comp_Code"
                     AND m."Comp_code" = pcompcode
                     AND m."cio_booking_id" = i."Cio_Booking_Id"
                     AND a."Agency_Code" || a."SUB_Agency_Code" =
                                                           m."Agency_sub_code"
                     AND a."Agency_Code" =
                                          NVL (pag_main_code, a."Agency_Code")
                     AND a."SUB_Agency_Code" =
                                       NVL (pag_sub_code, a."SUB_Agency_Code")
                     AND m."date_time" BETWEEN v_frdt AND v_todt
                     AND m."Client_code" = NVL (pclient, m."Client_code")
                     AND m."branch" = NVL (pbranch, m."branch")
                     AND b."pub_center" = NVL (pcenter, b."pub_center")
                     AND m."cio_booking_id" = NVL (pbkid, m."cio_booking_id")
                     AND m."Ad_type_code" = NVL (padtype, m."Ad_type_code")
                     AND m."Executive_code" =
                                          NVL (pexec_code, m."Executive_code")
                     AND i."Page_No" = NVL (pextra1, i."Page_No")
                ORDER BY comp_code, cio_booking_id, date_time;
   ELSE
      OPEN p_accounts FOR
         SELECT DISTINCT m."cio_booking_id" AS cio_booking_id,
                         m."Comp_code" AS "COMP_CODE",
                         m."date_time" AS "DATE_TIME",
                         m."branch" AS "BRANCH",
                         (SELECT "Branch_Name"
                            FROM branch_mst
                           WHERE "Branch_Code" = m."branch")
                                                            AS "BRANCH_NAME",
                         m."Ad_size_height" AS "HEIGHT",
                         m."Ad_size_width" AS "WIDTH", m."RO_No" AS "RO_NO",
                         m."RO_Date" AS "RO_DATE", m."Key_no" AS "KEY_NO",
                         m."Caption" "CAPTION", m."Page_no" AS "PAGE_NO",
                         m."Client_code" AS "CLIENT_CODE",
                         NVL
                            ((SELECT "Cust_Name"
                                FROM cust_mast
                               WHERE cust_mast."Comp_Code" = m."Comp_code"
                                 AND cust_mast."Cust_Code" = m."Client_code"),
                             m."Client_code"
                            ) AS "CLIENT_NAME",
                         m."Agency_sub_code" AS "AGENCY_SUB_CODE",
                         a."Agency_Name" AS "AGENCY_NAME",
                         m."Insertion_date" AS "INSERTION_DATE",
                         m."Executive_code" AS "EXECUTIVE_CODE",
                         (SELECT "Exec_name"
                            FROM exec_mast
                           WHERE TO_CHAR
                                      (exec_mast."Exe_no") =
                                       m."Executive_code")
                                                         AS "EXECUTIVE_NAME",
                         m.retainer AS "RETAINER",
                         (SELECT "Retain_Name"
                            FROM retainermaster
                           WHERE "Retain_Code" =
                                                m.retainer)
                                                          AS "RETAINER_NAME",
                         (SELECT DISTINCT i."industry_name"
                                     FROM industry_master i,
                                          product_cat_mast p
                                    WHERE p."prod_cat_code" = m."Product_code"
                                      AND i."industry_code" =
                                                             p."industry_code")
                                                          AS "INDUSTRY_NAME",
                         (SELECT DISTINCT i."industry_code"
                                     FROM industry_master i,
                                          product_cat_mast p
                                    WHERE p."prod_cat_code" = m."Product_code"
                                      AND i."industry_code" =
                                                             p."industry_code")
                                                          AS "INDUSTRY_CODE",
                         m."Product_code" AS "PRODUCT_CODE",
                         (SELECT "prod_desc"
                            FROM product_cat_mast
                           WHERE "prod_cat_code" =
                                           m."Product_code")
                                                           AS "PRODUCT_NAME",
                         m."Brand_code" AS "BRAND_CODE",
                         (SELECT "brand_name"
                            FROM brand_mst
                           WHERE "brand_code" =
                                               m."Brand_code")
                                                             AS "BRAND_NAME",
                         m."Ad_type_code" AS "AD_TYPE_CODE",
                         (SELECT "Adv_Type_Name"
                            FROM adv_type_mast
                           WHERE "Adv_Type_Code" =
                                           m."Ad_type_code")
                                                           AS "AD_TYPE_NAME",
                         m."Ad_cat_code" AS "AD_CAT_CODE",
                         (SELECT "Adv_Cat_Name"
                            FROM adv_cat_mast
                           WHERE "Comp_Code" = m."Comp_code"
                             AND "Adv_Cat_Code" = m."Ad_cat_code")
                                                            AS "AD_CAT_NAME",
                         CASE
                            WHEN m."Ad_sub_cat_code" =
                                                     '0'
                             OR m."Ad_sub_cat_code" = ''
                               THEN NULL
                            ELSE m."Ad_sub_cat_code"
                         END AS "AD_SUB_CAT_CODE",
                         (SELECT "Adv_Subcat_Name"
                            FROM adv_subcat_mast
                           WHERE "Comp_Code" =
                                            m."Comp_code"
                             AND "Adv_Subcat_Code" = m."Ad_sub_cat_code")
                                                         AS "AD_SUBCAT_NAME",
                         m."Color_code" AS "COLOR_CODE",
                         (SELECT "Col_Name"
                            FROM col_mast
                           WHERE "Col_Code" = m."Color_code")
                                                             AS "COLOR_NAME",
                         m."Uom_code",
                         (SELECT "UOM_DESC"
                            FROM uom_mast
                           WHERE "Uom_Code" = m."Uom_code") AS "UOM_NAME",
                         CASE
                            WHEN m."Variant" = '0'
                             OR "Variant" = ''
                               THEN NULL
                            ELSE m."Variant"
                         END AS "VARIANT",
                         (SELECT "Varient_Name"
                            FROM varient_mst
                           WHERE "Comp_Code" =
                                              m."Comp_code"
                             AND "Varient_Code" = m."Variant")
                                                           AS "VARIANT_NAME"
                    FROM tbl_booking_mast m,
                         tbl_booking_insert i,
                         agency_mast a,
                         branch_mst b
                   WHERE m."Comp_code" = i."Comp_Code"
                     AND m."Comp_code" = a."Comp_Code"
                     AND m."Comp_code" = pcompcode
                     AND m."cio_booking_id" = i."Cio_Booking_Id"
                     AND a."Agency_Code" || a."SUB_Agency_Code" =
                                                           m."Agency_sub_code"
                     AND a."Agency_Code" =
                                          NVL (pag_main_code, a."Agency_Code")
                     AND a."SUB_Agency_Code" =
                                       NVL (pag_sub_code, a."SUB_Agency_Code")
                     AND i."Insert_Date" BETWEEN v_frdt AND v_todt
                     AND m."Client_code" = NVL (pclient, m."Client_code")
                     AND m."branch" = NVL (pbranch, m."branch")
                     AND b."pub_center" = NVL (pcenter, b."pub_center")
                     AND m."cio_booking_id" = NVL (pbkid, m."cio_booking_id")
                     AND m."Ad_type_code" = NVL (padtype, m."Ad_type_code")
                     AND m."Executive_code" =
                                          NVL (pexec_code, m."Executive_code")
                     AND i."Page_No" = NVL (pextra1, i."Page_No")
                ORDER BY comp_code, cio_booking_id, date_time;
   END IF;

   OPEN p_accounts1 FOR
      SELECT SYSDATE AS "CUR_DATE"
        FROM DUAL;
END fetch_booking_for_mis;
/
//////////////////////////////////////////////////////////////////////
CREATE OR REPLACE PROCEDURE industryselect (
   compcode     IN       VARCHAR2,
   industry     IN       VARCHAR,
   p_accounts   OUT      cur_type_new1.cursor_type
)
IS
BEGIN
   OPEN p_accounts FOR
      SELECT   "industry_code", "industry_name"
          FROM industry_master
         WHERE "comp_code" = compcode
           AND "industry_name" LIKE '%' || industry || '%'
      ORDER BY "industry_name";
END;
/
/////////////////////////////////////////////////////////////////
CREATE OR REPLACE PROCEDURE productselect (
   compcode     IN       VARCHAR2,
   product      IN       VARCHAR,
   ind_code     IN       VARCHAR,
   p_accounts   OUT      cur_type_new1.cursor_type
)
IS
BEGIN
   OPEN p_accounts FOR
      SELECT   "prod_cat_code", "prod_desc"
          FROM product_cat_mast
         WHERE "comp_code" = compcode
           AND "industry_code" = ind_code
           AND "prod_desc" LIKE '%' || product || '%'
      ORDER BY "prod_desc";
END;
/
////////////////////////////////////////////////////////////////
CREATE OR REPLACE PROCEDURE websp_misupdate (
   pcompcode      IN   VARCHAR,
   pbkid          IN   VARCHAR,
   product_code   IN   VARCHAR,
   brand_code     IN   VARCHAR,
   varient_code   IN   VARCHAR
)
AS
BEGIN
   UPDATE tbl_booking_mast
      SET "Product_code" = product_code,
          "Brand_code" = brand_code,
          "Variant" = varient_code
    WHERE "Comp_code" = pcompcode AND "cio_booking_id" = pbkid;
END websp_misupdate;
/
////////////////////////////////////////////////////////////
CREATE OR REPLACE PROCEDURE followup (
   pcompcode      IN       VARCHAR2,
   pagency        IN       VARCHAR2,
   pclient        IN       VARCHAR2,
   pdatefrom      IN       VARCHAR2,
   pdateto        IN       VARCHAR2,
   pdateformate   IN       VARCHAR2,
   pextra1        IN       VARCHAR2,
   pextra2        IN       VARCHAR2,
   pextra3        IN       VARCHAR2,
   p_accounts     OUT      cur_type_new1.cursor_type
)
IS
   v_frdt   DATE;
   v_todt   DATE;
BEGIN
   v_frdt := TO_DATE (pdatefrom, '''' || pdateformate || '''');
   v_todt := TO_DATE (pdateto, '''' || pdateformate || '''');

   OPEN p_accounts FOR
      SELECT DISTINCT a."cio_booking_id" AS ID,
                      b."Agency_Name" AS agencyname, b."EmailID" AS mail,
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Comp_Code" = a."Comp_code"
                               AND "Cust_Code" = a."Client_code"),
                           a."Client_code"
                          ) AS clientname,
                      (SELECT "EmailID"
                         FROM cust_mast
                        WHERE "Comp_Code" = a."Comp_code"
                          AND "Cust_Code" = a."Client_code") AS client,
                      d."Package_Name" AS packagename,
                      f."Page_No" AS page_no,
                      a."No_of_insertion" AS insertion, a."RO_No" AS rono,
                      TO_CHAR (a."RO_Date",
                               '''' || pdateformate || ''''
                              ) AS rodate,
                      CASE
                         WHEN INSTR (a."Package_code",
                                     '',
                                     ''
                                    ) > 0
                            THEN fetch_pack_new (pcompcode, a."Package_code")
                         ELSE (SELECT DISTINCT MIN ("Combin_Desc")
                                          FROM combin_mast
                                         WHERE "Combin_Code" =
                                                              a."Package_code")
                      END AS "EDITIONNAME",
                      g."Comp_Name" AS comp_name,
                      (SELECT "EMAILID"
                         FROM exec_mast
                        WHERE "comp_code" = a."Comp_code"
                          AND TO_CHAR ("Exe_no") = a."Executive_code")
                                                           AS "EXEC_EMAILID"
                 FROM tbl_booking_mast a,
                      agency_mast b,
                      combin_mast d,
                      edition_mast e,
                      tbl_booking_insert f,
                      comp_mst g
                WHERE a."Comp_code" = g."Comp_Code"
                  AND a."Comp_code" = pcompcode
                  AND f."Cio_Booking_Id" = a."cio_booking_id"
                  AND (a."date_time" BETWEEN v_frdt AND v_todt)
                  AND (f."Insert_Date" IS NULL OR "Insert_Date" = '')
                  AND "Insert_Status" != 'cancel'
                  AND a."Agency_sub_code" = b."code_subcode"
                  AND a."Package_code" = d."Combin_Code"
                  AND f."Edition_Code" = e."Edition_Code"
                  AND a."Agency_sub_code" = NVL (pagency, a."Agency_sub_code")
                  AND a."cio_booking_id" = NVL (pextra1, a."cio_booking_id")
                  AND a."Client_code" = NVL (pclient, a."Client_code");
END followup;
/

@@@@@@@@@@@@@@@@@@@sumit@@@@@@@@follow up $ mis@@@@@@@@14\03\2012@@@@@@@@@@@


/********************ajay******0006650*****14/03/2012***********************/
/******specification**********/
CREATE OR REPLACE PACKAGE HT18JULY.autoagtypecode
 is
Type T_Accounts_Cursor is Ref Cursor;
procedure    autoagtypecode_p(str in varchar2,cod in varchar2,
p_Accounts out T_Accounts_Cursor,
p_Accounts1 out T_Accounts_Cursor);

procedure    autoagtypecode_p11(str in varchar2,cod in varchar2,adcattype in varchar2,
p_Accounts out T_Accounts_Cursor,
p_Accounts1 out T_Accounts_Cursor);

end    autoagtypecode;
/


/****************body*****************/
CREATE OR REPLACE package  body                   HT18JULY.autoagtypecode
 is

procedure    autoagtypecode_p(str in varchar2,cod in varchar2,
p_Accounts out T_Accounts_Cursor,
p_Accounts1 out T_Accounts_Cursor) as
begin

open p_Accounts for
select * from Agency_type_mst where upper("Agency_Type_Name")=upper(str);

open p_Accounts1 for
select MAX(TO_NUMBER(NVL(translate("Agency_Type_Code",'ABCDEFGHIJKLMNOPQRSTUVWXYZ~@#$%^&*()!><?/_+|=-',0),0))) AS "Agency_Type_Code" from Agency_type_mst where  upper("Agency_Type_Code") like upper(cod)||'%';

end    autoagtypecode_p;

procedure    autoagtypecode_p11(str in varchar2,cod in varchar2,adcattype in varchar2,
p_Accounts out T_Accounts_Cursor,
p_Accounts1 out T_Accounts_Cursor) as
begin

open p_Accounts for
select * from AD_CHARGE_MAST where "CHARGE_NAME"=str and "AD_TYPE"=adcattype;

open p_Accounts1 for
select nvl(max(to_number(substr("CHARGE_CODE",3,length("CHARGE_CODE")))),0)+1 AS "CHARGE_CODE" from AD_CHARGE_MAST where  "CHARGE_CODE" like cod||'%';

--nvl(max(to_number(substr("CHARGE_CODE",3,length("CHARGE_CODE")))),0)+1

end    autoagtypecode_p11;





end    autoagtypecode;
/




/****************end*********************************/

@@@@@@@@@@@@@@@@@@kuldeep 17\3\12@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//=========================================Begin Procedure==================================//
CREATE OR REPLACE PACKAGE executebooking IS
TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE executebooking_p(
compcode in varchar2,
ciobookid in varchar2,
docno in varchar2:=null,
keyno in varchar2:=null,
rono in varchar2:=null,
agencycode in varchar2:=null,
client in varchar2:=null,
booking in varchar2,
 dateformat     IN          VARCHAR2,
      revenue in varchar2,
P_Accounts  OUT  T_Accounts_Cursor,P_Accounts1  OUT  T_Accounts_Cursor,P_Accounts2  OUT  T_Accounts_Cursor
,P_Accounts3  OUT  T_Accounts_Cursor
);
end executebooking ;
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
        /* INSERT INTO TEMPBOOKING_MAST
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
                  "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", 
                  "Bill_area", "Special_disc_per", "Space_disc_per", 
                  "Paid_ins", "Contract_rate", "Deviation", "Variant_code", 
                  "Contract_name", "Contract_type", "Card_name", "Card_type", 
                  "Card_month", "Card_year", "Card_number", "Receipt_no", 
                  "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", 
                  "Bullet_code", "Bullet_premium", "Material_status", 
                  "Receipt_date", "prev_cioid", "prev_receipt", 
                  "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H", 
                  "Logo_W", "Logo_color", "Logo_Uom", SAPID, RETAINER, ADD_AGENCY_COMM, MOBILENO, ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, 
                  CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTERTYPE, CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, CHKTRADE, 
                  CHK_DATE, CHK_AMT, CHK_BANK_NAME, OUR_BANK, CHK_NO, DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE, ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT, 
                  LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE, REVISE_DATE, CLIENT_TYPE, TRANSLATION_CODE, TRANSLATION_PREMIUM, APP_USER
                  )*/
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
                LOCALGROSSAMT, LOCALBILLAMT,PACKAGE_TYPE,AD_REFID,RECEIPT_CURRENCY, CONV_CURR_RATE,REVISE_DATE, CLIENT_TYPE,TRANSLATION_CODE,TRANSLATION_PREMIUM,APP_USER
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


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
        m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",m."Receipt_no" as "Receipt_no",
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
            m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",m."Receipt_no" as "Receipt_no",
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
            m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",m."Receipt_no" as "Receipt_no",
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
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
        /*        ("date_time", "branch", "booked_by", "cio_booking_id", 
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
                  "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", 
                  "Bill_area", "Special_disc_per", "Space_disc_per", 
                  "Paid_ins", "Contract_rate", "Deviation", "Variant_code", 
                  "Contract_name", "Contract_type", "Card_name", "Card_type", 
                  "Card_month", "Card_year", "Card_number", "Receipt_no", 
                  "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", 
                  "Bullet_code", "Bullet_premium", "Material_status", 
                  "Receipt_date", "prev_cioid", "prev_receipt", 
                  "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H", 
                  "Logo_W", "Logo_color", "Logo_Uom", SAPID, RETAINER, ADD_AGENCY_COMM, MOBILENO, ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, 
                  CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTERTYPE, CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, CHKTRADE, 
                  CHK_DATE, CHK_AMT, CHK_BANK_NAME, OUR_BANK, CHK_NO, DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE, ACTIVE_AGREEDRATE, ACTIVE_AGREEDAMT, 
                  LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE, REVISE_DATE, CLIENT_TYPE, TRANSLATION_CODE, TRANSLATION_PREMIUM, APP_USER
                )*/
       ( SELECT "date_time", "branch", "booked_by", "cio_booking_id",
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
                LOCALGROSSAMT,LOCALBILLAMT,PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,APP_USER
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
            );

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
                 and "Comp_Code"=upper(compcode) and SYSDATE between "Eff_from_Date" and "Eff_Till_Date" AND ROWNUM<=1 ) as COMM_RATE,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT, NVL(LOCALGROSSAMT,"Gross_amount") as LOCALGROSSAMT, NVL(LOCALBILLAMT,"Bill_amount") as LOCALBILLAMT, RECEIPT_CURRENCY, CONV_CURR_RATE,
                 CASE dateformat
                         WHEN 'mm/dd/yyyy' THEN TO_CHAR("REVISE_DATE",'mm/dd/yyyy')
                         WHEN 'dd/mm/yyyy' THEN TO_CHAR("REVISE_DATE",'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd' THEN TO_CHAR("REVISE_DATE",'yyyy/mm/dd')  END AS "REVISE_DATE",CLIENT_TYPE,
                         
                         CASE dateformat
                         WHEN 'mm/dd/yyyy' THEN TO_CHAR("Creation_datetime",'mm/dd/yyyy hh:mi:ss')
                         WHEN 'dd/mm/yyyy' THEN TO_CHAR("Creation_datetime",'dd/mm/yyyy hh:mi:ss')
                         WHEN 'yyyy/mm/dd' THEN TO_CHAR("Creation_datetime",'yyyy/mm/dd hh:mi:ss') END                        
                          as CREATION_DATETIME,TRANSLATION_CODE, TRANSLATION_PREMIUM,
                          (SELECT CHARGES_TYPE FROM  AD_CHARGE_MAST WHERE AD_CHARGE_MAST.CHARGE_CODE=TEMPBOOKING_MAST.TRANSLATION_CODE and COMP_CODE=compcode) AS TRANSLATION_TYPE,
                          (SELECT "username" FROM  LOGIN WHERE LOGIN."userid"=TEMPBOOKING_MAST.APP_USER and LOGIN.COM_CODE=compcode) as APP_USER
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


//===========================================End of Script==================================//

@@@@@@@@@@@@@@@@@@kuldeep 17\3\12@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

/******************6658***********19march2012***********************/
CREATE OR REPLACE PACKAGE BODY bindagencyforbooking is
procedure bindagencyforbooking_p(
    compcode    in varchar2,
    userid      in varchar2,
    agency      in varchar2,
    pubcenter   in varchar2,
    p_Accounts  out T_Accounts_Cursor) as
v_filter    varchar2(20);
v_pcenter   varchar2(50);
Begin

    select distinct filter into v_filter from login where "userid"=userid;
    
    If v_filter='D' then--for district wise
        v_pcenter:=pubcenter;
    Elsif v_filter='P' then--for Printing center wise
        v_pcenter:=pubcenter;
    Else--for all
        v_pcenter:='0';
    End if;

    if v_pcenter = '0' or v_pcenter is null then
        open p_Accounts for
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name") like '%'||UPPER(agency)||'%'   order by "Agency_Name" ;
    else
        open p_Accounts for
        select  distinct  x."code_subcode" as "code_subcode",x."agency_name" as "agency_name",x.CITYNAME AS CITYNAME from
        (select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name") like '%'||UPPER(agency)||'%' and exists (select 'x' from branch_mst where "Branch_Code"=pubcenter and "Dist_Code"=agency_mast."Dist_Code") and v_filter='D' 
        union
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name") like '%'||UPPER(agency)||'%' and exists (select 'x' from branch_mst 
        where "Branch_Code"=agency_mast."Branch_code" and "pub_center"=v_pcenter) and v_filter='P') x
        order by "agency_name" ;
    end if;
end bindagencyforbooking_p;

end bindagencyforbooking;
/
/*****************************************************************/
                                                                     
                                                                     
                                                                     
                                             
CREATE OR REPLACE PROCEDURE bindagencyfromadd
(compcode           in varchar2,
userid              in varchar2,
agency              in varchar2,
pubcenter           in varchar2,
p_agencyaddress     in varchar2,
p_Accounts          OUT Cur_Type_New1.cursor_type)
 is
v_filter    varchar2(20);
v_pcenter   varchar2(50);
Begin

    select distinct filter into v_filter from login where "userid"=userid;
    
    If v_filter='D' then--for district wise
        v_pcenter:=pubcenter;
    Elsif v_filter='P' then--for Printing center wise
        v_pcenter:=pubcenter;
    Else--for all
        v_pcenter:='0';
    End if;
    
    If v_pcenter = '0' or v_pcenter is null then
        open p_Accounts for
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||'-'||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name"||"Add1"||"Add2"||"Add3") like '%'||upper(p_agencyaddress)||'%'  order by "Agency_Name" ;

    Else
        open p_Accounts for
        select  distinct  x."code_subcode" as "code_subcode",x."agency_name" as "agency_name",x.CITYNAME AS CITYNAME from
        (select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||'-'||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name"||"Add1"||"Add2"||"Add3") like '%'||upper(p_agencyaddress)||'%' and exists (select 'x' from branch_mst 
        where "Branch_Code"=v_pcenter and "Dist_Code"=agency_mast."Dist_Code") and v_filter='D' 
        union
        select  distinct  "code_subcode","Agency_Name" as "agency_name",(select "City_Name" from  city_mst where "Comp_Code"=compcode and "City_Code"=agency_mast."City_Code")||'-'||"Add1"||'-'||"Add2"||'-'||"Add3"||'-'||"Street"
        AS CITYNAME from Agency_mast where "Comp_Code"=compcode and
        nvl((SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1  AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode"  AND sysdate between "FROM_DATE" and "TO_DATE"),'AC0')='AC0'
        and upper("Agency_Name"||"Add1"||"Add2"||"Add3") like '%'||upper(p_agencyaddress)||'%' and exists (select 'x' from branch_mst 
        where "Branch_Code"=agency_mast."Branch_code" and "pub_center"=v_pcenter) and v_filter='P') x
        order by "agency_name";
    end if;
END bindagencyfromadd;
/


/******************6658***********19march2012***********************/


-----start--------------6719-----------20march2012-----------------------

CREATE OR REPLACE PACKAGE rpt_issue_pcentre_wise IS
	TYPE t_accounts_cursor IS REF CURSOR;
  PROCEDURE rpt_issue_pcentre_wise_p(
  	pcompcode       IN VARCHAR2,
    ppubcent       	IN VARCHAR2,
    pedtncode       IN VARCHAR2,
    pfrom_date      IN VARCHAR2,
    ptill_date      IN VARCHAR2,
    pdateformat     IN VARCHAR2,
    puserid			IN VARCHAR2,
    chk_access in varchar2:=null,
     pratio_type in varchar2:=null,
      pextra1 in varchar2:=null,
      pextra2 in varchar2:=null,
    p_accounts      OUT t_accounts_cursor,
    p_accounts1     OUT t_accounts_cursor
        );
END rpt_issue_pcentre_wise;
/


CREATE OR REPLACE PACKAGE BODY rpt_issue_pcentre_wise IS
/*
var v1 refcursor;
var v2 refcursor;
exec rpt_issue_pcentre_wise.rpt_issue_pcentre_wise_p('SP001','','','01-APR-2010','31-Mar-2011','dd/mm/yyyy','ADM','0','','A','O',:v1,:v2);
*/
PROCEDURE rpt_issue_pcentre_wise_p(
    pcompcode       IN VARCHAR2,
    ppubcent        IN VARCHAR2,
    pedtncode       IN VARCHAR2,
    pfrom_date      IN VARCHAR2,
    ptill_date      IN VARCHAR2,
    pdateformat     IN VARCHAR2,
    puserid         IN VARCHAR2,
    chk_access      IN varchar2:=null,
    pratio_type     IN varchar2:=null,--Edition ratio or Circualtion copy wise ratio
    pextra1         IN varchar2:=null,--Branch Based on Agency or Transaction
    pextra2         IN varchar2:=null,--With Size or Without Size
    p_accounts      OUT t_accounts_cursor,
    p_accounts1     OUT t_accounts_cursor)
IS
v_frdt      date;
v_todt      date;
v_query     VARCHAR2(8000);
qry         VARCHAR2(8000);

        cursor c11 is
            select a.publ_code,B."Edition_Alias" as edition, new_edition_code Edition_Code, get_edtn(B."Edition_Alias",'-') main_edition_code, 
            PUB_CENT_NAME,sum(amount) amount,sum(dpub_size) dpub_size,sum(lpub_size) lpub_size  from ( 
            select distinct d."Comp_Code" , d."Publication_Code" publ_code, d."Edition_Code" as Edition_Code,
            b."pub_center" as PUB_CENT_NAME,
            round((sum("Bill_Amt"* nvl(e.percentage,100)/100)),2) as amount,
            nvl(e.SUB_EDITION_CODE,d."Edition_Code") as new_edition_code,
            sum("Size_Book") as dpub_size,0 as lpub_size
            from edition_mast m,tbl_booking_insert d, editionwiseratio_temp e,branch_mst b,tbl_booking_mast t,agency_mast a
            where m."Edition_Code" = e."MAIN_EDITION_CODE"(+) and
            d."Comp_Code"=m."Comp_Code" and d."Comp_Code"=t."Comp_code" and d."Cio_Booking_Id"=t."cio_booking_id" and d."Edition_Code"=m."Edition_Code" and  
            (b."pub_center"=ppubcent or ppubcent is null) and t."Agency_sub_code"=a."code_subcode" and 
            t."branch"=b."Branch_Code" and
            d."Insert_Date" between  v_frdt and v_todt and d."Insert_Status" not in('cancel','hold','booked') 
            and "Edition_Type"='Main Edition' and (d."Height" is not null and d."Width" is not null)
            group by d."Comp_Code", d."Publication_Code",d."Edition_Code",b."pub_center",nvl(e.SUB_EDITION_CODE,d."Edition_Code")
            union all
            select d."Comp_Code" , d."Publication_Code" publ_code, d."Edition_Code" as Edition_Code,
            b."pub_center" as PUB_CENT_NAME, 
            round((sum("Bill_Amt"* nvl(e.percentage,100)/100)),2) as amount,
            nvl(e.SUB_EDITION_CODE,d."Edition_Code") as new_edition_code,
            0 as dpub_size,sum("Size_Book") as lpub_size
            from edition_mast m,tbl_booking_insert d, editionwiseratio_temp e,branch_mst b,tbl_booking_mast t,agency_mast a
            where m."Edition_Code" = e."MAIN_EDITION_CODE"(+) and
            d."Comp_Code"=m."Comp_Code" and d."Comp_Code"=t."Comp_code" and d."Cio_Booking_Id"=t."cio_booking_id" and d."Edition_Code"=m."Edition_Code" and  
            (b."pub_center"=ppubcent or ppubcent is null) and t."Agency_sub_code"=a."code_subcode" and 
            t."branch"=b."Branch_Code" and 
            d."Insert_Date" between  v_frdt and v_todt and d."Insert_Status" not in('cancel','hold','booked') 
            and "Edition_Type"='Main Edition' and (d."Height" is null and d."Width" is null)
            group by d."Comp_Code", d."Publication_Code",d."Edition_Code",b."pub_center",nvl(e.SUB_EDITION_CODE,d."Edition_Code")
            union all            
            select d."Comp_Code" , d."Publication_Code" publ_code,d."Edition_Code" as Edition_Code,
            b."pub_center" as PUB_CENT_NAME, 
            round(sum(d."Bill_Amt"),2) as amount,
            d."Edition_Code" as new_edition_code,
            round(sum("Size_Book"),2) as dpub_size,0 as lpub_size
            from edition_mast m,tbl_booking_insert d,branch_mst b,tbl_booking_mast t,agency_mast a
            where d."Comp_Code"=m."Comp_Code" and d."Comp_Code"=t."Comp_code" and d."Cio_Booking_Id"=t."cio_booking_id" and d."Edition_Code"=m."Edition_Code" and  
            (b."pub_center"=ppubcent or ppubcent is null) and t."Agency_sub_code"=a."code_subcode" and 
            t."branch"=b."Branch_Code" and 
            d."Insert_Date" between  v_frdt and v_todt and d."Insert_Status" not in('cancel','hold','booked') 
            and "Edition_Type"<>'Main Edition' and (d."Height" is not null and d."Width" is not null)
            group by d."Comp_Code", d."Publication_Code",d."Edition_Code",b."pub_center",d."Edition_Code"
            union all
            select d."Comp_Code" , d."Publication_Code" publ_code,d."Edition_Code" as Edition_Code,
            b."pub_center" as PUB_CENT_NAME,  
            round(sum(d."Bill_Amt"),2) as amount,
            d."Edition_Code" as new_edition_code,
            0 as dpub_size,sum("Size_Book") as lpub_size
            from edition_mast m,tbl_booking_insert d,branch_mst b,tbl_booking_mast t,agency_mast a
            where d."Comp_Code"=m."Comp_Code" and d."Comp_Code"=t."Comp_code" and d."Cio_Booking_Id"=t."cio_booking_id" and d."Edition_Code"=m."Edition_Code" and  
            (b."pub_center"=ppubcent or ppubcent is null) and t."Agency_sub_code"=a."code_subcode" and 
            t."branch"=b."Branch_Code" and 
            d."Insert_Date" between  v_frdt and v_todt and d."Insert_Status" not in('cancel','hold','booked') 
            and "Edition_Type"<>'Main Edition' and (d."Height" is null and d."Width" is null) 
            group by d."Comp_Code", d."Publication_Code",d."Edition_Code",b."pub_center",d."Edition_Code"
            ) A,  edition_mast B
            where new_edition_code=b."Edition_Code"
            group by  a.publ_code,B."Edition_Alias" , new_edition_code,  PUB_CENT_NAME
            order by B."Edition_Alias" ; 
  v11 c11%rowtype;

        cursor c12 is
            select a.publ_code,B."Edition_Alias" as edition, new_edition_code Edition_Code, get_edtn(B."Edition_Alias",'-') main_edition_code, 
            PUB_CENT_NAME,sum(amount) amount,sum(dpub_size) dpub_size,sum(lpub_size) lpub_size  from ( 
            select distinct d."Comp_Code" , d."Publication_Code" publ_code, d."Edition_Code" as Edition_Code,
            b."pub_center" as PUB_CENT_NAME,
            round((sum("Bill_Amt"* nvl(e.percentage,100)/100)),2) as amount,
            nvl(e.SUB_EDITION_CODE,d."Edition_Code") as new_edition_code,
            sum("Size_Book") as dpub_size,0 as lpub_size
            from edition_mast m,tbl_booking_insert d, editionwiseratio_temp e,branch_mst b,tbl_booking_mast t,agency_mast a
            where m."Edition_Code" = e."MAIN_EDITION_CODE"(+) and
            d."Comp_Code"=m."Comp_Code" and d."Comp_Code"=t."Comp_code" and d."Cio_Booking_Id"=t."cio_booking_id" and d."Edition_Code"=m."Edition_Code" and 
            (b."pub_center"=ppubcent or ppubcent is null) and t."Agency_sub_code"=a."code_subcode" and 
            a."Branch_code"=b."Branch_Code" and pextra1='A' and 
            d."Insert_Date" between  v_frdt and v_todt and d."Insert_Status" not in('cancel','hold','booked') 
            and "Edition_Type"='Main Edition' and (d."Height" is not null and d."Width" is not null)
            group by d."Comp_Code", d."Publication_Code",d."Edition_Code",b."pub_center",nvl(e.SUB_EDITION_CODE,d."Edition_Code")
            union all
            select d."Comp_Code" , d."Publication_Code" publ_code, d."Edition_Code" as Edition_Code,
            b."pub_center" as PUB_CENT_NAME, 
            round((sum("Bill_Amt"* nvl(e.percentage,100)/100)),2) as amount,
            nvl(e.SUB_EDITION_CODE,d."Edition_Code") as new_edition_code,
            0 as dpub_size,sum("Size_Book") as lpub_size
            from edition_mast m,tbl_booking_insert d, editionwiseratio_temp e,branch_mst b,tbl_booking_mast t,agency_mast a
            where m."Edition_Code" = e."MAIN_EDITION_CODE"(+) and
            d."Comp_Code"=m."Comp_Code" and d."Comp_Code"=t."Comp_code" and d."Cio_Booking_Id"=t."cio_booking_id" and d."Edition_Code"=m."Edition_Code" and
            (b."pub_center"=ppubcent or ppubcent is null) and t."Agency_sub_code"=a."code_subcode" and 
            a."Branch_code"=b."Branch_Code" and pextra1='A' and 
            d."Insert_Date" between  v_frdt and v_todt and d."Insert_Status" not in('cancel','hold','booked') 
            and "Edition_Type"='Main Edition' and (d."Height" is null and d."Width" is null)
            group by d."Comp_Code", d."Publication_Code",d."Edition_Code",b."pub_center",nvl(e.SUB_EDITION_CODE,d."Edition_Code")
            union all            
            select d."Comp_Code" , d."Publication_Code" publ_code,d."Edition_Code" as Edition_Code,
            b."pub_center" as PUB_CENT_NAME, 
            round(sum(d."Bill_Amt"),2) as amount,
            d."Edition_Code" as new_edition_code,
            round(sum("Size_Book"),2) as dpub_size,0 as lpub_size
            from edition_mast m,tbl_booking_insert d,branch_mst b,tbl_booking_mast t,agency_mast a
            where d."Comp_Code"=m."Comp_Code" and d."Comp_Code"=t."Comp_code" and d."Cio_Booking_Id"=t."cio_booking_id" and d."Edition_Code"=m."Edition_Code" and  
            (b."pub_center"=ppubcent or ppubcent is null) and t."Agency_sub_code"=a."code_subcode" and
            a."Branch_code"=b."Branch_Code" and pextra1='A' and 
            d."Insert_Date" between  v_frdt and v_todt and d."Insert_Status" not in('cancel','hold','booked') 
            and "Edition_Type"<>'Main Edition' and (d."Height" is not null and d."Width" is not null)
            group by d."Comp_Code", d."Publication_Code",d."Edition_Code",b."pub_center",d."Edition_Code"
            union all
            select d."Comp_Code" , d."Publication_Code" publ_code,d."Edition_Code" as Edition_Code,
            b."pub_center" as PUB_CENT_NAME,  
            round(sum(d."Bill_Amt"),2) as amount,
            d."Edition_Code" as new_edition_code,
            0 as dpub_size,sum("Size_Book") as lpub_size
            from edition_mast m,tbl_booking_insert d,branch_mst b,tbl_booking_mast t,agency_mast a
            where d."Comp_Code"=m."Comp_Code" and d."Comp_Code"=t."Comp_code" and d."Cio_Booking_Id"=t."cio_booking_id" and d."Edition_Code"=m."Edition_Code" and  
            (b."pub_center"=ppubcent or ppubcent is null) and t."Agency_sub_code"=a."code_subcode" and
            a."Branch_code"=b."Branch_Code" and 
            d."Insert_Date" between  v_frdt and v_todt and d."Insert_Status" not in('cancel','hold','booked') 
            and "Edition_Type"<>'Main Edition' and (d."Height" is null and d."Width" is null) 
            group by d."Comp_Code", d."Publication_Code",d."Edition_Code",b."pub_center",d."Edition_Code"
            ) A,  edition_mast B
            where new_edition_code=b."Edition_Code"
            group by  a.publ_code,B."Edition_Alias" , new_edition_code,  PUB_CENT_NAME
            order by B."Edition_Alias" ;
        v12 c12%rowtype;
            
            cursor c1 is
            select distinct pub_center_name pubcent_name,nvl((select "Pub_Cent_name" from pub_cent_mast 
            where "Pub_cent_Code"=d.pub_center_name),pub_center_name) pub_name from temp_rpt_issue_pcenter d  
            where sess_id=userenv('sessionid') order by d.pub_center_name;
        v1 c1%rowtype;

        v_var       varchar2(12000);
        v_var1      varchar2(12000);
        v_var2      varchar2(12000);
        v_var_sum   varchar2(12000);
        v_var_sum1  varchar2(12000);
        v_var_sum2  varchar2(12000);
BEGIN
 
        delete from temp_rpt_issue_pcenter where sess_id=userenv('sessionid') ;
        delete from editionwiseratio_temp;
        --Insert into searchtbl values('pcompcode:'||pcompcode||'ppubcent:' || ppubcent||'pedtncode:'||pedtncode||'pfrom_date:'||pfrom_date||
        --'ptill_date:'||ptill_date || 'pdateformat:'||pdateformat ||'puserid:'|| puserid);

        v_frdt    :=to_date(pfrom_date,''''||pdateformat||'''');
        v_todt    :=to_date(ptill_date,''''||pdateformat||'''');
        
       if pratio_type='C' then--based on circulation copy
           insert into editionwiseratio_temp(comp_code ,pub_code,main_edition_code,sub_edition_code ,
                    edition_name ,edition_alias ,percentage,effective_date) 
            select a.comp_code comp_code,a.pub_code pub_code,a.main_edtn_code main_edtn_code,b."Edition_Code" edtn_code,
            b."Edition_Name" edtn_name,b."Edition_Alias" edtn_alias,case when nvl(to_number(a.main_no_of_cir),0)>0 then round(((to_number(b."No_Of_Circulation")*100)/a.main_no_of_cir),2)
            else round(((to_number(b."No_Of_Circulation")*100)/b."No_Of_Circulation"),2) end edtn_ratio,to_date(sysdate) eff_date  from
            (select "Comp_Code" comp_code,"Pub_Code" pub_code,"City_Code" city_code,"Edition_Code" main_edtn_code,"Edition_Name" main_edtn_name,"Edition_Alias" main_edtn_alias,
            nvl(decode ("No_Of_Circulation",null,'0'),'0') main_no_of_cir from edition_mast 
            where "Edition_Type"='Main Edition') a,edition_mast b 
            where b."Comp_Code"=a.comp_code and b."Pub_Code"=a.pub_code and b."City_Code"=a.city_code and b."Edition_Type"='Edition'
            order by pub_code,edtn_alias,city_code; 
        else--based on sub edition wise ratio 
            insert into editionwiseratio_temp(comp_code ,pub_code,main_edition_code,sub_edition_code ,
                    edition_name ,edition_alias ,percentage,effective_date)
            select comp_code,pub_code,main_edition_code,sub_edition_code,edition_name edition_name,edition_name edition_alias,percentage,effective_date 
            from editionwiseratio_mast
            order by pub_code,main_edition_code,edition_alias;
        end if;
       
        if pextra1='A' then--branch based on agency master
            open c12;
            loop
                fetch c12 into v12;
                exit when c12%notfound;
                insert into temp_rpt_issue_pcenter(publ_code,edtn_code,edtn_name,pub_center_name,amt,sess_id,main_edtn_code,main_edtn_name,publ_area,publ_line)
                    values(v12.publ_code,v12.Edition_Code,v12.edition,v12.PUB_CENT_NAME,v12.amount,userenv('sessionid'),v12.main_edition_code,v12.main_edition_code,v12.dpub_size,v12.lpub_size);
            end loop;
            close c12;
        else--branch based on transsaction
            open c11;
            loop
                fetch c11 into v11;
                exit when c11%notfound;
                insert into temp_rpt_issue_pcenter(publ_code,edtn_code,edtn_name,pub_center_name,amt,sess_id,main_edtn_code,main_edtn_name,publ_area,publ_line)
                    values(v11.publ_code,v11.Edition_Code,v11.edition,v11.PUB_CENT_NAME,v11.amount,userenv('sessionid'),v11.main_edition_code,v11.main_edition_code,v11.dpub_size,v11.lpub_size);
            end loop;
            close c11;        
        end if;
        open c1;
        loop
            fetch c1 into v1;
            exit when c1%notfound;
            if pextra2 ='W' then--with Size
                if v_var is null then
                    v_var       :='case when d.pub_center_name='||''''||v1.pubcent_name||''''||' then d.publ_area else 0 end "'||'D#'||v1.pubcent_name||'"';
                    v_var       :=v_var||','||'case when d.pub_center_name='||''''||v1.pubcent_name||''''||' then d.publ_line else 0 end "'||'L#'||v1.pubcent_name||'"';
                    v_var       :=v_var||','||'case when d.pub_center_name='||''''||v1.pubcent_name||''''||' then (d.amt) else 0 end "'||'A#'||v1.pubcent_name||'"';
                    v_var_sum   :='round(sum("'||'D#'||v1.pubcent_name||'"),2)'||' "'||'D#'||v1.pub_name||'"';
                    v_var_sum   :=v_var_sum||','||'round(sum("'||'L#'||v1.pubcent_name||'"),2)'||' "'||'L#'||v1.pub_name||'"';
                    v_var_sum   :=v_var_sum||','||'round(sum("'||'A#'||v1.pubcent_name||'"),2)'||' "'||'A#'||v1.pub_name||'"';
                else
                    v_var       :=v_var||','||'case when d.pub_center_name='||''''||v1.pubcent_name||''''||' then d.publ_area else 0 end "'||'D#'||v1.pubcent_name||'"';
                    v_var       :=v_var||','||'case when d.pub_center_name='||''''||v1.pubcent_name||''''||' then d.publ_line else 0 end "'||'L#'||v1.pubcent_name||'"';
                    v_var       :=v_var||','||'case when d.pub_center_name='||''''||v1.pubcent_name||''''||' then (d.Amt) else 0 end"'||'A#'||v1.pubcent_name||'"';
                    v_var_sum   :=v_var_sum||','||'round(sum("'||'D#'||v1.pubcent_name||'"),2)'||' "'||'D#'||v1.pub_name||'"';
                    v_var_sum   :=v_var_sum||','||'round(sum("'||'L#'||v1.pubcent_name||'"),2)'||' "'||'L#'||v1.pub_name||'"';
                    v_var_sum   :=v_var_sum||','||'round(sum("'||'A#'||v1.pubcent_name||'"),2)'||' "'||'A#'||v1.pub_name||'"';
                end if;
            else--without Size
                if v_var is null then
                    v_var       :='case when d.pub_center_name='||''''||v1.pubcent_name||''''||' then (d.amt) else 0 end "'||'A#'||v1.pubcent_name||'"';
                    v_var_sum   :='round(sum("'||'A#'||v1.pubcent_name||'"),2)'||' "'||'A#'||v1.pub_name||'"';
                else
                    v_var       :=v_var||','||'case when d.pub_center_name='||''''||v1.pubcent_name||''''||' then (d.Amt) else 0 end"'||'A#'||v1.pubcent_name||'"';
                    v_var_sum   :=v_var_sum||','||'round(sum("'||'A#'||v1.pubcent_name||'"),2)'||' "'||'A#'||v1.pub_name||'"';
                end if;                
            end if;    
        end loop;
        close c1;

        --delete test1;insert into test1(vstring,vstring2) values(' issue pcentre v_var',v_var);commit;
        --insert into test1(vstring,vstring2) values(' issue pcentre v_var_sum',v_var_sum);commit;
        if v_var is not null then
           if pextra2 ='W' then--with Size
               v_query:='select
                main_edtn_name,edtn_code,edtn_name,edtn_pcenter_name('||''''||pcompcode||''''||',edtn_code) as pcenter,'||v_var_sum||' ,  round(sum("PUB_SIZE"),2) as "DISPLAY",round(sum("PUB_LINE"),2) as "LINEAGE",round(sum("AMT"),2) as "TOT",
                (select "Edition_Type" from Edition_mast where "Edition_Code"=edtn_code  )as "Type",
                 (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code" =publ_code) as "Publication"
                from (select distinct d.publ_code,d.main_edtn_name as main_edtn_name,d.edtn_code as edtn_code,d.edtn_name as edtn_name,
               '||v_var||',nvl(d.Amt,0) as "AMT",nvl(d.publ_area,0) as "PUB_SIZE",nvl(d.publ_line,0) as "PUB_LINE" from temp_rpt_issue_pcenter d where sess_id='||userenv('sessionid')||') 
               group by publ_code,main_edtn_name,edtn_code,edtn_name order by edtn_name,pcenter';
           else
               v_query:='select
                main_edtn_name,edtn_code,edtn_name,edtn_pcenter_name('||''''||pcompcode||''''||',edtn_code) as pcenter,'||v_var_sum||' , round(sum("AMT"),2) as "TOT",
                (select "Edition_Type" from Edition_mast where "Edition_Code"=edtn_code  )as "Type",
                 (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code" =publ_code) as "Publication"
                from (select distinct d.publ_code,d.main_edtn_name as main_edtn_name,d.edtn_code as edtn_code,d.edtn_name as edtn_name,
               '||v_var||',nvl(d.Amt,0) as "AMT",nvl(d.publ_area,0) as "PUB_SIZE",nvl(d.publ_line,0) as "PUB_LINE" from temp_rpt_issue_pcenter d where sess_id='||userenv('sessionid')||') 
               group by publ_code,main_edtn_name,edtn_code,edtn_name order by edtn_name,pcenter';           
           end if; 
        else
              if pextra2 ='W' then--with Size
               v_query:='select
                main_edtn_name,edtn_code,edtn_name,edtn_pcenter_name('||''''||pcompcode||''''||',edtn_code) as pcenter,  round(sum("PUB_SIZE"),2) as "DISPLAY",round(sum("PUB_LINE"),2) as "LINEAGE",round(sum("AMT"),2) as "TOT",
                (select "Edition_Type" from Edition_mast where "Edition_Code"=edtn_code  )as "Type",
                 (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code" =publ_code) as "Publication"
                from (select distinct d.publ_code,d.main_edtn_name as main_edtn_name,d.edtn_code as edtn_code,d.edtn_name as edtn_name,
               nvl(d.Amt,0) as "AMT",nvl(d.publ_area,0) as "PUB_SIZE",nvl(d.publ_line,0) as "PUB_LINE" from temp_rpt_issue_pcenter d where sess_id='||userenv('sessionid')||') 
               group by publ_code,main_edtn_name,edtn_code,edtn_name order by edtn_name,pcenter';
           else
               v_query:='select
                main_edtn_name,edtn_code,edtn_name,edtn_pcenter_name('||''''||pcompcode||''''||',edtn_code) as pcenter , round(sum("AMT"),2) as "TOT",
                (select "Edition_Type" from Edition_mast where "Edition_Code"=edtn_code  )as "Type",
                 (select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code" =publ_code) as "Publication"
                from (select distinct d.publ_code,d.main_edtn_name as main_edtn_name,d.edtn_code as edtn_code,d.edtn_name as edtn_name,
               nvl(d.Amt,0) as "AMT",nvl(d.publ_area,0) as "PUB_SIZE",nvl(d.publ_line,0) as "PUB_LINE" from temp_rpt_issue_pcenter d where sess_id='||userenv('sessionid')||') 
               group by publ_code,main_edtn_name,edtn_code,edtn_name order by edtn_name,pcenter';           
           end if;
           
        end if;
        --v_query:='SELECT SYSDATE FROM DUAL';

        OPEN p_accounts FOR v_query;
       
        delete from test1;commit;
       insert into test1(VSTRING) values(v_query);commit; 
        
 
       
        
        
        if v_var is not null then
        qry:=qry||'   select (SELECT initcap("Comp_Name")   from comp_mst where "Comp_Code"='''||pcompcode||''')AS "companyname",
            edtn_pcenter_name('||''''||pcompcode||''''||',edtn_code) as pcenter,'||v_var_sum||'
            from (select distinct d.edtn_code as edtn_code,d.edtn_name as edtn_name,
           '||v_var||' from temp_rpt_issue_pcenter d where sess_id='||userenv('sessionid')||') group by edtn_pcenter_name('''||pcompcode||''',edtn_code) order by pcenter';
        else
            qry:=qry||'   select (SELECT initcap("Comp_Name")   from comp_mst where "Comp_Code"='''||pcompcode||''')AS "companyname",
            edtn_pcenter_name('||''''||pcompcode||''''||',edtn_code) as pcenter
            from (select distinct d.edtn_code as edtn_code,d.edtn_name as edtn_name
            from temp_rpt_issue_pcenter d where sess_id='||userenv('sessionid')||') group by edtn_pcenter_name('''||pcompcode||''',edtn_code) order by pcenter';
        end if;


        --delete from searchtbl;insert into searchtbl values(qry);commit;
        open p_accounts1 for qry;

    END rpt_issue_pcentre_wise_p;
END rpt_issue_pcentre_wise;
/


-----End--------------6719-----------20march2012-----------------------


@@@@@@@@@@@@@@@@@@@@@@@@ kuldeep billing 20/03/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//=========================================Begin Procedure==================================//
CREATE OR REPLACE PROCEDURE Websp_Selectvaluesnew_rp(
ciobooking          IN  VARCHAR2,
editionname         IN  VARCHAR2,
compcode            IN  VARCHAR2,
insertion           IN  VARCHAR2,
dateformat          IN VARCHAR2,
p_getbookingrecord  OUT Cur_Type_New1.cursor_type,
p_accounts1         OUT Cur_Type_New1.cursor_type,
P_ACCOUNTS2         OUT Cur_Type_New1.cursor_type)
IS
str             VARCHAR(10000);
package_cd      VARCHAR(300);
package_result  VARCHAR(300);
package_cd1     VARCHAR(300);
A               NUMBER;

BEGIN

str :='SELECT DISTINCT m."cio_booking_id" AS "CIOID",
m."Agency_sub_code",a."Agency_Name" AS "Agency",a."Add1" , c."City_Name",
nvl(substr(((SELECT DISTINCT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE  CUST_MAST."Cust_Code"=m."Client_code")),1,18),m."Client_code") AS "advertiser" ,
i."Height" AS "Depth",
i."Width" AS "Width",
cl."Col_Alias" AS "Hue",
i."No_Insert" AS "Ins.No.",
m."RO_No" AS "RoNo.",
m."Card_amount" AS "Amt",
i."Disc_Rate" AS "Disc",
(SELECT ADVPOS_TYPE_MAST."Pos_Type" FROM ADVPOS_TYPE_MAST WHERE ADVPOS_TYPE_MAST."Pos_Type_Code"=i."Page_Post" ) AS "pageposition",
m."Ad_type_code" as "Ad_type_code",(SELECT ADV_TYPE_MAST."Adv_Type_Name" FROM ADV_TYPE_MAST  WHERE ADV_TYPE_MAST."Adv_Type_Code"=m."Ad_type_code" ) AS "AdType",

i."Size_Book" AS "Volume",
case nvl(m."Agrred_rate",0) when 0 then m."Card_rate" else m."Agrred_rate"  end as "package rate",
m."Gross_amount",
(SELECT BOX_MAST."Box_Charges_Native" FROM BOX_MAST  WHERE  m."Box_code"=BOX_MAST."Box_Code") AS "boxchares" ,
sum(i."Gross_Rate") as "Gross_Rate",
m."Creation_datetime",
(SELECT DISTINCT  "Package_Name" FROM COMBIN_MAST WHERE m."Package_code"=COMBIN_MAST."Combin_Code"  AND "Combin_Desc"='''||editionname||''' )AS "package_name",

nvl((SELECT DISTINCT CUST_MAST."Add1"  || "Stree" FROM CUST_MAST WHERE  CUST_MAST."Cust_Code"=m."Client_code" ),m."Client_address") AS "clientAd",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
m."No_of_insertion",
CASE '''||dateformat||'''
    WHEN ''mm/dd/yyyy'' THEN TO_CHAR(min(i."Insert_Date"),''mm/dd/yyyy'')
    WHEN ''dd/mm/yyyy'' THEN TO_CHAR(min(i."Insert_Date"),''dd/mm/yyyy'')
    WHEN ''yyyy/mm/dd'' THEN TO_CHAR(min(i."Insert_Date"),''yyyy/mm/dd'')  
END AS "Ins.Date",
min(i."Page_No") as "Page_insrt",
(SELECT "premiumname" FROM ADVPOS_PREM_MAST  WHERE   ADVPOS_PREM_MAST. "Premiumcode"=i."Premium1")as "premiumname",
m."Special_discount",
m."Special_charges",
m."Trade_disc",
(SELECT "premium_charges" FROM ADVPOS_PREM_MAST  WHERE   ADVPOS_PREM_MAST. "Premiumcode"=i."Premium1") AS "premiumch",
i."Card_Rate",(select max("Size_To") from rate_mast where "Comp_code"='''||compcode||''' and "Rate_Mast_Code"=m."Rate_code" and "Adv_Type_Code"=m."Ad_type_code" and "Adv_Cat_Code"=m."Ad_cat_code" and 
"Uom"=m."Uom_code" and "Color"=i."Col_Code" and m."Insertion_date" between "Valid_From" and "Valid_To") as "MIN_WORD" ,
initcap(b."Add1") as "Add1" , b."Phone1", b."Phone2", b."Fax"  as "Fax1",

m."Key_no" AS "Key No",
m."Agency_type",
 lower(b."EmailID") as  "Email" ,
(select to_char((SELECT distinct AD_BILLS."BILDT" + nvl(m."Agency_credit",nvl(a."Credit_Days",0)) from ad_bills
where ad_bills.bildt=i.bill_date and ad_bills.bilno=i.bill_no and AD_BILLS."IDNUM" =  '''||ciobooking||''' and ad_bills.insnum= '''||insertion||'''  and 
AD_BILLS."AGCODE" = a."code_subcode"),''dd-Mon-yyyy'') from dual) AS "paydate",

(select to_char((SELECT SYSDATE + nvl(m."Agency_credit",nvl(a."Credit_Days",0))  FROM  dual),''dd-Mon-yyyy'') from dual) as "paydatesys",
a."Add2",
a."Add3"
,m."Caption" as "Cap",
sum(i."Bill_Amt") as "Bill_Amt",
m.ADD_AGENCY_COMM as "addcom",
min(i."Insert_Date") as  "insert_date",b."Street" as "street",m."Box_no",

CASE '''||dateformat||'''
    WHEN ''mm/dd/yyyy'' THEN TO_CHAR(i."BILL_DATE",''mm/dd/yyyy'')
    WHEN ''dd/mm/yyyy'' THEN TO_CHAR(i."BILL_DATE",''dd/mm/yyyy'')
    WHEN ''yyyy/mm/dd'' THEN TO_CHAR(i."BILL_DATE",''yyyy/mm/dd'')  END AS "BILL_DATE",

CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR(m."RO_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(m."RO_Date",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(m."RO_Date",''yyyy/mm/dd'')  END AS "RO_Date",
m."Bill_remarks",
(select "Scheme_Name"  from Scheme_Master where Scheme_Master."scheme_id"=m."Scheme_type_code" and Scheme_Master."Comp_code"=m."Comp_code" and rownum <=1) as "Scheme",

i."Insert_Status" as "status",
case when instr(m."Package_code",'','') >0 then 
    FETCH_PACK_NAME('''||compcode||''', i.PACKAGE_CODE ) 
else
    (select distinct min("Package_Name") from combin_mast where "Combin_Code"=i.PACKAGE_CODE)
end AS "Package"
/*New Field Add*/
,(select "Adv_Cat_Name" from adv_cat_mast where "Comp_Code"='''||compcode||''' and "Adv_Cat_Code"=m."Ad_cat_code") as "Adv_Cat_Name",
(select "Adv_Subcat_Name" from adv_subcat_mast where "Comp_Code"='''||compcode||''' and "Adv_Subcat_Code"=m."Ad_sub_cat_code") as "Adv_Subcat_Name"
FROM TBL_BOOKING_MAST m,PUB_CENT_MAST pc,
TBL_BOOKING_INSERT i,AGENCY_MAST  a,PUB_MAST p,
COL_MAST cl,CITY_MST c,branch_mst b

WHERE m ."Comp_code"='''||compcode||'''
AND m."cio_booking_id"=i."Cio_Booking_Id"
AND m."Agency_sub_code"=a."code_subcode"
AND i."Col_Code"=cl."Col_Code"
AND pc."Pub_cent_Code"  =i."Pub_Cent_Code"
AND c."City_Code"=a."City_Code"  AND i."Publication_Code" = p."Pub_Code" AND   i."Cio_Booking_Id"='''||ciobooking||''' AND   i."No_Insert"='''||insertion||'''
and b ."Branch_Code"=m ."branch" 
group by m."cio_booking_id" ,
m."Agency_sub_code",a."Agency_Name" ,a."Add1" , c."City_Name",
m."Client_code",m."Client_address",
i."Height" ,
i."Width" ,
cl."Col_Alias" ,
i."No_Insert" ,
m."RO_No",
m."Card_amount" ,
i."Disc_Rate" ,
i."Page_Post" ,
m."Ad_type_code",
i."Size_Book" ,
m."Agrred_rate", m."Card_rate",
m."Gross_amount",
m."Box_code",m."Creation_datetime",m."Package_code",
m."No_of_insertion",
i."Premium1",m."Special_discount",m."Special_charges",m."Trade_disc",
i."Premium1" ,i."Card_Rate",
initcap(b."Add1") , b."Phone1", b."Phone2", b."Fax",
m."Key_no" ,m."Agency_type",
lower(b."EmailID"),m."Agency_credit",a."Credit_Days", 
a."Add2",a."Add3",m."Caption",
m.ADD_AGENCY_COMM,b."Street",m."Box_no",i."BILL_DATE",
m."RO_Date",m."Bill_remarks",m."Scheme_type_code",m."Comp_code",i."Insert_Status",
i.bill_no,i.bill_date,i.PACKAGE_CODE,a."code_subcode",m."Rate_code",m."Ad_type_code",
m."Ad_cat_code",m."Uom_code",i."Col_Code" , m."Insertion_date"
,m."Ad_sub_cat_code"';

delete from PACKAGE1;

BEGIN
    SELECT  "Package_code" INTO  package_cd1 FROM TBL_BOOKING_MAST WHERE "cio_booking_id"=ciobooking;

EXCEPTION WHEN NO_DATA_FOUND THEN 
    NULL; 
END;


A:=Fn_Splitfield(package_cd1,',');

DECLARE
     CURSOR c1 IS SELECT Edition_Name FROM RESULT;
BEGIN

    OPEN c1;
    LOOP
        FETCH  c1    INTO package_result;
        EXIT WHEN C1%NOTFOUND;

        INSERT INTO PACKAGE1 SELECT "Combin_Desc" FROM COMBIN_MAST WHERE "Combin_Code"=package_result;

    END LOOP;
        --print(@package_result)
    CLOSE c1;
END ;

delete from searchtbl;insert into searchtbl values(str);commit;

OPEN p_getbookingrecord FOR str;

OPEN p_accounts1 FOR SELECT * FROM PACKAGE1;

OPEN P_ACCOUNTS2 FOR
SELECT DISTINCT "Edition_Code","Edition",
Case when "Insert_Date" is not null then
    CASE dateformat WHEN 'mm/dd/yyyy' THEN TO_CHAR("Insert_Date",'mm/dd/yyyy')
                    WHEN 'dd/mm/yyyy' THEN TO_CHAR("Insert_Date",'dd/mm/yyyy')
                    WHEN 'yyyy/mm/dd' THEN TO_CHAR("Insert_Date",'yyyy/mm/dd')
Else
    null
End 
END AS "Ins.Date" 
FROM TBL_BOOKING_INSERT WHERE  "Comp_Code"=compcode and "Cio_Booking_Id"=ciobooking and "No_Insert"=insertion;


END ;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE Procedure pcenter_wise_detail(
     pcompcode          in varchar2,
     ppcenter           in varchar2,
     puserid            in varchar2,
     pdateformat        in varchar2,
     pextra1            in varchar2,
     pextra2            in varchar2,
     p_accounts         out cur_type_new1.cursor_type)
As
Begin
    open p_accounts for 
    select "Comp_Code" as "COMP_CODE",  "Pub_cent_Code"as "PUB_CENT_CODE",  "Pub_Cent_name" as  "PUB_CENT_NAME",  "Pub_Cent_Alias" as "PUB_CENT_ALIAS",  "Add1" as "ADD1",  "street" as "STREET","Country_Code" as "COUNTRY_CODE",  
    "State_Code" as "STATE_CODE",  "Dist_Code" as "DIST_CODE",  "City_Code" as "CITY_CODE",(select distinct "City_Name" from city_mst where "City_Code"=pub_cent_mast."City_Code")  as "CITY_NAME","zip" as "ZIP", "Phone1" as "PHONE1",
    "Phone2" as "PHONE2", "Fax" as "FAX",  "EmailID" as "EMAILID",  "Pub_Cent_Status" as "PUB_CENT_STATUS",  "Status_date" as "STATUS_DATE",  "Remarks" as "REMARKS",  "UserId" as "USERID",  "Creation_Datetime" as "CREATION_DATETIME",
    "Region_code" as "REGION_CODE",(select "Region_Name" from region_mst where "Region_Code"=pub_cent_mast."Region_code") as "REGION_NAME","Zone_code" as "ZONE_CODE",(select "Zone_Name" from zone_mst where "Zone_Code"=pub_cent_mast."Zone_code") as "ZONE_NAME", 
    "Fax1" as "FAX1", boxaddress as "BOXADDRESS",  print_cent as "PRINT_CENT", ip as "IP",  file_path as "FILE_PATH", cir_file_path as "CIR_FILE_PATH",
    nvl(center_comp_name,(select "Comp_Name" from comp_mst x where x."Comp_Code"= pub_cent_mast."Comp_Code" and "Comp_Code"=pcompcode)) "CENTER_COMP_NAME",
    (select "PAN_No" from comp_mst where comp_mst."Comp_Code"= pub_cent_mast."Comp_Code") as "PAN_NO" 
    from pub_cent_mast where ("Pub_cent_Code"=ppcenter or ppcenter is null)
    order by "COMP_CODE","PUB_CENT_NAME";

END pcenter_wise_detail;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE Websp_Bindcioidnew1
(
fromdate IN VARCHAR2,
todate IN VARCHAR2,
date1 IN VARCHAR2,
publication IN VARCHAR2,
bookingcenter IN VARCHAR2,
revenuecenter IN VARCHAR2,
agencytype IN VARCHAR2,

PACKAGE1 IN VARCHAR2,
adtype1 IN VARCHAR2,
agency IN VARCHAR2,
client IN VARCHAR2,
billstatus IN VARCHAR2,
rate_audit IN VARCHAR2,
billmode IN VARCHAR2,
billcycle IN VARCHAR2,

v_retainer_name in varchar2,
v_executive_name in varchar2,
v_branch_name in varchar2,
v_ad_category in varchar2,
v_district in varchar2,
v_taluka in varchar2,
pcompcode  IN  varchar2,
P_BILLNO IN VARCHAR2,
P_BILL_GEN_PRIOR IN VARCHAR2,
P_CENTERLOGIN IN VARCHAR2,
P_PUB_CENT_HO IN VARCHAR2,
P_FMG_BILL IN VARCHAR2,
P_SCHEME_TYPE in varchar2,
pto_bill_no in varchar2,

p_recordset OUT Cur_Type_New1.cursor_type

)

IS

query1 VARCHAR2(10000);


v_bill_criteria varchar2(10);

BEGIN
    if adtype1='DI0' then
        select disp_billing_criteria into v_bill_criteria from preferrences where "comp_code"=pcompcode;
    else
        select clsd_billing_criteria into v_bill_criteria from preferrences where "comp_code"=pcompcode;
    end if;
    
   IF(billstatus='3' AND rate_audit='n')
   THEN

      query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",


      nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where

cust_mast."Cust_Code"=tbl_booking_mast."Client_code"),"Client_code") as "client",


      AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
      TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
       tbl_booking_insert.BILL_NO
       ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"  AND
       TBL_BOOKING_INSERT."Insert_Status"=''publish'' AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"' ;
   END IF;


 IF(billstatus='3' AND rate_audit='y')
THEN

      query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
 nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where

cust_mast."Cust_Code"=tbl_booking_mast."Client_code"),"Client_code") as "client",
      AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
      TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
       tbl_booking_insert.BILL_NO
       ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"

      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"  AND
       TBL_BOOKING_INSERT."Insert_Status"=''audit by rate'' AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"' ;
END IF;
IF(billstatus='1' AND rate_audit='y'AND billmode='2')
THEN

 query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
 nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where

cust_mast."Cust_Code"=tbl_booking_mast."Client_code"),"Client_code") as "client",
      AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
      TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
       tbl_booking_insert.BILL_NO
       ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"  AND (TBL_BOOKING_INSERT."Insert_Status" =''AUDIT BY rate'' OR TBL_BOOKING_INSERT."Insert_Status"=''billed'')' ;
END IF;
IF(billstatus='1' AND rate_audit='n' AND billmode='2')
THEN

 query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
      (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
      AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
      TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
       tbl_booking_insert.BILL_NO
       ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
 AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"  AND (TBL_BOOKING_INSERT."Insert_Status" =''publish'' OR TBL_BOOKING_INSERT."Insert_Status"=''billed'')' ;
END IF;

IF(billstatus='1' AND rate_audit='n' AND (billmode='1' OR billmode='3'))
THEN
 query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
      (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
      AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
      TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",

      tbl_booking_insert.BILL_NO
      ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"

      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
 AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"  AND (TBL_BOOKING_INSERT."Insert_Status"=''billed'')' ;
END IF;

IF(billstatus='1' AND rate_audit='y' AND (billmode='1' OR billmode='3'))
THEN

 query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
      (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
      AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
      TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
      tbl_booking_insert.BILL_NO
      ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
 AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"  AND (TBL_BOOKING_INSERT."Insert_Status"=''billed'')' ;
END IF;

IF(billstatus='3' AND rate_audit='n' AND (billmode='1' OR billmode='3'))
THEN

 query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
      (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
      AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
      TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
      tbl_booking_insert.BILL_NO
      ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
 AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"  AND (TBL_BOOKING_INSERT."Insert_Status"=''billed'')' ;
END IF;
IF(billstatus='3' AND rate_audit='y' AND (billmode='1' OR billmode='3'))
THEN

 query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
      (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
      AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
      TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
      tbl_booking_insert.BILL_NO
      ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
 AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"  AND (TBL_BOOKING_INSERT."Insert_Status"=''billed'')' ;
END IF;
IF(billstatus=2)
THEN
 query1:=' SELECT DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id","No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code" AS "edition" ,
(SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS  "total",TBL_BOOKING_MAST."Bill_remarks",
tbl_booking_insert.BILL_NO
,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"  AND
 TBL_BOOKING_INSERT."Insert_Status"=''billed'' AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code" ';
END IF;



   IF(billstatus='5')
   THEN

      query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
      (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
      AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
      TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
      tbl_booking_insert.BILL_NO
      ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"  AND
       TBL_BOOKING_INSERT."Insert_Status"=''publish'' AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"' ;
   END IF;


IF(billstatus=6)
THEN
 query1:=' SELECT DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id","No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code" AS "edition" ,
(SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS  "total",TBL_BOOKING_MAST."Bill_remarks",
tbl_booking_insert.BILL_NO
,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"  AND
 TBL_BOOKING_INSERT."Insert_Status"=''booked'' AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code" ';
END IF;








    IF(v_retainer_name  IS NOT NULL)
THEN
 query1:= query1 ||' and TBL_BOOKING_MAST ."RETAINER" ='''||v_retainer_name ||'''';
END IF;




        IF(v_executive_name IS NOT NULL)
THEN
 query1:= query1||' and TBL_BOOKING_MAST  ."Executive_code" ='''||v_executive_name ||'''';
END IF;



IF(v_branch_name  IS NOT NULL)
THEN
 query1:= query1 ||' and TBL_BOOKING_MAST ."branch" ='''||v_branch_name ||'''';
END IF;



IF(v_ad_category  IS NOT NULL)
THEN
 query1:= query1 ||' and TBL_BOOKING_MAST ."Ad_cat_code" ='''||v_ad_category||'''';
END IF;


IF(v_district  IS NOT NULL)
THEN
 query1:= query1 ||' and TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."Dist_Code" ='''||v_district||''' or '''||v_district||''' is null)';
END IF;



IF(v_taluka IS NOT NULL)
THEN
 query1:= query1||'  AND TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where (AGENCY_MAST."Dist_Code"  in(select DIST_CODE from taluka_mast where   TALU_CODE='''||v_taluka||''' or '''||v_taluka||''' is null) )  AND AGENCY_MAST."Dist_Code"='''||v_district||''' OR '''||v_district||'''  IS NULL   )';
END IF;

/*if v_bill_criteria='A' then
    IF(billcycle IS NOT NULL)
    THEN
        query1:=query1 ||' AND AGENCY_MAST."BILL_FREQUENCY"='''||billcycle ||'''';
    END IF;
elsif v_bill_criteria='R' then

    IF(billcycle IS NOT NULL)
    THEN
        query1:=query1 ||' AND TBL_BOOKING_MAST."Bill_cycle" ='''||billcycle ||'''';
    END IF;
end if;*/
IF(agency IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST."Agency_sub_code" ='''||agency ||'''';
END IF;

IF(client IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST."Client_code" ='''||client ||'''';
END IF;


IF(agencytype IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST."Agency_type"  ='''||trim(agencytype)||'''';
END IF;
IF(adtype1 IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST. "Ad_type_code" ='''||adtype1||''' ';
END IF;


IF(bookingcenter  IS NOT NULL)
THEN

query1:=query1 ||' AND TBL_BOOKING_MAST. "branch" ='''||bookingcenter||''' ';
END IF;




if (P_FMG_BILL !='Include')
then

query1:=query1 ||' AND tbl_booking_mast."Booking_type" not in (''2'',''4'',''5'')';

end if;

if(P_SCHEME_TYPE='EXCLUDE')
THEN

query1:=query1 ||' AND tbl_booking_INSERT ."Pai_Free_Ins"  in (''Y'')';

END IF;




IF(revenuecenter IS NOT NULL)
THEN

query1:=query1 ||' AND TBL_BOOKING_MAST. "branch" ='''||revenuecenter||''' ';
END IF;

IF(publication IS NOT NULL)
THEN
query1:=query1 ||'AND  TBL_BOOKING_INSERT."Publication_Code"='''||publication ||'''';
END IF;

if (P_BILLNO is not null) and (pto_bill_no is not null) then
   query1:=query1 ||'AND  tbl_booking_insert.BILL_NO between '''||P_BILLNO||''' and '''||pto_bill_no||'''';
END IF;



IF(fromdate IS NOT NULL AND todate IS NOT NULL )
THEN
 query1:=query1 ||'  AND "Insert_Date" BETWEEN  '''||fromdate ||''' AND  '''||todate ||''' ';
END IF;



IF(PACKAGE1 IS NOT  NULL)
THEN
query1:=query1 ||' AND  TBL_BOOKING_INSERT."Edition" ='''||PACKAGE1 ||'''';
END IF;

query1:=query1 ||'group by TBL_BOOKING_INSERT."Cio_Booking_Id",tbl_booking_insert."No_Insert" ,TBL_BOOKING_MAST."Package_code"
 , AGENCY_MAST."Agency_Name",TBL_BOOKING_MAST."Trade_disc",TBL_BOOKING_INSERT."Insert_Status",TBL_BOOKING_MAST."No_of_insertion"
 ,TBL_BOOKING_MAST."Bill_remarks",TBL_BOOKING_MAST."Client_code",tbl_booking_insert.BILL_NO, tbl_booking_insert."Comp_Code",tbl_booking_insert."Insert_Date"  order by TBL_BOOKING_INSERT."Cio_Booking_Id", tbl_booking_insert."No_Insert"';


 delete from ank_search_new;
insert into ank_search_new values(query1);
commit;



 OPEN p_recordset FOR

 query1;

END ;
/

//===========================================End of Script==================================//

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep billing 20/03/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@



//-----------------------------------------------start-------------------------//


CREATE OR REPLACE PACKAGE HT18JULY.Wesp_Updatedate
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
p_CURRENCY_MEASUREMENT     IN VARCHAR2,

p_EDITABLE_AGENCY_COMM      IN VARCHAR2,
p_CANCELLATION_CHARGE      IN VARCHAR2,
P_taxi_entry_type          IN VARCHAR2

);
END      Wesp_Updatedate;
/






CREATE OR REPLACE PACKAGE BODY HT18JULY.Wesp_Updatedate IS
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
p_CURRENCY_MEASUREMENT     IN VARCHAR2,

p_EDITABLE_AGENCY_COMM      IN VARCHAR2,
p_CANCELLATION_CHARGE      IN VARCHAR2,
P_taxi_entry_type          IN VARCHAR2

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
RECORDS_ON_PAGE = p_paging,RECORDS_ON_PRINT = p_print,HEADER_ON_PAGE = p_allowpage,AGENCY_REQUIRED = p_agency_req,REGION_REQUIRED = p_region_req,
ALLOW_FOLLOW_DT_BOOOK=p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=p_CRM_SUPPLY_TYPE_FREE,
CURRENCY_MEASUREMENT=p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM=p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE=p_CANCELLATION_CHARGE,taxi_entry_type=P_taxi_entry_type 

  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/

//------------------------------------------end of script---------------------//


//-----------start-----------------------------------------------------//


CREATE OR REPLACE PACKAGE HT18JULY.Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/



CREATE OR REPLACE PACKAGE BODY HT18JULY.Currbindpreferpgld
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
        AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE ,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,"Space_area",EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE,TAXI_ENTRY_TYPE   
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/


//--------------------------------------end of script------------------//

//--------------------------------------ankit-------pending for dummy----------//

CREATE OR REPLACE PROCEDURE pending_for_dummy(
pcompcode       in varchar2,
ppubcenter      in varchar2, 
padtype         in varchar2,
ppubdate        in varchar2,
ppublcode       in varchar2,
pedtncode       in varchar2,
psuplcode       in varchar2,
preason         in varchar2,--1 for unapproval ,2 for unaduited 3 for material not upload
pdateformat     in varchar2,
puserid         in varchar2,
pextra1         in varchar2,
pextra2         in varchar2,
pextra3         in varchar2,
pextra4         in varchar2,
pextra5         in varchar2,
p_Accounts      OUT Cur_Type_New1.cursor_type)

is
    v_dt    date;
    v_approval_flag varchar2(1);
    
    cursor c1 is
    select distinct x.comp_code AS "COMP_CODE",x.cio_booking_id AS "CIO_BOOKING_ID",x.date_time AS "DATE_TIME",x.agency_code AS "AGENCY_CODE",x.sub_agency_code AS "SUB_AGENCY_CODE" ,x.agency_name AS "AGENCY_NAME",
    x.client_name AS "CLIENT_NAME",x.package_code AS "PACKAGE_CODE",x.package_name AS "PACKAGE_NAME",
    x.ad_cat as "AD_CAT",x.category_name as "CATEGORY_NAME",x.edition as "EDITION",x.no_insert "NO_INSERT",
    x.discount as "DISCOUNT",x."AUDIT" AS "AUDIT",x.file_name AS "FILE_NAME",x.reason_type as "REASON_TYPE" from
    (select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    nvl((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",NULL AS "EDITION",1 "NO_INSERT",
    nvl(m."Discount",0)+nvl(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",NULL AS "FILE_NAME",'1' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and i."Insert_Date"=v_dt and 
            m."Ad_type_code"=nvl(padtype,m."Ad_type_code") and i."Pub_Cent_Code"=nvl(ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=nvl(ppublcode,i."Publication_Code") and
            i."Edition_Code"=nvl(pedtncode,i."Edition_Code") and i."Supp_Code"=nvl(psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','publish','audit by rate','billed','hold') and
            (nvl(m."Discount",0)+nvl(m."Special_discount",0))>0 and nvl(m.app_status,'N')='N' and v_approval_flag='D' 
    union
    select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    nvl((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",NULL AS "EDITION",1 "NO_INSERT",
    nvl(m."Discount",0)+nvl(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",NULL AS "FILE_NAME",'2' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and i."Insert_Date"=v_dt and 
            m."Ad_type_code"=nvl(padtype,m."Ad_type_code") and i."Pub_Cent_Code"=nvl(ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=nvl(ppublcode,i."Publication_Code") and
            i."Edition_Code"=nvl(pedtncode,i."Edition_Code") and i."Supp_Code"=nvl(psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','publish','audit by rate','billed','hold') and
            (nvl(m."Discount",0)+nvl(m."Special_discount",0))>0 and m."audit" is null and nvl(m.app_status,'N')='Y' and v_approval_flag='D'
    union
    select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    nvl((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",NULL AS "EDITION",1 "NO_INSERT",
    nvl(m."Discount",0)+nvl(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",NULL AS "FILE_NAME",'2' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and i."Insert_Date"=v_dt and 
            m."Ad_type_code"=nvl(padtype,m."Ad_type_code") and i."Pub_Cent_Code"=nvl(ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=nvl(ppublcode,i."Publication_Code") and
            i."Edition_Code"=nvl(pedtncode,i."Edition_Code") and i."Supp_Code"=nvl(psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','publish','audit by rate','billed','hold') and
            m."audit" is null and v_approval_flag='N'
    union
    select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    nvl((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",i."Edition" AS "EDITION",i."No_Insert" "NO_INSERT",
    nvl(m."Discount",0)+nvl(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",i."File_Name" AS "FILE_NAME",'3' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and i."Insert_Date"=v_dt and 
            m."Ad_type_code"=nvl(padtype,m."Ad_type_code") and i."Pub_Cent_Code"=nvl(ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=nvl(ppublcode,i."Publication_Code") and
            i."Edition_Code"=nvl(pedtncode,i."Edition_Code") and i."Supp_Code"=nvl(psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','publish','audit by rate','billed','hold') and
            m."audit" is not null and i."File_Name" is null) x where reason_type=nvl(preason,reason_type)
            order by reason_type,date_time,cio_booking_id,edition;        
v1 c1%rowtype;
v_rec_count number(5);
BEGIN
    delete from temp_ad_bills_report where sess_id=userenv('sessionid');
    v_approval_flag:='N';
    
    select relauthreqon into v_approval_flag from preferrences where "comp_code"=pcompcode;
    
    v_dt:=to_date(ppubdate,''''||pdateformat||'''');
    
    Open c1;
    Loop
        Fetch c1 into v1;
        Exit when c1%notfound;
        
        v_rec_count:=nvl(v_rec_count,0)+1;
        
        insert into temp_ad_bills_report(cioid,rodate,client,package_code,adcat,packag,comp_code,padtype,ag_main_code,ag_sub_code,noinsert,clientcd,page_type,page_no,sess_id)
        values(v1.cio_booking_id,v1.date_time,v1.client_name,v1.agency_name,v1.category_name,v1.package_name,v1.comp_code,padtype,v1.agency_code,v1.sub_agency_code,v1.no_insert,v1.edition,v1.reason_type,v_rec_count,userenv('sessionid'));
        
    End loop;
    Close c1;        
    commit;
    
    open p_accounts for
    select comp_code as "COMP_CODE",cioid as "BKID",rodate as "BK_DATE",client as "CLIENT_NAME",package_code as "AGENCY_NAME",adcat as "CAT_NAME",
    packag as "PACKAGE_NAME",padtype as "AD_TYPE",ag_main_code as "AG_MAIN_CODE",ag_sub_code as "AG_SUB_CODE",noinsert as "NOINSERT",
    clientcd as "EDITION",page_type as "REASON_TYPE",page_no as "REC_NO"
    from temp_ad_bills_report where sess_id=userenv('sessionid') order by rec_no;
    
    delete from temp_ad_bills_report where sess_id=userenv('sessionid');commit;
END pending_for_dummy;
/

//--------------------------------------ankit-------pending for dummy----------//


@@@@@@@@@@@@@@@@@@@@@@@@@@@sumit  allads of the day  21/03/2012@@@@@@@@@@@@@@@@@@@@@@@

CREATE OR REPLACE PROCEDURE erp.reportnew1 (
   agname          IN       VARCHAR2 := NULL,
   clientname      IN       VARCHAR2 := NULL,
   adtype1         IN       VARCHAR2,
   adcategory      IN       VARCHAR2,
   adsubcategory   IN       VARCHAR2,
   fromdate        IN       VARCHAR2,
   dateto          IN       VARCHAR2,
   compcode        IN       VARCHAR2,
   pub_name        IN       VARCHAR2,
   pub_cent        IN       VARCHAR2,
   status          IN       VARCHAR2 := NULL,
   edition         IN       VARCHAR2,
   DATEFORMAT      IN       VARCHAR2,
   hold            IN       VARCHAR2 := NULL,
   descid          IN       VARCHAR2 := NULL,
   ascdesc         IN       VARCHAR2 := NULL,
   agtype          IN       VARCHAR2 := NULL,
   puserid         IN       VARCHAR2 := NULL,
   chk_access      IN       VARCHAR2 := NULL,
   pbranch         IN       VARCHAR2 := NULL,
   pprint_center   IN       VARCHAR2 := NULL,
   pwithout_rono   IN       VARCHAR2 := NULL,
                          --it is for without agency ro no. list Y or N or All
   pdate_flag      IN       VARCHAR2 := NULL,
                             --it is used for booking date B or publish date P
   pextra1         IN       VARCHAR2 := NULL,
   pextra2         IN       VARCHAR2 := NULL,
   pextra3         IN       VARCHAR2 := NULL,
   pextra4         IN       VARCHAR2 := NULL,
   pextra5         IN       VARCHAR2 := NULL,
   p_reportnew     OUT      cur_type_new1.cursor_type
)
IS
   center      VARCHAR (50);
   from_date   DATE;
   date_to     DATE;
   v_query     VARCHAR (8000);
   a           NUMBER;
BEGIN
   v_query :=
         ' SELECT m."cio_booking_id" AS "CIOID",i."Edition" as "edition",
    CASE '''
      || DATEFORMAT
      || '''WHEN ''mm/dd/yyyy'' THEN TO_CHAR(i."Insert_Date",''mm/dd/yyyy'')
    WHEN ''dd/mm/yyyy'' THEN TO_CHAR(i."Insert_Date",''dd/mm/yyyy'')
    WHEN ''yyyy/mm/dd'' THEN TO_CHAR(i."Insert_Date",''yyyy/mm/dd'')  END AS "Ins.date" ,
    a."Agency_Name" AS "Agency",
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
    /*(select COMBIN_MAST."Package_Name" from combin_mast where COMBIN_MAST."Combin_Code"  in(m."Package_code"))AS "Package",*/
    case when instr(m."Package_code",'','') >0 then 
        FETCH_PACK_new('''
      || compcode
      || ''', m."Package_code" ) 
    else
        (select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=m."Package_code")
    end AS "Package",
    i."Height" AS "Depth",i."Width"   AS "Width",round(i."Size_Book",2) AS "Area",
    (select uom_mast.UOM_DESC from uom_mast where m."Uom_code"=uom_mast."Uom_Code")as "uom",i."Col_Code" AS "Color_code",
    (SELECT ADVPOS_TYPE_MAST."Pos_Type_Alias" FROM ADVPOS_TYPE_MAST WHERE i."Page_Post"=ADVPOS_TYPE_MAST."Pos_Type_Code") AS "Page",
    m."Bullet_code" AS "BulletPremium" ,i."Page_Post" AS "PositionPremium" ,i."Premium1" AS "PagePremium" ,
    m."RO_No" AS "RoNo.",CASE m."ro_status" WHEN ''2'' THEN ''Reservation'' WHEN ''1'' THEN ''Confirm'' END AS "RoStatus",
    (SELECT ADV_CAT_MAST."Adv_Cat_Name" FROM ADV_CAT_MAST WHERE ADV_CAT_MAST."Adv_Cat_Code"=i."Ad_Cat") AS "AdCat",
    m."Card_rate" AS "CardRate",NVL("Agrred_rate",0) AS "AgreedRate",i."Bill_Amt" AS "Amt",m."Caption" AS "Cap",m."Key_no" AS "Key",
    (SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''
      || compcode
      || ''') AS "companyname",
    sysdate as "Rundate",
    m.CASHDISCOUNT as "Cash_Disc", m."AUDIT_COMMENT" as "COMMENT",m."Dockit_no" as "DOCKIT_NO"
    FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a
    WHERE m."Comp_code"='''
      || compcode
      || '''
    AND m."cio_booking_id"=i."Cio_Booking_Id"
    AND m."Agency_code"=a."Agency_Code"
    and m."Agency_sub_code"=a."code_subcode"
    AND m."cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
    and  lower(i."Insert_Status") !=''cancel''
    and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where  newuser_id='''
      || puserid
      || ''') and '''
      || chk_access
      || '''=''1'')
    or  ('''
      || chk_access
      || '''=''0'') )';

/*
IF(hold IS NOT NULL)THEN
v_query:=v_query||' and m."Insert_Status"!='''||'Cancel'||'''';

END IF;
*/
   IF (agname IS NOT NULL)
   THEN
      v_query := v_query || ' and m."Agency_code" =''' || agname || '''';
   END IF;

   IF (clientname IS NOT NULL)
   THEN
      v_query := v_query || ' and m."Client_code"=''' || clientname || '''';
   END IF;

   IF (status IS NOT NULL)
   THEN
      v_query := v_query || ' and i."Insert_Status"=''' || status || '''';
   END IF;

   IF (adtype1 IS NOT NULL)
   THEN
      v_query := v_query || ' and m."Ad_type_code"=''' || adtype1 || '''';
   END IF;

   IF (adcategory IS NOT NULL)
   THEN
      a := fn_splitfield (adcategory, ',');
      --v_query:=v_query||' and m."Ad_cat_code" in('''||Adcategory||''' )';
      v_query :=
         v_query || ' and i."Ad_Cat" in(select "EDITION_NAME" from result  )';
   END IF;

   IF (adsubcategory IS NOT NULL)
   THEN
      a := fn_splitfield_new (adsubcategory, ',');
      v_query :=
            v_query
         || ' and m."Ad_sub_cat_code" in(select "EDITION_NAME" from result_new where sess_id='
         || USERENV ('sessionid')
         || ' )';
   END IF;

   IF (pub_cent IS NOT NULL)
   THEN
      v_query := v_query || '  and i."Pub_Cent_Code"=''' || pub_cent || '''';
   END IF;

   IF pdate_flag = 'B'
   THEN
      IF (fromdate IS NOT NULL AND dateto IS NULL)
      THEN
         v_query := v_query || ' and m."date_time" =''' || fromdate || '''';
      END IF;

      IF (fromdate IS NOT NULL AND dateto IS NOT NULL)
      THEN
         v_query :=
               v_query
            || ' and m."date_time" between  '''
            || fromdate
            || ''' and  '''
            || dateto
            || ''' ';
      END IF;
   ELSE
      IF (fromdate IS NOT NULL AND dateto IS NULL)
      THEN
         v_query := v_query || ' and i."Insert_Date" =''' || fromdate || '''';
      END IF;

      IF (fromdate IS NOT NULL AND dateto IS NOT NULL)
      THEN
         v_query :=
               v_query
            || ' and i."Insert_Date" between  '''
            || fromdate
            || ''' and  '''
            || dateto
            || ''' ';
      END IF;
   END IF;

   IF (edition IS NOT NULL)
   THEN
      v_query := v_query || '  and i."Edition_Code"=''' || edition || '''';
   END IF;

   IF (pextra1 IS NOT NULL)
   THEN
      v_query := v_query || '  and m."Uom_code"=''' || pextra1 || '''';
   END IF;

   IF (pub_name IS NOT NULL)
   THEN
      v_query :=
               v_query || ' and  i."Publication_Code"=''' || pub_name || '''';
   END IF;

   IF ((agtype IS NOT NULL) AND (agtype <> 'Package') AND (agtype <> 'Solo'))
   THEN
      v_query :=
               v_query || ' and  m."Agency_type"=''' || UPPER (agtype)
               || '''';
   END IF;

   IF (pprint_center IS NOT NULL)
   THEN
      v_query :=
            v_query
         || ' and m."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE m."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''
         || pprint_center
         || ''')) ';
   END IF;

   IF (pbranch IS NOT NULL)
   THEN
      v_query := v_query || ' and m."branch" = ''' || pbranch || ''' ';
   END IF;

   IF pwithout_rono = 'Y'
   THEN
      v_query := v_query || ' and (m."RO_No" is null or m."RO_No"='''') ';
   END IF;

   IF pwithout_rono = 'N'
   THEN
      v_query :=
                v_query || ' and (m."RO_No" is not null or m."RO_No"<>'''') ';
   END IF;

   IF (descid IS NOT NULL)
   THEN
      v_query := v_query || '  order by "' || descid || '"';
      v_query := v_query || '' || ascdesc || '';
   ELSE
      v_query := v_query || '  order by i."Insert_Date",m."cio_booking_id"';
   END IF;

--delete from searchtbl;insert into searchtbl values(v_query);commit;
   OPEN p_reportnew FOR v_query;
END reportnew1;
/

////////////////////////////////////////////
CREATE OR REPLACE PROCEDURE erptest.getuom (
   compcode     IN       VARCHAR2,
   adtype       IN       VARCHAR2,
   uomdesc      IN       VARCHAR2,
   p_accounts   OUT      cur_type_new1.cursor_type
)
IS
BEGIN
   OPEN p_accounts FOR
      SELECT   "Uom_Code", "Uom_Name"
          FROM uom_mast
         WHERE "Comp_Code" = compcode AND "Ad_Type" = adtype
      ORDER BY "UOM_DESC";
END;
/


@@@@@@@@@@@@@@@@@@@@@@@@@@@sumit  allads of the day  21/03/2012@@@@@@@@@@@@@@@@@@@@@@@
/**************mimoh 22 march ***************qbc procedure*****************************/


CREATE OR REPLACE PROCEDURE chkrono (
   compcode      IN       VARCHAR2,
   userid        IN       VARCHAR2,
   agency        IN       VARCHAR2,
   p_rono        IN       VARCHAR2,
   p_accounts    OUT      cur_type_new1.cursor_type,
   p_accounts1   OUT      cur_type_new1.cursor_type
)
IS
cnt_agen NUMBER;
CNT NUMBER;
BEGIN
   OPEN p_accounts FOR
      SELECT "RO_No"
        FROM tbl_booking_mast
       WHERE "RO_No" = p_rono
         AND "Comp_code" = compcode
         AND "Agency_sub_code" = agency;
         
   SELECT COUNT (*)
     INTO cnt_agen
     FROM ro_book_allotment
    WHERE comp_code = compcode AND code_subcode = agency;

   SELECT COUNT (*)
     INTO cnt
     FROM ro_book_allotment
    WHERE comp_code = compcode
      AND code_subcode = agency
      AND (   TO_NUMBER (p_rono) BETWEEN rono_from AND rono_till
           OR rono_from IS NULL
           OR rono_till IS NULL
          );
          

   IF cnt_agen > 0
   THEN
      IF cnt > 0
      THEN
         OPEN p_accounts1 FOR
            SELECT *
              FROM ro_book_allotment
             WHERE comp_code = compcode
               AND code_subcode = agency
               AND (   TO_NUMBER (p_rono) BETWEEN rono_from AND rono_till
                    OR rono_from IS NULL
                    OR rono_till IS NULL
                   );
      ELSE
         OPEN p_accounts1 FOR
            SELECT 'N' res, 'NOT IN RO RANGE' res1
              FROM DUAL;
      END IF;
   ELSE
      OPEN p_accounts1 FOR
         SELECT 'Y' res, 'AGENCY NOT ENTERED' res1
           FROM DUAL;
   END IF;
EXCEPTION
   WHEN OTHERS
   THEN
      OPEN p_accounts1 FOR select 'N' as res from dual;
END;
/

/**************mimoh 22 march ***************qbc procedure*****************************/

/************************mimoh6992***********************/
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
p_CURRENCY_MEASUREMENT     IN VARCHAR2,

p_EDITABLE_AGENCY_COMM      IN VARCHAR2,
p_CANCELLATION_CHARGE      IN VARCHAR2,
P_taxi_entry_type          IN VARCHAR2,
P_ApprovalWith          IN VARCHAR2
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
p_CURRENCY_MEASUREMENT     IN VARCHAR2,

p_EDITABLE_AGENCY_COMM      IN VARCHAR2,
p_CANCELLATION_CHARGE      IN VARCHAR2,
P_taxi_entry_type          IN VARCHAR2,
P_ApprovalWith          IN VARCHAR2

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
RECORDS_ON_PAGE = p_paging,RECORDS_ON_PRINT = p_print,HEADER_ON_PAGE = p_allowpage,AGENCY_REQUIRED = p_agency_req,REGION_REQUIRED = p_region_req,
ALLOW_FOLLOW_DT_BOOOK=p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=p_CRM_SUPPLY_TYPE_FREE,
CURRENCY_MEASUREMENT=p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM=p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE=p_CANCELLATION_CHARGE,taxi_entry_type=P_taxi_entry_type,APPROVAL_WITH =P_ApprovalWith 

  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/

/************************************************************************************/
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
        AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE ,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,"Space_area",EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE,TAXI_ENTRY_TYPE,APPROVAL_WITH    
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/
/************************mimoh6992***********************/


/**********start**************ankit create user***********************/

CREATE OR REPLACE PACKAGE bindagencynameonkey
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE bindagencynameonkey_p (
      compcode     IN       VARCHAR2,
      userid       IN       VARCHAR2,
      agency       IN       VARCHAR2,
      p_accounts   OUT      t_accounts_cursor
   );
END bindagencynameonkey;
/









CREATE OR REPLACE PACKAGE BODY bindagencynameonkey
is
procedure bindagencynameonkey_p(compcode in varchar2,
userid in varchar2,agency in varchar2,
p_Accounts out T_Accounts_Cursor) as

begin
open p_Accounts for
select  distinct  "SUB_Agency_Code","Agency_Name","code_subcode" from Agency_mast where "Comp_Code"=compcode  and "Agency_Name" like '%'||agency||'%' order by "Agency_Name";

end   bindagencynameonkey_p;

end   bindagencynameonkey;
/




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
         SELECT "username", "password", "userid", "date_format", "COM_CODE", "comp_name", "Autogenerate", "curr_code", "retainer_code",AD_GET_FIELDNAME1('Comp_Code',com_code,'code_subcode',LOGIN."Agency_code",'Agency_Name','Agency_mast','','') AS "Agency_code", "User_status", "Admin", "Company_user", USER_COMPANY, CREATION_DATETIME, EMAIL, DISCOUNT, FILTER, ROLEID, BOOKING_EDITLINES, FIRSTNAME, LASTNAME, ROLE, STATUS, DOMAIN_USER, ad_get_fieldname('COMP_CD',com_code,'EMP_CODE',LOGIN.HR_CODE,'NAME','HR_EMP_MST','','') AS HR_CODE FROM LOGIN 
          WHERE "Admin"is null
            and ("COM_CODE" = com_code OR com_code IS NULL)
            AND ("username" LIKE username || '%' OR username IS NULL)
            AND ("userid" LIKE userid || '%' OR userid IS NULL);
  else
     OPEN p_accounts FOR
         SELECT "username", "password", "userid", "date_format", "COM_CODE", "comp_name", "Autogenerate", "curr_code", "retainer_code",AD_GET_FIELDNAME1('Comp_Code',com_code,'code_subcode',LOGIN."Agency_code",'Agency_Name','Agency_mast','','') AS "Agency_code", "User_status", "Admin", "Company_user", USER_COMPANY, CREATION_DATETIME, EMAIL, DISCOUNT, FILTER, ROLEID, BOOKING_EDITLINES, FIRSTNAME, LASTNAME, ROLE, STATUS, DOMAIN_USER, ad_get_fieldname('COMP_CD',com_code,'EMP_CODE',LOGIN.HR_CODE,'NAME','HR_EMP_MST','','') AS HR_CODE  FROM LOGIN
          WHERE  "Admin"='yes'
          and ("COM_CODE" = com_code OR com_code IS NULL)
            AND ("username" LIKE username || '%' OR username IS NULL)
            AND ("userid" LIKE userid || '%' OR userid IS NULL);       
end if;

END Loginexecute_p;
END Loginexecute;
/






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


/**********end**************ankit create user***********************/


@@@@@@@@@@@@@@@@@@@sumit 26/03/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

CREATE OR REPLACE PACKAGE BODY Rpt_Agencywise_Receipt_Reg IS
PROCEDURE Rpt_Agencywise_Receipt_Reg_p(
   pcompcode           IN VARCHAR2,
   pfrom_date          IN VARCHAR2,
   pto_date            IN VARCHAR2,
   pdoctype            IN VARCHAR2,
   pagency             IN VARCHAR2,
   punit               IN VARCHAR2,
   pdateformat         IN VARCHAR2,
   p_accounts          OUT T_Accounts_Cursor)
AS
   v_val NUMBER:=0;
   query1 varchar2(2000);
BEGIN
   IF pagency IS NOT NULL THEN
       v_val:=Fn_Splitfield(pagency ,';' );
   END IF;


   query1:=query1||'SELECT doctype AS DOCTYPE,recptno AS
RECEIPT_NO,AGCODE AS AGCODE,AG_MAIN_CODE AS AG_MAIN_CODE,AG_SUB_CODE
AS AG_SUB_CODE,
   TO_CHAR(recptdt,'''||pdateformat||''') AS RECEIPT_DATE,chno AS CHEQUE_NO ,
   TO_CHAR(chdt,'''||pdateformat||''') AS CHEQUE_DATE,billno AS
BILL_NO,TO_CHAR(billdt,'''||pdateformat||''') AS
BILL_DATE,TO_CHAR(ABS(amount),''9999999990.90'') AS AMOUNT,
agename('''||pcompcode||''',agcode) as "agname" FROM ad_outstand
   WHERE  recptno  IS NOT NULL AND  recptdt  IS NOT NULL AND
(comp_code='''||pcompcode||''' OR '''||pcompcode||''' IS NULL) AND
                   ( doctype ='''||pdoctype||''' OR
'''||pdoctype||''' IS NULL) AND  recptdt  BETWEEN '''||pfrom_date||'''
AND '''||pto_date||''' AND
                    (unit ='''||punit||''' OR '''||punit||''' IS NULL)
                   AND ( agcode IN(SELECT DISTINCT
"Agency_Code"||"SUB_Agency_Code"  AS agcode FROM agency_mast
                   WHERE  "Agency_Code"||"SUB_Agency_Code"  IN(SELECT
edition_name FROM result)) OR '''||pagency||''' IS NULL)
                   ORDER BY  recptdt,doctype,recptno,billno,billdt' ;

   OPEN p_accounts FOR query1;

   --delete from ank_search;insert into ank_search values(query1);commit;

END;
END Rpt_Agencywise_Receipt_Reg;
/



@@@@@@@@@@@@@@@@@sumit 26/03/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ KULDEEP 26/03/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//=========================== Start Srcipt ========================//
CREATE OR REPLACE PACKAGE loginDelete
IS

PROCEDURE  loginDelete_p (
userid1 in varchar2,
compcode in varchar2
);
END   loginDelete ;
/

CREATE OR REPLACE PACKAGE BODY loginDelete
IS


PROCEDURE  loginDelete_p (
    userid1 in varchar2,
    compcode in varchar2
) 
as
count_rec NUMBER;
begin
select count(*) into count_rec from tbl_booking_mast where "Userid"=userid1;

      IF count_rec IS NULL OR count_rec=0  THEN
        delete login where  "userid"=userid1;
        delete login_branch_mast where user_code=userid1;
        delete from module_detaibuttonl where "userid"= userid1 and "comp_code"=compcode;
        commit;
    END IF;

END   loginDelete_p ;
END   loginDelete ;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE wesp_moduledetailsel
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE wesp_moduledetailsel_p (
      modulename   IN       VARCHAR2,
      userid       IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END wesp_moduledetailsel;
/

CREATE OR REPLACE PACKAGE BODY Wesp_ModuleDetailSel
is
procedure  Wesp_ModuleDetailSel_p (modulename  in varchar2,userid  in varchar2,
P_ACCOUNTS out T_Account_cursor) as
begin
open  P_ACCOUNTS for
select "Form_Name",CASE FORMTYPE WHEN 'M' THEN 'Master' when 'T' then 'Transaction' when  'R'then 'Reports' END AS FORMTYPE,
 "Form_Alias",MODULECODE  from formmast order by MODULECODE,FORMTYPE,"Form_Name";
end Wesp_ModuleDetailSel_p;
end Wesp_ModuleDetailSel;
/

//=========================== Start Srcipt ========================//





///////////////////////////////////////////27/03/2012 for insert //////////////////////////////////////////////

///////////////////////////////
CREATE OR REPLACE PACKAGE websp_editorinsert Is

Procedure websp_editorinsert_P (
PubName in varchar2,
CityName in varchar2,
EditonCode in varchar2,
EditionName in varchar2,
Alias in varchar2,
userid  in varchar2,
compcode in varchar2,
country in varchar2,
circulation in varchar2,
uom in varchar2,
column1 in varchar2,
height1 in varchar2,
width1 in varchar2,
area1 in varchar2,
periodicity in varchar2,
gutter in varchar2,
col_space in varchar2,
hr in varchar2,
min1 in varchar2,
prod in varchar2,
type1 in varchar2,
noofcol in varchar2,
printcent in varchar2,
psegmentcod in varchar2
);

End websp_editorinsert ;
/

/////////////////////////////body

CREATE OR REPLACE package body HT18JULY.websp_editorinsert is

procedure websp_editorinsert_p (
pubname in varchar2,
cityname in varchar2,
editoncode in varchar2,
editionname in varchar2,
alias in varchar2,
userid  in varchar2,
compcode in varchar2,
country in varchar2,
circulation in varchar2,
uom in varchar2,
column1 in varchar2,
height1 in varchar2,
width1 in varchar2,
area1 in varchar2,
periodicity in varchar2,
gutter in varchar2,
col_space in varchar2,
hr in varchar2,
min1 in varchar2,
prod in varchar2,
type1 in varchar2,
noofcol in varchar2,
printcent in varchar2,
psegmentcod in varchar2
) as
begin
insert into edition_mast("Pub_Code", "City_Code", "Edition_Code", "Edition_Name", "Edition_Alias", "Comp_Code", "UserId",  "Country_Code", "No_Of_Circulation", "UOM_Code", "No_Of_Columns", "Size_Height", "Size_Width", "Edition_Area", "Preodicity_Code", "Gutter_Space", "Column_Space", "RO_hr", "RO_min", "Production", "Creation_Datetime","Edition_Type","No_Of_Collumn",print_cent,segment_code)
                     values(pubname,     cityname,    editoncode,  editionname,     alias,            compcode,  userid,       country,       circulation,         uom,       column1,          height1,       width1,       area1,         periodicity,     gutter,        col_space,    hr,      min1,      prod,     sysdate,type1,noofcol,printcent,psegmentcod);


commit;

end websp_editorinsert_p;

end websp_editorinsert;
/


////////////////////////////////////////////27/03/2012 for modify


CREATE OR REPLACE PACKAGE websp_editormodify Is

Procedure websp_editormodify_P (
PubName in varchar2,
CityName in varchar2,
EditonCode in varchar2,
EditionName in varchar2,
Alias in varchar2,
userid  in varchar2,
compcode in varchar2,
country in varchar2,
circulation in varchar2,
uom in varchar2,
column1 in varchar2,
height1 in varchar2,
width1 in varchar2,
area1 in varchar2,
periodicity in varchar2,
gutter in varchar2,
col_space in varchar2,
hr in varchar2,
min1 in varchar2,
prod in varchar2,
type1 in varchar2,
noofcol in varchar2,
printcent in varchar2,
psegmentcod in varchar2

);

End websp_editormodify;
/


///////////////////////////////////////////////body


CREATE OR REPLACE PACKAGE BODY HT18JULY.websp_editormodify Is

Procedure websp_editormodify_P (
PubName in varchar2,
CityName in varchar2,
EditonCode in varchar2,
EditionName in varchar2,
Alias in varchar2,
userid  in varchar2,
compcode in varchar2,
country in varchar2,
circulation in varchar2,
uom in varchar2,
column1 in varchar2,
height1 in varchar2,
width1 in varchar2,
area1 in varchar2,
periodicity in varchar2,
gutter in varchar2,
col_space in varchar2,
hr in varchar2,
min1 in varchar2,
prod in varchar2,
type1 in varchar2,
noofcol in varchar2,
printcent in varchar2,
psegmentcod in varchar2

) As

Begin

update EDITION_MAST set PRINT_CENT=printcent,"Pub_Code"=PubName, "City_Code"=CityName,"Edition_Name"=EditionName,"Edition_Alias"=Alias,"Edition_Code"=EditonCode,"Comp_Code"=compcode,"UserId"=userid,"Country_Code"=country,"No_Of_Circulation"=circulation,"UOM_Code"=uom,"No_Of_Columns"=column1,"Size_Height"=height1,"Size_Width"=width1,"Edition_Area"=area1,"Preodicity_Code"=periodicity,"Gutter_Space"=gutter,"Column_Space"=col_space,"RO_hr"=hr,"RO_min"=min1,"Production"=prod,"Edition_Type"=type1,"No_Of_Collumn"=noofcol,segment_code =psegmentcod where "Comp_Code"=compcode  and "Edition_Code"=EditonCode;




Commit;

End websp_editormodify_P;

End websp_editormodify;
/

///////////////////////////////////////////////////for execute////////////////////

CREATE OR REPLACE PACKAGE HT18JULY.websp_editorselect
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE websp_editorselect_p (
      pubname       IN       VARCHAR2,
      cityname      IN       VARCHAR2,
      editoncode    IN       VARCHAR2,
      editionname   IN       VARCHAR2,
      alias         IN       VARCHAR2,
      userid        IN       VARCHAR2,
      compcode      IN       VARCHAR2,
      country       IN       VARCHAR2,
      circulation   IN       VARCHAR2,
      uom           IN       VARCHAR2,
      column1       IN       VARCHAR2,
      height        IN       VARCHAR2,
      width         IN       VARCHAR2,
      area          IN       VARCHAR2,
      periodicity   IN       VARCHAR2,
      gutter        IN       VARCHAR2,
      col_space     IN       VARCHAR2,
      type1         IN       VARCHAR2,
      psegmentcod   IN       VARCHAR2,
      p_accounts    OUT      t_accounts_cursor
   );
END websp_editorselect;
/

//////////////////////////////body

CREATE OR REPLACE PACKAGE BODY HT18JULY.websp_editorselect
IS
   PROCEDURE websp_editorselect_p (
      pubname       IN       VARCHAR2,
      cityname      IN       VARCHAR2,
      editoncode    IN       VARCHAR2,
      editionname   IN       VARCHAR2,
      alias         IN       VARCHAR2,
      userid        IN       VARCHAR2,
      compcode      IN       VARCHAR2,
      country       IN       VARCHAR2,
      circulation   IN       VARCHAR2,
      uom           IN       VARCHAR2,
      column1       IN       VARCHAR2,
      height        IN       VARCHAR2,
      width         IN       VARCHAR2,
      area          IN       VARCHAR2,
      periodicity   IN       VARCHAR2,
      gutter        IN       VARCHAR2,
      col_space     IN       VARCHAR2,
      type1         IN       VARCHAR2,
      psegmentcod   IN       VARCHAR2,
      p_accounts    OUT      t_accounts_cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
        /* SELECT "Pub_Code","Edition_Name","Edition_Alias","Edition_Code","Country_Code","No_Of_Circulation","UOM_Code",
		 "No_Of_Columns","Size_Height","Size_Width","Edition_Area","Preodicity_Code","Gutter_Space","Column_Space","RO_hr",
		 "RO_min","Production","Edition_Type" ,"No_Of_Collumn"*/


		 select *

           FROM edition_mast
          WHERE ("Comp_Code" = compcode OR compcode IS NULL)
            AND ("Pub_Code" LIKE pubname || '%' OR pubname IS NULL)
            AND ("City_Code" LIKE cityname || '%' OR cityname IS NULL)
            AND ("Edition_Code" LIKE editoncode || '%' OR editoncode IS NULL
                )
            AND ("Edition_Name" LIKE editionname || '%' OR editionname IS NULL
                )
            AND ("Edition_Alias" LIKE alias || '%' OR alias IS NULL)
            AND ("Country_Code" LIKE country || '%' OR country IS NULL)
            AND (   "No_Of_Circulation" LIKE circulation || '%'
                 OR circulation IS NULL
                )
            /*AND ("UOM_Code" LIKE uom || '%' OR uom IS NULL)*/
            AND ("No_Of_Columns" LIKE column1 || '%' OR column1 IS NULL)
            AND ("Size_Height" LIKE height || '%' OR height IS NULL)
            AND ("Size_Width" LIKE width || '%' OR width IS NULL)
            AND ("Edition_Area" LIKE area || '%' OR area IS NULL)
            AND ("Edition_Type" LIKE type1 || '%' OR type1 IS NULL)
            AND (SEGMENT_CODE LIKE psegmentcod || '%' OR psegmentcod IS NULL);
   END websp_editorselect_p;
END websp_editorselect;
/
//////////////////////////////////////////////////////////end of insert modify snd execute procedures//////////////

/*****mimoh 28 march 2012*********7061*************************************************/
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
        AGENCY_UNBLOCK_APPROVAL,UNBLOCK_APPROVAL_OUTSIDE_LIMIT,CIR_BILL_PUBLWISE ,RECORDS_ON_PAGE,RECORDS_ON_PRINT,HEADER_ON_PAGE,AGENCY_REQUIRED,REGION_REQUIRED,ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE,CURRENCY_MEASUREMENT,"Space_area",EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE,TAXI_ENTRY_TYPE,APPROVAL_WITH,
      TDS_AUTO_CN,TDS_AUTO_REASON,TDS_DB_CDP,TDS_CR_CDP,SER_TAX_AUTO_CN,SER_TAX_AUTO_REASON,SER_TAX_DB_CDP,SER_TAX_CR_CDP,PKK_AUTO_CN,PKK_AUTO_REASON,PKK_DB_CDP,PKK_CR_CDP,BANK_CHG_AUTO_CN,BANK_CHG_AUTO_REASON,BANK_CHG_DB_CDP,BANK_CHG_CR_CDP   
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/
/****************************************************************************************************/

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
p_CURRENCY_MEASUREMENT     IN VARCHAR2,

p_EDITABLE_AGENCY_COMM      IN VARCHAR2,
p_CANCELLATION_CHARGE      IN VARCHAR2,
P_taxi_entry_type          IN VARCHAR2,
P_ApprovalWith          IN VARCHAR2,
p_Auto_TDS_Credit_Note IN VARCHAR2,
p_TDS_Reason IN VARCHAR2,
p_Debit_Account_Head IN VARCHAR2,
p_credit_Account_Head IN VARCHAR2,
p_service_tax_credit_note IN VARCHAR2,
p_Tax_Reason IN VARCHAR2,
p_Debit_Account_Service_Tax IN VARCHAR2,
p_Credit_Account_Service_Tax IN VARCHAR2,
p_Auto_Patrakar_Credit_Note IN VARCHAR2,
p_Patrakar_Reason IN VARCHAR2,
p_Debit_Account_Patrakar IN VARCHAR2,
p_Credit_Account_Patrakar IN VARCHAR2,
p_Auto_Bank_Credit_Note IN VARCHAR2,
p_Bank_Reason IN VARCHAR2,
p_Debit_Account_Bank IN VARCHAR2,
p_Credit_Account_Bank IN VARCHAR2
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
p_CURRENCY_MEASUREMENT     IN VARCHAR2,

p_EDITABLE_AGENCY_COMM      IN VARCHAR2,
p_CANCELLATION_CHARGE      IN VARCHAR2,
P_taxi_entry_type          IN VARCHAR2,
P_ApprovalWith          IN VARCHAR2,

p_Auto_TDS_Credit_Note IN VARCHAR2,
p_TDS_Reason IN VARCHAR2,
p_Debit_Account_Head IN VARCHAR2,
p_credit_Account_Head IN VARCHAR2,
p_service_tax_credit_note IN VARCHAR2,
p_Tax_Reason IN VARCHAR2,
p_Debit_Account_Service_Tax IN VARCHAR2,
p_Credit_Account_Service_Tax IN VARCHAR2,
p_Auto_Patrakar_Credit_Note IN VARCHAR2,
p_Patrakar_Reason IN VARCHAR2,
p_Debit_Account_Patrakar IN VARCHAR2,
p_Credit_Account_Patrakar IN VARCHAR2,
p_Auto_Bank_Credit_Note IN VARCHAR2,
p_Bank_Reason IN VARCHAR2,
p_Debit_Account_Bank IN VARCHAR2,
p_Credit_Account_Bank IN VARCHAR2

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
RECORDS_ON_PAGE = p_paging,RECORDS_ON_PRINT = p_print,HEADER_ON_PAGE = p_allowpage,AGENCY_REQUIRED = p_agency_req,REGION_REQUIRED = p_region_req,
ALLOW_FOLLOW_DT_BOOOK=p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=p_CRM_SUPPLY_TYPE_FREE,
CURRENCY_MEASUREMENT=p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM=p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE=p_CANCELLATION_CHARGE,taxi_entry_type=P_taxi_entry_type,APPROVAL_WITH =P_ApprovalWith , TDS_AUTO_CN=p_Auto_TDS_Credit_Note,
TDS_AUTO_REASON=p_TDS_Reason ,TDS_DB_CDP=p_Debit_Account_Head,TDS_CR_CDP=p_credit_Account_Head,SER_TAX_AUTO_CN=p_service_tax_credit_note,SER_TAX_AUTO_REASON=p_Tax_Reason,SER_TAX_DB_CDP=p_Debit_Account_Service_Tax,SER_TAX_CR_CDP=p_Credit_Account_Service_Tax,PKK_AUTO_CN=p_Auto_Patrakar_Credit_Note,PKK_AUTO_REASON=p_Patrakar_Reason ,PKK_DB_CDP=p_Debit_Account_Patrakar,PKK_CR_CDP=p_Credit_Account_Patrakar ,BANK_CHG_AUTO_CN=p_Auto_Bank_Credit_Note ,
BANK_CHG_AUTO_REASON=p_Bank_Reason ,BANK_CHG_DB_CDP=p_Debit_Account_Bank ,BANK_CHG_CR_CDP=p_Credit_Account_Bank 

  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/







/*****************************************************************/



CREATE OR REPLACE FUNCTION AD_GET_REASONNAME(pcompcode in varchar2,preason_code in varchar2)RETURN varchar2 IS
v_name reason_mst."reason_name"%type;
Begin
    BEGIN
        select "reason_name"  into v_name from reason_mst where "Comp_Code"=pcompcode and 
            "reason_code"=preason_code;
        exception when others then
        v_name:=null;
    end;
  return nvl(v_name,'');
END;
/



/*****mimoh 28 march 2012*********7061*************************************************/



/*********Start*******************7050*************avinash******28march2012********

CREATE OR REPLACE procedure rpt_booking_report(
    pagency_code    in varchar2,
    pclient_code    in varchar2,
    pfrom_date      in varchar2,
    pto_date        in varchar2,
    pdateformat     in varchar2,
    ppublication    in varchar2,
    pedition        in varchar2,
    ppub_center     in varchar2,
    pbranch         in varchar2,
    pcompcode       in varchar2,
    puserid         in varchar2,
    chk_access      in varchar2,
    pagency_type    in varchar2,
    pextra1         in varchar2,
    pextra2         in varchar2,
    p_accounts      OUT Cur_Type_New1.cursor_type)
is 
query1 varchar2(8000);
v_frdt date;
v_todt date;
    cursor c1 is
    select a."cio_booking_id" as "BOOKING_ID",c."Agency_Name" AS "AGENCY",
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE a."Comp_code"=CUST_MAST."Comp_Code" AND "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT", 
    "Caption" AS "CAPTION","Key_no" AS "KEY",b."Height" AS "Depth",b."Width"   AS "Width",round(b."Size_Book",2) AS "Area",
    b."Col_Code" as COLOR,b."Page_No" as "Page_No",
    NVL((select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") ,(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER )) as "EXE_RET",
    a."Card_rate" as "CARDRATE",A."Agrred_rate" as "AGGRATE",
    NVL(b."Gross_Rate",'0') as "GROSSAMT",NVL(a."Trade_disc",'0' )as "AGENCYTD(%)",
    NVL(a."ADD_AGENCY_COMM",'0') as  "AgencyAddlTD(%)",
    --CASHDISCOUNT as "Cash_Disc",
    0 as "Cash_Disc",
    NVL(b."Bill_Amt",'0') as "BILLAMT",(select "Comp_Name" from comp_mst where comp_mst."Comp_Code"=a."Comp_code") comp_name
    from tbl_booking_mast a,tbl_booking_insert b,agency_mast c
    WHERE a."Comp_code"=pcompcode AND
    a."Agency_sub_code"=c."code_subcode" AND a."cio_booking_id"=b."Cio_Booking_Id"  and
    ((b."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access='1')
    or (chk_access='0') ) and a."date_time" between v_frdt and  v_todt and (a."Agency_code" =  pagency_code or pagency_code is null) and (a."Client_code"=pclient_code or pclient_code is null)
    and (b."Publication_Code"=ppublication or ppublication is null) and (b."Pub_Cent_Code"=ppub_center or ppub_center is null) and 
    (b."Edition_Code"=pedition or pedition is null) and (a."branch"=pbranch or pbranch is null); 
begin

--insert into test1(vstring,vstring2) values('rpt_booking_report ','pdateformat '||pdateformat||' pfrom_date '||pfrom_date||' pto_date '||pto_date);commit;

v_frdt :=to_date(pfrom_date,''''||pdateformat||'''');
v_todt :=to_date(pto_date,''''||pdateformat||'''');
    /*open c1;
    loop
        fetch c1 into v1;
        exit when c1%notfound;
        
        
        
    end loop;
    close c1;*/    


query1:=query1|| 'select a."cio_booking_id" as "BOOKING_ID",
c."Agency_Name" AS "AGENCY",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE a."Comp_code"=CUST_MAST."Comp_Code" AND "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT", 
"Caption" AS "CAPTION",
"Key_no" AS "KEY",
b."Height" AS "Depth",
b."Width"   AS "Width",
round(b."Size_Book",2) AS "Area",
/*(select col_mast."Col_Alias" from col_mast where b."Col_Code" =col_mast."Col_Code")*/ b."Col_Code" as COLOR,
b."Page_No" as "Page_No",
NVL((select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") ,(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER )) as "EXE_RET",
a."Card_rate" as "CARDRATE",
A."Agrred_rate" as "AGGRATE",
NVL(b."Gross_Rate",''0'') as "GROSSAMT",
NVL(a."Trade_disc",''0'' )as "AGENCYTD(%)",
NVL(a."ADD_AGENCY_COMM",''0'') as  "AgencyAddlTD(%)",
--CASHDISCOUNT as "Cash_Disc",
0 as "Cash_Disc",
NVL(b."Bill_Amt",''0'') as "BILLAMT",(select "Comp_Name" from comp_mst where comp_mst."Comp_Code"=a."Comp_code") comp_name
from tbl_booking_mast a,tbl_booking_insert b,agency_mast c
WHERE a."Comp_code"='''||pcompcode||''' AND
a."Agency_sub_code"=c."code_subcode" AND
a."cio_booking_id"=b."Cio_Booking_Id"  and
 ((b."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') )';

IF(pfrom_date IS NOT NULL AND pto_date IS NOT NULL)
then
query1:=query1||' and a."date_time" between  '''||v_frdt ||''' and  '''||v_todt||''' ';
END if;

IF(pagency_code IS NOT NULL )
then
query1:=query1||' and a."Agency_code" =  '''||pagency_code||''' ';
END if;

IF(pclient_code IS NOT NULL )
then
query1:=query1||' and a."Client_code"='''||pclient_code ||'''';
END if;

IF(ppublication IS NOT NULL )
then
query1:=query1||' and  b."Publication_Code"='''||ppublication||'''';
END if;

IF(ppub_center IS NOT NULL )
then
query1:=query1||'  and b."Pub_Cent_Code"='''||ppub_center||'''';
END if;

IF(pedition IS NOT NULL )
then
query1:=query1||'  and b."Edition_Code"='''||pedition||'''';
END if;

IF(pbranch IS NOT NULL )
then
query1:=query1||'  and a."branch"='''||pbranch||'''';
END if;

DELETE FROM SEARCHTBL;
INSERT INTO SEARCHTBL VALUES(query1);
COMMIT;

open p_accounts for 
query1;

end rpt_booking_report;
/



/*********End*******************7050*************avinash**************


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ kuldeep 28/03/2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//=========================== Start Srcipt ========================//
CREATE OR REPLACE PACKAGE Uomadsize
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE uomadsize_p (
      compcode      IN       VARCHAR2,
     -- userid        IN       VARCHAR2,
	  advtype       in       varchar2,
      p_accounts    OUT      t_account_cursor
      --p_accounts1   OUT      t_account_cursor
   );
END Uomadsize;
/

CREATE OR REPLACE PACKAGE BODY Uomadsize
IS
   PROCEDURE uomadsize_p (
      compcode      IN       VARCHAR2,
   --   userid        IN       VARCHAR2,
       advtype       in       varchar2,
      p_accounts    OUT      t_account_cursor
      --p_accounts1   OUT      t_account_cursor
   )
   AS
   BEGIN
   if advtype is null then
    OPEN p_accounts FOR
         SELECT "Uom_Code", "Uom_Name"
           FROM UOM_MAST
          WHERE "Comp_Code" = compcode order by "Uom_Alias";
    else
     OPEN p_accounts FOR
         SELECT "Uom_Code", "Uom_Name"
           FROM UOM_MAST
          WHERE "Comp_Code" = compcode AND "Ad_Type" = advtype order by "Uom_Code";
   end if;
     
   END uomadsize_p;
END Uomadsize;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE getlogindata (
   vusername    IN       VARCHAR2,
   vpassword    IN       VARCHAR2,
   p_accounts   OUT      cur_type_new1.cursor_type
)
IS
BEGIN
   OPEN p_accounts FOR
      SELECT "username", "password", "userid", "date_format", "COM_CODE",
             "Autogenerate", "curr_code", "comp_name", "retainer_code",EMAIL
        FROM login
       WHERE "userid" = vpassword;-- AND "password" = vpassword;

   COMMIT;
END;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE procedure getapprovalRo_web(
    vusername       in varchar2,
    compcode        in varchar2,
    agency          in varchar2,
    executive       in varchar2,
    client          in varchar2,
    varFromDate     in date,
    varToDate       in date,
    dateformat      in varchar2,
    cioid           in varchar2,
    flag            in varchar2,
    pbranch         in varchar2,
    pdate_based_on  in varchar2,--for Booking date B,Publish Date P
    P_Accounts      OUT Cur_Type_New1.cursor_type) is

relauthreq          varchar2(1);
V_QUERY             VARCHAR(8000);
v_distcount_allowed number(12,2);
V_approval_with     varchar2(1);
v_login_hr_code         varchar2(50);
v_login_exec_team       varchar2(50);
begin

    select relauthreqon,approval_with into relauthreq,V_approval_with from preferrences where "comp_code"=compcode;
   
    select nvl(discount,'0'),hr_code into v_distcount_allowed,v_login_hr_code from login where "userid"=vusername;
    
    select min("Team_code") into v_login_exec_team from exec_mast where "comp_code"=compcode and hr_code=v_login_hr_code;

   
    V_QUERY:='SELECT distinct m."Comp_code",a."Agency_Name" as "AGENCY",(select "City_Name" from city_mst where "City_Code"=a."City_Code") as "CITY_NAME",
    (select "Retain_Name" from retainermaster where "Comp_Code"=m."Comp_code" and "Retain_Code"=m.retainer) as "RETAINER_NAME",
    (select "Exec_name" from EXEC_MAST where "comp_code"=m."Comp_code" and to_char("Exe_no")=m."Executive_code") as "EXECUTIVE_NAME",
    (select "Package_Name" from combin_mast where "Comp_Code"=m."Comp_code" and "Combin_Code"=(
    case when instr(''abcdef'','','') >0 then substr(m."Package_code",1,instr(m."Package_code",'','')-1) 
    else m."Package_code" end)) as "PACKAGE",
    case when '''||dateformat||'''=''dd/mm/yyyy'' then to_char(m."date_time",''dd/mm/yy'')
    when '''||dateformat||'''=''yyyy/mm/dd'' then to_char(m."date_time",''yy/mm/dd'')
    else to_char(m."date_time",''mm/dd/yy'') end as "BOOKDATE",
    (select "Cust_Name" from cust_mast where "Comp_Code"=m."Comp_code" and "Cust_Code"= m."Client_code") as "CLIENT",
    m."RO_No" as "RO_NO",
    case when '''||dateformat||'''=''dd/mm/yyyy'' then to_char(m."RO_Date",''dd/mm/yy'')
    when '''||dateformat||'''=''yyyy/mm/dd'' then to_char(m."RO_Date",''yy/mm/dd'')
    else to_char(m."RO_Date",''mm/dd/yy'') end as "RODATE",
    (select "Exec_name" from exec_mast where  to_char("Exe_no") = m."Executive_code") as "EXECUTIVE",
    (select "Retain_Name" from retainermaster where "Comp_Code"=m."Comp_code" and "Retain_Code"= m."RETAINER") as "RETAINER",
    m."Card_rate" as "CARD_RATE",Fn_Deviatio(m."Card_rate",m."Agrred_rate") as "DEVIATION",m."cio_booking_id" as "CIO_BOOKING_ID",
    m."Bill_amount" as "BILL_AMOUNT",m."Gross_amount" as "GROSS_AMOUNT",
    (select "premiumname" from advpos_prem_mast where "comp_code"=m."Comp_code" and "Premiumcode"=m."Page_prem") as "PAGEPERM",
    m.app_status as "APP_STATUS",m."booked_by" as "BOOKED_BY",
    (select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=m."Comp_code" and "Pay_Mode_Code"=m."Agency_pay") as "PAYMODE",
    m."Receipt_no" as "RECEIPT_NO",m."Ad_cat_code" as "AD_CAT_CODE",(select "Adv_Cat_Name" from adv_cat_mast where "Comp_Code"=m."Comp_code" and "Adv_Cat_Code"=m."Ad_cat_code") as "AD_CAT_NAME",
    m."Color_code" as "COLOR_CODE",(select "Col_Name" from col_mast where "Comp_Code"=m."Comp_code" and "Col_Code"=m."Color_code") as "COLOR_NAME",
    m."Card_amount" as "CARD_AMOUNT",m."Agrred_rate" as "AGRRED_RATE",m."Agreed_amount" as "AGREED_AMOUNT",
    m."Ad_size_height" as "AD_SIZE_HEIGHT",m."Ad_size_width" as "AD_SIZE_WIDTH",(m."Ad_size_height"*m."Ad_size_width") as "SIZE_BOOK",
    to_char(min(i."Insert_Date"),'''||dateformat||''') as "FIRST_INSDATE",to_char(max(i."Insert_Date"),'''||dateformat||''') as "LAST_INSDATE"
        from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
    where m."Comp_code"='''||compcode||''' and m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode"
    and ((Fn_Deviatio(m."Card_rate",m."Agrred_rate") is not null and Fn_Deviatio(m."Card_rate",m."Agrred_rate") != ''0'') OR Fn_chkSalesExec(m."Userid")=''SE0'' OR '''||relauthreq||''' = ''A'')
    and m."Agency_sub_code" = nvl('''||agency||''',m."Agency_sub_code") and (m."Executive_code" = '''||executive||'''  OR '''||executive||''' IS NULL)
    and (m."Client_code" = '''||client||'''  OR '''||client||''' IS NULL)
    and m."cio_booking_id" = nvl('''||cioid||''',m."cio_booking_id" )
    and (nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)) between nvl((select max(nvl(discount,''0'')) from login where "userid"<>'''||vusername||''' and to_number(nvl(discount,''0''))<'||v_distcount_allowed||'),1) and '||v_distcount_allowed||' ';
   
    if flag ='A' then--for Approval
        v_query:=v_query||' and m.app_status=''Y'' ';
    elsif flag ='R' then-- for rejected    
        v_query:=v_query||' and m.app_status=''N'' ';
    else--pending for approval and rejected
        v_query:=v_query||' and nvl(m.app_status,''#'')!=''Y'' and nvl(m.app_status,''#'')!=''N'' ';
    end if;
   
    if pdate_based_on='P' then--On Published date
        v_query:=v_query||' and i."Insert_Date" between '''||varfromdate||''' and '''||vartodate||'''';
    else--on Booking date
        v_query:=v_query||' and m."date_time" between '''||varfromdate||''' and '''||vartodate||'''';
    end if;
    
    if pbranch ='B' then--If B then Data will show Acc. to Branch Permission
        v_query:=v_query||' AND m."branch" in(select ltrim(rtrim(branch_code)) from login_branch_mast where user_code='''||vusername||''' and comp_code='''||compcode||''' and user_flag=''Y'')';
    end if;
   
    If nvl(v_approval_with,'D')='T' and v_login_exec_team is not null then --approval with discounting
        v_query:=v_query||' AND (select distinct "Team_code" from exec_mast where "comp_code"=m."Comp_code" and to_char("Exe_no")=m."Executive_code")='''||v_login_exec_team||'''';
    End if;
    v_query:=v_query||' group by m."Comp_code",a."Agency_Name",m."Package_code",m."date_time", m."Client_code",m."RO_No",m."RO_Date",m."Executive_code",m."RETAINER",
                    m."Card_rate",m."cio_booking_id",m."Bill_amount",m."Gross_amount",m."Page_prem",m.app_status,m."booked_by",m."Agency_pay",
                    m."Receipt_no",m."Ad_cat_code",m."Ad_cat_code",m."Color_code",m."Card_amount",m."Agrred_rate",m."Agreed_amount",
                    m."Ad_size_height",m."Ad_size_width",m.retainer,m."Executive_code",a."City_Code"
                    ORDER BY bookdate DESC,m."cio_booking_id"';
   
   --INSERT INTO TEST1(VSTRING,VSTRING2) VALUES('getapprovalRo_web ',V_QUERY);COMMIT;
   
    open P_Accounts for V_QUERY;
   
/*if flag ='A' then
    open P_Accounts for
    SELECT distinct a."Agency_Name" as "AGENCY",
    (select "Package_Name" from combin_mast where "Comp_Code"=compcode and "Combin_Code"=(
    case when instr('abcdef',',') >0 then substr(m."Package_code",1,instr(m."Package_code",',')-1) 
    else m."Package_code" end)) as "PACKAGE",
    case when dateformat='dd/mm/yyyy' then to_char(m."date_time",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."date_time",'yy/mm/dd')
    else to_char(m."date_time",'mm/dd/yy') end as "BOOKDATE",
    (select "Cust_Name" from cust_mast where "Comp_Code"=compcode and "Cust_Code"= m."Client_code") as "CLIENT",
    m."RO_No" as "RO_NO",
    case when dateformat='dd/mm/yyyy' then to_char(m."RO_Date",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."RO_Date",'yy/mm/dd')
    else to_char(m."RO_Date",'mm/dd/yy') end as "RODATE",
    (select "Exec_name" from exec_mast where  to_char("Exe_no") = m."Executive_code") as "EXECUTIVE",
    (select "Retain_Name" from retainermaster where "Comp_Code"=compcode and "Retain_Code"= m."RETAINER") as "RETAINER",
    m."Card_rate" as "CARD_RATE",Fn_Deviatio(m."Card_rate",m."Agrred_rate") as "DEVIATION",m."cio_booking_id" as "CIO_BOOKING_ID",
    m."Bill_amount" as "BILL_AMOUNT",m."Gross_amount" as "GROSS_AMOUNT",
    (select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=m."Page_prem") as "PAGEPERM",
    m.app_status as "APP_STATUS",m."booked_by" as "BOOKED_BY",
    (select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=m."Agency_pay") as "PAYMODE",
    m."Receipt_no" as "RECEIPT_NO",m."Ad_cat_code" as "AD_CAT_CODE",(select "Adv_Cat_Name" from adv_cat_mast where "Comp_Code"=m."Comp_code" and "Adv_Cat_Code"=m."Ad_cat_code") as "AD_CAT_NAME",
    m."Color_code" as "COLOR_CODE", m."Card_amount" as "CARD_AMOUNT",m."Agrred_rate" as "AGRRED_RATE",m."Agreed_amount" as "AGREED_AMOUNT",
    m."Ad_size_height" as "AD_SIZE_HEIGHT",m."Ad_size_width" as "AD_SIZE_WIDTH",(m."Ad_size_height"*m."Ad_size_width") as "SIZE_BOOK",
    min(i."Insert_Date") as "FIRST_INSDATE",max(i."Insert_Date") as "LAST_INSDATE"
        from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
    where m."Comp_code"=compcode and m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
    m."branch"=nvl(pbranch,m."branch") and m.app_status='Y'
    and (Fn_Deviatio(m."Card_rate",m."Agrred_rate") is not null OR Fn_chkSalesExec(m."Userid")='SE0' OR relauthreq = 'A')
    and m."Agency_sub_code" = nvl(agency,m."Agency_sub_code") and (m."Executive_code" = executive  OR executive IS NULL)
    and (m."Client_code" = client  OR client IS NULL) and m."date_time" between varfromdate and vartodate
    and m."cio_booking_id" = nvl(cioid,m."cio_booking_id")
    group by a."Agency_Name",m."Package_code",m."date_time", m."Client_code",m."RO_No",m."RO_Date",m."Executive_code",m."RETAINER",
    m."Card_rate",m."cio_booking_id",m."Bill_amount",m."Gross_amount",m."Page_prem",m.app_status,m."booked_by",m."Agency_pay",
    m."Receipt_no",m."Ad_cat_code",m."Ad_cat_code",m."Color_code",m."Card_amount",m."Agrred_rate",m."Agreed_amount",
    m."Ad_size_height",m."Ad_size_width"
    ORDER BY m."date_time" DESC,m."cio_booking_id";
elsif flag ='R' then
    open P_Accounts for
    SELECT distinct a."Agency_Name" as agency,
    (select "Package_Name" from combin_mast where "Comp_Code"=compcode and "Combin_Code"=(
    case when instr('abcdef',',') >0 then substr(m."Package_code",1,instr(m."Package_code",',')-1) 
    else m."Package_code" end)) as Package,
    case when dateformat='dd/mm/yyyy' then to_char(m."date_time",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."date_time",'yy/mm/dd')
    else to_char(m."date_time",'mm/dd/yy') end as bookdate,
    (select "Cust_Name" from cust_mast where "Comp_Code"=compcode and "Cust_Code"= m."Client_code") as client,
    m."RO_No",case when dateformat='dd/mm/yyyy' then to_char(m."RO_Date",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."RO_Date",'yy/mm/dd')
    else to_char(m."RO_Date",'mm/dd/yy') end as rodate,
    (select "Exec_name" from exec_mast where to_char("Exe_no") = m."Executive_code") as executive,
    (select "Retain_Name" from retainermaster where "Comp_Code"=compcode and "Retain_Code"= m."RETAINER") retainer,m."Card_rate" as "Card_rate",
    Fn_Deviatio(m."Card_rate",m."Agrred_rate") as deviation,m."cio_booking_id",m."Bill_amount" as "Bill_amount",m."Gross_amount" as "Gross_amount",
    (select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=m."Page_prem") as PAGEPERM,m.APP_STATUS as "APP_STATUS",m."booked_by" as "booked_by",
    (select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=m."Agency_pay") as "paymode",m."Receipt_no" "Receipt_no"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
    where m."Comp_code"=compcode and m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
    m."branch"=nvl(pbranch,m."branch") and m.app_status='N' 
    and (Fn_Deviatio(m."Card_rate",m."Agrred_rate") is not null OR Fn_chkSalesExec(m."Userid")='SE0' OR  RELAUTHREQ = 'A')
    AND (m."Agency_sub_code" = agency  OR agency IS NULL)
    AND (m."Executive_code" = executive  OR executive IS NULL)
    AND (m."Client_code" = client  OR client IS NULL)
    and m."date_time" between varfromdate and vartodate
    AND (m."cio_booking_id" = cioid  OR cioid IS NULL)
    ORDER BY m."date_time" DESC,m."cio_booking_id";
else
    open P_Accounts for
    SELECT distinct a."Agency_Name" as agency,
    (select "Package_Name" from combin_mast where "Comp_Code"=compcode and "Combin_Code"=(
    case when instr('abcdef',',') >0 then substr(m."Package_code",1,instr(m."Package_code",',')-1) 
    else m."Package_code" end)) as Package,
    case when dateformat='dd/mm/yyyy' then to_char(m."date_time",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."date_time",'yy/mm/dd')
    else to_char(m."date_time",'mm/dd/yy') end as bookdate,
    (select "Cust_Name" from cust_mast where "Comp_Code"=compcode and "Cust_Code"= m."Client_code") client,m."RO_No" as "RO_No",
    case when dateformat='dd/mm/yyyy' then to_char(m."RO_Date",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."RO_Date",'yy/mm/dd')
    else to_char(m."RO_Date",'mm/dd/yy') end as rodate,
    (select "Exec_name" from exec_mast where "Exe_no" = m."Executive_code") as executive,
    (select "Retain_Name" from retainermaster where "Comp_Code"=compcode and "Retain_Code"= m."RETAINER") retainer,m."Card_rate" as "Card_rate",
    Fn_Deviatio(m."Card_rate",m."Agrred_rate") as deviation,m."cio_booking_id",m."Bill_amount" as "Bill_amount",m."Gross_amount" as "Gross_amount",
    (select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=m."Page_prem") as "PAGEPERM",
    m.APP_STATUS as "APP_STATUS",m."booked_by" as "booked_by",
    (select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=m."Agency_pay") as "paymode",m."Receipt_no" as "Receipt_no"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
    where m."Comp_code"=compcode and m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
    m."branch"=nvl(pbranch,m."branch") and nvl(m.app_status,'#')!='Y' and nvl(m.app_status,'#')!='N' 
    and (Fn_Deviatio(m."Card_rate",m."Agrred_rate") is not null OR Fn_chkSalesExec(m."Userid")='SE0' OR  RELAUTHREQ = 'A')
    AND (m."Agency_sub_code" = agency  OR agency IS NULL)
    AND (m."Executive_code" = executive  OR executive IS NULL)
    AND (m."Client_code" = client  OR client IS NULL)
    and m."date_time" between varFromDate and varToDate
    AND (m."cio_booking_id" = cioid  OR cioid IS NULL)
    ORDER BY m."date_time" DESC,m."cio_booking_id" ;
end if;*/

End getapprovalRo_web;
/

//=========================== Start Srcipt ========================//










@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 28\03\2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@




@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 29\03\2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE ADCAPTION_INS_UPD_DEL 

   (PCOMP_CODE     IN VARCHAR2,
    PADTYPE_CODE   IN VARCHAR2,
    PCAPTION       IN VARCHAR2,
    PUSERID        IN VARCHAR2,
    PTRN_TYPE      IN VARCHAR2, --'I' For Insert, 'U' For Update, 'D' For Delete & 'E' For Execute
    PCAPTION_CODE  IN VARCHAR2, 
    PEXTRA1        IN VARCHAR2, 
    PEXTRA2        IN VARCHAR2, 
    PEXTRA3        IN VARCHAR2, 
    PEXTRA4        IN VARCHAR2
    ) 
AS

 vno           NUMBER (8);
BEGIN
  IF NVL(PTRN_TYPE,'?')='I' THEN
     SELECT MAX (TO_NUMBER (CAPTION_CODE)) + 1  INTO vno FROM CAPTION_MAST  WHERE PCOMP_CODE = PCOMP_CODE;
     IF nvl(vno,0) = 0 
     THEN
        vno :=1;
     END IF;
     INSERT INTO CAPTION_MAST   (COMP_CODE,AD_TYPE, CAPTION_CODE, CAPTION_NAME, USERID, CREATION_DATETIME)
                         VALUES (PCOMP_CODE,PADTYPE_CODE,vno,PCAPTION,PUSERID,SYSDATE);
  END IF;
  IF NVL(PTRN_TYPE,'?')='U' THEN
    UPDATE CAPTION_MAST  SET AD_TYPE=PADTYPE_CODE, CAPTION_NAME=PCAPTION WHERE  CAPTION_CODE=PCAPTION_CODE AND COMP_CODE=PCOMP_CODE;
                   
  END IF;
  IF NVL(PTRN_TYPE,'?')='D' THEN
     DELETE FROM CAPTION_MAST
        WHERE  COMP_CODE = PCOMP_CODE
           AND CAPTION_CODE = PCAPTION_CODE;

  END IF;
END;
/





@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 29\03\2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@






@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 30\03\2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@



//==================================== Start Procedure Script =======================//
CREATE OR REPLACE PROCEDURE websp_getmoduleper (
   comcode      IN       VARCHAR2,
   userid1      IN       VARCHAR2,
   p_accounts   OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT DISTINCT x.modulecode modulecode
                 FROM (SELECT DISTINCT modulecode
                                  FROM module_detaibuttonl
                                 WHERE "userid" = userid1
                                   AND "comp_code" = comcode
                                   AND modulecode IS NOT NULL
                                   AND NVL ("Button_id", '0') <> '0'
                       UNION
                       SELECT DISTINCT a.module_alias modulecode
                                  FROM module_mast a, module_user_rights b
                                 WHERE b.comp_code = comcode
                                   AND b.user_code = userid1
                                   AND a.module_id = b.module_id
                                   AND NVL (b.user_right, '0') <> '0') x;
END websp_getmoduleper;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE ad_bindcaption (
   pcompcode    IN       VARCHAR2,
   puserid      IN       VARCHAR2,
   pcaption     IN       VARCHAR2,
   pextra       IN       VARCHAR2,
   p_accounts   OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT caption_code, caption_name
        FROM caption_mast
       WHERE comp_code = pcompcode
         AND UPPER (caption_name) LIKE '%' || UPPER (pcaption) || '%';
END;
/



//==================================== End of Start Procedure Script =======================//




@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@kuldeep 30\03\2012@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@




//=========================================kuldeep 23/03/2012 ==================================//
CREATE OR REPLACE PROCEDURE WEBSP_BINDCIOIDNEW1(
FROMDATE            IN VARCHAR2,
TODATE              IN VARCHAR2,
DATE1               IN VARCHAR2,
PUBLICATION         IN VARCHAR2,
BOOKINGCENTER       IN VARCHAR2,
REVENUECENTER       IN VARCHAR2,
AGENCYTYPE          IN VARCHAR2,
PACKAGE1            IN VARCHAR2,
ADTYPE1             IN VARCHAR2,
AGENCY              IN VARCHAR2,
CLIENT              IN VARCHAR2,
BILLSTATUS          IN VARCHAR2,
RATE_AUDIT          IN VARCHAR2,
BILLMODE            IN VARCHAR2,
BILLCYCLE           IN VARCHAR2,
V_RETAINER_NAME     IN VARCHAR2,
V_EXECUTIVE_NAME    IN VARCHAR2,
V_BRANCH_NAME       IN VARCHAR2,
V_AD_CATEGORY       IN VARCHAR2,
V_DISTRICT          IN VARCHAR2,
V_TALUKA            IN VARCHAR2,
PCOMPCODE           IN  VARCHAR2,
P_BILLNO            IN VARCHAR2,
P_BILL_GEN_PRIOR    IN VARCHAR2,
P_CENTERLOGIN       IN VARCHAR2,
P_PUB_CENT_HO       IN VARCHAR2,
P_FMG_BILL          IN VARCHAR2,
P_SCHEME_TYPE       IN VARCHAR2,
PTO_BILL_NO         IN VARCHAR2,
P_UOM               IN VARCHAR2,
P_RECORDSET         OUT CUR_TYPE_NEW1.CURSOR_TYPE)

IS

query1 VARCHAR2(10000);

v_bill_criteria varchar2(10);

BEGIN
    if adtype1='DI0' then
        select disp_billing_criteria into v_bill_criteria from preferrences where "comp_code"=pcompcode;
    else
        select clsd_billing_criteria into v_bill_criteria from preferrences where "comp_code"=pcompcode;
    end if;
    
    IF(billstatus='3' AND rate_audit='n')
    THEN

      query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",

      nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where cust_mast."Cust_Code"=tbl_booking_mast."Client_code"),"Client_code") as "client",
      AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
      TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
       tbl_booking_insert.BILL_NO
       ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"  AND
       TBL_BOOKING_INSERT."Insert_Status"=''publish'' AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"' ;
    END IF;


     IF(billstatus='3' AND rate_audit='y')
    THEN

          query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
     nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where

    cust_mast."Cust_Code"=tbl_booking_mast."Client_code"),"Client_code") as "client",
          AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
          TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
           tbl_booking_insert.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"

          FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"  AND
           TBL_BOOKING_INSERT."Insert_Status"=''audit by rate'' AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"' ;
    END IF;

    IF(billstatus='1' AND rate_audit='y'AND billmode='2')
    THEN

     query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
     nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where

    cust_mast."Cust_Code"=tbl_booking_mast."Client_code"),"Client_code") as "client",
          AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
          TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
           tbl_booking_insert.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
    AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"  AND (TBL_BOOKING_INSERT."Insert_Status" =''AUDIT BY rate'' OR TBL_BOOKING_INSERT."Insert_Status"=''billed'')' ;
    END IF;

    IF(billstatus='1' AND rate_audit='n' AND billmode='2')
    THEN
     query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
          (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
          AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
          TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
           tbl_booking_insert.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
     AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"  AND (TBL_BOOKING_INSERT."Insert_Status" =''publish'' OR TBL_BOOKING_INSERT."Insert_Status"=''billed'')' ;
    END IF;

    IF(billstatus='1' AND rate_audit='n' AND (billmode='1' OR billmode='3'))
    THEN
     query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
          (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
          AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
          TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
          tbl_booking_insert.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
     AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"  AND (TBL_BOOKING_INSERT."Insert_Status"=''billed'')' ;
    END IF;

    IF(billstatus='1' AND rate_audit='y' AND (billmode='1' OR billmode='3'))
    THEN

     query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
          (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
          AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
          TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
          tbl_booking_insert.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
     AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"  AND (TBL_BOOKING_INSERT."Insert_Status"=''billed'')' ;
    END IF;

    IF(billstatus='3' AND rate_audit='n' AND (billmode='1' OR billmode='3'))
    THEN

     query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
          (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
          AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
          TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
          tbl_booking_insert.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
     AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"  AND (TBL_BOOKING_INSERT."Insert_Status"=''billed'')' ;
    END IF;

    IF(billstatus='3' AND rate_audit='y' AND (billmode='1' OR billmode='3'))
    THEN

     query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
          (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
          AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
          TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
          tbl_booking_insert.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
     AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"  AND (TBL_BOOKING_INSERT."Insert_Status"=''billed'')' ;
    END IF;

    IF(billstatus=2)
    THEN
     query1:=' SELECT DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id","No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code" AS "edition" ,
    (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
    AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
    TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS  "total",TBL_BOOKING_MAST."Bill_remarks",
    tbl_booking_insert.BILL_NO
    ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
    FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"  AND
     TBL_BOOKING_INSERT."Insert_Status"=''billed'' AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code" ';
    END IF;



    IF(billstatus='5')
    THEN

      query1:='SELECT  DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id", "No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code"  AS "edition",
      (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
      AGENCY_MAST."Agency_Name" AS "Agency",sum(TBL_BOOKING_INSERT."Gross_Rate") as "Gross_Rate",TBL_BOOKING_MAST."Trade_disc" AS "Commission",tbl_booking_insert."Insert_Date" as "pub_date",
      TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS "total",TBL_BOOKING_MAST."Bill_remarks",
      tbl_booking_insert.BILL_NO
      ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"  AND
       TBL_BOOKING_INSERT."Insert_Status"=''publish'' AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code"' ;
    END IF;


    IF(billstatus=6)
    THEN
     query1:=' SELECT DISTINCT  TBL_BOOKING_INSERT."Cio_Booking_Id","No_Insert" AS "no_of_insertion" ,TBL_BOOKING_MAST."Package_code" AS "edition" ,
    (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = TBL_BOOKING_MAST."Client_code") AS "client",
    AGENCY_MAST."Agency_Name" AS "Agency",
    TBL_BOOKING_INSERT."Insert_Status" AS "status",TBL_BOOKING_MAST."No_of_insertion" AS  "total",TBL_BOOKING_MAST."Bill_remarks",
    tbl_booking_insert.BILL_NO
    ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO) as "PrintCount"
    FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"  AND
     TBL_BOOKING_INSERT."Insert_Status"=''booked'' AND AGENCY_MAST."code_subcode"=TBL_BOOKING_MAST."Agency_sub_code" ';
    END IF;

    IF(v_retainer_name  IS NOT NULL)
    THEN
     query1:= query1 ||' and TBL_BOOKING_MAST ."RETAINER" ='''||v_retainer_name ||'''';
    END IF;




    IF(v_executive_name IS NOT NULL)
    THEN
     query1:= query1||' and TBL_BOOKING_MAST  ."Executive_code" ='''||v_executive_name ||'''';
    END IF;



    IF(v_branch_name  IS NOT NULL)
    THEN
     query1:= query1 ||' and TBL_BOOKING_MAST ."branch" ='''||v_branch_name ||'''';
    END IF;



    IF(v_ad_category  IS NOT NULL)
    THEN
     query1:= query1 ||' and TBL_BOOKING_MAST ."Ad_cat_code" ='''||v_ad_category||'''';
    END IF;


    IF(v_district  IS NOT NULL)
    THEN
     query1:= query1 ||' and TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."Dist_Code" ='''||v_district||''' or '''||v_district||''' is null)';
    END IF;



    IF(v_taluka IS NOT NULL)
    THEN
     query1:= query1||'  AND TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" from agency_mast where (AGENCY_MAST."Dist_Code"  in(select DIST_CODE from taluka_mast where   TALU_CODE='''||v_taluka||''' or '''||v_taluka||''' is null) )  AND AGENCY_MAST."Dist_Code"='''||v_district||''' OR '''||v_district||'''  IS NULL   )';
    END IF;

    if v_bill_criteria='A' then
        IF(billcycle IS NOT NULL)
        THEN
            query1:=query1 ||' AND AGENCY_MAST."BILL_FREQUENCY"='''||billcycle ||'''';
        END IF;
    elsif v_bill_criteria='R' then

        IF(billcycle IS NOT NULL)
        THEN
            query1:=query1 ||' AND TBL_BOOKING_MAST."Bill_cycle" ='''||billcycle ||'''';
        END IF;
    end if;
    
    IF(agency IS NOT NULL)
    THEN
    query1:=query1 ||' AND TBL_BOOKING_MAST."Agency_sub_code" ='''||agency ||'''';
    END IF;

    IF(client IS NOT NULL)
    THEN
    query1:=query1 ||' AND TBL_BOOKING_MAST."Client_code" ='''||client ||'''';
    END IF;


    IF(agencytype IS NOT NULL)
    THEN
    query1:=query1 ||' AND TBL_BOOKING_MAST."Agency_type"  ='''||trim(agencytype)||'''';
    END IF;
    IF(adtype1 IS NOT NULL)
    THEN
    query1:=query1 ||' AND TBL_BOOKING_MAST. "Ad_type_code" ='''||adtype1||''' ';
    END IF;


    IF(bookingcenter  IS NOT NULL)
    THEN

    query1:=query1 ||' AND TBL_BOOKING_MAST. "branch" ='''||bookingcenter||''' ';
    END IF;




    if (P_FMG_BILL !='Include')
    then

    query1:=query1 ||' AND tbl_booking_mast."Booking_type" not in (''2'',''4'',''5'')';

    end if;

    if(P_SCHEME_TYPE='EXCLUDE')
    THEN

    query1:=query1 ||' AND tbl_booking_INSERT ."Pai_Free_Ins"  in (''Y'')';

    END IF;




    IF(revenuecenter IS NOT NULL)
    THEN

    query1:=query1 ||' AND TBL_BOOKING_MAST. "branch" ='''||revenuecenter||''' ';
    END IF;

    IF(publication IS NOT NULL)
    THEN
    query1:=query1 ||'AND  TBL_BOOKING_INSERT."Publication_Code"='''||publication ||'''';
    END IF;

    if (P_BILLNO is not null) and (pto_bill_no is not null) then
       query1:=query1 ||'AND  tbl_booking_insert.BILL_NO between '''||P_BILLNO||''' and '''||pto_bill_no||'''';
    END IF;



    IF(fromdate IS NOT NULL AND todate IS NOT NULL )
    THEN
     query1:=query1 ||'  AND "Insert_Date" BETWEEN  '''||fromdate ||''' AND  '''||todate ||''' ';
    END IF;
    
    if (P_UOM is not null) then
       query1:=query1 ||'AND  tbl_booking_mast."Uom_code" = '''||P_UOM||'''';
    END IF;



    IF(PACKAGE1 IS NOT  NULL)
    THEN
    query1:=query1 ||' AND  TBL_BOOKING_INSERT."Edition" ='''||PACKAGE1 ||'''';
    END IF;

    query1:=query1 ||'group by TBL_BOOKING_INSERT."Cio_Booking_Id",tbl_booking_insert."No_Insert" ,TBL_BOOKING_MAST."Package_code"
     , AGENCY_MAST."Agency_Name",TBL_BOOKING_MAST."Trade_disc",TBL_BOOKING_INSERT."Insert_Status",TBL_BOOKING_MAST."No_of_insertion"
     ,TBL_BOOKING_MAST."Bill_remarks",TBL_BOOKING_MAST."Client_code",tbl_booking_insert.BILL_NO, tbl_booking_insert."Comp_Code",tbl_booking_insert."Insert_Date"  order by TBL_BOOKING_INSERT."Cio_Booking_Id", tbl_booking_insert."No_Insert"';


 delete from ank_search_new;
insert into ank_search_new values(query1);
commit;



 OPEN p_recordset FOR

 query1;

END ;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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

CREATE OR REPLACE PACKAGE BODY ERPTEST.bindaudit IS
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
    extra1          in varchar2,--for UOM
    extra2          in varchar2,
    extra3          in varchar2,
    extra4          in varchar2,
    P_ACCOUNT       OUT T_ACCOUNT_CURSOR)
AS

v_branch1       varchar2(50);
v_branch2       varchar2(50);
v_approval_req  varchar2(1);
BEGIN
    /* INSERT INTO test1(vstring)VALUES (   'fromdate '|| fromdate|| ' todate '|| todate|| ' date1 '|| date1|| ' BRANCH1 '|| branch1|| ' Adtype '|| adtype|| ' audittype '|| audittype|| ' branch2 '|| branch2|| ' v_Cat '|| v_cat|| ' v_userid '|| v_userid);COMMIT;*/
    If branch1 = 'All' then
        v_branch1 := null;
    End if;
    
    If branch2 = 'All' then
        v_branch2 := null;
    End if;
    v_approval_req:='N';
    
    select relauthreqon into v_approval_req from preferrences where "comp_code"=comp_code;
    
    IF audittype = 'audit' THEN
        OPEN p_account FOR
        SELECT distinct m."cio_booking_id" as "cio_booking_id",
        NVL ((SELECT distinct  "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),
        m."Client_code") AS "Client_code",
        m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",m."Receipt_no" as "Receipt_no",
        (SELECT distinct "File_Name" FROM tbl_booking_insert
        WHERE "Cio_Booking_Id" =m."cio_booking_id" AND "File_Name" IS NOT NULL AND ROWNUM <= 1) AS "FILENAME",
        CASE date1 WHEN 'mm/dd/yyyy' THEN TO_CHAR(m."Creation_datetime",'mm/dd/yyyy')
            WHEN 'dd/mm/yyyy' THEN TO_CHAR (m."Creation_datetime", 'dd/mm/yyyy')
            WHEN 'yyyy/mm/dd' THEN TO_CHAR (m."Creation_datetime", 'yyyy/mm/dd')
        END AS "Creation_datetime",m.ATTACHMENT1 as ATTACHMENT,
        AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'A') as "Agency_Remark",
        AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'C') as "Client_Remark",
        case when v_approval_req='N' then 'Y' else 
            case when nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)=0 then 'Y' else nvl(m.app_status,'N') end 
        end as "APPROVAL_FLAG"
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
        and m."Uom_code"=nvl(extra1,m."Uom_code")
        order by "cio_booking_id";
    END IF;

    IF audittype = 'unaudit' or audittype is null THEN
        OPEN p_account FOR
            SELECT distinct m."cio_booking_id" as "cio_booking_id",
            NVL ((SELECT distinct "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),
            m."Client_code") AS "Client_code",
            m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",m."Receipt_no" as "Receipt_no",
            (SELECT distinct  "File_Name" FROM tbl_booking_insert
            WHERE "Cio_Booking_Id" =m."cio_booking_id"
            AND "File_Name" IS NOT NULL
            AND ROWNUM <= 1) AS "FILENAME",
            CASE date1 WHEN 'mm/dd/yyyy' THEN TO_CHAR(m."Creation_datetime",'mm/dd/yyyy')
                WHEN 'dd/mm/yyyy' THEN TO_CHAR (m."Creation_datetime", 'dd/mm/yyyy')
                WHEN 'yyyy/mm/dd' THEN TO_CHAR (m."Creation_datetime", 'yyyy/mm/dd')
            END AS "Creation_datetime",m.ATTACHMENT1 as ATTACHMENT,
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'A') as "Agency_Remark",
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'C') as "Client_Remark",
            case when v_approval_req='N' then 'Y' else 
                case when nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)=0 then 'Y' else nvl(m.app_status,'N') end 
            end as "APPROVAL_FLAG"
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
            AND m."Uom_code"=nvl(extra1,m."Uom_code")
            order by "cio_booking_id";
    END IF;

    IF audittype = 'modified' THEN
        OPEN p_account FOR
            SELECT distinct m."cio_booking_id" as "cio_booking_id",
            NVL ((SELECT distinct "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),
            m."Client_code") AS "Client_code",
            m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",m."Receipt_no" as "Receipt_no",
            (SELECT distinct  "File_Name" FROM tbl_booking_insert
            WHERE "Cio_Booking_Id" =m."cio_booking_id"
            AND "File_Name" IS NOT NULL
            AND ROWNUM <= 1) AS "FILENAME",
            CASE date1 WHEN 'mm/dd/yyyy' THEN TO_CHAR(m."Creation_datetime",'mm/dd/yyyy')
                WHEN 'dd/mm/yyyy' THEN TO_CHAR (m."Creation_datetime", 'dd/mm/yyyy')
                WHEN 'yyyy/mm/dd' THEN TO_CHAR (m."Creation_datetime", 'yyyy/mm/dd')
            END AS "Creation_datetime",m.ATTACHMENT1 as ATTACHMENT,
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'A') as "Agency_Remark",
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'C') as "Client_Remark",
            case when v_approval_req='N' then 'Y' else 
                case when nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)=0 then 'Y' else nvl(m.app_status,'N') end 
            end as "APPROVAL_FLAG"
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
            AND m."Uom_code"=nvl(extra1,m."Uom_code")
            order by "cio_booking_id";
    END IF;

   END bindaudit_p;
END bindaudit;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE websp_bindaudit IS
   TYPE t_accounts_cursor IS REF CURSOR;

PROCEDURE websp_bindaudit_p(
    fromdate        IN varchar2,
    todate          IN varchar2,
    date1           IN varchar2,
    branch          IN varchar2,
    adtype          IN varchar2,
    publication     in varchar2,
    pub_cent        in varchar2,
    edition         in varchar2,
    agency          in varchar2,
    client          in varchar2,
    branchnew       in varchar2,
    v_retainer      in varchar2,
    v_executive     in varchar2,
    v_supplement    in varchar2,
    v_insert_status in varchar2,
    puom_code       in varchar2,
    p_accounts      OUT t_accounts_cursor);
END websp_bindaudit;
/

CREATE OR REPLACE PACKAGE BODY websp_bindaudit
IS
PROCEDURE websp_bindaudit_p(
    fromdate        IN varchar2,
    todate          IN varchar2,
    date1           IN varchar2,
    branch          IN varchar2,
    adtype          IN varchar2,
    publication     in varchar2,
    pub_cent        in varchar2,
    edition         in varchar2,
    agency          in varchar2,
    client          in varchar2,
    branchnew       in varchar2,
    v_retainer      in varchar2,
    v_executive     in varchar2,
    v_supplement    in varchar2,
    v_insert_status in varchar2,
    puom_code       in varchar2,
    p_accounts      OUT t_accounts_cursor)
IS

query1 VARCHAR2(10000);

BEGIN

query1:='select tbl_booking_insert."Cio_Booking_Id" as "cio_booking_id",
"No_Insert" as "no_of_insertion" ,
"Edition"  as "edition",
nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where  cust_mast."Cust_Code"=tbl_booking_mast."Client_code"),"Client_code") as "client",
AGENCY_MAST."Agency_Name" as "Agency",
tbl_booking_mast."Gross_amount" as "gross_amount",
tbl_booking_insert ."Insert_Status" as "status",
CASE ''date1''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("Insert_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("Insert_Date",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("Insert_Date",''yyyy/mm/dd'')  END AS "Ins.date",
tbl_booking_mast."RO_No",
COL_MAST."Col_Alias" as "Col_Name",
tbl_booking_insert ."Size_Book",
tbl_booking_insert."Agreed_Rate",
tbl_booking_insert."Bill_Amt",
tbl_booking_insert."Height", "Width"
from tbl_booking_insert,
tbl_booking_mast,
COL_MAST,
agency_mast where tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id"  and
 TBL_BOOKING_MAST."Color_code"=COL_MAST."Col_Code"  AND
 agency_mast."code_subcode"=tbl_booking_mast."Agency_sub_code"';



/*and "Insert_Date"  between fromdate and todate and "Ad_type_code"='''||adtype||'''

AND  (TBL_BOOKING_INSERT."Publication_Code"=publication OR publication IS NULL)
AND (TBL_BOOKING_INSERT."Pub_Cent_Code" =pub_cent OR pub_cent IS NULL)
AND (TBL_BOOKING_INSERT  ."Edition_Code"=edition OR  edition IS NULL)
AND (TBL_BOOKING_MAST."Agency_code" =agency OR agency  IS NULL)
AND (TBL_BOOKING_MAST."Client_code" =client OR client  IS NULL)
AND (TBL_BOOKING_MAST ."branch" =branchnew OR branchnew  IS NULL)
AND (TBL_BOOKING_insert."Supp_Code" =v_supplement OR v_supplement  IS NULL)
AND (TBL_BOOKING_MAST ."RETAINER" =v_retainer OR v_retainer  IS NULL)
AND (TBL_BOOKING_MAST  ."Executive_code" =v_executive OR v_executive  IS NULL)';*/


if(v_insert_status is not null) then
    query1:=query1 ||' AND TBL_BOOKING_insert."Insert_Status" ='''||v_insert_status||''' ';
end if;

if(v_insert_status is null) then
    query1:=query1 ||' AND TBL_BOOKING_insert."Insert_Status" in (''publish'',''audit by rate'') ';
end if;

IF(v_retainer   IS NOT NULL) THEN
    query1:=query1||'  and tbl_booking_mast."RETAINER"='''||v_retainer ||'''';
END IF;


IF(v_executive  IS NOT NULL) THEN
    query1:=query1||'  and tbl_booking_mast."Executive_code"='''||v_executive||'''';
END IF;


IF(v_supplement  IS NOT NULL) THEN
    query1:=query1||'  and TBL_BOOKING_insert."Supp_Code"='''||v_supplement||'''';
END IF;

IF(branchnew  IS NOT NULL) THEN
    query1:=query1||'  and tbl_booking_mast."branch"='''||branchnew||'''';
END IF;

IF(client IS NOT NULL) THEN
    query1:=query1||'  and tbl_booking_mast."Client_code"='''||client||'''';
END IF;


IF(pub_cent IS NOT NULL) THEN
    query1:=query1||'  and tbl_booking_insert."Pub_Cent_Code"='''||pub_cent||'''';
END IF;


IF(agency IS NOT NULL) THEN
    query1:=query1 ||' and TBL_BOOKING_MAST."Agency_code" ='''||agency ||'''';
END IF;


IF(publication IS NOT NULL) THEN
    query1:=query1||' and  TBL_BOOKING_insert."Publication_Code"='''||publication||'''';
END IF;

IF(adtype IS NOT NULL) THEN
    query1:=query1 || ' and TBL_BOOKING_MAST."Ad_type_code" ='''||adtype||'''';
END IF;

IF(fromdate IS NOT NULL AND todate IS NOT NULL ) THEN
    query1:=query1||' and "Insert_Date" between  '''||fromdate ||''' and  '''||todate||''' ';
END IF;

IF(edition IS NOT NULL) THEN
    query1:=query1||'  and tbl_booking_insert."Edition_Code"='''||edition||'''';
END IF;

IF(puom_code IS NOT NULL) THEN
    query1:=query1||'  and tbl_booking_mast."Uom_code"='''||puom_code||'''';
END IF;


query1:=query1||'  order by tbl_booking_insert."Cio_Booking_Id"';

OPEN p_accounts  FOR
query1;

--delete from ANK_SEARCH ;iNSERT INTO ANK_SEARCH VALUES(query1);


   END websp_bindaudit_p;
END websp_bindaudit;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
ALTER TABLE AD_OUTSTAND_LOG
MODIFY(CHNO VARCHAR2(50 BYTE));
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE Bill_Saveinsert(
    orderno1        IN VARCHAR2,
    invoice1        IN VARCHAR2,
    amountforvat    IN NUMBER ,
    amt3            IN NUMBER,
    boxchg1         IN NUMBER,
    insnum_cou      IN NUMBER,
    doctyp          IN VARCHAR2,
    maxinsert       IN VARCHAR2,
    chk_billtype    in varchar2)
IS

pubcode             VARCHAR2(5);
pub_cent_code       VARCHAR2(8000);
branch              VARCHAR2(8);
ro_num              VARCHAR2(40);
ro_date             DATE;
client_code         VARCHAR2(70);
client_name         VARCHAR2(70);
insert_date         DATE;
v_comp_code         VARCHAR2(8000);
userid              VARCHAR2(25);
package_code        VARCHAR2(8000);
v_agency_sub_code   VARCHAR2(50);
colour_code         VARCHAR2(3);
noofinsert          NUMBER;
bildt               DATE;
v_agcode            VARCHAR2(50);
v_cod_subcode       VARCHAR2(50);
rate_code           varchar2(100);
adcat_v             varchar2(20);

adsubcat_v          varchar2(20);
bl_remarks_v        varchar2(40);
ag_comm_v           varchar2(50);
trade_disc          number;
bill_rmk_v          varchar2(500);
region_v            varchar2(10);
retainer_v          varchar2(10);
cont_name           varchar2(100);
cont_type           varchar2(100);
cont_rate           varchar2(100);
exe_code            varchar2(100);

special_disc        varchar2(100);
space_disc          varchar2(100);
bill_pay            varchar2(100);
---------15DEC
scheme_type         varchar2(100);
revcenter           varchar2(100);
ro_status           varchar2(100);
page_type           varchar2(100);
booking_type        varchar2(100);
prod_code           varchar2(200);
page_no             varchar2(200);
page_position       varchar2(8);
billremark          varchar2(500);

bill_date_new       date;
v_rcptno            varchar2(50);

v_BK_AGCODE         varchar2(20);
v_BK_AGSUBCODE      varchar2(20);
acagency_v          varchar2(20);
v_branch            varchar2(100);
V_REC_EXISTS        number(3);
 v_rcptdt           date;
 v_ad_type          varchar2(10);
 v_Ad_Cat           varchar2(20);
v_Ad_Sub_Cat        varchar2(20);


---------15DEC


   cursor c1 is
   select "Comp_code","RO_No","RO_Date","Color_code","Agency_sub_code" ,"Client_code","Trade_disc","No_of_insertion" ,"RETAINER","Contract_name","Contract_type", "Contract_rate",
    "Special_discount","Space_discount","Bill_pay","Executive_code","Scheme_type_code","Revenue_center",
    "ro_status","Page_type_code","Booking_type","Product_code","Page_no","Page_position_code","Bill_remarks","branch","date_time","Receipt_no","Ad_type_code"
   from tbl_booking_mast where"cio_booking_id"=orderno1;
BEGIN

     open c1;
     fetch c1 into v_comp_code,ro_num,ro_date,colour_code,v_agency_sub_code,client_code,trade_disc,noofinsert,retainer_v,cont_name,cont_type ,cont_rate,
                         special_disc,space_disc,Bill_pay ,exe_code,scheme_type,revcenter,
                   ro_status,page_type,booking_type,prod_code,page_no,page_position,billremark,v_branch,v_rcptdt,v_rcptno,v_ad_type;
     close c1;


/*if(chk_billtype ='classifed' ) then
    select "Insertion_date" into bill_date_new from tbl_booking_mast where "cio_booking_id"=orderno1;
else*/
    select distinct min("Insert_Date"),min("Insert_Date"),min("Publication_Code"),min("Ad_Cat"),min("Ad_Sub_Cat")  
    into  bill_date_new,insert_date,pubcode,v_ad_cat,v_ad_sub_cat from tbl_booking_insert where "Cio_Booking_Id"=orderno1 and 
    "No_Insert"=maxinsert and "Insert_Date" is not null;
--end if;

select distinct "Branch_Code" into  branch from branch_mst where "Comp_Code"=v_comp_code and "Branch_Code"=v_branch;

begin
   select distinct  "Agency_Code","SUB_Agency_Code","acagency" into v_agcode,v_cod_subcode,acagency_v  from agency_mast
    where "Comp_Code"=v_comp_code and "code_subcode" =v_agency_sub_code ;
exception when no_data_found then
   null;
end;

begin
   select distinct  "Cust_Name" into client_name from cust_mast where "Comp_Code"=v_comp_code and "Cust_Code"=client_code;
exception when no_data_found then
   client_name:=null;
end;

begin
select  distinct "Userid" into userid from tbl_booking_insert where "Cio_Booking_Id"=orderno1;
exception when no_data_found then
   userid:=null;
end;

v_BK_AGCODE        :=v_agcode;
v_BK_AGSUBCODE    :=v_cod_subcode;

IF acagency_v IS NOT NULL THEN
  SELECT COUNT(*) INTO V_REC_EXISTS FROM AGENCY_MAST WHERE "Comp_Code"=v_comp_code and "code_subcode" =v_agcode||acagency_v;

  IF NVL(V_REC_EXISTS,0)>0 THEN
     v_agency_sub_code:=v_agcode||acagency_v;
     v_cod_subcode    :=acagency_v;
  END IF;
END IF;

INSERT INTO AD_BILLS ("UNIT","IDNUM","AGCODE","BKFOR","BILDT","BILNO","BILLAMT","GROSS_AMT","RONUM","RODATE","CLIENTCD","CLIENTNAME","COLOUR","BOXCHRG","INSNUM","INSDATE","USRID","NOOFINSRT","AG_MAIN_CODE", "AG_SUB_CODE","DISCOUNT",REGION_CODE_V,RETAINER_CODE,"PRIPUB","CONTRACT_NAME","CONTRACT_TYPE","CONTRACT_RATE","EXECUTIVE_NAME","OVRDDISC","SPACEDISC","BILL_PAY" ,SCHEME,REVENUE_CENTER,RO_STATUS,PAGE_TYPE,BOOKING_TYPE,PRIPROCTG,PAGENUM,PAGE_POST,BILL_RMRK,comp_code_v,BK_AGCODE, BK_AGSUBCODE,RCPTNO,RCPTDT,AD_TYPE,PRIADCTG, SECADCTG)
VALUES(branch ,orderno1,v_agency_sub_code,branch,TRUNC(bill_date_new),invoice1,amountforvat,amt3,ro_num,ro_date,client_code,client_name,colour_code,boxchg1,maxinsert,TRUNC(insert_date),userid,insnum_cou,v_agcode,v_cod_subcode,trade_disc,region_v,retainer_v,pubcode,cont_name,cont_type,cont_rate,exe_code,special_disc,space_disc,Bill_pay,scheme_type,revcenter,ro_status,page_type,booking_type,prod_code,page_no,page_position,billremark,v_comp_code,v_BK_AGCODE,v_BK_AGSUBCODE,v_rcptno,v_rcptdt,v_ad_type,v_Ad_Cat,v_Ad_Sub_Cat );


INSERT INTO AD_OUTSTAND("UNIT","AGCODE","PRIPUB","BKFOR","BILLNO","AMOUNT","NOOFINSRT","INSDATE","COMP_CODE","USERID","CREATION_DATETIME","DOCTYPE","BILLDT" ,"AG_MAIN_CODE", "AG_SUB_CODE", "REMARK",BK_AGCODE, BK_AGSUBCODE,RECEIPT_NO,RETAINER_CODE, EXEC_CODE,CHNO, CHDT,BANK,AD_TYPE,PRIPROCTG)
VALUES(branch,v_agency_sub_code,pubcode,branch,invoice1,amountforvat,noofinsert,TRUNC(insert_date),v_comp_code,userid,TRUNC(SYSDATE),doctyp,TRUNC(bill_date_new),v_agcode,v_cod_subcode,bill_rmk_v,v_BK_AGCODE,v_BK_AGSUBCODE,orderno1,retainer_v,exe_code,ro_num,ro_date,client_code,v_ad_type,v_Ad_Cat);

END Bill_Saveinsert;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//=========================================== kuldeep 23/03/2012 End of Script==================================//


//==================r o file========================= ankit ====7098==============================//


CREATE OR REPLACE procedure ad_ro_filing
(pcompcode      in varchar2,
ppaymode        in varchar2,
ptodate         in varchar2,
pfromdate       in varchar2,
pclient         in varchar2,
ptaluka         in varchar2,
pagency         in varchar2,
ppcenter        in varchar2,
pexename        in varchar2,
pdistrict       in varchar2,
pretainer       in varchar2,
pbranch         in varchar2,
prodocstatus    in varchar2,
pdateformate    in varchar2,
pbookingid      in varchar2,
prono           in varchar2,
p_accounts      OUT Cur_Type_New1.cursor_type)
is

v_frdt date;
v_todt date;
begin

    v_frdt:=to_date(pfromdate,''''||pdateformate||'''');
    v_todt:=to_date(ptodate,''''||pdateformate||'''');
    if prodocstatus is null then
        open p_accounts for
        select distinct a."branch" branch_name ,a."cio_booking_id",a."RO_No" as "Agency R.o.No",a."RO_Date",b."Agency_Name" as "Agency Name",
        nvl((select cust_mast."Cust_Name" from cust_mast where cust_mast."Cust_Code"=a."Client_code"),a."Client_code") as "Client Name","Ad_type_code" ,a.RODOCSTATUS
        from tbl_booking_mast a,agency_mast b,pub_cent_mast c,branch_mst d
        where a."Comp_code"=pcompcode and a."Comp_code"=b."Comp_Code" and b."code_subcode"=a."Agency_sub_code" and 
        a."branch"=d."Branch_Code" and c."Pub_cent_Code"=d."pub_center" and d."Branch_Code"=nvl(pbranch,d."Branch_Code") and
        c."Pub_cent_Code"=nvl(ppcenter,c."Pub_cent_Code") and a."date_time">=v_frdt and a."date_time"<=v_todt and
        a."Agency_sub_code"=nvl(pagency,a."Agency_sub_code")
         and  (a."Client_code"=pclient or pclient is null) 
        and  (a."cio_booking_id"=pbookingid or pbookingid is null)
         and  (a."RO_No"=prono or prono is null) 
        and 
        b."Dist_Code"=nvl(pdistrict,b."Dist_Code") and (b.taluka=ptaluka or ptaluka is null) and 
        (a."Bill_pay"=ppaymode or ppaymode is null) and (a."Executive_code"=pexename or pexename is null) and
        (a.RETAINER=pretainer or pretainer is null) and a.RODOCSTATUS is null
        order by branch_name,"cio_booking_id";
     elsif prodocstatus='A' then
        open p_accounts for
        select distinct a."branch" branch_name ,a."cio_booking_id",a."RO_No" as "Agency R.o.No",a."RO_Date",b."Agency_Name" as "Agency Name",
        nvl((select cust_mast."Cust_Name" from cust_mast where cust_mast."Cust_Code"=a."Client_code"),a."Client_code") as "Client Name","Ad_type_code" ,a.RODOCSTATUS
        from tbl_booking_mast a,agency_mast b,pub_cent_mast c,branch_mst d
        where a."Comp_code"=pcompcode and a."Comp_code"=b."Comp_Code" and b."code_subcode"=a."Agency_sub_code" and 
        a."branch"=d."Branch_Code" and c."Pub_cent_Code"=d."pub_center" and d."Branch_Code"=nvl(pbranch,d."Branch_Code") and
        c."Pub_cent_Code"=nvl(ppcenter,c."Pub_cent_Code") and a."date_time">=v_frdt and a."date_time"<=v_todt and
        a."Agency_sub_code"=nvl(pagency,a."Agency_sub_code")and  (a."Client_code"=pclient or pclient is null)
          and  (a."cio_booking_id"=pbookingid or pbookingid is null)
         and  (a."RO_No"=prono or prono is null)  
        and 
        b."Dist_Code"=nvl(pdistrict,b."Dist_Code")  and (b.taluka=ptaluka or ptaluka is null) and 
        (a."Bill_pay"=ppaymode or ppaymode is null) and (a."Executive_code"=pexename or pexename is null) and
        (a.RETAINER=pretainer or pretainer is null) 
        order by branch_name,"cio_booking_id";     
     else
        open p_accounts for
        select distinct a."branch" branch_name ,a."cio_booking_id",a."RO_No" as "Agency R.o.No",a."RO_Date",b."Agency_Name" as "Agency Name",
        nvl((select cust_mast."Cust_Name" from cust_mast where cust_mast."Cust_Code"=a."Client_code"),a."Client_code") as "Client Name","Ad_type_code" ,a.RODOCSTATUS
        from tbl_booking_mast a,agency_mast b,pub_cent_mast c,branch_mst d
        where a."Comp_code"=pcompcode and a."Comp_code"=b."Comp_Code" and b."code_subcode"=a."Agency_sub_code" and 
        a."branch"=d."Branch_Code" and c."Pub_cent_Code"=d."pub_center" and d."Branch_Code"=nvl(pbranch,d."Branch_Code") and
        c."Pub_cent_Code"=nvl(ppcenter,c."Pub_cent_Code") and a."date_time">=v_frdt and a."date_time"<=v_todt and
        a."Agency_sub_code"=nvl(pagency,a."Agency_sub_code") and  (a."Client_code"=pclient or pclient is null)
          and  (a."cio_booking_id"=pbookingid or pbookingid is null)
         and  (a."RO_No"=prono or prono is null) 
         and 
        b."Dist_Code"=nvl(pdistrict,b."Dist_Code") and (b.taluka=ptaluka or ptaluka is null) and 
        (a."Bill_pay"=ppaymode or ppaymode is null) and (a."Executive_code"=pexename or pexename is null) and
        (a.RETAINER=pretainer or pretainer is null) and a.RODOCSTATUS=prodocstatus
        order by branch_name,"cio_booking_id";     
     end if;    

end;
/

//==================r o file=========end================ ankit ====7098==============================//




//===========================Start================ Avinash ====7030======03-apr2012 ========================//

CREATE OR REPLACE procedure getdistrict(
compcode in varchar2,
userid in varchar2,
pextra1 in varchar2,
 p_Accounts      out cur_type_new1.cursor_type) AS

BEGIN


Open P_Accounts For
select "Dist_Name","Dist_Code" from dist_mst where "Comp_Code"=compcode 
  and (
  (upper("Dist_Name") like upper(pextra1)||'%') or (pextra1 is null))

 order by "Dist_Code";
 
 END;





//===========================End================ Avinash ====7030======03-apr2012 ========================//



============================Start==============Avinash====7050========================

CREATE OR REPLACE procedure HT18JULY.rpt_booking_report(
    pagency_code    in varchar2,
    pclient_code    in varchar2,
    pfrom_date      in varchar2,
    pto_date        in varchar2,
    pdateformat     in varchar2,
    ppublication    in varchar2,
    pedition        in varchar2,
    ppub_center     in varchar2,
    pbranch         in varchar2,
    pcompcode       in varchar2,
    puserid         in varchar2,
    chk_access      in varchar2,
    pagency_type    in varchar2,
    pextra1         in varchar2,
    pextra2         in varchar2,
    p_accounts      OUT Cur_Type_New1.cursor_type)
is 
query1 varchar2(8000);
v_frdt date;
v_todt date;
    cursor c1 is
    select a."cio_booking_id" as "BOOKING_ID",c."Agency_Name" AS "AGENCY",
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE a."Comp_code"=CUST_MAST."Comp_Code" AND "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT", 
    "Caption" AS "CAPTION","Key_no" AS "KEY",b."Height" AS "Depth",b."Width"   AS "Width",round(b."Size_Book",2) AS "Area",
    b."Col_Code" as COLOR,b."Page_No" as "Page_No",
    NVL((select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") ,(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER )) as "EXE_RET",
    a."Card_rate" as "CARDRATE",A."Agrred_rate" as "AGGRATE",
    NVL(b."Gross_Rate",'0') as "GROSSAMT",NVL(a."Trade_disc",'0' )as "AGENCYTD(%)",
    NVL(a."ADD_AGENCY_COMM",'0') as  "AgencyAddlTD(%)",
    --CASHDISCOUNT as "Cash_Disc",
    0 as "Cash_Disc",
    NVL(b."Bill_Amt",'0') as "BILLAMT",(select "Comp_Name" from comp_mst where comp_mst."Comp_Code"=a."Comp_code") comp_name
    from tbl_booking_mast a,tbl_booking_insert b,agency_mast c
    WHERE a."Comp_code"=pcompcode AND
    a."Agency_sub_code"=c."code_subcode" AND a."cio_booking_id"=b."Cio_Booking_Id"  and
    ((b."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access='1')
    or (chk_access='0') ) and a."date_time" between v_frdt and  v_todt and (a."Agency_code" =  pagency_code or pagency_code is null) and (a."Client_code"=pclient_code or pclient_code is null)
    and (b."Publication_Code"=ppublication or ppublication is null) and (b."Pub_Cent_Code"=ppub_center or ppub_center is null) and 
    (b."Edition_Code"=pedition or pedition is null) and (a."branch"=pbranch or pbranch is null); 
begin

--insert into test1(vstring,vstring2) values('rpt_booking_report ','pdateformat '||pdateformat||' pfrom_date '||pfrom_date||' pto_date '||pto_date);commit;

v_frdt :=to_date(pfrom_date,''''||pdateformat||'''');
v_todt :=to_date(pto_date,''''||pdateformat||'''');
    /*open c1;
    loop
        fetch c1 into v1;
        exit when c1%notfound;
        
        
        
    end loop;
    close c1;*/    


query1:=query1|| 'select a."cio_booking_id" as "BOOKING_ID",
c."Agency_Name" AS "AGENCY",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE a."Comp_code"=CUST_MAST."Comp_Code" AND "Cust_Code"="Client_code"),"Client_code")  AS "CLIENT", 
"Caption" AS "CAPTION",
"Key_no" AS "KEY",
b."Height" AS "Depth",
b."Width"   AS "Width",
round(b."Size_Book",2) AS "Area",
/*(select col_mast."Col_Alias" from col_mast where b."Col_Code" =col_mast."Col_Code")*/ b."Col_Code" as COLOR,
b."Page_No" as "Page_No",
NVL((select EXEC_MAST."Exec_name" from exec_mast where a."Executive_code"=exec_mast."Exe_no") ,(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=a.RETAINER )) as "EXE_RET",
a."Card_rate" as "CARDRATE",
A."Agrred_rate" as "AGGRATE",
NVL(b."Gross_Rate",''0'') as "GROSSAMT",
NVL(a."Trade_disc",''0'' )as "AGENCYTD(%)",
NVL(a."ADD_AGENCY_COMM",''0'') as  "AgencyAddlTD(%)",
--CASHDISCOUNT as "Cash_Disc",
0 as "Cash_Disc",
NVL(b."Bill_Amt",''0'') as "BILLAMT",(select "Comp_Name" from comp_mst where comp_mst."Comp_Code"=a."Comp_code") comp_name
from tbl_booking_mast a,tbl_booking_insert b,agency_mast c
WHERE a."Comp_code"='''||pcompcode||''' AND
a."Agency_sub_code"=c."code_subcode" AND
a."cio_booking_id"=b."Cio_Booking_Id"  and
 ((b."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') )';

IF(pfrom_date IS NOT NULL AND pto_date IS NOT NULL)
then
query1:=query1||' and a."date_time" between  '''||v_frdt ||''' and  '''||v_todt||''' ';
END if;

IF(pagency_code IS NOT NULL )
then
query1:=query1||' and a."Agency_code" =  '''||pagency_code||''' ';
END if;

IF(pclient_code IS NOT NULL )
then
query1:=query1||' and a."Client_code"='''||pclient_code ||'''';
END if;

IF(ppublication IS NOT NULL )
then
query1:=query1||' and  b."Publication_Code"='''||ppublication||'''';
END if;

IF(ppub_center IS NOT NULL )
then
query1:=query1||'  and b."Pub_Cent_Code"='''||ppub_center||'''';
END if;

IF(pedition IS NOT NULL )
then
query1:=query1||'  and b."Edition_Code"='''||pedition||'''';
END if;

IF(pbranch IS NOT NULL )
then
query1:=query1||'  and a."branch"='''||pbranch||'''';
END if;

DELETE FROM SEARCHTBL;
INSERT INTO SEARCHTBL VALUES(query1);
COMMIT;

open p_accounts for 
query1;

end rpt_booking_report;
/


============================End==============Avinash====7050========================
////////////////////////////billing procedure changes for bkfor
CREATE OR REPLACE procedure det_monthly_new(
    orderno1        in varchar2,
    invoice1        in varchar2,
    amountforvat    in number ,
    boxchg1         in number,
    noofinsert      in number ,
    edition_name    in varchar2,
    todate          in date,
    v_insert_id     in varchar2)
  is

 pubcode        varchar2(50);
 pub_cent_code  varchar2(50);
 branch         varchar2(100);
 ro_num         varchar2(100);
 ro_date        date;
 client_code    tbl_booking_mast."Client_code"%type;
 client_name    varchar2(150);
 insert_date    date;
 v_comp_code    varchar2(20);
 userid         varchar2(50);
 package_code_v varchar2(500);
 colour_code    varchar2(30);
 ad_catv        varchar2(50);
 ad_subcatv     varchar2(50);
 rate_codev     varchar2(50);
 v_agcode       varchar2(40);
 v_cod_subcode  varchar2(30);
 v_agency_sub_code  varchar2(40);
 box_nov        varchar2(40);
 receipt_nov    varchar2(40);
 edition_codev  varchar2(30);
 edition_v      varchar2(500);
 supp_code_v    varchar2(8);
 height_v       number;
 width_v        number;
 size_book_v    number;
 page_post_v    varchar2(8) ;
 prem_per1_v    number;
 premium2_v     number;
 prem_per2_v    number ;
 premium_allow_v    varchar2(2);
 status_mat     varchar2(50);
 file_name      varchar2(100);
 disc_rate      number;
 bill_st        varchar2(8);
 agred_rate     number;
 pay_free_ins   varchar2(2);
 solo_rate      number;
 page_prem      varchar2(8);
 page_per       number;
 noof_columns   number;
 bill_amt       number;
 bill_rate      number;
 ad_sub_cat3    varchar2(15);
 ad_sub_cat4    varchar2(15);
 ad_sub_cat5    varchar2(15);
 trade_disc     number;
 ad_typ_v       varchar2(10);
 card_rate_v    float;
 premium        varchar2(8);

 v_bk_agcode       varchar2(20);
 v_bk_agsubcode varchar2(20);
 acagency_v     varchar2(20);
 v_branch       varchar2(100);
 v_rec_exists   number(3);
 v_date_time date;
 v_print_center varchar2(8);
BEGIN

UPDATE TBL_BOOKING_INSERT SET "Insert_Status"='billed',bill_no=invoice1, bill_date= trunc(todate)
WHERE "Insert_Id"=v_insert_id;

--lgselect "Publication_Code" into pubcode from tbl_booking_insert  WHERE  "Insert_Id"=v_insert_id;

select "Publication_Code","AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5",  "Height" ,
 "Width", "Size_Book","Edition","Supp_Code","Page_Post",
 "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow" ,
 "Status_Material" ,"No_Ofcolumn" ,"Bill_Amt" ,"Bill_Rate",
 "File_Name", "Disc_Rate", "Bill_Status", "Agreed_Rate",
 "Pai_Free_Ins", "Solo_Rate", "Page_Prem", "Page_Per" ,"Pub_Cent_Code","Card_Rate","Premium1" ,
"Userid","Ad_Cat","Ad_Sub_Cat","Comp_Code","Edition"
into pubcode,ad_sub_cat3,ad_sub_cat4,ad_sub_cat5,height_v,
width_v,size_book_v,edition_v,supp_code_v,page_post_v,
prem_per1_v,prem_per2_v,premium2_v,premium_allow_v ,
status_mat,noof_columns,bill_amt,bill_rate,
file_name,disc_rate,bill_st,agred_rate,
pay_free_ins,solo_rate,page_prem,page_per, pub_cent_code ,card_rate_v,premium,
userid,ad_catv ,ad_subcatv,v_comp_code,edition_codev
from tbl_booking_insert
WHERE  "Insert_Id"=v_insert_id;

select "branch","Agency_sub_code" , "RO_No","Discount","Ad_type_code" ,"RO_Date","Package_code",
"Rate_code" ,"Box_no","Receipt_no" ,"Insertion_date","Color_code","Client_code" ,"date_time"
into v_branch,v_agency_sub_code ,ro_num,trade_disc,ad_typ_v,ro_date,package_code_v,
rate_codev,box_nov,receipt_nov,insert_date,colour_code,client_code, v_date_time
from tbl_booking_mast where "cio_booking_id"=orderno1;

BEGIN
select distinct "Branch_Code" into  branch from BRANCH_MST where "Comp_Code"=v_comp_code and "Branch_Code"=v_branch;
EXCEPTION WHEN NO_DATA_FOUND THEN
NULL;
END;

/*lgbegin
select   "Client_code"  into  client_code from tbl_booking_mast where  "cio_booking_id"=orderno1;
EXCEPTION WHEN NO_DATA_FOUND THEN
NULL;
end;*/

begin
select  "Cust_Name" into client_name from cust_mast where "Comp_Code"=v_comp_code and "Cust_Code" =client_code;
EXCEPTION WHEN NO_DATA_FOUND THEN
NULL;
end;

BEGIN
   SELECT DISTINCT  "Agency_Code","SUB_Agency_Code","acagency" INTO v_agcode,v_cod_subcode,acagency_v  FROM AGENCY_MAST
    WHERE "Comp_Code"=v_comp_code and "Agency_Code"||"SUB_Agency_Code" =v_agency_sub_code;
EXCEPTION WHEN NO_DATA_FOUND THEN
   NULL;
END;

v_bk_agcode        :=v_agcode;
v_bk_agsubcode    :=v_cod_subcode;

if acagency_v is not null then
  select count(*) into v_rec_exists from agency_mast where "Comp_Code"=v_comp_code and "Agency_Code"=v_agcode and "SUB_Agency_Code" =acagency_v;

  if nvl(v_rec_exists,0)>0 then
     v_agency_sub_code:=v_agcode||acagency_v;
     v_cod_subcode    :=acagency_v;
  end if;
end if;

BEGIN
   SELECT DISTINCT  "pub_center" INTO v_print_center  FROM branch_mst 
    WHERE "Comp_Code"=v_comp_code and "Branch_Code" = branch;
EXCEPTION WHEN NO_DATA_FOUND THEN
   NULL;
END;

insert into ad_bills_det(unit,idnum,agcode,pripub,bkfor,bildt,bilno,gross_amt,ronum,rodate,clientcd,clientname,colour,boxchrg,insnum,insdate, usrid,priadctg,secadctg,ratecd,ag_main_code,ag_sub_code,boxno,rcptno,secpub,ad_subcat3,ad_subcat4,ad_subcat5,height,width,size_book,edition,supp_code,page_post,prem_per1,premium2 ,prem_per2,prem_allow,status_mat,noofcolumns ,bill_amt,bill_rate,file_name,disc_rate,bill_status,agg_rate,pai_free_ins,solo_rate,page_prem,page_per,discount,ad_type_v,billamt,card_rate_v,package_code,sppremium,comp_code_v,insert_id,bk_agcode, bk_agsubcode,RCPTDT,print_center)
values(branch ,orderno1,v_agency_sub_code,pubcode, branch,trunc(todate),invoice1,amountforvat,ro_num,trunc(ro_date),client_code,client_name,colour_code,boxchg1,noofinsert,trunc(insert_date),userid,ad_catv,ad_subcatv,rate_codev,v_agcode,v_cod_subcode,box_nov,receipt_nov,edition_codev,ad_sub_cat3,ad_sub_cat4,ad_sub_cat5,height_v,width_v,size_book_v,edition_v,supp_code_v,page_post_v,prem_per1_v,prem_per2_v,premium2_v,premium_allow_v,status_mat,noof_columns,bill_amt,bill_rate,file_name,disc_rate,bill_st,agred_rate,pay_free_ins,solo_rate,page_prem,page_per,trade_disc,ad_typ_v,amountforvat,card_rate_v, package_code_v,premium,v_comp_code,v_insert_id,v_BK_AGCODE,v_BK_AGSUBCODE, v_date_time,v_print_center);

END;
/
///////////////////////////////////////////////////////////////////////////////

==========================================ankit==============7143=======================================

CREATE OR REPLACE procedure chkprefren(
Pcompcode in varchar2,
P_Accounts OUT cur_type_new1.cursor_type
)
as 
begin
open P_Accounts for  
select * from PREFERRENCES where "comp_code"=Pcompcode;


end;
/







create or replace procedure fa_account_mast_typewise (
      pcompcode     in       varchar2,
      paccty        in       varchar2,
      paccname      in       varchar2,
      puserid       in       varchar2,
      pextra1       in       varchar2,
      pextra2       in       varchar2,
      p_accounts    out      cur_type_new1.cursor_type)
   as
begin
      open p_accounts for
         select m.comp_code as "COMP_CODE", m.cdp as "CDP", m.acc_name as "ACC_NAME", m.acc_alias as "ACC_ALIAS",
         m.acc_nature as "ACC_NATURE", m.ACC_TY as "ACC_TY",t.ac_type_desc as "AC_TYPE_DESC",t.ac_cash_bank as "AC_CASH_BANK"
           from fa_acc_mast m,fa_account_type_mast t
            where m.comp_code = pcompcode and m.comp_code = t.comp_code
                and m.acc_ty =t.ac_type_code and t.ac_cash_bank=nvl(paccty,t.ac_cash_bank)
                and ((upper (m.acc_name) like upper ('%' || paccname || '%')) or (paccname is null))
                order by acc_name;
            
END fa_account_mast_typewise;
==================end========================ankit==============7143=======================================


//=======================************* Start Procedure Scripts ***********kuldeep****===============//
alter table pub_cent_mast add (LOGO_FILE_PATH varchar2(200))
alter table pcmdummy1 add (LOGO_FILE_PATH varchar2(200))

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE Procedure pcenter_wise_detail(
     pcompcode          in varchar2,
     ppcenter           in varchar2,
     puserid            in varchar2,
     pdateformat        in varchar2,
     pextra1            in varchar2,
     pextra2            in varchar2,
     p_accounts         out cur_type_new1.cursor_type)
As
Begin
    open p_accounts for 
    select "Comp_Code" as "COMP_CODE",  "Pub_cent_Code"as "PUB_CENT_CODE",  "Pub_Cent_name" as  "PUB_CENT_NAME",  "Pub_Cent_Alias" as "PUB_CENT_ALIAS",  "Add1" as "ADD1",  "street" as "STREET","Country_Code" as "COUNTRY_CODE",  
    "State_Code" as "STATE_CODE",  "Dist_Code" as "DIST_CODE",  "City_Code" as "CITY_CODE",(select distinct "City_Name" from city_mst where "City_Code"=pub_cent_mast."City_Code")  as "CITY_NAME","zip" as "ZIP", "Phone1" as "PHONE1",
    "Phone2" as "PHONE2", "Fax" as "FAX",  "EmailID" as "EMAILID",  "Pub_Cent_Status" as "PUB_CENT_STATUS",  "Status_date" as "STATUS_DATE",  "Remarks" as "REMARKS",  "UserId" as "USERID",  "Creation_Datetime" as "CREATION_DATETIME",
    "Region_code" as "REGION_CODE",(select "Region_Name" from region_mst where "Region_Code"=pub_cent_mast."Region_code") as "REGION_NAME","Zone_code" as "ZONE_CODE",(select "Zone_Name" from zone_mst where "Zone_Code"=pub_cent_mast."Zone_code") as "ZONE_NAME", 
    "Fax1" as "FAX1", boxaddress as "BOXADDRESS",  print_cent as "PRINT_CENT", ip as "IP",  file_path as "FILE_PATH", cir_file_path as "CIR_FILE_PATH",LOGO_FILE_PATH as "LOGO_FILE_PATH",
    nvl(center_comp_name,(select "Comp_Name" from comp_mst x where x."Comp_Code"= pub_cent_mast."Comp_Code" and "Comp_Code"=pcompcode)) "CENTER_COMP_NAME",
    (select "PAN_No" from comp_mst where comp_mst."Comp_Code"= pub_cent_mast."Comp_Code") as "PAN_NO" 
    from pub_cent_mast where ("Pub_cent_Code"=ppcenter or ppcenter is null)
    order by "COMP_CODE","PUB_CENT_NAME";

END pcenter_wise_detail;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
pcompanyname in varchar2,
plogopath in varchar2
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
pcompanyname in varchar2,
plogopath in varchar2
)as

distcode  varchar2(50);
 statecode  varchar2(50);
 countrycode  varchar2(50);
begin



--select "Dist_Code"  into distcode  from dist_mst where "Dist_Name"=dist;
--select "State_Code"  into statecode from state_mst  where "State_Name"=state;
--select "Country_Code" into countrycode from count_mst  where "Country_Name"=country;

insert into pub_cent_mast("Comp_Code","Pub_cent_Code","Pub_Cent_name","Pub_Cent_Alias","Add1","street","Country_Code","State_Code","Dist_Code","City_Code","zip","Phone1","Phone2","Fax","EmailID","Pub_Cent_Status","Status_date","Remarks","UserId","Creation_Datetime","Region_code","Zone_code","Fax1","BOXADDRESS",PRINT_CENT,FILE_PATH,CIR_FILE_PATH,CENTER_COMP_NAME,LOGO_FILE_PATH)

 values(compcode,centercode,centername, alias,add1,street,country, state, dist, city, pin,phone1,phone2, fax,email,'',sysdate,remarks,userid,sysdate,region1,zone,fax1,boxaddress,printval,imgpath,cir_imgpath,pcompanyname,plogopath);


end  pcminsert_p;
end  pcminsert;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
pcompanyname in varchar2,
plogopath    in varchar2
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
pcompanyname in varchar2,
plogopath    in varchar2
)
as
begin

 update pub_cent_mast set "Pub_Cent_name"=centername , "Pub_Cent_Alias"=alias, "Add1"=add1, "street"=street, "Country_Code"=country, "State_Code"=state, "Dist_Code"=dist, "City_Code"=city, "zip"=pin, "Phone1"=phone1, "Phone2"=phone2,"Fax"=fax, "EmailID"=email,

 "Remarks"=remarks,"Region_code"=region1,"Zone_code"=zone,"Fax1"=fax1, "BOXADDRESS"=boxadd , PRINT_CENT=printval,FILE_PATH=imgpath,CIR_FILE_PATH=cir_imgpath,CENTER_COMP_NAME=pcompanyname,LOGO_FILE_PATH=plogopath where "Comp_Code"=compcode  and   "Pub_cent_Code"=centercode;

 commit;


end pcmupdate_p;
end pcmupdate;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE pcmexe Is

Type T_Accounts_Cursor Is Ref Cursor;


Procedure pcmexe_P(
compcode in varchar2,
centcode in varchar2,
centname in varchar2,
alias in varchar2,
city in varchar2,
country in varchar2,
pcompname in varchar2,
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
pcompname in varchar2,
p_Accounts OUT T_Accounts_Cursor ) AS

BEGIN

DELETE FROM pcmdummy1; COMMIT;

--select "Comp_Code","Pub_cent_Code","Pub_Cent_name","Pub_Cent_Alias","Add1","street","Country_Code", "State_Code","Dist_Code","City_Code","zip","Phone1","Phone2","Fax","EmailID",(select "cent_status" from pcm_status where  "center_code" ="Pub_cent_Code"),sysdate,"Remarks","UserId",(select "TO_DATE" from pcm_status where "center_code"="Pub_cent_Code" ),(select "FROM_DATE" from pcm_status where "center_code"="Pub_cent_Code" ),"Creation_Datetime","Region_code" as "Region_code","Zone_code" as "Zone_code","Fax1" from pub_cent_mast
INSERT INTO pcmdummy1
SELECT "Comp_Code","Pub_cent_Code","Pub_Cent_name","Pub_Cent_Alias","Add1","street","Country_Code",
"State_Code","Dist_Code","City_Code","zip","Phone1","Phone2","Fax","EmailID","Pub_Cent_Status"
,SYSDATE,"Remarks","UserId",SYSDATE,SYSDATE,"Creation_Datetime","Region_code","Zone_code","Fax1","BOXADDRESS",PRINT_CENT,
(select "Region_Name" from region_mst where region_mst."Region_Code"=pub_cent_mast."Region_code") as "Region_Name",
(select "Zone_Name" from zone_mast where zone_mast."Zone_Code"= pub_cent_mast."Zone_code") as "Zone_Name",FILE_PATH,CIR_FILE_PATH,CENTER_COMP_NAME,LOGO_FILE_PATH
FROM pub_cent_mast
WHERE "Comp_Code"=compcode AND  ("Pub_cent_Code"=centcode OR centcode IS NULL)AND
 ("Pub_Cent_name" LIKE centname||'%' OR centname IS NULL)
AND  ("Pub_Cent_Alias" LIKE alias||'%' OR alias IS NULL)
AND  ("Country_Code"=country OR country IS NULL)
AND  ("City_Code"=city OR city IS NULL)
AND  ("CENTER_COMP_NAME" LIKE pcompname||'%' OR pcompname IS NULL)
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
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE WEBSP_BINDCIOIDNEW1(
FROMDATE            IN VARCHAR2,
TODATE              IN VARCHAR2,
DATE1               IN VARCHAR2,
PUBLICATION         IN VARCHAR2,
BOOKINGCENTER       IN VARCHAR2,
REVENUECENTER       IN VARCHAR2,
AGENCYTYPE          IN VARCHAR2,
PACKAGE1            IN VARCHAR2,
ADTYPE1             IN VARCHAR2,
AGENCY              IN VARCHAR2,
CLIENT              IN VARCHAR2,
BILLSTATUS          IN VARCHAR2,
RATE_AUDIT          IN VARCHAR2,
BILLMODE            IN VARCHAR2,
BILLCYCLE           IN VARCHAR2,
V_RETAINER_NAME     IN VARCHAR2,
V_EXECUTIVE_NAME    IN VARCHAR2,
V_BRANCH_NAME       IN VARCHAR2,
V_AD_CATEGORY       IN VARCHAR2,
V_DISTRICT          IN VARCHAR2,
V_TALUKA            IN VARCHAR2,
PCOMPCODE           IN  VARCHAR2,
P_BILLNO            IN VARCHAR2,
P_BILL_GEN_PRIOR    IN VARCHAR2,
P_CENTERLOGIN       IN VARCHAR2,
P_PUB_CENT_HO       IN VARCHAR2,
P_FMG_BILL          IN VARCHAR2,
P_SCHEME_TYPE       IN VARCHAR2,
PTO_BILL_NO         IN VARCHAR2,
P_UOM               IN VARCHAR2,
P_RECORDSET         OUT CUR_TYPE_NEW1.CURSOR_TYPE)

IS

query1 VARCHAR2(10000);

v_bill_criteria varchar2(10);
v_dateformat    varchar2(100);

BEGIN
    if adtype1='DI0' then
        select disp_billing_criteria,"date_format" into v_bill_criteria,v_dateformat from preferrences where "comp_code"=pcompcode;
    else
        select clsd_billing_criteria,"date_format" into v_bill_criteria,v_dateformat from preferrences where "comp_code"=pcompcode;
    end if;
    
    IF(billstatus='3' AND rate_audit='n')
    THEN

      query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
      nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
      a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
      i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",
       i.BILL_NO
       ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
      FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
       i."Insert_Status"=''publish'' AND a."code_subcode"=m."Agency_sub_code" and m."audit" is not null 
       and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;


     IF(billstatus='3' AND rate_audit='y')
    THEN

          query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
     nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where
    cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"

          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
           i."Insert_Status"=''audit by rate'' AND a."code_subcode"=m."Agency_sub_code" and m."audit" is not null 
           and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='1' AND rate_audit='y'AND billmode='2')
    THEN

     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
     nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where
    cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",
           i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
    AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status" =''audit by rate'' OR i."Insert_Status"=''billed'') and m."audit" is not null
    and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='1' AND rate_audit='n' AND billmode='2')
    THEN
     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",
           i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status" =''publish'' OR i."Insert_Status"=''billed'')  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='1' AND rate_audit='n' AND (billmode='1' OR billmode='3'))
    THEN
     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
          (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status"=''billed'')  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='1' AND rate_audit='y' AND (billmode='1' OR billmode='3'))
    THEN

     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end  AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status"=''billed'')  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='3' AND rate_audit='n' AND (billmode='1' OR billmode='3'))
    THEN

     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end  AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status"=''billed'')  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='3' AND rate_audit='y' AND (billmode='1' OR billmode='3'))
    THEN

     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
        AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status"=''billed'')  and m."audit" is not null
        and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus=2)
    THEN
     query1:=' SELECT DISTINCT  i."Cio_Booking_Id",i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition" ,
    nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
    a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
    i."Insert_Status" AS "status",m."No_of_insertion" AS  "total",m."Bill_remarks",i.BILL_NO
    ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
    FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
     i."Insert_Status"=''billed'' AND a."code_subcode"=m."Agency_sub_code"  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
    END IF;



    IF(billstatus='5')
    THEN

      query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
      nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
      a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
      i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
      ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
      FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
       i."Insert_Status"=''publish'' AND a."code_subcode"=m."Agency_sub_code"  and m."audit" is not null
       and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;


    IF(billstatus=6)
    THEN
     query1:=' SELECT DISTINCT  i."Cio_Booking_Id",i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition" ,
    nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
    a."Agency_Name" AS "Agency",
    i."Insert_Status" AS "status",m."No_of_insertion" AS  "total",m."Bill_remarks",i.BILL_NO
    ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
    FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
     i."Insert_Status"=''booked'' AND a."code_subcode"=m."Agency_sub_code" 
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
    END IF;

    IF(v_retainer_name  IS NOT NULL)
    THEN
     query1:= query1 ||' and m."RETAINER" ='''||v_retainer_name ||'''';
    END IF;




    IF(v_executive_name IS NOT NULL)
    THEN
     query1:= query1||' and m."Executive_code" ='''||v_executive_name ||'''';
    END IF;



    IF(v_branch_name  IS NOT NULL and v_branch_name <> 0)
    THEN
     query1:= query1 ||' and m."branch" ='''||v_branch_name ||'''';
    END IF;



    IF(v_ad_category  IS NOT NULL)
    THEN
     query1:= query1 ||' and m."Ad_cat_code" ='''||v_ad_category||'''';
    END IF;


    IF(v_district  IS NOT NULL)
    THEN
     query1:= query1 ||' and m."Agency_sub_code"  in (select agency_mast."code_subcode" from agency_mast where agency_mast."Dist_Code" ='''||v_district||''' or '''||v_district||''' is null)';
    END IF;



    IF(v_taluka IS NOT NULL)
    THEN
     query1:= query1||'  AND m."Agency_sub_code"  in (select agency_mast."code_subcode" from agency_mast where (agency_mast."Dist_Code"  in(select DIST_CODE from taluka_mast where TALU_CODE='''||v_taluka||''' or '''||v_taluka||''' is null) )  AND agency_mast."Dist_Code"='''||v_district||''' OR '''||v_district||'''  IS NULL   )';
    END IF;

    if v_bill_criteria='A' then
        IF(billcycle IS NOT NULL)
        THEN
            query1:=query1 ||' AND a."BILL_FREQUENCY"='''||billcycle ||'''';
        END IF;
    elsif v_bill_criteria='R' then

        IF(billcycle IS NOT NULL)
        THEN
            query1:=query1 ||' AND m."Bill_cycle" ='''||billcycle ||'''';
        END IF;
    end if;
    
    IF(agency IS NOT NULL)
    THEN
    query1:=query1 ||' AND m."Agency_sub_code" ='''||agency ||'''';
    END IF;

    IF(client IS NOT NULL)
    THEN
    query1:=query1 ||' AND m."Client_code" ='''||client ||'''';
    END IF;


    IF(agencytype IS NOT NULL) THEN
        query1:=query1 ||' AND m."Agency_type"  ='''||trim(agencytype)||'''';
    END IF;
    
    IF(adtype1 IS NOT NULL) THEN
        query1:=query1 ||' AND m."Ad_type_code" ='''||adtype1||''' ';
    END IF;


    IF(bookingcenter  IS NOT NULL) THEN
        query1:=query1 ||' AND exists(select ''x'' from branch_mst where "Branch_Code"=m."branch" and "pub_center" ='''||bookingcenter||''') ';
    END IF;

    if (P_FMG_BILL !='Include') then

        query1:=query1 ||' AND m."Booking_type" not in (''2'',''4'',''5'')';

    end if;

    if(P_SCHEME_TYPE='EXCLUDE') THEN

        query1:=query1 ||' AND i."Pai_Free_Ins"  in (''Y'')';

    END IF;

    IF(revenuecenter IS NOT NULL) THEN

        query1:=query1 ||' AND m."Revenue_center" ='''||revenuecenter||''' ';
    
    END IF;

    IF(publication IS NOT NULL)
    THEN
    query1:=query1 ||'AND  i."Publication_Code"='''||publication ||'''';
    END IF;

    if (P_BILLNO is not null) and (pto_bill_no is not null) then
       query1:=query1 ||'AND  i.BILL_NO between '''||P_BILLNO||''' and '''||pto_bill_no||'''';
    END IF;



    IF(fromdate IS NOT NULL AND todate IS NOT NULL )
    THEN
     query1:=query1 ||'  AND i."Insert_Date" BETWEEN  '''||fromdate ||''' AND  '''||todate ||''' ';
    END IF;
    
    if (P_UOM is not null) then
       query1:=query1 ||'AND  m."Uom_code" = '''||P_UOM||'''';
    END IF;



    IF(PACKAGE1 IS NOT  NULL)
    THEN
    query1:=query1 ||' AND  i."Edition" ='''||PACKAGE1 ||'''';
    END IF;

    query1:=query1 ||'group by i."Cio_Booking_Id",i."No_Insert" ,m."Package_code"
     , a."Agency_Name",m."Trade_disc",i."Insert_Status",m."No_of_insertion"
     ,m."Bill_remarks",m."Client_code",i.BILL_NO, i."Comp_Code"  order by i."Cio_Booking_Id", i."No_Insert"';


    delete from ank_search_new;insert into ank_search_new values(query1);commit;



 OPEN p_recordset FOR

 query1;

END ;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE websp_bindcioidnew1_combined (
   fromdate           IN       VARCHAR2,
   todate             IN       VARCHAR2,
   date1              IN       VARCHAR2,
   publication        IN       VARCHAR2,
   bookingcenter      IN       VARCHAR2,
   revenuecenter      IN       VARCHAR2,
   agencytype         IN       VARCHAR2,
   package1           IN       VARCHAR2,
   adtype1            IN       VARCHAR2,
   agency             IN       VARCHAR2,
   client             IN       VARCHAR2,
   billstatus         IN       VARCHAR2,
   rate_audit         IN       VARCHAR2,
   billmode           IN       VARCHAR2,
   billcycle          IN       VARCHAR2,
   v_retainer_name    IN       VARCHAR2,
   v_executive_name   IN       VARCHAR2,
   v_branch_name      IN       VARCHAR2,
   v_ad_category      IN       VARCHAR2,
   v_district         IN       VARCHAR2,
   v_taluka           IN       VARCHAR2,
   pcompcode          IN       VARCHAR2,
   p_billno           IN       VARCHAR2,
   p_bill_gen_prior   IN       VARCHAR2,
   p_centerlogin      IN       VARCHAR2,
   p_pub_cent_ho      IN       VARCHAR2,
   p_fmg_bill         IN       VARCHAR2,
   p_scheme_type      IN       VARCHAR2,
   pto_bill_no        IN       VARCHAR2,
   p_uom              IN       VARCHAR2,
   p_recordset        OUT      cur_type_new1.cursor_type
)
IS
   query1            VARCHAR2 (10000);
   v_bill_criteria   VARCHAR2 (10);
begin
   if adtype1 = 'DI0' then
      select disp_billing_criteria into v_bill_criteria from preferrences where "comp_code" = pcompcode;
   else
      select clsd_billing_criteria into v_bill_criteria from preferrences where "comp_code" = pcompcode;
   end if;

   IF (billstatus = '3' AND rate_audit = 'n') THEN
      query1 :=' SELECT DISTINCT  i."Cio_Booking_Id", max(i."No_Insert") AS "no_of_insertion" ,m."Package_code"  AS "edition",
      nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
      a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
      min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO,
      (select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
      FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
      a."code_subcode"=m."Agency_sub_code" and m."audit" is not null and  m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''publish'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '3' AND rate_audit = 'y') THEN
      query1 :=' SELECT DISTINCT  i."Cio_Booking_Id", max(i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
     nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where
    cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
           i."Insert_Status" not in(''cancel'',''hold'') and  a."code_subcode"=m."Agency_sub_code" and m."audit" is not null
           and  m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''audit by rate'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''') 
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '1' AND rate_audit = 'y' AND billmode = '2')
   THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", max(i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
     nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where
    cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
        AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and m."audit" is not null
        and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND (b."Insert_Status" =''audit by rate'' OR b."Insert_Status"=''billed'') AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''') 
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '1' AND rate_audit = 'n' AND billmode = '2')
   THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", max(i."No_Insert") AS "no_of_insertion" ,m."Package_code"AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
        AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and 
        m."audit" is not null
        and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND (b."Insert_Status" =''publish'' OR b."Insert_Status"=''billed'') AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '1' AND rate_audit = 'n' AND (billmode = '1' OR billmode = '3'))
   THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
          (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
          AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and 
          m."audit" is not null 
          and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '1' AND rate_audit = 'y'AND (billmode = '1' OR billmode = '3'))THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
            AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and 
           m."audit" is not null 
           and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") '
           ;
   END IF;

   IF (billstatus = '3' AND rate_audit = 'n' AND (billmode = '1' OR billmode = '3')) THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND 
     i."Insert_Status" not in(''cancel'',''hold'') and m."audit" is not null
     and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '3' AND rate_audit = 'y'AND (billmode = '1' OR billmode = '3')) THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
        AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and 
        m."audit" is not null 
        and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = 2) THEN
      query1 :=
            ' SELECT DISTINCT  i."Cio_Booking_Id",count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition" ,
    nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
    a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
    min(i."Insert_Status") AS "status",m."No_of_insertion" AS  "total",m."Bill_remarks",i.BILL_NO
    ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
    FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
     i."Insert_Status" not in(''cancel'',''hold'') and a."code_subcode"=m."Agency_sub_code"  and m."audit" is not null
     and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '5') THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
      nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
      a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
      min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
      ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
      FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
       i."Insert_Status" not in(''cancel'',''hold'') and a."code_subcode"=m."Agency_sub_code" and m."audit" is not null
       and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''publish'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = 6)THEN
      query1 :=
            ' SELECT DISTINCT  i."Cio_Booking_Id",count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition" ,
        nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
        a."Agency_Name" AS "Agency",
        min(i."Insert_Status") AS "status",m."No_of_insertion" AS  "total",m."Bill_remarks",i.BILL_NO
        ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount"
        FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
         i."Insert_Status" not in(''cancel'',''hold'') and a."code_subcode"=m."Agency_sub_code" 
         and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''booked'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (v_retainer_name IS NOT NULL) THEN
      query1 := query1 || ' and m."RETAINER" =''' || v_retainer_name || '''';
   END IF;

   IF (v_executive_name IS NOT NULL) THEN
      query1 :=
          query1 || ' and m."Executive_code" =''' || v_executive_name || '''';
   END IF;

   IF (v_branch_name IS NOT NULL  AND v_branch_name <> 0) THEN
      query1 := query1 || ' and m."branch" =''' || v_branch_name || '''';
   END IF;

   IF (v_ad_category IS NOT NULL) THEN
      query1 := query1 || ' and m."Ad_cat_code" =''' || v_ad_category || '''';
   END IF;

   IF (v_district IS NOT NULL) THEN
      query1 :=
            query1|| ' and exists (select ''x'' from agency_mast where m."Agency_sub_code"=agency_mast."code_subcode" and agency_mast."Dist_Code" ='''|| v_district|| ''' or '''|| v_district|| ''' is null)';
   END IF;

   IF (v_taluka IS NOT NULL) THEN
      query1 :=
            query1|| '  AND exists (select ''x'' from agency_mast where m."Agency_sub_code"=agency_mast."code_subcode" and (agency_mast."Dist_Code"  in(select DIST_CODE from taluka_mast where TALU_CODE='''|| v_taluka|| ''' or '''|| v_taluka|| ''' is null) )  AND agency_mast."Dist_Code"='''|| v_district|| ''' OR '''|| v_district|| '''  IS NULL   )';
   END IF;

   IF v_bill_criteria = 'A'
   THEN
      IF (billcycle IS NOT NULL) THEN
         query1 :=query1 || ' AND a."BILL_FREQUENCY"=''' || billcycle || '''';
      END IF;
   ELSIF v_bill_criteria = 'R'
   THEN
      IF (billcycle IS NOT NULL) THEN
         query1 := query1 || ' AND m."Bill_cycle" =''' || billcycle || '''';
      END IF;
   END IF;

   IF (agency IS NOT NULL) THEN
      query1 := query1 || ' AND m."Agency_sub_code" =''' || agency || '''';
   END IF;

   IF (client IS NOT NULL) THEN
      query1 := query1 || ' AND m."Client_code" =''' || client || '''';
   END IF;

   IF (agencytype IS NOT NULL) THEN
      query1 :=query1 || ' AND m."Agency_type"  =''' || TRIM (agencytype)|| '''';
   END IF;

   IF (adtype1 IS NOT NULL) THEN
      query1 := query1 || ' AND m."Ad_type_code" =''' || adtype1 || ''' ';
   END IF;

   IF (bookingcenter IS NOT NULL) THEN
      query1:=query1 ||' AND exists(select ''x'' from branch_mst where "Branch_Code"=m."branch" and "pub_center" ='''||bookingcenter||''') ';
   END IF;

   IF (p_fmg_bill != 'Include') THEN
      query1 := query1 || ' AND m."Booking_type" not in (''2'',''4'',''5'')';
   END IF;

   IF (p_scheme_type = 'EXCLUDE') THEN
      query1 := query1 || ' AND i."Pai_Free_Ins"  in (''Y'')';
   END IF;

   IF (revenuecenter IS NOT NULL) THEN
      query1 := query1 || ' AND m."Revenue_center" =''' || revenuecenter || ''' ';
   END IF;

   IF (publication IS NOT NULL) THEN
      query1 :=
              query1 || ' AND  i."Publication_Code"=''' || publication || '''';
   END IF;

   IF (p_billno IS NOT NULL) AND (pto_bill_no IS NOT NULL) THEN
      query1 :=query1||' AND  i.BILL_NO between '''||p_billno||''' and '''||pto_bill_no||'''';
   END IF;

   IF (p_uom IS NOT NULL) THEN
      query1 := query1 || 'AND  m."Uom_code" = ''' || p_uom || '''';
   END IF;

   IF (package1 IS NOT NULL) THEN
      query1 := query1 || ' AND  i."Edition" =''' || package1 || '''';
   END IF;

   query1 :=query1|| 'group by i."Cio_Booking_Id",m."Package_code", a."Agency_Name",m."Trade_disc",m."No_of_insertion"
     ,m."Bill_remarks",m."Client_code",i.BILL_NO, i."Comp_Code"  order by i."Cio_Booking_Id"';

   delete from ank_search_new;insert into ank_search_new values (query1);commit;

   OPEN p_recordset FOR query1;
END websp_bindcioidnew1_combined;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE Websp_Selectvaluesnew_rp(
ciobooking          IN  VARCHAR2,
editionname         IN  VARCHAR2,
compcode            IN  VARCHAR2,
insertion           IN  VARCHAR2,
dateformat          IN VARCHAR2,
p_getbookingrecord  OUT Cur_Type_New1.cursor_type,
p_accounts1         OUT Cur_Type_New1.cursor_type,
P_ACCOUNTS2         OUT Cur_Type_New1.cursor_type)
IS
str             VARCHAR(10000);
package_cd      VARCHAR(300);
package_result  VARCHAR(300);
package_cd1     VARCHAR(300);
A               NUMBER;

BEGIN

str :='SELECT DISTINCT m."cio_booking_id" AS "CIOID",
m."Agency_sub_code",a."Agency_Name" AS "Agency",a."Add1" , c."City_Name",
nvl(substr(((SELECT DISTINCT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE  CUST_MAST."Cust_Code"=m."Client_code")),1,18),m."Client_code") AS "advertiser" ,
i."Height" AS "Depth",
i."Width" AS "Width",
i.BOXCHARGE as "BOXCHARGE",
cl."Col_Alias" AS "Hue",
i."No_Insert" AS "Ins.No.",
m."RO_No" AS "RoNo.",
m."Card_amount" AS "Amt",
m."Bullet_premium" as "Bullet_Charges",
i."Disc_Rate" AS "Disc",
(SELECT ADVPOS_TYPE_MAST."Pos_Type" FROM ADVPOS_TYPE_MAST WHERE ADVPOS_TYPE_MAST."Pos_Type_Code"=i."Page_Post" ) AS "pageposition",
m."Ad_type_code" as "Ad_type_code",(SELECT ADV_TYPE_MAST."Adv_Type_Name" FROM ADV_TYPE_MAST  WHERE ADV_TYPE_MAST."Adv_Type_Code"=m."Ad_type_code" ) AS "AdType",

i."Size_Book" AS "Volume",
case nvl(m."Agrred_rate",0) when 0 then m."Card_rate" else m."Agrred_rate"  end as "package rate",
m."Gross_amount",
(SELECT BOX_MAST."Box_Charges_Native" FROM BOX_MAST  WHERE  m."Box_code"=BOX_MAST."Box_Code") AS "boxchares" ,
sum(i."Gross_Rate") as "Gross_Rate",
m."Creation_datetime",
(SELECT DISTINCT  "Package_Name" FROM COMBIN_MAST WHERE m."Package_code"=COMBIN_MAST."Combin_Code"  AND "Combin_Desc"='''||editionname||''' )AS "package_name",

nvl((SELECT DISTINCT CUST_MAST."Add1"  || "Stree" FROM CUST_MAST WHERE  CUST_MAST."Cust_Code"=m."Client_code" ),m."Client_address") AS "clientAd",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
m."No_of_insertion",
CASE '''||dateformat||'''
    WHEN ''mm/dd/yyyy'' THEN TO_CHAR(min(i."Insert_Date"),''mm/dd/yyyy'')
    WHEN ''dd/mm/yyyy'' THEN TO_CHAR(min(i."Insert_Date"),''dd/mm/yyyy'')
    WHEN ''yyyy/mm/dd'' THEN TO_CHAR(min(i."Insert_Date"),''yyyy/mm/dd'')  
END AS "Ins.Date",
min(i."Page_No") as "Page_insrt",
(SELECT "premiumname" FROM ADVPOS_PREM_MAST  WHERE   ADVPOS_PREM_MAST. "Premiumcode"=i."Premium1")as "premiumname",
m."Special_discount",
m."Special_charges",
m."Trade_disc",
(SELECT "premium_charges" FROM ADVPOS_PREM_MAST  WHERE   ADVPOS_PREM_MAST. "Premiumcode"=i."Premium1") AS "premiumch",
i."Card_Rate",(select max("Size_To") from rate_mast where "Combin_Code"=i.PACKAGE_CODE and "Comp_code"='''||compcode||''' and "Rate_Mast_Code"=m."Rate_code" and "Adv_Type_Code"=m."Ad_type_code" and "Adv_Cat_Code"=m."Ad_cat_code" and 
"Uom"=m."Uom_code" and "Color"=i."Col_Code" and m."Insertion_date" between "Valid_From" and "Valid_To") as "MIN_WORD" ,
(select max("Week_Extra_Rate") from rate_mast where "Combin_Code"=i.PACKAGE_CODE and "Comp_code"='''||compcode||''' and "Rate_Mast_Code"=m."Rate_code" and "Adv_Type_Code"=m."Ad_type_code" and "Adv_Cat_Code"=m."Ad_cat_code" and 
"Uom"=m."Uom_code" and "Color"=i."Col_Code" and m."Insertion_date" between "Valid_From" and "Valid_To") as "EXTRA_RATE" ,
initcap(b."Add1") as "Add1" , b."Phone1", b."Phone2", b."Fax"  as "Fax1",

m."Key_no" AS "Key No",m."Uom_code",
m."Agency_type",
 lower(b."EmailID") as  "Email" ,
(select to_char((SELECT distinct AD_BILLS."BILDT" + nvl(m."Agency_credit",nvl(a."Credit_Days",0)) from ad_bills
where ad_bills.bildt=i.bill_date and ad_bills.bilno=i.bill_no and AD_BILLS."IDNUM" =  '''||ciobooking||''' and ad_bills.insnum= '''||insertion||'''  and 
AD_BILLS."AGCODE" = a."code_subcode"),''dd-Mon-yyyy'') from dual) AS "paydate",

(select to_char((SELECT SYSDATE + nvl(m."Agency_credit",nvl(a."Credit_Days",0))  FROM  dual),''dd-Mon-yyyy'') from dual) as "paydatesys",
a."Add2",
a."Add3"
,m."Caption" as "Cap",
sum(i."Bill_Amt") as "Bill_Amt",
m.ADD_AGENCY_COMM as "addcom",
min(i."Insert_Date") as  "insert_date",b."Street" as "street",m."Box_no",

CASE '''||dateformat||'''
    WHEN ''mm/dd/yyyy'' THEN TO_CHAR(i."BILL_DATE",''mm/dd/yyyy'')
    WHEN ''dd/mm/yyyy'' THEN TO_CHAR(i."BILL_DATE",''dd/mm/yyyy'')
    WHEN ''yyyy/mm/dd'' THEN TO_CHAR(i."BILL_DATE",''yyyy/mm/dd'')  END AS "BILL_DATE",

CASE '''||dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR(m."RO_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(m."RO_Date",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(m."RO_Date",''yyyy/mm/dd'')  END AS "RO_Date",
m."Bill_remarks",
(select "Scheme_Name"  from Scheme_Master where Scheme_Master."scheme_id"=m."Scheme_type_code" and Scheme_Master."Comp_code"=m."Comp_code" and rownum <=1) as "Scheme",

i."Insert_Status" as "status",
case when instr(m."Package_code",'','') >0 then 
    FETCH_PACK_NAME('''||compcode||''', i.PACKAGE_CODE ) 
else
    (select distinct min("Package_Name") from combin_mast where "Combin_Code"=i.PACKAGE_CODE)
end AS "Package"
/*New Field Add*/
,(select "Adv_Cat_Name" from adv_cat_mast where "Comp_Code"='''||compcode||''' and "Adv_Cat_Code"=m."Ad_cat_code") as "Adv_Cat_Name",
(select "Adv_Subcat_Name" from adv_subcat_mast where "Comp_Code"='''||compcode||''' and "Adv_Subcat_Code"=m."Ad_sub_cat_code") as "Adv_Subcat_Name"
FROM TBL_BOOKING_MAST m,PUB_CENT_MAST pc,
TBL_BOOKING_INSERT i,AGENCY_MAST  a,PUB_MAST p,
COL_MAST cl,CITY_MST c,branch_mst b

WHERE m ."Comp_code"='''||compcode||'''
AND m."cio_booking_id"=i."Cio_Booking_Id"
AND m."Agency_sub_code"=a."code_subcode"
AND i."Col_Code"=cl."Col_Code"
AND pc."Pub_cent_Code"  =i."Pub_Cent_Code"
AND c."City_Code"=a."City_Code"  AND i."Publication_Code" = p."Pub_Code" AND   i."Cio_Booking_Id"='''||ciobooking||''' AND   i."No_Insert"='''||insertion||'''
and b ."Branch_Code"=m ."branch" 
group by m."cio_booking_id" ,
m."Agency_sub_code",a."Agency_Name" ,a."Add1" , c."City_Name",
m."Client_code",m."Client_address",
i."Height" ,
i."Width" ,
cl."Col_Alias" ,
i."No_Insert" ,
m."RO_No",
m."Card_amount" ,
i."Disc_Rate" ,
i."Page_Post" ,
m."Ad_type_code",
i."Size_Book" ,
m."Agrred_rate", m."Card_rate",
m."Gross_amount",
m."Box_code",m."Creation_datetime",m."Package_code",
m."No_of_insertion",
i."Premium1",m."Special_discount",m."Special_charges",m."Trade_disc",
i."Premium1" ,i."Card_Rate",
initcap(b."Add1") , b."Phone1", b."Phone2", b."Fax",
m."Key_no" ,m."Agency_type",
lower(b."EmailID"),m."Agency_credit",a."Credit_Days", 
a."Add2",a."Add3",m."Caption",
m.ADD_AGENCY_COMM,b."Street",m."Box_no",i."BILL_DATE",
m."RO_Date",m."Bill_remarks",m."Scheme_type_code",m."Comp_code",i."Insert_Status",
i.bill_no,i.bill_date,i.PACKAGE_CODE,a."code_subcode",m."Rate_code",m."Ad_type_code",
m."Ad_cat_code",m."Uom_code",i."Col_Code" , m."Insertion_date"
,m."Ad_sub_cat_code",
i.BOXCHARGE,m."Bullet_premium"';

delete from PACKAGE1;

BEGIN
    SELECT  "Package_code" INTO  package_cd1 FROM TBL_BOOKING_MAST WHERE "cio_booking_id"=ciobooking;

EXCEPTION WHEN NO_DATA_FOUND THEN 
    NULL; 
END;


A:=Fn_Splitfield(package_cd1,',');

DECLARE
     CURSOR c1 IS SELECT Edition_Name FROM RESULT;
BEGIN

    OPEN c1;
    LOOP
        FETCH  c1    INTO package_result;
        EXIT WHEN C1%NOTFOUND;

        INSERT INTO PACKAGE1 SELECT "Combin_Desc" FROM COMBIN_MAST WHERE "Combin_Code"=package_result;

    END LOOP;
        --print(@package_result)
    CLOSE c1;
END ;

delete from searchtbl;insert into searchtbl values(str);commit;

OPEN p_getbookingrecord FOR str;

OPEN p_accounts1 FOR SELECT * FROM PACKAGE1;

OPEN P_ACCOUNTS2 FOR
SELECT DISTINCT "Edition_Code","Edition",PACKAGE_CODE,
Case when "Insert_Date" is not null then
    CASE dateformat WHEN 'mm/dd/yyyy' THEN TO_CHAR("Insert_Date",'mm/dd/yyyy')
                    WHEN 'dd/mm/yyyy' THEN TO_CHAR("Insert_Date",'dd/mm/yyyy')
                    WHEN 'yyyy/mm/dd' THEN TO_CHAR("Insert_Date",'yyyy/mm/dd')
Else
    null
End 
END AS "Ins.Date" 
FROM TBL_BOOKING_INSERT WHERE  "Comp_Code"=compcode and "Cio_Booking_Id"=ciobooking and "No_Insert"=insertion;


END ;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE Websp_Selectvaluesnew_combined(
pcompcode           IN  VARCHAR2,
pciobooking         IN  VARCHAR2,
puserid             IN  VARCHAR2,
pdateformat         IN  VARCHAR2,
pextra1             IN  VARCHAR2,
pextra2             IN  VARCHAR2,
pextra3             IN  VARCHAR2,
pextra4             IN  VARCHAR2,
pextra5             IN  VARCHAR2,
p_getbookingrecord  OUT Cur_Type_New1.cursor_type,
p_accounts1         OUT Cur_Type_New1.cursor_type,
P_ACCOUNTS2         OUT Cur_Type_New1.cursor_type)
IS
str             VARCHAR(10000);
package_cd      VARCHAR(300);
package_result  VARCHAR(300);
package_cd1     VARCHAR(300);
A               NUMBER;

BEGIN

str :='SELECT DISTINCT m."cio_booking_id" AS "CIOID",i.PACKAGE_CODE as "PACKAGE_CODE",/*i."Edition_Code"*/ i."Edition" as "Edition",
m."Agency_sub_code",a."Agency_Name" AS "Agency",a."Add1" , c."City_Name",
nvl(substr(((SELECT DISTINCT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE  CUST_MAST."Cust_Code"=m."Client_code")),1,18),m."Client_code") AS "advertiser" ,
i."Height" AS "Depth",
i."Width" AS "Width",
cl."Col_Alias" AS "Hue",
i."No_Insert" AS "Ins.No.",
m."RO_No" AS "RoNo.",
m."Card_amount" AS "Amt",
m."Bullet_premium" as "Bullet_Charges",
m.TRANSLATION_PREMIUM as "TRANSLATION_PREMIUM",
m."Bill_amount" as "Bill_amount",
i."Disc_Rate" AS "Disc",
(SELECT bullet_mast."Bullet_Charges_Type" FROM bullet_mast  WHERE m."Comp_code"=bullet_mast."Comp_Code" and m."Bullet_code" =bullet_mast."Bullet_Code") as "Bullet_Charges_Type",
(SELECT ADVPOS_TYPE_MAST."Pos_Type" FROM ADVPOS_TYPE_MAST WHERE ADVPOS_TYPE_MAST."Pos_Type_Code"=i."Page_Post" ) AS "pageposition",
m."Ad_type_code" as "Ad_type_code",(SELECT ADV_TYPE_MAST."Adv_Type_Name" FROM ADV_TYPE_MAST  WHERE ADV_TYPE_MAST."Adv_Type_Code"=m."Ad_type_code" ) AS "AdType",

i."Size_Book" AS "Volume",
case nvl(m."Agrred_rate",0) when 0 then m."Card_rate" else m."Agrred_rate"  end as "package rate",
m."Gross_amount",
(SELECT BOX_MAST."Box_Charges_Native" FROM BOX_MAST  WHERE m."Comp_code"=BOX_MAST."Comp_Code" and  m."Box_code"=BOX_MAST."Box_Code" ) AS "boxchares" ,
(i."Gross_Rate") as "Gross_Rate",
m."Creation_datetime",
(SELECT DISTINCT  "Package_Name" FROM COMBIN_MAST WHERE m."Package_code"=COMBIN_MAST."Combin_Code")AS "package_name",

nvl((SELECT DISTINCT CUST_MAST."Add1"  || "Stree" FROM CUST_MAST WHERE  CUST_MAST."Cust_Code"=m."Client_code" ),m."Client_address") AS "clientAd",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
m."No_of_insertion",
CASE '''||pdateformat||'''
    WHEN ''mm/dd/yyyy'' THEN TO_CHAR((i."Insert_Date"),''mm/dd/yyyy'')
    WHEN ''dd/mm/yyyy'' THEN TO_CHAR((i."Insert_Date"),''dd/mm/yyyy'')
    WHEN ''yyyy/mm/dd'' THEN TO_CHAR((i."Insert_Date"),''yyyy/mm/dd'')  
END AS "Ins.Date",
(i."Page_No") as "Page_insrt",
(SELECT "premiumname" FROM ADVPOS_PREM_MAST  WHERE   ADVPOS_PREM_MAST. "Premiumcode"=i."Premium1")as "premiumname",
m."Special_discount",
m."Special_charges",
m."Trade_disc",
(SELECT "premium_charges" FROM ADVPOS_PREM_MAST  WHERE   ADVPOS_PREM_MAST. "Premiumcode"=i."Premium1") AS "premiumch",
i."Card_Rate",(select max("Size_To") from rate_mast where "Combin_Code"=i.PACKAGE_CODE and "Comp_code"='''||pcompcode||''' and "Rate_Mast_Code"=m."Rate_code" and "Adv_Type_Code"=m."Ad_type_code" and "Adv_Cat_Code"=m."Ad_cat_code" and 
"Uom"=m."Uom_code" and "Color"=i."Col_Code" and m."Insertion_date" between "Valid_From" and "Valid_To") as "MIN_WORD" ,
(select max("Week_Extra_Rate") from rate_mast where "Combin_Code"=i.PACKAGE_CODE and "Comp_code"='''||pcompcode||''' and "Rate_Mast_Code"=m."Rate_code" and "Adv_Type_Code"=m."Ad_type_code" and "Adv_Cat_Code"=m."Ad_cat_code" and 
"Uom"=m."Uom_code" and "Color"=i."Col_Code" and m."Insertion_date" between "Valid_From" and "Valid_To") as "EXTRA_RATE" ,
initcap(b."Add1") as "Add1" , b."Phone1", b."Phone2", b."Fax"  as "Fax1",

m."Key_no" AS "Key No",m."Uom_code",
m."Agency_type",
 lower(b."EmailID") as  "Email" ,
(select to_char((SELECT distinct AD_BILLS."BILDT" + nvl(m."Agency_credit",nvl(a."Credit_Days",0)) from ad_bills
where ad_bills.bildt=i.bill_date and ad_bills.bilno=i.bill_no and AD_BILLS."IDNUM" =  '''||pciobooking||''' and  
AD_BILLS."AGCODE" = a."code_subcode"),''dd-Mon-yyyy'') from dual) AS "paydate",

(select to_char((SELECT SYSDATE + nvl(m."Agency_credit",nvl(a."Credit_Days",0))  FROM  dual),''dd-Mon-yyyy'') from dual) as "paydatesys",
a."Add2",
a."Add3"
,m."Caption" as "Cap",
(i."Bill_Amt") as "Bill_Amt",
m.ADD_AGENCY_COMM as "addcom",
(i."Insert_Date") as  "insert_date",b."Street" as "street",m."Box_no",

CASE '''||pdateformat||'''
    WHEN ''mm/dd/yyyy'' THEN TO_CHAR(i."BILL_DATE",''mm/dd/yyyy'')
    WHEN ''dd/mm/yyyy'' THEN TO_CHAR(i."BILL_DATE",''dd/mm/yyyy'')
    WHEN ''yyyy/mm/dd'' THEN TO_CHAR(i."BILL_DATE",''yyyy/mm/dd'')  END AS "BILL_DATE",

CASE '''||pdateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR(m."RO_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(m."RO_Date",''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(m."RO_Date",''yyyy/mm/dd'')  END AS "RO_Date",
m."Bill_remarks",
(select "Scheme_Name"  from Scheme_Master where Scheme_Master."scheme_id"=m."Scheme_type_code" and Scheme_Master."Comp_code"=m."Comp_code" and rownum <=1) as "Scheme",

i."Insert_Status" as "status",
case when instr(m."Package_code",'','') >0 then 
    FETCH_PACK_NAME('''||pcompcode||''', i.PACKAGE_CODE ) 
else
    (select distinct ("Package_Name") from combin_mast where "Combin_Code"=i.PACKAGE_CODE)
end AS "Package"
/*New Field Add*/
,(select "Adv_Cat_Name" from adv_cat_mast where "Comp_Code"='''||pcompcode||''' and "Adv_Cat_Code"=m."Ad_cat_code") as "Adv_Cat_Name",
(select "Adv_Subcat_Name" from adv_subcat_mast where "Comp_Code"='''||pcompcode||''' and "Adv_Subcat_Code"=m."Ad_sub_cat_code") as "Adv_Subcat_Name"
FROM TBL_BOOKING_MAST m,PUB_CENT_MAST pc,
TBL_BOOKING_INSERT i,AGENCY_MAST  a,PUB_MAST p,
COL_MAST cl,CITY_MST c,branch_mst b

WHERE m ."Comp_code"='''||pcompcode||'''
AND m."cio_booking_id"=i."Cio_Booking_Id"
AND m."Agency_sub_code"=a."code_subcode"
AND i."Col_Code"=cl."Col_Code"
AND pc."Pub_cent_Code"  =i."Pub_Cent_Code"
AND c."City_Code"=a."City_Code"  AND i."Publication_Code" = p."Pub_Code" AND   i."Cio_Booking_Id"='''||pciobooking||'''  
and b ."Branch_Code"=m ."branch" 
/*group by m."cio_booking_id" ,
m."Agency_sub_code",a."Agency_Name" ,a."Add1" , c."City_Name",
m."Client_code",m."Client_address",
i."Height" ,
i."Width" ,
i."Edition_Code",
cl."Col_Alias" ,
i."No_Insert" ,
m."Bullet_premium"
m."RO_No",
m."Card_amount" ,
i."Disc_Rate" ,
i."Page_Post" ,
m."Ad_type_code",
m."Bill_amount",
i."Size_Book" ,
m."Agrred_rate", m."Card_rate",
m."Gross_amount",
m."Box_code",m."Creation_datetime",m."Package_code",
m."No_of_insertion",
i."Premium1",m."Special_discount",m."Special_charges",m."Trade_disc",
i."Premium1" ,i."Card_Rate",
initcap(b."Add1") , b."Phone1", b."Phone2", b."Fax",
m."Key_no" ,m."Agency_type",
lower(b."EmailID"),m."Agency_credit",a."Credit_Days", 
a."Add2",a."Add3",m."Caption",
m.ADD_AGENCY_COMM,b."Street",m."Box_no",i."BILL_DATE",
m."RO_Date",m."Bill_remarks",m."Scheme_type_code",m."Comp_code",i."Insert_Status",
i.bill_no,i.bill_date,i.PACKAGE_CODE,a."code_subcode",m."Rate_code",m."Ad_type_code",
m."Ad_cat_code",m."Uom_code",i."Col_Code" , m."Insertion_date"
,m."Ad_sub_cat_code"*/ order by m."cio_booking_id",i."No_Insert",i.PACKAGE_CODE ';

delete from PACKAGE1;

BEGIN
    SELECT  "Package_code" INTO  package_cd1 FROM TBL_BOOKING_MAST WHERE "cio_booking_id"=pciobooking;

EXCEPTION WHEN NO_DATA_FOUND THEN 
    NULL; 
END;


A:=Fn_Splitfield(package_cd1,',');

DECLARE
     CURSOR c1 IS SELECT Edition_Name FROM RESULT;
BEGIN

    OPEN c1;
    LOOP
        FETCH  c1    INTO package_result;
        EXIT WHEN C1%NOTFOUND;

        INSERT INTO PACKAGE1 SELECT "Combin_Desc" FROM COMBIN_MAST WHERE "Combin_Code"=package_result;

    END LOOP;
        --print(@package_result)
    CLOSE c1;
END ;

delete from searchtbl;insert into searchtbl values(str);commit;

OPEN p_getbookingrecord FOR str;

open p_accounts1 for-- select * from package1;
select sum(i."Gross_Rate") as "package_rate", 
case sum(nvl(i."Agreed_Rate",0))  when 0 then sum(i."Card_Rate") 
else sum(i."Agreed_Rate")  end as "package rate",i."No_Insert" "No_Insert",
(select sum(tbl_booking_insert."Gross_Rate") from tbl_booking_insert 
where "Cio_Booking_Id"=pciobooking and "No_Insert"=i."No_Insert") as "insert_gross"
from tbl_booking_insert i where i."Cio_Booking_Id"=pciobooking and i."Insert_Status" !='cancel'
group by i."No_Insert",i.package_code;

  
OPEN P_ACCOUNTS2 FOR
SELECT DISTINCT "No_Insert", "Edition_Code","Edition",PACKAGE_CODE,
Case when "Insert_Date" is not null then
    CASE pdateformat WHEN 'mm/dd/yyyy' THEN TO_CHAR("Insert_Date",'mm/dd/yyyy')
                    WHEN 'dd/mm/yyyy' THEN TO_CHAR("Insert_Date",'dd/mm/yyyy')
                    WHEN 'yyyy/mm/dd' THEN TO_CHAR("Insert_Date",'yyyy/mm/dd')
Else
    null
End 
END AS "Ins.Date" 
FROM TBL_BOOKING_INSERT WHERE  "Comp_Code"=pcompcode and "Cio_Booking_Id"=pciobooking
order by "No_Insert",PACKAGE_CODE;


END Websp_Selectvaluesnew_combined;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE procedure bill_save_data(
    pcompcode       in    varchar2,
    pcenter         in    varchar2,
    porderno        in    varchar2,
    pinsertion_no   in    number,
    pbill_cycle     in    varchar2,--for single insertion wise or multiple insertion wise
    puserid         in    varchar2,
    pfrom_date      in    varchar2,
    ptill_date      in    varchar2,
    pbill_date      in    varchar2,
    pdateformat     in    varchar2,
    pnoofinsert     in    number,
    pprefix         in    varchar2,
    pextra1         in    varchar2,
    pextra2         in    varchar2,
    pextra3         in    varchar2,
    pextra4         in    varchar2,
    pextra5         in    varchar2)
is
 pubcode            varchar2(50);
 pub_cent_code      varchar2(50);
 ro_num             varchar2(40);
 ro_date            date;
 client_code        varchar2(500);
 client_name        varchar2(700);
 insert_date        date;
 v_comp_code        varchar2(18);
 userid             varchar2(80);
 package_code_v     varchar2(8000);
 agency_sub_code    varchar2(500);
 colour_code        varchar2(300);
 ad_catv            varchar2(300);
 ad_subcatv         varchar2(300);
 rate_codev         varchar2(300);
 box_nov            varchar2(400);
 receipt_nov        varchar2(400);
 edition_codev      varchar2(300);
 edition_v          varchar2(500);
 supp_code_v        varchar2(80);
 height_v           number;
 width_v            number;
 size_book_v        number;
 page_post_v        varchar2(80) ;
 prem_per1_v        number;
 premium2_v         number;
 prem_per2_v        number ;
 premium_allow_v    varchar2(20);
 status_mat         varchar2(200);
 file_name          varchar2(100);
 disc_rate          number;
 bill_st            varchar2(80);
 agred_rate         number;
 pay_free_ins       varchar2(20);
 solo_rate          number;
 page_prem          varchar2(80);
 page_per           number;
 noof_columns       number;
 bill_amt           number;
 bill_rate          number;
 ad_sub_cat3        varchar2(100);
 ad_sub_cat4        varchar2(100);
 ad_sub_cat5        varchar2(100);
 trade_disc         number;
 ad_typ_v           varchar2(100);
 card_rate_v        float;
 premium            varchar2(8);

v_bk_agcode        varchar2(100);
v_bk_agsubcode     varchar2(100);
acagency_v         varchar2(100);
v_branch           varchar2(100);
v_rec_exists       number(3);


v_agcode           varchar2(100);
v_cod_subcode      varchar2(100);
v_agency_sub_code  varchar2(100);
v_date_time        date;
v_insertid         number(15);
v_gross_rate       number(18,2);
v_box_chrg         number(10,2);
 
v_billno    varchar2(30);
v_frdt  date;
v_todt  date;
v_bill_date date;
v_brand varchar2(30);

    cursor c1 is
    select m."branch" branch,m."RO_No" ro_no,m."RO_Date" ro_date,m."Discount" discount,m."Ad_type_code" ad_type,m."Color_code" color_code,
    m."Rate_code" rate_code,m."Box_no" box_no,m."Receipt_no" receipt_no,m."Client_code" client_code,nvl((select  "Cust_Name" from cust_mast where "Cust_Code" =m."Client_code"),m."Client_code") client_name,
    m."Agency_sub_code" code_subcode,m."date_time" date_time, 
    i.package_code, i."AD_SUBCAT3" ad_subcat3, i."AD_SUBCAT4" ad_subcat4, i."AD_SUBCAT5" ad_subcat5, i."Height" height, i."Width" width, 
    i."Size_Book" size_book,i."Edition" edition,i."Supp_Code" supp_code,i."Page_Post" page_post,i."Prem_Per1" prem_per1, 
    i."Premium2" premium2, i."Prem_Per2" prem_per2, i."Premium_Allow" premium_allow,i."Status_Material" ,i."No_Ofcolumn" ,
    i."Bill_Amt" bill_amt,i."Bill_Rate" bill_rate,i."File_Name" file_name, i."Disc_Rate" disc_rate, i."Bill_Status" bill_status, 
    i."Agreed_Rate" agreed_rate, i."Pai_Free_Ins" pai_free_ins, i."Solo_Rate" solo_rate,
    i."Page_Prem" page_prem, i."Page_Per" page_per,i."Pub_Cent_Code" pub_cent_code,i."Card_Rate" card_rate, i."Insert_Date" insert_date,
    i."Premium1" premium1,i."Publication_Code" publication_code,
    i."Comp_Code" ,i."Ad_Cat" ad_cat,i."Ad_Sub_Cat" ad_sub_cat,i."Insert_Id" insert_id,i."Gross_Rate" gross_rate,i."BOXCHARGE" BOXCHARGE,
    a."Agency_Code" agency_code,a."SUB_Agency_Code" sub_agency_code,a."acagency" acagency,
    m."Product_code",m."Brand_code"
from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and  m."Comp_code"=pcompcode and 
    m."cio_booking_id"=i."Cio_Booking_Id" and m."cio_booking_id"=porderno and m."ro_status"='1' and 
    m."Agency_sub_code"=a."code_subcode" and i.bill_no is null and 
    ((i."No_Insert" =pinsertion_no and m."Bill_cycle"=nvl(pbill_cycle,m."Bill_cycle") and nvl(pbill_cycle,'1') <>'6') 
    or (m."Bill_cycle"=nvl(pbill_cycle,m."Bill_cycle") and nvl(pbill_cycle,'1') ='6')) and 
    i."Insert_Status" not in('cancel','hold')
    order by i."Insert_Id";

v1 c1%rowtype;

cursor c2 is
   select m."Comp_code",m."RO_No",m."RO_Date",m."Color_code",m."Agency_sub_code" ,m."Client_code",
    nvl((select  "Cust_Name" from cust_mast where "Cust_Code" =m."Client_code"),m."Client_code") client_name,
    m."Trade_disc",m."RETAINER",m."Contract_name",m."Contract_type", m."Contract_rate",
    m."Special_discount",m."Space_discount",m."Bill_pay",m."Executive_code",m."Scheme_type_code",m."Revenue_center",
    m."ro_status",m."Page_type_code",m."Booking_type",m."Product_code",m."Brand_code", m."Page_no",m."Page_position_code",m."Bill_remarks",
    m."branch",m."date_time",m."Receipt_no",m."Ad_type_code",
    max(i."Publication_Code"),min(i."Ad_Cat"),min(i."Ad_Sub_Cat"),min(i."Insert_Date"),
    a."Agency_Code" agency_code,a."SUB_Agency_Code" sub_agency_code,a."acagency" acagency,
    round(sum(i."Bill_Amt")) bill_amt,round(sum(i."Gross_Rate")) gross_amt,sum(boxcharge) boxcharge
from tbl_booking_mast m,tbl_booking_insert i,agency_mast a 
where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and  m."Comp_code"=pcompcode and 
    m."cio_booking_id"=i."Cio_Booking_Id" and m."cio_booking_id"=porderno and m."ro_status"='1' and 
    m."Agency_sub_code"=a."code_subcode" and i.bill_no is not null and i.bill_no=v_billno and
    ((i."No_Insert" =pinsertion_no and m."Bill_cycle"=nvl(pbill_cycle,m."Bill_cycle") and nvl(pbill_cycle,'1') <>'6') 
    or (m."Bill_cycle"=nvl(pbill_cycle,m."Bill_cycle") and nvl(pbill_cycle,'1') ='6')) and i."Insert_Status" not in('cancel','hold')
    group by m."Comp_code",m."RO_No",m."RO_Date",m."Color_code",m."Agency_sub_code" ,m."Client_code",
    m."Trade_disc",m."RETAINER",m."Contract_name",m."Contract_type", m."Contract_rate",
    m."Special_discount",m."Space_discount",m."Bill_pay",m."Executive_code",m."Scheme_type_code",m."Revenue_center",
    m."ro_status",m."Page_type_code",m."Booking_type",m."Product_code",m."Page_no",m."Page_position_code",m."Bill_remarks",
    m."branch",m."date_time",m."Receipt_no",m."Ad_type_code",a."Agency_Code",a."SUB_Agency_Code",a."acagency",m."Brand_code";

retainer_v          varchar2(10);
cont_name           varchar2(100);
cont_type           varchar2(100);
cont_rate           varchar2(100);
exe_code            varchar2(100);
special_disc        varchar2(100);
space_disc          varchar2(100);
bill_pay            varchar2(100);

scheme_type         varchar2(100);
revcenter           varchar2(100);
ro_status           varchar2(100);
page_type           varchar2(100);
booking_type        varchar2(100);
prod_code           varchar2(200);
page_no             varchar2(200);
page_position       varchar2(8);
billremark          varchar2(500);
v_rcptdt            date;
v_rcptno            varchar2(50);
v_ad_type           varchar2(10);
region_v            varchar2(50);
billremark          varchar2(500);
bill_rmk_v          varchar2(500);
BEGIN

    v_frdt  :=to_date(pfrom_date,''''||pdateformat||'''');
    v_todt  :=to_date(ptill_date,''''||pdateformat||'''');

    if pbill_date is not null then
        v_bill_date:=to_date(pbill_date,''''||pdateformat||'''');
    else
        select  min("Insert_Date")  into  v_bill_date from tbl_booking_insert where "Cio_Booking_Id"=porderno 
        and (("No_Insert" =pinsertion_no and nvl(pbill_cycle,'1') <>'6') or nvl(pbill_cycle,'1') ='6' )  and "Insert_Date" is not null and bill_no is null and "Insert_Status" in('publish','audit by rate');
    end if;        

    ---generate bill no
    getautoinvoiceno_centerwise(pcompcode,pcenter,v_bill_date,pdateformat,'F',pprefix,null,null,v_billno);
    
    open c1;
    loop
        fetch c1 into v_branch,ro_num,ro_date,trade_disc,ad_typ_v,colour_code, rate_codev,box_nov,receipt_nov ,client_code,client_name ,v_agency_sub_code,v_date_time,
        package_code_v,ad_sub_cat3,ad_sub_cat4,ad_sub_cat5,height_v,width_v,size_book_v,edition_v,
        supp_code_v,page_post_v,prem_per1_v,prem_per2_v,premium2_v,premium_allow_v,status_mat,
        noof_columns,bill_amt,bill_rate,file_name,disc_rate,bill_st,agred_rate,pay_free_ins,solo_rate,
        page_prem,page_per, pub_cent_code ,card_rate_v,insert_date,premium,pubcode,
        v_comp_code,ad_catv,ad_subcatv,v_insertid,v_gross_rate,v_box_chrg,
        v_agcode,v_cod_subcode,acagency_v,prod_code,v_brand;
        exit when c1%notfound;


        v_bk_agcode       :=v_agcode;
        v_bk_agsubcode    :=v_cod_subcode;

        if acagency_v is not null then
          select count(*) into v_rec_exists from agency_mast where "Comp_Code"=v_comp_code and 
            "code_subcode" =v_agcode||acagency_v;

          if nvl(v_rec_exists,0)>0 then
             v_agency_sub_code:=v_agcode||acagency_v;
             v_cod_subcode    :=acagency_v;
          end if;
        end if;        
    
        insert into ad_bills_det
        (unit,idnum,agcode,pripub,bkfor,bildt,bilno,gross_amt,ronum,rodate,clientcd,clientname,
        colour,boxchrg,insnum,insdate, usrid,priadctg,secadctg,ratecd,ag_main_code,ag_sub_code,
        boxno,rcptno,secpub,ad_subcat3,ad_subcat4,ad_subcat5,height,width,size_book,edition,
        supp_code,page_post,prem_per1,premium2 ,prem_per2,prem_allow,status_mat,noofcolumns ,
        bill_amt,bill_rate,file_name,disc_rate,bill_status,agg_rate,pai_free_ins,solo_rate,page_prem,page_per,
        discount,ad_type_v,billamt,card_rate_v,package_code,sppremium,insert_id,comp_code_v,bk_agcode, bk_agsubcode,rcptdt,
        priproctg,secproctg)
        values
        (v_branch ,porderno,v_agency_sub_code,pubcode, pub_cent_code,trunc(v_bill_date),v_billno,v_gross_rate,ro_num,trunc(ro_date),client_code,client_name,
        colour_code,v_box_chrg,nvl(pnoofinsert,pinsertion_no),trunc(insert_date),puserid,ad_catv,ad_subcatv,rate_codev,v_agcode,v_cod_subcode,
        box_nov,receipt_nov,edition_codev,ad_sub_cat3,ad_sub_cat4,ad_sub_cat5,height_v,width_v,size_book_v,edition_codev,
        supp_code_v,page_post_v,prem_per1_v,prem_per2_v,premium2_v,premium_allow_v,status_mat,noof_columns,
        bill_amt,bill_rate,file_name,disc_rate,bill_st,agred_rate,pay_free_ins,solo_rate,page_prem,page_per,
        trade_disc,ad_typ_v,bill_amt,card_rate_v, package_code_v,premium,v_insertid,v_comp_code,v_bk_agcode,v_bk_agsubcode,v_date_time,
        null,null);

        
        update tbl_booking_insert  set "Insert_Status"='billed',bill_no=v_billno, bill_date= trunc(v_bill_date) where "Insert_Id" =v_insertid;
    end loop;
    close c1;
    
    open c2;
        fetch c2 into v_comp_code,ro_num,ro_date,colour_code,v_agency_sub_code,client_code,client_name,
            trade_disc,retainer_v,cont_name,cont_type ,cont_rate,
            special_disc,space_disc,Bill_pay ,exe_code,scheme_type,revcenter,
            ro_status,page_type,booking_type,prod_code,v_brand,page_no,page_position,bill_rmk_v,v_branch,v_rcptdt,v_rcptno,v_ad_type,
            pubcode, ad_catv,ad_subcatv,insert_date,
            v_agcode,v_cod_subcode,acagency_v,bill_amt,v_gross_rate,v_box_chrg;
    
        v_bk_agcode       :=v_agcode;
        v_bk_agsubcode    :=v_cod_subcode;

    
        if acagency_v is not null then
          select count(*) into v_rec_exists from agency_mast where "Comp_Code"=v_comp_code and 
            "code_subcode" =v_agcode||acagency_v;

          if nvl(v_rec_exists,0)>0 then
             v_agency_sub_code:=v_agcode||acagency_v;
             v_cod_subcode    :=acagency_v;
          end if;
        end if;

        insert into ad_bills (
            unit,idnum,agcode,bkfor,bildt,bilno,billamt,gross_amt,ronum,rodate,
            clientcd,clientname,colour,boxchrg,insnum,insdate,usrid,noofinsrt,ag_main_code, ag_sub_code,
            discount,region_code_v,retainer_code,pripub,contract_name,contract_type,contract_rate,executive_name,
            ovrddisc,spacedisc,bill_pay ,scheme,revenue_center,ro_status,page_type,booking_type,priproctg,secproctg,pagenum,page_post,
            bill_rmrk,comp_code_v,bk_agcode, bk_agsubcode,rcptno,rcptdt,ad_type,priadctg, secadctg)
        values(
            v_branch ,porderno,v_agency_sub_code,v_branch,trunc(v_bill_date),v_billno,bill_amt,v_gross_rate,ro_num,ro_date,
            client_code,client_name,colour_code,v_box_chrg,pinsertion_no,trunc(insert_date),puserid,pnoofinsert,v_agcode,v_cod_subcode,
            trade_disc,region_v,retainer_v,pubcode,cont_name,cont_type,cont_rate,exe_code,
            special_disc,space_disc,bill_pay,scheme_type,revcenter,ro_status,page_type,booking_type,prod_code,v_brand,page_no,page_position,
            bill_rmk_v,v_comp_code,v_bk_agcode,v_bk_agsubcode,v_rcptno,v_rcptdt,v_ad_type,ad_catv,ad_subcatv );

        insert into ad_outstand(
            unit,agcode,pripub,bkfor,billno,amount,noofinsrt,insdate,comp_code,userid,
            creation_datetime,doctype,billdt ,ag_main_code, ag_sub_code, remark,bk_agcode, bk_agsubcode,receipt_no,retainer_code, 
            exec_code,chno, chdt,bank,ad_type,priproctg)
        values(
            v_branch,v_agency_sub_code,pubcode,v_branch,v_billno,bill_amt,pnoofinsert,trunc(insert_date),v_comp_code,userid,
            sysdate,'BILL',trunc(v_bill_date),v_agcode,v_cod_subcode,bill_rmk_v,v_bk_agcode,v_bk_agsubcode,porderno,retainer_v,
            exe_code,ro_num,ro_date,client_code,v_ad_type,ad_catv);

    close c2;
    commit;
end bill_save_data;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE Procedure Websp_Receipt_Print
(pcompcode           IN  VARCHAR2,
pcio_booking_id     IN  VARCHAR2,
dateformat          IN  VARCHAR2,
p_getbookingrecord  OUT Cur_Type_New1.cursor_type,
p_accounts1         OUT Cur_Type_New1.cursor_type,
P_ACCOUNTS2         OUT Cur_Type_New1.cursor_type)

IS
BEGIN

        OPEN p_getbookingrecord FOR
        SELECT DISTINCT a."Agency_Name" AS "Agen",
        NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
        p."Pub_Name" AS "Pub",m."No_of_insertion" AS "noinsert",m."Gross_amount" AS "gamt1",
        --m."Gross_amount" AS "gamt",
        (select "oth_amount"  from ad_rcpthdr where "comp_code"=m."Comp_code" and "recptno"=m."Receipt_no"  and "doctype" in('RCP','CA')) as "gamt",
        m."cio_booking_id" AS "CIOID",
        NVL(a."Add1",' ') AS "address",c."City_Name",
        SYSDATE AS "receiptdate",
        m."Receipt_no" AS "recno",m."Trade_disc" AS "trade_disc",m."Bill_area",m."Ad_type_code",m."Uom_code",
        (select "Adv_Cat_Alias" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=m."Ad_cat_code") as "CAT_NAME",
        (select "Adv_Subcat_Alias" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code"=m."Ad_sub_cat_code") as "SUBCAT_NAME",
        (select "catalias"  from ad_cat3 where m."Ad_Subcat3"=ad_cat3."catcode" ) as "CAT3_NAME",
        (select "Cat_Alias"  from tbl_cat4 where m."Ad_Subcat4"=tbl_cat4."Cat_Code") as "CAT4_NAME",
        (select "Cat_Alias"  from tbl_cat5 where m."Ad_subcat5"=tbl_cat5."Cat_Code") as "CAT5_NAME",
        CASE dateformat
        WHEN 'mm/dd/yyyy' THEN (select TO_CHAR(nvl("recptdt","date_time"),'mm/dd/yyyy')  from ad_rcpthdr where "comp_code"=m."Comp_code" and "recptno"=m."Receipt_no"  and "doctype" in('RCP','CA'))
        WHEN 'dd/mm/yyyy' THEN (select TO_CHAR(nvl("recptdt","date_time"),'dd/mm/yyyy')  from ad_rcpthdr where "comp_code"=m."Comp_code" and "recptno"=m."Receipt_no"  and "doctype" in('RCP','CA'))
        WHEN 'yyyy/mm/dd' THEN (select TO_CHAR(nvl("recptdt","date_time"),'yyyy/mm/dd')  from ad_rcpthdr where "comp_code"=m."Comp_code" and "recptno"=m."Receipt_no"  and "doctype" in('RCP','CA'))  END AS "BookDate",
        (select "Uom_Alias" from uom_mast where uom_mast."Uom_Code"=m."Uom_code"),
        m."branch",m."Bill_amount" AS "bilamt",
        SYSDATE AS "receiptdate1",
        m."Caption"  AS "caption",m."RO_No" AS "rono",
        CASE dateformat
        WHEN 'mm/dd/yyyy' THEN TO_CHAR(m."RO_Date",'mm/dd/yyyy')
        WHEN 'dd/mm/yyyy' THEN TO_CHAR(m."RO_Date",'dd/mm/yyyy')
        WHEN 'yyyy/mm/dd' THEN TO_CHAR(m."RO_Date",'yyyy/mm/dd')  END AS "rodate",
        t."Adv_Type_Name" as "adtype",
        (SELECT COMBIN_MAST."Package_Name" FROM COMBIN_MAST WHERE m."Package_code"=COMBIN_MAST."Combin_Code") AS "Package_Name",
        m."Card_rate" AS "pkgrate",m."Card_amount" AS "cardamount",
        cm."Comp_Name" AS "companyname",
        cm."Add1" AS "address",
        cm."EmailID" AS "emailid",
        cm."PAN_No" AS "pan_no",
        pm."Payment_Mode_Name",m."ADD_AGENCY_COMM" AS "adl_agency_comm",
        m."Page_amount" AS "Page_prem",
        m."Booking_type" AS  "Booking_type",
        m."Box_no"    AS "Box_no",
        m."Special_disc_per" AS "Special_disc_per",
        m."Prem_per"    AS "Prem_per",
        m."Bullet_premium" as "Bullet_Charges",
        m.TRANSLATION_PREMIUM as "TRANSLATION_PREMIUM",
        /********* For Extra Rate And Min Word find From Rate Master ******/
        (select max("Size_To") from rate_mast where "Combin_Code"=i.PACKAGE_CODE and "Comp_code"=pcompcode and "Rate_Mast_Code"=m."Rate_code" and "Adv_Type_Code"=m."Ad_type_code" and "Adv_Cat_Code"=m."Ad_cat_code" and 
        "Uom"=m."Uom_code" and "Color"=i."Col_Code" and m."Insertion_date" between "Valid_From" and "Valid_To") as "MIN_WORD" ,
        (select max("Week_Extra_Rate") from rate_mast where "Combin_Code"=i.PACKAGE_CODE and "Comp_code"=pcompcode and "Rate_Mast_Code"=m."Rate_code" and "Adv_Type_Code"=m."Ad_type_code" and "Adv_Cat_Code"=m."Ad_cat_code" and 
        "Uom"=m."Uom_code" and "Color"=i."Col_Code" and m."Insertion_date" between "Valid_From" and "Valid_To") as "EXTRA_RATE" ,

        nvl(m."Special_discount",0) as "Special_discount",nvl(m."Space_discount",0) as "Space_discount",
        m."Agrred_rate" as "Agreed_Rate",i."Insert_Date",m.doctype DOCTYPE,
        (select "Bill_amount" from tbl_booking_mast pre_bk where pre_bk."cio_booking_id"=m."prev_cioid" ) as PREVBILLAMT,
        m.cashdiscount,CASHDISCTYPE,m.ADD_AGENCY_COMM_AMT,
        (select "Box_Charges_Native" from box_mast where "Box_Code" =m."Box_code") as boxcharge,
        (select "Box_Charges_Type" from box_mast where "Box_Code" =m."Box_code") as boxtype,
        nvl ((SELECT "Cust_Name"||'-'||m."Client_address" FROM CUST_MAST WHERE "Cust_Code" = m."Client_code") , m."Client_code"||'-'||m."Client_address") AS Client2,
        (select "amount"  from ad_rcpthdr where "recptno"=m."Receipt_no"  and "doctype" in('RCP','CA')) as "gcancelamt",
        nvl(m."Bullet_code",'') as "eyecatcher",(select charges_type from ad_charge_mast where charge_code=m.translation_code) as "CHARGE_TYPE", 
        m.translation_premium as "TRANSLATION_PREMIUM",(select sum("Gross_Rate") from tbl_booking_insert 
        where tbl_booking_insert."Cio_Booking_Id" = m."cio_booking_id" and "No_Insert"=1) as "INSERT_GROSS_AMT"        
        from tbl_booking_mast m,pub_cent_mast pc,tbl_booking_insert i,
        agency_mast a,pub_mast p,col_mast cl,
        adv_type_mast t,city_mst c,comp_mst cm,payment_mode_mast pm
        
        where m."Comp_code"=pcompcode and m."Comp_code"=cm."Comp_Code" and m."cio_booking_id"=i."Cio_Booking_Id" and m."cio_booking_id"=pcio_booking_id 
        and m."Agency_sub_code"=a."code_subcode" and i."Publication_Code" = p."Pub_Code"
        and pc."Pub_cent_Code"=i."Pub_Cent_Code" and c."City_Code"=a."City_Code" and
        pm."Pay_Mode_Code"=m."Agency_pay" and m."Ad_type_code"=t."Adv_Type_Code" and cl."Col_Code"=m."Color_code"
        order by i."Insert_Date" DESC;

        open p_accounts1 for
        select distinct (select "Package_Name" from combin_mast where "Combin_Code"=i."PACKAGE_CODE") as "Edition",
        case 'dd/mm/yyyy'
        when 'mm/dd/yyyy' then to_char(min(i."Insert_Date"),'mm/dd/yyyy')
        when 'dd/mm/yyyy' then to_char(min(i."Insert_Date"),'dd/mm/yyyy')
        when 'yyyy/mm/dd' then to_char(min(i."Insert_Date"),'yyyy/mm/dd')  end as "Insert_Date",
        sum(i."Gross_Rate") as   "Gross_Rate",
        max(i."Height") "Height", max(i."Width") "Width", max(i."Size_Book") "Size_Book",min(cl."Col_Alias") "Col_Alias", 
        min(i."Page_No") "Page_No", 
        sum(i."Agreed_Rate") as "Agreed_Rate",sum(i."Solo_Rate") as "Solo_Rate",i."No_Insert" as "No_Insert"
        from tbl_booking_insert i , col_mast cl
        where i."Cio_Booking_Id"=pcio_booking_id and i."Col_Code"=cl."Col_Code"  
        group by i."PACKAGE_CODE",i."No_Insert" 
        order by i."No_Insert","Edition";-- desc;

        open p_accounts2 for 
        select  distinct "Combin_Desc"  as "PACKAGE_NAME" 
        from tbl_booking_mast m,tbl_booking_insert i,combin_mast c 
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=pcompcode and 
        m."cio_booking_id"=pcio_booking_id and m."cio_booking_id"=i."Cio_Booking_Id" and
        c."Combin_Code"=i.package_code;
            
end Websp_Receipt_Print;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
                         WHEN '3'
                            THEN 'Delete Only'
                         WHEN '4'
                            THEN 'Insert,Update Only'
                         WHEN '5'
                            THEN 'Insert,Delete Only'
                         WHEN '6'
                            THEN 'Update,Delete Only'
                         WHEN '7'
                            THEN 'All Permission'
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

//=======================************* End of Procedure Scripts ***************===============//


/**************************************mimoh*****7162***************************************************/
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
      p_parent        IN   VARCHAR2,
       poldclient   in varchar2
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
      p_parent        IN   VARCHAR2,
      poldclient   in varchar2
   )
   AS
      countrycode   VARCHAR2 (100);
      fatchstatus   VARCHAR2 (100);
      p_remark      VARCHAR2 (500) null;
   BEGIN
            begin
                 select "Status_Name" into fatchstatus from tblstatus where "Status_Code"=(select "CUST_STATUS" from status_detail_client where "cust_code"=custcode and "comp_code"=compcode and rownum<=1) and rownum<=1;
               
            EXCEPTION
                   WHEN NO_DATA_FOUND THEN  NULL;
            END;
            
             begin
                 select "Remarks" into p_remark from cust_mast where "Comp_Code"=compcode and "Cust_Code"=custcode and rownum<=1;
               
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
                PARENT_CLIENT=p_parent,
                OLD_CLIENT_CODE = poldclient
          WHERE "Comp_Code" = compcode
            AND "Cust_Code" = custcode;
           -- AND "UserId" = userid;

        /* TO INSERT DATA IN CLIENT HISTORY LOG*/
         IF (p_remark != alert)
         then
         INSERT INTO CUST_REMARK_DETAIL(COMP_CODE, CUST_CODE,CUST_REMARK, USERID)
                        VALUES(compcode,custcode,alert,userid);
         end if;
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
                      CLIENT_TYPE,QBC_AGENCY,"TYPE",PARENT_CLIENT,OLD_CLIENT_CODE 
                     )
              VALUES (compcode, custcode, custname, custalias,
                      add1, street, citycode, zip, dist,
                      state, country, phone1, phone2,
                      fax, emailid, url1, vats, servicetax1,
                      pan1, creditdays, paymodecode,
                      fatchstatus, statusreason, alert, userid,
                      SYSDATE, zone, region1,
                      crdlimit, rategroup, clientcat,taluka1,agency_sav,
                      p_CLIENT_TYPE,p_QBC_AGENCY,p_type,p_parent,poldclient
                     );
       /* TO INSERT DATA IN CLIENT HISTORY LOG*/
       
         INSERT INTO CUST_REMARK_DETAIL(COMP_CODE, CUST_CODE,CUST_REMARK, USERID)
                        VALUES(compcode,custcode,alert,userid);
      END IF;
   END clientsave_p;
END clientsave;
/

/****************************************************************************************/

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
            agency_code, division, client_type, qbc_agency,"TYPE",PARENT_CLIENT,OLD_CLIENT_CODE )
         SELECT "Comp_Code", "Cust_Code", "Cust_Name", "Cust_Alias", "Add1",
                "Stree", "City_Code", "Zip", "Dist_Code", "State_Code",
                "Country_Code", "phone1", "Phone2", "Fax", "EmailID", "URL",
                "No_of_VTS", "ST_ACC_No", "PAN_No", "Credit_Days",
                "Pay_Mode_Code", "Cust_Status", "Status_Reason", "Remarks",
                "UserId", "Creation_Datetime", "Zone_code", "Region_code",
                "Credit_limit", "Rate_Gr_Code", SYSDATE, "Client_category","TALUKA",
                AGENCY_CODE, DIVISION, CLIENT_TYPE, QBC_AGENCY,"TYPE","PARENT_CLIENT",OLD_CLIENT_CODE 
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
SELECT COMP_CODE as "Comp_Code", CUST_CODE as "Cust_Code", CUST_NAME as "Cust_Name", CUST_ALIAS as "Cust_Alias", ADD1 as "Add1", STREE as "Stree", CITY_CODE as "City_Code", ZIP as "Zip", DIST_CODE as "Dist_Code", STATE_CODE as "State_Code", COUNTRY_CODE as "Country_Code", PHONE1 as "phone1", PHONE2 as "Phone2", FAX as "Fax", EMAILID as "EmailID", URL, NO_OF_VTS as "No_of_VTS", ST_ACC_NO, PAN_NO, CREDIT_DAYS as "Credit_Days", PAY_MODE_CODE as "Pay_Mode_Code", CUST_STATUS as "Cust_Status", STATUS_REASON as "Status_Reason", REMARKS as "Remarks", USERID as "UserId", CREATION_DATETIME as "Creation_Datetime", ZONE_CODE as "Zone_code", REGION_CODE as "Region_code", CREDIT_LIMIT as "Credit_limit", RATE_GR_CODE as "Rate_Gr_Code", TO_DATE as "to_date", CLIENT_CATEGORY as "Client_category",TALUKA1 as "TALUKA",CLIENT_TYPE, QBC_AGENCY,"TYPE",PARENT_CLIENT,OLD_CLIENT_CODE FROM CUST_MAST_TEMP ORDER BY Cust_Code;

   END clientexecute_p;
END Clientexecute;
/


/**************************************mimoh*****7162***************************************************/
/**************************************mimoh************7180********11/april/2012***************************************************************/


CREATE OR REPLACE PACKAGE Retainerexec IS

TYPE T_Accounts_Cursor IS REF CURSOR;


PROCEDURE RetainerExec_P(
compcode IN  VARCHAR2,
Retain_Code IN VARCHAR2,
retname  IN VARCHAR2,
retalias IN VARCHAR2,
citycode IN VARCHAR2,
pubcent  IN VARCHAR2,
country IN VARCHAR2,
box_matter IN VARCHAR2,
repname in varchar2,
branchname in varchar2,
p_Accounts OUT T_Accounts_Cursor );

END Retainerexec;
/





CREATE OR REPLACE PACKAGE BODY Retainerexec IS

PROCEDURE RetainerExec_P(
compcode IN  VARCHAR2,
Retain_Code IN VARCHAR2,
retname  IN VARCHAR2,
retalias IN VARCHAR2,
citycode IN VARCHAR2,
pubcent  IN VARCHAR2,
country IN VARCHAR2,
box_matter IN VARCHAR2,
repname in varchar2,
branchname in varchar2,
p_Accounts OUT T_Accounts_Cursor ) AS

BEGIN


OPEN p_Accounts FOR
SELECT "Comp_Code","userid","Retain_Code","Retain_Name","Retain_Alias","Add1","Street","City_Code","Zip","Dist_Code","State_Code","Region_Code","Country_Code","Phone1","Phone2","Fax","EmailID","Credit_Days","Remarks","PAN_No",
(SELECT  "Status_Name" FROM TBLSTATUS WHERE "Status_Code" =(select STATUS_NAME from ret_status_detail where "Retain_Code"=RETAINERMASTER."Retain_Code" and rownum <=1 AND sysdate between "FROM_DATE" and "TO_DATE")) as "Retain_status",SYSDATE,SYSDATE,"pubcent_code","BOXMATTER","PUBLICATION","EDITION","SUPPLEMENT","TALUKA",REPRESENTATIVE as "repname","Branch_code",CREDIT_LIMIT,MOBILENO,"SIGN",ad_get_fieldname('COMP_CD',compcode,'EMP_CODE',RETAINERMASTER.HR_CODE,'NAME','HR_EMP_MST','','') AS HR_CODE,(select ACC_NAME   from fa_acc_mast where COMP_CODE=compcode and CDP= RETAINERMASTER.CDP )AS ACC_NAME,CDP  FROM  RETAINERMASTER
 WHERE "Comp_Code"=compcode AND  "Retain_Code"=Retain_Code OR Retain_Code IS NULL AND
 "Retain_Name" LIKE retname||'%'
AND  ("Retain_Alias" LIKE retalias||'%' )
AND  ("Country_Code"=country OR country IS NULL)
AND  ("City_Code"=citycode OR citycode IS NULL)
AND  ("pubcent_code"=pubcent OR pubcent IS NULL)
AND  ("Branch_code"=branchname OR branchname IS NULL)
;


END RetainerExec_P;

END Retainerexec;
/


/*****************************************************************************************************/



CREATE OR REPLACE PACKAGE RetainerInsertDetail Is



Type T_Accounts_Cursor Is Ref Cursor;
Procedure RetainerInsertDetail_P (Comp_Code1  in varchar2,
Retain_Code1  in varchar2,
userid1 in varchar2,
Retain_Name1 in varchar2,
Retain_Alias1 in varchar2,
Add11 in varchar2 ,
Street1 in varchar2 ,
City_Code1 in varchar2,
pubcent   in varchar2,
Zip1 in varchar2 ,
Dist_Code1 in varchar2 ,
State_Code1 in varchar2,
zone_code1 in varchar2,
region_code1 in varchar2,
Country_Code1 in varchar2,
phone11 in varchar2,
Phone21 in varchar2 ,
Fax1 in varchar2 ,
EmailID1 in varchar2 ,
PAN_No1 in varchar2 ,
Credit_Days1 in varchar2,
Remarks1 in varchar2 ,
flag in number,
Box in varchar2,
Publication1 in varchar2,
Edition1 in varchar2,
Supplement1 in varchar2,
taluka1 in varchar2,
repname in varchar2,
branchcode in varchar2,
creditlimit in varchar2,
mobile1 in varchar2,
signature in varchar2,
p_empcode in varchar2,
p_maincdp in varchar2
);

End RetainerInsertDetail;
/





CREATE OR REPLACE PACKAGE BODY RetainerInsertDetail Is

Procedure RetainerInsertDetail_P (Comp_Code1  in varchar2,
Retain_Code1 in varchar2,
userid1 in varchar2,
Retain_Name1 in varchar2,
Retain_Alias1 in varchar2,
Add11 in varchar2 ,
Street1 in varchar2 ,
City_Code1 in varchar2,
pubcent   in varchar2,
Zip1 in varchar2 ,
Dist_Code1 in varchar2 ,
State_Code1 in varchar2,
zone_code1 in varchar2,
region_code1 in varchar2,
Country_Code1 in varchar2,
phone11 in varchar2,
Phone21 in varchar2 ,
Fax1 in varchar2 ,
EmailID1 in varchar2 ,
PAN_No1 in varchar2 ,
Credit_Days1 in varchar2,
Remarks1 in varchar2 ,
flag in number,
Box in varchar2,
Publication1 in varchar2,
Edition1 in varchar2,
Supplement1 in varchar2,
taluka1 in varchar2,
repname in varchar2,
branchcode in varchar2,
creditlimit in varchar2,
mobile1 in varchar2,
signature in varchar2,
p_empcode in varchar2,
p_maincdp in varchar2
) As

  Begin
    if flag = '0' then
   insert into RetainerMaster("Comp_Code" ,"Retain_Code" ,"userid" ,"Retain_Name" ,"Retain_Alias" ,"Add1" ,"Street" ,"City_Code" ,"Zip" ,"Dist_Code" ,"State_Code" ,"Zone_Code","Region_Code","Country_Code" ,"Phone1" ,"Phone2" ,"Fax" ,"EmailID" ,"PAN_No" ,"Credit_Days","Remarks" , "pubcent_code","Creation_Datetime", "Retain_status", "To_date","BOXMATTER","PUBLICATION","EDITION","SUPPLEMENT","TALUKA",REPRESENTATIVE,"Branch_code",CREDIT_LIMIT,MOBILENO,"SIGN",HR_CODE,CDP)values (Comp_Code1,Retain_Code1,userid1,Retain_Name1,Retain_Alias1,Add11,Street1,City_Code1,Zip1,Dist_Code1,State_Code1,zone_code1,region_code1,Country_Code1,phone11,Phone21,Fax1,EmailID1,PAN_No1,Credit_Days1,Remarks1,pubcent,sysdate,'','',Box,Publication1,Edition1,Supplement1,taluka1,repname,branchcode,creditlimit,mobile1,signature,p_empcode,p_maincdp) ;
   else
   update RetainerMaster set "Retain_Name" = Retain_Name1  ,"Retain_Alias" =Retain_Alias1 ,"Add1" = Add11,"Street" = Street1,"City_Code" =City_Code1 ,"Zip" = Zip1,  "Dist_Code" = Dist_Code1 ,"State_Code" = State_Code1 ,"Zone_Code" = zone_code1,"Region_Code" = region_code1,"Country_Code" = Country_Code1,"Phone1" = phone11,"Phone2" =Phone21,"Fax" =Fax1 ,"EmailID" =EmailID1 ,"PAN_No" = PAN_No1,"Credit_Days" = Credit_Days1,"Remarks" =Remarks1, "pubcent_code"=pubcent, "BOXMATTER"=Box,"PUBLICATION"=Publication1,"EDITION"=Edition1,"SUPPLEMENT"=Supplement1,"TALUKA"=taluka1,REPRESENTATIVE=repname,"Branch_code"=branchcode,CREDIT_LIMIT=creditlimit,MOBILENO=mobile1,"SIGN"=signature,HR_CODE =p_empcode,CDP=p_maincdp where "Comp_Code" = Comp_Code1 and "Retain_Code" = Retain_Code1;
   end if;
    commit;
   End RetainerInsertDetail_P;
 End RetainerInsertDetail;
/




CREATE OR REPLACE procedure ad_acc_name_bind
(
pcompcode in varchar2,
paccname in varchar2,
pextra2 in varchar2,
p_accounts out Cur_Type_New1.cursor_type
)
as


    begin
     open p_accounts for
        select  ACC_NAME,CDP   from fa_acc_mast where ACC_NAME like '%'||paccname||'%' and comp_code=pcompcode;

      
        
    end;
/


/**************************************mimoh************7180********11/april/2012***************************************************************/

***************************** issue 7141 (Complete report)**********************
CREATE OR REPLACE PACKAGE BODY HT18JULY.Rpt_Agencywise_Receipt_untag IS
  PROCEDURE Rpt_Agencywise_Receipt_untag_p(
    pcompcode       in varchar2,
    pfrom_date      in varchar2,
    pto_date        in varchar2,
    pdoctype        in varchar2,
    pagency         in varchar2,
    punit           in varchar2,
    pdateformat     in varchar2,
    p_accounts      out T_Accounts_Cursor)
   AS
    v_val NUMBER:=0;
    query1 varchar2(2000);
    BEGIN
        /*IF pagency IS NOT NULL THEN
            v_val:=Fn_Splitfield(pagency ,';' );
        END IF;*/
        
        query1:=query1||'SELECT doctype AS DOCTYPE,recptno AS RECEIPT_NO,TO_CHAR(recptdt,'''||pdateformat||''') AS RECEIPT_DATE,chno AS CHEQUE_NO ,
        TO_CHAR(chdt,'''||pdateformat||''') AS CHEQUE_DATE,billno AS BILL_NO,TO_CHAR(billdt,'''||pdateformat||''') AS BILL_DATE,TO_CHAR(ABS(amount),''9999999990.90'') AS AMOUNT , agename('''||pcompcode||''',agcode) as "agname" 
        ,(select abs(sum(amount)) from ad_rcpthdr b where b."comp_code"=a.comp_code 
        and b."unit"=a.unit and b."recptno"=a.recptno) as "rec_amt" FROM ad_outstand a
        WHERE  recptno  IS NOT NULL AND  recptdt  IS NOT NULL 
        and billno is null and billdt is null and amount != ''0'' 
        AND (comp_code='''||pcompcode||''' OR '''||pcompcode||''' IS NULL) AND
                        ( doctype ='''||pdoctype||''' OR '''||pdoctype||''' IS NULL) AND  recptdt  BETWEEN '''||pfrom_date||''' AND '''||pto_date||''' AND
                         (unit ='''||punit||''' OR '''||punit||''' IS NULL)
                        AND (agcode ='||''''||pagency||''''||' OR '''||pagency||''' IS NULL)
                        ORDER BY  recptdt,doctype,recptno' ;
                        --WHERE  "Agency_Code"||"SUB_Agency_Code"  IN(SELECT edition_name FROM result)) OR '''||pagency||''' IS NULL)
  delete from ank_search;insert into ank_search values(query1);commit;
  
  OPEN p_accounts FOR
  SELECT a.comp_code comp_code,a.doctype AS DOCTYPE, a.recptno||(select distinct '*' ty  from AD_RCPT_BOOKING_DET where comp_code=a.comp_code and doctype=a.doctype and recptno=a.recptno and recptdt=a.recptdt) AS RECEIPT_NO,TO_CHAR(a.recptdt,pdateformat) AS RECEIPT_DATE,a.chno AS CHEQUE_NO ,
    TO_CHAR(a.chdt,pdateformat) AS CHEQUE_DATE,billno AS BILL_NO,TO_CHAR(billdt,pdateformat) AS BILL_DATE,TO_CHAR(ABS(a.amount),'9999999990.90') AS AMOUNT , substr(agename(a.comp_code,a.agcode),1,30) as "agname",
    (select ABS(sum(b."amount")) from ad_rcpthdr b 
    where b."comp_code"=a.comp_code and b."unit"=a.unit and b."doctype"=a.doctype and b."recptno"=a.recptno) as "rec_amt" 
    FROM ad_outstand a
    WHERE a.comp_code=pcompcode AND (a.unit =punit OR punit IS NULL) and (a.doctype =pdoctype OR pdoctype IS NULL) AND  
    a.recptdt BETWEEN pfrom_date AND pto_date AND a.billno is null and a.billdt is null and a.amount != 0 AND 
    (agcode =pagency OR pagency IS NULL)
    ORDER BY a.comp_code,a.recptdt,a.doctype,a.recptno;

END Rpt_Agencywise_Receipt_untag_p;
END Rpt_Agencywise_Receipt_untag;
/
*********************** end of issue 7141********************************************

//=======================************* Start Procedure Scripts ***************===============//
CREATE OR REPLACE PROCEDURE adb_bindratecode(
    pcompcode       in  varchar2,
    pextra1         in  varchar2,
    pextra2         in  varchar2,
    p_accounts      out cur_type_new1.cursor_type)

AS
begin
    open p_accounts for
  select distinct "Rate_Mast_Code" from rate_mast where "Comp_code"=pcompcode order by "Rate_Mast_Code";
    
end adb_bindratecode;
/
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE websp_modifyMatter is
procedure websp_modifyMatter_p(
cioid in varchar2,
matter_filename in varchar2,
RTFformat in varchar2,
XTGformat in varchar2,
matter in varchar2,
flag in varchar2,
receiptnumber in varchar2,
p_lang  in varchar2
);
end  websp_modifyMatter;
/

CREATE OR REPLACE PACKAGE BODY websp_modifyMatter is
procedure websp_modifyMatter_p(
cioid in varchar2,
matter_filename in varchar2,
RTFformat in varchar2,
XTGformat in varchar2,
matter in varchar2,
flag in varchar2,
receiptnumber in varchar2,
p_lang  in varchar2
)as
begin
if(flag='1') then
update tbl_matter set "RTFformat"=RTFformat,"XTGformat"=XTGformat,"matter"=matter,LANG=p_lang where "cioid"=cioid and "matter_filename"=matter_filename;
else
insert into tbl_matter("cioid","matter_filename","RTFformat","XTGformat","matter","receipt",LANG) values(cioid,matter_filename,RTFformat,XTGformat,matter,receiptnumber,p_lang);
end if;
end websp_modifyMatter_p;
end  websp_modifyMatter;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PACKAGE websp_insertMatter is
procedure websp_insertMatter_p(
cioid            varchar2,
matter_filename  varchar2,
RTFformat        varchar2,
XTGformat        varchar2,
matter           varchar2,
receiptno        varchar2,
p_lang           varchar2
);
end websp_insertMatter;
/

CREATE OR REPLACE PACKAGE BODY websp_insertMatter is
procedure websp_insertMatter_p(
cioid            varchar2,
matter_filename  varchar2,
RTFformat        varchar2,
XTGformat        varchar2,
matter           varchar2,
receiptno        varchar2,
p_lang           varchar2
)as
begin
insert into tbl_matter("cioid","matter_filename","RTFformat","XTGformat","matter","receipt",LANG) values(cioid,matter_filename,RTFformat,XTGformat,matter,receiptno,p_lang);
end websp_insertMatter_p;
end websp_insertMatter;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE pending_for_dummy(
pcompcode       in varchar2,
ppubcenter      in varchar2, 
padtype         in varchar2,
ppubfrdate      in varchar2,
ppubtodate      in varchar2,
ppublcode       in varchar2,
pedtncode       in varchar2,
psuplcode       in varchar2,
preason         in varchar2,--1 for unapproval ,2 for unaduited 3 for material not upload
pdateformat     in varchar2,
puserid         in varchar2,
pextra1         in varchar2,
pextra2         in varchar2,
pextra3         in varchar2,
pextra4         in varchar2,
pextra5         in varchar2,
p_Accounts      OUT Cur_Type_New1.cursor_type)

is
    v_frdt    date;
    v_todt    date;
    
    v_approval_flag varchar2(1);
    
    cursor c1 is
    select distinct x.comp_code AS "COMP_CODE",x.cio_booking_id AS "CIO_BOOKING_ID",x.date_time AS "DATE_TIME",x.agency_code AS "AGENCY_CODE",x.sub_agency_code AS "SUB_AGENCY_CODE" ,x.agency_name AS "AGENCY_NAME",
    x.client_name AS "CLIENT_NAME",x.package_code AS "PACKAGE_CODE",x.package_name AS "PACKAGE_NAME",
    x.ad_cat as "AD_CAT",x.category_name as "CATEGORY_NAME",nvl(x.edition,x.package_name) as "EDITION",x.no_insert "NO_INSERT",
    x.discount as "DISCOUNT",x."AUDIT" AS "AUDIT",x.file_name AS "FILE_NAME",x.reason_type as "REASON_TYPE" from
    (select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    nvl((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",NULL AS "EDITION",1 "NO_INSERT",
    nvl(m."Discount",0)+nvl(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",NULL AS "FILE_NAME",'1' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and (i."Insert_Date" between v_frdt and v_todt) and 
            m."Ad_type_code"=nvl(padtype,m."Ad_type_code") and i."Pub_Cent_Code"=nvl(ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=nvl(ppublcode,i."Publication_Code") and
            i."Edition_Code"=nvl(pedtncode,i."Edition_Code") and i."Supp_Code"=nvl(psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','hold') and
            (nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0))>0 and nvl(m.app_status,'N')='N' and v_approval_flag='D' 
    union
    select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    nvl((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",NULL AS "EDITION",1 "NO_INSERT",
    nvl(m."Discount",0)+nvl(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",NULL AS "FILE_NAME",'2' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and (i."Insert_Date"  between v_frdt and v_todt) and 
            m."Ad_type_code"=nvl(padtype,m."Ad_type_code") and i."Pub_Cent_Code"=nvl(ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=nvl(ppublcode,i."Publication_Code") and
            i."Edition_Code"=nvl(pedtncode,i."Edition_Code") and i."Supp_Code"=nvl(psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','hold') and
            (nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0))>0 and m."audit" is null and nvl(m.app_status,'N')='Y' and v_approval_flag='D'
    union
    select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    nvl((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",NULL AS "EDITION",1 "NO_INSERT",
    nvl(m."Discount",0)+nvl(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",NULL AS "FILE_NAME",'2' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and (i."Insert_Date"  between v_frdt and v_todt) and 
            m."Ad_type_code"=nvl(padtype,m."Ad_type_code") and i."Pub_Cent_Code"=nvl(ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=nvl(ppublcode,i."Publication_Code") and
            i."Edition_Code"=nvl(pedtncode,i."Edition_Code") and i."Supp_Code"=nvl(psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','hold') and
            (nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0))=0 and m."audit" is null and v_approval_flag='Y'
    union
    select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    nvl((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",NULL AS "EDITION",1 "NO_INSERT",
    nvl(m."Discount",0)+nvl(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",NULL AS "FILE_NAME",'2' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and (i."Insert_Date"  between v_frdt and v_todt) and 
            m."Ad_type_code"=nvl(padtype,m."Ad_type_code") and i."Pub_Cent_Code"=nvl(ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=nvl(ppublcode,i."Publication_Code") and
            i."Edition_Code"=nvl(pedtncode,i."Edition_Code") and i."Supp_Code"=nvl(psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','hold') and
            m."audit" is null and v_approval_flag='N'
    union
    select distinct m."Comp_code" AS "COMP_CODE",m."cio_booking_id" AS "CIO_BOOKING_ID",m."date_time" AS "DATE_TIME",a."Agency_Code" AS "AGENCY_CODE",a."SUB_Agency_Code" AS "SUB_AGENCY_CODE" ,a."Agency_Name" AS "AGENCY_NAME",
    nvl((select "Cust_Name" from cust_mast where "Cust_Code"= m."Client_code"),m."Client_code") AS "CLIENT_NAME",i.package_code AS "PACKAGE_CODE",
    (select "Package_Name" from combin_mast where "Combin_Code"=i.package_code) AS "PACKAGE_NAME",
    m."Ad_cat_code" AS "AD_CAT",(select "Adv_Cat_Name" from adv_cat_mast where "Adv_Cat_Code"=i."Ad_Cat") AS "CATEGORY_NAME",i."Edition" AS "EDITION",i."No_Insert" "NO_INSERT",
    nvl(m."Discount",0)+nvl(m."Special_discount",0) as "DISCOUNT",m."audit" AS "AUDIT",i."File_Name" AS "FILE_NAME",'3' as "REASON_TYPE"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and m."Comp_code"=pcompcode and
            m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and (i."Insert_Date"  between v_frdt and v_todt) and 
            m."Ad_type_code"=nvl(padtype,m."Ad_type_code") and i."Pub_Cent_Code"=nvl(ppubcenter,i."Pub_Cent_Code") and i."Publication_Code"=nvl(ppublcode,i."Publication_Code") and
            i."Edition_Code"=nvl(pedtncode,i."Edition_Code") and i."Supp_Code"=nvl(psuplcode,i."Supp_Code") and i."Insert_Status" not in('cancel','hold') and
            m."audit" is not null and i."File_Name" is null) x where reason_type=nvl(preason,reason_type)
            order by reason_type,date_time,cio_booking_id,edition;        
v1 c1%rowtype;
v_rec_count number(5);
BEGIN
    delete from temp_ad_bills_report where sess_id=userenv('sessionid');
    v_approval_flag:='N';
    
    select relauthreqon into v_approval_flag from preferrences where "comp_code"=pcompcode;
    
    v_frdt:=to_date(ppubfrdate,''''||pdateformat||'''');
    v_todt:=to_date(ppubtodate,''''||pdateformat||'''');
    
    Open c1;
    Loop
        Fetch c1 into v1;
        Exit when c1%notfound;
        
        v_rec_count:=nvl(v_rec_count,0)+1;
        
        insert into temp_ad_bills_report(cioid,rodate,client,package_code,adcat,packag,comp_code,padtype,ag_main_code,ag_sub_code,noinsert,clientcd,page_type,page_no,sess_id)
        values(v1.cio_booking_id,v1.date_time,v1.client_name,v1.agency_name,v1.category_name,v1.package_name,v1.comp_code,padtype,v1.agency_code,v1.sub_agency_code,v1.no_insert,v1.edition,v1.reason_type,v_rec_count,userenv('sessionid'));
        
    End loop;
    Close c1;        
    commit;
    
    open p_accounts for
    select comp_code as "COMP_CODE",cioid as "BKID",to_char(rodate,''||pdateformat||'') as "BK_DATE",client as "CLIENT_NAME",package_code as "AGENCY_NAME",adcat as "CAT_NAME",
    packag as "PACKAGE_NAME",padtype as "AD_TYPE",ag_main_code as "AG_MAIN_CODE",ag_sub_code as "AG_SUB_CODE",noinsert as "NOINSERT",
    clientcd as "EDITION",page_type as "REASON_TYPE",page_no as "REC_NO"
    from temp_ad_bills_report where sess_id=userenv('sessionid') order by rec_no;
    
    delete from temp_ad_bills_report where sess_id=userenv('sessionid');commit;
END pending_for_dummy;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE procedure getapprovalRo_web(
    vusername       in varchar2,
    compcode        in varchar2,
    agency          in varchar2,
    executive       in varchar2,
    client          in varchar2,
    varFromDate     in date,
    varToDate       in date,
    dateformat      in varchar2,
    cioid           in varchar2,
    flag            in varchar2,
    pbranch         in varchar2,
    pdate_based_on  in varchar2,--for Booking date B,Publish Date P
    P_Accounts      OUT Cur_Type_New1.cursor_type) is

relauthreq          varchar2(1);
V_QUERY             VARCHAR(8000);
v_distcount_allowed number(12,2);
V_approval_with     varchar2(1);
v_login_hr_code         varchar2(50);
v_login_exec_team       varchar2(50);
begin

    select relauthreqon,approval_with into relauthreq,V_approval_with from preferrences where "comp_code"=compcode;
   
    select nvl(discount,'0'),hr_code into v_distcount_allowed,v_login_hr_code from login where "userid"=vusername;
    
    select min("Team_code") into v_login_exec_team from exec_mast where "comp_code"=compcode and hr_code=v_login_hr_code;

   
    V_QUERY:='SELECT distinct m."Comp_code",a."Agency_Name" as "AGENCY",(select "City_Name" from city_mst where "City_Code"=a."City_Code") as "CITY_NAME",
    (select "Retain_Name" from retainermaster where "Comp_Code"=m."Comp_code" and "Retain_Code"=m.retainer) as "RETAINER_NAME",
    (select "Exec_name" from EXEC_MAST where "comp_code"=m."Comp_code" and to_char("Exe_no")=m."Executive_code") as "EXECUTIVE_NAME",
    (select "Package_Name" from combin_mast where "Comp_Code"=m."Comp_code" and "Combin_Code"=(
    case when instr(''abcdef'','','') >0 then substr(m."Package_code",1,instr(m."Package_code",'','')-1) 
    else m."Package_code" end)) as "PACKAGE",
    case when '''||dateformat||'''=''dd/mm/yyyy'' then to_char(m."date_time",''dd/mm/yy'')
    when '''||dateformat||'''=''yyyy/mm/dd'' then to_char(m."date_time",''yy/mm/dd'')
    else to_char(m."date_time",''mm/dd/yy'') end as "BOOKDATE",
    (select "Cust_Name" from cust_mast where "Comp_Code"=m."Comp_code" and "Cust_Code"= m."Client_code") as "CLIENT",
    m."RO_No" as "RO_NO",
    case when '''||dateformat||'''=''dd/mm/yyyy'' then to_char(m."RO_Date",''dd/mm/yy'')
    when '''||dateformat||'''=''yyyy/mm/dd'' then to_char(m."RO_Date",''yy/mm/dd'')
    else to_char(m."RO_Date",''mm/dd/yy'') end as "RODATE",
    (select "Exec_name" from exec_mast where  to_char("Exe_no") = m."Executive_code") as "EXECUTIVE",
    (select "Retain_Name" from retainermaster where "Comp_Code"=m."Comp_code" and "Retain_Code"= m."RETAINER") as "RETAINER",
    m."Card_rate" as "CARD_RATE",Fn_Deviatio(m."Card_rate",m."Agrred_rate") as "DEVIATION",m."cio_booking_id" as "CIO_BOOKING_ID",
    m."Bill_amount" as "BILL_AMOUNT",m."Gross_amount" as "GROSS_AMOUNT",
    (select "premiumname" from advpos_prem_mast where "comp_code"=m."Comp_code" and "Premiumcode"=m."Page_prem") as "PAGEPERM",
    m.app_status as "APP_STATUS",m."booked_by" as "BOOKED_BY",
    (select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=m."Comp_code" and "Pay_Mode_Code"=m."Agency_pay") as "PAYMODE",
    m."Receipt_no" as "RECEIPT_NO",m."Ad_cat_code" as "AD_CAT_CODE",(select "Adv_Cat_Name" from adv_cat_mast where "Comp_Code"=m."Comp_code" and "Adv_Cat_Code"=m."Ad_cat_code") as "AD_CAT_NAME",
    m."Color_code" as "COLOR_CODE",(select "Col_Name" from col_mast where "Comp_Code"=m."Comp_code" and "Col_Code"=m."Color_code") as "COLOR_NAME",
    m."Card_amount" as "CARD_AMOUNT",m."Agrred_rate" as "AGRRED_RATE",m."Agreed_amount" as "AGREED_AMOUNT",
    m."Ad_size_height" as "AD_SIZE_HEIGHT",m."Ad_size_width" as "AD_SIZE_WIDTH",(m."Ad_size_height"*m."Ad_size_width") as "SIZE_BOOK",
    to_char(min(i."Insert_Date"),'''||dateformat||''') as "FIRST_INSDATE",to_char(max(i."Insert_Date"),'''||dateformat||''') as "LAST_INSDATE",m.ATTACHMENT1 as "ATTACHMENT",m."Page_no" as "PAGE_NO"
        from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
    where m."Comp_code"='''||compcode||''' and m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode"
    and ((Fn_Deviatio(m."Card_rate",m."Agrred_rate") is not null and Fn_Deviatio(m."Card_rate",m."Agrred_rate") != ''0'') OR Fn_chkSalesExec(m."Userid")=''SE0'' OR '''||relauthreq||''' = ''A'')
    and m."Agency_sub_code" = nvl('''||agency||''',m."Agency_sub_code") and (m."Executive_code" = '''||executive||'''  OR '''||executive||''' IS NULL)
    and (m."Client_code" = '''||client||'''  OR '''||client||''' IS NULL)
    and m."cio_booking_id" = nvl('''||cioid||''',m."cio_booking_id" )
    and (nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)) between nvl((select max(nvl(discount,''0'')) from login where "userid"<>'''||vusername||''' and to_number(nvl(discount,''0''))<'||v_distcount_allowed||'),1) and '||v_distcount_allowed||' ';
   
    if flag ='A' then--for Approval
        v_query:=v_query||' and m.app_status=''Y'' ';
    elsif flag ='R' then-- for rejected    
        v_query:=v_query||' and m.app_status=''N'' ';
    else--pending for approval and rejected
        v_query:=v_query||' and nvl(m.app_status,''#'')!=''Y'' and nvl(m.app_status,''#'')!=''N'' ';
    end if;
   
    if pdate_based_on='P' then--On Published date
        v_query:=v_query||' and i."Insert_Date" between '''||varfromdate||''' and '''||vartodate||'''';
    else--on Booking date
        v_query:=v_query||' and m."date_time" between '''||varfromdate||''' and '''||vartodate||'''';
    end if;
    
    if pbranch ='B' then--If B then Data will show Acc. to Branch Permission
        v_query:=v_query||' AND m."branch" in(select ltrim(rtrim(branch_code)) from login_branch_mast where user_code='''||vusername||''' and comp_code='''||compcode||''' and user_flag=''Y'')';
    end if;
   
   -- If nvl(v_approval_with,'D')='T' and v_login_exec_team is not null then --approval with discounting
   --     v_query:=v_query||' AND (select distinct "Team_code" from exec_mast where "comp_code"=m."Comp_code" and to_char("Exe_no")=m."Executive_code")='''||v_login_exec_team||'''';
   -- End if;
    v_query:=v_query||' group by m."Comp_code",a."Agency_Name",m."Package_code",m."date_time", m."Client_code",m."RO_No",m."RO_Date",m."Executive_code",m."RETAINER",
                    m."Card_rate",m."cio_booking_id",m."Bill_amount",m."Gross_amount",m."Page_prem",m.app_status,m."booked_by",m."Agency_pay",
                    m."Receipt_no",m."Ad_cat_code",m."Ad_cat_code",m."Color_code",m."Card_amount",m."Agrred_rate",m."Agreed_amount",
                    m."Ad_size_height",m."Ad_size_width",m.retainer,m."Executive_code",a."City_Code",m.ATTACHMENT1,m."Page_no"
                    ORDER BY bookdate DESC,m."cio_booking_id"';
   
   --INSERT INTO TEST1(VSTRING,VSTRING2) VALUES('getapprovalRo_web ',V_QUERY);COMMIT;
   
    open P_Accounts for V_QUERY;
   
/*if flag ='A' then
    open P_Accounts for
    SELECT distinct a."Agency_Name" as "AGENCY",
    (select "Package_Name" from combin_mast where "Comp_Code"=compcode and "Combin_Code"=(
    case when instr('abcdef',',') >0 then substr(m."Package_code",1,instr(m."Package_code",',')-1) 
    else m."Package_code" end)) as "PACKAGE",
    case when dateformat='dd/mm/yyyy' then to_char(m."date_time",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."date_time",'yy/mm/dd')
    else to_char(m."date_time",'mm/dd/yy') end as "BOOKDATE",
    (select "Cust_Name" from cust_mast where "Comp_Code"=compcode and "Cust_Code"= m."Client_code") as "CLIENT",
    m."RO_No" as "RO_NO",
    case when dateformat='dd/mm/yyyy' then to_char(m."RO_Date",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."RO_Date",'yy/mm/dd')
    else to_char(m."RO_Date",'mm/dd/yy') end as "RODATE",
    (select "Exec_name" from exec_mast where  to_char("Exe_no") = m."Executive_code") as "EXECUTIVE",
    (select "Retain_Name" from retainermaster where "Comp_Code"=compcode and "Retain_Code"= m."RETAINER") as "RETAINER",
    m."Card_rate" as "CARD_RATE",Fn_Deviatio(m."Card_rate",m."Agrred_rate") as "DEVIATION",m."cio_booking_id" as "CIO_BOOKING_ID",
    m."Bill_amount" as "BILL_AMOUNT",m."Gross_amount" as "GROSS_AMOUNT",
    (select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=m."Page_prem") as "PAGEPERM",
    m.app_status as "APP_STATUS",m."booked_by" as "BOOKED_BY",
    (select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=m."Agency_pay") as "PAYMODE",
    m."Receipt_no" as "RECEIPT_NO",m."Ad_cat_code" as "AD_CAT_CODE",(select "Adv_Cat_Name" from adv_cat_mast where "Comp_Code"=m."Comp_code" and "Adv_Cat_Code"=m."Ad_cat_code") as "AD_CAT_NAME",
    m."Color_code" as "COLOR_CODE", m."Card_amount" as "CARD_AMOUNT",m."Agrred_rate" as "AGRRED_RATE",m."Agreed_amount" as "AGREED_AMOUNT",
    m."Ad_size_height" as "AD_SIZE_HEIGHT",m."Ad_size_width" as "AD_SIZE_WIDTH",(m."Ad_size_height"*m."Ad_size_width") as "SIZE_BOOK",
    min(i."Insert_Date") as "FIRST_INSDATE",max(i."Insert_Date") as "LAST_INSDATE"
        from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
    where m."Comp_code"=compcode and m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
    m."branch"=nvl(pbranch,m."branch") and m.app_status='Y'
    and (Fn_Deviatio(m."Card_rate",m."Agrred_rate") is not null OR Fn_chkSalesExec(m."Userid")='SE0' OR relauthreq = 'A')
    and m."Agency_sub_code" = nvl(agency,m."Agency_sub_code") and (m."Executive_code" = executive  OR executive IS NULL)
    and (m."Client_code" = client  OR client IS NULL) and m."date_time" between varfromdate and vartodate
    and m."cio_booking_id" = nvl(cioid,m."cio_booking_id")
    group by a."Agency_Name",m."Package_code",m."date_time", m."Client_code",m."RO_No",m."RO_Date",m."Executive_code",m."RETAINER",
    m."Card_rate",m."cio_booking_id",m."Bill_amount",m."Gross_amount",m."Page_prem",m.app_status,m."booked_by",m."Agency_pay",
    m."Receipt_no",m."Ad_cat_code",m."Ad_cat_code",m."Color_code",m."Card_amount",m."Agrred_rate",m."Agreed_amount",
    m."Ad_size_height",m."Ad_size_width"
    ORDER BY m."date_time" DESC,m."cio_booking_id";
elsif flag ='R' then
    open P_Accounts for
    SELECT distinct a."Agency_Name" as agency,
    (select "Package_Name" from combin_mast where "Comp_Code"=compcode and "Combin_Code"=(
    case when instr('abcdef',',') >0 then substr(m."Package_code",1,instr(m."Package_code",',')-1) 
    else m."Package_code" end)) as Package,
    case when dateformat='dd/mm/yyyy' then to_char(m."date_time",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."date_time",'yy/mm/dd')
    else to_char(m."date_time",'mm/dd/yy') end as bookdate,
    (select "Cust_Name" from cust_mast where "Comp_Code"=compcode and "Cust_Code"= m."Client_code") as client,
    m."RO_No",case when dateformat='dd/mm/yyyy' then to_char(m."RO_Date",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."RO_Date",'yy/mm/dd')
    else to_char(m."RO_Date",'mm/dd/yy') end as rodate,
    (select "Exec_name" from exec_mast where to_char("Exe_no") = m."Executive_code") as executive,
    (select "Retain_Name" from retainermaster where "Comp_Code"=compcode and "Retain_Code"= m."RETAINER") retainer,m."Card_rate" as "Card_rate",
    Fn_Deviatio(m."Card_rate",m."Agrred_rate") as deviation,m."cio_booking_id",m."Bill_amount" as "Bill_amount",m."Gross_amount" as "Gross_amount",
    (select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=m."Page_prem") as PAGEPERM,m.APP_STATUS as "APP_STATUS",m."booked_by" as "booked_by",
    (select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=m."Agency_pay") as "paymode",m."Receipt_no" "Receipt_no"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
    where m."Comp_code"=compcode and m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
    m."branch"=nvl(pbranch,m."branch") and m.app_status='N' 
    and (Fn_Deviatio(m."Card_rate",m."Agrred_rate") is not null OR Fn_chkSalesExec(m."Userid")='SE0' OR  RELAUTHREQ = 'A')
    AND (m."Agency_sub_code" = agency  OR agency IS NULL)
    AND (m."Executive_code" = executive  OR executive IS NULL)
    AND (m."Client_code" = client  OR client IS NULL)
    and m."date_time" between varfromdate and vartodate
    AND (m."cio_booking_id" = cioid  OR cioid IS NULL)
    ORDER BY m."date_time" DESC,m."cio_booking_id";
else
    open P_Accounts for
    SELECT distinct a."Agency_Name" as agency,
    (select "Package_Name" from combin_mast where "Comp_Code"=compcode and "Combin_Code"=(
    case when instr('abcdef',',') >0 then substr(m."Package_code",1,instr(m."Package_code",',')-1) 
    else m."Package_code" end)) as Package,
    case when dateformat='dd/mm/yyyy' then to_char(m."date_time",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."date_time",'yy/mm/dd')
    else to_char(m."date_time",'mm/dd/yy') end as bookdate,
    (select "Cust_Name" from cust_mast where "Comp_Code"=compcode and "Cust_Code"= m."Client_code") client,m."RO_No" as "RO_No",
    case when dateformat='dd/mm/yyyy' then to_char(m."RO_Date",'dd/mm/yy')
    when dateformat='yyyy/mm/dd' then to_char(m."RO_Date",'yy/mm/dd')
    else to_char(m."RO_Date",'mm/dd/yy') end as rodate,
    (select "Exec_name" from exec_mast where "Exe_no" = m."Executive_code") as executive,
    (select "Retain_Name" from retainermaster where "Comp_Code"=compcode and "Retain_Code"= m."RETAINER") retainer,m."Card_rate" as "Card_rate",
    Fn_Deviatio(m."Card_rate",m."Agrred_rate") as deviation,m."cio_booking_id",m."Bill_amount" as "Bill_amount",m."Gross_amount" as "Gross_amount",
    (select "premiumname" from advpos_prem_mast where "comp_code"=compcode and "Premiumcode"=m."Page_prem") as "PAGEPERM",
    m.APP_STATUS as "APP_STATUS",m."booked_by" as "booked_by",
    (select "Payment_Mode_Name" from payment_mode_mast where "Comp_Code"=compcode and "Pay_Mode_Code"=m."Agency_pay") as "paymode",m."Receipt_no" as "Receipt_no"
    from tbl_booking_mast m,tbl_booking_insert i,agency_mast a
    where m."Comp_code"=compcode and m."Comp_code"=i."Comp_Code" and m."Comp_code"=a."Comp_Code" and
    m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
    m."branch"=nvl(pbranch,m."branch") and nvl(m.app_status,'#')!='Y' and nvl(m.app_status,'#')!='N' 
    and (Fn_Deviatio(m."Card_rate",m."Agrred_rate") is not null OR Fn_chkSalesExec(m."Userid")='SE0' OR  RELAUTHREQ = 'A')
    AND (m."Agency_sub_code" = agency  OR agency IS NULL)
    AND (m."Executive_code" = executive  OR executive IS NULL)
    AND (m."Client_code" = client  OR client IS NULL)
    and m."date_time" between varFromDate and varToDate
    AND (m."cio_booking_id" = cioid  OR cioid IS NULL)
    ORDER BY m."date_time" DESC,m."cio_booking_id" ;
end if;*/

End getapprovalRo_web;
/


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//=======================************* End of Procedure Scripts ***************===============//


//=======================************* Start Procedure Scripts ***************===============//
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
    extra1          in varchar2,--for UOM
    extra2          in varchar2,
    extra3          in varchar2,
    extra4          in varchar2,
    P_ACCOUNT       OUT T_ACCOUNT_CURSOR)
AS

v_branch1       varchar2(50);
v_branch2       varchar2(50);
v_approval_req  varchar2(1);
BEGIN
     --INSERT INTO test1(vstring)VALUES (   'fromdate '|| fromdate|| ' todate '|| todate|| ' date1 '|| date1|| ' BRANCH1 '|| branch1|| ' Adtype '|| adtype|| ' audittype '|| audittype|| ' branch2 '|| branch2|| ' v_Cat '|| v_cat|| ' v_userid '|| v_userid);COMMIT;
    If branch1 = 'All' then
        v_branch1 := null;
    Else
        v_branch1 := branch1;
    End if;
    
    If branch2 = 'All' then
        v_branch2 := null;
    Else
        v_branch2 := branch2;    
    End if;
    v_approval_req:='N';
    
    select relauthreqon into v_approval_req from preferrences where "comp_code"=comp_code;
    
    IF audittype = 'audit' THEN
        OPEN p_account FOR
        SELECT distinct m."cio_booking_id" as "cio_booking_id",
        NVL ((SELECT distinct  "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),
        m."Client_code") AS "Client_code",
        m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",m."Receipt_no" as "Receipt_no",
        (SELECT distinct "File_Name" FROM tbl_booking_insert
        WHERE "Cio_Booking_Id" =m."cio_booking_id" AND "File_Name" IS NOT NULL AND ROWNUM <= 1) AS "FILENAME",
        CASE date1 WHEN 'mm/dd/yyyy' THEN TO_CHAR(m."Creation_datetime",'mm/dd/yyyy')
            WHEN 'dd/mm/yyyy' THEN TO_CHAR (m."Creation_datetime", 'dd/mm/yyyy')
            WHEN 'yyyy/mm/dd' THEN TO_CHAR (m."Creation_datetime", 'yyyy/mm/dd')
        END AS "Creation_datetime",m.ATTACHMENT1 as ATTACHMENT,
        AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'A') as "Agency_Remark",
        AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'C') as "Client_Remark",
        case when v_approval_req='N' then 'Y' else 
            case when nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)=0 then 'Y' else nvl(m.app_status,'N') end 
        end as "APPROVAL_FLAG",TO_CHAR(m."Insertion_date",date1) as "INSERT_DATE",m."Insertion_date" dd
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
        and m."Uom_code"=nvl(extra1,m."Uom_code")
        order by m."Insertion_date",m."cio_booking_id";
    END IF;

    IF audittype = 'unaudit' or audittype is null THEN
        OPEN p_account FOR
            SELECT distinct m."cio_booking_id" as "cio_booking_id",
            NVL ((SELECT distinct "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),
            m."Client_code") AS "Client_code",
            m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",m."Receipt_no" as "Receipt_no",
            (SELECT distinct  "File_Name" FROM tbl_booking_insert
            WHERE "Cio_Booking_Id" =m."cio_booking_id"
            AND "File_Name" IS NOT NULL
            AND ROWNUM <= 1) AS "FILENAME",
            CASE date1 WHEN 'mm/dd/yyyy' THEN TO_CHAR(m."Creation_datetime",'mm/dd/yyyy')
                WHEN 'dd/mm/yyyy' THEN TO_CHAR (m."Creation_datetime", 'dd/mm/yyyy')
                WHEN 'yyyy/mm/dd' THEN TO_CHAR (m."Creation_datetime", 'yyyy/mm/dd')
            END AS "Creation_datetime",m.ATTACHMENT1 as ATTACHMENT,
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'A') as "Agency_Remark",
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'C') as "Client_Remark",
            case when v_approval_req='N' then 'Y' else 
                case when nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)=0 then 'Y' else nvl(m.app_status,'N') end 
            end as "APPROVAL_FLAG",TO_CHAR(m."Insertion_date",date1) as "INSERT_DATE",m."Insertion_date" dd
            FROM tbl_booking_mast m,tbl_booking_insert i,branch_mst b,login_branch_mast lb
            WHERE m."cio_booking_id" =i."Cio_Booking_Id"
            and m."Agency_sub_code"= nvl(pagency_code,m."Agency_sub_code")
            AND m."Ad_type_code" = adtype
            AND m."branch" = nvl(v_branch2,m."branch")
            AND m."branch"= b."Branch_Code"
            and m."branch"= lb.branch_code
            and m."Client_code"= nvl(pclient_code,m."Client_code")
            and m."date_time" BETWEEN fromdate AND todate
            AND m."audit" IS NULL AND m."ro_status"='1'
            AND m."Ad_cat_code" = nvl(v_cat,m."Ad_cat_code")
            AND lb.user_code = v_userid
            AND NVL (lb.user_flag, 'N') = 'Y'
            AND b."pub_center" = nvl(v_branch1,b."pub_center")
            and (i."PACKAGE_CODE"= v_package_code or v_package_code is null )
            and (i."SECTIONCODE"= psection_code or psection_code is null)
            and nvl(m.modified_audit,'N')!='Y' and exists (select "userid" from login where "userid"=m."Userid" and
            ((nvl("Agency_code",'0')<>'0' and nvl(p_booktype,'A') ='Q') or
            (nvl("Agency_code",'0')='0' and nvl(p_booktype,'A') ='D') or nvl(p_booktype,'A') ='A'))
            AND m."Uom_code"=nvl(extra1,m."Uom_code")
            order by m."Insertion_date",m."cio_booking_id";
    END IF;

    IF audittype = 'modified' THEN
        OPEN p_account FOR
            SELECT distinct m."cio_booking_id" as "cio_booking_id",
            NVL ((SELECT distinct "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),
            m."Client_code") AS "Client_code",
            m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",m."Receipt_no" as "Receipt_no",
            (SELECT distinct  "File_Name" FROM tbl_booking_insert
            WHERE "Cio_Booking_Id" =m."cio_booking_id"
            AND "File_Name" IS NOT NULL
            AND ROWNUM <= 1) AS "FILENAME",
            CASE date1 WHEN 'mm/dd/yyyy' THEN TO_CHAR(m."Creation_datetime",'mm/dd/yyyy')
                WHEN 'dd/mm/yyyy' THEN TO_CHAR (m."Creation_datetime", 'dd/mm/yyyy')
                WHEN 'yyyy/mm/dd' THEN TO_CHAR (m."Creation_datetime", 'yyyy/mm/dd')
            END AS "Creation_datetime",m.ATTACHMENT1 as ATTACHMENT,
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'A') as "Agency_Remark",
            AD_GETAGENCY_ADD(comp_code,m."cio_booking_id",'C') as "Client_Remark",
            case when v_approval_req='N' then 'Y' else 
                case when nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)=0 then 'Y' else nvl(m.app_status,'N') end 
            end as "APPROVAL_FLAG",TO_CHAR(m."Insertion_date",date1) as "INSERT_DATE",m."Insertion_date" dd
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
            AND m."Uom_code"=nvl(extra1,m."Uom_code")
            order by m."Insertion_date",m."cio_booking_id";
    END IF;

   END bindaudit_p;
END bindaudit;
/


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
/* Formatted on 2012/04/11 00:45 (Formatter Plus v4.8.8) */
CREATE OR REPLACE FUNCTION fetch_unpublish_edtn (
   pcompcode         VARCHAR2,
   pcioid            VARCHAR2,
   pinsertion_no     INT,
   pinsertion_type   VARCHAR2, --1 for single insertion or 2 for all insertion
   pshowedtn         VARCHAR2,            --for Y show edtn and N for NOt show
   pextra1           VARCHAR2,
   pextra2           VARCHAR2
)
   RETURN VARCHAR2
AS
   v_val    VARCHAR2 (2000);
   v_edtn   VARCHAR2 (200);

   CURSOR c1
   IS
      SELECT DISTINCT "Edition" edtn
                 FROM tbl_booking_insert
                WHERE "Comp_Code" = pcompcode
                  AND "Cio_Booking_Id" = pcioid
                  AND "No_Insert" = pinsertion_no
                  AND "Insert_Status" IN ('booked', 'hold')
                  AND bill_no IS NULL
                  AND pinsertion_type = '1'
      UNION
      SELECT DISTINCT "Edition" edtn
                 FROM tbl_booking_insert
                WHERE "Comp_Code" = pcompcode
                  AND "Cio_Booking_Id" = pcioid
                  AND "Insert_Status" IN ('booked', 'hold')
                  AND bill_no IS NULL
                  AND pinsertion_type = '2';

   v1       c1%ROWTYPE;
BEGIN
   IF NVL (pshowedtn, 'N') = 'Y'
   THEN
      OPEN c1;

      LOOP
         FETCH c1
          INTO v1;

         EXIT WHEN c1%NOTFOUND;
         v_edtn := v1.edtn;

         IF (v_val IS NULL)
         THEN
            v_val := v_edtn;
         ELSE
            v_val := v_val || ',' || v_edtn;
         END IF;
      END LOOP;

      CLOSE c1;
   ELSE
      SELECT SUM (x.edtn) edtn
        INTO v_val
        FROM (SELECT COUNT (DISTINCT "Edition") edtn
                FROM tbl_booking_insert
               WHERE "Comp_Code" = pcompcode
                 AND "Cio_Booking_Id" = pcioid
                 AND "No_Insert" = pinsertion_no
                 AND "Insert_Status" IN ('booked', 'hold')
                 AND bill_no IS NULL
                 AND pinsertion_type = '1'
              UNION
              SELECT COUNT (DISTINCT "Edition") edtn
                FROM tbl_booking_insert
               WHERE "Comp_Code" = pcompcode
                 AND "Cio_Booking_Id" = pcioid
                 AND "Insert_Status" IN ('booked', 'hold')
                 AND bill_no IS NULL
                 AND pinsertion_type = '2') x;
   END IF;

   RETURN v_val;
END fetch_unpublish_edtn;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE WEBSP_BINDCIOIDNEW1(
FROMDATE            IN VARCHAR2,
TODATE              IN VARCHAR2,
DATE1               IN VARCHAR2,
PUBLICATION         IN VARCHAR2,
BOOKINGCENTER       IN VARCHAR2,
REVENUECENTER       IN VARCHAR2,
AGENCYTYPE          IN VARCHAR2,
PACKAGE1            IN VARCHAR2,
ADTYPE1             IN VARCHAR2,
AGENCY              IN VARCHAR2,
CLIENT              IN VARCHAR2,
BILLSTATUS          IN VARCHAR2,
RATE_AUDIT          IN VARCHAR2,
BILLMODE            IN VARCHAR2,
BILLCYCLE           IN VARCHAR2,
V_RETAINER_NAME     IN VARCHAR2,
V_EXECUTIVE_NAME    IN VARCHAR2,
V_BRANCH_NAME       IN VARCHAR2,
V_AD_CATEGORY       IN VARCHAR2,
V_DISTRICT          IN VARCHAR2,
V_TALUKA            IN VARCHAR2,
PCOMPCODE           IN  VARCHAR2,
P_BILLNO            IN VARCHAR2,
P_BILL_GEN_PRIOR    IN VARCHAR2,
P_CENTERLOGIN       IN VARCHAR2,
P_PUB_CENT_HO       IN VARCHAR2,
P_FMG_BILL          IN VARCHAR2,
P_SCHEME_TYPE       IN VARCHAR2,
PTO_BILL_NO         IN VARCHAR2,
P_UOM               IN VARCHAR2,
PEXCLUDE_RATE_CODE  IN VARCHAR2,
P_RECORDSET         OUT CUR_TYPE_NEW1.CURSOR_TYPE,
P_RECORDSET1        OUT CUR_TYPE_NEW1.CURSOR_TYPE)

IS

query1      VARCHAR2(10000);
v_wherecl   VARCHAR2(2000);

v_bill_criteria varchar2(10);
v_dateformat    varchar2(100);
v_chkdt         date;
last_billno     number(10);
v_last_dt       date;
v_billed            number(10);
v_booked_by_others  number(10);
BEGIN
    if adtype1='DI0' then
        select disp_billing_criteria,"date_format" into v_bill_criteria,v_dateformat from preferrences where "comp_code"=pcompcode;
    else
        select clsd_billing_criteria,"date_format" into v_bill_criteria,v_dateformat from preferrences where "comp_code"=pcompcode;
    end if;
    
    IF(billstatus='3' AND rate_audit='n')
    THEN

      query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
      nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
      a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
      i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",
       i.BILL_NO
       ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
      FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"  AND
       i."Insert_Status"=''publish'' AND a."code_subcode"=m."Agency_sub_code" and m."audit" is not null 
       and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;


     IF(billstatus='3' AND rate_audit='y')
    THEN

          query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
     nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where
    cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",
           fetch_unpublish_edtn('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",''1'',''N'',null,null) as "UNPUBLISHED"

          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"  AND
           i."Insert_Status"=''audit by rate'' AND a."code_subcode"=m."Agency_sub_code" and m."audit" is not null 
           and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='1' AND rate_audit='y'AND billmode='2')
    THEN

     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
     nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where
    cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",
           i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where m."Comp_code"='''||pcompcode||''' and i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
    AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status" =''audit by rate'' OR i."Insert_Status"=''billed'') and m."audit" is not null
    and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='1' AND rate_audit='n' AND billmode='2')
    THEN
     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",
           i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status" =''publish'' OR i."Insert_Status"=''billed'')  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='1' AND rate_audit='n' AND (billmode='1' OR billmode='3'))
    THEN
     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
          (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where m."Comp_code"='''||pcompcode||''' and i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status"=''billed'')  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='1' AND rate_audit='y' AND (billmode='1' OR billmode='3'))
    THEN

     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end  AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status"=''billed'')  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='3' AND rate_audit='n' AND (billmode='1' OR billmode='3'))
    THEN

     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end  AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status"=''billed'')  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='3' AND rate_audit='y' AND (billmode='1' OR billmode='3'))
    THEN

     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"
        AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status"=''billed'')  and m."audit" is not null
        and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus=2)
    THEN
     query1:=' SELECT DISTINCT  i."Cio_Booking_Id",i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition" ,
    nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
    a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
    i."Insert_Status" AS "status",m."No_of_insertion" AS  "total",m."Bill_remarks",i.BILL_NO
    ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
    FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"  AND
     i."Insert_Status"=''billed'' AND a."code_subcode"=m."Agency_sub_code"  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
    END IF;



    IF(billstatus='5')
    THEN

      query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
      nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
      a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
      i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
      ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
      FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"  AND
       i."Insert_Status"=''publish'' AND a."code_subcode"=m."Agency_sub_code"  and m."audit" is not null
       and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;


    IF(billstatus=6)
    THEN
     query1:=' SELECT DISTINCT  i."Cio_Booking_Id",i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition" ,
    nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
    a."Agency_Name" AS "Agency",
    i."Insert_Status" AS "status",m."No_of_insertion" AS  "total",m."Bill_remarks",i.BILL_NO
    ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
    FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"  AND
     i."Insert_Status"=''booked'' AND a."code_subcode"=m."Agency_sub_code" 
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
    END IF;

    IF(v_retainer_name  IS NOT NULL)
    THEN
     v_wherecl:= v_wherecl ||' and m."RETAINER" ='''||v_retainer_name ||'''';
    END IF;


    IF(v_executive_name IS NOT NULL)
    THEN
     v_wherecl:= v_wherecl||' and m."Executive_code" ='''||v_executive_name ||'''';
    END IF;


    IF(v_branch_name  IS NOT NULL and v_branch_name <> 0)
    THEN
     v_wherecl:= v_wherecl ||' and m."branch" ='''||v_branch_name ||'''';
    END IF;


    IF(v_ad_category  IS NOT NULL)
    THEN
     v_wherecl:= v_wherecl ||' and m."Ad_cat_code" ='''||v_ad_category||'''';
    END IF;


    IF(v_district  IS NOT NULL)
    THEN
     v_wherecl:= v_wherecl ||' and m."Agency_sub_code"  in (select agency_mast."code_subcode" from agency_mast where agency_mast."Dist_Code" ='''||v_district||''' or '''||v_district||''' is null)';
    END IF;


    IF(v_taluka IS NOT NULL)
    THEN
     v_wherecl:= v_wherecl||'  AND m."Agency_sub_code"  in (select agency_mast."code_subcode" from agency_mast where (agency_mast."Dist_Code"  in(select DIST_CODE from taluka_mast where TALU_CODE='''||v_taluka||''' or '''||v_taluka||''' is null) )  AND agency_mast."Dist_Code"='''||v_district||''' OR '''||v_district||'''  IS NULL   )';
    END IF;

    if v_bill_criteria='A' then
        IF(billcycle IS NOT NULL)
        THEN
            v_wherecl:=v_wherecl ||' AND a."BILL_FREQUENCY"='''||billcycle ||'''';
        END IF;
    elsif v_bill_criteria='R' then

        IF(billcycle IS NOT NULL)
        THEN
            v_wherecl:=v_wherecl ||' AND m."Bill_cycle" ='''||billcycle ||'''';
        END IF;
    end if;
    
    IF(agency IS NOT NULL)
    THEN
    v_wherecl:=v_wherecl ||' AND m."Agency_sub_code" ='''||agency ||'''';
    END IF;

    IF(client IS NOT NULL)
    THEN
    v_wherecl:=v_wherecl ||' AND m."Client_code" ='''||client ||'''';
    END IF;


    IF(agencytype IS NOT NULL) THEN
        v_wherecl:=v_wherecl ||' AND m."Agency_type"  ='''||trim(agencytype)||'''';
    END IF;
    
    IF(adtype1 IS NOT NULL) THEN
        v_wherecl:=v_wherecl ||' AND m."Ad_type_code" ='''||adtype1||''' ';
    END IF;


    IF(bookingcenter  IS NOT NULL) THEN
        v_wherecl:=v_wherecl ||' AND exists(select ''x'' from branch_mst where "Branch_Code"=m."branch" and "pub_center" ='''||bookingcenter||''') ';
    END IF;

    if (P_FMG_BILL !='Include') then

        v_wherecl:=v_wherecl ||' AND m."Booking_type" not in (''2'',''4'',''5'')';

    end if;

    if(P_SCHEME_TYPE='EXCLUDE') THEN

        v_wherecl:=v_wherecl ||' AND i."Pai_Free_Ins"  in (''Y'')';

    END IF;

    IF(revenuecenter IS NOT NULL) THEN

        v_wherecl:=v_wherecl ||' AND m."Revenue_center" ='''||revenuecenter||''' ';
    
    END IF;

    IF(publication IS NOT NULL)
    THEN
        v_wherecl:=v_wherecl ||'AND  i."Publication_Code"='''||publication ||'''';
    END IF;

    if (P_BILLNO is not null) and (pto_bill_no is not null) then
       v_wherecl:=v_wherecl ||'AND  i.BILL_NO between '''||P_BILLNO||''' and '''||pto_bill_no||'''';
    END IF;



    IF(fromdate IS NOT NULL AND todate IS NOT NULL )
    THEN
        v_wherecl:=v_wherecl ||'  AND i."Insert_Date" BETWEEN  '''||fromdate ||''' AND  '''||todate ||''' ';
    END IF;
    
    if (P_UOM is not null) then
       v_wherecl:=v_wherecl ||'AND  m."Uom_code" = '''||P_UOM||'''';
    END IF;


    IF(PACKAGE1 IS NOT NULL)
    THEN
        v_wherecl:=v_wherecl ||' AND  i."Edition" ='''||PACKAGE1 ||'''';
    END IF;
    
    IF(PEXCLUDE_RATE_CODE IS NOT NULL OR PEXCLUDE_RATE_CODE<>'')
    THEN
        v_wherecl:=v_wherecl ||' AND  m."Rate_code" not in('||PEXCLUDE_RATE_CODE||')';

    END IF;    

    query1:=query1 ||v_wherecl||' group by i."Cio_Booking_Id",i."No_Insert" ,m."Package_code"
     , a."Agency_Name",m."Trade_disc",i."Insert_Status",m."No_of_insertion"
     ,m."Bill_remarks",m."Client_code",i.BILL_NO, i."Comp_Code"  order by i."Cio_Booking_Id", i."No_Insert"';


    delete from ank_search_new;insert into ank_search_new values(query1);commit;

    open p_recordset for query1;
    
    v_chkdt:=ad_get_finandt(pcompcode,fromdate,v_dateformat,null,null);
    
    select max(invoice_no) as "recno" into last_billno from tbl_invoiceno where comp_code=pcompcode and 
                center_code=bookingcenter and ad_get_finandt(pcompcode,fromdate,v_dateformat,null,null)=v_chkdt;
                
    select max(bildt) into v_last_dt from ad_bills 
    where comp_code_v=pcompcode and ad_get_finandt(comp_code_v,bildt,v_dateformat,null,null)=v_chkdt and 
    exists(select 'x' from branch_mst where "Branch_Code"=ad_bills.unit and "pub_center"=bookingcenter); 
    
    select count(distinct i."Cio_Booking_Id"||i."No_Insert") into v_billed from tbl_booking_mast m,tbl_booking_insert i
        where m."Comp_code"=pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
        exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "pub_center"=bookingcenter) and
        m."Ad_type_code"=nvl(adtype1,m."Ad_type_code") AND i."Insert_Date" BETWEEN  fromdate AND  todate and bill_no is not null;
        
    select count(distinct i."Cio_Booking_Id"||i."No_Insert") into v_booked_by_others from tbl_booking_mast m,tbl_booking_insert i
        where m."Comp_code"=pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
        not exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "pub_center"=bookingcenter) and
        m."Ad_type_code"=nvl(adtype1,m."Ad_type_code") AND i."Insert_Date" BETWEEN fromdate AND todate and
        i."Pub_Cent_Code"=bookingcenter
        and not exists(select 'x' from tbl_booking_mast where m."Comp_code"=pcompcode and "prev_cioid" is not null and "prev_cioid"=m."cio_booking_id");
        

    open p_recordset1 for 
    select nvl(last_billno,0) as "LAST_BILLNO",to_char(v_last_dt,v_dateformat) as "LAST_BILLDT",nvl(v_billed,0) as "ALREADY_BILLED",
     nvl(v_booked_by_others,0) as "BOOKED_BY_OTHERS" from dual;

END ;
/

@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE PROCEDURE websp_bindcioidnew1_combined (
   FROMDATE           IN       VARCHAR2,
   TODATE             IN       VARCHAR2,
   DATE1              IN       VARCHAR2,
   PUBLICATION        IN       VARCHAR2,
   BOOKINGCENTER      IN       VARCHAR2,
   REVENUECENTER      IN       VARCHAR2,
   AGENCYTYPE         IN       VARCHAR2,
   PACKAGE1           IN       VARCHAR2,
   ADTYPE1            IN       VARCHAR2,
   AGENCY             IN       VARCHAR2,
   CLIENT             IN       VARCHAR2,
   BILLSTATUS         IN       VARCHAR2,
   RATE_AUDIT         IN       VARCHAR2,
   BILLMODE           IN       VARCHAR2,
   BILLCYCLE          IN       VARCHAR2,
   V_RETAINER_NAME    IN       VARCHAR2,
   V_EXECUTIVE_NAME   IN       VARCHAR2,
   V_BRANCH_NAME      IN       VARCHAR2,
   V_AD_CATEGORY      IN       VARCHAR2,
   V_DISTRICT         IN       VARCHAR2,
   V_TALUKA           IN       VARCHAR2,
   PCOMPCODE          IN       VARCHAR2,
   P_BILLNO           IN       VARCHAR2,
   P_BILL_GEN_PRIOR   IN       VARCHAR2,
   P_CENTERLOGIN      IN       VARCHAR2,
   P_PUB_CENT_HO      IN       VARCHAR2,
   P_FMG_BILL         IN       VARCHAR2,
   P_SCHEME_TYPE      IN       VARCHAR2,
   PTO_BILL_NO        IN       VARCHAR2,
   P_UOM              IN       VARCHAR2,
   PEXCLUDE_RATE_CODE IN VARCHAR2,
   P_RECORDSET        OUT      CUR_TYPE_NEW1.CURSOR_TYPE,
   P_RECORDSET1        OUT CUR_TYPE_NEW1.CURSOR_TYPE
)
IS
   query1            VARCHAR2 (10000);
   v_bill_criteria   VARCHAR2 (10);
   
    v_dateformat    varchar2(100);
    v_chkdt         date;
    last_billno     number(10);
    v_last_dt       date;
    v_billed            number(10);
    v_booked_by_others  number(10);
begin
   if adtype1 = 'DI0' then
      select disp_billing_criteria,"date_format" into v_bill_criteria,v_dateformat from preferrences where "comp_code" = pcompcode;
   else
      select clsd_billing_criteria,"date_format" into v_bill_criteria,v_dateformat from preferrences where "comp_code" = pcompcode;
   end if;

   IF (billstatus = '3' AND rate_audit = 'n') THEN
      query1 :=' SELECT DISTINCT  i."Cio_Booking_Id", max(i."No_Insert") AS "no_of_insertion" ,m."Package_code"  AS "edition",
      nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
      a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
      min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO,
      (select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
      FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
      a."code_subcode"=m."Agency_sub_code" and m."audit" is not null and  m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''publish'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '3' AND rate_audit = 'y') THEN
      query1 :=' SELECT DISTINCT  i."Cio_Booking_Id", max(i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
     nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where
    cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",
           fetch_unpublish_edtn('''||pcompcode||''',i."Cio_Booking_Id",null,''2'',''N'',null,null) as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
           i."Insert_Status" not in(''cancel'',''hold'') and  a."code_subcode"=m."Agency_sub_code" and m."audit" is not null
           and  m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''audit by rate'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''') 
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '1' AND rate_audit = 'y' AND billmode = '2')
   THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", max(i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
     nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where
    cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
        AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and m."audit" is not null
        and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND (b."Insert_Status" =''audit by rate'' OR b."Insert_Status"=''billed'') AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''') 
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '1' AND rate_audit = 'n' AND billmode = '2')
   THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", max(i."No_Insert") AS "no_of_insertion" ,m."Package_code"AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
        AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and 
        m."audit" is not null
        and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND (b."Insert_Status" =''publish'' OR b."Insert_Status"=''billed'') AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '1' AND rate_audit = 'n' AND (billmode = '1' OR billmode = '3'))
   THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
          (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
          AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and 
          m."audit" is not null 
          and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '1' AND rate_audit = 'y'AND (billmode = '1' OR billmode = '3'))THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
            AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and 
           m."audit" is not null 
           and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") '
           ;
   END IF;

   IF (billstatus = '3' AND rate_audit = 'n' AND (billmode = '1' OR billmode = '3')) THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND 
     i."Insert_Status" not in(''cancel'',''hold'') and m."audit" is not null
     and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '3' AND rate_audit = 'y'AND (billmode = '1' OR billmode = '3')) THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
        AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and 
        m."audit" is not null 
        and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = 2) THEN
      query1 :=
            ' SELECT DISTINCT  i."Cio_Booking_Id",count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition" ,
    nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
    a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
    min(i."Insert_Status") AS "status",m."No_of_insertion" AS  "total",m."Bill_remarks",i.BILL_NO
    ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
    FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
     i."Insert_Status" not in(''cancel'',''hold'') and a."code_subcode"=m."Agency_sub_code"  and m."audit" is not null
     and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '5') THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
      nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
      a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
      min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
      ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
      FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
       i."Insert_Status" not in(''cancel'',''hold'') and a."code_subcode"=m."Agency_sub_code" and m."audit" is not null
       and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''publish'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = 6)THEN
      query1 :=
            ' SELECT DISTINCT  i."Cio_Booking_Id",count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition" ,
        nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
        a."Agency_Name" AS "Agency",
        min(i."Insert_Status") AS "status",m."No_of_insertion" AS  "total",m."Bill_remarks",i.BILL_NO
        ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
        FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
         i."Insert_Status" not in(''cancel'',''hold'') and a."code_subcode"=m."Agency_sub_code" 
         and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''booked'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (v_retainer_name IS NOT NULL) THEN
      query1 := query1 || ' and m."RETAINER" =''' || v_retainer_name || '''';
   END IF;

   IF (v_executive_name IS NOT NULL) THEN
      query1 :=
          query1 || ' and m."Executive_code" =''' || v_executive_name || '''';
   END IF;

   IF (v_branch_name IS NOT NULL  AND v_branch_name <> 0) THEN
      query1 := query1 || ' and m."branch" =''' || v_branch_name || '''';
   END IF;

   IF (v_ad_category IS NOT NULL) THEN
      query1 := query1 || ' and m."Ad_cat_code" =''' || v_ad_category || '''';
   END IF;

   IF (v_district IS NOT NULL) THEN
      query1 :=
            query1|| ' and exists (select ''x'' from agency_mast where m."Agency_sub_code"=agency_mast."code_subcode" and agency_mast."Dist_Code" ='''|| v_district|| ''' or '''|| v_district|| ''' is null)';
   END IF;

   IF (v_taluka IS NOT NULL) THEN
      query1 :=
            query1|| '  AND exists (select ''x'' from agency_mast where m."Agency_sub_code"=agency_mast."code_subcode" and (agency_mast."Dist_Code"  in(select DIST_CODE from taluka_mast where TALU_CODE='''|| v_taluka|| ''' or '''|| v_taluka|| ''' is null) )  AND agency_mast."Dist_Code"='''|| v_district|| ''' OR '''|| v_district|| '''  IS NULL   )';
   END IF;

   IF v_bill_criteria = 'A'
   THEN
      IF (billcycle IS NOT NULL) THEN
         query1 :=query1 || ' AND a."BILL_FREQUENCY"=''' || billcycle || '''';
      END IF;
   ELSIF v_bill_criteria = 'R'
   THEN
      IF (billcycle IS NOT NULL) THEN
         query1 := query1 || ' AND m."Bill_cycle" =''' || billcycle || '''';
      END IF;
   END IF;

   IF (agency IS NOT NULL) THEN
      query1 := query1 || ' AND m."Agency_sub_code" =''' || agency || '''';
   END IF;

   IF (client IS NOT NULL) THEN
      query1 := query1 || ' AND m."Client_code" =''' || client || '''';
   END IF;

   IF (agencytype IS NOT NULL) THEN
      query1 :=query1 || ' AND m."Agency_type"  =''' || TRIM (agencytype)|| '''';
   END IF;

   IF (adtype1 IS NOT NULL) THEN
      query1 := query1 || ' AND m."Ad_type_code" =''' || adtype1 || ''' ';
   END IF;

   IF (bookingcenter IS NOT NULL) THEN
      query1:=query1 ||' AND exists(select ''x'' from branch_mst where "Branch_Code"=m."branch" and "pub_center" ='''||bookingcenter||''') ';
   END IF;

   IF (p_fmg_bill != 'Include') THEN
      query1 := query1 || ' AND m."Booking_type" not in (''2'',''4'',''5'')';
   END IF;

   IF (p_scheme_type = 'EXCLUDE') THEN
      query1 := query1 || ' AND i."Pai_Free_Ins"  in (''Y'')';
   END IF;

   IF (revenuecenter IS NOT NULL) THEN
      query1 := query1 || ' AND m."Revenue_center" =''' || revenuecenter || ''' ';
   END IF;

   IF (publication IS NOT NULL) THEN
      query1 :=
              query1 || ' AND  i."Publication_Code"=''' || publication || '''';
   END IF;

   IF (p_billno IS NOT NULL) AND (pto_bill_no IS NOT NULL) THEN
      query1 :=query1||' AND  i.BILL_NO between '''||p_billno||''' and '''||pto_bill_no||'''';
   END IF;

   IF (p_uom IS NOT NULL) THEN
      query1 := query1 || 'AND  m."Uom_code" = ''' || p_uom || '''';
   END IF;

   IF (package1 IS NOT NULL) THEN
      query1 := query1 || ' AND  i."Edition" =''' || package1 || '''';
   END IF;
   
    IF(PEXCLUDE_RATE_CODE IS NOT NULL OR PEXCLUDE_RATE_CODE<>'')
    THEN
        query1:=query1 ||' AND  m."Rate_code" not in('||PEXCLUDE_RATE_CODE||')';

    END IF;    


   query1 :=query1|| 'group by i."Cio_Booking_Id",m."Package_code", a."Agency_Name",m."Trade_disc",m."No_of_insertion"
     ,m."Bill_remarks",m."Client_code",i.BILL_NO, i."Comp_Code"  order by i."Cio_Booking_Id"';

   delete from ank_search_new;insert into ank_search_new values (query1);commit;

   OPEN p_recordset FOR query1;
   
   v_chkdt:=ad_get_finandt(pcompcode,fromdate,v_dateformat,null,null);
    
    select max(invoice_no) as "recno" into last_billno from tbl_invoiceno where comp_code=pcompcode and 
                center_code=bookingcenter and ad_get_finandt(pcompcode,fromdate,v_dateformat,null,null)=v_chkdt;
                
    select max(bildt) into v_last_dt from ad_bills 
    where comp_code_v=pcompcode and ad_get_finandt(comp_code_v,bildt,v_dateformat,null,null)=v_chkdt and 
    exists(select 'x' from branch_mst where "Branch_Code"=ad_bills.unit and "pub_center"=bookingcenter); 
    
    select count(distinct i."Cio_Booking_Id"||i."No_Insert") into v_billed from tbl_booking_mast m,tbl_booking_insert i
        where m."Comp_code"=pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
        exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "pub_center"=bookingcenter) and
        m."Ad_type_code"=nvl(adtype1,m."Ad_type_code") AND i."Insert_Date" BETWEEN  fromdate AND  todate and bill_no is not null;
        
    select count(distinct i."Cio_Booking_Id"||i."No_Insert") into v_booked_by_others from tbl_booking_mast m,tbl_booking_insert i
        where m."Comp_code"=pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
        not exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "pub_center"=bookingcenter) and
        m."Ad_type_code"=nvl(adtype1,m."Ad_type_code") AND i."Insert_Date" BETWEEN fromdate AND todate and
        i."Pub_Cent_Code"=bookingcenter 
        and not exists(select 'x' from tbl_booking_mast where m."Comp_code"=pcompcode and "prev_cioid" is not null and "prev_cioid"=m."cio_booking_id");
        

    open p_recordset1 for 
    select nvl(last_billno,0) as "LAST_BILLNO",to_char(v_last_dt,v_dateformat) as "LAST_BILLDT",nvl(v_billed,0) as "ALREADY_BILLED",
     nvl(v_booked_by_others,0) as "BOOKED_BY_OTHERS" from dual;
     
END websp_bindcioidnew1_combined;
/


@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE OR REPLACE Procedure Websp_Receipt_Print
(pcompcode           IN  VARCHAR2,
pcio_booking_id     IN  VARCHAR2,
dateformat          IN  VARCHAR2,
p_getbookingrecord  OUT Cur_Type_New1.cursor_type,
p_accounts1         OUT Cur_Type_New1.cursor_type,
P_ACCOUNTS2         OUT Cur_Type_New1.cursor_type)

IS
BEGIN

        OPEN p_getbookingrecord FOR
        SELECT DISTINCT a."Agency_Name" AS "Agen",
        NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
        p."Pub_Name" AS "Pub",m."No_of_insertion" AS "noinsert",m."Gross_amount" AS "gamt1",
        --m."Gross_amount" AS "gamt",
        (select "oth_amount"  from ad_rcpthdr where "comp_code"=m."Comp_code" and "recptno"=m."Receipt_no"  and "doctype" in('RCP','CA')) as "gamt",
        m."cio_booking_id" AS "CIOID",
        NVL(a."Add1",' ') AS "address",c."City_Name",
        SYSDATE AS "receiptdate",
        m."Receipt_no" AS "recno",m."Trade_disc" AS "trade_disc",m."Bill_area",m."Ad_type_code",m."Uom_code",
        (select "Adv_Cat_Alias" from adv_cat_mast where adv_cat_mast."Adv_Cat_Code"=m."Ad_cat_code") as "CAT_NAME",
        (select "Adv_Subcat_Alias" from adv_subcat_mast where adv_subcat_mast."Adv_Subcat_Code"=m."Ad_sub_cat_code") as "SUBCAT_NAME",
        (select "catalias"  from ad_cat3 where m."Ad_Subcat3"=ad_cat3."catcode" ) as "CAT3_NAME",
        (select "Cat_Alias"  from tbl_cat4 where m."Ad_Subcat4"=tbl_cat4."Cat_Code") as "CAT4_NAME",
        (select "Cat_Alias"  from tbl_cat5 where m."Ad_subcat5"=tbl_cat5."Cat_Code") as "CAT5_NAME",
        (select AG_MAIN_CODE from ad_direct_client_agency where m."Comp_code"= ad_direct_client_agency.COMP_CODE and m."Agency_sub_code"=ad_direct_client_agency.AG_MAIN_CODE||ad_direct_client_agency.AG_SUB_CODE ) as "Direct_Agency",
        CASE dateformat
        WHEN 'mm/dd/yyyy' THEN (select TO_CHAR(nvl("recptdt","date_time"),'mm/dd/yyyy')  from ad_rcpthdr where "comp_code"=m."Comp_code" and "recptno"=m."Receipt_no"  and "doctype" in('RCP','CA'))
        WHEN 'dd/mm/yyyy' THEN (select TO_CHAR(nvl("recptdt","date_time"),'dd/mm/yyyy')  from ad_rcpthdr where "comp_code"=m."Comp_code" and "recptno"=m."Receipt_no"  and "doctype" in('RCP','CA'))
        WHEN 'yyyy/mm/dd' THEN (select TO_CHAR(nvl("recptdt","date_time"),'yyyy/mm/dd')  from ad_rcpthdr where "comp_code"=m."Comp_code" and "recptno"=m."Receipt_no"  and "doctype" in('RCP','CA'))  END AS "BookDate",
        (select "Uom_Alias" from uom_mast where uom_mast."Uom_Code"=m."Uom_code"),
        m."branch",m."Bill_amount" AS "bilamt",
        SYSDATE AS "receiptdate1",
        m."Caption"  AS "caption",m."RO_No" AS "rono",
        CASE dateformat
        WHEN 'mm/dd/yyyy' THEN TO_CHAR(m."RO_Date",'mm/dd/yyyy')
        WHEN 'dd/mm/yyyy' THEN TO_CHAR(m."RO_Date",'dd/mm/yyyy')
        WHEN 'yyyy/mm/dd' THEN TO_CHAR(m."RO_Date",'yyyy/mm/dd')  END AS "rodate",
        t."Adv_Type_Name" as "adtype",
        (SELECT COMBIN_MAST."Package_Name" FROM COMBIN_MAST WHERE m."Package_code"=COMBIN_MAST."Combin_Code") AS "Package_Name",
        m."Card_rate" AS "pkgrate",m."Card_amount" AS "cardamount",
        cm."Comp_Name" AS "companyname",
        cm."Add1" AS "address",
        cm."EmailID" AS "emailid",
        cm."PAN_No" AS "pan_no",
        pm."Payment_Mode_Name",m."ADD_AGENCY_COMM" AS "adl_agency_comm",
        m."Page_amount" AS "Page_prem",
        m."Booking_type" AS  "Booking_type",
        m."Box_no"    AS "Box_no",
        m."Special_disc_per" AS "Special_disc_per",
        m."Prem_per"    AS "Prem_per",
        m."Bullet_premium" as "Bullet_Charges",
        m.TRANSLATION_PREMIUM as "TRANSLATION_PREMIUM",
        /********* For Extra Rate And Min Word find From Rate Master ******/
        (select max("Size_To") from rate_mast where "Combin_Code"=i.PACKAGE_CODE and "Comp_code"=pcompcode and "Rate_Mast_Code"=m."Rate_code" and "Adv_Type_Code"=m."Ad_type_code" and "Adv_Cat_Code"=m."Ad_cat_code" and 
        "Uom"=m."Uom_code" and "Color"=i."Col_Code" and m."Insertion_date" between "Valid_From" and "Valid_To") as "MIN_WORD" ,
        (select max("Week_Extra_Rate") from rate_mast where "Combin_Code"=i.PACKAGE_CODE and "Comp_code"=pcompcode and "Rate_Mast_Code"=m."Rate_code" and "Adv_Type_Code"=m."Ad_type_code" and "Adv_Cat_Code"=m."Ad_cat_code" and 
        "Uom"=m."Uom_code" and "Color"=i."Col_Code" and m."Insertion_date" between "Valid_From" and "Valid_To") as "EXTRA_RATE" ,

        nvl(m."Special_discount",0) as "Special_discount",nvl(m."Space_discount",0) as "Space_discount",
        m."Agrred_rate" as "Agreed_Rate",i."Insert_Date",m.doctype DOCTYPE,
        (select "Bill_amount" from tbl_booking_mast pre_bk where pre_bk."cio_booking_id"=m."prev_cioid" ) as PREVBILLAMT,
        m.cashdiscount,CASHDISCTYPE,m.ADD_AGENCY_COMM_AMT,
        (select "Box_Charges_Native" from box_mast where "Box_Code" =m."Box_code") as boxcharge,
        (select "Box_Charges_Type" from box_mast where "Box_Code" =m."Box_code") as boxtype,
        nvl ((SELECT "Cust_Name"||'-'||m."Client_address" FROM CUST_MAST WHERE "Cust_Code" = m."Client_code") , m."Client_code"||'-'||m."Client_address") AS Client2,
        (select "amount"  from ad_rcpthdr where "recptno"=m."Receipt_no"  and "doctype" in('RCP','CA')) as "gcancelamt",
        nvl(m."Bullet_code",'') as "eyecatcher",(select charges_type from ad_charge_mast where charge_code=m.translation_code) as "CHARGE_TYPE", 
        m.translation_premium as "TRANSLATION_PREMIUM",(select sum("Gross_Rate") from tbl_booking_insert 
        where tbl_booking_insert."Cio_Booking_Id" = m."cio_booking_id" and "No_Insert"=1) as "INSERT_GROSS_AMT"        
        from tbl_booking_mast m,pub_cent_mast pc,tbl_booking_insert i,
        agency_mast a,pub_mast p,col_mast cl,
        adv_type_mast t,city_mst c,comp_mst cm,payment_mode_mast pm
        
        where m."Comp_code"=pcompcode and m."Comp_code"=cm."Comp_Code" and m."cio_booking_id"=i."Cio_Booking_Id" and m."cio_booking_id"=pcio_booking_id 
        and m."Agency_sub_code"=a."code_subcode" and i."Publication_Code" = p."Pub_Code"
        and pc."Pub_cent_Code"=i."Pub_Cent_Code" and c."City_Code"=a."City_Code" and
        pm."Pay_Mode_Code"=m."Agency_pay" and m."Ad_type_code"=t."Adv_Type_Code" and cl."Col_Code"=m."Color_code"
        order by i."Insert_Date" DESC;

        open p_accounts1 for
        select distinct (select "Package_Name" from combin_mast where "Combin_Code"=i."PACKAGE_CODE") as "Edition",
        case 'dd/mm/yyyy'
        when 'mm/dd/yyyy' then to_char(min(i."Insert_Date"),'mm/dd/yyyy')
        when 'dd/mm/yyyy' then to_char(min(i."Insert_Date"),'dd/mm/yyyy')
        when 'yyyy/mm/dd' then to_char(min(i."Insert_Date"),'yyyy/mm/dd')  end as "Insert_Date",
        sum(i."Gross_Rate") as   "Gross_Rate",
        max(i."Height") "Height", max(i."Width") "Width", max(i."Size_Book") "Size_Book",min(cl."Col_Alias") "Col_Alias", 
        min(i."Page_No") "Page_No", 
        sum(i."Agreed_Rate") as "Agreed_Rate",sum(i."Solo_Rate") as "Solo_Rate",i."No_Insert" as "No_Insert"
        from tbl_booking_insert i , col_mast cl
        where i."Cio_Booking_Id"=pcio_booking_id and i."Col_Code"=cl."Col_Code"  
        group by i."PACKAGE_CODE",i."No_Insert" 
        order by i."No_Insert","Edition";-- desc;

        open p_accounts2 for 
        select  distinct "Combin_Desc"  as "PACKAGE_NAME" 
        from tbl_booking_mast m,tbl_booking_insert i,combin_mast c 
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=pcompcode and 
        m."cio_booking_id"=pcio_booking_id and m."cio_booking_id"=i."Cio_Booking_Id" and
        c."Combin_Code"=i.package_code;
            
end Websp_Receipt_Print;
/

//=======================************* End of Procedure Scripts ***************===============//



/***************************kuldeep*******************************16 04 2012********************/
create or replace procedure rpt_booking_collection(
    agname          in varchar2:= null,
    fromdate        in varchar2:= null,
    dateto          in varchar2:= null,
    compcode        in varchar2:= null,
    dateformat      in varchar2:= null,
    client          in varchar2:=null,
    agencypay       in varchar2:=null,
    advtype         in varchar2:=null,
    pub_cent        in varchar2:=null,
    puserid         in varchar2,
    chk_access      in varchar2,
    useridcode      in varchar2:=null,
    pbranch         in varchar2:=null,
    puom_code       in varchar2:=null,
    p_recordsetnew  out cur_type_new1.cursor_type)
IS
query1 VARCHAR2(10000);
--agencypay VARCHAR2(10);
BEGIN


    query1:='SELECT distinct m."cio_booking_id" AS "CIOID",m."date_time" as "BKDATE", AGENCY_MAST."Agency_Name" AS "AGENCY",
    (select "City_Name" from city_mst where "City_Code"=a."City_Code") as "AGENCY_CITY",
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "CLIENT",
    round(nvl(m."Bill_amount",''0''),2) AS "BILLAMT",
    round(m."Bill_height"*m."Bill_width",2) AS "BILLABLEAREA",
    round(nvl(m."Trade_disc",''0''),2) AS "TRADEDISC%",
    round(m."Agrred_rate",2) AS "AGREEDRATE",
    m."Receipt_no" AS "RECEIPTNO",
    round(m."Card_rate",2) as "CARDRATE",
    u.UOM_DESC as "UOM",
    (SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "COMPANYNAME",
    sysdate as "RUNDATE",
    m."Userid" as "USERID",(select login."username" from login where login."userid"=m."Userid" ) as "USERNAME",
    b."Branch_Name" as "BRANCH"
    FROM TBL_BOOKING_MAST m, AGENCY_MAST a,tbl_booking_insert i,branch_mst b,uom_mast u
    WHERE m."Comp_code"='''||compcode||''' AND m."cio_booking_id"=i."Cio_Booking_Id" 
    AND m."Agency_code"=a."Agency_Code" and m."Agency_sub_code"=a."code_subcode" and m."branch"=b."Branch_Code"
    AND m."Uom_code"=u."Uom_Code"AND m."Receipt_no" IS NOT NULL
    AND not exists (select distinct ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
    and lower(i."Insert_Status") !=''cancel''
    and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
    or  ('''||chk_access||'''=''0'') ) ' ;

    IF(useridcode IS NOT NULL)
    THEN
        query1:=query1||'  AND m."Userid" ='''||useridcode||'''';
    END IF;

    IF(pbranch IS NOT NULL)
    THEN
        query1:=query1||'  and m."branch" ='''||pbranch||''''; 
    END IF;

    IF(pub_cent IS NOT NULL)
    THEN
        query1:=query1||'  AND i."Pub_Cent_Code"='''||pub_cent||'''';
    END IF;

    IF(advtype IS NOT NULL)
    THEN
        query1:=query1 ||' AND m."Ad_type_code" ='''||advtype ||'''';
    END IF;

    IF(puom_code IS NOT NULL)
    THEN
        query1:=query1 ||' AND m."Uom_code" ='''||puom_code ||'''';
    END IF;
        
    IF(agencypay IS NOT NULL)
    THEN
        query1:=query1 ||' AND m."Agency_pay" ='''||agencypay ||'''';
    END IF;

    IF(agname IS NOT NULL)
    THEN
        query1:=query1 ||' AND m."Agency_code" ='''||agname ||'''';
    END IF;


    IF(fromdate IS NOT NULL AND dateto IS NULL )
    THEN
        query1:=query1||' AND m."date_time" ='''||fromdate||'''';

    END IF;

    IF(fromdate IS NOT NULL AND dateto IS NOT NULL )
    THEN
        query1:=query1||' AND m."date_time" BETWEEN  '''||fromdate ||''' AND  '''||dateto||''' ';
    END IF;

    IF(client IS NOT NULL)
    THEN
        query1:=query1||' AND m."Client_code"='''||client||'''';
    END IF;

    query1:=query1||' order by USERNAME,USERID,BKDATE,RECEIPTNO';

    delete from searchtbl;insert into searchtbl values('rpt_booking_collection' || query1);commit;

    open p_recordsetnew  for query1;

end rpt_booking_collection;
/

/***************************kuldeep*******************************16 04 2012********************/




/******************kuldeep ****************16042012******************************/
CREATE OR REPLACE PROCEDURE ERPTEST.Money_Rep
(
    agname          IN VARCHAR2:= NULL,
    fromdate        IN VARCHAR2:= NULL,
    dateto          IN VARCHAR2:= NULL,
    compcode        IN VARCHAR2:= NULL,
    dateformat      IN VARCHAR2:= NULL,
    client          IN VARCHAR2:=NULL,
    agencypay       in varchar2:=null,
    advtype         in varchar2:=null,
    pub_cent        in varchar2:=null,
    puserid         IN VARCHAR2,
    chk_access      in varchar2,
    useridcode      in varchar2:=null,
    pbranch         in varchar2:=null,
    p_uom       in varchar2:=null,
    p_recordsetnew OUT Cur_Type_New1.cursor_type

)

IS

query1 VARCHAR2(10000);
--agencypay VARCHAR2(10);
BEGIN

--agencypay:='CA0';
--agencypay:='DD0';



query1:='SELECT distinct TBL_BOOKING_MAST."cio_booking_id" AS "CIOID",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"="Client_code"),"Client_code")  AS "Client",
round(nvl(TBL_BOOKING_MAST."Bill_amount",''0''),2) AS "BillAmt",
round(TBL_BOOKING_MAST."Bill_height"*"Bill_width",2) AS "BillableArea",
round(nvl(TBL_BOOKING_MAST."Trade_disc",''0''),2) AS "TradeDisc%",
round(TBL_BOOKING_MAST."Agrred_rate",2) AS "AgreedRate",
TBL_BOOKING_MAST."Receipt_no" AS "ReceiptNo",
round(tbl_booking_MAST."Card_rate",2) as "CardRate",
(select uom_mast.UOM_DESC from uom_mast where tbl_booking_mast."Uom_code"=uom_mast."Uom_Code")as "uom",
(SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "companyname",
sysdate as "Rundate",
(select login."username" from login where login."userid"=tbl_booking_mast."Userid" ) as "User",
--old version
--tbl_booking_mast."branch" as "Branch"
--new version
(SELECT "Branch_Name" FROM BRANCH_MST where  TBL_BOOKING_mast."branch" = "Branch_Code") as "Branch"

FROM TBL_BOOKING_MAST,
AGENCY_MAST,
tbl_booking_insert

WHERE TBL_BOOKING_MAST."Comp_code"='''||compcode||''' AND
TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id" AND
TBL_BOOKING_MAST."Agency_code"=AGENCY_MAST."Agency_Code" and
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode"
AND TBL_BOOKING_MAST."Receipt_no" IS NOT NULL
AND "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
and  lower("Insert_Status") !=''cancel''
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
or  ('''||chk_access||'''=''0'') ) ' ;

IF(useridcode IS NOT NULL)
THEN
query1:=query1||'  AND tbl_booking_mast."Userid" ='''||useridcode||'''';
END IF;

--new version
IF(pbranch IS NOT NULL)
THEN
query1:=query1||'  and TBL_BOOKING_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''||pbranch||''')'; 
END IF;

/*old version
IF(pbranch IS NOT NULL)
THEN
query1:=query1||'  AND tbl_booking_mast."branch" ='''||pbranch||'''';
END IF;
*/



IF(pub_cent IS NOT NULL)
THEN
query1:=query1||'  AND TBL_BOOKING_INSERT."Pub_Cent_Code"='''||pub_cent||'''';
END IF;

IF(advtype IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST."Ad_type_code" ='''||advtype ||'''';
END IF;
IF(agencypay IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST."Agency_pay" ='''||agencypay ||'''';
END IF;

 IF(p_uom IS NOT NULL)
    THEN
        query1:=query1 ||' AND m."Uom_code" ='''||p_uom ||'''';
    END IF;

IF(agname IS NOT NULL)
THEN
query1:=query1 ||' AND TBL_BOOKING_MAST."Agency_code" ='''||agname ||'''';
END IF;


IF(fromdate IS NOT NULL AND dateto IS NULL )
THEN
    query1:=query1||' AND TBL_BOOKING_MAST."date_time" ='''||fromdate||'''';

END IF;

IF(fromdate IS NOT NULL AND dateto IS NOT NULL )
THEN
    query1:=query1||' AND TBL_BOOKING_MAST."date_time" BETWEEN  '''||fromdate ||''' AND  '''||dateto||''' ';
END IF;

IF(client IS NOT NULL)
THEN
query1:=query1||' AND  TBL_BOOKING_MAST."Client_code"='''||client||'''';
END IF;




query1:=query1||' order by 13';

--query1:=query1||' order by substr(TBL_BOOKING_MAST."Receipt_no",13)';

delete from searchtbl;
insert into searchtbl values('Money' || query1);
commit;

OPEN p_recordsetnew  FOR

query1;

END ;
/
*************************************************************


CREATE OR REPLACE procedure ERPTEST.rpt_booking_collection(
    agname          in varchar2:= null,
    fromdate        in varchar2:= null,
    dateto          in varchar2:= null,
    compcode        in varchar2:= null,
    dateformat      in varchar2:= null,
    client          in varchar2:=null,
    agencypay       in varchar2:=null,
    advtype         in varchar2:=null,
    pub_cent        in varchar2:=null,
    puserid         in varchar2,
    chk_access      in varchar2,
    useridcode      in varchar2:=null,
    pbranch         in varchar2:=null,
    puom_code       in varchar2:=null,
    p_recordsetnew  out cur_type_new1.cursor_type)
IS
query1 VARCHAR2(10000);
--agencypay VARCHAR2(10);
BEGIN


    query1:='SELECT distinct m."cio_booking_id" AS "CIOID",m."date_time" as "BKDATE", a."Agency_Name" AS "AGENCY",
    (select "City_Name" from city_mst where "City_Code"=a."City_Code") as "AGENCY_CITY",
    NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "CLIENT",
    round(nvl(m."Bill_amount",''0''),2) AS "BILLAMT",
    round(m."Bill_height"*m."Bill_width",2) AS "BILLABLEAREA",
    round(nvl(m."Trade_disc",''0''),2) AS "TRADEDISC%",
    round(m."Agrred_rate",2) AS "AGREEDRATE",
    m."Receipt_no" AS "RECEIPTNO",
    round(m."Card_rate",2) as "CARDRATE",
    u.UOM_DESC as "UOM",
    (SELECT initcap("Comp_Name") from comp_mst where "Comp_Code"='''||compcode||''') AS "COMPANYNAME",
    sysdate as "RUNDATE",
    m."Userid" as "USERID",(select login."username" from login where login."userid"=m."Userid" ) as "USERNAME",
    b."Branch_Name" as "BRANCH"
    FROM TBL_BOOKING_MAST m, AGENCY_MAST a,tbl_booking_insert i,branch_mst b,uom_mast u
    WHERE m."Comp_code"='''||compcode||''' AND m."cio_booking_id"=i."Cio_Booking_Id" 
    AND m."Agency_code"=a."Agency_Code" and m."Agency_sub_code"=a."code_subcode" and m."branch"=b."Branch_Code"
    AND m."Uom_code"=u."Uom_Code"AND m."Receipt_no" IS NOT NULL
    AND not exists (select distinct ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
    and lower(i."Insert_Status") !=''cancel''
    and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')
    or  ('''||chk_access||'''=''0'') ) ' ;

    IF(useridcode IS NOT NULL)
    THEN
        query1:=query1||'  AND m."Userid" ='''||useridcode||'''';
    END IF;

    IF(pbranch IS NOT NULL)
    THEN
        query1:=query1||'  and m."branch" ='''||pbranch||''''; 
    END IF;

    IF(pub_cent IS NOT NULL)
    THEN
        query1:=query1||'  AND i."Pub_Cent_Code"='''||pub_cent||'''';
    END IF;

    IF(advtype IS NOT NULL)
    THEN
        query1:=query1 ||' AND m."Ad_type_code" ='''||advtype ||'''';
    END IF;

    IF(puom_code IS NOT NULL)
    THEN
        query1:=query1 ||' AND m."Uom_code" ='''||puom_code ||'''';
    END IF;
        
    IF(agencypay IS NOT NULL)
    THEN
        query1:=query1 ||' AND m."Agency_pay" ='''||agencypay ||'''';
    END IF;

    IF(agname IS NOT NULL)
    THEN
        query1:=query1 ||' AND m."Agency_code" ='''||agname ||'''';
    END IF;


    IF(fromdate IS NOT NULL AND dateto IS NULL )
    THEN
        query1:=query1||' AND m."date_time" ='''||fromdate||'''';

    END IF;

    IF(fromdate IS NOT NULL AND dateto IS NOT NULL )
    THEN
        query1:=query1||' AND m."date_time" BETWEEN  '''||fromdate ||''' AND  '''||dateto||''' ';
    END IF;

    IF(client IS NOT NULL)
    THEN
        query1:=query1||' AND m."Client_code"='''||client||'''';
    END IF;

    query1:=query1||' order by USERNAME,USERID,BKDATE,RECEIPTNO';

    delete from searchtbl;insert into searchtbl values('rpt_booking_collection' || query1);commit;

    open p_recordsetnew  for query1;

end rpt_booking_collection;
/
/**********************************************************************/
CREATE OR REPLACE procedure ERPTEST.schedulereport_checklist(
    fromdate        in varchar2,
    dateto          in varchar2,
    compcode        in varchar2,
    pub_name        in varchar2,
    pub_cent        in varchar2,
    dateformat      in varchar2,
    descid          in varchar2:=null,
    ascdesc         in varchar2:=null,
    adtyp           in varchar2,
    adcatg          in varchar2,
    edition_name    in varchar2,
    drpstatus       in varchar2,
    supplement_name in varchar2,
    packagecode     in varchar2,
    editiondtl      in varchar2,
    puserid         in varchar2:=null,
    chk_access      in varchar2:=null,
    p_branch            in varchar2:=null,
    poth_branch_flag    in varchar2,--Y for
    p_uom           in varchar2,   
    p_accounts      OUT Cur_Type_New1.cursor_type,
    p_accounts1     OUT Cur_Type_New1.cursor_type,
    p_accounts2     OUT Cur_Type_New1.cursor_type,
    p_accounts3     out Cur_Type_New1.cursor_type,
    p_accounts4     out Cur_Type_New1.cursor_type) IS

query1      VARCHAR2(20000);
query_group VARCHAR2(8000);
query2      VARCHAR2(1000);
v_gau   number:=17;
v_val   number(4);
vs_gau  number(4);
v_billed            number(10);
v_booked_by_others  number(10);

Cursor p1 Is
select i."Edition" as "edition",count(*) as "tot"
FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i,AGENCY_MAST a,COL_MAST c, UOM_MAST u
WHERE m."Comp_code"=compcode AND
m."cio_booking_id"=i."Cio_Booking_Id" AND
m."Agency_sub_code"=a."code_subcode" AND
i."Col_Code" =c."Col_Code" AND
u."Uom_Code"=m."Uom_code"
AND i."Insert_Date" BETWEEN fromdate AND dateto
and (i."Insert_Status"!=drpstatus or drpstatus is null)
AND (i."Publication_Code"=pub_name or pub_name is null)
AND (i."Pub_Cent_Code"=pub_cent or pub_cent is null)
AND (m."Ad_type_code"=Adtyp or Adtyp is null)
AND (i."Ad_Cat"=adcatg or adcatg is null)
AND (i."Edition_Code"=edition_name or edition_name is null)
AND (i."Supp_Code" =supplement_name or supplement_name is null)
AND (m."branch"  = p_branch  OR    p_branch  is null)
and (packagecode in (m."Package_code") or packagecode is null)
and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1)
or  (chk_access=0) )
group by i."Edition" order by i."Edition";

g1 p1%rowtype;

Cursor C1 Is
SELECT distinct i."Cio_Booking_Id" AS "CIOID",m."Package_code" as package_code,m."Gross_amount" as Crate
FROM TBL_BOOKING_MAST m, TBL_BOOKING_INSERT i--,multipack_rep
WHERE m."Comp_code"=compcode AND
m."cio_booking_id"=i."Cio_Booking_Id"
AND i."Insert_Date" BETWEEN fromdate AND dateto
AND (i."Publication_Code"=pub_name or pub_name is null)
AND (i."Pub_Cent_Code"=pub_cent or pub_cent is null)
AND (m."Ad_type_code"=Adtyp or Adtyp is null)
AND (i."Ad_Cat"=adcatg or adcatg is null)
AND (i."Edition_Code"=edition_name or edition_name is null)
AND (i."Supp_Code" =supplement_name or supplement_name is null)
AND (m."branch"  = p_branch  OR    p_branch  is null)
and (packagecode in (m."Package_code") or packagecode is null)
and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=puserid) and chk_access=1)
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


---------------------end -------------------------------
if(packagecode is null or editiondtl='1')then
    if(drpstatus ='includecancel' or drpstatus ='includehold') then
    
        query1:='select distinct x.comp_code as "COMP_CODE", x.cioid as "CIOID",x.agency as "AGENCY",x.agency_city as "AGENCY_CITY", 
        x.client  as "CLIENT",x.hue as "HUE",x.cardrate as "CARDRATE",x.agreedrate as "AGREEDRATE",
        x.caption as "CAPTION",x.key_no as "KEY_NO",x.RO_NO as "RO_NO",
        x.pagepremium as "PAGEPREMIUM",x.pospremium as "POSPREMIUM",
        x.width  as "WIDTH",x.depth as "DEPTH",x.area as "AREA",
        x.ins_date as "INSERT_DATE" ,
        case '''||dateformat||'''
        when ''mm/dd/yyyy'' then to_char(x.ins_date,''MM-DD-YY'')
        when ''dd/mm/yyyy'' then to_char(x.ins_date,''DD-MM-YY'')
        when ''yyyy/mm/dd'' then to_char(x.ins_date,''YY-MM-DD'') end
        as "INS_DATE" ,
        x.adcat as "ADCAT",x.adsubcat as "ADSUBCAT",x.adsubcat3 as "ADSUBCAT3",
        x.pageno as "PAGENO",x.ratecd as "RATECD",x.uom as "UOM",x.uomdesc as "UOMDESC",x.booktype as "booktype",x."AUDIT" as "AUDIT",
        x.app_status as "APP_STATUS",x.app_user as "APP_USER",x.no_insert as "NO_INSERT",x.branch_name as "BRANCH_NAME",
        x.package_name AS "PACKAGE_NAME",x.edition as "EDITION",
        x.trade_disc as "TRADE_DISC",sum(x.bill_amt) "BILL_AMT",x.bill_remarks as "BILL_REMARKS",x.bill_no as "BILL_NO",x.bill_date as "BILL_DATE",
        x.edition_name as "EDITION_NAME" from
        (select distinct m."Comp_code" comp_code, m."cio_booking_id" as cioid,a."Agency_Name" as agency,(select "City_Name" from city_mst where "City_Code"=a."City_Code") as agency_city, 
        nvl((select "Cust_Name" from cust_mast where "Cust_Code"=m."Client_code" and m."Comp_code"=cust_mast."Comp_Code" ),m."Client_code")  as client,
        c."Col_Alias" as hue,m."Card_rate" as cardrate,nvl(m."Agrred_rate",''0'')/*m."Card_rate")*/ as agreedrate,
        m."Caption" as caption,m."Key_no" as key_no,m."RO_No" as ro_no,
        (select advpos_prem_mast."premiumname" from advpos_prem_mast where advpos_prem_mast."Premiumcode"=i."Premium1" and advpos_prem_mast."comp_code"=m."Comp_code" ) as pagepremium,
        (select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=i."Page_Post" and advpos_type_mast."Comp_Code"=m."Comp_code" ) as pospremium,
        round(i."Size_Book",2) as area,
        i."Insert_Date" as ins_date,i."Width"  as width,i."Height" as depth,
        ac."Adv_Cat_Name" as adcat,
        (select adv_subcat_mast."Adv_Subcat_Name" from adv_subcat_mast where  adv_subcat_mast."Adv_Subcat_Code"=i."Ad_Sub_Cat" and adv_subcat_mast."Comp_Code"=m."Comp_code" ) as adsubcat,
        (select ad_cat3."catname" from ad_cat3 where  ad_cat3."catcode"=m."Ad_Subcat3" and ad_cat3."compcode"=m."Comp_code" ) as adsubcat3,
        i."Page_No" as pageno,m."Rate_code" as ratecd,
        u."Uom_Name" as uom,u."UOM_DESC" as uomdesc,m."Booking_type" as booktype,m."audit" as "AUDIT",
        m.app_status as app_status,m.app_user as app_user,
        i."No_Insert" as no_insert,b."Branch_Name" as branch_name,
        fetch_insert_package('''||compcode||''',m."cio_booking_id",i."No_Insert",''N'') as package_name,
        fetch_publish_edtnname(m."Comp_code",m."cio_booking_id",i."Insert_Date",null,'''||pub_name||''',null,'''||dateformat||''',null,null) as edition,
        m."Trade_disc" as trade_disc,i."Bill_Amt" as bill_amt,m."Bill_remarks" as bill_remarks,i.bill_no as bill_no,i.bill_date as bill_date,
        i."Edition" as edition_name
        from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,col_mast c,uom_mast u,branch_mst b,adv_cat_mast ac
        where m."Comp_code"='''||compcode||''' and m."Comp_code"=i."Comp_Code" and ac."Comp_Code"=i."Comp_Code" and
        m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
        i."Col_Code"=c."Col_Code" and b."Branch_Code"=m."branch" and ac."Adv_Cat_Code"=i."Ad_Cat" 
        and u."Uom_Code"=m."Uom_code"
        and not exists (select distinct ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
        and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')or  ('''||chk_access||'''=''0'') )
        and (('''||drpstatus||''' =''includecancel'' and  lower(i."Insert_Status") !=''hold'') or ('''||drpstatus||''' =''includehold'' and lower(i."Insert_Status") !=''cancel''))
        and i."Insert_Date" between '''||fromdate||''' and '''||dateto||'''';
        
    else

        query1:='select distinct x.comp_code as "COMP_CODE", x.cioid as "CIOID",x.agency as "AGENCY",x.agency_city as "AGENCY_CITY", 
        x.client  as "CLIENT",x.hue as "HUE",x.cardrate as "CARDRATE",x.agreedrate as "AGREEDRATE",
        x.caption as "CAPTION",x.key_no as "KEY_NO",x.RO_NO as "RO_NO",
        x.pagepremium as "PAGEPREMIUM",x.pospremium as "POSPREMIUM",
        x.width  as "WIDTH",x.depth as "DEPTH",x.area as "AREA",
        x.ins_date as "INSERT_DATE" ,
        case '''||dateformat||'''
        when ''mm/dd/yyyy'' then to_char(x.ins_date,''MM-DD-YY'')
        when ''dd/mm/yyyy'' then to_char(x.ins_date,''DD-MM-YY'')
        when ''yyyy/mm/dd'' then to_char(x.ins_date,''YY-MM-DD'') end
        as "INS_DATE" ,
        x.adcat as "ADCAT",x.adsubcat as "ADSUBCAT",x.adsubcat3 as "ADSUBCAT3",
        x.pageno as "PAGENO",x.ratecd as "RATECD",x.uom as "UOM",x.uomdesc as "UOMDESC",x.booktype as "booktype",x."AUDIT" as "AUDIT",
        x.app_status as "APP_STATUS",x.app_user as "APP_USER",x.no_insert as "NO_INSERT",x.branch_name as "BRANCH_NAME",
        x.package_name AS "PACKAGE_NAME",x.edition as "EDITION",
        x.trade_disc as "TRADE_DISC",sum(x.bill_amt) "BILL_AMT",x.bill_remarks as "BILL_REMARKS",x.bill_no as "BILL_NO",x.bill_date as "BILL_DATE",
        x.edition_name as "EDITION_NAME" from
        (select distinct m."Comp_code" comp_code, m."cio_booking_id" as cioid,a."Agency_Name" as agency,(select "City_Name" from city_mst where "City_Code"=a."City_Code") as agency_city, 
        nvl((select "Cust_Name" from cust_mast where "Cust_Code"=m."Client_code" and m."Comp_code"=cust_mast."Comp_Code" ),m."Client_code")  as client,
        c."Col_Alias" as hue,m."Card_rate" as cardrate,nvl(m."Agrred_rate",''0'')/*m."Card_rate")*/ as agreedrate,
        m."Caption" as caption,m."Key_no" as key_no,m."RO_No" as ro_no,
        (select advpos_prem_mast."premiumname" from advpos_prem_mast where advpos_prem_mast."Premiumcode"=i."Premium1" and advpos_prem_mast."comp_code"=m."Comp_code" ) as pagepremium,
        (select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=i."Page_Post" and advpos_type_mast."Comp_Code"=m."Comp_code" ) as pospremium,
        round(i."Size_Book",2) as area,
        i."Insert_Date" as ins_date,i."Width"  as width,i."Height" as depth,
        ac."Adv_Cat_Name" as adcat,
        (select adv_subcat_mast."Adv_Subcat_Name" from adv_subcat_mast where  adv_subcat_mast."Adv_Subcat_Code"=i."Ad_Sub_Cat" and adv_subcat_mast."Comp_Code"=m."Comp_code" ) as adsubcat,
        (select ad_cat3."catname" from ad_cat3 where  ad_cat3."catcode"=m."Ad_Subcat3" and ad_cat3."compcode"=m."Comp_code" ) as adsubcat3,
        i."Page_No" as pageno,m."Rate_code" as ratecd,
        u."Uom_Name" as uom,u."UOM_DESC" as uomdesc,m."Booking_type" as booktype,m."audit" as "AUDIT",
        m.app_status as app_status,m.app_user as app_user,
        i."No_Insert" as no_insert,b."Branch_Name" as branch_name,
        fetch_insert_package('''||compcode||''',m."cio_booking_id",i."No_Insert",''N'') as package_name,
        fetch_publish_edtnname(m."Comp_code",m."cio_booking_id",i."Insert_Date",null,'''||pub_name||''',null,'''||dateformat||''',null,null) as edition,
        m."Trade_disc" as trade_disc,i."Bill_Amt" as bill_amt,m."Bill_remarks" as bill_remarks,i.bill_no as bill_no,i.bill_date as bill_date,
        i."Edition" as edition_name
        from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,col_mast c,uom_mast u,branch_mst b,adv_cat_mast ac
        where m."Comp_code"='''||compcode||''' and m."Comp_code"=i."Comp_Code" and ac."Comp_Code"=i."Comp_Code" and
        m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
        i."Col_Code"=c."Col_Code" and b."Branch_Code"=m."branch" and ac."Adv_Cat_Code"=i."Ad_Cat" 
        and lower(i."Insert_Status") !=''cancel''and lower(i."Insert_Status") !=''hold''
        and u."Uom_Code"=m."Uom_code"
        and not exists (select distinct ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
        and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')or  ('''||chk_access||'''=''0'') )
        and i."Insert_Date" between '''||fromdate||''' and '''||dateto||'''';

    end if;

else
    if(drpstatus ='includecancel' or drpstatus ='includehold') then

        query1:='select distinct x.comp_code as "COMP_CODE", x.cioid as "CIOID",x.agency as "AGENCY",x.agency_city as "AGENCY_CITY", 
        x.client  as "CLIENT",x.hue as "HUE",x.cardrate as "CARDRATE",x.agreedrate as "AGREEDRATE",
        x.caption as "CAPTION",x.key_no as "KEY_NO",x.RO_NO as "RO_NO",
        x.pagepremium as "PAGEPREMIUM",x.pospremium as "POSPREMIUM",
        x.width  as "WIDTH",x.depth as "DEPTH",x.area as "AREA",
        x.ins_date as "INSERT_DATE" ,
        case '''||dateformat||'''
        when ''mm/dd/yyyy'' then to_char(x.ins_date,''MM-DD-YY'')
        when ''dd/mm/yyyy'' then to_char(x.ins_date,''DD-MM-YY'')
        when ''yyyy/mm/dd'' then to_char(x.ins_date,''YY-MM-DD'') end
        as "INS_DATE" ,
        x.adcat as "ADCAT",x.adsubcat as "ADSUBCAT",x.adsubcat3 as "ADSUBCAT3",
        x.pageno as "PAGENO",x.ratecd as "RATECD",x.uom as "UOM",x.uomdesc as "UOMDESC",x.booktype as "booktype",x."AUDIT" as "AUDIT",
        x.app_status as "APP_STATUS",x.app_user as "APP_USER",x.no_insert as "NO_INSERT",x.branch_name as "BRANCH_NAME",
        x.package_name AS "PACKAGE_NAME",x.edition as "EDITION",
        x.trade_disc as "TRADE_DISC",sum(x.bill_amt) "BILL_AMT",x.bill_remarks as "BILL_REMARKS",x.bill_no as "BILL_NO",x.bill_date as "BILL_DATE",
        x.edition_name as "EDITION_NAME" from
        (select distinct m."Comp_code" comp_code, m."cio_booking_id" as cioid,a."Agency_Name" as agency,(select "City_Name" from city_mst where "City_Code"=a."City_Code") as agency_city, 
        nvl((select "Cust_Name" from cust_mast where "Cust_Code"=m."Client_code" and m."Comp_code"=cust_mast."Comp_Code" ),m."Client_code")  as client,
        c."Col_Alias" as hue,m."Card_rate" as cardrate,nvl(m."Agrred_rate",''0'')/*m."Card_rate")*/ as agreedrate,
        m."Caption" as caption,m."Key_no" as key_no,m."RO_No" as ro_no,
        (select advpos_prem_mast."premiumname" from advpos_prem_mast where advpos_prem_mast."Premiumcode"=i."Premium1" and advpos_prem_mast."comp_code"=m."Comp_code" ) as pagepremium,
        (select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=i."Page_Post" and advpos_type_mast."Comp_Code"=m."Comp_code" ) as pospremium,
        round(i."Size_Book",2) as area,
        i."Insert_Date" as ins_date,i."Width"  as width,i."Height" as depth,
        ac."Adv_Cat_Name" as adcat,
        (select adv_subcat_mast."Adv_Subcat_Name" from adv_subcat_mast where  adv_subcat_mast."Adv_Subcat_Code"=i."Ad_Sub_Cat" and adv_subcat_mast."Comp_Code"=m."Comp_code" ) as adsubcat,
        (select ad_cat3."catname" from ad_cat3 where  ad_cat3."catcode"=m."Ad_Subcat3" and ad_cat3."compcode"=m."Comp_code" ) as adsubcat3,
        i."Page_No" as pageno,m."Rate_code" as ratecd,
        u."Uom_Name" as uom,u."UOM_DESC" as uomdesc,m."Booking_type" as booktype,m."audit" as "AUDIT",
        m.app_status as app_status,m.app_user as app_user,
        i."No_Insert" as no_insert,b."Branch_Name" as branch_name,
        fetch_insert_package('''||compcode||''',m."cio_booking_id",i."No_Insert",''N'') as package_name,
        fetch_publish_edtnname(m."Comp_code",m."cio_booking_id",i."Insert_Date",null,'''||pub_name||''',null,'''||dateformat||''',null,null) as edition,
        m."Trade_disc" as trade_disc,i."Bill_Amt" as bill_amt,m."Bill_remarks" as bill_remarks,i.bill_no as bill_no,i.bill_date as bill_date,
        i."Edition" as edition_name
        from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,col_mast c,uom_mast u,branch_mst b,adv_cat_mast ac
        where m."Comp_code"='''||compcode||''' and m."Comp_code"=i."Comp_Code" and ac."Comp_Code"=i."Comp_Code" and
        m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
        i."Col_Code"=c."Col_Code" and b."Branch_Code"=m."branch" and ac."Adv_Cat_Code"=i."Ad_Cat" 
        and u."Uom_Code"=m."Uom_code"
        and not exists (select distinct ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
        and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')or  ('''||chk_access||'''=''0'') )
        and (('''||drpstatus||''' =''includecancel'' and  lower(i."Insert_Status") !=''hold'') or ('''||drpstatus||''' =''includehold'' and lower(i."Insert_Status") !=''cancel''))
        and i."Insert_Date" between '''||fromdate||''' and '''||dateto||'''';
        
    else

        query1:='select distinct x.comp_code as "COMP_CODE", x.cioid as "CIOID",x.agency as "AGENCY",x.agency_city as "AGENCY_CITY", 
        x.client  as "CLIENT",x.hue as "HUE",x.cardrate as "CARDRATE",x.agreedrate as "AGREEDRATE",
        x.caption as "CAPTION",x.key_no as "KEY_NO",x.RO_NO as "RO_NO",
        x.pagepremium as "PAGEPREMIUM",x.pospremium as "POSPREMIUM",
        x.width  as "WIDTH",x.depth as "DEPTH",x.area as "AREA",
        x.ins_date as "INSERT_DATE" ,
        case '''||dateformat||'''
        when ''mm/dd/yyyy'' then to_char(x.ins_date,''MM-DD-YY'')
        when ''dd/mm/yyyy'' then to_char(x.ins_date,''DD-MM-YY'')
        when ''yyyy/mm/dd'' then to_char(x.ins_date,''YY-MM-DD'') end
        as "INS_DATE" ,
        x.adcat as "ADCAT",x.adsubcat as "ADSUBCAT",x.adsubcat3 as "ADSUBCAT3",
        x.pageno as "PAGENO",x.ratecd as "RATECD",x.uom as "UOM",x.uomdesc as "UOMDESC",x.booktype as "booktype",x."AUDIT" as "AUDIT",
        x.app_status as "APP_STATUS",x.app_user as "APP_USER",x.no_insert as "NO_INSERT",x.branch_name as "BRANCH_NAME",
        x.package_name AS "PACKAGE_NAME",x.edition as "EDITION",
        x.trade_disc as "TRADE_DISC",sum(x.bill_amt) "BILL_AMT",x.bill_remarks as "BILL_REMARKS",x.bill_no as "BILL_NO",x.bill_date as "BILL_DATE",
        x.edition_name as "EDITION_NAME" from
        (select distinct m."Comp_code" comp_code, m."cio_booking_id" as cioid,a."Agency_Name" as agency,(select "City_Name" from city_mst where "City_Code"=a."City_Code") as agency_city, 
        nvl((select "Cust_Name" from cust_mast where "Cust_Code"=m."Client_code" and m."Comp_code"=cust_mast."Comp_Code" ),m."Client_code")  as client,
        c."Col_Alias" as hue,m."Card_rate" as cardrate,nvl(m."Agrred_rate",''0'')/*m."Card_rate")*/ as agreedrate,
        m."Caption" as caption,m."Key_no" as key_no,m."RO_No" as ro_no,
        (select advpos_prem_mast."premiumname" from advpos_prem_mast where advpos_prem_mast."Premiumcode"=i."Premium1" and advpos_prem_mast."comp_code"=m."Comp_code" ) as pagepremium,
        (select advpos_type_mast."Pos_Type" from advpos_type_mast where advpos_type_mast."Pos_Type_Code"=i."Page_Post" and advpos_type_mast."Comp_Code"=m."Comp_code" ) as pospremium,
        round(i."Size_Book",2) as area,
        i."Insert_Date" as ins_date,i."Width"  as width,i."Height" as depth,
        ac."Adv_Cat_Name" as adcat,
        (select adv_subcat_mast."Adv_Subcat_Name" from adv_subcat_mast where  adv_subcat_mast."Adv_Subcat_Code"=i."Ad_Sub_Cat" and adv_subcat_mast."Comp_Code"=m."Comp_code" ) as adsubcat,
        (select ad_cat3."catname" from ad_cat3 where  ad_cat3."catcode"=m."Ad_Subcat3" and ad_cat3."compcode"=m."Comp_code" ) as adsubcat3,
        i."Page_No" as pageno,m."Rate_code" as ratecd,
        u."Uom_Name" as uom,u."UOM_DESC" as uomdesc,m."Booking_type" as booktype,m."audit" as "AUDIT",
        m.app_status as app_status,m.app_user as app_user,
        i."No_Insert" as no_insert,b."Branch_Name" as branch_name,
        fetch_insert_package('''||compcode||''',m."cio_booking_id",i."No_Insert",''N'') as package_name,
        fetch_publish_edtnname(m."Comp_code",m."cio_booking_id",i."Insert_Date",null,'''||pub_name||''',null,'''||dateformat||''',null,null) as edition,
        m."Trade_disc" as trade_disc,i."Bill_Amt" as bill_amt,m."Bill_remarks" as bill_remarks,i.bill_no as bill_no,i.bill_date as bill_date,
        i."Edition" as edition_name
        from tbl_booking_mast m,tbl_booking_insert i,agency_mast a,col_mast c,uom_mast u,branch_mst b,adv_cat_mast ac
        where m."Comp_code"='''||compcode||''' and m."Comp_code"=i."Comp_Code" and ac."Comp_Code"=i."Comp_Code" and
        m."cio_booking_id"=i."Cio_Booking_Id" and m."Agency_sub_code"=a."code_subcode" and
        i."Col_Code"=c."Col_Code" and b."Branch_Code"=m."branch" and ac."Adv_Cat_Code"=i."Ad_Cat" 
        and lower(i."Insert_Status") !=''cancel''and lower(i."Insert_Status") !=''hold''
        and u."Uom_Code"=m."Uom_code"
        and not exists (select distinct ''x'' from tbl_booking_mast where m."cio_booking_id"="prev_cioid" and "prev_cioid" is not null)
        and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||puserid||''') and '''||chk_access||'''=''1'')or  ('''||chk_access||'''=''0'') )
        and i."Insert_Date" between '''||fromdate||''' and '''||dateto||'''';
end if;
end if;

IF(pub_name IS NOT NULL )THEN
    query1:=query1||' AND i."Publication_Code"='''||pub_name||'''';
END IF;

IF(p_branch IS NOT NULL )THEN
    query1:=query1||' AND m."branch"='''||p_branch||'''';
END IF;

IF(adtyp IS NOT NULL) THEN
    query1:=query1|| ' AND m."Ad_type_code"='''||Adtyp||''' ';
END IF;

IF(p_uom IS NOT NULL) THEN
    query1:=query1|| ' AND m."Uom_code"='''||p_uom||''' ';
END IF;

IF(adcatg IS NOT NULL) THEN
    query1:=query1|| ' AND i."Ad_Cat" in ('''||adcatg||''' )';
END IF;

IF(edition_name IS NOT NULL ) THEN
    query1:=query1||'  AND i."Edition_Code"='''||edition_name||'''';
END IF;

IF(supplement_name IS NOT NULL ) THEN
    query1:=query1||' AND (i."Supp_Code" ='''||supplement_name||''' )';
END IF;

IF(packagecode IS NOT NULL ) THEN
    query1:=query1||' AND ('''||packagecode||''' in (m."Package_code") )';
END IF;

IF(pub_cent IS NOT NULL) THEN
    query2:='  AND i."Pub_Cent_Code"='''||pub_cent||'''';
END IF;

query_group:=' )x group by x.comp_code, x.cioid,x.agency,x.agency_city, x.client,x.hue,x.cardrate,x.agreedrate,
x.caption,x.key_no ,x.RO_NO,x.pagepremium,x.pospremium,x.width ,x.depth ,x.area,x.ins_date ,x.adcat,x.adsubcat ,x.adsubcat3 ,
x.pageno ,x.ratecd ,x.uom,x.uomdesc,x.booktype,x."AUDIT",x.app_status ,x.app_user,x.no_insert,x.branch_name,
x.package_name,x.edition,x.trade_disc,x.bill_remarks,x.bill_no,x.bill_date,x.edition_name';

if(packagecode is null)then
    query_group:=query_group||' order by cioid,insert_date';
else
    query_group:=query_group||' order by cioid,insert_date';
end if;

delete from searchtbl;insert into searchtbl values(query1); commit;
insert into searchtbl values(query2||query_group); commit;

OPEN p_accounts FOR query1||query2||query_group;

OPEN p_accounts1 FOR
select "Edition_Alias"  as "Editions"  from edition_mast where ("Pub_Code"=pub_name or pub_name is null)  and "Edition_Type"='Main Edition';

If nvl(poth_branch_flag,'N')='Y' and (pub_cent IS NOT NULL) then

    query2:=' AND not exists (select ''x'' from tbl_booking_insert where "Cio_Booking_Id"=m."cio_booking_id" and "No_Insert"=i."No_Insert" and "Pub_Cent_Code"='''||pub_cent||''')';
else
    query2:=' AND 1=2 ';
End If;

--delete from searchtbl;
insert into searchtbl values(query1); commit;
insert into searchtbl values(query2||query_group); commit;

OPEN p_accounts2 FOR
query1||query2||query_group;


OPEN p_accounts3 FOR
--select PACK, TOT from  MULTIPAGE_BREAK where  sess_id=userenv('sessionid') order by PACK,TOT desc;
 select count(distinct i."Cio_Booking_Id"||i."No_Insert") into v_billed from tbl_booking_mast m,tbl_booking_insert i
        where m."Comp_code"=compcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
        exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "Branch_Code"=p_branch) and
        m."Ad_type_code"=nvl(adtyp,m."Ad_type_code") AND i."Insert_Date" BETWEEN  fromdate AND  dateto and bill_no is not null;
        
    select count(distinct i."Cio_Booking_Id"||i."No_Insert") into v_booked_by_others from tbl_booking_mast m,tbl_booking_insert i
        where m."Comp_code"=compcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
        exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "Branch_Code"=p_branch) and
        m."Ad_type_code"=nvl(adtyp,m."Ad_type_code") AND i."Insert_Date" BETWEEN fromdate AND dateto        
        and not exists(select 'x' from tbl_booking_mast where m."Comp_code"=compcode and "prev_cioid" is not null and "prev_cioid"=m."cio_booking_id")
        and nvl(p_branch,'/')<>'/';
        
OPEN  p_accounts4 FOR
SELECT SYSDATE,initcap("Comp_Name") as "COMP_NAME" ,nvl(v_billed,0) as "ALREADY_BILLED", nvl(v_booked_by_others,0) as "BOOKED_BY_OTHERS" 
from comp_mst where "Comp_Code"=compcode;

delete from multipack_rep where sess_id=userenv('sessionid')  ;
delete from multipack_rat where sess_id=userenv('sessionid') ;
DELETE FROM multipack_ratnew where sess_id=userenv('sessionid')  ; 
DELETE FROM MULTIPAGE_BREAK where sess_id=userenv('sessionid')  ;commit;

end schedulereport_checklist;
/
/*****************************************************************************/

CREATE OR REPLACE PROCEDURE WEBSP_BINDCIOIDNEW1(
FROMDATE            IN VARCHAR2,
TODATE              IN VARCHAR2,
DATE1               IN VARCHAR2,
PUBLICATION         IN VARCHAR2,
BOOKINGCENTER       IN VARCHAR2,
REVENUECENTER       IN VARCHAR2,
AGENCYTYPE          IN VARCHAR2,
PACKAGE1            IN VARCHAR2,
ADTYPE1             IN VARCHAR2,
AGENCY              IN VARCHAR2,
CLIENT              IN VARCHAR2,
BILLSTATUS          IN VARCHAR2,
RATE_AUDIT          IN VARCHAR2,
BILLMODE            IN VARCHAR2,
BILLCYCLE           IN VARCHAR2,
V_RETAINER_NAME     IN VARCHAR2,
V_EXECUTIVE_NAME    IN VARCHAR2,
V_BRANCH_NAME       IN VARCHAR2,
V_AD_CATEGORY       IN VARCHAR2,
V_DISTRICT          IN VARCHAR2,
V_TALUKA            IN VARCHAR2,
PCOMPCODE           IN  VARCHAR2,
P_BILLNO            IN VARCHAR2,
P_BILL_GEN_PRIOR    IN VARCHAR2,
P_CENTERLOGIN       IN VARCHAR2,
P_PUB_CENT_HO       IN VARCHAR2,
P_FMG_BILL          IN VARCHAR2,
P_SCHEME_TYPE       IN VARCHAR2,
PTO_BILL_NO         IN VARCHAR2,
P_UOM               IN VARCHAR2,
PEXCLUDE_RATE_CODE  IN VARCHAR2,
P_RECORDSET         OUT CUR_TYPE_NEW1.CURSOR_TYPE,
P_RECORDSET1        OUT CUR_TYPE_NEW1.CURSOR_TYPE)

IS

query1      VARCHAR2(10000);
v_wherecl   VARCHAR2(2000);

v_bill_criteria varchar2(10);
v_dateformat    varchar2(100);
v_chkdt         date;
last_billno     number(10);
v_last_dt       date;
v_billed            number(10);
v_booked_by_others  number(10);
BEGIN
    if adtype1='DI0' then
        select disp_billing_criteria,"date_format" into v_bill_criteria,v_dateformat from preferrences where "comp_code"=pcompcode;
    else
        select clsd_billing_criteria,"date_format" into v_bill_criteria,v_dateformat from preferrences where "comp_code"=pcompcode;
    end if;
    
    IF(billstatus='3' AND rate_audit='n')
    THEN

      query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
      nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
      a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
      i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",round(sum(i."Bill_Amt"),2) as "Bill_Amt",
       i.BILL_NO
       ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
      FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"  AND
       i."Insert_Status"=''publish'' AND a."code_subcode"=m."Agency_sub_code" and m."audit" is not null 
       and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;


     IF(billstatus='3' AND rate_audit='y')
    THEN

          query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
     nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where
    cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",round(sum(i."Bill_Amt"),2) as "Bill_Amt",i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",
           fetch_unpublish_edtn('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",''1'',''N'',null,null) as "UNPUBLISHED"

          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"  AND
           i."Insert_Status"=''audit by rate'' AND a."code_subcode"=m."Agency_sub_code" and m."audit" is not null 
           and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='1' AND rate_audit='y'AND billmode='2')
    THEN

     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
     nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where
    cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",round(sum(i."Bill_Amt"),2) as "Bill_Amt",
           i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where m."Comp_code"='''||pcompcode||''' and i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
    AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status" =''audit by rate'' OR i."Insert_Status"=''billed'') and m."audit" is not null
    and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='1' AND rate_audit='n' AND billmode='2')
    THEN
     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",round(sum(i."Bill_Amt"),2) as "Bill_Amt",
           i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status" =''publish'' OR i."Insert_Status"=''billed'')  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='1' AND rate_audit='n' AND (billmode='1' OR billmode='3'))
    THEN
     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
          (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",round(sum(i."Bill_Amt"),2) as "Bill_Amt",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where m."Comp_code"='''||pcompcode||''' and i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status"=''billed'')  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='1' AND rate_audit='y' AND (billmode='1' OR billmode='3'))
    THEN

     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end  AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",round(sum(i."Bill_Amt"),2) as "Bill_Amt",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status"=''billed'')  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='3' AND rate_audit='n' AND (billmode='1' OR billmode='3'))
    THEN

     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end  AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",round(sum(i."Bill_Amt"),2) as "Bill_Amt",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status"=''billed'')  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus='3' AND rate_audit='y' AND (billmode='1' OR billmode='3'))
    THEN

     query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
          i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",round(sum(i."Bill_Amt"),2) as "Bill_Amt",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"
        AND a."code_subcode"=m."Agency_sub_code"  AND (i."Insert_Status"=''billed'')  and m."audit" is not null
        and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;

    IF(billstatus=2)
    THEN
     query1:=' SELECT DISTINCT  i."Cio_Booking_Id",i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition" ,
    nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
    a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
    i."Insert_Status" AS "status",m."No_of_insertion" AS  "total",m."Bill_remarks",round(sum(i."Bill_Amt"),2) as "Bill_Amt",i.BILL_NO
    ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
    FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"  AND
     i."Insert_Status"=''billed'' AND a."code_subcode"=m."Agency_sub_code"  and m."audit" is not null
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
    END IF;



    IF(billstatus='5')
    THEN

      query1:='SELECT  DISTINCT  i."Cio_Booking_Id", i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition",
      nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
      a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",m."Trade_disc" AS "Commission",to_char(min(i."Insert_Date"),'''||v_dateformat||''') as "pub_date",
      i."Insert_Status" AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",round(sum(i."Bill_Amt"),2) as "Bill_Amt",i.BILL_NO
      ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
      FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"  AND
       i."Insert_Status"=''publish'' AND a."code_subcode"=m."Agency_sub_code"  and m."audit" is not null
       and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ' ;
    END IF;


    IF(billstatus=6)
    THEN
     query1:=' SELECT DISTINCT  i."Cio_Booking_Id",i."No_Insert" AS "no_of_insertion" ,case when instr(m."Package_code",'','') >0 then fetch_insert_package('''||pcompcode||''',i."Cio_Booking_Id",i."No_Insert",null) else m."Package_code" end AS "edition" ,
    nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
    a."Agency_Name" AS "Agency",
    i."Insert_Status" AS "status",m."No_of_insertion" AS  "total",m."Bill_remarks",round(sum(i."Bill_Amt"),2) as "Bill_Amt",i.BILL_NO
    ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
    FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."Comp_code"='''||pcompcode||''' and m."cio_booking_id"=i."Cio_Booking_Id"  AND
     i."Insert_Status"=''booked'' AND a."code_subcode"=m."Agency_sub_code" 
     and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
    END IF;

    IF(v_retainer_name  IS NOT NULL)
    THEN
     v_wherecl:= v_wherecl ||' and m."RETAINER" ='''||v_retainer_name ||'''';
    END IF;


    IF(v_executive_name IS NOT NULL)
    THEN
     v_wherecl:= v_wherecl||' and m."Executive_code" ='''||v_executive_name ||'''';
    END IF;


    IF(v_branch_name  IS NOT NULL and v_branch_name <> 0)
    THEN
     v_wherecl:= v_wherecl ||' and m."branch" ='''||v_branch_name ||'''';
    END IF;


    IF(v_ad_category  IS NOT NULL)
    THEN
     v_wherecl:= v_wherecl ||' and m."Ad_cat_code" ='''||v_ad_category||'''';
    END IF;


    IF(v_district  IS NOT NULL)
    THEN
     v_wherecl:= v_wherecl ||' and m."Agency_sub_code"  in (select agency_mast."code_subcode" from agency_mast where agency_mast."Dist_Code" ='''||v_district||''' or '''||v_district||''' is null)';
    END IF;


    IF(v_taluka IS NOT NULL)
    THEN
     v_wherecl:= v_wherecl||'  AND m."Agency_sub_code"  in (select agency_mast."code_subcode" from agency_mast where (agency_mast."Dist_Code"  in(select DIST_CODE from taluka_mast where TALU_CODE='''||v_taluka||''' or '''||v_taluka||''' is null) )  AND agency_mast."Dist_Code"='''||v_district||''' OR '''||v_district||'''  IS NULL   )';
    END IF;

    if v_bill_criteria='A' then
        IF(billcycle IS NOT NULL)
        THEN
            v_wherecl:=v_wherecl ||' AND a."BILL_FREQUENCY"='''||billcycle ||'''';
        END IF;
    elsif v_bill_criteria='R' then

        IF(billcycle IS NOT NULL)
        THEN
            v_wherecl:=v_wherecl ||' AND m."Bill_cycle" ='''||billcycle ||'''';
        END IF;
    end if;
    
    IF(agency IS NOT NULL)
    THEN
    v_wherecl:=v_wherecl ||' AND m."Agency_sub_code" ='''||agency ||'''';
    END IF;

    IF(client IS NOT NULL)
    THEN
    v_wherecl:=v_wherecl ||' AND m."Client_code" ='''||client ||'''';
    END IF;


    IF(agencytype IS NOT NULL) THEN
        v_wherecl:=v_wherecl ||' AND m."Agency_type"  ='''||trim(agencytype)||'''';
    END IF;
    
    IF(adtype1 IS NOT NULL) THEN
        v_wherecl:=v_wherecl ||' AND m."Ad_type_code" ='''||adtype1||''' ';
    END IF;


    IF(bookingcenter  IS NOT NULL) THEN
        v_wherecl:=v_wherecl ||' AND exists(select ''x'' from branch_mst where "Branch_Code"=m."branch" and "pub_center" ='''||bookingcenter||''') ';
    END IF;

    if (P_FMG_BILL !='Include') then

        v_wherecl:=v_wherecl ||' AND m."Booking_type" not in (''2'',''4'',''5'')';

    end if;

    if(P_SCHEME_TYPE='EXCLUDE') THEN

        v_wherecl:=v_wherecl ||' AND i."Pai_Free_Ins"  in (''Y'')';

    END IF;

    IF(revenuecenter IS NOT NULL) THEN

        v_wherecl:=v_wherecl ||' AND m."Revenue_center" ='''||revenuecenter||''' ';
    
    END IF;

    IF(publication IS NOT NULL)
    THEN
        v_wherecl:=v_wherecl ||'AND  i."Publication_Code"='''||publication ||'''';
    END IF;

    if (P_BILLNO is not null) and (pto_bill_no is not null) then
       v_wherecl:=v_wherecl ||'AND  i.BILL_NO between '''||P_BILLNO||''' and '''||pto_bill_no||'''';
    END IF;



    IF(fromdate IS NOT NULL AND todate IS NOT NULL )
    THEN
        v_wherecl:=v_wherecl ||'  AND i."Insert_Date" BETWEEN  '''||fromdate ||''' AND  '''||todate ||''' ';
    END IF;
    
    if (P_UOM is not null) then
       v_wherecl:=v_wherecl ||'AND  m."Uom_code" = '''||P_UOM||'''';
    END IF;


    IF(PACKAGE1 IS NOT NULL)
    THEN
        v_wherecl:=v_wherecl ||' AND  i."Edition" ='''||PACKAGE1 ||'''';
    END IF;
    
    IF(PEXCLUDE_RATE_CODE IS NOT NULL OR PEXCLUDE_RATE_CODE<>'')
    THEN
        v_wherecl:=v_wherecl ||' AND  m."Rate_code" not in('||PEXCLUDE_RATE_CODE||')';

    END IF;    

    query1:=query1 ||v_wherecl||' group by i."Cio_Booking_Id",i."No_Insert" ,m."Package_code"
     , a."Agency_Name",m."Trade_disc",i."Insert_Status",m."No_of_insertion"
     ,m."Bill_remarks",m."Client_code",i.BILL_NO, i."Comp_Code"  order by i."Cio_Booking_Id", i."No_Insert"';


    delete from ank_search_new;insert into ank_search_new values(query1);commit;

    open p_recordset for query1;
    
    v_chkdt:=ad_get_finandt(pcompcode,fromdate,v_dateformat,null,null);
    
    select max(invoice_no) as "recno" into last_billno from tbl_invoiceno where comp_code=pcompcode and 
                center_code=bookingcenter and ad_get_finandt(pcompcode,fromdate,v_dateformat,null,null)=v_chkdt;
                
    select max(bildt) into v_last_dt from ad_bills 
    where comp_code_v=pcompcode and ad_get_finandt(comp_code_v,bildt,v_dateformat,null,null)=v_chkdt and 
    exists(select 'x' from branch_mst where "Branch_Code"=ad_bills.unit and "pub_center"=bookingcenter); 
    
    select count(distinct i."Cio_Booking_Id"||i."No_Insert") into v_billed from tbl_booking_mast m,tbl_booking_insert i
        where m."Comp_code"=pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
        exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "pub_center"=bookingcenter) and
        m."Ad_type_code"=nvl(adtype1,m."Ad_type_code") AND i."Insert_Date" BETWEEN  fromdate AND  todate and bill_no is not null;
        
    select count(distinct i."Cio_Booking_Id"||i."No_Insert") into v_booked_by_others from tbl_booking_mast m,tbl_booking_insert i
        where m."Comp_code"=pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
        not exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "pub_center"=bookingcenter) and
        m."Ad_type_code"=nvl(adtype1,m."Ad_type_code") AND i."Insert_Date" BETWEEN fromdate AND todate and
        i."Pub_Cent_Code"=bookingcenter
        and not exists(select 'x' from tbl_booking_mast where m."Comp_code"=pcompcode and "prev_cioid" is not null and "prev_cioid"=m."cio_booking_id");
        

    open p_recordset1 for 
    select nvl(last_billno,0) as "LAST_BILLNO",to_char(v_last_dt,v_dateformat) as "LAST_BILLDT",nvl(v_billed,0) as "ALREADY_BILLED",
     nvl(v_booked_by_others,0) as "BOOKED_BY_OTHERS" from dual;

END ;
/

/**************************************************************************/

CREATE OR REPLACE PROCEDURE ERPTEST.websp_bindcioidnew1_combined (
   FROMDATE           IN       VARCHAR2,
   TODATE             IN       VARCHAR2,
   DATE1              IN       VARCHAR2,
   PUBLICATION        IN       VARCHAR2,
   BOOKINGCENTER      IN       VARCHAR2,
   REVENUECENTER      IN       VARCHAR2,
   AGENCYTYPE         IN       VARCHAR2,
   PACKAGE1           IN       VARCHAR2,
   ADTYPE1            IN       VARCHAR2,
   AGENCY             IN       VARCHAR2,
   CLIENT             IN       VARCHAR2,
   BILLSTATUS         IN       VARCHAR2,
   RATE_AUDIT         IN       VARCHAR2,
   BILLMODE           IN       VARCHAR2,
   BILLCYCLE          IN       VARCHAR2,
   V_RETAINER_NAME    IN       VARCHAR2,
   V_EXECUTIVE_NAME   IN       VARCHAR2,
   V_BRANCH_NAME      IN       VARCHAR2,
   V_AD_CATEGORY      IN       VARCHAR2,
   V_DISTRICT         IN       VARCHAR2,
   V_TALUKA           IN       VARCHAR2,
   PCOMPCODE          IN       VARCHAR2,
   P_BILLNO           IN       VARCHAR2,
   P_BILL_GEN_PRIOR   IN       VARCHAR2,
   P_CENTERLOGIN      IN       VARCHAR2,
   P_PUB_CENT_HO      IN       VARCHAR2,
   P_FMG_BILL         IN       VARCHAR2,
   P_SCHEME_TYPE      IN       VARCHAR2,
   PTO_BILL_NO        IN       VARCHAR2,
   P_UOM              IN       VARCHAR2,
   PEXCLUDE_RATE_CODE IN VARCHAR2,
   P_RECORDSET        OUT      CUR_TYPE_NEW1.CURSOR_TYPE,
   P_RECORDSET1        OUT CUR_TYPE_NEW1.CURSOR_TYPE
)
IS
   query1            VARCHAR2 (10000);
   v_bill_criteria   VARCHAR2 (10);
   
    v_dateformat    varchar2(100);
    v_chkdt         date;
    last_billno     number(10);
    v_last_dt       date;
    v_billed            number(10);
    v_booked_by_others  number(10);
begin
   if adtype1 = 'DI0' then
      select disp_billing_criteria,"date_format" into v_bill_criteria,v_dateformat from preferrences where "comp_code" = pcompcode;
   else
      select clsd_billing_criteria,"date_format" into v_bill_criteria,v_dateformat from preferrences where "comp_code" = pcompcode;
   end if;

   IF (billstatus = '3' AND rate_audit = 'n') THEN
      query1 :=' SELECT DISTINCT  i."Cio_Booking_Id", max(i."No_Insert") AS "no_of_insertion" ,m."Package_code"  AS "edition",
      nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
      a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",round(sum(i."Bill_Amt"),2) as "Bill_Amt",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
      min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO,
      (select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
      FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
      a."code_subcode"=m."Agency_sub_code" and m."audit" is not null and  m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''publish'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '3' AND rate_audit = 'y') THEN
      query1 :=' SELECT DISTINCT  i."Cio_Booking_Id", max(i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
     nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where
    cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",round(sum(i."Bill_Amt"),2) as "Bill_Amt",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",
           fetch_unpublish_edtn('''||pcompcode||''',i."Cio_Booking_Id",null,''2'',''N'',null,null) as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
           i."Insert_Status" not in(''cancel'',''hold'') and  a."code_subcode"=m."Agency_sub_code" and m."audit" is not null
           and  m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''audit by rate'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''') 
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '1' AND rate_audit = 'y' AND billmode = '2')
   THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", max(i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
     nvl((select distinct cust_mast."Cust_Alias" from cust_mast  where
    cust_mast."Cust_Code"=m."Client_code"),m."Client_code") as "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",round(sum(i."Bill_Amt"),2) as "Bill_Amt",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
        AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and m."audit" is not null
        and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND (b."Insert_Status" =''audit by rate'' OR b."Insert_Status"=''billed'') AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''') 
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '1' AND rate_audit = 'n' AND billmode = '2')
   THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", max(i."No_Insert") AS "no_of_insertion" ,m."Package_code"AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",round(sum(i."Bill_Amt"),2) as "Bill_Amt",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
           ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
        AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and 
        m."audit" is not null
        and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND (b."Insert_Status" =''publish'' OR b."Insert_Status"=''billed'') AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '1' AND rate_audit = 'n' AND (billmode = '1' OR billmode = '3'))
   THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
          (SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",round(sum(i."Bill_Amt"),2) as "Bill_Amt",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
          AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and 
          m."audit" is not null 
          and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '1' AND rate_audit = 'y'AND (billmode = '1' OR billmode = '3'))THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",round(sum(i."Bill_Amt"),2) as "Bill_Amt",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
            AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and 
           m."audit" is not null 
           and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") '
           ;
   END IF;

   IF (billstatus = '3' AND rate_audit = 'n' AND (billmode = '1' OR billmode = '3')) THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",round(sum(i."Bill_Amt"),2) as "Bill_Amt",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
     AND a."code_subcode"=m."Agency_sub_code"  AND 
     i."Insert_Status" not in(''cancel'',''hold'') and m."audit" is not null
     and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '3' AND rate_audit = 'y'AND (billmode = '1' OR billmode = '3')) THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
          nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
          a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",round(sum(i."Bill_Amt"),2) as "Bill_Amt",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
          min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
          ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
          FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"
        AND a."code_subcode"=m."Agency_sub_code"  AND i."Insert_Status" not in(''cancel'',''hold'') and 
        m."audit" is not null 
        and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = 2) THEN
      query1 :=
            ' SELECT DISTINCT  i."Cio_Booking_Id",count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition" ,
    nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
    a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",round(sum(i."Bill_Amt"),2) as "Bill_Amt",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
    min(i."Insert_Status") AS "status",m."No_of_insertion" AS  "total",m."Bill_remarks",i.BILL_NO
    ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
    FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
     i."Insert_Status" not in(''cancel'',''hold'') and a."code_subcode"=m."Agency_sub_code"  and m."audit" is not null
     and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''billed'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = '5') THEN
      query1 :=
            'SELECT  DISTINCT  i."Cio_Booking_Id", count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition",
      nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
      a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",round(sum(i."Bill_Amt"),2) as "Bill_Amt",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
      min(i."Insert_Status") AS "status",m."No_of_insertion" AS "total",m."Bill_remarks",i.BILL_NO
      ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
      FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
       i."Insert_Status" not in(''cancel'',''hold'') and a."code_subcode"=m."Agency_sub_code" and m."audit" is not null
       and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''publish'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (billstatus = 6)THEN
      query1 :=
            ' SELECT DISTINCT  i."Cio_Booking_Id",count(distinct i."No_Insert") AS "no_of_insertion" ,m."Package_code" AS "edition" ,
        nvl((SELECT CUST_MAST."Cust_Alias" FROM CUST_MAST  WHERE CUST_MAST."Cust_Code" = m."Client_code"),m."Client_code") AS "client",
        a."Agency_Name" AS "Agency",sum(i."Gross_Rate") as "Gross_Rate",round(sum(i."Bill_Amt"),2) as "Bill_Amt",m."Trade_disc" AS "Commission",min(i."Insert_Date") as "pub_date",
        min(i."Insert_Status") AS "status",m."No_of_insertion" AS  "total",m."Bill_remarks",i.BILL_NO
        ,(select max(nvl(ad_bills.PRINT_COUNT,0)) from ad_bills  where  i."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=i.BILL_NO) as "PrintCount",null as "UNPUBLISHED"
        FROM TBL_BOOKING_INSERT i,TBL_BOOKING_MAST m,AGENCY_MAST a WHERE m."cio_booking_id"=i."Cio_Booking_Id"  AND
         i."Insert_Status" not in(''cancel'',''hold'') and a."code_subcode"=m."Agency_sub_code" 
         and m."cio_booking_id" in (select distinct a."cio_booking_id" from tbl_booking_mast a,tbl_booking_insert b
      where a."cio_booking_id"=b."Cio_Booking_Id" AND b."Insert_Status"=''booked'' AND b."Insert_Date" between '''||fromdate||''' and '''||todate||''' and 
      b."Insert_Status" not in(''cancel'') and a."Bill_cycle"='''||billcycle||''')
      and not exists(select ''x'' from ad_direct_client_agency where ag_main_code||ag_sub_code=m."Agency_sub_code") ';
   END IF;

   IF (v_retainer_name IS NOT NULL) THEN
      query1 := query1 || ' and m."RETAINER" =''' || v_retainer_name || '''';
   END IF;

   IF (v_executive_name IS NOT NULL) THEN
      query1 :=
          query1 || ' and m."Executive_code" =''' || v_executive_name || '''';
   END IF;

   IF (v_branch_name IS NOT NULL  AND v_branch_name <> 0) THEN
      query1 := query1 || ' and m."branch" =''' || v_branch_name || '''';
   END IF;

   IF (v_ad_category IS NOT NULL) THEN
      query1 := query1 || ' and m."Ad_cat_code" =''' || v_ad_category || '''';
   END IF;

   IF (v_district IS NOT NULL) THEN
      query1 :=
            query1|| ' and exists (select ''x'' from agency_mast where m."Agency_sub_code"=agency_mast."code_subcode" and agency_mast."Dist_Code" ='''|| v_district|| ''' or '''|| v_district|| ''' is null)';
   END IF;

   IF (v_taluka IS NOT NULL) THEN
      query1 :=
            query1|| '  AND exists (select ''x'' from agency_mast where m."Agency_sub_code"=agency_mast."code_subcode" and (agency_mast."Dist_Code"  in(select DIST_CODE from taluka_mast where TALU_CODE='''|| v_taluka|| ''' or '''|| v_taluka|| ''' is null) )  AND agency_mast."Dist_Code"='''|| v_district|| ''' OR '''|| v_district|| '''  IS NULL   )';
   END IF;

   IF v_bill_criteria = 'A'
   THEN
      IF (billcycle IS NOT NULL) THEN
         query1 :=query1 || ' AND a."BILL_FREQUENCY"=''' || billcycle || '''';
      END IF;
   ELSIF v_bill_criteria = 'R'
   THEN
      IF (billcycle IS NOT NULL) THEN
         query1 := query1 || ' AND m."Bill_cycle" =''' || billcycle || '''';
      END IF;
   END IF;

   IF (agency IS NOT NULL) THEN
      query1 := query1 || ' AND m."Agency_sub_code" =''' || agency || '''';
   END IF;

   IF (client IS NOT NULL) THEN
      query1 := query1 || ' AND m."Client_code" =''' || client || '''';
   END IF;

   IF (agencytype IS NOT NULL) THEN
      query1 :=query1 || ' AND m."Agency_type"  =''' || TRIM (agencytype)|| '''';
   END IF;

   IF (adtype1 IS NOT NULL) THEN
      query1 := query1 || ' AND m."Ad_type_code" =''' || adtype1 || ''' ';
   END IF;

   IF (bookingcenter IS NOT NULL) THEN
      query1:=query1 ||' AND exists(select ''x'' from branch_mst where "Branch_Code"=m."branch" and "pub_center" ='''||bookingcenter||''') ';
   END IF;

   IF (p_fmg_bill != 'Include') THEN
      query1 := query1 || ' AND m."Booking_type" not in (''2'',''4'',''5'')';
   END IF;

   IF (p_scheme_type = 'EXCLUDE') THEN
      query1 := query1 || ' AND i."Pai_Free_Ins"  in (''Y'')';
   END IF;

   IF (revenuecenter IS NOT NULL) THEN
      query1 := query1 || ' AND m."Revenue_center" =''' || revenuecenter || ''' ';
   END IF;

   IF (publication IS NOT NULL) THEN
      query1 :=
              query1 || ' AND  i."Publication_Code"=''' || publication || '''';
   END IF;

   IF (p_billno IS NOT NULL) AND (pto_bill_no IS NOT NULL) THEN
      query1 :=query1||' AND  i.BILL_NO between '''||p_billno||''' and '''||pto_bill_no||'''';
   END IF;

   IF (p_uom IS NOT NULL) THEN
      query1 := query1 || 'AND  m."Uom_code" = ''' || p_uom || '''';
   END IF;

   IF (package1 IS NOT NULL) THEN
      query1 := query1 || ' AND  i."Edition" =''' || package1 || '''';
   END IF;
   
    IF(PEXCLUDE_RATE_CODE IS NOT NULL OR PEXCLUDE_RATE_CODE<>'')
    THEN
        query1:=query1 ||' AND  m."Rate_code" not in('||PEXCLUDE_RATE_CODE||')';

    END IF;    


   query1 :=query1|| 'group by i."Cio_Booking_Id",m."Package_code", a."Agency_Name",m."Trade_disc",m."No_of_insertion"
     ,m."Bill_remarks",m."Client_code",i.BILL_NO, i."Comp_Code"  order by i."Cio_Booking_Id"';

   delete from ank_search_new;insert into ank_search_new values (query1);commit;

   OPEN p_recordset FOR query1;
   
   v_chkdt:=ad_get_finandt(pcompcode,fromdate,v_dateformat,null,null);
    
    select max(invoice_no) as "recno" into last_billno from tbl_invoiceno where comp_code=pcompcode and 
                center_code=bookingcenter and ad_get_finandt(pcompcode,fromdate,v_dateformat,null,null)=v_chkdt;
                
    select max(bildt) into v_last_dt from ad_bills 
    where comp_code_v=pcompcode and ad_get_finandt(comp_code_v,bildt,v_dateformat,null,null)=v_chkdt and 
    exists(select 'x' from branch_mst where "Branch_Code"=ad_bills.unit and "pub_center"=bookingcenter); 
    
    select count(distinct i."Cio_Booking_Id"||i."No_Insert") into v_billed from tbl_booking_mast m,tbl_booking_insert i
        where m."Comp_code"=pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
        exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "pub_center"=bookingcenter) and
        m."Ad_type_code"=nvl(adtype1,m."Ad_type_code") AND i."Insert_Date" BETWEEN  fromdate AND  todate and bill_no is not null;
        
    select count(distinct i."Cio_Booking_Id"||i."No_Insert") into v_booked_by_others from tbl_booking_mast m,tbl_booking_insert i
        where m."Comp_code"=pcompcode and m."cio_booking_id"=i."Cio_Booking_Id" and 
        not exists (select 'x' from branch_mst where "Branch_Code"=m."branch" and "pub_center"=bookingcenter) and
        m."Ad_type_code"=nvl(adtype1,m."Ad_type_code") AND i."Insert_Date" BETWEEN fromdate AND todate and
        i."Pub_Cent_Code"=bookingcenter 
        and not exists(select 'x' from tbl_booking_mast where m."Comp_code"=pcompcode and "prev_cioid" is not null and "prev_cioid"=m."cio_booking_id");
        

    open p_recordset1 for 
    select nvl(last_billno,0) as "LAST_BILLNO",to_char(v_last_dt,v_dateformat) as "LAST_BILLDT",nvl(v_billed,0) as "ALREADY_BILLED",
     nvl(v_booked_by_others,0) as "BOOKED_BY_OTHERS" from dual;
     
END websp_bindcioidnew1_combined;
/

/******************kuldeep ****************16042012******************************/


==========================start======25-may2012=======7588======avinash====================================================
CREATE OR REPLACE PROCEDURE HT18JULY.Schedulereport1(
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
    p_accounts4     out Cur_Type_New1.cursor_type) IS
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
and "cio_booking_id" not in(select distinct "prev_cioid" from tbl_booking_mast where "prev_cioid" is not null)
and ((drpstatus ='includecancel' and  lower("Insert_Status") !='hold') 
   or (drpstatus ='includehold' and lower("Insert_Status") !='cancel')
   or (drpstatus ='cancel' and lower("Insert_Status") !='cancel' and lower("Insert_Status") !='hold') )
-- and (TBL_BOOKING_INSERT."Insert_Status"!=drpstatus or drpstatus is null)

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
        ,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT",
        (select distinct "Branch_Name" from branch_mst where "Branch_Code"=TBL_BOOKING_MAST."branch") as "BRANCH_NAME"
        ,AD_GET_CITYNAME(TBL_BOOKING_MAST."Comp_code",AGENCY_MAST."City_Code") CITY_NAME
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
    ,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT",
    (select distinct "Branch_Name" from branch_mst where "Branch_Code"=TBL_BOOKING_MAST."branch") as "BRANCH_NAME"
     ,AD_GET_CITYNAME(TBL_BOOKING_MAST."Comp_code",AGENCY_MAST."City_Code") CITY_NAME
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
     ,AD_GET_CITYNAME(TBL_BOOKING_MAST."Comp_code",AGENCY_MAST."City_Code") CITY_NAME
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
    ,tbl_booking_insert."File_Name" as "FILE_NAME",TBL_BOOKING_MAST.APP_STATUS as "APP_STATUS",tbl_booking_insert."No_Insert" as "NO_INSERT",
    (select distinct "Branch_Name" from branch_mst where "Branch_Code"=TBL_BOOKING_MAST."branch") as "BRANCH_NAME"
     ,AD_GET_CITYNAME(TBL_BOOKING_MAST."Comp_code",AGENCY_MAST."City_Code") CITY_NAME
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


IF(fromdate IS NOT NULL AND dateto IS NOT NULL ) THEN
    query1:=query1||' AND TBL_BOOKING_INSERT."Insert_Date" BETWEEN '''||fromdate||''' AND '''||dateto||''' ';
END IF;


IF(pub_name IS NOT NULL )THEN
    query1:=query1||' AND TBL_BOOKING_INSERT."Publication_Code"='''||pub_name||'''';
END IF;

IF(p_branch IS NOT NULL )THEN
    query1:=query1||' AND TBL_BOOKING_MAST."branch"='''||p_branch||'''';
END IF;

IF(pub_cent IS NOT NULL) THEN
    query1:=query1||'  AND TBL_BOOKING_INSERT."Pub_Cent_Code"='''||pub_cent||'''';
END IF;


IF(adtyp IS NOT NULL) THEN
    query1:=query1|| ' AND TBL_BOOKING_MAST."Ad_type_code"='''||Adtyp||''' ';
END IF;

IF(adcatg IS NOT NULL) THEN
    query1:=query1|| ' AND tbl_booking_insert."Ad_Cat" in ('''||adcatg||''' )';
END IF;

IF(edition_name IS NOT NULL ) THEN
    query1:=query1||'  AND TBL_BOOKING_INSERT."Edition_Code"='''||edition_name||'''';
END IF;

IF(supplement_name IS NOT NULL ) THEN
    query1:=query1||' AND (TBL_BOOKING_insert."Supp_Code" ='''||supplement_name||''' )';
END IF;

IF(packagecode IS NOT NULL ) THEN
    query1:=query1||' AND ('''||packagecode||''' in (tbl_booking_mast."Package_code") )';
END IF;

if(packagecode is null)then

    IF(descid IS NOT  NULL) THEN
        query1:=query1||'  order by "'||descid||'",TBL_BOOKING_INSERT."Edition"';
        query1:=query1||''||ascdesc||'';
    else
        query1:=query1||' order by TBL_BOOKING_INSERT."Edition",TBL_BOOKING_MAST."cio_booking_id"';
    END IF;

else
    IF(descid IS NOT  NULL) THEN
        query1:=query1||'  order by "'||descid||'"';
        query1:=query1||''||ascdesc||'';
    else
        query1:=query1||' order by TBL_BOOKING_MAST."cio_booking_id"';
    END IF;
end if;
delete from searchtbl;insert into searchtbl values(query1); commit;

OPEN p_accounts FOR query1;

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

==========================end======25-may2012=======7588======avinash====================================================