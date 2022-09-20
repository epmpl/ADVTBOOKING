//====================Update By Bhanu========================//

CREATE OR REPLACE PACKAGE insertintobookchild
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  insertintobookchild_p (


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
cirvts in varchar2,
cirpub in varchar2,
ciredi in varchar2,
cirrate in varchar2,
cirdate_v in date, 
ciragency_v in varchar2,
 ciragencysubcode_v in varchar2, 
 center_v in varchar2,
  branch_v in varchar2,
  splitdata_v in varchar2,
  subedidata in varchar2,
  splboldsizevalue IN VARCHAR2,
  vatrate_p in float,
  boxcharge_p in float,
  vat_inc_p in varchar2,
  grossamtlocal_p in varchar2,
  billamtlocal_p in varchar2,
  sectioncode_p in varchar2,
  resourceno_p in varchar2,
  caption_inserts_p in varchar2,
  dealerheight in NUMBER,
              dealerwidth in NUMBER,
              disc_p in float,
              
      agncyamnt in varchar2,
      adlgncyamnt in varchar2,
      spldiscamt in varchar2,
      cashdamnt in varchar2,        
           ROUNDOFF in float,    
              
    p_error out varchar2

   );
END insertintobookchild;
/
********************************
CREATE OR REPLACE PACKAGE BODY HT18JULY.insertintobookchild
IS
   PROCEDURE insertintobookchild_p (
      insertdate           IN       DATE,
      edition              IN       VARCHAR2,
      premium1             IN       VARCHAR2,
      premium2             IN       VARCHAR2,
      premallow            IN       VARCHAR2,
      adcategory           IN       VARCHAR2,
      latestdate           IN       DATE,
      material             IN       VARCHAR2,
      cardrate             IN       NUMBER,
      matfilename          IN       VARCHAR2,
      discrate             IN       NUMBER,
      insertstatus         IN       VARCHAR2,
      billstatus           IN       VARCHAR2,
      adsubcat1            IN       VARCHAR2,
      compcode             IN       VARCHAR2,
      userid               IN       VARCHAR2,
      cioid                IN       VARCHAR2,
      height               IN       NUMBER,
      width                IN       NUMBER,
      totalsize            IN       NUMBER,
      pagepost             IN       VARCHAR2,
      premper1             IN       NUMBER,
      premper2             IN       NUMBER,
      colid                IN       VARCHAR2,
      repeat               IN       DATE,
      insertno             IN       INT,
      paid                 IN       VARCHAR2,
      agrrate              IN       NUMBER,
      solorate             IN       NUMBER,
      grossrate            IN       NUMBER,
      insert_pageno        IN       NUMBER,
      insert_remarks       IN       VARCHAR2,
      page_code            IN       VARCHAR2,
      page_per             IN       NUMBER,
      noofcol              IN       NUMBER,
      billamt              IN       NUMBER,
      billrate             IN       NUMBER,
      logo_h               IN       VARCHAR2,
      logo_w               IN       VARCHAR2,
      logo_name            IN       VARCHAR2,
      ad_cat_3             IN       VARCHAR2,
      ad_cat_4             IN       VARCHAR2,
      ad_cat_5             IN       VARCHAR2,
      pkgcode              IN       VARCHAR2,
      gridins              IN       NUMBER,
      pkgalias             IN       VARCHAR2,
      cirvts               IN       VARCHAR2,
      cirpub               IN       VARCHAR2,
      ciredi               IN       VARCHAR2,
      cirrate              IN       VARCHAR2,
      cirdate_v            IN       DATE,
      ciragency_v          IN       VARCHAR2,
      ciragencysubcode_v   IN       VARCHAR2,
      center_v             IN       VARCHAR2,
      branch_v             IN       VARCHAR2,
        splitdata_v          IN       VARCHAR2,
         subedidata in varchar2,
         splboldsizevalue IN VARCHAR2,
          vatrate_p in float,
            boxcharge_p in float,
            vat_inc_p in varchar2,
            grossamtlocal_p in varchar2,
            billamtlocal_p in varchar2,
            sectioncode_p in varchar2,
              resourceno_p in varchar2,
              caption_inserts_p in varchar2,
              dealerheight in NUMBER,
              dealerwidth in NUMBER,
               disc_p in float,
               agncyamnt in varchar2,
      adlgncyamnt in varchar2,
      spldiscamt in varchar2,
      cashdamnt in varchar2,
ROUNDOFF in float, 
      
      p_error              OUT      VARCHAR2
   )
   AS
      edi           VARCHAR2 (50);
      publi         VARCHAR2 (50);
      pub_cent      VARCHAR2 (50);
      supp          VARCHAR2 (50);
      cou1          NUMBER;
      ID            NUMBER;
      insertidval   NUMBER;
      receiptno_m varchar2(50);
      vatamtamt  varchar2(50);
      error1 varchar2(100);

   BEGIN
    BEGIN
    select Receipt_no into receiptno_m from tbl_booking_mast_g where cio_booking_id=cioid and rownum<=1;
     EXCEPTION
         WHEN NO_DATA_FOUND
         THEN
            NULL;
      END;
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
      
        IF(NVL(vatrate_p,0)>0) THEN        
            vatamtamt:=TO_CHAR(round((billamt-(billamt/(1+(vatrate_p/100)))),2));
        ELSE        
            vatamtamt:=NULL;        
        END IF;
        

      IF (cou1 > 0)
      THEN
         BEGIN
            SELECT "Edition_Code"
              INTO edi
              FROM edition_mast
             WHERE ("Edition_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Pub_Code"
              INTO publi
              FROM edition_mast
             WHERE ("Edition_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "City_Code"
              INTO pub_cent
              FROM edition_mast
             WHERE ("Edition_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
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
             WHERE ("Supp_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Pub_Code"
              INTO publi
              FROM supplement_mast
             WHERE ("Supp_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "Supp_Code"
              INTO supp
              FROM supplement_mast
             WHERE ("Supp_Alias" = edition)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
         EXCEPTION
            WHEN NO_DATA_FOUND
            THEN
               NULL;
         END;

         BEGIN
            SELECT "City_Code"
              INTO pub_cent
              FROM edition_mast
             WHERE ("Edition_Code" = edi)
               AND ("Comp_Code" = compcode)
               AND ROWNUM <= 1;
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

--insertidval:=INSERTID.nextval;
      SELECT insertid.NEXTVAL
        INTO insertidval
        FROM DUAL;
        INSERT INTO tbl_booking_insert_G
                  (CIO_BOOKING_ID, EDITION, INSERT_DATE, COL_CODE,
                   HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1,
                   PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW,
                   AD_CAT, AD_SUB_CAT, LATEST_BY, STATUS_MATERIAL,
                   FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS,
                   BILL_STATUS, COMP_CODE, USERID, REPEATING_DATE,
                   NO_INSERT, EDITION_CODE, PUBLICATION_CODE,
                   PUB_CENT_CODE, SUPP_CODE, PAI_FREE_INS,
                   AGREED_RATE, SOLO_RATE, GROSS_RATE, PAGE_NO,
                   REMARKS, PAGE_PREM, PAGE_PER, NO_OFCOLUMN,
                   BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME,
                   INSERT_ID, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5,
                   PACKAGE_CODE, INSERTS, PKG_ALIAS, SESID,SPECIAL_SIZE1,VATAMT,BOXCHARGE,VAT_INC,LOCALGROSSAMT, LOCALBILLAMT, SECTIONCODE, RESOURCE_NO,CAPTION,
                   DEALER_H, DEALER_W, DISCOUNT,INSERT_STATUS_PUB,SPECIAL_SIZE2,agncyamnt,adlgncyamt,spldisamt,cashdisamt,ROUND_VALUE 
                  )
           VALUES (cioid, edition, insertdate, colid,
                   height, width, totalsize, pagepost, premium1,
                   premper1, premium2, premper2, premallow,
                   adcategory, adsubcat1, latestdate, material,
                   matfilename, cardrate, discrate, insertstatus,
                   billstatus, compcode, userid, repeat,
                   insertno, edi, publi,
                   pub_cent, supp, paid,
                   agrrate, solorate, grossrate, insert_pageno,
                   insert_remarks, page_code, page_per, noofcol,
                   billamt, billrate, logo_h, logo_w, logo_name,
                   insertidval, ad_cat_3, ad_cat_4, ad_cat_5,
                   pkgcode, gridins, pkgalias,USERENV ('sessionid'),splboldsizevalue,vatrate_p,boxcharge_p,vat_inc_p,grossamtlocal_p,billamtlocal_p,sectioncode_p,  resourceno_p,caption_inserts_p,
                   dealerheight,dealerwidth,disc_p,insertstatus,vatamtamt,agncyamnt,adlgncyamnt,spldiscamt,cashdamnt,ROUNDOFF
                  );
                  insert_split_details(splitdata_v,receiptno_m,cioid,insertidval,error1);
                INSERT INTO TEST1 VALUES(edition,'EDITION');
                 insert_edition_details(subedidata,receiptno_m,cioid,insertidval,compcode,edi,insertdate,height,width,totalsize,insertstatus,pkgcode,insertno,insert_pageno,error1);
                 commit;
                  --insert into abctest values(edition);
/*                 
      INSERT INTO tbl_booking_insert
                  ("Cio_Booking_Id", "Edition", "Insert_Date", "Col_Code",
                   "Height", "Width", "Size_Book", "Page_Post", "Premium1",
                   "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow",
                   "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Status_Material",
                   "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status",
                   "Bill_Status", "Comp_Code", "Userid", "Repeating_Date",
                   "No_Insert", "Edition_Code", "Publication_Code",
                   "Pub_Cent_Code", "Supp_Code", "Pai_Free_Ins",
                   "Agreed_Rate", "Solo_Rate", "Gross_Rate", "Page_No",
                   "Remarks", "Page_Prem", "Page_Per", "No_Ofcolumn",
                   "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name",
                   "Insert_Id", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5",
                   package_code, inserts, pkg_alias
                  )
           VALUES (cioid, edition, insertdate, colid,
                   height, width, totalsize, pagepost, premium1,
                   premper1, premium2, premper2, premallow,
                   adcategory, adsubcat1, latestdate, material,
                   matfilename, cardrate, discrate, insertstatus,
                   billstatus, compcode, userid, repeat,
                   insertno, edi, publi,
                   pub_cent, supp, paid,
                   agrrate, solorate, grossrate, insert_pageno,
                   insert_remarks, page_code, page_per, noofcol,
                   billamt, billrate, logo_h, logo_w, logo_name,
                   insertidval, ad_cat_3, ad_cat_4, ad_cat_5,
                   pkgcode, gridins, pkgalias
                  );
*/
      IF (cirvts IS NOT NULL)
      THEN
         INSERT INTO TBL_BOOKING_VTS_g
                     (compcode, cioid, insertid, vts, publication, edition,
                      rate, ciragcode, ciragsubcode, center,
                      branch, publishdate ,SESID
                     )
              VALUES (compcode, cioid, insertidval, cirvts, cirpub, ciredi,
                      cirrate, ciragency_v, ciragencysubcode_v, center_v,
                      branch_v, cirdate_v,USERENV ('sessionid')
                     );
      END IF;
   EXCEPTION
      WHEN OTHERS
      THEN
         p_error := 'Error:' || SQLERRM;
   END insertintobookchild_p;
END insertintobookchild;
/


======================================================================================================================
CREATE OR REPLACE PROCEDURE HT18JULY.committransaction (
   pcioid          IN       VARCHAR2,
   totalcount      IN       INT,
   pcompcode       IN       VARCHAR2,
   pcentname       IN       VARCHAR2,
   puserid         IN       VARCHAR2,
   pbkid_gentype   IN       VARCHAR2,
   pbk_type        IN       VARCHAR2,
   pquotation      IN       VARCHAR2,
   p_error         OUT      VARCHAR2,
   p_new_cioid     OUT      VARCHAR2
)
IS
   countnum          INT;
   newid             VARCHAR2 (100);
   billpay           VARCHAR2 (20);
   rostatus          VARCHAR2 (20);
   remarks           VARCHAR2 (500);
   clientname        VARCHAR2 (200);
   v_cursor1         TYPES.cursor_type;
   v_cursor2         TYPES.cursor_type;
   v_cursor1_var1    VARCHAR2 (50);
   v_cursor1_var2    VARCHAR2 (50);
   v_cursor2_var1    VARCHAR2 (50);
   v_direct_client   NUMBER (5);
BEGIN
   newid := pcioid;

   SELECT COUNT (*)
     INTO countnum
     FROM tbl_booking_insert_g
    WHERE cio_booking_id = pcioid;

   IF (countnum = totalcount)
   THEN
         delete from test1;
insert into test1  values('a','b');
commit;

   
      IF pquotation = 'Q'
      THEN
      
      


         newid := pcioid;

         INSERT INTO tbl_booking_mast_q
                     (date_time, branch, booked_by, cio_booking_id,
                      prev_booking, applied_by, audit_q, ro_no, ro_date,
                      caption, bill_status, ro_status, agency_code,
                      agency_address, client_code, client_address,
                      agency_sub_code, dockit_no, executive_code,
                      executive_zone, product_code, brand_code, key_no,
                      bill_remarks, print_remark, package_code,
                      no_of_insertion, insertion_date, repeating_day,
                      ad_type_code, ad_cat_code, ad_sub_cat_code, color_code,
                      uom_code, page_position_code, page_type_code, page_no,
                      ad_size_type_code, ad_size_height, ad_size_width,
                      rate_code, scheme_type_code, currency_code,
                      agrred_rate, agreed_amount, special_discount,
                      space_discount, special_charges, agency_status,
                      agency_type, agency_pay, agency_credit, total_area,
                      card_rate, card_amount, discount, discount_per,
                      bill_cycle, revenue_center, bill_pay, bill_height,
                      bill_width, bill_to, invoices, vts, bill_add,
                      trade_disc, agency_out, box_code, box_no, box_agency,
                      box_client, box_address, comp_code, userid,
                      creation_datetime, booking_type, tfn, coupan_ad,
                      campaign, bill_amount, page_prem, page_amount,
                      prem_per, gross_amount, ad_size_column, bill_column,
                      bill_area, special_disc_per, space_disc_per, paid_ins,
                      contract_rate, deviation, variant_code, contract_name,
                      contract_type, card_name, card_type, card_month,
                      card_year, card_number, receipt_no, ad_subcat3,
                      ad_subcat4, ad_subcat5, bg_color, bullet_code,
                      bullet_premium, material_status, receipt_date,
                      prev_cioid, prev_receipt, prev_grossamt, region,
                      variant, colortype, logo_h, logo_w, logo_color,
                      logo_uom, sapid, retainer, add_agency_comm,
                      audit_comment, mobileno, add_agency_comm_amt,
                      retainer_comm, retainer_comm_amt, cash_recieved,
                      cont_gross, ciragency, cirrate, ciredition,
                      cirpublication, ciragency_subcode, barter_type,
                      app_status, app_remarks, app_date, app_user,
                      rodocstatus, cashdiscount, cashdisctype, attachment1,
                      attachment2, disc_premium, doctype, chktradedisc,
                      chk_no, chk_date, chk_amt, chk_bank_name, our_bank,
                      dealerpanel, dealer_h, dealer_w, dealertype,
                      active_agreedrate, active_agreedamt, localgrossamt,
                      localbillamt, package_type, ad_refid, receipt_currency,
                      conv_curr_rate, revise_date, client_type,
                      translation_code, translation_premium,
                      cancellation_charge, translation_disc, posprem_disc)
            SELECT date_time, branch, booked_by, newid cio_booking_id,
                   prev_booking, applied_by, audit_g,
                   CASE
                      WHEN NVL (v_direct_client, 0) > 0
                      AND bill_pay = 'CA0'
                      AND ro_status = '1'
                         THEN newid
                      ELSE ro_no
                   END ro_no,
                   ro_date, caption, bill_status, ro_status, agency_code,
                   agency_address, client_code, client_address,
                   agency_sub_code, dockit_no, executive_code,
                   executive_zone, product_code, brand_code, key_no,
                   bill_remarks, print_remark, package_code, no_of_insertion,
                   insertion_date, repeating_day, ad_type_code, ad_cat_code,
                   ad_sub_cat_code, color_code, uom_code, page_position_code,
                   page_type_code, page_no, ad_size_type_code,
                   ad_size_height, ad_size_width, rate_code,
                   scheme_type_code, currency_code, agrred_rate,
                   agreed_amount, special_discount, space_discount,
                   special_charges, agency_status, agency_type, agency_pay,
                   agency_credit, total_area, card_rate, card_amount,
                   discount, discount_per, bill_cycle, revenue_center,
                   bill_pay, bill_height, bill_width, bill_to, invoices, vts,
                   bill_add, trade_disc, agency_out, box_code, box_no,
                   box_agency, box_client, box_address, comp_code, userid,
                   creation_datetime, booking_type, tfn, coupan_ad, campaign,
                   bill_amount, page_prem, page_amount, prem_per,
                   gross_amount, ad_size_column, bill_column, bill_area,
                   special_disc_per, space_disc_per, paid_ins, contract_rate,
                   deviation, variant_code, contract_name, contract_type,
                   card_name, card_type, card_month, card_year, card_number,
                   receipt_no, ad_subcat3, ad_subcat4, ad_subcat5, bg_color,
                   bullet_code, bullet_premium, material_status,
                   receipt_date, prev_cioid, prev_receipt, prev_grossamt,
                   region, variant, colortype, logo_h, logo_w, logo_color,
                   logo_uom, sapid, retainer, add_agency_comm, audit_comment,
                   mobileno, add_agency_comm_amt, retainer_comm,
                   retainer_comm_amt, cash_recieved, cont_gross, ciragency,
                   cirrate, ciredition, cirpublication, ciragency_subcode,
                   barter_type, app_status, app_remarks, app_date, app_user,
                   rodocstatus, cashdiscount, cashdisctype, attachment1,
                   attachment2, disc_premium, doctype, chktradedisc, chk_no,
                   chk_date, chk_amt, chk_bank_name, our_bank, dealerpanel,
                   dealer_h, dealer_w, dealertype, active_agreedrate,
                   active_agreedamt, localgrossamt, localbillamt,
                   package_type, ad_refid, receipt_currency, conv_curr_rate,
                   revise_date, client_type, translation_code,
                   translation_premium, cancellation_charge,
                   translation_disc, posprem_disc
              FROM tbl_booking_mast_g
             WHERE cio_booking_id = pcioid;

         INSERT INTO tbl_booking_insert_q
                     (insert_id, cio_booking_id, no_insert, edition_code,
                      publication_code, pub_cent_code, supp_code, edition,
                      insert_date, col_code, height, width, size_book,
                      page_post, premium1, prem_per1, premium2, prem_per2,
                      premium_allow, ad_cat, ad_sub_cat, latest_by,
                      repeating_date, status_material, file_name, card_rate,
                      disc_rate, insert_status, bill_status, agreed_rate,
                      pai_free_ins, solo_rate, gross_rate, comp_code, userid,
                      page_no, remarks, pub_height, pub_width, page_prem,
                      page_per, no_ofcolumn, bill_amt, bill_rate, logo_h,
                      logo_w, logo_name, ad_subcat3, ad_subcat4, ad_subcat5,
                      package_code, bill_no, bill_date, inserts, pkg_alias,
                      cont_gross_amt, app_status, app_remarks, app_date,
                      app_user, special_size1, vatamt, boxcharge, vat_inc,
                      localgrossamt, localbillamt, sectioncode, resource_no,
                      caption, dealer_h, dealer_w, discount,ROUND_VALUE)
            SELECT insert_id, newid cio_booking_id, no_insert, edition_code,
                   publication_code, pub_cent_code, supp_code, edition,
                   insert_date, col_code, height, width, size_book,
                   page_post, premium1, prem_per1, premium2, prem_per2,
                   premium_allow, ad_cat, ad_sub_cat, latest_by,
                   repeating_date, status_material, file_name, card_rate,
                   disc_rate, insert_status, bill_status, agreed_rate,
                   pai_free_ins, solo_rate, gross_rate, comp_code, userid,
                   page_no, remarks, pub_height, pub_width, page_prem,
                   page_per, no_ofcolumn, bill_amt, bill_rate, logo_h,
                   logo_w, logo_name, ad_subcat3, ad_subcat4, ad_subcat5,
                   package_code, bill_no, bill_date, inserts, pkg_alias,
                   cont_gross_amt, app_status, app_remarks, app_date,
                   app_user, special_size1, vatamt, boxcharge, vat_inc,
                   localgrossamt, localbillamt, sectioncode, resource_no,
                   caption, dealer_h, dealer_w, discount,ROUND_VALUE
              FROM tbl_booking_insert_g
             WHERE cio_booking_id = pcioid;

         p_error := 'AA';
         p_new_cioid := newid;
      ELSE
         getautocodebooking.getautocodebooking_p (compcode         => pcentname,
                                                  auto1            => '0',
                                                  no1              => '0',
                                                  p_accounts       => v_cursor1,
                                                  p_accounts1      => v_cursor2
                                                 );

         FETCH v_cursor1
          INTO v_cursor1_var1, v_cursor1_var2;

         FETCH v_cursor2
          INTO v_cursor2_var1;

         IF pbkid_gentype = '1'
         THEN             --1 for First 3 character of Centre Name+Year + Slno
            newid :=
                   SUBSTR (pcentname, 1, 3)
               || v_cursor1_var2
               || LPAD (v_cursor1_var1, 8, '0');
         ELSIF pbkid_gentype = '2'
         THEN    --2 for First 3 character of Centre Name+Year + Userid + Slno
            newid :=
                  SUBSTR (pcentname, 1, 3)
               || v_cursor1_var2
               || LPAD (v_cursor1_var1, 8, '0')
               || puserid;
         ELSIF pbkid_gentype = '4'
         THEN                                                 --BK Type + Slno
            newid := pbk_type || LPAD (v_cursor1_var1, 8, '0');
         ELSE
            newid := LPAD (v_cursor1_var1, 8, '0');
         END IF;

         p_error := 'Y';
         p_new_cioid := newid;

         SELECT COUNT (*)
           INTO v_direct_client
           FROM tbl_booking_mast_g a, ad_direct_client_agency b
          WHERE a.cio_booking_id = pcioid
            AND a.agency_sub_code = b.ag_main_code || b.ag_sub_code;

         INSERT INTO tbladid_ins
                     (cioid, countnum, flag
                     )
              VALUES (newid, countnum, p_error
                     );

         INSERT INTO tbl_booking_mast
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
                      "Space_discount", "Special_charges", "Agency_status",
                      "Agency_type", "Agency_pay", "Agency_credit",
                      "Total_area", "Card_rate", "Card_amount", "Discount",
                      "Discount_per", "Bill_cycle", "Revenue_center",
                      "Bill_pay", "Bill_height", "Bill_width", "Bill_to",
                      "Invoices", "Vts", "Bill_add", "Trade_disc",
                      "Agency_out", "Box_code", "Box_no", "Box_agency",
                      "Box_client", "Box_address", "Comp_code", "Userid",
                      "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad",
                      "Campaign", "Bill_amount", "Page_prem", "Page_amount",
                      "Prem_per", "Gross_amount", "Ad_size_column",
                      "Bill_column", "Bill_area", "Special_disc_per",
                      "Space_disc_per", "Paid_ins", "Contract_rate",
                      "Deviation", "Variant_code", "Contract_name",
                      "Contract_type", "Card_name", "Card_type", "Card_month",
                      "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3",
                      "Ad_Subcat4", "Ad_subcat5", "Bg_color", "Bullet_code",
                      "Bullet_premium", "Material_status", "Receipt_date",
                      "prev_cioid", "prev_receipt", "prev_grossamt", "Region",
                      "Variant", "Colortype", "Logo_H", "Logo_W",
                      "Logo_color", "Logo_Uom", "SAPID", "RETAINER",
                      "ADD_AGENCY_COMM", "AUDIT_COMMENT", "MOBILENO",
                      "ADD_AGENCY_COMM_AMT", "RETAINER_COMM",
                      "RETAINER_COMM_AMT", "CASH_RECIEVED", "CONT_GROSS",
                      "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION",
                      "CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS",
                      "APP_REMARKS", "APP_DATE", "APP_USER", "RODOCSTATUS",
                      cashdiscount, cashdisctype, attachment1, attachment2,
                      disc_premium, doctype, chktradedisc, chk_no, chk_date,
                      chk_amt, chk_bank_name, our_bank, dealerpanel, dealer_h,
                      dealer_w, dealertype, active_agreedrate,
                      active_agreedamt, localgrossamt, localbillamt,
                      package_type, ad_refid, receipt_currency,
                      conv_curr_rate, revise_date, client_type,
                      translation_code, translation_premium,
                      cancellation_charge, translation_disc, posprem_disc,
                      bill_hold,DESIGN_BOX,LOGOTYPE_PREM,ONLINE_AD,STYLE,FIXED_BOOKING,VAT_CODE)
            SELECT date_time, branch, booked_by, newid cio_booking_id,
                   prev_booking, applied_by, audit_g,
                   CASE
                      WHEN NVL (v_direct_client, 0) > 0
                      AND bill_pay = 'CA0'
                      AND ro_status = '1'
                         THEN newid
                      ELSE ro_no
                   END ro_no,
                   ro_date, caption, bill_status, ro_status, agency_code,
                   agency_address, client_code, client_address,
                   agency_sub_code, dockit_no, executive_code, executive_zone,
                   product_code, brand_code, key_no, bill_remarks,
                   print_remark, package_code, no_of_insertion,
                   insertion_date, repeating_day, ad_type_code, ad_cat_code,
                   ad_sub_cat_code, color_code, uom_code, page_position_code,
                   page_type_code, page_no, ad_size_type_code, ad_size_height,
                   ad_size_width, rate_code, scheme_type_code, currency_code,
                   agrred_rate, agreed_amount, special_discount,
                   space_discount, special_charges, agency_status,
                   agency_type, agency_pay, agency_credit, total_area,
                   card_rate, card_amount, discount, discount_per, bill_cycle,
                   revenue_center, bill_pay, bill_height, bill_width, bill_to,
                   invoices, vts, bill_add, trade_disc, agency_out, box_code,
                   box_no, box_agency, box_client, box_address, comp_code,
                   userid, creation_datetime, booking_type, tfn, coupan_ad,
                   campaign, bill_amount, page_prem, page_amount, prem_per,
                   gross_amount, ad_size_column, bill_column, bill_area,
                   special_disc_per, space_disc_per, paid_ins, contract_rate,
                   deviation, variant_code, contract_name, contract_type,
                   card_name, card_type, card_month, card_year, card_number,
                   receipt_no, ad_subcat3, ad_subcat4, ad_subcat5, bg_color,
                   bullet_code, bullet_premium, material_status, receipt_date,
                   prev_cioid, prev_receipt, prev_grossamt, region, variant,
                   colortype, logo_h, logo_w, logo_color, logo_uom, sapid,
                   retainer, add_agency_comm, audit_comment, mobileno,
                   add_agency_comm_amt, retainer_comm, retainer_comm_amt,
                   cash_recieved, cont_gross, ciragency, cirrate, ciredition,
                   cirpublication, ciragency_subcode, barter_type, app_status,
                   app_remarks, app_date, app_user, rodocstatus, cashdiscount,
                   cashdisctype, attachment1, attachment2, disc_premium,
                   doctype, chktradedisc, chk_no, chk_date, chk_amt,
                   chk_bank_name, our_bank, dealerpanel, dealer_h, dealer_w,
                   dealertype, active_agreedrate, active_agreedamt,
                   localgrossamt, localbillamt, package_type, ad_refid,
                   receipt_currency, conv_curr_rate, revise_date, client_type,
                   translation_code, translation_premium, cancellation_charge,
                   translation_disc, posprem_disc, bill_hold,DESIGN_BOX,LOGOTYPE_PREM,ONLINE_AD,STYLE,FIXED_BOOKING,VAT_CODE
              FROM tbl_booking_mast_g
             WHERE cio_booking_id = pcioid;

         INSERT INTO tbl_booking_insert
                     ("Insert_Id", "Cio_Booking_Id", "No_Insert",
                      "Edition_Code", "Publication_Code", "Pub_Cent_Code",
                      "Supp_Code", "Edition", "Insert_Date", "Col_Code",
                      "Height", "Width", "Size_Book", "Page_Post", "Premium1",
                      "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow",
                      "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Repeating_Date",
                      "Status_Material", "File_Name", "Card_Rate",
                      "Disc_Rate", "Insert_Status", "Bill_Status",
                      "Agreed_Rate", "Pai_Free_Ins", "Solo_Rate",
                      "Gross_Rate", "Comp_Code", "Userid", "Page_No",
                      "Remarks", "Pub_Height", "Pub_Width", "Page_Prem",
                      "Page_Per", "No_Ofcolumn", "Bill_Amt", "Bill_Rate",
                      "Logo_H", "Logo_W", "Logo_name", "AD_SUBCAT3",
                      "AD_SUBCAT4", "AD_SUBCAT5", "PACKAGE_CODE", "BILL_NO",
                      "BILL_DATE", "INSERTS", "PKG_ALIAS", "CONT_GROSS_AMT",
                      "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER",
                      special_size1, vatamt, boxcharge, vat_inc,
                      localgrossamt, localbillamt, sectioncode, resource_no,
                      caption, dealer_h, dealer_w, discount,
                      insert_status_pub,SPECIAL_SIZE2,agncyamnt,adlgncyamt,spldisamt,cashdisamt,ROUND_VALUE)
            SELECT insert_id, newid cio_booking_id, no_insert, edition_code,
                   publication_code, pub_cent_code, supp_code, edition,
                   insert_date, col_code, height, width, size_book, page_post,
                   premium1, prem_per1, premium2, prem_per2, premium_allow,
                   ad_cat, ad_sub_cat, latest_by, repeating_date,
                   status_material, replace(file_name,pcioid,newid),
                   card_rate, disc_rate, insert_status, bill_status,
                   agreed_rate, pai_free_ins, solo_rate, gross_rate,
                   comp_code, userid, page_no, remarks, pub_height, pub_width,
                   page_prem, page_per, no_ofcolumn, bill_amt, bill_rate,
                   logo_h, logo_w, logo_name, ad_subcat3, ad_subcat4,
                   ad_subcat5, package_code, bill_no, bill_date, inserts,
                   pkg_alias, cont_gross_amt, app_status, app_remarks,
                   app_date, app_user, special_size1, vatamt, boxcharge,
                   vat_inc, localgrossamt, localbillamt, sectioncode,
                   resource_no, caption, dealer_h, dealer_w, discount,
                   insert_status_pub,SPECIAL_SIZE2,agncyamnt,adlgncyamt,spldisamt,cashdisamt,ROUND_VALUE
              FROM tbl_booking_insert_g
             WHERE cio_booking_id = pcioid;

         INSERT INTO tbl_booking_vts
                     (compcode, cioid, insertid, vts, publication, edition,
                      rate, creationdatetime, ciragcode, ciragsubcode, center,
                      branch, publishdate)
            SELECT compcode, newid cioid, insertid, vts, publication, edition,
                   rate, creationdatetime, ciragcode, ciragsubcode, center,
                   branch, publishdate
              FROM tbl_booking_vts_g
             WHERE cioid = pcioid;
             
             
             
                
             
             
                         
             
             
             

         INSERT INTO tbl_booking_insert_sizesplit
                     (cioid, receiptno, insertid, insertdate, height, width,
                      area, srno, creationdatetime)
            SELECT newid cioid, receiptno, insertid, insertdate, height,
                   width, area, srno, creationdatetime
              FROM tbl_booking_insert_sizesplit_g
             WHERE cioid = pcioid;

         --INSERT INTO ABCTEST VALUES(newid,counttest);
         INSERT INTO tbl_booking_subedition
                     (comp_code, cioid, insertid, publication, edition,
                      insertdate, height, width, totalarea, insertstatus,
                      receiptno, srno, no_insert, page_no)
            SELECT comp_code, newid cioid, insertid, publication, edition,
                   insertdate, height, width, totalarea, insertstatus,
                   receiptno, srno, no_insert, page_no
              FROM tbl_booking_subedition_g
             WHERE tbl_booking_subedition_g.cioid = pcioid;

insert into tbl_oldnewcioid(oldid,newcioid) values(pcioid,newid);
         INSERT INTO tbl_booking_sharing_trans
                     (publication, TYPE, sharing, cioid, srno)
            SELECT publication, TYPE, sharing, newid cioid, srno
              FROM tbl_booking_sharing_trans_g
             WHERE cioid = pcioid;

         INSERT INTO tbl_booking_fmg_trans
                     (cioid, insertid, creationdatetime, fmg_reasons)
            SELECT newid cioid, insertid, creationdatetime, fmg_reasons
              FROM tbl_booking_fmg_trans_g
             WHERE cioid = pcioid;

         UPDATE tbl_matter
            SET "cioid" = newid
          WHERE "cioid" = pcioid;

         SELECT "Bill_pay", "ro_status"
           INTO billpay, rostatus
           FROM tbl_booking_mast
          WHERE "cio_booking_id" = newid;

         IF billpay = 'CA0' AND rostatus = '1'
         THEN
            DECLARE
               CURSOR c1
               IS
                  SELECT *
                    FROM tbl_booking_mast
                   WHERE "cio_booking_id" = newid;

               v1             c1%ROWTYPE;
               v_error        VARCHAR2 (2000);
               v_rcptno_r     VARCHAR2 (50);
               vrecpt         VARCHAR2 (20);
               branchcode     VARCHAR2 (20);
               vrepcode       VARCHAR2 (20);
               subagencyreg   VARCHAR2 (20);
               prevcioid_v    VARCHAR2 (50);
               billamt_v      FLOAT;
               grossamt_v     FLOAT;
               v_curdate      DATE;
               v_conrate float;
               localbillamt_v float;
            BEGIN
               OPEN c1;

               FETCH c1
                INTO v1;

               BEGIN
                  SELECT "Branch_Code"
                    INTO branchcode
                    FROM branch_mst
                   WHERE "Comp_Code" = v1."Comp_code"
                     AND "Branch_Name" = v1."branch";
               EXCEPTION
                  WHEN NO_DATA_FOUND
                  THEN
                     branchcode := v1."branch";
               END;

               BEGIN
                  SELECT "SUB_Agency_Code"
                    INTO subagencyreg
                    FROM agency_mast
                   WHERE "Comp_Code" = v1."Comp_code"
                     AND "code_subcode" = v1."Agency_sub_code";
               EXCEPTION
                  WHEN NO_DATA_FOUND
                  THEN
                     subagencyreg := '';
               END;

               vrecpt := v1."Receipt_no";
               prevcioid_v := v1."prev_cioid";

               IF prevcioid_v IS NULL OR v1."prev_receipt" IS NULL
               THEN
                  billamt_v := v1."Bill_amount";
                  grossamt_v := v1."Gross_amount";
                  v_curdate := TO_DATE (SYSDATE);
                  localbillamt_v:=v1.LOCALBILLAMT;
               ELSE
                  SELECT "Bill_amount", "Gross_amount",LOCALBILLAMT
                    INTO billamt_v, grossamt_v,localbillamt_v
                    FROM tbl_booking_mast
                   WHERE "cio_booking_id" = prevcioid_v;

                  billamt_v := v1."Bill_amount" - billamt_v;
                  grossamt_v := v1."Gross_amount" - grossamt_v;

                  IF grossamt_v = 0 OR grossamt_v IS NULL
                  THEN
                     grossamt_v := v1."Gross_amount";
                  END IF;

                  v_curdate := TO_DATE (SYSDATE);
                  localbillamt_v:=v1.LOCALBILLAMT-localbillamt_v;
               END IF;

               -- select substr(max("recptno"),1,12)||lpad(substr(max("recptno"),-6)+1,6,'0') into vrecpt from ad_rcpthdr where "unit"=branchcode and "doctype"='RCP' and
               -- "recptdt" between '1-mar-2011' and '31-mar-2011';

               --receiptsave_booking.receiptsave_booking_P(pcompcode,puserid , punit ,ptype , precpt , prdate , ppaymodres ,preceivedreg ,pvouno  ,pamount  ,pagency , pothercd ,
               --pchno  ,pchedate , pbank  , pnarration ,prep   , pvdate , pag_main_code ,pag_sub_code , ourbank,  cioid , execname , retainer ,
               -- prevcioid , p_error)
               BEGIN
                  SELECT "Cust_Name"
                    INTO clientname
                    FROM cust_mast
                   WHERE "Cust_Code" = v1."Client_code"
                     AND "Comp_Code" = v1."Comp_code";
               EXCEPTION
                  WHEN NO_DATA_FOUND
                  THEN
                     clientname := v1."Client_code";
               END;
                begin
                 select nvl(to_number("Conv_Rate"),1) into v_conrate from  CURR_CONV_DET where "Curr_Code"=v1."Currency_code" and CONV_CURRENCY=v1.RECEIPT_CURRENCY and v1."date_time" BETWEEN "Valid_From_Date" AND "Valid_Till_Date";
                exception
                when NO_DATA_FOUND THEN
                 v_conrate:=1;
                END;
               remarks :=
                     'RONO#'
                  || v1."RO_No"
                  || ' RODATE# '
                  || TO_CHAR (v1."RO_Date", 'dd-mon-yyyy')
                  || ' BOOKINGID# '
                  || v1."cio_booking_id"
                  || ' CLIENT#'
                  || clientname;
               receiptsave_booking.receiptsave_booking_p
                                                        (v1."Comp_code",
                                                         v1."Userid",
                                                         v1."branch",
                                                         v1.doctype,
                                                         vrecpt,
                                                         v_curdate,
                                                         v1."Bill_pay",
                                                         '',
                                                         '',
                                                         billamt_v,
                                                         v1."Agency_sub_code",
                                                         grossamt_v,
                                                         '',
                                                         '',
                                                         '',
                                                         remarks,
                                                         vrepcode,
                                                         v1."date_time",
                                                         v1."Agency_code",
                                                         subagencyreg,
                                                         '',
                                                         v1."cio_booking_id",
                                                         v1."Executive_code",
                                                         v1.retainer,
                                                         v1."prev_cioid",
                                                         localbillamt_v,
                                                         v1.RECEIPT_CURRENCY,
                                                         v_conrate,
                                                         v_rcptno_r,
                                                         v_error
                                                        );

               UPDATE tbl_booking_mast
                  SET "Receipt_no" = v_rcptno_r,
                      "Receipt_date" = v_curdate
                WHERE "cio_booking_id" = v1."cio_booking_id";

               CLOSE c1;

               COMMIT;
            END;
         END IF;
      END IF;
    /*
    INSERT INTO TBL_BOOKING_MAST("date_time", "branch", "booked_by", "cio_booking_id", "prev_booking", "applied_by", "audit", "RO_No", "RO_Date", "Caption", "bill_status", "ro_status", "Agency_code", "Agency_address", "Client_code", "Client_address", "Agency_sub_code", "Dockit_no", "Executive_code", "Executive_zone", "Product_code", "Brand_code", "Key_no", "Bill_remarks", "Print_remark", "Package_code", "No_of_insertion", "Insertion_date", "Repeating_day", "Ad_type_code", "Ad_cat_code", "Ad_sub_cat_code", "Color_code", "Uom_code", "Page_position_code", "Page_type_code", "Page_no", "Ad_size_type_code", "Ad_size_height", "Ad_size_width", "Rate_code", "Scheme_type_code", "Currency_code", "Agrred_rate", "Agreed_amount", "Special_discount", "Space_discount", "Special_charges", "Agency_status", "Agency_type", "Agency_pay", "Agency_credit", "Total_area", "Card_rate", "Card_amount", "Discount", "Discount_per", "Bill_cycle", "Revenue_center", "Bill_pay", "Bill_height", "Bill_width", "Bill_to", "Invoices", "Vts", "Bill_add", "Trade_disc", "Agency_out", "Box_code", "Box_no", "Box_agency", "Box_client", "Box_address", "Comp_code", "Userid", "Creation_datetime", "Booking_type", "Tfn", "Coupan_ad", "Campaign", "Bill_amount", "Page_prem", "Page_amount", "Prem_per", "Gross_amount", "Ad_size_column", "Bill_column", "Bill_area", "Special_disc_per", "Space_disc_per", "Paid_ins", "Contract_rate", "Deviation", "Variant_code", "Contract_name", "Contract_type", "Card_name", "Card_type", "Card_month", "Card_year", "Card_number", "Receipt_no", "Ad_Subcat3", "Ad_Subcat4", "Ad_subcat5", "Bg_color", "Bullet_code", "Bullet_premium", "Material_status", "Receipt_date", "prev_cioid", "prev_receipt", "prev_grossamt", "Region", "Variant", "Colortype", "Logo_H", "Logo_W", "Logo_color", "Logo_Uom", "SAPID", "RETAINER", "ADD_AGENCY_COMM", "AUDIT_COMMENT", "MOBILENO", "ADD_AGENCY_COMM_AMT", "RETAINER_COMM", "RETAINER_COMM_AMT", "CASH_RECIEVED", "CONT_GROSS", "CIRAGENCY", "CIRRATE", "CIREDITION", "CIRPUBLICATION", "CIRAGENCY_SUBCODE", "BARTER_TYPE", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER", "RODOCSTATUS")
   SELECT DATE_TIME, BRANCH, BOOKED_BY, CIO_BOOKING_ID, PREV_BOOKING, APPLIED_BY, AUDIT_G, RO_NO, RO_DATE, CAPTION, BILL_STATUS, RO_STATUS, AGENCY_CODE, AGENCY_ADDRESS, CLIENT_CODE, CLIENT_ADDRESS, AGENCY_SUB_CODE, DOCKIT_NO, EXECUTIVE_CODE, EXECUTIVE_ZONE, PRODUCT_CODE, BRAND_CODE, KEY_NO, BILL_REMARKS, PRINT_REMARK, PACKAGE_CODE, NO_OF_INSERTION, INSERTION_DATE, REPEATING_DAY, AD_TYPE_CODE, AD_CAT_CODE, AD_SUB_CAT_CODE, COLOR_CODE, UOM_CODE, PAGE_POSITION_CODE, PAGE_TYPE_CODE, PAGE_NO, AD_SIZE_TYPE_CODE, AD_SIZE_HEIGHT, AD_SIZE_WIDTH, RATE_CODE, SCHEME_TYPE_CODE, CURRENCY_CODE, AGRRED_RATE, AGREED_AMOUNT, SPECIAL_DISCOUNT, SPACE_DISCOUNT, SPECIAL_CHARGES, AGENCY_STATUS, AGENCY_TYPE, AGENCY_PAY, AGENCY_CREDIT, TOTAL_AREA, CARD_RATE, CARD_AMOUNT, DISCOUNT, DISCOUNT_PER, BILL_CYCLE, REVENUE_CENTER, BILL_PAY, BILL_HEIGHT, BILL_WIDTH, BILL_TO, INVOICES, VTS, BILL_ADD, TRADE_DISC, AGENCY_OUT, BOX_CODE, BOX_NO, BOX_AGENCY, BOX_CLIENT, BOX_ADDRESS, COMP_CODE, USERID, CREATION_DATETIME, BOOKING_TYPE, TFN, COUPAN_AD, CAMPAIGN, BILL_AMOUNT, PAGE_PREM, PAGE_AMOUNT, PREM_PER, GROSS_AMOUNT, AD_SIZE_COLUMN, BILL_COLUMN, BILL_AREA, SPECIAL_DISC_PER, SPACE_DISC_PER, PAID_INS, CONTRACT_RATE, DEVIATION, VARIANT_CODE, CONTRACT_NAME, CONTRACT_TYPE, CARD_NAME, CARD_TYPE, CARD_MONTH, CARD_YEAR, CARD_NUMBER, RECEIPT_NO, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, BG_COLOR, BULLET_CODE, BULLET_PREMIUM, MATERIAL_STATUS, RECEIPT_DATE, PREV_CIOID, PREV_RECEIPT, PREV_GROSSAMT, REGION, VARIANT, COLORTYPE, LOGO_H, LOGO_W, LOGO_COLOR, LOGO_UOM, SAPID, RETAINER, ADD_AGENCY_COMM, AUDIT_COMMENT, MOBILENO, ADD_AGENCY_COMM_AMT, RETAINER_COMM, RETAINER_COMM_AMT, CASH_RECIEVED, CONT_GROSS, CIRAGENCY, CIRRATE, CIREDITION, CIRPUBLICATION, CIRAGENCY_SUBCODE, BARTER_TYPE, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER, RODOCSTATUS FROM TBL_BOOKING_MAST_G WHERE SESID=USERENV ('sessionid') and CIO_BOOKING_ID=cioid;

   INSERT INTO TBL_BOOKING_insert("Insert_Id", "Cio_Booking_Id", "No_Insert", "Edition_Code", "Publication_Code", "Pub_Cent_Code", "Supp_Code", "Edition", "Insert_Date", "Col_Code", "Height", "Width", "Size_Book", "Page_Post", "Premium1", "Prem_Per1", "Premium2", "Prem_Per2", "Premium_Allow", "Ad_Cat", "Ad_Sub_Cat", "Latest_By", "Repeating_Date", "Status_Material", "File_Name", "Card_Rate", "Disc_Rate", "Insert_Status", "Bill_Status", "Agreed_Rate", "Pai_Free_Ins", "Solo_Rate", "Gross_Rate", "Comp_Code", "Userid", "Page_No", "Remarks", "Pub_Height", "Pub_Width", "Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt", "Bill_Rate", "Logo_H", "Logo_W", "Logo_name", "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5", "PACKAGE_CODE", "BILL_NO", "BILL_DATE", "INSERTS", "PKG_ALIAS", "CONT_GROSS_AMT", "APP_STATUS", "APP_REMARKS", "APP_DATE", "APP_USER")
   SELECT INSERT_ID, CIO_BOOKING_ID, NO_INSERT, EDITION_CODE, PUBLICATION_CODE, PUB_CENT_CODE, SUPP_CODE, EDITION, INSERT_DATE, COL_CODE, HEIGHT, WIDTH, SIZE_BOOK, PAGE_POST, PREMIUM1, PREM_PER1, PREMIUM2, PREM_PER2, PREMIUM_ALLOW, AD_CAT, AD_SUB_CAT, LATEST_BY, REPEATING_DATE, STATUS_MATERIAL, FILE_NAME, CARD_RATE, DISC_RATE, INSERT_STATUS, BILL_STATUS, AGREED_RATE, PAI_FREE_INS, SOLO_RATE, GROSS_RATE, COMP_CODE, USERID, PAGE_NO, REMARKS, PUB_HEIGHT, PUB_WIDTH, PAGE_PREM, PAGE_PER, NO_OFCOLUMN, BILL_AMT, BILL_RATE, LOGO_H, LOGO_W, LOGO_NAME, AD_SUBCAT3, AD_SUBCAT4, AD_SUBCAT5, PACKAGE_CODE, BILL_NO, BILL_DATE, INSERTS, PKG_ALIAS, CONT_GROSS_AMT, APP_STATUS, APP_REMARKS, APP_DATE, APP_USER FROM TBL_BOOKING_INSERT_G WHERE SESID=USERENV ('sessionid') and CIO_BOOKING_ID=cioid;

   */
   ELSE
      ROLLBACK;
      
      

      p_error := 'N';
      p_new_cioid := newid;

--DELETE FROM TBL_BOOKING_INSERT WHERE "Cio_Booking_Id"=cioid;
--DELETE FROM TBL_BOOKING_mast WHERE "cio_booking_id"=cioid;
      INSERT INTO tbladid_ins
                  (cioid, countnum, flag
                  )
           VALUES (newid, countnum, p_error
                  );
   END IF;
--delete from tbl_booking_mast_g where  CIO_BOOKING_ID=cioid;
--delete from tbl_booking_insert_g where  CIO_BOOKING_ID=cioid;
--delete from tbl_booking_vts_g where  cioid=newid;
END;
/

===========================================================================================//
CREATE OR REPLACE PACKAGE HT18JULY.getdataforexecute
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE getdataforexecute_p (
      compcode       IN       VARCHAR2,
      ciobid         IN       VARCHAR2,
      p_accounts     OUT      t_accounts_cursor,
      p_accounts1    OUT      t_accounts_cursor,
      p_accounts2    OUT      t_accounts_cursor,
      p_accounts3    OUT      t_accounts_cursor,
      p_accounts4    OUT      t_accounts_cursor,
      p_accounts5    OUT      t_accounts_cursor,
      p_accounts6    OUT      t_accounts_cursor,
      p_accounts7    OUT      t_accounts_cursor,
      p_accounts8    OUT      t_accounts_cursor,
      p_accounts9    OUT      t_accounts_cursor,
      p_accounts10   OUT      t_accounts_cursor,
      p_accounts11   OUT      t_accounts_cursor,
      p_accounts12   OUT      t_accounts_cursor
   );
END getdataforexecute;
/

**********************************
CREATE OR REPLACE PACKAGE BODY HT18JULY.getdataforexecute
IS
   PROCEDURE getdataforexecute_p (
      compcode       IN       VARCHAR2,
      ciobid         IN       VARCHAR2,
      p_accounts     OUT      t_accounts_cursor,
      p_accounts1    OUT      t_accounts_cursor,
      p_accounts2    OUT      t_accounts_cursor,
      p_accounts3    OUT      t_accounts_cursor,
      p_accounts4    OUT      t_accounts_cursor,
      p_accounts5    OUT      t_accounts_cursor,
      p_accounts6    OUT      t_accounts_cursor,
      p_accounts7    OUT      t_accounts_cursor,
      p_accounts8    OUT      t_accounts_cursor,
      p_accounts9    OUT      t_accounts_cursor,
      p_accounts10   OUT      t_accounts_cursor,
      p_accounts11   OUT      t_accounts_cursor,
      p_accounts12   OUT      t_accounts_cursor
   )
   AS
   --adv_subcat_code   varchar2(20);
   --adcat3 varchar2(20);
   --adcat4 varchar2(20);
   BEGIN
      --BEGIN
      INSERT INTO advcategories
         SELECT DISTINCT "Ad_Sub_Cat", "AD_SUBCAT3", "AD_SUBCAT4"
                    FROM tbl_booking_insert
                   WHERE /*("Comp_Code"=compcode) and */ ("Cio_Booking_Id" =
                                                                       ciobid);

          --EXCEPTION WHEN NO_DATA_FOUND
          --THEN NULL;
      --END;
      OPEN p_accounts FOR
         SELECT   "Cio_Booking_Id" AS "cio_booking_id", "Edition",
                  "Insert_Date" AS "Insert_date", "Col_Code" AS "Col_code",
                  "Height", "Width", "Size_Book" AS "Size_book",
                  "Page_Post" AS "Page_post", "Premium1",
                  "Prem_Per1" AS "Prem_per1", "Premium2",
                  NVL ("Prem_Per2", '0') AS "Prem_per2",
                  "Premium_Allow" AS "Premium_allow", "Ad_Cat" AS "Ad_cat",
                  "Ad_Sub_Cat" AS "Ad_sub_cat", "Latest_By" AS "Latest_by",
                  "Status_Material" AS "Status_material",
                  "File_Name" AS "File_name", "Card_Rate" AS "Card_rate",
                  NVL ("Disc_Rate", '0') AS "Disc_rate",
                  "Insert_Status" AS "Insert_status",
                  "Bill_Status" AS "Bill_status", "Comp_Code" AS "comp_code",
                  "Userid", "Repeating_Date" AS "Repeating_date",
                  "No_Insert" AS "no_insert",
                  "Edition_Code" AS "Edition_code",
                  "Publication_Code" AS "Publication_code",
                  "Pub_Cent_Code" AS "Pub_cent_code",
                  "Supp_Code" AS "Supp_code",
                  NVL ("Agreed_Rate", '0') AS "Agreed_rate",
                  "Pai_Free_Ins" AS "Pai_free_ins",
                  NVL ("Solo_Rate", '0') AS "Solo_rate",
                  "Insert_Id" AS "insert_id", "Gross_Rate" AS "Gross_rate",
                  "Page_No" AS "Page_no", "Remarks",
                  "Page_Prem" AS "Page_prem",
                  NVL ("Page_Per", '0') AS "page_per",
                  "No_Ofcolumn" AS "No_ofcolumn", "Bill_Amt" AS "Bill_Amt",
                  "Bill_Rate" AS "Bill_rate", "Logo_H" AS "Logo_H",
                  "Logo_W" AS "Logo_W", "Logo_name" AS "Logo_name",
                  "AD_SUBCAT3", "AD_SUBCAT4", "AD_SUBCAT5", package_code,
                  inserts, pkg_alias, "Publication_Code" AS "PUBCODE",
                  (SELECT vts
                     FROM tbl_booking_vts
                    WHERE cioid = "Cio_Booking_Id"
                      AND insertid = "Insert_Id") AS vts,
                  (SELECT publication
                     FROM tbl_booking_vts
                    WHERE cioid = "Cio_Booking_Id"
                      AND insertid = "Insert_Id") AS cirpublication,
                  (SELECT edition
                     FROM tbl_booking_vts
                    WHERE cioid = "Cio_Booking_Id"
                      AND insertid = "Insert_Id") AS ciredition,
                  (SELECT rate
                     FROM tbl_booking_vts
                    WHERE cioid = "Cio_Booking_Id"
                      AND insertid = "Insert_Id") AS cirrate,
                  (SELECT publishdate
                     FROM tbl_booking_vts
                    WHERE cioid = "Cio_Booking_Id"
                      AND insertid = "Insert_Id") AS cirpublishdate,
                  (SELECT edtn_name
                     FROM cir_edtn_mast
                    WHERE comp_code = compcode
                      AND edtn =
                             (SELECT edition
                                FROM tbl_booking_vts
                               WHERE cioid = "Cio_Booking_Id"
                                 AND insertid = "Insert_Id"))
                                                           AS cireditionname,
                  (SELECT NVL (priority, '1')
                     FROM tbl_priority_uom
                    WHERE edition_code =
                                tbl_booking_insert."Edition_Code"
                      AND tbl_priority_uom.combin_code =
                                               tbl_booking_insert.package_code)
                                                                 AS priority,
                  (SELECT SPLIT
                     FROM combin_mast
                    WHERE "Combin_Code" = package_code) AS SPLIT,
                  special_size1, vatamt, NVL (boxcharge, '') AS boxcharge,
                  NVL (vat_inc, '0') AS vat_inc,
                  NVL (localgrossamt, "Gross_Rate") AS localgrossamt,
                  NVL (localbillamt, "Bill_Amt") AS localbillamt,
                  NVL (sectioncode, '') AS sectioncode,
                  NVL (resource_no, '') AS resource_no,
                  NVL (caption, '') AS caption, dealer_h, dealer_w,
                  NVL (discount, '') AS discount, bill_date,
                  insert_status_pub,
                  (select "publication_type" from pub_mast where "Pub_Code"="Publication_Code") AS PUBTYPE,AGNCYAMNT as "agncyamnt",ADLGNCYAMT as "adlgncyamt",SPLDISAMT as "spldisamt",CASHDISAMT as "cashdisamt", 
                  ROUND_VALUE as ROUND_VALUE
             FROM tbl_booking_insert
            WHERE /*("Comp_Code"=compcode) and*/ ("Cio_Booking_Id" = ciobid)
         ORDER BY "Insert_Id";

      OPEN p_accounts1 FOR
         --select "Col_Name" as  "col_Name","Col_Code" as "col_Code" from col_mast where ("Comp_Code"=compcode);
         SELECT NULL AS "col_Name", NULL AS "col_Code"
           FROM DUAL;

      OPEN p_accounts2 FOR
         --select "premiumname" as "premiumname","Premiumcode" as "Premiumcode" from ADVPOS_PREM_MAST where ("comp_code"=compcode);
         SELECT NULL AS "premiumname", NULL AS "Premiumcode"
           FROM DUAL;

      OPEN p_accounts3 FOR
         --select "Adv_Subcat_Name","Adv_Subcat_Code" from adv_subcat_mast;
         SELECT NULL "Adv_Subcat_Name", NULL "Adv_Subcat_Code"
           FROM DUAL;

      OPEN p_accounts4 FOR
         --select "Uom_Name" as "uom_name","Uom_Code" as "uom_code" from uom_mast where ("Comp_Code"=compcode);
         SELECT NULL AS "uom_name", NULL AS "uom_code"
           FROM DUAL;

      OPEN p_accounts5 FOR
         --select "Adv_Type_Name" as "adv_type_name","Adv_Type_Code" as "adv_type_code" from adv_type_mast where "Comp_Code"=compcode;
         SELECT NULL AS "adv_type_name", NULL AS "adv_type_code"
           FROM DUAL;

      OPEN p_accounts6 FOR
         --select "Adv_Cat_Name" as "adv_cat_name","Adv_Cat_Code" as "adv_cat_code" from ADV_CAT_MAST where ("Comp_Code"=compcode);
         SELECT NULL AS "adv_cat_name", NULL AS "adv_cat_code"
           FROM DUAL;

      OPEN p_accounts7 FOR
         --select "Pos_Type_Code" as "pos_type_code","Pos_Type" as "pos_type" from advpos_type_mast where ("Comp_Code"=compcode);
         SELECT NULL AS "pos_type_code", NULL AS "pos_type"
           FROM DUAL;

      OPEN p_accounts8 FOR
         --select   "Paid_permission"   from Module_DetaiButtonl  where ("comp_code"=compcode) and ("Form_Name"='Booking_master');
         SELECT NULL "Paid_permission"
           FROM DUAL;

      OPEN p_accounts9 FOR
         --select "Logo_name" as "Logo_name"from tbl_booking_insert where "Comp_Code"=compcode and "Cio_Booking_Id"=ciobid and rownum<=1;
         SELECT NULL AS "Logo_name"
           FROM tbl_booking_insert
          WHERE "Comp_Code" = compcode
            AND "Cio_Booking_Id" = ciobid
            AND ROWNUM <= 1;

      OPEN p_accounts10 FOR
         --select "catname","catcode" from ad_cat3 where "subcatname" in (select AD_SUB_CAT from advcategories) order by "catname";
         SELECT NULL "catname", NULL "catcode"
           FROM DUAL;

      OPEN p_accounts11 FOR
         --select "Cat_Name","Cat_Code" from tbl_cat4 where "Sub_Cat_Name" in (select AD_SUBCAT3 from advcategories) order by "Cat_Name";
         SELECT NULL "Cat_Name", NULL "Cat_Code"
           FROM DUAL;

      OPEN p_accounts12 FOR
         --select "Cat_Name","Cat_Code" from tbl_cat5 where "Sub_Cat_Name" in (select AD_SUBCAT4 from advcategories) order by "Cat_Name";
         SELECT NULL "Cat_Name", NULL "Cat_Code"
           FROM DUAL;
   END getdataforexecute_p;
END getdataforexecute;
/
=======================================================================================================
CREATE OR REPLACE PACKAGE HT18JULY.insertintobookchild_display
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

agnamnt in varchar2,
      adlgncyamnt in varchar2,
      spldiscamt in varchar2,
      cashdamnt in varchar2, 
ROUNDOFF in float,
P_ip  in varchar2,
P_RATE_AUDIT_FLAG in varchar2
   );
END insertintobookchild_display;
/
*************************************************************
CREATE OR REPLACE PACKAGE BODY HT18JULY.insertintobookchild_display
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
      disc_p               IN   FLOAT,
      
      agnamnt in varchar2,
      adlgncyamnt in varchar2,
      spldiscamt in varchar2,
      cashdamnt in varchar2, 
      ROUNDOFF in float,
      p_ip                 IN   VARCHAR2,
      p_rate_audit_flag    IN   VARCHAR2
   )
   AS
      heightm            NUMBER;
      widthm             NUMBER;
      insertstatusm      VARCHAR2 (50);
      cioidm             VARCHAR2 (50);
      edi                VARCHAR2 (50);
      publi              VARCHAR2 (50);
      pub_cent           VARCHAR2 (50);
      supp               VARCHAR2 (50);
      cou1               NUMBER;
      ID                 NUMBER;
      billnum            VARCHAR2 (50);
      retain             VARCHAR2 (50);
      executive          VARCHAR (50);
      insertidval        NUMBER;
      countcir           NUMBER;
      error1             VARCHAR2 (409);
      insertdatem        DATE;
      heightmain         NUMBER;
      widthmain          NUMBER;
      pagenomain          NUMBER;
      pagenom          NUMBER;
      insertstatusmain   VARCHAR2 (50);
      insertdatemain     DATE;
      totalsizemain      NUMBER;
      countnum           NUMBER;
      vatamtamt  varchar2(50);
   BEGIN
      heightm := height;
      widthm := width;
      insertstatusm := insertstatus;
      cioidm := cioid;
      insertdatem := insertdate;
      pagenom:=insert_pageno;

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
        IF(NVL(vatrate_p,0)>0) THEN        
            vatamtamt:=TO_CHAR(round((billamt-(billamt/(1+(vatrate_p/100)))),2));
        ELSE        
            vatamtamt:=NULL;        
        END IF;
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
         SELECT COUNT (*)
           INTO countnum
           FROM tbl_booking_insert
          WHERE "No_Insert" = insertno
            AND "Edition" = edition
            AND "Cio_Booking_Id" = cioid;

         IF countnum <= 0
         THEN
            SELECT insertid.NEXTVAL
              INTO insertidval
              FROM DUAL;

            INSERT INTO tbl_booking_insert
                        ("Cio_Booking_Id", "Edition", "Insert_Date",
                         "Col_Code", "Height", "Width", "Size_Book",
                         "Page_Post", "Premium1", "Prem_Per1", "Premium2",
                         "Prem_Per2", "Premium_Allow", "Ad_Cat",
                         "Ad_Sub_Cat", "Latest_By", "Status_Material",
                         "File_Name", "Card_Rate", "Disc_Rate",
                         "Insert_Status", "Bill_Status", "Comp_Code",
                         "Userid", "Repeating_Date", "No_Insert",
                         "Edition_Code", "Publication_Code", "Pub_Cent_Code",
                         "Supp_Code", "Pai_Free_Ins", "Agreed_Rate",
                         "Solo_Rate", "Gross_Rate", "Page_No", "Remarks",
                         "Page_Prem", "Page_Per", "No_Ofcolumn", "Bill_Amt",
                         "Bill_Rate", "Logo_H", "Logo_W", "Logo_name",
                         "Insert_Id", "AD_SUBCAT3", "AD_SUBCAT4",
                         "AD_SUBCAT5", package_code, inserts, pkg_alias,
                         boxcharge, vat_inc, vatamt, localgrossamt,
                         localbillamt, sectioncode, resource_no,
                         caption, dealer_h, dealer_w, discount,INSERT_STATUS_PUB,SPECIAL_SIZE2,AGNCYAMNT , ADLGNCYAMT ,SPLDISAMT ,CASHDISAMT,ROUND_VALUE
                        )
                 VALUES (cioid, edition, insertdate,
                         colid, height, width, totalsize,
                         pagepost, premium1, premper1, premium2,
                         premper2, premallow, adcategory,
                         adsubcat1, latestdate, material,
                         matfilename, cardrate, discrate,
                         insertstatus, billstatus, compcode,
                         userid, repeat, insertno,
                         edi, publi, pub_cent,
                         supp, paid, agrrate,
                         solorate, grossrate, insert_pageno, insert_remarks,
                         page_code, page_per, noofcol, billamt,
                         billrate, logo_h, logo_w, logo_name,
                         insertidval, ad_cat_3, ad_cat_4,
                         ad_cat_5, pkgcode, gridins, pkgalias,
                         boxcharge_p, vat_inc_p, vatrate_p, grossamtlocal_p,
                         billamtlocal_p, sectioncode_p, resourceno_p,
                         caption_inserts_p, dealerheight, dealerwidth, disc_p,'booked',vatamtamt,agnamnt,adlgncyamnt,spldiscamt,cashdamnt,ROUNDOFF
                        );

            IF (cirvts IS NOT NULL)
            THEN
               INSERT INTO tbl_booking_vts
                           (compcode, cioid, insertid, vts, publication,
                            edition, rate, ciragcode,
                            ciragsubcode, center, branch, publishdate
                           )
                    VALUES (compcode, cioid, insertidval, cirvts, cirpub,
                            ciredi, cirrate, ciragency_v,
                            ciragencysubcode_v, center_v, branch_v, cirdate_v
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
         END IF;
      ELSE
         SELECT "Insert_Date", "Height", "Width", "Insert_Status",
                "Size_Book","Page_No"
           INTO insertdatemain, heightmain, widthmain, insertstatusmain,
                totalsizemain,pagenomain
           FROM tbl_booking_insert
          WHERE "Insert_Id" = insertid1;
       if insertstatusmain !='billed' then   
        IF matfilename IS NOT NULL THEN
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
              --  Insert_Status_PUB = insertstatus,
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
                discount = disc_p,
                rate_audit_flag = p_rate_audit_flag,
                rate_audit_ip = p_ip,
                SPECIAL_SIZE2=vatamtamt,
                AGNCYAMNT =agnamnt,
                ADLGNCYAMT =adlgncyamnt,
                SPLDISAMT =spldiscamt,
                CASHDISAMT  =cashdamnt,ROUND_VALUE=ROUNDOFF
                
          WHERE "Cio_Booking_Id" = cioid AND "Insert_Id" = insertid1;
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
                "Card_Rate" = cardrate,
                "Disc_Rate" = discrate,
                "Insert_Status" = insertstatus,
              --  Insert_Status_PUB = insertstatus,
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
                discount = disc_p,
                rate_audit_flag = p_rate_audit_flag,
                rate_audit_ip = p_ip,
                AGNCYAMNT =agnamnt,
                ADLGNCYAMT =adlgncyamnt,
                SPLDISAMT =spldiscamt,
                CASHDISAMT  =cashdamnt
                ,ROUND_VALUE=ROUNDOFF
                 where
                "Cio_Booking_Id" = cioidm AND "Insert_Id" = insertid1;
         END IF; 

         IF (subedidata IS NULL)
         THEN
            IF insertstatus = 'cancel'
            THEN
               UPDATE tbl_booking_subedition
                  SET insertstatus = 'cancel'
                WHERE tbl_booking_subedition.cioid = cioidm
                  AND insertid = insertid1
                  AND tbl_booking_subedition.insertstatus NOT IN
                                                        ('publish', 'billed');
            ELSE
               IF (   (insertdatem IS NULL AND insertdatemain IS NOT NULL)
                   OR (insertdatem IS NOT NULL AND insertdatemain IS NULL)
                   OR (    insertdatem IS NOT NULL
                       AND insertdatemain IS NOT NULL
                       AND TO_CHAR (insertdatemain, 'dd/mm/yyyy') !=
                                           TO_CHAR (insertdatem, 'dd/mm/yyyy')
                      )
                  )
               THEN
                  UPDATE tbl_booking_subedition
                     SET tbl_booking_subedition.insertdate = insertdatem
                   WHERE tbl_booking_subedition.cioid = cioidm
                     AND tbl_booking_subedition.insertid = insertid1
                     AND tbl_booking_subedition.insertstatus != 'publish'
                     AND tbl_booking_subedition.insertstatus != 'billed';
               END IF;

               IF (heightm != heightmain)
               THEN
                  UPDATE tbl_booking_subedition
                     SET tbl_booking_subedition.height = heightm
                   WHERE tbl_booking_subedition.cioid = cioidm
                     AND tbl_booking_subedition.insertid = insertid1
                     AND tbl_booking_subedition.insertstatus != 'publish'
                     AND tbl_booking_subedition.insertstatus != 'billed';
               END IF;
                IF (pagenom != pagenomain)
               THEN
                  UPDATE tbl_booking_subedition
                     SET tbl_booking_subedition.PAGE_NO = pagenom
                   WHERE tbl_booking_subedition.cioid = cioidm
                     AND tbl_booking_subedition.insertid = insertid1
                     AND tbl_booking_subedition.insertstatus != 'publish'
                     AND tbl_booking_subedition.insertstatus != 'billed';
               END IF;
               IF (widthm != widthmain)
               THEN
                  UPDATE tbl_booking_subedition
                     SET tbl_booking_subedition.width = widthm
                   WHERE tbl_booking_subedition.cioid = cioidm
                     AND tbl_booking_subedition.insertid = insertid1
                     AND tbl_booking_subedition.insertstatus != 'publish'
                     AND tbl_booking_subedition.insertstatus != 'billed';
               END IF;

               IF (totalsize != totalsizemain)
               THEN
                  UPDATE tbl_booking_subedition
                     SET tbl_booking_subedition.totalarea = totalsize
                   WHERE tbl_booking_subedition.cioid = cioidm
                     AND tbl_booking_subedition.insertid = insertid1
                     AND tbl_booking_subedition.insertstatus != 'publish'
                     AND tbl_booking_subedition.insertstatus != 'billed';
               END IF;

               IF (insertstatusm != insertstatusmain)
               THEN
                  UPDATE tbl_booking_subedition
                     SET tbl_booking_subedition.insertstatus = insertstatusm
                   WHERE tbl_booking_subedition.cioid = cioidm
                     AND tbl_booking_subedition.insertid = insertid1
                     AND tbl_booking_subedition.insertstatus != 'publish'
                     AND tbl_booking_subedition.insertstatus != 'billed';
               END IF;
            END IF;
         END IF;

         BEGIN
            SELECT COUNT (*)
              INTO countcir
              FROM tbl_booking_vts
             WHERE cioid = cioidm AND insertid = insertid1;
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
                 VALUES (compcode, cioidm, insertidval, cirvts, cirpub,
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
             WHERE cioid = cioidm AND insertid = insertid1;
         END IF;

        /* IF insertstatus = 'billed'
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
         END IF;*/
      END IF;
      END IF;
   END insertintobookchild_display_p;
END insertintobookchild_display;
/
================================================================================================================
