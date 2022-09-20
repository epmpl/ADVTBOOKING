=====avinash====by mimoh========================04jun2012=============

CREATE OR REPLACE PACKAGE bindaudit
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE bindaudit_p (
      fromdate         IN       VARCHAR2,
      todate           IN       VARCHAR2,
      date1            IN       VARCHAR2,
      branch1          IN       VARCHAR2,
      adtype           IN       VARCHAR2,
      audittype        IN       VARCHAR2,
      branch2          IN       VARCHAR2,
      v_cat            IN       VARCHAR2,
      v_userid         IN       VARCHAR2,
      comp_code        IN       VARCHAR2,
      v_package_code   IN       VARCHAR2,
      pagency_code     IN       VARCHAR2,
      pclient_code     IN       VARCHAR2,
      psection_code    IN       VARCHAR2,
      p_booktype       IN       VARCHAR2,
      extra1           IN       VARCHAR2,
      extra2           IN       VARCHAR2,
      extra3           IN       VARCHAR2,
      extra4           IN       VARCHAR2,
      p_account        OUT      t_account_cursor
   );
END bindaudit;
/


/***************************************************************************/


CREATE OR REPLACE PACKAGE BODY bindaudit
IS
   PROCEDURE bindaudit_p (
      fromdate         IN       VARCHAR2,
      todate           IN       VARCHAR2,
      date1            IN       VARCHAR2,
      branch1          IN       VARCHAR2,
      adtype           IN       VARCHAR2,
      audittype        IN       VARCHAR2,
      branch2          IN       VARCHAR2,
      v_cat            IN       VARCHAR2,
      v_userid         IN       VARCHAR2,
      comp_code        IN       VARCHAR2,
      v_package_code   IN       VARCHAR2,
      pagency_code     IN       VARCHAR2,
      pclient_code     IN       VARCHAR2,
      psection_code    IN       VARCHAR2,
      p_booktype       IN       VARCHAR2,
                                 --A for all ,D for Direct ,Q for Qbc Booking
      extra1           IN       VARCHAR2,                           --for UOM
      extra2           IN       VARCHAR2,
                   --for Date based on ,B for Booking Date,P for Publish date
      extra3           IN       VARCHAR2,
      extra4           IN       VARCHAR2,
      p_account        OUT      t_account_cursor
   )
   AS
      v_branch1        VARCHAR2 (50);
      v_branch2        VARCHAR2 (50);
      v_approval_req   VARCHAR2 (1);
      v_query          VARCHAR2 (20000);
      v_wherecl        VARCHAR2 (5000);
      v_query_group    VARCHAR2 (5000);
   BEGIN
      --INSERT INTO test1(vstring)VALUES (   'fromdate '|| fromdate|| ' todate '|| todate|| ' date1 '|| date1|| ' BRANCH1 '|| branch1|| ' Adtype '|| adtype|| ' audittype '|| audittype|| ' branch2 '|| branch2|| ' v_Cat '|| v_cat|| ' v_userid '|| v_userid);COMMIT;
      IF branch1 = 'All'
      THEN
         v_branch1 := NULL;
      ELSE
         v_branch1 := branch1;
      END IF;

      IF branch2 = 'All'
      THEN
         v_branch2 := NULL;
      ELSE
         v_branch2 := branch2;
      END IF;

      v_approval_req := 'N';

      SELECT relauthreqon
        INTO v_approval_req
        FROM preferrences
       WHERE "comp_code" = comp_code;

      v_query :=
            'SELECT distinct m."cio_booking_id" as "cio_booking_id",
        NVL ((SELECT distinct  "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),
        m."Client_code") AS "Client_code",
        m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",m."Receipt_no" as "Receipt_no",
        (SELECT distinct "File_Name" FROM tbl_booking_insert
        WHERE "Cio_Booking_Id" =m."cio_booking_id" AND "File_Name" IS NOT NULL AND ROWNUM <= 1) AS "FILENAME",
        CASE '''
         || date1
         || ''' WHEN ''mm/dd/yyyy'' THEN TO_CHAR(m."Creation_datetime",''mm/dd/yyyy'')
            WHEN ''dd/mm/yyyy'' THEN TO_CHAR (m."Creation_datetime", ''dd/mm/yyyy'')
            WHEN ''yyyy/mm/dd'' THEN TO_CHAR (m."Creation_datetime", ''yyyy/mm/dd'')
        END AS "Creation_datetime",m.ATTACHMENT1 as ATTACHMENT,
        AD_GETAGENCY_ADD('''
         || comp_code
         || ''',m."cio_booking_id",''A'') as "Agency_Remark",
        AD_GETAGENCY_ADD('''
         || comp_code
         || ''',m."cio_booking_id",''C'') as "Client_Remark",
        case when '''
         || v_approval_req
         || '''=''N'' then ''Y'' else 
        case when nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)=0 then ''Y'' else nvl(m.app_status,''N'') end 
        end as "APPROVAL_FLAG",TO_CHAR(min(i."Insert_Date"),'''
         || date1
         || ''') as "INSERT_DATE",min(i."Insert_Date") dd
        FROM tbl_booking_mast m,tbl_booking_insert i,branch_mst b,login_branch_mast lb
        WHERE m."cio_booking_id" =i."Cio_Booking_Id" AND m."Ad_type_code" = '''
         || adtype
         || '''
        AND m."branch"= b."Branch_Code" and m."branch"= lb.branch_code AND NVL (lb.user_flag, ''N'') = ''Y''';

      IF pagency_code IS NOT NULL
      THEN
         v_wherecl :=
            v_wherecl || ' and m."Agency_sub_code"= ''' || pagency_code
            || '''';
      END IF;

      IF v_branch2 IS NOT NULL
      THEN
         v_wherecl := v_wherecl || ' and m."branch"= ''' || v_branch2 || '''';
      END IF;

      IF pclient_code IS NOT NULL
      THEN
         v_wherecl :=
              v_wherecl || ' and m."Client_code"= ''' || pclient_code || '''';
      END IF;

      IF pclient_code IS NOT NULL
      THEN
         v_wherecl :=
              v_wherecl || ' and m."Client_code"= ''' || pclient_code || '''';
      END IF;

      IF audittype = 'audit' OR (audittype = 'unaudit' OR audittype IS NULL)
      THEN
         IF extra2 = 'P'
         THEN
            v_wherecl :=
                  v_wherecl
               || ' and i."Insert_Date" BETWEEN '''
               || fromdate
               || ''' AND '''
               || todate
               || '''';
         ELSE
            v_wherecl :=
                  v_wherecl
               || ' and m."date_time" BETWEEN '''
               || fromdate
               || ''' AND '''
               || todate
               || '''';
         END IF;
      END IF;

      IF v_cat IS NOT NULL
      THEN
         v_wherecl :=
                     v_wherecl || ' and m."Ad_cat_code"= ''' || v_cat || '''';
      END IF;

      IF v_userid IS NOT NULL
      THEN
         v_wherecl :=
                     v_wherecl || ' and lb.user_code= ''' || v_userid || '''';
      END IF;

      IF v_branch1 IS NOT NULL
      THEN
         v_wherecl :=
                  v_wherecl || ' and b."pub_center"= ''' || v_branch1 || '''';
      END IF;

      IF v_package_code IS NOT NULL
      THEN
         v_wherecl :=
            v_wherecl || ' and i."PACKAGE_CODE"= ''' || v_package_code
            || '''';
      END IF;

      IF psection_code IS NOT NULL
      THEN
         v_wherecl :=
             v_wherecl || ' and i."SECTIONCODE"= ''' || psection_code || '''';
      END IF;

      IF extra1 IS NOT NULL
      THEN
         v_wherecl := v_wherecl || ' and m."Uom_code"= ''' || extra1 || '''';
      END IF;

      IF p_booktype IS NOT NULL
      THEN
         v_wherecl :=
               v_wherecl
            || ' and exists (select "userid" from login where "userid"=m."Userid" and
                                    ((nvl("Agency_code",''0'')<>''0'' and nvl('''
            || p_booktype
            || ''',''A'') =''Q'') or
                   (nvl("Agency_code",''0'')=''0'' and nvl('''
            || p_booktype
            || ''',''A'') =''D'') or nvl('''
            || p_booktype
            || ''',''A'') =''A''))';
      END IF;

      IF audittype = 'audit'
      THEN
         IF extra1 IS NOT NULL
         THEN
            v_wherecl := v_wherecl || ' AND m."audit" IS NOT NULL';
         END IF;
      END IF;

      IF audittype = 'unaudit' OR audittype IS NULL
      THEN
         v_wherecl :=
               v_wherecl
            || ' AND m."audit" IS NULL AND m."ro_status"=''1'' and nvl(m.modified_audit,''N'')!=''Y''';
      END IF;

      IF audittype = 'modified'
      THEN
         v_wherecl :=
               v_wherecl
            || ' AND m."audit" IS NULL AND m."ro_status"=''1'' and nvl(m.modified_audit,''N'')=''Y''';
      END IF;

      /*IF audittype = 'unaudit' or audittype is null THEN
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
              --and m."date_time" BETWEEN fromdate AND todate
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
      END IF;*/
      v_query_group :=
         ' group by m."cio_booking_id" ,m."Client_code",m."audit", m."Ad_type_code",m."Receipt_no",
            m."Creation_datetime",m.ATTACHMENT1,nvl(m."Discount_per",0),nvl(m."Special_disc_per",0),m.app_status 
            order by dd,"cio_booking_id"';

      DELETE FROM test1;

      INSERT INTO test1
                  (vstring, vstring2
                  )
           VALUES ('bindaudit ', v_query || v_wherecl || v_query_group
                  );

      COMMIT;

      OPEN p_account FOR v_query || v_wherecl || v_query_group;
   END bindaudit_p;
END bindaudit;
/
=====avinash====by mimoh========================04jun2012=============



///////////////issue no 7702/////////////////


CREATE OR REPLACE PACKAGE HT18JULY.Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/




CREATE OR REPLACE PACKAGE BODY HT18JULY.currbindpreferpgld
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
                "Receipt_no", "uom_code", "Bgcolor_publication",
                "chkfor_valid_pubdates", "Agency_ratecode", "audit",
                "book_insert_date", "agencycomm", "rate_audit", "bill_audit",
                "billtype", "Premium_type", "copy_booking",
                "RATE_COMPANY_AGENCY", "ADDITIONAL_AGENCY_COMM",
                "AGENCY_RETAINER_COMM", "SUBEDITIONRATE", cls_billtype,
                dis_billtype, "BILLING_FORMAT", "RATE_CHECK", "ALL_PACKAGE",
                dayrate, scheme_type, disp_clsbill, receipt_format,
                cash_receipt_bill, bill_orderwslast, floor_chk, rokeycheck,
                agencycomm_seq_com, credit_recipt, disp_cashbill,
                cla_cashbill, rate_audit_pref, barcoding_allowed,
                fmg_bill_dis, bill_disp_cashbill, bill_cla_cashbill,
                backdatereceipt, rowise_cashbooking, cutofftime,
                dockit_booking, approval, back_days, cash_discount,
                cash_discounttype, "Allowed_old_date", seprate_cashier,
                cir_many_time_posting, cir_backdays_posting,
                cir_max_return_allow, cir_return_limit_allow,
                cir_no_of_chqbounce, cir_days_chqbounce, cir_return_days,
                cir_sup_order_limit, disp_billing_criteria,
                clsd_billing_criteria, max_publishdays, billno_periodicity,
                specialdisc_trans_edit, sharing_trans,
                multipackage_sel_trans, scheme_minword, trade_splcharge,
                rate_authorization, f2_record, publishad_edit_rateaudit,
                bindrevenue_center, fa_ledger_allow, clearance_type_allow,
                repeat_day_type, premium_edit, bill_generation_prior,
                publication_ho, spldisc_allowprem, bill_scheme,
                allowed_pdc_days_receipt, ad_type_manul_bill,
                outstanding_amt_criteria AS ro_outstand, genrate_cir_agcd,
                disp_auditbkg, cir_dis_auto_posting, relauthreqon,
                cir_auto_approval_unsold, cir_auto_physical_unsold,
                cir_unsold_include_inct, cir_unsold_include_insfee,
                cir_unsold_on_received_dt, agency_unblock_approval,
                unblock_approval_outside_limit, cir_bill_publwise,
                records_on_page, records_on_print, header_on_page,
                agency_required, region_required, allow_follow_dt_boook,
                crm_supply_type_paid, crm_supply_type_free,
                currency_measurement, "Space_area", editable_agency_comm,
                cancellation_charge, taxi_entry_type, approval_with,
                tds_auto_cn, tds_auto_reason, tds_db_cdp, tds_cr_cdp,
                ser_tax_auto_cn, ser_tax_auto_reason, ser_tax_db_cdp,
                ser_tax_cr_cdp, pkk_auto_cn, pkk_auto_reason, pkk_db_cdp,
                pkk_cr_cdp, bank_chg_auto_cn, bank_chg_auto_reason,
                bank_chg_db_cdp, bank_chg_cr_cdp, cir_barcode,
                cir_wieght_calc_req, gen_rct_typ, product_brand_req, ALLOWPREM_CARD_DISC_RATE
           FROM preferrences
          WHERE "comp_code" = compcode;
   END currbindpreferpgld_p;
END currbindpreferpgld;
/


////////////////issue no 7702///////////////






////////////shipra ///////////// done by mimoh sir//////////////




CREATE OR REPLACE PACKAGE BODY rptest.websp_getExec is
procedure websp_getExec_p(
compcode    in varchar2,
execname    in varchar2,
value       in varchar2,
center      in varchar2,
P_Accounts  out T_Accounts_Cursor)as
begin
    if center is not null and center!='0' then
        if(value <> '3')then
            open P_Accounts for
            select "Exe_no" as "exe_no","Exec_name"||','||(select "City_Name" from city_mst where "City_Code"=exec_mast."city_code") as "exec_name" 
            from exec_mast where "comp_code"=compcode and  "Exec_name" like '%' || upper(execname)||'%'
                and "dist_code"=(select "Dist_Code" from branch_mst where "Branch_Code"=center) and "exe_status"='Active' order by "Exec_name";
        end if;
        if(value='3') then
            open P_Accounts for
            select "Exe_no" as "exe_no","Exec_name"||','||(select "City_Name" from city_mst where "City_Code"=exec_mast."city_code") as "exec_name" 
            from exec_mast where "comp_code"=compcode and "Exe_no"=execname and "exe_status"='Active' order by "Exec_name";
        end if;
    else
        if(value <> '3')then
            open P_Accounts for
            select "Exe_no" as "exe_no","Exec_name"||','||(select "City_Name" from city_mst where "City_Code"=exec_mast."city_code") as "exec_name" 
            from exec_mast where "comp_code"=compcode and  "Exec_name" like '%' || upper(execname)||'%' and "exe_status"='Active'
            order by "Exec_name";
        end if;
        if(value='3') then
            open P_Accounts for
            select "Exe_no" as "exe_no","Exec_name"||','||(select "City_Name" from city_mst where "City_Code"=exec_mast."city_code") as "exec_name" 
            from exec_mast where "comp_code"=compcode and "Exe_no"=execname and "exe_status"='Active' order by "Exec_name";
        end if;
    end if;
end websp_getExec_p;
end websp_getExec;
/







CREATE OR REPLACE PACKAGE BODY GETRETAINER IS
PROCEDURE GETRETAINER_p(
    COMPCODE1   IN  VARCHAR2,
    PUBCENTER   IN  VARCHAR2,
    center in varchar2,
    p_accounts  out t_accounts_cursor)
    AS
BEGIN
       
    -- SELECT "Retain_Name","Retain_Code" FROM RETAINERMASTER WHERE "Comp_Code"=COMPCODE1;-- AND "pubcent_code"=PUBCENTER;
    if center ='0' or center is null then
        OPEN p_accounts for
        SELECT "Retain_Name"||','||(select "City_Name" from city_mst where "City_Code"=retainermaster."City_Code") as "Retain_Name","Retain_Code" FROM RETAINERMASTER 
        WHERE "Comp_Code"=COMPCODE1 AND "Retain_Name" LIKE  '%'|| upper(PUBCENTER) ||'%'
        and (SELECT  "Status_Name" FROM TBLSTATUS WHERE "Status_Code" =(select STATUS_NAME from ret_status_detail where
        "Retain_Code"=RETAINERMASTER."Retain_Code" and rownum <=1 AND sysdate between "FROM_DATE" and "TO_DATE"))='ACTIVE'
        ORDER BY "Retain_Name";
    else
        OPEN p_accounts for
        SELECT "Retain_Name"||','||(select "City_Name" from city_mst where "City_Code"=retainermaster."City_Code") as "Retain_Name","Retain_Code" FROM RETAINERMASTER 
        WHERE "Comp_Code"=COMPCODE1 AND "Retain_Name" LIKE  '%'|| upper(PUBCENTER) ||'%'
        and "Dist_Code"=(select "Dist_Code" from branch_mst where "Branch_Code"=center)  and (SELECT  "Status_Name" FROM TBLSTATUS WHERE "Status_Code" =(select STATUS_NAME from ret_status_detail where
        "Retain_Code"=RETAINERMASTER."Retain_Code" and rownum <=1 AND sysdate between "FROM_DATE" and "TO_DATE"))='ACTIVE'
        ORDER BY "Retain_Name";-- AND "pubcent_code"=PUBCENTER;
    end if;
      
END GETRETAINER_p;
END GETRETAINER;
/











CREATE OR REPLACE procedure emp_code_bind (
    pcomp_code  in       varchar2,                 
    pname       in       varchar2,
    pextra1     in       varchar2,
    pextra2     in       varchar2,
    pextra3     in       varchar2,
    pextra4     in       varchar2,
    p_accounts  out      cur_type_new1.cursor_type,
    p_accounts1 out      cur_type_new1.cursor_type,
    p_accounts2 out      cur_type_new1.cursor_type,
    p_accounts3 out      cur_type_new1.cursor_type)
is
begin
    open p_accounts for     
    select emp_code as "EMP_CODE",name as "NAME",addr1 as "ADDR1",addr2 as "ADDR2",addr3 as "ADDR3",pin as "PIN",
    father_name as "FATHER_NAME",last_name as "LAST_NAME",
    (select dept from hr_dept_mast where dept_code=hr_emp_mst.deptcode) "DEPT_NAME",email as "EMAIL",
    phone as "PHONE",mobile as "MOBILE",bran_code as "BRAN_CODE",
    (select "Branch_Name" from branch_mst where "Branch_Code"=hr_emp_mst.bran_code) as "BRANCH_NAME"
    from hr_emp_mst where comp_cd=pcomp_code 
    and ( upper(name) like upper(pname)||'%' or pname is null) order by "NAME";
         
    open p_accounts1 for 
    select 'a' as "A" from dual;
         
    open p_accounts2 for 
    select 'a'  as "A" from dual;
    open p_accounts3 for 
    select 'a' as "A" from dual;
     
end emp_code_bind;
/








create or replace procedure cir_rep_datewise_po_summ(
     pcomp_code     in varchar2,
     punit_code     in varchar2,
     ppubl          in varchar2,
     pfromdate      in varchar2,
     ptilldate      in varchar2,
     pdateformat    in varchar2,
     preptype       in varchar2,--1 for supply type wise 2 for edition wise
     pextra1        in varchar2,
     pextra2        in varchar2,
     pextra3        in varchar2,
     pextra4        in varchar2,
     pextra5        in varchar2,
     p_accounts     OUT Cur_Type_New1.cursor_type,
     p_accounts1    OUT Cur_Type_New1.cursor_type) as

v_date             date;
v_date1            date;
    
    cursor cur_dbk is
            select x.comp_code comp_code,x.unit_code unit_code,x.supdate supdate,x.publ_name publ_name,
            x.sup_ty_name sup_ty_name,x.sup_seqno sup_seqno,x.supply_copy supply_copy 
            from
            (select d.comp_code comp_code,d.unit_code unit_code,d.supdate supdate,p.publ_name publ_name,
            t.sup_ty_name sup_ty_name,t.sup_seq_no sup_seqno,sum(d.sup_copy) supply_copy
            from cir_dbksup d,cir_edtn_mast e,cir_publ_mast p,cir_supply_type_mast t
            where d.comp_code=e.comp_code and d.comp_code=p.comp_code 
            and d.comp_code=t.comp_code and d.comp_code=pcomp_code and
            d.unit_code=e.unit_code and d.unit_code=nvl(punit_code,d.unit_code) and d.publ=p.publ 
            and d.publ=e.publ and d.publ=nvl(ppubl,d.publ) and 
            d.edtn=e.edtn and d.supdate between v_date and v_date1 and d.sup_type_code=t.sup_ty_code and 
            nvl(preptype,'1')='1'
            group by d.comp_code,d.unit_code,d.supdate,p.publ_name,t.sup_ty_name,t.sup_seq_no
            union
            select d.comp_code comp_code,d.unit_code unit_code,d.supdate supdate,p.publ_name publ_name,
            e.edtn sup_ty_name,e.edtn_seq_no sup_seqno,sum(d.sup_copy) supply_copy
            from cir_dbksup d,cir_edtn_mast e,cir_publ_mast p,cir_supply_type_mast t
            where d.comp_code=e.comp_code and d.comp_code=p.comp_code 
            and d.comp_code=t.comp_code and d.comp_code=pcomp_code and
            d.unit_code=e.unit_code and d.unit_code=nvl(punit_code,d.unit_code) and d.publ=p.publ 
            and d.publ=e.publ and d.publ=nvl(ppubl,d.publ) and 
            d.edtn=e.edtn and d.supdate between v_date and v_date1 and d.sup_type_code=t.sup_ty_code and
            nvl(preptype,'1')='2' 
            group by d.comp_code,d.unit_code,d.supdate,p.publ_name,e.edtn,e.edtn_seq_no)x;
        rec_dbk cur_dbk%rowtype;

     cursor cur_sup_type is
        select distinct rec_amt sup_seq_no,agname supply_type_name
            from cir_temp_bill_collection
            where cur_sessionid=userenv('sessionid') 
        order by rec_amt,agname;
     rec_sup_type cur_sup_type%rowtype;


    vvar        varchar2(4000);
    vvar_sum    varchar2(4000);
    vquery      varchar2(8000);
    v_count     number(5);
Begin
    
    v_date  :=to_date(pfromdate,''''||pdateformat||'''');
    v_date1 :=to_date(ptilldate,''''||pdateformat||'''');
        
    delete from cir_temp_bill_collection where cur_sessionid=userenv('sessionid');

    --delete from test1;commit;insert into test1(vstring,vstring2) values(' date ',pfromdate||','||ptilldate);
    
    open cur_dbk;
    loop
        fetch cur_dbk into rec_dbk;
        exit when cur_dbk%notfound;

        insert into cir_temp_bill_collection
        (comp_code, unit_code, billdt, publ_code, supply_copy, gross_amt, 
        cur_sessionid, agname)
        values
        (rec_dbk.comp_code,rec_dbk.unit_code,rec_dbk.supdate,rec_dbk.publ_name,rec_dbk.supply_copy,NULL,
        userenv('sessionid'),rec_dbk.sup_ty_name);
    end loop;
    close cur_dbk;
    
    open cur_sup_type;
    loop
        fetch cur_sup_type into rec_sup_type;
        exit when cur_sup_type%notfound;
        if vvar is null then
            vvar       :='case when d.agname='||''''||rec_sup_type.supply_type_name||''''||' then d.supply_copy else 0 end "'||rec_sup_type.supply_type_name||'"';
            vvar_sum   :='sum("'||rec_sup_type.supply_type_name||'")'||' "'||rec_sup_type.supply_type_name||'"';
        else
            vvar       :=vvar||','||'case when d.agname='||''''||rec_sup_type.supply_type_name||''''||' then d.supply_copy else 0 end "'||rec_sup_type.supply_type_name||'"';
            vvar_sum   :=vvar_sum||','||'sum("'||rec_sup_type.supply_type_name||'")'||' "'||rec_sup_type.supply_type_name||'"';
        end if;            
    end loop;
    close cur_sup_type;

    if vvar is null then            
        vquery:=' select x.comp_code comp_code,x.unit_code unit_code,x.publ publ,x.publ_name publ_name,
                x.supdate supdate, sum(x.supply_copy) TOTAL
                from
                (select d.comp_code comp_code,d.unit_code unit_code,d.publ_code publ,d.publ_code publ_name,
                to_char(d.billdt'||','||''''||pdateformat||''''||') supdate,d.supply_copy supply_copy 
                from cir_temp_bill_collection d
                where d.cur_sessionid=userenv(''sessionid'')) x  group by x.comp_code,x.unit_code,x.publ,x.publ_name,x.supdate
                order by comp_code,unit_code,supdate,publ_name';
    else
        vquery:=' select x.comp_code comp_code,x.unit_code unit_code,x.publ publ,x.publ_name publ_name,
                x.supdate supdate,'||vvar_sum||', sum(x.supply_copy) TOTAL
                from
                (select d.comp_code comp_code,d.unit_code unit_code,d.publ_code publ,d.publ_code publ_name,
                to_char(d.billdt'||','||''''||pdateformat||''''||') supdate,'||vvar||',d.supply_copy supply_copy
                from cir_temp_bill_collection d
                where d.cur_sessionid=userenv(''sessionid'')) x  group by x.comp_code,x.unit_code,x.publ,x.publ_name,x.supdate
                order by comp_code,unit_code,supdate,publ_name';
    end if;                    
    --insert into test1(vstring) values ('1 pextra1 '||vquery);commit;

    open p_accounts for vquery;
    if vvar is null then
        vquery:=' select x.comp_code comp_code,x.unit_code unit_code,x.publ publ,x.publ_name publ_name,sum(x.supply_copy) TOTAL from
                (select d.comp_code comp_code,d.unit_code unit_code,d.publ_code publ,d.publ_code publ_name,
                to_char(d.billdt'||','||''''||pdateformat||''''||') supdate,d.supply_copy supply_copy from cir_temp_bill_collection d
                where d.cur_sessionid=userenv(''sessionid'')) x group by x.comp_code,x.unit_code,x.publ,x.publ_name
                order by comp_code,unit_code,publ_name';                
    else
        vquery:=' select x.comp_code comp_code,x.unit_code unit_code,x.publ publ,x.publ_name publ_name,
                '||vvar_sum||', sum(x.supply_copy) TOTAL from
                (select d.comp_code comp_code,d.unit_code unit_code,d.publ_code publ,d.publ_code publ_name,
                to_char(d.billdt'||','||''''||pdateformat||''''||') supdate,'||vvar||',d.supply_copy supply_copy from cir_temp_bill_collection d
                where d.cur_sessionid=userenv(''sessionid'')) x group by x.comp_code,x.unit_code,x.publ,x.publ_name
                order by comp_code,unit_code,publ_name';    
    end if;
    --insert into test1(vstring) values ('2 pextra1 '||vquery);commit;
    
    delete from cir_temp_bill_collection where cur_sessionid=userenv('sessionid');

    open p_accounts1 for vquery;    
End cir_rep_datewise_po_summ;
/










/////////////end by shipra/////////// mimoh sir///////////////////////






////shipra .........done by mimoh sir
CREATE OR REPLACE PROCEDURE getdata_export (
   adtype_p        IN       VARCHAR2,
   fromdate_p      IN       VARCHAR2,
   todate_p        IN       VARCHAR2,
   p_solo          IN       VARCHAR2,
   p_ratecode      IN       VARCHAR2,
   p_pubcent       IN       VARCHAR2,
   pedtn_flag      IN       VARCHAR2,
                    --M for Main,E for Edition ,S for Suppliment and A for All
   p_packagecode   IN       VARCHAR2,
   padcatg         IN       VARCHAR2,
   puom_code       IN       VARCHAR2,
   pextra1         IN       VARCHAR2,
   pextra2         IN       VARCHAR2,
   pextra3         IN       VARCHAR2,
   pextra4         IN       VARCHAR2,
   pextra5         IN       VARCHAR2,
   p_accounts      OUT      cur_type_new1.cursor_type
)
IS
   v_gr   NUMBER (5);
BEGIN
   v_gr := fn_splitfield (p_packagecode, ',');
   v_gr := fn_splitfield1 (padcatg, ',');

   IF NVL (p_solo, '') = 'S'
   THEN
      OPEN p_accounts FOR
         SELECT   x."rateuniqueid", x."pub_center", x."Adv_Cat_Code",
                  x."Adv_subcat_code", x."Ad_Subcat4", x."Ad_Subcat5",
                  x."Ad_subcat6", x."Premium", x."Scheme_Name",
                  x."Comp_code", x."Rate_Mast_Code", x."Adv_Type_Code",
                  x."Rate_Gr_Code", x."Currency", x."combin_desc",
                  x."Combin_Code", x."Uom", x."Size_To", x."Size_From",
                  x."consumption_Per", x."Color", x."Col_chr_typ",
                  x."Remarks", x.valid_from AS valid_from,
                  x.valid_to AS valid_to, x."Package_Name" AS "Package_Name",
                  x."Adv_Cat_Name" AS "Adv_Cat_Name",
                  x."Adv_Subcat_Name" AS "Adv_Subcat_Name",
                  x."Uom_Name" AS "Uom_Name", x."Week_Day_Rate",
                  x."Week_min_rate", x."Week_Extra_Rate", x."Focus_Day_Rate",
                  x."Focus_min_rate", x."Focus_extra_rate", x."userid",
                  x."Creation_DateTime", x."Premium_Charges",
                  x."weekend_rate", x."weekend_min_rate", x."weekend_extra",
                  x."chksolo", x."min_ad_area", x."Edition_from",
                  x."Edition_to", x."floor_amount", x."floor_discount",
                  x."From_insertion", x."To_insertion", x."Agency_type",
                  x."Client_cat", x."Max_Area", x.sun_rate, x.mon_rate,
                  x.tue_rate, x.wed_rate, x.thu_rate, x.fri_rate, x.sat_rate,
                  x.sun_rate_extra, x.mon_rate_extra, x.tue_rate_extra,
                  x.wed_rate_extra, x.thu_rate_extra, x.fri_rate_extra,
                  x.sat_rate_extra, x.maxwidth, x.priority, x.vat_detail,
                  x.adon, x.ref_id, x.cancellation_charges,
                  x."ratemastid" "ratemastid", x."id" "id",
                  x."rate_code" AS "rate_code"
             FROM (SELECT r."rateuniqueid", r."pub_center", r."Adv_Cat_Code",
                          r."Adv_subcat_code", r."Ad_Subcat4", r."Ad_Subcat5",
                          r."Ad_subcat6", r."Premium", r."Scheme_Name",
                          r."Comp_code", r."Rate_Mast_Code",
                          r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",
                          r."combin_desc", r."Combin_Code", r."Uom",
                          r."Size_To", r."Size_From", r."consumption_Per",
                          r."Color", r."Col_chr_typ", r."Remarks",
                          TO_CHAR (r."Valid_From",
                                   'mm/dd/yyyy') AS valid_from,
                          TO_CHAR (r."Valid_To", 'mm/dd/yyyy') AS valid_to,
                          (SELECT "Package_Name"
                             FROM combin_mast
                            WHERE combin_mast."Combin_Code" =
                                            r."Combin_Code"
                              AND combin_mast."Comp_Code" = r."Comp_code")
                                                            AS "Package_Name",
                          (SELECT "Adv_Cat_Name"
                             FROM adv_cat_mast
                            WHERE adv_cat_mast."Adv_Cat_Code" =
                                           r."Adv_Cat_Code"
                              AND adv_cat_mast."Comp_Code" = r."Comp_code")
                                                            AS "Adv_Cat_Name",
                          (SELECT "Adv_Subcat_Name"
                             FROM adv_subcat_mast
                            WHERE adv_subcat_mast."Adv_Subcat_Code" =
                                     r."Adv_subcat_code"
                              AND adv_subcat_mast."Comp_Code" = r."Comp_code")
                                                         AS "Adv_Subcat_Name",
                          (SELECT "Uom_Name"
                             FROM uom_mast
                            WHERE uom_mast."Uom_Code" = r."Uom"
                              AND uom_mast."Comp_Code" = r."Comp_code")
                                                                AS "Uom_Name",
                          r."Week_Day_Rate", r."Week_min_rate",
                          r."Week_Extra_Rate", r."Focus_Day_Rate",
                          r."Focus_min_rate", r."Focus_extra_rate",
                          r."userid", r."Creation_DateTime",
                          r."Premium_Charges", r."weekend_rate",
                          r."weekend_min_rate", r."weekend_extra",
                          r."chksolo", r."min_ad_area", r."Edition_from",
                          r."Edition_to", r."floor_amount",
                          r."floor_discount", r."From_insertion",
                          r."To_insertion", r."Agency_type", r."Client_cat",
                          r."Max_Area", r.sun_rate, r.mon_rate, r.tue_rate,
                          r.wed_rate, r.thu_rate, r.fri_rate, r.sat_rate,
                          r.sun_rate_extra, r.mon_rate_extra,
                          r.tue_rate_extra, r.wed_rate_extra,
                          r.thu_rate_extra, r.fri_rate_extra,
                          r.sat_rate_extra, r.maxwidth, r.priority,
                          r.vat_detail, r.adon, r.ref_id,
                          r.cancellation_charges, '' "ratemastid", '' "id",
                          "Rate_Mast_Code" AS "rate_code"
                     --,'' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
                   FROM   rate_mast r
                    WHERE "Adv_Type_Code" = adtype_p
                      AND "Valid_From" >= fromdate_p
                      AND "Valid_To" <= todate_p
                      AND INSTR ("combin_desc", '+') <= 0
                      AND r."Rate_Mast_Code" =
                                          NVL (p_ratecode, r."Rate_Mast_Code")
                      AND (r."pub_center" = p_pubcent OR p_pubcent IS NULL)
                      AND EXISTS (
                             SELECT 'x'
                               FROM edition_mast
                              WHERE edition_mast."Edition_Alias" =
                                                               r."combin_desc"
                                AND (   (    "Edition_Type" = 'Main Edition'
                                         AND pedtn_flag = 'M'
                                        )
                                     OR (    "Edition_Type" = 'Edition'
                                         AND pedtn_flag = 'E'
                                        )
                                    ))
                      AND (   r."Combin_Code" IN (SELECT edition_name
                                                    FROM RESULT)
                           OR p_packagecode IS NULL
                          )
                      AND (   r."Adv_Cat_Code" IN (SELECT edition_name
                                                     FROM result1)
                           OR padcatg IS NULL
                          )
                      AND (r."Uom" = puom_code OR puom_code IS NULL)
                   UNION
                   SELECT r."rateuniqueid", r."pub_center", r."Adv_Cat_Code",
                          r."Adv_subcat_code", r."Ad_Subcat4", r."Ad_Subcat5",
                          r."Ad_subcat6", r."Premium", r."Scheme_Name",
                          r."Comp_code", r."Rate_Mast_Code",
                          r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",
                          r."combin_desc", r."Combin_Code", r."Uom",
                          r."Size_To", r."Size_From", r."consumption_Per",
                          r."Color", r."Col_chr_typ", r."Remarks",
                          TO_CHAR (r."Valid_From",
                                   'mm/dd/yyyy') AS valid_from,
                          TO_CHAR (r."Valid_To", 'mm/dd/yyyy') AS valid_to,
                          (SELECT "Package_Name"
                             FROM combin_mast
                            WHERE combin_mast."Combin_Code" =
                                            r."Combin_Code"
                              AND combin_mast."Comp_Code" = r."Comp_code")
                                                            AS "Package_Name",
                          (SELECT "Adv_Cat_Name"
                             FROM adv_cat_mast
                            WHERE adv_cat_mast."Adv_Cat_Code" =
                                           r."Adv_Cat_Code"
                              AND adv_cat_mast."Comp_Code" = r."Comp_code")
                                                            AS "Adv_Cat_Name",
                          (SELECT "Adv_Subcat_Name"
                             FROM adv_subcat_mast
                            WHERE adv_subcat_mast."Adv_Subcat_Code" =
                                     r."Adv_subcat_code"
                              AND adv_subcat_mast."Comp_Code" = r."Comp_code")
                                                         AS "Adv_Subcat_Name",
                          (SELECT "Uom_Name"
                             FROM uom_mast
                            WHERE uom_mast."Uom_Code" = r."Uom"
                              AND uom_mast."Comp_Code" = r."Comp_code")
                                                                AS "Uom_Name",
                          r."Week_Day_Rate", r."Week_min_rate",
                          r."Week_Extra_Rate", r."Focus_Day_Rate",
                          r."Focus_min_rate", r."Focus_extra_rate",
                          r."userid", r."Creation_DateTime",
                          r."Premium_Charges", r."weekend_rate",
                          r."weekend_min_rate", r."weekend_extra",
                          r."chksolo", r."min_ad_area", r."Edition_from",
                          r."Edition_to", r."floor_amount",
                          r."floor_discount", r."From_insertion",
                          r."To_insertion", r."Agency_type", r."Client_cat",
                          r."Max_Area", r.sun_rate, r.mon_rate, r.tue_rate,
                          r.wed_rate, r.thu_rate, r.fri_rate, r.sat_rate,
                          r.sun_rate_extra, r.mon_rate_extra,
                          r.tue_rate_extra, r.wed_rate_extra,
                          r.thu_rate_extra, r.fri_rate_extra,
                          r.sat_rate_extra, r.maxwidth, r.priority,
                          r.vat_detail, r.adon, r.ref_id,
                          r.cancellation_charges, '' "ratemastid", '' "id",
                          "Rate_Mast_Code" AS "rate_code"
                     --,'' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
                   FROM   rate_mast r
                    WHERE "Adv_Type_Code" = adtype_p
                      AND "Valid_From" >= fromdate_p
                      AND "Valid_To" <= todate_p
                      AND INSTR ("combin_desc", '+') <= 0
                      AND r."Rate_Mast_Code" =
                                          NVL (p_ratecode, r."Rate_Mast_Code")
                      AND (r."pub_center" = p_pubcent OR p_pubcent IS NULL)
                      AND EXISTS (
                             SELECT 'x'
                               FROM supplement_mast
                              WHERE supplement_mast."Supp_Alias" =
                                                               r."combin_desc"
                                AND pedtn_flag = 'S')
                      AND (   r."Combin_Code" IN (SELECT edition_name
                                                    FROM RESULT)
                           OR p_packagecode IS NULL
                          )
                      AND (   r."Adv_Cat_Code" IN (SELECT edition_name
                                                     FROM result1)
                           OR padcatg IS NULL
                          )
                      AND (r."Uom" = puom_code OR puom_code IS NULL)
                   UNION
                   SELECT r."rateuniqueid", r."pub_center", r."Adv_Cat_Code",
                          r."Adv_subcat_code", r."Ad_Subcat4", r."Ad_Subcat5",
                          r."Ad_subcat6", r."Premium", r."Scheme_Name",
                          r."Comp_code", r."Rate_Mast_Code",
                          r."Adv_Type_Code", r."Rate_Gr_Code", r."Currency",
                          r."combin_desc", r."Combin_Code", r."Uom",
                          r."Size_To", r."Size_From", r."consumption_Per",
                          r."Color", r."Col_chr_typ", r."Remarks",
                          TO_CHAR (r."Valid_From",
                                   'mm/dd/yyyy') AS valid_from,
                          TO_CHAR (r."Valid_To", 'mm/dd/yyyy') AS valid_to,
                          (SELECT "Package_Name"
                             FROM combin_mast
                            WHERE combin_mast."Combin_Code" =
                                            r."Combin_Code"
                              AND combin_mast."Comp_Code" = r."Comp_code")
                                                            AS "Package_Name",
                          (SELECT "Adv_Cat_Name"
                             FROM adv_cat_mast
                            WHERE adv_cat_mast."Adv_Cat_Code" =
                                           r."Adv_Cat_Code"
                              AND adv_cat_mast."Comp_Code" = r."Comp_code")
                                                            AS "Adv_Cat_Name",
                          (SELECT "Adv_Subcat_Name"
                             FROM adv_subcat_mast
                            WHERE adv_subcat_mast."Adv_Subcat_Code" =
                                     r."Adv_subcat_code"
                              AND adv_subcat_mast."Comp_Code" = r."Comp_code")
                                                         AS "Adv_Subcat_Name",
                          (SELECT "Uom_Name"
                             FROM uom_mast
                            WHERE uom_mast."Uom_Code" = r."Uom"
                              AND uom_mast."Comp_Code" = r."Comp_code")
                                                                AS "Uom_Name",
                          r."Week_Day_Rate", r."Week_min_rate",
                          r."Week_Extra_Rate", r."Focus_Day_Rate",
                          r."Focus_min_rate", r."Focus_extra_rate",
                          r."userid", r."Creation_DateTime",
                          r."Premium_Charges", r."weekend_rate",
                          r."weekend_min_rate", r."weekend_extra",
                          r."chksolo", r."min_ad_area", r."Edition_from",
                          r."Edition_to", r."floor_amount",
                          r."floor_discount", r."From_insertion",
                          r."To_insertion", r."Agency_type", r."Client_cat",
                          r."Max_Area", r.sun_rate, r.mon_rate, r.tue_rate,
                          r.wed_rate, r.thu_rate, r.fri_rate, r.sat_rate,
                          r.sun_rate_extra, r.mon_rate_extra,
                          r.tue_rate_extra, r.wed_rate_extra,
                          r.thu_rate_extra, r.fri_rate_extra,
                          r.sat_rate_extra, r.maxwidth, r.priority,
                          r.vat_detail, r.adon, r.ref_id,
                          r.cancellation_charges, '' "ratemastid", '' "id",
                          "Rate_Mast_Code" AS "rate_code"
                     --,'' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
                   FROM   rate_mast r
                    WHERE r."Adv_Type_Code" = adtype_p
                      AND r."Valid_From" >= fromdate_p
                      AND r."Valid_To" <= todate_p
                      AND INSTR (r."combin_desc", '+') <= 0
                      AND r."Rate_Mast_Code" =
                                          NVL (p_ratecode, r."Rate_Mast_Code")
                      AND (r."pub_center" = p_pubcent OR p_pubcent IS NULL)
                      AND pedtn_flag = 'A'
                      AND (   r."Combin_Code" IN (SELECT edition_name
                                                    FROM RESULT)
                           OR p_packagecode IS NULL
                          )
                      AND (   r."Adv_Cat_Code" IN (SELECT edition_name
                                                     FROM result1)
                           OR padcatg IS NULL
                          )
                      AND (r."Uom" = puom_code OR puom_code IS NULL)) x
         ORDER BY x."rateuniqueid";
   END IF;

   IF NVL (p_solo, '') = 'P'
   THEN
      OPEN p_accounts FOR
         SELECT   r."rateuniqueid", r."pub_center", r."Adv_Cat_Code",
                  r."Adv_subcat_code", r."Ad_Subcat4", r."Ad_Subcat5",
                  r."Ad_subcat6", r."Premium", r."Scheme_Name",
                  r."Comp_code", r."Rate_Mast_Code", r."Adv_Type_Code",
                  r."Rate_Gr_Code", r."Currency", r."combin_desc",
                  r."Combin_Code", r."Uom", r."Size_To", r."Size_From",
                  r."consumption_Per", r."Color", r."Col_chr_typ",
                  r."Remarks",
                  TO_CHAR (r."Valid_From", 'mm/dd/yyyy') AS valid_from,
                  TO_CHAR (r."Valid_To", 'mm/dd/yyyy') AS valid_to,
                  (SELECT "Package_Name"
                     FROM combin_mast
                    WHERE combin_mast."Combin_Code" =
                                            r."Combin_Code"
                      AND combin_mast."Comp_Code" = r."Comp_code")
                                                           AS "Package_Name",
                  (SELECT "Adv_Cat_Name"
                     FROM adv_cat_mast
                    WHERE adv_cat_mast."Adv_Cat_Code" =
                                           r."Adv_Cat_Code"
                      AND adv_cat_mast."Comp_Code" = r."Comp_code")
                                                           AS "Adv_Cat_Name",
                  (SELECT "Adv_Subcat_Name"
                     FROM adv_subcat_mast
                    WHERE adv_subcat_mast."Adv_Subcat_Code" =
                                     r."Adv_subcat_code"
                      AND adv_subcat_mast."Comp_Code" = r."Comp_code")
                                                        AS "Adv_Subcat_Name",
                  (SELECT "Uom_Name"
                     FROM uom_mast
                    WHERE uom_mast."Uom_Code" = r."Uom"
                      AND uom_mast."Comp_Code" = r."Comp_code")
                                                               AS "Uom_Name",
                  r."Week_Day_Rate", r."Week_min_rate", r."Week_Extra_Rate",
                  r."Focus_Day_Rate", r."Focus_min_rate",
                  r."Focus_extra_rate", r."userid", r."Creation_DateTime",
                  r."Premium_Charges", r."weekend_rate",
                  r."weekend_min_rate", r."weekend_extra", r."chksolo",
                  r."min_ad_area", r."Edition_from", r."Edition_to",
                  r."floor_amount", r."floor_discount", r."From_insertion",
                  r."To_insertion", r."Agency_type", r."Client_cat",
                  r."Max_Area", r.sun_rate, r.mon_rate, r.tue_rate,
                  r.wed_rate, r.thu_rate, r.fri_rate, r.sat_rate,
                  r.sun_rate_extra, r.mon_rate_extra, r.tue_rate_extra,
                  r.wed_rate_extra, r.thu_rate_extra, r.fri_rate_extra,
                  r.sat_rate_extra, r.maxwidth, r.priority, r.vat_detail,
                  r.adon, r.ref_id, r.cancellation_charges, '' "ratemastid",
                  '' "id", "Rate_Mast_Code" AS "rate_code"
             --, '' "edition_name", ''"Week_Day_Rate", ''"Week_min_rate", ''"Week_Extra_Rate", ''"Focus_Day_Rate", ''"Focus_min_rate", ''"Focus_extra_rate", ''"userid", ''"Creation_DateTime", ''"Comp_Code", ''"Solus_week_rate", ''"Solus_focus_rate", ''"weekend_rate", ''"weekend_min", ''"weekend_extra", ''"Solo_weekendrate", ''SUN_RATE, ''MON_RATE, ''TUE_RATE, ''WED_RATE, ''THU_RATE, ''FRI_RATE, ''SAT_RATE, ''SUN_RATE_EXTRA, ''MON_RATE_EXTRA, ''TUE_RATE_EXTRA, ''WED_RATE_EXTRA, ''THU_RATE_EXTRA, ''FRI_RATE_EXTRA, ''SAT_RATE_EXTRA, ''PKGNAME
         FROM     rate_mast r
            WHERE "Adv_Type_Code" = adtype_p
              AND "Valid_From" >= fromdate_p
              AND "Valid_To" <= todate_p
              AND INSTR ("combin_desc", '+') > 0
              AND r."Rate_Mast_Code" = NVL (p_ratecode, r."Rate_Mast_Code")
              AND (r."pub_center" = p_pubcent OR p_pubcent IS NULL)
              AND (   r."Combin_Code" IN (SELECT edition_name
                                            FROM RESULT)
                   OR p_packagecode IS NULL
                  )
              AND (r."Adv_Cat_Code" IN (SELECT edition_name
                                          FROM result1) OR padcatg IS NULL
                  )
              AND (r."Uom" = puom_code OR puom_code IS NULL)
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


//////////////shipra/////// done by mimoh sir///////////

===start==avinash====by mimoh========================06jun2012=============
CREATE OR REPLACE PACKAGE insertintobookchild_display
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE insertintobookchild_display_p (
      insertdate           IN   DATE,
      edition              IN   VARCHAR2,
      premium1             IN   VARCHAR2,
      premium2             IN   VARCHAR2,
      premallow            IN   VARCHAR2,
      adcategory           IN   VARCHAR2,
      latestdate           IN   DATE,
      material             IN   VARCHAR2,
      cardrate             IN   NUMBER,
      matfilename          IN   VARCHAR2,
      discrate             IN   NUMBER,
      insertstatus         IN   VARCHAR2,
      billstatus           IN   VARCHAR2,
      adsubcat1            IN   VARCHAR2,
      compcode             IN   VARCHAR2,
      userid               IN   VARCHAR2,
      cioid                IN   VARCHAR2,
      height               IN   NUMBER,
      width                IN   NUMBER,
      totalsize            IN   NUMBER,
      pagepost             IN   VARCHAR2,
      premper1             IN   NUMBER,
      premper2             IN   NUMBER,
      colid                IN   VARCHAR2,
      repeat               IN   DATE,
      insertno             IN   INT,
      paid                 IN   VARCHAR2,
      agrrate              IN   NUMBER,
      solorate             IN   NUMBER,
      grossrate            IN   NUMBER,
      insert_pageno        IN   NUMBER,
      insert_remarks       IN   VARCHAR2,
      page_code            IN   VARCHAR2,
      page_per             IN   NUMBER,
      noofcol              IN   NUMBER,
      billamt              IN   NUMBER,
      billrate             IN   NUMBER,
      logo_h               IN   VARCHAR2,
      logo_w               IN   VARCHAR2,
      logo_name            IN   VARCHAR2,
      ad_cat_3             IN   VARCHAR2,
      ad_cat_4             IN   VARCHAR2,
      ad_cat_5             IN   VARCHAR2,
      pkgcode              IN   VARCHAR2,
      gridins              IN   NUMBER,
      pkgalias             IN   VARCHAR2,
      insertid1            IN   NUMBER,
      cirvts               IN   VARCHAR2,
      cirpub               IN   VARCHAR2,
      ciredi               IN   VARCHAR2,
      cirrate              IN   VARCHAR2,
      cirdate_v            IN   DATE,
      ciragency_v          IN   VARCHAR2,
      ciragencysubcode_v   IN   VARCHAR2,
      center_v             IN   VARCHAR2,
      branch_v             IN   VARCHAR2,
      boxcharge_p          IN   FLOAT,
      vat_inc_p            IN   VARCHAR2,
      vatrate_p            IN   FLOAT,
      grossamtlocal_p      IN   NUMBER,
      billamtlocal_p       IN   NUMBER,
      sectioncode_p        IN   VARCHAR2,
      resourceno_p         IN   VARCHAR2,
      caption_inserts_p    IN   VARCHAR2,
      dealerheight         IN   NUMBER,
      dealerwidth          IN   NUMBER,
      subedidata           IN   VARCHAR2,
      disc_p               IN   FLOAT
   );
END insertintobookchild_display;
/



CREATE OR REPLACE PACKAGE BODY insertintobookchild_display
IS
   PROCEDURE insertintobookchild_display_p (
      insertdate           IN   DATE,
      edition              IN   VARCHAR2,
      premium1             IN   VARCHAR2,
      premium2             IN   VARCHAR2,
      premallow            IN   VARCHAR2,
      adcategory           IN   VARCHAR2,
      latestdate           IN   DATE,
      material             IN   VARCHAR2,
      cardrate             IN   NUMBER,
      matfilename          IN   VARCHAR2,
      discrate             IN   NUMBER,
      insertstatus         IN   VARCHAR2,
      billstatus           IN   VARCHAR2,
      adsubcat1            IN   VARCHAR2,
      compcode             IN   VARCHAR2,
      userid               IN   VARCHAR2,
      cioid                IN   VARCHAR2,
      height               IN   NUMBER,
      width                IN   NUMBER,
      totalsize            IN   NUMBER,
      pagepost             IN   VARCHAR2,
      premper1             IN   NUMBER,
      premper2             IN   NUMBER,
      colid                IN   VARCHAR2,
      repeat               IN   DATE,
      insertno             IN   INT,
      paid                 IN   VARCHAR2,
      agrrate              IN   NUMBER,
      solorate             IN   NUMBER,
      grossrate            IN   NUMBER,
      insert_pageno        IN   NUMBER,
      insert_remarks       IN   VARCHAR2,
      page_code            IN   VARCHAR2,
      page_per             IN   NUMBER,
      noofcol              IN   NUMBER,
      billamt              IN   NUMBER,
      billrate             IN   NUMBER,
      logo_h               IN   VARCHAR2,
      logo_w               IN   VARCHAR2,
      logo_name            IN   VARCHAR2,
      ad_cat_3             IN   VARCHAR2,
      ad_cat_4             IN   VARCHAR2,
      ad_cat_5             IN   VARCHAR2,
      pkgcode              IN   VARCHAR2,
      gridins              IN   NUMBER,
      pkgalias             IN   VARCHAR2,
      insertid1            IN   NUMBER,
      cirvts               IN   VARCHAR2,
      cirpub               IN   VARCHAR2,
      ciredi               IN   VARCHAR2,
      cirrate              IN   VARCHAR2,
      cirdate_v            IN   DATE,
      ciragency_v          IN   VARCHAR2,
      ciragencysubcode_v   IN   VARCHAR2,
      center_v             IN   VARCHAR2,
      branch_v             IN   VARCHAR2,
      boxcharge_p          IN   FLOAT,
      vat_inc_p            IN   VARCHAR2,
      vatrate_p            IN   FLOAT,
      grossamtlocal_p      IN   NUMBER,
      billamtlocal_p       IN   NUMBER,
      sectioncode_p        IN   VARCHAR2,
      resourceno_p         IN   VARCHAR2,
      caption_inserts_p    IN   VARCHAR2,
      dealerheight         IN   NUMBER,
      dealerwidth          IN   NUMBER,
      subedidata           IN   VARCHAR2,
      disc_p               IN   FLOAT
   )
   AS
      heightm         NUMBER;
      widthm          NUMBER;
      insertstatusm   VARCHAR2 (50);
      cioidm          VARCHAR2 (50);
      edi             VARCHAR2 (50);
      publi           VARCHAR2 (50);
      pub_cent        VARCHAR2 (50);
      supp            VARCHAR2 (50);
      cou1            NUMBER;
      ID              NUMBER;
      billnum         VARCHAR2 (50);
      retain          VARCHAR2 (50);
      executive       VARCHAR (50);
      insertidval     NUMBER;
      countcir        NUMBER;
      error1          VARCHAR2 (409);
      insertdatem     DATE;
   BEGIN
      heightm := height;
      widthm := width;
      insertstatusm := insertstatus;
      cioidm := cioid;
      insertdatem := insertdate;

      BEGIN
         SELECT COUNT (*)
           INTO cou1
           FROM edition_mast
          WHERE ("Edition_Alias" = edition) AND ("Comp_Code" = compcode);
      EXCEPTION
         WHEN NO_DATA_FOUND
         THEN
            NULL;
      END;

      IF (cou1 > 0)
      THEN
         BEGIN
            SELECT "Edition_Code"
              INTO edi
              FROM edition_mast
             WHERE ("Edition_Alias" = edition) AND ("Comp_Code" = compcode);
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Pub_Code"
              INTO publi
              FROM edition_mast
             WHERE ("Edition_Alias" = edition) AND ("Comp_Code" = compcode);
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "City_Code"
              INTO pub_cent
              FROM edition_mast
             WHERE ("Edition_Alias" = edition) AND ("Comp_Code" = compcode);
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         supp := '';
      ELSE
         BEGIN
            SELECT "Edition_Code"
              INTO edi
              FROM supplement_mast
             WHERE ("Supp_Alias" = edition) AND ("Comp_Code" = compcode);
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Pub_Code"
              INTO publi
              FROM supplement_mast
             WHERE ("Supp_Alias" = edition) AND ("Comp_Code" = compcode);
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Supp_Code"
              INTO supp
              FROM supplement_mast
             WHERE ("Supp_Alias" = edition) AND ("Comp_Code" = compcode);
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "City_Code"
              INTO pub_cent
              FROM edition_mast
             WHERE ("Edition_Code" = edi) AND ("Comp_Code" = compcode);
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;
      END IF;

      IF (supp IS NULL)
      THEN
         supp := 'MN';
      END IF;

      IF (insertid1 IS NULL OR insertid1 = '0' OR insertid1 = '')
      THEN
         SELECT insertid.NEXTVAL
           INTO insertidval
           FROM DUAL;

         INSERT INTO tbl_booking_insert
                     ("Cio_Booking_Id", "Edition", "Insert_Date", "Col_Code",
                      "Height", "Width", "Size_Book", "Page_Post",
                      "Premium1", "Prem_Per1", "Premium2", "Prem_Per2",
                      "Premium_Allow", "Ad_Cat", "Ad_Sub_Cat", "Latest_By",
                      "Status_Material", "File_Name", "Card_Rate",
                      "Disc_Rate", "Insert_Status", "Bill_Status",
                      "Comp_Code", "Userid", "Repeating_Date", "No_Insert",
                      "Edition_Code", "Publication_Code", "Pub_Cent_Code",
                      "Supp_Code", "Pai_Free_Ins", "Agreed_Rate",
                      "Solo_Rate", "Gross_Rate", "Page_No", "Remarks",
                      "Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt",
                      "Bill_Rate", "Logo_H", "Logo_W", "Logo_name",
                      "Insert_Id", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5",
                      package_code, inserts, pkg_alias, boxcharge, vat_inc,
                      vatamt, localgrossamt, localbillamt,
                      sectioncode, resource_no, caption,
                      dealer_h, dealer_w, discount
                     )
              VALUES (cioid, edition, insertdate, colid,
                      height, width, totalsize, pagepost,
                      premium1, premper1, premium2, premper2,
                      premallow, adcategory, adsubcat1, latestdate,
                      material, matfilename, cardrate,
                      discrate, insertstatus, billstatus,
                      compcode, userid, repeat, insertno,
                      edi, publi, pub_cent,
                      supp, paid, agrrate,
                      solorate, grossrate, insert_pageno, insert_remarks,
                      page_code, page_per, noofcol, billamt,
                      billrate, logo_h, logo_w, logo_name,
                      insertidval, ad_cat_3, ad_cat_4, ad_cat_5,
                      pkgcode, gridins, pkgalias, boxcharge_p, vat_inc_p,
                      vatrate_p, grossamtlocal_p, billamtlocal_p,
                      sectioncode_p, resourceno_p, caption_inserts_p,
                      dealerheight, dealerwidth, disc_p
                     );

         IF (cirvts IS NOT NULL)
         THEN
            INSERT INTO tbl_booking_vts
                        (compcode, cioid, insertid, vts, publication,
                         edition, rate, ciragcode, ciragsubcode,
                         center, branch, publishdate
                        )
                 VALUES (compcode, cioid, insertidval, cirvts, cirpub,
                         ciredi, cirrate, ciragency_v, ciragencysubcode_v,
                         center_v, branch_v, cirdate_v
                        );
         END IF;

         insert_edition_details_update (subedidata,
                                        NULL,
                                        cioid,
                                        insertidval,
                                        compcode,
                                        edi,
                                        insertdate,
                                        height,
                                        width,
                                        totalsize,
                                        insertstatus,
                                        pkgcode,
                                        insertno,
                                        insert_pageno,
                                        error1
                                       );
      ELSE
         UPDATE tbl_booking_insert
            SET "Edition" = edition,
                "Insert_Date" = insertdate,
                "Col_Code" = colid,
                "Height" = height,
                "Width" = width,
                "Size_Book" = totalsize,
                "Page_Post" = pagepost,
                "Premium1" = premium1,
                "Prem_Per1" = premper1,
                "Premium2" = premium2,
                "Prem_Per2" = premper2,
                "Premium_Allow" = premallow,
                "Ad_Cat" = adcategory,
                "Ad_Sub_Cat" = adsubcat1,
                "Latest_By" = latestdate,
                "Status_Material" = material,
                "File_Name" = matfilename,
                "Card_Rate" = cardrate,
                "Disc_Rate" = discrate,
                "Insert_Status" = insertstatus,
                "Bill_Status" = billstatus,
                "Comp_Code" = compcode,
                "Userid" = userid,
                "Repeating_Date" = repeat,
                "No_Insert" = insertno,
                "Edition_Code" = edi,
                "Publication_Code" = publi,
                "Pub_Cent_Code" = pub_cent,
                "Supp_Code" = supp,
                "Pai_Free_Ins" = paid,
                "Agreed_Rate" = agrrate,
                "Solo_Rate" = solorate,
                "Gross_Rate" = grossrate,
                "Page_No" = insert_pageno,
                "Remarks" = insert_remarks,
                "Page_Prem" = page_code,
                "Page_Per" = page_per,
                "No_Ofcolumn" = noofcol,
                "Bill_Amt" = billamt,
                "Bill_Rate" = billrate,
                "Logo_H" = logo_h,
                "Logo_W" = logo_w,
                "Logo_name" = logo_name,
                "AD_SUBCAT3" = ad_cat_3,
                "AD_SUBCAT4" = ad_cat_4,
                "AD_SUBCAT5" = ad_cat_5,
                package_code = pkgcode,
                inserts = gridins,
                pkg_alias = pkgalias,
                boxcharge = boxcharge_p,
                vat_inc = vat_inc_p,
                vatamt = vatrate_p,
                localgrossamt = grossamtlocal_p,
                localbillamt = billamtlocal_p,
                sectioncode = sectioncode_p,
                resource_no = resourceno_p,
                caption = caption_inserts_p,
                dealer_h = dealerheight,
                dealer_w = dealerwidth,
                discount = disc_p
          WHERE "Cio_Booking_Id" = cioid AND "Insert_Id" = insertid1;

         IF (subedidata IS NULL)
         THEN
            IF insertstatus = 'cancel'
            THEN
               UPDATE tbl_booking_subedition
                  SET insertstatus = 'cancel'
                WHERE tbl_booking_subedition.cioid = cioid
                  AND insertid = insertid1
                  AND tbl_booking_subedition.insertstatus NOT IN
                                                        ('publish', 'billed');
            ELSE
               UPDATE tbl_booking_subedition
                  SET tbl_booking_subedition.insertdate = insertdatem,
                      tbl_booking_subedition.height = heightm,
                      tbl_booking_subedition.width = widthm,
                      tbl_booking_subedition.totalarea = totalsize,
                      tbl_booking_subedition.insertstatus = insertstatusm
                WHERE tbl_booking_subedition.cioid = cioidm
                  AND tbl_booking_subedition.insertid = insertid1
                  AND tbl_booking_subedition.insertstatus != 'publish'
                  AND tbl_booking_subedition.insertstatus != 'billed';
            END IF;
         END IF;

         BEGIN
            SELECT COUNT (*)
              INTO countcir
              FROM tbl_booking_vts
             WHERE cioid = cioid AND insertid = insertid1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               countcir := 0;
         END;

         IF (countcir = 0)
         THEN
            insertidval := insertid1;

            INSERT INTO tbl_booking_vts
                        (compcode, cioid, insertid, vts, publication,
                         edition, rate, ciragcode, ciragsubcode,
                         center, branch, publishdate
                        )
                 VALUES (compcode, cioid, insertidval, cirvts, cirpub,
                         ciredi, cirrate, ciragency_v, ciragencysubcode_v,
                         center_v, branch_v, cirdate_v
                        );
         ELSE
            UPDATE tbl_booking_vts
               SET vts = cirvts,
                   publication = cirpub,
                   edition = ciredi,
                   rate = cirrate,
                   ciragcode = ciragency_v,
                   ciragsubcode = ciragencysubcode_v,
                   publishdate = cirdate_v
             WHERE cioid = cioid AND insertid = insertid1;
         END IF;

         IF insertstatus = 'billed'
         THEN
            BEGIN
               SELECT bill_no
                 INTO billnum
                 FROM tbl_booking_insert
                WHERE "Cio_Booking_Id" = cioid AND "Insert_Id" = insertid1;
            EXCEPTION
               WHEN NO_DATA_FOUND
               THEN
                  NULL;
            END;

            IF billnum IS NOT NULL
            THEN
               BEGIN
                  SELECT "Executive_code", retainer
                    INTO executive, retain
                    FROM tbl_booking_mast
                   WHERE "cio_booking_id" = cioid;
               EXCEPTION
                  WHEN NO_DATA_FOUND
                  THEN
                     NULL;
               END;

               IF retain IS NOT NULL
               THEN
                  UPDATE ad_bills
                     SET retainer_code = retain,
                         executive_name = NULL
                   WHERE bilno = billnum;
               END IF;

               IF executive IS NOT NULL
               THEN
                  UPDATE ad_bills
                     SET executive_name = executive,
                         retainer_code = NULL
                   WHERE bilno = billnum;
               END IF;
            END IF;
         END IF;
      END IF;
   END insertintobookchild_display_p;
END insertintobookchild_display;
/


/****************************************************************************************/\


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
subedidata in varchar2,
disc_p in float
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
subedidata in varchar2,
disc_p in float
   )
   AS

insertdatem date;
   heightm  number;
    widthm  number;
    insertstatusm  varchar2(50);
    cioidm  varchar2(50);

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
heightm:=height;
    widthm:=width;
    insertstatusm:=insertstatus;
    cioidm:=cioid;
    insertdatem:=insertdate;
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

    insert into tbl_booking_insert("Cio_Booking_Id","Edition","Insert_Date","Col_Code","Height","Width","Size_Book","Page_Post","Premium1","Prem_Per1","Premium2","Prem_Per2","Premium_Allow","Ad_Cat","Ad_Sub_Cat","Latest_By","Status_Material","File_Name","Card_Rate","Disc_Rate","Insert_Status","Bill_Status","Comp_Code","Userid","Repeating_Date","No_Insert","Edition_Code","Publication_Code","Pub_Cent_Code","Supp_Code","Pai_Free_Ins","Agreed_Rate","Solo_Rate","Gross_Rate","Page_No","Remarks","Page_Prem","Page_Per","No_Ofcolumn","Bill_Amt","Bill_Rate","Logo_H", "Logo_W", "Logo_name","Insert_Id","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION,DISCOUNT)
    values(cioid,edition,insertdate,colid,height,width,totalsize,pagepost,premium1,premper1,premium2,premper2,premallow,adcategory,adsubcat1,latestdate,material,matfilename,cardrate,discrate,insertstatus,billstatus,compcode,userid,repeat,insertno,edi,publi,pub_cent,supp,paid,agrrate,solorate,grossrate,insert_pageno,insert_remarks,page_code,page_per,noofcol,billamt,billrate,logo_h,logo_w,logo_name,insertidval,ad_cat_3,ad_cat_4,ad_cat_5, pkgcode,gridins,pkgalias, splboldsizevalue,vatrate_p,boxcharge_p,vat_inc_p ,grossamtlocal_p,billamtlocal_p,sectioncode_p,resourceno_p,caption_inserts_p,disc_p);
       
    
      if(cirvts is not null) then
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                            values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
      end if;

        insert_edition_details_update(subedidata,null,cioid,insertidval,compcode,edi,insertdate,height,width,totalsize,insertstatus,pkgcode,insertno,insert_pageno,error1);
    else
        update  tbl_booking_insert set  "Edition"=edition,"Insert_Date"=insertdate,"Col_Code"=colid,"Height"=height,"Width"=width,"Size_Book"=totalsize,"Page_Post"=pagepost,"Premium1"=premium1,"Prem_Per1"=premper1,"Premium2"=premium2,"Prem_Per2"=premper2,"Premium_Allow"=premallow,"Ad_Cat"=adcategory,"Ad_Sub_Cat"=adsubcat1,"Latest_By"=latestdate,"Status_Material"=material,"File_Name"=matfilename,"Card_Rate"=cardrate,"Disc_Rate"=discrate,"Insert_Status"=insertstatus,"Bill_Status"=billstatus,"Comp_Code"=compcode,"Userid"=userid,"Repeating_Date"=repeat,"No_Insert"=insertno,"Edition_Code"=edi,"Publication_Code"=publi,"Pub_Cent_Code"=pub_cent,"Supp_Code"=supp,"Pai_Free_Ins"=paid,"Agreed_Rate"=agrrate,"Solo_Rate"=solorate,"Gross_Rate"=grossrate,"Page_No"=insert_pageno,"Remarks"=insert_remarks,"Page_Prem"=page_code,"Page_Per"=page_per,"No_Ofcolumn"=noofcol,"Bill_Amt"=billamt,"Bill_Rate"=billrate,"Logo_H"=logo_h, "Logo_W"=logo_w, "Logo_name"=logo_name,"AD_SUBCAT3"=ad_cat_3,"AD_SUBCAT4"=ad_cat_4,"AD_SUBCAT5"=ad_cat_5,PACKAGE_CODE=pkgcode,INSERTS=gridins,PKG_ALIAS=pkgalias, SPECIAL_SIZE1= splboldsizevalue,VATAMT=vatrate_p,BOXCHARGE=boxcharge_p,VAT_INC=vat_inc_p,LOCALGROSSAMT=grossamtlocal_p,LOCALBILLAMT=billamtlocal_p,SECTIONCODE=sectioncode_p,RESOURCE_NO=resourceno_p,CAPTION=caption_inserts_p, DISCOUNT=disc_p  where "Cio_Booking_Id"=cioid and "Insert_Id" = insertid1;
        if(subedidata is null) then
        if insertstatus = 'cancel' then
                   update tbl_booking_subedition set INSERTSTATUS='cancel' where tbl_booking_subedition.cioid=cioid and insertid=insertid1
                and tbl_booking_subedition.INSERTSTATUS not in('publish','billed');
        ELSE
        update tbl_booking_subedition set tbl_booking_subedition.INSERTDATE=insertdatem,tbl_booking_subedition.HEIGHT=heightm,tbl_booking_subedition.WIDTH=widthm,tbl_booking_subedition.TOTALAREA=totalsize , tbl_booking_subedition.INSERTSTATUS=insertstatusm WHERE tbl_booking_subedition.CIOID= cioidm and tbl_booking_subedition.INSERTID=insertid1 and tbl_booking_subedition.INSERTSTATUS!='publish' and tbl_booking_subedition.INSERTSTATUS!='billed';            
        end if;
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


===end==avinash====by mimoh========================04jun2012=============

===start==avinash====by mimoh========================04jun2012=============
CREATE OR REPLACE PACKAGE bindaudit
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE bindaudit_p (
      fromdate         IN       VARCHAR2,
      todate           IN       VARCHAR2,
      date1            IN       VARCHAR2,
      branch1          IN       VARCHAR2,
      adtype           IN       VARCHAR2,
      audittype        IN       VARCHAR2,
      branch2          IN       VARCHAR2,
      v_cat            IN       VARCHAR2,
      v_userid         IN       VARCHAR2,
      comp_code        IN       VARCHAR2,
      v_package_code   IN       VARCHAR2,
      pagency_code     IN       VARCHAR2,
      pclient_code     IN       VARCHAR2,
      psection_code    IN       VARCHAR2,
      p_booktype       IN       VARCHAR2,
      extra1           IN       VARCHAR2,
      extra2           IN       VARCHAR2,
      extra3           IN       VARCHAR2,
      extra4           IN       VARCHAR2,
      p_account        OUT      t_account_cursor
   );
END bindaudit;
/


/***************************************************************************/


CREATE OR REPLACE PACKAGE BODY bindaudit
IS
   PROCEDURE bindaudit_p (
      fromdate         IN       VARCHAR2,
      todate           IN       VARCHAR2,
      date1            IN       VARCHAR2,
      branch1          IN       VARCHAR2,
      adtype           IN       VARCHAR2,
      audittype        IN       VARCHAR2,
      branch2          IN       VARCHAR2,
      v_cat            IN       VARCHAR2,
      v_userid         IN       VARCHAR2,
      comp_code        IN       VARCHAR2,
      v_package_code   IN       VARCHAR2,
      pagency_code     IN       VARCHAR2,
      pclient_code     IN       VARCHAR2,
      psection_code    IN       VARCHAR2,
      p_booktype       IN       VARCHAR2,
                                 --A for all ,D for Direct ,Q for Qbc Booking
      extra1           IN       VARCHAR2,                           --for UOM
      extra2           IN       VARCHAR2,
                   --for Date based on ,B for Booking Date,P for Publish date
      extra3           IN       VARCHAR2,
      extra4           IN       VARCHAR2,
      p_account        OUT      t_account_cursor
   )
   AS
      v_branch1        VARCHAR2 (50);
      v_branch2        VARCHAR2 (50);
      v_approval_req   VARCHAR2 (1);
      v_query          VARCHAR2 (20000);
      v_wherecl        VARCHAR2 (5000);
      v_query_group    VARCHAR2 (5000);
   BEGIN
      --INSERT INTO test1(vstring)VALUES (   'fromdate '|| fromdate|| ' todate '|| todate|| ' date1 '|| date1|| ' BRANCH1 '|| branch1|| ' Adtype '|| adtype|| ' audittype '|| audittype|| ' branch2 '|| branch2|| ' v_Cat '|| v_cat|| ' v_userid '|| v_userid);COMMIT;
      IF branch1 = 'All'
      THEN
         v_branch1 := NULL;
      ELSE
         v_branch1 := branch1;
      END IF;

      IF branch2 = 'All'
      THEN
         v_branch2 := NULL;
      ELSE
         v_branch2 := branch2;
      END IF;

      v_approval_req := 'N';

      SELECT relauthreqon
        INTO v_approval_req
        FROM preferrences
       WHERE "comp_code" = comp_code;

      v_query :=
            'SELECT distinct m."cio_booking_id" as "cio_booking_id",
        NVL ((SELECT distinct  "Cust_Name" FROM cust_mast WHERE "Cust_Code" = m."Client_code"),
        m."Client_code") AS "Client_code",
        m."audit" as "audit", m."Ad_type_code" as "Ad_type_code",m."Receipt_no" as "Receipt_no",
        (SELECT distinct "File_Name" FROM tbl_booking_insert
        WHERE "Cio_Booking_Id" =m."cio_booking_id" AND "File_Name" IS NOT NULL AND ROWNUM <= 1) AS "FILENAME",
        CASE '''
         || date1
         || ''' WHEN ''mm/dd/yyyy'' THEN TO_CHAR(m."Creation_datetime",''mm/dd/yyyy'')
            WHEN ''dd/mm/yyyy'' THEN TO_CHAR (m."Creation_datetime", ''dd/mm/yyyy'')
            WHEN ''yyyy/mm/dd'' THEN TO_CHAR (m."Creation_datetime", ''yyyy/mm/dd'')
        END AS "Creation_datetime",m.ATTACHMENT1 as ATTACHMENT,
        AD_GETAGENCY_ADD('''
         || comp_code
         || ''',m."cio_booking_id",''A'') as "Agency_Remark",
        AD_GETAGENCY_ADD('''
         || comp_code
         || ''',m."cio_booking_id",''C'') as "Client_Remark",
        case when '''
         || v_approval_req
         || '''=''N'' then ''Y'' else 
        case when nvl(m."Discount_per",0)+nvl(m."Special_disc_per",0)=0 then ''Y'' else nvl(m.app_status,''N'') end 
        end as "APPROVAL_FLAG",TO_CHAR(min(i."Insert_Date"),'''
         || date1
         || ''') as "INSERT_DATE",min(i."Insert_Date") dd
        FROM tbl_booking_mast m,tbl_booking_insert i,branch_mst b,login_branch_mast lb
        WHERE m."cio_booking_id" =i."Cio_Booking_Id" AND m."Ad_type_code" = '''
         || adtype
         || '''
        AND m."branch"= b."Branch_Code" and m."branch"= lb.branch_code AND NVL (lb.user_flag, ''N'') = ''Y''';

      IF pagency_code IS NOT NULL
      THEN
         v_wherecl :=
            v_wherecl || ' and m."Agency_sub_code"= ''' || pagency_code
            || '''';
      END IF;

      IF v_branch2 IS NOT NULL
      THEN
         v_wherecl := v_wherecl || ' and m."branch"= ''' || v_branch2 || '''';
      END IF;

      IF pclient_code IS NOT NULL
      THEN
         v_wherecl :=
              v_wherecl || ' and m."Client_code"= ''' || pclient_code || '''';
      END IF;

      IF pclient_code IS NOT NULL
      THEN
         v_wherecl :=
              v_wherecl || ' and m."Client_code"= ''' || pclient_code || '''';
      END IF;

      IF audittype = 'audit' OR (audittype = 'unaudit' OR audittype IS NULL)
      THEN
         IF extra2 = 'P'
         THEN
            v_wherecl :=
                  v_wherecl
               || ' and i."Insert_Date" BETWEEN '''
               || fromdate
               || ''' AND '''
               || todate
               || '''';
         ELSE
            v_wherecl :=
                  v_wherecl
               || ' and m."date_time" BETWEEN '''
               || fromdate
               || ''' AND '''
               || todate
               || '''';
         END IF;
      END IF;

      IF v_cat IS NOT NULL
      THEN
         v_wherecl :=
                     v_wherecl || ' and m."Ad_cat_code"= ''' || v_cat || '''';
      END IF;

      IF v_userid IS NOT NULL
      THEN
         v_wherecl :=
                     v_wherecl || ' and lb.user_code= ''' || v_userid || '''';
      END IF;

      IF v_branch1 IS NOT NULL
      THEN
         v_wherecl :=
                  v_wherecl || ' and b."pub_center"= ''' || v_branch1 || '''';
      END IF;

      IF v_package_code IS NOT NULL
      THEN
         v_wherecl :=
            v_wherecl || ' and i."PACKAGE_CODE"= ''' || v_package_code
            || '''';
      END IF;

      IF psection_code IS NOT NULL
      THEN
         v_wherecl :=
             v_wherecl || ' and i."SECTIONCODE"= ''' || psection_code || '''';
      END IF;

      IF extra1 IS NOT NULL
      THEN
         v_wherecl := v_wherecl || ' and m."Uom_code"= ''' || extra1 || '''';
      END IF;

      IF p_booktype IS NOT NULL
      THEN
         v_wherecl :=
               v_wherecl
            || ' and exists (select "userid" from login where "userid"=m."Userid" and
                                    ((nvl("Agency_code",''0'')<>''0'' and nvl('''
            || p_booktype
            || ''',''A'') =''Q'') or
                   (nvl("Agency_code",''0'')=''0'' and nvl('''
            || p_booktype
            || ''',''A'') =''D'') or nvl('''
            || p_booktype
            || ''',''A'') =''A''))';
      END IF;

      IF audittype = 'audit'
      THEN
         IF extra1 IS NOT NULL
         THEN
            v_wherecl := v_wherecl || ' AND m."audit" IS NOT NULL';
         END IF;
      END IF;

      IF audittype = 'unaudit' OR audittype IS NULL
      THEN
         v_wherecl :=
               v_wherecl
            || ' AND m."audit" IS NULL AND m."ro_status"=''1'' and nvl(m.modified_audit,''N'')!=''Y''';
      END IF;

      IF audittype = 'modified'
      THEN
         v_wherecl :=
               v_wherecl
            || ' AND m."audit" IS NULL AND m."ro_status"=''1'' and nvl(m.modified_audit,''N'')=''Y''';
      END IF;

      /*IF audittype = 'unaudit' or audittype is null THEN
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
              --and m."date_time" BETWEEN fromdate AND todate
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
      END IF;*/
      v_query_group :=
         ' group by m."cio_booking_id" ,m."Client_code",m."audit", m."Ad_type_code",m."Receipt_no",
            m."Creation_datetime",m.ATTACHMENT1,nvl(m."Discount_per",0),nvl(m."Special_disc_per",0),m.app_status 
            order by dd,"cio_booking_id"';

      DELETE FROM test1;

      INSERT INTO test1
                  (vstring, vstring2
                  )
           VALUES ('bindaudit ', v_query || v_wherecl || v_query_group
                  );

      COMMIT;

      OPEN p_account FOR v_query || v_wherecl || v_query_group;
   END bindaudit_p;
END bindaudit;
/
===end==avinash====by mimoh========================04jun2012=============

===start==avinash====by mimoh========================07jun2012=============

CREATE OR REPLACE PACKAGE BODY ERP12MAY.insertintobookchild_update
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
subedidata in varchar2,
disc_p in float,
    P_ip  in varchar2,
P_RATE_AUDIT_FLAG in varchar2
   )
   AS

insertdatem date;
   heightm  number;
    widthm  number;
    insertstatusm  varchar2(50);
    cioidm  varchar2(50);

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
heightm:=height;
    widthm:=width;
    insertstatusm:=insertstatus;
    cioidm:=cioid;
    insertdatem:=insertdate;
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

    insert into tbl_booking_insert("Cio_Booking_Id","Edition","Insert_Date","Col_Code","Height","Width","Size_Book","Page_Post","Premium1","Prem_Per1","Premium2","Prem_Per2","Premium_Allow","Ad_Cat","Ad_Sub_Cat","Latest_By","Status_Material","File_Name","Card_Rate","Disc_Rate","Insert_Status","Bill_Status","Comp_Code","Userid","Repeating_Date","No_Insert","Edition_Code","Publication_Code","Pub_Cent_Code","Supp_Code","Pai_Free_Ins","Agreed_Rate","Solo_Rate","Gross_Rate","Page_No","Remarks","Page_Prem","Page_Per","No_Ofcolumn","Bill_Amt","Bill_Rate","Logo_H", "Logo_W", "Logo_name","Insert_Id","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION,DISCOUNT)
    values(cioid,edition,insertdate,colid,height,width,totalsize,pagepost,premium1,premper1,premium2,premper2,premallow,adcategory,adsubcat1,latestdate,material,matfilename,cardrate,discrate,insertstatus,billstatus,compcode,userid,repeat,insertno,edi,publi,pub_cent,supp,paid,agrrate,solorate,grossrate,insert_pageno,insert_remarks,page_code,page_per,noofcol,billamt,billrate,logo_h,logo_w,logo_name,insertidval,ad_cat_3,ad_cat_4,ad_cat_5, pkgcode,gridins,pkgalias, splboldsizevalue,vatrate_p,boxcharge_p,vat_inc_p ,grossamtlocal_p,billamtlocal_p,sectioncode_p,resourceno_p,caption_inserts_p,disc_p);
       
    
      if(cirvts is not null) then
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                            values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
      end if;

        insert_edition_details_update(subedidata,null,cioid,insertidval,compcode,edi,insertdate,height,width,totalsize,insertstatus,pkgcode,insertno,insert_pageno,error1);
    else
        update  tbl_booking_insert set  "Edition"=edition,"Insert_Date"=insertdate,"Col_Code"=colid,"Height"=height,"Width"=width,"Size_Book"=totalsize,"Page_Post"=pagepost,"Premium1"=premium1,"Prem_Per1"=premper1,"Premium2"=premium2,"Prem_Per2"=premper2,"Premium_Allow"=premallow,"Ad_Cat"=adcategory,"Ad_Sub_Cat"=adsubcat1,"Latest_By"=latestdate,"Status_Material"=material,"File_Name"=matfilename,"Card_Rate"=cardrate,"Disc_Rate"=discrate,"Insert_Status"=insertstatus,"Bill_Status"=billstatus,"Comp_Code"=compcode,"Userid"=userid,"Repeating_Date"=repeat,"No_Insert"=insertno,"Edition_Code"=edi,"Publication_Code"=publi,"Pub_Cent_Code"=pub_cent,"Supp_Code"=supp,"Pai_Free_Ins"=paid,"Agreed_Rate"=agrrate,"Solo_Rate"=solorate,"Gross_Rate"=grossrate,"Page_No"=insert_pageno,"Remarks"=insert_remarks,"Page_Prem"=page_code,"Page_Per"=page_per,"No_Ofcolumn"=noofcol,"Bill_Amt"=billamt,"Bill_Rate"=billrate,"Logo_H"=logo_h, "Logo_W"=logo_w, "Logo_name"=logo_name,"AD_SUBCAT3"=ad_cat_3,"AD_SUBCAT4"=ad_cat_4,"AD_SUBCAT5"=ad_cat_5,PACKAGE_CODE=pkgcode,INSERTS=gridins,PKG_ALIAS=pkgalias, SPECIAL_SIZE1= splboldsizevalue,VATAMT=vatrate_p,BOXCHARGE=boxcharge_p,VAT_INC=vat_inc_p,LOCALGROSSAMT=grossamtlocal_p,LOCALBILLAMT=billamtlocal_p,SECTIONCODE=sectioncode_p,RESOURCE_NO=resourceno_p,CAPTION=caption_inserts_p, DISCOUNT=disc_p ,RATE_AUDIT_FLAG=P_RATE_AUDIT_FLAG,
RATE_AUDIT_IP =P_ip  where "Cio_Booking_Id"=cioid and "Insert_Id" = insertid1;
        if(subedidata is null) then
        if insertstatus = 'cancel' then
                   update tbl_booking_subedition set INSERTSTATUS='cancel' where tbl_booking_subedition.cioid=cioid and insertid=insertid1
                and tbl_booking_subedition.INSERTSTATUS not in('publish','billed');
        ELSE
        update tbl_booking_subedition set tbl_booking_subedition.INSERTDATE=insertdatem,tbl_booking_subedition.HEIGHT=heightm,tbl_booking_subedition.WIDTH=widthm,tbl_booking_subedition.TOTALAREA=totalsize , tbl_booking_subedition.INSERTSTATUS=insertstatusm WHERE tbl_booking_subedition.CIOID= cioidm and tbl_booking_subedition.INSERTID=insertid1 and tbl_booking_subedition.INSERTSTATUS!='publish' and tbl_booking_subedition.INSERTSTATUS!='billed';            
        end if;
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


CREATE OR REPLACE TRIGGER RPTEST.INSERT_RATE_AUDIT_LOG
BEFORE UPDATE
ON RPTEST.TBL_BOOKING_INSERT 
REFERENCING NEW AS New OLD AS Old
FOR EACH ROW
DECLARE

/******************************************************************************
   NAME:       RATE_AUDIT_LOG
   PURPOSE:   FOR LOG GENERATE AT THE TIME OF RATE AUDIT    

   REVISIONS:
   Ver        Date        Author           Description
   ---------  ----------  ---------------  ------------------------------------
   1.0        6/6/2012     Sushil Kumar Tyagi        1. Created this trigger.

   NOTES:

   Automatically available Auto Replace Keywords:
      Object Name:     INSERT_RATE_AUDIT_LOG
      Sysdate:         6/6/2012
      Date and Time:   6/6/2012, 10:09:09 PM, and 6/6/2012 10:09:09 PM
      Username:         (set in TOAD Options, Proc Templates)
      Table Name:      TBL_BOOKING_MAST (set in the "New PL/SQL Object" dialog)
      Trigger Options:  (set in the "New PL/SQL Object" dialog)
******************************************************************************/
v_rate_audit_log_required varchar2(1);
BEGIN
   select rate_audit_log_required into v_rate_audit_log_required from preferrences where "comp_code"=:old."Comp_Code";
   if updating and nvl(v_rate_audit_log_required,'?')='Y' and nvl(:new.rate_audit_flag,'?')='Y' then
        insert into tbl_booking_insert_log_r (Insert_Id, Cio_Booking_Id, No_Insert, Edition_Code, Publication_Code,
                                              Pub_Cent_Code, Supp_Code, Edition, Insert_Date, Col_Code,
                                              Height, Width, Size_Book, Page_Post, Premium1,
                                              Prem_Per1, Premium2, Prem_Per2, Premium_Allow, Ad_Cat,
                                              Ad_Sub_Cat, Latest_By, Repeating_Date, Status_Material, File_Name,
                                              Card_Rate, Disc_Rate, Insert_Status, Bill_Status, Agreed_Rate,
                                              Pai_Free_Ins, Solo_Rate, Gross_Rate, Comp_Code, Userid,
                                              Page_No, Remarks, Pub_Height, Pub_Width, Page_Prem,
                                              Page_Per, No_Ofcolumn, Bill_Amt, Bill_Rate, Logo_H,
                                              Logo_W, Logo_name, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5,
                                              PACKAGE_CODE, BILL_NO, BILL_DATE, INSERTS, PKG_ALIAS,
                                              CONT_GROSS_AMT, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER,
                                              LOCKSTATUS, PROOFREAD, SPECIAL_SIZE1, SPECIAL_SIZE2, VATAMT,
                                              BOXCHARGE, VAT_INC, LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE,
                                              RESOURCE_NO, CAPTION, DEALER_H, DEALER_W, RATE_AUDIT_FLAG,
                                              RATE_AUDIT_IP, RATE_AUDIT_BY, RATE_AUDIT_DATE, TRN_TYPE)
                                      values (:OLD."Insert_Id", :OLD."Cio_Booking_Id", :OLD."No_Insert", :OLD."Edition_Code", :OLD."Publication_Code",
                                              :OLD."Pub_Cent_Code", :OLD."Supp_Code", :OLD."Edition", :OLD."Insert_Date", :OLD."Col_Code",
                                              :OLD."Height", :OLD."Width", :OLD."Size_Book", :OLD."Page_Post", :OLD."Premium1",
                                              :OLD."Prem_Per1", :OLD."Premium2", :OLD."Prem_Per2", :OLD."Premium_Allow", :OLD."Ad_Cat",
                                              :OLD."Ad_Sub_Cat", :OLD."Latest_By", :OLD."Repeating_Date", :OLD."Status_Material", :OLD."File_Name",
                                              :OLD."Card_Rate", :OLD."Disc_Rate", :OLD."Insert_Status", :OLD."Bill_Status", :OLD."Agreed_Rate",
                                              :OLD."Pai_Free_Ins", :OLD."Solo_Rate", :OLD."Gross_Rate", :OLD."Comp_Code", :OLD."Userid",
                                              :OLD."Page_No", :OLD."Remarks", :OLD."Pub_Height", :OLD."Pub_Width", :OLD."Page_Prem",
                                              :OLD."Page_Per", :OLD."No_Ofcolumn", :OLD."Bill_Amt", :OLD."Bill_Rate", :OLD."Logo_H",
                                              :OLD."Logo_W", :OLD."Logo_name", :OLD.AD_SUBCAT3, :OLD.AD_SUBCAT4, :OLD.AD_SUBCAT5,
                                              :OLD.PACKAGE_CODE, :OLD.BILL_NO, :OLD.BILL_DATE, :OLD.INSERTS, :OLD.PKG_ALIAS,
                                              :OLD.CONT_GROSS_AMT, :OLD.APP_STATUS, :OLD.APP_REMARKS, :OLD.APP_DATE, :OLD.APP_USER,
                                              :OLD.LOCKSTATUS, :OLD.PROOFREAD, :OLD.SPECIAL_SIZE1, :OLD.SPECIAL_SIZE2, :OLD.VATAMT,
                                              :OLD.BOXCHARGE, :OLD.VAT_INC, :OLD.LOCALGROSSAMT, :OLD.LOCALBILLAMT, :OLD.SECTIONCODE,
                                              :OLD.RESOURCE_NO, :OLD.CAPTION, :OLD.DEALER_H, :OLD.DEALER_W, :OLD.RATE_AUDIT_FLAG,
                                              :OLD.RATE_AUDIT_IP, :OLD."Userid", sysdate, 'O');
    
        insert into tbl_booking_insert_log_r (Insert_Id, Cio_Booking_Id, No_Insert, Edition_Code, Publication_Code,
                                              Pub_Cent_Code, Supp_Code, Edition, Insert_Date, Col_Code,
                                              Height, Width, Size_Book, Page_Post, Premium1,
                                              Prem_Per1, Premium2, Prem_Per2, Premium_Allow, Ad_Cat,
                                              Ad_Sub_Cat, Latest_By, Repeating_Date, Status_Material, File_Name,
                                              Card_Rate, Disc_Rate, Insert_Status, Bill_Status, Agreed_Rate,
                                              Pai_Free_Ins, Solo_Rate, Gross_Rate, Comp_Code, Userid,
                                              Page_No, Remarks, Pub_Height, Pub_Width, Page_Prem,
                                              Page_Per, No_Ofcolumn, Bill_Amt, Bill_Rate, Logo_H,
                                              Logo_W, Logo_name, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5,
                                              PACKAGE_CODE, BILL_NO, BILL_DATE, INSERTS, PKG_ALIAS,
                                              CONT_GROSS_AMT, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER,
                                              LOCKSTATUS, PROOFREAD, SPECIAL_SIZE1, SPECIAL_SIZE2, VATAMT,
                                              BOXCHARGE, VAT_INC, LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE,
                                              RESOURCE_NO, CAPTION, DEALER_H, DEALER_W, RATE_AUDIT_FLAG,
                                              RATE_AUDIT_IP, RATE_AUDIT_BY, RATE_AUDIT_DATE, TRN_TYPE)
                                      values (:NEW."Insert_Id", :NEW."Cio_Booking_Id", :NEW."No_Insert", :NEW."Edition_Code", :NEW."Publication_Code",
                                              :NEW."Pub_Cent_Code", :NEW."Supp_Code", :NEW."Edition", :NEW."Insert_Date", :NEW."Col_Code",
                                              :NEW."Height", :NEW."Width", :NEW."Size_Book", :NEW."Page_Post", :NEW."Premium1",
                                              :NEW."Prem_Per1", :NEW."Premium2", :NEW."Prem_Per2", :NEW."Premium_Allow", :NEW."Ad_Cat",
                                              :NEW."Ad_Sub_Cat", :NEW."Latest_By", :NEW."Repeating_Date", :NEW."Status_Material", :NEW."File_Name",
                                              :NEW."Card_Rate", :NEW."Disc_Rate", :NEW."Insert_Status", :NEW."Bill_Status", :NEW."Agreed_Rate",
                                              :NEW."Pai_Free_Ins", :NEW."Solo_Rate", :NEW."Gross_Rate", :NEW."Comp_Code", :NEW."Userid",
                                              :NEW."Page_No", :NEW."Remarks", :NEW."Pub_Height", :NEW."Pub_Width", :NEW."Page_Prem",
                                              :NEW."Page_Per", :NEW."No_Ofcolumn", :NEW."Bill_Amt", :NEW."Bill_Rate", :NEW."Logo_H",
                                              :NEW."Logo_W", :NEW."Logo_name", :NEW.AD_SUBCAT3, :NEW.AD_SUBCAT4, :NEW.AD_SUBCAT5,
                                              :NEW.PACKAGE_CODE, :NEW.BILL_NO, :NEW.BILL_DATE, :NEW.INSERTS, :NEW.PKG_ALIAS,
                                              :NEW.CONT_GROSS_AMT, :NEW.APP_STATUS, :NEW.APP_REMARKS, :NEW.APP_DATE, :NEW.APP_USER,
                                              :NEW.LOCKSTATUS, :NEW.PROOFREAD, :NEW.SPECIAL_SIZE1, :NEW.SPECIAL_SIZE2, :NEW.VATAMT,
                                              :NEW.BOXCHARGE, :NEW.VAT_INC, :NEW.LOCALGROSSAMT, :NEW.LOCALBILLAMT, :NEW.SECTIONCODE,
                                              :NEW.RESOURCE_NO, :NEW.CAPTION, :NEW.DEALER_H, :NEW.DEALER_W, :NEW.RATE_AUDIT_FLAG,
                                              :NEW.RATE_AUDIT_IP, :NEW."Userid", sysdate, 'N');                                   
   end if; 
   EXCEPTION
     WHEN OTHERS THEN
       -- Consider logging the error and then re-raise
       RAISE;
END INSERT_RATE_AUDIT_LOG;
/

CREATE OR REPLACE TRIGGER RPTEST.RATE_AUDIT_LOG
BEFORE UPDATE
ON RPTEST.TBL_BOOKING_MAST 
REFERENCING NEW AS New OLD AS Old
FOR EACH ROW
DECLARE

/******************************************************************************
   NAME:       RATE_AUDIT_LOG
   PURPOSE:   FOR LOG GENERATE AT THE TIME OF RATE AUDIT    

   REVISIONS:
   Ver        Date        Author           Description
   ---------  ----------  ---------------  ------------------------------------
   1.0        6/6/2012     Sushil Kumar Tyagi        1. Created this trigger.

   NOTES:

   Automatically available Auto Replace Keywords:
      Object Name:     RATE_AUDIT_LOG
      Sysdate:         6/6/2012
      Date and Time:   6/6/2012, 10:09:09 PM, and 6/6/2012 10:09:09 PM
      Username:         (set in TOAD Options, Proc Templates)
      Table Name:      TBL_BOOKING_MAST (set in the "New PL/SQL Object" dialog)
      Trigger Options:  (set in the "New PL/SQL Object" dialog)
******************************************************************************/
v_rate_audit_log_required varchar2(1);
BEGIN
   select rate_audit_log_required into v_rate_audit_log_required from preferrences where "comp_code"=:old."Comp_code";   
   if updating and nvl(v_rate_audit_log_required,'?')='Y' and nvl(:new.rate_audit_flag,'?')='Y' then
       insert into tbl_booking_mast_log_r (date_time ,  branch ,  booked_by ,  cio_booking_id ,  prev_booking ,
                                           applied_by ,  audit_by ,  RO_No ,  RO_Date ,  Caption ,
                                           bill_status ,  ro_status ,  Agency_code ,  Agency_address ,  Client_code ,
                                           Client_address ,  Agency_sub_code ,  Dockit_no ,  Executive_code ,  Executive_zone ,
                                           Product_code ,  Brand_code ,  Key_no ,  Bill_remarks ,  Print_remark ,
                                           Package_code ,  No_of_insertion ,  Insertion_date ,  Repeating_day ,  Ad_type_code ,
                                           Ad_cat_code ,  Ad_sub_cat_code ,  Color_code ,  Uom_code ,  Page_position_code ,
                                           Page_type_code ,  Page_no ,  Ad_size_type_code ,  Ad_size_height ,  Ad_size_width ,
                                           Rate_code ,  Scheme_type_code ,  Currency_code ,  Agrred_rate ,  Agreed_amount ,
                                           Special_discount ,  Space_discount ,  Special_charges ,  Agency_status ,  Agency_type ,
                                           Agency_pay ,  Agency_credit ,  Total_area ,  Card_rate ,  Card_amount ,
                                           Discount ,  Discount_per ,  Bill_cycle ,  Revenue_center ,  Bill_pay ,
                                           Bill_height ,  Bill_width ,  Bill_to ,  Invoices ,  Vts ,
                                           Bill_add ,  Trade_disc ,  Agency_out ,  Box_code ,  Box_no , 
                                           Box_agency ,  Box_client ,  Box_address ,  Comp_code ,  Userid ,
                                           Creation_datetime ,  Booking_type ,  Tfn ,  Coupan_ad ,  Campaign ,
                                           Bill_amount ,  Page_prem ,  Page_amount ,  Prem_per ,  Gross_amount ,
                                           Ad_size_column ,  Bill_column ,  Bill_area ,  Special_disc_per ,  Space_disc_per ,
                                           Paid_ins ,  Contract_rate ,  Deviation ,  Variant_code ,  Contract_name ,
                                           Contract_type ,  Card_name ,  Card_type ,  Card_month ,  Card_year ,
                                           Card_number ,  Receipt_no ,  Ad_Subcat3 ,  Ad_Subcat4 ,  Ad_subcat5 ,
                                           Bg_color ,  Bullet_code ,  Bullet_premium ,  Material_status ,  Receipt_date ,
                                           prev_cioid ,  prev_receipt ,  prev_grossamt ,  Region ,  Variant ,
                                           Colortype ,  Logo_H ,  Logo_W ,  Logo_color ,  Logo_Uom ,
                                           SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO,
                                           ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS,
                                           CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE,
                                           BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER,
                                           RODOCSTATUS, RO_COMMENT, PROOFREAD, CASHDISCOUNT, CASHDISCTYPE,
                                           ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, DOCTYPE, CHKTRADEDISC,
                                           CHK_DATE, CHK_AMT, CHK_BANK_NAME, OUR_BANK, CHK_NO,
                                           DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE, ACTIVE_AGREEDRATE,
                                           ACTIVE_AGREEDAMT, LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID,
                                           RECEIPT_CURRENCY, CONV_CURR_RATE, REVISE_DATE, CLIENT_TYPE, TRANSLATION_CODE,
                                           TRANSLATION_PREMIUM, MODIFIED_AUDIT, CANCELLATION_CHARGE, RATE_AUDIT_FLAG, RATE_AUDIT_IP,
                                           RATE_AUDIT_BY, RATE_AUDIT_DATE, TRN_TYPE)
                                  values (:OLD."date_time",  :OLD."branch",  :OLD."booked_by",  :OLD."cio_booking_id",  :OLD."prev_booking",
                                          :OLD."applied_by",  :OLD."audit",  :OLD."RO_No",  :OLD."RO_Date",  :OLD."Caption",
                                          :OLD."bill_status",  :OLD."ro_status",  :OLD."Agency_code",  :OLD."Agency_address",  :OLD."Client_code",
                                          :OLD."Client_address",  :OLD."Agency_sub_code",  :OLD."Dockit_no",  :OLD."Executive_code",  :OLD."Executive_zone",
                                          :OLD."Product_code",  :OLD."Brand_code",  :OLD."Key_no",  :OLD."Bill_remarks",  :OLD."Print_remark",
                                          :OLD."Package_code",  :OLD."No_of_insertion",  :OLD."Insertion_date",  :OLD."Repeating_day",  :OLD."Ad_type_code",
                                          :OLD."Ad_cat_code",  :OLD."Ad_sub_cat_code",  :OLD."Color_code",  :OLD."Uom_code",  :OLD."Page_position_code",
                                          :OLD."Page_type_code",  :OLD."Page_no",  :OLD."Ad_size_type_code",  :OLD."Ad_size_height",  :OLD."Ad_size_width",
                                          :OLD."Rate_code",  :OLD."Scheme_type_code",  :OLD."Currency_code",  :OLD."Agrred_rate",  :OLD."Agreed_amount",
                                          :OLD."Special_discount",  :OLD."Space_discount",  :OLD."Special_charges",  :OLD."Agency_status",  :OLD."Agency_type",
                                          :OLD."Agency_pay",  :OLD."Agency_credit",  :OLD."Total_area",  :OLD."Card_rate",  :OLD."Card_amount",
                                          :OLD."Discount",  :OLD."Discount_per",  :OLD."Bill_cycle",  :OLD."Revenue_center",  :OLD."Bill_pay",
                                          :OLD."Bill_height",  :OLD."Bill_width",  :OLD."Bill_to",  :OLD."Invoices",  :OLD."Vts",
                                          :OLD."Bill_add",  :OLD."Trade_disc",  :OLD."Agency_out",  :OLD."Box_code",  :OLD."Box_no", 
                                          :OLD."Box_agency",  :OLD."Box_client",  :OLD."Box_address",  :OLD."Comp_code",  :OLD."Userid",
                                          :OLD."Creation_datetime",  :OLD."Booking_type",  :OLD."Tfn",  :OLD."Coupan_ad",  :OLD."Campaign",
                                          :OLD."Bill_amount",  :OLD."Page_prem",  :OLD."Page_amount",  :OLD."Prem_per",  :OLD."Gross_amount",
                                          :OLD."Ad_size_column",  :OLD."Bill_column",  :OLD."Bill_area",  :OLD."Special_disc_per",  :OLD."Space_disc_per",
                                          :OLD."Paid_ins",  :OLD."Contract_rate",  :OLD."Deviation",  :OLD."Variant_code",  :OLD."Contract_name",
                                          :OLD."Contract_type",  :OLD."Card_name",  :OLD."Card_type",  :OLD."Card_month",  :OLD."Card_year",
                                          :OLD."Card_number",  :OLD."Receipt_no",  :OLD."Ad_Subcat3",  :OLD."Ad_Subcat4",  :OLD."Ad_subcat5",
                                          :OLD."Bg_color",  :OLD."Bullet_code",  :OLD."Bullet_premium",  :OLD."Material_status",  :OLD."Receipt_date",
                                          :OLD."prev_cioid",  :OLD."prev_receipt",  :OLD."prev_grossamt",  :OLD."Region",  :OLD."Variant",
                                          :OLD."Colortype",  :OLD."Logo_H",  :OLD."Logo_W",  :OLD."Logo_color",  :OLD."Logo_Uom",
                                          :OLD.SAPID, :OLD.RETAINER, :OLD.ADD_AGENCY_COMM, :OLD.AUDIT_COMMENT, :OLD.MOBILENO,
                                          :OLD.ADD_AGENCY_COMM_AMT, :OLD.RETAINER_COMM, :OLD.RETAINER_COMM_AMT, :OLD.CASH_RECIEVED, :OLD.CONT_GROSS,
                                          :OLD.CIRAGENCY, :OLD.CIRRATE, :OLD.CIREDITION, :OLD.CIRPUBLICATION, :OLD.CIRAGENCY_SUBCODE,
                                          :OLD.BARTER_TYPE, :OLD.APP_STATUS, :OLD.APP_REMARKS, :OLD.APP_DATE, :OLD.APP_USER,
                                          :OLD.RODOCSTATUS, :OLD.RO_COMMENT, :OLD.PROOFREAD, :OLD.CASHDISCOUNT, :OLD.CASHDISCTYPE,
                                          :OLD.ATTACHMENT1, :OLD.ATTACHMENT2, :OLD.DISC_PREMIUM, :OLD.DOCTYPE, :OLD.CHKTRADEDISC,
                                          :OLD.CHK_DATE, :OLD.CHK_AMT, :OLD.CHK_BANK_NAME, :OLD.OUR_BANK, :OLD.CHK_NO,
                                          :OLD.DEALERPANEL, :OLD.DEALER_H, :OLD.DEALER_W, :OLD.DEALERTYPE, :OLD.ACTIVE_AGREEDRATE,
                                          :OLD.ACTIVE_AGREEDAMT, :OLD.LOCALGROSSAMT, :OLD.LOCALBILLAMT, :OLD.PACKAGE_TYPE, :OLD.AD_REFID,
                                          :OLD.RECEIPT_CURRENCY, :OLD.CONV_CURR_RATE, :OLD.REVISE_DATE, :OLD.CLIENT_TYPE, :OLD.TRANSLATION_CODE,
                                          :OLD.TRANSLATION_PREMIUM, :OLD.MODIFIED_AUDIT, :OLD.CANCELLATION_CHARGE, :OLD.RATE_AUDIT_FLAG, :OLD.RATE_AUDIT_IP,
                                          :OLD."Userid", sysdate, 'O');
       insert into tbl_booking_mast_log_r (date_time ,  branch ,  booked_by ,  cio_booking_id ,  prev_booking ,
                                           applied_by ,  audit_by ,  RO_No ,  RO_Date ,  Caption ,
                                           bill_status ,  ro_status ,  Agency_code ,  Agency_address ,  Client_code ,
                                           Client_address ,  Agency_sub_code ,  Dockit_no ,  Executive_code ,  Executive_zone ,
                                           Product_code ,  Brand_code ,  Key_no ,  Bill_remarks ,  Print_remark ,
                                           Package_code ,  No_of_insertion ,  Insertion_date ,  Repeating_day ,  Ad_type_code ,
                                           Ad_cat_code ,  Ad_sub_cat_code ,  Color_code ,  Uom_code ,  Page_position_code ,
                                           Page_type_code ,  Page_no ,  Ad_size_type_code ,  Ad_size_height ,  Ad_size_width ,
                                           Rate_code ,  Scheme_type_code ,  Currency_code ,  Agrred_rate ,  Agreed_amount ,
                                           Special_discount ,  Space_discount ,  Special_charges ,  Agency_status ,  Agency_type ,
                                           Agency_pay ,  Agency_credit ,  Total_area ,  Card_rate ,  Card_amount ,
                                           Discount ,  Discount_per ,  Bill_cycle ,  Revenue_center ,  Bill_pay ,
                                           Bill_height ,  Bill_width ,  Bill_to ,  Invoices ,  Vts ,
                                           Bill_add ,  Trade_disc ,  Agency_out ,  Box_code ,  Box_no , 
                                           Box_agency ,  Box_client ,  Box_address ,  Comp_code ,  Userid ,
                                           Creation_datetime ,  Booking_type ,  Tfn ,  Coupan_ad ,  Campaign ,
                                           Bill_amount ,  Page_prem ,  Page_amount ,  Prem_per ,  Gross_amount ,
                                           Ad_size_column ,  Bill_column ,  Bill_area ,  Special_disc_per ,  Space_disc_per ,
                                           Paid_ins ,  Contract_rate ,  Deviation ,  Variant_code ,  Contract_name ,
                                           Contract_type ,  Card_name ,  Card_type ,  Card_month ,  Card_year ,
                                           Card_number ,  Receipt_no ,  Ad_Subcat3 ,  Ad_Subcat4 ,  Ad_subcat5 ,
                                           Bg_color ,  Bullet_code ,  Bullet_premium ,  Material_status ,  Receipt_date ,
                                           prev_cioid ,  prev_receipt ,  prev_grossamt ,  Region ,  Variant ,
                                           Colortype ,  Logo_H ,  Logo_W ,  Logo_color ,  Logo_Uom ,
                                           SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO,
                                           ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS,
                                           CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE,
                                           BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER,
                                           RODOCSTATUS, RO_COMMENT, PROOFREAD, CASHDISCOUNT, CASHDISCTYPE,
                                           ATTACHMENT1, ATTACHMENT2, DISC_PREMIUM, DOCTYPE, CHKTRADEDISC,
                                           CHK_DATE, CHK_AMT, CHK_BANK_NAME, OUR_BANK, CHK_NO,
                                           DEALERPANEL, DEALER_H, DEALER_W, DEALERTYPE, ACTIVE_AGREEDRATE,
                                           ACTIVE_AGREEDAMT, LOCALGROSSAMT, LOCALBILLAMT, PACKAGE_TYPE, AD_REFID,
                                           RECEIPT_CURRENCY, CONV_CURR_RATE, REVISE_DATE, CLIENT_TYPE, TRANSLATION_CODE,
                                           TRANSLATION_PREMIUM, MODIFIED_AUDIT, CANCELLATION_CHARGE, RATE_AUDIT_FLAG, RATE_AUDIT_IP,
                                           RATE_AUDIT_BY, RATE_AUDIT_DATE, TRN_TYPE)
                                  values (:NEW."date_time",  :NEW."branch",  :NEW."booked_by",  :NEW."cio_booking_id",  :NEW."prev_booking",
                                          :NEW."applied_by",  :NEW."audit",  :NEW."RO_No",  :NEW."RO_Date",  :NEW."Caption",
                                          :NEW."bill_status",  :NEW."ro_status",  :NEW."Agency_code",  :NEW."Agency_address",  :NEW."Client_code",
                                          :NEW."Client_address",  :NEW."Agency_sub_code",  :NEW."Dockit_no",  :NEW."Executive_code",  :NEW."Executive_zone",
                                          :NEW."Product_code",  :NEW."Brand_code",  :NEW."Key_no",  :NEW."Bill_remarks",  :NEW."Print_remark",
                                          :NEW."Package_code",  :NEW."No_of_insertion",  :NEW."Insertion_date",  :NEW."Repeating_day",  :NEW."Ad_type_code",
                                          :NEW."Ad_cat_code",  :NEW."Ad_sub_cat_code",  :NEW."Color_code",  :NEW."Uom_code",  :NEW."Page_position_code",
                                          :NEW."Page_type_code",  :NEW."Page_no",  :NEW."Ad_size_type_code",  :NEW."Ad_size_height",  :NEW."Ad_size_width",
                                          :NEW."Rate_code",  :NEW."Scheme_type_code",  :NEW."Currency_code",  :NEW."Agrred_rate",  :NEW."Agreed_amount",
                                          :NEW."Special_discount",  :NEW."Space_discount",  :NEW."Special_charges",  :NEW."Agency_status",  :NEW."Agency_type",
                                          :NEW."Agency_pay",  :NEW."Agency_credit",  :NEW."Total_area",  :NEW."Card_rate",  :NEW."Card_amount",
                                          :NEW."Discount",  :NEW."Discount_per",  :NEW."Bill_cycle",  :NEW."Revenue_center",  :NEW."Bill_pay",
                                          :NEW."Bill_height",  :NEW."Bill_width",  :NEW."Bill_to",  :NEW."Invoices",  :NEW."Vts",
                                          :NEW."Bill_add",  :NEW."Trade_disc",  :NEW."Agency_out",  :NEW."Box_code",  :NEW."Box_no", 
                                          :NEW."Box_agency",  :NEW."Box_client",  :NEW."Box_address",  :NEW."Comp_code",  :NEW."Userid",
                                          :NEW."Creation_datetime",  :NEW."Booking_type",  :NEW."Tfn",  :NEW."Coupan_ad",  :NEW."Campaign",
                                          :NEW."Bill_amount",  :NEW."Page_prem",  :NEW."Page_amount",  :NEW."Prem_per",  :NEW."Gross_amount",
                                          :NEW."Ad_size_column",  :NEW."Bill_column",  :NEW."Bill_area",  :NEW."Special_disc_per",  :NEW."Space_disc_per",
                                          :NEW."Paid_ins",  :NEW."Contract_rate",  :NEW."Deviation",  :NEW."Variant_code",  :NEW."Contract_name",
                                          :NEW."Contract_type",  :NEW."Card_name",  :NEW."Card_type",  :NEW."Card_month",  :NEW."Card_year",
                                          :NEW."Card_number",  :NEW."Receipt_no",  :NEW."Ad_Subcat3",  :NEW."Ad_Subcat4",  :NEW."Ad_subcat5",
                                          :NEW."Bg_color",  :NEW."Bullet_code",  :NEW."Bullet_premium",  :NEW."Material_status",  :NEW."Receipt_date",
                                          :NEW."prev_cioid",  :NEW."prev_receipt",  :NEW."prev_grossamt",  :NEW."Region",  :NEW."Variant",
                                          :NEW."Colortype",  :NEW."Logo_H",  :NEW."Logo_W",  :NEW."Logo_color",  :NEW."Logo_Uom",
                                          :NEW.SAPID, :NEW.RETAINER, :NEW.ADD_AGENCY_COMM, :NEW.AUDIT_COMMENT, :NEW.MOBILENO,
                                          :NEW.ADD_AGENCY_COMM_AMT, :NEW.RETAINER_COMM, :NEW.RETAINER_COMM_AMT, :NEW.CASH_RECIEVED, :NEW.CONT_GROSS,
                                          :NEW.CIRAGENCY, :NEW.CIRRATE, :NEW.CIREDITION, :NEW.CIRPUBLICATION, :NEW.CIRAGENCY_SUBCODE,
                                          :NEW.BARTER_TYPE, :NEW.APP_STATUS, :NEW.APP_REMARKS, :NEW.APP_DATE, :NEW.APP_USER,
                                          :NEW.RODOCSTATUS, :NEW.RO_COMMENT, :NEW.PROOFREAD, :NEW.CASHDISCOUNT, :NEW.CASHDISCTYPE,
                                          :NEW.ATTACHMENT1, :NEW.ATTACHMENT2, :NEW.DISC_PREMIUM, :NEW.DOCTYPE, :NEW.CHKTRADEDISC,
                                          :NEW.CHK_DATE, :NEW.CHK_AMT, :NEW.CHK_BANK_NAME, :NEW.OUR_BANK, :NEW.CHK_NO,
                                          :NEW.DEALERPANEL, :NEW.DEALER_H, :NEW.DEALER_W, :NEW.DEALERTYPE, :NEW.ACTIVE_AGREEDRATE,
                                          :NEW.ACTIVE_AGREEDAMT, :NEW.LOCALGROSSAMT, :NEW.LOCALBILLAMT, :NEW.PACKAGE_TYPE, :NEW.AD_REFID,
                                          :NEW.RECEIPT_CURRENCY, :NEW.CONV_CURR_RATE, :NEW.REVISE_DATE, :NEW.CLIENT_TYPE, :NEW.TRANSLATION_CODE,
                                          :NEW.TRANSLATION_PREMIUM, :NEW.MODIFIED_AUDIT, :NEW.CANCELLATION_CHARGE, :NEW.RATE_AUDIT_FLAG, :NEW.RATE_AUDIT_IP,
                                          :NEW."Userid", sysdate, 'N');                                   
   end if; 
   EXCEPTION
     WHEN OTHERS THEN
       -- Consider logging the error and then re-raise
       RAISE;
END RATE_AUDIT_LOG;
/
CREATE TABLE TBL_BOOKING_INSERT_LOG_R
(
  INSERT_ID         NUMBER(10)                  NOT NULL,
  CIO_BOOKING_ID    VARCHAR2(50 BYTE)           NOT NULL,
  NO_INSERT         NUMBER(10),
  EDITION_CODE      VARCHAR2(8 BYTE)            NOT NULL,
  PUBLICATION_CODE  VARCHAR2(8 BYTE)            NOT NULL,
  PUB_CENT_CODE     VARCHAR2(8 BYTE)            NOT NULL,
  SUPP_CODE         VARCHAR2(8 BYTE),
  EDITION           VARCHAR2(500 BYTE)          NOT NULL,
  INSERT_DATE       DATE,
  COL_CODE          VARCHAR2(8 BYTE),
  HEIGHT            FLOAT(126),
  WIDTH             FLOAT(126),
  SIZE_BOOK         FLOAT(126),
  PAGE_POST         VARCHAR2(8 BYTE),
  PREMIUM1          VARCHAR2(8 BYTE),
  PREM_PER1         FLOAT(126),
  PREMIUM2          VARCHAR2(8 BYTE),
  PREM_PER2         FLOAT(126),
  PREMIUM_ALLOW     VARCHAR2(2 BYTE),
  AD_CAT            VARCHAR2(8 BYTE),
  AD_SUB_CAT        VARCHAR2(8 BYTE),
  LATEST_BY         DATE,
  REPEATING_DATE    DATE,
  STATUS_MATERIAL   VARCHAR2(20 BYTE),
  FILE_NAME         VARCHAR2(100 BYTE),
  CARD_RATE         FLOAT(126),
  DISC_RATE         FLOAT(126),
  INSERT_STATUS     VARCHAR2(50 BYTE),
  BILL_STATUS       VARCHAR2(8 BYTE),
  AGREED_RATE       FLOAT(126),
  PAI_FREE_INS      VARCHAR2(2 BYTE),
  SOLO_RATE         FLOAT(126),
  GROSS_RATE        FLOAT(126),
  COMP_CODE         VARCHAR2(8 BYTE)            NOT NULL,
  USERID            VARCHAR2(8 BYTE)            NOT NULL,
  PAGE_NO           NUMBER(10),
  REMARKS           VARCHAR2(500 BYTE),
  PUB_HEIGHT        FLOAT(126),
  PUB_WIDTH         FLOAT(126),
  PAGE_PREM         VARCHAR2(8 BYTE),
  PAGE_PER          FLOAT(126),
  NO_OFCOLUMN       FLOAT(126),
  BILL_AMT          FLOAT(126),
  BILL_RATE         FLOAT(126),
  LOGO_H            VARCHAR2(5 BYTE),
  LOGO_W            VARCHAR2(5 BYTE),
  LOGO_NAME         VARCHAR2(100 BYTE),
  AD_SUBCAT3        VARCHAR2(15 BYTE),
  AD_SUBCAT4        VARCHAR2(15 BYTE),
  AD_SUBCAT5        VARCHAR2(15 BYTE),
  PACKAGE_CODE      VARCHAR2(100 BYTE),
  BILL_NO           VARCHAR2(100 BYTE),
  BILL_DATE         DATE,
  INSERTS           NUMBER,
  PKG_ALIAS         VARCHAR2(50 BYTE),
  CONT_GROSS_AMT    FLOAT(126),
  APP_STATUS        VARCHAR2(10 BYTE),
  APP_REMARKS       VARCHAR2(500 BYTE),
  APP_DATE          DATE                        DEFAULT NULL,
  APP_USER          VARCHAR2(50 BYTE),
  LOCKSTATUS        VARCHAR2(1 BYTE)            DEFAULT 'N',
  PROOFREAD         VARCHAR2(50 BYTE),
  SPECIAL_SIZE1     VARCHAR2(50 BYTE),
  SPECIAL_SIZE2     VARCHAR2(50 BYTE),
  VATAMT            FLOAT(126),
  BOXCHARGE         NUMBER,
  VAT_INC           VARCHAR2(2 BYTE),
  LOCALGROSSAMT     NUMBER,
  LOCALBILLAMT      NUMBER,
  SECTIONCODE       VARCHAR2(50 BYTE),
  RESOURCE_NO       VARCHAR2(50 BYTE),
  CAPTION           VARCHAR2(500 BYTE),
  DEALER_H          FLOAT(126),
  DEALER_W          FLOAT(126),
  RATE_AUDIT_FLAG   VARCHAR2(1 BYTE),
  RATE_AUDIT_IP     VARCHAR2(20 BYTE),
  RATE_AUDIT_BY     VARCHAR2(20 BYTE),
  RATE_AUDIT_DATE   DATE,
  TRN_TYPE          VARCHAR2(1 BYTE)
)


CREATE TABLE TBL_BOOKING_MAST_LOG_R
(
  DATE_TIME            DATE                     NOT NULL,
  BRANCH               VARCHAR2(25 BYTE)        NOT NULL,
  BOOKED_BY            VARCHAR2(25 BYTE)        NOT NULL,
  CIO_BOOKING_ID       VARCHAR2(50 BYTE)        NOT NULL,
  PREV_BOOKING         VARCHAR2(25 BYTE),
  APPLIED_BY           VARCHAR2(25 BYTE),
  AUDIT_BY             VARCHAR2(25 BYTE),
  RO_NO                VARCHAR2(40 BYTE),
  RO_DATE              DATE,
  CAPTION              VARCHAR2(500 BYTE),
  BILL_STATUS          VARCHAR2(8 BYTE)         NOT NULL,
  RO_STATUS            VARCHAR2(8 BYTE),
  AGENCY_CODE          VARCHAR2(15 BYTE),
  AGENCY_ADDRESS       VARCHAR2(500 BYTE),
  CLIENT_CODE          VARCHAR2(100 BYTE),
  CLIENT_ADDRESS       VARCHAR2(500 BYTE),
  AGENCY_SUB_CODE      VARCHAR2(20 BYTE),
  DOCKIT_NO            VARCHAR2(25 BYTE),
  EXECUTIVE_CODE       VARCHAR2(50 BYTE),
  EXECUTIVE_ZONE       VARCHAR2(50 BYTE),
  PRODUCT_CODE         VARCHAR2(20 BYTE),
  BRAND_CODE           VARCHAR2(20 BYTE),
  KEY_NO               VARCHAR2(50 BYTE),
  BILL_REMARKS         VARCHAR2(500 BYTE),
  PRINT_REMARK         VARCHAR2(500 BYTE),
  PACKAGE_CODE         VARCHAR2(500 BYTE)       NOT NULL,
  NO_OF_INSERTION      NUMBER,
  INSERTION_DATE       DATE,
  REPEATING_DAY        VARCHAR2(8 BYTE),
  AD_TYPE_CODE         VARCHAR2(8 BYTE),
  AD_CAT_CODE          VARCHAR2(8 BYTE),
  AD_SUB_CAT_CODE      VARCHAR2(50 BYTE),
  COLOR_CODE           VARCHAR2(8 BYTE),
  UOM_CODE             VARCHAR2(8 BYTE),
  PAGE_POSITION_CODE   VARCHAR2(8 BYTE),
  PAGE_TYPE_CODE       VARCHAR2(100 BYTE),
  PAGE_NO              NUMBER,
  AD_SIZE_TYPE_CODE    VARCHAR2(8 BYTE),
  AD_SIZE_HEIGHT       NUMBER,
  AD_SIZE_WIDTH        NUMBER,
  RATE_CODE            VARCHAR2(100 BYTE),
  SCHEME_TYPE_CODE     VARCHAR2(50 BYTE),
  CURRENCY_CODE        VARCHAR2(8 BYTE),
  AGRRED_RATE          NUMBER,
  AGREED_AMOUNT        NUMBER,
  SPECIAL_DISCOUNT     NUMBER,
  SPACE_DISCOUNT       NUMBER,
  SPECIAL_CHARGES      NUMBER,
  AGENCY_STATUS        VARCHAR2(15 BYTE),
  AGENCY_TYPE          VARCHAR2(25 BYTE),
  AGENCY_PAY           VARCHAR2(25 BYTE),
  AGENCY_CREDIT        NUMBER,
  TOTAL_AREA           NUMBER,
  CARD_RATE            NUMBER,
  CARD_AMOUNT          NUMBER,
  DISCOUNT             NUMBER,
  DISCOUNT_PER         NUMBER,
  BILL_CYCLE           VARCHAR2(8 BYTE),
  REVENUE_CENTER       VARCHAR2(50 BYTE),
  BILL_PAY             VARCHAR2(8 BYTE),
  BILL_HEIGHT          NUMBER,
  BILL_WIDTH           NUMBER,
  BILL_TO              VARCHAR2(100 BYTE),
  INVOICES             NUMBER,
  VTS                  NUMBER,
  BILL_ADD             VARCHAR2(500 BYTE),
  TRADE_DISC           NUMBER,
  AGENCY_OUT           VARCHAR2(50 BYTE),
  BOX_CODE             VARCHAR2(50 BYTE),
  BOX_NO               VARCHAR2(50 BYTE),
  BOX_AGENCY           VARCHAR2(2 BYTE),
  BOX_CLIENT           VARCHAR2(2 BYTE),
  BOX_ADDRESS          VARCHAR2(500 BYTE),
  COMP_CODE            VARCHAR2(8 BYTE)         NOT NULL,
  USERID               VARCHAR2(8 BYTE)         NOT NULL,
  CREATION_DATETIME    DATE                     NOT NULL,
  BOOKING_TYPE         VARCHAR2(8 BYTE),
  TFN                  VARCHAR2(2 BYTE),
  COUPAN_AD            VARCHAR2(2 BYTE),
  CAMPAIGN             VARCHAR2(50 BYTE),
  BILL_AMOUNT          NUMBER,
  PAGE_PREM            VARCHAR2(8 BYTE),
  PAGE_AMOUNT          NUMBER,
  PREM_PER             NUMBER,
  GROSS_AMOUNT         NUMBER,
  AD_SIZE_COLUMN       NUMBER,
  BILL_COLUMN          NUMBER,
  BILL_AREA            NUMBER,
  SPECIAL_DISC_PER     NUMBER,
  SPACE_DISC_PER       NUMBER,
  PAID_INS             NUMBER,
  CONTRACT_RATE        NUMBER,
  DEVIATION            NUMBER,
  VARIANT_CODE         VARCHAR2(8 BYTE),
  CONTRACT_NAME        VARCHAR2(50 BYTE),
  CONTRACT_TYPE        VARCHAR2(50 BYTE),
  CARD_NAME            VARCHAR2(100 BYTE),
  CARD_TYPE            VARCHAR2(50 BYTE),
  CARD_MONTH           VARCHAR2(8 BYTE),
  CARD_YEAR            VARCHAR2(8 BYTE),
  CARD_NUMBER          VARCHAR2(20 BYTE),
  RECEIPT_NO           VARCHAR2(50 BYTE),
  AD_SUBCAT3           VARCHAR2(8 BYTE),
  AD_SUBCAT4           VARCHAR2(8 BYTE),
  AD_SUBCAT5           VARCHAR2(8 BYTE),
  BG_COLOR             VARCHAR2(8 BYTE),
  BULLET_CODE          VARCHAR2(8 BYTE),
  BULLET_PREMIUM       NUMBER,
  MATERIAL_STATUS      VARCHAR2(20 BYTE),
  RECEIPT_DATE         DATE,
  PREV_CIOID           VARCHAR2(100 BYTE),
  PREV_RECEIPT         VARCHAR2(50 BYTE),
  PREV_GROSSAMT        NUMBER,
  REGION               VARCHAR2(8 BYTE),
  VARIANT              VARCHAR2(8 BYTE),
  COLORTYPE            VARCHAR2(8 BYTE),
  LOGO_H               VARCHAR2(5 BYTE),
  LOGO_W               VARCHAR2(5 BYTE),
  LOGO_COLOR           VARCHAR2(8 BYTE),
  LOGO_UOM             VARCHAR2(8 BYTE),
  SAPID                VARCHAR2(10 BYTE),
  RETAINER             VARCHAR2(8 BYTE),
  ADD_AGENCY_COMM      VARCHAR2(8 BYTE),
  AUDIT_COMMENT        VARCHAR2(1000 BYTE),
  MOBILENO             VARCHAR2(50 BYTE),
  ADD_AGENCY_COMM_AMT  VARCHAR2(50 BYTE),
  RETAINER_COMM        VARCHAR2(50 BYTE),
  RETAINER_COMM_AMT    VARCHAR2(50 BYTE),
  CASH_RECIEVED        NUMBER,
  CONT_GROSS           NUMBER,
  CIRAGENCY            VARCHAR2(100 BYTE),
  CIRRATE              VARCHAR2(50 BYTE),
  CIREDITION           VARCHAR2(50 BYTE),
  CIRPUBLICATION       VARCHAR2(50 BYTE),
  CIRAGENCY_SUBCODE    VARCHAR2(50 BYTE),
  BARTER_TYPE          VARCHAR2(50 BYTE),
  APP_STATUS           VARCHAR2(10 BYTE),
  APP_REMARKS          VARCHAR2(500 BYTE),
  APP_DATE             DATE                     DEFAULT NULL,
  APP_USER             VARCHAR2(50 BYTE),
  RODOCSTATUS          VARCHAR2(25 BYTE),
  RO_COMMENT           VARCHAR2(500 BYTE),
  PROOFREAD            VARCHAR2(50 BYTE),
  CASHDISCOUNT         NUMBER,
  CASHDISCTYPE         VARCHAR2(5 BYTE),
  ATTACHMENT1          VARCHAR2(50 BYTE),
  ATTACHMENT2          VARCHAR2(50 BYTE),
  DISC_PREMIUM         VARCHAR2(50 BYTE),
  DOCTYPE              VARCHAR2(20 BYTE),
  CHKTRADEDISC         VARCHAR2(1 BYTE),
  CHK_DATE             DATE,
  CHK_AMT              FLOAT(126),
  CHK_BANK_NAME        VARCHAR2(50 BYTE),
  OUR_BANK             VARCHAR2(50 BYTE),
  CHK_NO               VARCHAR2(50 BYTE),
  DEALERPANEL          VARCHAR2(1 BYTE),
  DEALER_H             FLOAT(126),
  DEALER_W             FLOAT(126),
  DEALERTYPE           VARCHAR2(1 BYTE),
  ACTIVE_AGREEDRATE    NUMBER,
  ACTIVE_AGREEDAMT     NUMBER,
  LOCALGROSSAMT        NUMBER,
  LOCALBILLAMT         NUMBER,
  PACKAGE_TYPE         VARCHAR2(5 BYTE),
  AD_REFID             VARCHAR2(50 BYTE),
  RECEIPT_CURRENCY     VARCHAR2(8 BYTE),
  CONV_CURR_RATE       VARCHAR2(8 BYTE),
  REVISE_DATE          DATE,
  CLIENT_TYPE          VARCHAR2(5 BYTE),
  TRANSLATION_CODE     VARCHAR2(25 BYTE),
  TRANSLATION_PREMIUM  NUMBER,
  MODIFIED_AUDIT       VARCHAR2(1 BYTE),
  CANCELLATION_CHARGE  VARCHAR2(1 BYTE),
  RATE_AUDIT_FLAG      VARCHAR2(1 BYTE),
  RATE_AUDIT_IP        VARCHAR2(20 BYTE),
  RATE_AUDIT_BY        VARCHAR2(20 BYTE),
  RATE_AUDIT_DATE      DATE,
  TRN_TYPE             VARCHAR2(1 BYTE)
)


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
subedidata in varchar2,
disc_p in float,
    P_ip  in varchar2,
P_RATE_AUDIT_FLAG in varchar2
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
subedidata in varchar2,
disc_p in float,
    P_ip  in varchar2,
P_RATE_AUDIT_FLAG in varchar2
   )
   AS

insertdatem date;
   heightm  number;
    widthm  number;
    insertstatusm  varchar2(50);
    cioidm  varchar2(50);

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
heightm:=height;
    widthm:=width;
    insertstatusm:=insertstatus;
    cioidm:=cioid;
    insertdatem:=insertdate;
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

    insert into tbl_booking_insert("Cio_Booking_Id","Edition","Insert_Date","Col_Code","Height","Width","Size_Book","Page_Post","Premium1","Prem_Per1","Premium2","Prem_Per2","Premium_Allow","Ad_Cat","Ad_Sub_Cat","Latest_By","Status_Material","File_Name","Card_Rate","Disc_Rate","Insert_Status","Bill_Status","Comp_Code","Userid","Repeating_Date","No_Insert","Edition_Code","Publication_Code","Pub_Cent_Code","Supp_Code","Pai_Free_Ins","Agreed_Rate","Solo_Rate","Gross_Rate","Page_No","Remarks","Page_Prem","Page_Per","No_Ofcolumn","Bill_Amt","Bill_Rate","Logo_H", "Logo_W", "Logo_name","Insert_Id","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT,LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION,DISCOUNT)
    values(cioid,edition,insertdate,colid,height,width,totalsize,pagepost,premium1,premper1,premium2,premper2,premallow,adcategory,adsubcat1,latestdate,material,matfilename,cardrate,discrate,insertstatus,billstatus,compcode,userid,repeat,insertno,edi,publi,pub_cent,supp,paid,agrrate,solorate,grossrate,insert_pageno,insert_remarks,page_code,page_per,noofcol,billamt,billrate,logo_h,logo_w,logo_name,insertidval,ad_cat_3,ad_cat_4,ad_cat_5, pkgcode,gridins,pkgalias, splboldsizevalue,vatrate_p,boxcharge_p,vat_inc_p ,grossamtlocal_p,billamtlocal_p,sectioncode_p,resourceno_p,caption_inserts_p,disc_p);
       
    
      if(cirvts is not null) then
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                            values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
      end if;

        insert_edition_details_update(subedidata,null,cioid,insertidval,compcode,edi,insertdate,height,width,totalsize,insertstatus,pkgcode,insertno,insert_pageno,error1);
    else
        update  tbl_booking_insert set  "Edition"=edition,"Insert_Date"=insertdate,"Col_Code"=colid,"Height"=height,"Width"=width,"Size_Book"=totalsize,"Page_Post"=pagepost,"Premium1"=premium1,"Prem_Per1"=premper1,"Premium2"=premium2,"Prem_Per2"=premper2,"Premium_Allow"=premallow,"Ad_Cat"=adcategory,"Ad_Sub_Cat"=adsubcat1,"Latest_By"=latestdate,"Status_Material"=material,"File_Name"=matfilename,"Card_Rate"=cardrate,"Disc_Rate"=discrate,"Insert_Status"=insertstatus,"Bill_Status"=billstatus,"Comp_Code"=compcode,"Userid"=userid,"Repeating_Date"=repeat,"No_Insert"=insertno,"Edition_Code"=edi,"Publication_Code"=publi,"Pub_Cent_Code"=pub_cent,"Supp_Code"=supp,"Pai_Free_Ins"=paid,"Agreed_Rate"=agrrate,"Solo_Rate"=solorate,"Gross_Rate"=grossrate,"Page_No"=insert_pageno,"Remarks"=insert_remarks,"Page_Prem"=page_code,"Page_Per"=page_per,"No_Ofcolumn"=noofcol,"Bill_Amt"=billamt,"Bill_Rate"=billrate,"Logo_H"=logo_h, "Logo_W"=logo_w, "Logo_name"=logo_name,"AD_SUBCAT3"=ad_cat_3,"AD_SUBCAT4"=ad_cat_4,"AD_SUBCAT5"=ad_cat_5,PACKAGE_CODE=pkgcode,INSERTS=gridins,PKG_ALIAS=pkgalias, SPECIAL_SIZE1= splboldsizevalue,VATAMT=vatrate_p,BOXCHARGE=boxcharge_p,VAT_INC=vat_inc_p,LOCALGROSSAMT=grossamtlocal_p,LOCALBILLAMT=billamtlocal_p,SECTIONCODE=sectioncode_p,RESOURCE_NO=resourceno_p,CAPTION=caption_inserts_p, DISCOUNT=disc_p ,RATE_AUDIT_FLAG=P_ip,
RATE_AUDIT_IP =P_RATE_AUDIT_FLAG where "Cio_Booking_Id"=cioid and "Insert_Id" = insertid1;
        if(subedidata is null) then
        if insertstatus = 'cancel' then
                   update tbl_booking_subedition set INSERTSTATUS='cancel' where tbl_booking_subedition.cioid=cioid and insertid=insertid1
                and tbl_booking_subedition.INSERTSTATUS not in('publish','billed');
        ELSE
        update tbl_booking_subedition set tbl_booking_subedition.INSERTDATE=insertdatem,tbl_booking_subedition.HEIGHT=heightm,tbl_booking_subedition.WIDTH=widthm,tbl_booking_subedition.TOTALAREA=totalsize , tbl_booking_subedition.INSERTSTATUS=insertstatusm WHERE tbl_booking_subedition.CIOID= cioidm and tbl_booking_subedition.INSERTID=insertid1 and tbl_booking_subedition.INSERTSTATUS!='publish' and tbl_booking_subedition.INSERTSTATUS!='billed';            
        end if;
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


/**************************************************************************************************************/



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
subedidata in varchar2,
disc_p in float,
P_ip  in varchar2,
P_RATE_AUDIT_FLAG in varchar2
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
    subedidata in varchar2,
    disc_p in float,
    P_ip  in varchar2,
P_RATE_AUDIT_FLAG in varchar2
    )
   
AS
      heightm  number;
    widthm  number;
    insertstatusm  varchar2(50);
    cioidm  varchar2(50);
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
insertdatem date;
    BEGIN
    heightm:=height;
    widthm:=width;
    insertstatusm:=insertstatus;
    cioidm:=cioid;
    insertdatem:=insertdate;
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
        
        insert into tbl_booking_insert("Cio_Booking_Id","Edition","Insert_Date","Col_Code","Height","Width","Size_Book","Page_Post","Premium1","Prem_Per1","Premium2","Prem_Per2","Premium_Allow","Ad_Cat","Ad_Sub_Cat","Latest_By","Status_Material","File_Name","Card_Rate","Disc_Rate","Insert_Status","Bill_Status","Comp_Code","Userid","Repeating_Date","No_Insert","Edition_Code","Publication_Code","Pub_Cent_Code","Supp_Code","Pai_Free_Ins","Agreed_Rate","Solo_Rate","Gross_Rate","Page_No","Remarks","Page_Prem","Page_Per","No_Ofcolumn","Bill_Amt","Bill_Rate","Logo_H", "Logo_W", "Logo_name","Insert_Id","AD_SUBCAT3","AD_SUBCAT4","AD_SUBCAT5",PACKAGE_CODE,INSERTS,PKG_ALIAS,BOXCHARGE,VAT_INC,VATAMT,LOCALGROSSAMT,LOCALBILLAMT, SECTIONCODE,RESOURCE_NO,CAPTION,DEALER_H,DEALER_W,DISCOUNT)
        values(cioid,edition,insertdate,colid,height,width,totalsize,pagepost,premium1,premper1,premium2,premper2,premallow,adcategory,adsubcat1,latestdate,material,matfilename,cardrate,discrate,insertstatus,billstatus,compcode,userid,repeat,insertno,edi,publi,pub_cent,supp,paid,agrrate,solorate,grossrate,insert_pageno,insert_remarks,page_code,page_per,noofcol,billamt,billrate,logo_h,logo_w,logo_name,insertidval,ad_cat_3,ad_cat_4,ad_cat_5, pkgcode,gridins,pkgalias,boxcharge_p,vat_inc_p,vatrate_p,grossamtlocal_p,billamtlocal_p,sectioncode_p,resourceno_p,caption_inserts_p,dealerheight,dealerwidth,disc_p);
        if(cirvts is not null) then
        insert into tbl_booking_vts(COMPCODE,CIOID,INSERTID,VTS,PUBLICATION,EDITION,RATE,CIRAGCODE,CIRAGSUBCODE,CENTER,BRANCH,PUBLISHDATE)
                    values(compcode,cioid,insertidval,cirvts,cirpub,ciredi,cirrate,ciragency_v, ciragencysubcode_v, center_v, branch_v,cirdate_v);
        end if; 
         insert_edition_details_update(subedidata,null,cioid,insertidval,compcode,edi,insertdate,height,width,totalsize,insertstatus,pkgcode,insertno,insert_pageno,error1);
                   
    else
        update  tbl_booking_insert set "Edition"=edition,"Insert_Date"=insertdate,"Col_Code"=colid,"Height"=height,"Width"=width,"Size_Book"=totalsize,"Page_Post"=pagepost,"Premium1"=premium1,"Prem_Per1"=premper1,"Premium2"=premium2,"Prem_Per2"=premper2,"Premium_Allow"=premallow,"Ad_Cat"=adcategory,"Ad_Sub_Cat"=adsubcat1,"Latest_By"=latestdate,"Status_Material"=material,"File_Name"=matfilename,"Card_Rate"=cardrate,"Disc_Rate"=discrate,"Insert_Status"=insertstatus,"Bill_Status"=billstatus,"Comp_Code"=compcode,"Userid"=userid,"Repeating_Date"=repeat,"No_Insert"=insertno,"Edition_Code"=edi,"Publication_Code"=publi,"Pub_Cent_Code"=pub_cent,"Supp_Code"=supp,"Pai_Free_Ins"=paid,"Agreed_Rate"=agrrate,"Solo_Rate"=solorate,"Gross_Rate"=grossrate,"Page_No"=insert_pageno,"Remarks"=insert_remarks,"Page_Prem"=page_code,"Page_Per"=page_per,"No_Ofcolumn"=noofcol,"Bill_Amt"=billamt,"Bill_Rate"=billrate,"Logo_H"=logo_h, "Logo_W"=logo_w, "Logo_name"=logo_name,"AD_SUBCAT3"=ad_cat_3,"AD_SUBCAT4"=ad_cat_4,"AD_SUBCAT5"=ad_cat_5,PACKAGE_CODE=pkgcode,INSERTS=gridins,PKG_ALIAS=pkgalias,BOXCHARGE=boxcharge_p, VAT_INC=vat_inc_p,VATAMT=vatrate_p, LOCALGROSSAMT=grossamtlocal_p, LOCALBILLAMT=billamtlocal_p, SECTIONCODE=sectioncode_p, RESOURCE_NO=resourceno_p,CAPTION=caption_inserts_p,DEALER_H=dealerheight,DEALER_W=dealerwidth,DISCOUNT=disc_p ,RATE_AUDIT_FLAG=P_ip,
RATE_AUDIT_IP =P_RATE_AUDIT_FLAG where "Cio_Booking_Id"=cioid AND "Insert_Id"=insertid1;
        if(subedidata is null) then
            if insertstatus = 'cancel' then
              update tbl_booking_subedition set INSERTSTATUS='cancel' where tbl_booking_subedition.cioid=cioid and insertid=insertid1
                and tbl_booking_subedition.INSERTSTATUS not in('publish','billed');
                 ELSE
                update tbl_booking_subedition set tbl_booking_subedition.INSERTDATE=insertdatem,tbl_booking_subedition.HEIGHT=heightm,tbl_booking_subedition.WIDTH=widthm,tbl_booking_subedition.TOTALAREA=totalsize , tbl_booking_subedition.INSERTSTATUS=insertstatusm WHERE tbl_booking_subedition.CIOID= cioidm and tbl_booking_subedition.INSERTID=insertid1 and tbl_booking_subedition.INSERTSTATUS!='publish' and tbl_booking_subedition.INSERTSTATUS!='billed';
            end if;
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


/**********************************************************************************/






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
canclecharge in varchar2,
p_revisedate IN       DATE,
P_ip  in varchar2,
P_RATE_AUDIT_FLAG in varchar2
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
canclecharge in varchar2,
p_revisedate        IN DATE,
P_ip  in varchar2,
P_RATE_AUDIT_FLAG in varchar2
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
MODIFIED_AUDIT=v_modifed_audit,CANCELLATION_CHARGE=canclecharge,RATE_AUDIT_FLAG=P_RATE_AUDIT_FLAG,"Userid"=userid,RATE_AUDIT_IP=P_ip
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

/////////////////Start Issue no:7614(8/6/2012)/////////////////////////////////////



/////////////issue no 7785////////////////////////////


CREATE OR REPLACE PACKAGE HT18JULY.Gettheprevbooking Is

Type T_Accounts_Cursor Is Ref Cursor;
Procedure Gettheprevbooking_P(Compcode In Varchar2,vuserid In Varchar2,
Formname In Varchar2 ,
P_Accounts Out T_Accounts_Cursor,
P_Accounts1 Out T_Accounts_Cursor,
P_Accounts2 Out T_Accounts_Cursor,
P_Accounts3 Out T_Accounts_Cursor,
P_Accounts4 Out T_Accounts_Cursor,
P_Accounts5 Out T_Accounts_Cursor,
P_Accounts6 Out T_Accounts_Cursor,
P_Accounts7 Out T_Accounts_Cursor

);

End Gettheprevbooking;
/








CREATE OR REPLACE PACKAGE BODY HT18JULY.Gettheprevbooking Is

Procedure Gettheprevbooking_P(Compcode In Varchar2,vuserid In Varchar2,formname In Varchar2 ,
P_Accounts Out T_Accounts_Cursor,
P_Accounts1 Out T_Accounts_Cursor,
P_Accounts2 Out T_Accounts_Cursor,
P_Accounts3 Out T_Accounts_Cursor,
P_Accounts4 Out T_Accounts_Cursor,
P_Accounts5 Out T_Accounts_Cursor,
P_Accounts6 Out T_Accounts_Cursor,
P_Accounts7 Out T_Accounts_Cursor

) As

Begin

Open P_Accounts For
Select "cio_booking_id" From Tbl_Booking_Mast Where "Comp_code"=Compcode And "Userid"=Vuserid and "Ad_type_code"=formname AND ROWNUM<=1
Order By "Creation_datetime" Desc  ;


Open P_Accounts1 For
--Select "Retain_Name"  as "retain_name"From Retainermaster Where "Retain_Code" =(Select "retainer_code" From Login Where "COM_CODE"=Compcode And "userid"=vuserid);
SELECT "retainer_code",BOOKING_EDITLINES FROM LOGIN where "userid"=vuserid;


Open P_Accounts2 For
--Select "Backdate_booking" From Module_Detaibuttonl  Where "Form_Name"=formname And "comp_code"=Compcode And "userid"=vuserid;
SELECT "Allowed_old_date","AGENCYCOMM_SEQ_COM","CREDIT_RECIPT",BACKDATERECEIPT,DOCKIT_BOOKING,"copy_booking","book_insert_date",SEPRATE_CASHIER, MAX_PUBLISHDAYS,SPECIALDISC_TRANS_EDIT, SHARING_TRANS, MULTIPACKAGE_SEL_TRANS, nvl(SCHEME_MINWORD,'N'), nvl(TRADE_SPLCHARGE,'Y'),PUBLISHAD_EDIT_RATEAUDIT,NVL(PREMIUM_EDIT,'N') as PREMIUM_EDIT,NVL(SPLDISC_ALLOWPREM,'N') AS SPLDISC_ALLOWPREM,NVL(EDITABLE_AGENCY_COMM,'N') as EDITABLE_AGENCY_COMM,NVL(CANCELLATION_CHARGE,'N') as CANCELLATION_CHARGE, NVL(ALLOWPREM_CARD_DISC_RATE,'C') AS ALLOWPREM_CARD_DISC_RATE from PREFERRENCES where "comp_code" = Compcode;


Open P_Accounts3 For  Select "Agency_Name"||'('||"code_subcode" ||')' as "agency_name","Agency_Code" as "agency_code"From Agency_Mast Where "qbc_userid"=vuserid ;



Open P_Accounts4 For
Select "Confirm_qbc" as "Confirm_qbc" From Module_Detaibuttonl Where "Form_Name"='QBC' and "userid"=vuserid ;

Open P_Accounts5 For
select "Agency_Name" || '('||"code_subcode" ||')' ,"Agency_Code"  as "agency_code" from agency_mast  where "code_subcode" in (select "Agency_code" from login where "userid"=vuserid);

Open P_Accounts6 For
select   "Agency_Name" as "agency_name","code_subcode" from agency_mast where "Agency_Code" in    ( select "Agency_Code"  from agency_mast where "qbc_userid"=vuserid);

Open P_Accounts7 For

select   "Agency_Name" as "agency_name","code_subcode" as "code_subcode" from agency_mast where "Agency_Code" in    (select "Agency_Code" from agency_mast  where "code_subcode" in (select "Agency_code" from login where "userid"=vuserid));

End Gettheprevbooking_P;

End Gettheprevbooking;
/



///////////////end of issue 7785//////////done by shipra



////////////done by bhanu sir


CREATE OR REPLACE PROCEDURE HT18JULY.chkdiscountpremedit_per
 (
   compcode           IN       VARCHAR2,
   userid1               IN       VARCHAR2,
   
   p_accounts    OUT      cur_type_new1.cursor_type,
   p_accounts1    OUT      cur_type_new1.cursor_type
)
IS
BEGIN
   OPEN p_accounts FOR
         select PERMISSION_DESC from userpermission where COMM_CODE=compcode and USERID=userid1 and
          PERMISSION_DESC='Allow Editing Discount Item Line Wise In Transaction';
          
   OPEN p_accounts1 FOR
         select PERMISSION_DESC from userpermission where COMM_CODE=compcode and USERID=userid1 and
          PERMISSION_DESC='Not Allow Reset Paid Insertion In Transaction';
END;
/


////////////////////////end by bhanu sir ///////////////








start //////////////////////shipra//////////by bhanu sir////////////////////////


CREATE TABLE TBL_BOOKING_INSERT_Q
(
  INSERT_ID         NUMBER(10)                NOT NULL,
  CIO_BOOKING_ID    VARCHAR2(50 BYTE)         NOT NULL,
  NO_INSERT         NUMBER(10),
  EDITION_CODE      VARCHAR2(8 BYTE)          NOT NULL,
  PUBLICATION_CODE  VARCHAR2(8 BYTE)          NOT NULL,
  PUB_CENT_CODE     VARCHAR2(8 BYTE)          NOT NULL,
  SUPP_CODE         VARCHAR2(8 BYTE),
  EDITION           VARCHAR2(500 BYTE)        NOT NULL,
  INSERT_DATE       DATE,
  COL_CODE          VARCHAR2(8 BYTE),
  HEIGHT            FLOAT(126),
  WIDTH             FLOAT(126),
  SIZE_BOOK         FLOAT(126),
  PAGE_POST         VARCHAR2(8 BYTE),
  PREMIUM1          VARCHAR2(8 BYTE),
  PREM_PER1         FLOAT(126),
  PREMIUM2          VARCHAR2(8 BYTE),
  PREM_PER2         FLOAT(126),
  PREMIUM_ALLOW     VARCHAR2(2 BYTE),
  AD_CAT            VARCHAR2(8 BYTE),
  AD_SUB_CAT        VARCHAR2(8 BYTE),
  LATEST_BY         DATE,
  REPEATING_DATE    DATE,
  STATUS_MATERIAL   VARCHAR2(20 BYTE),
  FILE_NAME         VARCHAR2(100 BYTE),
  CARD_RATE         FLOAT(126),
  DISC_RATE         FLOAT(126),
  INSERT_STATUS     VARCHAR2(50 BYTE),
  BILL_STATUS       VARCHAR2(8 BYTE),
  AGREED_RATE       FLOAT(126),
  PAI_FREE_INS      VARCHAR2(2 BYTE),
  SOLO_RATE         FLOAT(126),
  GROSS_RATE        FLOAT(126),
  COMP_CODE         VARCHAR2(8 BYTE)          NOT NULL,
  USERID            VARCHAR2(8 BYTE)          NOT NULL,
  PAGE_NO           NUMBER(10),
  REMARKS           VARCHAR2(500 BYTE),
  PUB_HEIGHT        FLOAT(126),
  PUB_WIDTH         FLOAT(126),
  PAGE_PREM         VARCHAR2(8 BYTE),
  PAGE_PER          FLOAT(126),
  NO_OFCOLUMN       FLOAT(126),
  BILL_AMT          FLOAT(126),
  BILL_RATE         FLOAT(126),
  LOGO_H            VARCHAR2(5 BYTE),
  LOGO_W            VARCHAR2(5 BYTE),
  LOGO_NAME         VARCHAR2(100 BYTE),
  AD_SUBCAT3          VARCHAR2(15 BYTE),
  AD_SUBCAT4          VARCHAR2(15 BYTE),
  AD_SUBCAT5          VARCHAR2(15 BYTE),
  PACKAGE_CODE        VARCHAR2(100 BYTE),
  BILL_NO             VARCHAR2(100 BYTE),
  BILL_DATE           DATE,
  INSERTS             NUMBER,
  PKG_ALIAS           VARCHAR2(50 BYTE),
  CONT_GROSS_AMT      FLOAT(126),
  APP_STATUS          VARCHAR2(10 BYTE),
  APP_REMARKS         VARCHAR2(500 BYTE),
  APP_DATE            DATE                      DEFAULT NULL,
  APP_USER            VARCHAR2(50 BYTE),
  LOCKSTATUS          VARCHAR2(1 BYTE)          DEFAULT 'N',
  PROOFREAD           VARCHAR2(50 BYTE),
  SPECIAL_SIZE1       VARCHAR2(50 BYTE),
  SPECIAL_SIZE2       VARCHAR2(50 BYTE),
  VATAMT              FLOAT(126),
  BOXCHARGE           NUMBER,
  VAT_INC             VARCHAR2(2 BYTE),
  LOCALGROSSAMT       NUMBER,
  LOCALBILLAMT        NUMBER,
  SECTIONCODE         VARCHAR2(50 BYTE),
  RESOURCE_NO         VARCHAR2(50 BYTE),
  CAPTION             VARCHAR2(500 BYTE),
  DEALER_H            FLOAT(126),
  DEALER_W            FLOAT(126),
  DISCOUNT            FLOAT(126),
  RATE_AUDIT_FLAG     VARCHAR2(1 BYTE),
  RATE_AUDIT_IP       VARCHAR2(20 BYTE)
)







CREATE TABLE TBL_BOOKING_MAST_Q
(
  DATE_TIME           DATE                    DEFAULT SYSDATE               NOT NULL,
  BRANCH              VARCHAR2(25 BYTE)       NOT NULL,
  BOOKED_BY           VARCHAR2(25 BYTE)       NOT NULL,
  CIO_BOOKING_ID      VARCHAR2(50 BYTE)       NOT NULL,
  PREV_BOOKING        VARCHAR2(25 BYTE),
  APPLIED_BY          VARCHAR2(25 BYTE),
  AUDIT_Q               VARCHAR2(25 BYTE),
  RO_NO               VARCHAR2(40 BYTE),
  RO_DATE             DATE,
  CAPTION             VARCHAR2(500 BYTE),
  BILL_STATUS         VARCHAR2(8 BYTE)        NOT NULL,
  RO_STATUS           VARCHAR2(8 BYTE),
  AGENCY_CODE         VARCHAR2(15 BYTE),
  AGENCY_ADDRESS      VARCHAR2(500 BYTE),
  CLIENT_CODE         VARCHAR2(100 BYTE),
  CLIENT_ADDRESS      VARCHAR2(500 BYTE),
  AGENCY_SUB_CODE     VARCHAR2(20 BYTE),
  DOCKIT_NO           VARCHAR2(25 BYTE),
  EXECUTIVE_CODE      VARCHAR2(50 BYTE),
  EXECUTIVE_ZONE      VARCHAR2(50 BYTE),
  PRODUCT_CODE        VARCHAR2(20 BYTE),
  BRAND_CODE          VARCHAR2(20 BYTE),
  KEY_NO              VARCHAR2(50 BYTE),
  BILL_REMARKS        VARCHAR2(500 BYTE),
  PRINT_REMARK        VARCHAR2(500 BYTE),
  PACKAGE_CODE        VARCHAR2(500 BYTE)      NOT NULL,
  NO_OF_INSERTION     NUMBER,
  INSERTION_DATE      DATE,
  REPEATING_DAY       VARCHAR2(8 BYTE),
  AD_TYPE_CODE        VARCHAR2(8 BYTE),
  AD_CAT_CODE         VARCHAR2(8 BYTE),
  AD_SUB_CAT_CODE     VARCHAR2(50 BYTE),
  COLOR_CODE          VARCHAR2(8 BYTE),
  UOM_CODE            VARCHAR2(8 BYTE),
  PAGE_POSITION_CODE  VARCHAR2(8 BYTE),
  PAGE_TYPE_CODE      VARCHAR2(100 BYTE),
  PAGE_NO             NUMBER,
  AD_SIZE_TYPE_CODE   VARCHAR2(8 BYTE),
  AD_SIZE_HEIGHT      NUMBER,
  AD_SIZE_WIDTH       NUMBER,
  RATE_CODE           VARCHAR2(100 BYTE),
  SCHEME_TYPE_CODE    VARCHAR2(50 BYTE),
  CURRENCY_CODE       VARCHAR2(8 BYTE),
  AGRRED_RATE         NUMBER,
  AGREED_AMOUNT       NUMBER,
  SPECIAL_DISCOUNT    NUMBER,
  SPACE_DISCOUNT      NUMBER,
  SPECIAL_CHARGES     NUMBER,
  AGENCY_STATUS       VARCHAR2(15 BYTE),
  AGENCY_TYPE         VARCHAR2(25 BYTE),
  AGENCY_PAY          VARCHAR2(25 BYTE),
  AGENCY_CREDIT       NUMBER,
  TOTAL_AREA          NUMBER,
  CARD_RATE           NUMBER,
  CARD_AMOUNT         NUMBER,
  DISCOUNT            NUMBER,
  DISCOUNT_PER        NUMBER,
  BILL_CYCLE          VARCHAR2(8 BYTE),
  REVENUE_CENTER      VARCHAR2(50 BYTE),
  BILL_PAY            VARCHAR2(8 BYTE),
  BILL_HEIGHT         NUMBER,
  BILL_WIDTH          NUMBER,
  BILL_TO             VARCHAR2(100 BYTE),
  INVOICES            NUMBER,
  VTS                 NUMBER,
  BILL_ADD            VARCHAR2(500 BYTE),
  TRADE_DISC          NUMBER,
  AGENCY_OUT          VARCHAR2(50 BYTE),
  BOX_CODE            VARCHAR2(50 BYTE),
  BOX_NO              VARCHAR2(50 BYTE),
  BOX_AGENCY          VARCHAR2(2 BYTE),
  BOX_CLIENT          VARCHAR2(2 BYTE),
  BOX_ADDRESS         VARCHAR2(500 BYTE),
  COMP_CODE           VARCHAR2(8 BYTE)        NOT NULL,
  USERID              VARCHAR2(8 BYTE)        NOT NULL,
  CREATION_DATETIME   DATE                    NOT NULL,
  BOOKING_TYPE        VARCHAR2(8 BYTE),
  TFN                 VARCHAR2(2 BYTE),
  COUPAN_AD           VARCHAR2(2 BYTE),
  CAMPAIGN            VARCHAR2(50 BYTE),
  BILL_AMOUNT         NUMBER,
  PAGE_PREM           VARCHAR2(8 BYTE),
  PAGE_AMOUNT         NUMBER,
  PREM_PER            NUMBER,
  GROSS_AMOUNT        NUMBER,
  AD_SIZE_COLUMN      NUMBER,
  BILL_COLUMN         NUMBER,
  BILL_AREA           NUMBER,
  SPECIAL_DISC_PER    NUMBER,
  SPACE_DISC_PER      NUMBER,
  PAID_INS            NUMBER,
  CONTRACT_RATE       NUMBER,
  DEVIATION           NUMBER,
  VARIANT_CODE        VARCHAR2(8 BYTE),
  CONTRACT_NAME       VARCHAR2(50 BYTE),
  CONTRACT_TYPE       VARCHAR2(50 BYTE),
  CARD_NAME           VARCHAR2(100 BYTE),
  CARD_TYPE           VARCHAR2(50 BYTE),
  CARD_MONTH          VARCHAR2(8 BYTE),
  CARD_YEAR           VARCHAR2(8 BYTE),
  CARD_NUMBER         VARCHAR2(20 BYTE),
  RECEIPT_NO          VARCHAR2(50 BYTE),
  AD_SUBCAT3          VARCHAR2(8 BYTE),
  AD_SUBCAT4          VARCHAR2(8 BYTE),
  AD_SUBCAT5          VARCHAR2(8 BYTE),
  BG_COLOR            VARCHAR2(8 BYTE),
  BULLET_CODE         VARCHAR2(8 BYTE),
  BULLET_PREMIUM      NUMBER,
  MATERIAL_STATUS     VARCHAR2(20 BYTE),
  RECEIPT_DATE        DATE,
  PREV_CIOID          VARCHAR2(100 BYTE),
  PREV_RECEIPT        VARCHAR2(50 BYTE),
  PREV_GROSSAMT       NUMBER,
  REGION              VARCHAR2(8 BYTE),
  VARIANT             VARCHAR2(8 BYTE),
  COLORTYPE           VARCHAR2(8 BYTE),
  LOGO_H              VARCHAR2(5 BYTE),
  LOGO_W              VARCHAR2(5 BYTE),
  LOGO_COLOR          VARCHAR2(8 BYTE),
  LOGO_UOM            VARCHAR2(8 BYTE),
  SAPID                 VARCHAR2(10 BYTE),
  RETAINER              VARCHAR2(8 BYTE),
  ADD_AGENCY_COMM       VARCHAR2(8 BYTE),
  AUDIT_COMMENT         VARCHAR2(1000 BYTE),
  MOBILENO              VARCHAR2(50 BYTE),
  ADD_AGENCY_COMM_AMT   VARCHAR2(50 BYTE),
  RETAINER_COMM         VARCHAR2(50 BYTE),
  RETAINER_COMM_AMT     VARCHAR2(50 BYTE),
  CASH_RECIEVED         NUMBER,
  CONT_GROSS            NUMBER,
  CIRAGENCY             VARCHAR2(100 BYTE),
  CIRRATE               VARCHAR2(50 BYTE),
  CIREDITION            VARCHAR2(50 BYTE),
  CIRPUBLICATION        VARCHAR2(50 BYTE),
  CIRAGENCY_SUBCODE     VARCHAR2(50 BYTE),
  BARTER_TYPE           VARCHAR2(50 BYTE),
  APP_STATUS            VARCHAR2(10 BYTE),
  APP_REMARKS           VARCHAR2(500 BYTE),
  APP_DATE              DATE                    DEFAULT NULL,
  APP_USER              VARCHAR2(50 BYTE),
  RODOCSTATUS           VARCHAR2(25 BYTE),
  RO_COMMENT            VARCHAR2(500 BYTE),
  PROOFREAD             VARCHAR2(50 BYTE),
  CASHDISCOUNT          NUMBER,
  CASHDISCTYPE          VARCHAR2(5 BYTE),
  ATTACHMENT1           VARCHAR2(50 BYTE),
  ATTACHMENT2           VARCHAR2(50 BYTE),
  DISC_PREMIUM          VARCHAR2(50 BYTE),
  DOCTYPE               VARCHAR2(20 BYTE),
  CHKTRADEDISC          VARCHAR2(1 BYTE),
  CHK_DATE              DATE,
  CHK_AMT               FLOAT(126),
  CHK_BANK_NAME         VARCHAR2(50 BYTE),
  OUR_BANK              VARCHAR2(50 BYTE),
  CHK_NO                VARCHAR2(50 BYTE),
  DEALERPANEL           VARCHAR2(1 BYTE),
  DEALER_H              FLOAT(126),
  DEALER_W              FLOAT(126),
  DEALERTYPE            VARCHAR2(1 BYTE),
  ACTIVE_AGREEDRATE     NUMBER,
  ACTIVE_AGREEDAMT      NUMBER,
  LOCALGROSSAMT         NUMBER,
  LOCALBILLAMT          NUMBER,
  PACKAGE_TYPE          VARCHAR2(5 BYTE),
  AD_REFID              VARCHAR2(50 BYTE),
  RECEIPT_CURRENCY      VARCHAR2(8 BYTE),
  CONV_CURR_RATE        VARCHAR2(8 BYTE),
  REVISE_DATE           DATE,
  CLIENT_TYPE           VARCHAR2(5 BYTE),
  TRANSLATION_CODE      VARCHAR2(25 BYTE),
  TRANSLATION_PREMIUM   NUMBER,
  MODIFIED_AUDIT        VARCHAR2(50 BYTE),
  CANCELLATION_CHARGE   VARCHAR2(1 BYTE),
  RATE_AUDIT_FLAG       VARCHAR2(1 BYTE),
  RATE_AUDIT_IP         VARCHAR2(20 BYTE),
  TRANSLATION_DISC      VARCHAR2(10 BYTE),
  POSPREM_DISC          VARCHAR2(10 BYTE)
)


/////////////end /////////////////////by bhanu sir/////////////////



start ///////////shipra //////by bhanu sir/////////////////////



                                                                     
                                                                     
                                                                     
                                             
CREATE OR REPLACE PROCEDURE fetchbookingdealdata (
   pcompcode     IN       VARCHAR2,
   pfrdt         IN       VARCHAR2,
   ptodt         IN       VARCHAR2,
   pdeal         IN       VARCHAR2,
   pagency       IN       VARCHAR2,
   pclient       IN       VARCHAR2,
   ppub          IN       VARCHAR2,
   puid          IN       VARCHAR2,
   pfilter       IN       VARCHAR2,--A for all data, D for Deal data,I for Invocie data
   pdateformat   IN       VARCHAR2,
   p_accounts    OUT      cur_type_new1.cursor_type)
AS
BEGIN
    DELETE  FROM fetchbookingdeal_temp WHERE sess_id = USERENV ('SESSIONID'); COMMIT;
IF pfilter = 'A' THEN--all data
    BEGIN
        DECLARE 
        CURSOR c1 IS
            SELECT DISTINCT x."Comp_code" as comp_code, x."date_time" as bkdate,x."cio_booking_id" AS cio_booking_id,
            y."No_Insert" AS insert_id,y."Size_Book" AS size_book,
            NVL (NVL (x."Contract_rate", x."Agrred_rate"),x."Card_rate") AS bill_rate,
            a."Agency_Name" AS agency_name,(select "City_Name" from city_mst where "City_Code"=a."City_Code") as "CITY_NAME",
            x."Agency_sub_code" AS agency_sub_code,y.bill_no AS bill_no,
            (SELECT "Cust_Name" FROM cust_mast WHERE "Cust_Code" =x."Client_code") AS client_name,
            x."Client_code" AS client_code,
            NVL((SELECT MIN ("Dealarte")
                  FROM contract_detail, contract_mast
                 WHERE contract_mast."Deal_No" =contract_detail."deal_code" and
                    contract_detail."ContractCode" =x."Contract_name"),'') AS deal,
            (SELECT "deal_code" FROM contract_detail
                WHERE "ContractCode" =x."Contract_name") AS contract,
            y.bill_date AS bill_date,
            sum(y."Bill_Amt") AS bill_amt,'' as REMARKS,'' as CREDIT_NOTE_RATE,
            x."Trade_disc" as trade_disc,nvl((select distinct nvl(additional_flag,'0') from comm_details 
           where "Agency_code"||"Agency_sub_code"=x."Agency_sub_code" and
           x."date_time" between "Eff_from_Date" and "Eff_Till_Date"),'0') as additional_flag,
           y."Insert_Status" insert_status, y."Disc_Rate" disc_rate,
           x.add_agency_comm add_agency_comm, x.chktradedisc,
           x.translation_premium, x.translation_disc as translation_disc,
           (select distinct charges_type from ad_charge_mast where ad_charge_mast.charge_code=x.translation_code and 
           comp_code=x."Comp_code" and x."date_time" between valid_from_date and valid_till_date) as translation_type,
           (select charge_name from ad_charge_mast where ad_charge_mast.charge_code=x.translation_code and comp_code=x."Comp_code" 
            and x."date_time" between valid_from_date and valid_till_date) as translation_code,
           x."Special_discount" as special_discount,x."Space_discount" as space_discount,x."Special_charges" as special_charges,
           x."Package_code" as package_code,
           (select disc_type from disc_master where disc_code=x.disc_premium) as disc_type,
            x."Prem_per" as prem_per,x."Special_disc_per" as special_disc_per,x."Discount" as discount,
            x."Discount_per" discount_per,x."Space_disc_per" space_disc_per,x."Page_prem" as page_prem,
            x."Page_position_code" as page_position_code,
            x."Page_amount" as page_amount,x.posprem_disc as posprem_disc,
            x."Ad_type_code"as  ad_type,x."Uom_code" as uom_code 
            FROM tbl_booking_mast x, tbl_booking_insert y,agency_mast a
            WHERE  x."Comp_code"=y."Comp_Code" and x."cio_booking_id" = y."Cio_Booking_Id"
            AND x."Agency_sub_code" = nvl(pagency,x."Agency_sub_code")
            AND x."Agency_sub_code" =a."code_subcode"
            AND (x."Client_code" = pclient OR pclient IS NULL)
            AND ((SELECT "deal_code" FROM contract_detail
                 WHERE "ContractCode" = x."Contract_name") =pdeal OR pdeal IS NULL)
            AND y."Insert_Date" BETWEEN pfrdt AND ptodt and y."Insert_Status" not in('cancel','hold')
            group by x."Comp_code",x."date_time",x."cio_booking_id",y."No_Insert",y."Size_Book",
            NVL (NVL (x."Contract_rate", x."Agrred_rate"),x."Card_rate"),
            a."Agency_Name",a."City_Code", x."Agency_sub_code",y.bill_no,
            x."Client_code",x."Contract_name",y.bill_date,x."Trade_disc",
            y."Insert_Status", y."Disc_Rate",x.add_agency_comm, x.chktradedisc,
            x.translation_premium,x.translation_disc,x.translation_code,
            x."Special_discount",x."Space_discount",x."Special_charges",x."Package_code",
            x.disc_premium,x."Prem_per" ,x."Special_disc_per",x."Discount",
            x."Discount_per",x."Space_disc_per",x."Page_prem",
            x."Ad_type_code",x."Uom_code",x."Page_position_code",x."Page_amount",x.posprem_disc ;

v       c1%ROWTYPE;
v_cnt   NUMBER;
BEGIN
    OPEN c1;
    LOOP
        FETCH c1 INTO v;
        EXIT WHEN c1%NOTFOUND;

               SELECT COUNT (*) INTO v_cnt FROM ad_deal_credit_provision
                WHERE CIO_BOOKING_ID=v.cio_booking_id and insert_id = v.insert_id;

               IF v_cnt = 0 THEN
                  INSERT INTO fetchbookingdeal_temp
                              (cio_booking_id, insert_id, size_book,
                               bill_rate, agency_name,
                               agency_sub_code, bill_no, client_name,
                               client_code, deal, contract,
                               bill_date, bill_amt, sess_id,REMARKS,CREDIT_NOTE_RATE,TRADE_DISC,
                               Insert_Status, Disc_Rate,add_agency_comm,chktradedisc,
                               translation_premium ,translation_disc,translation_type,
                               special_discount,space_discount ,special_charges,package_code,
                               disc_type ,prem_per,special_disc_per ,
                               discount,discount_per,space_disc_per ,--premium_charges_type,
                               ad_type,uom_code,ag_city,
                               translation_code ,page_prem ,page_position_code ,page_amount ,posprem_disc)
                       VALUES (v.cio_booking_id, v.insert_id, v.size_book,
                               v.bill_rate, v.agency_name,
                               v.agency_sub_code, v.bill_no, v.client_name,
                               v.client_code, v.deal, v.contract,
                               v.bill_date, v.bill_amt, userenv ('SESSIONID'),v.remarks,v.credit_note_rate,
                              v.trade_disc,v.Insert_Status, v.Disc_Rate,v.add_agency_comm,v.chktradedisc,
                               v.translation_premium ,v.translation_disc,v.translation_type,
                               v.special_discount,v.space_discount ,v.special_charges,v.package_code,
                               v.disc_type ,v.prem_per,v.special_disc_per ,
                               v.discount,v.discount_per,v.space_disc_per ,--v.premium_charges_type,
                               v.ad_type,v.uom_code,v.city_name,
                               v.translation_code ,v.page_prem ,v.page_position_code ,v.page_amount ,v.posprem_disc);
               ELSE
                  INSERT INTO fetchbookingdeal_temp
                              (cio_booking_id, insert_id, size_book,
                               bill_rate, agency_name, agency_sub_code,
                               bill_no, client_name, client_code, deal,
                               contract, bill_date, bill_amt, sess_id,REMARKS,CREDIT_NOTE_RATE,TRADE_DISC,
                               Insert_Status, Disc_Rate,add_agency_comm,chktradedisc,
                               translation_premium ,translation_disc,translation_type,
                               special_discount,space_discount ,special_charges,package_code,
                               disc_type ,prem_per,special_disc_per ,
                               discount,discount_per,space_disc_per ,--premium_charges_type,
                               ad_type,uom_code,ag_city,
                               translation_code ,page_prem ,page_position_code ,page_amount ,posprem_disc)
                     SELECT cio_booking_id, insert_id, total_insertion,
                            bill_rate, (SELECT "Agency_Name"
                                          FROM agency_mast
                                         WHERE "code_subcode" = agency_code),
                            agency_code, bill_no,
                            (SELECT "Cust_Name"
                               FROM cust_mast
                              WHERE "Cust_Code" = client_code), client_code,
                            /*credit_note_rate*/DISCOUNTED_RATE, contract_id, bill_date,
                            bill_amount, USERENV ('SESSIONID'),REMARKS,CREDIT_NOTE_RATE,TRADE_DISC,
                            Insert_Status, Disc_Rate,add_agency_comm,chktradedisc,
                            translation_premium ,translation_disc,translation_type,
                            special_discount,space_discount ,special_charges,package_code,
                            disc_type ,prem_per,special_disc_per ,
                            discount,discount_per,space_disc_per ,--premium_charges_type,
                            ad_type,uom_code,ag_city,
                            translation_code ,page_prem ,page_position_code ,page_amount ,posprem_disc
                       FROM ad_deal_credit_provision
                      WHERE CIO_BOOKING_ID=v.cio_booking_id and insert_id = v.insert_id;
               END IF;
            END LOOP;
            CLOSE c1;
         END;
      END;

      OPEN p_accounts FOR
         SELECT t.cio_booking_id cio_booking_id, t.insert_id insert_id, t.size_book size_book, 
            t.bill_rate bill_rate, t.agency_name agency_name,
                t.agency_sub_code agency_sub_code, t.bill_no bill_no, t.client_name client_name, t.client_code client_code, 
                t.deal deal,t.contract contract, t.bill_date bill_date, t.bill_amt bill_amt,t.REMARKS REMARKS,t.CREDIT_NOTE_RATE CREDIT_NOTE_RATE,
                t.TRADE_DISC TRADE_DISC,
                t.insert_status insert_status, t.disc_rate disc_rate,t.add_agency_comm add_agency_comm,t.chktradedisc chktradedisc,
                t.translation_premium translation_premium,t.translation_disc translation_disc,t.translation_type translation_type,
                t.special_discount special_discount,t.space_discount space_discount,t.special_charges special_charges,t.package_code package_code,
                t.disc_type disc_type,t.prem_per prem_per,t.special_disc_per special_disc_per,
                t.discount discount,t.discount_per discount_per,t.space_disc_per space_disc_per,
                t.ad_type ad_type,t.uom_code uom_code,t.ag_city ag_city,t.PAGE_PREM PAGE_PREM,t.Page_position_code Page_position_code,
                (select "premium_charges_type" from advpos_prem_mast where "Premiumcode" =t.Page_prem and "comp_code"=pcompcode) as premium_charges_type,
                (select "premiumname" from advpos_prem_mast where "Premiumcode" =t.Page_prem and "comp_code"=pcompcode) as premium_charges_name,
                (select distinct "Pos_Type" from advpos_type_mast  where "Pos_Type_Code" = t.Page_position_code and "Comp_Code"=pcompcode) as pos_type,
                (select distinct "Premium" from advpos_type_mast  where "Pos_Type_Code" = t.Page_position_code and "Comp_Code"=pcompcode) as premium,
                t.page_amount page_amount,t.posprem_disc posprem_disc 
           FROM fetchbookingdeal_temp t
          WHERE sess_id = USERENV ('SESSIONID');
END IF;

IF pfilter = 'D' THEN
    BEGIN
         DECLARE
            CURSOR c1 IS
                SELECT DISTINCT x."Comp_code" as comp_code,x."date_time" as bkdate,x."cio_booking_id" AS cio_booking_id,
                    y."No_Insert" AS insert_id,y."Size_Book" AS size_book,
                    NVL (NVL (x."Contract_rate", x."Agrred_rate"),x."Card_rate") AS bill_rate,
                    a."Agency_Name" AS agency_name,(select "City_Name" from city_mst where "City_Code"=a."City_Code") as city_name,
                    x."Agency_sub_code" AS agency_sub_code,y.bill_no AS bill_no,
                    (SELECT "Cust_Name" FROM cust_mast
                    WHERE "Cust_Code" =x."Client_code") AS client_name,
                    x."Client_code" AS client_code,
                    NVL((SELECT MIN ("Dealarte")
                    FROM contract_detail, contract_mast
                    WHERE contract_mast."Deal_No" =contract_detail."deal_code" and
                    contract_detail."ContractCode" =x."Contract_name"),'') AS deal,
                    (SELECT "deal_code" FROM contract_detail
                    WHERE "ContractCode" =x."Contract_name") AS contract,
                    y.bill_date AS bill_date,
                    sum(y."Bill_Amt") AS bill_amt,'' as REMARKS,'' as CREDIT_NOTE_RATE,
                    x."Trade_disc" as trade_disc,nvl((select distinct nvl(additional_flag,'0') from comm_details 
                   where "Agency_code"||"Agency_sub_code"=x."Agency_sub_code" and
                   x."date_time" between "Eff_from_Date" and "Eff_Till_Date"),'0') as additional_flag,
                   y."Insert_Status" insert_status, y."Disc_Rate" disc_rate,
                   x.add_agency_comm add_agency_comm, x.chktradedisc,
                   x.translation_premium, x.translation_disc as translation_disc,
                   (select distinct charges_type from ad_charge_mast where ad_charge_mast.charge_code=x.translation_code and 
                    comp_code=x."Comp_code" and x."date_time" between valid_from_date and valid_till_date) as translation_type,
                    (select charge_name from ad_charge_mast where ad_charge_mast.charge_code=x.translation_code and comp_code=x."Comp_code" 
                    and x."date_time" between valid_from_date and valid_till_date) as translation_code,                    
                    x."Special_discount" as special_discount,x."Space_discount" as space_discount,x."Special_charges" as special_charges,
                    x."Package_code" as package_code,
                    (select disc_type from disc_master where disc_code=x.disc_premium) as disc_type,
                    x."Prem_per" as prem_per,x."Special_disc_per" as special_disc_per,x."Discount" as discount,
                    x."Discount_per" discount_per,x."Space_disc_per" space_disc_per,x."Page_prem" as page_prem,
                    x."Page_position_code" as page_position_code,
                    x."Page_amount" as page_amount,x.posprem_disc as posprem_disc,
                    x."Ad_type_code"as  ad_type,x."Uom_code" as uom_code
                    FROM tbl_booking_mast x, tbl_booking_insert y,agency_mast a
                    WHERE x."Comp_code"=y."Comp_Code" and x."cio_booking_id" = y."Cio_Booking_Id"
                    AND x."Agency_sub_code" = nvl(pagency,x."Agency_sub_code")
                    AND x."Agency_sub_code" = a."code_subcode"
                    AND (x."Client_code" = pclient OR pclient IS NULL)
                    AND ((SELECT "deal_code"
                    FROM contract_detail
                    WHERE "ContractCode" = x."Contract_name") =pdeal OR pdeal IS NULL)
                    AND y."Insert_Date" BETWEEN pfrdt AND ptodt
                    AND x."Contract_name" IS NOT NULL and y."Insert_Status" not in('cancel','hold')
                group by x."Comp_code" ,x."date_time",x."cio_booking_id",y."No_Insert",y."Size_Book",
                NVL (NVL (x."Contract_rate", x."Agrred_rate"),x."Card_rate"),
                a."Agency_Name" ,a."City_Code",
                x."Agency_sub_code" ,y.bill_no,x."Client_code",
                x."Contract_name",y.bill_date,x."Trade_disc",y."Insert_Status", y."Disc_Rate",
                x.add_agency_comm, x.chktradedisc,x.translation_premium, x.translation_disc,x.translation_code,
                x."Special_discount",x."Space_discount",x."Special_charges",x."Package_code",
                x.disc_premium,x."Prem_per" ,x."Special_disc_per",x."Discount",
                x."Discount_per",x."Space_disc_per",x."Page_prem",
                x."Ad_type_code",x."Uom_code",x."Page_position_code",x."Page_amount",x.posprem_disc;

            v       c1%ROWTYPE;
            v_cnt   NUMBER;
        BEGIN
            OPEN c1;
            LOOP
               FETCH c1 INTO v;
               EXIT WHEN c1%NOTFOUND;

               SELECT COUNT (*) INTO v_cnt
                 FROM ad_deal_credit_provision
                WHERE CIO_BOOKING_ID=v.cio_booking_id and insert_id = v.insert_id;

               IF v_cnt = 0 THEN
                  INSERT INTO fetchbookingdeal_temp
                              (cio_booking_id, insert_id, size_book,
                               bill_rate, agency_name,
                               agency_sub_code, bill_no, client_name,
                               client_code, deal, contract,
                               bill_date, bill_amt, sess_id,REMARKS,CREDIT_NOTE_RATE,TRADE_DISC,
                               Insert_Status, Disc_Rate,add_agency_comm,chktradedisc,
                               translation_premium ,translation_disc,translation_type,
                               special_discount,space_discount ,special_charges,package_code,
                               disc_type ,prem_per,special_disc_per ,
                               discount,discount_per,space_disc_per ,--premium_charges_type,
                               ad_type,uom_code,ag_city,
                               translation_code ,page_prem ,page_position_code ,page_amount ,posprem_disc
                              )
                       VALUES (v.cio_booking_id, v.insert_id, v.size_book,
                               v.bill_rate, v.agency_name,
                               v.agency_sub_code, v.bill_no, v.client_name,
                               v.client_code, v.deal, v.contract,
                               v.bill_date, v.bill_amt, USERENV ('SESSIONID'),v.remarks,v.credit_note_rate,v.trade_disc,
                               v.Insert_Status, v.Disc_Rate,v.add_agency_comm,v.chktradedisc,
                               v.translation_premium ,v.translation_disc,v.translation_type,
                               v.special_discount,v.space_discount ,v.special_charges,v.package_code,
                               v.disc_type ,v.prem_per,v.special_disc_per ,
                               v.discount,v.discount_per,v.space_disc_per ,--v.premium_charges_type,
                               v.ad_type,v.uom_code,v.city_name,
                               v.translation_code ,v.page_prem ,v.page_position_code ,v.page_amount ,v.posprem_disc);
               ELSE
                  INSERT INTO fetchbookingdeal_temp
                              (cio_booking_id, insert_id, size_book,
                               bill_rate, agency_name, agency_sub_code,
                               bill_no, client_name, client_code, deal,
                               contract, bill_date, bill_amt, sess_id,remarks,credit_note_rate,trade_disc,
                               Insert_Status, Disc_Rate,add_agency_comm,chktradedisc,
                               translation_premium ,translation_disc,translation_type,
                               special_discount,space_discount ,special_charges,package_code,
                               disc_type ,prem_per,special_disc_per ,
                               discount,discount_per,space_disc_per ,--premium_charges_type,
                               ad_type,uom_code,ag_city,
                               translation_code ,page_prem ,page_position_code ,page_amount ,posprem_disc)
                     SELECT cio_booking_id, insert_id, total_insertion,
                            bill_rate, (SELECT "Agency_Name"
                                          FROM agency_mast
                                         WHERE "code_subcode" = agency_code),
                            agency_code, bill_no,
                            (SELECT "Cust_Name"
                               FROM cust_mast
                              WHERE "Cust_Code" = client_code), client_code,
                            /*credit_note_rate*/DISCOUNTED_RATE, contract_id, bill_date,
                            bill_amount, USERENV ('SESSIONID'),REMARKS,CREDIT_NOTE_RATE,TRADE_DISC,
                            Insert_Status, Disc_Rate,add_agency_comm,chktradedisc,
                            translation_premium ,translation_disc,translation_type,
                            special_discount,space_discount ,special_charges,package_code,
                            disc_type ,prem_per,special_disc_per ,
                            discount,discount_per,space_disc_per ,--premium_charges_type,
                            ad_type,uom_code,ag_city,
                            translation_code ,page_prem ,page_position_code ,page_amount ,posprem_disc
                       FROM ad_deal_credit_provision
                      WHERE CIO_BOOKING_ID=v.cio_booking_id and insert_id = v.insert_id;
               END IF;
            END LOOP;
            CLOSE c1;
        END;
    END;

    OPEN p_accounts FOR
    SELECT t.cio_booking_id cio_booking_id, t.insert_id insert_id, t.size_book size_book, t.bill_rate bill_rate, t.agency_name agency_name,
    t.agency_sub_code agency_sub_code, t.bill_no bill_no, t.client_name client_name, t.client_code client_code, t.deal deal,
    t.contract contract, t.bill_date bill_date, t.bill_amt bill_amt,t.remarks remarks,t.credit_note_rate credit_note_rate,t.trade_disc trade_disc,
    t.insert_status insert_status, t.disc_rate disc_rate,t.add_agency_comm add_agency_comm,t.chktradedisc chktradedisc,
    t.translation_premium translation_premium,t.translation_disc translation_disc, t.translation_type translation_type,
    t.special_discount special_discount,t.space_discount space_discount,t.special_charges special_charges,t.package_code package_code,
    t.disc_type disc_type,t.prem_per prem_per,t.special_disc_per special_disc_per,
    t.discount discount,t.discount_per discount_per,t.space_disc_per space_disc_per,--premium_charges_type,
    t.ad_type ad_type,t.uom_code uom_code,t.ag_city ag_city,t.page_prem page_prem,t.page_position_code page_position_code,
    (select "premium_charges_type" from advpos_prem_mast where "Premiumcode" =t.page_prem and "comp_code"=pcompcode) as premium_charges_type,
    (select "premiumname" from advpos_prem_mast where "Premiumcode" =t.page_prem and "comp_code"=pcompcode) as premium_charges_name,
    (select distinct "Pos_Type" from advpos_type_mast  where "Pos_Type_Code" = t.page_position_code and "Comp_Code"=pcompcode) as pos_type,
    (select distinct "Premium" from advpos_type_mast  where "Pos_Type_Code" = t.page_position_code and "Comp_Code"=pcompcode) as premium,
    t.page_amount page_amount,t.posprem_disc posprem_disc
    FROM fetchbookingdeal_temp t
    WHERE sess_id = USERENV ('SESSIONID');
END IF;

IF pfilter = 'I' THEN
      BEGIN
         DECLARE
            CURSOR c1 IS
               SELECT DISTINCT x."Comp_code" as comp_code,x."date_time" as bkdate, x."cio_booking_id" AS cio_booking_id,
                               y."No_Insert" AS insert_id,y."Size_Book" AS size_book,
                               NVL (NVL (x."Contract_rate", x."Agrred_rate"),x."Card_rate") AS bill_rate,
                               a."Agency_Name" AS agency_name,(select "City_Name" from city_mst where "City_Code"=a."City_Code") as city_name,
                               x."Agency_sub_code" AS agency_sub_code,y.bill_no AS bill_no,
                               (SELECT "Cust_Name" FROM cust_mast
                                 WHERE "Cust_Code" = x."Client_code") AS client_name,
                               x."Client_code" AS client_code,
                               NVL((SELECT MIN ("Dealarte")
                                      FROM contract_detail, contract_mast
                                     WHERE contract_mast."Deal_No" =contract_detail."deal_code" and
                                        contract_detail."ContractCode" =x."Contract_name"),'') AS deal,
                               (SELECT "deal_code"
                                  FROM contract_detail
                                 WHERE "ContractCode" = x."Contract_name")AS contract,
                               y.bill_date AS bill_date,
                               round(sum(y."Bill_Amt")) AS bill_amt,'' as REMARKS,'' as CREDIT_NOTE_RATE,
                               x."Trade_disc" as trade_disc,nvl((select distinct nvl(additional_flag,'0') from comm_details 
                               where "Agency_code"||"Agency_sub_code"=x."Agency_sub_code" and
                               x."date_time" between "Eff_from_Date" and "Eff_Till_Date"),'0') as additional_flag,
                               y."Insert_Status" insert_status, y."Disc_Rate" disc_rate,
                               x.add_agency_comm add_agency_comm, x.chktradedisc,
                               x.translation_premium, x.translation_disc as translation_disc,
                               (select distinct charges_type from ad_charge_mast where ad_charge_mast.charge_code=x.translation_code and 
                                comp_code=x."Comp_code" and x."date_time" between valid_from_date and valid_till_date) as translation_type,
                                (select charge_name from ad_charge_mast where ad_charge_mast.charge_code=x.translation_code and comp_code=x."Comp_code" 
                                and x."date_time" between valid_from_date and valid_till_date) as translation_code,                                
                                x."Special_discount" as special_discount,x."Space_discount" as space_discount,x."Special_charges" as special_charges,
                                x."Package_code" as package_code,
                                (select disc_type from disc_master where disc_code=x.disc_premium) as disc_type,
                                x."Prem_per" as prem_per,x."Special_disc_per" as special_disc_per,x."Discount" as discount,
                                x."Discount_per" discount_per,x."Space_disc_per" space_disc_per,
                                x."Page_prem" as page_prem,
                                x."Page_position_code" as page_position_code,
                                x."Page_amount" as page_amount,x.posprem_disc as posprem_disc,
                                x."Ad_type_code" as  ad_type,x."Uom_code" as uom_code
                          FROM tbl_booking_mast x, tbl_booking_insert y,agency_mast a
                         WHERE x."Comp_code"=y."Comp_Code" and x."cio_booking_id" = y."Cio_Booking_Id"
                           AND x."Agency_sub_code" = nvl(pagency,x."Agency_sub_code")
                           and x."Agency_sub_code"=a."code_subcode"
                           AND (x."Client_code" = pclient OR pclient IS NULL)
                           AND ((SELECT "deal_code" FROM contract_detail
                                     WHERE "ContractCode" = x."Contract_name") = pdeal OR pdeal IS NULL)
                           AND y.bill_date BETWEEN pfrdt AND ptodt
                           AND y.bill_no IS NOT NULL and y."Insert_Status" not in('cancel','hold')
                           group by x."Comp_code",x."date_time" ,x."cio_booking_id",y."No_Insert",y."Size_Book",
                               NVL (NVL (x."Contract_rate", x."Agrred_rate"),x."Card_rate"),
                               a."Agency_Name",a."City_Code",x."Agency_sub_code",y.bill_no,
                               x."Client_code",x."Contract_name",y.bill_date,x."Trade_disc",
                               y."Insert_Status", y."Disc_Rate",x.add_agency_comm, x.chktradedisc,
                               x.translation_premium ,x.translation_disc,x.translation_code,
                               x."Special_discount",x."Space_discount",x."Special_charges",x."Package_code",
                               x.disc_premium,x."Prem_per" ,x."Special_disc_per",x."Discount",
                               x."Discount_per",x."Space_disc_per",x."Page_prem",
                               x."Ad_type_code",x."Uom_code",x."Page_position_code",x."Page_amount",x.posprem_disc;

            v       c1%ROWTYPE;
            v_cnt   NUMBER;
         BEGIN
            OPEN c1;
            LOOP
               FETCH c1 INTO v;
               EXIT WHEN c1%NOTFOUND;

               SELECT COUNT (*) INTO v_cnt
                 FROM ad_deal_credit_provision
                WHERE CIO_BOOKING_ID=v.cio_booking_id and insert_id = v.insert_id;

               IF v_cnt = 0 THEN
                  INSERT INTO fetchbookingdeal_temp
                              (cio_booking_id, insert_id, size_book,
                               bill_rate, agency_name,
                               agency_sub_code, bill_no, client_name,
                               client_code, deal, contract,
                               bill_date, bill_amt, sess_id,REMARKS,CREDIT_NOTE_RATE,trade_disc,
                               Insert_Status, Disc_Rate,add_agency_comm,chktradedisc,
                               translation_premium ,translation_disc,translation_type,
                               special_discount,space_discount ,special_charges,package_code,
                               disc_type ,prem_per,special_disc_per ,
                               discount,discount_per,space_disc_per ,--premium_charges_type,
                               ad_type,uom_code,ag_city,
                               translation_code ,page_prem ,page_position_code ,page_amount ,posprem_disc
                              )
                       VALUES (v.cio_booking_id, v.insert_id, v.size_book,
                               v.bill_rate, v.agency_name,
                               v.agency_sub_code, v.bill_no, v.client_name,
                               v.client_code, v.deal, v.contract,
                               v.bill_date, v.bill_amt, userenv ('SESSIONID'),v.remarks,v.credit_note_rate,v.trade_disc,
                               v.Insert_Status, v.Disc_Rate,v.add_agency_comm,v.chktradedisc,
                               v.translation_premium ,v.translation_disc,v.translation_type,
                               v.special_discount,v.space_discount ,v.special_charges,v.package_code,
                               v.disc_type ,v.prem_per,v.special_disc_per ,
                               v.discount,v.discount_per,v.space_disc_per ,--v.premium_charges_type,
                               v.ad_type,v.uom_code,v.city_name,
                               v.translation_code ,v.page_prem ,v.page_position_code ,v.page_amount ,v.posprem_disc);
               ELSE
                  INSERT INTO fetchbookingdeal_temp
                              (cio_booking_id, insert_id, size_book,
                               bill_rate, agency_name, agency_sub_code,
                               bill_no, client_name, client_code, deal,
                               contract, bill_date, bill_amt, sess_id,REMARKS,CREDIT_NOTE_RATE,trade_disc,
                               Insert_Status, Disc_Rate,add_agency_comm,chktradedisc,
                               translation_premium ,translation_disc,translation_type,
                               special_discount,space_discount ,special_charges,package_code,
                               disc_type ,prem_per,special_disc_per ,
                               discount,discount_per,space_disc_per ,premium_charges_type,
                               ad_type,uom_code,ag_city,
                               translation_code ,page_prem ,page_position_code ,page_amount ,posprem_disc)
                     SELECT cio_booking_id, insert_id, total_insertion,
                            bill_rate, (SELECT "Agency_Name" FROM agency_mast WHERE "code_subcode" = agency_code),
                            agency_code, bill_no,
                            (SELECT "Cust_Name" FROM cust_mast WHERE "Cust_Code" = client_code), client_code,
                            /*credit_note_rate*/DISCOUNTED_RATE, contract_id, bill_date,
                            bill_amount, USERENV ('SESSIONID'),REMARKS,CREDIT_NOTE_RATE,trade_disc,
                            Insert_Status, Disc_Rate,add_agency_comm,chktradedisc,
                               translation_premium ,translation_disc,translation_type,
                               special_discount,space_discount ,special_charges,package_code,
                               disc_type ,prem_per,special_disc_per ,
                               discount,discount_per,space_disc_per ,premium_charges_type,
                               ad_type,uom_code,ag_city,
                               translation_code ,page_prem ,page_position_code ,page_amount ,posprem_disc
                       FROM ad_deal_credit_provision WHERE CIO_BOOKING_ID=v.cio_booking_id and insert_id = v.insert_id;
               END IF;
            END LOOP;
            CLOSE c1;
         END;
      END;

      OPEN p_accounts FOR
         SELECT t.cio_booking_id cio_booking_id, t.insert_id insert_id, t.size_book size_book, t.bill_rate bill_rate, t.agency_name agency_name,
                t.agency_sub_code agency_sub_code, t.bill_no bill_no, t.client_name client_name, t.client_code client_code, t.deal deal,
                t.contract contract, t.bill_date bill_date, t.bill_amt bill_amt,t.remarks remarks,t.credit_note_rate credit_note_rate,t.trade_disc trade_disc,
                t.insert_status insert_status, t.disc_rate disc_rate,t.add_agency_comm add_agency_comm,t.chktradedisc chktradedisc,
                t.translation_premium translation_premium,t.translation_disc translation_disc,t.translation_type translation_type,
                t.special_discount special_discount,t.space_discount space_discount,t.special_charges special_charges,t.package_code package_code,
                t.disc_type disc_type,t.prem_per prem_per,t.special_disc_per special_disc_per,
                t.discount discount,t.discount_per discount_per,t.space_disc_per space_disc_per,--t.premium_charges_type,
                t.ad_type ad_type,t.uom_code uom_code,t.ag_city ag_city,t.page_prem page_prem,t.page_position_code page_position_code,
    (select "premium_charges_type" from advpos_prem_mast where "Premiumcode" =t.page_prem and "comp_code"=pcompcode) as premium_charges_type,
    (select "premiumname" from advpos_prem_mast where "Premiumcode" =t.page_prem and "comp_code"=pcompcode) as premium_charges_name,
    (select distinct "Pos_Type" from advpos_type_mast  where "Pos_Type_Code" = t.page_position_code and "Comp_Code"=pcompcode) as pos_type,
    (select distinct "Premium" from advpos_type_mast  where "Pos_Type_Code" = t.page_position_code and "Comp_Code"=pcompcode) as premium,
    t.page_amount page_amount,t.posprem_disc posprem_disc    
           FROM fetchbookingdeal_temp t
          WHERE sess_id = USERENV ('SESSIONID');
END IF;

   DELETE  FROM fetchbookingdeal_temp WHERE sess_id = USERENV ('SESSIONID'); COMMIT;
END fetchbookingdealdata;
/


////////////////////end ////////////by bhanu sir//////////






/////start////////by bhanu sir//////////////////////////////////////

CREATE OR REPLACE PROCEDURE websp_updatefilename_CD
(
    compcode IN varchar2,
    fname in varchar2,
    idnum in varchar2,
    insnum in number,
    insertid in varchar2,
    peditioncode in varchar2,
    p_Accounts out Cur_Type_New1.cursor_type
)

Is
    ediflag varchar2(1);
    begin
        select edition_flag into ediflag from clfd_ad_ros where idnum=idnum and insnum=insnum and pagination_id=insertid 
        and edition=peditioncode;           -- (select substr(fname,instr(fname,'-',-1)+1) from dual);

        if ediflag='S' then
            update tbl_booking_subedition set FileName=fname where CioId=idnum and No_Insert=insnum and InsertId=insertid 
            and edition=peditioncode;    --(select substr(fname,instr(fname,'-',-1)+1) from dual);
            update tbl_booking_insert set "File_Name"=fname where "Cio_Booking_Id"=idnum and "No_Insert"=insnum and "Insert_Id"=insertid;
            commit;
            
            open p_Accounts for
            select FileName from tbl_booking_subedition where CioId=idnum and No_Insert=insnum and InsertId=insertid 
            and edition=peditioncode; --(select substr(fname,instr(fname,'-',-1)+1) from dual);
        else
            update tbl_booking_insert set "File_Name"=fname where "Cio_Booking_Id"=idnum and "No_Insert"=insnum and "Insert_Id"=insertid;
           -- update ad_dummy_data set "file_name"=fname,updateflag='Y' where "idnum"=idnum and "insnum"=insertid and "ronum"=insnum and "edition_code"=peditioncode;
            commit;
            
            open p_Accounts for
            select "File_Name" from tbl_booking_insert where "Cio_Booking_Id"=idnum and "No_Insert"=insnum and "Insert_Id"=insertid;
        end if;

end ;
/



///////////////////////end by bhanu sir///////////////////


===start======avinash====7854=====26jun2012==============================================

CREATE OR REPLACE PROCEDURE websp_rep_material_log(
    pinsdate   date,
    pcenter    varchar2,
    pusername  varchar2,
    pextra1    varchar2,
    pextra2    varchar2,
    p_Accounts OUT CUR_TYPE_NEW1.CURSOR_TYPE)IS
BEGIN
    
    open p_accounts for
    select username,originalname,sapname,insdate,bkfor,(select "Pub_Cent_name" from pub_cent_mast 
    where "Pub_cent_Code"=allthumbimage_log.bkfor) bkfor_name, upd_datetime from allthumbimage_log
    where insdate=pinsdate and bkfor=nvl(pcenter,bkfor) and (username=pusername or pusername is null)
    order by originalname;
    
END websp_rep_material_log;
/
===end======avinash====7854=====26jun2012==============================================

=======updated by dimple=================================issue no 7799==============================
                                                                     
                                                                     
                                                                     
                                             
CREATE OR REPLACE procedure login_user_report 
(pcomp_code     in  varchar2,
pbranch         in  varchar2,
pusername       in  varchar2,
proleid         in  varchar2,
pstatus         in  varchar2,
pdateformat     in  varchar2,
pextra1         in  varchar2,
pextra2         in  varchar2,
pextra3         in  varchar2,
pextra4         in  varchar2,
pextra5         in  varchar2,
p_accounts      out cur_type_new1.cursor_type) is
Begin

     open p_accounts for 
     select "userid" userid,"username" username,firstname, lastname,
    "Agency_code",(select "Agency_Name" from agency_mast where "code_subcode"=login."Agency_code") agency_name,
    "retainer_code" branch,(select "Branch_Name" from branch_mst where "Branch_Code"=login."retainer_code") branch_name, 
    (select "Comp_Name" from comp_mst where "Comp_Code"=login.com_code) comp_name,email, discount,roleid,null as rolename,  
    case when "Admin"='Yes' then 'ADMIN' else 'USER' end login_type,  case when filter='D' then 'District Wise' 
    when filter='P' then 'Publ Center Wise' else 'All' end filter_type, 
    booking_editlines,  case when status='A' then 'Active' else 'Inactive' end status,  
    hr_code,(select distinct name from hr_emp_mst where hr_code=login.hr_code and rownum<=1),
    acc_code,(select acc_name from fa_acc_mast where comp_code=login.com_code and cdp=login.acc_code) acc_name,
    null as branch_permission 
    from login where "username" like pusername||'%' and 
    "retainer_code"=nvl(pbranch,"retainer_code") and roleid=nvl(proleid,roleid) and 
    status=nvl(pstatus,status) order by username;
    
End login_user_report;
/


========================================end issue no 7799==========================================









