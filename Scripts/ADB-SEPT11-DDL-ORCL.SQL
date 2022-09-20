
/*********************** Mimoh 15/9/2011 4912 *******************/
exec add_col_in_table ('AGENCY_MAST','VAT','VARCHAR2(1)',null) ;
/*********************** Mimoh 15/9/2011 4912 *******************/





/*********************** Mimoh 20/9/2011 0004914 *******************/
exec add_col_in_table ('PREFERRENCES','OUTSTANDING_AMT_CRITERIA','VARCHAR2(5)',null) ;
/*********************** Mimoh 20/9/2011 0004914 ******************

/**************************4-oct-2011********************************/
exec add_table('LOGININFO',
'CREATE TABLE LOGININFO
(
  COMPCODE   VARCHAR2(50 BYTE),
  USERID     VARCHAR2(50 BYTE),
  STARTTIME  DATE,
  LASTUSED   DATE,
  IP         VARCHAR2(50 BYTE),
  SESSIONID  VARCHAR2(50 BYTE)
)');


exec add_table('LOGININFO_LOG',
'CREATE TABLE LOGININFO_LOG
(
  COMPCODE   VARCHAR2(50 BYTE),
  USERID     VARCHAR2(50 BYTE),
  STARTTIME  DATE,
  ENDTIME    DATE,
  IP         VARCHAR2(50 BYTE),
  SESSIONID  VARCHAR2(50 BYTE)
)');

exec add_col_in_table('COMP_MST','LICENSE_INFO','varchar2(100)',null)	 ;

exec add_col_in_table('COMP_MST','LAST_KEY_UPDATE ','Date',null)	 ;

exec add_col_in_table('COMP_MST','LAST_KEY_UPDATED_BY','varchar2(50)',null)	 ;


/************0005269********** Mimoh 10/10/2011  *******************/
exec add_col_in_table ('PREFERRENCES','GENRATE_CIR_AGCD','NUMBER (2)',null) ;
/*******************0005269*** Mimoh 10/10/2011  ******************


/***************************Kuldeep Bhati 12/10/2011***0005318 ****************************/

exec add_col_in_table ('PREFERRENCES','DISP_AUDITBKG','varchar2(5)',null)	 ;
/***************************Kuldeep Bhati 12/10/2011******0005318 ************************/

/***************************Kuldeep Bhati 12/10/2011***0005330 ****************************/

exec add_col_in_table ('uom_mast','FLAG','varchar2(5)',null)	 ;
/***************************Kuldeep Bhati 12/10/2011******0005330 ************************/

/***************************Kuldeep Bhati 13/10/2011***0004884   ****************************/

exec add_col_in_table ('LOGIN','STATUS','varchar2(20)',null)	 ;
/***************************Kuldeep Bhati 13/10/2011******0004884  ************************/


/************0005143********** Mimoh 16/10/2011  *******************/

exec add_col_in_table ('Client_Cont_details','MOBILENO','VARCHAR2(50)',null) ;
exec add_col_in_table ('Client_Cont_details','ANNIVERSARY','DATE',null) ;




/*******************0005143*** Mimoh 16/10/2011  ******************




/*********************** Mimoh 19/10/2011 5373 *******************/
exec add_col_in_table ('PREFERRENCES','CIR_DIS_AUTO_POSTING ','VARCHAR2(1)',null) ;
/*********************** Mimoh 19/10/2011 5373 ******************


/***************** Lata 24oct11 ***********************/
exec add_table('TBL_EXT_BOOKING_RPT_DET',
'create table TBL_EXT_BOOKING_RPT_DET
(BOOKINGID VARCHAR2(50),
RECEIPTNO VARCHAR2(50),
COMPCODE VARCHAR2(20),
USERID VARCHAR2(20),
IP_USER VARCHAR2(20),
DATE_TIME DATE)');


/*********************** LATA  31/10/2011  *******************/
exec add_col_in_table ('PREFERRENCES','RELAUTHREQON','VARCHAR2(1)',null) ;
exec add_col_in_table 'colcm','AD_TYPE','VARCHAR(10)',null;
*********************************************************************
/*********************mimoh 31oct 2011********************0005464*****/
exec add_col_in_table ('Adv_Exec_Master','SIGN','VARCHAR2(50)',null) ;

exec add_col_in_table ('RetainerMaster','SIGN','VARCHAR2(50)',null) ;
/************************************************************
////////////////////////////
CREATE OR REPLACE PACKAGE Bindaudit
IS
  TYPE T_ACCOUNT_CURSOR IS REF CURSOR;

  PROCEDURE bindaudit_p(fromdate IN VARCHAR2,todate IN VARCHAR2,date1 IN VARCHAR2,BRANCH1 IN VARCHAR2,Adtype IN VARCHAR2,
  audittype IN VARCHAR2
  ,branch2 IN VARCHAR2,
  v_Cat in varchar2,
  v_userid in varchar2,
  comp_code in varchar2:=null,
  v_package_code in varchar2,
  P_ACCOUNT OUT T_ACCOUNT_CURSOR);
END Bindaudit;
/


//////////////// strating of 5689





CREATE OR REPLACE PACKAGE BODY bindaudit
IS
   PROCEDURE bindaudit_p (
      fromdate    IN       VARCHAR2,
      todate      IN       VARCHAR2,
      date1       IN       VARCHAR2,
      branch1     IN       VARCHAR2,
      adtype      IN       VARCHAR2,
      audittype   IN       VARCHAR2,
      branch2     IN       VARCHAR2,
      v_cat       IN       VARCHAR2,
      v_userid    IN       VARCHAR2,
      comp_code   in varchar2:=null,
      v_package_code in varchar2,
      p_account   OUT      t_account_cursor
   )
   AS
   RELAUTHREQ  varchar2(1);
   BEGIN
   select RELAUTHREQON INTO RELAUTHREQ from preferrences where ("comp_code"=comp_code or comp_code is null) ;
      INSERT INTO test1
                  (vstring
                  )
           VALUES (   'fromdate '
                   || fromdate
                   || ' todate '
                   || todate
                   || ' date1 '
                   || date1
                   || ' BRANCH1 '
                   || branch1
                   || ' Adtype '
                   || adtype
                   || ' audittype '
                   || audittype
                   || ' branch2 '
                   || branch2
                   || ' v_Cat '
                   || v_cat
                   || ' v_userid '
                   || v_userid
                  );

      COMMIT;
  
      IF audittype = 'audit'
      THEN
        IF RELAUTHREQ = 'A' THEN
                 IF (branch1 = 'All' AND branch2 IS NULL)
                 THEN
                    OPEN p_account FOR
                       SELECT "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                          and tbl_booking_mast.APP_STATUS='Y'    
                          AND tbl_booking_mast."branch" IN (
                                 SELECT branch_mst."Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                              )
                                              and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                              
                                              and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                              ;
                 ELSE
                    OPEN p_account FOR
                       SELECT "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "branch" IN (
                                 SELECT "Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                    AND "pub_center" = branch1)
                           and tbl_booking_mast.APP_STATUS='Y'            
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL)
                            and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                          ;
                 END IF;
        ELSIF RELAUTHREQ ='D' THEN
                 IF (branch1 = 'All' AND branch2 IS NULL)
                 THEN
                    OPEN p_account FOR
                       SELECT "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                          and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')    
                          AND tbl_booking_mast."branch" IN (
                                 SELECT branch_mst."Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                                and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"                                           
                                              )
                                                  and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                              ;
                 ELSE
                    OPEN p_account FOR
                       SELECT "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "branch" IN (
                                 SELECT "Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                    AND "pub_center" = branch1)
                          and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')          
                          AND "Ad_type_code" = adtype
                          AND "audit" IS NOT NULL
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                              
                                and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                    and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null )
                                ;
                 END IF;
        ELSE
            IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NOT NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                      
                                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         ELSE
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NOT NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                      
                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                        
                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         END IF;
        END IF;
         
      END IF;

      IF audittype = 'unaudit'
      THEN
      IF RELAUTHREQ = 'A' THEN
        IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                   and tbl_booking_mast.APP_STATUS='Y'     
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         -- SELECT "cio_booking_id",nvl((select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code","audit","Ad_type_code",(select "File_Name" from tbl_booking_insert where "Cio_Booking_Id"=tbl_booking_mast."cio_booking_id" and "File_Name" is not null and rownum<=1) as "FILENAME" FROM TBL_BOOKING_MAST WHERE  "date_time" BETWEEN fromdate AND todate AND "Ad_type_code"=Adtype AND "audit" IS  NULL and ("branch"=branch2 OR  branch2 IS NULL) and (tbl_booking_mast."Ad_cat_code"=v_Cat OR  v_Cat IS NULL);
         ELSE
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                   and tbl_booking_mast.APP_STATUS='Y'           
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                      
                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         END IF;
      ELSIF RELAUTHREQ = 'D' THEN
        IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')    
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                      
                                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         -- SELECT "cio_booking_id",nvl((select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code","audit","Ad_type_code",(select "File_Name" from tbl_booking_insert where "Cio_Booking_Id"=tbl_booking_mast."cio_booking_id" and "File_Name" is not null and rownum<=1) as "FILENAME" FROM TBL_BOOKING_MAST WHERE  "date_time" BETWEEN fromdate AND todate AND "Ad_type_code"=Adtype AND "audit" IS  NULL and ("branch"=branch2 OR  branch2 IS NULL) and (tbl_booking_mast."Ad_cat_code"=v_Cat OR  v_Cat IS NULL);
         ELSE
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast ,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                  and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')          
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                      
                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                        
                            and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         END IF;
      ELSE
        IF (branch1 = 'All' AND branch2 IS NULL)
         THEN
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                            and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                          and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         -- SELECT "cio_booking_id",nvl((select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code","audit","Ad_type_code",(select "File_Name" from tbl_booking_insert where "Cio_Booking_Id"=tbl_booking_mast."cio_booking_id" and "File_Name" is not null and rownum<=1) as "FILENAME" FROM TBL_BOOKING_MAST WHERE  "date_time" BETWEEN fromdate AND todate AND "Ad_type_code"=Adtype AND "audit" IS  NULL and ("branch"=branch2 OR  branch2 IS NULL) and (tbl_booking_mast."Ad_cat_code"=v_Cat OR  v_Cat IS NULL);
         ELSE
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" = branch1)
                  AND "Ad_type_code" = adtype
                  AND "audit" IS NULL
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                      
                          and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"  
                          and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
                      
         END IF;
      END IF;
         
      END IF;

      IF audittype != 'unaudit' AND audittype != 'audit'
      THEN
        IF RELAUTHREQ = 'A' THEN
                     IF (branch1 = 'All')
                     THEN
                        OPEN p_account FOR
                           SELECT "cio_booking_id",
                                  NVL ((SELECT "Cust_Name"
                                          FROM cust_mast
                                         WHERE "Cust_Code" = "Client_code"),
                                       "Client_code"
                                      ) AS "Client_code",
                                  "audit", "Ad_type_code",
                                  (SELECT "File_Name"
                                     FROM tbl_booking_insert
                                    WHERE "Cio_Booking_Id" =
                                             tbl_booking_mast."cio_booking_id"
                                      AND "File_Name" IS NOT NULL
                                      AND ROWNUM <= 1) AS "FILENAME",
                                  CASE date1
                                     WHEN 'mm/dd/yyyy'
                                        THEN TO_CHAR
                                               ("Creation_datetime",
                                                'mm/dd/yyyy'
                                               )
                                     WHEN 'dd/mm/yyyy'
                                        THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                     WHEN 'yyyy/mm/dd'
                                        THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                                  END AS "Creation_datetime"
                             FROM tbl_booking_mast,tbl_booking_insert
                            WHERE "date_time" BETWEEN fromdate AND todate
                              AND "Ad_type_code" = adtype
                              AND ("branch" = branch2 OR branch2 IS NULL)
                              AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                                  )
                             and tbl_booking_mast.APP_STATUS='Y'     
                              AND tbl_booking_mast."branch" IN (
                                     SELECT branch_mst."Branch_Name"
                                       FROM branch_mst
                                      WHERE branch_mst."Branch_Code" IN (
                                               SELECT lb.branch_code
                                                 FROM login_branch_mast lb
                                                WHERE lb.user_code = v_userid
                                                  AND NVL (lb.user_flag, 'N') = 'Y'))
                                                     and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"  
                                                  and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
                                                  
                                                  
                     ELSE
                        OPEN p_account FOR
                           SELECT "cio_booking_id",
                                  NVL ((SELECT "Cust_Name"
                                          FROM cust_mast
                                         WHERE "Cust_Code" = "Client_code"),
                                       "Client_code"
                                      ) AS "Client_code",
                                  "audit", "Ad_type_code",
                                  (SELECT "File_Name"
                                     FROM tbl_booking_insert
                                    WHERE "Cio_Booking_Id" =
                                             tbl_booking_mast."cio_booking_id"
                                      AND "File_Name" IS NOT NULL
                                      AND ROWNUM <= 1) AS "FILENAME",
                                  CASE date1
                                     WHEN 'mm/dd/yyyy'
                                        THEN TO_CHAR
                                               ("Creation_datetime",
                                                'mm/dd/yyyy'
                                               )
                                     WHEN 'dd/mm/yyyy'
                                        THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                     WHEN 'yyyy/mm/dd'
                                        THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                                  END AS "Creation_datetime"
                             FROM tbl_booking_mast, tbl_booking_insert
                            WHERE "date_time" BETWEEN fromdate AND todate
                              AND "branch" IN (
                                     SELECT "Branch_Code"
                                       FROM branch_mst
                                      WHERE branch_mst."Branch_Code" IN (
                                               SELECT lb.branch_code
                                                 FROM login_branch_mast lb
                                                WHERE lb.user_code = v_userid
                                                  AND NVL (lb.user_flag, 'N') = 'Y')
                                        AND "pub_center" =
                                                        (SELECT "Pub_cent_Code"
                                                           FROM pub_cent_mast
                                                          WHERE "Pub_cent_Code" = branch1))
                              and tbl_booking_mast.APP_STATUS='Y'                            
                              AND "Ad_type_code" = adtype
                              AND ("branch" = branch2 OR branch2 IS NULL)
                              AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                                  )  and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                  and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
                                  
                     END IF;
        ELSIF RELAUTHREQ = 'D' THEN
                 IF (branch1 = 'All')
                 THEN
                    OPEN p_account FOR
                       SELECT "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "Ad_type_code" = adtype
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                          and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A')    
                          AND tbl_booking_mast."branch" IN (
                                 SELECT branch_mst."Branch_Name"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y'))
                                                and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                                and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
                                                
                 ELSE
                    OPEN p_account FOR
                       SELECT "cio_booking_id",
                              NVL ((SELECT "Cust_Name"
                                      FROM cust_mast
                                     WHERE "Cust_Code" = "Client_code"),
                                   "Client_code"
                                  ) AS "Client_code",
                              "audit", "Ad_type_code",
                              (SELECT "File_Name"
                                 FROM tbl_booking_insert
                                WHERE "Cio_Booking_Id" =
                                         tbl_booking_mast."cio_booking_id"
                                  AND "File_Name" IS NOT NULL
                                  AND ROWNUM <= 1) AS "FILENAME",
                              CASE date1
                                 WHEN 'mm/dd/yyyy'
                                    THEN TO_CHAR
                                           ("Creation_datetime",
                                            'mm/dd/yyyy'
                                           )
                                 WHEN 'dd/mm/yyyy'
                                    THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                                 WHEN 'yyyy/mm/dd'
                                    THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                              END AS "Creation_datetime"
                         FROM tbl_booking_mast,tbl_booking_insert
                        WHERE "date_time" BETWEEN fromdate AND todate
                          AND "branch" IN (
                                 SELECT "Branch_Code"
                                   FROM branch_mst
                                  WHERE branch_mst."Branch_Code" IN (
                                           SELECT lb.branch_code
                                             FROM login_branch_mast lb
                                            WHERE lb.user_code = v_userid
                                              AND NVL (lb.user_flag, 'N') = 'Y')
                                    AND "pub_center" =
                                                    (SELECT "Pub_cent_Code"
                                                       FROM pub_cent_mast
                                                      WHERE "Pub_cent_Code" = branch1))
                          AND "Ad_type_code" = adtype
                            and (Fn_Deviatio(tbl_booking_mast."Card_rate",tbl_booking_mast."Agrred_rate") is not null OR Fn_chkSalesExec(tbl_booking_mast."Userid")='SE0' OR  RELAUTHREQ = 'A') 
                          AND ("branch" = branch2 OR branch2 IS NULL)
                          AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                              )
                                and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                              and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
                 END IF;
        ELSE
             IF (branch1 = 'All')
         THEN
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "Ad_type_code" = adtype
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                  AND tbl_booking_mast."branch" IN (
                         SELECT branch_mst."Branch_Name"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y'))
                                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                                        and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         ELSE
            OPEN p_account FOR
               SELECT "cio_booking_id",
                      NVL ((SELECT "Cust_Name"
                              FROM cust_mast
                             WHERE "Cust_Code" = "Client_code"),
                           "Client_code"
                          ) AS "Client_code",
                      "audit", "Ad_type_code",
                      (SELECT "File_Name"
                         FROM tbl_booking_insert
                        WHERE "Cio_Booking_Id" =
                                 tbl_booking_mast."cio_booking_id"
                          AND "File_Name" IS NOT NULL
                          AND ROWNUM <= 1) AS "FILENAME",
                      CASE date1
                         WHEN 'mm/dd/yyyy'
                            THEN TO_CHAR
                                   ("Creation_datetime",
                                    'mm/dd/yyyy'
                                   )
                         WHEN 'dd/mm/yyyy'
                            THEN TO_CHAR ("Creation_datetime", 'dd/mm/yyyy')
                         WHEN 'yyyy/mm/dd'
                            THEN TO_CHAR ("Creation_datetime", 'yyyy/mm/dd')
                      END AS "Creation_datetime"
                 FROM tbl_booking_mast,tbl_booking_insert
                WHERE "date_time" BETWEEN fromdate AND todate
                  AND "branch" IN (
                         SELECT "Branch_Code"
                           FROM branch_mst
                          WHERE branch_mst."Branch_Code" IN (
                                   SELECT lb.branch_code
                                     FROM login_branch_mast lb
                                    WHERE lb.user_code = v_userid
                                      AND NVL (lb.user_flag, 'N') = 'Y')
                            AND "pub_center" =
                                            (SELECT "Pub_cent_Code"
                                               FROM pub_cent_mast
                                              WHERE "Pub_cent_Code" = branch1))
                  AND "Ad_type_code" = adtype
                  AND ("branch" = branch2 OR branch2 IS NULL)
                  AND (tbl_booking_mast."Ad_cat_code" = v_cat OR v_cat IS NULL
                      )
                        and tbl_booking_mast."cio_booking_id" =tbl_booking_insert."Cio_Booking_Id"
                        
                        and (tbl_booking_insert."PACKAGE_CODE"= v_package_code or v_package_code is null );
         END IF;
        END IF;
        
      END IF;
   END bindaudit_p;
END bindaudit;
/
/////////////////end of 5689


//////////////issue no 7947//////////////////////


 ALTER TABLE temp_adv_NEW1 ADD (ATTACHMENT VARCHAR2(100 BYTE) );


ALTER TABLE Exec_mast ADD (ATTACHMENT VARCHAR2(50 BYTE) );





////////////end of issue 7947//////////////////

