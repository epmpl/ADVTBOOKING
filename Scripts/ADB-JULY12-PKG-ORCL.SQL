=======start===========avinash by mimoh=================16july2012=========================
CREATE OR REPLACE PROCEDURE updateexestatus_slab (
   compcode   IN   VARCHAR2,
   userid     IN   VARCHAR2,
   execode    IN   VARCHAR2,
   code       IN   NUMBER,
   fromdays   IN   NUMBER,
   todays     IN   NUMBER,
   common     IN   VARCHAR2,
   commrate   IN   NUMBER
)
AS
BEGIN
   UPDATE executive_comm_slab
      SET comp_code = compcode,
          from_days = fromdays,
          till_days = todays,
          comm_on = common,
          comm_rate = commrate,
          updated_by = userid,
          updated_date = SYSDATE
    WHERE enln = code AND exe_code = execode;

   COMMIT;
END;

******************************************************************


CREATE OR REPLACE PROCEDURE exeselectslab (
   compcode     IN       VARCHAR2,
   userid       IN       VARCHAR2,
   execode      IN       VARCHAR2,
   code11       IN       NUMBER,
   p_accounts   OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT "ENLN", "FROM_DAYS", "TILL_DAYS", "COMM_ON", "COMM_RATE"
        FROM executive_comm_slab
       WHERE "COMP_CODE" = compcode
         AND "EXE_CODE" = execode
         AND "ENLN" = code11;
END;
/



CREATE OR REPLACE PROCEDURE reportnew1 (
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
   pinclude        IN       VARCHAR2 := NULL,
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
    m.CASHDISCOUNT as "Cash_Disc", m."AUDIT_COMMENT" as "COMMENT",m."Dockit_no" as "DOCKIT_NO",m."Userid" as "USERID",m."date_time" as "DATE_TIME" 
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

if(nvl(pinclude,'N')='N' )then
v_query := v_query || ' and lower(i."Insert_Status" )!=''hold''';
end if;
 IF (pextra2 IS NOT NULL )
   THEN
      v_query := v_query || ' and m."cio_booking_id" =''' || pextra2 || '''';
   END IF;

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
   IF(pextra2 ='') 
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
      end IF;
   ELSE
   IF(pextra2 ='') 
   THEN
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
      v_query := v_query || '  order by m."date_time", i."Insert_Date",m."cio_booking_id"';
   END IF;

--delete from searchtbl;insert into searchtbl values(v_query);commit;
   OPEN p_reportnew FOR v_query;
END reportnew1;
/





========end==========avinash by mimoh=================16july2012=========================/


========start==========avinash by mimoh=================23july2012=========================/

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
      DATEFORMAT    IN       VARCHAR2,
      revenue       IN       VARCHAR2,
      p_accounts    OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor,
      p_accounts2   OUT      t_accounts_cursor,
      p_accounts3   OUT      t_accounts_cursor
   )
   AS
      version1   NUMBER;
      count1     NUMBER;
   BEGIN
      DELETE FROM tempbooking_mast;

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
         SELECT   "date_time", "branch", "booked_by", "cio_booking_id",
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
                  "Scheme_type_code", "Currency_code",
                  NVL ("Agrred_rate", '0'), NVL ("Agreed_amount", '0'),
                  "Special_discount", "Space_discount", "Special_charges",
                  "Agency_status", "Agency_type", "Agency_pay",
                  "Agency_credit", "Total_area", "Card_rate", "Card_amount",
                  NVL ("Discount", '0'), "Discount_per", "Bill_cycle",
                  "Revenue_center", "Bill_pay", "Bill_height", "Bill_width",
                  "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc",
                  "Agency_out", "Box_code", "Box_no", "Box_agency",
                  "Box_client", "Box_address", "Comp_code", "Userid",
                  "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad",
                  "Campaign", "Bill_amount", "Page_prem", "Page_amount",
                  "Prem_per", "Gross_amount", "Ad_size_column",
                  "Bill_column", "Bill_area", "Special_disc_per",
                  "Space_disc_per", "Paid_ins", "Contract_rate", "Deviation",
                  "Variant_code", "Contract_name", "Contract_type",
                  "Card_name", "Card_type", "Card_month", "Card_year",
                  "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4",
                  "Ad_subcat5", "Bg_color", "Bullet_code", "Bullet_premium",
                  "Material_status", TRUNC ("Receipt_date"), "prev_cioid",
                  "prev_receipt", "prev_grossamt", "Region", "Variant",
                  "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom",
                  sapid, retainer, "ADD_AGENCY_COMM", mobileno,
                  add_agency_comm_amt, retainer_comm, retainer_comm_amt,
                  cash_recieved, ciragency, cirrate, ciredition,
                  cirpublication, ciragency_subcode, barter_type,
                  cashdiscount, cashdisctype, attachment1, attachment2,
                  disc_premium, chktradedisc, chk_date, chk_amt,
                  chk_bank_name, our_bank, chk_no, dealerpanel, dealer_h,
                  dealer_w, dealertype, active_agreedrate, active_agreedamt,
                  localgrossamt, localbillamt, package_type, ad_refid,
                  receipt_currency, conv_curr_rate, revise_date, client_type,
                  translation_code, translation_premium, app_user,
                  cancellation_charge, translation_disc, posprem_disc,
                  bill_hold
             FROM tbl_booking_mast
            WHERE ("Comp_code" = compcode OR compcode IS NULL)
              AND (   ("cio_booking_id" = ciobookid OR ciobookid IS NULL)
                   OR ("Receipt_no" = ciobookid OR ciobookid IS NULL)
                  )
              AND ("Dockit_no" LIKE docno || '%' OR docno IS NULL)
              AND ("Key_no" LIKE keyno || '%' OR keyno IS NULL)
              AND ("RO_No" LIKE rono || '%' OR rono IS NULL)
              AND (   "Agency_sub_code" LIKE agencycode || '%'
                   OR agencycode IS NULL
                  )
              AND ("Client_code" LIKE client || '%' OR client IS NULL)
              AND ("Ad_type_code" LIKE booking || '%' OR booking IS NULL)
              AND "branch" IN (
                     SELECT LTRIM (RTRIM (branch_code))
                       FROM login_branch_mast
                      WHERE user_code = revenue
                        AND comp_code = compcode
                        AND user_flag = 'Y')
         ORDER BY "Creation_datetime";

      --Dbms_output.put_line('rinki--');
      OPEN p_accounts FOR
         SELECT   CASE DATEFORMAT
                     WHEN 'mm/dd/yyyy'
                        THEN TO_CHAR ("date_time", 'mm/dd/yyyy')
                     WHEN 'dd/mm/yyyy'
                        THEN TO_CHAR ("date_time", 'dd/mm/yyyy')
                     WHEN 'yyyy/mm/dd'
                        THEN TO_CHAR ("date_time", 'yyyy/mm/dd')
                  END AS date_time,
                  "branch", "booked_by", "cio_booking_id", "prev_booking",
                  "applied_by", "audit", "RO_No",
                  TO_CHAR ("RO_Date", 'dd/mm/yyyy') AS "RO_Date", "Caption",
                  "bill_status", "ro_status", "Agency_code", "Agency_address",
                  "Client_code", "Client_address", "Agency_sub_code",
                  "Dockit_no", "Executive_code", "Executive_zone",
                  "Product_code", "Brand_code", "Key_no", "Bill_remarks",
                  "Print_remark", "Package_code", "No_of_insertion",
                  TO_CHAR ("Insertion_date",
                           'dd/mm/yyyy') AS "Insertion_date", "Repeating_day",
                  "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code",
                  "Color_code", "Uom_code", "Page_position_code",
                  "Page_type_code", "Page_no", "Ad_size_type_code",
                  "Ad_size_height", "Ad_size_width", "Rate_code",
                  (SELECT "Scheme_Name"
                     FROM scheme_master
                    WHERE "scheme_id" =
                             tempbooking_mast."Scheme_type_code")
                                                        AS "Scheme_type_code",
                  "Currency_code", "Agrred_rate", "Agreed_amount",
                  "Special_discount", "Space_discount", "Special_charges",
                  tempbooking_mast."Comp_code", tempbooking_mast."Userid",
                  tempbooking_mast."Agency_status", "Agency_type",
                  "Agency_pay", "Agency_credit", "Total_area", "Card_rate",
                  "Card_amount", "Discount", "Discount_per", "Bill_cycle",
                  "Revenue_center", "Bill_pay", "Bill_height", "Bill_width",
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
                  (SELECT    exec_mast."Exec_name"
                          || '('
                          || TO_CHAR (exec_mast."Exe_no")
                          || ')'
                     FROM exec_mast
                    WHERE tempbooking_mast."Executive_code" =
                                                            exec_mast."Exe_no"
                      AND tempbooking_mast."Comp_code" = exec_mast."comp_code")
                                                                AS "execname",
                  
                  --91
                  (SELECT    product_cat_mast."prod_desc"
                          || '('
                          || product_cat_mast."prod_cat_code"
                          || ')'
                     FROM product_cat_mast
                    WHERE tempbooking_mast."Product_code" =
                                              product_cat_mast."prod_cat_code"
                      AND tempbooking_mast."Comp_code" =
                                                  product_cat_mast."comp_code")
                                                                 AS "product",
                  
                  --92
                  "Paid_ins", "Contract_rate", "Deviation", "Variant_code",
                  (SELECT "deal_name"
                     FROM contract_mast
                    WHERE "Deal_No" =
                             (SELECT "deal_code"
                                FROM contract_detail
                               WHERE "ContractCode" =
                                           "Contract_name"))
                                                           AS "Contract_name",
                  "Contract_type", "Card_name", "Card_type",
                                                            --100
                                                            "Card_month",
                  "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3",
                  "Ad_Subcat4", "Ad_subcat5", "Bg_color", "Bullet_code",
                  "Bullet_premium",
                  (SELECT "Agency_Name"
                     FROM agency_mast
                    WHERE "code_subcode" =
                             tempbooking_mast."Agency_sub_code")
                                                           AS "AgencySubCode",
                  
                  --111
                  NVL ((SELECT "Cust_Name"
                          FROM cust_mast
                         WHERE "Cust_Code" = "Client_code"), '') AS "Client",
                  
                  --112
                  (SELECT "Payment_Mode_Name"
                     FROM payment_mode_mast
                    WHERE "Pay_Mode_Code" = "Agency_pay") AS "PayMode",
                  (SELECT "Adv_Cat_Name"
                     FROM adv_cat_mast
                    WHERE adv_cat_mast."Adv_Cat_Code" =
                             tempbooking_mast."Ad_cat_code")
                                                            AS "categoryname",
                  (SELECT "Adv_Subcat_Name"
                     FROM adv_subcat_mast
                    WHERE adv_subcat_mast."Adv_Subcat_Code" =
                             tempbooking_mast."Ad_sub_cat_code")
                                                         AS "subcategoryname",
                  (SELECT "brand_name"
                     FROM brand_mst
                    WHERE "brand_code" =
                                     tempbooking_mast."Brand_code")
                                                                   AS "Brand",
                  (SELECT "Uom_Name"
                     FROM uom_mast
                    WHERE "Uom_Code" = tempbooking_mast."Uom_code") AS "UOM",
                  (SELECT "premiumname"
                     FROM advpos_prem_mast
                    WHERE "Premiumcode" =
                             tempbooking_mast."Page_type_code")
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
                  "Material_status",
                  TO_CHAR ("Receipt_date", 'dd/mm/yyyy') AS "Receipt_date",
                  tempbooking_mast."Region", "Variant", "Colortype",
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
                    WHERE "Uom_Code" =
                                    tempbooking_mast."Uom_code")
                                                                AS "logocode",
                  (SELECT "Box_Charges_Native"
                     FROM box_mast
                    WHERE box_mast."Box_Code" =
                                     tempbooking_mast."Box_code"
                      AND "pub_center" =
                             (SELECT "pub_center"
                                FROM branch_mst
                               WHERE "Branch_Code" = tempbooking_mast."branch"))
                                                                 AS "boxchrg",
                  tempbooking_mast.sapid, retainer,
                  (SELECT "Retain_Name"
                     FROM retainermaster
                    WHERE retainermaster."Retain_Code" =
                                      tempbooking_mast.retainer)
                                                                AS "RETAINER",
                  (SELECT    "Retain_Name"
                          || '('
                          || "Retain_Code"
                          || ')'
                     FROM retainermaster
                    WHERE retainermaster."Retain_Code" =
                                                     tempbooking_mast.retainer)
                                                               AS "RETAINER1",
                  (SELECT "Package_Name"
                     FROM combin_mast
                    WHERE "Combin_Code" =
                             tempbooking_mast."Package_code")
                                                             AS "Package_cod",
                  (SELECT "Col_Name"
                     FROM col_mast
                    WHERE "Col_Code" =
                                 tempbooking_mast."Color_code")
                                                               AS "Color_cod",
                  (SELECT "Pos_Type"
                     FROM advpos_type_mast
                    WHERE "Pos_Type_Code" =
                             tempbooking_mast."Page_position_code")
                                                       AS "Page_position_cod",
                  DECODE (tempbooking_mast."Booking_type",
                          '1', 'FMG',
                          '2', 'BARTER',
                          '3', 'NORMAL',
                          '4', 'COMPLIMEN

TRY'
                         ) AS "Book_type",
                  (SELECT "catname"
                     FROM ad_cat3
                    WHERE ad_cat3."catcode" =
                                   tempbooking_mast."Ad_Subcat3")
                                                                 AS "Subcat3",
                  (SELECT "Cat_Name"
                     FROM tbl_cat4
                    WHERE tbl_cat4."Cat_Code" =
                                   tempbooking_mast."Ad_Subcat4")
                                                                 AS "Subcat4",
                  (SELECT "Cat_Name"
                     FROM tbl_cat5
                    WHERE tbl_cat5."Cat_Code" =
                                   tempbooking_mast."Ad_subcat5")
                                                                 AS "subcat5",
                  (SELECT "Comm_Rate"
                     FROM ret_comm_details
                    WHERE ret_comm_details."Retain_Code" =
                                 tempbooking_mast.retainer
                      AND ROWID =
                             (SELECT MAX (ROWID)
                                FROM ret_comm_details
                               WHERE ret_comm_details."Retain_Code" =
                                                     tempbooking_mast.retainer))
                                                           AS "RETAINER_COMM",
                  "ADD_AGENCY_COMM", tempbooking_mast."Scheme_type_code",
                  mobileno, cashdiscount, cashdisctype, attachment1,
                  attachment2, disc_premium, chktrade, chk_date, chk_amt,
                  chk_bank_name, our_bank, chk_no, agency_mast.booking_type,
                  dealerpanel, dealer_h, dealer_w, dealertype, mobileno,
                  (SELECT "Comm_Rate"
                     FROM comm_details
                    WHERE "Agency_code" || "Agency_sub_code" =
                              tempbooking_mast."Agency_sub_code"
                      AND "Comp_Code" = UPPER (compcode)
                      AND SYSDATE BETWEEN "Eff_from_Date" AND "Eff_Till_Date"
                      AND ROWNUM <= 1) AS comm_rate,
                  active_agreedrate, active_agreedamt,
                  NVL (localgrossamt, "Gross_amount") AS localgrossamt,
                  NVL (localbillamt, "Bill_amount") AS localbillamt,
                  translation_disc, posprem_disc,
                  (SELECT disc_type
                     FROM disc_master
                    WHERE disc_code = disc_premium) AS disc_type
/*for Display and classified*/
         FROM     tempbooking_mast, agency_mast
            WHERE agency_mast."code_subcode" =
                                            tempbooking_mast."Agency_sub_code"
              AND agency_mast."Comp_Code" = compcode
         ORDER BY "Creation_datetime";

      DBMS_OUTPUT.put_line ('rinki--');

----------------------------------------------------Lata------------------------------------------------------
      OPEN p_accounts1 FOR
         SELECT 'A' AS a
           FROM DUAL;

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
         SELECT 'A' AS a
           FROM DUAL;

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
         SELECT 'A' AS a
           FROM DUAL;
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




========end==========avinash by mimoh=================23july2012=========================/


=======start===========avinash by mimoh=================25july2012=========================
CREATE OR REPLACE PROCEDURE fmgdatabid (
   comecode     IN       VARCHAR2,
   todate       IN       VARCHAR2,
   fromdate     IN       VARCHAR2,
   bookingid    IN       VARCHAR2,
   agency       IN       VARCHAR2,
   client       IN       VARCHAR2,
   insertid     IN       VARCHAR2,
   p_adtye      IN       VARCHAR2,
   extra        IN       VARCHAR2,
   p_accounts   OUT      cur_type_new1.cursor_type
)
IS
   a        NUMBER;
   query1   VARCHAR2 (10000);
BEGIN
   IF insertid IS NULL
   THEN
-- query1:='select distinct tbl_booking_insert."Cio_Booking_Id",(select "Col_Name" from col_mast where "Col_Code"=tbl_booking_insert."Col_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION","Insert_Id",to_char("Insert_Date",''dd/mm/yyyy'') as "Insert_Date","Gross_Rate","Bill_Amt" from tbl_booking_insert,tbl_booking_mast where
      
      query1 :=
            'select distinct tbl_booking_insert."Cio_Booking_Id",tbl_booking_insert."Col_Code" as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION","Insert_Id",to_char("Insert_Date",''dd/mm/yyyy'') as "Insert_Date","Gross_Rate",round("Bill_Amt",2) "Bill_Amt","RO_No" from tbl_booking_insert,tbl_booking_mast where
 tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and tbl_booking_insert."Comp_Code"='''|| comecode
         || ''' and tbl_booking_mast."Agency_sub_code"= '''|| agency
         || ''' and tbl_booking_mast."Ad_type_code"= '''|| p_adtye
         || ''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')';
        
    If fromdate is not null and todate  is not null then
        query1 :=query1|| ''' and "Insert_Date" between '''|| fromdate|| ''' and '''|| todate;
    end if;
    
      IF (bookingid IS NOT NULL)
      THEN
         query1 := query1|| ' and tbl_booking_insert."Cio_Booking_Id"='''|| bookingid|| '''';
      END IF;

      IF (client IS NOT NULL)
      THEN
         query1 :=query1 || ' and tbl_booking_mast."Client_code"=''' || client|| '''';
      END IF;

      query1 := query1 || ' order by "Insert_Id"';

      OPEN p_accounts FOR query1;
   ELSE
      DELETE FROM RESULT;

      a := fn_splitfield (insertid, '~');
--query1:='select distinct tbl_booking_insert."Cio_Booking_Id",(select "Col_Name" from col_mast where "Col_Code"=tbl_booking_insert."Col_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION","Insert_Id",to_char("Insert_Date",''dd/mm/yyyy'') as "Insert_Date","Gross_Rate","Bill_Amt" from tbl_booking_insert,tbl_booking_mast where tbl_booking_insert."Comp_Code"='''||comecode||'''  and tbl_booking_mast."Agency_sub_code"= '''||agency||''' and tbl_booking_mast."Ad_type_code"= '''||p_adtye||''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')';
      query1 :=
            'select distinct tbl_booking_insert."Cio_Booking_Id",tbl_booking_insert."Col_Code" as "color","Height","Width","Size_Book",(SELECT "Edition_Alias" from edition_Mast where "Edition_Code"=tbl_booking_insert."Edition_Code" and "Comp_Code"=tbl_booking_insert."Comp_Code") as "EDITION","Insert_Id",to_char("Insert_Date",''dd/mm/yyyy'') as "Insert_Date","Gross_Rate","Bill_Amt","RO_No" from tbl_booking_insert,tbl_booking_mast where tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" and tbl_booking_insert."Comp_Code"='''
         || comecode
         || '''  and tbl_booking_mast."Agency_sub_code"= '''
         || agency
         || ''' and tbl_booking_mast."Ad_type_code"= '''
         || p_adtye
         || ''' and "Insert_Status" in (''publish'',''billed'',''audit by rate'')';
      query1 :=
            query1
         || ' and tbl_booking_insert."Insert_Id" in(select edition_name from result)';

      OPEN p_accounts FOR query1;
   END IF;
END;
/

=======end===========avinash by mimoh=================25july2012=========================


=======start===========avinash by mimoh=================26july2012=========================

CREATE OR REPLACE PROCEDURE getmatterlog
(

ptable IN VARCHAR2,
puserid IN VARCHAR2,
pfrmdt IN VARCHAR2,
ptdat IN VARCHAR2,

P_Accounts OUT Cur_Type_New1.cursor_type

)


IS
v_query     VARCHAR(8000);

BEGIN
    if puserid is not null then
        v_query:=' select * from '|| ptable ||'  where "UPDATED_BY"='''|| puserid ||''' AND LOG_DATE   BETWEEN ''' || pfrmdt ||'''  and  ''' ||ptdat||''' '  ;
    else
        v_query:=' select * from '|| ptable ||'  where LOG_DATE   BETWEEN ''' || pfrmdt ||'''  and  ''' ||ptdat||''' '  ;
    end if;            


OPEN p_accounts FOR v_query;
END ;
/



//*************************************************************************************************************//



CREATE OR REPLACE PROCEDURE binbookingid (
   p_compcode    IN       VARCHAR2,
   p_bookingid   IN       VARCHAR2,
   p_accounts    OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT "cio_booking_id"
        FROM tbl_booking_mast
       WHERE "Comp_code" = p_compcode
         AND "cio_booking_id" LIKE p_bookingid || '%'
         AND ROWNUM <= 10;
END;
/


/*******************************************************************************************************************/


CREATE OR REPLACE PROCEDURE rate_audit_logreport (
   pfromdate     IN       VARCHAR2,
   pdateto       IN       VARCHAR2,
   pcompcode     IN       VARCHAR2,
   ppub_cent     IN       VARCHAR2,
   pbranch       IN       VARCHAR2,
   pdateformat   IN       VARCHAR2,
   padtyp        IN       VARCHAR2,
   puom          IN       VARCHAR2,
   pagency       IN       VARCHAR2,
   pclient       IN       VARCHAR2,
   pbkid         IN       VARCHAR2,
   puserid       IN       VARCHAR2,
   pextra1       IN       VARCHAR2,
   pextra2       IN       VARCHAR2,
   pextra3       IN       VARCHAR2,
   pextra4       IN       VARCHAR2,
   pextra5       IN       VARCHAR2,
   p_accounts    OUT      cur_type_new1.cursor_type,
   p_accounts1   OUT      cur_type_new1.cursor_type,
   p_accounts2   OUT      cur_type_new1.cursor_type,
   p_accounts3   OUT      cur_type_new1.cursor_type,
   p_accounts4   OUT      cur_type_new1.cursor_type
)
IS
BEGIN
   OPEN p_accounts FOR
      SELECT   m.comp_code, (SELECT "Comp_Name"
                               FROM comp_mst
                              WHERE "Comp_Code" = m.comp_code) comp_name,
               SYSDATE AS "CUR_DATE", m.cio_booking_id, i.insert_id,
               m.agency_sub_code, a."Agency_Name", m.agency_address,
               NVL ((SELECT "Cust_Name"
                       FROM cust_mast
                      WHERE "Cust_Code" = m.client_code
                        AND m.comp_code = cust_mast."Comp_Code"),
                    m.client_code
                   ) client,
               m.client_address, m.ro_no, m.ro_date, m.executive_code,
               (SELECT "Exec_name"
                  FROM exec_mast
                 WHERE TO_CHAR ("Exe_no") =
                                           m.executive_code)
                                                           AS executive_name,
               m.retainer, (SELECT "Retain_Name"
                              FROM retainermaster
                             WHERE "Retain_Code" = m.retainer) retainer_name,
               m.booking_type, NULL translation, m.rate_code, m.agrred_rate,
               m.agreed_amount,
               CASE
                  WHEN NVL (m.disc_premium, '0') = '0'
                     THEN m.special_disc_per
                  ELSE 0
               END AS special_disc_per,
               m.space_disc_per, m.special_charges, m.page_position_code,
               m.page_type_code, m.prem_per, m.prem_per, m.translation_code,
               m.translation_premium, i.boxcharge, i.publication_code,
               m.bill_cycle, m.bill_pay, m.box_code, i.no_insert,
               i.insert_date, i.edition, i.ad_cat,
               (SELECT "Adv_Cat_Name"
                  FROM adv_cat_mast
                 WHERE "Adv_Cat_Code" = i.ad_cat) ad_cat_name, i.ad_sub_cat,
               (SELECT "Adv_Subcat_Name"
                  FROM adv_subcat_mast
                 WHERE "Adv_Subcat_Code" = i.ad_sub_cat) ad_sub_cat_name,
               i.col_code, i.height, i.width, i.insert_status, i.page_no,
               i.page_prem, i.page_post, i.pai_free_ins, i.package_code,
               (SELECT "Package_Name"
                  FROM combin_mast
                 WHERE "Combin_Code" = i.package_code) package_name,
               m.page_prem AS page_prem, m.prem_per AS page_prem_per,
               CASE
                  WHEN NVL (m.disc_premium, '0') = '0'
                     THEN 0
                  ELSE m.special_disc_per
               END AS disc_on_page_prem,
               m.translation_premium AS translation_charges,
               m.translation_disc AS disc_on_trans_charge,
               m.bullet_code AS eye_catcher,
               m.page_position_code AS position_prem,
               m.posprem_disc AS disc_on_posi_prem,
               m.page_amount AS posi_prem_per, m.page_prem AS position_prem,
               m.rate_audit_ip, m.rate_audit_by, m.rate_audit_date,
               m.trn_type
          FROM tbl_booking_mast_log_r m,
               tbl_booking_insert_log_r i,
               agency_mast a
         WHERE m.comp_code = i.comp_code
           AND m.comp_code = a."Comp_Code"
           AND m.cio_booking_id = i.cio_booking_id
           AND m.cio_booking_id = NVL (pbkid, m.cio_booking_id)
           AND m.agency_sub_code = a."code_subcode"
           AND m.agency_sub_code = NVL (pagency, m.agency_sub_code)
           AND m.ad_type_code = NVL (padtyp, m.ad_type_code)
           AND m.uom_code = NVL (puom, m.uom_code)
           AND m.client_code = NVL (pclient, m.client_code)
           AND EXISTS (
                  SELECT 'x'
                    FROM branch_mst
                   WHERE "Branch_Code" = m.branch
                     AND "Branch_Code" = NVL (pbranch, "Branch_Code")
                     AND "pub_center" = NVL (ppub_cent, "pub_center"))
      ORDER BY cio_booking_id, insert_id, rate_audit_date, trn_type DESC;

   OPEN p_accounts1 FOR
      SELECT SYSDATE AS "CUR_DATE"
        FROM DUAL;

   OPEN p_accounts2 FOR
      SELECT SYSDATE AS "CUR_DATE"
        FROM DUAL;

   OPEN p_accounts3 FOR
      SELECT SYSDATE AS "CUR_DATE"
        FROM DUAL;

   OPEN p_accounts4 FOR
      SELECT SYSDATE AS "CUR_DATE"
        FROM DUAL;
END rate_audit_logreport;
/


/*********************************************************************************************************************/








=======end===========avinash by mimoh=================26july2012=========================

//////////done by shipra //////////////issue no 8096///////////////


CREATE OR REPLACE PROCEDURE HT18JULY.Ad_Gen_Code_fmg (
    pcompcode   in varchar2,
   
    pdescp     in varchar2,
  
    p_accounts   OUT   cur_type_new1.cursor_type)
    as
    vno         number(5);
    vtype_code  varchar2(15);

BEGIN

    Begin
       select max(substr(REASON_CODE,2,3))+1 into vno from AD_FMG_REASON_MAST where comp_code=pcompcode;
    Exception When Others Then
        vno:=null;
    End;
    If nvl(vno,0)=0 Then
        vtype_code:='A'||'001';
    Else
        vtype_code:='A'||lpad(vno,3,'0');
    End if;

    open p_accounts for select vtype_code as "VAR_CODE" from dual;

End Ad_Gen_Code_fmg;
/




////////////////////////end//////////shipra///////8096




/////////////////////////////////********************************Sumit Roy(Rate Master)************************//////////////////////


CREATE OR REPLACE PROCEDURE binndratecode (
   p_compcode    IN       VARCHAR2,
   p_ratecode   IN       VARCHAR2,
   p_accounts    OUT      cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT distinct "RATE_DESC"
        FROM rate_code_mast
       WHERE "COMP_CODE" = p_compcode
       AND "STATUS" = 'AC0'
         AND "RATE_CODE" LIKE p_ratecode || '%';
        
END;
/




*****************************************************************************************



CREATE OR REPLACE PROCEDURE bindstatus_for_ratemast
(
pcompcode in varchar2,


p_accounts   OUT   cur_type_new1.cursor_type
)

as
begin
 open p_accounts for
 select "Status_Code","Status_Name" from tblstatus where "Comp_Code"=pcompcode  order by "Status_Code";
 
end;
/

*************************************************************************************************

CREATE OR REPLACE PROCEDURE AD_RATECODE_CHECK
(
pcomp_code in varchar2,
pratecode  in varchar2,
pextra1    in varchar2,
pextra2    in varchar2,

p_accounts   OUT   cur_type_new1.cursor_type
)

as
 return_value        int; 
 chgval         varchar2(2); 
 Begin
begin
   SELECT COUNT(*) into return_value  FROM RATE_MAST WHERE "Comp_code"=pcomp_code AND "Rate_Mast_Code"=pratecode;

end;
 
 IF return_value>0 THEN 
   
    --  open p_accounts for
   --   begin
   --  SELECT 'Return_Value' = 'N';
       chgval:='N';
   --   end;
  ELSE 
    
   --  open p_accounts for
   --   begin
    --  SELECT 'Return_Value' = 'Y';
     chgval:='Y';
   --  end;
    END IF;
 
  open p_accounts for select chgval as "Return_Value" from dual;
end;
/



*****************************************************************************************


CREATE OR REPLACE PACKAGE autoagtypecode
 is
Type T_Accounts_Cursor is Ref Cursor;
procedure    autoagtypecode_p(str in varchar2,cod in varchar2,
p_Accounts out T_Accounts_Cursor,
p_Accounts1 out T_Accounts_Cursor);

procedure    autoagtypecode_p11(str in varchar2,cod in varchar2,adcattype in varchar2,
p_Accounts out T_Accounts_Cursor,
p_Accounts1 out T_Accounts_Cursor);
procedure    autoratecode(str in varchar2,cod in varchar2,
p_Accounts out T_Accounts_Cursor,
p_Accounts1 out T_Accounts_Cursor);

end    autoagtypecode;
/







CREATE OR REPLACE package  body autoagtypecode
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

procedure    autoratecode(str in varchar2,cod in varchar2,
p_Accounts out T_Accounts_Cursor,
p_Accounts1 out T_Accounts_Cursor) as
begin

open p_Accounts for
select * from RATE_CODE_MAST where upper("RATE_DESC")=upper(str);

open p_Accounts1 for
select MAX(TO_NUMBER(NVL(translate("RATE_CODE",'ABCDEFGHIJKLMNOPQRSTUVWXYZ~@#$%^&*()!><?/_+|=-',0),0))) AS "RATE_CODE" from RATE_CODE_MAST where  upper("RATE_CODE") like upper(cod)||'%';

end    autoratecode;





end    autoagtypecode;
/


////////////////////////////////////*****************END********************************////////////////////////////////


=======start===========avinash by mimoh=================31july2012=========================
CREATE OR REPLACE PACKAGE BODY getagencyname_agency
IS
   PROCEDURE getagencyname_agency_p (
      compcode      IN       VARCHAR2,
      client        IN       VARCHAR2,
      value1         IN       VARCHAR2,
      p_accounts    OUT      t_accounts_cursor--,
      --p_accounts1   OUT      t_accounts_cursor
   )
   AS
   BEGIN
   
   --DBMS_OUTPUT.PUT_LINE(value1);
   
      IF (value1 = '0')
      THEN
         OPEN p_accounts FOR
            SELECT DISTINCT "Agency_Code", "Agency_Name", "Add1", "Add2",
                            "Add3","SUB_Agency_Code"
                       FROM agency_mast
                      WHERE "Comp_Code" = compcode
                        AND "code_subcode" = client;
      --END IF;



--      (value1 = '1')
      --THEN
       else
         OPEN p_accounts FOR
            SELECT DISTINCT "Cust_Code", "Cust_Name", "Add1"
              FROM cust_mast
             WHERE "Comp_Code" = compcode AND "Cust_Code" = client;
             
            
            
      END IF;
   END getagencyname_agency_p;
END getagencyname_agency;
/


/************************************************************************************************/

CREATE OR REPLACE PACKAGE BODY agecatcode
IS
   PROCEDURE agecatcode_p (code IN VARCHAR2, p_accounts OUT t_accounts_cursor)
   AS
   BEGIN
      OPEN p_accounts FOR
         SELECT   "Agency_Cat_Name", "Agency_Cat_Code"
             FROM agency_cat_mast
            WHERE "agencytype" = code
         ORDER BY "Agency_Cat_Name";
   END agecatcode_p;
END agecatcode;
/





/***************************************************************************************************/





CREATE OR REPLACE PACKAGE BODY bindagencytype
IS
   PROCEDURE bindagencytype_p (
      agencytype   IN       VARCHAR2,
      p_accounts   OUT      t_accounts_cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
         SELECT DISTINCT *
                    FROM agency_cat_mast
                   WHERE "agencytype" = agencytype
                ORDER BY "Agency_Cat_Name";
   END bindagencytype_p;
END bindagencytype;
/

=======END===========avinash by mimoh=================31july2012=========================


