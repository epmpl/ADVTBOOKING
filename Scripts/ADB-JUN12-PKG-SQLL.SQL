
===start======avinash====by mimoh=====04jun2012==============================================
ALTER PROCEDURE bindaudit
--@code			as varchar(10),
@fromdate		as varchar(10),
@todate			as varchar(10),
@date			as varchar(15),
@branch1		as varchar(50),
@adtype			as varchar(50),
@audittype		as VARCHAR(50),
@branch2		as VARCHAR(50),
@v_Cat			as varchar(50),
@comp_code		as varchar(50),
@package_code   as varchar(100),
@pagency_code   as varchar(100),
@pclient_code   as varchar(100),
@psection_code  as varchar(100),
@p_booktype     as varchar(100),--A for all ,D for Direct ,Q for Qbc Booking
@extra1         as varchar(100),--for UOM
@extra2         as varchar(100),--for Date based on ,B for Booking Date,P for Publish date
@extra3         as varchar(100),
@extra4         as varchar(100)
AS

declare @v_approval_req		as varchar(1)
declare @query				as varchar(8000)

set @v_approval_req='N'

select @v_approval_req=relauthreqon from preferrences where "comp_code"=@comp_code
    
IF (@audittype = 'audit') begin
    IF(@branch1='All') begin
        set @query  ='SELECT distinct m.cio_booking_id cio_booking_id,
        isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,m."Receipt_no" as "Receipt_no",
        (select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name <> null ) as FILENAME,
        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m. Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
        case when  '''+@v_approval_req+'''=''N'' then ''Y'' else
            case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
        end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),min(i."Insert_Date"),102) END AS "INSERT_DATE",
        m."Insertion_date" dd 
        FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i 
        WHERE m.cio_booking_id=i.cio_booking_id AND m.Ad_type_code='''+@Adtype+''' AND m.audit <>''' 
    end
    ELSE begin
        set @query  ='SELECT distinct m.cio_booking_id cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code)
        as Client_code,m.audit audit,m.Ad_type_code Ad_type_code,
		m."Receipt_no" as "Receipt_no",
		(select top 1  File_Name from tbl_booking_insert
        where Cio_Booking_Id=m.cio_booking_id and File_Name <> null ) as FILENAME,
        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
		case when  '''+@v_approval_req+'''=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),min(i."Insert_Date"),102) END AS "INSERT_DATE",
        m."Insertion_date" dd		
        FROM TBL_BOOKING_MAST m,tbl_booking_insert i 
        WHERE m.cio_booking_id=i.cio_booking_id AND m.Ad_type_code='''+@Adtype+''' AND 
        m.branch IN (SELECT Branch_CODE FROM BRANCH_MST
        WHERE pub_center=(SELECT top 1 Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+'''))
        AND  m.audit <> '''''
     END
END
IF (@audittype = 'unaudit') begin
    IF(@branch1='All')begin
                     
        set @query  =' SELECT  distinct m.cio_booking_id cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,
		m."Receipt_no" as "Receipt_no",
        (select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name <> null) as FILENAME,

        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
		case when  '''+@v_approval_req+'''=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),min(i."Insert_Date"),102) END AS "INSERT_DATE",
        m."Insertion_date" dd
        FROM TBL_BOOKING_MAST m,tbl_booking_insert i 
        WHERE  m.cio_booking_id=i.cio_booking_id AND m.Ad_type_code='''+@Adtype+''' AND audit = ''''
        and isnull(m.modified_audit,''N'')!=''Y'''
    end         
    ELSE begin
        set @query  =' SELECT distinct m.cio_booking_id cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,
		m."Receipt_no" as "Receipt_no",
        (select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name <> null ) as FILENAME ,

        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
        case when  '''+@v_approval_req+'''=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),min(i."Insert_Date"),102) END AS "INSERT_DATE",
        m."Insertion_date" dd
        FROM TBL_BOOKING_MAST m,tbl_booking_insert i 
        WHERE m.cio_booking_id=i.cio_booking_id AND m.Ad_type_code='''+@Adtype+''' AND
        branch IN(SELECT Branch_CODE FROM BRANCH_MST WHERE pub_center=(SELECT  top 1 Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+''' ))
        AND m.audit = '''' and isnull(m.modified_audit,''N'')!=''Y'''
    END
END

IF (@audittype = 'modified') begin
    IF(@branch1='All')begin

        set @query  ='SELECT distinct m.cio_booking_id cio_booking_id,
        isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,

		m."Receipt_no" as "Receipt_no",
		(select top 1 File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name <> null ) as FILENAME,
        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
		case when  '''+@v_approval_req+'''=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),min(i."Insert_Date"),102) END AS "INSERT_DATE",
        m."Insertion_date" dd        
        FROM TBL_BOOKING_MAST m,tbl_booking_insert i WHERE m.cio_booking_id=i.cio_booking_id AND
        m.Ad_type_code='''+@Adtype+''' and isnull(m.modified_audit,''N'')!=''Y'''
    end        
    ELSE begin

        set @query  ='SELECT distinct m.cio_booking_id,
        isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,m."Receipt_no" as "Receipt_no",

		(select top 1 File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name is not null
        ) as FILENAME,
        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT ,
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
		case when  '''+@v_approval_req+'''=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),min(i."Insert_Date"),102) END AS "INSERT_DATE",
        m."Insertion_date" dd        
        FROM TBL_BOOKING_MAST m,tbl_booking_insert i WHERE m.cio_booking_id=i.cio_booking_id AND
        m.branch IN(SELECT Branch_CODE FROM BRANCH_MST WHERE pub_center=(SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+''')) AND
        m.Ad_type_code='''+@Adtype+''' and isnull(m.modified_audit,''N'')!=''Y'''
    END
END

If @extra2='P' begin
	set @query= @query+' AND m.date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''''
end
else begin
	set @query= @query+' AND m.insert_date BETWEEN '''+@fromdate+''' AND '''+@todate+''''
end	

if(@package_code <> null or @package_code <> '') begin
    set @query= @query+' and i.package_code in ('''+@package_code+''') '
end

if(@pagency_code <> null or @pagency_code <> '') begin
    set @query= @query+' and m.Agency_sub_code in ('''+@pagency_code+''') '
end

if(@pclient_code <> null or @pclient_code <> '') begin
    set @query= @query+' and m.Client_code in ('''+@pclient_code+''') '
end

if(@psection_code <> null or @psection_code <> '') begin
    set @query= @query+' and i.SECTIONCODE in ('''+@psection_code+''') '
end

if(@branch2 <> null or @branch2 <> '') begin
    set @query= @query+' and m.branch='''+@branch2+''' '
end

if(@v_Cat <> null or @v_Cat <> '') begin
    set @query=@query+' and m.Ad_cat_code='''+@v_Cat+''' '
end

if(@extra1 <> null or @extra1 <> '') begin
    set @query=@query+' and m."Uom_code"='''+@extra1+''' '
end

set @query=@query+' group by m."cio_booking_id" ,m."Client_code",m."audit", m."Ad_type_code",m."Receipt_no",
        m."Creation_datetime",m.ATTACHMENT1,nvl(m."Discount_per",0),nvl(m."Special_disc_per",0),m.app_status 
        order by dd,"cio_booking_id"';

print(@query)
exec(@query)

=========avinash====by mimoh=====04jun2012==============================================




///////////start   ////////mimoh sir///////////////////////



ALTER procedure emp_code_bind 
    @pcomp_code	as	varchar(20),
    @pname      as	varchar(20),
    @pextra1    as	varchar(200),
    @pextra2    as	varchar(200),
    @pextra3    as	varchar(200),
    @pextra4    as	varchar(200)
as
begin
    select emp_code as "EMP_CODE",name as "NAME",addr1 as "ADDR1",addr2 as "ADDR2",addr3 as "ADDR3",pin as "PIN",
    father_name as "FATHER_NAME",last_name as "LAST_NAME",
    (select dept from hr_dept_mast where dept_code=hr_emp_mst.deptcode) "DEPT_NAME",email as "EMAIL",
    phone as "PHONE",mobile as "MOBILE",bran_code as "BRAN_CODE",
    (select "Branch_Name" from branch_mst where "Branch_Code"=hr_emp_mst.bran_code) as "BRANCH_NAME"
    from hr_emp_mst where comp_cd=@pcomp_code 
    and ( upper(name) like upper(@pname)+'%' or @pname is null or @pname='') order by "NAME";
         
    select 'a' as "A"
         
    select 'a'  as "A" 

    select 'a' as "A"
     
end












create procedure cir_rep_datewise_po_summ
     @pcomp_code     as varchar(20),
     @punit_code     as varchar(20),
     @ppubl          as varchar(20),
     @pfromdate      as datetime,
     @ptilldate      as datetime,
     @pdateformat    as varchar(20),
     @preptype       as varchar(20),--1 for supply type wise 2 for edition wise
     @pextra1        as varchar(20),
     @pextra2        as varchar(20),
     @pextra3        as varchar(20),
     @pextra4        as varchar(20),
     @pextra5        as varchar(20) as
begin

    create table #cir_temp_bill_collection
    (comp_code		varchar(200),
     unit_code		varchar(200), 
     billdt			datetime, 
     publ_code		varchar(200),
     supply_copy	int,
     gross_amt		numeric(15,4), 
	 agname			varchar(200))

    declare cur_dbk cursor for
            select distinct x.comp_code comp_code,x.unit_code unit_code,x.supdate supdate,x.publ_name publ_name,
            x.sup_ty_name sup_ty_name,x.sup_seqno sup_seqno,x.supply_copy supply_copy 
            from
            (select d.comp_code comp_code,d.unit_code unit_code,d.supdate supdate,p.publ_name publ_name,
            t.sup_ty_name sup_ty_name,t.sup_seq_no sup_seqno, sum(d.sup_copy) supply_copy
            from cir_dbksup d,cir_edtn_mast e,cir_publ_mast p,cir_supply_type_mast t
            where d.comp_code=e.comp_code and d.comp_code=p.comp_code 
            and d.comp_code=t.comp_code and d.comp_code=@pcomp_code and
            d.unit_code=e.unit_code and d.unit_code=isnull(@punit_code,d.unit_code) and d.publ=p.publ 
            and d.publ=e.publ and d.publ=isnull(@ppubl,d.publ) and 
            d.edtn=e.edtn and d.supdate >= @pfromdate and d.supdate <=@ptilldate and d.sup_type_code=t.sup_ty_code and 
            isnull(@preptype,'1')='1'
            group by d.comp_code,d.unit_code,d.supdate,p.publ_name,t.sup_ty_name,t.sup_seq_no
            union
            select d.comp_code comp_code,d.unit_code unit_code,d.supdate supdate,p.publ_name publ_name,
            e.edtn sup_ty_name,e.edtn_seq_no sup_seqno, sum(d.sup_copy) supply_copy
            from cir_dbksup d,cir_edtn_mast e,cir_publ_mast p,cir_supply_type_mast t
            where d.comp_code=e.comp_code and d.comp_code=p.comp_code 
            and d.comp_code=t.comp_code and d.comp_code=@pcomp_code and
            d.unit_code=e.unit_code and d.unit_code=isnull(@punit_code,d.unit_code) and d.publ=p.publ 
            and d.publ=e.publ and d.publ=isnull(@ppubl,d.publ) and 
            d.edtn=e.edtn and d.supdate >= @pfromdate and d.supdate <=@ptilldate and d.sup_type_code=t.sup_ty_code and
            isnull(@preptype,'1')='2' 
            group by d.comp_code,d.unit_code,d.supdate,p.publ_name,e.edtn,e.edtn_seq_no)x;

declare @rec_dbk_comp_code		varchar(100)
declare @rec_dbk_unit_code		varchar(100)
declare @rec_dbk_supdate		datetime
declare @rec_dbk_publ_name		varchar(100)
declare @rec_dbk_sup_ty_name	varchar(100)
declare @rec_dbk_sup_seqno		int
declare @rec_dbk_supply_copy	int

     declare cur_sup_type cursor for
        select distinct gross_amt sup_seq_no,agname supply_type_name 
        from #cir_temp_bill_collection
        order by gross_amt,agname;

declare @rec_sup_type_sup_seq_no		int
declare @rec_sup_type_supply_type_name  varchar(100)    
declare @vvar        varchar(4000)
declare @vvar_sum    varchar(4000)
declare @vquery      varchar(8000)
declare @v_count     int
	 
    open cur_dbk
        fetch NEXT FROM cur_dbk into @rec_dbk_comp_code,@rec_dbk_unit_code,@rec_dbk_supdate,@rec_dbk_publ_name,
			@rec_dbk_sup_ty_name,@rec_dbk_sup_seqno,@rec_dbk_supply_copy
	WHILE (@@FETCH_STATUS = 0) BEGIN
        insert into #cir_temp_bill_collection
        (comp_code, unit_code, billdt, publ_code, supply_copy, gross_amt, 
		agname)
        values(@rec_dbk_comp_code,@rec_dbk_unit_code,@rec_dbk_supdate,@rec_dbk_publ_name,@rec_dbk_supply_copy,NULL,
        @rec_dbk_sup_ty_name)
        
        fetch NEXT FROM cur_dbk into @rec_dbk_comp_code,@rec_dbk_unit_code,@rec_dbk_supdate,@rec_dbk_publ_name,
			@rec_dbk_sup_ty_name,@rec_dbk_sup_seqno,@rec_dbk_supply_copy
    end
    close cur_dbk;
		
    open cur_sup_type;
        fetch next from cur_sup_type into @rec_sup_type_sup_seq_no,@rec_sup_type_supply_type_name
		WHILE (@@FETCH_STATUS = 0) BEGIN
        if @vvar is null or @vvar ='' begin
            set @vvar       ='case when d.agname='+''''+@rec_sup_type_supply_type_name+''''+' then d.supply_copy else 0 end "'+@rec_sup_type_supply_type_name+'"'
            set @vvar_sum   ='sum("'+@rec_sup_type_supply_type_name+'")'+' "'+@rec_sup_type_supply_type_name+'"'
        end
        else Begin
            set @vvar       =@vvar+','+'case when d.agname='+''''+@rec_sup_type_supply_type_name+''''+' then d.supply_copy else 0 end "'+@rec_sup_type_supply_type_name+'"'
            set @vvar_sum   =@vvar_sum+','+'sum("'+@rec_sup_type_supply_type_name+'")'+' "'+@rec_sup_type_supply_type_name+'"'
        end
        fetch next from cur_sup_type into @rec_sup_type_sup_seq_no,@rec_sup_type_supply_type_name
    end
    close cur_sup_type;
    print(@vvar)
	deallocate cur_sup_type
	
	deallocate cur_dbk
    if @vvar is null or @vvar ='' begin
        set @vquery=' select x.comp_code comp_code,x.unit_code unit_code,x.publ publ,x.publ_name publ_name,
                x.supdate supdate, sum(x.supply_copy) TOTAL from
                (select d.comp_code comp_code,d.unit_code unit_code,d.publ_code publ,d.publ_code publ_name,
                case '''+@pdateformat+'''
				when ''mm/dd/yyyy'' then convert(varchar(20),d.billdt,101)
				when ''dd/mm/yyyy'' then convert(varchar(20),d.billdt,103)
				when ''yyyy/mm/dd'' then convert(varchar(20),d.billdt,111) end as supdate,
                d.supply_copy supply_copy 
                from #cir_temp_bill_collection d
                where d.cur_sessionid=userenv(''sessionid'')) x  group by x.comp_code,x.unit_code,x.publ,x.publ_name,x.supdate
                order by comp_code,unit_code,supdate,publ_name';
    end
    else begin
        set @vquery=' select x.comp_code comp_code,x.unit_code unit_code,x.publ publ,x.publ_name publ_name,
                x.supdate supdate,'+@vvar_sum+', sum(x.supply_copy) TOTAL
                from
                (select d.comp_code comp_code,d.unit_code unit_code,d.publ_code publ,d.publ_code publ_name,
                case '''+@pdateformat+'''
				when ''mm/dd/yyyy'' then convert(varchar(20),d.billdt,101)
				when ''dd/mm/yyyy'' then convert(varchar(20),d.billdt,103)
				when ''yyyy/mm/dd'' then convert(varchar(20),d.billdt,111) end as supdate,
				'+@vvar+',d.supply_copy supply_copy
                from #cir_temp_bill_collection d) x  group by x.comp_code,x.unit_code,x.publ,x.publ_name,x.supdate
                order by comp_code,unit_code,supdate,publ_name';
    end               

    print(@vquery)
    exec(@vquery)
    
    if @vvar is null or @vvar ='' begin
        set @vquery=' select x.comp_code comp_code,x.unit_code unit_code,x.publ publ,x.publ_name publ_name,sum(x.supply_copy) TOTAL from
                (select d.comp_code comp_code,d.unit_code unit_code,d.publ_code publ,d.publ_code publ_name,
                case '''+@pdateformat+'''
				when ''mm/dd/yyyy'' then convert(varchar(20),d.billdt,101)
				when ''dd/mm/yyyy'' then convert(varchar(20),d.billdt,103)
				when ''yyyy/mm/dd'' then convert(varchar(20),d.billdt,111) end as supdate,
                d.supply_copy supply_copy from #cir_temp_bill_collection d) x group by x.comp_code,x.unit_code,x.publ,x.publ_name
                order by comp_code,unit_code,publ_name';                
    end
    else begin
        set @vquery=' select x.comp_code comp_code,x.unit_code unit_code,x.publ publ,x.publ_name publ_name,
                '+@vvar_sum+', sum(x.supply_copy) TOTAL from
                (select d.comp_code comp_code,d.unit_code unit_code,d.publ_code publ,d.publ_code publ_name,
                case '''+@pdateformat+'''
				when ''mm/dd/yyyy'' then convert(varchar(20),d.billdt,101)
				when ''dd/mm/yyyy'' then convert(varchar(20),d.billdt,103)
				when ''yyyy/mm/dd'' then convert(varchar(20),d.billdt,111) end as supdate,
				'+@vvar+',d.supply_copy supply_copy from #cir_temp_bill_collection d) x 
                group by x.comp_code,x.unit_code,x.publ,x.publ_name
                order by comp_code,unit_code,publ_name';    
    end
    
    print(@vquery)
    exec(@vquery)
    
    drop table #cir_temp_bill_collection
End








/////////end ///////shipra///////////by mimoh sir/////////



====start=======avinash===mimoh=======================================
ALTER PROCEDURE bindaudit
--@code			as varchar(10),
@fromdate		as varchar(10),
@todate			as varchar(10),
@date			as varchar(15),
@branch1		as varchar(50),
@adtype			as varchar(50),
@audittype		as VARCHAR(50),
@branch2		as VARCHAR(50),
@v_Cat			as varchar(50),
@comp_code		as varchar(50),
@package_code   as varchar(100),
@pagency_code   as varchar(100),
@pclient_code   as varchar(100),
@psection_code  as varchar(100),
@p_booktype     as varchar(100),--A for all ,D for Direct ,Q for Qbc Booking
@extra1         as varchar(100),--for UOM
@extra2         as varchar(100),--for Date based on ,B for Booking Date,P for Publish date
@extra3         as varchar(100),
@extra4         as varchar(100)
AS

declare @v_approval_req		as varchar(1)
declare @query				as varchar(8000)

set @v_approval_req='N'

select @v_approval_req=relauthreqon from preferrences where "comp_code"=@comp_code
    
IF (@audittype = 'audit') begin
    IF(@branch1='All') begin
        set @query  ='SELECT distinct m.cio_booking_id cio_booking_id,
        isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,m."Receipt_no" as "Receipt_no",
        (select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name <> null ) as FILENAME,
        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m. Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
        case when  '''+@v_approval_req+'''=''N'' then ''Y'' else
            case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
        end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),min(i."Insert_Date"),102) END AS "INSERT_DATE",
        m."Insertion_date" dd 
        FROM TBL_BOOKING_MAST m,TBL_BOOKING_INSERT i 
        WHERE m.cio_booking_id=i.cio_booking_id AND m.Ad_type_code='''+@Adtype+''' AND m.audit <>''' 
    end
    ELSE begin
        set @query  ='SELECT distinct m.cio_booking_id cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code)
        as Client_code,m.audit audit,m.Ad_type_code Ad_type_code,
		m."Receipt_no" as "Receipt_no",
		(select top 1  File_Name from tbl_booking_insert
        where Cio_Booking_Id=m.cio_booking_id and File_Name <> null ) as FILENAME,
        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
		case when  '''+@v_approval_req+'''=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),min(i."Insert_Date"),102) END AS "INSERT_DATE",
        m."Insertion_date" dd		
        FROM TBL_BOOKING_MAST m,tbl_booking_insert i 
        WHERE m.cio_booking_id=i.cio_booking_id AND m.Ad_type_code='''+@Adtype+''' AND 
        m.branch IN (SELECT Branch_CODE FROM BRANCH_MST
        WHERE pub_center=(SELECT top 1 Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+'''))
        AND  m.audit <> '''''
     END
END
IF (@audittype = 'unaudit') begin
    IF(@branch1='All')begin
                     
        set @query  =' SELECT  distinct m.cio_booking_id cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,
		m."Receipt_no" as "Receipt_no",
        (select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name <> null) as FILENAME,

        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
		case when  '''+@v_approval_req+'''=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),min(i."Insert_Date"),102) END AS "INSERT_DATE",
        m."Insertion_date" dd
        FROM TBL_BOOKING_MAST m,tbl_booking_insert i 
        WHERE  m.cio_booking_id=i.cio_booking_id AND m.Ad_type_code='''+@Adtype+''' AND audit = ''''
        and isnull(m.modified_audit,''N'')!=''Y'''
    end         
    ELSE begin
        set @query  =' SELECT distinct m.cio_booking_id cio_booking_id,isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,
		m."Receipt_no" as "Receipt_no",
        (select top 1  File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name <> null ) as FILENAME ,

        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
        case when  '''+@v_approval_req+'''=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),min(i."Insert_Date"),102) END AS "INSERT_DATE",
        m."Insertion_date" dd
        FROM TBL_BOOKING_MAST m,tbl_booking_insert i 
        WHERE m.cio_booking_id=i.cio_booking_id AND m.Ad_type_code='''+@Adtype+''' AND
        branch IN(SELECT Branch_CODE FROM BRANCH_MST WHERE pub_center=(SELECT  top 1 Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+''' ))
        AND m.audit = '''' and isnull(m.modified_audit,''N'')!=''Y'''
    END
END

IF (@audittype = 'modified') begin
    IF(@branch1='All')begin

        set @query  ='SELECT distinct m.cio_booking_id cio_booking_id,
        isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,

		m."Receipt_no" as "Receipt_no",
		(select top 1 File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name <> null ) as FILENAME,
        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT,
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
		case when  '''+@v_approval_req+'''=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),min(i."Insert_Date"),102) END AS "INSERT_DATE",
        m."Insertion_date" dd        
        FROM TBL_BOOKING_MAST m,tbl_booking_insert i WHERE m.cio_booking_id=i.cio_booking_id AND
        m.Ad_type_code='''+@Adtype+''' and isnull(m.modified_audit,''N'')!=''Y'''
    end        
    ELSE begin

        set @query  ='SELECT distinct m.cio_booking_id,
        isnull((select Cust_Name from cust_mast where Cust_Code=m.Client_code),m.Client_code) as Client_code,
        m.audit audit,m.Ad_type_code Ad_type_code,m."Receipt_no" as "Receipt_no",

		(select top 1 File_Name from tbl_booking_insert where Cio_Booking_Id=m.cio_booking_id and File_Name is not null
        ) as FILENAME,
        CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),m.Creation_datetime,101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),m.Creation_datetime,103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),m.Creation_datetime,102) END AS "Creation_datetime",
        m.ATTACHMENT1 as ATTACHMENT ,
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''A'') as "Agency_Remark",
        dbo.AD_GETAGENCY_ADD('''+@comp_code+''',m.cio_booking_id,''C'') as "Client_Remark",
		case when  '''+@v_approval_req+'''=''N'' then ''Y'' else
			case when isnull(m."Discount_per",0)+isnull(m."Special_disc_per",0)=0 then ''Y'' else ''N'' end
		end as "APPROVAL_FLAG",
		CASE '''+@date+'''
        WHEN ''mm/dd/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),101)
        WHEN ''dd/mm/yyyy'' THEN convert(varchar(50),min(i."Insert_Date"),103)
        WHEN ''yyyy/mm/dd'' THEN convert(varchar(50),min(i."Insert_Date"),102) END AS "INSERT_DATE",
        m."Insertion_date" dd        
        FROM TBL_BOOKING_MAST m,tbl_booking_insert i WHERE m.cio_booking_id=i.cio_booking_id AND
        m.branch IN(SELECT Branch_CODE FROM BRANCH_MST WHERE pub_center=(SELECT Pub_cent_Code FROM PUB_CENT_MAST WHERE Pub_cent_Code='''+@BRANCH1+''' and comp_code='''+@comp_code+''')) AND
        m.Ad_type_code='''+@Adtype+''' and isnull(m.modified_audit,''N'')!=''Y'''
    END
END

If @extra2='P' begin
	set @query= @query+' AND m.date_time BETWEEN '''+@fromdate+''' AND '''+@todate+''''
end
else begin
	set @query= @query+' AND m.insert_date BETWEEN '''+@fromdate+''' AND '''+@todate+''''
end	

if(@package_code <> null or @package_code <> '') begin
    set @query= @query+' and i.package_code in ('''+@package_code+''') '
end

if(@pagency_code <> null or @pagency_code <> '') begin
    set @query= @query+' and m.Agency_sub_code in ('''+@pagency_code+''') '
end

if(@pclient_code <> null or @pclient_code <> '') begin
    set @query= @query+' and m.Client_code in ('''+@pclient_code+''') '
end

if(@psection_code <> null or @psection_code <> '') begin
    set @query= @query+' and i.SECTIONCODE in ('''+@psection_code+''') '
end

if(@branch2 <> null or @branch2 <> '') begin
    set @query= @query+' and m.branch='''+@branch2+''' '
end

if(@v_Cat <> null or @v_Cat <> '') begin
    set @query=@query+' and m.Ad_cat_code='''+@v_Cat+''' '
end

if(@extra1 <> null or @extra1 <> '') begin
    set @query=@query+' and m."Uom_code"='''+@extra1+''' '
end

set @query=@query+' group by m."cio_booking_id" ,m."Client_code",m."audit", m."Ad_type_code",m."Receipt_no",
        m."Creation_datetime",m.ATTACHMENT1,nvl(m."Discount_per",0),nvl(m."Special_disc_per",0),m.app_status 
        order by dd,"cio_booking_id"';

print(@query)
exec(@query)


====start=======avinash===mimoh=======================================

/////////////////////start issue no:7421(7/6/2012)//////////////////////

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[websp_selectvalues]    Script Date: 06/07/2012 16:21:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[websp_selectvalues]

(@ciobooking	varchar(50), 
@editionname	varchar(50),
@compcode		VARCHAR(50),
@insertion		varchar(50),
@dateformat		varchar(50)

)
as 
declare @str			as varchar(8000)
declare @str1			as varchar(8000)
declare @str3 as varchar(8000)
declare @package_cd		as varchar(8000)
declare @package_result as varchar(8000)
declare @package_cd1	as varchar(8000)
create table #package ( package_name varchar (8000) )

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

isnull((select prod_desc from Product_cat_mast where prod_cat_code=tbl_booking_mast.Product_code),''--'') as product,

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
(select top 1 Uom_Name from uom_mast where uom_code=tbl_booking_mast.uom_code) as uom_name,
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
PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))) AS CITY_NAMEnew,
tbl_booking_mast.RETAINER,

dbo.AD_GET_EXECNAME('''+@compcode+''',tbl_booking_mast.Executive_code)

as Executive_code,
(select ADV_SUBCAT_MAST.Adv_Subcat_Name from ADV_SUBCAT_MAST where ADV_SUBCAT_MAST.Adv_Subcat_Code=TBL_BOOKING_MAST.ad_sub_cat_code) as "AdSubCat",

0 as "vat_rate",

dbo.get_printing_cent_street_fr_bran('''+@compcode+''',tbl_booking_mast.branch)as street_login,



(SELECT DISTINCT PACKAGE_NAME FROM COMBIN_MAST WHERE COMBIN_MAST.COMBIN_CODE=TBL_BOOKING_MAST.PACKAGE_CODE) AS "PACK_NAME",

tbl_booking_mast.bill_remarks as Bill_remarks

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
 and TBL_BOOKING_MAST.agency_sub_code=AGENCY_MAST.code_subcode 

and comp_mst.comp_code='''+@compcode+''' 
 and tbl_booking_insert.Col_code=col_mast.Col_code   and pub_mast.pub_code=tbl_booking_insert.publication_code 
  and edition_mast.edition_code=tbl_booking_insert.edition_code and city_mst.city_code=agency_mast.city_code  and TBL_BOOKING_INSERT.publication_code = PUB_MAST.pub_code and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' and   tbl_booking_insert.no_insert='''+@insertion+''' and  tbl_booking_insert.edition='''+@editionname+''' '



print('d')
--set @str3=' and tbl_booking_insert.insert_date='''+convert (varchar(10),@pubdate,101)+''''
select  @package_cd1=package_code from tbl_booking_mast where cio_booking_id=@ciobooking




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

exec(@str+@str1+@str3)


select * from #package
delete from #package

select distinct edition_code from tbl_booking_insert where  cio_booking_id=@ciobooking and Insert_status not in ('Hold','cancel')

-- select top 1 insert_date from tbl_booking_insert where  cio_booking_id=@ciobooking order by insert_date
select top 1 DateName( Month,insert_date )+'-'+ DateName( Year, insert_date ) as "insert_date" from tbl_booking_insert where  cio_booking_id=@ciobooking and tbl_booking_insert.no_insert=@insertion order by insert_date



select distinct 


case @dateformat 
when 'mm/dd/yyyy' then convert(varchar(10),bill_date,101) 
when 'dd/mm/yyyy' then convert(varchar(10),bill_date,103) 
when 'yyyy/mm/dd' then convert(varchar(10),bill_date,3)  end 




 as "bill_dt"  from tbl_booking_insert where cio_booking_id=@ciobooking


select scheme_code as "bill_dt"  from Scheme_Master where comp_code=@compcode and Scheme_id=@v_scheme_code


/* changes by GAurav for vision

select distinct edition_code from tbl_booking_insert where  cio_booking_id=@ciobooking

select top 1 insert_date from tbl_booking_insert where  cio_booking_id=@ciobooking 

select convert(varchar(25),dbo.UD_GET_MAXINSDT(@ciobooking,@insertion),3) as "bill_dt"

*/

/////////////////////end issue no:7421/////////////////////////////


=========start===avinash===========by lata mam==============================07june2012=================================


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go






ALTER PROCEDURE [dbo].[insertintobooking]

@approvedby as varchar(25),
@audit as varchar(25),
@rono as varchar(20),
@rodate as datetime,
@caption as varchar(500),
@billstatus as varchar(8),
@rostatus as varchar(8),
@agency as varchar(8),
@client as varchar(100),
@agencyaddress as varchar(500),
@clientaddresses as varchar(500),
@agencycode as varchar(50),
@dockitno as varchar(25),
@execname as varchar(8),
@execzone as varchar(8),
@product as varchar(8),
@brand as varchar(8),
@keyno as varchar(50),
@billremark as varchar(500),
@printremark as varchar(500),
@package as varchar(500),
@insertion as int,
@startdate as datetime,
@repeatdate as varchar(8),
@adtype as varchar(8),
@adcategory as varchar(8),
@subcategory as varchar(8),
@color as varchar(8),
@uom as varchar(8),
@pageposition as varchar(8),
@pagetype as varchar(100),
@pageno as int,
@adsizheight as float,
@adsizwidth as float,
@ratecode as varchar(8),
@scheme as varchar(500),
@currency as varchar(8),
@agreedrate as float,
@agreedamt as float,
@spedisc as float,
@spacedisx as float,
@compcode as varchar(8),
@userid as varchar(8),
@ciobookid as varchar(50),
@date_time as datetime,
@branch as varchar(25),
@booked_by as varchar(25),
@prevbook as varchar(25),
@adsizetype as varchar(8),
@specialcharges as float,
--, , , , , , , , , , , , , , , , , , , 
@agencytype as varchar(25),
@agencystatus as varchar(25),
@paymode as varchar(25),
@agencredit as int,
@cardrate as float,
@cardamount as float,
@discount as float,
@discountper as float,
@billaddress as varchar(500),
@totarea as float,
@billcycle as varchar(8),
@revenuecenter as varchar(8),
@billpay as varchar(8),
@billheight as float,
@billwidth as float,
@billto as varchar(8),
@invoices as int,
@vts as int,
@tradedisc as float,
@agencyout as varchar(50),
@boxcode as varchar(8),
@boxno as varchar(8),
@boxaddress as varchar(500),
@boxagency as varchar(2),
@boxclient as varchar(2),
@bookingtype as varchar(8),
@tfn as varchar(2),
@coupan as varchar(2),
@campaign as varchar(50),
@bill_amt as float,
@pageprem as varchar(8),
@pageamt as float,
@premper as float,
@grossamt as float,
@adsizcolumn as float,
@billarea as float,
@billcolumn as float,
@spacediscper as float,
@specdiscper as float,
@paidins as int,
@deviation as float,
@dealrate as float,
@varient as varchar(8),
@dealtype as varchar(50),
@contractname as varchar(50),
@cardname as varchar(100),
@cardtype as varchar(50),
@cardmonth as varchar(8),
@cardyear as varchar(8),
@cardno as varchar(20),
@receiptno as varchar(50),
@adscat3 as varchar(8),
@adscat4 as varchar(8),
@adscat5 as varchar(8),
@bgcolor as varchar(8),
@bulletcode as varchar(8),
@bulletprm as float,
@material as varchar(8),
@receiptdate as datetime=null,
@prevcioid as varchar(100)=null,
@prevreceipt as varchar(50)=null,
@prev_ga as float=null,
@region as varchar(8)=null,
@varient_name as varchar(8)=null,
@coltype as varchar(8)=null,
@logo_h as varchar(5)=null,
@logo_w as varchar(5)=null,
@logo_col as varchar(8)=null,
@logo_uom as varchar(8)=null,
@retainer1 AS VARCHAR(50),
@addagencyrate AS VARCHAR(50),
@mobileno AS varchar(100),
@addlamt as varchar(50),
@retamt as varchar(50),
@retper as varchar(50),
@cashrecieved as float,
@CIRAGENCY as varchar(100),
@CIRRATE as varchar(50),
@CIREDITION as varchar(50),
@CIRPUBLICATION as varchar(50),
@CIRAGENCYSUBCODE as varchar(50),
@BARTERTYPE AS VARCHAR(50),
@CASHDISCOUNT_V AS FLOAT,
@CASHDISCOUNTPER_V AS VARCHAR(5),
@attach1 AS varchar(50),
@attach2 AS varchar(50),
@drpdiscprem AS VARCHAR(50),
@doctype as varchar(20),
@CHKTRADE AS VARCHAR(1),
@sharepub_p as varchar(4000),
@fmginsert	as varchar(100),
@chkno AS VARCHAR(50),
@chkdate as datetime=null,
@chkamt AS VARCHAR(30),
@chkbankname as varchar(100),
@ourbank	as varchar(50),
@DEALERPANEL_P AS VARCHAR(1),
@DEALERH_P AS FLOAT,
@DEALERW_P AS FLOAT,
@DEALERTYPE_P AS VARCHAR(1),
@multiselect AS VARCHAR(200),
@AGREEDRATE_ACTIVE as int,
@AGREEDAMT_ACTIVE as int,
@grossamtlocal_p as float,
@billamtlocal_p as float,
@chkadon_p as varchar(5),
@refid_p as varchar(50),
@rcpt_currency as varchar(8),
@cur_convrate as varchar(8),
@p_revisedate as datetime,
@clienttype as varchar(5),
@translation as varchar(25),
@translationcharge as float,
@fmgreasons as varchar(50),
@canclecharge as varchar(50),
@transdisc_p as varchar(10),
@pospremdisc_p as varchar(10)
AS

declare @sccode as varchar(50)
declare @bk_audit as varchar(2)
declare @rate_auth as varchar(2)
declare @auditn as varchar(50)
declare @username_v as varchar(50)
declare @roleid_v as varchar(50)
-----BHANU
declare @RELAUTHREQ as varchar(1)
---BHANU
--select @sccode=scheme_id from scheme_master where scheme_name=ltrim(rtrim(@scheme)) and comp_code=@compcode
SET @sccode=@scheme
--, , , , , , , ,CIRAGENCY,CIRRATE,CIREDITION
select @rate_auth=RATE_AUTHORIZATION,@bk_audit=audit,@RELAUTHREQ=RELAUTHREQON from preferrences where comp_code=@compcode
-----------------------------------------------------BHANU @RELAUTHREQ != 'A'-----**************/
select @username_v=username,@roleid_v=roleid from login where userid=@userid
if @roleid_v!='SE0' and  @RELAUTHREQ != 'A'
begin
if @RELAUTHREQ = 'D'
  begin
		if @rate_auth='Y' and @bk_audit='y' and (@agreedamt is null or @agreedamt='' or @agreedamt='0') 
		begin
				
			  set @auditn=@username_v
		end
		else
		begin
			   set @auditn=@audit    
		end
	end 
else
		  set @auditn=@username_v
   
end

else
begin
       set @auditn=@audit    
end
------------------------BHANU CHANGS CONDITION @RELAUTHREQ != 'A'
insert into tbl_booking_mast_g(
date_time ,
branch  ,
booked_by  ,
cio_booking_id  ,
prev_booking  ,
applied_by  ,
audit  ,
RO_No  ,
RO_Date ,
Caption ,
bill_status ,
ro_status  ,
Agency_code  ,
Agency_address ,
Client_code  ,
Client_address ,
Agency_sub_code  ,
Dockit_no  ,
Executive_code  ,
Executive_zone  ,
Product_code  ,
Brand_code  ,
	Key_no  ,
Bill_remarks ,
Print_remark ,
Package_code ,
No_of_insertion ,
Insertion_date ,
Repeating_day  ,
Ad_type_code  ,
Ad_cat_code  ,	
Ad_sub_cat_code ,
Color_code  ,
	Uom_code  ,
Page_position_code  ,
Page_type_code  ,
Page_no ,
Ad_size_type_code  ,
Ad_size_height  ,
Ad_size_width  ,
Rate_code  ,
Scheme_type_code  ,
Currency_code  ,
Agrred_rate  ,	
Agreed_amount  ,
Special_discount  ,
Space_discount  ,
Special_charges  ,
Comp_code ,
Userid,
Agency_status,
Agency_type,
Agency_pay,
Agency_credit,
Total_area,
Card_rate,
Card_amount,
Discount,
Discount_per,
Bill_cycle,
Revenue_center,
Bill_pay,
Bill_height,
Bill_width,
Bill_to,
Invoices,
Vts,
Bill_add,
Trade_disc,
Agency_out,
Box_code,
Box_no,
Box_agency,
Box_client,
Box_address,
Booking_type,
Tfn,
Coupan_ad,
Campaign,
Bill_amount,
Page_prem,
Page_amount,
Prem_per,
Gross_amount,
Ad_size_column,
Bill_column,
Bill_area,
Special_disc_per,
Space_disc_per,
Paid_ins,
Contract_rate,
Deviation,
Variant_code,
Contract_name,
Contract_type,
Card_name,
Card_type,
Card_month,
Card_year,
Card_number,
Receipt_no,
Ad_Subcat3,
Ad_Subcat4,
Ad_subcat5,
Bg_color,
Bullet_code,
Bullet_premium,
Material_status,
Receipt_date,
prev_cioid,
prev_receipt,
prev_grossamt,
Region,
Variant,
Colortype,
Logo_H,
Logo_W,
Logo_color,
Logo_Uom,
Creation_datetime,
RETAINER,
ADD_AGENCY_COMM,
MobileNo,
ADD_AGENCY_COMM_AMT,
RETAINER_COMM,
RETAINER_COMM_AMT,
CASH_RECIEVED,
CIRAGENCY,
CIRRATE,
CIREDITION,
CIRPUBLICATION,
CIRAGENCY_SUBCODE,
BARTER_TYPE,
CASHDISCOUNT,
CASHDISCTYPE,
ATTACHMENT1,
ATTACHMENT2,
DISC_PREMIUM,
DOCTYPE,
CHKTRADEDISC,
CHK_NO,
CHK_DATE,
CHK_AMT,
CHK_BANK_NAME,
OUR_BANK,
DEALERPANEL,
DEALER_H,
DEALER_W,
DEALERTYPE,
ACTIVE_AGREEDRATE,
ACTIVE_AGREEDAMT,
LOCALGROSSAMT,
LOCALBILLAMT,
PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY,CONV_CURR_RATE,
REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,CANCELLATION_CHARGE,TRANSLATION_DISC,POSPREM_DISC
) 
values	 
(@date_time,
@branch,
@booked_by,
@ciobookid,
@prevbook,
@approvedby ,
@auditn ,
@rono ,
@rodate ,
@caption,
@billstatus ,
@rostatus ,
@agency ,
@agencyaddress,
@client ,
@clientaddresses,
@agencycode ,
@dockitno ,
@execname ,
@execzone ,
@product ,
@brand ,
@keyno ,
@billremark,
@printremark,
@package ,
@insertion,
 @startdate ,
@repeatdate ,
@adtype ,
@adcategory ,
@subcategory ,
@color ,
@uom ,
@pageposition ,
@pagetype ,
@pageno,
@adsizetype,
 @adsizheight ,
@adsizwidth ,
@ratecode ,
@sccode ,
@currency ,
@agreedrate ,
@agreedamt ,
@spedisc ,
@spacedisx ,
@specialcharges,
@compcode ,
@userid,
@agencystatus,
@agencytype,
@paymode,
@agencredit,
@totarea,
@cardrate,
@cardamount,
@discount, 
@discountper,
@billcycle, 
@revenuecenter,
@billpay, 
@billheight,
 @billwidth,
@billto, 
@invoices, 
@vts,
@billaddress , 
@tradedisc, 
@agencyout,
@boxcode,
@boxno,
@boxagency,
@boxclient,
@boxaddress,
@bookingtype,
@tfn,
@coupan,
@campaign ,
@bill_amt,
@pageprem,
@pageamt,
@premper,
@grossamt,
@adsizcolumn,
@billcolumn,
@billarea,
@specdiscper,
@spacediscper,
@paidins,
@dealrate,
@deviation,
@varient,
@contractname,
@dealtype,
@cardname,
@cardtype,
@cardmonth,
@cardyear,
@cardno,
@receiptno,
@adscat3,
@adscat4,
@adscat5,
@bgcolor,
@bulletcode,
@bulletprm,
@material,
@receiptdate,
@prevcioid,
@prevreceipt,
@prev_ga,
@region,
@varient_name,
@coltype,
@logo_h,
@logo_w,
@logo_col,
@logo_uom,
GETDATE(),
 @retainer1,
@addagencyrate,
@mobileno,
@addlamt,
@retper,
@retamt,
@cashrecieved,
@CIRAGENCY,
@CIRRATE,
@CIREDITION,
@CIRPUBLICATION,
@CIRAGENCYSUBCODE,
@BARTERTYPE,
@CASHDISCOUNT_V,
@CASHDISCOUNTPER_V,
@attach1,
@attach2,
@drpdiscprem,
@doctype,
@CHKTRADE,
@chkno,
@chkdate,
@chkamt,
@chkbankname,
@ourbank,
@DEALERPANEL_P,
@DEALERH_P,
@DEALERW_P,
@DEALERTYPE_P,
@AGREEDRATE_ACTIVE,
@AGREEDAMT_ACTIVE,
@grossamtlocal_p,
@billamtlocal_p,
@chkadon_p,@refid_p,@rcpt_currency,@cur_convrate,
@p_revisedate,@clienttype,@translation,@translationcharge,@canclecharge,@transdisc_p,@pospremdisc_p
)


IF @sharepub_p is not null and @sharepub_p!=''
begin
	exec insert_sharepub_details @sharepub_p,@ciobookid,'INSERT'
end


if @fmginsert is not null and @fmginsert!=''
begin
	exec insert_fmgTrans_details @fmginsert,@ciobookid,'INSERT',@fmgreasons
end




if @multiselect is not null and @multiselect!=''
begin
	exec insert_multiexec_details @userid,@compcode,@multiselect,@ciobookid,'INSERT'
end


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[updatebooking]

@approvedby as varchar(25),
@audit as varchar(25),
@rono as varchar(20),
@rodate as datetime,
@caption as varchar(500),
@billstatus as varchar(8),
@rostatus as varchar(8),
@agency as varchar(8),
@client as varchar(100),
@agencyaddress as varchar(500),
@clientaddresses as varchar(500),
@agencycode as varchar(18),
@dockitno as varchar(25),
@execname as varchar(8),
@execzone as varchar(8),
@product as varchar(8),
@brand as varchar(8),
@keyno as varchar(50),
@billremark as varchar(500),
@printremark as varchar(500),
@package as varchar(80),
@insertion as int,
@startdate as datetime,
@repeatdate as varchar(8),
@adtype as varchar(8),
@adcategory as varchar(8),
@subcategory as varchar(8),
@color as varchar(8),
@uom as varchar(8),
@pageposition as varchar(8),
@pagetype as varchar(100),
@pageno as int,
@adsizheight as float,
@adsizwidth as float,
@ratecode as varchar(8),
@scheme as varchar(500),
@currency as varchar(8),
@agreedrate as float,
@agreedamt as float,
@spedisc as float,
@spacedisx as float,
@compcode as varchar(8),
@userid as varchar(8),
@ciobookid as varchar(50),
@date_time as datetime,
@branch as varchar(25),
@booked_by as varchar(25),
@prevbook as varchar(25),
@adsizetype as varchar(8),
@specialcharges as float,
@agencytype as varchar(25),
@agencystatus as varchar(25),
@paymode as varchar(25),
@agencredit as int,
@cardrate as float,
@cardamount as float,
@discount as float,
@discountper as float,
@billaddress as varchar(500),
@totarea as float,
@billcycle as varchar(8),
@revenuecenter as varchar(8),
@billpay as varchar(8),
@billheight as float,
@billwidth as float,
@billto as varchar(100),
@invoices as int,
@vts as int,
@tradedisc as float,
@agencyout as varchar(50),
@boxcode as varchar(8),
@boxno as varchar(8),
@boxaddress as varchar(500),
@boxagency as varchar(2),
@boxclient as varchar(2),
@bookingtype as varchar(8),
@tfn as varchar(2),
@coupan as varchar(2),
@campaign as varchar(50),
@bill_amt as float,
@pageprem as varchar(8),
@pageamt as float,
@premper as float,
@grossamt as float,
@adsizcolumn as float,
@billarea as float,
@billcolumn as float,
@spacediscper as float,
@specdiscper as float,
@paidins as int,
@dealrate as float,
@deviation as float,
@varient as varchar(8),
@dealtype as varchar(50),
@contractname as varchar(50),
@cardname as varchar(100),
@cardtype as varchar(50),
@cardmonth as varchar(8),
@cardyear as varchar(8),
@cardno as varchar(20),
@receiptno as varchar(50),
@adscat3 as varchar(8),
@adscat4 as varchar(8),
@adscat5 as varchar(8),
@bgcolor as varchar(8),
@bulletcode as varchar(8),
@bulletprm as float,
@material as varchar(8),
@region as varchar(8),
@varient_name as varchar(8),
@status as varchar(50),
@coltype as varchar(8),
@logo_h as varchar(5),
@logo_w as varchar(5),
@logo_col as varchar(8),
@logo_uom as varchar(8),
@retainer1 as varchar(50),
@addagencyrate as varchar(50),
@mobileno as varchar(100),
@addlamt as varchar(50),
@retamt as varchar(50),
@retper as varchar(50),
@cashrecieved as numeric,
@CIRAGENCY AS VARCHAR(100),
@CIRRATE AS VARCHAR(50),
@CIREDITION AS VARCHAR(50),
@CIRPUBLICATION AS VARCHAR(50),
@CIRAGENCYSUBCODE AS VARCHAR(50),
@BARTERTYPE AS VARCHAR(50),
@CASHDISCOUNT_V AS FLOAT,
@CASHDISCOUNTPER_V AS VARCHAR(5),
@attach1 AS varchar(50),
@attach2 AS varchar(50),
@drpdiscprem AS VARCHAR(50),
@doctype as varchar(20),
@CHKTRADE AS VARCHAR(1),
@sharepub_p as varchar(4000),
@fmginsert as varchar(100),
@chkno AS VARCHAR(50),
@chkdate as datetime=null,
@chkamt AS VARCHAR(30),
@chkbankname as varchar(100),
@ourbank	as varchar(50),
@DEALERPANEL_P AS VARCHAR(1),
@DEALERH_P AS FLOAT,
@DEALERW_P AS FLOAT,
@DEALERTYPE_P AS VARCHAR(1),
@multiselect AS VARCHAR(200),
@AGREEDRATE_ACTIVE as int,
@AGREEDAMT_ACTIVE as int,
@grossamtlocal_p as float,
@billamtlocal_p as float,
@chkadon_p as varchar(5),
@refid_p as varchar(50),
@rcpt_currency as varchar(8),
@cur_convrate as varchar(8),
@p_revisedate as datetime,
@clienttype as varchar(5),
@translation as varchar(25),
@translationcharge as float,
@fmgreasons as varchar(50),
@canclecharge  as varchar(50),
@P_ip as varchar(50),
@P_RATE_AUDIT_FLAG as varchar(10),
@transdisc_p as varchar(10),
@pospremdisc_p as varchar(10)
AS
declare @sccode			as varchar(50)
declare @v_modifed_audit varchar(1)
declare @v_audit_exist   numeric(1)

set @v_modifed_audit=null
If @audit is null and @rostatus='1' Begin
    
    /*select @v_audit_exist=count(x.rec) from
    (select count(*) rec from tbl_booking_mast 
        where "Comp_code"=@compcode and "cio_booking_id"=@ciobookid and "ro_status"='1' and "audit" is not null
    union
    select count(*) from tbl_booking_mast 
    where "Comp_code"=@compcode and "cio_booking_id"=@ciobookid and "ro_status"='1' and isnull(modified_audit,'N')='Y') x
    
    If @v_audit_exist>0 Begin
        set @v_modifed_audit='Y'
    End*/
    
    select  @v_modifed_audit =case when ("audit" is not null and "audit"!='') then 'Y' 
								when isnull(modified_audit,'N')='Y' then 'Y' 
							else null  End from tbl_booking_mast 
        where "Comp_code"=@compcode and "cio_booking_id"=@ciobookid and "ro_status"='1'    
End

select @sccode=scheme_id from scheme_master where scheme_name=ltrim(rtrim(@scheme)) and comp_code=@compcode
--insert into tbl_booking_mast( ,  ,  ,  ,  ,  ,  ,  , , ,	 ,  ,  , ,  , ,  ,  ,  ,  ,  ,  ,	  , , , , , ,  ,  ,  ,	 ,  ,	  ,  ,  , ,  ,  ,  ,  ,  ,  ,  ,	  ,  ,  ,  ,Comp_code ,Userid  )
--values			(,,,,, , , , ,, , , ,, ,, , , , , , , ,,, ,,  , , , , , , , , ,,,  , , , , , , , , ,,@compcode ,@userid )

--,,,,,,,,,,,,,,,,,,, 
--,,,,,,,, ,, ,, , ,, , , , , 
create table #recpt_t(receipt_no varchar(30))
update tbl_booking_mast set date_time=@date_time,branch=@branch,booked_by=@booked_by,prev_booking=@prevbook,applied_by=@approvedby,RO_No=@rono,RO_Date=@rodate,
Caption=@caption,bill_status=@billstatus,ro_status=@rostatus,Agency_code=@agency,Agency_address=@agencyaddress,Client_code=@client,Client_address=@clientaddresses,Agency_sub_code=@agencycode,
Dockit_no=@dockitno,Executive_code=@execname,Executive_zone=@execzone,Product_code=@product,Brand_code=@brand,Key_no=@keyno,Bill_remarks=@billremark,Print_remark=@printremark,
Package_code=@package,No_of_insertion=@insertion,Insertion_date=@startdate,Repeating_day=@repeatdate,Ad_type_code=@adtype,Ad_cat_code=@adcategory,Ad_sub_cat_code=@subcategory,
Color_code=@color,Uom_code=@uom,Page_position_code=@pageposition,Page_type_code=@pagetype,Page_no=@pageno,Ad_size_type_code=@adsizetype,Ad_size_height=@adsizheight,
Ad_size_width=@adsizwidth,Rate_code=@ratecode,Scheme_type_code=@sccode,Currency_code=@currency,Agrred_rate=@agreedrate,Agreed_amount=@agreedamt,Special_discount=@spedisc,
Space_discount=@spacedisx,Special_charges=@specialcharges,Agency_status=@agencystatus,Agency_type=@agencytype,Agency_pay=@paymode,Agency_credit=@agencredit,
Total_area=@totarea,Card_rate=@cardrate,Card_amount=@cardamount,Discount=@discount,Discount_per=@discountper,Bill_cycle=@billcycle,Revenue_center=@revenuecenter,
Bill_pay=@billpay,Bill_height=@billheight,Bill_width=@billwidth,Bill_to=@billto,Invoices=@invoices,Vts=@vts,Bill_add=@billaddress,Trade_disc=@tradedisc,Agency_out=@agencyout,
Box_code=@boxcode,Box_no=@boxno,Box_agency=@boxagency,Box_client=@boxclient,Box_address=@boxaddress,Booking_type=@bookingtype,Tfn=@tfn,Coupan_ad=@coupan,Campaign=@campaign,
Bill_amount=@bill_amt,Page_prem=@pageprem,Page_amount=@pageamt,Prem_per=@premper,Gross_amount=@grossamt,Ad_size_column=@adsizcolumn,Bill_column=@billcolumn,
Bill_area=@billarea,Special_disc_per=@specdiscper,Space_disc_per=@spacediscper,Paid_ins= @paidins,Contract_rate=@dealrate,Deviation=@deviation,Variant_code=@varient,
Contract_name=@contractname,Contract_type=@dealtype,Card_name=@cardname,Card_type=@cardtype,Card_month=@cardmonth,Card_year=@cardyear,Card_number=@cardno,Receipt_no=@receiptno,
Ad_Subcat3=@adscat3,Ad_Subcat4=@adscat4,Ad_subcat5=@adscat5,Bg_color=@bgcolor,Bullet_code=@bulletcode,Bullet_premium=@bulletprm,Material_status=@material,region=@region,variant=@varient_name,
status=@status,colortype=@coltype,logo_h=@logo_h,logo_w=@logo_w,logo_color=@logo_col,logo_uom=@logo_uom,RETAINER=@retainer1, ADD_AGENCY_COMM=@addagencyrate, tbl_booking_mast.MOBILENO=@mobileno,
add_agency_comm_amt=@addlamt,retainer_comm=@retper,retainer_comm_amt=@retamt,CASH_RECIEVED=@cashrecieved,CIRAGENCY=@CIRAGENCY,CIRRATE=@CIRRATE,CIREDITION=@CIREDITION,
CIRPUBLICATION=@CIRPUBLICATION,CIRAGENCY_SUBCODE=@CIRAGENCYSUBCODE,BARTER_TYPE=@BARTERTYPE,
CASHDISCOUNT=@CASHDISCOUNT_V, CASHDISCTYPE=@CASHDISCOUNTPER_V, ATTACHMENT1=@attach1, ATTACHMENT2=@attach2, DISC_PREMIUM=@drpdiscprem, DOCTYPE=@doctype,
CHKTRADEDISC=@CHKTRADE,CHK_NO=@chkno,CHK_DATE=@chkdate,CHK_AMT=@chkamt,CHK_BANK_NAME=@chkbankname,OUR_BANK=@ourbank,
DEALERPANEL=@DEALERPANEL_P,
DEALER_H=@DEALERH_P,
DEALER_W=@DEALERW_P,
DEALERTYPE=@DEALERTYPE_P,
ACTIVE_AGREEDRATE=@AGREEDRATE_ACTIVE,
ACTIVE_AGREEDAMT=@AGREEDAMT_ACTIVE,
LOCALGROSSAMT=@grossamtlocal_p,
LOCALBILLAMT=@billamtlocal_p,
PACKAGE_TYPE=@chkadon_p, AD_REFID=@refid_p,
RECEIPT_CURRENCY=@rcpt_currency,CONV_CURR_RATE=@cur_convrate,REVISE_DATE=@p_revisedate,CLIENT_TYPE=@clienttype,
TRANSLATION_CODE=@translation, TRANSLATION_PREMIUM=@translationcharge,MODIFIED_AUDIT=@v_modifed_audit,CANCELLATION_CHARGE=@canclecharge,
TRANSLATION_DISC=@transdisc_p,POSPREM_DISC=@pospremdisc_p,RATE_AUDIT_IP=@P_ip,RATE_AUDIT_FLAG=@P_RATE_AUDIT_FLAG
 where comp_code=@compcode and cio_booking_id=@ciobookid


IF @sharepub_p is not null and @sharepub_p!=''
begin
	exec insert_sharepub_details @sharepub_p,@ciobookid,'UPDATE'
end
 delete from TBL_BOOKING_FMG_TRANS where CIOID=@ciobookid
if @fmginsert is not null and @fmginsert!=''
begin
	exec insert_fmgTrans_details @fmginsert,@ciobookid,'UPDATE',@fmgreasons
end
if @multiselect is not null and @multiselect!=''
begin
	exec insert_multiexec_details @userid,@compcode,@multiselect,@ciobookid,'UPDATE'
end

IF @billpay='CA0' AND @rostatus='1' and (@receiptno='' or @receiptno is null)
BEGIN
declare @clientname varchar(500)
declare @remarks varchar(600)
declare @v_rcptno_r      varchar(50)
declare @vrecpt       varchar(20)
declare @branchcode   varchar(20)
declare @vrepcode     varchar(20)
declare @subagencyreg varchar(20)
declare @prevcioid_v varchar(50)
declare @billamt_v float
declare @grossamt_v float
declare @v_curdate datetime
declare @book_compcode varchar(50)
declare @book_branch varchar(50)
declare @book_agencycode varchar(50)

declare @prev_cioid varchar(50)

declare @book_rec varchar(50)

declare @book_client varchar(500)

declare @book_datetime datetime

declare @book_gross float
declare @book_billamt float
declare @book_userid varchar(50)
declare @book_billpay varchar(50)
declare @book_Agency_sub_code varchar(50)
declare @book_exec varchar(50)
declare @book_retainer varchar(50)
declare @book_Agency_code varchar(50)
declare @book_prev_cioid varchar(50)
select @book_client=client_code,@book_prev_cioid=prev_cioid,@book_Agency_code=Agency_code,@book_retainer=RETAINER,@book_exec=Executive_code,@book_Agency_sub_code=Agency_sub_code,@book_billpay=Bill_pay,@book_userid=userid,@book_datetime=date_time,@book_gross=Gross_amount,@book_billamt=Bill_amount,@prev_cioid=prev_cioid,@book_rec=receipt_no,@book_compcode=comp_code,@book_branch=branch,@book_agencycode=Agency_sub_code from tbl_booking_mast where cio_booking_id=@ciobookid

select @branchcode=Branch_Code  from branch_mst where Comp_Code=@book_compcode and Branch_Name=@book_branch

select @subagencyreg=SUB_Agency_Code  from agency_mast where Comp_Code=@book_compcode and code_subcode=@book_agencycode
set @vrecpt=@book_rec
set @prevcioid_v=@prev_cioid

if @prevcioid_v is null or @prevcioid_v=''
begin
		set @billamt_v=@book_billamt
		set @grossamt_v=@book_gross
		set @v_curdate=getdate()
end
else
begin
		select @billamt_v=Bill_amount,@grossamt_v=Gross_amount from tbl_booking_mast where cio_booking_id=@prevcioid_v
		set @billamt_v=@book_billamt - @billamt_v
		 set @grossamt_v=@book_gross - @grossamt_v
		 set @v_curdate=getdate()
end

 SELECT @clientname=Cust_Name FROM CUST_MAST WHERE Cust_Code = @book_client and Comp_Code=@book_compcode
if @clientname=''
begin
set @clientname=@book_client
end	

print @clientname
select @remarks='RONO#'+RO_No +' RODATE# ' + isnull(convert(varchar(12),RO_Date,103),'') + ' BOOKINGID# ' + cio_booking_id + ' CLIENT#' + @clientname from tbl_booking_mast where cio_booking_id=@ciobookid
insert into #recpt_t 
 exec receiptsave_booking @book_compcode,@book_userid, @book_branch,@doctype,@vrecpt,@v_curdate,@book_billpay,'','',@billamt_v,@book_Agency_sub_code,@grossamt_v,
  '','','',@remarks,@vrepcode,@book_datetime,@book_Agency_code,@subagencyreg,'',@ciobookid,@book_exec,@book_retainer,@book_prev_cioid
select @v_rcptno_r=receipt_no from   #recpt_t
update tbl_booking_mast set Receipt_no=@v_rcptno_r,receipt_date=@v_curdate where cio_booking_id=@ciobookid
drop table #recpt_t
END



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[executebooking]
@compcode as varchar(8),
@ciobookid as varchar(50),
@docno as varchar(25)=null,
@keyno as varchar(50)=null,
@rono as varchar(20)=null,
@agencycode as varchar(50)=null,
@client as varchar(100)=null,
@booking as varchar(8),
@dateformat as varchar(20),
@revenue as varchar(50)

AS
declare @query as varchar(8000)


CREATE TABLE #tempbooking_mast (
	date_time  datetime ,
	branch  varchar (25) ,
	booked_by  varchar (25) ,
	cio_booking_id  varchar (50) ,
	prev_booking  varchar (25) ,
	applied_by  varchar (25) ,
	audit  varchar (25) ,
	RO_No  varchar (20) ,
	RO_Date  datetime ,
	Caption  varchar (500) ,
	bill_status  varchar (8) ,
	ro_status  varchar (8) ,
	Agency_code  varchar (8) ,
	Agency_address  varchar (500) ,
	Client_code  varchar (100) ,
	Client_address  varchar (500) ,
	Agency_sub_code  varchar (28) ,
	Dockit_no  varchar (25) ,
	Executive_code  varchar (8) ,
	Executive_zone  varchar (8) ,
	Product_code  varchar (8) ,
	Brand_code  varchar (8) ,
	Key_no  varchar (50) ,
	Bill_remarks  varchar (500) ,
	Print_remark  varchar (500) ,
	Package_code  varchar (500) ,
	No_of_insertion  int ,
	Insertion_date  datetime ,
	Repeating_day  varchar (8) ,
	Ad_type_code  varchar (8) ,
	Ad_cat_code  varchar (8) ,
	Ad_sub_cat_code  varchar (50) ,
	Color_code  varchar (8) ,
	Uom_code  varchar (8) ,
	Page_position_code  varchar (8) ,
	Page_type_code  varchar (100) ,
	Page_no  int ,
	Ad_size_type_code  varchar (8) ,
	Ad_size_height  float ,
	Ad_size_width  float ,
	Rate_code  varchar (100) ,
	Scheme_type_code  varchar (18) ,
	Currency_code  varchar (8) ,
	Agrred_rate  float ,
	Agreed_amount  float ,
	Special_discount  float ,
	Space_discount  float ,
	Special_charges  float ,
	Agency_status  varchar (15) ,
	Agency_type  varchar (25) ,
	Agency_pay  varchar (25) ,
	Agency_credit  int ,
	Total_area  float ,
	Card_rate  float ,
	Card_amount  float ,
	Discount  float ,
	Discount_per  float ,
	Bill_cycle  varchar (8) ,
	Revenue_center  varchar (8) ,
	Bill_pay  varchar (8) ,
	Bill_height  float ,
	Bill_width  float ,
	Bill_to  varchar (100) ,
	Invoices  int ,
	Vts  int ,
	Bill_add  varchar (500) ,
	Trade_disc  float ,
	Agency_out  varchar (50) ,
	Box_code  varchar (8) ,
	Box_no  varchar (8) ,
	Box_agency  varchar (2) ,
	Box_client  varchar (2) ,
	Box_address  varchar (500) ,
	Comp_code  varchar (8) ,
	Userid  varchar (8) ,
	Creation_datetime  datetime ,
	Booking_type  varchar (8) ,
	Tfn  varchar (2) ,
	Coupan_ad  varchar (2) ,
	Campaign  varchar (50) ,
	Bill_amount  float ,
	Page_prem  varchar (8) ,
	Page_amount  float ,
	Prem_per  float ,
	Gross_amount  float ,
	Ad_size_column  float ,
	Bill_column  float ,
	Bill_area  float ,
	Special_disc_per  float ,
	Space_disc_per  float ,
	Paid_ins  int ,
	Contract_rate  float ,
	Deviation  float ,
	Variant_code  varchar (8) ,
	Contract_name  varchar (50) ,
	Contract_type  varchar (50) ,
	Card_name  varchar (100) ,
	Card_type  varchar (50) ,
	Card_month  varchar (8) ,
	Card_year  varchar (8) ,
	Card_number  varchar (20) ,
	Receipt_no  varchar (50) ,
	Ad_Subcat3  varchar (8) ,
	Ad_Subcat4  varchar (8) ,
	Ad_subcat5  varchar (8) ,
	Bg_color  varchar (8) ,
	Bullet_code  varchar (8) ,
	Bullet_premium  float ,
	Material_status  varchar (8) ,
	Receipt_date  datetime ,
	prev_cioid  varchar (100) ,
	prev_receipt  varchar (50) ,
	prev_grossamt  float ,
	Region  varchar (8) ,
	Variant  varchar (8) ,
	status  varchar (50) ,
	Colortype  varchar (8) ,
	Logo_H  varchar (5) ,
	Logo_W  varchar (5) ,
	Logo_color  varchar (8) ,
	Logo_Uom  varchar (8) ,
	SAPID  varchar (50) ,
	RETAINER  varchar (50) ,
	ADD_AGENCY_COMM  varchar (8) ,
MOBILENO varchar (50) ,
ADD_AGENCY_COMM_AMT  varchar (50),
RETAINER_COMM  varchar (50),
RETAINER_COMM_AMT  varchar (50),
CASH_RECIEVED numeric,
CIRAGENCY varchar (50),
CIRRATE varchar (50),
CIREDITION varchar (50),
CIRPUBLICATION varchar (50),
CIRAGENCY_SUBCODE varchar (50),
BARTERTYPE VARCHAR(50),
addflag varchar(10),
CASHDISCOUNT FLOAT,
CASHDISCTYPE VARCHAR(5 ),
ATTACHMENT1 VARCHAR(50 ),
ATTACHMENT2 VARCHAR(50 ),
DISC_PREMIUM VARCHAR(50),
CHKTRADEDISC VARCHAR(1),
CHK_DATE datetime,CHK_AMT float,CHK_BANK_NAME varchar(50),OUR_BANK varchar(50),CHK_NO varchar(50),
DEALERPANEL VARCHAR(1),
DEALER_H float,
DEALER_W float,
DEALERTYPE VARCHAR(1),
ACTIVE_AGREEDRATE INT,ACTIVE_AGREEDAMT INT,
LOCALGROSSAMT FLOAT,
LOCALBILLAMT FLOAT,
PACKAGE_TYPE VARCHAR(5),
AD_REFID VARCHAR(50),
RECEIPT_CURRENCY VARCHAR(8),
CONV_CURR_RATE VARCHAR(8),
REVISE_DATE  datetime ,
CLIENT_TYPE VARCHAR(5),
TRANSLATION_CODE VARCHAR(25), 
TRANSLATION_PREMIUM FLOAT,
APP_USER VARCHAR(50),
CANCELLATION_CHARGE  VARCHAR(1),
TRANSLATION_DISC  varchar(10),
POSPREM_DISC  varchar(10)
)

set @query=' insert  #tempbooking_mast  select 
	date_time,
	branch,
	booked_by,
	cio_booking_id,
	prev_booking,
	applied_by,
	audit ,
	RO_No,
	RO_Date,
	Caption,
	bill_status,
	ro_status,
	Agency_code,
	Agency_address,
	Client_code,
	Client_address,
	Agency_sub_code,
	Dockit_no,
	Executive_code,
	Executive_zone,
	Product_code,
	Brand_code,
	Key_no,
	Bill_remarks,
	Print_remark,
	Package_code,
	No_of_insertion,
	Insertion_date,
	Repeating_day,
	Ad_type_code,
	Ad_cat_code,
	Ad_sub_cat_code,
	Color_code,
	Uom_code,
	Page_position_code,
	Page_type_code,
	Page_no,
	Ad_size_type_code,
	Ad_size_height,
	Ad_size_width,
	Rate_code,
	Scheme_type_code,
	Currency_code,
	Agrred_rate,
	Agreed_amount,
	Special_discount,
	Space_discount,
	Special_charges,
	Agency_status,
	Agency_type,
	Agency_pay,
	Agency_credit  ,
	Total_area,
	Card_rate,
	Card_amount,
	Discount,
	Discount_per,
	Bill_cycle,
	Revenue_center,
	Bill_pay,
	Bill_height,
	Bill_width,
	Bill_to,
	Invoices  ,
	Vts  ,
	Bill_add,
	Trade_disc,
	Agency_out,
	Box_code,
	Box_no,
	Box_agency,
	Box_client,
	Box_address,
	Comp_code,
	Userid,
	Creation_datetime,
	Booking_type,
	Tfn,
	Coupan_ad,
	Campaign ,
	Bill_amount,
	Page_prem,
	Page_amount,
	Prem_per,
	Gross_amount,
	Ad_size_column,
	Bill_column,
	Bill_area,
	Special_disc_per,
	Space_disc_per ,
	Paid_ins,
	Contract_rate,
	Deviation,
	Variant_code,
	Contract_name,
	Contract_type,
	Card_name,
	Card_type,
	Card_month,
	Card_year,
	Card_number,
	Receipt_no,
	Ad_Subcat3,
	Ad_Subcat4,
	Ad_subcat5,
	Bg_color,
	Bullet_code,
	Bullet_premium,
	Material_status,
	Receipt_date,
	prev_cioid,
	prev_receipt,
	prev_grossamt,
	Region,
	Variant,
	status,
	Colortype,
	Logo_H,
	Logo_W,
	Logo_color,
	Logo_Uom,
	SAPID,
	RETAINER,
	ADD_AGENCY_COMM,
MOBILENO,ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,CASH_RECIEVED,
CIRAGENCY,CIRRATE,CIREDITION,CIRPUBLICATION,CIRAGENCY_SUBCODE,BARTER_TYPE,
(SELECT top 1 ADDITIONAL_FLAG  FROM COMM_DETAILS WHERE Agency_code+Agency_sub_code=tbl_booking_mast.Agency_sub_code and getdate() between eff_from_date and eff_till_date) AS ADDFLAG,
CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,CHKTRADEDISC,
CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,CHK_NO,DEALERPANEL,
DEALER_H,
DEALER_W,
DEALERTYPE
,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT,LOCALGROSSAMT,LOCALBILLAMT,PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,
REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,APP_USER,CANCELLATION_CHARGE,TRANSLATION_DISC,POSPREM_DISC 
	 from tbl_booking_mast where comp_code='''+@compcode+'''  '
print @ciobookid

if(@booking <> '0')
begin
set @query=@query+'and  (Ad_type_code = '''+@booking+''')' 
end 


if(@ciobookid<>'' )
begin
set @query=@query+'and  ( receipt_no='''+@ciobookid+''' or  cio_booking_id='''+@ciobookid+''')' 
end

--cio_booking_id = '''+@ciobookid+''' or

if(@docno<>'')
begin
set @query=@query+'and  Dockit_no = '''+@docno+''''
end

if(@keyno<>'')
begin
set @query=@query+'and  Key_no = '''+@keyno+''''
end

if(@rono<>'')
begin
set @query=@query+'and  RO_No = '''+@rono+''''
end

if(@agencycode<>'' )
begin
set @query=@query+'and  Agency_sub_code = '''+@agencycode+''''
end

if(@client<>'' ) 
begin
set @query=@query+'and  Client_code = '''+@client+''''
end

/*if(@booking<> '')
begin
set @query=@query +' and Ad_type_code='''+@booking+''''
end*/
 --set @query=@query + 'and branch='''+@revenue+''''
IF (@revenue IS NOT NULL or @revenue <> '')
--	set @query=@query + 'and branch in(select BRANCH_CODE FROM LOGIN_BRANCH_MAST  WHERE COMP_CODE='''+@compcode+''' and USER_CODE='''+@revenue+'''  and USER_FLAG=''Y'')'
-- SELECT BRANCH_CODE FROM LOGIN_BRANCH_MAST WHERE USER_CODE=revenue and COMP_CODE=compcode and USER_FLAG='Y')
print(@query)
exec(@query)


--insert into #tempbooking_mast(packgename)  select package_name from combin_mast where combin_code in (select Package_code from #tempbooking_mast)

--select convert(varchar(10),date_time,101) as  date_time,branch ,booked_by ,cio_booking_id ,prev_booking ,applied_by ,audit ,RO_No ,convert(varchar(10),RO_Date,101) as RO_Date ,Caption ,bill_status ,ro_status ,Agency_code ,Agency_address ,Client_code ,Client_address ,
select 
CASE @dateformat
                     WHEN 'mm/dd/yyyy' then convert(varchar(10),date_time,101)
	 WHEN 'dd/mm/yyyy' then convert(varchar(10),date_time,103)
WHEN 'yyyy/mm/dd' then convert(varchar(10),date_time,111)
	end	 as  DATE_TIME
,branch ,(select "Branch_Name" from branch_mst where "Branch_Code"="branch") as "BRANCH_NAME",
	booked_by ,cio_booking_id ,prev_booking ,applied_by ,audit ,RO_No ,CASE @dateformat
                     WHEN 'mm/dd/yyyy' then convert(varchar(10),ro_date,101)
	 WHEN 'dd/mm/yyyy' then convert(varchar(10),ro_date,103)
WHEN 'yyyy/mm/dd' then convert(varchar(10),ro_date,111)
	end  as RO_Date ,Caption ,bill_status ,ro_status ,#tempbooking_mast.Agency_code ,Agency_address ,Client_code  ,Client_address ,
	Agency_sub_code ,Dockit_no ,Executive_code  ,Executive_zone ,Product_code ,Brand_code ,Key_no ,Bill_remarks ,Print_remark ,Package_code ,No_of_insertion, CASE @dateformat
                     WHEN 'mm/dd/yyyy' then convert(varchar(10),Insertion_date,101)
	 WHEN 'dd/mm/yyyy' then convert(varchar(10),Insertion_date,103)
WHEN 'yyyy/mm/dd' then convert(varchar(10),Insertion_date,111)
	end as Insertion_date ,Repeating_day ,
	Ad_type_code ,	Ad_cat_code ,Ad_sub_cat_code ,Color_code ,Uom_code ,Page_position_code ,Page_type_code ,Page_no ,Ad_size_type_code ,Ad_size_height ,Ad_size_width ,Rate_code ,
   (select scheme_name from scheme_master where comp_code=@compcode and scheme_id=#tempbooking_mast.Scheme_type_code) as Scheme_type_code ,Currency_code ,Agrred_rate ,Agreed_amount ,Special_discount ,Space_discount ,Special_charges ,#tempbooking_mast.Comp_code ,	#tempbooking_mast.Userid,
	#tempbooking_mast.Agency_status ,
	Agency_type  ,
	Agency_pay  ,
	Agency_credit  ,
	Total_area  ,
	Card_rate  ,
	Card_amount  ,
	Discount  ,
	Discount_per  ,
	Bill_cycle,
	Revenue_center ,
	Bill_pay ,
	Bill_height  ,
	Bill_width  ,
	#tempbooking_mast.Bill_to ,
	Invoices  ,
	Vts  ,
	Bill_add ,
	Trade_disc  ,
	Agency_out ,
	#tempbooking_mast.Booking_type,
    Campaign,
	Page_prem,
	Page_amount,
	Prem_per,
	Gross_amount,
	Bill_amount,
	Box_code,
	Box_no,
	Box_agency,
	Box_client,
	Box_address,
	Tfn,
	Coupan_ad,
	Ad_size_column,
	Bill_column,
	Bill_area,
	Special_disc_per,
	Space_disc_per,
	agency_mast.agency_name+'('+agency_mast.code_subcode+')' as AgencyName,
(select exec_mast.exec_name+'('+convert(varchar(10),exec_mast.exe_no,101)+')' from exec_mast where   #tempbooking_mast.Executive_code=exec_mast.exe_no and #tempbooking_mast.comp_code=exec_mast.comp_code )  as execname ,
--	product_cat_mast.prod_desc+'('+product_cat_mast.prod_cat_code+')' ,

(select product_cat_mast.prod_desc+'('+product_cat_mast.prod_cat_code+')'  from   product_cat_mast where #tempbooking_mast.product_code=product_cat_mast.prod_cat_code
	and 	#tempbooking_mast.comp_code=product_cat_mast.comp_code) as product,	  

	Paid_ins,Contract_rate,Deviation,Variant_code,Contract_name,Contract_type,Card_name ,
	Card_type ,
	Card_month ,
	Card_year ,
	Card_number,
	Receipt_no ,
	Ad_Subcat3,
	Ad_Subcat4,
	Ad_subcat5,
	Bg_color,
	Bullet_code,
	Bullet_premium,
(select agency_name from agency_mast where comp_code=@compcode and code_subcode=#tempbooking_mast.agency_sub_code) as AgencySubCode,
isnull((select cust_name from CUST_MAST where comp_code=@compcode and cust_code=client_code),'')  as "Client",
(select payment_mode_name from Payment_Mode_Mast where comp_code=@compcode and pay_mode_code=agency_pay) as PayMode,
(select adv_cat_name from adv_cat_mast where comp_code=@compcode and adv_cat_mast.adv_cat_code=#tempbooking_mast.ad_cat_code) as categoryname,
(select  adv_subcat_name from adv_subcat_mast where comp_code=@compcode and adv_subcat_mast.adv_subcat_code=#tempbooking_mast.ad_sub_cat_code) as subcategoryname,
(select brand_name from brand_mst where comp_code=@compcode and brand_code=#tempbooking_mast.brand_code) as Brand,
(select uom_name from uom_mast where comp_code = @compcode and uom_code=#tempbooking_mast.uom_code) as UOM,
(select premiumname  from advpos_prem_mast where COMP_code=@compcode and premiumcode=#tempbooking_mast.page_type_code) as PagePremium,
(select pos_type from advpos_type_mast where comp_code=@compcode and pos_type_code=#tempbooking_mast.page_position_code) as PositionPremium,
(select curr_name from curr_mast where comp_code=@compcode and curr_code=#tempbooking_mast.currency_code) as Currency,
Material_status,
Receipt_date,#tempbooking_mast.region,Variant ,Colortype,	(select	uom_desc from uom_mast where comp_code=@compcode and uom_code=#tempbooking_mast.uom_code) as uom_desc,(select logo from uom_mast where comp_code=@compcode and uom_code=#tempbooking_mast.uom_code) as logo
	
	,Logo_H,Logo_W,Logo_color,Logo_Uom	,(select Logo_Uom from uom_mast  where comp_code=@compcode and uom_code=#tempbooking_mast.uom_code) as logocode,
	(select Box_Charges_Native from box_mast where comp_code=@compcode and box_mast.Box_Code=#tempbooking_mast.Box_code) as boxchrg,
retainer,(SELECT Retain_Name+'('+Retain_Code+')' FROM RETAINERMASTER WHERE comp_code=@compcode and RETAINERMASTER.Retain_Code=#TEMPBOOKING_MAST.RETAINER) AS RETAINER1,#tempbooking_mast.Booking_type as Booking_type,
(select Box_Charges_Type from box_mast where comp_code=@compcode and box_mast.Box_Code=#tempbooking_mast.Box_code) as boxchargetype,
ADD_AGENCY_COMM_AMT,RETAINER_COMM,RETAINER_COMM_AMT,CASH_RECIEVED,
(select pub_center from branch_mst where Branch_Code=#tempbooking_mast.branch and Comp_Code=@compcode) as pub_center,
  CIRAGENCY,CIRRATE,CIREDITION,CIRPUBLICATION,CIRAGENCY_SUBCODE,BARTERTYPE,(SELECT BARTE_DESC FROM AD_BARTER WHERE COMP_CODE=@compcode AND BARTER_CODE=#TEMPBOOKING_MAST.BARTERTYPE) AS BARTE_DESC,
  (SELECT BARTER_AMOUNT FROM AD_BARTER WHERE COMP_CODE=@compcode AND  BARTER_CODE=#TEMPBOOKING_MAST.BARTERTYPE) AS BARTE_AMOUNT,ADD_AGENCY_COMM,ADDFLAG,
CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,CHKTRADEDISC AS CHKTRADE,CASE @dateformat
 WHEN 'mm/dd/yyyy' then convert(varchar(10),CHK_DATE,101)
WHEN 'dd/mm/yyyy' then convert(varchar(10),CHK_DATE,103)
WHEN 'yyyy/mm/dd' then convert(varchar(10),CHK_DATE,111)
	end as CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,CHK_NO, AGENCY_MAST.BOOKING_TYPE,
DEALERPANEL,
DEALER_H,
DEALER_W,
DEALERTYPE,MOBILENO,ISNULL(ACTIVE_AGREEDRATE,0) as ACTIVE_AGREEDRATE,ISNULL(ACTIVE_AGREEDAMT,0) as ACTIVE_AGREEDRATE,
ISNULL(LOCALGROSSAMT,GROSS_AMOUNT) AS LOCALGROSSAMT, ISNULL(LOCALBILLAMT,BILL_AMOUNT) AS LOCALBILLAMT,PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,
(select TOP 1 Comm_Rate from comm_details where Agency_code + Agency_sub_code=#tempbooking_mast.agency_sub_code
 and Comp_code=upper(@compcode) and getdate() between Eff_from_Date and Eff_Till_Date ) as COMM_RATE,
 CASE @dateformat
	WHEN 'mm/dd/yyyy' then convert(varchar(10),REVISE_DATE,101)
	WHEN 'dd/mm/yyyy' then convert(varchar(10),REVISE_DATE,103)
	WHEN 'yyyy/mm/dd' then convert(varchar(10),REVISE_DATE,111)
 end as REVISE_DATE,CLIENT_TYPE,
 CASE @dateformat
	WHEN 'mm/dd/yyyy' then convert(DATETIME,#TEMPBOOKING_MAST.Creation_datetime,101)
	WHEN 'dd/mm/yyyy' then convert(DATETIME,#TEMPBOOKING_MAST.Creation_datetime,103)
	WHEN 'yyyy/mm/dd' then convert(DATETIME,#TEMPBOOKING_MAST.Creation_datetime,111)
 end as
 CREATION_DATETIME,TRANSLATION_CODE, TRANSLATION_PREMIUM,
 (SELECT CHARGES_TYPE FROM  AD_CHARGE_MAST WHERE AD_CHARGE_MAST.CHARGE_CODE=#TEMPBOOKING_MAST.TRANSLATION_CODE and COMP_CODE=@compcode) AS TRANSLATION_TYPE,
 (SELECT username FROM  LOGIN WHERE LOGIN.userid=#TEMPBOOKING_MAST.APP_USER and LOGIN.COM_CODE=@compcode) as APP_USER,CANCELLATION_CHARGE,
TRANSLATION_DISC ,POSPREM_DISC 
	  from #tempbooking_mast,agency_mast where  agency_mast.code_subcode=#tempbooking_mast.agency_sub_code and agency_mast.comp_code=@compcode 
print('ankur')

----------------------------------------------------Lata------------------------------------------------------
/*
select count(*) as [count] from tbl_booking_mast_history where cio_booking_id=@ciobookid and audit<>''
declare @version int
select @version=max(version) from tbl_booking_mast_history where cio_booking_id=@ciobookid and version<(select max(version) from tbl_booking_mast_history where cio_booking_id=@ciobookid)



select convert(varchar(10),date_time,101) as  date_time,branch ,booked_by ,cio_booking_id ,prev_booking ,applied_by ,audit ,RO_No ,convert(varchar(10),RO_Date,101) as RO_Date ,Caption ,bill_status ,ro_status ,tbl_booking_mast_history.Agency_code ,Agency_address ,client_code  ,Client_address ,
	Agency_sub_code ,Dockit_no ,Executive_code  ,Executive_zone ,Product_code ,Brand_code ,Key_no ,Bill_remarks ,Print_remark ,Package_code ,No_of_insertion ,convert(varchar(10),Insertion_date,101) as Insertion_date ,Repeating_day ,
	Ad_type_code ,	Ad_cat_code ,Ad_sub_cat_code ,Color_code ,Uom_code ,Page_position_code ,Page_type_code ,Page_no ,Ad_size_type_code ,Ad_size_height ,Ad_size_width ,Rate_code ,
	Scheme_type_code ,Currency_code ,Agrred_rate ,Agreed_amount ,Special_discount ,Space_discount ,Special_charges ,tbl_booking_mast_history.Comp_code ,	tbl_booking_mast_history.Userid,
	tbl_booking_mast_history.Agency_status ,
	Agency_type  ,
	Agency_pay  ,
	Agency_credit  ,
	Total_area  ,
	Card_rate  ,
	Card_amount  ,
	Discount  ,
	Discount_per  ,
	Bill_cycle,
	Revenue_center ,
	Bill_pay ,
	Bill_height  ,
	Bill_width  ,
	tbl_booking_mast_history.Bill_to ,
	Invoices  ,
	Vts  ,
	Bill_add ,
	Trade_disc  ,
	Agency_out ,

	booking_type,
Campaign,
	Page_prem,
	Page_amount,
	Prem_per,
	Gross_amount,
	Bill_amount,
	Box_code,
	Box_no,
	Box_agency,
	Box_client,
	Box_address,
	Tfn,
	Coupan_ad,
	Ad_size_column,
	Bill_column,
	Bill_area,
	Special_disc_per,
	Space_disc_per,

	--(select agency_name+'('+agency_code+')' from agency_mast where agency_code in(select Agency_code from #tempbooking_mast) and type='p'  and comp_code=@compcode),
	--(select exec_name+'('+convert(varchar(10),exe_no,101)+')' from exec_mast where exe_no in (select Executive_code from #tempbooking_mast)  and comp_code=@compcode),
	--(select prod_desc+'('+prod_cat_code+')' from product_cat_mast where prod_cat_code in (select Product_code from #tempbooking_mast) and comp_code=@compcode),
	agency_mast.agency_name+'('+agency_mast.code_subcode+')' as AgencyName,
(select exec_mast.exec_name+'('+convert(varchar(10),exec_mast.exe_no,101)+')'  from exec_mast where   tbl_booking_mast_history.Executive_code=exec_mast.exe_no and tbl_booking_mast_history.comp_code=exec_mast.comp_code )  as execname ,
--	product_cat_mast.prod_desc+'('+product_cat_mast.prod_cat_code+')' ,

(select product_cat_mast.prod_desc+'('+product_cat_mast.prod_cat_code+')'  from   product_cat_mast where tbl_booking_mast_history.product_code=product_cat_mast.prod_cat_code
	and 	tbl_booking_mast_history.comp_code=product_cat_mast.comp_code) as product,	  

	Paid_ins,Contract_rate,Deviation,Variant_code,Contract_name,Contract_type,Card_name ,
	Card_type ,
	Card_month ,
	Card_year ,
	Card_number,
	Receipt_no ,
	Ad_Subcat3,
	Ad_Subcat4,
	Ad_subcat5,
	Bg_color,
	Bullet_code,
	Bullet_premium,
(select agency_name from agency_mast where code_subcode=tbl_booking_mast_history.agency_sub_code) as AgencySubCode,
isnull((select cust_name from CUST_MAST where cust_code=client_code),client_code)  as "Client",
(select payment_mode_name from Payment_Mode_Mast where pay_mode_code=agency_pay) as PayMode,
(select adv_cat_name from adv_cat_mast where adv_cat_mast.adv_cat_code=tbl_booking_mast_history.ad_cat_code) as categoryname,
(select  adv_subcat_name from adv_subcat_mast where adv_subcat_mast.adv_subcat_code=tbl_booking_mast_history.ad_sub_cat_code) as subcategoryname,
(select brand_name from brand_mst where brand_code=tbl_booking_mast_history.brand_code) as Brand,
(select uom_name from uom_mast where uom_code=tbl_booking_mast_history.uom_code) as UOM,
(select premiumname  from advpos_prem_mast where premiumcode=tbl_booking_mast_history.page_type_code) as PagePremium,
(select pos_type from advpos_type_mast where pos_type_code=tbl_booking_mast_history.page_position_code) as PositionPremium,
(select curr_name from curr_mast where curr_code=tbl_booking_mast_history.currency_code) as Currency
	
	
	  from tbl_booking_mast_history,agency_mast where tbl_booking_mast_history.cio_booking_id=@ciobookid and version=@version and agency_mast.code_subcode=tbl_booking_mast_history.agency_sub_code and agency_mast.comp_code=@compcode 


















--select * from tbl_booking_mast_history where cio_booking_id=@ciobookid and version=@version
select convert(varchar(10),date_time,101) as  date_time,branch ,booked_by ,cio_booking_id ,prev_booking ,applied_by ,audit ,RO_No ,convert(varchar(10),RO_Date,101) as RO_Date ,Caption ,bill_status ,ro_status ,tbl_booking_mast_history.Agency_code ,Agency_address ,client_code  ,Client_address ,
	Agency_sub_code ,Dockit_no ,Executive_code  ,Executive_zone ,Product_code ,Brand_code ,Key_no ,Bill_remarks ,Print_remark ,Package_code ,No_of_insertion ,convert(varchar(10),Insertion_date,101) as Insertion_date ,Repeating_day ,
	Ad_type_code ,	Ad_cat_code ,Ad_sub_cat_code ,Color_code ,Uom_code ,Page_position_code ,Page_type_code ,Page_no ,Ad_size_type_code ,Ad_size_height ,Ad_size_width ,Rate_code ,
	Scheme_type_code ,Currency_code ,Agrred_rate ,Agreed_amount ,Special_discount ,Space_discount ,Special_charges ,tbl_booking_mast_history.Comp_code ,	tbl_booking_mast_history.Userid,
	tbl_booking_mast_history.Agency_status ,
	Agency_type  ,
	Agency_pay  ,

	Agency_credit  ,
	Total_area  ,
	Card_rate  ,
	Card_amount  ,
	Discount  ,
	Discount_per  ,
	Bill_cycle,
	Revenue_center ,
	Bill_pay ,
	Bill_height  ,
	Bill_width  ,
	tbl_booking_mast_history.Bill_to ,
	Invoices  ,
	Vts  ,

	Bill_add ,
	Trade_disc  ,
	Agency_out ,
	booking_type,
Campaign,
	Page_prem,
	Page_amount,
	Prem_per,
	Gross_amount,
	Bill_amount,
	Box_code,
	Box_no,
	Box_agency,
	Box_client,
	Box_address,
	Tfn,
	Coupan_ad,
	Ad_size_column,
	Bill_column,
	Bill_area,
	Special_disc_per,
	Space_disc_per,
	--(select agency_name+'('+agency_code+')' from agency_mast where agency_code in(select Agency_code from #tempbooking_mast) and type='p'  and comp_code=@compcode),
	--(select exec_name+'('+convert(varchar(10),exe_no,101)+')' from exec_mast where exe_no in (select Executive_code from #tempbooking_mast)  and comp_code=@compcode),
	--(select prod_desc+'('+prod_cat_code+')' from product_cat_mast where prod_cat_code in (select Product_code from #tempbooking_mast) and comp_code=@compcode),
	agency_mast.agency_name+'('+agency_mast.code_subcode+')' as AgencyName,
(select exec_mast.exec_name+'('+convert(varchar(10),exec_mast.exe_no,101)+')'  from exec_mast where   tbl_booking_mast_history.Executive_code=exec_mast.exe_no and tbl_booking_mast_history.comp_code=exec_mast.comp_code )  as execname ,
--	product_cat_mast.prod_desc+'('+product_cat_mast.prod_cat_code+')' ,

(select product_cat_mast.prod_desc+'('+product_cat_mast.prod_cat_code+')'  from   product_cat_mast where tbl_booking_mast_history.product_code=product_cat_mast.prod_cat_code
	and 	tbl_booking_mast_history.comp_code=product_cat_mast.comp_code) as product,	  

	Paid_ins,Contract_rate,Deviation,Variant_code,Contract_name,Contract_type,Card_name ,
	Card_type ,
	Card_month ,
	Card_year ,
	Card_number,
	Receipt_no ,
	Ad_Subcat3,
	Ad_Subcat4,
	Ad_subcat5,
	Bg_color,
	Bullet_code,
	Bullet_premium,
(select agency_name from agency_mast where code_subcode=tbl_booking_mast_history.agency_sub_code) as AgencySubCode,
isnull((select cust_name from CUST_MAST where cust_code=client_code),client_code)  as "Client",
(select payment_mode_name from Payment_Mode_Mast where pay_mode_code=agency_pay) as PayMode,
(select adv_cat_name from adv_cat_mast where adv_cat_mast.adv_cat_code=tbl_booking_mast_history.ad_cat_code) as categoryname,
(select  adv_subcat_name from adv_subcat_mast where adv_subcat_mast.adv_subcat_code=tbl_booking_mast_history.ad_sub_cat_code) as subcategoryname,
(select brand_name from brand_mst where brand_code=tbl_booking_mast_history.brand_code) as Brand,
(select uom_name from uom_mast where uom_code=tbl_booking_mast_history.uom_code) as UOM,
(select premiumname  from advpos_prem_mast where premiumcode=tbl_booking_mast_history.page_type_code) as PagePremium,
(select pos_type from advpos_type_mast where pos_type_code=tbl_booking_mast_history.page_position_code) as PositionPremium,
(select curr_name from curr_mast where curr_code=tbl_booking_mast_history.currency_code) as Currency
	
	
	  from tbl_booking_mast_history,agency_mast where tbl_booking_mast_history.cio_booking_id=@ciobookid and version=(select max(version) from tbl_booking_mast_history where cio_booking_id=@ciobookid and version<(select max(version) from tbl_booking_mast_history where cio_booking_id=@ciobookid) and audit<>'')  and agency_mast.code_subcode=tbl_booking_mast_history.agency_sub_code and agency_mast.comp_code=@compcode 

--select * from tbl_booking_mast_history where cio_booking_id=@ciobookid and  version=(select max(version) from tbl_booking_mast_history where cio_booking_id=@ciobookid and version<(select max(version) from tbl_booking_mast_history where cio_booking_id=@ciobookid) and audit<>'') 
----------------------------------------------------END------------------------------------------------------
--#tempbooking_mast.Agency_sub_code


drop table #tempbooking_mast
*/







set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER PROCEDURE [dbo].[committransaction]
	@pcioid          as  varchar(50),
	@totalcount      as  int,
	@pcompcode       as  varchar(20),
	@pcentname       as  varchar(20),
	@puserid         as  varchar(20),
	@pbkid_gentype   as  varchar(20),
	@pbk_type		 as  varchar(20)
AS
declare @countnum int
declare @billpay varchar(20)
declare @rostatus varchar(10)
declare @remarks varchar(500)
declare @clientname varchar(200)

declare @v_cursor1_var1  varchar(50)
declare @v_cursor1_var2  varchar(50)
declare @newid			 varchar(50)	

BEGIN
select @countnum=count(*) from tbl_booking_insert_g where Cio_Booking_Id=@pcioid
if @countnum=@totalcount begin

EXEC getautocodebooking_new
	@pcompcode,
	'0',
	'0',
	@v_cursor1_var1 OUTPUT, 
    @v_cursor1_var2 OUTPUT
                                            
    
    if  @pbkid_gentype='1' Begin--1 for First 3 character of Centre Name+Year + Slno  
        
        set @newid=substring(@pcentname,1,3)+@v_cursor1_var2+dbo.fnPadLeft('0',8,@v_cursor1_var1) 
    End
    else if  @pbkid_gentype='2' Begin--2 for First 3 character of Centre Name+Year + Userid + Slno
    
        set @newid=substring(@pcentname,1,3)+@v_cursor1_var2+dbo.fnPadLeft('0',8,@v_cursor1_var1) +@puserid
	End
    else if  @pbkid_gentype='4' Begin--4 for BK Type + Slno
        set @newid=@pbk_type+dbo.fnPadLeft('0',8,@v_cursor1_var1) 
    end	
    else if  @pbkid_gentype='3' Begin--3 for Slno only
        set @newid=dbo.fnPadLeft('0',8,@v_cursor1_var1) 
    end
    else 
    Begin
        set @newid=dbo.fnPadLeft('0',8,@v_cursor1_var1) 
    end
create table #recpt_t(receipt_no varchar(130))
 INSERT INTO tbl_booking_mast
           ([date_time]
           ,[branch]
           ,[booked_by]
           ,[cio_booking_id]
           ,[prev_booking]
           ,[applied_by]
           ,[audit]
           ,[RO_No]
           ,[RO_Date]
           ,[Caption]
           ,[bill_status]
           ,[ro_status]
           ,[Agency_code]
           ,[Agency_address]
           ,[Client_code]
           ,[Client_address]
           ,[Agency_sub_code]
           ,[Dockit_no]
           ,[Executive_code]
           ,[Executive_zone]
           ,[Product_code]
           ,[Brand_code]
           ,[Key_no]
           ,[Bill_remarks]
           ,[Print_remark]
           ,[Package_code]
           ,[No_of_insertion]
           ,[Insertion_date]
           ,[Repeating_day]
           ,[Ad_type_code]
           ,[Ad_cat_code]
           ,[Ad_sub_cat_code]
           ,[Color_code]
           ,[Uom_code]
           ,[Page_position_code]
           ,[Page_type_code]
           ,[Page_no]
           ,[Ad_size_type_code]
           ,[Ad_size_height]
           ,[Ad_size_width]
           ,[Rate_code]
           ,[Scheme_type_code]
           ,[Currency_code]
           ,[Agrred_rate]
           ,[Agreed_amount]
           ,[Special_discount]
           ,[Space_discount]
           ,[Special_charges]
           ,[Agency_status]
           ,[Agency_type]
           ,[Agency_pay]
           ,[Agency_credit]
           ,[Total_area]
           ,[Card_rate]
           ,[Card_amount]
           ,[Discount]
           ,[Discount_per]
           ,[Bill_cycle]
           ,[Revenue_center]
           ,[Bill_pay]
           ,[Bill_height]
           ,[Bill_width]
           ,[Bill_to]
           ,[Invoices]
           ,[Vts]
           ,[Bill_add]
           ,[Trade_disc]
           ,[Agency_out]
           ,[Box_code]
           ,[Box_no]
           ,[Box_agency]
           ,[Box_client]
           ,[Box_address]
           ,[Comp_code]
           ,[Userid]
           ,[Creation_datetime]
           ,[Booking_type]
           ,[Tfn]
           ,[Coupan_ad]
           ,[Campaign]
           ,[Bill_amount]
           ,[Page_prem]
           ,[Page_amount]
           ,[Prem_per]
           ,[Gross_amount]
           ,[Ad_size_column]
           ,[Bill_column]
           ,[Bill_area]
           ,[Special_disc_per]
           ,[Space_disc_per]
           ,[Paid_ins]
           ,[Contract_rate]
           ,[Deviation]
           ,[Variant_code]
           ,[Contract_name]
           ,[Contract_type]
           ,[Card_name]
           ,[Card_type]
           ,[Card_month]
           ,[Card_year]
           ,[Card_number]
           ,[Receipt_no]
           ,[Ad_Subcat3]
           ,[Ad_Subcat4]
           ,[Ad_subcat5]
           ,[Bg_color]
           ,[Bullet_code]
           ,[Bullet_premium]
           ,[Material_status]
           ,[Receipt_date]
           ,[prev_cioid]
           ,[prev_receipt]
           ,[prev_grossamt]
           ,[Region]
           ,[Variant]
           ,[status]
           ,[Colortype]
           ,[Logo_H]
           ,[Logo_W]
           ,[Logo_color]
           ,[Logo_Uom]
           ,[SAPID]
           ,[RETAINER]
           ,[ADD_AGENCY_COMM]
           ,[AUDIT_COMMENT]
           ,[MOBILENO]
           ,[ADD_AGENCY_COMM_AMT]
           ,[RETAINER_COMM]
           ,[RETAINER_COMM_AMT]
           ,[CASH_RECIEVED]
           ,[CONT_GROSS]
           ,[CIRAGENCY]
           ,[CIRRATE]
           ,[CIREDITION]
           ,[CIRPUBLICATION]
           ,[CIRAGENCY_SUBCODE]
           ,[BARTER_TYPE]
           ,[APP_STATUS]
           ,[APP_REMARKS]
           ,[APP_DATE]
           ,[APP_USER]
           ,[RODOCSTATUS]
           ,[RO_COMMENT],CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,
			DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL,
			DEALER_H,
			DEALER_W,
			DEALERTYPE,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT,PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,
			REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,CANCELLATION_CHARGE,TRANSLATION_DISC,POSPREM_DISC)
SELECT [date_time]
           ,[branch]
           ,[booked_by]
           ,@newid
           ,[prev_booking]
           ,[applied_by]
           ,[audit]
           ,[RO_No]
           ,[RO_Date]
           ,[Caption]
           ,[bill_status]
           ,[ro_status]
           ,[Agency_code]
           ,[Agency_address]
           ,[Client_code]
           ,[Client_address]
           ,[Agency_sub_code]
           ,[Dockit_no]
           ,[Executive_code]
           ,[Executive_zone]
           ,[Product_code]
           ,[Brand_code]
           ,[Key_no]
           ,[Bill_remarks]
           ,[Print_remark]
           ,[Package_code]
           ,[No_of_insertion]
           ,[Insertion_date]
           ,[Repeating_day]
           ,[Ad_type_code]
           ,[Ad_cat_code]
           ,[Ad_sub_cat_code]
           ,[Color_code]
           ,[Uom_code]
           ,[Page_position_code]
           ,[Page_type_code]
           ,[Page_no]
           ,[Ad_size_type_code]
           ,[Ad_size_height]
           ,[Ad_size_width]
           ,[Rate_code]
           ,[Scheme_type_code]
           ,[Currency_code]
           ,[Agrred_rate]
           ,[Agreed_amount]
           ,[Special_discount]
           ,[Space_discount]
           ,[Special_charges]
           ,[Agency_status]
           ,[Agency_type]
           ,[Agency_pay]
           ,[Agency_credit]
           ,[Total_area]
           ,[Card_rate]
           ,[Card_amount]
           ,[Discount]
           ,[Discount_per]
           ,[Bill_cycle]
           ,[Revenue_center]
           ,[Bill_pay]
           ,[Bill_height]
           ,[Bill_width]
           ,[Bill_to]
           ,[Invoices]
           ,[Vts]
           ,[Bill_add]
           ,[Trade_disc]
           ,[Agency_out]
           ,[Box_code]
           ,[Box_no]
           ,[Box_agency]
           ,[Box_client]
           ,[Box_address]
           ,[Comp_code]
           ,[Userid]
           ,[Creation_datetime]
           ,[Booking_type]
           ,[Tfn]
           ,[Coupan_ad]
           ,[Campaign]
           ,[Bill_amount]
           ,[Page_prem]
           ,[Page_amount]
           ,[Prem_per]
           ,[Gross_amount]
           ,[Ad_size_column]
           ,[Bill_column]
           ,[Bill_area]
           ,[Special_disc_per]
           ,[Space_disc_per]
           ,[Paid_ins]
           ,[Contract_rate]
           ,[Deviation]
           ,[Variant_code]
           ,[Contract_name]
           ,[Contract_type]
           ,[Card_name]
           ,[Card_type]
           ,[Card_month]
           ,[Card_year]
           ,[Card_number]
           ,[Receipt_no]
           ,[Ad_Subcat3]
           ,[Ad_Subcat4]
           ,[Ad_subcat5]
           ,[Bg_color]
           ,[Bullet_code]
           ,[Bullet_premium]
           ,[Material_status]
           ,[Receipt_date]
           ,[prev_cioid]
           ,[prev_receipt]
           ,[prev_grossamt]
           ,[Region]
           ,[Variant]
           ,[status]
           ,[Colortype]
           ,[Logo_H]
           ,[Logo_W]
           ,[Logo_color]
           ,[Logo_Uom]
           ,[SAPID]
           ,[RETAINER]
           ,[ADD_AGENCY_COMM]
           ,[AUDIT_COMMENT]
           ,[MOBILENO]
           ,[ADD_AGENCY_COMM_AMT]
           ,[RETAINER_COMM]
           ,[RETAINER_COMM_AMT]
           ,[CASH_RECIEVED]
           ,[CONT_GROSS]
           ,[CIRAGENCY]
           ,[CIRRATE]
           ,[CIREDITION]
           ,[CIRPUBLICATION]
           ,[CIRAGENCY_SUBCODE]
           ,[BARTER_TYPE]
           ,[APP_STATUS]
           ,[APP_REMARKS]
           ,[APP_DATE]
           ,[APP_USER]
           ,[RODOCSTATUS]
           ,[RO_COMMENT],CASHDISCOUNT, CASHDISCTYPE, ATTACHMENT1, ATTACHMENT2,DISC_PREMIUM,
			DOCTYPE,CHKTRADEDISC,CHK_NO,CHK_DATE,CHK_AMT,CHK_BANK_NAME,OUR_BANK,DEALERPANEL,
			DEALER_H,
			DEALER_W,
			DEALERTYPE,ACTIVE_AGREEDRATE,ACTIVE_AGREEDAMT,LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID, RECEIPT_CURRENCY, CONV_CURR_RATE,
			REVISE_DATE,CLIENT_TYPE,TRANSLATION_CODE, TRANSLATION_PREMIUM,CANCELLATION_CHARGE,TRANSLATION_DISC,POSPREM_DISC
			 FROM TBL_BOOKING_MAST_G WHERE  CIO_BOOKING_ID=@pcioid

INSERT INTO [tbl_booking_insert]
			(insert_id,
           [cio_booking_id]
           ,[no_insert]
           ,[Edition_code]
           ,[Publication_code]
           ,[Pub_cent_code]
           ,[Supp_code]
           ,[Edition]
           ,[Insert_date]
           ,[Col_code]
           ,[Height]
           ,[Width]
           ,[Size_book]
           ,[Page_post]
           ,[Premium1]
           ,[Prem_per1]
           ,[Premium2]
           ,[Prem_per2]
           ,[Premium_allow]
           ,[Ad_cat]
           ,[Ad_sub_cat]
           ,[Latest_by]
           ,[Repeating_date]
           ,[Status_material]
           ,[File_name]
           ,[Card_rate]
           ,[Disc_rate]
           ,[Insert_status]
           ,[Bill_status]
           ,[Agreed_rate]
           ,[Pai_free_ins]
           ,[Solo_rate]
           ,[Gross_rate]
           ,[comp_code]
           ,[Userid]
           ,[Page_no]
           ,[Remarks]
           ,[Pub_height]
           ,[Pub_width]
           ,[Page_prem]
           ,[page_per]
           ,[No_ofcolumn]
           ,[Bill_Amt]
           ,[Bill_rate]
           ,[Logo_H]
           ,[Logo_W]
           ,[Logo_name]
           ,[AD_SUBCAT3]
           ,[AD_SUBCAT4]
           ,[AD_SUBCAT5]
           ,[PACKAGE_CODE]
           ,[BILL_NO]
           ,[BILL_DATE]
           ,[INSERTS]
           ,[PKG_ALIAS]
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT
           , LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION,DISCOUNT)
SELECT insert_id,@newid
           ,[no_insert]
           ,[Edition_code]
           ,[Publication_code]
           ,[Pub_cent_code]
           ,[Supp_code]
           ,[Edition]
           ,[Insert_date]
           ,[Col_code]
           ,[Height]
           ,[Width]
           ,[Size_book]
           ,[Page_post]
           ,[Premium1]
           ,[Prem_per1]
           ,[Premium2]
           ,[Prem_per2]
           ,[Premium_allow]
           ,[Ad_cat]
           ,[Ad_sub_cat]
           ,[Latest_by]
           ,[Repeating_date]
           ,[Status_material]
           ,[File_name]
           ,[Card_rate]
           ,[Disc_rate]
           ,[Insert_status]
           ,[Bill_status]
           ,[Agreed_rate]
           ,[Pai_free_ins]
           ,[Solo_rate]
           ,[Gross_rate]
           ,[comp_code]
           ,[Userid]
           ,[Page_no]
           ,[Remarks]
           ,[Pub_height]
           ,[Pub_width]
           ,[Page_prem]
           ,[page_per]
           ,[No_ofcolumn]
           ,[Bill_Amt]
           ,[Bill_rate]
           ,[Logo_H]
           ,[Logo_W]
           ,[Logo_name]
           ,[AD_SUBCAT3]
           ,[AD_SUBCAT4]
           ,[AD_SUBCAT5]
           ,[PACKAGE_CODE]
           ,[BILL_NO]
           ,[BILL_DATE]
           ,[INSERTS]
           ,[PKG_ALIAS]
           ,[LOCKSTATUS],SPECIAL_SIZE1,VATAMT, BOXCHARGE,VAT_INC
           , LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO,CAPTION, DISCOUNT
            FROM TBL_BOOKING_INSERT_G WHERE  CIO_BOOKING_ID=@pcioid

INSERT INTO TBL_BOOKING_VTS(COMPCODE, CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE) 
SELECT COMPCODE, @newid CIOID, INSERTID, VTS, PUBLICATION, EDITION, RATE, CREATIONDATETIME, CIRAGCODE, CIRAGSUBCODE, CENTER, BRANCH, PUBLISHDATE FROM TBL_BOOKING_VTS_G WHERE  cioid=@pcioid


insert into tbl_booking_subedition(COMP_CODE, CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO,SRNO, NO_INSERT,PAGE_NO)
select COMP_CODE, @newid CIOID, INSERTID, PUBLICATION, EDITION, INSERTDATE, HEIGHT, WIDTH, TOTALAREA, INSERTSTATUS, RECEIPTNO, SRNO, NO_INSERT,PAGE_NO from tbl_booking_subedition_g
where tbl_booking_subedition_g.CIOID=@pcioid;


insert into TBL_BOOKING_SHARING_TRANS(PUBLICATION, TYPE, SHARING, CIOID, SRNO)
select PUBLICATION, TYPE, SHARING, @newid CIOID, SRNO from TBL_BOOKING_SHARING_TRANS_g where CIOID=@pcioid

insert into TBL_BOOKING_FMG_TRANS(CIOID, INSERTID, CREATIONDATETIME,FMG_REASONS)
select @newid CIOID, INSERTID, CREATIONDATETIME,FMG_REASONS from TBL_BOOKING_FMG_TRANS_G where CIOID=@pcioid

 update tbl_matter set cioid=@newid where "cioid"=@pcioid 
 
 select @billpay=Bill_pay,@rostatus=ro_status  from tbl_booking_mast where cio_booking_id=@newid
PRINT @rostatus
if (@billpay = 'CA0' or @billpay = 'CH0') and @rostatus='1' begin
	PRINT 'START'
	declare @v_rcptno_r      varchar(50)
	declare @vrecpt       varchar(20)
	declare @branchcode   varchar(20)
	declare @vrepcode     varchar(20)
	declare @subagencyreg varchar(20)
	declare @prevcioid_v varchar(50)
	declare @billamt_v float
	declare @grossamt_v float
	declare @v_curdate datetime
	declare @book_compcode varchar(50)
	declare @book_branch varchar(50)
	declare @book_agencycode varchar(50)

	declare @prev_cioid varchar(50)

	declare @book_rec varchar(50)
	declare @book_doctype varchar(50)
	declare @book_client varchar(500)

	declare @book_datetime datetime

	declare @book_gross float
	declare @book_billamt float
	declare @book_userid varchar(50)
	declare @book_billpay varchar(50)
	declare @book_Agency_sub_code varchar(50)
	declare @book_exec varchar(50)
	declare @book_retainer varchar(50)
	declare @book_Agency_code varchar(50)
	declare @book_prev_cioid varchar(50)
	
	select @book_doctype=doctype,@book_client=client_code,@book_prev_cioid=prev_cioid,@book_Agency_code=Agency_code,@book_retainer=RETAINER,@book_exec=Executive_code,@book_Agency_sub_code=Agency_sub_code,@book_billpay=Bill_pay,@book_userid=userid,@book_datetime=date_time,@book_gross=Gross_amount,@book_billamt=Bill_amount,@prev_cioid=prev_cioid,@book_rec=receipt_no,@book_compcode=comp_code,@book_branch=branch,@book_agencycode=Agency_sub_code from tbl_booking_mast where cio_booking_id=@newid

	select @branchcode=Branch_Code  from branch_mst where Comp_Code=@book_compcode and Branch_Name=@book_branch

	select @subagencyreg=SUB_Agency_Code  from agency_mast where Comp_Code=@book_compcode and code_subcode=@book_agencycode
	set @vrecpt		=@book_rec
	set @prevcioid_v=@prev_cioid

	if @prevcioid_v is null or @prevcioid_v='' begin
			set @billamt_v	=@book_billamt
			set @grossamt_v	=@book_gross
			set @v_curdate	=@book_datetime
	end
	else begin
			select @billamt_v=Bill_amount,@grossamt_v=Gross_amount from tbl_booking_mast where cio_booking_id=@prevcioid_v
			set @billamt_v	=@book_billamt - @billamt_v
			 set @grossamt_v=@book_gross - @grossamt_v
			IF @grossamt_v = 0 OR @grossamt_v IS NULL
			BEGIN
				set @grossamt_v=@book_gross
			END
			 set @v_curdate=getdate()
	end

	SELECT @clientname=Cust_Name FROM CUST_MAST WHERE Cust_Code = @book_client and Comp_Code=@book_compcode
	if @clientname='' begin
		set @clientname=@book_client
	end	
	print @pcioid
	print @clientname
	select @remarks='RONO#'+RO_No +' RODATE# ' + isnull(convert(varchar(12),RO_Date,103),'') + ' BOOKINGID# ' + cio_booking_id + ' CLIENT#' + @clientname from tbl_booking_mast where cio_booking_id=@pcioid
	--print 'lata'
	--print @book_Agency_code
	--print @subagencyreg
	--print @cioid
	--print @book_exec
	--print @book_retainer
	--print @book_prev_cioid
	--print 'f'
	--print(@book_compcode+'#,'+@book_userid+'#,'+ @book_branch+'#,'+'RCP'+'#,'+@vrecpt+'#,'+convert(varchar(12),@v_curdate,103)+'#,'+@book_billpay+'#,'+''+'#,'+''+'#,'+cast(@billamt_v as varchar(10))+'#,'+@book_Agency_sub_code+'#,'+cast(@grossamt_v as varchar(20))+'#,')
	 --  print(''+'#,'+''+'#,'+''+'#,'+@remarks+'#,'+@vrepcode+'#,'+convert(varchar(12),@book_datetime,103)+'#,'+@book_Agency_code+'#,'+@subagencyreg+'#,'+''+'#,'+@cioid+'#,'+@book_exec+'#,'+@book_retainer+'#,'+@book_prev_cioid)

	insert into #recpt_t 
	 exec receiptsave_booking @book_compcode,@book_userid, @book_branch,@book_doctype,@vrecpt,@v_curdate,@book_billpay,'','',@billamt_v,@book_Agency_sub_code,@grossamt_v,
	  '','','',@remarks,@vrepcode,@book_datetime,@book_Agency_code,@subagencyreg,'',@newid,@book_exec,@book_retainer,@book_prev_cioid
	
	select @v_rcptno_r=receipt_no from   #recpt_t
	
	update tbl_booking_mast set Receipt_no=@v_rcptno_r where cio_booking_id=@newid
	
	drop table #recpt_t
	end

end
select @newid as "CIO_ID",@v_rcptno_r as "REC"
END




=========end===avinash===========by lata mam==============================07june2012=================================

//////////////////////////////issue no:7569(8/6/2012)/////////////

USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[websp_bindcioidlatest12]    Script Date: 06/08/2012 09:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






ALTER procedure  [dbo].[websp_bindcioidlatest12]
--@code as varchar(10),
@fromdate as varchar(10),
 @todate as varchar(10),
@date as varchar(15),
@publication as varchar(50),
@bookingcenter as varchar(40),
@revenuecenter as varchar(40),
@agencytype as varchar(30),
@package as varchar(40),
@adtype as varchar(50),
@agency as varchar(50),
@client as varchar(50),
@billstatus as varchar(50),
@rate_audit as varchar(8),
@billmode as  varchar(10),
@billcycle as varchar(10),
@v_retainer_name AS varchar(10),
@v_executive_name AS varchar(10),
@v_branch_name AS varchar(10),
@v_ad_category AS varchar(10),
@v_district AS varchar(10),
@v_taluka AS varchar(10),
@pcompcode AS varchar(10),
@billno as varchar(200),
@BILL_GEN_PRIOR as varchar(50)=null,
@PUB_CENT_HO as varchar(50)=null,
@centerlogin as varchar(50)=null,
@fmg_bills as varchar(20)=null,
@scheme_type as varchar(50)=null,
@pto_bill_no as varchar(50)

 AS



declare @package_cd  as varchar(300)
declare @package_result  as varchar(300)
declare @package_cd1  as varchar(300)
declare  @str as varchar(8000)
declare @billcyc as varchar(40)

declare @v_bill_criteria as varchar(10);

create table #package ( package_name varchar (100) )


print(@billcycle)


if @adtype='DI0' begin
    select @v_bill_criteria=disp_billing_criteria from preferrences where comp_code=@pcompcode
	end
else
	begin
    select @v_bill_criteria=clsd_billing_criteria From preferrences where comp_code=@pcompcode
	end


if(@billstatus='2')
begin


 set  @str='select distinct max(tbl_booking_insert.cio_booking_id) cio_booking_id,max(no_insert)as no_of_insertion ,max(tbl_booking_mast.package_code) as edition ,
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=tbl_booking_mast.Client_code),tbl_booking_mast.Client_code)  AS client,
max(tbl_booking_mast.trade_disc) as Commission,convert(varchar,max(tbl_booking_insert.Insert_Date),103) as "pub_date",
AGENCY_MAST.agency_name as Agency,sum(tbl_booking_insert.gross_rate) as gross_rate,tbl_booking_insert.insert_status as status,count(tbl_booking_mast.no_of_insertion) as total,max(TBL_BOOKING_MAST.Bill_remarks) as Bill_remarks,
tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount",
tbl_booking_insert.Bill_Amt,
null as "UNPUBLISHED"
from tbl_booking_insert,tbl_booking_mast,agency_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.cio_booking_id  
 and agency_mast.code_subcode=tbl_booking_mast.agency_sub_code  and ( tbl_booking_insert.insert_status=''billed'')' 
end






if(@billstatus=1 and @rate_audit='n' and ( @billmode='3' ))
begin
set  @str='SELECT  DISTINCT  TBL_BOOKING_INSERT.Cio_Booking_Id, No_Insert AS no_of_insertion ,TBL_BOOKING_MAST.Package_code  AS edition,
    isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client,
      AGENCY_MAST.Agency_Name AS Agency,sum(TBL_BOOKING_INSERT.Gross_Rate) as Gross_Rate,TBL_BOOKING_MAST.Trade_disc AS Commission,convert(varchar,tbl_booking_insert.Insert_Date,103) as "pub_date",
      TBL_BOOKING_INSERT.Insert_Status AS status,TBL_BOOKING_MAST.No_of_insertion AS total,TBL_BOOKING_MAST.Bill_remarks,

	  tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount",

tbl_booking_insert.Bill_Amt,
null as "UNPUBLISHED"

      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
 AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code  AND (TBL_BOOKING_INSERT.Insert_Status=''billed'')' ;

end

if( @billstatus='3' )
begin
set  @str='select distinct  tbl_booking_insert.cio_booking_id,no_insert as no_of_insertion ,tbl_booking_mast.package_code as edition ,
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client,
tbl_booking_mast.trade_disc as Commission,convert(varchar,tbl_booking_insert.Insert_Date,103) as "pub_date",
AGENCY_MAST.agency_name as Agency,sum(tbl_booking_insert.gross_rate) as gross_rate,tbl_booking_insert.insert_status as status,tbl_booking_mast.no_of_insertion as total,TBL_BOOKING_MAST.Bill_remarks as Bill_remarks,

tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount"
,tbl_booking_insert.Bill_Amt,
null as "UNPUBLISHED"
from tbl_booking_insert,tbl_booking_mast,agency_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.cio_booking_id  
 and agency_mast.code_subcode=tbl_booking_mast.agency_sub_code  and ( tbl_booking_insert.insert_status=''audit by rate'')' 

end


IF(@billstatus=6)
begin
set  @str=' SELECT DISTINCT  TBL_BOOKING_INSERT.Cio_Booking_Id,No_Insert AS no_of_insertion ,TBL_BOOKING_MAST.Package_code AS edition ,
isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client,
AGENCY_MAST.Agency_Name AS Agency,sum(TBL_BOOKING_INSERT.Gross_Rate) as Gross_Rate,TBL_BOOKING_MAST.Trade_disc AS Commission,convert(varchar,tbl_booking_insert.Insert_Date,103) as "pub_date",
TBL_BOOKING_INSERT.Insert_Status AS status,TBL_BOOKING_MAST.No_of_insertion AS  total,TBL_BOOKING_MAST.Bill_remarks,
tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount"
,tbl_booking_insert.Bill_Amt,
null as "UNPUBLISHED"
FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id  AND
 TBL_BOOKING_INSERT.Insert_Status=''booked'' AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code ';
END 


IF(@billstatus=5)
 begin

    set  @str='SELECT  DISTINCT  TBL_BOOKING_INSERT.Cio_Booking_Id, No_Insert AS no_of_insertion ,TBL_BOOKING_MAST.Package_code  AS edition,
      isnull((SELECT Cust_Name FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client,
      AGENCY_MAST.Agency_Name AS Agency,sum(TBL_BOOKING_INSERT.Gross_Rate) as Gross_Rate,TBL_BOOKING_MAST.Trade_disc AS Commission,convert(varchar,tbl_booking_insert.Insert_Date,103) as "pub_date",
      TBL_BOOKING_INSERT.Insert_Status AS status,TBL_BOOKING_MAST.No_of_insertion AS total,TBL_BOOKING_MAST.Bill_remarks,
      tbl_booking_insert.BILL_NO,
(select top 1 isnull(ad_bills.PRINT_COUNT,0) from ad_bills  where  tbl_booking_insert."Comp_Code"=ad_bills.COMP_CODE_V and ad_bills.BILNO=tbl_booking_insert.BILL_NO  ) as "PrintCount"
,tbl_booking_insert.Bill_Amt,
null as "UNPUBLISHED"

      FROM TBL_BOOKING_INSERT,TBL_BOOKING_MAST,AGENCY_MAST WHERE TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id  AND
       TBL_BOOKING_INSERT.Insert_Status=''publish'' AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code' ;
   END 


/*
if @v_bill_criteria='A' begin--it is for agency bill frequncy
	if(@billcycle is not null )
	begin	
		if(@billcycle != '1')
		begin
			set @str=@str+' and AGENCY_MAST.bill_frequency ='''+@billcycle +''''
		end
		else
		begin
			set @str=@str+' and isnull(AGENCY_MAST.bill_frequency,0) not in (''W'',''M'',''F'')'
		end
	end
end
if @v_bill_criteria='R' begin --it is for bill cycle in booking
	if(@billcycle is not null )
	begin
		set @str=@str+' and replace(TBL_BOOKING_MAST.Bill_cycle,''0'',''1'') ='''+@billcycle +''''
--print(@billcycle)
	end
end

*/

if(@agency is not null)
begin

set @str=@str+' and TBL_BOOKING_MAST.agency_sub_code ='''+@agency +''''
end

if(@client is not null)
begin
set @str=@str+' and TBL_BOOKING_MAST.client_code ='''+@client +''''
end
if(@agencytype is not null)
begin
set @str=@str+' and TBL_BOOKING_mast.agency_type  ='''+@agencytype+''''
end


if(@adtype is not null)
begin
print(@adtype)
set @str=@str + ' and TBL_BOOKING_MAST. ad_type_code ='''+@adtype+''' '
End


if(@bookingcenter is not null)
begin
--print(@adtype)
set @str=@str + 'and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''+@bookingcenter+'''))';
--set @str=@str + ' and TBL_BOOKING_MAST. branch ='''+@bookingcenter+''' '
End


if(@revenuecenter is not null)
begin

set @str=@str + ' and TBL_BOOKING_MAST. branch ='''+@revenuecenter+''' '
End


if(@publication is not null)
begin
set @str=@str+' and  TBL_BOOKING_INSERT.publication_code='''+ @publication +''''
End

 if(@fromdate is not null and @todate is not null )
begin
	set @str=@str+' and insert_date between  '''+@fromdate +''' and  '''+@todate +''' '
end


--print('ankur33')
print(@package)
if(@package is not null)
begin
print(@package)
set @str=@str+' and  TBL_BOOKING_insert.edition ='''+@package +''''
End

/*
if(@BILL_GEN_PRIOR = 'PUB_CENT_HO')
begin
		if(@PUB_CENT_HO is not null) and @PUB_CENT_HO=@centerlogin
		begin
		set @str=@str+' and  ((TBL_BOOKING_INSERT.pub_cent_code='''+@PUB_CENT_HO+''''+') or (tbl_booking_insert.package_code in (SELECT package_code FROM temp_packagename)))'
		end
		else
		begin
		set @str=@str+' and  ((TBL_BOOKING_INSERT.pub_cent_code='''+@centerlogin+''''+') and (tbl_booking_insert.package_code not in (SELECT package_code FROM temp_packagename)))'
		end
end
*/
if((@billno is not null) and (@pto_bill_no is not null))
begin
		set @str=@str+' and  TBL_BOOKING_INSERT.bill_no between '''+@billno+'''  and '''+@pto_bill_no+''''

end



if(@fmg_bills !='Include')
begin
set @str=@str+' and tbl_booking_mast.Booking_type not in (''2'',''4'',''5'')'

end

if(@billstatus='2')
begin
	set @str=@str+' group by AGENCY_MAST.agency_name,tbl_booking_insert.insert_status ,
	tbl_booking_insert.bill_no,tbl_booking_insert.Comp_Code

,tbl_booking_insert.Bill_Amt,Client_code

	order by tbl_booking_insert.bill_no,cio_booking_id'
end
else
begin
	set @str=@str+' group by tbl_booking_insert.cio_booking_id,no_insert,tbl_booking_mast.package_code
	,tbl_booking_mast.client_code,tbl_booking_mast.trade_disc,AGENCY_MAST.agency_name
	,tbl_booking_insert.insert_status ,tbl_booking_mast.Client_code
	,tbl_booking_mast.no_of_insertion ,TBL_BOOKING_MAST.Bill_remarks,tbl_booking_insert.bill_no,
	tbl_booking_insert.Comp_Code,tbl_booking_insert.Insert_Date 
,tbl_booking_insert.Bill_Amt
	order by tbl_booking_insert.cio_booking_id,tbl_booking_insert.no_insert'
end













 --select nvl(last_billno,0) as "LAST_BILLNO",to_char(v_last_dt,v_dateformat) as "LAST_BILLDT",nvl(v_billed,0) as "ALREADY_BILLED",
  --   nvl(v_booked_by_others,0) as "BOOKED_BY_OTHERS" from dual;





select  @package_cd1=tbl_booking_insert.package_code from tbl_booking_insert,tbl_booking_mast,agency_mast where tbl_booking_mast.cio_booking_id=tbl_booking_insert.cio_booking_id  
 and agency_mast.code_subcode=tbl_booking_mast.agency_sub_code  and (tbl_booking_insert.insert_status ='publish' or tbl_booking_insert.insert_status='billed')
--insert into #package select replace(package_code,'''','') from dbo.PA_Splitedition(@editioncode,',' )


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




print( @str)
exec( @str)


select 0 as "LAST_BILLNO",0 as "LAST_BILLDT",0 as "ALREADY_BILLED",
   0 as "BOOKED_BY_OTHERS" 


select * from #package
delete from #package


/*if(@billstatus <> null)
begin
set @str=@str+' and  TBL_BOOKING_INSERT.insert_status='''+ @billstatus +''''
End*/


/////////////////////end//////////////////////////////////////////////////////////

//////////////////////////////Start Issue No:7711(8/6/2012)//////////////////



ALTER PROCEDURE  [dbo].[Websp_Orderlastnew_b]
(

@bookingid as VARCHAR(500),
@dateformat as VARCHAR(50),
@fromdate as VARCHAR(50),
@dateto as VARCHAR(50),
@v_invoice as VARCHAR(500),
@v_compcode as VARCHAR(50)

)

 AS

declare @query as varchar(8000)
declare @query1 as varchar(8000)
declare @str as varchar(8000)
declare @var_date_min as varchar(8000)
declare @package_cd  as varchar(300)
declare @package_result  as varchar(300)
declare @package_cd1  as varchar(300)
create table #package ( package_name varchar (100) )
set @var_date_min=@fromdate


set @query='SELECT TBL_BOOKING_MAST .RO_No,
 TBL_BOOKING_INSERT .Cio_Booking_Id,
TBL_BOOKING_INSERT.No_Insert ,
TBL_BOOKING_INSERT.Edition,
Height,
Width,
Size_Book,
COL_MAST.Col_Name,
 TBL_BOOKING_INSERT.Page_No,
 TBL_BOOKING_INSERT.No_Ofcolumn,

 TBL_BOOKING_insert.Gross_Rate,
 CASE '''+@dateformat+'''
  WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),Insert_Date,1)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),Insert_Date,3)

WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),Insert_Date,3)  END AS "Ins.date",
tbl_booking_insert.Agreed_Rate,
tbl_booking_mast.Agency_address,
 AGENCY_MAST.Agency_Name,
 CASE '''+@dateformat+'''
   WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),RO_Date,1)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),RO_Date,3)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),RO_Date,3) END AS RO_Date,
pub_mast.Pub_Name as Publication,
(select adv_cat_mast.Adv_Cat_Name from adv_cat_mast where ADV_CAT_MAST.Adv_Cat_Code=TBL_BOOKING_MAST.Ad_cat_code)

as AdCat,

isnull((SELECT Cust_Alias FROM CUST_MAST WHERE Cust_Code=Client_code),Client_code)  AS client
,tbl_booking_mast.Client_address
, city_mst.City_Name,
tbl_booking_insert.No_Insert,
(SELECT BOX_MAST.Box_Charges_Native FROM BOX_MAST,TBL_BOOKING_MAST  WHERE

TBL_BOOKING_MAST.Box_code=BOX_MAST.Box_Code AND TBL_BOOKING_MAST.cio_booking_id='''+@bookingid+''') as

boxcode,
TBL_BOOKING_MAST.Trade_disc,
Invoices,

(select  PUB_CENT_MAST.Add1 FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS Add1,
1 as Phone1,
2 as Phone2,
PUB_CENT_MAST .Fax1 as Fax1,
uom_mast.Uom_Alias ,
TBL_BOOKING_MAST.Key_no AS "Key No",
3 as Email,

CASE '''+@dateformat+'''
when ''mm/dd/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),1) 
when ''dd/mm/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),3) 
when ''yyyy/mm/dd'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_insert.insert_date ),3)  end as "paydate",
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),1) 
when ''dd/mm/yyyy'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),3) 
when ''yyyy/mm/dd'' then convert(varchar(10),dateadd(day,Agency_mast.Credit_Days,tbl_booking_mast.insertion_date ),3)  end as "paydatesys",

tbl_booking_insert.Card_Rate,
adv_type_mast.Adv_Type_Name,
tbl_booking_mast.No_of_insertion,
tbl_booking_mast.Gross_amount,
tbl_booking_mast.Caption,



comp_mst .Comp_Name as companyname,

comp_mst.PAN_No as pan,
PUB_CENT_MAST.Pub_Cent_name as pubname,

comp_mst.Add1 as address,
comp_mst.Street as street,
comp_mst.Fax as fax,
(select distinct Bullet_Charges  from BULlet_mast,tbl_booking_mast where tbl_booking_mast

.Bullet_code=BULlet_mast.Bullet_Code  AND   TBL_BOOKING_mast.cio_booking_id='''+@bookingid+''' ) AS

expremiumch,
TBL_BOOKING_MAST  .ADD_AGENCY_COMM as adtd,


tbl_booking_mast.Trade_disc  as td,

  tbl_booking_mast.branch,
    col_mast.Col_Alias as  Color_code,


   CASE '''+@dateformat+'''
   WHEN ''mm/dd/yyyy'' THEN convert(varchar(20),getdate(),1)
WHEN ''dd/mm/yyyy'' THEN convert(varchar(20),getdate(),3)
WHEN ''yyyy/mm/dd'' THEN convert(varchar(20),getdate(),3) END AS SYSDATE1,


(select PUB_CENT_MAST .EmailID FROM PUB_CENT_MAST WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS EmailID,


CASE '''+@dateformat+'''
 when ''mm/dd/yyyy''  then(select convert(varchar(20),max(Insert_Date),1) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''')
 when ''dd/mm/yyyy'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id='''+@bookingid+''')

 when ''yyyy/mm/dd'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''') end as maxdate,


 (select advpos_type_mast.Amount from  advpos_type_mast where

advpos_type_mast.Pos_Type_Code=tbl_booking_mast.Page_position_code)as expr,

 tbl_booking_mast.Card_rate*Total_area as amtnew,

50 as  "PACKAGERATE",

/* ((SELECT SUM(Card_Rate-ROUND((Card_Rate*(isnull(TBL_BOOKING_MAST.Special_disc_per,0)+isnull(TBL_BOOKING_MAST.Space_disc_per,0))/100),2)) FROM TBL_BOOKING_INSERT  WHERE INSERTS=''1'' AND TBL_BOOKING_INSERT
.Cio_Booking_Id='''+@bookingid+''' and
Insert_Date between  '''+@var_date_min+''' and '''+@dateto+''' )) AS PACKAGERATE,*/

TBL_BOOKING_MAST.Agrred_rate,




(select  PUB_CENT_MAST.street FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS street_new,





CASE '''+@dateformat+'''
 when ''mm/dd/yyyy''  then(select convert(varchar(20),max(Insert_Date),1) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''' AND Insert_Date between  '''+@fromdate+''' and
'''+@dateto+''')
 when ''dd/mm/yyyy'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id='''+@bookingid+''' AND Insert_Date between  '''+@fromdate+''' and
'''+@dateto+''')

 when ''yyyy/mm/dd'' then(select convert(varchar(20),max(Insert_Date),3) from tbl_booking_insert where

Cio_Booking_Id ='''+@bookingid+''' AND Insert_Date between  '''+@fromdate+''' and
'''+@dateto+''') end as maxdate1,

TBL_BOOKING_INSERT.Bill_Amt,';


set @query1='(select  PUB_CENT_MAST.Fax FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS Fax2,

(select  PUB_CENT_MAST.Fax1 FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST.Pub_cent_Code IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS Fax3,
(select  PUB_CENT_MAST."FILE_PATH" FROM  PUB_CENT_MAST  WHERE
PUB_CENT_MAST."Pub_cent_Code" IN
(SELECT BRANCH_MST.pub_center FROM BRANCH_MST WHERE BRANCH_MST.Branch_Name=TBL_BOOKING_MAST.branch AND PUB_CENT_MAST.Pub_cent_Code=BRANCH_MST.pub_center ))AS FILE_PATH,
tbl_booking_mast."Special_charges" as "Special_charges",


pub_cent_mast.Fax1 as fax1,
pub_cent_mast.phone1 as phone,
pub_cent_mast.phone1 as phone0,
COL_MAST.Col_Code,
tbl_booking_mast."Bill_to" as "bill2",
dbo.getadd('''+@v_compcode+''','''+@bookingid+''') as "agenadd",

tbl_booking_mast.bill_remarks as "Remark",
dbo.get_printing_cent_street_fr_bran('''+@v_compcode+''',tbl_booking_mast.branch)as street_login,
 AGENCY_MAST.code_subcode as "Agency_code"
,

(select edition_code  from edition_mast where edition_mast.edition_code=tbl_booking_insert.edition_code) as Edition_Name
,
isnull((select Product_Name from Product_Mast where Product_Code=tbl_booking_mast.Product_code),tbl_booking_mast.Product_code) as product


FROM TBL_BOOKING_MAST  ,
TBL_BOOKING_INSERT,
COL_MAST,
AGENCY_MAST,
PUB_MAST,
CITY_MST,
PUB_CENT_MAST,
uom_mast,
adv_type_mast,
comp_mst,
Product_Mast
WHERE  TBL_BOOKING_INSERT.Col_Code=COL_MAST.Col_Code 
AND  CITY_MST.City_Code=AGENCY_MAST.City_Code  

AND AGENCY_MAST.code_subcode=TBL_BOOKING_MAST.Agency_sub_code 
AND TBL_BOOKING_INSERT.Publication_Code=PUB_MAST.Pub_Code
and uom_mast.Uom_Code=tbl_booking_mast.Uom_code
and TBL_BOOKING_MAST .Comp_code=comp_mst.Comp_Code
and tbl_booking_mast.Ad_type_code=adv_type_mast.Adv_Type_Code 
 AND adv_type_mast.COMP_CODE=TBL_BOOKING_MAST.COMP_CODE
and PUB_CENT_MAST.Pub_cent_Code  =TBL_BOOKING_INSERT.Pub_Cent_Code
AND TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.Cio_Booking_Id
AND TBL_BOOKING_INSERT  .Cio_Booking_Id='''+@bookingid+''' 
and Insert_Date between  '''+@var_date_min+''' and
'''+@dateto+'''
--and (bill_no='''+@v_invoice+''' or  '''+@v_invoice+'''= '''')

and Insert_Status!=''cancel''


order by tbl_booking_insert. No_Insert'

print(@query)
print(@query1)
exec(@query+@query1)

select  @package_cd1=package_code from tbl_booking_mast where cio_booking_id=@bookingid



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
exec(@str)

select * from #package
delete from #package


update ad_bills set PRINT_COUNT=isnull(PRINT_COUNT,0)+1 where COMP_CODE_V=@v_compcode and BILNO=@v_invoice;
///////////////////////end////////////////////////////////

////////////again start issue no:7711(8/6/2012)////////////////////
USE [new_db_hari]
GO
/****** Object:  StoredProcedure [dbo].[websp_selectvalues]    Script Date: 05/24/2012 10:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[websp_selectvalues]


(

@ciobooking  varchar(50), 
@editionname varchar(50),
@compcode  VARCHAR(50),
@insertion varchar(50),
@dateformat varchar(50)
)
as 
declare @str  as varchar(8000)
declare @package_cd  as varchar(300)
declare @package_result  as varchar(300)
declare @package_cd1  as varchar(300)
create table #package ( package_name varchar (100) )

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
pub_cent_mast.add1,
pub_cent_mast.phone1,
pub_cent_mast.phone2 ,
pub_cent_mast.fax1,
TBL_BOOKING_INSERT.agreed_rate,
TBL_BOOKING_INSERT.Edition as "EditionName",
agency_mast.bill_to,
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),insert_date,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),insert_date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),insert_date,3)  end as "insert_date",
tbl_booking_mast.uom_code,
(select Uom_Name from uom_mast where uom_code=tbl_booking_mast.uom_code) as uom_name,
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
PUB_MAST.Pub_Code as "pub_cod",
edition_mast.Edition_Code as "edit_code",
tbl_booking_mast.Scheme_type_code as "scheme",
tbl_booking_mast.Rate_code as "rate_code",
agency_mast.Agency_Code as "agency_cod",
(select top 1 Box_Charges_Native from Box_mast where Box_mast.Box_Code=tbl_booking_mast.Box_code) as "Box_Charge",
tbl_booking_mast.Page_amount as "Pag_amt",
tbl_booking_mast.Prem_per as "pag_prem",
dbo.get_printing_cent_name_fr_bran('''+@compcode+''',tbl_booking_mast.branch) as Print_cent_name,
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),date_time,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),date_time,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),date_time,3)  end as "date_time",
case tbl_booking_mast.ad_type_code
when ''DI0'' then tbl_booking_mast."Caption" else tbl_booking_mast."key_no" end as "Cap",
TBL_BOOKING_mast.ADD_AGENCY_COMM as "addcom",
case '''+@dateformat + '''
when ''mm/dd/yyyy'' then convert(varchar(10),TBL_BOOKING_MAST.RO_Date,1) 
when ''dd/mm/yyyy'' then convert(varchar(10),TBL_BOOKING_MAST.RO_Date,3) 
when ''yyyy/mm/dd'' then convert(varchar(10),TBL_BOOKING_MAST.RO_Date,3)  end as "RO_Date",
tbl_booking_mast."key_no" as "key_no",
AGENCY_MAST.pin_code,
(select distinct COLORRATEGROUPMAST.prcent_pr from COLORRATEGROUPMAST 
where tbl_booking_mast.comp_code=COLORRATEGROUPMAST.comp_code and 
tbl_booking_mast.ad_type_code=COLORRATEGROUPMAST.ad_type and tbl_booking_insert.package_code=COLORRATEGROUPMAST.pkg_code 
 and tbl_booking_insert.col_code=COLORRATEGROUPMAST.color_name) as "Extra",
(select top 1 Cont_Person from cont_details where tbl_booking_mast.Comp_code=cont_details.Comp_Code 
and cont_details.Agency_Code=tbl_booking_mast.Agency_code) as "contact",
pub_cent_mast.Street as "pub_cent_street",
TBL_BOOKING_MAST.Bill_remarks,
tbl_booking_mast."Bill_to" as "bill2",
dbo.getadd('''+@compcode+''','''+@ciobooking+''') as "agenadd",
dbo.get_printing_cent_street_fr_bran('''+@compcode+''',tbl_booking_mast.branch)as street_login
,
tbl_booking_mast.Agrred_rate  as Agrred_rate
,
	isnull((select Product_Name from Product_Mast where Product_Code=tbl_booking_mast.Product_code),''--'') as product


from TBL_BOOKING_MAST,pub_cent_mast,
TBL_BOOKING_INSERT,
AGENCY_MAST ,
PUB_MAST
,
COL_MAST ,
edition_mast,
city_mst,
comp_mst,
Product_Mast

 where TBL_BOOKING_MAST.comp_code='''+@compcode+''' and TBL_BOOKING_INSERT.pub_cent_code=pub_cent_mast.pub_cent_code
and TBL_BOOKING_MAST.cio_booking_id=TBL_BOOKING_INSERT.cio_booking_id
 and TBL_BOOKING_MAST.agency_code=AGENCY_MAST.agency_code  and comp_mst.comp_code='''+@compcode+''' 
 and tbl_booking_insert.Col_code=col_mast.Col_code   and pub_mast.pub_code=tbl_booking_insert.publication_code 
  and edition_mast.edition_code=tbl_booking_insert.edition_code and city_mst.city_code=agency_mast.city_code  and TBL_BOOKING_INSERT.publication_code = PUB_MAST.pub_code and   tbl_booking_insert.cio_booking_id='''+@ciobooking+''' and   tbl_booking_insert.no_insert='''+@insertion+''' and  tbl_booking_insert.edition='''+@editionname+''' '





select  @package_cd1=package_code from tbl_booking_mast where cio_booking_id=@ciobooking



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
exec(@str)


select * from #package
delete from #package

select distinct edition_code from tbl_booking_insert where  cio_booking_id=@ciobooking

-- select top 1 insert_date from tbl_booking_insert where  cio_booking_id=@ciobooking order by insert_date
select top 1 DateName( Month,insert_date )+''+ DateName( Year, insert_date ) as "insert_date" from tbl_booking_insert where  cio_booking_id=@ciobooking order by insert_date

////////////////////////end ////////////////////////




//////start by shipra/////issue no 7785//////////////////


USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[gettheprevbooking]    Script Date: 06/14/2012 13:00:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[gettheprevbooking]
@compcode as varchar(8),
@userid as varchar(8),
@formname as varchar(50)


AS
declare @agency as varchar(20)

select top 1 cio_booking_id from tbl_booking_mast where comp_code=@compcode and userid=@userid and ad_type_code=@formname order by Creation_datetime desc

--select retain_name from retainermaster where retain_code =(select retainer_code from login where com_code=@compcode and userid=@userid)
SELECT retainer_code,BOOKING_EDITLINES FROM LOGIN where userid=@userid

--select Backdate_booking from Module_DetaiButtonl  where Form_name=@formname and comp_code=@compcode and userid=@userid
SELECT Allowed_old_date ,AGENCYCOMM_SEQ_COM,CREDIT_RECIPT,BACKDATERECEIPT,DOCKIT_BOOKING,copy_booking,book_insert_date,SEPRATE_CASHIER,MAX_PUBLISHDAYS,SPECIALDISC_TRANS_EDIT, SHARING_TRANS, MULTIPACKAGE_SEL_TRANS, isnull(SCHEME_MINWORD,'N'), isnull(TRADE_SPLCHARGE,'Y'),PUBLISHAD_EDIT_RATEAUDIT,isnull(PREMIUM_EDIT,'N') as PREMIUM_EDIT,ISNULL(SPLDISC_ALLOWPREM,'N') AS SPLDISC_ALLOWPREM from PREFERRENCES where comp_code = @compcode

select agency_name + '('+code_subcode +')' as agency_name,agency_code from agency_mast where qbc_userid=@userid

select Confirm_qbc from Module_DetaiButtonl where form_name='QBC' and userid=@userid

select agency_name + '('+code_subcode +')',agency_code from agency_mast  where code_subcode in (select agency_code from login where userid=@userid)


select   agency_name,code_subcode from agency_mast where agency_code in    ( select agency_code  from agency_mast where qbc_userid=@userid)
select   agency_name,code_subcode from agency_mast where agency_code in    (select agency_code from agency_mast  where code_subcode in (select agency_code from login where userid=@userid))



///////////end of issue 7785///////done by shipra/////////




///////////////done by bhanu sir/////////////////////////



USE [abhi]
GO
/****** Object:  StoredProcedure [dbo].[chkdiscountpremedit_per]    Script Date: 06/14/2012 15:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER Procedure [dbo].[chkdiscountpremedit_per]
@compcode as varchar(20),
@userid1 as varchar(20)
as



 select PERMISSION_DESC from userpermission where COMM_CODE=@compcode and USERID=@userid1
and PERMISSION_DESC='Allow Editing Discount Item Line Wise In Transaction'

select PERMISSION_DESC from userpermission where COMM_CODE=@compcode and USERID=@userid1
and PERMISSION_DESC='Not Allow Reset Paid Insertion In Transaction'



//////////////////end by bhanu sir///////////////////////





///////////////start///avinash==========15-06==2012===================================

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go









ALTER PROCEDURE [dbo].[executecontract]

@compcode as varchar(8),--
@userid as varchar(8),--
@DealNo as varchar(8),--
@dealname as varchar(50),--
@agencycode as varchar(8),--
@subagencycode as varchar(8),--
@representative as varchar(8),
@dealtype as varchar(8),
@quotion_p as varchar(8)
--@contract_id as varchar(100)--



AS

declare @query as varchar(2000)



CREATE TABLE #Temp_Contract_mast (
	Deal_No varchar (8)  ,
	Comp_code varchar (8)  ,
	Agency_code varchar (80)  ,
	Sub_Agency_Code varchar (8)  ,
	Client_code varchar (80)  ,
	Product_code varchar (8)  ,
	From_date datetime  ,
	Till_date datetime  ,
	representative varchar (8)  ,
	Userid varchar (8)  ,
	Creation_datetime datetime  ,
	Total_val int ,
	Total_volu int ,
	team_code varchar(8),
	deal_type varchar(8),
	deal_name varchar(50),
	contract_id varchar(100),
	Ad_type varchar(12),
	REMARKS varchar(1000),
	EXECUTIVE varchar(20), 
	RETAINER varchar(20),
	CONTRACTDATE datetime,
	CLOSEDATE datetime,
	SERVICETAX datetime,
	PAYMENTTYPE varchar(200),
	CAPTION varchar(500),
B2B varchar(10), CHKMULTIAD varchar(10), SEQNO_ALLOW varchar(10), SEQNO varchar(10), 
AFT_PRTCLR_AD varchar(10), INDUSTRY varchar(10), INDUSTRY_PRODUCT varchar(100), DEALON VARCHAR(20)
,ATTACHMENT VARCHAR(20),QUOTATION varchar(2)
) 
/*

CREATE TABLE #temp_Contract_mast (
	Deal_No varchar (8) ,
	Comp_code varchar (8) ,
	Agency_code varchar (8)  ,
	Sub_Agency_Code varchar (8)  ,
	Client_code varchar (8)  ,
	Product_code varchar (8)  ,
	From_date datetime  ,
	Till_date datetime  ,
	representative varchar (8)  ,
	Adv_cat_code varchar (8)  ,
	Publication_code varchar (8)  ,
	suppliment_code varchar (8)  ,
	Edition_code varchar (8)  ,
	Booked_for varchar (8)  ,
	Color_code varchar (8)  ,
	Card_rate decimal(18, 0)  ,
	Deal_rate decimal(18, 0)  ,
	premium_code varchar (8)  ,
	Card_premium varchar (8)  ,
	Deal_premium varchar (8)  ,
	Volume_billed varchar (15)  ,
	Volume_disc varchar (15)  ,
	Value_from varchar (15)  ,
	Value_to varchar (15)  ,
	UOM_Code varchar (8)  ,
	Package_code varchar (8)  ,
	Userid varchar (8) ,
	Creation_datetime datetime ,
	Total_val int  ,
	Total_volu int  ,
	curr_code varchar (8)  ,
	team_code varchar (8)  ,
	deal_type varchar (8)  ,
	deal_name varchar (50)  
)*/




--delete from temp_contract_mast where comp_code=@compcode and userid=@userid
/*
set @query='insert into #Temp_Contract_mast  select   Deal_No AS Deal_No
,Comp_code AS Comp_code,
(select agency_name + ''('' + Agency_code + '')'' from agency_mast where agency_mast.Agency_code=contract_mast.agency_code and agency_mast.SUB_Agency_Code=contract_mast.Sub_Agency_Code)as Agency_code
,Sub_Agency_Code,(select Cust_Name + ''(''+Cust_Code+'')'' from cust_mast where cust_mast.Cust_Code=contract_mast.Client_Code) as Client_code,
Product_code,convert(varchar(10),From_date,101) as From_date,convert(varchar(10),Till_date,101) as Till_date,
representative,Userid,getdate(),Total_val,Total_volu,
team_code,deal_type,deal_name, contract_id,Ad_type,REMARKS,
(select Exec_name + ''(''+CAST(Exe_no AS VARCHAR(20))+'')'' 
from exec_mast where Exe_no=EXECUTIVE) as EXECUTIVE, 
(select Retain_Name+''('' + Retain_Code + '')'' from  retainermaster where Retain_Code=RETAINER) as RETAINER
, CONTRACTDATE, CLOSEDATE, SERVICETAX, PAYMENTTYPE, CAPTION,B2B, CHKMULTIAD, SEQNO_ALLOW, 
SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON  from contract_mast 
 where comp_code='''+@compcode+''''
*/
set @query='select   Deal_No AS Deal_No
,Comp_code AS Comp_code,
(select agency_name + ''('' + Agency_code + '')'' from agency_mast where agency_mast.Agency_code=contract_mast.agency_code and agency_mast.SUB_Agency_Code=contract_mast.Sub_Agency_Code)as Agency_code
,Sub_Agency_Code,isnull((select Cust_Name + ''(''+Cust_Code+'')'' from cust_mast where cust_mast.Cust_Code=contract_mast.Client_Code),Client_code) as Client_code,
Product_code,convert(varchar(10),From_date,101) as From_date,convert(varchar(10),Till_date,101) as Till_date,
representative,Userid,getdate(),Total_val,Total_volu,
team_code,deal_type,deal_name, contract_id,Ad_type,REMARKS,
(select Exec_name + ''(''+CAST(Exe_no AS VARCHAR(20))+'')'' 
from exec_mast where Exe_no=EXECUTIVE) as EXECUTIVE, 
(select Retain_Name+''('' + Retain_Code + '')'' from  retainermaster where Retain_Code=RETAINER) as RETAINER
, convert(varchar(10),CONTRACTDATE,101) as CONTRACTDATE, convert(varchar(10),CLOSEDATE,101) as CLOSEDATE, SERVICETAX, PAYMENTTYPE, CAPTION,B2B, CHKMULTIAD, SEQNO_ALLOW, 
SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON,ATTACHMENT, 
(select Pub_Cent_name + ''('' + Pub_cent_Code + '')'' from pub_cent_mast where pub_cent_mast.Pub_cent_Code=contract_mast.DEAL_FROM) AS DEAL_FROM, DEAL_CENTER, TRANSLATION_CHARGES,
RECEIPT_NO, RECEIPT_DATE, RO_STATUS, RO_NO, convert(varchar(10),RO_DATE,101) AS RO_DATE, RCPT_CURRENCY,QUOTATION
 from contract_mast 
 where comp_code='''+@compcode+''''
if(@DealNo <> '')
begin
set @query=@query+'and Deal_No like ''%'+@DealNo+'%'''
end

if(@dealname <> '')
begin
set @query=@query+'and deal_name like ''%'+@dealname+'%'''
end

if(@agencycode <> '0' and @agencycode <>'')
begin
set @query=@query+'and Agency_code like '''+@agencycode+''''
end

if(@dealtype <> '0' and @dealtype <> '')
begin
set @query=@query+'and deal_type like '''+@dealtype+''''
end


if(@subagencycode <>''  and @subagencycode <> '0')
begin
	
	
	set @query=@query+' and Sub_Agency_Code like '''+@subagencycode+''''
	
end

if(@representative <> '0'  and  @representative <>'' ) 
begin
set @query=@query+' and Representative like '''+@representative+''''
end

if(@quotion_p = 'Y'  and  @quotion_p ='y' ) 
begin
set @query=@query+' and QUOTATION like '''+@quotion_p+''''
end

else
begin
set @query=@query+' and QUOTATION  is null ' 
end

print(@query)
exec(@query)
/*
select   Deal_No,Comp_code,Agency_code,Sub_Agency_Code,Client_code,Product_code,
convert(varchar(10),From_date,101) as From_date,convert(varchar(10),Till_date,101) as Till_date,
representative,Userid,Total_val,Total_volu,team_code,deal_type,deal_name,contract_id,Ad_type,REMARKS,EXECUTIVE, RETAINER, CONTRACTDATE, CLOSEDATE, SERVICETAX, PAYMENTTYPE, CAPTION,B2B, CHKMULTIAD, SEQNO_ALLOW, SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON   from #Temp_Contract_mast
*/
drop table #Temp_Contract_mast




*************************************************************************

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go








ALTER PROCEDURE [dbo].[insertcontactmast]
@compcode as varchar(8),
@userid as varchar(8),
@DealNo as varchar(8),
@dealname as varchar(50),
@agencycode as varchar(8),
@subagencycode as varchar(8),
@product as varchar(8),
@validfromdate as datetime,
@validtill as datetime,
@representative as varchar(8),
@clientname as varchar(8),
@totalvalue as float,
@totalvolume as float,
@currencys as varchar(8),
@teamname as varchar(8),
@dealtype as varchar(8),
@adtype as varchar(8),
@remarks as varchar(200),
@executive_var as varchar(20),
@retainer_var as varchar(20),
@contdate_var as datetime,
@closedate_var as datetime,
@servicetax_var as varchar(5),
@caption_var as varchar(500),
@paymode_var as varchar(200),
@b2b_var as varchar(10),
@chkmulti_var as varchar(10),
@chkseq_var as varchar(10),
@seqno_var as varchar(10),
@chkparti_var as varchar(10),
@indus_var as varchar(10),
@induspro_var as varchar(100),
@dealon_var as varchar(20),
@attachment1 as varchar(20),
@dealfrom as varchar(50),
@dealcenter as varchar(50),
@translation as varchar(50),
@rono_p as varchar(50),
@rodate_p as datetime,
@rostatus_p as varchar(50),
@rcptno_p as varchar(50),
@rcptcurr_p as varchar(50),
@quotion_p  as varchar(8)
AS

insert into contract_mast(Deal_No,Comp_code,Agency_code,Sub_Agency_Code,Client_code,Product_code,From_date,Till_date,representative,Userid,Total_val,Total_volu,curr_code,team_code,deal_type,deal_name,Ad_type,REMARKS,EXECUTIVE,RETAINER,CONTRACTDATE, CLOSEDATE, SERVICETAX,PAYMENTTYPE,CAPTION,B2B, CHKMULTIAD, SEQNO_ALLOW, SEQNO, AFT_PRTCLR_AD, INDUSTRY, INDUSTRY_PRODUCT, DEALON,ATTACHMENT,DEAL_FROM, DEAL_CENTER, TRANSLATION_CHARGES, RECEIPT_NO, RECEIPT_DATE, RO_STATUS, RO_NO, RO_DATE, RCPT_CURRENCY,QUOTATION )
values(@DealNo,@compcode,@agencycode,@subagencycode,@clientname,@product,@validfromdate,@validtill,@representative,@userid,@totalvalue,@totalvolume,@currencys,@teamname,@dealtype,@dealname,@adtype,@remarks,@executive_var,@retainer_var,@contdate_var,@closedate_var,@servicetax_var,@paymode_var,@caption_var,@b2b_var,@chkmulti_var,@chkseq_var,@seqno_var,@chkparti_var,@indus_var,@induspro_var,@dealon_var,@attachment1,@dealfrom,@dealcenter,@translation,@rcptno_p,getdate(),@rostatus_p,@rono_p,@rodate_p,@rcptcurr_p,@quotion_p)








///////////////end///avinash==========15-06==2012===================================






//////////start////////shipra//////////////by bhanu sir

CREATE TABLE [dbo].[tbl_booking_insert_Q](
    [insert_id] [int] NOT NULL,
    [cio_booking_id] [varchar](50) NOT NULL,
    [no_insert] [int] NULL,
    [Edition_code] [varchar](8) NOT NULL,
    [Publication_code] [varchar](8) NOT NULL,
    [Pub_cent_code] [varchar](8) NOT NULL,
    [Supp_code] [varchar](8) NOT NULL,
    [Edition] [varchar](500) NOT NULL,
    [Insert_date] [datetime] NULL,
    [Col_code] [varchar](8) NULL,
    [Height] [float] NULL,
    [Width] [float] NULL,
    [Size_book] [float] NULL,
    [Page_post] [varchar](8) NULL,
    [Premium1] [varchar](8) NULL,
    [Prem_per1] [float] NULL,
    [Premium2] [varchar](8) NULL,
    [Prem_per2] [float] NULL,
    [Premium_allow] [varchar](2) NULL,
    [Ad_cat] [varchar](8) NULL,
    [Ad_sub_cat] [varchar](8) NULL,
    [Latest_by] [datetime] NULL,
    [Repeating_date] [datetime] NULL,
    [Status_material] [varchar](8) NULL,
    [File_name] [varchar](100) NULL,
    [Card_rate] [float] NULL,
    [Disc_rate] [float] NULL,
    [Insert_status] [varchar](25) NULL,
    [Bill_status] [varchar](8) NULL,
    [Agreed_rate] [float] NULL,
    [Pai_free_ins] [varchar](2) NULL,
    [Solo_rate] [float] NULL,
    [Gross_rate] [float] NULL,
    [comp_code] [varchar](8) NOT NULL,
    [Userid] [varchar](8) NOT NULL,
    [Page_no] [int] NULL,
    [Remarks] [varchar](500) NULL,
    [Pub_height] [float] NULL,
    [Pub_width] [float] NULL,
    [Page_prem] [varchar](8) NULL,
    [page_per] [float] NULL,
    [No_ofcolumn] [float] NULL,
    [Bill_Amt] [float] NULL,
    [Bill_rate] [float] NULL,
    [Logo_H] [varchar](5) NULL,
    [Logo_W] [varchar](5) NULL,
    [Logo_name] [varchar](100) NULL,
    [AD_SUBCAT3] [varchar](15) NULL,
    [AD_SUBCAT4] [varchar](15) NULL,
    [AD_SUBCAT5] [varchar](15) NULL,
    [PACKAGE_CODE] [varchar](100) NULL,
    [BILL_NO] [varchar](100) NULL,
    [BILL_DATE] [datetime] NULL,
    [INSERTS] [numeric](18, 0) NULL,
    [PKG_ALIAS] [varchar](50) NULL,
    [CONT_GROSS_AMT] [float] NULL,
    [APP_STATUS] [varchar](50) NULL,
    [APP_REMARKS] [varchar](500) NULL,
    [APP_DATE] [datetime] NULL,
    [APP_USER] [varchar](50) NULL,
    [LOCKSTATUS] [varchar](1) NULL,
    [PROOFREAD] [varchar](50) NULL,
    [SPECIAL_SIZE1] [varchar](50) NULL,
    [SPECIAL_SIZE2] [varchar](50) NULL,
    [VATAMT] [float] NULL,
    [BOXCHARGE] [float] NULL,
    [VAT_INC] [varchar](2) NULL,
    [LOCALGROSSAMT] [float] NULL,
    [LOCALBILLAMT] [float] NULL,
    [SECTIONCODE] [varchar](50) NULL,
    [RESOURCE_NO] [varchar](50) NULL,
    [CAPTION] [varchar](500) NULL,
    [DEALER_H] [float] NULL,
    [DEALER_W] [float] NULL,
    [DISCOUNT] [float] NULL,
    [RATE_AUDIT_FLAG] [varchar](1) NULL,
    [RATE_AUDIT_IP] [varchar](20) NULL,
 CONSTRAINT [PK_tbl_booking_insert_Q] PRIMARY KEY CLUSTERED 
(
    [insert_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




CREATE TABLE [dbo].[tbl_booking_mast_Q](
    [date_time] [datetime] NOT NULL,
    [branch] [varchar](25) NOT NULL,
    [booked_by] [varchar](25) NOT NULL,
    [cio_booking_id] [varchar](50) NOT NULL,
    [prev_booking] [varchar](25) NOT NULL,
    [applied_by] [varchar](25) NOT NULL,
    [audit] [varchar](25) NULL,
    [RO_No] [varchar](40) NULL,
    [RO_Date] [datetime] NULL,
    [Caption] [varchar](500) NULL,
    [bill_status] [varchar](8) NOT NULL,
    [ro_status] [varchar](8) NULL,
    [Agency_code] [varchar](15) NULL,
    [Agency_address] [varchar](500) NULL,
    [Client_code] [varchar](100) NULL,
    [Client_address] [varchar](500) NULL,
    [Agency_sub_code] [varchar](20) NULL,
    [Dockit_no] [varchar](25) NULL,
    [Executive_code] [varchar](50) NULL,
    [Executive_zone] [varchar](50) NULL,
    [Product_code] [varchar](50) NULL,
    [Brand_code] [varchar](50) NULL,
    [Key_no] [varchar](50) NULL,
    [Bill_remarks] [varchar](500) NULL,
    [Print_remark] [varchar](500) NULL,
    [Package_code] [varchar](500) NOT NULL,
    [No_of_insertion] [int] NULL,
    [Insertion_date] [datetime] NULL,
    [Repeating_day] [varchar](8) NULL,
    [Ad_type_code] [varchar](8) NULL,
    [Ad_cat_code] [varchar](50) NULL,
    [Ad_sub_cat_code] [varchar](50) NULL,
    [Color_code] [varchar](8) NULL,
    [Uom_code] [varchar](8) NULL,
    [Page_position_code] [varchar](8) NULL,
    [Page_type_code] [varchar](100) NULL,
    [Page_no] [int] NULL,
    [Ad_size_type_code] [varchar](8) NULL,
    [Ad_size_height] [float] NULL,
    [Ad_size_width] [float] NULL,
    [Rate_code] [varchar](100) NULL,
    [Scheme_type_code] [varchar](18) NULL,
    [Currency_code] [varchar](8) NULL,
    [Agrred_rate] [float] NULL,
    [Agreed_amount] [float] NULL,
    [Special_discount] [float] NULL,
    [Space_discount] [float] NULL,
    [Special_charges] [float] NULL,
    [Agency_status] [varchar](15) NULL,
    [Agency_type] [varchar](25) NULL,
    [Agency_pay] [varchar](25) NULL,
    [Agency_credit] [int] NULL,
    [Total_area] [float] NULL,
    [Card_rate] [float] NULL,
    [Card_amount] [float] NULL,
    [Discount] [float] NULL,
    [Discount_per] [float] NULL,
    [Bill_cycle] [varchar](8) NULL,
    [Revenue_center] [varchar](50) NULL,
    [Bill_pay] [varchar](8) NULL,
    [Bill_height] [float] NULL,
    [Bill_width] [float] NULL,
    [Bill_to] [varchar](100) NULL,
    [Invoices] [int] NULL,
    [Vts] [int] NULL,
    [Bill_add] [varchar](500) NULL,
    [Trade_disc] [float] NULL,
    [Agency_out] [varchar](50) NULL,
    [Box_code] [varchar](50) NULL,
    [Box_no] [varchar](8) NULL,
    [Box_agency] [varchar](2) NULL,
    [Box_client] [varchar](2) NULL,
    [Box_address] [varchar](500) NULL,
    [Comp_code] [varchar](8) NOT NULL,
    [Userid] [varchar](8) NOT NULL,
    [Creation_datetime] [datetime] NOT NULL,
    [Booking_type] [varchar](8) NULL,
    [Tfn] [varchar](2) NULL,
    [Coupan_ad] [varchar](2) NULL,
    [Campaign] [varchar](50) NULL,
    [Bill_amount] [float] NULL,
    [Page_prem] [varchar](8) NULL,
    [Page_amount] [float] NULL,
    [Prem_per] [float] NULL,
    [Gross_amount] [float] NULL,
    [Ad_size_column] [float] NULL,
    [Bill_column] [float] NULL,
    [Bill_area] [float] NULL,
    [Special_disc_per] [float] NULL,
    [Space_disc_per] [float] NULL,
    [Paid_ins] [int] NULL,
    [Contract_rate] [float] NULL,
    [Deviation] [float] NULL,
    [Variant_code] [varchar](8) NULL,
    [Contract_name] [varchar](50) NULL,
    [Contract_type] [varchar](50) NULL,
    [Card_name] [varchar](100) NULL,
    [Card_type] [varchar](50) NULL,
    [Card_month] [varchar](8) NULL,
    [Card_year] [varchar](8) NULL,
    [Card_number] [varchar](20) NULL,
    [Receipt_no] [varchar](50) NULL,
    [Ad_Subcat3] [varchar](8) NULL,
    [Ad_Subcat4] [varchar](8) NULL,
    [Ad_subcat5] [varchar](8) NULL,
    [Bg_color] [varchar](8) NULL,
    [Bullet_code] [varchar](8) NULL,
    [Bullet_premium] [float] NULL,
    [Material_status] [varchar](8) NULL,
    [Receipt_date] [datetime] NULL,
    [prev_cioid] [varchar](100) NULL,
    [prev_receipt] [varchar](50) NULL,
    [prev_grossamt] [float] NULL,
    [Region] [varchar](8) NULL,
    [Variant] [varchar](8) NULL,
    [status] [varchar](50) NULL,
    [Colortype] [varchar](8) NULL,
    [Logo_H] [varchar](5) NULL,
    [Logo_W] [varchar](5) NULL,
    [Logo_color] [varchar](8) NULL,
    [Logo_Uom] [varchar](8) NULL,
    [SAPID] [varchar](50) NULL,
    [RETAINER] [varchar](50) NULL,
    [ADD_AGENCY_COMM] [varchar](8) NULL,
    [AUDIT_COMMENT] [varchar](2000) NULL,
    [MOBILENO] [varchar](100) NULL,
    [ADD_AGENCY_COMM_AMT] [varchar](50) NULL,
    [RETAINER_COMM] [varchar](50) NULL,
    [RETAINER_COMM_AMT] [varchar](50) NULL,
    [CASH_RECIEVED] [float] NULL,
    [CONT_GROSS] [float] NULL,
    [CIRAGENCY] [varchar](100) NULL,
    [CIRRATE] [varchar](50) NULL,
    [CIREDITION] [varchar](50) NULL,
    [CIRPUBLICATION] [varchar](50) NULL,
    [CIRAGENCY_SUBCODE] [varchar](50) NULL,
    [BARTER_TYPE] [varchar](50) NULL,
    [APP_STATUS] [varchar](50) NULL,
    [APP_REMARKS] [varchar](500) NULL,
    [APP_DATE] [datetime] NULL,
    [APP_USER] [varchar](50) NULL,
    [RODOCSTATUS] [varchar](25) NULL,
    [RO_COMMENT] [varchar](500) NULL,
    [PROOFREAD] [varchar](50) NULL,
    [CASHDISCOUNT] [float] NULL,
    [CASHDISCTYPE] [varchar](5) NULL,
    [ATTACHMENT1] [varchar](50) NULL,
    [ATTACHMENT2] [varchar](50) NULL,
    [DISC_PREMIUM] [varchar](50) NULL,
    [DOCTYPE] [varchar](20) NULL,
    [CHKTRADEDISC] [varchar](1) NULL,
    [CHK_DATE] [datetime] NULL,
    [CHK_AMT] [float] NULL,
    [CHK_BANK_NAME] [varchar](50) NULL,
    [OUR_BANK] [varchar](50) NULL,
    [CHK_NO] [varchar](50) NULL,
    [DEALERPANEL] [varchar](1) NULL,
    [DEALER_H] [float] NULL,
    [DEALER_W] [float] NULL,
    [DEALERTYPE] [varchar](1) NULL,
    [ACTIVE_AGREEDRATE] [int] NULL,
    [ACTIVE_AGREEDAMT] [int] NULL,
    [temp_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
    [LOCALGROSSAMT] [float] NULL,
    [LOCALBILLAMT] [float] NULL,
    [PACKAGE_TYPE] [varchar](5) NULL,
    [AD_REFID] [varchar](50) NULL,
    [RECEIPT_CURRENCY] [varchar](8) NULL,
    [CONV_CURR_RATE] [varchar](8) NULL,
    [REVISE_DATE] [dbo].[Date] NULL,
    [CLIENT_TYPE] [varchar](5) NULL,
    [TRANSLATION_CODE] [varchar](25) NULL,
    [TRANSLATION_PREMIUM] [float] NULL,
    [MODIFIED_AUDIT] [varchar](5) NULL,
    [CANCELLATION_CHARGE] [varchar](1) NULL,
    [bill_language1] [varchar](50) NULL,
    [bill_page_type] [varchar](50) NULL,
    [RATE_AUDIT_FLAG] [varchar](1) NULL,
    [RATE_AUDIT_IP] [varchar](20) NULL,
    [TRANSLATION_DISC] [varchar](10) NULL,
    [POSPREM_DISC] [varchar](10) NULL,
 CONSTRAINT [PK_tbl_booking_mast_Q] PRIMARY KEY CLUSTERED 
(
    [cio_booking_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


//////////////end//////shipra //////////////////////// bhanu sir/////////////////

===========start==avinash=============21-june-2012=======================================
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER procedure [dbo].[maildeal]
@pcompcode as varchar(8),
@puserid as varchar(8),
@pdeal_no as varchar(10)

as
Begin
select d.INSERTION,isnull((select Col_Name from col_mast where Col_Code=d.color),'')as Color_Name,
m.Deal_Rate,d.cardrate,d.CONTRACT_AMOUNT,m.Total_val

from contract_mast m,contract_detail d where m.Deal_No=@pdeal_no and d.deal_code=@pdeal_no
end

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER procedure [dbo].[mailrateheader]
@pcompcode as varchar(8),
@puserid as varchar(8),
@pdeal_no as varchar(10)

as
Begin
select m.CONTRACTDATE,isnull((select Cust_Name from cust_mast where Cust_Code=m.client_code),m.client_code)
 as Client_Name,isnull((select Agency_Name from agency_mast where code_subcode=m.agency_code+m.sub_agency_code),'') as Agency_Name,
m.REMARKS,(select Phone from agency_mast where code_subcode=m.agency_code+m.sub_agency_code) as Phone,
(select Fax from agency_mast where code_subcode=m.agency_code+m.sub_agency_code) as Fax,
(select EmailID from agency_mast where code_subcode=m.agency_code+m.sub_agency_code) as EmailID

from contract_mast m where m.Deal_No=@pdeal_no
end


===========end==avinash=============21-june-2012=======================================

===start======avinash====by mimoh=====25jun2012==============================================

CREATE  PROCEDURE binndratecode
   
   @p_compcode    as       VARCHAR(10),
   @p_ratecode   as       VARCHAR(50)
   
as


      SELECT distinct "Rate_Mast_Code"
        FROM rate_mast
       WHERE "Comp_code" = @p_compcode
         AND "Rate_Mast_Code" LIKE @p_ratecode + '%'
        

===start======avinash====by mimoh=====25jun2012==============================================

===start======avinash====7854=====26jun2012==============================================

CREATE PROCEDURE websp_rep_material_log
    @pinsdate   datetime,
    @pcenter    varchar(20),
    @pusername  varchar(200),
    @pextra1    varchar(200),
    @pextra2    varchar(200)AS
BEGIN
    
    select username,originalname,sapname,insdate,bkfor,(select "Pub_Cent_name" from pub_cent_mast 
    where "Pub_cent_Code"=allthumbimage_log.bkfor) bkfor_name, upd_datetime from allthumbimage_log
    where insdate=@pinsdate and (bkfor=isnull(@pcenter,bkfor) or @pcenter='') and (username=@pusername or @pusername is null or @pusername='')
    order by originalname;
    
END
===end======avinash====7854=====26jun2012==============================================

======================updated by dimple=====issue no 7799==============================

                                                                     
                                                                     
                                                                     
                                             
CREATE procedure login_user_report 
@pcomp_code      as  varchar(200),
@pbranch         as  varchar(200),
@pusername       as  varchar(200),
@proleid         as  varchar(200),
@pstatus         as  varchar(200),
@pdateformat     as  varchar(200),
@pextra1         as  varchar(200),
@pextra2         as  varchar(200),
@pextra3         as  varchar(200),
@pextra4         as  varchar(200),
@pextra5         as  varchar(200) as
Begin

     select "userid" userid,"username" username,firstname, lastname,
    "Agency_code",(select "Agency_Name" from agency_mast where "code_subcode"=login."Agency_code") agency_name,
    "retainer_code" branch,(select "Branch_Name" from branch_mst where "Branch_Code"=login."retainer_code") branch_name, 
    (select "Comp_Name" from comp_mst where "Comp_Code"=login.com_code) comp_name,email, discount,roleid,null as rolename,  
    case when "Admin"='Yes' then 'ADMIN' else 'USER' end login_type,  case when filter='D' then 'District Wise' 
    when filter='P' then 'Publ Center Wise' else 'All' end filter_type, 
    booking_editlines,  case when status='A' then 'Active' else 'Inactive' end status,  
    hr_code,(select distinct name from hr_emp_mst where hr_code=login.hr_code),
    acc_code,(select acc_name from fa_acc_mast where comp_code=login.com_code and cdp=login.acc_code) acc_name,
    null as branch_permission 
    from login where ("username" like @pusername+'%' or @pusername='') and 
    ("retainer_code"=isnull(@pbranch,"retainer_code") or @pbranch='') and 
    (roleid=isnull(@proleid,roleid) or @proleid='') and 
    (status=isnull(@pstatus,status) or @pstatus='') order by username;
    
End

==================================end ======== issue no 7799===========================
