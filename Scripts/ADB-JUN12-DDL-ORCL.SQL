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






////////////shipra ////////////done by lata mam//////////////////////


ALTER TABLE HT18JULY.EDITION_MAST
ADD (GROUPCODE NUMBER);

ALTER TABLE HT18JULY.TMPINS
ADD (GROUPCODE NUMBER);

ALTER TABLE HT18JULY.TMP2
ADD (GROUPCODE NUMBER);


///////////////////end by shipra/////////////////////////////////////



===start=======avinash=====================================by lata mam======
 alter table tbl_booking_mast add rate_audit_ip varchar2(20);

  alter table tbl_booking_insert add rate_audit_ip varchar2(20);
    alter table PREFERRENCES add rate_audit_log_required varchar2(1);

alter table  tbl_booking_mast add rate_audit_flag varchar2(1)
alter table  tbl_booking_insert add rate_audit_flag varchar2(1)

    alter table tbl_booking_mast add TRANSLATION_DISC varchar2(10);
        alter table tbl_booking_mast add POSPREM_DISC varchar2(10);
   
      alter table tbl_booking_mast_g add TRANSLATION_DISC varchar2(10)
        alter table tbl_booking_mast_g add POSPREM_DISC varchar2(10)

alter table tempbooking_mast add TRANSLATION_DISC varchar2(10);
        alter table tempbooking_mast add POSPREM_DISC varchar2(10)
===End=======avinash=====================================by lata mam======


/////////start//////shipra/////////////////by bhanu sir//////////////////////////


ALTER TABLE FETCHBOOKINGDEAL_TEMP ADD ( ADDITIONAL_FLAG  varchar2(8),INSERT_STATUS varchar2(50),DISC_RATE number(18,2),
ADD_AGENCY_COMM varchar2(8), CHKTRADEDISC varchar2(1),TRANSLATION_PREMIUM number(15,2),TRANSLATION_DISC number(15,2))

ALTER TABLE AD_DEAL_CREDIT_PROVISION ADD (ADDITIONAL_FLAG  VARCHAR2(8),INSERT_STATUS VARCHAR2(50),DISC_RATE NUMBER(18,2),
ADD_AGENCY_COMM VARCHAR2(8), CHKTRADEDISC VARCHAR2(1),TRANSLATION_PREMIUM NUMBER(15,2),TRANSLATION_DISC NUMBER(15,2))

ALTER TABLE FETCHBOOKINGDEAL_TEMP ADD (TRANSLATION_TYPE VARCHAR2(10),
SPECIAL_DISCOUNT number(15,2),SPACE_DISCOUNT number(15,2),SPECIAL_CHARGES number(15,2),PACKAGE_CODE VARCHAR2(500))

ALTER TABLE AD_DEAL_CREDIT_PROVISION ADD (TRANSLATION_TYPE VARCHAR2(10),
SPECIAL_DISCOUNT number(15,2),SPACE_DISCOUNT number(15,2),SPECIAL_CHARGES number(15,2),PACKAGE_CODE VARCHAR2(500))

ALTER TABLE FETCHBOOKINGDEAL_TEMP ADD
(DISC_TYPE VARCHAR2 (1),PREM_PER NUMBER(15,2),SPECIAL_DISC_PER NUMBER(15,2),
DISCOUNT NUMBER(15,2),DISCOUNT_PER NUMBER(15,2),SPACE_DISC_PER NUMBER(15,2),PREMIUM_CHARGES_TYPE VARCHAR2 (8))

ALTER TABLE AD_DEAL_CREDIT_PROVISION ADD
(DISC_TYPE VARCHAR2 (1),PREM_PER NUMBER(15,2),SPECIAL_DISC_PER NUMBER(15,2),
DISCOUNT NUMBER(15,2),DISCOUNT_PER NUMBER(15,2),SPACE_DISC_PER NUMBER(15,2),PREMIUM_CHARGES_TYPE VARCHAR2 (8))

ALTER TABLE FETCHBOOKINGDEAL_TEMP ADD (AG_CITY VARCHAR2(30),AD_TYPE VARCHAR2(8),UOM_CODE VARCHAR2(8))

ALTER TABLE AD_DEAL_CREDIT_PROVISION ADD (AG_CITY VARCHAR2(30),AD_TYPE VARCHAR2(8),UOM_CODE VARCHAR2(8))


//////////end /////shipra////////////////// bhanu sir///////////////////////



//////////////////start 6/19/2012/////shipra//////////////////done by bahnu sir//////////


ALTER TABLE FETCHBOOKINGDEAL_TEMP ADD(TRANSLATION_CODE VARCHAR2(8),PAGE_PREM VARCHAR2(8),
PAGE_POSITION_CODE VARCHAR2(8),PAGE_AMOUNT NUMBER,POSPREM_DISC VARCHAR2(30))

ALTER TABLE AD_DEAL_CREDIT_PROVISION ADD(TRANSLATION_CODE VARCHAR2(8),PAGE_PREM VARCHAR2(8),
PAGE_POSITION_CODE VARCHAR2(8),PAGE_AMOUNT NUMBER,POSPREM_DISC VARCHAR2(30))


//////////end ////6//19/2012/////shipra//////////////////done by bahnu sir//////////











//////////start////////shipra/////////////////bhanu sir//////////////



ALTER TABLE FETCHBOOKINGDEAL_TEMP ADD(BKDATE    DATE)

ALTER TABLE AD_DEAL_CREDIT_PROVISION ADD(BKDATE    DATE)


////////end //////shipra/////////////////////bhanu sir///////////



==start==========7854===avinash=============================26/06/2012=========

CREATE TABLE ALLTHUMBIMAGE_LOG
( ORIGINALNAME VARCHAR2(1000 BYTE),
  SAPNAME VARCHAR2(30 BYTE),
  FLAG CHAR(1 BYTE) DEFAULT 'N',
  INSDATE DATE,
  PRIPUB VARCHAR2(5 BYTE),
  BKFOR VARCHAR2(3 BYTE),
  EDITION VARCHAR2(3 BYTE),
  SECPUB VARCHAR2(8 BYTE),
  USERNAME VARCHAR2(50 BYTE),
  MACHINE_IP VARCHAR2(20 BYTE),
  UPD_DATETIME DATE)

==end==========7854===avinash=============================26/06/2012=========






