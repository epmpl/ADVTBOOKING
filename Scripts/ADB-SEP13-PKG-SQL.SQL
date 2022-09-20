
ALTER PROCEDURE [dbo].[ad_bill_adjustment]

@pcompcode           as varchar(20),
@punit               as varchar(20),
@pdatefrom           as datetime,
@pdateto             as datetime,
@pag_main_code       as varchar(30),
@pag_sub_code        as varchar(30),
@pdoctype            as varchar(10),--for RCP---
@pbooking_id         as varchar(50),
@precptno            as varchar(50),
@puserid             as varchar(20),
@pdateformat         as varchar(20),
@pextra1             as varchar(20),
@pextra2             as varchar(20)

AS


declare  @v_frdt as datetime
declare  @v_todt as datetime
declare  @v_cnt1 as numeric(10)
declare @v_cnt2  as   numeric(10)
declare @v_cnt3 as numeric(10)
declare @v_cnt4 as numeric(10)
declare @vdummy as numeric(15,2)
declare @v_canmiss as varchar(20)
declare @v_adjust_amt as numeric(15,2)

set @vdummy=0

-- cursor c1 variables
declare @v1_unit as varchar(30)
declare @v1_doctype as varchar(30)
declare @v1_bkfor as varchar(50)
declare @v1_recptno as varchar(50)
declare @v1_recptdt as datetime
declare @v1_ag_main_code as varchar(30)
declare @v1_ag_sub_code as varchar(30)
declare @v1_bk_agcode as varchar(30)
declare @v1_bk_agsubcode as varchar(30)
declare @v1_receipt_no as varchar(50)
declare @v1_chno as varchar(100)
declare @v1_chdt as datetime
declare @v1_bank as varchar(100)
declare @v1_reason as varchar(30)
declare @v1_voucherno as varchar(50)
declare @v1_voucherdate as datetime
declare @v1_comp_code as varchar(30)
declare @v1_received_region as varchar(50)
declare @v1_retainer_code as varchar(100)
declare @v1_exec_code as varchar(100)
--cursor c12---
declare @v12_billno as varchar(50)
declare @v12_billdt as datetime
declare @v12_pripub as varchar(50)
declare @v12_bkfor as varchar(50)
declare @v12_retainer_code as varchar(50)
declare @v12_exec_code as varchar(50)
declare @v12_rec_amount   as decimal(15,2)
declare @v12_ad_type   as varchar(50)
declare @v12_priproctg as varchar(50)

--cursor c2---
declare @v2_billno as varchar(50)
declare @v2_billdt as datetime
declare @v2_amount as numeric(15,2)
-----------------------
declare @dsign numeric(2);
--if(@pdateformat='dd/mm/yyyy')
--begin
--    set @v_frdt= convert(varchar(10),@pfrom_date,103)
--    set @v_todt= convert(varchar(10),@ptill_date,103)
--    set @vrct_upto= convert(varchar(10),@prcpt_upto,103)
--end
--else if(@pdateformat='mm/dd/yyyy')
--begin
--    set @v_frdt= convert(varchar(10),@pfrom_date,101)
--    set @v_todt= convert(varchar(10),@ptill_date,101)
--    set @vrct_upto= convert(varchar(10),@prcpt_upto,101)
--end
--else
--begin
--    set @v_frdt= convert(varchar(10),@pfrom_date,111)
--    set @v_todt= convert(varchar(10),@ptill_date,111)
--    set @vrct_upto= convert(varchar(10),@prcpt_upto,111)
--end

set @v_frdt= @pdatefrom
set @v_todt= @pdateto
print 'CLAI120002089'

declare c1 cursor for select unit, doctype, bkfor, recptno, recptdt, 
                             ag_main_code, ag_sub_code, bk_agcode, bk_agsubcode,/*amount amount,*/ receipt_no,
                             chno, chdt, bank, reason, voucherno,
                             voucherdate, comp_code, received_region, retainer_code, exec_code from ad_outstand  
                         where comp_code=@pcompcode 
                          and (unit =@punit or @punit is null) 
                          and  doctype='RCP' 
                          and (doctype=@pdoctype or @pdoctype is null) 
                          and (ag_main_code=@pag_main_code or @pag_main_code is null) 
                          and (ag_sub_code=@pag_sub_code or @pag_sub_code is null) 
                          and (receipt_no=@pbooking_id or @pbooking_id is null) 
                          and  receipt_no is not null 
                          and  recptdt between @v_frdt and @v_todt 
                          and (recptno=@precptno or @precptno is null) 
                          and billno is null 
                          and amount<0
                         order by recptdt,recptno;


declare @v_rem_amt numeric(15,2)
declare @v_rcpamt numeric(15,2)
PRINT '1-1'
set @v_rem_amt =0
set @v_rcpamt =0
set @v_frdt= @pdatefrom
set @v_todt= @pdateto
PRINT '1-2'
open c1
        fetch NEXT FROM c1 INTO @v1_unit, @v1_doctype, @v1_bkfor, @v1_recptno, @v1_recptdt,
                                @v1_ag_main_code, @v1_ag_sub_code, @v1_bk_agcode, @v1_bk_agsubcode, @v1_receipt_no,
                                @v1_chno, @v1_chdt, @v1_bank, @v1_reason, @v1_voucherno,
                                @v1_voucherdate, @v1_comp_code, @v1_received_region, @v1_retainer_code, @v1_exec_code
        
        PRINT '@@FETCH_STATUS'
        PRINT @@FETCH_STATUS
        WHILE (@@FETCH_STATUS = 0) 
        BEGIN
/****************************/
PRINT '1-3'
PRINT '@v1_receipt_no'
PRINT @v1_receipt_no
declare c12 cursor for select billno, billdt, pripub, bkfor, retainer_code,
                              exec_code, amount /*ad_type, priproctg*/ from ad_outstand 
                         where comp_code=@v1_comp_code 
                           and doctype='BILL' 
                           and ag_main_code=@v1_ag_main_code 
                           and ag_sub_code=@v1_ag_sub_code 
                           and billno is not null 
                           and receipt_no=@v1_receipt_no 
                           and cast(billdt as varchar)+billno not in (select cast(billdt as varchar)+billno from ad_outstand 
                                                                         where comp_code=@v1_comp_code 
                                                                           and ag_main_code=@v1_ag_main_code 
                                                                           and ag_sub_code=@v1_ag_sub_code 
                                                                           and receipt_no=@v1_receipt_no 
                                                                         group by billno,billdt 
                                                                         having sum(amount)=0)
                          order by billdt,billno;

/****************************/
print '2'
        open c12
            fetch NEXT FROM c12 INTO @v12_billno, @v12_billdt, @v12_pripub, @v12_bkfor, @v12_retainer_code,
                                     @v12_exec_code, @v12_rec_amount
            WHILE (@@FETCH_STATUS = 0) 
            BEGIN
PRINT '@v12_billno'
PRINT @v1_comp_code
PRINT @v1_ag_main_code
PRINT @v1_ag_sub_code
PRINT @v12_billdt
PRINT @v12_billno
PRINT @v12_billno
/****************************/
declare c2 cursor for select billno, billdt, sum(amount) amount from ad_outstand 
                        where comp_code=@v1_comp_code 
                          and ag_main_code=@v1_ag_main_code 
                          and ag_sub_code=@v1_ag_sub_code 
                         -- and billdt=@v12_billdt 
                          and billno=@v12_billno
                        group by billno,billdt 
                        having sum(amount)>0 
                        order by billdt,billno;
                        PRINT 'S1'

/****************************/
            open c2
                fetch NEXT FROM c2 INTO @v2_billno, @v2_billdt, @v2_amount                
            close c2;
            deallocate c2
                PRINT 'S2'
                PRINT @v2_billno
                    if @v2_billno is not null and @v2_billdt is not null and @v2_amount>0 begin                
                           select @v_cnt1=count(*) from ad_rcptdet 
                        where comp_code        =@v1_comp_code and 
                              ag_main_code=@v1_ag_main_code and 
                              ag_sub_code =@v1_ag_sub_code and 
                              doctype     =@v1_doctype and 
                              recptno     =@v1_recptno and 
                              recptdt     =@v1_recptdt and 
                              billno      =@v2_billno and 
                              billdt      =@v2_billdt;
                                PRINT 'S3'
                        select @v_cnt2=count(*) from ad_outstand
                        where comp_code     =@v1_comp_code and 
                              doctype       =@v1_doctype and 
                              ag_main_code  =@v1_ag_main_code and 
                              ag_sub_code   =@v1_ag_sub_code and 
                              billdt        =@v2_billdt and
                              recptno       =@v1_recptno and 
                              recptdt       =@v1_recptdt and 
                              billno        =@v2_billno;
                              PRINT 'S4'
                            select @v_rcpamt=amount from ad_rcpthdr
                            where   comp_code   =@v1_comp_code and
                                    ag_main_code=@v1_ag_main_code and 
                                    ag_sub_code =@v1_ag_sub_code and 
                                    doctype     =@v1_doctype and 
                                    recptno     =@v1_recptno and 
                                    recptdt     =@v1_recptdt;
                            if(@v_rcpamt is null or @v_rcpamt=0)
                            begin
                                set @v_rcpamt=0;
                            end
                            PRINT @v_rcpamt
                            PRINT @v1_comp_code
                            PRINT @v1_ag_main_code
                            PRINT @v1_ag_sub_code
                            PRINT @v1_doctype
                            PRINT @v1_recptno
                            PRINT @v1_recptdt
                            PRINT 'S5'
                        select @v_adjust_amt=sum(amount) from ad_outstand
                        where comp_code           =@v1_comp_code and
                                    doctype       =@v1_doctype and 
                                    ag_main_code  =@v1_ag_main_code and 
                                    ag_sub_code   =@v1_ag_sub_code and 
                                    recptno       =@v1_recptno and 
                                    recptdt       =@v1_recptdt and 
                                    billno is not null;

                                    PRINT 'S6'
print @v_rcpamt
print @v_adjust_amt
                        select @dsign=Dsign from fa_docmst where Comp_code=@v1_comp_code and doc_type=@v1_doctype;

                            set @v_rem_amt    =isnull(@v_rcpamt,0)-isnull(@v_adjust_amt,0);
                            if isnull(@v_adjust_amt,0)+isnull(@v_rem_amt,0)=isnull(@v_rcpamt,0) and isnull(@v_rcpamt,0)<>0 begin
                    
                                if isnull(@v_cnt1,0)=0 and isnull(@v_cnt2,0)=0 begin---for billno not adjust 
                                    set @vdummy         = @dsign * (cast(isnull(@v2_amount,0) as numeric(15,2)));
                                    if abs(@v_rem_amt)<abs(@vdummy) begin
                                        set @vdummy        =@v_rem_amt;
                                        set @v_rem_amt    =isnull(@v_rcpamt,0)-isnull(@v_adjust_amt,0)-isnull(@vdummy,0);
                                    end
                                    else
                                    begin
                                        set @v_rem_amt    =isnull(@v_rcpamt,0)-isnull(@v_adjust_amt,0)-isnull(@vdummy,0);
                                    end
                                    PRINT 'W2-1'
                                    PRINT @v1_recptdt
                                    if isnull(@v_rem_amt,0)>0
                                       Begin
                                          set @v_rem_amt = 0 
                                       End
                                    update ad_outstand set amount=@v_rem_amt/*isnull(amount,0)-isnull(vdummy,0)*/,pripub=@v12_pripub
                                        where   comp_code      =@v1_comp_code and
                                                unit           =@v1_unit and 
                                                ag_main_code   =@v1_ag_main_code and 
                                                ag_sub_code    =@v1_ag_sub_code and 
                                                doctype        =@v1_doctype and 
                                                recptno        =@v1_recptno and 
                                                recptdt        =@v1_recptdt and 
                                                billno is null;
            print 'w2'
                                    insert into ad_outstand
                                        (unit,agcode,doctype,bkfor,recptno,recptdt,ag_main_code,ag_sub_code,bk_agcode,bk_agsubcode,amount,receipt_no,chno,chdt,bank,reason,voucherno,voucherdate,
                                        comp_code,received_region,retainer_code,exec_code,billno,billdt,pripub,userid,ad_type,priproctg) 
                                    values (@v1_unit,@v1_ag_main_code+@v1_ag_sub_code,@v1_doctype,@v12_bkfor,@v1_recptno,@v1_recptdt,@v1_ag_main_code,@v1_ag_sub_code,@v1_bk_agcode,@v1_bk_agsubcode,@vdummy,@v1_receipt_no,@v1_chno,@v1_chdt,@v1_bank,@v1_reason,@v1_voucherno,@v1_voucherdate,
                                        @v1_comp_code,@v1_received_region,@v12_retainer_code,@v12_exec_code,@v2_billno,@v2_billdt,@v12_pripub,@puserid,@v12_ad_type,@v12_priproctg);
                        print 'w1'
                                    insert into ad_rcptdet (unit,agcode,doctype,bkfor,recptno,
                                                            recptdt,ag_main_code,ag_sub_code,bk_agcode,bk_agsubcode,
                                                            amount,reason,voucherno,comp_code,received_region,
                                                            billno,billdt,pripub,voucherdate,userid,
                                                            username,userdate)
                                                    values (@v1_unit,@v1_ag_main_code+@v1_ag_sub_code,@v1_doctype,@v12_bkfor,@v1_recptno,
                                                            @v1_recptdt,@v1_ag_main_code,@v1_ag_sub_code,@v1_bk_agcode,@v1_bk_agsubcode,
                                                            @vdummy,@v1_reason,@v1_voucherno,@v1_comp_code,@v1_received_region,
                                                            @v2_billno,@v2_billdt,@v12_pripub,@v1_voucherdate,@puserid,
                                                            @puserid,getdate());
                                end        
            
                            end
                    end
                    set @v2_billno=null
                    set @v2_billdt=null 
                    set @v2_amount=0
                    set @vdummy=0
                    set @v_rem_amt=0
                    set @v_cnt1=0
                    set @v_cnt2=0
                    set @v_cnt3=0
                    set @v_cnt4=0
                    set @v_adjust_amt=0
                    set @v_rcpamt =0;

            fetch NEXT FROM c12 INTO @v12_billno, @v12_billdt, @v12_pripub, @v12_bkfor, @v12_retainer_code,
                                     @v12_exec_code,@v12_rec_amount
            end
        close c12;
        deallocate c12


        fetch NEXT FROM c1 INTO @v1_unit, @v1_doctype, @v1_bkfor, @v1_recptno, @v1_recptdt, 
                                @v1_ag_main_code, @v1_ag_sub_code, @v1_bk_agcode, @v1_bk_agsubcode, @v1_receipt_no, 
                                @v1_chno, @v1_chdt, @v1_bank, @v1_reason, @v1_voucherno, 
                                @v1_voucherdate, @v1_comp_code, @v1_received_region, @v1_retainer_code, @v1_exec_code
        end
close c1;
deallocate c1

/////////////////////////////////////////////////



ALTER procedure [dbo].[CHECKBOOKINGCREDITLIMIT]
(
@compcode as varchar(100),
@agcode as varchar(100),
@outstandamt as varchar(100),
@billamt as varchar(100),
@datecheck as varchar(100),
@extra2 as varchar(100),
@extra3 as varchar(100),
@extra4 as varchar(100),
@extra5 as varchar(100))
 as
declare @preferrenceflag VARCHAR(1)
declare @creditlimit float
declare @finaloutstand float
declare @dboutstand float
declare @V_USED_CREDIT_LIMIT_PER NUMERIC(15,2)
declare @V_PREF_CREDIT_LIMIT_PER NUMERIC(15,2)
declare @V_UBBILLED_BOOKING_AMT NUMERIC(15,2)
declare @V_USED_AMT NUMERIC(15,2)
 
begin
set @finaloutstand=0
select @preferrenceflag=CHECKBOOKINGCREDITLIMIT, @V_PREF_CREDIT_LIMIT_PER =isnull(CREDIT_LIMIT_PRECENTAGE_ALERT,0) from preferrences where comp_code=@compcode

select @dboutstand=dbo.adagency_outstanding(@compcode,'','',@agcode,@datecheck,'mm/dd/yyyy')

SELECT @V_UBBILLED_BOOKING_AMT = SUM(BILL_AMT) FROM TBL_BOOKING_INSERT WHERE Insert_status NOT IN ('CANCEL','BILLED') /*AND INSERT_DATE <=@datecheck*/
AND cio_booking_id IN (SELECT cio_booking_id FROM TBL_BOOKING_MAST WHERE Comp_code = @compcode AND Agency_sub_code = @agcode)

select @creditlimit=CREDIT_LIMIT from agency_mast where Comp_Code=@compcode and code_subcode=@agcode
print 'gg'

//////////////////////////////////////


ALTER PROCEDURE [dbo].[pub_Reportnew](
@agname			as VARCHAR(50)= NULL,
@Adtype			as VARCHAR(50)= NULL,
@fromdate		as VARCHAR(20)= NULL,
@dateto			as VARCHAR(20)= NULL,
@compcode		as VARCHAR(10)= NULL,
@pub_cent		as VARCHAR(50)= NULL,
@category		as VARCHAR(50)= NULL,
@edition		as VARCHAR(50)= NULL,
@dateformat		as VARCHAR(20)= NULL,
@Region			as VARCHAR(50)= NULL,
@product		as VARCHAR(50)= NULL,
@agency			as VARCHAR(50)= NULL,
@descid			as VARCHAR(10)= NULL,
@ascdesc		as VARCHAR(10)= NULL,
@agcat			as VARCHAR(50)=null,
@adcheck		as VARCHAR(10)=null,
@executive		as VARCHAR(50)=null,
@puserid		as VARCHAR(10)=null,
@chk_access		as VARCHAR(2),
@pstatecode     as VARCHAR(100)= NULL,
@pdistcode      as VARCHAR(100)= NULL,
@pinsertstatus  as VARCHAR(100)= NULL)

as
declare @query1	VARCHAR(8000)
declare @grpnew VARCHAR(100)
declare @grpne	VARCHAR(100)
declare @grpst	VARCHAR(100)
declare @prefer as VARCHAR(10)
BEGIN
select distinct @prefer= AGENCY_RETAINER_COMM from preferrences where comp_code=@compcode


if(@adcheck=1) begin

set @query1='SELECT distinct m.cio_booking_id AS "CIOID",
a.Agency_Name AS "Agency",
isnull((SELECT Cust_Name FROM CUST_MAST WHERE CUST_MAST.comp_code=m.comp_code and Cust_Code=m.Client_code),m.Client_code)  AS "Client",
p.Pub_Name AS "Publication",
round(m.Total_area,2) AS "Area",
(SELECT BRANCH_MST.Branch_Name FROM BRANCH_MST WHERE BRANCH_MST.comp_code=m.comp_code and m.Revenue_center =BRANCH_MST.Branch_Code )AS "RevenueCenter",
m.Rate_code as "Rate",